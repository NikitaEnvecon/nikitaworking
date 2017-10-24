-----------------------------------------------------------------------------
--
--  Logical unit: StatutoryFee
--  Component:    ACCRUL
--
--  IFS Developer Studio Template Version 3.0
--
--  Date    Sign    History
--  ------  ------  ---------------------------------------------------------
--  970609  MiJo     Cheanged column name from Percentage to Fee_Rate.
--  970718  SLKO     Converted to Foundation 1.2.2d
--  970813  SLKO     To short variable in Get_Description function.
--  970808  ARBI     Added VALID_FROM to key - modifications of LU
--  970825  MiJo     Bug 97-0053, added default date for valid from and valid until.
--  990415  JPS      Performed Template Changes. (Foundation 2.2.1)
--  990824  AnTo     Added columns vat_received and vat_disbursed
--  990929  Uma      Fixed Bug#11752
--  000119  Uma      Global Date Definition.
--  000707  BmEk     A527: Added Check_Fee_Code
--  000914  HiMu     Added General_SYS.Init_Method
--  000915  LiSv     A806: Added check_exist_deductible and exist_deductible. Added new view
--                   STATUTORY_FEE_DEDUCTIBLE
--  000920  LiSv     Call #48841 corrected.
--  000926  BmEk     A520: Modified Check_Delete___ and added Validate_Modify___
--  001003  LiSv     A808: Added control in Upack_Check_Insert and Unpack_Check_Update.
--  001004  BmEk     A527: Corrected cursor in Get_Fee_Percent.
--  001013  prtilk   BUG # 15677  Checked General_SYS.Init_Method
--  001026  BmEk     Call #50952. Modified fee_rate and description to not null columns.
--  001122  LiSv     For new Create Company concept added new view statutory_fee_etc and statutory_fee_pct.
--                   Added procedures Make_Company, Copy___, Import___ and Export___.
--  010221  ToOs     Bug # 20177 Added Global Lu constants for check for transaction_sys calls
--  010502  BmEk     IID 9001. Added view STATUTORY_FEE_NON_VAT and STATUTORY_FEE_VAT
--  010510  JeGu     Bug #21705 Implementation New Dummyinterface
--                   Changed Insert__ RETURNING rowid INTO objid_
--  010531  Bmekse   Removed methods used by the old way for transfer basic data from
--                   master to slave (nowdays is Replication used instead)
--  010814  AjRolk   Bug ID 23691 Fixed, Included check for the FEE_RATE
--  010816  OVJOSE   Added Create Company translation method Create_Company_Translations___
--  011016  FaMese   Bug # 19207.
--  011025  LiSV     Futher correction of Bug #19207.
--  011207  LiSv     IID 10001. Added ncf_inv_tax_rate. NOTE This is only used by companies in Norway.
--  011207  ovjose   IID 20001 Enhancement of Update Company. Changes inside make_company method
--                   Changed Import___, Export___ and Copy___ methods to use records and update on key
--  020103  KuPelk   IID 10950 Added new table column as tax_recoverable to Statutory_Fee_Tab.
--  020121  LiSv     IID 10120 Added check for tax type IRS1099TX. Added view STATUTORY_FEE_TAX_WITHHOLD.
--  020213  Mnisse   IID 21003, Added company translation support for description
--  020219  KAGALK   Call 27275 corrected. Added if statement to unpack_check_update.
--  020307  BmEk     Added Get_Fee_Type_Client
--  020312  KuPelk   Call Id 77128 Corrected.
--  020314  Thsrlk   Redo Call 27275 using dynamic calls.
--  020314  Upulp    Call ID 78269 Fixed
--  020315  BmEk     Added view VIEWNONVATCUST
--  020320  LiSv     Additional correction of Bug #19207. Changed Get_Description
--  020320  Mnisse   Copy__ changed FOUND -> NOTFOUND
--  020325  Shsalk   Call Id 79630 Fixed. changed get_description and get_pecentage.
--                   Added view TAX_CODE_LOV. Added functions get_valid_until and get_valid_from
--  020531  MACHLK   Bug# 29512 Fixed. Added new view TAX_CODE_LOV1.
--  020611  ovjose   Bug 29600 Corrected. Removed function call in STATUTORY_FEE_PCT.
--  021002  Nimalk   Removed usage of the view Company_Finance_Auth in viewes
--                   and replaced by view Company_Finance_Auth1 using EXISTS caluse instead of joins
--  021112  risrlk   SALSA-IID ITFI101E. Modified Check_delete___ and Insert___ methods.
--  021120  Jakalk   SALSA-IIDFRFI105E. Added public method Get_Deductible_Percent.
--  021202  mgutse   SALSA-IIDITFI127N. Allow tax withholding tax codes to be deductible.
--  021209  ISJALK   IIDESFI109E, added attribute multiple_tax, views STATUTORY_FEE_MULTIPLE, STATUTORY_FEE_DEDUCT_MULTIPLE,
--                   STATUTORY_FEE_VAT_MULTIPLE, STATUTORY_FEE_VSR and changed WHERE clauses of some existing views.
--  021209  ISJALK   IIDESFI109E, Changed Get_Description.
--                   Added public method Set_Multiple_Tax.
--  021230  ISJALK   SP3 merge, BUG 32675.
--  030109  ISJALK   IIDESFI109E, Addded STATUTORY_FEE_NON_VAT_MULTIPLE.
--  030116  ISJALK   Call 92685, Added STATUTORY_FEE_NON_RDE.
--  030122  Hecolk   IID ESFI109EB. Added view 'STATUTORY_FEE_NON_RDE_MULTIPLE'
--  030205  Hecolk   IID ESFI109EB. Modified views 'STATUTORY_FEE_NON_RDE' and 'STATUTORY_FEE_NON_RDE_MULTIPLE'
--  030226  Hecolk   B94551 for IID ESFI109EB, Added Checks in 'Unpack_Check_Insert___' & 'Unpack_Check_Update___'
--  030306  Hecolk   IID ESFI109E, Modified VIEW 'STATUTORY_FEE'
--  030317  RAFA     IID ITFI127N, added new columns to Statutory_fee_tab
--  030320  prdilk   B94834 Added Checks in 'Unpack_Check_Insert___' & 'Unpack_Check_Update___'
--  030324  Hecolk   B95580 for IID ESFI109E, Modified view 'STATUTORY_FEE_NON_RDE_MULTIPLE'
--  030403  Hecolk   IID ESFI109E, Quality Issues
--  030408  mgutse   IID ITFI127N. Validation of tax code when using tax withhold amount table.
--  030505  ChFolk   Call ID 96247. Added FUNCTION Get_Order_Fee_Rate.
--  030602  mgutse   IID ITFI127N. Validation of tax code when using tax withhold amount table.
--  030611  ChFolk   Added new View STATUTORY_FEE_ADV_PAY_VAT_LOV.
--  030613  RAFA     ARFI144N Added tax_amount_at_inv_print
--  030627  Hecolk   Modified Precedure Unpack_Check_Insert___
--  030703  Hecolk   Modified Precedure Unpack_Check_Update___
--  030703  Hecolk   Added New FUNCTION Check_Attached & Modified PROCEDURE Check_Delete___
--  030709  ChFolk   Reserved the changes that have been done for Advance Payment. Removed View STATUTORY_FEE_ADV_PAY_VAT_LOV.
--  040329  Gepelk   2004 SP1 Merge.
--  040407  Hecolk   Touch down Merge - FI01 Minimum Tax
--  040615  sachlk   FIPR338A2: Unicode Changes.
--  040910  GeKalk   Added a new public method Get_Tot_Attached_Fee_Rate.
--  040918  AnGiSe   FITH352. Added field minimum_base_amount to views STATUTORY_FEE and STATUTORY_FEE_DEDUCT_MULTIPLE,
--                   to methods for insert,update and get.
--  041112  Risrlk   Merged LCS Bug 45341
--  041122  AnGiSe   B119979 Added method Exist_Withhold for control of valid tax_withholding_codes.
--  050106  NiFelk   B12076, Added method Exist_Deduct.
--  050223  AnGiSe   B122004 Default value set to NULL instead of SYSDATE for in parameter in get_fee_type
--  050223           and added null handling in cursor instead, since it's not working with default sysdate.
--  051208  GaWiLk   LCS merge 45867. Added Get_Vat_Received_Db, Get_Vat_Disbursed_Db
--  051228  Kagalk   LCS merge 54341, Modified error message.
--  060124  Ingulk   Call ID 130035 Added a method Is_Withheld
--  060209  Nalslk   LCS merge 48733, Added validation to check, deductible percentage with Sales tax and Use tax
--  060302  Nalslk   LCS merge 53770, To support CALCVAT with deductible less than 100%, removed existing validations.
--  061117  Paralk   B139949 , Call PROCEDURE Remove_Exception_Tax_Codes() in Remove__().
--  070420  Shsalk   LCS merge 64353, Added new method Get_Fee_Type_For_Basic_Data().
--  070510  Prdilk   B141476, Modified Unpack_Check_Update___ to support translations. 
--  070601  Surmlk   Merged Bug 65074, corrected. Modifications done to allow change tax pecentage for sales and use tax 
--                   in all tax regimes. To avoid changing tax pecentage for VAT in all tax regimes. 
--  070810  Shwilk   Done Assert_SYS corrections.
--  071212  Maaylk   Bug 69131, Added new function Get_Fee_Type()
--  080709  Kagalk   Bug 75220, Changed error text constant to enable to translate it correctly.
--  090421  mawelk   Bug 80044, Corrected. Changesto Check_Delete___() and  Delete___()
--  090717  ErFelk   Bug 83174, Changed some error messages in Unpack_Check_Insert___, Unpack_Check_Update___ and Import___.
--  091106  Jofise   Bug 86773, Added column tax_reporting_category to STATUTORY_FEE_TAB. Changed from triangulation_trade
--                   to tax_reporting_category on all places in this file. Added new functions, Get_Tax_Reporting_Category_Db()
--                   and Get_Tax_Reporting_Category().
--  091224  Pwewlk   EAFH-1264, Removed the obsolete view TAX_CODE_LOV
--  100330  Nsillk   EAFH-2575, Added some validations in Copy method
--  100728  Umdolk   EANE-3003, Reverse engineering, Removed manual check for hold table in check_delete_.
--  100624  Gawilk   Bug 91364. Modified function Get.
--  101125  Elarse   Added a new view, STATUTORY_FEE_VAT_MULT, without restrictions for multiple tax.
--  110113  Elarse   DF-553, Added Get_Tax_Code_Info().
--  110503  Hiralk   EASTONE-16079, Added a new view STATUTORY_FEE_VAT_MULT_ZERO to restrict for non zero tax precentage VAT codes.
--  111018  Shdilk   SFI-135, Conditional compilation.
--  111104  Sacalk   SFI-618, Modified PROCEDURE Copy___
--  120627  THPELK   Bug 97225, Added Get_Tax_Code_Info() and Check_Fee_Code().
--  121123  Thpelk  Bug 106680 - Modified Conditional compilation to use single component package.
--  121130  SURBLK   Removed Genaral_SYS and Added pragma in to Check_Fee_Code().
--  121207  Maaylk  PEPA-183, Removed global variables
--  130515  Hawalk   Bug 108966, Checks whether a certain tax code is connected to an invoice in state 'Preliminary', before
--  130515           it is attempted to be deleted. Code changes inside Check_Delete___() and Validate_Modify___().
--  130612  JuKoDE   EDEL-2132, Added Check_Fee_Type_Not_Allowed()
--  130620  Dihelk   Bug 110672, Missing LOV tag was added for all views.
--  130807  Dihelk   Bug 111707, Missing LOV tag was added to the STATUTORY_FEE vie
--  140425  Lamalk   PBFI-6935, Modified 'Prepare_Insert___'. Added Decode method to fetch the correct value for TAX_REPORTING_CATEGORY column.
--  150318  Dipelk   KES-51, Added validation that checks deductible != 100 for 'RDE'(Surcharge VAT).
--  150422  Raablk   Bug 121320, Tax Code Created from Company Template should update correctly to basic data.
-----------------------------------------------------------------------------

