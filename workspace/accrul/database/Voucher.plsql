-----------------------------------------------------------------------------
--
--  Logical unit: Voucher
--  Component:    ACCRUL
--
--  IFS Developer Studio Template Version 3.0
--
--  Date    Sign    History
--  ------  ------  ---------------------------------------------------------
--  960401  ToRe     Created
--  990708  Dhar     Rewritten
--  991213  Hima     Added View Voucher_Approval and FUNCTION Get_Sum for Voucher Approval
--  991214  SaCh     Removed public method Get_Voucher_Type.
--  991227  SaCh     Removed public procedure Voucher_Init which supported 7.3.1
--  991227  SaCh     Removed public procedure Voucher_Row which supported 7.3.1
--  000105  SaCh     Added public procedures Get_Voucher_Type, Voucher_Init & Voucher_Row.
--  000125  Uma      Bug Id# 30388. Added private procedure Approve_Voucher__. Changed &VIEW2
--  000308  Uma      Corrected Bug Id# 35388.
--  000328  Ruwan    Corrected Bug Id# 35806. Changed View2 to display 'Error' state vouchers
--  000419  SaCh     Corrected Bug Id# 37978.
--  000422  SaCh     Corrected Bug Id# 38394.
--  000526  AsWi     Added private procedures Create_Voucher_Head__ And Get_Head_Info__.
--  000718  Thanuja  Corrected Call ID 45725. Commented a condition in PROCEDURE Add_Voucher_Row
--  000721  Uma      Changes done in Validate_Voucher_Type__ with respect to A356 - Journal Code
--  000803  Uma      Changed Voucher Group to Function Group
--  000825  BmEk     A527: Added Amount_Method and Get_Amount_Method
--  000904  BmEk     Changed View2 to deselect simulation vouchers
--  000907  Uma      Corrected Bug ID #47808.
--  000909  Uma      Corrected Bug ID #48013. Added Ledger_ID validations
--  000915  HiMu     Added General_SYS.Init_Method
--  000918  Uma      Corrected Bug ID #48556/48558 - Added function_group to Create_Voucher_Head__.
--  000919  Camk     Call #49012 corrected. Can not update Interim Vouchers
--  000922  HiMu     Corrected Bug ID #48832.
--  000922  BmEk     A527: Modified Error_SYS.Check_Not_Null call for newrec_.amount_method.
--  001006  prtilk   BUG # 15677  Checked General_SYS.Init_Method
--  001018  SaCh     Added function_group_ as an in parameter to drop_voucher_ procedure.
--  001026  Uma      Added Get_Function_Group.
--  001219  Chajlk   Call Id 18577 Corrected.
--  010112  Camk     Bug #19012 Corrected.
--  010113  ToOs     Bug #19980, changed calls from User_Group_Period_API.Get_Period/Is_Period_Open
--                   to User_Group_Period_API.Get_And_Validate_Period
--  010221  ToOs     Bug # 20177 Added Global Lu constants for check for transaction_sys calls
--  010226  ToOs     Bug # 20254 Added a check IF intled is installed
--  010307  ToOs     Bug # 20512 Use of a new view in a sub-select in view VOUCHER to increase performance
--  001211  SHSALK   BUG # 18084  Checked the  Authorize Level
--  010427  JeGu     Bug #21600 Performance
--  010502  ANDJ     Bug #21665, GL-Update rewrite.
--  010502  OVJOSE   Added Check if company is a template company.
--  010508  JeGu     Bug #21705 Implementation New Dummyinterface
--                   Changed Insert__ RETURNING rowid INTO objid_
--  010531  JeGu     Misc performance
--  010613  LiSv     Bug #22504 Corrected.
--  010619  JeGu     More #21705
--  010626  Gawilk   Corrections on bug # 21705. Changed the parameter to the
--                   Intled_Connection_V101_API.Check_If_Manual in Approve_Voucher__ .
--  010717  SUMALK   Bug 22932 Fixed.(removed dynamic sql and added Execute Immediate)
--  010720  ToKu     Bug #18398 fixed.
--  010802  Brwelk   Bug 23412 - Added column revenue_cost_clear_voucher to the view, unpack_check_insert & update
--                   Changed method New_Voucher and added Exist_Rev_Cost_Clear_Voucher and Get_Revenue_Cost_Clear_Voucher .
--  010815  JeGu     Bug #23726 Added column simulation_voucher. Changed some procedures/functions
--  010904  JeGu     Bug #24125 Some minor changes
--  010925  JeGu     Fix length on company_ in add_voucher_row
--  011010  Assalk   Bug # 25033, Returned voucher_no in New_Voucher is the ledger is an Internal Ledger.
--  011024  ovjose   Bug #25777. Removed Bug correction 18577 (savepoint caused ora-error).
--  020618  ASHELK   Bug 30756, Overloaded Procedure Interim_Voucher to Pass
--  020618           User Group Selected in client to Server.
--  020826  SACHLK   Corrected Bug # 29965.
--  021017  SAMBLK   Increased the length of the voucher_group_ in Voucher_Init & Create_Pca_Voucher
--  021023  LoKrLK   Corrected Core bug Comments According to Delta Engine Standards
--  030731  Nimalk   SP4 Merge.
--  030822  LoKrLK   LCS Patch Merge (37672)
--  030916  LoKrLK   LCS Patch Merge (38535) Modified Update__
--  031017  Thsrlk   LCS Patch Merge (38745).
--  031029  Raablk   Did small modification in View Voucher .(When get Value for Free Text use
--                   Voucher_Text instead Voucher_Text2  )
--  040329  Gepelk   2004 SP1 Merge.
--  040722  Hecolk   FIPR228, Added Method Get_Vou_Status_Client_, Modified Finite_State_Set___
--  040901  Kagalk   LCS Merge (45622).
--  041004  Ingulk   FITH337A - Added a condition to the accounting_period in the Unpack_Check_Update___.
--  041004  julwcmbp FIJP334A, Added column Use_Correction_Rows to Voucher_Tab
--  041015  Hecolk   Modified Finite_State_Set___
--  041206  ShSaLk   Remove of Sync730.api/apy.
--  050316  Viselk   LCS Bug 49375 Merged.
--  050826  AsHelk   LCS Bug 51787 Merged. Re-arranged view VOUCHER_APPROVAL for performance improvement.
--  051114  THPELK   FIAD377 - Added Rollback_Voucher_ parameter for Reverse_Voucher__().
--  051118  WAPELK   Merged the Bug 52783. Correct the user group variable's width.
--  051122  RUFELK   Corrected Bug # 129112. Modified the field 'free_text' in 'VOUCHER' view.
--  051124  MASELK   Bug #127522 Modified methods Unpack_Check_Insert__() and Unpack_Check_Update__()
--  051207  RUFELK   B129486 Modified decode function of the field 'free_text' in the 'VOUCHER' view.
--  060109  AsHelk   Merged LCS Bug 54162.
--  060210  Kethlk   Merged LCS Bug 55967.
--  060219  GADALK   B129952 - Changed in New_Voucher. Call to Voucher_No_Serial_API.Get_Next_Voucher_No
--  060228  Miablk   B133615 - Moved the 'IF' condition that sets revenue_cost_clear_voucher to 'false' in to
--                   Unpack_Check_Insert___ method where the value for revenue_cost_clear_voucher is set
--  060303  GADALK   Corrected the erroronous/strange method Get_Revenue_Cost_Clear_Voucher
--  060306  GADALK   B132835 - Changed Check_Voucher_Head_() validation skipped for YE function group
--  060314  GADALK   B136671 - Fixes in Get_Revenue_Cost_Clear_Voucher().
--  060918  SHSALK   LCS Merge 55369, A condition, for external vouchers, added.
--  061026  SuSalk   LCS Merge 58796, Added New Method Voucher_Rows_Exist.
--  061127  Paralk   LCS Merge 61065,Added procedure Is_User_Group_Used.
--  061129  NUGALK   Bug 61262, Corrected. Added function_group_ = 'J' to the elsif condition in Get_Reference_Company__
--  070212  Bmekse   FIPL634 Added Set_Reference_Data
--  070213  JoBase   FIPL641A: Added function Is_Pca_Update_Blocked.
--  070301  GaDalk   FIPL633A: Added procedure Clear_Row_Group_Ids__.
--  070306  GaDalk   FIPL633A: Added procedure Check_Double_Entry__.
--  070315  GaDalk   FIPL633A: Added row_group_validation to base view; Modified Check_Double_Entry__.
--  070329  GaDalk   B141953,B141956 FIPL633A Change of error message texts
--  070329  Kagalk   LCS Merge 63764, Added method Update_Intled_Voucher_Head___.
--  070426  Chsalk   LCS Merge 64832, Modified method interim_voucher.
--  070509  Surmlk   Added General_SYS.Init_Method  to method Clear_Row_Group_Ids__
--  070516  Chhulk   B142136 Modified Approve_Voucher__()
--  070517  Surmlk   Added ifs_assert_safe comment
--  070629  Paralk   LCS Merge 65535, Added method Remove_Object_Connections 
--  070702  Paralk   LCS Merge 65950 , Modified New_Voucher() , Create_Voucher_Head__()
--  070802  Maaylk   made Check_Refer_Mandatory__() private 
--  071016  DIFELK   Bug 68069 corrected. Modified Exist_Rev_Cost_Clear_Voucher to exclude updated vouchers.
--  071031  DIFELK   Bug 68295 corrected. Modifications done to update approve data depending on the rights given to user group.
--  071107  AsHelk   Bug 68285 corrected. Added Procedure Interim_Vou_Check_Ok___.
--  071114  DIFELK   Bug 68932 corrected. Modification done to disconnect voucher group K only when a connection is there.
--  080326  NiFelk   Bug 69891, Corrected.  
--  080423  Jeguse   Bug 73309, Corrected in Complete_Voucher___
--  080425  Makrlk   Bug 69890, Corrected.
--  080709  AsHelk   Bug 74637, Corrected.
--  080821  Mawelk   Bug 76395, Corrected. Modified Get_Reference_Company__() method
--  080911  Thepelk  Bug 76123, Corrected in Reverse_Voucher__() to create internal Ledger Vouchers for reversal vouchers.
--  081027  Thpelk   Bug 77406 - Modified Voucher_End().
--  081208  Thpelk   Bug 77503, Added validations for reversal voucher date in Reverse_Voucher__().
--  090122  Nirplk    Bug 77430, Added new voucher status 'Awaiting Approval'
--  090224  Thpelk   Bug 80676, Modified in Check_Voucher_Head_ to avoid validations for voucher with cancell state.
--  090225  Nirplk    Bug 77430, Corrected
--  090311  AjPelk   Bug 80599, Corrected
--  090325  RUFELK   Bug 77430, Corrected.
--  090407  RUFELK   Bug 82005, Corrected. Modified the Insert___() method to conditionally set the initial OBJSTATE.
--  090428  THPELK   Bug 82345, Corrected in Finite_State_Events__() and Finite_State_Machine___().  
--  090513  Maaylk   Bug 82107, Added conditon to make sure the object about to be deleted is not that do not exist
--  090513  Mawelk   Bug 82781, Added Check_Exist___() for Check_Voucher_Exist___() method.
--  090525  AsHelk   Bug 80221, Adding Transaction Statement Approved Annotation.
--  090717  ErFelk   Bug 83174, Replaced constant WRONGCALLORD2 and WRONGCALLORD3 with WRONGCALLORD1 in Add_Voucher_Row
--  090717           and Voucher_End. Chnaged some error messages in Interim_Voucher.
--  090810  LaPrlk   Bug 79846, Removed the precisions defined for NUMBER type variables.
--  090915  Thpelk   Bug 85766, Corrected in VOUCHER view.
--  091026  Mawelk   Bug 86703, corrected in VOUCHER view 
--  091210  Umdolk   Reverse Engineering Corrections, added missing references in base view.
--  100106  Umdolk   Added new state template.
--  100121  Makrlk   TWIN PEAKS Merge.
            --  090102  Ersruk   Modified Remove_Object_Connections to consider exclude_proj_followup.
            --  090317  Makrlk   Modified the method Create_Object_Connections__() to handle any code part value
--  101101  Elarse   RAVEN-985, Added newrec_.amount_method to New_Voucher().
--  100609  Ersruk   Modified the method Create_Object_Connections__() to handle transaction currency.
--  100725  Mawelk  Bug 91775 Corrected. Called the method Remove_Connected_Il_Vouchers() in Delete_Internal_Rows
--  110121  AjPelk  Bug 93980, Corrected.
--  ---------------- SIZZLER --------------------------------------------------
--  111207  Ersruk   Modified Voucher_End to raise errors if cancel_option is false.
--  110308  THPELK  EASTONE-14691 LCS Merge( Bug 95617) Added new method Remove_Object_Connections(), Remove_Object_Connections___() with two new paramters 
--                  and modified the existing.
--  110530  THPELK  EASTONE-19663 LCS Merge(bug 94149)-Corrected in Insert___() added NVL condition to newrec_.interim_voucher so the vouchers without interim
--                  vouchers will be saved with 'N' for interim voucher column 
--  110708  Nsillk  FIDEAGLE-537, Merged Bug 94459
--  110721  Sacalk  FIDEAGLE-317, Merged Bug 96287, Corrected in Unpack_Check_Update___().
--  110812  Mohrlk  FFIDEAGLE-211, Modified method Update___().
--  111018  Shdilk  SFI-135, Conditional compilation.
--  111020  Swralk  SFI-143, Added conditional compilation for the places that had called package INTLED_CONNECTION_V101_API and INTLED_CONNECTION_V140_API.
--  111026  Nirplk  SFI-8, Merged Bug 99038, Corrected in Unpack_Check_Update___().
--  111117  Swralk  SFI-739, Removed General_SYS.Init statement from FUNCTION Is_Cancellation_Voucher__ and Is_Pca_Update_Blocked. 
--  111205  Shdilk  SFI-1066, Templates for entities with state.
--  120302  Sacalk  SFI-2396, Modified in PROCEDURE Voucher_End 
--  120313  Clstlk  EASTRTM-3899, LCS Merge( Bug 101511)
--  120403  Clstlk  EASTRTM-8352, LCS Merge( Bug 101535)
--  120812  THPELK  Bug 104100, Merged. Corrected the Performance improvement in fetching voucher row number.
--  120817  Umdolk  EDEL-1324, Modified Complete_Voucher__ method to update add_investment_info records when completing the voucher. 
--  120827  Umdolk  EDEL-1504, Added method Is_Cancel_Vou_Exist_Hold.  
--  120917  Umdolk  EDEL-1440, Added method Check_Negative_Amount.
--  121123  Thpelk  Bug 106680 - Modified Conditional compilation to use single component package.
--  121123  Janblk  DANU-122, Parallel currency implementation.
--  121210  Maaylk  PEPA-183, Removed global variables
--  121231  AmThLK  Bug 107600 -Modified Refr_Obj_Conn_Cost_Info___: removed the Function Group 'P' from the cost calculation (not needed in the processes of PeriodicalCapitalization, Revenue Recognition and Project completion)
--  130307  CLSTLK  Bug 108417 Merged. Added Finalize_Interim_Voucher___() and modified Interim_Voucher().
--  130506  THPELK  Bug 109556, Corrected. Added the IF condition to allow status changes from AwaitingAprroval -> Approved and Not Approved -> Approved
--                  for interim voucher('R').
--  130508  NILILK  DANU-244, Modified Check_Double_Entry__ to modify an error message related to Parallel Currency.  
--  130816  Clstlk  Bug 111218, Fixed General_SYS.Init_Method issue.
--  130917  CLSTLK  Bug 110569,Added new function Is_Voucher_Status_Error()
--  140108  ChFolk  Modified Finite_State_Machine___ to get the value for state_.
--  140220  MEALLK  PBFI-5543, Added User_Group_Period_API.Is_Period_Open check to Check_Insert___ and Check_Update___
--  140305  MAWELK  LCS Bug Id ) Fixed.
--  140407  Umdolk  PBFI-6383, Corrected in interim_voucher method.
--  140408  Shedlk  PBFI-4123, Merged LCS bug 112236.
--  140429  DIFELK  PBFI-6998, removed methods Get_Balance_Voucher_Par___ and Get_Balance_Voucher__.
--                  Calls new method Get_Balance_Voucher_All___ instead.
--  140409  Nirylk  PBFI-5614, Added deliv_type_id to VoucherRowRecType   
--  140902  THPELK  PRFI-1102 LCS Merge(Bug 116267).
--  141115  DipeLK  PRFI-3492,Paralell curency columnsimplemented in Approval Voucher window.
--  140328  THPELK  PRFI-3705, LCS Merg(Bug 115796) Corrected.
--  141217  THPELK  PRFI-4111, Excluded function group YE from the PRFI-3705 correction due to the special handling ( clear revenue cost voucher creation 
--                  process do not call Voucher_API.Voucher_End).
--  150407  Kanslk  Bug 121856, Modified 'Complete_Voucher__', so that vouchers created in function group T, voucher gets inbalnace in parallel currency in some special scenarios, 
--                  in such case voucher row with the lowest parallel amount is updated so that voucher gets balanced. 
--  140521  THPELK  Bug 122504, Corrected to handle Year End Vouchers.
--  150810  THPELK  Bug 123270, Corrected.
--  151118  Mawelk  Bug Id 125057 Added a method Update_Current_Row_Num
--  160211  Chwtlk  Bug 126851, Moved PROCEDURE Balance_Parallel_Diff___ outside of the scope of PROCEDURE Complete_Voucher__.
--                  Called PROCEDURE Balance_Parallel_Diff___ from PROCEDURE Voucher_End. Modified PROCEDURE Balance_Parallel_Diff___.
--  160518  Nudilk  Bug 129273, Corrected in Get_Sum.
--  160905  Chwilk  Bug 130729, Modified New_Voucher.
-----------------------------------------------------------------------------

layer Core;

-------------------- PUBLIC DECLARATIONS ------------------------------------

TYPE VoucherRecType IS RECORD (
    company                    VARCHAR2(20),
    voucher_type               VARCHAR2(3),
    function_group             VARCHAR2(10),
    accounting_year            NUMBER,
    voucher_no                 NUMBER,
    voucher_date               DATE,
    accounting_period          NUMBER,
    date_reg                   DATE,
    userid                     VARCHAR2(30),
    user_group                 user_group_member_finance_tab.user_group%type,    
    correction                 VARCHAR2(1),
    accounting_text_id         VARCHAR2(200),
    voucher_text               VARCHAR2(2000),
    voucher_text2              VARCHAR2(2000),
    update_error               VARCHAR2(200),
    internal_seq_number        NUMBER,
    transfer_id                VARCHAR2(200),
    interim_voucher            VARCHAR2(1),
    voucher_type_reference     VARCHAR2(3),
    accounting_year_reference  NUMBER,
    voucher_no_reference       NUMBER,
    multi_company_id           VARCHAR2(20),
    jou_no                     NUMBER,
    entered_by_user_group      user_group_member_finance_tab.user_group%type,
    approval_date              DATE,
    approved_by_userid         VARCHAR2(30),
    approved_by_user_group     user_group_member_finance_tab.user_group%type,
    revenue_cost_clear_voucher VARCHAR2(5),
    amount_method              VARCHAR2(200),
    simulation_voucher         VARCHAR2(5),
    project_code_part          VARCHAR2(1),
    fa_code_part               VARCHAR2(1),
    curr_code_part             VARCHAR2(1),
    elim_code_part             VARCHAR2(1),
    internal_code_part         VARCHAR2(10),
    status_cancelled           VARCHAR2(5),
    base_currency_code         VARCHAR2(3),
    base_currency_rounding     NUMBER,
    base_currency_inverted     VARCHAR2(5) );

TYPE VoucherRowRecType IS RECORD (
    company                         VARCHAR2(20),
    voucher_type                    VARCHAR2(3),
    function_group                  VARCHAR2(10),
    accounting_year                 NUMBER,
    accounting_period               NUMBER,
    voucher_no                      NUMBER,
    row_no                          NUMBER,
    row_group_id                    NUMBER,
    codestring_rec                  Accounting_Codestr_Api.CodestrRec,
    internal_seq_number             NUMBER,

    correction                      VARCHAR2(1),         -- to support old version
    currency_debet_amount           NUMBER,
    currency_credit_amount          NUMBER,
    currency_amount                 NUMBER,              -- to support old version
    debet_amount                    NUMBER,
    credit_amount                   NUMBER,
    amount                          NUMBER,              -- to support old version
    third_currency_debit_amount     NUMBER,
    third_currency_credit_amount    NUMBER,
    third_currency_amount           NUMBER,

    currency_code                   VARCHAR2(3),
    quantity                        NUMBER,
    process_code                    VARCHAR2(10),
    optional_code                   VARCHAR2(20),
    project_activity_id             NUMBER,
    text                            VARCHAR2(200),
    party_type_id                   VARCHAR2(20),
    reference_serie                 VARCHAR2(50),
    reference_number                VARCHAR2(50),
    reference_row_no             NUMBER ,
    trans_code                      VARCHAR2(100),
    update_error                    VARCHAR2(200),
    transfer_id                     VARCHAR2(200),
    corrected                       VARCHAR2(20),
    ext_validate_codestr            VARCHAR2(10),
    multi_company_id                VARCHAR2(20),
    currency_rate                   NUMBER,
    conversion_factor               NUMBER,
    voucher_date                    DATE,
    object_id                       VARCHAR2(10),
    project_id                      VARCHAR2(10),
    auto_tax_vou_entry              VARCHAR2(20),
    tax_direction                   VARCHAR2(20),
    tax_amount                      NUMBER,
    currency_tax_amount             NUMBER,
    tax_base_amount                 NUMBER,
    currency_tax_base_amount        NUMBER,
    reference_version               NUMBER,
    party_type                      VARCHAR2(20),
    mpccom_accounting_id            NUMBER,
    currency_type                   VARCHAR2(10),
    revenue_cost_clear_voucher      VARCHAR2(5),       --'TRUE' for 'clear rev/cost vouchers'
    activate_code                   VARCHAR2(20),
    parallel_curr_rate_type         VARCHAR2(10),
    parallel_currency_rate          NUMBER,
    parallel_curr_conv_fac          NUMBER,
    parallel_curr_gross_amt         NUMBER,
    parallel_curr_tax_amt           NUMBER,
    parallel_curr_tax_base_amt      NUMBER,
    deliv_type_id                   voucher_row_tab.deliv_type_id%TYPE
    );


-------------------- PRIVATE DECLARATIONS -----------------------------------


-------------------- LU SPECIFIC IMPLEMENTATION METHODS ---------------------

PROCEDURE Refr_Obj_Conn_Cost_Info___(
   rec_    IN OUT VOUCHER_TAB%ROWTYPE )
IS
   CURSOR get_vourow IS
      SELECT row_no
      FROM   voucher_row_tab
      WHERE  company          = rec_.company
      AND    accounting_year  = rec_.accounting_year
      AND    voucher_type     = rec_.voucher_type
      AND    voucher_no       = rec_.voucher_no
      AND    nvl(project_activity_id,0) <> 0;
BEGIN
   -- Refresh Object Connection and Cost Info of Activity Connected Voucher Rows
   -- Bug 107600,  Begin
   IF rec_.function_group IN ('M','0','L','T','O','V','TF') THEN
      FOR rowrec_ IN get_vourow LOOP
         Voucher_Row_API.Calculate_Cost_And_Progress (rec_.company,
                                                      rec_.voucher_type,
                                                      rec_.accounting_year,
                                                      rec_.voucher_no,
                                                      rowrec_.row_no);
      END LOOP;
   END IF;
   -- Bug 107600,  End
END Refr_Obj_Conn_Cost_Info___;


PROCEDURE Object_Conn_Handler___(
   rec_                  IN OUT VOUCHER_TAB%ROWTYPE,
   object_conn_handling_ IN     VARCHAR2 )
IS
BEGIN
   IF (NVL(object_conn_handling_, 'XXX')= 'XXX')  THEN
      -- Default behaviour... Refresh cost info
      Refr_Obj_Conn_Cost_Info___(rec_);
   ELSIF (NVL(object_conn_handling_, 'XXX')= 'CREATE') THEN
      -- Object connection creation has not been handled in any other way
      -- Therefore Create it
      Voucher_Row_API.Create_Object_Connection(rec_.company,
                                               rec_.voucher_type,
                                               rec_.accounting_year,
                                               rec_.voucher_no );
   ELSE 
      -- No object connection related activity should be performed
      NULL;
   END IF;
END Object_Conn_Handler___;


PROCEDURE Interim_Vou_Check_Ok___ (
   voucher_type_     IN VARCHAR2,
   voucher_no_       IN NUMBER,
   accounting_year_  IN NUMBER,
   company_          IN VARCHAR2 )
IS
   
   interim_voucher_       VARCHAR2(2);
   CURSOR chk_voucher IS
      SELECT interim_voucher
        FROM Voucher_Tab
       WHERE company            = company_
         AND accounting_year    = accounting_year_
         AND voucher_type       = voucher_type_
         AND voucher_no         = voucher_no_
         AND voucher_updated    = 'N';
   
BEGIN
   OPEN chk_voucher;
   FETCH chk_voucher INTO interim_voucher_;
   IF (chk_voucher%FOUND) THEN
      CLOSE chk_voucher;
      IF (nvl(interim_voucher_,'N')= 'Y') THEN
         Error_SYS.Record_General(lu_name_,'INTERIMVOUEXIST: Interim voucher already exists.');
      END IF;
   ELSE
      CLOSE chk_voucher;
      Error_SYS.Record_General(lu_name_,'VOUUPD: This voucher has already been updated to General Ledger'); 
   END IF;
END Interim_Vou_Check_Ok___;

FUNCTION Lock_And_Get_Next_Row_No___ (
   company_         IN VARCHAR2,
   voucher_type_    IN VARCHAR2,
   accounting_year_ IN NUMBER,
   voucher_no_      IN NUMBER ) RETURN NUMBER
IS
   CURSOR get_next_vou_row_number IS
      SELECT NVL(v.current_row_number,0), rowstate, function_group
       FROM voucher_tab v
      WHERE v.company         = company_
       AND  v.accounting_year = accounting_year_
       AND  v.voucher_no      = voucher_no_
       AND  v.voucher_type    = voucher_type_
       FOR UPDATE NOWAIT;

   next_vou_row_number_  NUMBER := NULL;
   voucher_status_       VOUCHER_TAB.rowstate%TYPE;
   function_group_       VOUCHER_TAB.function_group%TYPE;
   vou_changed 			 EXCEPTION;
   vou_deleted 			 EXCEPTION;
   vou_locked  			 EXCEPTION;
   PRAGMA      			 EXCEPTION_INIT(vou_locked, -0054);
BEGIN
   
   OPEN  get_next_vou_row_number;
   FETCH get_next_vou_row_number INTO next_vou_row_number_, voucher_status_, function_group_;
   IF (get_next_vou_row_number%NOTFOUND) THEN
      CLOSE get_next_vou_row_number;
      RAISE vou_deleted;
   ELSE
      -- function group 'R' set the voucher head 'Confirmed' before adding any voucher rows. Therefore have to exclude it too.
      IF (voucher_status_ = 'Confirmed' AND function_group_ NOT IN ('M', 'K', 'Q', 'R', 'YE')) THEN
         CLOSE get_next_vou_row_number;
         RAISE vou_changed;
      ELSE
         next_vou_row_number_ := next_vou_row_number_+1;

         UPDATE voucher_tab 
           SET  current_row_number = next_vou_row_number_
         WHERE company         = company_
          AND  accounting_year = accounting_year_
          AND  voucher_no      = voucher_no_
          AND  voucher_type    = voucher_type_;
      
         CLOSE get_next_vou_row_number;
         RETURN next_vou_row_number_;
      END IF;
   END IF;         
       
EXCEPTION
   WHEN vou_locked THEN
      Error_SYS.Record_Locked(lu_name_);
   WHEN vou_changed THEN
      Error_SYS.Record_Modified(lu_name_);
   WHEN vou_deleted THEN
      Error_SYS.Record_Removed(lu_name_);
END Lock_And_Get_Next_Row_No___;   

PROCEDURE Check_Voucher_Exist___ (
   newrec_ IN VOUCHER_TAB%ROWTYPE )
IS
BEGIN
   IF (Check_Exist___ (newrec_.company,newrec_.accounting_year,newrec_.voucher_type,newrec_.voucher_no)) THEN
     Error_SYS.Record_General(lu_name_,'VOUCHERISEXIST: The Voucher object already exists');
   END IF; 
   $IF Component_Genled_SYS.INSTALLED $THEN
      Gen_Led_Voucher_API.Exist_Voucher ( newrec_.company,
                                          newrec_.voucher_type,
                                          newrec_.accounting_year,
                                          newrec_.voucher_no );
   $END
END Check_Voucher_Exist___;


PROCEDURE Validate_At_New___ (
   external_ IN BOOLEAN,
   newrec_   IN OUT VOUCHER_TAB%ROWTYPE )
IS
BEGIN
   Validate_Voucher___ (newrec_);
END Validate_At_New___;


PROCEDURE Validate_At_Modify___ (
   newrec_ IN OUT VOUCHER_TAB%ROWTYPE,
   oldrec_ IN VOUCHER_TAB%ROWTYPE )
IS
BEGIN
   Validate_Voucher___ (newrec_);
END Validate_At_Modify___;


PROCEDURE Drop_Voucher___ (
   company_         IN VARCHAR2,
   voucher_type_    IN VARCHAR2,
   accounting_year_ IN NUMBER,
   voucher_no_      IN NUMBER,
   remove_          IN BOOLEAN )
IS
BEGIN
   -- PICZ if in voucher type there is information, that voucher should be left in this table
   -- mark it as consolidated ...

   IF (remove_) THEN
      Voucher_Row_API.Drop_Voucher_Rows_ ( company_,
                                           voucher_type_,
                                           accounting_year_,
                                           voucher_no_ );
      DELETE
      FROM  voucher_tab
      WHERE company         = company_
      AND   voucher_type    = voucher_type_
      AND   accounting_year = accounting_year_
      AND   voucher_no      = voucher_no_;
   ELSE
      Mark_Voucher_Updated ( company_,
                             accounting_year_,
                             voucher_type_,
                             voucher_no_ );
   END IF;
END Drop_Voucher___;


PROCEDURE Remove_Object_Connections___(
   row_no_          OUT NUMBER,
   err_msg_         OUT VARCHAR2,
   company_         IN  VARCHAR2,
   voucher_type_    IN  VARCHAR2,
   accounting_year_ IN  NUMBER,
   voucher_no_      IN  NUMBER,
   function_group_  IN  VARCHAR2,
   store_original_  IN  VARCHAR2)
