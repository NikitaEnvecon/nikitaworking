-----------------------------------------------------------------------------
--
--  Logical unit: VoucherUtilPub
--  Component:    ACCRUL
--
--  IFS Developer Studio Template Version 3.0
--
--  Date    Sign    History
--  ------  ------  ---------------------------------------------------------
--  000811  LiSv     A523: Added item_id to newrec_ in Create_Voucher_Rows.
--  000830  OVJOSE   Added ledger_id, add_internal, internal_seq_number to newrec_
--                   in Create_Voucher_Rows.
--  000908  Uma      Added Internal Ledger validations in Complete_Voucher, 
--                   Create_Voucher_Rows, Create_Voucher_Head. 
--  000908  BmEk     A527: Added tax_base_amount and currency_tax_base_amount in 
--                   Create_Voucher_Rows.
--  000915  HiMu     Added General_SYS.Init_Method
--  000918  Uma      Corrected Bug ID #48556/48558.  
--  001002  LiSv     Added code in Complete_Voucher to support if it not is automatic allotment;
--  001006  prtilk   BUG # 15677  Checked General_SYS.Init_Method
--  001016  Uma      Corrected Bug #49729 and #50071
--  001220  Chajlk   Corrected Bug # 53728 ( Foreign Call Id 18437).
--  010215  ANTRSE   Corrected Bug # 20027
--  010221  ANTRSE   Recorrection of Bug # 20027
--  010226  ToOs     Bug # 20254 Added a check IF intled is installed
--  010508  JeGu     Bug #21705 Implementation New Dummyinterface
--  010817  SUMALK   Bug 23366 Fixed.( Intled vouchers were not created when voutype is connected to AllLedger).
--  030131  mgutse   IID ITFI127N. Added reference_version in Create_Voucher_Rows.
--  030328  RAFA     IID RDFI151N. Added party_type to Create_Voucher_Rows.
--  030327  Bmekse   IID ITFI127N, Added tax_item_id to newrec_ in Create_Voucher_Rows.
--  040329  Gepelk   2004 SP1 Merge.
--  040901  Kagalk   LCS Merge (45622).
--  041025  Gawilk   FIPR307. Added inv_acc_row_id to newrec_ in Create_Voucher_Rows.
--  051114  THPELK   FIAD377 - Added Rollback_Voucher_ parameter for Create_Reverse_Voucher().
--  051118  WAPELK   Merged the Bug 52783. Correct the user group variable's width.
--  051213  Nsillk   Merged Bug 53811, Added new method  Is_Project_Vouchers_Updated() to check 
--  051213           if project connected Vouchers are updated.
--  060310  Gawilk   Added currency_type to newrec_ in Create_Voucher_Rows. 
--  070424  Nimalk   LCS Merge 64666, Added PROCEDURE Adjust_Multi_Comp_Vou_Row  
--  070708  Kagalk   LCS Merge 62414, Modified Create_Voucher_Rows method.  
--  071101  Maaylk   Bug 66085, Modified Create_Voucher_Rows to change currency amount and currency code for prize variance voucher row lines 
--  071201  Jeguse   Bug 69803 Corrected.
--  080102  Maaylk   Bug 70040, Instead of assigning 1 to currency_rate_ got the currency rate of base currency of voucher_company.
--  080315  Kagalk   Bug 70611, Corrected voucher not balanced error for multi company invoices.
--  080326  NiFelk   Bug 69891, Corrected.
--  080423  Makrlk   Bug 69890, Corrected.
--  080709  AsHelk   Bug 74637, Corrected.  
--  080814  Kanslk   Bug 74448, Modified PROCEDURE Adjust_Multi_Comp_Vou_Row
--  080918  Chhulk   Bug 75732, Modified Create_Voucher_Rows()
--  080919  Jeguse   Bug 77131, Modified Create_Voucher_Rows
--  090810  LaPrlk   Bug 79846, Removed the precisions defined for NUMBER type variables.
--  100824  Hiralk   Bug 91131, Modified Adjust_Multi_Comp_Vou_Row().
--  111020  Swralk   SFI-143, Added conditional compilation for the places that had called package INTLED_CONNECTION_V101_API.
--  111209  Shdilk   SFI-1125, Conditional compilation. Add Get_Acc_Journal.
--  111213  Clstlk   SFI-784, LCS bug 99676, Added method Create_Object_Connection().
--  111219  Lisvse   SFI-1011, Removed code added by bug 66085 and 70040 for posting type M91 and M92 since this code is not accurate any more. 
--                   In IID HP051 - BF Currency Handling this logic was changed so currency amount is reflected for M91 and M92.
--  121123  Thpelk  Bug 106680 - Modified Conditional compilation to use single component package.
--  121123  Janblk   DANU-122, Parallel currency implementatio
--  140411  Nirylk   PBFI-5614, Added deliv_type_id to PublicRowRec, Modified Create_Voucher_Rows()
--  140804  SALIDE   PRFI-1379, Modified Create_Voucher_Rows()
--  150128  AjPelk PRFI-4489, Lcs merge Bug 120401, Added the new field CURRENCY_RATE_TYPE
--  160405  Nudilk   Bug 128457, Corrected.
-----------------------------------------------------------------------------

layer Core;

-------------------- PUBLIC DECLARATIONS ------------------------------------

TYPE  PublicHeadRec1 IS RECORD (
      company              VARCHAR2(20),
      voucher_date         DATE,
      user_group           user_group_member_finance_tab.user_group%type,
      voucher_type         VARCHAR2(3),
      voucher_no           NUMBER,
      voucher_type_ref     VARCHAR2(3),
      accounting_year_ref  NUMBER,
      voucher_no_ref       NUMBER,
      multi_company_id     VARCHAR2(20),
      voucher_text         VARCHAR2(2000),
      notes                VARCHAR2(2000),
      voucher_group        VARCHAR2(3),
      is_from_payment      VARCHAR2(5));
