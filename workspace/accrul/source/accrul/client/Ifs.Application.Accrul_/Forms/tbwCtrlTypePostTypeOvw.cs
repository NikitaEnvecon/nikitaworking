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
    [FndWindowRegistration("POSTING_CTRL_ALWD_COMBINATION", "PostingCtrlAllowedComb")]
    public partial class tbwCtrlTypePostTypeOvw : cTableWindowFin
    {

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public tbwCtrlTypePostTypeOvw()
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
        public new static tbwCtrlTypePostTypeOvw FromHandle(SalWindowHandle handle)
        {
            return ((tbwCtrlTypePostTypeOvw)SalWindow.FromHandle(handle, typeof(tbwCtrlTypePostTypeOvw)));
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
                return Properties.Resources.WH_tbwCtrlTypePostType;
            }
            #endregion
        }

        

        /// <summary>
        /// Applications and the framework call the DataSourcePrepareKeyTransfer
        /// function to initialize data transfer with all keys of the data source.
        /// COMMENTS:
        /// DataSourcePrepareKeyTransfer is typically called before a window is
        /// created.
        /// </summary>
        /// <param name="sWindowName">
        /// Window name
        /// Intendend receiver window of the data transfer. When overriding DataSourcePrepareKeyTransfer,
        /// applications can use this parameter to initialize data transfer in different ways for
        /// different receiver windows.
        /// </param>
        /// <returns></returns>
        public new SalNumber DataSourcePrepareKeyTransfer(SalString sWindowName)
        {
            #region Local Variables
            SalArray<SalString> sItemNames = new SalArray<SalString>();
            SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                if (sWindowName == Pal.GetActiveInstanceName("tbwCombControlType"))
                {
                    sItemNames[0] = "COMPANY";
                    hWndItems[0] = colsCompany;
                    sItemNames[1] = "POSTING_TYPE";
                    hWndItems[1] = colsPostingType;
                    sItemNames[1] = "COMB_CONTROL_TYPE";
                    hWndItems[1] = colsControlType;
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("CombControlType", i_hWndSelf, sItemNames, hWndItems);
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
        private void colsPostingType_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovUserOrderBy:
                    e.Handled = true;
                    e.Return = ((SalString)"MODULE,SORT_ORDER").ToHandle();
                    return;
            }
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colsControlType_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom:
                    this.colsControlType_OnPM_DataItemZoom(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemZoom event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colsControlType_OnPM_DataItemZoom(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.colsControlTypeCategoryDb.Text != "COMBINATION")
            {
                e.Return = false;
                return;
            }
            e.Return = tbwCtrlTypePostTypeOvw.FromHandle(this.colsControlType.i_hWndFrame).DataSourceCreateWindow(Sys.wParam, Pal.GetActiveInstanceName("tbwCombControlType"));
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

        #endregion

    }
}
