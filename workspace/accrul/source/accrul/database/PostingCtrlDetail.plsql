-----------------------------------------------------------------------------
--
--  Logical unit: PostingCtrlDetail
--  Component:    ACCRUL
--
--  IFS Developer Studio Template Version 3.0
--
--  Date    Sign    History
--  ------  ------  ---------------------------------------------------------
--  960313  MIJO    Created.
--  970627  SLKO    Converted to Foundation 1.2.2d
--  980205  MALR    Update of Default Data, added code in Generate_Default_Data_.
--  980429  THUS    Added one new procedure to validate if account exists
--  990416  JPS     Performed Template Changes.(Foundation 2.2.1)
--  991020  JPS     Corrected Bug # 63704.
--  991220  SaCh    Removed protected procedure Get_Codepart_Value.
--  000105  SaCh    Added protected procedure Get_Codepart_Value.
--  000125  Uma     Global Date Definition. 
--  000217  Uma     Corrected Bug Id# 32139.
--  000309  Uma     Closed dynamic cursors in Exceptions.
--  000414  SaCh    Added RAISE to exceptions.
--  000705  LeKa    A521: Added tax_flag.
--  000914  HiMu    Added General_SYS.Init_Method                              
--  001005  prtilk  BUG # 15677  Checked General_SYS.Init_Method 
--  001024  LiSv    Call #50936 Corrected. Couldn't use deductible tax codes for posting type IP3 and PP18.
--  211100  SAABLK  Bug # 18405 recorrected.
--  160701  SUMALK  Bug 22932 Fixed. Removed dynamic sql and added Execute Immediate.
--  010917  GAWILK  Bug # 24355 fixed. Checked for overlapping periods.
--  010917  LiSv    Bug #21794 Corrected. Removed procedure Validate_Record___ it is not used anymore.
--  020219  Asodse  Date 020208 IID 21003 Company Translation, Replaced "Text Field Translation"
--  020320  Uma     Merged Bug #27845. PP44 is allowed even when part of it is non deductible.
--  021002  Nimalk  Removed usage of the view Company_Finance_Auth in POSTING_CTRL_DETAIL view 
--                  and replaced by view Company_Finance_Auth1 using EXISTS caluse instead of joins
--  030130  mgutse  Bug 93462 (Salsa). Exist control for IC7 Income Type must have currency code as parameter.
--  030218  mgutse  Bug 94216 (Salsa). Use Exist_Deductible in Exist control for AC7 when PP48 or PP49.
--  030225  mgutse  Bug 94305. New key in LU IncomeType. 
--  030305  mgutse  Bug 94305. New key in LU Type1099. 
--  030306  Ravilk  Added procedure 'Get_Code_Part_Value'.
--  041216  Saahlk  LCS Patch Merge, Bug 47056.
--  050523  reanpl  FIAD376 Actual Costing - added pc_valid_from column, removed valid_until
--  051123  nijalk  Modified Validate_Control_Type_Value__.
--  060214  Nalslk  LCS Merge 50682, modified method Validate_Control_Type_Value__ to support deductible tax for
--                  posting controls IP9 and IP10
--  060612  Iswalk  FIPL614A, Added spec_ctrl_type_category and removed spec_combined_control_type.
--  060613  Iswalk  FIPL614A, Replaced hard coded values, AC1, AC2 and C58 with ctrl_type_category.
--  060615  Rufelk  FIPL614A - Restricted FIXED control types as Specification Control Types.
--  060619  Rufelk  FIPL614A - Removed allowed_default and used ctrl_type_category instead.
--  060925  THAYLK  LCS Merge Bug 59300, Added functions Is_Led_Account_Used and Is_Tax_Account_Used
--  061109  NuFilk  FIPL609A - Modified method Validate_Control_Type_Value__.
--  061120  NuFilk  FIPL609A - Modified method Validate_Control_Type_Value__.
--  070104  GaDaLK  FIPL659A - Modified calls to Posting_Ctrl_Control_Type_API.Get_Description(2) in POSTING_CTRL_DETAIL 
--  070105  Shsalk  LCS Merge 61873, Corrected.Added NOCHECK for code_part_value in view POSTING_CTRL_DETAIL
--  070222  NuFilk  FIPL609B - Modified method Validate_Control_Type_Value__.
--  070320  Shsalk  LCS Merge 63645, Corrected.Added validation for the statistical account in unpack_check_insert
--                  and unpack_check_update.
--  070912  Shsalk  B148647 Made an error message more descriptive.
--  071102  cldase  IID 75DEV-Fin12 (Bug 68473) - Added a check for control_type AC21 in Unpack_Check_Insert()
--  071203  Maselk  Bug 67620, Corrected. Modified view comments of POSTING_CTRL_DETAIL.
--  080811  AsHelk  Bug 75985, Corrected.
--  080828  AsHelk  Bug 75985, Additional Corrections.
--  090717  ErFelk  Bug 83174, Replaced SPECNOLEDGACCNT with NOLEDGACCNT and SPECSTATACC with STATACC in Validate_Specification___.
--  090929  AjPelk  EAST-250,  spec_control_type ref parameter , spec_code_part removed and add code_part instead
--  100104  HimRlk  EAST-1822, Added ref parameter to module column to PostingCtrlControlType.
--  100423  SaFalk  Modified REF for spec_control_type in POSTING_CTRL_DETAIL.
--  100716  Umdolk  EANE-2936, Reverse engineering - added ref to PostingCtrl and Removed method Delete_Posting_Detail_.
--  100623  Mawelk  Bug 91384 Corrected. Modified method Validate_Control_Type_Value__.
--  100906  JoAnSE  WDPECK-1233, Added special case for INDIRECT_JOB_API in Validate_Control_Type_Value__
--  110217  Vwloza  Updated Validate_Control_Type_Value__ with exist function for PROJ_RESOURCE_GROUP_API.
--  111020  ovjose  Added no_code_part_value
--  120214  Hawalk  SFI-2334, Merged bug 100135, Modifed Exist_Value__(), Validate_Control_Type_Value__() with the addition of valid_from_
--  120214          (to support report codes from project reporting) and insert and update routines changed accordingly (75 correction done
--  120214          by Kanslk).
--  120215  Hawalk  SFI-2334, Merged bug 100135, Inside Validate_Control_Type_Value__(), included the check for 'REPORT_COST_API', to rid 
--  120215          Exist_Value__() of package name checks. This part of the correction differs from 75, where the latter method contains 
--  120215          package name checks.
--  120228  PRatlk  Introduced new method Remove_Posting_Control_Detail
--  120329  Najylk  EASTRTM-7016, Modified Validate_Control_Type_Value__ 
--  120514  SALIDE   EDEL-698, Added VIEW_AUDIT
--  130724  Shedlk  Bug 111335, Corrected in Validate_Control_Type_Value__. Added condition for ROLE_TO_SITE_AP
--  130930  MEALLK   MASU-60, modified code in Validate_Control_Type_Value__ and Exist_Value__
--  140303  Mawelk  PBFI-5116 (Lcs Bug Id 114586)
--  140422  THPELK  PBFI-4377 (Lcs Bug Id 113342)
--  150707  DAWELK  ANPJ-757, Modified Validate_Control_Type_Value__(), to change the procedure, when the package is project_invoice_util_api.
-----------------------------------------------------------------------------