TYPE  PublicHeadRec2 IS RECORD (
      company              VARCHAR2(20),
      voucher_date         DATE,
      User                 VARCHAR2(30),
      voucher_group        VARCHAR2(3),
      voucher_no           NUMBER,
      voucher_type_ref     VARCHAR2(3),
      accounting_year_ref  NUMBER,
      voucher_no_ref       NUMBER,
      multi_company_id     VARCHAR2(20),
      voucher_text         VARCHAR2(2000),
      notes                VARCHAR2(2000),
      user_group           user_group_member_finance_tab.user_group%type,
      approval_user        VARCHAR2(30));
TYPE  PublicHeadRec3    IS RECORD (
      company              VARCHAR2(20),
      voucher_type         VARCHAR2(3),
      accounting_year      NUMBER,
      accounting_period    NUMBER,
      voucher_no           NUMBER);
TYPE  HeadInfoRec    IS RECORD (
      company              VARCHAR2(20),
      voucher_type         VARCHAR2(3),
      accounting_year      NUMBER,
      accounting_period    NUMBER,
      fictive_voucher_no   VARCHAR2(10),
      voucher_date         DATE,
      transfer_id          VARCHAR2(2000));
TYPE  PublicKeyRec   IS RECORD (
      company              VARCHAR2(20),
      voucher_type         VARCHAR2(3),
      accounting_year      NUMBER,
      voucher_no           NUMBER);
TYPE  PublicRowRec   IS RECORD (
      currency_code                VARCHAR2(3),
      debit                        BOOLEAN,
      amount                       NUMBER,
      currency_rate                NUMBER,
      conversion_factor            NUMBER,
      currency_amount              NUMBER,
      third_currency_amount        NUMBER,
      tax_base_curr                NUMBER,
      tax_base_dom                 NUMBER,
      codestring_rec               Accounting_Codestr_API.CodestrRec,
      quantity                     NUMBER,
      process_code                 VARCHAR2(10),
      optional_code                VARCHAR2(20),
      project_activity_id          NUMBER,
      text                         VARCHAR2(200),
      party_type_id                VARCHAR2(20),
      reference_serie              VARCHAR2(50),
      reference_number             VARCHAR2(50),
      trans_code                   VARCHAR2(100),
      corrected                    VARCHAR2(20),
      multi_company_id             VARCHAR2(20),
      item_id                      NUMBER,
      ledger_id                    VARCHAR2(10),
      add_internal                 VARCHAR2(5),
      internal_seq_number          NUMBER,
      reference_version            NUMBER,
      party_type                   VARCHAR2(20),
      tax_item_id                  NUMBER,
      inv_acc_row_id               VARCHAR2(100),
      currency_type                VARCHAR2(10),
      tax_direction                VARCHAR2(20),
      allocation_id                NUMBER,
      ext_validate_codestr         VARCHAR2(10),
      auto_tax_vou_entry           VARCHAR2(20),
      tax_amount                   NUMBER,
      currency_tax_amount          NUMBER,
      mpccom_accounting_id         NUMBER,
      revenue_cost_clear_voucher   VARCHAR2(5),
      function_group               VARCHAR2(10),
      update_error                 VARCHAR2(200),
      third_currency_tax_amount    NUMBER,
      third_curr_tax_base_amount   NUMBER,
      third_curr_gross_amt         NUMBER,
      parallel_curr_rate_type      VARCHAR2(10),
      parallel_curr_rate           NUMBER,
      parallel_curr_conv_factor    NUMBER,
      third_debit                  BOOLEAN,
      deliv_type_id                voucher_row_tab.deliv_type_id%TYPE,
      reference_row_no             NUMBER,
      currency_rate_type           VARCHAR2(10));

-------------------- PRIVATE DECLARATIONS -----------------------------------


-------------------- LU SPECIFIC IMPLEMENTATION METHODS ---------------------

-------------------- LU SPECIFIC PRIVATE METHODS ----------------------------

-------------------- LU SPECIFIC PROTECTED METHODS --------------------------

-------------------- LU SPECIFIC PUBLIC METHODS -----------------------------

PROCEDURE Create_Voucher_Head (
   head_info_rec_ OUT HeadInfoRec,
   vou_head_rec_  IN  PublicHeadRec1 )
IS
   vou_rec_           VOUCHER_TAB%ROWTYPE;
   ledger_id_         VARCHAR2(10);      
   CURSOR get_voucher IS
      SELECT * 
      FROM   VOUCHER_TAB
      WHERE  transfer_id = head_info_rec_.transfer_id;
BEGIN
   IF (Company_API.Get_Template_Company(vou_head_rec_.company) = 'TRUE') THEN
      Error_SYS.Appl_General(lu_name_, 'TEMPLATECOMP: Company :P1 is a Template Company and cannot create vouchers', vou_head_rec_.company);
   END IF; 
   ledger_id_ :=  Voucher_Type_API.Get_Ledger_Id(vou_head_rec_.company, vou_head_rec_.voucher_type);
   Voucher_API.Create_Voucher_Head__(  head_info_rec_.transfer_id,
                                       vou_head_rec_.company,
                                       vou_head_rec_.voucher_date,
                                       vou_head_rec_.user_group,
                                       vou_head_rec_.voucher_type,
                                       vou_head_rec_.voucher_no,
                                       vou_head_rec_.voucher_type_ref,
                                       vou_head_rec_.accounting_year_ref,
                                       vou_head_rec_.voucher_no_ref,
                                       vou_head_rec_.multi_company_id,
                                       vou_head_rec_.voucher_text,
                                       vou_head_rec_.notes,
                                       vou_head_rec_.voucher_group,
                                       is_from_payment_ => vou_head_rec_.is_from_payment); 
   IF (ledger_id_ NOT IN ('*', '00')) THEN
      -- Internal Ledger
      $IF Component_Intled_SYS.INSTALLED $THEN
         Internal_Voucher_Util_Pub_API.Get_Head_Info_Internal( head_info_rec_.company,   
                                                               head_info_rec_.voucher_type,
                                                               head_info_rec_.accounting_year,
                                                               head_info_rec_.accounting_period,
                                                               head_info_rec_.fictive_voucher_no,
                                                               head_info_rec_.voucher_date,
                                                               head_info_rec_.transfer_id );                              
      $ELSE
         NULL;
      $END
   ELSE
      -- All Ledger or General Ledger
      Get_Head_Info( head_info_rec_.company,
                     head_info_rec_.voucher_type,
                     head_info_rec_.accounting_year,
                     head_info_rec_.accounting_period,
                     head_info_rec_.fictive_voucher_no,
                     head_info_rec_.voucher_date,
                     head_info_rec_.transfer_id );
   END IF;
   OPEN  get_voucher;
   FETCH get_voucher INTO vou_rec_;
   CLOSE get_voucher;    

   $IF Component_Intled_SYS.INSTALLED $THEN
      IF (Voucher_Type_API.Is_Vou_Type_All_Ledger(vou_rec_.company, vou_rec_.voucher_type) = 'TRUE') THEN
         Internal_Voucher_Util_Pub_API.Create_Internal_Head(vou_rec_);  
      END IF;
   $END
