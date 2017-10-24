-----------------------------------------------------------------------------
--
--  Logical unit: CurrencyAmount
--  Component:    ACCRUL
--
--  IFS Developer Studio Template Version 3.0
--
--  Date    Sign    History
--  ------  ------  ---------------------------------------------------------
--  XXXXXX  XXXX   Created
--  970718  SLKO   Converted to Foundation 1.2.2d
--  980127  SLKO   Converted to Foundation1 2.0.0
--  980220  PICZ   Added Get_Rounded_Amount
--  981030  PRASI  Calc_Currency_Amount,Calc_Currency_Rate,Calc_Amount,
--                 Calculate_Currency_Rate  has been modified to cater for Triangulation.
--  990312  MANG   Add New Public Function called 'Calc_Trans_Amount'
--  000912  HiMu   Added General_SYS.Init_Method
--  001005  prtilk BUG # 15677  Checked General_SYS.Init_Method
--  010822  JeGu   Bug #23726 Modified Calc_Currency_Amount, Calc_Amount and Calc_Currency_Rate
--  040323  Gepelk 2004 SP1 Merge
--  040920  reanpl  FIJP344 Japanese Tax Rounding, added Round_Amount
--  061122  ThWilk  LCS Merge 58755,Added method Calc_Unrounded_Amount.
--  080116  Makrlk Bug 69559, Added a OUT parameter to Calc_Unrounded_Amount
--  080825  VADELK Bug 76042, Corrected. In Calc_Unrounded_Amount accounting currency amount is rounded
--  080825         according to the rounding value specified for the accounting currency.
--  100803  Clstlk SAPSUCKER, DF-34 Set IFs Currency as the format of amount fields.
--                 Added Calc_Third_Curr_Round_Amt.
--  120806  MAAYLK Bug 101320, Changed Calc_Unrounded_Amount(), used the public rec of currency_code_api
--  121123  Janblk DANU-122, Parallel currency implementation   
--  121128  ovjose DANU-264 New interfaces Calc_Parallel_Amt_Rate, Calc_Parallel_Amt_Rate_Round, Calc_Parallel_Curr_Amt_Round
--  121207  ovjose DANU-264, Removed methods Calc_Third_Curr_Round_Amt, Calculate_Third_Curr_Amount. 
--                 The method cannot be used if transaction currency is based for parallel currency.
--  130311  PRatlk  DANU-593, Added new method Get_Currency_Converted_Amount to be used in Group Consolidation.
--  130703  PratLk  DANU-1500 , Changed Get_Currency_Converted_Amount to a function to improve performance
-----------------------------------------------------------------------------

layer Core;

-------------------- PUBLIC DECLARATIONS ------------------------------------

TYPE ConvertedAmountsRec IS RECORD (
   conv_credit_amount   NUMBER,
   conv_debit_amount    NUMBER,
   conv_balance_amount  NUMBER);

-------------------- PRIVATE DECLARATIONS -----------------------------------


-------------------- LU SPECIFIC IMPLEMENTATION METHODS ---------------------

FUNCTION Calculate_Parallel_Amount___(
   parallel_base_       IN VARCHAR2,
   trans_amount_        IN NUMBER,
   acc_amount_          IN NUMBER,
   currency_rate_       IN NUMBER,
   conversion_factor_   IN NUMBER,
   inverted_            IN VARCHAR2) RETURN NUMBER
IS
   parallel_amount_base_      NUMBER;
   rate_                      NUMBER;
BEGIN
   IF (parallel_base_ = 'TRANSACTION_CURRENCY') THEN
      parallel_amount_base_ := trans_amount_; 
      IF (inverted_= 'TRUE') THEN
         rate_ := 1 / (currency_rate_ /conversion_factor_);
      ELSE
         rate_ := currency_rate_ / conversion_factor_;
      END IF;
   ELSIF (parallel_base_ = 'ACCOUNTING_CURRENCY') THEN
      parallel_amount_base_ := acc_amount_;
      IF (inverted_= 'TRUE') THEN
         rate_ := currency_rate_ / conversion_factor_;
      ELSE
         rate_ := 1 / ( currency_rate_ / conversion_factor_ );
      END IF;
   ELSE
      -- Invalid parallel base then return parallel_amount_base_ which is null at this point
      RETURN parallel_amount_base_;
   END IF;
   RETURN (parallel_amount_base_ * rate_);
END Calculate_Parallel_Amount___;


-------------------- LU SPECIFIC PRIVATE METHODS ----------------------------

-------------------- LU SPECIFIC PROTECTED METHODS --------------------------

-------------------- LU SPECIFIC PUBLIC METHODS -----------------------------

PROCEDURE Calc_Currency_Amount (
   currency_amount_    OUT NUMBER,
   company_            IN  VARCHAR2,
   currency_code_      IN  VARCHAR2,
   currency_rate_      IN  NUMBER,
   amount_             IN  NUMBER,
   division_factor_    IN  NUMBER DEFAULT NULL,
   base_currency_code_ IN  VARCHAR2 DEFAULT 'XXX' )
IS

   curr_amount_       NUMBER;
   conv_factor_       NUMBER;
   currency_rounding_ NUMBER;
   divisor_           NUMBER;
   base_currency_     VARCHAR2(3);
   decimals_in_rate_  NUMBER;
