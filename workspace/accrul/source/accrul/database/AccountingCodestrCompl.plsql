-----------------------------------------------------------------------------
--
--  Logical unit: AccountingCodestrCompl
--  Component:    ACCRUL
--
--  IFS Developer Studio Template Version 3.0
--
--  Date    Sign    History
--  ------  ------  ---------------------------------------------------------
--  960329  xxxx  Base Table to Logical Unit Generator 1.0A
--  960607  ToRe  Override value in override_rec is default 'Y'.
--  970627  SLKO  Converted to Foundation 1.2.2d
--  980217  SLKO  Converted to Foundation1 2.0.0
--  980921  Bren  Master Slave Connection
--                Added Send_Code_Comp_Info___, Send_Code_Comp_Info_Delete___,
--                Send_Code_Comp_Info_Modify___, Receive_Code_Comp_Info___ .
--  990405  JPS   Corrected Bog 8446. Changed Get_Codestring_Completetion.
--  990420  JPS   Performed Template Changes (Foundation 2.2.1)
--  000908  HiMu  Added General_SYS.Init_Method 
--  001004  prtilk BUG # 15677  Checked General_SYS.Init_Method 
--  010531  Bmekse Removed methods used by the old way for transfer basic data from
--                 master to slave (nowdays is Replication used instead)
--  020207  MaNi  IID21003, Company Translations
--  021001  Nimalk   Remove usage of the view Company_Finance_Auth in ACCOUNTING_CODESTR_COMPL view 
--                   and replaced by view Company_Finance_Auth1 using EXISTS caluse instead of joins
--  030730  prdilk   SP4 Merge 
--  030903  Thsrlk LCS Merge - Bug 38836,Corrected. Added function Exist_Completion__.
--  040727  Umdolk Merged LCS Bug 43755.
--  061212  Kagalk LCS Merge 58758, Performance improvement.
--  090110  Maaylk Bug 79375, modified Connect_To_Account(). Should exist records with codefill_value NOT NULL to return true
--  090720  Marulk Bug 83876, added necessary view and methods to add the LU to the company template. 
--  100914  Jaralk Bug 92858 Added two method to update the ACCOUNTING_CODESTR_COMPL_TAB  
--                 to reflect the changes done in ACCOUNTING_CODE_PART tab
--  110818  Mohrlk FIDEAGLE-1337, Merged bug 98291, Changed the column width field of view comment of codefill value field of the accounting_codestr_compl view
--  131104  Umdolk PBFI-893, Refactoring.
--  150811  Thpelk Bug Id 123238, Fixed
--  160211  Savmlk Bug Id 127280, Fixed.
-----------------------------------------------------------------------------

layer Core;

-------------------- PUBLIC DECLARATIONS ------------------------------------


-------------------- PRIVATE DECLARATIONS -----------------------------------


-------------------- LU SPECIFIC IMPLEMENTATION METHODS ---------------------

@Override
PROCEDURE Check_Update___ (
   oldrec_ IN     accounting_codestr_compl_tab%ROWTYPE,
   newrec_ IN OUT accounting_codestr_compl_tab%ROWTYPE,
   indrec_ IN OUT Indicator_Rec,
   attr_   IN OUT VARCHAR2 )
IS
   name_      VARCHAR2(30);
   value_     VARCHAR2(4000);
   codefill_value_name_  VARCHAR2(100);
BEGIN
   codefill_value_name_:= Client_SYS.Cut_Item_Value('CODEFILL_VALUE_NAME',attr_);
   IF (codefill_value_name_ IS NOT NULL)THEN
      Error_SYS.Item_Update(lu_name_, 'CODEFILL_VALUE_NAME');
   END IF;
   super(oldrec_, newrec_, indrec_, attr_);   
EXCEPTION
   WHEN value_error THEN
      Error_SYS.Item_Format(lu_name_, name_, value_);
END Check_Update___;

-- Bug 123238, Begin
PROCEDURE Fetch_No_Codepart_Value___ ( no_codepart_val_rec_    OUT Accounting_Codestr_API.CodestrRec,
									            codestring_rec_      IN OUT Accounting_Codestr_API.CodestrRec,
                                       company_             IN     VARCHAR2 )
IS
  CURSOR get_rec_ IS
	SELECT *
	FROM POST_CTRL_NO_CODEPART_VAL_TMP;
	
BEGIN
  -- To support MPL posting types 
  IF ( codestring_rec_.posting_type LIKE 'M%') THEN
     IF ( codestring_rec_.code_a = CHR(0)||CHR(0) ) THEN 
        no_codepart_val_rec_.code_a := 'TRUE';
        codestring_rec_.code_a := NULL;
     END IF;
     
     IF ( codestring_rec_.code_b = CHR(0)||CHR(0) ) THEN 
        no_codepart_val_rec_.code_b := 'TRUE';
        codestring_rec_.code_b := NULL;
     END IF;
     
     IF ( codestring_rec_.code_c = CHR(0)||CHR(0) ) THEN 
        no_codepart_val_rec_.code_c := 'TRUE';
        codestring_rec_.code_c := NULL;
     END IF;
     
     IF ( codestring_rec_.code_d = CHR(0)||CHR(0) ) THEN 
        no_codepart_val_rec_.code_d := 'TRUE';
        codestring_rec_.code_d := NULL;
     END IF;
     
     IF ( codestring_rec_.code_e = CHR(0)||CHR(0) ) THEN 
        no_codepart_val_rec_.code_e := 'TRUE';
        codestring_rec_.code_e := NULL;
     END IF;
     
     IF ( codestring_rec_.code_f = CHR(0)||CHR(0) ) THEN 
        no_codepart_val_rec_.code_f := 'TRUE';
        codestring_rec_.code_f := NULL;
     END IF;
     
     trace_sys.Message('2222 ' );
     IF ( codestring_rec_.code_g = CHR(0)||CHR(0) ) THEN 
        trace_sys.Message('33333 ' );
        no_codepart_val_rec_.code_g := 'TRUE';
        codestring_rec_.code_g := NULL;
     END IF;
     
     IF ( codestring_rec_.code_h = CHR(0)||CHR(0) ) THEN 
        no_codepart_val_rec_.code_h := 'TRUE';
        codestring_rec_.code_h := NULL;
     END IF;
     
     IF ( codestring_rec_.code_i = CHR(0)||CHR(0) ) THEN 
        no_codepart_val_rec_.code_i := 'TRUE';
        codestring_rec_.code_i := NULL;
     END IF;
     
     IF ( codestring_rec_.code_j = CHR(0)||CHR(0) ) THEN 
        no_codepart_val_rec_.code_j := 'TRUE';
        codestring_rec_.code_j := NULL;
     END IF;

  ELSE
	  FOR rec_ IN get_rec_ LOOP
	    no_codepart_val_rec_.code_a := rec_.code_a;
		 no_codepart_val_rec_.code_b := rec_.code_b;
		 no_codepart_val_rec_.code_c := rec_.code_c;
		 no_codepart_val_rec_.code_d := rec_.code_d;
		 no_codepart_val_rec_.code_e := rec_.code_e;
		 no_codepart_val_rec_.code_f := rec_.code_f;
		 no_codepart_val_rec_.code_g := rec_.code_g;
		 no_codepart_val_rec_.code_h := rec_.code_h;
		 no_codepart_val_rec_.code_i := rec_.code_i;
		 no_codepart_val_rec_.code_j := rec_.code_j;
	
	  END LOOP;
  END IF;  
END Fetch_No_Codepart_Value___;
-- Bug 123238, End


-------------------- LU SPECIFIC PRIVATE METHODS ----------------------------

PROCEDURE Complete_Code_Part__ (
   code_a_codefill_          OUT VARCHAR2,
   code_b_codefill_          OUT VARCHAR2,
   code_c_codefill_          OUT VARCHAR2,
   code_d_codefill_          OUT VARCHAR2,
   code_e_codefill_          OUT VARCHAR2,
   code_f_codefill_          OUT VARCHAR2,
   code_g_codefill_          OUT VARCHAR2,
   code_h_codefill_          OUT VARCHAR2,
   code_i_codefill_          OUT VARCHAR2,
   code_j_codefill_          OUT VARCHAR2,
   process_code_codefill_    OUT VARCHAR2,
   company_               IN     VARCHAR2,
   code_part_             IN     VARCHAR2,
   code_part_value_       IN     VARCHAR2 )
