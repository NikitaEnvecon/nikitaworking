-----------------------------------------------------------------------------
--
--  Logical unit: AccountingYear
--  Component:    ACCRUL
--
--  IFS Developer Studio Template Version 3.0
--
--  Date    Sign    History
--  ------  ------  ---------------------------------------------------------
--  991227  BAMA     Created
--  000302  Uma      Corrected Bug Id# 32901.
--  000908  HiMu     Added General_SYS.Init_Method
--  001206  LISV     For new Create Company concept added new view accounting_year_ect and accounting_year_pct.
--                   Added procedures Make_Company, Copy___, Import___ and Export___.
--  010816  OVJOSE   Added Create Company translation method Create_Company_Translations___
--  010905  Assalk   Added Set_Consolidated_Flag,Clear_Consolidated_Flag.
--  010905  JeGu     Simplified functions: Set_Consolidated_Flag, Clear_Consolidated_Flag,
--                   Added column open_bal_consolidated_db to view ACC_YEAR
--  020102  THSRLK   IID 20001 Enhancement of Update Company. Changes inside make_company method
--                   Changed Import___, Export___ and Copy___ methods to use records
--  020312  ovjose   Removed Create Company translation method Create_Company_Translations___
--  021001  Nimalk   Removed usage of the view Company_Finance_Auth in ACC_YEAR,
--                   YEAR_END_FROM_YEAR_LOV,YEAR_END_TO_YEAR_LOV view
--                   and replaced by view Company_Finance_Auth1 using EXISTS caluse instead of joins
--  021106  KuPelk   IID ESFI110N Year End Accounting.
--  021127  kuPelk   Bug# 91592 Corrected by removing Execute_Update method .
--  021204  KuPelk   IID ESFI110N .Added new method as Close_Opened_Year.
--  021218  KuPelk   IID ESFI110N .Added new method as  Update_Year_Data__.
--  021218  GePelk   IID ESFI110N .Added new method as Change_Blance_State__.
--  040623  anpelk   FIPR338A2: Unicode Changes.
--  041005  WAPELK   Bug 45325 Merged.
--  090303  Jaralk   Bug 80877 Added IF condition in Open_Up_Closed_Year () 
--                   to check if the successive year is open before opening the current year
--  090309  WITOPL   Bug 82373, SKwP-2 - Final Closing of Period - Finally Closed Year Added
--  090807  Maaylk   Bug 81730. Added method Check_Exist()
--  100420  Nsillk   Modifications done to support update Company
--  110415  Sacalk   EASTONE-15173, Modified the view ACC_YEAR
--  110518  RUFELK   EASTONE-20019, Modified the Prepare_Insert___() method.
--  110719  Sacalk   FIDEAGLE-307 , Merged LCS Bug 96469, corrected in Prepare_insert___
--  130808  NIANLK   CAHOOK-1280: Added new check to validate Account Year leng
--  131111  Umdolk   PBFI-1318, Refactoring.
--  141123  ShFrlk   PRMF-3684, Corrected. Error due to records in [CURSOR get_period_info] not getting sorted at certain instances. Therefore, sorted by Accounting_Year and Accounting_Period.
--  160310  Clstlk   Bug 127629, Added new method Find_Next_Available_Year().
-----------------------------------------------------------------------------

layer Core;

-------------------- PUBLIC DECLARATIONS ------------------------------------

TYPE Year_Period_Rec IS RECORD
(
   accounting_year     ACCOUNTING_PERIOD_TAB.ACCOUNTING_YEAR%TYPE,
   accounting_period   ACCOUNTING_PERIOD_TAB.ACCOUNTING_PERIOD%TYPE,
   date_from           ACCOUNTING_PERIOD_TAB.DATE_FROM%TYPE,
   date_until          ACCOUNTING_PERIOD_TAB.DATE_UNTIL%TYPE,
   period_status_db    ACCOUNTING_PERIOD_TAB.PERIOD_STATUS%TYPE,        
   period_type_db      ACCOUNTING_PERIOD_TAB.YEAR_END_PERIOD%TYPE
);

TYPE Year_Period_Tab IS TABLE OF Year_Period_Rec INDEX BY BINARY_INTEGER;


-------------------- PRIVATE DECLARATIONS -----------------------------------


-------------------- LU SPECIFIC IMPLEMENTATION METHODS ---------------------

PROCEDURE Import___ (
   crecomp_rec_ IN Enterp_Comp_Connect_V170_API.Crecomp_Lu_Public_Rec )
IS
   attr_          VARCHAR2(2000);
   objid_         VARCHAR2(2000);
   objversion_    VARCHAR2(2000);
   newrec_        ACCOUNTING_YEAR_TAB%ROWTYPE;
   empty_rec_     ACCOUNTING_YEAR_TAB%ROWTYPE;
   msg_           VARCHAR2(2000);
   i_             NUMBER := 0;
   update_by_key_ BOOLEAN;
   any_rows_      BOOLEAN := FALSE;
   indrec_        Indicator_Rec;
   CURSOR get_data IS
      SELECT N1, C1, C2, C3
      FROM   Create_Company_Template_Pub src
      WHERE  component = 'ACCRUL'
      AND    lu    = lu_name_
      AND    template_id = crecomp_rec_.template_id
      AND    version     = crecomp_rec_.version
      AND    NOT EXISTS (SELECT 1 
                         FROM accounting_year_tab dest
                         WHERE dest.company = crecomp_rec_.company
                         AND dest.accounting_year = src.N1);