layer Core;

-------------------- PUBLIC DECLARATIONS ------------------------------------


-------------------- PRIVATE DECLARATIONS -----------------------------------


-------------------- LU SPECIFIC IMPLEMENTATION METHODS ---------------------

PROCEDURE Validate_Modify___ (
   newrec_ IN STATUTORY_FEE_TAB%ROWTYPE )
IS
   fee_type_           VARCHAR2(10);
   fee_rate_           NUMBER;
   vat_received_       VARCHAR2(20);
   vat_disbursed_      VARCHAR2(20);
   deductible_         NUMBER;
   attr_               VARCHAR2(2000);
   result_             VARCHAR2(5);
   is_vat_code_        VARCHAR2(5) := 'FALSE';   
   CURSOR get_vat_surch IS
      SELECT fee_code
      FROM   statutory_fee_detail_tab
      WHERE  company      = newrec_.company
      AND    att_fee_code = newrec_.fee_code;
   CURSOR old_rec IS
      SELECT fee_type, fee_rate, vat_received,
             vat_disbursed, deductible
      FROM   STATUTORY_FEE_TAB
      WHERE  company  = newrec_.company
      AND    fee_code = newrec_.fee_code;
BEGIN
   OPEN  old_rec;
   FETCH old_rec INTO fee_type_, fee_rate_, vat_received_, vat_disbursed_, deductible_;
   CLOSE old_rec;
   $IF Component_Invoic_SYS.INSTALLED $THEN
      is_vat_code_ := Company_Invoice_Info_API.Is_Vat_Code_At_Inv_Line(newrec_.company);
   $END
   IF (is_vat_code_ = 'TRUE') THEN
      IF (newrec_.fee_type != fee_type_) OR 
         (newrec_.fee_rate != fee_rate_) OR 
         (newrec_.vat_received != vat_received_) OR 
         (newrec_.vat_disbursed != vat_disbursed_) OR 
         (newrec_.deductible != deductible_) THEN
         IF NOT ((newrec_.fee_type = 'SALETX' OR newrec_.fee_type = 'USETX') AND 
                 (newrec_.fee_rate != fee_rate_))THEN   
            -- Bug 108966, begin
            -- Check if tax code exists in invoice in state 'Preliminary' (i.e., no voucher yet).
            $IF Component_Invoic_SYS.INSTALLED $THEN
               result_ := Tax_Item_API.Tax_Code_Exist_In_Prel_Invoice(newrec_.company, newrec_.fee_code);
               
               IF (result_ = 'TRUE') THEN
                  Error_Sys.Record_General(lu_name_, 'NOTMODIFYPRELINV: You are not allowed to modify Tax Code :P1 since it is used in an invoice in preliminary state.', newrec_.fee_code);
               END IF;
            $END
            -- Bug 108966, end
            IF newrec_.fee_type = 'RDE' THEN
               -- Surcharge VAT validations
               FOR sur_rec_ IN get_vat_surch LOOP
                   -- Check if tax code exist in Hold Table
                   Voucher_Row_API.Tax_Code_In_Voucher_Row(result_, newrec_.company, sur_rec_.fee_code);
                   IF (result_ = 'TRUE') THEN
                      Error_Sys.Record_General(lu_name_,'NOTMODIFY: You are not allowed to modify Tax Code :P1 since it is used in the hold table.', newrec_.fee_code);
                   END IF;
                   -- Check if tax code exist in General Ledger
                   $IF Component_Genled_SYS.INSTALLED $THEN
                      Client_SYS.Clear_Attr(attr_);
                      Client_SYS.Add_To_Attr('COMPANY', newrec_.company, attr_);
                      Client_SYS.Add_To_Attr('TAX_CODE', sur_rec_.fee_code, attr_);
                      Gen_Led_Voucher_Row_API.Tax_Code_In_Gl_Voucher_Row ( attr_);
                   $END                 
               END LOOP;
            ELSE
               -- Check if tax code exist in Hold Table
               Voucher_Row_API.Tax_Code_In_Voucher_Row(result_, newrec_.company, newrec_.fee_code);
               IF (result_ = 'TRUE') THEN
                  Error_Sys.Record_General(lu_name_,'NOTMODIFY: You are not allowed to modify Tax Code :P1 since it is used in the hold table.', newrec_.fee_code);
               END IF;
               -- Check if tax code exist in General Ledger
               $IF Component_Genled_SYS.INSTALLED $THEN
                  Client_SYS.Clear_Attr(attr_);
                  Client_SYS.Add_To_Attr('COMPANY', newrec_.company, attr_);
                  Client_SYS.Add_To_Attr('TAX_CODE', newrec_.fee_code, attr_);
                  Gen_Led_Voucher_Row_API.Tax_Code_In_Gl_Voucher_Row ( attr_);
               $END
            END IF;   
         END IF;
      END IF;
   ELSIF is_vat_code_ = 'FALSE' AND 
      ((newrec_.fee_type = 'VAT' OR newrec_.fee_type = 'RDE') AND 
       newrec_.fee_rate != fee_rate_) THEN
      -- SALES TAX REGIME VALIDATIONS                                     
      IF (newrec_.fee_type = 'RDE') THEN
         -- Surcharge VAT validations
         FOR sur_rec_ IN get_vat_surch LOOP
            -- Check if tax code exist in Hold Table
            Voucher_Row_API.Tax_Code_In_Voucher_Row(result_, newrec_.company, sur_rec_.fee_code);
            IF (result_ = 'TRUE') THEN
               Error_Sys.Record_General(lu_name_,'NOTMODIFY: You are not allowed to modify Tax Code :P1 since it is used in the hold table.', newrec_.fee_code);
            END IF;
            -- Check if tax code exist in General Ledger
            $IF Component_Genled_SYS.INSTALLED $THEN
               Client_SYS.Clear_Attr(attr_);
               Client_SYS.Add_To_Attr('COMPANY', newrec_.company, attr_);
               Client_SYS.Add_To_Attr('TAX_CODE', sur_rec_.fee_code, attr_);
               Gen_Led_Voucher_Row_API.Tax_Code_In_Gl_Voucher_Row ( attr_);
            $END                 
         END LOOP;
      ELSE
         -- Check if tax code exist in Hold Table
         Voucher_Row_API.Tax_Code_In_Voucher_Row(result_, newrec_.company, newrec_.fee_code);
         IF (result_ = 'TRUE') THEN
            Error_Sys.Record_General(lu_name_,'NOTMODIFY: You are not allowed to modify Tax Code :P1 since it is used in the hold table.', newrec_.fee_code);
         END IF;
         -- Check if tax code exist in General Ledger
         $IF Component_Genled_SYS.INSTALLED $THEN
            Client_SYS.Clear_Attr(attr_);
            Client_SYS.Add_To_Attr('COMPANY', newrec_.company, attr_);
            Client_SYS.Add_To_Attr('TAX_CODE', newrec_.fee_code, attr_);
            Gen_Led_Voucher_Row_API.Tax_Code_In_Gl_Voucher_Row ( attr_);
         $END
      END IF;
   END IF;
