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

using Ifs.Fnd.Windows.Forms;

namespace Ifs.Application.Accrul_
{

    /// <summary>
    /// </summary>
    [FndWindowRegistration("RPD_COMPANY", "RpdCompany", FndWindowRegistrationFlags.HomePage)]
    public partial class frmRpdCompany : cFormWindow
    {
        #region Member Variables

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public frmRpdCompany()
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
        public new static frmRpdCompany FromHandle(SalWindowHandle handle)
        {
            return ((frmRpdCompany)SalWindow.FromHandle(handle, typeof(frmRpdCompany)));
        }
        #endregion

        #region Properties

        #endregion

        #region Methods
        protected virtual SalBoolean AccountingPeriodConnections(SalNumber nWhat)
        {
            #region Local Variables
            SalArray<SalString> sItemNames = new SalArray<SalString>();
            SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        return Sal.TblAnyRows(this.cChildTableDetail, Sys.ROW_Selected, 0) && Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("frmRpdCompanyPeriod"));

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        Sal.WaitCursor(true);
                        sItemNames[0] = "RPD_ID";
                        hWndItems[0] = cChildTableDetail_colsRpdId;
                        sItemNames[1] = "COMPANY";
                        hWndItems[1] = cChildTableDetail_colsCompany;
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("RpdCompany", this.cChildTableDetail, sItemNames, hWndItems);
                        SessionCreateWindow(Pal.GetActiveInstanceName("frmRpdCompanyPeriod"), Sys.hWndMDI);
                        Sal.WaitCursor(false);
                        break;
                }
            }
            return false;
            #endregion
        }

        protected virtual SalBoolean GetRpdIdDescription()
        {
            #region Local Variables
            SalBoolean bCommandOk = false;
            SalString lsStmt = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                String sStmt = ":i_hWndFrame.frmRpdCompany.dfsDescription := " + cSessionManager.c_sDbPrefix + "RPD_IDENTITY_API.GET_DESCRIPTION(:i_hWndFrame.frmRpdCompany.cmbRpdId IN)";
                DbPLSQLTransaction(cSessionManager.c_hSql, sStmt);
                return true;
            }
            #endregion
        }

        protected virtual SalBoolean MapAccountingPeriods(SalNumber nWhat)
        {
            #region Local Variables
            SalArray<SalString> sItemNames = new SalArray<SalString>();
            SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
            SalNumber nRow = Sys.TBL_MinRow;
            SalNumber nReturn = Sys.NUMBER_Null;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        return Sal.TblFindNextRow(this.cChildTableDetail, ref nRow, Sys.ROW_Selected, 0)
                            && !Sal.TblFindNextRow(this.cChildTableDetail, ref nRow, Sys.ROW_Selected, 0)
                            && Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Rpd_Company_API.Map_Accounting_Periods")
                            && Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("dlgRpdMapAccPeriods"))
                            && this.cChildTableDetail_colIsRpdPeriodsDefined.Text.Equals("TRUE")
                            && (!this.cChildTableDetail.DataSourceIsDirty(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire));

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        Sal.WaitCursor(true);
                        nReturn = dlgRpdMapAccPeriods.ModalDialog(Ifs.Fnd.ApplicationForms.Int.Explorer.ExplorerForm, cChildTableDetail_colsRpdId.Text, cChildTableDetail_colsCompany.Text);
                        if ( nReturn== Sys.IDOK)
                        {
                            Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_RpdMapSuccess, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                        }
                        else if (nReturn = Sys.IDNO)
                        {
                            Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_RpdMapPartly, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                        }
                        Sal.WaitCursor(false);
                        break;
                }
            }
            return false;
            #endregion
        }
        #endregion

        #region Overrides

        #endregion

        #region Message Actions

        #endregion

        #region Overrides

        #endregion

        #region Menu Event Handlers
        private void cmd_menuTblMenu_MenuItem_AccPerConnections_Inquire(object sender, Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = AccountingPeriodConnections(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void cmd_menuTblMenu_MenuItem_AccPerConnections_Execute(object sender, Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            AccountingPeriodConnections(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        
        private void cmd_menuTblMenu_MenuItem_MapAccountingPeriods_Inquire(object sender, FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = MapAccountingPeriods(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void cmd_menuTblMenu_MenuItem_MapAccountingPeriods_Execute(object sender, FndCommandExecuteEventArgs e)
        {
             MapAccountingPeriods(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }
        #endregion

        #region Window Actions
        private void cmbRpdId_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.cmbRpdId_OnPM_DataItemValidate(sender, e);
                    break;                
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cmbRpdId_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam) == Sys.VALIDATE_Cancel)
            {
                e.Return = Sys.VALIDATE_Cancel;
                return;
            }
            if (!(Sal.IsNull(this.cmbRpdId)) && this.cmbRpdId.EditDataItemStateGet() == Ifs.Fnd.ApplicationForms.Const.EDIT_Changed)
            {
                this.GetRpdIdDescription();
            }
            e.Return = Sys.VALIDATE_Ok;
            return;
            #endregion
        }
        #endregion
    }
}
