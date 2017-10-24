-----------------------------------------------------------------------------
--
--  Logical unit: Account
--  Component:    ACCRUL
--
--  IFS Developer Studio Template Version 3.0
--
--  Date    Sign    History
--  ------  ------  ---------------------------------------------------------
--  971103  MiJo     Created
--  980619  Kanchi   Modified to accomadate codepart 'A' functionality  through
--                   this LU.
--                   Views from Accounting_code_Part_A were copied. And as for the start
--                   only the public functions/procedures  were copied from accounting_
--                   code_part_A.
--                   Function calls to functions/procedures of  accounting_code_part_A are
--                   directed to this Account LU:s copied functions/procedures.
--  980914  Bren     Master Slave Connection.
--                   Added procedures Send_Account_Info & Receive_Account_Info.
--  990317  Bren     Bug #: 5779. Added a protected procedure Exist to handle overloaded procedure.
--  990416  Ruwan    Modified with respect to new template
--  990928  Uma      Fixed Bug#11701
--  991118  FAMESE   Added "Text_Field_Translation_API.Insert_Text" in "Unpack_Check_Insert___".
--                   Changed Description VARCHAR2(100) to VARCHAR2(200). Changed some of MessageId.
--  000118  Dhar     Modified PROCEDURE Modifydefdata__
--  000119  Uma      Global Date Definition.
--  000414  HiMu     Add Valid_from, Valid_Until to view3
--  000607  BmEk     A522: Added column tax_handling_value and Get_Tax_Handling_Value
--  000614  LeKa     A521: Added procedure Validate_Tax_Account. Added column tax_flag and tax_flag_db.
--  000627  BmEk     A522: Modified Get_Tax_Handling_Value.
--  000706  LiSv     A521: Added Is_Tax_Account
--  000807  BmEk     A522: Added Validate_Tax_Code___ and call to this procedure in
--                   Validate_Insert_Modify___.
--  000817  Uma      A540: Added no_archiving_trans in inserting and updating.
--  000831  Uma      A540: Modified no_archiving_trans according to new requirements.
--  000908  HiMu     Added General_SYS.Init_Method
--  000909  Uma      Added PROCEDURE Is_Tax_Account.
--  001004  prtilk   BUG # 15677  Checked General_SYS.Init_Method
--  001013  Uma      Corrected BugId #49192. Added View4
--  001013  LiSv     A809: Added VIEW5 - Tax Account
--  001013  BmEk     A807: Added column tax_code_mandatory and Is_Tax_Code_Mandatory.
--  001019  Uma      Corrected Bug #50700.
--  001031  BMEk     A807: Modified tax_code_mandatory to FALSE in Prepare_Insert___.
--  001204  LiSv     For new Create Company concept added new view account_ect and account_pct.
--                   Added procedures Make_Company, Copy___, Import___, Export___, Validate_Insert_Modify,
--                   Validate_Cons_Account and New.
--  010221  ToOs     Bug #20177 Added Global Lu constants for check for transaction_sys calls
--  010409  JeGu     Bug #21018 Performance, New procedures Validate_Account, Get_Stat_Curr
--  010410  JeGu     Bug #21018 Changed some functions/procedures wich are common to all codepart-LU's
--                   This functions/procedures now calls Accounting_Code_Part_Value_API
--  010427  LiSv     Removed procedure Modifydefdata__ and Receive_Default_Info.
--  010509  JeGu     Bug #21705 Implementation New Dummyinterface
--                   Changed Insert__ RETURNING rowid INTO objid_
--  010523  Chablk   Bug #22010. Commented Call statements of Account Type exist functions for the Hold Table & GL Table
--  010531  Bmekse   Removed methods used by the old way for transfer basic data from
--                   master to slave (nowdays is Replication used instead)
--  010816  OVJOSE   Added Create Company translation method Create_Company_Translations___
--  010821  Chablk   Bug #22010. Commented Call statements of Logical Account Type exist functions for the Hold Table & GL Table
--  020102  THSRLK   IID 20001 Enhancement of Update Company. Changes inside make_company method
--                   Changed Import___, Export___ and Copy___ methods to use records
--  020206  MaNi     Company Translation ( Enterp_Comp_Connect_V160_API )
--  020219  KAGALK   Call ID 27292 (Merged code)
--  020321  Uma      Merged Bug# 28324. Changed "POSTCTRLEXIST_PER_BAL" To "POSTCTRLEXISTPERBAL".
--  020618  ovjose   Bug 31025 corrected. Update of company does not work properly for Accounts.
--  021001  Nimalk   Removed usage of the view Company_Finance_Auth in ACCOUNT,TAX_ACCOUNT and ACCOUNTS_CONSOLIDATION view
--                   and replaced by view Company_Finance_Auth1 using EXISTS caluse instead of joins
--  021031  ovjose   Glob06. Added column description so the accounts can hold their own description.
--  030102  DAGALK   SP3 merge, Bug 31427, 32686.
--  031015  CHPRLK   Added validation to prevent changing logical account type if
--                   code part value is used in transcations
--  040323  Gepelk   2004 SP1 Merge
--  040621  Gepelk   IID FIPR307. Modified PS_CODE_ACCOUNTING_CODE_PART_A.
--  040623  anpelk   FIPR338A2: Unicode Changes.
--  040723  Gawilk   FIPR307A. Added view ACCOUNT_LOV
--  040830  Nalslk   Bug 117482. Modified TYPE column's value from Pseudo_Code_Value_API.Decode('2') to Accnt_Type
--  040902  KuPelk   Bug 117440. Modified ACCOUNT_LOV by adding user name to the type column.
--  040906  AjPelk   Call 117440 , A default null parameter has been added into Validate_Account_Pseudo__
--  040906  AjPelk   Call 117440 User name added to the type description of PS_CODE_ACCOUNT
--  041008  Thsrlk   LCS Merge (46856)
--  041110  nsillk   LCS Merge (44560)
--  050119  NiFelk   Call 120992, Corrected.
--  050201  nsillk   Merged Bug 42667.
--  050317  Samwlk   LCS Merge Bug 48389.
--  050321  upunlk   LCS Merge 47814 - Changed the valid_until date of the method Copy().
--  050411  Nsillk   LCS Merge 50362,Added sort_value in the else section of the sort_value.
--  050725  THPELk   001-Db Dic Test Corrections Replaced PKG2 with PKG
--  050908  Nsillk   LCS Merge(51856).
--  051025  Nsillk   Removed view ACCOUNT_CONSOLIDATION Because it is not used.
--  051026  Nsillk   LCS Merge(42667) Recorrection.
--  051229  Nsillk   LCS Merge(54796/54798).
--  050111  Vohelk   B129857 Added new function Is_Ledger_Tax_Account
--  050111  Maaylk   B132510 Changed VEIW3's 3rd select statement
--  060215  Shsalk   B134001 Corrected. Modified Account View.
--  060215  Nsillk   Changed the lenght of sort_value.
--  060218  Gawilk   Modified the key string to AccountingCodePartValue
--  060727  DHSELK   Modified to_date() function to work with Persian Calander.
--  060925  THAYLK   LCS Merge Bug 59300, Modified Unpack_Check_Update___
--  061002  Samwlk   LCS Merge 58036, Modified unpack check insert and unpack check update.
--  061019  GaDaLK   FIPL659 Added Get_Control_Type_Value_Desc
--  061130  Paralk   LCS 61575 Merged,Add new if to handle budget Accouts in Get_Required_Code_Part_Pseudo Function.
--  061206  Kagalk   LCS Merge 61513, Added NOCHECK option to column cons_accnt in ACCOUNT view.
--  061206           Added Check_Delete_Cons_Accnt___
--  061212  Kagalk   LCS Merge 58758, Added Function Get_Required_Code_Parts
--  070116  RUFELK   FIPL637A - Considered the 'O' logical account type where the 'S' logical_account_type was used.
--  070322  Shsalk   LCS Merge 63645, Corrected.Added more validation in Validate_Stat_Account___
--  070709  Paralk   LCS Merge 63624, View STAT_ACCOUNT_LOV added.
--  080515  NiFelk   Bug 63513, Corrected.
--  081013  Maselk   Bug 77356, Corrected. Modified the where condition of view pre_account_codepart_a_mpccom.
--  090123  RUFELK   Bug 79773 Corrected. Seperated the text translation tag and the actual text by a SPACE in the Exist() method.
--  090605  THPELK   Bug 82609 - Added missing UNDEFINE statements for VIEW_LOV, VIEW7, VIEW_LOV1.
--  090612  Jaralk   Bug 83118, Corrected in Unpack_Check_Update___ and Unpack_Check_Insert___
--  090713  ErFelk   Bug 83174, Modified some constants in Validate_Insert_Modify___, Unpack_Check_Update___,
--  090713           Validate_Consolidation_Accnt and Check_Currency_Balance___. 
--  090724  WAPELK   Bug Id 84476, Assign null to parent code parts when creating a new company/template 
--                   from consolidated company 
--  090810  Nirplk   Bug 83061, Corrected in Modify_Code_Part_Value
--  100423  SaFalk   Modified REF for logical_account_type in ACCOUNT.
--- 100130  Makrlk   TWIN PEAKS merge
            --  090102  Ersruk   Added new column exclude_proj_followup.
            --  090120  Ersruk   Validation added in Unpack_Check_Insert___,Unpack_Check_Update___ to check exclude_proj_followup.
-- -------------------------------SIZZLER-------------------------------------------------
-- 110817   Ersruk   Added new column exclude_periodical_cap.
-- 110909   NaSalk   Modified Copy___, Import___ and Export___.
-- 111115   NaSalk   Modified Validate_Insert_Modify___.
            --  090303  Ersruk   Added company template changes for exclude_proj_followup.
            --  090406  Ersruk   Added PA recommended changes.
            --  090513  Ersruk   Added parameter ex_proj_foll_changed_ into Validate_Excl_Proj_Flwup___,Validate_Insert_Modify___.
            --  091005  Ersruk   Called Cost_Element_To_Account_API.Get_Account_Cost_Element in Validate_Excl_Proj_Flwup___.
--  100223  Nsillk   EAFH-2142 , Modified methods Import and Copy 
--  110110  Janblk   RAVEN-1398, Modified the column order of view ACCOUNTS_CONSOLIDATION          
--  110808  JuKoDE   EDEL-69, Added procedure Validate_Budget_Req_Account_ to show required codepart demand info and called it from the other same method
--  110713  SACALK   FIDEAGLE-301, Merged LCS Bug ID 96812 Corrected. Added Prepare_Codepart_Demands() method. 
--  110622  WAPELK   FIDEAGLE-1161: LCS Merge (Bug Id 97220)- Check whether the account is available in IL Hold table before deleting from account form.
--  111018  Shdilk   SFI-135, Conditional compilation.
--  111018  Swralk   SFI-128, Added conditional compilation for the places that had called package FIXASS_CONNECTION_V890_API.
--  111025  Saallk   SPJ-552, Modified Delete___() to check if account is used in secondary mapping.
--  111027  Saallk   SPJ-552, Modified Validate_Excl_Proj_Flwup___() to secondary mapping checks.
--  120219  Gawilk   SFI-1578, Applied the patch 100077.
--  120326  Umdolk   EASTRTM-6191, Corrected in Get_Accnt_Group.
--  120514  SALIDE   EDEL-698, Added ACCOUNT_AV
--  120730  Maaylk   Bug 101320, Created function Validate_Account_Rec used in Validate_Account to remove usage of General_SYS.
--  121123  Thpelk  Bug 106680 - Modified Conditional compilation to use single component package.
--  121204  Maaylk   PEPA-183, Removed global variables
--   130611   Umdolk   DANU-465, Added logical account type to ACCOUNT_CODE_A1.
--  130618  IsSalk  Bug 110425, Added valid_from and valid_until to the view PRE_ACCOUNT_CODEPART_A_MPCCOM.
--  131113  Umdolk  PBFI-880, Refacotring.
--  140904  Mawelk  PRFI-1768  (LCS Bug Id 117967) Fixed 
--  150713  Umdolk  Bug 123573, Modified Check_Common to handle null values in EXCLUDE_FROM_CURR_TRANS.
--  150804  Chwtlk  Bug 121544, Modified PROCEDURE Check_Update___.
--  160824  Chwtlk  Bug 131063, Added FUNCTION Exist2 to return the varchar2 value with respect to FUNCTION Exists.
-----------------------------------------------------------------------------
-----------------------------------------------------------------------------
--  040723  ********************* IMPORTANT *********************************
--  040723      If PS_CODE_ACCOUNT is modified do the same in ACCOUNT_LOV
--  040723  ****************************************************************
-----------------------------------------------------------------------------

layer Core;

-------------------- PUBLIC DECLARATIONS ------------------------------------

TYPE Val_Account_Rec IS RECORD
   (val_result   VARCHAR2(5),
    curr_balance ACCOUNTING_CODE_PART_VALUE_TAB.curr_balance%TYPE,
    req_string   VARCHAR2(100));    


-------------------- PRIVATE DECLARATIONS -----------------------------------


-------------------- LU SPECIFIC IMPLEMENTATION METHODS ---------------------

@Override
PROCEDURE Raise_Record_Not_Exist___ (
   company_ IN VARCHAR2,
   account_ IN VARCHAR2 )
IS
BEGIN
   Error_SYS.Record_Not_Exist(lu_name_, 'ACCNOTEXIST: Account ":P1" does not exist in company ":P2"',account_,company_);
   super(company_, account_);
END Raise_Record_Not_Exist___;

PROCEDURE Validate_Insert_Modify___ (
   newrec_ IN ACCOUNTING_CODE_PART_VALUE_TAB%ROWTYPE,
   mode_   IN VARCHAR2,
   flag_   IN BOOLEAN DEFAULT FALSE,
   ex_proj_foll_changed_ IN BOOLEAN DEFAULT FALSE )
IS
   dummy_number_ NUMBER;
BEGIN   
   IF Accounting_Code_Parts_API.Is_Code_Used( newrec_.company, 'B') = 'FALSE' AND
   newrec_.req_code_b != 'S' THEN
         Error_Sys.Record_General(lu_name_,
                                  'CD_BLK: Code Part :P1 is Blocked',
                                  Accounting_Code_Parts_API.Get_Name(newrec_.company,'B'));
   END IF;
   IF Accounting_Code_Parts_API.Is_Code_Used( newrec_.company, 'C') = 'FALSE' AND
   newrec_.req_code_c != 'S' THEN
         Error_Sys.Record_General(lu_name_,
                                  'CD_BLK: Code Part :P1 is Blocked',
                                  Accounting_Code_Parts_API.Get_Name(newrec_.company,'C'));
   END IF;
   IF Accounting_Code_Parts_API.Is_Code_Used( newrec_.company, 'D') = 'FALSE' AND
   newrec_.req_code_d != 'S' THEN
         Error_Sys.Record_General(lu_name_,
                                  'CD_BLK: Code Part :P1 is Blocked',
                                  Accounting_Code_Parts_API.Get_Name(newrec_.company,'D'));
   END IF;
   IF Accounting_Code_Parts_API.Is_Code_Used( newrec_.company, 'E') = 'FALSE' AND
   newrec_.req_code_e != 'S' THEN
         Error_Sys.Record_General(lu_name_,
                                  'CD_BLK: Code Part :P1 is Blocked',
                                  Accounting_Code_Parts_API.Get_Name(newrec_.company,'E'));
   END IF;
   IF Accounting_Code_Parts_API.Is_Code_Used( newrec_.company, 'F') = 'FALSE' AND
   newrec_.req_code_f != 'S' THEN
         Error_Sys.Record_General(lu_name_,
                                  'CD_BLK: Code Part :P1 is Blocked',
                                  Accounting_Code_Parts_API.Get_Name(newrec_.company,'F'));
   END IF;
   IF Accounting_Code_Parts_API.Is_Code_Used( newrec_.company, 'G') = 'FALSE' AND
   newrec_.req_code_g != 'S' THEN
         Error_Sys.Record_General(lu_name_,
                                  'CD_BLK: Code Part :P1 is Blocked',
                                  Accounting_Code_Parts_API.Get_Name(newrec_.company,'G'));
   END IF;
   IF Accounting_Code_Parts_API.Is_Code_Used( newrec_.company, 'H') = 'FALSE' AND
   newrec_.req_code_h != 'S' THEN
         Error_Sys.Record_General(lu_name_,
                                  'CD_BLK: Code Part :P1 is Blocked',
                                  Accounting_Code_Parts_API.Get_Name(newrec_.company,'H'));
   END IF;
   IF Accounting_Code_Parts_API.Is_Code_Used( newrec_.company, 'I') = 'FALSE' AND
      newrec_.req_code_i != 'S' THEN
         Error_Sys.Record_General(lu_name_,
                                  'CD_BLK: Code Part :P1 is Blocked',
                                  Accounting_Code_Parts_API.Get_Name(newrec_.company,'I'));
   END IF;
   IF Accounting_Code_Parts_API.Is_Code_Used( newrec_.company, 'J') = 'FALSE' AND
      newrec_.req_code_j != 'S' THEN
         Error_Sys.Record_General(lu_name_,
                                  'CD_BLK: Code Part :P1 is Blocked',
                                  Accounting_Code_Parts_API.Get_Name(newrec_.company,'J'));
   END IF;

   IF (mode_ = 'INSERT') THEN
      
      Accounting_Code_Parts_API.Get_Max_Number_Of_Char( dummy_number_, newrec_.company, 'A');
      IF FINANCE_LIB_API.Fin_Length( newrec_.code_part_value) > dummy_number_ THEN
         Error_SYS.Record_General('Account', 'TOMANYSIGN: To many characters in account number');
      END IF;

      Check_Currency_Balance___( newrec_);
      Account_Type_API.Exist( newrec_.company, newrec_.accnt_type);
      Account_Group_API.Exist( newrec_.company, newrec_.accnt_group);
      IF newrec_.valid_from > newrec_.valid_until THEN
         Error_SYS.Record_General( 'Account', 'WRONGDATE: "To date" can not be lower than "From date"');
      END IF;
      Validate_Cons_Account___( newrec_);
   ELSE      -- mode_ = 'MODIFY'
      IF newrec_.valid_from > newrec_.valid_until THEN
         Error_SYS.Record_General( 'Account', 'WRONGDATE: "To date" can not be lower than "From date"');
      END IF;
      Validate_Ledg_Flag___( newrec_);
      Validate_Currency_Balance___( newrec_);
      Check_currency_Balance___( newrec_);
      Validate_Cons_Account___( newrec_);
      Validate_Tax_Account___( newrec_);
      Validate_Tax_Code___( newrec_);
      IF newrec_.bud_account ='Y' THEN
         Validate_Budget_Account___( newrec_ );
      END IF;
      IF (flag_) THEN
          Validate_Stat_Account___( newrec_ );
      END IF;
   END IF;
   Validate_Excl_Proj_Flwup___ ( newrec_, ex_proj_foll_changed_);   
   --SIZ-693 Begin
   IF (newrec_.exclude_periodical_cap != 'INCLUDE' AND newrec_.logical_account_type IN ('A', 'L', 'O')) THEN
      Error_SYS.Record_General( 'Account', 'WRONGPERCAPACTYPE: Only the accounts of type Revenue, Cost and Statistics can be excluded from Periodical Capitalization.');
   END IF;
   --SIZ-693 End
END Validate_Insert_Modify___;


PROCEDURE Check_Currency_Balance___ (
   rec_ IN ACCOUNTING_CODE_PART_VALUE_TAB%ROWTYPE )
IS
   code_part_using_function_  VARCHAR2(1);
   can_not_curr_bal           EXCEPTION;

   CURSOR get_curr IS
      SELECT code_part
      FROM   Accounting_code_part_tab
      WHERE  company = rec_.company
      AND    code_part_function   = 'CURR';

BEGIN
   IF ( rec_.curr_balance = 'Y' ) THEN
      OPEN get_curr;
      FETCH get_curr INTO code_part_using_function_;
      CLOSE get_curr;
      IF (code_part_using_function_ IS NOT NULL) THEN
         IF (code_part_using_function_ = 'B') THEN
            IF (rec_.req_code_b != 'S' ) THEN
               RAISE can_not_curr_bal;
            END IF;
         ELSIF (code_part_using_function_ = 'C') THEN
            IF (rec_.req_code_c != 'S' ) THEN
               RAISE can_not_curr_bal;
            END IF;
         ELSIF (code_part_using_function_ = 'D') THEN
            IF (rec_.req_code_d != 'S' ) THEN
               RAISE can_not_curr_bal;
            END IF;
         ELSIF (code_part_using_function_ = 'E') THEN
            IF (rec_.req_code_e != 'S' ) THEN
               RAISE can_not_curr_bal;
            END IF;
         ELSIF (code_part_using_function_ = 'F') THEN
            IF (rec_.req_code_f != 'S' ) THEN
               RAISE can_not_curr_bal;
            END IF;
         ELSIF (code_part_using_function_ = 'G') THEN
            IF (rec_.req_code_g != 'S' ) THEN
               RAISE can_not_curr_bal;
            END IF;
         ELSIF (code_part_using_function_ = 'H') THEN
            IF (rec_.req_code_h != 'S' ) THEN
               RAISE can_not_curr_bal;
            END IF;
         ELSIF (code_part_using_function_ = 'I') THEN
            IF (rec_.req_code_i != 'S' ) THEN
               RAISE can_not_curr_bal;
            END IF;
         ELSIF (code_part_using_function_ = 'J') THEN
            IF (rec_.req_code_j != 'S' ) THEN
               RAISE can_not_curr_bal;
            END IF;
         END IF;
      END IF;
   END IF;
