-----------------------------------------------------------------------------
--
--  Logical unit: LevelInfoUtil
--  Component:    ACCRUL
--
--  IFS Developer Studio Template Version 3.0
--
--  Date    Sign    History
--  ------  ------  ---------------------------------------------------------
--  000626  LeKa   Created
--  000831  LiSv   Changed Check_Level.
--  000904  LiSv   Added abs to calculation of acc_percent_to_amount_.
--  001201  BmEk   Corrected Bug #18216. Added check on inverted_rate_. Also 
--                 removed trace_sys.
--  020111  Dagalk Bug #26728 When NetAmount is zero, the vatamount can be changed(no error-messages)   
--  020605  JeGu   Bug #29533 Implemented currency rounding in Check_Level  
--  041026  reanpl  FITH351 Indirect Taxes, added second procedure Check_Level 
--  070522  Nimalk LCS Merge 64483, Added FUNCTION Check_Level___, FUNCTION Check_Level and Modified PROCEDURE Check_Level 
--  080114  Makrlk Bug 69421 Corrected. Used the ROUND function in Check_Level___().
--  090828  LaPrlk Bug 85370, Corrected in FUNCTION Check_Level___
--  120618  Clstlk Bug 102033, Modified Check_Level___() so that net zero voucher lines will not be validated for overwriting level.
--  130918  Jaralk Bug 112429  removed ROUND function added by Bug 69421 in Check_Level__
-----------------------------------------------------------------------------

layer Core;

-------------------- PUBLIC DECLARATIONS ------------------------------------


-------------------- PRIVATE DECLARATIONS -----------------------------------


-------------------- LU SPECIFIC IMPLEMENTATION METHODS ---------------------

FUNCTION Check_Level___ (
   company_        IN VARCHAR2,
   amount_         IN NUMBER,
   tax_amount_     IN NUMBER,
   tax_code_       IN VARCHAR2,
   curr_rate_      IN NUMBER,
   div_factor_     IN NUMBER,
   net_gross_flag_ IN VARCHAR2 ) RETURN VARCHAR2
IS
   def_tax_percent_        NUMBER;
   def_tax_amount_         NUMBER;
   level_in_percent_       NUMBER;
   level_in_acc_currency_  NUMBER;
   acc_percent_to_amount_  NUMBER;
   acc_def_tax_amount_     NUMBER;
   acc_tax_amount_         NUMBER;
   deductible_percent_     NUMBER;
   acc_currency_code_      VARCHAR2(100);
   inverted_rate_          VARCHAR2(100);
   rounding_               NUMBER;
   within_level_           VARCHAR2(5) := 'TRUE';
BEGIN
   -- Bug 102033, Begin, added check for net zero lines
   IF (tax_code_ IS NOT NULL AND ((net_gross_flag_ = 'NET' AND amount_ !=0) OR (net_gross_flag_ = 'GROSS'))) THEN
      def_tax_percent_       := Statutory_Fee_API.Get_Percentage(company_, tax_code_) / 100;
      deductible_percent_    := Statutory_Fee_API.Get_Deductible(company_, tax_code_) / 100;

      acc_currency_code_     := Company_Finance_API.Get_Currency_Code(company_);
      rounding_              := Currency_Code_API.Get_Currency_Rounding(company_, acc_currency_code_);
      
      IF (net_gross_flag_ = 'NET') THEN
         def_tax_amount_    := amount_ * ( def_tax_percent_ * deductible_percent_ );
      ELSE
         def_tax_amount_    := (amount_ * ( def_tax_percent_  / (1 + def_tax_percent_) * deductible_percent_ ) );	  
      END IF;

      level_in_percent_      := Company_Finance_API.Get_Level_In_Percent(company_);
      level_in_acc_currency_ := Company_Finance_API.Get_Level_In_Acc_Currency(company_);

      inverted_rate_         := Currency_Code_API.Get_Inverted(company_, acc_currency_code_);
      

      IF (inverted_rate_ = 'FALSE') THEN
         acc_def_tax_amount_ := ROUND(((def_tax_amount_ * curr_rate_) / div_factor_),rounding_);
         acc_tax_amount_     := ROUND(((tax_amount_ * curr_rate_) /div_factor_),rounding_);
      ELSE
         acc_def_tax_amount_ := ROUND(((def_tax_amount_ * div_factor_) / curr_rate_),rounding_);
         acc_tax_amount_     := ROUND(((tax_amount_ * div_factor_) / curr_rate_),rounding_);
      END IF;
      acc_percent_to_amount_ := ROUND(abs(((level_in_percent_ * acc_def_tax_amount_) / 100)), rounding_);
      IF (level_in_percent_ IS NOT NULL AND level_in_acc_currency_ IS NOT NULL) THEN
         IF (acc_percent_to_amount_ < level_in_acc_currency_) THEN
            IF (acc_tax_amount_ >(acc_def_tax_amount_ + acc_percent_to_amount_) OR acc_tax_amount_ <(acc_def_tax_amount_ - acc_percent_to_amount_)) THEN
               within_level_ := 'FALSE';
            END IF;
         ELSE
            IF (acc_tax_amount_ >(acc_def_tax_amount_ + level_in_acc_currency_) OR acc_tax_amount_ <(acc_def_tax_amount_ - level_in_acc_currency_)) THEN
               within_level_ := 'FALSE';
            END IF;
         END IF;
      ELSIF (level_in_percent_ IS NOT NULL AND level_in_acc_currency_ IS NULL) THEN
         IF (acc_tax_amount_ >(acc_def_tax_amount_ + acc_percent_to_amount_) OR acc_tax_amount_ <(acc_def_tax_amount_ - acc_percent_to_amount_)) THEN
            within_level_ := 'FALSE';
         END IF;
      ELSIF (level_in_percent_ IS NULL AND level_in_acc_currency_ IS NOT NULL) THEN
         IF (acc_tax_amount_ >(acc_def_tax_amount_ + level_in_acc_currency_) OR acc_tax_amount_ <(acc_def_tax_amount_ - level_in_acc_currency_)) THEN
            within_level_ := 'FALSE';
         END IF;
      END IF;
   END IF;
   -- Bug 102033, End
   RETURN within_level_; 
