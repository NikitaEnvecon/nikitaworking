-----------------------------------------------------------------------------
--
--  Logical unit: AccountingPeriod
--  Component:    ACCRUL
--
--  IFS Developer Studio Template Version 3.0
--
--  Date    Sign    History
--  ------  ------  ---------------------------------------------------------
--  960412  jela     Base Table to Logical Unit Generator 1.0A
--  960531  jela     Added call to User_Group_Period_API in Unpack_Check_Update__
--                   to close periods there if Accounting Period is closed.
--  970326  AnDj     Added Check_Valid_Range__
--  970326  AnDj     Fixed Support 660, Deleted duplicate NOYEAR =>
--                   NOYEAR1 and NOYEAR2
--  970707  SLKO     Converted to Foundation1 1.2.2d
--  970715  PICZ     Column CONSOLIDATED added
--  970715  PICZ     Added Get_Consolidation_Info function
--  970721  PICZ     Added functions: Set_Consolidated_Flag, Clear_Consolidated_Flag,
--                   Period_Valid_For_Consolidation
--  970812  JoTh     Bug # 97-0039 to_date() added to where clause in procedure
--                   Get_Accounting_Year.
--  970926  PICZ     Fixed bug in Insert__: consolidated flag was inserted without
--                   call to Encode method
--  980122  SLKO     Converted to Foundation1 2.0.0
--  980203  MALR     Update of Default Data, added procedure ModifyDefDataAccper__.
--  980212  MALR     Changed procedure ModifyDefDataAccper__, UserGroup is also a parameter.
--  980308  MiJo     Bug #3439, Added new procedures, Get_Max_Period and Get_Min_Period.
--  980316  PiCz     Bug #1391 - removed coma (,) from error message CHG_STATUS -
--                   it was not possible to show whole error message
--  980317  PiCz     Bug #1308 - changed date's validation
--  980331  PiCz     Trunctaing date in Get_Accounting_Period
--  980625  Kanchi   Added View5 to overcome the bug # 4905
--  980921  Bren     Master Slave Connection
--                   Added Send_Acc_Period_Info___, Send_Acc_Period_Info_
--                   Send_Acc_Period_Info_Modify___, Send_Acc_Period_Info.
--  981030  Mang     Added View6 and View7.
--  990217  ANDJ     Bug # 9124 fixed.
--  990408  JPS      Added a Cursor in Periodexist.
--  990419  JPS      Performed Template Changes.(Foundation 2.2.1)
--  991026  Dhar     Added Procedure Year_Exist
--  000120  Dhar     Added Procedure Get_Previous_Period
--  000103  Uma      Made the field Description Mandatory in ACCOUNTING_PERIOD
--  000310  Bren     Added VIEW ACCOUNTING_PERIOD_DEF for Voucher Type Wizard.
--  000316  Upul     Add procedure Check_Year_End_Period & Check_Previous_Year_End_Period
--  000901  SaCh     Added procedure Get_Periods_Sans_Year_End.
--  000908  HiMu     Added General_SYS.Init_Method.
--  001004  prtilk   BUG # 15677  Checked General_SYS.Init_Method
--  001130  OVJOSE   For new Create Company concept added new view accounting_period_ect and accounting_period_pct.
--                   Added procedures Make_Company, Copy___, Import___ and Export___.
--  010221  ToOs     Bug # 20177 Added Global Lu constants for check for transaction_sys calls
--  010427  LiSv     For new Create Company concept remarked view ACCOUNTING_PERIOD_DEF
--  010509  JeGu     Bug #21705 Implementation New Dummyinterface
--                   Changed Insert__ RETURNING rowid INTO objid_
--  010531  Bmekse   Removed methods used by the old way for transfer basic data from
--                   master to slave (nowdays is Replication used instead)
--  010626  ASSALK   added code in Get_Consolidation_Info to check for the Opening balance of the year.
--  010731  Brwelk   Added Get_YearPer_For_YearEnd_User, Get_Acc_Year_Period_User_Group and view9.
--  010816  OVJOSE   Added Create Company translation method Create_Company_Translations___
--  010905  JeGu     Simplified functions: Set_Consolidated_Flag, Clear_Consolidated_Flag,
--  010918  Brwelk   Changed Get_Period_Info___. Added a ORDER BY to the cursor.
--  020102  THSRLK   IID 20001 Enhancement of Update Company. Changes inside make_company method
--                   Changed Import___, Export___ and Copy___ methods to use records
--  020213  Mnisse   IID 21003, Added company translation support for description
--  020318  Shsalk   Call Id 79709 Corrected. Changed the Get_Year_End_Period.
--  020320  Mnisse   Copy__ changed FOUND -> NOTFOUND
--  020611  ovjose   Bug 29600 Corrected. Removed function call in ACCOUNTING_PERIOD_PCT.
--  020718  SUMALK   Bug 31711 Fixed.
--  021001  Nimalk   Removed usage of the view Company_Finance_Auth in ACCOUNTING_PERIOD,ACCOUNTING_PERIOD_FULL_LOV,
--                   ACCOUNTING_YEAR_FULL_LOV,ACCOUNTING_PERIOD_LOV,ACCOUNTING_YEAR_LOV,ACCOUNTING_PERIOD_TEMPview
--                   and replaced by view Company_Finance_Auth1 using EXISTS caluse instead of joins
--  021101  KuPelk   IID ESFI110N Year End Accounting.Added ned IID as PeriodType(Year_End_Period).
--  021104  Dagalk   ITFI103N -Internal ledger Year-end Add new field period_status_int .
--  021106  KuPelk   IID ESFI110N Year End Accounting.Added new methods as Check_Year_Opening_Period,
--                   Get_Opening_Period and Get_Year_End_Period_Data and Check_Opening_Date.
--  021107  Dagalk   ITFI103N -Internal ledger Year-end remove Acc_Status_Int_API and Use Acc_Per_Status_API
--                   also add  period_status_int to company creation views and import, copy, export procedures
--  021121  Chprlk   Modified the wrong where clause in VIEW9 ACCOUNTING_YEAR_END_PERIOD
--  021121  Chprlk   Added a default parameter period status to Get_Year_End_Period
--  011203  Chprlk   Corrected comparisons for year_end_period
--  021206  Chprlk   Added new method Get_All_Ordinary_Period for Call 92000
--  021212  KuPelk   IID ESFI110N Changed Get_Year_End_Period method.
--  030331  Risrlk   IID RDFI140NF. Changed Db_Values. Year_end_period(Period_Type_API)
--  030403  Risrlk   IID RDFI140NF. Increased the Year_end_period column width of the views.
--  030417  Risrlk   Modified Get_Year_End_Period_Data__ method.
--  030731  prdilk   SP4 Merge.
--  031017  LoKrLK   LCS Patch Merge (38565). Modified Get_Period_Info___.
--  031017  Thsrlk   LCS Patch Merge (38745).
--  031020  Brwelk   Init_Method Corrections
--  040323  Gepelk   2004 SP1 Merge
--  040623  anpelk   FIPR338A2: Unicode Changes.
--  041014  WAPELK   Merged Bug 45325.
--  041213  UPUNLK   Added private method Get_Year_Period__ to use in ACC_YEAR_PERIOD_PUB.
--  050105  UPUNLK   Added ACC_YEAR_PERIOD_PUB view to apy which is removed from apy.
--  050420  ISWALK   removed General_SYS.Init_Method() from Get_Year_Period__
--  050704  INGULK   FIAD377 Added a method Get_Next_Allowed_Periiod
--  050712  INGULK   FIAD377 Added methods Get_Previous_Allowed_Period & Is_Period_Allowed
--  051102  Nsillk   LCS Merge(53694).
--  051104  ShFrlk   LCS Bug 53325, Merged.
--  051107  Nsillk   LCS Merge(53901).
--  060210  Ingulk   Call Id 130916 - added a method Is_Year_Close().
--  060227  Gadalk   Call Id 132835 - Unpack_Check_Update___(), clossing year end periods
--  060320  Gadalk   Call Id 132835 - Changes in Check_Period_Closed()
--  060615  Kagalk   FIPL603A - Synchronize accounting periods and periods in journals.
--  070321  Shsalk   LCS Merge 60218 corrected. Modified procedure Get_Prev_Ordinary_Period.
--  070510  Prdilk   B141476, Modified Unpack_Check_Update___ to support translations. 
--  070629  Shsalk   B146296, corrected company template problem.
--  070910  Shwilk   LCS merge 66981, Modified method Check_Previous_Year_End_Period
--  071205  Jeguse   Bug 69803 Corrected.
--  080116  Sjaylk   Bug 70457, Changed Get_Prev_Ordinary_Period
--  080409  Nirplk   Bug 71549, Added new columns. Report_From_Date, report_until_date with validations
--  080721  Thpelk   Bug 75655, Modified the validaion in Unpack_Check_Update___().
--  081031  Makrlk   Bug 77389, Added new methods Get_Next_Allowing_Period() and Get_Number_Of_Allowed_Periods().
--  081208  Thpelk   Bug 77503, Corrected in Get_Next_Vou_Period() and Get_Next_Allowed_Period().
--  090219  reanpl   Bug 82373, SKwP Ceritificate - Final Closing of Period (SKwP-2)
--  090311  witopl   Bug 82373, SKwP Ceritificate - Final Closing of Period (SKwP-2)
--  090605  THPELK   Bug 82609 - Added missing UNDEFINE statements for VIEW10.
--  090717  ErFelk   Bug 83174, Replaced INS_00 with BALCONFLAG in Unpack_Check_Insert___, replaced UPDATE_00 with BALCONFLAG
--  090717           in Unpack_Check_Update___, replaced YEARENDPERIOD3 with YEARENDPERIOD5 in Check_Previous_Year_End_Period
--  090717           and replaced PER_IN_WAI1 with PER_HOLD_WAI in Check_Close_Period.  
--  090810  LaPrlk   Bug 79846, Removed the precisions defined for NUMBER type variables.
--  091120  Nirplk   Bug 87119, Corrected, modified the error msg PERIODCONSOLIDATED to support IEE client
--  091221  HimRlk   Reverse engineering correction, Removed method call to User_Group_Period_API.Period_Delete_Allowed in
--  091221           method Check_Delete_Record__.
--  100209  Nsillk   EAFH-1510 , Used Defined Calendar Modifications
--  100324  Nsillk   EAFH-2578 , Fetched the correct year opening description
--  100420  Nsillk   Modifications done to support update Company
--  100423  SaFalk   Modified REF for year_end_period in ACCOUNTING_PERIOD and ACCOUNTING_PERIOD_PCT.
--  100427  AsHelk   Bug 84970, Corrected. Ifs Assert Safe Annotation.
--  100716  Umdolk  EANE-2936, Reverse engineering - Corrected references and keys in base view.
--  101015  AjPelk   Bug 93466  Corrected. Added a method
--  110415  Sacalk   EASTONE-15173, Modified the view ACCOUNTING_PERIOD
--  110711  Sacalk   FIDEAGLE-300 , Merged LCS bug 96815, Added a new method Get_Next_Any_Period.
--  110712  Mohrlk   FIDEAGLE-1062, Merged bug 97478, Corrected in Get_Acc_Year_Period_User_Group().
--  111018  Shdilk   SFI-135, Conditional compilation.
--  111206  JuKoDE   SFI-1088, Added new function Get_Ordinary_Accounting_year() and Get_Ordinary_Accounting_period()
--  120119  Samblk   SFI-1499, merged bug 100546, Corrected, Moved some validations from Unpack_Check_Update___ to  Do_Final_Check().
--  120829  JuKoDE   EDEL-1532, Removed General_SYS in Get_Ordinary_Accounting_Year() and set PRAGMA in package specification.
--  120923  Chhulk   Bug 104778, Modified Import___().
--  120925  Chwilk   Bug 105088, Modified Unpack_Check_Update___.
--  121009  Machlk   Bug 105642, Removed the unneeded expression from where clause.
--  121123  Thpelk  Bug 106680 - Modified Conditional compilation to use single component package.
--  121204  Maaylk      PEPA-183, Removed global variables
--  130808  NIANLK   CAHOOK-1280: Added new checks to validate Account Year and period lenghs
--  130514  Janblk   DANU-1024, Added a parameter to Get_Opening_Period() to exclude checking for period_status 
--  130913  Umdolk  DANU-1918, Added public view ACC_YEAR_PERIOD_SUMMARY_PUB.
--  130917  Umdolk  DANU-1934, Modified ACC_YEAR_PERIOD_SUMMARY_PUB to correct the fresh installation error.
--  130816  Clstlk  Bug 111218, Fixed General_SYS.Init_Method issue.
--  130821  SJayLK   RUB-1040, Added BI Metadata specific funtions to support BA Function based parameters
--  130902  MAWELK  Bug 111219 Fixed. 
--  130902  THPELK  Bug 112154, Corrected QA script cleanup - Financials  Type Cursor usage in procedure / function.
--  131118  Umdolk  PBFI-899, Refactoring
--  150421  THPELK  Bug 122078, Corrected in Check_Update___().
--  160329  SAVMLK  Bug 128136, Added new function Get_Firstdate_Nextopenperiod().
--  160816  MAAYLK  Bug 130949, modified Get_Voucher_Period() to fetch period from gen_led_arch_voucher_tab
-----------------------------------------------------------------------------

layer Core;

-------------------- PUBLIC DECLARATIONS ------------------------------------

TYPE PeriodTab IS TABLE OF NUMBER
      INDEX BY BINARY_INTEGER;


-------------------- PRIVATE DECLARATIONS -----------------------------------

TYPE Year_Period_Rec IS RECORD
(
   Accounting_Year   PLS_INTEGER,
   Accounting_Period PLS_INTEGER   
);

TYPE Year_Period_Tab IS TABLE OF Year_Period_Rec INDEX BY BINARY_INTEGER;

TYPE Micro_Cache_Year_Per_Type IS TABLE OF Year_Period_Rec INDEX BY VARCHAR2(1000);

micro_cache_year_per_tab_   Micro_Cache_Year_Per_Type;

micro_cache_year_per_value_ Year_Period_Rec;

micro_cache_year_per_time_  NUMBER := 0;

micro_cache_year_per_user_  VARCHAR2(30);

-------------------- LU SPECIFIC IMPLEMENTATION METHODS ---------------------

PROCEDURE Validate_Close___ (newrec_ ACCOUNTING_PERIOD_TAB%ROWTYPE)
IS
   dummy_      NUMBER;
   
   $IF Component_Genled_SYS.INSTALLED $THEN
      CURSOR is_rows_exists  IS
         SELECT 1
         FROM   gen_led_voucher_row2 
         WHERE  company           = newrec_.company 
         AND    accounting_year   = newrec_.accounting_year
         AND    accounting_period = newrec_.accounting_period 
         AND    function_group   != 'YE'
         AND    (journal_id IS NULL OR sequence_no IS NULL);
   $END
BEGIN
   $IF Component_Genled_SYS.INSTALLED $THEN

      IF nvl(Acc_Journal_Year_API.Get_Sort_Order_Db(newrec_.company, newrec_.accounting_year), 'XXX') = 'SEQUENCE_NO' THEN
         OPEN  is_rows_exists;
         FETCH is_rows_exists INTO dummy_;
         IF is_rows_exists%FOUND THEN
            CLOSE is_rows_exists;
            Error_SYS.Record_General(lu_name_, 'ACCPERCLOSE10: Period :P1 can not be closed because not all voucher rows exist in Accounting Journal with Sort by "Sequence No"',
                                                newrec_.accounting_period);
         END IF;
         CLOSE is_rows_exists;
      END IF;
   $ELSE
      NULL;
   $END
END Validate_Close___;


PROCEDURE Validate_Final_Close___ (newrec_ ACCOUNTING_PERIOD_TAB%ROWTYPE)
IS
   CURSOR check_prev_periods IS
      SELECT 1
      FROM   ACCOUNTING_PERIOD_TAB
      WHERE  company         = newrec_.company
      AND    accounting_year = newrec_.accounting_year
      AND    date_until      < newrec_.date_from
      AND    year_end_period = 'ORDINARY'
      AND    period_status  != 'F';

   CURSOR check_periods IS
      SELECT 1
      FROM   ACCOUNTING_PERIOD_TAB
      WHERE  company         = newrec_.company
      AND    accounting_year = newrec_.accounting_year
      AND    year_end_period IN ('ORDINARY','YEAROPEN')
      AND    period_status  != 'F';
   
   $IF Component_Genled_SYS.INSTALLED $THEN 
      CURSOR is_rows_exists IS
         SELECT 1 FROM accounting_journal_item_tab 
         WHERE  company           = newrec_.company
         AND    accounting_year   = newrec_.accounting_year
         AND    accounting_period = newrec_.accounting_period
         AND    rowstate          = 'Empty';
   $END

   dummy_  NUMBER;

BEGIN
   IF newrec_.year_end_period = 'ORDINARY' THEN
      OPEN check_prev_periods;
      FETCH check_prev_periods INTO dummy_;
      IF check_prev_periods%FOUND THEN
         CLOSE check_prev_periods;
         Error_SYS.Record_General(lu_name_, 'ACCPERFINCLOSE10: To close the period finally all previous Ordinary periods must be in state "Finally Closed".');
      END IF;
      CLOSE check_prev_periods;
   ELSIF newrec_.year_end_period = 'YEAROPEN' THEN
      IF nvl(Accounting_Year_API.Get_Year_Status_Db(newrec_.company, newrec_.accounting_year-1),'C') = 'O' THEN
         Error_SYS.Record_General(lu_name_, 'ACCPERFINCLOSE20: To close the period finally previous year must be in state "Closed" or "Finally Closed".');
      END IF;
   ELSIF newrec_.year_end_period = 'YEARCLOSE' THEN
      IF nvl(Accounting_Year_API.Get_Year_Status_Db(newrec_.company, newrec_.accounting_year-1),'C') = 'O' THEN
         Error_SYS.Record_General(lu_name_, 'ACCPERFINCLOSE20: To close the period finally previous year must be in state "Closed" or "Finally Closed".');
      END IF;

      OPEN check_periods;
      FETCH check_periods INTO dummy_;
      IF check_periods%FOUND THEN
         CLOSE check_periods;
         Error_SYS.Record_General(lu_name_, 'ACCPERFINCLOSE30: To close the period finally all Ordinary and Year Opening periods must be in state "Finally Closed".');
      END IF;
      CLOSE check_periods;
   END IF;

   $IF Component_Genled_SYS.INSTALLED $THEN 
      IF newrec_.year_end_period IN ('ORDINARY','YEARCLOSE') THEN
      
         OPEN  is_rows_exists;
         FETCH is_rows_exists INTO dummy_;
         IF is_rows_exists%FOUND THEN
            CLOSE is_rows_exists;
            Error_SYS.Record_General(lu_name_, 'ACCPERFINCLOSE40: To close the period finally all Accounting Journals must be in state "Automatic" or "Generated".');
         END IF;
         CLOSE is_rows_exists;
      END IF;
   $ELSE
      NULL;
   $END
END Validate_Final_Close___;


PROCEDURE Check_Dt_Change_Allowed___ (
   company_           IN VARCHAR2,
   accounting_year_   IN NUMBER,
   accounting_period_ IN NUMBER )
IS
   change_not_allowed_  BOOLEAN := FALSE;
BEGIN
   -- Check Hold table
   IF (VOUCHER_API.Exist_Vou_Per_Period (company_,
                                         accounting_year_,
                                         accounting_period_ )= 'TRUE') THEN
      change_not_allowed_ := TRUE;
   ELSIF (Rpd_Company_Period_API.Check_Exist(company_, accounting_year_, accounting_period_)) THEN
      Error_SYS.Record_General(lu_name_, 
                            'CHNOTALLWED2: Reporting Period Definitions Exists for Year and Period - Valid From, Valid Until Cannot be modified.');              
   ELSE
      -- Hold Table is clear, Check Genled
      $IF Component_Genled_SYS.INSTALLED $THEN
         IF (GEN_LED_VOUCHER_API.Exist_Vou_Per_Period (company_,
                                                       accounting_year_,
                                                       accounting_period_ )= 'TRUE') THEN
   
              change_not_allowed_ := TRUE;
         END IF;
      $ELSE
         NULL;
      $END
   END IF;

   IF (change_not_allowed_) THEN
      Error_SYS.Record_General(lu_name_,
                             'CHNOTALLWED: You are not allowed to modify valid from and valid until dates since transactions exist for the period.' );
   END IF;