BEGIN
   update_by_key_ := Enterp_Comp_Connect_V170_API.Use_Keys(module_, lu_name_, crecomp_rec_);
   any_rows_ := Exist_Any___(crecomp_rec_.company);

   IF (NOT any_rows_) AND (crecomp_rec_.user_defined = 'TRUE') THEN
      FOR k in 0..crecomp_rec_.number_of_years-1 LOOP
         i_ := i_ + 1;
         @ApproveTransactionStatement(2014-03-25,dipelk)
         SAVEPOINT make_company_insert;
         BEGIN
            newrec_.company           := crecomp_rec_.company;
            newrec_.accounting_year   := crecomp_rec_.acc_year + k;
            newrec_.opening_balances  := 'N';
            newrec_.closing_balances  := 'N';
            newrec_.year_status       := 'O';
            Client_SYS.Clear_Attr(attr_);
            indrec_ := Get_Indicator_Rec___(newrec_);
            Check_Insert___(newrec_, indrec_, attr_);
            Insert___(objid_, objversion_, newrec_, attr_);
         EXCEPTION
            WHEN OTHERS THEN
               msg_ := SQLERRM;
               @ApproveTransactionStatement(2014-03-25,dipelk)
               ROLLBACK TO make_company_insert;
               Enterp_Comp_Connect_V170_API.Log_Logging(crecomp_rec_.company, module_, 'ACCOUNTING_YEAR_API', 'Error', msg_);
         END;
      END LOOP;
      IF (i_ = 0) THEN
         msg_ := Language_SYS.Translate_Constant(lu_name_, 'NODATAFOUND: No Data Found');
         Enterp_Comp_Connect_V170_API.Log_Logging(crecomp_rec_.company, module_, 'ACCOUNTING_YEAR_API', 'CreatedSuccessfully', msg_);                                                   
      ELSE
         IF (msg_ IS NULL) THEN
            Enterp_Comp_Connect_V170_API.Log_Logging(crecomp_rec_.company, module_, 'ACCOUNTING_YEAR_API', 'CreatedSuccessfully');                  
         ELSE
            Enterp_Comp_Connect_V170_API.Log_Logging(crecomp_rec_.company, module_, 'ACCOUNTING_YEAR_API', 'CreatedWithErrors');                     
         END IF;                     
      END IF;
   ELSE
      IF ( (update_by_key_ AND (Company_Finance_API.Get_User_Def_Cal(crecomp_rec_.company) = 'FALSE')) OR 
         (NOT any_rows_) ) THEN

         FOR rec_ IN get_data LOOP
            i_ := i_ + 1;
            @ApproveTransactionStatement(2014-03-25,dipelk)
            SAVEPOINT make_company_insert;
            BEGIN

               newrec_ := empty_rec_;

               newrec_.company           := crecomp_rec_.company;
               newrec_.accounting_year   := rec_.n1;
               newrec_.opening_balances  := rec_.c1;
               newrec_.closing_balances  := rec_.c2;
               newrec_.year_status       := rec_.c3;
               Client_SYS.Clear_Attr(attr_);
               indrec_ := Get_Indicator_Rec___(newrec_);
               Check_Insert___(newrec_, indrec_, attr_);
               Insert___(objid_, objversion_, newrec_, attr_);
            EXCEPTION
               WHEN OTHERS THEN
                  msg_ := SQLERRM;
                  @ApproveTransactionStatement(2014-03-25,dipelk)
                  ROLLBACK TO make_company_insert;
                  Enterp_Comp_Connect_V170_API.Log_Logging(crecomp_rec_.company, module_, 'ACCOUNTING_YEAR_API', 'Error', msg_);                                                   
            END;
         END LOOP;
         IF (i_ = 0) THEN
            msg_ := Language_SYS.Translate_Constant(lu_name_, 'NODATAFOUND: No Data Found');
            Enterp_Comp_Connect_V170_API.Log_Logging(crecomp_rec_.company, module_, 'ACCOUNTING_YEAR_API', 'CreatedSuccessfully', msg_);                                                   
         ELSE
            IF (msg_ IS NULL) THEN
               Enterp_Comp_Connect_V170_API.Log_Logging(crecomp_rec_.company, module_, 'ACCOUNTING_YEAR_API', 'CreatedSuccessfully');                  
            ELSE
               Enterp_Comp_Connect_V170_API.Log_Logging(crecomp_rec_.company, module_, 'ACCOUNTING_YEAR_API', 'CreatedWithErrors');                     
            END IF;                     
         END IF;
      ELSE
         -- this statement is to add to the log that the Create company process for LUs is finished even if
         -- has been performed
         Enterp_Comp_Connect_V170_API.Log_Logging(crecomp_rec_.company, module_, 'ACCOUNTING_YEAR_API', 'CreatedSuccessfully');
      END IF;
   END IF;
EXCEPTION
   WHEN OTHERS THEN
      msg_ := SQLERRM;
      Enterp_Comp_Connect_V170_API.Log_Logging(crecomp_rec_.company, module_, 'ACCOUNTING_YEAR_API', 'Error', msg_);
      Enterp_Comp_Connect_V170_API.Log_Logging(crecomp_rec_.company, module_, 'ACCOUNTING_YEAR_API', 'CreatedWithErrors');
END Import___;


PROCEDURE Copy___ (
   crecomp_rec_   IN Enterp_Comp_Connect_V170_API.Crecomp_Lu_Public_Rec )
IS
   attr_          VARCHAR2(2000);
   objid_         VARCHAR2(2000);
   objversion_    VARCHAR2(2000);
   newrec_        ACCOUNTING_YEAR_TAB%ROWTYPE;
   empty_rec_     ACCOUNTING_YEAR_TAB%ROWTYPE;
   msg_           VARCHAR2(2000);
   i_             NUMBER := 0;
   update_by_key_ BOOLEAN;
   any_rows_      BOOLEAN := FALSE;
   indrec_        Indicator_Rec;
   CURSOR get_data IS
      SELECT accounting_year
      FROM   accounting_year_tab src
      WHERE  company = crecomp_rec_.old_company
      AND    NOT EXISTS (SELECT 1 
                         FROM accounting_year_tab dest
                         WHERE dest.company = crecomp_rec_.company
                         AND dest.accounting_year = src.accounting_year);

