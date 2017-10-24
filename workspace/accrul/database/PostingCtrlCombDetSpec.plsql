-----------------------------------------------------------------------------
--
--  Logical unit: PostingCtrlCombDetSpec
--  Component:    ACCRUL
--
--  IFS Developer Studio Template Version 3.0
--
--  Date    Sign    History
--  ------  ------  ---------------------------------------------------------
--  050606  reanpl  Created for FIAD376 - Actual Costing
--  060619  iswalk  removed allowed_default_.
--  070321  shsalk  LCS Merge 63645,Corrected.Added method Account_Exist
--  070912  Shsalk  B148647 Made an error message more descriptive.
--  111020  ovjose  Added no_code_part_valu
--  140409  THPELK PBFI-4377, LCS Merge (Bug 113342).
-----------------------------------------------------------------------------

layer Core;

-------------------- PUBLIC DECLARATIONS ------------------------------------


-------------------- PRIVATE DECLARATIONS -----------------------------------


-------------------- LU SPECIFIC IMPLEMENTATION METHODS ---------------------

PROCEDURE Validate_Row___ (
   newrec_ IN POSTING_CTRL_COMB_DET_SPEC_TAB%ROWTYPE )
IS
   description_   VARCHAR2(200);
   module_        VARCHAR2(20);
   ledg_flag_     VARCHAR2(1);
   tax_flag_      VARCHAR2(1);
BEGIN

   IF (newrec_.code_part = 'A' AND newrec_.no_code_part_value = 'TRUE') THEN
      Error_SYS.Record_General(lu_name_, 
                               'NOCODEPVALALLOWED: Not allowed to use :P1 for Code Part :P2', 
                               Get_Column_Trans___('NO_CODE_PART_VALUE'),
                               Accounting_Code_Parts_API.Get_Name(newrec_.company, newrec_.code_part));
      
   END IF;

   IF (newrec_.code_part_value IS NOT NULL AND newrec_.no_code_part_value = 'TRUE') THEN
      Error_SYS.Record_General(lu_name_, 
                               'CODEANDNOCODEPVAL: Not allowed to set a code part value and use :P1',
                               Get_Column_Trans___('NO_CODE_PART_VALUE'));
   END IF;

   Posting_Ctrl_Posting_Type_API.Get_Posting_Type_Attri_ ( description_, module_, ledg_flag_, tax_flag_, newrec_.posting_type );

   IF (newrec_.code_part = 'A') THEN
      Account_API.Exist(newrec_.company, newrec_.code_part_value);
      IF ledg_flag_ = 'Y' THEN
         IF (NOT ACCOUNTING_CODE_PART_A_API.Is_Ledger_Account( newrec_.company, newrec_.code_part_value )) THEN
            Error_SYS.Record_General(lu_name_, 'CMBSPECNOLEDGACCNT: :P1 is no ledger account and not valid for posting type :P2', newrec_.code_part_value,newrec_.posting_type);
         END IF;
      ELSIF tax_flag_ = 'Y' THEN
         IF (NOT Account_API.Is_Tax_Account( newrec_.company, newrec_.code_part_value )) THEN
            Error_SYS.Record_General(lu_name_, 'CMBSPECNOTAXACCNT: Account :P1 is no tax account and not valid for posting type :P2', newrec_.code_part_value,newrec_.posting_type);
         END IF;
      ELSIF (ACCOUNTING_CODE_PART_A_API.Is_Stat_Account(newrec_.company, newrec_.code_part_value )) = 'TRUE' THEN
         Error_SYS.Record_General(lu_name_, 'CMBSPECSTATACC: :P1 is a statistical account and not valid for posting type :P2', newrec_.code_part_value,newrec_.posting_type);
      END IF;
   ELSE
      IF (newrec_.no_code_part_value = 'FALSE') THEN
         Accounting_Code_Part_Value_API.Exist(newrec_.company, newrec_.code_part, newrec_.code_part_value);
      END IF;
      --Accounting_Code_Part_Value_API.Exist(newrec_.company, newrec_.code_part, newrec_.code_part_value);
   END IF;
END Validate_Row___;


FUNCTION Get_Column_Trans___
   (item_      IN VARCHAR2) RETURN VARCHAR2
IS
BEGIN
   -- Should not use the protected method in Language_SYS but until a public method the protected method is used.
   RETURN Language_SYS.Translate_Item_Prompt_(lu_name_, Upper(item_));
END Get_Column_Trans___;


@Override
PROCEDURE Prepare_Insert___ (
   attr_ IN OUT VARCHAR2 )
