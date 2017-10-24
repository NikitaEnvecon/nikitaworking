-----------------------------------------------------------------------------
--
--  Logical unit: IntfaceReplPackageUtil
--  Component:    FNDMIG
--
--  IFS Developer Studio Template Version 3.0
--
--  Date    Sign    History
--  ------  ------  ---------------------------------------------------------
--  100811  ChMuLK Bug #84970 - Certified the assert safe for dynamic SQLs
--  100525  JHMASE Bug #90882 - Alias in key columns generate packages with errors
--  070814  JHMASE Bug #67171 - Replication to IFS Connect does not work
--  060329  TRLYNO Bug #56862 - FNDMIG added functionality
--  060209  TRLYNO Bug #55643 - Changes in building procedure body
--  040507  TRLY   Created
--                 Bug #44483 - Replication of Object structure
-----------------------------------------------------------------------------

layer Core;

-------------------- PUBLIC DECLARATIONS ------------------------------------

-- Name of referred api
pl_api_  CONSTANT VARCHAR2(30) := 'PLSQLAP_Record_API';

-- Name of method in generated replication package
repl_procedure_name_ CONSTANT VARCHAR2(30) := 'Create_Message';

-- Linefeed
lf_          CONSTANT VARCHAR2(1) := chr(10);
rec_sep_     CONSTANT VARCHAR2(2) := chr(13)||chr(10);


TYPE intface_repl_struct_rec IS RECORD (
   view_name_        intface_repl_structure_tab.view_name%TYPE,
   parent_seq_       intface_repl_structure_tab.parent_seq%TYPE,
   struct_seq_       intface_repl_structure_tab.structure_seq%TYPE,
   select_where_     intface_repl_structure_tab.select_where%TYPE,
   record_name_      intface_repl_structure_tab.record_name%TYPE,
   element_name_     intface_repl_structure_tab.element_name%TYPE,
   element_type_     intface_repl_structure_tab.element_type%TYPE );
   

TYPE header_rec IS RECORD(
   message_sender_   intface_header_tab.message_name%TYPE,
   message_receiver_ intface_header_tab.message_receiver%TYPE,
   repl_id_          intface_header_tab.intface_name%TYPE,
   body_type_        intface_header_tab.message_type%TYPE,
   message_name_     intface_header_tab.message_name%TYPE,
   date_format_      intface_header_tab.date_format%TYPE );
   

TYPE level_rec IS RECORD (
   level_            NUMBER,
   first_level_      NUMBER,
   old_level_        NUMBER);
   
-- Array to save source text in + variables
TYPE varchar_tabtype IS
   TABLE OF VARCHAR2(2000)
   INDEX BY BINARY_INTEGER;
   

TYPE source_record IS RECORD(
   Type varchar_tabtype,
   text varchar_tabtype);
   
-- Array to save source text-types in
TYPE type_record IS RECORD(
   Type varchar_tabtype);
   
-- Record to be used in Get_One_Level_Data__, see also below
TYPE Repl_Cols IS RECORD
   (  intface_name    intface_repl_struct_cols_tab.intface_name%TYPE,
      structure_seq   intface_repl_struct_cols_tab.structure_seq%TYPE,
      column_name     intface_repl_struct_cols_tab.column_name%TYPE,
      data_type       intface_repl_struct_cols_tab.data_type%TYPE,
      flags           intface_repl_struct_cols_tab.flags%TYPE,
      column_alias    intface_repl_struct_cols_tab.column_alias%TYPE,
      on_insert       intface_repl_struct_cols_tab.on_insert%TYPE,
      on_update       intface_repl_struct_cols_tab.on_update%TYPE,
      parent_key_name intface_repl_struct_cols_tab.parent_key_name%TYPE);
      
-- Cursor used in Get_One_Level_Data__, to create record above,
column_cursor_ CONSTANT VARCHAR2(2000) :=
      ' SELECT intface_name, structure_seq, column_name, data_type, '||
               'flags, column_alias, on_insert, on_update, parent_key_name '||
      ' FROM intface_repl_struct_cols_tab '||
      ' WHERE intface_name = :intface_name '||
      ' AND structure_seq = :structure_seq '||
      ' ORDER BY column_seq';
      
-------------------- PRIVATE DECLARATIONS -----------------------------------


-------------------- LU SPECIFIC IMPLEMENTATION METHODS ---------------------

PROCEDURE Check_Former_Keys___ (
   intface_name_    IN VARCHAR2,
   structure_seq_   IN NUMBER,
   parent_key_name_ IN VARCHAR2,
   repl_mode_       IN VARCHAR2 )
IS
   column_exists_ BOOLEAN := FALSE;
   parent_key_missing_ EXCEPTION;
   struct_seq_ NUMBER;
   --
   CURSOR get_struct IS
      SELECT structure_seq
      FROM   intface_repl_structure
      WHERE intface_name = intface_name_
      AND  INSTR(on_insert||on_update,'TRUE') != 0 -- One of them must be checked
      CONNECT BY PRIOR structure_seq = parent_seq
         AND intface_name = intface_name_
         AND ((on_insert = 'TRUE' and repl_mode_ = 'I') OR
              (on_update = 'TRUE' and repl_mode_ = 'U'))
      START WITH parent_seq IS NULL
         AND intface_name = intface_name_;
   CURSOR get_prim_keys IS
      SELECT column_name
      FROM   intface_repl_struct_cols
      WHERE  intface_name = intface_name_
      AND structure_seq = struct_seq_
      AND parent_key_name is not NULL
      AND column_name = parent_key_name_;   
BEGIN
   FOR srec_ IN get_struct LOOP
      struct_seq_ := srec_.structure_seq;      
      -- Only check items prior to structure_seq_
      EXIT when struct_seq_ = structure_seq_;
      FOR prec_ IN get_prim_keys LOOP
         column_exists_ := TRUE;
      END LOOP;
   END LOOP;
   IF ( NOT column_exists_ ) THEN
      RAISE parent_key_missing_;
   END IF;