layer Core;

-------------------- PUBLIC DECLARATIONS ------------------------------------


-------------------- PRIVATE DECLARATIONS -----------------------------------


-------------------- LU SPECIFIC IMPLEMENTATION METHODS ---------------------

PROCEDURE Get_Extern_Lov___ (
   lov_               OUT VARCHAR2,
   pkg_               OUT VARCHAR2,
   package_name_   IN     VARCHAR2,
   procedure_name_ IN     VARCHAR2,
   inpar1_         IN     VARCHAR2 )
IS
   --
   block_      VARCHAR2(300);
   outpar1_    VARCHAR2(500);
   outpar2_    VARCHAR2(500);
   bindinpar1_ VARCHAR2(100) := inpar1_;
BEGIN
   Assert_SYS.Assert_Is_Package_Method(package_name_,procedure_name_);
   block_ := 'BEGIN ' || package_name_ || '.' || procedure_name_ || '( ';
   block_ := block_ || ':output1_';
   block_ := block_ || ',:output2_';
   block_ := block_ || ', :bindinpar1_';
   block_ := block_ || ' ); END;';
   @ApproveDynamicStatement(2005-11-11,shsalk)
   EXECUTE IMMEDIATE block_ using IN OUT bindinpar1_,IN OUT outpar1_, IN OUT outpar2_;

   lov_ := outpar1_;
   pkg_ := outpar2_;
EXCEPTION
   WHEN OTHERS THEN
   RAISE;            
END Get_Extern_Lov___;


PROCEDURE Validate_Specification___ (
   newrec_ IN POSTING_CTRL_DETAIL_TAB%ROWTYPE )
IS
   description_     VARCHAR2(200);
   module_          VARCHAR2(20);
   ledg_flag_       VARCHAR2(1);
   tax_flag_        VARCHAR2(1);
   default_value_   VARCHAR2(20);
   b_flag_          BOOLEAN;
BEGIN
   IF newrec_.control_type = newrec_.spec_control_type THEN
      Error_SYS.Record_General(lu_name_, 'SPECDIFCTRL: Specification control type should be different then general control type.');
   END IF;
   IF (newrec_.spec_ctrl_type_category IN ('FIXED', 'PREPOSTING')) THEN
      Error_SYS.Record_General(lu_name_, 'SPECPREPOST: Control types of :P1 and :P2 categories are not allowed as specification control types.', Ctrl_Type_Category_API.Decode('FIXED'), Ctrl_Type_Category_API.Decode('PREPOSTING'));
   END IF;

   b_flag_ := Ctrl_Type_Allowed_Value_API.Validate_Allowed_Comb__(newrec_.company, 
                                                                  newrec_.posting_type, 
                                                                  newrec_.spec_module, 
                                                                  newrec_.spec_control_type, 
                                                                  newrec_.code_part, 
                                                                  Ctrl_Type_Category_API.Decode(newrec_.spec_ctrl_type_category)); 

   IF (NOT b_flag_) THEN
      Error_SYS.Record_General(lu_name_, 
                               'SPECINVCOMB: Invalid combination for posting type :P1 code part :P2 and control type :P3',
                               newrec_.posting_type, 
                               newrec_.code_part, 
                               newrec_.spec_control_type);
   END IF;

   IF (newrec_.spec_default_value IS NULL) THEN
      IF (newrec_.spec_ctrl_type_category = 'FIXED') THEN
         Error_SYS.Record_General(lu_name_, 'SPECNO1: Specification default value must be entered.');
      END IF;
   ELSE
      IF (newrec_.spec_ctrl_type_category = 'PREPOSTING') THEN
         Error_SYS.Record_General(lu_name_, 'SPECNO2: It is not valid to enter specification default value.');
      END IF;
   END IF;

   Posting_Ctrl_Posting_Type_API.Get_Posting_Type_Attri_ ( description_, module_, ledg_flag_, tax_flag_, newrec_.posting_type );

   FOR i_ IN 1..2 LOOP
      IF i_ = 1 THEN
         default_value_ := newrec_.spec_default_value;
      ELSE
         default_value_ := newrec_.spec_default_value_no_ct;
      END IF;
      IF default_value_ IS NOT NULL THEN
         IF (newrec_.code_part = 'A') THEN
            Account_API.Exist(newrec_.company, default_value_);
            IF ledg_flag_ = 'Y' THEN
               IF (NOT ACCOUNTING_CODE_PART_A_API.Is_Ledger_Account( newrec_.company, default_value_ )) THEN
                  Error_SYS.Record_General(lu_name_, 'NOLEDGACCNT: :P1 is not a ledger account and therefore it is not valid for posting type :P2', default_value_,newrec_.posting_type);
               END IF;
            ELSIF tax_flag_ = 'Y' THEN
               IF (NOT Account_API.Is_Tax_Account( newrec_.company, default_value_ )) THEN
                  Error_SYS.Record_General(lu_name_, 'SPECNOTAXACCNT: Account :P1 is not a tax account and therefore it is not valid for posting type :P2', default_value_,newrec_.posting_type);
               END IF;
            ELSIF (ACCOUNTING_CODE_PART_A_API.Is_Stat_Account(newrec_.company, default_value_ )) = 'TRUE' THEN
               Error_SYS.Record_General(lu_name_, 'STATACC: :P1 is a statistical account and not valid for posting type :P2', default_value_,newrec_.posting_type);
            END IF;
         ELSE
            Accounting_Code_Part_Value_API.Exist(newrec_.company, newrec_.code_part, default_value_);
         END IF;
      END IF;
   END LOOP;
END Validate_Specification___;