END Check_Dt_Change_Allowed___;


PROCEDURE Import___ (
   crecomp_rec_ IN Enterp_Comp_Connect_V170_API.Crecomp_Lu_Public_Rec )
IS
   attr_          VARCHAR2(32000);
   objid_         VARCHAR2(2000);
   objversion_    VARCHAR2(2000);
   newrec_        ACCOUNTING_PERIOD_TAB%ROWTYPE;
   empty_rec_     ACCOUNTING_PERIOD_TAB%ROWTYPE;
   msg_           VARCHAR2(2000);
   i_             NUMBER := 0;
   update_by_key_ BOOLEAN;
   any_rows_      BOOLEAN := FALSE;
   start_month_   NUMBER;
   month_         NUMBER;
   period_type_   VARCHAR2(20);
   cal_year_      NUMBER;
   -- Bug 104778, Begin
   from_date_     DATE;
   set_off_val_   NUMBER;
   -- Bug 104778, End
   indrec_        Indicator_Rec;

   -- NOTE: added D3 and D4. STD template will not have D3 and D4. However if a 
   --       user defined template contains report from date and report until date 
   --       it should get imported using D3 and D4. Therefore D3 and D4 columns were added.
   --       Added N3 and N4. Standard templates will not have these. These are used for
   --       companies with user defined calendar option and templates created by such companies
   CURSOR get_data IS
      SELECT C1, C2, C3, C4, C5, N1, N2, N3, N4, D1, D2, D3, D4
      FROM   Create_Company_Template_Pub src
      WHERE  component   = 'ACCRUL'
      AND    lu          = lu_name_
      AND    template_id = crecomp_rec_.template_id
      AND    version     = crecomp_rec_.version
      AND    NOT EXISTS (SELECT 1 
                         FROM ACCOUNTING_PERIOD_TAB dest
                         WHERE dest.company = crecomp_rec_.company
                         AND dest.accounting_year = src.N1
                         AND dest.accounting_period = src.N2)
      ORDER BY N1, N2;

   -- Bug 104778, Begin
   CURSOR get_from_date ( template_id_ VARCHAR2, component_ VARCHAR2, lu_ VARCHAR2 )IS
      SELECT t.d1
      FROM create_company_template_pub t
      WHERE t.template_id = template_id_
      AND  t.component = component_
      AND t.lu = lu_
      AND t.item_id = 1;
   -- Bug 104778, End

BEGIN
   update_by_key_ := Enterp_Comp_Connect_V170_API.Use_Keys(module_, lu_name_, crecomp_rec_);

   IF (update_by_key_) THEN
      IF (Company_Finance_API.Get_User_Def_Cal(crecomp_rec_.company) = 'FALSE') THEN
         FOR rec_ IN get_data LOOP
            i_ := i_ + 1;
            @ApproveTransactionStatement(2014-03-25,dipelk)
            SAVEPOINT make_company_insert;
            BEGIN
               
               newrec_ := empty_rec_;

               newrec_.company           := crecomp_rec_.company;
               newrec_.accounting_year      := rec_.n1;
               newrec_.accounting_period    := rec_.n2;
               newrec_.description          := rec_.c1;
               newrec_.year_end_period      := rec_.c2;
               newrec_.period_status        := rec_.c3;
               newrec_.period_status_int    := rec_.c5;
               newrec_.date_from            := rec_.d1;
               newrec_.date_until           := rec_.d2;
               newrec_.consolidated         := rec_.c4;
               newrec_.report_from_date     := rec_.d3;
               newrec_.report_until_date    := rec_.d4;
               newrec_.cal_year             := rec_.N3;
               newrec_.cal_month            := rec_.N4;
               Client_SYS.Clear_Attr(attr_);
               indrec_ := Get_Indicator_Rec___(newrec_);
               Check_Insert___(newrec_, indrec_, attr_);
               Insert___(objid_, objversion_, newrec_, attr_);
            EXCEPTION
               WHEN OTHERS THEN
                  msg_ := SQLERRM;
                  @ApproveTransactionStatement(2014-03-25,dipelk)
                  ROLLBACK TO make_company_insert;
                  Enterp_Comp_Connect_V170_API.Log_Logging(crecomp_rec_.company, module_, 'ACCOUNTING_PERIOD_API', 'Error', msg_);
            END;
         END LOOP;
      END IF;
      IF ( i_ = 0 ) THEN
         msg_ := language_sys.translate_constant(lu_name_, 'NODATAFOUND: No Data Found');
         Enterp_Comp_Connect_V170_API.Log_Logging(crecomp_rec_.company, module_, 'ACCOUNTING_PERIOD_API', 'CreatedSuccessfully', msg_);
      ELSE
         IF msg_ IS NULL THEN
            Enterp_Comp_Connect_V170_API.Log_Logging(crecomp_rec_.company, module_, 'ACCOUNTING_PERIOD_API', 'CreatedSuccessfully');
         ELSE
            Enterp_Comp_Connect_V170_API.Log_Logging(crecomp_rec_.company, module_, 'ACCOUNTING_PERIOD_API', 'CreatedWithErrors');
         END IF;
      END IF;
   ELSE
      any_rows_ := Exist_Any___(crecomp_rec_.company);
      IF (NOT any_rows_) THEN
         IF (crecomp_rec_.user_defined = 'TRUE') THEN
            start_month_ := crecomp_rec_.cal_start_month;
            -- Bug 104778, Begin
            OPEN get_from_date (crecomp_rec_.template_id, 'ACCRUL', 'AccountingPeriod') ;
            FETCH get_from_date INTO from_date_;
            CLOSE get_from_date;            
            set_off_val_ := NVL(EXTRACT(MONTH FROM from_date_), 1);
            -- Bug 104778, End
            FOR year_ IN 0..crecomp_rec_.number_of_years-1 LOOP
               
               i_ := i_ + 1;
               month_ := start_month_;
               cal_year_ := crecomp_rec_.cal_start_year + year_;
               FOR period_ IN 0..12 LOOP
                  @ApproveTransactionStatement(2014-03-25,dipelk)
                  SAVEPOINT make_company_insert;
                  BEGIN
                     IF (month_ = 13) THEN
                        month_ := 1;
                        cal_year_ := crecomp_rec_.cal_start_year + year_ + 1;
                     END IF;
                     IF period_ = 0 THEN
                        period_type_ := 'YEAROPEN';
                     ELSE
                        period_type_ := 'ORDINARY';
                     END IF;
                     newrec_.company              := crecomp_rec_.company;
                     newrec_.accounting_year      := crecomp_rec_.acc_year + year_;
                     newrec_.accounting_period    := period_;
                     newrec_.year_end_period      := period_type_;
                     newrec_.period_status        := 'O';
                     newrec_.period_status_int    := 'O';
                     newrec_.date_from            := Get_First_Day_Month___(month_,cal_year_);
                     IF period_ = 0 THEN
                        newrec_.date_until := newrec_.date_from;
                     ELSE
                        newrec_.date_until  := LAST_DAY(newrec_.date_from);
                     END IF;
                     newrec_.consolidated         := 'N';
                     newrec_.report_from_date     := NULL;
                     newrec_.report_until_date    := NULL;
                     newrec_.cal_year             := cal_year_;
                     newrec_.cal_month            := month_;
                     IF (period_ = 0) THEN
                        newrec_.cal_month := 0;
                        newrec_.cal_year  := newrec_.accounting_year;
                     END IF;
                     newrec_.description          := Get_Period_Desc( period_, 
                                                                      newrec_.cal_year,
                                                                      newrec_.cal_month );                     
                     Client_SYS.Clear_Attr(attr_);
                     indrec_ := Get_Indicator_Rec___(newrec_);
                     Check_Insert___(newrec_, indrec_, attr_);
                     Insert___(objid_, objversion_, newrec_, attr_);

                     IF (period_ != 0)THEN
                        month_ := month_ + 1;
                     END IF;
                  EXCEPTION
                     WHEN OTHERS THEN
                        msg_ := SQLERRM;
                        @ApproveTransactionStatement(2014-03-24,dipelk)
                        ROLLBACK TO make_company_insert;
                        Enterp_Comp_Connect_V170_API.Log_Logging(crecomp_rec_.company, module_, 'ACCOUNTING_PERIOD_API', 'Error', msg_);
                  END;
               END LOOP;
            END LOOP;
            -- Bug 104778, Begin
            start_month_ := crecomp_rec_.cal_start_month;
            FOR year_ IN 0..crecomp_rec_.number_of_years LOOP
               month_ := start_month_;
               cal_year_ := crecomp_rec_.cal_start_year + year_;
               FOR period_ IN 0..12 LOOP
                  BEGIN
                     IF (month_ = 13) THEN
                        month_ := 1;
                        cal_year_ := crecomp_rec_.cal_start_year + year_ + 1;
                     END IF;
                     newrec_.accounting_year      := crecomp_rec_.acc_year + year_;
                     newrec_.accounting_period    := period_;
                     newrec_.cal_year             := cal_year_;
                     newrec_.cal_month            := month_;
                     IF (period_ = 0) THEN
                        newrec_.cal_month := 0;
                        newrec_.cal_year  := newrec_.accounting_year;
                     END IF;
                     IF (set_off_val_ != 1) THEN
                        Enterp_Comp_Connect_V170_API.Copy_Templ_To_Comp_Trans(crecomp_rec_.template_id,
                                                                              crecomp_rec_.company,
                                                                              'ACCRUL',
                                                                              lu_name_,
                                                                              lu_name_,
                                                                              Get_Set_Off_Year___(newrec_.cal_year,newrec_.cal_month, (set_off_val_ - 1 ))||'^'||Get_Set_Off_Month___(newrec_.cal_year,newrec_.cal_month, (set_off_val_ - 1 )),
                                                                              newrec_.cal_year||'^'||newrec_.cal_month,
                                                                              crecomp_rec_.languages||Client_SYS.text_separator_||'PROG');
                     END IF;

                     IF (period_ != 0)THEN
                        month_ := month_ + 1;
                     END IF;
                  EXCEPTION
                     WHEN OTHERS THEN
                        msg_ := SQLERRM;
                        Enterp_Comp_Connect_V170_API.Log_Logging(crecomp_rec_.company, module_, 'ACCOUNTING_PERIOD_API', 'Error', msg_);
                  END;
               END LOOP;
            END LOOP;
            -- Bug 104778, End
         ELSE
            FOR rec_ IN get_data LOOP
               attr_ := NULL;
               i_ := i_ + 1;
               @ApproveTransactionStatement(2014-03-25,dipelk)
               SAVEPOINT make_company_insert;
               BEGIN
                  newrec_.company              := crecomp_rec_.company;
                  newrec_.accounting_year      := rec_.n1;
                  newrec_.accounting_period    := rec_.n2;
                  newrec_.description          := rec_.c1;
                  newrec_.year_end_period      := rec_.c2;
                  newrec_.period_status        := rec_.c3;
                  newrec_.period_status_int    := rec_.c5;
                  newrec_.date_from            := rec_.d1;
                  newrec_.date_until           := rec_.d2;
                  newrec_.consolidated         := rec_.c4;
                  newrec_.report_from_date     := rec_.d3;
                  newrec_.report_until_date    := rec_.d4;
                  newrec_.cal_year             := rec_.N3;
                  newrec_.cal_month            := rec_.N4;
                  Client_SYS.Clear_Attr(attr_);
                  indrec_ := Get_Indicator_Rec___(newrec_);
                  Check_Insert___(newrec_, indrec_, attr_);
                  Insert___(objid_, objversion_, newrec_, attr_);
               EXCEPTION
                  WHEN OTHERS THEN
                     msg_ := SQLERRM;
                     @ApproveTransactionStatement(2014-03-24,dipelk)
                     ROLLBACK TO make_company_insert;
                     Enterp_Comp_Connect_V170_API.Log_Logging(crecomp_rec_.company, module_, 'ACCOUNTING_PERIOD_API', 'Error', msg_);
               END;
            END LOOP;
         END IF;
         IF ( i_ = 0 ) THEN
            msg_ := language_sys.translate_constant(lu_name_, 'NODATAFOUND: No Data Found');
            Enterp_Comp_Connect_V170_API.Log_Logging(crecomp_rec_.company, module_, 'ACCOUNTING_PERIOD_API', 'CreatedSuccessfully', msg_);
         ELSE
            IF msg_ IS NULL THEN
               Enterp_Comp_Connect_V170_API.Log_Logging(crecomp_rec_.company, module_, 'ACCOUNTING_PERIOD_API', 'CreatedSuccessfully');
            ELSE
               Enterp_Comp_Connect_V170_API.Log_Logging(crecomp_rec_.company, module_, 'ACCOUNTING_PERIOD_API', 'CreatedWithErrors');
            END IF;
         END IF;
      ELSE
         Enterp_Comp_Connect_V170_API.Log_Logging(crecomp_rec_.company, module_, 'ACCOUNTING_PERIOD_API', 'CreatedSuccessfully');
      END IF;
   END IF;
EXCEPTION
   WHEN OTHERS THEN
      msg_ := SQLERRM;
      Enterp_Comp_Connect_V170_API.Log_Logging(crecomp_rec_.company, module_, 'ACCOUNTING_PERIOD_API', 'Error', msg_);
      Enterp_Comp_Connect_V170_API.Log_Logging(crecomp_rec_.company, module_, 'ACCOUNTING_PERIOD_API', 'CreatedWithErrors');
END Import___;


PROCEDURE Copy___ (
   crecomp_rec_   IN Enterp_Comp_Connect_V170_API.Crecomp_Lu_Public_Rec )
IS
   attr_          VARCHAR2(2000);
   objid_         VARCHAR2(2000);
   objversion_    VARCHAR2(2000);
   newrec_        ACCOUNTING_PERIOD_TAB%ROWTYPE;
   empty_rec_     ACCOUNTING_PERIOD_TAB%ROWTYPE;
   msg_           VARCHAR2(2000);
   i_             NUMBER := 0;
   update_by_key_ BOOLEAN;
   any_rows_      BOOLEAN := FALSE;
   start_month_   NUMBER;
   month_         NUMBER;
   period_type_   VARCHAR2(20);
   cal_year_      NUMBER;
   indrec_        Indicator_Rec;
   CURSOR get_data IS
      SELECT accounting_year, accounting_period, description, year_end_period, date_from,
      date_until, report_from_date, report_until_date, cal_year,cal_month
      FROM   accounting_period_tab src 
      WHERE  company = crecomp_rec_.old_company
      AND    NOT EXISTS (SELECT 1 
                         FROM accounting_period_tab dest
                         WHERE dest.company = crecomp_rec_.company
                         AND dest.accounting_year = src.accounting_year
                         AND dest.accounting_period = src.accounting_period)
      ORDER BY accounting_year, accounting_period;
BEGIN
   update_by_key_ := Enterp_Comp_Connect_V170_API.Use_Keys(module_, lu_name_, crecomp_rec_);

   IF (update_by_key_) THEN
      IF (Company_Finance_API.Get_User_Def_Cal(crecomp_rec_.company) = 'FALSE') THEN
         FOR rec_ IN get_data LOOP
            i_ := i_ + 1;
            @ApproveTransactionStatement(2014-03-25,dipelk)
            SAVEPOINT make_company_insert;
            BEGIN

               newrec_ := empty_rec_;
          
               newrec_.accounting_year      := rec_.accounting_year;
               newrec_.accounting_period    := rec_.accounting_period;
               newrec_.description          := rec_.description;
               newrec_.year_end_period      := rec_.year_end_period;
               newrec_.period_status        := 'O';
               newrec_.period_status_int    := 'O';
               newrec_.date_from            := rec_.date_from;
               newrec_.date_until           := rec_.date_until;
               newrec_.consolidated         := 'N';
               newrec_.report_from_date     := rec_.report_from_date;
               newrec_.report_until_date    := rec_.report_until_date;
               newrec_.cal_year             := rec_.cal_year;
               newrec_.cal_month            := rec_.cal_month;
               newrec_.company              := crecomp_rec_.company;
               Client_SYS.Clear_Attr(attr_);
               indrec_ := Get_Indicator_Rec___(newrec_);
               Check_Insert___(newrec_, indrec_, attr_);
               Insert___(objid_, objversion_, newrec_, attr_);
            EXCEPTION
               WHEN OTHERS THEN
                  msg_ := SQLERRM;
                  @ApproveTransactionStatement(2014-03-24,dipelk)
                  ROLLBACK TO make_company_insert;
                  Enterp_Comp_Connect_V170_API.Log_Logging(crecomp_rec_.company, module_, 'ACCOUNTING_PERIOD_API', 'Error', msg_);                                                   
            END;
         END LOOP;
         IF (i_ = 0) THEN
            msg_ := Language_SYS.Translate_Constant(lu_name_, 'NODATAFOUND: No Data Found');
            Enterp_Comp_Connect_V170_API.Log_Logging(crecomp_rec_.company, module_, 'ACCOUNTING_PERIOD_API', 'CreatedSuccessfully', msg_);                                                   
         ELSE
            IF (msg_ IS NULL) THEN
               Enterp_Comp_Connect_V170_API.Log_Logging(crecomp_rec_.company, module_, 'ACCOUNTING_PERIOD_API', 'CreatedSuccessfully');                  
            ELSE
               Enterp_Comp_Connect_V170_API.Log_Logging(crecomp_rec_.company, module_, 'ACCOUNTING_PERIOD_API', 'CreatedWithErrors');                     
            END IF;                     
         END IF;
      END IF;
      Enterp_Comp_Connect_V170_API.Log_Logging(crecomp_rec_.company, module_, 'ACCOUNTING_PERIOD_API', 'CreatedSuccessfully');
   ELSE
      any_rows_ := Exist_Any___(crecomp_rec_.company);
      IF (NOT any_rows_) THEN
         IF (crecomp_rec_.user_defined = 'TRUE') THEN
            start_month_ := crecomp_rec_.cal_start_month;
            FOR year_ IN 0..crecomp_rec_.number_of_years-1 LOOP
               month_ := start_month_;
               cal_year_ := crecomp_rec_.cal_start_year + year_;
               FOR period_ IN 0..12 LOOP
                  @ApproveTransactionStatement(2014-03-25,dipelk)
                  SAVEPOINT make_company_insert;
                  BEGIN
                     IF (month_ = 13) THEN
                        month_ := 1;
                        cal_year_ := crecomp_rec_.cal_start_year + year_ + 1;
                     END IF;
                     IF period_ = 0 THEN
                        period_type_ := 'YEAROPEN';
                     ELSE
                        period_type_ := 'ORDINARY';
                     END IF;
                     newrec_.company              := crecomp_rec_.company;
                     newrec_.accounting_year      := crecomp_rec_.acc_year + year_;
                     newrec_.accounting_period    := period_;
                     newrec_.description          := Get_Period_Desc(cal_year_,period_,month_);
                     newrec_.year_end_period      := period_type_;
                     newrec_.period_status        := 'O';
                     newrec_.period_status_int    := 'O';
                     newrec_.date_from            := Get_First_Day_Month___(month_,cal_year_);
                     IF period_ = 0 THEN
                        newrec_.date_until := newrec_.date_from;
                     ELSE
                        newrec_.date_until  := LAST_DAY(newrec_.date_from);
                     END IF;
                     newrec_.consolidated         := 'N';
                     newrec_.report_from_date     := NULL;
                     newrec_.report_until_date    := NULL;
                     newrec_.cal_year             := cal_year_;
                     newrec_.cal_month            := month_;
                     IF (period_ = 0) THEN
                        newrec_.cal_month := 0;
                        newrec_.cal_year  := newrec_.accounting_year;
                     END IF;
                     Client_SYS.Clear_Attr(attr_);
                     indrec_ := Get_Indicator_Rec___(newrec_);
                     Check_Insert___(newrec_, indrec_, attr_);
                     Insert___(objid_, objversion_, newrec_, attr_);

                     IF (period_ != 0)THEN
                        month_ := month_ + 1;
                     END IF;
                  EXCEPTION
                     WHEN OTHERS THEN
                        msg_ := SQLERRM;
                        @ApproveTransactionStatement(2014-03-24,dipelk)
                        ROLLBACK TO make_company_insert;
                        Enterp_Comp_Connect_V170_API.Log_Logging(crecomp_rec_.company, module_, 'ACCOUNTING_PERIOD_API', 'Error', msg_);
                  END;
               END LOOP;
            END LOOP;
         ELSE
            FOR rec_ IN get_data LOOP
               i_ := i_ + 1;
               BEGIN

                  newrec_ := empty_rec_;
                 
                  newrec_.accounting_year      := rec_.accounting_year;
                  newrec_.accounting_period    := rec_.accounting_period;
                  newrec_.description          := rec_.description;
                  newrec_.year_end_period      := rec_.year_end_period;
                  newrec_.period_status        := 'O';
                  newrec_.period_status_int    := 'O';
                  newrec_.date_from            := rec_.date_from;
                  newrec_.date_until           := rec_.date_until;
                  newrec_.consolidated         := 'N';
                  newrec_.report_from_date     := rec_.report_from_date;
                  newrec_.report_until_date    := rec_.report_until_date;
                  newrec_.cal_year             := rec_.cal_year;
                  newrec_.cal_month            := rec_.cal_month;
                  newrec_.company              := crecomp_rec_.company;
                  Client_SYS.Clear_Attr(attr_);
                  indrec_ := Get_Indicator_Rec___(newrec_);
                  Check_Insert___(newrec_, indrec_, attr_);
                  Insert___(objid_, objversion_, newrec_, attr_);
               EXCEPTION
                  WHEN OTHERS THEN
                     msg_ := SQLERRM;
                     Enterp_Comp_Connect_V170_API.Log_Logging(crecomp_rec_.company, module_, 'ACCOUNTING_PERIOD_API', 'Error', msg_);                                                   
               END;
            END LOOP;
         END IF;
         IF (i_ = 0) THEN
            msg_ := Language_SYS.Translate_Constant(lu_name_, 'NODATAFOUND: No Data Found');
            Enterp_Comp_Connect_V170_API.Log_Logging(crecomp_rec_.company, module_, 'ACCOUNTING_PERIOD_API', 'CreatedSuccessfully', msg_);                                                   
         ELSE
            IF (msg_ IS NULL) THEN
               Enterp_Comp_Connect_V170_API.Log_Logging(crecomp_rec_.company, module_, 'ACCOUNTING_PERIOD_API', 'CreatedSuccessfully');                  
            ELSE
               Enterp_Comp_Connect_V170_API.Log_Logging(crecomp_rec_.company, module_, 'ACCOUNTING_PERIOD_API', 'CreatedWithErrors');                     
            END IF;                     
         END IF;
      ELSE
         Enterp_Comp_Connect_V170_API.Log_Logging(crecomp_rec_.company, module_, 'ACCOUNTING_PERIOD_API', 'CreatedSuccessfully');
      END IF;
   END IF;
