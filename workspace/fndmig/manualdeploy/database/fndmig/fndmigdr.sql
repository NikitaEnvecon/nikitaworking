----------------------------------------------------------------
--
-- File     :  FNDMIGDR.SQL
--
-- Component:  FNDMIG - Data Migration
--
-- Release  :
--
-- Created  : 2015-03-12
--
----------------------------------------------------------------
-- NOTE  This script drops the complete component and must be
-- NOTE  edited before usage.
-- NOTE  Number of synonyms, triggers, sequences, MVs and tables
-- NOTE  might not be exact due to incomplete information in the
-- NOTE  database
-- NOTE  Please check with CRE/INS script(s) to make sure that
-- NOTE  correct objects are dropped
-- NOTE  The script will drop
-- NOTE  -  Obvious component data stored in other component's frameworks
-- NOTE  - Database objects for the component
----------------------------------------------------------------

-- Remove the EXIT statement when the template script has been verified
-- Start removing/commenting here
PROMPT ****************************************************************
PROMPT NOTE NOTE NOTE NOTE NOTE NOTE NOTE NOTE NOTE NOTE NOTE NOTE NOTE
PROMPT ****************************************************************
PROMPT The script must be edited/verified first
PROMPT Execution will end here
EXIT
-- END removing/commenting here

ACCEPT remove_data DEFAULT 'No' FORMAT 'A3' PROMPT 'Do you want to remove data related to component as well [(Y)es/(N)o, The default is No]? '

SET SERVEROUTPUT ON SIZE UNLIMITED
SET VERIFY OFF
SET FEEDBACK OFF


SPOOL FNDMIGDR.log

--=======================================================
-- DATA REMOVAL SECTION START
--=======================================================

BEGIN
   IF (SUBSTR(UPPER('&remove_data'),1,1)  = 'Y') THEN
      --=======================================================
      dbms_output.put_line('START removing some module specific data...');
      dbms_output.put_line('Please Wait...');
      --=======================================================
   END IF;
END;
/

--=======================================================
-- Removing Posting Controls and Related Data Start
--=======================================================

BEGIN
   IF (SUBSTR(UPPER('&remove_data'),1,1)  = 'Y') THEN
      dbms_output.put_line('Removing Posting Controls and Related Data...');
   END IF;
END;
/
----------------------------------------------------------------
-- Removing posting controls related to the module
----------------------------------------------------------------
BEGIN
   IF (SUBSTR(UPPER('&remove_data'),1,1)  = 'Y') THEN
      dbms_output.put_line('Removing Posting Controls Related to Module');
      Posting_Ctrl_Public_API.Remove_Postingctrls_Per_Module('FNDMIG');
   END IF;
END;
/

----------------------------------------------------------------
-- Removing combined control types related to the module
----------------------------------------------------------------
BEGIN
   IF (SUBSTR(UPPER('&remove_data'),1,1)  = 'Y') THEN
      dbms_output.put_line('Removing Combined Control Types related to the Module...');
      Posting_Ctrl_Public_API.Rmv_Combctrl_Typs_Per_Module('FNDMIG');
   END IF;
END;
/

----------------------------------------------------------------
-- Removing allowed control types related to the module
----------------------------------------------------------------
BEGIN
   IF (SUBSTR(UPPER('&remove_data'),1,1)  = 'Y') THEN
      dbms_output.put_line('Removing Allowed Control Types related to the Module...');
      Posting_Ctrl_Public_API.Remove_Allowed_Comb_Per_Module('FNDMIG');
   END IF;
END;
/

----------------------------------------------------------------
-- Removing control types related to the module
----------------------------------------------------------------
BEGIN
   IF (SUBSTR(UPPER('&remove_data'),1,1)  = 'Y') THEN
      dbms_output.put_line('Removing Control Types related to the Module...');
      Posting_Ctrl_Public_API.Remove_Ctrl_Types_Per_Module('FNDMIG');
   END IF;
END;
/