IS
BEGIN
   super(attr_);
   Client_SYS.Add_To_Attr('NO_CODE_PART_VALUE_DB', 'FALSE', attr_);
END Prepare_Insert___;


@Override
PROCEDURE Check_Insert___ (
   newrec_ IN OUT posting_ctrl_comb_det_spec_tab%ROWTYPE,
   indrec_ IN OUT Indicator_Rec,
   attr_   IN OUT VARCHAR2 )
IS
   name_  VARCHAR2(30);
   value_ VARCHAR2(4000);
   internal_id_   NUMBER;
   stmt_          VARCHAR2(1000);
BEGIN
   indrec_.valid_from   := FALSE;
   IF (newrec_.no_code_part_value IS NULL) THEN
      newrec_.no_code_part_value := 'FALSE';
      indrec_.no_code_part_value := TRUE;
   END IF; 
   
   super(newrec_, indrec_, attr_);
   Error_SYS.Check_Not_Null(lu_name_, 'CODE_PART_VALUE', newrec_.code_part_value);

   IF (newrec_.no_code_part_value = 'FALSE') THEN
      Error_SYS.Check_Not_Null(lu_name_, 'CODE_PART_VALUE', newrec_.code_part_value);
   END IF;



   IF newrec_.spec_control_type1_value = '%' AND newrec_.spec_control_type2_value = '%' THEN
      Error_SYS.Appl_General( lu_name_, 'POSTCMBDETSPEC01: Value % is not allowed for both control types at the same time.');
   END IF;

   IF newrec_.spec_control_type1_value != '%' THEN
      IF (newrec_.spec_control_type1 = 'IC7') THEN
         -- Control type IC7, Income Type, needs currency code and country_code to get the internal id
         -- that should be saved.
         newrec_.spec_control_type1_value := Income_Type_API.Get_Internal_Income_Type(newrec_.spec_control_type1_value,
                                                                                      Company_Finance_API.Get_Currency_Code(newrec_.company),
                                                                                      Company_API.Get_Country_Db(newrec_.company));
      ELSIF (newrec_.spec_control_type1 = 'IC8') THEN
         -- Control type IC8, Irs1099_Type_Id, needs country_code to get the internal id to save
         stmt_ := 'BEGIN :internal_id_ := Type1099_API.Get_Internal_Type1099(:control_type1_value_,
            Company_API.Get_Country_Db(:company_)); END;';
         @ApproveDynamicStatement(2005-12-05,ovjose)
         EXECUTE IMMEDIATE stmt_ using IN OUT internal_id_, newrec_.spec_control_type1_value, newrec_.company;
         newrec_.spec_control_type1_value := internal_id_;
      END IF;

      Posting_Ctrl_Detail_API.Validate_Control_Type_Value__(newrec_.company, newrec_.spec_control_type1_value, newrec_.spec_control_type1, newrec_.spec_module1, newrec_.posting_type );
   END IF;

   IF newrec_.spec_control_type2_value != '%' THEN
      IF (newrec_.spec_control_type2 = 'IC7') THEN
         -- Control type IC7, Income Type, needs currency code and country_code to get the internal id
         -- that should be saved.
         newrec_.spec_control_type2_value := Income_Type_API.Get_Internal_Income_Type(newrec_.spec_control_type2_value,
                                                                                      Company_Finance_API.Get_Currency_Code(newrec_.company),
                                                                                      Company_API.Get_Country_Db(newrec_.company));
      ELSIF (newrec_.spec_control_type2 = 'IC8') THEN
         -- Control type IC8, Irs1099_Type_Id, needs country_code to get the internal id to save
         stmt_ := 'BEGIN :internal_id_ := Type1099_API.Get_Internal_Type1099(:control_type2_value_,
            Company_API.Get_Country_Db(:company_)); END;';
         @ApproveDynamicStatement(2005-12-05,ovjose)
         EXECUTE IMMEDIATE stmt_ using IN OUT internal_id_, newrec_.spec_control_type2_value, newrec_.company;
         newrec_.spec_control_type2_value := internal_id_;
      END IF;

      Posting_Ctrl_Detail_API.Validate_Control_Type_Value__(newrec_.company, newrec_.spec_control_type2_value, newrec_.spec_control_type2, newrec_.spec_module2, newrec_.posting_type );
   END IF;

   Validate_Row___ (newrec_);
EXCEPTION
   WHEN value_error THEN
      Error_SYS.Item_Format(lu_name_, name_, value_);
END Check_Insert___;