END Validate_Modify___;


-- Check_Exist___
--   Check if a specific LU-instance already exist in the database.
FUNCTION Check_Exist___ (
   company_    IN VARCHAR2,
   fee_code_   IN VARCHAR2,
   valid_from_ IN DATE) RETURN BOOLEAN
IS
   dummy_ NUMBER;
   CURSOR exist_control1 IS
      SELECT 1
      FROM   STATUTORY_FEE_TAB
      WHERE  company    = company_
      AND    fee_code   = fee_code_
      AND    valid_from = valid_from_;   
BEGIN
   IF (valid_from_ IS NULL) THEN
      RETURN Check_Exist___(company_, fee_code_);
   ELSE
      OPEN  exist_control1;
      FETCH exist_control1 INTO dummy_;
      IF (exist_control1%FOUND) THEN
         CLOSE exist_control1;
         RETURN(TRUE);
      END IF;
      CLOSE exist_control1;
      RETURN(FALSE);
   END IF;
END Check_Exist___;


FUNCTION Check_Exist_Deductible___ (
   company_    IN VARCHAR2,
   fee_code_   IN VARCHAR2,
   valid_from_ IN DATE DEFAULT NULL ) RETURN BOOLEAN
IS
   dummy_ NUMBER;
   CURSOR exist_control1 IS
      SELECT 1
      FROM   STATUTORY_FEE_TAB
      WHERE  company     = company_
      AND    fee_code    = fee_code_
      AND    valid_from  = valid_from_
      AND    deductible != 100;
   CURSOR exist_control2 IS
      SELECT 1
      FROM   STATUTORY_FEE_TAB
      WHERE  company     = company_
      AND    fee_code    = fee_code_
      AND    deductible != 100;
BEGIN
   IF valid_from_ IS NULL THEN
      OPEN  exist_control2;
      FETCH exist_control2 INTO dummy_;
      IF (exist_control2%FOUND) THEN
         CLOSE exist_control2;
         RETURN(TRUE);
      END IF;
      CLOSE exist_control2;
      RETURN(FALSE);
   ELSE
      OPEN  exist_control1;
      FETCH exist_control1 INTO dummy_;
      IF (exist_control1%FOUND) THEN
         CLOSE exist_control1;
         RETURN(TRUE);
      END IF;
      CLOSE exist_control1;
      RETURN(FALSE);
   END IF;
END Check_Exist_Deductible___;


FUNCTION Check_Exist_Withhold___ (
   company_    IN VARCHAR2,
   fee_code_   IN VARCHAR2,
   valid_from_ IN DATE DEFAULT NULL ) RETURN BOOLEAN
IS
   dummy_ NUMBER;
   CURSOR exist_withhold IS
      SELECT 1
      FROM   STATUTORY_FEE_TAB
      WHERE  company    = company_
      AND    fee_code   = fee_code_
      AND    valid_from = valid_from_
      AND    fee_type   IN ('IRS1099TX');
   CURSOR exist_withhold2 IS
      SELECT 1
      FROM   STATUTORY_FEE_TAB
      WHERE  company  = company_
      AND    fee_code = fee_code_
      AND    fee_type IN ('IRS1099TX');
BEGIN
   IF valid_from_ IS NULL THEN
      OPEN  exist_withhold2;
      FETCH exist_withhold2 INTO dummy_;
      IF (exist_withhold2%FOUND) THEN
         CLOSE exist_withhold2;
         RETURN(TRUE);
      END IF;
      CLOSE exist_withhold2;
      RETURN(FALSE);
   ELSE
      OPEN  exist_withhold;
      FETCH exist_withhold INTO dummy_;
      IF (exist_withhold%FOUND) THEN
         CLOSE exist_withhold;
         RETURN(TRUE);
      END IF;
      CLOSE exist_withhold;
      RETURN(FALSE);
   END IF;
END Check_Exist_Withhold___;


@Override
PROCEDURE Import_Assign___ (
   newrec_      IN OUT statutory_fee_tab%ROWTYPE,
   crecomp_rec_ IN     Enterp_Comp_Connect_V170_API.Crecomp_Lu_Public_Rec,
   pub_rec_     IN     Create_Company_Template_Pub%ROWTYPE )
IS
BEGIN
   super(newrec_, crecomp_rec_, pub_rec_);
   newrec_.valid_from := crecomp_rec_.valid_from;
END Import_Assign___;

   
@Override
PROCEDURE Prepare_Insert___ (
   attr_ IN OUT VARCHAR2 )
IS
   valid_until_      Accrul_Attribute_Tab.attribute_value%TYPE;
BEGIN
   valid_until_    := Accrul_Attribute_API.Get_Attribute_Value('DEFAULT_VALID_TO');
   super(attr_);
   Client_SYS.Add_To_Attr( 'VALID_UNTIL', to_date(valid_until_, 'YYYYMMDD'), attr_ );
   Client_SYS.Add_To_Attr( 'VAT_RECEIVED', Vat_Method_API.Decode(1), attr_ );
   Client_SYS.Add_To_Attr( 'VAT_DISBURSED', Vat_Method_API.Decode(1), attr_ );
   Client_SYS.Add_To_Attr( 'DEDUCTIBLE', 100, attr_ );
   Client_SYS.Add_To_Attr( 'MULTIPLE_TAX', 'FALSE', attr_);
   Client_SYS.Add_To_Attr( 'USE_WITHHOLD_AMOUNT_TABLE', 'FALSE', attr_);
   Client_SYS.Add_To_Attr( 'TAX_AMOUNT_AT_INV_PRINT', Tax_Amount_At_Inv_Print_API.Decode('SEPARATE'), attr_ );
   Client_SYS.Add_To_Attr( 'TAX_REPORTING_CATEGORY',Tax_Reporting_Category_API.Decode('NONE'), attr_);
