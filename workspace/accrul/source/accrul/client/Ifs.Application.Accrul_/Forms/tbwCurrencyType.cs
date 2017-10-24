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
    [FndWindowRegistration("CURRENCY_TYPE", "CurrencyType", FndWindowRegistrationFlags.HomePage)]
    public partial class tbwCurrencyType : cTableWindowFin
    {
        #region Window Variables
        public SalString sCompanyName = "";
        public SalArray<SalString> sPlaceHolders = new SalArray<SalString>();
        public SalArray<SalString> sChanges = new SalArray<SalString>();
        public SalString sID = "";
        public SalNumber nNumChanges = 0;
        public SalString sOldDefault = "";
        public SalNumber nRow = 0;
        public SalNumber nCurrentRow = 0;
        public SalString sDefaultRefCode = "";
        public SalString sDefaultType = "";
        public SalBoolean bOk = false;
        public SalArray<SalString> sItemNames = new SalArray<SalString>();
        public SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public tbwCurrencyType()
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
        public new static tbwCurrencyType FromHandle(SalWindowHandle handle)
        {
            return ((tbwCurrencyType)SalWindow.FromHandle(handle, typeof(tbwCurrencyType)));
        }
        #endregion

        #region Methods

        /// <summary>
        /// </summary>
        /// <returns></returns>
        // Bug 83502, Removed FrameStartupUser and moved code to vrtActivate  
        // Bug 83502, Added method vrtActivate and moved in code from FrameStartupUser
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public override SalNumber vrtActivate(fcURL URL)
        {
            #region Local Variables
            // Bug 83134, Begin
            SalString sProfileString = "";
            SalArray<SalString> sItemValues = new SalArray<SalString>();
            // Bug 83134, End
            #endregion

            using (new SalContext(this))
            {
                // Bug 83134, Begin, Modified Code
                if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.RecCountGet() > 0)
                {
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet("COMPANY", sItemValues);
                    i_sCompany = sItemValues[0];
                    sProfileString = "COMPANY" + "^" + i_sCompany;
                    Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.AM_UserProfileValueSet, 0, sProfileString.ToHandle());
                    sProfileString = "COMPANY" + ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_US).ToCharacter() + i_sCompany + ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_RS).ToCharacter();
                    Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_UserProfileChanged, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, sProfileString.ToHandle());
                    SetWindowTitle();
                }
                // Bug 83134, End
            }
            return base.Activate(URL);
        }
                
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public new SalString GetWindowTitle()
        {
            #region Actions
            using (new SalContext(this))
            {
                return Properties.Resources.WH_tbwCurrencyType;
            }
            #endregion
        }

        /// <summary>
        /// This function sets default values for some form's fields
        /// </summary>
        /// <returns></returns>
        public new SalBoolean DataRecordGetDefaults()
        {
            #region Actions
            using (new SalContext(this))
            {
                colCompany.Text = i_sCompany;
                colCompany.EditDataItemSetEdited();
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="sWhat"></param>
        /// <returns></returns>
        public virtual SalNumber RightMouseClick(SalString sWhat)
        {
            #region Local Variables
            SalArray<SalString> sItemNames = new SalArray<SalString>();
            SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                Sal.WaitCursor(true);
                sItemNames[0] = "CURRENCY_TYPE";
                hWndItems[0] = colIdType;
                Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("TYPETYPES", this, sItemNames, hWndItems);
                SessionCreateWindow(Pal.GetActiveInstanceName("frmCurrencyRate"), Sys.hWndMDI);
                Sal.WaitCursor(false);
            }

            return 0;
            #endregion
        }
        #endregion

        #region Window Actions

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tbwCurrencyType_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceQueryFieldName:
                    this.tbwCurrencyType_OnPM_DataSourceQueryFieldName(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove:
                    this.tbwCurrencyType_OnPM_DataRecordRemove(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave:
                    this.tbwCurrencyType_OnPM_DataSourceSave(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataSourceQueryFieldName event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwCurrencyType_OnPM_DataSourceQueryFieldName(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if ((SalString.FromHandle(Sys.lParam) == "COMPANY") && (Sys.wParam != Vis.DT_Handle))
            {
                e.Return = (this.i_hWndFrame.ToNumber().ToString(0) + ".tbwCurrencyType.i_sCompany").ToHandle();
                return;
            }
            else
            {
                e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceQueryFieldName, Sys.wParam, Sys.lParam);
                return;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataSourceSave event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwCurrencyType_OnPM_DataSourceSave(object sender, WindowActionsEventArgs e)
        {
            e.Handled = true;
            this.bOk = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Sys.wParam, Sys.lParam);
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute && this.bOk)
            {
                Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceRefresh, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
            }
            e.Return = this.bOk;
            return;
        }

        /// <summary>
        /// PM_DataRecordRemove event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwCurrencyType_OnPM_DataRecordRemove(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("CURRENCY_TYPE_API.Check_If_Default_Rate", System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                    this.bOk = this.DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN\r\n " + cSessionManager.c_sDbPrefix + "CURRENCY_TYPE_API.Check_If_Default_Rate(\r\n" +
                        " :i_hWndFrame.tbwCurrencyType.sDefaultType,\r\n" +
                        " :i_hWndFrame.tbwCurrencyType.colCompany,\r\n" +
                        " :i_hWndFrame.tbwCurrencyType.colIdType\r\n" +
                        ");  \r\n END;");
                }
                if (this.sDefaultType == "TRUE")
                {
                    if (Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_CurrencyRateType + " " + tbwCurrencyType.FromHandle(this.i_hWndFrame).colIdType.Text + " "  + Properties.Resources.TEXT_CurrencyDefaultRate + " " + this.colRefCurrencyCode.Text + Properties.Resources.TEXT_CurrencyProceed,
                        Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, (Ifs.Fnd.ApplicationForms.Const.WARNING_YesNo | Sys.MB_DefButton2)) == Sys.IDYES)
                    {
                        e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove, Sys.wParam, Sys.lParam);
                        return;
                    }
                    else
                    {
                        e.Return = false;
                        return;
                    }
                }
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colRefCurrencyCode_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.colRefCurrencyCode_OnSAM_SetFocus(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom:
                    this.colRefCurrencyCode_OnPM_DataItemZoom(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colRefCurrencyCode_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.colsRateTypeCategoryDb.Text == "NORMAL")
            {
                this.colRefCurrencyCode.p_sLovReference = "COMPANY_FINANCE1(COMPANY)";
            }
            else
            {
                this.colRefCurrencyCode.p_sLovReference = "CURRENCY_CODE(COMPANY)";
            }
            #endregion
        }

        private void colRefCurrencyCode_OnPM_DataItemZoom(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            switch (Sys.wParam)
            {
                case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();
                    this.sItemNames[0] = "COMPANY";
                    this.hWndItems[0] = this.colCompany;
                    this.sItemNames[1] = "CURRENCY_CODE";
                    this.hWndItems[1] = this.colRefCurrencyCode;                    
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("CurrencyCode", this.colRefCurrencyCode.i_hWndFrame, this.sItemNames, this.hWndItems);
                    SessionNavigate(Pal.GetActiveInstanceName("tbwCurrencyCode"));
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
        private void colTypeDefault_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_Validate:
                    this.colTypeDefault_OnSAM_Validate(sender, e);
                    break;

                case Sys.SAM_SetFocus:
                    this.colTypeDefault_OnSAM_SetFocus(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_Validate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colTypeDefault_OnSAM_Validate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.ListQuerySelection(this.colTypeDefault) == 1)
            {
                if (this.sOldDefault != this.colTypeDefault.Text)
                {
                    Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_ChangeDefaultValue, "Error", Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                    e.Return = false;
                    return;
                }
            }
            if (Sal.SendClassMessage(Sys.SAM_Validate, Sys.wParam, Sys.lParam))
            {
                if (Sal.ListQuerySelection(this.colTypeDefault) == 0)
                {
                    this.nCurrentRow = Sal.TblQueryContext(this.colTypeDefault.i_hWndFrame);
                    this.nRow = Sys.TBL_MinRow;
                    while (true)
                    {
                        if (Sal.TblFindNextRow(this.colTypeDefault.i_hWndFrame, ref this.nRow, 0, 0))
                        {
                            Sal.TblSetContext(this.colTypeDefault.i_hWndFrame, this.nRow);
                            if (this.nCurrentRow != this.nRow && this.sDefaultRefCode == this.colRefCurrencyCode.Text)
                            {
                                Sal.ListSetSelect(this.colTypeDefault, 1);
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                    Sal.TblSetContext(this.colTypeDefault.i_hWndFrame, this.nCurrentRow);
                }
                e.Return = true;
                return;
            }
            e.Return = false;
            return;
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colTypeDefault_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.sOldDefault = this.colTypeDefault.Text;
            this.sDefaultRefCode = this.colRefCurrencyCode.Text;
            e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
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

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        
        #endregion

        #region Event Handlers

        private void menuItem_Currency_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled =  ( (Sal.TblAnyRows(Sys.hWndForm, Sys.ROW_Selected, 0)) && (Ifs.Fnd.ApplicationForms.Var.Security.IsViewAvailable("CURRENCY_RATE")));
        }

        private void menuItem_Currency_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            RightMouseClick("EDIT");
        }

        private void menuItem_Change_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Sys.lParam);
        }

        private void menuItem_Change_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Sys.lParam);
        }

        private void menuItem_Currency_1_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = Sal.TblAnyRows(Sys.hWndForm, Sys.ROW_Selected, 0);
        }

        private void menuItem_Currency_1_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            RightMouseClick("EDIT");
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