IS
   --
   codefill_code_part_    VARCHAR2(1);
   codefill_value_        VARCHAR2(20);
   --
   CURSOR complete_cursor IS
      SELECT  codefill_code_part, codefill_value
      FROM    ACCOUNTING_CODESTR_COMPL_TAB
      WHERE   company         = company_
      AND     code_part       = code_part_
      AND     code_part_value = code_part_value_
      AND     codefill_value  IS NOT NULL;
   --
BEGIN

   code_a_codefill_       := NULL;
   code_b_codefill_       := NULL;
   code_c_codefill_       := NULL;
   code_d_codefill_       := NULL;
   code_e_codefill_       := NULL;
   code_f_codefill_       := NULL;
   code_g_codefill_       := NULL;
   code_h_codefill_       := NULL;
   code_i_codefill_       := NULL;
   code_j_codefill_       := NULL;
   process_code_codefill_ := NULL;

   OPEN complete_cursor;
   WHILE (TRUE) LOOP
      FETCH complete_cursor INTO codefill_code_part_, codefill_value_;
      EXIT WHEN complete_cursor%NOTFOUND;
      IF codefill_code_part_ = 'A' THEN
         code_a_codefill_ := codefill_value_;
      ELSIF codefill_code_part_ = 'B' THEN
         code_b_codefill_ := codefill_value_;
      ELSIF codefill_code_part_ = 'C' THEN
         code_c_codefill_ := codefill_value_;
      ELSIF codefill_code_part_ = 'D' THEN
         code_d_codefill_ := codefill_value_;
      ELSIF codefill_code_part_ = 'E' THEN
         code_e_codefill_ := codefill_value_;
      ELSIF codefill_code_part_ = 'F' THEN
         code_f_codefill_ := codefill_value_;
      ELSIF codefill_code_part_ = 'G' THEN
         code_g_codefill_ := codefill_value_;
      ELSIF codefill_code_part_ = 'H' THEN
         code_h_codefill_ := codefill_value_;
      ELSIF codefill_code_part_ = 'I' THEN
         code_i_codefill_ := codefill_value_;
      ELSIF codefill_code_part_ = 'J' THEN
         code_j_codefill_ := codefill_value_;
      ELSIF codefill_code_part_ = 'P' THEN
         process_code_codefill_ := codefill_value_;
      END IF;
   END LOOP;
   CLOSE complete_cursor;
END Complete_Code_Part__;


FUNCTION Exist_Completion__(company_ IN VARCHAR2, account_ in VARCHAR2) RETURN VARCHAR2
IS 
 CURSOR check_completion IS
     SELECT 1
     FROM Accounting_Codestr_Compl
     WHERE company = company_
     AND code_part = 'A'
     AND code_part_value = account_;
     
  temp_   NUMBER;   
  result_ VARCHAR2(5);
  
BEGIN
   OPEN check_completion;
   FETCH check_completion INTO temp_;
   CLOSE check_completion;
  
   IF (temp_ > 0) THEN
      result_ := 'TRUE';
   ELSE
      result_ := 'FALSE';
   END IF;   
  
   RETURN result_;
END Exist_Completion__;


-------------------- LU SPECIFIC PROTECTED METHODS --------------------------

FUNCTION Check_Delete_Allowed_ (
   company_           IN VARCHAR2,
   code_part_value_   IN VARCHAR2,
   code_part_         IN VARCHAR2 DEFAULT NULL ) RETURN BOOLEAN
IS
   --
   dummy_             VARCHAR2(1);
   --

   --
   CURSOR exist_code_part IS
     SELECT 'X'
     FROM   ACCOUNTING_CODESTR_COMPL_TAB
     WHERE  company            = company_
     AND    codefill_code_part = code_part_
     AND    codefill_value     = code_part_value_;

   CURSOR exist_code_part_value IS
     SELECT 'X'
     FROM   ACCOUNTING_CODESTR_COMPL_TAB
     WHERE  company        = company_
     AND    codefill_value = code_part_value_;
BEGIN
   IF (code_part_ IS NULL) THEN
      OPEN  exist_code_part_value;
      FETCH exist_code_part_value INTO dummy_;
      IF (exist_code_part_value%NOTFOUND) THEN
         CLOSE  exist_code_part_value;
         RETURN TRUE;
      ELSE
         CLOSE  exist_code_part_value;
         RETURN FALSE;
      END IF;
   ELSE
      OPEN  exist_code_part;
      FETCH exist_code_part INTO dummy_;
      IF (exist_code_part%NOTFOUND) THEN
         CLOSE  exist_code_part;
         RETURN TRUE;
      ELSE
         CLOSE  exist_code_part;
         RETURN FALSE;
      END IF;
   END IF;
END Check_Delete_Allowed_;


-------------------- LU SPECIFIC PUBLIC METHODS -----------------------------


@Override
@UncheckedAccess
@SecurityCheck Company.UserAuthorized(company_)
FUNCTION Get_Codefill_Value (
   company_ IN VARCHAR2,
   code_part_ IN VARCHAR2,
   code_part_value_ IN VARCHAR2,
   codefill_code_part_ IN VARCHAR2 ) RETURN VARCHAR2
IS   
BEGIN
   RETURN Super(company_, code_part_, code_part_value_, codefill_code_part_);
END Get_Codefill_Value;



@SecurityCheck Company.UserAuthorized(company_)
PROCEDURE Get_Codestring_Completetion (
   codestring_rec_    IN OUT Accounting_Codestr_API.CodestrRec,
   code_part_         IN OUT VARCHAR2,
   company_           IN     VARCHAR2,
   override_rec_      IN     Accounting_Codestr_API.CodestrRec )
IS
   --
   code_a_codefill_          VARCHAR2(20);
   code_b_codefill_          VARCHAR2(20);
   code_c_codefill_          VARCHAR2(20);
   code_d_codefill_          VARCHAR2(20);
   code_e_codefill_          VARCHAR2(20);
   code_f_codefill_          VARCHAR2(20);
   code_g_codefill_          VARCHAR2(20);
   code_h_codefill_          VARCHAR2(20);
   code_i_codefill_          VARCHAR2(20);
   code_j_codefill_          VARCHAR2(20);
   process_code_codefill_    VARCHAR2(20);
   code_part_value_          VARCHAR2(20);
   codep_                    VARCHAR2(1);

   -- Bug 123238, Begin
   no_codepart_val_rec_ ACCOUNTING_CODESTR_API.CODESTRREC;
   -- Bug 123238, End
   --