EXCEPTION
   WHEN parent_key_missing_ THEN
      Error_SYS.Record_General( lu_name_, 'KEYERR: Parent key :P1 does not exist in structures prior to :P2',  parent_key_name_, structure_seq_ );
END Check_Former_Keys___;


PROCEDURE Check_Lengths___ (
   start_body_ IN OUT VARCHAR2,
   key_var_    IN OUT VARCHAR2,
   cursor_     IN OUT VARCHAR2,
   rec_var_    IN OUT VARCHAR2,
   body_       IN OUT VARCHAR2,
   level_body_ IN OUT VARCHAR2,
   source_too_long_ IN OUT BOOLEAN )
IS
   source_length_ NUMBER;
BEGIN
   source_length_ := length(start_body_) +
                     length(key_var_) +
                     length(cursor_) +
                     length(rec_var_) +
                     length(body_) +
                     length(level_body_);
   --
   IF ( source_length_ > 32000 ) THEN
      --
      source_too_long_ := TRUE;
      --
      start_body_ := NULL;
      cursor_     := NULL;
      body_       := NULL;
   END IF;
END Check_Lengths___;

PROCEDURE Save_Source_Text___ (
   srec_         IN OUT source_record,
   source_count_ IN OUT NUMBER,
   type_         IN VARCHAR2,
   text_         IN VARCHAR2 )
IS
   ptr_   NUMBER := NULL;
   line_  VARCHAR2(2000);
   from_  NUMBER := NULL;
   to_    NUMBER;
   index_ NUMBER;
   --
BEGIN
   --
   LOOP
      -- Extract text between linefeeds
      EXIT WHEN to_ = 0;
      from_ := nvl(ptr_, 1);
      to_   := instr(text_, lf_, from_);
      index_ := instr(text_, lf_, from_);
      line_  := substr(text_, from_, index_-from_);
      ptr_   := to_+1;
      to_   := instr(text_, lf_, from_);
      -- Save it in PL table
      IF ( line_ IS NOT NULL ) THEN
         source_count_ := source_count_ + 1;
         srec_.type(source_count_) := type_;      
         srec_.text(source_count_) := line_;      
      END IF;
   END LOOP;   
END Save_Source_Text___;

PROCEDURE Write_Source_Text___ (
   write_count_  IN OUT NUMBER,
   header_rec_   IN header_rec,
   srec_         IN source_record,
   source_count_ IN NUMBER,
   trec_         IN type_record,
   type_count_   IN NUMBER )
IS
   type_ VARCHAR2(20);
BEGIN
   -- Source texts has been inserted into PL table in random order.
   -- Here we fetch the text ordered by type
   -- See also  Initialize_Type_Array___
   FOR i1 IN 1..type_count_ LOOP
      type_ := trec_.type(i1);
      FOR i2 IN 1..source_count_ LOOP
         IF ( srec_.type(i2) = type_ ) THEN
            write_count_ := write_count_ +1 ;
            INSERT INTO intface_job_detail_tab (
               intface_name, line_no, file_string, status, rowversion )
            VALUES (
               header_rec_.repl_id_, write_count_, srec_.text(i2), '4', sysdate);
         END IF;
      END LOOP;
   END LOOP;
END Write_Source_Text___;


PROCEDURE Initialize_Type_Array___ (
   trec_       IN OUT type_record,
   type_count_ IN OUT NUMBER,
   header_rec_ IN header_rec )
IS 
   mode_ VARCHAR2(1);
   text_ VARCHAR2(2000) := 'HEADER_'||lf_||
                           'START_'||lf_||
                           'KEYVAR_'||lf_||
                           'CURSOR_'||lf_||
                           'STARTBODY_'||lf_||
                           'BODY_'||lf_||
                           'ENDBODY_'||lf_||
                           'ENDPKG_'||lf_;
   ptr_   NUMBER := NULL;
   line_  VARCHAR2(2000);
   from_  NUMBER := NULL;
   to_    NUMBER;
   index_ NUMBER;
BEGIN
   -- Source texts will be inserted into PL table in random order.
   -- We use source_type as key to build procedure text for intface_job_detail tab.
   -- See also Write_Source_Text___
   mode_ := 'I';
   FOR i1 IN 1..2 LOOP
      LOOP
         -- Extract text between linefeeds
         EXIT WHEN to_ = 0;
         from_ := nvl(ptr_, 1);
         to_   := instr(text_, lf_, from_);
         index_ := instr(text_, lf_, from_);
         line_  := substr(text_, from_, index_-from_);
         ptr_   := to_+1;
         to_   := instr(text_, lf_, from_);
         -- Save it in PL table
         type_count_ := type_count_ + 1;
         trec_.type(type_count_) := line_||mode_;      
      END LOOP;
   mode_ := 'U';
   ptr_ := NULL;
   to_ := NULL;
   END LOOP;   
   --
   DELETE 
   FROM intface_job_detail_tab
   WHERE intface_name = header_rec_.repl_id_;
   --
END Initialize_Type_Array___ ;


PROCEDURE Set_Level_Tab___ (
   tab_    IN OUT VARCHAR2,
   level_  IN NUMBER )
IS
   tabulator_ VARCHAR2(3) := '   ';
BEGIN
   tab_ := NULL;
   FOR i IN 1..level_ LOOP
      tab_ := nvl(tab_,'')||tabulator_;
   END LOOP;   
END Set_Level_Tab___ ;


-------------------- LU SPECIFIC PRIVATE METHODS ----------------------------

FUNCTION Build_Package_Start__ (
   srec_         IN OUT source_record,
   source_count_ IN OUT NUMBER,
   package_name_ IN VARCHAR2,
   repl_mode_    IN VARCHAR2) RETURN VARCHAR2
IS
   start_package_ VARCHAR2(32000);