END Create_Voucher_Head;


PROCEDURE Create_Voucher_Head (
   head_info_rec_ OUT HeadInfoRec,
   vou_head_rec_  IN  PublicHeadRec2 )
IS
   user_group_             VARCHAR2(30);
   voucher_type_           VARCHAR2(3);
   vou_rec_                VOUCHER_TAB%ROWTYPE;
   CURSOR get_voucher IS
      SELECT * 
      FROM   VOUCHER_TAB
      WHERE  transfer_id = head_info_rec_.transfer_id;
BEGIN
   IF (Company_API.Get_Template_Company(vou_head_rec_.company) = 'TRUE') THEN
      Error_SYS.Appl_General(lu_name_, 'TEMPLATECOMP: Company :P1 is a Template Company and cannot create vouchers', vou_head_rec_.company);
   END IF;    
   user_group_ :=  vou_head_rec_.user_group;
   IF (user_group_ IS NULL) THEN
      user_group_ := User_Group_Member_Finance_API.Get_Default_Group( vou_head_rec_.company, vou_head_rec_.user);
   END IF;
   Voucher_Type_User_Group_Api.Get_Default_Voucher_Type(voucher_type_,
                                                        vou_head_rec_.company,
                                                        user_group_,
                                                        Accounting_Period_API.Get_Accounting_Year(vou_head_rec_.company,vou_head_rec_.voucher_date),
                                                        vou_head_rec_.voucher_group );
   Voucher_API.Create_Voucher_Head__ ( head_info_rec_.transfer_id,
                                       vou_head_rec_.company,
                                       vou_head_rec_.voucher_date,
                                       user_group_,
                                       voucher_type_,
                                       vou_head_rec_.voucher_no,
                                       vou_head_rec_.voucher_type_ref,
                                       vou_head_rec_.accounting_year_ref,
                                       vou_head_rec_.voucher_no_ref,
                                       vou_head_rec_.multi_company_id,
                                       vou_head_rec_.voucher_text,
                                       vou_head_rec_.notes,
                                       vou_head_rec_.voucher_group,
                                       vou_head_rec_.approval_user);  
   Get_Head_Info( head_info_rec_.company,
                  head_info_rec_.voucher_type,
                  head_info_rec_.accounting_year,
                  head_info_rec_.accounting_period,
                  head_info_rec_.fictive_voucher_no,
                  head_info_rec_.voucher_date,
                  head_info_rec_.transfer_id );
   OPEN  get_voucher;
   FETCH get_voucher INTO vou_rec_;
   CLOSE get_voucher;

   $IF Component_Intled_SYS.INSTALLED $THEN
      IF (Voucher_Type_API.Is_Vou_Type_All_Ledger(vou_rec_.company, vou_rec_.voucher_type) = 'TRUE') THEN
         Internal_Voucher_Util_Pub_API.Create_Internal_Head(vou_rec_);  
      END IF;                                                      
   $END
END Create_Voucher_Head;


PROCEDURE Create_Voucher_Rows (
   transfer_id_    IN VARCHAR2,
   public_row_rec_ IN PublicRowRec )
IS
BEGIN

   Create_Voucher_Rows (transfer_id_      ,
                        public_row_rec_   ,
                        NULL              ,
                        NULL              ,      
                        NULL               );

   
END Create_Voucher_Rows;


PROCEDURE Create_Voucher_Rows (
   transfer_id_         IN VARCHAR2,
   public_row_rec_      IN PublicRowRec,
   base_currency_code_  IN VARCHAR2,
   is_base_emu_         IN VARCHAR2,      
   is_third_emu_        IN VARCHAR2  )
IS
   company_                      VARCHAR2(20);
   voucher_type_                 VARCHAR2(3);
   accounting_year_              NUMBER;
   accounting_period_            NUMBER;
   fictive_voucher_no_           NUMBER;
   voucher_date_                 DATE;
   base_currency_codex_          VARCHAR2(3);
   third_currency_code_          VARCHAR2(3);
   is_base_emux_                 VARCHAR2(5);
   is_third_emux_                VARCHAR2(5);
   third_currency_amount_        NUMBER;
   currency_rate_                NUMBER;
   newrec_                       VOUCHER_ROW_TAB%ROWTYPE;
   ledger_id_                    VARCHAR2(10);
   function_group_               VARCHAR2(10);  
   inverted_rate_                VARCHAR2(5);
   third_curr_tax_base_amnt_     NUMBER;
   compfin_rec_                  Company_Finance_API.Public_Rec;