EXCEPTION
   WHEN can_not_curr_bal THEN
      Error_SYS.Record_General('Account', 'FUNC_BLOCK: Currency balance flag can not be set if the codepart using currency balance is not blocked');
END Check_Currency_Balance___;


FUNCTION Check_Req___ (
   req_code_         IN VARCHAR2,
   account_ IN VARCHAR2 ) RETURN BOOLEAN
IS
BEGIN
   IF account_ IS NULL AND req_code_ = 'M' OR
      account_ IS NOT NULL AND req_code_ = 'S' THEN
      RETURN (TRUE);
   END IF;
   RETURN (FALSE);
END Check_Req___;


PROCEDURE Pre_Delete___ (
   rec_ IN ACCOUNTING_CODE_PART_VALUE_TAB%ROWTYPE )
IS
BEGIN
   Accounting_code_Part_Value_API.Check_Delete_Allowed ( rec_.company, 'A',
                                                         rec_.code_part_value );
END Pre_Delete___;


PROCEDURE Validate_Cons_Account___ (
   rec_ IN ACCOUNTING_CODE_PART_VALUE_TAB%ROWTYPE )
IS
   row_                      ACCOUNTING_CODE_PART_VALUE_TAB%ROWTYPE;
   cons_company_             VARCHAR2(20);
   no_cons_company           EXCEPTION;
   no_cons_accnt             EXCEPTION;
BEGIN
   cons_company_ := Company_Finance_API.Get_Cons_Company(rec_.company);
   IF (rec_.cons_accnt IS NOT NULL) THEN
      IF (cons_company_ IS NULL) THEN
         RAISE no_cons_company;
      END IF;
      row_ := Get_Object_By_Keys___( cons_company_,
                                     rec_.cons_accnt);
      IF (row_.company IS NULL) THEN
         RAISE no_cons_accnt;
      END IF;
   END IF;
EXCEPTION
   WHEN no_cons_company THEN
      Error_SYS.Record_General( 'Account',
                                'VAL_CONSCOMPANY: No Consolidation Company Exists for Company :P1',
                                rec_.company);
   WHEN no_cons_accnt THEN
      Error_SYS.Record_General( 'Account',
                                'VAL_CONSACCOUNT: This consolidation account is not in the consolidating companys plan of accounts');
END Validate_Cons_Account___;


PROCEDURE Validate_Currency_Balance___ (
   rec_ IN ACCOUNTING_CODE_PART_VALUE_TAB%ROWTYPE )
IS
   old_curr_balance_ VARCHAR2(20);
   already_exists_   VARCHAR2(5);

   CURSOR old_cur IS
      SELECT curr_balance
      FROM   accounting_code_part_value_tab
      WHERE  company = rec_.company
      AND    code_part = 'A'
      AND    code_part_value = rec_.code_part_value
      AND    NVL(bud_account,'N') = 'N';
BEGIN
   OPEN old_cur;
   FETCH old_cur INTO old_curr_balance_;
   CLOSE old_cur;

   IF (rec_.curr_balance != old_curr_balance_) THEN
      $IF Component_Genled_SYS.INSTALLED $THEN
         already_exists_ := Gen_Led_Voucher_Row_API.Account_Exist_In_Gl(rec_.company,
                                                                        rec_.code_part_value);
         IF (already_exists_ = 'TRUE') THEN
            Error_SYS.Record_General('Account', 'CURR_GL: You cannot change currency balance flag because the account is used in the General Ledger.');
         END IF;                                                                        
      $ELSE
         NULL;
      $END
      $IF Component_Intled_SYS.INSTALLED $THEN
         already_exists_ := Internal_Voucher_Row_API.Account_Exist_In_IL(rec_.company,
                                                                         rec_.code_part_value);
         IF (already_exists_ = 'TRUE') THEN
            Error_SYS.Record_General('Account', 'CURR_IL: You cannot change currency balance flag because the account is used in the Internal Ledger.');
         END IF;                                                                         
      $ELSE
         NULL;
      $END
   END IF;
END Validate_Currency_Balance___;


PROCEDURE Validate_Ledg_Flag___ (
   rec_ IN ACCOUNTING_CODE_PART_VALUE_TAB%ROWTYPE )
IS
   old_ledg_flag_ ACCOUNTING_CODE_PART_VALUE_TAB.ledg_flag%TYPE;
   result_        VARCHAR2(5);
   attr_          VARCHAR2(2000);
   CURSOR old_cur IS
      SELECT ledg_flag
      FROM   ACCOUNTING_CODE_PART_VALUE_TAB
      WHERE  company = rec_.company
      AND    code_part = 'A'
      AND    code_part_value = rec_.code_part_value
      AND    NVL(bud_account,'N') = 'N';

BEGIN
   OPEN old_cur;
   FETCH old_cur INTO old_ledg_flag_;
   CLOSE old_cur;
   IF (rec_.ledg_flag != old_ledg_flag_) THEN
      $IF Component_Genled_SYS.INSTALLED $THEN
         Client_SYS.Clear_Attr(attr_);
         Client_SYS.Add_To_Attr('COMPANY', rec_.company, attr_);
         Client_SYS.Add_To_Attr('ACCOUNT', rec_.code_part_value, attr_);
         Gen_Led_Voucher_Row_API.Postings_in_gl_voucher_row ( attr_ );
      $ELSE
         NULL;
      $END
      Voucher_Row_API.Postings_in_voucher_row (result_,
                                               rec_.company,
                                               rec_.code_part_value);
      IF (result_ = 'TRUE') THEN
         Error_SYS.Record_General('Account', 'POST_LED: You cannot change ledger flag if the account is used in the wait table');
      END IF;
   END IF;
END Validate_Ledg_Flag___;


PROCEDURE Validate_Budget_Account___ (
   rec_ IN ACCOUNTING_CODE_PART_VALUE_TAB%ROWTYPE )
IS
   attr_   VARCHAR2(2000);
BEGIN
   $IF Component_Genled_SYS.INSTALLED $THEN
      -- Check if account exist in Gen_Led_Voucher_Row
      Gen_Led_Voucher_Row_API.Account_Exist ( rec_.company,
                                              rec_.code_part_value );
      -- Check if account exist in Accounting_Balance
      Client_SYS.Clear_Attr(attr_);
      Client_SYS.Add_To_Attr('COMPANY', rec_.company, attr_);
      Client_SYS.Add_To_Attr('ACCOUNT', rec_.code_part_value, attr_);
      Accounting_Balance_API.Account_Exist ( attr_ );
      -- Check if account exist in Project_Balance
      Client_SYS.Clear_Attr(attr_);
      Client_SYS.Add_To_Attr('COMPANY', rec_.company, attr_);
      Client_SYS.Add_To_Attr('ACCOUNT', rec_.code_part_value, attr_);
      Accounting_Balance_API.Account_Exist ( attr_ );
   $END

-- Check if account exist in Holding Table
   Voucher_Row_API.Account_Exist(rec_.company,
                                 rec_.code_part_value);
-- Check if account exist in Posting_Ctrl and Posting_Ctrl_Detail
   Posting_Ctrl_API.Account_Exist(rec_.company,
                                  rec_.code_part_value);
   Posting_Ctrl_Detail_API.Account_Exist(rec_.company,
                                         rec_.code_part_value);
END Validate_Budget_Account___;


PROCEDURE Validate_Stat_Account___ (
   rec_ IN ACCOUNTING_CODE_PART_VALUE_TAB%ROWTYPE )
IS
   attr_   VARCHAR2(2000);

BEGIN
   $IF Component_Genled_SYS.INSTALLED $THEN
      -- Check if account exist in Gen_Led_Voucher_Row (Dynamic call)
      Gen_Led_Voucher_Row_API.Account_Exist ( rec_.company,
                                              rec_.code_part_value );
      -- Check if account exist in Accounting_Balance (Dynamic call)
      Client_SYS.Clear_Attr(attr_);
      Client_SYS.Add_To_Attr('COMPANY', rec_.company, attr_);
      Client_SYS.Add_To_Attr('ACCOUNT', rec_.code_part_value, attr_);
      Accounting_Balance_API.Account_Exist ( attr_ );
      -- Check if account exist in Project_Balance (Dynamic call)
      Client_SYS.Clear_Attr(attr_);
      Client_SYS.Add_To_Attr('COMPANY', rec_.company, attr_);
      Client_SYS.Add_To_Attr('ACCOUNT', rec_.code_part_value, attr_);
      Project_Balance_API.Account_Exist ( attr_ );
   $END

-- Check if account exist in Holding Table
   Voucher_Row_API.Account_Exist(rec_.company,
                                 rec_.code_part_value);
-- Check if account exist in Posting_Ctrl and Posting_Ctrl_Detail
   Posting_Ctrl_API.Account_Exist(rec_.company,
                                  rec_.code_part_value);
   Posting_Ctrl_Detail_API.Account_Exist(rec_.company,
                                         rec_.code_part_value);

   Posting_Ctrl_Comb_Detail_API.Account_Exist(rec_.company,
                                              rec_.code_part_value);
   Posting_Ctrl_Detail_Spec_API.Account_Exist(rec_.company,
                                              rec_.code_part_value);
   Posting_Ctrl_Comb_Det_Spec_API.Account_Exist(rec_.company,
                                                rec_.code_part_value);

END Validate_Stat_Account___;


FUNCTION Is_Ledger_Account___ (
   company_ IN VARCHAR2,
   account_ IN VARCHAR2 ) RETURN BOOLEAN
IS
   ledg_flag_    ACCOUNTING_CODE_PART_VALUE_TAB.ledg_flag%TYPE;
   CURSOR Check_Ledger_ IS
      SELECT ledg_flag
      FROM   ACCOUNTING_CODE_PART_VALUE_TAB
      WHERE  company = company_
      AND    code_part = 'A'
      AND    code_part_value = account_
      AND    NVL(bud_account,'N') = 'N';
BEGIN
   OPEN Check_Ledger_ ;
   FETCH Check_Ledger_ INTO ledg_flag_;
   CLOSE Check_Ledger_;
   IF (ledg_flag_ = 'Y') THEN
      RETURN TRUE;
   ELSE
      RETURN FALSE;
   END IF;
EXCEPTION WHEN no_data_found THEN
   Error_SYS.Record_Not_Exist(lu_name_);
END Is_Ledger_Account___;

PROCEDURE Get_Required_Code_Part___ (
   found_             OUT BOOLEAN,
   req_code_b_        OUT VARCHAR2,
   req_code_c_        OUT VARCHAR2,
   req_code_d_        OUT VARCHAR2,
   req_code_e_        OUT VARCHAR2,
   req_code_f_        OUT VARCHAR2,
   req_code_g_        OUT VARCHAR2,
   req_code_h_        OUT VARCHAR2,
   req_code_i_        OUT VARCHAR2,
   req_code_j_        OUT VARCHAR2,
   req_quantity_      OUT VARCHAR2,
   req_process_code_  OUT VARCHAR2,
   req_text_          OUT VARCHAR2,   
   company_           IN  VARCHAR2,
   accnt_             IN  VARCHAR2 ) IS
   --
   CURSOR get_req IS
      SELECT req_code_b,
             req_code_c,
             req_code_d,
             req_code_e,
             req_code_f,
             req_code_g,
             req_code_h,
             req_code_i,
             req_code_j,
             req_quantity,
             req_process_code,
             req_text             
      FROM   accounting_code_part_value_tab
      WHERE  company = company_
      AND    code_part = 'A'
      AND    code_part_value = accnt_;   
BEGIN   
   OPEN get_req;
   FETCH get_req INTO req_code_b_,
                      req_code_c_,
                      req_code_d_,
                      req_code_e_,
                      req_code_f_,
                      req_code_g_,
                      req_code_h_,
                      req_code_i_,
                      req_code_j_,
                      req_quantity_,
                      req_process_code_,                      
                      req_text_;
   IF (get_req%NOTFOUND) THEN
      found_ := FALSE;
   ELSE
      found_ := TRUE;
   END IF;
   CLOSE get_req;
END Get_Required_Code_Part___;


FUNCTION Get_Required_Code_Part___ (
   company_ IN VARCHAR2,
   accnt_ IN VARCHAR2 ) RETURN VARCHAR2
IS
   found_            BOOLEAN;
   req_b_            VARCHAR2(1);
   req_c_            VARCHAR2(1);
   req_d_            VARCHAR2(1);
   req_e_            VARCHAR2(1);
   req_f_            VARCHAR2(1);
   req_g_            VARCHAR2(1);
   req_h_            VARCHAR2(1);
   req_i_            VARCHAR2(1);
   req_j_            VARCHAR2(1);
   req_quantity_     VARCHAR2(1);
   req_process_code_ VARCHAR2(1);
   req_text_         VARCHAR2(1);
   req_attr_         VARCHAR2(2000);
BEGIN
   Get_Required_Code_Part___(found_,
                             req_b_,
                             req_c_,
                             req_d_,
                             req_e_,
                             req_f_,
                             req_g_,
                             req_h_,
                             req_i_,
                             req_j_,
                             req_quantity_,                             
                             req_process_code_,
                             req_text_,
                             company_,
                             accnt_);
   Client_SYS.Clear_Attr(req_attr_);
   Client_SYS.Add_To_Attr('CODE_B', req_b_, req_attr_);
   Client_SYS.Add_To_Attr('CODE_C', req_c_, req_attr_);
   Client_SYS.Add_To_Attr('CODE_D', req_d_, req_attr_);
   Client_SYS.Add_To_Attr('CODE_E', req_e_, req_attr_);
   Client_SYS.Add_To_Attr('CODE_F', req_f_, req_attr_);
   Client_SYS.Add_To_Attr('CODE_G', req_g_, req_attr_);
   Client_SYS.Add_To_Attr('CODE_H', req_h_, req_attr_);
   Client_SYS.Add_To_Attr('CODE_I', req_i_, req_attr_);
   Client_SYS.Add_To_Attr('CODE_J', req_j_, req_attr_);
   Client_SYS.Add_To_Attr('QUANTITY', req_quantity_, req_attr_);
   Client_SYS.Add_To_Attr('PROCESS_CODE', req_process_code_, req_attr_);
   Client_SYS.Add_To_Attr('TEXT', req_text_, req_attr_);   
   RETURN(req_attr_);
END Get_Required_Code_Part___;


PROCEDURE Validate_Tax_Account___ (
   rec_ IN ACCOUNTING_CODE_PART_VALUE_TAB%ROWTYPE )
IS
   old_tax_flag_  ACCOUNTING_CODE_PART_VALUE_TAB.tax_flag%TYPE;
   result_        VARCHAR2(5);
   attr_          VARCHAR2(2000);
   CURSOR old_cur IS
      SELECT tax_flag
      FROM   ACCOUNTING_CODE_PART_VALUE_TAB
      WHERE  company = rec_.company
      AND    code_part = 'A'
      AND    code_part_value = rec_.code_part_value
      AND    NVL(bud_account,'N') = 'N';
BEGIN
   OPEN old_cur;
   FETCH old_cur INTO old_tax_flag_;
   CLOSE old_cur;
   IF (rec_.tax_flag != old_tax_flag_) THEN
      $IF Component_Genled_SYS.INSTALLED $THEN
         Client_SYS.Clear_Attr(attr_);
         Client_SYS.Add_To_Attr('COMPANY', rec_.company, attr_);
         Client_SYS.Add_To_Attr('ACCOUNT', rec_.code_part_value, attr_);
         Gen_Led_Voucher_Row_API.Postings_in_gl_voucher_row ( attr_ );
      $ELSE
         NULL;
      $END
      Voucher_Row_API.Postings_in_voucher_row (result_,
                                               rec_.company,
                                               rec_.code_part_value);
      IF (result_ = 'TRUE') THEN
         Error_SYS.Record_General('Account', 'POST_TAX: You cannot change tax account flag if the account is used in the wait table');
      END IF;
   END IF;
END Validate_Tax_Account___;


PROCEDURE Validate_Tax_Code___ (
   rec_ IN ACCOUNTING_CODE_PART_VALUE_TAB%ROWTYPE )
IS
   old_tax_handling_value_ ACCOUNTING_CODE_PART_VALUE_TAB.tax_handling_value%TYPE;
   dummy_                  NUMBER;
   CURSOR old_cur IS
      SELECT tax_handling_value
      FROM   ACCOUNTING_CODE_PART_VALUE_TAB
      WHERE  company         = rec_.company
      AND    code_part       = 'A'
      AND    code_part_value = rec_.code_part_value;
   CURSOR get_tax_code IS
      SELECT COUNT(*)
      FROM   Account_Tax_Code
      WHERE  company  = rec_.company
      AND    account  = rec_.code_part_value;
BEGIN
   OPEN old_cur;
   FETCH old_cur INTO old_tax_handling_value_;
   CLOSE old_cur;
   IF (rec_.tax_handling_value != old_tax_handling_value_) THEN
      OPEN get_tax_code;
      FETCH get_tax_code INTO dummy_;
      IF (rec_.tax_handling_value IN ('BLOCKED')) AND (dummy_ != 0) THEN
         CLOSE get_tax_code;
         Error_SYS.Record_General('Account', 'TAXCODEEXIST: You are not allowed to set Tax Handling to :P1 since there are Tax Codes connected to the account.', Tax_Handling_Value_API.Decode(rec_.tax_handling_value));
      ELSIF (rec_.tax_handling_value IN ('ALL')) AND (dummy_ > 1) THEN
         CLOSE get_tax_code;
         Error_SYS.Record_General('Account', 'TAXCODETOMANY: You are not allowed to set Tax Handling to :P1 since there are more then one Tax Code connected to the account.', Tax_Handling_Value_API.Decode(rec_.tax_handling_value));
      END IF;
      CLOSE get_tax_code;
   END IF;
END Validate_Tax_Code___;


PROCEDURE Update_Code_Part_Demands___ (
   newrec_ IN ACCOUNTING_CODE_PART_VALUE_TAB%ROWTYPE )
IS
   objid_       ACCOUNT.objid%TYPE;
   CURSOR get_objid IS
      SELECT rowid
      FROM   ACCOUNTING_CODE_PART_VALUE_TAB
      WHERE  company = newrec_.company
      AND    code_part = 'A'
      AND    accnt_type = newrec_.accnt_type
      AND    NVL(bud_account, 'N') = 'N';
BEGIN
   OPEN get_objid;
   LOOP
      FETCH get_objid INTO objid_;
      EXIT WHEN get_objid%NOTFOUND;
      UPDATE accounting_code_part_value_tab
         SET req_code_b = newrec_.req_code_b,
             req_code_c = newrec_.req_code_c,
             req_code_d = newrec_.req_code_d,
             req_code_e = newrec_.req_code_e,
             req_code_f = newrec_.req_code_f,
             req_code_g = newrec_.req_code_g,
             req_code_h = newrec_.req_code_h,
             req_code_i = newrec_.req_code_i,
             req_code_j = newrec_.req_code_j,
             req_quantity = newrec_.req_quantity,
             req_process_code = newrec_.req_process_code,
             req_text = newrec_.req_text,
             req_budget_code_b = newrec_.req_budget_code_b,
             req_budget_code_c = newrec_.req_budget_code_c,
             req_budget_code_d = newrec_.req_budget_code_d,
             req_budget_code_e = newrec_.req_budget_code_e,
             req_budget_code_f = newrec_.req_budget_code_f,
             req_budget_code_g = newrec_.req_budget_code_g,
             req_budget_code_h = newrec_.req_budget_code_h,
             req_budget_code_i = newrec_.req_budget_code_i,
             req_budget_code_j = newrec_.req_budget_code_j,
             req_budget_quantity = newrec_.req_budget_quantity
         WHERE rowid = objid_;
   END LOOP;
   CLOSE get_objid;
END Update_Code_Part_Demands___;

  
@Override
PROCEDURE Import_Assign___ (
   newrec_      IN OUT accounting_code_part_value_tab%ROWTYPE,
   crecomp_rec_ IN     Enterp_Comp_Connect_V170_API.Crecomp_Lu_Public_Rec,
   pub_rec_     IN     Create_Company_Template_Pub%ROWTYPE )
IS
BEGIN
   super(newrec_, crecomp_rec_, pub_rec_);
   newrec_.code_part    := 'A';
   newrec_.valid_from   := crecomp_rec_.valid_from;
   newrec_.cons_accnt   := null;
   -- In case description is missing in template due to use of old template.
   IF ( newrec_.description IS NULL ) THEN
      newrec_.description := newrec_.code_part_value;
   END IF;
END Import_Assign___;


@Override
PROCEDURE Copy_Assign___ (
   newrec_      IN OUT accounting_code_part_value_tab%ROWTYPE,
   crecomp_rec_ IN     Enterp_Comp_Connect_V170_API.Crecomp_Lu_Public_Rec,
   oldrec_      IN     accounting_code_part_value_tab%ROWTYPE )
