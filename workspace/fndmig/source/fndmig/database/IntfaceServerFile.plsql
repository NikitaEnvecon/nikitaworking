-----------------------------------------------------------------------------
--
--  Logical unit: IntfaceServerFile
--  Component:    FNDMIG
--
--  IFS Developer Studio Template Version 3.0
--
--  Date    Sign    History
--  ------  ------  ---------------------------------------------------------
--  100930  JHMASE Bug #93329 - Removed dependecy to Intface_Detail
--  100916  JHMASE Bug #93068 - Reading Unicode file with EXTTABLE
--  091127  NABALK Bug #84218 - Certified the assert safe for dynamic SQLs
--  090331  JHMASE Bug #81836 - Column separator = <tab> is not working when EXTABLE rule is Active. 
--  081028  JHMASE Bug #78118 - Wrong characters set conversion of logfiles
--  080527  JHMASE Bug #74373 - Fetch out of sequence when to many files
--  071031  TRLYNO Bug #70434 - Changing NUMBER and DATE processing. Always create
--                              EXT-table with same format as IC-table.
--                              Compare decimal-sign on job with NLS-setting in database.
--                              Add NULLIF-statement to DATE-columns to handle spaces in files.
--                              Fixed bug in processing of pad_cgar_left_/pad_char_right_. Use 
--                              CHR value in statement.
--                              Allow option KEEPALL on EXT-tables (append multiple file loads).
--  070803  JHMASE Bug #67012 - Internal corrections and added functinality
--  060411  TRLYNO Bug #56862 - FNDMIG added functionality
--                     Add view comments for LOV from client + Get-functions
--  040316  JHMASE  Create
-----------------------------------------------------------------------------

layer Core;

-------------------- PUBLIC DECLARATIONS ------------------------------------

