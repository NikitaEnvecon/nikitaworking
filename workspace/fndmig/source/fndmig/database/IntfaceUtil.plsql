-----------------------------------------------------------------------------
--
--  Logical unit: IntfaceUtil
--  Component:    FNDMIG
--
--  IFS Developer Studio Template Version 3.0
--
--  Date    Sign    History
--  ------  ------  ---------------------------------------------------------
--  130313  UsRaLK Bug #107799 - Added method [Get_Schedule_Intface_Name_].
--  130118  ChMuLK Bug #103540 - Increased size of info_ in generated trigger.
--  121107  DuWilk bug #103619 - Modified Drop_IC_Table_ to drop view and revoke grant.
--  120704  WaWiLK Bug #103861 - Changed the insert dynamic sql statement in method Generate_Trigger_
--  100809  ChMuLK Bug #84970 - Certified the assert safe for dynamic SQLs
--  091127  NABALK Bug #84218 - Certified the assert safe for dynamic SQLs
--  081210  JHMASE Bug #79484 - Drop IC table fails with ORA-01403
--  080923  JHMASE Bug #76644 - Drop IC table when CREATE_TABLE_FROM_FILE job is removed
--  080404  JHMASE Bug #72850 - Made Update_All_Ic_Rows, Update_Rows_From_Conv_List and
--                              Make_Message_From_Attr protected
--  080313  JHMASE Bug #72447 - Added Update_All_Ic_Rows and Update_Rows_From_Conv_List
--  070828  TRLYNO Bug #67488 - KEEPTRIGGER rule implemented
--  061029  TRLYNO Bug #61381 - New procedure Make_Commit_
--  060808  TRLYNO Bug #59318 - FNDMIG bugfixes
--  060329  TRLYNO Bug #56862 - FNDMIG added functionality
--  060105  TRLYNO Bug #55479 - Added functionality in Data Migration
--  041222  JHMASE Bug #48786 - Make it work with double byte
--  041122  JHMASE Removed dependency to APPSRV
--  040507  TRLY   Bug #44483 - Replication of Object structures
--  040210  JHMASE Bug #42618 - Corrections
--  030708  TRLY   Prepared for new module FNDMI
-----------------------------------------------------------------------------

layer Core;

-------------------- PUBLIC DECLARATIONS ------------------------------------


-------------------- PRIVATE DECLARATIONS -----------------------------------

TYPE varchar2_tab IS TABLE OF VARCHAR2(200)
                     INDEX BY BINARY_INTEGER;

-------------------- LU SPECIFIC IMPLEMENTATION METHODS ---------------------

FUNCTION Find_Trigger_If___ (
   intface_name_ IN VARCHAR2,
   table_name_  IN VARCHAR2 ) RETURN VARCHAR2
IS
   stmt_          VARCHAR2(32000);
   cond_          VARCHAR2(20) := '      IF ';
   lf_            VARCHAR2(1) := chr(10);
   source_owner_  intface_header_tab.source_owner%TYPE;
   rule_string_   intface_rules_tab.rule_value%TYPE;
   CURSOR get_data IS
      SELECT a.column_name
      FROM all_tab_columns c,
           intface_method_list_attrib_tab a,
           intface_method_list_tab b
      WHERE b.intface_name = intface_name_
      AND UPPER(decode(instr(method_name,'.'),'0',method_name,
                     substr(method_name,1,instr(method_name,'.')-1)))
                        = REPLACE(UPPER(table_name_),'TAB','API')
      AND b.intface_name = a.intface_name
      AND b.execute_seq = a.execute_seq
      AND nvl(a.on_modify,'FALSE') = 'TRUE'
      AND c.owner = source_owner_
      AND c.table_name = upper(table_name_)
      AND c.column_name = a.column_name;
BEGIN
   -- Make IF-statement only when rule is active
   IF ( Intface_Rules_API.Rule_Is_Active(rule_string_, 'BUILDTRIGGERIF', intface_name_) ) THEN
      source_owner_ := nvl(Intface_Header_API.Get_Source_owner(intface_name_),
                           Fnd_Session_API.Get_App_Owner);
      FOR rec_ IN get_data LOOP
         stmt_ := stmt_||
         cond_ || '( ( :old.' || LOWER(rec_.column_name) || ' IS NULL AND :new.' || LOWER(rec_.column_name) || ' IS NULL )'||lf_||
         '         OR   ( ( :old.' || LOWER(rec_.column_name) || ' IS NOT NULL AND :new.' || LOWER(rec_.column_name) || ' IS NOT NULL )'||lf_||
         '            AND ( :old.' || LOWER(rec_.column_name) || ' = :new.' || LOWER(rec_.column_name) || ' ) ) )'||lf_;
         cond_ :=  '         AND ';
      END LOOP;
      IF ( cond_ = '         AND ' ) THEN
         stmt_ := stmt_||
         '      THEN'||lf_||
         '         RETURN;'||lf_||
         '      END IF;'||lf_;
      END IF;
   END IF;
   RETURN stmt_;
