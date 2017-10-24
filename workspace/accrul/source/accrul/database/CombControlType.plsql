-----------------------------------------------------------------------------
--
--  Logical unit: CombControlType
--  Component:    ACCRUL
--
--  IFS Developer Studio Template Version 3.0
--
--  Date    Sign    History
--  ------  ------  ---------------------------------------------------------
--  000214  SaCh     Created.
--  000314  SaCh     Corrected Bug # 36712.
--  000316  SaCh     Corrected Bug # 36724.
--  000329  SaCh     Corrected Bug # 70464.
--  000330  SaCh     Corrected Bug # 70484.
--  000512  Bren     Added procedure Validate_Comb_Control_Type__.
--  000912  HiMu     Added General_SYS.Init_Method
--  001004  prtilk   BUG # 15677  Checked General_SYS.Init_Method
--  010917  LiSv     Bug #21794 Corrected. Removed unused procedures and functions, Cct_Exist, Get_Ctrl_Type_Desc, Get_Module, Get_Company
--                      Is_Comb_Type_Allowed and Is_Cct.
--  020219  Shsalk   Add a check to see CCT is enabled.
--  020628  Hecolk   Bug 29068, Corrected. Added a new function Get_Comb_Control_Type_Desc
--  021008  Gawilk   Added new views COMB_CONTROL_TYPE_ECT and COMB_CONTROL_TYPE_PCT.
--                      Added procedures Make_Company, Copy___, Import___ and Export___.
--  040323  Gepelk   2004 SP1 Merge
--  040623  anpelk   FIPR338A2: Unicode Changes.
--  051017  nalslk   BUG #126895 Removed additional delete stmts from Delete___ mehtod.
--  060607  Rufelk   FIPL614A - Modified the places where hardcoded control types were used.
--  061215  GaDaLK   B140017 changed COMB_CONTROL_TYPE, Get_Comb_Type_Info()
--  131031  Umdolk   PBFI-1930, Refactoring
-----------------------------------------------------------------------------

layer Core;

-------------------- PUBLIC DECLARATIONS ------------------------------------


-------------------- PRIVATE DECLARATIONS -----------------------------------


-------------------- LU SPECIFIC IMPLEMENTATION METHODS ---------------------

@Override
PROCEDURE Check_Delete___ (
   remrec_ IN COMB_CONTROL_TYPE_TAB%ROWTYPE )
IS
   check_flag_   VARCHAR2(5);
BEGIN
   check_flag_ := Posting_Ctrl_API.Is_Cct_Used(remrec_.company, remrec_.comb_control_type, remrec_.posting_type);
   IF (check_flag_ = 'TRUE') THEN
      Error_SYS.Record_General(lu_name_, 'CCTISUSED: Combination control type :P1 is used in posting type :P2 in posting control. First delete or change the posting type.', remrec_.comb_control_type, remrec_.posting_type);
   END IF;
   super(remrec_);
END Check_Delete___;

@Override
PROCEDURE Check_Common___ (
   oldrec_ IN     comb_control_type_tab%ROWTYPE,
   newrec_ IN OUT comb_control_type_tab%ROWTYPE,
   indrec_ IN OUT Indicator_Rec,
   attr_   IN OUT VARCHAR2 )
IS
   ctrl_type1_category_ VARCHAR2(20);
   ctrl_type2_category_ VARCHAR2(20);
BEGIN
   IF (indrec_.comb_module) THEN
      indrec_.comb_module := FALSE;
   END IF;   
   IF (indrec_.module1) THEN
      indrec_.module1 := FALSE;
   END IF; 
   IF (indrec_.module2) THEN
      indrec_.module2 := FALSE;
   END IF;   
   
   -- Get values if not in newrec_
   IF (newrec_.comb_module IS NULL) THEN
      newrec_.comb_module := Posting_Ctrl_Posting_Type_API.Get_Module(newrec_.posting_type);
   END IF;
   
   super(oldrec_, newrec_, indrec_, attr_);
   
   POSTING_CTRL_CONTROL_TYPE_API.Exist(newrec_.control_type1,newrec_.module1);
   POSTING_CTRL_CONTROL_TYPE_API.Exist(newrec_.control_type2,newrec_.module2);
   
   ctrl_type1_category_ := Ctrl_Type_Category_API.Encode(Posting_Ctrl_Control_Type_API.Get_Ctrl_Type_Category(newrec_.control_type1, newrec_.module1));
   ctrl_type2_category_ := Ctrl_Type_Category_API.Encode(Posting_Ctrl_Control_Type_API.Get_Ctrl_Type_Category(newrec_.control_type2, newrec_.module2));

   IF (NOT (ctrl_type1_category_ IN ('ORDINARY', 'SYSTEM_DEFINED') AND ctrl_type2_category_ IN ('ORDINARY', 'SYSTEM_DEFINED'))) THEN
      Error_SYS.Record_General(lu_name_, 'NOTALLOWED: Only the Control Types of :P1 and :P2 categories are allowed for combinations', Ctrl_Type_Category_API.Decode('ORDINARY'), Ctrl_Type_Category_API.Decode('SYSTEM_DEFINED'));
   END IF;
   
   
   Posting_Ctrl_Allowed_Comb_API.Check_Allowed_For_Ctrl_Type_(newrec_.posting_type , newrec_.control_type1 );
   Posting_Ctrl_Allowed_Comb_API.Check_Allowed_For_Ctrl_Type_(newrec_.posting_type , newrec_.control_type2 );
   
