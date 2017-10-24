--------------------------------------------------------------------------------
--
--  File:         AccrulCl.sql
--
--  Component:    ACCRUL
--
--  Purpose:      Remove copied default data tables and other temporary tables
--                used to upgrade Accounting Rules.
-- 
--  Localization: Not needed.
--
--  Notes:        
--
--  Date    Sign     History
--  ------  ----     --------------------------------------------------------------
--  030228  MGUTSE   Created.
--  030702  Pperse   Removing renamed Ext_Files tables  
--  040909  Nalslk   Removing renamed tables from 8.10.0 version
--  050726  THPELK   Remove the Remove Package for CURR_TYPE_DEF_API
--  051014  reanpl   FIAD376 Actual Costing, remove valid_until column from POSTING_CTRL_DETAIL_TAB and POSTING_CTRL_COMB_DETAIL_TAB
--  060608  iswalk   FIPL614A, remove combined_control_type from POSTING_CTRL_TAB and POSTING_CTRL_DETAIL_TAB.  
--  060619  iswalk   FIPL614A, remove allowed_default from POSTING_CTRL_CONTROL_TYPE_TAB.
--  070622  shsalk   B145889, Dropped unwanted triggers coming from MEE.
--  091007  AsHelk   Bug 86122, Added escape mechanism.
--  100317  Samwlk   EAFH-2552, Remove posting_ctrl_def_900.
--  210524  Kagalk   EAFH-2939, Removed column accrul_id from Transferred_Voucher_Tab, Voucher_Tab
--  130805  DipeLK   CAHOOK-1168, Removed column MAX_NUMBER_OF_CHAR_TEMP from ACCOUNTING_CODE_PART_TAB
--  141204  DipeLK   PRFI-3818,Dropping obsolete COLUMNS from ACCOUNT_TYPE_TAB.
--  141205  DipeLK   PRFI-3818,Dropping obsolete COLUMNS from POSTING_CTRL_ALLOWED_COMB_TAB.
--  141205  DipeLK   PRFI-3818,Dropping obsolete COLUMNS from POSTING_CTRL_COMB_DETAIL_TAB.
--  141205  DipeLK   PRFI-3818,Dropping obsolete COLUMNS from STATUTORY_FEE_TAB.
--  141208  DipeLK   PRFI-3818,Dropping obsolete COLUMNS from TRANSFERRED_VOUCHER_TAB.
--  141208  DipeLK   PRFI-3818,Dropping obsolete COLUMNS from USER_FINANCE_TAB.
--  141217  DipeLK   PRFI-3818,Dropping obsolete COLUMNS from VOUCHER_TYPE_TAB.
--  141217  DipeLK   PRFI-3818,Dropping obsolete COLUMNS from VOUCHER_TYPE_USER_GROUP_TAB
--------------------------------------------------------------------------------

PROMPT NOTE! This script drops tables and columns no longer used in core
PROMPT and must be edited before usage.                                         
ACCEPT Press_any_key                                                            
EXIT; -- Remove me before usage

SET SERVEROUTPUT ON

PROMPT Dropping obsolete tables from previous releases.
BEGIN
   Database_Sys.Remove_Table( 'ACCOUNT_TYPE_DEF_TAB_TMP' );
   Database_Sys.Remove_Table( 'ACCOUNT_TYPE_DEF_TAB_850' );
   Database_Sys.Remove_Table( 'CURRENCY_CODE_TAB_SAVE' );
   Database_Sys.Remove_Table( 'CURRENCY_CODE_TAB_850' );
   Database_Sys.Remove_Table( 'ACCOUNT_TYPE_TAB_TMP' );
   Database_Sys.Remove_Table( 'ACCOUNT_TYPE_TAB_850' );
   Database_Sys.Remove_Table( 'PAYMENT_TERM_TAB_SAVE' );
   Database_Sys.Remove_Table( 'PAYMENT_TERM_TAB_852' );
END;
/