BEGIN
   update_by_key_ := Enterp_Comp_Connect_V170_API.Use_Keys(module_, lu_name_, crecomp_rec_);
   any_rows_ := Exist_Any___(crecomp_rec_.company);

   IF (NOT any_rows_) AND (crecomp_rec_.user_defined = 'TRUE') THEN
      FOR k in 0..crecomp_rec_.number_of_years-1 LOOP
         i_ := i_ + 1;
         @ApproveTransactionStatement(2014-03-25,dipelk)
         SAVEPOINT make_company_insert;
         BEGIN
            newrec_.company           := crecomp_rec_.company;
            newrec_.accounting_year   := crecomp_rec_.acc_year + k;
            newrec_.opening_balances  := 'N';
            newrec_.closing_balances  := 'N';
            newrec_.year_status       := 'O';
            Client_SYS.Clear_Attr(attr_);
            indrec_ := Get_Indicator_Rec___(newrec_);
            Check_Insert___(newrec_, indrec_, attr_);
            Insert___(objid_, objversion_, newrec_, attr_);
         EXCEPTION
            WHEN OTHERS THEN
               msg_ := SQLERRM;
               @ApproveTransactionStatement(2014-03-25,dipelk)
               ROLLBACK TO make_company_insert;
               Enterp_Comp_Connect_V170_API.Log_Logging(crecomp_rec_.company, module_, 'ACCOUNTING_YEAR_API', 'Error', msg_);
         END;
      END LOOP;
      IF (i_ = 0) THEN
         msg_ := Language_SYS.Translate_Constant(lu_name_, 'NODATAFOUND: No Data Found');
         Enterp_Comp_Connect_V170_API.Log_Logging(crecomp_rec_.company, module_, 'ACCOUNTING_YEAR_API', 'CreatedSuccessfully', msg_);                                                   
      ELSE
         IF (msg_ IS NULL) THEN
            Enterp_Comp_Connect_V170_API.Log_Logging(crecomp_rec_.company, module_, 'ACCOUNTING_YEAR_API', 'CreatedSuccessfully');                  
         ELSE
            Enterp_Comp_Connect_V170_API.Log_Logging(crecomp_rec_.company, module_, 'ACCOUNTING_YEAR_API', 'CreatedWithErrors');                     
         END IF;                     
      END IF;
   ELSE
      IF ( (update_by_key_ AND (Company_Finance_API.Get_User_Def_Cal(crecomp_rec_.company) = 'FALSE')) OR 
         (NOT any_rows_) ) THEN

         FOR rec_ IN get_data LOOP
            i_ := i_ + 1;
            @ApproveTransactionStatement(2014-03-25,dipelk)
            SAVEPOINT make_company_insert;
            BEGIN

               newrec_ := empty_rec_;
               
               newrec_.company           := crecomp_rec_.company;
               newrec_.accounting_year   := rec_.accounting_year;
               newrec_.opening_balances  := 'N';
               newrec_.closing_balances  := 'N';
               newrec_.year_status       := 'O';
               Client_SYS.Clear_Attr(attr_);
               indrec_ := Get_Indicator_Rec___(newrec_);
               Check_Insert___(newrec_, indrec_, attr_);
               Insert___(objid_, objversion_, newrec_, attr_);

            EXCEPTION
               WHEN OTHERS THEN
                  msg_ := SQLERRM;
                  @ApproveTransactionStatement(2014-03-25,dipelk)
                  ROLLBACK TO make_company_insert;
                  Enterp_Comp_Connect_V170_API.Log_Logging(crecomp_rec_.company, module_, 'ACCOUNTING_YEAR_API', 'Error', msg_);                                                   
            END;
         END LOOP;
         IF (i_ = 0) THEN
            msg_ := Language_SYS.Translate_Constant(lu_name_, 'NODATAFOUND: No Data Found');
            Enterp_Comp_Connect_V170_API.Log_Logging(crecomp_rec_.company, module_, 'ACCOUNTING_YEAR_API', 'CreatedSuccessfully', msg_);                                                   
         ELSE
            IF (msg_ IS NULL) THEN
               Enterp_Comp_Connect_V170_API.Log_Logging(crecomp_rec_.company, module_, 'ACCOUNTING_YEAR_API', 'CreatedSuccessfully');                  
            ELSE
               Enterp_Comp_Connect_V170_API.Log_Logging(crecomp_rec_.company, module_, 'ACCOUNTING_YEAR_API', 'CreatedWithErrors');                     
            END IF;                     
         END IF;
      ELSE
         -- this statement is to add to the log that the Create company process for LUs is finished even if
         -- nothing has been performed
         Enterp_Comp_Connect_V170_API.Log_Logging(crecomp_rec_.company, module_, 'ACCOUNTING_YEAR_API', 'CreatedSuccessfully');
      END IF;
   END IF;
EXCEPTION
   WHEN OTHERS THEN
      msg_ := SQLERRM;
      Enterp_Comp_Connect_V170_API.Log_Logging(crecomp_rec_.company, module_, 'ACCOUNTING_YEAR_API', 'Error', msg_);
      Enterp_Comp_Connect_V170_API.Log_Logging(crecomp_rec_.company, module_, 'ACCOUNTING_YEAR_API', 'CreatedWithErrors');
END Copy___;


PROCEDURE Export___ (
   crecomp_rec_   IN Enterp_Comp_Connect_V170_API.Crecomp_Lu_Public_Rec )
IS
   pub_rec_       Enterp_Comp_Connect_V170_API.Tem_Public_Rec;
   i_              NUMBER := 1;

   CURSOR get_data IS
      SELECT accounting_year
      FROM   accounting_year_tab
      WHERE  company = crecomp_rec_.company;