FUNCTION Get_Column_Trans___
   (item_      IN VARCHAR2) RETURN VARCHAR2
IS
BEGIN
   -- Should not use the protected method in Language_SYS but until a public method the protected method is used.
   RETURN Language_SYS.Translate_Item_Prompt_(lu_name_, Upper(item_));
END Get_Column_Trans___;


@Override
PROCEDURE Prepare_Insert___ (
   attr_  IN OUT VARCHAR2 )
IS
BEGIN
   super(attr_);
   Client_SYS.Add_To_Attr('NO_CODE_PART_VALUE_DB', 'FALSE', attr_);
END Prepare_Insert___;


-- Check_Exist___
--   Check if a specific LU-instance already exist in the database.
FUNCTION Check_Exist___ (
   company_            IN VARCHAR2,
   code_part_          IN VARCHAR2,
   posting_type_       IN VARCHAR2,
   pc_valid_from_      IN DATE,
   control_type_value_ IN VARCHAR2,
   valid_from_         IN DATE,
   code_part_value_    IN VARCHAR2   ) RETURN BOOLEAN
IS
   dummy_ NUMBER;
   CURSOR exist_control IS
      SELECT 1
      FROM   POSTING_CTRL_DETAIL_TAB
      WHERE  company            = company_
      AND    code_part          = code_part_
      AND    posting_type       = posting_type_
      AND    pc_valid_from      = pc_valid_from_
      AND    control_type_value = control_type_value_
      AND   valid_from = valid_from_
      AND   code_part_value     = code_part_value_;
BEGIN
   OPEN  exist_control;
   FETCH exist_control INTO dummy_;
   IF (exist_control%FOUND) THEN
      CLOSE exist_control;
      RETURN(TRUE);
   END IF;
   CLOSE exist_control;
   RETURN(FALSE);
END Check_Exist___;


@Override
PROCEDURE Check_Insert___ (
   newrec_ IN OUT posting_ctrl_detail_tab%ROWTYPE,
   indrec_ IN OUT Indicator_Rec,
   attr_   IN OUT VARCHAR2 )
IS
   name_                 VARCHAR2(30);
   value_                VARCHAR2(4000);
   description_          VARCHAR2(200);
   module_               VARCHAR2(20);
   ledg_flag_            VARCHAR2(1);
   tax_flag_             VARCHAR2(1); 
   internal_id_          NUMBER;
   stmt_                 VARCHAR2(1000);
BEGIN
  
   IF (newrec_.no_code_part_value IS NULL) THEN
      newrec_.no_code_part_value := 'FALSE';
      indrec_.no_code_part_value := TRUE;
   END IF;
   
   super(newrec_, indrec_, attr_);
   Posting_Ctrl_Control_Type_API.Exist(newrec_.control_type, newrec_.module);

   IF (newrec_.spec_control_type IS NULL) THEN
      -- if no_code_part_value is false and spec_control_type is null then give error
      IF (newrec_.no_code_part_value = 'FALSE') THEN
         Error_SYS.Check_Not_Null(lu_name_, 'CODE_PART_VALUE', newrec_.code_part_value);
      END IF;
   END IF;
   ------------------------------------------------------------------------
   -- Specific validation befor insert.
   -- Made by MJ.
   ------------------------------------------------------------------------
   IF (newrec_.code_part = 'A' AND newrec_.no_code_part_value = 'TRUE') THEN
      Error_SYS.Record_General(lu_name_, 
                               'NOCODEPVALALLOWED: Not allowed to use :P1 for Code Part :P2', 
                               Get_Column_Trans___('NO_CODE_PART_VALUE'),
                               Accounting_Code_Parts_API.Get_Name(newrec_.company, newrec_.code_part));
      
   END IF;

   IF (newrec_.spec_control_type IS NOT NULL AND newrec_.no_code_part_value = 'TRUE') THEN
      Error_SYS.Record_General(lu_name_, 
                               'NOCODEPVALSPEC: Not allowed to use :P1 together with :P2',
                               Get_Column_Trans___('NO_CODE_PART_VALUE'),
                               Get_Column_Trans___('SPEC_CONTROL_TYPE'));
   END IF;

   IF (newrec_.code_part_value IS NOT NULL AND newrec_.no_code_part_value = 'TRUE') THEN
      Error_SYS.Record_General(lu_name_, 
                               'CODEANDNOCODEPVAL: Not allowed to set a code part value and use :P1',
                               Get_Column_Trans___('NO_CODE_PART_VALUE'));
   END IF;
   
   IF TRUNC(newrec_.valid_from) < TRUNC(newrec_.pc_valid_from) THEN
      Error_SYS.Record_General(lu_name_, 'WRONGVALFROM: Detail Valid From date should be equal or grater than parent Valid From date.');
   END IF;

   IF (NOT Accounting_Code_Part_Value_API.Validate_Code_Part( newrec_.company, newrec_.code_part,
                                                              newrec_.code_part_value, newrec_.valid_from )) THEN    
      Error_SYS.Record_General(lu_name_, 'NOCODEPVALUE: :P1 does not exist or has invalid date', newrec_.code_part_value);
   END IF;
   
   Posting_Ctrl_Posting_Type_API.Get_Posting_Type_Attri_ ( description_, module_, ledg_flag_, tax_flag_, newrec_.posting_type ); 
   
   IF (newrec_.control_type = 'IC7') THEN
      -- Control type IC7, Income Type, needs currency code and country_code to get the internal id 
      -- that should be saved.  
      newrec_.control_type_value := Income_Type_API.Get_Internal_Income_Type(newrec_.control_type_value,
                                                                             Company_Finance_API.Get_Currency_Code(newrec_.company),
                                                                             Company_API.Get_Country_Db(newrec_.company));
   ELSIF (newrec_.control_type = 'IC8') THEN
      -- Control type IC8, Irs1099_Type_Id, needs country_code to get the internal id to save 
      stmt_ := 'BEGIN :internal_id_ := Type1099_API.Get_Internal_Type1099(:control_type_value_,
         Company_API.Get_Country_Db(:company_)); END;';
      @ApproveDynamicStatement(2005-11-11,shsalk)
      EXECUTE IMMEDIATE stmt_ using IN OUT internal_id_, newrec_.control_type_value, newrec_.company;
      newrec_.control_type_value := internal_id_;
   
   -- IID 75DEV-Fin12 (Bug 68473), begin
   ELSIF (newrec_.control_type = 'AC21') THEN
      IF (newrec_.posting_type = 'IP1') AND NOT 
          (VOUCHER_TYPE_DETAIL_API.Get_Function_Group(newrec_.company, newrec_.control_type_value) = 'I') THEN
         Error_SYS.Record_General(lu_name_, 'WRONGFUNCGR: The voucher type must be connected to function group I.');

      ELSIF (newrec_.posting_type = 'IP2' AND NOT 
             VOUCHER_TYPE_DETAIL_API.Get_Function_Group(newrec_.company, newrec_.control_type_value) = 'F') THEN
         Error_SYS.Record_General(lu_name_, 'WRONGFUNCGR2: The voucher type must be connected to function group F.');
      END IF;
   END IF;
   -- IID 75DEV-Fin12 (Bug 68473), end

   Validate_Control_Type_Value__ ( newrec_.company, newrec_.control_type_value,
                                   newrec_.control_type, newrec_.module, 
                                   newrec_.posting_type, newrec_.valid_from );

   IF newrec_.code_part_value IS NOT NULL THEN
      IF newrec_.code_part = 'A' THEN
         IF ( ledg_flag_ = 'Y' ) THEN
            IF (NOT Accounting_Code_part_A_API.Is_Ledger_Account( newrec_.company, newrec_.code_part_value )) THEN
               Error_SYS.Record_General(lu_name_, 'NOLEDGACCNT: :P1 is not a ledger account and therefore it is not valid for posting type :P2', newrec_.code_part_value,newrec_.posting_type);
            END IF;
         END IF;
         IF ( tax_flag_ = 'Y' ) THEN         
            IF (NOT Account_API.Is_Tax_Account( newrec_.company, newrec_.code_part_value )) THEN
               Error_SYS.Record_General(lu_name_, 'NOTAXACCNT: :P1 is not a tax account and therefore it is not valid for posting type :P2', newrec_.code_part_value,newrec_.posting_type);
            END IF;
         END IF;   
         IF (ACCOUNT_API.Is_Stat_Account(newrec_.company, newrec_.code_part_value ) = 'TRUE') THEN
             Error_SYS.Record_General(lu_name_, 'STATACC: :P1 is a statistical account and not valid for posting type :P2', newrec_.code_part_value,newrec_.posting_type);
         END IF;
      END IF;
   END IF;
   IF (newrec_.spec_control_type IS NOT NULL) THEN
      Error_SYS.Check_Not_Null(lu_name_, 'SPEC_CTRL_TYPE_CATEGORY', newrec_.spec_ctrl_type_category);
   END IF;
   -- it's not allowed to set "default value no CT value" for fixed value and pre-posting
   IF ((newrec_.spec_default_value_no_ct IS NOT NULL) AND (newrec_.spec_ctrl_type_category IN ('FIXED','PREPOSTING'))) THEN
      newrec_.spec_default_value_no_ct := NULL;
   END IF;

   IF newrec_.spec_control_type IS NOT NULL THEN
      Validate_Specification___ (newrec_);
   END IF;
