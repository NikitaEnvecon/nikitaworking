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
// 130130  MaRalk  PBR-1203, Replaced view CUSTOMER_INFO with CUSTOMER_INFO_CUSTCATEGORY_PUB in colsCustomerId_OnSAM_SetFocus. 
#endregion

using System;
using System.Text;
using System.Drawing;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;
using System.ComponentModel;
using Ifs.Application.Accrul;
using Ifs.Application.Appsrv;
using Ifs.Application.Enterp;
using Ifs.Fnd.ApplicationForms;
using PPJ.Runtime;
using PPJ.Runtime.Sql;
using PPJ.Runtime.Vis;
using PPJ.Runtime.Windows;
using PPJ.Runtime.Windows.QO;
using Ifs.Fnd.Windows.Forms;

namespace Ifs.Application.Accrul_
{
	
	/// <summary>
	/// </summary>
    [FndWindowRegistration("PAYMENT_VACATION_PERIOD", "PaymentVacationPeriod")]
    public partial class tbwPaymentVacationPeriod : cTableWindowFin
    {
        #region Window Variables
        public SalString sModule = "";
        public SalString sLu = "";
        public SalString lsAttribute = "";

        /// <summary>
        /// Standard method parameter
        /// Standard method parameter. Possible values are METHOD_Inquire, METHOD_Execute.
        /// </summary>
        public SalNumber nWhat = 0;

        /// <summary>
        /// Window name
        /// Name of window to create.
        /// </summary>
        public SalString sMessage = "";
        public SalString sStmt = "";
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public tbwPaymentVacationPeriod()
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
        public new static tbwPaymentVacationPeriod FromHandle(SalWindowHandle handle)
        {
            return ((tbwPaymentVacationPeriod)SalWindow.FromHandle(handle, typeof(tbwPaymentVacationPeriod)));
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
                return Properties.Resources.WH_tbwPaymentVacationPeriod;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <param name="sMessage"></param>
        /// <returns></returns>
        public virtual SalString ModifyZoomMessageInv(SalNumber nWhat, SalString sMessage)
        {
            #region Local Variables
            cMessage mParams = new cMessage();
            cMessage mModifiedParams = new cMessage();
            SalString sDestination = "";
            SalString sTransferType = "";
            SalNumber nItems = 0;
            SalNumber i = 0;
            SalArray<SalString> sNames = new SalArray<SalString>();
            SalArray<SalString> sValues = new SalArray<SalString>();
            SalString sNewWindowName = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                mParams.Unpack(sMessage);
                sDestination = mParams.FindAttribute("__DESTINATION", "Dummy1").ToUpper();
                sTransferType = mParams.FindAttribute("__TYPE", "Dummy2").ToUpper();
                if (sTransferType != "ZOOM")
                {
                    return sMessage;
                }
                nItems = mParams.EnumAttributes(sNames, sValues);
                while (i < nItems)
                {
                    if (sNames[i].Left(2) == "__")
                    {
                        // Copy data which controls the transfer
                        if ((sNames[i] == "__NAME") && ((sDestination == "INVOICE_TYPE") || (sDestination == "IDENTITY_PAY_INFO_CUST")))
                        {
                            // Modify to new window name
                            mModifiedParams.AddAttribute(sNames[i], sNewWindowName);
                        }
                        else
                        {
                            mModifiedParams.AddAttribute(sNames[i], sValues[i]);
                        }
                    }
                    else
                    {
                        if (sDestination == "IDENTITY_INVOICE_INFO_CUST")
                        {
                            // Whenever zooming to this view we should only send customer identity
                            // and it should be identified as 'CUSTOMER_ID'
                            if (sNames[i] == "CUSTOMER_ID" || sNames[i] == "IDENTITY" || sNames[i] == "PARTY_IDENTITY" || sNames[i] == "CUST_ID")
                            {
                                mModifiedParams.AddAttribute(sNames[i], "CUSTOMER_ID");
                            }
                            else
                            {
                                // Ignore all other attributes
                            }
                        }
                        else
                        {
                            // Whenever zooming to this view in some cases Foundation is not able to
                            // change VOUCHER_COMPANY to 'COMPANY' so we have to do that
                            mModifiedParams.AddAttribute(sNames[i], sValues[i]);
                        }
                    }
                    i = i + 1;
                }
                return mModifiedParams.Pack();
            }
            #endregion
        }
        // Bug 72811 begin.
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public new SalBoolean FrameStartupUser()
        {
            #region Actions
            using (new SalContext(this))
            {
                if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.RecCountGet() > 0)
                {
                    Sal.WaitCursor(true);
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemValueStrGet(Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemIndexGet("COMPANY"), 0, ref i_sCompany);
                    SetWindowTitle();
                    InitFromTransferredData();
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();
                    Sal.WaitCursor(false);
                    return false;
                }
                return true;
            }
            #endregion
        }
        #endregion

        #region Window Actions

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tbwPaymentVacationPeriod_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceCreateWindowTrans:
                    this.tbwPaymentVacationPeriod_OnPM_DataSourceCreateWindowTrans(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataSourceCreateWindowTrans event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwPaymentVacationPeriod_OnPM_DataSourceCreateWindowTrans(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            // Modify the zoom message if needed
            this.sMessage = SalString.FromHandle(Sys.lParam);
            this.sMessage = this.ModifyZoomMessageInv(Sys.wParam, this.sMessage);
            e.Return = this.DataSourceCreateWindowTrans(Sys.wParam, this.sMessage);
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colsPaymentMethod_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovUserWhere:
                    this.colsPaymentMethod_OnPM_DataItemLovUserWhere(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom:
                    this.colsPaymentMethod_OnPM_DataItemZoom(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemLovUserWhere event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colsPaymentMethod_OnPM_DataItemLovUserWhere(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.sStmt = "PARTY_TYPE_DB=&AO.PARTY_TYPE_API.ENCODE(:i_hWndFrame.tbwPaymentVacationPeriod.colsPartyType)";
            e.Return = this.sStmt.ToHandle();
            return;
            #endregion
        }

        private void colsPaymentMethod_OnPM_DataItemZoom(object sender, WindowActionsEventArgs e)
        {
            #region Local Variables
            SalArray<SalString> sItemNames = new SalArray<SalString>();
            SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
            #endregion

            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();
                hWndItems[0] = this.colsCompany;
                sItemNames[0] = "COMPANY";
                hWndItems[1] = this.colsPaymentMethod;
                sItemNames[1] = "WAY_ID";
                Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("PayVacationPeriod", this.i_hWndFrame, sItemNames, hWndItems);
                SessionNavigate(Pal.GetActiveInstanceName("tbwPaymentWay"));
                e.Return = true;
                return;
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colsCustomerId_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.colsCustomerId_OnSAM_SetFocus(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colsCustomerId_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Ifs.Fnd.ApplicationForms.Var.Security.AreAllViewsAvailable("IDENTITY_INVOICE_INFO_CUST"))
            {
                this.colsCustomerId.p_sLovReference = "IDENTITY_INVOICE_INFO_CUST(COMPANY)";
            }
            else
            {
                this.colsCustomerId.p_sLovReference = "CUSTOMER_INFO_CUSTCATEGORY_PUB";
            }
            Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
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
        #endregion

        #region Event Handlers

        private void menuItem_Change_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Sys.lParam);
        }

        private void menuItem_Change_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Sys.lParam);
        }

        #endregion

    }
}