PROMPT Dropping obsolete tables from 870 releases.
BEGIN
   Database_Sys.Remove_Table( 'CURRENCY_CODE_DEF_870' );
   Database_Sys.Remove_Table( 'CURRENCY_RATE_DEF_870' );
   Database_Sys.Remove_Table( 'CURRENCY_TYPE_DEF_870' );
   Database_Sys.Remove_Table( 'TEXT_FIELD_TRANSLATION_DEF_870' );
   Database_Sys.Remove_Table( 'ACCOUNTING_CODE_PART_DEF_870' );
   Database_Sys.Remove_Table( 'TRANSLATION_TYPE_870' );
   Database_Sys.Remove_Table( 'ACCOUNT_GROUP_DEF_870' );
   Database_Sys.Remove_Table( 'ACCNT_CODE_PART_VALUE_DEF_870' );
   Database_Sys.Remove_Table( 'ACCOUNT_CODESTR_COMB_DEF_870' );
   Database_Sys.Remove_Table( 'ACCOUNTING_PERIOD_DEF_870' );
   Database_Sys.Remove_Table( 'ACCOUNT_TYPE_DEF_870' );
   Database_Sys.Remove_Table( 'FUNCTION_GROUP_870' );
   Database_Sys.Remove_Table( 'VOUCHER_TYPE_DEF_870' );
   Database_Sys.Remove_Table( 'VOUCHER_TYPE_DETAIL_DEF_870' );
   Database_Sys.Remove_Table( 'VOUCHER_TYPE_DETAIL_DEF_870' );
   Database_Sys.Remove_Table( 'VOUCHER_TYPE_USER_GRP_DEF_870' );
   Database_Sys.Remove_Table( 'VOUCHER_NO_SERIAL_DEF_870' );
   Database_Sys.Remove_Table( 'USER_GROUP_FINANCE_DEF_870' );
   Database_Sys.Remove_Table( 'USER_FINANCE_DEF_870' );
   Database_Sys.Remove_Table( 'USER_GROUP_MEMBER_FIN_DEF_870' );
   Database_Sys.Remove_Table( 'USER_GROUP_PERIOD_DEF_870' );
   Database_Sys.Remove_Table( 'POSTING_CTRL_POSTING_TYPE_870' );
   Database_Sys.Remove_Table( 'POSTING_CTRL_ALLOWED_COMB_870' );
   Database_Sys.Remove_Table( 'ACC_POSTING_CTRL_DEF_870' );
   Database_Sys.Remove_Table( 'ACC_POST_CTRL_DETAIL_DEF_870' );
   Database_Sys.Remove_Table( 'POSTING_CTRL_CONTROL_TYPE_870' );
   Database_Sys.Remove_Table( 'CREATE_ACCRUL_COMPANY_870' );
   Database_Sys.Remove_Table( 'PAYMENT_TERM_DEF_870' );
   Database_Sys.Remove_Table( 'STATUTORY_FEE_DEF_870' );
   Database_Sys.Remove_Table( 'ACCRUL_ATTRIBUTE_870' );
   Database_Sys.Remove_Table( 'POSTING_CTRL_DEF_870' );
END;
/   