END Prepare_Insert___;


@Override
PROCEDURE Insert___ (
   objid_      OUT    VARCHAR2,
   objversion_ OUT    VARCHAR2,
   newrec_     IN OUT STATUTORY_FEE_TAB%ROWTYPE,
   attr_       IN OUT VARCHAR2 )
IS
BEGIN
   super(objid_, objversion_, newrec_, attr_);
   Tax_Book_API.New_Fee_Code(newrec_.company, newrec_.fee_code);
EXCEPTION
   WHEN dup_val_on_index THEN
      Error_SYS.Record_Exist(lu_name_);
END Insert___;

@Override
PROCEDURE Update___ (
   objid_      IN     VARCHAR2,
   oldrec_     IN     STATUTORY_FEE_TAB%ROWTYPE,
   newrec_     IN OUT NOCOPY STATUTORY_FEE_TAB%ROWTYPE,
   attr_       IN OUT NOCOPY VARCHAR2,
   objversion_ IN OUT NOCOPY VARCHAR2,
   by_keys_    IN     BOOLEAN DEFAULT FALSE )
IS
BEGIN
   super(objid_, oldrec_, newrec_, attr_, objversion_, by_keys_);
   IF (newrec_.deductible != oldrec_.deductible) THEN
      $IF Component_Trvexp_SYS.INSTALLED $THEN
         Expense_Code_Tax_Lines_API.Update_Recoverable(newrec_.company, newrec_.fee_code, newrec_.deductible);
      $ELSE
         NULL;
      $END
   END IF;
EXCEPTION
   WHEN dup_val_on_index THEN
      Error_SYS.Record_Exist(lu_name_);
END Update___;
   
@Override
PROCEDURE Check_Delete___ (
   remrec_ IN STATUTORY_FEE_TAB%ROWTYPE )
IS
   result_ VARCHAR2(100);
   attr_   VARCHAR2(2000);
   key_    VARCHAR2(2000);
BEGIN
   IF (NOT remrec_.valid_from IS NULL) THEN
      -- Bug 108966, begin
      -- Check if tax code exists in invoice in state 'Preliminary' (i.e., no voucher yet).
      $IF Component_Invoic_SYS.INSTALLED $THEN
         result_ := Tax_Item_API.Tax_Code_Exist_In_Prel_Invoice(remrec_.company, remrec_.fee_code);

         IF (result_ = 'TRUE') THEN
            Error_Sys.Record_General(lu_name_, 'NOTDELETEPRELINV: You are not allowed to delete Tax Code :P1 since it is used in an invoice in preliminary state.', remrec_.fee_code);
         END IF;
      $END
      -- Bug 108966, end
      --Check if tax code has other Tax Codes attached
      result_ := Get_Multiple_Tax(remrec_.company, remrec_.fee_code);
      IF (result_ = 'TRUE') THEN
         Error_Sys.Record_General(lu_name_,'NOTDELMULTI: You are not allowed to delete Tax Code :P1 since it has Tax Codes attached to it.', remrec_.fee_code);
      END IF;
      --Check if tax code is attached to another
      result_ := Check_Attached(remrec_.company, remrec_.fee_code);
      IF (result_ = 'TRUE') THEN
         Error_Sys.Record_General(lu_name_,'NOTDELATT: You are not allowed to delete Tax Code :P1 since it is attached to another Tax Code(s).', remrec_.fee_code);
      END IF;
      -- Check if tax code exist in General Ledger
      $IF Component_Genled_SYS.INSTALLED $THEN
         Client_SYS.Clear_Attr(attr_);
         Client_SYS.Add_To_Attr('COMPANY', remrec_.company, attr_);
         Client_SYS.Add_To_Attr('TAX_CODE', remrec_.fee_code, attr_);
         Gen_Led_Voucher_Row_API.Tax_Code_In_Gl_Voucher_Row ( attr_);
      $END
      Tax_Code_Per_Tax_Book_API.Delete_Rec(remrec_.company, remrec_.fee_code);

      key_ := remrec_.company || '^' || remrec_.fee_code || '^' || remrec_.valid_from || '^';
      Reference_SYS.Check_Restricted_Delete(lu_name_, key_);
   ELSE
      super(remrec_);  
   END IF; 
END Check_Delete___;


@Override
PROCEDURE Delete___ (
   objid_  IN VARCHAR2,
   remrec_ IN STATUTORY_FEE_TAB%ROWTYPE )
IS
   key_ VARCHAR2(2000);
BEGIN
   IF (NOT remrec_.valid_from IS NULL) THEN 
      key_ := remrec_.company || '^' || remrec_.fee_code || '^' || remrec_.valid_from || '^';
      Reference_SYS.Do_Cascade_Delete(lu_name_, key_);
      DELETE
         FROM  STATUTORY_FEE_TAB
         WHERE rowid = objid_;      
   ELSE
      super(objid_,remrec_);
   END IF;
END Delete___;


@Override
PROCEDURE Check_Common___ (
   oldrec_ IN     statutory_fee_tab%ROWTYPE,
   newrec_ IN OUT statutory_fee_tab%ROWTYPE,
   indrec_ IN OUT Indicator_Rec,
   attr_   IN OUT VARCHAR2 )