IS
BEGIN
   super(newrec_, crecomp_rec_, oldrec_);
   newrec_.cons_accnt   := null;
END Copy_Assign___;

   
PROCEDURE Check_Delete_Cons_Accnt___ (
   company_  IN  VARCHAR2,
   account_  IN  VARCHAR2 )
IS
   mapped_company_  VARCHAR2(20);
   mapped_account_  VARCHAR2(20);

   CURSOR check_cons_account IS
      SELECT a.account, a.company
      FROM  account a, 
            company_finance c
      WHERE a.company       = c.company
      AND   c.cons_company  = company_
      AND   a.cons_accnt    = account_ ;
BEGIN
   OPEN check_cons_account;
   FETCH check_cons_account  INTO mapped_account_,mapped_company_ ;
   IF (check_cons_account%FOUND) THEN
      CLOSE check_cons_account;
      Error_SYS.Record_General(lu_name_, 'USDINCON: This Account is linked to Account :P1 in Subsidiary Company :P2',mapped_account_ ,mapped_company_);
   ELSE
      CLOSE check_cons_account;
   END IF;
END Check_Delete_Cons_Accnt___;


PROCEDURE Validate_Excl_Proj_Flwup___ (
   newrec_                 IN ACCOUNTING_CODE_PART_VALUE_TAB%ROWTYPE,
   ex_proj_foll_changed_   IN BOOLEAN )
IS
   project_cost_element_ VARCHAR2(100);
BEGIN
   IF (NVL(newrec_.exclude_proj_followup, 'FALSE')='TRUE') THEN
      --check for project cost elements exist
      project_cost_element_ := Cost_Element_To_Account_API.Get_Account_Cost_Element(newrec_.company, newrec_.code_part_value);
      IF (project_cost_element_ IS NOT NULL) THEN
         Error_Sys.Record_General( lu_name_, 'COSTELECONN: Account :P1 is connected to project cost/revenue element :P2 and cannot be set as Exclude Project Follow-Up.', newrec_.code_part_value, project_cost_element_, NULL);
      END IF;

      --check for project elements exist in secondary mapping
      project_cost_element_ := Cost_Ele_To_Accnt_Secmap_API.Get_Account_Element(newrec_.company, newrec_.code_part_value);
      IF (project_cost_element_ IS NOT NULL) THEN
         Error_Sys.Record_General( lu_name_, 'SECMAPCOSTELECONN: Account :P1 is connected to project cost/revenue element :P2 in the secondary mapping and cannot be set as Exclude Project Follow-Up.', newrec_.code_part_value, project_cost_element_, NULL);
      END IF;

      --Allow only on the accounts with "Logical Account Type" ASSET or LIABILITY
      IF (newrec_.logical_account_type NOT IN ('A', 'L', 'O')) THEN
         Error_Sys.Record_General( lu_name_, 'NOTASSETLIAB: Exclude project followup is only allowed for accounts of logical account type Assets, Liabilities or Statistics, Opening Balance.');
      END IF;
   END IF;
   
   IF (ex_proj_foll_changed_ = TRUE ) THEN
      --check for posting transactions exist in mpccom
      $IF Component_Mpccom_SYS.INSTALLED $THEN
         IF (MPCCOM_ACCOUNTING_API.All_Postings_Transferred_Acc(newrec_.company,newrec_.code_part_value) = 'FALSE') THEN
            Error_SYS.Record_General(lu_name_,'TRANSEXIST: There are transactions with account :P1, waiting to be transferred from Distribution and/or Manufacturing. All transactions for account :P1 that are not in status error need to be transferred to GL before changing the value for Exclude Project Follow Up.', newrec_.code_part_value);
         END IF;
      $END
   
      --check there are any transactions in voucher row table
      IF (Voucher_Row_API.All_Postings_Transferred_Acc(newrec_.company, newrec_.code_part_value) = 'FALSE') THEN
         Error_SYS.Record_General(lu_name_,'VOUCHERROWEXIST: There are transactions with account :P1, in voucher hold table.', newrec_.code_part_value);
      END IF;
   END IF;
END Validate_Excl_Proj_Flwup___;

@Override
@SecurityCheck Company.UserExist(newrec_.company)
PROCEDURE Check_Common___ (
   oldrec_ IN     accounting_code_part_value_tab%ROWTYPE,
   newrec_ IN OUT accounting_code_part_value_tab%ROWTYPE,
   indrec_ IN OUT Indicator_Rec,
   attr_   IN OUT VARCHAR2 )
IS
BEGIN   
   IF (INSTR( newrec_.code_part_value,'&') >0) THEN
     Error_SYS.Record_General(lu_name_, 'INVCHARACTORS: You have entered an invalid character in this field');
   END IF;
   newrec_.code_part := 'A';
   newrec_.rowtype := 'Account';
   super(oldrec_, newrec_, indrec_, attr_);
   
   newrec_.accounting_text_id := Client_SYS.Attr_Value_To_Number(newrec_.accounting_text_id);
  
   IF (newrec_.cons_accnt IS NOT NULL) THEN
      Account_API.Validate_Cons_Account___(newrec_);
   END IF;   
   
   IF (indrec_.ledg_flag) THEN
      IF NOT(newrec_.ledg_flag ='Y' OR newrec_.ledg_flag ='N') THEN
         Error_SYS.Record_General(lu_name_, 'LEDGFLAGNOTALLOWED: Ledger Balance can be only "Y" or "N" ');
      END IF;
   END IF;
   IF (indrec_.curr_balance) THEN
      IF (newrec_.curr_balance IS NOT NULL) THEN
         IF NOT(newrec_.curr_balance ='Y' OR newrec_.curr_balance ='N') THEN
            Error_SYS.Record_General(lu_name_, 'CURRBALNOTALLOWED: Currency Balance can be only "Y" or "N" ');
         END IF;
      END IF;
      $IF Component_Fixass_SYS.INSTALLED $THEN
          IF (newrec_.curr_balance ='Y') THEN    
               IF (Acquisition_Account_API.Is_Acquisition_Account(newrec_.company, newrec_.CODE_PART_VALUE) = true) THEN
                  Error_SYS.Record_General(lu_name_, 'ACCRULCODEACURRBA1: Account is already used as an Acquisition Account in Fixed Assets. Cannot use for Currency Balance');
               END IF;            
            END IF;
     $END
   END IF;
   
   IF (indrec_.bud_account) THEN
      IF NOT(newrec_.bud_account ='Y' OR newrec_.bud_account ='N') THEN
         Error_SYS.Record_General(lu_name_, 'BUDNOTALLOWED: Budget Account can be only "Y" or "N" ');
      END IF;
   END IF;
   
   IF (indrec_.stat_account) THEN      
      IF NOT(newrec_.stat_account ='Y' OR newrec_.stat_account ='N') THEN
         Error_SYS.Record_General(lu_name_, 'STATNOTALLOWED: Statistical Account can be only "Y" or "N" ');
      END IF;
   END IF;
   
   IF (indrec_.tax_flag) THEN
      IF NOT(newrec_.tax_flag ='Y' OR newrec_.tax_flag ='N') THEN
         Error_SYS.Record_General(lu_name_, 'TAXFLAGNOTALLOWED: Tax Account can be only "Y" or "N" ');
      END IF;
   END IF;
   
   IF (newrec_.curr_balance = 'Y') THEN
      IF NOT (Accounting_Code_Parts_API.Code_Part_Function_Used( newrec_.company, 'CURR')) THEN 
         Error_SYS.Appl_General(lu_name_, 'CURR_BAL_FUNC_NOT_USED: The Currency Balance check box cannot be selected since no code part is connected to Currency Balance code part function in the Define Code String window.');
      END IF;
   END IF;

   IF (newrec_.bud_account ='Y') THEN
      IF ( newrec_.ledg_flag ='Y'  OR
         newrec_.curr_balance ='Y') THEN
         Error_Sys.Record_General( lu_name_, 'NOTALLOWEDBOTH: The account cannot be a ledger account or have a currency balance.');
      END IF;
   END IF;
   IF (newrec_.stat_account ='Y') THEN
      IF ( newrec_.ledg_flag ='Y') THEN
         Error_Sys.Record_General( lu_name_, 'NOTALLOWEDBOTH1: The account cannot be a ledger account.');
      END IF;
      IF (newrec_.logical_account_type NOT IN ('S', 'O')) THEN
         Error_Sys.Record_General( lu_name_, 'NOTASTAT: The account is not a Statistic Account.');
      END IF;
   END IF;
   IF (newrec_.exclude_from_curr_trans IS NULL) THEN
      newrec_.exclude_from_curr_trans := 'FALSE';
   END IF;
   IF (newrec_.keep_rep_currency IS NULL) THEN
      newrec_.keep_rep_currency := 'FALSE';
   END IF;
   IF (newrec_.keep_reporting_entity IS NULL) THEN
      newrec_.keep_reporting_entity := 'FALSE';
   END IF;
END Check_Common___;


@Overtake Base
FUNCTION Check_Exist___ (
   company_ IN VARCHAR2,
   account_ IN VARCHAR2 ) RETURN BOOLEAN
IS
   dummy_ NUMBER;
   CURSOR exist_control IS
      SELECT 1
      FROM   ACCOUNTING_CODE_PART_VALUE_TAB
      WHERE  company = company_      
      AND   code_part = 'A'
      AND   code_part_value = account_
      AND    NVL(bud_account,'N') = 'N';
BEGIN
   OPEN exist_control;
   FETCH exist_control INTO dummy_;
   IF (exist_control%FOUND) THEN
      CLOSE exist_control;
      RETURN(TRUE);
   END IF;
   CLOSE exist_control;
   RETURN(FALSE);
END Check_Exist___;


@Override
PROCEDURE Prepare_Insert___ (
   attr_ IN OUT VARCHAR2 )
IS
   company_             ACCOUNTING_CODE_PART_VALUE_TAB.company%TYPE;
   codepart_blocked_    ACCOUNT_CODE_A.req_code_b%TYPE;
   valid_until_         Accrul_Attribute_Tab.attribute_value%TYPE;
   accnt_type_          ACCOUNTING_CODE_PART_VALUE_TAB.accnt_type%TYPE;
BEGIN
   company_ := Client_SYS.Get_Item_Value( 'COMPANY', attr_ );
   codepart_blocked_ := Account_Request_API.Decode('S');
   valid_until_      := Accrul_Attribute_API.Get_Attribute_Value('DEFAULT_VALID_TO');
   accnt_type_       := Client_SYS.Get_Item_Value( 'ACCNT_TYPE', attr_ );
   super(attr_);
   Client_SYS.Add_To_Attr('VALID_FROM',   sysdate, attr_);
   Client_SYS.Add_To_Attr('VALID_UNTIL',  to_date(valid_until_,'YYYYMMDD'), attr_);
   Client_SYS.Add_To_Attr('LEDG_FLAG',    Accounting_Ledg_Flag_API.Decode('N'), attr_);
   Client_SYS.Add_To_Attr('CURR_BALANCE', Acc_Currency_Balance_Flag_API.Decode('N'), attr_);
   Client_SYS.Add_To_Attr('BUD_ACCOUNT',  Budget_Account_Flag_API.Decode('N'), attr_);
   Client_SYS.Add_To_Attr('STAT_ACCOUNT', Exclude_Stat_Account_API.Decode('N'), attr_);
   Client_SYS.Add_To_Attr('LEDG_FLAG_DB',    'N', attr_);
   Client_SYS.Add_To_Attr('CURR_BALANCE_DB', 'N', attr_);
   Client_SYS.Add_To_Attr('BUD_ACCOUNT_DB',  'N', attr_);
   Client_SYS.Add_To_Attr('STAT_ACCOUNT_DB', 'N', attr_);
   Client_SYS.Add_To_Attr('CONS_COMPANY', Company_Finance_API.Get_Cons_Company( company_ ), attr_ );
   Client_SYS.Add_To_Attr('ARCHIVING_TRANS_VALUE', Archiving_Trans_Value_API.Decode('FALSE') ,attr_ );
   
   Prepare_Codepart_Demands(attr_, company_, accnt_type_);

   Client_SYS.Add_To_Attr('TAX_HANDLING_VALUE', Tax_Handling_Value_API.Decode('ALL'), attr_);
   Client_SYS.Add_To_Attr('TAX_FLAG',           Tax_Account_Flag_API.Decode('N'), attr_);
   Client_SYS.Add_To_Attr('TAX_FLAG_DB',        'N', attr_);
   Client_SYS.Add_To_Attr('TAX_CODE_MANDATORY', 'FALSE', attr_);   
   Client_SYS.Add_To_Attr('EXCLUDE_PROJ_FOLLOWUP', 'FALSE', attr_);   
   Client_SYS.Add_To_Attr('EXCLUDE_PERIODICAL_CAP', Exclude_Periodical_Cap_API.Decode('INCLUDE'), attr_);

END Prepare_Insert___;

@Override
PROCEDURE Check_Delete___ (
   remrec_ IN ACCOUNTING_CODE_PART_VALUE_TAB%ROWTYPE )
IS
   key_str_   VARCHAR2(2000);
   attr_      VARCHAR2(2000);
   result_    VARCHAR2(5);
BEGIN
   Voucher_Row_API.Postings_In_Voucher_Row(result_,remrec_.company,remrec_.code_part_value);
   IF ( result_ = 'TRUE' ) THEN
      Error_Sys.Record_General( lu_name_,'NOTALLOWEDDELETE: You cannot delete the account since it is used in the wait table.');
   END IF;
   IF (Posting_Ctrl_API.Code_Part_Exist(remrec_.company,'A',remrec_.code_part_value)) THEN
      Error_SYS.Record_General( lu_name_, 'EXISTINCTRL: The code part value :P1 exist in posting control', remrec_.code_part_value);
   END IF;
   IF NOT Accounting_Codestr_Compl_API.Check_Delete_Allowed_( remrec_.company, remrec_.code_part_value, 'A') THEN
      Error_SYS.Record_General('Account','EXISTINCOMPL: The code part value :P1 exist in codestring completion', remrec_.code_part_value);
   END IF;
   $IF Component_Genled_SYS.INSTALLED $THEN
      Client_SYS.Clear_Attr(attr_);
      Client_SYS.Add_To_Attr('COMPANY', remrec_.company, attr_);
      Client_SYS.Add_To_Attr('ACCOUNT', remrec_.code_part_value, attr_);
      Gen_Led_Voucher_Row_API.Postings_in_gl_voucher_row ( attr_ );
      Budget_Year_Amount_API.Exist_Code_Part_Value ( remrec_.company,
                                                     'A',
                                                     remrec_.code_part_value );
      Budget_Period_Amount_API.Exist_Code_Part_Value ( remrec_.company,
                                                       'A',
                                                       remrec_.code_part_value );
   $END
      
   $IF Component_Intled_SYS.INSTALLED $THEN
      IF (Internal_Hold_Voucher_Row_Api.Account_Exist_In_IL_Hold(remrec_.company, remrec_.code_part_value ) = 'TRUE') THEN
         Error_Sys.Record_General( lu_name_,'NOTALLOWEDDELETE: You cannot delete the account since it is used in the wait table.');
      END IF;

      Internal_Voucher_Row_Api.Is_Code_Part_Value_Used(remrec_.company, remrec_.code_part, remrec_.code_part_value);
   $END

   -- Check if account is used in secondary mapping
   IF (Cost_Ele_To_Accnt_Secmap_API.Get_Account_Element(remrec_.company, remrec_.code_part_value) IS NOT NULL) THEN
      Error_SYS.Record_General(lu_name_, 'SECMAPACCOUNTUSED: It is not possible to delete Account :P1 as it has been used in the Secondary Cost/Revenue Element mapping.', remrec_.code_part_value);
   END IF;

   Check_Delete_Cons_Accnt___( remrec_.company,
                               remrec_.code_part_value );
   Pre_Delete___(remrec_);

   key_str_ := remrec_.company || '^' || 'A' || '^' || remrec_.code_part_value || '^';
   super(remrec_);
   Reference_SYS.Check_Restricted_Delete('AccountingCodePartValue', key_str_);

END Check_Delete___;


@Override
PROCEDURE Delete___ (
   objid_  IN VARCHAR2,
   remrec_ IN ACCOUNTING_CODE_PART_VALUE_TAB%ROWTYPE )
IS
BEGIN
   super(objid_, remrec_);
   -- Remove Structure items
   $IF Component_Genled_SYS.INSTALLED $THEN
      Accounting_Structure_Item_API.Remove_Structure_Items(remrec_.company, remrec_.code_part, remrec_.code_part_value);
   $END
END Delete___;


@Override
PROCEDURE Check_Insert___ (
   newrec_ IN OUT accounting_code_part_value_tab%ROWTYPE,
   indrec_ IN OUT Indicator_Rec,
   attr_   IN OUT VARCHAR2 )
IS
BEGIN   
   --The following IF statement was added so that any calls made by the ACCOUNTING_CODE_PART_A
   --LU will also be handled. This statement should be removed when the LU ACCOUNTING_CODE_PART_A
   --is removed.
   IF (Client_SYS.Item_Exist('CODE_PART_VALUE', attr_)) THEN
      newrec_.code_part_value := Client_SYS.Get_Item_Value('CODE_PART_VALUE', attr_);
   END IF;
   
   IF newrec_.logical_account_type IS NULL THEN
      newrec_.logical_account_type := Account_Type_Value_API.Encode(ACCOUNT_TYPE_API.Get_Logical_Account_Type(newrec_.company, newrec_.accnt_type));
   END IF;
   
   IF newrec_.exclude_periodical_cap IS NULL THEN
      newrec_.exclude_periodical_cap := 'INCLUDE';
      Client_SYS.Add_To_Attr('EXCLUDE_PERIODICAL_CAP', Exclude_Periodical_Cap_API.Decode('INCLUDE'), attr_);
   END IF;
   
   super(newrec_, indrec_, attr_);
      
   Account_Type_API.Logical_Account_Exist_Db(newrec_.company, newrec_.accnt_type, newrec_.logical_account_type);

   newrec_.sort_value := ACCOUNTING_CODE_PART_VALUE_API.Generate_Sort_Value(newrec_.code_part_value);
    
   Validate_Insert_Modify___(newrec_, 'INSERT');
   
END Check_Insert___;


@Override
PROCEDURE Check_Update___ (
   oldrec_ IN     accounting_code_part_value_tab%ROWTYPE,
   newrec_ IN OUT accounting_code_part_value_tab%ROWTYPE,
   indrec_ IN OUT Indicator_Rec,
   attr_   IN OUT VARCHAR2 )
IS   
   is_value_used_            VARCHAR2(5);
   flag_                     BOOLEAN := FALSE; 
   ex_proj_foll_changed_     BOOLEAN := FALSE;   
BEGIN
   IF (Client_SYS.Item_Exist('CODE_PART_VALUE', attr_)) THEN
      Error_SYS.Item_Update(lu_name_, 'CODE_PART_VALUE');
   END IF;  
   
   -- skip validation for LOGICAL_ACCOUNT_TYPE
   indrec_.logical_account_type := FALSE;
   
   IF ((Client_SYS.Item_Exist('NO_ARCHIVING_TRANS_DB', attr_))
   OR (Client_SYS.Item_Exist('NO_ARCHIVING_TRANS', attr_))) THEN
      newrec_.no_archiving_trans := Client_SYS.Cut_Item_Value('NO_ARCHIVING_TRANS_DB', attr_);
   END IF;  
   
   super(oldrec_, newrec_, indrec_, attr_);
      
   IF (indrec_.accnt_type) THEN
      newrec_.logical_account_type := Account_Type_Value_API.Encode(ACCOUNT_TYPE_API.Get_Logical_Account_Type(newrec_.company, newrec_.accnt_type));
   END IF;
   
   IF (indrec_.logical_account_type) THEN
      Account_Type_API.Logical_Account_Exist (newrec_.company,
                                              newrec_.accnt_type, 
                                              newrec_.logical_account_type);
   END IF;
   
   -- Bug 121544, Begin, allowing the flag_ to be TRUE only if the newrec_.stat_account value is not equal to the oldrec_.stat_account value
   IF (indrec_.stat_account) THEN
      IF (newrec_.stat_account IS NOT NULL) THEN
         IF (newrec_.stat_account != oldrec_.stat_account)THEN
            Validate_Stat_Account___( newrec_ );
            flag_ := TRUE;
         END IF;
      END IF;       
   END IF;
   -- Bug 121544, End.
   
   -- Check if the logical account type has changed
   IF (newrec_.logical_account_type != oldrec_.logical_account_type) THEN
      -- Check if code part value has been used in hold table
      is_value_used_ := Voucher_Row_API.Is_Code_Part_Value_Used(newrec_.company, 'A', newrec_.code_part_value);
      IF (is_value_used_ = 'TRUE')THEN
         Error_SYS.Record_General(lu_name_, 'USEDINVOUROW: Code part value :P1 is used by transcations in hold table',newrec_.code_part_value );
      END IF;
      $IF Component_Genled_SYS.INSTALLED $THEN
         -- Check if code part value has been used in general ledger
         Gen_Led_Voucher_Row_API.Is_Code_Part_Value_Used(newrec_.company,
                                                         'A',
                                                         newrec_.code_part_value);
      $END
   END IF;
   
   IF (newrec_.ledg_flag = 'N' ) THEN 
      IF ((Posting_Ctrl_Detail_API.Is_Led_Account_Used(newrec_.company ,newrec_.code_part_value) = 'TRUE') OR
          (Posting_Ctrl_API.Is_Led_Account_Used(newrec_.company ,newrec_.code_part_value) = 'TRUE') OR
          (Posting_Ctrl_Comb_Detail_API.Is_Led_Account_Used(newrec_.company ,newrec_.code_part_value) = 'TRUE')) THEN
         Error_SYS.Record_General(lu_name_, 'LEDGCHGNOTALLOWED: The account is currently used by a posting type in Posting Control which requires a Ledger Account.');
      END IF;
   END IF;
   
   IF (newrec_.tax_flag = 'N' ) THEN 
      IF ((Posting_Ctrl_Detail_API.Is_Tax_Account_Used(newrec_.company ,newrec_.code_part_value) = 'TRUE') OR
          (Posting_Ctrl_API.Is_Tax_Account_Used(newrec_.company ,newrec_.code_part_value) = 'TRUE') OR
          (Posting_Ctrl_Comb_Detail_API.Is_Tax_Account_Used(newrec_.company ,newrec_.code_part_value) = 'TRUE')) THEN
         Error_SYS.Record_General(lu_name_, 'TAXACCNOTALLOWED: The account is currently used by a posting type in Posting Control which requires a Tax Account.');
      END IF;
   END IF;   
   
   IF (nvl(oldrec_.exclude_proj_followup, 'FALSE') != nvl(newrec_.exclude_proj_followup, 'FALSE')) THEN
      ex_proj_foll_changed_ := TRUE;
   END IF;
   
   Validate_Insert_Modify___(newrec_, 'MODIFY', flag_, ex_proj_foll_changed_);   