PROMPT Dropping obsolete tables from 8.7.0.A releases.
BEGIN
   Database_Sys.Remove_Table( 'CURRENCY_CODE_DEF870A' );
   Database_Sys.Remove_Table( 'CURRENCY_RATE_DEF870A' );
   Database_Sys.Remove_Table( 'CURRENCY_TYPE_DEF870A' );
   Database_Sys.Remove_Table( 'TEXT_FIELD_TRANSLATION_DEF870A' );
   Database_Sys.Remove_Table( 'ACCOUNTING_CODE_PART_DEF870A' );
   Database_Sys.Remove_Table( 'TRANSLATION_TYPE870A' );
   Database_Sys.Remove_Table( 'ACCOUNT_GROUP_DEF870A' );
   Database_Sys.Remove_Table( 'ACCNT_CODE_PART_VALUE_DEF870A' );
   Database_Sys.Remove_Table( 'ACCOUNT_CODESTR_COMB_DEF870A' );
   Database_Sys.Remove_Table( 'ACCOUNTING_PERIOD_DEF870A' );
   Database_Sys.Remove_Table( 'ACCOUNT_TYPE_DEF870A' );
   Database_Sys.Remove_Table( 'FUNCTION_GROUP870A' );
   Database_Sys.Remove_Table( 'VOUCHER_TYPE_DEF870A' );
   Database_Sys.Remove_Table( 'VOUCHER_TYPE_DETAIL_DEF870A' );
   Database_Sys.Remove_Table( 'VOUCHER_TYPE_USER_GRP_DEF870A' );
   Database_Sys.Remove_Table( 'VOUCHER_NO_SERIAL_DEF870A' );
   Database_Sys.Remove_Table( 'USER_GROUP_FINANCE_DEF870A' );
   Database_Sys.Remove_Table( 'USER_FINANCE_DEF870A' );
   Database_Sys.Remove_Table( 'USER_GROUP_MEMBER_FIN_DEF870A' );
   Database_Sys.Remove_Table( 'USER_GROUP_PERIOD_DEF870A' );
   Database_Sys.Remove_Table( 'POSTING_CTRL_POSTING_TYPE870A' );
   Database_Sys.Remove_Table( 'POSTING_CTRL_ALLOWED_COMB870A' );
   Database_Sys.Remove_Table( 'ACC_POSTING_CTRL_DEF870A' );
   Database_Sys.Remove_Table( 'ACC_POST_CTRL_DETAIL_DEF870A' );
   Database_Sys.Remove_Table( 'POSTING_CTRL_CONTROL_TYPE870A' );
   Database_Sys.Remove_Table( 'CREATE_ACCRUL_COMPANY870A' );
   Database_Sys.Remove_Table( 'PAYMENT_TERM_DEF870A' );
   Database_Sys.Remove_Table( 'STATUTORY_FEE_DEF870A' );
   Database_Sys.Remove_Table( 'ACCRUL_ATTRIBUTE870A' );
   Database_Sys.Remove_Table( 'POSTING_CTRL_DEF_870A' );
END;
/

PROMPT Dropping obsolete tables from 8.7.1 releases.
BEGIN
   Database_Sys.Remove_Table( 'CURRENCY_CODE_DEF_871' );
   Database_Sys.Remove_Table( 'TEXT_FIELD_TRANSLATION_DEF_871' );
   Database_Sys.Remove_Table( 'ACCOUNTING_CODE_PART_DEF_871' );
   Database_Sys.Remove_Table( 'ACCOUNT_GROUP_DEF_871' );
   Database_Sys.Remove_Table( 'ACCNT_CODE_PART_VALUE_DEF_871' );
   Database_Sys.Remove_Table( 'ACCOUNT_CODESTR_COMB_DEF_871' );
   Database_Sys.Remove_Table( 'ACCOUNT_CODESTR_COMB_DEF_871' );
   Database_Sys.Remove_Table( 'ACCOUNTING_PERIOD_DEF_871' );
   Database_Sys.Remove_Table( 'ACCOUNT_TYPE_DEF_871');
   Database_Sys.Remove_Table( 'VOUCHER_TYPE_DEF_871');
   Database_Sys.Remove_Table( 'VOUCHER_TYPE_DETAIL_DEF_871');
   Database_Sys.Remove_Table( 'VOUCHER_TYPE_USER_GRP_DEF_871');
   Database_Sys.Remove_Table( 'VOUCHER_NO_SERIAL_DEF_871');
   Database_Sys.Remove_Table( 'USER_GROUP_FINANCE_DEF_871');
   Database_Sys.Remove_Table( 'USER_GROUP_PERIOD_DEF_871');
   Database_Sys.Remove_Table( 'USER_GROUP_MEMBER_FIN_DEF_871');
   Database_Sys.Remove_Table( 'USER_FINANCE_DEF_871');
   Database_Sys.Remove_Table( 'ACC_POSTING_CTRL_DEF_871');
   Database_Sys.Remove_Table( 'ACC_POST_CTRL_DETAIL_DEF_871');
   Database_Sys.Remove_Table( 'CREATE_ACCRUL_COMPANY_871');
   Database_Sys.Remove_Table( 'PAYMENT_TERM_DEF_871');
   Database_Sys.Remove_Table( 'STATUTORY_FEE_DEF_871');
   Database_Sys.Remove_Table( 'CURRENCY_RATE_DEF_871');
   Database_Sys.Remove_Table( 'CURRENCY_TYPE_DEF_871');
   Database_Sys.Remove_Table( 'TRANSLATION_TYPE_871');
   Database_Sys.Remove_Table( 'FUNCTION_GROUP_871');
   Database_Sys.Remove_Table( 'POSTING_CTRL_POSTING_TYPE_871');
   Database_Sys.Remove_Table( 'POSTING_CTRL_ALLOWED_COMB_871');
   Database_Sys.Remove_Table( 'POSTING_CTRL_CONTROL_TYPE_871');
   Database_Sys.Remove_Table( 'ACCRUL_ATTRIBUTE_871');
   Database_Sys.Remove_Table( 'POSTING_CTRL_DEF_871');
   Database_Sys.Remove_Table( 'EXT_CURRENCY_BATCH_871');
   Database_SYS.Remove_Table( 'COMPANY_FINANCE_LOG_871');