IS
BEGIN
   -- Bug 121320, begin
   IF (newrec_.multiple_tax IS NOT NULL AND newrec_.multiple_tax NOT IN ('TRUE', 'FALSE')) THEN 
      newrec_.multiple_tax := Fnd_Boolean_API.Encode(newrec_.multiple_tax); 
   END IF;
   IF (newrec_.multiple_tax IS NULL) THEN
      newrec_.multiple_tax := 'FALSE';
   END IF;
   
   IF (newrec_.use_withhold_amount_table IS NOT NULL AND newrec_.use_withhold_amount_table NOT IN ('TRUE', 'FALSE')) THEN
      newrec_.use_withhold_amount_table := Fnd_Boolean_API.Encode(newrec_.use_withhold_amount_table);
   END IF;
   IF (newrec_.use_withhold_amount_table IS NULL) THEN
      newrec_.use_withhold_amount_table := 'FALSE';
   END IF;
   -- Bug 121320, end
   super(oldrec_, newrec_, indrec_, attr_);

   IF (indrec_.fee_rate) THEN
      IF (newrec_.fee_rate  < 0 ) THEN
         Error_SYS.Appl_General(lu_name_,'INVALIDFEERATE: Tax Percentage can not be less than 0% ');
      END IF;
   END IF;
   IF (indrec_.vat_disbursed) THEN
      IF (newrec_.vat_disbursed = '2') THEN
         Error_SYS.Appl_General(lu_name_,'NOTVATMETH: Tax Method :P1 is not allowed for Outgoing Invoices ', Vat_Method_Api.Decode(newrec_.vat_disbursed));
      END IF;
   END IF;
   IF (indrec_.deductible) THEN
      IF (newrec_.deductible < 0 OR newrec_.deductible > 100 ) THEN
         Error_SYS.Appl_General(lu_name_,'DEDUCT: Deductible must be between 0% - 100%');
      END IF;
   END IF;
   IF (newrec_.tax_amt_limit IS NOT NULL ) THEN
      IF ((newrec_.fee_type = 'NOTAX') OR (newrec_.fee_type = 'IRS1099TX') OR (newrec_.fee_type = 'RDE')) THEN
         Error_SYS.Appl_General(lu_name_,'INVALID_LIMIT: Not possible to use a Tax Amount Limit for tax code :P1 of tax type :P2', newrec_.fee_code, Fee_Type_API.Decode(newrec_.fee_type));
      END IF;
   END IF;
   IF (newrec_.fee_type != 'VAT')      AND 
       newrec_.fee_type != 'IRS1099TX' AND 
       newrec_.fee_type != 'RDE'       AND 
       newrec_.fee_type != 'CALCVAT'   AND 
      (newrec_.vat_disbursed = '3' OR newrec_.vat_received = '3') THEN
      Error_SYS.Appl_General(lu_name_,'PAYMTONLYVATWITH: Tax Method :P1 is not valid for the selected Tax Type.', Vat_Method_API.Decode('3'));
   END IF;
   IF (newrec_.valid_from > newrec_.valid_until) THEN
      Error_SYS.Record_General( 'StatutoryFee', 'WRONGDATE: Valid until must be greater than valid from' );
   END IF;
   IF (newrec_.fee_type IN ('SALETX', 'USETX') AND newrec_.vat_received = '2') THEN
      Error_SYS.Record_General( 'StatutoryFee', 'SALUSETAXWITHFINAL: It is not allowed to use Sales Tax or Use Tax with Tax Method Tax Received equals to Final Posting.');
   END IF;

   IF (newrec_.fee_type = 'NOTAX') THEN
      IF (newrec_.fee_rate != 0) THEN
         Error_SYS.Appl_General(lu_name_,'INVALID_RATE: Percentage must be 0 for Tax Code with Tax Type :P1', Fee_Type_API.Decode(newrec_.fee_type));
      END IF;
      IF (newrec_.vat_disbursed != '4' OR newrec_.vat_received != '4') THEN
         Error_SYS.Appl_General(lu_name_,'INVALID_METHOD: Tax Method must be :P1 for Tax Code with Tax Type :P2', Vat_Method_API.Decode('4'), Fee_Type_API.Decode(newrec_.fee_type));
      END IF;
      IF (newrec_.deductible != 100) THEN
         Error_SYS.Appl_General(lu_name_,'INVALID_DEDUCT: The Deductible % must be 100 for a tax code with tax type :P1', Fee_Type_API.Decode(newrec_.fee_type));
      END IF;
   ELSIF (newrec_.fee_type = 'IRS1099TX') THEN
      IF (newrec_.vat_received NOT IN ('1','3') OR newrec_.vat_disbursed NOT IN ('1','3')) THEN   
         Error_SYS.Appl_General(lu_name_,'TAXWITHOLD: Only Tax Method :P1 or :P2 is valid for a Tax Code with Tax Type :P3', Vat_Method_API.Decode('1'), Vat_Method_API.Decode('3'), Fee_Type_API.Decode(newrec_.fee_type));
      END IF;
   ELSE
      IF (newrec_.fee_type = 'RDE') AND (newrec_.deductible != 100) THEN
         Error_SYS.Appl_General(lu_name_,'INVALID_DEDUCT: The Deductible % must be 100 for a tax code with tax type :P1', Fee_Type_API.Decode(newrec_.fee_type));
      END IF;
      IF (newrec_.vat_disbursed = '4' OR newrec_.vat_received = '4') THEN
         Error_SYS.Appl_General(lu_name_,'INV_METHOD: Tax Method must not be :P1 for Tax Type :P2', Vat_Method_API.Decode('4'), Fee_Type_API.Decode(newrec_.fee_type));
      END IF;
   END IF;
END Check_Common___;


@Override
PROCEDURE Check_Insert___ (
   newrec_ IN OUT statutory_fee_tab%ROWTYPE,
   indrec_ IN OUT Indicator_Rec,
   attr_   IN OUT VARCHAR2 )
IS
   name_  VARCHAR2(30);
   value_ VARCHAR2(4000);
   fee_type_db_   VARCHAR2(20);
BEGIN
   IF (newrec_.tax_reporting_category IS NULL) THEN
      newrec_.tax_reporting_category := 'NONE';
   END IF;
   -- Bug 121320, removed some code
   fee_type_db_ := newrec_.fee_type;

   super(newrec_, indrec_, attr_);
   
   Client_SYS.Add_To_Attr( 'FEE_TYPE_DB', fee_type_db_, attr_);
EXCEPTION
   WHEN value_error THEN
      Error_SYS.Item_Format(lu_name_, name_, value_);
END Check_Insert___;


@Override
PROCEDURE Check_Update___ (
   oldrec_ IN     statutory_fee_tab%ROWTYPE,
   newrec_ IN OUT statutory_fee_tab%ROWTYPE,
   indrec_ IN OUT Indicator_Rec,
   attr_   IN OUT VARCHAR2 )
IS
   name_  VARCHAR2(30);
   value_ VARCHAR2(4000);
   fee_type_db_   VARCHAR2(20);
BEGIN
   super(oldrec_, newrec_, indrec_, attr_);
   Client_SYS.Set_Item_Value( 'FEE_TYPE_DB', fee_type_db_, attr_);
   
   IF (indrec_.fee_type) THEN
      IF STATUTORY_FEE_DETAIL_API.Check_Used_Tax_Code(newrec_.company, newrec_.fee_code) THEN
         Error_SYS.Appl_General(lu_name_,'USEDINDETAIL: You are not allowed to change the type since Tax Code is used in multiple tax');
      END IF;
   END IF;

   -- Bug 121320, removed some code
   
   IF (newrec_.use_withhold_amount_table = 'TRUE') THEN
      IF (newrec_.fee_rate != 0) THEN
         Error_SYS.Appl_General(lu_name_,'INVALID_RATE2: Percentage must be 0 for a Tax Code with parameter Use Withholding Amount Table checked');
      ELSIF (newrec_.deductible != 100) THEN
         Error_SYS.Appl_General(lu_name_,'INVALID_DEDUCT2: Deductible % must be 100 for a Tax Code with parameter Use Withholding Amount Table checked');
      ELSIF (newrec_.vat_received != '3') THEN
         Error_SYS.Appl_General(lu_name_,'INVALID_VATREC: Tax Method Tax Received must be :P1 for a Tax Code with parameter Use Withholding Amount Table checked',Vat_Method_API.Decode('3'));
      ELSIF (newrec_.vat_disbursed != '3') THEN
         Error_SYS.Appl_General(lu_name_,'INVALID_VATDIS: Tax Method Tax Disbursed must be :P1 for a Tax Code with parameter Use Withholding Amount Table checked',Vat_Method_API.Decode('3'));
      END IF;
   END IF;
   IF newrec_.tax_reporting_category IS NULL THEN
      newrec_.tax_reporting_category := 'NONE';
   END IF;
   fee_type_db_ := newrec_.fee_type;
   Validate_Modify___(newrec_);
EXCEPTION
   WHEN value_error THEN
      Error_SYS.Item_Format(lu_name_, name_, value_);
END Check_Update___;


-------------------- LU SPECIFIC PRIVATE METHODS ----------------------------

@Override
PROCEDURE Remove__ (
   info_       OUT VARCHAR2,
   objid_      IN  VARCHAR2,
   objversion_ IN  VARCHAR2,
   action_     IN  VARCHAR2 )
IS
   remrec_ STATUTORY_FEE_TAB%ROWTYPE;
BEGIN
   super(info_, objid_, objversion_, action_);
   
   IF action_ = 'DO' THEN
      Tax_Liablty_Date_Exception_Api.Remove_Exception_Tax_Codes(info_,
                                                                remrec_.company,
                                                                remrec_.fee_code);   
   END IF;
   
END Remove__;

@Override
PROCEDURE Raise_Record_Not_Exist___ (
   company_ IN VARCHAR2,
   fee_code_ IN VARCHAR2 )
IS
BEGIN
   Error_SYS.Appl_General(lu_name_,'TAXNOTEXISTCO: The tax code :P1 does not exist in company :P2.', fee_code_, company_);
   super(company_, fee_code_);

END Raise_Record_Not_Exist___;



-------------------- LU SPECIFIC PROTECTED METHODS --------------------------

-------------------- LU SPECIFIC PUBLIC METHODS -----------------------------

-- Exist
--   Checks if given pointer (e.g. primary key) to an instance of this
--   logical unit exists. If not an exception will be raised.
@UncheckedAccess
PROCEDURE Exist (
   company_    IN VARCHAR2,
   fee_code_   IN VARCHAR2,
   valid_from_ IN DATE )