BEGIN

   -- Bug 123238, Begin
	Fetch_No_Codepart_Value___ ( no_codepart_val_rec_, codestring_rec_, company_ ); 
   -- Bug 123238, Begin

   IF codestring_rec_.code_a IS NOT NULL AND code_part_ IS NULL
   OR codestring_rec_.code_a IS NOT NULL AND code_part_ = 'A' THEN
         codep_           := 'A';
         code_part_value_ := codestring_rec_.code_a;
         Complete_Code_Part__ ( code_a_codefill_,
                                code_b_codefill_,
                                code_c_codefill_,
                                code_d_codefill_,
                                code_e_codefill_,
                                code_f_codefill_,
                                code_g_codefill_,
                                code_h_codefill_,
                                code_i_codefill_,
                                code_j_codefill_,
                                process_code_codefill_,
                                company_,
                                codep_,
                                code_part_value_ );
         -- Bug 123238, Begin
         IF (codestring_rec_.code_a IS NULL AND NVL(no_codepart_val_rec_.code_a,'FALSE')='FALSE') OR override_rec_.code_a = 'Y' THEN
            codestring_rec_.code_a := nvl(code_a_codefill_, codestring_rec_.code_a);
         END IF;
         IF (codestring_rec_.code_b IS NULL AND NVL(no_codepart_val_rec_.code_b,'FALSE')='FALSE') OR override_rec_.code_b = 'Y' THEN
            codestring_rec_.code_b := nvl(code_b_codefill_, codestring_rec_.code_b);
         END IF;
         IF (codestring_rec_.code_c IS NULL AND NVL(no_codepart_val_rec_.code_c,'FALSE')='FALSE') OR override_rec_.code_c = 'Y' THEN
            codestring_rec_.code_c := nvl(code_c_codefill_, codestring_rec_.code_c);
         END IF;
         IF (codestring_rec_.code_d IS NULL AND NVL(no_codepart_val_rec_.code_d,'FALSE')='FALSE') OR override_rec_.code_d = 'Y' THEN
            codestring_rec_.code_d := nvl(code_d_codefill_, codestring_rec_.code_d);
         END IF;
         IF (codestring_rec_.code_e IS NULL AND NVL(no_codepart_val_rec_.code_e,'FALSE')='FALSE') OR override_rec_.code_e = 'Y' THEN
            codestring_rec_.code_e := nvl(code_e_codefill_, codestring_rec_.code_e);
         END IF;
         IF (codestring_rec_.code_f IS NULL AND NVL(no_codepart_val_rec_.code_f,'FALSE')='FALSE') OR override_rec_.code_f = 'Y' THEN
            codestring_rec_.code_f := nvl(code_f_codefill_, codestring_rec_.code_f);
         END IF;
         IF (codestring_rec_.code_g IS NULL AND NVL(no_codepart_val_rec_.code_g,'FALSE')='FALSE') OR override_rec_.code_g = 'Y' THEN
            codestring_rec_.code_g := nvl(code_g_codefill_, codestring_rec_.code_g);
         END IF;
         IF (codestring_rec_.code_h IS NULL AND NVL(no_codepart_val_rec_.code_h,'FALSE')='FALSE') OR override_rec_.code_h = 'Y' THEN
            codestring_rec_.code_h := nvl(code_h_codefill_, codestring_rec_.code_h);
         END IF;
         IF (codestring_rec_.code_i IS NULL AND NVL(no_codepart_val_rec_.code_i,'FALSE')='FALSE') OR override_rec_.code_i = 'Y' THEN
            codestring_rec_.code_i := nvl(code_i_codefill_, codestring_rec_.code_i);
         END IF;
         IF (codestring_rec_.code_j IS NULL AND NVL(no_codepart_val_rec_.code_j,'FALSE')='FALSE') OR override_rec_.code_j = 'Y' THEN
            codestring_rec_.code_j := nvl(code_j_codefill_, codestring_rec_.code_j);
         END IF;
         IF codestring_rec_.process_code IS NULL OR override_rec_.process_code = 'Y' THEN
            codestring_rec_.process_code := nvl(process_code_codefill_, codestring_rec_.process_code);
         END IF;
         -- Bug 123238, End
      END IF;
      IF codestring_rec_.code_b IS NOT NULL AND code_part_ IS NULL
      OR codestring_rec_.code_b IS NOT NULL AND code_part_ = 'B' THEN
         IF code_b_codefill_ IS NOT NULL AND override_rec_.code_b = 'Y' THEN
            code_part_value_ := code_b_codefill_;
         ELSE
            code_part_value_ := codestring_rec_.code_b;
         END IF;
         codep_ := 'B';
         Complete_Code_Part__ ( code_a_codefill_,
                                code_b_codefill_,
                                code_c_codefill_,
                                code_d_codefill_,
                                code_e_codefill_,
                                code_f_codefill_,
                                code_g_codefill_,
                                code_h_codefill_,
                                code_i_codefill_,
                                code_j_codefill_,
                                process_code_codefill_,
                                company_,
                                codep_,
                                code_part_value_ );
         IF (codestring_rec_.code_a IS NULL AND NVL(no_codepart_val_rec_.code_a,'FALSE')='FALSE') OR override_rec_.code_a = 'Y' THEN
            codestring_rec_.code_a := nvl(code_a_codefill_, codestring_rec_.code_a);
         END IF;
         IF (codestring_rec_.code_b IS NULL AND NVL(no_codepart_val_rec_.code_b,'FALSE')='FALSE') OR override_rec_.code_b = 'Y' THEN
            codestring_rec_.code_b := nvl(code_b_codefill_, codestring_rec_.code_b);
         END IF;
         IF (codestring_rec_.code_c IS NULL AND NVL(no_codepart_val_rec_.code_c,'FALSE')='FALSE') OR override_rec_.code_c = 'Y' THEN
            codestring_rec_.code_c := nvl(code_c_codefill_, codestring_rec_.code_c);
         END IF;
         IF (codestring_rec_.code_d IS NULL AND NVL(no_codepart_val_rec_.code_d,'FALSE')='FALSE') OR override_rec_.code_d = 'Y' THEN
            codestring_rec_.code_d := nvl(code_d_codefill_, codestring_rec_.code_d);
         END IF;
         IF (codestring_rec_.code_e IS NULL AND NVL(no_codepart_val_rec_.code_e,'FALSE')='FALSE') OR override_rec_.code_e = 'Y' THEN
            codestring_rec_.code_e := nvl(code_e_codefill_, codestring_rec_.code_e);
         END IF;
         IF (codestring_rec_.code_f IS NULL AND NVL(no_codepart_val_rec_.code_f,'FALSE')='FALSE') OR override_rec_.code_f = 'Y' THEN
            codestring_rec_.code_f := nvl(code_f_codefill_, codestring_rec_.code_f);
         END IF;
         IF (codestring_rec_.code_g IS NULL AND NVL(no_codepart_val_rec_.code_g,'FALSE')='FALSE') OR override_rec_.code_g = 'Y' THEN
            codestring_rec_.code_g := nvl(code_g_codefill_, codestring_rec_.code_g);
         END IF;
         IF (codestring_rec_.code_h IS NULL AND NVL(no_codepart_val_rec_.code_h,'FALSE')='FALSE') OR override_rec_.code_h = 'Y' THEN
            codestring_rec_.code_h := nvl(code_h_codefill_, codestring_rec_.code_h);
         END IF;
         IF (codestring_rec_.code_i IS NULL AND NVL(no_codepart_val_rec_.code_i,'FALSE')='FALSE') OR override_rec_.code_i = 'Y' THEN
            codestring_rec_.code_i := nvl(code_i_codefill_, codestring_rec_.code_i);
         END IF;
         IF (codestring_rec_.code_j IS NULL AND NVL(no_codepart_val_rec_.code_j,'FALSE')='FALSE') OR override_rec_.code_j = 'Y' THEN
            codestring_rec_.code_j := nvl(code_j_codefill_, codestring_rec_.code_j);
         END IF;
         IF codestring_rec_.process_code IS NULL OR override_rec_.process_code = 'Y' THEN
            codestring_rec_.process_code := nvl(process_code_codefill_, codestring_rec_.process_code);
         END IF;
      END IF;

      IF codestring_rec_.code_c IS NOT NULL AND code_part_ IS NULL
         OR codestring_rec_.code_c IS NOT NULL AND code_part_  = 'C' THEN
         codep_           := 'C';
         code_part_value_ := codestring_rec_.code_c;
         Complete_Code_Part__ ( code_a_codefill_,
                                code_b_codefill_,
                                code_c_codefill_,
                                code_d_codefill_,
                                code_e_codefill_,
                                code_f_codefill_,
                                code_g_codefill_,
                                code_h_codefill_,
                                code_i_codefill_,
                                code_j_codefill_,
                                process_code_codefill_,
                                company_,
                                codep_,
                                code_part_value_ );
         IF (codestring_rec_.code_a IS NULL AND NVL(no_codepart_val_rec_.code_a,'FALSE')='FALSE') OR override_rec_.code_a = 'Y' THEN
            codestring_rec_.code_a := nvl(code_a_codefill_, codestring_rec_.code_a);
         END IF;
         IF (codestring_rec_.code_b IS NULL AND NVL(no_codepart_val_rec_.code_b,'FALSE')='FALSE') OR override_rec_.code_b = 'Y' THEN
            codestring_rec_.code_b := nvl(code_b_codefill_, codestring_rec_.code_b);
         END IF;
         IF (codestring_rec_.code_c IS NULL AND NVL(no_codepart_val_rec_.code_c,'FALSE')='FALSE') OR override_rec_.code_c = 'Y' THEN
            codestring_rec_.code_c := nvl(code_c_codefill_, codestring_rec_.code_c);
         END IF;
         IF (codestring_rec_.code_d IS NULL AND NVL(no_codepart_val_rec_.code_d,'FALSE')='FALSE') OR override_rec_.code_d = 'Y' THEN
            codestring_rec_.code_d := nvl(code_d_codefill_, codestring_rec_.code_d);
         END IF;
         IF (codestring_rec_.code_e IS NULL AND NVL(no_codepart_val_rec_.code_e,'FALSE')='FALSE') OR override_rec_.code_e = 'Y' THEN
         codestring_rec_.code_e := nvl(code_e_codefill_, codestring_rec_.code_e);
         END IF;
         IF (codestring_rec_.code_f IS NULL AND NVL(no_codepart_val_rec_.code_f,'FALSE')='FALSE') OR override_rec_.code_f = 'Y' THEN
            codestring_rec_.code_f := nvl(code_f_codefill_, codestring_rec_.code_f);
         END IF;
         IF (codestring_rec_.code_g IS NULL AND NVL(no_codepart_val_rec_.code_g,'FALSE')='FALSE') OR override_rec_.code_g = 'Y' THEN
            codestring_rec_.code_g := nvl(code_g_codefill_, codestring_rec_.code_g);
         END IF;
         IF (codestring_rec_.code_h IS NULL AND NVL(no_codepart_val_rec_.code_h,'FALSE')='FALSE') OR override_rec_.code_h = 'Y' THEN
            codestring_rec_.code_h := nvl(code_h_codefill_, codestring_rec_.code_h);
         END IF;
         IF (codestring_rec_.code_i IS NULL AND NVL(no_codepart_val_rec_.code_i,'FALSE')='FALSE') OR override_rec_.code_i = 'Y' THEN
            codestring_rec_.code_i := nvl(code_i_codefill_, codestring_rec_.code_i);
         END IF;
         IF (codestring_rec_.code_j IS NULL AND NVL(no_codepart_val_rec_.code_j,'FALSE')='FALSE') OR override_rec_.code_j = 'Y' THEN
            codestring_rec_.code_j := nvl(code_j_codefill_, codestring_rec_.code_j);
         END IF;
         IF codestring_rec_.process_code IS NULL OR override_rec_.process_code = 'Y' THEN
            codestring_rec_.process_code := nvl(process_code_codefill_, codestring_rec_.process_code);
         END IF;
      END IF;
      IF codestring_rec_.code_d IS NOT NULL AND code_part_  IS NULL
         OR codestring_rec_.code_d IS NOT NULL AND code_part_  = 'D' THEN
         codep_           := 'D';
         code_part_value_ := codestring_rec_.code_d;
         Complete_Code_Part__ ( code_a_codefill_,
                                code_b_codefill_,
                                code_c_codefill_,
                                code_d_codefill_,
                                code_e_codefill_,
                                code_f_codefill_,
                                code_g_codefill_,
                                code_h_codefill_,
                                code_i_codefill_,
                                code_j_codefill_,
                                process_code_codefill_,
                                company_,
                                codep_,
                                code_part_value_ );
         IF (codestring_rec_.code_a IS NULL AND NVL(no_codepart_val_rec_.code_a,'FALSE')='FALSE') OR override_rec_.code_a = 'Y' THEN
            codestring_rec_.code_a := nvl(code_a_codefill_, codestring_rec_.code_a);
         END IF;
         IF (codestring_rec_.code_b IS NULL AND NVL(no_codepart_val_rec_.code_b,'FALSE')='FALSE') OR override_rec_.code_b = 'Y' THEN
            codestring_rec_.code_b := nvl(code_b_codefill_, codestring_rec_.code_b);
         END IF;
         IF (codestring_rec_.code_c IS NULL AND NVL(no_codepart_val_rec_.code_c,'FALSE')='FALSE') OR override_rec_.code_c = 'Y' THEN
            codestring_rec_.code_c := nvl(code_c_codefill_, codestring_rec_.code_c);
         END IF;
         IF (codestring_rec_.code_d IS NULL AND NVL(no_codepart_val_rec_.code_d,'FALSE')='FALSE') OR override_rec_.code_d = 'Y' THEN
            codestring_rec_.code_d := nvl(code_d_codefill_, codestring_rec_.code_d);
         END IF;
         IF (codestring_rec_.code_e IS NULL AND NVL(no_codepart_val_rec_.code_e,'FALSE')='FALSE') OR override_rec_.code_e = 'Y' THEN
            codestring_rec_.code_e := nvl(code_e_codefill_, codestring_rec_.code_e);
         END IF;
         IF (codestring_rec_.code_f IS NULL AND NVL(no_codepart_val_rec_.code_f,'FALSE')='FALSE') OR override_rec_.code_f = 'Y' THEN
            codestring_rec_.code_f := nvl(code_f_codefill_, codestring_rec_.code_f);
         END IF;
         IF (codestring_rec_.code_g IS NULL AND NVL(no_codepart_val_rec_.code_g,'FALSE')='FALSE') OR override_rec_.code_g = 'Y' THEN
            codestring_rec_.code_g := nvl(code_g_codefill_, codestring_rec_.code_g);
         END IF;
         IF (codestring_rec_.code_h IS NULL AND NVL(no_codepart_val_rec_.code_h,'FALSE')='FALSE') OR override_rec_.code_h = 'Y' THEN
            codestring_rec_.code_h := nvl(code_h_codefill_, codestring_rec_.code_h);
         END IF;
         IF (codestring_rec_.code_i IS NULL AND NVL(no_codepart_val_rec_.code_i,'FALSE')='FALSE') OR override_rec_.code_i = 'Y' THEN
            codestring_rec_.code_i := nvl(code_i_codefill_, codestring_rec_.code_i);
         END IF;
         IF (codestring_rec_.code_j IS NULL AND NVL(no_codepart_val_rec_.code_j,'FALSE')='FALSE') OR override_rec_.code_j = 'Y' THEN
            codestring_rec_.code_j := nvl(code_j_codefill_, codestring_rec_.code_j);
         END IF;
         IF codestring_rec_.process_code IS NULL OR override_rec_.process_code = 'Y' THEN
            codestring_rec_.process_code := nvl(process_code_codefill_, codestring_rec_.process_code);
         END IF;
      END IF;
      IF codestring_rec_.code_e IS NOT NULL AND code_part_  IS NULL
         OR codestring_rec_.code_e IS NOT NULL AND code_part_  = 'E' THEN
         codep_           := 'E';
         code_part_value_ := codestring_rec_.code_e;
         Complete_Code_Part__ ( code_a_codefill_,
                                code_b_codefill_,
                                code_c_codefill_,
                                code_d_codefill_,
                                code_e_codefill_,
                                code_f_codefill_,
                                code_g_codefill_,
                                code_h_codefill_,
                                code_i_codefill_,
                                code_j_codefill_,
                                process_code_codefill_,
                                company_,
                                codep_,
                                code_part_value_ );
         IF (codestring_rec_.code_a IS NULL AND NVL(no_codepart_val_rec_.code_a,'FALSE')='FALSE') OR override_rec_.code_a = 'Y' THEN
            codestring_rec_.code_a := nvl(code_a_codefill_, codestring_rec_.code_a);
         END IF;
         IF (codestring_rec_.code_b IS NULL AND NVL(no_codepart_val_rec_.code_b,'FALSE')='FALSE') OR override_rec_.code_b = 'Y' THEN
            codestring_rec_.code_b := nvl(code_b_codefill_, codestring_rec_.code_b);
         END IF;
         IF (codestring_rec_.code_c IS NULL AND NVL(no_codepart_val_rec_.code_c,'FALSE')='FALSE') OR override_rec_.code_c = 'Y' THEN
            codestring_rec_.code_c := nvl(code_c_codefill_, codestring_rec_.code_c);
         END IF;
         IF (codestring_rec_.code_d IS NULL AND NVL(no_codepart_val_rec_.code_d,'FALSE')='FALSE') OR override_rec_.code_d = 'Y' THEN
            codestring_rec_.code_d := nvl(code_d_codefill_, codestring_rec_.code_d);
         END IF;
         IF (codestring_rec_.code_e IS NULL AND NVL(no_codepart_val_rec_.code_e,'FALSE')='FALSE') OR override_rec_.code_e = 'Y' THEN
            codestring_rec_.code_e := nvl(code_e_codefill_, codestring_rec_.code_e);
         END IF;
         IF (codestring_rec_.code_f IS NULL AND NVL(no_codepart_val_rec_.code_f,'FALSE')='FALSE') OR override_rec_.code_f = 'Y' THEN
            codestring_rec_.code_f := nvl(code_f_codefill_, codestring_rec_.code_f);
         END IF;
         IF (codestring_rec_.code_g IS NULL AND NVL(no_codepart_val_rec_.code_g,'FALSE')='FALSE') OR override_rec_.code_g = 'Y' THEN
            codestring_rec_.code_g := nvl(code_g_codefill_, codestring_rec_.code_g);
         END IF;
         IF (codestring_rec_.code_h IS NULL AND NVL(no_codepart_val_rec_.code_h,'FALSE')='FALSE') OR override_rec_.code_h = 'Y' THEN
            codestring_rec_.code_h := nvl(code_h_codefill_, codestring_rec_.code_h);
         END IF;
         IF (codestring_rec_.code_i IS NULL AND NVL(no_codepart_val_rec_.code_i,'FALSE')='FALSE') OR override_rec_.code_i = 'Y' THEN
            codestring_rec_.code_i := nvl(code_i_codefill_, codestring_rec_.code_i);
         END IF;
         IF (codestring_rec_.code_j IS NULL AND NVL(no_codepart_val_rec_.code_j,'FALSE')='FALSE') OR override_rec_.code_j = 'Y' THEN
            codestring_rec_.code_j := nvl(code_j_codefill_, codestring_rec_.code_j);
         END IF;
         IF codestring_rec_.process_code IS NULL OR override_rec_.process_code = 'Y' THEN
            codestring_rec_.process_code := nvl(process_code_codefill_, codestring_rec_.process_code);
         END IF;
      END IF;
      IF codestring_rec_.code_f IS NOT NULL AND code_part_  IS NULL
         OR codestring_rec_.code_f IS NOT NULL AND code_part_  = 'F' THEN
         codep_           := 'F';
         code_part_value_ := codestring_rec_.code_f;
         Complete_Code_Part__ ( code_a_codefill_,
                                code_b_codefill_,
                                code_c_codefill_,
                                code_d_codefill_,
                                code_e_codefill_,
                                code_f_codefill_,
                                code_g_codefill_,
                                code_h_codefill_,
                                code_i_codefill_,
                                code_j_codefill_,
                                process_code_codefill_,
                                company_,
                                codep_,
                                code_part_value_ );
         IF (codestring_rec_.code_a IS NULL AND NVL(no_codepart_val_rec_.code_a,'FALSE')='FALSE') OR override_rec_.code_a = 'Y' THEN
            codestring_rec_.code_a := nvl(code_a_codefill_, codestring_rec_.code_a);
         END IF;
         IF (codestring_rec_.code_b IS NULL AND NVL(no_codepart_val_rec_.code_b,'FALSE')='FALSE') OR override_rec_.code_b = 'Y' THEN
            codestring_rec_.code_b := nvl(code_b_codefill_, codestring_rec_.code_b);
         END IF;
         IF (codestring_rec_.code_c IS NULL AND NVL(no_codepart_val_rec_.code_c,'FALSE')='FALSE') OR override_rec_.code_c = 'Y' THEN
            codestring_rec_.code_c := nvl(code_c_codefill_, codestring_rec_.code_c);
         END IF;
         IF (codestring_rec_.code_d IS NULL AND NVL(no_codepart_val_rec_.code_d,'FALSE')='FALSE') OR override_rec_.code_d = 'Y' THEN
            codestring_rec_.code_d := nvl(code_d_codefill_, codestring_rec_.code_d);
         END IF;
         IF (codestring_rec_.code_e IS NULL AND NVL(no_codepart_val_rec_.code_e,'FALSE')='FALSE') OR override_rec_.code_e = 'Y' THEN
            codestring_rec_.code_e := nvl(code_e_codefill_, codestring_rec_.code_e);
         END IF;
         IF (codestring_rec_.code_f IS NULL AND NVL(no_codepart_val_rec_.code_f,'FALSE')='FALSE') OR override_rec_.code_f = 'Y' THEN
            codestring_rec_.code_f := nvl(code_f_codefill_, codestring_rec_.code_f);
         END IF;
         IF (codestring_rec_.code_g IS NULL AND NVL(no_codepart_val_rec_.code_g,'FALSE')='FALSE') OR override_rec_.code_g = 'Y' THEN
            codestring_rec_.code_g := nvl(code_g_codefill_, codestring_rec_.code_g);
         END IF;
         IF (codestring_rec_.code_h IS NULL AND NVL(no_codepart_val_rec_.code_h,'FALSE')='FALSE') OR override_rec_.code_h = 'Y' THEN
            codestring_rec_.code_h := nvl(code_h_codefill_, codestring_rec_.code_h);
         END IF;
         IF (codestring_rec_.code_i IS NULL AND NVL(no_codepart_val_rec_.code_i,'FALSE')='FALSE') OR override_rec_.code_i = 'Y' THEN
            codestring_rec_.code_i := nvl(code_i_codefill_, codestring_rec_.code_i);
         END IF;
         IF (codestring_rec_.code_j IS NULL AND NVL(no_codepart_val_rec_.code_j,'FALSE')='FALSE') OR override_rec_.code_j = 'Y' THEN
            codestring_rec_.code_j := nvl(code_j_codefill_, codestring_rec_.code_j);
         END IF;
         IF codestring_rec_.process_code IS NULL OR override_rec_.process_code = 'Y' THEN
            codestring_rec_.process_code := nvl(process_code_codefill_, codestring_rec_.process_code);
         END IF;
      END IF;
      IF codestring_rec_.code_g IS NOT NULL AND code_part_  IS NULL
         OR codestring_rec_.code_g IS NOT NULL AND code_part_  = 'G' THEN
         codep_           := 'G';
         code_part_value_ := codestring_rec_.code_g;
         Complete_Code_Part__ ( code_a_codefill_,
                                code_b_codefill_,
                                code_c_codefill_,
                                code_d_codefill_,
                                code_e_codefill_,
                                code_f_codefill_,
                                code_g_codefill_,
                                code_h_codefill_,
                                code_i_codefill_,
                                code_j_codefill_,
                                process_code_codefill_,
                                company_,
                                codep_,
                                code_part_value_ );
         IF (codestring_rec_.code_a IS NULL AND NVL(no_codepart_val_rec_.code_a,'FALSE')='FALSE') OR override_rec_.code_a = 'Y' THEN
            codestring_rec_.code_a := nvl(code_a_codefill_, codestring_rec_.code_a);
         END IF;
         IF (codestring_rec_.code_b IS NULL AND NVL(no_codepart_val_rec_.code_b,'FALSE')='FALSE') OR override_rec_.code_b = 'Y' THEN
            codestring_rec_.code_b := nvl(code_b_codefill_, codestring_rec_.code_b);
         END IF;
         IF (codestring_rec_.code_c IS NULL AND NVL(no_codepart_val_rec_.code_c,'FALSE')='FALSE') OR override_rec_.code_c = 'Y' THEN
            codestring_rec_.code_c := nvl(code_c_codefill_, codestring_rec_.code_c);
         END IF;
         IF (codestring_rec_.code_d IS NULL AND NVL(no_codepart_val_rec_.code_d,'FALSE')='FALSE') OR override_rec_.code_d = 'Y' THEN
            codestring_rec_.code_d := nvl(code_d_codefill_, codestring_rec_.code_d);
         END IF;
         IF (codestring_rec_.code_e IS NULL AND NVL(no_codepart_val_rec_.code_e,'FALSE')='FALSE') OR override_rec_.code_e = 'Y' THEN
            codestring_rec_.code_e := nvl(code_e_codefill_, codestring_rec_.code_e);
         END IF;
         IF (codestring_rec_.code_f IS NULL AND NVL(no_codepart_val_rec_.code_f,'FALSE')='FALSE') OR override_rec_.code_f = 'Y' THEN
            codestring_rec_.code_f := nvl(code_f_codefill_, codestring_rec_.code_f);
         END IF;
         IF (codestring_rec_.code_g IS NULL AND NVL(no_codepart_val_rec_.code_g,'FALSE')='FALSE') OR override_rec_.code_g = 'Y' THEN
            codestring_rec_.code_g := nvl(code_g_codefill_, codestring_rec_.code_g);
         END IF;
         IF (codestring_rec_.code_h IS NULL AND NVL(no_codepart_val_rec_.code_h,'FALSE')='FALSE') OR override_rec_.code_h = 'Y' THEN
            codestring_rec_.code_h := nvl(code_h_codefill_, codestring_rec_.code_h);
         END IF;
         IF (codestring_rec_.code_i IS NULL AND NVL(no_codepart_val_rec_.code_i,'FALSE')='FALSE') OR override_rec_.code_i = 'Y' THEN
            codestring_rec_.code_i := nvl(code_i_codefill_, codestring_rec_.code_i);
         END IF;
         IF (codestring_rec_.code_j IS NULL AND NVL(no_codepart_val_rec_.code_j,'FALSE')='FALSE') OR override_rec_.code_j = 'Y' THEN
            codestring_rec_.code_j := nvl(code_j_codefill_, codestring_rec_.code_j);
         END IF;
         IF codestring_rec_.process_code IS NULL OR override_rec_.process_code = 'Y' THEN
            codestring_rec_.process_code := nvl(process_code_codefill_, codestring_rec_.process_code);
         END IF;
      END IF;
      IF codestring_rec_.code_h IS NOT NULL AND code_part_  IS NULL
         OR codestring_rec_.code_h IS NOT NULL AND code_part_  = 'H' THEN
         codep_           := 'H';
         code_part_value_ := codestring_rec_.code_h;
         Complete_Code_Part__ ( code_a_codefill_,
                                code_b_codefill_,
                                code_c_codefill_,
                                code_d_codefill_,
                                code_e_codefill_,
                                code_f_codefill_,
                                code_g_codefill_,
                                code_h_codefill_,
                                code_i_codefill_,
                                code_j_codefill_,
                                process_code_codefill_,
                                company_,
                                codep_,
                                code_part_value_ );
         IF (codestring_rec_.code_a IS NULL AND NVL(no_codepart_val_rec_.code_a,'FALSE')='FALSE') OR override_rec_.code_a = 'Y' THEN
            codestring_rec_.code_a := nvl(code_a_codefill_, codestring_rec_.code_a);
         END IF;
         IF (codestring_rec_.code_b IS NULL AND NVL(no_codepart_val_rec_.code_b,'FALSE')='FALSE') OR override_rec_.code_b = 'Y' THEN
            codestring_rec_.code_b := nvl(code_b_codefill_, codestring_rec_.code_b);
         END IF;
         IF (codestring_rec_.code_c IS NULL AND NVL(no_codepart_val_rec_.code_c,'FALSE')='FALSE') OR override_rec_.code_c = 'Y' THEN
            codestring_rec_.code_c := nvl(code_c_codefill_, codestring_rec_.code_c);
         END IF;
         IF (codestring_rec_.code_d IS NULL AND NVL(no_codepart_val_rec_.code_d,'FALSE')='FALSE') OR override_rec_.code_d = 'Y' THEN
            codestring_rec_.code_d := nvl(code_d_codefill_, codestring_rec_.code_d);
         END IF;
         IF (codestring_rec_.code_e IS NULL AND NVL(no_codepart_val_rec_.code_e,'FALSE')='FALSE') OR override_rec_.code_e = 'Y' THEN
            codestring_rec_.code_e := nvl(code_e_codefill_, codestring_rec_.code_e);
         END IF;
         IF (codestring_rec_.code_f IS NULL AND NVL(no_codepart_val_rec_.code_f,'FALSE')='FALSE') OR override_rec_.code_f = 'Y' THEN
            codestring_rec_.code_f := nvl(code_f_codefill_, codestring_rec_.code_f);
         END IF;
         IF (codestring_rec_.code_g IS NULL AND NVL(no_codepart_val_rec_.code_g,'FALSE')='FALSE') OR override_rec_.code_g = 'Y' THEN
            codestring_rec_.code_g := nvl(code_g_codefill_, codestring_rec_.code_g);
         END IF;
         IF (codestring_rec_.code_h IS NULL AND NVL(no_codepart_val_rec_.code_h,'FALSE')='FALSE') OR override_rec_.code_h = 'Y' THEN
            codestring_rec_.code_h := nvl(code_h_codefill_, codestring_rec_.code_h);
         END IF;
         IF (codestring_rec_.code_i IS NULL AND NVL(no_codepart_val_rec_.code_i,'FALSE')='FALSE') OR override_rec_.code_i = 'Y' THEN
            codestring_rec_.code_i := nvl(code_i_codefill_, codestring_rec_.code_i);
         END IF;
         IF (codestring_rec_.code_j IS NULL AND NVL(no_codepart_val_rec_.code_j,'FALSE')='FALSE') OR override_rec_.code_j = 'Y' THEN
            codestring_rec_.code_j := nvl(code_j_codefill_, codestring_rec_.code_j);
         END IF;
         IF codestring_rec_.process_code IS NULL OR override_rec_.process_code = 'Y' THEN
            codestring_rec_.process_code := nvl(process_code_codefill_, codestring_rec_.process_code);
         END IF;
      END IF;
      IF codestring_rec_.code_i IS NOT NULL AND code_part_  IS NULL
         OR codestring_rec_.code_i IS NOT NULL AND code_part_  = 'I' THEN
         codep_           := 'I';
         code_part_value_ := codestring_rec_.code_i;
         Complete_Code_Part__ ( code_a_codefill_,
                                code_b_codefill_,
                                code_c_codefill_,
                                code_d_codefill_,
                                code_e_codefill_,
                                code_f_codefill_,
                                code_g_codefill_,
                                code_h_codefill_,
                                code_i_codefill_,
                                code_j_codefill_,
                                process_code_codefill_,
                                company_,
                                codep_,
                                code_part_value_ );
         IF (codestring_rec_.code_a IS NULL AND NVL(no_codepart_val_rec_.code_a,'FALSE')='FALSE') OR override_rec_.code_a = 'Y' THEN
            codestring_rec_.code_a := nvl(code_a_codefill_, codestring_rec_.code_a);
         END IF;
         IF (codestring_rec_.code_b IS NULL AND NVL(no_codepart_val_rec_.code_b,'FALSE')='FALSE') OR override_rec_.code_b = 'Y' THEN
            codestring_rec_.code_b := nvl(code_b_codefill_, codestring_rec_.code_b);
         END IF;
         IF (codestring_rec_.code_c IS NULL AND NVL(no_codepart_val_rec_.code_c,'FALSE')='FALSE') OR override_rec_.code_c = 'Y' THEN
            codestring_rec_.code_c := nvl(code_c_codefill_, codestring_rec_.code_c);
         END IF;
         IF (codestring_rec_.code_d IS NULL AND NVL(no_codepart_val_rec_.code_d,'FALSE')='FALSE') OR override_rec_.code_d = 'Y' THEN
            codestring_rec_.code_d := nvl(code_d_codefill_, codestring_rec_.code_d);
         END IF;
         IF (codestring_rec_.code_e IS NULL AND NVL(no_codepart_val_rec_.code_e,'FALSE')='FALSE') OR override_rec_.code_e = 'Y' THEN
            codestring_rec_.code_e := nvl(code_e_codefill_, codestring_rec_.code_e);
         END IF;
         IF (codestring_rec_.code_f IS NULL AND NVL(no_codepart_val_rec_.code_f,'FALSE')='FALSE') OR override_rec_.code_f = 'Y' THEN
            codestring_rec_.code_f := nvl(code_f_codefill_, codestring_rec_.code_f);
         END IF;
         IF (codestring_rec_.code_g IS NULL AND NVL(no_codepart_val_rec_.code_g,'FALSE')='FALSE') OR override_rec_.code_g = 'Y' THEN
            codestring_rec_.code_g := nvl(code_g_codefill_, codestring_rec_.code_g);
         END IF;
         IF (codestring_rec_.code_h IS NULL AND NVL(no_codepart_val_rec_.code_h,'FALSE')='FALSE') OR override_rec_.code_h = 'Y' THEN
            codestring_rec_.code_h := nvl(code_h_codefill_, codestring_rec_.code_h);
         END IF;
         IF (codestring_rec_.code_i IS NULL AND NVL(no_codepart_val_rec_.code_i,'FALSE')='FALSE') OR override_rec_.code_i = 'Y' THEN
            codestring_rec_.code_i := nvl(code_i_codefill_, codestring_rec_.code_i);
         END IF;
         IF (codestring_rec_.code_j IS NULL AND NVL(no_codepart_val_rec_.code_j,'FALSE')='FALSE') OR override_rec_.code_j = 'Y' THEN
            codestring_rec_.code_j := nvl(code_j_codefill_, codestring_rec_.code_j);
         END IF;
         IF codestring_rec_.process_code IS NULL OR override_rec_.process_code = 'Y' THEN
            codestring_rec_.process_code := nvl(process_code_codefill_, codestring_rec_.process_code);
         END IF;
      END IF;
      IF codestring_rec_.code_j IS NOT NULL AND code_part_  IS NULL
         OR codestring_rec_.code_j IS NOT NULL AND code_part_  = 'J' THEN
         codep_           := 'J';
         code_part_value_ := codestring_rec_.code_j;
         Complete_Code_Part__ ( code_a_codefill_,
                                code_b_codefill_,
                                code_c_codefill_,
                                code_d_codefill_,
                                code_e_codefill_,
                                code_f_codefill_,
                                code_g_codefill_,
                                code_h_codefill_,
                                code_i_codefill_,
                                code_j_codefill_,
                                process_code_codefill_,
                                company_,
                                codep_,
                                code_part_value_ );
         IF (codestring_rec_.code_a IS NULL AND NVL(no_codepart_val_rec_.code_a,'FALSE')='FALSE') OR override_rec_.code_a = 'Y' THEN
            codestring_rec_.code_a := nvl(code_a_codefill_, codestring_rec_.code_a);
         END IF;
         IF (codestring_rec_.code_b IS NULL AND NVL(no_codepart_val_rec_.code_b,'FALSE')='FALSE') OR override_rec_.code_b = 'Y' THEN
            codestring_rec_.code_b := nvl(code_b_codefill_, codestring_rec_.code_b);
         END IF;
         IF (codestring_rec_.code_c IS NULL AND NVL(no_codepart_val_rec_.code_c,'FALSE')='FALSE') OR override_rec_.code_c = 'Y' THEN
            codestring_rec_.code_c := nvl(code_c_codefill_, codestring_rec_.code_c);
         END IF;
         IF (codestring_rec_.code_d IS NULL AND NVL(no_codepart_val_rec_.code_d,'FALSE')='FALSE') OR override_rec_.code_d = 'Y' THEN
            codestring_rec_.code_d := nvl(code_d_codefill_, codestring_rec_.code_d);
         END IF;
         IF (codestring_rec_.code_e IS NULL AND NVL(no_codepart_val_rec_.code_e,'FALSE')='FALSE') OR override_rec_.code_e = 'Y' THEN
            codestring_rec_.code_e := nvl(code_e_codefill_, codestring_rec_.code_e);
         END IF;
         IF (codestring_rec_.code_f IS NULL AND NVL(no_codepart_val_rec_.code_f,'FALSE')='FALSE') OR override_rec_.code_f = 'Y' THEN
            codestring_rec_.code_f := nvl(code_f_codefill_, codestring_rec_.code_f);
         END IF;
         IF (codestring_rec_.code_g IS NULL AND NVL(no_codepart_val_rec_.code_g,'FALSE')='FALSE') OR override_rec_.code_g = 'Y' THEN
            codestring_rec_.code_g := nvl(code_g_codefill_, codestring_rec_.code_g);
         END IF;
         IF (codestring_rec_.code_h IS NULL AND NVL(no_codepart_val_rec_.code_h,'FALSE')='FALSE') OR override_rec_.code_h = 'Y' THEN
            codestring_rec_.code_h := nvl(code_h_codefill_, codestring_rec_.code_h);
         END IF;
         IF (codestring_rec_.code_i IS NULL AND NVL(no_codepart_val_rec_.code_i,'FALSE')='FALSE') OR override_rec_.code_i = 'Y' THEN
            codestring_rec_.code_i := nvl(code_i_codefill_, codestring_rec_.code_i);
         END IF;
         IF (codestring_rec_.code_j IS NULL AND NVL(no_codepart_val_rec_.code_j,'FALSE')='FALSE') OR override_rec_.code_j = 'Y' THEN
            codestring_rec_.code_j := nvl(code_j_codefill_, codestring_rec_.code_j);
         END IF;
         IF codestring_rec_.process_code IS NULL OR override_rec_.process_code = 'Y' THEN
            codestring_rec_.process_code := nvl(process_code_codefill_, codestring_rec_.process_code);
         END IF;
      END IF;