IS
   exclude_proj_followup_  VARCHAR2(5);
   CURSOR get_vou_rows(company_ VARCHAR2,vou_type_ VARCHAR2,acc_year_ NUMBER,vou_no_ NUMBER) IS
      SELECT row_no,project_activity_id,trans_code, party_type, company, account
        FROM Voucher_Row_Tab
       WHERE company         = company_
         AND voucher_type    = vou_type_
         AND accounting_year = acc_year_
         AND voucher_no      = vou_no_
         AND project_activity_id IS NOT NULL;   
   
   CURSOR check_cust_inv IS
      SELECT 'TRUE'
        FROM Voucher_Tab v, Voucher_Type_Detail_Tab vt
       WHERE v.company                = vt.company
         AND v.voucher_type_reference = vt.voucher_type
         AND v.company                = company_ 
         AND v.accounting_year        = accounting_year_ 
         AND v.voucher_type           = voucher_type_ 
         AND v.voucher_no             = voucher_no_
         AND vt.function_group        = 'F';
   
   vou_row_no_             NUMBER;
   cancelled_cust_inv_     VARCHAR2(5) := 'FALSE';
BEGIN
   err_msg_ := NULL;
   row_no_  := 0;

   -- Enable to remove object connections for K vouchers connected to cancelled customer invoices
   IF (function_group_ = 'K' AND store_original_ = 'N') THEN
      OPEN check_cust_inv;
      FETCH check_cust_inv INTO cancelled_cust_inv_;
      CLOSE check_cust_inv;      
   END IF;  

   FOR rec_ IN get_vou_rows(company_,voucher_type_,accounting_year_,voucher_no_) LOOP
      vou_row_no_ := rec_.row_no;
      IF (NOT (function_group_ = 'K' AND rec_.party_type = 'CUSTOMER' AND rec_.party_type IS NOT NULL)) 
         OR (cancelled_cust_inv_ = 'TRUE') THEN         
         -- Bug 123270, Begin
         IF (store_original_ = 'N' OR (store_original_ = 'Y' AND function_group_ IN ('M', 'K', 'Q') AND rec_.party_type IS NULL )) THEN
            IF (rec_.project_activity_id != 0) THEN               
               exclude_proj_followup_ := Account_API.Get_Exclude_Proj_Followup(rec_.company, rec_.account);
               
               IF ( NVL(exclude_proj_followup_, 'FALSE') = 'FALSE') THEN
                 Voucher_Row_API.Remove_Object_Connection(company_,
                                                          voucher_type_,
                                                          accounting_year_,
                                                          voucher_no_,
                                                          rec_.row_no,
                                                          rec_.project_activity_id );
               END IF;               
            END IF;
         END IF;         
         -- Bug 123270, End
      END IF;
   END LOOP;   
EXCEPTION
   WHEN OTHERS THEN
      row_no_      := vou_row_no_;
      err_msg_     := SQLERRM;      
END Remove_Object_Connections___;


FUNCTION Confirmed_Allowed___ (
   rec_ IN VOUCHER_TAB%ROWTYPE ) RETURN BOOLEAN
IS
   CURSOR find_rows IS
      SELECT 1
      FROM   VOUCHER_ROW_TAB
      WHERE  company         = rec_.company
      AND    voucher_type    = rec_.voucher_type
      AND    accounting_year = rec_.accounting_year
      AND    voucher_no      = rec_.voucher_no
      FOR UPDATE;

   user_group_of_user_  user_group_member_finance_tab.user_group%type;
   found_               BOOLEAN := FALSE;
BEGIN
   IF (User_Group_Member_Finance_API.Is_User_Member_Of_Group (rec_.company, Fnd_Session_API.Get_Fnd_User, rec_.user_group) = 'FALSE') THEN
      user_group_of_user_ := User_Group_Member_Finance_API.Get_User_Group (rec_.company,
                                                                           Fnd_Session_API.Get_Fnd_User);
      IF (Authorize_Level_API.Encode(Voucher_Type_User_Group_API.Get_Authorize_Level(rec_.company, rec_.accounting_year, user_group_of_user_, rec_.voucher_type))='Not Approved') THEN
         Error_Sys.Record_General( 'Voucher', 'STATUSINVALID: Current user is not allowed to change the Status to Approved.');
      END IF;
   END IF;

   Validate_Voucher_In_Balance___(rec_.company,
                                  rec_.voucher_type,
                                  rec_.accounting_year,
                                  rec_.voucher_no);
   FOR row_ IN find_rows LOOP
      found_ := TRUE;
      IF ( rec_.rowstate = 'Error' ) THEN
         UPDATE voucher_row_tab
            SET update_error = ''
         WHERE CURRENT OF find_rows;
      END IF;
   END LOOP;
   IF ( NOT found_ ) THEN
      Error_Sys.record_General( 'Voucher', 'NOVOUCHERROW: There are no voucher rows in current voucher');
   END IF;
   IF (Authorize_Level_API.Encode(Voucher_Type_User_Group_API.Get_Authorize_Level(rec_.company, rec_.accounting_year, rec_.user_group ,rec_.voucher_type))='Not Approved') THEN
      RETURN FALSE;
   END IF;
   RETURN TRUE;
END Confirmed_Allowed___;

-- Bug 127629,begin.
FUNCTION Confirmed_Allow_Approve___ (
   rec_        IN VOUCHER_TAB%ROWTYPE,
   counter_    IN NUMBER) RETURN BOOLEAN
IS
   CURSOR find_rows IS
      SELECT 1
      FROM   VOUCHER_ROW_TAB
      WHERE  company         = rec_.company
      AND    voucher_type    = rec_.voucher_type
      AND    accounting_year = rec_.accounting_year
      AND    voucher_no      = rec_.voucher_no;

   user_group_of_user_  user_group_member_finance_tab.user_group%type;
   found_               BOOLEAN := FALSE;
   row_exist_           NUMBER;
BEGIN
   IF (User_Group_Member_Finance_API.Is_User_Member_Of_Group (rec_.company, Fnd_Session_API.Get_Fnd_User, rec_.user_group) = 'FALSE') THEN
      user_group_of_user_ := User_Group_Member_Finance_API.Get_User_Group (rec_.company,
                                                                           Fnd_Session_API.Get_Fnd_User);
      IF (Authorize_Level_API.Encode(Voucher_Type_User_Group_API.Get_Authorize_Level(rec_.company, rec_.accounting_year, user_group_of_user_, rec_.voucher_type))='Not Approved') THEN
         Error_Sys.Record_General( 'Voucher', 'STATUSINVALID: Current user is not allowed to change the Status to Approved.');
      END IF;
   END IF;

   Validate_Voucher_In_Balance___(rec_.company,
                                  rec_.voucher_type,
                                  rec_.accounting_year,
                                  rec_.voucher_no);
   
   IF counter_ > 0 THEN
     found_ := TRUE;
   ELSE
      OPEN find_rows;
      FETCH find_rows INTO row_exist_;
      CLOSE find_rows;
      IF NVL(row_exist_,0) >0 THEN
        found_ := TRUE;
      END IF;
   END IF;
   
   IF ( NOT found_ ) THEN
      Error_Sys.record_General( 'Voucher', 'NOVOUCHERROW: There are no voucher rows in current voucher');
   ELSE
      UPDATE voucher_row_tab
      SET update_error = ''
      WHERE  company         = rec_.company
      AND    voucher_type    = rec_.voucher_type
      AND    accounting_year = rec_.accounting_year
      AND    voucher_no      = rec_.voucher_no
      AND    update_error IS NOT NULL;
   END IF;
   IF (Authorize_Level_API.Encode(Voucher_Type_User_Group_API.Get_Authorize_Level(rec_.company, rec_.accounting_year, rec_.user_group ,rec_.voucher_type))='Not Approved') THEN
      RETURN FALSE;
   END IF;
   RETURN TRUE;
END Confirmed_Allow_Approve___;
-- Bug 127629,end.

FUNCTION Waiting_Allowed___ (
   rec_ IN VOUCHER_TAB%ROWTYPE ) RETURN BOOLEAN
IS
   user_group_of_user_  user_group_member_finance_tab.user_group%type;
BEGIN
   user_group_of_user_ := User_Group_Member_Finance_API.Get_User_Group (rec_.company,
                                                                        Fnd_Session_API.Get_Fnd_User);
   IF (user_group_of_user_ IS NULL) THEN
      RETURN FALSE;
   END IF;
   RETURN TRUE;
END Waiting_Allowed___;


FUNCTION Awaiting_Ok___ (
   rec_  IN VOUCHER_TAB%ROWTYPE ) RETURN BOOLEAN
IS
   CURSOR find_vou_rows IS
      SELECT 1
      FROM   VOUCHER_ROW_TAB
      WHERE  company         = rec_.company
      AND    voucher_type    = rec_.voucher_type
      AND    accounting_year = rec_.accounting_year
      AND    voucher_no      = rec_.voucher_no
      FOR UPDATE;

   dummy_               NUMBER;
   found_               BOOLEAN := FALSE;
BEGIN
   Validate_Voucher_In_Balance___(rec_.company,
                                  rec_.voucher_type,
                                  rec_.accounting_year,
                                  rec_.voucher_no);

   OPEN find_vou_rows;
   FETCH find_vou_rows INTO dummy_;
   IF (find_vou_rows%FOUND) THEN
      found_ := TRUE;
   END IF;
   CLOSE find_vou_rows;
   
   IF ( NOT found_ ) THEN
      Error_Sys.record_General( 'Voucher', 'NOVOUCHERROW: There are no voucher rows in current voucher');
   END IF;

   RETURN TRUE;
END Awaiting_Ok___;


PROCEDURE Update_Intled_Voucher_Head___(
   newrec_         IN VOUCHER_TAB%ROWTYPE,
   is_insert_      IN BOOLEAN DEFAULT FALSE,
   from_pa_        IN BOOLEAN DEFAULT FALSE )
IS 
   $IF Component_Intled_SYS.INSTALLED $THEN
      new_int_rec_  internal_hold_voucher_API.Intled_Voucher_Head_Rec;
   $END
BEGIN
    $IF Component_Intled_SYS.INSTALLED $THEN
      IF (Voucher_Type_API.Is_Vou_Type_All_Ledger(newrec_.company, newrec_.voucher_type) = 'TRUE') THEN
         IF (NOT from_pa_) THEN
            IF (NOT is_insert_) THEN             
               
               new_int_rec_.company                    := newrec_.company;
               new_int_rec_.voucher_type               := newrec_.voucher_type;
               new_int_rec_.voucher_no                 := newrec_.voucher_no;
               new_int_rec_.accounting_year            := newrec_.accounting_year;
               new_int_rec_.voucher_date               := newrec_.voucher_date;
               new_int_rec_.date_reg                   := newrec_.date_reg;
               new_int_rec_.userid                     := newrec_.userid;
               new_int_rec_.accounting_text_id         := newrec_.accounting_text_id;
               new_int_rec_.voucher_text               := newrec_.voucher_text;
               new_int_rec_.update_error               := newrec_.update_error;
               new_int_rec_.internal_seq_number        := newrec_.internal_seq_number;
               new_int_rec_.transfer_id                := newrec_.transfer_id;
               new_int_rec_.interim_voucher            := newrec_.interim_voucher;
               new_int_rec_.voucher_type_reference     := newrec_.voucher_type_reference;
               new_int_rec_.voucher_updated            := newrec_.voucher_updated;
               new_int_rec_.multi_company_id           := newrec_.multi_company_id;
               new_int_rec_.correction                 := newrec_.correction;
               new_int_rec_.voucher_no_reference       := newrec_.voucher_no_reference;
               new_int_rec_.voucher_text2              := newrec_.voucher_text2;
               new_int_rec_.entered_by_user_group      := newrec_.entered_by_user_group;
               new_int_rec_.approval_date              := newrec_.approval_date;
               new_int_rec_.approved_by_userid         := newrec_.approved_by_userid;
               new_int_rec_.approved_by_user_group     := newrec_.approved_by_user_group;
               new_int_rec_.user_group                 := newrec_.user_group;
               new_int_rec_.accounting_period          := newrec_.accounting_period;
               new_int_rec_.rowversion                 := newrec_.rowversion;
               new_int_rec_.rowstate                   := newrec_.rowstate;

               Internal_Voucher_Util_Pub_API.Update_Head_Internal(new_int_rec_); 
            END IF;
         END IF;
      END IF;
   $ELSE
      NULL;
   $END
END Update_Intled_Voucher_Head___;


FUNCTION Get_Fictive_Voucher_No___  RETURN NUMBER
IS
 CURSOR get_next_no IS
      SELECT Accrul_Fictive_Vou_No.NEXTVAL
      FROM   DUAL;
 
 fictive_voucher_no_     NUMBER;
BEGIN
  OPEN  get_next_no;
  FETCH get_next_no INTO fictive_voucher_no_;
  CLOSE get_next_no;
  
  RETURN fictive_voucher_no_;
END Get_Fictive_Voucher_No___;


FUNCTION Fetch_Transfer_Id___ (
   company_         IN VARCHAR2,
   accounting_year_ IN NUMBER,
   voucher_type_    IN VARCHAR2,
   fictive_vou_no_  IN NUMBER ) RETURN VARCHAR2
IS
   session_id_   CONSTANT VARCHAR2(64) := Sys_Context('USERENV', 'SESSIONID');
   user_name_    VARCHAR2(30);
   transfer_id_  Voucher_Tab.transfer_id%TYPE;
BEGIN
   user_name_      := User_Finance_API.User_Id;
   transfer_id_    := user_name_||'$'||session_id_||'$'||company_||'$'||accounting_year_||'$'||voucher_type_||'$'||fictive_vou_no_;
   RETURN  transfer_id_;
END Fetch_Transfer_Id___;


-- Get_Balance_Voucher_All___
--   Method that sum the balance of a voucher in accounting currency and parallel currency
--   Output parameters:
--   acc_amount_:      Balance in accounting currency
--   par_curr_amount_: Balance in parallel currency
--   Input parameters:    Voucher key columns
PROCEDURE Get_Balance_Voucher_All___ (
   acc_amount_       OUT NUMBER,
   par_curr_amount_  OUT NUMBER,
   company_          IN  VARCHAR2,
   voucher_type_     IN  VARCHAR2,
   accounting_year_  IN  NUMBER,
   voucher_no_       IN  NUMBER )
IS
   CURSOR get_amount_ IS
      SELECT SUM(nvl(debet_amount,0) - nvl(credit_amount,0)),
             SUM(nvl(third_currency_debit_amount,0) - nvl(third_currency_credit_amount,0))
         FROM Accounting_Code_Part_Value_Tab A,
              Voucher_Row_Tab V
         WHERE A.Company         = V.Company
         AND   A.code_part       = 'A'
         AND   A.code_part_value = V.account
         AND   A.stat_account    ='N'
         AND   V.Company         = company_
         AND   V.Voucher_Type    = voucher_type_
         AND   V.Accounting_Year = accounting_year_
         AND   V.Voucher_No      = voucher_no_;
BEGIN
   OPEN get_amount_;
   FETCH get_amount_ INTO acc_amount_, par_curr_amount_;
   CLOSE get_amount_;
END Get_Balance_Voucher_All___;


-- Validate_Voucher_In_Balance___
--   Method that validates the balance of a voucher in accounting currency and parallel currency
--   Input parameters:    Voucher key columns
--   Bung 108417 Begin
--   Bung 108417 End
PROCEDURE Validate_Voucher_In_Balance___(
   company_          VARCHAR2,
   voucher_type_     VARCHAR2,
   accounting_year_  NUMBER,
   voucher_no_       NUMBER)
IS
   acc_balance_       NUMBER;
   par_curr_balance_  NUMBER;
BEGIN
   Get_Balance_Voucher_All___(acc_balance_,
                              par_curr_balance_,
                              company_,
                              voucher_type_,
                              accounting_year_,
                              voucher_no_);

   IF (acc_balance_ != 0) THEN
      Error_Sys.Record_General( 'Voucher', 'VOUNOTBALANCED: The Voucher :P1 is Not Balanced', voucher_no_ );
   END IF;  

   IF (par_curr_balance_ != 0) THEN
      Error_Sys.Record_General( 'Voucher', 'VOUNOTBALANCEDPAR: The Voucher :P1 is Not Balanced in parallel currency', voucher_no_ );
   END IF;  
END Validate_Voucher_In_Balance___;


PROCEDURE Finalize_Interim_Voucher___ (
   final_voucher_no_       OUT NUMBER,
   company_                IN  VARCHAR2,
   voucher_type_           IN  VARCHAR2,
   transfer_id_            IN  VARCHAR2 )
IS
   key_rec_                Voucher_Util_Pub_API.PublicKeyRec;
   automatic_              VARCHAR2(1);
BEGIN
   automatic_        := Voucher_Type_API.Check_Automatic(company_, voucher_type_);
   final_voucher_no_ := -111;
   IF (automatic_ = 'Y') THEN
      Complete_Voucher__ ( key_rec_        ,
                           transfer_id_    ,
                           company_        ,
                           voucher_type_   ,
                           automatic_      ,
                           FALSE           ,
                           TRUE );

      final_voucher_no_ := key_rec_.voucher_no;
   END IF;
END Finalize_Interim_Voucher___;


@Override
PROCEDURE Get_Id_Version_By_Keys___ (
   objid_           IN OUT VARCHAR2,
   objversion_      IN OUT VARCHAR2,
   company_         IN VARCHAR2,
   accounting_year_ IN NUMBER,
   voucher_type_    IN VARCHAR2,
   voucher_no_      IN NUMBER)
IS
BEGIN
   super(objid_, objversion_, company_, accounting_year_, voucher_type_, voucher_no_);
   IF (objid_ IS NULL OR objversion_ IS NULL) THEN
      Error_SYS.Record_Removed(lu_name_);
   END IF;   
END Get_Id_Version_By_Keys___;


@Override
PROCEDURE Finite_State_Machine___ (
   rec_                  IN OUT VOUCHER_TAB%ROWTYPE,
   event_                IN     VARCHAR2,
   attr_  IN OUT VARCHAR2 )
IS
   state_            VARCHAR2(30);
   object_conn_handling_ VARCHAR2(30);
   insert_state_ VARCHAR2(30);

   proj_conn_created_     VARCHAR2(5);
   tmp_obj_conn_handling_ VARCHAR2(20);

   CURSOR get_proj_conn_created IS
      SELECT proj_conn_created
      FROM voucher_tab
      WHERE company         = rec_.company
      AND   accounting_year = rec_.accounting_year
      AND   voucher_type    = rec_.voucher_type
      AND   voucher_no      = rec_.voucher_no;
   
BEGIN
   state_ := rec_.rowstate;
   super(rec_, event_, attr_);
   IF ((state_ IS NULL) AND (event_ IS NULL)) THEN
      insert_state_ := Client_SYS.Cut_Item_Value('INSERT_STATE', attr_);
      Finite_State_Set___(rec_, insert_state_);
   END IF;      
   object_conn_handling_ := Client_SYS.Cut_Item_Value('OBJECT_CONN_HANDLE', attr_);
   IF ((state_ = 'AwaitingApproval' AND ((rec_.rowstate IN ('Cancelled', 'Waiting', 'Confirmed')) OR Awaiting_Ok___(rec_ ))) OR
   (state_ = 'Confirmed' AND (rec_.rowstate IN ('Waiting', 'AwaitingApproval', 'Error'))) OR
   (state_ = 'Error' AND (rec_.rowstate IN ('Waiting', 'Confirmed'))) OR
   (state_ = 'Waiting' AND (rec_.rowstate IN ('Cancelled','AwaitingApproval','Confirmed')))) THEN
      tmp_obj_conn_handling_ := object_conn_handling_;
      IF (state_ = 'Confirmed' AND object_conn_handling_ IS NULL ) THEN
        OPEN get_proj_conn_created;
        FETCH get_proj_conn_created INTO proj_conn_created_;
        CLOSE get_proj_conn_created;

         IF (NVL(proj_conn_created_,'TRUE') = 'FALSE')  THEN
            tmp_obj_conn_handling_ := 'CREATE';
            UPDATE voucher_tab
               SET proj_conn_created = 'TRUE'	          
               WHERE company         = rec_.company
               AND   accounting_year = rec_.accounting_year
               AND   voucher_type    = rec_.voucher_type
               AND   voucher_no      = rec_.voucher_no;
         END IF;
      END IF;

      Object_Conn_Handler___(rec_ ,  tmp_obj_conn_handling_);
   END IF;
END Finite_State_Machine___;


@Override
PROCEDURE Prepare_Insert___ (
   attr_ IN OUT VARCHAR2 )
IS
   company_            VARCHAR2(20);
   voucher_date_       DATE;
   user_id_            VARCHAR2(30);
   user_group_         user_group_member_finance_tab.user_group%type;
   voucher_type_       VARCHAR2(3);
   desc_voucher_type_  VARCHAR2(2000);
   currency_type_      VARCHAR2(10);
   currency_code_      VARCHAR2(3);
   automatic_          VARCHAR2(1);
   accounting_year_    NUMBER;
   accounting_period_  NUMBER;
BEGIN
   company_ := Client_SYS.Get_Item_Value('COMPANY', attr_);
   voucher_date_ := Client_SYS.Get_Item_Value_To_Date('VOUCHER_DATE', attr_, lu_name_);
   super(attr_);
   user_id_ := substr(User_Finance_API.User_Id, 1, 30);
   User_Group_Member_Finance_API.Get_User_Group (user_group_,
                                                 company_,
                                                 user_id_);
   User_Group_Period_API.Get_Period (accounting_year_,
                                     accounting_period_,
                                     company_, user_group_,
                                     voucher_date_);
   Voucher_Type_User_Group_API.Get_Default_Voucher_Type (voucher_type_,
                                                         company_,
                                                         user_group_,
                                                         accounting_year_,
                                                         'M');
   desc_voucher_type_ := Voucher_Type_API.Get_Description (company_,
                                                           voucher_type_);
   automatic_ := Voucher_Type_API.Check_Automatic (company_,
                                                   voucher_type_);
   currency_code_ := substr(Company_Finance_API.Get_Currency_Code(company_), 1, 3);

   IF (Currency_Code_Api.Get_Valid_Emu(company_, currency_code_, voucher_date_) = 'TRUE') AND (TO_CHAR( voucher_date_, 'YYYY-MM-DD' ) >= '1999-01-01') THEN
      currency_type_ := substr(Currency_Type_API.Get_Default_Euro_Type__(company_), 1, 10);
   ELSE
      currency_type_ := substr(Currency_Type_API.Get_Default_Type(company_), 1, 10);
   END IF;
   Currency_Rate_API.Check_If_Curr_Code_Exists (company_,
                                                currency_type_,
                                                currency_code_ );

   Client_SYS.Add_To_Attr( 'USERID', user_id_, attr_ );
   Client_SYS.Add_To_Attr( 'USER_GROUP', user_group_, attr_ );
   Client_SYS.Add_To_Attr( 'VOUCHER_DATE', voucher_date_, attr_ );
   Client_SYS.Add_To_Attr( 'VOUCHER_TYPE', voucher_type_, attr_ );
   Client_SYS.Add_To_Attr( 'DESC_VOUCHER_TYPE', desc_voucher_type_, attr_ );
   Client_SYS.Add_To_Attr( 'VOUCHER_NO', 0, attr_ );
   Client_SYS.Add_To_Attr( 'AUTOMATIC', automatic_, attr_ );
   Client_SYS.Add_To_Attr( 'DATE_REG', SYSDATE, attr_ );
   Client_SYS.Add_To_Attr( 'ACCOUNTING_YEAR', accounting_year_, attr_ );
   Client_SYS.Add_To_Attr( 'ACCOUNTING_PERIOD', accounting_period_, attr_ );
   Client_SYS.Add_To_Attr( 'CURRENCY_TYPE', currency_type_, attr_ );
   Client_SYS.Add_To_Attr( 'CURRENCY_CODE', currency_code_, attr_ );
   
   Client_SYS.Add_To_Attr( 'ENTERED_BY_USER_GROUP', user_group_, attr_ );
   Client_SYS.Add_To_Attr( 'USE_CORRECTION_ROWS', 'FALSE', attr_ );

   IF Authorize_Level_API.Encode(Voucher_Type_User_Group_API.Get_Authorize_Level(company_,accounting_year_, user_group_ ,voucher_type_))= 'Approved' THEN
      Client_SYS.Add_To_Attr( 'VOUCHER_STATUS', Voucher_Status_API.Decode('Confirmed'), attr_ );
   ELSE
      Client_SYS.Add_To_Attr( 'VOUCHER_STATUS', Voucher_Status_API.Decode('AwaitingApproval'), attr_ );
   END IF;
   Client_SYS.Add_To_Attr( 'AMOUNT_METHOD', Def_Amount_Method_API.Decode(Company_Finance_API.Get_Def_Amount_Method_Db(company_)), attr_ );
END Prepare_Insert___;


@Override
PROCEDURE Insert___ (
   objid_      OUT    VARCHAR2,
   objversion_ OUT    VARCHAR2,
   newrec_     IN OUT VOUCHER_TAB%ROWTYPE,
   attr_       IN OUT VARCHAR2 )
IS
   automatic_voucher_ VARCHAR2(20);
   automatic_  VARCHAR2(1);
BEGIN
   -- pre insert
   automatic_voucher_ := Client_SYS.Cut_Item_Value('AUTOMATIC_VOUCHER', attr_);
   IF (automatic_voucher_ = 'AUTOMATIC') THEN
      automatic_ := Voucher_Type_API.Check_Automatic(newrec_.company, newrec_.voucher_type);
      IF ( automatic_ = 'Y' ) THEN
         IF (newrec_.voucher_no = 0) THEN
            newrec_.voucher_no     := Get_Fictive_Voucher_No___;
            newrec_.transfer_id    := Fetch_Transfer_Id___ (newrec_.company         ,
                                                            newrec_.accounting_year ,
                                                            newrec_.voucher_type    ,
                                                            newrec_.voucher_no       );
         ELSE
            Error_Sys.Record_General(lu_name_,'NOTMANUAL: Voucher Number should be assigned automatically');
         END IF;
      ELSE
         Voucher_No_Serial_API.Check_Voucher_No(newrec_.company,
                                                newrec_.voucher_date,
                                                newrec_.voucher_type,
                                                newrec_.voucher_no,
                                                newrec_.accounting_year,
                                                newrec_.accounting_period);
      END IF;         
   END IF;
   
   IF (Company_API.Get_Template_Company(newrec_.company) = 'TRUE') THEN
      Error_SYS.Appl_General(lu_name_, 'TEMPLATECOMP: Company :P1 is a Template Company and cannot create vouchers', newrec_.company);
   END IF;
   Check_Voucher_Exist___(newrec_);   
   IF (Authorize_Level_API.Encode(Voucher_Type_User_Group_Api.Get_Authorize_Level( newrec_.company,
                                                                                   newrec_.accounting_year,
                                                                                   newrec_.user_group,
                                                                                   newrec_.voucher_type )) = 'Approved' ) THEN
      IF (newrec_.revenue_cost_clear_voucher = 'TRUE' AND newrec_.function_group = 'M') THEN
         Client_SYS.Add_To_Attr('INSERT_STATE', 'Confirmed', attr_);
         newrec_.approval_date          := SYSDATE;
         newrec_.approved_by_userid     := newrec_.userid;
         newrec_.approved_by_user_group := newrec_.user_group;
      ELSE
         Client_SYS.Add_To_Attr('INSERT_STATE', 'Waiting', attr_);
	  END IF;
   ELSE
      Client_SYS.Add_To_Attr('INSERT_STATE', 'AwaitingApproval', attr_);
   END IF;
   
   IF (newrec_.function_group IN ('M','K','Q', 'R')) THEN
      newrec_.proj_conn_created := 'TRUE';
   ELSE
	   newrec_.proj_conn_created := 'FALSE';
   END IF;
   
   newrec_.voucher_date := TRUNC(newrec_.voucher_date);
   newrec_.interim_voucher := NVL(newrec_.interim_voucher,'N');
   newrec_.voucher_updated := NVL(newrec_.voucher_updated,'N');
   
   super(objid_, objversion_, newrec_, attr_);
-- post insert
   Client_SYS.Add_To_Attr('VOUCHER_NO', newrec_.voucher_no, attr_ );
   Client_SYS.Add_To_Attr('ENTERED_BY_USER_GROUP', newrec_.entered_by_user_group, attr_);
   Client_SYS.Add_To_Attr('APPROVAL_DATE', newrec_.approval_date, attr_);
   Client_SYS.Add_To_Attr('APPROVED_BY_USERID', newrec_.approved_by_userid, attr_);
   Client_SYS.Add_To_Attr('APPROVED_BY_USER_GROUP', newrec_.approved_by_user_group, attr_);
   Client_SYS.Add_To_Attr('TRANSFER_ID', newrec_.transfer_id, attr_);
   Client_SYS.Add_To_Attr('VOUCHER_NO_REFERENCE', newrec_.voucher_no_reference, attr_);
EXCEPTION
   WHEN dup_val_on_index THEN
      Error_SYS.Record_Exist(lu_name_);
END Insert___;


@Override
PROCEDURE Update___ (
   objid_      IN     VARCHAR2,
   oldrec_     IN     VOUCHER_TAB%ROWTYPE,
   newrec_     IN OUT VOUCHER_TAB%ROWTYPE,
   attr_       IN OUT VARCHAR2,
   objversion_ IN OUT VARCHAR2,
   by_keys_    IN BOOLEAN DEFAULT FALSE )
IS
   info_       VARCHAR2(2000);
BEGIN
   -- pre update
   IF (Company_API.Get_Template_Company(newrec_.company) = 'TRUE') THEN
      Error_SYS.Appl_General(lu_name_, 'TEMPLATECOMP: Company :P1 is a Template Company and cannot create vouchers', newrec_.company);
   END IF;
   
   IF (Client_SYS.Cut_Item_Value('UPDATE_ERROR_TAG', attr_) = 'UPDATE_ERROR_NULL') THEN
      newrec_.update_error := NULL;
   END IF;   
  
   super(objid_, oldrec_, newrec_, attr_, objversion_, by_keys_);
   IF (oldrec_.accounting_period != newrec_.accounting_period) THEN
      Voucher_Row_Api.Set_Accounting_Period_(
            newrec_.company,
            newrec_.accounting_year,
            newrec_.voucher_type,
            newrec_.voucher_no,
            newrec_.accounting_period );
   END IF; 

    $IF Component_Fixass_SYS.INSTALLED $THEN
       IF ((newrec_.rowstate = 'Confirmed') AND 
          (Check_Negative_Amount(newrec_.company, 
                                 newrec_.voucher_type, 
                                 newrec_.accounting_year, 
                                 newrec_.voucher_no) = 'TRUE')) THEN
          info_ := Language_SYS.Translate_Constant (lu_name_, 'NEGATIVEAMOUNT: The net book value will be negative for at least one book.');
          Client_SYS.Add_Info (lu_name_, info_);
       END IF; 
   $END
   
EXCEPTION
   WHEN dup_val_on_index THEN
      Error_SYS.Record_Exist(lu_name_);
END Update___;


@Override
PROCEDURE Delete___ (
   objid_  IN VARCHAR2,
   remrec_ IN VOUCHER_TAB%ROWTYPE )
IS
BEGIN
   super(objid_, remrec_);