BEGIN
   IF (NVL(base_currency_code_,'XXX') != 'XXX') THEN
      base_currency_    := base_currency_code_;
   ELSE
      base_currency_    := Company_Finance_Api.Get_Currency_Code(company_);
   END IF;
   Currency_Code_API.Get_Currency_Code_Attributes (conv_factor_,
                                                   currency_rounding_,
                                                   decimals_in_rate_,
                                                   company_,
                                                   currency_code_);
   IF (division_factor_ IS NOT NULL) THEN
      divisor_ := division_factor_;
   ELSE
      divisor_ := conv_factor_;
   END IF;
   IF Currency_Code_API.Get_Inverted(company_, base_currency_)= 'TRUE' THEN
      curr_amount_ := amount_ * ( currency_rate_ / divisor_ );
      currency_amount_ := round(curr_amount_, currency_rounding_);
   ELSE
      curr_amount_ := amount_ / ( currency_rate_ / divisor_ );
      currency_amount_ := round(curr_amount_, currency_rounding_);
   END IF;
END Calc_Currency_Amount;


PROCEDURE Calc_Currency_Rate (
   currency_rate_      OUT NUMBER,
   company_            IN  VARCHAR2,
   currency_code_      IN  VARCHAR2,
   amount_             IN  NUMBER,
   currency_amount_    IN  NUMBER,
   base_currency_code_ IN  VARCHAR2 DEFAULT 'XXX' )
IS
   curr_rate_         NUMBER;
   decimals_in_rate_  NUMBER;
   conv_factor_       NUMBER;
   currency_rounding_ NUMBER;
   base_currency_     VARCHAR2(3);
BEGIN
   IF (NVL(base_currency_code_,'XXX') != 'XXX') THEN
      base_currency_    := base_currency_code_;
   ELSE
      base_currency_    := Company_Finance_Api.Get_Currency_Code(company_);
   END IF;
   Currency_Code_API.Get_Currency_Code_Attributes (conv_factor_,
                                                   currency_rounding_,
                                                   decimals_in_rate_,
                                                   company_,
                                                   currency_code_);
   IF (currency_amount_ = 0 OR currency_amount_ IS NULL) THEN
      currency_rate_ := 0;
   ELSIF (amount_ =0 OR amount_ IS NULL) THEN
      currency_rate_ := 0;
   ELSIF Currency_Code_API.Get_Inverted(company_, base_currency_)= 'TRUE' THEN
      curr_rate_ := ( currency_amount_ / amount_  ) * conv_factor_ ;
      currency_rate_ := round(curr_rate_, decimals_in_rate_);
   ELSE
      curr_rate_ := ( amount_ / currency_amount_ ) * conv_factor_ ;
      currency_rate_ := round(curr_rate_, decimals_in_rate_);
   END IF;
END Calc_Currency_Rate;


PROCEDURE Calc_Amount (
   amount_             OUT NUMBER,
   company_            IN  VARCHAR2,
   currency_code_      IN  VARCHAR2,
   currency_rate_      IN  NUMBER,
   currency_amount_    IN  NUMBER,
   division_factor_    IN  NUMBER DEFAULT NULL,
   base_currency_code_ IN  VARCHAR2 DEFAULT 'XXX' )
IS
   amt_               NUMBER;
   conv_factor_       NUMBER;
   currency_rounding_ NUMBER;
   divisor_           NUMBER;
   base_currency_     VARCHAR2(3);
   decimals_in_rate_  NUMBER;
BEGIN
   IF (NVL(base_currency_code_,'XXX') != 'XXX') THEN
      base_currency_    := base_currency_code_;
   ELSE
      base_currency_    := Company_Finance_Api.Get_Currency_Code(company_);
   END IF;
   Currency_Code_API.Get_Currency_Code_Attributes (conv_factor_,
                                                   currency_rounding_,
                                                   decimals_in_rate_,
                                                   company_,
                                                   currency_code_);
   IF (division_factor_ IS NOT NULL) THEN
      divisor_ := division_factor_;
   ELSE
      divisor_ := conv_factor_;
   END IF;
   IF Currency_Code_API.Get_Inverted( company_, base_currency_ ) = 'TRUE' THEN
      amt_ := currency_amount_ * ( 1 / ( currency_rate_ / divisor_ ) );
      amount_ := round( amt_,currency_rounding_ );
   ELSE
      amt_ := currency_amount_ * ( currency_rate_ / divisor_ );
      amount_ := round(amt_, currency_rounding_);
   END IF;
END Calc_Amount;


PROCEDURE Calculate_Amount (
   amount_             OUT NUMBER,
   company_            IN  VARCHAR2,
   currency_code_      IN  VARCHAR2,
   currency_rate_      IN  NUMBER,
   currency_amount_    IN  NUMBER,
   division_factor_    IN  NUMBER DEFAULT NULL,
   base_currency_code_ IN  VARCHAR2 DEFAULT 'XXX' )
IS
   amt_               NUMBER;
   conv_factor_       NUMBER;
   currency_rounding_ NUMBER;
   divisor_           NUMBER;
   base_currency_     VARCHAR2(3);
   decimals_in_rate_  NUMBER;
BEGIN
   IF (NVL(base_currency_code_,'XXX') != 'XXX') THEN
      base_currency_    := base_currency_code_;
   ELSE
      base_currency_    := Company_Finance_Api.Get_Currency_Code(company_);
   END IF;
   Currency_Code_API.Get_Currency_Code_Attributes (conv_factor_,
                                                   currency_rounding_,
                                                   decimals_in_rate_,
                                                   company_,
                                                   currency_code_);

   IF (division_factor_ IS NOT NULL) THEN
      divisor_ := division_factor_;
   ELSE
      divisor_ := conv_factor_;
   END IF;
   IF Currency_Code_API.Get_Inverted( company_, base_currency_ ) = 'TRUE' THEN
      amt_ := currency_amount_ * currency_rate_ ;
      amount_ := round( amt_,currency_rounding_ );
   ELSE
      amt_ := currency_amount_ * ( currency_rate_ / divisor_ );
      amount_ := round(amt_, currency_rounding_);
   END IF;