END;
/
   
PROMPT Dropping obsolete tables from 8.8.0 releases.
BEGIN
   Database_Sys.Remove_Table( 'USER_GROUP_FINANCE_DEF_880');
   Database_Sys.Remove_Table( 'USER_GROUP_PERIOD_DEF_880');
   Database_Sys.Remove_Table( 'USER_GROUP_MEMBER_FIN_DEF_880');
   Database_Sys.Remove_Table( 'USER_FINANCE_DEF_880');
   Database_Sys.Remove_Table( 'EXT_CURRENCY_880');
   Database_Sys.Remove_Table( 'TEXT_FIELD_TRANSLATION_880');   
   Database_Sys.Remove_Table( 'ACCRUL_TMP_V880');
END;
/

PROMPT Dropping obsolete tables from 8.9.0 releases.
BEGIN
   Database_Sys.Remove_Table( 'POSTING_CTRL_DETAIL_890');
   Database_Sys.Remove_Table( 'POSTING_CTRL_COMB_DETAIL_890');
   Database_Sys.Remove_Table( 'EXT_FILE_TYPE_890');
   Database_Sys.Remove_Table( 'EXT_FILE_TYPE_GROUP_890');
   Database_Sys.Remove_Table( 'EXT_FILE_COLUMN_890');
   Database_Sys.Remove_Table( 'EXT_FILE_890');
   Database_Sys.Remove_Table( 'EXT_FILE_CONTROL_890');
   Database_Sys.Remove_Table( 'EXT_FILE_DETAIL_890');
   Database_Sys.Remove_Table( 'EXT_FILE_LOAD_890');
   Database_Sys.Remove_Table( 'EXT_PARAMETERS_890');
   Database_Sys.Remove_Table( 'EXT_CURRENCY_TASK_DETAIL_890');
   Database_Sys.Remove_Table( 'EXT_CURRENCY_TASK_890');
   Database_Sys.Remove_Table( 'POSTING_CTRL_TEMP_TAB');
   Database_Sys.Remove_Table( 'EURO_CORRECTION_ACCRUL_890');
   Database_Sys.Remove_Table( 'ACCRUL_TMP_V890');
END;
/

PROMPT Dropping obsolete tables from 8.10.0 releases.
BEGIN
   Database_Sys.Remove_Table( 'CURRENCY_TYPE_8100' );
END;
/

PROMPT Dropping obsolete tables from 8.10.0 releases.
BEGIN
   Database_Sys.Remove_Table( 'CURRENCY_TYPE_8100' );
END;
/

PROMPT Dropping obsolete tables from 9.0.0 releases.
BEGIN
   Database_Sys.Remove_Table( 'Posting_Ctrl_Def_900', TRUE );
END;
/

PROMPT Dropping obsolete packages AND VIEWS
BEGIN
   Database_SYS.Remove_View('EXT_PARAM_VOUCHER_TYPES', TRUE );
END;
/

PROMPT Dropping obsolete COLUMNS
DECLARE
   table_name_    VARCHAR2(30) := 'ACCOUNTING_CODESTR_COMB_TAB';
   column_        Database_SYS.ColRec;
