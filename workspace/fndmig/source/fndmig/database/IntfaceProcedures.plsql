-----------------------------------------------------------------------------
--
--  Logical unit: IntfaceProcedures
--  Component:    FNDMIG
--
--  IFS Developer Studio Template Version 3.0
--
--  Date    Sign    History
--  ------  ------  ---------------------------------------------------------
--  061102  JHMASE Bug #61592 - Remove unnecessary references
--  060329  TRLYNO Bug #56862 - FNDMIG added functionality, disable obsolete LOV
--  060209  TRLYNO Bug #55643 - Change view-definitions from user_ to dba_
--  041222  JHMASE Bug #48786 - Make it work with double byte
--  040514  JHMASE Bug #44651 - No data migrated on some LUs in Method List
--  040507  TRLY   Bug #44483 - Replication of Object structures
--  030708  TRLY  Prepared for new module FNDMI
-----------------------------------------------------------------------------

layer Core;

-------------------- PUBLIC DECLARATIONS ------------------------------------


-------------------- PRIVATE DECLARATIONS -----------------------------------


-------------------- LU SPECIFIC IMPLEMENTATION METHODS ---------------------

 --dummy method for translation purposes
PROCEDURE Items_To_Localize___  
IS
   text_dummy_ VARCHAR2(2000);
BEGIN
   text_dummy_ :=  Language_SYS.Translate_Constant('IntfaceProcedures','CREATE_OUTPUT_FILE: Write data to file');
   text_dummy_ :=  Language_SYS.Translate_Constant('IntfaceProcedures','INSERT_BY_METHOD_NEW: Insert rows from file');
   text_dummy_ :=  Language_SYS.Translate_Constant('IntfaceProcedures','CHECK_BY_METHOD_NEW: Check rows from file according to Business Logic');
   text_dummy_ :=  Language_SYS.Translate_Constant('IntfaceProcedures','INSERT_OR_UPDATE: Insert or Update rows from file');
   text_dummy_ :=  Language_SYS.Translate_Constant('IntfaceProcedures','CREATE_TABLE_FROM_FI: Create table from file');
   text_dummy_ :=  Language_SYS.Translate_Constant('IntfaceProcedures','MIGRATE_SOURCE_DATA: Data migration from table/view');
   text_dummy_ :=  Language_SYS.Translate_Constant('IntfaceProcedures','FNDMIG_EXPORT: Export Data Migration definitions to file');
   text_dummy_ :=  Language_SYS.Translate_Constant('IntfaceProcedures','FNDMIG_IMPORT: Import Data Migration definitions from file');
   text_dummy_ :=  Language_SYS.Translate_Constant('IntfaceProcedures','REPLICATION: Replication');
   text_dummy_ :=  Language_SYS.Translate_Constant('IntfaceProcedures','REPL_DATA_OUT: Replicate Data Structures');
   text_dummy_ :=  Language_SYS.Translate_Constant('IntfaceProcedures','EXCEL_MIGRATION: Data Migration from Excel file');
END Items_To_Localize___;


-------------------- LU SPECIFIC PRIVATE METHODS ----------------------------


-------------------- LU SPECIFIC PROTECTED METHODS --------------------------


-------------------- LU SPECIFIC PUBLIC METHODS -----------------------------



