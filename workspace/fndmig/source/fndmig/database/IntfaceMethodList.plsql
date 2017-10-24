-----------------------------------------------------------------------------
--
--  Logical unit: IntfaceMethodList
--  Component:    FNDMIG
--
--  IFS Developer Studio Template Version 3.0
--
--  Date    Sign    History
--  ------  ------  ---------------------------------------------------------
--  140714  ASBALK Bug #117115 - Corrected date type bind variables in Build_Get_Objid_Stmt__
--  130327  JHMASE Bug #107838 - FNDMIG ORA-29471: DBMS_SQL access denied
--  130128  DUWILK Bug #107438 - Add view comments for the temporary IC views.
--  130108  JHMASE Bug #102521 - Recompile invalid procedures
--  130102  CHMULK Bug #103540 - Increasing variable sizes that store info
--  121107  DUWILK Bug #103619 - Changed procedure Create_Table_From_File to create IC table views.
--  111206  DUWILK RDTERUNTIME-1775 Replication does not work for COMPANY_ID, CONTRACT_ID
--  111215  JHMASE Fixed for Custom Fields (added Get_Objid_From_Key)
--  111205  JHMASE Fixed for Custom Fields
--  111128  MaBoSe Removed storage parameters, they are not used anymore when creating tables
--  110209  JHMASE Bug #95483 - Dont put TEXT_ID$ column in SourceMapping tab
--  100923  JHMASE Bug #93207 - Not possible to call procedures with parameters named name_ and value_
--  100610  JHMASE Bug #91290 - Removed Assert_SYS.Assert_Is_Package_Method from Execute_Dynamic_Proc. 
--  100526  JHMASE Bug #90941 - Client values are not remapped to dbvalues when MAPDBCOL rule is used
--  091221  JHMASE Bug #87988 - ORA-06512 PL/SQL: numeric or value error: character string buffer too small 
--  091127  NABALK Bug #84218 - Certified the assert safe for dynamic SQLs
--  080324  TRLYNO Bug #73355 - Enhancements in exception handling
--  070918  TRLYNO Bug #70434 - Enhancements on handling global variables + job info
--  070803  JHMASE Bug #67012 - Internal corrections and added functinality
--  061102  JHMASE Bug #61592 - Remove unnecessary references
--  061029  TRLYNO Bug #61381 - New procedure Find_Missing_Iid_Defaults + bugfix
--  060816  USRALK Bug #59501 - Unpack_Check_Insert___: Added the error message NONBASEVIEW.
--  060808  TRLYNO Bug #59318 - FNDMIG bugfixes
--  060329  TRLYNO Bug #56862 - FNDMIG added functionality
--  060209  TRLYNO Bug #55643 - Change view-definitions from user_ to dba_
--  060105  TRLYNO Bug #55479 - Added functionality in Data Migration
--  051130  JHMASE Bug #54818 - Source Column length
--  051102  JHMASE Bug #54323 - Data Migration failure savepoint 'NEW_JOB' never established
--  051024  JHMASE Bug #54139 - Error in LastInfo messages
--  050615  TRLY   Bug #53247 - Handling of NULLVALUES
--  050601  JHMASE Bug #51608 - Dependency to IntfMethodListAttrib.apy removed
--  050306  TRLY   Bug #50034 - Allowed dynamic call to any procedure.
--                              Migrate_Source_Data : Replaced 3 cursors with 1 procedure ++
--                              Also implemented Oracle-interface DBMS_DESCRIBE.DESCRIBE_PROCEDURE
--                              ( this may lead to need for future upgrades ).
--                              Introduced new procedure for starting jobs from server,
--                              with return-parameter for execution status.
--  041222  JHMASE Bug #48786 - Make it work with double byte
--  041015  JHMASE Bug #47466 - Added view comments for Excel views
--  040908  JHMASE Bug #46897 - Performance improvments
--  040705  TRLY   Bug #44483 - New rules for connecting jobs
--  040514  JHMASE Bug #44651 - No data migrated on some LUs in Method List
--  040111  TRLY   Enhancements for v.1.0.0.A
--  030708  TRLY   Prepared for new module FNDMIG
--  130702  PGAN   Bug #110988- Fixed incomplete error message in Make_Attr_And_Referenc
--  141118  ChMuLK Bug #119168 - Modified Unpack_Check_Insert___, Find_Method_Name 
--                 TEBASE-768    to use Database_SYS.Method_Exist method
-----------------------------------------------------------------------------

layer Core;

-------------------- PUBLIC DECLARATIONS ------------------------------------

TYPE number_tabtype IS
   TABLE OF NUMBER
   INDEX BY BINARY_INTEGER;

TYPE attr_tabtype IS
   TABLE OF VARCHAR2(32000)
   INDEX BY BINARY_INTEGER;

TYPE varchar_tabtype IS
   TABLE OF VARCHAR2(2000)
   INDEX BY BINARY_INTEGER;

TYPE integer_tabtype IS
   TABLE OF INTEGER
   INDEX BY BINARY_INTEGER;

TYPE date_tabtype IS
   TABLE OF DATE
   INDEX BY BINARY_INTEGER;

TYPE boolean_tabtype IS
   TABLE OF BOOLEAN
   INDEX BY BINARY_INTEGER;

TYPE dynamic_record IS RECORD(
   method           varchar_tabtype,
   execute_seq      number_tabtype,
   error_count      number_tabtype,
   incomplete_count number_tabtype,
   commit_count     number_tabtype,
   last_row         number_tabtype,
   view_name        varchar_tabtype,
   orig_view_name   varchar_tabtype,
   attr             attr_tabtype,
   arg_attr         attr_tabtype,
   return_attr      attr_tabtype,
   column_name      varchar_tabtype,
   column_value     varchar_tabtype,
   on_new_master    varchar_tabtype,
   on_first_row     varchar_tabtype,
   method_mode      varchar_tabtype,
   reference        varchar_tabtype,
   repl_key         varchar_tabtype,
   upd_cur          integer_tabtype,
   h_cur            integer_tabtype);

TYPE reference_record IS RECORD(
   column_name_       varchar_tabtype,
   data_type_         varchar_tabtype,
   description_       varchar_tabtype,
   prepare_value_     varchar_tabtype,
   length_            number_tabtype,
   decimal_length_    number_tabtype,
   attr_seq_          number_tabtype,
   flags_             varchar_tabtype,
   source_column_     varchar_tabtype,
   reference_         varchar_tabtype,
   db_client_values_  varchar_tabtype,
   db_values_         varchar_tabtype,
   client_values_     varchar_tabtype,
   lov_view_          varchar_tabtype,
   lu_                varchar_tabtype);

msg_sep_          CONSTANT VARCHAR2(2) := chr(13)||chr(10); -- linefeed

replace_fieldsep_ CONSTANT VARCHAR2(2) := '<^';

replace_recsep_   CONSTANT VARCHAR2(2) := '^>';


-------------------- PRIVATE DECLARATIONS -----------------------------------

CURSOR column_data_type_cursor_ (owner_       VARCHAR2,
                                 table_name_  VARCHAR2,
                                 column_name_ VARCHAR2) IS
   SELECT data_type
   FROM   all_tab_columns
   WHERE  owner       = owner_
   AND    table_name  = table_name_
   AND    column_name = column_name_;


-------------------- LU SPECIFIC IMPLEMENTATION METHODS ---------------------

PROCEDURE Check_Drop_Procedures___ (
   p_intface_name_ IN VARCHAR2 )
IS
   rule_value_ intface_rules_tab.rule_value%TYPE;
BEGIN
   IF ( Intface_Rules_API.Rule_Is_Active(
      rule_value_, 'KEEPDYNAMPROC', p_intface_name_) ) THEN
      NULL;
   ELSE
      Intface_Method_List_API.Drop_All_Dynamic_Proc(p_intface_name_);
   END IF;
END Check_Drop_Procedures___;


FUNCTION Exist_In_Attrib___ (
   intface_name_ IN VARCHAR2,
   execute_seq_  IN NUMBER,
   column_name_  IN VARCHAR2 ) RETURN BOOLEAN
IS
   dummy_   VARCHAR2(1);
   ret_val_ BOOLEAN;
   --
   CURSOR get_data IS
      SELECT 'x'
      FROM intface_method_list_attrib_tab
      WHERE intface_name = intface_name_
      AND   execute_seq  = execute_seq_
      AND   column_name  = column_name_;
BEGIN
   OPEN  get_data;
   FETCH get_data INTO dummy_;
      ret_val_ := get_data%FOUND;
   CLOSE get_data;
   --
   RETURN ret_val_;
END Exist_In_Attrib___;


@Override
PROCEDURE Prepare_Insert___ (
   attr_ IN OUT VARCHAR2 )
IS
   intface_name_ INTFACE_METHOD_LIST.intface_name%TYPE;
BEGIN
   intface_name_ := Client_SYS.Get_Item_Value('INTFACE_NAME', attr_);
   super(attr_);
   Client_SYS.Add_To_Attr('ACTION', Intface_Method_Action_API.Decode('2'), attr_);
   Client_SYS.Add_To_Attr('PREFIX_OPTION', Intface_Prefix_Option_API.Decode(
      nvl(Intface_Rules_API.Get_Rule_Value( intface_name_ , 'CREATEDET'),
      nvl(Intface_Default_Rules_API.Get_Rule_Value('CREATEDET'),'1'))), attr_);
   Client_SYS.Add_To_Attr('ON_NEW', 'FALSE', attr_);
   Client_SYS.Add_To_Attr('ON_MODIFY', 'FALSE', attr_);
   Client_SYS.Add_To_Attr('ON_NEW_MASTER', 'FALSE', attr_);
   Client_SYS.Add_To_Attr('ON_FIRST_ROW', 'FALSE', attr_);
END Prepare_Insert___;


@Override
PROCEDURE Insert___ (
   objid_      OUT    VARCHAR2,
   objversion_ OUT    VARCHAR2,
   newrec_     IN OUT INTFACE_METHOD_LIST_TAB%ROWTYPE,
   attr_       IN OUT VARCHAR2 )
IS
BEGIN
   super(objid_, objversion_, newrec_, attr_);
   --
   Rebuild_Source_Column___(newrec_.intface_name);
   Find_Missing_Iid_Defaults(newrec_.intface_name);
   --
EXCEPTION
   WHEN dup_val_on_index THEN
      Error_SYS.Record_Exist(lu_name_);
END Insert___;

@Override
PROCEDURE Check_Insert___ (
   newrec_ IN OUT intface_method_list_tab%ROWTYPE,
   indrec_ IN OUT Indicator_Rec,
   attr_   IN OUT VARCHAR2 )
IS
   name_  VARCHAR2(30);
   value_ VARCHAR2(4000);
   error_message_   VARCHAR2(2000);
   --
   invalid_method  EXCEPTION;
   non_base_view   EXCEPTION;
   --
   pkg_name_       VARCHAR2(128); -- variables are oversized to avoid getting buffer overflow 
   meth_name_      VARCHAR2(128); -- when an incorrect method is used
   --
BEGIN
   -- Complete rec before insert
   IF ( newrec_.method_name IS NULL ) THEN
      newrec_.method_name := Find_Method_Name(newrec_.view_name);
      IF ( newrec_.method_name IS NOT NULL ) THEN
         newrec_.on_modify := 'TRUE';  
         newrec_.on_new := 'TRUE' ; 
      ELSIF ( UPPER(newrec_.view_name) = 'INTFACE_TABLE_MIGRATIONS' ) THEN
         newrec_.method_name := 'Intface_Table_Migrations_API.Process_Table';      
      ELSE
         error_message_ := newrec_.view_name;
         RAISE non_base_view;
      END IF;
   END IF;
   IF ( instr(newrec_.method_name,'.') != 0 ) THEN
      pkg_name_  := UPPER(substr(newrec_.method_name,1,INSTR(newrec_.method_name,'.')-1));
      meth_name_ := UPPER(substr(newrec_.method_name,INSTR(newrec_.method_name,'.')+1));
      IF NOT Database_SYS.Method_Exist(pkg_name_,meth_name_) THEN
         error_message_ := newrec_.method_name;
         RAISE invalid_method;
      END IF;
      newrec_.on_modify := 'FALSE'; 
      newrec_.on_new := 'FALSE' ;   
   END IF;
   --
   IF ( newrec_.prefix_option IS NULL ) THEN
      newrec_.prefix_option := Intface_Prefix_Option_API.Decode(
         nvl(Intface_Rules_API.Get_Rule_Value( newrec_.intface_name, 'CREATEDET'),
         nvl(Intface_Default_Rules_API.Get_Rule_Value('CREATEDET'),'1')));
   END IF;
   --
   Make_Attr_And_Reference(newrec_.convert_attr,
                        newrec_.references,
                        newrec_.view_name,
                        newrec_.intface_name,
                        newrec_.source_name,
                        newrec_.method_name,
                        newrec_.action,
                        newrec_.prefix_option,
                        newrec_.execute_seq);
   --
   super(newrec_, indrec_, attr_);
EXCEPTION
   WHEN value_error THEN
      Error_SYS.Item_Format(lu_name_, name_, value_);
   WHEN invalid_method THEN
      Error_SYS.Record_General(lu_name_, 'ILLMETH: Method :P1 does not exist', error_message_);
   WHEN non_base_view THEN
      Error_SYS.Record_General(lu_name_, 'NONBASEVIEW: Failed to identify standard methods for view ":P1" while trying to generate the Method List. The [View Name] must be a base view of an IFS Logical Unit.', error_message_);
END Check_Insert___;


@Override
PROCEDURE Check_Update___ (
   oldrec_ IN     intface_method_list_tab%ROWTYPE,
   newrec_ IN OUT intface_method_list_tab%ROWTYPE,
   indrec_ IN OUT Indicator_Rec,
   attr_   IN OUT VARCHAR2 )
IS
   name_               VARCHAR2(30);
   value_              VARCHAR2(4000);
   not_outside_loop_   EXCEPTION;
   not_inside_loop_    EXCEPTION;
BEGIN
   super(oldrec_, newrec_, indrec_, attr_);
--   -- Check consistence between method-names and action-values
--   IF ( instr(upper(newrec_.method_name), 'INTFACE_HEADER_API.START_JOB') != 0 ) THEN
--      IF ( Intface_Method_Action_API.Encode(newrec_.action) = '2' ) THEN
--         RAISE not_outside_loop_;
--      END IF;
--   END IF;
   IF ( instr(upper(newrec_.method_name), 'NEW__') != 0 OR
        instr(upper(newrec_.method_name), 'MODIFY__') != 0 OR
        instr(upper(newrec_.method_name), '.') = 0) THEN
      IF ( Intface_Method_Action_API.Encode(newrec_.action) IN ('1','3' ) ) THEN
         RAISE not_inside_loop_;
      END IF;
   END IF;
EXCEPTION
   WHEN value_error THEN
      Error_SYS.Item_Format(lu_name_, name_, value_);
   WHEN not_inside_loop_ THEN
      Error_SYS.Record_General(lu_name_, 'NOTINLOOP: Procedure :P1  must be started inside loop', newrec_.method_name);
   WHEN not_outside_loop_ THEN
      Error_SYS.Record_General(lu_name_, 'NOTOUTLOOP: Procedure :P1  cannot be started inside loop', newrec_.method_name);
END Check_Update___;

@Override
PROCEDURE Delete___ (
   objid_  IN VARCHAR2,
   remrec_ IN INTFACE_METHOD_LIST_TAB%ROWTYPE )
IS
BEGIN
   super(objid_, remrec_);
   IF ( instr(remrec_.method_name,'.') != 0 ) THEN
      Drop_One_Dynamic_Proc(remrec_.intface_name, remrec_.execute_seq);
   END IF;
END Delete___;


PROCEDURE Get_Arguments___ (
   count_       IN OUT NUMBER,
   ref_rec_     IN OUT reference_record,
   attr_seq_    IN OUT NUMBER,
   method_name_ IN     VARCHAR2 )
IS
   h_default_       VARCHAR2(20); 
   dummy_           DBMS_DESCRIBE.NUMBER_TABLE; 
   overload_        DBMS_DESCRIBE.NUMBER_TABLE; 
   position_        DBMS_DESCRIBE.NUMBER_TABLE; 
   argument_name_   DBMS_DESCRIBE.VARCHAR2_TABLE; 
   data_n_type_     DBMS_DESCRIBE.NUMBER_TABLE; 
   def_value_       DBMS_DESCRIBE.NUMBER_TABLE; 
   in_out_          DBMS_DESCRIBE.NUMBER_TABLE;
   --
   data_type_       VARCHAR2(10);
   direction_       VARCHAR2(10);
   length_          NUMBER;
   arg_name_        VARCHAR2(100);
   --
   illegal_method_     EXCEPTION;
   illegal_arg_type_   EXCEPTION;
BEGIN 
   DBMS_DESCRIBE.DESCRIBE_PROCEDURE(UPPER(method_name_),
      null, null, overload_, position_, dummy_, 
      argument_name_, data_n_type_, def_value_, in_out_, dummy_, dummy_, dummy_, dummy_, dummy_); 
   FOR i IN 1..argument_name_.count LOOP 
      h_default_ := NULL;  
      length_ := 22;
      arg_name_ := argument_name_(i);
      IF ( overload_(i) < 2) THEN -- IF overloaded, only display first alternative
         IF (def_value_(i) = 1) THEN 
            h_default_ := 'DEFAULT'; 
         END IF; 
         IF ( data_n_type_(i) = 1 ) THEN 
            data_type_ := 'VARCHAR2';
            length_    := 32000;
         ELSIF ( data_n_type_(i) = 2 ) THEN 
            data_type_ := 'NUMBER';
         ELSIF ( data_n_type_(i) = 12 ) THEN 
            data_type_ := 'DATE';
         ELSIF ( data_n_type_(i) = 0 ) THEN 
            RETURN;
         ELSE 
            RAISE illegal_arg_type_;
         END IF; 
--         IF ( position(i) = 0 ) THEN 
--           RAISE illegal_method_;
--         END IF;
         IF ( in_out_(i) = 0 ) THEN
            direction_ := 'IN';
         ELSIF ( in_out_(i) = 1 ) THEN
            direction_ := 'OUT';
         ELSIF ( in_out_(i) = 2 ) THEN
            direction_ := 'IN OUT';
         END IF;
         IF ( argument_name_(i) IS NULL AND direction_ = 'OUT' ) THEN
            -- This is a function
            arg_name_ := 'FUNCTION_RESULT';
         END IF;
         count_ := count_ + 1;
         attr_seq_ := nvl(attr_seq_,0) + 10;
         ref_rec_.column_name_(count_)      := arg_name_;
         ref_rec_.data_type_(count_)        := data_type_;
         ref_rec_.description_(count_)      := direction_||' '||h_default_;
         ref_rec_.attr_seq_(count_)         := attr_seq_;
         ref_rec_.prepare_value_(count_)    := 'NULLVALUE';
         ref_rec_.flags_(count_)            := 'ARG';
         ref_rec_.reference_(count_)        := NULL;
         ref_rec_.lu_(count_)               := NULL;
         ref_rec_.lov_view_(count_)         := NULL;
         ref_rec_.length_(count_)           := length_;
         ref_rec_.decimal_length_(count_)   := 0;
         ref_rec_.source_column_(count_)    := NULL;
         ref_rec_.db_client_values_(count_) := NULL;
         ref_rec_.db_values_(count_)        := NULL;
         ref_rec_.client_values_(count_)    := NULL;
      END IF; 
   END LOOP; 
EXCEPTION
   WHEN illegal_method_ THEN
      Error_SYS.Record_General(lu_name_, 'ILLMETHFUNC: Method :P1 is a function. Only procedures allowed', method_name_);
   WHEN illegal_arg_type_ THEN
      Error_SYS.Record_General(lu_name_, 'ILLARGTYPE: Argument :P1 has illegal type. Only datatype DATE VARCHAR2 NUMBER allowed', arg_name_ );
END Get_Arguments___;  

PROCEDURE Remap_Client_Default_To_Db___ (
   intface_name_ IN VARCHAR2 )
IS
   client_column_  VARCHAR2(200);
   client_default_ VARCHAR2(200);
   db_default_     VARCHAR2(200);
   pkg_            VARCHAR2(50);
   stmt_           VARCHAR2(2000);
   client_pos_     NUMBER;
   client_rowid_   ROWID;
   db_rowid_       ROWID;
   client_note_    VARCHAR2(100);
   db_note_        VARCHAR2(100);
   --
   CURSOR get_client_columns IS
      SELECT pos, column_name, default_value, 
             decode(source_column,NULL,NULL,source_column||'_DB') source_column,
             substr(db_client_values,1,instr(db_client_values,chr(13))-1) iid_lu,
             note_text, ROWID
      FROM intface_detail_tab
      WHERE intface_name =  intface_name_
      AND db_client_values IS NOT NULL
      AND column_name NOT LIKE '%_DB'
      AND default_value IS NOT NULL;
   --
   CURSOR get_db_columns IS
      SELECT column_name, ROWID
      FROM intface_detail_tab 
      WHERE intface_name = intface_name_
      AND column_name = client_column_||'_DB'
      AND pos = client_pos_ +10;
BEGIN
   -- Fetch Client IIDs with default-values
   FOR crec_ IN get_client_columns LOOP
      client_pos_     := crec_.pos;
      client_rowid_   :=  crec_.ROWID;
      client_default_ := crec_.default_value;
      client_column_  := crec_.column_name;
      FOR dbrec_ IN get_db_columns LOOP
         -- Find equivalent DB-column
         db_rowid_ := dbrec_.ROWID;
         --
         pkg_ := Dictionary_SYS.Clientnametodbname_(crec_.iid_lu)||'_API';
         -- Encode to DB-value
         stmt_ := 'BEGIN :val := '||pkg_||'.Encode(:value);End;';
         @ApproveDynamicStatement(2009-11-27,nabalk)
         EXECUTE IMMEDIATE stmt_
         USING IN OUT db_default_, IN TRIM(CHR(39) FROM client_default_);         
         --
         IF ( db_default_ IS NOT NULL ) THEN
            -- Move column mapping and default-values,
            -- make appropriate notes
            client_note_ := msg_sep_||
               Language_SYS.Translate_Constant(lu_name_,' CLREMAP: moved to DB-column', Fnd_Session_API.Get_Language);
            db_note_ := 
               Language_SYS.Translate_Constant(lu_name_,' DBREMAP: Remapped from client-value ', Fnd_Session_API.Get_Language );
            --
            UPDATE intface_detail_tab
            SET default_value = ''''||db_default_||'''', 
                note_text = db_note_, source_column = crec_.source_column
            WHERE ROWID = db_rowid_;
            --
            UPDATE intface_detail_tab
            SET default_value = NULL, source_column = NULL,
                note_text = note_text||client_note_
            WHERE ROWID = client_rowid_;
            END IF;
      END LOOP;
   END LOOP;
END Remap_Client_Default_To_Db___;

PROCEDURE Rebuild_Source_Column___ (
   intface_name_ IN VARCHAR2 )
IS
   client_column_ VARCHAR2(200);
   db_detail_ ROWID;
   client_detail_ ROWID;
   db_default_ VARCHAR2(2000);
   client_default_ VARCHAR2(2000);
   client_flags_ VARCHAR2(10);
   db_pos_ NUMBER;
   rule_value_     intface_rules_tab.rule_value%TYPE;
   --
   CURSOR get_db_columns IS
      SELECT column_name, flags, default_value, source_column, pos,
             ROWID det_rowid
      FROM intface_detail_tab 
      WHERE intface_name = intface_name_
      AND column_name LIKE '%_DB'
      AND source_column IS NOT NULL;
   CURSOR get_client_columns IS
      SELECT column_name, flags, default_value, source_column,
             ROWID det_rowid
      FROM intface_detail_tab
      WHERE intface_name =  intface_name_
      AND column_name = client_column_
      AND pos = db_pos_ -10
      AND source_column IS NOT NULL;
BEGIN
   FOR dbrec_ IN get_db_columns LOOP
      -- Find DB-columns
      client_column_ := substr(dbrec_.column_name, 1,length(dbrec_.column_name)-3);
      db_detail_  := dbrec_.det_rowid;
      db_default_ := dbrec_.default_value;
      db_pos_     := dbrec_.pos;
      FOR crec_ IN get_client_columns LOOP
         -- Find equivalent Client-column
         client_detail_ := crec_.det_rowid;
         client_default_ := crec_.default_value;
         client_flags_   := crec_.flags;
      END LOOP;
      IF ( db_default_ IS NOT NULL ) THEN
         -- Empty value for client-value column
         UPDATE intface_detail_tab
         SET source_column = NULL
         WHERE ROWID = client_detail_;
      ELSIF ( client_default_ IS NOT NULL ) THEN
         -- Empty value for db-value column
         UPDATE intface_detail_tab
         SET source_column = NULL
         WHERE ROWID = db_detail_;
      ELSE
         -- IF no default-value given, use db-value column
         UPDATE intface_detail_tab
         SET source_column = NULL
         WHERE ROWID = client_detail_;
      END IF;
   END LOOP;
   IF ( Intface_Rules_API.Rule_Is_Active(
      rule_value_, 'MAPDBCOL', intface_name_) ) THEN
         Remap_Client_Default_To_Db___(intface_name_);
   END IF;
END Rebuild_Source_Column___;


-----------------------------------------------------------------------------
-------------------- LU SPECIFIC PRIVATE METHODS ----------------------------
-----------------------------------------------------------------------------

PROCEDURE Build_Info_String__ (
   info_           IN OUT VARCHAR2,
   message_start_  IN     VARCHAR2,
   message_before_ IN     VARCHAR2,
   message_select_ IN     VARCHAR2,
   message_method_ IN     VARCHAR2,
   message_after_  IN     VARCHAR2,
   start_time_     IN     VARCHAR2,
   row_count_      IN     NUMBER,
   incompl_trans_  IN     BOOLEAN,
   commit_count_   IN     NUMBER,
   error_count_    IN     NUMBER,
   p_intface_name_ IN     VARCHAR2   )
IS
   w_info_          VARCHAR2(32000);
   message_count_   VARCHAR2(2000);
   message_commit_  VARCHAR2(2000);
   message_error_   VARCHAR2(2000);
   message_end_     VARCHAR2(2000);
   message_elapse_  VARCHAR2(2000);
   message_avg_     VARCHAR2(2000);
   end_time_        VARCHAR2(50) := to_char(sysdate,'DD-MON-YYYY HH24:MI:SS');
   elapsed_time_    NUMBER;
   elapsed_hours_   NUMBER;
   elapsed_minutes_ NUMBER;
   total_minutes_   NUMBER;
   avg_rows_        NUMBER;
   start_pos_       NUMBER;
   mode_            VARCHAR2(2000);
   max_info_length_ NUMBER := 4000;
   
   FUNCTION add_to_w_info_ (
      w_info_   IN VARCHAR2,
      string01_ IN VARCHAR2,
      string02_ IN VARCHAR2 DEFAULT NULL,
      string03_ IN VARCHAR2 DEFAULT NULL,
      string04_ IN VARCHAR2 DEFAULT NULL,
      string05_ IN VARCHAR2 DEFAULT NULL,
      string06_ IN VARCHAR2 DEFAULT NULL,
      string07_ IN VARCHAR2 DEFAULT NULL,
      string08_ IN VARCHAR2 DEFAULT NULL,
      string09_ IN VARCHAR2 DEFAULT NULL,
      string10_ IN VARCHAR2 DEFAULT NULL,
      string11_ IN VARCHAR2 DEFAULT NULL,
      string12_ IN VARCHAR2 DEFAULT NULL) RETURN VARCHAR2
   IS
   BEGIN
      IF ( string01_ IS NULL ) THEN
         RETURN w_info_;
      END IF;
      RETURN w_info_ || string01_ || string02_ || string03_ || string04_ ||
                        string05_ || string06_ || string07_ || string08_ ||
                        string09_ || string10_ || string11_ || string12_;
   EXCEPTION
      WHEN OTHERS THEN
         RETURN w_info_ || ' (...) ';
   END add_to_w_info_;