END Get_Codestring_Completetion;


@UncheckedAccess
@SecurityCheck Company.UserAuthorized(company_)
FUNCTION Connect_To_Account (
   company_         IN VARCHAR2,
   code_part_       IN VARCHAR2,
   code_part_value_ IN VARCHAR2  )     RETURN VARCHAR2
IS
   CURSOR code_str IS
      SELECT 'X'
      FROM   ACCOUNTING_CODESTR_COMPL_TAB
      WHERE  company         = company_
      AND    code_part       = code_part_
      AND    code_part_value = code_part_value_
      AND    codefill_value IS NOT NULL ;
   dummy_ VARCHAR2(1);
BEGIN
   OPEN  code_str;
   FETCH code_str INTO dummy_;
   CLOSE code_str;
   IF dummy_ = 'X' THEN
      RETURN('T');
   ELSE
      RETURN('F');
   END IF;
END Connect_To_Account;




FUNCTION Get_Complete_CodeString(
   company_          IN VARCHAR2,
   code_part_        IN VARCHAR2,
   code_part_value_  IN VARCHAR2) RETURN VARCHAR2
IS
   code_a_codefill_          VARCHAR2(20);
   code_b_codefill_          VARCHAR2(20);
   code_c_codefill_          VARCHAR2(20);
   code_d_codefill_          VARCHAR2(20);
   code_e_codefill_          VARCHAR2(20);
   code_f_codefill_          VARCHAR2(20);
   code_g_codefill_          VARCHAR2(20);
   code_h_codefill_          VARCHAR2(20);
   code_i_codefill_          VARCHAR2(20);
   code_j_codefill_          VARCHAR2(20);
   process_code_codefill_    VARCHAR2(20);
   code_a_desc_codefill_     VARCHAR2(200);
   code_b_desc_codefill_     VARCHAR2(200);
   code_c_desc_codefill_     VARCHAR2(200);
   code_d_desc_codefill_     VARCHAR2(200);
   code_e_desc_codefill_     VARCHAR2(200);
   code_f_desc_codefill_     VARCHAR2(200);
   code_g_desc_codefill_     VARCHAR2(200);
   code_h_desc_codefill_     VARCHAR2(200);
   code_i_desc_codefill_     VARCHAR2(200);
   code_j_desc_codefill_     VARCHAR2(200);
   completion_attr_          VARCHAR2(200);