BEGIN
   FOR pctrec_ IN get_data LOOP
      pub_rec_.template_id := crecomp_rec_.template_id;
      pub_rec_.component := module_;
      pub_rec_.version  := crecomp_rec_.version;
      pub_rec_.lu := lu_name_;
      pub_rec_.item_id := i_;
      pub_rec_.n1 := pctrec_.accounting_year;
      pub_rec_.c1 := 'N';
      pub_rec_.c2 := 'N';
      pub_rec_.c3 := 'O'; 
      Enterp_Comp_Connect_V170_API.Tem_Insert_Detail_Data(pub_rec_);
      i_ := i_ + 1;
   END LOOP;
END Export___;


PROCEDURE Get_Year_Periods___(
   year_periods_            OUT Year_Period_Tab,
   company_                 IN  VARCHAR2,
   accounting_year_from_    IN  NUMBER,
   accounting_period_from_  IN  NUMBER,
   accounting_year_until_   IN  NUMBER,
   accounting_period_until_ IN  NUMBER, 
   include_year_end_        IN  BOOLEAN DEFAULT TRUE)
IS 
   yp_from_           VARCHAR2(20);
   yp_until_          VARCHAR2(20);
   include_ye_        VARCHAR2(1) := 'Y';
   period_from_       NUMBER;
   period_until_      NUMBER;

   CURSOR get_period_info IS
      SELECT accounting_year,
             accounting_period,
             date_from,
             date_until,
             period_status, 
             year_end_period
      FROM ACCOUNTING_PERIOD_TAB
      WHERE company    = company_
      AND   ((Accounting_Period_API.Get_Year_Period__(accounting_year, accounting_period) >= yp_from_)  AND
             (Accounting_Period_API.Get_Year_Period__(accounting_year, accounting_period) <= yp_until_)
            )
      AND   (include_ye_ = 'Y' OR (include_ye_ = 'N' AND year_end_period = 'ORDINARY'))
      ORDER BY accounting_year, accounting_period;
BEGIN   
   --validations
   Company_Finance_API.Exist(company_);
   Exist(company_, accounting_year_from_);
   Exist(company_, accounting_year_until_);
   
   period_from_  := Assign_Period___(company_, accounting_year_from_, accounting_period_from_, 'MIN');
   period_until_ := Assign_Period___(company_, accounting_year_until_, accounting_period_until_, 'MAX');

   Accounting_Period_API.Exist(company_, accounting_year_from_, period_from_);
   Accounting_Period_API.Exist(company_, accounting_year_until_, period_until_);
   yp_from_  := Accounting_Period_API.Get_Year_Period__(accounting_year_from_, period_from_);
   yp_until_ := Accounting_Period_API.Get_Year_Period__(accounting_year_until_, period_until_);
   IF (yp_from_ > yp_until_) THEN
      Error_SYS.Appl_General(lu_name_,
                             'FROMGTUNTIL: The from year and period is greater than the until year and period');
   END IF;
   
   -- get data into out table
   IF (NOT include_year_end_) THEN
      include_ye_ := 'N';
   END IF;

   OPEN get_period_info;
   FETCH get_period_info BULK COLLECT INTO year_periods_;
   CLOSE get_period_info;

END Get_Year_Periods___;


FUNCTION Assign_Period___(
   company_             IN VARCHAR2,
   accounting_year_     IN NUMBER,
   supplied_acc_period_ IN NUMBER,
   min_or_max_          IN VARCHAR2) RETURN NUMBER
IS
BEGIN
   
   IF (supplied_acc_period_ IS NOT NULL) THEN
      RETURN supplied_acc_period_;
   END IF;

   IF (   min_or_max_ = 'MIN') THEN
      RETURN (Accounting_Period_API.Get_Min_Period(company_, accounting_year_));
   ELSIF (min_or_max_ = 'MAX') THEN 
      RETURN (Accounting_Period_API.Get_Max_Period(company_, accounting_year_));
   ELSE
      RETURN (Accounting_Period_API.Get_Max_Period(company_, accounting_year_));
   END IF;
   
END Assign_Period___;


@Override
PROCEDURE Prepare_Insert___ (
   attr_ IN OUT VARCHAR2 )
IS
BEGIN
   super(attr_);
   Client_SYS.Add_To_Attr('OPENING_BALANCES', Acc_Year_Op_Bal_API.Decode('N'), attr_);
   Client_SYS.Add_To_Attr('CLOSING_BALANCES', Acc_Year_Cl_Bal_API.Decode('N'), attr_);
   Client_SYS.Add_To_Attr('YEAR_STATUS', Acc_Year_Status_API.Decode('O'), attr_);
   Client_SYS.Add_To_Attr('YEAR_STATUS_DB', 'O', attr_);
   Client_SYS.Add_To_Attr('OPEN_BAL_CONSOLIDATED_DB', 'N', attr_);
END Prepare_Insert___;


@Override
PROCEDURE Insert___ (
   objid_      OUT    VARCHAR2,
   objversion_ OUT    VARCHAR2,
   newrec_     IN OUT ACCOUNTING_YEAR_TAB%ROWTYPE,
   attr_       IN OUT VARCHAR2 )
IS
   temp_       ACCOUNTING_YEAR_TAB.open_bal_consolidated%TYPE; 
BEGIN
   temp_ := newrec_.open_bal_consolidated;
   newrec_.open_bal_consolidated := NVL(newrec_.open_bal_consolidated,'N');
   super(objid_, objversion_, newrec_, attr_);
   newrec_.open_bal_consolidated :=  temp_;
EXCEPTION
   WHEN dup_val_on_index THEN
      Error_SYS.Record_Exist(lu_name_);
END Insert___;


@Override
PROCEDURE Check_Delete___ (
   remrec_ IN ACCOUNTING_YEAR_TAB%ROWTYPE )
IS
   dummy_  BOOLEAN;