END Check_Update___;


-------------------- LU SPECIFIC PRIVATE METHODS ----------------------------

PROCEDURE Validate_Account__ (
   company_                 IN     VARCHAR2,
   account_                 IN     VARCHAR2,
   voucher_date_            IN     DATE,
   req_string_              OUT    VARCHAR2,
   req_string_complete_     IN OUT VARCHAR2,
   ledger_accnt_            OUT    NUMBER )
IS
BEGIN
   Exist(company_, account_);
   Get_Required_Code_Part(req_string_, company_, account_);
   Accounting_Codestr_API.Complete_Codestring(req_string_complete_, company_, NULL, voucher_date_, 'A');
   IF (NOT ACCOUNT_API.Validate_Accnt(company_, account_, voucher_date_ )) THEN
      Error_SYS.Record_General('Account','ACCNT_NOT_VALID: Account number :P1 not valid for date interval',account_);
   END IF;
   IF (ACCOUNT_API.Is_Ledger_Account(company_, account_)) THEN
      ledger_accnt_ := 1;
   ELSE
      ledger_accnt_ := 0;
   END IF;
END Validate_Account__;


PROCEDURE Validate_Account_Pseudo__ (
   company_                 IN     VARCHAR2,
   account_                 IN     VARCHAR2,
   voucher_date_            IN     DATE,
   req_string_              OUT    VARCHAR2,
   req_string_complete_     IN OUT VARCHAR2,
   client_user_             IN VARCHAR2 DEFAULT NULL )
IS
BEGIN
   Exist_Account_And_Pseudo(company_, account_);
   Get_Required_Code_Part_Pseudo(req_string_,  company_, account_);
   IF Pseudo_Codes_Api.Exist_Pseudo(company_, account_) THEN
      Pseudo_Codes_API.Get_Complete_Pseudo(req_string_complete_, company_, account_,client_user_);
   ELSE
      Accounting_Codestr_API.Complete_Codestring(req_string_complete_, company_, NULL, voucher_date_, 'A');
   END IF;
END Validate_Account_Pseudo__;


-------------------- LU SPECIFIC PROTECTED METHODS --------------------------

PROCEDURE Validate_Req_Code_Part_ (
   company_          IN VARCHAR2,
   account_          IN VARCHAR2,
   req_code_part_    IN VARCHAR2,
   code_part_value_  IN VARCHAR2 )
IS
   req_code_b_       VARCHAR2(1);
   req_code_c_       VARCHAR2(1);
   req_code_d_       VARCHAR2(1);
   req_code_e_       VARCHAR2(1);
   req_code_f_       VARCHAR2(1);
   req_code_g_       VARCHAR2(1);
   req_code_h_       VARCHAR2(1);
   req_code_i_       VARCHAR2(1);
   req_code_j_       VARCHAR2(1);
   req_quantity_     VARCHAR2(1);
   req_text_         VARCHAR2(1);
   req_process_code_ VARCHAR2(1);
   --
   CURSOR reqcodepart IS
      SELECT req_code_b,
             req_code_c,
             req_code_d,
             req_code_e,
             req_code_f,
             req_code_g,
             req_code_h,
             req_code_i,
             req_code_j,
             req_quantity,
             req_text,
             req_process_code
      FROM  accounting_code_part_value_tab
      WHERE company = company_
      AND   code_part = 'A'
      AND   code_part_value = account_;
BEGIN
   OPEN reqcodepart;
   FETCH reqcodepart INTO req_code_b_, req_code_c_, req_code_d_, req_code_e_,
                          req_code_f_, req_code_g_, req_code_h_, req_code_i_,
                          req_code_j_, req_quantity_, req_text_, req_process_code_;
   CLOSE reqcodepart;
   IF (req_code_part_ = 'TEXT') AND (code_part_value_ IS NULL) THEN
      IF (req_text_ = 'M') THEN
         Error_SYS.record_general(lu_name_, 'WRONGTEXTREQ: Wrong requirements for account :P1 in Text', account_);
      END IF;
   ELSIF (req_code_part_ = 'PROCESS_CODE') AND (code_part_value_ IS NULL) THEN
      IF (req_process_code_ = 'M') THEN
         Error_SYS.record_general(lu_name_, 'WRONGPROCREQ: Wrong requirements for account :P1 in Process code', account_);
      END IF;
   ELSIF (req_code_part_ = 'PROCESS_CODE') AND (code_part_value_ IS NOT NULL) THEN
      IF (req_process_code_ = 'S') THEN
         Error_SYS.record_general(lu_name_, 'WRONGPROCREQ: Wrong requirements for account :P1 in Process code', account_);
      END IF;
   END IF;
END Validate_Req_Code_Part_;


FUNCTION Validate_Req_Account_ (
   codestring_rec_ IN Accounting_Codestr_API.CodestrRec,
   company_        IN VARCHAR2,
   voucher_date_   IN DATE ) RETURN BOOLEAN
IS
   --
   req_code_b_       VARCHAR2(1);
   req_code_c_       VARCHAR2(1);
   req_code_d_       VARCHAR2(1);
   req_code_e_       VARCHAR2(1);
   req_code_f_       VARCHAR2(1);
   req_code_g_       VARCHAR2(1);
   req_code_h_       VARCHAR2(1);
   req_code_i_       VARCHAR2(1);
   req_code_j_       VARCHAR2(1);
   req_quantity_     VARCHAR2(1);

   CURSOR account_cursor IS
      SELECT req_code_b,
             req_code_c,
             req_code_d,
             req_code_e,
             req_code_f,
             req_code_g,
             req_code_h,
             req_code_i,
             req_code_j,
             req_quantity
      FROM  accounting_code_part_value_tab
      WHERE company = company_
      AND   code_part = 'A'
      AND   code_part_value = codestring_rec_.code_a
      AND   voucher_date_ BETWEEN valid_from AND valid_until;
BEGIN
   OPEN account_cursor;
   FETCH account_cursor INTO req_code_b_,
                             req_code_c_,
                             req_code_d_,
                             req_code_e_,
                             req_code_f_,
                             req_code_g_,
                             req_code_h_,
                             req_code_i_,
                             req_code_j_,
                             req_quantity_;
   IF Check_Req___ (req_code_b_, codestring_rec_.code_b) OR
      Check_Req___ (req_code_c_, codestring_rec_.code_c) OR
      Check_Req___ (req_code_d_, codestring_rec_.code_d) OR
      Check_Req___ (req_code_e_, codestring_rec_.code_e) OR
      Check_Req___ (req_code_f_, codestring_rec_.code_f) OR
      Check_Req___ (req_code_g_, codestring_rec_.code_g) OR
      Check_Req___ (req_code_h_, codestring_rec_.code_h) OR
      Check_Req___ (req_code_i_, codestring_rec_.code_i) OR
      Check_Req___ (req_code_j_, codestring_rec_.code_j) OR
      Check_Req___ (req_quantity_, TO_CHAR(codestring_rec_.quantity)) THEN
      CLOSE account_cursor;
      RETURN(TRUE);
   END IF;
   CLOSE account_cursor;
   RETURN(FALSE);
EXCEPTION
   WHEN NO_DATA_FOUND THEN
      CLOSE account_cursor;
      RETURN(TRUE);
END Validate_Req_Account_;


PROCEDURE Check_Delete_Group_ (
   exists_        OUT VARCHAR2,
   company_       IN  VARCHAR2,
   account_group_ IN  VARCHAR2 )
IS
   dummy_      VARCHAR2(10);
   CURSOR check_group IS
      SELECT 'TRUE'
      FROM   ACCOUNTING_CODE_PART_VALUE_TAB
      WHERE  company = company_
      AND    code_part = 'A'
      AND    accnt_group = account_group_
      AND    NVL(bud_account, 'N') = 'N';
BEGIN
   OPEN check_group;
   FETCH check_group INTO dummy_;
   IF (check_group%NOTFOUND) THEN
      exists_ := 'FALSE';
   ELSE
      exists_ := 'TRUE';
   END IF;
   CLOSE check_group;
END Check_Delete_Group_;


FUNCTION Validate_Budget_Req_Account_ (
   codestring_rec_ IN Accounting_Codestr_API.CodestrRec,
   company_        IN VARCHAR2,
   voucher_date_   IN DATE ) RETURN BOOLEAN
IS
   result_     VARCHAR2(5);
   req_type_   VARCHAR2(1);
   codepart_   VARCHAR2(1);
BEGIN
   Validate_Budget_Req_Account_(result_, req_type_, codepart_, codestring_rec_, company_, voucher_date_);
   IF (result_ = 'TRUE') THEN
      RETURN(TRUE);
   END IF;
   RETURN(FALSE);
END Validate_Budget_Req_Account_;


PROCEDURE Validate_Budget_Req_Account_ (
   result_         OUT VARCHAR2,
   req_type_       OUT VARCHAR2,
   codepart_       OUT VARCHAR2,
   codestring_rec_ IN Accounting_Codestr_API.CodestrRec,
   company_        IN VARCHAR2,
   voucher_date_   IN DATE )
IS
   --
   req_budget_code_b_       VARCHAR2(1);
   req_budget_code_c_       VARCHAR2(1);
   req_budget_code_d_       VARCHAR2(1);
   req_budget_code_e_       VARCHAR2(1);
   req_budget_code_f_       VARCHAR2(1);
   req_budget_code_g_       VARCHAR2(1);
   req_budget_code_h_       VARCHAR2(1);
   req_budget_code_i_       VARCHAR2(1);
   req_budget_code_j_       VARCHAR2(1);
   req_budget_quantity_     VARCHAR2(1);

   is_req_code_b_    BOOLEAN;
   is_req_code_c_    BOOLEAN;
   is_req_code_d_    BOOLEAN;
   is_req_code_e_    BOOLEAN;
   is_req_code_f_    BOOLEAN;
   is_req_code_g_    BOOLEAN;
   is_req_code_h_    BOOLEAN;
   is_req_code_i_    BOOLEAN;
   is_req_code_j_    BOOLEAN;
   is_req_quantity_  BOOLEAN;

   CURSOR account_cursor IS
      SELECT req_budget_code_b,
             req_budget_code_c,
             req_budget_code_d,
             req_budget_code_e,
             req_budget_code_f,
             req_budget_code_g,
             req_budget_code_h,
             req_budget_code_i,
             req_budget_code_j,
             req_budget_quantity
      FROM  accounting_code_part_value_tab
      WHERE company = company_
      AND   code_part = 'A'
      AND   code_part_value = codestring_rec_.code_a
      AND   voucher_date_ BETWEEN valid_from AND valid_until;
BEGIN
   req_type_ := NULL;
   codepart_ := NULL;
   result_   := 'FALSE';
   OPEN account_cursor;
   FETCH account_cursor INTO req_budget_code_b_,
                             req_budget_code_c_,
                             req_budget_code_d_,
                             req_budget_code_e_,
                             req_budget_code_f_,
                             req_budget_code_g_,
                             req_budget_code_h_,
                             req_budget_code_i_,
                             req_budget_code_j_,
                             req_budget_quantity_;
   CLOSE account_cursor;
   is_req_code_b_   := Check_Req___ (req_budget_code_b_, codestring_rec_.code_b);
   is_req_code_c_   := Check_Req___ (req_budget_code_c_, codestring_rec_.code_c);
   is_req_code_d_   := Check_Req___ (req_budget_code_d_, codestring_rec_.code_d);
   is_req_code_e_   := Check_Req___ (req_budget_code_e_, codestring_rec_.code_e);
   is_req_code_f_   := Check_Req___ (req_budget_code_f_, codestring_rec_.code_f);
   is_req_code_g_   := Check_Req___ (req_budget_code_g_, codestring_rec_.code_g);
   is_req_code_h_   := Check_Req___ (req_budget_code_h_, codestring_rec_.code_h);
   is_req_code_i_   := Check_Req___ (req_budget_code_i_, codestring_rec_.code_i);
   is_req_code_j_   := Check_Req___ (req_budget_code_j_, codestring_rec_.code_j);
   is_req_quantity_ := Check_Req___ (req_budget_quantity_, TO_CHAR(codestring_rec_.quantity));
   IF is_req_code_b_ OR is_req_code_c_ OR is_req_code_d_ OR is_req_code_e_ OR is_req_code_f_ OR 
      is_req_code_g_ OR is_req_code_h_ OR is_req_code_i_ OR is_req_code_j_ OR is_req_quantity_ THEN
      IF (is_req_code_b_) THEN
         req_type_ := req_budget_code_b_;
         codepart_ := 'B';
      ELSIF (is_req_code_c_) THEN
         req_type_ := req_budget_code_c_;
         codepart_ := 'C';
      ELSIF (is_req_code_d_) THEN
         req_type_ := req_budget_code_d_;
         codepart_ := 'D';
      ELSIF (is_req_code_e_) THEN
         req_type_ := req_budget_code_e_;
         codepart_ := 'E';
      ELSIF (is_req_code_f_) THEN
         req_type_ := req_budget_code_f_;
         codepart_ := 'F';
      ELSIF (is_req_code_g_) THEN
         req_type_ := req_budget_code_g_;
         codepart_ := 'G';
      ELSIF (is_req_code_h_) THEN
         req_type_ := req_budget_code_h_;
         codepart_ := 'H';
      ELSIF (is_req_code_i_) THEN
         req_type_ := req_budget_code_i_;
         codepart_ := 'I';
      ELSIF (is_req_code_j_) THEN
         req_type_ := req_budget_code_j_;
         codepart_ := 'J';
      END IF;
      result_ := 'TRUE';
   END IF;
END Validate_Budget_Req_Account_;


FUNCTION Validate_Budget_Req_Account_ (
   codestring_rec_ IN Accounting_Codestr_API.CodestrRec,
   company_        IN VARCHAR2,
   budget_year_    IN NUMBER,
   period_         IN NUMBER,
   period_from_    IN NUMBER,
   period_to_      IN NUMBER ) RETURN BOOLEAN
IS
   result_     VARCHAR2(5);
   req_type_   VARCHAR2(1);
   codepart_   VARCHAR2(1);
BEGIN
   Validate_Budget_Req_Account_(result_, req_type_, codepart_, codestring_rec_, company_, budget_year_, period_, period_from_, period_to_);
   IF (result_ = 'TRUE') THEN
      RETURN(TRUE);
   END IF;
   RETURN(FALSE);
END Validate_Budget_Req_Account_;


PROCEDURE Validate_Budget_Req_Account_ (
   result_         OUT VARCHAR2,
   req_type_       OUT VARCHAR2,
   codepart_       OUT VARCHAR2,
   codestring_rec_ IN Accounting_Codestr_API.CodestrRec,
   company_        IN VARCHAR2,
   budget_year_    IN NUMBER,
   period_         IN NUMBER,
   period_from_    IN NUMBER,
   period_to_      IN NUMBER )
IS
   --
   req_budget_code_b_       VARCHAR2(1);
   req_budget_code_c_       VARCHAR2(1);
   req_budget_code_d_       VARCHAR2(1);
   req_budget_code_e_       VARCHAR2(1);
   req_budget_code_f_       VARCHAR2(1);
   req_budget_code_g_       VARCHAR2(1);
   req_budget_code_h_       VARCHAR2(1);
   req_budget_code_i_       VARCHAR2(1);
   req_budget_code_j_       VARCHAR2(1);
   req_budget_quantity_     VARCHAR2(1);

   is_req_code_b_    BOOLEAN;
   is_req_code_c_    BOOLEAN;
   is_req_code_d_    BOOLEAN;
   is_req_code_e_    BOOLEAN;
   is_req_code_f_    BOOLEAN;
   is_req_code_g_    BOOLEAN;
   is_req_code_h_    BOOLEAN;
   is_req_code_i_    BOOLEAN;
   is_req_code_j_    BOOLEAN;
   is_req_quantity_  BOOLEAN;

   date_from_               DATE;
   date_until_              DATE;

   from_date_range_from_    DATE;
   from_date_range_until_   DATE;
   to_date_range_from_      DATE;
   to_date_range_until_     DATE;
   min_period_              NUMBER;
   max_period_              NUMBER;
   bud_period_from_         NUMBER;
   bud_period_to_           NUMBER;


   CURSOR account_cursor IS
      SELECT req_budget_code_b,
             req_budget_code_c,
             req_budget_code_d,
             req_budget_code_e,
             req_budget_code_f,
             req_budget_code_g,
             req_budget_code_h,
             req_budget_code_i,
             req_budget_code_j,
             req_budget_quantity
      FROM  accounting_code_part_value_tab
      WHERE company = company_
      AND   code_part = 'A'
      AND   code_part_value = codestring_rec_.code_a
      AND   (valid_from <= date_until_
               AND valid_until >= date_from_ );

BEGIN
   req_type_ := NULL;
   codepart_ := NULL;
   result_   := 'FALSE';
   Accounting_Period_API.Get_Period_Date (date_from_,
                                          date_until_,
                                          company_,
                                          budget_year_,
                                          period_ );

   bud_period_from_ :=period_from_;
   bud_period_to_   :=period_to_;
   IF (period_  IS NULL    AND  period_from_ IS NULL AND  period_to_  IS NULL)  THEN
      Accounting_Period_API.Get_Min_Max_Period(min_period_,
                                               max_period_,
                                               company_,
                                               budget_year_);
      bud_period_from_ :=min_period_;
      bud_period_to_   :=max_period_;

   END IF;


   IF (period_ IS NULL) THEN
      Accounting_Period_API.Get_Period_Date (from_date_range_from_,
                                             from_date_range_until_,
                                             company_,
                                             budget_year_,
                                             bud_period_from_ );

      Accounting_Period_API.Get_Period_Date (to_date_range_from_,
                                             to_date_range_until_,
                                             company_,
                                             budget_year_,
                                             bud_period_to_);

      date_until_ :=from_date_range_until_;
      date_from_  := to_date_range_from_;
   END IF;

   OPEN account_cursor;
   FETCH account_cursor INTO req_budget_code_b_,
                             req_budget_code_c_,
                             req_budget_code_d_,
                             req_budget_code_e_,
                             req_budget_code_f_,
                             req_budget_code_g_,
                             req_budget_code_h_,
                             req_budget_code_i_,
                             req_budget_code_j_,
                             req_budget_quantity_;
   CLOSE account_cursor;
   is_req_code_b_   := Check_Req___ (req_budget_code_b_, codestring_rec_.code_b);
   is_req_code_c_   := Check_Req___ (req_budget_code_c_, codestring_rec_.code_c);
   is_req_code_d_   := Check_Req___ (req_budget_code_d_, codestring_rec_.code_d);
   is_req_code_e_   := Check_Req___ (req_budget_code_e_, codestring_rec_.code_e);
   is_req_code_f_   := Check_Req___ (req_budget_code_f_, codestring_rec_.code_f);
   is_req_code_g_   := Check_Req___ (req_budget_code_g_, codestring_rec_.code_g);
   is_req_code_h_   := Check_Req___ (req_budget_code_h_, codestring_rec_.code_h);
   is_req_code_i_   := Check_Req___ (req_budget_code_i_, codestring_rec_.code_i);
   is_req_code_j_   := Check_Req___ (req_budget_code_j_, codestring_rec_.code_j);
   is_req_quantity_ := Check_Req___ (req_budget_quantity_, TO_CHAR(codestring_rec_.quantity));
   IF is_req_code_b_ OR is_req_code_c_ OR is_req_code_d_ OR is_req_code_e_ OR is_req_code_f_ OR 
      is_req_code_g_ OR is_req_code_h_ OR is_req_code_i_ OR is_req_code_j_ OR is_req_quantity_ THEN
      IF (is_req_code_b_) THEN
         req_type_ := req_budget_code_b_;
         codepart_ := 'B';
      ELSIF (is_req_code_c_) THEN
         req_type_ := req_budget_code_c_;
         codepart_ := 'C';
      ELSIF (is_req_code_d_) THEN
         req_type_ := req_budget_code_d_;
         codepart_ := 'D';
      ELSIF (is_req_code_e_) THEN
         req_type_ := req_budget_code_e_;
         codepart_ := 'E';
      ELSIF (is_req_code_f_) THEN
         req_type_ := req_budget_code_f_;
         codepart_ := 'F';
      ELSIF (is_req_code_g_) THEN
         req_type_ := req_budget_code_g_;
         codepart_ := 'G';
      ELSIF (is_req_code_h_) THEN
         req_type_ := req_budget_code_h_;
         codepart_ := 'H';
      ELSIF (is_req_code_i_) THEN
         req_type_ := req_budget_code_i_;
         codepart_ := 'I';
      ELSIF (is_req_code_j_) THEN
         req_type_ := req_budget_code_j_;
         codepart_ := 'J';
      END IF;
      result_ := 'TRUE';
   END IF;
