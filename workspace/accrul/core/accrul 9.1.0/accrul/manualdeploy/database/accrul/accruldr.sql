----------------------------------------------------------------
--
-- File     :  ACCRULDR.SQL
--
-- Component:  ACCRUL - Accounting Rules
--
-- Release  :
--
-- Created  : 2015-03-10
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


SPOOL ACCRULDR.log

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
      Posting_Ctrl_Public_API.Remove_Postingctrls_Per_Module('ACCRUL');
   END IF;
END;
/

----------------------------------------------------------------
-- Removing combined control types related to the module
----------------------------------------------------------------
BEGIN
   IF (SUBSTR(UPPER('&remove_data'),1,1)  = 'Y') THEN
      dbms_output.put_line('Removing Combined Control Types related to the Module...');
      Posting_Ctrl_Public_API.Rmv_Combctrl_Typs_Per_Module('ACCRUL');
   END IF;
END;
/

----------------------------------------------------------------
-- Removing allowed control types related to the module
----------------------------------------------------------------
BEGIN
   IF (SUBSTR(UPPER('&remove_data'),1,1)  = 'Y') THEN
      dbms_output.put_line('Removing Allowed Control Types related to the Module...');
      Posting_Ctrl_Public_API.Remove_Allowed_Comb_Per_Module('ACCRUL');
   END IF;
END;
/

----------------------------------------------------------------
-- Removing control types related to the module
----------------------------------------------------------------
BEGIN
   IF (SUBSTR(UPPER('&remove_data'),1,1)  = 'Y') THEN
      dbms_output.put_line('Removing Control Types related to the Module...');
      Posting_Ctrl_Public_API.Remove_Ctrl_Types_Per_Module('ACCRUL');
   END IF;
END;
/

----------------------------------------------------------------
-- Removing posting types related to the module
----------------------------------------------------------------
BEGIN
   IF (SUBSTR(UPPER('&remove_data'),1,1)  = 'Y') THEN
      dbms_output.put_line('Removing Control Types related to the Module...');
      Posting_Ctrl_Public_API.Remove_Posting_Typs_Per_Module('ACCRUL');
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
      Create_Company_API.Remove_Company_Templs_Per_Comp('ACCRUL');
   END IF;
END;
/

----------------------------------------------------------------
      -- Removing create company metadata
----------------------------------------------------------------
BEGIN
   IF (SUBSTR(UPPER('&remove_data'),1,1)  = 'Y') THEN
      dbms_output.put_line('Removing Company Template Meta Data...');
      Crecomp_Component_API.Remove_Crecomp_Component('ACCRUL');
   END IF;
END;
/

----------------------------------------------------------------
-- Removing client mappings related to the module
----------------------------------------------------------------
BEGIN
   IF (SUBSTR(UPPER('&remove_data'),1,1)  = 'Y') THEN
      dbms_output.put_line('Removing Client Mappings related to the Module...');
      Client_Mapping_API.Remove_Mapping_Per_Module('ACCRUL');
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
      Xlr_Meta_Util_API.Remove_Dimensions('ACCRUL');
   END IF;
END;
/

----------------------------------------------------------------
      -- Removing fact metadata owned by module
----------------------------------------------------------------
BEGIN
   IF (SUBSTR(UPPER('&remove_data'),1,1)  = 'Y') THEN
      dbms_output.put_line('Removing Fact Metadata owned by the Module...');
      Xlr_Meta_Util_API.Remove_Facts('ACCRUL');
   END IF;
END;
/

----------------------------------------------------------------
-- Removing PO entries in repository
----------------------------------------------------------------
BEGIN
   IF (SUBSTR(UPPER('&remove_data'),1,1)  = 'Y') THEN
      dbms_output.put_line('Removing PO Entries in the Repository...');
      PRES_OBJECT_UTIL_API.Reset_Repository('ACCRUL');
   END IF;
END;
/

----------------------------------------------------------------
-- Removing language related entries
----------------------------------------------------------------
BEGIN
   IF (SUBSTR(UPPER('&remove_data'),1,1)  = 'Y') THEN
      dbms_output.put_line('Removing Language related Entries...');
      LANGUAGE_MODULE_API.Remove__('ACCRUL');
   END IF;
END;
/

----------------------------------------------------------------
-- Removing batch schedules related to the module
----------------------------------------------------------------
BEGIN
   IF (SUBSTR(UPPER('&remove_data'),1,1)  = 'Y') THEN
      dbms_output.put_line('Removing Batch Schedules related to the Module...');
      Batch_SYS.Rem_Cascade_Batch_Schedule_Met('EXTERNAL_FILE_UTILITY_API.EXECUTE_BATCH_PROCESS2');
   END IF;
END;
/

----------------------------------------------------------------
-- Removing reports for this module
----------------------------------------------------------------
BEGIN
   IF (SUBSTR(UPPER('&remove_data'),1,1)  = 'Y') THEN
      dbms_output.put_line('Removing Reports for the module...');
      Report_SYS.Remove_Report_Definition('POSTING_CTRL_DETAIL_REP');
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
      Object_Connection_SYS.Disable_Logical_Unit('MultiCompanyVoucher');
      Object_Connection_SYS.Disable_Logical_Unit('MultiCompanyVoucherRow');
      Object_Connection_SYS.Disable_Logical_Unit('Voucher');
      Object_Connection_SYS.Disable_Logical_Unit('VoucherRow');
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
-- Number of packages           : 272
-- Number of views              : 513
-- Number of triggers           : 0
-- Number of sequences          : 12
-- Number of materialized views : 48
-- Number of tables             : 134
----------------------------------------------------------------


----------------------------------------------------------------
-- Drop synonyms
----------------------------------------------------------------


----------------------------------------------------------------
-- Drop packages
----------------------------------------------------------------