BEGIN
   dummy_ := ACCOUNTING_YEAR_API.Period_Delete_Allowed(remrec_.company,remrec_.accounting_year);   
   super(remrec_);
END Check_Delete___;


@Override
PROCEDURE Check_Insert___ (
   newrec_ IN OUT accounting_year_tab%ROWTYPE,
   indrec_ IN OUT Indicator_Rec,
   attr_   IN OUT VARCHAR2 )
IS
   name_  VARCHAR2(30);
   value_ VARCHAR2(4000);
BEGIN
   super(newrec_, indrec_, attr_);
   IF ( LENGTH(newrec_.accounting_year) != 4 ) THEN
      Error_SYS.Appl_General(lu_name_, 'ACCYEARNOTMACTCH: The accounting year should consist of four characters.');
   END IF;      
EXCEPTION
   WHEN value_error THEN
      Error_SYS.Item_Format(lu_name_, name_, value_);
END Check_Insert___;


@Override
PROCEDURE Raise_Record_Not_Exist___ (
   company_         IN     VARCHAR2,
   accounting_year_ IN     NUMBER )
IS
BEGIN
   Error_SYS.Record_Not_Exist(lu_name_,  
                              'YEARNOTEXIST: Accounting year ":P1" does not exist in company ":P2"',
                               TO_CHAR(accounting_year_),
                               company_);
   super(company_, accounting_year_);
   --Add post-processing code here
END Raise_Record_Not_Exist___;




-------------------- LU SPECIFIC PRIVATE METHODS ----------------------------

PROCEDURE Open_Up_Closed_Year__ (
   company_             IN VARCHAR2,
   accounting_year_     IN NUMBER,
   closing_balances_db_ IN VARCHAR2,
   cl_rollback_vou_no_  IN VARCHAR2,
   op_rollback_vou_no_  IN VARCHAR2 )
IS
  year_data_   ACC_YEAR%ROWTYPE ;
  attr_        VARCHAR2(2000);
  info_        VARCHAR2(2000);

BEGIN
   Get_Id_Version_By_Keys___(year_data_.objid,
                             year_data_.objversion,
                             company_,
                             accounting_year_);
   IF (year_data_.objid IS NULL) THEN
      Error_SYS.Record_General( lu_name_, 'NO_ACCYEAR: Not a valid Accounting Year' );
   END IF;

   Client_SYS.Clear_Attr(attr_);
   Client_SYS.Add_To_Attr('YEAR_STATUS_DB','O', attr_);

   ACCOUNTING_YEAR_API.Modify__ (info_ ,year_data_.objid, year_data_.objversion, attr_,'DO' );

END Open_Up_Closed_Year__;


PROCEDURE Final_Year_End__ (
   company_ IN VARCHAR2,
   from_year_ IN VARCHAR2,
   to_year_ IN VARCHAR2,
   closing_balances_db_ IN VARCHAR2 )
IS
   from_year_data_   ACC_YEAR%ROWTYPE ;
   to_year_data_     ACC_YEAR%ROWTYPE ;
   attr_             VARCHAR2(2000);
   info_             VARCHAR2(2000);

BEGIN
   Get_Id_Version_By_Keys___(from_year_data_.objid,
                             from_year_data_.objversion,
                             company_,
                             from_year_);
   IF (from_year_data_.objid IS NULL) THEN
      Error_SYS.Record_General( lu_name_, 'NO_ACCYEAR: Not a valid Accounting Year' );
   END IF;

   Client_SYS.Clear_Attr(attr_);
   Client_SYS.Add_To_Attr('CLOSING_BALANCES_DB',closing_balances_db_, attr_);
   -- based on the presumption, that alternatively: all of the periods must be 'closed' or all must be 'finally closed' 
   -- (which is hopefully validated before).
   IF Accounting_Period_API.Period_Finally_Closed_Exist(company_, from_year_) != 'TRUE' THEN
      Client_SYS.Add_To_Attr('YEAR_STATUS_DB','C', attr_);
   ELSE
      Client_SYS.Add_To_Attr('YEAR_STATUS_DB','F', attr_);
   END IF;

   ACCOUNTING_YEAR_API.Modify__ (info_ ,from_year_data_.objid, from_year_data_.objversion, attr_,'DO' );

   Get_Id_Version_By_Keys___(to_year_data_.objid,
                             to_year_data_.objversion,
                             company_,
                             to_year_);

   IF (to_year_data_.objid IS NULL) THEN
      Error_SYS.Record_General( lu_name_, 'NO_ACCYEAR: Not a valid Accounting Year' );
   END IF;

   Client_SYS.Clear_Attr(attr_);
   Client_SYS.Add_To_Attr('OPENING_BALANCES_DB',closing_balances_db_, attr_);

   ACCOUNTING_YEAR_API.Modify__ (info_ ,to_year_data_.objid, to_year_data_.objversion, attr_,'DO' );

END Final_Year_End__;


PROCEDURE Update_Year_Data__ (
   company_ IN VARCHAR2,
   from_year_ IN NUMBER,
   from_period_ IN NUMBER,
   closing_balances_db_ IN VARCHAR2 )
IS
   year_data_   ACC_YEAR%ROWTYPE ;
   attr_        VARCHAR2(2000);
   info_        VARCHAR2(2000);

BEGIN

   Get_Id_Version_By_Keys___(year_data_.objid,
                             year_data_.objversion,
                             company_,
                             from_year_);
   IF (year_data_.objid IS NULL) THEN
      Error_SYS.Record_General( lu_name_, 'NO_ACCYEAR: Not a valid Accounting Year' );
   END IF;

   IF (from_period_ !=0) THEN
      Client_SYS.Clear_Attr(attr_);
      Client_SYS.Add_To_Attr('CLOSING_BALANCES_DB',closing_balances_db_, attr_);
      ACCOUNTING_YEAR_API.Modify__ (info_ ,year_data_.objid, year_data_.objversion, attr_,'DO' );
   END IF;

   IF (from_period_ = 0) THEN
      Client_SYS.Clear_Attr(attr_);
      Client_SYS.Add_To_Attr('OPENING_BALANCES_DB',closing_balances_db_, attr_);
      ACCOUNTING_YEAR_API.Modify__ (info_ ,year_data_.objid, year_data_.objversion, attr_,'DO' );
   END IF;