EXCEPTION
   WHEN OTHERS THEN
      msg_ := SQLERRM;
      Enterp_Comp_Connect_V170_API.Log_Logging(crecomp_rec_.company, module_, 'ACCOUNTING_PERIOD_API', 'Error', msg_);
      Enterp_Comp_Connect_V170_API.Log_Logging(crecomp_rec_.company, module_, 'ACCOUNTING_PERIOD_API', 'CreatedWithErrors');
END Copy___;


PROCEDURE Export___ (
   crecomp_rec_   IN Enterp_Comp_Connect_V170_API.Crecomp_Lu_Public_Rec )
IS
   pub_rec_       Enterp_Comp_Connect_V170_API.Tem_Public_Rec;
   i_              NUMBER := 1;

   CURSOR get_data IS
      SELECT accounting_year, accounting_period, description, year_end_period, date_from,
      date_until, report_from_date, report_until_date, cal_year,cal_month
      FROM   accounting_period_tab
      WHERE  company = crecomp_rec_.company
      ORDER BY accounting_year, accounting_period;
BEGIN
   FOR pctrec_ IN get_data LOOP
      pub_rec_.template_id := crecomp_rec_.template_id;
      pub_rec_.component := module_;
      pub_rec_.version  := crecomp_rec_.version;
      pub_rec_.lu := lu_name_;
      pub_rec_.item_id := i_;
      pub_rec_.n1 := pctrec_.accounting_year;
      pub_rec_.n2 := pctrec_.accounting_period;
      pub_rec_.c1 := pctrec_.description;
      pub_rec_.c2 := pctrec_.year_end_period;
      pub_rec_.c3 := 'O';
      pub_rec_.c5 := 'O';
      pub_rec_.d1 := pctrec_.date_from;
      pub_rec_.d2 := pctrec_.date_until;
      pub_rec_.c4 := 'N';
      pub_rec_.d3 := pctrec_.report_from_date;
      pub_rec_.d4 := pctrec_.report_until_date;
      pub_rec_.n3 := pctrec_.cal_year;
      pub_rec_.n4 := pctrec_.cal_month;
      Enterp_Comp_Connect_V170_API.Tem_Insert_Detail_Data(pub_rec_);
      i_ := i_ + 1;
   END LOOP;
END Export___;


PROCEDURE Validate_Report_Date___(
   company_             IN VARCHAR2,
   accounting_year_     IN NUMBER,
   accounting_period_   IN NUMBER,
   report_from_date_    IN DATE,
   report_until_date_   IN DATE,
   valid_until_date_    IN DATE )
IS
   max_rep_until_date_  DATE;
   min_rep_from_date_   DATE;

   CURSOR get_max_rep_until_date IS
      SELECT MAX(report_until_date)
      FROM ACCOUNTING_PERIOD_TAB
      WHERE company            = company_
      AND   accounting_year    = accounting_year_
      AND   accounting_period  < accounting_period_
      AND   report_until_date IS NOT NULL;

   CURSOR get_min_rep_from_date  IS
      SELECT MIN(report_from_date)
      FROM ACCOUNTING_PERIOD_TAB
      WHERE company            = company_
      AND   accounting_year    = accounting_year_
      AND   accounting_period  > accounting_period_
      AND   report_from_date IS NOT NULL;
   
BEGIN     
   IF (((report_from_date_    IS NOT NULL) AND (report_until_date_ IS NULL))
      OR ((report_until_date_ IS NOT NULL) AND (report_from_date_  IS NULL))) THEN
      Error_SYS.Record_General(lu_name_, 'ERRBOTHDATES: Both Report From Date and Report Until Date must have values');
   END IF;

   IF (report_from_date_  IS NOT NULL) THEN
      IF NOT (report_from_date_ >= valid_until_date_)  THEN
         Error_SYS.Record_General(lu_name_, 'ERRFROMDATE: Report From Date must be equal or later than the Valid Until Date');
      END IF;

      OPEN get_max_rep_until_date;
      FETCH get_max_rep_until_date INTO max_rep_until_date_;
      CLOSE get_max_rep_until_date;

      IF (report_from_date_ <= max_rep_until_date_)    THEN
         Error_SYS.Record_General(lu_name_, 'ERRMINFROMDATE: Report From Date must be later than Report Until Date for the closest previous period');
      END IF;

      OPEN  get_min_rep_from_date;
      FETCH get_min_rep_from_date  INTO min_rep_from_date_;
      CLOSE get_min_rep_from_date;

      IF (report_until_date_ >= min_rep_from_date_)  THEN
         Error_SYS.Record_General(lu_name_, 'ERRMAXUNTILDATE: Report Until Date must be earlier than Report From Date of the closest next period');
      END IF;

   END IF;
   IF (report_until_date_ IS NOT NULL) THEN
      IF NOT (report_until_date_ >= report_from_date_) THEN
         Error_SYS.Record_General(lu_name_, 'ERRMINUNTILDATE: Report Until Date must be equal or later than Report From Date');
      END IF;
   END IF;
END Validate_Report_Date___;


FUNCTION Get_First_Day_Month___(
   month_   IN NUMBER,
   year_    IN NUMBER ) RETURN DATE
IS
   v_month_  VARCHAR2(2);
   v_year_   VARCHAR2(4);
BEGIN
   v_month_ := TRIM(TO_CHAR(month_,'00'));
   v_year_  := TO_CHAR(year_);
   RETURN TO_DATE(v_year_ || '-' || v_month_ || '-01' ,'YYYY-MM-DD','NLS_CALENDAR=GREGORIAN');
END Get_First_Day_Month___;


FUNCTION Get_Set_Off_Year___ (
    cal_year_     IN NUMBER,
    cal_month_    IN NUMBER,
    month_diff_   IN NUMBER) RETURN NUMBER
IS
    year_         NUMBER;
BEGIN
    IF (cal_month_ = 0) THEN
       year_ := cal_year_;
    ELSIF (cal_month_ <= month_diff_) THEN
       year_ := cal_year_ - 1;
    ELSE
       year_ := cal_year_;
    END IF;
    
    RETURN year_;
END Get_Set_Off_Year___;


FUNCTION Get_Set_Off_Month___ (
    cal_year_     IN NUMBER,
    cal_month_    IN NUMBER,
    month_diff_   IN NUMBER) RETURN NUMBER
IS
    month_        NUMBER;
BEGIN
    IF (cal_month_ = 0) THEN
       month_ := 0;
    ELSIF (cal_month_ <= month_diff_) THEN
       month_ := cal_month_ + (12 - month_diff_) ;
    ELSE
       month_ := cal_month_ - month_diff_ ;
    END IF;
    RETURN month_;
END Get_Set_Off_Month___;


FUNCTION Build_Year_Period_Key___(year_period_rec_ Year_Period_Rec) RETURN VARCHAR
IS
   ypk_   VARCHAR2(10);
BEGIN
   ypk_ := TO_CHAR(year_period_rec_.Accounting_Year*100+year_period_rec_.Accounting_Period);
   RETURN ypk_;
END Build_Year_Period_Key___;


@Override
PROCEDURE Prepare_Insert___ (
   attr_ IN OUT VARCHAR2 )
IS
BEGIN
   super(attr_);
   Client_SYS.Add_To_Attr( 'PERIOD_STATUS',     Acc_Per_Status_API.Decode('O'),          attr_ );
   Client_SYS.Add_To_Attr( 'PERIOD_STATUS_INT', Acc_Per_Status_API.Decode('O'),          attr_ );
   Client_SYS.Add_To_Attr( 'CONSOLIDATED',      Consolidated_Yes_No_API.Decode('N'),     attr_ );
   Client_SYS.Add_To_Attr( 'YEAR_END_PERIOD',      Period_Type_API.Decode('ORDINARY'),     attr_ );
END Prepare_Insert___;


@Override
PROCEDURE Insert___ (
   objid_      OUT    VARCHAR2,
   objversion_ OUT    VARCHAR2,
   newrec_     IN OUT ACCOUNTING_PERIOD_TAB%ROWTYPE,
   attr_       IN OUT VARCHAR2 )
IS
   lang_code_        VARCHAR2(10) := Language_SYS.Get_Language;
BEGIN
   super(objid_, objversion_, newrec_, attr_);

   Enterp_Comp_Connect_V170_API.Insert_Company_Translation( newrec_.company,
                                                            'ACCRUL',
                                                            'AccountingPeriod',
                                                            newrec_.accounting_year||'^'||newrec_.accounting_period,
                                                            lang_code_,
                                                            newrec_.description );
   Invalidate_Year_Per_Cache___;
EXCEPTION
   WHEN dup_val_on_index THEN
      Error_SYS.Record_Exist(lu_name_);
END Insert___;


@Override
PROCEDURE Update___ (
   objid_      IN     VARCHAR2,
   oldrec_     IN     ACCOUNTING_PERIOD_TAB%ROWTYPE,
   newrec_     IN OUT ACCOUNTING_PERIOD_TAB%ROWTYPE,
   attr_       IN OUT VARCHAR2,
   objversion_ IN OUT VARCHAR2,
   by_keys_    IN     BOOLEAN DEFAULT FALSE )
IS
BEGIN
   super(objid_, oldrec_, newrec_, attr_, objversion_, by_keys_);
   -- Bug 104778, Begin
   Enterp_Comp_Connect_V170_API.Insert_Company_Translation( newrec_.company,
                                                            'ACCRUL',
                                                            'AccountingPeriod',
                                                            NVL(newrec_.cal_year,newrec_.accounting_year)||'^'||NVL(newrec_.cal_month,newrec_.accounting_period),
                                                            NULL,
                                                            newrec_.description,
                                                            oldrec_.description  );
   -- Bug 104778, End
   Invalidate_Year_Per_Cache___;
EXCEPTION
   WHEN dup_val_on_index THEN
      Error_SYS.Record_Exist(lu_name_);
END Update___;


@Override
PROCEDURE Check_Delete___ (
   remrec_ IN ACCOUNTING_PERIOD_TAB%ROWTYPE )
IS
   exists_   VARCHAR2(10);
BEGIN
   Check_Delete_Record__(exists_,
                         remrec_.company,
                         remrec_.accounting_year,
                         remrec_.accounting_period);
   IF exists_ = 'TRUE' THEN
      Error_SYS.Record_General(lu_name_,'NO_DEL_PER: You cannot delete the period :P1 it exists in the GL or wait table',remrec_.accounting_period);
   END IF;
   --
   super(remrec_);
END Check_Delete___;


@Override
PROCEDURE Delete___ (
   objid_  IN VARCHAR2,
   remrec_ IN ACCOUNTING_PERIOD_TAB%ROWTYPE )
IS
BEGIN
   
   $IF Component_Genled_SYS.INSTALLED $THEN
      Accounting_Journal_Item_API.Sync_Acc_Periods(remrec_.company, 
                                                   remrec_.accounting_year, 
                                                   remrec_.accounting_period,
                                                   remove_period_ => 'TRUE');
   $END

   Enterp_Comp_Connect_V170_API.Remove_Company_Attribute_Key( remrec_.company,
                                                              'ACCRUL',
                                                              'AccountingPeriod',
                                                              remrec_.accounting_year||'^'||remrec_.accounting_period );

   
   super(objid_, remrec_);
   Invalidate_Year_Per_Cache___;
END Delete___;

PROCEDURE Invalidate_Year_Per_Cache___
IS
   null_value_ Year_Period_Rec;
BEGIN
      micro_cache_year_per_tab_.delete;
      micro_cache_year_per_value_ := null_value_;
      micro_cache_year_per_time_  := 0;
END Invalidate_Year_Per_Cache___;


PROCEDURE Update_Year_Per_Cache___ (
   company_ IN VARCHAR2,
   actual_date_ IN DATE )
IS
   date_param_ DATE := TRUNC(actual_date_);
   req_id_     VARCHAR2(1000) := company_||'^'||TO_CHAR(date_param_, 'YYYY-MM-DD');
   null_value_ Year_Period_Rec;
   time_       NUMBER;
   expired_    BOOLEAN;   
   
   CURSOR get_accounting_year IS
      SELECT  accounting_year, accounting_period
        FROM  accounting_period_tab
       WHERE  company      = company_
         AND  date_from    <= date_param_
         AND  date_until   >= date_param_
         ORDER BY accounting_period ASC;   
BEGIN   
   time_       := Database_SYS.Get_Time_Offset;
   expired_    := ((time_ - micro_cache_year_per_time_) > 100);
   IF (expired_ OR (micro_cache_year_per_user_ IS NULL) OR (micro_cache_year_per_user_ != Fnd_Session_API.Get_Fnd_User)) THEN
      Invalidate_Year_Per_Cache___;
      micro_cache_year_per_user_ := Fnd_Session_API.Get_Fnd_User;
   END IF;
   IF (NOT micro_cache_year_per_tab_.exists(req_id_)) THEN      
      OPEN  get_accounting_year;
      FETCH get_accounting_year INTO micro_cache_year_per_value_;      
      IF (get_accounting_year%NOTFOUND) THEN
         micro_cache_year_per_value_ := null_value_;
         micro_cache_year_per_time_  := time_;         
         RETURN;
      ELSE
         IF (micro_cache_year_per_tab_.count >= 10) THEN
            DECLARE
               random_  NUMBER := NULL;
               element_ VARCHAR2(1000);
            BEGIN
               random_  := round(dbms_random.value(1,10), 0);
               element_ := micro_cache_year_per_tab_.first;
               FOR i IN 1..random_-1 LOOP
                  element_ := micro_cache_year_per_tab_.next(element_);
               END LOOP;
               micro_cache_year_per_tab_.delete(element_);               
            END;
         END IF;
         micro_cache_year_per_tab_(req_id_) := micro_cache_year_per_value_;
         micro_cache_year_per_time_ := time_;
      END IF;      
      CLOSE get_accounting_year;            
   END IF;
   micro_cache_year_per_value_ := micro_cache_year_per_tab_(req_id_);
END Update_Year_Per_Cache___;   


PROCEDURE Get_Period_Info___(
   accounting_year_       OUT NUMBER,
   accounting_period_     OUT NUMBER,
   company_            IN     VARCHAR2,
   actual_date_        IN     DATE      )
IS 
BEGIN
   Update_Year_Per_Cache___(company_, actual_date_);
   accounting_year_ := micro_cache_year_per_value_.Accounting_Year;
   accounting_period_ := micro_cache_year_per_value_.Accounting_Period;
END Get_Period_Info___;


@Override
PROCEDURE Check_Common___ (
   oldrec_ IN     accounting_period_tab%ROWTYPE,
   newrec_ IN OUT accounting_period_tab%ROWTYPE,
   indrec_ IN OUT Indicator_Rec,
   attr_   IN OUT VARCHAR2 )
IS
   manual_change     EXCEPTION;   
BEGIN
   super(oldrec_, newrec_, indrec_, attr_);
   IF (indrec_.consolidated) THEN
      IF (newrec_.consolidated = 'Y') THEN
         RAISE manual_change;
      END IF;
   END IF; 
   
   Check_Previous_Year_End_Period(newrec_.company,newrec_.accounting_year,
                                  newrec_.accounting_period,newrec_.year_end_period,newrec_.date_from,
                                  newrec_.date_until,newrec_.period_status,newrec_.period_status_int);                          
   IF (newrec_.year_end_period = 'YEAROPEN') THEN
      Check_Year_Opening_Period__(newrec_.company,newrec_.accounting_year,newrec_.accounting_period);
      Check_Opening_Date__(newrec_.company,newrec_.accounting_year,newrec_.accounting_period,newrec_.date_from,newrec_.date_until);
   END IF;

   Check_Valid_Range__(newrec_.date_from, newrec_.date_until);

   Validate_Report_Date___(
      newrec_.company,
      newrec_.accounting_year,
      newrec_.accounting_period,
      newrec_.report_from_date,
      newrec_.report_until_date,
      newrec_.date_until );
EXCEPTION
   WHEN manual_change THEN
      Error_SYS.Record_General(lu_name_,'BALCONFLAG: You can not manually set Balance Consolidated Flag');   
END Check_Common___;


@Override
PROCEDURE Check_Insert___ (
   newrec_ IN OUT accounting_period_tab%ROWTYPE,
   indrec_ IN OUT Indicator_Rec,
   attr_   IN OUT VARCHAR2 )
IS
   name_             VARCHAR2(30);
   value_            VARCHAR2(4000);