EXCEPTION
   WHEN value_error THEN
      Error_SYS.Item_Format(lu_name_, name_, value_);
END Check_Insert___;


@Override
PROCEDURE Check_Update___ (
   oldrec_ IN     posting_ctrl_detail_tab%ROWTYPE,
   newrec_ IN OUT posting_ctrl_detail_tab%ROWTYPE,
   indrec_ IN OUT Indicator_Rec,
   attr_   IN OUT VARCHAR2 )
IS
   name_                 VARCHAR2(30);
   value_                VARCHAR2(4000);
   description_          VARCHAR2(200);
   module_               VARCHAR2(20);
   ledg_flag_            VARCHAR2(1);
   tax_flag_             VARCHAR2(1); 
BEGIN
   IF (newrec_.no_code_part_value IS NULL) THEN
      newrec_.no_code_part_value := 'FALSE';
      indrec_.no_code_part_value := TRUE;
   END IF;
   
   super(oldrec_, newrec_, indrec_, attr_);


   IF (newrec_.spec_control_type IS NULL) THEN
      -- if no_code_part_value is false and spec_control_type is null then give error
      IF (newrec_.no_code_part_value = 'FALSE') THEN
         Error_SYS.Check_Not_Null(lu_name_, 'CODE_PART_VALUE', newrec_.code_part_value);
      END IF;
   END IF;
   ------------------------------------------------------------------------
   -- Specific validation befor insert.
   -- Made by MJ.
   ------------------------------------------------------------------------
   IF (newrec_.code_part = 'A' AND newrec_.no_code_part_value = 'TRUE') THEN
      Error_SYS.Record_General(lu_name_, 
                               'NOCODEPVALALLOWED: Not allowed to use :P1 for Code Part :P2', 
                               Get_Column_Trans___('NO_CODE_PART_VALUE'),
                               Accounting_Code_Parts_API.Get_Name(newrec_.company, newrec_.code_part));
      
   END IF;

   IF (newrec_.spec_control_type IS NOT NULL AND newrec_.no_code_part_value = 'TRUE') THEN
      Error_SYS.Record_General(lu_name_, 
                               'NOCODEPVALSPEC: Not allowed to use :P1 together with :P2',
                               Get_Column_Trans___('NO_CODE_PART_VALUE'),
                               Get_Column_Trans___('SPEC_CONTROL_TYPE'));
   END IF;

   IF (newrec_.code_part_value IS NOT NULL AND newrec_.no_code_part_value = 'TRUE') THEN
      Error_SYS.Record_General(lu_name_, 
                               'CODEANDNOCODEPVAL: Not allowed to set a code part value and use :P1',
                               Get_Column_Trans___('NO_CODE_PART_VALUE'));
   END IF;
   
   IF trunc(newrec_.valid_from) < trunc(newrec_.pc_valid_from) THEN
      Error_SYS.Record_General(lu_name_, 'WRONGVALFROM: Detail Valid From date should be equal or grater than parent Valid From date.');
   END IF;
      
   IF (NOT Accounting_Code_Part_Value_API.Validate_Code_Part( newrec_.company, newrec_.code_part,
                                                              newrec_.code_part_value, newrec_.valid_from )) THEN   
         Error_SYS.Record_General(lu_name_, 'NOCODEPVALUE: :P1 does not exist or has invalid date', newrec_.code_part_value); 
   END IF;
   Posting_Ctrl_Posting_Type_API.Get_Posting_Type_Attri_ ( description_, module_, ledg_flag_, tax_flag_, newrec_.posting_type ); 
   
   Validate_Control_Type_Value__ ( newrec_.company, newrec_.control_type_value,
                                   newrec_.control_type, newrec_.module, 
                                   newrec_.posting_type, newrec_.valid_from );
   IF newrec_.code_part_value IS NOT NULL THEN
      IF newrec_.code_part = 'A' THEN
         IF ( ledg_flag_ = 'Y' ) THEN
            IF (NOT Accounting_Code_part_A_API.Is_Ledger_Account( newrec_.company, newrec_.code_part_value )) THEN
               Error_SYS.Record_General(lu_name_, 'NOLEDGACCNT: :P1 is not a ledger account and therefore it is not valid for posting type :P2', newrec_.code_part_value, newrec_.posting_type);
            END IF;
         END IF;
         IF ( tax_flag_ = 'Y' ) THEN         
            IF (NOT Account_API.Is_Tax_Account( newrec_.company, newrec_.code_part_value )) THEN
               Error_SYS.Record_General(lu_name_, 'NOTAXACCNT: :P1 is not a tax account and therefore it is not valid for posting type :P2', newrec_.code_part_value, newrec_.posting_type);
            END IF;
         END IF;   
         IF (ACCOUNT_API.Is_Stat_Account(newrec_.company, newrec_.code_part_value ) = 'TRUE') THEN
             Error_SYS.Record_General(lu_name_, 'STATACC: :P1 is a statistical account and not valid for posting type :P2', newrec_.code_part_value, newrec_.posting_type);
         END IF;
      END IF;
   END IF;
   IF (newrec_.spec_control_type IS NOT NULL) THEN
      Error_SYS.Check_Not_Null(lu_name_, 'SPEC_CTRL_TYPE_CATEGORY', newrec_.spec_ctrl_type_category);
   END IF;
   -- it's not allowed to set "default value no CT value" for fixed value and pre-posting
   IF ((newrec_.spec_default_value_no_ct IS NOT NULL) AND (newrec_.spec_ctrl_type_category IN ('FIXED','PREPOSTING'))) THEN
      newrec_.spec_default_value_no_ct := NULL;
   END IF;

   IF newrec_.spec_control_type IS NOT NULL THEN
      Validate_Specification___ (newrec_);
   END IF;