IS
BEGIN
   IF (NOT Check_Exist___(company_, fee_code_, valid_from_)) THEN
      Error_SYS.Appl_General(lu_name_,'TAXNOTEXISTCO: The tax code :P1 does not exist in company :P2.', fee_code_, company_);
   END IF;
END Exist;


-- Exist
--   Checks if given pointer (e.g. primary key) to an instance of this
--   logical unit exists. If not an exception will be raised.



PROCEDURE Exist_Deductible (
   company_    IN VARCHAR2,
   fee_code_   IN VARCHAR2,
   valid_from_ IN DATE DEFAULT NULL )
IS
BEGIN
   IF (NOT Check_Exist___(company_, fee_code_, valid_from_)) THEN
      Error_SYS.Appl_General(lu_name_,'TAXNOTEXIST: Tax code does not exist.', fee_code_);
   END IF;
END Exist_Deductible;


PROCEDURE Exist_Withhold (
   company_    IN VARCHAR2,
   fee_code_   IN VARCHAR2,
   valid_from_ IN DATE DEFAULT NULL )
IS
BEGIN
   IF (NOT Check_Exist_Withhold___(company_, fee_code_, valid_from_)) THEN
      Error_SYS.Appl_General(lu_name_,'CODENOTEXIST: Tax withhold code does not exist.', fee_code_);
   END IF;
END Exist_Withhold;


@Override
@UncheckedAccess
@SecurityCheck Company.UserAuthorized(company_)
FUNCTION Get_Description (
   company_    IN VARCHAR2,
   fee_code_ IN VARCHAR2 ) RETURN VARCHAR2
IS
BEGIN
    RETURN super(company_,fee_code_);
END Get_Description;


@UncheckedAccess
@SecurityCheck Company.UserAuthorized(company_)
FUNCTION Get_Description (
   company_    IN VARCHAR2,
   fee_code_   IN VARCHAR2,
   valid_from_ IN DATE ,
   lang_code_  IN VARCHAR2  ) RETURN VARCHAR2
IS
   dummy_  VARCHAR2(100);
   CURSOR get_desc IS
      SELECT description
      FROM STATUTORY_FEE_TAB
      WHERE company    = company_
      AND   fee_code   = fee_code_;
BEGIN
   OPEN get_desc;
   FETCH get_desc INTO dummy_;
   IF (get_desc%NOTFOUND) THEN
      CLOSE get_desc;
      RETURN (NULL);
   ELSE
      CLOSE get_desc;
      dummy_ := nvl(substr(Enterp_Comp_Connect_V170_API.Get_Company_Translation(company_,'ACCRUL', 'StatutoryFee', fee_code_,lang_code_),1,100), dummy_);
      RETURN (dummy_ );
   END IF;
END Get_Description;


@SecurityCheck Company.UserAuthorized(company_)
PROCEDURE Get_Fee_Percent (
   percent_  OUT NUMBER,
   company_  IN  VARCHAR2,
   fee_code_ IN  VARCHAR2,
   date_     IN  DATE )
IS
   fee_type_ VARCHAR2(20);
   CURSOR getfee IS
      SELECT fee_rate, fee_type
      FROM   STATUTORY_FEE_TAB
      WHERE  company  = company_
      AND    fee_code = fee_code_
      AND    TRUNC(date_) BETWEEN valid_from AND valid_until;
BEGIN
   OPEN getfee;
   FETCH getfee INTO percent_, fee_type_;
   IF (getfee%NOTFOUND) THEN
      CLOSE getfee;
         Error_SYS.Record_General(lu_name_, 'NOPERCENT: The tax code :P1 is missing or has invalid time interval.', fee_code_);
   ELSE
      CLOSE getfee;
   END IF;
   IF ( fee_type_ = 'CALCVAT' ) THEN
      percent_ := 0;
   END IF;
END Get_Fee_Percent;


@UncheckedAccess
@SecurityCheck Company.UserAuthorized(company_)
FUNCTION Get_Percentage (
   company_  IN VARCHAR2,
   fee_code_ IN VARCHAR2,
   date_     IN DATE DEFAULT SYSDATE ) RETURN NUMBER
IS
   percent_  NUMBER;
   fee_type_ VARCHAR2(20);
   CURSOR getpercent IS
      SELECT fee_rate, fee_type
      FROM   STATUTORY_FEE_TAB
      WHERE  company  = company_
      AND    fee_code = fee_code_
      AND    TRUNC(date_) BETWEEN valid_from AND valid_until;
BEGIN
   OPEN getpercent;
   FETCH getpercent INTO percent_, fee_type_;
   CLOSE getpercent;
   IF ( fee_type_ = 'CALCVAT' ) THEN
      RETURN 0;
   ELSE
      RETURN percent_;
   END IF;
END Get_Percentage;

@Override
@SecurityCheck Company.UserAuthorized(company_)
FUNCTION Get_Fee_Type (
   company_  IN     VARCHAR2,
   fee_code_ IN     VARCHAR2 ) RETURN statutory_fee_tab.fee_type%TYPE
IS
BEGIN
   --Add pre-processing code here
   RETURN super(company_, fee_code_);
END Get_Fee_Type;

@UncheckedAccess
@SecurityCheck Company.UserAuthorized(company_)
PROCEDURE Get_Fee_Type (
   fee_type_ OUT VARCHAR2,
   company_  IN  VARCHAR2,
   fee_code_ IN  VARCHAR2,
   date_     IN  DATE DEFAULT NULL )
IS

   fee_type_db_   VARCHAR2(20);
   CURSOR get_type IS
      SELECT fee_type
      FROM   STATUTORY_FEE_TAB
      WHERE  company  = company_
      AND    fee_code = fee_code_
      AND    trunc(NVL(date_,SYSDATE)) BETWEEN valid_from AND valid_until;
BEGIN
   OPEN get_type;
   FETCH get_type INTO fee_type_db_;
   IF (get_type%NOTFOUND) THEN
      CLOSE get_type;
         Error_SYS.Record_General(lu_name_, 'MISSINVTIME: The tax code :P1 is missing or has invalid time interval.', fee_code_);
   ELSE
      CLOSE get_type;
   END IF;
   fee_type_ := fee_type_db_;
END Get_Fee_Type;



@SecurityCheck Company.UserAuthorized(company_)
PROCEDURE Get_Fee_Type_Tax_Code_Entry (
   fee_type_ OUT VARCHAR2,
   company_  IN  VARCHAR2,
   fee_code_ IN  VARCHAR2 )
IS
   fee_type_db_   VARCHAR2(20);
   CURSOR get_type IS
      SELECT fee_type
      FROM   STATUTORY_FEE_TAB
      WHERE  company  = company_
      AND    fee_code = fee_code_;
BEGIN
   OPEN  get_type;
   FETCH get_type INTO fee_type_db_;
   IF (get_type%NOTFOUND) THEN
      CLOSE get_type;
         Error_SYS.Record_General(lu_name_, 'MISSINVTIME: The tax code :P1 is missing or has invalid time interval.', fee_code_);
   ELSE
      CLOSE get_type;
   END IF;
   fee_type_ := fee_type_db_;
END Get_Fee_Type_Tax_Code_Entry;

@UncheckedAccess
@SecurityCheck Company.UserAuthorized(company_)   
PROCEDURE Get_Fee_Type_Client (
   fee_type_ OUT VARCHAR2,
   company_  IN  VARCHAR2,
   fee_code_ IN  VARCHAR2,
   date_     IN  DATE DEFAULT SYSDATE )
IS
   CURSOR get_type IS
      SELECT Fee_Type_API.Decode(fee_type)
      FROM   statutory_fee_tab
      WHERE  company  = company_
      AND    fee_code = fee_code_
      AND    trunc(date_) BETWEEN valid_from AND valid_until;
BEGIN
   OPEN  get_type;
   FETCH get_type INTO fee_type_;
   IF (get_type%NOTFOUND) THEN
      CLOSE get_type;
         Error_SYS.Record_General(lu_name_, 'MISSINVTIME: The tax code :P1 is missing or has invalid time interval.', fee_code_);
   ELSE
      CLOSE get_type;
   END IF;
END Get_Fee_Type_Client;


