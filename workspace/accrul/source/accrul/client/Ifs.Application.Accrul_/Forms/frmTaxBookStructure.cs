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
	/// This is the main form in Tax Book Structures
	/// </summary>
    [FndWindowRegistration("TAX_BOOK_STRUCTURE", "TaxBookStructure")]
    public partial class frmTaxBookStructure : cMasterDetailTabFormWindowFin
    {
        #region Window Variables
        public SalArray<SalString> sPlaceHolders = new SalArray<SalString>();
        public SalString sNewStructureId = "";
        public SalString sNewDescription = "";
        public SalDateTime dtValidFrom = SalDateTime.Null;
        public SalDateTime dtValidUntil = SalDateTime.Null;
        public SalDateTime dtMaxDate = SalDateTime.Null;
        public SalDateTime dtSysdate = SalDateTime.Null;
        public SalWindowHandle hWndNodesTab = SalWindowHandle.Null;
        public SalWindowHandle hWndTaxBookTab = SalWindowHandle.Null;
        public SalWindowHandle hWndLevelsTab = SalWindowHandle.Null;
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public frmTaxBookStructure()
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
        public new static frmTaxBookStructure FromHandle(SalWindowHandle handle)
        {
            return ((frmTaxBookStructure)SalWindow.FromHandle(handle, typeof(frmTaxBookStructure)));
        }
        #endregion

        #region Methods
        // Insert new code here...

        

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber DataRecordGetDefault()
        {
            #region Actions
            using (new SalContext(this))
            {
                dfsCompany.Text = i_sCompany;
                dfsCompany.EditDataItemSetEdited();
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="wParam"></param>
        /// <returns></returns>
        public virtual SalNumber DataSave(SalNumber wParam)
        {
            #region Actions
            using (new SalContext(this))
            {
                switch (wParam)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        Sal.SendMsgToChildren(i_hWndFrame, Ifs.Fnd.ApplicationForms.Const.PM_User, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, ((SalString)"SAVED").ToHandle());
                        break;
                        break;
                }
                return 1;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public new SalBoolean SetWindowTitle()
        {
            #region Local Variables
            SalString sCompany = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                UserGlobalValueGet("COMPANY", ref sCompany);
                Sal.SetWindowText(this, sCompany + " - " + Properties.Resources.WH_frmTaxBookStructure);
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
        private void frmTaxBookStructure_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave:
                    this.frmTaxBookStructure_OnPM_DataSourceSave(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew:
                    this.frmTaxBookStructure_OnPM_DataRecordNew(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove:
                    this.frmTaxBookStructure_OnPM_DataRecordRemove(sender, e);
                    break;

                case Const.PAM_RefreshTabs1:
                    this.frmTaxBookStructure_OnPAM_RefreshTabs1(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceQueryFieldName:
                    this.frmTaxBookStructure_OnPM_DataSourceQueryFieldName(sender, e);
                    break;

                case Sys.SAM_Create:
                    this.frmTaxBookStructure_OnSAM_Create(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataSourceSave event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmTaxBookStructure_OnPM_DataSourceSave(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                Sal.SendMsgToChildren(this.i_hWndFrame, Ifs.Fnd.ApplicationForms.Const.PM_User, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, ((SalString)"SAVE").ToHandle());
            }
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Sys.wParam, Sys.lParam))
            {
                e.Return = this.DataSave(Sys.wParam);
                return;
            }
            e.Return = false;
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataRecordNew event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmTaxBookStructure_OnPM_DataRecordNew(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew, Sys.wParam, Sys.lParam))
            {
                if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
                {
                    this.picTab.BringToTop(0, true);
                }
                e.Return = true;
                return;
            }
            e.Return = false;
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataRecordRemove event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmTaxBookStructure_OnPM_DataRecordRemove(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove, Sys.wParam, Sys.lParam);
                return;
            }
            else
            {
                e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove, Sys.wParam, Sys.lParam);
                return;
            }
            #endregion
        }

        /// <summary>
        /// PAM_RefreshTabs1 event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmTaxBookStructure_OnPAM_RefreshTabs1(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.hWndNodesTab = this.TabAttachedWindowHandleGet(this.picTab.FindName("Nodes"));
            this.hWndTaxBookTab = this.TabAttachedWindowHandleGet(this.picTab.FindName("TaxBooks"));
            if (this.hWndNodesTab != SalWindowHandle.Null)
            {
                Sal.SendMsg(this.hWndNodesTab, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceRefresh, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
            }
            if (this.hWndTaxBookTab != SalWindowHandle.Null)
            {
                Sal.SendMsg(this.hWndTaxBookTab, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceRefresh, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
            }
            e.Return = true;
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataSourceQueryFieldName event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmTaxBookStructure_OnPM_DataSourceQueryFieldName(object sender, WindowActionsEventArgs e)
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
                        e.Return = (this.i_hWndFrame.ToNumber().ToString(0) + ".frmTaxBookStructure.i_sCompany").ToHandle();
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
        /// SAM_Create event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmTaxBookStructure_OnSAM_Create(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam);
            this.SetWindowTitle();
            #endregion
        }
        #endregion

        #region Late Bind Methods
        // Insert new code here...

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalBoolean vrtSetWindowTitle()
        {
            return this.SetWindowTitle();
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

        #endregion

    }
}