EXCEPTION
   WHEN value_error THEN
      Error_SYS.Item_Format(lu_name_, name_, value_);
END Check_Update___;


-------------------- LU SPECIFIC PRIVATE METHODS ----------------------------

@Override
PROCEDURE New__ (
   info_          OUT VARCHAR2,
   objid_         OUT VARCHAR2,
   objversion_    OUT VARCHAR2,
   attr_       IN OUT VARCHAR2,
   action_     IN     VARCHAR2 )
IS
   newrec_     POSTING_CTRL_DETAIL_TAB%ROWTYPE;
BEGIN
   super(info_, objid_, objversion_, attr_, action_);
   IF (action_ = 'DO') THEN
      Client_SYS.Add_To_Attr('SPEC_CTRL_TYPE_CATEGORY_DB', newrec_.spec_ctrl_type_category, attr_);
   END IF;   
END New__;


@Override
PROCEDURE Modify__ (
   info_          OUT VARCHAR2,
   objid_      IN     VARCHAR2,
   objversion_ IN OUT VARCHAR2,
   attr_       IN OUT VARCHAR2,
   action_     IN     VARCHAR2 )
IS
   oldrec_     POSTING_CTRL_DETAIL_TAB%ROWTYPE;
   newrec_     POSTING_CTRL_DETAIL_TAB%ROWTYPE;
BEGIN
   super(info_, objid_, objversion_, attr_, action_);
   IF (action_ = 'DO') THEN
      IF (oldrec_.valid_from != newrec_.valid_from) THEN
         Posting_Ctrl_Detail_Spec_API.Update_Valid_From_(oldrec_.company,
                                                         oldrec_.posting_type,
                                                         oldrec_.code_part,
                                                         oldrec_.pc_valid_from,
                                                         oldrec_.control_type_value,
                                                         oldrec_.valid_from,
                                                         newrec_.valid_from);
         
         Posting_Ctrl_Comb_Det_Spec_API.Update_Valid_From_(oldrec_.company,
                                                           oldrec_.posting_type,
                                                           oldrec_.code_part,
                                                           oldrec_.pc_valid_from,
                                                           oldrec_.control_type_value,
                                                           oldrec_.valid_from,
                                                           newrec_.valid_from);
      END IF;      
      Client_SYS.Add_To_Attr('SPEC_CTRL_TYPE_CATEGORY_DB', newrec_.spec_ctrl_type_category, attr_);
   END IF;   
END Modify__;


PROCEDURE Exist_Value__ (
   pkg_name_           IN VARCHAR2,
   procedure_name_     IN VARCHAR2,
   company_            IN VARCHAR2,
   control_type_value_ IN VARCHAR2,
   valid_from_         IN DATE DEFAULT NULL )
IS
   block_      VARCHAR2(300);
   bindinpar1_ VARCHAR2(100) := company_;
   bindinpar2_ VARCHAR2(100) := control_type_value_;
   bindinpar3_ DATE          := valid_from_;
   bindinpar4_ VARCHAR2(7)   := TO_CHAR(NVL(valid_from_, SYSDATE), 'YYYY-MM');
BEGIN

   Assert_SYS.Assert_Is_Package_Method(pkg_name_,procedure_name_);
   IF (company_  IS NULL) THEN
      block_ := 'BEGIN ' || pkg_name_ || '.' || procedure_name_ || '( ';
      block_ := block_ || ':bindinpar2_';
      block_ := block_ || ' ); END;';
      @ApproveDynamicStatement(2005-11-11,shsalk)
      EXECUTE IMMEDIATE block_ using bindinpar2_;
   ELSE
   
      block_ := 'BEGIN ' || pkg_name_ || '.' || procedure_name_ || '( ';
      block_ := block_ || ':bindinpar1_, :bindinpar2_';
      
      IF (bindinpar3_ IS NOT NULL) THEN
         block_ := block_ || ', :bindinpar3_';        
      END IF;
      
      block_ := block_ || ' ); END;';
      
      IF (bindinpar3_ IS NULL) THEN
         @ApproveDynamicStatement(2005-11-11,shsalk)
         EXECUTE IMMEDIATE block_ using bindinpar1_,bindinpar2_;
      ELSE
         IF (pkg_name_ = 'INTER_COMPANY_ELIM_ACC_MAP_API') THEN 
            -- Note: New parameter to support the group consolidation implementation (Calls a custom Exist Method, not the framework generated method).
            @ApproveDynamicStatement(2013-09-30,meallk)
            EXECUTE IMMEDIATE block_ using bindinpar1_,bindinpar2_,bindinpar4_; 
         ELSE 
            -- Note: New parameter (valid_from_) to support for report codes from project reporting (REPORT_COST_API).
            @ApproveDynamicStatement(2012-02-04,hawalk)
            EXECUTE IMMEDIATE block_ using bindinpar1_,bindinpar2_,bindinpar3_;             
         END IF;
      END IF;
   END IF;
