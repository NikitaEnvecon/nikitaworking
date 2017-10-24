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
    [FndWindowRegistration("RPD_YEAR", "RpdYear", "", FndWindowRegistrationFlags.HomePage, false, "")]    
    public partial class frmRpdYear : cFormWindow
    {
        #region Member Variables

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public frmRpdYear()
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
        public new static frmRpdYear FromHandle(SalWindowHandle handle)
        {
            return ((frmRpdYear)SalWindow.FromHandle(handle, typeof(frmRpdYear)));
        }
        #endregion
        
        #region Properties

        #endregion

        #region Methods        
        protected virtual SalBoolean GetRpdIdDescription()
        {
            #region Local Variables
            SalBoolean bCommandOk = false;
            SalString lsStmt = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                String sStmt = ":i_hWndFrame.frmRpdYear.dfsDescription := " + cSessionManager.c_sDbPrefix + "RPD_IDENTITY_API.GET_DESCRIPTION(:i_hWndFrame.frmRpdYear.cmbRpdId IN)";
                DbPLSQLTransaction(cSessionManager.c_hSql, sStmt);
                return true;
            }
            #endregion
        }

        protected virtual SalBoolean AccPeriodConnectionsFromHeader(SalNumber nWhat)
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
                        return (!cmbRpdId.IsEmpty()) && Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("frmRpdCompanyPeriod"));

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        Sal.WaitCursor(true);
                        sItemNames[0] = "RPD_ID";
                        hWndItems[0] = cmbRpdId;
                        sItemNames[1] = "RPD_YEAR";
                        hWndItems[1] = dfnRpdYear;
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("RpdYear", this, sItemNames, hWndItems);
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.TypeSet("HEADER");
                        SessionCreateWindow(Pal.GetActiveInstanceName("frmRpdCompanyPeriod"), Sys.hWndMDI);
                        Sal.WaitCursor(false);
                        break;
                }
            }
            return false;
            #endregion
        }

        protected virtual SalBoolean AccPeriodConnectionsFromDetail(SalNumber nWhat)
        {
            #region Local Variables
            SalArray<SalString> sItemNames = new SalArray<SalString>();
            SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
            SalNumber nRow = 0;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        nRow = Sys.TBL_MinRow;
						if (Sal.TblFindNextRow(cChildTableDetail, ref nRow, Sys.ROW_Selected, 0))
                        {
                            if (Sal.TblFindNextRow(cChildTableDetail, ref nRow, Sys.ROW_Selected, 0))
                            {
                                return 0;
                            }
                        }
                        return (!cmbRpdId.IsEmpty()) && Sal.TblAnyRows(cChildTableDetail, Sys.ROW_Selected, 0) && Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("frmRpdCompanyPeriod"));

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        Sal.WaitCursor(true);
                        sItemNames[0] = "RPD_ID";
                        hWndItems[0] = cChildTableDetail_colsRpdId;
                        sItemNames[1] = "RPD_YEAR";
                        hWndItems[1] = cChildTableDetail_colnRpdYear;
                        sItemNames[2] = "RPD_PERIOD";
                        hWndItems[2] = cChildTableDetail_colnRpdPeriod;
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("RpdYear", cChildTableDetail, sItemNames, hWndItems);
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.TypeSet("DETAIL");
                        SessionCreateWindow(Pal.GetActiveInstanceName("frmRpdCompanyPeriod"), Sys.hWndMDI);
                        Sal.WaitCursor(false);
                        break;
                }
            }
            return false;
            #endregion
        }
        #endregion

        #region Overrides
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public override SalNumber vrtActivate(fcURL URL)
        {
            #region Local Variables
            SalString sDataSourceName = "";
            SalString sType = "";
            SalNumber nReturn;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.RecCountGet() > 0)
                {
                    sDataSourceName = Ifs.Fnd.ApplicationForms.Var.DataTransfer.i_sSourceName;
                    sType = Ifs.Fnd.ApplicationForms.Var.DataTransfer.i_sType;
                    nReturn = base.Activate(URL);
                    if (sDataSourceName == Pal.GetActiveInstanceName("tbwRpdIdentity") && sType == "RMB")
                    {
                        if (Sal.IsNull(dfnRpdYear))
                        {
                            Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_RpdYearNotDefined, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Warning, Ifs.Fnd.ApplicationForms.Const.WARNING_Ok);
                        }
                    }
                    return nReturn;
                }
                return base.Activate(URL);
            }
            #endregion
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

        #region Message Actions
        private void cmd_menuFrmMenu_MenuItem_AccPerConnections_Execute(object sender, FndCommandExecuteEventArgs e)
        {
            AccPeriodConnectionsFromHeader(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void cmd_menuFrmMenu_MenuItem_AccPerConnections_Inquire(object sender, FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = AccPeriodConnectionsFromHeader(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void cmd_menuTblMenu_MenuItem_AccPerConnections_Inquire(object sender, FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = AccPeriodConnectionsFromDetail(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void cmd_menuTblMenu_MenuItem_AccPerConnections_Execute(object sender, FndCommandExecuteEventArgs e)
        {
            AccPeriodConnectionsFromDetail(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }        
        #endregion

        #region Menu Event Handlers
        
        #endregion
    }
}