BEGIN
   mode_ := info_;
   info_ := NULL;
   --
   elapsed_time_ := to_date(end_time_, 'DD-MON-YYYY HH24:MI:SS') - to_date(start_time_, 'DD-MON-YYYY HH24:MI:SS');
   IF ( elapsed_time_ = 0 ) THEN
      elapsed_time_ := 0.00001157; -- set 1 second as minimum
   END IF;
   IF ( nvl(row_count_,0) != 0 and nvl(elapsed_time_,0) != 0 ) THEN
      elapsed_hours_   := trunc(elapsed_time_ * 24);
      elapsed_minutes_ := round((elapsed_time_ * 24 * 60) - (trunc(elapsed_time_ * 24) * 60),1);
      total_minutes_   := (elapsed_time_ * (24 * 60));
      avg_rows_        := trunc(row_count_ / total_minutes_);
      IF ( mode_ = 'CHECK' ) THEN
         message_count_ := Language_SYS.Translate_Constant(lu_name_, ' CHKCOUNT : :P1 rows checked ', Fnd_Session_API.Get_Language, lpad(to_char(nvl(row_count_, 0)), 8, ' '));
      ELSE
         message_count_ := Language_SYS.Translate_Constant(lu_name_, ' MSGCOUNT : :P1 rows selected ', Fnd_Session_API.Get_Language, lpad(to_char(nvl(row_count_, 0)), 8, ' '));
      END IF;
      IF ( incompl_trans_ ) THEN
         message_commit_ := Language_SYS.Translate_Constant(lu_name_, ' INCOMPLTRANS : Check result. Transactions may be partially committed ', Fnd_Session_API.Get_Language );
         BEGIN
            message_commit_ := message_commit_||msg_sep_||
                            Language_SYS.Translate_Constant(lu_name_, ' INCOMPLROW : Search for INCOMPLETE ROW in Error Message', Fnd_Session_API.Get_Language )||msg_sep_;
         EXCEPTION
            WHEN OTHERS THEN NULL;
         END;         
      ELSIF ( mode_ = 'CREATE_TABLE' ) THEN
         message_commit_ := Language_SYS.Translate_Constant(lu_name_, ' MSGCOMMIT : :P1 rows committed ', Fnd_Session_API.Get_Language, lpad(to_char(nvl(commit_count_, 0)), 8, ' '));
         BEGIN
            message_commit_ := message_commit_||msg_sep_;
         EXCEPTION
            WHEN OTHERS THEN NULL;
         END;         
      END IF;
      message_error_  := Language_SYS.Translate_Constant(lu_name_, ' MSGERR : :P1 rows failed ', Fnd_Session_API.Get_Language, lpad(to_char(nvl(error_count_, 0)), 8, ' '));
      message_elapse_ := Language_SYS.Translate_Constant(lu_name_, ' MSGLAPSE : Used :P1 hours and :P2 minutes ', Fnd_Session_API.Get_Language, to_char(elapsed_hours_), to_char(elapsed_minutes_));
      message_avg_    := Language_SYS.Translate_Constant(lu_name_, ' MSGAVG : Average of  :P1 rows per minute ', Fnd_Session_API.Get_Language, to_char(avg_rows_));
   END IF ;
   --
   w_info_ := add_to_w_info_(w_info_,message_start_,msg_sep_,msg_sep_);
   w_info_ := add_to_w_info_(w_info_,message_before_,msg_sep_,msg_sep_);
   w_info_ := add_to_w_info_(w_info_,message_select_,msg_sep_,msg_sep_);
   w_info_ := add_to_w_info_(w_info_,message_method_,msg_sep_,msg_sep_);
   w_info_ := add_to_w_info_(w_info_,message_after_,msg_sep_,msg_sep_);
   IF ( nvl(row_count_,0) != 0 ) THEN
      w_info_ := add_to_w_info_(w_info_,message_count_,msg_sep_,message_commit_,message_error_,msg_sep_,msg_sep_,
                                message_elapse_,msg_sep_,message_avg_,msg_sep_,msg_sep_);
   END IF;
   IF ( mode_ != 'CREATE_TABLE' ) THEN
      message_end_ := Language_SYS.Translate_Constant(lu_name_, ' TIMESTAMP2 : End time - :P1   :P2 ', Fnd_Session_API.Get_Language, end_time_ ,p_intface_name_ )||msg_sep_||msg_sep_;
   END IF;
   w_info_ := add_to_w_info_(w_info_,message_end_);
   --
   -- Info is saved in a table; must not exceed 4000 chars.
   IF ( length(w_info_) > max_info_length_ ) THEN
      -- Cut info, but always start with message_start_
      start_pos_ := -1 * (max_info_length_ - length(message_start_) - 2 * length(msg_sep_));
      info_ := message_start_||msg_sep_||msg_sep_||substr(w_info_,start_pos_);
   ELSE
      info_ := w_info_;
   END IF;
   Check_Drop_Procedures___(p_intface_name_);
   -- Make sure hash-marked attributes are reset.
   Unmap_Attributes_To_Pos(p_intface_name_);
END Build_Info_String__;

-- Used to save/restore context infromation of a particular job when connected migration jobs are run
PROCEDURE Change_Job_Context__ (
   action_ IN VARCHAR2,
   p_intface_name_ IN VARCHAR2   )
IS
   i_ VARCHAR2(5);
   intf_exec_level_ NUMBER;
   
BEGIN
   
   IF ( action_ = 'SAVE' ) THEN
      intf_exec_level_ :=  App_Context_SYS.Find_Number_Value('INTFACE_METHOD_LIST_API.INTF_EXEC_LEVEL_',0)+1;
      App_Context_SYS.Set_Value('INTFACE_METHOD_LIST_API.INTF_EXEC_LEVEL_',intf_exec_level_);
      i_ := concat(concat('L',to_char(intf_exec_level_)),'_');
      
      trace_sys.message('TRACE >>>>>>>>>>>>>>>>>>>> SAVE GLOBALS for Exec_Level - Job_id : '||intf_exec_level_||' - '||p_intface_name_);
      App_Context_SYS.Set_Value(concat(i_,Intface_Job_Detail_API.intf_date_executed_cid_),App_Context_SYS.Find_Date_Value(Intface_Job_Detail_API.intf_date_executed_cid_));
      App_Context_SYS.Set_Value(concat(i_,Intface_Job_Detail_API.intf_execution_no_cid_),App_Context_SYS.Find_Number_Value(Intface_Job_Detail_API.intf_execution_no_cid_));
      App_Context_SYS.Set_Value(concat(i_,Intface_Job_Detail_API.intf_skip_lines_cid_),App_Context_SYS.Find_Number_Value(Intface_Job_Detail_API.intf_skip_lines_cid_));
      App_Context_SYS.Set_Value(concat(i_,Intface_Job_Detail_API.intf_exit_lines_cid_),App_Context_SYS.Find_Number_Value(Intface_Job_Detail_API.intf_exit_lines_cid_));
      App_Context_SYS.Set_Value(concat(i_,Intface_Job_Detail_API.intf_file_is_on_server_cid_),App_Context_SYS.Find_Boolean_Value(Intface_Job_Detail_API.intf_file_is_on_server_cid_));
      App_Context_SYS.Set_Value(concat(i_,Intface_Job_Detail_API.intf_file_is_on_client_cid_),App_Context_SYS.Find_Boolean_Value(Intface_Job_Detail_API.intf_file_is_on_client_cid_));
      App_Context_SYS.Set_Value(concat(i_,Intface_Job_Detail_API.intf_no_file_context_id_),App_Context_SYS.Find_Boolean_Value(Intface_Job_Detail_API.intf_no_file_context_id_));
      App_Context_SYS.Set_Value(concat(i_,Intface_Job_Detail_API.intf_ignoreaderror_cid_),App_Context_SYS.Find_Boolean_Value(Intface_Job_Detail_API.intf_ignoreaderror_cid_));
      App_Context_SYS.Set_Value(concat(i_,Intface_Job_Detail_API.intf_ignorexeerror_cid_),App_Context_SYS.Find_Boolean_Value(Intface_Job_Detail_API.intf_ignorexeerror_cid_));
      App_Context_SYS.Set_Value(concat(i_,Intface_Job_Detail_API.intf_in_info_cid_),App_Context_SYS.Find_Value(Intface_Job_Detail_API.intf_in_info_cid_));
      App_Context_SYS.Set_Value(concat(i_,Intface_Job_Detail_API.intf_execution_ok_cid_),App_Context_SYS.Find_Boolean_Value(Intface_Job_Detail_API.intf_execution_ok_cid_));
      App_Context_SYS.Set_Value(concat(i_,Intface_Job_Detail_API.intf_commit_seq_cid_),App_Context_SYS.Find_Number_Value(Intface_Job_Detail_API.intf_commit_seq_cid_));
   ELSIF ( action_ = 'RESTORE' ) THEN
      intf_exec_level_ := App_Context_SYS.Get_Number_Value('INTFACE_METHOD_LIST_API.INTF_EXEC_LEVEL_');
      i_ := concat(concat('L',to_char(intf_exec_level_)),'_');
      
      App_Context_SYS.Set_Value(Intface_Job_Detail_API.intf_date_executed_cid_,App_Context_SYS.Get_Date_Value(concat(i_,Intface_Job_Detail_API.intf_date_executed_cid_)));
      App_Context_SYS.Set_Value(Intface_Job_Detail_API.intf_execution_no_cid_,App_Context_SYS.Get_Number_Value(concat(i_,Intface_Job_Detail_API.intf_execution_no_cid_)));
      App_Context_SYS.Set_Value(Intface_Job_Detail_API.intf_skip_lines_cid_,App_Context_SYS.Get_Number_Value(concat(i_,Intface_Job_Detail_API.intf_skip_lines_cid_)));
      App_Context_SYS.Set_Value(Intface_Job_Detail_API.intf_exit_lines_cid_,App_Context_SYS.Get_Number_Value(concat(i_,Intface_Job_Detail_API.intf_exit_lines_cid_)));
      App_Context_SYS.Set_Value(Intface_Job_Detail_API.intf_file_is_on_server_cid_,App_Context_SYS.Get_Boolean_Value(concat(i_,Intface_Job_Detail_API.intf_file_is_on_server_cid_)));
      App_Context_SYS.Set_Value(Intface_Job_Detail_API.intf_file_is_on_client_cid_,App_Context_SYS.Get_Boolean_Value(concat(i_,Intface_Job_Detail_API.intf_file_is_on_client_cid_)));
      App_Context_SYS.Set_Value(Intface_Job_Detail_API.intf_no_file_context_id_,App_Context_SYS.Get_Boolean_Value(concat(i_,Intface_Job_Detail_API.intf_no_file_context_id_)));
      App_Context_SYS.Set_Value(Intface_Job_Detail_API.intf_ignoreaderror_cid_,App_Context_SYS.Get_Boolean_Value(concat(i_,Intface_Job_Detail_API.intf_ignoreaderror_cid_)));
      App_Context_SYS.Set_Value(Intface_Job_Detail_API.intf_ignorexeerror_cid_,App_Context_SYS.Get_Boolean_Value(concat(i_,Intface_Job_Detail_API.intf_ignorexeerror_cid_)));
      App_Context_SYS.Set_Value(Intface_Job_Detail_API.intf_in_info_cid_,App_Context_SYS.Get_Value(concat(i_,Intface_Job_Detail_API.intf_in_info_cid_)));
      App_Context_SYS.Set_Value(Intface_Job_Detail_API.intf_execution_ok_cid_,App_Context_SYS.Get_Boolean_Value(concat(i_,Intface_Job_Detail_API.intf_execution_ok_cid_)));
      App_Context_SYS.Set_Value(Intface_Job_Detail_API.intf_commit_seq_cid_,App_Context_SYS.Get_Number_Value(concat(i_,Intface_Job_Detail_API.intf_commit_seq_cid_)));
      
      Intface_Detail_API.Load_Intface_Info(p_intface_name_);
      trace_sys.message('TRACE >>>>>>>>>>>>>>>>>>>> RESTORE GLOBALS for Exec_Level - Job_id : '||intf_exec_level_||' - '||p_intface_name_);
   ELSIF ( action_ = 'CLOSE' ) THEN
      intf_exec_level_ := App_Context_SYS.Get_Number_Value('INTFACE_METHOD_LIST_API.INTF_EXEC_LEVEL_');
      trace_sys.message('TRACE >>>>>>>>>>>>>>>>>>>> CLOSE GLOBALS for Exec_Level - Job_id : '||intf_exec_level_||' - '||p_intface_name_);
      intf_exec_level_ := intf_exec_level_ - 1;
      App_Context_SYS.Set_Value('INTFACE_METHOD_LIST_API.INTF_EXEC_LEVEL_',intf_exec_level_);      
   END IF;
END Change_Job_Context__;
  
PROCEDURE Build_Get_Objid_Stmt__ ( 
   upd_stmt_     IN OUT VARCHAR2,
   dyna_view_    IN OUT VARCHAR2,
   date_format_  IN     VARCHAR2,
   ref_attr_     IN     VARCHAR2 )
IS
   ptr_       NUMBER;
   name_      intface_detail.column_name%TYPE;
   value_     VARCHAR2(32000);
   upd_where_ VARCHAR2(32000);
   data_type_ VARCHAR2(200);
   --
   CURSOR get_data IS
      SELECT data_type
      FROM user_tab_columns
      WHERE table_name = dyna_view_
      AND column_name = name_;
BEGIN
   upd_stmt_ := 'BEGIN SELECT objid, objversion INTO :objid, :objversion '||
                'FROM '||dyna_view_;
   ptr_ := NULL;
   WHILE (Client_SYS.Get_Next_From_Attr(ref_attr_, ptr_, name_, value_)) LOOP
      OPEN  get_data;
      FETCH get_data INTO data_type_;
      CLOSE get_data;
      --
      IF ( upd_where_ IS NULL ) THEN
         IF ( nvl(data_type_,'VARCHAR2') = 'DATE' ) THEN
            upd_where_ := ' WHERE '||name_||' = '||
               'to_date('||' :'||name_||','||''''||date_format_||''''||')';
         ELSE
            upd_where_ := ' WHERE '||name_||' = :'||name_;
         END IF;
      ELSE
         IF (  nvl(data_type_,'VARCHAR2') = 'DATE' ) THEN
            upd_where_ := upd_where_||' AND '||name_||' = '||
               'to_date('||' :'||name_||','||''''||date_format_||''''||')';
         ELSE
            upd_where_ := upd_where_||' AND '||name_||' = :'||name_;
         END IF;
      END IF;
   END LOOP;
   upd_stmt_ := upd_stmt_||upd_where_||'; End;';
   --

END Build_Get_Objid_Stmt__;


FUNCTION Complete_Return_Attr__ ( 
   in_attr_      IN VARCHAR2,
   objid_        IN VARCHAR2,
   objversion_   IN VARCHAR2 ) RETURN VARCHAR2
IS
   return_attr_ VARCHAR2(32000) := in_attr_;
BEGIN
   -- Add objid/objversion to return_attr
   -- Methods later in the sequence may use these variables
   Client_SYS.Add_To_Attr('OBJID_', objid_, return_attr_);
   Client_SYS.Add_To_Attr('OBJVERSION_', objversion_, return_attr_);
trace_sys.message('RETURN attr:');
   Intface_Detail_API.Trace_Long_Msg(nvl(return_attr_, 'EMPTY'));
   RETURN nvl(return_attr_, 'EMPTY');
END Complete_Return_Attr__;


-----------------------------------------------------------------------------
-------------------- LU SPECIFIC PROTECTED METHODS --------------------------
-----------------------------------------------------------------------------


-----------------------------------------------------------------------------
-------------------- LU SPECIFIC PUBLIC METHODS -----------------------------
-----------------------------------------------------------------------------

PROCEDURE Make_Attr_And_Reference (
   attr_          IN OUT VARCHAR2,
   reference_     IN OUT VARCHAR2,
   view_name_     IN OUT VARCHAR2,
   intface_name_  IN     VARCHAR2,
   in_source_     IN     VARCHAR2,
   in_method_     IN     VARCHAR2,
   action_        IN     VARCHAR2,
   prefix_option_ IN     VARCHAR2,
   execute_seq_   IN     NUMBER )
IS
   source_owner_  VARCHAR2(100) := Intface_Header_API.Get_Source_owner(intface_name_);
   prepare_attr_  VARCHAR2(2000);
   prepare_value_ VARCHAR2(2000);
   fixed_value_   VARCHAR2(2000);
   info_          VARCHAR2(2000);
   objid_         VARCHAR2(2000);
   objversion_    VARCHAR2(2000);
   prep_action_   VARCHAR2(10) := 'PREPARE';
   action_db_     VARCHAR2(10);
   --
   mode_          VARCHAR2(20);
   stmt_          VARCHAR2(2000);
   h_cur_         INTEGER;
   dummy_         NUMBER;
   flags_         VARCHAR2(10);
   ref_           VARCHAR2(2000);
   lookup_ref_    VARCHAR2(2000);
   lu_prompt_     VARCHAR2(2000);
   lov_view_      VARCHAR2(2000);
   ref_prompt_    VARCHAR2(2000);
   orig_view_     INTFACE_METHOD_LIST.view_name%TYPE := view_name_;
   method_name_   INTFACE_METHOD_LIST.method_name%TYPE := in_method_;
   source_name_   INTFACE_METHOD_LIST.source_name%TYPE := ltrim(rtrim(in_source_));
   description_   intface_method_list_attrib_tab.description%TYPE;
   alias_name_    VARCHAR2(100);
   count_         NUMBER := 0;
   length_        NUMBER;
   attr_seq_      NUMBER;
   max_attr_seq_  NUMBER;
   max_pos_       NUMBER;
   column_name_   intface_detail.column_name%TYPE;
   add_objid_     BOOLEAN;
   create_det_    BOOLEAN;
   rule_string_   intface_rules.rule_value%TYPE;
   default_value_ VARCHAR2(2000);
   note_text_     VARCHAR2(2000);
   source_column_ intface_detail.source_column%TYPE;
   --
   date_format_        VARCHAR2(30) := Client_SYS.Date_Format_;
   --
   not_inside_loop_    EXCEPTION;
   not_outside_loop_   EXCEPTION;
   no_view_allowed_    EXCEPTION;
   no_package_         EXCEPTION;
   -- Db/Client variables
   iid_lu_             VARCHAR2(2000);
   prefixed_column_    VARCHAR2(2000);
   db_client_values_   VARCHAR2(2000);
   db_values_          VARCHAR2(2000);
   client_values_      VARCHAR2(2000);
   on_new_             VARCHAR2(5);
   on_modify_          VARCHAR2(5);
   err_msg_            VARCHAR2(250);
   --
   is_replication_     BOOLEAN := FALSE;
   old_column_name_    intface_detail.column_name%TYPE;
   old_flags_          VARCHAR2(10);
   --
   column_list_        VARCHAR2(32000);
   pos_                NUMBER;
   pos2_               NUMBER;
   objid_source_       VARCHAR2(10);
   test_               NUMBER := 0;
   --
   ref_rec_            reference_record;
   --
   procedure_name_     intface_header_tab.procedure_name%TYPE;
   --
   CURSOR get_source_columns IS
      SELECT c.column_name source_column
      FROM all_tab_columns c
      WHERE c.table_name = source_name_
      AND c.owner = source_owner_
      ORDER BY column_id;
   --
   CURSOR get_columns IS
      SELECT a.column_name column_name, a.data_type data_type,
             to_number(decode(a.data_type, 'NUMBER', nvl(a.data_precision, 20), a.data_length)) length,
             to_number(nvl(a.data_scale, 0)) data_scale, to_number(a.column_id * 10) attr_seq, b.comments,
             '' description
      FROM all_col_comments B, intface_views_col_info a
      WHERE a.view_name = orig_view_
      AND a.view_name  = b.table_name
      AND a.column_name = b.column_name
      AND b.owner = nvl(source_owner_,b.owner)
      AND b.comments IS NOT NULL
      AND a.column_name <> 'TEXT_ID$'
      -- Allow DB-columns,
      -- except for DataMigration LU
      -- This because we use an old FND template.
      -- Also exclude DB-columns for Replication
      AND ((nvl(substr(Dictionary_SYS.Comment_Value_('FLAGS', b.comments), 1, 4),'A---') != 'A---')
           or ( a.column_name like '%_DB' and substr(a.view_name,1,7) != 'INTFACE')
           or ( a.column_name like '%_DB' and Intface_Header_API.Get_Procedure_Name(intface_name_) != 'REPLICATION') )
      ORDER BY 5;
   --
--   CURSOR get_objid IS
--      SELECT c.column_name source_column, a.column_name column_name
--      FROM all_tab_columns c, intface_views_col_info a
--      WHERE a.view_name = orig_view_
--      AND a.column_name = 'OBJID'
--      AND c.table_name (+) = source_name_
--      AND c.owner (+) = source_owner_
--      AND c.column_name (+) = a.column_name;
   --
   CURSOR get_max_values IS
      SELECT nvl(max(pos), 0) pos, nvl(max(attr_seq), 0) attr_seq
      FROM intface_detail
      WHERE intface_name = intface_name_
      AND column_name != 'OBJID';

   CURSOR check_package IS
      SELECT 1 FROM user_objects
      WHERE object_name = upper(method_name_)
      AND object_type = 'PACKAGE';
   --
BEGIN
   --
   -- Find DB-value for action_
   action_db_ := Intface_Method_Action_API.Encode(action_);
   --
   procedure_name_ := Intface_Header_API.Get_Procedure_Name(intface_name_);
   
   IF ( procedure_name_ = 'REPLICATION' ) THEN
      is_replication_ := TRUE;
   END IF;
   -- Lookup relevant Rules
   IF ( Intface_Rules_API.Rule_Is_Active(
      rule_string_, 'CREATEDET', intface_name_) ) THEN
      create_det_ := TRUE;
   ELSE
      create_det_ := FALSE;
   END IF;
   IF ( Intface_Rules_API.Rule_Is_Active(
      rule_string_, 'ADDOBJID', intface_name_) ) THEN
      add_objid_ := TRUE;
   ELSE
      add_objid_ := FALSE;
   END IF;
   -- Empty attr and reference
   reference_ := NULL;
   Client_SYS.Clear_Attr(attr_);
   --
   alias_name_ := NULL;
   IF ( source_name_ IS NULL ) THEN
      source_name_ := Intface_Header_API.Get_Source_Name(intface_name_);
      IF ( instr(source_name_, ',') != 0 ) THEN
         -- This is a JOIN, source name cannot be used for lookup
         source_name_ := NULL;
         source_owner_ := nvl(source_owner_,Fnd_Session_API.Get_App_Owner);
      END IF;
   ELSIF ( instr(ltrim(rtrim(source_name_)),' ') != 0 ) THEN
      alias_name_ := ltrim(rtrim(substr(source_name_,instr(source_name_,' ')+1,length(source_name_))))||'.';
      source_name_ := substr(source_name_,1,instr(source_name_,' ')-1);
   END IF;
   IF ( instr(source_name_, '.') != 0 ) THEN
      -- Source_name is prefixed with owner; separate owner and source
      source_owner_ := substr(source_name_, 1, instr(source_name_, '.')-1);
      source_name_    :=  substr(source_name_, instr(source_name_, '.')+1);
   ELSIF ( (source_name_ IS NOT NULL ) AND ( source_owner_ IS NULL ) ) THEN
      source_owner_ := Fnd_Session_API.Get_App_Owner;
   END IF;
   IF ( instr(upper(method_name_), '.') != 0 ) THEN
      mode_ := 'OTHER';
   ELSIF ( instr(upper(method_name_), '.') = 0 ) THEN
      IF ( action_db_ IN ('1','3' ) ) THEN
         RAISE not_inside_loop_;
      END IF;
      mode_ := 'INSERT';
      stmt_ := 'Begin ' || method_name_ || '.New__(:info,:objid,:objversion,:attr,:action); End;';
      h_cur_ := DBMS_SQL.Open_Cursor;
      -- Get prepare attr
      BEGIN
         OPEN check_package;
         FETCH check_package INTO test_;
         IF check_package%NOTFOUND THEN
            CLOSE check_package;
            RAISE no_package_;
         ELSE
            CLOSE check_package;
         END IF;
         @ApproveDynamicStatement(2009-11-27,nabalk)
         DBMS_SQL.Parse(h_cur_, stmt_, DBMS_SQL.native);
         DBMS_SQL.bind_variable(h_cur_, 'info', info_, 2000);
         DBMS_SQL.bind_variable(h_cur_, 'objid', objid_, 2000);
         DBMS_SQL.bind_variable(h_cur_, 'objversion', objversion_, 2000);
         DBMS_SQL.bind_variable(h_cur_, 'attr', prepare_attr_, 2000);
         DBMS_SQL.bind_variable(h_cur_, 'action', prep_action_, 2000);
         dummy_ := DBMS_SQL.Execute(h_cur_);
         DBMS_SQL.variable_value(h_cur_, 'attr', prepare_attr_);
         DBMS_SQL.Close_Cursor(h_cur_);
      EXCEPTION
         WHEN no_package_ THEN
            DBMS_SQL.Close_Cursor(h_cur_);
            Trace_SYS.Message('NO PKG ERROR : Package '||method_name_||' not found');
         WHEN OTHERS THEN
            DBMS_SQL.Close_Cursor(h_cur_);
            Trace_SYS.Message('PREPARE ERROR :'|| SQLERRM);
      END;
   ELSIF ( instr(upper(method_name_), 'NEW__') != 0 ) THEN
      IF ( action_db_ IN ('1','3' ) ) THEN
         RAISE not_inside_loop_;
      END IF;
      mode_ := 'INSERT';
      stmt_ := 'Begin ' || method_name_ || '.New__(:info,:objid,:objversion,:attr,:action); End;';
      h_cur_ := DBMS_SQL.Open_Cursor;
      -- Get prepare attr
      BEGIN
         @ApproveDynamicStatement(2011-05-19,jhmase)
         DBMS_SQL.Parse(h_cur_, stmt_, DBMS_SQL.native);
         DBMS_SQL.bind_variable(h_cur_, 'info', info_, 2000);
         DBMS_SQL.bind_variable(h_cur_, 'objid', objid_, 2000);
         DBMS_SQL.bind_variable(h_cur_, 'objversion', objversion_, 2000);
         DBMS_SQL.bind_variable(h_cur_, 'attr', prepare_attr_, 2000);
         DBMS_SQL.bind_variable(h_cur_, 'action', prep_action_, 2000);
         dummy_ := DBMS_SQL.Execute(h_cur_);
         DBMS_SQL.variable_value(h_cur_, 'attr', prepare_attr_);
         DBMS_SQL.Close_Cursor(h_cur_);
      EXCEPTION
         WHEN OTHERS THEN
            DBMS_SQL.Close_Cursor(h_cur_);
            Trace_SYS.Message('PREPARE ERROR :'|| SQLERRM);
      END;
   ELSIF ( instr(upper(method_name_), 'MODIFY__') != 0 ) THEN
      IF ( action_db_ IN ('1','3' ) ) THEN
         RAISE not_inside_loop_;
      END IF;
      mode_ := 'INSERT';
