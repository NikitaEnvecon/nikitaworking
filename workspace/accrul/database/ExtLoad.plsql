-----------------------------------------------------------------------------
--
--  Logical unit: ExtLoad
--  Component:    ACCRUL
--
--  IFS Developer Studio Template Version 3.0
--
--  Date    Sign    History
--  ------  ------  ---------------------------------------------------------
--  970128  MaGu   Created
--  970411  MaGu   Changed proc. Load_Transaction. Now checking for existence
--                 of company. Storing VARCHAR2 datatype fields after converting
--                 to uppercase.
--  970414  MaGu   Now copying all elements of record type into temp. var.
--  970807  SLKO   Converted to Foundation 1.2.2d
--  970905  JOBJ   Added columns [currency_] debet_Amount, credit_amount
--  981026  Bren   Third Currency - Load_Transaction
--  000124  Upul   External Transactions Wizard - Added procedure convert_attr_.
--  000912  HiMu   Added General_SYS.Init_Method
--  010219  Uma    Corrected Bug# 20010.
--  010220  Uma    Corrected Bug# 20006. 
--  010402  Uma    Bug# 20944 - Merge of wizard modifications.
--                 Added Start_Ext_Transaction__. Replaced Convert_Attri_ with Convert_Message_.  
--  010530  JeGu   Some Code cleanup
--  020219  Kaga   Bug# 27881 (Merged Code)
--  020312  rako   Corrected Bug# 27666.
--  020614  JeGu   Bug #30817 corrected
--  020712  ASHELK Bug 30897, Corrected. Added an error message in Convert_Message_.
--  020618  JeGu   Bug #31077. New procedure Start_Ext_Vouchers to use from External Files (api_to_call) 
--  020819  JeGu   Moved bug correction for 31077 to after 30897 (Harvest)
--  021011  PPerse Merged External Files
--  030805  prdilk SP4 Merge. 
--  040329  Gepelk 2004 SP1 Merge.
--  050825  Samwlk LCS Bug 52702, Merged.
--  050825  Samwlk LCS Bug 52742, Merged.
--  051024  Gadalk LCS Bug 52834, Merged.
--  051027  Gadalk B128186 - Date Convertion error through Message_SYS.
--  060126  Samwlk LCS Bug 54682, Merged.
--  060209  Samwlk LCS Bug 55422, Merged.
--  060310  Samwlk LCS Bug 55911, Merged.
--  060310  Samwlk LCS Bug 55726, Merged.
--  060919  Shsalk LCS Bug 57054, Merged. A condition has been changed in order to consider 0 as null.
--  061024  GaDaLK LCS Bug 59910, Merged.
--  061110  Samwlk LCS Merge 57830, Removed the validation done to remove the code part 
--  061110         values for blocked code parts, and it will be validated in the checking transations(ext_check).
--  070116  RUFELK FIPL637A - Considered the 'O' logical_account_type where the 'S' logical_account_type was used.
--  070207  Kagalk LCS Merge 62180, Added new if condition in Load_Transactions() to check tax_type_ not in 'CALCVAT'
--  070919  Makrlk LCS Merge 67430, change procedure Start_Ext_Vouchers 
--  071218  cldase Bug 68733, Corrected bug so that automatic tax calculation is possible 
--  080205  Jeguse Bug 67579, Corrected
--  080225  Jeguse Bug 71809 Corrected.
--  080522  NiFelk Bug 74121, Corrected in Start_Ext_Vouchers. 
--  080915  AjPelk Bug 71024 Corrected
--  091019  Nsillk Bug 84885 Corrected
--  090925  RUFELK Bug 86126 Corrected. Moved code segment inside Start_Ext_Vouchers() method.
--  091106  RUFELK Bug 86931 Corrected. Modified the Start_Ext_Vouchers() method.
--  100121  Jaralk Bug 88016 Removed the code which assigned the rec_.currency_code to tst_trans_currency_ and 
--                     assgined  null to  trans_currency_type_ in Start_Ext_Vouchers()
--  110630  Sacalk FIDEAGLE-308, Bug 97265 Merged. Changed Start_Ext_Vouchers() method.
--  110818  WAPELK FIDEAGLE-1334, Merged the bug id 98305.
--  111004  AJPELK EASTTWO-15655, Bug 98827 merged.
--  111115  NIRPLk SFI-699, Merged Bug 99679.
--  120627  THPELK Bug 97225, Corrected in Load_Transaction().
--  120709  Raablk Bug 102620, Modified PROCEDURE Start_Ext_Vouchers().
--  120821  Sacalk EDEL-1403, Added Columns to support Automation of Add investment in FA 
--  120827  Sacalk EDEL-1360, Modified in Start_Ext_Vouchers. 
--  121123  Janblk DANU-122, Parallel currency implementation  
--  130610  NILILK DANU 1311, Parallel currency implementation
--  140304  MAWELK PBFI-4118(Lcs Bug Id 113927) fixed.
--  140409  Nirylk PBFI-5614, Modified Load_Transaction() and Start_Ext_Vouchers()
--  140929  Mawelk PRFI-2736 (Lcs Bug Id 118899), Modify Start_Ext_Vouchers()
--  141217  DipeLK PRFI-4042,Tax Base is NULL on the Tax Posting of a voucher created through external file
--  150128  AjPelk PRFI-4489, Lcs merge Bug 120401, Added new field CURRENCY_RATE_TYPE 
--  150216  AjPelk PRFI-5486, Lcs merge bug 120793
-----------------------------------------------------------------------------

layer Core;

-------------------- PUBLIC DECLARATIONS ------------------------------------


-------------------- PRIVATE DECLARATIONS -----------------------------------


-------------------- LU SPECIFIC IMPLEMENTATION METHODS ---------------------
  
-------------------- LU SPECIFIC PRIVATE METHODS ----------------------------

-------------------- LU SPECIFIC PROTECTED METHODS --------------------------

-------------------- LU SPECIFIC PUBLIC METHODS -----------------------------

PROCEDURE Load_Transaction (
   company_         IN VARCHAR2,
   load_id_         IN OUT VARCHAR2,
   voucher_type_    IN VARCHAR2,
   load_date_       IN DATE,
   user_id_         IN VARCHAR2,
   transaction_rec_ IN Ext_Transactions_API.ExtTransRec,
   checked_         IN VARCHAR2 DEFAULT 'FALSE',
   load_type_       IN VARCHAR2 DEFAULT NULL,
   load_file_id_    IN NUMBER   DEFAULT NULL )
IS
   t_transaction_rec_ Ext_Transactions_API.ExtTransRec;
   t_company_         VARCHAR2(20);
   t_load_id_         VARCHAR2(20);
   t_voucher_type_    VARCHAR2(3);
   t_user_id_         VARCHAR2(30);
   dummy_             VARCHAR2(10);
   req_rec_           Accounting_Codestr_API.CodestrRec;
   load_typex_                 VARCHAR2(20);
   tax_type_                   VARCHAR2(100);
   logical_account_type_db_    VARCHAR2(10);
   fee_percent_                NUMBER;
   currency_rounding_          NUMBER;
   rounding_                   NUMBER;
   auto_tax_calc_              VARCHAR2(1);
   def_amount_method_          VARCHAR2(5) := Company_Finance_API.Get_Def_Amount_Method_Db (company_);
   -- Bug 97225, Begin
   multiple_tax_               Statutory_Fee_Tab.multiple_tax%TYPE;
   deductible_percent_         Statutory_Fee_Tab.deductible%TYPE; 
   total_tax_amount_           NUMBER;
   function_group_             VOUCHER_TYPE_DETAIL_TAB.function_group%TYPE;
   check_deductible_           VARCHAR2(5):= 'FALSE';
   -- Bug 97225, End

   third_currency_round_       NUMBER;