EXCEPTION
   WHEN NO_DATA_FOUND THEN
      RAISE; 
   WHEN OTHERS THEN
      RAISE;     
END Exist_Value__;


PROCEDURE Validate_Control_Type_Value__ (
   company_             IN VARCHAR2,
   control_type_value_  IN VARCHAR2,
   control_type_        IN VARCHAR2,
   module_              IN VARCHAR2,
   posting_type_        IN VARCHAR2,
   valid_from_          IN DATE DEFAULT NULL )
IS
   description_          VARCHAR2(200);
   ctrl_type_category_   VARCHAR2(20);
   view_name_            VARCHAR2(100);
   pkg_name_             VARCHAR2(100);
   procedure_name_       VARCHAR2(100) := 'EXIST';
   new_company_          VARCHAR2(20);
   package_              VARCHAR2(30);
   get_lov_              VARCHAR2(30) := 'Get_Lov';
   lov_                  VARCHAR2(100);
BEGIN

   Posting_Ctrl_Control_Type_API.Get_Control_Type_Attri_ (description_,
                                                          ctrl_type_category_,
                                                          view_name_,
                                                          pkg_name_,
                                                          control_type_,
                                                          module_ );
   IF (module_ = 'MPC4') THEN
      package_ := module_||'_Am_API';
      Get_Extern_Lov___( lov_, pkg_name_, package_, get_lov_, control_type_ );
   ELSIF (module_ = 'SYS4MS') THEN
      package_ := module_||'_Am_API';
      Get_Extern_Lov___( lov_, pkg_name_, package_, get_lov_, control_type_ );
   ELSIF (module_ = 'INVORS') THEN
      package_ := module_||'_Am_API';
      Get_Extern_Lov___( lov_, pkg_name_, package_, get_lov_, control_type_ );
   END IF;
   IF (module_ = 'MPC4') OR (module_ = 'SYS4MS') THEN
      IF (INSTR(lov_, '(COMPANY)', 2)) = 0 THEN
         new_company_ := NULL;
      ELSE
         new_company_ := company_;
      END IF;
   ELSIF (INSTR(view_name_, '(COMPANY)', 2)) = 0 THEN
      new_company_ := NULL;
   ELSIF (view_name_ = 'PURCHASE_CHARGE_TYPE_LOV3(COMPANY)') OR (view_name_ = 'SALES_CHARGE_TYPE_ACCRUL(COMPANY)') THEN
      new_company_ := NULL;
   ELSE
      new_company_ := company_;
   END IF;
   
   IF (posting_type_ IN ('IP3','PP44', 'PP18', 'PP48', 'PP49', 'IP9', 'IP10') AND control_type_ = 'AC7' ) THEN
      procedure_name_ := 'Exist_Deductible';
   END IF;

   IF pkg_name_ = 'ORGANIZATION_API' THEN
      procedure_name_:= 'Org_Exist_Posting_Ctrl';
   END IF;
   
   -- Bug 111335, Begin
   IF pkg_name_ = 'ROLE_TO_SITE_API' THEN
      procedure_name_ := 'Role_Exist_Posting_Ctrl';
   END IF;
   -- Bug 111335, End

   IF pkg_name_ = 'SALES_CHARGE_TYPE_API' THEN
      procedure_name_ := 'Sale_Charge_Exist_Posting_Ctrl';
   END IF;

   IF pkg_name_ = 'LABOR_CLASS_API' THEN
      procedure_name_ := 'Exist_Labor_Class_No';
   END IF;
   
   IF pkg_name_ = 'WORK_ORDER_CODING_UTILITY_API' THEN
      procedure_name_:= 'Wo_Cost_Type_Exist';
   END IF;

   IF pkg_name_ = 'INDIRECT_JOB_API' THEN
      procedure_name_ := 'Exist_Posting_Ctrl';
   END IF;

   IF pkg_name_ = 'PROJ_RESOURCE_GROUP_API' THEN
      procedure_name_:= 'Resource_ID_Exist';
   END IF;
   
   IF pkg_name_ = 'PROJECT_INVOICE_UTIL_API' THEN
      procedure_name_:= 'Control_Type_Value_Exist';
   END IF;

   -- Note: Transaction_Reason should be validated. ( Calls procedures in Transaction_Reason_API)
   IF (control_type_ = 'FAC4') AND (posting_type_ IN ('FAP7',  'FAP8', 
                                                      'FAP11', 'FAP12',
                                                      'FAP19', 'FAP20',
                                                      'FAP25', 'FAP26', 'FAP27')) THEN
      procedure_name_:= 'Disposal_Reason_Checked';
   ELSIF (control_type_ = 'FAC4') AND (posting_type_ IN ('FAP15', 'FAP16',
                                                         'FAP30', 'FAP31', 'FAP33')) THEN
      procedure_name_:= 'Depreciation_Reason_Checked';
   ELSIF (control_type_ = 'FAC4') AND (posting_type_ IN ('FAP13', 'FAP14', 
                                                         'FAP28', 'FAP29')) THEN
      procedure_name_:= 'Acquisition_Reason_Checked';
   END IF;

   IF (pkg_name_ = 'REPORT_COST_API') THEN
      Exist_Value__ ( pkg_name_, procedure_name_, new_company_, control_type_value_, valid_from_ );
   ELSIF (pkg_name_ = 'INTER_COMPANY_ELIM_ACC_MAP_API') THEN
      procedure_name_ := 'Elim_Rule_Exist';
      Exist_Value__ ( pkg_name_, procedure_name_, company_, control_type_value_, valid_from_ );      
   ELSE
      Exist_Value__ ( pkg_name_, procedure_name_, new_company_, control_type_value_);
   END IF;
END Validate_Control_Type_Value__;


-------------------- LU SPECIFIC PROTECTED METHODS --------------------------