----------------------------------------------------------------
-- Removing posting types related to the module
----------------------------------------------------------------
BEGIN
   IF (SUBSTR(UPPER('&remove_data'),1,1)  = 'Y') THEN
      dbms_output.put_line('Removing Control Types related to the Module...');
      Posting_Ctrl_Public_API.Remove_Posting_Typs_Per_Module('FNDMIG');
   END IF;
END;
/
--=======================================================
-- Removing Posting Controls and Related Data End
--=======================================================

--=======================================================
-- Removing Company Templates and Related Data Start
--=======================================================

BEGIN
   IF (SUBSTR(UPPER('&remove_data'),1,1)  = 'Y') THEN
      dbms_output.put_line('Removing Company Templates and Related Data...');
   END IF;
END;
/

----------------------------------------------------------------
-- Removing company template data related to the module
----------------------------------------------------------------
BEGIN
   IF (SUBSTR(UPPER('&remove_data'),1,1)  = 'Y') THEN
      dbms_output.put_line('Removing Company Templates...');
      Create_Company_API.Remove_Company_Templs_Per_Comp('FNDMIG');
   END IF;
END;
/

----------------------------------------------------------------
      -- Removing create company metadata
----------------------------------------------------------------
BEGIN
   IF (SUBSTR(UPPER('&remove_data'),1,1)  = 'Y') THEN
      dbms_output.put_line('Removing Company Template Meta Data...');
      Crecomp_Component_API.Remove_Crecomp_Component('FNDMIG');
   END IF;
END;
/

----------------------------------------------------------------
-- Removing client mappings related to the module
----------------------------------------------------------------
BEGIN
   IF (SUBSTR(UPPER('&remove_data'),1,1)  = 'Y') THEN
      dbms_output.put_line('Removing Client Mappings related to the Module...');
      Client_Mapping_API.Remove_Mapping_Per_Module('FNDMIG');
   END IF;
END;
/

--=======================================================
-- Removing Company Templates and Related Data End
--=======================================================


----------------------------------------------------------------
-- Removing dimension metadata owned by module
----------------------------------------------------------------
BEGIN
   IF (SUBSTR(UPPER('&remove_data'),1,1)  = 'Y') THEN
      dbms_output.put_line('Removing Dimension Metadata owned by the Module...');
      Xlr_Meta_Util_API.Remove_Dimensions('FNDMIG');
   END IF;
END;
/

----------------------------------------------------------------
      -- Removing fact metadata owned by module
----------------------------------------------------------------
BEGIN
   IF (SUBSTR(UPPER('&remove_data'),1,1)  = 'Y') THEN
      dbms_output.put_line('Removing Fact Metadata owned by the Module...');
      Xlr_Meta_Util_API.Remove_Facts('FNDMIG');
   END IF;
END;
/

----------------------------------------------------------------
-- Removing PO entries in repository
----------------------------------------------------------------
BEGIN
   IF (SUBSTR(UPPER('&remove_data'),1,1)  = 'Y') THEN
      dbms_output.put_line('Removing PO Entries in the Repository...');
      PRES_OBJECT_UTIL_API.Reset_Repository('FNDMIG');
   END IF;
END;
/

----------------------------------------------------------------
-- Removing language related entries
----------------------------------------------------------------
BEGIN
   IF (SUBSTR(UPPER('&remove_data'),1,1)  = 'Y') THEN
      dbms_output.put_line('Removing Language related Entries...');
      LANGUAGE_MODULE_API.Remove__('FNDMIG');
   END IF;
END;
/

----------------------------------------------------------------
-- Removing batch schedules related to the module
----------------------------------------------------------------
BEGIN
   IF (SUBSTR(UPPER('&remove_data'),1,1)  = 'Y') THEN
      dbms_output.put_line('Removing Batch Schedules related to the Module...');
      Batch_SYS.Rem_Cascade_Batch_Schedule_Met('INTFACE_HEADER_API.START_BATCH_');
   END IF;
END;
/

----------------------------------------------------------------
-- Removing reports for this module
----------------------------------------------------------------
BEGIN
   IF (SUBSTR(UPPER('&remove_data'),1,1)  = 'Y') THEN
      dbms_output.put_line('Removing Reports for the module...');
      Report_SYS.Remove_Report_Definition('INTFACE_DOCUMENTATION_REP');
   END IF;
