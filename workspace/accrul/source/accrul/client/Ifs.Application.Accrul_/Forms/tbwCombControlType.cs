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
    [FndWindowRegistration("COMB_CONTROL_TYPE", "CombControlType", FndWindowRegistrationFlags.HomePage)]
    public partial class tbwCombControlType : cTableWindowFin
    {
        #region Window Variables
        public SalString sCompany = "";
        public SalString sPostingType = "";
        public SalString sColumnLabel = "";
        public SalString sControlType = "";
        public SalString sControlTypeDes = "";
        public SalString sModule = "";
        public SalString sCctEnabled = "";
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public tbwCombControlType()
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
        public new static tbwCombControlType FromHandle(SalWindowHandle handle)
        {
            return ((tbwCombControlType)SalWindow.FromHandle(handle, typeof(tbwCombControlType)));
        }
        #endregion

        #region Methods

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public new SalString GetWindowTitle()
        {
            #region Actions
            using (new SalContext(this))
            {
                return Properties.Resources.WH_tbwCombControlType;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean ValidatePostingType()
        {
            #region Local Variables
            SalArray<SalString> sArray = new SalArray<SalString>();
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                Sal.WaitCursor(true);
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("Posting_Ctrl_Posting_Type_API.Get_Module", System.Data.ParameterDirection.Input);
                    hints.Add("Posting_Ctrl_Posting_Type_API.Get_Description", System.Data.ParameterDirection.Input);
                    hints.Add("Posting_Ctrl_Posting_Type_API.Cct_Enabled", System.Data.ParameterDirection.Input);
                    if (!(DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN   :i_hWndFrame.tbwCombControlType.colsModule := \r\n				     " + cSessionManager.c_sDbPrefix + "Posting_Ctrl_Posting_Type_API.Get_Module(:i_hWndFrame.tbwCombControlType.colsPostingType);\r\n" +
                        "				     :i_hWndFrame.tbwCombControlType.colsPostingTypeDes := \r\n				     " + cSessionManager.c_sDbPrefix + "Posting_Ctrl_Posting_Type_API.Get_Description( :i_hWndFrame.tbwCombControlType.colsPostingType);												\r\n" +
                        "				     :i_hWndFrame.tbwCombControlType.sCctEnabled := \r\n" +
                        "				      " + cSessionManager.c_sDbPrefix + "Posting_Ctrl_Posting_Type_API.Cct_Enabled( :i_hWndFrame.tbwCombControlType.colsPostingType);	END;")))
                    {
                        Sal.WaitCursor(false);
                        return Sys.VALIDATE_Cancel;
                    }
                }
                Sal.WaitCursor(false);
                if (sCctEnabled == "FALSE")
                {
                    sArray[0] = colsPostingType.Text;
                    Ifs.Fnd.ApplicationForms.Int.AlertBoxWithParams(Properties.Resources.ERROR_PostTypeValidate, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.INFO_Ok, sArray);
                    return Sys.VALIDATE_Cancel;
                }
                return Sys.VALIDATE_Ok;
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
        private void tbwCombControlType_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_Create:
                    this.tbwCombControlType_OnSAM_Create(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceQueryFieldName:
                    this.tbwCombControlType_OnPM_DataSourceQueryFieldName(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_Create event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwCombControlType_OnSAM_Create(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SetWindowText(this, Properties.Resources.WH_tbwCombControlType);
            e.Return = Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataSourceQueryFieldName event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwCombControlType_OnPM_DataSourceQueryFieldName(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (SalString.FromHandle(Sys.lParam) == "POSTING_TYPE")
            {
                switch (Sys.wParam)
                {
                    case Vis.DT_Handle:
                        e.Return = SalWindowHandle.Null.ToNumber();
                        return;

                    default:
                        e.Return = (this.i_hWndFrame.ToNumber().ToString(0) + ".tbwCombControlType.colsPostingType").ToHandle();
                        return;
                }
            }
            else
            {
                e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceQueryFieldName, Sys.wParam, Sys.lParam);
                return;
            }
            if (SalString.FromHandle(Sys.lParam) == "CONTROL_TYPE1")
            {
                switch (Sys.wParam)
                {
                    case Vis.DT_Handle:
                        e.Return = SalWindowHandle.Null.ToNumber();
                        return;

                    default:
                        e.Return = (this.i_hWndFrame.ToNumber().ToString(0) + ".tbwCombControlType.sControlType").ToHandle();
                        return;
                }
            }
            else
            {
                e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceQueryFieldName, Sys.wParam, Sys.lParam);
                return;
            }
            if (SalString.FromHandle(Sys.lParam) == "CONTROL_TYPE2")
            {
                switch (Sys.wParam)
                {
                    case Vis.DT_Handle:
                        e.Return = SalWindowHandle.Null.ToNumber();
                        return;

                    default:
                        e.Return = (this.i_hWndFrame.ToNumber().ToString(0) + ".tbwCombControlType.sControlType").ToHandle();
                        return;
                }
            }
            else
            {
                e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceQueryFieldName, Sys.wParam, Sys.lParam);
                return;
            }
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colsPostingType_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    e.Handled = true;
                    e.Return = this.ValidatePostingType();
                    return;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovUserWhere:
                    e.Handled = true;
                    e.Return = ((SalString)" CCT_ENABLED =  'TRUE' ").ToHandle();
                    return;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovUserOrderBy:
                    e.Handled = true;
                    e.Return = ((SalString)"MODULE,SORT_ORDER").ToHandle();
                    return;
            }
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colsControlType1_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.colsControlType1_OnPM_DataItemValidate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovDone:
                    this.colsControlType1_OnPM_DataItemLovDone(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colsControlType1_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (!(Sal.IsNull(this.colsControlType1)))
            {
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("POSTING_CTRL_CONTROL_TYPE_API.Get_Control_Type_Module", System.Data.ParameterDirection.Input);
                    this.colsControlType1.DbPLSQLBlock(cSessionManager.c_hSql, ":i_hWndFrame.tbwCombControlType.colsModule1 := \r\n" + cSessionManager.c_sDbPrefix + "POSTING_CTRL_CONTROL_TYPE_API.Get_Control_Type_Module\r\n" +
                        "( :i_hWndFrame.tbwCombControlType.colsControlType1)");
                }
                this.colsModule1.EditDataItemSetEdited();
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemLovDone event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colsControlType1_OnPM_DataItemLovDone(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (!(Sal.IsNull(this.colsControlType1)))
            {
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("POSTING_CTRL_CONTROL_TYPE_API.Get_Control_Type_Module", System.Data.ParameterDirection.Input);
                    this.colsControlType1.DbPLSQLBlock(cSessionManager.c_hSql, ":i_hWndFrame.tbwCombControlType.colsModule1 := \r\n" + cSessionManager.c_sDbPrefix + "POSTING_CTRL_CONTROL_TYPE_API.Get_Control_Type_Module\r\n" +
                        "( :i_hWndFrame.tbwCombControlType.colsControlType1)");
                }
                this.colsModule1.EditDataItemSetEdited();
            }
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colsControlType2_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.colsControlType2_OnPM_DataItemValidate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovDone:
                    this.colsControlType2_OnPM_DataItemLovDone(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colsControlType2_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (!(Sal.IsNull(this.colsControlType2)))
            {
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("POSTING_CTRL_CONTROL_TYPE_API.Get_Control_Type_Module", System.Data.ParameterDirection.Input);
                    this.colsControlType2.DbPLSQLBlock(cSessionManager.c_hSql, ":i_hWndFrame.tbwCombControlType.colsModule2 := \r\n" + cSessionManager.c_sDbPrefix + "POSTING_CTRL_CONTROL_TYPE_API.Get_Control_Type_Module\r\n" +
                        "( :i_hWndFrame.tbwCombControlType.colsControlType2)");
                }
                this.colsModule2.EditDataItemSetEdited();
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemLovDone event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colsControlType2_OnPM_DataItemLovDone(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (!(Sal.IsNull(this.colsControlType2)))
            {
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("POSTING_CTRL_CONTROL_TYPE_API.Get_Control_Type_Module", System.Data.ParameterDirection.Input);
                    this.colsControlType2.DbPLSQLBlock(cSessionManager.c_hSql, ":i_hWndFrame.tbwCombControlType.colsModule2 := \r\n" + cSessionManager.c_sDbPrefix + "POSTING_CTRL_CONTROL_TYPE_API.Get_Control_Type_Module\r\n" +
                        "( :i_hWndFrame.tbwCombControlType.colsControlType2)");
                }
                this.colsModule2.EditDataItemSetEdited();
            }
            #endregion
        }
        #endregion

        #region Late Bind Methods

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalString vrtGetWindowTitle()
        {
            return this.GetWindowTitle();
        }

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        
        #endregion

        #region Event Handlers

        private void menuItem_Change_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            
            ((FndCommand)sender).Enabled = Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Sys.lParam);
        }

        private void menuItem_Change_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Sys.lParam);
        
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