@SecurityCheck Company.UserAuthorized(company_)   
PROCEDURE Get_Fee_Type_For_Basic_Data(
   fee_type_ OUT VARCHAR2,
   company_  IN  VARCHAR2,
   fee_code_ IN  VARCHAR2,
   date_     IN  DATE DEFAULT NULL )
IS 
   fee_type_db_   VARCHAR2(20);
   valid_date_    DATE;  
   CURSOR get_type IS
      SELECT fee_type
      FROM   STATUTORY_FEE_TAB
      WHERE  company  = company_
      AND    fee_code = fee_code_
      AND    trunc(NVL(date_,SYSDATE)) BETWEEN valid_from AND valid_until;
   CURSOR get_fee_type IS
      SELECT fee_type, valid_from
      FROM   STATUTORY_FEE_TAB                           
      WHERE  company  = company_
      AND    fee_code = fee_code_;
BEGIN
   OPEN get_type;
   FETCH get_type INTO fee_type_db_;       
   IF (get_type%NOTFOUND) THEN
      CLOSE get_type;
      OPEN get_fee_type;
      FETCH get_fee_type INTO fee_type_db_, valid_date_;
      IF (valid_date_ >= trunc(NVL(date_, SYSDATE))) THEN
         Client_SYS.Add_Info(lu_name_, 'FUTUREDATE: The tax code has a valid from date that is higher than today date. You can still set up the Customer or Supplier using this tax code, but it will not be possible to create or enter invoices using this tax code before its valid from date.');          
      ELSE
            Error_SYS.Record_General(lu_name_, 'MISSINVTIME: The tax code :P1 is missing or has invalid time interval.', fee_code_);
      END IF;
      CLOSE get_fee_type;
   ELSE
      CLOSE get_type;
   END IF;
   fee_type_ := fee_type_db_;
END Get_Fee_Type_For_Basic_Data;


PROCEDURE Get_Control_Type_Value_Desc (
   description_   OUT VARCHAR2,
   company_       IN VARCHAR2,
   fee_code_      IN VARCHAR2,
   valid_from_    IN DATE DEFAULT NULL )
IS
BEGIN
   description_ := Get_Description( company_, fee_code_, valid_from_,NULL );
END Get_Control_Type_Value_Desc;


@UncheckedAccess
@SecurityCheck Company.UserAuthorized(company_)
FUNCTION Get_Calculated_Percent (
   company_  IN VARCHAR2,
   fee_type_ IN VARCHAR2,
   fee_code_ IN VARCHAR2,
   date_     IN DATE ) RETURN NUMBER
IS
   percent_ NUMBER;
   CURSOR getpercent IS
      SELECT fee_rate
      FROM   STATUTORY_FEE_TAB
      WHERE  company  = company_
      AND    fee_code = fee_code_
      AND    fee_type = fee_type_
      AND    trunc(nvl(date_, SYSDATE)) BETWEEN valid_from AND valid_until;
BEGIN
   OPEN getpercent;
   FETCH getpercent INTO percent_;
   CLOSE getpercent;
   RETURN percent_;
END Get_Calculated_Percent;


@UncheckedAccess


@UncheckedAccess
@SecurityCheck Company.UserAuthorized(company_)
FUNCTION Get_Deductible_Percent (
   company_  IN VARCHAR2,
   fee_type_ IN VARCHAR2,
   fee_code_ IN VARCHAR2,
   date_     IN DATE ) RETURN NUMBER
IS
   deductpercent_ NUMBER;
   CURSOR getdeductpercent IS
      SELECT deductible
      FROM   STATUTORY_FEE_TAB
      WHERE  company  = company_
      AND    fee_code = fee_code_
      AND    fee_type = fee_type_
      AND    trunc(nvl(date_, SYSDATE)) BETWEEN valid_from AND valid_until;
BEGIN
   OPEN getdeductpercent;
   FETCH getdeductpercent INTO deductpercent_;
   CLOSE getdeductpercent;
   RETURN deductpercent_;
END Get_Deductible_Percent;


@Override
@UncheckedAccess
FUNCTION Get_Tax_Amt_Limit (
   company_  IN VARCHAR2,
   fee_code_ IN VARCHAR2 ) RETURN NUMBER
IS
BEGIN
   RETURN Get_Tax_Amt_Limit (company_,fee_code_,SYSDATE);
   
   RETURN super(company_, fee_code_);
END Get_Tax_Amt_Limit;


@UncheckedAccess
FUNCTION Get_Tax_Amt_Limit (
   company_  IN VARCHAR2,
   fee_code_ IN VARCHAR2,
   date_     IN DATE) RETURN NUMBER
IS
   percent_  NUMBER;
   CURSOR getpercent IS
      SELECT tax_amt_limit
      FROM   STATUTORY_FEE_TAB
      WHERE  company  = company_
      AND    fee_code = fee_code_
      AND    date_    BETWEEN valid_from AND valid_until;
BEGIN
   OPEN  getpercent;
   FETCH getpercent INTO percent_;
   CLOSE getpercent;
   RETURN percent_;
END Get_Tax_Amt_Limit;


@Override
@UncheckedAccess
FUNCTION Get_Minimum_Base_Amount (
   company_  IN VARCHAR2,
   fee_code_ IN VARCHAR2 ) RETURN NUMBER
IS
BEGIN
   RETURN Get_Minimum_Base_Amount(company_,fee_code_,SYSDATE);
   RETURN super(company_, fee_code_);
END Get_Minimum_Base_Amount;


@UncheckedAccess
FUNCTION Get_Minimum_Base_Amount (
   company_  IN VARCHAR2,
   fee_code_ IN VARCHAR2,
   date_     IN DATE ) RETURN NUMBER
IS
   minimum_base_amount_  NUMBER;
   CURSOR getminbaseamt IS
      SELECT minimum_base_amount
      FROM   STATUTORY_FEE_TAB
      WHERE  company  = company_
      AND    fee_code = fee_code_
      AND    date_    BETWEEN valid_from AND valid_until;
BEGIN

   OPEN  getminbaseamt;
   FETCH getminbaseamt INTO minimum_base_amount_;
   CLOSE getminbaseamt;
   RETURN minimum_base_amount_;
END Get_Minimum_Base_Amount;


@UncheckedAccess
FUNCTION Get_Comp_Tax_Amt_Limit_Lines (
   company_  IN VARCHAR2 ) RETURN VARCHAR2
IS
   tax_amt_limit_line_  VARCHAR2(5);
BEGIN
   $IF Component_Invoic_SYS.INSTALLED $THEN
      tax_amt_limit_line_ := COMPANY_INVOICE_INFO_API.Get_Tax_Amount_Limit(company_);
   $END
   RETURN tax_amt_limit_line_;
END Get_Comp_Tax_Amt_Limit_Lines;


@UncheckedAccess
@SecurityCheck Company.UserAuthorized(company_)
FUNCTION Get_Tot_Attached_Fee_Rate (
   company_  IN VARCHAR2,
   fee_code_ IN VARCHAR2 ) RETURN NUMBER
IS
   tot_fee_rate_  NUMBER := 0;
   CURSOR get_att_fee_code IS
      SELECT att_fee_code
      FROM   statutory_fee_detail_tab
      WHERE  company  = company_
      AND    fee_code = fee_code_;
BEGIN
   FOR rec_ IN get_att_fee_code LOOP
         tot_fee_rate_ :=tot_fee_rate_ + Get_Fee_Rate(company_,rec_.att_fee_code);
   END LOOP;
   RETURN tot_fee_rate_;
END Get_Tot_Attached_Fee_Rate;


@UncheckedAccess
FUNCTION Is_Withheld (
   company_  IN VARCHAR2,
   fee_code_ IN VARCHAR2 ) RETURN VARCHAR2
IS
   temp_         VARCHAR2(5);
   valid_from_   DATE;
BEGIN
   IF (NOT Check_Exist_Withhold___(company_, fee_code_, valid_from_)) THEN
      temp_ := 'FALSE';      
   ELSE
      temp_ := 'TRUE';
   END IF;
   RETURN temp_;
END Is_Withheld;


@UncheckedAccess
FUNCTION Check_Fee_Code (
   company_          IN VARCHAR2,
   fee_code_         IN VARCHAR2,
   date_             IN DATE      DEFAULT SYSDATE,
   check_deductible_ IN VARCHAR2  DEFAULT 'FALSE' ) RETURN BOOLEAN