END;
/

----------------------------------------------------------------
-- Removing events related to this module
----------------------------------------------------------------
BEGIN
   IF (SUBSTR(UPPER('&remove_data'),1,1)  = 'Y') THEN
      dbms_output.put_line('Removing Events Related to this Module...');
      NULL;
   END IF;
END;
/

----------------------------------------------------------------
-- Removing search domain related to the module
----------------------------------------------------------------
BEGIN
   IF (SUBSTR(UPPER('&remove_data'),1,1)  = 'Y') THEN
      dbms_output.put_line('Removing Search Domains for the Module...');
      NULL;
   END IF;
END;
/

----------------------------------------------------------------
-- Removing objects connections related to the module
----------------------------------------------------------------
BEGIN
   IF (SUBSTR(UPPER('&remove_data'),1,1)  = 'Y') THEN
      dbms_output.put_line('Removing Objects Connections related to the Module...');
      NULL;
   END IF;
END;
/

BEGIN
   IF (SUBSTR(UPPER('&remove_data'),1,1)  = 'Y') THEN
      dbms_output.put_line('Finished Removing Module Specific Data...');
   END IF;
END;
/

--=======================================================
-- DATA REMOVAL SECTION END
--=======================================================


----------------------------------------------------------------
-- Number of synonyms           : 0
-- Number of packages           : 51
-- Number of views              : 43
-- Number of triggers           : 0
-- Number of sequences          : 3
-- Number of materialized views : 0
-- Number of tables             : 22
----------------------------------------------------------------


----------------------------------------------------------------
-- Drop synonyms
----------------------------------------------------------------


----------------------------------------------------------------
-- Drop packages
----------------------------------------------------------------

