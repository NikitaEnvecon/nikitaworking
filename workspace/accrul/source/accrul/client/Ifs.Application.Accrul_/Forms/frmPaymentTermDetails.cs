#region Copyright (c) IFS Research & Development
// ======================================================================================================
//
//                 IFS Research & Development
//
//  This program is protected by copyright law and by international
//  conventions. All licensing, renting, lending or copying (including
//  for private use), and all other use of the program, which is not
//  explicitly permitted by IFS, is a violation of the rights
//  of IFS. Such violations will be reported to the
//  appropriate authorities.
//
//  VIOLATIONS OF ANY COPYRIGHT IS PUNISHABLE BY LAW AND CAN LEAD
//  TO UP TO TWO YEARS OF IMPRISONMENT AND LIABILITY TO PAY DAMAGES.
// ======================================================================================================
#endregion
#region History
// Date    By      Notes
// ------  ------  -------------------------------------------------------------------------------------
// 141023  Dihelk  PRFI-3067, Merged the bug 119192.
#endregion

using System.Windows.Forms;
using Ifs.Application.Accrul;
using Ifs.Fnd.ApplicationForms;
using Ifs.Fnd.Explorer.Interfaces;
using Ifs.Fnd.Windows.Forms;
using PPJ.Runtime;
using PPJ.Runtime.Sql;
using PPJ.Runtime.Windows;

namespace Ifs.Application.Accrul_
{
	
	/// <summary>
	/// </summary>
    [FndWindowRegistration("PAYMENT_TERM_DETAILS", "PaymentTermDetails")]
    public partial class frmPaymentTermDetails : cFormWindowFin
    {
        #region Window Variables
        public SalString sVatDistributionValue = "";
        public SalNumber nNoOfInstallments = 0;
        public SalNumber nNoOfFreeDelivMonths = 0;
        public SalNumber nDaysToDueDate = 0;
        public SalNumber nDueDay1 = 0;
        public SalNumber nDueDay2 = 0;
        public SalNumber nDueDay3 = 0;
        public SalString sInstituteId = "";
        public SalString sWayId = "";
        public SalString sEndOfMonth = "";
        public SalBoolean bRetValue = false;
        public SalArray<SalNumber> nInstallments = new SalArray<SalNumber>();
        public SalBoolean bOk = false;
        public SalNumber nIsFixassInstalled = 0;
        public SalString sReductCashDisc = "";
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public frmPaymentTermDetails()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();
        }
        #endregion

        #region System Methods/Properties

        /// <summary>
        /// Returns the object instance associated with the window handle.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public new static frmPaymentTermDetails FromHandle(SalWindowHandle handle)
        {
            return ((frmPaymentTermDetails)SalWindow.FromHandle(handle, typeof(frmPaymentTermDetails)));
        }
        #endregion

        #region Methods

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public new SalString GetWindowTitle()
        {
            #region Actions
            using (new SalContext(this))
            {
                return Properties.Resources.WH_frmPaymentTermDetails;
            }
            #endregion
        }

        
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public new SalBoolean FrameStartupUser()
        {
            IFndExplorerNavigationNotificationService notificationService = IFndApplication.GetExplorerFromCurrentThread().NavigationNotification;
            notificationService.NavigateFeatureActivated += new FndNavigationEventHandler(notificationService_NavigateFeatureActivated);
            base.FrameStartupUser();
            if (Int.IsFixAssInstalled)
            {
                nIsFixassInstalled = 1;
            }
            return true;
        }

        public new SalNumber Activate(fcURL URL)
        {
            using (new SalContext(this))
            {
                base.Activate(URL);
                if (nIsFixassInstalled == 1)
                {
                    DbPLSQLBlock(@":i_hWndFrame.frmPaymentTermDetails.sReductCashDisc := &AO.Fa_Company_API.Get_Reduction_Cash_Discount_Db(:i_hWndFrame.frmPaymentTermDetails.i_sCompany IN)");
                }
                return true;
            }
        }

        #endregion

        #region Window Actions

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void frmPaymentTermDetails_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave:
                    this.frmPaymentTermDetails_OnPM_DataSourceSave(sender, e);
                    break;

