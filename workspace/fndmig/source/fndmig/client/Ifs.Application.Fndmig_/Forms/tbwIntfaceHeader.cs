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

using System.Windows.Forms;
using Ifs.Fnd.ApplicationForms;
using Ifs.Fnd.Windows.Forms;
using PPJ.Runtime;
using PPJ.Runtime.Sql;
using PPJ.Runtime.Windows;

namespace Ifs.Application.Fndmig_
{
	
	/// <summary>
	/// </summary>
    [FndWindowRegistration("INTFACE_HEADER", "IntfaceHeader")]
    public partial class tbwIntfaceHeader : cTableWindow
    {
        #region Window Variables
        public SalString lsExportInfo = "";
        public SalString sFileLoc = "";
        public SalString sIntfaceName = "";
        public SalString sExportIntfaceNameDesc = "";
        public SalString sExportIntfaceName = "";
        public SalString sExecPlan = "";
        public SalBoolean bCommandOk = false;
        public SalString lsIn = "";
        public SalString lsReplication = "";
        public SalString sServProc = "";
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public tbwIntfaceHeader()
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
        public new static tbwIntfaceHeader FromHandle(SalWindowHandle handle)
        {
            return ((tbwIntfaceHeader)SalWindow.FromHandle(handle, typeof(tbwIntfaceHeader)));
        }
        #endregion

        #region Methods