BEGIN
   dbms_output.put_line('Removing Packages for the Module...');
   Installation_SYS.Remove_Package('INTFACE_CHANGE_DEFAULTS_API', TRUE);
   Installation_SYS.Remove_Package('INTFACE_CONV_LIST_API', TRUE);
   Installation_SYS.Remove_Package('INTFACE_CONV_LIST_COLS_API', TRUE);
   Installation_SYS.Remove_Package('INTFACE_DEFAULT_RULES_API', TRUE);
   Installation_SYS.Remove_Package('INTFACE_DETAIL_API', TRUE);
   Installation_SYS.Remove_Package('INTFACE_DETAIL_UTIL_API', TRUE);
   Installation_SYS.Remove_Package('INTFACE_DIRECTION_API', TRUE);
   Installation_SYS.Remove_Package('INTFACE_DOCUMENTATION_RPI', TRUE);
   Installation_SYS.Remove_Package('INTFACE_EVENTS_API', TRUE);
   Installation_SYS.Remove_Package('INTFACE_EXCEL_CONNECT_API', TRUE);
   Installation_SYS.Remove_Package('INTFACE_EXECUTION_API', TRUE);
   Installation_SYS.Remove_Package('INTFACE_EXECUTION_DETAIL_API', TRUE);
   Installation_SYS.Remove_Package('INTFACE_EXECUTION_UTIL_API', TRUE);
   Installation_SYS.Remove_Package('INTFACE_EXEC_INTERVAL_TYPE_API', TRUE);
   Installation_SYS.Remove_Package('INTFACE_FILE_LOCATION_API', TRUE);
   Installation_SYS.Remove_Package('INTFACE_FORMAT_CHAR_API', TRUE);
   Installation_SYS.Remove_Package('INTFACE_GROUP_API', TRUE);
   Installation_SYS.Remove_Package('INTFACE_HEADER_API', TRUE);
   Installation_SYS.Remove_Package('INTFACE_JOB_DETAIL_API', TRUE);
   Installation_SYS.Remove_Package('INTFACE_JOB_HIST_DETAIL_API', TRUE);
   Installation_SYS.Remove_Package('INTFACE_JOB_HIST_HEAD_API', TRUE);
   Installation_SYS.Remove_Package('INTFACE_JOB_STATUS_API', TRUE);
   Installation_SYS.Remove_Package('INTFACE_METHOD_ACTION_API', TRUE);
   Installation_SYS.Remove_Package('INTFACE_METHOD_LIST_API', TRUE);
   Installation_SYS.Remove_Package('INTFACE_METHOD_LIST_ATTRIB_API', TRUE);
   Installation_SYS.Remove_Package('INTFACE_MODE_API', TRUE);
   Installation_SYS.Remove_Package('INTFACE_PREFIX_OPTION_API', TRUE);
   Installation_SYS.Remove_Package('INTFACE_PRIVILEGE_API', TRUE);
   Installation_SYS.Remove_Package('INTFACE_PROCEDURES_API', TRUE);
   Installation_SYS.Remove_Package('INTFACE_PR_USER_API', TRUE);
   Installation_SYS.Remove_Package('INTFACE_QUICK_REPORT_UTIL_API', TRUE);
   Installation_SYS.Remove_Package('INTFACE_REPLICATION_LOG_API', TRUE);
   Installation_SYS.Remove_Package('INTFACE_REPLIC_CRITERIA_API', TRUE);
   Installation_SYS.Remove_Package('INTFACE_REPL_ELEM_TYPE_API', TRUE);
   Installation_SYS.Remove_Package('INTFACE_REPL_MAINT_UTIL_API', TRUE);
   Installation_SYS.Remove_Package('INTFACE_REPL_MESS_TYPE_API', TRUE);
   Installation_SYS.Remove_Package('INTFACE_REPL_OUT_LOG_API', TRUE);
   Installation_SYS.Remove_Package('INTFACE_REPL_PACKAGE_UTIL_API', TRUE);
   Installation_SYS.Remove_Package('INTFACE_REPL_REC_TYPE_API', TRUE);
   Installation_SYS.Remove_Package('INTFACE_REPL_STRUCTURE_API', TRUE);
   Installation_SYS.Remove_Package('INTFACE_REPL_STRUCT_COLS_API', TRUE);
   Installation_SYS.Remove_Package('INTFACE_REPL_TRIGGERS_UTIL_API', TRUE);
   Installation_SYS.Remove_Package('INTFACE_RULES_API', TRUE);
   Installation_SYS.Remove_Package('INTFACE_RULE_FLAG_API', TRUE);
   Installation_SYS.Remove_Package('INTFACE_RULE_VALUE_API', TRUE);
   Installation_SYS.Remove_Package('INTFACE_SERVER_FILE_API', TRUE);
   Installation_SYS.Remove_Package('INTFACE_TABLE_MIGRATIONS_API', TRUE);
   Installation_SYS.Remove_Package('INTFACE_USER_API', TRUE);
   Installation_SYS.Remove_Package('INTFACE_UTIL_API', TRUE);
   Installation_SYS.Remove_Package('INTFACE_VIEWS_API', TRUE);
   Installation_SYS.Remove_Package('INTFACE_XSD_UTIL_API', TRUE);
END;
/

----------------------------------------------------------------
-- Drop views
----------------------------------------------------------------

