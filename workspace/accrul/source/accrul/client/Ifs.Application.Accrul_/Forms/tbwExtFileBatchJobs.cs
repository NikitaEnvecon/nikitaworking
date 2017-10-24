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
    [FndWindowRegistration("EXT_FILE_BATCH_JOBS", "ExtFileBatchParam", FndWindowRegistrationFlags.HomePage)]
    public partial class tbwExtFileBatchJobs : cTableWindowFinBase
    {
        #region Window Variables
        public SalString lsParam = "";
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public tbwExtFileBatchJobs()
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
        public new static tbwExtFileBatchJobs FromHandle(SalWindowHandle handle)
        {
            return ((tbwExtFileBatchJobs)SalWindow.FromHandle(handle, typeof(tbwExtFileBatchJobs)));
        }
        #endregion

        #region Methods

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public new SalBoolean FrameStartupUser()
        {
            #region Actions
            using (new SalContext(this))
            {
                SetWindowTitle();
            }

            return false;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber SetWindowTitle()
        {
            #region Actions
            using (new SalContext(this))
            {
                Sal.SetWindowText(this, Ifs.Application.Accrul.Properties.Resources.TEXT_ExtSchedule);
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalBoolean Remove(SalNumber nWhat)
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
                        return Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Batch_SYS.Remove_Batch_Schedule") && Sal.TblAnyRows(i_hWndSelf, Sys.ROW_Selected, 0);

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        if (Ifs.Fnd.ApplicationForms.Int.AlertBox(Ifs.Application.Accrul.Properties.Resources.TEXT_ExtRemoveSchedule, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Question, Ifs.Fnd.ApplicationForms.Const.QUESTION_YesNo) == Sys.IDYES)
                        {
                            Sal.WaitCursor(true);
                            using (SignatureHints hints = SignatureHints.NewContext())
                            {
                                hints.Add("Ext_File_Batch_Param_API.Remove_Param", System.Data.ParameterDirection.Input);
                                DbPLSQLTransaction(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "Ext_File_Batch_Param_API.Remove_Param(\r\n" +
                                    "			     :i_hWndFrame.tbwExtFileBatchJobs.colnScheduleId)");
                            }
                            using (SignatureHints hints = SignatureHints.NewContext())
                            {
                                hints.Add("Batch_SYS.Remove_Batch_Schedule", System.Data.ParameterDirection.Input);
                                DbPLSQLTransaction(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "Batch_SYS.Remove_Batch_Schedule(\r\n" +
                                    "			     :i_hWndFrame.tbwExtFileBatchJobs.colnScheduleId)");
                            }
                            Sal.WaitCursor(false);
                            DataSourcePopulate(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                            return true;
                        }
                        break;
                }
            }

            return false;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="p_nWhat"></param>
        /// <returns></returns>
        public virtual SalBoolean OpenParamDialog(SalNumber p_nWhat)
        {
            #region Local Variables
            SalBoolean bEditable = false;
            SalString sSetId = "";
            SalString sTemp = "";
            cMessage Main = new cMessage();
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                switch (p_nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        if (Ifs.Fnd.ApplicationForms.Var.Security.IsPresObjectAvailable(Pal.GetActiveInstanceName("dlgExternalFileParam")) && Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Ext_File_Batch_Param_API.Update_Param_String"))
                        {
                            if (Sal.TblAnyRows(i_hWndSelf, Sys.ROW_Selected, 0))
                            {
                                return true;
                            }
                        }
                        return false;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        bEditable = 1;
                        lsParam = colParamString.Text;
                        Main.Unpack(lsParam);
                        sSetId = Main.GetAttribute("SET_ID");
                        if (dlgExternalFileParam.ModalDialog(i_hWndFrame, colsFileType.Text, sSetId, colParamString.Text, bEditable, ref lsParam) == Sys.IDOK)
                        {
                            if (colParamString.Text != lsParam)
                            {
                                Sal.WaitCursor(true);
                                using (SignatureHints hints = SignatureHints.NewContext())
                                {
                                    hints.Add("Ext_File_Batch_Param_API.Update_Param_String", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                                    if (!(DbPLSQLTransaction(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "Ext_File_Batch_Param_API.Update_Param_String(\r\n" +
                                        "                  :i_hWndFrame.tbwExtFileBatchJobs.colExtFileBatchParam,\r\n" +
                                        "	  :i_hWndFrame.tbwExtFileBatchJobs.lsParam )")))
                                    {
                                        Sal.WaitCursor(false);
                                        return false;
                                    }
                                }
                                Sal.SendMsg(i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceRefresh, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                                Sal.WaitCursor(false);
                            }
                            return true;
                        }
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
        private void tbwExtFileBatchJobs_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_UserProfileChanged:
                    this.tbwExtFileBatchJobs_OnPM_UserProfileChanged(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove:
                    this.tbwExtFileBatchJobs_OnPM_DataRecordRemove(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_UserProfileChanged event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwExtFileBatchJobs_OnPM_UserProfileChanged(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.DataSourceClear(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
            this.SetWindowTitle();
            #endregion
        }

        /// <summary>
        /// PM_DataRecordRemove event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwExtFileBatchJobs_OnPM_DataRecordRemove(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.Remove(Sys.wParam);
            e.Return = true;
            return;
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
        #endregion

        #region Event Handlers

        private void menuItem__Load_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = OpenParamDialog(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem__Load_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            OpenParamDialog(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        #endregion

    }
}