BEGIN
   super(newrec_, indrec_, attr_);
   IF ( LENGTH(newrec_.accounting_period) > 2 ) THEN
      Error_SYS.Appl_General(lu_name_, 'ACCPERIODEXCEEDED: The accounting period should consist of either one character or two characters.');
   END IF;


   IF (newrec_.year_end_period='YEARCLOSE') THEN
      Check_Year_End_Period(newrec_.company,newrec_.accounting_year,newrec_.accounting_period);
   END IF;
   
   -- Bug 105642 Begin
   Check_period_dates_new__(newrec_.company,newrec_.accounting_period,newrec_.date_from, newrec_.accounting_year, newrec_.year_end_period);
   Check_period_dates_new__(newrec_.company,newrec_.accounting_period,newrec_.date_until, newrec_.accounting_year, newrec_.year_end_period);
   -- Bug 105642 End
   
   Check_Whole_Period__(newrec_.company,newrec_.date_from,newrec_.date_until);

   IF ( newrec_.period_status = 'O' AND newrec_.period_status_int = 'C') THEN
      Error_Sys.Record_General(lu_name_,'PERSTAT: GL Period Status should be closed before Status of IL Period is in Closed.');
   END IF;

   $IF Component_Genled_SYS.INSTALLED $THEN
      Accounting_Journal_Item_API.Sync_Acc_Periods(newrec_.company, 
                                                   newrec_.accounting_year, 
                                                   newrec_.accounting_period,
                                                   add_period_ => 'TRUE');
   $END
EXCEPTION
   WHEN value_error THEN
      Error_SYS.Item_Format(lu_name_, name_, value_);
END Check_Insert___;


@Override
PROCEDURE Check_Update___ (
   oldrec_ IN     accounting_period_tab%ROWTYPE,
   newrec_ IN OUT accounting_period_tab%ROWTYPE,
   indrec_ IN OUT Indicator_Rec,
   attr_   IN OUT VARCHAR2 )
IS
   true_false_          VARCHAR2(1);
   period_status_       VARCHAR2(200);
   period_status_int_   VARCHAR2(200);
   dates_changed_       BOOLEAN := FALSE;
   prev_date_from_      DATE;
   prev_date_until_     DATE;
   s_period_status_     VARCHAR2(1);
   period_modified_     BOOLEAN := FALSE;

BEGIN
   prev_date_from_  := oldrec_.date_from;
   prev_date_until_ := oldrec_.date_until;
   
   IF (indrec_.period_status) THEN
      indrec_.period_status := FALSE;
      s_period_status_ := newrec_.period_status;
      IF ((oldrec_.period_status <> s_period_status_) AND
         (s_period_status_ = 'O') AND
         (oldrec_.consolidated = 'Y')) THEN
        Error_SYS.Appl_General(lu_name_,'PERIODCONSOLIDATED: Selected period has been consolidated.:P1Consolidation must be cancelled/rolled-back before reopening the period.', CHR(10)||CHR(13));
      END IF;

      IF (oldrec_.period_status <> s_period_status_) THEN
        period_modified_ := TRUE;
      END IF;
      newrec_.period_status := s_period_status_;
   END IF;
   IF (indrec_.date_from) THEN
       dates_changed_ := TRUE;
   END IF;
   IF (indrec_.date_until) THEN
       dates_changed_ := TRUE;
   END IF; 
   
   super(oldrec_, newrec_, indrec_, attr_);

   -------------------------------------------------------------------------------

   IF ( newrec_.period_status = 'O' AND newrec_.period_status_int = 'C') THEN
      -- Bug 105088, Begin, Added condition
      IF period_modified_ THEN
         Error_Sys.Record_General(lu_name_,'ILPERCL: The IL period should be in Open status before you open the GL period.');
      ELSE
         Error_Sys.Record_General(lu_name_,'PERSTAT: GL Period Status should be closed before Status of IL Period is in Closed.');
      END IF;      
      -- Bug 105088, End
   END IF;
   -----------------------------------------------------------------------------------
   -- Added to close User Groups per Period if Accounting Period is closed.
   IF( newrec_.period_status = 'C' )THEN
      Check_Close_period(true_false_,newrec_.company,newrec_.accounting_year,newrec_.accounting_period);
      period_status_     := Acc_Per_Status_API.Decode(newrec_.period_status);
      period_status_int_ := Acc_Per_Status_API.Decode(newrec_.period_status_int);
      --27/02/2006 Bug 132835
      --IF (newrec_.year_end_period !='YEARCLOSE') THEN
         User_Group_Period_API.Update_period_status_( newrec_.company,
                                                      period_status_,
                                                      period_status_int_,
                                                      newrec_.accounting_year,
                                                      newrec_.accounting_period);
      --END IF;
   END IF;
   IF newrec_.period_status = 'F' THEN
      Check_Close_period(true_false_,newrec_.company,newrec_.accounting_year,newrec_.accounting_period);
   END IF;
   ------------------------------------------------------------------------

   -- check there are any transactions in hold table before close period_status_int .
   IF( newrec_.period_status_int = 'C' )THEN
      $IF Component_Intled_SYS.INSTALLED $THEN
         IF( Internal_Hold_Manual_API.Check_Voucher_In_Holdtab(newrec_.company,
                                                                       newrec_.accounting_period,
                                                                       newrec_.accounting_year) = 'TRUE')THEN
            Error_SYS.Record_General(lu_name_,'PER_HOLD_WAI: There are transactions in the wait table that belongs to this period :P1', newrec_.accounting_period);
         END IF;
      $ELSE
         NULL;
      $END
   END IF;
-----------------------------------------------------------------------------------------

   -- check if any accounting year and accounting period exist in period allocation tab before user
   -- could change period allocation from open to close period

   --IF( PERIOD_ALLOCATION_API.Check_Year_Period_Exist(newrec_.company,newrec_.accounting_year,newrec_.accounting_period) )THEN
   --   Error_SYS.Record_General(lu_name_,'CHG_STATUS: You cannot change the status on this period :P1 it exists in Period Allocation table', newrec_.accounting_period);
   --END IF;
   IF (newrec_.period_status = 'C') OR (newrec_.period_status = 'F') THEN
      IF Period_Allocation_API.Check_Year_Period_Exist(newrec_.company,newrec_.accounting_year,newrec_.accounting_period) = 'TRUE' THEN
         Error_SYS.Record_General(lu_name_,'CHG_STATUS: You cannot change the status on this period :P1 it exists in Period Allocation table', newrec_.accounting_period);
      END IF;
   END IF;


   IF (dates_changed_) THEN
      IF((prev_date_from_ != newrec_.date_from) OR (prev_date_until_ != newrec_.date_until))   THEN
             Check_Dt_Change_Allowed___( newrec_.company,
                                         newrec_.accounting_year,
                                         newrec_.accounting_period );
      END IF;
   END IF;

   IF (newrec_.year_end_period = 'YEARCLOSE') THEN
       Check_Previous_Year_End_Period(newrec_.company,newrec_.accounting_year,
                          newrec_.accounting_period,newrec_.year_end_period,newrec_.date_from,
                          newrec_.date_until,newrec_.period_status,newrec_.period_status_int);
   END IF;

   IF period_modified_ THEN
      IF newrec_.period_status = 'F' THEN
         Validate_Final_Close___(newrec_);
      ELSIF newrec_.period_status = 'C' THEN
         Validate_Close___(newrec_);
      ELSE 
         $IF Component_Genled_SYS.INSTALLED $THEN
            Accounting_Journal_Item_API.Sync_Acc_Periods(newrec_.company, 
                                                   newrec_.accounting_year, 
                                                   newrec_.accounting_period);
         $ELSE
            NULL;
         $END
      END IF;
      -- Bug 122078 - Removed the ELSE Section. 
   END IF;
   
END Check_Update___;


-------------------- LU SPECIFIC PRIVATE METHODS ----------------------------

PROCEDURE Check_Delete_Record__ (
   exists_                OUT VARCHAR2,
   company_            IN     VARCHAR2,
   accounting_year_    IN     NUMBER,
   accounting_period_  IN     NUMBER )
IS
   attr_               VARCHAR2(2000);
BEGIN

   Client_SYS.Clear_Attr(attr_);
   Client_SYS.Add_To_Attr('COMPANY', company_, attr_);
   Client_SYS.Add_To_Attr('ACCOUNTING_YEAR', accounting_year_, attr_);
   Client_SYS.Add_To_Attr('ACCOUNTING_PERIOD', accounting_period_, attr_);
   $IF Component_Genled_SYS.INSTALLED $THEN
      Gen_Led_Voucher_API.Period_Delete_Allowed ( attr_ );
      Project_Balance_API.Period_Delete_Allowed ( attr_ );
      Accounting_Journal_Item_API.Sync_Acc_Periods(company_, 
                                                   accounting_year_, 
                                                   accounting_period_);
   $END
   Voucher_API.Period_Delete_Allowed(attr_);
END Check_Delete_Record__;


PROCEDURE Check_Period_Dates_New__ (
   company_            IN VARCHAR2,
   accounting_period_  IN NUMBER,
   date_               IN DATE,
   accounting_year_    IN NUMBER DEFAULT NULL,
   year_end_period_    IN VARCHAR2 DEFAULT 'ORDINARY' )
IS
   acc_year_               NUMBER;
   acc_period_             NUMBER;
   period_already_exists_  VARCHAR2(5);
   period_type_            VARCHAR2(10);


   CURSOR get_acc_info IS
      SELECT accounting_year, accounting_period, year_end_period
      FROM ACCOUNTING_PERIOD_TAB
      WHERE company         = company_
      AND   date_ BETWEEN date_from AND date_until;
BEGIN
   
   OPEN  get_acc_info;
   FETCH get_acc_info INTO acc_year_, acc_period_, period_type_;
   CLOSE get_acc_info;


   IF (year_end_period_ = 'ORDINARY' AND year_end_period_ = period_type_) THEN
      IF (acc_year_ IS NULL OR (acc_year_ = accounting_year_ AND acc_period_ = accounting_period_)) THEN
         period_already_exists_ := 'FALSE';
      ELSE
         period_already_exists_ := 'TRUE';
      END IF;
   ELSE
      IF (acc_year_ IS NULL OR acc_year_ = accounting_year_ ) THEN
         period_already_exists_ := 'FALSE';
      ELSE
         period_already_exists_ := 'TRUE';
      END IF;
   END IF;


   IF (period_already_exists_ = 'TRUE') THEN
      Error_SYS.Record_General(lu_name_,'IN_ANOTHER_PERIOD: Date :P1 is already part of another period', date_);
   END IF;
END Check_Period_Dates_New__;


PROCEDURE Check_Whole_Period__ (
   company_          IN VARCHAR2,
   date_from_        IN DATE,
   date_until_       IN DATE )
IS
   dummy_            VARCHAR2(10);

CURSOR
   Check_dates IS
   SELECT 'TRUE'
   FROM ACCOUNTING_PERIOD_TAB
   WHERE company    = company_
   AND   date_from  > date_from_
   AND   date_until < date_until_;
BEGIN
   dummy_ := 'FALSE';
   OPEN  Check_dates;
   FETCH Check_dates INTO dummy_;
   -- Bug 112154, Begin
   CLOSE Check_dates;
   -- Bug 112154, End
   IF (dummy_ = 'TRUE') THEN
       Error_SYS.Record_General(lu_name_,'IN_PERIOD_OERLAP: This Period overlaps another period');
   END IF;
END Check_Whole_Period__;


PROCEDURE Check_Valid_Range__ (
   date_from_         IN DATE,
   date_until_        IN DATE )
IS
BEGIN
   IF (date_from_ > date_until_) THEN
      Error_SYS.Record_General(lu_name_,'DATERR: Date from must be before date until');
   END IF;
END Check_Valid_Range__;


PROCEDURE Check_Year_Opening_Period__ (
   company_ IN VARCHAR2,
   accounting_year_ IN NUMBER,
   accounting_period_ IN NUMBER )
IS
   min_value_       NUMBER;
   dummy_           NUMBER;

   CURSOR min_period IS
      SELECT MIN(accounting_period)
      FROM   ACCOUNTING_PERIOD_TAB
      WHERE  company = company_
      AND    accounting_year = accounting_year_;

   CURSOR year_open IS
      SELECT 1
      FROM   ACCOUNTING_PERIOD_TAB
      WHERE  company = company_
      AND    accounting_year = accounting_year_
      AND    year_end_period = 'YEAROPEN'
      AND    accounting_period = min_value_ ;

BEGIN

   IF (accounting_period_ != 0 ) THEN
      Error_SYS.Record_General(lu_name_, 'YEAROPENPERIOD2: Only the period 0 can be a year :P1 opening period.',accounting_year_);
   END IF;

   OPEN  min_period;
   FETCH  min_period INTO  min_value_ ;
   CLOSE  min_period;

   OPEN year_open;
   FETCH year_open INTO dummy_;
   IF (year_open%FOUND) THEN
      IF (accounting_period_ > min_value_ ) THEN
         CLOSE year_open;
         Error_SYS.Record_General(lu_name_, 'YEAROPENPERIOD2: Only the period 0 can be a year :P1 opening period.',accounting_year_);
      END IF;
   END IF;
   CLOSE year_open;

END Check_Year_Opening_Period__;


PROCEDURE Get_Opening_Period__ (
   period_desc_ OUT VARCHAR2,
   valid_until_ OUT DATE,
   accounting_period_ OUT NUMBER,
   company_ IN VARCHAR2,
   accounting_year_ IN NUMBER,
   exclude_period_status_ IN VARCHAR2 DEFAULT NULL )
IS

   CURSOR opening_period_data IS
    SELECT accounting_period,description,date_until
    FROM ACCOUNTING_PERIOD_TAB
    WHERE company = company_
    AND   accounting_year = accounting_year_
    AND   year_end_period = 'YEAROPEN'
    AND   period_status = DECODE(exclude_period_status_,NULL,'O',period_status);

BEGIN

   OPEN opening_period_data;
   FETCH opening_period_data INTO accounting_period_,period_desc_,valid_until_;
   CLOSE opening_period_data;

END Get_Opening_Period__;


FUNCTION Get_Year_End_Period_Data__ (
   company_ IN VARCHAR2,
   accounting_year_ IN NUMBER,
   accounting_period_ IN NUMBER ) RETURN VARCHAR2
IS
   y_e_period_                VARCHAR2(20);

  CURSOR cur_year_end_period IS
   SELECT year_end_period
   FROM accounting_period_tab
   WHERE accounting_year = accounting_year_
   and company = company_
   and accounting_period = accounting_period_;

BEGIN
   OPEN cur_year_end_period;
   FETCH cur_year_end_period into y_e_period_;
   CLOSE cur_year_end_period;

RETURN y_e_period_;

END Get_Year_End_Period_Data__;


PROCEDURE Check_Opening_Date__ (
   company_ IN VARCHAR2,
   accounting_year_ IN NUMBER,
   accounting_period_ IN NUMBER,
   date_from_ IN DATE,
   date_until_ IN DATE )
IS
   next_dt_from_         DATE;
   next_dt_until_        DATE;


   CURSOR get_next_date IS
      SELECT date_from,date_until
      FROM   ACCOUNTING_PERIOD_TAB
      WHERE  company = company_
      AND    accounting_year = accounting_year_
      AND accounting_period = (accounting_period_+1) ;
BEGIN

   IF (date_from_ != date_until_) THEN
      Error_SYS.Record_General(lu_name_, 'YEARENDPERIOD7: Valid From and Valid Until of Year Opening Period should be equal to the first date of the financial Year :P1.',accounting_year_);
   END IF;

   OPEN get_next_date;
      FETCH get_next_date INTO next_dt_from_,next_dt_until_;
         IF (get_next_date%FOUND) THEN
            IF NOT (date_from_ = next_dt_from_ AND date_until_ = next_dt_from_) THEN
               CLOSE get_next_date;
               Error_SYS.Record_General(lu_name_, 'YEARENDPERIOD7: Valid From and Valid Until of Year Opening Period should be equal to the first date of the financial Year :P1.',accounting_year_);
            END IF;
         END IF;
   CLOSE get_next_date;

END Check_Opening_Date__;


@UncheckedAccess
FUNCTION Get_Year_Period__ (
   accounting_year_ IN NUMBER,
   accounting_period_ IN NUMBER ) RETURN VARCHAR2
IS
   year_period_ VARCHAR2(7);
BEGIN
   IF (accounting_period_<10) THEN
      year_period_ := concat(to_char(accounting_year_),concat('-0', to_char(accounting_period_)));
   ELSE
      year_period_ := concat(to_char(accounting_year_),concat('-', to_char(accounting_period_)));
   END IF;
   RETURN year_period_;
END Get_Year_Period__;

-------------------- LU SPECIFIC PROTECTED METHODS --------------------------

@UncheckedAccess
FUNCTION Get_Accounting_Year_ (
   company_ IN VARCHAR2,
   actual_date_ IN DATE ) RETURN NUMBER
IS
   year_             NUMBER;
   period_           NUMBER;
BEGIN
   Get_Period_Info___( year_, period_, company_, actual_date_ );
   RETURN year_;
END Get_Accounting_Year_;


-------------------- LU SPECIFIC PUBLIC METHODS -----------------------------

PROCEDURE Check_Year_End_Period (
   company_           IN VARCHAR2,
   accounting_year_   IN NUMBER,
   accounting_period_ IN NUMBER )
IS

   max_value_       NUMBER;
   dummy_           NUMBER;

CURSOR max_period IS
   SELECT MAX(accounting_period)
   FROM   ACCOUNTING_PERIOD_TAB
   WHERE  company = company_
   AND    accounting_year = accounting_year_;

CURSOR year_end IS
   SELECT 1
   FROM   ACCOUNTING_PERIOD_TAB
   WHERE  company = company_
   AND    accounting_year = accounting_year_
   AND    year_end_period = 'YEARCLOSE'
   AND    accounting_period = max_value_ ;

BEGIN

   OPEN  max_period;
   FETCH  max_period INTO  max_value_ ;
   CLOSE  max_period;

   OPEN year_end;
   FETCH year_end INTO dummy_;
   IF (year_end%NOTFOUND) THEN
      IF (accounting_period_ <= max_value_ ) THEN
         CLOSE year_end;
         Error_SYS.Record_General(lu_name_, 'YEARENDPERIOD2: It is not allowed to Check another Period when the Highest Period has already been Checked for the selected Year :P1',accounting_year_);
      END IF;
   END IF;
   CLOSE year_end;

END Check_Year_End_Period;


PROCEDURE Check_Previous_Year_End_Period (
   company_           IN VARCHAR2,
   accounting_year_   IN NUMBER,
   accounting_period_ IN NUMBER,
   year_end_period_   IN VARCHAR2,
   date_from_         IN DATE,
   date_until_        IN DATE,
   period_status_     IN VARCHAR2,
   period_status_int_ IN VARCHAR2 DEFAULT 'O' )
IS
   dummy1_               NUMBER;
   prev_dt_from_         DATE;
   prev_dt_until_        DATE;
   prev_year_end_period_ VARCHAR2(10);
   next_year_end_period_ VARCHAR2(10);
   prev_period_status_   VARCHAR2(1);
   open_date_            DATE;

   CURSOR check_other IS
      SELECT MAX(accounting_period)
      FROM   ACCOUNTING_PERIOD_TAB
      WHERE  company = company_
      AND    accounting_year = accounting_year_
      AND    year_end_period ='YEARCLOSE';

   CURSOR check_open_year_end IS
      SELECT 1
      FROM   ACCOUNTING_PERIOD_TAB
      WHERE  company = company_
      AND    accounting_year = accounting_year_
      AND    accounting_period <> accounting_period_
      AND    year_end_period ='YEARCLOSE'
      AND    period_status = 'O';

   CURSOR get_prev_period IS
      SELECT date_from,date_until,year_end_period,period_status
      FROM   ACCOUNTING_PERIOD_TAB
      WHERE  company = company_
      AND    accounting_year = accounting_year_
      AND    accounting_period = (accounting_period_ - 1);

   CURSOR get_next_period IS
      SELECT year_end_period
      FROM   ACCOUNTING_PERIOD_TAB
      WHERE  company = company_
      AND    accounting_year = accounting_year_
      AND    accounting_period = (accounting_period_ + 1);

   CURSOR check_open_int_year_end IS
      SELECT 1
      FROM ACCOUNTING_PERIOD_TAB
      WHERE company           = company_
         AND accounting_year   = accounting_year_
         AND accounting_period <> accounting_period_
         AND year_end_period   ='YEARCLOSE'
         AND period_status_int = 'O';