@Override
PROCEDURE Check_Update___ (
   oldrec_ IN     posting_ctrl_comb_det_spec_tab%ROWTYPE,
   newrec_ IN OUT posting_ctrl_comb_det_spec_tab%ROWTYPE,
   indrec_ IN OUT Indicator_Rec,
   attr_   IN OUT VARCHAR2 )
IS
   name_  VARCHAR2(30);
   value_ VARCHAR2(4000);
BEGIN
   indrec_.valid_from   := FALSE;
   IF (newrec_.no_code_part_value IS NULL) THEN
      newrec_.no_code_part_value := 'FALSE';
      indrec_.no_code_part_value := TRUE;
   END IF;
   
   super(oldrec_, newrec_, indrec_, attr_);

   IF (newrec_.no_code_part_value = 'FALSE') THEN
      Error_SYS.Check_Not_Null(lu_name_, 'CODE_PART_VALUE', newrec_.code_part_value);
   END IF;


   Validate_Row___ (newrec_);
EXCEPTION
   WHEN value_error THEN
      Error_SYS.Item_Format(lu_name_, name_, value_);
END Check_Update___;


-------------------- LU SPECIFIC PRIVATE METHODS ----------------------------

-------------------- LU SPECIFIC PROTECTED METHODS --------------------------

PROCEDURE Update_Valid_From_ (
   company_            IN VARCHAR2,
   posting_type_       IN VARCHAR2,
   code_part_          IN VARCHAR2,
   pc_valid_from_      IN DATE,
   control_type_value_ IN VARCHAR2,
   valid_from_         IN DATE,
   new_valid_from_     IN DATE )
IS
   CURSOR get_row_for_update IS
      SELECT *
      FROM   POSTING_CTRL_COMB_DET_SPEC_TAB
      WHERE company = company_
      AND   posting_type = posting_type_
      AND   code_part = code_part_
      AND   pc_valid_from = pc_valid_from_
      AND   control_type_value = control_type_value_
      AND   valid_from = valid_from_
      FOR UPDATE NOWAIT;
BEGIN
   FOR rec_ IN get_row_for_update LOOP
      UPDATE POSTING_CTRL_COMB_DET_SPEC_TAB
         SET valid_from = new_valid_from_
      WHERE CURRENT OF get_row_for_update;
   END LOOP;
END Update_Valid_From_;


-------------------- LU SPECIFIC PUBLIC METHODS -----------------------------

PROCEDURE Insert_Post_Ctrl_Comb_Det_Spec (
   company_                   IN VARCHAR2,
   posting_type_              IN VARCHAR2,
   code_part_                 IN VARCHAR2,
   pc_valid_from_             IN DATE,
   control_type_value_        IN VARCHAR2,
   valid_from_                IN DATE,
   spec_comb_control_type_    IN VARCHAR2,
   spec_control_type1_        IN VARCHAR2,
   spec_control_type1_value_  IN VARCHAR2,
   spec_module1_              IN VARCHAR2,
   spec_control_type2_        IN VARCHAR2,
   spec_control_type2_value_  IN VARCHAR2,
   spec_module2_              IN VARCHAR2,
   code_part_value_           IN VARCHAR2,
   no_code_part_value_db_     IN VARCHAR2 DEFAULT 'FALSE' )
IS
   objid_         VARCHAR2(100);
   attr_          VARCHAR2(2000);
   info_          VARCHAR2(2000);
   objversion_    VARCHAR2(2000);
   tmp_pc_valid_from_    DATE;
   dummy_         NUMBER;

   CURSOR get_posting IS
      SELECT 1
      FROM   POSTING_CTRL_COMB_DET_SPEC_TAB
      WHERE company = company_
      AND   code_part = code_part_
      AND   pc_valid_from = pc_valid_from_
      AND   posting_type = posting_type_
      AND   control_type_value = control_type_value_
      AND   valid_from = valid_from_
      AND   spec_comb_control_type = spec_comb_control_type_
      AND   spec_control_type1_value = spec_control_type1_value_
      AND   spec_control_type2_value = spec_control_type2_value_;
      
   CURSOR check_master IS
      SELECT 1
      FROM   POSTING_CTRL_DETAIL_TAB
      WHERE  company            = company_
      AND    posting_type       = posting_type_
      AND    code_part          = code_part_
      AND    pc_valid_from      = tmp_pc_valid_from_
      AND    control_type_value = control_type_value_
      AND    valid_from         = valid_from_;