END Calculate_Amount;


FUNCTION Get_Rounded_Amount (
   company_        IN VARCHAR2,
   currency_code_  IN VARCHAR2,
   amount_         IN NUMBER ) RETURN NUMBER
IS
   conv_factor_       NUMBER;
   currency_rounding_ NUMBER;
   decimals_in_rate_  NUMBER;
BEGIN
   Currency_Code_API.Get_Currency_Code_Attributes (conv_factor_,
                                                   currency_rounding_,
                                                   decimals_in_rate_,
                                                   company_,
                                                   currency_code_);
   RETURN round(amount_,currency_rounding_);
END Get_Rounded_Amount;


@UncheckedAccess
FUNCTION Calculate_Currency_Rate (
   company_            IN  VARCHAR2,
   currency_code_      IN  VARCHAR2,
   amount_             IN  NUMBER,
   currency_amount_    IN  NUMBER,
   base_currency_code_ IN  VARCHAR2 DEFAULT 'XXX' ) RETURN NUMBER
IS
   curr_rate_         NUMBER;
   decimals_in_rate_  NUMBER;
   conv_factor_       NUMBER;
   currency_rate_     NUMBER;
   base_currency_     VARCHAR2(3);
BEGIN
   IF (NVL(base_currency_code_,'XXX') != 'XXX') THEN
      base_currency_    := base_currency_code_;
   ELSE
      base_currency_    := Company_Finance_Api.Get_Currency_Code(company_);
   END IF;
   decimals_in_rate_ := Currency_Code_API.Get_No_Of_Decimals_In_Rate (company_,
                                                                      currency_code_);
   conv_factor_      := Currency_Code_API.Get_Conversion_Factor (company_,
                                                                 currency_code_);
   IF (currency_amount_ = 0 OR currency_amount_ IS NULL) THEN
      currency_rate_ :=0;
   ELSIF (amount_ = 0 OR amount_ IS NULL) THEN
      currency_rate_ :=0;
   ELSIF Currency_Code_API.Get_Inverted(company_, base_currency_)= 'TRUE' THEN
      curr_rate_ := ( currency_amount_ / amount_  ) * conv_factor_ ;
      currency_rate_ := round(curr_rate_, decimals_in_rate_);
   ELSE
      curr_rate_ := ( amount_ / currency_amount_ ) * conv_factor_ ;
      currency_rate_ := round(curr_rate_, decimals_in_rate_);
   END IF;
   RETURN  currency_rate_;
END Calculate_Currency_Rate;




-- Calculate_Parallel_Curr_Amount
--   Function that returns parallel currency amount based on the amount in either transaction currency or accounting currency
--   Input parameters:
--   company_:               Company for which data should be returned
--   trans_date_:            Date for which to get the rate and calculate the parallel currency amount
--   acc_curr_amount_:       Amount in accounting currency
--   trans_curr_amount_:     Amount in transaction currency
--   acc_curr_code_:         Accounting currency for the company
--   trans_curr_code_:       Transaction Currency
--   parallel_curr_type_:    The currency type to find the rate. Could for example be retreived by Company_Finance_API.Get_Parallel_Rate_Type if it is not defined from client or in flow.
--   parallel_curr_code_:    Parallel Currency for the company
--   parallel_base_:         Base for calculating parallel currency (TRANSACTION_CURRENCY or ACCOUNTING_CURRENCY)
--   is_acc_curr_emu_:       If Accounting currency is a valid EMU currency or not
--   is_parallel_curr_emu_:  If Parallel currency is a valid EMU currency or not
--   curr_type_rel_to_:      If the currency type is related to CUSTOMER/SUPPLIER or default type for parallel currency (see parallel_curr_type_ parameter)
FUNCTION Calculate_Parallel_Curr_Amount (
   company_                IN  VARCHAR2,
   trans_date_             IN  DATE,
   acc_curr_amount_        IN  NUMBER,
   trans_curr_amount_      IN  NUMBER,
   acc_curr_code_          IN  VARCHAR2,
   trans_curr_code_        IN  VARCHAR2,
   parallel_curr_type_     IN  VARCHAR2 DEFAULT NULL,
   parallel_curr_code_     IN  VARCHAR2 DEFAULT NULL,
   parallel_base_          IN  VARCHAR2 DEFAULT NULL,
   is_acc_curr_emu_        IN  VARCHAR2 DEFAULT NULL,
   is_parallel_curr_emu_   IN  VARCHAR2 DEFAULT NULL,
   curr_type_rel_to_       IN  VARCHAR2 DEFAULT NULL) RETURN NUMBER
IS
   rate_                   NUMBER;
   conv_factor_            NUMBER;
   inverted_               VARCHAR2(5);
   tmp_parallel_curr_code_ VARCHAR2(3) := parallel_curr_code_;
   parallel_amount_        NUMBER;
   tmp_parallel_base_      VARCHAR2(25):= parallel_base_;
   tmp_parallel_curr_type_ VARCHAR2(10) := parallel_curr_type_;