-- For Simulation vouchers
   Remove_Connected_Vouchers_ ( remrec_.company,
                                remrec_.accounting_year,
                                remrec_.voucher_type,
                                remrec_.voucher_no);
END Delete___;


PROCEDURE Validate_Voucher___ (
   newrec_ IN VOUCHER_TAB%ROWTYPE )
IS
   current_user_id_  VOUCHER_TAB.Userid%TYPE;
BEGIN
   User_Group_Period_API.Is_Period_Open (newrec_.company,
                                         newrec_.accounting_year,
                                         newrec_.accounting_period,
                                         newrec_.user_group );
   current_user_id_ := User_Finance_API.User_Id;
   User_Group_Member_Finance_API.Exist (newrec_.company,
                                        newrec_.user_group,
                                        current_user_id_ );

   Voucher_Type_User_Group_API.Validate_Voucher_Type (newrec_.company,
                                                      newrec_.voucher_type,
                                                      newrec_.function_group,
                                                      newrec_.accounting_year,
                                                      newrec_.user_group);
END Validate_Voucher___;

@Override
PROCEDURE Unpack___ (
   newrec_   IN OUT NOCOPY voucher_tab%ROWTYPE,
   indrec_   IN OUT NOCOPY Indicator_Rec,
   attr_     IN OUT NOCOPY VARCHAR2 )
IS
   acc_year_ NUMBER;
   acc_period_ NUMBER;
BEGIN
   -- pre unpack
   IF (newrec_.accounting_year IS NOT NULL) THEN
      IF (Client_SYS.Item_Exist('ACCOUNTING_YEAR', attr_)) THEN
         acc_year_ := Client_SYS.Cut_Item_Value('ACCOUNTING_YEAR', attr_);
         IF (newrec_.accounting_year != acc_year_) THEN
            Error_SYS.Item_Update(lu_name_, 'ACCOUNTING_YEAR');
         END IF;
      END IF;
   END IF;
   
   IF (newrec_.accounting_period IS NOT NULL) THEN
      IF (Client_SYS.Item_Exist('ACCOUNTING_PERIOD', attr_)) THEN
         acc_period_ := Client_SYS.Cut_Item_Value('ACCOUNTING_PERIOD', attr_);
         IF (newrec_.accounting_period != acc_period_) THEN
            IF (Company_Finance_API.Get_Use_Vou_No_Period(newrec_.company) = 'TRUE') THEN
               Error_SYS.Item_Update(lu_name_, 'ACCOUNTING_PERIOD');
            END IF;
            newrec_.accounting_period := acc_period_;
            indrec_.accounting_period := TRUE;
         END IF;   
      END IF;
   END IF;   

   IF (Client_SYS.Item_Exist('VOUCHER_STATUS_CONFIRMED', attr_)) THEN
      Error_SYS.Item_Update(lu_name_, 'VOUCHER_STATUS_CONFIRMED');
      attr_ := Client_SYS.Remove_Attr('VOUCHER_STATUS_CONFIRMED', attr_);
   END IF;

   IF (newrec_.entered_by_user_group IS NOT NULL) THEN
      IF (Client_SYS.Item_Exist('ENTERED_BY_USER_GROUP', attr_)) THEN
         IF (newrec_.userid = User_Finance_API.User_Id) THEN
            newrec_.entered_by_user_group := Client_SYS.Cut_Item_Value('ENTERED_BY_USER_GROUP', attr_);         
            indrec_.entered_by_user_group := TRUE;
         END IF;
      END IF;   
   END IF;
   
   IF (newrec_.voucher_text2 IS NOT NULL) THEN
      IF (Client_SYS.Item_Exist('VOUCHER_TEXT2', attr_)) THEN
         IF (newrec_.rowstate = 'Error') THEN
            Error_SYS.Appl_General(lu_name_, 'ERRNOTALLVOU: Status Error is not allowed for new voucher entry ');
         END IF;
      END IF;   
   END IF;
   
   IF (Client_SYS.Item_Exist('VOUCHER_DATE', attr_)) THEN
      newrec_.voucher_date := TRUNC(Client_SYS.Attr_Value_To_Date(Client_SYS.Cut_Item_Value('VOUCHER_DATE', attr_)));
      indrec_.voucher_date := TRUE;
   END IF;  
   IF (Client_SYS.Item_Exist('DATE_REG', attr_)) THEN
      newrec_.date_reg := TRUNC(Client_SYS.Attr_Value_To_Date(Client_SYS.Cut_Item_Value('DATE_REG', attr_)));
      indrec_.date_reg := TRUE;
   END IF;   
   attr_:= Client_SYS.Remove_Attr('DESC_VOUCHER_TYPE',attr_);   
   super(newrec_, indrec_, attr_);

   -- post unpack
   IF (newrec_.voucher_updated IS NULL) THEN
      newrec_.voucher_updated := 'N';
      indrec_.voucher_updated := TRUE;
   END IF;   
  
END Unpack___;   


@Override
PROCEDURE Check_Common___ (
   oldrec_ IN     voucher_tab%ROWTYPE,
   newrec_ IN OUT voucher_tab%ROWTYPE,
   indrec_ IN OUT Indicator_Rec,
   attr_   IN OUT VARCHAR2 )
IS
BEGIN
   IF (newrec_.simulation_voucher IS NULL) THEN
      newrec_.simulation_voucher := Voucher_Type_API.Get_Simulation_Voucher(newrec_.company,
                                                                            newrec_.voucher_type);
   END IF;
   
   User_Group_Period_API.Is_Period_Open (newrec_.company,
                                         newrec_.accounting_year,
                                         newrec_.accounting_period,
                                         newrec_.user_group );  
                                         
                                       
   super(oldrec_, newrec_, indrec_, attr_);

   IF (newrec_.function_group IS NULL) THEN
      newrec_.function_group := Voucher_Type_Detail_API.Get_Function_Group(newrec_.company,
                                                                           newrec_.voucher_type);
   END IF;

   IF (Company_API.Get_Template_Company(newrec_.company) = 'TRUE') THEN
      Error_SYS.Appl_General(lu_name_, 'TEMPLATECOMP: Company :P1 is a Template Company and cannot create vouchers', newrec_.company);
   END IF;

   -- No check if it is a multi company voucher
   IF (newrec_.multi_company_id IS NULL) THEN
      IF (newrec_.function_group IN ('K', 'M', 'Q')) THEN
         Error_SYS.Check_Not_Null(lu_name_, 'AMOUNT_METHOD', newrec_.amount_method);
      END IF;
   END IF;
END Check_Common___;


@Override
PROCEDURE Check_Insert___ (
   newrec_ IN OUT voucher_tab%ROWTYPE,
   indrec_ IN OUT Indicator_Rec,
   attr_   IN OUT VARCHAR2 )
IS
   name_  VARCHAR2(30);
   value_ VARCHAR2(4000);
   voucher_status_   VARCHAR2(200);
   voucher_status_db_   VARCHAR2(200);      
BEGIN
                                        
   super(newrec_, indrec_, attr_);

   IF (Client_SYS.Item_Exist('VOUCHER_STATUS',attr_)) THEN
      voucher_status_db_ := Client_SYS.Cut_Item_Value('VOUCHER_STATUS',attr_);
      voucher_status_ := Voucher_Status_API.Encode(voucher_status_db_);
      IF (voucher_status_db_ IS NOT NULL) THEN
         Voucher_Status_API.Exist(voucher_status_db_);
      END IF;
      IF (voucher_status_ = 'Error') THEN
         Error_SYS.Appl_General(lu_name_, 'ERRNOTALLVOU: Status Error is not allowed for new voucher entry ');
      END IF;    
   END IF;
   
   -- I put this because there is a problem with some client use db value and the
   -- other use client value
   IF (Voucher_Interim_API.Get_Client_Value(0) = newrec_.interim_voucher) OR (Voucher_Interim_API.Get_Client_Value(1) = newrec_.interim_voucher) THEN
     newrec_.interim_voucher := Voucher_Interim_API.Encode(newrec_.interim_voucher);
   END IF;
   
   IF Authorize_Level_API.Encode(Voucher_Type_User_Group_API.Get_Authorize_Level(newrec_.company,newrec_.accounting_year, newrec_.user_group ,newrec_.voucher_type))= 'ApproveOnly' THEN
      Error_SYS.Appl_General(lu_name_, 'APPROVEONLYVOUENTRY: Users included in a user group with :P1 authorization level are not allowed to enter or modify vouchers', Authorize_Level_API.Decode('ApproveOnly'));
   END IF;
   Voucher_Type_API.Validate_Vou_Type_All_Gen (newrec_.company, newrec_.voucher_type);
   
   IF (newrec_.revenue_cost_clear_voucher IS NULL) THEN
      newrec_.revenue_cost_clear_voucher := 'FALSE';
   END IF;   
   
   newrec_.voucher_date := TRUNC(newrec_.voucher_date);
   newrec_.date_reg := TRUNC(newrec_.date_reg);

   newrec_.entered_by_user_group := newrec_.user_group;
   IF (voucher_status_ = 'Confirmed') THEN
      newrec_.approval_date := SYSDATE;
      newrec_.approved_by_userid := newrec_.userid;
      newrec_.approved_by_user_group := newrec_.user_group;
   ELSE
      newrec_.approval_date := NULL;
      newrec_.approved_by_userid := NULL;
      newrec_.approved_by_user_group := NULL;
   END IF;

   Validate_At_New___ (FALSE,newrec_);
EXCEPTION
   WHEN value_error THEN
      Error_SYS.Item_Format(lu_name_, name_, value_);
END Check_Insert___;


@Override
PROCEDURE Check_Update___ (
   oldrec_ IN     voucher_tab%ROWTYPE,
   newrec_ IN OUT voucher_tab%ROWTYPE,
   indrec_ IN OUT Indicator_Rec,
   attr_   IN OUT VARCHAR2 )
IS
   name_                         VARCHAR2(30);
   value_ VARCHAR2(4000);
   --oldrec_                       VOUCHER_TAB%ROWTYPE := newrec_;
   voucher_status_               VARCHAR2(200) := newrec_.rowstate;
   voucher_status_db_            VARCHAR2(200);   
   current_user_id_              VOUCHER_TAB.Userid%TYPE;
   vou_row_rec_                  voucher_row_tab%ROWTYPE;
   from_multi_company_           VARCHAR2(5);
   voucher_status_only_          VARCHAR2(5):= 'TRUE';
BEGIN
                                        
   super(oldrec_, newrec_, indrec_, attr_);
   
   -- post check update
   IF (Client_SYS.Item_Exist('VOUCHER_STATUS',attr_)) THEN
      voucher_status_db_ := Client_SYS.Cut_Item_Value('VOUCHER_STATUS',attr_);
      voucher_status_:=Voucher_Status_API.Encode(voucher_status_db_);
      IF (voucher_status_db_ IS NOT NULL) THEN
             Voucher_Status_API.Exist(voucher_status_db_);
      END IF;
      IF (voucher_status_='Error') THEN
            Error_SYS.Appl_General(lu_name_, 'ERRNOTALLVOU: Status Error is not allowed for new voucher entry ');
      END IF;    
   END IF;   
      
   IF (Client_SYS.Item_Exist('FROM_MULTI_COMPANY', attr_)) THEN
      from_multi_company_ := Client_SYS.Cut_Item_Value('FROM_MULTI_COMPANY', attr_);
      voucher_status_only_ := 'FALSE';
   END IF;
   
   IF (indrec_.entered_by_user_group AND oldrec_.entered_by_user_group != newrec_.entered_by_user_group) THEN
      voucher_status_only_ := 'FALSE';
   END IF;
   
   IF (indrec_.function_group AND oldrec_.function_group != newrec_.function_group) THEN
      voucher_status_only_ := 'FALSE';
   END IF;   
   
   IF (indrec_.amount_method AND oldrec_.amount_method != newrec_.amount_method) THEN
      voucher_status_only_ := 'FALSE';
   END IF;   
   
   
   IF (indrec_.accounting_period OR indrec_.date_reg OR indrec_.userid OR
       indrec_.accounting_text_id OR indrec_.voucher_text OR indrec_.internal_seq_number OR
       indrec_.transfer_id OR indrec_.interim_voucher OR indrec_.voucher_type_reference OR
       indrec_.accounting_year_reference OR indrec_.voucher_no_reference OR indrec_.multi_company_id OR
       indrec_.approval_date OR indrec_.approved_by_userid OR indrec_.approved_by_user_group OR
       indrec_.voucher_text2 OR indrec_.revenue_cost_clear_voucher OR indrec_.simulation_voucher OR 
       indrec_.use_correction_rows) THEN
      voucher_status_only_ := 'FALSE';
   END IF;
   
   IF (oldrec_.voucher_date != newrec_.voucher_date) THEN
       voucher_status_only_ := 'FALSE';
      IF (newrec_.function_group NOT IN ('K', 'M', 'Q')) THEN
         IF NOT (newrec_.function_group = 'D' AND NVL(from_multi_company_,'FALSE')='TRUE') THEN
            Error_SYS.Appl_General(lu_name_, 'NOMODVOUDATE: Voucher date cannot be modified for automatically created vouchers');
         END IF;
      ELSE
         vou_row_rec_:= Voucher_Row_API.Get_Row (newrec_.company         ,
                                                 newrec_.voucher_type    ,
                                                 newrec_.accounting_year ,
                                                 newrec_.voucher_no      ,
                                                 1                      );
         IF vou_row_rec_.auto_tax_vou_entry='EXT' THEN
            Error_SYS.Appl_General(lu_name_, 'NOMODVOUDATE: Voucher date cannot be modified for automatically created vouchers');
         END IF;
      END IF;
   END IF;
   IF ( oldrec_.user_group != newrec_.user_group) THEN
      -- Bug 109556, Begin - Added the IF condition
      IF  NOT ( newrec_.function_group = 'R' AND newrec_.rowstate IN ('Waiting', 'AwaitingApproval','Error') AND voucher_status_ = 'Confirmed' AND voucher_status_only_ = 'TRUE') THEN
         voucher_status_only_ := 'FALSE';
      END IF;
      -- Bug 109556, End
      IF NOT((newrec_.rowstate IN ('Waiting', 'AwaitingApproval', 'Error')) AND voucher_status_ = 'Confirmed') THEN
         IF (newrec_.function_group NOT IN ('K', 'M', 'Q')) THEN
            Error_SYS.Appl_General(lu_name_, 'NOMODUSRGRP: User group cannot be modified for automatically created vouchers');
         END IF;
      END IF;
   END IF;

   -- Bug 109556, Begin - Added the IF condition to allow status changes from AwaitingAprroval -> Approved and Not Approved -> Approved for interim voucher('R') 
   IF ( newrec_.interim_voucher = 'Y' AND NOT ((newrec_.function_group = 'R' AND newrec_.rowstate IN ('Waiting', 'AwaitingApproval','Error') AND voucher_status_ = 'Confirmed' AND voucher_status_only_ = 'TRUE')
         OR (newrec_.interim_voucher= 'Y' AND newrec_.rowstate = 'Error' AND voucher_status_ = 'Confirmed' AND voucher_status_only_ = 'TRUE')
         OR (newrec_.voucher_updated = 'Y' AND voucher_status_only_ = 'TRUE'))) THEN
      Error_SYS.Record_General(lu_name_, 'ISINTERIM: The voucher is connected to an interim voucher and cannot be changed');
   END IF;
   -- Bug 109556, End

   Error_SYS.Check_Not_Null(lu_name_, 'VOUCHER_UPDATED', newrec_.voucher_updated);
   Error_SYS.Check_Not_Null(lu_name_, 'VOUCHER_STATUS', newrec_.rowstate);

   IF (voucher_status_ = 'Confirmed') THEN
      current_user_id_ := User_Finance_API.User_Id;
      newrec_.approval_date := SYSDATE;
      newrec_.approved_by_userid := current_user_id_;
      newrec_.approved_by_user_group := newrec_.user_group;
   ELSE
      newrec_.approval_date := NULL;
      newrec_.approved_by_userid := NULL;
      newrec_.approved_by_user_group := NULL;
   END IF;  
   
   IF (indrec_.user_group) THEN
      Validate_At_Modify___(newrec_, oldrec_);
   END IF;
   
   Client_SYS.Add_To_Attr('ENTERED_BY_USER_GROUP', newrec_.entered_by_user_group, attr_);
   Client_SYS.Add_To_Attr('APPROVAL_DATE', newrec_.approval_date, attr_);
   Client_SYS.Add_To_Attr('APPROVED_BY_USERID', newrec_.approved_by_userid, attr_);
   Client_SYS.Add_To_Attr('APPROVED_BY_USER_GROUP', newrec_.approved_by_user_group, attr_);
EXCEPTION
   WHEN value_error THEN
      Error_SYS.Item_Format(lu_name_, name_, value_);
END Check_Update___;


-- Bug 126851, Begin, Moved outside of the scope of PROCEDURE Complete_Voucher__.
-- Bug 121856, Begin
-- Balance handling method to balance amounts in the voucher for parallel currency for specific function group that does not handle this
-- when creating the voucher. Should not be used as general method to balance a voucher. This should be seen as an exception to how voucher are balanced.
PROCEDURE Balance_Parallel_Diff___ (
   company_            IN  VARCHAR2,
   voucher_type_       IN  VARCHAR2,
   accounting_year_    IN  VARCHAR2,
   voucher_no_         IN  VARCHAR2,
   function_group_     IN  VARCHAR2)
IS
   acc_balance_            NUMBER;
   par_curr_balance_       NUMBER;         
   compfin_rec_            Company_Finance_API.Public_Rec;
   debit_                  BOOLEAN := FALSE;

   -- Find the row with smallest amount (which is still larger than the diff) and sorted on row_no if amounts are equal. 
   CURSOR get_voucher_row IS
      SELECT NVL(r.third_currency_debit_amount,r.third_currency_credit_amount) par_amount, rowid, company, voucher_date, 
            debet_amount, credit_amount,
            currency_debet_amount, currency_credit_amount,
            third_currency_debit_amount, third_currency_credit_amount, currency_code, parallel_currency_rate
      FROM voucher_row_tab r
      WHERE company = company_
      AND voucher_type = voucher_type_
      AND accounting_year = accounting_year_
      AND voucher_no = voucher_no_
      AND NVL(r.third_currency_debit_amount,r.third_currency_credit_amount) > ABS(par_curr_balance_)
      ORDER BY 1 ASC, row_no ASC;
   row_rec_                get_voucher_row%ROWTYPE;
BEGIN
   -- Bug 126851, Begin, Changed the check for functional groups so that every functional group which parallel currency rounding is not handled will be handled here.
   -- Special handling for the below listed function groups (that not make sure to balance the amount in parallel currency
   -- which is not handled from the owner/creator of the voucher).
   IF (function_group_ NOT IN ('0', 'A', 'B', 'C', 'CB', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'M', 'N', 'P', 'PPC', 'Q', 'R', 'U', 'X', 'YE', 'Z')) THEN
      Get_Balance_Voucher_All___(acc_balance_,
                                 par_curr_balance_,
                                 company_,
                                 voucher_type_,
                                 accounting_year_,
                                 voucher_no_);            
      IF (par_curr_balance_ != 0) THEN
         compfin_rec_ := Company_Finance_API.Get(company_);
         OPEN  get_voucher_row;
         FETCH get_voucher_row INTO row_rec_;
         CLOSE get_voucher_row;
         debit_ := FALSE;
         IF (par_curr_balance_ > 0) THEN
            IF (row_rec_.third_currency_debit_amount IS NOT NULL) THEN                  
               row_rec_.third_currency_debit_amount := row_rec_.third_currency_debit_amount - par_curr_balance_;                  
            ELSE
               row_rec_.third_currency_credit_amount := row_rec_.third_currency_credit_amount + par_curr_balance_;                  
            END IF;               
         ELSE
            IF (row_rec_.third_currency_debit_amount IS NOT NULL) THEN                  
               row_rec_.third_currency_debit_amount := row_rec_.third_currency_debit_amount + ABS(par_curr_balance_);                  
            ELSE
               row_rec_.third_currency_credit_amount := row_rec_.third_currency_credit_amount - ABS(par_curr_balance_);                  
            END IF;               
         END IF;
         -- calulate the new rate after updating the amount
         row_rec_.parallel_currency_rate := Currency_Amount_API.Calculate_Parallel_Curr_Rate(row_rec_.company,
                                                                                             row_rec_.voucher_date,
                                                                                             NVL(row_rec_.debet_amount, row_rec_.credit_amount),
                                                                                             NVL(row_rec_.currency_debet_amount, row_rec_.currency_credit_amount),
                                                                                             NVL(row_rec_.third_currency_debit_amount, row_rec_.third_currency_credit_amount),
                                                                                             compfin_rec_.currency_code,
                                                                                             row_rec_.currency_code,
                                                                                             compfin_rec_.parallel_acc_currency,
                                                                                             compfin_rec_.parallel_base,
                                                                                             compfin_rec_.parallel_rate_type);
         UPDATE voucher_row_tab                     
            SET third_currency_debit_amount  = row_rec_.third_currency_debit_amount,
                third_currency_credit_amount = row_rec_.third_currency_credit_amount,
                parallel_currency_rate = row_rec_.parallel_currency_rate
          WHERE rowid = row_rec_.rowid;                        
      END IF;                                          
   END IF;
   -- Bug 126851, End.
END Balance_Parallel_Diff___;
-- Bug 121856, End
-- Bug 126851, End.
-------------------- LU SPECIFIC PRIVATE METHODS ----------------------------

@Override
PROCEDURE New__ (
   info_       OUT    VARCHAR2,
   objid_      OUT    VARCHAR2,
   objversion_ OUT    VARCHAR2,
   attr_       IN OUT VARCHAR2,
   action_     IN     VARCHAR2 )
IS
   newrec_     VOUCHER_TAB%ROWTYPE;
BEGIN
   IF (action_ = 'DO') THEN
      Client_SYS.Add_To_Attr('AUTOMATIC_VOUCHER', 'AUTOMATIC', attr_);
   END IF;   
   super(info_, objid_, objversion_, attr_, action_);
   IF (action_ = 'DO') THEN
      $IF Component_Intled_SYS.INSTALLED $THEN
         newrec_ := Get_Object_By_Id___(objid_);
         IF (Voucher_Type_API.Is_Vou_Type_All_Ledger(newrec_.company, newrec_.voucher_type) = 'TRUE') THEN  
            Internal_Voucher_Util_Pub_API.Create_Internal_Head(newrec_);
         END IF;
      $ELSE
         NULL;
      $END
   END IF;
END New__;


@Override
PROCEDURE Modify__ (
   info_       OUT    VARCHAR2,
   objid_      IN     VARCHAR2,
   objversion_ IN OUT VARCHAR2,
   attr_       IN OUT VARCHAR2,
   action_     IN     VARCHAR2 )
IS
   newrec_ VOUCHER_TAB%ROWTYPE;
BEGIN
   IF (action_ = 'DO') THEN
      Client_SYS.Add_To_Attr('UPDATE_ERROR_TAG', 'UPDATE_ERROR_NULL', attr_);
   END IF;   
   super(info_, objid_, objversion_, attr_, action_);
   IF (action_ = 'DO') THEN
      Update_Intled_Voucher_Head___(newrec_);      
   END IF;      
END Modify__;


PROCEDURE Insert_Voucher_Template__ (
   company_         IN VARCHAR2,
   template_        IN VARCHAR2,
   description_     IN VARCHAR2,
   valid_from_      IN DATE,
   valid_until_     IN DATE,
   accounting_year_ IN NUMBER,
   voucher_type_    IN VARCHAR2,
   voucher_no_      IN NUMBER,
   include_amount_  IN VARCHAR2 )
IS
BEGIN
   Voucher_Template_Api.Insert_Table_(company_ ,
                                      template_ ,
                                      description_ ,
                                      valid_from_ ,
                                      valid_until_ ,
                                      accounting_year_ ,
                                      voucher_type_ ,
                                      voucher_no_ ,
                                      include_amount_);
END Insert_Voucher_Template__;


PROCEDURE Prepare_Allocation__ (
   company_         IN VARCHAR2,
   accounting_year_ IN NUMBER,
   voucher_type_    IN VARCHAR2,
   voucher_no_      IN NUMBER )
IS
   found_ BOOLEAN := FALSE;
   ref_   VARCHAR2(200);
   CURSOR lock_objects IS
      SELECT 1
      FROM   voucher_row_tab b,
             voucher_tab a
      WHERE  b.company         = a.company
      AND    b.accounting_year = a.accounting_year
      AND    b.voucher_type    = a.voucher_type
      AND    b.voucher_no      = a.voucher_no
      AND    a.company         = company_
      AND    a.accounting_year = accounting_year_
      AND    a.voucher_type    = voucher_type_
      AND    a.voucher_no      = voucher_no_
      FOR UPDATE OF b.company, a.company;
BEGIN
   FOR object_ IN lock_objects LOOP
      found_ := TRUE;
   END LOOP;
   IF (NOT found_) THEN
      ref_ := voucher_type_ ||' '|| TO_CHAR(voucher_no_);
      Error_Sys.Record_General(lu_name_, 'NOREFOBJECT: Referenced Voucher [ :P1 ] not found.', ref_ );
   END IF;
END Prepare_Allocation__;


@UncheckedAccess
FUNCTION Get_Reference_Company__ (
   company_         IN VARCHAR2,
   voucher_type_    IN VARCHAR2,
   accounting_year_ IN NUMBER,
   voucher_no_      IN NUMBER ) RETURN VARCHAR2
IS

   CURSOR get_ref_company IS
      SELECT multi_company_id, function_group, interim_voucher, voucher_no_reference
      FROM VOUCHER_TAB
      WHERE company          = company_
      AND   voucher_type     = voucher_type_
      AND   accounting_year  = accounting_year_
      AND   voucher_no       = voucher_no_ ;
   
   function_group_           VOUCHER_TAB.function_group%TYPE;
   ref_company_              VOUCHER_TAB.company%TYPE := NULL;
   voucher_no_reference_     VOUCHER_TAB.voucher_no_reference%TYPE;
   multi_company_id_         VOUCHER_TAB.multi_company_id%TYPE;
   is_interim_voucher_       VOUCHER_TAB.interim_voucher%TYPE;

BEGIN
   OPEN  get_ref_company;
   FETCH get_ref_company INTO multi_company_id_, function_group_, is_interim_voucher_, voucher_no_reference_;
   CLOSE get_ref_company;

   IF (function_group_ IN ('D', 'U', 'B', 'M', 'K', 'Q', 'R', 'X', 'J','N')) THEN
      IF (is_interim_voucher_ = 'Y') THEN
         ref_company_ := company_;
      ELSIF (voucher_no_reference_ IS NOT NULL) THEN
         ref_company_ := NVL(multi_company_id_, company_);
      END IF;
   END IF;

   RETURN ref_company_;
END Get_Reference_Company__;


PROCEDURE Approve_Voucher__ (
   company_         IN VARCHAR2,
   accounting_year_ IN NUMBER,
   voucher_type_    IN VARCHAR2,
   voucher_no_      IN NUMBER,
   user_group_      IN VARCHAR2 )
IS
   rec_                 VOUCHER_TAB%ROWTYPE;
   current_user_id_     VOUCHER_TAB.Userid%TYPE;
   manual_found_        BOOLEAN := FALSE;
   counter_             NUMBER := 0;

   CURSOR get_vourow IS
      SELECT DISTINCT company, account, voucher_date
      FROM   voucher_row_tab
      WHERE  company          = company_
      AND    accounting_year  = accounting_year_
      AND    voucher_type     = voucher_type_
      AND    voucher_no       = voucher_no_;
BEGIN
   rec_ := Lock_By_Keys___(company_, accounting_year_, voucher_type_, voucher_no_);
   rec_.user_group := user_group_ ;

   $IF Component_Intled_SYS.INSTALLED $THEN
      IF (Voucher_Type_API.Get_Use_Manual(company_, voucher_type_) = 'TRUE') THEN
         FOR vourec_ IN get_vourow LOOP
            counter_ := counter_ + 1; 
            manual_found_ := (manual_found_ OR
                              (Int_Posting_Method_API.Check_If_Manual(vourec_.company,
                                                                      vourec_.account,
                                                                      vourec_.voucher_date) IS NOT NULL));
            IF manual_found_ THEN
              EXIT;
            END IF;                                                                 
         END LOOP;
      END IF;
   $END

   IF NOT ( manual_found_) THEN

      IF (Confirmed_Allow_Approve___(rec_, counter_)) THEN

         Check_Refer_Mandatory__( company_,accounting_year_, voucher_type_, voucher_no_);
         
         Finite_State_Set___(rec_, 'Confirmed');
         
         current_user_id_            := User_Finance_API.User_Id;
         rec_.approved_by_user_group := user_group_;

         UPDATE voucher_tab
            SET approval_date           = SYSDATE,
                approved_by_userid      = current_user_id_,
                approved_by_user_group  = rec_.approved_by_user_group
            WHERE company           = rec_.company
            AND   accounting_year   = rec_.accounting_year
            AND   voucher_type      = rec_.voucher_type
            AND   voucher_no        = rec_.voucher_no;
      END IF;
   ELSE

      Client_SYS.clear_Info;
      Client_SYS.Add_Info(lu_name_, 'NO: N');
   END IF;
END Approve_Voucher__;


PROCEDURE Create_Voucher_Head__ (
   transfer_id_         OUT VARCHAR2,
   company_             IN  VARCHAR2,
   voucher_date_        IN  DATE,
   user_group_          IN  VARCHAR2,
   voucher_type_        IN  VARCHAR2,
   voucher_no_          IN  NUMBER,
   voucher_type_ref_    IN  VARCHAR2 DEFAULT NULL,
   accounting_year_ref_ IN  NUMBER   DEFAULT NULL,
   voucher_no_ref_      IN  NUMBER   DEFAULT NULL,
   multi_company_id_    IN  VARCHAR2 DEFAULT NULL,
   voucher_text_        IN  VARCHAR2 DEFAULT NULL,
   notes_               IN  VARCHAR2 DEFAULT NULL,
   function_group_      IN  VARCHAR2 DEFAULT NULL,
   approval_user_       IN  VARCHAR2 DEFAULT NULL,
   is_from_payment_     IN  VARCHAR2 DEFAULT NULL )
IS
   objid_                  VARCHAR2(2000);
   objversion_             VARCHAR2(2000);
   user_name_              VARCHAR2(30);
   newrec_                 VOUCHER_TAB%ROWTYPE;
   fictive_voucher_no_     NUMBER;
   accounting_year_        NUMBER;
   accounting_period_      NUMBER;
   attr_                   VARCHAR2(2000);
   automatic_              VARCHAR2(1);
   ledger_id_              VARCHAR2(10);
   func_group_             VARCHAR2(10);
   amount_method_          voucher_tab.amount_method%TYPE;