--   ELSIF ( instr(upper(method_name_), 'INTFACE_HEADER_API.START_JOB') != 0 ) THEN
--      IF ( action_db_ = '2' ) THEN
--         RAISE not_outside_loop_;
--      END IF;
--      mode_ := 'OTHER';
   END IF;
   IF ( ( mode_ = 'OTHER' AND action_db_ IN ('1','3' )) AND view_name_ IS NOT NULL  ) THEN
      RAISE no_view_allowed_;
   END IF;
   --
   -- Save maxvalues. To be used in INSERT below
   OPEN  get_max_values;
   FETCH get_max_values INTO max_pos_, max_attr_seq_;
   CLOSE get_max_values;
   --
   Trace_SYS.Field('Make attr and ref MODE ',mode_);
   -- Find columns from source
   column_list_ := ';';
   FOR srec_ IN get_source_columns LOOP
      column_list_ := column_list_||srec_.source_column||';';
   END LOOP;
   FOR rec_ IN get_columns LOOP
      -- Check if there is a match on source column
      pos_ := instr(column_list_,';'||rec_.column_name||';');
      IF (pos_ != 0 ) THEN
         pos2_ :=  Instr(column_list_, ';', pos_+1,1);
         source_column_ := substr(column_list_,pos_+1,pos2_-pos_-1);
      ELSE
         source_column_ := NULL;
      END IF;
      -- Clear LOOP variables
      count_            := count_ + 1;
      ref_              := NULL;
      lookup_ref_       := NULL;
      iid_lu_           := NULL;
      db_client_values_ := NULL;
      db_values_        := NULL;
      client_values_    := NULL;
      lu_prompt_        := NULL;
      lov_view_         := NULL;
      flags_            := NULL;
      --
      -- Get flags and format them, make attr_string
      flags_ := substr(Dictionary_SYS.Comment_Value_('FLAGS', rec_.comments), 1, 4);
      IF ( substr(flags_, 1, 1) IN ('P', 'K') ) THEN
         flags_ := substr(flags_, 1, 1);
      ELSE
         flags_ := replace(substr(flags_, 2, 3), '-', '');
      END IF;
      IF ( mode_ = 'INSERT' ) THEN
         -- Get LU name for reference
         ref_ := Dictionary_SYS.Comment_Value_('REF', rec_.comments);
         
         IF ref_ IS NULL THEN
            ref_ := Dictionary_SYS.Comment_Value_('ENUMERATION', rec_.comments);
         END IF;
         
         IF ( ref_ IS NOT NULL ) THEN
            -- Remove parentheses and slashes ( f.ex. '/CASCADE')
            -- to extract LU-name only
            IF ( instr(ref_, '(') != 0 ) THEN
               lookup_ref_ := substr(ref_, 1, instr(ref_, '(')-1);
            ELSE
               lookup_ref_ := ref_;
            END IF;
            IF ( instr(lookup_ref_, '/') != 0 ) THEN
               lookup_ref_ := substr(lookup_ref_, 1, instr(lookup_ref_, '/')-1);
            END IF;
            lov_view_ := dictionary_SYS.Get_Base_View(lookup_ref_);
            IF ( lov_view_ IS NOT NULL ) THEN
               lu_prompt_ := nvl(Language_SYS.Translate_Lu_Prompt_(lookup_ref_), lookup_ref_);
            END IF;
         END IF;
         -- Get this items value from PREPARE
         prepare_value_ := Client_SYS.Get_Item_Value(rec_.column_name, prepare_attr_);
         --
         -- Check if this is an IID LU
         BEGIN
            iid_lu_ := dictionary_SYS.clientnametodbname_(lookup_ref_);
         EXCEPTION
            WHEN OTHERS THEN
               iid_lu_ := NULL;
         END;
         IF ( iid_lu_ IS NOT NULL ) THEN
            -- Get Db/Client-values for this LU
            prefixed_column_ := view_name_||'.'||rec_.column_name;
            Intface_Detail_API.Enum_Db_Client_Values(
               info_,
               db_client_values_,
               db_values_,
               client_values_,
               prefixed_column_,
               iid_lu_,
               lookup_ref_);
         ELSIF ( rec_.column_name like '%_DB' ) THEN
            -- Get Db/Client-values also for DB-columns
            prefixed_column_ := view_name_||'.'||substr(rec_.column_name,1,length(rec_.column_name)-3);
            Intface_Detail_API.Enum_Db_Client_Values(
               info_,
               db_client_values_,
               db_values_,
               client_values_,
               prefixed_column_);
            IF ( rec_.column_name = old_column_name_||'_DB' ) THEN
               -- Inherit flags from Client-column
               flags_ := old_flags_;
            ELSE
               flags_:= '-';
            END IF;
         END IF;
      END IF;
      ref_rec_.column_name_(count_)      := rec_.column_name;
      ref_rec_.data_type_(count_)        := rec_.data_type;
      ref_rec_.description_(count_)      := Intface_Detail_API.Get_Column_Description(view_name_, rec_.column_name);
      attr_seq_                          := rec_.attr_seq;
      ref_rec_.prepare_value_(count_)    := nvl(prepare_value_, 'NULLVALUE');
      ref_rec_.flags_(count_)            := flags_;
      ref_rec_.reference_(count_)        := lookup_ref_;
      ref_rec_.lu_(count_)               := lu_prompt_;
      ref_rec_.lov_view_(count_)         := lov_view_;
      ref_rec_.length_(count_)           := rec_.length;
      ref_rec_.decimal_length_(count_)   := rec_.data_scale;
      ref_rec_.source_column_(count_)    := source_column_;
      ref_rec_.db_client_values_(count_) := db_client_values_;
      ref_rec_.db_values_(count_)        := db_values_;
      ref_rec_.client_values_(count_)    := client_values_;
      ref_rec_.attr_seq_(count_)         := attr_seq_;
      --
      old_column_name_ := rec_.column_name;
      old_flags_ := flags_;
   END LOOP;
   --
   IF ( mode_ = 'OTHER' ) THEN
      Get_Arguments___( count_, ref_rec_, attr_seq_, in_method_ );
   END IF;
   --
   date_format_ := nvl(Intface_Header_API.Get_Date_Format(intface_name_),date_format_);
   -- Concatenate view name with execution sequence to make unique prefix
   IF ( Intface_Prefix_Option_API.Encode(prefix_option_) = '2' and mode_ != 'OTHER' ) THEN
      view_name_ := view_name_||to_char(execute_seq_);
   END IF;
   --
   -- Clear table Intface_Method_List_Attrib_Tab just in case
   DELETE
   FROM Intface_Method_List_Attrib_Tab
   WHERE intface_name = intface_name_
   AND   execute_seq =  execute_seq_;
   --
   FOR i IN 1..count_ LOOP
      IF ( create_det_ ) THEN
         length_ := ref_rec_.length_(i);
         IF ( ref_rec_.data_type_(i) = 'DATE' ) THEN
            length_ := length(date_format_) ;
         END IF;
         IF ( ref_rec_.flags_(i) IN ( 'P', 'K')  ) THEN
            column_name_ := ref_rec_.column_name_(i);
         ELSIF ( ref_rec_.flags_(i) = 'ARG') THEN
            column_name_ := 'METHOD'||to_char(execute_seq_)|| '.' || ref_rec_.column_name_(i);
         ELSIF ( Intface_Prefix_Option_API.Encode(prefix_option_) = '3' ) THEN
            column_name_ := ref_rec_.column_name_(i);
         ELSE
            column_name_ := view_name_ || '.' || ref_rec_.column_name_(i);
         END IF;
         Trace_SYS.Message('COLUMN_NAME :' || column_name_);
         IF (ref_rec_.prepare_value_(i) = 'NULLVALUE' ) THEN
            default_value_ := NULL;
            note_text_ := NULL;
         ELSIF ( ref_rec_.data_type_(i) = 'DATE' ) THEN
            IF ( trunc(to_date(ref_rec_.prepare_value_(i),date_format_)) = trunc(sysdate)  ) THEN
               default_value_ := 'sysdate';
               note_text_ := Language_SYS.Translate_Constant(lu_name_, ' DATEVAL : Default value sysdate from PREPARE  ', Fnd_Session_API.Get_Language );
            ELSE
               note_text_ := Language_SYS.Translate_Constant(lu_name_, ' PREPVAL : Default value :P1 from PREPARE  ', Fnd_Session_API.Get_Language, '''' || ref_rec_.prepare_value_(i) || '''' );
               default_value_ := 'to_date('||'''' || ref_rec_.prepare_value_(i) || ''''||','||''''||date_format_||''''||')';
            END IF;
         ELSE
            default_value_ := '''' || ref_rec_.prepare_value_(i) || '''';
            note_text_ := Language_SYS.Translate_Constant(lu_name_, ' PREPVAL : Default value :P1 from PREPARE  ', Fnd_Session_API.Get_Language, '''' || default_value_ || '''' );
         END IF;
         --
         IF ( ref_rec_.source_column_(i) IS NOT NULL ) THEN
            source_column_ := alias_name_||ref_rec_.source_column_(i);
         ELSE
            source_column_ := NULL;
         END IF;
         IF ( ref_rec_.flags_(i) = 'ARG' AND ref_rec_.description_(i) like 'OUT%' ) THEN
            -- Do not insert rows for OUT-variables in source-mapping
            NULL;
         ELSE
            BEGIN
               INSERT INTO Intface_Detail_Tab(
                  INTFACE_NAME, COLUMN_NAME, DATA_TYPE, LENGTH, DECIMAL_LENGTH,
                  SOURCE_COLUMN, CHANGE_DEFAULTS, DESCRIPTION, FLAGS,  ATTR_SEQ,
                  POS, DEFAULT_VALUE, NOTE_TEXT,
                  DB_CLIENT_VALUES, ROWVERSION)
               VALUES(intface_name_, column_name_ , ref_rec_.data_type_(i),  length_, ref_rec_.decimal_length_(i),
                  source_column_, '2',  ref_rec_.description_(i), ref_rec_.flags_(i), ref_rec_.attr_seq_(i) + max_attr_seq_,
                  ref_rec_.attr_seq_(i) + max_pos_, default_value_, note_text_,
                  decode(instr(column_name_,'_DB'),
                     '0',ref_rec_.client_values_(i),
                          ref_rec_.db_client_values_(i)),sysdate);
               IF procedure_name_ = 'EXCEL_MIGRATION' THEN
                  Basic_Data_Translation_API.Insert_Basic_Data_Translation('FNDMIG', 'IntfaceDetail',
                                                               intface_name_||'^'||column_name_||'^'||'DESCRIPTION',
                                                               NULL, ref_rec_.description_(i));
                  Basic_Data_Translation_API.Insert_Basic_Data_Translation('FNDMIG', 'IntfaceDetail',
                                                               intface_name_||'^'||column_name_||'^'||'NOTE_TEXT',
                                                               NULL, note_text_);
               END IF;
            EXCEPTION
               WHEN OTHERS THEN
                  Intface_Detail_API.Trace_Long_Msg('NOINSERT :' || SQLERRM);
            END;
         END IF;
      END IF;
      --
      IF ( add_objid_ ) THEN
         BEGIN
            -- Check if OBJID exists
            Intface_Detail_API.Exist(intface_name_, 'OBJID');
            -- Do nothing if column exists
         EXCEPTION
            WHEN OTHERS THEN
               BEGIN
                  IF ( is_replication_ ) THEN
                     objid_source_ := 'OBJID';
                  ELSE
                     objid_source_ := 'ROWID';
                  END IF;
                  -- Insert one row for OBJID. POS and ATTR_SEQ is set to
                  -- 99999 to make OBJID appear at bottom of list.
                  INSERT INTO Intface_Detail_Tab(
                     INTFACE_NAME, COLUMN_NAME, DATA_TYPE, LENGTH, SOURCE_COLUMN,
                     CHANGE_DEFAULTS, DESCRIPTION,  ATTR_SEQ, POS, ROWVERSION)
                  VALUES(intface_name_, 'OBJID' , 'VARCHAR2',  20, objid_source_,
                     '2',  'Objid' , 99999, 99999, sysdate);
               EXCEPTION
                  WHEN OTHERS THEN
                     Intface_Detail_API.Trace_Long_Msg('NOINSERT :' || SQLERRM);
               END;
         END;
      END IF;
      --
      fixed_value_ := NULL;
      IF ( ref_rec_.flags_(i) = 'ARG' ) THEN
         -- Set default on-line for f.ex. Intface_Header_API.Start_Job
         IF ( ref_rec_.column_name_(i) = 'EXEC_PLAN_' ) THEN
            fixed_value_ := 'ONLINE';
         END IF;
         description_ := ref_rec_.data_type_(i)||' '||ref_rec_.description_(i);
      ELSE
         description_ := ref_rec_.description_(i);
      END IF;

      on_new_ := 'FALSE';
      on_modify_ := 'FALSE';
      IF ( mode_ != 'OTHER' ) THEN
         -- Check OnNew/OnModify according to job-type and flags
         IF ref_rec_.flags_(i) IN ('P','K') OR ref_rec_.flags_(i) like '%I%' THEN
            on_new_ := 'TRUE';
         END IF;
         IF ref_rec_.flags_(i) IN ('P','K') THEN
            on_modify_ := 'FALSE';
         ELSIF ref_rec_.flags_(i) like '%U%' THEN
            on_modify_ := 'TRUE';
         ELSIF ref_rec_.column_name_(i) like '%DB' THEN
            on_new_ := 'TRUE';
            on_modify_ := 'TRUE';
         END IF;
         IF ( instr(upper(method_name_), 'MODIFY__') != 0 ) THEN
            on_new_ := 'FALSE';
         ELSIF ( instr(upper(method_name_), 'NEW__') != 0 ) THEN
            on_modify_ := 'FALSE';
         END IF;
         -- Do not use DB-columns for replication_jobs
         IF ( is_replication_ AND ref_rec_.flags_(i) = '-' ) THEN
            on_modify_ := 'FALSE';
            on_new_ := 'FALSE';
         END IF;
      ELSIF (ref_rec_.flags_(i) IN ('P','K')) THEN
         ref_rec_.flags_(i) := 'IU';
      END IF;
      db_client_values_ := ref_rec_.db_client_values_(i);
      IF ( ref_rec_.column_name_(i) LIKE '%DB' ) THEN
         ref_prompt_ := NULL;
         db_client_values_ := NULL;
      ELSIF ( ref_rec_.lu_(i) IS NOT NULL ) THEN
         ref_prompt_ := ref_rec_.reference_(i)||' - '||ref_rec_.lu_(i);
      ELSE
         ref_prompt_ := ref_rec_.reference_(i);
      END IF;
      INSERT INTO Intface_Method_List_Attrib_Tab (
         INTFACE_NAME,EXECUTE_SEQ,COLUMN_SEQUENCE, COLUMN_NAME,
         FLAGS,ON_NEW,ON_MODIFY,FIXED_VALUE,
         LU_REFERENCE,
         IID_VALUES, DESCRIPTION, ROWVERSION)
      VALUES (intface_name_,execute_seq_,ref_rec_.attr_seq_(i),ref_rec_.column_name_(i),
         ref_rec_.flags_(i), on_new_, on_modify_, fixed_value_,
         ref_prompt_,
         db_client_values_, description_, SYSDATE);
   END LOOP;
   --
   attr_ := NULL;      -- Do not return this value
   reference_ := NULL; -- Do not return this value
EXCEPTION
   WHEN not_inside_loop_ THEN
      Error_SYS.Record_General(lu_name_, 'NOTINLOOP: Procedure :P1  must be started inside loop', method_name_);
   WHEN not_outside_loop_ THEN
      Error_SYS.Record_General(lu_name_, 'NOTOUTLOOP: Procedure :P1  cannot be started inside loop', method_name_);
   WHEN no_view_allowed_ THEN
      Error_SYS.Record_General(lu_name_, 'NOVIEW: Specify view_name only inside loop');
   WHEN OTHERS THEN
      err_msg_ := substr(SQLERRM,1,250);
      Trace_SYS.Field('OTHERS ',err_msg_);
      err_msg_ :=REGEXP_REPLACE(err_msg_,'ORA-[[:digit:]]{5}: ','');
      Error_SYS.Record_General(lu_name_, 'MAKEOTHER: Error making attribute and references - :P1  ', err_msg_);
END Make_Attr_And_Reference;


FUNCTION Find_Method_Name (
   view_name_ IN VARCHAR2 ) RETURN VARCHAR2
IS
   package_name_ VARCHAR2(100);
BEGIN
   package_name_ := view_name_||'_API';
   IF Database_SYS.Method_Exist(package_name_, 'NEW__') THEN
      RETURN package_name_;
   ELSE   
      RETURN NULL;
   END IF;
END Find_Method_Name;


PROCEDURE Create_Table_From_File (
   info_         IN OUT VARCHAR2,
   intface_name_ IN     VARCHAR2 )
IS
   end_of_file_        BOOLEAN := FALSE;
   attr_               VARCHAR2(32000);
   file_string_        VARCHAR2(32000);
   error_in_create_    EXCEPTION;
   error_in_insert_    EXCEPTION;
   error_in_format_    EXCEPTION;
   error_in_syntax_    EXCEPTION;
   error_in_index_     EXCEPTION;
   error_create_view_  EXCEPTION;
   error_in_grant_     EXCEPTION;
   ambigous_column_    VARCHAR2(2000);
   line_objid_         VARCHAR2(2000);
   message_start_      VARCHAR2(2000);
   table_name_         VARCHAR2(35) := 'IC_'||intface_name_||'_TAB';
   index_name_         VARCHAR2(35) := 'IC_'||intface_name_||'_IX1';
   backup_name_        VARCHAR2(35) := 'IC_'||intface_name_||'_BKP';
      view_name_       VARCHAR2(30) := 'IC_'||intface_name_;
   tablespace_data_    VARCHAR2(100) := Fnd_Setting_API.Get_Value('FNDMIG_TBLSPACE_DATA');
   tablespace_index_   VARCHAR2(100) := Fnd_Setting_API.Get_Value('FNDMIG_TBLSPACE_IND');
   ptr_                NUMBER;
   name_               intface_detail.column_name%TYPE;
   value_              VARCHAR2(32000);
   column_list_        VARCHAR2(32000);
   index_list_         VARCHAR2(32000) := NULL;
   value_list_         VARCHAR2(32000);
   create_list_        VARCHAR2(32000);
   rename_msg_         VARCHAR2(32000);
   describe_msg_       VARCHAR2(32000);
   error_msg_          VARCHAR2(2000);
   describe_tabulator_ VARCHAR2(10) := '       ';
   line_no_            NUMBER := 0;
   status_             intface_job_detail_tab.status%TYPE;
   start_time_         VARCHAR2(50) := to_char(sysdate,'DD-MON-YYYY HH24:MI:SS');
   data_type_          VARCHAR2(30);
   date_format_        VARCHAR2(30) := Client_SYS.Date_Format_;
   count_stmt_         VARCHAR2(32000);
   drop_table_stmt_    VARCHAR2(32000);
   create_table_stmt_  VARCHAR2(32000);
   create_view_stmt_   VARCHAR2(2000);
   view_comment_stmt_  VARCHAR2(100);
   grant_stmt_         VARCHAR2(1000);
   drop_index_stmt_    VARCHAR2(32000);
   create_index_stmt_  VARCHAR2(32000);
   insert_stmt_        VARCHAR2(32000);
   rename_stmt_        VARCHAR2(32000);
   ic_row_stmt_        VARCHAR2(32000);
   i_cur_              INTEGER;
   ins_dummy_          NUMBER;
   insert_count_       NUMBER := 0;
   error_count_        NUMBER := 0;
   row_count_          NUMBER := 0;
   table_count_        NUMBER :=0;
   backup_count_       NUMBER :=0;
   mode_               VARCHAR2(20) := 'CREATE_TABLE';
   commit_seq_         NUMBER := 0;
   commit_count_       NUMBER := 0;
   error_in_conn_      EXCEPTION;
   rule_string_        VARCHAR2(30);
   rule_number_        NUMBER;
   conn_job1_          VARCHAR2(30) := Intface_Job_Detail_API.Get_Ctx_Val_Intf_Conn_Job;
   conn_job2_          VARCHAR2(30);
   conn_status_        NUMBER;
   connection_exist_   BOOLEAN := FALSE;
   table_options_      VARCHAR2(10) := 'DELETE';
   dummy_nbr_          NUMBER := NULL;
   column_name_        intface_detail.column_name%TYPE;
   length_             NUMBER;
   unique_ind_         VARCHAR2(30);
   intf_format_error_  VARCHAR2(2000);
   --
   intfsorted_cols_    Intface_Detail_Util_API.intfdet_col_tab_type;
   intfdet_rec_        Intface_Detail_Util_API.intfdet_tab_type;
   --
   test_       VARCHAR2(100);
   trunc_val_  BOOLEAN;
   string_null_ VARCHAR2(1) := NULL;
   --
   intf_ignorexeerror_     BOOLEAN := App_Context_SYS.Find_Boolean_Value(Intface_Job_Detail_API.intf_ignorexeerror_cid_);
   
   CURSOR find_connections IS
      SELECT intface_name
      FROM intface_rules_tab
      WHERE rule_flag = '1'
      AND rule_value = intface_name_
      AND rule_id = 'CONNJOB';
   --
   CURSOR get_key_columns IS
      SELECT column_name
      FROM Intface_detail_tab
      WHERE intface_name = intface_name_
      AND substr(flags,1,1) IN ('P','K')
      ORDER BY attr_seq, pos, column_name;
   --
   -- New procedure for Native dynamic SQL
   -- to replace calls to old DBMS_SQL
   PROCEDURE Execute_Stmt ( 
      error_msg_    IN OUT VARCHAR2 , 
      count_        IN OUT NUMBER,
      stmt_         IN     VARCHAR2 , 
      return_error_ IN     VARCHAR2 ) 
   IS
   BEGIN
      Intface_Detail_API.Trace_Long_Msg(stmt_);
      IF ( count_ IS NULL ) THEN
         @ApproveDynamicStatement(2011-05-19,jhmase)
         EXECUTE IMMEDIATE stmt_;
      ELSE
         @ApproveDynamicStatement(2011-05-19,jhmase)
         EXECUTE IMMEDIATE stmt_
         USING IN OUT count_;
      END IF;
   EXCEPTION
      WHEN OTHERS THEN
         IF ( return_error_ = 'TRUE' ) THEN
            error_msg_ := SQLERRM;
         ELSE
            error_msg_ := NULL;
         END IF;
   END Execute_Stmt;
   --
   FUNCTION Get_Bind_Value (
      date_form_ IN VARCHAR2,
      data_type_ IN VARCHAR2,
      name_      IN VARCHAR2 ) RETURN VARCHAR2
   IS
      bind_value_ VARCHAR2(2000);
   BEGIN
      IF ( data_type_ = 'DATE' ) THEN
         bind_value_ := 'to_date( :'||name_||','||''''||date_form_||''''||')';
      ELSE
         bind_value_ := ' :'||name_;
      END IF;
      RETURN bind_value_;
   END Get_Bind_Value;
BEGIN
   --
   --   message_start_ := Language_SYS.Translate_Constant(lu_name_, ' TIMESTAMP1 : Start time - :P1   :P2', Fnd_Session_API.Get_Language, start_time_, intface_name_);
   --
   info_ := NULL;
   intfdet_rec_ := Intface_Detail_Util_API.Get_Intface_Details(intface_name_);
   IF ( nvl(App_Context_SYS.Find_Value(Intface_Job_Detail_API.intf_in_info_cid_),'**') = 'RESTART') THEN
      -- Restarted job. Do not backup table, just insert remaining rows
      rename_msg_ := Language_SYS.Translate_Constant(lu_name_, ' RESTART : Restart insert into table :P1 ', Fnd_Session_API.Get_Language, table_name_);
   ELSE
      --
      IF ( conn_job1_ IS NOT NULL ) THEN
         -- This job has been started from another job
         -- Find status of connected job
         conn_status_ := Intface_Job_Status_API.Encode(Intface_Job_Detail_API.Get_Min_Status(conn_job1_));
         Intface_Job_Detail_API.Set_Ctx_Val_Intf_Conn_Job_(string_null_);
      ELSE
         -- Started directly from client,
         -- check if connections exist
         OPEN  find_connections;
         FETCH find_connections INTO conn_job2_;
            connection_exist_ := find_connections%FOUND;
         CLOSE find_connections;
      END IF;
      IF ( connection_exist_ ) THEN
         -- Cannot be started here
         Client_SYS.Add_Info(lu_name_, ' CONNERR : Job :P1 is connected to job :P2 and can not be started directly', intface_name_, conn_job2_);
         RAISE error_in_conn_;
      END IF;
      IF ( Intface_Rules_API.Rule_Is_Active(
              rule_string_, 'CRETABCONF', intface_name_) ) THEN
         table_options_ := rule_string_;
         IF ( table_options_ = 'KEEPERR' and conn_job1_ IS NULL ) THEN
            Client_SYS.Add_Info(lu_name_, 'KEEPERR : Rule KEEPERR can only be used when another job is connected to :P1 ', intface_name_);
            RAISE error_in_conn_;
         ELSIF ( table_options_ = 'KEEPALL' and conn_job1_ IS NOT NULL ) THEN
            Client_SYS.Add_Info(lu_name_, 'KEEPALL : Rule KEEPALL can not be used when another job is connected to :P1 (:P2)  ', intface_name_, conn_job1_ );
            RAISE error_in_conn_;
         ELSIF ( table_options_ = 'NOBACKUP' ) THEN
            NULL; -- Do no make backup-table
         END IF;
      END IF;
      --
      -- Drop old backup table after counting number of records
      -- Then rename table if it already exists
      --
      -- Count records
      count_stmt_ := 'BEGIN SELECT count(1) INTO :count FROM '||backup_name_||'; End;';
      backup_count_ := 0;
      Execute_Stmt(error_msg_, backup_count_, count_stmt_, 'TRUE');
      IF ( error_msg_ IS NOT NULL) THEN
         -- Backup table does not exist
         backup_count_ := -1;
         error_msg_ := NULL;
      ELSE
         -- Drop old backup table
         drop_table_stmt_ := 'DROP TABLE '||backup_name_;
         Execute_Stmt(error_msg_, dummy_nbr_ , drop_table_stmt_, 'FALSE');
         error_msg_ := NULL;
      END IF;
      -- Count records
      count_stmt_ := 'BEGIN SELECT count(1) INTO :count FROM '||table_name_||'; End;';
      table_count_ := 0;
      Execute_Stmt(error_msg_, table_count_, count_stmt_, 'TRUE');
      IF ( error_msg_ IS NOT NULL) THEN
         -- Table does not exist
         table_count_ := -1;
         error_msg_ := NULL;
      END IF;
      Trace_SYS.message('TABLE COUNT 1 '||error_msg_||' '||table_count_);
      -- Do not make backup-table with these options
      IF ( table_options_ NOT IN ('KEEPALL','NOBACKUP' )  ) THEN
         -- Rename table
         rename_stmt_ := 'RENAME '||table_name_||' to '||backup_name_;
         Execute_Stmt(error_msg_, dummy_nbr_, rename_stmt_, 'TRUE');
         IF ( error_msg_ IS NOT NULL ) THEN
            error_msg_ := NULL; -- May not exist, ignore error-message
         ELSE
            rename_msg_ := Language_SYS.Translate_Constant(lu_name_, ' RENAMTAB : Renamed table :P1 with :P2 records to :P3 ', Fnd_Session_API.Get_Language, table_name_, table_count_ , backup_name_);
         END IF;
         -- Table no longer exists
         table_count_ := -1;
         -- Add IC_ROW_NO to backup table if does not exist.
         ic_row_stmt_ := 'ALTER TABLE '||backup_name_||' ADD (IC_ROW_NO NUMBER)';
         Execute_Stmt(error_msg_, dummy_nbr_, ic_row_stmt_, 'FALSE');
         error_msg_ := NULL;
      END IF;
      IF ( table_options_ = 'NOBACKUP') THEN
         -- Drop old table
         drop_table_stmt_ := 'DROP TABLE '||table_name_;
         Execute_Stmt(error_msg_, dummy_nbr_ , drop_table_stmt_, 'FALSE');
         table_count_ := -1;
         error_msg_ := NULL;
      END IF;
      --
      -- Start on message to be displayed at end of procedure
      describe_msg_ := Language_SYS.Translate_Constant(lu_name_, ' CRETAB : Created table  :P1 (', Fnd_Session_API.Get_Language, table_name_ );
      describe_msg_ := describe_msg_||msg_sep_;
      FOR rec_nbr_ IN 1..intfdet_rec_.count LOOP
         --
         data_type_   := intfdet_rec_(rec_nbr_).data_type;
         column_name_ := intfdet_rec_(rec_nbr_).column_name;
         length_      := intfdet_rec_(rec_nbr_).length;
         -- Lookup data loaded in global table
         IF (length_ != 0 ) THEN
            -- Dash or space in column name creates trouble 
            -- for CREATE TABLE statement
            IF ( ( instr( column_name_,' ') != 0 ) OR
                 ( instr( column_name_,'-') != 0 ) ) THEN
               ambigous_column_ := column_name_;
               RAISE error_in_syntax_;
            END IF;
            -- Build list of columns for the create statement +formatted list of columns to be displayed in info message
            IF (data_type_ = 'VARCHAR2' ) THEN
               create_list_ := create_list_||column_name_||' '||'VARCHAR2('||length_||')'||',';
               describe_msg_ := describe_msg_||describe_tabulator_||column_name_||' '||'VARCHAR2('||length_||')'||','||msg_sep_;
            ELSE
               create_list_ := create_list_||column_name_||' '||data_type_||',';
               describe_msg_ := describe_msg_||describe_tabulator_||column_name_||' '||data_type_||','||msg_sep_;
            END IF;
         END IF;
      END LOOP;
      --
      -- Add column IC_ROW_NO
      describe_msg_ := describe_msg_||describe_tabulator_||'IC_ROW_NO NUMBER'||')';
      IF ( length(describe_msg_) > 1000 ) THEN
         -- Do not display list of columns if this is a long statement
         describe_msg_ := 'CREATE TABLE '||table_name_;
      END IF;
      create_list_ := create_list_||'IC_ROW_NO NUMBER';
      IF ( nvl(tablespace_data_,'*') != '*'  ) THEN
         tablespace_data_ := ' TABLESPACE '||tablespace_data_;
         describe_msg_ := describe_msg_||msg_sep_||tablespace_data_;
      ELSE
         tablespace_data_ := NULL;
      END IF;
      --Complete create statement
      create_table_stmt_ := 'CREATE TABLE '||table_name_||'('||create_list_||') '||
                      tablespace_data_;
      create_view_stmt_  := 'CREATE OR REPLACE VIEW '|| view_name_ ||' AS SELECT * FROM '|| table_name_;
      view_comment_stmt_ := 'COMMENT ON TABLE '|| view_name_ ||' IS ''MODULE=IGNORE^''';
      grant_stmt_        := 'GRANT SELECT ON '|| view_name_  || ' TO IFSSYS';
      IF ( rename_msg_ IS NOT NULL ) THEN
         -- Restore data from previous execution
         IF ( table_options_ = 'KEEPERR' AND conn_job1_ IS NOT NULL ) THEN
            -- Fetch error data from previous execution , then append data from file
            create_table_stmt_ := 'CREATE TABLE '||table_name_||
                             tablespace_data_||
                            ' AS SELECT * FROM '||backup_name_||
                            ' WHERE rowid IN (SELECT source_rowid FROM intface_job_hist_detail_tab '||
                                            ' WHERE intface_name = '||''''||conn_job1_||''''||
                                            ' AND execution_no in ('||
                                            ' select max(execution_no) '||
                                            ' from intface_job_hist_detail_tab '||
                                            ' WHERE intface_name = '||''''||conn_job1_||''''||'))';
            --
            describe_msg_ := 'CREATE TABLE '||table_name_||msg_sep_||
                            ' AS SELECT * FROM '||backup_name_||msg_sep_||
                            ' WHERE rowid IN (SELECT source_rowid FROM intface_job_hist_detail_tab '||msg_sep_||
                                            ' WHERE intface_name = '||''''||conn_job1_||''''||msg_sep_||
                                            ' AND execution_no in ('||msg_sep_||
                                            '    select max(execution_no) '||msg_sep_||
                                            '    from intface_job_hist_detail_tab '||msg_sep_||
                                            '    WHERE intface_name = '||''''||conn_job1_||''''||'))';
         END IF;
      END IF;
      column_list_ := NULL;
      Trace_SYS.message('TABLE COUNT 2 '||table_count_);
      IF ( table_count_ = -1 ) THEN 
         -- Execute create table statement
         Execute_Stmt(error_msg_, dummy_nbr_, create_table_stmt_ , 'TRUE');
         IF ( error_msg_ IS NOT NULL ) THEN
            RAISE error_in_create_;
         END IF;
         -- Create index if rule is active
         IF ( Intface_Rules_API.Rule_Is_Active(
                 unique_ind_, 'CREINDEX', intface_name_) ) THEN
            IF ( nvl(tablespace_index_,'*') != '*'  ) THEN
               tablespace_index_ := ' TABLESPACE '||tablespace_index_;
            ELSE
               tablespace_index_ := NULL;
            END IF;
            -- Get key columns
            FOR keyrec_ IN get_key_columns LOOP
               index_list_ := index_list_||','||keyrec_.column_name;
            END LOOP;
            index_list_  := ltrim(index_list_ ,',');
            drop_index_stmt_ := 'DROP INDEX '||index_name_;
            create_index_stmt_ := 'CREATE '||unique_ind_||' INDEX '||index_name_||' ON '||table_name_||'('||index_list_||')'
                                   ||tablespace_index_;
            Execute_Stmt(error_msg_, dummy_nbr_, drop_index_stmt_, 'FALSE');
            Execute_Stmt(error_msg_, dummy_nbr_, create_index_stmt_, 'TRUE');
            IF ( error_msg_ IS NOT NULL ) THEN
               RAISE error_in_index_;
            END IF;
            describe_msg_ := describe_msg_||msg_sep_||
               Language_SYS.Translate_Constant(lu_name_, ' CREIND : Created :P1 index on column :P2 ', Fnd_Session_API.Get_Language, unique_ind_, index_list_ );
         END IF;
         -- Execute create view statement
         Execute_Stmt(error_msg_, dummy_nbr_, create_view_stmt_ , 'TRUE');
         IF ( error_msg_ IS NOT NULL ) THEN
            RAISE error_create_view_;
         END IF;
         -- Execute view comment statement
         Execute_Stmt(error_msg_, dummy_nbr_, view_comment_stmt_ , 'TRUE');
         IF ( error_msg_ IS NOT NULL ) THEN
            RAISE error_create_view_;
         END IF;
         -- Execute grant view statement
         Execute_Stmt(error_msg_, dummy_nbr_, grant_stmt_ , 'TRUE');
         IF ( error_msg_ IS NOT NULL ) THEN
            RAISE error_in_grant_;
         END IF;
      ELSE
         describe_msg_ := Language_SYS.Translate_Constant(lu_name_, ' INSTAB : Insert into table :P1  with :P2 rows ', Fnd_Session_API.Get_Language, table_name_, table_count_ );
         describe_msg_ := describe_msg_||msg_sep_;
      END IF;
      -- Cleanup data on connected job
      IF ( nvl(conn_status_,0) = 3 AND table_options_ = 'KEEPERR' ) THEN
         IF ( Intface_Rules_API.Rule_Is_Active(
            rule_number_, 'SAVEJOBDAYS', conn_job1_) ) THEN
            Intface_Job_Detail_API.Make_History(conn_job1_, rule_number_, TRUE);
         END IF;
         Intface_Job_Detail_API.Delete_Details(conn_job1_);
      END IF;
   END IF;