END Validate_Budget_Req_Account_;


PROCEDURE Exist_ (
   company_ IN VARCHAR2,
   account_ IN VARCHAR2 )
IS
BEGIN
   IF (NOT Check_Exist___(company_, account_)) THEN
      Error_SYS.Record_Not_Exist(lu_name_);
   END IF;
END Exist_;


PROCEDURE Is_Ledger_Account_ (
   result_ OUT VARCHAR2,
   company_ IN VARCHAR2,
   account_ IN VARCHAR2 )
IS
   is_ledger_acc_    BOOLEAN;
BEGIN

   is_ledger_acc_ := Is_Ledger_Account___(company_,account_);
   IF ( is_ledger_acc_ ) THEN
      result_ := 'TRUE' ;
   ELSE
      result_ := 'FALSE' ;
   END IF;
END Is_Ledger_Account_;


PROCEDURE Get_Required_Code_Part_ (
   req_string_ OUT VARCHAR2,
   company_ IN VARCHAR2,
   accnt_ IN VARCHAR2 )
IS
   noaccnt           EXCEPTION;
   req_attr_         VARCHAR2(2000);
BEGIN

   req_attr_ := Get_Required_Code_Part___(company_, accnt_);
   IF req_attr_ IS NULL THEN
      raise noaccnt;
   END IF;
   req_string_ := req_attr_;
EXCEPTION
   WHEN noaccnt THEN
       Error_SYS.record_general(lu_name_, 'NOACCNTREQ: Account :P1 is missing in company :P2', accnt_, company_ );
END Get_Required_Code_Part_;


FUNCTION Validate_Code_Part_ (
   company_ IN VARCHAR2,
   account_ IN VARCHAR2,
   date_ IN DATE ) RETURN VARCHAR2
IS
   result_      VARCHAR2(6);
BEGIN
   Validate_Code_Part(result_,company_, account_,date_);
   RETURN result_;
END Validate_Code_Part_;


PROCEDURE Update_Code_Part_Demands_ (
   attr_ IN VARCHAR2 )
IS
   ptr_      NUMBER;
   name_     VARCHAR2(30);
   newrec_   ACCOUNTING_CODE_PART_VALUE_TAB%ROWTYPE;
   value_    VARCHAR2(2000);

BEGIN

   ptr_ := NULL;
   WHILE (Client_SYS.Get_Next_From_Attr(attr_, ptr_, name_, value_)) LOOP
      IF (name_ = 'COMPANY') THEN
         newrec_.company := value_;
      ELSIF (name_ = 'ACCNT_TYPE') THEN
         newrec_.accnt_type := value_;
      ELSIF (name_ = 'REQ_CODE_B') THEN
         newrec_.req_code_b := value_;
      ELSIF (name_ = 'REQ_CODE_C') THEN
         newrec_.req_code_c := value_;
      ELSIF (name_ = 'REQ_CODE_D') THEN
         newrec_.req_code_d := value_;
      ELSIF (name_ = 'REQ_CODE_E') THEN
         newrec_.req_code_e := value_;
      ELSIF (name_ = 'REQ_CODE_F') THEN
         newrec_.req_code_f := value_;
      ELSIF (name_ = 'REQ_CODE_G') THEN
         newrec_.req_code_g := value_;
      ELSIF (name_ = 'REQ_CODE_H') THEN
         newrec_.req_code_h := value_;
      ELSIF (name_ = 'REQ_CODE_I') THEN
         newrec_.req_code_i := value_;
      ELSIF (name_ = 'REQ_CODE_J') THEN
         newrec_.req_code_j := value_;
      ELSIF (name_ = 'REQ_QUANTITY') THEN
         newrec_.req_quantity := value_;
      ELSIF (name_ = 'PROCESS_CODE') THEN
         newrec_.req_process_code := value_;
      ELSIF (name_ = 'TEXT') THEN
         newrec_.req_text := value_;
      ELSIF (name_ = 'REQ_BUD_CODE_B') THEN
         newrec_.req_budget_code_b := value_;
      ELSIF (name_ = 'REQ_BUD_CODE_C') THEN
         newrec_.req_budget_code_c := value_;
      ELSIF (name_ = 'REQ_BUD_CODE_D') THEN
         newrec_.req_budget_code_d := value_;
      ELSIF (name_ = 'REQ_BUD_CODE_E') THEN
         newrec_.req_budget_code_e := value_;
      ELSIF (name_ = 'REQ_BUD_CODE_F') THEN
         newrec_.req_budget_code_f := value_;
      ELSIF (name_ = 'REQ_BUD_CODE_G') THEN
         newrec_.req_budget_code_g := value_;
      ELSIF (name_ = 'REQ_BUD_CODE_H') THEN
         newrec_.req_budget_code_h := value_;
      ELSIF (name_ = 'REQ_BUD_CODE_I') THEN
         newrec_.req_budget_code_i := value_;
      ELSIF (name_ = 'REQ_BUD_CODE_J') THEN
         newrec_.req_budget_code_j := value_;
      ELSIF (name_ = 'REQ_BUD_QUANTITY') THEN
         newrec_.req_budget_quantity := value_;
      ELSE
         NULL;
      END IF;
   END LOOP;
   Update_Code_Part_Demands___(newrec_);
END Update_Code_Part_Demands_;


-------------------- LU SPECIFIC PUBLIC METHODS -----------------------------

-- Exist
--   Checks if given pointer (e.g. primary key) to an instance of this
--   logical unit exists. If not an exception will be raised.
@UncheckedAccess
FUNCTION Exist (
   company_ IN VARCHAR2,
   account_ IN VARCHAR2 ) RETURN BOOLEAN
IS
BEGIN
   RETURN ( Check_Exist___( company_, account_));
END Exist;

-- Bug 131063, Begin.
@UncheckedAccess
FUNCTION Exist2 (
      company_ IN VARCHAR2,
      account_ IN VARCHAR2 ) RETURN VARCHAR2
   IS
BEGIN
   IF ( Account_API.Exists( company_, account_)) THEN
     RETURN 'TRUE';
   ELSE
     RETURN 'FALSE';
   END IF;
END Exist2;
-- Bug 131063, End.

PROCEDURE Get_Accnt_Group (
   accnt_group_ OUT VARCHAR2,
   company_     IN  VARCHAR2,
   accnt_       IN  VARCHAR2 )
IS
   CURSOR get_group IS
      SELECT accnt_group
      FROM   ACCOUNTING_CODE_PART_VALUE_TAB
      WHERE company = company_
      AND   code_part = 'A'
      AND   code_part_value = accnt_
      AND   NVL(bud_account, 'N') = 'N';
BEGIN
   OPEN get_group;
   FETCH get_group INTO accnt_group_;
   IF (get_group%NOTFOUND) THEN
      accnt_group_ := NULL;
   END IF;
   CLOSE get_group;
END Get_Accnt_Group;

PROCEDURE Get_Process_Code (
   process_code_ OUT VARCHAR2,
   company_      IN VARCHAR2,
   accnt_        IN VARCHAR2 )
IS
  CURSOR get_code IS
    SELECT process_code
    FROM   ACCOUNTING_CODE_PART_VALUE_TAB
    WHERE  company = company_
    AND    code_part = 'A'
    AND    code_part_value  = accnt_
    AND    NVL(bud_account, 'N') = 'N';
BEGIN
   OPEN get_code;
   FETCH get_code INTO process_code_;
   IF (get_code%NOTFOUND) THEN
      CLOSE get_code;
      process_code_ := NULL;
   ELSE
      CLOSE get_code;
   END IF;
END Get_Process_Code;


FUNCTION Accnt_Exist_In_Cons_Company (
   company_ IN VARCHAR2,
   account_ IN VARCHAR2 ) RETURN BOOLEAN
IS
   row_              ACCOUNTING_CODE_PART_VALUE_TAB%ROWTYPE;
BEGIN
   row_ := Get_Object_By_Keys___(company_, account_);
   IF (row_.code_part_value IS NULL) THEN
      RETURN FALSE;
   END IF;
   RETURN TRUE;
END Accnt_Exist_In_Cons_Company;


@UncheckedAccess
FUNCTION Calculate_Accnt_For_Cons (
   company_ IN VARCHAR2,
   account_ IN VARCHAR2 ) RETURN VARCHAR2
IS
   cons_accnt_      ACCOUNTING_CODE_PART_VALUE_TAB.cons_accnt%TYPE;
   row_             ACCOUNTING_CODE_PART_VALUE_TAB%ROWTYPE;
BEGIN
   row_ := Get_Object_By_Keys___( company_, account_);
   IF (row_.cons_accnt IS NOT NULL) THEN
      RETURN ( row_.cons_accnt );
   END IF;
   cons_accnt_ := Account_Group_API.Get_Default_Cons_Accnt( row_.company,
                                                            row_.accnt_group );
   IF (cons_accnt_ IS NULL) THEN
      RETURN ( row_.code_part_value );
   END IF;
   RETURN ( cons_accnt_ );
END Calculate_Accnt_For_Cons;


PROCEDURE Change_Account_Code_Parts (
   count_ OUT NUMBER,
   attr_  IN  VARCHAR2 )
IS
   company_       VARCHAR2(20);
   accnt_type_    VARCHAR2(20);
   ptr_           NUMBER;
   name_          VARCHAR2(30);
   value_         VARCHAR2(2000);
   objid_         VARCHAR2(2000);
   objversion_    VARCHAR2(2000);
   dummy_         VARCHAR2(200);
   attr2_         VARCHAR2(2000);
   temp_          VARCHAR2(2000);
   CURSOR get_objid IS
      SELECT rowid, ltrim(lpad(to_char(rowversion,'YYYYMMDDHH24MISS'),2000))
      FROM   ACCOUNTING_CODE_PART_VALUE_TAB
      WHERE  company = company_
      AND    code_part = 'A'
      AND    accnt_type = accnt_type_
      AND    NVL(bud_account, 'N') = 'N';
BEGIN

   ptr_ := NULL;
   WHILE (Client_SYS.Get_Next_From_Attr(attr_, ptr_, name_, value_)) LOOP
      IF (name_ = 'COMPANY') THEN
         company_ := value_;
      ELSIF (name_ = 'ACCNT_TYPE') THEN
         accnt_type_ := value_;
      ELSIF (name_ = 'REQ_CODE_B_DEFAULT') THEN
         Client_SYS.Add_To_Attr('REQ_CODE_B', value_, temp_);
      ELSIF (name_ = 'REQ_CODE_C_DEFAULT') THEN
         Client_SYS.Add_To_Attr('REQ_CODE_C', value_, temp_);
      ELSIF (name_ = 'REQ_CODE_D_DEFAULT') THEN
         Client_SYS.Add_To_Attr('REQ_CODE_D', value_, temp_);
      ELSIF (name_ = 'REQ_CODE_E_DEFAULT') THEN
         Client_SYS.Add_To_Attr('REQ_CODE_E', value_, temp_);
      ELSIF (name_ = 'REQ_CODE_F_DEFAULT') THEN
         Client_SYS.Add_To_Attr('REQ_CODE_F', value_, temp_);
      ELSIF (name_ = 'REQ_CODE_G_DEFAULT') THEN
         Client_SYS.Add_To_Attr('REQ_CODE_G', value_, temp_);
      ELSIF (name_ = 'REQ_CODE_H_DEFAULT') THEN
         Client_SYS.Add_To_Attr('REQ_CODE_H', value_, temp_);
      ELSIF (name_ = 'REQ_CODE_I_DEFAULT') THEN
         Client_SYS.Add_To_Attr('REQ_CODE_I', value_, temp_);
      ELSIF (name_ = 'REQ_CODE_J_DEFAULT') THEN
         Client_SYS.Add_To_Attr('REQ_CODE_J', value_, temp_);
      ELSIF (name_ = 'REQ_QUANTITY_DEFAULT') THEN
         Client_SYS.Add_To_Attr('REQ_QUANTITY', value_, temp_);
      ELSIF (name_ = 'PROCESS_CODE_DEFAULT') THEN
         Client_SYS.Add_To_Attr('REQ_PROCESS_CODE', value_, temp_);
      ELSIF (name_ = 'TEXT_DEFAULT') THEN
         Client_SYS.Add_To_Attr('REQ_TEXT', value_, temp_);
      ELSIF (name_ = 'REQ_BUD_CODE_B_DEFAULT') THEN
         Client_SYS.Add_To_Attr('REQ_BUDGET_CODE_B', value_, temp_);
      ELSIF (name_ = 'REQ_BUD_CODE_C_DEFAULT') THEN
         Client_SYS.Add_To_Attr('REQ_BUDGET_CODE_C', value_, temp_);
      ELSIF (name_ = 'REQ_BUD_CODE_D_DEFAULT') THEN
         Client_SYS.Add_To_Attr('REQ_BUDGET_CODE_D', value_, temp_);
      ELSIF (name_ = 'REQ_BUD_CODE_E_DEFAULT') THEN
         Client_SYS.Add_To_Attr('REQ_BUDGET_CODE_E', value_, temp_);
      ELSIF (name_ = 'REQ_BUD_CODE_F_DEFAULT') THEN
         Client_SYS.Add_To_Attr('REQ_BUDGET_CODE_F', value_, temp_);
      ELSIF (name_ = 'REQ_BUD_CODE_G_DEFAULT') THEN
         Client_SYS.Add_To_Attr('REQ_BUDGET_CODE_G', value_, temp_);
      ELSIF (name_ = 'REQ_BUD_CODE_H_DEFAULT') THEN
         Client_SYS.Add_To_Attr('REQ_BUDGET_CODE_H', value_, temp_);
      ELSIF (name_ = 'REQ_BUD_CODE_I_DEFAULT') THEN
         Client_SYS.Add_To_Attr('REQ_BUDGET_CODE_I', value_, temp_);
      ELSIF (name_ = 'REQ_BUD_CODE_J_DEFAULT') THEN
         Client_SYS.Add_To_Attr('REQ_BUDGET_CODE_J', value_, temp_);
      ELSIF (name_ = 'REQ_BUD_QUANTITY_DEFAULT') THEN
         Client_SYS.Add_To_Attr('REQ_BUDGET_QUANTITY', value_, temp_);
      ELSE
         NULL;
      END IF;
   END LOOP;
   attr2_ := temp_;
   OPEN get_objid;
   LOOP
      FETCH get_objid INTO objid_, objversion_;

      EXIT WHEN get_objid%NOTFOUND;
      temp_ := attr2_;
      Modify__(dummy_, objid_, objversion_, temp_, 'DO');
   END LOOP;
   CLOSE get_objid;
   Client_SYS.Clear_Attr(attr2_);
   Client_SYS.Clear_Attr(temp_);
END Change_Account_Code_Parts;


PROCEDURE Clear_Consolidation_Account (
   company_ IN VARCHAR2 )
IS
BEGIN
   UPDATE accounting_code_part_value_tab
      SET cons_accnt = NULL
      WHERE company = company_
        AND code_part = 'A';
END Clear_Consolidation_Account;


PROCEDURE Exist_Account_And_Pseudo (
   company_ IN VARCHAR2,
   account_ IN VARCHAR2 )
IS
BEGIN
   IF Is_Budget_account(company_, account_) THEN
      Error_SYS.Record_General(lu_name_, 'BUDACCONLY: Account :P1 is only allowed for budget',account_);
   ELSIF (NOT Check_Exist___( company_, account_ )) AND (NOT Pseudo_Codes_API.Exist_Pseudo(company_, account_ )) THEN
      Error_SYS.Record_General(lu_name_, 'EXISTACPC: Account or Pseudo Code does not exist');
   END IF;
END Exist_Account_And_Pseudo;

PROCEDURE Get_Accnt_Type (
   accnt_type_ OUT VARCHAR2,
   company_    IN  VARCHAR2,
   accnt_      IN  VARCHAR2 )
IS
BEGIN
   accnt_type_ := Get_Accnt_Type( company_, accnt_ );
END Get_Accnt_Type;


PROCEDURE Get_Account_Info (
   description_        OUT VARCHAR2,
   valid_from_         OUT DATE,
   valid_until_        OUT DATE,
   accounting_text_id_ OUT VARCHAR2,
   accnt_group_        OUT VARCHAR2,
   accnt_type_         OUT VARCHAR2,
   process_code_       OUT VARCHAR2,
   ledg_flag_          OUT VARCHAR2,
   cons_company_       OUT VARCHAR2,
   cons_accnt_         OUT VARCHAR2,
   curr_rate_          OUT NUMBER,
   curr_balance_       OUT VARCHAR2,
   conv_factor_        OUT NUMBER,
   text_               OUT VARCHAR2,
   company_            IN  VARCHAR2,
   account_            IN  VARCHAR2)
IS
   info_ ACCOUNTING_CODE_PART_VALUE_TAB%ROWTYPE;
   CURSOR info  IS
      SELECT *
      FROM  ACCOUNTING_CODE_PART_VALUE_TAB
      WHERE company = company_
      AND   code_part = 'A'
      AND   code_part_value = account_
      AND   NVL(bud_account, 'N') = 'N';
BEGIN
   OPEN info;
   FETCH info INTO info_;
   IF (info%NOTFOUND) THEN
      Error_SYS.Appl_General(lu_name_, 'NOACCNTREQ: Account :P1 is missing in company :P2', account_, company_ );
   END IF;
   CLOSE info;
   description_         := Get_Description( company_, account_ );
   valid_from_          := info_.valid_from;
   valid_until_         := info_.valid_until;
   accounting_text_id_  := info_.accounting_text_id;
   accnt_group_         := info_.accnt_group;
   accnt_type_          := info_.accnt_type;
   process_code_        := info_.process_code;
   ledg_flag_           := Accounting_Ledg_Flag_API.Decode(info_.ledg_flag);
   cons_company_        := Company_Finance_API.Get_Cons_Company(company_);
   cons_accnt_          := info_.cons_accnt;
   curr_balance_        := Acc_Currency_Balance_Flag_API.Decode(info_.curr_balance);
   text_                := info_.text;
END Get_Account_Info;


@UncheckedAccess
FUNCTION Get_Code_Part_Demand (
   company_    IN VARCHAR2,
   account_ IN VARCHAR2,
   code_part_ IN VARCHAR2 ) RETURN VARCHAR2
IS
   CURSOR get_code_req IS
     SELECT req_code_b,
            req_code_c,
            req_code_d,
            req_code_e,
            req_code_f,
            req_code_g,
            req_code_h,
            req_code_i,
            req_code_j,
            req_quantity,
            req_text,
            req_process_code
      FROM   accounting_code_part_value_tab
      WHERE Company = company_
      AND   Code_part_value  = account_
      AND   code_part = 'A';
   req_b_            VARCHAR2(1);
   req_c_            VARCHAR2(1);
   req_d_            VARCHAR2(1);
   req_e_            VARCHAR2(1);
   req_f_            VARCHAR2(1);
   req_g_            VARCHAR2(1);
   req_h_            VARCHAR2(1);
   req_i_            VARCHAR2(1);
   req_j_            VARCHAR2(1);
   req_quantity_     VARCHAR2(1);
   req_text_         VARCHAR2(1);
   req_process_code_ VARCHAR2(1);
