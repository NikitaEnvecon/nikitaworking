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
using Ifs.Application.Appsrv;
using Ifs.Application.Enterp;
using Ifs.Fnd.ApplicationForms;
using PPJ.Runtime;
using PPJ.Runtime.Sql;
using PPJ.Runtime.Vis;
using PPJ.Runtime.Windows;
using PPJ.Runtime.Windows.QO;
using Ifs.Fnd.Windows.Forms;

namespace Ifs.Application.Accrul
{
	
	/// <summary>
	/// Overview Attribute Connections
	/// </summary>
    [FndWindowRegistration("ACCOUNTING_ATTRIBUTE_CON", "AccountingAttributeCon", FndWindowRegistrationFlags.HomePage)]
    public partial class tbwAttributeCon : cTableWindowFin
    {
        #region Window Variables
        public SalNumber nIndexCompany = 0;
        public SalNumber nRetVal = 0;
        public SalString sValue = "";
        public SalWindowHandle hWndSource = SalWindowHandle.Null;
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public tbwAttributeCon()
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
        public new static tbwAttributeCon FromHandle(SalWindowHandle handle)
        {
            return ((tbwAttributeCon)SalWindow.FromHandle(handle, typeof(tbwAttributeCon)));
        }
        #endregion

        #region Methods