@ApproveTransactionStatement(2014-04-02,mabose)
   SAVEPOINT new_job_;
   -- Table is created, count if records have been selected from backup....
   count_stmt_ := 'BEGIN SELECT count(1) INTO :count FROM '||table_name_||'; End;';
   row_count_ := 0;
   Execute_Stmt(error_msg_, row_count_ , count_stmt_, 'FALSE');
   IF ( Intface_Rules_API.Rule_Is_Active(
           rule_string_, 'EXTTABLE', intface_name_) 
      AND App_Context_SYS.Find_Boolean_Value(Intface_Job_Detail_API.intf_file_is_on_server_cid_) ) THEN
      -- Create External Table and insert rows directly into IC-table
      UTL_FILE.FCLOSE_ALL; -- Close open server-file
      App_Context_SYS.Set_Value('INTFACE_SERVER_FILE_API.REJECT_LIMIT_',(nvl(rule_string_,'UNLIMITED')));
      BEGIN
         Intface_Server_File_API.Insert_From_Ext_To_Ic_Table(intface_name_, row_count_, insert_count_);
      EXCEPTION WHEN OTHERS THEN
         describe_msg_ := describe_msg_||msg_sep_||msg_sep_||SQLERRM;
      END;
      Intface_Server_File_API.Check_For_Bad_File(intface_name_);
   ELSE
      IF ( Intface_Rules_API.Rule_Is_Active(test_, 'TRUNCVAL', intface_name_) ) THEN
         trunc_val_ := TRUE;
      ELSE
         trunc_val_ := FALSE;
      END IF;
      
      intfsorted_cols_ := Intface_Detail_Util_API.Get_Sorted_Intface_Columns(intface_name_);
      intfdet_rec_ := Intface_Detail_Util_API.Get_Intface_Details(intface_name_);
      -- .. then get lines from file
      LOOP
         IF ( App_Context_SYS.Find_Boolean_Value(Intface_Job_Detail_API.intf_file_is_on_client_cid_) ) THEN
            FETCH Intface_Job_Detail_API.Get_String INTO line_no_, file_string_, status_, line_objid_;
            EXIT WHEN  Intface_Job_Detail_API.Get_String%NOTFOUND;
         ELSIF ( App_Context_SYS.Find_Boolean_Value(Intface_Job_Detail_API.intf_file_is_on_server_cid_) ) THEN
            Intface_Job_Detail_API.Get_Next_Line(line_no_, file_string_, end_of_file_);
            EXIT WHEN end_of_file_;
         END IF;
         CLient_Sys.Clear_Attr(attr_);
@ApproveTransactionStatement(2014-04-02,mabose)
         SAVEPOINT new_string_;
         --
         row_count_ := row_count_ +1;
         commit_seq_ := commit_seq_ +1;
         -- Build attr-string for each row from file
         IF ( Intface_Detail_API.String_To_Attr( attr_, file_string_, intf_format_error_, intface_name_, intfsorted_cols_, intfdet_rec_, trunc_val_) ) THEN
            ptr_ := NULL;
            WHILE (Client_SYS.Get_Next_From_Attr(attr_, ptr_, name_, value_)) LOOP
               IF ( value_ IS NOT NULL ) THEN
                  -- LOOP on ATTR-string to build insert column list + values list
                  -- Look up PL/SQL-table to find data-type for each column
                  FOR rec_nbr_ IN 1..intfdet_rec_.count LOOP
                     --
                     data_type_   := intfdet_rec_(rec_nbr_).data_type;
                     column_name_ := intfdet_rec_(rec_nbr_).column_name;
                     length_      := intfdet_rec_(rec_nbr_).length;
                     IF ( name_ = column_name_ ) THEN
                        IF (length_ != 0 ) THEN
                           column_list_ := column_list_||name_||',';
                           value_list_  := value_list_||Get_Bind_Value(date_format_,data_type_, name_)||',';
                        END IF;
                        EXIT;
                     END IF;
                  END LOOP;
               END IF;
            END LOOP;
            value_list_ := value_list_||':IC_ROW_NO';
            column_list_ := column_list_||'IC_ROW_NO';
            insert_stmt_ := 'INSERT INTO '||table_name_||' ('||column_list_||') VALUES ('||value_list_||' )';
            -- Execute insert by DBMS_SQL to be able to parse bind-variables
            ptr_ := NULL;
            i_cur_ := DBMS_SQL.Open_Cursor;
            @ApproveDynamicStatement(2011-05-19,jhmase)
            DBMS_SQL.Parse(i_cur_, insert_stmt_ , DBMS_SQL.native);
            WHILE (Client_SYS.Get_Next_From_Attr(attr_, ptr_, name_, value_)) LOOP
               IF ( value_ IS NOT NULL ) THEN
                  value_ := REPLACE(value_, 'NULLVALUE','');
                  DBMS_SQL.bind_variable(i_cur_,name_, value_, 2000);
               END IF;
            END LOOP;
            -- Parse line-counter
            DBMS_SQL.bind_variable(i_cur_,'IC_ROW_NO', row_count_, 2000);
            --
            BEGIN
               ins_dummy_ := DBMS_SQL.Execute(i_cur_);
               DBMS_SQL.Close_Cursor(i_cur_);
            EXCEPTION
               WHEN OTHERS THEN
                  error_msg_ := SQLERRM;
                  DBMS_SQL.Close_Cursor(i_cur_);
            END;
            IF ( error_msg_ IS NULL ) THEN
               -- Insert is OK
               insert_count_ := insert_count_ + 1;
               IF ( App_Context_SYS.Find_Boolean_Value(Intface_Job_Detail_API.intf_file_is_on_client_cid_) ) THEN
                  Intface_Job_Detail_API.Process_Job_Details(intface_name_,
                     line_no_ ,file_string_ , attr_ , null , line_objid_ );
               END IF;
            -- Error handling for insert
            ELSIF ( NOT intf_ignorexeerror_ ) THEN
               error_count_ := error_count_ + 1;
               RAISE error_in_insert_;
            ELSE
@ApproveTransactionStatement(2014-04-02,mabose)
               ROLLBACK TO SAVEPOINT new_string_;
               error_count_ := error_count_ + 1;
               Intface_Job_Detail_API.Process_Job_Details(intface_name_,
                  line_no_ ,file_string_ , attr_ , error_msg_ , line_objid_ );
            END IF;
            value_list_  := NULL;
            column_list_ := NULL;
            error_msg_   := NULL;
         ELSE
            error_count_ := error_count_ + 1;
            IF ( NOT intf_ignorexeerror_ ) THEN
               RAISE error_in_format_;
            ELSE
               Intface_Job_Detail_API.Process_Job_Details(intface_name_,
                  line_no_ ,file_string_ , attr_ , intf_format_error_ , line_objid_ );
            END IF;
         END IF;
         value_list_  := NULL;
         column_list_ := NULL;
         error_msg_   := NULL;
         IF ( nvl(App_Context_SYS.Find_Number_Value(Intface_Job_Detail_API.intf_commit_seq_cid_),commit_seq_+1) <= commit_seq_ ) THEN
@ApproveTransactionStatement(2014-04-02,mabose)
            COMMIT;
            Trace_SYS.Message(' TRACE>>>>>>> Commit ');
            commit_count_ := commit_count_ + commit_seq_;
            commit_seq_ := 0;
@ApproveTransactionStatement(2014-04-02,mabose)
            SAVEPOINT new_job_;
         END IF;
      END LOOP;
   END IF;
   -- Build info variable.
   info_ := mode_;
   Build_Info_String__(info_,message_start_ ,rename_msg_, describe_msg_,null,null, start_time_ , row_count_ , null, insert_count_,error_count_,intface_name_);
   App_Context_SYS.Set_Value(Intface_Job_Detail_API.intf_execution_ok_cid_,TRUE);
EXCEPTION
   WHEN error_in_conn_ THEN
      info_ := Client_Sys.Get_All_Info;
      Trace_SYS.field('CONN ',info_);
   WHEN error_in_create_ THEN
      Client_SYS.Add_Info(lu_name_, 'CREATEERROR : Error creating table :P1 - :P2', table_name_, error_msg_);
      info_ := Client_Sys.Get_All_Info;
   WHEN error_in_index_ THEN
      Client_SYS.Add_Info(lu_name_, 'INDEXERROR : Error creating index :P1 - :P2', create_index_stmt_, error_msg_);
      info_ := Client_Sys.Get_All_Info;
   WHEN error_create_view_ THEN
      Client_SYS.Add_Info(lu_name_, 'CREATEVIEWERR : Error creating view :P1 - :P2', view_name_, SUBSTR(error_msg_,0,900));
      info_ := Client_Sys.Get_All_Info;
   WHEN error_in_grant_ THEN
      Client_SYS.Add_Info(lu_name_, 'GRANTERROR : Error granting view :P1 to IFS system user (IFSSYS) - :P2', view_name_, SUBSTR(error_msg_,0,900));
      info_ := Client_Sys.Get_All_Info;
   WHEN error_in_syntax_ THEN
      Client_SYS.Add_Info(lu_name_, 'SYNTAXERROR : Column name :P1 is ambigously defined ', ambigous_column_ );
      info_ := Client_Sys.Get_All_Info;
      Trace_SYS.field('CREATE ',info_);
   WHEN error_in_insert_ THEN
@ApproveTransactionStatement(2014-04-02,mabose)
      ROLLBACK TO SAVEPOINT new_job_;
      info_ := mode_;
      IF ( commit_count_ > 0 ) THEN
         insert_count_ := commit_count_;
      END IF;
      Build_Info_String__(info_,message_start_ ,rename_msg_, describe_msg_,error_msg_,null, start_time_ , row_count_ , null, insert_count_,error_count_,intface_name_);
      Intface_Job_Detail_API.Process_Job_Details(intface_name_,
         line_no_ ,file_string_ , attr_ , error_msg_ , line_objid_ );
      Trace_SYS.field('INSERT ',error_msg_);
   WHEN error_in_format_ THEN
@ApproveTransactionStatement(2014-04-02,mabose)
      ROLLBACK TO SAVEPOINT new_job_;
      Intface_Job_Detail_API.Process_Job_Details(intface_name_,
         line_no_ ,file_string_ , attr_ , intf_format_error_ , line_objid_ );
      info_ := mode_;
      IF ( commit_count_ > 0 ) THEN
         insert_count_ := commit_count_;
      END IF;
      Build_Info_String__(info_,message_start_ ,rename_msg_, describe_msg_,intf_format_error_,null, start_time_ , row_count_ , null, insert_count_,error_count_,intface_name_);
      Trace_SYS.field('format_ ',intf_format_error_);
   WHEN OTHERS THEN
      error_msg_ := SQLERRM;
@ApproveTransactionStatement(2014-04-02,mabose)
      ROLLBACK TO SAVEPOINT new_job_;
      info_ := mode_;
      Build_Info_String__(info_,message_start_ ,rename_msg_, describe_msg_,error_msg_,null, start_time_ , row_count_ , null, insert_count_,error_count_,intface_name_);
      Intface_Job_Detail_API.Process_Job_Details(intface_name_,
         line_no_ ,file_string_ , attr_ , error_msg_ , line_objid_ );
      Trace_SYS.field('OTHER ',error_msg_);
END Create_Table_From_File;


PROCEDURE Rebuild_Attr_String (
   attr_         IN OUT VARCHAR2,
   source_attr_  IN     VARCHAR2,
   convert_attr_ IN     VARCHAR2,
   view_name_    IN     VARCHAR2,
   row_count_    IN     NUMBER,
   method_mode_  IN     VARCHAR2 )
IS
BEGIN
   Error_SYS.Appl_General(lu_name_, 'OBSOL: Procedure is obsolete');
END Rebuild_Attr_String;


PROCEDURE Migrate_Source_Data (
   info_         IN OUT VARCHAR2,
   intface_name_ IN     VARCHAR2 )
IS
   dyna_count_         NUMBER := 0;
   dyna_rec_           dynamic_record;

   source_name_        intface_header.source_name%TYPE;
   source_owner_       intface_header.source_owner%TYPE;
   source_rowid_       rowid;
   count_              NUMBER := 0;
   cols_               VARCHAR2(32000);
   cols_value_         intface_detail.default_value%TYPE;
   stmt_               VARCHAR2(32000);
   before_stmt_        VARCHAR2(2000);
   dyna_stmt_          VARCHAR2(2000);
   upd_stmt_           VARCHAR2(2000);
   where_              VARCHAR2(32000);
   order_by_           VARCHAR2(2000);
   group_by_           VARCHAR2(2000);
   h_cur_              INTEGER;
   dummy_              NUMBER;
   attr_               VARCHAR2(32000);
   column_value_       VARCHAR2(2000);
   convert_value_      VARCHAR2(2000);
   column_name_        intface_detail.column_name%TYPE;
   conv_list_id_       intface_detail.conv_list_id%TYPE;
   row_count_          NUMBER := 0;
   commit_count_       NUMBER := 0;
   commit_seq_         NUMBER := 0;
   commit_seq_cnt_     NUMBER := 0;
   error_count_        NUMBER := 0;
   check_count_        NUMBER := 0;
   rowid_count_        NUMBER;
   dyna_attr_          VARCHAR2(32000);
   w_attr_             VARCHAR2(32000);
   objid_              VARCHAR2(2000);
   objversion_         VARCHAR2(2000);
   action_             VARCHAR2(10) := 'DO';
   date_format_start_  VARCHAR2(30) := 'to_char(';
   date_format_end_    VARCHAR2(100) := ','||''''||'YYYY-MM-DD-HH24.MI.SS'||''''||')';
   date_format_        VARCHAR2(30) := Client_SYS.Date_Format_;
   rowid_name_         VARCHAR2(30);
   start_time_         VARCHAR2(50) := to_char(sysdate,'DD-MON-YYYY HH24:MI:SS');
   message_start_      VARCHAR2(32000) := NULL;
   message_before_     VARCHAR2(32000) := NULL;
   message_select_     VARCHAR2(32000) := NULL;
   message_method_     VARCHAR2(32000) := NULL;
   all_methods_        VARCHAR2(32000) := NULL;
   method_result_      VARCHAR2(2000) := NULL;
   message_after_      VARCHAR2(32000) := NULL;
   header_message_     VARCHAR2(2000);
   execute_method_     BOOLEAN;
   start_ok_           BOOLEAN;
   execution_no_       NUMBER;
   incomplete_select_  EXCEPTION;
   method_error_       EXCEPTION;
   method_error_after_ EXCEPTION;
   no_restart_         EXCEPTION;
   no_execute_         EXCEPTION;
   no_start_           EXCEPTION;
   no_conn_start_      EXCEPTION;
   old_seq_            NUMBER;
   show_method_        VARCHAR2(100);
   add_objid_          BOOLEAN;
   rule_string_        intface_rules.rule_value%TYPE;
   method_upd_isopen_  BOOLEAN := FALSE;
   method_h_isopen_    BOOLEAN := FALSE;
   parse_intface_name_ intface_header_tab.intface_name%TYPE;
   parse_info_         VARCHAR2(2000);
   parse_attr_         VARCHAR2(2000);
   ref_attr_           VARCHAR2(2000);
   ref_value_          VARCHAR2(2000);
   dyna_view_          INTFACE_METHOD_LIST.view_name%TYPE;
   exec_seq_           VARCHAR2(10);
   exec_plan_          VARCHAR2(10) := 'ONLINE';
   method_raised_      NUMBER;
   -- To be used when inserting master/detail rows.
   new_master_         BOOLEAN := TRUE;
   first_row_          BOOLEAN := FALSE;
   master_key_value_   VARCHAR2(32000);
   old_master_value_   VARCHAR2(32000);
   -- Variables to check if methods before, in or after loop fails.
   -- To be used when intf_execution_ok_ is given value at end of procedure
   methods_before_ok_  BOOLEAN := TRUE;
   methods_in_ok_      BOOLEAN := TRUE;
   methods_after_ok_   BOOLEAN := TRUE;
   -- Variables used to check if methods New/Modify have
   -- been defined in pairs(after each other) in MethodList.
   -- That affects the execution.
   second_method_      BOOLEAN;
   --
   i_                  NUMBER := 0;
   value_list_         VARCHAR2(2000) := 'NO REPLICATION;';
   repl_destination_   VARCHAR2(20);
   convert_attr_       VARCHAR2(32000);
   arg_attr_           VARCHAR2(32000);
   return_attr_        VARCHAR2(32000);
   null_value_         CONSTANT VARCHAR2(20) := NULL;
   start_              DATE;
   row_err_count_      NUMBER := 0;
   log_seq_count_      NUMBER;
   log_seq_            NUMBER;
   cur_log_seq_        NUMBER;
   replication_        BOOLEAN := FALSE;
   repl_criteria_      intface_header_tab.repl_criteria%TYPE  := 'XX';
   repl_mode_          intface_header_tab.replication_mode%TYPE := 'XX';
   -- Variables to check how methods did execute
   incomplete_trans_   BOOLEAN := FALSE;
   method_executed_    BOOLEAN;
   incomplete_result_  VARCHAR2(2000) := NULL;
   error_result_       VARCHAR2(2000) := NULL;
   old_exe_seq_        NUMBER := 0;
   conn_job1_          VARCHAR2(30);
   use_nullvalue_      VARCHAR2(30) := 'NULLVALUE';
   dummy_proc_         VARCHAR2(100);
   source_specified_   BOOLEAN := TRUE;
   intf_repl_rowid_    VARCHAR2(2000);
   --
   intf_ignorexeerror_     BOOLEAN := App_Context_SYS.Find_Boolean_Value(Intface_Job_Detail_API.intf_ignorexeerror_cid_);
   intf_in_info_ VARCHAR2(2000) := App_Context_SYS.Find_Value(Intface_Job_Detail_API.intf_in_info_cid_);
   
   -- Get methods to be executed
   CURSOR check_details IS
      SELECT count(1)
      FROM intface_job_detail_tab
      WHERE intface_name = intface_name_
      GROUP BY intface_name;
   --
   CURSOR get_max_log_seq IS
      SELECT NVL(MAX(log_seq),0)
      FROM intface_replication_log_tab
      WHERE intface_name = intface_name_;
   --
   CURSOR get_min_log_seq(repl_rowid_ VARCHAR2) IS
      SELECT NVL(MIN(log_seq),0)
      FROM intface_replication_log_tab
      WHERE intface_name = intface_name_
      AND repl_rowid = repl_rowid_;
   --
   -- Get methods to be executed for one action value
   CURSOR Get_Method_List (action_ IN VARCHAR2 ) IS
      SELECT
         intface_name, execute_seq, view_name,
         method_name,
         decode(instr(column_name,'@'),
            '0','#'||Intface_Detail_API.Get_Pos(intface_name,column_name), -- Find pos and prefix with hash 
            column_name) column_name, 
         column_value, convert_attr, references,
         source_name, note_text, prefix_option, action, rowversion,
         on_modify,
         on_new,
         Get_Method_Type(method_name) method_type,
         nvl(on_new_master,'FALSE') on_new_master,
         nvl(on_first_row,'FALSE') on_first_row
      FROM intface_method_list_tab
      WHERE intface_name = intface_name_
      AND action = action_
      ORDER BY execute_seq;
   --
   CURSOR Get_Columns IS
      SELECT *
      FROM Intface_detail_tab
      WHERE intface_name = intface_name_
      AND ( source_column IS NOT NULL OR default_value IS NOT NULL)
      ORDER BY pos,attr_seq;
   --
   CURSOR check_proc IS
      SELECT object_name, execute_seq, status
      FROM all_objects, intface_method_list
      WHERE object_name(+) = Intface_Method_list_api.Get_Dynamic_Proc_Name(intface_name, execute_seq)
      AND object_type(+) = 'PROCEDURE'
      AND owner(+) = Fnd_Session_API.get_app_owner
      AND intface_name = intface_name_
      AND instr(method_name,'.') != 0;
   --
   -- Record definitions
   stack_     Intface_detail_API.varchar_tabtype;
   rec_       Intface_Detail_API.intdet_record;
   --
   PROCEDURE Get_Method_List_Attrib__ (
      ref_attr_      IN OUT VARCHAR,
      convert_attr_  IN OUT VARCHAR,
      arg_attr_      IN OUT VARCHAR,
      repl_criteria_ IN VARCHAR,
      method_type_   IN VARCHAR,
      seq_           IN NUMBER )
   IS
      CURSOR get_data IS
         SELECT *
         FROM intface_method_list_attrib_tab
         WHERE intface_name = intface_name_
         AND   execute_seq = seq_
         AND   fixed_value IS NOT NULL -- Items marked from Map_Attributes_To_Pos
         ORDER BY column_sequence;
   BEGIN
      Trace_SYS.Message('REPL_CRITERIA : '||repl_criteria_);
      FOR crec_ IN get_data LOOP
         IF ( crec_.flags = 'ARG' ) THEN
               client_sys.add_to_attr(crec_.column_name, crec_.fixed_value, arg_attr_);
         END IF;
         IF ( method_type_ = 'NEW' ) THEN
            IF ( crec_.on_new = 'TRUE' OR crec_.flags in ('P','K') ) THEN
               client_sys.add_to_attr(crec_.column_name, crec_.fixed_value, convert_attr_);
            END IF;
         ELSIF ( method_type_ = 'MODIFY' ) THEN
            IF ( crec_.on_modify = 'TRUE' ) THEN
            client_sys.add_to_attr(crec_.column_name, crec_.fixed_value, convert_attr_);
            END IF;
            IF ( crec_.flags IN ('P','K') ) THEN
               client_sys.add_to_attr(crec_.column_name, crec_.fixed_value, ref_attr_);
         END IF;
         ELSIF ( method_type_ = 'OTHER' ) THEN
            IF ( crec_.flags IN ('P','K') ) THEN
               client_sys.add_to_attr(crec_.column_name, crec_.fixed_value, ref_attr_);
            ELSIF ( crec_.flags != 'ARG' ) THEN
               client_sys.add_to_attr(crec_.column_name, crec_.fixed_value, convert_attr_);
            END IF;
         END IF;
         IF ( ( repl_criteria_ = '1' AND crec_.column_name IN ( 'CONTRACT','CONTRACT_ID','CONTRACT_NO','SITE','CONTRACT_') ) OR
              ( repl_criteria_ = '2' AND crec_.column_name IN ( 'COMPANY','COMPANY_ID','COMPANY_NO','COMPANY_KEY','COMPANY_'))    ) THEN
            IF ( repl_destination_ IS NOT NULL ) THEN
               IF ( crec_.flags IN ('P','K') ) THEN
                  IF ( method_type_ = 'NEW') THEN
                     Client_SYS.Set_Item_Value(crec_.column_name, repl_destination_, convert_attr_);
                  ELSIF ( method_type_ = 'MODIFY' ) THEN
                     Client_SYS.Set_Item_Value(crec_.column_name, repl_destination_, ref_attr_);
                  END IF;
               ELSIF ( crec_.flags = 'ARG' ) THEN
                  Client_SYS.Set_Item_Value(crec_.column_name, repl_destination_, arg_attr_);
               END IF;
            END IF;
         END IF;
      END LOOP;
      --
      -- Make sure there are values in attr-strings
      ref_attr_ := nvl(ref_attr_,'EMPTY');
      arg_attr_ := nvl(arg_attr_,'EMPTY');
      convert_attr_ := nvl(convert_attr_,'EMPTY');
      -- Display them 
      Intface_Detail_API.Trace_Long_Msg(method_type_||' ATTR : '||convert_attr_);
      Intface_Detail_API.Trace_Long_Msg('KEY ATTR : '||ref_attr_);
      Intface_Detail_API.Trace_Long_Msg('ARGUMENT ATTR : '||arg_attr_);
   END Get_Method_List_Attrib__;
   -- Made local procedure for closing all cursors after main loop is finished
   PROCEDURE Close_Cursors__ (cur_count_ IN NUMBER ) IS
   BEGIN
      IF ( h_cur_ != 0 ) THEN
         IF ( DBMS_SQL.Is_Open(h_cur_) ) THEN
            DBMS_SQL.Close_Cursor(h_cur_);
         END IF;
      END IF;
      FOR i IN 1..cur_count_ LOOP
         IF ( dyna_rec_.h_cur(i) !=0 ) THEN
            IF ( DBMS_SQL.Is_Open(dyna_rec_.h_cur(i)) ) THEN
               DBMS_SQL.Close_Cursor(dyna_rec_.h_cur(i));
            END IF;
         END IF;
         IF ( dyna_rec_.upd_cur(i) !=0 ) THEN
            IF ( DBMS_SQL.Is_Open(dyna_rec_.upd_cur(i))) THEN
               DBMS_SQL.Close_Cursor(dyna_rec_.upd_cur(i));
            END IF;
         END IF;
      END LOOP;
   EXCEPTION
      WHEN OTHERS THEN
        Trace_SYS.Message('CLOSE CURSORS FAILED '||SQLERRM);
   END Close_Cursors__;
   
   PROCEDURE Rebuild_Ref_Value___ (
      in_out_val_  IN OUT VARCHAR2,
      row_count_   IN     NUMBER,
      method_mode_ IN     VARCHAR2 )
   IS
      at_pos_       NUMBER;
      seq_          VARCHAR2(100);
      get_item_     VARCHAR2(100);
      ref_value1_    VARCHAR2(2000);
   BEGIN
      ref_value1_ := in_out_val_;
      at_pos_ := instr(ref_value1_,'@');
      seq_ := substr(ref_value1_,at_pos_ +1);
      in_out_val_ := NULL; -- Return NULL when IF-tests within LOOP fails
      FOR i IN 1..dyna_count_ LOOP

         -- For New__/Modify__ there will be two enties for each execute_seq.
         -- Ignore entries with empty return_attr
         IF ( seq_ = to_char(dyna_rec_.execute_seq(i)) AND dyna_rec_.return_attr(i) != 'EMPTY' ) THEN
            IF ( dyna_rec_.on_new_master(i) = 'TRUE' OR dyna_rec_.on_first_row(i) = 'TRUE' OR dyna_rec_.column_name(i) IS NOT NULL  ) THEN
               -- Condition defined for this method
               get_item_ := substr(ref_value1_,1,at_pos_ -1);
               in_out_val_ := Client_SYS.Get_Item_Value(get_item_, dyna_rec_.return_attr(i));
            ELSIF ( method_mode_ IN ('UPDATE','INSERT') AND dyna_rec_.method_mode(i) IN ('UPDATE','INSERT') ) THEN
               -- Method without conditions :
               -- new/modify methods must have match on row_count
               IF ( dyna_rec_.last_row(i) = row_count_ ) THEN
                  get_item_ := substr(ref_value1_,1,at_pos_ -1);
                  in_out_val_ := Client_SYS.Get_Item_Value(get_item_, dyna_rec_.return_attr(i));
               END IF;
            ELSE
               get_item_ := substr(ref_value1_,1,at_pos_ -1);
               in_out_val_ := Client_SYS.Get_Item_Value(get_item_, dyna_rec_.return_attr(i));
            END IF;
            EXIT;
         END IF;
      END LOOP;
   END Rebuild_Ref_Value___;

   PROCEDURE Get_Objid_From_Key_Values___ (
      objid_      IN OUT VARCHAR2,
      objversion_ IN OUT VARCHAR2,
      exec_meth_  IN OUT BOOLEAN,
      ref_attr_   IN OUT VARCHAR2,
      message_    IN OUT VARCHAR2,
      attr_       IN     VARCHAR2,
      row_count_  IN     NUMBER,
      meth_count_ IN     NUMBER,
      meth_mode_  IN     VARCHAR2 )
   IS
      ptr_        NUMBER;
      name_       intface_detail.column_name%TYPE;
      value_      VARCHAR2(32000);
      ref_value2_ VARCHAR2(32000);
      dummy2_     NUMBER;
      j_          NUMBER := 0;
      item_name_  VARCHAR2(200);
   BEGIN
      -- Get key-columns from attr stored in PL/Table stored attr
      WHILE (Client_SYS.Get_Next_From_Attr(dyna_rec_.reference(meth_count_), ptr_, name_, value_)) LOOP
         ref_value2_ := value_;
         IF ( instr(value_,'#') = 1 ) THEN      -- Mapped to pos
            IF ( instr(value_,';') = 0  ) THEN
               ref_value2_ := Client_SYS.Get_Item_Value(value_, attr_);
            ELSE
               value_ := value_||';'; -- To make instr work
               LOOP                   -- LOOP to find values from multiple values
                  IF j_ = 0 THEN
                     item_name_:= substr(value_,0,instr(value_,';',1,j_+1)-1);
                  ELSE
                     item_name_:= substr(value_,instr(value_,';',1,j_)+1,instr(value_,';',1,j_+1) -
                             instr(value_,';',1,j_)-1);
                  END IF;
                  EXIT WHEN item_name_ IS NULL;
                  ref_value2_ := Client_SYS.Get_Item_Value(item_name_, attr_);
                  EXIT WHEN ref_value2_ IS NOT NULL; -- Exit on first occurrence
                  j_ := j_ + 1;
               END LOOP;
            END IF;
         ELSIF ( instr(ref_value2_,'@') != 0  ) THEN
            -- Get values from a previous method
            Rebuild_Ref_Value___(ref_value2_, row_count_, meth_mode_);
         END IF;
         -- Send key-values to cursor
         Trace_SYS.Message('Send key-values to cursor : '||name_||'/'||ref_value2_);
         DBMS_SQL.bind_variable(dyna_rec_.upd_cur(meth_count_),name_,ref_value2_, 32000);
         -- Save values on ref-attr
         Client_SYS.Add_To_Attr( name_, ref_value2_, ref_attr_);
      END LOOP;
      BEGIN
         -- Execute select and get return-values
         dummy2_ := DBMS_SQL.Execute(dyna_rec_.upd_cur(meth_count_));
         DBMS_SQL.variable_value(dyna_rec_.upd_cur(meth_count_),'objid', objid_);
         DBMS_SQL.variable_value(dyna_rec_.upd_cur(meth_count_),'objversion', objversion_);
      EXCEPTION
         WHEN no_data_found THEN
            Trace_SYS.Message('Objid/objversion not found : '||SQLERRM);
            IF ( meth_mode_ = 'OTHER' ) THEN
               exec_meth_ := FALSE;
            END IF;
         WHEN OTHERS THEN
            message_ := SQLERRM;
            Trace_SYS.Message('Get objid/objversion failed : '||SQLERRM);
            IF ( meth_mode_ = 'OTHER' ) THEN
               exec_meth_ := FALSE;
            END IF;
      END;
   END Get_Objid_From_Key_Values___;
   
   PROCEDURE Rebuild_Attr_String___ (
      attr_         IN OUT VARCHAR2,
      source_attr_  IN     VARCHAR2,
      convert_attr_ IN     VARCHAR2,
      view_name_    IN     VARCHAR2,
      row_count_    IN     NUMBER,
      method_mode_  IN     VARCHAR2 )
   IS
      ptr_          NUMBER;
      name_         intface_detail.column_name%TYPE;
      value_        VARCHAR2(2000);
      source_value_ VARCHAR2(2000);
      k_            NUMBER := 0;
      item_name_    VARCHAR2(200);
   BEGIN
      ptr_ := NULL;
      Client_SYS.Clear_Attr(attr_);
      trace_sys.message('REBUILD method_attr for view '||view_name_||' :');
      Intface_Detail_API.Trace_Long_Msg(convert_attr_);
      WHILE (Client_SYS.Get_Next_From_Attr(convert_attr_, ptr_, name_, value_)) LOOP
         source_value_ := NULL;
         IF ( instr(value_,'#') = 1 ) THEN      -- Mapped to pos
            IF ( instr(value_,';') = 0  ) THEN
               source_value_ := Client_SYS.Get_Item_Value(value_, source_attr_);
            ELSE
               value_ := value_||';'; -- To make instr work
               LOOP                   -- LOOP to find values from multiple pos
                  IF k_ = 0 THEN
                     item_name_:= substr(value_,0,instr(value_,';',1,k_+1)-1);
                  ELSE
                     item_name_:= substr(value_,instr(value_,';',1,k_)+1,instr(value_,';',1,k_+1) -
                             instr(value_,';',1,k_)-1);
                  END IF;
                  EXIT WHEN item_name_ IS NULL;
                  source_value_ := Client_SYS.Get_Item_Value(item_name_, source_attr_);
                  EXIT WHEN source_value_ IS NOT NULL; -- Exit on first occurrence
                  k_ := k_ + 1;
               END LOOP;
            END IF;
         ELSE
            -- Value from convert_attr overrides
            source_value_ := value_;
            IF (instr(value_,'@') != 0 ) THEN
               Rebuild_Ref_Value___(source_value_, row_count_ , method_mode_);
            END IF;
         END IF;
         IF ( source_value_ IS NOT NULL ) THEN
            IF ( source_value_ = 'NULLVALUE' AND method_mode_ IN ( 'INSERT', 'ARGUMENTS' )  ) THEN
               NULL; -- Add no empty items on insert-attr and argument-attr
            ELSIF ( source_value_ = 'NULLVALUE' ) THEN
               Client_SYS.Add_To_Attr(name_, '', attr_);
            ELSE
               Client_SYS.Add_To_Attr(name_, source_value_, attr_);
            END IF;
         END IF;
      END LOOP;
      trace_sys.message('REBUILD OUT_attr : ');
      Intface_Detail_API.Trace_Long_Msg(attr_);
   END Rebuild_Attr_String___;
