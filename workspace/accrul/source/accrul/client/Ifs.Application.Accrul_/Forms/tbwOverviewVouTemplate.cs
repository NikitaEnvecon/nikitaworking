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
    [FndWindowRegistration("VOUCHER_TEMPLATE", "VoucherTemplate")]
    public partial class tbwOverviewVouTemplate : cTableWindowFin
    {

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public tbwOverviewVouTemplate()
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
        public new static tbwOverviewVouTemplate FromHandle(SalWindowHandle handle)
        {
            return ((tbwOverviewVouTemplate)SalWindow.FromHandle(handle, typeof(tbwOverviewVouTemplate)));
        }
        #endregion

        #region Methods
        #endregion

        #region Late Bind Methods
        #endregion

        #region Event Handlers

        private void menuItem__Voucher_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            if (!(Sal.SendMsg(i_hWndFrame, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0)))
            {
                if (Sal.TblAnyRows(i_hWndFrame, Sys.ROW_Selected, 0))
                {
                    ((FndCommand)sender).Enabled = true;
                }
                else
                {
                    ((FndCommand)sender).Enabled = false;
                }
            }
            else
            {
                ((FndCommand)sender).Enabled = false;
            }
        }

        private void menuItem__Voucher_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            Ifs.Fnd.ApplicationForms.Int.PostMessage(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceCreateWindow, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Pal.GetActiveInstanceName("frmVouTemplate"));
        }

        private void menuItem_Change_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Sys.lParam);
        }

        private void menuItem_Change_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Sys.lParam);
        }

        private void menuItem__Voucher_1_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            if (!(Sal.SendMsg(i_hWndFrame, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0)))
            {
                if (Sal.TblAnyRows(i_hWndFrame, Sys.ROW_Selected, 0))
                {
                    ((FndCommand)sender).Enabled = true;
                }
                else
                {
                    ((FndCommand)sender).Enabled = false;
                }
            }
            else
            {
                ((FndCommand)sender).Enabled = false;
            }
        }

        private void menuItem__Voucher_1_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            Ifs.Fnd.ApplicationForms.Int.PostMessage(i_hWndFrame, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceCreateWindow, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Pal.GetActiveInstanceName("frmVouTemplate"));
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
