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
    [FndWindowRegistration("EXT_FILE_LOAD", "ExtFileLoad", FndWindowRegistrationFlags.HomePage)]
    public partial class tbwExternalFileTransactions : cTableWindowFinBase
    {

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public tbwExternalFileTransactions()
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
        public new static tbwExternalFileTransactions FromHandle(SalWindowHandle handle)
        {
            return ((tbwExternalFileTransactions)SalWindow.FromHandle(handle, typeof(tbwExternalFileTransactions)));
        }
        #endregion

        #region Methods

        /// <summary>
        /// </summary>
        /// <param name="p_nWhat"></param>
        /// <returns></returns>
        public virtual SalBoolean Details(SalNumber p_nWhat)
        {
            #region Local Variables
            SalArray<SalString> sItemNames = new SalArray<SalString>();
            SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                switch (p_nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        return Sal.TblAnyRows(i_hWndSelf, Sys.ROW_Selected, 0);

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        Sal.WaitCursor(true);
                        sItemNames[0] = "LOAD_FILE_ID";
                        hWndItems[0] = colnLoadFileId;
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("LOAD_ID", i_hWndSelf, sItemNames, hWndItems);
                        SessionCreateWindow(Pal.GetActiveInstanceName("frmExternalFileTransactions"), Sys.hWndMDI);
                        Sal.WaitCursor(false);
                        return true;
                }
            }

            return false;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="nWhatInv"></param>
        /// <returns></returns>
        public virtual SalNumber ExtLog(SalNumber nWhatInv)
        {
            #region Local Variables
            SalArray<SalString> sItemNames = new SalArray<SalString>();
            SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                switch (nWhatInv)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        return Ifs.Fnd.ApplicationForms.Var.Security.IsViewAvailable("EXT_FILE_LOG");

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        Sal.WaitCursor(true);
                        sItemNames[0] = "LOAD_FILE_ID";
                        hWndItems[0] = colnLoadFileId;
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("ExtFileLog", i_hWndSelf, sItemNames, hWndItems);
                        SessionCreateWindow(Pal.GetActiveInstanceName("frmExternalFileLog"), Sys.hWndMDI);
                        return true;
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
        private void tbwExternalFileTransactions_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove:
                    this.tbwExternalFileTransactions_OnPM_DataRecordRemove(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataRecordRemove event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwExternalFileTransactions_OnPM_DataRecordRemove(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove, Sys.wParam, Sys.lParam))
            {
                if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
                {
                    e.Return = false;
                    return;
                }
                e.Return = true;
                return;
            }
            e.Return = false;
            return;
            #endregion
        }
        #endregion

        #region Late Bind Methods
        #endregion

        #region Event Handlers

        private void menuItem__Details_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = Details(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem__Details_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            Details(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem__External_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = ExtLog(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem__External_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            ExtLog(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        #endregion

    }
}