BEGIN
   Complete_Code_Part__ ( code_a_codefill_,
                          code_b_codefill_,
                          code_c_codefill_,
                          code_d_codefill_,
                          code_e_codefill_,
                          code_f_codefill_,
                          code_g_codefill_,
                          code_h_codefill_,
                          code_i_codefill_,
                          code_j_codefill_,
                          process_code_codefill_,
                          company_,
                          code_part_,
                          code_part_value_ );

   IF (code_a_codefill_ IS NULL) AND (code_b_codefill_ IS NULL)
                                 AND (code_c_codefill_ IS NULL) 
                                 AND (code_d_codefill_ IS NULL) 
                                 AND (code_e_codefill_ IS NULL) 
                                 AND (code_f_codefill_ IS NULL) 
                                 AND (code_g_codefill_ IS NULL) 
                                 AND (code_h_codefill_ IS NULL) 
                                 AND (code_i_codefill_ IS NULL) 
                                 AND (code_j_codefill_ IS NULL) 
                                 AND (process_code_codefill_ IS NULL) THEN
      RETURN NULL;
   ELSE
      IF (code_a_codefill_ IS NOT NULL) THEN
         Client_SYS.Add_To_Attr('ACCOUNT', code_a_codefill_, completion_attr_);
         code_a_desc_codefill_ := ACCOUNT_API.Get_Description(company_, code_a_codefill_);
         Client_SYS.Add_To_Attr('ACCOUNT_DESC', code_a_desc_codefill_, completion_attr_);
      END IF;
   
      IF (code_b_codefill_ IS NOT NULL) THEN
         Client_SYS.Add_To_Attr('CODE_B', code_b_codefill_, completion_attr_);
         code_b_desc_codefill_ := CODE_B_API.Get_Description(company_, code_b_codefill_);
         Client_SYS.Add_To_Attr('CODE_B_DESC', code_b_desc_codefill_, completion_attr_);
      END IF;
      
      IF (code_c_codefill_ IS NOT NULL) THEN
         Client_SYS.Add_To_Attr('CODE_C', code_c_codefill_, completion_attr_);
         code_c_desc_codefill_ := CODE_C_API.Get_Description(company_, code_c_codefill_);
         Client_SYS.Add_To_Attr('CODE_C_DESC', code_c_desc_codefill_, completion_attr_);
      END IF;
   
      IF (code_d_codefill_ IS NOT NULL) THEN
         Client_SYS.Add_To_Attr('CODE_D', code_d_codefill_, completion_attr_);
         code_d_desc_codefill_ := CODE_D_API.Get_Description(company_, code_d_codefill_);
         Client_SYS.Add_To_Attr('CODE_D_DESC', code_d_desc_codefill_, completion_attr_);
      END IF;
   
      IF (code_e_codefill_ IS NOT NULL) THEN
         Client_SYS.Add_To_Attr('CODE_E', code_e_codefill_, completion_attr_);
         code_e_desc_codefill_ := CODE_E_API.Get_Description(company_, code_e_codefill_);
         Client_SYS.Add_To_Attr('CODE_E_DESC', code_e_desc_codefill_, completion_attr_);
      END IF;
   
      IF (code_f_codefill_ IS NOT NULL) THEN
         Client_SYS.Add_To_Attr('CODE_F', code_f_codefill_, completion_attr_);
         code_f_desc_codefill_ := CODE_F_API.Get_Description(company_, code_f_codefill_);
         Client_SYS.Add_To_Attr('CODE_F_DESC', code_f_desc_codefill_, completion_attr_);
      END IF;
   
      IF (code_g_codefill_ IS NOT NULL) THEN
         Client_SYS.Add_To_Attr('CODE_G', code_g_codefill_, completion_attr_);
         code_g_desc_codefill_ := CODE_G_API.Get_Description(company_, code_g_codefill_);
         Client_SYS.Add_To_Attr('CODE_G_DESC', code_g_desc_codefill_, completion_attr_);
      END IF;
   
      IF (code_h_codefill_ IS NOT NULL) THEN
         Client_SYS.Add_To_Attr('CODE_H', code_h_codefill_, completion_attr_);
         code_h_desc_codefill_ := CODE_H_API.Get_Description(company_, code_h_codefill_);
         Client_SYS.Add_To_Attr('CODE_H_DESC', code_h_desc_codefill_, completion_attr_);
      END IF;
   
      IF (code_i_codefill_ IS NOT NULL) THEN
         Client_SYS.Add_To_Attr('CODE_I', code_i_codefill_, completion_attr_);
         code_i_desc_codefill_ := CODE_I_API.Get_Description(company_, code_i_codefill_);
         Client_SYS.Add_To_Attr('CODE_I_DESC', code_i_desc_codefill_, completion_attr_);
      END IF;
   
      IF (code_j_codefill_ IS NOT NULL) THEN
         Client_SYS.Add_To_Attr('CODE_J', code_j_codefill_, completion_attr_);
         code_j_desc_codefill_ := CODE_J_API.Get_Description(company_, code_j_codefill_);
         Client_SYS.Add_To_Attr('CODE_J_DESC', code_j_desc_codefill_, completion_attr_);
      END IF;
   
      IF (process_code_codefill_ IS NOT NULL) THEN
         Client_SYS.Add_To_Attr('PROCESS_CODE', process_code_codefill_, completion_attr_);   
      END IF;
   END IF;
   RETURN completion_attr_;
