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
// 104134  Samblk  Modified vrtActivate to get correct company from data transfer.
// 121205  Waudlk  Bug 107179, Registered the window with COMPANY_CURRENCY_LOV view as home page and disabled the security.

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
    [FndWindowRegistration("CURRENCY_CODE", "CurrencyCode", FndWindowRegistrationFlags.HomePage)]
    [FndWindowRegistration("COMPANY_FINANCE1", "CurrencyCode", FndWindowRegistrationFlags.HomePage)]
    [FndWindowRegistration("CURRENCY_RATE1", "CurrencyRate", FndWindowRegistrationFlags.HomePage)]
    [FndWindowRegistration("COMPANY_CURRENCY_LOV", "CurrencyCode", FndWindowRegistrationFlags.HomePage | FndWindowRegistrationFlags.NoSecurity)]
    public partial class tbwCurrencyCode : cTableWindowFin
    {
        #region Window Variables
        public SalString sCompanyName = "";
        public SalArray<SalString> sPlaceHolders = new SalArray<SalString>();
        public SalArray<SalString> sChanges = new SalArray<SalString>();
        public SalString sID = "";
        public SalNumber nNumChanges = 0;
        public SalString sDummyEmuCurrency = "";
        public SalNumber nRow = 0;
        public SalDateTime dDate = SalDateTime.Null;
        public SalString sCurrCode = "";
        public SalNumber nMyRow = 0;
        public SalString sAllDeletingCurrency = "";
        public SalArray<SalString> sDeleteParam = new SalArray<SalString>();
        public SalString bCanProceed = "";
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public tbwCurrencyCode()
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
        public new static tbwCurrencyCode FromHandle(SalWindowHandle handle)
        {
            return ((tbwCurrencyCode)SalWindow.FromHandle(handle, typeof(tbwCurrencyCode)));
        }
        #endregion

        #region Methods
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public override SalNumber vrtActivate(fcURL URL)
        {
            SalArray<SalString> sItemValues = new SalArray<SalString>();

            #region Actions
            using (new SalContext(this))
            {
                if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.RecCountGet() > 0)
                {
                    Sal.WaitCursor(true);
                    // Bug 104134, Start
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet("COMPANY", sItemValues);
                    i_sCompany = sItemValues[0];
                    if (i_sCompany == SalString.Null)
                    {
                        UserGlobalValueGet("COMPANY", ref i_sCompany); 
                    }
                    else
                    {
                        UserGlobalValueSet("COMPANY", i_sCompany);
                    }
                    // Bug 104134, End
                    if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.TypeGet() == "ZOOM")
                    {
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.i_sItemNames[0] = "CURRENCY_CODE";
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.i_sItemNames[1] = "COMPANY";
                    }
                    if (InitFromTransferredData())
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();
                    Sal.WaitCursor(false);
                    SetWindowTitle();
                    return false;
                }
                SetWindowTitle();
                return base.Activate(URL);
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
        /// <returns></returns>
        public new SalString GetWindowTitle()
        {
            #region Actions
            using (new SalContext(this))
            {
                return Properties.Resources.WH_tbwCurrencyCode;
            }
            #endregion
        }

       
        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalBoolean Include(SalNumber nWhat)
        {
            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        nRow = Sys.TBL_MinRow;
                        // Bug 75446, Begin, checked for the security permission
                        if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("CURRENCY_CODE_API.Can_Make_Emu_Currency")))
                        {
                            return false;
                        }
                        if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("dlgInclude"))))
                        {
                            return false;
                        }
                        // Bug 75446, End
                        if (Sal.TblFindNextRow(i_hWndFrame, ref nRow, Sys.ROW_Selected, 0))
                        {
                            if (Sal.TblFindNextRow(i_hWndFrame, ref nRow, Sys.ROW_Selected, 0))
                            {
                                return false;
                            }
                            if (!(Sal.IsNull(coldEmuCurrencyFromDate)))
                            {
                                return false;
                            }
                            return true;
                        }
                        return false;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        sCurrCode = colCurrencyCode.Text;
                        if (dlgInclude.ModalDialog(i_hWndFrame, sCurrCode, ref dDate) == Sys.IDOK)
                        {
                            using (SignatureHints hints = SignatureHints.NewContext())
                            {
                                hints.Add("CURRENCY_CODE_API.Can_Make_Emu_Currency", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                                DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN\r\n" +
                                    "  :i_hWndFrame.tbwCurrencyCode.bCanProceed :=" + cSessionManager.c_sDbPrefix + " CURRENCY_CODE_API.Can_Make_Emu_Currency ( :i_hWndFrame.tbwCurrencyCode.i_sCompany ,  :i_hWndFrame.tbwCurrencyCode.colCurrencyCode , :i_hWndFrame.tbwCurrencyCode.dDate);\r\nEND;");
                            }
                            if (bCanProceed == "TRUE")
                            {
                                coldEmuCurrencyFromDate.DateTime = dDate;
                                Sal.SetFieldEdit(coldEmuCurrencyFromDate, true);
                                Sal.SendMsg(i_hWndFrame, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                            }
                            else
                            {
                                Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_ERR_CurrDateError, "Unable to set EMU Currency", Ifs.Fnd.ApplicationForms.Const.WARNING_Ok);
                            }
                        }
                        return true;
                }
            }

            return false;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalBoolean Exclude(SalNumber nWhat)
        {
            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        nRow = Sys.TBL_MinRow;
                        if (Sal.TblFindNextRow(i_hWndFrame, ref nRow, Sys.ROW_Selected, 0))
                        {
                            if (Sal.TblFindNextRow(i_hWndFrame, ref nRow, Sys.ROW_Selected, 0))
                            {
                                return false;
                            }
                            if (Sal.IsNull(coldEmuCurrencyFromDate))
                            {
                                return false;
                            }
                            return true;
                        }
                        return false;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        coldEmuCurrencyFromDate.DateTime = Sys.DATETIME_Null;
                        Sal.SetFieldEdit(coldEmuCurrencyFromDate, true);
                        Sal.SendMsg(i_hWndFrame, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                        return true;
                }
            }

            return false;
            #endregion
        }
        #endregion

        #region Window Actions

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tbwCurrencyCode_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove:
                    this.tbwCurrencyCode_OnPM_DataRecordRemove(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataRecordRemove event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwCurrencyCode_OnPM_DataRecordRemove(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                this.sAllDeletingCurrency = Ifs.Fnd.ApplicationForms.Const.strNULL;
                this.nMyRow = Sys.TBL_MinRow;
                while (Sal.TblFindNextRow(this.i_hWndFrame, ref this.nMyRow, Sys.ROW_Selected, 0))
                {
                    Sal.TblSetContext(this.i_hWndFrame, this.nMyRow);
                    if (this.colCurrencyCode.Text != Ifs.Fnd.ApplicationForms.Const.strNULL)
                    {
                        this.sAllDeletingCurrency = this.sAllDeletingCurrency + this.colCurrencyCode.Text + ",";
                    }
                }
                if (this.sAllDeletingCurrency != Ifs.Fnd.ApplicationForms.Const.strNULL)
                {
                    this.sDeleteParam[0] = this.sAllDeletingCurrency;
                    if (Ifs.Fnd.ApplicationForms.Int.AlertBoxWithParams(Properties.Resources.TEXT_DeleteCurrencyMessage, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_OkCancel, this.sDeleteParam) ==
                    Sys.IDOK)
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
        private void colCurrencyCode_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.colCurrencyCode_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colCurrencyCode_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam))
            {
                if (this.colCurrencyCode.Text == "EUR")
                {
                    this.colnInverted.Text = "TRUE";
                }
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
        private void colCurrencyRounding_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.colCurrencyRounding_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colCurrencyRounding_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam)
            {
                if (this.colCurrencyRounding.Number == 3)
                {
                    Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_ChangeCurrencyFormat, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                }
            }
            e.Return = Sys.VALIDATE_Ok;
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

       
        #endregion

        #region Event Handlers

        private void menuItem_Include_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {

            ((FndCommand)sender).Enabled = Include(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem_Include_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            Include(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem_Exclude_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
           
            ((FndCommand)sender).Enabled = Exclude(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem_Exclude_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            Exclude(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

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
