-----------------------------------------------------------------------------
--
--  Logical unit: AccPeriodCloseUtil
--  Component:    ACCRUL
--
--  IFS Developer Studio Template Version 3.0
--
--  Date    Sign    History
--  ------  ------  ---------------------------------------------------------
--  140812  Samllk  PRFI-229,    Added Utility and the methods Get_Ext_Trans_Types(), Get_Currency_Reval_Status(),
--                               Get_Revenue_Recog_Status(), Get_Procedure_Status(), Get_Bal_Trans_Cons_Status(),
--                               Get_Not_Transferred_Count(), Get_Month_End_Final_Status(), Get_Ext_Trans_Types_Db(),
--                               Get_Depr_Prop_Status()
--  141104  Samllk  PRFI-3258,   Added method Get_Not_Transferred_Count_()
--  150202  Samllk  PRFI-4269,   Removed Get_Bal_Trans_Cons_Status() and modified Get_Month_End_Final_Status()
--  150916  Samllk  AFT-4960,    Added methods to get the status of all transactions and added constants to represent statuses
--  160627  Samllk  Bug 130047,  Modified function Get_Month_End_Final_Status
-----------------------------------------------------------------------------

layer Core;

-------------------- PUBLIC DECLARATIONS ------------------------------------


-------------------- PRIVATE DECLARATIONS -----------------------------------

ERROR               CONSTANT NUMBER  := 3;
WARNING             CONSTANT NUMBER  := 2;
SUCCESS             CONSTANT NUMBER  := 1;
NOT_AVAILABLE       CONSTANT NUMBER  := 0;

-------------------- LU SPECIFIC IMPLEMENTATION METHODS ---------------------


-------------------- LU SPECIFIC PRIVATE METHODS ----------------------------


-------------------- LU SPECIFIC PROTECTED METHODS --------------------------


-------------------- LU SPECIFIC PUBLIC METHODS -----------------------------

@UncheckedAccess
FUNCTION Get_Ext_Trans_Types_Db  RETURN VARCHAR2
IS
BEGIN
   RETURN ('INVENTORY^PURCHASE^PROCESSING^RENTAL^MAINTENANCE TIME^TOOLS AND FACILITIES^WORK ORDER EXPENSES^WORK ORDER EXTERNALS^');   
END Get_Ext_Trans_Types_Db;

@UncheckedAccess
FUNCTION Get_Ext_Trans_Types  RETURN VARCHAR2
IS
   value_list_    VARCHAR2(4000);
BEGIN
   value_list_ := Language_sys.Translate_Constant(lu_name_ ,'EXTTRANSINVNT: Inventory') || '^';
   value_list_ := value_list_ || Language_sys.Translate_Constant(lu_name_ ,'EXTTRANSPURCH: Purchase') || '^';
   value_list_ := value_list_ || Language_sys.Translate_Constant(lu_name_ ,'EXTTRANSPROCS: Processing') || '^';
   value_list_ := value_list_ || Language_sys.Translate_Constant(lu_name_ ,'EXTTRANSRENTL: Rental') || '^';
   value_list_ := value_list_ || Language_sys.Translate_Constant(lu_name_ ,'EXTTRANSMAINT: Maintenance Time') || '^';
   value_list_ := value_list_ || Language_sys.Translate_Constant(lu_name_ ,'EXTTRANSTOOLS: Tools and Facilities') || '^';
   value_list_ := value_list_ || Language_sys.Translate_Constant(lu_name_ ,'EXTTRANSWKEXP: Work Order Expenses') || '^';
   value_list_ := value_list_ || Language_sys.Translate_Constant(lu_name_ ,'EXTTRANSWKEXT: Work Order Externals') || '^';
   
   RETURN Language_Sys.Translate_Constant(lu_name_, value_list_);   
END Get_Ext_Trans_Types;

@UncheckedAccess
FUNCTION Get_Currency_Reval_Status (
   company_           IN VARCHAR2,
   accounting_year_   IN NUMBER,
   accounting_period_ IN NUMBER) RETURN NUMBER
IS
   $IF Component_Genled_SYS.INSTALLED $THEN
      CURSOR check_unposted_reval IS
         SELECT 1
         FROM   currency_revaluation_tab
         WHERE  company           = company_
         AND    accounting_year   = accounting_year_
         AND    accounting_period = accounting_period_
         AND    rowstate          IN ('Defined', 'Calculated', 'Acknowledged');
      CURSOR check_posted_reval IS
         SELECT 1
         FROM   currency_revaluation_tab
         WHERE  company           = company_
         AND    accounting_year   = accounting_year_
         AND    accounting_period = accounting_period_
         AND    rowstate          = 'Posted';
   $END
   dummy_                 NUMBER;
   status_                NUMBER := 0;
BEGIN
   $IF Component_Genled_SYS.INSTALLED $THEN
      OPEN  check_unposted_reval;
      FETCH check_unposted_reval INTO dummy_;
      IF check_unposted_reval%FOUND THEN
        CLOSE check_unposted_reval;
        status_ := WARNING;
      ELSE
         CLOSE check_unposted_reval;
         OPEN  check_posted_reval;
         FETCH check_posted_reval INTO dummy_;
         IF check_posted_reval%FOUND THEN
            status_ := SUCCESS;
         ELSE
            status_ := ERROR;
         END IF;
         CLOSE check_posted_reval;
      END IF;
   $ELSE
      status_ := NOT_AVAILABLE;
   $END
   RETURN status_;
END Get_Currency_Reval_Status;
   