BEGIN
   company_            := substr(transfer_id_,INSTR(transfer_id_,'$',1,2)+1,(INSTR(transfer_id_,'$',1,3)-1)-INSTR(transfer_id_,'$',1,2));
   voucher_type_       := substr(transfer_id_,INSTR(transfer_id_,'$',1,4)+1,(INSTR(transfer_id_,'$',1,5)-1)-INSTR(transfer_id_,'$',1,4));
   IF (base_currency_code_ IS NULL) THEN
      base_currency_codex_ := Company_Finance_Api.Get_Currency_Code (company_);
   ELSE
      base_currency_codex_ := base_currency_code_;
   END IF;
   ledger_id_ := public_row_rec_.ledger_id;
   IF (ledger_id_ IS NULL) THEN
      ledger_id_    := Voucher_Type_Api.Get_Ledger_Id(company_, voucher_type_);
   END IF;
   IF (ledger_id_ NOT IN ('*', '00')) THEN
      -- Internal Ledger
      $IF Component_Intled_SYS.INSTALLED $THEN
         Internal_Voucher_Util_Pub_API.Get_Head_Info_Internal( company_,  
                                                               voucher_type_,
                                                               accounting_year_,
                                                               accounting_period_,
                                                               fictive_voucher_no_,
                                                               voucher_date_,
                                                               transfer_id_ ); 
      $ELSE
         NULL;
      $END
   ELSE
      -- All Ledger or Internal Ledger                                                      
      Get_Head_Info( company_,
                     voucher_type_,
                     accounting_year_,
                     accounting_period_,
                     fictive_voucher_no_,
                     voucher_date_,
                     transfer_id_ );
   END IF;                                                         
   IF ( public_row_rec_.currency_rate IS NULL) THEN
      Currency_Amount_Api.Calc_Currency_Rate(currency_rate_,
                                             company_,
                                             public_row_rec_.currency_code,
                                             public_row_rec_.amount,
                                             public_row_rec_.currency_amount);
   END IF;

   IF (is_base_emu_ IS NULL) THEN
      is_base_emux_ := Currency_Code_API.Get_Valid_Emu(company_, base_currency_codex_, voucher_date_);
   ELSE
      is_base_emux_ := is_base_emu_;
   END IF;

   -- Parallel currency handling
   compfin_rec_         := Company_Finance_API.Get(company_);
   third_currency_code_ := Company_Finance_API.Get_Parallel_Acc_Currency(company_, voucher_date_);
   
   IF (third_currency_code_ IS NOT NULL) THEN
      IF (is_third_emu_ IS NULL ) THEN
         is_third_emux_ := Currency_Code_API.Get_Valid_Emu(company_, third_currency_code_, voucher_date_);
      ELSE
         is_third_emux_ := is_third_emu_;
      END IF;
      newrec_.parallel_curr_rate_type  := NVL(public_row_rec_.parallel_curr_rate_type, compfin_rec_.parallel_rate_type);

      IF (public_row_rec_.third_currency_amount IS NULL) THEN
         -- parallel currency amount is not given then assume that not rate or conversion factor is not given either. Then fetch rate and 
         -- conversion factor and calculate parallel amount
         Currency_Rate_API.Get_Parallel_Currency_Rate(newrec_.parallel_currency_rate,
                                                      newrec_.parallel_conversion_factor,
                                                      inverted_rate_,
                                                      company_,
                                                      public_row_rec_.currency_code,
                                                      voucher_date_,
                                                      newrec_.parallel_curr_rate_type,
                                                      compfin_rec_.parallel_base,
                                                      base_currency_codex_,
                                                      third_currency_code_,
                                                      is_base_emux_,
                                                      is_third_emux_); 

         third_currency_amount_ := Currency_Amount_API.Calc_Parallel_Curr_Amt_Round(company_,
                                                                                    voucher_date_,
                                                                                    public_row_rec_.amount,
                                                                                    public_row_rec_.currency_amount,
                                                                                    base_currency_codex_,
                                                                                    public_row_rec_.currency_code,
                                                                                    newrec_.parallel_curr_rate_type,
                                                                                    third_currency_code_,
                                                                                    compfin_rec_.parallel_base,
                                                                                    is_base_emux_,
                                                                                    is_third_emux_);
      ELSE
         third_currency_amount_ := public_row_rec_.third_currency_amount;
         -- If rate if null then assume that conversion factor is also null. Then calculate rate and fetch conversion factor.
         IF (public_row_rec_.parallel_curr_rate IS NULL) THEN
            IF ( (public_row_rec_.amount = 0) OR (public_row_rec_.currency_amount = 0) OR (public_row_rec_.third_currency_amount = 0) ) THEN
               newrec_.parallel_currency_rate := 0;
            ELSE
               newrec_.parallel_currency_rate := Currency_Amount_API.Calculate_Parallel_Curr_Rate(company_,
                                                                                                  voucher_date_,
                                                                                                  public_row_rec_.amount,
                                                                                                  public_row_rec_.currency_amount,
                                                                                                  public_row_rec_.third_currency_amount,
                                                                                                  base_currency_codex_,
                                                                                                  public_row_rec_.currency_code,
                                                                                                  third_currency_code_,
                                                                                                  compfin_rec_.parallel_base,
                                                                                                  newrec_.parallel_curr_rate_type);
            END IF;
            
            newrec_.parallel_conversion_factor := Currency_Rate_API.Get_Par_Curr_Rate_Conv_Factor(company_,
                                                                                                  public_row_rec_.currency_code,
                                                                                                  voucher_date_,
                                                                                                  base_currency_codex_,
                                                                                                  third_currency_code_,
                                                                                                  compfin_rec_.parallel_base,
                                                                                                  newrec_.parallel_curr_rate_type);
                                                                                                  
         ELSE
            newrec_.parallel_currency_rate      := public_row_rec_.parallel_curr_rate;
            newrec_.parallel_conversion_factor  := public_row_rec_.parallel_curr_conv_factor;
         END IF;
      END IF;

   END IF;

   IF (public_row_rec_.debit) THEN
      newrec_.debet_amount                 := public_row_rec_.amount;
      newrec_.currency_debet_amount        := public_row_rec_.currency_amount;
      IF public_row_rec_.trans_code = 'AP9' THEN
        IF public_row_rec_.third_debit THEN
           newrec_.third_currency_debit_amount  := third_currency_amount_;  
        ELSE
           newrec_.third_currency_credit_amount := third_currency_amount_;
        END IF;
      ELSE  
         newrec_.third_currency_debit_amount  := third_currency_amount_;
      END IF;
   ELSE
      newrec_.credit_amount                := public_row_rec_.amount;
      newrec_.currency_credit_amount       := public_row_rec_.currency_amount;
      IF public_row_rec_.trans_code = 'AP9' THEN
         IF public_row_rec_.third_debit THEN
            newrec_.third_currency_debit_amount  := third_currency_amount_;  
         ELSE
            newrec_.third_currency_credit_amount := third_currency_amount_;
         END IF;  
      ELSE
         newrec_.third_currency_credit_amount := third_currency_amount_;
      END IF;
   END IF;
   
   IF (third_currency_code_ IS NOT NULL) THEN
      newrec_.parallel_curr_tax_amount       := public_row_rec_.third_currency_tax_amount;
      newrec_.parallel_curr_gross_amount     := public_row_rec_.third_curr_gross_amt;
      newrec_.parallel_curr_tax_base_amount  := public_row_rec_.third_curr_tax_base_amount;
      
      IF (public_row_rec_.third_curr_tax_base_amount IS NULL AND public_row_rec_.tax_base_dom IS NOT NULL) THEN 
         third_curr_tax_base_amnt_ := Currency_Amount_API.Calc_Parallel_Curr_Amt_Round(company_,
                                                                                       voucher_date_,
                                                                                       public_row_rec_.tax_base_dom,
                                                                                       public_row_rec_.tax_base_curr,
                                                                                       base_currency_codex_,
                                                                                       public_row_rec_.currency_code,
                                                                                       newrec_.parallel_curr_rate_type,
                                                                                       third_currency_code_,
                                                                                       compfin_rec_.parallel_base,
                                                                                       is_base_emux_,
                                                                                       is_third_emux_);
         newrec_.parallel_curr_tax_base_amount := third_curr_tax_base_amnt_; 
      END IF;
   ELSE
      -- if parallel currency is not used then set amounts to null
      newrec_.third_currency_debit_amount := NULL;
      newrec_.third_currency_credit_amount := NULL;
   END IF;

   newrec_.company                  := company_;
   newrec_.voucher_type             := voucher_type_;
   newrec_.accounting_year          := accounting_year_;
   newrec_.accounting_period        := accounting_period_;
   newrec_.voucher_no               := fictive_voucher_no_;
   newrec_.account                  := public_row_rec_.codestring_rec.code_a;
   newrec_.code_b                   := public_row_rec_.codestring_rec.code_b;
   newrec_.code_c                   := public_row_rec_.codestring_rec.code_c;
   newrec_.code_d                   := public_row_rec_.codestring_rec.code_d;
   newrec_.code_e                   := public_row_rec_.codestring_rec.code_e;
   newrec_.code_f                   := public_row_rec_.codestring_rec.code_f;
   newrec_.code_g                   := public_row_rec_.codestring_rec.code_g;
   newrec_.code_h                   := public_row_rec_.codestring_rec.code_h;
   newrec_.code_i                   := public_row_rec_.codestring_rec.code_i;
   newrec_.code_j                   := public_row_rec_.codestring_rec.code_j;
   newrec_.currency_code            := public_row_rec_.currency_code;
   newrec_.currency_rate            := NVL(public_row_rec_.currency_rate,currency_rate_);
   IF (public_row_rec_.conversion_factor IS NOT NULL) THEN
      newrec_.conversion_factor := public_row_rec_.conversion_factor;
   ELSE
      newrec_.conversion_factor := Currency_Code_Api.Get_Conversion_Factor(company_, newrec_.currency_code);
   END IF;
   newrec_.quantity                 := public_row_rec_.quantity;
   newrec_.process_code             := public_row_rec_.process_code;
   newrec_.optional_code            := public_row_rec_.optional_code;
   newrec_.project_activity_id      := public_row_rec_.project_activity_id;
   newrec_.text                     := public_row_rec_.text;
   newrec_.party_type_id            := public_row_rec_.party_type_id;
   newrec_.reference_serie          := public_row_rec_.reference_serie;
   newrec_.reference_number         := public_row_rec_.reference_number;
   newrec_.reference_version        := public_row_rec_.reference_version;
   newrec_.trans_code               := public_row_rec_.trans_code;
   newrec_.transfer_id              := transfer_id_;
   newrec_.corrected                := NVL( public_row_rec_.corrected, 'N' );
   newrec_.multi_company_id         := public_row_rec_.multi_company_id;
   newrec_.item_id                  := public_row_rec_.item_id;
   newrec_.internal_seq_number      := public_row_rec_.internal_seq_number;
   newrec_.tax_base_amount          := public_row_rec_.tax_base_dom;
   newrec_.currency_tax_base_amount := public_row_rec_.tax_base_curr;
   newrec_.party_type               := public_row_rec_.party_type;       
   newrec_.tax_item_id              := public_row_rec_.tax_item_id; 
   newrec_.inv_acc_row_id           := public_row_rec_.inv_acc_row_id;
   newrec_.currency_type            := public_row_rec_.currency_type;
   IF (newrec_.trans_code NOT LIKE 'IP%' AND newrec_.trans_code NOT LIKE 'PP%') THEN
      newrec_.allocation_id         := public_row_rec_.allocation_id;
   END IF;
   newrec_.auto_tax_vou_entry       := public_row_rec_.auto_tax_vou_entry;
   newrec_.tax_amount               := public_row_rec_.tax_amount;
   newrec_.currency_tax_amount      := public_row_rec_.currency_tax_amount;
   newrec_.mpccom_accounting_id     := public_row_rec_.mpccom_accounting_id;
   newrec_.update_error             := public_row_rec_.update_error;
   IF public_row_rec_.tax_direction IS NOT NULL THEN
      newrec_.tax_direction         := public_row_rec_.tax_direction;       
   END IF;
   newrec_.deliv_type_id            := public_row_rec_.deliv_type_id;
   newrec_.quantity                 := public_row_rec_.quantity;
   newrec_.reference_row_no         := public_row_rec_.reference_row_no;
   newrec_.currency_rate_type       := public_row_rec_.currency_rate_type;
   newrec_.parallel_curr_rate_type  := public_row_rec_.parallel_curr_rate_type;

   Error_SYS.Check_Not_Null(lu_name_, 'COMPANY',           newrec_.company);
   Error_SYS.Check_Not_Null(lu_name_, 'VOUCHER_TYPE',      newrec_.voucher_type);
   Error_SYS.Check_Not_Null(lu_name_, 'ACCOUNTING_YEAR',   newrec_.accounting_year);
   Error_SYS.Check_Not_Null(lu_name_, 'VOUCHER_NO',        newrec_.voucher_no);
   Error_SYS.Check_Not_Null(lu_name_, 'ACCOUNT',           newrec_.account);
   Error_SYS.Check_Not_Null(lu_name_, 'ACCOUNTING_PERIOD', newrec_.accounting_period);
   IF (ledger_id_ IN ('*', '00')) THEN
      -- All Ledger or General Ledger
      Voucher_Row_API.Insert_Row__(newrec_,FALSE);
   ELSIF (ledger_id_ <> '01') AND (public_row_rec_.internal_seq_number IS NOT NULL) THEN
      Internal_Postings_Accrul_API.Insert_Manual_Postings(ledger_id_, newrec_);
   END IF;
   $IF Component_Intled_SYS.INSTALLED $THEN
      function_group_ := Voucher_Type_Detail_API.Get_Function_Group (newrec_.company, newrec_.voucher_type);
      IF (function_group_ ='Z') THEN
         IF Voucher_Type_API.Is_Vou_Type_All_Ledger(newrec_.company, newrec_.voucher_type) = 'TRUE'  THEN   
            -- All Ledger
            Internal_Voucher_Util_Pub_API.Create_Internal_Row(newrec_); 
         END IF;
      ELSE
         IF (Voucher_Type_API.Is_Vou_Type_All_Ledger(newrec_.company, newrec_.voucher_type) = 'TRUE' AND ledger_id_ = '*') THEN
            -- All Ledger
            Internal_Voucher_Util_Pub_API.Create_Internal_Row(newrec_); 
         END IF;
      END IF;
      IF (ledger_id_ NOT IN ('*', '00')) THEN
         -- Internal Ledger
         Internal_Voucher_Util_Pub_API.Create_Row_Internal(newrec_, ledger_id_); 
      END IF; 
   $END