BEGIN
   --
   start_package_  := 'CREATE OR REPLACE PACKAGE BODY '||package_name_||lf_||
                      'IS '||lf_||
                      'PROCEDURE '||repl_procedure_name_ ||' ('||lf_||
                      '   attr_ IN VARCHAR2 ) '||lf_||
                      'IS'||lf_||
                      '   row_count_ NUMBER := 0;'||lf_;
   --
   Save_Source_Text___(srec_, source_count_, 'START_'||repl_mode_,start_package_);
   Save_Source_Text___(srec_, source_count_, 'STARTBODY_'||repl_mode_,'BEGIN'||lf_);
   RETURN start_package_;
END Build_Package_Start__;


PROCEDURE Build_End_Loop__ (
   end_loop_     IN OUT VARCHAR2,
   srec_         IN OUT source_record,
   source_count_ IN OUT NUMBER,
   tab_          IN OUT VARCHAR2,
   from_level_   IN     NUMBER,
   to_level_     IN     NUMBER,
   repl_mode_    IN     VARCHAR2 )
IS
   count_       NUMBER;
   source_text_ VARCHAR2(2000);
BEGIN
   end_loop_ := chr(10);
   count_ := (nvl(from_level_,0) - nvl(to_level_,0)) +1;
   FOR i IN 1..count_ LOOP
      source_text_ := tab_||'END LOOP;'||lf_;
      end_loop_ := end_loop_||source_text_;
      Save_Source_Text___(srec_, source_count_, 'BODY_'||repl_mode_,source_text_);
      tab_ := substr(tab_,1,length(tab_)-3);
   END LOOP;
END Build_End_Loop__;


PROCEDURE Build_One_Level_Data__ (
   start_body_       IN OUT VARCHAR2,
   key_var_          IN OUT VARCHAR2,
   cursor_           IN OUT VARCHAR2,
   rec_var_          IN OUT VARCHAR2,
   body_             IN OUT VARCHAR2,
   parent_key_count_ IN OUT NUMBER,
   master_rec_       IN OUT VARCHAR2,
   srec_             IN OUT source_record,
   source_count_     IN OUT NUMBER,
   source_too_long_  IN OUT BOOLEAN,
   tab_              IN OUT VARCHAR2,
   header_rec_       IN     header_rec,
   repl_mode_        IN     VARCHAR2,
   level_rec_        IN     level_rec,
   repl_str_rec_     IN     intface_repl_struct_rec,
   previous_view_    IN     VARCHAR2 )
IS
   where_clause_ VARCHAR2(32000);
   column_list_  VARCHAR2(32000);
   update_keys_  VARCHAR2(32000);
   level_body_   VARCHAR2(32000);
   cur_name_     VARCHAR2(2000);
   rec_name_     VARCHAR2(2000);
   var_name_     VARCHAR2(2000);
   use_column_   BOOLEAN;
   --
   level_key_count_  NUMBER;
   list_length_      NUMBER;
   parent_var_name_  VARCHAR2(100);
   source_text_      VARCHAR2(2000);
   --
   TYPE col_type IS REF CURSOR;
   col_           col_type;
   crec_          Repl_Cols;
BEGIN
   -- Set dynamic names used in FOR-statement
   cur_name_        := 'Get_'||repl_str_rec_.struct_seq_; -- Cursor name
   rec_name_        := 'rec_'||repl_str_rec_.struct_seq_; -- LOOP record name
   var_name_        := 'rec'||repl_str_rec_.struct_seq_;  -- PLSQLAP_Record_API.type_record_
   parent_var_name_ := 'rec'||repl_str_rec_.parent_seq_;  -- Used in Complete_Level_Body
   -- Set tabulator to be used
   Set_Level_Tab___ (tab_, level_rec_.level_);
   --
   -- Initialize counter
   level_key_count_ := 0;
   list_length_     := 0;
   --
   -- Build FOR-statement, save source text
   source_text_ := lf_||tab_||'FOR '||rec_name_||' IN '||cur_name_||' LOOP'||lf_;
   Save_Source_Text___(srec_, source_count_, 'BODY_'||repl_mode_,source_text_);
   body_ := body_||source_text_;
   --
   Build_Rec_Variables__(body_, master_rec_, srec_, source_count_, var_name_, header_rec_, repl_mode_, repl_str_rec_, tab_ );
   --
   -- Cursor select is static and declared in package header
   @ApproveDynamicStatement(2010-08-11,chmulk)
   OPEN col_ FOR column_cursor_
      USING IN header_rec_.repl_id_, IN repl_str_rec_.struct_seq_;
   LOOP
      FETCH col_ INTO crec_;
      EXIT WHEN col_%NOTFOUND;
      IF ( ( level_rec_.level_ = level_rec_.first_level_ OR instr(previous_view_,'DUAL')!= 0 ) 
            AND (crec_.parent_key_name IS NOT NULL )  ) THEN
         -- Build Start of body, unpack attr-string
         source_text_ := tab_||lower(crec_.column_name)||'_ := '||
            'Client_SYS.Get_Item_Value('||''''||crec_.column_name||''''||', attr_);'||lf_;
         start_body_ := start_body_||source_text_;
         Save_Source_Text___(srec_, source_count_, 'STARTBODY_'||repl_mode_,source_text_);
      END IF;
      -- Make boolean to synchronize update_keys_, column_list_ and level_body_
      IF ( (crec_.on_insert = 'TRUE' AND repl_mode_ = 'I' ) OR (crec_.on_update = 'TRUE' AND repl_mode_ = 'U' )) THEN
         use_column_ := TRUE;
      ELSE
         use_column_ := FALSE;
      END IF;
      IF ( crec_.parent_key_name IS NOT NULL ) THEN
         -- Check if variable is already present, make variablse for all key-columns
         IF ( instr(nvl(key_var_,'XX'),' '||lower(crec_.column_name)||'_ ') = 0 ) THEN
            source_text_ := '   '||lower(crec_.column_name)||'_ '||repl_str_rec_.view_name_||'.'||lower(crec_.column_name)||'%TYPE;'||lf_;
            key_var_ := key_var_||source_text_;
            Save_Source_Text___(srec_, source_count_, 'KEYVAR_'||repl_mode_,source_text_);
         END IF;
         IF ( level_rec_.level_ = level_rec_.first_level_) THEN
            parent_key_count_ := parent_key_count_ +1;
         ELSE
            level_key_count_ := level_key_count_ +1;
            -- Keys must appear in same order as parent keys of master view
            IF ( parent_key_count_ >= level_key_count_ ) THEN
               -- Check if primary keys correspond to first level's primary keys
               Check_Former_Keys___ (header_rec_.repl_id_, repl_str_rec_.struct_seq_, crec_.parent_key_name, repl_mode_ );
            END IF;
         END IF;
         Build_Where_Clause__(where_clause_, crec_.column_name, crec_.parent_key_name, level_rec_);
         IF ( use_column_ ) THEN
            -- Last action within each LOOP is to update key-variables
            update_keys_ := update_keys_||tab_||'   '||lower(crec_.column_name)||'_ := '||rec_name_||'.'||crec_.column_name||';'||lf_;
         END IF;
      END IF;
      IF ( use_column_ ) THEN
         IF (instr(crec_.column_name,' ') != 0) THEN
            crec_.column_alias := substr(crec_.column_name,instr(crec_.column_name,' ')+1);
            crec_.column_name  := substr(crec_.column_name,1,instr(crec_.column_name,' ')-1);
         END IF;
         Build_Column_List__(column_list_, list_length_, crec_,header_rec_);
         Build_Level_Body__(level_body_, rec_name_, var_name_, crec_, header_rec_, level_rec_.level_, tab_);
      END IF;
   END LOOP;
   CLOSE col_;
   --
   -- If statement exceeds 32k, we cannot perform EXECUTE IMMEDIATE
   -- See handling of variable source_too_long
   Check_Lengths___(start_body_ ,key_var_ ,cursor_, rec_var_ ,body_, level_body_ ,source_too_long_);
   --
   body_ := body_||Complete_Level_Body__( srec_, source_count_, level_body_, update_keys_, cur_name_, var_name_, header_rec_, repl_mode_, level_rec_, repl_str_rec_, previous_view_, parent_var_name_, tab_ );
   column_list_ := rtrim(column_list_,',');
   cursor_ := cursor_||Build_Cursor__( srec_, source_count_, cur_name_, where_clause_, column_list_, var_name_, header_rec_, repl_mode_, repl_str_rec_ );
