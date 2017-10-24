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
// WAWILK 12-06-20 Bug 103432 - Modified method, ShowProcStmt 
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
	/// Method List
	/// </summary>
    [FndWindowRegistration("INTFACE_METHOD_LIST", "IntfaceMethodList")]
    [FndDynamicTabPage("frmIntfaceHeader.picTab", "METHODLIST", "tbwIntfaceMethodList", "TAB_NAME_MethodList", 0)]
    public partial class tbwIntfaceMethodList : cTableWindow
    {
        #region Window Variables
        public SalString sFromIntfaceName = "";
        public SalString sIntfaceName = "";
        public SalString sMethodType = "";
        public SalString lsProcStmt = "";
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public tbwIntfaceMethodList()
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
        public new static tbwIntfaceMethodList FromHandle(SalWindowHandle handle)
        {
            return ((tbwIntfaceMethodList)SalWindow.FromHandle(handle, typeof(tbwIntfaceMethodList)));
        }
        #endregion

        #region Methods

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public new SalNumber DataSourceSaveMarkCommitted()
        {
            #region Local Variables
            SalString sFormName = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                ((cTableManager)this).DataSourceSaveMarkCommitted();
                ((cTableManager)this).DataSourceRefresh(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
            }

            return 0;
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
            SalString sIntfaceName = "";
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
                if (sFormName == Pal.GetActiveInstanceName("tbwIntfaceMethodList"))
                {
                    sArray[0] = "INTFACE_NAME";
                    hWndArray[0] = colsIntfaceName;
                    sArray[1] = "EXECUTE_SEQ";
                    hWndArray[1] = colnExecuteSeq;
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init(Pal.GetActiveInstanceName("tbwIntfaceMethodList"), this, sArray, hWndArray);
                    cMessage Params = new cMessage();
                    Params.AddAttribute("EXECUTE_SEQ", colnExecuteSeq.Number);
                    Params.AddAttribute("VIEWNAME", colsViewName.Text);
                    SessionNavigateWithParams(Pal.GetActiveInstanceName("tbwIntfaceMethodListAttribute"), Params);
                    Sal.WaitCursor(false);
                    return true;
                }
                else
                {
                    Sal.WaitCursor(false);
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
            SalNumber nRow = 0;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        if (sMethod == Pal.GetActiveInstanceName("tbwIntfaceMethodList"))
                        {
                            // Return Security.IsDataSourceAvailable('tbwIntfaceMethodList') AND SalTblAnyRows( i_hWndFrame, ROW_Selected, 0 )
                            if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("tbwIntfaceMethodListAttribute")) && Sal.TblAnyRows(i_hWndFrame, Sys.ROW_Selected, 0)))
                            {
                                return false;
                            }
                            nRow = Sys.TBL_MinRow;
                            if (Sal.TblFindNextRow(i_hWndSelf, ref nRow, Sys.ROW_Selected, 0))
                            {
                                return !(Sal.TblFindNextRow(i_hWndSelf, ref nRow, Sys.ROW_Selected, 0));
                            }
                        }
                        if (sMethod == "ShowProcStmt")
                        {
                            if (Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceIsDirty, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0))
                            {
                                return false;
                            }
                            DbImmediate("SELECT " + cSessionManager.c_sDbPrefix + "Intface_Method_List_API.Get_Method_Type( :i_hWndFrame.tbwIntfaceMethodList.colsMethodName )\r\n" +
                                "                                  INTO :i_hWndFrame.tbwIntfaceMethodList.colsHiddenSqlStatement FROM dual");
                            if (tbwIntfaceMethodList.FromHandle(i_hWndFrame).colsHiddenSqlStatement.Text == "OTHER")
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        goto case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        if (sMethod == Pal.GetActiveInstanceName("tbwIntfaceMethodList"))
                        {
                            return PrepareLaunch(sMethod);
                        }
                        if (sMethod == "ShowProcStmt")
                        {
                            return ShowProcStmt(nWhat);
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
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalBoolean ShowProcStmt(SalNumber nWhat)
        {
            #region Local Variables
            SalBoolean bCommandOk = false;
            SalString sProcedureText = null;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    // Case METHOD_Inquire

                    // If SalSendMsg( hWndForm, PM_DataSourceIsDirty, METHOD_Inquire, 0)

                    // Return FALSE

                    // Call DbImmediate('SELECT '||c_sDbPrefix||'Intface_Method_List_API.Get_Method_Type( :i_hWndFrame.tbwIntfaceMethodList.colsMethodName )

                    //                                   INTO sMethodType FROM dual')

                    // If sMethodType = 'OTHER'

                    // Return TRUE

                    // Else

                    // Return FALSE

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        Sal.WaitCursor(true);
                        using (SignatureHints hints = SignatureHints.NewContext())
                        {
                            hints.Add("Intface_Method_List_API.Show_Dynamic_Proc_Stmt", System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                            if (DbPLSQLBlock(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "Intface_Method_List_API.Show_Dynamic_Proc_Stmt(:i_hWndFrame.tbwIntfaceMethodList.colsHiddenSqlStatement,\r\n" +
                                "                                :i_hWndFrame.tbwIntfaceMethodList.colsIntfaceName, :i_hWndFrame.tbwIntfaceMethodList.colnExecuteSeq)"))
                            {
                                sProcedureText = this.colsHiddenSqlStatement.GetText(33000);
                                dlgEditor.ModalDialog(this, ref sProcedureText, null, 0);
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
        #endregion

        #region Window Actions

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tbwIntfaceMethodList_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordDuplicate:
                    this.tbwIntfaceMethodList_OnPM_DataRecordDuplicate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataRecordDuplicate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwIntfaceMethodList_OnPM_DataRecordDuplicate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            switch (Sys.wParam)
            {
                case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                    e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordDuplicate, Sys.wParam, Sys.lParam);
                    return;

                case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                    Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordDuplicate, Sys.wParam, Sys.lParam);
                    break;
            }
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
        public override SalNumber vrtUserMethod(SalNumber nWhat, SalString sMethod)
        {
            return this.UserMethod(nWhat, sMethod);
        }
        #endregion

        #region Event Handlers

        private void menuItem__Method_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            // TODO: Rewrite command event handler not to use UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            ((FndCommand)sender).Enabled = Sal.SendMsg(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, ((SalString)Pal.GetActiveInstanceName("tbwIntfaceMethodList")).ToHandle());
        }

        private void menuItem__Method_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            // TODO: Rewrite command event handler not to make use of UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            Sal.PostMsg(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, ((SalString)Pal.GetActiveInstanceName("tbwIntfaceMethodList")).ToHandle());
        }

        private void menuItem_Show_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            // TODO: Rewrite command event handler not to use UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            ((FndCommand)sender).Enabled = Sal.SendMsg(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, ((SalString)"ShowProcStmt").ToHandle());
        }

        private void menuItem_Show_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            // TODO: Rewrite command event handler not to make use of UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            Sal.PostMsg(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, ((SalString)"ShowProcStmt").ToHandle());
        }

        #endregion

    }
}