END Find_Trigger_If___;


PROCEDURE Compile_Trigger___ (
   stmt_        IN VARCHAR2,
   name_        IN VARCHAR2,
   error_names_ IN OUT VARCHAR2 )
IS
   cid_            NUMBER;
   compile_error_  EXCEPTION;
   PRAGMA          exception_init(compile_error_, -24344);
BEGIN
   cid_ := dbms_sql.open_cursor;
   @ApproveDynamicStatement(2011-05-19,jhmase)
   dbms_sql.parse(cid_, stmt_, dbms_sql.native);
   dbms_sql.close_cursor(cid_);
EXCEPTION
   WHEN compile_error_ THEN
      IF (dbms_sql.is_open(cid_)) THEN
         dbms_sql.close_cursor(cid_);
      END IF;
      IF error_names_ IS NULL THEN
         error_names_ := name_;
      ELSE
         error_names_ := error_names_||', '||name_;
      END IF;
   WHEN OTHERS THEN
      IF (dbms_sql.is_open(cid_)) THEN
         dbms_sql.close_cursor(cid_);
      END IF;
      RAISE;
END Compile_Trigger___;


-------------------- LU SPECIFIC PRIVATE METHODS ----------------------------

-------------------- LU SPECIFIC PROTECTED METHODS --------------------------

-- Get_Schedule_Intface_Name_
--   Locate the [Intface_Name] associated with the given [schedule_id_].
@UncheckedAccess
FUNCTION Get_Schedule_Intface_Name_ (
   schedule_id_ IN NUMBER ) RETURN VARCHAR2
IS
   CURSOR get_data IS
      SELECT Client_SYS.Get_Item_Value('INTFACE_NAME', par.value) intface_name
        FROM batch_schedule_par_pub par
       WHERE par.schedule_id = schedule_id_
         AND par.name = 'ATTR_';

   temp_ get_data%ROWTYPE;
BEGIN
   OPEN  get_data;
   FETCH get_data INTO temp_;
   CLOSE get_data;

   RETURN temp_.intface_name;
END Get_Schedule_Intface_Name_;


FUNCTION Get_Tech_Attrib_Value_ (
   lu_name_          IN VARCHAR2,
   technical_class_  IN VARCHAR2,
   attribute_        IN VARCHAR2,
   key_value_        IN VARCHAR2) RETURN VARCHAR2
IS
   TYPE TechAttrValue IS REF CURSOR;
   c1_  TechAttrValue;

   value_     VARCHAR2(100);
   --
   stmt_      VARCHAR2(2000) :=
      'SELECT DECODE(c.attrib_type_db, ''1'', TO_CHAR(value_no), value_text) ' ||
      'FROM   technical_attrib_std c, ' ||
      '       technical_specification_both b, ' ||
      '       technical_object_reference a ' ||
      'WHERE  a.lu_name           = :1 ' ||
      'AND    a.key_value         = :2 ' ||
      'AND    a.technical_class   = :3 ' ||
      'AND    a.technical_spec_no = b.technical_spec_no ' ||
      'AND    a.technical_class   = b.technical_class ' ||
      'AND    b.attribute         = :4 ' ||
      'AND    b.attribute         = c.attribute';
BEGIN
   @ApproveDynamicStatement(2009-11-27,nabalk)
   OPEN  c1_ FOR stmt_ USING lu_name_, key_value_, technical_class_, attribute_;
   FETCH c1_ INTO value_;
   CLOSE c1_;
   --
   RETURN value_;
END Get_Tech_Attrib_Value_ ;


PROCEDURE Generate_Trigger_ (
   intface_name_ IN VARCHAR2,
   table_name_  IN VARCHAR2,
   state_       IN VARCHAR2,
   on_insert_   IN VARCHAR2,
   on_update_   IN VARCHAR2,
   repl_mode_    IN VARCHAR2 )