        /// <summary>
        /// </summary>
        /// <returns>
        /// Applications should return FALSE to skip standard window startup logic (such
        /// as exectuing the "startup behavior" settings), or TRUE to allow standard logic.
        /// </returns>
        public new SalBoolean FrameStartupUser()
        {
            #region Actions
            using (new SalContext(this))
            {
                DbImmediate("SELECT " + cSessionManager.c_sDbPrefix + "Intface_Direction_API.Get_Client_Value(4)\r\n" +
                    "                                  INTO :i_hWndFrame.tbwIntfaceHeader.lsReplication FROM dual");
                return true;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="sFormName"></param>
        /// <returns></returns>
        public virtual SalBoolean PrepareLaunch(SalString sFormName)
        {
            #region Local Variables
            SalArray<SalString> sArray = new SalArray<SalString>();
            SalArray<SalWindowHandle> hWndArray = new SalArray<SalWindowHandle>();
            SalNumber nCurrentTableRow = 0;
            // Variables for printing report
            SalNumber nResultKey = 0;
            SalString sPrintMode = "";
            SalString sReservResult = "";
            // Window handles for AlertBox
            SalNumber nReturn = 0;
            SalNumber hBtnPrint = 0;
            SalNumber hBtnPreview = 0;
            SalNumber hBtnCancel = 0;
            SalArray<SalNumber> hButtonArray = new SalArray<SalNumber>();
            SalString lsReportAttr = "";
            SalString lsParamAttr = "";
            SalNumber nIndex = 0;
            SalNumber nPrintJobId = 0;
            SalArray<SalString> lsInstanceAttr = new SalArray<SalString>();
            SalNumber nRow = 0;
            SalNumber nPrint = 0;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                Sal.WaitCursor(true);
                if (sFormName == "Print Documentation")
                {
                    nRow = Sys.TBL_MinRow;
                    nPrint = 0;
                    sIntfaceName = Ifs.Fnd.ApplicationForms.Const.strNULL;
                    if (Sal.TblAnyRows(this, Sys.ROW_Selected, 0))
                    {
                        while (Sal.TblFindNextRow(this, ref nRow, Sys.ROW_Selected, 0) && !(i_bMethodAborted))
                        {
                            Sal.TblSetContext(this, nRow);
                            lsParamAttr = Ifs.Fnd.ApplicationForms.Const.strNULL;
                            sIntfaceName = colsIntfaceName.Text;
                            lsReportAttr = Ifs.Fnd.ApplicationForms.Int.PalAttrCreate("REPORT_ID", "INTFACE_DOCUMENTATION_REP");
                            lsParamAttr = lsParamAttr + Ifs.Fnd.ApplicationForms.Int.PalAttrCreate("INTFACE_IN", sIntfaceName);
                            lsParamAttr = lsParamAttr + Ifs.Fnd.ApplicationForms.Int.PalAttrCreate("PRINT_DOC_INFO", "N");
                            lsParamAttr = lsParamAttr + Ifs.Fnd.ApplicationForms.Int.PalAttrCreate("PRINT_HEADER", "Y");
                            lsParamAttr = lsParamAttr + Ifs.Fnd.ApplicationForms.Int.PalAttrCreate("PRINT_DETAIL", "Y");
                            lsParamAttr = lsParamAttr + Ifs.Fnd.ApplicationForms.Int.PalAttrCreate("PRINT_METH_LIST", "Y");
                            lsParamAttr = lsParamAttr + Ifs.Fnd.ApplicationForms.Int.PalAttrCreate("PRINT_MAP_VALUE", "Y");
                            // ! Print report for all received lines
                            Ifs.Fnd.ApplicationForms.Var.InfoService.ReportExecute(ref nPrintJobId, lsReportAttr, lsParamAttr, Ifs.Fnd.ApplicationForms.Const.strNULL);
                            lsInstanceAttr[nPrint] = Ifs.Fnd.ApplicationForms.Int.PalAttrCreate("RESULT_KEY", Ifs.Fnd.ApplicationForms.Int.PalAttrFormatNumber(nPrintJobId));
                            nPrint = nPrint + 1;
                        }
                    }
                    return Ifs.Fnd.ApplicationForms.Var.InfoService.ReportListPrint(Ifs.Fnd.ApplicationForms.Const.strNULL, lsInstanceAttr);
                }
                else if (sFormName == Pal.GetActiveInstanceName("frmIntfaceHeader"))
                {
                    sArray[0] = "INTFACE_NAME";
                    hWndArray[0] = colsIntfaceName;
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init(Pal.GetActiveInstanceName("tbwIntfaceHeader"), this, sArray, hWndArray);
                    if (CheckLaunchRepl())
                    {
                        SessionNavigate(Pal.GetActiveInstanceName("frmIntfaceReplStruct"));
                    }
                    else
                    {
                        SessionNavigate(Pal.GetActiveInstanceName("frmIntfaceHeader"));
                    }
                    Sal.WaitCursor(false);
                    return true;
                }
                else if (sFormName == Pal.GetActiveInstanceName("frmIntfaceStart"))
                {
                    sArray[0] = "INTFACE_NAME";
                    hWndArray[0] = colsIntfaceName;
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init(Pal.GetActiveInstanceName("tbwIntfaceHeader"), this, sArray, hWndArray);
                    SessionNavigate(Pal.GetActiveInstanceName("frmIntfaceStart"));
                    Sal.WaitCursor(false);
                    return true;
                }
                else if (sFormName == Pal.GetActiveInstanceName("tbwIntfaceJobHistHead"))
                {
                    sArray[0] = "INTFACE_NAME";
                    hWndArray[0] = colsIntfaceName;
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init(Pal.GetActiveInstanceName("tbwIntfaceHeader"), this, sArray, hWndArray);
                    SessionNavigate(Pal.GetActiveInstanceName("tbwIntfaceJobHistHead"));
                    Sal.WaitCursor(false);
                    return true;
                }
                else if (sFormName == "Export Job")
                {
                    lsExportInfo = "INTFACE_NAME=" + colsIntfaceName.Text;
                    colsExportJob.Text = "FNDMIG_EXPORT";
                    DbImmediate("SELECT " + cSessionManager.c_sDbPrefix + "Intface_File_Location_API.Encode(" + cSessionManager.c_sDbPrefix + "Intface_Header_API.Get_File_Location(:i_hWndFrame.tbwIntfaceHeader.colsExportJob))\r\n" +
                        "                                  INTO :i_hWndFrame.tbwIntfaceHeader.sFileLoc FROM dual");
                    sExecPlan = "ONLINE";
                    Sal.WaitCursor(true);
                    if (DbTransactionBegin(ref cSessionManager.c_hSql))
                    {
                        using (SignatureHints hints = SignatureHints.NewContext())
                        {
                            hints.Add("Intface_Header_API.Start_Job", System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                            if (DbPLSQLBlock(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "Intface_Header_API.Start_Job" + "( :i_hWndFrame.tbwIntfaceHeader.lsExportInfo,\r\n" +
                                "                               :i_hWndFrame.tbwIntfaceHeader.sExecPlan, :i_hWndFrame.tbwIntfaceHeader.colsExportJob)"))
                            {
                                DbTransactionEnd(cSessionManager.c_hSql);
                            }
                            else
                            {
                                bCommandOk = DbCommit(cSessionManager.c_hSql);
                                // gjohno 191199 Disabled so the rollback is not in function
                                // Call DbTransactionClear(c_hSql)
                                DbTransactionEnd(cSessionManager.c_hSql);
                                Sal.WaitCursor(false);
                                return false;
                            }
                        }
                        Sal.WaitCursor(false);
                        Ifs.Fnd.ApplicationForms.Int.AlertBox(lsExportInfo, Properties.Resources.ALERT_TitleEx, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                        if (sFileLoc != "1")
                        {
                            sArray[0] = "INTFACE_NAME";
                            hWndArray[0] = colsExportJob;
                            Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init(Pal.GetActiveInstanceName("tbwIntfaceHeader"), this, sArray, hWndArray);
                            SessionNavigate(Pal.GetActiveInstanceName("frmIntfaceStart"));
                        }
                        return true;
                    }
                }
                else if (sFormName == Pal.GetActiveInstanceName("tbwIntfaceServerProcesses"))
                {
                    // We can no longer query tbwIntfaceServerProcesses with INTFACE_NAME
                    // sArray[0] = "INTFACE_NAME";
                    sArray[0] = "Intface_Util_API.Get_Schedule_Intface_Name_(SCHEDULE_ID)";
                    hWndArray[0] = colsIntfaceName;
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init(Pal.GetActiveInstanceName("tbwIntfaceHeader"), this, sArray, hWndArray);
                    SessionNavigate(Pal.GetActiveInstanceName("tbwIntfaceServerProcesses"));
                    Sal.WaitCursor(false);
                    return true;
                }
                else
                {
                    Sal.WaitCursor(false);
                    return false;
                }
            }

            return false;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <param name="sMethod"></param>
        /// <returns></returns>
        public new SalNumber UserMethod(SalNumber nWhat, SalString sMethod)
        {
            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        if (sMethod == Pal.GetActiveInstanceName("frmIntfaceHeader"))
                        {
                            return Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("tbwIntfaceHeader")) && Sal.TblAnyRows(i_hWndFrame, Sys.ROW_Selected, 0);
                        }
                        if (sMethod == Pal.GetActiveInstanceName("frmIntfaceStart"))
                        {
                            return Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("frmIntfaceStart")) && Sal.TblAnyRows(i_hWndFrame, Sys.ROW_Selected, 0);
                        }
                        if (sMethod == Pal.GetActiveInstanceName("tbwIntfaceJobHistHead"))
                        {
                            return Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("tbwIntfaceJobHistHead")) && Sal.TblAnyRows(i_hWndFrame, Sys.ROW_Selected, 0);
                        }
                        if (sMethod == "Print Documentation")
                        {
                            return Sal.TblAnyRows(i_hWndFrame, Sys.ROW_Selected, 0) && Ifs.Fnd.ApplicationForms.Var.Security.IsViewAvailable("INTFACE_DOCUMENTATION_REP");
                        }
                        if (sMethod == "Export Job")
                        {
                            return Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("frmIntfaceStart")) && Sal.TblAnyRows(i_hWndFrame, Sys.ROW_Selected, 0);
                        }
                        if (sMethod == Pal.GetActiveInstanceName("tbwIntfaceServerProcesses"))
                        {
                            return GetServerProcFlag();
                        }
                        else
                        {
                            return false;
                        }
                        goto case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        if (sMethod == Pal.GetActiveInstanceName("frmIntfaceHeader"))
                        {
                            return PrepareLaunch(sMethod);
                        }
                        if (sMethod == Pal.GetActiveInstanceName("frmIntfaceStart"))
                        {
                            return PrepareLaunch(sMethod);
                        }
                        if (sMethod == Pal.GetActiveInstanceName("tbwIntfaceJobHistHead"))
                        {
                            return PrepareLaunch(sMethod);
                        }
                        if (sMethod == "Print Documentation")
                        {
                            return PrepareLaunch(sMethod);
                        }
                        if (sMethod == "Export Job")
                        {
                            return PrepareLaunch(sMethod);
                        }
                        if (sMethod == Pal.GetActiveInstanceName("tbwIntfaceServerProcesses"))
                        {
                            return PrepareLaunch(sMethod);
                        }
                        else
                        {
                            return false;
                        }
                        break;
                }
            }

