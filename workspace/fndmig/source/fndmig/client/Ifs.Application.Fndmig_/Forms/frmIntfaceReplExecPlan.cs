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
using PPJ.Runtime.Vis;

namespace Ifs.Application.Fndmig_
{
	
	/// <summary>
	/// </summary>
    public partial class frmIntfaceReplExecPlan : cFormWindow
    {
        #region Window Variables
        public SalString sLookupValues = "";
        public SalArray<SalString> sValue = new SalArray<SalString>();
        public SalString sIntfaceName = "";
        public SalString sClientValue = "";
        public SalString sDbValue = "";
        public SalString sExecPlan = "";
        public SalString sInfo = "";
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public frmIntfaceReplExecPlan()
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
        public new static frmIntfaceReplExecPlan FromHandle(SalWindowHandle handle)
        {
            return ((frmIntfaceReplExecPlan)SalWindow.FromHandle(handle, typeof(frmIntfaceReplExecPlan)));
        }
        #endregion

        #region Methods

        /// <summary>
        /// Applications override the FrameStartupUser function to perform
        /// actions when a window has been started.
        /// COMMENTS:
        /// Common actions to perform at this time is populating the window
        /// with special data, changeing the window title etc.
        /// 
        /// The FrameStartupUser is called by the framework after a window
        /// has been complete created and is visible on the screen, but before
        /// the framework executes any startup behvior according to the properties
        /// for that window.
        /// 
        /// Note: If this function is overriden on a form or table window some code
        /// must be supplied in order to support the standard framework functionality
        /// DataTransfer.
        /// EXAMPLE:
        /// Function: FrameStartupUser
        /// 	Actions
        /// 		Call SetWindowTitle( )
        /// 		If DataTransfer.RecCountGet( ) > 0
        /// 			Call SalWaitCursor( TRUE )
        /// 			Call InitFromTransferredData( )
        /// 			Call DataTransfer.Reset( )
        /// 			Call SalWaitCursor( FALSE )
        /// 			Return FALSE
        /// 		Else
        /// 			Call SalWaitCursor( FALSE )
        /// 			Return TRUE
        /// 		Return TRUE
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
                LoadInvervals();
                // Insert new code here...
            }