END Create_Voucher_Rows;


PROCEDURE Create_Object_Connections (
   company_         IN VARCHAR2,
   voucher_type_    IN VARCHAR2,
   accounting_year_ IN NUMBER,
   voucher_no_      IN NUMBER )
IS
BEGIN
   Voucher_Row_API.Create_Object_Connection(company_         , 
                                            voucher_type_    ,
                                            accounting_year_ ,
                                            voucher_no_       );
END Create_Object_Connections;


PROCEDURE Create_Object_Connections (
   err_msg_             OUT VARCHAR2,
   project_activity_id_ OUT NUMBER,
   company_             IN  VARCHAR2,
   voucher_type_        IN  VARCHAR2,
   accounting_year_     IN  NUMBER,
   voucher_no_          IN  NUMBER )
IS
BEGIN
   Voucher_Row_API.Create_Object_Connection(err_msg_ ,
                                            project_activity_id_ ,
                                            company_         , 
                                            voucher_type_    ,
                                            accounting_year_ ,
                                            voucher_no_       );
END Create_Object_Connections; 


PROCEDURE Complete_Voucher (
   key_rec_     OUT PublicKeyRec,
   transfer_id_ IN  VARCHAR2 )
IS
   company_                VARCHAR2(20);
   voucher_type_           VARCHAR2(3);
   automatic_              VARCHAR2(1);   
