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
// Date    By      Notes
// ------  ------  -------------------------------------------------------------------------------------
// 100405  MaMalk  Modified vrtActivate and FrameStartupUser functions to correctly merge the changes done in centura.
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
using System.Collections.Generic;

namespace Ifs.Application.Accrul_
{
	
	/// <summary>
	/// </summary>
    public partial class frmAccPer : cFormWindowFin
    {
        #region Window Variables
        public SalString sCompanyName = "";
        public SalArray<SalString> sPlaceHolders = new SalArray<SalString>();
        public SalArray<SalString> sChanges = new SalArray<SalString>();
        public SalString sID = "";
        public SalNumber nNumChanges = 0;
        public SalString TempAccYear = "";
        public SalString sClVouType = "";
        public SalString sOpVouType = "";
        public SalString sClosingBalances = "";
        public SalString sClosingBalancesdb = "";
        public SalNumber nClYear = 0;
        public SalNumber nClPeriod = 0;
        public SalNumber nClVouNo = 0;
        public SalNumber nOpYear = 0;
        public SalNumber nOpPeriod = 0;
        public SalNumber nOpVouNo = 0;
        public SalArray<SalString> sArray = new SalArray<SalString>();
        public SalNumber nPkgNo = 0;
        public SalString sPeriodType = "";
        public SalString lsPeriodExist = "";
        public SalString sAllApproved = "";
        public SalBoolean bMethodAvailable = false;
        public SalNumber nMethodNo = 0;
        public SalBoolean bInvMethodAvailable = false;
        public SalNumber nInvMethodNo = 0;
        public SalString lsPostErrInvs = "";
        public SalString lsStmt = "";
        public SalString sPeriodClosingMethodDb = "";
        public SalString sPerOpen = "";
        public SalString sPerClosed = "";
        public SalString sPerFinClosed = "";
        public SalString sNewPerStatus = "";
        public SalArray<SalString> sParam = new SalArray<SalString>();
        public SalString sIsFinallyClosed = "";
        public SalString sLastPeriodBalanced = "";
        public SalArray<SalString> sAccYear = new SalArray<SalString>();
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public frmAccPer()
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
        public new static frmAccPer FromHandle(SalWindowHandle handle)
        {
            return ((frmAccPer)SalWindow.FromHandle(handle, typeof(frmAccPer)));
        }
        #endregion