BEGIN
   IF (approval_user_ IS NOT NULL) THEN
      user_name_ := approval_user_;
   ELSE
      user_name_ := User_Finance_API.User_Id;
   END IF;

   ledger_id_ := Voucher_Type_Api.Get_Ledger_Id (company_,
                                                 voucher_type_);
   IF (ledger_id_ IN ('*', '00')) THEN                                                 
      User_Group_Period_API.Get_And_Validate_Period( accounting_year_,
                                                     accounting_period_,
                                                     company_,
                                                     user_group_,
                                                     voucher_date_ );
   ELSE
      User_Group_Period_API.Get_And_Validate_Il_Period( accounting_year_,
                                                        accounting_period_,
                                                        company_,
                                                        user_group_,
                                                        voucher_date_ );
   END IF;                                                  
   
   User_Group_Member_Finance_API.Exist( company_,
                                        user_group_,
                                        user_name_ );
   IF (function_group_ IS NULL) THEN
      func_group_ := Voucher_Type_API.Get_Voucher_Group (company_,
                                                         voucher_type_);
   ELSE
      func_group_ := function_group_;
   END IF;
   IF (func_group_ IN  ('M', 'K', 'Q' )) THEN
      amount_method_ :=  Company_Finance_API.Get_Def_Amount_Method_Db(company_);
   END IF;
   Voucher_Type_User_Group_API.Validate_Voucher_Type(company_,
                                                     voucher_type_,
                                                     func_group_,
                                                     accounting_year_,
                                                     user_group_);


   automatic_ := Voucher_Type_API.Check_Automatic (company_,
                                                   voucher_type_);

   IF ( automatic_ = 'Y' ) THEN
      IF (NVL(voucher_no_,0) = 0) THEN
         fictive_voucher_no_ := Get_Fictive_Voucher_No___;
      ELSE
         Error_Sys.Record_General(lu_name_,'NOTMANUAL: Voucher Number should be assigned automatically');
      END IF;
   ELSE
      Voucher_No_Serial_API.Check_Voucher_No(company_,
                                             voucher_date_,
                                             voucher_type_,
                                             voucher_no_,
                                             accounting_year_,
                                             accounting_period_);
      fictive_voucher_no_ := voucher_no_;
   END IF;

   transfer_id_    := Fetch_Transfer_Id___ (company_         ,
                                            accounting_year_ ,
                                            voucher_type_    ,
                                            fictive_voucher_no_);

   newrec_.company                   := company_;
   newrec_.accounting_year           := accounting_year_;
   newrec_.voucher_type              := voucher_type_;
   newrec_.voucher_no                := fictive_voucher_no_;
   newrec_.voucher_date              := voucher_date_;
   newrec_.user_group                := user_group_;
   newrec_.accounting_period         := accounting_period_;
   newrec_.date_reg                  := sysdate;
   newrec_.userid                    := user_name_;
   newrec_.entered_by_user_group     := user_group_;
   newrec_.transfer_id               := transfer_id_;
   newrec_.voucher_type_reference    := voucher_type_ref_;
   newrec_.accounting_year_reference := accounting_year_ref_;
   newrec_.voucher_no_reference      := voucher_no_ref_;
   newrec_.multi_company_id          := multi_company_id_;
   newrec_.amount_method             := amount_method_;
   IF (NVL(is_from_payment_,'FALSE') = 'TRUE' ) THEN
      newrec_.voucher_text              := notes_;
      newrec_.voucher_text2             := voucher_text_;
   ELSE
      newrec_.voucher_text              := voucher_text_ ;
      newrec_.voucher_text2             := notes_;
   END IF;
   newrec_.function_group            := func_group_;

   Error_SYS.Check_Not_Null(lu_name_, 'COMPANY', newrec_.company);
   Error_SYS.Check_Not_Null(lu_name_, 'ACCOUNTING_YEAR', newrec_.accounting_year);
   Error_SYS.Check_Not_Null(lu_name_, 'VOUCHER_TYPE', newrec_.voucher_type);
   Error_SYS.Check_Not_Null(lu_name_, 'VOUCHER_NO', newrec_.voucher_no);
   Error_SYS.Check_Not_Null(lu_name_, 'VOUCHER_DATE', newrec_.voucher_date);
   Error_SYS.Check_Not_Null(lu_name_, 'DATE_REG', newrec_.date_reg);

   IF (Company_API.Get_Template_Company(newrec_.company) = 'TRUE') THEN
      Error_SYS.Appl_General(lu_name_, 'TEMPLATECOMP: Company :P1 is a Template Company and cannot create vouchers', newrec_.company);
   END IF;
   
   IF (ledger_id_ IN ('*', '00')) THEN
      IF (newrec_.function_group IS NULL) THEN
         newrec_.function_group := Voucher_Type_Detail_API.Get_Function_Group (newrec_.company,
                                                                               newrec_.voucher_type);
      END IF;
      IF (newrec_.simulation_voucher IS NULL) THEN
         newrec_.simulation_voucher := Voucher_Type_API.Get_Simulation_Voucher (newrec_.company,
                                                                                newrec_.voucher_type);
      END IF;
      Insert___(objid_, objversion_, newrec_, attr_);
   END IF;
   $IF Component_Intled_SYS.INSTALLED $THEN
      IF (ledger_id_ NOT IN ('*', '00')) THEN   -- Internal Ledger 
         Internal_Voucher_Util_Pub_API.Create_Head_Internal (newrec_,
                                                             ledger_id_);
      END IF;
   $END
END Create_Voucher_Head__;


PROCEDURE Get_Head_Info__ (
   company_           IN OUT VARCHAR2,
   voucher_type_      IN OUT VARCHAR2,
   accounting_year_   IN OUT NUMBER,
   accounting_period_ IN OUT NUMBER,
   voucher_no_        IN OUT NUMBER,
   voucher_date_      IN OUT DATE,
   transfer_id_       IN     VARCHAR2 )
IS
   CURSOR head_info IS
      SELECT company,
             voucher_type,
             accounting_year,
             accounting_period,
             voucher_no,
             voucher_date
      FROM   VOUCHER_TAB
      WHERE  transfer_id = transfer_id_;
BEGIN
   OPEN  head_info;
   FETCH head_info INTO company_,
                        voucher_type_,
                        accounting_year_,
                        accounting_period_,
                        voucher_no_,
                        voucher_date_;
   CLOSE head_info;
END Get_Head_Info__;


PROCEDURE Validate_Voucher_Date__ (
   accounting_year_    IN OUT NUMBER,
   accounting_period_  IN OUT NUMBER,
   company_            IN     VARCHAR2,
   voucher_date_       IN     DATE,
   user_group_         IN     VARCHAR2)
IS
BEGIN
   Accounting_Period_API.Get_Accounting_Year (accounting_year_,
                                              accounting_period_,
                                              company_,
                                              voucher_date_);
   User_Group_Period_API.Is_Period_Open (company_,
                                         accounting_year_,
                                         accounting_period_,
                                         user_group_);
END Validate_Voucher_Date__;


PROCEDURE Reverse_Voucher__ (
   reversal_voucher_no_   IN OUT NUMBER,
   company_               IN VARCHAR2,
   voucher_no_            IN NUMBER,
   accounting_year_       IN NUMBER,
   voucher_type_          IN VARCHAR2,
   voucher_date_          IN DATE DEFAULT NULL,
   reversal_acc_year_     IN NUMBER DEFAULT NULL,
   reversal_acc_period_   IN NUMBER DEFAULT NULL,
   reversal_user_group_   IN VARCHAR2 DEFAULT NULL,
   reversal_voucher_type_ IN VARCHAR2 DEFAULT NULL,
   rollback_voucher_      IN VARCHAR2 DEFAULT NULL )
IS
   reverse_rec_         VOUCHER_TAB%ROWTYPE;
   old_rec_             VOUCHER_TAB%ROWTYPE;
   new_rec_             VOUCHER_TAB%ROWTYPE;
   next_period_         NUMBER;
   next_year_           NUMBER;
   accounting_period_   NUMBER;
   date_from_           DATE;
   date_until_          DATE;
   automatic_flag_      VARCHAR2(3);
   objid_               VARCHAR2(2000);
   objversion_          VARCHAR2(2000);
   rev_objid_           VARCHAR2(2000);
   rev_objversion_      VARCHAR2(2000);
   attr_                VARCHAR2(2000);
   modattr_             VARCHAR2(2000);
   function_group_      VOUCHER_TAB.function_group%TYPE;
   ledger_id_           VOUCHER_TYPE_TAB.ledger_id%TYPE;
   indrec_              Indicator_Rec;
   authorize_level_     VOUCHER_TYPE_USER_GROUP_TAB.Authorize_Level%TYPE;
BEGIN
   Client_SYS.Clear_Attr(attr_);
   reverse_rec_ := Get_Object_By_Keys___(company_,
                                         accounting_year_,
                                         voucher_type_,
                                         voucher_no_);
   Get_Id_Version_By_Keys___(objid_,
                             objversion_,
                             company_,
                             accounting_year_,
                             voucher_type_,
                             voucher_no_);

   reverse_rec_.voucher_no_reference      := reverse_rec_.voucher_no;
   reverse_rec_.voucher_type_reference    := reverse_rec_.voucher_type;
   reverse_rec_.accounting_year_reference := reverse_rec_.accounting_year;
    
   IF (reversal_voucher_type_ IS NOT NULL) THEN
      reverse_rec_.voucher_type := reversal_voucher_type_;
      Voucher_Type_API.Exist(company_,
                             reversal_voucher_type_);
      Voucher_Type_API.Validate_Vou_Type_All_Gen(company_,
                                                 reversal_voucher_type_);
      reverse_rec_.function_group     := Voucher_Type_Detail_API.Get_Function_Group(company_,
                                                                                    reversal_voucher_type_);
      reverse_rec_.simulation_voucher := Voucher_Type_API.Get_Simulation_Voucher(company_,
                                                                                 reversal_voucher_type_);
   END IF;

   IF (reversal_user_group_ IS NOT NULL) THEN
      reverse_rec_.user_group := reversal_user_group_;
      User_Group_Finance_API.Exist(company_,
                                   reversal_user_group_);
   END IF;


   accounting_period_ := Voucher_API.Get_Accounting_Period(company_,
                                                           voucher_type_,
                                                           accounting_year_,
                                                           voucher_no_);

   Accounting_Period_API.Get_Next_Allowed_Period(next_period_,
                                                 next_year_,
                                                 company_,
                                                 accounting_period_,
                                                 accounting_year_);

   IF(reversal_acc_year_ IS NOT NULL) THEN
      next_year_ := reversal_acc_year_;
   END IF;

   IF(reversal_acc_period_ IS NOT NULL) THEN
      next_period_ := reversal_acc_period_;
   END IF;

   reverse_rec_.date_reg               := SYSDATE;
   reverse_rec_.rowstate               := NULL;
   reverse_rec_.voucher_updated        := 'N';
   reverse_rec_.accounting_year        := next_year_;
   reverse_rec_.accounting_period      := next_period_;
   reverse_rec_.approval_date          := SYSDATE;
   reverse_rec_.entered_by_user_group  := reverse_rec_.user_group;
   reverse_rec_.approved_by_user_group := reverse_rec_.user_group;



   IF(voucher_date_ IS NULL) THEN

      Accounting_Period_API.Get_Period_Date(date_from_,
                                            date_until_,
                                            company_,
                                            next_year_,
                                            next_period_);
      reverse_rec_.voucher_date := date_from_;
   ELSE
      reverse_rec_.voucher_date := voucher_date_;

   END IF;
   ledger_id_ := Voucher_Type_API.Get_Ledger_Id(company_, reverse_rec_.voucher_type );
  
   IF ((ledger_id_ IN ('*','00')) OR (ledger_id_ IS NULL)) THEN
      User_Group_Period_API.Get_And_Validate_Period( next_year_,
                                                     next_period_,
                                                     company_,
                                                     reverse_rec_.user_group,
                                                     reverse_rec_.voucher_date );
   ELSE
      User_Group_Period_API.Get_And_Validate_Il_Period( next_year_,
                                                        next_period_,
                                                        company_,
                                                        reverse_rec_.user_group,
                                                        reverse_rec_.voucher_date );
   END IF;

   automatic_flag_ := Voucher_Type_API.Check_Automatic(company_,
                                                       reverse_rec_.voucher_type);

   IF(automatic_flag_ = 'Y') THEN
      Voucher_No_Serial_API.Get_Next_Voucher_No(reversal_voucher_no_,
                                                company_,
                                                reverse_rec_.voucher_type,
                                                reverse_rec_.voucher_date,
                                                reverse_rec_.accounting_year,
                                                reverse_rec_.accounting_period);
   ELSE
      Voucher_No_Serial_API.Check_Voucher_No(company_,
                                             reverse_rec_.accounting_year,
                                             reverse_rec_.voucher_type,
                                             reversal_voucher_no_);
   END IF;
   
   reverse_rec_.voucher_no := reversal_voucher_no_;
   Client_SYS.Add_To_Attr( 'VOUCHER_STATUS', Voucher_Status_API.Decode('Waiting'), attr_);
   
   Unpack___(reverse_rec_, indrec_, attr_);
   Check_Insert___(reverse_rec_, indrec_, attr_);
   reverse_rec_.rowkey := NULL;
   Insert___(rev_objid_, rev_objversion_, reverse_rec_, attr_);
   Finite_State_Set___(reverse_rec_, 'Waiting'); 

   Client_SYS.Clear_attr(modattr_);

   old_rec_ := Lock_By_keys___(company_,
                               accounting_year_,
                               voucher_type_,
                               voucher_no_);
   new_rec_ := old_rec_;
   new_rec_.voucher_no_reference        := reversal_voucher_no_;
   new_rec_.voucher_type_reference      := reverse_rec_.voucher_type;
   new_rec_.accounting_year_reference   := reverse_rec_.accounting_year;
   Update___(objid_,old_rec_,new_rec_,modattr_,objversion_,FALSE);

   
   $IF Component_Intled_SYS.INSTALLED $THEN

      IF (ledger_id_ = '*') THEN 
         Internal_Voucher_Util_Pub_API.Create_Internal_Head(reverse_rec_);
         ledger_id_ := NULL;
         -- Update the voucher_no ref of the original internal vouchers
         INTERNAL_VOUCHER_UTIL_PUB_API.Set_Reference_Data(company_,
                                                          accounting_year_,
                                                          voucher_no_,
                                                          voucher_type_,
                                                          reverse_rec_.accounting_year,
                                                          reverse_rec_.voucher_no,
                                                          reverse_rec_.voucher_type,
                                                          NULL,
                                                          NULL,
                                                          ledger_id_,
                                                          'TRUE');
      ELSIF (ledger_id_ != '00') THEN
         Internal_Voucher_Util_Pub_API.Create_Head_Internal (reverse_rec_, ledger_id_);
         
         -- Update the voucher_no ref of the original internal vouchers
         INTERNAL_VOUCHER_UTIL_PUB_API.Set_Reference_Data(company_,
                                                          accounting_year_,
                                                          voucher_no_,
                                                          voucher_type_,
                                                          reverse_rec_.accounting_year,
                                                          reverse_rec_.voucher_no,
                                                          reverse_rec_.voucher_type,
                                                          NULL,
                                                          NULL,
                                                          ledger_id_,
                                                          'TRUE');
      END IF;
   $END

   Voucher_Row_API.Reverse_Voucher_Rows__(company_,
                                          voucher_no_,
                                          accounting_year_,
                                          voucher_type_,
                                          reversal_voucher_no_,
                                          reverse_rec_.accounting_year,
                                          reverse_rec_.voucher_type,
                                          rollback_voucher_);
   Client_SYS.Clear_attr(modattr_);
   Get_Id_Version_By_Keys___(objid_,
                             objversion_,
                             company_,
                             reverse_rec_.accounting_year,
                             reverse_rec_.voucher_type,
                             reversal_voucher_no_);


   old_rec_ := Lock_By_keys___(company_,
                               reverse_rec_.accounting_year,
                               reverse_rec_.voucher_type,
                               reversal_voucher_no_);
   new_rec_ := old_rec_;
   new_rec_.approval_date               := SYSDATE;
   new_rec_.approved_by_userid          := reverse_rec_.userid;
   new_rec_.approved_by_user_group      := reverse_rec_.user_group;
   Update___(objid_,old_rec_,new_rec_,modattr_,objversion_,FALSE);                                          
                                          
   authorize_level_ := Authorize_Level_API.Encode
                                (voucher_type_user_group_api.get_authorize_level
                                                            (company_, 
                                                             reverse_rec_.accounting_year,
                                                             reverse_rec_.user_group,
                                                             reverse_rec_.voucher_type));
   IF (authorize_level_ = 'Approved') THEN
       Finite_State_Set___(reverse_rec_, 'Confirmed');
   END IF;
   
   function_group_     := Voucher_Type_Detail_API.Get_Function_Group(company_, voucher_type_); 
   IF function_group_ = 'LI' THEN
      IF  (Voucher_Rows_Exist(company_, reverse_rec_.accounting_year, reversal_voucher_no_, voucher_type_) = 'FALSE') THEN
         Finite_State_Set___(reverse_rec_, 'Cancelled');
      END IF;
   END IF;
END Reverse_Voucher__;


PROCEDURE Validate_Voucher_Type__ (
   automatic_              IN OUT VARCHAR2,
   simulation_voucher_     IN OUT VARCHAR2,
   desc_voucher_type_      IN OUT VARCHAR2,
   company_                IN     VARCHAR2,
   voucher_type_           IN     VARCHAR2,
   user_group_             IN     VARCHAR2,
   accounting_year_        IN     NUMBER )
IS
   function_group_   VARCHAR2(1);
   valid_            VARCHAR2(20);
BEGIN
   simulation_voucher_ := UPPER(SUBSTR(Voucher_Type_API.Get_Simulation_Voucher(company_, voucher_type_), 1, 5));
   function_group_     := UPPER(SUBSTR(Voucher_Type_API.Get_Voucher_Group(company_, voucher_type_), 1, 1));

   IF function_group_ NOT IN ('M','Q','K') THEN
      Error_SYS.Record_General(lu_name_, 'VOUGRPNOTVALID: Only voucher with category Manual Correction and Opening balances is allowed');
   END IF;
   IF (function_group_ IS NULL) THEN
      Error_SYS.Record_General(lu_name_, 'NOFUNGROUP: Voucher Type :P1 does not have Function Group', voucher_type_);
   END IF;

   Voucher_Type_User_Group_API.Check_If_Voucher_Type_Valid(valid_,
                                                           company_,
                                                           user_group_,
                                                           accounting_year_,
                                                           voucher_type_);
   Voucher_Type_API.Validate_Vou_Type_All_Gen (company_,
                                               voucher_type_);

   automatic_ := Voucher_Type_API.Check_Automatic(company_,
                                                  voucher_type_);
   desc_voucher_type_ := Voucher_Type_API.Get_Description(company_,
                                                          voucher_type_);
END Validate_Voucher_Type__;


PROCEDURE Create_Object_Connections__ (
   company_         IN VARCHAR2,
   voucher_type_    IN VARCHAR2,
   accounting_year_ IN NUMBER,
   voucher_no_      IN NUMBER )
IS   
   CURSOR getvourow IS
      SELECT row_no, account, code_b, code_c, code_d, code_e , code_f, code_g, code_h, code_i, code_j,
             debet_amount, credit_amount, text, trans_code, v.voucher_date,
             project_activity_id, currency_code, currency_debet_amount, currency_credit_amount
      FROM   voucher_tab v, voucher_row_tab vr
      WHERE  v.company           = vr.company
      AND    v.voucher_type      = vr.voucher_type
      AND    v.accounting_year   = vr.accounting_year
      AND    v.voucher_no        = vr.voucher_no
      AND    vr.company          = company_
      AND    vr.voucher_type     = voucher_type_
      AND    vr.accounting_year  = accounting_year_
      AND    vr.voucher_no       = voucher_no_
      AND    v.function_group    IN ('M','K','Q')
      AND    vr.project_id IS NOT NULL
      AND    NVL(vr.project_activity_id,0) != 0;  


BEGIN

   FOR row_ IN getvourow LOOP
      IF (row_.project_activity_id != -123456)  THEN         
         Voucher_Row_API.Create_Object_Connection_( company_                 ,
                                                    voucher_type_            ,
                                                    accounting_year_         ,
                                                    voucher_no_              ,
                                                    row_.row_no              ,
                                                    row_.account             ,
                                                    row_.debet_amount        ,
                                                    row_.credit_amount       ,
                                                    row_.text                ,
                                                    row_.trans_code          ,
                                                    row_.project_activity_id ,
                                                    row_.voucher_date        ,
                                                    row_.code_b              ,
                                                    row_.code_c              ,
                                                    row_.code_d              ,
                                                    row_.code_e              , 
                                                    row_.code_f              ,
                                                    row_.code_g              ,
                                                    row_.code_h              ,
                                                    row_.code_i              ,
                                                    row_.code_j              ,
                                                    row_.currency_code       ,
                                                    row_.currency_debet_amount,
                                                    row_.currency_credit_amount);

      END IF;
   END LOOP; 
END Create_Object_Connections__;


PROCEDURE Finalize_Manual_Voucher__ (
   final_voucher_no_       OUT NUMBER,
   company_                IN  VARCHAR2,
   voucher_type_           IN  VARCHAR2,
   transfer_id_            IN  VARCHAR2 )
IS 
   key_rec_                Voucher_Util_Pub_API.PublicKeyRec;
   automatic_              VARCHAR2(1);   
BEGIN
     automatic_        := Voucher_Type_API.Check_Automatic(company_, voucher_type_);
     final_voucher_no_ := -111;
     IF (automatic_ = 'Y') THEN
       
        Complete_Voucher__ ( key_rec_            ,
                             transfer_id_        ,
                             company_            ,
                             voucher_type_       ,
                             automatic_          ,
                             TRUE                );

       final_voucher_no_ := key_rec_.voucher_no;
       -- need to update the object connections here.
       -- when the final voucher number is known
       Create_Object_Connections__( company_ ,
                                    voucher_type_    ,
                                    key_rec_.accounting_year ,
                                    final_voucher_no_         );

   END IF;
END Finalize_Manual_Voucher__;


PROCEDURE Complete_Voucher__ (
   key_rec_            OUT Voucher_Util_Pub_API.PublicKeyRec,
   transfer_id_        IN  VARCHAR2,
   company_            IN  VARCHAR2,
   voucher_type_       IN  VARCHAR2,
   automatic_          IN  VARCHAR2,
   manual_voucher_     IN  BOOLEAN,
   interim_voucher_    IN  BOOLEAN DEFAULT FALSE )
IS
   -- Temporary variables because IN parameters cannot be modified
   t_company_              voucher_tab.company%TYPE;
   t_voucher_type_         voucher_tab.voucher_type%TYPE;

   accounting_year_        NUMBER;
   accounting_period_      NUMBER;
   fictive_voucher_no_     NUMBER;
   voucher_no_             NUMBER;
   voucher_date_           DATE;
   objid_                  VARCHAR2(2000);
   objversion_             VARCHAR2(2000);
   attr_                   VARCHAR2(2000);
   info_                   VARCHAR2(2000);
   user_group_             user_group_member_finance_tab.user_group%type;
   approved_by_user_group_ user_group_member_finance_tab.user_group%type;
   approved_by_userid_     VARCHAR2(30);
   manual_found_           BOOLEAN := FALSE;
   ledger_id_              VARCHAR2(10);
   authorize_level_        VARCHAR2(20);
   -- Bug 121856, Begin
   function_group_         voucher_tab.function_group%TYPE;
   -- Bug 121856, End
   
   -- Bug 121856, Begin, added function_group
   CURSOR get_vou IS
      SELECT rowid, ltrim(lpad(to_char(rowversion,'YYYYMMDDHH24MISS'),2000)), user_group, function_group
      FROM   voucher_tab
      WHERE  transfer_id  = transfer_id_;
   -- Bug 121856, End
   
   CURSOR get_vourow IS
      SELECT *
      FROM   voucher_row_tab
      WHERE  transfer_id  = transfer_id_;
      
   -- Bug 126851, Moved PROCEDURE Balance_Parallel_Diff___ outside of the scope of PROCEDURE Complete_Voucher__.

BEGIN
   ledger_id_    := Voucher_Type_Api.Get_Ledger_Id(company_, voucher_type_);
   
    
   IF (ledger_id_ NOT IN ('*', '00')) THEN
      -- Internal Ledger
      $IF Component_Intled_SYS.INSTALLED $THEN
         Internal_Voucher_Util_Pub_API.Get_Head_Info_Internal ( t_company_, 
                                                                t_voucher_type_,
                                                                accounting_year_,
                                                                accounting_period_,
                                                                fictive_voucher_no_,
                                                                voucher_date_,
                                                                transfer_id_ ); 
      $ELSE
         NULL;
      $END
   ELSE
      -- All Ledger or General Ledger
      Get_Head_Info__( t_company_,
                       t_voucher_type_,
                       accounting_year_,
                       accounting_period_,
                       fictive_voucher_no_,
                       voucher_date_,
                       transfer_id_ );
   END IF;
   IF ( automatic_ = 'Y' ) THEN
      Voucher_No_Serial_API.Get_Next_Voucher_No(voucher_no_, company_, voucher_type_, voucher_date_, accounting_year_, accounting_period_);
   ELSE
      voucher_no_ := fictive_voucher_no_;
      Voucher_No_Serial_API.Check_Voucher_No(company_,
                                             voucher_date_,
                                             voucher_type_,
                                             voucher_no_,
                                             accounting_year_,
                                             accounting_period_);
   END IF;                                                            
       
   key_rec_.company         := company_;
   key_rec_.voucher_type    := voucher_type_;
   key_rec_.accounting_year := accounting_year_;
   key_rec_.voucher_no      := voucher_no_;
   
   
   IF (ledger_id_ IN ('*', '00')) THEN
      --All Ledger or General Ledger
      -- set proj_conn_created flag -> 'TRUE means project connections will get created seperately later by the relavent product.
      UPDATE voucher_tab
      SET    voucher_no  = voucher_no_,
             rowversion  = SYSDATE,
             proj_conn_created = 'TRUE'
      WHERE  transfer_id = transfer_id_;
   
      UPDATE voucher_row_tab
      SET    voucher_no  = voucher_no_,
             rowversion  = SYSDATE
      WHERE  transfer_id = transfer_id_;
     
      -- Bug 121856, Begin, added function_group_
      OPEN  get_vou;
      FETCH get_vou INTO objid_, objversion_, user_group_, function_group_;
      CLOSE get_vou;
      -- Bug 121856, End
          
      -- Bug 108417,Begin Added IF condition
      IF NOT(interim_voucher_)  THEN
         UPDATE internal_postings_accrul_tab
         SET voucher_no = voucher_no_
         WHERE  company         = company_
         AND    accounting_year = accounting_year_
         AND    voucher_type    = voucher_type_
         AND    voucher_no      = fictive_voucher_no_ ;
         
         UPDATE period_allocation_tab
         SET voucher_no = voucher_no_
         WHERE  company         = company_
         AND    accounting_year = accounting_year_
         AND    voucher_type    = voucher_type_
         AND    voucher_no      = fictive_voucher_no_ ;
      
         $IF Component_Fixass_SYS.INSTALLED $THEN 
            UPDATE add_investment_info_tab
            SET    keyref1         = voucher_no_
            WHERE  company         = company_
            AND    source_ref      = 'VOUCHER'
            AND    keyref1         = fictive_voucher_no_
            AND    keyref2         = voucher_type_
            AND    keyref3         = accounting_year_;
         $END
      END IF;
      -- Bug 108417,End
      
      -- Bug 108417,Begin Modified IF condition
      IF NOT(manual_voucher_ OR interim_voucher_) THEN
         -- When completing a manual voucher, this part need not be executed
         IF (Voucher_Type_API.Get_Use_Manual(key_rec_.company, key_rec_.voucher_type) = 'TRUE') THEN
            FOR rec_ IN get_vourow LOOP
               manual_found_ := (manual_found_ OR (Voucher_Row_API.Is_Add_Internal( rec_.company,
                                                                                    rec_.internal_seq_number,
                                                                                    rec_.account,
                                                                                    rec_.voucher_type,
                                                                                    rec_.voucher_no,
                                                                                    rec_.accounting_year) = 'TRUE'));
            END LOOP;   
         END IF;
      
         IF (NOT manual_found_) THEN
            -- Bug 121856, Begin
            -- Special handling for specific function group to automatically balance parallel if it is unbalanced.
            Balance_Parallel_Diff___(company_,
                                     voucher_type_,
                                     accounting_year_,
                                     voucher_no_,
                                     function_group_);
            -- Bug 121856, End
            Voucher_API.Ready_To_Update__( info_,objid_, objversion_, attr_,'DO','NO');
            approved_by_userid_     := User_Finance_API.User_Id;
         
            IF (user_group_ IS NULL) THEN
               approved_by_user_group_ := User_Group_Member_Finance_Api.get_default_group( key_rec_.company, approved_by_userid_ );
            ELSE
               approved_by_user_group_ := user_group_;
            END IF;
         
            authorize_level_ := Authorize_Level_API.Encode
                                (voucher_type_user_group_api.get_authorize_level
                                                            (key_rec_.company, 
                                                             key_rec_.accounting_year,
                                                             approved_by_user_group_,
                                                             key_rec_.voucher_type));         
   
            IF (authorize_level_ = 'Approved') THEN
               UPDATE   voucher_tab
                  SET   approval_date           = SYSDATE,
                        approved_by_userid      = approved_by_userid_,
                        approved_by_user_group  = approved_by_user_group_
                  WHERE company         = key_rec_.company
                  AND   accounting_year = key_rec_.accounting_year
                  AND   voucher_type    = key_rec_.voucher_type                            
                  AND   voucher_no      = key_rec_.voucher_no;
            END IF;      
         END IF;
      END IF;
      -- Bug 108417,End
   END IF;
   $IF Component_Intled_SYS.INSTALLED $THEN
      Internal_Voucher_Util_Pub_API.Complete_Internal(transfer_id_,voucher_no_);  
   $END 
END Complete_Voucher__;


PROCEDURE Check_Refer_Mandatory__ (
   company_         IN VARCHAR2,
   accounting_year_ IN NUMBER,
   voucher_type_    IN VARCHAR2,
   voucher_no_      IN NUMBER )
IS
   dummy_           NUMBER;   
   CURSOR get_vourow IS
      SELECT 1
      FROM   voucher_row_tab
      WHERE  company          = company_
      AND    accounting_year  = accounting_year_
      AND    voucher_type     = voucher_type_
      AND    voucher_no       = voucher_no_
      AND    (reference_serie  IS NULL OR reference_number IS NULL);
BEGIN

   IF (voucher_type_api.Is_Reference_Mandatory( company_, voucher_type_ ) = 'Y') THEN
      OPEN get_vourow;
      FETCH get_vourow INTO dummy_;
      IF (get_vourow%FOUND) THEN
         CLOSE get_vourow;
         Error_SYS.Record_General( 'Voucher','REFSERNUMNOTNULL: Reference Series and Reference Number cannot be null when Reference Mandatory is checked for Voucher Type :P1', voucher_type_ );
      END IF;
      CLOSE get_vourow;
   END IF;