END Check_Common___;


@Override
PROCEDURE Check_Insert___ (
   newrec_ IN OUT comb_control_type_tab%ROWTYPE,
   indrec_ IN OUT Indicator_Rec,
   attr_   IN OUT VARCHAR2 )
IS

   control_type1_       VARCHAR2(10);
   control_type2_       VARCHAR2(10);
   comb_type_exist_     VARCHAR2(10);
BEGIN   
   -- Get values if not in newrec_   
   IF (newrec_.module1 IS NULL) THEN
      newrec_.module1 := Posting_Ctrl_Control_Type_API.Get_Control_Type_Module(newrec_.control_type1);
   END IF;
   IF (newrec_.module2 IS NULL) THEN
      newrec_.module2 := Posting_Ctrl_Control_Type_API.Get_Control_Type_Module(newrec_.control_type2);
   END IF;   
   
   super(newrec_, indrec_, attr_);
   
   Validate_Comb_Control_Type__ (control_type1_, control_type2_, comb_type_exist_, newrec_.company, newrec_.comb_control_type);

   IF (comb_type_exist_ = 'YES') THEN
      IF (newrec_.control_type1 != control_type1_ ) THEN
         Error_SYS.Record_General(lu_name_, 'VALCTRTYPE1: Control Type 1 should be :P1 as Combination Control Type :P2 already exists',control_type1_,newrec_.comb_control_type);
      END IF;
      IF (newrec_.control_type2 != control_type2_ ) THEN
         Error_SYS.Record_General(lu_name_, 'VALCTRTYPE2: Control Type 2 should be :P1 as Combination Control Type :P2 already exists',control_type2_,newrec_.comb_control_type);
      END IF;
   END IF;

   IF (Posting_Ctrl_Control_Type_API.Check_Exist(newrec_.comb_control_type)) THEN
      Error_SYS.Record_General(lu_name_, 'COMBEXIST: Combination Control Type :P1 already exists as a Control Type.',newrec_.comb_control_type);
   END IF;

   IF (newrec_.control_type1 = newrec_.control_type2) THEN
      Error_SYS.Record_General(lu_name_, 'CTRTYPESEQUAL: Two different control types must be selected for combination');
   END IF;
       
   IF (Posting_Ctrl_Posting_Type_API.Cct_Enabled(newrec_.posting_type) = 'FALSE') THEN
      Error_SYS.Record_General(lu_name_, 'POSTYPNOTALO: Posting Type :P1 is not allowed to use in Combination Control Types', newrec_.posting_type);
   END IF;
END Check_Insert___;


@Override
PROCEDURE Check_Update___ (
   oldrec_ IN     comb_control_type_tab%ROWTYPE,
   newrec_ IN OUT comb_control_type_tab%ROWTYPE,
   indrec_ IN OUT Indicator_Rec,
   attr_   IN OUT VARCHAR2 )
IS
   check_flag_          VARCHAR2(5);
BEGIN  
   super(oldrec_, newrec_, indrec_, attr_);
      
   IF (oldrec_.control_type1 <> newrec_.control_type1) OR (oldrec_.control_type2 <> newrec_.control_type2) THEN
     check_flag_ := Posting_Ctrl_API.Is_Cct_Used(newrec_.company, newrec_.comb_control_type, newrec_.posting_type);
     IF (check_flag_ = 'TRUE') THEN
        Error_SYS.Record_General(lu_name_, 'CCTISUSED: Combination control type :P1 is used in posting type :P2 in posting control. First delete or change the posting type.', newrec_.comb_control_type, newrec_.posting_type);
     END IF;
   END IF;

   IF (newrec_.control_type1 = newrec_.control_type2) THEN
      Error_SYS.Record_General(lu_name_, 'CTRTYPESEQUAL: Two different control types must be selected for combination');
   END IF;

