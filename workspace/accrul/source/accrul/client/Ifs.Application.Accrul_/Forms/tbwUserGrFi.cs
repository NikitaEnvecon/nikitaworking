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
    [FndWindowRegistration("USER_GROUP_FINANCE", "UserGroupFinance", FndWindowRegistrationFlags.HomePage)]
    [FndWindowRegistration("USER_GROUP_MEMBER_FINANCE2", "UserGroupFinance")]
    public partial class tbwUserGrFi : cTableWindowFin
    {
        #region Window Variables
        public SalArray<SalString> sPlaceHolders = new SalArray<SalString>();
        public SalString sCompanyName = "";
        public SalArray<SalString> sChanges = new SalArray<SalString>();
        public SalString sID = "";
        public SalNumber nNumChanges = 0;
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public tbwUserGrFi()
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
        public new static tbwUserGrFi FromHandle(SalWindowHandle handle)
        {
            return ((tbwUserGrFi)SalWindow.FromHandle(handle, typeof(tbwUserGrFi)));
        }
        #endregion

        #region Methods
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public override SalNumber vrtActivate(fcURL URL)
        {
            #region Local Variables
            SalNumber nItemIndexValue = 0;
            SalNumber nRC = 0;
            SalString sUserWhere = "";
            SalString sTmp = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.RecCountGet() > 0)
                {
                    Sal.WaitCursor(true);
                    nItemIndexValue = Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemIndexGet("USERID");
                    if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.TypeGet() == "ZOOM" && nItemIndexValue >= 0)
                    {
                        nItemIndexValue = Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemIndexGet("USER_GROUP");
                        nRC = Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemValueStrGet(nItemIndexValue, 0, ref sTmp);
                        sUserWhere = "USER_GROUP ='" + sTmp + "'";
                        Sal.SendMsg(i_hWndFrame, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceUserWhere, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, sUserWhere.ToHandle());
                        Sal.SendMsg(i_hWndFrame, Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Sys.lParam);
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();
                        Sal.WaitCursor(false);
                        return false;
                    }
                    else
                    {
                        if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.RecCountGet() > 0)
                        {
                            if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.TypeGet() == "ZOOM")
                            {
                                Ifs.Fnd.ApplicationForms.Var.DataTransfer.i_sItemNames[0] = "USER_GROUP";
                                Ifs.Fnd.ApplicationForms.Var.DataTransfer.i_sItemNames[1] = "COMPANY";
                            }
                        }
                        if (InitFromTransferredData())
                            Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();
                        Sal.WaitCursor(false);
                        return false;
                    }
                }
                Sal.WaitCursor(false);
                return base.Activate(URL);
            }
            #endregion

        }

        /// <summary>
        /// Gets client default values for NEW records
        /// </summary>
        /// <returns></returns>
        public new SalBoolean DataRecordGetDefaults()
        {
            #region Actions
            using (new SalContext(this))
            {
                tbwUserGrFi.FromHandle(i_hWndFrame).colCompany.Text = i_sCompany;
                tbwUserGrFi.FromHandle(i_hWndFrame).colCompany.EditDataItemSetEdited();
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
                return Properties.Resources.WH_tbwUserGrFi;
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
        private void tbwUserGrFi_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceQueryFieldName:
                    this.tbwUserGrFi_OnPM_DataSourceQueryFieldName(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataSourceQueryFieldName event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwUserGrFi_OnPM_DataSourceQueryFieldName(object sender, WindowActionsEventArgs e)
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
                        e.Return = (this.i_hWndFrame.ToNumber().ToString(0) + ".tbwUserGrFi.i_sCompany").ToHandle();
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
        public override SalString vrtGetWindowTitle()
        {
            return this.GetWindowTitle();
        }
        #endregion

        #region Event Handlers

        private void menuItem_Users_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = Sal.TblAnyRows(Sys.hWndForm, Sys.ROW_Selected, 0);
        }

        private void menuItem_Users_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            SalArray<SalString> sItemNames = new SalArray<SalString>();
            SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();

            Sal.WaitCursor(true);
            sItemNames[0] = "USER_GROUP";
            hWndItems[0] = colUserGroup;
            Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("USER_PER_USER_GROUP", this, sItemNames, hWndItems);
            SessionCreateWindow(Pal.GetActiveInstanceName("frmUserGrMem"), Sys.hWndMDI);
            Sal.WaitCursor(false);
        }

        private void menuItem_Change_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Sys.lParam);
        }

        private void menuItem_Change_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Sys.lParam);
        }

        private void menuItem_Users_1_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = Sal.TblAnyRows(Sys.hWndForm, Sys.ROW_Selected, 0);
        }

        private void menuItem_Users_1_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            SalArray<SalString> sItemNames = new SalArray<SalString>();
            SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();

            Sal.WaitCursor(true);
            sItemNames[0] = "USER_GROUP";
            hWndItems[0] = colUserGroup;
            Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("USER_PER_USER_GROUP", this, sItemNames, hWndItems);
            SessionCreateWindow(Pal.GetActiveInstanceName("frmUserGrMem"), Sys.hWndMDI);
            Sal.WaitCursor(false);
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