BEGIN
   IF (tmp_parallel_curr_code_ IS NULL) THEN
      tmp_parallel_curr_code_ := Company_Finance_API.Get_Parallel_Acc_Currency(company_);
   END IF;

   IF (tmp_parallel_curr_code_ IS NOT NULL) THEN
      IF (tmp_parallel_curr_code_ = acc_curr_code_) THEN
         -- if the parallel currency is the same as accounting currency, the acc curr amount will be used
         parallel_amount_ := acc_curr_amount_;
      ELSIF (tmp_parallel_curr_code_ = trans_curr_code_) THEN
         -- if the parallel currency is the same as transaction currency, the trans curr amount will be used
         parallel_amount_ := trans_curr_amount_;
      ELSE
         -- if the parallel curr is different from accounting and transaction curr, do the calculation
         IF (tmp_parallel_base_ IS NULL) THEN
            tmp_parallel_base_ := Company_Finance_API.Get_Parallel_Base_Db(company_);
         END IF;
         IF (tmp_parallel_curr_type_ IS NULL) THEN
            -- get the currency type, either the default parallel type or based on Buy/Sell rate type
            -- The interface with two parameters does not yet exist, should be added.
            /*
            tmp_currency_type_ := Company_Finance_API.Get_Parallel_Rate_Type(company_,
                                                                             curr_type_rel_to_);
            */
            -- get the default parallel curr rate type for company
	         tmp_parallel_curr_type_ := Company_Finance_API.Get_Parallel_Rate_Type(company_);
         END IF; 

         -- If the base amount for the calculation is 0 then return 0.
         IF (tmp_parallel_base_ = 'TRANSACTION_CURRENCY') THEN
            IF (trans_curr_amount_ = 0) THEN
               RETURN 0;
            END IF;
         ELSIF (tmp_parallel_base_ = 'ACCOUNTING_CURRENCY') THEN
            IF (acc_curr_amount_ = 0) THEN
               RETURN 0;
            END IF;
         END IF;
         
         Currency_Rate_API.Get_Parallel_Currency_Rate(rate_,
                                                      conv_factor_,
                                                      inverted_,
                                                      company_,
                                                      trans_curr_code_,
                                                      trans_date_,
                                                      tmp_parallel_curr_type_,
                                                      tmp_parallel_base_,
                                                      acc_curr_code_,
                                                      tmp_parallel_curr_code_,
                                                      is_acc_curr_emu_,
                                                      is_parallel_curr_emu_);

         parallel_amount_ := Calculate_Parallel_Amount___(tmp_parallel_base_,
                                                          trans_curr_amount_,
                                                          acc_curr_amount_,
                                                          rate_,
                                                          conv_factor_,
                                                          inverted_);
      END IF;
   ELSE
      -- Parallel Currency is not used in the company, return NULL
      parallel_amount_ := NULL;
   END IF;
   RETURN parallel_amount_;
END Calculate_Parallel_Curr_Amount;


@UncheckedAccess
FUNCTION Calculate_To_Euro (
   company_       IN VARCHAR2,
   currency_code_ IN VARCHAR2,
   date_          IN DATE,
   amount_        IN NUMBER ) RETURN NUMBER
IS
   def_curr_type_        VARCHAR2(10);
   rate_                 NUMBER;
   currency_rounding_    NUMBER;
   conv_factor_          NUMBER;
BEGIN
   def_curr_type_     := Currency_Type_Api.Get_Default_Type( company_ );
   currency_rounding_ := Currency_Code_Api.Get_Currency_Rounding(company_, 'EUR');
   rate_              := Currency_Rate_Api.Get_Currency_Rate(company_,'EUR',def_curr_type_, date_);
   conv_factor_       := Currency_Rate_Api.Get_Conv_Factor(company_,'EUR',def_curr_type_, date_);
   RETURN round((amount_ / (rate_ / conv_factor_)), currency_rounding_ );
END Calculate_To_Euro;




@UncheckedAccess
FUNCTION Calc_Trans_Amount (
   company_         IN VARCHAR2,
   base_curr_code_  IN VARCHAR2,
   base_amount_     IN NUMBER,
   trans_curr_code_ IN VARCHAR2,
   trans_date_      IN DATE ) RETURN NUMBER
IS
   curr_rate_      NUMBER;
   curr_type_      VARCHAR2(10);
   trans_amount_   NUMBER;
   rounding_       NUMBER;
BEGIN
   curr_type_    := Currency_Type_Api.Get_Default_Type(company_);
   curr_rate_    := Currency_Rate_Api.Get_Currency_Rate_Base( company_, trans_curr_code_, base_curr_code_, curr_type_, trans_date_ );
   trans_amount_ := base_amount_ / curr_rate_;
   rounding_     := Currency_Code_Api.Get_Currency_Rounding(company_, trans_curr_code_);
   RETURN Round(trans_amount_ , rounding_);
END Calc_Trans_Amount;




@UncheckedAccess
FUNCTION Round_Amount (
   rounding_method_db_  IN VARCHAR2,
   amount_              IN NUMBER,
   decimals_            IN NUMBER) RETURN NUMBER
IS
   pow_             NUMBER;
BEGIN

   IF (amount_ IS NULL OR amount_ = 0) THEN
      RETURN 0;
   END IF;

   IF    rounding_method_db_ = 'ROUND_NEAREST' THEN
      RETURN ROUND(amount_, decimals_);

   ELSIF rounding_method_db_ = 'ROUND_UP' THEN
      pow_ := POWER( 10, decimals_);
      RETURN CEIL( ABS( amount_) * pow_) / pow_ * SIGN( amount_);

   ELSIF rounding_method_db_ = 'ROUND_DOWN' THEN
      RETURN TRUNC( amount_, decimals_);

   ELSE
      RETURN(amount_);
   END IF;