BEGIN
   -- Lookup relevant Rules
   IF ( Intface_Rules_API.Rule_Is_Active(
      rule_string_, 'CHECKOPTION', intface_name_) ) THEN
      action_ := 'CHECK';
   END IF;
   IF ( Intface_Rules_API.Rule_Is_Active(
      rule_string_, 'NONULLVAL', intface_name_) ) THEN
      use_nullvalue_ := NULL;
   END IF;
   IF ( Intface_Header_API.Get_Procedure_Name(intface_name_) = 'REPLICATION') THEN
      replication_   := TRUE;
      intf_repl_rowid_ := App_Context_SYS.Find_Value(Intface_Job_Detail_API.intf_repl_rowid_context_id_);
      repl_criteria_ := Intface_Replic_Criteria_API.Encode(Intface_Header_API.Get_Repl_Criteria(intface_name_)) ;
      repl_mode_     := Intface_Mode_API.Encode(Intface_Header_API.Get_Replication_Mode(intface_name_)) ;
      value_list_    := nvl(Intface_Header_API.Get_Value_List(intface_name_),'NO REPLICATION')||';';
   END IF;
   Change_Job_Context__('SAVE',intface_name_);
   --Create procedures before SAVEPOINTS are defined 
   IF ( Intface_Rules_API.Rule_Is_Active(
      dummy_proc_, 'KEEPDYNAMPROC', intface_name_) ) THEN
      FOR rec2_ IN check_proc LOOP
         -- Only create procedures that have not been created before,
         -- or if status is INVALID
         IF ( rec2_.status IS NULL ) THEN
            Create_One_Dynamic_Proc( intface_name_, rec2_.execute_seq );
         ELSIF ( rec2_.status = 'INVALID' ) THEN
            stmt_ := 'ALTER PROCEDURE '||rec2_.object_name||' COMPILE';
            BEGIN
               @ApproveDynamicStatement(2012-05-07,jhmase)
               EXECUTE IMMEDIATE stmt_;
            EXCEPTION
               WHEN OTHERS THEN NULL; -- May be invalid still
            END;
         END IF;
      END LOOP;
   ELSE
      Create_All_Dynamic_Procs( intface_name_ );
   END IF;
   --
@ApproveTransactionStatement(2014-04-02,mabose)
   SAVEPOINT new_job_;
   --
   -- Update FIXED_VALUE in IntfaceMethodListAttrib temporarily
   -- to mark items that may have value on attr-string.
   -- See also Unmap_Attributes_To_Pos
   Map_Attributes_To_Pos(intface_name_);
   --
   message_start_ := Language_SYS.Translate_Constant(lu_name_, ' TIMESTAMP1 : Start time - :P1   :P2', Fnd_Session_API.Get_Language, start_time_, intface_name_);
   execution_no_  := App_Context_SYS.Find_Number_Value(Intface_Job_Detail_API.intf_execution_no_cid_) -1;
   source_name_   := Intface_Header_API.Get_Source_Name(intface_name_);
   source_owner_  := Intface_Header_API.Get_Source_Owner(intface_name_);
   IF ( source_name_ IS NULL ) THEN
      -- No source specified
      source_specified_ := FALSE;
   END IF;
   -- Lookup relevant Rule
   IF ( Intface_Rules_API.Rule_Is_Active(
           rule_string_, 'ADDOBJID', intface_name_) ) THEN
      add_objid_ := TRUE;
   ELSE
      add_objid_ := FALSE;
   END IF;
   --
   IF ( Intface_Job_Detail_API.Get_Ctx_Val_Intf_Conn_Job IS NOT NULL AND nvl(intf_in_info_,'**') != 'RESTART'  ) THEN
      trace_sys.message('TRACE >>>>>>>>>>>>>>>>>>>>>>> EXECUTING CONNECTED JOBS');
      conn_job1_ := Intface_Job_Detail_API.Get_Ctx_Val_Intf_Conn_Job;
      info_ := 'CONNJOB='||intface_name_;
      BEGIN
         before_stmt_ := 'Begin Intface_Header_API.Start_Job_From_Server(:info,:attr,:exec_plan,:intface_name ); End;';
         @ApproveDynamicStatement(2009-11-27,nabalk)
         EXECUTE IMMEDIATE before_stmt_
         USING IN OUT info_,
               IN OUT attr_,
               IN     exec_plan_,
               IN     conn_job1_;
         --
         message_before_ := info_;
         Intface_Job_Detail_API.Set_Ctx_Val_Intf_Conn_Job_(null_value_);
         Change_Job_Context__('RESTORE',intface_name_);
         IF ( Client_SYS.Get_Item_Value('EXEC_FLAG', attr_) = 'FALSE' ) THEN
            -- Job failed 
@ApproveTransactionStatement(2014-04-02,mabose)
            SAVEPOINT new_job_;
            RAISE no_conn_start_;            
         END IF;
@ApproveTransactionStatement(2014-04-02,mabose)
         COMMIT;
@ApproveTransactionStatement(2014-04-02,mabose)
         SAVEPOINT new_job_; -- Restore savepoint
      EXCEPTION
         WHEN OTHERS THEN
            message_before_ := SQLERRM||msg_sep_;
            methods_before_ok_ := FALSE; -- Patch1
            Intface_Job_Detail_API.Set_Ctx_Val_Intf_Conn_Job_(null_value_);
            Change_Job_Context__('RESTORE',intface_name_);
            RAISE no_conn_start_;
      END;
   END IF;
@ApproveTransactionStatement(2014-04-02,mabose)
   SAVEPOINT new_job_;
   --
   -- Check if there are error lines in IntfaceJobDetail
   OPEN  check_details;
   FETCH check_details INTO check_count_;
      start_ok_ := check_details%NOTFOUND;
   CLOSE check_details;
   --
   IF ( source_owner_ IS NOT NULL ) THEN
      source_name_ := source_owner_||chr(46)||source_name_;
   END IF;
   -- Execute methods to be processed before main loop start.
   -- They have action=1
   trace_sys.message('TRACE >>>>>>>>>>>>>>>>>>>>>>> EXECUTING JOBS BEFORE LOOP');
   FOR brec_ IN Get_Method_List('1') LOOP
@ApproveTransactionStatement(2014-04-02,mabose)
      SAVEPOINT new_method_;
      BEGIN
         header_message_ := Language_SYS.Translate_Constant(lu_name_, ' HEADMSG : EXECUTING METHOD NO. :P1 : ', Fnd_Session_API.Get_Language, to_char(brec_.execute_seq));
         IF ( message_before_ IS NULL ) THEN
            message_before_ := header_message_||msg_sep_||'       ';
         ELSE
            message_before_ := message_before_||msg_sep_||msg_sep_||header_message_||msg_sep_||'       ';
         END IF;
         Client_SYS.Clear_Attr(parse_attr_);
         Get_Method_List_Attrib__ ( ref_attr_, convert_attr_ ,parse_attr_, 
                                   '0', 'BEFORE_LOOP', brec_.execute_seq );
            Intface_Detail_API.Trace_Long_Msg('Parse_Attr '||parse_attr_);
         IF ( instr(upper(brec_.method_name),'INTFACE_HEADER_API.START_JOB') != 0 ) THEN
            parse_intface_name_ := Client_SYS.Get_Item_Value('INTFACE_NAME_', parse_attr_);
            -- This starts another migration job
            IF ( parse_intface_name_ IS NULL ) THEN
               message_before_ := message_before_||Language_SYS.Translate_Constant(lu_name_, ' NONAME : Value for Job ID is missing on attr-string for method no. :P1 ', Fnd_Session_API.Get_Language, to_char(brec_.execute_seq));
               RAISE no_execute_ ;
            ELSIF ( parse_intface_name_ = intface_name_ ) THEN
               message_before_ := message_before_||Language_SYS.Translate_Constant(lu_name_, ' DUPNAME : Method no. :P1 - Value for Job ID cannot be equal to main job  ', Fnd_Session_API.Get_Language, to_char(brec_.execute_seq));
               RAISE no_execute_ ;
            END IF;
         END IF;
         -- May contain hardcoded value:
         info_ := Client_SYS.Get_Item_Value('INFO_', parse_attr_);
         -- Execute procedure
         Client_SYS.Clear_Attr(attr_);
         Execute_Dynamic_Proc ( info_,
                                objid_,      -- Dummy 
                                objversion_, -- Dummy 
                                attr_,       -- Dummy 
                                parse_attr_,
                                'DO',        --Action 
                                Get_Dynamic_Proc_Name( intface_name_, brec_.execute_seq ));
         IF ( Client_SYS.Get_Item_Value('EXEC_FLAG', attr_) = 'FALSE' ) THEN
            -- Job failed 
@ApproveTransactionStatement(2014-04-02,mabose)
            SAVEPOINT new_method_;
            RAISE no_execute_;            
         END IF;
         info_ := nvl(info_, Language_SYS.Translate_Constant(lu_name_, ' EXEOK :  Executed without error ', Fnd_Session_API.Get_Language));
      EXCEPTION
         WHEN no_execute_ THEN
            Change_Job_Context__('RESTORE',intface_name_); -- Restore global variables from Load_Intface_Info
            Trace_SYS.Message(' Get_Method_List no_execute_');
            methods_before_ok_ := FALSE;
            IF ( NOT intf_ignorexeerror_ ) THEN
               message_before_ := message_before_||msg_sep_||SQLERRM;
               RAISE method_error_after_;
            ELSE
@ApproveTransactionStatement(2014-04-02,mabose)
               ROLLBACK TO SAVEPOINT new_method_;
               message_before_ := message_before_||msg_sep_||SQLERRM;
            END IF;
         WHEN OTHERS THEN
            Change_Job_Context__('RESTORE',intface_name_); -- Restore global variables from Load_Intface_Info
            Trace_SYS.Message('Get_Method_List OTHERS');
            methods_before_ok_ := FALSE;
            IF ( NOT intf_ignorexeerror_ ) THEN
               message_before_ := message_before_||msg_sep_||SQLERRM;
               RAISE method_error_after_;
            ELSE