IS
   temp_           VARCHAR2(32000);
   start_          VARCHAR2(32000);
   end_            VARCHAR2(32000);
   dummy_          VARCHAR2(10);
   status_         VARCHAR2(10);
   event_          VARCHAR2(32000) := NULL;
   stmt_           VARCHAR2(32000);
   trigger_        VARCHAR2(2000);
   error_triggers_ VARCHAR2(100);
   insert_         VARCHAR2(1) := 'I';
   update_         VARCHAR2(1) := 'U';
   cid_            NUMBER;
   from_value_     VARCHAR2(2000);
   repl_criteria_  VARCHAR2(2000);
   where_          VARCHAR2(2000);
   when_clause_    VARCHAR2(2000) := NULL;
   if_stmt_        VARCHAR2(32000) := NULL;
   rule_value_     VARCHAR2(200);

   CURSOR check_trigger(name_ IN VARCHAR2) IS
      SELECT 'x'
      FROM   user_triggers
      WHERE  trigger_name = name_;

BEGIN
   trace_sys.message('intface_name_ '||intface_name_);
   trace_sys.message('table_name_ '||table_name_);
   trace_sys.message('state_      '||state_);
   trace_sys.message('on_insert_  '||on_insert_);
   trace_sys.message('on_update_  '||on_update_);
   trace_sys.message('repl_mode_ '||repl_mode_);
   trigger_ := 'RPL_'||substr(intface_name_,1,26);
   IF on_insert_ = 'TRUE' THEN
      event_ := 'INSERT';
   END IF;
   IF on_update_ = 'TRUE' THEN
      IF event_ IS NULL THEN
         event_ := 'UPDATE';
      ELSE
         event_ := 'INSERT OR UPDATE';
      END IF;
      if_stmt_ := Find_Trigger_If___(intface_name_, table_name_);
   END IF;
   IF state_ = 'TRUE' THEN
      status_ := 'ENABLE';
   ELSE
      status_ := 'DISABLE';
   END IF;
   from_value_ := Intface_Header_API.Get_From_Value(intface_name_);
   repl_criteria_ := Intface_Header_API.Get_Repl_Criteria(intface_name_);
   where_ := Intface_Header_API.Get_Trigger_When(intface_name_);
   IF ( where_ IS NOT NULL ) THEN
      when_clause_ := ' WHEN (' ||where_||' )'||chr(10);
   ELSE
      when_clause_ := ' WHEN ( new.'||repl_criteria_||' = '''||from_value_||''''||where_||' )'||chr(10);
   END IF;
   --
   start_ := 'CREATE OR REPLACE TRIGGER '||
          trigger_||chr(10)||'AFTER '||event_||' ON '||table_name_||
          ' FOR EACH ROW '||chr(10)||
          when_clause_||
          'DECLARE'||chr(10)||'   log_id_ number; '
           ||chr(10)||'   event_short_ VARCHAR2(2000);'||chr(10)||'   info_ VARCHAR2(32000);'
           ||chr(10)||'BEGIN ';
   temp_ := chr(10)||'   SELECT Repl_log_Seq.NEXTVAL INTO log_id_ FROM DUAL;'||chr(10)||
            '   IF INSERTING THEN '||chr(10)||'      event_short_ := '''||insert_||''';'||chr(10)||
            '   ELSIF UPDATING THEN '||chr(10)||'      event_short_ := '''||update_||''';'||chr(10)||
            if_stmt_||
            '   END IF;'||chr(10)||
            '   INSERT INTO Intface_Replication_Log_tab (Log_Seq,Intface_Name,Trigger_Type,Repl_Rowid,Log_Date,Rowversion) VALUES (log_id_,'''||intface_name_||''',event_short_,:new.rowid,SYSDATE,SYSDATE);';
   end_ := '';
   IF repl_mode_ = '2' THEN
      end_ := chr(10)||'   info_:= '||'''ROWID='''||'||:new.rowid;';
      end_ := end_||chr(10)||'   Intface_Header_API.Start_job(info_, '||'''NOW'''||','''||intface_name_||''');';
   END IF;
   end_ := end_||chr(10)||'END;';
   stmt_ :=  start_||temp_||end_;
   IF ( Intface_Rules_API.Rule_Is_Active(rule_value_, 'KEEPTRIGGER', intface_name_ ) ) THEN
      -- Customized trigger-code. Just Enable or Disable the trigger
      open check_trigger(trigger_);
      fetch check_trigger into dummy_;
      IF check_trigger%FOUND THEN
         stmt_ := 'ALTER TRIGGER '||trigger_||' '||status_;
         trace_sys.message(substr(stmt_,1,250));
         cid_ := dbms_sql.open_cursor;
         @ApproveDynamicStatement(2009-11-27,nabalk)
         dbms_sql.parse(cid_, stmt_, dbms_sql.native);
         dbms_sql.close_cursor(cid_);
      END IF;
      close check_trigger;
   ELSIF (on_insert_='FALSE' AND on_update_ = 'FALSE') OR repl_mode_ NOT IN ('2','3') THEN
      open check_trigger(trigger_);
      fetch check_trigger into dummy_;
      if check_trigger%FOUND then
         stmt_ := 'DROP TRIGGER '||trigger_;
         trace_sys.message(substr(stmt_,1,250));
         cid_ := dbms_sql.open_cursor;
         @ApproveDynamicStatement(2009-11-27,nabalk)
         dbms_sql.parse(cid_, stmt_, dbms_sql.native);
         dbms_sql.close_cursor(cid_);
      end if;
      close check_trigger;
   ELSIF stmt_ IS NOT NULL AND repl_criteria_ IS NOT NULL AND from_value_ IS NOT NULL THEN
      -- Generate standard triggercode.
      Intface_Detail_API.trace_long_msg(stmt_);
      Compile_Trigger___(stmt_, trigger_, error_triggers_);
      IF error_triggers_ IS NOT NULL THEN
         Error_SYS.Record_General('IntfaceUtil', 'COMPILE_ERRORS: Compilation errors for triggers :P1', error_triggers_);
      END IF;
      IF status_ = 'DISABLE' THEN
         Assert_SYS.Assert_Is_Trigger(trigger_);
         stmt_ := 'ALTER TRIGGER '||trigger_||' '||status_;
         trace_sys.message(substr(stmt_,1,250));
         cid_ := dbms_sql.open_cursor;
         @ApproveDynamicStatement(2009-11-27,nabalk)
         dbms_sql.parse(cid_, stmt_, dbms_sql.native);
         dbms_sql.close_cursor(cid_);
      END IF;
   END IF;
END Generate_Trigger_;


PROCEDURE Make_Message_From_Attr_ (
   message_      IN OUT VARCHAR2,
   attr_         IN     VARCHAR2 )
IS
   ptr_      NUMBER;
   name_     VARCHAR2(30);
   value_    VARCHAR2(2000);
   buf_      VARCHAR2(32000);
   msg_name_ VARCHAR2(100);
BEGIN
   ptr_ := NULL;
   WHILE (Client_SYS.Get_Next_From_Attr(attr_, ptr_, name_, value_)) LOOP
      IF (name_ = 'MESSAGE_NAME') THEN
         buf_ := Message_SYS.Construct('');
         msg_name_ := value_;
      ELSE
         Message_SYS.Add_Attribute(buf_, name_,value_);
      END IF;
   END LOOP;
   message_ := Message_SYS.Construct(msg_name_);
   Message_SYS.Add_Attribute(message_,'B',buf_);
END Make_Message_From_Attr_;


PROCEDURE Update_All_Ic_Rows_ (
   table_name_    IN VARCHAR2,
   update_column_ IN VARCHAR2,
   update_value_  IN VARCHAR2 )
IS
   stmt_ VARCHAR2(32000);
BEGIN
   IF ( substr(table_name_,1,3) != 'IC_') THEN
      Error_SYS.Record_General(lu_name_, ' UPDERR: You cannot update other tables than IC-tables');
   END IF;
   --
   Assert_SYS.Assert_Is_Table(table_name_);
   Assert_SYS.Assert_Is_Table_Column(table_name_, update_column_);
   stmt_ := ' UPDATE '||table_name_||' SET '||update_column_||' = :value';
   --
   Intface_Detail_API.Trace_Long_Msg(stmt_);
   --
   @ApproveDynamicStatement(2009-11-27,nabalk)
   EXECUTE IMMEDIATE stmt_
   USING IN update_value_;
END Update_All_Ic_Rows_;


PROCEDURE Update_Rows_From_Conv_List_ (
   table_name_    IN VARCHAR2,
   update_column_ IN VARCHAR2,
   source_column_ IN VARCHAR2,
   conv_list_id_  IN VARCHAR2 )
IS
   stmt_            VARCHAR2(32000);
   conv_list_value_ VARCHAR2(2000);
BEGIN
   IF ( substr(table_name_,1,3) != 'IC_') THEN
      Error_SYS.Record_General(lu_name_, ' UPDERR: You cannot update other tables than IC-tables');
   END IF;
   --
   IF (instr(conv_list_id_,'|') != 0 ) THEN
      conv_list_value_ := conv_list_id_;
   ELSIF (instr(conv_list_id_,'''') != 0 ) THEN
      conv_list_value_ := conv_list_id_;
   ELSE
      conv_list_value_ := ''''||conv_list_id_||'''';
   END IF;
   stmt_ := ' UPDATE '||table_name_||' a '||
            ' SET a.'||update_column_||' = (SELECT b.new_value '||
            ' FROM intface_conv_list_cols_tab b'||
            ' WHERE b.conv_list_id = '||conv_list_value_||
            ' AND a.'||source_column_||' = b.old_value )'||
            ' WHERE EXISTS (SELECT '||''''||'x'||''''||
            ' FROM intface_conv_list_cols_tab b'||
            ' WHERE b.conv_list_id = '||conv_list_value_||
            ' AND a.'||source_column_||' = b.old_value)'||
            ' AND a.'||update_column_||' IS NULL';
   --
   Intface_Detail_API.Trace_Long_Msg(stmt_);
   --
   @ApproveDynamicStatement(2011-05-19,jhmase)
   EXECUTE IMMEDIATE stmt_;