END Round_Amount;




PROCEDURE Calc_Unrounded_Amount (
   not_round_amnt_     OUT    NUMBER,
   amount_             OUT NUMBER,
   diff_amount_        IN OUT NUMBER,
   company_            IN VARCHAR2,
   currency_code_      IN VARCHAR2,
   currency_rate_      IN NUMBER,
   currency_amount_    IN NUMBER,
   division_factor_    IN NUMBER DEFAULT NULL,
   base_currency_code_ IN VARCHAR2 DEFAULT 'XXX' )
IS
   orig_amount_       NUMBER;
   conv_factor_       NUMBER;
   currency_rounding_ NUMBER;
   divisor_           NUMBER;
   base_currency_     VARCHAR2(3);
   decimals_in_rate_  NUMBER;
   base_currency_rounding_ NUMBER;
   -- Bug 101320, Begin
   currency_code_rec_ Currency_Code_API.Public_Rec;
   -- Bug 101320, End
BEGIN
   IF (NVL(base_currency_code_,'XXX') != 'XXX') THEN
      base_currency_    := base_currency_code_;
   ELSE
      base_currency_    := Company_Finance_Api.Get_Currency_Code(company_);
   END IF;
   -- Bug 101320, Begin, used the public rec of currency_code_api after changes to the public rec
   currency_code_rec_ := Currency_Code_API.Get(company_,
                                               currency_code_);
                                               
   conv_factor_       := currency_code_rec_.conv_factor;
   currency_rounding_ := currency_code_rec_.currency_rounding;
   decimals_in_rate_  := currency_code_rec_.decimals_in_rate;
   -- Bug 101320, End

   base_currency_rounding_ := Currency_Code_Api.Get_Currency_Rounding(company_ , base_currency_);

   IF (division_factor_ IS NOT NULL) THEN
      divisor_ := division_factor_;
   ELSE
      divisor_ := conv_factor_;
   END IF;
   IF Currency_Code_API.Get_Inverted( company_, base_currency_ ) = 'TRUE' THEN
      orig_amount_ := currency_amount_ * ( 1 / ( currency_rate_ / divisor_ )) + diff_amount_;
      amount_ := round( orig_amount_,base_currency_rounding_ );
   ELSE
      orig_amount_ := currency_amount_ * ( currency_rate_ / divisor_ ) + diff_amount_;
      amount_ := round( orig_amount_,base_currency_rounding_ );
   END IF;
   diff_amount_    := orig_amount_ - amount_;
   not_round_amnt_ := orig_amount_;
   
END Calc_Unrounded_Amount;


-- Calc_Parallel_Curr_Amt_Round
--   Function that returns the rounded parallel currency amount (based on the amount in either transaction currency or accounting currency)
--   Input parameters:
--   company_:               Company for which data should be returned
--   trans_date_:            Date for which to get the rate and calculate the parallel currency amount
--   acc_curr_amount_:       Amount in accounting currency
--   trans_curr_amount_:     Amount in transaction currency
--   acc_curr_code_:         Accounting currency for the company
--   trans_curr_code_:       Transaction Currency
--   parallel_curr_type_:    The currency type to find the rate. Could for example be retreived by Company_Finance_API.Get_Parallel_Rate_Type if it is not defined from client or in flow.
--   parallel_curr_code_:    Parallel Currency for the company
--   parallel_base_:         Base for calculating parallel currency (TRANSACTION_CURRENCY or ACCOUNTING_CURRENCY)
--   is_acc_curr_emu_:       If Accounting currency is a valid EMU currency or not
--   is_parallel_curr_emu_:  If Parallel currency is a valid EMU currency or not
--   curr_type_rel_to_:      If the currency type is related to CUSTOMER/SUPPLIER or default type for parallel currency (see parallel_curr_type_ parameter)
--   number_of_dec_in_amt_:  The number of decimals to round the amount to, if not given number of decimals will be taken from the currency
FUNCTION Calc_Parallel_Curr_Amt_Round (
   company_                IN  VARCHAR2,
   trans_date_             IN  DATE,
   acc_curr_amount_        IN  NUMBER,
   trans_curr_amount_      IN  NUMBER,
   acc_curr_code_          IN  VARCHAR2,
   trans_curr_code_        IN  VARCHAR2,
   parallel_curr_type_     IN  VARCHAR2 DEFAULT NULL,
   parallel_curr_code_     IN  VARCHAR2 DEFAULT NULL,
   parallel_base_          IN  VARCHAR2 DEFAULT NULL,
   is_acc_curr_emu_        IN  VARCHAR2 DEFAULT NULL,
   is_parallel_curr_emu_   IN  VARCHAR2 DEFAULT NULL,
   curr_type_rel_to_       IN  VARCHAR2 DEFAULT NULL,
   number_of_dec_in_amt_   IN  NUMBER DEFAULT NULL) RETURN NUMBER
IS
   tmp_amount_                NUMBER;
   tmp_number_of_dec_in_amt_  NUMBER := number_of_dec_in_amt_;
   tmp_parallel_curr_code_    VARCHAR2(3) := parallel_curr_code_;