BEGIN
   OPEN get_code_req;
   FETCH get_code_req INTO req_b_,
                           req_c_,
                           req_d_,
                           req_e_,
                           req_f_,
                           req_g_,
                           req_h_,
                           req_i_,
                           req_j_,
                           req_quantity_,
                           req_text_,
                           req_process_code_;
   CLOSE get_code_req;
   IF (code_part_ = 'B') THEN
      RETURN req_b_;
   ELSIF (code_part_ = 'C') THEN
      RETURN req_c_;
   ELSIF (code_part_ = 'D') THEN
      RETURN req_d_;
   ELSIF (code_part_ = 'E') THEN
      RETURN req_e_;
   ELSIF (code_part_ = 'F') THEN
      RETURN req_f_;
   ELSIF (code_part_ = 'G') THEN
      RETURN req_g_;
   ELSIF (code_part_ = 'H') THEN
      RETURN req_h_;
   ELSIF (code_part_ = 'I') THEN
      RETURN req_i_;
   ELSIF (code_part_ = 'J') THEN
      RETURN req_j_;
   ELSIF (code_part_ = 'QUANTITY') THEN
      RETURN req_quantity_;
   ELSIF (code_part_ = 'TEXT') THEN
      RETURN req_text_;
   ELSIF (code_part_ = 'PROCESS_CODE') THEN
      RETURN req_process_code_;
   END IF;
   RETURN NULL;
END Get_Code_Part_Demand;


PROCEDURE Get_Curr_Balance (
  curr_balance_       IN OUT VARCHAR2,
  company_            IN     VARCHAR2,
  accnt_              IN     VARCHAR2 )
IS
BEGIN
   curr_balance_ := Get_Currency_Balance( company_, accnt_ );
END Get_Curr_Balance;


@UncheckedAccess
FUNCTION Get_Accnt_Type_Db (
   company_   IN VARCHAR2,
   account_   IN VARCHAR2 ) RETURN VARCHAR2
IS
   CURSOR get_type IS
      SELECT logical_account_type
      FROM   ACCOUNTING_CODE_PART_VALUE_TAB
      WHERE company          = company_
      AND   code_part = 'A'
      AND   code_part_value = account_
      AND   NVL(bud_account, 'N') = 'N';
   accnt_type_db_    ACCOUNTING_CODE_PART_VALUE_TAB.logical_account_type%TYPE;
BEGIN
   OPEN get_type;
   FETCH get_type INTO accnt_type_db_;
   IF (get_type%NOTFOUND) THEN
      CLOSE get_type;
      accnt_type_db_ := NULL;
   ELSE
      CLOSE get_type;
   END IF;
   RETURN accnt_type_db_ ;
END Get_Accnt_Type_Db;


@UncheckedAccess
FUNCTION Get_Currency_Balance (
   company_            IN     VARCHAR2,
   accnt_              IN     VARCHAR2 ) RETURN VARCHAR2
IS
   CURSOR get_balance IS
      SELECT curr_balance
      FROM   Accounting_code_part_value_tab
      WHERE Company = company_
      AND   code_part = 'A'
      AND   code_part_value  = accnt_;
   curr_balance_ VARCHAR2(1);
BEGIN
   OPEN get_balance;
   FETCH get_balance INTO curr_balance_;
   IF (get_balance%NOTFOUND) THEN
      CLOSE get_balance;
      curr_balance_ := 'N';
      RETURN curr_balance_;
   ELSE
      CLOSE get_balance;
   END IF;
   RETURN curr_balance_;
END Get_Currency_Balance;


@UncheckedAccess
FUNCTION Get_Demand_String (
   company_ IN VARCHAR2,
   account_ IN VARCHAR2 ) RETURN VARCHAR2
IS
   i_             NUMBER;
   demand_string_ VARCHAR2(100);
   code_part_     VARCHAR2(25);
BEGIN
   demand_string_ := '';
   i_ := 1;
   WHILE ( i_<=12 ) LOOP
      IF (i_=1 ) THEN
         code_part_ := 'B';
      ELSIF (i_=2) THEN
         code_part_ := 'C';
      ELSIF (i_=3) THEN
         code_part_ := 'D';
      ELSIF (i_=4) THEN
         code_part_ := 'E';
      ELSIF (i_=5) THEN
         code_part_ := 'F';
      ELSIF (i_=6) THEN
         code_part_ := 'G';
      ELSIF (i_=7) THEN
         code_part_ := 'H';
      ELSIF (i_=8) THEN
         code_part_ := 'I';
      ELSIF (i_=9) THEN
         code_part_ := 'J';
      ELSIF (i_=10) THEN
         code_part_ := 'PROCESS_CODE';
      ELSIF (i_=11) THEN
         code_part_ := 'TEXT';
      ELSIF (i_=12) THEN
         code_part_ := 'QUANTITY';
      END IF;
      demand_string_ := demand_string_ || to_char(i_) || Accounting_Code_Part_A_API.Get_Code_Part_Demand(company_, account_, code_part_);
      i_ := i_ + 1;
   END LOOP;
   RETURN(demand_string_);
END Get_Demand_String;


@UncheckedAccess
FUNCTION Get_Quantity_Demand (
   company_         IN VARCHAR2,
   account_ IN VARCHAR2 ) RETURN VARCHAR2
IS
  CURSOR req_qty_ IS
      SELECT req_quantity
      FROM   accounting_code_part_value_tab
      WHERE  Company = company_
      AND    Code_Part = 'A'
      AND    Code_Part_Value = account_;

   req_quantity_  VARCHAR2(2) := NULL;
BEGIN
   OPEN req_qty_;
   FETCH req_qty_ INTO req_quantity_;
   CLOSE req_qty_;
   RETURN(req_quantity_);
END Get_Quantity_Demand;


PROCEDURE Validate_Code_Part (
   result_          OUT VARCHAR2,
   company_         IN  VARCHAR2,
   account_         IN VARCHAR2,
   date_            IN  DATE )
IS
   dummy_      BOOLEAN;
BEGIN
   dummy_ := Validate_Code_Part(company_, account_, date_ );
   IF ( dummy_ ) THEN
      result_ := 'TRUE' ;
   ELSE
      result_ := 'FALSE' ;
   END IF;
END Validate_Code_Part;


@UncheckedAccess
FUNCTION Validate_Code_Part (
   company_         IN VARCHAR2,
   account_         IN VARCHAR2,
   date_            IN DATE ) RETURN BOOLEAN
IS
BEGIN

   RETURN Accounting_Code_Part_Value_API.Validate_Code_Part (company_,
                                                             'A',
                                                             account_,
                                                             date_);
END Validate_Code_Part;


PROCEDURE New_Code_Part_Value (
   attr_ IN VARCHAR2 )
IS
BEGIN
   NULL;
END New_Code_Part_Value;


PROCEDURE Modify_Code_Part_Value (
   attr_ IN VARCHAR2 )
IS
   ptr_              NUMBER;
   name_             VARCHAR2(2000);
   value_            VARCHAR2(2000);
   info_             VARCHAR2(2000);
   new_attr_         VARCHAR2(2000);
   company_          VARCHAR2(20);
   code_part_value_  VARCHAR2(20);
   objid_            VARCHAR2(2000);
   objversion_       VARCHAR2(2000);
   code_part_        Accounting_Code_Part_Value_Tab.code_part%TYPE;   
BEGIN
   Client_SYS.Clear_Attr(new_attr_);
   ptr_ := NULL;
   WHILE (Client_SYS.Get_Next_From_Attr(attr_, ptr_, name_, value_)) LOOP
      IF (name_ = 'COMPANY') THEN
         company_ := value_;
      ELSIF (name_ = 'CODE_PART_VALUE') THEN         -- to be removed [ Move code parts ]
         code_part_value_ := value_;
      ELSIF (name_ = 'CODE_PART') THEN
         code_part_ := value_;
      ELSE
         Client_SYS.Add_To_Attr(name_,value_,new_attr_);
      END IF;
   END LOOP;
   Get_Id_Version_By_Keys___ ( objid_, objversion_, company_, code_part_value_);
   Modify__(info_,objid_,objversion_,new_attr_,'DO');
END Modify_Code_Part_Value;


PROCEDURE Remove_Code_Part_Value (
   attr_ IN VARCHAR2 )
IS
   ptr_              NUMBER;
   name_             VARCHAR2(2000);
   value_            VARCHAR2(2000);
   info_             VARCHAR2(2000);
   company_          VARCHAR2(20);
   code_part_value_  VARCHAR2(20);
   objid_            VARCHAR2(2000);
   objversion_       VARCHAR2(2000);
BEGIN
   ptr_ := NULL;
   WHILE (Client_SYS.Get_Next_From_Attr(attr_, ptr_, name_, value_)) LOOP
      IF (name_ = 'COMPANY') THEN
         company_ := value_;
      ELSIF (name_ = 'CODE_PART') THEN
         code_part_value_ := value_;
      ELSIF (name_ = 'CODE_PART_VALUE') THEN
         code_part_value_ := value_;
      END IF;
   END LOOP;
   Get_Id_Version_By_Keys___ ( objid_, objversion_, company_, code_part_value_);
   Remove__(info_,objid_,objversion_,'DO');
END Remove_Code_Part_Value;


PROCEDURE Is_Ledger_Account (
   result_       OUT    VARCHAR2,
   company_      IN     VARCHAR2,
   accnt_        IN     VARCHAR2   )
IS
   dummy_      BOOLEAN;
BEGIN
   dummy_ := Is_Ledger_Account___(company_,accnt_);
   IF ( dummy_ ) THEN
      result_ := 'TRUE' ;
   ELSE
      result_ := 'FALSE' ;
   END IF;
END Is_Ledger_Account;


FUNCTION Is_Ledger_Account (
   company_      IN     VARCHAR2,
   accnt_        IN     VARCHAR2 ) RETURN BOOLEAN
IS
   is_ledg_flag_    BOOLEAN;
BEGIN
   is_ledg_flag_ := Is_Ledger_Account___(company_, accnt_);
   RETURN is_ledg_flag_;
END Is_Ledger_Account;


PROCEDURE Validate_Accnt (
   result_       OUT    VARCHAR2,
   company_      IN     VARCHAR2,
   accnt_        IN     VARCHAR2,
   voucher_date_ IN     DATE     )
IS
   dummy_      BOOLEAN;
BEGIN
   dummy_ := Validate_Accnt(company_,accnt_,voucher_date_ );
   IF ( dummy_ ) THEN
      result_ := 'TRUE' ;
   ELSE
      result_ := 'FALSE' ;
   END IF;
END Validate_Accnt;


FUNCTION Validate_Accnt (
   company_      IN     VARCHAR2,
   accnt_        IN     VARCHAR2,
   voucher_date_ IN     DATE ) RETURN BOOLEAN
IS
BEGIN
   IF accnt_ IS NOT NULL THEN
      IF (Accounting_Code_Part_Value_API.Validate_Code_Part ( company_, 'A', accnt_, voucher_date_ )) THEN
         RETURN TRUE;
      ELSE
         RETURN FALSE;
      END IF;
   END IF;
   RETURN TRUE;
END Validate_Accnt;


PROCEDURE Get_Required_Code_Part (
   req_string_    OUT VARCHAR2,
   company_       IN  VARCHAR2,
   accnt_         IN  VARCHAR2 )
IS
   noaccnt           EXCEPTION;
   req_attr_         VARCHAR2(2000);
BEGIN
   req_attr_ := Get_Required_Code_Part___(company_, accnt_);
   IF req_attr_ IS NULL THEN
      RAISE noaccnt;
   END IF;
   req_string_ := req_attr_;
EXCEPTION
   WHEN noaccnt THEN
       Error_SYS.record_general(lu_name_, 'NOACCNTREQ: Account :P1 is missing in company :P2', accnt_, company_ );
END Get_Required_Code_Part;


@UncheckedAccess
FUNCTION Get_Required_Code_Part (
   company_       IN  VARCHAR2,
   accnt_         IN  VARCHAR2 ) RETURN VARCHAR2
IS
   req_attr_         VARCHAR2(2000);
BEGIN
   req_attr_ := Get_Required_Code_Part___(company_, accnt_);
   RETURN(req_attr_);
END Get_Required_Code_Part;


PROCEDURE Get_Required_Code_Part (
   req_rec_       OUT Accounting_Codestr_API.CodestrRec,
   company_       IN  VARCHAR2,
   accnt_ IN VARCHAR2 )
IS
   noaccnt           EXCEPTION;
   req_attr_         VARCHAR2(2000);
   ptr_      NUMBER;
   name_     VARCHAR2(30);
   value_    VARCHAR2(2000);
BEGIN
   req_attr_ := Get_Required_Code_Part___(company_, accnt_);
   ptr_ := NULL;
   WHILE (Client_SYS.Get_Next_From_Attr(req_attr_, ptr_, name_, value_)) LOOP
      IF (name_ = 'CODE_B') THEN
         req_rec_.code_b := value_;
      ELSIF (name_ = 'CODE_C') THEN
         req_rec_.code_c := value_;
      ELSIF (name_ = 'CODE_D') THEN
         req_rec_.code_d := value_;
      ELSIF (name_ = 'CODE_E') THEN
         req_rec_.code_e := value_;
      ELSIF (name_ = 'CODE_F') THEN
         req_rec_.code_f := value_;
      ELSIF (name_ = 'CODE_G') THEN
         req_rec_.code_g := value_;
      ELSIF (name_ = 'CODE_H') THEN
         req_rec_.code_h := value_;
      ELSIF (name_ = 'CODE_I') THEN
         req_rec_.code_i := value_;
      ELSIF (name_ = 'CODE_J') THEN
         req_rec_.code_j := value_;
      ELSIF (name_ = 'PROCESS_CODE') THEN
         req_rec_.process_code := value_;
      ELSIF (name_ = 'TEXT') THEN
         req_rec_.text := value_;
      ELSIF (name_ = 'QUANTITY') THEN      
         IF (value_ = 'S') THEN  -- Blocked
            req_rec_.quantity := 0;      
         ELSIF (value_ = 'K') THEN -- Can
            req_rec_.quantity := 1;                           
         ELSIF (value_ = 'M') THEN -- Mandatory
            req_rec_.quantity := 2;                           
         END IF;            
      END IF;
   END LOOP;
   IF req_attr_ IS NULL THEN
      raise noaccnt;
   END IF;
EXCEPTION
   WHEN noaccnt THEN
      Error_SYS.appl_general(lu_name_, 'NOACCNTREQ: Account :P1 is missing in company :P2', accnt_, company_ );
END Get_Required_Code_Part;


PROCEDURE Get_Required_Code_Part (
   req_code_b_        OUT VARCHAR2,
   req_code_c_        OUT VARCHAR2,
   req_code_d_        OUT VARCHAR2,
   req_code_e_        OUT VARCHAR2,
   req_code_f_        OUT VARCHAR2,
   req_code_g_        OUT VARCHAR2,
   req_code_h_        OUT VARCHAR2,
   req_code_i_        OUT VARCHAR2,
   req_code_j_        OUT VARCHAR2,
   req_text_          OUT VARCHAR2,
   req_process_code_  OUT VARCHAR2,
   company_           IN  VARCHAR2,
   accnt_             IN  VARCHAR2 ) IS
   --
   req_quantity_     VARCHAR2(1);
   found_            BOOLEAN;
   --
   noaccnt           EXCEPTION;
BEGIN   
   Get_Required_Code_Part___(found_,
                             req_code_b_,
                             req_code_c_,
                             req_code_d_,
                             req_code_e_,
                             req_code_f_,
                             req_code_g_,
                             req_code_h_,
                             req_code_i_,
                             req_code_j_,
                             req_quantity_,
                             req_process_code_,
                             req_text_,                             
                             company_,
                             accnt_);

   IF (NOT found_) THEN
      RAISE noaccnt;
   END IF;   
 EXCEPTION
   WHEN noaccnt THEN
       Error_SYS.record_general(lu_name_, 'NOACCNTREQ: Account :P1 is missing in company :P2', accnt_, company_ );
END Get_Required_Code_Part;


PROCEDURE Validate_Consolidation_Accnt (
   company_       IN VARCHAR2,
   cons_company_  IN VARCHAR2 )
IS
   CURSOR all_accounts IS
      SELECT *
      FROM  ACCOUNTING_CODE_PART_VALUE_TAB
      WHERE company = company_
      AND   code_part = 'A'
      AND   NVL(bud_account, 'N') = 'N';
   accnt_type_               ACCOUNTING_CODE_PART_VALUE_TAB.accnt_type%TYPE;
   row_                      ACCOUNTING_CODE_PART_VALUE_TAB%ROWTYPE;
   incorrect_accnt_type      EXCEPTION;
   no_cons_accnt             EXCEPTION;
BEGIN
   FOR accnt_ IN all_accounts LOOP
      IF (accnt_.cons_accnt IS NOT NULL) THEN
         row_ := Get_Object_By_Keys___( cons_company_,
                                        accnt_.cons_accnt);
         IF (row_.company IS NULL) THEN
            RAISE no_cons_accnt;
         END IF;
         accnt_type_ := Get_Accnt_Type( accnt_.company,
                                        accnt_.cons_accnt );
         IF (accnt_type_ != row_.accnt_type) THEN
            RAISE incorrect_accnt_type;
         END IF;
      END IF;
   END LOOP;
EXCEPTION
   WHEN incorrect_accnt_type THEN
      Error_SYS.Record_General( lu_name_,
                                'VAL_CON_ACCOUNT: Only account with the same type can be used as consolidation account' );
   WHEN no_cons_accnt THEN
      Error_SYS.Record_General( 'Account',
                                'VAL_CONSACCOUNT: This consolidation account is not in the consolidating companys plan of accounts');
END Validate_Consolidation_Accnt;


PROCEDURE Get_Required_Code_Part_Pseudo (
   req_string_    OUT VARCHAR2,
   company_       IN  VARCHAR2,
   accnt_         IN  VARCHAR2 )
IS
   account_          VARCHAR2(20);
   CURSOR get_req IS
      SELECT req_code_b,
             req_code_c,
             req_code_d,
             req_code_e,
             req_code_f,
             req_code_g,
             req_code_h,
             req_code_i,
             req_code_j,
             req_quantity,
             req_process_code,
             req_text
      FROM   accounting_code_part_value_tab
       WHERE Company = company_
       AND   Code_part_value  = accnt_
       AND   code_part = 'A';
    CURSOR get_req2 IS
      SELECT req_code_b,
             req_code_c,
             req_code_d,
             req_code_e,
             req_code_f,
             req_code_g,
             req_code_h,
             req_code_i,
             req_code_j
       FROM   accounting_code_part_value_tab
       WHERE Company = company_
       AND   Code_part_value  = account_;
   CURSOR get_req3 IS
      SELECT req_budget_code_b,
             req_budget_code_c,
             req_budget_code_d,
             req_budget_code_e,
             req_budget_code_f,
             req_budget_code_g,
             req_budget_code_h,
             req_budget_code_i,
             req_budget_code_j,
             req_quantity
      FROM   accounting_code_part_value_tab
      WHERE  Company          = company_
      AND    Code_part_value  = accnt_
      AND    code_part        = 'A';

   CURSOR get_req4 IS
      SELECT req_budget_code_b,
             req_budget_code_c,
             req_budget_code_d,
             req_budget_code_e,
             req_budget_code_f,
             req_budget_code_g,
             req_budget_code_h,
             req_budget_code_i,
             req_budget_code_j
      FROM  accounting_code_part_value_tab
      WHERE Company          = company_
      AND   Code_part_value  = account_;

   noaccnt           EXCEPTION;
   req_b_            VARCHAR2(1);
   req_c_            VARCHAR2(1);
   req_d_            VARCHAR2(1);
   req_e_            VARCHAR2(1);
   req_f_            VARCHAR2(1);
   req_g_            VARCHAR2(1);
   req_h_            VARCHAR2(1);
   req_i_            VARCHAR2(1);
   req_j_            VARCHAR2(1);
   req_quantity_     VARCHAR2(1);
   req_process_code_ VARCHAR2(1);
   req_text_         VARCHAR2(1);
   req_attr_         VARCHAR2(2000);
   --