END Build_One_Level_Data__;


PROCEDURE Build_Rec_Variables__ (
   rec_var_      IN OUT VARCHAR2,
   master_rec_   IN OUT VARCHAR2,
   srec_         IN OUT source_record,
   source_count_ IN OUT NUMBER,
   var_name_     IN     VARCHAR2,
   header_rec_   IN     header_rec,
   repl_mode_    IN     VARCHAR2,
   repl_str_rec_ IN     intface_repl_struct_rec,
   tab_          IN     VARCHAR2 )
IS
   source_text_  VARCHAR2(2000);
BEGIN
trace_sys.field(' in var_name ',var_name_);
   IF ( nvl(header_rec_.body_type_,'TRACE') = 'BIZAPI' ) THEN
      source_text_ := tab_||'   '||var_name_||' := '||pl_api_||'.New_Record('||''''||repl_str_rec_.record_name_||''''||');'||lf_;
      rec_var_ := rec_var_||source_text_;
      Save_Source_Text___(srec_, source_count_, 'BODY_'||repl_mode_,source_text_);
      IF ( master_rec_ IS NULL ) THEN
trace_sys.field(' master rec_ ',var_name_);
         master_rec_ := var_name_;
      END IF;
   ELSIF ( nvl(header_rec_.body_type_,'TRACE') = 'TRACE' ) THEN
      rec_var_ := rec_var_||'Trace_SYS.Message('||''''||repl_str_rec_.view_name_||''''||');'||lf_;
   END IF;
END Build_Rec_Variables__;


FUNCTION Build_Cursor__ (
   srec_         IN OUT source_record,
   source_count_ IN OUT NUMBER,
   cursor_name_  IN VARCHAR2,
   where_clause_ IN VARCHAR2,
   column_list_  IN VARCHAR2,
   var_name_     IN VARCHAR2,
   header_rec_   IN header_rec,
   repl_mode_    IN VARCHAR2,
   repl_str_rec_ IN intface_repl_struct_rec ) RETURN VARCHAR2
IS
   cursor_ VARCHAR2(32000);
   local_list_ VARCHAR2(32000) := column_list_;
   cursor_where_ VARCHAR2(32000) := NULL ;
BEGIN
   IF ( repl_str_rec_.select_where_ IS NOT NULL ) THEN
      -- Use where_clause from client
      cursor_where_ := '    WHERE '||repl_str_rec_.select_where_;
   ELSIF ( where_clause_ IS NOT NULL ) THEN
      -- Use where_clause built from key-columns
      cursor_where_ := where_clause_;
   END IF;
   IF ( local_list_ IS NULL AND upper(repl_str_rec_.view_name_) IN ('DUAL','SYS.DUAL') ) THEN
      local_list_ := '1';
   END IF;
   cursor_ :=  '   CURSOR '||cursor_name_||' IS '||lf_||
               '      SELECT '||local_list_||lf_||
               '      FROM '||repl_str_rec_.view_name_||lf_||
                 cursor_where_||';'||lf_;
   --
   IF ( nvl(header_rec_.body_type_,'TRACE') = 'BIZAPI' ) THEN
      -- Declare one recordtype for each cursor
      cursor_ := cursor_||'   '||var_name_||' '||pl_api_||'.type_record_;'||lf_||lf_ ;
   END IF;
   Save_Source_Text___(srec_, source_count_, 'CURSOR_'||repl_mode_,cursor_);
   RETURN cursor_;