BEGIN

   IF (year_end_period_ = 'YEARCLOSE') THEN
      OPEN get_prev_period;
      FETCH get_prev_period INTO prev_dt_from_,prev_dt_until_,prev_year_end_period_,prev_period_status_;
      IF (get_prev_period%FOUND) THEN
         IF NOT (date_from_ = prev_dt_until_ AND date_until_ = prev_dt_until_) THEN
            CLOSE get_prev_period;
            Error_SYS.Record_General(lu_name_, 'YEARENDPERIOD4: Valid From and Valid Until of Year End Period should be equal to the last date of the financial Year :P1.',accounting_year_);
         END IF;
         IF (prev_year_end_period_ = 'YEARCLOSE') AND (prev_period_status_ ='O') AND (period_status_ = 'O')  THEN
            CLOSE get_prev_period;
            Error_SYS.Record_General(lu_name_, 'YEARENDPERIOD6: More than one Year End Period can not be Open at the same time ');
         END IF;
      END IF;
      CLOSE get_prev_period;

      OPEN get_next_period;
      FETCH get_next_period INTO next_year_end_period_;
      IF (get_next_period%FOUND) THEN
         IF (next_year_end_period_ = 'ORDINARY') THEN
            CLOSE get_next_period;
            Error_SYS.Record_General(lu_name_, 'YEARENDPERIOD3: It is not allowed to have Year end Period, with next period is an Ordinary period ');
         END IF;
      END IF;
      CLOSE get_next_period;

      IF (period_status_ = 'O') THEN
         OPEN check_open_year_end;
         FETCH check_open_year_end INTO dummy1_;
         IF (check_open_year_end%FOUND) THEN
            CLOSE check_open_year_end;
            Error_SYS.Record_General(lu_name_, 'YEARENDPERIOD6: More than one Year End Period can not be Open at the same time ');
         END IF;
         CLOSE check_open_year_end;
      END IF;

      IF (period_status_int_ = 'O') THEN
         OPEN check_open_int_year_end;
         FETCH check_open_int_year_end INTO dummy1_;
         IF (check_open_int_year_end%FOUND) THEN
            CLOSE check_open_int_year_end;
            Error_SYS.Record_General(lu_name_, 'YEARENDPERIOD6: More than one Year End Period can not be Open at the same time ');
         END IF;
         CLOSE check_open_int_year_end;
      END IF;

   END IF;

   OPEN  check_other;
   FETCH check_other INTO dummy1_;
   IF (check_other%NOTFOUND) THEN
      CLOSE check_other;
   ELSE
      IF (accounting_period_ > dummy1_ AND year_end_period_ = 'ORDINARY' ) THEN
         Error_SYS.Record_General(lu_name_, 'YEARENDPERIOD5: It is not allowed to create a new ordinary period with a number higher than previous year end period :P1.',dummy1_);
      END IF;
   CLOSE check_other;
   END IF;
   open_date_ :=  Get_Date_From(company_, accounting_year_, 0);
   IF (open_date_ IS NOT NULL AND open_date_ > date_from_ ) THEN
      Error_SYS.Record_General(lu_name_, 'YEARENDPERIOD8: It is not allowed to create a new ordinary period with a date lesser than year opening period.');
   END IF;
END Check_Previous_Year_End_Period;


@SecurityCheck Company.UserAuthorized(company_)
PROCEDURE Get_Period_Status_Int (
   period_status_int_        OUT VARCHAR2,
   company_           IN     VARCHAR2,
   accounting_year_   IN     NUMBER,
   accounting_period_ IN     NUMBER )
IS
   --
   status_            VARCHAR2(20);
   --
   CURSOR get_period_status IS
      SELECT  period_status_int
      FROM    ACCOUNTING_PERIOD_TAB
      WHERE   company           = company_
      AND     accounting_year   = accounting_year_
      AND     accounting_period = accounting_period_;
BEGIN
   OPEN  get_period_status;
   FETCH get_period_status INTO status_;
   IF (get_period_status%NOTFOUND) THEN
      CLOSE get_period_status;
      status_ := NULL;
   ELSE
      CLOSE get_period_status;
   END IF;
   period_status_int_ :=  status_;
END Get_Period_Status_Int;


@SecurityCheck Company.UserAuthorized(company_)
PROCEDURE Periodexist (
   exists_               OUT VARCHAR2,
   company_           IN     VARCHAR2,
   accounting_year_   IN     NUMBER,
   accounting_period_ IN     NUMBER )
IS
   CURSOR Period_Exist IS
      SELECT  'TRUE'
      FROM    ACCOUNTING_PERIOD_TAB
      WHERE   company         = company_
      AND   accounting_year   = accounting_year_
      AND   accounting_period = accounting_period_;
BEGIN
   exists_ := 'FALSE';
   OPEN  Period_Exist;
   FETCH Period_Exist INTO exists_;
   CLOSE Period_Exist;
EXCEPTION
   WHEN no_data_found THEN
        exists_ := 'FALSE';
END Periodexist;


@SecurityCheck Company.UserAuthorized(company_)
PROCEDURE Check_Period_Dates (
   company_     IN VARCHAR2,
   date_from_   IN DATE )
IS
   max_year_       NUMBER;
   min_year_       NUMBER;
   max_period_     NUMBER;
   min_period_     NUMBER;
   check_date_     DATE;
   min_date_       DATE;
BEGIN
   BEGIN
      SELECT max(accounting_year), min(accounting_year)
         INTO   max_year_, min_year_
         FROM   ACCOUNTING_PERIOD_TAB
         WHERE  Company = company_;
   EXCEPTION WHEN no_data_found THEN
         max_year_ := 0;
   END;
   BEGIN
      SELECT  max(accounting_period)
         INTO    max_period_
         FROM    ACCOUNTING_PERIOD_TAB
         WHERE   accounting_year = max_year_
         AND     Company         = company_;
   END;
   BEGIN
      SELECT  min(accounting_period)
         INTO    min_period_
         FROM    ACCOUNTING_PERIOD_TAB
         WHERE   company         = company_
         AND     accounting_year = min_year_;
   END;
   BEGIN
      SELECT  date_from
         INTO    min_date_
         FROM    ACCOUNTING_PERIOD_TAB
         WHERE   company           = company_
         AND     accounting_year   = min_year_
         AND     accounting_period = min_period_;
   END;
   BEGIN
      IF max_year_ != 0 THEN
         BEGIN
            SELECT  date_until
               INTO    check_date_
               FROM    ACCOUNTING_PERIOD_TAB
               WHERE   company           = company_
               AND     accounting_year   = max_year_
               AND     accounting_period = max_period_;
            IF date_from_ > check_date_ + 1 THEN
               Error_SYS.Record_General(lu_name_, 'NO_INS_PER: The start date must not be more than one day after last stop date');
            END IF;
            IF date_from_ < check_date_ + 1 THEN
               IF date_from_ > min_date_ THEN
                  Error_SYS.Record_General(lu_name_, 'NO_INS_PER2: The start date is within the date range for another accounting period');               
               END IF;
            END IF;
         END;
      END IF;
   END;
END Check_Period_Dates;


PROCEDURE Check_High_Period (
   high_period_        OUT NUMBER,
   company_         IN     VARCHAR2,
   accounting_year_ IN     NUMBER )
IS
BEGIN

   SELECT max(accounting_period)  INTO   high_period_
      FROM   ACCOUNTING_PERIOD_TAB
      WHERE  company         = company_
      AND    accounting_year = accounting_year_;
END Check_High_Period;


PROCEDURE Get_Max_Period_Date (
   max_date_     OUT DATE,
   company_   IN     VARCHAR2 )
IS
   CURSOR max_date_until IS
      SELECT max(date_until)
      FROM   ACCOUNTING_PERIOD_TAB
      WHERE  company = company_;
BEGIN

   OPEN  max_date_until;
   FETCH max_date_until INTO max_date_;
   CLOSE max_date_until;
END Get_Max_Period_Date;


PROCEDURE Check_Close_Period (
   true_false_           OUT VARCHAR2,
   company_           IN     VARCHAR2,
   accounting_year_   IN     NUMBER,
   accounting_period_ IN     NUMBER )
IS
   result_            VARCHAR2(5);
BEGIN

   Voucher_API.Check_If_Postings_In_Voucher(result_,company_,accounting_period_,accounting_year_);
   IF (result_ = 'TRUE') THEN
      Error_SYS.Record_General(lu_name_,'PER_HOLD_WAI: There are transactions in the wait table that belongs to this period :P1', accounting_period_);
   END IF;
END Check_Close_Period;


@UncheckedAccess
@SecurityCheck Company.UserAuthorized(company_)
FUNCTION Get_Period_Description (
   company_           IN VARCHAR2,
   accounting_year_   IN NUMBER,
   accounting_period_ IN NUMBER,
   cal_year_          IN NUMBER DEFAULT NULL,
   cal_month_         IN NUMBER DEFAULT NULL ) RETURN VARCHAR2
IS
   desc_  ACCOUNTING_PERIOD.description%TYPE;
   CURSOR get_desc IS
      SELECT description
      FROM   ACCOUNTING_PERIOD
      WHERE  company           = company_
      AND    accounting_year   = accounting_year_
      AND    accounting_period = accounting_period_;

   CURSOR get_cal IS
      SELECT description
      FROM   ACCOUNTING_PERIOD
      WHERE  company   = company_
      AND    cal_year  = cal_year_
      AND    cal_month = cal_month_;
BEGIN
   IF (cal_year_ IS NULL OR cal_month_ IS NULL) THEN
      OPEN  get_desc;
      FETCH get_desc INTO desc_;
      CLOSE get_desc;
   ELSE
      OPEN  get_cal;
      FETCH get_cal INTO desc_;
      CLOSE get_cal;
   END IF;
   RETURN desc_;
END Get_Period_Description;


@SecurityCheck Company.UserAuthorized(company_)
PROCEDURE Get_Period_Status (
   period_status_        OUT VARCHAR2,
   company_           IN     VARCHAR2,
   accounting_year_   IN     NUMBER,
   accounting_period_ IN     NUMBER )
IS
   --
   status_            VARCHAR2(20);
   --
   CURSOR get_period_status IS
      SELECT  period_status
      FROM    ACCOUNTING_PERIOD_TAB
      WHERE   company           = company_
      AND     accounting_year   = accounting_year_
      AND     accounting_period = accounting_period_;
BEGIN

   OPEN  get_period_status;
   FETCH get_period_status INTO status_;
   IF (get_period_status%NOTFOUND) THEN
      CLOSE get_period_status;
      status_ := NULL;
   ELSE
      CLOSE get_period_status;
   END IF;
   period_status_ :=  status_;
END Get_Period_Status;


@UncheckedAccess
@SecurityCheck Company.UserAuthorized(company_)
FUNCTION Is_Period_Open (
   company_            IN VARCHAR2,
   accounting_year_    IN NUMBER,
   accounting_period_  IN NUMBER ) RETURN VARCHAR2
IS
   --
   status_             VARCHAR2(20);
   --
   CURSOR is_period_open IS
      SELECT  period_status
      FROM    ACCOUNTING_PERIOD_TAB
      WHERE   company           = company_
      AND     accounting_year   = accounting_year_
      AND     accounting_period = accounting_period_;
BEGIN
   OPEN  is_period_open;
   FETCH is_period_open INTO status_;
   IF (is_period_open%NOTFOUND) THEN
      CLOSE is_period_open;
      RETURN 'FALSE';
   ELSE
      CLOSE is_period_open;
      IF (status_ = 'O') THEN
         RETURN 'TRUE';
      ELSE
         RETURN 'FALSE';
      END IF;
   END IF;
END Is_Period_Open;


@UncheckedAccess
@SecurityCheck Company.UserAuthorized(company_)
FUNCTION Is_Il_Period_Open (
   company_            IN VARCHAR2,
   accounting_year_    IN NUMBER,
   accounting_period_  IN NUMBER ) RETURN VARCHAR2
IS
   --
   status_             VARCHAR2(20);
   --
   CURSOR is_period_open IS
      SELECT  period_status_int
      FROM    ACCOUNTING_PERIOD_TAB
      WHERE   company           = company_
      AND     accounting_year   = accounting_year_
      AND     accounting_period = accounting_period_;
BEGIN
   OPEN  is_period_open;
   FETCH is_period_open INTO status_;
   IF (is_period_open%NOTFOUND) THEN
      CLOSE is_period_open;
      RETURN 'FALSE';
   ELSE
      CLOSE is_period_open;
      IF (status_ = 'O') THEN
         RETURN 'TRUE';
      ELSE
         RETURN 'FALSE';
      END IF;
   END IF;
END Is_Il_Period_Open;


@UncheckedAccess
PROCEDURE Get_Accounting_Year (
   accounting_year_       OUT NUMBER,
   accounting_period_     OUT NUMBER,
   company_            IN     VARCHAR2,
   date_in_            IN     DATE )
IS
   --
   year_               NUMBER;
   period_             NUMBER;
   --
BEGIN
   Get_Period_Info___( year_, period_, company_, date_in_ );
   IF ( ( year_ IS NULL ) OR ( period_ IS NULL ) ) THEN
      Error_SYS.Record_General( lu_name_,
                                'NOYEAR1: No Period exists for the date :P1 in company :P2',
                                date_in_,
                                company_ );
   END IF;
   accounting_year_   := year_;
   accounting_period_ := period_;
END Get_Accounting_Year;


PROCEDURE Get_Accounting_Year (
   accounting_year_       OUT NUMBER,
   accounting_period_     OUT NUMBER,
   company_               IN  VARCHAR2,
   date_in_               IN  DATE,
   user_group_            IN  VARCHAR2 )
IS
   year_end_period_     VARCHAR2(10);
   date_param_          DATE;

   CURSOR get_accounting_year IS
      SELECT  accounting_year, accounting_period, year_end_period
        FROM  accounting_period_tab
       WHERE  company          = company_
         AND  date_from       <= date_param_
         AND  date_until      >= date_param_
         and  year_end_period like year_end_period_
         ORDER BY accounting_period ASC;
         
   CURSOR get_yearend_accounting_year IS
      SELECT  accounting_year, accounting_period
        FROM  accounting_period_tab
       WHERE  company          = company_
         AND  date_from       <= date_param_
         AND  date_until      >= date_param_
         AND  year_end_period = 'YEARCLOSE'
         AND  period_status = 'O'
         ORDER BY accounting_period ASC;

BEGIN
   IF (User_Group_Finance_Api.Get_Allowed_Acc_Period(company_,user_group_) = '1') THEN
      year_end_period_ := 'ORDINARY';
   ELSE
      year_end_period_ := 'YEAR%';
   END IF;
   date_param_ := TRUNC( date_in_ );
   OPEN  get_accounting_year;
   FETCH get_accounting_year INTO accounting_year_, accounting_period_, year_end_period_;
   CLOSE get_accounting_year;
   IF year_end_period_ = 'YEARCLOSE' THEN
      OPEN  get_yearend_accounting_year;
      FETCH get_yearend_accounting_year INTO accounting_year_, accounting_period_;
      CLOSE get_yearend_accounting_year;       
   END IF;
   IF (year_end_period_ = 'YEAROPEN') THEN
      Error_SYS.Record_General( lu_name_,
                                'YEAROPEN: Not allow to use year open period.',
                                date_in_,
                                company_ );
   END IF;
   IF ( ( accounting_year_ IS NULL ) OR ( accounting_period_ IS NULL ) ) THEN
      Error_SYS.Record_General( lu_name_,
                                'NOYEAR1: No Period exists for the date :P1 in company :P2',
                                date_in_,
                                company_ );
   END IF;
END Get_Accounting_Year;


@UncheckedAccess
FUNCTION Get_Accounting_Year (
   company_          IN VARCHAR2,
   actual_date_      IN DATE ) RETURN NUMBER
IS
   --
   year_             NUMBER;
   period_           NUMBER; -- dummy
   --
BEGIN
   Get_Period_Info___( year_, period_, company_, actual_date_ );
   RETURN year_;
END Get_Accounting_Year;


@UncheckedAccess
FUNCTION Get_Accounting_Period (
   company_          IN VARCHAR2,
   actual_date_      IN DATE ) RETURN NUMBER
IS
   --
   year_             NUMBER; -- dummy
   period_           NUMBER;
   --
BEGIN
   Get_Period_Info___( year_, period_, company_, actual_date_ );
   RETURN period_;
END Get_Accounting_Period;


@SecurityCheck Company.UserAuthorized(company_)
PROCEDURE Period_Delete_Allowed (
   company_             IN VARCHAR2,
   accounting_year_     IN NUMBER,
   accounting_period_   IN NUMBER )
IS
   --
   dummy_               VARCHAR2(1);
   --
   CURSOR period_after IS
      SELECT  'Y'
      FROM    ACCOUNTING_PERIOD_TAB
      WHERE   company = company_
      AND   ((accounting_year > accounting_year_)
            OR    (accounting_year = accounting_year_ AND accounting_period > accounting_period_));
   CURSOR period_before IS
      SELECT  'Y'
      FROM    ACCOUNTING_PERIOD_TAB
      WHERE   company = company_
      AND   ((accounting_year < accounting_year_)
            OR    (accounting_year = accounting_year_ AND accounting_period < accounting_period_));
BEGIN
   OPEN  period_before;
   FETCH period_before INTO dummy_;
   OPEN  period_after;
   FETCH period_after INTO dummy_;
   IF (period_after%FOUND AND period_before%FOUND) THEN
      Error_SYS.Record_General(lu_name_, 'NO_DEL: It is not allowed to delete a period :P1 in the middle of a date range', accounting_period_);
      CLOSE period_after;
      CLOSE period_before;
   ELSE
      CLOSE period_after;
      CLOSE period_before;
   END IF;
END Period_Delete_Allowed;


@SecurityCheck Company.UserAuthorized(company_)
PROCEDURE Get_Firstdate_Nextaccperiod (
   acc_period_out_     OUT NUMBER,
   acc_year_out_       OUT NUMBER,
   date_first_         OUT DATE,
   company_         IN     VARCHAR2,
   accounting_year_ IN     NUMBER,
   user_group_      IN     VARCHAR2,
   period_start_    IN     NUMBER,
   period_range_    IN     NUMBER )
IS
   --
   ctr_             NUMBER;
   CURSOR acc_period IS
      SELECT  date_from , accounting_year, accounting_period
      FROM    ACCOUNTING_PERIOD_TAB
      WHERE   company = company_
      AND   ( accounting_year * 100 ) + accounting_period  >=
            ( accounting_year_ * 100) + period_start_
      ORDER BY ACCOUNTING_YEAR  , ACCOUNTING_PERIOD ;
   --
BEGIN
   date_first_     := NULL ;
   acc_period_out_ := 0 ;
   acc_year_out_   := 0;
   ctr_            := 0 ;
   FOR  ap_cur IN acc_period  LOOP
      EXIT WHEN ( period_range_ < ctr_ ) ;
      IF (USER_GROUP_PERIOD_API.Is_Period_Open(company_, ap_cur.accounting_year, ap_cur.accounting_period, user_group_)
         = 'TRUE') THEN
         date_first_     := ap_cur.date_from ;
         acc_period_out_ := ap_cur.accounting_period ;
         acc_year_out_   := ap_cur.accounting_year ;
         EXIT WHEN (TRUE);
         -- BREAK --
      END IF;
      ctr_ := ctr_ + 1;
   END LOOP;