END Check_Refer_Mandatory__;


PROCEDURE Clear_Row_Group_Ids__ (
   company_         IN VARCHAR2,
   accounting_year_ IN NUMBER,
   voucher_type_    IN VARCHAR2,
   voucher_no_      IN NUMBER )
IS
BEGIN
   UPDATE voucher_row_tab
   SET    row_group_id    = NULL
   WHERE  company         = company_
   AND    accounting_year = accounting_year_
   AND    voucher_type    = voucher_type_
   AND    voucher_no      = voucher_no_;
END Clear_Row_Group_Ids__;


PROCEDURE Check_Double_Entry__ (
   company_         IN VARCHAR2,
   accounting_year_ IN NUMBER,
   voucher_type_    IN VARCHAR2,
   voucher_no_      IN NUMBER,
   voucher_status_  IN VARCHAR2 )
IS 
   CURSOR get_groups_ IS
      SELECT   row_group_id              row_group_id,
               MAX(correction)           correction_type1,
               MIN(correction)           correction_type2,
               NVL(SUM(debet_amount),0)  sum_debit,
               NVL(SUM(credit_amount),0) sum_credit,
               COUNT(debet_amount)       count_debit,
               COUNT(credit_amount)      count_credit,
               NVL(SUM(third_currency_debit_amount),0)  sum_third_cur_debit,
               NVL(SUM(third_currency_credit_amount),0) sum_third_cur_credit
      FROM     (SELECT company,
                       accounting_year,
                       voucher_type,
                       voucher_no,
                       row_group_id,
                       debet_amount,
                       credit_amount,
                       third_currency_debit_amount,
                       third_currency_credit_amount,
                       VOUCHER_ROW_API.Get_Correction_All__(company, 
                                                            voucher_type, 
                                                            accounting_year, 
                                                            voucher_no,
                                                            reference_row_no, 
                                                            nvl(debet_amount,credit_amount),
                                                            auto_tax_vou_entry) correction
                FROM voucher_row_tab)
      WHERE    company         = company_
      AND      accounting_year = accounting_year_
      AND      voucher_type    = voucher_type_
      AND      voucher_no      = voucher_no_
      GROUP BY row_group_id;
BEGIN
   IF ((Voucher_Status_API.Encode(voucher_status_) = 'Confirmed') AND
       (Voucher_Type_Api.Is_Row_Group_Validated(company_,voucher_type_) = 'Y')) THEN
      FOR group_ IN get_groups_ LOOP
         IF (group_.row_group_id IS NULL) THEN
            Error_SYS.Record_General ('Voucher', 'ACCRULDOUBLEENTRY4: All voucher rows must have a value for the Row Group ID');
         END IF;
         IF (group_.correction_type1 <> group_.correction_type2) THEN
            Error_SYS.Record_General ('Voucher', 'ACCRULDOUBLEENTRY1: All voucher rows must have the same value in the Correction column in the same group :P1', group_.row_group_id);
         END IF;
         IF (group_.count_debit > 1 AND group_.count_credit > 1) THEN
            Error_Sys.Record_General ('Voucher', 'ACCRULDOUBLEENTRY2: You cannot have more than one debit or more than one credit in Row Group ID :P1', group_.row_group_id);
         END IF;        
         IF (group_.sum_debit <> group_.sum_credit) THEN
            Error_Sys.Record_General ('Voucher', 'ACCRULDOUBLEENTRY3: The total amount of debit postings should be equal to the total amount of credit postings for Row Group ID :P1', group_.row_group_id);
         END IF;
         IF (group_.sum_third_cur_debit <> group_.sum_third_cur_credit) THEN
            Error_Sys.Record_General ('Voucher', 'ACCRULDOUBLEENTRY5: The total amount of parallel currency debit postings should be equal to the total amount of parallel currency credit postings for Row Group ID :P1', group_.row_group_id);
         END IF;
     END LOOP;
  ELSE
     Trace_sys.message('Double Entry Validation NOT done.');
  END IF;
END Check_Double_Entry__;


@UncheckedAccess
FUNCTION Is_Cancellation_Voucher__(
   company_           IN VARCHAR2,
   voucher_type_      IN VARCHAR2,
   accounting_year_   IN NUMBER,
   voucher_no_        IN NUMBER ) RETURN VARCHAR2
IS
   CURSOR is_cancel_voucher IS
      SELECT /*+ FIRST_ROWS(1) */ 1
      FROM voucher_row_tab
      WHERE company = company_
      AND accounting_year = accounting_year_
      AND voucher_type = voucher_type_
      AND voucher_no = voucher_no_
      AND trans_code LIKE 'CANCELLATION%';

   dummy_      PLS_INTEGER;
BEGIN
   OPEN is_cancel_voucher;
   FETCH is_cancel_voucher INTO dummy_;
   -- Only need to check if any row has trans_code CANCELLATION since all rows have 
   -- CANCELLATION trans_code on a cancellation voucher
   IF (is_cancel_voucher%FOUND) THEN
      CLOSE is_cancel_voucher;
      RETURN 'TRUE';
   ELSE
      CLOSE is_cancel_voucher;
      RETURN 'FALSE';
   END IF;
END Is_Cancellation_Voucher__;


PROCEDURE Ready_To_Update__ (
   info_                  OUT    VARCHAR2,
   objid_                 IN     VARCHAR2,
   objversion_            IN OUT VARCHAR2,
   attr_                  IN OUT VARCHAR2,
   action_                IN     VARCHAR2,
   object_conn_handling_  IN     VARCHAR2)
IS
   rec_ VOUCHER_TAB%ROWTYPE;
BEGIN
   IF (action_ = 'DO') THEN
      Client_SYS.Add_To_Attr('OBJECT_CONN_HANDLE', object_conn_handling_, attr_);
   END IF;   
   IF (action_ = 'CHECK') THEN
      NULL;
   ELSIF (action_ = 'DO') THEN
      rec_ := Lock_By_Id___(objid_, objversion_);
      Finite_State_Machine___(rec_, 'ReadyToUpdate', attr_);
      objversion_ := to_char(rec_.rowversion,'YYYYMMDDHH24MISS');
      Finite_State_Add_To_Attr___(rec_, attr_);
   END IF;
   info_ := Client_SYS.Get_All_Info;
END Ready_To_Update__;


-------------------- LU SPECIFIC PROTECTED METHODS --------------------------

FUNCTION Get_Prognosis_Value_ (
   company_                IN VARCHAR2,
   from_voucher_type_      IN VARCHAR2,
   to_voucher_type_        IN VARCHAR2,
   from_accounting_year_   IN NUMBER,
   to_accounting_year_     IN NUMBER,
   from_accounting_period_ IN NUMBER,
   to_accounting_period_   IN NUMBER,
   from_user_              IN VARCHAR2,
   to_user_                IN VARCHAR2 ) RETURN NUMBER
IS
   prognosis_              NUMBER;
   CURSOR count_vouchers(company_           IN VARCHAR2,
                         from_voucher_type_ IN VARCHAR2,
                         to_voucher_type_   IN VARCHAR2,
                         accounting_year_   IN NUMBER,
                         start_period_      IN NUMBER,
                         end_period_        IN NUMBER,
                         from_user_         IN VARCHAR2,
                         to_user_           IN VARCHAR2) IS
      SELECT voucher_type
      FROM   VOUCHER_TAB
      WHERE  company           = company_
      AND    voucher_type      BETWEEN from_voucher_type_ AND to_voucher_type_
      AND    accounting_year   = accounting_year_
      AND    accounting_period BETWEEN start_period_ AND end_period_
      AND    userid            BETWEEN from_user_ AND to_user_
      AND    voucher_updated   = 'N'
      AND    rowstate          = 'Confirmed';
   accounting_year_     NUMBER;
   start_period_        NUMBER;
   end_period_          NUMBER;
BEGIN
   prognosis_ := 0;
   IF ( NOT Company_Finance_Api.Is_User_Authorized(company_) ) THEN
      RETURN prognosis_;
   END IF;

   -- if PERCOS module is installed and user has no privilige to this module
   -- do not count PCA vouchers
   start_period_ := from_accounting_period_;
   accounting_year_ := from_accounting_year_;
   while (accounting_year_ < to_accounting_year_) LOOP
      Accounting_Period_API.Check_High_Period (end_period_,
                                               company_,
                                               accounting_year_);
      FOR voucher_ IN count_vouchers (company_,
                                      from_voucher_type_,
                                      to_voucher_type_,
                                      accounting_year_,
                                      start_period_,
                                      end_period_,
                                      from_user_,
                                      to_user_) LOOP
         prognosis_ := prognosis_ + 1;
      END LOOP;
      accounting_year_ := accounting_year_ + 1;
      start_period_ := 1;
   END LOOP;
   IF (accounting_year_ = to_accounting_year_) THEN
      FOR voucher_ IN count_vouchers (company_,
                                      from_voucher_type_,
                                      to_voucher_type_,
                                      accounting_year_,
                                      start_period_,
                                      to_accounting_period_,
                                      from_user_,
                                      to_user_) LOOP
         prognosis_ := prognosis_ + 1;
      END LOOP;
   END IF;
   RETURN prognosis_;
END Get_Prognosis_Value_;


FUNCTION Get_Vou_Status_Client_ (
   company_         IN VARCHAR2,
   accounting_year_ IN NUMBER,
   voucher_type_    IN VARCHAR2,
   voucher_no_      IN NUMBER ) RETURN VARCHAR2
IS
   CURSOR get_state IS
      SELECT rowstate
      FROM   VOUCHER_TAB
      WHERE  company         = company_
      AND    voucher_type    = voucher_type_
      AND    accounting_year = accounting_year_
      AND    voucher_no      = voucher_no_;
   vou_state_          VARCHAR2(20);
BEGIN
   OPEN get_state;
   FETCH get_state INTO vou_state_;
   CLOSE get_state;

   RETURN Finite_State_Decode__(vou_state_);

END Get_Vou_Status_Client_;


-- Read_Lock_Voucher_
--   This procedure reads and locks one voucher. Used by updating routine
--   in General Ledger.
PROCEDURE Read_Lock_Voucher_ (
   objid_                  IN OUT VARCHAR2,
   objversion_             IN OUT VARCHAR2,
   voucher_rec_            OUT    VoucherRecType,
   company_                IN     VARCHAR2,
   from_voucher_type_      IN     VARCHAR2,
   to_voucher_type_        IN     VARCHAR2,
   from_accounting_year_   IN     NUMBER,
   to_accounting_year_     IN     NUMBER,
   from_accounting_period_ IN     NUMBER,
   to_accounting_period_   IN     NUMBER,
   from_user_              IN     VARCHAR2,
   to_user_                IN     VARCHAR2,
   voucher_numb_           IN     VARCHAR2 DEFAULT NULL )
IS
   CURSOR get_voucher_info IS
      SELECT rowid      objid,
             ltrim(lpad(to_char(rowversion,'YYYYMMDDHH24MISS'),2000)) objversion,
             company,
             voucher_type,
             accounting_year,
             voucher_no,
             voucher_date,
             accounting_period,
             date_reg,
             userid,
             user_group,
             accounting_text_id,
             transfer_id,
             interim_voucher,
             internal_seq_number,
             voucher_type_reference,
             voucher_no_reference,
             accounting_year_reference,
             voucher_text,
             voucher_text2,
             entered_by_user_group,
             approval_date,
             approved_by_userid,
             approved_by_user_group
      FROM VOUCHER_TAB
      WHERE company           = company_
        AND voucher_type      BETWEEN from_voucher_type_ AND to_voucher_type_
        AND accounting_year   BETWEEN from_accounting_year_ AND to_accounting_year_
        AND accounting_period BETWEEN from_accounting_period_ AND to_accounting_period_
        AND userid            BETWEEN from_user_ AND to_user_
        AND voucher_updated   = 'N'
        AND rowstate          = 'Confirmed'
        AND (voucher_numb_ IS NULL OR INSTR(voucher_numb_, '^'||voucher_no||'^'||voucher_type||'^')>0)
      FOR UPDATE OF internal_seq_number nowait;
BEGIN
   -- if PERCOS module is installed and user has no privilige to this module
   -- do not count PCA vouchers
   OPEN get_voucher_info;
   FETCH get_voucher_info INTO objid_,
                               objversion_,
                               voucher_rec_.company,
                               voucher_rec_.voucher_type,
                               voucher_rec_.accounting_year,
                               voucher_rec_.voucher_no,
                               voucher_rec_.voucher_date,
                               voucher_rec_.accounting_period,
                               voucher_rec_.date_reg,
                               voucher_rec_.userid,
                               voucher_rec_.user_group,
                               voucher_rec_.accounting_text_id,
                               voucher_rec_.transfer_id,
                               voucher_rec_.interim_voucher,
                               voucher_rec_.internal_seq_number,
                               voucher_rec_.voucher_type_reference,
                               voucher_rec_.voucher_no_reference,
                               voucher_rec_.accounting_year_reference,
                               voucher_rec_.voucher_text,
                               voucher_rec_.voucher_text2,
                               voucher_rec_.entered_by_user_group,
                               voucher_rec_.approval_date,
                               voucher_rec_.approved_by_userid,
                               voucher_rec_.approved_by_user_group;

   IF get_voucher_info%NOTFOUND THEN
      objid_ := NULL;
   END IF;
   CLOSE get_voucher_info;
END Read_Lock_Voucher_;


-- Read_Lock_Voucher_Rows_
--   This procedure reads and locks all voucher rows belonging to a voucher.
--   Used by updating routine in General Ledger.
PROCEDURE Read_Lock_Voucher_Rows_ (
   voucher_rec_    IN     VoucherRecType,
   error_mess_     OUT    VARCHAR2 )
IS
   CURSOR lock_row_info IS
      SELECT 1
      FROM voucher_row_tab
      WHERE company         = voucher_rec_.company
      AND   voucher_type    = voucher_rec_.voucher_type
      AND   accounting_year = voucher_rec_.accounting_year
      AND   voucher_no      = voucher_rec_.voucher_no
      FOR UPDATE OF internal_seq_number nowait;
BEGIN
   error_mess_ := NULL;
   OPEN lock_row_info;
   -- There is no need to loop through all rows.
   -- The OPEN-statement locks them until COMMIT.
   CLOSE lock_row_info;
EXCEPTION
   WHEN OTHERS THEN
      error_mess_ := SQLERRM;
END Read_Lock_Voucher_Rows_;


-- Drop_Voucher_
--   This procedure drops one voucher.
--   Used by updating routine in General Ledger.
PROCEDURE Drop_Voucher_ (
   company_         IN VARCHAR2,
   voucher_type_    IN VARCHAR2,
   accounting_year_ IN NUMBER,
   voucher_no_      IN NUMBER )
IS
   remove_          BOOLEAN := TRUE;
   store_original_  VARCHAR2(1);
   CURSOR store_org IS
      SELECT store_original
      FROM   voucher_type_detail_tab
      WHERE  company      = company_
      AND    voucher_type = voucher_type_;
BEGIN
   -- This procedure is for backward compability against older versions of GENLED.
   OPEN store_org;
   FETCH store_org INTO store_original_;
   IF (store_original_ = 'Y') THEN
      remove_ := FALSE;
   END IF;
   CLOSE store_org;
   Drop_Voucher___(company_,
                   voucher_type_,
                   accounting_year_,
                   voucher_no_,
                   remove_);
END Drop_Voucher_;


-- Drop_Voucher_
--   This procedure drops one voucher.
--   Used by updating routine in General Ledger.
PROCEDURE Drop_Voucher_ (
   company_         IN VARCHAR2,
   voucher_type_    IN VARCHAR2,
   accounting_year_ IN NUMBER,
   voucher_no_      IN NUMBER,
   function_group_  IN VARCHAR2 )
IS
   remove_          BOOLEAN := TRUE;
   store_original_  VARCHAR2(1);
   CURSOR store_org IS
      SELECT store_original
      FROM   voucher_type_detail_tab
      WHERE  company      = company_
      AND    voucher_type = voucher_type_;
BEGIN
   OPEN store_org;
   FETCH store_org INTO store_original_;
   IF (store_original_ = 'Y') THEN
      remove_ := FALSE;
   END IF;
   CLOSE store_org;
   Drop_Voucher___(company_,
                   voucher_type_,
                   accounting_year_,
                   voucher_no_,
                   remove_);
END Drop_Voucher_;


PROCEDURE Remove_By_Keys_ (
   company_         IN VARCHAR2,
   voucher_type_    IN VARCHAR2,
   accounting_year_ IN NUMBER,
   voucher_no_      IN NUMBER )
IS
   remrec_             VOUCHER_TAB%ROWTYPE;
   key_                VARCHAR2(2000);
BEGIN
   remrec_ := Lock_By_Keys___(company_, accounting_year_, voucher_type_,  voucher_no_);
   Check_Delete___(remrec_);
   key_ := remrec_.company || '^' || remrec_.accounting_year || '^' || remrec_.voucher_type || '^' || remrec_.voucher_no || '^';
   Reference_SYS.Do_Cascade_Delete(lu_name_, key_);
   DELETE
      FROM  voucher_tab
      WHERE company         = company_
      AND   accounting_year = accounting_year_
      AND   voucher_type    = voucher_type_
      AND   voucher_no      = voucher_no_;
END Remove_By_Keys_;


-- Check_Voucher_Head_
--   This procedure checks that the voucher head information is correct.
--   Used by updating routine in General Ledger.
PROCEDURE Check_Voucher_Head_ (
   voucher_rec_ IN       VoucherRecType,
   attr_        IN OUT   VARCHAR2,
   err_mess_    OUT      VARCHAR2 )
IS
BEGIN
   err_mess_ := NULL;
   Voucher_No_Serial_Api.Check_Voucher_No ( voucher_rec_.company,
                                            voucher_rec_.voucher_date,
                                            voucher_rec_.voucher_type,
                                            voucher_rec_.voucher_no,
                                            voucher_rec_.accounting_year,
                                            voucher_rec_.accounting_period );
   Voucher_Type_User_Group_Api.Exist ( voucher_rec_.company,
                                       voucher_rec_.accounting_year,
                                       voucher_rec_.voucher_type,
                                       voucher_rec_.approved_by_user_group );
   User_Group_Period_Api.Is_Period_Open( voucher_rec_.company,
                                         voucher_rec_.accounting_year,
                                         voucher_rec_.accounting_period,
                                         voucher_rec_.approved_by_user_group );
   @ApproveTransactionStatement(2009-05-25,ashelk)
   SAVEPOINT VOUHEAD_ok;
   Client_SYS.Clear_Attr(attr_);
   Client_SYS.Add_To_Attr( 'COMPANY', voucher_rec_.company, attr_);
   Client_SYS.Add_To_Attr( 'VOUCHER_TYPE', voucher_rec_.voucher_type, attr_);
   Client_SYS.Add_To_Attr( 'FUNCTION_GROUP', voucher_rec_.function_group, attr_);
   Client_SYS.Add_To_Attr( 'ACCOUNTING_YEAR', voucher_rec_.accounting_year, attr_);
   Client_SYS.Add_To_Attr( 'VOUCHER_NO', voucher_rec_.voucher_no, attr_);
   Client_SYS.Add_To_Attr( 'VOUCHER_DATE', voucher_rec_.voucher_date, attr_);
   Client_SYS.Add_To_Attr( 'DATE_REG', voucher_rec_.date_reg, attr_);
   Client_SYS.Add_To_Attr( 'ACCOUNTING_PERIOD', voucher_rec_.accounting_period, attr_);
   Client_SYS.Add_To_Attr( 'USERID', voucher_rec_.userid, attr_);
   Client_SYS.Add_To_Attr( 'ACCOUNTING_TEXT_ID', voucher_rec_.accounting_text_id, attr_);
   Client_SYS.Add_To_Attr( 'TRANSFER_ID', voucher_rec_.transfer_id, attr_);
   Client_SYS.Add_To_Attr( 'USER_GROUP', voucher_rec_.user_group, attr_);
   Client_SYS.Add_To_Attr( 'VOUCHER_TYPE_REFERENCE', voucher_rec_.voucher_type_reference, attr_);
   Client_SYS.Add_To_Attr( 'ACCOUNTING_YEAR_REFERENCE',voucher_rec_.accounting_year_reference, attr_);
   Client_SYS.Add_To_Attr( 'VOUCHER_NO_REFERENCE', voucher_rec_.voucher_no_reference, attr_);
   Client_SYS.Add_To_Attr( 'INTERIM_VOUCHER', voucher_rec_.interim_voucher, attr_);
   Client_SYS.Add_To_Attr( 'VOUCHER_TEXT', voucher_rec_.voucher_text, attr_);
   Client_SYS.Add_To_Attr( 'VOUCHER_TEXT2', voucher_rec_.voucher_text2, attr_);
   Client_SYS.Add_To_Attr( 'INTERNAL_SEQ_NUMBER', voucher_rec_.internal_seq_number, attr_);
   Client_SYS.Add_To_Attr( 'ENTERED_BY_USER_GROUP', voucher_rec_.entered_by_user_group, attr_);
   Client_SYS.Add_To_Attr( 'APPROVAL_DATE', voucher_rec_.approval_date, attr_);
   Client_SYS.Add_To_Attr( 'APPROVED_BY_USERID', voucher_rec_.approved_by_userid, attr_);
   Client_SYS.Add_To_Attr( 'APPROVED_BY_USER_GROUP', voucher_rec_.approved_by_user_group, attr_);
   IF (voucher_rec_.multi_company_id IS NOT NULL) THEN
      Client_SYS.Add_To_Attr( 'MULTI_COMPANY_ID', voucher_rec_.multi_company_id, attr_);
   END IF;
EXCEPTION
   WHEN OTHERS THEN
      err_mess_ := SQLERRM;
END Check_Voucher_Head_;


-- Check_Voucher_Head_
--   This procedure checks that the voucher head information is correct.
--   Used by updating routine in General Ledger.
PROCEDURE Check_Voucher_Head_ (
   voucher_rec_ IN       VoucherRecType,
   err_mess_    OUT      VARCHAR2 )
IS
BEGIN
   err_mess_ := NULL;
   Voucher_No_Serial_Api.Check_Voucher_No ( voucher_rec_.company,
                                            voucher_rec_.accounting_year,
                                            voucher_rec_.voucher_type,
                                            voucher_rec_.voucher_no );
   IF ( voucher_rec_.status_cancelled != 'TRUE') THEN
      Voucher_Type_User_Group_Api.Exist ( voucher_rec_.company,
                                          voucher_rec_.accounting_year,
                                          voucher_rec_.voucher_type,
                                          voucher_rec_.approved_by_user_group );
      IF voucher_rec_.function_group != 'YE' THEN
         User_Group_Period_Api.Is_Period_Open( voucher_rec_.company,
                                               voucher_rec_.accounting_year,
                                               voucher_rec_.accounting_period,
                                               voucher_rec_.approved_by_user_group );
      END IF;
   END IF;
   @ApproveTransactionStatement(2009-05-25,ashelk)
   SAVEPOINT VOUHEAD_ok;
EXCEPTION
   WHEN OTHERS THEN
      err_mess_ := SQLERRM;
END Check_Voucher_Head_;


PROCEDURE Remove_Connected_Vouchers_ (
   company_         IN VARCHAR2,
   accounting_year_ IN NUMBER,
   voucher_type_    IN VARCHAR2,
   voucher_no_      IN NUMBER )
IS
   CURSOR getrec IS
      SELECT accounting_year,
             voucher_type,
             voucher_no
      FROM   VOUCHER_TAB
      WHERE  company = company_
      AND    accounting_year_reference = accounting_year_
      AND    voucher_type_reference    = voucher_type_
      AND    voucher_no_reference      = voucher_no_;

   simulation_voucher_  VARCHAR2(5);
BEGIN
   simulation_voucher_ := Voucher_Type_API.Get_Simulation_Voucher ( company_,
                                                                    voucher_type_);

   IF (simulation_voucher_ = 'TRUE') THEN
      FOR getrec_ IN getrec LOOP
         Remove_By_Keys_ (company_,
                          getrec_.voucher_type,
                          getrec_.accounting_year,
                          getrec_.voucher_no);

      END LOOP;
      $IF Component_Intled_SYS.INSTALLED $THEN
       -- To remove the internal voucher header from Internal_Hold_Voucher_Tab

         INTERNAL_VOUCHER_UTIL_PUB_API.Remove_Connected_Il_Vouchers(company_,
                                                                    voucher_type_,
                                                                    accounting_year_,
                                                                    voucher_no_);
      $END
   END IF;
END Remove_Connected_Vouchers_;


-------------------- LU SPECIFIC PUBLIC METHODS -----------------------------

-- Exist_Vou_Per_Period
--   This procedure checks if any vouchers exists in waiting table for a particular Period
@UncheckedAccess
FUNCTION Exist_Vou_Per_Period (
      company_            IN     VARCHAR2,
      accounting_year_    IN     NUMBER,
      accounting_period_  IN     NUMBER ) RETURN VARCHAR2
IS
   CURSOR exist_vouchers IS
      SELECT 1
      FROM  voucher_tab
      WHERE company           = company_
      AND   accounting_year   = accounting_year_
      AND   accounting_period = accounting_period_;

   dummy_ NUMBER;
BEGIN

   OPEN  exist_vouchers;
   FETCH exist_vouchers INTO dummy_;

   IF (exist_vouchers%FOUND) THEN
      CLOSE exist_vouchers;
      RETURN 'TRUE';
   ELSE
      CLOSE exist_vouchers;
      RETURN 'FALSE';
   END IF;
END Exist_Vou_Per_Period;


@UncheckedAccess
FUNCTION Is_Ye_Vouchers_Exist(
   company_             IN VARCHAR2,
   acc_year_            IN NUMBER ) RETURN VARCHAR2
IS
   dummy_     NUMBER;

   CURSOR vou_exist_ IS
   SELECT 1
      FROM voucher_tab
      WHERE company         = company_
      AND function_group    = 'YE'
      AND accounting_year   = acc_year_
      AND voucher_updated   = 'N'
      AND rowstate          = 'Confirmed';
BEGIN
   OPEN vou_exist_;
   FETCH vou_exist_ INTO dummy_;
   IF (vou_exist_%FOUND) THEN
      CLOSE vou_exist_;
      RETURN 'TRUE';
   ELSE
      CLOSE vou_exist_;
      RETURN 'FALSE';
   END IF;
END Is_Ye_Vouchers_Exist;


@UncheckedAccess
FUNCTION Get_Date_Reg (
   company_         IN VARCHAR2,
   voucher_type_    IN VARCHAR2,
   accounting_year_ IN NUMBER,
   voucher_no_      IN NUMBER ) RETURN DATE
IS
   temp_  Public_Rec;
BEGIN
   temp_  := Get(company_,accounting_year_,voucher_type_,voucher_no_);
   RETURN temp_.date_reg;
END Get_Date_Reg;


-- Is_Usergroup_Used
--   This procedure checks if any vouchers exists in waiting table with a partcular usergroup
@UncheckedAccess
FUNCTION Is_Usergroup_Used (
      company_    IN VARCHAR2,
      user_group_ IN VARCHAR2 ) RETURN VARCHAR2
IS
   CURSOR user_group_used IS
      SELECT 1
      FROM  voucher_tab
      WHERE company    = company_
      AND   user_group = user_group_;

   dummy_ NUMBER;
BEGIN

   OPEN  user_group_used;
   FETCH user_group_used INTO dummy_;

   IF (user_group_used%FOUND) THEN
      CLOSE user_group_used;
      RETURN 'TRUE';
   ELSE
      CLOSE user_group_used;
      RETURN 'FALSE';
   END IF;
END Is_Usergroup_Used;


@UncheckedAccess
FUNCTION Get_Userid (
   company_         IN VARCHAR2,
   voucher_type_    IN VARCHAR2,
   accounting_year_ IN NUMBER,
   voucher_no_      IN NUMBER ) RETURN VARCHAR2
IS
   temp_  Public_Rec;
BEGIN
   temp_  := Get(company_,accounting_year_,voucher_type_,voucher_no_);
   RETURN temp_.userid;
END Get_Userid;


@UncheckedAccess
FUNCTION Get_Transfer_Id (
   company_         IN VARCHAR2,
   voucher_type_    IN VARCHAR2,
   accounting_year_ IN NUMBER,
   voucher_no_      IN NUMBER ) RETURN VARCHAR2
IS
   temp_  Public_Rec;
BEGIN
   temp_  := Get(company_,accounting_year_,voucher_type_,voucher_no_);
   RETURN temp_.transfer_id;
END Get_Transfer_Id;


@UncheckedAccess
FUNCTION Get_Accounting_Period (
   company_         IN VARCHAR2,
   voucher_type_    IN VARCHAR2,
   accounting_year_ IN NUMBER,
   voucher_no_      IN NUMBER ) RETURN NUMBER
IS
   temp_   Public_Rec;

BEGIN
   temp_  := Get(company_,accounting_year_,voucher_type_,voucher_no_);
   RETURN temp_.accounting_period;
END Get_Accounting_Period;


@UncheckedAccess
FUNCTION Get_User_Group (
   company_         IN VARCHAR2,
   voucher_type_    IN VARCHAR2,
   accounting_year_ IN NUMBER,
   voucher_no_      IN NUMBER ) RETURN VARCHAR2
IS
   temp_  Public_Rec;
BEGIN
   temp_  := Get(company_,accounting_year_,voucher_type_,voucher_no_);
   RETURN temp_.user_group;
END Get_User_Group;


PROCEDURE Get_User_Group (
   user_group_      OUT VARCHAR2,
   company_         IN  VARCHAR2,
   voucher_type_    IN  VARCHAR2,
   accounting_year_ IN  NUMBER,
   voucher_no_      IN  NUMBER )
IS
   nousergr  EXCEPTION;
BEGIN
   user_group_ := Get_User_Group (company_,
                                  voucher_type_,
                                  accounting_year_,
                                  voucher_no_);
   IF ( user_group_ IS NULL ) THEN
      raise nousergr;
   END IF;
EXCEPTION
   WHEN nousergr THEN
       Error_SYS.record_general(lu_name_, 'NOVOU: Voucher number :P1 is missing company :P2 voucher_type :P3',voucher_no_,company_,voucher_type_);
END Get_User_Group;


-- Transfer_Init
--   This procedure is called when a transaktion of vouchers to Accounting
--   Rules is started. A new Transfer Identity is fetched and returned to
--   calling routine.
PROCEDURE Transfer_Init (
   transfer_id_ OUT VARCHAR2,
   company_     IN  VARCHAR2 )
IS
BEGIN
   transfer_id_ := 0;
END Transfer_Init;