BEGIN
   IF (tmp_parallel_curr_code_ IS NULL) THEN
      tmp_parallel_curr_code_ := Company_Finance_API.Get_Parallel_Acc_Currency(company_);
   END IF;
   -- Parallel Currency is not used in the company, return NULL
   IF (tmp_parallel_curr_code_ IS NULL) THEN
      RETURN NULL;
   END IF;
   tmp_amount_ := Calculate_Parallel_Curr_Amount(company_,
                                                 trans_date_,
                                                 acc_curr_amount_,
                                                 trans_curr_amount_,
                                                 acc_curr_code_,
                                                 trans_curr_code_,
                                                 parallel_curr_type_,
                                                 tmp_parallel_curr_code_,
                                                 parallel_base_,
                                                 is_acc_curr_emu_,
                                                 is_parallel_curr_emu_,
                                                 curr_type_rel_to_);
   IF (tmp_number_of_dec_in_amt_ IS NULL) THEN
      tmp_number_of_dec_in_amt_ := NVL(Currency_Code_API.Get_Currency_Rounding (company_,
                                                                                tmp_parallel_curr_code_),
                                       0);
   END IF;
   RETURN ROUND(tmp_amount_, tmp_number_of_dec_in_amt_);
END Calc_Parallel_Curr_Amt_Round;


-- Calc_Parallel_Amt_Rate
--   Function that returns parallel currency amount by passing the rate data to the parallel currency, based on either transaction currency or accounting currency data
--   Input parameters:
--   company_:               Company for which data should be returned
--   acc_curr_amount_:       Amount in accounting currency
--   trans_curr_amount_:     Amount in transaction currency
--   acc_curr_code_:         Accounting currency for the company
--   trans_curr_code_:       Transaction Currency
--   currency_rate_          Rate between the currencies (either between transaction currency and parallel currency or between accounting currency and parallel currency)
--   conversion_factor_      Conversion factor for the currency
--   inverted_               If the rate is inverted or not (TRUE/FALSE)
--   parallel_curr_code_:    Parallel Currency for the company
--   parallel_base_:         Base for calculating parallel currency (TRANSACTION_CURRENCY or ACCOUNTING_CURRENCY)
--   always_calculate_:      For some PPV postings parallel amount is calulated by changing the parallel base to ACCOUNTING_CURRENCY, for postings which have transaction 
--                           currency code equal to parallel currency code and transaction currency amount is zero this parameter tells to calculate parallel amount instead of copying transaction amount to parallel amount.
@UncheckedAccess
FUNCTION Calc_Parallel_Amt_Rate (
   company_                IN  VARCHAR2,
   acc_curr_amount_        IN  NUMBER,
   trans_curr_amount_      IN  NUMBER,
   acc_curr_code_          IN  VARCHAR2,
   trans_curr_code_        IN  VARCHAR2,
   currency_rate_          IN  NUMBER,
   conversion_factor_      IN  NUMBER,
   inverted_               IN  VARCHAR2,
   parallel_curr_code_     IN  VARCHAR2 DEFAULT NULL,
   parallel_base_          IN  VARCHAR2 DEFAULT NULL,
   always_calculate_       IN  VARCHAR2 DEFAULT 'FALSE') RETURN NUMBER
IS
   tmp_parallel_curr_code_ VARCHAR2(3) := parallel_curr_code_;
   parallel_amount_        NUMBER;
   tmp_parallel_base_      VARCHAR2(25):= parallel_base_;
BEGIN
   IF (tmp_parallel_curr_code_ IS NULL) THEN
      tmp_parallel_curr_code_ := Company_Finance_API.Get_Parallel_Acc_Currency(company_);
   END IF;

   IF (tmp_parallel_curr_code_ IS NOT NULL) THEN
      IF (tmp_parallel_base_ IS NULL) THEN
         tmp_parallel_base_ := Company_Finance_API.Get_Parallel_Base_Db(company_);
      END IF;

      IF (tmp_parallel_curr_code_ = acc_curr_code_) THEN
         parallel_amount_ := acc_curr_amount_;
      ELSIF ((tmp_parallel_curr_code_ = trans_curr_code_) AND always_calculate_ = 'FALSE') THEN
         parallel_amount_ := trans_curr_amount_;
      ELSE
         -- if rate is 0 or null then return 0. To avoid division by zero error and null would just return null anyhow
         IF ( (currency_rate_ = 0) OR (currency_rate_ IS NULL) ) THEN
            RETURN 0;
         END IF;
         parallel_amount_ := Calculate_Parallel_Amount___(tmp_parallel_base_,
                                                          trans_curr_amount_,
                                                          acc_curr_amount_,
                                                          currency_rate_,
                                                          conversion_factor_,
                                                          inverted_);
      END IF;
   ELSE
      -- Parallel Currency is not used in the company, return NULL
      parallel_amount_ := NULL;
   END IF;
   RETURN parallel_amount_;
END Calc_Parallel_Amt_Rate;