            return false;
            #endregion
        }
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public override SalNumber vrtActivate(fcURL URL)
        {
            using (new SalContext(this))
            {
                SetRepeatedDaysEnable();
                SetRepeatedIntervalEnable();
                SetRepeatedTimeEnable();
            }
            return base.Activate(URL);
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber LoadInvervals()
        {
            #region Actions
            using (new SalContext(this))
            {
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("INTFACE_EXEC_INTERVAL_TYPE_API.Enumerate", System.Data.ParameterDirection.Output);
                    if (DbPLSQLBlock(cSessionManager.c_hSql, "&AO.INTFACE_EXEC_INTERVAL_TYPE_API.Enumerate(:i_hWndSelf.frmIntfaceReplExecPlan.sLookupValues)"))
                    {
                        sLookupValues.Tokenize(((SalNumber)31).ToCharacter(), ((SalNumber)31).ToCharacter(), sValue);
                        Vis.ListArrayPopulate(cmbInterval, sValue);
                        Sal.SetWindowText(cmbInterval, sValue[0]);
                        // Select the value that was populated before lookup
                        // If _LookupFormatPlSqlEnumerate( ':i_hWndSelf.cComboBox.__lsLookupValues', lsStmt )
                        // Set __lsLookupValues = strNULL
                        // If DbPLSQLBlock( c_hSql, lsStmt )
                        // Call SalStrTokenize( __lsLookupValues, SalNumberToChar(31), SalNumberToChar(31), sValue )
                        // Save currently populated value
                        // Set sOldValue =  MyValue
                        // Save edit flag
                        // Set bEditFlag = SalQueryFieldEdit( i_hWndSelf )
                        // Populate list
                        // Call SalListClear( i_hWndSelf )
                        // Call VisListArrayPopulate( i_hWndSelf, sValue )
                        // Select the value that was populated before lookup
                        // Call SalSetWindowText( i_hWndSelf, sOldValue )
                        // Restore edit flag
                        // Call SalSetFieldEdit( i_hWndSelf, bEditFlag )
                    }
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean OnRadioButtonClick()
        {
            #region Actions
            using (new SalContext(this))
            {
                SetRepeatedTimeEnable();
                SetRepeatedDaysEnable();
                SetRepeatedIntervalEnable();
                return true;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber SetRepeatedTimeEnable()
        {
            #region Actions
            using (new SalContext(this))
            {
                if (rbDaily.Checked || rbWeekly.Checked)
                {
                    Sal.EnableWindow(dfRepeatedTime);
                }
                else
                {
                    Sal.DisableWindow(dfRepeatedTime);
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber SetRepeatedDaysEnable()
        {
            #region Actions
            using (new SalContext(this))
            {
                if (rbWeekly.Checked)
                {
                    Sal.EnableWindow(cbMonday);
                    Sal.EnableWindow(cbTuesday);
                    Sal.EnableWindow(cbWednesday);
                    Sal.EnableWindow(cbThursday);
                    Sal.EnableWindow(cbFriday);
                    Sal.EnableWindow(cbSaturday);
                    Sal.EnableWindow(cbSunday);
                }
                else
                {
                    Sal.DisableWindow(cbMonday);
                    Sal.DisableWindow(cbTuesday);
                    Sal.DisableWindow(cbWednesday);
                    Sal.DisableWindow(cbThursday);
                    Sal.DisableWindow(cbFriday);
                    Sal.DisableWindow(cbSaturday);
                    Sal.DisableWindow(cbSunday);
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber SetRepeatedIntervalEnable()
        {
            #region Actions
            using (new SalContext(this))
            {
                if (rbDaily.Checked || rbWeekly.Checked)
                {
                    Sal.DisableWindow(dfnInterval);
                    Sal.DisableWindow(cmbInterval);
                }
                else
                {
                    Sal.EnableWindow(dfnInterval);
                    Sal.EnableWindow(cmbInterval);
                }
            }

            return 0;
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
                if (sMethod == "ExecutePlan")
                {
                    return ExecutePlan(nWhat, Ifs.Fnd.ApplicationForms.Const.strNULL);
                }
                if (sMethod == "Enable")
                {
                    Enable();
                    return 1;
                }
                if (sMethod == "Disable")
                {
                    Disable();
                    return 1;
                }
                if (sMethod == "ScheduleInsertProcedure")
                {
                    return ExecutePlan(nWhat, "I");
                }
                if (sMethod == "ScheduleUpdateProcedure")
                {
                    return ExecutePlan(nWhat, "U");
                }
                return 0;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <param name="sProcedure"></param>
        /// <returns></returns>
        public virtual SalBoolean ExecutePlan(SalNumber nWhat, SalString sProcedure)
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
                        if (Sal.IsNull(frmIntfaceReplStruct.FromHandle(i_hWndParent).dfsProcedureName))
                        {
                            return false;
                        }
                        else if (Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceIsDirty, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0))
                        {
                            return false;
                        }
                        else if (rbInterval.Checked && Sal.IsNull(dfnInterval))
                        {
                            return false;
                        }
                        else if (rbInterval.Checked && cmbInterval.Text == Ifs.Fnd.ApplicationForms.Const.strNULL)
                        {
                            return false;
                        }
                        else if ((rbDaily.Checked || rbWeekly.Checked) && Sal.IsNull(dfRepeatedTime))
                        {
                            return false;
                        }
                        else if (rbWeekly.Checked && !(cbMonday.Checked || cbTuesday.Checked || cbWednesday.Checked || cbThursday.Checked || cbFriday.Checked || cbSaturday.Checked || cbSunday.Checked))
                        {
                            return false;
                        }
                        if (sProcedure == Ifs.Fnd.ApplicationForms.Const.strNULL)
                        {
                            return frmIntfaceReplStruct.FromHandle(i_hWndParent).sDbMode == "3";
                        }
                        else
                        {
                            return frmIntfaceReplStruct.FromHandle(i_hWndParent).sDbMode == "1";
                        }
                        return true;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        Sal.WaitCursor(true);
                        Sal.GetWindowText(frmIntfaceReplStruct.FromHandle(i_hWndParent).ecmbIntfaceName, ref sIntfaceName, 30);
                        // Set sInfo = strNULL
                        sInfo = sProcedure;
                        if (DbTransactionBegin(ref cSessionManager.c_hSql))
                        {
                            ParseExecutionPlan();
                            using (SignatureHints hints = SignatureHints.NewContext())
                            {
                                hints.Add("Intface_Header_API.Start_Job", System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                                if (DbPLSQLBlock(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "Intface_Header_API.Start_Job" + "( :i_hWndFrame.frmIntfaceReplStruct.sInfo,\r\n" +
                                    "                                :i_hWndFrame.frmIntfaceReplExecPlan.sExecPlan, :i_hWndFrame.frmIntfaceReplExecPlan.sIntfaceName)"))
                                {
                                    Ifs.Fnd.ApplicationForms.Int.AlertBox(sInfo, Properties.Resources.ALERT_TitleEx, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                                    DbTransactionEnd(cSessionManager.c_hSql);
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
                        Sal.WaitCursor(false);
                        return true;

                    default:
                        return false;
                }
            }

            return false;
            #endregion
        }

        /// <summary>
        /// return the execution plan
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean ParseExecutionPlan()
        {
            // Receive String: sExecPlan

            #region Local Variables
            SalString sDate = "";
            SalString sTime = "";
            SalString sDays = "";
            SalString sIntervalSum = "";
            SalString sInterval = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                if (rbInterval.Checked)
                {
                    sIntervalSum = GetIntervalType();
                    sInterval = dfnInterval.Number.ToString(0);
                    sExecPlan = "SYSDATE+" + sInterval + "/" + sIntervalSum;
                    return true;
                }
                else if (rbDaily.Checked)
                {
                    if (GetRepeatedTime(ref sTime))
                    {
                        sExecPlan = "WEEKLY ON mon;tue;wed;thu;fri;sat;sun AT " + sTime;
                        return true;
                    }
                    Ifs.Fnd.ApplicationForms.Int.ErrorBox(Properties.Resources.FNDMIG_BatchExecInvalidTime);
                    return false;
                }
                else if (rbWeekly.Checked)
                {
                    if (GetRepeatedDays(ref sDays))
                    {
                        if (GetRepeatedTime(ref sTime))
                        {
                            sExecPlan = "WEEKLY ON " + sDays + " AT " + sTime;
                            return true;
                        }
                        else
                        {
                            Ifs.Fnd.ApplicationForms.Int.ErrorBox(Properties.Resources.FNDMIG_BatchExecInvalidTime);
                        }
                    }
                    else
                    {
                        Ifs.Fnd.ApplicationForms.Int.ErrorBox(Ifs.Fnd.ApplicationForms.Properties.Resources.__FNDINF_BatchExecInvalidDays);
                    }
                    return false;
                }
            }

            return false;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalString GetIntervalType()
        {
            #region Actions
            using (new SalContext(this))
            {
                return GetDbValue("INTFACE_EXEC_INTERVAL_TYPE_API", cmbInterval.Text);
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="sPackage"></param>
        /// <param name="sParamClientValue"></param>
        /// <returns></returns>
        public virtual SalString GetDbValue(SalString sPackage, SalString sParamClientValue)
        {
            #region Local Variables
            SalBoolean bResult = false;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                sClientValue = sParamClientValue;
                bResult = DbPLSQLBlock(cSessionManager.c_hSql, "\r\n" +
                    "BEGIN\r\n" +
                    "	:i_hWndFrame.frmIntfaceReplExecPlan.sDbValue := &AO." + sPackage + ".ENCODE(:i_hWndFrame.frmIntfaceReplExecPlan.sClientValue);\r\nEND;");
                return sDbValue;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="sReturn"></param>
        /// <returns></returns>
        public virtual SalBoolean GetRepeatedDays(ref SalString sReturn)
        {
            #region Local Variables
            SalString sDelim = "";
            SalString sValue = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                if (cbMonday.Checked)
                {
                    sValue = sValue + sDelim + "mon";
                    sDelim = ";";
                }
                if (cbTuesday.Checked)
                {
                    sValue = sValue + sDelim + "tue";
                    sDelim = ";";
                }
                if (cbWednesday.Checked)
                {
                    sValue = sValue + sDelim + "wed";
                    sDelim = ";";
                }
                if (cbThursday.Checked)
                {
                    sValue = sValue + sDelim + "thu";
                    sDelim = ";";
                }
                if (cbFriday.Checked)
                {
                    sValue = sValue + sDelim + "fri";
                    sDelim = ";";
                }
                if (cbSaturday.Checked)
                {
                    sValue = sValue + sDelim + "sat";
                    sDelim = ";";
                }
                if (cbSunday.Checked)
                {
                    sValue = sValue + sDelim + "sun";
                }
                sReturn = sValue;
                return sValue != Ifs.Fnd.ApplicationForms.Const.strNULL;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="sReturn"></param>
        /// <returns></returns>
        public virtual SalBoolean GetRepeatedTime(ref SalString sReturn)
        {
            #region Actions
            using (new SalContext(this))
            {
                if (Sal.IsNull(dfRepeatedTime))
                {
                    return false;
                }
                sReturn = dfRepeatedTime.DateTime.ToString("hhhh:mm");
                return true;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber Disable()
        {
            #region Actions
            using (new SalContext(this))
            {
                Sal.DisableWindow(cbMonday);
                Sal.DisableWindow(cbTuesday);
                Sal.DisableWindow(cbWednesday);
                Sal.DisableWindow(cbThursday);
                Sal.DisableWindow(cbFriday);
                Sal.DisableWindow(cbSaturday);
                Sal.DisableWindow(cbSunday);
                // Interval
                Sal.DisableWindow(dfnInterval);
                Sal.DisableWindow(cmbInterval);

                Sal.DisableWindow(dfRepeatedTime);

                Sal.DisableWindow(rbInterval);
                Sal.DisableWindow(rbDaily);
                Sal.DisableWindow(rbWeekly);
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber Enable()
        {
            #region Actions
            using (new SalContext(this))
            {
                Sal.EnableWindow(rbInterval);
                Sal.EnableWindow(rbDaily);
                Sal.EnableWindow(rbWeekly);

                SetRepeatedDaysEnable();
                SetRepeatedIntervalEnable();
                SetRepeatedTimeEnable();
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
        private void rbInterval_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_Click:
                    e.Handled = true;
                    this.OnRadioButtonClick();
                    break;
            }
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void rbDaily_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_Click:
                    e.Handled = true;
                    this.OnRadioButtonClick();
                    break;
            }
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void rbWeekly_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_Click:
                    e.Handled = true;
                    this.OnRadioButtonClick();
                    break;
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

        private void menuItem_Create_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            // TODO: Rewrite command event handler not to use UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            ((FndCommand)sender).Enabled = Sal.SendMsg(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, ((SalString)"ExecutePlan").ToHandle());
        }

        private void menuItem_Create_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            // TODO: Rewrite command event handler not to make use of UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            Sal.PostMsg(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, ((SalString)"ExecutePlan").ToHandle());
        }

        private void menuItem_Schedule_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            // TODO: Rewrite command event handler not to use UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            ((FndCommand)sender).Enabled = Sal.SendMsg(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, ((SalString)"ScheduleInsertProcedure").ToHandle());
        }

        private void menuItem_Schedule_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            // TODO: Rewrite command event handler not to make use of UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            Sal.PostMsg(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, ((SalString)"ScheduleInsertProcedure").ToHandle());
        }

        private void menuItem_Schedule_1_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            // TODO: Rewrite command event handler not to use UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            ((FndCommand)sender).Enabled = Sal.SendMsg(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, ((SalString)"ScheduleUpdateProcedure").ToHandle());
        }

        private void menuItem_Schedule_1_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            // TODO: Rewrite command event handler not to make use of UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            Sal.PostMsg(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, ((SalString)"ScheduleUpdateProcedure").ToHandle());
        }

        #endregion

    }
}
