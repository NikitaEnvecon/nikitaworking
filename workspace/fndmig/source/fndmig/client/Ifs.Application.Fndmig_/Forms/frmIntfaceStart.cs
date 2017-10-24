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
    [FndWindowRegistration("INTFACE_HEADER", "IntfaceJobHeader", FndWindowRegistrationFlags.HomePage)]
    [FndWindowRegistration("INTFACE_DETAIL", "IntfaceDetail", FndWindowRegistrationFlags.HomePage)]
    [FndWindowRegistration("INTFACE_JOB_DETAIL", "IntfaceJobDetail", FndWindowRegistrationFlags.HomePage)]
    public partial class frmIntfaceStart : cMasterDetailTabFormWindow
    {
        #region Window Variables
        public SalArray<SalString> sParamArray = new SalArray<SalString>();
        public SalString sInfo = "";
        public SalString sIntfaceName = "";
        public SalString sExecPlan = "";
        public SalString lsStatNoFile = "";
        public SalString lsLoaded = "";
        public SalString lsError = "";
        public SalString lsOk = "";
        public SalString lsOnServer = "";
        public SalString lsOnClient = "";
        public SalString lsLocNoFile = "";
        public SalString lsOut = "";
        public SalString lsConvert = "";
        public SalString sDirection = "";
        public SalNumber nMsgReturn = 0;
        public SalBoolean bNoError = false;
        public SalBoolean bDirection = false;
        public SalBoolean bJobOk = false;
        public SalBoolean bFileReady = false;
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public frmIntfaceStart()
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
        public new static frmIntfaceStart FromHandle(SalWindowHandle handle)
        {
            return ((frmIntfaceStart)SalWindow.FromHandle(handle, typeof(frmIntfaceStart)));
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
                DbImmediate("SELECT " + cSessionManager.c_sDbPrefix + "Intface_Job_Status_API.Get_Client_Value(0),\r\n" +
                    "                                            " + cSessionManager.c_sDbPrefix + "Intface_Job_Status_API.Get_Client_Value(1),\r\n" +
                    "                                            " + cSessionManager.c_sDbPrefix + "Intface_Job_Status_API.Get_Client_Value(2),\r\n" +
                    "                                            " + cSessionManager.c_sDbPrefix + "Intface_Job_Status_API.Get_Client_Value(3),\r\n" +
                    "                                            " + cSessionManager.c_sDbPrefix + "Intface_File_Location_API.Get_Client_Value(0),\r\n" +
                    "                                            " + cSessionManager.c_sDbPrefix + "Intface_File_Location_API.Get_Client_Value(1),\r\n" +
                    "                                            " + cSessionManager.c_sDbPrefix + "Intface_File_Location_API.Get_Client_Value(2),\r\n" +
                    "                                            " + cSessionManager.c_sDbPrefix + "Intface_Direction_API.Get_Client_Value(1),\r\n" +
                    "                                            " + cSessionManager.c_sDbPrefix + "Intface_Direction_API.Get_Client_Value(3)\r\n" +
                    "                                  INTO :i_hWndFrame.frmIntfaceStart.lsStatNoFile, :i_hWndFrame.frmIntfaceStart.lsLoaded,\r\n" +
                    "                                            :i_hWndFrame.frmIntfaceStart.lsError, :i_hWndFrame.frmIntfaceStart.lsOk, \r\n" +
                    "                                            :i_hWndFrame.frmIntfaceStart.lsOnServer, :i_hWndFrame.frmIntfaceStart.lsOnClient, \r\n" +
                    "                                            :i_hWndFrame.frmIntfaceStart.lsLocNoFile,\r\n" +
                    "                                            :i_hWndFrame.frmIntfaceStart.lsOut,\r\n" +
                    "                                            :i_hWndFrame.frmIntfaceStart.lsConvert FROM dual");
                // Insert new code here...
                return true;
            }
            #endregion
        }
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public override SalNumber vrtActivate(fcURL URL)
        {
            using (new SalContext(this))
            {
                if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.RecCountGet() > 0)
                {
                    Sal.WaitCursor(true);
                    if (InitFromTransferredData())
                    {
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();
                    }
                    Sal.WaitCursor(false);
                    return false;
                }
                else
                {
                    return base.Activate(URL);
                }
            }
        }

        /// <summary>
        /// Function to show window title/text
        /// </summary>
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalBoolean InvalidateTitle(SalNumber nWhat)
        {
            #region Actions
            using (new SalContext(this))
            {
                if (nWhat == Ifs.Fnd.ApplicationForms.Const.PM_DataItemPopulate || nWhat == Ifs.Fnd.ApplicationForms.Const.PM_DataItemSave)
                {
                    sParamArray[0] = SalString.FromHandle(cmbIntfaceName.EditDataItemValueGet());
                    Sal.SetWindowText(i_hWndFrame, Ifs.Fnd.ApplicationForms.Int.TranslateConstantWithParams(Properties.Resources.WH_frmIntfaceStart, sParamArray));
                    return true;
                }
                else if (nWhat == Ifs.Fnd.ApplicationForms.Const.PM_DataItemClear || nWhat == Ifs.Fnd.ApplicationForms.Const.PM_DataItemNew)
                {
                    Sal.SetWindowText(this, Properties.Resources.WH_frmIntfaceStartClear);
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
        /// <param name="nWhat"></param>
        /// <param name="sMethod"></param>
        /// <returns></returns>
        public new SalNumber UserMethod(SalNumber nWhat, SalString sMethod)
        {
            #region Local Variables
            SalString sName = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                if (sMethod == "UnpackFile")
                {
                    return UnpackFile(nWhat);
                }
                else if (sMethod == "CleanUp")
                {
                    return CleanUp(nWhat);
                }
                else if (sMethod == "Refresh")
                {
                    return Refresh(nWhat);
                }
                else if (sMethod == "StartOnline")
                {
                    return StartOnline(nWhat);
                }
                else if (sMethod == "RestartOnline")
                {
                    return RestartOnline(nWhat);
                }
                else if (sMethod == "ScheduleJob")
                {
                    return GetExecutePlan(nWhat);
                }
                return 0;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalBoolean StartOnline(SalNumber nWhat)
        {
            // Boolean: bCommandOk

            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        if (Sal.IsNull(dfsProcedureName))
                        {
                            return false;
                        }
                        else if (Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceIsDirty, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0))
                        {
                            return false;
                        }
                        // Only available when flag and status is: OnClient/Loaded,  OnServer/NoFile and OnServer/Loaded
                        // and when direction = Out
                        else if (dfsDirection.Text == lsOut)
                        {
                            return true;
                        }
                        // Inmu added AND dfsDirection != lsConvert
                        else if (dfsFileLocation.Text == lsLocNoFile && dfsDirection.Text != lsConvert)
                        {
                            return false;
                        }
                        else if (dfsStatus.Text == lsError || dfsStatus.Text == lsOk)
                        {
                            return false;
                        }
                        else if (dfsFileLocation.Text == lsOnClient && dfsStatus.Text == lsStatNoFile)
                        {
                            return false;
                        }
                        // Else If dfsFileLocation = lsOnServer AND dfsStatus = lsLoaded
                        // Return FALSE
                        else
                        {
                            return true;
                        }
                        goto case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        return ExecuteJob("Start");

                    default:
                        return false;
                }
            }

            return false;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalBoolean RestartOnline(SalNumber nWhat)
        {
            // Boolean: bCommandOk

            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        if (Sal.IsNull(dfsProcedureName))
                        {
                            return false;
                        }
                        else if (dfsStatus.Text != lsError)
                        {
                            return false;
                        }
                        else if (Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceIsDirty, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0))
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                        goto case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        return ExecuteJob("Restart");

                    default:
                        return false;
                }
            }

            return false;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="sTypeOfExecution"></param>
        /// <returns></returns>
        public virtual SalBoolean ExecuteJob(SalString sTypeOfExecution)
        {
            #region Local Variables
            SalBoolean bCommandOk = false;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                Sal.WaitCursor(true);
                Sal.GetWindowText(cmbIntfaceName, ref sIntfaceName, 30);
                if (sTypeOfExecution == "Start")
                {
                    sInfo = Ifs.Fnd.ApplicationForms.Const.strNULL;
                }
                else
                {
                    sInfo = "RESTART";
                }
                sExecPlan = "ONLINE";
                if (DbTransactionBegin(ref cSessionManager.c_hSql))
                {
                    using (SignatureHints hints = SignatureHints.NewContext())
                    {
                        hints.Add("Intface_Header_API.Start_Job", System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                        if (DbPLSQLBlock(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "Intface_Header_API.Start_Job" + "( :i_hWndFrame.frmIntfaceStart.sInfo, \r\n" +
                            "                                :i_hWndFrame.frmIntfaceStart.sExecPlan, :i_hWndFrame.frmIntfaceStart.sIntfaceName)"))
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
                }
                Sal.WaitCursor(false);
                Ifs.Fnd.ApplicationForms.Int.AlertBox(sInfo, Properties.Resources.ALERT_Title, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                Refresh(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
                sInfo = Ifs.Fnd.ApplicationForms.Const.strNULL;
                return true;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalBoolean GetExecutePlan(SalNumber nWhat)
        {
            // Boolean: bCommandOk

            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        if (Sal.IsNull(dfsProcedureName))
                        {
                            return false;
                        }
                        else if (dfsProcedureName.Text.Equals("EXCEL_MIGRATION"))
                        {
                            return false;
                        }
                        else if (Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceIsDirty, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0))
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                        goto case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        SetParameters();
                        Sal.GetWindowText(cmbIntfaceName, ref sIntfaceName, 30);
                        if (dlgExecSingel.ModalDialog(Ifs.Fnd.ApplicationForms.Int.Explorer.ExplorerForm, sIntfaceName, bNoError, bDirection, bJobOk, bFileReady, ref sInfo) == Sys.IDOK)
                        {
                            Ifs.Fnd.ApplicationForms.Int.AlertBox(sInfo, Properties.Resources.ALERT_Title, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                            Refresh(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
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
        public virtual SalNumber SetParameters()
        {
            #region Actions
            using (new SalContext(this))
            {
                bNoError = false;
                bDirection = false;
                bJobOk = false;
                bFileReady = false;
                if (dfsStatus.Text == this.lsError)
                {
                    bNoError = true;
                }
                if (this.dfsDirection.Text == this.lsOut)
                {
                    bDirection = true;
                }
                if (this.dfsStatus.Text == this.lsOk)
                {
                    bJobOk = true;
                }
                if (dfsFileLocation.Text == this.lsOnClient && dfsStatus.Text == this.lsStatNoFile)
                {
                    bFileReady = true;
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public new SalNumber DataSourceSaveMarkCommitted()
        {
            #region Actions
            using (new SalContext(this))
            {
                if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
                {
                    // Refresh after done RMB FileLoad from client
                    Ifs.Fnd.ApplicationForms.Int.PostMessage(this, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Sys.wParam, "Refresh");
                }
                return ((cDataSource)this).DataSourceSaveMarkCommitted();
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalBoolean UnpackFile(SalNumber nWhat)
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
                        if (Sal.IsNull(dfsProcedureName))
                        {
                            return false;
                        }
                        else if (Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceIsDirty, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0))
                        {
                            return false;
                        }
                        else if (dfsStatus.Text == lsError || dfsStatus.Text == lsOk)
                        {
                            return false;
                        }
                        else if (dfsFileLocation.Text == lsLocNoFile)
                        {
                            return false;
                        }
                        // Else If dfsStatus = lsLoaded AND dfsFileLocation = lsOnServer
                        // Return FALSE
                        else if (dfsStatus.Text == lsStatNoFile && dfsFileLocation.Text == lsOnClient)
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
                        Sal.GetWindowText(cmbIntfaceName, ref sIntfaceName, 30);
                        sInfo = "UNPACK";
                        sExecPlan = "ONLINE";
                        DbTransactionBegin(ref cSessionManager.c_hSql);
                        using (SignatureHints hints = SignatureHints.NewContext())
                        {
                            hints.Add("Intface_Header_API.Start_Job", System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                            if (DbPLSQLBlock(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "Intface_Header_API.Start_Job" + "( :i_hWndFrame.frmIntfaceStart.sInfo, \r\n" +
                                "                                :i_hWndFrame.frmIntfaceStart.sExecPlan, :i_hWndFrame.frmIntfaceStart.sIntfaceName)"))
                            {
                                // Call DbCommit(c_hSql)
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
                        Ifs.Fnd.ApplicationForms.Int.AlertBox(sInfo, Properties.Resources.ALERT_Title, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                        Refresh(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
                        sInfo = Ifs.Fnd.ApplicationForms.Const.strNULL;
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
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalBoolean CleanUp(SalNumber nWhat)
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
                        else if (Sal.IsNull(cmbIntfaceName))
                        {
                            return false;
                        }
                        else if (dfsStatus.Text == lsStatNoFile)
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                        goto case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        Sal.GetWindowText(cmbIntfaceName, ref sIntfaceName, 30);
                        if (Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_QuestionCleanUp, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Warning, Ifs.Fnd.ApplicationForms.Const.QUESTION_YesNo) == Sys.IDYES)
                        {
                            Sal.WaitCursor(true);
                            DbTransactionBegin(ref cSessionManager.c_hSql);
                            using (SignatureHints hints = SignatureHints.NewContext())
                            {
                                hints.Add("Intface_Job_Detail_API.Prepare_Details", System.Data.ParameterDirection.Input);
                                if (DbPLSQLBlock(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "Intface_Job_Detail_API.Prepare_Details" + "(:i_hWndFrame.frmIntfaceStart.sIntfaceName)"))
                                {
                                    // Call DbCommit(c_hSql)
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
                            // Repopulate selected item in master
                            cmbIntfaceName.RecordSelectionListSetSelect(cmbIntfaceName.GetSelectedItem());
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
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalBoolean Refresh(SalNumber nWhat)
        {
            // Boolean: bCommandOk

            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        // Should never occur
                        return false;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        cmbIntfaceName.RecordSelectionListSetSelect(cmbIntfaceName.GetSelectedItem());
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
        /// <returns></returns>
        public virtual void SetGlobalPath()
        {
            //setting the database context
            this.PLSQLContext.Set("INTFACE_SERVER_FILE_API.CURRENT_DIRECTORY_", this.dfsIntfacePath.Text);
        }
        #endregion

        #region Window Actions

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void cmbIntfaceName_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemClear:
                    this.cmbIntfaceName_OnPM_DataItemClear(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemSave:
                    this.cmbIntfaceName_OnPM_DataItemSave(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemPopulate:
                    this.cmbIntfaceName_OnPM_DataItemPopulate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemNew:
                    this.cmbIntfaceName_OnPM_DataItemNew(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemClear event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cmbIntfaceName_OnPM_DataItemClear(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.InvalidateTitle(Ifs.Fnd.ApplicationForms.Const.PM_DataItemClear);
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemClear, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemSave event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cmbIntfaceName_OnPM_DataItemSave(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.InvalidateTitle(Ifs.Fnd.ApplicationForms.Const.PM_DataItemSave);
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemSave, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemPopulate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cmbIntfaceName_OnPM_DataItemPopulate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemPopulate, Sys.wParam, Sys.lParam);
            this.InvalidateTitle(Ifs.Fnd.ApplicationForms.Const.PM_DataItemPopulate);
            e.Return = true;
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemNew event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cmbIntfaceName_OnPM_DataItemNew(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.InvalidateTitle(Ifs.Fnd.ApplicationForms.Const.PM_DataItemNew);
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemNew, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void dfsIntfacePath_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemPopulate:
                    this.dfsIntfacePath_OnPM_DataItemPopulate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemPopulate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsIntfacePath_OnPM_DataItemPopulate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemPopulate, Sys.wParam, Sys.lParam);
            this.SetGlobalPath();
            e.Return = true;
            return;
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
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.dfsProcedureName_OnPM_DataItemValidate(sender, e);
                    break;
            }
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
            e.Return = Sys.VALIDATE_Ok;
            return;
            #endregion
        }
        #endregion

        #region Late Bind Methods

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalNumber vrtDataSourceSaveMarkCommitted()
        {
            return this.DataSourceSaveMarkCommitted();
        }

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

        private void menuItem_Start_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            // TODO: Rewrite command event handler not to use UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            ((FndCommand)sender).Enabled = Sal.SendMsg(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, ((SalString)"StartOnline").ToHandle());
        }

        private void menuItem_Start_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            // TODO: Rewrite command event handler not to make use of UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            Sal.PostMsg(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, ((SalString)"StartOnline").ToHandle());
        }

        private void menuItem_Restart_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            // TODO: Rewrite command event handler not to use UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            ((FndCommand)sender).Enabled = Sal.SendMsg(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, ((SalString)"RestartOnline").ToHandle());
        }

        private void menuItem_Restart_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            // TODO: Rewrite command event handler not to make use of UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            Sal.PostMsg(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, ((SalString)"RestartOnline").ToHandle());
        }

        private void menuItem_Schedule_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            // TODO: Rewrite command event handler not to use UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            ((FndCommand)sender).Enabled = Sal.SendMsg(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, ((SalString)"ScheduleJob").ToHandle());
        }

        private void menuItem_Schedule_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            // TODO: Rewrite command event handler not to make use of UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            Sal.PostMsg(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, ((SalString)"ScheduleJob").ToHandle());
        }

        private void menuItem_Unpack_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            // TODO: Rewrite command event handler not to use UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            ((FndCommand)sender).Enabled = Sal.SendMsg(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, ((SalString)"UnpackFile").ToHandle());
        }

        private void menuItem_Unpack_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            // TODO: Rewrite command event handler not to make use of UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            Sal.PostMsg(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, ((SalString)"UnpackFile").ToHandle());
        }

        private void menuItem_Clean_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            // TODO: Rewrite command event handler not to use UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            ((FndCommand)sender).Enabled = Sal.SendMsg(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, ((SalString)"CleanUp").ToHandle());
        }

        private void menuItem_Clean_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            // TODO: Rewrite command event handler not to make use of UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            Sal.PostMsg(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, ((SalString)"CleanUp").ToHandle());
        }

        private void menuFrmMethods_menuJob_Execute(object sender, FndCommandExecuteEventArgs e)
        {
            #region Local Variables
            SalArray<SalString> sIntfaceName = new SalArray<SalString>();
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                Sal.WaitCursor(true);
                sIntfaceName[0] = cmbIntfaceName.Text;
                Ifs.Fnd.ApplicationForms.Var.DataTransfer.SourceNameSet(Pal.GetActiveInstanceName("frmIntfaceStart"));
                Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemAdd("INTFACE_NAME", sIntfaceName);
                SessionNavigate(Pal.GetActiveInstanceName("frmIntfaceHeader"));
                Sal.WaitCursor(false);
            }
            #endregion
        }

        private void menuFrmMethods_menuJob_Inquire(object sender, FndCommandInquireEventArgs e)
        {
            #region Action
            if (string.IsNullOrEmpty(cmbIntfaceName.Text))
            {
                ((FndCommand)sender).Enabled = false;
            }
            else
            {
                ((FndCommand)sender).Enabled = true;
            }
            #endregion
        }

        #endregion
    }
}