@SecurityCheck Company.UserAuthorized(company_)
PROCEDURE Get_Code_Part_Value_ (
   code_part_value_        OUT VARCHAR2,
   module_              IN     VARCHAR2,
   company_             IN     VARCHAR2,
   posting_type_        IN     VARCHAR2,
   code_part_           IN     VARCHAR2,
   date_                IN     DATE,
   control_type_        IN     VARCHAR2,
   control_type_value_  IN     VARCHAR2 )
IS
   no_code_part_value_     VARCHAR2(5);
BEGIN
   Get_Code_Part_Value_Ex_(code_part_value_, no_code_part_value_, module_, company_, posting_type_, code_part_, date_ , control_type_, control_type_value_);
END Get_Code_Part_Value_;


PROCEDURE Get_Codepart_Value_ (
   codepart_value_ IN OUT VARCHAR2,
   date_           IN     DATE,
   company_        IN     VARCHAR2,
   posting_type_   IN     VARCHAR2,
   module_         IN     VARCHAR2,
   control_type_   IN     VARCHAR2,
   code_part_      IN     VARCHAR2,
   control_value_  IN     VARCHAR2 )
IS
   no_code_part_value_     VARCHAR2(5);
BEGIN
   Get_Code_Part_Value_Ex_(codepart_value_, no_code_part_value_, module_, company_, posting_type_, code_part_, date_ , control_type_, control_value_);
   IF (no_code_part_value_ = 'TRUE') THEN
      -- do nothing
      NULL;
   ELSE
      -- if no_code_part_value_ is null or not TRUE
      IF (codepart_value_ IS NULL) THEN
         Posting_Ctrl_API.Get_Default_Value_( codepart_value_,
                                                company_,
                                                posting_type_,
                                                code_part_,
                                                control_type_ );
      END IF;
   END IF;
END Get_Codepart_Value_;


PROCEDURE Override_Default_ (
   company_            IN VARCHAR2,
   posting_type_       IN VARCHAR2,
   code_part_          IN VARCHAR2,
   code_part_value_    IN VARCHAR2,
   control_type_       IN VARCHAR2,
   control_type_value_ IN VARCHAR2,
   module_             IN VARCHAR2 )
IS
   valid_from_   DATE;
BEGIN
   valid_from_  := Company_Finance_Api.Get_Valid_From( company_ );
   INSERT
      INTO posting_ctrl_detail_tab (
           company,
           code_part,
           posting_type,
           pc_valid_from,
           code_part_value,
           control_type_value,
           valid_from,
           control_type,
           module,
           no_code_part_value,
           rowversion
           )
      VALUES (
           company_,
           code_part_,
           posting_type_,
           valid_from_,
           code_part_value_,
           control_type_value_,
           valid_from_,
           control_type_,
           module_,
           'FALSE',
           sysdate
           );
EXCEPTION
   WHEN dup_val_on_index THEN
      NULL;
END Override_Default_;


PROCEDURE Update_Pc_Valid_From_ (
   company_            IN VARCHAR2,
   posting_type_       IN VARCHAR2,
   code_part_          IN VARCHAR2,
   pc_valid_from_      IN DATE,
   new_pc_valid_from_  IN DATE )
IS
   CURSOR get_row_for_update IS
      SELECT *
      FROM   POSTING_CTRL_DETAIL_TAB
      WHERE company = company_
      AND   posting_type = posting_type_
      AND   code_part = code_part_
      AND   pc_valid_from = pc_valid_from_
      FOR UPDATE NOWAIT;

   CURSOR get_spec_row_for_update IS
      SELECT *
      FROM  POSTING_CTRL_DETAIL_SPEC_TAB
      WHERE company = company_
      AND   posting_type = posting_type_
      AND   code_part = code_part_
      AND   pc_valid_from = pc_valid_from_
      FOR UPDATE NOWAIT;
   
   CURSOR get_comb_row_for_update IS
      SELECT *
      FROM   POSTING_CTRL_COMB_DET_SPEC_TAB
      WHERE  company       = company_
      AND    posting_type  = posting_type_
      AND    code_part     = code_part_
      AND    pc_valid_from = pc_valid_from_
      FOR UPDATE NOWAIT;
BEGIN
   FOR rec_ IN get_row_for_update LOOP
      UPDATE POSTING_CTRL_DETAIL_TAB
         SET pc_valid_from = new_pc_valid_from_
      WHERE CURRENT OF get_row_for_update;
   END LOOP;
   
   FOR rec_ IN get_spec_row_for_update LOOP
      UPDATE POSTING_CTRL_DETAIL_SPEC_TAB
         SET pc_valid_from = new_pc_valid_from_
      WHERE CURRENT OF get_spec_row_for_update;
   END LOOP;
   
   FOR rec_ IN get_comb_row_for_update LOOP
      UPDATE POSTING_CTRL_COMB_DET_SPEC_TAB
         SET pc_valid_from = new_pc_valid_from_
      WHERE CURRENT OF get_comb_row_for_update;
   END LOOP;
END Update_Pc_Valid_From_;


@SecurityCheck Company.UserAuthorized(company_)
@UncheckedAccess
PROCEDURE Get_Code_Part_Value_Ex_ (
   code_part_value_        OUT VARCHAR2,
   no_code_part_value_     OUT VARCHAR2,
   module_              IN     VARCHAR2,
   company_             IN     VARCHAR2,
   posting_type_        IN     VARCHAR2,
   code_part_           IN     VARCHAR2,
   date_                IN     DATE,
   control_type_        IN     VARCHAR2,
   control_type_value_  IN     VARCHAR2 )
IS
   CURSOR codepartvalue IS
     SELECT code_part_value, no_code_part_value_
     FROM   POSTING_CTRL_DETAIL_TAB
     WHERE  company            = company_
     AND    posting_type       = posting_type_
     AND    code_part          = code_part_
     AND    control_type       = control_type_
     AND    module             = module_
     AND    control_type_value = control_type_value_
     AND    valid_from = (SELECT MAX(valid_from)
                          FROM   POSTING_CTRL_DETAIL_TAB
                          WHERE  company            = company_
                          AND    posting_type       = posting_type_
                          AND    code_part          = code_part_
                          AND    control_type       = control_type_
                          AND    module             = module_
                          AND    control_type_value = control_type_value_
                          AND    valid_from        <= date_);
BEGIN
   OPEN codepartvalue;
   FETCH codepartvalue INTO code_part_value_, no_code_part_value_;
   CLOSE codepartvalue;
END Get_Code_Part_Value_Ex_;