END Update_Year_Data__;


PROCEDURE Close_Opened_Year__ (
   company_ IN VARCHAR2,
   accounting_year_ IN NUMBER )
IS
   from_year_data_   ACC_YEAR%ROWTYPE ;
   attr_        VARCHAR2(2000);
   info_        VARCHAR2(2000);
BEGIN

   Get_Id_Version_By_Keys___(from_year_data_.objid,
                             from_year_data_.objversion,
                             company_,
                             accounting_year_);
   IF (from_year_data_.objid IS NULL) THEN
      Error_SYS.Record_General( lu_name_, 'NO_ACCYEAR: Not a valid Accounting Year' );
   END IF;

   Client_SYS.Clear_Attr(attr_);
   -- based on the presumption, that alternatively: all of the periods must be 'closed' or all must be 'finally closed' 
   -- (which is hopefully validated before).
   IF Accounting_Period_API.Period_Finally_Closed_Exist(company_, accounting_year_) != 'TRUE' THEN
      Client_SYS.Add_To_Attr('YEAR_STATUS_DB','C', attr_);
   ELSE
      Client_SYS.Add_To_Attr('YEAR_STATUS_DB','F', attr_);
   END IF;

   ACCOUNTING_YEAR_API.Modify__ (info_ ,from_year_data_.objid, from_year_data_.objversion, attr_,'DO' );
END Close_Opened_Year__;


PROCEDURE Change_Balance_State__ (
   company_ IN VARCHAR2,
   acc_year_ IN NUMBER,
   acc_period_ IN NUMBER )
IS
   year_data_   ACC_YEAR%ROWTYPE;
   attr_        VARCHAR2(2000);
   info_        VARCHAR2(2000);

BEGIN

   Get_Id_Version_By_Keys___(year_data_.objid,
                             year_data_.objversion,
                             company_,
                             acc_year_);
   IF (year_data_.objid IS NULL) THEN
      Error_SYS.Record_General( lu_name_, 'NO_ACCYEAR: Not a valid Accounting Year' );
   END IF;

   IF (acc_period_ != 0) THEN
      Client_SYS.Clear_Attr(attr_);
      Client_SYS.Add_To_Attr('CLOSING_BALANCES_DB','N', attr_);
      ACCOUNTING_YEAR_API.Modify__ (info_ ,year_data_.objid, year_data_.objversion, attr_,'DO' );
   END IF;
   IF (acc_period_ = 0) THEN
      Client_SYS.Clear_Attr(attr_);
      Client_SYS.Add_To_Attr('OPENING_BALANCES_DB','N', attr_);
      ACCOUNTING_YEAR_API.Modify__ (info_ ,year_data_.objid, year_data_.objversion, attr_,'DO' );
   END IF;
END Change_Balance_State__;

-------------------- LU SPECIFIC PROTECTED METHODS --------------------------

-------------------- LU SPECIFIC PUBLIC METHODS -----------------------------

-- Exist
--   Checks if given pointer (e.g. primary key) to an instance of this
--   logical unit exists. If not an exception will be raised.
@UncheckedAccess
PROCEDURE Exist (
   accounting_year_ IN VARCHAR2,
   company_ IN VARCHAR2 )
IS
BEGIN
   Exist(company_, TO_NUMBER(accounting_year_));
END Exist;


-- Exist
--   Checks if given pointer (e.g. primary key) to an instance of this
--   logical unit exists. If not an exception will be raised.



-- Exist
--   Checks if given pointer (e.g. primary key) to an instance of this
--   logical unit exists. If not an exception will be raised.
@UncheckedAccess
PROCEDURE Exist (
   accounting_year_  IN NUMBER,
   company_          IN VARCHAR2)
IS
BEGIN
   Exist(company_, accounting_year_); 
END Exist;


FUNCTION Period_Delete_Allowed (
   company_               IN VARCHAR2,
   accounting_year_       IN NUMBER ) RETURN BOOLEAN
IS
   dummy_               VARCHAR2(1);

   CURSOR check_period IS
      SELECT  'Y'
      FROM    accounting_period_tab
      WHERE   company = company_
      AND     accounting_year = accounting_year_;

BEGIN
   dummy_ := 'N';

   OPEN check_period;
   FETCH check_period INTO dummy_;
      IF dummy_ = 'Y' THEN
         CLOSE check_period;
         Error_SYS.Record_General(lu_name_,'NO_PER_DEL: The periods for this year have to be removed first');
         RETURN FALSE;
      ELSE
         CLOSE check_period;
         RETURN TRUE;
      END IF;
END Period_Delete_Allowed;


PROCEDURE Open_Up_Closed_Year (
   company_    IN  VARCHAR2,
   acc_year_   IN  NUMBER )
IS
   CURSOR get_next_year IS
      SELECT accounting_year
      FROM ACC_YEAR
      WHERE company = company_
      AND accounting_year > acc_year_
      AND ROWNUM = 1
      ORDER BY accounting_year;

   year_data_   ACC_YEAR%ROWTYPE ;
   empty_data_  ACC_YEAR%ROWTYPE ;
   attr_        VARCHAR2(2000);
   info_        VARCHAR2(2000);
   next_year_   NUMBER;

   CURSOR closed_open_period IS
      SELECT 1
      FROM ACCOUNTING_PERIOD_TAB
      WHERE company = company_
      AND   accounting_year = next_year_
      AND   year_end_period = 'YEAROPEN'
      AND   period_status IN ('F','C');

   dummy_ NUMBER;