END Get_Firstdate_Nextaccperiod;

@SecurityCheck Company.UserAuthorized(company_)
PROCEDURE Get_Firstdate_Nextopenperiod (
   acc_period_out_     OUT NUMBER,
   acc_year_out_       OUT NUMBER,
   date_first_         OUT DATE,
   company_         IN     VARCHAR2,
   accounting_year_ IN     NUMBER,
   user_group_      IN     VARCHAR2,
   period_start_    IN     NUMBER,
   ledger_id_       IN     VARCHAR2)
IS
   CURSOR acc_period IS
      SELECT  date_from , accounting_year, accounting_period
      FROM    ACCOUNTING_PERIOD_TAB
      WHERE   company = company_
      AND   ( accounting_year * 100 ) + accounting_period  >=
            ( accounting_year_ * 100) + period_start_
      ORDER BY ACCOUNTING_YEAR  , ACCOUNTING_PERIOD ;
   --
BEGIN
      date_first_     := NULL ;
      acc_period_out_ := 0 ;
      acc_year_out_   := 0;
      FOR  ap_cur IN acc_period  LOOP
         IF (USER_GROUP_PERIOD_API.Is_Period_Open_GL_IL(company_, ap_cur.accounting_year, ap_cur.accounting_period, user_group_,ledger_id_)
            = 'TRUE') THEN
            date_first_     := ap_cur.date_from ;
            acc_period_out_ := ap_cur.accounting_period ;
            acc_year_out_   := ap_cur.accounting_year ;
            EXIT WHEN (TRUE);
            -- BREAK --
         END IF;
      END LOOP;
END Get_Firstdate_Nextopenperiod;

@SecurityCheck Company.UserAuthorized(company_)
PROCEDURE Check_Accounting_Year (
   company_             IN VARCHAR2,
   accounting_year_     IN NUMBER )
IS
   CURSOR exist_year IS
      SELECT accounting_year
      FROM   ACCOUNTING_PERIOD_TAB
      WHERE  company       = company_
      AND  accounting_year = accounting_year_;
   year_ NUMBER;
BEGIN
   OPEN  exist_year;
   FETCH exist_year INTO year_ ;
   IF (exist_year%NOTFOUND) THEN
      CLOSE exist_year;
      Error_SYS.Record_General(lu_name_, 'NOYEAR2: Accounting Year :P1 does not exist.', accounting_year_);
   ELSE
      CLOSE exist_year;
   END IF;
END Check_Accounting_Year;


PROCEDURE Conv_Period (
   accounting_year_        OUT NUMBER,
   accounting_period_      OUT NUMBER,
   company_             IN     VARCHAR2,
   period_              IN     NUMBER )
IS
   new_period_          NUMBER;
   new_year_            NUMBER;
BEGIN
   new_period_        := substr(period_, 3, 4);
   accounting_period_ := new_period_;
   new_year_          := substr(period_, 1, 2);
   IF (new_year_ > 0) THEN
      accounting_year_ := 19||new_year_;
   ELSE
      accounting_year_ := 20||new_year_;
   END IF;
END Conv_Period;


@SecurityCheck Company.UserAuthorized(company_)
PROCEDURE Get_Min_Max_Period (
   min_period_         OUT NUMBER,
   max_period_         OUT NUMBER,
   company_         IN     VARCHAR2,
   accounting_year_ IN     NUMBER )
IS
   CURSOR get_max_period IS
      SELECT max(accounting_period)
      FROM   ACCOUNTING_PERIOD_TAB
      WHERE  company       = company_
      AND  accounting_year = accounting_year_;
   CURSOR get_min_period IS
      SELECT min(accounting_period)
      FROM   ACCOUNTING_PERIOD_TAB
      WHERE  company       = company_
      AND  accounting_year = accounting_year_;
BEGIN
   OPEN  get_max_period;
   FETCH get_max_period INTO max_period_ ;
   CLOSE get_max_period;
   OPEN  get_min_period;
   FETCH get_min_period INTO min_period_ ;
   CLOSE get_min_period;
END Get_Min_Max_Period;


@SecurityCheck Company.UserAuthorized(company_)
@UncheckedAccess
PROCEDURE Get_Period_Date (
   date_from_            OUT DATE,
   date_until_           OUT DATE,
   company_           IN     VARCHAR2,
   accounting_year_   IN     NUMBER,
   accounting_period_ IN     NUMBER )
IS
   CURSOR get_date IS
      SELECT date_from, date_until
      FROM   ACCOUNTING_PERIOD_TAB
      WHERE  company           = company_
      AND    accounting_year   = accounting_year_
      AND    accounting_period = accounting_period_;
BEGIN
   OPEN  get_date;
   FETCH get_date INTO date_from_, date_until_;
   CLOSE get_date;
END Get_Period_Date;


@SecurityCheck Company.UserAuthorized(company_)
PROCEDURE Get_All_Periods (
   period_tab_         OUT PeriodTab,
   num_of_period_      OUT NUMBER,
   company_         IN     VARCHAR2,
   accounting_year_ IN     NUMBER )
IS
   CURSOR Get_period IS
      SELECT accounting_period
      FROM   ACCOUNTING_PERIOD_TAB
      WHERE  company         = company_
      AND    accounting_year = accounting_year_;
   row_      NUMBER := 1;
BEGIN
   OPEN get_period;
   LOOP
      FETCH get_period INTO period_tab_(row_);
      EXIT WHEN get_period%NOTFOUND;
      row_ := row_ + 1;
   END LOOP;
   CLOSE get_period;
   num_of_period_ := row_ - 1;
END Get_All_Periods;


PROCEDURE Check_Period_Closed (
   all_period_status_     OUT VARCHAR2,
   closed_exist_          OUT VARCHAR2,
   finally_closed_exist_  OUT VARCHAR2,
   company_               IN  VARCHAR2,
   accounting_year_       IN  NUMBER,
   closing_balances_db_   IN  VARCHAR2)
IS
   period_tab_         Accounting_Period_API.PeriodTab;
   num_of_period_      NUMBER;
   period_status_      VARCHAR2(1);
BEGIN
   all_period_status_ := 'TRUE';
   closed_exist_         := 'FALSE';
   finally_closed_exist_ := 'FALSE';
   Accounting_Period_API.Get_All_Periods(period_tab_, num_of_period_, company_, accounting_year_);
   FOR i IN 1..num_of_period_   LOOP
      Accounting_Period_API.Get_Period_Status(period_status_, company_, accounting_year_, period_tab_(i));
      IF (period_status_ = 'O') THEN
         all_period_status_ := 'FALSE';
      ELSIF (period_status_ = 'C') THEN
         closed_exist_ := 'TRUE';
      ELSIF (period_status_ = 'F') THEN
         finally_closed_exist_ := 'TRUE';
      END IF;
   END LOOP;
   IF (closing_balances_db_ = 'FV') THEN
      Get_Period_Status( period_status_,company_, accounting_year_ + 1,0);
      IF (period_status_ = 'C') OR (period_status_ = 'F') THEN
         all_period_status_ := 'FALSE';
      END IF;
   END IF;
END Check_Period_Closed;


@SecurityCheck Company.UserAuthorized(company_)
PROCEDURE Get_Consolidation_Info (
   period_exists_           IN OUT VARCHAR2,
   period_closed_           IN OUT VARCHAR2,
   period_consolidated_     IN OUT VARCHAR2,
   company_                 IN     VARCHAR2,
   accounting_year_         IN     NUMBER,
   accounting_period_       IN     NUMBER )
IS
   CURSOR period_info IS
      SELECT consolidated             db_consolidated,
             period_status            db_period_status
      FROM   ACCOUNTING_PERIOD_TAB
      WHERE  company           = company_
      AND    accounting_year   = accounting_year_
      AND    accounting_period = accounting_period_;

   row_                          period_info%ROWTYPE;
   open_balance_db_              VARCHAR2(2);

BEGIN
   OPEN  period_info;
   FETCH period_info INTO row_;
   IF (period_info%NOTFOUND)  AND (accounting_period_ != '0') THEN
      period_exists_ := 'FALSE';
   ELSE
      period_exists_ := 'TRUE';
      -- check, if period is closed ....
      --IF (row_.db_period_status != 'C') THEN
      IF (row_.db_period_status = 'O') THEN
         period_closed_ := 'FALSE';
      ELSE
         period_closed_ := 'TRUE';
      END IF;
      -- check, if period is not consolidated ....
      IF (row_.db_consolidated = 'Y') THEN
         period_consolidated_ := 'TRUE';
      ELSE
         period_consolidated_ := 'FALSE';
      END IF;
   END IF;
   CLOSE period_info;

   IF (accounting_period_ = '0') THEN
      open_balance_db_ := Accounting_Year_API.Get_Opening_Balanecs_Db(company_,accounting_year_);
      IF (open_balance_db_ = 'N') THEN
         Error_SYS.Record_General(lu_name_,'NOOPENBAL: No Opening Balances exist for the year :P1',accounting_year_);
      END IF;
   END IF;
END Get_Consolidation_Info;


PROCEDURE Set_Consolidated_Flag (
   company_                IN VARCHAR2,
   accounting_year_        IN NUMBER,
   accounting_period_      IN NUMBER )
IS
BEGIN
   UPDATE accounting_period_tab
      SET consolidated = 'Y'
   WHERE Company     = company_
   AND   Accounting_Year = accounting_year_
   AND   Accounting_Period = accounting_period_ ;
END Set_Consolidated_Flag;


PROCEDURE Clear_Consolidated_Flag (
   company_               IN VARCHAR2,
   accounting_year_       IN NUMBER,
   accounting_period_     IN NUMBER )
IS
BEGIN
   UPDATE accounting_period_tab
      SET consolidated = 'N'
   WHERE Company     = company_
   AND   Accounting_Year = accounting_year_
   AND   Accounting_Period = accounting_period_ ;
END Clear_Consolidated_Flag;


@UncheckedAccess
@SecurityCheck Company.UserAuthorized(company_)
FUNCTION Period_Valid_For_Cons (
   company_            IN VARCHAR2,
   accounting_year_    IN NUMBER,
   accounting_period_  IN NUMBER ) RETURN BOOLEAN
IS
   row_                ACCOUNTING_PERIOD_TAB%ROWTYPE;
BEGIN
   row_ := Get_Object_By_Keys___( company_, accounting_year_, accounting_period_ );
   --IF (row_.period_status != 'C') THEN
   IF (row_.period_status = 'O') THEN
      RETURN FALSE;
   END IF;
   IF (row_.consolidated != 'N') THEN
      RETURN FALSE;
   END IF;
   RETURN TRUE;
END Period_Valid_For_Cons;


@SecurityCheck Company.UserAuthorized(company_)
PROCEDURE Get_Next_Period (
   next_alloc_period_     OUT NUMBER,
   next_alloc_year_       OUT NUMBER,
   company_            IN     VARCHAR2,
   current_period_     IN     NUMBER,
   current_year_       IN     NUMBER )
IS
   CURSOR next_acc_period IS
      SELECT  accounting_year, accounting_period
      FROM    ACCOUNTING_PERIOD_TAB
      WHERE   company = company_
      AND   (accounting_year * 100) + accounting_period  >
            (current_year_ * 100) + current_period_
      AND period_status = 'O'
      ORDER BY ACCOUNTING_YEAR, ACCOUNTING_PERIOD ;
BEGIN
   OPEN  next_acc_period;
   FETCH next_acc_period INTO next_alloc_year_ , next_alloc_period_  ;
   CLOSE next_acc_period;
END Get_Next_Period;


@UncheckedAccess
@SecurityCheck Company.UserAuthorized(company_)
FUNCTION Get_Max_Period (
   company_          IN VARCHAR2,
   accounting_year_  IN NUMBER ) RETURN NUMBER
IS
   CURSOR getmaxperiod IS
      SELECT max(accounting_period)
      FROM   ACCOUNTING_PERIOD_TAB
      WHERE  company       = company_
      AND  accounting_year = accounting_year_;
   max_period_               NUMBER := 12;
BEGIN
   OPEN   getmaxperiod;
   FETCH  getmaxperiod INTO max_period_ ;
   CLOSE  getmaxperiod;
   RETURN max_period_;
END Get_Max_Period;


@UncheckedAccess
@SecurityCheck Company.UserAuthorized(company_)
FUNCTION Get_Min_Period (
   company_          IN VARCHAR2,
   accounting_year_  IN NUMBER ) RETURN NUMBER
IS
   CURSOR getminperiod IS
      SELECT min(accounting_period)
      FROM   ACCOUNTING_PERIOD_TAB
      WHERE  company       = company_
      AND  accounting_year = accounting_year_;
   min_period_               NUMBER := 1;
BEGIN
   OPEN   getminperiod;
   FETCH  getminperiod INTO min_period_ ;
   CLOSE  getminperiod;
   RETURN min_period_;
END Get_Min_Period;


@SecurityCheck Company.UserAuthorized(company_)
FUNCTION Get_Datefrom_For_Thirdbudamt (
   company_           IN VARCHAR2,
   accounting_year_   IN NUMBER ) RETURN DATE
IS
   date_from_         DATE;
   CURSOR cur_datefrom_ IS
      SELECT date_from
      FROM   ACCOUNTING_PERIOD_TAB
      WHERE  company           = company_
      AND    accounting_year   = accounting_year_
      AND    accounting_period = (SELECT MIN(accounting_period)
                                  FROM   ACCOUNTING_PERIOD_TAB
                                  WHERE  company         = company_
                                  AND    accounting_year = accounting_year_ );
BEGIN
   OPEN   cur_datefrom_;
   FETCH  cur_datefrom_ INTO date_from_ ;
   CLOSE  cur_datefrom_;
   RETURN date_from_;
END Get_Datefrom_For_Thirdbudamt;


@SecurityCheck Company.UserAuthorized(company_)
PROCEDURE Year_Exist (
   exist_year_ IN OUT VARCHAR2,
   company_ IN VARCHAR2,
   accounting_year_ IN NUMBER )
IS
   CURSOR check_year IS
      SELECT accounting_year
      FROM   ACCOUNTING_PERIOD_TAB
      WHERE  company       = company_
      AND  accounting_year = accounting_year_;
   year_ NUMBER;
BEGIN
   OPEN  check_year ;
   FETCH check_year INTO year_ ;
   IF (check_year%NOTFOUND) THEN
      CLOSE check_year ;
      exist_year_ := 'FALSE';
   ELSE
      CLOSE check_year ;
      exist_year_ := 'TRUE';
   END IF;
END Year_Exist;


PROCEDURE Check_Period_Status (
   all_period_status_ OUT VARCHAR2,
   company_ IN VARCHAR2,
   accounting_year_ IN NUMBER,
   accounting_period_ IN NUMBER )
IS
   CURSOR get_accperiod IS
      SELECT accounting_year, accounting_period
      FROM ACCOUNTING_PERIOD_TAB
      WHERE company              = company_
      AND   accounting_year     <= accounting_year_
      AND   accounting_period   <= accounting_period_;

   period_status_      ACCOUNTING_PERIOD_TAB.period_status%TYPE;

BEGIN

   FOR accperiod_ IN get_accperiod LOOP
      EXIT WHEN (get_accperiod%NOTFOUND) OR (all_period_status_ = 'FALSE');
      Get_Period_Status(period_status_, company_, accperiod_.accounting_year, accperiod_.accounting_period);
      IF period_status_ = 'O' THEN
         all_period_status_ := 'FALSE';
      END IF;
   END LOOP;
END Check_Period_Status;


@SecurityCheck Company.UserAuthorized(company_)
PROCEDURE Get_Previous_Period (
   previous_period_    OUT NUMBER,
   previous_year_      OUT NUMBER,
   company_         IN VARCHAR2,
   current_period_  IN NUMBER,
   current_year_    IN NUMBER )
IS
   CURSOR previous_acc_period IS
      SELECT  accounting_year, accounting_period
      FROM    ACCOUNTING_PERIOD_TAB
      WHERE   company = company_
      AND   (accounting_year * 100) + accounting_period  <
            (current_year_ * 100 ) + current_period_
      AND period_status = 'O'
      ORDER BY (ACCOUNTING_YEAR) DESC, (ACCOUNTING_PERIOD) DESC ;
BEGIN
   OPEN  previous_acc_period;
      FETCH previous_acc_period INTO previous_year_ , previous_period_ ;
      CLOSE previous_acc_period;
END Get_Previous_Period;


PROCEDURE Get_Year_End_Period (
   accounting_period_ OUT NUMBER,
   period_des_        OUT VARCHAR2,
   valid_until_       OUT DATE,
   company_           IN VARCHAR2,
   accounting_year_   IN NUMBER,
   period_status_     IN VARCHAR2 DEFAULT 'O' )
IS
   -- Bug Id 111219 Removed the OR AND period_status_db = period_status_db)); 
   CURSOR year_end_period IS
      SELECT MAX(accounting_period)
      FROM ACCOUNTING_PERIOD
      WHERE company = company_
      AND   accounting_year = accounting_year_
      AND   year_end_period_db = 'YEARCLOSE'
      AND   (period_status_db = period_status_ OR (period_status_ = 'C' AND period_status_db IN ('C','F'))
      OR    (period_status_ = 'NONE'));

   CURSOR year_end_period_data IS
      SELECT description,date_until
      FROM ACCOUNTING_PERIOD
      WHERE  company = company_
      AND accounting_year = accounting_year_
      AND accounting_period = accounting_period_  ;

BEGIN

   OPEN year_end_period;
   FETCH year_end_period INTO accounting_period_;
   CLOSE year_end_period;

   OPEN  year_end_period_data;
   FETCH year_end_period_data INTO  period_des_,valid_until_;
   CLOSE  year_end_period_data;

END Get_Year_End_Period;


@UncheckedAccess
FUNCTION Is_Year_End_Period (
   company_           IN VARCHAR2,
   accounting_year_   IN NUMBER,
   accounting_period_ IN NUMBER ) RETURN BOOLEAN
IS
  CURSOR year_end_period_data IS
    SELECT 1
    FROM ACCOUNTING_PERIOD_TAB
    WHERE company = company_
    AND   accounting_year = accounting_year_
    AND   accounting_period = accounting_period_
    AND   year_end_period IN ('YEAROPEN','YEARCLOSE');

   dummy_                NUMBER;
BEGIN
   OPEN year_end_period_data;
   FETCH year_end_period_data INTO dummy_;
   IF (year_end_period_data%FOUND) THEN
      CLOSE year_end_period_data;
      RETURN TRUE;
   END IF;
   CLOSE year_end_period_data;
   RETURN FALSE;
END Is_Year_End_Period;


@SecurityCheck Company.UserAuthorized(company_)   
PROCEDURE Get_Periods_Sans_Year_End (
   periodtab_          OUT PeriodTab,
   num_of_periods_     OUT NUMBER,
   company_         IN     VARCHAR2,
   accounting_year_ IN     NUMBER )
IS
   CURSOR Get_Period IS
      SELECT accounting_period
      FROM   ACCOUNTING_PERIOD_TAB
      WHERE  company         = company_
      AND    accounting_year = accounting_year_
      AND   year_end_period = 'ORDINARY';
   row_      NUMBER := 1;
BEGIN
   OPEN Get_Period;
   LOOP
      FETCH Get_Period INTO periodtab_(row_);
      EXIT WHEN Get_Period%NOTFOUND;
      row_ := row_ + 1;
   END LOOP;
   CLOSE Get_Period;
   num_of_periods_ := row_ - 1;
END Get_Periods_Sans_Year_End;


