-----------------------------------------------------------------------------
--
--  Logical unit: IntfaceReplMaintUtil
--  Component:    FNDMIG
--
--  IFS Developer Studio Template Version 3.0
--
--  Date    Sign    History
--  ------  ------  ---------------------------------------------------------
--  130313  UsRaLK Bug #107799 - Changed references to scheduled task instead of the server process.
--  100811  ChMu   Certified the assert safe for dynamic SQLs (Bug#84970).
--  060209  TRLYNO Bug #55643 - Change view-definitions from user_ to dba_
--  041116  JHMASE Bug #48018 - Moved INTFACE_REPL_EXPORT_INFO view to IntfHead.apy
--  040507  TRLY  Created
--                Bug #44483 - Replication of Object structure
-----------------------------------------------------------------------------

layer Core;

-------------------- PUBLIC DECLARATIONS ------------------------------------

lf_      CONSTANT VARCHAR2(1)  := chr(10);
TYPE number_tabtype IS
   TABLE OF NUMBER
   INDEX BY BINARY_INTEGER;
TYPE varchar_tabtype IS
   TABLE OF VARCHAR2(2000)
   INDEX BY BINARY_INTEGER;
TYPE rowid_tabtype IS
   TABLE OF ROWID
   INDEX BY BINARY_INTEGER;
TYPE log_table IS RECORD(
   key_attr       varchar_tabtype,
   pos            number_tabtype,
   start_pos      number_tabtype,
   trigger_type   varchar_tabtype,
   Rowid          rowid_tabtype);

-------------------- PRIVATE DECLARATIONS -----------------------------------


-------------------- LU SPECIFIC IMPLEMENTATION METHODS ---------------------

PROCEDURE Process_Pl_Table___ (
   repl_id_   IN VARCHAR2,
   log_count_ IN NUMBER,
   log_table_ IN log_table)
IS
BEGIN
   FOR i IN 1..log_count_ LOOP
      IF ( i = 1 ) THEN
         Replic_Data_Automatic_(
            repl_id_,
            log_table_.trigger_type(i),
            log_table_.key_attr(i));
      END IF;
      --
      DELETE
      FROM intface_repl_out_log_tab
      WHERE rowid = log_table_.rowid(i);
   END LOOP;
END Process_Pl_Table___;


-------------------- LU SPECIFIC PRIVATE METHODS ----------------------------

-------------------- LU SPECIFIC PROTECTED METHODS --------------------------

PROCEDURE Process_Log_Table_ (
   info_         IN OUT VARCHAR2,
   intface_name_ IN     VARCHAR2 )
IS
   old_key_attr_ VARCHAR2(2000);
   key_attr_     VARCHAR2(2000);
   repl_id_      intface_header_tab.intface_name%TYPE;
   log_count_    NUMBER;
   start_count_  NUMBER;
   start_pos_    NUMBER;
   log_table_    log_table;
   --
   CURSOR get_data IS
      SELECT key_attr, pos , start_pos,  trigger_type, rowid
      FROM intface_repl_out_log_tab
      WHERE intface_name = intface_name_
      ORDER BY key_attr, trigger_type, pos;
   --
BEGIN
   start_count_ := 0;
   log_count_ := 0;
   repl_id_ := intface_name_;
   FOR rec_ IN get_data LOOP
      key_attr_ := rec_.key_attr;
      IF (nvl(old_key_attr_, key_attr_) != key_attr_ ) THEN
         IF ( start_pos_ IS NULL ) THEN
            Process_Pl_Table___(repl_id_, log_count_, log_table_);
         ELSIF ( start_pos_/10 = start_count_ ) THEN
            -- Complete structure for insert
            Process_Pl_Table___(repl_id_, log_count_, log_table_);
         ELSIF ( start_count_ = 0 ) THEN
            -- Insert performed earlier, perform update now
            log_table_.trigger_type(1) := 'U';
            Process_Pl_Table___(repl_id_, log_count_, log_table_);
         END IF;
         start_count_ := 0;
         log_count_ := 0;
      END IF;
      log_count_ := log_count_ +1;
      -- Insert data for this key-attr into pl-table
      log_table_.key_attr(log_count_) := key_attr_;
      log_table_.pos(log_count_) := rec_.pos;
      log_table_.start_pos(log_count_) := rec_.start_pos;
      log_table_.trigger_type(log_count_) := rec_.trigger_type;
      log_table_.rowid(log_count_) := rec_.rowid;
      IF ( rec_.start_pos IS NOT NULL ) THEN
         IF ( rec_.trigger_type = 'I' AND
            rec_.pos <= rec_.start_pos ) THEN
            -- Keep track of number of inserts up to start_pos
            start_count_ := start_count_ + 1;
            start_pos_ := rec_.start_pos;
         END IF;
      END IF;
      --
      old_key_attr_ := rec_.key_attr;
   END LOOP;
   --
   IF ( start_pos_ IS NULL ) THEN
      Process_Pl_Table___(repl_id_, log_count_, log_table_);
   ELSIF ( start_pos_/10 = start_count_ ) THEN
      -- Complete structure for insert
      Process_Pl_Table___(repl_id_, log_count_, log_table_);
   ELSIF ( start_count_ = 0 ) THEN
      -- Insert performed earlier, perform update now
      log_table_.trigger_type(1) := 'U';
      Process_Pl_Table___(repl_id_, log_count_, log_table_);
   END IF;
   Client_SYS.Add_Info(lu_name_, 'LOGOK: Log table with :P1 rows succefully processed for :P2 ', to_char(log_count_), intface_name_);
   info_ := Client_Sys.Get_All_Info;
END Process_Log_Table_;


PROCEDURE Replic_Data_Automatic_ (
   intface_name_ IN VARCHAR2,
   trigger_type_ IN VARCHAR2,
   attr_         IN VARCHAR2 )
IS
   stmt_    VARCHAR2(32000);
   err_msg_ VARCHAR2(2000);
   package_name_ VARCHAR2(100) := 'RPL_'||intface_name_||'_'||trigger_type_;

BEGIN
   --
   Assert_SYS.Assert_Is_Package(package_name_);
   stmt_ := 'BEGIN '|| package_name_ ||'.Create_Message(:attr_);End;';

   Trace_SYS.Message(stmt_);

   --safe due to check Assert_SYS.Assert_Is_Package
   @ApproveDynamicStatement(2010-08-11,chmulk)
   EXECUTE IMMEDIATE stmt_
   USING IN attr_;
EXCEPTION
   WHEN OTHERS THEN
      err_msg_ := replace(SQLERRM,'ORA-','ORA');
      Error_SYS.Record_General( 'IntfaceReplMaintUtil' , 'EXECERR: Error occured - :P1 ', err_msg_ );
END Replic_Data_Automatic_;


-------------------- LU SPECIFIC PUBLIC METHODS -----------------------------

PROCEDURE Replic_Automatic_Batch (
   attr_         IN VARCHAR2 )
IS
BEGIN
   Replic_Data_Automatic_(Client_SYS.Get_Item_Value('REPL_ID',attr_),
                          Client_SYS.Get_Item_Value('TRIGGER_TYPE',attr_),
                          attr_);
END Replic_Automatic_Batch;


PROCEDURE Replic_Data_Out (
   info_         IN OUT VARCHAR2,
   intface_name_ IN     VARCHAR2 )
IS
   attr_ VARCHAR2(2000);
   mode_ intface_header.replication_mode%TYPE;
   trigger_type_ VARCHAR2(20);
   err_msg_ VARCHAR2(2000);
BEGIN
   attr_ := info_;
   info_ := NULL;
   mode_ := Client_SYS.Get_Item_Value('MODE',attr_);
   trigger_type_ := Client_SYS.Get_Item_Value('INFO',attr_);
   IF ( mode_ = '3' ) THEN
      Process_Log_Table_(info_, intface_name_);
   ELSIF ( mode_ = '1' ) THEN
      attr_ := null;
      Replic_Data_Automatic_(intface_name_, trigger_type_,attr_);
      Client_SYS.Add_Info(lu_name_, 'REPLOK: Procedure :P1 succefully processed ', 'RPL_'||intface_name_||'_'||trigger_type_);
      info_ := Client_Sys.Get_All_Info;
   END IF;
   Intface_Job_Detail_API.Format_Info(info_);
EXCEPTION
   WHEN OTHERS THEN
@ApproveTransactionStatement(2014-04-02,mabose)
      ROLLBACK;
      err_msg_ := replace(SQLERRM,'ORA-','ORA');
      Client_SYS.Add_Info(lu_name_, 'REPLFAIL: Replication job :P1 failed - :P2 ',intface_name_, err_msg_);
      info_ := Client_Sys.Get_All_Info;
      Intface_Job_Detail_API.Format_Info(info_);
END Replic_Data_Out;

@UncheckedAccess
FUNCTION Get_Source_Error (
   object_name_ IN VARCHAR2 ) RETURN VARCHAR2
IS
   rec_sep_ VARCHAR2(2) := chr(13)||chr(10);
   error_text_ VARCHAR2(2000);
   CURSOR get_error IS
      SELECT distinct text
      FROM user_errors
      WHERE name = object_name_;
BEGIN
   FOR rec_ IN get_error LOOP
      IF ( nvl(length(error_text_),0) + length(rec_.text) < 2000 ) THEN
         error_text_ := error_text_||rec_.text||lf_;
      ELSE
         error_text_ := substr(error_text_||rec_.text,1,2000);
      END IF;
   END LOOP;
   error_text_ := replace(error_text_,lf_,rec_sep_);
   RETURN error_text_;
END Get_Source_Error;


PROCEDURE Show_Source_Text (
   source_text_ IN OUT VARCHAR2,
   object_name_ IN     VARCHAR2 )
IS
   rec_sep_ VARCHAR2(2) := chr(13)||chr(10);
   CURSOR get_data IS
      SELECT replace(text,lf_,rec_sep_) text
      FROM user_source
      WHERE name = object_name_
      AND type IN ('TRIGGER','PACKAGE BODY')
      ORDER BY line;
BEGIN
   source_text_ := NULL;
   FOR rec_ IN get_data LOOP
      IF ( nvl(length(source_text_),0) + length(rec_.text) < 32000 ) THEN
         source_text_ := source_text_||rec_.text;
      ELSE
         source_text_ := substr(source_text_||rec_.text,1,32000);
      END IF;
   END LOOP;
END Show_Source_Text;


FUNCTION Are_Packages_Valid (
   intface_name_ IN VARCHAR2 ) RETURN VARCHAR2
IS
   status_ VARCHAR2(5);
BEGIN
   status_ :=  Are_Objects_Valid(intface_name_,'PACKAGE BODY');
   RETURN status_;
END Are_Packages_Valid;


FUNCTION Are_Triggers_Valid (
   intface_name_ IN VARCHAR2 ) RETURN VARCHAR2
IS
   status_ VARCHAR2(5);
BEGIN
   status_ :=  Are_Objects_Valid( intface_name_,'TRIGGER');
   RETURN status_;
END Are_Triggers_Valid;


FUNCTION Are_Objects_Valid (
   intface_name_ IN VARCHAR2,
   object_type_  IN VARCHAR2 ) RETURN VARCHAR2
IS
   status_ VARCHAR2(5) := 'TRUE';
   count_ NUMBER := 0;
   --
   CURSOR get_data IS
      SELECT status
      FROM intface_repl_db_objects
      WHERE intface_name = intface_name_
      AND object_type LIKE object_type_;
BEGIN
   -- Check if status is VALID for all objects
   FOR rec_ IN get_data LOOP
      count_ := count_ + 1;
      IF ( rec_.status = 'INVALID' ) THEN
         status_ := 'FALSE';
         EXIT;
      END IF;
   END LOOP;
   -- No objects generated, return FALSE
   IF ( count_ = 0 ) THEN
      status_ := 'FALSE';
   END IF;
   RETURN status_;
END Are_Objects_Valid;


FUNCTION Are_Triggers_Enabled (
   intface_name_ IN VARCHAR2 ) RETURN VARCHAR2
IS
   status_ VARCHAR2(5) := 'TRUE';
   count_ NUMBER := 0;
   --
   CURSOR get_data IS
      SELECT status
      FROM intface_repl_db_objects
      WHERE intface_name = intface_name_
      AND object_type = 'TRIGGER';
BEGIN
   -- Check if status is VALID for all objects
   FOR rec_ IN get_data LOOP
      count_ := count_ + 1;
      IF ( rec_.status != 'ENABLED' ) THEN
         status_ := 'FALSE';
         EXIT;
      END IF;
   END LOOP;
   -- No objects generated, return FALSE
   IF ( count_ = 0 ) THEN
      status_ := 'FALSE';
   END IF;
   RETURN status_;
END Are_Triggers_Enabled;


FUNCTION Are_Triggers_Disabled (
   intface_name_ IN VARCHAR2 ) RETURN VARCHAR2
IS
   status_ VARCHAR2(5) := 'TRUE';
   count_ NUMBER := 0;
   --
   CURSOR get_data IS
      SELECT status
      FROM intface_repl_db_objects
      WHERE intface_name = intface_name_
      AND object_type = 'TRIGGER';
BEGIN
   -- Check if status is VALID for all objects
   FOR rec_ IN get_data LOOP
      count_ := count_ + 1;
      IF ( rec_.status != 'DISABLED' ) THEN
         status_ := 'FALSE';
         EXIT;
      END IF;
   END LOOP;
   -- No objects generated, return FALSE
   IF ( count_ = 0 ) THEN
      status_ := 'FALSE';
   END IF;
   RETURN status_;
END Are_Triggers_Disabled;


FUNCTION Count_Server_Processes (
   intface_name_ IN VARCHAR2 ) RETURN NUMBER
IS
   proc_count_ NUMBER := 0;
   CURSOR get_data IS
      SELECT 'x' dummy
        FROM batch_schedule_task job, batch_schedule_par_pub par
       WHERE job.schedule_id = par.schedule_id
         AND par.name = 'ATTR_'
         AND Client_SYS.Get_Item_Value('INTFACE_NAME', par.value) = intface_name_;
BEGIN
   FOR rec_ IN get_data LOOP
      proc_count_ := proc_count_ +1;
   END LOOP;
   RETURN proc_count_;
END Count_Server_Processes;


PROCEDURE Check_Update_Allowed (
   intface_name_ IN VARCHAR2 )
IS
   enabled_  VARCHAR2(5) := Are_Triggers_Enabled(intface_name_);
BEGIN
   IF ( enabled_ = 'TRUE' ) THEN
      Error_SYS.Record_General( lu_name_, 'NOUPDATE: You can not update :P1 beacuse replication is in process. All triggers are enabled. ', intface_name_);
   END IF;
END Check_Update_Allowed;


FUNCTION Are_Objects_Generated (
   intface_name_ IN VARCHAR2,
   object_type_  IN VARCHAR2 ) RETURN VARCHAR2
IS
   status_ VARCHAR2(5) := 'FALSE';
   CURSOR get_objects IS
      SELECT 'x'
      FROM intface_repl_db_objects
      WHERE intface_name = intface_name_
      AND object_type = object_type_;
BEGIN
   FOR rec_ IN get_objects LOOP
      status_ := 'TRUE';
   END LOOP;
   RETURN status_;
END Are_Objects_Generated;


FUNCTION Where_Exists (
   intface_name_ IN VARCHAR2 ) RETURN VARCHAR2
IS
   status_ VARCHAR2(5) := 'FALSE';
   CURSOR get_where IS
      SELECT 'x'
      FROM intface_repl_structure
      WHERE intface_name = intface_name_
      AND INSTR(on_insert||on_update,'TRUE') != 0
      AND ( ( parent_seq IS NULL AND
              view_name != 'DUAL'
              AND select_where IS NOT NULL) OR
            (select_where IS NOT NULL));
BEGIN
   FOR rec_ IN get_where LOOP
      status_ := 'TRUE';
   END LOOP;
   RETURN status_;
END Where_Exists;


FUNCTION Serv_Proc_Exists (
   intface_name_ IN VARCHAR2 ) RETURN VARCHAR2
IS
   temp_ VARCHAR2(5);
   CURSOR get_data IS
      SELECT 'TRUE'
        FROM batch_schedule_task job, batch_schedule_par_pub par
       WHERE job.schedule_id = par.schedule_id
         AND par.name = 'ATTR_'
         AND Client_SYS.Get_Item_Value('INTFACE_NAME', par.value) = intface_name_;
BEGIN
   OPEN  get_data;
   FETCH get_data INTO temp_;
   IF get_data%NOTFOUND THEN
      temp_ := 'FALSE';
   END IF;
   CLOSE get_data;
   RETURN temp_;
END Serv_Proc_Exists;