@ApproveTransactionStatement(2014-04-02,mabose)
               ROLLBACK TO SAVEPOINT new_method_;
               message_before_ := message_before_||msg_sep_||SQLERRM;
            END IF;
      END;
      -- Info variable may contain returnvalue from procedure
      -- or errormessage from EXCEPTION. Save info for each turn in loop.
      IF ( info_ IS NOT NULL ) THEN
         message_before_ := message_before_||msg_sep_||info_;
      END IF;
      info_ := NULL;
      parse_info_ := NULL;
      parse_intface_name_ := NULL;
      Change_Job_Context__('RESTORE',intface_name_);
   END LOOP;
   -- This flag may have been set to FALSE by preceeding filejobs. Reset it here
   App_Context_SYS.Set_Value(Intface_Job_Detail_API.intf_no_file_context_id_,TRUE);
   --
   IF ( source_specified_ ) THEN
   -- Make this IF-test to avoid error-messages if no selection has bee specified.
   -- The job may contain methods that shoud be executed 'BeforeLoop' or 'AfterLoop'.
   trace_sys.message('TRACE >>>>>>>>>>>>>>>>>>>>>>> BUILDING SELECT STATEMENT');
   --
   -- Now we start to build the main selection,
   -- and first we make a column-list based on Intface_Details SOURCE_COLUMN and DEFAULT_VALUE
   -- We also save COLUMN_NAME in a PL/SQL-table (rec_)
   -- for use later when we build the main attr-string
   FOR x IN Get_Columns LOOP
      -- The first key items in list are 'master' keys
      IF (x.flags NOT IN ('P','K') ) THEN
         new_master_ := FALSE;
      END IF;
      cols_value_ := NULL;
      IF ( x.source_column IS NULL ) THEN
         cols_value_ := x.default_value;
      ELSIF ( x.default_value IS NOT NULL ) THEN
         cols_value_ := 'nvl('||x.source_column||','||x.default_value||')';
      ELSE
         cols_value_ := x.source_column;
      END IF;
      --
      IF ( x.data_type = 'DATE') THEN
         -- Format dates to char values
         cols_value_ := date_format_start_||cols_value_||date_format_end_;
      END IF;
      IF ( x.column_name = 'OBJID' ) THEN
         rowid_name_ := cols_value_;
      ELSE
         cols_  := cols_ || cols_value_|| ', ';
         count_ := count_ + 1;
         rec_.cols_(count_) := x.column_name;
         rec_.pos_(count_) := x.pos;
         rec_.conv_list_id_(count_) := x.conv_list_id ;
         -- Mark items
         IF ( new_master_ ) THEN
            -- Mark items that are 'master' keys
            rec_.data_type_(count_) := 'MASTER' ;
         ELSE
            rec_.data_type_(count_) := 'NOMASTER' ;
         END IF;
      END IF;
   END LOOP;
   -- Add OBJID/rowid to select list if we have any + put it in PL/SQL table
   -- In this way we always make sure OBJID is last column in select list
   IF ( rowid_name_ IS NOT NULL ) THEN
      rowid_count_ := count_ +1; -- We have to keep track of number of columns both
                                 -- with and without rowid
      rec_.cols_(rowid_count_)      := upper(rowid_name_);
      cols_ := cols_||rowid_name_;
   ELSE
      IF ( add_objid_) THEN
         -- OBJID should be part of select when rule is active
         message_select_ := Language_SYS.Translate_Constant(lu_name_, ' NOOBJID : OBJID not in select, but Rule ADDOBJID is active ', Fnd_Session_API.Get_Language );
         RAISE no_start_;
      ELSE
         rowid_count_ := count_;
         cols_ := rtrim(rtrim(cols_,' '),',');
      END IF;
   END IF;
   --
   IF ( replication_ AND repl_mode_  IN ('2','3') ) THEN
      log_seq_count_ := rowid_count_ +1;
      rec_.cols_(log_seq_count_) := 'IRL.LOG_SEQ';
      cols_ := cols_||', IRL.LOG_SEQ';
      stmt_ := 'SELECT ' || cols_ || ' FROM ' || source_name_||' tbl,Intface_Replication_Log_tab irl' ;
   ELSE
      stmt_ := 'SELECT ' || cols_ || ' FROM ' || source_name_ ;
   END IF;

   --
   message_select_ := Language_SYS.Translate_Constant(lu_name_, ' INCOMPLSELECT : Incomplete select not executed  -  :P1 ', Fnd_Session_API.Get_Language, substr(stmt_,length(stmt_)-1900) );
   IF ( cols_ IS NULL OR source_name_ IS NULL ) THEN
      IF ( cols_ IS NOT NULL OR source_name_ IS NOT NULL ) THEN
         NULL ; -- OK
      ELSE
         message_select_ := Language_SYS.Translate_Constant(lu_name_, ' NOSELECT : No select specified  ', Fnd_Session_API.Get_Language);
      END IF;
      RAISE incomplete_select_;
   END IF;
   --
   -- Add where-clause to main select.
   --
   IF ( nvl(intf_in_info_,'**') = 'RESTART' AND rowid_name_ IS NOT NULL ) THEN
      -- IF this is a restarted job, and we have rowid on source, we
      -- should select only rows with errors from Intface_Job_History,
      -- so we make a sub-query from this table
      --
      IF ( instr(Intface_Header_API.Get_Source_Name(intface_name_),',') != 0 ) THEN
         -- This is a JOIN, keep original WHERE + add subquery
         where_ := Intface_Header_API.Get_Complete_Where(intface_name_)||
                ' AND '||rowid_name_||' IN (select source_rowid from intface_job_hist_detail_tab'||
                                             ' where intface_name = '||''''||intface_name_||''''||
                                             ' and execution_no = '||execution_no_||')';
      ELSE
      where_ := ' WHERE '||rowid_name_||' IN (select source_rowid from intface_job_hist_detail_tab'||
                                             ' where intface_name = '||''''||intface_name_||''''||
                                             ' and execution_no = '||execution_no_||')';
      END IF;
      --
   ELSIF ( nvl(intf_in_info_,'**') = 'RESTART' AND rowid_name_ IS NULL ) THEN
      -- Automatic restart is not possible
      message_select_ := Language_SYS.Translate_Constant(lu_name_, ' NORESTART : Restart impossible - :P1 contains no rowid ', Fnd_Session_API.Get_Language, source_name_ );
      RAISE no_restart_;
   ELSIF ( start_ok_ ) THEN
      -- No error lines in IntfaceJobDetail
      -- Make standard where
      where_ := Intface_Header_API.Get_Complete_Where(intface_name_);
   ELSE
      -- There are error lines in IntfaceJobDetail, end job
      message_select_ := Language_SYS.Translate_Constant(lu_name_, ' NOSTART : :P1 have :P2 error lines and cannot be started ', Fnd_Session_API.Get_Language, intface_name_, to_char(check_count_));
      RAISE no_start_;
   END IF;

   IF ( replication_ AND repl_mode_  IN ('2','3') ) THEN
      
      IF ( repl_mode_ = '2' ) THEN
         -- Mode = Automatic, i.e. process transactions in same order as they occurred
         OPEN get_min_log_seq(intf_repl_rowid_);
         FETCH get_min_log_seq INTO log_seq_;
         CLOSE get_min_log_seq;
      ELSE
         -- Mode = Batch, process all occurrences since last job-execution 
         OPEN get_max_log_seq;
         FETCH get_max_log_seq INTO log_seq_;
         CLOSE get_max_log_seq;
      END IF;
      where_ := Intface_Header_API.Get_Complete_Where(intface_name_);
      IF ( where_ IS NULL ) THEN
          where_ :=  ' WHERE tbl.objid = irl.repl_rowid' ||
               ' and irl.intface_name = :intface_name ' ||
                    ' AND irl.log_seq <= :log_seq' ||
                  ' and tbl.objid = nvl(:repl_rowid ,tbl.objid) ';
      ELSE
          where_ := where_|| ' AND tbl.objid = irl.repl_rowid' ||
               ' and irl.intface_name = :intface_name ' ||
                    ' AND irl.log_seq <= :log_seq' ||
                  ' and tbl.objid = nvl(:repl_rowid ,tbl.objid) ';
      END IF;
   END IF;

   --
   stmt_ := stmt_ || where_;
   --
   -- Finally, add group_by and order-by clause to statement
   --
   group_by_ := Intface_Header_API.Get_Group_By_Clause(intface_name_);
   IF ( group_by_ IS NOT NULL) THEN
      group_by_ := ' GROUP BY '||group_by_;
      stmt_ := stmt_ || group_by_;
   END IF;
   order_by_ := Intface_Header_API.Get_Order_By_Clause(intface_name_);
   IF ( replication_ AND repl_mode_  IN ('2','3') ) THEN
      IF  ( order_by_ IS NOT NULL) THEN
         order_by_ := order_by_ || ',';
      END IF;
      order_by_ := order_by_ ||'irl.log_seq';
   END IF;
   IF ( order_by_ IS NOT NULL) THEN
      stmt_ := stmt_ || ' ORDER BY '|| order_by_;
   END IF;
   --
   -- Save statement, except for column list . Used in building info-variable later
   -- Make newline before FROM and WHERE
   --
   message_select_ := Language_SYS.Translate_Constant(lu_name_, ' SELECTSTMT : Created select  :  ', Fnd_Session_API.Get_Language)||
                      msg_sep_||replace(replace(substr(stmt_,instr(upper(stmt_),' FROM ')),'FROM',msg_sep_||'FROM'),'WHERE',msg_sep_||'WHERE') ;
   --
   h_cur_ := 0;   -- Dummyvalue, replaced further down
   --
   -- Open cursor and parse main select statement
   h_cur_ := DBMS_SQL.Open_Cursor;
   Intface_Detail_API.Trace_Long_Msg(stmt_);
   BEGIN
      @ApproveDynamicStatement(2011-05-19,jhmase)
      DBMS_SQL.Parse(h_cur_, stmt_, DBMS_SQL.native);

      IF ( replication_ AND repl_mode_  IN ('2','3') ) THEN
            DBMS_SQL.bind_variable(h_cur_,'intface_name', intface_name_, 2000);
            DBMS_SQL.bind_variable(h_cur_,'log_seq', log_seq_, 2000);
            DBMS_SQL.bind_variable(h_cur_,'repl_rowid', intf_repl_rowid_, 2000);
      END IF;
   EXCEPTION
      WHEN OTHERS THEN
         Trace_SYS.Message('PARSE FAILED '||SQLERRM);
         Intface_Detail_API.Trace_Long_Msg(stmt_);
         message_select_ := Language_SYS.Translate_Constant(lu_name_, ' SELECTSTMT : Error in  select  :P1 - :P2 ', Fnd_Session_API.Get_Language, null , substr(SQLERRM,1,1950));
         RAISE no_start_;
   END;
   -- Execute as many Define_Columns as we have selected columns.
   -- These get a number in the 'Stack' and we fetch the return-value
   -- in the main select loop further down
   IF ( replication_ AND repl_mode_  IN ('2','3') ) THEN
      FOR i IN 1..log_seq_count_ LOOP
         stack_(i) := NULL;
         DBMS_SQL.Define_Column(h_cur_, i, stack_(i), 2000);
      END LOOP;
   ELSE
      FOR i IN 1..rowid_count_ LOOP
         stack_(i) := NULL;
         DBMS_SQL.Define_Column(h_cur_, i, stack_(i), 2000);
      END LOOP;
   END IF;
   --
   -- Now, the main select is ready to be executed, but first we fetch
   -- all methods in Intface_Method_List with action=2, put them in a PL/SQL table,
   -- open a cursor and parse each statement. This is done before looping on main selection
   -- to avoid parsing within this loop.
   -- IF this is a standard new method, we also send in the values for
   -- info, objid and objversion, because they have the same in-value(NULL) each time
   --
   trace_sys.message('TRACE >>>>>>>>>>>>>>>>>>>>>>> BUILDING DYNAMIC PL-TABLE');
   BEGIN
   dyna_count_ := 0;
   LOOP
      IF i_ = 0 THEN
         repl_destination_:= substr(value_list_,0,instr(value_list_,';',1,i_+1)-1);
      ELSE
         repl_destination_:= substr(value_list_,instr(value_list_,';',1,i_)+1,instr(value_list_,';',1,i_+1) -
                 instr(value_list_,';',1,i_)-1);
      END IF;
      EXIT WHEN repl_destination_ IS NULL;
      Trace_SYS.Message(i_||'   '||repl_destination_||'   '||length(repl_destination_));
      i_ := i_ + 1;
      IF ( repl_destination_ = 'NO REPLICATION' ) THEN
         repl_destination_ := NULL;
      END IF;
      FOR drec_ IN Get_Method_List('2') LOOP
         -- Put methods to be executed in a PL/SQL-table (dyna_rec_).
         -- dyna_count_ := get_method_list%ROWCOUNT;
         -- Creates convert_attr and reference
         Client_SYS.Clear_Attr(ref_attr_);
         Client_SYS.Clear_Attr(convert_attr_);
         Client_SYS.Clear_Attr(arg_attr_);
         -- Save original view name by trimming off extensions (if any)
         dyna_view_ := drec_.view_name;
         IF ( drec_.prefix_option = '2' ) THEN
            -- Trim off execute_seq from end of view_name
            exec_seq_ := to_char(drec_.execute_seq);
            IF substr(drec_.view_name, length(drec_.view_name) - length(exec_seq_) + 1, length(exec_seq_)) = exec_seq_ THEN
               dyna_view_ := substr(drec_.view_name,1, length(drec_.view_name) - length(exec_seq_));
            END IF;
         END IF;
         Trace_SYS.Message('TRACE >>>>>>>>>>>>>>>>>>>>>>> Exec_Seq_'||drec_.execute_seq);
         -- Set common PL/TABLE values
         IF ( drec_.on_modify = 'TRUE' AND drec_.method_type != 'OTHER') THEN
            -- Standard Modify__ method
            -- Build attribute variables
            Get_Method_List_Attrib__ ( ref_attr_, convert_attr_ ,arg_attr_, 
                                      repl_criteria_, 'MODIFY' , drec_.execute_seq );
            -- .. and load info into dynamic table 
            dyna_count_ := dyna_count_ + 1;
         dyna_rec_.on_new_master(dyna_count_) := drec_.on_new_master;
         dyna_rec_.on_first_row(dyna_count_) := drec_.on_first_row;
         dyna_rec_.column_name(dyna_count_) := drec_.column_name;
         dyna_rec_.column_value(dyna_count_) := drec_.column_value;
         dyna_rec_.error_count(dyna_count_) := 0 ;
         dyna_rec_.incomplete_count(dyna_count_) := 0 ;
         dyna_rec_.commit_count(dyna_count_) := 0 ;
         dyna_rec_.last_row(dyna_count_) := 0 ;
         dyna_rec_.execute_seq(dyna_count_) := drec_.execute_seq;
         dyna_rec_.view_name(dyna_count_) := drec_.view_name;
         dyna_rec_.upd_cur(dyna_count_) := 0; -- Dummyvalue, replaced further down
         dyna_rec_.h_cur(dyna_count_) := 0;   -- Dummyvalue, replaced further down
         dyna_rec_.orig_view_name(dyna_count_) := drec_.view_name;
         dyna_rec_.return_attr(dyna_count_) := 'EMPTY';
            dyna_rec_.attr(dyna_count_) := convert_attr_;
            dyna_stmt_ := 'Begin '||drec_.method_name||'.MODIFY__(:info,:objid,:objversion,:attr, :action ); End;';
            dyna_rec_.method(dyna_count_) := dyna_stmt_;
            dyna_rec_.method_mode(dyna_count_)    := 'UPDATE';
            dyna_rec_.reference(dyna_count_)      := ref_attr_;
            dyna_rec_.h_cur(dyna_count_)          := DBMS_SQL.Open_Cursor;
            method_h_isopen_                      := TRUE;
            -- Parse statement and keep cursor
            @ApproveDynamicStatement(2011-05-19,jhmase)
            DBMS_SQL.Parse(dyna_rec_.h_cur(dyna_count_), dyna_rec_.method(dyna_count_), DBMS_SQL.native);
            DBMS_SQL.bind_variable(dyna_rec_.h_cur(dyna_count_),'info', info_, 2000);
            DBMS_SQL.bind_variable(dyna_rec_.h_cur(dyna_count_),'objid', objid_, 2000);
            DBMS_SQL.bind_variable(dyna_rec_.h_cur(dyna_count_),'objversion', objversion_, 2000);
            DBMS_SQL.bind_variable(dyna_rec_.h_cur(dyna_count_),'attr', return_attr_, 32000);
            DBMS_SQL.bind_variable(dyna_rec_.h_cur(dyna_count_),'action', action_, 2000);
            --
            IF ( ref_attr_ IS NOT NULL ) THEN
               -- Also parse select for getting objid, objversion
               Intface_Method_List_API.Build_Get_Objid_Stmt__ ( upd_stmt_, dyna_view_,date_format_, ref_attr_);
               Intface_Detail_API.Trace_Long_Msg('Get_Objid_Stmt '||upd_stmt_);
               -- Parse select-statement
               dyna_rec_.upd_cur(dyna_count_) := DBMS_SQL.Open_Cursor;
               method_upd_isopen_ := TRUE;
               -- Safe due to appending values are not directly exposed to user inputs
               @ApproveDynamicStatement(2009-11-27,nabalk)
               DBMS_SQL.Parse(dyna_rec_.upd_cur(dyna_count_), upd_stmt_ , DBMS_SQL.native);
               DBMS_SQL.bind_variable(dyna_rec_.upd_cur(dyna_count_),'objid', objid_, 2000);
               DBMS_SQL.bind_variable(dyna_rec_.upd_cur(dyna_count_),'objversion', objversion_, 2000);
            END IF;
            IF ( repl_destination_ IS NOT NULL ) THEN
               dyna_rec_.repl_key(dyna_count_) := Intface_Replic_Criteria_API.Decode(repl_criteria_)||' '||repl_destination_||' : ';
            ELSE
               dyna_rec_.repl_key(dyna_count_) := ' ';
            END IF;
         END IF;
         IF ( drec_.on_new = 'TRUE' ) THEN
            -- Standard New__ method
            Trace_SYS.Message('NEW');
            Client_SYS.Clear_Attr(ref_attr_);
            Client_SYS.Clear_Attr(convert_attr_);
            -- Build attribute variables 
            Get_Method_List_Attrib__( ref_attr_, convert_attr_ ,arg_attr_, 
                                      repl_criteria_, 'NEW', drec_.execute_seq );
            -- .. and load info into dynamic table 
            dyna_count_ := dyna_count_ + 1;
            dyna_rec_.on_new_master(dyna_count_) := drec_.on_new_master;
            dyna_rec_.on_first_row(dyna_count_) := drec_.on_first_row;
            dyna_rec_.column_name(dyna_count_) := drec_.column_name;
            dyna_rec_.column_value(dyna_count_) := drec_.column_value;
            dyna_rec_.error_count(dyna_count_) := 0 ;
            dyna_rec_.incomplete_count(dyna_count_) := 0 ;
            dyna_rec_.commit_count(dyna_count_) := 0 ;
            dyna_rec_.last_row(dyna_count_) := 0 ;
            dyna_rec_.execute_seq(dyna_count_) := drec_.execute_seq;
            dyna_rec_.view_name(dyna_count_) := drec_.view_name;
            dyna_rec_.upd_cur(dyna_count_) := 0; -- Dummyvalue, replaced further down
            dyna_rec_.h_cur(dyna_count_) := 0;   -- Dummyvalue, replaced further down
            dyna_rec_.orig_view_name(dyna_count_) := drec_.view_name;
            dyna_rec_.return_attr(dyna_count_) := 'EMPTY';
            dyna_rec_.attr(dyna_count_) := convert_attr_;
            dyna_stmt_ := 'Begin '||drec_.method_name||'.NEW__(:info,:objid,:objversion,:attr, :action ); End;';
            dyna_rec_.method(dyna_count_) := dyna_stmt_;
            dyna_rec_.method_mode(dyna_count_) := 'INSERT';
            dyna_rec_.h_cur(dyna_count_) := DBMS_SQL.Open_Cursor;
            method_h_isopen_ := TRUE;
            @ApproveDynamicStatement(2011-05-19,jhmase)
            DBMS_SQL.Parse(dyna_rec_.h_cur(dyna_count_), dyna_rec_.method(dyna_count_), DBMS_SQL.native);
            DBMS_SQL.bind_variable(dyna_rec_.h_cur(dyna_count_),'info', info_, 2000);
            DBMS_SQL.bind_variable(dyna_rec_.h_cur(dyna_count_),'objid', objid_, 2000);
            DBMS_SQL.bind_variable(dyna_rec_.h_cur(dyna_count_),'objversion', objversion_, 2000);
            DBMS_SQL.bind_variable(dyna_rec_.h_cur(dyna_count_),'attr', return_attr_, 32000);
            DBMS_SQL.bind_variable(dyna_rec_.h_cur(dyna_count_),'action', action_, 2000);
            IF ( repl_destination_ IS NOT NULL ) THEN
               dyna_rec_.repl_key(dyna_count_) := Intface_Replic_Criteria_API.Decode(repl_criteria_)||' '||repl_destination_||' : ';
            ELSE
               dyna_rec_.repl_key(dyna_count_) := ' ';
            END IF;
         END IF;
         IF ( drec_.method_type = 'OTHER' ) THEN
            -- Any other method.
            -- Build attr-strings...
            Get_Method_List_Attrib__ ( ref_attr_, convert_attr_ ,arg_attr_, 
                                      repl_criteria_, drec_.method_type, drec_.execute_seq );
            -- .. and load info into dynamic table 
            dyna_count_ := dyna_count_ + 1;
            dyna_rec_.on_new_master(dyna_count_) := drec_.on_new_master;
            dyna_rec_.on_first_row(dyna_count_) := drec_.on_first_row;
            dyna_rec_.column_name(dyna_count_) := drec_.column_name;
            dyna_rec_.column_value(dyna_count_) := drec_.column_value;
            dyna_rec_.error_count(dyna_count_) := 0 ;
            dyna_rec_.incomplete_count(dyna_count_) := 0 ;
            dyna_rec_.commit_count(dyna_count_) := 0 ;
            dyna_rec_.last_row(dyna_count_) := 0 ;
            dyna_rec_.execute_seq(dyna_count_) := drec_.execute_seq;
            dyna_rec_.view_name(dyna_count_) := drec_.view_name;
            dyna_rec_.upd_cur(dyna_count_) := 0; -- Dummyvalue, replaced further down
            dyna_rec_.h_cur(dyna_count_) := 0;   -- Dummyvalue, replaced further down
            dyna_rec_.orig_view_name(dyna_count_) := drec_.view_name;
            dyna_rec_.return_attr(dyna_count_) := 'EMPTY';
            dyna_rec_.method_mode(dyna_count_) := 'OTHER';
            dyna_stmt_ := 'Begin '||Intface_Method_List_API.Get_Dynamic_Proc_Name(intface_name_, drec_.execute_seq)||
                           '(:info,:objid,:objversion,:attr,:arg_attr,:action); End;';
            dyna_rec_.method(dyna_count_) := dyna_stmt_;
            dyna_rec_.attr(dyna_count_) := convert_attr_;
            dyna_rec_.reference(dyna_count_) := ref_attr_;
            dyna_rec_.arg_attr(dyna_count_) := arg_attr_;
            dyna_rec_.h_cur(dyna_count_) := DBMS_SQL.Open_Cursor;
            method_h_isopen_ := TRUE;
            @ApproveDynamicStatement(2011-05-19,jhmase)
            DBMS_SQL.Parse(dyna_rec_.h_cur(dyna_count_), dyna_rec_.method(dyna_count_), DBMS_SQL.native);
            DBMS_SQL.bind_variable(dyna_rec_.h_cur(dyna_count_),'info', info_, 2000);
            IF ( drec_.on_modify = 'TRUE' AND ref_attr_ IS NOT NULL ) THEN
               -- Also parse select for getting objid, objversion
               Intface_Method_List_API.Build_Get_Objid_Stmt__ ( upd_stmt_, dyna_view_,date_format_, ref_attr_);
               Intface_Detail_API.Trace_Long_Msg('Get_Objid_Stmt '||upd_stmt_);
               -- Parse select-statement
               dyna_rec_.upd_cur(dyna_count_) := DBMS_SQL.Open_Cursor;
               method_upd_isopen_ := TRUE;
               -- Safe due to appending values are not directly exposed to user inputs
               @ApproveDynamicStatement(2009-11-27,nabalk)
               DBMS_SQL.Parse(dyna_rec_.upd_cur(dyna_count_), upd_stmt_ , DBMS_SQL.native);
               DBMS_SQL.bind_variable(dyna_rec_.upd_cur(dyna_count_),'objid', objid_, 2000);
               DBMS_SQL.bind_variable(dyna_rec_.upd_cur(dyna_count_),'objversion', objversion_, 2000);
            END IF;
         END IF;
         Trace_SYS.Message('dyna_stmt_'||dyna_stmt_);
         Trace_SYS.Message('dyna_rec_.upd_cur(dyna_count_)'||dyna_rec_.upd_cur(dyna_count_));
         dyna_stmt_ := NULL;
         upd_stmt_ := NULL;
      END LOOP;
   END LOOP;
   start_ := SYSDATE;
   EXCEPTION
      WHEN OTHERS THEN
         Trace_SYS.Message('PARSE METHODS FAILED '||SQLERRM);
         message_method_ := substr(dyna_stmt_||' - '||SQLERRM,1,2000);
         Trace_SYS.Message('ROLLBACK to SAVEPOINT new_job_') ;
@ApproveTransactionStatement(2014-04-02,mabose)
         ROLLBACK to SAVEPOINT new_job_;
         RAISE method_error_;
   END;
   -- Reset attribute mappings
   Unmap_Attributes_To_Pos(intface_name_);
   -- Commit unfinished transactions before executing cursor
@ApproveTransactionStatement(2014-04-02,mabose)
   COMMIT;
@ApproveTransactionStatement(2014-04-02,mabose)
   SAVEPOINT new_job_;
   END IF;
   -- Execute main selection only if there are methods to be executed
   IF ( method_upd_isopen_ OR method_h_isopen_ ) THEN
      BEGIN
         -- Check for errors
         dummy_ := DBMS_SQL.Execute(h_cur_);
      EXCEPTION
         WHEN OTHERS THEN
            Trace_SYS.Message('EXECUTE MAIN  FAILED '||SQLERRM);
            message_select_ := stmt_||msg_sep_||msg_sep_|| SQLERRM;
@ApproveTransactionStatement(2014-04-02,mabose)
            ROLLBACK TO SAVEPOINT new_job_;
            RAISE no_start_;
      END;
      trace_sys.message('TRACE >>>>>>>>>>>>>>>>>>>>>>> START FETCHING DATA FROM SELECT');
      LOOP -- Start SELECT loop
@ApproveTransactionStatement(2014-04-02,mabose)
         SAVEPOINT new_row_;
         BEGIN
            -- Check for errors
            IF (DBMS_SQL.Fetch_Rows(h_cur_) = 0) THEN
               EXIT;
           END IF;
         EXCEPTION
            WHEN OTHERS THEN
               Trace_SYS.Message('FETCH ROWS  FAILED '||SQLERRM);
               message_select_ := stmt_||msg_sep_||msg_sep_|| SQLERRM;
@ApproveTransactionStatement(2014-04-02,mabose)
               ROLLBACK TO SAVEPOINT new_job_;
               RAISE no_start_;
         END;
         -- Start to fetch return-values from main selection
         -- keep track of number rows read
         row_count_ := row_count_ + 1;
         commit_seq_ := commit_seq_ + 1;
         Trace_SYS.Message('DBMS_SQL.Fetch_row_ '||to_char(row_count_)) ;
         -- Empty variables that are used only within each row
         attr_             := NULL;
         master_key_value_ := NULL;
         old_seq_          := NULL;
         ref_value_        := NULL;
         --
         IF ( App_Context_SYS.Find_Number_Value(Intface_Job_Detail_API.intf_skip_lines_cid_) >= row_count_ ) THEN
            -- Rule SKIPLINES is active
            NULL;
         ELSIF ( App_Context_SYS.Find_Number_Value(Intface_Job_Detail_API.intf_exit_lines_cid_) < row_count_ ) THEN
            -- Rule EXITLINES is active
            EXIT;
         ELSE
            --
            -- Get defined columns from selection
            FOR i IN 1..count_ LOOP
               -- For each selected row, we find values in the 'Stack' and match
               -- them with COLUMN_NAME that we have saved in PL/SQL-table
               DBMS_SQL.Column_Value(h_cur_, i, stack_(i));
               column_value_ := nvl(stack_(i),use_nullvalue_);
               -- Use hash + pos to name items on attr
               -- Map_Attributes_To_Pos has already marked items 
               -- on dyna_rec_.attr with this item (in fixed_value),
               -- and Rebuild_Attr_String will perform faster
               column_name_  := '#'||rec_.pos_(i);
               conv_list_id_ := rec_.conv_list_id_(i);
               IF ( conv_list_id_ IS NOT NULL ) THEN
                  -- Convert values for this column
                  BEGIN
                     convert_value_ := NULL;
                     convert_value_ := Intface_Conv_List_Cols_API.Get_New_Value(conv_list_id_ ,column_value_ );
                     column_value_ := nvl(convert_value_, column_value_);
                  EXCEPTION
                     WHEN OTHERS THEN
                        message_method_ := substr(SQLERRM,1,2000);
                  END;
               END IF;
               client_sys.add_to_attr(column_name_ , column_value_, attr_);
               IF ( rec_.data_type_(i) = 'MASTER' ) THEN
                  -- Save value og master item
                  master_key_value_ := master_key_value_||column_value_||';';
               END IF;
            END LOOP;
            Trace_SYS.Message('After column LOOP, SELECT attr_ :');
            Intface_Detail_API.Trace_Long_Msg(attr_);
            IF ( replication_ AND repl_mode_  IN ('2','3') ) THEN
               DBMS_SQL.Column_Value(h_cur_, log_seq_count_, stack_(log_seq_count_));
               cur_log_seq_ := stack_(log_seq_count_);
               Trace_SYS.Message('Log_seq: '||cur_log_seq_);
               DELETE fROM Intface_Replication_Log_TAB
               WHERE  log_seq = cur_log_seq_;
               Trace_SYS.Message('After delete');
            END IF;
            IF ( nvl(old_master_value_,'x$x$') != master_key_value_ ) THEN
               -- Check if this is a new master record
               client_sys.add_to_attr( 'NEW_MASTER', 'TRUE', attr_);
               new_master_ := TRUE;
            ELSE
               client_sys.add_to_attr( 'NEW_MASTER', 'FALSE', attr_);
               new_master_ := FALSE;
            END IF;
            Trace_SYS.Message('MASTER Key '||master_key_value_);
            old_master_value_ := master_key_value_;
            --
            first_row_ := FALSE;
            IF ( row_count_ = 1 ) THEN
               first_row_ := TRUE;
            END IF;
            IF ( count_ != rowid_count_ ) THEN
               -- Save value of rowid. To be used in error-handling
               DBMS_SQL.Column_Value(h_cur_, rowid_count_, stack_(rowid_count_));
               source_rowid_ := stack_(rowid_count_);
            END IF;
            -- Now we have built an attr-string, then loop on defined methods,
@ApproveTransactionStatement(2014-04-02,mabose)
            SAVEPOINT new_method_;
            trace_sys.message('TRACE >>>>>>>>>>>>>>>>>>>>>>> EXECUTE METHOD LIST');
            Trace_SYS.Message('Dyna count_ '||dyna_count_);
            FOR i IN 1..dyna_count_ LOOP -- Start method loop
               trace_sys.message('TRACE >>>>>>>>>>>>>>>>>>>>>>> Checking method no.'||dyna_rec_.execute_seq(i)) ;
               Trace_SYS.Message('Method MODE '||dyna_rec_.method_mode(i)) ;
@ApproveTransactionStatement(2014-04-02,mabose)
               SAVEPOINT new_repl_;
               IF ( replication_ ) THEN
                   row_err_count_ := row_err_count_ + 1;
               ELSE
                   row_err_count_ := row_count_;
               END IF;
               ref_attr_ := NULL;
               arg_attr_ := NULL;
               return_attr_ := NULL;
               dyna_attr_ := NULL;
               second_method_ := FALSE;
               IF ( dyna_rec_.method_mode(i) IN ( 'INSERT','UPDATE' ) ) THEN
                  -- Rebuild attr moved further down.
                  IF ( nvl(old_seq_,-1) = dyna_rec_.execute_seq(i)) THEN
                     -- Find out if this is method #1 or #2.
                     second_method_ := TRUE;
                  END IF;
               END IF;
               -- Check if this method should be executed, based
               -- on values in COLUMN_NAME and COLUMN_VALUE
               Trace_SYS.Message('MethodList.column_name(i) '||dyna_rec_.column_name(i));
               Trace_SYS.Message('MethodList.column_value(i) '||dyna_rec_.column_value(i));
               IF ( dyna_rec_.column_name(i) IS NULL ) THEN
                  execute_method_ := TRUE;
               ELSE
                  IF ( instr( dyna_rec_.column_name(i),'@' ) != 0 ) THEN
                     -- Check value from previous method
                     ref_value_ := dyna_rec_.column_name(i);
                     Rebuild_Ref_Value___(ref_value_, row_count_, dyna_rec_.method_mode(i));
                  ELSE
                     -- Check if value exists on SELECT-attr
                      ref_value_ := Client_SYS.Get_Item_Value(dyna_rec_.column_name(i),attr_ );
                  END IF;
                  --
                  IF ( nvl(ref_value_,'NULLVALUE') = 'NULLVALUE' ) THEN
                     IF ( dyna_rec_.column_value(i) IS NULL ) THEN
                        execute_method_ := TRUE;
                     ELSE
                        execute_method_ := FALSE;
                     END IF;
                  ELSIF ( ref_value_ LIKE dyna_rec_.column_value(i) ) THEN
                     execute_method_ := TRUE;
                  ELSE
                     execute_method_ := FALSE;
                  END IF;
               END IF;
               Trace_SYS.Message('Selected column value '||ref_value_);
               IF ( execute_method_ ) THEN
                  -- Final check on ON_NEW_MASTER/ON_FIRST_ROW options
                  IF ( dyna_rec_.on_new_master(i) = 'TRUE' ) THEN
                     execute_method_ := new_master_;
                  END IF;
                  IF ( dyna_rec_.on_first_row(i) = 'TRUE' ) THEN
                     execute_method_ := first_row_;
                  END IF;
               END IF;
               -- Execute this method
               IF ( execute_method_ ) THEN
                  dyna_rec_.return_attr(i) := 'EMPTY';
                  IF ( dyna_rec_.method_mode(i) = 'UPDATE' ) THEN
                     --
                     objid_ := NULL;
                     objversion_ := NULL;
                     -- Perform Modify, but first find value for key columns and lookup objid/objversion
                     Get_Objid_From_Key_Values___(
                        objid_, objversion_, 
                        execute_method_,ref_attr_, message_method_, attr_, 
                        row_count_, i , dyna_rec_.method_mode(i)) ;
                     --
                     IF ( objid_ IS NOT NULL ) THEN
                        Rebuild_Attr_String___(dyna_attr_, attr_, dyna_rec_.attr(i),dyna_rec_.view_name(i),row_count_, dyna_rec_.method_mode(i));
                        Trace_SYS.Message('Existing objid/objversion : '||objid_||'/'||objversion_);
                        -- Record exists, execute Modify
                        DBMS_SQL.bind_variable(dyna_rec_.h_cur(i),'attr', dyna_attr_, 32000);
                        DBMS_SQL.bind_variable(dyna_rec_.h_cur(i),'objid', objid_, 32000);
                        DBMS_SQL.bind_variable(dyna_rec_.h_cur(i),'objversion', objversion_, 32000);
                        BEGIN
                           Trace_SYS.Message('Method Statement '||dyna_rec_.method(i)) ;
                           dummy_ := DBMS_SQL.Execute(dyna_rec_.h_cur(i));
                           DBMS_SQL.variable_value(dyna_rec_.h_cur(i),'objid', objid_);
                           DBMS_SQL.variable_value(dyna_rec_.h_cur(i),'objversion', objversion_);
                           DBMS_SQL.variable_value(dyna_rec_.h_cur(i),'attr', return_attr_);
                           old_seq_ := dyna_rec_.execute_seq(i);
                           dyna_rec_.commit_count(i) := dyna_rec_.commit_count(i) + 1;
                           dyna_rec_.last_row(i) := row_count_;
                           dyna_rec_.return_attr(i) := Complete_Return_Attr__(return_attr_,objid_, objversion_);
                        EXCEPTION
                           WHEN OTHERS THEN
                              dyna_rec_.error_count(i) := dyna_rec_.error_count(i) + 1;
                              -- Add ref_attr to dyna_attr in order to display keyvalues
                              -- on error handling in IntfaceJobDetail
                              dyna_attr_ := ref_attr_||dyna_attr_;
                              message_method_ := substr(SQLERRM,1,2000);
                              Trace_SYS.Message('Method MODIFY failed : '||SQLERRM);
                        END;
                     END IF;
                     old_seq_ := dyna_rec_.execute_seq(i);
                  ELSIF ( dyna_rec_.method_mode(i) = 'INSERT' ) THEN
                     IF ( ( second_method_ ) AND ( objid_ IS NOT NULL ) ) THEN
                        -- This record has been modified, no insert necessary
                           NULL;
                     ELSE
                        Rebuild_Attr_String___(dyna_attr_, attr_, dyna_rec_.attr(i),dyna_rec_.view_name(i),row_count_, dyna_rec_.method_mode(i));
                        BEGIN
                           Trace_SYS.Message('Method Statement '||dyna_rec_.method(i)) ;
                        DBMS_SQL.bind_variable(dyna_rec_.h_cur(i),'attr', dyna_attr_, 32000);
                           dummy_ := DBMS_SQL.Execute(dyna_rec_.h_cur(i));
                           DBMS_SQL.variable_value(dyna_rec_.h_cur(i),'objid', objid_);
                           DBMS_SQL.variable_value(dyna_rec_.h_cur(i),'objversion', objversion_);
                           DBMS_SQL.variable_value(dyna_rec_.h_cur(i),'attr', return_attr_);
                           old_seq_ := dyna_rec_.execute_seq(i);
                           dyna_rec_.commit_count(i) := dyna_rec_.commit_count(i) + 1;
                           dyna_rec_.last_row(i) := row_count_;
                           dyna_rec_.return_attr(i) := Complete_Return_Attr__(return_attr_,objid_, objversion_);
                        EXCEPTION
                           WHEN OTHERS THEN
                              dyna_rec_.error_count(i) := dyna_rec_.error_count(i) + 1;
                              Trace_SYS.Message('Method NEW failed : '||SQLERRM);
                              message_method_ := substr(SQLERRM,1,2000);
                        END;
                     END IF;
                     objid_ := NULL;
                     objversion_ := NULL;
                  ELSE
                     -- Other procedure
                     IF ( dyna_rec_.attr(i) != 'EMPTY' ) THEN
                        Rebuild_Attr_String___(dyna_attr_, attr_, dyna_rec_.attr(i), nvl(dyna_rec_.view_name(i),'METHOD'||dyna_rec_.execute_seq(i)), row_count_,dyna_rec_.method_mode(i));
                     END IF;
                     IF ( dyna_rec_.arg_attr(i)  != 'EMPTY' ) THEN
                        Rebuild_Attr_String___(arg_attr_, attr_, dyna_rec_.arg_attr(i),'METHOD'||dyna_rec_.execute_seq(i),row_count_, 'ARGUMENTS');
                     END IF;
                     IF ( dyna_rec_.upd_cur(i) != 0 ) THEN -- Find objid and objversion
                        Trace_SYS.Message('Get_Objid_From_Key_Values___');
                        -- Must find objid/objversion from key-values first.....
                        Get_Objid_From_Key_Values___(
                           objid_, objversion_, 
                           execute_method_,ref_attr_, message_method_, attr_, 
                           row_count_, i , dyna_rec_.method_mode(i)) ;
                     END IF;
                     --
                     IF ( execute_method_ ) THEN
                        Trace_SYS.Message('Method Statement '||dyna_rec_.method(i)) ;
                        DBMS_SQL.bind_variable(dyna_rec_.h_cur(i),'objid', objid_, 32000);
                        DBMS_SQL.bind_variable(dyna_rec_.h_cur(i),'objversion', objversion_, 32000);
                        DBMS_SQL.bind_variable(dyna_rec_.h_cur(i),'attr', dyna_attr_, 32000);
                        DBMS_SQL.bind_variable(dyna_rec_.h_cur(i),'arg_attr', arg_attr_, 32000);
                        DBMS_SQL.bind_variable(dyna_rec_.h_cur(i),'action', action_, 32000);
                        BEGIN
                           dummy_ := DBMS_SQL.Execute(dyna_rec_.h_cur(i));
                           DBMS_SQL.variable_value(dyna_rec_.h_cur(i),'attr', return_attr_);
                           dyna_rec_.return_attr(i) := Complete_Return_Attr__(return_attr_,objid_, objversion_);
                           dyna_rec_.commit_count(i) := dyna_rec_.commit_count(i) + 1;
                           dyna_rec_.last_row(i) := row_count_;
                        EXCEPTION
                           WHEN OTHERS THEN
                              dyna_rec_.error_count(i) := dyna_rec_.error_count(i) + 1;
                              -- Parse SELECT-attr if dyna_attr_ is null
                              IF ( nvl(dyna_attr_,'EMPTY') = 'EMPTY' ) THEN
                                 dyna_attr_ := attr_;
                              END IF;
                              --Ref_attr_ may containg key-values
                              dyna_attr_ := nvl(ref_attr_||dyna_attr_,return_attr_);
                              message_method_ := substr(SQLERRM,1,2000);
                              Trace_SYS.Message('Method OTHER failed : '||SQLERRM);
                        END;
                     END IF;
                    objid_ := NULL;
                    objversion_ := NULL;
                  END IF;
               ELSE
                  trace_sys.message('TRACE >>>>>>>>>>>>>>>>>>>>>>> Method no.'||dyna_rec_.execute_seq(i)||' not executed') ;
               END IF;
               -- Message_method has only been used if errors have occured
               IF ( message_method_ IS NOT NULL ) THEN
                  -- This method has failed
                  -- Make w_attr_ for presentation in case of error-handling
                  w_attr_ := dyna_attr_;
                  IF ( NOT intf_ignorexeerror_ ) THEN
                     error_count_ := error_count_ + 1;
                     method_raised_ := i;               -- For error-handling in EXCEPTION
                     RAISE method_error_;
                  ELSE
                     IF ( NOT replication_ ) THEN
                        BEGIN
                           -- IF server methods have execeuted COMMIT,
                           -- this ROLLBACK will fail. In that case we'll
                           -- have incomplete transactions
                           Trace_SYS.Message('ROLLBACK to SAVEPOINT new_method_') ;