@UncheckedAccess
FUNCTION Get_Revenue_Recog_Status (
   company_           IN VARCHAR2,
   accounting_year_   IN NUMBER,
   accounting_period_ IN NUMBER ) RETURN NUMBER
IS
   $IF Component_Genled_SYS.INSTALLED $THEN
      CURSOR get_unposted_revenues IS
         SELECT 1
         FROM   REVENUE_RECOGNITION_TAB
         WHERE  company             = company_
         AND    accounting_year     = accounting_year_
         AND    accounting_period   = accounting_period_
         AND    rowstate  IN ('Defined', 'Calculated', 'Modified', 'Acknowledged');
      CURSOR get_posted_revenues IS
         SELECT 1
         FROM   REVENUE_RECOGNITION_TAB
         WHERE  company             = company_
         AND    accounting_year     = accounting_year_
         AND    accounting_period   = accounting_period_
         AND    rowstate  = 'Posted/Closed';
   $END
   temp_                  NUMBER;
   status_                NUMBER := 0;
BEGIN
   $IF Component_Genled_SYS.INSTALLED $THEN
      OPEN  get_unposted_revenues;
      FETCH get_unposted_revenues INTO temp_;
      IF get_unposted_revenues%FOUND THEN
         CLOSE get_unposted_revenues;
         status_ := WARNING;
      ELSE
         CLOSE get_unposted_revenues;
         OPEN  get_posted_revenues;
         FETCH get_posted_revenues INTO temp_;
         IF get_posted_revenues%FOUND THEN
            status_ := SUCCESS;
         ELSE
            status_ := ERROR;
         END IF;
         CLOSE get_posted_revenues;
      END IF;
   $ELSE
      status_ := NOT_AVAILABLE;
   $END
   RETURN status_;
END Get_Revenue_Recog_Status;

@UncheckedAccess
FUNCTION Get_Procedure_Status (
   company_           IN VARCHAR2,
   accounting_year_   IN NUMBER,
   accounting_period_ IN NUMBER ) RETURN NUMBER
IS
   $IF Component_Percos_SYS.INSTALLED $THEN
      CURSOR get_not_closed IS
         SELECT 1
         FROM   cost_allocation_procedure_tab
         WHERE  company           = company_
         AND    accounting_year   = accounting_year_
         AND    accounting_period = accounting_period_
         AND    ledger_id        IN ('00','*')
         AND    allocation_type   = 'ACTUAL'
         AND    rowstate         IN ('Defined', 'Active');
      CURSOR get_closed IS
         SELECT 1
         FROM   cost_allocation_procedure_tab
         WHERE  company           = company_
         AND    accounting_year   = accounting_year_
         AND    accounting_period = accounting_period_
         AND    ledger_id        IN ('00','*')
         AND    allocation_type   = 'ACTUAL'
         AND    rowstate         IN ('Closed');
   $END
   dummy_                 NUMBER;
   status_                NUMBER := 0;
BEGIN
   $IF Component_Percos_SYS.INSTALLED $THEN
      OPEN  get_not_closed;
      FETCH get_not_closed INTO dummy_;
      IF get_not_closed%FOUND THEN
         CLOSE get_not_closed;
         status_ := WARNING;
      ELSE
         CLOSE get_not_closed;
         OPEN  get_closed;
         FETCH get_closed INTO dummy_;
         IF get_closed%FOUND THEN
            CLOSE get_closed;
            status_ := SUCCESS;
         ELSE
            CLOSE get_closed;
            status_ := ERROR;
         END IF;
      END IF;
   $ELSE
      status_ := NOT_AVAILABLE;
   $END
   RETURN status_;
END Get_Procedure_Status;
   
FUNCTION Get_Depr_Prop_Status (
    company_           IN VARCHAR2,
    accounting_year_   IN NUMBER,
    accounting_period_ IN NUMBER ) RETURN NUMBER
IS
   $IF Component_Fixass_SYS.INSTALLED $THEN
      CURSOR get_prop_exist_period IS
         SELECT 1
         FROM   DEPR_PROPOSAL_TAB d,
                fa_book_tab f
         WHERE  d.company = company_
         AND    d.financial_year_sel  = accounting_year_
         AND    d.financial_period_sel = accounting_period_
         AND    d.company = f.company
         AND    d.book_id_sel = f.book_id
         AND    f.create_accounting = 'TRUE'      
         AND    (f.voucher_type IS NULL
                 OR EXISTS
                 (SELECT 1
                  FROM   voucher_type_tab v
                  WHERE  v.company = f.company
                  AND    v.voucher_type = f.voucher_type
                  AND    v.ledger_id IN ('*', '00')
                 )
                );  
      CURSOR get_unposted_revenues IS
         SELECT 1
         FROM   DEPR_PROPOSAL_TAB d,
                fa_book_tab f
         WHERE  d.company = company_
         AND    (d.financial_year_sel  < accounting_year_
                 OR (d.financial_year_sel  = accounting_year_
                     AND d.financial_period_sel <= accounting_period_))
         AND    d.rowstate IN ('Created', 'Authorized')
         AND    d.company = f.company
         AND    d.book_id_sel = f.book_id
         AND    f.create_accounting = 'TRUE'      
         AND    (f.voucher_type IS NULL
                 OR EXISTS
                 (SELECT 1
                  FROM   voucher_type_tab v
                  WHERE  v.company = f.company
                  AND    v.voucher_type = f.voucher_type
                  AND    v.ledger_id IN ('*', '00')
                 )
                );          
   $END
   dummy_                 NUMBER;
   status_                NUMBER := 0;
