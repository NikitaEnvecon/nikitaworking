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
    [FndWindowRegistration("PAYMENT_TERM", "PaymentTerm", FndWindowRegistrationFlags.HomePage)]
    public partial class tbwPaymentTerm : cTableWindowFin
    {
        #region Window Variables
        public SalString sModule = "";
        public SalString sLu = "";
        public SalString lsAttribute = "";
        public SalString sReductCashDisc= "";
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public tbwPaymentTerm()
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
        public new static tbwPaymentTerm FromHandle(SalWindowHandle handle)
        {
            return ((tbwPaymentTerm)SalWindow.FromHandle(handle, typeof(tbwPaymentTerm)));
        }
        #endregion

        #region Methods

        public new SalBoolean FrameStartupUser()
        {
            base.FrameStartupUser();
            IFndExplorerNavigationNotificationService notificationService = IFndApplication.GetExplorerFromCurrentThread().NavigationNotification;
            notificationService.NavigateFeatureActivated += new FndNavigationEventHandler(notificationService_NavigateFeatureActivated);
            return true;
        }

        /// <summary>
        /// Gets default values for NEW records
        /// </summary>
        /// <returns></returns>
        public new SalBoolean DataRecordGetDefaults()
        {
            #region Actions
            using (new SalContext(this))
            {
                colCompany.Text = i_sCompany;
                colCompany.EditDataItemSetEdited();
                colBlockForDirectDebiting.Text = "FALSE";
                colBlockForDirectDebiting.EditDataItemSetEdited();
                colsConsiderPayVacPeriod.Text = "FALSE";
                colsConsiderPayVacPeriod.EditDataItemSetEdited();
                colsCashDiscFixassAcqValueDb.Text = sReductCashDisc;
                colsCashDiscFixassAcqValueDb.EditDataItemSetEdited();
                return true;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public new SalString GetWindowTitle()
        {
            #region Actions
            using (new SalContext(this))
            {
                return Properties.Resources.WH_tbwPaymentTerm;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="sFormName"></param>
        /// <returns></returns>
        public virtual SalBoolean PrepareLaunch(SalString sFormName)
        {
            #region Local Variables
            SalString sSourceName = "";
            SalArray<SalString> sItemNames = new SalArray<SalString>();
            SalWindowHandle hWndSource = SalWindowHandle.Null;
            SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                if (sFormName == Pal.GetActiveInstanceName("frmPaymentTermDetails"))
                {
                    Sal.WaitCursor(true);
                    sSourceName = Pal.GetActiveInstanceName("tbwPaymentTerm");
                    sItemNames[0] = "COMPANY";
                    sItemNames[1] = "PAY_TERM_ID";
                    hWndSource = i_hWndFrame;
                    hWndItems[0] = colCompany;
                    hWndItems[1] = colPayTermId;
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init(sSourceName, hWndSource, sItemNames, hWndItems);
                    SessionCreateWindow(Pal.GetActiveInstanceName("frmPaymentTermDetails"), Sys.hWndMDI);
                    Sal.WaitCursor(false);
                    return true;
                    Sal.WaitCursor(true);
                }
                else
                {
                    return false;
                }
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="sFormName">Bug 72811, Begin.</param>
        /// <returns></returns>
        public virtual SalBoolean UMPaymentVacationLaunch(SalString sFormName)
        {
            // Bug 72811, End.

            #region Local Variables
            // Bug 72811, Begin.
            SalString sSourceName = "";
            SalArray<SalString> sItemNames = new SalArray<SalString>();
            SalWindowHandle hWndSource = SalWindowHandle.Null;
            SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
            // Bug 72811, End.
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                // Bug 72811, Begin.
                if (sFormName == Pal.GetActiveInstanceName("tbwPaymentVacationPeriod"))
                {
                    Sal.WaitCursor(true);
                    sSourceName = Pal.GetActiveInstanceName("tbwPaymentTerm");
                    sItemNames[0] = "COMPANY";
                    hWndSource = i_hWndFrame;
                    hWndItems[0] = colCompany;
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init(sSourceName, hWndSource, sItemNames, hWndItems);
                    SessionCreateWindow(Pal.GetActiveInstanceName("tbwPaymentVacationPeriod"), Sys.hWndMDI);
                    Sal.WaitCursor(false);
                    return true;
                }
                else
                {
                    return false;
                }
                // Bug 72811, End.
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber Translation()
        {
            #region Local Variables
            SalNumber nRow = 0;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                Sal.WaitCursor(true);
                sModule = "ACCRUL";
                sLu = "PaymentTerm";
                lsAttribute = Ifs.Fnd.ApplicationForms.Const.strNULL;
                nRow = Sys.TBL_MinRow;
                while (true)
                {
                    if (Sal.TblFindNextRow(i_hWndFrame, ref nRow, Sys.ROW_Selected, 0))
                    {
                        Sal.TblSetContext(i_hWndFrame, nRow);
                        lsAttribute = lsAttribute + "'" + colPayTermId.Text + "'" + ",";
                    }
                    else
                    {
                        break;
                    }
                }
                if (lsAttribute != Ifs.Fnd.ApplicationForms.Const.strNULL)
                {
                    lsAttribute = lsAttribute.Left(lsAttribute.Length - 1);
                }
                Ifs.Fnd.ApplicationForms.Var.Cache.SessionStore("TRANSLATE_COMPANY", i_sCompany);
                Ifs.Fnd.ApplicationForms.Var.Cache.SessionStore("TRANSLATE_MODULE", sModule);
                Ifs.Fnd.ApplicationForms.Var.Cache.SessionStore("TRANSLATE_LU", sLu);
                Ifs.Fnd.ApplicationForms.Var.Cache.SessionStore("TRANSLATE_ATTRIBUTE", lsAttribute);
                SessionCreateWindow(Pal.GetActiveInstanceName("frmCompanyTranslation"), Sys.hWndMDI);
                Sal.WaitCursor(false);
                return true;
            }
            #endregion
        }
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public override SalNumber vrtActivate(fcURL URL)
        {
            #region Local Variables
            SalNumber nRC = 0;
            SalNumber nItemIndex = 0;
            SalBoolean bDataTransfer = false;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.RecCountGet() > 0)
                {
                    Sal.WaitCursor(true);
                    if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.TypeGet() == "ZOOM")
                    {
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.i_sItemNames[0] = "PAY_TERM_ID";
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.i_sItemNames[1] = "COMPANY";
                    }
                    nItemIndex = Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemIndexGet("COMPANY");
                    if (nItemIndex >= 0)
                    {
                        nRC = Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemValueStrGet(nItemIndex, 0, ref i_sCompany);
                    }
                    SetWindowTitle();
                    InitFromTransferredData();
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();
                    Sal.WaitCursor(false);
                    bDataTransfer = true;
                }
                if (Int.IsFixAssInstalled)
                {
                    DbPLSQLBlock(@":i_hWndFrame.tbwPaymentTerm.sReductCashDisc := &AO.Fa_Company_API.Get_Reduction_Cash_Discount_Db(:i_hWndFrame.tbwPaymentTerm.i_sCompany IN)");
                }
                if (bDataTransfer)
                   return false;
                return base.Activate(URL);
            }

            #endregion

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
            if (Int.IsFixAssInstalled)
                DbPLSQLBlock(@":i_hWndFrame.tbwPaymentTerm.sReductCashDisc := &AO.Fa_Company_API.Get_Reduction_Cash_Discount_Db(:i_hWndFrame.tbwPaymentTerm.i_sCompany IN)");
        }

        #endregion

        #region Window Actions

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colsVatDistribution_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.colsVatDistribution_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colsVatDistribution_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            using (SignatureHints hints = SignatureHints.NewContext())
            {
                hints.Add("PAYMENT_TERM_API.Check_Vat_Distribution", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                if (this.colsVatDistribution.DbPLSQLBlock(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "PAYMENT_TERM_API.Check_Vat_Distribution(\r\n" +
                    "   :i_hWndFrame.tbwPaymentTerm.colCompany,\r\n" +
                    "   :i_hWndFrame.tbwPaymentTerm.colPayTermId,   \r\n" +
                    "   :i_hWndFrame.tbwPaymentTerm.colsVatDistribution)"))
                {
                    e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
                    return;
                }
            }
            #endregion
        }

        private void tableWindow_colsCashDiscFixassAcqValueDb_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.tableWindow_colsCashDiscFixassAcqValueDb_OnPM_DataItemQueryEnabled(sender, e);
                    break;
                case Sys.SAM_AnyEdit:
                    this.tableWindow_colsCashDiscFixassAcqValueDb_OnSAM_AnyEdit(sender, e);
                    break;
            }
            #endregion
        }

        private void tableWindow_colsCashDiscFixassAcqValueDb_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            e.Handled = true;
            if (!Int.IsFixAssInstalled)
            {
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                return;
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled, Sys.wParam, Sys.lParam);
        }

        private void tableWindow_colsCashDiscFixassAcqValueDb_OnSAM_AnyEdit(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Sys.SAM_AnyEdit, Sys.wParam, Sys.lParam))
            {
                if (this.sReductCashDisc == "FALSE" && this.colsCashDiscFixassAcqValueDb.Text == "TRUE")
                { 
                    Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_ReductCashDiscNoChk, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Warning, Ifs.Fnd.ApplicationForms.Const.WARNING_Ok);
                }
                e.Return = true;
            }
            e.Return = false;
            return;
            #endregion
        }

        #endregion

        #region Late Bind Methods

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalBoolean vrtDataRecordGetDefaults()
        {
            return this.DataRecordGetDefaults();
        }
        // Insert new code here...

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalString vrtGetWindowTitle()
        {
            return this.GetWindowTitle();
        }

        public override SalBoolean vrtFrameStartupUser()
        {
            return this.FrameStartupUser();
        }

        #endregion

        #region Event Handlers

        private void menuItem_Payment_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = Sal.TblAnyRows(i_hWndFrame, Sys.ROW_Selected, 0);
        }

        private void menuItem_Payment_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            PrepareLaunch(Pal.GetActiveInstanceName("frmPaymentTermDetails"));
        }

        private void menuItem_Translation_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = Sal.TblAnyRows(i_hWndFrame, Sys.ROW_Selected, 0) && Ifs.Fnd.ApplicationForms.Var.Component.IsWindowAvailable(Pal.GetActiveInstanceName("frmCompanyTranslation")) && Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("frmCompanyTranslation"));
        }

        private void menuItem_Translation_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            Translation();
        }

        private void menuItem_Payment_1_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            // Bug 75104, Begin, checked for security permission
            if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsViewAvailable("PAYMENT_VACATION_PERIOD")))
            {
                ((FndCommand)sender).Enabled = false;
            }
            if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("tbwPaymentVacationPeriod"))))
            {
                ((FndCommand)sender).Enabled = false;
            }
            // Bug 75104, End
            else
            {
                ((FndCommand)sender).Enabled = Sal.TblAnyRows(i_hWndFrame, Sys.ROW_Selected, 0);
            }            
        }

        private void menuItem_Payment_1_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            UMPaymentVacationLaunch(Pal.GetActiveInstanceName("tbwPaymentVacationPeriod"));
        }

        private void menuItem_Change_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Sys.lParam);
        }

        private void menuItem_Change_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Sys.lParam);
        }

        private void menuItem_Translation_1_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = Sal.TblAnyRows(i_hWndFrame, Sys.ROW_Selected, 0) && Ifs.Fnd.ApplicationForms.Var.Component.IsWindowAvailable(Pal.GetActiveInstanceName("frmCompanyTranslation")) && Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("frmCompanyTranslation"));
        }

        private void menuItem_Translation_1_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            Translation();
        }

        private void menuItem_Change_1_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Sys.lParam);
        }

        private void menuItem_Change_1_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Sys.lParam);
        }

        #endregion

    }
}