END Build_Cursor__;


PROCEDURE Build_Column_List__ (
   column_list_ IN OUT VARCHAR2,
   list_length_ IN OUT NUMBER,
   col_rec_     IN     Repl_Cols,
   header_rec_  IN     header_rec )
IS
   local_column_name_ VARCHAR2(2000);
   column_name_ intface_repl_struct_cols_tab.column_name%TYPE;
   column_alias_ intface_repl_struct_cols_tab.column_alias%TYPE;
BEGIN
   column_alias_ := lower(col_rec_.column_alias);
   IF (instr(col_rec_.column_name,'''') != 0 ) THEN
      -- Hardcoded value, no change in Case
      column_name_ := col_rec_.column_name;
   ELSE
      column_name_ := lower(col_rec_.column_name);
   END IF;
   -- Convert columns of type date if date_format_ is entered
   -- Always make alias for these columns
   IF ( col_rec_.data_type = 'DATE' AND header_rec_.date_format_ IS NOT NULL ) THEN
      column_alias_ := nvl(column_alias_, column_name_);
      --
      local_column_name_ := 'to_char('||column_name_||','||
                      ''''||header_rec_.date_format_||''''||') ';
   ELSE
      local_column_name_ := column_name_;
   END IF;
   IF (column_alias_ IS NOT NULL ) THEN
      IF (col_rec_.parent_key_name IS NOT NULL) THEN
         local_column_name_ := local_column_name_||','||local_column_name_||' '||column_alias_||',';
      ELSE
         local_column_name_ := local_column_name_||' '||column_alias_||',';
      END IF;
   ELSE
      local_column_name_ := local_column_name_||',';
   END IF;
   IF ( (length(column_list_) + length(local_column_name_)-list_length_) > 100 ) THEN
      list_length_ := list_length_ + 100;
      column_list_ := column_list_||lf_||'              '||local_column_name_;
   ELSE
      column_list_ := column_list_||local_column_name_;
   END IF;
END Build_Column_List__;


PROCEDURE Build_Where_Clause__ (
   where_clause_    IN OUT VARCHAR2,
   column_name_     IN     VARCHAR2,
   parent_key_name_ IN     VARCHAR2,
   level_rec_       IN     level_rec )
IS
BEGIN
   IF ( where_clause_ IS NULL ) THEN
      where_clause_ := '      WHERE ';
   ELSE
      where_clause_ := where_clause_||lf_||'      AND ';
   END IF;
   -- First level must have exact match on key columns,
   -- elsewhere we use nvl to allow partial key input
   IF ( level_rec_.level_ = level_rec_.first_level_ ) THEN
      where_clause_ := where_clause_||lower(column_name_)||' = '||
         lower(parent_key_name_)||'_';
   ELSE
      where_clause_ := where_clause_||lower(column_name_)||' = '||
         'nvl('||lower(parent_key_name_)||'_'||','||lower(column_name_)||')';
   END IF;
END Build_Where_Clause__;


PROCEDURE Build_Level_Body__ (
   body_       IN OUT VARCHAR2,
   rec_name_   IN     VARCHAR2,
   var_name_   IN     VARCHAR2,
   col_rec_    IN     Repl_Cols,
   header_rec_ IN     header_rec,
   level_      IN     NUMBER,
   tab_        IN     VARCHAR2 )
IS
   margin_ VARCHAR2(2000) := NULL;
   column_name_  intface_repl_struct_cols_tab.column_name%TYPE := col_rec_.column_name;
   column_alias_ intface_repl_struct_cols_tab.column_name%TYPE := col_rec_.column_alias;
   format_var_ VARCHAR2(100) := NULL ;
BEGIN
   IF ( nvl(header_rec_.body_type_,'TRACE') = 'BIZAPI' ) THEN
      -- Make PLSQLAP_Record_API.Set_Value declarations
      IF ( col_rec_.data_type = 'DATE' AND header_rec_.date_format_ IS NULL ) THEN
         -- Add format parameter to date columns
         format_var_ := ', PLSQLAP_Record_API.dt_Date';
      END IF;
      body_ := body_||tab_||'   '||pl_api_||'.Set_Value('||
         var_name_||','||''''||nvl(column_alias_,column_name_)||''''||','||rec_name_||'.'||nvl(column_alias_,column_name_)||format_var_||');'||lf_;
   ELSIF ( nvl(header_rec_.body_type_,'TRACE') = 'TRACE' ) THEN
      FOR i IN 1..level_ LOOP
         margin_ := margin_||'   ';
      END LOOP;
      body_ := body_||tab_||'   '||'Trace_SYS.Field('||''''||margin_||nvl(column_alias_,column_name_)||''''||','||rec_name_||'.'||nvl(column_alias_,column_name_)||');'||lf_;
   END IF;
END Build_Level_Body__;


FUNCTION Complete_Level_Body__ (
   srec_          IN OUT source_record,
   source_count_  IN OUT NUMBER,
   level_body_    IN VARCHAR2,
   update_keys_   IN VARCHAR2,
   cur_name_      IN VARCHAR2,
   var_name_      IN VARCHAR2,
   header_rec_    IN header_rec,
   repl_mode_     IN VARCHAR2,
   level_rec_     IN level_rec,
   repl_str_rec_  IN intface_repl_struct_rec,
   previous_view_ IN VARCHAR2,
   parent_var_name_ IN VARCHAR2,
   tab_             IN VARCHAR2 ) RETURN VARCHAR2
IS
   body_ VARCHAR2(32000);
   add_element_ VARCHAR2(2000);
BEGIN
   body_ := level_body_;
   IF ( nvl(header_rec_.body_type_,'TRACE') = 'BIZAPI' ) THEN
      add_element_ := '.ADD_'||repl_str_rec_.element_type_;
      IF ( level_rec_.level_ != level_rec_.first_level_  ) THEN
         body_ := body_||tab_||'   '||pl_api_||add_element_||'('||parent_var_name_||','||''''||repl_str_rec_.element_name_||''''||','||var_name_||');'||lf_;
--      ELSE
--         body_ := body_||tab_||'   row_count_ := '||cur_name_||'%ROWCOUNT; ';
      END IF;
      -- Place ROWCOUNT allocation on level 2 if first level is a select from DUAL
      IF ( level_rec_.level_ != level_rec_.first_level_ AND instr(previous_view_,'DUAL') != 0  ) THEN
         body_ := body_||tab_||'   row_count_ := '||cur_name_||'%ROWCOUNT; ';
      ELSIF ( level_rec_.level_ = level_rec_.first_level_ AND instr(repl_str_rec_.view_name_,'DUAL') = 0 ) THEN
         body_ := body_||tab_||'   row_count_ := '||cur_name_||'%ROWCOUNT; ';
      END IF;
   END IF;
   body_ := body_||lf_||update_keys_;
   --
   Save_Source_Text___(srec_, source_count_, 'BODY_'||repl_mode_,body_);
   RETURN body_;
END Complete_Level_Body__;

FUNCTION Build_End_Body__ (
   srec_         IN OUT source_record,
   source_count_ IN OUT NUMBER,
   header_rec_   IN header_rec,
   repl_mode_    IN VARCHAR2,
   master_rec_   IN VARCHAR2 ) RETURN VARCHAR2
IS
   end_body_     VARCHAR2(32000);
   message_type_ VARCHAR2(30) := 'INTF_BIZAPI';
   name_         VARCHAR2(200);
BEGIN
   --
   IF ( nvl(header_rec_.body_type_,'TRACE') = 'BIZAPI' ) THEN
      IF ( SUBSTR(header_rec_.message_name_,1,13) = '$REPLICATION:' ) THEN
         name_ := SUBSTR(header_rec_.message_name_,14,LENGTH(header_rec_.message_name_)-14);
      ELSIF ( SUBSTR(header_rec_.message_name_,1,1) = '$' AND SUBSTR(header_rec_.message_name_,LENGTH(header_rec_.message_name_),1) = '$' ) THEN
         name_ := SUBSTR(header_rec_.message_name_,2,LENGTH(header_rec_.message_name_)-2); 
      ELSE
         name_ := header_rec_.message_name_;
      END IF;
      end_body_ := lf_||
                   '   IF ( row_count_ != 0 ) THEN '||lf_||
                   '      PLSQLAP_Server_API.Post_Outbound_BizAPI ('||lf_||
                   '         bizapi_name_ => '||''''||name_||''''||','||lf_||
                   '         message_body_ => '||master_rec_||','||lf_;
      IF ( SUBSTR(header_rec_.message_name_,1,1) = '$' AND SUBSTR(header_rec_.message_name_,LENGTH(header_rec_.message_name_),1) = '$' ) THEN
         end_body_ := end_body_||'         message_type_ => '||''''||message_type_||''''||','||lf_;
      END IF;                   
      IF ( header_rec_.message_sender_ IS NOT NULL ) THEN
         end_body_ := end_body_||'         sender_ => '||''''||header_rec_.message_sender_||''''||','||lf_;
      END IF;
      IF ( header_rec_.message_receiver_ IS NOT NULL ) THEN
         end_body_ := end_body_||'         receiver_ => '||''''||header_rec_.message_receiver_||''''||','||lf_;
      END IF;
      end_body_ := rtrim(end_body_,','||lf_)||');'||lf_||
                                   '   END IF; '||lf_;
   END IF;
   end_body_ := end_body_||lf_||'END '||repl_procedure_name_||';'||lf_;
   --
   Save_Source_Text___(srec_, source_count_, 'ENDBODY_'||repl_mode_,end_body_);
   RETURN end_body_;
END Build_End_Body__;


FUNCTION Build_End_Package__ (
   srec_         IN OUT source_record,
   source_count_ IN OUT NUMBER,
   package_name_ IN VARCHAR2,
   repl_mode_    IN VARCHAR2) RETURN VARCHAR2
IS
   end_package_ VARCHAR2(32000);
BEGIN
   --
   end_package_ := 'END '||package_name_||';';
   --
   Save_Source_Text___(srec_, source_count_, 'ENDPKG_'||repl_mode_,end_package_||lf_||'/'||lf_);
   RETURN end_package_;
END Build_End_Package__;


-------------------- LU SPECIFIC PROTECTED METHODS --------------------------

-------------------- LU SPECIFIC PUBLIC METHODS -----------------------------

FUNCTION Build_Package_Header (
   srec_          IN OUT source_record,
   source_count_  IN OUT NUMBER,
   package_name_  IN VARCHAR2,
   repl_mode_     IN VARCHAR2 ) RETURN VARCHAR2
IS
   package_ VARCHAR2(32000);
BEGIN
   --
   package_ := 'CREATE OR REPLACE PACKAGE '||package_name_||' IS '||lf_||
                ' PROCEDURE '||repl_procedure_name_ ||' ('||lf_||
                '    attr_ IN VARCHAR2 ); '||lf_||
                'END '||package_name_||';';
   --
   Save_Source_Text___(srec_, source_count_, 'HEADER_'||repl_mode_,package_||lf_||'/'||lf_);
   RETURN package_;
END Build_Package_Header;


FUNCTION Build_Package_Body (
   srec_            IN OUT source_record,
   source_count_    IN OUT NUMBER,
   write_count_     IN OUT NUMBER,
   source_too_long_ IN OUT BOOLEAN,
   package_name_    IN VARCHAR2,
   intface_name_    IN VARCHAR2,
   mode_            IN VARCHAR2,
   trec_            IN type_record,
   type_count_      IN NUMBER ) RETURN VARCHAR2
IS
   stmt_          VARCHAR2(32000);
   start_package_ VARCHAR2(32000);
   key_var_       VARCHAR2(32000) := lf_;
   cursor_        VARCHAR2(32000) := lf_;
   start_body_    VARCHAR2(32000) := 'BEGIN'||lf_||lf_;
   rec_var_       VARCHAR2(32000) := lf_;
   body_          VARCHAR2(32000);
   end_loop_      VARCHAR2(2000);
   end_body_      VARCHAR2(32000);
   end_package_   VARCHAR2(32000);
   write_error_   EXCEPTION;
   parent_error_  EXCEPTION;
   no_data_       EXCEPTION;
   no_parent_     EXCEPTION;
   err_msg_       VARCHAR2(2000);
   count_         NUMBER := 0;
   parent_count_  NUMBER := 0;
   --
   header_rec_    header_rec;
   level_rec_     level_rec;
   repl_str_rec_  intface_repl_struct_rec;
   master_rec_    VARCHAR2(100);
   --
   previous_view_    intface_repl_structure_tab.view_name%TYPE := NULL;
   parent_key_count_ NUMBER := 0;
   --
   tab_           VARCHAR2(100);
   CURSOR check_data IS
      SELECT count(1), sum(decode(parent_seq,null,1,0))
      FROM   intface_repl_structure a
      WHERE intface_name = intface_name_
      AND  INSTR(on_insert||on_update,'TRUE') != 0; -- One of them must be checked
   --
   CURSOR get_data IS
      SELECT structure_seq, view_name, parent_seq,
             record_name, element_name, element_type_db,
             level, select_where
      FROM   intface_repl_structure a
      WHERE intface_name = intface_name_
      AND   'TRUE' = DECODE(UPPER(view_name),
                        'DUAL',DECODE(parent_seq,null,'TRUE','FALSE'),
                        'SYS.DUAL',DECODE(parent_seq,null,'TRUE','FALSE'),
                        'TRUE')
      AND ((on_insert = 'TRUE' and mode_ = 'I') OR
           (on_update = 'TRUE' and mode_ = 'U'))
      CONNECT BY PRIOR structure_seq = parent_seq
         AND intface_name = intface_name_
      START WITH parent_seq IS NULL
         AND intface_name = intface_name_;
BEGIN
   header_rec_.repl_id_ := intface_name_;
   level_rec_.first_level_ := NULL;
   master_rec_ := NULL;
   -- Check structure data
   OPEN  check_data;
   FETCH check_data INTO count_, parent_count_;
   CLOSE check_data;
   --
trace_sys.field('count_ ', count_);
trace_sys.field('parent_count ', parent_count_);
   IF ( count_ = 0 ) THEN
      RAISE no_data_;
   ELSIF ( count_ = 1 and nvl(parent_count_,0) != 1 ) THEN
      RAISE no_parent_;
   ELSIF ( nvl(parent_count_,0) != 1 ) THEN
      RAISE parent_error_;
   END IF;
   FOR rec_ IN get_data LOOP
      count_ := count_ + 1;
      level_rec_.level_ := rec_.level;
      IF ( level_rec_.first_level_ IS NULL ) THEN
         start_package_ := Build_Package_Start__ (srec_, source_count_, package_name_, mode_ );
         level_rec_.first_level_ := rec_.level;
         -- Save variables from IntfaceHeader, only once
         header_rec_.body_type_        := Intface_Repl_Mess_Type_API.Encode(Intface_Header_API.Get_Message_Type(intface_name_));
         header_rec_.message_name_     := nvl(Intface_Header_API.Get_Message_Name(intface_name_),
                                       '$REPLICATION:'||intface_name_||'$');
         header_rec_.message_sender_   := Intface_Header_API.Get_Message_Sender(intface_name_);
         header_rec_.message_receiver_ := Intface_Header_API.Get_Message_Receiver(intface_name_);
         header_rec_.date_format_      := Intface_Header_API.Get_Date_Format(intface_name_);
      ELSIF (nvl(level_rec_.old_level_,0) >= level_rec_.level_ ) THEN
          -- End previous loop(s)
          Build_End_Loop__(end_loop_, srec_, source_count_, tab_, level_rec_.old_level_, level_rec_.level_, mode_ );
          body_ := body_ ||end_loop_;
      END IF;

      repl_str_rec_.view_name_     := rec_.view_name;
      repl_str_rec_.parent_seq_    := rec_.parent_seq;
      repl_str_rec_.struct_seq_    := rec_.structure_seq;
      repl_str_rec_.record_name_   := nvl(rec_.record_name, rec_.view_name);
      repl_str_rec_.element_name_  := nvl(rec_.element_name, rec_.view_name);
      repl_str_rec_.element_type_  := rec_.element_type_db;
      repl_str_rec_.select_where_  := rec_.select_where;
      -- Build sections of final statement for each turn in the loop
      Build_One_Level_Data__( start_body_, key_var_, cursor_, rec_var_, body_, parent_key_count_, master_rec_, srec_, source_count_, source_too_long_, tab_, header_rec_, mode_, level_rec_, repl_str_rec_, previous_view_ );
      --
      level_rec_.old_level_ := rec_.level;
      previous_view_ := rec_.view_name;
   END LOOP;
   --
   IF ( level_rec_.first_level_ IS NULL ) THEN
      stmt_ := NULL;
   ELSE
      -- End main loop
      Build_End_Loop__(end_loop_, srec_, source_count_, tab_, level_rec_.old_level_, level_rec_.first_level_, mode_);
      body_ := body_||end_loop_;
      end_body_ := Build_End_Body__(srec_, source_count_, header_rec_, mode_, master_rec_);
      end_package_ := Build_End_Package__(srec_, source_count_, package_name_, mode_);
      -- Build complete statement
      IF ( source_too_long_ ) THEN
         BEGIN
            Write_Source_Text___(write_count_, header_rec_, srec_, source_count_, trec_, type_count_);
         EXCEPTION 
            WHEN OTHERS THEN
            trace_sys.message(SQLERRM);
            RAISE write_error_;
         END;
         stmt_ := NULL;
      ELSE
         stmt_ := start_package_||
                  key_var_||
                  cursor_||
                  start_body_||
                  rec_var_||
                  body_||
                  end_body_||
                  end_package_;
      END IF;
   END IF;
   RETURN stmt_;
EXCEPTION
   WHEN write_error_ THEN
      err_msg_ := replace(SQLERRM,'ORA-','ORA');
      Error_SYS.Record_General(lu_name_,'ERRLONG: Source too long, cannot write to Intface_Job_Detail - :P1 ',err_msg_);
   WHEN no_parent_ THEN
      err_msg_ := replace(SQLERRM,'ORA-','ORA');
      Error_SYS.Record_General(lu_name_,'ERR1PAR: Single rows should not have any value in column Parent Sequence ');
   WHEN no_data_ THEN
      err_msg_ := replace(SQLERRM,'ORA-','ORA');
      Error_SYS.Record_General(lu_name_,'NODATA: At least one row must be marked with On Insert or On Update');
   WHEN parent_error_ THEN
      err_msg_ := replace(SQLERRM,'ORA-','ORA');
      Error_SYS.Record_General(lu_name_,'ERR2PAR: One row should be parent = without value in column Parent Sequence ');
   WHEN OTHERS THEN
      err_msg_ := replace(SQLERRM,'ORA-','ORA');
      Error_SYS.Record_General(lu_name_,'OTHERS: Error compiling package - :P1 ', err_msg_);
END Build_Package_Body;


PROCEDURE Show_Package_Text (
   package_text_    IN OUT VARCHAR2,
   srec_            IN OUT source_record,
   source_count_    IN OUT NUMBER,
   write_count_     IN OUT NUMBER,
   source_too_long_ IN OUT BOOLEAN,
   package_name_    IN VARCHAR2,
   intface_name_    IN VARCHAR2,
   mode_            IN VARCHAR2,
   trec_            IN type_record,
   type_count_      IN NUMBER )
IS
BEGIN
   package_text_ := Build_Package_Body(srec_, source_count_, write_count_, source_too_long_, package_name_, intface_name_, mode_, trec_, type_count_ );
END Show_Package_Text;


PROCEDURE Compile_Packages (
   intface_name_ IN VARCHAR2 )
IS
   drop_stmt_      VARCHAR2(32000);
   head_stmt_      VARCHAR2(32000);
   body_stmt_      VARCHAR2(32000);
   err_msg_        VARCHAR2(2000);
   long_source_    EXCEPTION;
   header_rec_     header_rec;
   repl_mode_      VARCHAR2(1);
   package_name_   VARCHAR2(100);
   srec_           source_record;
   source_count_   NUMBER;
   write_count_    NUMBER;
   trec_           type_record;
   type_count_     NUMBER;
   
   source_too_long_ BOOLEAN;
BEGIN
   
   header_rec_.repl_id_ := intface_name_;
   type_count_ := 0;
   write_count_ := 0;
   source_too_long_ := FALSE;
   --
   Initialize_Type_Array___ (trec_, type_count_, header_rec_);
   repl_mode_ := 'I';
   FOR i IN 1..2 LOOP
      drop_stmt_ := NULL;
      package_name_ := 'RPL_'||intface_name_||'_'||repl_mode_;
      BEGIN
         -- Always drop before new compile
         Assert_Sys.Assert_Is_Package(package_name_);
         drop_stmt_ := ' DROP PACKAGE '||package_name_;
         @ApproveDynamicStatement(2010-08-09,chmulk)
         EXECUTE IMMEDIATE drop_stmt_;
      EXCEPTION
         -- May not exists
         WHEN OTHERS THEN 
            Trace_SYS.Message(SQLERRM);
      END;
      repl_mode_ := 'U';
   END LOOP;
   repl_mode_ := 'I';
   FOR i IN 1..2 LOOP
      head_stmt_ := NULL;
      body_stmt_ := NULL;
      source_count_ := 0;
      package_name_ := 'RPL_'||intface_name_||'_'||repl_mode_;
      --
      head_stmt_ := Build_Package_Header(srec_, source_count_, package_name_, repl_mode_ );
      --
      body_stmt_ := Build_Package_Body(srec_, source_count_, write_count_, source_too_long_, package_name_, intface_name_, repl_mode_, trec_, type_count_);
      IF ( NOT source_too_long_ ) THEN
         IF ( body_stmt_ IS NOT NULL ) THEN
            @ApproveDynamicStatement(2010-08-09,chmulk)
            EXECUTE IMMEDIATE head_stmt_;
            @ApproveDynamicStatement(2010-08-09,chmulk)
            EXECUTE IMMEDIATE body_stmt_;
         END IF;
      END IF;
      repl_mode_ := 'U';
   END LOOP;
   IF ( source_too_long_ ) THEN
@ApproveTransactionStatement(2014-04-02,mabose)
      COMMIT; -- Save rows in Intface_Job_Detail
      RAISE long_source_;
   END IF;
   --
EXCEPTION
   WHEN long_source_ THEN
      Error_SYS.Record_General(lu_name_,'LONGSRC: Source too long. Export file from ExecuteJob window and deploy from Admin');
   WHEN OTHERS THEN
trace_sys.message(SQLERRM);
      err_msg_ := replace(SQLERRM,'ORA-','ORA');
      Error_SYS.Record_General( lu_name_ , 'COMPERR: Error compiling package :P1 ', package_name_||' '||err_msg_ );
END Compile_Packages;


FUNCTION Package_Is_Generated (
   intface_name_ IN VARCHAR2 ) RETURN VARCHAR2
IS
   result_ VARCHAR2(5) := 'FALSE';
   CURSOR get_data IS
      SELECT 'TRUE' result
      FROM user_objects
      WHERE object_type = 'PACKAGE BODY'
      AND object_name like 'RPL_'||intface_name_||'__';
BEGIN
   FOR rec_ IN get_data LOOP
      result_ := rec_.result;
   END LOOP;
   RETURN result_;
END Package_Is_Generated;