        #region Methods

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public new SalBoolean FrameStartupUser()
        {
            #region Local Variables
            SalString sDataSourceName = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                // Bug 82373, Begin, new methods added, some methods removed
                // Bug 79908, Begin, Merged the server calls
                // Bug 71122, Begin, Added Check_Non_Approved_Paym_Exists
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("Transaction_SYS.Package_Is_Installed_Num", System.Data.ParameterDirection.Input);
                    hints.Add("Acc_Per_Status_API.Decode", System.Data.ParameterDirection.Input);
                    DbPLSQLBlock(cSessionManager.c_hSql, " BEGIN\r\n" +
                        "				:i_hWndFrame.frmAccPer.nPkgNo := &AO.Transaction_SYS.Package_Is_Installed_Num('INTERNAL_LEDGER_API');\r\n" +
                        "				:i_hWndFrame.frmAccPer.sPerOpen := &AO.Acc_Per_Status_API.Decode('O');\r\n" +
                        "				:i_hWndFrame.frmAccPer.sPerClosed := &AO.Acc_Per_Status_API.Decode('C');\r\n" +
                        "				:i_hWndFrame.frmAccPer.sPerFinClosed := &AO.Acc_Per_Status_API.Decode('F');\r\n			END;");
                }
                // Bug 71122, End
                // Bug 79908, End
                // Bug 82373, End
                if (nPkgNo == 0)
                {
                    Sal.HideWindow(this.tblAccPerDetail_colsPeriodStatusInt);
                }
                // Insert new code here...
                // Bug 79908, Moved the db block
                // Bug 82373, Removed Code
                return true;
            }
            #endregion
        }
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public override SalNumber vrtActivate(fcURL URL)
        {
            #region Local Variables
            SalString sDataSourceName = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                this.cbOpenBalConsol.i_sCheckedValue = "Y";
                this.cbOpenBalConsol.i_sUncheckedValue = "N";

                if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.RecCountGet() > 0)
                {
                    Sal.WaitCursor(true);
                    sDataSourceName = Ifs.Fnd.ApplicationForms.Var.DataTransfer.i_sSourceName;
                    // Bug 81879 begin. Added or (sDataSourceName = 'Voucher')
                    if ((sDataSourceName == "FaAccountingPeriod") || (sDataSourceName == "OutstandingSalesAccting") || (sDataSourceName == "AccountingJournalItem") || (sDataSourceName == "Voucher") || 
                                (sDataSourceName == "Commitments") || (sDataSourceName == "PeriodicCalendarCompany"))
                    {
                        // Bug 81879 end                    {
                        initFromZoom();
                    }
                    else
                    {
                        if (InitFromTransferredData())
                            Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();
                        Sal.WaitCursor(false);
                    }
                    return false;
                }
                return base.Activate(URL);
            }
            #endregion

        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber OpenUpYear()
        {
            #region Local Variables
            SalArray<SalString> sItemNames = new SalArray<SalString>();
            SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("ACC_YEAR_CL_BAL_API.Encode", System.Data.ParameterDirection.Input);
                    DbPLSQLBlock(cSessionManager.c_hSql, ":i_hWndFrame.frmAccPer.sClosingBalancesdb := " + cSessionManager.c_sDbPrefix + "ACC_YEAR_CL_BAL_API.Encode(:i_hWndFrame.frmAccPer.dfClosingBalances)");
                }
                if (sClosingBalancesdb == "FB")
                {
                    using (SignatureHints hints = SignatureHints.NewContext())
                    {
                        hints.Add("Accounting_year_API.Open_Up_Closed_Year", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                        DbPLSQLTransaction(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "Accounting_year_API.Open_Up_Closed_Year(\r\n" +
                            "			:i_hWndFrame.frmAccPer.dfsCompany,:i_hWndFrame.frmAccPer.ecmbYear.i_sMyValue)");
                    }
                    i_lsUserWhere = DataSourceUserWhereGet();
                    Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Ifs.Fnd.ApplicationForms.Const.POPULATE_Single);
                }
                else if (sClosingBalancesdb == "FV")
                {
                    Sal.WaitCursor(true);
                    sItemNames[0] = "company";
                    hWndItems[0] = dfsCompany;
                    sItemNames[1] = "accounting_year";
                    hWndItems[1] = ecmbYear;
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init(Pal.GetActiveInstanceName("frmAccPer"), i_hWndFrame, sItemNames, hWndItems);
                    SessionModalDialog(Pal.GetActiveInstanceName("dlgRollbackFinalYearVou"), this);
                    Sal.WaitCursor(false);
                }
                else
                {
                    Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_CheckTrans, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Warning, Ifs.Fnd.ApplicationForms.Const.WARNING_OkCancel);
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber ChangeCom()
        {
            this.SendMessage(Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Sys.lParam);
            return 0; 
        }

        public virtual SalNumber OpenUpYearRmb(SalNumber nWhat)
        {
            #region Local Variables
            SalArray<SalString> sItemNames = new SalArray<SalString>();
            SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire)
                {
                    // Bug 82373, Begin, added new statement Period_Finally_Closed_Exist
                    using (SignatureHints hints = SignatureHints.NewContext())
                    {
                        hints.Add("ACC_YEAR_CL_BAL_API.Encode", System.Data.ParameterDirection.Input);
                        hints.Add("Accounting_Period_API.Period_Finally_Closed_Exist", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                        DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN\r\n" +
                            "	:i_hWndFrame.frmAccPer.sClosingBalancesdb := " + cSessionManager.c_sDbPrefix + "ACC_YEAR_CL_BAL_API.Encode(:i_hWndFrame.frmAccPer.dfClosingBalances);\r\n" +
                            "	:i_hWndFrame.frmAccPer.sIsFinallyClosed := &AO.Accounting_Period_API.Period_Finally_Closed_Exist(\r\n" +
                            "			:i_hWndFrame.frmAccPer.dfsCompany,\r\n" +
                            "			:i_hWndFrame.frmAccPer.ecmbYear.i_sMyValue);\r\nEND;");
                    }
                    if (sIsFinallyClosed == "TRUE")
                    {
                        return 0;
                    }
                    // Bug 82373, End
                    if ((dfStatusDb.Text == "C") && (sClosingBalancesdb == "FV") && Ifs.Fnd.ApplicationForms.Var.Component.IsWindowAvailable(Pal.GetActiveInstanceName("dlgRollbackFinalYearVou")) && Ifs.Fnd.ApplicationForms.Var.Component.IsWindowAvailable(Pal.GetActiveInstanceName("dlgRollbackVouCreated")))
                    {
                        return 1;
                    }
                    if ((dfStatusDb.Text == "C") && (sClosingBalancesdb == "FB"))
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
                {
                    if (Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_OpenYear, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Warning, Ifs.Fnd.ApplicationForms.Const.WARNING_OkCancel) == Sys.IDOK)
                    {
                        using (SignatureHints hints = SignatureHints.NewContext())
                        {
                            hints.Add("ACC_YEAR_CL_BAL_API.Encode", System.Data.ParameterDirection.Input);
                            DbPLSQLBlock(cSessionManager.c_hSql, ":i_hWndFrame.frmAccPer.sClosingBalancesdb := " + cSessionManager.c_sDbPrefix + "ACC_YEAR_CL_BAL_API.Encode(:i_hWndFrame.frmAccPer.dfClosingBalances)");
                        }
                        if (sClosingBalancesdb == "FB")
                        {
                            using (SignatureHints hints = SignatureHints.NewContext())
                            {
                                hints.Add("Accounting_year_API.Open_Up_Closed_Year", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                                DbPLSQLTransaction(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "Accounting_year_API.Open_Up_Closed_Year(\r\n" +
                                    "			:i_hWndFrame.frmAccPer.dfsCompany,:i_hWndFrame.frmAccPer.ecmbYear.i_sMyValue)");
                            }
                            i_lsUserWhere = DataSourceUserWhereGet();
                            Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Ifs.Fnd.ApplicationForms.Const.POPULATE_Single);
                        }
                        else if (sClosingBalancesdb == "FV")
                        {
                            Sal.WaitCursor(true);
                            sItemNames[0] = "company";
                            hWndItems[0] = dfsCompany;
                            sItemNames[1] = "accounting_year";
                            hWndItems[1] = ecmbYear;
                            Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init(Pal.GetActiveInstanceName("frmAccPer"), i_hWndFrame, sItemNames, hWndItems);
                            SessionModalDialog(Pal.GetActiveInstanceName("dlgRollbackFinalYearVou"), this);
                            Sal.WaitCursor(false);
                        }
                        else
                        {
                            Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_CheckTrans, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Warning, Ifs.Fnd.ApplicationForms.Const.WARNING_OkCancel);
                        }
                    }
                }
            }
            return 0;
            #endregion
        }
               
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber initFromZoom()
        {
            #region Local Variables
            SalString sMasterWhereStmt = "";
            SalString sChildWhereStmt = "";
            SalString sYear = "";
            SalString sPeriod = "";
            SalString sCompany = "";
            SalNumber nCompanyIndex = 0;
            SalNumber nAccYearIndex = 0;
            SalNumber nAccPeriodIndex = 0;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                nCompanyIndex = Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemIndexGet("COMPANY");
                nAccYearIndex = Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemIndexGet("ACCOUNTING_YEAR");
                nAccPeriodIndex = Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemIndexGet("ACCOUNTING_PERIOD");
                Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemValueStrGet(nCompanyIndex, 0, ref sCompany);
                Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemValueStrGet(nAccYearIndex, 0, ref sYear);
                Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemValueStrGet(nAccPeriodIndex, 0, ref sPeriod);
                Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();
                SetCompany(sCompany);
                // Creating MasterWhere
                sMasterWhereStmt = " COMPANY='" + sCompany + "' AND ACCOUNTING_YEAR='" + sYear + "'";
                // Creating ChildWhere
                sChildWhereStmt = "ACCOUNTING_PERIOD='" + sPeriod + "'";
                Sal.SendMsg(i_hWndFrame, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceUserWhere, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, sMasterWhereStmt.ToHandle());
                Sal.SendMsg(tblAccPerDetail, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceUserWhere, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, sChildWhereStmt.ToHandle());
                Sal.SendMsg(i_hWndFrame, Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                Sal.WaitCursor(false);
                return true;
            }
            #endregion
        }
        // Bug 82373, Removed SaveAccountingPeriods()
        // Bug 72815, Begin.
        /// <summary>
        /// This function was added in case the year end accounting was done with the accounting periods window opened tha database changes are not reflected in the window
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean IsYearOpen()
        {
            #region Actions
            using (new SalContext(this))
            {
                // Bug 79908, Begin, Added an IF condition to skip the db call when company is null (during framestartup)
                if (dfsCompany.Text != Sys.STRING_Null)
                {
                    using (SignatureHints hints = SignatureHints.NewContext())
                    {
                        hints.Add("Accounting_Year_API.Get_Year_Status_Db", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                        if (DbPLSQLBlock(cSessionManager.c_hSql, ":i_hWndFrame.frmAccPer.dfStatusDb := &AO.Accounting_Year_API.Get_Year_Status_Db(:i_hWndFrame.frmAccPer.dfsCompany,\r\n" +
                            "                                                                                                                                                                                          :i_hWndFrame.frmAccPer.ecmbYear.i_sMyValue)"))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                // Bug 79908, End
            }

            return false;
            #endregion
        }
        // Bug 72815, End..
        // Bug 93466 Begin
        /// <summary>
        /// Applications override the DataSourceSaveCheckOk function to check
        /// whether a save transaction was sucessful.
        /// </summary>
        /// <returns>
        /// Applications should return TRUE to indicate that the transaction was sucessful and
        /// let the framework commit it. If FALSE is returned, the framework will rollback the
        /// entire save transaction.
        /// </returns>
        public new SalBoolean DataSourceSaveCheckOk()
        {
            #region Actions
            using (new SalContext(this))
            {
                Sal.WaitCursor(true);
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("Accounting_Period_API.Do_Final_Check", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                    if (!(DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN\r\n" +
                        "                                                            &AO.Accounting_Period_API.Do_Final_Check(\r\n" +
                        "                                                                                        :i_hWndFrame.frmAccPer.dfsCompany,\r\n" +
                        "                                                                                        :i_hWndFrame.frmAccPer.ecmbYear.i_sMyValue ); \r\n" +
                        "                                                     END;")))
                    {
                        return false;
                    }
                }
                Sal.WaitCursor(false);
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
        private void frmAccPer_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                // Bug 82373, Removed On PM_DataSourceSave

                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate:
                    this.frmAccPer_OnPM_DataSourcePopulate(sender, e);
                    break;

                // Bug 72815, End

                case Sys.SAM_Activate:
                    this.frmAccPer_OnSAM_Activate(sender, e);
                    break;

                // Bug 72815, End
            }
            #endregion
        }

        /// <summary>
        /// PM_DataSourcePopulate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmAccPer_OnPM_DataSourcePopulate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Sys.wParam, Sys.lParam))
            {
                if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
                {
                    using (SignatureHints hints = SignatureHints.NewContext())
                    {
                        hints.Add("Company_Finance_API.Get_Period_Closing_Method", System.Data.ParameterDirection.Input);
                        hints.Add("Period_Closing_Method_API.Encode", System.Data.ParameterDirection.Input);
                        if (!(this.DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN :i_hWndFrame.frmAccPer.sPeriodClosingMethodDb :=\r\n" +
                            "	&AO.Period_Closing_Method_API.Encode(&AO.Company_Finance_API.Get_Period_Closing_Method(:i_hWndFrame.frmAccPer.dfsCompany)); END;")))
                        {
                            e.Return = false;
                            return;
                        }
                    }
                }
                e.Return = true;
                return;
            }
            e.Return = false;
            return;
            #endregion
        }

        /// <summary>
        /// SAM_Activate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmAccPer_OnSAM_Activate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == 1)
            {
                this.IsYearOpen();
            }
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void cbOpenBalConsol_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
            }
            #endregion
        }

        /// <summary>
        /// SAM_Create event handler.
        /// </summary>
        /// <param name="message"></param>

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblAccPerDetail_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew:
                    this.tblAccPerDetail_OnPM_DataRecordNew(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordDuplicate:
                    this.tblAccPerDetail_OnPM_DataRecordDuplicate(sender, e);
                    break;

                case Sys.SAM_RowHeaderDoubleClick:
                    this.tblAccPerDetail_OnSAM_RowHeaderDoubleClick(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove:
                    this.tblAccPerDetail_OnPM_DataRecordRemove(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataRecordNew event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblAccPerDetail_OnPM_DataRecordNew(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire)
            {
                if (Sal.IsNull(this.ecmbYear))
                {
                    e.Return = false;
                    return;
                }
                // Bug 82373, Begin
                if (this.dfStatusDb.Text != "O")
                {
                    e.Return = false;
                    return;
                }
                // Bug 82373, End
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataRecordDuplicate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblAccPerDetail_OnPM_DataRecordDuplicate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire)
            {
                // Bug 82373, Begin
                if (this.dfStatusDb.Text != "O")
                {
                    e.Return = false;
                    return;
                }
                // Bug 82373, End
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordDuplicate, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// SAM_RowHeaderDoubleClick event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblAccPerDetail_OnSAM_RowHeaderDoubleClick(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire)
            {
                // Bug 82373, Begin
                if (this.dfStatusDb.Text != "O")
                {
                    e.Return = false;
                    return;
                }
                // Bug 82373, End
            }
            e.Return = Sal.SendClassMessage(Sys.SAM_RowHeaderDoubleClick, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataRecordRemove event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblAccPerDetail_OnPM_DataRecordRemove(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire)
            {
                // Bug 82373, Begin
                if (this.dfStatusDb.Text != "O")
                {
                    e.Return = false;
                    return;
                }
                // Bug 82373, End
            }
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                DbPLSQLBlock(@"{0} := &AO.Voucher_No_Serial_API.Is_Period_Exist({1} IN,{2} IN, {3} IN);", 
                                                                                this.QualifiedVarBindName("lsPeriodExist"),
                                                                                this.dfsCompany.QualifiedBindName,
                                                                                this.tblAccPerDetail_colAccountingYear.QualifiedBindName,
                                                                                this.tblAccPerDetail_colAccountingPeriod.QualifiedBindName);
                
                if (this.lsPeriodExist == "TRUE")
                {
                    if (Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_VoucherSerialPeriod, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Warning, Ifs.Fnd.ApplicationForms.Const.WARNING_OkCancel) == Sys.IDOK)
                    {
                        e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove, Sys.wParam, Sys.lParam);
                        return;
                    }
                    else
                    {
                        e.Return = false;
                        return;
                    }
                }
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }
        #endregion

        #region Late Bind Methods

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalBoolean vrtDataSourceSaveCheckOk()
        {
            return this.DataSourceSaveCheckOk();
        }

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalBoolean vrtFrameStartupUser()
        {
            return this.FrameStartupUser();
        }

        
        #endregion

        #region ChildTable-tblAccPerDetail

        #region Methods

            /// <summary>
            /// Gets default values for NEW records
            /// </summary>
            /// <returns></returns>
            public virtual SalBoolean tblAccPerDetail_DataRecordGetDefaults()
            {
                #region Actions
         
                tblAccPerDetail_colCompany.Text = this.dfsCompany.Text;
                this.TempAccYear = this.ecmbYear.i_sMyValue;
                tblAccPerDetail_colAccountingYear.Number = this.TempAccYear.ToNumber();
                tblAccPerDetail_colAccountingYear.EditDataItemSetEdited();
                tblAccPerDetail_colCompany.EditDataItemSetEdited();
                return true;
               
                #endregion
            }
            // -------------------------- message answer functions -------------------
            /// <summary>
            /// </summary>
            /// <returns></returns>
            public virtual SalString GetWindowTitle()
            {
                #region Actions
             
                return Properties.Resources.WH_frmAccPer;
           
                #endregion
            }
            // -------------------------- internal functions -------------------------
            /// <summary>
            /// This function returns TRUE, if only one row in table window is selected
            /// </summary>
            /// <returns></returns>
            public virtual SalBoolean ___OnlyOneRowSelected()
            {
                #region Local Variables
                SalNumber nOldRow = 0;
                SalNumber nRow = 0;
                SalNumber nSelRows = 0;
                #endregion
              
                #region Actions
           
                nOldRow = Sal.TblQueryContext(tblAccPerDetail);
                nRow = Sys.TBL_MinRow;
                nSelRows = 0;
                while (true)
                {
                    if (Sal.TblFindNextRow(tblAccPerDetail, ref nRow, Sys.ROW_Selected, Sys.ROW_MarkDeleted))
                    {
                        Sal.TblSetContext(tblAccPerDetail, nRow);
                        nSelRows = nSelRows + 1;
                    }
                    else
                    {
                        break;
                    }
                }
                Sal.TblSetContext(tblAccPerDetail, nOldRow);
                if (nSelRows != 1)
                {
                    return false;
                }
                return true;
             
                #endregion
            }
            // --------------------------  -------------------------
            /// <summary>
            /// </summary>
            /// <param name="nWhat"></param>
            /// <returns></returns>
            public virtual SalNumber Create(SalNumber nWhat)
            {
                #region Local Variables
                SalNumber nRow = 0;
                SalArray<SalNumber> nYear = new SalArray<SalNumber>();
                SalArray<SalNumber> nPeriod = new SalArray<SalNumber>();
                SalArray<SalString> sPeriodStatus = new SalArray<SalString>();
                SalNumber nIndex = 0;
                #endregion

                #region Actions

                Sal.WaitCursor(true);
                nRow = Sys.TBL_MinRow;
                nIndex = 0;
                while (Sal.TblFindNextRow(tblAccPerDetail, ref nRow, Sys.ROW_Selected, 0))
                {
                    Sal.TblSetContext(tblAccPerDetail, nRow);
                    nYear[nIndex] = tblAccPerDetail_colAccountingYear.Number;
                    nPeriod[nIndex] = tblAccPerDetail_colAccountingPeriod.Number;
                    sPeriodStatus[nIndex] = tblAccPerDetail_colPeriodStatus.Text;
                    nIndex = nIndex + 1;
                }
                nPeriod[nIndex] = -1;
                Sal.WaitCursor(false);
                return dlgCreatePeriod.ModalDialog(Ifs.Fnd.ApplicationForms.Int.Explorer.ExplorerForm, nYear, nPeriod, sPeriodStatus, tblAccPerDetail_colCompany.Text);
                return 0;

                #endregion   
            }
         
            /// <summary>
            /// </summary>
            /// <param name="sWhat"></param>
            /// <returns></returns>
            public virtual SalNumber RightMouseClick(SalString sWhat)
            {
                #region Local Variables
                SalArray<SalString> sItemNames = new SalArray<SalString>();
                SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
                #endregion

                #region Action
                Sal.WaitCursor(true);
                sItemNames[0] = "Accounting_Year";
                hWndItems[0] = tblAccPerDetail_colAccountingYear;
                sItemNames[1] = "Accounting_Period";
                hWndItems[1] = tblAccPerDetail_colAccountingPeriod;
                Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("ACCOUNTING_PERIOD", tblAccPerDetail, sItemNames, hWndItems);
                SessionCreateWindow(Pal.GetActiveInstanceName("frmUserGrpPer"), Sys.hWndMDI);
                Sal.WaitCursor(false);
                return 0;
                #endregion
            }

            /// <summary>
            /// </summary>
            /// <returns></returns>
            public virtual SalBoolean Check_AccPeriod()
            {
                #region Local Variables
                SalNumber nRowCount = 0;
                SalNumber nAccPer = 0;
                SalNumber nTempCount = 0;
                SalNumber nPrevRowCount = 0;
                #endregion

                #region Actions
      
                nRowCount = Sys.TBL_MinRow;
                nAccPer = tblAccPerDetail_colAccountingPeriod.Number;
                nTempCount = 0;
                nPrevRowCount = Sal.TblQueryContext(tblAccPerDetail);
                while (Sal.TblFindNextRow(tblAccPerDetail, ref nRowCount, 0, Sys.ROW_New))
                {
                    Sal.TblSetContext(tblAccPerDetail, nRowCount);
                    if (tblAccPerDetail_colAccountingPeriod.Number == nAccPer)
                    {
                        nTempCount = nTempCount + 1;
                    }
                }
                if (nTempCount > 0)
                {
                    Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_frmAccPer1, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Warning, Ifs.Fnd.ApplicationForms.Const.WARNING_Ok);
                    Sal.TblSetContext(tblAccPerDetail, nPrevRowCount);
                    return false;
                }
                Sal.TblSetContext(tblAccPerDetail, nPrevRowCount);
                return true;
                #endregion
            }
            // Bug 82373, Begin
            /// <summary>
            /// </summary>
            /// <param name="p_sAction"></param>
            /// <returns></returns>
            public virtual SalBoolean CheckSelectedPeriodsStatus(SalString p_sAction)
            {
                #region Local Variables
                SalNumber nCurrentRow = 0;
                SalNumber nOldRow = 0;
                SalString sPrevPerStatus = "";
                #endregion

                #region Actions
           
                nOldRow = Sal.TblQueryContext(tblAccPerDetail);
                nCurrentRow = Sys.TBL_MinRow;
                // Fetch first selected row
                Sal.TblFindNextRow(tblAccPerDetail, ref nCurrentRow, Sys.ROW_Selected, 0);
                Sal.TblSetContext(tblAccPerDetail, nCurrentRow);
                sPrevPerStatus = tblAccPerDetail_colPeriodStatus.Text;
                if (p_sAction == "OPEN")
                {
                    if (tblAccPerDetail_colPeriodStatus.Text != this.sPerClosed)
                    {
                        Sal.TblSetContext(tblAccPerDetail, nOldRow);
                        return false;
                    }
                }
                else if (p_sAction == "CLOSE")
                {
                    if (tblAccPerDetail_colPeriodStatus.Text != this.sPerOpen)
                    {
                        Sal.TblSetContext(tblAccPerDetail, nOldRow);
                        return false;
                    }
                }
                else if (p_sAction == "VALIDATE")
                {
                    if (tblAccPerDetail_colPeriodStatus.Text != this.sPerClosed && tblAccPerDetail_colPeriodStatus.Text != this.sPerOpen)
                    {
                        Sal.TblSetContext(tblAccPerDetail, nOldRow);
                        return false;
                    }
                }
                else
                {
                    Sal.TblSetContext(tblAccPerDetail, nOldRow);
                    return false;
                }
                while (Sal.TblFindNextRow(tblAccPerDetail, ref nCurrentRow, Sys.ROW_Selected, 0))
                {
                    Sal.TblSetContext(tblAccPerDetail, nCurrentRow);
                    if (tblAccPerDetail_colPeriodStatus.Text != sPrevPerStatus)
                    {
                        Sal.TblSetContext(tblAccPerDetail, nOldRow);
                        return false;
                    }
                    sPrevPerStatus = tblAccPerDetail_colPeriodStatus.Text;
                }
                Sal.TblSetContext(tblAccPerDetail, nOldRow);
                return true;
          
                #endregion
            }

            /// <summary>
            /// </summary>
            /// <param name="p_sAction"></param>
            /// <returns></returns>
            public virtual SalNumber ModifyPeriodStatus(SalString p_sAction)
            {
                #region Local Variables
                SalString lsStmt = "";
                SalNumber nCurrentRow = 0;
                SalNumber nOldRow = 0;
                #endregion

                #region Actions
           
                Sal.WaitCursor(true);
                IDictionary<string, string> namedBindVariables = new Dictionary<string, string>();
                namedBindVariables.Add("Objid", this.QualifiedVarBindName("tblAccPerDetail.__colObjid"));
                namedBindVariables.Add("Objversion", this.QualifiedVarBindName("tblAccPerDetail.__colObjversion"));
                if (p_sAction == "OPEN")
                {
                    lsStmt = "&AO.Accounting_Period_API.Open_Period({Objid} IN, {Objversion} INOUT )";
                }
                else if (p_sAction == "CLOSE")
                {
                    lsStmt = "&AO.Accounting_Period_API.Close_Period({Objid} IN, {Objversion} INOUT )";
                }
                else if (p_sAction == "CLOSE_FIN")
                {
                    lsStmt = "&AO.Accounting_Period_API.Close_Period_Finally({Objid} IN, {Objversion} INOUT )";
                }
                else
                {
                    Sal.WaitCursor(false);
                    return false;
                }
                nCurrentRow = Sys.TBL_MinRow;
                nOldRow = Sal.TblQueryContext(tblAccPerDetail);
                DbTransactionBegin(ref cSessionManager.c_hSql);
                while (Sal.TblFindNextRow(tblAccPerDetail, ref nCurrentRow, Sys.ROW_Selected, 0))
                {
                    Sal.TblSetContext(tblAccPerDetail, nCurrentRow);
                    if (!(DbPLSQLBlock(lsStmt,namedBindVariables)))
                    {
                        DbTransactionClear(cSessionManager.c_hSql);
                        if (p_sAction == "CLOSE_FIN")
                        {
                            Sal.TblSetContext(tblAccPerDetail, nOldRow);
                        }
                        else
                        {
                            tblAccPerDetail.SendMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                        }
                        Sal.WaitCursor(false);
                        return false;
                    }
                        
                    tblAccPerDetail.DataRecordRefresh(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
                }
                DbTransactionEnd(cSessionManager.c_hSql);
                Sal.TblSetContext(tblAccPerDetail, nOldRow);
                Sal.WaitCursor(false);
                return true;
                
                #endregion
            }

            public virtual SalNumber ValidateTransProgress(SalNumber nWhat)
            {
                #region Local Variables
                SalNumber nMinRow = 0;
                #endregion

                #region Actions

                if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire)
                {
                    if (((bool)Sal.SendMsg(tblAccPerDetail, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0)) || this.dfStatusDb.Text == "C" || !(Sal.TblAnyRows(tblAccPerDetail, Sys.ROW_Selected, 0)))
                    {
                        return 0;
                    }
                    if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("dlgTransactionsInProgress"))))
                    {
                        return 0;
                    }
                    return CheckSelectedPeriodsStatus("VALIDATE");
                }
                if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
                {
                    nMinRow = Sys.TBL_MinRow;
                    return dlgTransactionsInProgress.ModalDialog(Ifs.Fnd.ApplicationForms.Int.Explorer.ExplorerForm, this, nMinRow, this.dfsCompany.Text, this.ecmbYear.i_sMyValue.ToNumber(), "VALIDATE");
                }

                return 0;
                #endregion
            }

            internal protected virtual SalNumber ClosePeriod(SalNumber nWhat)
            {
                #region Local Variables
                SalNumber nMinRow = 0;
                #endregion

                #region Actions
                if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire)
                {
                    if (((bool)Sal.SendMsg(tblAccPerDetail, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0)) || this.dfStatusDb.Text == "C" || !(Sal.TblAnyRows(tblAccPerDetail, Sys.ROW_Selected, 0)))
                    {
                        return 0;
                    }
                    if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("dlgTransactionsInProgress"))))
                    {
                        return 0;
                    }
                    if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Accounting_Period_API.Close_Period")))
                    {
                        return 0;
                    }
                    return CheckSelectedPeriodsStatus("CLOSE");
                }
                if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
                {
                    nMinRow = Sys.TBL_MinRow;
                    if (dlgTransactionsInProgress.ModalDialog(Ifs.Fnd.ApplicationForms.Int.Explorer.ExplorerForm, this, nMinRow, this.dfsCompany.Text, this.ecmbYear.i_sMyValue.ToNumber(), "CLOSE") == 10)
                    {
                        ModifyPeriodStatus("CLOSE");
                    }
                }
              
                return 0;
                #endregion
            }

            /// <summary>
            /// </summary>
            /// <param name="nWhat"></param>
            /// <returns></returns>
            public virtual SalNumber OpenPeriod(SalNumber nWhat)
            {
                #region Actions
                if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire)
                {
                    if (((bool)Sal.SendMsg(tblAccPerDetail, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0)) || this.dfStatusDb.Text == "C" || !(Sal.TblAnyRows(tblAccPerDetail, Sys.ROW_Selected, 0)))
                    {
                        return 0;
                    }
                    if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Accounting_Period_API.Open_Period")))
                    {
                        return 0;
                    }
                    return CheckSelectedPeriodsStatus("OPEN");
                }
                if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
                {
                    ModifyPeriodStatus("OPEN");
                }
                return 0;
                #endregion
            }

            /// <summary>
            /// </summary>
            /// <param name="nWhat"></param>
            /// <returns></returns>
            public virtual SalNumber CloseFinally(SalNumber nWhat)
            {
                #region Local Variables
                SalNumber nMinRow = 0;
                #endregion

                #region Actions
                if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire)
                {
                    if (((bool)Sal.SendMsg(tblAccPerDetail, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0)) || this.dfStatusDb.Text == "C" || !(___OnlyOneRowSelected()))
                    {
                        return 0;
                    }
                    if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("dlgTransactionsInProgress"))))
                    {
                        return 0;
                    }
                    if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Accounting_Period_API.Close_Period_Finally")))
                    {
                        return 0;
                    }
                    if (tblAccPerDetail_colPeriodStatus.Text == this.sPerClosed && this.sPeriodClosingMethodDb == "NOT_REVERSIBLE")
                    {
                        return 1;
                    }
                    return 0;
                }
                if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
                {
                    nMinRow = Sys.TBL_MinRow;
                    if (dlgTransactionsInProgress.ModalDialog(Ifs.Fnd.ApplicationForms.Int.Explorer.ExplorerForm, this, nMinRow, this.dfsCompany.Text, this.ecmbYear.i_sMyValue.ToNumber(), "CLOSE_FIN") == 20)
                    {
                        // Get info for validation of the balane at the final closing of the last non finally closed period
                        using (SignatureHints hints = SignatureHints.NewContext())
                        {
                            hints.Add("Accounting_Period_API.Year_Balanced_At_Period_Close", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                            if (!(DbPLSQLBlock(@"BEGIN {0} := &AO.Accounting_Period_API.Year_Balanced_At_Period_Close({1} IN, {2} IN, {3} IN); END; ", 
                                    this.QualifiedVarBindName("sLastPeriodBalanced"),
                                    this.QualifiedVarBindName("dfsCompany"),
                                    this.QualifiedVarBindName("tblAccPerDetail_colAccountingYear"),
                                    this.QualifiedVarBindName("tblAccPerDetail_colAccountingPeriod"))))
                            {
                                return 0;
                            }
                        }
                        if (this.sLastPeriodBalanced == "FALSE")
                        {
                            this.sParam[0] = tblAccPerDetail_colAccountingYear.Number.ToString(0);
                            if (Ifs.Fnd.ApplicationForms.Int.AlertBoxWithParams(Properties.Resources.TEXT_NonBalancedYear, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Warning, (Ifs.Fnd.ApplicationForms.Const.QUESTION_YesNo | Sys.MB_DefButton2), this.sParam) !=
                            Sys.IDYES)
                            {
                                return 0;
                            }
                        }

                        this.sParam[0] = tblAccPerDetail_colsDescription.Text;
                        if (Ifs.Fnd.ApplicationForms.Int.AlertBoxWithParams(Properties.Resources.TEXT_ConfirmPeriodFinClose, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Warning, (Ifs.Fnd.ApplicationForms.Const.QUESTION_YesNo | Sys.MB_DefButton2),
                            this.sParam) == Sys.IDYES)
                        {
                            ModifyPeriodStatus("CLOSE_FIN");
                        }
                        else
                        {
                            return 0;
                        }
                    }
                }
                
                return 0;
                #endregion
            }

            public virtual SalNumber ChangeCompany(SalNumber nWhat)
            {
                #region Actions
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        return 1;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        this.ChangeCom();
                        break;
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
            private void tblAccPerDetail_colAccountingPeriod_WindowActions(object sender, WindowActionsEventArgs e)
            {
                #region Actions
                switch (e.ActionType)
                {
                    case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                        this.tblAccPerDetail_colAccountingPeriod_OnPM_DataItemValidate(sender, e);
                        break;
                }
                #endregion
            }

            /// <summary>
            /// PM_DataItemValidate event handler.
            /// </summary>
            /// <param name="message"></param>
            private void tblAccPerDetail_colAccountingPeriod_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
            {
                #region Actions
                e.Handled = true;
                if (this.Check_AccPeriod())
                {
                    if (this.tblAccPerDetail_colAccountingPeriod.Number == 0)
                    {
                        using (SignatureHints hints = SignatureHints.NewContext())
                        {
                            hints.Add("Period_Type_API.Decode", System.Data.ParameterDirection.Input);
                            if (!(this.tblAccPerDetail_colAccountingPeriod.DbPLSQLBlock(cSessionManager.c_hSql, ":i_hWndFrame.frmAccPer.sPeriodType := " + cSessionManager.c_sDbPrefix + "Period_Type_API.Decode('YEAROPEN')")))
                            {
                                e.Return = false;
                                return;
                            }
                        }
                        if (this.sPeriodType != Ifs.Fnd.ApplicationForms.Const.strNULL)
                        {
                            this.tblAccPerDetail_colsPeriodType.Text = this.sPeriodType;
                        }
                    }
                    e.Return = Sys.VALIDATE_Ok;
                    return;
                }
                #endregion
            }

            /// <summary>
            /// Window Actions
            /// </summary>
            /// <param name="sender">The source of the event.</param>
            /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
            private void tblAccPerDetail_colsDescription_WindowActions(object sender, WindowActionsEventArgs e)
            {
                #region Actions
                switch (e.ActionType)
                {
                    case Ifs.Fnd.ApplicationForms.Const.PM_EditStateFieldEnabled:
                        this.tblAccPerDetail_colsDescription_OnPM_EditStateFieldEnabled(sender, e);
                        break;
                }
                #endregion
            }

            /// <summary>
            /// PM_EditStateFieldEnabled event handler.
            /// </summary>
            /// <param name="message"></param>
            private void tblAccPerDetail_colsDescription_OnPM_EditStateFieldEnabled(object sender, WindowActionsEventArgs e)
            {
                #region Actions
                e.Handled = true;
                if (this.dfStatusDb.Text == "C")
                {
                    e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                    return;
                }
                // Bug 91976 Begin
                e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_EditStateFieldEnabled, Sys.wParam, Sys.lParam);
                return;
                // Bug 91976 End
                #endregion
            }

            /// <summary>
            /// Window Actions
            /// </summary>
            /// <param name="sender">The source of the event.</param>
            /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
            private void tblAccPerDetail_coldDateFrom_WindowActions(object sender, WindowActionsEventArgs e)
            {
                #region Actions
                switch (e.ActionType)
                {
                    case Ifs.Fnd.ApplicationForms.Const.PM_EditStateFieldEnabled:
                        this.tblAccPerDetail_coldDateFrom_OnPM_EditStateFieldEnabled(sender, e);
                        break;
                }
                #endregion
            }

            /// <summary>
            /// PM_EditStateFieldEnabled event handler.
            /// </summary>
            /// <param name="message"></param>
            private void tblAccPerDetail_coldDateFrom_OnPM_EditStateFieldEnabled(object sender, WindowActionsEventArgs e)
            {
                #region Actions
                e.Handled = true;
                if (this.dfStatusDb.Text == "C")
                {
                    e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                    return;
                }
                // Bug 91976 Begin
                e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_EditStateFieldEnabled, Sys.wParam, Sys.lParam);
                return;
                // Bug 91976 End
                #endregion
            }

            /// <summary>
            /// Window Actions
            /// </summary>
            /// <param name="sender">The source of the event.</param>
            /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
            private void tblAccPerDetail_coldDateUntil_WindowActions(object sender, WindowActionsEventArgs e)
            {
                #region Actions
                switch (e.ActionType)
                {
                    case Ifs.Fnd.ApplicationForms.Const.PM_EditStateFieldEnabled:
                        this.tblAccPerDetail_coldDateUntil_OnPM_EditStateFieldEnabled(sender, e);
                        break;
                }
                #endregion
            }

            /// <summary>
            /// PM_EditStateFieldEnabled event handler.
            /// </summary>
            /// <param name="message"></param>
            private void tblAccPerDetail_coldDateUntil_OnPM_EditStateFieldEnabled(object sender, WindowActionsEventArgs e)
            {
                #region Actions
                e.Handled = true;
                if (this.dfStatusDb.Text == "C")
                {
                    e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                    return;
                }
                // Bug 91976 Begin
                e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_EditStateFieldEnabled, Sys.wParam, Sys.lParam);
                return;
                // Bug 91976 End
                #endregion
            }

            /// <summary>
            /// Window Actions
            /// </summary>
            /// <param name="sender">The source of the event.</param>
            /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
            private void tblAccPerDetail_colsPeriodType_WindowActions(object sender, WindowActionsEventArgs e)
            {
                #region Actions
                switch (e.ActionType)
                {
                    case Sys.SAM_DropDown:
                        this.tblAccPerDetail_colsPeriodType_OnSAM_DropDown(sender, e);
                        break;
                }
                #endregion
            }

            /// <summary>
            /// SAM_DropDown event handler.
            /// </summary>
            /// <param name="message"></param>
            private void tblAccPerDetail_colsPeriodType_OnSAM_DropDown(object sender, WindowActionsEventArgs e)
            {
                #region Actions
                e.Handled = true;
                if (Sal.SendClassMessage(Sys.SAM_DropDown, Sys.wParam, Sys.lParam))
                {
                    if (this.tblAccPerDetail_colAccountingPeriod.Number == 0)
                    {
                        Sal.ListDelete(this.tblAccPerDetail_colsPeriodType.i_hWndSelf, 1);
                        Sal.ListDelete(this.tblAccPerDetail_colsPeriodType.i_hWndSelf, 1);
                    }
                    else
                    {
                        e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_LookupInit, Sys.wParam, Sys.lParam);
                        return;
                        e.Return = true;
                        return;
                    }
                }
                #endregion
            }
            #endregion

        #region Window Events

        private void tblAccPerDetail_DataRecordGetDefaultsEvent(object sender, FndReturnEventArgsSalBoolean e)
        {
            e.Handled = true;
            e.ReturnValue = this.tblAccPerDetail_DataRecordGetDefaults();
        }
        #endregion 

        #endregion

        #region Event Handlers

        private void menuItem_User_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            if (!(Sal.SendMsg(i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0)))
            {
                ((FndCommand)sender).Enabled = Sal.TblAnyRows(Sys.hWndForm, Sys.ROW_Selected, 0);
            }
            else
            {
                ((FndCommand)sender).Enabled = false;
            }

        }

        private void menuItem_User_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {

             this.RightMouseClick("EDIT");
        }

        private void menuItem_Create_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("dlgCreatePeriod"))) ||
                   !(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("User_Group_Period_API.Insert_User_Group")) ||
                    (bool)Sal.SendMsg(this.GetParent(), Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Sys.wParam, Sys.lParam))
            {
                ((FndCommand)sender).Enabled = false;
            }
            else
            {
                ((FndCommand)sender).Enabled = Sal.TblAnyRows(Sys.hWndForm, Sys.ROW_Selected, 0);
            }
        }

        private void menuItem_Create_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            this.Create(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute); 
        }

        private void menuItem_Validate_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = this.ValidateTransProgress(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

       

        private void menuItem_Validate_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            this.ValidateTransProgress(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem_Close_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled =  this.ClosePeriod(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem_Close_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            this.ClosePeriod(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem_Open_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = this.OpenPeriod(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem_Open_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            this.OpenPeriod(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem_Close_1_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = this.CloseFinally(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem_Close_1_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            this.CloseFinally(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem_Change_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = this.ChangeCompany(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem_Change_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            this.ChangeCompany(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem_Change_1_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = true;
        }

        private void menuItem_Change_1_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            ChangeCom();
        }

        private void menuItem_Open_1_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = OpenUpYearRmb(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem_Open_1_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            OpenUpYearRmb(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem_Change_2_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = true;
        }

        private void menuItem_Change_2_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            ChangeCom();
        }

        private void menuItem_Open_2_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = OpenUpYearRmb(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem_Open_2_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            OpenUpYearRmb(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }
        #endregion
    }
}