@ApproveTransactionStatement(2014-04-02,mabose)
                           ROLLBACK TO SAVEPOINT new_method_;
@ApproveTransactionStatement(2014-04-02,mabose)
                           SAVEPOINT new_method_;
                        EXCEPTION
                           WHEN OTHERS THEN
                              Trace_SYS.Message('ROLLBACK to new_method FAILED ');
                              dyna_rec_.incomplete_count(i) := dyna_rec_.incomplete_count(i) + 1;
                              message_method_ := substr('INCOMPLETE ROW : '||message_method_,1,2000);
                        END;
                     ELSE
@ApproveTransactionStatement(2014-04-02,mabose)
                        ROLLBACK TO SAVEPOINT new_repl_;
                     END IF;
                     Intface_Job_Detail_API.Process_Job_Details(intface_name_,
                        row_err_count_ ,null , w_attr_ , message_method_ , source_rowid_ );
                        -- row_count_ ,null , w_attr_ , message_method_ , source_rowid_ );
                     IF ( replication_ ) THEN
@ApproveTransactionStatement(2014-04-02,mabose)
                        COMMIT;
                        message_method_ := NULL;
                     ELSE
                        EXIT;
                     END IF;
                  END IF;
               END IF;
            END LOOP; -- End method loop
            Trace_SYS.Message('Method LOOP finished');
            --
            -- Keep track of number rows COMMITed
            --
            IF ( message_method_ IS NOT NULL ) THEN
               error_count_ := error_count_ + 1;
               message_method_ := NULL;
            ELSE
               commit_count_ := commit_count_ + 1;
            END IF;
         END IF;
         IF ( replication_ ) THEN
@ApproveTransactionStatement(2014-04-02,mabose)
            COMMIT;
@ApproveTransactionStatement(2014-04-02,mabose)
            SAVEPOINT new_job_;
         ELSIF ( nvl(App_Context_SYS.Find_Number_Value(Intface_Job_Detail_API.intf_commit_seq_cid_),commit_seq_+1) <= commit_seq_ ) THEN
@ApproveTransactionStatement(2014-04-02,mabose)
            COMMIT;
            Trace_SYS.Message(' TRACE>>>>>>> Commit ');
            commit_seq_cnt_ := commit_seq_cnt_ + commit_seq_;
            commit_seq_ := 0;
@ApproveTransactionStatement(2014-04-02,mabose)
            SAVEPOINT new_job_;
         END IF;
      END LOOP; -- End SELECT loop
      IF ( replication_ AND repl_mode_  IN ('2','3') ) THEN
         -- IF there have been added a WHERE-clause to the job,
         -- there may be rows in the log-table that never meets this clause,
         -- and therefore never will be handled.
         -- Perform this extra DELETE to remove 'leftovers'
         Trace_SYS.Message('Delete prior to Log_seq: '||log_seq_);
         DELETE FROM Intface_Replication_Log_TAB
         WHERE  intface_name = intface_name_
         AND log_seq < log_seq_;
      END IF;
      --
      -- Check how each method have executed.
      -- Build info message
      error_count_ := 0;
      FOR i IN 1..dyna_count_ LOOP
         Trace_SYS.Message('check method no '||to_char(i));
         -- Extract method_name
         show_method_ := REPLACE(SUBSTR(dyna_rec_.method(i),1,INSTR(dyna_rec_.method(i),'(')-1),'Begin ','');
         IF ( dyna_rec_.method_mode(i) != 'OTHER' ) THEN
            show_method_ := substr(show_method_,1,instr(show_method_,'.')-1);
         END IF;
         method_result_ := NULL;
         IF ( old_exe_seq_ != dyna_rec_.execute_seq(i) ) THEN
            IF ( action_ = 'CHECK') THEN
               method_result_ := Language_SYS.Translate_Constant(lu_name_, ' METHCHK : :P1 :P2  with CHECK option ', Fnd_Session_API.Get_Language, lpad(to_char(dyna_rec_.execute_seq(i)),3,' '), show_method_ );
            ELSE
               method_result_ := Language_SYS.Translate_Constant(lu_name_, ' METHNAME : :P1 :P2 ', Fnd_Session_API.Get_Language, lpad(to_char(dyna_rec_.execute_seq(i)),3,' '), show_method_ );
            END IF;
            method_result_ := msg_sep_||method_result_;
         END IF;
         method_executed_ := TRUE;
         incomplete_result_ := NULL;
         error_result_ := NULL;
         IF ( dyna_rec_.incomplete_count(i) > 0 ) THEN
            incomplete_trans_ := TRUE;
            incomplete_result_ := msg_sep_||Language_SYS.Translate_Constant(lu_name_, ' INCOMPLETE : :P1 incomplete transactions due to COMMIT or ROLLBACK in a called method ', Fnd_Session_API.Get_Language, to_char(dyna_rec_.incomplete_count(i)));
            methods_in_ok_ := FALSE;
            error_count_ := error_count_ + dyna_rec_.incomplete_count(i);
         ELSIF ( dyna_rec_.error_count(i) > 0 ) THEN
            error_result_ := Language_SYS.Translate_Constant(lu_name_, ' METHFAILED : , Errors : :P1  ', Fnd_Session_API.Get_Language, to_char(dyna_rec_.error_count(i)));
            methods_in_ok_ := FALSE;
            error_count_ := error_count_ + dyna_rec_.error_count(i);
         ELSIF ( dyna_rec_.commit_count(i) > 0 ) THEN
            NULL ;
         ELSE
            method_executed_  := FALSE;
         END IF;
         IF ( method_executed_ ) THEN
            IF ( replication_ AND repl_destination_ IS NOT NULL ) THEN
               method_result_ := method_result_||msg_sep_||'       '||dyna_rec_.repl_key(i);
            ELSE
               method_result_ := method_result_||msg_sep_||'       ';
            END IF;
            --
            IF ( dyna_rec_.method_mode(i) = 'INSERT' ) THEN         
               method_result_ := method_result_ || 
                  Language_SYS.Translate_Constant(lu_name_, ' METHINS : New rows      : :P1  ', Fnd_Session_API.Get_Language, to_char(dyna_rec_.commit_count(i)));
            ELSIF ( dyna_rec_.method_mode(i) = 'UPDATE' ) THEN         
               method_result_ := method_result_ || 
                  Language_SYS.Translate_Constant(lu_name_, ' METHUPD : Updated rows  : :P1  ', Fnd_Session_API.Get_Language, to_char(dyna_rec_.commit_count(i)));
            ELSE
               method_result_ := method_result_ || 
                  Language_SYS.Translate_Constant(lu_name_, ' METHPRC : Processed rows  : :P1  ', Fnd_Session_API.Get_Language, to_char(dyna_rec_.commit_count(i)));
            END IF;
            method_result_ := method_result_ || error_result_|| incomplete_result_;
         END IF;
         IF ( all_methods_ IS NULL ) THEN
            all_methods_ := method_result_;
         ELSE
            all_methods_ := substr(all_methods_||method_result_,1,30000);
         END IF;
         old_exe_seq_ := dyna_rec_.execute_seq(i);
      END LOOP;
      Close_Cursors__(dyna_count_);
   ELSIF ( h_cur_ != 0  ) THEN
      message_select_ := NULL; -- Select parsed, but not executed
      IF ( DBMS_SQL.Is_Open(h_cur_) ) THEN
         DBMS_SQL.Close_Cursor(h_cur_);
      END IF;
   END IF;
   --
   trace_sys.message('TRACE >>>>>>>>>>>>>>>>>>>>>>> EXECUTE METHODS AFTER LOOP');
   -- Finally, execute methods after main loop ends. They have action=3
   FOR arec_ IN Get_Method_List('3') LOOP
@ApproveTransactionStatement(2014-04-02,mabose)
      SAVEPOINT new_method_;
      BEGIN
         header_message_ := Language_SYS.Translate_Constant(lu_name_, ' HEADMSG : EXECUTING METHOD NO. :P1 : ', Fnd_Session_API.Get_Language, to_char(arec_.execute_seq));
         IF ( message_after_ IS NULL ) THEN
            message_after_ := header_message_||msg_sep_||'       ';
         ELSE
            message_after_ := message_after_||msg_sep_||msg_sep_||header_message_||msg_sep_||'       ';
         END IF;
         Client_SYS.Clear_Attr(parse_attr_);
         Get_Method_List_Attrib__ ( ref_attr_, convert_attr_ ,parse_attr_, 
                                   '0', 'AFTER_LOOP', arec_.execute_seq );
         IF ( instr(upper(arec_.method_name),'INTFACE_HEADER_API.START_JOB') != 0) THEN
            -- This starts another migration job
            parse_intface_name_ := Client_SYS.Get_Item_Value('INTFACE_NAME_', parse_attr_);
            IF ( parse_intface_name_ IS NULL ) THEN
               message_after_ := message_after_||Language_SYS.Translate_Constant(lu_name_, ' NONAME : Value for Job ID is missing on attr-string for method no. :P1 ', Fnd_Session_API.Get_Language, to_char(arec_.execute_seq));
               RAISE no_execute_;
            ELSIF ( parse_intface_name_ = intface_name_ ) THEN
               message_after_ := message_after_||Language_SYS.Translate_Constant(lu_name_, ' DUPNAME : Method no. :P1 - Value for Job ID cannot be equal to main job  ', Fnd_Session_API.Get_Language, to_char(arec_.execute_seq));
               RAISE no_execute_ ;
            END IF;
         END IF;
         -- May contain hardcoded value:
         info_ := Client_SYS.Get_Item_Value('INFO_', parse_attr_);
         --
         Client_SYS.Clear_Attr(attr_);
         Execute_Dynamic_Proc ( info_,
                                objid_,      -- Dummy 
                                objversion_, -- Dummy 
                                attr_,       -- Dummy 
                                parse_attr_,
                                'DO',        --Action 
                                Get_Dynamic_Proc_Name( intface_name_, arec_.execute_seq ));
         IF ( Client_SYS.Get_Item_Value('EXEC_FLAG', attr_) = 'FALSE' ) THEN
            -- Job failed
@ApproveTransactionStatement(2014-04-02,mabose)
            SAVEPOINT new_method_;
            RAISE no_execute_;
         END IF;
         info_ := nvl(info_, Language_SYS.Translate_Constant(lu_name_, ' EXEOK :  Executed without error', Fnd_Session_API.Get_Language));
      EXCEPTION
         WHEN no_execute_ THEN
            Change_Job_Context__('RESTORE',intface_name_); -- Restore global variables from Load_Intface_Info
            Trace_SYS.Message(' Get_Method_List no_execute_');
            methods_after_ok_ := FALSE;
            IF ( NOT intf_ignorexeerror_ ) THEN
               message_after_ := message_after_||msg_sep_||SQLERRM;
               RAISE method_error_after_;
            ELSE
@ApproveTransactionStatement(2014-04-02,mabose)
               ROLLBACK TO SAVEPOINT new_method_;
               message_after_ := message_after_||msg_sep_||SQLERRM;
            END IF;
         WHEN OTHERS THEN
            Change_Job_Context__('RESTORE',intface_name_); -- Restore global variables from Load_Intface_Info
            Trace_SYS.Message('Get_Method_List OTHERS');
            methods_after_ok_ := FALSE;
            IF ( NOT intf_ignorexeerror_ ) THEN
               message_after_ := message_after_||msg_sep_||SQLERRM;
               RAISE method_error_after_;
            ELSE
@ApproveTransactionStatement(2014-04-02,mabose)
               ROLLBACK TO SAVEPOINT new_method_;
               message_after_ := message_after_||msg_sep_||SQLERRM;
            END IF;
      END;
      -- Info variable may contain returnvalue from procedure
      -- or errormessage from EXCEPTION. Save info for each turn in loop.
      IF ( info_ IS NOT NULL ) THEN
         message_after_ := message_after_||msg_sep_||info_;
      END IF;
      info_ := NULL;
      parse_info_ := NULL;
      parse_intface_name_ := NULL;
      Change_Job_Context__('RESTORE',intface_name_);
   END LOOP;
   --
   -- Build info variable.
   -- Send action to make alternate message for CHECKed rows
   info_ := action_;
   Build_Info_String__(info_,message_start_,message_before_, message_select_, all_methods_ ,message_after_, start_time_,row_count_, incomplete_trans_, commit_count_,error_count_,intface_name_);
   --
   -- Reset global OK variable
   IF ( ( methods_before_ok_ ) AND ( methods_in_ok_ ) AND ( methods_after_ok_) ) THEN
      App_Context_SYS.Set_Value(Intface_Job_Detail_API.intf_execution_ok_cid_,TRUE);
      trace_sys.message('TRACE >>>>>>>>>>>>>>>>>>>>>>> JOB CLOSES NORMALLY WITHOUT ERRORS');
   ELSE
      App_Context_SYS.Set_Value(Intface_Job_Detail_API.intf_execution_ok_cid_,FALSE);
      trace_sys.message('TRACE >>>>>>>>>>>>>>>>>>>>>>> JOB CLOSES NORMALLY. ERRORS HAVE OCCURED');
   END IF;
   Close_Cursors__(dyna_count_);
EXCEPTION
   WHEN no_conn_start_ THEN
      message_select_ := Language_SYS.Translate_Constant(lu_name_, ' CONNERR : Cannot start this job. Connected job :P1 has errors.', Fnd_Session_API.Get_Language, conn_job1_ );
      Build_Info_String__(info_,message_start_,message_before_, message_select_,message_method_,message_after_, start_time_,row_count_,incomplete_trans_,commit_count_,error_count_,intface_name_);
      trace_sys.message('TRACE >>>>>>>>>>>>>>>>>>>>>>> JOB ABORTED - no_conn_start_');
   WHEN incomplete_select_ THEN
      trace_sys.message('TRACE >>>>>>>>>>>>>>>>>>>>>>> JOB ABORTED - incomplete_select_ rollback');
      --ROLLBACK TO SAVEPOINT new_job_;
@ApproveTransactionStatement(2014-04-02,mabose)
      ROLLBACK;
      -- Send action to make alternate message for CHECKed rows
      info_ := action_;
      Build_Info_String__(info_,message_start_,message_before_, message_select_,message_method_,message_after_, start_time_,row_count_,incomplete_trans_,commit_count_,error_count_,intface_name_);
   WHEN no_restart_ THEN
      trace_sys.message('TRACE >>>>>>>>>>>>>>>>>>>>>>> JOB ABORTED - no_restart_ rollback');
      --ROLLBACK TO SAVEPOINT new_job_;
@ApproveTransactionStatement(2014-04-02,mabose)
      ROLLBACK;
      -- Send action to make alternate message for CHECKed rows
      info_ := action_;
      Build_Info_String__(info_,message_start_,message_before_, message_select_,message_method_,message_after_, start_time_,row_count_,incomplete_trans_,commit_count_,error_count_,intface_name_);
   WHEN no_start_ THEN
      trace_sys.message('TRACE >>>>>>>>>>>>>>>>>>>>>>> JOB ABORTED - no_start_');
      --ROLLBACK TO SAVEPOINT new_job_;
@ApproveTransactionStatement(2014-04-02,mabose)
      ROLLBACK;
      -- Send action to make alternate message for CHECKed rows
      info_ := action_;
      Build_Info_String__(info_,message_start_,message_before_, message_select_,message_method_,message_after_, start_time_,row_count_,incomplete_trans_,commit_count_,error_count_,intface_name_);
   WHEN method_error_ THEN
      trace_sys.message('TRACE >>>>>>>>>>>>>>>>>>>>>>> JOB ABORTED - method_error_ ');
      BEGIN
@ApproveTransactionStatement(2014-04-02,mabose)
         ROLLBACK TO SAVEPOINT new_job_;
         Trace_SYS.Message('Rollback OK ');
      EXCEPTION
         -- IF ROLLBACK fails, make warning
         WHEN OTHERS THEN
            IF ( nvl(method_raised_,0) != 0 ) THEN
               dyna_rec_.incomplete_count(method_raised_) := dyna_rec_.incomplete_count(method_raised_) + 1;
            END IF;
            Trace_SYS.Message('ROLLBACK failed, RAISE '||SQLERRM);
            message_method_ := Language_SYS.Translate_Constant(lu_name_, ' INCOMPLROW1 : INCOMPLETE ROW : ', Fnd_Session_API.Get_Language )||message_method_ ;
      END;
      IF ( App_Context_SYS.Find_Number_Value(Intface_Job_Detail_API.intf_commit_seq_cid_) IS NULL ) THEN
         commit_count_ := 0;
      END IF;
      -- Check how each method have executed.
      -- Build info message
      error_count_ := 0;
      FOR i IN 1..dyna_count_ LOOP
         Trace_SYS.Message('check method no '||to_char(i));
         -- Extract method_name
         show_method_ := REPLACE(SUBSTR(dyna_rec_.method(i),1,INSTR(dyna_rec_.method(i),'(')-1),'Begin ','');
         IF ( dyna_rec_.method_mode(i) != 'OTHER' ) THEN
            show_method_ := substr(show_method_,1,instr(show_method_,'.')-1);
         END IF;
         method_result_ := NULL;
         IF ( old_exe_seq_ != dyna_rec_.execute_seq(i) ) THEN
            IF ( action_ = 'CHECK') THEN
               method_result_ := Language_SYS.Translate_Constant(lu_name_, ' METHCHK : :P1 :P2  with CHECK option ', Fnd_Session_API.Get_Language, lpad(to_char(dyna_rec_.execute_seq(i)),3,' '), show_method_ );
            ELSE
               method_result_ := Language_SYS.Translate_Constant(lu_name_, ' METHNAME : :P1 :P2 ', Fnd_Session_API.Get_Language, lpad(to_char(dyna_rec_.execute_seq(i)),3,' '), show_method_ );
            END IF;
            method_result_ := msg_sep_||method_result_;
         END IF;
         method_executed_ := TRUE;
         incomplete_result_ := NULL;
         error_result_ := NULL;
         IF ( dyna_rec_.incomplete_count(i) > 0 ) THEN
            incomplete_trans_ := TRUE;
            incomplete_result_ := msg_sep_||Language_SYS.Translate_Constant(lu_name_, ' INCOMPLETE : :P1 incomplete transactions due to COMMIT or ROLLBACK in a called method ', Fnd_Session_API.Get_Language, to_char(dyna_rec_.incomplete_count(i)));
            methods_in_ok_ := FALSE;
            error_count_ := error_count_ + dyna_rec_.incomplete_count(i);
         ELSIF ( dyna_rec_.error_count(i) > 0 ) THEN
            error_result_ := Language_SYS.Translate_Constant(lu_name_, ' METHFAILED : , Errors : :P1  ', Fnd_Session_API.Get_Language, to_char(dyna_rec_.error_count(i)));
            methods_in_ok_ := FALSE;
            error_count_ := error_count_ + dyna_rec_.error_count(i);
         ELSIF ( dyna_rec_.commit_count(i) > 0 ) THEN
            NULL ;
         ELSE
            method_executed_  := FALSE;
         END IF;
         IF ( method_executed_ ) THEN
            IF ( replication_ AND repl_destination_ IS NOT NULL ) THEN
               method_result_ := method_result_||msg_sep_||'       '||dyna_rec_.repl_key(i);
            ELSE
               method_result_ := method_result_||msg_sep_||'       ';
            END IF;
            --
            IF ( dyna_rec_.method_mode(i) = 'INSERT' ) THEN         
               method_result_ := method_result_ || 
                  Language_SYS.Translate_Constant(lu_name_, ' METHINS : New rows      : :P1  ', Fnd_Session_API.Get_Language, to_char(dyna_rec_.commit_count(i)));
            ELSIF ( dyna_rec_.method_mode(i) = 'UPDATE' ) THEN         
               method_result_ := method_result_ || 
                  Language_SYS.Translate_Constant(lu_name_, ' METHUPD : Updated rows  : :P1  ', Fnd_Session_API.Get_Language, to_char(dyna_rec_.commit_count(i)));
            ELSE
               method_result_ := method_result_ || 
                  Language_SYS.Translate_Constant(lu_name_, ' METHPRC : Processed rows  : :P1  ', Fnd_Session_API.Get_Language, to_char(dyna_rec_.commit_count(i)));
            END IF;
            method_result_ := method_result_ || error_result_|| incomplete_result_;
         END IF;
         IF ( all_methods_ IS NULL ) THEN
            all_methods_ := method_result_;
         ELSE
            all_methods_ := substr(all_methods_||method_result_,1,30000);
         END IF;
         old_exe_seq_ := dyna_rec_.execute_seq(i);
      END LOOP;
      IF ( commit_seq_cnt_ > 0) THEN
         all_methods_ := all_methods_||msg_sep_||msg_sep_||
            Language_SYS.Translate_Constant(lu_name_, ' COMMITSEQ :  Rows committed by Rule COMMITSEQ : :P1 ', Fnd_Session_API.Get_Language , to_char(commit_seq_cnt_));
      END IF;
      Trace_SYS.Message('Close cursors');
      Close_Cursors__(dyna_count_);
      Trace_SYS.Message('Update job details');
      IF ( nvl(method_raised_,0) != 0 ) THEN
         -- Update details only if this Exception is raised
         -- for a method InLoop
         BEGIN
         Intface_Job_Detail_API.Process_Job_Details(intface_name_,
             row_count_ ,null , dyna_attr_ , message_method_ , source_rowid_ );
         EXCEPTION
            WHEN OTHERS THEN
               Trace_SYS.Message(SQLERRM);
         END;
      END IF;
      Trace_SYS.Message('Build info');
      -- Send action to make alternate message for CHECKed rows
      info_ := action_;
      Build_Info_String__(info_,message_start_,message_before_, message_select_,all_methods_ ,message_after_, start_time_,row_count_,incomplete_trans_,commit_count_,error_count_,intface_name_);
      Trace_SYS.Message('Build OK');
   WHEN method_error_after_ THEN
      Trace_SYS.Message('TRACE >>>>>>>>>>>>>>>>>>>>>>> JOB ABORTED - method_error_after_ ');
      Build_Info_String__(info_,message_start_,message_before_, message_select_,all_methods_ ,message_after_, start_time_,row_count_,incomplete_trans_,commit_count_,error_count_,intface_name_);
   WHEN OTHERS THEN
      Trace_SYS.Message('TRACE >>>>>>>>>>>>>>>>>>>>>>> JOB ABORTED - OTHERS') ;
      Trace_SYS.Message('OTHERS '||SQLERRM);
@ApproveTransactionStatement(2014-04-02,mabose)
      ROLLBACK TO SAVEPOINT new_job_;
      commit_count_ := 0;
      Close_Cursors__(dyna_count_);
      Build_Info_String__(info_,message_start_,message_before_, message_select_,message_method_,message_after_, start_time_,row_count_,incomplete_trans_,commit_count_,error_count_,intface_name_);
END Migrate_Source_Data;

FUNCTION Get_Sequence_No (
   sequence_name_ IN VARCHAR2,
   sequence_value_ IN VARCHAR2 ) RETURN NUMBER
IS
   h_cur_      INTEGER;
   dummy_      NUMBER;
   stmt_       VARCHAR2(2000);
   seq_no_     NUMBER;
   test_       NUMBER := 0;
   no_sequence EXCEPTION;
   CURSOR check_sequence IS
      SELECT 1 FROM user_sequences
      WHERE sequence_name = upper(sequence_name_);
BEGIN
   OPEN check_sequence;
   FETCH check_sequence INTO test_;
   IF check_sequence%NOTFOUND THEN
      CLOSE check_sequence;
      RAISE no_sequence;
   ELSE
      CLOSE check_sequence;
   END IF;
   IF ( upper(sequence_value_) = 'NEXTVAL' ) THEN
      stmt_ := 'Begin SELECT '||sequence_name_||'.nextval '||
                'INTO :SEQ_NO FROM DUAL ; End;';
   ELSIF ( upper(sequence_value_) = 'CURRVAL' ) THEN
      stmt_ := 'Begin SELECT '||sequence_name_||'.currval '||
                'INTO :SEQ_NO FROM DUAL ; End;';
   END IF;
   IF ( upper(sequence_value_) IN ('NEXTVAL','CURRVAL') ) THEN
      h_cur_ := DBMS_SQL.Open_Cursor;
      @ApproveDynamicStatement(2009-11-27,nabalk)
      DBMS_SQL.Parse(h_cur_, stmt_, DBMS_SQL.native);
      DBMS_SQL.bind_variable(h_cur_,'SEQ_NO', seq_no_);
      dummy_ := DBMS_SQL.Execute(h_cur_);
      DBMS_SQL.variable_value(h_cur_,'SEQ_NO', seq_no_);
      DBMS_SQL.Close_Cursor(h_cur_);
   END IF;
   RETURN seq_no_;
