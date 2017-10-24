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
    [FndWindowRegistration("CODE_J,ACCOUNTING_CODEPART_J,CODE_J_ALL", "CodeJ", FndWindowRegistrationFlags.HomePage)]
    public partial class tbwCodeJ : cTableWindowCodePart
    {
        #region Window Variables
        public SalString sParentCodePart = "";
        public SalString sCompany = "";
        public SalString sCodePart = "";
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public tbwCodeJ()
        {
            // to translate sWindowTitle according to the code part value translation
            i_bTranslateForCodePart = true;
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
        public new static tbwCodeJ FromHandle(SalWindowHandle handle)
        {
            return ((tbwCodeJ)SalWindow.FromHandle(handle, typeof(tbwCodeJ)));
        }
        #endregion

        #region Methods
        // Bug 65271,Begin
        /// <summary>
        /// </summary>
        /// <param name="sWindowName"></param>
        /// <returns></returns>
        public new SalNumber DataSourcePrepareKeyTransfer(SalString sWindowName)
        {
            #region Local Variables
            SalArray<SalString> sArray = new SalArray<SalString>();
            SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                if (sWindowName == Pal.GetActiveInstanceName("frmHistoryLog"))
                {
                    sArray[0] = "COMPANY";
                    sArray[1] = "CODE_PART";
                    sArray[2] = "CODE_PART_VALUE";
                    hWndItems[0] = colsCompany;
                    hWndItems[1] = colCodePart;
                    hWndItems[2] = colsCodeJ;
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("CodeJ", this, sArray, hWndItems);
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.TypeSet("CREATE_WINDOW");
                }
                else
                {
                    ((cDataSource)this).DataSourcePrepareKeyTransfer(sWindowName);
                }
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
        private void tbwCodeJ_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_Create:
                    this.tbwCodeJ_OnSAM_Create(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceQueryFieldName:
                    this.tbwCodeJ_OnPM_DataSourceQueryFieldName(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_Create event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwCodeJ_OnSAM_Create(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.i_sCode = "CODE_J";
            e.Return = Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataSourceQueryFieldName event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwCodeJ_OnPM_DataSourceQueryFieldName(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if ((SalString.FromHandle(Sys.lParam) == "CONS_CODE_PART") && (Sys.wParam != Vis.DT_Handle))
            {
                this.sCodePart = "J";
                this.UserGlobalValueGet("COMPANY", ref this.sCompany);
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("ACCOUNTING_CODE_PARTS_API.Get_Parent_Code_Part", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                    SalString lsStmtTemp = cSessionManager.c_lsStmt;
                    this.DbPLSQLBlock(cSessionManager.c_hSql, ":i_hWndFrame.tbwCodeB.sParentCodePart := &AO.ACCOUNTING_CODE_PARTS_API.Get_Parent_Code_Part(:i_hWndFrame.tbwCodeB.sCompany,:i_hWndFrame.tbwCodeB.sCodePart)");
                    cSessionManager.c_lsStmt = lsStmtTemp;
                }
                if (this.sParentCodePart == SalString.Null)
                {
                    this.sParentCodePart = "N";
                }
                e.Return = (this.i_hWndFrame.ToNumber().ToString(0) + "." + Ifs.Fnd.ApplicationForms.Int.QualifiedItemNameGet(this.i_hWndFrame) + ".sParentCodePart").ToHandle();
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
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colsCodeJ_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.colsCodeJ_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colsCodeJ_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam))
            {
                if (Sal.IsNull(this.colsCodeJ.i_hWndSelf))
                {
                    e.Return = Sys.VALIDATE_Ok;
                    return;
                }
                if ((((SalString)this.colsCodeJ.Text).Scan("&") >= 0) || (((SalString)this.colsCodeJ.Text).Scan("'") >= 0) || (((SalString)this.colsCodeJ.Text).Scan("^") >= 0))
                {
                    Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_InvalidCharacter, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
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
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colsCBText_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                // Bug 70804, Begin.

                case Sys.SAM_DoubleClick:
                    e.Handled = true;
                    e.Return = this.FreeText(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
                    return;

                // Bug 70804, End.
            }
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colsConsCodePartValue_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.colsConsCodePartValue_OnSAM_SetFocus(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colsConsCodePartValue_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.colsConsCompany.Text == Ifs.Fnd.ApplicationForms.Const.strNULL)
            {
                this.colsConsCodePartValue.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                // Used this method as using Sal.SendMsg,Sal.PostMsg to send Tab key is not working properly in aurora client
                System.Windows.Forms.SendKeys.Send("{TAB}");
                Sal.MessageBeep(0);
            }
            e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }
        #endregion

        #region Late Bind Methods

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalNumber vrtDataSourcePrepareKeyTransfer(SalString sWindowName)
        {
            return this.DataSourcePrepareKeyTransfer(sWindowName);
        }

        #endregion

        #region Event Handlers

        private void menuItem_Code_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = CodestrCompl(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem_Code_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            CodestrCompl(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem__Translation_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = Translation(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem__Translation_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            Translation(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem__Code_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = ConnectAttribute(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem__Code_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            ConnectAttribute(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem__Notes_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = FreeText(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem__Notes_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            FreeText(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem_Change_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = !(bZoom) && !(Sal.SendMsg(i_hWndFrame, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0));
        }

        private void menuItem_Change_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            ChangeCompany(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        #endregion

    }
}