BEGIN

   Get_Id_Version_By_Keys___(year_data_.objid,
                             year_data_.objversion,
                             company_,
                             acc_year_);
   IF (year_data_.objid IS NULL) THEN
      Error_SYS.Record_General( lu_name_, 'NO_ACCYEAR: Not a valid Accounting Year' );
   END IF;

   Client_SYS.Clear_Attr(attr_);
   Client_SYS.Add_To_Attr('YEAR_STATUS_DB','O', attr_);
   Client_SYS.Add_To_Attr('CLOSING_BALANCES_DB','P', attr_);

   IF (Accounting_Year_API.Get_Year_Status_Db(company_, acc_year_ + 1) != 'C') THEN

      ACCOUNTING_YEAR_API.Modify__ (info_ ,year_data_.objid, year_data_.objversion, attr_,'DO' );

      OPEN  get_next_year;
      FETCH get_next_year INTO next_year_;
      IF ( get_next_year%FOUND ) THEN
         year_data_ := empty_data_;
         Get_Id_Version_By_Keys___(year_data_.objid,
                                   year_data_.objversion,
                                   company_,
                                   next_year_);
         IF (year_data_.objid IS NULL) THEN
            Error_SYS.Record_General( lu_name_, 'NO_ACCYEAR: Not a valid Accounting Year' );
         END IF;

         OPEN closed_open_period;
         FETCH closed_open_period INTO dummy_;
         IF closed_open_period%FOUND THEN
            CLOSE closed_open_period;
            Error_SYS.Record_General (lu_name_, 'NOPCLOS: The year cannot be re-opened when the opening period of the following year is closed!');
         END IF;
         CLOSE closed_open_period;

         Client_SYS.Clear_Attr(attr_);
         Client_SYS.Add_To_Attr('OPENING_BALANCES_DB','P', attr_);

         ACCOUNTING_YEAR_API.Modify__ (info_ ,year_data_.objid, year_data_.objversion, attr_,'DO' );
      END IF;
      CLOSE get_next_year;
   ELSE
      Error_SYS.Record_General(lu_name_, 'NOYEARSCLOSED: All subsequent years must be open');
   END IF;

END Open_Up_Closed_Year;


@UncheckedAccess
FUNCTION Get_Opening_Balanecs_Db (
   company_ IN VARCHAR2,
   accounting_year_ IN NUMBER ) RETURN VARCHAR2
IS
   temp_ ACC_YEAR.opening_balances_db%TYPE;
   CURSOR get_attr IS
      SELECT opening_balances_db
      FROM ACC_YEAR
      WHERE company = company_
      AND   accounting_year = accounting_year_;
BEGIN
   OPEN get_attr;
   FETCH get_attr INTO temp_;
   CLOSE get_attr;
   RETURN temp_;
END Get_Opening_Balanecs_Db;


PROCEDURE Preliminary_Year_End (
   company_    IN  VARCHAR2,
   from_year_  IN  NUMBER,
   to_year_    IN NUMBER )
IS
   from_year_data_   ACC_YEAR%ROWTYPE ;
   to_year_data_   ACC_YEAR%ROWTYPE ;
   attr_        VARCHAR2(2000);
   info_        VARCHAR2(2000);

BEGIN

   Get_Id_Version_By_Keys___(from_year_data_.objid,
                             from_year_data_.objversion,
                             company_,
                             from_year_);
   IF (from_year_data_.objid IS NULL) THEN
      Error_SYS.Record_General( lu_name_, 'NO_ACCYEAR: Not a valid Accounting Year' );
   END IF;

   Client_SYS.Clear_Attr(attr_);
   Client_SYS.Add_To_Attr('CLOSING_BALANCES_DB','P', attr_);

   ACCOUNTING_YEAR_API.Modify__ (info_ ,from_year_data_.objid, from_year_data_.objversion, attr_,'DO' );

   Get_Id_Version_By_Keys___(to_year_data_.objid,
                             to_year_data_.objversion,
                             company_,
                             to_year_);
   IF (to_year_data_.objid IS NULL) THEN
      Error_SYS.Record_General( lu_name_, 'NO_ACCYEAR: Not a valid Accounting Year' );
   END IF;

   Client_SYS.Clear_Attr(attr_);
   Client_SYS.Add_To_Attr('OPENING_BALANCES_DB','P', attr_);

   ACCOUNTING_YEAR_API.Modify__ (info_ ,to_year_data_.objid, to_year_data_.objversion, attr_,'DO' );
END  Preliminary_Year_End;


PROCEDURE Final_Year_End (
   company_    IN  VARCHAR2,
   from_year_  IN  NUMBER,
   to_year_    IN NUMBER )
IS
   from_year_data_   ACC_YEAR%ROWTYPE ;
   to_year_data_   ACC_YEAR%ROWTYPE ;
   attr_        VARCHAR2(2000);
   info_        VARCHAR2(2000);

BEGIN

   Get_Id_Version_By_Keys___(from_year_data_.objid,
                             from_year_data_.objversion,
                             company_,
                             from_year_);
   IF (from_year_data_.objid IS NULL) THEN
      Error_SYS.Record_General( lu_name_, 'NO_ACCYEAR: Not a valid Accounting Year' );
   END IF;

   Client_SYS.Clear_Attr(attr_);
   Client_SYS.Add_To_Attr('CLOSING_BALANCES_DB','FB', attr_);
   -- based on the presumption, that alternatively: all of the periods must be 'closed' or all must be 'finally closed' 
   -- (which is hopefully validated before).
   IF Accounting_Period_API.Period_Finally_Closed_Exist(company_, from_year_) != 'TRUE' THEN
      Client_SYS.Add_To_Attr('YEAR_STATUS_DB','C', attr_);
   ELSE
      Client_SYS.Add_To_Attr('YEAR_STATUS_DB','F', attr_);
   END IF;

   ACCOUNTING_YEAR_API.Modify__ (info_ ,from_year_data_.objid, from_year_data_.objversion, attr_,'DO' );

   Get_Id_Version_By_Keys___(to_year_data_.objid,
                             to_year_data_.objversion,
                             company_,
                             to_year_);
   IF (to_year_data_.objid IS NULL) THEN
      Error_SYS.Record_General( lu_name_, 'NO_ACCYEAR: Not a valid Accounting Year' );
   END IF;

   Client_SYS.Clear_Attr(attr_);
   Client_SYS.Add_To_Attr('OPENING_BALANCES_DB','FB', attr_);

   ACCOUNTING_YEAR_API.Modify__ (info_ ,to_year_data_.objid, to_year_data_.objversion, attr_,'DO' );