BEGIN
   company_      := substr(transfer_id_,INSTR(transfer_id_,'$',1,2)+1,(INSTR(transfer_id_,'$',1,3)-1)-INSTR(transfer_id_,'$',1,2));
   voucher_type_ := substr(transfer_id_,INSTR(transfer_id_,'$',1,4)+1,(INSTR(transfer_id_,'$',1,5)-1)-INSTR(transfer_id_,'$',1,4));


   automatic_ := Voucher_Type_API.Check_Automatic(company_, voucher_type_); 

    
   Voucher_API.Complete_Voucher__( key_rec_       ,
                                   transfer_id_   ,
                                   company_       ,
                                   voucher_type_  ,
                                   automatic_     ,
                                   FALSE           );

END Complete_Voucher;


FUNCTION Get_Fictive_Voucher_No (
   transfer_id_ IN VARCHAR2 ) RETURN NUMBER
IS
BEGIN
   RETURN TO_NUMBER(substr(transfer_id_,INSTR(transfer_id_,'$',1,5)+1,FINANCE_LIB_API.Fin_Length(transfer_id_)));
END Get_Fictive_Voucher_No;


PROCEDURE Get_Head_Info (
   company_           IN OUT VARCHAR2,
   voucher_type_      IN OUT VARCHAR2,
   accounting_year_   IN OUT NUMBER,
   accounting_period_ IN OUT NUMBER,
   voucher_no_        IN OUT NUMBER,
   voucher_date_      IN OUT DATE,
   transfer_id_       IN     VARCHAR2 )
IS
BEGIN
   Voucher_API.Get_Head_Info__(  company_,
                                 voucher_type_,
                                 accounting_year_,
                                 accounting_period_,
                                 voucher_no_,
                                 voucher_date_,
                                 transfer_id_);                                       
END Get_Head_Info;


PROCEDURE Check_Curr_Info_For_Company(
   found_                   OUT VARCHAR2,
   company_                 IN  VARCHAR2,
   currency_code_           IN  VARCHAR2,
   para_curr_round_changed_ IN  VARCHAR2 )