        /// <summary>
        /// </summary>
        /// <returns>
        /// Applications should return FALSE to skip standard window startup logic (such
        /// as exectuing the "startup behavior" settings), or TRUE to allow standard logic.
        /// </returns>
        public new SalBoolean FrameStartupUser()
        {
            #region Actions
            using (new SalContext(this))
            {
                // Insert new code here...
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
                return Properties.Resources.WH_AttributeConOvw;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean SetWindowText()
        {
            #region Actions
            using (new SalContext(this))
            {
                Sal.SetWindowText(i_hWndSelf, i_sCompany + " - " + Properties.Resources.WH_AttributeConOvw);
                return true;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean GetCodePart()
        {
            #region Actions
            using (new SalContext(this))
            {
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("Accounting_Attribute_API.Get_Code_Part", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                    if (!(DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN\r\n" +
                        "			:i_hWndFrame.tbwAttributeCon.colsCodePart :=\r\n" +
                        "			&AO.Accounting_Attribute_API.Get_Code_Part(:i_hWndFrame.tbwAttributeCon.colsCompany, :i_hWndFrame.tbwAttributeCon.colsAttribute);\r\n			END;")))
                    {
                        return false;
                    }
                }
                colsCodePart.EditDataItemSetEdited();
                return true;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean CheckAttrValue()
        {
            #region Actions
            using (new SalContext(this))
            {
                Sal.WaitCursor(true);
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("ACCOUNTING_ATTRIBUTE_VALUE_API.Exist", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                    if (!(DbPLSQLBlock(cSessionManager.c_hSql, "&AO.ACCOUNTING_ATTRIBUTE_VALUE_API.Exist(\r\n" +
                        "			:i_hWndFrame.tbwAttributeCon.colsCompany, :i_hWndFrame.tbwAttributeCon.colsAttribute, :i_hWndFrame.tbwAttributeCon.colsAttributeValue)")))
                    {
                        Sal.WaitCursor(false);
                        return false;
                    }
                }
                Sal.WaitCursor(false);
                return true;
            }
            #endregion
        }

        /// <summary>
        /// Applications override the FrameShutdownUser to perform shutdown
        /// logic for a window.
        /// COMMENTS:
        /// The framework calls FrameShutdownUser with METHOD_Inquire when the
        /// user selects to close the window (while the SAM_Close message is
        /// being processed), and with METHOD_Execute just before the window
        /// is destroyed.
        /// </summary>
        /// <param name="nWhat">
        /// Standard method parameter
        /// Standard method parameter. Possible values are METHOD_Inquire, METHOD_Execute.
        /// </param>
        /// <returns>
        /// When nWhat = METHOD_Inquire: applications should return TRUE if the window
        /// can be shut down, FALSE otherwise. Returning FALSE will prevent the window
        /// from being closed.
        /// When nWhat = METHOD_Execute: applications should return TRUE if the shutdown
        /// actions were performed successfully, FALSE otherwise. Returning FALSE will prevent
        /// the window from being closed.
        /// </returns>
        public new SalBoolean FrameShutdownUser(SalNumber nWhat)
        {
            #region Actions
            using (new SalContext(this))
            {
                if (Ifs.Fnd.ApplicationForms.Int.QualifiedItemNameGet(hWndSource) == Pal.GetActiveInstanceName("frmTabProjAcc"))
                {
                    Sal.SendMsg(hWndSource, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceRefresh, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
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
        private void tbwAttributeCon_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceQueryFieldName:
                    this.tbwAttributeCon_OnPM_DataSourceQueryFieldName(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataSourceQueryFieldName event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwAttributeCon_OnPM_DataSourceQueryFieldName(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (SalString.FromHandle(Sys.lParam) == "COMPANY")
            {
                switch (Sys.wParam)
                {
                    case Vis.DT_Handle:
                        e.Return = SalWindowHandle.Null.ToNumber();
                        return;

                    default:
                        e.Return = (this.i_hWndFrame.ToNumber().ToString(0) + ".tbwAttributeCon.i_sCompany").ToHandle();
                        return;
                }
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
        private void colsAttribute_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_Validate:
                    this.colsAttribute_OnSAM_Validate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_Validate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colsAttribute_OnSAM_Validate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Sys.SAM_Validate, Sys.wParam, Sys.lParam))
            {
                e.Return = this.GetCodePart();
                return;
            }
            e.Return = Sys.VALIDATE_Cancel;
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colsCodePartValue_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_Validate:
                    this.colsCodePartValue_OnSAM_Validate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_Validate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colsCodePartValue_OnSAM_Validate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Sys.SAM_Validate, Sys.wParam, Sys.lParam))
            {
                // Start Bug# 24693
                if (this.colsCodePartValueDescription.Text == Ifs.Fnd.ApplicationForms.Const.strNULL)
                {
                    using (SignatureHints hints = SignatureHints.NewContext())
                    {
                        hints.Add("Accounting_Code_Part_Value_API.Get_Description", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                        this.colsCodePartValue.DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN\r\n" +
                            "		:i_hWndParent.tbwAttributeCon.colsCodePartValueDescription :=\r\n" +
                            "		&AO.Accounting_Code_Part_Value_API.Get_Description(:i_hWndParent.tbwAttributeCon.colsCompany, :i_hWndParent.tbwAttributeCon.colsCodePart,\r\n" +
                            "											:i_hWndParent.tbwAttributeCon.colsCodePartValue);\r\n		END;");
                    }
                }
                // End Bug# 24693
                if (this.colsCodePartValueDescription.Text == Ifs.Fnd.ApplicationForms.Const.strNULL && this.colsCodePartValue.Text != Ifs.Fnd.ApplicationForms.Const.strNULL)
                {
                    if (Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_CodePartValueNotExist, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Sys.MB_IconExclamation))
                    {
                        e.Return = false;
                        return;
                    }
                }
                e.Return = true;
                return;
            }
            e.Return = Sys.VALIDATE_Cancel;
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colsAttributeValue_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.colsAttributeValue_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colsAttributeValue_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam))
            {
                if (this.colsAttributeValue.Text != Ifs.Fnd.ApplicationForms.Const.strNULL)
                {
                    e.Return = this.CheckAttrValue();
                    return;
                }
                e.Return = true;
                return;
            }
            e.Return = Sys.VALIDATE_Cancel;
            return;
            #endregion
        }
        #endregion

        #region Late Bind Methods

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalBoolean vrtFrameShutdownUser(SalNumber nWhat)
        {
            return this.FrameShutdownUser(nWhat);
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
        /// </summary>
        /// <returns></returns>
        public override SalNumber vrtActivate(fcURL URL)
        {
            #region Actions
            using (new SalContext(this))
            {
                hWndSource = Ifs.Fnd.ApplicationForms.Var.DataTransfer.i_hWndSource;
                SetWindowTitle();
                if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.RecCountGet() > 0)
                {
                    Sal.WaitCursor(true);
                    nIndexCompany = Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemIndexGet("COMPANY");
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemValueStrGet(nIndexCompany, 0, ref i_sCompany);
                    UserGlobalValueSet("COMPANY", i_sCompany);
                    SetWindowText();
                    InitFromTransferedData();
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();
                    Sal.WaitCursor(false);
                }
                return base.Activate(URL);
            }
            #endregion
        }
        #endregion

        #region Event Handlers

        private void menuItem__Attribute_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = Sal.TblAnyRows(Sys.hWndForm, Sys.ROW_Selected, 0) && Ifs.Fnd.ApplicationForms.Var.Security.IsViewAvailable("ACCOUNTING_ATTRIBUTE");
        }

        private void menuItem__Attribute_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            SalArray<SalString> sItemNames = new SalArray<SalString>();
            SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();

            Sal.WaitCursor(true);
            sItemNames[0] = "ATTRIBUTE";
            hWndItems[0] = colsAttribute;
            Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("ATTRIBUTE", this, sItemNames, hWndItems);
            SessionCreateWindow(Pal.GetActiveInstanceName("frmAttValue"), Sys.hWndMDI);
            Sal.WaitCursor(false);
        }

        private void menuItem__Change_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = !(Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0));
        }

        private void menuItem__Change_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            Var.FinlibServices.DoChangeCompany(this);
        }

        private void menuItem__Attribute_1_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = Sal.TblAnyRows(Sys.hWndForm, Sys.ROW_Selected, 0) && Ifs.Fnd.ApplicationForms.Var.Security.IsViewAvailable("ACCOUNTING_ATTRIBUTE");
        }

        private void menuItem__Attribute_1_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            SalArray<SalString> sItemNames = new SalArray<SalString>();
            SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();

            Sal.WaitCursor(true);
            sItemNames[0] = "ATTRIBUTE";
            hWndItems[0] = colsAttribute;
            Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("ATTRIBUTE", this, sItemNames, hWndItems);
            SessionCreateWindow(Pal.GetActiveInstanceName("frmAttValue"), Sys.hWndMDI);
            Sal.WaitCursor(false);
        }

        private void menuItem__Change_1_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = !(Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0));
        }

        private void menuItem__Change_1_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            Var.FinlibServices.DoChangeCompany(this);
        }

        #endregion

    }
}