BEGIN
   IF (load_type_ IS NOT NULL) THEN
      load_typex_ := load_type_;
   ELSE
      load_typex_ := voucher_type_;
   END IF;
   auto_tax_calc_                           := Ext_Parameters_API.Get_Auto_Tax_Calc_Db(company_,load_typex_);
   t_company_                               := UPPER(company_);
   t_load_id_                               := UPPER(load_id_);
   t_voucher_type_                          := UPPER(voucher_type_);
   t_user_id_                               := UPPER(user_id_);
   -- converting to uppercase and copying
   t_transaction_rec_.load_file_id          := transaction_rec_.load_file_id;
   t_transaction_rec_.row_no                := transaction_rec_.row_no;
   t_transaction_rec_.company               := UPPER(transaction_rec_.company);
   t_transaction_rec_.load_id               := UPPER(transaction_rec_.load_id);
   t_transaction_rec_.user_id               := t_user_id_;
   t_transaction_rec_.load_group_item       := UPPER(transaction_rec_.load_group_item);
   t_transaction_rec_.transaction_date      := transaction_rec_.transaction_date;
   t_transaction_rec_.voucher_type          := UPPER(transaction_rec_.voucher_type);
   t_transaction_rec_.voucher_no            := transaction_rec_.voucher_no;
   t_transaction_rec_.accounting_year       := transaction_rec_.accounting_year;
   t_transaction_rec_.codestring_rec.code_a := UPPER(transaction_rec_.codestring_rec.code_a);
   t_transaction_rec_.codestring_rec.code_b := UPPER(transaction_rec_.codestring_rec.code_b);
   t_transaction_rec_.codestring_rec.code_c := UPPER(transaction_rec_.codestring_rec.code_c);
   t_transaction_rec_.codestring_rec.code_d := UPPER(transaction_rec_.codestring_rec.code_d);
   t_transaction_rec_.codestring_rec.code_e := UPPER(transaction_rec_.codestring_rec.code_e);
   t_transaction_rec_.codestring_rec.code_f := UPPER(transaction_rec_.codestring_rec.code_f);
   t_transaction_rec_.codestring_rec.code_g := UPPER(transaction_rec_.codestring_rec.code_g);
   t_transaction_rec_.codestring_rec.code_h := UPPER(transaction_rec_.codestring_rec.code_h);
   t_transaction_rec_.codestring_rec.code_i := UPPER(transaction_rec_.codestring_rec.code_i);
   t_transaction_rec_.codestring_rec.code_j := UPPER(transaction_rec_.codestring_rec.code_j);
   t_transaction_rec_.quantity              := transaction_rec_.quantity;
   t_transaction_rec_.process_code          := UPPER(transaction_rec_.process_code);
   t_transaction_rec_.transaction_reason    := UPPER(transaction_rec_.transaction_reason);
   t_transaction_rec_.event_date            := transaction_rec_.event_date;
   t_transaction_rec_.retroactive_date      := transaction_rec_.retroactive_date;

   IF (t_transaction_rec_.codestring_rec.code_a IS NOT NULL) THEN
      Account_API.Get_Required_Code_Part (req_rec_,
                                          company_,
                                          t_transaction_rec_.codestring_rec.code_a);
      
      IF (t_transaction_rec_.quantity IS NOT NULL) AND
         (Account_API.Get_Code_Part_Demand (company_,
                                            t_transaction_rec_.codestring_rec.code_a,
                                            'QUANTITY') = 'S' )THEN
         t_transaction_rec_.quantity     := NULL;
      END IF;
      IF (t_transaction_rec_.process_code IS NOT NULL) AND
         (Account_API.Get_Code_Part_Demand (company_,
                                            t_transaction_rec_.codestring_rec.code_a,
                                            'PROCESS_CODE') = 'S' )THEN
         t_transaction_rec_.process_code := NULL;
      END IF;
   END IF;                                                       
   t_transaction_rec_.correction                   := transaction_rec_.correction;
   t_transaction_rec_.currency_amount              := transaction_rec_.currency_amount;
   t_transaction_rec_.amount                       := transaction_rec_.amount;
   t_transaction_rec_.currency_debet_amount        := transaction_rec_.currency_debet_amount;
   t_transaction_rec_.currency_credit_amount       := transaction_rec_.currency_credit_amount;
   t_transaction_rec_.debet_amount                 := transaction_rec_.debet_amount;
   t_transaction_rec_.credit_amount                := transaction_rec_.credit_amount;
   t_transaction_rec_.currency_code                := UPPER(transaction_rec_.currency_code);
   t_transaction_rec_.quantity                     := transaction_rec_.quantity;
   t_transaction_rec_.process_code                 := UPPER(transaction_rec_.process_code);
   t_transaction_rec_.optional_code                := UPPER(transaction_rec_.optional_code);
   t_transaction_rec_.project_activity_id          := transaction_rec_.project_activity_id;
   t_transaction_rec_.text                         := transaction_rec_.text;
   t_transaction_rec_.party_type_id                := UPPER(transaction_rec_.party_type_id);
   t_transaction_rec_.reference_number             := UPPER(transaction_rec_.reference_number);
   t_transaction_rec_.reference_serie              := UPPER(transaction_rec_.reference_serie);
   t_transaction_rec_.trans_code                   := UPPER(transaction_rec_.trans_code);
   t_transaction_rec_.third_currency_debit_amount  := transaction_rec_.third_currency_debit_amount;
   t_transaction_rec_.third_currency_credit_amount := transaction_rec_.third_currency_credit_amount;
   t_transaction_rec_.ext_vouch_date               := transaction_rec_.ext_vouch_date;
   t_transaction_rec_.ext_group_item               := transaction_rec_.ext_group_item;
   t_transaction_rec_.load_date                    := load_date_;
   t_transaction_rec_.currency_rate                := transaction_rec_.currency_rate;
   t_transaction_rec_.user_group                   := transaction_rec_.user_group; 
   t_transaction_rec_.third_currency_amount        := transaction_rec_.third_currency_amount;
   t_transaction_rec_.third_currency_tax_amount    := transaction_rec_.third_currency_tax_amount;
   t_transaction_rec_.deliv_type_id                := transaction_rec_.deliv_type_id;
   IF (t_transaction_rec_.load_type IS NULL) THEN
      t_transaction_rec_.load_type                 := load_typex_;
   END IF;
   IF (checked_ = 'FALSE') THEN
      -- checking for existence of company
      Company_Finance_API.Exist( t_company_ );
      -- checking for existence of rec.
      Ext_Parameters_API.Exist (t_company_, load_typex_);
   END IF;
   t_transaction_rec_.tax_amount := transaction_rec_.tax_amount;
   t_transaction_rec_.currency_tax_amount := transaction_rec_.currency_tax_amount;

   IF (t_transaction_rec_.amount IS NULL AND
       t_transaction_rec_.debet_amount IS NOT NULL) THEN
      t_transaction_rec_.amount := t_transaction_rec_.debet_amount;
   END IF; 
   IF (t_transaction_rec_.amount IS NULL AND
       t_transaction_rec_.credit_amount IS NOT NULL) THEN
      t_transaction_rec_.amount := t_transaction_rec_.credit_amount * -1;
   END IF; 
   IF (t_transaction_rec_.currency_amount IS NULL AND
       t_transaction_rec_.currency_debet_amount IS NOT NULL) THEN
      t_transaction_rec_.currency_amount := t_transaction_rec_.currency_debet_amount;
   END IF; 
   IF (t_transaction_rec_.currency_amount IS NULL AND
       t_transaction_rec_.currency_credit_amount IS NOT NULL) THEN
      t_transaction_rec_.currency_amount := t_transaction_rec_.currency_credit_amount * -1;
   END IF;
   IF (t_transaction_rec_.third_currency_amount IS NULL AND
       t_transaction_rec_.third_currency_debit_amount IS NOT NULL) THEN
      t_transaction_rec_.third_currency_amount := t_transaction_rec_.third_currency_debit_amount;
   END IF;
   IF (t_transaction_rec_.third_currency_amount IS NULL AND
       t_transaction_rec_.third_currency_credit_amount IS NOT NULL) THEN
      t_transaction_rec_.third_currency_amount := t_transaction_rec_.third_currency_credit_amount * -1;
   END IF;

   -- Bug 97225, Begin
   function_group_ := Voucher_Type_Detail_API.Get_Function_Group(t_transaction_rec_.company, t_transaction_rec_.voucher_type);
   IF (function_group_ IN ('M', 'K','Q')) THEN
        check_deductible_ := 'TRUE';
   END IF;
   -- Bug 97225, End


   -- tax calculations begin
   -- Note : Just to inform the same auto tax calculation have been implemented in 
   -- Ext_Transactions_API.Auto_Tax_Calculation_Done() under bug 92374 , so pls do not forget to 
   -- modify it whenever this changes.
   IF (auto_tax_calc_ = 'Y') THEN
      IF (t_transaction_rec_.optional_code IS NULL) THEN
         -- Bug 97225, Begin
         Account_Tax_Code_API.Get_Default_Tax_Code (t_transaction_rec_.optional_code,
                                                    t_transaction_rec_.tax_direction,
                                                    t_transaction_rec_.company,
                                                    t_transaction_rec_.codestring_rec.code_a,
                                                    check_deductible_ => check_deductible_);
         -- Bug 97225, End
      END IF;
      IF (t_transaction_rec_.optional_code IS NOT NULL) THEN
         -- Bug 97225, Begin
         Statutory_Fee_API.Get_Tax_Code_Info(multiple_tax_, tax_type_, deductible_percent_,t_transaction_rec_.company, t_transaction_rec_.optional_code);
         IF ( function_group_ IN ('M', 'K','Q') AND tax_type_ = 'VAT')THEN
            -- to avoid deductible tax calculations
            check_deductible_ := 'TRUE';
         ELSE
            check_deductible_ := 'FALSE';
         END IF;
         -- Bug 97225, End

         IF (t_transaction_rec_.optional_code IS NOT NULL AND
             t_transaction_rec_.tax_amount IS NULL AND
             t_transaction_rec_.currency_tax_amount IS NULL AND
             t_transaction_rec_.third_currency_tax_amount IS NULL) THEN
            t_transaction_rec_.tax_direction := Tax_Direction_API.Encode(t_transaction_rec_.tax_direction);

            fee_percent_ := Statutory_Fee_API.Get_Calculated_Percent(t_transaction_rec_.company,
                                                                     tax_type_,
                                                                     t_transaction_rec_.optional_code,
                                                                     load_date_);
            IF (NVL(fee_percent_,0) != 0) THEN
               fee_percent_ := fee_percent_ / 100;
               -- Bug 97225, Begin
               deductible_percent_ := deductible_percent_/100;
               -- Bug 97225, End
               currency_rounding_ := Currency_Code_API.Get_Currency_Rounding(t_transaction_rec_.company,
                                                                             t_transaction_rec_.currency_code);
               rounding_ := Currency_Code_API.Get_Currency_Rounding(t_transaction_rec_.company,
                                                                    Currency_Code_API.Get_Currency_Code(t_transaction_rec_.company));
               -- Bug 97225, Begin
               third_currency_round_ := Currency_Code_API.Get_Currency_Rounding(t_transaction_rec_.company, Currency_Code_API.Get_Parallel_Acc_Currency (t_transaction_rec_.company));
               IF (tax_type_ NOT IN ('CALCVAT')) THEN
                  IF (def_amount_method_ = 'GROSS') THEN
                     total_tax_amount_                      := t_transaction_rec_.currency_amount * fee_percent_ / ( 1 + fee_percent_ );
                     IF (deductible_percent_ != 1 AND check_deductible_ = 'TRUE')  THEN
                        t_transaction_rec_.currency_tax_amount := ROUND(total_tax_amount_* deductible_percent_, currency_rounding_);
                     ELSE
                        t_transaction_rec_.currency_tax_amount := ROUND(total_tax_amount_, currency_rounding_);
                     END IF;
                     
                     total_tax_amount_                      := t_transaction_rec_.amount * fee_percent_ / ( 1 + fee_percent_ );
                     IF (deductible_percent_ != 1 AND check_deductible_ = 'TRUE')  THEN
                        t_transaction_rec_.tax_amount          := ROUND(total_tax_amount_ * deductible_percent_, rounding_);
                     ELSE
                        t_transaction_rec_.tax_amount          := ROUND(total_tax_amount_, rounding_);
                     END IF;

                     t_transaction_rec_.third_currency_tax_amount := ROUND((t_transaction_rec_.third_currency_amount * fee_percent_ / ( 1 + fee_percent_ )), third_currency_round_);
                  ELSE
                     total_tax_amount_                      := t_transaction_rec_.currency_amount * fee_percent_;
                     IF (deductible_percent_ != 1 AND check_deductible_ = 'TRUE')  THEN
                        t_transaction_rec_.currency_tax_amount := ROUND(total_tax_amount_ * deductible_percent_, currency_rounding_);
                        t_transaction_rec_.currency_amount     := ROUND(t_transaction_rec_.currency_amount + (total_tax_amount_ - t_transaction_rec_.currency_tax_amount), currency_rounding_);
                        -- set currecy credit/debit amounts
                        IF (t_transaction_rec_.currency_debet_amount IS NOT NULL) THEN
                           t_transaction_rec_.currency_debet_amount  := t_transaction_rec_.currency_amount;
                        ELSIF (t_transaction_rec_.currency_credit_amount IS NOT NULL) THEN
                           t_transaction_rec_.currency_credit_amount  := t_transaction_rec_.currency_amount*-1;
                        END IF;
                     ELSE
                        t_transaction_rec_.currency_tax_amount := ROUND(total_tax_amount_, currency_rounding_);
                     END IF;

                     total_tax_amount_                      := t_transaction_rec_.amount * fee_percent_;
                     IF (deductible_percent_ != 1 AND check_deductible_ = 'TRUE')  THEN
                        t_transaction_rec_.tax_amount          := ROUND(total_tax_amount_ * deductible_percent_, rounding_);
                        t_transaction_rec_.amount              := ROUND(t_transaction_rec_.amount + (total_tax_amount_ - t_transaction_rec_.tax_amount), rounding_);
                        -- set currecy credit/debit amounts
                        IF (t_transaction_rec_.debet_amount IS NOT NULL) THEN
                            t_transaction_rec_.debet_amount  := t_transaction_rec_.amount;
                        ELSIF (t_transaction_rec_.credit_amount IS NOT NULL) THEN
                            t_transaction_rec_.credit_amount  := t_transaction_rec_.amount*-1;
                        END IF;
                     ELSE
                        t_transaction_rec_.tax_amount          := ROUND(total_tax_amount_, rounding_);
                     END IF;
                     t_transaction_rec_.third_currency_tax_amount := ROUND((t_transaction_rec_.third_currency_amount * fee_percent_), third_currency_round_);
                  END IF;
               ELSE 
                  t_transaction_rec_.currency_tax_amount := ROUND((t_transaction_rec_.currency_amount * fee_percent_), currency_rounding_);
                  t_transaction_rec_.tax_amount          := ROUND((t_transaction_rec_.amount * fee_percent_), rounding_);
                  t_transaction_rec_.third_currency_tax_amount          := ROUND((t_transaction_rec_.third_currency_amount * fee_percent_), third_currency_round_);
               END IF;
               -- Bug 97225, End
            ELSIF (fee_percent_ = 0) THEN
               t_transaction_rec_.currency_tax_amount := 0;
               t_transaction_rec_.tax_amount          := 0;
               t_transaction_rec_.third_currency_tax_amount          := 0;
            END IF;
         END IF;
      END IF;
   END IF;
   -- tax calculations end
   -- Bug 97225, Begin
   IF  t_transaction_rec_.optional_code  IS NOT NULL AND t_transaction_rec_.codestring_rec.code_a IS NOT NULL AND Statutory_Fee_API.Check_Fee_Code(t_transaction_rec_.company,t_transaction_rec_.optional_code, check_deductible_=> check_deductible_) THEN
       -- Tax Direction
       Statutory_Fee_API.Get_Fee_Type(tax_type_,  t_transaction_rec_.company  ,  t_transaction_rec_.optional_code);
       IF (tax_type_ IN ('NOTAX')) THEN
          t_transaction_rec_.tax_direction := tax_type_;
       ELSE
          IF transaction_rec_.tax_direction IS NOT NULL THEN
             t_transaction_rec_.tax_direction := Tax_Direction_API.Encode(transaction_rec_.tax_direction);
          ELSE
             logical_account_type_db_ := Account_API.Get_Logical_Account_Type_Db(t_transaction_rec_.company, t_transaction_rec_.codestring_rec.code_a);
             IF (logical_account_type_db_ IN ('A', 'C')) THEN
             -- Assign 'Tax Received'
                t_transaction_rec_.tax_direction := Tax_Direction_API.Get_Db_Value(0);
             ELSIF (logical_account_type_db_ IN ('L', 'R', 'S', 'O')) THEN
             -- Assign 'Tax Disbursed'
                t_transaction_rec_.tax_direction := Tax_Direction_API.Get_Db_Value(1);
             END IF;
          END IF;
       END IF;
   END IF;
   -- Bug 97225, End
   t_transaction_rec_.currency_rate_type         := transaction_rec_.currency_rate_type;
   t_transaction_rec_.parallel_curr_rate_type    := transaction_rec_.parallel_curr_rate_type;
   
   IF (load_id_ IS NULL) THEN
      Ext_Load_ID_Storage_API.Get_Next_Load_Id(load_id_, company_);
      -- Removes old records with same load_id wich should not be there (caused by an error while loading)
      DELETE
      FROM   ext_load_info_tab
      WHERE  company = company_
      AND    load_id = load_id_;
      DELETE
      FROM   ext_transactions_tab
      WHERE  company = company_
      AND    load_id = load_id_;
   END IF;
   t_load_id_   := UPPER(load_id_);
   Ext_Load_Info_API.Exist ( dummy_,
                             t_company_,
                             t_load_id_ );
   IF (dummy_ = 'FALSE') THEN
      Ext_Load_Info_API.New_Load_Info ( t_company_,
                                        t_load_id_,
                                        t_voucher_type_,
                                        load_date_,
                                        t_user_id_,
                                        load_type_,
                                        load_file_id_ );
   END IF;


   Ext_Transactions_API.New_Transaction (t_company_,
                                         t_load_id_,
                                         t_transaction_rec_);