-- Calc_Parallel_Amt_Rate_Round
--   Function that returns parallel currency amount rounded by passing the rate to the parallel currency, based on either transaction currency or accounting currency data
--   Input parameters:
--   company_:               Company for which data should be returned
--   acc_curr_amount_:       Amount in accounting currency
--   trans_curr_amount_:     Amount in transaction currency
--   acc_curr_code_:         Accounting currency for the company
--   trans_curr_code_:       Transaction Currency
--   currency_rate_          Rate between the currencies (either between transaction currency and parallel currency or between accounting currency and parallel currency)
--   conversion_factor_      Conversion factor for the currency
--   inverted_               If the rate is inverted or not (TRUE/FALSE)
--   parallel_curr_code_:    Parallel Currency for the company
--   parallel_base_:         Base for calculating parallel currency (TRANSACTION_CURRENCY or ACCOUNTING_CURRENCY), db value
--   number_of_dec_in_amt_:  The number of decimals to round the amount to, if not given number of decimals will be taken from the currency
--   always_calculate_:      For some PPV postings parallel amount is calulated by changing the parallel base to ACCOUNTING_CURRENCY, for postings which have transaction 
--                           currency code equal to parallel currency code and transaction currency amount is zero this parameter tells to calculate parallel amount instead of copying transaction amount to parallel amount.       
--   This logic of this method is same as the Calc_Amount Method, This method additionally returns
--   the difference between the unrounded amount and the rounded amount. This is introduced mainly
--   to be used in doing period allocation in Gen_Led_Voucher_Row_API.
@UncheckedAccess
FUNCTION Calc_Parallel_Amt_Rate_Round (
   company_                IN  VARCHAR2,
   acc_curr_amount_        IN  NUMBER,
   trans_curr_amount_      IN  NUMBER,
   acc_curr_code_          IN  VARCHAR2,
   trans_curr_code_        IN  VARCHAR2,
   currency_rate_          IN  NUMBER,
   conversion_factor_      IN  NUMBER,
   inverted_               IN  VARCHAR2,
   parallel_curr_code_     IN  VARCHAR2 DEFAULT NULL,
   parallel_base_          IN  VARCHAR2 DEFAULT NULL,
   number_of_dec_in_amt_   IN  NUMBER   DEFAULT NULL,
   always_calculate_       IN  VARCHAR2 DEFAULT 'FALSE') RETURN NUMBER
IS
   tmp_parallel_curr_code_    VARCHAR2(3) := parallel_curr_code_;
   tmp_number_of_dec_in_amt_  NUMBER := number_of_dec_in_amt_;
   parallel_amount_           NUMBER;
BEGIN
   IF (tmp_parallel_curr_code_ IS NULL) THEN
      tmp_parallel_curr_code_ := Company_Finance_API.Get_Parallel_Acc_Currency(company_);
   END IF;
   -- Parallel Currency is not used in the company, return NULL
   IF (tmp_parallel_curr_code_ IS NULL) THEN
      RETURN NULL;
   END IF;
   parallel_amount_ := Calc_Parallel_Amt_Rate(company_,
                                              acc_curr_amount_,
                                              trans_curr_amount_,
                                              acc_curr_code_,
                                              trans_curr_code_,
                                              currency_rate_,
                                              conversion_factor_,
                                              inverted_,
                                              tmp_parallel_curr_code_,
                                              parallel_base_,
                                              always_calculate_);

   IF (tmp_number_of_dec_in_amt_ IS NULL) THEN
      tmp_number_of_dec_in_amt_ := NVL(Currency_Code_API.Get_Currency_Rounding (company_,
                                                                                tmp_parallel_curr_code_),
                                       0);
   END IF;
   parallel_amount_ := ROUND(parallel_amount_, tmp_number_of_dec_in_amt_);
   RETURN parallel_amount_;
END Calc_Parallel_Amt_Rate_Round;




-- Calculate_Parallel_Curr_Rate
--   Function that calculates the parallel currency rate and rounded, into number of decimals for the rate based on the currency, by passing amounts and currencies for transaction
--   Input parameters:
--   company_:                  Company for which data should be returned
--   transaction_date_:         The Transasction date
--   acc_curr_amount_:          Amount in accounting currency
--   trans_curr_amount_:        Amount in transaction currency
--   parallel_curr_amount_:     Amount in parallel currency
--   acc_curr_code_:            Accounting currency for the company
--   trans_curr_code_:          Transaction Currency
--   parallel_curr_code_:       Parallel Currency for the company
--   parallel_curr_base_db_:    Base for calculating parallel currency (TRANSACTION_CURRENCY or ACCOUNTING_CURRENCY), db value
--   parallel_curr_rate_type_:  The parallel currency rate type, from which currency rate table conversion factor and inverted flag should be fetched
--   decimals_in_rate_:         The number of decimals to round the rate to, if not given number of decimals will be taken from the currency
--   The currecny conversion methodology is not different from any other methods. This method gets all the values necessry for calculation
--   as parameters so this is very efficient to use inside loops. Used in GROCON for currency translations.
@UncheckedAccess
FUNCTION Calculate_Parallel_Curr_Rate (
   company_                   IN VARCHAR2,
   transaction_date_          IN DATE,
   acc_curr_amount_           IN NUMBER,
   trans_curr_amount_         IN NUMBER,
   parallel_curr_amount_      IN NUMBER,
   acc_curr_code_             IN VARCHAR2,
   trans_curr_code_           IN VARCHAR2,
   parallel_curr_code_        IN VARCHAR2,
   parallel_curr_base_db_     IN VARCHAR2 DEFAULT NULL,
   parallel_curr_rate_type_   IN VARCHAR2 DEFAULT NULL,
   decimals_in_rate_          IN NUMBER DEFAULT NULL) RETURN NUMBER
IS
   rate_                         NUMBER;
   curr_code_                    VARCHAR2(3);
   ref_curr_code_                VARCHAR2(3);
   curr_rate_rec_                Currency_Rate_API.Rate_Data_Rec_Type;
   tmp_parallel_curr_base_db_    VARCHAR2(25) := parallel_curr_base_db_;
   tmp_parallel_curr_rate_type_  VARCHAR2(10) := parallel_curr_rate_type_;
   tmp_decimals_in_rate_         NUMBER := decimals_in_rate_;