-- New_Voucher
--   This procedures has to be called to initiate that a new voucher will be
--   transferred to Accounting Rules. If several vouchers will be transferred
--   this procedure must be called at first for each voucher. A voucher_id is
--   given to identify the voucher among all others. A transfer_id is given to
--   identify a transaction of several vouchers. If voucher_type, voucher_id
--   and period is NULL, the procedure give these parameters to the calling
PROCEDURE New_Voucher (
   voucher_type_         IN OUT VARCHAR2,
   voucher_no_           IN OUT NUMBER,
   voucher_id_           IN OUT VARCHAR2,
   accounting_year_      IN OUT NUMBER,
   accounting_period_    IN OUT NUMBER,
   company_              IN     VARCHAR2,
   transfer_id_          IN     VARCHAR2,
   voucher_date_         IN     DATE,
   voucher_group_        IN     VARCHAR2,
   user_group_           IN OUT VARCHAR2,
   correction_           IN     VARCHAR2   DEFAULT NULL,
   voucher_type_ref_     IN     VARCHAR2   DEFAULT NULL,
   accounting_year_ref_  IN     NUMBER     DEFAULT NULL,
   voucher_no_ref_       IN     NUMBER     DEFAULT NULL,
   multi_company_id_     IN     VARCHAR2   DEFAULT NULL,
   voucher_text_         IN     VARCHAR2   DEFAULT NULL,
   notes_                IN     VARCHAR2   DEFAULT NULL,
   is_year_end_          IN     BOOLEAN    DEFAULT FALSE)
IS
   call_error_voucher_init EXCEPTION;
   user_name_              VARCHAR2(30);
   attr_                   VARCHAR2(2000);
   newrec_                 VOUCHER_TAB%ROWTYPE;
   objid_                  VARCHAR2(2000);
   objversion_             VARCHAR2(2000);
   automatic_              VARCHAR2(1);
   ledger_id_              VARCHAR2(10);
   func_group_             VARCHAR2(5);
   status_                 VARCHAR2(1);
   year_end_               VARCHAR2(5);

BEGIN
   user_name_ := User_Finance_API.User_Id;
   IF voucher_id_ IS NOT NULL THEN
      RAISE call_error_voucher_init;
   END IF;

   IF (user_group_ IS NULL) THEN
      user_group_ := User_Group_Member_Finance_Api.get_default_group( company_, user_name_ );
   END IF;

   func_group_ := VOUCHER_TYPE_DETAIL_API.Get_Function_Group(company_,voucher_type_);

   year_end_ := 'FALSE';
   IF (is_year_end_) THEN
      year_end_ := 'TRUE';
      ACCOUNTING_PERIOD_API.Get_Period_Status(status_, company_, accounting_year_, accounting_period_);
      IF (status_ != 'O') THEN
         ERROR_SYS.Record_General(lu_name_,'PERCLOSED: The period :P1 is closed', accounting_period_ );
      END IF;
      IF (USER_GROUP_PERIOD_API.Is_Period_Open(company_, accounting_year_, accounting_period_, user_group_) != 'TRUE') THEN
         Error_SYS.Record_General(lu_name_,'USRGRPPER: Period not open for user group :P1',user_group_);
      END IF;
   END IF;
   ledger_id_ := Voucher_Type_API.Get_Ledger_Id(company_, voucher_type_);
   IF (func_group_ != 'YE' OR func_group_ IS NULL) AND (year_end_ = 'FALSE') THEN     
      IF ((ledger_id_ IN ('*','00')) OR (ledger_id_ IS NULL)) THEN
         User_Group_Period_Api.Get_And_Validate_Period( accounting_year_,
                                                        accounting_period_,
                                                        company_,
                                                        user_group_,
                                                        voucher_date_ );
      ELSE
         User_Group_Period_API.Get_And_Validate_Il_Period( accounting_year_,
                                                           accounting_period_,
                                                           company_,
                                                           user_group_,
                                                           voucher_date_ );
      END IF;
   END IF;
   IF voucher_type_ IS NULL THEN
      Voucher_Type_User_Group_Api.Get_Default_Voucher_Type(voucher_type_,
                                                           company_,
                                                           user_group_,
                                                           accounting_year_,
                                                           voucher_group_ );
   END IF;
   IF voucher_no_ IS NULL OR voucher_no_ = 0 THEN
      voucher_no_ := 0;
   END IF;

   User_Group_Member_Finance_API.Exist( company_,
                                        user_group_,
                                        user_name_ );
   Voucher_Type_User_Group_API.Validate_Voucher_Type(company_,
                                                     voucher_type_,
                                                     voucher_group_,
                                                     accounting_year_,
                                                     user_group_);

   newrec_.company                     := company_;
   newrec_.accounting_year             := accounting_year_;
   newrec_.voucher_type                := voucher_type_;
   Voucher_Type_API.Exist (newrec_.company,
                           newrec_.voucher_type);
   newrec_.voucher_no                  := voucher_no_;
   newrec_.voucher_date                := voucher_date_;
   newrec_.user_group                  := user_group_;
   newrec_.accounting_period           := accounting_period_;
   newrec_.date_reg                    := sysdate;
   newrec_.userid                      := user_name_;
   newrec_.entered_by_user_group       := user_group_;
   newrec_.transfer_id                 := transfer_id_;
   newrec_.voucher_type_reference      := voucher_type_ref_;
   newrec_.accounting_year_reference   := accounting_year_ref_;
   newrec_.voucher_no_reference        := voucher_no_ref_;
   newrec_.multi_company_id            := multi_company_id_;
   newrec_.voucher_text                := voucher_text_ ;
   newrec_.voucher_text2               := notes_;
   newrec_.function_group              := voucher_group_;
   -- Bug 130729, Begin, Added condition
   IF (func_group_ NOT IN  ('0', 'L')) THEN
      newrec_.amount_method            := Company_Finance_API.Get_Def_Amount_Method_Db(company_);
   END IF;
   -- Bug 130729, End

   Error_SYS.Check_Not_Null(lu_name_, 'COMPANY', newrec_.company);
   Error_SYS.Check_Not_Null(lu_name_, 'ACCOUNTING_YEAR', newrec_.accounting_year);
   Error_SYS.Check_Not_Null(lu_name_, 'VOUCHER_TYPE', newrec_.voucher_type);
   Error_SYS.Check_Not_Null(lu_name_, 'VOUCHER_NO', newrec_.voucher_no);
   Error_SYS.Check_Not_Null(lu_name_, 'VOUCHER_DATE', newrec_.voucher_date);
   Error_SYS.Check_Not_Null(lu_name_, 'DATE_REG', newrec_.date_reg);

   IF (Company_API.Get_Template_Company(newrec_.company) = 'TRUE') THEN
      Error_SYS.Appl_General(lu_name_, 'TEMPLATECOMP: Company :P1 is a Template Company and cannot create vouchers', newrec_.company);
   END IF;

   automatic_ := Voucher_Type_API.Check_Automatic (newrec_.company, newrec_.voucher_type);

   IF ( automatic_ = 'Y' ) THEN
      IF (newrec_.voucher_no = 0) THEN
         Voucher_No_Serial_API.Get_Next_Voucher_No (newrec_.voucher_no,
                                                    newrec_.company,
                                                    newrec_.voucher_type,
                                                    newrec_.voucher_date,
                                                    newrec_.accounting_year,
                                                    newrec_.accounting_period);
      ELSE
         Error_Sys.Record_General(lu_name_,'NOTMANUAL: Voucher Number should be assigned automatically');
      END IF;
   ELSE
      Voucher_No_Serial_API.Check_Voucher_No(newrec_.company,
                                             newrec_.voucher_date,
                                             newrec_.voucher_type,
                                             newrec_.voucher_no,
                                             newrec_.accounting_year,
                                             newrec_.accounting_period);
   END IF;

   IF (User_Group_Finance_Api.Get_Allowed_Acc_Period(newrec_.company,newrec_.user_group) = '2') THEN
      IF (Accounting_Period_Api.Is_Year_End_Period(newrec_.company, newrec_.accounting_year, newrec_.accounting_period) = TRUE) THEN
         newrec_.revenue_cost_clear_voucher := 'TRUE';
      END IF;
   END IF;
   
   IF ( ledger_id_ IS NULL) THEN
      ledger_id_ := Voucher_Type_API.Get_Ledger_Id(company_, voucher_type_);
   END IF;

   IF (ledger_id_ IN ('*','00') ) THEN
      IF (newrec_.function_group IS NULL) THEN
         newrec_.function_group := Voucher_Type_Detail_API.Get_Function_Group (newrec_.company,
                                                                               newrec_.voucher_type);
      END IF;
      IF (newrec_.simulation_voucher IS NULL) THEN
         newrec_.simulation_voucher := Voucher_Type_API.Get_Simulation_Voucher (newrec_.company,
                                                                                newrec_.voucher_type);
      END IF;
      Insert___(objid_, objversion_, newrec_, attr_);
      voucher_no_ := newrec_.voucher_no;
      voucher_id_ := transfer_id_||Client_SYS.field_separator_||company_||Client_SYS.field_separator_||voucher_type_||Client_SYS.field_separator_||TO_CHAR(newrec_.voucher_no)||Client_SYS.field_separator_||TO_CHAR(accounting_year_);
      $IF Component_Intled_SYS.INSTALLED $THEN
         IF (Voucher_Type_API.Is_Vou_Type_All_Ledger(newrec_.company, newrec_.voucher_type) = 'TRUE') THEN
            Internal_Voucher_Util_Pub_API.Create_Internal_Head(newrec_);            
         END IF;
      $END
   ELSE
      $IF Component_Intled_SYS.INSTALLED $THEN
         voucher_no_ := newrec_.voucher_no;
         Internal_Voucher_Util_Pub_API.Create_Head_Internal (newrec_, ledger_id_);
      $ELSE
         NULL;
      $END
   END IF;
EXCEPTION
   WHEN call_error_voucher_init THEN
      Error_SYS.record_general(lu_name_, 'WRONGCALLORD1: Wrong calling order when creating voucher in waittable.');
END New_Voucher;


PROCEDURE New_Ext_Voucher (
   voucher_type_         IN OUT VARCHAR2,
   voucher_no_           IN OUT NUMBER,
   transfer_id_          IN OUT VARCHAR2,
   accounting_year_      IN     NUMBER,
   accounting_period_    IN     NUMBER,
   company_              IN     VARCHAR2,
   voucher_date_         IN     DATE,
   voucher_group_        IN     VARCHAR2,
   user_group_           IN     VARCHAR2,
   correction_           IN     VARCHAR2,
   automatic_            IN     VARCHAR2,
   ledger_id_            IN     VARCHAR2,
   user_name_            IN     VARCHAR2,
   vou_type_all_ledger_  IN     VARCHAR2 )
IS
   call_error_voucher_init EXCEPTION;
   newrec_                 VOUCHER_TAB%ROWTYPE;
   voucher_type_ref_       voucher_tab.Voucher_Type_Reference%TYPE;
   accounting_year_ref_    voucher_tab.accounting_year_reference%TYPE;
   voucher_no_ref_         voucher_tab.voucher_no_reference%TYPE;
   vou_rec_                VOUCHER_TAB%ROWTYPE;

   CURSOR get_voucher IS
      SELECT * 
        FROM VOUCHER_TAB
       WHERE transfer_id = transfer_id_;

BEGIN
   newrec_.company                   := company_;
   Error_SYS.Check_Not_Null(lu_name_, 'COMPANY', company_);
   Error_SYS.Check_Not_Null(lu_name_, 'ACCOUNTING_YEAR', accounting_year_);
   Error_SYS.Check_Not_Null(lu_name_, 'VOUCHER_TYPE', voucher_type_);
   Error_SYS.Check_Not_Null(lu_name_, 'VOUCHER_DATE', voucher_date_);
        
   Create_Voucher_Head__ ( transfer_id_         ,
                           company_             ,
                           voucher_date_        ,
                           user_group_          ,
                           voucher_type_        ,
                           voucher_no_          ,
                           voucher_type_ref_    ,
                           accounting_year_ref_ ,
                           voucher_no_ref_      ,
                           NULL                 ,
                           NULL                 ,
                           NULL                 ,
                           voucher_group_       ,
                           NULL                 ,
                           'FALSE'               );

   -- Note: use the same code written in Voucher_Util_Pub_API.Create_Voucher_Head()
   OPEN  get_voucher;
   FETCH get_voucher INTO vou_rec_;
   CLOSE get_voucher;
   $IF Component_Intled_SYS.INSTALLED $THEN
      IF (vou_type_all_ledger_ = 'TRUE') THEN  
         Internal_Voucher_Util_Pub_API.Create_Internal_Head(vou_rec_);
      END IF;
   $END

EXCEPTION
   WHEN call_error_voucher_init THEN
      Error_SYS.record_general(lu_name_, 'WRONGCALLORD1: Wrong calling order when creating voucher in waittable.');
END New_Ext_Voucher;


-- Add_Voucher_Row
--   This procedure is called for each voucher row. The procedure creates
--   voucher rows in Accounting Rules. When the first Voucher row of a voucher
--   is sent, the Voucher head is also created.
PROCEDURE Add_Voucher_Row (
   voucher_row_rec_     IN OUT VoucherRowRecType,
   transfer_id_         IN     VARCHAR2,
   voucher_id_          IN     VARCHAR2,
   base_currency_code_  IN     VARCHAR2,
   base_curr_rounding_  IN     NUMBER,
   is_base_emu_         IN     VARCHAR2,
   trans_curr_rounding_ IN     NUMBER,      
   third_curr_rounding_ IN     NUMBER,      
   is_third_emu_        IN     VARCHAR2,    
   fa_code_part_        IN     VARCHAR2,
   project_code_part_   IN     VARCHAR2,
   create_project_conn_ IN     BOOLEAN DEFAULT TRUE )   
IS
   call_error_voucher_row EXCEPTION;
   voucher_row_attr_      VARCHAR2(2000);
   headrec_               VOUCHER_TAB%ROWTYPE;
   voucher_id_temp_       VARCHAR2(300);
   company_               VARCHAR2(20);
   base_currency_codex_   VARCHAR2(3);               --
   base_curr_roundingx_   NUMBER;                    --
   is_base_emux_          VARCHAR2(5);               --
   trans_curr_roundingx_  NUMBER;                    -- Misc performance
   third_currency_code_   VARCHAR2(3);               --
   third_curr_roundingx_  NUMBER;                    --
   is_third_emux_         VARCHAR2(5);               --
   project_code_partx_    VARCHAR2(1);
   fa_code_partx_         VARCHAR2(1);               --
   ledger_id_il_          VARCHAR2(10);
   accounting_year_       VOUCHER_TAB.accounting_year%TYPE;
   voucher_type_          VOUCHER_TAB.voucher_type%TYPE;
   voucher_no_            VOUCHER_TAB.voucher_no%TYPE;
   sep_                   CONSTANT VARCHAR2(1) := Client_SYS.field_separator_;
BEGIN

   ledger_id_il_ := Voucher_Type_Api.Get_Ledger_Id (voucher_row_rec_.company,
                                                    voucher_row_rec_.voucher_type);
   
   company_         := SUBSTR(voucher_id_,INSTR(voucher_id_,sep_,1,1)+1,INSTR(voucher_id_,sep_,1,2)-INSTR(voucher_id_,sep_,1,1)-1);
   voucher_type_    := SUBSTR(voucher_id_,INSTR(voucher_id_,sep_,1,2)+1,INSTR(voucher_id_,sep_,1,3)-INSTR(voucher_id_,sep_,1,2)-1);
   voucher_no_      := TO_NUMBER(SUBSTR(voucher_id_,INSTR(voucher_id_,sep_,1,3)+1,INSTR(voucher_id_,sep_,1,4)-INSTR(voucher_id_,sep_,1,3)-1));
   accounting_year_ := TO_NUMBER(SUBSTR(voucher_id_,INSTR(voucher_id_,sep_,1,4)+1));
   
   headrec_ := Get_Object_By_Keys___(company_,accounting_year_,voucher_type_,voucher_no_);

   voucher_id_temp_ := headrec_.transfer_id||sep_||
                       headrec_.company||sep_||
                       headrec_.voucher_type||sep_||
                       TO_CHAR(headrec_.voucher_no)||sep_||
                       TO_CHAR(headrec_.accounting_year);


   IF (voucher_id_ = voucher_id_temp_ AND transfer_id_ = headrec_.transfer_id) THEN
      voucher_row_rec_.company         := headrec_.company;
      voucher_row_rec_.voucher_type    := headrec_.voucher_type;
      voucher_row_rec_.accounting_year := headrec_.accounting_year;
      voucher_row_rec_.voucher_no      := headrec_.voucher_no;
      voucher_row_rec_.voucher_date    := headrec_.voucher_date;
      company_                         := headrec_.company;
      IF (fa_code_part_ IS NOT NULL) THEN
         fa_code_partx_ := fa_code_part_;
      ELSE
         fa_code_partx_ := Accounting_Code_Parts_Api.Get_Codepart_Function (company_,
                                                                            'FAACC');
      END IF;
      IF (project_code_part_ IS NOT NULL) THEN
         project_code_partx_ := project_code_part_;
      ELSE
         project_code_partx_ := Accounting_Code_Parts_Api.Get_Codepart_Function (company_,
                                                                                 'PRACC');
      END IF;
      -- Currency_codes and roundings are sent to this procedure
      IF (base_currency_code_ = 'XXX') THEN
         base_currency_codex_  := Company_Finance_Api.Get_Currency_Code (company_);
         is_base_emux_ := Currency_Code_Api.Get_Valid_Emu (company_,
                                                           base_currency_codex_,
                                                           voucher_row_rec_.voucher_date);
         base_curr_roundingx_  := Currency_Code_API.Get_currency_rounding (company_,
                                                                           base_currency_codex_);
         third_currency_code_ := Company_Finance_Api.Get_Parallel_Acc_Currency (voucher_row_rec_.company,
                                                                                voucher_row_rec_.voucher_date);
         IF (voucher_row_rec_.currency_code = base_currency_code_) THEN
            trans_curr_roundingx_ := base_curr_roundingx_;
         ELSE
            trans_curr_roundingx_ := Currency_Code_API.Get_currency_rounding (voucher_row_rec_.company,
                                                                              voucher_row_rec_.currency_code);
         END IF;
         IF (third_currency_code_ IS NOT NULL) THEN
            IF    (third_currency_code_ = base_currency_codex_) THEN
               third_curr_roundingx_  := base_curr_roundingx_;
            ELSIF (third_currency_code_ = voucher_row_rec_.currency_code) THEN
               third_curr_roundingx_  := trans_curr_roundingx_;
            ELSE
               third_curr_roundingx_  := Currency_Code_API.Get_currency_rounding (voucher_row_rec_.company,
                                                                                 third_currency_code_);
            END IF;
            is_third_emux_       := Currency_Code_Api.Get_Valid_Emu (voucher_row_rec_.company,
                                                                     third_currency_code_,
                                                                     voucher_row_rec_.voucher_date);
         ELSE
            is_third_emux_       := 'FALSE';
         END IF;
      -- Currency_codes and roundings are not sent to this procedure
      ELSE
         base_currency_codex_  := base_currency_code_;
         base_curr_roundingx_  := base_curr_rounding_;
         trans_curr_roundingx_ := trans_curr_rounding_;
         third_curr_roundingx_ := third_curr_rounding_;
         is_base_emux_         := is_base_emu_;
         is_third_emux_        := is_third_emu_;
      END IF;

      voucher_row_rec_.accounting_period := headrec_.accounting_period;

      Voucher_Row_Api.Add_New_Row_( voucher_row_rec_,
                                    voucher_row_attr_,
                                    base_currency_codex_,
                                    base_curr_roundingx_,   --
                                    is_base_emux_,          --
                                    trans_curr_roundingx_,  --
                                    third_curr_roundingx_,  --
                                    is_third_emux_,         --
                                    fa_code_partx_,
                                    project_code_partx_,
                                    create_project_conn_ );  --
   ELSE
      RAISE call_error_voucher_row;
   END IF;
EXCEPTION
   WHEN call_error_voucher_row THEN
      Error_SYS.record_general(lu_name_, 'WRONGCALLORD1: Wrong calling order when creating voucher in waittable.');
END Add_Voucher_Row;


-- Add_Voucher_Row
--   This procedure is called for each voucher row. The procedure creates
--   voucher rows in Accounting Rules. When the first Voucher row of a voucher
--   is sent, the Voucher head is also created.
PROCEDURE Add_Voucher_Row (
   voucher_row_rec_     IN OUT VoucherRowRecType,
   transfer_id_         IN     VARCHAR2,
   voucher_id_          IN     VARCHAR2,
   create_project_conn_ IN     BOOLEAN DEFAULT TRUE )
IS
BEGIN
   Add_Voucher_Row (voucher_row_rec_,
                    transfer_id_,
                    voucher_id_,
                    'XXX',
                    0,
                    'FALSE',
                    0,
                    0,
                    'FALSE',
                    NULL,
                    NULL,
                    create_project_conn_);
END Add_Voucher_Row;


-- Voucher_End
--   This procedure is called when the last voucher row has been transferred to
--   Accounting Rules. After calling this procedure, commit should be done by
--   calling routine.
PROCEDURE Voucher_End (
   voucher_id_            IN OUT VARCHAR2,
   cancel_option_         IN     BOOLEAN  DEFAULT FALSE,
   object_conn_handling_  IN     VARCHAR2 DEFAULT NULL )
IS
   attr_                  VARCHAR2(2000);
   call_error_voucher_end EXCEPTION;
   objid_                 VOUCHER.objid%TYPE;
   objversion_            VARCHAR2(2000);
   notfound_              EXCEPTION;
   headrec_               VOUCHER_TAB%ROWTYPE;
   company_               VOUCHER_TAB.company%TYPE;
   accounting_year_       VOUCHER_TAB.accounting_year%TYPE;
   voucher_type_          VOUCHER_TAB.voucher_type%TYPE;
   voucher_no_            VOUCHER_TAB.voucher_no%TYPE;
   manual_found_          BOOLEAN := FALSE;
   authorize_level_       VARCHAR2(20);   
   ledger_id_             VOUCHER_TYPE_TAB.ledger_id%TYPE;
   info_save_             VARCHAR2(2000);
   sep_                   CONSTANT VARCHAR2(1) := Client_SYS.field_separator_;
   
   CURSOR get_vourow IS
      SELECT *
      FROM   voucher_row_tab
      WHERE  company          = company_
      AND    accounting_year  = accounting_year_
      AND    voucher_type     = voucher_type_
      AND    voucher_no       = voucher_no_;

BEGIN
 
   company_         := SUBSTR(voucher_id_,INSTR(voucher_id_, sep_,1,1)+1,INSTR(voucher_id_, sep_,1,2)-INSTR(voucher_id_, sep_,1,1)-1);
   voucher_type_    := SUBSTR(voucher_id_,INSTR(voucher_id_, sep_,1,2)+1,INSTR(voucher_id_, sep_,1,3)-INSTR(voucher_id_, sep_,1,2)-1);
   voucher_no_      := TO_NUMBER(SUBSTR(voucher_id_,INSTR(voucher_id_, sep_,1,3)+1,INSTR(voucher_id_, sep_,1,4)-INSTR(voucher_id_, sep_,1,3)-1));
   accounting_year_ := TO_NUMBER(SUBSTR(voucher_id_,INSTR(voucher_id_, sep_,1,4)+1));    
   
   headrec_         := Get_Object_By_Keys___(company_,accounting_year_,voucher_type_,voucher_no_);
   
   Get_Id_Version_By_Keys___(objid_,objversion_,company_,accounting_year_,voucher_type_,voucher_no_);
   voucher_id_ := NULL;
   $IF Component_Intled_SYS.INSTALLED $THEN
      IF (Voucher_Type_API.Get_Use_Manual (headrec_.company,
                                           headrec_.voucher_type) = 'TRUE') THEN
         FOR rec_ IN get_vourow LOOP  
            manual_found_ := (manual_found_ OR
                              (Internal_Voucher_Util_Pub_API.Check_If_Manual (rec_.company,
                                                                              rec_.account,
                                                                              headrec_.voucher_date) IS NOT NULL));
         END LOOP;
      END IF;
   $END

   IF (NOT manual_found_) THEN
      -- set proj_conn_created flag -> 'TRUE means either project connections
      -- will get created through this method, or they will be created seperately later by the relavent product.
      -- Need to set this flag before Ready_To_Update__() to avoid project connection creation at the status change 'Approved'.
      UPDATE   voucher_tab
           SET   proj_conn_created = 'TRUE'                  
           WHERE company           = headrec_.company
           AND   accounting_year   = headrec_.accounting_year
           AND   voucher_type      = headrec_.voucher_type
           AND   voucher_no        = headrec_.voucher_no;
      
      -- Bug 126851, Begin.
      Balance_Parallel_Diff___(headrec_.company,
                               headrec_.voucher_type,
                               headrec_.accounting_year,
                               headrec_.voucher_no,
                               headrec_.function_group);
      -- Bug 126851, End.
      IF cancel_option_ THEN
         BEGIN
            Ready_To_Update__ ( info_save_,
                                objid_,
                                objversion_,
                                attr_,
                                'DO',
                                object_conn_handling_);
         EXCEPTION WHEN OTHERS THEN
            IF (Instr(SQLERRM,'NOVOUCHERROW') != 0 ) THEN
               Cancel__( info_save_,objid_, objversion_, attr_, 'DO' );
            ELSE 
                RAISE ;
            END IF;
         END;
      ELSE
         Ready_To_Update__ ( info_save_,
                             objid_,
                             objversion_,
                             attr_,
                             'DO',
                             object_conn_handling_);
      END IF;
      headrec_.approved_by_userid     := User_Finance_API.User_Id;
      IF (headrec_.user_group IS NULL) THEN
         headrec_.approved_by_user_group := User_Group_Member_Finance_Api.get_default_group( headrec_.company,
                                                                                             headrec_.approved_by_userid );
      ELSE
         headrec_.approved_by_user_group := headrec_.user_group;
      END IF;
      
      authorize_level_ := Authorize_Level_API.Encode
                          (Voucher_Type_User_Group_API.Get_Authorize_Level
                                                      (headrec_.company,
                                                       headrec_.accounting_year,
                                                       headrec_.approved_by_user_group,
                                                       headrec_.voucher_type));
      IF (authorize_level_ = 'Approved') THEN      
         UPDATE   voucher_tab
            SET   approval_date           = SYSDATE,
                  approved_by_userid      = headrec_.approved_by_userid,
                  approved_by_user_group  = headrec_.approved_by_user_group
            WHERE company         = headrec_.company
            AND   accounting_year = headrec_.accounting_year
            AND   voucher_type    = headrec_.voucher_type
            AND   voucher_no      = headrec_.voucher_no;

         $IF Component_Intled_SYS.INSTALLED $THEN
            ledger_id_    := Voucher_Type_Api.Get_Ledger_Id(headrec_.company, headrec_.voucher_type);
            IF (ledger_id_ != '00') THEN
               INTERNAL_VOUCHER_UTIL_PUB_API.Update_Approval_Info(headrec_.company,
                                                                  headrec_.voucher_type,
                                                                  headrec_.voucher_no,
                                                                  headrec_.accounting_year,
                                                                  headrec_.approved_by_userid,
                                                                  headrec_.approved_by_user_group);
            END IF;
         $ELSE
            NULL;
         $END
      END IF;
    END IF;
EXCEPTION
   WHEN call_error_voucher_end THEN
      Error_SYS.Record_General(lu_name_, 'WRONGCALLORD1: Wrong calling order when creating voucher in waittable.');
   WHEN notfound_ THEN
      Error_SYS.Record_General(lu_name_,'VOUNOTEXIST: Voucher Does Not Exist.');
END Voucher_End;


-- Voucher_Type_Delete_Allowed
--   This procedure checks if a voucher exists in waiting table with a certain
--   voucher type. If the voucher type exists an exception is raised and
--   deletion of this voucher type is not allowed.
PROCEDURE Voucher_Type_Delete_Allowed (
   company_            IN VARCHAR2,
   voucher_type_       IN VARCHAR2 )
IS
   dummy_ VARCHAR2(1);
   exist  EXCEPTION;

   CURSOR voucher_type_exist IS
      SELECT  'X'
      FROM    VOUCHER_TAB
      WHERE   company      = company_
      AND     voucher_type = voucher_type_;
BEGIN
   OPEN voucher_type_exist;
   FETCH voucher_type_exist INTO dummy_;
   IF voucher_type_exist%FOUND THEN
      CLOSE voucher_type_exist;
      RAISE exist;
   END IF;
   CLOSE voucher_type_exist;
EXCEPTION
   WHEN exist THEN
      CLOSE voucher_type_exist;
      Error_SYS.record_general(lu_name_, 'VOUTYPEEXIST: Delete is not allowed. Voucher type :P1 exists in Voucher',voucher_type_);
END Voucher_Type_Delete_Allowed;


PROCEDURE Check_Voucher (
   attr_ IN VARCHAR2 )
IS
   dummy_            VARCHAR2(1);
   company_          VARCHAR2(20);
   voucher_type_     VARCHAR2(3);
   accounting_year_  NUMBER := NULL;
   ptr_              NUMBER;
   name_             VARCHAR2(30);
   value_            VARCHAR2(2000);
   action_           VARCHAR2(100);
   CURSOR voucher_exist IS
      SELECT  'X'
      FROM    VOUCHER_TAB
      WHERE   company      = company_
        AND   voucher_type = voucher_type_
        AND   accounting_year = decode(accounting_year_, NULL, accounting_year, accounting_year_);
BEGIN
   WHILE (Client_SYS.Get_Next_From_Attr(attr_, ptr_, name_, value_)) LOOP
      IF (name_ = 'COMPANY') THEN
         company_ := value_;
      ELSIF (name_ = 'VOUCHER_TYPE') THEN
         voucher_type_ := value_;
      ELSIF (name_ = 'ACCOUNTING_YEAR') THEN
         accounting_year_ := value_;
      ELSIF (name_ = 'ACTION') THEN
         action_ := value_;
      END IF;
   END LOOP;
   IF (action_ = 'DELETE') THEN
      Voucher_Type_Delete_Allowed ( company_,
                                    voucher_type_);
   ELSE
      OPEN voucher_exist;
      FETCH voucher_exist INTO dummy_;
      IF voucher_exist%FOUND THEN
         CLOSE voucher_exist;
         Error_SYS.record_general(lu_name_, 'VOUEXIST2: You are not allowed to modify a Function Group that is in use for Voucher Type :P1', voucher_type_);
      END IF;
      CLOSE voucher_exist;
   END IF;
END Check_Voucher;


PROCEDURE Interim_Voucher (
   voucher_type_           IN     VARCHAR2,
   voucher_no_             IN     NUMBER,
   accounting_year_        IN     NUMBER,
   company_                IN     VARCHAR2,
   voucher_type_ref_       IN     VARCHAR2,
   date_voucher_ref_       IN     DATE,
   accounting_year_ref_    IN     NUMBER,
   accounting_period_ref_  IN     NUMBER  )
IS
   attr_                  VARCHAR2(2000);
   lu_rec_                VOUCHER_TAB%ROWTYPE;
   rowverion_             VOUCHER_TAB.rowversion%TYPE;
   voucher_status_        VARCHAR2(200);
   objid_                 VARCHAR2(100);
   objversion_            VARCHAR2(2000);
   user_group_of_user_    user_group_member_finance_tab.user_group%type;
   automatic_             VARCHAR2(1);
   head_rec_              Voucher_Tab%ROWTYPE;
   ledger_id_             VARCHAR2(10);