BEGIN
   $IF Component_Fixass_SYS.INSTALLED $THEN
      OPEN  get_prop_exist_period;
      FETCH get_prop_exist_period INTO dummy_;
      IF get_prop_exist_period%NOTFOUND THEN
         CLOSE get_prop_exist_period;
         status_ := ERROR;
      ELSE
         CLOSE get_prop_exist_period;
         OPEN  get_unposted_revenues;
         FETCH get_unposted_revenues INTO dummy_;
         IF get_unposted_revenues%FOUND THEN
            status_ := WARNING;
         ELSE
            status_ := SUCCESS;
         END IF;
         CLOSE get_unposted_revenues;
      END IF;
   $ELSE
      status_ := NOT_AVAILABLE;
   $END
   RETURN status_;
END Get_Depr_Prop_Status;

@UncheckedAccess
FUNCTION Get_Not_Transferred_Count  (
   company_            IN     VARCHAR2,
   accounting_year_    IN     NUMBER,
   accounting_period_  IN     NUMBER,
   trans_type_         IN     VARCHAR2)  RETURN NUMBER
IS
   end_date_            DATE;
BEGIN
   end_date_   := Accounting_Period_Api.Get_Date_Until(company_, accounting_year_, accounting_period_);
   RETURN Get_Not_Transferred_Count_(company_, trans_type_, end_date_); 
END Get_Not_Transferred_Count;

@UncheckedAccess
FUNCTION Get_Not_Transferred_Count_  (
   company_            IN     VARCHAR2,
   trans_type_         IN     VARCHAR2,
   end_date_           IN     DATE DEFAULT NULL)  RETURN NUMBER
IS
   count_               NUMBER := 0;
   booking_source1_     VARCHAR2(15);
   booking_source2_     VARCHAR2(15) := NULL;
   cost_type_           VARCHAR2(20);
   voucher_type_        Voucher_Type_Tab.voucher_type%TYPE;
   function_group_      Function_Group_Tab.function_group%TYPE;
   
   $IF Component_Mpccom_SYS.INSTALLED $THEN
      CURSOR get_dist_manu_count_ IS
         SELECT COUNT(accounting_id)
         FROM   MPCCOM_ACCOUNTING
         WHERE  contract IN (select contract from site_public where company = company_)
         AND    status_code IN ('1', '2', '99')
         AND    date_applied <= end_date_
         AND    booking_source IN (booking_source1_, booking_source2_);
      CURSOR get_dist_manu_count_all_ IS
         SELECT COUNT(accounting_id)
         FROM   MPCCOM_ACCOUNTING
         WHERE  contract IN (select contract from site_public where company = company_)
         AND    status_code IN ('1', '2', '99')
         AND    booking_source IN (booking_source1_, booking_source2_);
   $END

   $IF Component_Wo_SYS.INSTALLED $THEN
      CURSOR get_maintenance_count_ IS
          SELECT COUNT(seq)
          FROM PCM_ACCOUNTING_tab t
          WHERE t.company = company_
          AND ( t.voucher_no IS NULL)
          AND t.transaction_id IN (SELECT a.transaction_id
                                   FROM Wo_Time_Transaction_Hist_Tab a
                                   WHERE a.trans_date <= end_date_
                                   AND a.work_order_cost_type = cost_type_
                                   AND (SELECT  b.company FROM site b
                                        WHERE b.contract = a.contract) = company_
                                        AND 1 IN (SELECT 1 FROM work_order_coding_tab c
                                        WHERE c.wo_no = a.wo_no
                                        AND c.row_no = a.row_no
                                        and c.book_status NOT IN ('T')));
      CURSOR get_maintenance_count_all_ IS
          SELECT COUNT(seq)
          FROM PCM_ACCOUNTING_tab t
          WHERE t.company = company_
          AND ( t.voucher_no IS NULL)
          AND t.transaction_id IN (SELECT a.transaction_id
                                   FROM Wo_Time_Transaction_Hist_Tab a
                                   WHERE a.work_order_cost_type = cost_type_
                                   AND (SELECT  b.company FROM site b
                                        WHERE b.contract = a.contract) = company_
                                        AND 1 IN (SELECT 1 FROM work_order_coding_tab c
                                        WHERE c.wo_no = a.wo_no
                                        AND c.row_no = a.row_no
                                        and c.book_status NOT IN ('T')));
   $END