BEGIN
   IF (tmp_parallel_curr_base_db_ IS NULL) THEN
      tmp_parallel_curr_base_db_ := Company_Finance_API.Get_Parallel_Base_Db(company_);
   END IF;
   IF (tmp_parallel_curr_rate_type_ IS NULL) THEN
      tmp_parallel_curr_rate_type_ := Company_Finance_API.Get_Parallel_Rate_Type(company_);
   END IF;

   IF (tmp_parallel_curr_base_db_ = 'TRANSACTION_CURRENCY') THEN
      ref_curr_code_ := parallel_curr_code_;
      curr_code_     := trans_curr_code_;

      -- if any of the amounts are zero then return 0 rate
      IF ( (trans_curr_amount_ = 0) OR (parallel_curr_amount_ = 0) ) THEN
         RETURN 0;
      END IF;
   ELSE
      ref_curr_code_ := acc_curr_code_;
      curr_code_     := parallel_curr_code_;

      -- if any of the amounts are zero then return 0 rate
      IF ( (acc_curr_amount_ = 0) OR (parallel_curr_amount_ = 0) ) THEN
         RETURN 0;
      END IF;
   END IF;

   curr_rate_rec_ := Currency_Rate_API.Currency_Rate_Info(company_,
                                                          tmp_parallel_curr_rate_type_,
                                                          curr_code_,
                                                          ref_curr_code_,
                                                          transaction_date_,
                                                          Currency_Code_API.Get_Emu(company_,
                                                                                    ref_curr_code_));

   IF (tmp_parallel_curr_base_db_ = 'TRANSACTION_CURRENCY') THEN
      IF (curr_rate_rec_.inverted = 'TRUE') THEN
         rate_ := (trans_curr_amount_/parallel_curr_amount_) * curr_rate_rec_.conv_factor ;
      ELSE
         rate_ := (parallel_curr_amount_/trans_curr_amount_) * curr_rate_rec_.conv_factor;
      END IF;
   ELSE
      IF (curr_rate_rec_.inverted = 'TRUE') THEN
         rate_ := (parallel_curr_amount_/acc_curr_amount_) * curr_rate_rec_.conv_factor;
      ELSE
         rate_ := (acc_curr_amount_/parallel_curr_amount_) * curr_rate_rec_.conv_factor;
      END IF;
   END IF;
   IF (tmp_decimals_in_rate_ IS NULL) THEN
      tmp_decimals_in_rate_ := Currency_Code_API.Get_No_Of_Decimals_In_Rate(company_, parallel_curr_code_);
   END IF;
   rate_ := ROUND(rate_, tmp_decimals_in_rate_);
   RETURN rate_;
END Calculate_Parallel_Curr_Rate;




@UncheckedAccess
FUNCTION Get_Currency_Converted_Amount(
   master_company_             IN VARCHAR2,
   to_curr_code_               IN VARCHAR2,
   from_curr_code_             IN VARCHAR2,
   inverted_rate_              IN VARCHAR2,
   currency_rounding_          IN NUMBER,
   currency_rate_              IN NUMBER,
   conversion_factor_          IN NUMBER,
   credit_amount_              IN NUMBER,
   debit_amount_               IN NUMBER,
   master_company_curr_code_   IN VARCHAR2 DEFAULT NULL) RETURN ConvertedAmountsRec
IS
   credit_converted_amount_   NUMBER;
   dedit_converted_amount_    NUMBER;
   master_curr_code_          VARCHAR2(3);
   return_amounts_            ConvertedAmountsRec;
   
BEGIN
   -- Return the same value if the currency codes are equal.   
   IF(to_curr_code_ = from_curr_code_) THEN
      return_amounts_.conv_credit_amount     := credit_amount_;
      return_amounts_.conv_debit_amount      := debit_amount_;
      return_amounts_.conv_balance_amount    := (nvl(debit_amount_,0) - nvl(credit_amount_,0));
      RETURN return_amounts_;
   END IF;
   
   IF(master_company_curr_code_ IS NULL) THEN
      master_curr_code_ := Company_Finance_API.Get_Currency_Code(master_company_);
   ELSE
      master_curr_code_ := master_company_curr_code_;
   END IF;

   -- Do the necessery claculations.
   IF(NOT(master_curr_code_ = to_curr_code_)) THEN
      dedit_converted_amount_    := debit_amount_   * currency_rate_;
      credit_converted_amount_   := credit_amount_  * currency_rate_;
   ELSE
      IF(inverted_rate_ = 'TRUE') THEN                    
         dedit_converted_amount_   := debit_amount_   * (1 / (currency_rate_ / conversion_factor_));
         credit_converted_amount_  := credit_amount_  * (1 / (currency_rate_ / conversion_factor_));
      ELSE
         dedit_converted_amount_   := debit_amount_   * (currency_rate_ / conversion_factor_);
         credit_converted_amount_  := credit_amount_  * (currency_rate_ / conversion_factor_);
      END IF;                
   END IF;
   
   -- Rounds the calculated amount.
   return_amounts_.conv_credit_amount  := round(credit_converted_amount_,currency_rounding_);
   return_amounts_.conv_debit_amount   := round(dedit_converted_amount_,currency_rounding_);
   return_amounts_.conv_balance_amount := (nvl(return_amounts_.conv_debit_amount,0) - nvl(return_amounts_.conv_credit_amount,0));
   
   RETURN return_amounts_;
   
END Get_Currency_Converted_Amount;