@SecurityCheck Company.UserAuthorized(company_)   
PROCEDURE Get_All_Ordinary_Periods (
   period_tab_         OUT PeriodTab,
   num_of_period_ OUT NUMBER,
   company_ IN VARCHAR2,
   accounting_year_ IN NUMBER )
IS
   CURSOR Get_period IS
      SELECT accounting_period
      FROM   ACCOUNTING_PERIOD_TAB
      WHERE  company         = company_
      AND    accounting_year = accounting_year_
      AND    year_end_period = 'ORDINARY';
   row_      NUMBER := 1;
BEGIN
   OPEN get_period;
   LOOP
      FETCH get_period INTO period_tab_(row_);
      EXIT WHEN get_period%NOTFOUND;
      row_ := row_ + 1;
   END LOOP;
   CLOSE get_period;
   num_of_period_ := row_ - 1;
END Get_All_Ordinary_Periods;


@UncheckedAccess
FUNCTION Get_Voucher_Period (
   company_         IN VARCHAR2,
   accounting_year_ IN NUMBER,
   voucher_no_      IN NUMBER,
   voucher_type_    IN VARCHAR2 ) RETURN NUMBER
IS
   accounting_period_temp_ ACCOUNTING_PERIOD_TAB.accounting_period%TYPE;
   accounting_period_ ACCOUNTING_PERIOD_TAB.accounting_period%TYPE;
   CURSOR get_vou_accrul_ IS
      SELECT accounting_period
        FROM voucher_tab
       WHERE company = company_
         AND accounting_year = accounting_year_
         AND voucher_no =  voucher_no_
         AND voucher_type = voucher_type_ ;
   
   $IF Component_Genled_SYS.INSTALLED $THEN
      CURSOR get_vou_genled IS
         SELECT accounting_period 
         FROM gen_led_voucher_tab
         WHERE company         = company_ 
         AND   accounting_year = accounting_year_
         AND   voucher_no      = voucher_no_ 
         AND   voucher_type    = voucher_type_;

   -- Bug 130949, Begin
      CURSOR get_vou_genled_archived IS
         SELECT accounting_period 
         FROM gen_led_arch_voucher_tab
         WHERE company         = company_ 
         AND   accounting_year = accounting_year_
         AND   voucher_no      = voucher_no_ 
         AND   voucher_type    = voucher_type_;
   -- Bug 130949, End
   $END
BEGIN
   -- Since voucher can be updated to GENLED
   -- First do accrul
   -- Then GENLED - since ACCRUL/Application can be installed/exist
   -- without GENLED , do dynamic calling
   OPEN get_vou_accrul_;
   FETCH get_vou_accrul_ INTO accounting_period_temp_;
   IF ( get_vou_accrul_%FOUND ) THEN
      -- IF exist return the value
      accounting_period_ := accounting_period_temp_;
   ELSE
      -- Then check for GENLED
      $IF Component_Genled_SYS.INSTALLED $THEN
         OPEN get_vou_genled;
         FETCH get_vou_genled INTO accounting_period_temp_;
         IF (get_vou_genled%FOUND) THEN
            -- IF exist return the value
            accounting_period_ := accounting_period_temp_ ;
         ELSE
            -- Bug 130949, Begin
            OPEN get_vou_genled_archived;
            FETCH get_vou_genled_archived INTO accounting_period_temp_;
            IF (get_vou_genled_archived%FOUND) THEN
               -- IF exist return the value
               accounting_period_ := accounting_period_temp_ ;
            ELSE
               accounting_period_:= NULL;
            END IF;
            CLOSE get_vou_genled_archived;
            -- Bug 130949, End
         END IF;
         CLOSE get_vou_genled;
      $ELSE
         NULL;
      $END
   END IF;
   CLOSE get_vou_accrul_;
   RETURN accounting_period_;
END Get_Voucher_Period;


@UncheckedAccess
PROCEDURE Get_Ordinary_Accounting_Year (
   accounting_year_   OUT NUMBER,
   accounting_period_ OUT NUMBER,
   company_           IN  VARCHAR2,
   date_in_           IN  DATE )
IS
   date_param_     DATE;
   CURSOR get_year IS
      SELECT  accounting_year, accounting_period
      FROM  ACCOUNTING_PERIOD_TAB
      WHERE  company    = company_
      AND  date_from  <= date_param_
      AND  date_until >= date_param_
      AND  year_end_period = 'ORDINARY'
      ORDER BY accounting_period ASC;
BEGIN
   date_param_ := TRUNC( date_in_ );
   OPEN get_year;
   FETCH get_year INTO accounting_year_, accounting_period_;
   CLOSE get_year;
END Get_Ordinary_Accounting_Year;


@UncheckedAccess
FUNCTION Get_Ordinary_Accounting_year (
   company_        IN  VARCHAR2,
   date_in_        IN  DATE ) RETURN NUMBER
IS
   accounting_year_     NUMBER;
   accounting_period_   NUMBER;
BEGIN
   Get_Ordinary_Accounting_Year(accounting_year_, accounting_period_, company_, date_in_);
   RETURN accounting_year_;
END Get_Ordinary_Accounting_year;


PROCEDURE Get_Opening_Period (
   period_desc_           OUT VARCHAR2,
   valid_until_           OUT DATE,
   accounting_period_     OUT NUMBER,
   company_               IN  VARCHAR2,
   accounting_year_       IN  NUMBER,
   exclude_period_status_ IN  VARCHAR2 DEFAULT NULL )
IS
BEGIN
   Get_Opening_Period__( period_desc_,
                         valid_until_,
                         accounting_period_,
                         company_,
                         accounting_year_,
                         exclude_period_status_);
END Get_Opening_Period;

@UncheckedAccess
FUNCTION Get_Accounting_Period_Ext (
   company_      IN VARCHAR2,
   user_group_   IN VARCHAR2,
   voucher_date_ IN DATE ) RETURN NUMBER
IS
   vou_year_        NUMBER;
   period_          NUMBER;
   vou_period_      NUMBER;
   date_until_      DATE;
   date_from_       DATE;
   
   CURSOR year_end_period_data IS
      SELECT accounting_period,date_until
      FROM   ACCOUNTING_PERIOD_TAB
      WHERE  company = company_
      AND    accounting_year = vou_year_
      AND    year_end_period = 'YEARCLOSE'
      AND    period_status = 'O';

   CURSOR get_ordinary_year IS
      SELECT accounting_year, accounting_period
      FROM   ACCOUNTING_PERIOD_TAB
      WHERE  company         = company_
      AND    date_from       <= TRUNC(voucher_date_)
      AND    date_until      >= TRUNC(voucher_date_)
      AND    year_end_period = 'ORDINARY'
      ORDER BY accounting_period ASC;       
      
    CURSOR opening_period_data IS
      SELECT accounting_period, date_until
      FROM   ACCOUNTING_PERIOD_TAB
      WHERE  company         = company_
      AND    accounting_year = vou_year_
      AND    year_end_period = 'YEAROPEN'
      AND    period_status   = 'O';  
BEGIN
   vou_period_ := NULL;
   
   OPEN get_ordinary_year;
   FETCH get_ordinary_year INTO vou_year_, vou_period_;
   CLOSE get_ordinary_year;

   IF (User_Group_Finance_Api.Get_Allowed_Acc_Period(company_,user_group_) = '2') THEN
      OPEN year_end_period_data;
      FETCH year_end_period_data INTO period_,date_until_;
      CLOSE year_end_period_data;
      date_from_ := Get_Date_From(company_ ,vou_year_, period_);
      -- if the date_until_ and date_from_ equals to voucher_date then YE period.
      IF ((voucher_date_ = date_until_) AND (voucher_date_ = date_from_) ) THEN
         RETURN period_;
      ELSE
         
         OPEN opening_period_data;
         FETCH opening_period_data INTO period_,date_until_;
         CLOSE opening_period_data;
         
         date_from_ := Get_Date_From(company_ ,vou_year_, period_);
         -- if the date_until_ and date_from_ equals to voucher_date then Year opening period.
         IF ((voucher_date_ = date_until_) AND (voucher_date_ = date_from_) ) THEN
            RETURN period_;
         ELSE
            RETURN vou_period_;
         END IF;
      END IF;
   ELSE
      RETURN vou_period_;
   END IF;
END Get_Accounting_Period_Ext;


PROCEDURE Get_Accounting_Year_Period_Ext (
   accounting_year_   OUT NUMBER,
   accounting_period_ OUT NUMBER,
   company_           IN  VARCHAR2,
   user_group_        IN  VARCHAR2,
   voucher_date_      IN  DATE )
IS
   vou_year_        NUMBER;
   period_          NUMBER;
   vou_period_      NUMBER;
   description_     VARCHAR2(100);
   date_until_      DATE;
   date_from_       DATE;
BEGIN
   vou_period_ := NULL;
   Get_Ordinary_Accounting_Year(vou_year_,vou_period_,company_ ,voucher_date_);
   IF (User_Group_Finance_Api.Get_Allowed_Acc_Period(company_,user_group_) = '2') THEN
      Get_Year_End_Period(period_, description_, date_until_, company_, vou_year_);
      date_from_ := Get_Date_From(company_ ,vou_year_, period_);
      -- if the date_until_ and date_from_ equals to voucher_date then YE period.
      IF ((voucher_date_ = date_until_) AND (voucher_date_ = date_from_) ) THEN
         accounting_period_ := period_;
      ELSE
         Get_Opening_Period(description_,date_until_,period_,company_,vou_year_);
         date_from_ := Get_Date_From(company_ ,vou_year_, period_);
         -- if the date_until_ and date_from_ equals to voucher_date then Year opening period.
         IF ((voucher_date_ = date_until_) AND (voucher_date_ = date_from_) ) THEN
            accounting_period_ := period_;
         ELSE
            accounting_period_ := vou_period_;
         END IF;
      END IF;
   ELSE
      accounting_period_ := vou_period_;
   END IF;
   IF ( ( vou_year_ IS NULL ) OR ( accounting_period_ IS NULL ) ) THEN
      Error_SYS.Record_General( lu_name_,
                                'NOYEAR1: No Period exists for the date :P1 in company :P2',
                                voucher_date_,
                                company_ );
   END IF;
   accounting_year_   := vou_year_;
END Get_Accounting_Year_Period_Ext;


@SecurityCheck Company.UserAuthorized(company_)   
PROCEDURE Get_Next_Allowed_Period (
   next_allow_period_ OUT NUMBER,
   next_allow_year_   OUT NUMBER,
   company_           IN  VARCHAR2,
   current_period_    IN  NUMBER,
   current_year_      IN  NUMBER )
IS
   CURSOR next_acc_period IS
      SELECT  accounting_year, accounting_period
      FROM    ACCOUNTING_PERIOD_TAB
      WHERE   company = company_
      AND     (accounting_year * 100) + accounting_period  >
              (current_year_ * 100) + current_period_
      AND     year_end_period = 'ORDINARY'
      ORDER BY ACCOUNTING_YEAR, ACCOUNTING_PERIOD ;
BEGIN
   OPEN  next_acc_period;
   FETCH next_acc_period INTO next_allow_year_ , next_allow_period_  ;
   CLOSE next_acc_period;
END Get_Next_Allowed_Period;


@UncheckedAccess
@SecurityCheck Company.UserAuthorized(company_)
PROCEDURE Get_Previous_Allowed_Period (
   prev_allowed_period_ OUT NUMBER,
   prev_allowed_year_   OUT NUMBER,
   company_             IN VARCHAR2,
   current_period_      IN NUMBER,
   current_year_        IN NUMBER )
IS
   CURSOR prev_acc_period IS
      SELECT  accounting_year, accounting_period
      FROM    ACCOUNTING_PERIOD_TAB
      WHERE   company = company_
      AND     (accounting_year * 100) + accounting_period  <
              (current_year_ * 100) + current_period_
      AND     period_status = 'O'
      AND     year_end_period = 'ORDINARY'
      ORDER BY ACCOUNTING_YEAR DESC, ACCOUNTING_PERIOD DESC ;
BEGIN
   OPEN  prev_acc_period;
   FETCH prev_acc_period INTO prev_allowed_year_ , prev_allowed_period_  ;
   CLOSE prev_acc_period;
END Get_Previous_Allowed_Period;


@UncheckedAccess
@SecurityCheck Company.UserAuthorized(company_)
FUNCTION Is_Period_Allowed (
   company_ IN VARCHAR2,
   period_  IN NUMBER,
   year_    IN NUMBER ) RETURN VARCHAR2
IS
   CURSOR allowed_period IS
      SELECT  '1'
      FROM    ACCOUNTING_PERIOD_TAB
      WHERE   company            = company_
      AND     accounting_year    = year_
      AND     accounting_period  = period_
      AND     period_status = 'O'
      AND     year_end_period = 'ORDINARY';

   is_allowed_       VARCHAR2(5);

BEGIN
   OPEN  allowed_period;
   FETCH allowed_period INTO is_allowed_;
   CLOSE allowed_period;

   IF( is_allowed_ = '1' ) THEN
      is_allowed_ := 'TRUE';
   ELSE
      is_allowed_ := 'FALSE';
   END IF;
   RETURN is_allowed_;
END Is_Period_Allowed;


@UncheckedAccess
FUNCTION Is_Year_Close (
   company_           IN VARCHAR2,
   accounting_year_   IN NUMBER,
   accounting_period_ IN NUMBER ) RETURN VARCHAR2
IS
   CURSOR year_end_period_data IS
    SELECT 1
    FROM ACCOUNTING_PERIOD_TAB
    WHERE company           = company_
    AND   accounting_year   = accounting_year_
    AND   accounting_period = accounting_period_
    AND   year_end_period   = 'YEARCLOSE';

   dummy_                NUMBER;
BEGIN
   OPEN  year_end_period_data;
   FETCH year_end_period_data INTO dummy_;
   IF (year_end_period_data%FOUND) THEN
      CLOSE year_end_period_data;
      RETURN 'TRUE';
   END IF;
   CLOSE year_end_period_data;
   RETURN 'FALSE';
END Is_Year_Close;


@SecurityCheck Company.UserAuthorized(company_)   
PROCEDURE Get_Next_Vou_Period (
   next_period_    IN OUT NUMBER,
   next_year_      IN OUT NUMBER,
   company_        IN VARCHAR2,
   current_period_ IN NUMBER,
   current_year_   IN NUMBER )
IS
   CURSOR next_acc_period IS
      SELECT  accounting_year, accounting_period
      FROM    ACCOUNTING_PERIOD_TAB
      WHERE   company = company_
      AND   (accounting_year * 100) + accounting_period  >
            (current_year_ * 100) + current_period_
      AND year_end_period != 'YEAROPEN'
      ORDER BY ACCOUNTING_YEAR, ACCOUNTING_PERIOD ;

   CURSOR max_ordinary_period IS
      SELECT MAX(accounting_period)
      FROM   Accounting_Period_Tab
      WHERE  company         = company_
      AND    accounting_year = current_year_
      AND    year_end_period = 'ORDINARY';
   CURSOR cnt_yc_open IS
      SELECT 1
      FROM   Accounting_Period_Tab
      WHERE  company         = company_
      AND    accounting_year = current_year_
      AND    year_end_period = 'YEARCLOSE';
      

   max_period_           NUMBER;
   max_ordinary_period_  NUMBER;
   cnt_year_close_open_  NUMBER;

BEGIN
   max_period_ := Get_Max_Period(company_,current_year_);

   OPEN  max_ordinary_period;
   FETCH max_ordinary_period INTO max_ordinary_period_;
   CLOSE max_ordinary_period;

   IF( max_ordinary_period_ = current_period_) THEN
      IF( max_period_ = current_period_) THEN
         next_year_   := NULL;
         next_period_ := NULL;
      ELSE
         OPEN  cnt_yc_open;
         FETCH cnt_yc_open INTO cnt_year_close_open_;
         IF (cnt_yc_open%NOTFOUND) THEN
            CLOSE cnt_yc_open;
            next_year_   := NULL;
            next_period_ := NULL;
         ELSE
           CLOSE cnt_yc_open;
           OPEN  next_acc_period;
           FETCH next_acc_period INTO next_year_ , next_period_  ;
           CLOSE next_acc_period;
         END IF;
      END IF;

   ELSE          
      OPEN  next_acc_period;
      FETCH next_acc_period INTO next_year_ , next_period_  ;
      CLOSE next_acc_period;
   END IF;
END Get_Next_Vou_Period;


@Override
@UncheckedAccess
@SecurityCheck Company.UserAuthorized(company_)
FUNCTION Get (
   company_ IN VARCHAR2,
   accounting_year_ IN NUMBER,
   accounting_period_ IN NUMBER ) RETURN Public_Rec
IS
BEGIN
   RETURN super(company_, accounting_year_, accounting_period_);
END Get;


PROCEDURE Get_Yearper_For_Yearend_User (
   year_           OUT NUMBER,
   period_         OUT NUMBER,
   company_         IN VARCHAR2,
   user_group_      IN VARCHAR2,
   voucher_date_    IN DATE )
IS
   vou_year_        NUMBER;
   vou_period_      NUMBER;
   description_     VARCHAR2(100);
   date_until_      DATE;
BEGIN
   -- Bug 111218, Begin 
   -- Bug 111218, End 
   IF (User_Group_Finance_Api.Get_Allowed_Acc_Period(company_,user_group_) = '2') THEN
      Get_Period_Info___(vou_year_,vou_period_, company_, voucher_date_ );
      Get_Year_End_Period(period_, description_, date_until_, company_, vou_year_);
      IF period_ IS NOT NULL THEN
         year_ := vou_year_;
      END IF;
      IF (date_until_ != voucher_date_) OR (date_until_ IS NULL) THEN
         Error_SYS.Record_General(lu_name_, 'USERGRPDATEERROR: User Group :P1 is not valid for Voucher Date :P2', user_group_, voucher_date_ );
      END IF;
   ELSE
      year_ := 0;
      period_ := 0;
   END IF;
END Get_Yearper_For_Yearend_User;


PROCEDURE Get_Acc_Year_Period_User_Group (
   year_           OUT NUMBER,
   period_         OUT NUMBER,
   company_         IN VARCHAR2,
   user_group_      IN VARCHAR2,
   voucher_date_    IN DATE,
   check_period_status_ IN VARCHAR2 DEFAULT 'TRUE'  )
IS
   vou_year_        NUMBER;
   vou_period_      NUMBER;
   description_     VARCHAR2(100);
   date_until_      DATE;
   status_          VARCHAR2(5):= NULL;
BEGIN
   Get_Period_Info___(vou_year_,vou_period_, company_, voucher_date_ );
   IF (User_Group_Finance_Api.Get_Allowed_Acc_Period(company_,user_group_) = '2') THEN
      
      IF (check_period_status_ = 'FALSE') THEN
         status_ := 'NONE';
      END IF;
      Get_Year_End_Period(period_, description_, date_until_, company_, vou_year_, status_);

      IF period_ IS NOT NULL THEN
         year_ := vou_year_;
      ELSE
         Error_SYS.Record_General(lu_name_,
                                'NOYEARENDP: No Year-End Period exists for the date :P1 in company :P2',
                                voucher_date_,
                                company_ );
      END IF;
   ELSE
      year_   := vou_year_;
      period_ := vou_period_;
   END IF;
END Get_Acc_Year_Period_User_Group;


PROCEDURE Close_Open_Periods(
   company_             IN  VARCHAR2,
   from_year_           IN  NUMBER,
   to_year_             IN  NUMBER)
IS

CURSOR year_detail(accounting_year_ NUMBER, year_end_period_ VARCHAR2) IS
   SELECT  *
   FROM    ACCOUNTING_PERIOD
   WHERE   company = company_
   AND     accounting_year = accounting_year_
   AND     year_end_period_db = year_end_period_
   AND     period_status_db = 'O';


from_year_data_   ACCOUNTING_PERIOD%ROWTYPE ;
to_year_data_   ACCOUNTING_PERIOD%ROWTYPE ;
attr_        VARCHAR2(2000);
info_        VARCHAR2(2000);