BEGIN
   IF(Is_Budget_Account(company_,accnt_)) THEN
      IF Pseudo_Codes_Api.Exist_Pseudo(company_, accnt_ ) THEN
         account_ := Pseudo_Codes_API.Get_Account(company_, accnt_);
         OPEN get_req4;
         FETCH get_req4 INTO req_b_,
                           req_c_,
                           req_d_,
                           req_e_,
                           req_f_,
                           req_g_,
                           req_h_,
                           req_i_,
                           req_j_;
         Client_SYS.Clear_Attr(req_attr_);
         Client_SYS.Add_To_Attr('CODE_B', req_b_, req_attr_);
         Client_SYS.Add_To_Attr('CODE_C', req_c_, req_attr_);
         Client_SYS.Add_To_Attr('CODE_D', req_d_, req_attr_);
         Client_SYS.Add_To_Attr('CODE_E', req_e_, req_attr_);
         Client_SYS.Add_To_Attr('CODE_F', req_f_, req_attr_);
         Client_SYS.Add_To_Attr('CODE_G', req_g_, req_attr_);
         Client_SYS.Add_To_Attr('CODE_H', req_h_, req_attr_);
         Client_SYS.Add_To_Attr('CODE_I', req_i_, req_attr_);
         Client_SYS.Add_To_Attr('CODE_J', req_j_, req_attr_);
         req_string_ := req_attr_;
         CLOSE get_req4;
      ELSE
         OPEN get_req3;
         FETCH get_req3 INTO req_b_,
                             req_c_,
                             req_d_,
                             req_e_,
                             req_f_,
                             req_g_,
                             req_h_,
                             req_i_,
                             req_j_,
                             req_quantity_;
         IF (get_req3%NOTFOUND) AND (NOT Pseudo_Codes_Api.Exist_Pseudo(company_, accnt_ ))THEN
            CLOSE get_req3;
            RAISE noaccnt;
         END IF;
         Client_SYS.Clear_Attr(req_attr_);
         Client_SYS.Add_To_Attr('CODE_B', req_b_, req_attr_);
         Client_SYS.Add_To_Attr('CODE_C', req_c_, req_attr_);
         Client_SYS.Add_To_Attr('CODE_D', req_d_, req_attr_);
         Client_SYS.Add_To_Attr('CODE_E', req_e_, req_attr_);
         Client_SYS.Add_To_Attr('CODE_F', req_f_, req_attr_);
         Client_SYS.Add_To_Attr('CODE_G', req_g_, req_attr_);
         Client_SYS.Add_To_Attr('CODE_H', req_h_, req_attr_);
         Client_SYS.Add_To_Attr('CODE_I', req_i_, req_attr_);
         Client_SYS.Add_To_Attr('CODE_J', req_j_, req_attr_);
         Client_SYS.Add_To_Attr('QUANTITY', req_quantity_, req_attr_);
         req_string_ := req_attr_;
         CLOSE get_req3;
      END IF;
   ELSE
      IF Pseudo_Codes_Api.Exist_Pseudo(company_, accnt_ ) THEN
         account_ := Pseudo_Codes_API.Get_Account(company_, accnt_);
         OPEN get_req2;
         FETCH get_req2 INTO req_b_,
                             req_c_,
                             req_d_,
                             req_e_,
                             req_f_,
                             req_g_,
                             req_h_,
                             req_i_,
                             req_j_;
         Client_SYS.Clear_Attr(req_attr_);
         Client_SYS.Add_To_Attr('CODE_B', req_b_, req_attr_);
         Client_SYS.Add_To_Attr('CODE_C', req_c_, req_attr_);
         Client_SYS.Add_To_Attr('CODE_D', req_d_, req_attr_);
         Client_SYS.Add_To_Attr('CODE_E', req_e_, req_attr_);
         Client_SYS.Add_To_Attr('CODE_F', req_f_, req_attr_);
         Client_SYS.Add_To_Attr('CODE_G', req_g_, req_attr_);
         Client_SYS.Add_To_Attr('CODE_H', req_h_, req_attr_);
         Client_SYS.Add_To_Attr('CODE_I', req_i_, req_attr_);
         Client_SYS.Add_To_Attr('CODE_J', req_j_, req_attr_);
         req_string_ := req_attr_;
         CLOSE get_req2;
      ELSE
         OPEN get_req;
         FETCH get_req INTO req_b_,
                            req_c_,
                            req_d_,
                            req_e_,
                            req_f_,
                            req_g_,
                            req_h_,
                            req_i_,
                            req_j_,
                            req_quantity_,
                            req_process_code_,
                            req_text_;
         IF (get_req%NOTFOUND) AND (NOT Pseudo_Codes_Api.Exist_Pseudo(company_, accnt_ ))THEN
            CLOSE get_req;
            RAISE noaccnt;
         END IF;
         Client_SYS.Clear_Attr(req_attr_);
         Client_SYS.Add_To_Attr('CODE_B', req_b_, req_attr_);
         Client_SYS.Add_To_Attr('CODE_C', req_c_, req_attr_);
         Client_SYS.Add_To_Attr('CODE_D', req_d_, req_attr_);
         Client_SYS.Add_To_Attr('CODE_E', req_e_, req_attr_);
         Client_SYS.Add_To_Attr('CODE_F', req_f_, req_attr_);
         Client_SYS.Add_To_Attr('CODE_G', req_g_, req_attr_);
         Client_SYS.Add_To_Attr('CODE_H', req_h_, req_attr_);
         Client_SYS.Add_To_Attr('CODE_I', req_i_, req_attr_);
         Client_SYS.Add_To_Attr('CODE_J', req_j_, req_attr_);
         Client_SYS.Add_To_Attr('QUANTITY', req_quantity_, req_attr_);
         Client_SYS.Add_To_Attr('PROCESS_CODE', req_process_code_, req_attr_);
         Client_SYS.Add_To_Attr('TEXT', req_text_, req_attr_);
         req_string_ := req_attr_;
         CLOSE get_req;
      END IF;
   END IF;
 
EXCEPTION
   WHEN noaccnt THEN
       Error_SYS.record_general(lu_name_, 'NOACCNTREQ: Account :P1 is missing in company :P2', accnt_, company_ );
END Get_Required_Code_Part_Pseudo;


PROCEDURE Validate_Account (
   val_result_         OUT    VARCHAR2,
   curr_balance_       OUT    VARCHAR2,
   req_string_         OUT    VARCHAR2,
   company_            IN     VARCHAR2,
   accnt_              IN     VARCHAR2,
   budget_year_        IN     NUMBER,
   period_             IN     NUMBER,
   period_from_        IN     NUMBER,
   period_to_          IN     NUMBER )
IS
   date_from_                 DATE;
   date_until_                DATE;

   from_date_range_from_      DATE;
   from_date_range_until_     DATE;
   to_date_range_from_        DATE;
   to_date_range_until_       DATE;
   min_period_                NUMBER;
   max_period_                NUMBER;
   bud_period_from_           NUMBER;
   bud_period_to_             NUMBER;


   CURSOR get_balance IS
      SELECT curr_balance,
             nvl(req_code_b,' ') ||
             nvl(req_code_c,' ') ||
             nvl(req_code_d,' ') ||
             nvl(req_code_e,' ') ||
             nvl(req_code_f,' ') ||
             nvl(req_code_g,' ') ||
             nvl(req_code_h,' ') ||
             nvl(req_code_i,' ') ||
             nvl(req_code_j,' ') ||
             nvl(req_quantity,' ') req_string
      FROM   Accounting_code_part_value_tab
      WHERE  Company = company_
      AND    code_part = 'A'
      AND    code_part_value  = accnt_
      AND    (valid_from <= date_until_
             AND valid_until >= date_from_);
BEGIN
   Accounting_Period_API.Get_Period_Date (date_from_,
                                          date_until_,
                                          company_,
                                          budget_year_,
                                          period_ );

   bud_period_from_ :=period_from_;
   bud_period_to_   :=period_to_;

   IF (period_  IS NULL    AND  period_from_ IS NULL AND  period_to_  IS NULL)  THEN
      Accounting_Period_API.Get_Min_Max_Period(min_period_,
                                               max_period_,
                                               company_,
                                               budget_year_);
      bud_period_from_ :=min_period_;
      bud_period_to_   :=max_period_;

   END IF;
   IF (period_ IS NULL) THEN
      Accounting_Period_API.Get_Period_Date (from_date_range_from_,
                                             from_date_range_until_,
                                             company_,
                                             budget_year_,
                                             bud_period_from_ );

      Accounting_Period_API.Get_Period_Date (to_date_range_from_,
                                             to_date_range_until_,
                                             company_,
                                             budget_year_,
                                             bud_period_to_);

      date_until_ :=from_date_range_until_;
      date_from_  := to_date_range_from_;
   END IF;
   OPEN get_balance;
   FETCH get_balance INTO curr_balance_, req_string_;
   IF (get_balance%NOTFOUND) THEN
       val_result_   := 'FALSE';
       curr_balance_ := 'N';
   ELSE
       val_result_   := 'TRUE';
   END IF;
   CLOSE get_balance;
END Validate_Account;


PROCEDURE Validate_Account (
   val_result_         OUT    VARCHAR2,
   curr_balance_       OUT    VARCHAR2,
   req_string_         OUT    VARCHAR2,
   company_            IN     VARCHAR2,
   accnt_              IN     VARCHAR2,
   date_               IN     DATE )
IS
   rec_                       Val_Account_Rec;
BEGIN
   
   rec_ := Validate_Account_Rec(company_,
                                accnt_,
                                date_);
                                
   curr_balance_ := rec_.curr_balance;
   req_string_ := rec_.req_string;
   val_result_ := rec_.val_result;                                                                
END Validate_Account;


PROCEDURE Validate_Account (
   demand_string_ OUT VARCHAR2,
   company_ IN VARCHAR2,
   account_ IN VARCHAR2 )
IS
BEGIN
   demand_string_ := '';
   Exist(company_, account_);
   demand_string_ := Get_Demand_String(company_, account_);
END Validate_Account;


@UncheckedAccess
FUNCTION Is_Stat_Account (
   company_ IN VARCHAR2,
   account_ IN VARCHAR2 ) RETURN VARCHAR2
IS
   stat_flag_    ACCOUNTING_CODE_PART_VALUE_TAB.stat_account%TYPE;
   CURSOR stat_flag IS
         SELECT stat_account
         FROM ACCOUNTING_CODE_PART_VALUE_TAB
         WHERE company = company_
         AND   code_part = 'A'
         AND   code_part_value   = account_;
BEGIN
   OPEN stat_flag;
   FETCH stat_flag INTO stat_flag_;
   CLOSE stat_flag;
   IF stat_flag_ = 'Y' THEN
      RETURN 'TRUE';
   END IF;
   RETURN 'FALSE';
END Is_Stat_Account;


@Override
@SecurityCheck Company.UserAuthorized(company_)
FUNCTION Get_Description (
   company_ IN VARCHAR2,
   account_ IN VARCHAR2 ) RETURN VARCHAR2
IS
BEGIN
   --Add pre-processing code here
   RETURN super(company_, account_);
END Get_Description;





@UncheckedAccess
PROCEDURE Get_Description (
  description_        IN OUT VARCHAR2,
  company_            IN     VARCHAR2,
  account_            IN     VARCHAR2 ) 
IS
BEGIN  
  description_ := Get_Description(company_, account_);
END Get_Description;


PROCEDURE Account_Exist (
   company_ IN VARCHAR2,
   accnt_type_ IN VARCHAR2 )
IS
   dummy_   NUMBER;
   CURSOR check_account IS
      SELECT 1
      FROM   ACCOUNTING_CODE_PART_VALUE_TAB
      WHERE company = company_
      AND   code_part = 'A'
      AND   accnt_type  = accnt_type_;
BEGIN
   OPEN check_account;
   FETCH check_account INTO dummy_;
   IF (check_account%FOUND) THEN
      Error_SYS.Record_General('Account', 'ACCNTTYPEEXISTS: The Logical Account Type cannot be changed since there are accounts connected to Account type :P1',accnt_type_);
      CLOSE check_account ;
   END IF;
   CLOSE check_account ;
END Account_Exist;


PROCEDURE Check_Delete_Allowed (
   company_  IN VARCHAR2,
   account_  IN VARCHAR2 )
IS
BEGIN
   Accounting_Code_Part_Value_API.Check_Delete_Allowed2 (company_,account_,'A');
END Check_Delete_Allowed;


PROCEDURE Check_Valid_From_To (
   company_     IN VARCHAR2,
   account_     IN VARCHAR2,
   valid_from_  IN DATE,
   valid_to_    IN DATE )
IS
BEGIN
   Accounting_Code_Part_Value_API.Check_Valid_From_To (company_,
                                                       'A',
                                                       account_,
                                                       valid_from_,
                                                       valid_to_);
END Check_Valid_From_To;


PROCEDURE Check_Account_Exist (
   company_ IN VARCHAR2,
   account_ IN VARCHAR2 )
IS
   dummy_ NUMBER;
   CURSOR exist_control IS
      SELECT 1
      FROM   ACCOUNTING_CODE_PART_VALUE_TAB
      WHERE  company = company_
      AND    code_part = 'A'
      AND    code_part_value = account_;
BEGIN
   OPEN exist_control;
   FETCH exist_control INTO dummy_;
   IF (exist_control%NOTFOUND) THEN
      Error_SYS.Record_Not_Exist(lu_name_);
   END IF;
   CLOSE exist_control;
END Check_Account_Exist;


@UncheckedAccess
FUNCTION Exist_Code_Part_Value (
   company_ IN VARCHAR2 ) RETURN BOOLEAN
IS
BEGIN
   RETURN Accounting_Code_Part_Value_API.Exist_Code_Part_Value (company_,'A');
END Exist_Code_Part_Value;


PROCEDURE Get_Logical_Accnt_Type (
   accnt_type_ OUT VARCHAR2,
   company_ IN VARCHAR2,
   accnt_ IN VARCHAR2 )
IS
  accnt_type_db_   VARCHAR2(20);
BEGIN
   accnt_type_db_ := Get_Accnt_Type_Db ( company_, accnt_ );
   accnt_type_ := Account_Type_Value_API.Decode(accnt_type_db_);
END Get_Logical_Accnt_Type;


@UncheckedAccess
FUNCTION Is_Budget_Account (
   company_ IN VARCHAR2,
   account_ IN VARCHAR2 ) RETURN BOOLEAN
IS
   CURSOR get_bud_account IS
      SELECT code_part_value
       FROM  ACCOUNTING_CODE_PART_VALUE_TAB
       WHERE company              = company_
       AND   code_part            = 'A'
       AND   code_part_value      = account_
       AND   NVL(bud_account,'N') = 'Y';
   bud_account_   ACCOUNTING_CODE_PART_VALUE_TAB.code_part_value%TYPE;
BEGIN
   OPEN  get_bud_account;
   FETCH get_bud_account INTO bud_account_;
   IF get_bud_account%FOUND THEN
      CLOSE get_bud_account;
      RETURN TRUE;
   END IF;
   CLOSE get_bud_account;
   RETURN FALSE;
END Is_Budget_Account;


@UncheckedAccess
FUNCTION Get_Budget_Code_Demand (
   company_    IN VARCHAR2,
   account_    IN VARCHAR2,
   code_part_  IN VARCHAR2 ) RETURN VARCHAR2
IS
   CURSOR get_code_req IS
     SELECT req_budget_code_b,
            req_budget_code_c,
            req_budget_code_d,
            req_budget_code_e,
            req_budget_code_f,
            req_budget_code_g,
            req_budget_code_h,
            req_budget_code_i,
            req_budget_code_j,
            req_budget_quantity
      FROM  accounting_code_part_value_tab
      WHERE Company = company_
      AND   Code_part_value  = account_
      AND   code_part = 'A';
   req_b_            VARCHAR2(1);
   req_c_            VARCHAR2(1);
   req_d_            VARCHAR2(1);
   req_e_            VARCHAR2(1);
   req_f_            VARCHAR2(1);
   req_g_            VARCHAR2(1);
   req_h_            VARCHAR2(1);
   req_i_            VARCHAR2(1);
   req_j_            VARCHAR2(1);
   req_quantity_     VARCHAR2(1);
BEGIN
   OPEN get_code_req;
   FETCH get_code_req INTO req_b_,
                           req_c_,
                           req_d_,
                           req_e_,
                           req_f_,
                           req_g_,
                           req_h_,
                           req_i_,
                           req_j_,
                           req_quantity_;
   CLOSE get_code_req;
   IF (code_part_ = 'B') THEN
      RETURN req_b_;
   ELSIF (code_part_ = 'C') THEN
      RETURN req_c_;
   ELSIF (code_part_ = 'D') THEN
      RETURN req_d_;
   ELSIF (code_part_ = 'E') THEN
      RETURN req_e_;
   ELSIF (code_part_ = 'F') THEN
      RETURN req_f_;
   ELSIF (code_part_ = 'G') THEN
      RETURN req_g_;
   ELSIF (code_part_ = 'H') THEN
      RETURN req_h_;
   ELSIF (code_part_ = 'I') THEN
      RETURN req_i_;
   ELSIF (code_part_ = 'J') THEN
      RETURN req_j_;
   ELSIF (code_part_ = 'QUANTITY') THEN
      RETURN req_quantity_;
   END IF;
   RETURN NULL;
END Get_Budget_Code_Demand;

PROCEDURE Is_Tax_Account (
   result_       OUT VARCHAR2,
   company_      IN VARCHAR2,
   accnt_        IN VARCHAR2 )
IS
   tax_flag_        ACCOUNTING_CODE_PART_VALUE_TAB.tax_flag%TYPE;
   CURSOR tax_flag IS
      SELECT tax_flag
      FROM   ACCOUNTING_CODE_PART_VALUE_TAB
      WHERE  company = company_
      AND    code_part = 'A'
      AND    code_part_value   = accnt_;
BEGIN
   OPEN tax_flag;
   FETCH tax_flag INTO tax_flag_;
   CLOSE tax_flag;
   IF tax_flag_ = 'Y' THEN
      result_ := 'TRUE';
   ELSE
      result_ := 'FALSE';
   END IF;
END Is_Tax_Account;


@UncheckedAccess
FUNCTION Is_Tax_Account (
   company_      IN VARCHAR2,
   accnt_        IN VARCHAR2 ) RETURN BOOLEAN
IS
   tax_flag_        ACCOUNTING_CODE_PART_VALUE_TAB.tax_flag%TYPE;
   CURSOR tax_flag IS
      SELECT tax_flag
      FROM   ACCOUNTING_CODE_PART_VALUE_TAB
      WHERE  company         = company_
      AND    code_part       = 'A'
      AND    code_part_value = accnt_;
BEGIN
   OPEN tax_flag;
   FETCH tax_flag INTO tax_flag_;
   CLOSE tax_flag;
   IF tax_flag_ = 'Y' THEN
      RETURN TRUE;
   END IF;
   RETURN FALSE;
END Is_Tax_Account;


PROCEDURE Get_Stat_Curr (
   stat_flag_          OUT    VARCHAR2,
   curr_balance_       OUT    VARCHAR2,
   company_            IN     VARCHAR2,
   accnt_              IN     VARCHAR2 )
IS
   stat_account_              VARCHAR2(1);
   CURSOR get_balance IS
      SELECT curr_balance,
             stat_account
      FROM   Accounting_code_part_value_tab
      WHERE  Company = company_
      AND    code_part = 'A'
      AND    code_part_value  = accnt_;
BEGIN
   OPEN get_balance;
   FETCH get_balance INTO curr_balance_, stat_account_;
   IF (get_balance%NOTFOUND) THEN
      curr_balance_ := 'N';
      stat_account_ := 'N';
   END IF;
   IF stat_account_ = 'Y' THEN
      stat_flag_ := 'TRUE';
   ELSE
      stat_flag_ := 'FALSE';
   END IF;
   CLOSE get_balance;
END Get_Stat_Curr;


@UncheckedAccess
FUNCTION Is_Tax_Code_Mandatory (
   company_ IN VARCHAR2,
   account_ IN VARCHAR2 ) RETURN BOOLEAN
IS
   temp_ ACCOUNTING_CODE_PART_VALUE_TAB.tax_code_mandatory%TYPE;
   CURSOR get_attr IS
      SELECT tax_code_mandatory
      FROM   ACCOUNTING_CODE_PART_VALUE_TAB
      WHERE  company         = company_
      AND    code_part       = 'A'
      AND    code_part_value = account_;
BEGIN
   OPEN  get_attr;
   FETCH get_attr INTO temp_;
   CLOSE get_attr;
   IF temp_ = 'TRUE' THEN
      RETURN TRUE;
   END IF;
   RETURN FALSE;
END Is_Tax_Code_Mandatory;


PROCEDURE New (
   objid_      OUT    VARCHAR2,
   objversion_ OUT    VARCHAR2,
   newrec_     IN OUT ACCOUNTING_CODE_PART_VALUE_TAB%ROWTYPE,
   attr_       IN OUT VARCHAR2 )
IS
BEGIN
   ACCOUNT_API.Insert___(objid_, objversion_, newrec_, attr_);
END New;


PROCEDURE Validate_Cons_Account (
   rec_ IN ACCOUNTING_CODE_PART_VALUE_TAB%ROWTYPE )
IS
BEGIN
   ACCOUNT_API.Validate_Cons_Account___(rec_);
END Validate_Cons_Account;


PROCEDURE Validate_Insert_Modify (
   newrec_ IN ACCOUNTING_CODE_PART_VALUE_TAB%ROWTYPE,
   mode_   IN VARCHAR2 )
IS
BEGIN
   ACCOUNT_API.Validate_Insert_Modify___(newrec_, mode_);
END Validate_Insert_Modify;


FUNCTION Is_Codepart_Blocked (
   company_            IN VARCHAR2,
   code_part_          IN VARCHAR2 ) RETURN VARCHAR2
IS
   cnt_                NUMBER;
   found_              VARCHAR2(5);
   CURSOR code_b_blocked is
      SELECT 1 FROM accounting_code_part_value_tab WHERE company = company_ AND req_code_b != 'S';
   CURSOR code_c_blocked is
      SELECT 1 FROM accounting_code_part_value_tab WHERE company = company_ AND req_code_c != 'S';
   CURSOR code_d_blocked is
      SELECT 1 FROM accounting_code_part_value_tab WHERE company = company_ AND req_code_d != 'S';
   CURSOR code_e_blocked is
      SELECT 1 FROM accounting_code_part_value_tab WHERE company = company_ AND req_code_e != 'S';
   CURSOR code_f_blocked is
      SELECT 1 FROM accounting_code_part_value_tab WHERE company = company_ AND req_code_f != 'S';
   CURSOR code_g_blocked is
      SELECT 1 FROM accounting_code_part_value_tab WHERE company = company_ AND req_code_g != 'S';
   CURSOR code_h_blocked is
      SELECT 1 FROM accounting_code_part_value_tab WHERE company = company_ AND req_code_h != 'S';
   CURSOR code_i_blocked is
      SELECT 1 FROM accounting_code_part_value_tab WHERE company = company_ AND req_code_i != 'S';
   CURSOR code_j_blocked is
      SELECT 1 FROM accounting_code_part_value_tab WHERE company = company_ AND req_code_j != 'S';