-------------------- LU SPECIFIC PUBLIC METHODS -----------------------------

-- Exist
--   Checks if given pointer (e.g. primary key) to an instance of this
--   logical unit exists. If not an exception will be raised.
@UncheckedAccess
PROCEDURE Exist (
   company_            IN VARCHAR2,
   code_part_          IN VARCHAR2,
   posting_type_       IN VARCHAR2,
   pc_valid_from_      IN DATE,
   control_type_value_ IN VARCHAR2,
   valid_from_         IN DATE,
   code_part_value_    IN VARCHAR2    )
IS
BEGIN
   IF (NOT Check_Exist___(company_, code_part_, posting_type_, pc_valid_from_, control_type_value_, valid_from_, code_part_value_)) THEN
      Error_SYS.Record_Not_Exist(lu_name_);
   END IF;
   NULL;
END Exist;


-- Exist
--   Checks if given pointer (e.g. primary key) to an instance of this
--   logical unit exists. If not an exception will be raised.



@SecurityCheck Company.UserAuthorized(company_)
FUNCTION Details_Exist (
   company_            IN VARCHAR2,
   posting_type_       IN VARCHAR2,
   code_part_          IN VARCHAR2,
   control_type_       IN VARCHAR2,
   control_type_value_ IN VARCHAR2) RETURN BOOLEAN
IS
   dummy_  VARCHAR2(1);
   CURSOR details IS
      SELECT 'X'
         FROM   POSTING_CTRL_DETAIL_TAB
         WHERE  company            = company_
           AND  posting_type       = posting_type_
           AND  code_part          = code_part_
           AND  control_type       = control_type_
           AND  control_type_value = control_type_value_;
BEGIN
   OPEN details;
   FETCH details INTO dummy_;
   IF ( details%NOTFOUND ) THEN
      CLOSE details;
      RETURN FALSE;
   ELSE
      CLOSE details;
      RETURN TRUE;
   END IF;
END Details_Exist;


@SecurityCheck Company.UserAuthorized(company_)
PROCEDURE Account_Exist (
   company_ IN VARCHAR2,
   account_ IN VARCHAR2 )
IS
   postings_   NUMBER;
   CURSOR check_account IS
      SELECT 1
      FROM   POSTING_CTRL_DETAIL_TAB
      WHERE  ( code_part_value          = account_ OR
               spec_default_value       = account_ OR
               spec_default_value_no_ct = account_ )
      AND    company         = company_
      AND    code_part       ='A';
BEGIN
   OPEN  check_account;
   FETCH check_account INTO postings_;
   IF (check_account%FOUND) THEN
      CLOSE check_account;
      Error_SYS.Record_General('PostingCtrlDetail', 'ACCNTEXISTS: The account :P1 exists in posting control ', account_);
   END IF;
   CLOSE check_account;
END Account_Exist;


PROCEDURE Get_Code_Part_Value(
   code_part_value_     OUT VARCHAR2,
   module_              IN  VARCHAR2,
   company_             IN  VARCHAR2,
   posting_type_        IN  VARCHAR2,
   code_part_           IN  VARCHAR2,
   date_                IN  DATE,
   control_type_        IN  VARCHAR2,
   control_type_value_  IN  VARCHAR2 )
IS
   no_code_part_value_  VARCHAR2(5);
BEGIN
   Get_Code_Part_Value_Ex_(code_part_value_   ,
                           no_code_part_value_,
                           module_            ,
                           company_           ,
                           posting_type_      ,
                           code_part_         ,
                           date_              ,
                           control_type_      ,
                           control_type_value_);
END Get_Code_Part_Value;


@SecurityCheck Company.UserAuthorized(company_)
PROCEDURE Remove_Posting_Control_Detail(
   company_            IN     VARCHAR2,
   code_part_          IN     VARCHAR2,
   posting_type_       IN     VARCHAR2,
   pc_valid_from_      IN     DATE,
   control_type_value_ IN     VARCHAR2,
   valid_from_         IN     DATE,
   code_part_value_    IN     VARCHAR2 DEFAULT NULL )
IS
   dummy_info_ VARCHAR2(2000);
   objid_ VARCHAR2(2000);
   objversion_ VARCHAR2(2000);
BEGIN
   Get_Id_Version_By_Keys___(objid_,
                             objversion_,
                             company_,
                             code_part_,
                             posting_type_,
                             pc_valid_from_,
                             control_type_value_,
                             valid_from_);
   Remove__(dummy_info_,
            objid_,
            objversion_,
            'DO');
END Remove_Posting_Control_Detail;


@UncheckedAccess
FUNCTION Is_Led_Account_Used (
   company_ IN VARCHAR2,
   account_ IN VARCHAR2 ) RETURN VARCHAR2
IS
   ledger_account_is_used_   NUMBER;
   CURSOR check_ledger_used IS
      SELECT 1 
      FROM   posting_ctrl_detail_tab pcdt , posting_ctrl_posting_type_tab pcpt
      WHERE  code_part         = 'A' 
      AND    code_part_value   = account_
      AND    company           = company_
      AND    pcpt.ledg_flag    = 'Y'
      AND    pcpt.posting_type = pcdt.posting_type;
BEGIN      
   OPEN check_ledger_used;
   FETCH check_ledger_used INTO ledger_account_is_used_;
   IF (check_ledger_used%FOUND) THEN
      CLOSE check_ledger_used;  
      RETURN 'TRUE';
   END IF;
   CLOSE check_ledger_used;  
   RETURN 'FALSE';
END Is_Led_Account_Used;


@UncheckedAccess
FUNCTION Is_Tax_Account_Used (
   company_ IN VARCHAR2,
   account_ IN VARCHAR2 ) RETURN VARCHAR2
IS
   tax_account_is_used_   NUMBER;
   CURSOR check_tax_used IS
      SELECT 1 
      FROM   posting_ctrl_detail_tab pcdt , posting_ctrl_posting_type_tab pcpt
      WHERE  code_part         = 'A' 
      AND    code_part_value   = account_
      AND    company           = company_
      AND    pcpt.tax_flag    = 'Y'
      AND    pcpt.posting_type = pcdt.posting_type;
BEGIN      
   OPEN check_tax_used;
   FETCH check_tax_used INTO tax_account_is_used_;
   IF (check_tax_used%FOUND) THEN
      CLOSE check_tax_used;  
      RETURN 'TRUE';
   END IF;
   CLOSE check_tax_used;  
   RETURN 'FALSE';
END Is_Tax_Account_Used;