BEGIN

   tmp_pc_valid_from_ := nvl(pc_valid_from_, Company_Finance_API.Get_Valid_From(company_));
   
   -- don't insert details if master doesn't exist
   OPEN  check_master;
   FETCH check_master INTO dummy_;
   IF check_master%notfound THEN
      CLOSE check_master;
      RETURN;
   ELSE
      CLOSE check_master;
   END IF;

   IF (Company_Finance_API.Is_User_Authorized(company_ )) THEN

      OPEN get_posting;
      FETCH get_posting INTO dummy_;
      IF get_posting%found THEN
         CLOSE get_posting;
      ELSE
         CLOSE get_posting;
         Client_SYS.Clear_Attr(attr_);
         Client_SYS.Add_To_Attr( 'COMPANY', company_, attr_);
         Client_SYS.Add_To_Attr( 'POSTING_TYPE', posting_type_, attr_);
         Client_SYS.Add_To_Attr( 'CODE_PART', code_part_, attr_);
         Client_SYS.Add_To_Attr( 'PC_VALID_FROM', trunc(tmp_pc_valid_from_), attr_);
         Client_SYS.Add_To_Attr( 'CONTROL_TYPE_VALUE', control_type_value_, attr_);
         Client_SYS.Add_To_Attr( 'VALID_FROM', valid_from_, attr_);
         Client_SYS.Add_To_Attr( 'SPEC_COMB_CONTROL_TYPE', spec_comb_control_type_, attr_);
         Client_SYS.Add_To_Attr( 'SPEC_CONTROL_TYPE1', spec_control_type1_, attr_);
         Client_SYS.Add_To_Attr( 'SPEC_CONTROL_TYPE1_VALUE', spec_control_type1_value_, attr_);
         Client_SYS.Add_To_Attr( 'SPEC_MODULE1', spec_module1_, attr_);
         Client_SYS.Add_To_Attr( 'SPEC_CONTROL_TYPE2', spec_control_type2_, attr_);
         Client_SYS.Add_To_Attr( 'SPEC_CONTROL_TYPE2_VALUE', spec_control_type2_value_, attr_);
         Client_SYS.Add_To_Attr( 'SPEC_MODULE2', spec_module2_, attr_);
         Client_SYS.Add_To_Attr( 'CODE_PART_VALUE', code_part_value_, attr_);

         -- ovjose test
         Client_SYS.Add_To_Attr( 'NO_CODE_PART_VALUE_DB', no_code_part_value_db_, attr_);
         
         New__ ( info_, objid_, objversion_, attr_, 'DO' );
      END IF;
   END IF;
   
END Insert_Post_Ctrl_Comb_Det_Spec;


@SecurityCheck Company.UserAuthorized(company_)
PROCEDURE Account_Exist (
   company_ IN VARCHAR2,
   account_ IN VARCHAR2 )
IS
   postings_   NUMBER;
   CURSOR check_account IS
      SELECT 1
        FROM POSTING_CTRL_COMB_DET_SPEC_TAB
       WHERE company         = company_ 
         AND code_part       = 'A'
         AND code_part_value = account_;
BEGIN
   OPEN check_account;
   FETCH check_account INTO postings_;
   IF (check_account%FOUND) THEN
      CLOSE check_account;
      Error_SYS.Record_General('PostingCtrlCombDetSpec', 'ACCNTEXISTS: The account :P1 exists in posting control ', account_);
   END IF;
   CLOSE check_account;
END Account_Exist;


@SecurityCheck Company.UserAuthorized(company_)
PROCEDURE Remove_Post_Ctrl_Comb_Det_Spec(
   company_                  IN VARCHAR2,
   code_part_                IN VARCHAR2,
   pc_valid_from_            IN DATE,
   posting_type_             IN VARCHAR2,
   control_type_value_       IN VARCHAR2,
   valid_from_               IN DATE,
   spec_comb_control_type_   IN VARCHAR2,
   spec_control_type1_value_ IN VARCHAR2,
   spec_control_type2_value_ IN VARCHAR2)
IS
   dummy_info_ VARCHAR2(2000);
   objid_      VARCHAR2(2000);
   objversion_ VARCHAR2(2000);
BEGIN
   Get_Id_Version_By_Keys___(objid_,
                             objversion_,
                             company_,
                             code_part_,
                             pc_valid_from_,
                             posting_type_,
                             control_type_value_,
                             valid_from_,
                             spec_comb_control_type_,
                             spec_control_type1_value_,
                             spec_control_type2_value_);
      Remove__(dummy_info_,
               objid_,
               objversion_,
               'DO');
END Remove_Post_Ctrl_Comb_Det_Spec;

-- Bug 127043,begin.
PROCEDURE New_Rec(
   newrec_     IN OUT Posting_Ctrl_Comb_Det_Spec_Tab%ROWTYPE)
IS
BEGIN
   New___(newrec_);
END New_Rec;
-- Bug 127043,end.