-----------------------------------------------------------------------------
--
--  Logical unit: IntfaceJobDetail
--  Component:    FNDMIG
--
--  IFS Developer Studio Template Version 3.0
--
--  Date    Sign    History
--  ------  ------  ---------------------------------------------------------
--  130522  DuWiLK bug #110197- Make use of impersonate user functionality in data migration.
--  110810  UsRaLK Bug #97854 - Execute_Job_ changed DBMS_SQL to EXECUTE IMMEDIATE.
--  100707  JHMASE Bug #91778 - Insufficient renaming of files with rule FILERENAM
--  100305  JHMASE Bug #89361 - ORA-06502: PL/SQL: numeric or value error: character string buffer too small 
--                              in INTFACE_METHOD_LIST_API
--  091124  NABALK Bug #84218 - Certified the assert safe for dynamic SQLs
--  080529  TRLYNO Bug #74163 - Occasional mismatch of dates in fields Last Info and 
--                              Executed at in window Migration Job History
--  080404  TRLYNO Bug #72912 - Possibility to use filename from rule value
--  070918  TRLYNO Bug #70434 - Enhancements on handling global variables + job info
--                              Allowing rule FILEBKP in addition to other FILExxxx-rules
--                              Implementing rule ALTREPLUSER
--  070606  TRLYNO G428770 (Bug #67489) - Update_History with Autonomous Transaction to conceal COMMIT
--  060915  JHMASE Bug #62044 - Not possible to use LAST_EXECUTED in condtitions
--  060522  JHMASE Bug #58202 - Error when using SYNCDETAILS rule
--  060329  TRLYNO Bug #56862 - FNDMIG added functionality
--  060105  TRLYNO Bug #55479 - Added functionality in Data Migration
--  041222  JHMASE Bug #48786 - Make it work with double byte
--  040507  TRLY   Bug #44483 - New rules for connecting jobs
--  040128  TRLY  Enhancements for v.1.0.0.A
--  030708  TRLY  Prepared for new module FNDMI
-----------------------------------------------------------------------------

layer Core;

-------------------- PUBLIC DECLARATIONS ------------------------------------


TYPE Intface_Info_Collection IS RECORD
   (  intface_name_ intface_header_tab.intface_name%TYPE,
   cleanup_det_ VARCHAR2(10),
   cleanup_ BOOLEAN,
   no_cleanup_ BOOLEAN,
   event_ BOOLEAN,
   server_file_info_ VARCHAR2(2000),
   save_days_ NUMBER,
   make_history_ BOOLEAN
   );
   
TYPE Get_String_Rec IS RECORD
(
line_no intface_job_detail_tab.line_no%TYPE,
file_string intface_job_detail_tab.file_string%TYPE,
status intface_job_detail_tab.status%TYPE,
rowid_ ROWID
);
   
   
CURSOR Get_String (intface_name_ IN VARCHAR2 ) RETURN Get_String_Rec IS
   SELECT line_no, file_string, status,  rowid
   FROM intface_job_detail_tab
   WHERE intface_name = intface_name_
   AND status < '4'
   ORDER BY line_no;

number_null_                 CONSTANT NUMBER        := NULL;

varchar_null_                CONSTANT VARCHAR2(10)  := NULL;

intf_backup_file_context_id_ CONSTANT VARCHAR2(100) := 'INTFACE_JOB_DETAIL_API.INTF_BACKUP_FILE_';

intf_backup_path_context_id_ CONSTANT VARCHAR2(100) := 'INTFACE_JOB_DETAIL_API.INTF_BACKUP_PATH_';

intf_delete_file_context_id_ CONSTANT VARCHAR2(100) := 'INTFACE_JOB_DETAIL_API.INTF_DELETE_FILE_';

intf_move_path_context_id_   CONSTANT VARCHAR2(100) := 'INTFACE_JOB_DETAIL_API.INTF_MOVE_PATH_';

intf_rename_file_context_id_ CONSTANT VARCHAR2(100) := 'INTFACE_JOB_DETAIL_API.INTF_RENAME_FILE_';

intf_rename_path_context_id_ CONSTANT VARCHAR2(100) := 'INTFACE_JOB_DETAIL_API.INTF_RENAME_PATH_';

intf_repl_rowid_context_id_  CONSTANT VARCHAR2(100) := 'INTFACE_JOB_DETAIL_API.INTF_REPL_ROWID_';

intf_from_server_context_id_ CONSTANT VARCHAR2(100) := 'INTFACE_JOB_DETAIL_API.INTF_FROM_SERVER_';

intf_no_file_context_id_     CONSTANT VARCHAR2(100) := 'INTFACE_JOB_DETAIL_API.INTF_NO_FILE_';

intf_file_is_on_client_cid_  CONSTANT VARCHAR2(100) := 'INTFACE_JOB_DETAIL_API.INTF_FILE_IS_ON_CLIENT_';

intf_file_is_on_server_cid_  CONSTANT VARCHAR2(100) := 'INTFACE_JOB_DETAIL_API.INTF_FILE_IS_ON_SERVER_';

intf_ignoreaderror_cid_      CONSTANT VARCHAR2(100) := 'INTFACE_JOB_DETAIL_API.INTF_IGNOREADERROR_';

intf_ignorexeerror_cid_      CONSTANT VARCHAR2(100) := 'INTFACE_JOB_DETAIL_API.INTF_IGNOREXEERROR_';

intf_in_info_cid_            CONSTANT VARCHAR2(100) := 'INTFACE_JOB_DETAIL_API.INTF_IN_INFO_';

intf_execution_ok_cid_       CONSTANT VARCHAR2(100) := 'INTFACE_JOB_DETAIL_API.INTF_EXECUTION_OK_';

intf_commit_seq_cid_         CONSTANT VARCHAR2(100) := 'INTFACE_JOB_DETAIL_API.INTF_COMMIT_SEQ_';

intf_date_executed_cid_      CONSTANT VARCHAR2(100) := 'INTFACE_JOB_DETAIL_API.INTF_DATE_EXECUTED_';

intf_skip_lines_cid_         CONSTANT VARCHAR2(100) := 'INTFACE_JOB_DETAIL_API.INTF_SKIP_LINES_';

intf_exit_lines_cid_         CONSTANT VARCHAR2(100) := 'INTFACE_JOB_DETAIL_API.INTF_EXIT_LINES_';

intf_execution_no_cid_       CONSTANT VARCHAR2(100) := 'INTFACE_JOB_DETAIL_API.INTF_EXECUTION_NO_';

intf_trunc_value_cid_        CONSTANT VARCHAR2(100) := 'INTFACE_JOB_DETAIL_API.INTF_TRUNC_VAL_';

-------------------- PRIVATE DECLARATIONS -----------------------------------

intf_last_info_context_id_ CONSTANT VARCHAR2(100) := 'INTFACE_JOB_DETAIL_API.INTF_LAST_INFO_';

intf_conn_job_context_id_  CONSTANT VARCHAR2(100) := 'INTFACE_JOB_DETAIL_API.INTF_CONN_JOB_';

-------------------- LU SPECIFIC IMPLEMENTATION METHODS ---------------------

FUNCTION Replace_Keywords___ (
   name_         IN VARCHAR2,
   old_name_     IN VARCHAR2,
   intface_name_ IN VARCHAR2 ) RETURN VARCHAR2
IS
   new_name_    VARCHAR2(2000) := name_;
   prefix_      VARCHAR2(2000) := SUBSTR(old_name_,1,INSTR(old_name_,'.')-1);

   FUNCTION get_date_format RETURN VARCHAR2
   IS
      format_ VARCHAR2(20);
   BEGIN
      SELECT NVL(date_format,'yyyymmdd')
      INTO   format_
      FROM   intface_header_tab
      WHERE  intface_name = intface_name_;
      RETURN format_;
   EXCEPTION
      WHEN OTHERS THEN
         RETURN 'yyyymmdd';   
   END get_date_format;
   
   FUNCTION get_sys_guid RETURN VARCHAR2 
   IS
      a_ VARCHAR2(100);
   BEGIN
      @ApproveDynamicStatement(2010-07-07,jhmase)
      EXECUTE IMMEDIATE 'SELECT SYS_GUID() FROM dual' INTO a_;
      RETURN a_;
   EXCEPTION
      WHEN OTHERS THEN
         RETURN NULL;
   END get_sys_guid;

   FUNCTION get_seq_no RETURN VARCHAR2 
   IS
      no_ NUMBER;
   BEGIN
      SELECT intface_backup_file_seq.nextval
      INTO   no_
      FROM dual;
      RETURN TO_CHAR(no_);
   END get_seq_no;
BEGIN
   IF ( prefix_ IS NOT NULL AND INSTR(new_name_,CHR(38)||'FILE') > 0 ) THEN
      new_name_ := REPLACE(new_name_,CHR(38)||'FILE',prefix_);
   END IF;
   IF ( INSTR(new_name_,CHR(38)||'DATF') > 0 ) THEN
      new_name_ := REPLACE(new_name_,CHR(38)||'DATF',TO_CHAR(SYSDATE,get_date_format));
   END IF;
   IF ( INSTR(new_name_,CHR(38)||'DATE') > 0 ) THEN
      new_name_ := REPLACE(new_name_,CHR(38)||'DATE',TO_CHAR(SYSDATE,'yyyymmdd'));
   END IF;
   IF ( INSTR(new_name_,CHR(38)||'USER') > 0 ) THEN
      new_name_ := REPLACE(new_name_,CHR(38)||'USER',Fnd_Session_API.Get_Fnd_User);
   END IF;
   IF ( INSTR(new_name_,CHR(38)||'GUID') > 0 ) THEN
      new_name_ := REPLACE(new_name_,CHR(38)||'GUID',get_sys_guid);
   END IF;
   IF ( INSTR(new_name_,CHR(38)||'TIME') > 0 ) THEN
      new_name_ := REPLACE(new_name_,CHR(38)||'TIME',TO_CHAR(SYSDATE,'hh24miss'));
   END IF;
   IF ( INSTR(new_name_,CHR(38)||'SEQN') > 0 ) THEN
      new_name_ := REPLACE(new_name_,CHR(38)||'SEQN',get_seq_no);
   END IF;
   RETURN new_name_;
END Replace_Keywords___;


PROCEDURE Handle_Server_File___ (
   intface_name_ IN VARCHAR2 )
IS
   backup_path_  intface_header.intface_path%TYPE;
   server_error_ VARCHAR2(2000);
   return_       BOOLEAN;
   intf_file_path_ intface_header_tab.intface_path%TYPE := Intface_Detail_API.Get_Current_File_Path;
   intf_file_name_ VARCHAR2(200) := Intface_Detail_API.Get_Current_File_Name;
   intf_move_path_ intface_header_tab.intface_path%TYPE;
   intf_rename_file_ VARCHAR2(200);
   intf_rename_path_ intface_header_tab.intface_path%TYPE;
BEGIN
   -- Backup server file   
   IF ( Intface_Rules_API.Rule_Is_Active(
      backup_path_, 'FILEBKP', intface_name_) ) THEN
      -- Backup  original file + empty it.
      -- Set intface file path as backup path if rule doesn't define it 
      backup_path_ := nvl(backup_path_, intf_file_path_);
      Intface_Detail_API.Backup_Server_File(intface_name_, backup_path_);
      App_Context_SYS.Set_Value(intf_backup_path_context_id_,backup_path_);
      App_Context_SYS.Set_Value(intf_backup_file_context_id_,Intface_Detail_API.Get_Backup_File_Name(intface_name_));
      IF ( Intface_Direction_API.Encode(Intface_Procedures_API.Get_Direction(Intface_Header_API.Get_Procedure_Name(intface_name_))) = '1' ) THEN 
         -- Empty only in-files
         Intface_Detail_API.Open_File(intface_name_, 'W');
         Intface_Detail_API.Close_Normal;
      END IF;
   END IF;
   -- Move server file
   IF ( Intface_Rules_API.Rule_Is_Active(
      intf_move_path_, 'FILEMOV', intface_name_) ) THEN
      App_Context_SYS.Set_Value(intf_move_path_context_id_,intf_move_path_);
      -- Keep same filename
      return_ := Intface_Server_File_API.Move_File(
                    intf_file_path_,
                    intf_file_name_, 
                    intf_move_path_, intf_file_name_);
   -- Rename file. New name is of same format as with rule FILEBKP
   ELSIF ( Intface_Rules_API.Rule_Is_Active(
      intf_rename_path_, 'FILERENAM', intface_name_) ) THEN
      IF    ( INSTR(intf_rename_path_,CHR(47)) > 0 )THEN
         intf_rename_file_ := SUBSTR(intf_rename_path_,INSTR(intf_rename_path_,CHR(47))+1);
         intf_rename_path_ := SUBSTR(intf_rename_path_,1,INSTR(intf_rename_path_,CHR(47))-1);
      ELSIF ( INSTR(intf_rename_path_,CHR(92)) > 0 ) THEN
         intf_rename_file_ := SUBSTR(intf_rename_path_,INSTR(intf_rename_path_,CHR(92))+1);
         intf_rename_path_ := SUBSTR(intf_rename_path_,1,INSTR(intf_rename_path_,CHR(92))-1); 
      ELSIF ( INSTR(intf_rename_path_,'.') > 0  ) THEN
         --File name specified
         intf_rename_file_ := intf_rename_path_;
         intf_rename_path_ := NULL;
      ELSE
         intf_rename_file_ := Intface_Detail_API.Get_Backup_File_Name(intface_name_,intf_file_name_);
      END IF;
      -- First rename file.....
      intf_rename_file_ := Replace_Keywords___(intf_rename_file_, intf_file_name_, intface_name_);
      -- Set values, used later in Set_Last_Info
      App_Context_SYS.Set_Value(intf_rename_file_context_id_,intf_rename_file_);
      App_Context_SYS.Set_Value(intf_rename_path_context_id_,intf_rename_path_);
      return_ := Intface_Server_File_API.Rename_File(
                   intf_file_path_,
                   intf_file_name_, 
                   intf_rename_file_);
      IF ( intf_rename_path_ IS NOT NULL ) THEN
         -- ....then move it to specified path
         return_ := Intface_Server_File_API.Move_File(
                       intf_file_path_,
                       intf_rename_file_, 
                       intf_rename_path_, 
                       intf_rename_file_);
      END IF;
   -- Rename file. New name is of same format as with rule FILEBKP
   ELSIF ( Intface_Rules_API.Rule_Is_Active(
      backup_path_, 'FILEDEL', intface_name_) ) THEN
      return_ := Intface_Server_File_API.Delete_File(
                   intf_file_path_,
                   intf_file_name_); 
      App_Context_SYS.Set_Value(Intface_Job_Detail_API.intf_delete_file_context_id_, intf_file_name_);
   END IF;
EXCEPTION
   WHEN OTHERS THEN
      server_error_ := SQLERRM;
      UTL_FILE.FCLOSE_ALL;
      Error_SYS.Record_General(lu_name_, ' SERVFILEERR: Error in file handling - :P1' , server_error_);
END Handle_Server_File___;


PROCEDURE Update_History___ (
   intface_name_ IN VARCHAR2,
   mode_         IN VARCHAR2,
   save_days_    IN NUMBER,
   make_history_ IN BOOLEAN )
IS 
   PRAGMA AUTONOMOUS_TRANSACTION;
   intf_save_err_ BOOLEAN;
   test_          VARCHAR2(100);
   intf_execution_no_ NUMBER := App_Context_SYS.Find_Number_Value(Intface_Job_Detail_API.intf_execution_no_cid_,NULL);
   intf_in_info_ VARCHAR2(2000) := App_Context_SYS.Find_Value(Intface_Job_Detail_API.intf_in_info_cid_);
   --
   CURSOR get_header IS
      SELECT rowid, execution_no
      FROM INTFACE_JOB_HIST_HEAD_TAB
      WHERE intface_name = intface_name_
      AND status = '6';
   --
BEGIN
   IF ( nvl(intf_in_info_,'**') != 'UNPACK' ) THEN
      IF ( mode_ = 'INIT' AND nvl(intf_in_info_,'**') != 'UNPACK' ) THEN
         IF ( NOT make_history_ ) THEN
            -- Remove previous history,
            -- only last execution will be logged,
            -- except on RESTART on conversion jobs,
            -- then last two executions will be logged
            IF ( nvl(intf_in_info_,'**') = 'RESTART' AND App_Context_SYS.Find_Boolean_Value(Intface_Job_Detail_API.intf_no_file_context_id_)) THEN
               NULL;
            ELSE
               Delete_History(intface_name_, save_days_);
               -- All history will bee deleted.
               -- Reset execution_no in case of previous restarts
               intf_execution_no_ := 0;
               App_Context_SYS.Set_Value(Intface_Job_Detail_API.intf_execution_no_cid_,intf_execution_no_);
            END IF;
         END IF;
         -- Insert header-rec before job starts
         BEGIN
         INSERT INTO INTFACE_JOB_HIST_HEAD_TAB (
            INTFACE_NAME,
            EXECUTION_NO,
            DATE_EXECUTED,
            EXECUTED_BY,
            LAST_INFO,
            STATUS,
            ROWVERSION)
         VALUES(
            intface_name_,
            intf_execution_no_,
            sysdate,
            Fnd_Session_API.Get_Fnd_User,
            NULL ,
            '6',
            sysdate);
         EXCEPTION
            WHEN dup_val_on_index THEN
               UPDATE INTFACE_JOB_HIST_HEAD_TAB
                  SET status = '6'
               WHERE intface_name = intface_name_
                 AND execution_no = intf_execution_no_;
         END;
      END IF;
      IF ( mode_ = 'DELETE' ) THEN
         -- Remove header-rec; new will be inserted
         FOR rec_ IN get_header LOOP
            DELETE FROM INTFACE_JOB_HIST_HEAD_TAB
            WHERE rowid = rec_.rowid;
         END LOOP;
      END IF;
      IF ( mode_ = 'CLOSE' ) THEN
         IF ( Intface_Rules_API.Rule_Is_Active(test_, 'SAVEJOBERR', intface_name_) ) THEN
            intf_save_err_ := TRUE;
         ELSE
            intf_save_err_ := FALSE;
         END IF;
         -- Update header-rec with success or failure status
         FOR rec_ IN get_header LOOP
            IF ( App_Context_SYS.Find_Boolean_Value(Intface_Job_Detail_API.intf_execution_ok_cid_) ) THEN
                IF (  intf_save_err_ ) THEN
                  -- Do not save OK jobs in history
                  DELETE FROM INTFACE_JOB_HIST_HEAD_TAB
                  WHERE rowid = rec_.rowid;
                ELSIF ( rec_.execution_no = intf_execution_no_ ) THEN
                  UPDATE INTFACE_JOB_HIST_HEAD_TAB
                     SET status = '5',
                     last_info = Get_Ctx_Val_Intf_Last_Info
                  WHERE rowid = rec_.rowid;
               END IF;
            ELSIF ( rec_.execution_no = intf_execution_no_ ) THEN
               UPDATE INTFACE_JOB_HIST_HEAD_TAB
                  SET status = '7',
                  last_info = Get_Ctx_Val_Intf_Last_Info
               WHERE rowid = rec_.rowid;
            ELSIF ( nvl(intf_in_info_,'**') = 'RESTART' AND App_Context_SYS.Find_Boolean_Value(Intface_Job_Detail_API.intf_no_file_context_id_) ) THEN
               -- Remove last history row on migration job that failes
               DELETE FROM INTFACE_JOB_HIST_HEAD_TAB
               WHERE rowid = rec_.rowid;
            END IF;
         END LOOP;
      END IF;
   END IF;
   @ApproveTransactionStatement(2013-11-20,wawilk)
   COMMIT;
EXCEPTION
   WHEN OTHERS THEN
      trace_sys.message('Update history OTHERS '||SQLERRM);
      @ApproveTransactionStatement(2013-11-20,wawilk)
      ROLLBACK;
END Update_History___;


FUNCTION Server_File_Has_Data___ (
   intf_server_file_info_ IN OUT VARCHAR2,
   file_name_ IN VARCHAR2,
   directory_ IN VARCHAR2 ) RETURN BOOLEAN
IS
   size_ VARCHAR2(2000);
BEGIN
   size_ := Intface_Server_File_API.Get_File_Size(directory_, file_name_);
   IF ( size_ IS NULL ) THEN
      intf_server_file_info_ := Language_SYS.Translate_Constant(lu_name_ , ' NOFILE : File :P1 does not exist on :P2, job not started', Fnd_Session_API.Get_Language, file_name_, directory_);
      RETURN FALSE;
   ELSIF ( size_ = '0 KB') THEN
      intf_server_file_info_ := Language_SYS.Translate_Constant(lu_name_ , ' EMPTYFILE : File :P1 on :P2 is empty, job not started', Fnd_Session_API.Get_Language, file_name_, directory_);
      RETURN FALSE;
   ELSE
      RETURN TRUE;
   END IF;
END Server_File_Has_Data___;


@Override
PROCEDURE Prepare_Insert___ (
   attr_ IN OUT VARCHAR2 )
IS
BEGIN
   super(attr_);
   Client_SYS.Add_To_Attr('EXECUTION_NO', 0, attr_);
   Client_SYS.Add_To_Attr('DATE_EXECUTED', sysdate , attr_);
   Client_SYS.Add_To_Attr('STATUS', Intface_Job_Status_API.Decode('2'), attr_);
END Prepare_Insert___;


@Override
PROCEDURE Insert___ (
   objid_      OUT    VARCHAR2,
   objversion_ OUT    VARCHAR2,
   newrec_     IN OUT INTFACE_JOB_DETAIL_TAB%ROWTYPE,
   attr_       IN OUT VARCHAR2 )
IS
BEGIN
   newrec_.date_executed := NVL(newrec_.date_executed, sysdate);
   super(objid_, objversion_, newrec_, attr_);
EXCEPTION
   WHEN dup_val_on_index THEN
      Error_SYS.Record_Exist(lu_name_);
END Insert___;


PROCEDURE Set_Last_Executed___ (   
   intface_name_ IN     VARCHAR2 ) 
IS
BEGIN
   UPDATE intface_header_tab
   SET last_executed = App_Context_SYS.Find_Date_Value(Intface_Job_Detail_API.intf_date_executed_cid_),
       executed_by = Fnd_Session_API.Get_Fnd_User
   WHERE intface_name = intface_name_;
END Set_Last_Executed___;


-------------------- LU SPECIFIC PRIVATE METHODS ----------------------------

-------------------- LU SPECIFIC PROTECTED METHODS --------------------------

FUNCTION Initialize_Job_ (
   info_         IN OUT VARCHAR2,
   intf_info_rec_ IN OUT NOCOPY Intface_Info_Collection ) RETURN BOOLEAN
IS
   head_location_   intface_header_tab.file_location%TYPE;
   rule_string_     VARCHAR2(2000);
   execution_no_    NUMBER;
   rule_number_     NUMBER;
   error_open_file_ EXCEPTION;
   no_file_loaded_  EXCEPTION;
   client_cleanup_  EXCEPTION;
   hist_error_      EXCEPTION;
   sync_error_      EXCEPTION;
   conn_error_      EXCEPTION;
   select_error_    EXCEPTION;
   objid_error_     EXCEPTION;
   error_msg_       VARCHAR2(2000);
   chk_job_         VARCHAR2(2000);
   chk_dir_         VARCHAR2(2000);
   chk_file_        VARCHAR2(2000);
   intf_servfiload_    BOOLEAN;
   alt_repl_user_   VARCHAR2(30);
   org_repl_user_   VARCHAR2(30);
   string_null_     VARCHAR2(1) := NULL;
   intf_direction_          intface_procedures_tab.direction%TYPE;
   intf_min_status_         NUMBER;
   
   intf_in_info_    VARCHAR2(2000);
   --
   CURSOR get_execution_no IS
   SELECT MAX(execution_no)
   FROM intface_job_hist_head
   WHERE intface_name = intf_info_rec_.intface_name_;
   --
BEGIN
   -- Initialize this variable with FALSE
   -- Each procedure will set it to TRUE on normal termination
   App_Context_SYS.Set_Value(Intface_Job_Detail_API.intf_execution_ok_cid_,FALSE);
   App_Context_SYS.Set_Value(intf_from_server_context_id_, 'TRUE');
   -- Save central globals
   --
   OPEN  get_execution_no;
   FETCH get_execution_no INTO execution_no_;
   CLOSE get_execution_no;
   --
   App_Context_SYS.Set_Value('INTFACE_JOB_DETAIL_API.INTF_START_TIME_',to_char(sysdate,'DD-MON-YYYY HH24:MI:SS'));
   intf_direction_ := Intface_Direction_API.Encode(Intface_Procedures_API.Get_Direction(Intface_Header_API.Get_Procedure_Name(intf_info_rec_.intface_name_)));
   head_location_ := Intface_File_Location_API.Encode(Intface_Header_API.Get_File_Location(intf_info_rec_.intface_name_));
   --
   Intface_Header_API.Check_Intface_No_File(head_location_,intf_direction_);
      
   IF ( substr(info_,1,5) = 'ROWID' ) THEN
      App_Context_SYS.Set_Value(intf_repl_rowid_context_id_,substr(info_,7));
      App_Context_SYS.Set_Value(Intface_Job_Detail_API.intf_in_info_cid_,varchar_null_);
   -- Check if this job has been started from a connected job
   ELSIF ( substr(info_,1,7) = 'CONNJOB' ) THEN
      Set_Ctx_Val_Intf_Conn_Job_(substr(info_,9));
      App_Context_SYS.Set_Value(Intface_Job_Detail_API.intf_in_info_cid_,varchar_null_);
   ELSE
      App_Context_SYS.Set_Value(intf_repl_rowid_context_id_,string_null_);
      App_Context_SYS.Set_Value(Intface_Job_Detail_API.intf_in_info_cid_,info_); -- May contain value 'UNPACK' or 'RESTART' (from client)
   END IF;
   info_ := null;
   intf_info_rec_.server_file_info_ := NULL;
   intf_in_info_ := App_Context_SYS.Find_Value(Intface_Job_Detail_API.intf_in_info_cid_);
   --
   IF ( Intface_Rules_API.Rule_Is_Active( chk_job_, 'CHKSERVERFILE', intf_info_rec_.intface_name_) ) THEN
      -- Check if serverfile exists or has data.
      -- IF not, RETURN to procedure Just_Do_It
      chk_file_ := Intface_Header_API.Get_Intface_File(nvl(chk_job_,intf_info_rec_.intface_name_));
      chk_dir_ := Intface_Header_API.Get_Intface_Path(nvl(chk_job_,intf_info_rec_.intface_name_));
      IF NOT ( Server_File_Has_Data___(intf_info_rec_.server_file_info_, chk_file_, chk_dir_ )) THEN
         RETURN FALSE;
      END IF;
   END IF;
   --
   -- Load Server File
   --
   IF ( Intface_Rules_API.Rule_Is_Active( rule_string_, 'SERVFILOAD', intf_info_rec_.intface_name_) ) THEN
      intf_servfiload_ := TRUE;
      IF ( nvl(intf_in_info_,'**') != 'RESTART' ) THEN -- No new load on RESTART
         Load_Server_File(intf_info_rec_.intface_name_);
      END IF;
   ELSE
      intf_servfiload_ := FALSE;
   END IF;
   App_Context_SYS.Set_Value(Intface_Job_Detail_API.intf_date_executed_cid_,sysdate);
   intf_min_status_ := Intface_Job_Status_API.Encode(Get_Min_Status(intf_info_rec_.intface_name_));
   --
   -- Set global BOOLEANs for file location
   --
   App_Context_SYS.Set_Value(Intface_Job_Detail_API.intf_no_file_context_id_,FALSE);
   IF ( intf_min_status_ = 2 ) THEN -- File is loaded ie. 'OnClient'
      App_Context_SYS.Set_Value(Intface_Job_Detail_API.intf_file_is_on_server_cid_,FALSE);
      App_Context_SYS.Set_Value(Intface_Job_Detail_API.intf_file_is_on_client_cid_,TRUE);
   ELSIF ( head_location_ = '1' ) THEN
      App_Context_SYS.Set_Value(Intface_Job_Detail_API.intf_file_is_on_server_cid_,TRUE);
      App_Context_SYS.Set_Value(Intface_Job_Detail_API.intf_file_is_on_client_cid_,FALSE);
   ELSIF ( head_location_  = '2' ) THEN
      App_Context_SYS.Set_Value(Intface_Job_Detail_API.intf_file_is_on_server_cid_,FALSE);
      App_Context_SYS.Set_Value(Intface_Job_Detail_API.intf_file_is_on_client_cid_,TRUE);
   ELSE
      App_Context_SYS.Set_Value(Intface_Job_Detail_API.intf_file_is_on_server_cid_,FALSE);
      App_Context_SYS.Set_Value(Intface_Job_Detail_API.intf_file_is_on_client_cid_,FALSE);
      App_Context_SYS.Set_Value(Intface_Job_Detail_API.intf_no_file_context_id_,TRUE);
   END IF;
   --
   --
   -- Save rule values in global variables
   --
   IF ( Intface_Rules_API.Rule_Is_Active(
           rule_string_, 'CLEANUP', intf_info_rec_.intface_name_) ) THEN
      intf_info_rec_.cleanup_ := TRUE;
      intf_info_rec_.cleanup_det_  := nvl(rule_string_,'AFTER');
   ELSE
      intf_info_rec_.cleanup_ := FALSE;
   END IF;
   -- Rule for history logging
   IF ( Intface_Rules_API.Rule_Is_Active(
      rule_number_, 'SAVEJOBDAYS', intf_info_rec_.intface_name_) ) THEN
      --
      intf_info_rec_.make_history_ := TRUE;
      intf_info_rec_.save_days_    := rule_number_;
      IF ( intf_servfiload_ AND nvl(intf_in_info_,'**') = 'RESTART' ) THEN
         -- Save error rows
         Make_History(intf_info_rec_.intface_name_, intf_info_rec_.save_days_, intf_info_rec_.make_history_);
      END IF;
      App_Context_SYS.Set_Value(Intface_Job_Detail_API.intf_execution_no_cid_,nvl(execution_no_,0) +1);
   ELSE
      intf_info_rec_.make_history_ := FALSE;
      App_Context_SYS.Set_Value(Intface_Job_Detail_API.intf_execution_no_cid_,nvl(execution_no_,0));
      intf_info_rec_.save_days_    := 0;
   END IF;
   --
   -- Always make history header
   -- in case job aborts
   Update_History___( intf_info_rec_.intface_name_, 'INIT', intf_info_rec_.save_days_, intf_info_rec_.make_history_ );
   -- Cleanup before job starts (only server files) :
   IF ( ( intf_info_rec_.cleanup_ ) AND  ( nvl(intf_info_rec_.cleanup_det_,'AFTER') = 'BEFORE' )  ) THEN -- Clear details before job starts
      IF ( App_Context_SYS.Find_Boolean_Value(Intface_Job_Detail_API.intf_file_is_on_client_cid_) ) THEN
         RAISE client_cleanup_;
      ELSIF ( nvl(intf_in_info_,'**') != 'RESTART' AND intf_min_status_ != 1 ) THEN
         BEGIN
            IF ( intf_info_rec_.make_history_ ) THEN
               Make_History(intf_info_rec_.intface_name_, intf_info_rec_.save_days_, intf_info_rec_.make_history_);
               -- Refresh execution_no before new job starts
               OPEN  get_execution_no;
               FETCH get_execution_no INTO execution_no_;
               CLOSE get_execution_no;
               App_Context_SYS.Set_Value(Intface_Job_Detail_API.intf_execution_no_cid_,nvl(execution_no_,0) +1);
            END IF;
            Delete_Details(intf_info_rec_.intface_name_);
            -- Refresh status before new job starts
            intf_min_status_ := Intface_Job_Status_API.Encode(Get_Min_Status(intf_info_rec_.intface_name_));
         EXCEPTION
            WHEN OTHERS THEN
               RAISE hist_error_;
         END;
         -- Reload min_status
         intf_min_status_ := Intface_Job_Status_API.Encode(Get_Min_Status(intf_info_rec_.intface_name_));
      END IF;
   END IF;
   IF ( Intface_Rules_API.Rule_Is_Active(
           rule_number_, 'SKIPLINES', intf_info_rec_.intface_name_) ) THEN
      App_Context_SYS.Set_Value(Intface_Job_Detail_API.intf_skip_lines_cid_,rule_number_);
   ELSE
      App_Context_SYS.Set_Value(Intface_Job_Detail_API.intf_skip_lines_cid_,0);
   END IF;
   IF ( Intface_Rules_API.Rule_Is_Active(
           rule_number_, 'EXITLINES', intf_info_rec_.intface_name_) ) THEN
      App_Context_SYS.Set_Value(Intface_Job_Detail_API.intf_exit_lines_cid_,rule_number_);
   ELSE
      App_Context_SYS.Set_Value(Intface_Job_Detail_API.intf_exit_lines_cid_,99999999);
   END IF;
   IF ( Intface_Rules_API.Rule_Is_Active(
           rule_string_, 'IGNOREADERROR', intf_info_rec_.intface_name_) ) THEN
      App_Context_SYS.Set_Value(Intface_Job_Detail_API.intf_ignoreaderror_cid_,TRUE);
   ELSE
      App_Context_SYS.Set_Value(Intface_Job_Detail_API.intf_ignoreaderror_cid_,FALSE);
   END IF;
   IF ( Intface_Rules_API.Rule_Is_Active(
           rule_string_, 'IGNOREXEERROR', intf_info_rec_.intface_name_) ) THEN
      App_Context_SYS.Set_Value(Intface_Job_Detail_API.intf_ignorexeerror_cid_,TRUE);
   ELSE
      App_Context_SYS.Set_Value(Intface_Job_Detail_API.intf_ignorexeerror_cid_,FALSE);
   END IF;
   -- Rule for source migration
   IF ( Intface_Rules_API.Rule_Is_Active(
           rule_number_, 'COMMITSEQ', intf_info_rec_.intface_name_) ) THEN
      App_Context_SYS.Set_Value(Intface_Job_Detail_API.intf_commit_seq_cid_,rule_number_);
   ELSE
      App_Context_SYS.Set_Value(Intface_Job_Detail_API.intf_commit_seq_cid_,varchar_null_);
   END IF;
   --
   -- Rule for EventServer
   IF ( Intface_Rules_API.Rule_Is_Active(
           rule_string_, 'EVENTMESS', intf_info_rec_.intface_name_) ) THEN
      intf_info_rec_.event_ := TRUE ;
   ELSE
      intf_info_rec_.event_ := FALSE ;
   END IF;
   -- Rule for Client Files
   IF ( Intface_Rules_API.Rule_Is_Active(
           rule_string_, 'NOCLEANUP', intf_info_rec_.intface_name_) ) THEN
      intf_info_rec_.no_cleanup_ := TRUE;
   ELSE
      intf_info_rec_.no_cleanup_ := FALSE;
   END IF;
   --
   -- CLEAN UP IF PREVIOUS JOBS HAVE FAILED :
   --
   -- To be sure CLOSE CURSOR below won't fail
   BEGIN
      OPEN Intface_Job_Detail_API.Get_String(intf_info_rec_.intface_name_) ;
   EXCEPTION
      WHEN OTHERS THEN null;
   END;
   IF ( Intface_Job_Detail_API.Get_String%ISOPEN ) THEN
       -- IF previous jobs have failed cursor may be open
       CLOSE Intface_Job_Detail_API.Get_String;
   END IF;
   -- To be sure no files are open from previous jobs
   UTL_FILE.FCLOSE_ALL;
   -- Synchronize details
   IF ( Intface_Rules_API.Rule_Is_Active(
           rule_string_, 'SYNCDETAILS', intf_info_rec_.intface_name_) ) THEN
      info_ := UPPER(nvl(rule_string_,'NOMATCH'));
      Intface_Header_API.Sync_Details(info_, intf_info_rec_.intface_name_);
      IF ( info_ IS NOT NULL ) THEN
         RAISE sync_error_;
      END IF;
      IF ( nvl(App_Context_SYS.Find_Number_Value(Intface_Job_Detail_API.intf_skip_lines_cid_),0) = 0) THEN
         App_Context_SYS.Set_Value(Intface_Job_Detail_API.intf_skip_lines_cid_,1);
      END IF;
   END IF;
   --
   -- Load intface information into global variables an PL/SQL-table
   Intface_Detail_API.Load_Intface_Info(intf_info_rec_.intface_name_);
   IF ( intf_direction_ = '4' ) THEN
      -- Migration, check if it is connected to another job
      IF ( Intface_Rules_API.Rule_Is_Active(
              rule_string_, 'CONNJOB', intf_info_rec_.intface_name_) ) THEN
         Set_Ctx_Val_Intf_Conn_Job_(rule_string_);
         IF ( Intface_Job_Status_API.Encode(Intface_Job_Detail_API.Get_Min_Status(Get_Ctx_Val_Intf_Conn_Job)) = '3' ) THEN
            error_msg_ := Language_SYS.Translate_Constant(lu_name_, ' CONNERR : Connected job :P1 has error lines ',  Fnd_Session_API.Get_Language,Get_Ctx_Val_Intf_Conn_Job );
            RAISE conn_error_;
         END IF;
      END IF;
   END IF;
   --
   Prepare_Details(intf_info_rec_.intface_name_,TRUE);
   -- CLEAN UP FINISHED
   --
   IF ( intf_direction_ != '4' ) THEN
      IF ( nvl(intf_in_info_,'**') = 'RESTART' ) THEN -- Read only loaded data
         App_Context_SYS.Set_Value(Intface_Job_Detail_API.intf_file_is_on_server_cid_,FALSE);
         App_Context_SYS.Set_Value(Intface_Job_Detail_API.intf_file_is_on_client_cid_,TRUE);
         OPEN Intface_Job_Detail_API.Get_String(intf_info_rec_.intface_name_) ;
      ELSE
         IF ( App_Context_SYS.Find_Boolean_Value(Intface_Job_Detail_API.intf_file_is_on_server_cid_) ) THEN
            -- Open server file for read or write
            BEGIN
               IF ( intf_direction_ = '1' ) THEN
                  Intface_Detail_API.Open_File(intf_info_rec_.intface_name_, 'R');
               ELSIF ( intf_direction_ = '2' ) THEN
                  Intface_Detail_API.Open_File(intf_info_rec_.intface_name_, 'W');
               END IF;
               EXCEPTION
                  WHEN OTHERS THEN
                     RAISE error_open_file_;
            END;
         ELSIF ( App_Context_SYS.Find_Boolean_Value(Intface_Job_Detail_API.intf_file_is_on_client_cid_) ) THEN
            IF ( intf_direction_ = '1' ) THEN
               IF ( intf_min_status_ = '1' ) THEN
                  -- No file loaded
                  RAISE no_file_loaded_;
               END IF;
               OPEN Intface_Job_Detail_API.Get_String(intf_info_rec_.intface_name_) ;
            END IF;
         END IF;
      END IF;
   ELSIF ( nvl(intf_in_info_,'**') = 'RESTART' AND App_Context_SYS.Find_Boolean_Value(Intface_Job_Detail_API.intf_no_file_context_id_) ) THEN
      -- Restart of Conversion, make history and delete details...
      -- .... but first check if statement is valid
      IF ( NOT Intface_Header_API.Validate_Select_Stmt_Ok(intf_info_rec_.intface_name_)) THEN
         RAISE select_error_;
      END IF;
      -- .... then check that OBJID is mapped
      IF ( NOT Intface_Method_List_API.is_objid_mapped(intf_info_rec_.intface_name_) ) THEN
         RAISE objid_error_;
      END IF;
      -- .... then move error details
      Make_History(intf_info_rec_.intface_name_, 1000, intf_info_rec_.make_history_);
      Delete_Details(intf_info_rec_.intface_name_);
      -- Reload execution no
      OPEN  get_execution_no;
      FETCH get_execution_no INTO execution_no_;
      CLOSE get_execution_no;
      App_Context_SYS.Set_Value(Intface_Job_Detail_API.intf_execution_no_cid_,nvl(execution_no_,0) +1);
   END IF;
   trace_sys.message('<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< INIT >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>');
   trace_sys.message('INIT job/execution_no_ '||intf_info_rec_.intface_name_||'/'||App_Context_SYS.Find_Number_Value(Intface_Job_Detail_API.intf_execution_no_cid_));
   IF Intface_Rules_API.Rule_Is_Active(rule_string_, 'ALTREPLUSER', intf_info_rec_.intface_name_) THEN
      Intface_Rules_API.Validate_Repl_User(alt_repl_user_, intf_info_rec_.intface_name_);
      org_repl_user_ := Fnd_Session_API.Get_Fnd_User;
      Fnd_Session_API.Impersonate_Fnd_User(alt_repl_user_);
   END IF;
   --
   RETURN TRUE;
EXCEPTION
   WHEN sync_error_ THEN
      RETURN FALSE;
   WHEN conn_error_ THEN
      Client_SYS.Add_Info(lu_name_, 'CONNJOBERR: Cannot start job. :P1 ', error_msg_);
      info_ :=  Client_Sys.Get_All_Info;
      RETURN FALSE;
   WHEN client_cleanup_ THEN
      Client_SYS.Add_Info(lu_name_, 'CLIENTCLEAN: Rule CLEANUP with value BEFORE is not allowed for client file ');
      info_ :=  Client_Sys.Get_All_Info;
      RETURN FALSE;
   WHEN hist_error_ THEN
      UTL_FILE.FCLOSE_ALL;
      Client_SYS.Add_Info(lu_name_, ' HISTERR: Error making history :P1 ', SQLERRM );
      info_ := Client_Sys.Get_All_Info;
      RETURN FALSE;
   WHEN error_open_file_ THEN
      UTL_FILE.FCLOSE_ALL;
      Client_SYS.Add_Info(lu_name_, 'OPENERR: Failed to open file :P1 on :P2 ',Intface_Detail_API.Get_Current_File_Name, Intface_Detail_API.Get_Current_File_Path ) ;
      info_ :=  Client_Sys.Get_All_Info;
      RETURN FALSE;
   WHEN no_file_loaded_ THEN
      Client_SYS.Add_Info(lu_name_, 'NOLOAD: Client file :P1 not loaded for :P2 ', Intface_Detail_API.Get_Current_File_Name, intf_info_rec_.intface_name_ ) ;
      info_ :=  Client_Sys.Get_All_Info;
      RETURN FALSE;
   WHEN select_error_ THEN
      Client_SYS.Add_Info(lu_name_, 'SELECTERR: Select statement for :P1 has errors ', intf_info_rec_.intface_name_ ) ;
      info_ :=  Client_Sys.Get_All_Info;
      RETURN FALSE;
   WHEN objid_error_ THEN
      Client_SYS.Add_Info(lu_name_, 'NOOBJID: Column OBJID is not mapped for :P1. Restart impossible', intf_info_rec_.intface_name_ ) ;
      info_ :=  Client_Sys.Get_All_Info;
      RETURN FALSE;
   WHEN OTHERS THEN
      UTL_FILE.FCLOSE_ALL;
      Client_SYS.Add_Info(lu_name_, 'INITJOBERR: Failed to initialize job :P1', SQLERRM);
      info_ :=  Client_Sys.Get_All_Info;
      IF org_repl_user_ IS NOT NULL THEN
         Fnd_Session_API.Reset_Fnd_User;
      END IF;
      RETURN FALSE;
END Initialize_Job_;


FUNCTION Execute_Job_ (
   info_         IN OUT VARCHAR2,
   intface_name_ IN     VARCHAR2 ) RETURN BOOLEAN
IS
   procedure_name_     Intface_Header_TAB.Procedure_Name%TYPE := Intface_Header_API.Get_Procedure_Name(intface_name_);
   package_name_       VARCHAR2(30)                           := 'Intface_Util_API';
   stmt_               VARCHAR2(2000);
   error_in_stmt_      EXCEPTION;
BEGIN
   IF ( NVL(App_Context_SYS.Find_Value(Intface_Job_Detail_API.intf_in_info_cid_),'**') = 'UNPACK' ) THEN
      procedure_name_ := 'Unpack' ;
      package_name_   := 'Intface_Job_Detail_API';
   END IF;
   
   IF    ( UPPER(procedure_name_) = 'UNPACK' ) THEN
      Intface_Job_Detail_API.Unpack(info_, intface_name_);   
   ELSIF ( UPPER(procedure_name_) = 'MIGRATE_SOURCE_DATA' ) THEN
      Intface_Method_List_API.Migrate_Source_Data(info_, intface_name_);   
   ELSIF ( UPPER(procedure_name_) = 'REPLICATION' ) THEN
      Intface_Method_List_API.Migrate_Source_Data(info_, intface_name_);   
   ELSIF ( UPPER(procedure_name_) = 'INSERT_OR_UPDATE' ) THEN
      Intface_Detail_API.Insert_Or_Update(info_, intface_name_);   
   ELSIF ( UPPER(procedure_name_) = 'INSERT_BY_METHOD_NEW' ) THEN
      Intface_Detail_API.Insert_By_Method_New(info_, intface_name_);
   ELSIF ( UPPER(procedure_name_) = 'CHECK_BY_METHOD_NEW' ) THEN
      Intface_Detail_API.Check_By_Method_New(info_, intface_name_);
   ELSIF ( UPPER(procedure_name_) = 'CREATE_TABLE_FROM_FILE' ) THEN
      Intface_Method_List_API.Create_Table_From_File(info_, intface_name_);   
   ELSIF ( UPPER(procedure_name_) = 'REPLIC_DATA_OUT' ) THEN
      Intface_Repl_Maint_Util_API.Replic_Data_Out(info_, intface_name_);
   ELSIF ( UPPER(procedure_name_) = 'FNDMIG_IMPORT' ) THEN
      Intface_Header_API.Fndmig_Import(info_, intface_name_);
   ELSIF ( UPPER(procedure_name_) = 'FNDMIG_EXPORT' ) THEN
      Intface_Header_API.Fndmig_Export(info_, intface_name_);
   ELSIF ( UPPER(procedure_name_) = 'CREATE_OUTPUT_FILE' ) THEN
      Intface_Detail_API.Create_Output_File(info_, intface_name_);
   ELSIF ( UPPER(procedure_name_) = 'QUICK_REPORTS_OUT' ) THEN
      Intface_Quick_Report_Util_API.Quick_Reports_Out(info_, intface_name_);
   ELSE
      Assert_SYS.Assert_Is_Package_Method(package_name_, procedure_name_);
      stmt_   := 'BEGIN ' || package_name_ || '.' || procedure_name_ || '(:info,:intface_name); END;';
      BEGIN
         @ApproveDynamicStatement(2011-08-10,usralk)
         EXECUTE IMMEDIATE stmt_
            USING
               IN OUT info_,
               IN     intface_name_;
      EXCEPTION
         WHEN OTHERS THEN
            info_ := SQLERRM;
            RAISE error_in_stmt_;
      END;
   END IF;
   RETURN TRUE;
EXCEPTION
   WHEN error_in_stmt_ THEN
      RETURN FALSE;
   WHEN OTHERS THEN
      info_ := SQLERRM;
      RETURN FALSE;
END Execute_Job_;


FUNCTION Close_Job_ (
   info_         IN OUT VARCHAR2,
   intf_info_rec_ IN OUT NOCOPY Intface_Info_Collection ) RETURN BOOLEAN
IS
   close_error_  EXCEPTION;
   hist_error_   EXCEPTION;
   min_status_   VARCHAR2(20);
   max_status_   VARCHAR2(20);
   rule_string_  VARCHAR2(100);
   altrepuser_active_ BOOLEAN := FALSE;
   string_null_ VARCHAR2(1) := NULL;
   intf_direction_          intface_procedures_tab.direction%TYPE;
   intf_in_info_ VARCHAR2(2000) := App_Context_SYS.Find_Value(Intface_Job_Detail_API.intf_in_info_cid_);
BEGIN
   -- Empty global variables
   App_Context_SYS.Set_Value(intf_backup_file_context_id_,string_null_);
   App_Context_SYS.Set_Value(intf_backup_path_context_id_,string_null_);
   App_Context_SYS.Set_Value(intf_move_path_context_id_,string_null_);
   App_Context_SYS.Set_Value(intf_rename_file_context_id_,string_null_);
   App_Context_SYS.Set_Value(intf_rename_path_context_id_,string_null_);
   App_Context_SYS.Set_Value(intf_delete_file_context_id_,string_null_);
   App_Context_SYS.Set_Value(Intface_Job_Detail_API.intf_skip_lines_cid_,number_null_);
   App_Context_SYS.Set_Value(Intface_Job_Detail_API.intf_exit_lines_cid_,number_null_);
   intf_direction_ := Intface_Direction_API.Encode(Intface_Procedures_API.Get_Direction(Intface_Header_API.Get_Procedure_Name(intf_info_rec_.intface_name_)));
   App_Context_SYS.Set_Value(intf_from_server_context_id_, 'FALSE');
   IF Intface_Rules_API.Rule_Is_Active(rule_string_, 'ALTREPLUSER', intf_info_rec_.intface_name_) THEN
      altrepuser_active_ := TRUE; -- Rule is active, need to reset user
   END IF;
   Get_Min_Max_Status(min_status_, max_status_, intf_info_rec_.intface_name_);
   --
   IF ( nvl(intf_in_info_,'*' ) != 'UNPACK' ) THEN
      IF ( intf_info_rec_.event_ ) THEN
         -- Call to event server
         BEGIN
            Intface_Events_API.Notify_Job_Finished( min_status_, max_status_,intf_info_rec_);
         EXCEPTION
            WHEN OTHERS THEN
               trace_sys.message('EVENT_ERROR '||SQLERRM);
         END;
      END IF;
   END IF;
   -- Set intf_execution_ok_ after call to event_server
   IF ( min_status_ = '3' OR max_status_ = '3' ) THEN
      App_Context_SYS.Set_Value(Intface_Job_Detail_API.intf_execution_ok_cid_,FALSE);
   END IF;
   --
   IF ( App_Context_SYS.Find_Boolean_Value(Intface_Job_Detail_API.intf_file_is_on_server_cid_) ) THEN
      UTL_FILE.FCLOSE_ALL;
      IF ( App_Context_SYS.Find_Boolean_Value(Intface_Job_Detail_API.intf_execution_ok_cid_) ) THEN
         IF ( nvl(intf_in_info_,'*' ) != 'UNPACK' ) THEN
            Handle_Server_File___( intf_info_rec_.intface_name_);
         END IF;
      END IF;
   ELSE
      IF ( Intface_Job_Detail_API.Get_String%ISOPEN ) THEN
         CLOSE Intface_Job_Detail_API.Get_String;
      END IF;
   END IF;
   -- Set last info after server-files are handled, and before history is made
   IF ( nvl(intf_in_info_,'**') != 'UNPACK' AND intf_info_rec_.server_file_info_ IS NULL ) THEN
      Intface_Header_API.Set_Last_Info( intf_info_rec_.intface_name_, Get_Ctx_Val_Intf_Last_Info, intf_info_rec_.server_file_info_  );
   END IF;
   --
   IF ( min_status_ = '3' ) THEN
      -- Interface with errors
      IF ( ( intf_info_rec_.cleanup_ ) AND  ( nvl(intf_info_rec_.cleanup_det_,'AFTER') = 'AFTER' )  ) THEN -- Clear details even if job failed
         BEGIN
            IF ( intf_info_rec_.make_history_ ) THEN
               Make_History(intf_info_rec_.intface_name_, intf_info_rec_.save_days_, intf_info_rec_.make_history_);
            END IF;
            Delete_Details(intf_info_rec_.intface_name_);
         EXCEPTION
            WHEN OTHERS THEN
               RAISE hist_error_;
         END;
      END IF;
   -- Clear details and make history if job is OK
   ELSIF ( min_status_ IN ('1','4') ) THEN
      -- OK job
      IF ( intf_direction_ = '1' ) THEN -- File in, clear details
         IF ( intf_info_rec_.no_cleanup_ ) THEN  -- .. except in this case
            NULL;
         ELSE
            BEGIN
               IF ( intf_info_rec_.make_history_ ) THEN
                  Make_History(intf_info_rec_.intface_name_, intf_info_rec_.save_days_, intf_info_rec_.make_history_);
               END IF;
               Delete_Details(intf_info_rec_.intface_name_);
            EXCEPTION
               WHEN OTHERS THEN
                  RAISE hist_error_;
            END;
         END IF;
      ELSIF ( intf_direction_ = '4' AND min_status_ = '1' ) THEN -- OK source migration
         BEGIN
            IF ( intf_info_rec_.make_history_ ) THEN
               Make_History(intf_info_rec_.intface_name_, intf_info_rec_.save_days_, intf_info_rec_.make_history_);
            END IF;
         EXCEPTION
            WHEN OTHERS THEN
               RAISE hist_error_;
         END;
      ELSIF ( nvl(intf_in_info_,'**') = 'RESTART' AND min_status_ IN ('1') )  THEN
         -- OK restarted job
         BEGIN
            IF ( intf_info_rec_.make_history_ ) THEN
               Make_History(intf_info_rec_.intface_name_, intf_info_rec_.save_days_, intf_info_rec_.make_history_);
            END IF;
         EXCEPTION
            WHEN OTHERS THEN
               RAISE hist_error_;
         END;
      END IF;
   END IF;
   --
   -- Update history header
   Update_History___( intf_info_rec_.intface_name_, 'CLOSE', intf_info_rec_.save_days_, intf_info_rec_.make_history_ );
   --
   IF ( intf_direction_ = '4'  ) THEN 
      -- Clear globals for connected Migraton jobs
      Intface_Method_List_API.Change_Job_Context__('CLOSE',intf_info_rec_.intface_name_ );
   END IF;
   IF altrepuser_active_ THEN
      Fnd_Session_API.Reset_Fnd_User;
   END IF;
   trace_sys.message('CLOSE job/execution_no_ '||intf_info_rec_.intface_name_||'/'||App_Context_SYS.Find_Number_Value(Intface_Job_Detail_API.intf_execution_no_cid_));
   trace_sys.message('<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< CLOSE >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>');
   RETURN TRUE;
EXCEPTION
   WHEN hist_error_ THEN
      UTL_FILE.FCLOSE_ALL;
      Client_SYS.Add_Info(lu_name_, ' HISTERR: Error making history :P1 ', SQLERRM );
      info_ := Client_Sys.Get_All_Info;
      IF altrepuser_active_ THEN
         Fnd_Session_API.Reset_Fnd_User;
      END IF;
      RETURN FALSE;
   WHEN close_error_ THEN
      UTL_FILE.FCLOSE_ALL;
      Client_SYS.Add_Info(lu_name_, ' CLOSEFILERR: Error when closing file :P1 ', SQLERRM );
      info_ := Client_Sys.Get_All_Info;
      RETURN FALSE;
   WHEN OTHERS THEN
      UTL_FILE.FCLOSE_ALL;
      Client_SYS.Add_Info(lu_name_, ' CLOSEJOBERR: Error when closing job :P1 ', SQLERRM );
      info_ := Client_Sys.Get_All_Info;
      IF altrepuser_active_ THEN
         Fnd_Session_API.Reset_Fnd_User;
      END IF;
      RETURN FALSE;
END Close_Job_;

-------------------- LU SPECIFIC PUBLIC METHODS -----------------------------

PROCEDURE Process_Job_Details (
   intface_name_  IN VARCHAR2,
   line_no_       IN NUMBER,
   file_string_   IN VARCHAR2,
   attr_          IN VARCHAR2,
   error_message_ IN VARCHAR2,
   line_rowid_    IN VARCHAR2 )
IS
   w_attr_   VARCHAR2(2000);
   intf_date_executed_ DATE := App_Context_SYS.Find_Date_Value(Intface_Job_Detail_API.intf_date_executed_cid_);
   intf_execution_no_ NUMBER := App_Context_SYS.Find_Number_Value(Intface_Job_Detail_API.intf_execution_no_cid_);
   intf_in_info_ VARCHAR2(2000) := App_Context_SYS.Find_Value(Intface_Job_Detail_API.intf_in_info_cid_);
BEGIN
   w_attr_ := substr(attr_,1,2000);
   IF ( Intface_Direction_API.Encode(Intface_Procedures_API.Get_Direction(Intface_Header_API.Get_Procedure_Name(intface_name_))) = '4' AND App_Context_SYS.Find_Boolean_Value(Intface_Job_Detail_API.intf_no_file_context_id_) ) THEN
      -- Error message from conversion
      INSERT INTO intface_job_detail_tab (
         intface_name, date_executed, line_no, file_string, attribute_string,
            source_rowid, error_message, execution_no, status, executed_by, rowversion)
      VALUES(
         intface_name_, intf_date_executed_, line_no_, file_string_, w_attr_,
            line_rowid_, error_message_, intf_execution_no_ , '3', Fnd_Session_API.Get_Fnd_User, sysdate ) ;
   ELSIF ( line_rowid_ IS NOT NULL ) THEN
      -- Intface_Job_Detail is the source ; update by rowid
      IF ( error_message_ IS NULL ) THEN
         UPDATE intface_job_detail_tab
         SET attribute_string = w_attr_,
             error_message = NULL,
             execution_no = decode(intf_in_info_,
                                   'UNPACK',0,intf_execution_no_),
             status = decode(intf_in_info_, 'UNPACK', '2' ,'CHECK', '2' , '4'),
             executed_by = nvl(executed_by,Fnd_Session_API.Get_Fnd_User)
         WHERE rowid = line_rowid_;
      ELSE
         UPDATE intface_job_detail_tab
         SET attribute_string = w_attr_ ,
             error_message = error_message_,
             execution_no = decode(intf_in_info_,
                              'UNPACK',0,intf_execution_no_),
             status = decode(intf_in_info_, 'UNPACK', '2' , '3'),
             executed_by = nvl(executed_by,Fnd_Session_API.Get_Fnd_User)
         WHERE rowid = line_rowid_;
      END IF;
   ELSIF ( error_message_ = 'OUTPUT_TO_CLIENT' ) THEN
      -- Called from Create_Output_File, store all lines.
      --
      INSERT INTO intface_job_detail_tab (
         intface_name, date_executed, line_no, file_string, attribute_string,
            error_message, execution_no, status, executed_by, rowversion)
      VALUES(
         intface_name_, intf_date_executed_, line_no_, file_string_, w_attr_,
            null , intf_execution_no_ , '4',  Fnd_Session_API.Get_Fnd_User, sysdate ) ;
   ELSIF ( error_message_ IS NOT NULL ) THEN
      -- Server file is source, insert new error message.
      --
      INSERT INTO intface_job_detail_tab (
         intface_name, date_executed, line_no, file_string, attribute_string,
            error_message, execution_no, status, executed_by, rowversion)
      VALUES(
         intface_name_, intf_date_executed_, line_no_, substr(file_string_,1,2000), w_attr_,
            error_message_, intf_execution_no_ , '3', Fnd_Session_API.Get_Fnd_User, sysdate ) ;
   END IF;
END Process_Job_Details;


PROCEDURE Get_Next_Line (
   line_no_     IN OUT NUMBER,
   file_string_ IN OUT VARCHAR2,
   end_of_file_ IN OUT BOOLEAN )
IS
   x_file_string_ VARCHAR2(32000);
   x_eof_         BOOLEAN;
   x_line_no_     NUMBER;
   intf_skip_lines_ NUMBER := App_Context_SYS.Find_Number_Value(Intface_Job_Detail_API.intf_skip_lines_cid_);
   intf_exit_lines_ NUMBER := App_Context_SYS.Find_Number_Value(Intface_Job_Detail_API.intf_exit_lines_cid_);
BEGIN
   --
   line_no_ := nvl(line_no_,0) + 1;
   --
   IF ( line_no_ = 1 ) THEN
      -- check if lines should be skipped
      IF ( intf_skip_lines_ != 0 ) THEN
         x_line_no_ := line_no_;
         -- LOOPs past first lines
         FOR i IN 1..intf_skip_lines_  LOOP
            Intface_Detail_API.Get_Next_Line(x_file_string_, x_eof_ );
            IF ( x_eof_ ) THEN
               end_of_file_ := TRUE;
            END IF;
         END LOOP;
         x_line_no_ := x_line_no_ + intf_skip_lines_;
         line_no_ := x_line_no_;
      END IF;
   END IF;
   Intface_Detail_API.Get_Next_Line(file_string_, end_of_file_);
   IF ( nvl(intf_exit_lines_ ,0) > 0 ) THEN
      IF ( line_no_ > intf_exit_lines_ ) THEN
         end_of_file_ := TRUE;
      END IF;
   END IF;
EXCEPTION
   WHEN OTHERS THEN
      end_of_file_  := TRUE;
      Trace_SYS.Message('Get_Next_Line OTHERS '||SQLERRM);
END Get_Next_Line;


PROCEDURE Just_Do_It (
   info_         IN OUT VARCHAR2,
   intface_name_ IN     VARCHAR2 )
IS
   close_info_ VARCHAR2(2000);
   intf_info_rec_ Intface_Info_Collection;
BEGIN
   intf_info_rec_.intface_name_ := intface_name_;
   IF ( Initialize_Job_( info_, intf_info_rec_ ) ) THEN
      IF NOT ( Execute_Job_( info_, intface_name_ ) ) THEN
         App_Context_SYS.Set_Value(Intface_Job_Detail_API.intf_execution_ok_cid_,FALSE);
      END IF;
      Format_Info(info_);
      Set_Ctx_Val_Intf_Last_Info_(info_);
      IF ( NOT Close_Job_ (close_info_, intf_info_rec_ ) ) THEN
         -- Add info from close job to original info
         IF ( close_info_ IS NOT NULL ) THEN
            info_ := close_info_||' ==> '||Get_Ctx_Val_Intf_Last_Info;
         END IF;
      ELSE
         info_ := Get_Ctx_Val_Intf_Last_Info;
      END IF;
   ELSE
      IF ( intf_info_rec_.server_file_info_ IS NOT NULL ) THEN
         -- Job closed down because no data on file, normal termination
         App_Context_SYS.Set_Value(Intface_Job_Detail_API.intf_execution_ok_cid_,TRUE);
         info_ := intf_info_rec_.server_file_info_;
      ELSE
         -- Set last info
         Format_Info(info_);
         -- Call EventServer; Close_Job_ never executed
         BEGIN
            Intface_Events_API.Notify_Job_Finished( '1' , '1',intf_info_rec_ );
         EXCEPTION
            WHEN OTHERS THEN
               trace_sys.message('EVENT_ERROR '||SQLERRM);
         END;
      END IF;
   END IF;
   Set_Last_Executed___(intface_name_);
   App_Context_SYS.Set_Value(Intface_Job_Detail_API.intf_in_info_cid_,varchar_null_);
   intf_info_rec_.server_file_info_ := NULL;
EXCEPTION
   WHEN OTHERS THEN
      info_ := SQLERRM;
      Set_Last_Executed___(intface_name_);
END Just_Do_It;


PROCEDURE Load_Server_File (
   intface_name_ IN VARCHAR2 )
IS
   line_no_     NUMBER := 0;
   eof_out_     BOOLEAN := FALSE;
   file_string_ VARCHAR2(4000);
BEGIN
   --
   -- Load intface info ; this may bee called from client
   Intface_Detail_API.Load_Intface_Info(intface_name_);
   --
   -- Loads serverfile into job_details
   Intface_Detail_API.Open_File(intface_name_, 'R');
   Intface_Detail_API.Get_Next_Line (file_string_, eof_out_);
   WHILE ( NOT eof_out_ ) LOOP
      line_no_ := line_no_ +1 ;
      INSERT INTO INTFACE_JOB_DETAIL_TAB (INTFACE_NAME, LINE_NO, FILE_STRING, DATE_EXECUTED,
                          EXECUTION_NO, STATUS, ROWVERSION)
      VALUES( intface_name_, line_no_, file_string_, App_Context_SYS.Find_Date_Value(Intface_Job_Detail_API.intf_date_executed_cid_,sysdate),
               0 , '2', sysdate);
      Intface_Detail_API.Get_Next_Line (file_string_, eof_out_);
   END LOOP;
   Intface_Detail_API.CLose_Normal;
EXCEPTION
   WHEN OTHERS THEN
      UTL_FILE.FCLOSE_ALL;
      trace_sys.message('Load_Server_File OTHERS '||SQLERRM);
      Error_SYS.Record_General(lu_name_, 'LOADFILERR: Error loading file :P1 on :P2 ',  Intface_Detail_API.Get_Current_File_Name, Intface_Detail_API.Get_Current_File_Path);
END Load_Server_File;


PROCEDURE Make_History (
   intface_name_ IN VARCHAR2,
   save_days_    IN NUMBER,
   make_history_ IN BOOLEAN )
IS
   --
   min_status_ NUMBER;
   last_info_      intface_header_tab.last_info%TYPE;
   last_executed_  intface_header_tab.last_executed%TYPE;
   executed_by_    intface_header_tab.executed_by%TYPE;
   ins_rowid_      ROWID;
   status_         NUMBER;
   intf_save_err_  BOOLEAN;
   test_           VARCHAR2(100);
   --
   CURSOR get_details IS
      SELECT *
      FROM INTFACE_JOB_DETAIL_TAB
      WHERE status = '3'
      AND intface_name = intface_name_;
   --
   CURSOR get_ok_details IS
      SELECT *
      FROM INTFACE_JOB_DETAIL_TAB
      WHERE status = '4'
      AND intface_name = intface_name_
      AND rownum = 1;
   --
   --
BEGIN
   --
   min_status_ := Intface_Job_Status_API.Encode(Get_Min_Status(intface_name_));
   --
   last_executed_ := App_Context_SYS.Find_Date_Value(Intface_Job_Detail_API.intf_date_executed_cid_);
   executed_by_   := Fnd_Session_API.Get_Fnd_User;
   last_info_     := Intface_Header_API.Get_Last_Info( intface_name_ );
   --
   IF ( Intface_Rules_API.Rule_Is_Active(test_, 'SAVEJOBERR', intface_name_) ) THEN
      intf_save_err_ := TRUE;
   ELSE
      intf_save_err_ := FALSE;
   END IF;
   
   Delete_History( intface_name_, save_days_ );
   --
   IF ( ( min_status_  = 4 ) AND ( App_Context_SYS.Find_Boolean_Value(Intface_Job_Detail_API.intf_file_is_on_client_cid_) ) AND NOT ( intf_save_err_ ) ) THEN
      -- Make OK history row for client file
      FOR new_rec_ IN get_ok_details LOOP
         -- Delete initial header before inserting new
         Update_History___(intface_name_, 'DELETE', save_days_, make_history_);
         BEGIN
         INSERT INTO INTFACE_JOB_HIST_HEAD_TAB (
            INTFACE_NAME,
            EXECUTION_NO,
            DATE_EXECUTED,
            EXECUTED_BY,
            LAST_INFO,
            STATUS,
            ROWVERSION)
         VALUES(
            new_rec_.intface_name,
            new_rec_.execution_no,
            new_rec_.date_executed,
            new_rec_.executed_by,
            last_info_ ,
            '5',
            new_rec_.rowversion);
         EXCEPTION
            -- Cleanup from client,
            -- history header exists
            WHEN dup_val_on_index THEN
            NULL;
         END;
      END LOOP;
   ELSIF ( ( min_status_ = 1 ) AND ( App_Context_SYS.Find_Boolean_Value(Intface_Job_Detail_API.intf_file_is_on_server_cid_) ) AND NOT ( intf_save_err_ ) ) THEN
      -- Make OK history row for server file
      -- Delete initial header before inserting new
      Update_History___(intface_name_, 'DELETE', save_days_, make_history_);
      IF NOT App_Context_SYS.Find_Boolean_Value(Intface_Job_Detail_API.intf_execution_ok_cid_) THEN
         status_ := 7;
      ELSE
         status_ := 5;
      END IF;
      BEGIN
      INSERT INTO INTFACE_JOB_HIST_HEAD_TAB (
         INTFACE_NAME,
         EXECUTION_NO,
         DATE_EXECUTED,
         EXECUTED_BY,
         LAST_INFO,
         STATUS,
         ROWVERSION)
      VALUES(
         intface_name_,
         App_Context_SYS.Find_Number_Value(Intface_Job_Detail_API.intf_execution_no_cid_),
         last_executed_,
         executed_by_,
         last_info_ ,
         status_,
         sysdate);
      EXCEPTION
         -- Cleanup from client,
         -- history header exists
         WHEN dup_val_on_index THEN
         NULL;
      END;
   ELSIF ( ( min_status_ = 1 ) AND ( Intface_Direction_API.Encode(Intface_Procedures_API.Get_Direction(Intface_Header_API.Get_Procedure_Name(intface_name_))) = '4' ) AND NOT ( intf_save_err_ ) ) THEN
      -- Make OK history row for migration job
      -- Delete initial header before inserting new
      Update_History___(intface_name_, 'DELETE', save_days_, make_history_);
      BEGIN
      INSERT INTO INTFACE_JOB_HIST_HEAD_TAB (
         INTFACE_NAME,
         EXECUTION_NO,
         DATE_EXECUTED,
         EXECUTED_BY,
         LAST_INFO,
         STATUS,
         ROWVERSION)
      VALUES(
         intface_name_,
         App_Context_SYS.Find_Number_Value(Intface_Job_Detail_API.intf_execution_no_cid_),
         last_executed_,
         executed_by_,
         last_info_ ,
         '5',
         sysdate);
      EXCEPTION
         -- Cleanup from client,
         -- history header exists
         WHEN dup_val_on_index THEN
         NULL;
      END;
   ELSE
      -- Save ERROR history rows
      FOR new_rec_ IN get_details LOOP
         IF ( get_details%ROWCOUNT = 1) THEN
            -- Delete initial header before inserting new
            Update_History___(intface_name_, 'DELETE', save_days_, make_history_);
            executed_by_ := nvl(executed_by_,Intface_Header_API.Get_Executed_By(intface_name_));
            last_executed_ := nvl(last_executed_,Intface_Header_API.Get_Last_Executed(intface_name_));
            -- New ERROR history HEAD
            BEGIN
            INSERT INTO INTFACE_JOB_HIST_HEAD_TAB (
               INTFACE_NAME,
               EXECUTION_NO,
               DATE_EXECUTED,
               EXECUTED_BY,
               LAST_INFO,
               STATUS,
               ROWVERSION)
            VALUES(
               intface_name_,
               new_rec_.execution_no,
               last_executed_,
               executed_by_,
               last_info_ ,
               new_rec_.status,
               sysdate);
            EXCEPTION
               -- Cleanup from client,
               -- history header exists
               WHEN dup_val_on_index THEN
               NULL;
            END;
         END IF;
         IF nvl(App_Context_SYS.Find_Value(intf_from_server_context_id_),'FALSE') = 'TRUE' THEN
            ins_rowid_ := new_rec_.source_rowid;
         ELSE
            ins_rowid_ := NULL;
         END IF;
         INSERT INTO INTFACE_JOB_HIST_DETAIL_TAB (
            INTFACE_NAME,
            EXECUTION_NO,
            LINE_NO,
            FILE_STRING,
            ATTRIBUTE_STRING,
            ERROR_MESSAGE,
            SOURCE_ROWID,
            ROWVERSION)
         VALUES(
            intface_name_,
            new_rec_.execution_no,
            new_rec_.line_no,
            new_rec_.file_string,
            new_rec_.attribute_string,
            new_rec_.error_message,
            ins_rowid_,
            new_rec_.rowversion);
         --
      END LOOP;
   END IF;
EXCEPTION
   WHEN OTHERS THEN
      trace_sys.message('Make_History OTHERS '||SQLERRM);
      Error_SYS.Record_General(lu_name_, 'HISTERR: Error making history :P1 ', SQLERRM );
END Make_History;


PROCEDURE Delete_Details (
   intface_name_ IN VARCHAR2 )
IS
BEGIN
   DELETE FROM INTFACE_JOB_DETAIL_TAB
   WHERE intface_name = intface_name_;
EXCEPTION
   WHEN OTHERS THEN
   trace_sys.message('Delete details OTHERS '||SQLERRM);
END Delete_Details;


PROCEDURE Delete_History (
   intface_name_ IN VARCHAR2,
   save_days_    IN NUMBER DEFAULT NULL)
IS
   execution_no_ INTFACE_JOB_HIST_HEAD_TAB.execution_no%TYPE;
   --
   CURSOR get_hist_head IS
      SELECT rowid, execution_no
         FROM INTFACE_JOB_HIST_HEAD_TAB
         WHERE intface_name = intface_name_
         AND trunc(date_executed) <= trunc(sysdate) - nvl(save_days_,0);
   --
   CURSOR get_hist_detail IS
      SELECT rowid
         FROM INTFACE_JOB_HIST_DETAIL_TAB
         WHERE intface_name = intface_name_
         AND execution_no = execution_no_;
BEGIN
   FOR hrec_ IN get_hist_head LOOP
      execution_no_ := hrec_.execution_no;
      FOR drec_ IN get_hist_detail LOOP
         DELETE FROM INTFACE_JOB_HIST_DETAIL_TAB
         WHERE rowid = drec_.rowid;
      END LOOP;
      DELETE FROM INTFACE_JOB_HIST_HEAD_TAB
      WHERE rowid = hrec_.rowid;
   END LOOP;
END Delete_History;


PROCEDURE Prepare_Details (
   intface_name_ IN VARCHAR2,
   intf_prepare_ IN BOOLEAN DEFAULT FALSE )
IS
   rule_number_   NUMBER;
   intf_skip_lines_ NUMBER := App_Context_SYS.Find_Number_Value(Intface_Job_Detail_API.intf_skip_lines_cid_);
   intf_exit_lines_ NUMBER := App_Context_SYS.Find_Number_Value(Intface_Job_Detail_API.intf_exit_lines_cid_);
   intf_in_info_ VARCHAR2(2000) := App_Context_SYS.Find_Value(Intface_Job_Detail_API.intf_in_info_cid_);
BEGIN
   --
   IF ( nvl(intf_in_info_,'**') = 'RESTART' )  THEN
      -- Restart from client
      NULL;
   ELSIF ( Intface_Direction_API.Encode(Intface_Procedures_API.Get_Direction(Intface_Header_API.Get_Procedure_Name(intface_name_))) = '4' AND intf_prepare_) THEN
      -- Start of source migration job
      NULL;
   ELSIF ( nvl(Intface_Job_Status_API.Encode(Get_Min_Status(intface_name_)),0) = '2' AND intf_prepare_ ) THEN
      -- File already loaded
      IF ( App_Context_SYS.Find_Boolean_Value(Intface_Job_Detail_API.intf_file_is_on_client_cid_) ) THEN
         -- Update status on lines so that they will be ignored
         IF ( nvl(intf_skip_lines_,0 )  > 0 ) THEN
            UPDATE intface_job_detail_tab
            SET status = '4',
             executed_by = Fnd_Session_API.Get_Fnd_User,
             execution_no = decode(intf_in_info_,
                                   'UNPACK',0,App_Context_SYS.Find_Number_Value(Intface_Job_Detail_API.intf_execution_no_cid_))
            WHERE intface_name = intface_name_
            AND line_no <= intf_skip_lines_;
         END IF;
         IF ( nvl(intf_exit_lines_,0 )  != 999999 ) THEN
            UPDATE intface_job_detail_tab
            SET status = '4',
             executed_by = Fnd_Session_API.Get_Fnd_User,
             execution_no = decode(intf_in_info_,
                                   'UNPACK',0,App_Context_SYS.Find_Number_Value(Intface_Job_Detail_API.intf_execution_no_cid_))
            WHERE intface_name = intface_name_
            AND line_no > intf_exit_lines_;
         END IF;
      END IF;
   ELSIF ( nvl(Intface_Job_Status_API.Encode(Get_Min_Status(intface_name_)),0) = '1' AND intf_prepare_ ) THEN
      -- Do nothing, file will be loaded from  server
      NULL;
   ELSE
      -- Min_status = '3' (error) or '4' (OK), make history
      IF ( nvl(intf_in_info_,'**') != 'UNPACK'  )  THEN
         -- Cleanup details
         IF ( Intface_Rules_API.Rule_Is_Active(
              rule_number_, 'SAVEJOBDAYS', intface_name_) ) THEN
            Make_History(intface_name_, rule_number_, TRUE);
         END IF;
      END IF;
      Delete_Details(intface_name_);
   END IF;
EXCEPTION
   WHEN OTHERS THEN
      Error_SYS.Record_General(lu_name_, 'PREPERR: Error preparing details :P1 ', SQLERRM );
END Prepare_Details;


@UncheckedAccess
FUNCTION Get_Min_Status (
   intface_name_ IN VARCHAR2 ) RETURN VARCHAR2
IS
   temp_ INTFACE_JOB_DETAIL.status%TYPE;
   CURSOR get_attr IS
      SELECT MIN(status)
      FROM INTFACE_JOB_DETAIL_TAB
      WHERE intface_name = intface_name_;
   dummy_ VARCHAR2(1);
   error_exist_ BOOLEAN;
   CURSOR check_error IS
      SELECT 'x'
      FROM INTFACE_JOB_DETAIL_TAB
      WHERE intface_name = intface_name_
      AND status = '3';
BEGIN
   OPEN get_attr;
   FETCH get_attr INTO temp_;
   CLOSE get_attr;
   --
   IF ( Intface_Header_API.Get_Procedure_Name(intface_name_) = 'CHECK_BY_METHOD_NEW' ) THEN
      -- Set min(status) = errorstatus for CHECK_BY_METHOD_NEW.
      -- This to enable Restart option from RMB in StartJob
      OPEN  check_error;
      FETCH check_error INTO dummy_;
         error_exist_ := check_error%FOUND;
      CLOSE check_error;
      IF ( error_exist_ ) THEN
         temp_ := '3';
      END IF;
   END IF;
   RETURN Intface_Job_Status_API.Decode(nvl(temp_,1));
END Get_Min_Status;


PROCEDURE Get_Min_Max_Status (
   min_status_   OUT VARCHAR2,
   max_status_   OUT VARCHAR2,
   intface_name_ IN  VARCHAR2 )
IS
   CURSOR get_attr IS
      SELECT nvl(MIN(status),'1'), nvl(MAX(status),'1')
      FROM INTFACE_JOB_DETAIL_TAB
      WHERE intface_name = intface_name_;
BEGIN
   OPEN get_attr;
   FETCH get_attr INTO min_status_, max_status_;
   CLOSE get_attr;
END Get_Min_Max_Status;


PROCEDURE Unpack (
   info_         IN OUT VARCHAR2,
   intface_name_ IN     VARCHAR2 )
IS
   end_of_file_      BOOLEAN := FALSE;
   file_string_      VARCHAR2(32000);
   status_           intface_job_detail_tab.status%TYPE;
   line_no_          intface_job_detail_tab.line_no%TYPE;
   line_objid_       rowid;
   --
   attr_         VARCHAR2(32000);
   --
   --
   intf_format_error_         VARCHAR2(2000);
   --
   intfsorted_cols_ Intface_Detail_Util_API.intfdet_col_tab_type;
   intfdet_rec_     Intface_Detail_Util_API.intfdet_tab_type;
   
   test_      VARCHAR2(100);
   trunc_val_ BOOLEAN;
BEGIN
   IF ( Intface_Rules_API.Rule_Is_Active(test_, 'TRUNCVAL', intface_name_) ) THEN
      trunc_val_ := TRUE;
   ELSE
      trunc_val_ := FALSE;
   END IF;
   App_Context_SYS.Set_Value(Intface_Job_Detail_API.intf_trunc_value_cid_,trunc_val_);
   --
   intfsorted_cols_ := Intface_Detail_Util_API.Get_Sorted_Intface_Columns(intface_name_);
   intfdet_rec_ := Intface_Detail_Util_API.Get_Intface_Details(intface_name_);
   LOOP
      IF ( App_Context_SYS.Find_Boolean_Value(Intface_Job_Detail_API.intf_file_is_on_client_cid_) ) THEN
         FETCH Intface_Job_Detail_API.Get_String INTO line_no_, file_string_, status_, line_objid_;
         EXIT WHEN  Intface_Job_Detail_API.Get_String%NOTFOUND;
      ELSIF ( App_Context_SYS.Find_Boolean_Value(Intface_Job_Detail_API.intf_file_is_on_server_cid_) ) THEN
         Intface_Job_Detail_API.Get_Next_Line(line_no_, file_string_, end_of_file_);
         EXIT WHEN end_of_file_;
      END IF;
      CLient_SYS.Clear_Attr(Attr_);
      @ApproveTransactionStatement(2013-11-20,wawilk)
      SAVEPOINT new_string_;
      IF (Intface_Detail_API.String_To_Attr(attr_, file_string_, intf_format_error_, intface_name_, intfsorted_cols_, intfdet_rec_, trunc_val_) ) THEN
         IF ( App_Context_SYS.Find_Boolean_Value(Intface_Job_Detail_API.intf_file_is_on_client_cid_) ) THEN
            Intface_Job_Detail_API.Process_Job_Details(intface_name_,
                  line_no_ ,file_string_ , attr_ , null , line_objid_ );
         END IF;
      ELSE
         Intface_Job_Detail_API.Process_Job_Details(intface_name_,
            line_no_ ,file_string_ , attr_ , intf_format_error_ , line_objid_ );
      END IF;
   END LOOP;
   Client_SYS.Clear_Info;
   Client_SYS.Add_Info(lu_name_, 'UNPACKEND: Unpack complete for Job :P1 ', intface_name_);
   info_ := replace(Client_Sys.Get_All_Info,chr(30),'');
EXCEPTION
   WHEN OTHERS THEN
      Client_SYS.Add_Info(lu_name_, ' UNPACKERR: Error occured during unpack ==> :P1 ', SQLERRM);
      info_ := replace(Client_Sys.Get_All_Info,chr(30),'');
END Unpack;


@UncheckedAccess
FUNCTION Get_Backup_File (
   intface_name_ IN VARCHAR2,
   file_path_    IN VARCHAR2,
   file_name_    IN VARCHAR2 ) RETURN VARCHAR2
IS
   bkp_path_ intface_header_tab.intface_path%TYPE;
   bkp_file_ intface_header_tab.intface_file%TYPE;
BEGIN
   IF ( Intface_Rules_API.Rule_Is_Active(
        bkp_path_, 'FILEBKP', intface_name_) ) THEN
      IF ( bkp_path_ IS NULL ) THEN
        bkp_path_ := file_path_;
      END IF;
      bkp_file_ := Intface_Detail_API.Get_Backup_File_Name(intface_name_, file_name_);
      IF (instr(bkp_path_,'\') != 0 ) THEN
        bkp_path_ := bkp_path_||'\';
      ELSIF (instr(bkp_path_,'/') != 0 ) THEN
        bkp_path_ := bkp_path_||'/';
      END IF;
      RETURN bkp_path_||bkp_file_;
   ELSE
      RETURN '';
   END IF;
END Get_Backup_File;


PROCEDURE Format_Info (
   info_ IN OUT VARCHAR2 )
IS
BEGIN
   -- Remove separators from Client_SYS, divide multiple messages with newline
   info_ := replace(replace(replace(info_,'INFO'||chr(31),''),chr(30)||' ',chr(13)||chr(10)),chr(30),'');
   -- 4 newlines may occur. Reduce to 2
   info_ := REPLACE(info_,chr(13)||chr(10)||chr(13)||chr(10)||chr(13)||chr(10)||chr(13)||chr(10),chr(13)||chr(10)||chr(13)||chr(10));
END Format_Info;


FUNCTION Get_Max_Line_No (
   intface_name_ IN VARCHAR2 ) RETURN NUMBER
IS
   max_line_ NUMBER;
   CURSOR get_line IS
      SELECT nvl(max(line_no),0) line_no
      FROM INTFACE_JOB_DETAIL_TAB
      WHERE intface_name = intface_name_;
BEGIN
   OPEN get_line;
   FETCH get_line INTO max_line_;
   CLOSE get_line;
   RETURN max_line_;
END Get_Max_Line_No;


FUNCTION Get_Ctx_Val_Intf_Last_Info RETURN VARCHAR2
IS
BEGIN
   RETURN App_Context_SYS.Find_Value(intf_last_info_context_id_);
END Get_Ctx_Val_Intf_Last_Info;


FUNCTION Get_Ctx_Val_Intf_Conn_Job RETURN VARCHAR2
IS
BEGIN
   RETURN App_Context_SYS.Find_Value(intf_conn_job_context_id_);
END Get_Ctx_Val_Intf_Conn_Job;


PROCEDURE Set_Ctx_Val_Intf_Last_Info_ (
   last_info_ VARCHAR2 )
IS
BEGIN
   App_Context_SYS.Set_Value(intf_last_info_context_id_, last_info_);
END Set_Ctx_Val_Intf_Last_Info_;


PROCEDURE Set_Ctx_Val_Intf_Conn_Job_ (
   intf_conn_job_ VARCHAR2)
IS
BEGIN
   App_Context_SYS.Set_Value(intf_conn_job_context_id_, intf_conn_job_);
END Set_Ctx_Val_Intf_Conn_Job_; 