BEGIN
   column_ := Database_SYS.Set_Column_Values('Keystring');
   Database_SYS.Alter_Table_Column ( table_name_, 'D', column_, TRUE);
END;
/

DECLARE
   table_name_    VARCHAR2(30) := 'PAYMENT_TERM_TAB';
   column_        Database_SYS.ColRec;
BEGIN
   column_ := Database_SYS.Set_Column_Values('Days_Cnt', 'NUMBER(20,0)' );
   Database_SYS.Alter_Table_Column ( table_name_, 'D', column_, TRUE );
   column_ := Database_SYS.Set_Column_Values('No_Free_Deliv_Month', 'NUMBER(20)' );
   Database_SYS.Alter_Table_Column ( table_name_, 'D', column_, TRUE );
   column_ := Database_SYS.Set_Column_Values('End_Of_Month', 'VARCHAR2(5)' );
   Database_SYS.Alter_Table_Column ( table_name_, 'D', column_, TRUE );
   column_ := Database_SYS.Set_Column_Values('Specific_Due_Day', 'NUMBER(20)' );
   Database_SYS.Alter_Table_Column ( table_name_, 'D', column_, TRUE );
END;
/

PROMPT DROP column valid_until FROM POSTING_CTRL_DETAIL_TAB
DECLARE
   table_name_      VARCHAR2(30) := 'POSTING_CTRL_DETAIL_TAB';
   column_          Database_SYS.ColRec;
BEGIN
   column_ := Database_SYS.Set_Column_Values('VALID_UNTIL');
   Database_SYS.Alter_Table_Column ( table_name_, 'D', column_, TRUE);
END;
/

DECLARE
   column_          Database_SYS.ColRec;
BEGIN
   column_ := Database_SYS.Set_Column_Values('VALID_UNTIL');
   Database_SYS.Alter_Table_Column ( 'POSTING_CTRL_COMB_DETAIL_TAB', 'D', column_, TRUE);
   column_ := Database_SYS.Set_Column_Values('STRING_EVALUATE');
   Database_SYS.Alter_Table_Column ( 'EXT_FILE_TEMPLATE_CONTROL_TAB', 'D', column_, TRUE);
   column_ := Database_SYS.Set_Column_Values('DEFAULT_VALUE');
   Database_SYS.Alter_Table_Column ( 'EXT_FILE_TEMPLATE_DETAIL_TAB', 'D', column_, TRUE);
   column_ := Database_SYS.Set_Column_Values('STRING_EVALUATE');
   Database_SYS.Alter_Table_Column ( 'EXT_FILE_TEMPLATE_DETAIL_TAB', 'D', column_, TRUE);
END;
/

PROMPT Dropping obsolete COLUMNS from 8.11.0 releases.
DECLARE
   column_        Database_SYS.ColRec;
BEGIN
   column_ := Database_SYS.Set_Column_Values('combined_control_type');
   Database_SYS.Alter_Table_Column ( 'POSTING_CTRL_TAB', 'D', column_, TRUE);
   column_ := Database_SYS.Set_Column_Values('spec_combined_control_type');
   Database_SYS.Alter_Table_Column ( 'POSTING_CTRL_DETAIL_TAB', 'D', column_, TRUE);
   column_ := Database_SYS.Set_Column_Values('allowed_default');
   Database_SYS.Alter_Table_Column ( 'POSTING_CTRL_CONTROL_TYPE_TAB', 'D', column_, TRUE);
END;
/

PROMPT Dropping obsolete COLUMNS from 9.0.0 releases.
DECLARE
   column_          Database_SYS.ColRec;
BEGIN
   column_ := Database_SYS.Set_Column_Values('ACCRUL_ID');
   Database_SYS.Alter_Table_Column ( 'TRANSFERRED_VOUCHER_TAB', 'D', column_, TRUE);
   column_ := Database_SYS.Set_Column_Values('ACCRUL_ID');
   Database_SYS.Alter_Table_Column ( 'VOUCHER_TAB', 'D', column_, TRUE);
END;
/