BEGIN   
   IF(trans_type_ = 'INVENTORY') THEN
      booking_source1_ := 'INVENTORY';
   ELSIF (trans_type_ = 'PURCHASE') THEN
      booking_source1_ := 'PURCHASE';
   ELSIF (trans_type_ = 'PROCESSING') THEN
      booking_source1_ := 'LABOR';
      booking_source2_ := 'OPERATION';
   ELSIF (trans_type_ = 'RENTAL') THEN
      booking_source1_ := 'RENTAL';
   ELSIF (trans_type_ = 'MAINTENANCE TIME') THEN
      voucher_type_ :=  'MT';
   ELSIF (trans_type_ = 'TOOLS AND FACILITIES') THEN
      voucher_type_ :=  'MT2';
   ELSIF (trans_type_ = 'WORK ORDER EXPENSES') THEN
      voucher_type_ :=  'MT4';
   ELSIF (trans_type_ = 'WORK ORDER EXTERNALS') THEN
      voucher_type_ :=  'MT5';
   END IF;
   
   IF (trans_type_ IN ('INVENTORY', 'PURCHASE', 'PROCESSING', 'RENTAL')) THEN
      IF(booking_source2_ IS NULL) THEN
         booking_source2_ := booking_source1_;
      END IF;
      $IF Component_Mpccom_SYS.INSTALLED $THEN
         IF(end_date_ IS NOT NULL) THEN
            OPEN  get_dist_manu_count_;
            FETCH get_dist_manu_count_ INTO count_;
            CLOSE get_dist_manu_count_;
         ELSE
            OPEN  get_dist_manu_count_all_;
            FETCH get_dist_manu_count_all_ INTO count_;
            CLOSE get_dist_manu_count_all_;
         END IF;
      $ELSE
        NULL;
      $END
   ELSIF (trans_type_ IN ('MAINTENANCE TIME', 'TOOLS AND FACILITIES', 'WORK ORDER EXPENSES', 'WORK ORDER EXTERNALS')) THEN
      $IF Component_Wo_SYS.INSTALLED $THEN
         function_group_      := Voucher_Type_Detail_API.Get_Function_Group(company_, voucher_type_);
         IF (function_group_ = 'V') THEN
            cost_type_ := Work_Order_Cost_Type_API.DB_PERSONNEL;
         ELSIF (function_group_ = 'TF') THEN
            cost_type_ := Work_Order_Cost_Type_API.DB_TOOLS_FACILITIES;
         ELSIF (function_group_ = 'TP') THEN
            cost_type_ := Work_Order_Cost_Type_API.DB_EXTERNAL;
         ELSIF (function_group_ = 'TE') THEN
            cost_type_ := Work_Order_Cost_Type_API.DB_EXPENSES;
         END IF;
         IF(end_date_ IS NOT NULL) THEN
            OPEN  get_maintenance_count_;
            FETCH get_maintenance_count_ INTO count_;
            CLOSE get_maintenance_count_;
         ELSE
            OPEN  get_maintenance_count_all_;
            FETCH get_maintenance_count_all_ INTO count_;
            CLOSE get_maintenance_count_all_;
         END IF;
      $ELSE
        NULL;
      $END
   END IF;
   RETURN count_; 
END Get_Not_Transferred_Count_;

FUNCTION Get_Month_End_Final_Status(
   company_            IN     VARCHAR2,
   accounting_year_    IN     NUMBER,
   accounting_period_  IN     NUMBER) RETURN NUMBER
IS
   start_date_          DATE;
   end_date_            DATE;
   -- Bug 130047, Removed Code
   result_              VARCHAR2(5);
   -- Bug 130047, begin
   s_dummy_             VARCHAR2(100);
   year_end_period_     VARCHAR2(100);
   
   CURSOR get_acc_period IS
      SELECT date_from, date_until, year_end_period
      FROM   ACCOUNTING_PERIOD_TAB
      WHERE  company           = company_
      AND    accounting_year   = accounting_year_
      AND    accounting_period = accounting_period_;
   -- Bug 130047, end
BEGIN
   -- Bug 130047, begin
   OPEN  get_acc_period;
   FETCH get_acc_period INTO start_date_, end_date_, year_end_period_;
   CLOSE get_acc_period;
   
   Voucher_API.Check_If_Postings_In_Voucher(result_, company_, accounting_period_, accounting_year_);
   IF (result_ = 'TRUE') THEN
      RETURN ERROR;
   ELSIF (Period_Allocation_API.Check_Year_Period_Exist(company_, accounting_year_, accounting_period_) = 'TRUE') THEN
      RETURN ERROR;
   END IF;
   $IF Component_Genled_SYS.INSTALLED $THEN
      IF (Currency_Revaluation_API.Check_Non_Posted_Reval_Exist(company_, accounting_year_, accounting_period_) = 'TRUE') THEN
         RETURN ERROR;
      ELSIF (Revenue_Recognition_API.All_Posted_For_Period(company_, accounting_year_, accounting_period_) = 'FALSE') THEN
         RETURN ERROR;
      END IF;
   $END
   $IF Component_Percos_SYS.INSTALLED $THEN
      IF (Cost_Allocation_Procedure_API.Check_Non_Closed_Proc_Exist(company_, accounting_year_, accounting_period_) = 'TRUE') THEN
         RETURN ERROR;
      END IF;
   $END
   $IF Component_Conacc_SYS.INSTALLED $THEN
      IF (Company_Cons_Trans_API.All_Bal_Trans_Cons_For_Period(company_, accounting_year_, accounting_period_) != '') THEN
         RETURN ERROR;
      END IF;
   $END
   $IF Component_Mpccom_SYS.INSTALLED $THEN
      IF (Mpccom_Accounting_API.All_Postings_Transferred(company_, start_date_, end_date_) = 'FALSE') THEN
         RETURN ERROR;
      END IF;
   $END
   $IF Component_Wo_SYS.INSTALLED $THEN
      IF (Pcm_Accounting_API.All_Postings_Transferred(company_, start_date_, end_date_) = 'FALSE') THEN
         RETURN ERROR;
      END IF;
   $END
   
   IF (year_end_period_ != Period_Type_API.DB_YEAR_OPENING) THEN
      $IF Component_Invoic_SYS.INSTALLED $THEN
         Invoice_API.Post_Error_Invs_Exist(result_, company_, accounting_year_, accounting_period_, start_date_, end_date_);
         IF (result_ = 'TRUE') THEN
            RETURN WARNING;
         ELSE
            Invoice_Utility_Pub_API.Preliminary_Invs_Exist(result_, company_, accounting_year_, accounting_period_, start_date_, end_date_);
            IF (result_ = 'TRUE') THEN
               RETURN WARNING;
            ELSIF (Ext_Inc_Inv_Load_Info_API.Check_Non_Created_Inv_Exist(company_, accounting_year_, accounting_period_, start_date_, end_date_) = 'TRUE') THEN   
               RETURN WARNING;
            ELSIF (Ext_Out_Inv_Load_Info_API.Check_Non_Created_Inv_Exist(company_, accounting_year_, accounting_period_, start_date_, end_date_) = 'TRUE') THEN
               RETURN WARNING;
            END IF;
         END IF;
      $END
      $IF Component_Payled_SYS.INSTALLED $THEN         
         Prel_Payment_Trans_Util_API.Check_Non_Approved_Paym_Exists(result_, s_dummy_, company_, accounting_year_, accounting_period_, start_date_, end_date_);
         IF (result_ = 'TRUE') THEN
            RETURN WARNING;
         ELSIF (Mixed_Payment_API.All_Approved_For_Period(company_, accounting_year_, accounting_period_, start_date_, end_date_) = 'FALSE') THEN
            RETURN WARNING;
         ELSIF (Cash_Box_API.All_Approved_For_Period(company_, accounting_year_, accounting_period_, start_date_, end_date_) = 'FALSE') THEN
            RETURN WARNING;
         ELSIF(Ext_Payment_Head_API.Check_Non_Used_Pay_Exist(company_, accounting_year_, accounting_period_, start_date_, end_date_) = 'TRUE') THEN
            RETURN WARNING;
         END IF;
      $END
      $IF Component_Fixass_SYS.INSTALLED $THEN
         IF (Fa_Object_Transaction_API.All_Imp_Trans_Post_For_Period(company_, start_date_, end_date_) = 'FALSE') THEN
            RETURN WARNING;
         ELSIF (Change_Object_Value_Temp_API.All_Change_Acq_Post_For_Period(company_, start_date_, end_date_) = 'FALSE') THEN
            RETURN WARNING;
         ELSIF (Change_Object_Value_Temp_API.All_Change_Net_Post_For_Period(company_, start_date_, end_date_) = 'FALSE') THEN
            RETURN WARNING;
         ELSIF (Depr_Proposal_API.All_Proposal_Post_For_Period(company_, accounting_year_, accounting_period_) = 'FALSE') THEN
            RETURN WARNING;
         END IF;
      $END
      IF (Ext_Load_Info_API.Check_Non_Created_ExtVou_Exist(company_, start_date_, end_date_) = 'TRUE') THEN
         RETURN WARNING;
      END IF;  
   END IF;
   RETURN SUCCESS;
   -- Bug 130047, end