BEGIN
   dbms_output.put_line('Removing Packages for the Module...');
   Database_SYS.Remove_Package('ACCOUNTING_ATTRIBUTE_API', TRUE);
   Database_SYS.Remove_Package('ACCOUNTING_ATTRIBUTE_CON_API', TRUE);
   Database_SYS.Remove_Package('ACCOUNTING_ATTRIBUTE_VALUE_API', TRUE);
   Database_SYS.Remove_Package('ACCOUNTING_CODESTR_API', TRUE);
   Database_SYS.Remove_Package('ACCOUNTING_CODESTR_COMB_API', TRUE);
   Database_SYS.Remove_Package('ACCOUNTING_CODESTR_COMPL_API', TRUE);
   Database_SYS.Remove_Package('ACCOUNTING_CODESTR_CO_UTIL_API', TRUE);
   Database_SYS.Remove_Package('ACCOUNTING_CODE_PARTS_API', TRUE);
   Database_SYS.Remove_Package('ACCOUNTING_CODE_PART_A_API', TRUE);
   Database_SYS.Remove_Package('ACCOUNTING_CODE_PART_FU_API', TRUE);
   Database_SYS.Remove_Package('ACCOUNTING_CODE_PART_UTIL_API', TRUE);
   Database_SYS.Remove_Package('ACCOUNTING_CODE_PART_VALUE_API', TRUE);
   Database_SYS.Remove_Package('ACCOUNTING_CODE_PART_Y_N_API', TRUE);
   Database_SYS.Remove_Package('ACCOUNTING_LEDG_FLAG_API', TRUE);
   Database_SYS.Remove_Package('ACCOUNTING_PERIOD_API', TRUE);
   Database_SYS.Remove_Package('ACCOUNTING_YEAR_API', TRUE);
   Database_SYS.Remove_Package('ACCOUNT_API', TRUE);
   Database_SYS.Remove_Package('ACCOUNT_GROUP_API', TRUE);
   Database_SYS.Remove_Package('ACCOUNT_PROCESS_CODE_API', TRUE);
   Database_SYS.Remove_Package('ACCOUNT_REQUEST_API', TRUE);
   Database_SYS.Remove_Package('ACCOUNT_REQUEST_TEXT_API', TRUE);
   Database_SYS.Remove_Package('ACCOUNT_TAX_CODE_API', TRUE);
   Database_SYS.Remove_Package('ACCOUNT_TYPE_API', TRUE);
   Database_SYS.Remove_Package('ACCOUNT_TYPE_VALUE_API', TRUE);
   Database_SYS.Remove_Package('ACCRUL_ATTRIBUTE_API', TRUE);
   Database_SYS.Remove_Package('ACCRUL_FIN_SEL_TEMPL_API', TRUE);
   Database_SYS.Remove_Package('ACCRUL_FIN_SEL_TEMPL_DET_API', TRUE);
   Database_SYS.Remove_Package('ACCRUL_FIN_SEL_TEMPL_VAL_API', TRUE);
   Database_SYS.Remove_Package('ACCRUL_FOOTER_FIELD_API', TRUE);
   Database_SYS.Remove_Package('ACCRUL_LIB_MHS_API', TRUE);
   Database_SYS.Remove_Package('ACCRUL_POSTING_CTRL_API', TRUE);
   Database_SYS.Remove_Package('ACCRUL_POSTING_CTRL_DETAIL_API', TRUE);
   Database_SYS.Remove_Package('ACCRUL_POST_CTRL_CDET_SPEC_API', TRUE);
   Database_SYS.Remove_Package('ACCRUL_POST_CTRL_COMB_DET_API', TRUE);
   Database_SYS.Remove_Package('ACCRUL_POST_CTRL_DET_SPEC_API', TRUE);
   Database_SYS.Remove_Package('ACCRUL_UTILITY_API', TRUE);
   Database_SYS.Remove_Package('ACC_CURRENCY_BALANCE_FLAG_API', TRUE);
   Database_SYS.Remove_Package('ACC_PERIOD_CLOSE_UTIL_API', TRUE);
   Database_SYS.Remove_Package('ACC_PER_STATUS_API', TRUE);
   Database_SYS.Remove_Package('ACC_YEAR_CL_BAL_API', TRUE);
   Database_SYS.Remove_Package('ACC_YEAR_OP_BAL_API', TRUE);
   Database_SYS.Remove_Package('ACC_YEAR_STATUS_API', TRUE);
   Database_SYS.Remove_Package('ALLOWED_ACCOUNTING_PERIODS_API', TRUE);
   Database_SYS.Remove_Package('ARCHIVING_TRANS_VALUE_API', TRUE);
   Database_SYS.Remove_Package('AUDIT_DATE_FORMAT_API', TRUE);
   Database_SYS.Remove_Package('AUDIT_DECIMAL_API', TRUE);
   Database_SYS.Remove_Package('AUDIT_FORMAT_API', TRUE);
   Database_SYS.Remove_Package('AUDIT_NEGATIVE_FMT_API', TRUE);
   Database_SYS.Remove_Package('AUDIT_SOURCE_API', TRUE);
   Database_SYS.Remove_Package('AUDIT_SOURCE_COLUMN_API', TRUE);
   Database_SYS.Remove_Package('AUDIT_SOURCE_TYPE_API', TRUE);
   Database_SYS.Remove_Package('AUDIT_STORAGE_API', TRUE);
   Database_SYS.Remove_Package('AUDIT_THOUSAND_FMT_API', TRUE);
   Database_SYS.Remove_Package('AUDIT_TIME_FORMAT_API', TRUE);
   Database_SYS.Remove_Package('AUDIT_UTIL_API', TRUE);
   Database_SYS.Remove_Package('AUDIT_ZERO_FORMAT_API', TRUE);
   Database_SYS.Remove_Package('AUTHORIZE_LEVEL_API', TRUE);
   Database_SYS.Remove_Package('AUTOMATIC_ALLOTMENT_API', TRUE);
   Database_SYS.Remove_Package('BUDGET_ACCOUNT_FLAG_API', TRUE);
   Database_SYS.Remove_Package('CODESTRING_COMB_API', TRUE);
   Database_SYS.Remove_Package('CODE_B_API', TRUE);
   Database_SYS.Remove_Package('CODE_C_API', TRUE);
   Database_SYS.Remove_Package('CODE_D_API', TRUE);
   Database_SYS.Remove_Package('CODE_E_API', TRUE);
   Database_SYS.Remove_Package('CODE_F_API', TRUE);
   Database_SYS.Remove_Package('CODE_G_API', TRUE);
   Database_SYS.Remove_Package('CODE_H_API', TRUE);
   Database_SYS.Remove_Package('CODE_I_API', TRUE);
   Database_SYS.Remove_Package('CODE_J_API', TRUE);
   Database_SYS.Remove_Package('COMB_CONTROL_ALLOWED_API', TRUE);
   Database_SYS.Remove_Package('COMB_CONTROL_TYPE_API', TRUE);
   Database_SYS.Remove_Package('COMB_RULE_ID_API', TRUE);
   Database_SYS.Remove_Package('COMPANY_FINANCE_API', TRUE);
   Database_SYS.Remove_Package('COMPANY_SECURITY_API', TRUE);
   Database_SYS.Remove_Package('CONSOLIDATED_YES_NO_API', TRUE);
   Database_SYS.Remove_Package('CORRECTED_VOUCHER_API', TRUE);
   Database_SYS.Remove_Package('CORRECTION_TYPE_API', TRUE);
   Database_SYS.Remove_Package('COST_ELEMENT_TO_ACCOUNT_API', TRUE);
   Database_SYS.Remove_Package('COST_ELE_TO_ACCNT_SECMAP_API', TRUE);
   Database_SYS.Remove_Package('CTRL_TYPE_ALLOWED_VALUE_API', TRUE);
   Database_SYS.Remove_Package('CTRL_TYPE_CATEGORY_API', TRUE);
   Database_SYS.Remove_Package('CURRENCY_AMOUNT_API', TRUE);
   Database_SYS.Remove_Package('CURRENCY_AMOUNT_PUB_API', TRUE);
   Database_SYS.Remove_Package('CURRENCY_CODE_API', TRUE);
   Database_SYS.Remove_Package('CURRENCY_RATE_API', TRUE);
   Database_SYS.Remove_Package('CURRENCY_TYPE_API', TRUE);
   Database_SYS.Remove_Package('CURRENCY_TYPE_BASIC_DATA_API', TRUE);
   Database_SYS.Remove_Package('CURRENCY_VALUE_API', TRUE);
   Database_SYS.Remove_Package('CURR_RATE_TYPE_CATEGORY_API', TRUE);
   Database_SYS.Remove_Package('CURR_TYPE_DEF_API', TRUE);
   Database_SYS.Remove_Package('DEFAULT_GROUP_API', TRUE);
   Database_SYS.Remove_Package('DEFAULT_TYPE_API', TRUE);
   Database_SYS.Remove_Package('DEF_AMOUNT_METHOD_API', TRUE);
   Database_SYS.Remove_Package('EXCLUDE_PERIODICAL_CAP_API', TRUE);
   Database_SYS.Remove_Package('EXCLUDE_STAT_ACCOUNT_API', TRUE);
   Database_SYS.Remove_Package('EXTERNAL_FILE_UTILITY_API', TRUE);
   Database_SYS.Remove_Package('EXTY_DATA_TYPE_API', TRUE);
   Database_SYS.Remove_Package('EXT_CHECK_API', TRUE);
   Database_SYS.Remove_Package('EXT_CONDITION_API', TRUE);
   Database_SYS.Remove_Package('EXT_CREATE_API', TRUE);
   Database_SYS.Remove_Package('EXT_CURRENCY_API', TRUE);
   Database_SYS.Remove_Package('EXT_CURRENCY_TASK_API', TRUE);
   Database_SYS.Remove_Package('EXT_CURRENCY_TASK_DETAIL_API', TRUE);
   Database_SYS.Remove_Package('EXT_FILE_ARGUMENT_HANDLER_API', TRUE);
   Database_SYS.Remove_Package('EXT_FILE_BATCH_PARAM_API', TRUE);
   Database_SYS.Remove_Package('EXT_FILE_COLUMN_UTIL_API', TRUE);
   Database_SYS.Remove_Package('EXT_FILE_COMPANY_DEFAULT_API', TRUE);
   Database_SYS.Remove_Package('EXT_FILE_FORMAT_API', TRUE);
   Database_SYS.Remove_Package('EXT_FILE_FUNCTION_API', TRUE);
   Database_SYS.Remove_Package('EXT_FILE_FUNCTION_HANDLER_API', TRUE);
   Database_SYS.Remove_Package('EXT_FILE_IDENTITY_API', TRUE);
   Database_SYS.Remove_Package('EXT_FILE_LOAD_API', TRUE);
   Database_SYS.Remove_Package('EXT_FILE_LOG_API', TRUE);
   Database_SYS.Remove_Package('EXT_FILE_LOG_DETAIL_API', TRUE);
   Database_SYS.Remove_Package('EXT_FILE_MESSAGE_API', TRUE);
   Database_SYS.Remove_Package('EXT_FILE_NAME_OPTION_API', TRUE);
   Database_SYS.Remove_Package('EXT_FILE_ROW_STATE_API', TRUE);
   Database_SYS.Remove_Package('EXT_FILE_SEPARATOR_API', TRUE);
   Database_SYS.Remove_Package('EXT_FILE_SERVER_UTIL_API', TRUE);
   Database_SYS.Remove_Package('EXT_FILE_STATE_API', TRUE);
   Database_SYS.Remove_Package('EXT_FILE_TEMPLATE_API', TRUE);
   Database_SYS.Remove_Package('EXT_FILE_TEMPLATE_CONTROL_API', TRUE);
   Database_SYS.Remove_Package('EXT_FILE_TEMPLATE_DETAIL_API', TRUE);
   Database_SYS.Remove_Package('EXT_FILE_TEMPLATE_DIR_API', TRUE);
   Database_SYS.Remove_Package('EXT_FILE_TEMPL_DET_FUNC_API', TRUE);
   Database_SYS.Remove_Package('EXT_FILE_TRANS_API', TRUE);
   Database_SYS.Remove_Package('EXT_FILE_TYPE_API', TRUE);
   Database_SYS.Remove_Package('EXT_FILE_TYPE_PARAM_API', TRUE);
   Database_SYS.Remove_Package('EXT_FILE_TYPE_REC_API', TRUE);
   Database_SYS.Remove_Package('EXT_FILE_TYPE_REC_COLUMN_API', TRUE);
   Database_SYS.Remove_Package('EXT_FILE_XML_LAYOUT_API', TRUE);
   Database_SYS.Remove_Package('EXT_GROUP_ITEM_API', TRUE);
   Database_SYS.Remove_Package('EXT_LOAD_API', TRUE);
   Database_SYS.Remove_Package('EXT_LOAD_ID_STORAGE_API', TRUE);
   Database_SYS.Remove_Package('EXT_LOAD_INFO_API', TRUE);
   Database_SYS.Remove_Package('EXT_LOAD_STATE_API', TRUE);
   Database_SYS.Remove_Package('EXT_PARAMETERS_API', TRUE);
   Database_SYS.Remove_Package('EXT_TRANSACTIONS_API', TRUE);
   Database_SYS.Remove_Package('EXT_TYPE_PARAM_PER_SET_API', TRUE);
   Database_SYS.Remove_Package('EXT_TYPE_PARAM_SET_API', TRUE);
   Database_SYS.Remove_Package('EXT_VOUCHER_DATE_API', TRUE);
   Database_SYS.Remove_Package('EXT_VOUCHER_DIFF_API', TRUE);
   Database_SYS.Remove_Package('EXT_VOUCHER_NO_ALLOC_API', TRUE);
   Database_SYS.Remove_Package('FEE_TYPE_API', TRUE);
   Database_SYS.Remove_Package('FILE_DIRECTION_API', TRUE);
   Database_SYS.Remove_Package('FINANCE_DOC_REG_API', TRUE);
   Database_SYS.Remove_Package('FINANCE_LIB_API', TRUE);
   Database_SYS.Remove_Package('FINANCE_YES_NO_API', TRUE);
   Database_SYS.Remove_Package('FIN_OBJECT_API', TRUE);
   Database_SYS.Remove_Package('FIN_OBJECT_SELECTION_API', TRUE);
   Database_SYS.Remove_Package('FIN_OBJ_GRP_API', TRUE);
   Database_SYS.Remove_Package('FIN_OBJ_GRP_OBJECT_API', TRUE);
   Database_SYS.Remove_Package('FIN_OBJ_GRP_SEL_OBJECT_API', TRUE);
   Database_SYS.Remove_Package('FIN_OBJ_SELECTION_VALUES_API', TRUE);
   Database_SYS.Remove_Package('FIN_OBJ_TYPE_API', TRUE);
   Database_SYS.Remove_Package('FIN_OWNERSHIP_API', TRUE);
   Database_SYS.Remove_Package('FIN_SELECTION_TEMPL_UTIL_API', TRUE);
   Database_SYS.Remove_Package('FIN_SEL_OBJECT_ALLOW_OPER_API', TRUE);
   Database_SYS.Remove_Package('FIN_SEL_OBJECT_API', TRUE);
   Database_SYS.Remove_Package('FIN_SEL_OBJECT_OPERATOR_API', TRUE);
   Database_SYS.Remove_Package('FIN_SEL_OBJECT_TYPE_API', TRUE);
   Database_SYS.Remove_Package('FIN_SEL_OBJ_TEMPL_API', TRUE);
   Database_SYS.Remove_Package('FIN_SEL_OBJ_TEMPL_DET_API', TRUE);
   Database_SYS.Remove_Package('FIN_SEL_TEMPL_OWNERSHIP_API', TRUE);
   Database_SYS.Remove_Package('FIN_SEL_TEMPL_VALUES_API', TRUE);
   Database_SYS.Remove_Package('FOOTER_CONNECTION_API', TRUE);
   Database_SYS.Remove_Package('FOOTER_CONNECTION_MASTER_API', TRUE);
   Database_SYS.Remove_Package('FOOTER_DEFINITION_API', TRUE);
   Database_SYS.Remove_Package('FOOTER_FIELD_API', TRUE);
   Database_SYS.Remove_Package('FUNCTION_GROUP_API', TRUE);
   Database_SYS.Remove_Package('GROUP_TYPE_API', TRUE);
   Database_SYS.Remove_Package('INTERNAL_POSTINGS_ACCRUL_API', TRUE);
   Database_SYS.Remove_Package('IN_EXT_FILE_TEMPLATE_DIR_API', TRUE);
   Database_SYS.Remove_Package('LABLE_PRINT_API', TRUE);
   Database_SYS.Remove_Package('LEDGER_API', TRUE);
   Database_SYS.Remove_Package('LEVEL_INFO_UTIL_API', TRUE);
   Database_SYS.Remove_Package('LOGICAL_CODE_PART_API', TRUE);
   Database_SYS.Remove_Package('MULTI_COMPANY_VOUCHER_API', TRUE);
   Database_SYS.Remove_Package('MULTI_COMPANY_VOUCHER_ROW_API', TRUE);
   Database_SYS.Remove_Package('MULTI_COMPANY_VOUCHER_UTIL_API', TRUE);
   Database_SYS.Remove_Package('OUT_EXT_FILE_TEMPLATE_DIR_API', TRUE);
   Database_SYS.Remove_Package('PARALLEL_BASE_API', TRUE);
   Database_SYS.Remove_Package('PAYMENT_TERM_API', TRUE);
   Database_SYS.Remove_Package('PAYMENT_TERM_DETAILS_API', TRUE);
   Database_SYS.Remove_Package('PAYMENT_VACATION_PERIOD_API', TRUE);
   Database_SYS.Remove_Package('PERIOD_ALLOCATION_API', TRUE);
   Database_SYS.Remove_Package('PERIOD_ALLOCATION_RULE_API', TRUE);
   Database_SYS.Remove_Package('PERIOD_ALLOC_PER_DISTR_API', TRUE);
   Database_SYS.Remove_Package('PERIOD_ALLOC_RULE_LINE_API', TRUE);
   Database_SYS.Remove_Package('PERIOD_CLOSING_METHOD_API', TRUE);
   Database_SYS.Remove_Package('PERIOD_TYPE_API', TRUE);
   Database_SYS.Remove_Package('POSTING_CTRL_ALLOWED_COMB_API', TRUE);
   Database_SYS.Remove_Package('POSTING_CTRL_ALL_CODEPART_API', TRUE);
   Database_SYS.Remove_Package('POSTING_CTRL_API', TRUE);
   Database_SYS.Remove_Package('POSTING_CTRL_COMB_DETAIL_API', TRUE);
   Database_SYS.Remove_Package('POSTING_CTRL_COMB_DET_SPEC_API', TRUE);
   Database_SYS.Remove_Package('POSTING_CTRL_COMP_CODE_STR_API', TRUE);
   Database_SYS.Remove_Package('POSTING_CTRL_CONTROL_TYPE_API', TRUE);
   Database_SYS.Remove_Package('POSTING_CTRL_CRECOMP_API', TRUE);
   Database_SYS.Remove_Package('POSTING_CTRL_DETAIL_API', TRUE);
   Database_SYS.Remove_Package('POSTING_CTRL_DETAIL_RPI', TRUE);
   Database_SYS.Remove_Package('POSTING_CTRL_DETAIL_SPEC_API', TRUE);
   Database_SYS.Remove_Package('POSTING_CTRL_LEDGER_FLAG_API', TRUE);
   Database_SYS.Remove_Package('POSTING_CTRL_POSTING_TYPE_API', TRUE);
   Database_SYS.Remove_Package('POSTING_CTRL_PUBLIC_API', TRUE);
   Database_SYS.Remove_Package('POSTING_CTRL_STR_CODE_API', TRUE);
   Database_SYS.Remove_Package('POSTING_CTRL_TAX_FLAG_API', TRUE);
   Database_SYS.Remove_Package('PRJ_FOLLOWUP_ELEMENT_TYPE_API', TRUE);
   Database_SYS.Remove_Package('PROJECT_COST_ELEMENT_API', TRUE);
   Database_SYS.Remove_Package('PSEUDO_CODES_API', TRUE);
   Database_SYS.Remove_Package('PSEUDO_CODE_VALUE_API', TRUE);
   Database_SYS.Remove_Package('RPD_COMPANY_API', TRUE);
   Database_SYS.Remove_Package('RPD_COMPANY_PERIOD_API', TRUE);
   Database_SYS.Remove_Package('RPD_COMPANY_PERIOD_DET_API', TRUE);
   Database_SYS.Remove_Package('RPD_IDENTITY_API', TRUE);
   Database_SYS.Remove_Package('RPD_PERIOD_API', TRUE);
   Database_SYS.Remove_Package('RPD_PERIOD_DETAIL_API', TRUE);
   Database_SYS.Remove_Package('RPD_YEAR_API', TRUE);
   Database_SYS.Remove_Package('SELECTION_TYPE_API', TRUE);
   Database_SYS.Remove_Package('STATUTORY_FEE_API', TRUE);
   Database_SYS.Remove_Package('STATUTORY_FEE_DETAIL_API', TRUE);
   Database_SYS.Remove_Package('STORE_ORIGINAL_YES_NO_API', TRUE);
   Database_SYS.Remove_Package('SYSTEM_FOOTER_FIELD_API', TRUE);
   Database_SYS.Remove_Package('TAX_ACCOUNT_FLAG_API', TRUE);
   Database_SYS.Remove_Package('TAX_AMOUNT_AT_INV_PRINT_API', TRUE);
   Database_SYS.Remove_Package('TAX_BOOK_API', TRUE);
   Database_SYS.Remove_Package('TAX_BOOK_STRUCTURE_API', TRUE);
   Database_SYS.Remove_Package('TAX_BOOK_STRUCTURE_ITEM_API', TRUE);
   Database_SYS.Remove_Package('TAX_BOOK_STRUCTURE_LEVEL_API', TRUE);
   Database_SYS.Remove_Package('TAX_BOOK_STRUC_ITEM_TYPE_API', TRUE);
   Database_SYS.Remove_Package('TAX_CLASS_API', TRUE);
   Database_SYS.Remove_Package('TAX_CODES_PER_TAX_CLASS_API', TRUE);
   Database_SYS.Remove_Package('TAX_CODE_API', TRUE);
   Database_SYS.Remove_Package('TAX_CODE_PER_TAX_BOOK_API', TRUE);
   Database_SYS.Remove_Package('TAX_CODE_TEXTS_API', TRUE);
   Database_SYS.Remove_Package('TAX_DIRECTION_API', TRUE);
   Database_SYS.Remove_Package('TAX_DIRECTION_SP_API', TRUE);
   Database_SYS.Remove_Package('TAX_HANDLING_VALUE_API', TRUE);
   Database_SYS.Remove_Package('TAX_LIABILITY_DATE_API', TRUE);
   Database_SYS.Remove_Package('TAX_LIABILITY_DATE_CTRL_API', TRUE);
   Database_SYS.Remove_Package('TAX_LIABLTY_DATE_EXCEPTION_API', TRUE);
   Database_SYS.Remove_Package('TAX_REPORTING_CATEGORY_API', TRUE);
   Database_SYS.Remove_Package('TAX_ROUNDING_LEVEL_API', TRUE);
   Database_SYS.Remove_Package('TAX_ROUNDING_METHOD_API', TRUE);
   Database_SYS.Remove_Package('TEXT_FIELD_TRANSLATION_API', TRUE);
   Database_SYS.Remove_Package('TEXT_TYPE_API', TRUE);
   Database_SYS.Remove_Package('TRANSFERRED_VOUCHER_API', TRUE);
   Database_SYS.Remove_Package('TRANSFERRED_VOUCHER_ROW_API', TRUE);
   Database_SYS.Remove_Package('USER_FINANCE_API', TRUE);
   Database_SYS.Remove_Package('USER_GROUP_FINANCE_API', TRUE);
   Database_SYS.Remove_Package('USER_GROUP_MEMBER_FINANCE_API', TRUE);
   Database_SYS.Remove_Package('USER_GROUP_PERIOD_API', TRUE);
   Database_SYS.Remove_Package('VALIDATE_CODE_STRING_API', TRUE);
   Database_SYS.Remove_Package('VAT_DISTRIBUTION_API', TRUE);
   Database_SYS.Remove_Package('VAT_METHOD_API', TRUE);
   Database_SYS.Remove_Package('VERTEX_UTILITY_API', TRUE);
   Database_SYS.Remove_Package('VOUCHER_API', TRUE);
   Database_SYS.Remove_Package('VOUCHER_CORRECTION_API', TRUE);
   Database_SYS.Remove_Package('VOUCHER_INTERIM_API', TRUE);
   Database_SYS.Remove_Package('VOUCHER_NOTE_API', TRUE);
   Database_SYS.Remove_Package('VOUCHER_NO_SERIAL_API', TRUE);
   Database_SYS.Remove_Package('VOUCHER_ROW_API', TRUE);
   Database_SYS.Remove_Package('VOUCHER_STATUS_API', TRUE);
   Database_SYS.Remove_Package('VOUCHER_TEMPLATE_API', TRUE);
   Database_SYS.Remove_Package('VOUCHER_TEMPLATE_ROW_API', TRUE);
   Database_SYS.Remove_Package('VOUCHER_TEXT_API', TRUE);
   Database_SYS.Remove_Package('VOUCHER_TRANSFER_HIST_API', TRUE);
   Database_SYS.Remove_Package('VOUCHER_TYPE_API', TRUE);
   Database_SYS.Remove_Package('VOUCHER_TYPE_DETAIL_API', TRUE);
   Database_SYS.Remove_Package('VOUCHER_TYPE_USER_GROUP_API', TRUE);
   Database_SYS.Remove_Package('VOUCHER_UPDATED_API', TRUE);
   Database_SYS.Remove_Package('VOUCHER_UTIL_PUB_API', TRUE);