                case Sys.SAM_Create:
                    this.frmPaymentTermDetails_OnSAM_Create(sender, e);
                    break;

            }
            #endregion
        }

        /// <summary>
        /// PM_DataSourceSave event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmPaymentTermDetails_OnPM_DataSourceSave(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                if (!(this.CheckInstallmentRecords()))
                {
                    e.Return = false;
                    return;
                }
                if (!(this.CheckSumNetAmount()))
                {
                    e.Return = false;
                    return;
                }
                if (!(this.CheckNetPercentage()))
                {
                    e.Return = false;
                    return;
                }
                if (!(this.CheckInstallmentRange()))
                {
                    Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.ERROR_InstallmentRangeError, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                    e.Return = false;
                    return;
                }
                this.bRetValue = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Sys.wParam, Sys.lParam);
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("PAYMENT_TERM_DETAILS_API.Regen_Installments", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                    this.DbPLSQLBlock(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "PAYMENT_TERM_DETAILS_API.Regen_Installments(\r\n" +
                        "   :i_hWndFrame.frmPaymentTermDetails.dfsCompany,\r\n" +
                        "   :i_hWndFrame.frmPaymentTermDetails.cmbPayTermId)");
                }
                if (this.bRetValue)
                {
                    Sal.SendMsg(this.tblPaymentTermDetails, Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Ifs.Fnd.ApplicationForms.Const.POPULATE_Single);
                }
                e.Return = this.bRetValue;
                return;
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// SAM_Create event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmPaymentTermDetails_OnSAM_Create(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam);
            using (SignatureHints hints = SignatureHints.NewContext())
            {
                hints.Add("Vat_Distribution_API.Decode", System.Data.ParameterDirection.Input);
                this.DbPLSQLBlock(cSessionManager.c_hSql, ":i_hWndFrame.frmPaymentTermDetails.sVatDistributionValue := &AO.Vat_Distribution_API.Decode('FIRSTINSTONLYTAX')");
            }
            #endregion
        }

        private void cbCashDiscFixassAcqValueDb_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.cbCashDiscFixassAcqValueDb_OnPM_DataItemQueryEnabled(sender, e);
                    break;
                case Sys.SAM_AnyEdit:
                    this.cbCashDiscFixassAcqValueDb_OnSAM_AnyEdit(sender, e);
                    break;
            }
            #endregion
        }

        private void cbCashDiscFixassAcqValueDb_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.nIsFixassInstalled == 0)
            {
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                return;
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        private void cbCashDiscFixassAcqValueDb_OnSAM_AnyEdit(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Sys.SAM_AnyEdit, Sys.wParam, Sys.lParam))
            {
                if (this.sReductCashDisc == "FALSE" && this.cbCashDiscFixassAcqValueDb.IsChecked())
                {
                    Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_ReductCashDiscNoChk, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Warning, Ifs.Fnd.ApplicationForms.Const.WARNING_Ok);
                }
                e.Return = true;
            }
            e.Return = false;
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblPaymentTermDetails_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordDuplicate:
                    this.tblPaymentTermDetails_OnPM_DataRecordDuplicate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew:
                    this.tblPaymentTermDetails_OnPM_DataRecordNew(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordCopy:
                    e.Handled = true;
                    e.Return = false;
                    return;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataRecordDuplicate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblPaymentTermDetails_OnPM_DataRecordDuplicate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire)
            {
                this.bOk = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordDuplicate, Sys.wParam, Sys.lParam);
                this.nRetValue = this.CheckLastDayEncounted(this.tblPaymentTermDetails_colnInstallmentNumber.Number);
                if (this.nRetValue == 1)
                {
                    e.Return = false;
                    return;
                }
                e.Return = this.bOk;
                return;
            }
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                this.bOk = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordDuplicate, Sys.wParam, Sys.lParam);
                this.tblPaymentTermDetails_colnDayFrom.Number = this.GetNextDayFrom(this.tblPaymentTermDetails_colnInstallmentNumber.Number);
                this.tblPaymentTermDetails_colnDayFrom.EditDataItemSetEdited();
                this.tblPaymentTermDetails_colnDayTo.Number = 31;
                this.tblPaymentTermDetails_colnDayTo.EditDataItemSetEdited();
                e.Return = this.bOk;
                return;
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordDuplicate, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataRecordNew event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblPaymentTermDetails_OnPM_DataRecordNew(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                this.bOk = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew, Sys.wParam, Sys.lParam);
                this.nInstIncomplete = 1;
                if (!(this.tblPaymentTermDetails_colnInstallmentNumber.EditDataItemStateGet() == Ifs.Fnd.ApplicationForms.Const.EDIT_Changed) || Sal.IsNull(this.tblPaymentTermDetails_colnInstallmentNumber))
                {
                    if (!(this.CheckInstallmentRange()))
                    {
                        this.tblPaymentTermDetails_colnInstallmentNumber.Number = this.nInstIncomplete;
                    }
                    else
                    {
                        this.tblPaymentTermDetails_colnInstallmentNumber.Number = this.GetMaxInstallmentId() + 1;
                    }
                    this.tblPaymentTermDetails_colnInstallmentNumber.EditDataItemSetEdited();
                }
                Sal.SendMsg(this.tblPaymentTermDetails_colnInstallmentNumber, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
                e.Return = this.bOk;
                return;
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }
        #endregion

        #region Late Bind Methods

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalBoolean vrtFrameStartupUser()
        {
            return this.FrameStartupUser();
        }

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalString vrtGetWindowTitle()
        {
            return this.GetWindowTitle();
        }

        public override SalNumber vrtActivate(fcURL URL)
        {
            return this.Activate(URL);
        }

        public override SalBoolean vrtFrameShutdownUser(SalNumber nWhat)
        {
            if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                IFndExplorerNavigationNotificationService notificationService = IFndApplication.GetExplorerFromCurrentThread().NavigationNotification;
                notificationService.NavigateFeatureActivated -= new FndNavigationEventHandler(notificationService_NavigateFeatureActivated);
            }
            return base.vrtFrameShutdownUser(nWhat);
        }

        void notificationService_NavigateFeatureActivated(object sender, FndNavigationEventArgs e)
        {
            #region Actions
            if (nIsFixassInstalled == 1)
            {
                DbPLSQLBlock(cSessionManager.c_hSql,
                                    @":i_hWndFrame.frmPaymentTermDetails.sReductCashDisc := &AO.Fa_Company_API.Get_Reduction_Cash_Discount_Db(
                                                    :i_hWndFrame.frmPaymentTermDetails.i_sCompany)");
            }
            #endregion
        }

        #endregion

        #region ChildTable-tblPaymentTermDetails

        #region Window Variables
        public SalNumber nRetValue = 0;
        public SalNumber nInstIncomplete = 0;
        //public SalString sResult = "";
        //public SalString sFormatId = "";
        #endregion

        #region Methods

        /// <summary>
        /// Checks if the sum of the NetAmountcolumns are 100
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean CheckSumNetAmount()
        {
            #region Actions

            if (!(Sal.TblAnyRows(tblPaymentTermDetails, 0, Sys.ROW_MarkDeleted)))
            {
                return true;
            }
            SalNumber nRow = Sys.TBL_MinRow;
            SalNumber nCurrentRow = Sal.TblQueryContext(tblPaymentTermDetails);
            SalNumber nSum = 0;
            while (Sal.TblFindNextRow(tblPaymentTermDetails, ref nRow, 0, Sys.ROW_MarkDeleted))
            {
                Sal.TblSetContext(tblPaymentTermDetails, nRow);
                if (tblPaymentTermDetails_colnDayFrom.Number == 1)
                {
                    nSum = nSum + tblPaymentTermDetails_colnNetAmountPercentage.Number;
                }
            }
            if (nSum != 100)
            {
                Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.ERROR_CheckSumNetAmount, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                Sal.TblSetContext(tblPaymentTermDetails, nCurrentRow);
                Sal.TblSetFocusCell(tblPaymentTermDetails, Sal.TblQueryContext(tblPaymentTermDetails), tblPaymentTermDetails_colnNetAmountPercentage, 0, 0);
                return false;
            }
            else
            {
                Sal.TblSetContext(tblPaymentTermDetails, nCurrentRow);
                return true;
            }
            
            #endregion
        }

        /// <summary>
        /// Some checkes on the installment records.
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean CheckInstallmentRecords()
        {
            #region Local Variables
            SalNumber nFirstDaysToDueDate = 0;
            #endregion

            #region Actions
            if (this.sVatDistributionValue == this.cmbVatDistribution.Text)
            {
                SalNumber nRow = Sys.TBL_MinRow;
                while (true)
                {
                    if (Sal.TblFindNextRow(tblPaymentTermDetails, ref nRow, 0, Sys.ROW_MarkDeleted))
                    {
                        Sal.TblSetContext(tblPaymentTermDetails, nRow);
                        // Only zero in colnNetAmount on the first row
                        if (!(tblPaymentTermDetails_colnNetAmountPercentage.Number == 0) && tblPaymentTermDetails_colnInstallmentNumber.Number == MinInstallmentNo())
                        {
                            Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.ERROR_NetAmountMustZero, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                            return false;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                Sal.TblSetContext(tblPaymentTermDetails, nRow);
                nRow = Sys.TBL_MinRow;
                while (Sal.TblFindNextRow(tblPaymentTermDetails, ref nRow, Sys.ROW_MarkDeleted, 0))
                {
                    Sal.TblSetContext(tblPaymentTermDetails, nRow);
                    if (tblPaymentTermDetails_colnInstallmentNumber.Number == MinInstallmentNo())
                    {
                        Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.ERROR_CannotDeleteFirst, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                        return false;
                    }
                }
            }
            return true;
            
            #endregion
        }

        /// <summary>
        /// Returns TRUE if the current context row is the first row
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean IsCurrentFirstRowOld()
        {
 
            SalNumber nContext = Sal.TblQueryContext(tblPaymentTermDetails);
            SalNumber nRow = Sys.TBL_MinRow;
            if (Sal.TblFindNextRow(tblPaymentTermDetails, ref nRow, 0, 0))
            {
                return (nContext == nRow);
            }
            return false;

        }

        /// <summary>
        /// Gets default values for NEW records
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean DataRecordGetDefaults()
        {       
            if (IsCurrentFirstRowOld())
            {
                if (this.cmbVatDistribution.Text == this.sVatDistributionValue)
                {
                    tblPaymentTermDetails_colnInstallmentNumber.Number = 1;
                    tblPaymentTermDetails_colnNetAmountPercentage.Number = 0;
                    tblPaymentTermDetails_colnDaysToDueDate.Number = 0;
                    tblPaymentTermDetails_colnInstallmentNumber.EditDataItemSetEdited();
                    tblPaymentTermDetails_colnNetAmountPercentage.EditDataItemSetEdited();
                    tblPaymentTermDetails_colnDaysToDueDate.EditDataItemSetEdited();
                }
            }
            return true;
        }

        /// <summary>
        /// Create Installmentrows
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean CreateAutomaticPaymentPlan()
        {
            #region Local Variables
            SalNumber nCountInstallments = 0;
            SalNumber nSum = 0;
            SalNumber nTotalRemaining = 0;
            SalNumber nRemaining = 0;
            SalNumber nSumNetAmount = 0;
            SalNumber nDays = 0;
            #endregion

            #region Actions

            nCountInstallments = 0;
            nSum = 0;
            nTotalRemaining = 0;
            nRemaining = 0;
            nDays = SalNumber.Null;
            while (true)
            {
                if (this.nNoOfInstallments != nCountInstallments)
                {
                    Sal.SendMsg(tblPaymentTermDetails, Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                    nCountInstallments = nCountInstallments + 1;
                    tblPaymentTermDetails_colnInstallmentNumber.Number = nCountInstallments;
                    tblPaymentTermDetails_colnInstallmentNumber.EditDataItemSetEdited();
                    tblPaymentTermDetails_colnDayFrom.Number = 1;
                    tblPaymentTermDetails_colnDayFrom.EditDataItemSetEdited();
                    tblPaymentTermDetails_colnDayTo.Number = 31;
                    tblPaymentTermDetails_colnDayTo.EditDataItemSetEdited();
                    tblPaymentTermDetails_colnFreeDeliveryMonths.Number = this.nNoOfFreeDelivMonths;
                    tblPaymentTermDetails_colnFreeDeliveryMonths.EditDataItemSetEdited();
                    if (this.nDaysToDueDate != SalNumber.Null)
                    {
                        nDays = nDays + this.nDaysToDueDate;
                        tblPaymentTermDetails_colnDaysToDueDate.Number = nDays;
                        tblPaymentTermDetails_colnDaysToDueDate.EditDataItemSetEdited();
                    }
                    tblPaymentTermDetails_colEndOfMonth.Text = this.sEndOfMonth;
                    tblPaymentTermDetails_colEndOfMonth.EditDataItemSetEdited();
                    tblPaymentTermDetails_colnDueDate1.Number = this.nDueDay1;
                    tblPaymentTermDetails_colnDueDate1.EditDataItemSetEdited();
                    tblPaymentTermDetails_colnDueDate2.Number = this.nDueDay2;
                    tblPaymentTermDetails_colnDueDate2.EditDataItemSetEdited();
                    tblPaymentTermDetails_colnDueDate3.Number = this.nDueDay3;
                    tblPaymentTermDetails_colnDueDate3.EditDataItemSetEdited();
                    // The first row when cmbVatDistribution has the value 'First Installment Only Vat'
                    if ((this.sVatDistributionValue == this.cmbVatDistribution.Text) && (nCountInstallments == 1))
                    {
                        tblPaymentTermDetails_colnNetAmountPercentage.Number = 0;
                    }
                    // The other rows when cmbVatDistribution has the value 'First Installment Only Vat'
                    else if ((this.sVatDistributionValue == this.cmbVatDistribution.Text) && (nCountInstallments > 1))
                    {
                        tblPaymentTermDetails_colnNetAmountPercentage.Number = (100 / (this.nNoOfInstallments - 1)).Truncate(10, 7);
                        nSum = tblPaymentTermDetails_colnNetAmountPercentage.Number;
                        nRemaining = (100 / (this.nNoOfInstallments - 1)) - tblPaymentTermDetails_colnNetAmountPercentage.Number;
                        SumNetAmount(ref nSumNetAmount, ref nSum, ref nTotalRemaining, nRemaining, nCountInstallments);
                    }
                    else
                    {
                        tblPaymentTermDetails_colnNetAmountPercentage.Number = (100 / this.nNoOfInstallments).Truncate(10, 7);
                        nSum = tblPaymentTermDetails_colnNetAmountPercentage.Number;
                        nRemaining = (100 / this.nNoOfInstallments) - tblPaymentTermDetails_colnNetAmountPercentage.Number;
                        SumNetAmount(ref nSumNetAmount, ref nSum, ref nTotalRemaining, nRemaining, nCountInstallments);
                    }
                    tblPaymentTermDetails_colnNetAmountPercentage.EditDataItemSetEdited();
                    tblPaymentTermDetails_colsPaymentMethod.Text = this.sWayId;
                    tblPaymentTermDetails_colsPaymentMethod.EditDataItemSetEdited();
                    tblPaymentTermDetails_colsPaymentInstitute.Text = this.sInstituteId;
                    tblPaymentTermDetails_colsPaymentInstitute.EditDataItemSetEdited();
                    Sal.SetFocus(tblPaymentTermDetails_colnInstallmentNumber);
                }
                else
                {
                    break;
                }
            }
            return true;
            
            #endregion
        }

        /// <summary>
        /// Make so Net Amount will be 100
        /// </summary>
        /// <param name="nSumNetAmount"></param>
        /// <param name="nSum"></param>
        /// <param name="nTotalRemaining"></param>
        /// <param name="nRemaining"></param>
        /// <param name="nCountInstallments"></param>
        /// <returns></returns>
        public virtual SalNumber SumNetAmount(ref SalNumber nSumNetAmount, ref SalNumber nSum, ref SalNumber nTotalRemaining, SalNumber nRemaining, SalNumber nCountInstallments)
        {
            if (nCountInstallments == this.nNoOfInstallments)
            {
                // The last row gets a value so it will be 100.
                tblPaymentTermDetails_colnNetAmountPercentage.Number = 100 - nSumNetAmount;
            }
            else if (nTotalRemaining > 0.01m)
            {
                tblPaymentTermDetails_colnNetAmountPercentage.Number = tblPaymentTermDetails_colnNetAmountPercentage.Number + 0.01m;
                nTotalRemaining = nTotalRemaining - 0.01m + nRemaining;
                nSumNetAmount = nSumNetAmount + tblPaymentTermDetails_colnNetAmountPercentage.Number;
            }
            else
            {
                nSumNetAmount = nSumNetAmount + nSum;
                nTotalRemaining = nTotalRemaining + nRemaining;
            }
           
            return 0;
        }

        /// <summary>
        /// Returns the Minimum Installment No Value
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber MinInstallmentNo()
        {
            SalNumber nRow = Sys.TBL_MinRow;
            SalNumber nTemp = 999;
            while (true)
            {
                if (Sal.TblFindNextRow(tblPaymentTermDetails, ref nRow, 0, Sys.ROW_MarkDeleted))
                {
                    Sal.TblSetContext(tblPaymentTermDetails, nRow);
                    if (tblPaymentTermDetails_colnInstallmentNumber.Number < nTemp)
                    {
                        nTemp = tblPaymentTermDetails_colnInstallmentNumber.Number;
                    }
                }
                else
                {
                    break;
                }
            }
            return nTemp;
      
        }

        /// <summary>
        /// Validates This Field
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean ValidateDueDate1()
        {
            if (tblPaymentTermDetails_colnDueDate1.Number == Sys.NUMBER_Null)
            {
                tblPaymentTermDetails_colnDueDate2.Number = Sys.NUMBER_Null;
                tblPaymentTermDetails_colnDueDate2.EditDataItemSetEdited();
                tblPaymentTermDetails_colnDueDate3.Number = Sys.NUMBER_Null;
                tblPaymentTermDetails_colnDueDate3.EditDataItemSetEdited();
                return Sys.VALIDATE_Ok;
            }
            else
            {
                if ((tblPaymentTermDetails_colnDueDate1.Number < 1) || (tblPaymentTermDetails_colnDueDate1.Number > 31))
                {
                    Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.ERROR_DueDateSpecific, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                    return Sys.VALIDATE_Cancel;
                }
                else
                {
                    return Sys.VALIDATE_Ok;
                }
            }
        }

        /// <summary>
        /// Validates This Field
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean ValidateDueDate2()
        {
            if (tblPaymentTermDetails_colnDueDate2.Number == Sys.NUMBER_Null)
            {
                tblPaymentTermDetails_colnDueDate3.Number = Sys.NUMBER_Null;
                tblPaymentTermDetails_colnDueDate3.EditDataItemSetEdited();
                return Sys.VALIDATE_Ok;
            }
            else
            {
                if ((tblPaymentTermDetails_colnDueDate2.Number < 1) || (tblPaymentTermDetails_colnDueDate2.Number > 31))
                {
                    Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.ERROR_DueDateSpecific, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                    return Sys.VALIDATE_Cancel;
                }
                else
                {
                    if (tblPaymentTermDetails_colnDueDate1.Number == Sys.NUMBER_Null)
                    {
                        Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.ERROR_DueDate2, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                        tblPaymentTermDetails_colnDueDate2.Number = Sys.NUMBER_Null;
                        return Sys.VALIDATE_Ok;
                    }
                    else
                    {
                        return Sys.VALIDATE_Ok;
                    }
                    return Sys.VALIDATE_Ok;
                }
            }
        }

        /// <summary>
        /// Validates This Field
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean ValidateDueDate3()
        {
            if (tblPaymentTermDetails_colnDueDate3.Number == Sys.NUMBER_Null)
            {
                return Sys.VALIDATE_Ok;
            }
            else
            {
                if ((tblPaymentTermDetails_colnDueDate3.Number < 1) || (tblPaymentTermDetails_colnDueDate3.Number > 31))
                {
                    Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.ERROR_DueDateSpecific, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                    return Sys.VALIDATE_Cancel;
                }
                else
                {
                    if (tblPaymentTermDetails_colnDueDate2.Number == Sys.NUMBER_Null)
                    {
                        Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.ERROR_DueDate3, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                        tblPaymentTermDetails_colnDueDate3.Number = Sys.NUMBER_Null;
                        return Sys.VALIDATE_Ok;
                    }
                    else
                    {
                        return Sys.VALIDATE_Ok;
                    }
                }
                return Sys.VALIDATE_Ok;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="nInstNumber"></param>
        /// <param name="nDayFrom"></param>
        /// <returns></returns>
        public virtual SalBoolean IsInstallmentNumberExists(SalNumber nInstNumber, SalNumber nDayFrom)
        {
            #region Local Variables
            SalNumber nRow = 0;
            SalNumber nCurrentRow = 0;
            #endregion

            #region Actions
            nRow = Sys.TBL_MinRow;
            nCurrentRow = Sal.TblQueryContext(tblPaymentTermDetails);
            while (Sal.TblFindNextRow(tblPaymentTermDetails, ref nRow, 0, 0))
            {
                Sal.TblSetContext(tblPaymentTermDetails, nRow);
                if (tblPaymentTermDetails_colnInstallmentNumber.Number == nInstNumber && tblPaymentTermDetails_colnDayFrom.Number != nDayFrom)
                {
                    Sal.TblSetContext(tblPaymentTermDetails, nCurrentRow);
                    return true;
                }
            }
            Sal.TblSetContext(tblPaymentTermDetails, nCurrentRow);
            return false;
            #endregion
        }

        /// <summary>
        /// Checks If the Net Percentage Is Null
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean CheckNetPercentage()
        {
            SalNumber nCurrentRow = Sal.TblQueryContext(tblPaymentTermDetails);
            SalNumber nRow = Sys.TBL_MinRow;
            while (Sal.TblFindNextRow(tblPaymentTermDetails, ref nRow, 0, 0))
            {
                Sal.TblSetContext(tblPaymentTermDetails, nRow);
                if (tblPaymentTermDetails_colnDayFrom.Number == 1 && Sal.IsNull(tblPaymentTermDetails_colnNetAmountPercentage))
                {
                    Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.ERROR_NetPercentageIsNull, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                    Sal.TblSetContext(tblPaymentTermDetails, nCurrentRow);
                    Sal.TblSetFocusCell(tblPaymentTermDetails, Sal.TblQueryContext(tblPaymentTermDetails), tblPaymentTermDetails_colnNetAmountPercentage, 0, 0);
                    return false;
                }
            }
            Sal.TblSetContext(tblPaymentTermDetails, nCurrentRow);
            return true;
        }

        /// <summary>
        /// Returns the next possible Day From
        /// </summary>
        /// <param name="nInstNumber"></param>
        /// <returns></returns>
        public virtual SalNumber GetNextDayFrom(SalNumber nInstNumber)
        {          
            SalNumber nRow = Sys.TBL_MinRow;
            SalNumber nCurrentRow = Sal.TblQueryContext(tblPaymentTermDetails);
            SalNumber nReturnValue = 0;
            while (Sal.TblFindNextRow(tblPaymentTermDetails, ref nRow, 0, Sys.ROW_MarkDeleted))
            {
                Sal.TblSetContext(tblPaymentTermDetails, nRow);
                if (tblPaymentTermDetails_colnInstallmentNumber.Number == nInstNumber)
                {
                    if (!(Sal.IsNull(tblPaymentTermDetails_colnDayTo)))
                    {
                        if (tblPaymentTermDetails_colnDayTo.Number == 31)
                        {
                            Sal.TblSetContext(tblPaymentTermDetails, nCurrentRow);
                            tblPaymentTermDetails_colnInstallmentNumber.Number = Sys.NUMBER_Null;
                            Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.ERROR_FirstDayFrom, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                            return 0;
                        }
                        if (tblPaymentTermDetails_colnDayTo.Number > nReturnValue)
                        {
                            nReturnValue = tblPaymentTermDetails_colnDayTo.Number;
                        }
                    }
                }
            }
            Sal.TblSetContext(tblPaymentTermDetails, nCurrentRow);
            return nReturnValue + 1;
        }

        /// <summary>
        /// Checks if last day has been encounted for the installment
        /// </summary>
        /// <param name="nInstNumber"></param>
        /// <returns></returns>
        public virtual SalNumber CheckLastDayEncounted(SalNumber nInstNumber)
        {
            SalNumber nRow = Sys.TBL_MinRow;
            SalNumber nCurrentRow = Sal.TblQueryContext(tblPaymentTermDetails);
            SalNumber nReturnValue = 0;
            while (Sal.TblFindNextRow(tblPaymentTermDetails, ref nRow, 0, Sys.ROW_MarkDeleted))
            {
                Sal.TblSetContext(tblPaymentTermDetails, nRow);
                if (tblPaymentTermDetails_colnInstallmentNumber.Number == nInstNumber)
                {
                    if (!(Sal.IsNull(tblPaymentTermDetails_colnDayTo)))
                    {
                        if (tblPaymentTermDetails_colnDayTo.Number == 31)
                        {
                            Sal.TblSetContext(tblPaymentTermDetails, nCurrentRow);
                            return 1;
                        }
                    }
                }
            }
            Sal.TblSetContext(tblPaymentTermDetails, nCurrentRow);
            return 0;
        }

            

        /// <summary>
        /// </summary>
        /// <param name="sFormName"></param>
        /// <returns></returns>
        public virtual SalBoolean PrepareLaunch(SalString sFormName)
        {
            if (sFormName == Pal.GetActiveInstanceName("frmPaymentTermDisc"))
            {
                Sal.WaitCursor(true);
                Sal.SendMsg(tblPaymentTermDetails, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceCreateWindow, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, sFormName.ToHandle());
                Sal.WaitCursor(false);
                return true;
            }
            else
            {   return false;   }

        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean CheckInstallmentRange()
        {
            #region Local Variables
            SalNumber nUpperBound = 0;
            SalNumber nLoopValue = 0;
            SalBoolean bResult = false;
            #endregion

            #region Actions
            this.nInstallments.SetUpperBound(1, -1);
            SalNumber nRow = Sys.TBL_MinRow;
            SalNumber nCurrentRow = Sal.TblQueryContext(tblPaymentTermDetails);
            while (Sal.TblFindNextRow(tblPaymentTermDetails, ref nRow, 0, Sys.ROW_MarkDeleted))
            {
                Sal.TblSetContext(tblPaymentTermDetails, nRow);
                if (!(InstallmentExistInArray(tblPaymentTermDetails_colnInstallmentNumber.Number)))
                {
                    nUpperBound = this.nInstallments.GetUpperBound(1);
                    this.nInstallments[nUpperBound + 1] = tblPaymentTermDetails_colnInstallmentNumber.Number;
                }
            }

            nUpperBound = this.nInstallments.GetUpperBound(1);
            while (nLoopValue < nUpperBound)
            {
                nLoopValue = nLoopValue + 1;
                bResult = CheckRangeForSpecificInstallment(this.nInstallments[nLoopValue]);
                if (bResult == false)
                {
                    Sal.TblSetContext(tblPaymentTermDetails, nCurrentRow);
                    return false;
                }
            }
            Sal.TblSetContext(tblPaymentTermDetails, nCurrentRow);
            return true;
            #endregion

        }

        /// <summary>
        /// </summary>
        /// <param name="nInstallmentNumberToChk"></param>
        /// <returns></returns>
        public virtual SalBoolean InstallmentExistInArray(SalNumber nInstallmentNumberToChk)
        {
            SalNumber nLoopValue = 0;
            SalNumber nUpperBound = this.nInstallments.GetUpperBound(1);
            while (nLoopValue < nUpperBound)
            {
                nLoopValue = nLoopValue + 1;
                if (this.nInstallments[nLoopValue] == nInstallmentNumberToChk)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// </summary>
        /// <param name="nInstallmentNumberToChk"></param>
        /// <returns></returns>
        public virtual SalNumber CheckRangeForSpecificInstallment(SalNumber nInstallmentNumberToChk)
        {
            #region Local Variables
            SalBoolean bFinalDayEnoucounted = false;
            SalNumber nPreviouseDayTo = 0;
            #endregion

            #region Actions
            if (!(nInstallmentNumberToChk == SalNumber.Null))
            {
                SalNumber nRow = Sys.TBL_MinRow;
                bFinalDayEnoucounted = false;
                SalBoolean bWrongSequence = false;
                this.nInstIncomplete = 0;
                while (Sal.TblFindNextRow(tblPaymentTermDetails, ref nRow, 0, Sys.ROW_MarkDeleted))
                {
                    Sal.TblSetContext(tblPaymentTermDetails, nRow);
                    if (tblPaymentTermDetails_colnInstallmentNumber.Number == nInstallmentNumberToChk)
                    {
                        if (tblPaymentTermDetails_colnDayFrom.Number == 1)
                        {
                            nPreviouseDayTo = tblPaymentTermDetails_colnDayTo.Number;
                        }
                        else
                        {
                            if (tblPaymentTermDetails_colnDayFrom.Number != nPreviouseDayTo + 1)
                            {
                                bWrongSequence = true;
                            }
                            nPreviouseDayTo = tblPaymentTermDetails_colnDayTo.Number;
                        }
                        if (tblPaymentTermDetails_colnDayTo.Number == 31)
                        {
                            bFinalDayEnoucounted = true;
                        }
                    }
                }
                if (bWrongSequence || !(bFinalDayEnoucounted))
                {
                    nInstIncomplete = nInstallmentNumberToChk;
                    return false;
                }
                return true;
            }
            return true;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber GetMaxInstallmentId()
        {
            SalNumber nRow = Sys.TBL_MinRow;
            SalNumber nMaxInstallment = 0;
            SalNumber nCurrentRow = Sal.TblQueryContext(tblPaymentTermDetails);
            while (Sal.TblFindNextRow(tblPaymentTermDetails, ref nRow, 0, Sys.ROW_MarkDeleted))
            {
                Sal.TblSetContext(tblPaymentTermDetails, nRow);
                if (tblPaymentTermDetails_colnInstallmentNumber.Number > nMaxInstallment)
                {
                    nMaxInstallment = tblPaymentTermDetails_colnInstallmentNumber.Number;
                }
            }
            Sal.TblSetContext(tblPaymentTermDetails, nCurrentRow);
            return nMaxInstallment;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber ValidateInstallmentId()
        {
            if (Sal.IsNull(tblPaymentTermDetails_colnDummyInstallmentNumber))
            {
                tblPaymentTermDetails_colnDummyInstallmentNumber.Number = tblPaymentTermDetails_colnInstallmentNumber.Number;
            }
            else
            {
                if (tblPaymentTermDetails_colnDayFrom.Number != 1 && tblPaymentTermDetails_colnDummyInstallmentNumber.Number != tblPaymentTermDetails_colnInstallmentNumber.Number)
                {
                    Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.ERROR_InstallmentRangeError, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                    tblPaymentTermDetails_colnInstallmentNumber.Number = tblPaymentTermDetails_colnDummyInstallmentNumber.Number;
                    tblPaymentTermDetails_colnInstallmentNumber.EditDataItemSetEdited();
                }
            }
            
            return 0;
        }
        #endregion

        #region Window Actions

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblPaymentTermDetails_colnInstallmentNumber_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblPaymentTermDetails_colnInstallmentNumber_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblPaymentTermDetails_colnInstallmentNumber_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (!(this.tblPaymentTermDetails_colnDayFrom.EditDataItemStateGet() == Ifs.Fnd.ApplicationForms.Const.EDIT_Changed) || Sal.IsNull(this.tblPaymentTermDetails_colnDayFrom))
            {
                this.nRetValue = this.GetNextDayFrom(this.tblPaymentTermDetails_colnInstallmentNumber.Number);
                if (this.nRetValue == 0)
                {
                    e.Return = Sys.VALIDATE_Cancel;
                    return;
                }
                else
                {
                    this.tblPaymentTermDetails_colnDayFrom.Number = this.nRetValue;
                    this.tblPaymentTermDetails_colnDayFrom.EditDataItemSetEdited();
                    if (!(this.tblPaymentTermDetails_colnDayTo.EditDataItemStateGet() == Ifs.Fnd.ApplicationForms.Const.EDIT_Changed) || Sal.IsNull(this.tblPaymentTermDetails_colnDayTo))
                    {
                        this.tblPaymentTermDetails_colnDayTo.Number = 31;
                        this.tblPaymentTermDetails_colnDayTo.EditDataItemSetEdited();
                    }
                    this.ValidateInstallmentId();
                    e.Return = Sys.VALIDATE_Ok;
                    return;
                }
            }
            else
            {
                if (!(this.tblPaymentTermDetails_colnDayTo.EditDataItemStateGet() == Ifs.Fnd.ApplicationForms.Const.EDIT_Changed) || Sal.IsNull(this.tblPaymentTermDetails_colnDayTo))
                {
                    this.tblPaymentTermDetails_colnDayTo.Number = 31;
                    this.tblPaymentTermDetails_colnDayTo.EditDataItemSetEdited();
                }
                this.ValidateInstallmentId();
                e.Return = Sys.VALIDATE_Ok;
                return;
            }
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblPaymentTermDetails_colnDayTo_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblPaymentTermDetails_colnDayTo_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblPaymentTermDetails_colnDayTo_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.tblPaymentTermDetails_colnDayTo.Number < 2 || this.tblPaymentTermDetails_colnDayTo.Number > 31 || this.tblPaymentTermDetails_colnDayTo.Number == 30 || this.tblPaymentTermDetails_colnDayTo.Number <= this.tblPaymentTermDetails_colnDayFrom.Number)
            {
                Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.ERROR_DayToRange, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                e.Return = Sys.VALIDATE_Cancel;
                return;
            }
            e.Return = Sys.VALIDATE_Ok;
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblPaymentTermDetails_colnFreeDeliveryMonths_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblPaymentTermDetails_colnFreeDeliveryMonths_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblPaymentTermDetails_colnFreeDeliveryMonths_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (!(Sal.IsNull(this.tblPaymentTermDetails_colnFreeDeliveryMonths)))
            {
                if (this.tblPaymentTermDetails_colnFreeDeliveryMonths.Number < 0)
                {
                    Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.ERROR_InvalidMonth, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                    e.Return = Sys.VALIDATE_Cancel;
                    return;
                }
                e.Return = Sys.VALIDATE_Ok;
                return;
            }
            e.Return = Sys.VALIDATE_Ok;
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblPaymentTermDetails_colnDaysToDueDate_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblPaymentTermDetails_colnDaysToDueDate_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblPaymentTermDetails_colnDaysToDueDate_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (!(Sal.IsNull(this.tblPaymentTermDetails_colnDaysToDueDate)))
            {
                if (this.tblPaymentTermDetails_colnDaysToDueDate.Number < 0)
                {
                    Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.ERROR_DaysToDueDate, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                    e.Return = Sys.VALIDATE_Cancel;
                    return;
                }
                e.Return = Sys.VALIDATE_Ok;
                return;
            }
            e.Return = Sys.VALIDATE_Ok;
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblPaymentTermDetails_colnDueDate1_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    e.Handled = true;
                    e.Return = this.ValidateDueDate1();
                    return;
            }
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblPaymentTermDetails_colnDueDate2_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    e.Handled = true;
                    e.Return = this.ValidateDueDate2();
                    return;
            }
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblPaymentTermDetails_colnDueDate3_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    e.Handled = true;
                    e.Return = this.ValidateDueDate3();
                    return;
            }
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblPaymentTermDetails_colnNetAmountPercentage_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblPaymentTermDetails_colnNetAmountPercentage_OnPM_DataItemValidate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.tblPaymentTermDetails_colnNetAmountPercentage_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblPaymentTermDetails_colnNetAmountPercentage_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam))
            {
                if (this.tblPaymentTermDetails_colnNetAmountPercentage.Number < 0 && this.tblPaymentTermDetails_colnDayFrom.Number == 1)
                {
                    Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.ERROR_NetAmountNegative, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                    e.Return = Sys.VALIDATE_Cancel;
                    return;
                }
                else
                {
                    e.Return = Sys.VALIDATE_Ok;
                    return;
                }
            }
            else
            {
                e.Return = Sys.VALIDATE_Cancel;
                return;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblPaymentTermDetails_colnNetAmountPercentage_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.tblPaymentTermDetails_colnDayFrom.Number == 1)
            {
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldEnabled;
                return;
            }
            else
            {
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                return;
            }
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblPaymentTermDetails_colsPaymentInstitute_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.tblPaymentTermDetails_colsPaymentInstitute_OnSAM_SetFocus(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblPaymentTermDetails_colsPaymentInstitute_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.tblPaymentTermDetails_colsPaymentMethod.Text == Ifs.Fnd.ApplicationForms.Const.strNULL)
            {
                if (Ifs.Fnd.ApplicationForms.Var.Security.AreAllViewsAvailable("PAYMENT_INSTITUTE"))
                {
                    this.tblPaymentTermDetails_colsPaymentInstitute.p_sLovReference = "PAYMENT_INSTITUTE(COMPANY)";
                }
                else
                {
                    this.tblPaymentTermDetails_colsPaymentInstitute.p_sLovReference = Ifs.Fnd.ApplicationForms.Const.strNULL;
                }
            }
            else
            {
                if (Ifs.Fnd.ApplicationForms.Var.Security.AreAllViewsAvailable("PAYMENT_INSTITUTE_PER_WAY_ID"))
                {
                    this.tblPaymentTermDetails_colsPaymentInstitute.p_sLovReference = "PAYMENT_INSTITUTE_PER_WAY_ID(COMPANY, WAY_ID)";
                }
                else
                {
                    this.tblPaymentTermDetails_colsPaymentInstitute.p_sLovReference = Ifs.Fnd.ApplicationForms.Const.strNULL;
                }
            }
            Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblPaymentTermDetails_colsPaymentMethod_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.tblPaymentTermDetails_colsPaymentMethod_OnSAM_SetFocus(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblPaymentTermDetails_colsPaymentMethod_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.tblPaymentTermDetails_colsPaymentInstitute.Text == Ifs.Fnd.ApplicationForms.Const.strNULL)
            {
                if (Ifs.Fnd.ApplicationForms.Var.Security.AreAllViewsAvailable("PAYMENT_WAY"))
                {
                    this.tblPaymentTermDetails_colsPaymentMethod.p_sLovReference = "PAYMENT_WAY(COMPANY)";
                }
                else
                {
                    this.tblPaymentTermDetails_colsPaymentMethod.p_sLovReference = Ifs.Fnd.ApplicationForms.Const.strNULL;
                }
            }
            else
            {
                if (Ifs.Fnd.ApplicationForms.Var.Security.AreAllViewsAvailable("PAYMENT_WAY_PER_INSTITUTE3"))
                {
                    this.tblPaymentTermDetails_colsPaymentMethod.p_sLovReference = "PAYMENT_WAY_PER_INSTITUTE3(COMPANY, INSTITUTE_ID)";
                }
                else
                {
                    this.tblPaymentTermDetails_colsPaymentMethod.p_sLovReference = Ifs.Fnd.ApplicationForms.Const.strNULL;
                }
            }
            Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
            #endregion
        }
        #endregion

        #region Window Events

        private void tblPaymentTermDetails_DataRecordGetDefaultsEvent(object sender, FndReturnEventArgsSalBoolean e)
        {
            e.Handled = true;
            e.ReturnValue = this.DataRecordGetDefaults();
        }

        #endregion
        #endregion

        #region Event Handlers

            private void menuItem_Automatic_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            
                if (SourceStateQuery(Ifs.Fnd.ApplicationForms.Const.DATASOURCE_Query) && !(Sal.TblAnyRows(tblPaymentTermDetails, 0, 0)))
                {
                    ((FndCommand)sender).Enabled = true;
                }
                else
                {
                    ((FndCommand)sender).Enabled = false;
                }

            
        }

        private void menuItem_Automatic_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
                            SalBoolean bIsVatDist = false;   

                            nDaysToDueDate = 0;
                            nNoOfFreeDelivMonths = 0;
                            Sal.WaitCursor(true);
                            if (sVatDistributionValue == cmbVatDistribution.Text)
                            {
                                bIsVatDist = true;
                            }
                            else
                            {
                                bIsVatDist = false;
                            }
                            if (dlgPaymentTermDetails.ModalDialog(Ifs.Fnd.ApplicationForms.Int.Explorer.ExplorerForm, ref i_sCompany, ref nNoOfInstallments, ref nNoOfFreeDelivMonths, ref nDaysToDueDate, ref nDueDay1, ref nDueDay2, ref nDueDay3, ref sInstituteId, ref sWayId, ref sEndOfMonth, ref bIsVatDist) ==
                            Sys.IDOK)
                            {
                                this.CreateAutomaticPaymentPlan();
                                Sal.WaitCursor(false);
                               
                            }
        }

        private void menuItem_Change_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            
              ((FndCommand)sender).Enabled = Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Sys.lParam);
            
        }

        private void menuItem_Change_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Sys.lParam);
            
        }

        private void menuItem_Payment_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            if (Ifs.Fnd.ApplicationForms.Var.Component.IsWindowAvailable(Pal.GetActiveInstanceName("frmPaymentTermDisc")))
            {
                ((FndCommand)sender).Enabled = true;
            }
            else
            {
                ((FndCommand)sender).Enabled = false;
            }
        }

        private void menuItem_Payment_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {

            this.PrepareLaunch(Pal.GetActiveInstanceName("frmPaymentTermDisc"));
           
        }

        #endregion
    }
}