END Check_Level___;


-------------------- LU SPECIFIC PRIVATE METHODS ----------------------------

-------------------- LU SPECIFIC PROTECTED METHODS --------------------------

-------------------- LU SPECIFIC PUBLIC METHODS -----------------------------

@UncheckedAccess
FUNCTION Check_Level (
   company_        IN VARCHAR2,
   amount_         IN NUMBER,
   tax_amount_     IN NUMBER,
   tax_code_       IN VARCHAR2,
   curr_rate_      IN NUMBER,
   div_factor_     IN NUMBER,
   net_gross_flag_ IN VARCHAR2 ) RETURN VARCHAR2
IS
BEGIN
   RETURN Check_Level___(company_,
                         amount_,
                         tax_amount_,
                         tax_code_,
                         curr_rate_,
                         div_factor_,
                         net_gross_flag_);
END Check_Level;



PROCEDURE Check_Level (
   company_        IN VARCHAR2,
   amount_         IN NUMBER,
   tax_amount_     IN NUMBER,
   tax_code_       IN VARCHAR2,
   curr_rate_      IN NUMBER,
   div_factor_     IN NUMBER,
   net_gross_flag_ IN VARCHAR2 )
IS
   within_level_   VARCHAR2(5) := 'TRUE';
   
BEGIN
   
   within_level_ := Check_Level___(company_,
                                   amount_,
                                   tax_amount_,
                                   tax_code_,
                                   curr_rate_,
                                   div_factor_,
                                   net_gross_flag_);
   IF (within_level_ != 'TRUE') THEN                                
      Error_SYS.Record_General( lu_name_,'LEVEL: Tax amount adjustment cannot be greater than the maximum overwriting level on tax.'); 
   END IF;
   
END Check_Level;


PROCEDURE Check_Level (
   company_             IN VARCHAR2,
   acc_def_tax_amount_  IN NUMBER,
   acc_tax_amount_      IN NUMBER)
IS
   level_in_percent_       NUMBER;
   level_in_acc_currency_  NUMBER;
   acc_percent_to_amount_  NUMBER;
   not_within_level_       EXCEPTION;
   
BEGIN

   level_in_percent_      := Company_Finance_API.Get_Level_In_Percent(company_);
   level_in_acc_currency_ := Company_Finance_API.Get_Level_In_Acc_Currency(company_);

   acc_percent_to_amount_ := abs(((level_in_percent_ * acc_def_tax_amount_) / 100));
      
   IF (level_in_percent_ IS NOT NULL AND level_in_acc_currency_ IS NOT NULL) THEN
      IF (acc_percent_to_amount_ < level_in_acc_currency_) THEN
         IF (acc_tax_amount_ >(acc_def_tax_amount_ + acc_percent_to_amount_) OR acc_tax_amount_ <(acc_def_tax_amount_ - acc_percent_to_amount_)) THEN
            RAISE not_within_level_;
         END IF;
      ELSE
         IF (acc_tax_amount_ >(acc_def_tax_amount_ + level_in_acc_currency_) OR acc_tax_amount_ <(acc_def_tax_amount_ - level_in_acc_currency_)) THEN
            RAISE not_within_level_;
         END IF;
      END IF;
   ELSIF (level_in_percent_ IS NOT NULL AND level_in_acc_currency_ IS NULL) THEN
      IF (acc_tax_amount_ >(acc_def_tax_amount_ + acc_percent_to_amount_) OR acc_tax_amount_ <(acc_def_tax_amount_ - acc_percent_to_amount_)) THEN
         RAISE not_within_level_;
      END IF;
   ELSIF (level_in_percent_ IS NULL AND level_in_acc_currency_ IS NOT NULL) THEN
      IF (acc_tax_amount_ >(acc_def_tax_amount_ + level_in_acc_currency_) OR acc_tax_amount_ <(acc_def_tax_amount_ - level_in_acc_currency_)) THEN
         RAISE not_within_level_;
      END IF;
   END IF;
EXCEPTION
   WHEN not_within_level_ THEN
      Error_SYS.Record_General( lu_name_,'LEVEL: Tax amount adjustment cannot be greater than the maximum overwriting level on tax.');
   WHEN OTHERS THEN
      RAISE;
END Check_Level;