END Get_Month_End_Final_Status;

@UncheckedAccess
FUNCTION Get_GL_Trans_Types  RETURN VARCHAR2
IS
   value_list_    VARCHAR2(4000);
BEGIN
   value_list_ := ' ^' || Language_sys.Translate_Constant(lu_name_ ,'TRANS1: Not Updated Vouchers') || '^';
   value_list_ := value_list_ || Language_sys.Translate_Constant(lu_name_ ,'TRANS2: Not Updated Vouchers with Period Allocation') || '^';
   value_list_ := value_list_ || Language_sys.Translate_Constant(lu_name_ ,'TRANS3: Not Posted Currency Revaluation') || '^';
   value_list_ := value_list_ || Language_sys.Translate_Constant(lu_name_ ,'TRANS4: Not Posted Revenue Recognition') || '^';
   value_list_ := value_list_ || Language_sys.Translate_Constant(lu_name_ ,'TRANS5: Not Closed Cost Allocation Procedure') || '^';
   value_list_ := value_list_ || Language_sys.Translate_Constant(lu_name_ ,'TRANS6: Not Consolidated Balances from Subsidiaries') || '^';
   value_list_ := value_list_ || Language_sys.Translate_Constant(lu_name_ ,'TRANS7: Pending Transfers from Distribution/Manufacturing') || '^';
   value_list_ := value_list_ || Language_sys.Translate_Constant(lu_name_ ,'TRANS9: Pending Transfers from Maintenance') || '^';
   value_list_ := value_list_ || Language_sys.Translate_Constant(lu_name_ ,'TRANS8: Customer Invoices with Posting Errors') || '^';
   value_list_ := value_list_ || Language_sys.Translate_Constant(lu_name_ ,'TRANS10: Customer Invoices in Preliminary Status') || '^';
   value_list_ := value_list_ || Language_sys.Translate_Constant(lu_name_ ,'TRANS11: Not Approved Preliminary Payments') || '^';
   value_list_ := value_list_ || Language_sys.Translate_Constant(lu_name_ ,'TRANS12: Not Approved Mixed Payments') || '^';
   value_list_ := value_list_ || Language_sys.Translate_Constant(lu_name_ ,'TRANS13: Not Approved Cashbox') || '^';
   value_list_ := value_list_ || Language_sys.Translate_Constant(lu_name_ ,'TRANS14: Not Posted Trans. in Post Imported Trans. Window') || '^';
   value_list_ := value_list_ || Language_sys.Translate_Constant(lu_name_ ,'TRANS15: Not Posted Trans. in Change in Acq. Value') || '^';
   value_list_ := value_list_ || Language_sys.Translate_Constant(lu_name_ ,'TRANS16: Not Posted Trans. in Change Net Value') || '^';
   value_list_ := value_list_ || Language_sys.Translate_Constant(lu_name_ ,'TRANS17: Not Posted Depreciation Proposals') || '^';
   value_list_ := value_list_ || Language_sys.Translate_Constant(lu_name_ ,'TRANS18: Ext. Vouchers waiting to be Created') || '^';
   value_list_ := value_list_ || Language_sys.Translate_Constant(lu_name_ ,'TRANS19: Ext. Supplier Invoices waiting to be Created') || '^';
   value_list_ := value_list_ || Language_sys.Translate_Constant(lu_name_ ,'TRANS20: Ext. Customer Invoices waiting to be Created') || '^';
   value_list_ := value_list_ || Language_sys.Translate_Constant(lu_name_ ,'TRANS21: Ext. Payments waiting to be Created') || '^';
   
   RETURN value_list_;