EXCEPTION
   WHEN OTHERS THEN
      trace_sys.message(SQLERRM);
END Update_Rows_From_Conv_List_;


PROCEDURE Drop_IC_Table_ (
   intface_name_ IN VARCHAR2 )
IS
   table_name_  VARCHAR2(100) := 'IC_' || intface_name_ || '_TAB';
   backup_name_ VARCHAR2(100) := 'IC_' || intface_name_ || '_BKP';
   view_name_   VARCHAR2(30)   := 'IC_' || intface_name_;
   stmt_        VARCHAR2(200);

   FUNCTION Is_IC_Table RETURN BOOLEAN
   IS
   BEGIN
      -- Check if column IC_ROW_NO is present
      IF Database_SYS.Column_Exist(UPPER(table_name_),'IC_ROW_NO') THEN
         RETURN TRUE;
      ELSE
         RETURN FALSE;
      END IF;
   END Is_IC_Table;
BEGIN
   IF ( Is_IC_Table() ) THEN
      BEGIN
         -- Check backup table
         IF Database_SYS.Table_Exist(UPPER(backup_name_)) THEN
            stmt_ := 'DROP TABLE ' || backup_name_;
            Trace_SYS.Message(stmt_);
            @ApproveDynamicStatement(2009-11-27,nabalk)
            EXECUTE IMMEDIATE stmt_;
         ELSE
            Trace_SYS.Message('Backup table '||backup_name_||' not found');
         END IF;
      EXCEPTION
         WHEN OTHERS THEN
            Trace_SYS.Message(SQLERRM);
      END;
      BEGIN
         stmt_ := 'REVOKE SELECT ON '||view_name_||' FROM IFSSYS';
         Trace_SYS.Message(stmt_);
         @ApproveDynamicStatement(2012-11-07,duwilk)
         EXECUTE IMMEDIATE stmt_;
         stmt_ := 'DROP VIEW ' || view_name_;
         Trace_SYS.Message(stmt_);
         @ApproveDynamicStatement(2012-11-07,duwilk)
         EXECUTE IMMEDIATE stmt_;
         stmt_ := 'DROP TABLE ' || table_name_;
         Trace_SYS.Message(stmt_);
         @ApproveDynamicStatement(2009-11-27,nabalk)
         EXECUTE IMMEDIATE stmt_;
      EXCEPTION
         WHEN OTHERS THEN
            Trace_SYS.Message(SQLERRM);
      END;
   END IF;
