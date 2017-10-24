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
    public partial class frmIntfaceReplStruct : cMasterDetailTabFormWindow
    {
        #region Window Variables
        public SalString sDirection = "";
        public SalString lsConversion = "";
        public SalString sIntfaceName = "";
        public SalBoolean bCommandOk = false;
        public SalString sFormName = "";
        public SalString sProcOk = "";
        public SalString sTrigOk = "";
        public SalString sTrigEnabled = "";
        public SalString sTrigDisabled = "";
        public SalString sDbMode = "";
        public SalBoolean bNew = false;
        public SalBoolean bOk = false;
        public SalString sInfo = "";
        public SalString sUpPrivilege;
        public SalNumber nMessage = 0;
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public frmIntfaceReplStruct()
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
        public new static frmIntfaceReplStruct FromHandle(SalWindowHandle handle)
        {
            return ((frmIntfaceReplStruct)SalWindow.FromHandle(handle, typeof(frmIntfaceReplStruct)));
        }
        #endregion

        #region Methods

        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalBoolean ShowSqlStmt(SalNumber nWhat)
        {
            #region Local Variables
            SalBoolean bCommandOk = false;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        if (sDirection == lsConversion)
                        {
                            return true;
                        }
                        else if (Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceIsDirty, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0))
                        {
                            return false;
                        }
                        else
                        {
                            return false;
                        }
                        goto case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        Sal.WaitCursor(true);
                        Sal.GetWindowText(ecmbIntfaceName, ref sIntfaceName, 30);
                        DbTransactionBegin(ref cSessionManager.c_hSql);
                        using (SignatureHints hints = SignatureHints.NewContext())
                        {
                            hints.Add("Intface_Header_API.Show_Select_Stmt", System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.Input);
                            if (DbPLSQLBlock(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "Intface_Header_API.Show_Select_Stmt" + "(  :i_hWndFrame.frmIntfaceHeader.dflsHiddenSqlStatement,\r\n" +
                                "                                :i_hWndFrame.frmIntfaceHeader.sIntfaceName)"))
                            {
                                DbTransactionEnd(cSessionManager.c_hSql);
                            }
                            else
                            {
                                DbTransactionClear(cSessionManager.c_hSql);
                                Sal.WaitCursor(false);
                                return false;
                            }
                        }
                        Sal.WaitCursor(false);
                        Sal.SendMsg(frmIntfaceHeader.FromHandle(i_hWndFrame).dflsHiddenSqlStatement, Ifs.Fnd.ApplicationForms.Const.PM_DataItemEditor, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                        return true;

                    default:
                        return false;
                }
            }

            return false;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="bPopulateSingle"></param>
        /// <returns></returns>
        public SalBoolean DataSourcePopulateIt(SalBoolean bPopulateSingle)
        {
            #region Local Variables
            SalBoolean bOk = false;
            SalString sPrevDirection = "";
            SalString sPrevProcedureName = "";
            SalNumber nTabActive = 0;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                sPrevDirection = dfsDirection.Text;
                sPrevProcedureName = dfsProcedureName.Text;
                bOk = ((cDataSource)this).DataSourcePopulateIt(bPopulateSingle);
                if (bOk)
                {
                    bNew = false;
                    Sal.GetWindowText(ecmbIntfaceName, ref sIntfaceName, 30);
                    Refresh();
                    GetDbMode(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
                    EnableExecutionPlan();
                }
                Sal.SetFocus(ecmbIntfaceName);
                return bOk;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber Refresh()
        {
            #region Local Variables
            SalBoolean result = false;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                Sal.GetWindowText(ecmbIntfaceName, ref sIntfaceName, 30);
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("INTFACE_REPL_MAINT_UTIL_API.ARE_PACKAGES_VALID", System.Data.ParameterDirection.Input);
                    hints.Add("INTFACE_REPL_MAINT_UTIL_API.ARE_TRIGGERS_VALID", System.Data.ParameterDirection.Input);
                    hints.Add("INTFACE_REPL_MAINT_UTIL_API.ARE_TRIGGERS_ENABLED", System.Data.ParameterDirection.Input);
                    hints.Add("INTFACE_REPL_MAINT_UTIL_API.ARE_TRIGGERS_DISABLED", System.Data.ParameterDirection.Input);
                    result = DbPLSQLBlock(cSessionManager.c_hSql, "\r\n" +
                        "BEGIN\r\n" +
                        "	:i_hWndFrame.frmIntfaceReplStruct.sProcOk := &AO.INTFACE_REPL_MAINT_UTIL_API.ARE_PACKAGES_VALID(:i_hWndFrame.frmIntfaceReplStruct.sIntfaceName);\r\n" +
                        "	:i_hWndFrame.frmIntfaceReplStruct.sTrigOk := &AO.INTFACE_REPL_MAINT_UTIL_API.ARE_TRIGGERS_VALID(:i_hWndFrame.frmIntfaceReplStruct.sIntfaceName);\r\n" +
                        "	:i_hWndFrame.frmIntfaceReplStruct.sTrigEnabled := &AO.INTFACE_REPL_MAINT_UTIL_API.ARE_TRIGGERS_ENABLED(:i_hWndFrame.frmIntfaceReplStruct.sIntfaceName);\r\n" +
                        "	:i_hWndFrame.frmIntfaceReplStruct.sTrigDisabled := &AO.INTFACE_REPL_MAINT_UTIL_API.ARE_TRIGGERS_DISABLED(:i_hWndFrame.frmIntfaceReplStruct.sIntfaceName);\r\nEND;");
                }
                EnableExecutionPlan();
                return result;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalBoolean GetDbMode(SalNumber nWhat)
        {
            #region Local Variables
            SalBoolean result = false;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("INTFACE_MODE_API.ENCODE", System.Data.ParameterDirection.Input);
                    result = DbPLSQLBlock(cSessionManager.c_hSql, "\r\n" +
                        "BEGIN\r\n" +
                        "	:i_hWndFrame.frmIntfaceReplStruct.sDbMode := &AO.INTFACE_MODE_API.ENCODE(:i_hWndFrame.frmIntfaceReplStruct.cmbReplicationMode);\r\nEND;");
                }
                return result;
            }
            #endregion
        }

        /// <summary>
        /// The framework calls the UserMethod function on arrival of the
        /// PM_UserMethod message to perform an application defined method.
        /// Applications should override this function to implement the
        /// methods.
        /// COMMENTS:
        /// The nWhat and sMethod parameters correspont to the wParam and
        /// lParam parameters for the PM_UserMethod message received by
        /// the framework.
        /// EXAMPLE:
        /// Function: UserMethod
        /// 	Actions
        /// 		If sMethod = 'check credit'
        /// 			Return UM_CheckCredit( nWhat )
        /// 		If sMethod = 'update statistics'
        /// 			Return UM_UpdateStatistics( nWhat )
        /// 		Else
        /// 			Return FALSE
        /// </summary>
        /// <param name="nWhat">
        /// Standard method parameter
        /// Standard method parameter. Possible values are METHOD_Inquire, METHOD_Execute, METHOD_GetType
        /// </param>
        /// <param name="sMethod">
        /// Method name
        /// Name of the method to be executed.
        /// </param>
        /// <returns>
        /// When nWhat = METHOD_Inquire: the return value should be TRUE if the
        /// method is available (possible to execute), FALSE otherwise.
        /// When nWhat = METHOD_Execute: the return value should be TRUE if the method
        /// is completed sucessfully, FALSE otherwise.
        /// </returns>
        public new SalNumber UserMethod(SalNumber nWhat, SalString sMethod)
        {
            #region Actions
            using (new SalContext(this))
            {
                if (sMethod == "StartInsertProcedure")
                {
                    return StartInsertProcedure(nWhat);
                }
                if (sMethod == "StartUpdateProcedure")
                {
                    return StartUpdateProcedure(nWhat);
                }
                if (sMethod == "CompilePackages")
                {
                    return CompilePackages(nWhat);
                }
                if (sMethod == "CompileTriggers")
                {
                    return CompileTriggers(nWhat);
                }
                if (sMethod == "EnableTriggers")
                {
                    return EnableTriggers(nWhat);
                }
                if (sMethod == "DisableTriggers")
                {
                    return DisableTriggers(nWhat);
                }
                if (sMethod == "ShowLogTable")
                {
                    return ShowLogTable(nWhat);
                }
                if (sMethod == "ReplicationMode")
                {
                    GetDbMode(nWhat);
                    EnableExecutionPlan();
                }
                if (sMethod == "ShowServerProcesses")
                {
                    return ShowServerProcesses(nWhat);
                }
                if (sMethod == "ShowLogTable")
                {
                    return ShowLogTable(nWhat);
                }
                if (sMethod == "CopyIntface")
                {
                    return CopyIntface(nWhat);
                }
                if (sMethod == "CreateXsdFile")
                {
                    return CreateXsdFile(nWhat);
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalNumber CompilePackages(SalNumber nWhat)
        {
            #region Local Variables
            SalBoolean result = false;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        if (DataSourceIsDirty(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire))
                        {
                            return false;
                        }
                        return sTrigEnabled == "FALSE" && !(bNew);

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        Sal.WaitCursor(true);
                        DbTransactionBegin(ref cSessionManager.c_hSql);
                        Sal.GetWindowText(ecmbIntfaceName, ref sIntfaceName, 30);
                        using (SignatureHints hints = SignatureHints.NewContext())
                        {
                            hints.Add("INTFACE_REPL_PACKAGE_UTIL_API.COMPILE_PACKAGES", System.Data.ParameterDirection.Input);
                            result = DbPLSQLBlock(cSessionManager.c_hSql, "&AO.INTFACE_REPL_PACKAGE_UTIL_API.COMPILE_PACKAGES(:i_hWndFrame.frmIntfaceReplStruct.sIntfaceName)");
                        }
                        if (result)
                        {
                            Refresh();
                            DbTransactionEnd(cSessionManager.c_hSql);
                        }
                        else
                        {
                            DbTransactionClear(cSessionManager.c_hSql);
                        }
                        RefreshDbObjects();
                        Sal.WaitCursor(false);
                        return true;
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalNumber CompileTriggers(SalNumber nWhat)
        {
            #region Local Variables
            SalBoolean result = false;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        if (DataSourceIsDirty(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire))
                        {
                            return false;
                        }
                        return sDbMode != "1" && sProcOk == "TRUE" && sTrigEnabled == "FALSE" && !(bNew);

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        Sal.WaitCursor(true);
                        DbTransactionBegin(ref cSessionManager.c_hSql);
                        Sal.GetWindowText(ecmbIntfaceName, ref sIntfaceName, 30);
                        using (SignatureHints hints = SignatureHints.NewContext())
                        {
                            hints.Add("INTFACE_REPL_TRIGGERS_UTIL_API.COMPILE_TRIGGERS", System.Data.ParameterDirection.Input);
                            result = DbPLSQLBlock(cSessionManager.c_hSql, "&AO.INTFACE_REPL_TRIGGERS_UTIL_API.COMPILE_TRIGGERS(:i_hWndFrame.frmIntfaceReplStruct.sIntfaceName)");
                        }
                        if (result)
                        {
                            Refresh();
                            DbTransactionEnd(cSessionManager.c_hSql);
                        }
                        else
                        {
                            DbTransactionClear(cSessionManager.c_hSql);
                        }
                        RefreshDbObjects();
                        Sal.WaitCursor(false);
                        return true;
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalNumber EnableTriggers(SalNumber nWhat)
        {
            #region Local Variables
            SalBoolean result = false;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        if (DataSourceIsDirty(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire))
                        {
                            return false;
                        }
                        return sDbMode != "1" && sTrigOk == "TRUE" && sProcOk == "TRUE" && sTrigDisabled == "TRUE";

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        Sal.WaitCursor(true);
                        DbTransactionBegin(ref cSessionManager.c_hSql);
                        Sal.GetWindowText(ecmbIntfaceName, ref sIntfaceName, 30);
                        using (SignatureHints hints = SignatureHints.NewContext())
                        {
                            hints.Add("INTFACE_REPL_TRIGGERS_UTIL_API.SWITCH_ALL_TRIGGERS", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                            result = DbPLSQLBlock(cSessionManager.c_hSql, "&AO.INTFACE_REPL_TRIGGERS_UTIL_API.SWITCH_ALL_TRIGGERS(:i_hWndFrame.frmIntfaceReplStruct.sIntfaceName, 'ON')");
                        }
                        if (result)
                        {
                            Refresh();
                            DbTransactionEnd(cSessionManager.c_hSql);
                        }
                        else
                        {
                            DbTransactionClear(cSessionManager.c_hSql);
                        }
                        RefreshDbObjects();
                        Sal.WaitCursor(false);
                        return true;
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalNumber DisableTriggers(SalNumber nWhat)
        {
            #region Local Variables
            SalBoolean result = false;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        if (DataSourceIsDirty(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire))
                        {
                            return false;
                        }
                        return sDbMode != "1" && sTrigOk == "TRUE" && sTrigEnabled == "TRUE";

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        Sal.WaitCursor(true);
                        DbTransactionBegin(ref cSessionManager.c_hSql);
                        Sal.GetWindowText(ecmbIntfaceName, ref sIntfaceName, 30);
                        using (SignatureHints hints = SignatureHints.NewContext())
                        {
                            hints.Add("INTFACE_REPL_TRIGGERS_UTIL_API.SWITCH_ALL_TRIGGERS", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                            result = DbPLSQLBlock(cSessionManager.c_hSql, "&AO.INTFACE_REPL_TRIGGERS_UTIL_API.SWITCH_ALL_TRIGGERS(:i_hWndFrame.frmIntfaceReplStruct.sIntfaceName, 'OFF')");
                        }
                        if (result)
                        {
                            Refresh();
                            DbTransactionEnd(cSessionManager.c_hSql);
                        }
                        else
                        {
                            DbTransactionClear(cSessionManager.c_hSql);
                        }
                        RefreshDbObjects();
                        Sal.WaitCursor(false);
                        return true;
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalNumber StartInsertProcedure(SalNumber nWhat)
        {
            #region Local Variables
            SalBoolean result = false;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        if (DataSourceIsDirty(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire))
                        {
                            return false;
                        }
                        return sDbMode == "1" && sProcOk == "TRUE";

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        return StartProcedure("I");
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalNumber StartUpdateProcedure(SalNumber nWhat)
        {
            #region Local Variables
            SalBoolean result = false;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        if (DataSourceIsDirty(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire))
                        {
                            return false;
                        }
                        return sDbMode == "1" && sProcOk == "TRUE";

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        return StartProcedure("U");
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber EnableExecutionPlan()
        {
            #region Local Variables
            SalBoolean bEnable = false;
            SalWindowHandle hWndTab = SalWindowHandle.Null;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                bEnable = (sDbMode == "3" && sProcOk == "TRUE" && sTrigOk == "TRUE") || (sDbMode == "1" && sProcOk == "TRUE");
                picTab.Enable(picTab.FindName("ExecutionPlan"), bEnable);
                hWndTab = TabAttachedWindowHandleGet(picTab.FindName("ExecutionPlan"));
                if (bEnable)
                {
                    Sal.SendMsg(hWndTab, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, ((SalString)"Enable").ToHandle());
                }
                else
                {
                    Sal.SendMsg(hWndTab, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, ((SalString)"Disable").ToHandle());
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalNumber ShowLogTable(SalNumber nWhat)
        {
            #region Local Variables
            SalArray<SalString> sArray = new SalArray<SalString>();
            SalArray<SalWindowHandle> hWndArray = new SalArray<SalWindowHandle>();
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire)
                {
                    return true;
                }
                if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
                {
                    Sal.WaitCursor(true);
                    sArray[0] = "INTFACE_NAME";
                    hWndArray[0] = ecmbIntfaceName;
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init(Pal.GetActiveInstanceName("tbwIntfaceReplOutLog"), this, sArray, hWndArray);
                    SessionNavigate(Pal.GetActiveInstanceName("tbwIntfaceReplOutLog"));
                    Sal.WaitCursor(false);
                    return true;
                }
                return false;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalNumber CreateXsdFile(SalNumber nWhat)
        {
            #region Local Variables
            SalArray<SalString> sArray = new SalArray<SalString>();
            SalArray<SalWindowHandle> hWndArray = new SalArray<SalWindowHandle>();
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire)
                {
                    return true;
                }
                if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
                {
                    Sal.GetWindowText(ecmbIntfaceName, ref sIntfaceName, 30);
                    if (DbTransactionBegin(ref cSessionManager.c_hSql))
                    {
                        using (SignatureHints hints = SignatureHints.NewContext())
                        {
                            hints.Add("Intface_Xsd_Util_API.Create_Xsd_Client", System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.Input);
                            if (DbPLSQLBlock(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "Intface_Xsd_Util_API.Create_Xsd_Client" + "( :i_hWndFrame.frmIntfaceReplStruct.sInfo, \r\n" +
                                "	:i_hWndFrame.frmIntfaceReplStruct.sIntfaceName)"))
                            {
                                DbTransactionEnd(cSessionManager.c_hSql);
                                Ifs.Fnd.ApplicationForms.Int.AlertBox(sInfo, Properties.Resources.ALERT_TitleXsdCreated, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                                Sal.WaitCursor(true);
                                sArray[0] = "INTFACE_NAME";
                                hWndArray[0] = ecmbIntfaceName;
                                Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init(Pal.GetActiveInstanceName("frmIntfaceReplStruct"), this, sArray, hWndArray);
                                SessionNavigate(Pal.GetActiveInstanceName("frmIntfaceStart"));
                                Sal.WaitCursor(false);
                                return true;
                            }
                            else
                            {
                                bCommandOk = DbCommit(cSessionManager.c_hSql);
                                DbTransactionEnd(cSessionManager.c_hSql);
                                Sal.WaitCursor(false);
                                return false;
                            }
                        }
                    }
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalNumber ShowServerProcesses(SalNumber nWhat)
        {
            #region Local Variables
            SalArray<SalString> sArray = new SalArray<SalString>();
            SalArray<SalWindowHandle> hWndArray = new SalArray<SalWindowHandle>();
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire)
                {
                    return true;
                }
                if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
                {
                    Sal.WaitCursor(true);
                    // We can no longer query for the INTFACE_NAME
                    // sArray[0] = "INTFACE_NAME";
                    sArray[0] = "Intface_Util_API.Get_Schedule_Intface_Name_(SCHEDULE_ID)";
                    hWndArray[0] = ecmbIntfaceName;
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init(Pal.GetActiveInstanceName("tbwIntfaceServerProcesses"), this, sArray, hWndArray);
                    SessionNavigate(Pal.GetActiveInstanceName("tbwIntfaceServerProcesses"));
                    Sal.WaitCursor(false);
                    return true;
                }
                return false;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber RefreshDbObjects()
        {
            #region Actions
            using (new SalContext(this))
            {
                Sal.SendMsg(tblObjects, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceRefresh, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalBoolean CopyIntface(SalNumber nWhat)
        {
            #region Local Variables
            SalBoolean bCommandOk = false;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        if (Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceIsDirty, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0))
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                        goto case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        Sal.WaitCursor(true);
                        Sal.GetWindowText(ecmbIntfaceName, ref sIntfaceName, 30);
                        if (Ifs.Fnd.ApplicationForms.Int.InputDialog(Properties.Resources.TEXT_IntfaceCopyTitle, Properties.Resources.TEXT_IntfaceCopyLabel, ref sInfo))
                        {
                            DbTransactionBegin(ref cSessionManager.c_hSql);
                            sInfo = sInfo.ToUpper();
                            Sal.GetWindowText(ecmbIntfaceName, ref sIntfaceName, 30);
                            using (SignatureHints hints = SignatureHints.NewContext())
                            {
                                hints.Add("Intface_Header_API.Copy_Intface", System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.Input);
                                if (DbPLSQLBlock(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "Intface_Header_API.Copy_Intface" + "(  :i_hWndFrame.frmIntfaceReplStruct.sInfo,\r\n" +
                                    "                                :i_hWndFrame.frmIntfaceReplStruct.sIntfaceName)"))
                                {
                                    DbTransactionEnd(cSessionManager.c_hSql);
                                }
                                else
                                {
                                    DbTransactionClear(cSessionManager.c_hSql);
                                    Sal.WaitCursor(false);
                                    return false;
                                }
                            }
                            Sal.WaitCursor(false);
                            Ifs.Fnd.ApplicationForms.Int.AlertBox(sInfo, Properties.Resources.ALERT_TitleCopyIntface, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                            Refresh();
                            sInfo = Ifs.Fnd.ApplicationForms.Const.strNULL;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                        break;

                    default:
                        return false;
                }
            }

            return false;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual void SetGlobalProc()
        {
            //setting the database context
            this.PLSQLContext.Set("INTFACE_RULES_API.INTF_PROCEDURE_NAME_", this.dfsProcedureName.Text);
        }

        /// <summary>
        /// </summary>
        /// <param name="sProcedure"></param>
        /// <returns></returns>
        public virtual SalNumber StartProcedure(SalString sProcedure)
        {
            #region Actions
            using (new SalContext(this))
            {
                sInfo = sProcedure;
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("Intface_Header_API.Start_Job", System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                    if (DbPLSQLBlock(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "Intface_Header_API.Start_Job" + "( :i_hWndFrame.frmIntfaceReplStruct.sInfo,\r\n" +
                        "                              'ONLINE', :i_hWndFrame.frmIntfaceReplStruct.sIntfaceName)"))
                    {
                        DbTransactionEnd(cSessionManager.c_hSql);
                        Ifs.Fnd.ApplicationForms.Int.AlertBox(sInfo, Properties.Resources.ALERT_TitleEx, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                        return true;
                    }
                    else
                    {
                        DbCommit(cSessionManager.c_hSql);
                        DbTransactionEnd(cSessionManager.c_hSql);
                        Sal.WaitCursor(false);
                        return false;
                    }
                }
            }
            #endregion
        }

        /// <summary>
        /// Returns if the current user is allowed to add Migration Jobs
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean ChangeAllowed()
        {
            #region Actions
            //If already have a value use it
            if (!string.IsNullOrEmpty(sUpPrivilege))
            {
                return sUpPrivilege.Equals("TRUE");
            }
            if (DbPLSQLBlock(cSessionManager.c_hSql, ":i_hWndFrame.frmIntfaceHeader.sUpPrivilege := &AO.Intface_User_API.Has_Update_Privilege"))
            {
                return sUpPrivilege.Equals("TRUE");
            }
            else
            {
                return false;
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
        private void frmIntfaceReplStruct_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                // Insert new code here...

                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave:
                    this.frmIntfaceReplStruct_OnPM_DataSourceSave(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew:
                    this.frmIntfaceReplStruct_OnPM_DataRecordNew(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_Create event handler.
        /// </summary>
        /// <param name="message"></param>
        // Insert new code here...

        /// <summary>
        /// PM_DataSourceSave event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmIntfaceReplStruct_OnPM_DataSourceSave(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.bOk = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Sys.wParam, Sys.lParam);
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute && this.bOk)
            {
                Sal.SendMsg(this.tblStructure, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceRefresh, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                this.Refresh();
                this.GetDbMode(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
                this.bNew = false;
            }
            e.Return = this.bOk;
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataRecordNew event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmIntfaceReplStruct_OnPM_DataRecordNew(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.bOk = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew, Sys.wParam, Sys.lParam);
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute && this.bOk)
            {
                this.sProcOk = "FALSE";
                this.bNew = true;
                this.sTrigOk = "FALSE";
                this.sTrigEnabled = "FALSE";
                this.sTrigDisabled = "FALSE";
            }
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire && this.bOk)
            {
                if (!ChangeAllowed())
                {
                    e.Return = false;
                    return;
                }
            }
            e.Return = this.bOk;
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void ecmbIntfaceName_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_FieldEdit:
                    this.ecmbIntfaceName_OnSAM_FieldEdit(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_FieldEdit event handler.
        /// </summary>
        /// <param name="message"></param>
        private void ecmbIntfaceName_OnSAM_FieldEdit(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Ifs.Fnd.ApplicationForms.Var.Console.Add("Inne i SAM FieldEdit");
            Sal.SetFieldEdit(this.ecmbIntfaceName, true);
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void cmbReplicationMode_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_Click:
                    this.cmbReplicationMode_OnSAM_Click(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_Click event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cmbReplicationMode_OnSAM_Click(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, ((SalString)"ReplicationMode").ToHandle());
            Sal.SendClassMessage(Sys.SAM_Click, Sys.wParam, Sys.lParam);
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void dfsProcedureName_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemPopulate:
                    this.dfsProcedureName_OnPM_DataItemPopulate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.dfsProcedureName_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemPopulate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsProcedureName_OnPM_DataItemPopulate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemPopulate, Sys.wParam, Sys.lParam);
            this.SetGlobalProc();
            e.Return = true;
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsProcedureName_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam) == Sys.VALIDATE_Cancel)
            {
                e.Return = Sys.VALIDATE_Cancel;
                return;
            }
            Ifs.Fnd.ApplicationForms.Int.PostMessage(this.dfsDirection, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, 0, SalString.Null);
            this.SetGlobalProc();
            e.Return = Sys.VALIDATE_Ok;
            return;
            #endregion
        }
        #endregion

        #region Late Bind Methods

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalBoolean vrtDataSourcePopulateIt(SalNumber nParam)
        {
            return this.DataSourcePopulateIt(nParam);
        }

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalNumber vrtUserMethod(SalNumber nWhat, SalString sMethod)
        {
            return this.UserMethod(nWhat, sMethod);
        }
        #endregion

        #region ChildTable - tblStructure

        #region Methods

        /// <summary>
        /// </summary>
        protected virtual bool DefineColumns(SalNumber nWhat)
        {
            switch (nWhat)
            {
                case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                    return (!Sal.IsNull(tblStructure_colsIntfaceName) &&
                        !DataSourceIsDirty(nWhat) &&
                        tblStructure.vrtDataSourceCreateWindow(nWhat, Pal.GetActiveInstanceName("tbwIntfaceReplStructCols")));

                case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                    SalArray<SalString> sArray = new SalArray<SalString>();
                    SalArray<SalWindowHandle> hWndArray = new SalArray<SalWindowHandle>();

                    sArray[0] = "INTFACE_NAME";
                    hWndArray[0] = tblStructure_colsIntfaceName;
                    sArray[1] = "STRUCTURE_SEQ";
                    hWndArray[1] = tblStructure_colnStructureSeq;
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init(Pal.GetActiveInstanceName("tbwIntfaceReplStructCols"), tblStructure, sArray, hWndArray);
                    cMessage Params = new cMessage();
                    Params.AddAttribute("VIEWNAME", tblStructure_colsViewName.Text);
                    return SessionNavigateWithParams(Pal.GetActiveInstanceName("tbwIntfaceReplStructCols"), Params);
            }
            return false;
        }

        #endregion

        #endregion

        #region ChildTable - tblObjects

        #region Methods

        /// <summary>
        /// </summary>
        protected virtual bool ShowSourceText(SalNumber nWhat)
        {
            switch (nWhat)
            {
                case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                    return (!Sal.IsNull(tblObjects_colsObjectName));

                case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                    Sal.WaitCursor(true);
                    if (DbPLSQLBlock("&AO.INTFACE_REPL_MAINT_UTIL_API.Show_Source_Text({0} INOUT, {1} IN)", dflsHiddenSqlStatement.QualifiedBindName, tblObjects_colsObjectName.QualifiedBindName))
                        dflsHiddenSqlStatement.vrtEditLaunchEditor();
                    Sal.WaitCursor(false);
                    return true;

            }
            return false;
        }

        #endregion

        #endregion

        #region Event Handlers

        private void menuItem__Copy_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            // TODO: Rewrite command event handler not to use UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            ((FndCommand)sender).Enabled = Sal.SendMsg(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, ((SalString)"CopyIntface").ToHandle());
        }

        private void menuItem__Copy_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            // TODO: Rewrite command event handler not to make use of UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            Ifs.Fnd.ApplicationForms.Int.PostMessage(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, "CopyIntface");
        }

        private void menuItem_Start_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            // TODO: Rewrite command event handler not to use UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            ((FndCommand)sender).Enabled = Sal.SendMsg(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, ((SalString)"StartInsertProcedure").ToHandle());
        }

        private void menuItem_Start_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            // TODO: Rewrite command event handler not to make use of UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            Sal.PostMsg(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, ((SalString)"StartInsertProcedure").ToHandle());
        }

        private void menuItem_Start_1_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            // TODO: Rewrite command event handler not to use UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            ((FndCommand)sender).Enabled = Sal.SendMsg(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, ((SalString)"StartUpdateProcedure").ToHandle());
        }

        private void menuItem_Start_1_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            // TODO: Rewrite command event handler not to make use of UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            Sal.PostMsg(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, ((SalString)"StartUpdateProcedure").ToHandle());
        }

        private void menuItem_Compile_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            // TODO: Rewrite command event handler not to use UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            ((FndCommand)sender).Enabled = Sal.SendMsg(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, ((SalString)"CompilePackages").ToHandle());
        }

        private void menuItem_Compile_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            // TODO: Rewrite command event handler not to make use of UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            Sal.PostMsg(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, ((SalString)"CompilePackages").ToHandle());
        }

        private void menuItem_Compile_1_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            // TODO: Rewrite command event handler not to use UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            ((FndCommand)sender).Enabled = Sal.SendMsg(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, ((SalString)"CompileTriggers").ToHandle());
        }

        private void menuItem_Compile_1_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            // TODO: Rewrite command event handler not to make use of UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            Sal.PostMsg(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, ((SalString)"CompileTriggers").ToHandle());
        }

        private void menuItem__Enable_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            // TODO: Rewrite command event handler not to use UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            ((FndCommand)sender).Enabled = Sal.SendMsg(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, ((SalString)"EnableTriggers").ToHandle());
        }

        private void menuItem__Enable_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            // TODO: Rewrite command event handler not to make use of UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            Sal.PostMsg(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, ((SalString)"EnableTriggers").ToHandle());
        }

        private void menuItem__Disable_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            // TODO: Rewrite command event handler not to use UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            ((FndCommand)sender).Enabled = Sal.SendMsg(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, ((SalString)"DisableTriggers").ToHandle());
        }

        private void menuItem__Disable_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            // TODO: Rewrite command event handler not to make use of UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            Sal.PostMsg(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, ((SalString)"DisableTriggers").ToHandle());
        }

        private void menuItem_Show_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            // TODO: Rewrite command event handler not to use UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            ((FndCommand)sender).Enabled = Sal.SendMsg(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, ((SalString)"ShowServerProcesses").ToHandle());
        }

        private void menuItem_Show_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            // TODO: Rewrite command event handler not to make use of UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            Sal.PostMsg(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, ((SalString)"ShowServerProcesses").ToHandle());
        }

        private void menuItem_Show_1_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            // TODO: Rewrite command event handler not to use UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            ((FndCommand)sender).Enabled = Sal.SendMsg(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, ((SalString)"ShowLogTable").ToHandle());
        }

        private void menuItem_Show_1_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            // TODO: Rewrite command event handler not to make use of UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            Sal.PostMsg(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, ((SalString)"ShowLogTable").ToHandle());
        }

        private void menuItem_Create_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            // TODO: Rewrite command event handler not to use UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            ((FndCommand)sender).Enabled = Sal.SendMsg(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, ((SalString)"CreateXsdFile").ToHandle());
        }

        private void menuItem_Create_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            // TODO: Rewrite command event handler not to make use of UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            Sal.PostMsg(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, ((SalString)"CreateXsdFile").ToHandle());
        }

        private void cmdShowSourceText_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = ShowSourceText(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void cmdShowSourceText_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            ShowSourceText(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void cmdDefineColumns_Inquire(object sender, FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = DefineColumns(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void cmdDefineColumns_Execute(object sender, FndCommandExecuteEventArgs e)
        {
            DefineColumns(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        #endregion
    }
}