END Get_GL_Trans_Types;

@UncheckedAccess
FUNCTION Get_GL_Trans_Types_Db  RETURN VARCHAR2
IS
   value_list_    VARCHAR2(4000);
BEGIN
   value_list_ := ' ^' || 'NOT UPDATED VOUCHERS' || '^';
   value_list_ := value_list_ || 'NOT UPDATED VOUCHERS WITH PERIOD ALLOCATION' || '^';
   value_list_ := value_list_ || 'NOT POSTED CURRENCY REVALUATION' || '^';
   value_list_ := value_list_ || 'NOT POSTED REVENUE RECOGNITION' || '^';
   value_list_ := value_list_ || 'NOT CLOSED COST ALLOCATION PROCEDURE' || '^';
   value_list_ := value_list_ || 'NOT CONSOLIDATED BALANCES FROM SUBSIDIARIES' || '^';
   value_list_ := value_list_ || 'PENDING TRANSFERS FROM DISTRIBUTION/MANUFACTURING' || '^';
   value_list_ := value_list_ || 'PENDING TRANSFERS FROM MAINTENANCE' || '^';
   value_list_ := value_list_ || 'CUSTOMER INVOICES WITH POSTING ERRORS' || '^';
   value_list_ := value_list_ || 'CUSTOMER INVOICES IN PRELIMINARY STATUS' || '^';
   value_list_ := value_list_ || 'NOT APPROVED PRELIMINARY PAYMENTS' || '^';
   value_list_ := value_list_ || 'NOT APPROVED MIXED PAYMENTS' || '^';
   value_list_ := value_list_ || 'NOT APPROVED CASHBOX' || '^';
   value_list_ := value_list_ || 'NOT POSTED TRANS IN POST IMPORTED TRANS WINDOW' || '^';
   value_list_ := value_list_ || 'NOT POSTED TRANS IN CHANGE IN ACQ VALUE' || '^';
   value_list_ := value_list_ || 'NOT POSTED TRANS IN CHANGE NET VALUE' || '^';
   value_list_ := value_list_ || 'NOT POSTED DEPRECIATION PROPOSALS' || '^';
   value_list_ := value_list_ || 'EXT VOUCHERS WAITING TO BE CREATED' || '^';
   value_list_ := value_list_ || 'EXT SUPPLIER INVOICES WAITING TO BE CREATED' || '^';
   value_list_ := value_list_ || 'EXT CUSTOMER INVOICES WAITING TO BE CREATED' || '^';
   value_list_ := value_list_ || 'EXT PAYMENTS WAITING TO BE CREATED' || '^';
   
   RETURN value_list_;
END Get_GL_Trans_Types_Db;

@UncheckedAccess
FUNCTION Get_Not_Transferred  (
   company_            IN     VARCHAR2,
   accounting_year_    IN     NUMBER,
   accounting_period_  IN     NUMBER,
   trans_type_         IN     VARCHAR2)  RETURN NUMBER
IS
   start_date_          DATE;
   end_date_            DATE;
   count_               NUMBER := 0;
   
   CURSOR get_not_updated_vouchers_ IS
      SELECT 1
      from VOUCHER 
      where company = company_ 
            AND voucher_updated_db = 'N' AND accounting_year = accounting_year_ AND accounting_period = accounting_period_;
   $IF Component_Invoic_SYS.INSTALLED $THEN         
      CURSOR get_cus_inv_post_err_ IS
         SELECT 1
         from INVOICE 
         WHERE  company = company_ 
                AND ((objstate = 'Printed' AND NVL(ok_create_voucher, 'FALSE') = 'FALSE') OR 
                     (objstate = 'Preliminary' AND creator = 'MAN_CUST_INVOICE_API' AND multi_invoice_voucher = 'TRUE' 
                      AND ok_create_voucher = 'FALSE')) 
                      AND invoice_date BETWEEN start_date_ AND end_date_;
      CURSOR get_cus_inv_in_prel_status_ IS
         SELECT 1
         from invoice WHERE company = company_ 
         AND  objstate = 'Preliminary' AND party_type = 'CUSTOMER' 
         AND multi_invoice_voucher IS NULL 
         AND invoice_date BETWEEN start_date_ AND end_date_;
   $END
   $IF Component_Payled_SYS.INSTALLED $THEN 
      CURSOR get_not_approved_prel_payment_ IS
         SELECT 1
         from prel_payment  
         WHERE company = company_ AND voucher_date BETWEEN start_date_ AND end_date_;
      CURSOR get_not_approved_mix_payment_ IS
         SELECT 1
         from MIXED_PAYMENT 
         where company = company_ 
         AND objstate  = 'NotApproved' AND voucher_date_ref BETWEEN start_date_ AND end_date_;
      CURSOR get_not_approved_cashbox_ IS
         SELECT 1
         from cash_box WHERE company = company_ AND 
         objstate  = 'Entered' AND voucher_date_ref BETWEEN start_date_ AND end_date_;
   $END
                
