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
    [FndWindowRegistration("ACCOUNTING_CODESTR_COMB_UIV", "AccountingCodeStringComb", FndWindowRegistrationFlags.HomePage)]
    public partial class tbwCombControl : cTableWindowFin
    {
        #region Window Variables
        public SalString sCompanyName = "";
        public SalArray<SalString> sPlaceHolders = new SalArray<SalString>();
        public SalArray<SalString> sChanges = new SalArray<SalString>();
        public SalString sID = "";
        public SalNumber nNumChanges = 0;
        public SalNumber nRetVal = 0;
        public SalString sUsedB = "";
        public SalString sUsedC = "";
        public SalString sUsedD = "";
        public SalString sUsedE = "";
        public SalString sUsedF = "";
        public SalString sUsedG = "";
        public SalString sUsedH = "";
        public SalString sUsedI = "";
        public SalString sUsedJ = "";
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public tbwCombControl()
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
        public new static tbwCombControl FromHandle(SalWindowHandle handle)
        {
            return ((tbwCombControl)SalWindow.FromHandle(handle, typeof(tbwCombControl)));
        }
        #endregion

        #region Methods
        // Insert new code here...

        /// <summary>
        /// Gets client default values for NEW records
        /// </summary>
        /// <returns></returns>
        public new SalBoolean DataRecordGetDefaults()
        {
            #region Actions
            using (new SalContext(this))
            {
                colsCompany.Text = i_sCompany;
                colsCompany.EditDataItemSetEdited();

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
                return Properties.Resources.WM_tbwCombControl;
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
        private void tbwCombControl_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_Create:
                    this.tbwCombControl_OnSAM_Create(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceQueryFieldName:
                    this.tbwCombControl_OnPM_DataSourceQueryFieldName(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_Create event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwCombControl_OnSAM_Create(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SetWindowText(this, Properties.Resources.WM_tbwCombControl);
            e.Return = Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataSourceQueryFieldName event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwCombControl_OnPM_DataSourceQueryFieldName(object sender, WindowActionsEventArgs e)
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
                        e.Return = (this.i_hWndFrame.ToNumber().ToString(0) + ".tbwCombControl.i_sCompany").ToHandle();
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
        private void colAllowed_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_LookupInit:
                    this.colAllowed_OnPM_LookupInit(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_LookupInit event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colAllowed_OnPM_LookupInit(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.colAllowed.EditDataItemFlagSet(Ifs.Fnd.ApplicationForms.Const.FIELD_Required, true);
            Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_LookupInit, Sys.wParam, Sys.lParam);
            this.colAllowed.EditDataItemFlagSet(Ifs.Fnd.ApplicationForms.Const.FIELD_Required, false);
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colCodea_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.colCodea_OnSAM_SetFocus(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colCodea_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendMsg(this.colCodea.i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_EditStateFieldEnabled, 0, 0))
            {
                this.coldummyCdPart.Text = "A";
            }
            else
            {
                this.coldummyCdPart.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
            }
            e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colCodeb_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.colCodeb_OnSAM_SetFocus(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colCodeb_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendMsg(this.colCodeb.i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_EditStateFieldEnabled, 0, 0))
            {
                this.coldummyCdPart.Text = "B";
            }
            else
            {
                this.coldummyCdPart.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
            }
            e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colCodec_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.colCodec_OnSAM_SetFocus(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colCodec_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendMsg(this.colCodec.i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_EditStateFieldEnabled, 0, 0))
            {
                this.coldummyCdPart.Text = "C";
            }
            else
            {
                this.coldummyCdPart.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
            }
            e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colCoded_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.colCoded_OnSAM_SetFocus(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colCoded_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendMsg(this.colCoded.i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_EditStateFieldEnabled, 0, 0))
            {
                this.coldummyCdPart.Text = "D";
            }
            else
            {
                this.coldummyCdPart.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
            }
            e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colCodee_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.colCodee_OnSAM_SetFocus(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colCodee_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendMsg(this.colCodee.i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_EditStateFieldEnabled, 0, 0))
            {
                this.coldummyCdPart.Text = "E";
            }
            else
            {
                this.coldummyCdPart.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
            }
            e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colCodef_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.colCodef_OnSAM_SetFocus(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colCodef_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendMsg(this.colCodef.i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_EditStateFieldEnabled, 0, 0))
            {
                this.coldummyCdPart.Text = "F";
            }
            else
            {
                this.coldummyCdPart.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
            }
            e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colCodeg_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.colCodeg_OnSAM_SetFocus(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colCodeg_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendMsg(this.colCodeg.i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_EditStateFieldEnabled, 0, 0))
            {
                this.coldummyCdPart.Text = "G";
            }
            else
            {
                this.coldummyCdPart.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
            }
            e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colCodeh_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.colCodeh_OnSAM_SetFocus(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colCodeh_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendMsg(this.colCodeh.i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_EditStateFieldEnabled, 0, 0))
            {
                this.coldummyCdPart.Text = "H";
            }
            else
            {
                this.coldummyCdPart.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
            }
            e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colCodei_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.colCodei_OnSAM_SetFocus(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colCodei_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendMsg(this.colCodei.i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_EditStateFieldEnabled, 0, 0))
            {
                this.coldummyCdPart.Text = "I";
            }
            else
            {
                this.coldummyCdPart.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
            }
            e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colCodej_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.colCodej_OnSAM_SetFocus(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colCodej_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendMsg(this.colCodej.i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_EditStateFieldEnabled, 0, 0))
            {
                this.coldummyCdPart.Text = "J";
            }
            else
            {
                this.coldummyCdPart.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
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

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        
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