END Load_Transaction;


PROCEDURE Start_Ext_Vouchers (
   info_             IN OUT VARCHAR2,
   load_file_id_     IN     NUMBER,
   parameter_string_ IN     VARCHAR2 DEFAULT NULL )
IS
   ext_file_load_rec_    Ext_File_Load_API.Public_Rec;
   rec_                  Ext_transactions_Api.ExtTransRec;
   user_id_              VARCHAR2(20);
   loaded_               BOOLEAN        := FALSE;
   load_date_            DATE;
   load_group_item_      VARCHAR2(30);
   ext_group_by_item_    VARCHAR2(1);
   ext_vouch_extern_     VARCHAR2(1);
   voucher_no_           NUMBER;
   line_no_              NUMBER := 0;
   mode_                 VARCHAR2(10);
   ext_vouch_date_       VARCHAR2(1);
   company_              VARCHAR2(20);
   voucher_type_         VARCHAR2(20)   := '???';
   load_type_            VARCHAR2(20)   := '???';
   load_state_           VARCHAR2(200);
   load_id_              VARCHAR2(20);
   old_load_id_          VARCHAR2(20);
   checked_              VARCHAR2(5)    := 'FALSE';
   parameter_attr_       VARCHAR2(2000);
   err_msg_              VARCHAR2(2000);
   check_when_loaded_    VARCHAR2(5)    := 'FALSE';
   create_when_checked_  VARCHAR2(5)    := 'FALSE';
   check_when_loadedx_   VARCHAR2(5)    := 'FALSE';
   create_when_checkedx_ VARCHAR2(5)    := 'FALSE';
   ext_load_state_       VARCHAR2(2);
   base_currency_        VARCHAR2(3);   
   company_load_id_      VARCHAR2(32000);
   third_currency_code_  VARCHAR2(3);
   base_currency_round_  NUMBER;
   trans_currency_round_ NUMBER;
   third_currency_round_ NUMBER;
   translate_            VARCHAR2(2000); 
   base_curr_inverted_   VARCHAR2(5);   
   tst_company_          VARCHAR2(20)   := '??';
   tst_trans_currency_   VARCHAR2(3)    := '??';
   tst_curr_date_        DATE           := TRUNC(SYSDATE);
   act_curr_date_        DATE;
   trans_currency_type_  VARCHAR2(20); 
   trans_conv_factor_    NUMBER;
   trans_curr_rate_      NUMBER;
   --
   main_correction_      ext_parameters_tab.correction%TYPE;

   curr_type_                 Currency_Type_Tab.currency_type%TYPE;
   conv_factor_               Currency_Rate_Tab.currency_rate%TYPE;
   curr_rate_                 Currency_Rate_Tab.conv_factor%TYPE := NULL;
   inverted_                  Currency_Code_Tab.inverted%TYPE;
   user_group_                user_group_member_finance_tab.user_group%TYPE;
   is_base_emu_               VARCHAR2(6);
   is_third_emu_              VARCHAR2(6);
  
   CURSOR getextparam IS
      SELECT voucher_type,
             ext_voucher_no_alloc,
             ext_group_item,
             ext_voucher_date,
             check_when_loaded,
             create_when_checked,
             correction
      FROM   Ext_Parameters_Tab
      WHERE  company   = company_
      AND    load_type = load_type_;
   CURSOR get_ext_file_trans IS
      SELECT *
      FROM   Ext_File_Trans_Tab
      WHERE  load_file_id = load_file_id_
      AND    row_state = 2
      ORDER BY row_no;
   CURSOR get_load_id IS
      SELECT company,
             load_id
      FROM   Ext_Load_Info_Tab
      WHERE  load_file_id = load_file_id_;
   --
   -- This procedure is used for columns that should'nt have value '-'
   PROCEDURE CcolToRec (
      rec_col_   IN OUT VARCHAR2,
      trans_col_ IN     VARCHAR2 )
   IS
   BEGIN
      IF (trans_col_ = '-') THEN
         rec_col_ := NULL;
      ELSE
         rec_col_ := trans_col_;
      END IF;
   END CcolToRec;
   --
   BEGIN
   ext_file_load_rec_ := Ext_File_Load_API.Get (load_file_id_);
   Message_SYS.Get_Attribute (ext_file_load_rec_.parameter_string, 'USER_GROUP', user_group_);
   company_           := ext_file_load_rec_.company;
   base_currency_     := Company_Finance_API.Get_Currency_Code (company_);
   third_currency_code_  := Currency_Code_API.Get_Parallel_Acc_Currency (company_);
   is_base_emu_          := Currency_Code_API.Get_Valid_Emu (company_,
                                                             base_currency_,
                                                             tst_curr_date_);
   is_third_emu_         := Currency_Code_API.Get_Valid_Emu (company_,
                                                             third_currency_code_,
                                                             tst_curr_date_); 
   IF (parameter_string_ IS NOT NULL) THEN
      parameter_attr_ := parameter_string_;
   ELSE
      parameter_attr_ := ext_file_load_rec_.parameter_string;
   END IF;
   IF (parameter_attr_ IS NOT NULL) THEN
      Message_SYS.Get_Attribute (parameter_attr_, 'LOAD_TYPE', load_type_);
      load_date_ := ext_file_load_rec_.load_date;
      BEGIN
         Message_SYS.Get_Attribute (parameter_attr_, 'CHECK_WHEN_LOADED', check_when_loadedx_);
      EXCEPTION
         WHEN OTHERS THEN
            check_when_loadedx_ := NULL;
      END;
      BEGIN
         Message_SYS.Get_Attribute (parameter_attr_, 'CREATE_WHEN_CHECKED', create_when_checkedx_);
      EXCEPTION
         WHEN OTHERS THEN
            create_when_checkedx_ := NULL;
      END;
   ELSE
      Error_SYS.Record_General( lu_name_, 'EXTPAREMPTY: External parameter string is empty');
   END IF;
   Company_Finance_API.Exist ( company_ );
   IF (NVL(load_type_,'???') = '???') THEN
      load_type_ := Ext_Parameters_API.Get_Def_Load_Type ( company_ );
   END IF;
   OPEN  getextparam;
   FETCH getextparam INTO voucher_type_,
                          ext_vouch_extern_,
                          ext_group_by_item_,
                          ext_vouch_date_,
                          check_when_loaded_,
                          create_when_checked_,
                          rec_.correction;
   IF (getextparam%NOTFOUND) THEN
      Error_SYS.Record_General( 'EXT_LOAD_API', 'EXTPARNOTEXIST: External interface parameters does not exist for company :P1, load type :P2', company_, load_type_ );
   END IF;
   CLOSE getextparam;
   IF (check_when_loadedx_ IS NOT NULL) THEN
      check_when_loaded_   := check_when_loadedx_;
   END IF;
   IF (create_when_checkedx_ IS NOT NULL) THEN
      create_when_checked_ := create_when_checkedx_;
   END IF;
   checked_                := 'TRUE';
   user_id_                := Fnd_Session_API.Get_Fnd_User;
   IF (Ext_File_Load_API.Get_State_Db ( load_file_id_ ) != '3' ) THEN
      load_state_ := Ext_File_Load_API.Get_State ( load_file_id_ );
      Error_SYS.Record_General( lu_name_, 'EXTLOADNOTUNP: Load File Id :P1 has wrong state :P2', load_file_id_, load_state_ );
   END IF;
   --
   
   FOR trans_rec_ IN get_ext_file_trans LOOP
      rec_.load_file_id                   := load_file_id_;
      rec_.row_no                         := trans_rec_.row_no;
      rec_.company                        := NVL(trans_rec_.c70,company_); 
      old_load_id_  := Ext_Load_Info_API.Get_Loadable_Load_Id (rec_.company, load_file_id_);
      IF (old_load_id_ IS NOT NULL) THEN
         load_id_ := old_load_id_;
      ELSE
         Ext_Load_ID_Storage_API.Get_Next_Load_Id(load_id_,
                                               rec_.company);
         IF (company_load_id_ IS NULL) THEN
            company_load_id_ := rec_.company || '/' || load_id_;
         ELSE
            company_load_id_ := company_load_id_ || ',' || rec_.company || '/' || load_id_;
         END IF;
      END IF;
      
      rec_.user_group := user_group_;
      -- Use CcolToRec for all 'c'-volumns that shouldn't have value '-'
      CcolToRec (rec_.codestring_rec.code_a, trans_rec_.c1);
      CcolToRec (rec_.codestring_rec.code_b, trans_rec_.c2);
      CcolToRec (rec_.codestring_rec.code_c, trans_rec_.c3);
      CcolToRec (rec_.codestring_rec.code_d, trans_rec_.c4);
      CcolToRec (rec_.codestring_rec.code_e, trans_rec_.c5);
      CcolToRec (rec_.codestring_rec.code_f, trans_rec_.c6);
      CcolToRec (rec_.codestring_rec.code_g, trans_rec_.c7);
      CcolToRec (rec_.codestring_rec.code_h, trans_rec_.c8);
      CcolToRec (rec_.codestring_rec.code_i, trans_rec_.c9);
      CcolToRec (rec_.codestring_rec.code_j, trans_rec_.c10);
      CcolToRec (rec_.currency_code,         trans_rec_.c11);
      CcolToRec (rec_.process_code,          trans_rec_.c12);
      CcolToRec (rec_.optional_code,         trans_rec_.c13);
      CcolToRec (rec_.text,                  trans_rec_.c14);
      CcolToRec (rec_.party_type_id,         trans_rec_.c15);
      CcolToRec (rec_.reference_number,      trans_rec_.c16);
      CcolToRec (rec_.reference_serie,       trans_rec_.c17);
      CcolToRec (rec_.trans_code,            trans_rec_.c18);
      CcolToRec (load_group_item_,           trans_rec_.c19);
      CcolToRec (rec_.voucher_type,          trans_rec_.c20);
      CcolToRec (rec_.tax_direction,         trans_rec_.c21);
      CcolToRec (rec_.transaction_reason,    trans_rec_.c24);
      CcolToRec (rec_.deliv_type_id,         trans_rec_.c71);
      CcolToRec (rec_.currency_rate_type,    trans_rec_.c72);
      CcolToRec (rec_.parallel_curr_rate_type,    trans_rec_.c73);
     
      IF (tst_company_ != rec_.company) THEN
         tst_company_          := rec_.company;
         base_currency_        := Company_Finance_API.Get_Currency_Code (tst_company_);
         base_currency_round_  := Currency_Code_API.Get_Currency_Rounding (tst_company_, base_currency_);
         base_curr_inverted_   := Currency_Code_API.Get_Inverted (tst_company_, base_currency_);
         third_currency_code_  := Currency_Code_API.Get_Parallel_Acc_Currency (tst_company_);
         IF (third_currency_code_ IS NOT NULL) THEN
            third_currency_round_ := Currency_Code_API.Get_Currency_Rounding(tst_company_, third_currency_code_);
         END IF;
      END IF;
      IF (rec_.currency_code IS NULL) THEN
         rec_.currency_code := base_currency_;
      END IF;
      IF (ext_vouch_date_ = '2') THEN
         act_curr_date_     := trans_rec_.d1;
         IF (act_curr_date_ IS NULL) THEN
            act_curr_date_  := load_date_;
         END IF;
      ELSE
         act_curr_date_     := load_date_;
      END IF;

      IF (tst_trans_currency_ != rec_.currency_code OR act_curr_date_ != tst_curr_date_) THEN

          trans_currency_type_  := ''; 
          tst_curr_date_        := act_curr_date_;
          trans_currency_round_ := Currency_Code_Api.Get_Currency_Rounding(tst_company_, rec_.currency_code);
         
          Currency_Rate_API.Get_Currency_Rate_Defaults (trans_currency_type_,
                                                        trans_conv_factor_,
                                                        trans_curr_rate_,
                                                        rec_.company,
                                                        rec_.currency_code,
                                                        tst_curr_date_); 
       END IF;     
      /*
      base_currency_round_ := Currency_Code_Api.Get_Currency_Rounding(rec_.company, base_currency_);
      IF ( rec_.currency_code = base_currency_ ) THEN
         trans_currency_round_ := base_currency_round_;
      ELSE
         trans_currency_round_ := Currency_Code_Api.Get_Currency_Rounding(rec_.company, rec_.currency_code);
      END IF;
      third_currency_code_ := Currency_Code_Api.Get_Parallel_Acc_Currency(rec_.company);
      IF third_currency_code_ IS NOT NULL THEN
         IF ( third_currency_code_ = base_currency_ ) THEN
            third_currency_round_ := base_currency_round_;
         ELSIF ( third_currency_code_ = rec_.currency_code ) THEN
            third_currency_round_ := trans_currency_round_;
         ELSE
            third_currency_round_ := Currency_Code_Api.Get_Currency_Rounding(rec_.company,third_currency_code_);
         END IF;
      END IF;
      */

      voucher_no_                         := trans_rec_.n1;
      rec_.accounting_year                := trans_rec_.n2;
      rec_.currency_debet_amount          := ROUND(trans_rec_.n3,trans_currency_round_);
      rec_.currency_credit_amount         := ROUND(trans_rec_.n4,trans_currency_round_);
      rec_.currency_amount                := ROUND(trans_rec_.n5,trans_currency_round_);
      rec_.debet_amount                   := ROUND(trans_rec_.n6,base_currency_round_);
      rec_.credit_amount                  := ROUND(trans_rec_.n7,base_currency_round_);
      rec_.amount                         := ROUND(trans_rec_.n8,base_currency_round_);
      rec_.project_activity_id            := trans_rec_.n14;
      rec_.event_date                     := trans_rec_.d2;
      IF ( trans_rec_.d3 IS NULL ) THEN 
         rec_.retroactive_date            := rec_.event_date;
      ELSE            
         rec_.retroactive_date            := trans_rec_.d3;
      END IF;

      rec_.third_currency_debit_amount    := ROUND(trans_rec_.n10,third_currency_round_);
      rec_.third_currency_credit_amount   := ROUND(trans_rec_.n11,third_currency_round_);     
      rec_.third_currency_amount          := ROUND(trans_rec_.n15,third_currency_round_);
      rec_.third_currency_tax_amount      := ROUND(trans_rec_.n16,third_currency_round_);

      IF (NVL(trans_rec_.c22,'+') = '-') THEN
         IF (rec_.amount IS NOT NULL) THEN
            rec_.amount                   := rec_.amount * -1;
         END IF;
         IF (rec_.currency_amount IS NOT NULL) THEN
            rec_.currency_amount          := rec_.currency_amount * -1;
         END IF;
         IF (rec_.tax_amount IS NOT NULL) THEN
            rec_.tax_amount               := rec_.tax_amount * -1;
         END IF;
         IF (rec_.currency_tax_amount IS NOT NULL) THEN
            rec_.currency_tax_amount      := rec_.currency_tax_amount * -1;
         END IF;
      END IF;
      IF (NVL(trans_rec_.c23,'+') = '-') THEN
         IF (rec_.quantity IS NOT NULL) THEN
            rec_.quantity                 := rec_.quantity * -1;
         END IF;
         IF (rec_.amount IS NOT NULL) THEN
            rec_.amount                   := rec_.amount * -1;
         END IF;
         IF (rec_.currency_amount IS NOT NULL) THEN
            rec_.currency_amount          := rec_.currency_amount * -1;
         END IF;
      END IF;
      IF (rec_.voucher_type IS NULL) THEN
         rec_.voucher_type                := voucher_type_;
      END IF;
      -- showing inverted currency rate is wrong.
      IF ((trans_rec_.n6 IS NULL AND trans_rec_.n7 IS NULL AND trans_rec_.n8 IS NULL) AND 
          (trans_rec_.n3 IS NOT NULL OR trans_rec_.n4 IS NOT NULL OR trans_rec_.n5 IS NOT NULL)) THEN
         -- Bug 120401, Begin
         IF (rec_.currency_rate_type IS NOT NULL ) THEN
            curr_type_ := rec_.currency_rate_type;
         ELSE
            curr_type_ := Currency_Type_API.Get_Default_Type(rec_.company);
            rec_.currency_rate_type := curr_type_;
         END IF;
         Currency_Rate_API.Fetch_Currency_Rate_Base(conv_factor_,
                                                    curr_rate_,
                                                    inverted_,
                                                    rec_.company,
                                                    rec_.currency_code,
                                                    base_currency_,
                                                    curr_type_,
                                                    act_curr_date_,
                                                    'DUMMY');
         rec_.currency_rate := curr_rate_;                                                      
      END IF;
           
      main_correction_              := Ext_Parameters_API.Get_Correction (company_ , load_type_);
      
      IF main_correction_ = 'TRUE' THEN
         rec_.correction :='FALSE';
         IF NVL(rec_.currency_debet_amount,0)*NVL(rec_.debet_amount,0) < 0 THEN
            -- assigned something new in order to maintain this line as an error line until this gets saved  
            rec_.correction :='EDEB';
         ELSIF NVL(rec_.currency_credit_amount,0)*NVL(rec_.credit_amount,0) < 0 THEN
            -- assigned something new in order to maintain this line as an error line until this gets saved  
            rec_.correction :='ECRD';
         ELSIF NVL(rec_.amount,0)*NVL(rec_.currency_amount,0)<0 THEN
            -- assigned something new in order to maintain this line as an error line until this gets saved  
            rec_.correction :='EAMT';
         ELSIF NVL(rec_.currency_debet_amount,0)     < 0 THEN
            rec_.correction :='TRUE';
         ELSIF NVL(rec_.currency_credit_amount,0) < 0 THEN
             rec_.correction :='TRUE';
         ELSIF NVL(rec_.debet_amount,0)           < 0 THEN
            rec_.correction :='TRUE';
         ELSIF NVL(rec_.credit_amount,0)          < 0 THEN
            rec_.correction :='TRUE';
         ELSIF rec_.currency_debet_amount IS NULL AND rec_.currency_credit_amount IS NULL AND rec_.currency_amount IS NOT NULL THEN
            rec_.correction :='TRUE';
         ELSIF  rec_.debet_amount IS NULL AND rec_.credit_amount IS NULL AND rec_.amount IS NOT NULL THEN
            rec_.correction :='TRUE';
         END IF;
      END IF;
      
      IF rec_.correction = 'FALSE' THEN
         IF (rec_.currency_amount IS NOT NULL AND rec_.currency_debet_amount IS NULL AND rec_.currency_credit_amount IS NULL) THEN
            IF (rec_.currency_amount < 0) THEN
               rec_.currency_credit_amount := rec_.currency_amount * -1;
            ELSE
               rec_.currency_debet_amount  := rec_.currency_amount;  
            END IF;            
         ELSIF (NVL(rec_.currency_credit_amount,0) != 0) THEN
            IF (rec_.currency_credit_amount < 0) THEN
               rec_.currency_amount        := rec_.currency_credit_amount;                           
               rec_.currency_credit_amount := rec_.currency_credit_amount * -1;
            ELSE
               rec_.currency_amount        := rec_.currency_credit_amount * -1;
            END IF;
         ELSIF (NVL(rec_.currency_debet_amount,0) != 0 ) THEN
            IF (rec_.currency_debet_amount < 0) THEN
               rec_.currency_debet_amount  := rec_.currency_debet_amount * -1;
               rec_.currency_amount        := rec_.currency_debet_amount;
            ELSE
               rec_.currency_amount        := rec_.currency_debet_amount;
            END IF;
         END IF;
         IF (rec_.amount IS NOT NULL AND rec_.debet_amount IS NULL AND rec_.credit_amount IS NULL) THEN
            IF (rec_.amount < 0) THEN
               rec_.credit_amount := rec_.amount * -1;
            ELSE
               rec_.debet_amount  := rec_.amount;
            END IF;
         ELSIF (rec_.credit_amount IS NOT NULL) THEN
            IF (rec_.credit_amount < 0) THEN
               rec_.amount        := rec_.credit_amount;
               rec_.credit_amount := rec_.credit_amount * -1;
            ELSE
               rec_.amount        := rec_.credit_amount * -1;
            END IF;
         ELSIF (rec_.debet_amount IS NOT NULL) THEN
            IF (rec_.debet_amount < 0) THEN
               rec_.debet_amount  := rec_.debet_amount * -1;
               rec_.amount        := rec_.debet_amount;
            ELSE
               rec_.amount        := rec_.debet_amount;
            END IF;
         END IF;
         IF (rec_.third_currency_amount IS NOT NULL AND rec_.third_currency_debit_amount IS NULL AND rec_.third_currency_credit_amount IS NULL) THEN
            IF (rec_.third_currency_amount < 0) THEN
               rec_.third_currency_credit_amount := rec_.third_currency_amount * -1;
            ELSE
               rec_.third_currency_debit_amount  := rec_.third_currency_amount;
            END IF;
         ELSIF (NVL(rec_.third_currency_credit_amount,0) != 0) THEN
            IF (rec_.third_currency_credit_amount < 0) THEN
               rec_.third_currency_amount        := rec_.third_currency_credit_amount;
               rec_.third_currency_credit_amount := rec_.third_currency_credit_amount * -1;
            ELSE
               rec_.third_currency_amount        := rec_.third_currency_credit_amount * -1;
            END IF;
         ELSIF (NVL(rec_.third_currency_debit_amount,0) != 0 ) THEN
            IF (rec_.third_currency_debit_amount < 0) THEN
               rec_.third_currency_debit_amount  := rec_.third_currency_debit_amount * -1;
               rec_.third_currency_amount        := rec_.third_currency_debit_amount;
            ELSE
               rec_.third_currency_amount        := rec_.third_currency_debit_amount;
            END IF;
         END IF;
      ELSIF rec_.correction = 'TRUE' THEN
         IF (rec_.currency_amount IS NOT NULL AND rec_.currency_debet_amount IS NULL AND rec_.currency_credit_amount IS NULL) THEN
            IF (rec_.currency_amount < 0) THEN
               rec_.currency_debet_amount  := rec_.currency_amount;
               rec_.currency_credit_amount := NULL;
            ELSE
               rec_.currency_credit_amount := rec_.currency_amount * -1;            
               rec_.currency_debet_amount  := NULL;               
            END IF;
         ELSIF (NVL(rec_.currency_debet_amount,0) != 0 ) THEN
            IF (rec_.currency_credit_amount < 0) THEN
               rec_.currency_amount        := rec_.currency_credit_amount * -1;
            ELSE
               rec_.currency_amount        := rec_.currency_credit_amount;
               rec_.currency_credit_amount := rec_.currency_credit_amount * -1;               
            END IF;                     
         ELSIF (NVL(rec_.currency_debet_amount,0) != 0 ) THEN
            IF (rec_.currency_debet_amount < 0) THEN
               rec_.currency_amount        := rec_.currency_debet_amount;
            ELSE
               rec_.currency_debet_amount  := rec_.currency_debet_amount * -1;
               rec_.currency_amount        := rec_.currency_debet_amount;
            END IF;
         END IF;
         IF (rec_.amount IS NOT NULL AND rec_.debet_amount IS NULL AND rec_.credit_amount IS NULL) THEN
            IF (rec_.amount < 0) THEN
               rec_.debet_amount  := rec_.amount;
               rec_.credit_amount := NULL;
            ELSE
               rec_.credit_amount := rec_.amount * -1;            
               rec_.debet_amount  := NULL;               
            END IF;
         ELSIF (rec_.credit_amount IS NOT NULL) THEN
            IF (rec_.credit_amount < 0) THEN
               rec_.amount        := rec_.credit_amount * -1;
            ELSE
               rec_.amount        := rec_.credit_amount;
               rec_.credit_amount := rec_.credit_amount * -1;               
            END IF;                     
         ELSIF (rec_.debet_amount IS NOT NULL) THEN
            IF (rec_.debet_amount < 0) THEN
               rec_.amount        := rec_.debet_amount;
            ELSE
               rec_.debet_amount  := rec_.debet_amount * -1;
               rec_.amount        := rec_.debet_amount;
            END IF;
         END IF;
         IF (rec_.third_currency_amount IS NOT NULL AND rec_.third_currency_debit_amount IS NULL AND rec_.third_currency_credit_amount IS NULL) THEN
            IF (rec_.third_currency_amount < 0) THEN
               rec_.third_currency_debit_amount  := rec_.third_currency_amount;
               rec_.third_currency_credit_amount := NULL;
            ELSE
               rec_.third_currency_credit_amount := rec_.third_currency_amount * -1;
               rec_.third_currency_debit_amount  := NULL;
            END IF;
         ELSIF (NVL(rec_.third_currency_debit_amount,0) != 0 ) THEN
            IF (rec_.third_currency_credit_amount < 0) THEN
               rec_.third_currency_amount        := rec_.third_currency_credit_amount * -1;
            ELSE
               rec_.third_currency_amount        := rec_.third_currency_credit_amount;
               rec_.third_currency_credit_amount := rec_.third_currency_credit_amount * -1;
            END IF;
         ELSIF (NVL(rec_.third_currency_debit_amount,0) != 0 ) THEN
            IF (rec_.third_currency_debit_amount < 0) THEN
               rec_.third_currency_amount        := rec_.third_currency_debit_amount;
            ELSE
               rec_.third_currency_debit_amount  := rec_.third_currency_debit_amount * -1;
               rec_.third_currency_amount        := rec_.third_currency_debit_amount;
            END IF;
         END IF;
      ELSIF rec_.correction = 'EDEB' THEN
         rec_.currency_amount              :=rec_.currency_debet_amount * -1;
      ELSIF rec_.correction = 'ECRD' THEN
         rec_.currency_amount              := rec_.currency_credit_amount * -1;
      ELSIF rec_.correction = 'EAMT' THEN
         IF rec_.currency_amount < 0 THEN
            rec_.currency_credit_amount    := rec_.currency_amount * -1;
         ELSIF rec_.currency_amount > 0 THEN
            rec_.currency_debet_amount     := rec_.currency_amount;
         END IF;
         IF rec_.amount < 0 THEN
            rec_.credit_amount             := rec_.amount * -1;
         ELSIF rec_.amount > 0 THEN
            rec_.debet_amount              := rec_.amount;
         END IF;
      END IF;
      
      IF (rec_.currency_rate_type IS NOT NULL ) THEN
         IF (rec_.currency_amount IS NOT NULL ) THEN
            IF ( conv_factor_ != 0) THEN
               IF (rec_.currency_amount > 0 AND rec_.currency_credit_amount IS NOT NULL) THEN
                  rec_.currency_amount := rec_.currency_amount * -1;
               ELSIF (rec_.currency_amount < 0 AND rec_.currency_debet_amount IS NOT NULL ) THEN
                  rec_.currency_amount := rec_.currency_amount * -1;
               END IF;               
               IF (inverted_= 'TRUE')  THEN
                  rec_.amount := ROUND(rec_.currency_amount * 1/(curr_rate_/conv_factor_),base_currency_round_);
               ELSE
                  rec_.amount := ROUND(rec_.currency_amount * (curr_rate_/conv_factor_),base_currency_round_);
               END IF;
            END IF;
         END IF;
      END IF;
      
      rec_.quantity                       := trans_rec_.n9;
      -- Bug 102620, begin, added if condition
      IF (ext_vouch_date_ = '2') THEN
         rec_.transaction_date               := trans_rec_.d1;
      END IF;
      -- Bug 102620, end
      rec_.tax_amount                     := ROUND(trans_rec_.n12,base_currency_round_);
      rec_.currency_tax_amount            := ROUND(trans_rec_.n13,trans_currency_round_);
      -- Bug 102620, begin, modified if condition to fetch the load date from external load data
      IF (ext_vouch_date_ = '1' OR rec_.transaction_date IS NULL) THEN
         rec_.transaction_date            := load_date_;
      END IF;
      -- Bug 102620, end
      IF (rec_.currency_code = base_currency_) THEN
         IF (NVL(rec_.currency_amount,0)=0 AND rec_.amount IS NOT NULL) THEN
            rec_.currency_amount := rec_.amount;
         END IF;
         IF (NVL(rec_.amount,0)=0 AND rec_.currency_amount IS NOT NULL) THEN
            rec_.amount := rec_.currency_amount;
         END IF;
         IF (NVL(rec_.currency_debet_amount,0)=0 AND rec_.debet_amount IS NOT NULL) THEN
            rec_.currency_debet_amount := rec_.debet_amount;
         END IF;
         IF (NVL(rec_.debet_amount,0)=0 AND rec_.currency_debet_amount IS NOT NULL) THEN
            rec_.debet_amount := rec_.currency_debet_amount;
         END IF;
         IF (NVL(rec_.currency_credit_amount,0)=0 AND rec_.credit_amount IS NOT NULL) THEN
            rec_.currency_credit_amount := rec_.credit_amount;
         END IF;
         IF (NVL(rec_.credit_amount,0)=0 AND rec_.currency_credit_amount IS NOT NULL) THEN
            rec_.credit_amount := rec_.currency_credit_amount;
         END IF;
      ELSE
         -- If the file have amount in transaction currency but not in accounting currency,
         -- amounts in accounting currency will be calculated
         IF (rec_.currency_amount IS NOT NULL AND rec_.amount IS NULL) THEN
            rec_.amount := ROUND(rec_.currency_amount * (trans_curr_rate_ / trans_conv_factor_), base_currency_round_);
            --IF (rec_.amount < 0) THEN
            IF (NVL(rec_.currency_credit_amount,0) != 0 ) THEN
               rec_.credit_amount            := rec_.amount * -1;
               rec_.debet_amount             := NULL;
            ELSE
               rec_.credit_amount            := NULL;
               rec_.debet_amount             := rec_.amount;
            END IF;
         END IF;
      END IF;

               
      IF (third_currency_code_ IS NOT NULL AND rec_.third_currency_amount IS NULL) THEN 
         IF (rec_.amount IS NOT NULL) THEN
            IF (rec_.parallel_curr_rate_type IS NULL) THEN
               rec_.parallel_curr_rate_type := Company_Finance_API.Get_Parallel_Rate_Type(company_); 
            END IF;
             rec_.third_currency_amount := Currency_Amount_API.Calculate_Parallel_Curr_Amount (rec_.company,
                                                                                               tst_curr_date_,
                                                                                               rec_.amount,
                                                                                               rec_.currency_amount,
                                                                                               base_currency_,
                                                                                               rec_.currency_code,
                                                                                               rec_.parallel_curr_rate_type,
                                                                                               third_currency_code_,
                                                                                               NULL,
                                                                                               is_base_emu_,
                                                                                               is_third_emu_);
            rec_.third_currency_amount := ROUND(rec_.third_currency_amount,third_currency_round_);
         END IF;
            
         IF rec_.correction = 'FALSE' THEN
            IF (rec_.third_currency_amount IS NOT NULL AND rec_.third_currency_debit_amount IS NULL AND rec_.third_currency_credit_amount IS NULL) THEN
               IF (rec_.third_currency_amount < 0) THEN
                  rec_.third_currency_credit_amount := rec_.third_currency_amount * -1;
               ELSE
                  rec_.third_currency_debit_amount  := rec_.third_currency_amount;
               END IF; 
            END IF;   
         ELSIF rec_.correction = 'TRUE' THEN
            IF (rec_.third_currency_amount IS NOT NULL AND rec_.third_currency_debit_amount IS NULL AND rec_.third_currency_credit_amount IS NULL) THEN
               IF (rec_.third_currency_amount < 0) THEN
                  rec_.third_currency_debit_amount  := rec_.third_currency_amount;
                  rec_.third_currency_credit_amount := NULL;
               ELSE
                  rec_.third_currency_credit_amount := rec_.third_currency_amount * -1;
                  rec_.third_currency_debit_amount  := NULL;
               END IF;
            END IF;
         END IF; 
      END IF;  
      
      IF (third_currency_code_ IS NOT NULL AND rec_.third_currency_tax_amount IS NULL) THEN 
         IF (rec_.tax_amount IS NOT NULL) THEN
            rec_.third_currency_tax_amount := Currency_Amount_API.Calculate_Parallel_Curr_Amount (rec_.company,
                                                                                                  tst_curr_date_,
                                                                                                  rec_.tax_amount,
                                                                                                  rec_.currency_tax_amount,
                                                                                                  base_currency_,
                                                                                                  rec_.currency_code,
                                                                                                  rec_.parallel_curr_rate_type,
                                                                                                  third_currency_code_,
                                                                                                  NULL,
                                                                                                  is_base_emu_,
                                                                                                  is_third_emu_);
            rec_.third_currency_tax_amount := ROUND(rec_.third_currency_tax_amount,third_currency_round_);
         END IF;
      END IF;
      
      rec_.ext_vouch_date                 := ext_vouch_date_;
      rec_.ext_group_item                 := ext_group_by_item_;
      Error_SYS.Check_Not_Null(lu_name_, 'COMPANY', rec_.company);
      Error_SYS.Check_Not_Null(lu_name_, 'USER_ID', user_id_);
      Error_SYS.Check_Not_Null(lu_name_, 'VOUCHER_TYPE', rec_.voucher_type);
      line_no_ := line_no_ +1;
      IF (ext_vouch_extern_ = '1') THEN
         rec_.voucher_no := voucher_no_;
      END IF;
      IF (ext_group_by_item_ = '1') THEN
         IF (NVL(rec_.voucher_type,' ') = ' ') THEN
            rec_.load_group_item := TO_CHAR(rec_.voucher_no);
         ELSE
            rec_.load_group_item := rec_.voucher_type || TO_CHAR(rec_.voucher_no);
         END IF;
         Trace_SYS.Message ('rec_.load_group_item : '||rec_.load_group_item);
      ELSIF (ext_group_by_item_ = '2') THEN
            IF (NVL(rec_.voucher_type,' ') = ' ') THEN
               rec_.load_group_item := load_group_item_;
            ELSE
               rec_.load_group_item := rec_.voucher_type || load_group_item_;
            END IF;
      ELSIF (ext_group_by_item_ = '3') THEN
         IF (NVL(rec_.voucher_type,' ') = ' ') THEN
            rec_.load_group_item := TO_CHAR(rec_.transaction_date,'YYYYMMDD');
         ELSE
            rec_.load_group_item := rec_.voucher_type || TO_CHAR(rec_.transaction_date,'YYYYMMDD');
         END IF;
      ELSIF (ext_group_by_item_ = '4') THEN
         IF (NVL(rec_.voucher_type,' ') = ' ') THEN
            rec_.load_group_item := rec_.reference_number;
         ELSE
            rec_.load_group_item := rec_.voucher_type || rec_.reference_number;
         END IF;
      END IF;
      
      IF (mode_ = 'ONLINE') THEN
         Error_SYS.Check_Not_Null(lu_name_, 'ACCOUNT', rec_.codestring_rec.code_a);
         Ext_Load_API.Load_Transaction (rec_.company, -- 49830 
                                        load_id_,
                                        voucher_type_,
                                        load_date_,
                                        user_id_,
                                        rec_,
                                        checked_,
                                        load_type_,
                                        load_file_id_);                             
      ELSE
         Ext_Load_API.Load_Transaction (rec_.company,  
                                        load_id_,
                                        voucher_type_,
                                        load_date_,
                                        user_id_,
                                        rec_,
                                        checked_,
                                        load_type_,
                                        load_file_id_);
                                        
         Ext_File_Trans_API.Update_Row_State (load_file_id_,
                                              trans_rec_.row_no,
                                              '3');
      END IF;
      IF (line_no_ > 0) THEN
         loaded_ := TRUE;
      END IF;
      rec_.currency_rate := NULL;
   END LOOP;

   IF (line_no_ = 0) THEN
      Error_Sys.Record_General(lu_name_,'NOUNPDATA: No unpacked data found, check load file id :P1',load_file_id_);
   ELSE
      Ext_File_Load_API.Update_State (load_file_id_, '4');
      FOR load_rec_ IN get_load_id LOOP
         ext_load_state_ := Ext_Load_State_API.Encode(Ext_Load_Info_API.Get_Ext_Load_State (load_rec_.company, load_rec_.load_id));
         Trace_SYS.Message ('ext_load_state_ : '||ext_load_state_||' check_when_loadedx_ : '||check_when_loadedx_||' create_when_checkedx_ : '||create_when_checkedx_);
         err_msg_ := 'NOERRORLOAD: Load id :P1 is loaded without errors';
         Client_SYS.Clear_Info;
         Client_SYS.Add_Info(lu_name_, err_msg_, load_rec_.load_id);
         info_ := Client_SYS.Get_All_Info;
         IF (ext_load_state_ = '1') THEN
            IF (check_when_loadedx_ = 'TRUE') THEN
               Ext_Check_API.Check_Transaction ( info_,
                                                 load_rec_.company,
                                                 load_rec_.load_id,
                                                 'TRUE' );
               ext_load_state_ := Ext_Load_State_API.Encode(Ext_Load_Info_API.Get_Ext_Load_State (load_rec_.company, load_rec_.load_id));
            END IF;
         END IF;
         IF (ext_load_state_ IN ('3','4')) THEN
            IF (create_when_checkedx_ = 'TRUE') THEN
               Ext_Create_API.Create_Voucher ( info_,
                                               load_rec_.company,
                                               load_rec_.load_id );
               ext_load_state_ := Ext_Load_State_API.Encode(Ext_Load_Info_API.Get_Ext_Load_State (load_rec_.company, load_rec_.load_id));
            END IF;
         END IF;
      END LOOP;
   END IF;
   IF (ext_load_state_ = '1') THEN
      err_msg_ := 'NOERRORLOAD: Company / Load id :P1 is loaded without errors';
      translate_ := Language_SYS.Translate_Constant(lu_name_, 'NOERRORLOAD: Company / Load id :P1 is loaded without errors');
   ELSIF (ext_load_state_ = '2') THEN
      err_msg_ := 'ERRORLOAD: Company / Load id :P1 is loaded with errors';
      translate_ := Language_SYS.Translate_Constant(lu_name_,'ERRORLOAD: Company / Load id :P1 is loaded with errors');
   ELSIF (ext_load_state_ = '3') THEN
      err_msg_ := 'NOERRORCHK: Company / Load id :P1 is checked without errors';
      translate_ := Language_SYS.Translate_Constant(lu_name_,'NOERRORCHK: Company / Load id :P1 is checked without errors');
   ELSIF (ext_load_state_ = '4') THEN
      err_msg_ := 'ERRORCHK: Company / Load id :P1 is checked with errors';
      translate_ := Language_SYS.Translate_Constant(lu_name_,'ERRORCHK: Company / Load id :P1 is checked with errors');
   ELSIF (ext_load_state_ = '5') THEN
      err_msg_ := 'NOERRORCRE: Company / Load id :P1 is updated to hold table';
      translate_ := Language_SYS.Translate_Constant(lu_name_,'NOERRORCRE: Company / Load id :P1 is updated to hold table');
   ELSIF (ext_load_state_ = '6') THEN
      err_msg_ := 'ERRORCRE: Company / Load id :P1 is created with errors';
      translate_ := Language_SYS.Translate_Constant(lu_name_,'ERRORCRE: Company / Load id :P1 is created with errors');
   END IF;
   IF (err_msg_ IS NOT NULL) THEN
      Client_SYS.Add_Info(lu_name_, err_msg_, company_load_id_);
   END IF;
   info_ := Client_SYS.Get_All_Info;
EXCEPTION
   WHEN OTHERS THEN
      err_msg_ := SQLERRM;
      info_    := err_msg_;
      Ext_File_Trans_API.Update_Row_State (load_file_id_,
                                           rec_.row_no,
                                           '5',
                                           err_msg_);
      Ext_File_Load_API.Update_State (load_file_id_, '9');   
END Start_Ext_Vouchers;