BEGIN
   dbms_output.put_line('Removing Views for the Module...');
   Installation_SYS.Remove_View('INTFACE_ALLOWED_JOBS', TRUE);
   Installation_SYS.Remove_View('INTFACE_CHARACTERSET_LOV', TRUE);
   Installation_SYS.Remove_View('INTFACE_CONV_LIST', TRUE);
   Installation_SYS.Remove_View('INTFACE_CONV_LIST_COLS', TRUE);
   Installation_SYS.Remove_View('INTFACE_DEFAULT_RULES', TRUE);
   Installation_SYS.Remove_View('INTFACE_DETAIL', TRUE);
   Installation_SYS.Remove_View('INTFACE_DETAIL_COL_LOV', TRUE);
   Installation_SYS.Remove_View('INTFACE_DOCUMENTATION_REP', TRUE);
   Installation_SYS.Remove_View('INTFACE_EXCEL_INPUT_DEFAULT', TRUE);
   Installation_SYS.Remove_View('INTFACE_EXCEL_INPUT_FORMAT', TRUE);
   Installation_SYS.Remove_View('INTFACE_EXECUTION', TRUE);
   Installation_SYS.Remove_View('INTFACE_EXECUTION_DETAIL', TRUE);
   Installation_SYS.Remove_View('INTFACE_GROUP', TRUE);
   Installation_SYS.Remove_View('INTFACE_HEADER', TRUE);
   Installation_SYS.Remove_View('INTFACE_INFO_SERVICES_RPV', TRUE);
   Installation_SYS.Remove_View('INTFACE_JOB_DETAIL', TRUE);
   Installation_SYS.Remove_View('INTFACE_JOB_HIST_DETAIL', TRUE);
   Installation_SYS.Remove_View('INTFACE_JOB_HIST_HEAD', TRUE);
   Installation_SYS.Remove_View('INTFACE_METHOD_LIST', TRUE);
   Installation_SYS.Remove_View('INTFACE_METHOD_LIST_ATTRIB', TRUE);
   Installation_SYS.Remove_View('INTFACE_PROCEDURES', TRUE);
   Installation_SYS.Remove_View('INTFACE_PROC_LOV_EXCL_REPL', TRUE);
   Installation_SYS.Remove_View('INTFACE_PROC_LOV_INCL_REPL', TRUE);
   Installation_SYS.Remove_View('INTFACE_PR_USER', TRUE);
   Installation_SYS.Remove_View('INTFACE_REPLICATION_LOG', TRUE);
   Installation_SYS.Remove_View('INTFACE_REPL_DB_OBJECTS', TRUE);
   Installation_SYS.Remove_View('INTFACE_REPL_EXPORT_INFO', TRUE);
   Installation_SYS.Remove_View('INTFACE_REPL_OUT_LOG', TRUE);
   Installation_SYS.Remove_View('INTFACE_REPL_PARENT_LOV', TRUE);
   Installation_SYS.Remove_View('INTFACE_REPL_STRUCTURE', TRUE);
   Installation_SYS.Remove_View('INTFACE_REPL_STRUCT_COLS', TRUE);
   Installation_SYS.Remove_View('INTFACE_REPL_TABLE_LOV', TRUE);
   Installation_SYS.Remove_View('INTFACE_RULES', TRUE);
   Installation_SYS.Remove_View('INTFACE_RULES_LOV', TRUE);
   Installation_SYS.Remove_View('INTFACE_SERVER_DIR_LOV', TRUE);
   Installation_SYS.Remove_View('INTFACE_SERVER_FILES_LOV', TRUE);
   Installation_SYS.Remove_View('INTFACE_SERVER_PROCESSES', TRUE);
   Installation_SYS.Remove_View('INTFACE_SOURCE_COL_LOV', TRUE);
   Installation_SYS.Remove_View('INTFACE_TABLE_MIGRATIONS', TRUE);
   Installation_SYS.Remove_View('INTFACE_TABLE_NAME_LOV', TRUE);
   Installation_SYS.Remove_View('INTFACE_USER', TRUE);
   Installation_SYS.Remove_View('INTFACE_VIEWS', TRUE);
   Installation_SYS.Remove_View('INTFACE_VIEWS_COL_INFO', TRUE);
END;
/

----------------------------------------------------------------
-- Drop triggers
----------------------------------------------------------------

BEGIN
   dbms_output.put_line('Removing Triggers for the Module...');
   NULL;
END;
/

----------------------------------------------------------------
-- Drop sequences
----------------------------------------------------------------

BEGIN
   dbms_output.put_line('Removing Sequences Refered only by the current Module...');
   Installation_SYS.Remove_Sequence('INTFACE_BACKUP_FILE_SEQ', TRUE);
   Installation_SYS.Remove_Sequence('INTFACE_EXCEL_SEQ', TRUE);
END;
/

----------------------------------------------------------------
-- NOTE: Sequences below are refered by current module but are also
--       referred by other packages in other modules
----------------------------------------------------------------