            return false;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean CheckExpOk()
        {
            #region Local Variables
            SalNumber nMinRow = 0;
            SalNumber nMaxRow = 0;
            SalNumber nPosRow = 0;
            SalNumber nRow = 0;
            SalNumber nSelectedRow = 0;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                if (Sal.TblQueryScroll(i_hWndSelf, ref nPosRow, ref nMinRow, ref nMaxRow) && (Ifs.Fnd.ApplicationForms.Int.QualifiedItemNameGet(i_hWndSelf) == Pal.GetActiveInstanceName("tbwIntfaceHeader")) && !(Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceIsDirty,
                    Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0)))
                {
                    nSelectedRow = 0;
                    nRow = nPosRow;
                    while (nRow <= nMaxRow)
                    {
                        if (Sal.TblQueryRowFlags(i_hWndSelf, nRow, Sys.ROW_Selected))
                        {
                            nSelectedRow = nSelectedRow + 1;
                        }
                        nRow = nRow + 1;
                    }
                    if (nSelectedRow == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean CheckLaunchRepl()
        {
            #region Local Variables
            SalNumber nMinRow = 0;
            SalNumber nMaxRow = 0;
            SalNumber nPosRow = 0;
            SalNumber nRow = 0;
            SalNumber nSelectedRow = 0;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                if (Sal.TblQueryScroll(i_hWndSelf, ref nPosRow, ref nMinRow, ref nMaxRow) && (Ifs.Fnd.ApplicationForms.Int.QualifiedItemNameGet(i_hWndSelf) == Pal.GetActiveInstanceName("tbwIntfaceHeader")) && colIntfaceProceduresDirection.Text == lsReplication && !(Sal.SendMsg(this,
                    Ifs.Fnd.ApplicationForms.Const.PM_DataSourceIsDirty, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0)))
                {
                    nSelectedRow = 0;
                    nRow = nPosRow;
                    // While nRow <= nMaxRow
                    // If SalTblQueryRowFlags ( i_hWndSelf , nRow, ROW_Selected )
                    // Set nSelectedRow = nSelectedRow + 1
                    // Set nRow = nRow +1
                    // If nSelectedRow = 1
                    // Return TRUE
                    // Else
                    // Return FALSE
                    return true;
                }
                else
                {
                    return false;
                }
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber GetServerProcFlag()
        {
            #region Actions
            using (new SalContext(this))
            {
                DbImmediate("SELECT " + cSessionManager.c_sDbPrefix + "Intface_Repl_Maint_Util_API.Serv_Proc_Exists(:i_hWndFrame.tbwIntfaceHeader.colsIntfaceName)\r\n" +
                    "                                  INTO :i_hWndFrame.tbwIntfaceHeader.sServProc FROM dual");
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean CheckServProc()
        {
            #region Actions
            using (new SalContext(this))
            {
                GetServerProcFlag();
                if (sServProc == "TRUE")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            #endregion
        }
        #endregion

        #region Late Bind Methods

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalBoolean vrtFrameStartupUser()
        {
            return this.FrameStartupUser();
        }

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalNumber vrtUserMethod(SalNumber nWhat, SalString sMethod)
        {
            return this.UserMethod(nWhat, sMethod);
        }
        #endregion

        #region Event Handlers

        private void menuItem__Job_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            // TODO: Rewrite command event handler not to use UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            ((FndCommand)sender).Enabled = Sal.SendMsg(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, ((SalString)Pal.GetActiveInstanceName("frmIntfaceHeader")).ToHandle());
        }

        private void menuItem__Job_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            // TODO: Rewrite command event handler not to make use of UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            Sal.PostMsg(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, ((SalString)Pal.GetActiveInstanceName("frmIntfaceHeader")).ToHandle());
        }

        private void menuItem__Start_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            // TODO: Rewrite command event handler not to use UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            ((FndCommand)sender).Enabled = Sal.SendMsg(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, ((SalString)Pal.GetActiveInstanceName("frmIntfaceStart")).ToHandle());
        }

        private void menuItem__Start_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            // TODO: Rewrite command event handler not to make use of UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            Sal.PostMsg(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, ((SalString)Pal.GetActiveInstanceName("frmIntfaceStart")).ToHandle());
        }

        private void menuItem_Job_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            // TODO: Rewrite command event handler not to use UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            ((FndCommand)sender).Enabled = Sal.SendMsg(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, ((SalString)Pal.GetActiveInstanceName("tbwIntfaceJobHistHead")).ToHandle());
        }

        private void menuItem_Job_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            // TODO: Rewrite command event handler not to make use of UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            Sal.PostMsg(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, ((SalString)Pal.GetActiveInstanceName("tbwIntfaceJobHistHead")).ToHandle());
        }

        private void menuItem__Print_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            // TODO: Rewrite command event handler not to use UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            ((FndCommand)sender).Enabled = Sal.SendMsg(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, ((SalString)"Print Documentation").ToHandle());
        }

        private void menuItem__Print_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            // TODO: Rewrite command event handler not to make use of UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            Sal.PostMsg(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, ((SalString)"Print Documentation").ToHandle());
        }

        private void menuItem__Export_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = CheckExpOk();
        }

        private void menuItem__Export_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            // TODO: Rewrite command event handler not to make use of UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            Sal.PostMsg(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, ((SalString)"Export Job").ToHandle());
        }

        private void menuItem_Server_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = CheckServProc();
        }

        private void menuItem_Server_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            // TODO: Rewrite command event handler not to make use of UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            Sal.PostMsg(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, ((SalString)Pal.GetActiveInstanceName("tbwIntfaceServerProcesses")).ToHandle());
        }

        #endregion

    }
}