BEGIN
   OPEN  year_detail(from_year_, 'YEARCLOSE');
   FETCH year_detail INTO from_year_data_;
   IF ( year_detail%NOTFOUND ) THEN
      Error_SYS.Record_General( lu_name_, 'NO_ACCYEAR: Not a valid Accounting Year' );
   END IF;
   CLOSE year_detail;

   Client_SYS.Clear_Attr(attr_);
   Client_SYS.Add_To_Attr('PERIOD_STATUS',Acc_Per_Status_API.Decode('C'), attr_);
   Modify__ (info_ ,from_year_data_.objid, from_year_data_.objversion, attr_,'DO' );

   OPEN  year_detail(to_year_,'YEAROPEN');
   FETCH year_detail INTO to_year_data_;
   IF ( year_detail%NOTFOUND ) THEN
      Error_SYS.Record_General( lu_name_, 'NO_ACCYEAR: Not a valid Accounting Year' );
   END IF;
   CLOSE year_detail;

   Client_SYS.Clear_Attr(attr_);
   Client_SYS.Add_To_Attr('PERIOD_STATUS',Acc_Per_Status_API.Decode('C'), attr_);

   Modify__ (info_ ,to_year_data_.objid, to_year_data_.objversion, attr_,'DO' );

END Close_Open_Periods;


@UncheckedAccess
FUNCTION Get_First_Normal_Period (
   company_         IN VARCHAR2,
   accounting_year_ IN NUMBER ) RETURN NUMBER
IS
   CURSOR get_first_normal IS
      SELECT accounting_period
        FROM Accounting_Period_Tab
       WHERE company         = company_
         AND accounting_year = accounting_year_
         AND year_end_period = 'ORDINARY'
       ORDER BY accounting_period ASC;
   acc_period_  NUMBER;
BEGIN
   OPEN get_first_normal;
   FETCH get_first_normal INTO acc_period_;
   IF (get_first_normal%FOUND) THEN
      CLOSE get_first_normal;
      RETURN acc_period_;
   END IF;
   CLOSE get_first_normal;
   RETURN -1;
END Get_First_Normal_Period;


@SecurityCheck Company.UserAuthorized(company_)   
PROCEDURE Get_Prev_Ordinary_Period (
   previous_period_    OUT NUMBER,
   previous_year_      OUT NUMBER,
   company_             IN VARCHAR2,
   current_period_      IN NUMBER,
   current_year_        IN NUMBER,
   status_check_        IN VARCHAR2 DEFAULT NULL,
   no_of_periods_       IN NUMBER   DEFAULT NULL )
IS
   dummy_                  NUMBER := 1;
   dummy_no_of_periods_    NUMBER ;
   CURSOR prev_ordinary_acc_period IS
      SELECT  accounting_year, accounting_period
      FROM    ACCOUNTING_PERIOD_TAB
      WHERE   company         = company_
      AND     (accounting_year * 100) + accounting_period  <
              (current_year_ * 100 ) + current_period_
      AND     period_status   = 'O'
      AND     year_end_period = 'ORDINARY'
      ORDER BY (ACCOUNTING_YEAR) DESC, (ACCOUNTING_PERIOD) DESC ;

   CURSOR prev_ord_acc_period_status IS
      SELECT  accounting_year, accounting_period
      FROM    ACCOUNTING_PERIOD_TAB
      WHERE   company         = company_
      AND     (accounting_year * 100) + accounting_period  <
              (current_year_ * 100 ) + current_period_
      AND     year_end_period = 'ORDINARY'
      ORDER BY (ACCOUNTING_YEAR) DESC, (ACCOUNTING_PERIOD) DESC ;
BEGIN
   dummy_no_of_periods_       := NVL(no_of_periods_, 1);
   IF ( dummy_no_of_periods_ <= 0 ) THEN
      dummy_no_of_periods_    := 1;
   END IF;
   -- Note- This functionality was requested by PRJREP
   IF (status_check_ IS NULL) THEN
      FOR rec_ IN prev_ordinary_acc_period LOOP
         dummy_ := dummy_ + 1;
         previous_year_    := rec_.accounting_year; 
         previous_period_  := rec_.accounting_period;
         EXIT WHEN (dummy_ > dummy_no_of_periods_ );
      END LOOP;
   ELSE
      FOR rec_ IN prev_ord_acc_period_status LOOP
         dummy_ := dummy_ + 1;
         previous_year_    := rec_.accounting_year; 
         previous_period_  := rec_.accounting_period;
         EXIT WHEN (dummy_ > dummy_no_of_periods_ );
      END LOOP;
   END IF;
END Get_Prev_Ordinary_Period;


PROCEDURE Open_Period (
   objid_      IN     VARCHAR2,
   objversion_ IN OUT VARCHAR2 )
IS
   info_           VARCHAR2(2000);
   attr_           VARCHAR2(2000);
BEGIN
   
   Client_SYS.Clear_Attr( attr_ );
   Client_SYS.Add_To_Attr( 'PERIOD_STATUS', Acc_Per_Status_API.Decode('O'), attr_ );
   Modify__( info_, objid_, objversion_, attr_, 'DO' );
END Open_Period;


PROCEDURE Close_Period (
   objid_      IN     VARCHAR2,
   objversion_ IN OUT VARCHAR2 )
IS
   info_           VARCHAR2(2000);
   attr_           VARCHAR2(2000);
BEGIN
   
   Client_SYS.Clear_Attr( attr_ );
   Client_SYS.Add_To_Attr( 'PERIOD_STATUS', Acc_Per_Status_API.Decode('C'), attr_ );
   Modify__( info_, objid_, objversion_, attr_, 'DO' );
END Close_Period;


PROCEDURE Close_Period_Finally (
   objid_      IN     VARCHAR2,
   objversion_ IN OUT VARCHAR2 )
IS
   info_           VARCHAR2(2000);
   attr_           VARCHAR2(2000);
BEGIN
   
   Client_SYS.Clear_Attr( attr_ );
   Client_SYS.Add_To_Attr( 'PERIOD_STATUS', Acc_Per_Status_API.Decode('F'), attr_ );
   Modify__( info_, objid_, objversion_, attr_, 'DO' );
END Close_Period_Finally;


@UncheckedAccess
FUNCTION Period_Finally_Closed_Exist (
   company_         IN VARCHAR2,
   accounting_year_ IN NUMBER ) RETURN VARCHAR2
IS
   CURSOR check_period IS
      SELECT 1
      FROM   ACCOUNTING_PERIOD_TAB
      WHERE  company         = company_
      AND    accounting_year = accounting_year_
      AND    period_status   = 'F';
   dummy_  NUMBER;
BEGIN
   
   OPEN  check_period;
   FETCH check_period INTO dummy_;
   IF check_period%FOUND THEN
      CLOSE check_period;
      RETURN 'TRUE';
   ELSE
      CLOSE check_period;
      RETURN 'FALSE';
   END IF;
END Period_Finally_Closed_Exist;


FUNCTION Year_Balanced_At_Period_Close (
   company_         IN VARCHAR2,
   acc_year_        IN NUMBER,
   acc_period_      IN NUMBER) RETURN VARCHAR2
IS
   dummy_            NUMBER;
   amount_balance_   NUMBER;
   stmt_             VARCHAR2(2000);
  
   CURSOR oth_open_periods IS
   SELECT 1
     FROM accounting_period_tab
    WHERE company  = company_
      AND accounting_year = acc_year_
      AND accounting_period != acc_period_
      AND period_status != 'F';
BEGIN
  -- check if it is the last period in the year,
  OPEN oth_open_periods;
  FETCH oth_open_periods INTO dummy_;
  IF oth_open_periods%NOTFOUND THEN
  CLOSE oth_open_periods;
     -- it's last period in the year - check balances and return false when it's not 0
      stmt_ := 'BEGIN Accounting_Balance_API.Cal_Tot_Amount_Bal(:amount, :company, :year, :year1); END;';
      @ApproveDynamicStatement(2009-03-03,reanpl)
      EXECUTE IMMEDIATE stmt_ using OUT amount_balance_, IN company_, IN acc_year_, IN acc_year_;


      IF NVL(amount_balance_,0) != 0 THEN
         RETURN 'FALSE';
      END IF;
  ELSE
    CLOSE oth_open_periods;
  END IF;
  RETURN 'TRUE';
  
END Year_Balanced_At_Period_Close;


@SecurityCheck Company.UserAuthorized(company_)
PROCEDURE Get_Next_Allowing_Period (
   next_allow_period_ OUT NUMBER,
   next_allow_year_   OUT NUMBER,
   company_           IN  VARCHAR2,
   current_period_    IN  NUMBER,
   current_year_      IN  NUMBER )
IS
   CURSOR next_acc_period IS
      SELECT  accounting_year, accounting_period
      FROM    ACCOUNTING_PERIOD_TAB
      WHERE   company = company_
      AND     (accounting_year * 100) + accounting_period  >
              (current_year_ * 100) + current_period_
      AND     year_end_period = 'ORDINARY'
      ORDER BY ACCOUNTING_YEAR, ACCOUNTING_PERIOD ;
BEGIN

   OPEN  next_acc_period;
   FETCH next_acc_period INTO next_allow_year_ , next_allow_period_  ;
   CLOSE next_acc_period;
END Get_Next_Allowing_Period;


@UncheckedAccess
FUNCTION Get_Number_Of_Allowed_Periods (
   company_            IN VARCHAR2,
   first_acc_period_   IN NUMBER,
   first_acc_year_     IN NUMBER,
   last_acc_period_    IN NUMBER,
   last_acc_year_      IN NUMBER) RETURN NUMBER
IS
   no_of_periods_      NUMBER;

   CURSOR get_num_of_periods IS
      SELECT COUNT(accounting_period)
      FROM   ACCOUNTING_PERIOD_TAB
      WHERE  ((accounting_year*100+accounting_period) >= (first_acc_year_*100+first_acc_period_))
      AND    ((accounting_year*100+accounting_period) <= (last_acc_year_*100+last_acc_period_))
      AND    company = company_
      AND    year_end_period = 'ORDINARY';
BEGIN
   OPEN  get_num_of_periods;
   FETCH get_num_of_periods INTO no_of_periods_;
   CLOSE get_num_of_periods;
   
   RETURN no_of_periods_;
END Get_Number_Of_Allowed_Periods;


@UncheckedAccess
FUNCTION Get_Period_Desc(
   period_  IN NUMBER,
   year_    IN NUMBER,
   month_   IN NUMBER ) RETURN VARCHAR2
IS
   desc_ VARCHAR2(100);
BEGIN
   IF period_ = 0 THEN
      desc_ := 'Year Opening Period '||year_;
   ELSIF month_ = 1 THEN
      desc_ := 'January '||year_;
   ELSIF month_ = 2 THEN
      desc_ := 'February '||year_;
   ELSIF month_ = 3 THEN
      desc_ := 'March '||year_;
   ELSIF month_ = 4 THEN
      desc_ := 'April '||year_;
   ELSIF month_ = 5 THEN
      desc_ := 'May '||year_;
   ELSIF month_ = 6 THEN
      desc_ := 'June '||year_;
   ELSIF month_ = 7 THEN
      desc_ := 'July '||year_;
   ELSIF month_ = 8 THEN
      desc_ := 'August '||year_;
   ELSIF month_ = 9 THEN
      desc_ := 'September '||year_;
   ELSIF month_ = 10 THEN
      desc_ := 'October '||year_;
   ELSIF month_ = 11 THEN
      desc_ := 'November '||year_;
   ELSIF month_ = 12 THEN
      desc_ := 'December '||year_;
   END IF;
   RETURN desc_;
END Get_Period_Desc;


PROCEDURE Do_Final_Check (
   company_         IN VARCHAR2,
   accounting_year_ IN NUMBER )
IS
   previous_date_until_      DATE;
   previous_year_end_period_ ACCOUNTING_PERIOD_TAB.year_end_period%TYPE;
   check_year_end_           NUMBER;
   
   -- Bug 105642 Begin, Added accounting_year
   CURSOR accper_data IS
      SELECT date_from, date_until, year_end_period, accounting_period, accounting_year 
      FROM   ACCOUNTING_PERIOD_TAB
      WHERE  company         = company_
      AND    accounting_year = accounting_year_
      ORDER BY  accounting_period;
   -- Bug 105642 End

   CURSOR check_year_end(accounting_period_ NUMBER) IS
      SELECT 1 
      FROM   ACCOUNTING_PERIOD_TAB
      WHERE  company           = company_
      AND    accounting_year   = accounting_year_
      AND    accounting_period = accounting_period_ + 1
      AND    year_end_period   = 'YEARCLOSE';
BEGIN
   FOR get_rec IN accper_data LOOP
      -- Bug 105642 Begin
      Check_Period_Dates_New__(company_, get_rec.accounting_period, get_rec.date_from, get_rec.accounting_year, get_rec.year_end_period);
      Check_Period_Dates_New__(company_, get_rec.accounting_period, get_rec.date_until, get_rec.accounting_year, get_rec.year_end_period);
      -- Bug 105642 End
      
      OPEN  check_year_end(get_rec.accounting_period);
      FETCH check_year_end INTO check_year_end_;
      CLOSE check_year_end;

      IF (check_year_end_ IS NULL) THEN
         Check_Whole_Period__(company_, get_rec.date_from, get_rec.date_until);
      END IF;

      -- in table period_type stores as year_end_period
      IF previous_year_end_period_ IS NOT NULL AND previous_date_until_ IS NOT NULL THEN
         IF previous_year_end_period_ = 'YEAROPEN' AND get_rec.year_end_period = 'ORDINARY' THEN
            -- condition1 applies to the ORDINARY period type , but raise the same error msg
            IF NOT (previous_date_until_ = get_rec.date_from) THEN
                              Error_SYS.Record_General(lu_name_,
               'INVDATE1: Date :P1 and :P2 not in sequential order',
               previous_date_until_,
               get_rec.date_from);
            END IF;
         ELSIF previous_year_end_period_ = 'ORDINARY' AND get_rec.year_end_period = 'ORDINARY' THEN
            -- condition1 applies to the ORDINARY period type , but raise the same error msg 
            IF NOT (previous_date_until_ + 1 = get_rec.date_from) THEN
                              Error_SYS.Record_General(lu_name_,
               'INVDATE1: Date :P1 and :P2 not in sequential order',
               previous_date_until_,
               get_rec.date_from);
            END IF;
         END IF;
      END IF;
      previous_date_until_      := get_rec.date_until;
      previous_year_end_period_ := get_rec.year_end_period;
   END LOOP;
END Do_Final_Check;


@SecurityCheck Company.UserAuthorized(company_)
PROCEDURE Get_Next_Any_Period (
   next_period_    OUT NUMBER,
   next_year_      OUT NUMBER,
   company_        IN  VARCHAR2,
   current_period_ IN  NUMBER,
   current_year_   IN  NUMBER )
IS
   CURSOR next_acc_period IS
      SELECT accounting_year, accounting_period
      FROM   ACCOUNTING_PERIOD_TAB
      WHERE  company = company_
      AND   (accounting_year * 100) + accounting_period  >
            (current_year_ * 100) + current_period_
      ORDER BY ACCOUNTING_YEAR, ACCOUNTING_PERIOD ;
BEGIN
   OPEN  next_acc_period;
   FETCH next_acc_period INTO next_year_, next_period_;
   CLOSE next_acc_period;
END Get_Next_Any_Period;


@UncheckedAccess
FUNCTION Get_Ordinary_Accounting_period (
   company_        IN  VARCHAR2,
   date_in_        IN  DATE ) RETURN NUMBER
IS
   accounting_year_     NUMBER;
   accounting_period_   NUMBER;
BEGIN
   Get_Ordinary_Accounting_Year(accounting_year_, accounting_period_, company_, date_in_);
   RETURN accounting_period_;
END Get_Ordinary_Accounting_period;


@UncheckedAccess
FUNCTION Get_Period_Incr (
  company_            IN     VARCHAR2,
  year_period_key_    IN     VARCHAR2,
  include_year_end_   IN     VARCHAR2,
  increment_          IN     PLS_INTEGER ) RETURN VARCHAR2
IS
  fr_                 VARCHAR2(1);
  stmt_               VARCHAR2(2000);
  TYPE                Ref_Cur_Type IS REF CURSOR;
  c_get_period_       Ref_Cur_Type;
  order_by_stmt_      VARCHAR2(200);
  year_periods_       Year_Period_Tab;
BEGIN
   fr_ := '>';
   order_by_stmt_ := 'ORDER BY ACCOUNTING_YEAR ASC, ACCOUNTING_PERIOD ASC';
   IF (increment_ < 0 ) THEN
      fr_ := '<';
      order_by_stmt_ := 'ORDER BY ACCOUNTING_YEAR DESC, ACCOUNTING_PERIOD DESC';
   END IF;
   
   stmt_ := 'SELECT  accounting_year, accounting_period ' ||
            'FROM    ACCOUNTING_PERIOD_TAB ' ||
            'WHERE   company = :company_ ' ||
            'AND     (accounting_year * 100) + accounting_period '|| fr_ ||' :year_period_key_ ' ||
            'AND     year_end_period LIKE DECODE(:include_year_end_ ,''TRUE'',''%'',''ORDINARY'') ' ||
            'AND     ROWNUM <= TO_CHAR(ABS(:increment_)) ' ||
            order_by_stmt_;
   @ApproveDynamicStatement(2013-09-04,sjaylk)
   OPEN  c_get_period_ FOR stmt_ USING IN company_, 
                                      IN year_period_key_,
                                      IN UPPER(include_year_end_),
                                      IN increment_;
   FETCH c_get_period_ BULK COLLECT INTO year_periods_ ;
   CLOSE c_get_period_;       
   
   IF (year_periods_.COUNT = 0) THEN
      RETURN NULL;
   ELSE 
      RETURN(Build_Year_Period_Key___(year_periods_(ABS(increment_))));
   END IF;
END Get_Period_Incr;


@UncheckedAccess
FUNCTION Get_Curr_Acc_Year (
   company_            IN     VARCHAR2) RETURN NUMBER
IS
BEGIN
   RETURN Get_Ordinary_Accounting_Year(company_, SYSDATE);
END Get_Curr_Acc_Year;


@UncheckedAccess
FUNCTION Get_Curr_Acc_Period (
   company_            IN     VARCHAR2) RETURN NUMBER
IS
BEGIN
   RETURN Get_Ordinary_Accounting_Period(company_, SYSDATE);
END Get_Curr_Acc_Period;


@UncheckedAccess
FUNCTION Get_Acc_Year (
   company_            IN     VARCHAR2,
   date_               IN     DATE) RETURN NUMBER
IS
BEGIN
   RETURN Get_Ordinary_Accounting_Year(company_, date_);
END Get_Acc_Year;


@UncheckedAccess
FUNCTION Get_Acc_Period (
   company_            IN     VARCHAR2,
   date_               IN     DATE) RETURN NUMBER
IS
BEGIN
   RETURN Get_Ordinary_Accounting_Period(company_, date_);
END Get_Acc_Period;


@UncheckedAccess
FUNCTION Get_Curr_Acc_Year_Period (
   company_            IN     VARCHAR2) RETURN VARCHAR2
IS   
BEGIN   
   RETURN Get_Acc_Year_Period(company_, SYSDATE);
END Get_Curr_Acc_Year_Period;


@UncheckedAccess
FUNCTION Get_Acc_Year_Period (
   company_            IN     VARCHAR2,
   date_               IN     DATE) RETURN VARCHAR2
IS
   accounting_year_     NUMBER;
   accounting_period_   NUMBER;
BEGIN
   Get_Ordinary_Accounting_Year(accounting_year_, accounting_period_, company_, date_);
   RETURN TO_CHAR(accounting_year_)||TO_CHAR(accounting_period_,'FM00');   
END Get_Acc_Year_Period;