END Drop_IC_Table_;


PROCEDURE Drop_Trg_And_Pkg_ (
   intface_name_ IN VARCHAR2 )
IS
   stmt_         VARCHAR2(200);
   test_         NUMBER := 0;
   package_name_ VARCHAR2(100);
   no_package_   EXCEPTION;
   CURSOR check_package IS
      SELECT 1 FROM user_objects
      WHERE object_name = upper(package_name_)
      AND object_type = 'PACKAGE';
BEGIN
   BEGIN
      package_name_ := 'RPL_'||intface_name_||'_I';
      OPEN check_package;
      FETCH check_package INTO test_;
      IF check_package%NOTFOUND THEN
         CLOSE check_package;
         RAISE no_package_;
      ELSE
         CLOSE check_package;
      END IF;
      stmt_ := 'DROP PACKAGE ' || package_name_;
      Trace_SYS.Message(stmt_);
      @ApproveDynamicStatement(2010-08-09,chmulk)
      EXECUTE IMMEDIATE stmt_;
   EXCEPTION
      WHEN no_package_ THEN
         Trace_SYS.Message('NO PKG ERROR : Package '||package_name_||' not found');
      WHEN OTHERS THEN
         Trace_SYS.Message(SQLERRM);
   END;
   BEGIN
      package_name_ := 'RPL_' || intface_name_ || '_U';
      OPEN check_package;
      FETCH check_package INTO test_;
      IF check_package%NOTFOUND THEN
         CLOSE check_package;
         RAISE no_package_;
      ELSE
         CLOSE check_package;
      END IF;
      stmt_ := 'DROP PACKAGE RPL_' || package_name_;
      Trace_SYS.Message(stmt_);
      @ApproveDynamicStatement(2010-08-09,chmulk)
      EXECUTE IMMEDIATE stmt_;
   EXCEPTION
      WHEN no_package_ THEN
         Trace_SYS.Message('NO PKG ERROR : Package ' || package_name_ || ' not found');
      WHEN OTHERS THEN
         Trace_SYS.Message(SQLERRM);
   END;
