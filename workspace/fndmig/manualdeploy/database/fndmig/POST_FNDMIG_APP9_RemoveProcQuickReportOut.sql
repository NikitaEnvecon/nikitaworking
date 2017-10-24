
-----------------------------------------------------------------------------------------
--
--  Module:   FNDMIG
--
--  File:     POST_FNDMIG_APP9_RemoveProcQuickReportOut.sql
--
--  Purpose:  The Quick_Report_OUT Procedure is Deprecated. It is recommended to use the
--            built in Import/Export functionality in Quick Report
--            This script will remove all data related to any FNDMIG Quick Report Out Job.
--------------------------------------------
--  Date    Sign      History
--  ------  ------    -------------------------------------------------------------------
--  141201  ChMuLK    Created.
-----------------------------------------------------------------------------------------

exec Installation_SYS.Log_Detail_Time_Stamp('FNDMIG','POST_FNDMIG_APP9_RemoveProcQuickReportOut.sql','Timestamp_1');
PROMPT POST_FNDMIG_APP9_RemoveProcQuickReportOut.sql

SET SERVEROUTPUT ON

DECLARE 
  CURSOR Get_Jobs IS
    SELECT intface_name
    FROM intface_header_tab
    WHERE procedure_name LIKE 'QUICK_REPORTS_OUT';
    
  TYPE jobs_tab IS TABLE OF Get_Jobs%ROWTYPE;
  jobs_ jobs_tab;
  errors_ BOOLEAN := FALSE;
BEGIN
  
  OPEN Get_Jobs;
  FETCH Get_Jobs BULK COLLECT INTO jobs_;
  CLOSE Get_Jobs;
  
  FOR i_ IN 1..jobs_.COUNT LOOP
    BEGIN
      SAVEPOINT before_job_delete;
      dbms_output.put_line('Removing Migration Job '||jobs_(i_).intface_name);
      DELETE FROM intface_job_hist_head_tab WHERE intface_name = jobs_(i_).intface_name;
      DELETE FROM intface_job_hist_detail_tab WHERE intface_name = jobs_(i_).intface_name;
      DELETE FROM intface_job_detail_tab WHERE intface_name = jobs_(i_).intface_name;
      DELETE FROM intface_detail_tab WHERE intface_name = jobs_(i_).intface_name;
      DELETE FROM intface_pr_user_tab WHERE intface_name = jobs_(i_).intface_name;
      DELETE FROM intface_rules_tab WHERE intface_name = jobs_(i_).intface_name;
      DELETE FROM intface_header_tab WHERE intface_name = jobs_(i_).intface_name;
      COMMIT;
    EXCEPTION
      WHEN OTHERS THEN
        -- Something went wrong,
        -- But we will continue removing other jobs
        errors_ := TRUE;
        ROLLBACK TO before_job_delete;
        dbms_output.put_line('Error when removing Migration Job '||jobs_(i_).intface_name);
        dbms_output.put_line('Error: '||SQLERRM || dbms_utility.format_error_backtrace);
    END;
  END LOOP;
  
  IF NOT errors_ THEN
     DELETE FROM intface_procedures_tab WHERE procedure_name = 'QUICK_REPORTS_OUT';
     COMMIT;
     dbms_output.put_line('Migration Procedure QUICK_REPORTS_OUT removed successfully.');
  ELSE
     dbms_output.put_line('Unable to remove Migration Procedure QUICK_REPORTS_OUT because of errors.');
     dbms_output.put_line('Correct errors and try again.');
  END IF;
END;
/
SET SERVEROUT OFF;

exec Installation_SYS.Log_Detail_Time_Stamp('FNDMIG','POST_FNDMIG_APP9_RemoveProcQuickReportOut.sql','Timestamp_2');
PROMPT Execution of POST_FNDMIG_APP9_RemoveProcQuickReportOut.sql is Completed.
exec Installation_SYS.Log_Detail_Time_Stamp('FNDMIG','POST_FNDMIG_APP9_RemoveProcQuickReportOut.sql','Done');