IS
   CURSOR curr_info_in_hold_table IS
      SELECT vrt.currency_code, 
             vrt.third_currency_debit_amount, 
             vrt.third_currency_credit_amount
      FROM   voucher_tab vt, 
             voucher_row_tab vrt
      WHERE  vt.company         = vrt.company
      AND    vt.accounting_year = vrt.accounting_year
      AND    vt.voucher_no      = vrt.voucher_no
      AND    vt.voucher_type    = vrt.voucher_type
      AND    vt.company         = company_
      AND    vt.voucher_updated = 'N';
   acc_curr_code_ company_finance_tab.currency_code%TYPE;       
BEGIN
   found_ := 'FALSE';
   acc_curr_code_ := Currency_Code_API.Get_Currency_Code(company_);
   FOR get_currency_info_ IN curr_info_in_hold_table LOOP
      IF (get_currency_info_.currency_code = currency_code_) THEN
         found_ := 'TRUE';
         EXIT;
      ELSIF (para_curr_round_changed_ = 'TRUE') THEN
         IF (get_currency_info_.third_currency_debit_amount > 0) OR (get_currency_info_.third_currency_credit_amount > 0) THEN
            found_ := 'TRUE';
            EXIT;
         ELSE
            found_ := 'FALSE';   
         END IF;   
      ELSIF (currency_code_ = acc_curr_code_) THEN
         found_ := 'TRUE';
         EXIT;
      ELSE
         found_ := 'FALSE';
      END IF;
   END LOOP;         
END Check_Curr_Info_For_Company;


PROCEDURE Create_Reverse_Voucher (
   reversal_voucher_no_   IN OUT NUMBER,
   company_               IN VARCHAR2,
   voucher_no_            IN NUMBER,
   accounting_year_       IN NUMBER,
   voucher_type_          IN VARCHAR2,
   reversal_voucher_date_ IN DATE     DEFAULT NULL,
   reversal_acc_year_     IN NUMBER   DEFAULT NULL,
   reversal_acc_period_   IN NUMBER   DEFAULT NULL,
   reversal_user_group_   IN VARCHAR2 DEFAULT NULL,
   reversal_voucher_type_ IN VARCHAR2 DEFAULT NULL,
   rollback_voucher_      IN VARCHAR2 DEFAULT NULL )
IS
BEGIN
   Voucher_API.Reverse_Voucher__(reversal_voucher_no_,
                                 company_,
                                 voucher_no_,
                                 accounting_year_,
                                 voucher_type_,
                                 reversal_voucher_date_,
                                 reversal_acc_year_,
                                 reversal_acc_period_,
                                 reversal_user_group_,
                                 reversal_voucher_type_,
                                 rollback_voucher_);
END Create_Reverse_Voucher;


@UncheckedAccess
FUNCTION Is_Project_Vouchers_Updated (
   company_          IN VARCHAR2,
   code_part_        IN VARCHAR2,
   code_part_value_  IN VARCHAR2 ) RETURN VARCHAR2
IS
   CURSOR chk_exist IS
      SELECT 1 
      FROM   voucher_tab v,
             voucher_row_tab vr
      WHERE  v.company           = company_
      AND    v.company           = vr.company
      AND    v.accounting_year   = vr.accounting_year
      AND    v.accounting_period = vr.accounting_period
      AND    v.voucher_no        = vr.voucher_no 
      AND    v.voucher_type      = vr.voucher_type
      AND    v.voucher_updated   =  'N'
      AND    DECODE (code_part_,  'A' , account,
                                  'B' , code_b,
                                  'C' , code_c,
                                  'D' , code_d,
                                  'E' , code_e,
                                  'F' , code_f,
                                  'G' , code_g,
                                  'H' , code_h,
                                  'I' , code_i,
                                  'J' , code_j ) = code_part_value_;
   dummy_   NUMBER;
BEGIN
   OPEN chk_exist;
   FETCH chk_exist INTO dummy_;
   IF (chk_exist%FOUND) THEN
      CLOSE chk_exist;
      RETURN 'FALSE';
   END IF;
   CLOSE chk_exist;
   RETURN 'TRUE';
END Is_Project_Vouchers_Updated;




PROCEDURE Adjust_Multi_Comp_Vou_Row (
   transfer_id_   IN VARCHAR2 )
IS
   attr_                 VARCHAR2(2000);
   ledger_id_            VARCHAR2(10);
   company_              VARCHAR2(20);
   voucher_type_         VARCHAR2(3);
   accounting_year_      NUMBER;
   accounting_period_    NUMBER;
   fictive_voucher_no_   NUMBER;
   debet_amount_         NUMBER;
   credit_amount_        NUMBER;
   sum_debet_amount_     NUMBER;
   sum_credit_amount_    NUMBER;
   row_no_               NUMBER;
   dom_balance_          NUMBER := 0;  
   voucher_date_         DATE;
   sum_debit_par_amount_   NUMBER;
   sum_credit_par_amount_  NUMBER;
   debit_par_amount_       NUMBER;
   credit_par_amount_      NUMBER;
   parallel_balance_       NUMBER;

   CURSOR get_amt_sum IS
      SELECT SUM(debet_amount),
             SUM(credit_amount),
             SUM(third_currency_debit_amount),
             SUM(third_currency_credit_amount)
      FROM   voucher_row_tab
      WHERE  transfer_id = transfer_id_; 

   CURSOR get_vourow IS
      SELECT v.debet_amount, 
             v.credit_amount, 
             v.third_currency_debit_amount,
             v.third_currency_credit_amount,
             v.row_no
      FROM   voucher_row_tab v, 
             accounting_code_part_value_tab a
      WHERE  v.transfer_id         = transfer_id_
      AND    v.company             = a.company
      AND    v.account             = a.code_part_value 
      AND    a.code_part           = 'A'
      AND    a.logical_account_type IN ('C','A','R','S','L')
      AND    v.trans_code IN ('MANUAL', 'EXTERNAL')
      ORDER BY v.row_no DESC;