BEGIN
   lu_rec_ := Get_Object_by_Keys___(company_,
                                    accounting_year_,
                                    voucher_type_ ,
                                    voucher_no_);
   voucher_status_ := Voucher_Status_API.Decode(lu_rec_.rowstate);

   lu_rec_.voucher_type              := voucher_type_ref_;
   lu_rec_.accounting_year           := accounting_year_ref_;
   lu_rec_.voucher_no                := 0;
   lu_rec_.voucher_date              := date_voucher_ref_;
   lu_rec_.interim_voucher           := 'Y';
   lu_rec_.accounting_period         := accounting_period_ref_;
   lu_rec_.voucher_type_reference    := voucher_type_;
   lu_rec_.accounting_year_reference := accounting_year_;
   lu_rec_.voucher_no_reference      := voucher_no_;
   lu_rec_.voucher_updated           := 'N';
   lu_rec_.date_reg                  := sysdate;
   lu_rec_.rowstate                  := NULL;
   lu_rec_.function_group := Voucher_Type_Detail_API.Get_Function_Group (lu_rec_.company,
                                                                         voucher_type_ref_);
   lu_rec_.simulation_voucher := Voucher_Type_API.Get_Simulation_Voucher (lu_rec_.company,
                                                                          voucher_type_ref_);
   user_group_of_user_ := User_Group_Member_Finance_API.Get_User_Group (lu_rec_.company,
                                                                        Fnd_Session_API.Get_Fnd_User);

   Error_SYS.Check_Not_Null(lu_name_, 'COMPANY', lu_rec_.company);
   Error_SYS.Check_Not_Null(lu_name_, 'ACCOUNTING_YEAR', lu_rec_.accounting_year);
   Error_SYS.Check_Not_Null(lu_name_, 'VOUCHER_TYPE', lu_rec_.voucher_type);
   Error_SYS.Check_Not_Null(lu_name_, 'VOUCHER_NO', lu_rec_.voucher_no);
   Error_SYS.Check_Not_Null(lu_name_, 'VOUCHER_DATE', lu_rec_.voucher_date);
   Error_SYS.Check_Not_Null(lu_name_, 'DATE_REG', lu_rec_.date_reg);

   Validate_At_New___ (FALSE,
                       lu_rec_);

   IF  Authorize_Level_API.Encode(Voucher_Type_User_Group_API.Get_Authorize_Level(lu_rec_.company, lu_rec_.accounting_year, user_group_of_user_, lu_rec_.voucher_type))='Not Approved' THEN
      Error_Sys.Record_General( 'Voucher', 'STATUSINVALID: Current user is not allowed to change the Status to Approved.');
   END IF;
   lu_rec_.entered_by_user_group  := lu_rec_.user_group;
   lu_rec_.approval_date          := SYSDATE;
   lu_rec_.approved_by_userid     := lu_rec_.userid;
   lu_rec_.approved_by_user_group := lu_rec_.user_group;

   automatic_ := Voucher_Type_API.Check_Automatic (lu_rec_.company,
                                                   lu_rec_.voucher_type);
   IF ( automatic_ = 'Y' ) THEN
      IF (lu_rec_.voucher_no = 0) THEN
         Voucher_No_Serial_API.Get_Next_Voucher_No (lu_rec_.voucher_no,
                                                    lu_rec_.company,
                                                    lu_rec_.voucher_type,
                                                    lu_rec_.voucher_date,
                                                    lu_rec_.accounting_year,
                                                    lu_rec_.accounting_period);
      ELSE
         Error_Sys.Record_General(lu_name_,'NOTMANUAL: Voucher Number should be assigned automatically');
      END IF;
   ELSE
      Voucher_No_Serial_API.Check_Voucher_No(lu_rec_.company,
                                             lu_rec_.voucher_date,
                                             lu_rec_.voucher_type,
                                             lu_rec_.voucher_no,
                                             lu_rec_.accounting_year,
                                             lu_rec_.accounting_period);
   END IF;

   Voucher_Type_API.Validate_Vou_Type_All_Gen (lu_rec_.company,
                                               lu_rec_.voucher_type);

   lu_rec_.rowkey := NULL;
   Insert___(objid_, objversion_, lu_rec_, attr_);
   Finite_State_Set___(lu_rec_, 'Confirmed');
   rowverion_ := sysdate;
   UPDATE VOUCHER_TAB
      SET voucher_type_reference = voucher_type_ref_ ,
          accounting_year_reference = accounting_year_ref_,
          voucher_no_reference = lu_rec_.voucher_no,
          interim_voucher = 'Y' ,
          rowversion = rowverion_
   WHERE  company         = company_
   AND    voucher_type    = voucher_type_
   AND    voucher_no      = voucher_no_
   AND    accounting_year = accounting_year_;

   ledger_id_ := Voucher_Type_API.Get_Ledger_Id (company_,
                                                 voucher_type_ref_ );
   head_rec_.company                   := lu_rec_.company;
   head_rec_.voucher_type              := lu_rec_.voucher_type;
   head_rec_.accounting_year           := lu_rec_.accounting_year;
   head_rec_.voucher_no                := lu_rec_.voucher_no ;
   head_rec_.voucher_date              := lu_rec_.voucher_date ;
   head_rec_.interim_voucher           := lu_rec_.interim_voucher;
   head_rec_.accounting_period         := lu_rec_.accounting_period;
   head_rec_.voucher_type_reference    := lu_rec_.voucher_type_reference;
   head_rec_.accounting_year_reference := lu_rec_.accounting_year_reference ;
   head_rec_.voucher_no_reference      := lu_rec_.voucher_no_reference;
   head_rec_.voucher_updated           := lu_rec_.voucher_updated ;
   head_rec_.date_reg                  := lu_rec_.date_reg;
   head_rec_.userid                    := Fnd_Session_API.Get_Fnd_User ;
   head_rec_.entered_by_user_group     := lu_rec_.entered_by_user_group;
   head_rec_.user_group                := lu_rec_.user_group;
   head_rec_.approval_date             := lu_rec_.approval_date;
   head_rec_.approved_by_userid        := lu_rec_.approved_by_userid ;
   head_rec_.approved_by_user_group    := lu_rec_.approved_by_user_group;

   $IF Component_Intled_SYS.INSTALLED $THEN
      IF (ledger_id_ ='*') THEN
         Internal_Voucher_Util_Pub_API.Create_Internal_Head (head_rec_);
      END IF;
   $END

   Voucher_Row_API.Interim_Voucher ( voucher_type_,
                                     voucher_no_,
                                     accounting_year_,
                                     company_,
                                     voucher_type_ref_,
                                     lu_rec_.voucher_no,
                                     accounting_year_ref_);
END Interim_Voucher;


PROCEDURE Interim_Voucher (
   voucher_type_           IN     VARCHAR2,
   voucher_no_             IN     NUMBER,
   accounting_year_        IN     NUMBER,
   company_                IN     VARCHAR2,
   voucher_type_ref_       IN     VARCHAR2,
   date_voucher_ref_       IN     DATE,
   accounting_year_ref_    IN     NUMBER,
   accounting_period_ref_  IN     NUMBER,
   interim_user_grp_ref_   IN     VARCHAR2  )
IS
   attr_                  VARCHAR2(2000);
   lu_rec_                VOUCHER_TAB%ROWTYPE;
   rowverion_             VOUCHER_TAB.rowversion%TYPE;
   voucher_status_        VARCHAR2(200);
   objid_                 VARCHAR2(100);
   objversion_            VARCHAR2(2000);
   automatic_             VARCHAR2(1);
   head_rec_              Voucher_Tab%ROWTYPE;
   ledger_id_             VARCHAR2(10);
   -- Bug 108417, Begin
   final_voucher_no_      NUMBER;
   -- Bug 108417, End

BEGIN

   -- Validate if Interim voucher can be created
   Interim_Vou_Check_Ok___(voucher_type_     ,
                           voucher_no_       ,
                           accounting_year_  ,
                           company_          );

   
   lu_rec_ := Get_Object_by_Keys___(company_,
                                    accounting_year_,
                                    voucher_type_ ,
                                    voucher_no_);

   lu_rec_.user_group :=  interim_user_grp_ref_;
   lu_rec_.userid     :=  Fnd_Session_API.Get_Fnd_User;

   voucher_status_ := Voucher_Status_API.Decode(lu_rec_.rowstate);

   lu_rec_.voucher_type              := voucher_type_ref_;
   lu_rec_.accounting_year           := accounting_year_ref_;
   lu_rec_.voucher_no                := 0;
   lu_rec_.voucher_date              := date_voucher_ref_;
   lu_rec_.interim_voucher           := 'Y';
   lu_rec_.accounting_period         := accounting_period_ref_;
   lu_rec_.voucher_type_reference    := voucher_type_;
   lu_rec_.accounting_year_reference := accounting_year_;
   lu_rec_.voucher_no_reference      := voucher_no_;
   lu_rec_.voucher_updated           := 'N';
   lu_rec_.date_reg                  := sysdate;
   lu_rec_.rowstate                  := NULL;
   lu_rec_.function_group := Voucher_Type_Detail_API.Get_Function_Group (lu_rec_.company,
                                                                         voucher_type_ref_);
   lu_rec_.simulation_voucher := Voucher_Type_API.Get_Simulation_Voucher (lu_rec_.company,
                                                                          voucher_type_ref_);
   --user_group_of_user_ := User_Group_Member_Finance_API.Get_User_Group (lu_rec_.company,
                                                                        --Fnd_Session_API.Get_Fnd_User); 

   -- Bug 108417, Begin Added Fictive to voucher_no.
   automatic_ := Voucher_Type_API.Check_Automatic(lu_rec_.company, lu_rec_.voucher_type);
   IF ( automatic_ = 'Y' ) THEN
      IF (lu_rec_.voucher_no = 0) THEN
         lu_rec_.voucher_no     := Get_Fictive_Voucher_No___;
         lu_rec_.transfer_id    := Fetch_Transfer_Id___ (lu_rec_.company,
                                                         lu_rec_.accounting_year,
                                                         lu_rec_.voucher_type,
                                                         lu_rec_.voucher_no);
      ELSE
         -- Bug 83174 Begin, Error message was changed.
         Error_Sys.Record_General(lu_name_,'NOTMANUAL: Voucher Number should be assigned automatically');
         -- Bug 83174 End
      END IF;
   ELSE
      Voucher_No_Serial_API.Check_Voucher_No(lu_rec_.company,
                                             lu_rec_.voucher_date,
                                             lu_rec_.voucher_type,
                                             lu_rec_.voucher_no);
   END IF;
   -- Bug 108417, End

   Error_SYS.Check_Not_Null(lu_name_, 'COMPANY', lu_rec_.company);
   Error_SYS.Check_Not_Null(lu_name_, 'ACCOUNTING_YEAR', lu_rec_.accounting_year);
   Error_SYS.Check_Not_Null(lu_name_, 'VOUCHER_TYPE', lu_rec_.voucher_type);
   Error_SYS.Check_Not_Null(lu_name_, 'VOUCHER_NO', lu_rec_.voucher_no);
   Error_SYS.Check_Not_Null(lu_name_, 'VOUCHER_DATE', lu_rec_.voucher_date);
   Error_SYS.Check_Not_Null(lu_name_, 'DATE_REG', lu_rec_.date_reg);

   Validate_At_New___ (FALSE,
                       lu_rec_);

   lu_rec_.entered_by_user_group  := lu_rec_.user_group;
   lu_rec_.approval_date          := SYSDATE;
   lu_rec_.approved_by_userid     := lu_rec_.userid;
   lu_rec_.approved_by_user_group := lu_rec_.user_group;

   -- Bug 108417,Moved code up

   Voucher_Type_API.Validate_Vou_Type_All_Gen (lu_rec_.company,
                                               lu_rec_.voucher_type);

   lu_rec_.rowkey := NULL;
   Insert___(objid_, objversion_, lu_rec_, attr_);
   IF  Authorize_Level_API.Encode(Voucher_Type_User_Group_API.Get_Authorize_Level(lu_rec_.company, lu_rec_.accounting_year, lu_rec_.user_group, lu_rec_.voucher_type))='Not Approved' THEN
      Finite_State_Set___(lu_rec_, 'Waiting');
   ELSE
   Finite_State_Set___(lu_rec_, 'Confirmed');
   END IF;
   rowverion_ := sysdate;

   -- Bug 108417, Moved code below.
   ledger_id_ := Voucher_Type_API.Get_Ledger_Id (company_,
                                                 voucher_type_ref_ );
   head_rec_.company                   := lu_rec_.company;
   head_rec_.voucher_type              := lu_rec_.voucher_type;
   head_rec_.accounting_year           := lu_rec_.accounting_year;
   head_rec_.voucher_no                := lu_rec_.voucher_no ;
   head_rec_.voucher_date              := lu_rec_.voucher_date ;
   head_rec_.interim_voucher           := lu_rec_.interim_voucher;
   head_rec_.accounting_period         := lu_rec_.accounting_period;
   head_rec_.voucher_type_reference    := lu_rec_.voucher_type_reference;
   head_rec_.accounting_year_reference := lu_rec_.accounting_year_reference ;
   head_rec_.voucher_no_reference      := lu_rec_.voucher_no_reference;
   head_rec_.voucher_updated           := lu_rec_.voucher_updated ;
   head_rec_.date_reg                  := lu_rec_.date_reg;
   head_rec_.userid                    := Fnd_Session_API.Get_Fnd_User ;
   head_rec_.entered_by_user_group     := lu_rec_.entered_by_user_group;
   head_rec_.user_group                := lu_rec_.user_group;
   head_rec_.approval_date             := lu_rec_.approval_date;
   head_rec_.approved_by_userid        := lu_rec_.approved_by_userid ;
   head_rec_.approved_by_user_group    := lu_rec_.approved_by_user_group;
   -- Bug 108417, Begin 
   head_rec_.transfer_id               := lu_rec_.transfer_id;
   -- Bug 108417, End

   $IF Component_Intled_SYS.INSTALLED $THEN
      IF (ledger_id_ ='*') THEN
         Internal_Voucher_Util_Pub_API.Create_Internal_Head (head_rec_);
      END IF;
   $END

   -- Bug 108417, Begin Added new parameter transfer_id.
   Voucher_Row_API.Interim_Voucher ( voucher_type_,
                                     voucher_no_,
                                     accounting_year_,
                                     company_,
                                     voucher_type_ref_,
                                     lu_rec_.voucher_no,
                                     accounting_year_ref_,
                                     lu_rec_.transfer_id);

   Finalize_Interim_Voucher___ ( final_voucher_no_,
                                 company_,
                                 voucher_type_ref_,
                                 lu_rec_.transfer_id);
   UPDATE VOUCHER_TAB
   SET voucher_type_reference = voucher_type_ref_ ,
       accounting_year_reference = accounting_year_ref_,
       voucher_no_reference = final_voucher_no_,
       interim_voucher = 'Y' ,
       rowversion = rowverion_
   WHERE  company         = company_
   AND    voucher_type    = voucher_type_
   AND    voucher_no      = voucher_no_
   AND    accounting_year = accounting_year_;

   -- Bug 108417,Moved from Voucher_Row_API.Interim_Voucher()
   IF (company_ IS NOT NULL) THEN
      Voucher_Row_API.Create_Object_Connection( lu_rec_.company,
                                                lu_rec_.voucher_type,
                                                lu_rec_.accounting_year,
                                                final_voucher_no_);
   END IF;
   -- Bug 108417, End
                                    
END Interim_Voucher;


@UncheckedAccess
FUNCTION Get_My_Conv_Factor (
   company_         IN  VARCHAR2,
   voucher_type_    IN  VARCHAR2,
   accounting_year_ IN  NUMBER,
   voucher_no_      IN  NUMBER,
   currency_code_   IN  VARCHAR2 )  RETURN NUMBER
IS
   conv_factor_    NUMBER;
   currency_type_  VARCHAR2(10);
   voucher_date_   DATE;
BEGIN
   voucher_date_  := Get_Voucher_Date (company_,
                                      accounting_year_,
                                      voucher_type_,
                                      voucher_no_);
   currency_type_ := Currency_Type_API.Get_default_Type (company_);
   conv_factor_   := Currency_Rate_API.Get_Conv_Factor (company_,
                                                        currency_code_,
                                                        currency_type_,
                                                        voucher_date_);
   RETURN (conv_factor_);
END Get_My_Conv_Factor;


PROCEDURE Check_If_Postings_In_Voucher (
   result_              OUT   VARCHAR2,
   company_             IN    VARCHAR2,
   accounting_period_   IN    NUMBER,
   accounting_year_     IN    NUMBER )
IS
   postings_   NUMBER;
   CURSOR check_postings IS
      SELECT 1
      FROM   VOUCHER_TAB
      WHERE  company           = company_
      AND    accounting_year   = accounting_year_
      AND    accounting_period = accounting_period_
      AND    voucher_updated   = 'N'; -- ANDJ 97-10-01.
BEGIN
   OPEN check_postings;
   FETCH check_postings INTO postings_;
   IF (check_postings%FOUND) THEN
      result_ := 'TRUE';
   ELSE
      result_ := 'FALSE';
   END IF;
   CLOSE check_postings;
END Check_If_Postings_In_Voucher;


-- Period_Delete_Allowed
--   This procedure checks if any vouchers exists in waiting table with voucher
--   dates corresponding to a certain period. If period exists an exception
--   is raised and deletion of this period is not allowed.
--   Only to support 7.3.1
--   Only to support 7.3.1
--   PCA functionality
PROCEDURE Period_Delete_Allowed (
   attr_               IN VARCHAR2 )
IS
   dummy_               VARCHAR2(1);
   company_             VARCHAR2(20);
   accounting_year_     NUMBER;
   accounting_period_   NUMBER;
   ptr_                 NUMBER;
   name_                VARCHAR2(30);
   value_               VARCHAR2(2000);
CURSOR check_period IS
   SELECT  'Y'
   FROM    VOUCHER_TAB
   WHERE   company           = company_
   AND     accounting_year   = accounting_year_
   AND     accounting_period = accounting_period_;

BEGIN
   dummy_ := 'N';
   WHILE (Client_SYS.Get_Next_From_Attr(attr_, ptr_, name_, value_)) LOOP
      IF (name_ = 'COMPANY') THEN
         company_ := value_;
      END IF;
      IF (name_ = 'ACCOUNTING_YEAR') THEN
         accounting_year_ := value_;
      END IF;
      IF (name_ = 'ACCOUNTING_PERIOD') THEN
         accounting_period_ := value_;
      END IF;
   END LOOP;
   OPEN check_period;
   FETCH check_period INTO dummy_;
   IF dummy_ = 'Y' THEN
      CLOSE check_period;
      Error_SYS.Record_General(lu_name_,'NO_DEL: It is not allowed to delete a period when there are transactions in General Ledger for this period');
   ELSE
      CLOSE check_period;
   END IF;
END Period_Delete_Allowed;


PROCEDURE Voucher_Init (
  voucher_type_       IN OUT VARCHAR2,
  voucher_no_         IN OUT NUMBER,
  voucher_id_         IN OUT VARCHAR2,
  period_             IN OUT NUMBER,
  company_            IN     VARCHAR2,
  transfer_id_        IN     NUMBER,
  voucher_date_       IN     DATE,
  reference_          IN     VARCHAR2,
  user_name_          IN     VARCHAR2,
  curr_code_          IN     VARCHAR2 )
IS
   correction_          VARCHAR2(20);  -- This variable isn't used anymore
   accounting_year_     NUMBER;
   accounting_period_   NUMBER;
   voucher_group_       VARCHAR2(10);
   user_group_          user_group_member_finance_tab.user_group%type;
BEGIN
   correction_ := 'N';                 -- This Stat. isn't used anymore
   voucher_group_ := reference_;
   user_group_ := User_Group_Member_Finance_Api.get_default_group ( company_,
                                                                    user_name_ );
   New_Voucher ( voucher_type_,
                 voucher_no_,
                 voucher_id_,
                 accounting_year_,
                 accounting_period_,
                 company_,
                 transfer_id_,
                 voucher_date_,
                 voucher_group_,
                 user_group_,
                 correction_ );
   period_ := to_number (substr( to_char(accounting_year_)||lpad(to_char(accounting_period_),2,'0'), 3, 6 ) );
END Voucher_Init;


PROCEDURE Get_Voucher_Type (
   voucher_type_     OUT VARCHAR2,
   company_          IN  VARCHAR2,
   user_group_       IN  VARCHAR2,
   reference_        IN  VARCHAR2,
   voucher_date_     IN  DATE )
IS
   accounting_year_  NUMBER;
   voucher_group_    VARCHAR2(20);
BEGIN
   accounting_year_ := Accounting_Period_API.Get_Accounting_Year ( company_,
                                                                   voucher_date_ );
-- voucher_group is DB value.
   voucher_group_ := reference_;
   Voucher_Type_User_Group_Api.get_default_voucher_type ( voucher_type_,
                                                          company_,
                                                          user_group_,
                                                          accounting_year_,
                                                          voucher_group_ );
END Get_Voucher_Type;


@UncheckedAccess
FUNCTION Get_Correction (
   company_          IN VARCHAR2,
   accounting_year_  IN NUMBER,
   voucher_no_       IN NUMBER,
   voucher_type_     IN VARCHAR2 ) RETURN VARCHAR2
IS
BEGIN
   RETURN 'N';
END Get_Correction;


PROCEDURE Mark_Voucher_Updated (
   company_         IN VARCHAR2,
   accounting_year_ IN NUMBER,
   voucher_type_    IN VARCHAR2,
   voucher_no_      IN NUMBER )
IS
   row_                VOUCHER_TAB%ROWTYPE;
   info_               VARCHAR2(2000);
   attr_               VARCHAR2(2000);
   objid_              VOUCHER.OBJID%TYPE;
   objversion_         VOUCHER.OBJVERSION%TYPE;
BEGIN
   row_ := Get_Object_By_Keys___( company_,
                                  accounting_year_,
                                  voucher_type_,
                                  voucher_no_ );

   Client_SYS.Clear_Attr( attr_ );
   Client_SYS.Add_To_Attr( 'VOUCHER_UPDATED', Voucher_Updated_API.Decode('Y'), attr_ );
   Get_Id_Version_By_Keys___( objid_,
                              objversion_,
                              company_,
                              accounting_year_,
                              voucher_type_,
                              voucher_no_ );
   Modify__(info_, objid_ , objversion_ , attr_, 'DO');
END Mark_Voucher_Updated;


PROCEDURE Voucher_Save_Ok (
   result_          IN OUT  VARCHAR2,
   company_         IN      VARCHAR2,
   voucher_type_    IN      VARCHAR2,
   accounting_year_ IN      NUMBER,
   voucher_no_      IN      NUMBER )
IS
   CURSOR get_rows_no IS
      SELECT 1
      FROM   VOUCHER_ROW_TAB
      WHERE  company         = company_
      AND    voucher_type    = voucher_type_
      AND    accounting_year = accounting_year_
      AND    voucher_no      = voucher_no_;
   CURSOR get_status IS
      SELECT rowstate
      FROM   VOUCHER_TAB
      WHERE  company         = company_
      AND    voucher_type    = voucher_type_
      AND    accounting_year = accounting_year_
      AND    voucher_no      = voucher_no_;
   cnt_                 NUMBER;
   vou_status_          VARCHAR2(20);
BEGIN
   -- check, if there are voucher rows ....
   OPEN  get_rows_no;
   FETCH get_rows_no INTO cnt_;
   IF (get_rows_no%NOTFOUND) THEN
      CLOSE get_rows_no;
      result_ := 'FALSE';
   ELSE
      CLOSE get_rows_no;
      OPEN get_status;
      FETCH get_status INTO vou_status_;
      CLOSE get_status;
      IF (vou_status_ = 'Confirmed') THEN
         Validate_Voucher_In_Balance___(company_,
                                        voucher_type_,
                                        accounting_year_,
                                        voucher_no_);
      END IF;
      result_ := 'TRUE';
   END IF;
END Voucher_Save_Ok;


PROCEDURE Voucher_Info_For_Pca (
   total_vouchers_        IN OUT NUMBER,
   vouchers_with_costs_   IN OUT NUMBER,
   vouchers_with_error_   IN OUT NUMBER,
   company_               IN     VARCHAR2,
   accounting_year_       IN     NUMBER,
   accounting_period_     IN     NUMBER )
IS
   CURSOR get_total_vouchers IS
      SELECT count(*)
      FROM   VOUCHER_TAB
      WHERE  company            = company_
      AND    accounting_year    = accounting_year_
      AND    accounting_period  = accounting_period_
      AND    voucher_updated   != 'Y';
   CURSOR get_error_vouchers IS
      SELECT 1
      FROM   VOUCHER_TAB
      WHERE  company            = company_
      AND    accounting_year    = accounting_year_
      AND    accounting_period  = accounting_period_
      AND    voucher_updated   != 'Y'
      AND    rowstate           = 'Error';
   CURSOR get_vou_with_cost_accnts IS
      SELECT count(distinct vou.voucher_no)
      FROM   VOUCHER_TAB     vou,
             VOUCHER_ROW_TAB vou_row
      WHERE  vou.company            = vou_row.company
      AND    vou.voucher_type       = vou_row.voucher_type
      AND    vou.accounting_year    = vou_row.accounting_year
      AND    vou.voucher_no         = vou_row.voucher_no
      AND    accounting_code_part_a_api.get_accnt_type_db(vou_row.company,vou_row.account)
                                    = 'C'
      AND    vou.company            = company_
      AND    vou.accounting_year    = accounting_year_
      AND    vou.accounting_period  = accounting_period_
      AND    voucher_updated       != 'Y';
BEGIN
   OPEN  get_total_vouchers;
   FETCH get_total_vouchers INTO total_vouchers_;
   CLOSE get_total_vouchers;
   IF (total_vouchers_ = 0) THEN
      vouchers_with_costs_ := 0;
      vouchers_with_error_ := 0;
      RETURN;
   END IF;
   OPEN  get_error_vouchers;
   FETCH get_error_vouchers INTO vouchers_with_error_;
   CLOSE get_error_vouchers;
   OPEN  get_vou_with_cost_accnts;
   FETCH get_vou_with_cost_accnts INTO vouchers_with_costs_;
   CLOSE get_vou_with_cost_accnts;
END Voucher_Info_For_Pca;


@UncheckedAccess
FUNCTION Show_Pca_Vouchers (
   company_                IN VARCHAR2,
   voucher_type_           IN VARCHAR2,
   use_pca_                IN VARCHAR2 ) RETURN VARCHAR2
IS
   voucher_group_          VARCHAR2(10);
BEGIN
   voucher_group_ := Voucher_Type_API.Get_Voucher_Group (company_,
                                                         voucher_type_);
   IF (voucher_group_ != 'Z') THEN
      RETURN 'TRUE';
   ELSE
      IF (use_pca_ = 'TRUE') THEN
         RETURN 'TRUE';
      ELSE
         RETURN 'FALSE';
      END IF;
   END IF;
   RETURN 'FALSE';
END Show_Pca_Vouchers;


@UncheckedAccess
FUNCTION Process_Pca_Vouchers (
   company_                 IN VARCHAR2 ) RETURN VARCHAR2
IS
   user_group_           user_group_member_finance_tab.user_group%type;
BEGIN
   IF (Is_Lu_Installed('COST_ALLOCATION_PROCEDURE_API')='TRUE') THEN
      -- use dynamic SQL to call function from Percos module ....
      user_group_ := User_Group_Member_Finance_API.Get_User_Group (company_,
                                                                   User_Finance_API.User_Id);
      RETURN 'TRUE';
   END IF;
   RETURN 'FALSE';
END Process_Pca_Vouchers;


@UncheckedAccess
FUNCTION Is_Lu_Installed (
   name_                   IN VARCHAR2 ) RETURN VARCHAR2
IS
   dummy_ NUMBER;
   CURSOR find_name IS
      SELECT 1
      FROM   user_objects
      WHERE  object_name = name_
      AND    object_type = 'PACKAGE BODY';
BEGIN
   OPEN find_name;
   FETCH find_name INTO dummy_;
   IF (find_name%FOUND) THEN
      CLOSE find_name;
      RETURN 'TRUE';
   END IF;
   CLOSE find_name;
   RETURN 'FALSE';
END Is_Lu_Installed;


FUNCTION Get_Balance_Voucher (
   company_         IN  VARCHAR2,
   voucher_type_    IN  VARCHAR2,
   accounting_year_ IN  NUMBER,
   voucher_no_      IN  NUMBER ) RETURN NUMBER
IS
   acc_curr_bal_        NUMBER;
   par_curr_bal_        NUMBER;
BEGIN
   Get_Balance_Voucher_All___(acc_curr_bal_,
                              par_curr_bal_,
                              company_,
                              voucher_type_,
                              accounting_year_,
                              voucher_no_);
   RETURN acc_curr_bal_;                             
END Get_Balance_Voucher;


PROCEDURE Create_Pca_Voucher (
   voucher_no_        OUT VARCHAR2,
   company_           IN VARCHAR2,
   accounting_year_   IN NUMBER,
   accounting_period_ IN NUMBER,
   voucher_type_      IN VARCHAR2,
   voucher_date_      IN DATE,
   user_group_        IN VARCHAR2 )
IS
   voucher_group_    VARCHAR2(10);
   transfer_id_      VARCHAR2(200);
   correction_       VARCHAR2(1);
   voucher_id_       VARCHAR2(300);
   voucher_no_temp_       NUMBER;
   accounting_year_temp_ NUMBER;
   user_group_temp_      user_group_member_finance_tab.user_group%type;
   accounting_period_temp_ NUMBER;
   voucher_type_temp_   VARCHAR2(3);
BEGIN
   voucher_group_ := Voucher_type_api.Get_voucher_group (company_,
                                                         voucher_type_);
   accounting_year_temp_   := accounting_year_;
   accounting_period_temp_ := accounting_period_;
   user_group_temp_        := user_group_;
   voucher_type_temp_      := voucher_type_;

   New_Voucher (voucher_type_temp_,
                voucher_no_temp_,
                voucher_id_,
                accounting_year_temp_,
                accounting_period_temp_,
                company_,
                transfer_id_,
                voucher_date_,
                voucher_group_,
                user_group_temp_,
                correction_);
   voucher_no_ := to_char(voucher_no_temp_);
END Create_Pca_Voucher;


PROCEDURE Check_If_Postings_In_Vou_User (
   result_              OUT   VARCHAR2,
   company_             IN    VARCHAR2,
   accounting_period_   IN    NUMBER,
   accounting_year_     IN    NUMBER,
   user_group_          IN    VARCHAR2 )
IS
   postings_                 VOUCHER_TAB%ROWTYPE;
   CURSOR check_postings  IS
      SELECT *
      FROM   VOUCHER_TAB
      WHERE  company           = company_
      AND    accounting_year   = accounting_year_
      AND    accounting_period = accounting_period_
      AND    voucher_updated   = 'N'
      AND    user_group        = user_group_;