q_       CONSTANT VARCHAR2(4) := ''''; -- quotation
lf_      CONSTANT VARCHAR2(2) := chr(13)||chr(10); -- linefeed

-------------------- PRIVATE DECLARATIONS -----------------------------------


-------------------- LU SPECIFIC IMPLEMENTATION METHODS ---------------------

PROCEDURE Set_Table_Info___ (
   intface_name_ IN VARCHAR2 ,
   file_name_    IN VARCHAR2 ,
   action_        IN VARCHAR2,
   character_set_ IN VARCHAR2 DEFAULT NULL )
IS
BEGIN
   UPDATE intface_header_tab
   SET intface_file = file_name_
   WHERE intface_name = intface_name_ ;
   --
   IF ( action_ = 'SET' ) THEN
      UPDATE intface_header_tab
      SET char_set = Database_SYS.Get_Default_File_Encoding
      WHERE intface_name = intface_name_ ;   
   END IF;
   
   IF ( action_ = 'RESET' ) THEN
      -- If a logfile has been loaded, execution_seq equals zero
      -- Update to current execution_seq to make sure the log-file
      -- is put into history table when Cleanup is performed from start-window
      -- + update context file-name
      Intface_Detail_API.Set_Current_File_Name_(file_name_);
      --
      UPDATE intface_header_tab
      SET char_set = character_set_
      WHERE intface_name = intface_name_ ;
      UPDATE intface_job_detail_tab
      SET execution_no = App_Context_SYS.Find_Number_Value(Intface_Job_Detail_API.intf_execution_no_cid_)
      WHERE intface_name = intface_name_
      AND execution_no = 0;
   END IF;
END Set_Table_Info___;


FUNCTION Get_Files___ ( directory_ IN VARCHAR2 ) RETURN Intface_strArray
AS LANGUAGE JAVA NAME 'intfaceFile.getFileList(java.lang.String) return oracle.sql.ARRAY';

FUNCTION Get_Files_Short___ (
   directory_ IN  VARCHAR2 ) RETURN Intface_strArray
AS LANGUAGE JAVA NAME 'intfaceFile.getFileListShort(java.lang.String) return oracle.sql.ARRAY';

FUNCTION File_Exists___ ( 
   directory_ IN VARCHAR2,
   file_name_ IN VARCHAR2 ) RETURN VARCHAR2
AS  LANGUAGE JAVA NAME 'intfaceFile.exists(java.lang.String, java.lang.String) return java.lang.String';

FUNCTION Delete_File___ ( 
   directory_ IN VARCHAR2,
   file_name_ IN VARCHAR2 ) RETURN VARCHAR2
AS  LANGUAGE JAVA NAME 'intfaceFile.delete(java.lang.String, java.lang.String) return java.lang.String';

FUNCTION Rename_File___ ( 
   directory_ IN VARCHAR2,
   file_name_ IN VARCHAR2,
   new_name_  IN VARCHAR2 ) RETURN VARCHAR2
AS  LANGUAGE JAVA NAME 'intfaceFile.rename(java.lang.String, java.lang.String, java.lang.String) return java.lang.String';

FUNCTION Move_File___ ( 
   from_directory_ IN VARCHAR2,
   to_directory_   IN VARCHAR2,
   from_file_      IN VARCHAR2,
   to_file_        IN VARCHAR2 ) RETURN VARCHAR2
AS  LANGUAGE JAVA NAME 'intfaceFile.move(java.lang.String, java.lang.String, java.lang.String, java.lang.String) return java.lang.String';

FUNCTION Copy_File___ ( 
   from_directory_ IN VARCHAR2,
   to_directory_   IN VARCHAR2,
   from_file_      IN VARCHAR2,
   to_file_        IN VARCHAR2 ) RETURN VARCHAR2
AS  LANGUAGE JAVA NAME 'intfaceFile.copy(java.lang.String, java.lang.String, java.lang.String, java.lang.String) return java.lang.String';

FUNCTION Get_Path___ (
   directory_ IN VARCHAR2) RETURN VARCHAR2
IS
   path_ VARCHAR2(4000);
BEGIN
   SELECT path 
   INTO   path_
   FROM   INTFACE_SERVER_DIR_LOV
   WHERE  name = directory_;
   RETURN path_;
EXCEPTION
   WHEN OTHERS THEN
      RETURN directory_;
END Get_Path___;


FUNCTION Get_Next_Token___ (
   line_ IN     VARCHAR2,
   s_    IN OUT NUMBER) RETURN VARCHAR2
IS
   r_ VARCHAR2(2000);
   e_ NUMBER;
BEGIN
   e_ := INSTR(line_ || ';', ';', s_);
   r_ := SUBSTR(line_, s_, e_-s_);
   s_ := e_ + 1;
   RETURN r_;
END Get_Next_Token___;


FUNCTION Get_Utl_File_Dirs___ RETURN VARCHAR2
IS
   value_     SYS.v_$parameter.value%TYPE;   
BEGIN
   SELECT t.value INTO value_ FROM sys.v_$parameter t WHERE UPPER(name) = 'UTL_FILE_DIR';
   IF (value_ IS NOT NULL) THEN
      RETURN value_ || ',';
   ELSE
      RETURN NULL;
   END IF;
EXCEPTION
   WHEN OTHERS THEN
      RETURN NULL;
END Get_Utl_File_Dirs___;


-------------------- LU SPECIFIC PRIVATE METHODS ----------------------------

-------------------- LU SPECIFIC PROTECTED METHODS --------------------------

-------------------- LU SPECIFIC PUBLIC METHODS -----------------------------
@UncheckedAccess
FUNCTION Directory_List RETURN Intface_Directory_Types
IS
   lov_   Intface_Directory_Types := Intface_Directory_Types();
   dir_   Intface_Directory_Type;
   index_ BINARY_INTEGER := 0;
   priv_  VARCHAR2(10);
   read_  BOOLEAN;
   write_ BOOLEAN;
   utl_file_dir_ SYS.v_$parameter.value%TYPE;
   appowner_     VARCHAR2(30) := Fnd_Session_API.Get_App_Owner;

   CURSOR c1_ IS
      SELECT directory_name name,
             directory_path path
      FROM   all_directories;
   CURSOR c2_ (dir_ VARCHAR2, owner_ VARCHAR2) IS
      SELECT privilege
      FROM   dba_tab_privs
      WHERE  owner      = 'SYS'
      AND    table_name = dir_
      AND    (grantee   = 'PUBLIC'
        OR    grantee   = owner_);

   PROCEDURE UnpackUtlFileDirList(s_ VARCHAR2) IS
      path_      VARCHAR2(512);
      start_pos_ NUMBER := 1;
      end_pos_   NUMBER := 0;
   BEGIN
      end_pos_ := INSTR(s_, ',', start_pos_);
      WHILE ( end_pos_ > 0 ) LOOP
         path_ := SUBSTR(s_, start_pos_, (end_pos_ - start_pos_));
         dir_ := Intface_Directory_Type(RTRIM(LTRIM(path_)),RTRIM(LTRIM(path_)),'read,write');
         index_ := index_ + 1;
         lov_.extend;
         lov_(index_) := dir_;
         start_pos_ := end_pos_ + 1;
         end_pos_ := INSTR(s_, ',', start_pos_);
      END LOOP;
   END UnpackUtlFileDirList;            
BEGIN
   utl_file_dir_ := Get_Utl_File_Dirs___;
   IF ( utl_file_dir_ IS NOT NULL ) THEN
      UnpackUtlFileDirList(utl_file_dir_);
   END IF;
   FOR c1_rec_ IN c1_ LOOP
      read_  := FALSE;
      write_ := FALSE;
      FOR c2_rec_ IN c2_(RTRIM(LTRIM(c1_rec_.name)),appowner_) LOOP
         IF c2_rec_.privilege = 'READ'  THEN read_  := TRUE;END IF;
         IF c2_rec_.privilege = 'WRITE' THEN write_ := TRUE;END IF;
      END LOOP;
      IF ( read_ ) OR ( write_ ) THEN
         IF ( read_ )  THEN priv_ := 'read'; END IF;
         IF ( write_ ) THEN priv_ := priv_ || ',write'; END IF;
         dir_ := Intface_Directory_Type(RTRIM(LTRIM(c1_rec_.name)),RTRIM(LTRIM(c1_rec_.path)),priv_);
         index_ := index_ + 1;
         lov_.extend;
         lov_(index_) := dir_;
      END IF;
   END LOOP;
   RETURN lov_;
END Directory_List;


FUNCTION Set_Directory (
   directory_ IN VARCHAR2 ) RETURN VARCHAR2
IS
BEGIN
   App_Context_SYS.Set_Value('INTFACE_SERVER_FILE_API.CURRENT_DIRECTORY_',directory_);
   RETURN 'TRUE';
END Set_Directory ;

@UncheckedAccess
FUNCTION File_List ( 
   directory_ IN VARCHAR2 DEFAULT NULL) RETURN Intface_File_Types
IS
   files_  Intface_File_Types := Intface_File_Types();
   file_   Intface_File_Type;
   index_  BINARY_INTEGER := 0;
   s_      NUMBER;

   PROCEDURE UnpackFileList(file_list_ Intface_strArray) IS
      file_string_  VARCHAR2(2000);
   BEGIN
      FOR i IN 1..file_list_.count LOOP
         file_string_ := file_list_(i);
         s_ := 1;
         file_  := Intface_File_Type(Get_Next_Token___(file_string_, s_),
                                     Get_Next_Token___(file_string_, s_),
                                     Get_Next_Token___(file_string_, s_),
                                     NVL(directory_,App_Context_SYS.Find_Value('INTFACE_SERVER_FILE_API.CURRENT_DIRECTORY_')));
         files_.extend;
         index_ := index_ + 1;
         files_(index_) := file_;
      END LOOP;
   END UnpackFileList;
BEGIN
   IF ( NVL(directory_,App_Context_SYS.Find_Value('INTFACE_SERVER_FILE_API.CURRENT_DIRECTORY_')) IS NOT NULL ) THEN
      UnpackFileList(Get_Files_Short___(Get_Path___(NVL(directory_,App_Context_SYS.Find_Value('INTFACE_SERVER_FILE_API.CURRENT_DIRECTORY_')))));
   END IF;
   RETURN files_;
END File_List;


FUNCTION File_Exists ( 
   directory_ IN VARCHAR2,
   file_name_ IN VARCHAR2 ) RETURN BOOLEAN
IS
BEGIN
   IF ( File_Exists___(Get_Path___(directory_), file_name_) = 'TRUE' ) THEN
      RETURN TRUE;
   ELSE
      RETURN FALSE;
   END IF;
END File_Exists;


FUNCTION Delete_File ( 
   directory_ IN VARCHAR2,
   file_name_ IN VARCHAR2 ) RETURN BOOLEAN
IS
BEGIN
   IF ( Delete_File___(Get_Path___(directory_), file_name_) = 'TRUE' ) THEN
      RETURN TRUE;
   ELSE
      RETURN FALSE;
   END IF;
END Delete_File;


FUNCTION Rename_File ( 
   directory_ IN VARCHAR2,
   file_name_ IN VARCHAR2,
   new_name_  IN VARCHAR2 ) RETURN BOOLEAN
IS
BEGIN
   IF ( Rename_File___(Get_Path___(directory_), file_name_, new_name_) = 'TRUE' ) THEN
      RETURN TRUE;
   ELSE
      RETURN FALSE;
   END IF;
END Rename_File;


FUNCTION Move_File ( 
   from_directory_ IN VARCHAR2,
   from_file_name_ IN VARCHAR2,
   to_directory_   IN VARCHAR2,
   to_file_name_   IN VARCHAR2 DEFAULT NULL) RETURN BOOLEAN
IS
BEGIN
   IF ( Move_File___(Get_Path___(from_directory_), Get_Path___(to_directory_), from_file_name_, NVL(to_file_name_, from_file_name_)) = 'TRUE' ) THEN
      RETURN TRUE;
   ELSE
      RETURN FALSE;
   END IF;
END Move_File;


FUNCTION Copy_File ( 
   from_directory_ IN VARCHAR2,
   from_file_name_ IN VARCHAR2,
   to_directory_   IN VARCHAR2,
   to_file_name_   IN VARCHAR2 DEFAULT NULL) RETURN BOOLEAN
IS
BEGIN
   IF ( Copy_File___(Get_Path___(from_directory_), Get_Path___(to_directory_), from_file_name_, NVL(to_file_name_, from_file_name_)) = 'TRUE' ) THEN
      RETURN TRUE;
   ELSE
      RETURN FALSE;
   END IF;
END Copy_File;


FUNCTION Get_File_Size (
   directory_      IN VARCHAR2, 
   file_name_      IN VARCHAR2 ) RETURN VARCHAR2
IS
   size_          VARCHAR2(50);
   set_directory_ VARCHAR2(5);
   CURSOR get_size(set_dir_ IN VARCHAR2) IS
      SELECT file_size
      FROM INTFACE_SERVER_FILES_LOV
      WHERE set_dir_ = 'TRUE'
      AND file_name = file_name_;
BEGIN
   set_directory_:= INTFACE_SERVER_FILE_API.set_directory(directory_);
   OPEN  get_size(set_directory_);
   FETCH get_size INTO size_;
   CLOSE get_size;
   RETURN size_;
END Get_File_Size;


PROCEDURE Show_Create_Ext_Table_Stmt (
   intface_name_ IN     VARCHAR2,
   statement_    IN OUT VARCHAR2 ) 
IS
   column_name_        intface_detail_tab.column_name%TYPE;
   ambigous_column_    intface_detail_tab.column_name%TYPE;
   error_in_syntax_    EXCEPTION;
   length_             NUMBER;
   data_type_          VARCHAR2(30);
   pos_                NUMBER;
   ext_create_stmt_    VARCHAR2(32000);
   ext_table_list_     VARCHAR2(32000);
   ext_load_list_      VARCHAR2(32000);
   ext_sep_            VARCHAR2(100) := Intface_Format_Char_API.Get_Char(Intface_Header_API.Get_Column_Separator(intface_name_));
   ext_emb_            VARCHAR2(100) := Intface_Format_Char_API.Get_Char(Intface_Header_API.Get_Column_Embrace(intface_name_));
   decimal_point_      VARCHAR2(1) := Intface_Format_Char_API.Get_Char(Intface_Header_API.Get_Decimal_Point(intface_name_));
   table_tab_          VARCHAR2(10);
   load_tab_           VARCHAR2(10);
   load_pos_           VARCHAR2(100);
   skip_lines_         VARCHAR2(100);
   skip_text_          VARCHAR2(100);
   char_set_           VARCHAR2(200) := Intface_Header_API.Get_Char_Set(intface_name_);
   date_format_        VARCHAR2(100) := Intface_Header_API.Get_Date_Format(intface_name_);
   nls_decimal_        VARCHAR2(1);
   load_format_        VARCHAR2(200);
   date_length_        VARCHAR2(100) := ' ';
   badfile_           VARCHAR2(100);
   logfile_           VARCHAR2(100);
   disfile_           VARCHAR2(100);
   ext_dir_           VARCHAR2(100);
   ext_file_          VARCHAR2(100);
   ext_table_name_    VARCHAR2(35);
   CURSOR get_data IS
      SELECT pos, column_name, data_type, length
      FROM   intface_detail_tab
      WHERE  intface_name = intface_name_
      AND pos > 0
      ORDER BY pos;
   CURSOR get_nls_decimal IS
      SELECT substr(VALUE,1,1)
      FROM nls_database_parameters
      WHERE parameter = 'NLS_NUMERIC_CHARACTERS';
BEGIN
   IF ( Intface_Header_API.Get_Column_Separator(intface_name_) = '9' ) THEN
      ext_sep_ := '\t';
   END IF;
   badfile_        := intface_name_||'.bad';
   logfile_        := intface_name_||'.log';
   disfile_        := intface_name_||'.dis';
   ext_dir_        := Intface_Header_API.Get_Intface_Path(intface_name_);
   ext_file_       := Intface_Header_API.Get_Intface_File(intface_name_);
   ext_table_name_ := 'IC_'||intface_name_||'_EXT';
   -- Check NLS-setting in database
   OPEN  get_nls_decimal;
   FETCH get_nls_decimal INTO nls_decimal_;
   CLOSE get_nls_decimal;
   --
   IF ( Intface_Rules_API.Rule_Is_Active(
         skip_lines_ , 'SKIPLINES', intface_name_) ) THEN
      skip_text_ := ' SKIP '||skip_lines_||' ';
   END IF;
   FOR rec_ IN get_data LOOP
      --
      data_type_   := rec_.data_type;
      column_name_ := rec_.column_name;
      length_      := rec_.length;
      pos_         := rec_.pos;
      load_pos_    := NULL;
      IF ( ( char_set_ IS NOT NULL ) AND 
           ( char_set_ IN ('UTFE','UTF8','AL16UTF16','AL32UTF8','AL24UTFFSS') ) ) THEN
         load_format_ := 'CHAR('||length_*2||')';
      ELSE
         load_format_ := 'CHAR('||length_||')';
      END IF;
      -- Dash or space in column name creates trouble
      -- for CREATE TABLE statement
      IF ( ( instr( column_name_,' ') != 0 ) OR
           ( instr( column_name_,'-') != 0 ) ) THEN
         ambigous_column_ := column_name_;
         RAISE error_in_syntax_;
      END IF;
      -- Build list of columns for the create statement 
      -- If there is match between nls and job-setup we may declare NUMBERs,
      -- else all should be VARCHAR2
      IF ( (nvl(decimal_point_,'XX') = nls_decimal_) AND rec_.data_type = 'NUMBER'  ) THEN
         ext_table_list_ := ext_table_list_||table_tab_||column_name_||' '||'NUMBER'||','||lf_;
      ELSIF ( rec_.data_type = 'DATE' ) THEN
         Error_SYS.Check_Not_Null(intface_name_, 'DATE_FORMAT', ltrim(rtrim(date_format_,q_),q_));
         date_length_ := lpad(date_length_,length_,' ');
         ext_table_list_ := ext_table_list_||table_tab_||column_name_||' '||'DATE'||','||lf_;
         load_format_ := 'DATE '||'"'||date_format_||'" NULLIF '||column_name_||'='||q_||date_length_||q_;
      ELSE
         ext_table_list_ := ext_table_list_||table_tab_||column_name_||' '||'VARCHAR2('||length_||')'||','||lf_;
      END IF;
      -- ...then build column list similar to the Loader controlfile. 
      IF ( ext_sep_ IS NOT NULL ) THEN
         -- Delimited file
         ext_load_list_ := ext_load_list_||load_tab_||column_name_||' '||load_format_||','||lf_;
      ELSE
         -- Fixed column lengths 
         load_pos_ := ' POSITION('||to_char(pos_)||':'||to_char(pos_+length_-1)||') ';         
         ext_load_list_ := ext_load_list_||load_tab_||column_name_||load_pos_||','||lf_;
      END IF;
      table_tab_ := '     ';    -- this avoids tab on first item
      load_tab_ := '         '; -- this avoids tab on first item
   END LOOP;
   ext_table_list_  := rtrim(ext_table_list_ ,','||lf_);
   ext_load_list_  := rtrim(ext_load_list_ ,','||lf_);
   ext_create_stmt_ := 'CREATE TABLE '||ext_table_name_||lf_||
                       '   ( '||ext_table_list_||')'||lf_||
                       'ORGANIZATION EXTERNAL '||lf_||
                       '   ( TYPE oracle_loader '||lf_||
                       '     DEFAULT DIRECTORY '||ext_dir_||lf_||
                       '     ACCESS PARAMETERS '||lf_||
                       '     ( RECORDS DELIMITED BY newline'||skip_text_||lf_||
                       '       BADFILE '||q_||badfile_||q_||lf_||
                       '       DISCARDFILE '||q_||disfile_||q_||lf_||
                       '       LOGFILE '||ext_dir_||':'||q_||logfile_||q_||lf_;
   IF char_set_ IS NOT NULL THEN
      ext_create_stmt_ := ext_create_stmt_||
                       '       CHARACTERSET '||char_set_||lf_;
   END IF;
   IF ( ext_sep_ IS NOT NULL ) THEN
      ext_create_stmt_ := ext_create_stmt_||
                       '       FIELDS TERMINATED BY "'||ext_sep_||'"'||lf_;
      IF ( ext_emb_ IS NOT NULL ) THEN
         ext_create_stmt_ := ext_create_stmt_||
                       '       OPTIONALLY ENCLOSED BY '||q_||ext_emb_||q_||lf_;
      END IF;
      ext_create_stmt_ := ext_create_stmt_||
                       '       MISSING FIELD VALUES ARE NULL '||lf_||'       ';
   ELSE
      ext_create_stmt_ := ext_create_stmt_||'FIELDS ';
   END IF;
      ext_create_stmt_ := ext_create_stmt_||
                       '( '||ext_load_list_||'))'||lf_||
                       '   LOCATION ('||q_||ext_file_||q_||'))'||lf_||
                       'REJECT LIMIT '||App_Context_SYS.Find_Value('INTFACE_SERVER_FILE_API.REJECT_LIMIT_');
     statement_ := ext_create_stmt_;
--   RETURN substr(ext_create_stmt_,1,4050);
EXCEPTION
   WHEN error_in_syntax_ THEN
      Error_SYS.Record_General(lu_name_, 'SYNTAXERROR: Column name :P1 is ambigously defined ', ambigous_column_ );
END Show_Create_Ext_Table_Stmt;


PROCEDURE Show_Ins_From_Ext_To_Ic_Stmt (
   intface_name_ IN     VARCHAR2,
   statement_    IN OUT VARCHAR2 ) 
IS
   data_type_     VARCHAR2(20);
   column_name_   VARCHAR2(2000);
   default_value_ VARCHAR2(2000);
   tran_value_    VARCHAR2(2000);
   decimal_point_ VARCHAR2(1) := Intface_Format_Char_API.Get_Char(Intface_Header_API.Get_Decimal_Point(intface_name_));
   thousand_sep_  VARCHAR2(1) := Intface_Format_Char_API.Get_Char(Intface_Header_API.Get_Thousand_Separator(intface_name_));
   date_format_   VARCHAR2(30):= q_||Intface_Header_API.Get_Date_Format(intface_name_)||q_;
   insert_list_   VARCHAR2(32000);
   select_list_   VARCHAR2(32000);
   item_value_    VARCHAR2(32000);
   emb_           VARCHAR2(4);
   conv_list_     intface_detail_tab.conv_list_id%TYPE;
   pad_left_      VARCHAR2(10);
   pad_right_     VARCHAR2(10);
   denominator_        NUMBER;
   ic_tab_        VARCHAR2(50) := 'IC_'||intface_name_||'_TAB';
   insert_stmt_   VARCHAR2(32000);
   tab_           VARCHAR2(3);
   rule_value_    VARCHAR2(2000);
   nls_decimal_   VARCHAR2(1);
   ext_table_name_    VARCHAR2(35);
   CURSOR get_data IS
      SELECT pos, column_name, data_type, default_value, 
             nvl(decimal_length,0) decimal_length, nvl(amount_factor,1) amount_factor, 
             pad_char_right,
             pad_char_left,
             conv_list_id,
             decode(data_type,'VARCHAR2',q_,NULL) def_embrace
      FROM intface_detail_tab
      WHERE intface_name = intface_name_
      AND ( pos > 0 OR nvl(default_value,'NULLVALUE') != 'NULLVALUE')
      ORDER BY decode(pos,0,99999,pos), column_name;
   CURSOR get_nls_decimal IS
      SELECT substr(VALUE,1,1)
      FROM nls_database_parameters
      WHERE parameter = 'NLS_NUMERIC_CHARACTERS';
BEGIN
   ext_table_name_ := 'IC_'||intface_name_||'_EXT';
   -- Check NLS-setting in database
   -- Prepare translation of decimal sign
   OPEN  get_nls_decimal;
   FETCH get_nls_decimal INTO nls_decimal_;
   CLOSE get_nls_decimal;
   IF ( nvl(decimal_point_,nls_decimal_) != nls_decimal_ ) THEN
      tran_value_ := q_||'1'||decimal_point_||q_||','||q_||'1'||nls_decimal_||q_;
   END IF;
   FOR rec_ IN get_data LOOP
      data_type_ := rec_.data_type;
      column_name_ := rec_.column_name;
      default_value_ := rec_.default_value;
      emb_ := rec_.def_embrace;
      conv_list_ := rec_.conv_list_id;
      pad_left_ := rec_.pad_char_left;
      pad_right_ := rec_.pad_char_right;
      denominator_ := rec_.amount_factor;
      IF ( rec_.pos > 0 ) THEN 
         item_value_ := rec_.column_name;
         -- Apply formatting options from then FileMapping folder
         IF ( pad_left_ IS NOT NULL ) THEN
            item_value_ := 'ltrim('||item_value_||','||'chr('||pad_left_||')'||')';
         END IF;
         IF ( pad_right_ IS NOT NULL ) THEN
            item_value_ := 'rtrim('||item_value_||','||'chr('||pad_right_||')'||')';
         END IF;
         IF ( conv_list_ IS NOT NULL ) THEN
            item_value_ := 'nvl(Intface_Conv_List_Cols_API.Get_New_Value('||
                           q_||conv_list_||q_||','||item_value_||'),'||item_value_||')';
         END IF;
         IF ( data_type_ = 'NUMBER' ) THEN
            -- Remove thousand-separator
            IF ( thousand_sep_ IS NOT NULL ) THEN
               item_value_ := 'REPLACE('||item_value_||','||q_||thousand_sep_||q_||','||q_||q_||')';
            END IF;
            -- Check for default-values
            IF ( default_value_ IS NOT NULL ) THEN
               item_value_ := 'nvl('||item_value_||','||default_value_||')';
            END IF;
            IF ( tran_value_ IS NOT NULL ) THEN
               -- TRANSLATE desimal-sign comma to decimal-sign point
               item_value_ := 'translate('||item_value_||','||tran_value_||')';
            END IF;
            -- If not specified, denominator is default 1 
            item_value_ := 'to_number('||item_value_||')'||'/'||denominator_;
         ELSIF ( data_type_ = 'DATE' ) THEN
            IF ( default_value_ IS NULL ) THEN
               NULL;
            ELSIF ( instr(upper(default_value_),'SYSDATE') != 0 ) THEN
               -- SYSDATE as default
               item_value_ := 'nvl('||item_value_||',SYSDATE)'; 
            ELSIF ( instr(upper(default_value_),'SYSDATE') = 0 ) THEN
               -- specific date as default, keep it inside TO_DATE
               item_value_ := 'nvl('||item_value_||',to_date('||q_||default_value_||q_||','||date_format_||'))';
            END IF;
         ELSE
            IF ( default_value_ IS NOT NULL ) THEN
               item_value_ := 'nvl('||item_value_||','||emb_||default_value_||emb_||')';
            END IF;
            IF ( NOT Intface_Rules_API.Rule_Is_Active(
               rule_value_, 'KEEPBLANKS', intface_name_) ) THEN
               item_value_ := 'ltrim(rtrim('||item_value_||'))';     
            END IF;   
            
         END IF;
      ELSE
         -- Item with pos=0
         IF (data_type_ = 'DATE' AND instr(upper(default_value_),'SYSDATE') = 0 ) THEN
            item_value_ := 'to_date('||q_||default_value_||q_||','||date_format_||')';
         ELSE
            item_value_ := emb_||default_value_||emb_;
         END IF;
      END IF;         
      --      
      insert_list_ := insert_list_||tab_||rec_.column_name||','||lf_;
      tab_ := '   ';
      select_list_ := select_list_||tab_||item_value_||','||lf_;
   END LOOP;
   insert_list_ := '   ('||insert_list_||tab_||'IC_ROW_NO) ';
   -- If rule CRETABCONF is active with value KEEPALL, you may append
   -- several files into a IC-table. Add existing number of rows to ROWNUM
   select_list_ := select_list_||tab_||'ROWNUM + :TABCOUNT'||lf_;
   insert_stmt_ := 'INSERT INTO '||ic_tab_||lf_||
                   insert_list_||lf_||
                   'SELECT '||lf_||select_list_||'FROM '||ext_table_name_;
   statement_ := insert_stmt_;
END Show_Ins_From_Ext_To_Ic_Stmt;


PROCEDURE Create_Ext_Table (
   intface_name_ IN VARCHAR2 )
IS
   file_loc_           VARCHAR2(100) := Intface_Header_API.Get_File_Location(intface_name_);
   server_loc_         VARCHAR2(100) := Intface_File_location_API.Decode('1');
   stmt_               VARCHAR2(32000);
   chk_stmt_           VARCHAR2(32000);
   err_msg_            VARCHAR2(2000);
   loc_error_          EXCEPTION;
   tab_error_          EXCEPTION;
   badfile_           VARCHAR2(100);
   logfile_           VARCHAR2(100);
   disfile_           VARCHAR2(100);
   ext_dir_           VARCHAR2(100);
   ext_table_name_    VARCHAR2(35);
BEGIN
   ext_dir_ := Intface_Header_API.Get_Intface_Path(intface_name_);
   badfile_ := intface_name_||'.bad';
   logfile_ := intface_name_||'.log';
   disfile_ := intface_name_||'.dis';
   ext_table_name_ := 'IC_'||intface_name_||'_EXT';
   -- Delete previuos log-files .
   Trace_SYS.Message('Deleting old files');
   Delete_Server_File(ext_dir_, badfile_);
   Delete_Server_File(ext_dir_, disfile_);
   Delete_Server_File(ext_dir_, logfile_);
   -- Drop previous external table
   BEGIN
      IF NOT Database_SYS.Table_Exist(ext_table_name_) THEN
         Error_SYS.Record_General(lu_name_, '');
      END IF;
      stmt_ := 'DROP TABLE '||ext_table_name_;
      @ApproveDynamicStatement(2009-11-27,nabalk)
      EXECUTE IMMEDIATE stmt_;
   EXCEPTION WHEN OTHERS THEN NULL;
   END;
   -- Build statement
   Show_Create_Ext_Table_Stmt(intface_name_,stmt_);
   -- Display it with Trace_SYS
   --Intface_Detail_API.Trace_Long_Msg(stmt_);
   BEGIN
      -- Create table
      @ApproveDynamicStatement(2011-05-19,jhmase)
      EXECUTE IMMEDIATE stmt_;
      -- Check that table has been correctly created.
      chk_stmt_ := 'SELECT '||q_||'x'||q_||' FROM '||ext_table_name_||' WHERE ROWNUM < 2';
      @ApproveDynamicStatement(2009-11-27,nabalk)
      EXECUTE IMMEDIATE chk_stmt_;
      trace_sys.message('Create table OK');
   EXCEPTION WHEN OTHERS THEN
      err_msg_ := SQLERRM;
      RAISE tab_error_;
   END;   
EXCEPTION
   WHEN loc_error_ THEN
      Error_SYS.Record_General(lu_name_, ' NOSERV: File location must be :P1, not :P2. Update job header ', server_loc_, file_loc_);
   WHEN tab_error_ THEN   
      Error_SYS.Record_General( lu_name_, ' NOTAB: Table not created: :P1', lf_||err_msg_);
END Create_Ext_Table;


PROCEDURE Insert_From_Ext_To_Ic_Table (
   intface_name_ IN VARCHAR2,
   select_count_ IN OUT NUMBER,
   commit_count_ IN OUT NUMBER )
IS
   stmt_      VARCHAR2(32000);
   err_msg_   VARCHAR2(200);        
   cnt_stmt_  VARCHAR2(32000);
   ic1_cnt_   NUMBER := 0;
   ic2_cnt_   NUMBER := 0;
   noins_     EXCEPTION;
   notab_     EXCEPTION;
   no_ic_tab_ EXCEPTION;
   tab_name_ VARCHAR2(100);
BEGIN
   -- First create external table
   BEGIN
      Create_Ext_Table(intface_name_);
   EXCEPTION
      WHEN OTHERS THEN
         err_msg_ := SQLERRM;
         RAISE notab_;
   END;
   -- Count records before start
   BEGIN
      tab_name_ := 'IC_'||intface_name_||'_TAB';
      IF NOT Database_SYS.Table_Exist(tab_name_) THEN
         RAISE no_ic_tab_;
      END IF;
      cnt_stmt_ := 'BEGIN SELECT count(1) INTO :COUNT FROM '||tab_name_||';END;';
      @ApproveDynamicStatement(2009-11-27,nabalk)
      EXECUTE IMMEDIATE cnt_stmt_ USING IN OUT ic1_cnt_;
   EXCEPTION
      WHEN no_ic_tab_ THEN
         Error_SYS.Record_General(lu_name_, ' NOICTAB: Table :P1 does not exist', tab_name_);
      WHEN OTHERS THEN
         Error_SYS.Record_General(lu_name_, ' CNTERR: An Error occured while counting records');
   END;
   -- Build statement for insert
   Show_Ins_From_Ext_To_Ic_Stmt(intface_name_,stmt_);
   -- Display it with Trace_SYS
   Intface_Detail_API.Trace_Long_Msg(stmt_);
   -- Insert rows
   BEGIN
      -- If rule CRETABCONF is active with value KEEPALL, you may append
      -- several files into a IC-table. Parse ic1_cnt_ to add correct number in IC_ROW_NO 
      @ApproveDynamicStatement(2011-05-19,jhmase)
      EXECUTE IMMEDIATE stmt_ USING IN ic1_cnt_;
   EXCEPTION WHEN OTHERS THEN
      err_msg_ := SQLERRM;
      RAISE noins_;
   END;
   -- Count new total
   @ApproveDynamicStatement(2009-11-27,nabalk)
   EXECUTE IMMEDIATE cnt_stmt_ USING IN OUT ic2_cnt_;
   --
   select_count_ := nvl(ic2_cnt_,0);
   commit_count_ := nvl(ic2_cnt_,0)-nvl(ic1_cnt_,0);
EXCEPTION
   WHEN notab_ THEN
      @ApproveTransactionStatement(2013-11-20,wawilk)
      ROLLBACK;
      @ApproveTransactionStatement(2013-11-20,wawilk)
      SAVEPOINT new_job_; -- Avoid error-message 'SAVEPONT new_job_ never established'...
      Error_SYS.Record_General( lu_name_, ' NOTABEXT: External table not created. :P1', lf_||err_msg_);
   WHEN noins_ THEN
      @ApproveTransactionStatement(2013-11-20,wawilk)
      ROLLBACK;
      @ApproveTransactionStatement(2013-11-20,wawilk)
      SAVEPOINT new_job_; -- Avoid error-message 'SAVEPONT new_job_ never established'...
      Error_SYS.Record_General( lu_name_, ' NOINS: Insert in IC-table failed. RMB Unpack File in Execute Job window will display format errors. :P1', lf_||err_msg_);
END Insert_From_Ext_To_Ic_Table;


PROCEDURE Check_For_Bad_File (
   intface_name_ IN VARCHAR2 )
IS
   rule_value_ VARCHAR2(100);
   character_set_ VARCHAR2(100) := Intface_Header_API.Get_File_Encoding(intface_name_);
   badfile_           VARCHAR2(100);
   logfile_           VARCHAR2(100);
   ext_dir_           VARCHAR2(100);
   ext_file_          VARCHAR2(100);
BEGIN
   badfile_        := intface_name_||'.bad';
   logfile_        := intface_name_||'.log';
   ext_dir_        := Intface_Header_API.Get_Intface_Path(intface_name_);
   ext_file_       := Intface_Header_API.Get_Intface_File(intface_name_);
   -- Check if there is a bad-file, then records are missing
   IF ( Intface_Server_File_API.File_Exists(ext_dir_, badfile_)) THEN
      -- Set filename on IntfaceHeader equal to logfile
      Set_Table_Info___(intface_name_, logfile_,'SET');
      -- Load logfile into IntfaceJobDetail
      Intface_Job_Detail_API.Load_Server_File(intface_name_);
      -- Reset filename on IntfaceHeader and update IntfaceJobDetail
      Set_Table_Info___(intface_name_, ext_file_,'RESET',character_set_);
      @ApproveTransactionStatement(2013-11-20,wawilk)
      COMMIT; -- Save updated data before RAISE
      @ApproveTransactionStatement(2013-11-20,wawilk)
      SAVEPOINT new_job_; -- Avoid error-message 'SAVEPONT new_job_ never established'...
      Error_SYS.Record_General(lu_name_, ' CREERR: Records were rejected. Check logfile from start-window ');
   ELSIF ( Intface_Rules_API.Rule_Is_Active(
         rule_value_ , 'REMLOG', intface_name_) ) THEN
      -- Remove log-file if job is OK
      Delete_Server_File(ext_dir_, logfile_);
   END IF;   
END Check_For_Bad_File;


PROCEDURE Delete_Server_File (
   directory_ IN VARCHAR2, 
   file_name_ IN VARCHAR2 )
IS
   no_file_ VARCHAR2(2000);
BEGIN
   IF ( Delete_File(directory_, file_name_)) THEN
      NULL;
   ELSE
      no_file_ := Language_SYS.Translate_Constant(lu_name_, ' NOFILE: File :P1 does not exist on :P2',Fnd_Session_API.Get_Language, file_name_, directory_);
      Trace_SYS.Message(no_file_);
   END IF;
END Delete_Server_File;



