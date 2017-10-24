#region Copyright (c) IFS Research & Development
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
#endregion
#region History
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Ifs.Fnd.ApplicationForms;
using PPJ.Runtime;
using PPJ.Runtime.Windows;

namespace Ifs.Application.Accrul
{

    /// <summary>
    /// </summary>
    public partial class frmDocumentFooter : cMasterDetailTabFormWindow
    {
        #region Member Variables
        SalString sDefineFooterActive = "";
        public bool bFooterFieldModify = false;
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public frmDocumentFooter()
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
        [DebuggerStepThrough]
        public new static frmDocumentFooter FromHandle(SalWindowHandle handle)
        {
            return ((frmDocumentFooter)SalWindow.FromHandle(handle, typeof(frmDocumentFooter)));
        }
        #endregion

        #region Properties

        #endregion

        #region Methods

        public SalNumber TabActivateStart(SalWindowHandle hWnd, SalNumber nTab)
        {
            #region Actions
            using (new SalContext(this))
            {
                if (nTab == 1)
                {
                    sDefineFooterActive = "TRUE";
                }
            }

            return 1;
            #endregion
        }

        public SalNumber DataSourceSave(SalNumber nWhat)
        {
            #region Actions
            SalWindowHandle hWndFooterDef = SalWindowHandle.Null;
            if (base.DataSourceSave(nWhat))
            {
                if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
                {
                    if (bFooterFieldModify && sDefineFooterActive == "TRUE")
                    {
                        hWndFooterDef = TabAttachedWindowHandleGet(picTab.FindName("DefineFooter"));
                        Sal.SendMsg(hWndFooterDef, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceRefresh, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                    }
                }
                return true;
            }

            return false;
            #endregion
        }

        #endregion

        #region Overrides

        public override SalBoolean vrtTabActivateStart(SalWindowHandle hWnd, SalNumber nTab)
        {
            return this.TabActivateStart(hWnd, nTab);
        }

        public override SalNumber vrtDataSourceSave(SalNumber nWhat)
        {
            return this.DataSourceSave(nWhat);
        }

        #endregion



        #region Message Actions
        private void frmDocumentFooter_WindowActions(object sender, WindowActionsEventArgs e)
        {
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew:
                    this.frmDocumentFooter_OnPM_DataRecordNew(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_User:
                    this.frmDocumentFooter_OnPM_User(sender, e);
                    break;
            }


        }

        private void frmDocumentFooter_OnPM_DataRecordNew(object sender, WindowActionsEventArgs e)
        {
            #region Action
            e.Handled = true;
            e.Return = false;
            return;
            #endregion
        }

        /// <summary>
        /// PM_User event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmDocumentFooter_OnPM_User(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                if (SalString.FromHandle(Sys.lParam) == "GetCompany")
                {                    
                    e.Return = ((SalString)this.cmbsCompany.Text).ToHandle();
                }
            }
            #endregion
        }
        #endregion

        #region Event Handlers

        #endregion

        #region Menu Event Handlers

        #endregion
    }
}