BEGIN
   OPEN check_postings;
   FETCH check_postings INTO postings_;
   IF check_postings%NOTFOUND THEN
     result_ := 'FALSE';
   ELSE
     result_ := 'TRUE';
   END IF;
   CLOSE check_postings;
END Check_If_Postings_In_Vou_User;


PROCEDURE Get_Reference_Info (
   multi_company_id_    OUT VARCHAR2,
   voucher_type_ref_    OUT VARCHAR2,
   accounting_year_ref_ OUT NUMBER,
   voucher_no_ref_      OUT NUMBER,
   company_             IN  VARCHAR2,
   voucher_type_        IN  VARCHAR2,
   accounting_year_     IN  NUMBER,
   voucher_no_          IN  NUMBER )
IS
   CURSOR getref IS
      SELECT multi_company_id,
             voucher_type_reference,
             accounting_year_reference,
             voucher_no_reference
      FROM   VOUCHER_TAB
      WHERE  company         = company_
      AND    voucher_type    = voucher_type_
      AND    accounting_year = accounting_year_
      AND    voucher_no      = voucher_no_;
BEGIN
   OPEN getref;
   FETCH getref INTO multi_company_id_,
                     voucher_type_ref_,
                     accounting_year_ref_,
                     voucher_no_ref_;
   CLOSE getref;
END Get_Reference_Info;


@UncheckedAccess
FUNCTION Is_Multi_Company_Voucher(
   company_         IN VARCHAR2,
   voucher_type_    IN VARCHAR2,
   accounting_year_ IN NUMBER,
   voucher_no_      IN NUMBER) RETURN VARCHAR2
IS
   temp_ VOUCHER_TAB.multi_company_id%TYPE;
   CURSOR get_attr IS
      SELECT multi_company_id
      FROM VOUCHER_TAB
      WHERE company         = company_
      AND   voucher_type    = voucher_type_
      AND   accounting_year = accounting_year_
      AND   voucher_no      = voucher_no_;
BEGIN
   OPEN get_attr;
   FETCH get_attr INTO temp_;
   CLOSE get_attr;
   IF temp_ IS NOT NULL THEN
      RETURN 'TRUE';
   ELSE
      RETURN 'FALSE';
   END IF;
END Is_Multi_Company_Voucher;


PROCEDURE New_Head (
   attr_ IN OUT VARCHAR2 )
IS
   info_       VARCHAR2(2000);
   objid_      VOUCHER.OBJID%TYPE;
   objversion_ VOUCHER.OBJVERSION%TYPE;
BEGIN
   New__( info_, objid_, objversion_, attr_, 'DO');
END New_Head;


@UncheckedAccess
FUNCTION Is_Voucher_Type_Used (
   company_ IN VARCHAR2,
   voucher_type_ IN VARCHAR2 ) RETURN VARCHAR2
IS
   dummy_   VARCHAR2(10);
   CURSOR voucher_type_exist IS
      SELECT  'X'
      FROM    VOUCHER_TAB
      WHERE   company         = company_
      AND     voucher_type    = voucher_type_;
BEGIN
   OPEN voucher_type_exist;
   FETCH voucher_type_exist INTO dummy_;
   IF voucher_type_exist%FOUND THEN
      CLOSE voucher_type_exist;
      RETURN 'TRUE';
   ELSE
      CLOSE voucher_type_exist;
      RETURN 'FALSE';
   END IF;
END Is_Voucher_Type_Used;


FUNCTION Check_Exist (
   company_         IN VARCHAR2,
   accounting_year_ IN NUMBER,
   voucher_type_    IN VARCHAR2,
   voucher_no_      IN NUMBER ) RETURN BOOLEAN
IS
   dummy_ NUMBER;
   CURSOR exist_control IS
      SELECT 1
      FROM   VOUCHER_TAB
      WHERE  company         = company_
      AND    accounting_year = accounting_year_
      AND    voucher_type    = voucher_type_
      AND    voucher_no      = voucher_no_;
BEGIN
   OPEN exist_control;
   FETCH exist_control INTO dummy_;
   IF (exist_control%FOUND) THEN
      CLOSE exist_control;
      RETURN(TRUE);
   END IF;
   CLOSE exist_control;
   RETURN(FALSE);
END Check_Exist;


PROCEDURE Drop_Voucher (
   company_         IN VARCHAR2,
   accounting_year_ IN NUMBER,
   voucher_type_    IN VARCHAR2,
   voucher_no_      IN NUMBER,
   remove_          IN BOOLEAN DEFAULT TRUE )
IS
BEGIN
   
   -- Note: While this method was written in order to remove a temporary voucher calling from PAYLED, the possibility of
   -- Note: using it as a general public interface for Drop_Voucher_() is retained by the use of the extra DEFAULT parameter
   -- Note: remove_. This is set to TRUE when it is only desired to delete the voucher, otherwise no value may be sent.
   -- Note: In the latter case, the method Drop_Voucher_() is called as done currently from GENLED (note also the unused
   -- Note: parameter function_group_ in the overloaded method Drop_Voucher_()).
   IF remove_ THEN
      Drop_Voucher___(company_, voucher_type_, accounting_year_, voucher_no_, TRUE);
   ELSE
      Voucher_API.Drop_Voucher_(company_, voucher_type_, accounting_year_, voucher_no_);
   END IF;
END Drop_Voucher;


FUNCTION Voucher_Rows_Exist(
   company_         IN VARCHAR2, 
   accounting_year_ IN NUMBER, 
   voucher_no_      IN NUMBER, 
   voucher_type_    IN VARCHAR2) RETURN VARCHAR2

IS
   temp_       NUMBER;
   rows_found_ VARCHAR2(10);
   
   CURSOR find_reverse_rows_ IS
      SELECT 1       
      FROM   VOUCHER_ROW_TAB
      WHERE  company         = company_
      AND    voucher_type    = voucher_type_
      AND    accounting_year = accounting_year_
      AND    voucher_no      = voucher_no_;

BEGIN
   OPEN find_reverse_rows_;
   FETCH find_reverse_rows_ INTO temp_;
   IF(find_reverse_rows_%NOTFOUND) THEN
      rows_found_:= 'FALSE';
   ELSE
      rows_found_:= 'TRUE';
   END IF;
   CLOSE find_reverse_rows_;
   RETURN rows_found_;
END Voucher_Rows_Exist;


PROCEDURE Is_User_Group_Used (
   is_used_         OUT VARCHAR2,
   company_         IN VARCHAR2,
   voucher_type_    IN VARCHAR2,
   user_group_      IN VARCHAR2,
   accounting_year_ IN NUMBER )
IS
   dummy_hold_   VARCHAR2(10);
   CURSOR user_group_exist_hold IS
      SELECT  1
      FROM    VOUCHER_TAB
      WHERE   company         = company_
      AND     voucher_type    = voucher_type_
      AND     user_group      = user_group_
      AND     accounting_year = accounting_year_
      AND     voucher_updated = 'N';

BEGIN
   is_used_ := 'FALSE';
   OPEN user_group_exist_hold;
   FETCH user_group_exist_hold INTO dummy_hold_;
   IF user_group_exist_hold%FOUND THEN
      is_used_ := 'TRUE';
   END IF;
   CLOSE user_group_exist_hold;
END Is_User_Group_Used;


@UncheckedAccess
FUNCTION Is_Cancel_Vou_Exist_Hold (
   company_                IN    VARCHAR2,
   voucher_type_           IN    VARCHAR2,
   voucher_no_             IN    NUMBER, 
   acc_year_               IN    NUMBER ) RETURN VARCHAR2
IS
   dummy_ NUMBER;
   CURSOR get_cancelled_vouchers IS
      SELECT   1
        FROM   voucher_tab t
        WHERE  t.company                   = company_
         AND   t.voucher_type_reference    = voucher_type_
         AND   t.voucher_no_reference      = voucher_no_
         AND   t.accounting_year_reference = acc_year_
         AND   t.voucher_updated           = 'N';
BEGIN
   OPEN  get_cancelled_vouchers;
   FETCH get_cancelled_vouchers INTO dummy_; 
   IF (get_cancelled_vouchers%FOUND) THEN
      CLOSE get_cancelled_vouchers;
      RETURN 'TRUE';
   ELSE
      CLOSE get_cancelled_vouchers;
      RETURN 'FALSE';
   END IF;
END Is_Cancel_Vou_Exist_Hold;


PROCEDURE Remove_Object_Connections(
   company_         IN VARCHAR2,
   voucher_type_    IN VARCHAR2,
   accounting_year_ IN NUMBER,
   voucher_no_      IN NUMBER,
   function_group_  IN VARCHAR2,
   store_original_  IN VARCHAR2)
IS
   vou_row_no_             NUMBER;
   err_msg_                VARCHAR2(32000);
   err_                    EXCEPTION;

BEGIN
   Remove_Object_Connections___( vou_row_no_, err_msg_, company_, voucher_type_, accounting_year_, voucher_no_, function_group_, store_original_ );
   IF ( err_msg_ IS NOT NULL ) THEN
      RAISE err_;
   END IF;
EXCEPTION
   WHEN err_ THEN
      Error_SYS.Appl_General(lu_name_, err_msg_);

END Remove_Object_Connections;


PROCEDURE Remove_Object_Connections (
   row_no_          OUT NUMBER,
   err_msg_         OUT VARCHAR2,
   company_         IN  VARCHAR2,
   voucher_type_    IN  VARCHAR2,
   accounting_year_ IN  NUMBER,
   voucher_no_      IN  NUMBER,
   function_group_  IN  VARCHAR2,
   store_original_  IN  VARCHAR2 )
IS

BEGIN
   Remove_Object_Connections___( row_no_, err_msg_, company_, voucher_type_, accounting_year_, voucher_no_, function_group_, store_original_ );

END Remove_Object_Connections;


@Override
@UncheckedAccess
@SecurityCheck Company.UserAuthorized(company_)
FUNCTION Get (
   company_         IN VARCHAR2,
   accounting_year_ IN NUMBER,
   voucher_type_    IN VARCHAR2,
   voucher_no_      IN NUMBER ) RETURN Public_Rec
IS
BEGIN
   RETURN super(company_, accounting_year_, voucher_type_, voucher_no_);
END Get;


@UncheckedAccess
FUNCTION Get_Sum (
   company_            IN VARCHAR2,
   accounting_year_    IN NUMBER,
   voucher_type_       IN VARCHAR2,
   voucher_no_         IN NUMBER,
   flag_               IN VARCHAR2  ) RETURN NUMBER
IS
   amount_                NUMBER;
   -- Bug 129273,begin.
   CURSOR get_amount_ IS
      SELECT SUM(DECODE(flag_,'debit',debet_amount,'credit',credit_amount))
      FROM Accounting_Code_Part_Value_Tab a,
           Voucher_Row_Tab v
      WHERE a.company         = v.company
      AND   a.code_part       = 'A'
      AND   a.code_part_value = v.account
      AND   a.stat_account    = 'N'
      AND   v.company         = company_
      AND   v.voucher_Type    = voucher_type_
      AND   v.accounting_Year = accounting_year_
      AND   v.voucher_No      = voucher_no_;
   -- Bug 129273,end.
BEGIN
   OPEN get_amount_;
   FETCH get_amount_ INTO amount_;
   CLOSE get_amount_;
   RETURN amount_;
END Get_Sum;

@UncheckedAccess
FUNCTION Get_Sum_Third_Curr (
   company_            IN VARCHAR2,
   accounting_year_    IN NUMBER,
   voucher_type_       IN VARCHAR2,
   voucher_no_         IN NUMBER,
   flag_               IN VARCHAR2  ) RETURN NUMBER
IS
   amount_                NUMBER;
   -- Bug 129273,begin.
   CURSOR get_amount_ IS
      SELECT SUM(DECODE(flag_,'debit',third_currency_debit_amount,'credit',third_currency_credit_amount))
      FROM Accounting_Code_Part_Value_Tab a,
           Voucher_Row_Tab v
      WHERE a.company         = v.company
      AND   a.code_part       = 'A'
      AND   a.code_part_value = v.account
      AND   a.stat_account    = 'N'
      AND   v.company         = company_
      AND   v.voucher_Type    = voucher_type_
      AND   v.accounting_Year = accounting_year_
      AND   v.voucher_No      = voucher_no_;
   -- Bug 129273,end.
BEGIN
   OPEN get_amount_;
   FETCH get_amount_ INTO amount_;
   CLOSE get_amount_;
   RETURN amount_;
END Get_Sum_Third_Curr;

@UncheckedAccess
FUNCTION Is_Voucher_Exist (
   company_         IN VARCHAR2,
   voucher_type_    IN VARCHAR2,
   accounting_year_ IN NUMBER,
   voucher_no_      IN NUMBER ) RETURN VARCHAR2
IS
   CURSOR vou_exist IS
      SELECT 1
      FROM   VOUCHER
      WHERE  company         = company_
      AND    accounting_year = accounting_year_
      AND    voucher_type    = voucher_type_
      AND    voucher_no      = voucher_no_;
   dummy_    NUMBER;
BEGIN
   OPEN vou_exist;
   FETCH vou_exist INTO dummy_;
   IF (vou_exist%FOUND) THEN
      CLOSE vou_exist;
      RETURN 'TRUE';
   ELSE
      CLOSE vou_exist;
      RETURN 'FALSE';
   END IF;
END Is_Voucher_Exist;

@Override
@UncheckedAccess
@SecurityCheck Company.UserAuthorized(company_)
FUNCTION Get_Revenue_Cost_Clear_Voucher (
   company_         IN VARCHAR2,
   accounting_year_ IN NUMBER,
   voucher_type_    IN VARCHAR2,
   voucher_no_      IN NUMBER ) RETURN VARCHAR2
IS
   temp_ VOUCHER_TAB.revenue_cost_clear_voucher%TYPE;
BEGIN
   temp_ := super(company_, accounting_year_, voucher_type_, voucher_no_);
   RETURN NVL(temp_, 'FALSE');
END Get_Revenue_Cost_Clear_Voucher;

FUNCTION Exist_Rev_Cost_Clear_Voucher (
   company_              IN VARCHAR2,
   accounting_year_      IN NUMBER,
   accounting_period_    IN NUMBER,
   user_group_           IN VARCHAR2,
   voucher_type_         IN VARCHAR2 ) RETURN VARCHAR2
IS
   CURSOR exist_rev_cost_ IS
      SELECT 1
      FROM   VOUCHER_TAB
      WHERE  company             = company_
      AND    accounting_year     = accounting_year_
      AND    accounting_period   = accounting_period_
      AND    revenue_cost_clear_voucher = 'TRUE'
      AND    voucher_updated     = 'N';
   exist_voucher_       VARCHAR2(5);
BEGIN
   OPEN exist_rev_cost_;
   FETCH exist_rev_cost_ INTO exist_voucher_;
   IF (exist_rev_cost_%FOUND) THEN
      CLOSE exist_rev_cost_;
      RETURN 'TRUE';
   ELSE
      CLOSE exist_rev_cost_;
      RETURN 'FALSE';
   END IF;
END Exist_Rev_Cost_Clear_Voucher;


FUNCTION Is_Vou_Exist (
   company_              IN VARCHAR2,
   voucher_type_         IN VARCHAR2,
   accounting_year_      IN NUMBER,
   from_vou_no_          IN NUMBER,
   to_vou_no_            IN NUMBER ) RETURN VARCHAR2
IS
    vou_exist_           VARCHAR2(5) := 'FALSE';
BEGIN
   $IF Component_Genled_SYS.INSTALLED $THEN
      vou_exist_ := Gen_Led_Voucher_API.Is_Vou_Exist(company_,
                                                     voucher_type_,
                                                     accounting_year_,
                                                     from_vou_no_,
                                                     to_vou_no_);
   $END
   RETURN vou_exist_;
END Is_Vou_Exist;


PROCEDURE Set_Reference_Data(
   company_              IN VARCHAR2,
   accounting_year_      IN NUMBER,
   voucher_no_           IN NUMBER,
   voucher_type_         IN VARCHAR2,
   accounting_year_ref_  IN NUMBER,
   voucher_no_ref_       IN NUMBER,
   voucher_type_ref_     IN VARCHAR2,
   multi_company_id_     IN VARCHAR2,
   voucher_text_         IN VARCHAR2)
IS
BEGIN
   UPDATE voucher_tab
      SET accounting_year_reference  = accounting_year_ref_,
          voucher_no_reference = voucher_no_ref_,
          voucher_type_reference = voucher_type_ref_,
          multi_company_id = multi_company_id_,
          voucher_text2 = voucher_text_
   WHERE  company         = company_
   AND    accounting_year = accounting_year_
   AND    voucher_no      = voucher_no_
   AND    voucher_type    = voucher_type_;

   UPDATE voucher_row_tab
      SET multi_company_id = multi_company_id_
   WHERE  company         = company_
   AND    accounting_year = accounting_year_
   AND    voucher_no      = voucher_no_
   AND    voucher_type    = voucher_type_;
END Set_Reference_Data;


@SecurityCheck Company.UserAuthorized(company_)
PROCEDURE Set_Voucher_Reference (
   company_                   IN VARCHAR2,
   voucher_type_              IN VARCHAR2,
   voucher_no_                IN NUMBER,   
   accounting_year_           IN NUMBER,
   voucher_text_              IN VARCHAR2,
   voucher_type_reference_    IN VARCHAR2,
   voucher_no_reference_      IN NUMBER,
   accounting_year_reference_ IN NUMBER )
IS
BEGIN
   UPDATE voucher_tab
      SET voucher_text2             = voucher_text_,
          voucher_type_reference    = voucher_type_reference_,
          accounting_year_reference = accounting_year_reference_,
          voucher_no_reference      = voucher_no_reference_
   WHERE  company         = company_
   AND    voucher_no      = voucher_no_
   AND    voucher_type    = voucher_type_
   AND    accounting_year = accounting_year_;
END Set_Voucher_Reference;
                                           
                                           
@UncheckedAccess
FUNCTION Is_Pca_Update_Blocked (
   company_                IN VARCHAR2,
   function_group_         IN VARCHAR2 ) RETURN VARCHAR2
IS
   rollback_mode_db_          VARCHAR2(20):='CORRECTION';
BEGIN
   IF (function_group_ = 'Z') THEN
      $IF Component_Percos_SYS.INSTALLED $THEN
         rollback_mode_db_ := COMPANY_COST_ALLOC_INFO_API.Get_Rollback_Mode_Db(company_);
         IF (rollback_mode_db_ = 'ROLLBACK') THEN
            RETURN 'TRUE';
         END IF;
      $ELSE
         NULL;
      $END
   END IF;
   RETURN 'FALSE';
END Is_Pca_Update_Blocked;


FUNCTION Get_Next_Row_Number (
   company_         IN VARCHAR2,
   voucher_type_    IN VARCHAR2,
   accounting_year_ IN NUMBER,
   voucher_no_      IN NUMBER ) RETURN NUMBER
IS
BEGIN
   RETURN Lock_And_Get_Next_Row_No___(company_, voucher_type_, accounting_year_, voucher_no_);  
END Get_Next_Row_Number;


FUNCTION Check_Negative_Amount(
   company_         IN VARCHAR2,
   voucher_type_    IN VARCHAR2,
   accounting_year_ IN NUMBER,
   voucher_no_      IN NUMBER ) RETURN VARCHAR2
IS
   fa_code_part_      VARCHAR2(1);
   is_negative_       VARCHAR2(5);
   CURSOR get_records IS
       SELECT DISTINCT  object_id, account
       FROM  voucher_row_tab
       WHERE company          = company_
         AND voucher_type     = voucher_type_
         AND accounting_year  = accounting_year_
         AND voucher_no       = voucher_no_
         AND object_id IS NOT NULL;
BEGIN
   $IF Component_Fixass_SYS.INSTALLED $THEN
      fa_code_part_ := Accounting_Code_Parts_API.Get_Codepart_Function(company_, 'FAACC');
      IF fa_code_part_ IS NOT NULL THEN       
         FOR rec_ IN get_records LOOP
             IF ((Fa_Object_API.Get_Rowstate(company_,rec_.object_id) = 'Active') AND (Acquisition_Account_API.Is_Acquisition_Account(company_, rec_.account))) THEN
                is_negative_ := Change_Object_Value_Util_API.Check_Negative_Amount('VOUCHER',
                                                                                   company_,
                                                                                   voucher_no_,
                                                                                   voucher_type_,
                                                                                   accounting_year_,
                                                                                   NULL,
                                                                                   NULL,
                                                                                   rec_.object_id);
               IF is_negative_ = 'TRUE' THEN
                   RETURN  'TRUE';
               END IF;
            END IF;
         END LOOP;
      END IF;
   $END
   RETURN 'FALSE';
END Check_Negative_Amount;


-- Get_Balance_Voucher_Par
--   Function that returns the balance for a voucher in parallel currency
--   Input parameters: Voucher key columns
--   Bug 110569, begin
--   Bug 110569, End
@UncheckedAccess
FUNCTION Get_Balance_Voucher_Par (
   company_         IN  VARCHAR2,
   voucher_type_    IN  VARCHAR2,
   accounting_year_ IN  NUMBER,
   voucher_no_      IN  NUMBER ) RETURN NUMBER
IS
   acc_curr_bal_        NUMBER;
   par_curr_bal_        NUMBER;   
BEGIN
   Get_Balance_Voucher_All___(acc_curr_bal_,
                              par_curr_bal_,
                              company_,
                              voucher_type_,
                              accounting_year_,
                              voucher_no_);
   RETURN par_curr_bal_;                             
END Get_Balance_Voucher_Par;


@UncheckedAccess
FUNCTION Is_Voucher_Status_Error (
   company_         IN VARCHAR2,
   accounting_year_ IN NUMBER,
   voucher_type_    IN VARCHAR2,
   voucher_no_      IN NUMBER ) RETURN VARCHAR2
IS
   CURSOR get_state IS
      SELECT rowstate
      FROM   VOUCHER_TAB
      WHERE  company         = company_
      AND    voucher_type    = voucher_type_
      AND    accounting_year = accounting_year_
      AND    voucher_no      = voucher_no_;

   vou_state_          VOUCHER_TAB.rowstate%TYPE;
BEGIN 
   OPEN  get_state;
   FETCH get_state INTO vou_state_;
   CLOSE get_state;
   
   IF vou_state_ = 'Error' THEN
      RETURN 'TRUE';       
   ELSE
      RETURN 'FALSE';       
   END IF;
END Is_Voucher_Status_Error;


-- Exist
--   Checks if given pointer (e.g. primary key) to an instance of this
--   logical unit exists. If not an exception will be raised.
@UncheckedAccess
PROCEDURE Exist (
   company_         IN VARCHAR2,
   voucher_type_    IN VARCHAR2,
   accounting_year_ IN NUMBER,
   voucher_no_      IN NUMBER )
IS
BEGIN
   IF (NOT Check_Exist___(company_, accounting_year_, voucher_type_, voucher_no_)) THEN
      Error_SYS.Record_Not_Exist(lu_name_);
   END IF;
END Exist;

@Override
@UncheckedAccess
@SecurityCheck Company.UserAuthorized(company_)
FUNCTION Get_Voucher_Date (
   company_ IN VARCHAR2,
   accounting_year_ IN NUMBER,
   voucher_type_ IN VARCHAR2,
   voucher_no_ IN NUMBER ) RETURN DATE
IS
BEGIN
   RETURN super(company_, accounting_year_, voucher_type_, voucher_no_);
END Get_Voucher_Date;

@Override
@UncheckedAccess
@SecurityCheck Company.UserAuthorized(company_)
FUNCTION Get_Date_Reg (
   company_ IN VARCHAR2,
   accounting_year_ IN NUMBER,
   voucher_type_ IN VARCHAR2,
   voucher_no_ IN NUMBER ) RETURN DATE
IS

BEGIN
   RETURN super(company_, accounting_year_, voucher_type_, voucher_no_);
END Get_Date_Reg;

@Override
@UncheckedAccess
@SecurityCheck Company.UserAuthorized(company_)
FUNCTION Get_Userid (
   company_ IN VARCHAR2,
   accounting_year_ IN NUMBER,
   voucher_type_ IN VARCHAR2,
   voucher_no_ IN NUMBER ) RETURN VARCHAR2
IS
BEGIN
   RETURN super(company_, accounting_year_, voucher_type_, voucher_no_);
END Get_Userid;


@Override
@UncheckedAccess
@SecurityCheck Company.UserAuthorized(company_)
FUNCTION Get_Transfer_Id (
   company_ IN VARCHAR2,
   accounting_year_ IN NUMBER,
   voucher_type_ IN VARCHAR2,
   voucher_no_ IN NUMBER ) RETURN VARCHAR2
IS
BEGIN
   RETURN super(company_, accounting_year_, voucher_type_, voucher_no_);
END Get_Transfer_Id;

@Override
@UncheckedAccess
@SecurityCheck Company.UserAuthorized(company_)
FUNCTION Get_Interim_Voucher (
   company_ IN VARCHAR2,
   accounting_year_ IN NUMBER,
   voucher_type_ IN VARCHAR2,
   voucher_no_ IN NUMBER ) RETURN VARCHAR2
IS
BEGIN
   RETURN super(company_, accounting_year_, voucher_type_, voucher_no_);
END Get_Interim_Voucher;

@Override
@UncheckedAccess
@SecurityCheck Company.UserAuthorized(company_)
FUNCTION Get_Accounting_Period (
   company_ IN VARCHAR2,
   accounting_year_ IN NUMBER,
   voucher_type_ IN VARCHAR2,
   voucher_no_ IN NUMBER ) RETURN NUMBER
IS
BEGIN
   RETURN super(company_, accounting_year_, voucher_type_, voucher_no_);
END Get_Accounting_Period;

@Override
@UncheckedAccess
@SecurityCheck Company.UserAuthorized(company_)
FUNCTION Get_User_Group (
   company_ IN VARCHAR2,
   accounting_year_ IN NUMBER,
   voucher_type_ IN VARCHAR2,
   voucher_no_ IN NUMBER ) RETURN VARCHAR2
IS
BEGIN
   RETURN super(company_, accounting_year_, voucher_type_, voucher_no_);
END Get_User_Group;

@Override
@UncheckedAccess
@SecurityCheck Company.UserAuthorized(company_)
FUNCTION Get_Function_Group (
   company_ IN VARCHAR2,
   accounting_year_ IN NUMBER,
   voucher_type_ IN VARCHAR2,
   voucher_no_ IN NUMBER ) RETURN VARCHAR2
IS
BEGIN
   RETURN super(company_, accounting_year_, voucher_type_, voucher_no_);
END Get_Function_Group;

@Override
@UncheckedAccess
@SecurityCheck Company.UserAuthorized(company_)
FUNCTION Get_Voucher_Updated (
   company_ IN VARCHAR2,
   accounting_year_ IN NUMBER,
   voucher_type_ IN VARCHAR2,
   voucher_no_ IN NUMBER ) RETURN VARCHAR2
IS
BEGIN
   RETURN super(company_, accounting_year_, voucher_type_, voucher_no_);
END Get_Voucher_Updated;

@Override
@UncheckedAccess
@SecurityCheck Company.UserAuthorized(company_)
FUNCTION Get_Voucher_Updated_Db (
   company_ IN VARCHAR2,
   accounting_year_ IN NUMBER,
   voucher_type_ IN VARCHAR2,
   voucher_no_ IN NUMBER ) RETURN VARCHAR2
IS   
BEGIN
   RETURN super(company_, accounting_year_, voucher_type_, voucher_no_);
END Get_Voucher_Updated_Db;   

@Override
@UncheckedAccess
@SecurityCheck Company.UserAuthorized(company_)
FUNCTION Get_Simulation_Voucher (
   company_ IN VARCHAR2,
   accounting_year_ IN NUMBER,
   voucher_type_ IN VARCHAR2,
   voucher_no_ IN NUMBER ) RETURN VARCHAR2
IS   
BEGIN
   RETURN super(company_, accounting_year_, voucher_type_, voucher_no_);
END Get_Simulation_Voucher;

@Override
@UncheckedAccess
@SecurityCheck Company.UserAuthorized(company_)
FUNCTION Get_Use_Correction_Rows (
   company_ IN VARCHAR2,
   accounting_year_ IN NUMBER,
   voucher_type_ IN VARCHAR2,
   voucher_no_ IN NUMBER ) RETURN VARCHAR2
IS
BEGIN   
   RETURN super(company_, accounting_year_, voucher_type_, voucher_no_);
END Get_Use_Correction_Rows;

@Override
@UncheckedAccess
@SecurityCheck Company.UserAuthorized(company_)
FUNCTION Get_Amount_Method (
   company_ IN VARCHAR2,
   accounting_year_ IN NUMBER,
   voucher_type_ IN VARCHAR2,
   voucher_no_ IN NUMBER ) RETURN VARCHAR2
IS
BEGIN
   RETURN super(company_, accounting_year_, voucher_type_, voucher_no_);
END Get_Amount_Method;

@Override
@UncheckedAccess
@SecurityCheck Company.UserAuthorized(company_)
FUNCTION Get_Amount_Method_Db (
   company_ IN VARCHAR2,
   accounting_year_ IN NUMBER,
   voucher_type_ IN VARCHAR2,
   voucher_no_ IN NUMBER ) RETURN VARCHAR2
IS   
BEGIN
   RETURN super(company_, accounting_year_, voucher_type_, voucher_no_);
END Get_Amount_Method_Db;


PROCEDURE Get_Voucher_Date (
   voucher_date_    OUT DATE,
   company_         IN  VARCHAR2,
   voucher_type_    IN  VARCHAR2,
   accounting_year_ IN  NUMBER,
   voucher_no_      IN  NUMBER )
IS
   novoucher  EXCEPTION;
BEGIN
   -- Bug 111218,Begin
   -- Bug 111218,Begin
   voucher_date_ := Get_Voucher_Date (company_,
                                      accounting_year_,
                                      voucher_type_,
                                      voucher_no_);

   IF (voucher_date_ IS NULL) THEN
      RAISE novoucher;
   END IF;
EXCEPTION
   WHEN novoucher THEN
       Error_SYS.record_general(lu_name_, 'NOVOU: Voucher number :P1 is missing company :P2 voucher_type :P3',voucher_no_,company_,voucher_type_);
END Get_Voucher_Date;

-- Bug 125057, Begin
PROCEDURE Update_Current_Row_Num (
   company_         IN VARCHAR2,
   voucher_type_    IN VARCHAR2,
   accounting_year_ IN NUMBER,
   voucher_no_      IN NUMBER,
   current_row_num_ IN NUMBER ) 
IS   

BEGIN
  UPDATE  voucher_tab
  SET     current_row_number = current_row_num_	          
  WHERE   company            = company_
  AND     accounting_year    = accounting_year_
  AND     voucher_type       = voucher_type_
  AND     voucher_no         = voucher_no_;
 
END Update_Current_Row_Num;
-- Bug 125057, End