END Check_Update___;


-------------------- LU SPECIFIC PRIVATE METHODS ----------------------------

PROCEDURE Validate_Comb_Control_Type__ (
   control_type1_        OUT VARCHAR2,
   control_type2_        OUT VARCHAR2,
   comb_type_exist_      OUT VARCHAR2,
   company_              IN  VARCHAR2,
   comb_control_type_    IN  VARCHAR2 )
IS
   cct_        VARCHAR2(10);
   ct1_        VARCHAR2(10);
   ct2_        VARCHAR2(10);

   CURSOR Get_Control IS
      SELECT Comb_Control_Type, Control_Type1, Control_Type2
        FROM Comb_Control_Type_Tab
       WHERE Company = company_
         AND Comb_Control_Type = comb_control_type_;
BEGIN
   OPEN Get_Control;
   FETCH Get_Control INTO cct_, ct1_, ct2_;
   IF (Get_Control%FOUND) THEN
      comb_type_exist_ := 'YES';
      control_type1_ :=    ct1_;
      control_type2_ :=    ct2_;
   ELSE
      comb_type_exist_ := 'NO';
      control_type1_ :=    NULL;
      control_type2_ :=    NULL;
   END IF;
   CLOSE Get_Control;
END Validate_Comb_Control_Type__;


-------------------- LU SPECIFIC PROTECTED METHODS --------------------------

-------------------- LU SPECIFIC PUBLIC METHODS -----------------------------

PROCEDURE Get_Control_Type1_Type2 (
   control_type1_        OUT VARCHAR2,
   control_type2_        OUT VARCHAR2,
   company_              IN  VARCHAR2,
   posting_type_         IN  VARCHAR2,
   comb_control_type_    IN  VARCHAR2 )
IS
   CURSOR Get_Type IS
      SELECT control_type1, control_type2
        FROM Comb_Control_Type_Tab
       WHERE company = company_
         AND posting_type = posting_type_
         AND comb_control_type = comb_control_Type_;
BEGIN

   OPEN Get_Type;
   FETCH Get_Type INTO control_type1_, control_type2_;
   CLOSE Get_Type;
END Get_Control_Type1_Type2;     


@UncheckedAccess
PROCEDURE Get_Comb_Type_Info (
   control_type1_          OUT VARCHAR2,
   control_type2_          OUT VARCHAR2,
   control_type1_desc_     OUT VARCHAR2,
   control_type2_desc_     OUT VARCHAR2,
   control_type1_module_   OUT VARCHAR2,
   control_type2_module_   OUT VARCHAR2,
   company_                IN  VARCHAR2,
   posting_type_           IN  VARCHAR2,
   comb_control_type_      IN  VARCHAR2 )
IS
   CURSOR Comb_Type_Info_ IS
      SELECT   Control_Type1, Control_Type2, Module1, Module2
        FROM   Comb_Control_Type
       WHERE   company = company_
         AND   posting_type = posting_type_
         AND   comb_control_type = comb_control_Type_;

BEGIN
   OPEN Comb_Type_Info_;
   FETCH Comb_Type_Info_ INTO control_type1_, control_type2_, control_type1_module_, control_type2_module_;
   Posting_Ctrl_Control_Type_API.Get_Description(control_type1_desc_, control_type1_, control_type1_module_, company_);
   Posting_Ctrl_Control_Type_API.Get_Description(control_type2_desc_, control_type2_, control_type2_module_, company_);
   CLOSE Comb_Type_Info_;
END Get_Comb_Type_Info;


PROCEDURE Remove_Comb_Control_Type (
   company_                IN VARCHAR2,
   posting_type_           IN VARCHAR2,
   comb_control_type_      IN VARCHAR2 )
IS
   comb_ctrl_exist_        NUMBER;
   CURSOR check_rec IS
      SELECT 1
      FROM   comb_control_type_tab
      WHERE  company           = company_
      AND    posting_type      = posting_type_
      AND    comb_control_type = comb_control_type_;

BEGIN
   OPEN check_rec;
   FETCH check_rec INTO comb_ctrl_exist_;
   IF check_rec%FOUND THEN
      CLOSE check_rec;
      DELETE FROM comb_control_type_tab
      WHERE  company           = company_
      AND    posting_type      = posting_type_
      AND    comb_control_type = comb_control_type_;
   ELSE
      CLOSE check_rec;
   END IF;
END Remove_Comb_Control_Type;