BEGIN
   OPEN  get_amt_sum;
   FETCH get_amt_sum INTO sum_debet_amount_, sum_credit_amount_, sum_debit_par_amount_, sum_credit_par_amount_;
   CLOSE get_amt_sum;
   IF nvl(sum_debet_amount_,0) != nvl(sum_credit_amount_,0) THEN
      dom_balance_ := nvl(sum_debet_amount_,0) - nvl(sum_credit_amount_,0);
   END IF;
   IF NVL(sum_debit_par_amount_,0) != NVL(sum_credit_par_amount_,0) THEN 
      parallel_balance_ := NVL(sum_debit_par_amount_,0) - NVL(sum_credit_par_amount_,0);
   END IF;
   IF (dom_balance_ != 0 OR parallel_balance_ != 0) THEN
      company_        := substr(transfer_id_,INSTR(transfer_id_,'$',1,2)+1,(INSTR(transfer_id_,'$',1,3)-1)-INSTR(transfer_id_,'$',1,2));
      voucher_type_   := substr(transfer_id_,INSTR(transfer_id_,'$',1,4)+1,(INSTR(transfer_id_,'$',1,5)-1)-INSTR(transfer_id_,'$',1,4));
      ledger_id_      := Voucher_Type_API.Get_Ledger_Id(company_, voucher_type_);
      IF (Voucher_Type_API.Get_Voucher_Group(company_, voucher_type_) != 'D') THEN
         RETURN;
      END IF;
      IF (ledger_id_ IS NULL) THEN
         ledger_id_   := Voucher_Type_API.Get_Ledger_Id(company_, voucher_type_);
      END IF;
      IF ledger_id_ IN ('*', '00') THEN
         -- All Ledger or General Ledger
         Get_Head_Info( company_,
                        voucher_type_,
                        accounting_year_,
                        accounting_period_,
                        fictive_voucher_no_,
                        voucher_date_,
                        transfer_id_ );
         OPEN  get_vourow;
         FETCH get_vourow INTO debet_amount_, credit_amount_, debit_par_amount_, credit_par_amount_, row_no_;
         IF get_vourow%FOUND THEN
            IF dom_balance_ != 0 THEN 
               IF (debet_amount_ IS NOT NULL) THEN  
                  Client_SYS.Add_To_Attr( 'DEBET_AMOUNT', (debet_amount_ - dom_balance_), attr_);
               ELSE   
                  Client_SYS.Add_To_Attr( 'CREDIT_AMOUNT', (credit_amount_ + dom_balance_), attr_);
               END IF;
            END IF;
            IF parallel_balance_ != 0 THEN 
               IF (debit_par_amount_ IS NOT NULL) THEN  
                  Client_SYS.Add_To_Attr( 'THIRD_CURRENCY_DEBIT_AMOUNT',  (debit_par_amount_ - parallel_balance_),  attr_);
               ELSE   
                  Client_SYS.Add_To_Attr( 'THIRD_CURRENCY_CREDIT_AMOUNT', (credit_par_amount_ + parallel_balance_), attr_);
               END IF;
            END IF;
            Voucher_Row_API.Modify_Row(attr_,
                                       company_,
                                       voucher_type_,
                                       accounting_year_,
                                       fictive_voucher_no_,
                                       row_no_);
         END IF;
         CLOSE get_vourow;
      END IF;
   END IF;
END Adjust_Multi_Comp_Vou_Row;


@UncheckedAccess
FUNCTION Get_Acc_Journal(
   company_              IN VARCHAR2,
   voucher_type_         IN VARCHAR2 ) RETURN VARCHAR2
IS
BEGIN
   $IF Component_Genled_SYS.INSTALLED $THEN
      RETURN Def_Acc_Journal_Item_API.Get_Acc_Journal(company_, voucher_type_);
   $ELSE
      RETURN NULL;
   $END
END Get_Acc_Journal;

-- Bug 128457,begin.
@UncheckedAccess
FUNCTION Non_Manual_Vou_Row_Exist(
   company_          IN VARCHAR2, 
   accounting_year_  IN NUMBER,    
   voucher_type_     IN VARCHAR2,
   voucher_no_       IN NUMBER) RETURN VARCHAR2
IS
   CURSOR row_exist IS
      SELECT 1
      FROM Voucher_Row_Tab 
      WHERE company        = company_
      AND  accounting_year = accounting_year_
      AND voucher_type     = voucher_type_
      AND voucher_no       = voucher_no_
      AND trans_code       != 'MANUAL';
   
   ndummy_   NUMBER;
   
BEGIN
   OPEN row_exist;
   FETCH row_exist INTO ndummy_;
   IF (row_exist%FOUND) THEN
      CLOSE row_exist;
      RETURN 'TRUE';
   END IF;
   CLOSE row_exist;
   RETURN 'FALSE';
END Non_Manual_Vou_Row_Exist;

@UncheckedAccess
FUNCTION Disable_Interim_Voucher(
   company_          IN VARCHAR2, 
   accounting_year_  IN NUMBER,    
   voucher_type_     IN VARCHAR2,
   voucher_no_       IN NUMBER,
   voucher_group_    IN VARCHAR2) RETURN VARCHAR2
IS
   CURSOR row_exist IS
      SELECT 1
      FROM Voucher_Row
      WHERE company        = company_
      AND  accounting_year = accounting_year_
      AND voucher_type     = voucher_type_
      AND voucher_no       = voucher_no_
      AND ( period_allocation = 'TRUE' OR 
            correction = 'TRUE' OR
            (trans_code NOT IN ('MANUAL','AP1','AP2', 'AP3', 'AP4') AND NOT(trans_code = 'EXTERNAL' AND voucher_group_ IN ('M','K','Q'))));
   
   ndummy_   NUMBER;
   
BEGIN
   OPEN row_exist;
   FETCH row_exist INTO ndummy_;
   IF (row_exist%FOUND) THEN
      CLOSE row_exist;
      RETURN 'TRUE';
   END IF;
   CLOSE row_exist;
   RETURN 'FALSE';
END Disable_Interim_Voucher;
-- Bug 128457,end.