PROMPT Dropping obsolete triggers.
BEGIN
   Installation_SYS.Remove_Trigger ( 'POSTING_CTRL_DETAIL_U');
   Installation_SYS.Remove_Trigger ( 'POSTING_CTRL_DETAIL_I');
   Installation_SYS.Remove_Trigger ( 'POSTING_CTRL_DETAIL_D');
END;
/

PROMPT Dropping Temporary COLUMN from ACCOUNTING_CODE_PART_TAB
DECLARE
   table_name_ VARCHAR2(30) := 'ACCOUNTING_CODE_PART_TAB';
   column_     Database_SYS.ColRec;
BEGIN
   column_ := Database_SYS.Set_Column_Values('MAX_NUMBER_OF_CHAR_TEMP');
   Database_SYS.Alter_Table_Column ( table_name_ , 'D', column_ , TRUE );
END;
/

PROMPT Dropping obsolete COLUMNS from 9.1.0 releases.
DECLARE
   column_          Database_SYS.ColRec;
BEGIN
   column_ := Database_SYS.Set_Column_Values('NCF_INV_STAT_FEE');
   Database_SYS.Alter_Table_Column ( 'ACCOUNTING_CODE_PART_VALUE_TAB', 'D', column_, TRUE);
   column_ := Database_SYS.Set_Column_Values('NCF_OVERRIDE_FEE');
   Database_SYS.Alter_Table_Column ( 'ACCOUNTING_CODE_PART_VALUE_TAB', 'D', column_, TRUE); 
   column_ := Database_SYS.Set_Column_Values('ACCOUNT_TYPE_DESCRIPTION');
   Database_SYS.Alter_Table_Column ( 'ACCOUNT_TYPE_TAB', 'D', column_, TRUE);  
   column_ := Database_SYS.Set_Column_Values('POSTING_COMBINATION_ID');
   Database_SYS.Alter_Table_Column ( 'EXT_TRANSACTIONS_TAB', 'D', column_, TRUE);
   column_ := Database_SYS.Set_Column_Values('CCT_COMPANY');
   Database_SYS.Alter_Table_Column ( 'POSTING_CTRL_ALLOWED_COMB_TAB', 'D', column_, TRUE); 
   column_ := Database_SYS.Set_Column_Values('CONTROL_TYPE1_DESCRIPTION');
   Database_SYS.Alter_Table_Column ( 'POSTING_CTRL_COMB_DETAIL_TAB', 'D', column_, TRUE);
   column_ := Database_SYS.Set_Column_Values('CONTROL_TYPE2_DESCRIPTION');
   Database_SYS.Alter_Table_Column ( 'POSTING_CTRL_COMB_DETAIL_TAB', 'D', column_, TRUE);  
   column_ := Database_SYS.Set_Column_Values('NCF_INV_TAX_RATE');
   Database_SYS.Alter_Table_Column ( 'STATUTORY_FEE_TAB', 'D', column_, TRUE);
   column_ := Database_SYS.Set_Column_Values('TRIANGULATION_TRADE');
   Database_SYS.Alter_Table_Column ( 'STATUTORY_FEE_TAB', 'D', column_, TRUE);  
   column_ := Database_SYS.Set_Column_Values('ROWTYPE');
   Database_SYS.Alter_Table_Column ( 'TRANSFERRED_VOUCHER_TAB', 'D', column_, TRUE);
   column_ := Database_SYS.Set_Column_Values('DESCRIPTION');
   Database_SYS.Alter_Table_Column ( 'USER_FINANCE_TAB', 'D', column_, TRUE); 
   column_ := Database_SYS.Set_Column_Values('VOUCHER_GROUP');
   Database_SYS.Alter_Table_Column ( 'VOUCHER_TYPE_TAB', 'D', column_, TRUE); 
   column_ := Database_SYS.Set_Column_Values('VOUCHER_GROUP');
   Database_SYS.Alter_Table_Column ( 'VOUCHER_TYPE_USER_GROUP_TAB', 'D', column_, TRUE); 
END;
/

PROMPT -------------------------------------------------------------
PROMPT Drop of obsolete table in ACCRUL done!
PROMPT ---------------------------------------------------
        

                     