END;
/

----------------------------------------------------------------
-- Drop views
----------------------------------------------------------------

BEGIN
   dbms_output.put_line('Removing Views for the Module...');
   Database_SYS.Remove_View('ACCOUNT', TRUE);
   Database_SYS.Remove_View('ACCOUNTING_ATTRIBUTE', TRUE);
   Database_SYS.Remove_View('ACCOUNTING_ATTRIBUTE_ALL_AV', TRUE);
   Database_SYS.Remove_View('ACCOUNTING_ATTRIBUTE_CON', TRUE);
   Database_SYS.Remove_View('ACCOUNTING_ATTRIBUTE_CON2', TRUE);
   Database_SYS.Remove_View('ACCOUNTING_ATTRIBUTE_VALUE', TRUE);
   Database_SYS.Remove_View('ACCOUNTING_CODEPART_A', TRUE);
   Database_SYS.Remove_View('ACCOUNTING_CODEPART_B', TRUE);
   Database_SYS.Remove_View('ACCOUNTING_CODEPART_C', TRUE);
   Database_SYS.Remove_View('ACCOUNTING_CODEPART_D', TRUE);
   Database_SYS.Remove_View('ACCOUNTING_CODEPART_E', TRUE);
   Database_SYS.Remove_View('ACCOUNTING_CODEPART_F', TRUE);
   Database_SYS.Remove_View('ACCOUNTING_CODEPART_G', TRUE);
   Database_SYS.Remove_View('ACCOUNTING_CODEPART_H', TRUE);
   Database_SYS.Remove_View('ACCOUNTING_CODEPART_I', TRUE);
   Database_SYS.Remove_View('ACCOUNTING_CODEPART_J', TRUE);
   Database_SYS.Remove_View('ACCOUNTING_CODEPART_VAL_FINREP', TRUE);
   Database_SYS.Remove_View('ACCOUNTING_CODESTR_COMB', TRUE);
   Database_SYS.Remove_View('ACCOUNTING_CODESTR_COMB_UIV', TRUE);
   Database_SYS.Remove_View('ACCOUNTING_CODESTR_COMPL', TRUE);
   Database_SYS.Remove_View('ACCOUNTING_CODE_PARTS', TRUE);
   Database_SYS.Remove_View('ACCOUNTING_CODE_PARTS_AV', TRUE);
   Database_SYS.Remove_View('ACCOUNTING_CODE_PARTS_PUBLIC', TRUE);
   Database_SYS.Remove_View('ACCOUNTING_CODE_PARTS_USED2', TRUE);
   Database_SYS.Remove_View('ACCOUNTING_CODE_PART_A', TRUE);
   Database_SYS.Remove_View('ACCOUNTING_CODE_PART_A1', TRUE);
   Database_SYS.Remove_View('ACCOUNTING_CODE_PART_VALUE', TRUE);
   Database_SYS.Remove_View('ACCOUNTING_CODE_PART_VALUE_AV', TRUE);
   Database_SYS.Remove_View('ACCOUNTING_CODE_PART_VALUE_LOV', TRUE);
   Database_SYS.Remove_View('ACCOUNTING_CODE_PART_VALUE_PUB', TRUE);
   Database_SYS.Remove_View('ACCOUNTING_CODE_PART_VAL_PUB', TRUE);
   Database_SYS.Remove_View('ACCOUNTING_PERIOD', TRUE);
   Database_SYS.Remove_View('ACCOUNTING_PERIOD_LOV', TRUE);
   Database_SYS.Remove_View('ACCOUNTING_PERIOD_TEMP', TRUE);
   Database_SYS.Remove_View('ACCOUNTING_YEAR', TRUE);
   Database_SYS.Remove_View('ACCOUNTING_YEAR_END_PERIOD', TRUE);
   Database_SYS.Remove_View('ACCOUNTING_YEAR_FULL_LOV', TRUE);
   Database_SYS.Remove_View('ACCOUNTING_YEAR_LOV', TRUE);
   Database_SYS.Remove_View('ACCOUNTING_YEAR_PERIOD', TRUE);
   Database_SYS.Remove_View('ACCOUNTS_CONSOLIDATION', TRUE);
   Database_SYS.Remove_View('ACCOUNT_AV', TRUE);
   Database_SYS.Remove_View('ACCOUNT_CODE_A', TRUE);
   Database_SYS.Remove_View('ACCOUNT_CODE_A1', TRUE);
   Database_SYS.Remove_View('ACCOUNT_GROUP', TRUE);
   Database_SYS.Remove_View('ACCOUNT_GROUP_AV', TRUE);
   Database_SYS.Remove_View('ACCOUNT_GROUP_PUB', TRUE);
   Database_SYS.Remove_View('ACCOUNT_LOV', TRUE);
   Database_SYS.Remove_View('ACCOUNT_MATCHING_CODE_A', TRUE);
   Database_SYS.Remove_View('ACCOUNT_PROCESS_CODE', TRUE);
   Database_SYS.Remove_View('ACCOUNT_TAX_CODE', TRUE);
   Database_SYS.Remove_View('ACCOUNT_TYPE', TRUE);
   Database_SYS.Remove_View('ACCOUNT_TYPE_PUB', TRUE);
   Database_SYS.Remove_View('ACCRUED_COST_REVENUE', TRUE);
   Database_SYS.Remove_View('ACCRUL_ATTRIBUTE', TRUE);
   Database_SYS.Remove_View('ACCRUL_SESSION_PID', TRUE);
   Database_SYS.Remove_View('ACCRUL_VOUCHER_ROW_QRY', TRUE);
   Database_SYS.Remove_View('ACC_CODE_PARTS_GROCON_LOV', TRUE);
   Database_SYS.Remove_View('ACC_PER_EXT_TRANS_TYPE_LOBBY', TRUE);
   Database_SYS.Remove_View('ACC_YEAR', TRUE);
   Database_SYS.Remove_View('ACC_YEAR_PERIOD_PUB', TRUE);
   Database_SYS.Remove_View('ACC_YEAR_PERIOD_SUMMARY_PUB', TRUE);
   Database_SYS.Remove_View('ALLOWED_CONTROL_TYPE', TRUE);
   Database_SYS.Remove_View('ALLOWED_PERIODS_PUB', TRUE);
   Database_SYS.Remove_View('ALL_CURRENCY_RATES_WEB', TRUE);
   Database_SYS.Remove_View('AUDIT_FORMAT', TRUE);
   Database_SYS.Remove_View('AUDIT_SOURCE', TRUE);
   Database_SYS.Remove_View('AUDIT_SOURCE_COLUMN', TRUE);
   Database_SYS.Remove_View('AUDIT_STORAGE', TRUE);
   Database_SYS.Remove_View('BUDGET_ACC_CODE_PART_VALUE', TRUE);
   Database_SYS.Remove_View('CODESTRING_COMB', TRUE);
   Database_SYS.Remove_View('CODESTRING_COMBINATION', TRUE);
   Database_SYS.Remove_View('CODE_B', TRUE);
   Database_SYS.Remove_View('CODE_B_ALL', TRUE);
   Database_SYS.Remove_View('CODE_C', TRUE);
   Database_SYS.Remove_View('CODE_C_ALL', TRUE);
   Database_SYS.Remove_View('CODE_D', TRUE);
   Database_SYS.Remove_View('CODE_D_ALL', TRUE);
   Database_SYS.Remove_View('CODE_E', TRUE);
   Database_SYS.Remove_View('CODE_E_ALL', TRUE);
   Database_SYS.Remove_View('CODE_F', TRUE);
   Database_SYS.Remove_View('CODE_F_ALL', TRUE);
   Database_SYS.Remove_View('CODE_G', TRUE);
   Database_SYS.Remove_View('CODE_G_ALL', TRUE);
   Database_SYS.Remove_View('CODE_H', TRUE);
   Database_SYS.Remove_View('CODE_H_ALL', TRUE);
   Database_SYS.Remove_View('CODE_I', TRUE);
   Database_SYS.Remove_View('CODE_I_ALL', TRUE);
   Database_SYS.Remove_View('CODE_J', TRUE);
   Database_SYS.Remove_View('CODE_J_ALL', TRUE);
   Database_SYS.Remove_View('CODE_PARTS_FOR_CONSOLIDATION', TRUE);
   Database_SYS.Remove_View('CODE_PARTS_USED_PUB', TRUE);
   Database_SYS.Remove_View('CODE_PART_VALUE_FOR_CONS', TRUE);
   Database_SYS.Remove_View('COMB_CONTROL_TYPE', TRUE);
   Database_SYS.Remove_View('COMB_CONTROL_TYPE_VALUE', TRUE);
   Database_SYS.Remove_View('COMB_RULE_ID', TRUE);
   Database_SYS.Remove_View('COMPANY_FINANCE', TRUE);
   Database_SYS.Remove_View('COMPANY_FINANCE1', TRUE);
   Database_SYS.Remove_View('COMPANY_FINANCE_ADM', TRUE);
   Database_SYS.Remove_View('COMPANY_FINANCE_AUTH', TRUE);
   Database_SYS.Remove_View('COMPANY_FINANCE_AUTH1', TRUE);
   Database_SYS.Remove_View('COMPANY_FINANCE_AUTH_PUB', TRUE);
   Database_SYS.Remove_View('COMPANY_SECURITY_BASIC', TRUE);
   Database_SYS.Remove_View('COMPANY_SECURITY_EXTENDED', TRUE);
   Database_SYS.Remove_View('CONSOLIDATION_ACCOUNT', TRUE);
   Database_SYS.Remove_View('COST_CENTERS_PUB', TRUE);
   Database_SYS.Remove_View('COST_ELEMENT_TO_ACCOUNT', TRUE);
   Database_SYS.Remove_View('COST_ELEMENT_TO_ACCOUNT_ALL', TRUE);
   Database_SYS.Remove_View('COST_ELE_TO_ACCNT_SECMAP', TRUE);
   Database_SYS.Remove_View('CTRL_TYPE_ALLOWED_VALUE', TRUE);
   Database_SYS.Remove_View('CURRENCY_CODE', TRUE);
   Database_SYS.Remove_View('CURRENCY_RATE', TRUE);
   Database_SYS.Remove_View('CURRENCY_RATE1', TRUE);
   Database_SYS.Remove_View('CURRENCY_RATE2', TRUE);
   Database_SYS.Remove_View('CURRENCY_RATES_PER_RATE_TYPE', TRUE);
   Database_SYS.Remove_View('CURRENCY_RATE_MV_HLP', TRUE);
   Database_SYS.Remove_View('CURRENCY_TYPE', TRUE);
   Database_SYS.Remove_View('CURRENCY_TYPE1', TRUE);
   Database_SYS.Remove_View('CURRENCY_TYPE2', TRUE);
   Database_SYS.Remove_View('CURRENCY_TYPE3', TRUE);
   Database_SYS.Remove_View('CURRENCY_TYPE_BASIC_DATA', TRUE);
   Database_SYS.Remove_View('CUST_CHECK_VOU_TYPE', TRUE);
   Database_SYS.Remove_View('DIM_ACCOUNTING_PERIOD_DM', TRUE);
   Database_SYS.Remove_View('DIM_ACCOUNTING_PERIOD_LOV_DM', TRUE);
   Database_SYS.Remove_View('DIM_ACCOUNTING_PERIOD_LOV_OL', TRUE);
   Database_SYS.Remove_View('DIM_ACCOUNTING_PERIOD_OL', TRUE);
   Database_SYS.Remove_View('DIM_ACCOUNTING_PROCESS_CODE_DM', TRUE);
   Database_SYS.Remove_View('DIM_ACCOUNTING_PROCESS_CODE_OL', TRUE);
   Database_SYS.Remove_View('DIM_ACCOUNTING_YEAR_LOV_DM', TRUE);
   Database_SYS.Remove_View('DIM_ACCOUNTING_YEAR_LOV_OL', TRUE);
   Database_SYS.Remove_View('DIM_ACCOUNT_DM', TRUE);
   Database_SYS.Remove_View('DIM_ACCOUNT_OL', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR2_ACCOUNT_DM', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR2_ACCOUNT_OL', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR2_CODE_B_DM', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR2_CODE_B_OL', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR2_CODE_C_DM', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR2_CODE_C_OL', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR2_CODE_D_DM', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR2_CODE_D_OL', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR2_CODE_E_DM', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR2_CODE_E_OL', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR2_CODE_F_DM', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR2_CODE_F_OL', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR2_CODE_G_DM', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR2_CODE_G_OL', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR2_CODE_H_DM', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR2_CODE_H_OL', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR2_CODE_I_DM', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR2_CODE_I_OL', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR2_CODE_J_DM', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR2_CODE_J_OL', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR3_ACCOUNT_DM', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR3_ACCOUNT_OL', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR3_CODE_B_DM', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR3_CODE_B_OL', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR3_CODE_C_DM', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR3_CODE_C_OL', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR3_CODE_D_DM', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR3_CODE_D_OL', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR3_CODE_E_DM', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR3_CODE_E_OL', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR3_CODE_F_DM', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR3_CODE_F_OL', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR3_CODE_G_DM', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR3_CODE_G_OL', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR3_CODE_H_DM', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR3_CODE_H_OL', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR3_CODE_I_DM', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR3_CODE_I_OL', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR3_CODE_J_DM', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR3_CODE_J_OL', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR4_ACCOUNT_DM', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR4_ACCOUNT_OL', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR4_CODE_B_DM', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR4_CODE_B_OL', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR4_CODE_C_DM', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR4_CODE_C_OL', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR4_CODE_D_DM', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR4_CODE_D_OL', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR4_CODE_E_DM', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR4_CODE_E_OL', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR4_CODE_F_DM', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR4_CODE_F_OL', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR4_CODE_G_DM', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR4_CODE_G_OL', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR4_CODE_H_DM', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR4_CODE_H_OL', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR4_CODE_I_DM', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR4_CODE_I_OL', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR4_CODE_J_DM', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR4_CODE_J_OL', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR5_ACCOUNT_DM', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR5_ACCOUNT_OL', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR5_CODE_B_DM', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR5_CODE_B_OL', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR5_CODE_C_DM', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR5_CODE_C_OL', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR5_CODE_D_DM', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR5_CODE_D_OL', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR5_CODE_E_DM', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR5_CODE_E_OL', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR5_CODE_F_DM', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR5_CODE_F_OL', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR5_CODE_G_DM', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR5_CODE_G_OL', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR5_CODE_H_DM', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR5_CODE_H_OL', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR5_CODE_I_DM', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR5_CODE_I_OL', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR5_CODE_J_DM', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR5_CODE_J_OL', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR_ACCOUNT_DM', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR_ACCOUNT_OL', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR_CODE_B_DM', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR_CODE_B_OL', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR_CODE_C_DM', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR_CODE_C_OL', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR_CODE_D_DM', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR_CODE_D_OL', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR_CODE_E_DM', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR_CODE_E_OL', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR_CODE_F_DM', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR_CODE_F_OL', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR_CODE_G_DM', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR_CODE_G_OL', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR_CODE_H_DM', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR_CODE_H_OL', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR_CODE_I_DM', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR_CODE_I_OL', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR_CODE_J_DM', TRUE);
   Database_SYS.Remove_View('DIM_ANALYTIC_ATTR_CODE_J_OL', TRUE);
   Database_SYS.Remove_View('DIM_CODE_B_DM', TRUE);
   Database_SYS.Remove_View('DIM_CODE_B_OL', TRUE);
   Database_SYS.Remove_View('DIM_CODE_C_DM', TRUE);
   Database_SYS.Remove_View('DIM_CODE_C_OL', TRUE);
   Database_SYS.Remove_View('DIM_CODE_D_DM', TRUE);
   Database_SYS.Remove_View('DIM_CODE_D_OL', TRUE);
   Database_SYS.Remove_View('DIM_CODE_E_DM', TRUE);
   Database_SYS.Remove_View('DIM_CODE_E_OL', TRUE);
   Database_SYS.Remove_View('DIM_CODE_F_DM', TRUE);
   Database_SYS.Remove_View('DIM_CODE_F_OL', TRUE);
   Database_SYS.Remove_View('DIM_CODE_G_DM', TRUE);
   Database_SYS.Remove_View('DIM_CODE_G_OL', TRUE);
   Database_SYS.Remove_View('DIM_CODE_H_DM', TRUE);
   Database_SYS.Remove_View('DIM_CODE_H_OL', TRUE);
   Database_SYS.Remove_View('DIM_CODE_I_DM', TRUE);
   Database_SYS.Remove_View('DIM_CODE_I_OL', TRUE);
   Database_SYS.Remove_View('DIM_CODE_J_DM', TRUE);
   Database_SYS.Remove_View('DIM_CODE_J_OL', TRUE);
   Database_SYS.Remove_View('DIM_COMPANY_DM', TRUE);
   Database_SYS.Remove_View('DIM_COMPANY_OL', TRUE);
   Database_SYS.Remove_View('DIM_CURRENCY_CODE_DM', TRUE);
   Database_SYS.Remove_View('DIM_CURRENCY_CODE_OL', TRUE);
   Database_SYS.Remove_View('DIM_CURRENCY_RATE_TYPE_DM', TRUE);
   Database_SYS.Remove_View('DIM_CURRENCY_RATE_TYPE_OL', TRUE);
   Database_SYS.Remove_View('DIM_RPD_COMPANY_PERIOD_DM', TRUE);
   Database_SYS.Remove_View('DIM_RPD_COMPANY_PERIOD_OL', TRUE);
   Database_SYS.Remove_View('DIM_RPD_PERIOD_DM', TRUE);
   Database_SYS.Remove_View('DIM_RPD_PERIOD_OL', TRUE);
   Database_SYS.Remove_View('DIM_SUBSIDIARY_COMPANY_DM', TRUE);
   Database_SYS.Remove_View('DIM_SUBSIDIARY_COMPANY_OL', TRUE);
   Database_SYS.Remove_View('DIM_TAXCODE_DM', TRUE);
   Database_SYS.Remove_View('DIM_TAXCODE_OL', TRUE);
   Database_SYS.Remove_View('DIM_TAX_BOOK_DM', TRUE);
   Database_SYS.Remove_View('DIM_TAX_BOOK_OL', TRUE);
   Database_SYS.Remove_View('DIM_VOUCHER_TYPE_DM', TRUE);
   Database_SYS.Remove_View('DIM_VOUCHER_TYPE_OL', TRUE);
   Database_SYS.Remove_View('EXT_CURRENCY_TASK', TRUE);
   Database_SYS.Remove_View('EXT_CURRENCY_TASK_DETAIL', TRUE);
   Database_SYS.Remove_View('EXT_CURRENCY_TASK_LOV', TRUE);
   Database_SYS.Remove_View('EXT_FILE_BATCH_JOBS', TRUE);
   Database_SYS.Remove_View('EXT_FILE_BATCH_PARAM', TRUE);
   Database_SYS.Remove_View('EXT_FILE_COMPANY_DEFAULT', TRUE);
   Database_SYS.Remove_View('EXT_FILE_FUNCTION', TRUE);
   Database_SYS.Remove_View('EXT_FILE_IDENTITY', TRUE);
   Database_SYS.Remove_View('EXT_FILE_LOAD', TRUE);
   Database_SYS.Remove_View('EXT_FILE_LOG', TRUE);
   Database_SYS.Remove_View('EXT_FILE_LOG_DETAIL', TRUE);
   Database_SYS.Remove_View('EXT_FILE_MODULE_NAME', TRUE);
   Database_SYS.Remove_View('EXT_FILE_SEPARATOR', TRUE);
   Database_SYS.Remove_View('EXT_FILE_TEMPLATE', TRUE);
   Database_SYS.Remove_View('EXT_FILE_TEMPLATE_CONTROL', TRUE);
   Database_SYS.Remove_View('EXT_FILE_TEMPLATE_DETAIL', TRUE);
   Database_SYS.Remove_View('EXT_FILE_TEMPLATE_DETAIL_DEST', TRUE);
   Database_SYS.Remove_View('EXT_FILE_TEMPLATE_DETAIL_REC', TRUE);
   Database_SYS.Remove_View('EXT_FILE_TEMPLATE_DIR', TRUE);
   Database_SYS.Remove_View('EXT_FILE_TEMPLATE_LOV', TRUE);
   Database_SYS.Remove_View('EXT_FILE_TEMPLATE_LOV2', TRUE);
   Database_SYS.Remove_View('EXT_FILE_TEMPLATE_LOV_CUPAY', TRUE);
   Database_SYS.Remove_View('EXT_FILE_TEMPL_COLUMN', TRUE);
   Database_SYS.Remove_View('EXT_FILE_TEMPL_DET_FUNC', TRUE);
   Database_SYS.Remove_View('EXT_FILE_TEMPL_REC_TYPE', TRUE);
   Database_SYS.Remove_View('EXT_FILE_TRANS', TRUE);
   Database_SYS.Remove_View('EXT_FILE_TRANS_DETAIL', TRUE);
   Database_SYS.Remove_View('EXT_FILE_TRANS_END', TRUE);
   Database_SYS.Remove_View('EXT_FILE_TRANS_HEAD', TRUE);
   Database_SYS.Remove_View('EXT_FILE_TRANS_TAXNO', TRUE);
   Database_SYS.Remove_View('EXT_FILE_TYPE', TRUE);
   Database_SYS.Remove_View('EXT_FILE_TYPE_PARAM', TRUE);
   Database_SYS.Remove_View('EXT_FILE_TYPE_PARAM_DIALOG', TRUE);
   Database_SYS.Remove_View('EXT_FILE_TYPE_REC', TRUE);
   Database_SYS.Remove_View('EXT_FILE_TYPE_REC_COLUMN', TRUE);
   Database_SYS.Remove_View('EXT_FILE_TYPE_USABLE', TRUE);
   Database_SYS.Remove_View('EXT_FILE_VIEW_LOV', TRUE);
   Database_SYS.Remove_View('EXT_FILE_VIEW_NAME', TRUE);
   Database_SYS.Remove_View('EXT_FILE_XML_LAYOUT', TRUE);
   Database_SYS.Remove_View('EXT_FILE_XML_LAYOUT_P', TRUE);
   Database_SYS.Remove_View('EXT_LOAD_ID_STORAGE', TRUE);
   Database_SYS.Remove_View('EXT_LOAD_INFO', TRUE);
   Database_SYS.Remove_View('EXT_PARAMETERS', TRUE);
   Database_SYS.Remove_View('EXT_PARAMETERS_LOV', TRUE);
   Database_SYS.Remove_View('EXT_TRANSACTIONS', TRUE);
   Database_SYS.Remove_View('EXT_TRANSACTIONS_NEW', TRUE);
   Database_SYS.Remove_View('EXT_TYPE_PARAM_PER_SET', TRUE);
   Database_SYS.Remove_View('EXT_TYPE_PARAM_PER_SET2', TRUE);
   Database_SYS.Remove_View('EXT_TYPE_PARAM_SET', TRUE);
   Database_SYS.Remove_View('FACT_CURRENCY_RATES_DM', TRUE);
   Database_SYS.Remove_View('FACT_CURRENCY_RATES_DM_OPT', TRUE);
   Database_SYS.Remove_View('FACT_CURRENCY_RATES_OL', TRUE);
   Database_SYS.Remove_View('FACT_CURRENCY_RATES_OL_OPT', TRUE);
   Database_SYS.Remove_View('FINANCE_DOC_REG', TRUE);
   Database_SYS.Remove_View('FIN_OBJECT', TRUE);
   Database_SYS.Remove_View('FIN_OBJECT_SELECTION', TRUE);
   Database_SYS.Remove_View('FIN_OBJ_GRP', TRUE);
   Database_SYS.Remove_View('FIN_OBJ_GRP_OBJECT', TRUE);
   Database_SYS.Remove_View('FIN_OBJ_GRP_SEL_OBJECT', TRUE);
   Database_SYS.Remove_View('FIN_OBJ_SELECTION_VALUES', TRUE);
   Database_SYS.Remove_View('FIN_SEL_OBJECT', TRUE);
   Database_SYS.Remove_View('FIN_SEL_OBJECT_ALLOW_OPER', TRUE);
   Database_SYS.Remove_View('FIN_SEL_OBJECT_COMPANY', TRUE);
   Database_SYS.Remove_View('FIN_SEL_OBJ_TEMPL', TRUE);
   Database_SYS.Remove_View('FIN_SEL_OBJ_TEMPL_DET', TRUE);
   Database_SYS.Remove_View('FIN_SEL_OBJ_TEMPL_DET_GEN_PCT', TRUE);
   Database_SYS.Remove_View('FIN_SEL_OBJ_TEMPL_GEN_PCT', TRUE);
   Database_SYS.Remove_View('FIN_SEL_TEMPL_VALUES', TRUE);
   Database_SYS.Remove_View('FIN_SEL_TEMPL_VAL_GEN_PCT', TRUE);
   Database_SYS.Remove_View('FOOTER_CONNECTION', TRUE);
   Database_SYS.Remove_View('FOOTER_CONNECTION_GEN_PCT', TRUE);
   Database_SYS.Remove_View('FOOTER_CONNECTION_MASTER', TRUE);
   Database_SYS.Remove_View('FOOTER_CONNECTION_MASTER_LOV', TRUE);
   Database_SYS.Remove_View('FOOTER_DEFINITION', TRUE);
   Database_SYS.Remove_View('FOOTER_FIELD', TRUE);
   Database_SYS.Remove_View('FOOTER_FIELD_GEN_PCT', TRUE);
   Database_SYS.Remove_View('FOOTER_WITHOUT_SITE_LOV', TRUE);
   Database_SYS.Remove_View('FUNCTION_GROUP', TRUE);
   Database_SYS.Remove_View('FUNCTION_GROUP_INT', TRUE);
   Database_SYS.Remove_View('INTERNAL_POSTINGS_ACCRUL', TRUE);
   Database_SYS.Remove_View('IN_EXT_FILE_TEMPLATE_DIR', TRUE);
   Database_SYS.Remove_View('IN_EXT_FILE_TEMPLATE_DIR_LOV', TRUE);
   Database_SYS.Remove_View('LATEST_CURRENCY_RATES', TRUE);
   Database_SYS.Remove_View('MC_ACCOUNTING_CODEPART_A', TRUE);
   Database_SYS.Remove_View('MC_ACCOUNTING_CODEPART_B', TRUE);
   Database_SYS.Remove_View('MC_ACCOUNTING_CODEPART_C', TRUE);
   Database_SYS.Remove_View('MC_ACCOUNTING_CODEPART_D', TRUE);
   Database_SYS.Remove_View('MC_ACCOUNTING_CODEPART_E', TRUE);
   Database_SYS.Remove_View('MC_ACCOUNTING_CODEPART_F', TRUE);
   Database_SYS.Remove_View('MC_ACCOUNTING_CODEPART_G', TRUE);
   Database_SYS.Remove_View('MC_ACCOUNTING_CODEPART_H', TRUE);
   Database_SYS.Remove_View('MC_ACCOUNTING_CODEPART_I', TRUE);
   Database_SYS.Remove_View('MC_ACCOUNTING_CODEPART_J', TRUE);
   Database_SYS.Remove_View('MULTI_COMPANY_VOUCHER', TRUE);
   Database_SYS.Remove_View('MULTI_COMPANY_VOUCHER2', TRUE);
   Database_SYS.Remove_View('MULTI_COMPANY_VOUCHER_ROW', TRUE);
   Database_SYS.Remove_View('MULTI_COMPANY_VOUCHER_ROW2', TRUE);
   Database_SYS.Remove_View('OUT_EXT_FILE_TEMPLATE_DIR', TRUE);
   Database_SYS.Remove_View('PAYMENT_TERM', TRUE);
   Database_SYS.Remove_View('PAYMENT_TERM_AFP_VALID_PUB', TRUE);
   Database_SYS.Remove_View('PAYMENT_TERM_DETAILS', TRUE);
   Database_SYS.Remove_View('PAYMENT_TERM_PUB', TRUE);
   Database_SYS.Remove_View('PAYMENT_VACATION_PERIOD', TRUE);
   Database_SYS.Remove_View('PERIOD_ALLOCATION', TRUE);
   Database_SYS.Remove_View('PERIOD_ALLOCATION_RULE', TRUE);
   Database_SYS.Remove_View('PERIOD_ALLOC_RULE_LINE', TRUE);
   Database_SYS.Remove_View('POSTING_CTRL', TRUE);
   Database_SYS.Remove_View('POSTING_CTRL_ALLOWED_COMB', TRUE);
   Database_SYS.Remove_View('POSTING_CTRL_ALLOWED_VALUE', TRUE);
   Database_SYS.Remove_View('POSTING_CTRL_ALWD_COMBINATION', TRUE);
   Database_SYS.Remove_View('POSTING_CTRL_AV', TRUE);
   Database_SYS.Remove_View('POSTING_CTRL_CDET_SPEC_GEN_PCT', TRUE);
   Database_SYS.Remove_View('POSTING_CTRL_COMB_DETAIL', TRUE);
   Database_SYS.Remove_View('POSTING_CTRL_COMB_DETAIL_AV', TRUE);
   Database_SYS.Remove_View('POSTING_CTRL_COMB_DETAIL_PUB', TRUE);
   Database_SYS.Remove_View('POSTING_CTRL_COMB_DET_GEN_PCT', TRUE);
   Database_SYS.Remove_View('POSTING_CTRL_COMB_DET_SPEC', TRUE);
   Database_SYS.Remove_View('POSTING_CTRL_COMB_DET_SPEC_PUB', TRUE);
   Database_SYS.Remove_View('POSTING_CTRL_CONTROL_TYPE', TRUE);
   Database_SYS.Remove_View('POSTING_CTRL_DETAIL', TRUE);
   Database_SYS.Remove_View('POSTING_CTRL_DETAIL_AV', TRUE);
   Database_SYS.Remove_View('POSTING_CTRL_DETAIL_GEN_PCT', TRUE);
   Database_SYS.Remove_View('POSTING_CTRL_DETAIL_PUB', TRUE);
   Database_SYS.Remove_View('POSTING_CTRL_DETAIL_REP', TRUE);
   Database_SYS.Remove_View('POSTING_CTRL_DETAIL_RPV', TRUE);
   Database_SYS.Remove_View('POSTING_CTRL_DETAIL_SPEC', TRUE);
   Database_SYS.Remove_View('POSTING_CTRL_DETAIL_SPEC_PUB', TRUE);
   Database_SYS.Remove_View('POSTING_CTRL_DETAIL_SPEC_RPV', TRUE);
   Database_SYS.Remove_View('POSTING_CTRL_DET_SPEC_GEN_PCT', TRUE);
   Database_SYS.Remove_View('POSTING_CTRL_GEN_PCT', TRUE);
   Database_SYS.Remove_View('POSTING_CTRL_MASTER', TRUE);
   Database_SYS.Remove_View('POSTING_CTRL_POSTING_TYPE', TRUE);
   Database_SYS.Remove_View('POSTING_CTRL_PUB', TRUE);
   Database_SYS.Remove_View('POSTING_CTRL_RPV', TRUE);
   Database_SYS.Remove_View('PRE_ACCOUNT_CODEPART_A_MPCCOM', TRUE);
   Database_SYS.Remove_View('PRIVATE_PSEUDO_CODES', TRUE);
   Database_SYS.Remove_View('PROJECT_COST_ELEMENT', TRUE);
   Database_SYS.Remove_View('PROJECT_COST_ELEMENT_LOV', TRUE);
   Database_SYS.Remove_View('PROJECT_COST_TYPE_ELEMENT_LOV', TRUE);
   Database_SYS.Remove_View('PROJECT_REV_TYPE_ELEMENT_LOV', TRUE);
   Database_SYS.Remove_View('PSEUDO_CODES', TRUE);
   Database_SYS.Remove_View('PS_CODE_ACCOUNT', TRUE);
   Database_SYS.Remove_View('PS_CODE_ACCOUNTING_CODE_PART_A', TRUE);
   Database_SYS.Remove_View('RPD_COMPANY', TRUE);
   Database_SYS.Remove_View('RPD_COMPANY_PERIOD', TRUE);
   Database_SYS.Remove_View('RPD_COMPANY_PERIOD_DET', TRUE);
   Database_SYS.Remove_View('RPD_IDENTITY', TRUE);
   Database_SYS.Remove_View('RPD_PERIOD', TRUE);
   Database_SYS.Remove_View('RPD_PERIOD_DETAIL', TRUE);
   Database_SYS.Remove_View('RPD_YEAR', TRUE);
   Database_SYS.Remove_View('SECONDARY_ACC_CODE_PART_VALUE', TRUE);
   Database_SYS.Remove_View('STATUTORY_FEE', TRUE);
   Database_SYS.Remove_View('STATUTORY_FEE_DEDUCTIBLE', TRUE);
   Database_SYS.Remove_View('STATUTORY_FEE_DEDUCT_MULTIPLE', TRUE);
   Database_SYS.Remove_View('STATUTORY_FEE_DETAIL', TRUE);
   Database_SYS.Remove_View('STATUTORY_FEE_MULTIPLE', TRUE);
   Database_SYS.Remove_View('STATUTORY_FEE_NON_RDE', TRUE);
   Database_SYS.Remove_View('STATUTORY_FEE_NON_RDE_MULTIPLE', TRUE);
   Database_SYS.Remove_View('STATUTORY_FEE_NON_VAT', TRUE);
   Database_SYS.Remove_View('STATUTORY_FEE_NON_VAT_MULTIPLE', TRUE);
   Database_SYS.Remove_View('STATUTORY_FEE_PUB', TRUE);
   Database_SYS.Remove_View('STATUTORY_FEE_TAX_WITHHOLD', TRUE);
   Database_SYS.Remove_View('STATUTORY_FEE_VAT', TRUE);
   Database_SYS.Remove_View('STATUTORY_FEE_VAT_MULT', TRUE);
   Database_SYS.Remove_View('STATUTORY_FEE_VAT_MULT_ZERO', TRUE);
   Database_SYS.Remove_View('STATUTORY_FEE_VSR', TRUE);
   Database_SYS.Remove_View('STAT_ACCOUNT_LOV', TRUE);
   Database_SYS.Remove_View('SUPP_CHECK_VOU_TYPE', TRUE);
   Database_SYS.Remove_View('SYSTEM_FOOTER_FIELD', TRUE);
   Database_SYS.Remove_View('TAX_ACCOUNT', TRUE);
   Database_SYS.Remove_View('TAX_BOOK', TRUE);
   Database_SYS.Remove_View('TAX_BOOK_LOV', TRUE);
   Database_SYS.Remove_View('TAX_BOOK_STRUCTURE', TRUE);
   Database_SYS.Remove_View('TAX_BOOK_STRUCTURE_ITEM', TRUE);
   Database_SYS.Remove_View('TAX_BOOK_STRUCTURE_ITEM2', TRUE);
   Database_SYS.Remove_View('TAX_BOOK_STRUCTURE_ITEM3', TRUE);
   Database_SYS.Remove_View('TAX_BOOK_STRUCTURE_LEVEL', TRUE);
   Database_SYS.Remove_View('TAX_CLASS', TRUE);
   Database_SYS.Remove_View('TAX_CODES_PER_TAX_CLASS', TRUE);
   Database_SYS.Remove_View('TAX_CODES_PER_TAX_CLASS_PUB', TRUE);
   Database_SYS.Remove_View('TAX_CODE_LOV1', TRUE);
   Database_SYS.Remove_View('TAX_CODE_PER_TAX_BOOK', TRUE);
   Database_SYS.Remove_View('TAX_CODE_TEXTS', TRUE);
   Database_SYS.Remove_View('TAX_LIABILITY_DATE_CTRL', TRUE);
   Database_SYS.Remove_View('TAX_LIABILITY_DATE_CTRL_AV', TRUE);
   Database_SYS.Remove_View('TAX_LIABLTY_DATE_EXCEPTION', TRUE);
   Database_SYS.Remove_View('TAX_LIABLTY_DATE_EXCEPTION_AV', TRUE);
   Database_SYS.Remove_View('TEXT_TYPE', TRUE);
   Database_SYS.Remove_View('TRANSFERRED_VOUCHER', TRUE);
   Database_SYS.Remove_View('TRANSFERRED_VOUCHER_ROW', TRUE);
   Database_SYS.Remove_View('USER_FINANCE', TRUE);
   Database_SYS.Remove_View('USER_FINANCE_AUTH_PUB', TRUE);
   Database_SYS.Remove_View('USER_GROUP_FINANCE', TRUE);
   Database_SYS.Remove_View('USER_GROUP_FINANCE_ADM', TRUE);
   Database_SYS.Remove_View('USER_GROUP_MEMBER_FINANCE', TRUE);
   Database_SYS.Remove_View('USER_GROUP_MEMBER_FINANCE2', TRUE);
   Database_SYS.Remove_View('USER_GROUP_MEMBER_FINANCE3', TRUE);
   Database_SYS.Remove_View('USER_GROUP_MEMBER_FINANCE4', TRUE);
   Database_SYS.Remove_View('USER_GROUP_MEMBER_FINANCE_ADM', TRUE);
   Database_SYS.Remove_View('USER_GROUP_PERIOD', TRUE);
   Database_SYS.Remove_View('VOUCHER', TRUE);
   Database_SYS.Remove_View('VOUCHER_APPROVAL', TRUE);
   Database_SYS.Remove_View('VOUCHER_NOTE', TRUE);
   Database_SYS.Remove_View('VOUCHER_NO_SERIAL', TRUE);
   Database_SYS.Remove_View('VOUCHER_NO_SERIAL_YR', TRUE);
   Database_SYS.Remove_View('VOUCHER_ROW', TRUE);
   Database_SYS.Remove_View('VOUCHER_ROW_QRY', TRUE);
   Database_SYS.Remove_View('VOUCHER_ROW_QRY_FINREP', TRUE);
   Database_SYS.Remove_View('VOUCHER_ROW_QRY_PID_FINREP', TRUE);
   Database_SYS.Remove_View('VOUCHER_TEMPLATE', TRUE);
   Database_SYS.Remove_View('VOUCHER_TEMPLATE_ROW', TRUE);
   Database_SYS.Remove_View('VOUCHER_TEXT', TRUE);
   Database_SYS.Remove_View('VOUCHER_TRANSFER_HIST', TRUE);
   Database_SYS.Remove_View('VOUCHER_TYPE', TRUE);
   Database_SYS.Remove_View('VOUCHER_TYPE_ALL_LEDGER', TRUE);
   Database_SYS.Remove_View('VOUCHER_TYPE_DETAIL', TRUE);
   Database_SYS.Remove_View('VOUCHER_TYPE_DETAIL_LOV', TRUE);
   Database_SYS.Remove_View('VOUCHER_TYPE_DETAIL_QUERY', TRUE);
   Database_SYS.Remove_View('VOUCHER_TYPE_DET_ALL_LED', TRUE);
   Database_SYS.Remove_View('VOUCHER_TYPE_FOR_F', TRUE);
   Database_SYS.Remove_View('VOUCHER_TYPE_FOR_H', TRUE);
   Database_SYS.Remove_View('VOUCHER_TYPE_FOR_I', TRUE);
   Database_SYS.Remove_View('VOUCHER_TYPE_FOR_P', TRUE);
   Database_SYS.Remove_View('VOUCHER_TYPE_FOR_PC', TRUE);
   Database_SYS.Remove_View('VOUCHER_TYPE_FOR_Z', TRUE);
   Database_SYS.Remove_View('VOUCHER_TYPE_FUNCTION_GROUP', TRUE);
   Database_SYS.Remove_View('VOUCHER_TYPE_GEN', TRUE);
   Database_SYS.Remove_View('VOUCHER_TYPE_INT', TRUE);
   Database_SYS.Remove_View('VOUCHER_TYPE_INTERIM_VOU', TRUE);
   Database_SYS.Remove_View('VOUCHER_TYPE_INTERNAL_PERIOD', TRUE);
   Database_SYS.Remove_View('VOUCHER_TYPE_INT_ALL', TRUE);
   Database_SYS.Remove_View('VOUCHER_TYPE_USER_GROUP', TRUE);
   Database_SYS.Remove_View('VOUCHER_TYPE_USER_GROUP2', TRUE);
   Database_SYS.Remove_View('VOUCHER_TYPE_USER_GROUP3', TRUE);
   Database_SYS.Remove_View('VOUCHER_TYPE_USER_GROUP_INT', TRUE);
   Database_SYS.Remove_View('VOUCHER_TYPE_USER_GROUP_LOV', TRUE);
   Database_SYS.Remove_View('VOUCHER_TYPE_USER_GRP_ALL_GL', TRUE);
   Database_SYS.Remove_View('VOUCHER_TYPE_USER_GRP_FA', TRUE);
   Database_SYS.Remove_View('VOUCHER_TYPE_USER_GRP_INTERNAL', TRUE);
   Database_SYS.Remove_View('VOUCHER_TYPE_USER_VOV', TRUE);
   Database_SYS.Remove_View('VOUCHER_TYPE_VOUCHER_GROUP', TRUE);
   Database_SYS.Remove_View('VOU_TYPE_MULTI_FUNC_GROUP', TRUE);
   Database_SYS.Remove_View('YEAR_END_FROM_YEAR_LOV', TRUE);
   Database_SYS.Remove_View('YEAR_END_TO_YEAR_LOV', TRUE);
   Database_SYS.Remove_View('YEAR_END_USER_GROUP_LOV', TRUE);
   Database_SYS.Remove_View('YEAR_END_VOUCHER_TYPE_LOV', TRUE);
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
   Database_SYS.Remove_Sequence('ACCRUL_FICTIVE_VOU_NO', TRUE);
   Database_SYS.Remove_Sequence('AUDIT_STORAGE_SEQ', TRUE);
   Database_SYS.Remove_Sequence('CODESTRING_COMB_SEQ', TRUE);
   Database_SYS.Remove_Sequence('EXT_FILE_BATCH_PARAM_SEQ', TRUE);
   Database_SYS.Remove_Sequence('EXT_FILE_SEQUENCE', TRUE);
   Database_SYS.Remove_Sequence('FIN_SELECTION_OBJECT_ID_SEQ', TRUE);
   Database_SYS.Remove_Sequence('PERIOD_ALLOCATION_SEQ', TRUE);
   Database_SYS.Remove_Sequence('PERIOD_ALLOC_LINE_SEQ', TRUE);
   Database_SYS.Remove_Sequence('USERENV_SESSION_SEQ', TRUE);
   Database_SYS.Remove_Sequence('ACRRUL_EXT_PROCESS_SEQUENCE', TRUE);
   Database_SYS.Remove_Sequence('INTERNAL_MANUAL_POST_SEQ', TRUE);
   Database_SYS.Remove_Sequence('VOUCHER_TRANSFER_HIST_SEQ', TRUE);
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
   Database_SYS.Remove_Materialized_View('ACCOUNTING_PERIOD_MV', TRUE);
   Database_SYS.Remove_Materialized_View('ACCOUNTING_PERIOD_TRANSL_MV', TRUE);
   Database_SYS.Remove_Materialized_View('ACCOUNTING_PROCESS_CODE_MV', TRUE);
   Database_SYS.Remove_Materialized_View('ACCOUNT_MV', TRUE);
   Database_SYS.Remove_Materialized_View('ACCOUNT_TRANSLATION_MV', TRUE);
   Database_SYS.Remove_Materialized_View('ACC_PROCESS_CODE_TRANSL_MV', TRUE);
   Database_SYS.Remove_Materialized_View('ANALYTIC_ATTR_ACCOUNT_MV', TRUE);
   Database_SYS.Remove_Materialized_View('ANALYTIC_ATTR_CODE_B_MV', TRUE);
   Database_SYS.Remove_Materialized_View('ANALYTIC_ATTR_CODE_C_MV', TRUE);
   Database_SYS.Remove_Materialized_View('ANALYTIC_ATTR_CODE_D_MV', TRUE);
   Database_SYS.Remove_Materialized_View('ANALYTIC_ATTR_CODE_E_MV', TRUE);
   Database_SYS.Remove_Materialized_View('ANALYTIC_ATTR_CODE_F_MV', TRUE);
   Database_SYS.Remove_Materialized_View('ANALYTIC_ATTR_CODE_G_MV', TRUE);
   Database_SYS.Remove_Materialized_View('ANALYTIC_ATTR_CODE_H_MV', TRUE);
   Database_SYS.Remove_Materialized_View('ANALYTIC_ATTR_CODE_I_MV', TRUE);
   Database_SYS.Remove_Materialized_View('ANALYTIC_ATTR_CODE_J_MV', TRUE);
   Database_SYS.Remove_Materialized_View('CODE_B_MV', TRUE);
   Database_SYS.Remove_Materialized_View('CODE_B_TRANSLATION_MV', TRUE);
   Database_SYS.Remove_Materialized_View('CODE_C_MV', TRUE);
   Database_SYS.Remove_Materialized_View('CODE_C_TRANSLATION_MV', TRUE);
   Database_SYS.Remove_Materialized_View('CODE_D_MV', TRUE);
   Database_SYS.Remove_Materialized_View('CODE_D_TRANSLATION_MV', TRUE);
   Database_SYS.Remove_Materialized_View('CODE_E_MV', TRUE);
   Database_SYS.Remove_Materialized_View('CODE_E_TRANSLATION_MV', TRUE);
   Database_SYS.Remove_Materialized_View('CODE_F_MV', TRUE);
   Database_SYS.Remove_Materialized_View('CODE_F_TRANSLATION_MV', TRUE);
   Database_SYS.Remove_Materialized_View('CODE_G_MV', TRUE);
   Database_SYS.Remove_Materialized_View('CODE_G_TRANSLATION_MV', TRUE);
   Database_SYS.Remove_Materialized_View('CODE_H_MV', TRUE);
   Database_SYS.Remove_Materialized_View('CODE_H_TRANSLATION_MV', TRUE);
   Database_SYS.Remove_Materialized_View('CODE_I_MV', TRUE);
   Database_SYS.Remove_Materialized_View('CODE_I_TRANSLATION_MV', TRUE);
   Database_SYS.Remove_Materialized_View('CODE_J_MV', TRUE);
   Database_SYS.Remove_Materialized_View('CODE_J_TRANSLATION_MV', TRUE);
   Database_SYS.Remove_Materialized_View('COMPANY_FINANCE_MV', TRUE);
   Database_SYS.Remove_Materialized_View('CURRENCY_CODE_MV', TRUE);
   Database_SYS.Remove_Materialized_View('CURRENCY_RATE_MV', TRUE);
   Database_SYS.Remove_Materialized_View('CURRENCY_RATE_TYPE_MV', TRUE);
   Database_SYS.Remove_Materialized_View('RPD_COMPANY_PERIOD_MV', TRUE);
   Database_SYS.Remove_Materialized_View('RPD_PERIOD_MV', TRUE);
   Database_SYS.Remove_Materialized_View('SUBSIDIARY_COMPANY_MV', TRUE);
   Database_SYS.Remove_Materialized_View('TAXCODE_MV', TRUE);
   Database_SYS.Remove_Materialized_View('TAXCODE_TRANSLATION_MV', TRUE);
   Database_SYS.Remove_Materialized_View('TAX_BOOK_MV', TRUE);
   Database_SYS.Remove_Materialized_View('TAX_BOOK_TRANSLATION_MV', TRUE);
   Database_SYS.Remove_Materialized_View('VOUCHER_TYPE_MV', TRUE);
   Database_SYS.Remove_Materialized_View('VOUCHER_TYPE_TRANSL_MV', TRUE);
END;
/

----------------------------------------------------------------
-- Drop tables
----------------------------------------------------------------
-- NOTE: Tables below are referred only by current module...

BEGIN
   dbms_output.put_line('Removing Tables refered only by current Module...');
   Database_SYS.Remove_Table('ACCOUNTING_CODESTR_COMB_TAB', TRUE);
   Database_SYS.Remove_Table('ACCOUNTING_CODESTR_COMPL_TAB', TRUE);
   Database_SYS.Remove_Table('ACCOUNT_TAX_CODE_TAB', TRUE);
   Database_SYS.Remove_Table('ACCOUNTING_PROCESS_CODE_TAB', TRUE);
   Database_SYS.Remove_Table('ACCOUNTING_SEQ_NO_TAB', TRUE);
   Database_SYS.Remove_Table('ACCOUNTING_TEXT_TAB', TRUE);
   Database_SYS.Remove_Table('AC_AM_STR', TRUE);
   Database_SYS.Remove_Table('AC_AM_STR_ALLOWED_COMB', TRUE);
   Database_SYS.Remove_Table('AC_AM_STR_CODE', TRUE);
   Database_SYS.Remove_Table('AC_AM_STR_CONTROL_TYPE', TRUE);
   Database_SYS.Remove_Table('AC_AM_STR_ROW', TRUE);
   Database_SYS.Remove_Table('AUDIT_FORMAT_TAB', TRUE);
   Database_SYS.Remove_Table('AUDIT_SOURCE_COLUMN_TAB', TRUE);
   Database_SYS.Remove_Table('AUDIT_SOURCE_TAB', TRUE);
   Database_SYS.Remove_Table('AUDIT_STORAGE_TAB', TRUE);
   Database_SYS.Remove_Table('COMB_CONTROL_TYPE_TAB', TRUE);
   Database_SYS.Remove_Table('COMB_RULE_ID_TAB', TRUE);
   Database_SYS.Remove_Table('COST_ELEMENT_TO_ACCOUNT_TAB', TRUE);
   Database_SYS.Remove_Table('COST_ELE_TO_ACCNT_SECMAP_TAB', TRUE);
   Database_SYS.Remove_Table('CURRENCY_RATE_DEF_TAB', TRUE);
   Database_SYS.Remove_Table('CURRENCY_TYPE_DEF_TAB', TRUE);
   Database_SYS.Remove_Table('EXT_CURRENCY_TASK_DETAIL_TAB', TRUE);
   Database_SYS.Remove_Table('EXT_CURRENCY_TASK_TAB', TRUE);
   Database_SYS.Remove_Table('EXT_FILE_BATCH_PARAM_TAB', TRUE);
   Database_SYS.Remove_Table('EXT_FILE_COMPANY_DEFAULT_TAB', TRUE);
   Database_SYS.Remove_Table('EXT_FILE_FUNCTION_TAB', TRUE);
   Database_SYS.Remove_Table('EXT_FILE_LOG_DETAIL_TAB', TRUE);
   Database_SYS.Remove_Table('EXT_FILE_LOG_TAB', TRUE);
   Database_SYS.Remove_Table('EXT_FILE_SEPARATOR_TAB', TRUE);
   Database_SYS.Remove_Table('EXT_FILE_TEMPLATE_CONTROL_TAB', TRUE);
   Database_SYS.Remove_Table('EXT_FILE_TYPE_PARAM_TAB', TRUE);
   Database_SYS.Remove_Table('EXT_FILE_TYPE_REC_COLUMN_TAB', TRUE);
   Database_SYS.Remove_Table('EXT_FILE_XML_LAYOUT_TAB', TRUE);
   Database_SYS.Remove_Table('EXT_LOAD_ID_STORAGE_TAB', TRUE);
   Database_SYS.Remove_Table('EXT_LOAD_INFO_TAB', TRUE);
   Database_SYS.Remove_Table('EXT_PARAMETERS_TAB', TRUE);
   Database_SYS.Remove_Table('EXT_TRANSACTIONS_TAB', TRUE);
   Database_SYS.Remove_Table('EXT_TYPE_PARAM_PER_SET_TAB', TRUE);
   Database_SYS.Remove_Table('EXT_TYPE_PARAM_SET_TAB', TRUE);
   Database_SYS.Remove_Table('EXT_VOUCHER_ROW_TAB', TRUE);
   Database_SYS.Remove_Table('EXT_VOUCHER_TAB', TRUE);
   Database_SYS.Remove_Table('FIN_OBJECT_TAB', TRUE);
   Database_SYS.Remove_Table('FIN_OBJ_GRP_OBJECT_TAB', TRUE);
   Database_SYS.Remove_Table('FIN_OBJ_GRP_SEL_OBJECT_TAB', TRUE);
   Database_SYS.Remove_Table('FIN_OBJ_GRP_TAB', TRUE);
   Database_SYS.Remove_Table('FIN_OBJ_SELECTION_VALUES_TAB', TRUE);
   Database_SYS.Remove_Table('FIN_SEL_OBJECT_ALLOW_OPER_TAB', TRUE);
   Database_SYS.Remove_Table('FIN_SEL_OBJECT_TAB', TRUE);
   Database_SYS.Remove_Table('FIN_SEL_OBJ_TEMPL_DET_TAB', TRUE);
   Database_SYS.Remove_Table('FIN_SEL_OBJ_TEMPL_TAB', TRUE);
   Database_SYS.Remove_Table('FIN_SEL_TEMPL_VALUES_TAB', TRUE);
   Database_SYS.Remove_Table('FOOTER_CONNECTION_TAB', TRUE);
   Database_SYS.Remove_Table('FOOTER_FIELD_TAB', TRUE);
   Database_SYS.Remove_Table('INTERNAL_POSTINGS_ACCRUL_TAB', TRUE);
   Database_SYS.Remove_Table('PAYMENT_VACATION_PERIOD_TAB', TRUE);
   Database_SYS.Remove_Table('POSTING_CTRL_ALLOWED_COMB_TAB', TRUE);
   Database_SYS.Remove_Table('POSTING_CTRL_CONTROL_TYPE_TAB', TRUE);
   Database_SYS.Remove_Table('POSTING_CTRL_DETAIL_RPT', TRUE);
   Database_SYS.Remove_Table('POSTING_CTRL_DETAIL_SPEC_RPT', TRUE);
   Database_SYS.Remove_Table('POSTING_CTRL_DETAIL_TEMP_TAB', TRUE);
   Database_SYS.Remove_Table('POSTING_CTRL_RPT', TRUE);
   Database_SYS.Remove_Table('PSEUDO_CODES_TAB', TRUE);
   Database_SYS.Remove_Table('RPD_COMPANY_PERIOD_TAB', TRUE);
   Database_SYS.Remove_Table('RPD_YEAR_TAB', TRUE);
   Database_SYS.Remove_Table('SYSTEM_FOOTER_FIELD_TAB', TRUE);
   Database_SYS.Remove_Table('TAX_BOOK_STRUCTURE_LEVEL_TAB', TRUE);
   Database_SYS.Remove_Table('TAX_CLASS_TAB', TRUE);
   Database_SYS.Remove_Table('TAX_CODES_PER_TAX_CLASS_TAB', TRUE);
   Database_SYS.Remove_Table('TRANSLATION_TYPE_TAB', TRUE);
   Database_SYS.Remove_Table('VOUCHER_NO_SERIAL_TAB', TRUE);
   Database_SYS.Remove_Table('VOUCHER_TEMPLATE_ROW_TAB', TRUE);
   Database_SYS.Remove_Table('VOUCHER_TEMPLATE_TAB', TRUE);
   Database_SYS.Remove_Table('VOUCHER_TEXT_TAB', TRUE);
   Database_SYS.Remove_Table('VOUCHER_TRANSFER_HIST_TAB', TRUE);
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
   Database_SYS.Remove_Table('ACCOUNTING_ATTRIBUTE_CON_TAB', TRUE);
   Database_SYS.Remove_Table('ACCOUNTING_ATTRIBUTE_TAB', TRUE);
   Database_SYS.Remove_Table('ACCOUNTING_ATTRIBUTE_VALUE_TAB', TRUE);
   Database_SYS.Remove_Table('ACCOUNTING_CODE_PART_VALUE_TAB', TRUE);
   Database_SYS.Remove_Table('ACCOUNTING_PERIOD_TAB', TRUE);
   Database_SYS.Remove_Table('ACCOUNTING_YEAR_TAB', TRUE);
   Database_SYS.Remove_Table('ACCOUNT_GROUP_TAB', TRUE);
   Database_SYS.Remove_Table('ACCOUNT_TYPE_TAB', TRUE);
   Database_SYS.Remove_Table('ACCRUL_ATTRIBUTE_TAB', TRUE);
   Database_SYS.Remove_Table('ACCRUL_SESSION_PID_TAB', TRUE);
   Database_SYS.Remove_Table('CODESTRING_COMB_TAB', TRUE);
   Database_SYS.Remove_Table('COMPANY_FINANCE_TAB', TRUE);
   Database_SYS.Remove_Table('CURRENCY_CODE_TAB', TRUE);
   Database_SYS.Remove_Table('CURRENCY_RATE_TAB', TRUE);
   Database_SYS.Remove_Table('CURRENCY_TYPE_BASIC_DATA_TAB', TRUE);
   Database_SYS.Remove_Table('CURRENCY_TYPE_TAB', TRUE);
   Database_SYS.Remove_Table('EXT_FILE_IDENTITY_TAB', TRUE);
   Database_SYS.Remove_Table('EXT_FILE_LOAD_TAB', TRUE);
   Database_SYS.Remove_Table('EXT_FILE_TEMPLATE_DETAIL_TAB', TRUE);
   Database_SYS.Remove_Table('EXT_FILE_TEMPLATE_DIR_TAB', TRUE);
   Database_SYS.Remove_Table('EXT_FILE_TEMPLATE_TAB', TRUE);
   Database_SYS.Remove_Table('EXT_FILE_TEMPL_DET_FUNC_TAB', TRUE);
   Database_SYS.Remove_Table('EXT_FILE_TRANS_TAB', TRUE);
   Database_SYS.Remove_Table('EXT_FILE_TYPE_REC_TAB', TRUE);
   Database_SYS.Remove_Table('EXT_FILE_TYPE_TAB', TRUE);
   Database_SYS.Remove_Table('FINANCE_DOC_REG_TAB', TRUE);
   Database_SYS.Remove_Table('FIN_OBJECT_SELECTION_TAB', TRUE);
   Database_SYS.Remove_Table('FOOTER_CONNECTION_MASTER_TAB', TRUE);
   Database_SYS.Remove_Table('FOOTER_DEFINITION_TAB', TRUE);
   Database_SYS.Remove_Table('FUNCTION_GROUP_TAB', TRUE);
   Database_SYS.Remove_Table('MULTI_COMPANY_VOUCHER_ROW_TAB', TRUE);
   Database_SYS.Remove_Table('MULTI_COMPANY_VOUCHER_TAB', TRUE);
   Database_SYS.Remove_Table('PAYMENT_TERM_DETAILS_TAB', TRUE);
   Database_SYS.Remove_Table('PAYMENT_TERM_TAB', TRUE);
   Database_SYS.Remove_Table('PERIOD_ALLOCATION_RULE_TAB', TRUE);
   Database_SYS.Remove_Table('PERIOD_ALLOCATION_TAB', TRUE);
   Database_SYS.Remove_Table('PERIOD_ALLOC_RULE_LINE_TAB', TRUE);
   Database_SYS.Remove_Table('POSTING_CTRL_COMB_DETAIL_TAB', TRUE);
   Database_SYS.Remove_Table('POSTING_CTRL_COMB_DET_SPEC_TAB', TRUE);
   Database_SYS.Remove_Table('POSTING_CTRL_DETAIL_SPEC_TAB', TRUE);
   Database_SYS.Remove_Table('POSTING_CTRL_DETAIL_TAB', TRUE);
   Database_SYS.Remove_Table('POSTING_CTRL_POSTING_TYPE_TAB', TRUE);
   Database_SYS.Remove_Table('POSTING_CTRL_TAB', TRUE);
   Database_SYS.Remove_Table('PROJECT_COST_ELEMENT_TAB', TRUE);
   Database_SYS.Remove_Table('RPD_COMPANY_PERIOD_DET_TAB', TRUE);
   Database_SYS.Remove_Table('RPD_COMPANY_TAB', TRUE);
   Database_SYS.Remove_Table('RPD_IDENTITY_TAB', TRUE);
   Database_SYS.Remove_Table('RPD_PERIOD_DETAIL_TAB', TRUE);
   Database_SYS.Remove_Table('RPD_PERIOD_TAB', TRUE);
   Database_SYS.Remove_Table('STATUTORY_FEE_DETAIL_TAB', TRUE);
   Database_SYS.Remove_Table('STATUTORY_FEE_TAB', TRUE);
   Database_SYS.Remove_Table('TAX_BOOK_STRUCTURE_ITEM_TAB', TRUE);
   Database_SYS.Remove_Table('TAX_BOOK_STRUCTURE_TAB', TRUE);
   Database_SYS.Remove_Table('TAX_BOOK_TAB', TRUE);
   Database_SYS.Remove_Table('TAX_CODE_PER_TAX_BOOK_TAB', TRUE);
   Database_SYS.Remove_Table('TAX_CODE_TEXTS_TAB', TRUE);
   Database_SYS.Remove_Table('TAX_LIABILITY_DATE_CTRL_TAB', TRUE);
   Database_SYS.Remove_Table('TAX_LIABLTY_DATE_EXCEPTION_TAB', TRUE);
   Database_SYS.Remove_Table('TRANSFERRED_VOUCHER_ROW_TAB', TRUE);
   Database_SYS.Remove_Table('TRANSFERRED_VOUCHER_TAB', TRUE);
   Database_SYS.Remove_Table('USER_FINANCE_TAB', TRUE);
   Database_SYS.Remove_Table('USER_GROUP_FINANCE_TAB', TRUE);
   Database_SYS.Remove_Table('USER_GROUP_MEMBER_FINANCE_TAB', TRUE);
   Database_SYS.Remove_Table('USER_GROUP_PERIOD_TAB', TRUE);
   Database_SYS.Remove_Table('VOUCHER_NOTE_TAB', TRUE);
   Database_SYS.Remove_Table('VOUCHER_ROW_TAB', TRUE);
   Database_SYS.Remove_Table('VOUCHER_TAB', TRUE);
   Database_SYS.Remove_Table('VOUCHER_TYPE_DETAIL_TAB', TRUE);
   Database_SYS.Remove_Table('VOUCHER_TYPE_TAB', TRUE);
   Database_SYS.Remove_Table('VOUCHER_TYPE_USER_GROUP_TAB', TRUE);
END;
/


----------------------------------------------------------------
-- Removing patch registrations for this module
----------------------------------------------------------------
BEGIN
   dbms_output.put_line('Removing Patch Registrations for the Module...');
   Database_SYS.Clear_Db_Patch_Registration('ACCRUL');
END;
/

----------------------------------------------------------------
-- Removing module version information
----------------------------------------------------------------
BEGIN
   dbms_output.put_line('Removing Module Version Information for the Module...');
   Module_Api.Clear('ACCRUL');
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