IS
   dummy_      NUMBER;

   CURSOR get_fee_code IS
      SELECT 1
      FROM   STATUTORY_FEE_TAB
      WHERE  company      = company_
      AND    fee_code     = fee_code_
      AND    TRUNC(date_) BETWEEN valid_from AND valid_until
      AND    deductible   = 100;

   CURSOR get_fee_code_deduct IS
      SELECT 1
      FROM   STATUTORY_FEE_TAB
      WHERE  company      = company_
      AND    fee_code     = fee_code_
      AND    TRUNC(date_) BETWEEN valid_from AND valid_until;

BEGIN
   IF ( check_deductible_ = 'TRUE') THEN
      OPEN  get_fee_code_deduct;
      FETCH get_fee_code_deduct INTO dummy_;
      IF (get_fee_code_deduct%FOUND) THEN
         CLOSE get_fee_code_deduct;
         RETURN(TRUE);
      END IF;
      CLOSE get_fee_code_deduct;
      RETURN(FALSE);
   ELSE
      OPEN  get_fee_code;
      FETCH get_fee_code INTO dummy_;
      IF (get_fee_code%FOUND) THEN
         CLOSE get_fee_code;
         RETURN(TRUE);
      END IF;
      CLOSE get_fee_code;
      RETURN(FALSE);
   END IF;
END Check_Fee_Code;


@SecurityCheck Company.UserAuthorized(company_)
PROCEDURE Get_Tax_Code_Info (
   multiple_tax_   OUT VARCHAR2,
   fee_type_       OUT VARCHAR2,
   deductible_     OUT NUMBER,
   company_        IN  VARCHAR2,
   fee_code_       IN  VARCHAR2,
   date_           IN  DATE DEFAULT NULL )
IS
   
   CURSOR get_info IS
      SELECT multiple_tax, fee_type, deductible
      FROM   STATUTORY_FEE_TAB
      WHERE  company  = company_
      AND    fee_code = fee_code_
      AND    trunc(NVL(date_,SYSDATE)) BETWEEN valid_from AND valid_until;
BEGIN
   OPEN get_info;
   FETCH get_info INTO multiple_tax_, fee_type_, deductible_;
   IF (get_info%NOTFOUND) THEN
      CLOSE get_info;
      Error_SYS.record_general(lu_name_, 'NOFEETYPE: Invalid Tax Code :P1', fee_code_);
   ELSE
      CLOSE get_info;
   END IF;
END Get_Tax_Code_Info;

@SecurityCheck Company.UserAuthorized(company_)
PROCEDURE Get_Tax_Code_Info (
   fee_rate_         OUT NUMBER,
   fee_type_db_      OUT VARCHAR2,
   is_multiple_tax_  OUT VARCHAR2,
   company_          IN  VARCHAR2,
   fee_code_         IN  VARCHAR2,
   date_             IN  DATE DEFAULT NULL)
IS
   CURSOR get_tax_info IS
      SELECT fee_rate, fee_type, multiple_tax
      FROM   STATUTORY_FEE_TAB
      WHERE  company = company_
      AND    fee_code = fee_code_
      AND    trunc(NVL(date_,SYSDATE)) BETWEEN valid_from AND valid_until;
BEGIN
   OPEN  get_tax_info;
   FETCH get_tax_info INTO fee_rate_, fee_type_db_, is_multiple_tax_;
   CLOSE get_tax_info;
   IF ( fee_type_db_ = 'CALCVAT' ) THEN
      fee_rate_ := 0;
   END IF;
END Get_Tax_Code_Info;

@Override
@UncheckedAccess
@SecurityCheck Company.UserAuthorized(company_)
FUNCTION Get_Fee_Rate (
   company_ IN VARCHAR2,
   fee_code_ IN VARCHAR2 ) RETURN NUMBER
IS
   percent_       NUMBER;
BEGIN
   percent_ := super(company_, fee_code_);
      
   IF ( Get_Fee_Type_Db(company_,fee_code_) = 'CALCVAT' ) THEN
      RETURN 0;
   ELSE
      RETURN percent_;
   END IF;
END Get_Fee_Rate;


@SecurityCheck Company.UserAuthorized(company_)   
PROCEDURE Set_Multiple_Tax (
   company_  IN VARCHAR2,
   fee_code_ IN VARCHAR2,
   flag_     IN BOOLEAN)
IS
   attr_             VARCHAR2(2000);
   newrec_           STATUTORY_FEE_TAB%ROWTYPE;
   oldrec_           STATUTORY_FEE_TAB%ROWTYPE;
   dummy_rowid_      ROWID;
   dummy_rowversion_ VARCHAR2(200);
BEGIN
   oldrec_ := Lock_By_Keys___( company_, fee_code_);
   newrec_ := oldrec_;
   IF flag_ THEN
      newrec_.multiple_tax := 'TRUE';
   ELSE
      newrec_.multiple_tax := 'FALSE';
   END IF;
   Update___(dummy_rowid_,
             oldrec_,
             newrec_,
             attr_,
             dummy_rowversion_,
             TRUE);
END Set_Multiple_Tax;


-- Get_Order_Fee_Rate
--   This method is used in ORDER module to return the the fee rate of a given fee code.
--   Pls inform Distribution team, if any change has to be done to this method.
@UncheckedAccess
@SecurityCheck Company.UserAuthorized(company_)
FUNCTION Get_Order_Fee_Rate (
   company_  IN VARCHAR2,
   fee_code_ IN VARCHAR2 ) RETURN NUMBER
IS
   percent_  NUMBER;

   CURSOR getpercent IS
      SELECT fee_rate
      FROM   STATUTORY_FEE_TAB
      WHERE  company  = company_
      AND    fee_code = fee_code_;
BEGIN
   OPEN getpercent;
   FETCH getpercent INTO percent_;
   CLOSE getpercent;
   RETURN percent_;
END Get_Order_Fee_Rate;


@UncheckedAccess
FUNCTION Check_Attached (
   company_  IN VARCHAR2,
   fee_code_ IN VARCHAR2) RETURN VARCHAR2
IS
   result_   NUMBER;
   CURSOR chk_att IS
      SELECT   1
      FROM  statutory_fee_detail_tab
      WHERE company = company_
      AND   att_fee_code = fee_code_;
BEGIN
   OPEN chk_att;
   FETCH chk_att INTO result_;
   IF (chk_att%FOUND) THEN
      CLOSE chk_att;
      RETURN 'TRUE';
   ELSE
      CLOSE chk_att;
      RETURN 'FALSE';
   END IF;
END Check_Attached;


PROCEDURE Exist_Deduct (
   company_    IN VARCHAR2,
   fee_code_   IN VARCHAR2,
   valid_from_ IN DATE DEFAULT NULL )
IS
BEGIN
   IF (Check_Exist_Deductible___(company_, fee_code_, valid_from_)) THEN
      Error_SYS.Appl_General(lu_name_,'NOTVALID: Some part of Tax Code :P1 is non-deductible and therefore not valid to use.', fee_code_);
   END IF;
END Exist_Deduct;



PROCEDURE Check_Fee_Type_Not_Allowed (
   company_    IN VARCHAR2,
   fee_code_   IN VARCHAR2,
   date_       IN DATE DEFAULT SYSDATE )
IS
   fee_type_   VARCHAR2(20);
BEGIN
   Get_Fee_Type(fee_type_, company_, fee_code_, date_);
   IF (fee_type_ = 'RDE') THEN
      Error_SYS.Record_General(lu_name_, 'INVTYPERDE: Tax codes of type :P1 is not allowed.', fee_type_);
   END IF;
END Check_Fee_Type_Not_Allowed;

@Override
@UncheckedAccess
@SecurityCheckIfNotNull Company.UserAuthorized(company_)
FUNCTION Get_Fee_Type_Db (
   company_  IN     VARCHAR2,
   fee_code_ IN     VARCHAR2 ) RETURN statutory_fee_tab.fee_type%TYPE
IS
BEGIN
   --Add pre-processing code here
   RETURN super(company_, fee_code_);
END Get_Fee_Type_Db;