END Get_Complete_CodeString;   


@UncheckedAccess
FUNCTION Get_Translated_Code_Fill_Name (
   company_ IN VARCHAR2,
   module_ IN VARCHAR2,
   lu_ IN VARCHAR2,
   attribute_ IN VARCHAR2,
   lang_code_ IN VARCHAR2 DEFAULT NULL ) RETURN VARCHAR2
IS
   text_    VARCHAR2(2000);    
BEGIN
   text_ := Enterp_Comp_Connect_V170_API.Get_Company_Translation(company_, module_, lu_, attribute_,lang_code_, 'NO') ;
   IF ((text_ IS NULL) AND (attribute_ = 'P')) THEN
      text_ := language_sys.Translate_Constant(lu_name_, 'PROCESS_CODE: Process Code');
   END IF;
   RETURN text_;
END Get_Translated_Code_Fill_Name;



PROCEDURE Insert_Code_Parts(
   newrec_ IN OUT ACCOUNTING_CODESTR_COMPL_TAB%ROWTYPE ) 
IS 
   objid_      VARCHAR2(2000);
   objversion_ VARCHAR2(2000);
   attr_       VARCHAR2(2000);
BEGIN
   IF NOT Check_Exist___ (newrec_.company ,newrec_.code_part, newrec_.code_part_value, newrec_.codefill_value) THEN
      newrec_.rowkey := NULL;
      Insert___(objid_, objversion_, newrec_, attr_);
   END IF;
END Insert_Code_Parts;


PROCEDURE Delete_Code_Parts(
   company_            IN VARCHAR2,
   code_part_          IN VARCHAR2,
   code_part_value_    IN VARCHAR2,
   codefill_code_part_ IN VARCHAR2) 
IS
   info_             VARCHAR2(2000);
   objid_            VARCHAR2(2000);
   objversion_       VARCHAR2(2000);
   
BEGIN
   IF Check_Exist___ (company_, code_part_, code_part_value_, codefill_code_part_) THEN
      Get_Id_Version_By_Keys___ (objid_, objversion_, company_,code_part_,code_part_value_,codefill_code_part_);
      Remove__(info_,objid_,objversion_,'DO');
   END IF;
END Delete_Code_Parts;