END Drop_Trg_And_Pkg_;


-------------------- LU SPECIFIC PUBLIC METHODS -----------------------------

PROCEDURE Insert_Or_Update (
   info_         IN OUT VARCHAR2,
   intface_name_ IN     VARCHAR2 )
IS
BEGIN
   Intface_Detail_API.Insert_Or_Update(info_, intface_name_);
END Insert_Or_Update;


PROCEDURE Insert_By_Method_New (
   info_         IN OUT VARCHAR2,
   intface_name_ IN     VARCHAR2 )
IS
BEGIN
   Intface_Detail_API.Insert_By_Method_New(info_, intface_name_);
END Insert_By_Method_New;


PROCEDURE Check_By_Method_New (
   info_         IN OUT VARCHAR2,
   intface_name_ IN     VARCHAR2 )
IS
BEGIN
   Intface_Detail_API.Check_By_Method_New(info_, intface_name_);
END Check_By_Method_New;


PROCEDURE Create_Output_File (
   info_         IN OUT VARCHAR2,
   intface_name_ IN     VARCHAR2 )
IS
BEGIN
   Intface_Detail_API.Create_Output_File(info_, intface_name_);
END Create_Output_File;


PROCEDURE Migrate_Source_Data (
   info_         IN OUT VARCHAR2,
   intface_name_ IN     VARCHAR2 )
IS
BEGIN
   Intface_Method_List_API.Migrate_Source_Data(info_, intface_name_);
END Migrate_Source_Data;


PROCEDURE Create_Table_From_File (
   info_         IN OUT VARCHAR2,
   intface_name_ IN     VARCHAR2 )
IS
BEGIN
   Intface_Method_List_API.Create_Table_From_File(info_, intface_name_);
END Create_Table_From_File;


PROCEDURE Fndmig_Export (
   info_         IN OUT VARCHAR2,
   intface_name_ IN     VARCHAR2 )
IS
BEGIN
   Intface_Header_API.Fndmig_Export(info_, intface_name_);
END Fndmig_Export;


PROCEDURE Fndmig_Import (
   info_         IN OUT VARCHAR2,
   intface_name_ IN     VARCHAR2 )
IS
BEGIN
   Intface_Header_API.Fndmig_Import(info_, intface_name_);
END Fndmig_Import;


PROCEDURE Replication (
   info_         IN OUT VARCHAR2,
   intface_name_ IN     VARCHAR2 )
IS
BEGIN
   Intface_Method_List_API.Migrate_Source_Data(info_, intface_name_);
END Replication;


PROCEDURE Replic_Data_Out (
   info_         IN OUT VARCHAR2,
   intface_name_ IN     VARCHAR2 )
IS
BEGIN
   Intface_Repl_Maint_Util_API.Replic_Data_Out(info_, intface_name_);
END Replic_Data_Out;


PROCEDURE Quick_Reports_Out (
   info_         IN OUT VARCHAR2,
   intface_name_ IN     VARCHAR2 )
IS
BEGIN
   Intface_Quick_Report_Util_API.Quick_Reports_Out(info_, intface_name_);
END Quick_Reports_Out;