EXCEPTION
   WHEN no_sequence THEN
      Trace_SYS.Message('Sequence '||sequence_name_||' not found');
   RETURN seq_no_;
   WHEN OTHERS THEN
      Trace_SYS.Message(SQLERRM);
      IF ( DBMS_SQL.Is_Open(h_cur_) ) THEN
         DBMS_SQL.Close_Cursor(h_cur_);
      END IF;
   RETURN seq_no_;
END Get_Sequence_No;

FUNCTION Get_Dynamic_Proc_Name (
   intface_name_ IN VARCHAR2,
   execute_seq_  IN NUMBER) RETURN VARCHAR2
IS 
   name_ VARCHAR2(100);
BEGIN
   name_ := 'IC_'||intface_name_||'_'||execute_seq_;
   RETURN name_;
END Get_Dynamic_Proc_Name;

FUNCTION Get_Dynamic_Proc_Code (
   intface_name_ IN VARCHAR2,
   execute_seq_  IN NUMBER) RETURN VARCHAR2
IS 
   method_name_  VARCHAR2(100) := Intface_Method_List_API.Get_Method_Name(intface_name_, execute_seq_);
   proc_name_    VARCHAR2(100) := Intface_Method_List_API.Get_Dynamic_Proc_Name(intface_name_, execute_seq_);
   lf_           VARCHAR2(1) := chr(10);
   stmt_         VARCHAR2(32000);
   -- Text-variables to hold different parts of the statement
   start_proc_   VARCHAR2(32000);
   end_proc_     VARCHAR2(32000);
   before_meth_  VARCHAR2(32000);
   arg_list_     VARCHAR2(32000) := lf_;
   after_meth_   VARCHAR2(32000) := lf_;
   extra_line_   VARCHAR2(2000);
   extra_line1_  VARCHAR2(2000);
   alt_attr_col_ VARCHAR2(100);
   cols_count_   NUMBER           := 0;
   fixed_value_  VARCHAR2(2000);
   add_attr1_    VARCHAR2(2000) := NULL;
   add_attr2_    VARCHAR2(2000) := ';';
   rec_in_out_   VARCHAR2(10);
   count_arg_in_ NUMBER := 0;
   --
   -- Select data from user_arguments
   -- Define get_item_start and get_item_end
   -- to prepare handling of date and number variables.
   -- Also check if this is a function; i.e. if argument_name is NULL
   -- and direction is OUT, this is the returnvalue from a function
   CURSOR get_data IS
      SELECT UPPER(nvl(argument_name,
               decode(in_out,'OUT',
                  'FUNCTION_RESULT',NULL))) argument_name,
             decode(data_type,'VARCHAR2','VARCHAR2(32000)',UPPER(data_type)) data_type, 
             position,
             in_out ,
             decode(data_type,
               'VARCHAR2',NULL,
               'NUMBER','Client_SYS.Attr_Value_To_Number(',
               'DATE','Client_SYS.Attr_Value_To_Date(') get_item_start,
             decode(data_type,
               'VARCHAR2',NULL,
               'NUMBER',')',
               'DATE',')') get_item_end,
            Intface_Method_List_Attrib_API.Get_Fixed_Value(intface_name_,execute_seq_,argument_name) fixed_value
      FROM all_arguments
      WHERE package_name = UPPER(substr(method_name_,1,INSTR(method_name_,'.')-1))
      AND object_name = UPPER(substr(method_name_,INSTR(method_name_,'.')+1))
      AND nvl(overload,1) =1
      AND data_level = 0
      AND owner = Fnd_Session_API.Get_App_Owner
      ORDER BY position;
   --
   -- There is a parameter for attribute-string
   -- but it is not named ATTR_. We have pointed it out
   -- by entering ATTR_ to fixed_value.
   CURSOR check_attr_name IS
      SELECT lower(column_name)
      FROM intface_method_list_attrib_tab
      WHERE intface_name = intface_name_
      AND execute_seq = execute_seq_
      AND upper(fixed_value) = 'ATTR_';
   --
   FUNCTION Format_Fixed_Value (
      value_ IN VARCHAR2,
      data_type_ IN VARCHAR2 ) RETURN VARCHAR2
   IS
      return_value_ VARCHAR2(2000);
   BEGIN
      return_value_ := value_;
      IF ( instr(return_value_ ,'@') != 0 ) THEN
         return_value_ := NULL;
         RETURN return_value_;
      ELSIF ( return_value_ = 'ATTR_' ) THEN
         return_value_ := NULL;
         RETURN return_value_;
      ELSIF ( instr(data_type_ ,'VARCHAR2') != 0 ) THEN
         return_value_ := ''''||value_||'''';
      END IF;      
      RETURN ' := '||return_value_;
   END Format_Fixed_Value;
BEGIN
   --
   end_proc_  := 'END '||proc_name_||';';
   start_proc_  := 'CREATE OR REPLACE PROCEDURE '||proc_name_||' ('||lf_||
                   '   info_        IN OUT VARCHAR2, '||lf_||
                   '   objid_       IN OUT VARCHAR2, '||lf_||
                   '   objversion_  IN OUT VARCHAR2, '||lf_||
                   '   attr_        IN OUT VARCHAR2, '||lf_||
                   '   arg_attr_    IN VARCHAR2, '||lf_||
                   '   in_action_   IN VARCHAR2) '||lf_||
                   'IS '||lf_||
                   '   ptr$_ NUMBER;'||lf_||
                   '   name$_ VARCHAR2(30);'||lf_||
                   '   value$_ VARCHAR2(2000);'||lf_||
                   '   action_ VARCHAR2(2000) := in_action_;'||lf_||
                   '   -- '||lf_;
   before_meth_  := 'BEGIN '||lf_||
                    '   WHILE (Client_SYS.Get_Next_From_Attr(arg_attr_, ptr$_, name$_, value$_)) LOOP '||lf_||
                    '      IF ';
   -- Check if attribute parameter has alternative name
   OPEN  check_attr_name;
   FETCH check_attr_name INTO alt_attr_col_;
   CLOSE  check_attr_name;
   --
   -- Start select from user-arguments.
   -- Build different parts of the statement within this one loop
   FOR rec_ IN get_data LOOP
      fixed_value_ := NULL;
      rec_in_out_ := rec_.in_out;
      IF (rec_.fixed_value IS NOT NULL ) THEN
         fixed_value_ := Format_Fixed_Value(rec_.fixed_value, rec_.data_type);      
      END IF;
      IF ( rec_.argument_name = 'FUNCTION_RESULT') THEN
         -- This is used to enclose the function-call in Client_SYS.Add_To_Attr,
         -- which is OVERLOADED and handles any dataype of the return-value
         add_attr1_ := 'Client_SYS.Add_To_Attr('||''''||'FUNCTION_RESULT'||''''||',';
         add_attr2_ := ',attr_);';
      ELSE
         -- Build argument list for method call
         arg_list_ := arg_list_||'      '||lower(rec_.argument_name)||','||lf_;
      END IF;      
      IF ( rec_.argument_name NOT IN ('ATTR_','ARG_ATTR_')) THEN
         IF ( instr(rec_in_out_,'IN') != 0 ) THEN
            count_arg_in_ := count_arg_in_ +1;
         END IF; 
         IF ( rec_.argument_name NOT IN ('INFO_','OBJID_','OBJVERSION_','ACTION_','FUNCTION_RESULT') ) THEN 
            -- Declare variables for arguments that not already exists as in-parameters
            start_proc_ := start_proc_||'   '||lower(rec_.argument_name)||' '||rec_.data_type||fixed_value_||';'||lf_ ;
         END IF;
         -- Handle in/out arguments, but only those who exists in MethodListAttrib
         -- (except for info and attr's)
         IF ( ( fixed_value_ IS NULL AND rec_.argument_name != 'INFO_') OR 
              ( rec_.argument_name = 'INFO_' AND fixed_value_ IS NOT NULL ) ) THEN 
            -- Dont loop on arguments with fixed value, they are declared as 
            -- variable-declarations with hardcoded value, EXCEPT for INFO_, which is handled here
            IF ( nvl(upper(alt_attr_col_),'**') != rec_.argument_name AND
                 Exist_In_Attrib___( intface_name_, execute_seq_, rec_.argument_name ) ) THEN
               cols_count_ := cols_count_ +1;
               -- Ignore parameters with single direction OUT
               IF ( (instr(rec_in_out_,'OUT') != 1 ) ) THEN
                  -- Get values from arg_attr 
                  before_meth_ := before_meth_ ||
                     ' ( name$_ = '||''''||rec_.argument_name||''''||' ) THEN '||lf_||
                     '         '||lower(rec_.argument_name)||':= '||rec_.get_item_start||
                                 'value$_'||rec_.get_item_end||';'||lf_||
                     '      ELSIF ';
               END IF;
               IF ( (instr(rec_in_out_,'OUT') != 0 ) AND rec_.argument_name NOT IN ('INFO_','OBJID_','OBJVERSION_','ACTION_','FUNCTION_RESULT')) THEN
                  -- Add OUT-values to attr after method call; to be returned and stored in memory
                  after_meth_ := after_meth_||'   Client_SYS.Add_To_Attr('||''''||rec_.argument_name||''''||','||lower(rec_.argument_name)||',attr_);'||lf_;
               END IF;
            END IF;
         END IF;
      END IF;
   END LOOP;
   -- End WHILE LOOP
   --
   -- Format before_meth_
   IF ( cols_count_ = 0  ) THEN
      -- No columns in argument list, overwrite WHILE-loop + IF-test
      before_meth_ := 'BEGIN '||lf_;
   ELSIF ( count_arg_in_ = 0  ) THEN
      -- No in parameters, overwrite WHILE-loop + IF-test
      before_meth_ := 'BEGIN '||lf_;
   ELSIF ( cols_count_ = 1 AND  rec_in_out_ = 'OUT' ) THEN
      -- Method with single OUT-parameter, overwrite WHILE-loop + IF-test
      before_meth_ := 'BEGIN '||lf_;
   ELSIF ( count_arg_in_ = 1 AND  alt_attr_col_ IS NOT NULL ) THEN
      -- Attribute-string as single IN-parameter, but we handle it further down
      before_meth_ := 'BEGIN '||lf_;
   ELSE
      -- Remove trailing ELSIF....
      IF ( substr(before_meth_,length(before_meth_)-11) = '      ELSIF ' ) THEN
         before_meth_ := substr(before_meth_,1,length(before_meth_)-11);
      END IF;
      -- ...and complete statement
      before_meth_ := before_meth_||
                       '      END IF;'||lf_||
                       '   END LOOP;'||lf_;
   --
   END IF;
   IF ( alt_attr_col_ IS NOT NULL ) THEN
      -- Handle alternative attr-variables (!=ATTR_)
      -- First assign our attr_ to in-parameter
      extra_line_ := '   '||alt_attr_col_||' := attr_ ;'||lf_;
      -- ..then retrieve returnvalue and assign it to attr_
      extra_line1_ := lf_||'   attr_ := '||alt_attr_col_||';';
   ELSE
      extra_line_ := '   --'||lf_;
      extra_line1_ := lf_||'   --';
   END IF;
   before_meth_ := before_meth_||extra_line_;
   after_meth_  := extra_line1_||after_meth_;
   --
   -- Format argument-list
   arg_list_ := rtrim(rtrim(arg_list_,lf_),',');
   --
   -- Build complete statement
   stmt_ := start_proc_||before_meth_||
           '   '|| add_attr1_||UPPER(method_name_)||'('||rtrim(arg_list_,',')||')'||add_attr2_||
            after_meth_||end_proc_;
   RETURN stmt_;
END Get_Dynamic_Proc_Code;

PROCEDURE Create_One_Dynamic_Proc (
   intface_name_ IN VARCHAR2,
   execute_seq_  IN NUMBER)
IS
   stmt_ VARCHAR2(32000);
BEGIN
   stmt_ := Intface_Method_List_API.Get_Dynamic_Proc_Code(intface_name_, execute_seq_);
   @ApproveDynamicStatement(2011-05-19,jhmase)
   EXECUTE IMMEDIATE stmt_;
   trace_sys.message('TRACE >>>>>>>>>>>>>>>>>>>>>>> CREATED DYNAMIC PROCEDURE '||
                     Intface_Method_List_API.Get_Dynamic_Proc_Name(intface_name_, execute_seq_));
END Create_One_Dynamic_Proc;


PROCEDURE Create_All_Dynamic_Procs (
   intface_name_ IN VARCHAR2 )
IS 
   CURSOR get_data IS
      SELECT execute_seq
      FROM INTFACE_METHOD_LIST
      WHERE intface_name = intface_name_
      AND Get_Method_Type(method_name) = 'OTHER';
BEGIN
   FOR rec_ IN get_data LOOP
      Create_One_Dynamic_Proc(intface_name_, rec_.execute_seq );
   END LOOP;
END Create_All_Dynamic_Procs;


PROCEDURE Execute_Dynamic_Proc (
   info_        IN OUT VARCHAR2,
   objid_       IN OUT VARCHAR2,
   objversion_  IN OUT VARCHAR2,
   attr_        IN OUT VARCHAR2,
   arg_attr_    IN VARCHAR2,
   in_action_   IN VARCHAR2,
   method_name_ IN VARCHAR2 )
IS
   stmt_ VARCHAR2(32000);
BEGIN
   stmt_ := 'Begin '||method_name_||
              '(:info,:objid,:objversion,:attr,:arg_attr,:action); End;';
   @ApproveDynamicStatement(2010-06-10,jhmase)
   EXECUTE IMMEDIATE stmt_
   USING IN OUT info_,
         IN OUT objid_,
         IN OUT objversion_,
         IN OUT attr_,
         IN     arg_attr_,
         IN     in_action_ ;
END Execute_Dynamic_Proc;
   

PROCEDURE Show_Dynamic_Proc_Stmt (
   info_         IN OUT VARCHAR2,
   intface_name_ IN     VARCHAR2,
   execute_seq_  IN     NUMBER )
IS
   lf_  VARCHAR2(5) := chr(13)||chr(10);
   nl_  VARCHAR2(5) := chr(10);
BEGIN
   info_ := Intface_Method_List_API.Get_Dynamic_Proc_Code(intface_name_, execute_seq_);
   info_ := replace(info_,nl_, lf_);
END Show_Dynamic_Proc_Stmt ;

FUNCTION Get_Method_Type (
   method_name_ IN VARCHAR2 ) RETURN VARCHAR2
IS
   ret_value_ VARCHAR2(10);
BEGIN
   IF ( instr(method_name_,'.') != 0 ) THEN
      ret_value_ := 'OTHER';
   ELSE
      ret_value_ := 'NORMAL';
   END IF;
   RETURN ret_value_;
END Get_Method_Type;


PROCEDURE Drop_All_Dynamic_Proc (
   intface_name_ IN VARCHAR2 )
IS
   CURSOR get_data IS
      SELECT execute_seq
      FROM INTFACE_METHOD_LIST
      WHERE intface_name = intface_name_
      AND Get_Method_Type(method_name) = 'OTHER';
BEGIN
   FOR rec_ IN get_data LOOP
      Intface_Method_List_API.Drop_One_Dynamic_Proc(intface_name_, rec_.execute_seq);
   END LOOP;
END Drop_All_Dynamic_Proc ;


PROCEDURE Drop_One_Dynamic_Proc (
   intface_name_ IN VARCHAR2,
   execute_seq_  IN NUMBER )
IS
   stmt_      VARCHAR2(32000);
   proc_name_ VARCHAR2(100);
   test_      NUMBER := 0;
   CURSOR check_procedure IS
      SELECT 1
      FROM   user_procedures
      WHERE object_name = substr( upper(proc_name_), 1, instr( upper(proc_name_), '.' ) - 1 )
         AND procedure_name = substr( upper(proc_name_), instr( upper(proc_name_), '.' ) + 1 )
      UNION
      SELECT 1
      FROM user_objects
      WHERE object_name = upper(proc_name_)
        AND object_type = 'PROCEDURE';
BEGIN
   proc_name_ := Get_Dynamic_Proc_Name(intface_name_, execute_seq_);
   OPEN check_procedure;
   FETCH check_procedure INTO test_;
   IF check_procedure%NOTFOUND THEN
      CLOSE check_procedure;
      Error_SYS.Record_General(lu_name_, '');
   ELSE
      CLOSE check_procedure;
   END IF;
   stmt_ := 'DROP PROCEDURE '||proc_name_;
   @ApproveDynamicStatement(2009-11-27,nabalk)
   EXECUTE IMMEDIATE stmt_;
EXCEPTION WHEN OTHERS
   THEN NULL; -- May not be created
END Drop_One_Dynamic_Proc ;


-- Checks if column OBJID is mapped
-- This is vital for Migrations Jobs if you
-- need to RESTART the job
FUNCTION Is_Objid_Mapped (
   intface_name_ IN VARCHAR2 ) RETURN BOOLEAN
IS
   objid_ok_ BOOLEAN;
   dummy_    VARCHAR2(1);
   CURSOR get_data IS
      SELECT 'x'
      FROM intface_detail
      WHERE intface_name = intface_name_
      AND   column_name = 'OBJID'
      AND nvl(source_column, default_value) IS NOT NULL;
BEGIN
   OPEN  get_data;
   FETCH get_data INTO dummy_;
      objid_ok_ := get_data%FOUND;
   CLOSE get_data;
   --
   RETURN objid_ok_;   
END Is_Objid_Mapped;

PROCEDURE Find_Missing_Iid_Defaults (
   intface_name_ IN VARCHAR2 )
IS
   client_column_ VARCHAR2(200);
   db_detail_ ROWID;
   db_pos_ NUMBER;
   default_text_ VARCHAR2(2000);
   note_text_ VARCHAR2(2000);
   CURSOR get_db_columns IS
      SELECT column_name, flags, default_value, source_column, pos,
             ROWID det_rowid
      FROM intface_detail_tab
      WHERE intface_name = intface_name_
      AND column_name LIKE '%_DB'
      AND source_column IS NULL
      AND default_value IS NULL
      AND note_text IS NULL;
   CURSOR get_client_columns IS
      SELECT column_name, flags, default_value, source_column,
             ROWID det_rowid
      FROM intface_detail_tab
      WHERE intface_name =  intface_name_
      AND column_name = client_column_
      AND pos = db_pos_ -10
      AND source_column IS NULL
      AND default_value IS NULL;
BEGIN
   FOR dbrec_ IN get_db_columns LOOP
      -- Find DB-columns
      client_column_ := substr(dbrec_.column_name, 1,length(dbrec_.column_name)-3);
      db_detail_  := dbrec_.det_rowid;
      db_pos_     := dbrec_.pos;
      IF ( substr(dbrec_.flags,1,1) IN('P','K','M') ) THEN
         default_text_ := Language_SYS.Translate_Constant(lu_name_,' MANDDEF: <MISSING MANDATORY DEFAULT_VALUE>',Fnd_Session_API.Get_Language);
      ELSE
         default_text_ := Language_SYS.Translate_Constant(lu_name_,' OPTDEF: <MISSING OPTIONAL DEFAULT_VALUE>',Fnd_Session_API.Get_Language);
      END IF;
      note_text_ := Language_SYS.Translate_Constant(lu_name_,' NOTEDEF: Please decide use of Default Value. OPTIONALs may be removed ',Fnd_Session_API.Get_Language);
      FOR crec_ IN get_client_columns LOOP
         UPDATE intface_detail_tab
         SET default_value = ''''||default_text_||'''',
             note_text = note_text_
         WHERE ROWID = db_detail_;
      END LOOP;
   END LOOP;
END Find_Missing_Iid_Defaults;

-- Mark items that are mapped in SourceMapping
-- with POS from IntfaceDetail prefixed with hash.
-- The objective is to have a compressed attribute-string,
-- avoiding items that will never hold any value.
PROCEDURE Map_Attributes_To_Pos (
   intface_name_ IN VARCHAR2 )
IS
   view_name_ intface_method_list.view_name%TYPE;
   column_name_ intface_detail.column_name%TYPE;
   fixed_value_ intface_method_list_attrib_tab.fixed_value%TYPE;
   --
   CURSOR get_method_data IS
      SELECT a.intface_name, b.flags,
            nvl(a.view_name,'METHOD'||a.execute_seq) view_name, 
            b.column_name, a.execute_seq, a.method_name, b.ROWID
      FROM intface_method_list_attrib_tab b, intface_method_list a
      WHERE a.intface_name = intface_name_
      AND a.intface_name = b.intface_name
      AND a.execute_seq = b.execute_seq
      AND instr(nvl(b.fixed_value,'#'),'#') = 1
      AND ( (instr(b.on_new||b.on_modify,'TRUE') != 0 AND instr(a.method_name,'.')= 0) OR
            instr(a.method_name,'.') != 0);
   --
   CURSOR get_mapped_data IS
      SELECT pos, source_column, column_name, default_value
      FROM intface_detail
      WHERE intface_name = intface_name_
      AND column_name = column_name_
      AND (source_column IS NOT NULL OR default_value IS NOT NULL);
BEGIN
   FOR rec_ IN get_method_data LOOP
      view_name_    := rec_.view_name;
      fixed_value_  := NULL;
      column_name_ := view_name_||'.'||rec_.column_name;
      FOR mrec_ IN get_mapped_data LOOP
         fixed_value_ := '#'||mrec_.pos;
      END LOOP;
      column_name_ := rec_.column_name;
      FOR mrec_ IN get_mapped_data LOOP
         IF ( fixed_value_ IS NULL) THEN
            fixed_value_ := '#'||mrec_.pos;
         ELSE
            fixed_value_ := fixed_value_||';'||'#'||mrec_.pos;
         END IF;
      END LOOP;
      IF ( fixed_value_ IS NULL AND rec_.flags IN ('P','K')  ) THEN
         fixed_value_ := '#NULL'; -- dummy-value, needed on key-columns
      END IF;
      UPDATE intface_method_list_attrib_tab
      SET fixed_value = fixed_value_
      WHERE ROWID = rec_.ROWID;
   END LOOP;
END Map_Attributes_To_Pos;


PROCEDURE Unmap_Attributes_To_Pos (
   intface_name_ IN VARCHAR2 )
IS
   CURSOR get_data IS
      SELECT ROWID
      FROM intface_method_list_attrib_tab
      WHERE intface_name = intface_name_
      AND substr(fixed_value,1,1) = '#';
BEGIN
   FOR rec_ IN get_data LOOP
      UPDATE intface_method_list_attrib_tab
      SET fixed_value = NULL
      WHERE ROWID = rec_.ROWID;
   END LOOP;
END Unmap_Attributes_To_Pos;

FUNCTION Get_Objid_From_Key (
   view_name_    IN VARCHAR2,
   key_columns_  IN VARCHAR2,
   key_values_   IN VARCHAR2,
   date_format_  IN VARCHAR2 DEFAULT NULL ) RETURN VARCHAR2
IS
   stmt_     VARCHAR2(32000);
   appowner_ VARCHAR2(30) := Fnd_Session_API.Get_App_Owner;

   FUNCTION Get_Data_Type (
      column_name_ IN VARCHAR2 ) RETURN VARCHAR2
   IS
      data_type_ all_tab_columns.data_type%TYPE;
   BEGIN
      OPEN column_data_type_cursor_(appowner_, view_name_, column_name_);
      FETCH column_data_type_cursor_ INTO data_type_;
      CLOSE column_data_type_cursor_;
      RETURN data_type_;
   END Get_Data_Type;
   
   FUNCTION Get_Bind_Value (
      name_ IN OUT VARCHAR2 ) RETURN VARCHAR2
   IS
      bind_value_ VARCHAR2(2000);
      data_type_  VARCHAR2(200) := Get_Data_Type(name_);
   BEGIN
      IF    ( data_type_ = 'DATE' ) THEN
         bind_value_ := 'to_date( :'||name_||','||''''||NVL(date_format_,Client_SYS.date_format_)||''''||')';
      ELSIF ( data_type_ = 'NUMBER' ) THEN
         bind_value_ := 'to_number( :'||name_||')';
      ELSE
         bind_value_ := ':'||name_;
      END IF;
      RETURN bind_value_;
   END Get_Bind_Value;
 
   FUNCTION Get_Next_Key_Name (
      key_names_ IN OUT VARCHAR2,
      ptr_       IN OUT NUMBER, 
      name_      OUT    VARCHAR2 ) RETURN BOOLEAN
   IS
      pos_ NUMBER;
   BEGIN
      key_names_ := ltrim(key_names_,';');
      IF ( ptr_ IS NULL ) THEN
         pos_  := INSTR(key_names_, ';');
         name_ := SUBSTR(key_names_, 1, pos_ - 1);
         ptr_  := pos_ + 1;
         IF ( name_ IS NULL ) THEN
            RETURN FALSE;
         END IF;
      ELSE
         pos_  := INSTR(key_names_, ';', ptr_);
         name_ := SUBSTR(key_names_, ptr_, pos_ - ptr_);
         ptr_  := pos_ + 1;
         IF ( name_ IS NULL ) THEN
            RETURN FALSE;
         END IF;
      END IF;
      RETURN TRUE;
   END Get_Next_Key_Name;
  
   FUNCTION Create_Where_Stmt (
      keys_ IN VARCHAR2 ) RETURN VARCHAR2
   IS
      ptr_        NUMBER;
      name_       VARCHAR2(2000);
      bind_value_ VARCHAR2(2000);
      key_names_  VARCHAR2(32000);
      stmt2_      VARCHAR2(32000);
   BEGIN   
      key_names_ := ltrim(keys_,';');
      WHILE Get_Next_Key_Name(key_names_, ptr_, name_) LOOP
         bind_value_ := Get_Bind_Value(name_);
         IF ( stmt2_ IS NULL ) THEN
            stmt2_ := name_ || ' = ' || bind_value_;
         ELSE
            stmt2_ := stmt2_ || ' AND ' || name_ || ' = ' ||bind_value_;
         END IF;
      END LOOP;
      RETURN stmt2_;
   END Create_Where_Stmt;
   
   FUNCTION Execute_Stmt (
      stmt_       IN VARCHAR2,
      key_names_  IN VARCHAR2,
      key_values_ IN VARCHAR2 ) RETURN VARCHAR2
   IS
      TYPE parameter_list IS
         TABLE OF VARCHAR2(2000)
         INDEX BY BINARY_INTEGER;
      parameter_values_  parameter_list;
      parameter_names_   parameter_list;
      
      value_   VARCHAR2(2000);
      values_  VARCHAR2(32000);
      ptr_     NUMBER;
      idx_     BINARY_INTEGER;
      objid_   VARCHAR2(2000);
      
      cursor_  INTEGER;
      dummy_   INTEGER;
   BEGIN
      idx_ := 0;
      values_ := ltrim(key_values_,';');
      WHILE Get_Next_Key_Name(values_, ptr_, value_) LOOP
         IF ( value_ IS NOT NULL ) THEN
            idx_ := idx_ + 1;
            parameter_values_(idx_) := value_;
         END IF;
      END LOOP;
      idx_ := 0;
      values_ := ltrim(key_names_,';');
      WHILE Get_Next_Key_Name(values_, ptr_, value_) LOOP
         IF ( value_ IS NOT NULL ) THEN
            idx_ := idx_ + 1;
            parameter_names_(idx_) := value_;
         END IF;
      END LOOP;
      
      cursor_ := DBMS_SQL.OPEN_CURSOR;
      @ApproveDynamicStatement(2011-12-15,jhmase)
      DBMS_SQL.PARSE(cursor_, stmt_, DBMS_SQL.native);
      DBMS_SQL.DEFINE_COLUMN(cursor_, 1, objid_, 2000);      
      FOR i_ IN 1..idx_ LOOP
         DBMS_SQL.BIND_VARIABLE(cursor_, parameter_names_(i_), parameter_values_(i_), 2000);
      END LOOP;
      dummy_ := DBMS_SQL.EXECUTE_AND_FETCH(cursor_);
      DBMS_SQL.COLUMN_VALUE(cursor_, 1, objid_);     
      DBMS_SQL.CLOSE_CURSOR(cursor_);

      RETURN objid_;
   END Execute_Stmt;
   
BEGIN
   stmt_ := 'SELECT objid FROM ' || view_name_ || ' WHERE ' || Create_Where_Stmt(key_columns_);
   Trace_SYS.Message('TRACE >>>>>>>>>>>>>>>>>>>>>>> SQL: ' || stmt_);
   RETURN Execute_Stmt(stmt_, key_columns_, key_values_);
END Get_Objid_From_Key;