END Final_Year_End;


PROCEDURE Set_Consolidated_Flag (
   company_                IN VARCHAR2,
   accounting_year_        IN NUMBER )
IS
BEGIN
   UPDATE accounting_year_tab
      SET open_bal_consolidated = 'Y'
   WHERE company         = company_
   AND   accounting_year = accounting_year_ ;
END Set_Consolidated_Flag;


PROCEDURE Clear_Consolidated_Flag (
   company_                IN VARCHAR2,
   accounting_year_        IN NUMBER )
IS
BEGIN
   UPDATE accounting_year_tab
      SET open_bal_consolidated = 'N'
   WHERE company         = company_
   AND   accounting_year = accounting_year_ ;
END Clear_Consolidated_Flag;


PROCEDURE Update_Year_Data (
   company_ IN VARCHAR2,
   from_year_ IN VARCHAR2,
   to_year_ IN VARCHAR2,
   closing_balances_db_ IN VARCHAR2 )
IS

   from_year_data_   ACC_YEAR%ROWTYPE ;
   to_year_data_   ACC_YEAR%ROWTYPE ;
   attr_        VARCHAR2(2000);
   info_        VARCHAR2(2000);

BEGIN

   Get_Id_Version_By_Keys___(from_year_data_.objid,
                             from_year_data_.objversion,
                             company_,
                             from_year_);
   IF (from_year_data_.objid IS NULL) THEN
      Error_SYS.Record_General( lu_name_, 'NO_ACCYEAR: Not a valid Accounting Year' );
   END IF;

   Client_SYS.Clear_Attr(attr_);
   Client_SYS.Add_To_Attr('CLOSING_BALANCES_DB',closing_balances_db_, attr_);

   ACCOUNTING_YEAR_API.Modify__ (info_ ,from_year_data_.objid, from_year_data_.objversion, attr_,'DO' );

   Get_Id_Version_By_Keys___(to_year_data_.objid,
                             to_year_data_.objversion,
                             company_,
                             to_year_);
   IF (to_year_data_.objid IS NULL) THEN
      Error_SYS.Record_General( lu_name_, 'NO_ACCYEAR: Not a valid Accounting Year' );
   END IF;

   Client_SYS.Clear_Attr(attr_);
   Client_SYS.Add_To_Attr('OPENING_BALANCES_DB',closing_balances_db_, attr_);

   ACCOUNTING_YEAR_API.Modify__ (info_ ,to_year_data_.objid, to_year_data_.objversion, attr_,'DO' );

END Update_Year_Data;


PROCEDURE Close_Opened_Year (
   company_ IN VARCHAR2,
   accounting_year_ IN NUMBER )
IS

BEGIN

   Close_Opened_Year__(company_, accounting_year_);
END Close_Opened_Year;


@UncheckedAccess
FUNCTION Check_Exist (
   company_         IN VARCHAR2,
   accounting_year_ IN NUMBER ) RETURN VARCHAR2
IS
BEGIN
   IF (Check_Exist___(company_, accounting_year_)) THEN
      RETURN 'TRUE';
   ELSE
      RETURN 'FALSE';
   END IF;
END Check_Exist;


PROCEDURE Get_Year_Periods(
   year_periods_            OUT Year_Period_Tab,
   company_                 IN  VARCHAR2,
   accounting_year_from_    IN  NUMBER,
   accounting_period_from_  IN  NUMBER,
   accounting_year_until_   IN  NUMBER,
   accounting_period_until_ IN  NUMBER, 
   include_year_end_        IN  BOOLEAN DEFAULT TRUE)
IS
BEGIN
   Get_Year_Periods___(year_periods_,
                       company_,
                       accounting_year_from_,
                       accounting_period_from_,  
                       accounting_year_until_,   
                       accounting_period_until_, 
                       include_year_end_);        
END Get_Year_Periods;


PROCEDURE Get_Year_Periods(
   year_periods_            OUT Year_Period_Tab,
   company_                 IN  VARCHAR2,
   accounting_year_from_    IN  NUMBER,
   accounting_year_until_   IN  NUMBER,
   include_year_end_        IN  BOOLEAN DEFAULT TRUE)
IS
BEGIN
   Get_Year_Periods___(year_periods_,
                       company_,
                       accounting_year_from_,
                       NULL,  
                       accounting_year_until_,   
                       NULL, 
                       include_year_end_);        
END Get_Year_Periods;

-- Bug 127629, Begin
@UncheckedAccess
FUNCTION Find_Next_Available_Year (
   company_         IN VARCHAR2,
   accounting_year_ IN NUMBER) RETURN NUMBER
IS
   next_year_ NUMBER;
   CURSOR get_next_year IS
      SELECT accounting_year
      FROM   Accounting_Year_Tab
      WHERE  company         = company_
      AND    accounting_year > accounting_year_      
      ORDER BY accounting_year;
BEGIN  
   OPEN get_next_year; 
   FETCH get_next_year INTO next_year_;
   CLOSE get_next_year;
   RETURN next_year_; 
END Find_Next_Available_Year;
-- Bug 127629, End 