BEGIN
   dbms_output.put_line('Removing Sequences that are referred by other Modules as well...');
   NULL;
END;
/

----------------------------------------------------------------
-- Drop Materialized Views
----------------------------------------------------------------

BEGIN
   dbms_output.put_line('Removing Materialized Views for the Module...');
   NULL;
END;
/

----------------------------------------------------------------
-- Drop tables
----------------------------------------------------------------
-- NOTE: Tables below are referred only by current module...

BEGIN
   dbms_output.put_line('Removing Tables refered only by current Module...');
   Installation_SYS.Remove_Table('INTFACE_CONV_LIST_COLS_TAB', TRUE);
   Installation_SYS.Remove_Table('INTFACE_CONV_LIST_TAB', TRUE);
   Installation_SYS.Remove_Table('INTFACE_DEFAULT_RULES_TAB', TRUE);
   Installation_SYS.Remove_Table('INTFACE_DETAIL_TAB', TRUE);
   Installation_SYS.Remove_Table('INTFACE_EXECUTION_DETAIL_TAB', TRUE);
   Installation_SYS.Remove_Table('INTFACE_EXECUTION_TAB', TRUE);
   Installation_SYS.Remove_Table('INTFACE_GROUP_TAB', TRUE);
   Installation_SYS.Remove_Table('INTFACE_HEADER_TAB', TRUE);
   Installation_SYS.Remove_Table('INTFACE_INFO_SERVICES_RPT', TRUE);
   Installation_SYS.Remove_Table('INTFACE_JOB_DETAIL_TAB', TRUE);
   Installation_SYS.Remove_Table('INTFACE_JOB_HIST_DETAIL_TAB', TRUE);
   Installation_SYS.Remove_Table('INTFACE_JOB_HIST_HEAD_TAB', TRUE);
   Installation_SYS.Remove_Table('INTFACE_METHOD_LIST_ATTRIB_TAB', TRUE);
   Installation_SYS.Remove_Table('INTFACE_METHOD_LIST_TAB', TRUE);
   Installation_SYS.Remove_Table('INTFACE_PROCEDURES_TAB', TRUE);
   Installation_SYS.Remove_Table('INTFACE_PR_USER_TAB', TRUE);
   Installation_SYS.Remove_Table('INTFACE_REPLICATION_LOG_TAB', TRUE);
   Installation_SYS.Remove_Table('INTFACE_REPL_OUT_LOG_TAB', TRUE);
   Installation_SYS.Remove_Table('INTFACE_REPL_STRUCTURE_TAB', TRUE);
   Installation_SYS.Remove_Table('INTFACE_REPL_STRUCT_COLS_TAB', TRUE);
   Installation_SYS.Remove_Table('INTFACE_RULES_TAB', TRUE);
   Installation_SYS.Remove_Table('INTFACE_USER_TAB', TRUE);
END;
/

----------------------------------------------------------------
-- NOTE: Tables below are belongs to the current module but are also
--       referred by other objects in other modules
--       These tables should be dropped BUT all the references will be
--       Invalidated
----------------------------------------------------------------

BEGIN
   dbms_output.put_line('Removing Tables for the current module but also referred by other Modules as well...');
   NULL;
END;
/


----------------------------------------------------------------
-- Removing patch registrations for this module
----------------------------------------------------------------
BEGIN
   dbms_output.put_line('Removing Patch Registrations for the Module...');
   Installation_SYS.Clear_Db_Patch_Registration('FNDMIG');
END;
/

----------------------------------------------------------------
-- Removing module version information
----------------------------------------------------------------
BEGIN
   dbms_output.put_line('Removing Module Version Information for the Module...');
   Module_Api.Clear('FNDMIG');
END;
/




COMMIT;


----------------------------------------------------------------
--Re Compiling All Invalid Objects
----------------------------------------------------------------
PROMPT Re Compiling All Invalid Objects
EXEC Database_SYS.Compile_All_Invalid_Objects;

----------------------------------------------------------------
-- End
----------------------------------------------------------------


SPOOL OFF


SET SERVEROUTPUT OFF