BEGIN
   IF (code_part_ = 'B') THEN
      OPEN code_b_blocked;
      FETCH code_b_blocked INTO cnt_;
      IF (code_b_blocked%FOUND) THEN
         found_ := 'TRUE';
      ELSE
         found_ := 'FALSE';
      END IF;
      CLOSE code_b_blocked;
   ELSIF (code_part_ = 'C') THEN
      OPEN code_c_blocked;
      FETCH code_c_blocked INTO cnt_;
      IF (code_c_blocked%FOUND) THEN
         found_ := 'TRUE';
      ELSE
         found_ := 'FALSE';
      END IF;
      CLOSE code_c_blocked;
   ELSIF (code_part_ = 'D') THEN
      OPEN code_d_blocked;
      FETCH code_d_blocked INTO cnt_;
      IF (code_d_blocked%FOUND) THEN
         found_ := 'TRUE';
      ELSE
         found_ := 'FALSE';
      END IF;
      CLOSE code_d_blocked;
   ELSIF (code_part_ = 'E') THEN
      OPEN code_e_blocked;
      FETCH code_e_blocked INTO cnt_;
      IF (code_e_blocked%FOUND) THEN
         found_ := 'TRUE';
      ELSE
         found_ := 'FALSE';
      END IF;
      CLOSE code_e_blocked;
   ELSIF (code_part_ = 'F') THEN
      OPEN code_f_blocked;
      FETCH code_f_blocked INTO cnt_;
      IF (code_f_blocked%FOUND) THEN
         found_ := 'TRUE';
      ELSE
         found_ := 'FALSE';
      END IF;
      CLOSE code_f_blocked;
   ELSIF (code_part_ = 'G') THEN
      OPEN code_g_blocked;
      FETCH code_g_blocked INTO cnt_;
      IF (code_g_blocked%FOUND) THEN
         found_ := 'TRUE';
      ELSE
         found_ := 'FALSE';
      END IF;
      CLOSE code_g_blocked;
   ELSIF (code_part_ = 'H') THEN
      OPEN code_h_blocked;
      FETCH code_h_blocked INTO cnt_;
      IF (code_h_blocked%FOUND) THEN
         found_ := 'TRUE';
      ELSE
         found_ := 'FALSE';
      END IF;
      CLOSE code_h_blocked;
   ELSIF (code_part_ = 'I') THEN
      OPEN code_i_blocked;
      FETCH code_i_blocked INTO cnt_;
      IF (code_i_blocked%FOUND) THEN
         found_ := 'TRUE';
      ELSE
         found_ := 'FALSE';
      END IF;
      CLOSE code_i_blocked;
   ELSIF (code_part_ = 'J') THEN
      OPEN code_j_blocked;
      FETCH code_j_blocked INTO cnt_;
      IF (code_j_blocked%FOUND) THEN
         found_ := 'TRUE';
      ELSE
         found_ := 'FALSE';
      END IF;
      CLOSE code_j_blocked;
   END IF;
   RETURN found_;
END Is_Codepart_Blocked;


FUNCTION Is_Codepart_Blocked (
   company_            IN VARCHAR2,
   account_            IN VARCHAR2,
   code_part_          IN VARCHAR2 ) RETURN VARCHAR2
IS
   cnt_                NUMBER;
   found_              VARCHAR2(5);
   CURSOR code_b_blocked is
      SELECT 1 FROM accounting_code_part_value_tab WHERE company = company_ AND code_part_value = account_ and REQ_CODE_B = 'S';
   CURSOR code_c_blocked is
      SELECT 1 FROM accounting_code_part_value_tab WHERE company = company_ AND code_part_value = account_ and REQ_CODE_C = 'S';
   CURSOR code_d_blocked is
      SELECT 1 FROM accounting_code_part_value_tab WHERE company = company_ AND code_part_value = account_ and REQ_CODE_D = 'S';
   CURSOR code_e_blocked is
      SELECT 1 FROM accounting_code_part_value_tab WHERE company = company_ AND code_part_value = account_ and REQ_CODE_E = 'S';
   CURSOR code_f_blocked is
      SELECT 1 FROM accounting_code_part_value_tab WHERE company = company_ AND code_part_value = account_ and REQ_CODE_F = 'S';
   CURSOR code_g_blocked is
      SELECT 1 FROM accounting_code_part_value_tab WHERE company = company_ AND code_part_value = account_ and REQ_CODE_G = 'S';
   CURSOR code_h_blocked is
      SELECT 1 FROM accounting_code_part_value_tab WHERE company = company_ AND code_part_value = account_ and REQ_CODE_H = 'S';
   CURSOR code_i_blocked is
      SELECT 1 FROM accounting_code_part_value_tab WHERE company = company_ AND code_part_value = account_ and REQ_CODE_I = 'S';
   CURSOR code_j_blocked is
      SELECT 1 FROM accounting_code_part_value_tab WHERE company = company_ AND code_part_value = account_ and REQ_CODE_J = 'S';
   CURSOR qty_blocked is
      SELECT 1 FROM accounting_code_part_value_tab WHERE company = company_ AND code_part_value = account_ and REQ_QUANTITY   = 'S';
BEGIN
   IF (code_part_ = 'B') THEN
      OPEN code_b_blocked;
      FETCH code_b_blocked INTO cnt_;
      IF (code_b_blocked%FOUND) THEN
         found_ := 'TRUE';
      ELSE
         found_ := 'FALSE';
      END IF;
      CLOSE code_b_blocked;
   ELSIF (code_part_ = 'C') THEN
      OPEN code_c_blocked;
      FETCH code_c_blocked INTO cnt_;
      IF (code_c_blocked%FOUND) THEN
         found_ := 'TRUE';
      ELSE
         found_ := 'FALSE';
      END IF;
      CLOSE code_c_blocked;
   ELSIF (code_part_ = 'D') THEN
      OPEN code_d_blocked;
      FETCH code_d_blocked INTO cnt_;
      IF (code_d_blocked%FOUND) THEN
         found_ := 'TRUE';
      ELSE
         found_ := 'FALSE';
      END IF;
      CLOSE code_d_blocked;
   ELSIF (code_part_ = 'E') THEN
      OPEN code_e_blocked;
      FETCH code_e_blocked INTO cnt_;
      IF (code_e_blocked%FOUND) THEN
         found_ := 'TRUE';
      ELSE
         found_ := 'FALSE';
      END IF;
      CLOSE code_e_blocked;
   ELSIF (code_part_ = 'F') THEN
      OPEN code_f_blocked;
      FETCH code_f_blocked INTO cnt_;
      IF (code_f_blocked%FOUND) THEN
         found_ := 'TRUE';
      ELSE
         found_ := 'FALSE';
      END IF;
      CLOSE code_f_blocked;
   ELSIF (code_part_ = 'G') THEN
      OPEN code_g_blocked;
      FETCH code_g_blocked INTO cnt_;
      IF (code_g_blocked%FOUND) THEN
         found_ := 'TRUE';
      ELSE
         found_ := 'FALSE';
      END IF;
      CLOSE code_g_blocked;
   ELSIF (code_part_ = 'H') THEN
      OPEN code_h_blocked;
      FETCH code_h_blocked INTO cnt_;
      IF (code_h_blocked%FOUND) THEN
         found_ := 'TRUE';
      ELSE
         found_ := 'FALSE';
      END IF;
      CLOSE code_h_blocked;
   ELSIF (code_part_ = 'I') THEN
      OPEN code_i_blocked;
      FETCH code_i_blocked INTO cnt_;
      IF (code_i_blocked%FOUND) THEN
         found_ := 'TRUE';
      ELSE
         found_ := 'FALSE';
      END IF;
      CLOSE code_i_blocked;
   ELSIF (code_part_ = 'J') THEN
      OPEN code_j_blocked;
      FETCH code_j_blocked INTO cnt_;
      IF (code_j_blocked%FOUND) THEN
         found_ := 'TRUE';
      ELSE
         found_ := 'FALSE';
      END IF;
      CLOSE code_j_blocked;
   ELSIF (code_part_ = 'QUANTITY') THEN
      OPEN qty_blocked;
      FETCH qty_blocked INTO cnt_;
      IF (qty_blocked%FOUND) THEN
         found_ := 'TRUE';
      ELSE
         found_ := 'FALSE';
      END IF;
      CLOSE qty_blocked;
   END IF;
   RETURN found_;
END Is_Codepart_Blocked;


FUNCTION Is_Ledger_Tax_Account(
   company_            IN VARCHAR2,
   account_            IN VARCHAR2) RETURN VARCHAR2
IS
   result_ VARCHAR2(10);
BEGIN
   Is_Tax_Account(result_,company_,account_);
   IF result_ = 'TRUE' THEN
      RETURN 'TRUE';
   ELSE
      RETURN 'FALSE';
   END IF;
END Is_Ledger_Tax_Account;


@UncheckedAccess
FUNCTION Get_Required_Code_Parts (
   company_       IN  VARCHAR2,
   accnt_         IN  VARCHAR2 ) RETURN Accounting_Codestr_API.CodestrRec
IS
   req_rec_       Accounting_Codestr_API.CodestrRec;
   CURSOR get_req IS
      SELECT req_code_b,
             req_code_c,
             req_code_d,
             req_code_e,
             req_code_f,
             req_code_g,
             req_code_h,
             req_code_i,
             req_code_j,
             req_quantity,
             req_process_code,
             req_text
      FROM   accounting_code_part_value_tab
      WHERE  Company          = company_
      AND    Code_part_value  = accnt_
      AND    code_part        = 'A';
   
   required_rec_  get_req%ROWTYPE;
   
BEGIN
   OPEN get_req;
   FETCH get_req INTO required_rec_ ;
   CLOSE get_req;

   req_rec_.code_b       := required_rec_.req_code_b;
   req_rec_.code_c       := required_rec_.req_code_c;
   req_rec_.code_d       := required_rec_.req_code_d;
   req_rec_.code_e       := required_rec_.req_code_e;
   req_rec_.code_f       := required_rec_.req_code_f;
   req_rec_.code_g       := required_rec_.req_code_g;
   req_rec_.code_h       := required_rec_.req_code_h;
   req_rec_.code_i       := required_rec_.req_code_i;
   req_rec_.code_j       := required_rec_.req_code_j;
   req_rec_.process_code := required_rec_.req_process_code;
   req_rec_.text         := required_rec_.req_text;
   
   RETURN req_rec_;
END Get_Required_Code_Parts;


@UncheckedAccess
FUNCTION Get_Exclude_Proj_Followup (
   company_ IN VARCHAR2,
   account_ IN VARCHAR2 ) RETURN VARCHAR2
IS
   temp_ ACCOUNTING_CODE_PART_VALUE_TAB.exclude_proj_followup%TYPE;
   CURSOR get_attr IS
      SELECT exclude_proj_followup
      FROM ACCOUNTING_CODE_PART_VALUE_TAB
      WHERE company = company_
      AND   code_part = 'A'
      AND   code_part_value = account_;
BEGIN
   OPEN get_attr;
   FETCH get_attr INTO temp_;
   CLOSE get_attr;
   RETURN temp_;
END Get_Exclude_Proj_Followup;

PROCEDURE Get_Control_Type_Value_Desc (
   description_   OUT VARCHAR2,
   company_       IN  VARCHAR2,
   account_       IN  VARCHAR2)
IS
BEGIN
   description_ := ACCOUNT_API.Get_Description(company_, account_);
END Get_Control_Type_Value_Desc;


PROCEDURE Prepare_Codepart_Demands (
   attr_          IN OUT VARCHAR2,
   company_       IN     VARCHAR2,
   accnt_type_    IN     VARCHAR2 )
IS
   default_code_b_       VARCHAR2(1);
   default_code_c_       VARCHAR2(1);
   default_code_d_       VARCHAR2(1);
   default_code_e_       VARCHAR2(1);
   default_code_f_       VARCHAR2(1);
   default_code_g_       VARCHAR2(1);
   default_code_h_       VARCHAR2(1);
   default_code_i_       VARCHAR2(1);
   default_code_j_       VARCHAR2(1);
   default_quantity_     VARCHAR2(1);
   default_text_         VARCHAR2(1);
   default_process_code_ VARCHAR2(1);
   default_bud_code_b_   VARCHAR2(1);
   default_bud_code_c_   VARCHAR2(1);
   default_bud_code_d_   VARCHAR2(1);
   default_bud_code_e_   VARCHAR2(1);
   default_bud_code_f_   VARCHAR2(1);
   default_bud_code_g_   VARCHAR2(1);
   default_bud_code_h_   VARCHAR2(1);
   default_bud_code_i_   VARCHAR2(1);
   default_bud_code_j_   VARCHAR2(1);
   default_bud_quantity_ VARCHAR2(1);

   codepart_blocked_    ACCOUNT_CODE_A.req_code_b%TYPE;
BEGIN
   codepart_blocked_ := Account_Request_API.Decode('S');
   
   IF (accnt_type_ IS NOT NULL) THEN
      Account_Type_API.Get_Default_Codepart_Demands_(default_code_b_, default_code_c_, default_code_d_,
                                                     default_code_e_, default_code_f_, default_code_g_,
                                                     default_code_h_, default_code_i_, default_code_j_,
                                                     default_quantity_, default_text_, default_process_code_,
                                                     default_bud_code_b_, default_bud_code_c_, default_bud_code_d_,
                                                     default_bud_code_e_, default_bud_code_f_, default_bud_code_g_,
                                                     default_bud_code_h_, default_bud_code_i_, default_bud_code_j_,
                                                     default_bud_quantity_, company_, accnt_type_);
       
      Client_SYS.Add_To_Attr('REQ_CODE_B_DB',   default_code_b_, attr_);
      Client_SYS.Add_To_Attr('REQ_CODE_C_DB',   default_code_c_, attr_);
      Client_SYS.Add_To_Attr('REQ_CODE_D_DB',   default_code_d_, attr_);
      Client_SYS.Add_To_Attr('REQ_CODE_E_DB',   default_code_e_, attr_);
      Client_SYS.Add_To_Attr('REQ_CODE_F_DB',   default_code_f_, attr_);
      Client_SYS.Add_To_Attr('REQ_CODE_G_DB',   default_code_g_, attr_);
      Client_SYS.Add_To_Attr('REQ_CODE_H_DB',   default_code_h_, attr_);
      Client_SYS.Add_To_Attr('REQ_CODE_I_DB',   default_code_i_, attr_);
      Client_SYS.Add_To_Attr('REQ_CODE_J_DB',   default_code_j_, attr_);
      Client_SYS.Add_To_Attr('REQ_QUANTITY_DB', default_quantity_, attr_);
      Client_SYS.Add_To_Attr('REQ_TEXT_DB',     default_text_, attr_);
      Client_SYS.Add_To_Attr('REQ_PROCESS_CODE_DB',   default_process_code_, attr_);
      Client_SYS.Add_To_Attr('REQ_BUDGET_CODE_B_DB',   default_bud_code_b_, attr_);
      Client_SYS.Add_To_Attr('REQ_BUDGET_CODE_C_DB',   default_bud_code_c_, attr_);
      Client_SYS.Add_To_Attr('REQ_BUDGET_CODE_D_DB',   default_bud_code_d_, attr_);
      Client_SYS.Add_To_Attr('REQ_BUDGET_CODE_E_DB',   default_bud_code_e_, attr_);
      Client_SYS.Add_To_Attr('REQ_BUDGET_CODE_F_DB',   default_bud_code_f_, attr_);
      Client_SYS.Add_To_Attr('REQ_BUDGET_CODE_G_DB',   default_bud_code_g_, attr_);
      Client_SYS.Add_To_Attr('REQ_BUDGET_CODE_H_DB',   default_bud_code_h_, attr_);
      Client_SYS.Add_To_Attr('REQ_BUDGET_CODE_I_DB',   default_bud_code_i_, attr_);
      Client_SYS.Add_To_Attr('REQ_BUDGET_CODE_J_DB',   default_bud_code_j_, attr_);
      Client_SYS.Add_To_Attr('REQ_BUDGET_QUANTITY_DB', default_bud_quantity_, attr_);
   ELSE
      Client_SYS.Add_To_Attr('REQ_CODE_B',   codepart_blocked_, attr_);
      Client_SYS.Add_To_Attr('REQ_CODE_C',   codepart_blocked_, attr_);
      Client_SYS.Add_To_Attr('REQ_CODE_D',   codepart_blocked_, attr_);
      Client_SYS.Add_To_Attr('REQ_CODE_E',   codepart_blocked_, attr_);
      Client_SYS.Add_To_Attr('REQ_CODE_F',   codepart_blocked_, attr_);
      Client_SYS.Add_To_Attr('REQ_CODE_G',   codepart_blocked_, attr_);
      Client_SYS.Add_To_Attr('REQ_CODE_H',   codepart_blocked_, attr_);
      Client_SYS.Add_To_Attr('REQ_CODE_I',   codepart_blocked_, attr_);
      Client_SYS.Add_To_Attr('REQ_CODE_J',   codepart_blocked_, attr_);
      Client_SYS.Add_To_Attr('REQ_QUANTITY', Account_Request_Text_API.Decode('K'), attr_);
      Client_SYS.Add_To_Attr('REQ_TEXT',     Account_Request_Text_API.Decode('K'), attr_);
      Client_SYS.Add_To_Attr('REQ_PROCESS_CODE',   Account_Request_API.Decode('K'), attr_);
      Client_SYS.Add_To_Attr('REQ_BUDGET_CODE_B',   codepart_blocked_, attr_);
      Client_SYS.Add_To_Attr('REQ_BUDGET_CODE_C',   codepart_blocked_, attr_);
      Client_SYS.Add_To_Attr('REQ_BUDGET_CODE_D',   codepart_blocked_, attr_);
      Client_SYS.Add_To_Attr('REQ_BUDGET_CODE_E',   codepart_blocked_, attr_);
      Client_SYS.Add_To_Attr('REQ_BUDGET_CODE_F',   codepart_blocked_, attr_);
      Client_SYS.Add_To_Attr('REQ_BUDGET_CODE_G',   codepart_blocked_, attr_);
      Client_SYS.Add_To_Attr('REQ_BUDGET_CODE_H',   codepart_blocked_, attr_);
      Client_SYS.Add_To_Attr('REQ_BUDGET_CODE_I',   codepart_blocked_, attr_);
      Client_SYS.Add_To_Attr('REQ_BUDGET_CODE_J',   codepart_blocked_, attr_);
      Client_SYS.Add_To_Attr('REQ_BUDGET_QUANTITY', codepart_blocked_, attr_);
   END IF;
END Prepare_Codepart_Demands;


@UncheckedAccess
FUNCTION Get_Tax_Code_Mandatory (
   company_ IN VARCHAR2,
   account_ IN VARCHAR2 ) RETURN VARCHAR2
IS
   temp_ ACCOUNTING_CODE_PART_VALUE_TAB.tax_code_mandatory%TYPE;
   CURSOR get_attr IS
      SELECT tax_code_mandatory
      FROM ACCOUNTING_CODE_PART_VALUE_TAB
      WHERE company = company_
      AND   code_part = 'A'
      AND   code_part_value = account_;
BEGIN
   OPEN get_attr;
   FETCH get_attr INTO temp_;
   CLOSE get_attr;
   RETURN temp_;
END Get_Tax_Code_Mandatory;


@UncheckedAccess
FUNCTION Validate_Account_Rec(
   company_            IN     VARCHAR2,
   accnt_              IN     VARCHAR2,
   date_               IN     DATE ) RETURN Val_Account_Rec
IS
   tdate_                     DATE;
   rec_                       Val_Account_Rec;
   CURSOR get_balance IS
      SELECT curr_balance,
             nvl(req_code_b,' ') ||
             nvl(req_code_c,' ') ||
             nvl(req_code_d,' ') ||
             nvl(req_code_e,' ') ||
             nvl(req_code_f,' ') ||
             nvl(req_code_g,' ') ||
             nvl(req_code_h,' ') ||
             nvl(req_code_i,' ') ||
             nvl(req_code_j,' ') ||
             nvl(req_quantity,' ') ||
             nvl(req_process_code,' ') ||
             nvl(req_text,' ') req_string_
      FROM   Accounting_code_part_value_tab
      WHERE  company         = company_
      AND    code_part       = 'A'
      AND    code_part_value = accnt_
      AND    tdate_          BETWEEN valid_from AND valid_until;
BEGIN
   tdate_ := trunc(date_);
   OPEN get_balance;
   FETCH get_balance INTO rec_.curr_balance, rec_.req_string;
   IF (get_balance%NOTFOUND) THEN
      rec_.val_result   := 'FALSE';
      rec_.curr_balance := 'N';
   ELSE
      rec_.val_result   := 'TRUE';
   END IF;
   CLOSE get_balance;
   RETURN rec_;
END Validate_Account_Rec;  