BEGIN
   start_date_ := Accounting_Period_Api.Get_Date_From(company_, accounting_year_, accounting_period_);
   end_date_   := Accounting_Period_Api.Get_Date_Until(company_, accounting_year_, accounting_period_);
   IF(trans_type_ = 'NOT UPDATED VOUCHERS') THEN
      OPEN  get_not_updated_vouchers_;
      FETCH get_not_updated_vouchers_ INTO count_;
      IF get_not_updated_vouchers_%FOUND THEN
         CLOSE get_not_updated_vouchers_;
         RETURN ERROR;
      ELSE
         CLOSE get_not_updated_vouchers_;
         RETURN SUCCESS;
      END IF;
   ELSIF (trans_type_ = 'NOT UPDATED VOUCHERS WITH PERIOD ALLOCATION') THEN
      IF(Period_Allocation_API.Check_Year_Period_Exist(company_, accounting_year_ , accounting_period_) = 'TRUE') THEN
         RETURN ERROR;
      ELSE
         RETURN SUCCESS;
      END IF;
   ELSIF (trans_type_ = 'NOT POSTED CURRENCY REVALUATION') THEN
      $IF Component_Genled_SYS.INSTALLED $THEN
         IF(Currency_Revaluation_API.Check_Non_Posted_Reval_Exist(company_, accounting_year_ , accounting_period_) = 'TRUE') THEN
            RETURN ERROR;
         ELSE
            RETURN SUCCESS;
         END IF;
      $ELSE
         RETURN SUCCESS;
      $END
   ELSIF (trans_type_ = 'NOT POSTED REVENUE RECOGNITION') THEN
      $IF Component_Genled_SYS.INSTALLED $THEN
         IF(Revenue_Recognition_API.All_Posted_For_Period(company_, accounting_year_ , accounting_period_) = 'TRUE') THEN
            RETURN SUCCESS;
         ELSE
            RETURN ERROR;
         END IF;
      $ELSE
         RETURN SUCCESS;
      $END
   ELSIF (trans_type_ = 'NOT CLOSED COST ALLOCATION PROCEDURE') THEN
      $IF Component_Percos_SYS.INSTALLED $THEN
         IF(Cost_Allocation_Procedure_API.Check_Non_Closed_Proc_Exist(company_, accounting_year_ , accounting_period_) = 'TRUE') THEN
            RETURN ERROR;
         ELSE
            RETURN SUCCESS;
         END IF;
      $ELSE
         RETURN SUCCESS;
      $END
   ELSIF (trans_type_ = 'NOT CONSOLIDATED BALANCES FROM SUBSIDIARIES') THEN
      $IF Component_Conacc_SYS.INSTALLED $THEN
         IF(Company_Cons_Trans_API.All_Bal_Trans_Cons_For_Period(company_, accounting_year_ , accounting_period_) IS NULL) THEN
            RETURN SUCCESS;
         ELSE
            RETURN ERROR;
         END IF;
      $ELSE
         RETURN SUCCESS;
      $END
   ELSIF (trans_type_ = 'PENDING TRANSFERS FROM DISTRIBUTION/MANUFACTURING') THEN
      $IF Component_Mpccom_SYS.INSTALLED $THEN   
         IF(Mpccom_Accounting_API.All_Postings_Transferred(company_, start_date_, end_date_) = 'TRUE') THEN
            RETURN SUCCESS;
         ELSE
            RETURN ERROR;
         END IF;
      $ELSE
         RETURN SUCCESS;
      $END
   ELSIF (trans_type_ = 'PENDING TRANSFERS FROM MAINTENANCE') THEN
      $IF Component_Wo_SYS.INSTALLED $THEN
         IF(Pcm_Accounting_API.All_Postings_Transferred(company_, start_date_, end_date_) = 'TRUE') THEN
            RETURN SUCCESS;
         ELSE
            RETURN ERROR;
         END IF;
      $ELSE
         RETURN SUCCESS;
      $END
   ELSIF (trans_type_ = 'CUSTOMER INVOICES WITH POSTING ERRORS') THEN
      $IF Component_Invoic_SYS.INSTALLED $THEN
         OPEN  get_cus_inv_post_err_;
         FETCH get_cus_inv_post_err_ INTO count_;
         IF get_cus_inv_post_err_%FOUND THEN
            CLOSE get_cus_inv_post_err_;
            RETURN WARNING;
         ELSE
            CLOSE get_cus_inv_post_err_;
            RETURN SUCCESS;
         END IF;
      $ELSE
         RETURN SUCCESS;
      $END
   ELSIF (trans_type_ = 'CUSTOMER INVOICES IN PRELIMINARY STATUS') THEN
      $IF Component_Invoic_SYS.INSTALLED $THEN
         OPEN  get_cus_inv_in_prel_status_;
         FETCH get_cus_inv_in_prel_status_ INTO count_;
         IF get_cus_inv_in_prel_status_%FOUND THEN
            CLOSE get_cus_inv_in_prel_status_;
            RETURN WARNING;
         ELSE
            CLOSE get_cus_inv_in_prel_status_;
            RETURN SUCCESS;
         END IF;
      $ELSE
         RETURN SUCCESS;
      $END
   ELSIF (trans_type_ = 'NOT APPROVED PRELIMINARY PAYMENTS') THEN
      $IF Component_Payled_SYS.INSTALLED $THEN 
         OPEN  get_not_approved_prel_payment_;
         FETCH get_not_approved_prel_payment_ INTO count_;
         IF get_not_approved_prel_payment_%FOUND THEN
            CLOSE get_not_approved_prel_payment_;
            RETURN WARNING;
         ELSE
            CLOSE get_not_approved_prel_payment_;
            RETURN SUCCESS;
         END IF;
      $ELSE
         RETURN SUCCESS;
      $END
   ELSIF (trans_type_ = 'NOT APPROVED MIXED PAYMENTS') THEN
      $IF Component_Payled_SYS.INSTALLED $THEN 
         OPEN  get_not_approved_mix_payment_;
         FETCH get_not_approved_mix_payment_ INTO count_;
         IF get_not_approved_mix_payment_%FOUND THEN
            CLOSE get_not_approved_mix_payment_;
            RETURN WARNING;
         ELSE
            CLOSE get_not_approved_mix_payment_;
            RETURN SUCCESS;
         END IF;
      $ELSE
         RETURN SUCCESS;
      $END
   ELSIF (trans_type_ = 'NOT APPROVED CASHBOX') THEN
      $IF Component_Payled_SYS.INSTALLED $THEN 
         OPEN  get_not_approved_cashbox_;
         FETCH get_not_approved_cashbox_ INTO count_;
         IF get_not_approved_cashbox_%FOUND THEN
            CLOSE get_not_approved_cashbox_;
            RETURN WARNING;
         ELSE
            CLOSE get_not_approved_cashbox_;
            RETURN SUCCESS;
         END IF;
      $ELSE
         RETURN SUCCESS;
      $END
   ELSIF (trans_type_ = 'NOT POSTED TRANS IN POST IMPORTED TRANS WINDOW') THEN
      $IF Component_Fixass_SYS.INSTALLED $THEN
         IF(Fa_Object_Transaction_API.All_Imp_Trans_Post_For_Period(company_, start_date_, end_date_) = 'TRUE') THEN
            RETURN SUCCESS;
         ELSE
            RETURN WARNING;
         END IF;
      $ELSE
         RETURN SUCCESS;
      $END
   ELSIF (trans_type_ = 'NOT POSTED TRANS IN CHANGE IN ACQ VALUE') THEN
      $IF Component_Fixass_SYS.INSTALLED $THEN
         IF(Change_Object_Value_Temp_API.All_Change_Acq_Post_For_Period(company_, start_date_, end_date_) = 'TRUE') THEN
            RETURN SUCCESS;
         ELSE
            RETURN WARNING;
         END IF;
      $ELSE
         RETURN SUCCESS;
      $END
   ELSIF (trans_type_ = 'NOT POSTED TRANS IN CHANGE NET VALUE') THEN
      $IF Component_Fixass_SYS.INSTALLED $THEN
         IF(Change_Object_Value_Temp_API.All_Change_Net_Post_For_Period(company_, start_date_, end_date_) = 'TRUE') THEN
            RETURN SUCCESS;
         ELSE
            RETURN WARNING;
         END IF;
      $ELSE
         RETURN SUCCESS;
      $END
   ELSIF (trans_type_ = 'NOT POSTED DEPRECIATION PROPOSALS') THEN
      $IF Component_Fixass_SYS.INSTALLED $THEN
         IF(Depr_Proposal_API.All_Proposal_Post_For_Period(company_, accounting_year_ , accounting_period_) = 'TRUE') THEN
            RETURN SUCCESS;
         ELSE
            RETURN WARNING;
         END IF;
      $ELSE
         RETURN SUCCESS;
      $END
   ELSIF (trans_type_ = 'EXT VOUCHERS WAITING TO BE CREATED') THEN
      IF(Ext_Load_Info_API.Check_Non_Created_ExtVou_Exist(company_, start_date_, end_date_) = 'TRUE') THEN
         RETURN WARNING;
      ELSE
         RETURN SUCCESS;
      END IF;
   ELSIF (trans_type_ = 'EXT SUPPLIER INVOICES WAITING TO BE CREATED') THEN
      $IF Component_Invoic_SYS.INSTALLED $THEN
         IF(Ext_Inc_Inv_Load_Info_API.Check_Non_Created_Inv_Exist(company_, accounting_year_ , accounting_period_, start_date_, end_date_) = 'TRUE') THEN
            RETURN WARNING;
         ELSE
            RETURN SUCCESS;
         END IF;
      $ELSE
         RETURN SUCCESS;
      $END
   ELSIF (trans_type_ = 'EXT CUSTOMER INVOICES WAITING TO BE CREATED') THEN
      $IF Component_Invoic_SYS.INSTALLED $THEN
         IF(Ext_Out_Inv_Load_Info_API.Check_Non_Created_Inv_Exist(company_, accounting_year_ , accounting_period_, start_date_, end_date_) = 'TRUE') THEN
            RETURN WARNING;
         ELSE
            RETURN SUCCESS;
         END IF;
      $ELSE
         RETURN SUCCESS;
      $END
   ELSIF (trans_type_ = 'EXT PAYMENTS WAITING TO BE CREATED') THEN
      $IF Component_Payled_SYS.INSTALLED $THEN
         IF(Ext_Payment_Head_API.Check_Non_Used_Pay_Exist(company_, accounting_year_ , accounting_period_, start_date_, end_date_) = 'TRUE') THEN
            RETURN WARNING;
         ELSE
            RETURN SUCCESS;
         END IF;
      $ELSE
         RETURN SUCCESS;
      $END
   ELSE
      RETURN NOT_AVAILABLE;
   END IF;
END Get_Not_Transferred;