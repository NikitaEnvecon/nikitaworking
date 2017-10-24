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

namespace Ifs.Application.Accrul
{

    /// <summary>
    /// </summary>
    public partial class tbwAuditFormat : cTableWindowFin
    {
        #region Member Variables

        #endregion

        #region Window Variables
        public SalString sDefVal = "";
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public tbwAuditFormat()
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
        public new static tbwAuditFormat FromHandle(SalWindowHandle handle)
        {
            return ((tbwAuditFormat)SalWindow.FromHandle(handle, typeof(tbwAuditFormat)));
        }
        #endregion

        #region Properties

        #endregion

        #region Methods

        public new SalBoolean DataSourceSaveCheckOk()
        {
            #region Local Variables
            SalBoolean bCommandOk = false;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                bCommandOk = DbPLSQLBlock(cSessionManager.c_hSql, @"&AO.Audit_Format_API.Only_One_Default_Format__(
                                                                            :i_hWndFrame.tbwAuditFormat.colsCompany IN)");
                //Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Sys.wParam, Sys.lParam);
                return bCommandOk;
            }
            #endregion
        }

        public new SalBoolean DataRecordPrepareNew()
        {
            #region Actions
            using (new SalContext(this))
            {
                if (!(((cTableWindowFin)this).DataRecordPrepareNew()))
                {
                    return false;
                }
                if (__IsDefaultAddressSet())
                {
                    colsDefaultFormat.Text = "FALSE";
                }
                else
                {
                    colsDefaultFormat.Text = "TRUE";
                }
                colsDefaultFormat.EditDataItemSetEdited();
                return true;
            }
            #endregion
        }

        public virtual SalNumber __UncheckDefaults()
        {
            #region Local Variables
            SalNumber nOldRow = 0;
            SalNumber nRow = 0;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                nOldRow = Sal.TblQueryContext(i_hWndSelf);
                nRow = Sys.TBL_MinRow;
                while (true)
                {
                    if (Sal.TblFindNextRow(i_hWndSelf, ref nRow, 0, 0))
                    {
                        Sal.TblSetContext(i_hWndSelf, nRow);
                        if (nOldRow != nRow)
                        {
                            if (colsDefaultFormat.Text == "TRUE")
                            {
                                colsDefaultFormat.Text = "FALSE";
                            }
                        }
                        colsDefaultFormat.EditDataItemSetEdited();
                    }
                    else
                    {
                        break;
                    }
                }
                Sal.TblSetContext(i_hWndSelf, nOldRow);
            }

            return 0;
            #endregion
        }

        public virtual SalBoolean __CheckPossible()
        {
            #region Local Variables
            SalNumber nRow = 0;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                nRow = Sal.TblQueryContext(i_hWndSelf);
                if (Sal.TblQueryRowFlags(i_hWndSelf, nRow, Sys.ROW_MarkDeleted))
                {
                    return false;
                }
                return true;
            }
            #endregion
        }

        public virtual SalBoolean __IsDefaultAddressSet()
        {
            #region Local Variables
            SalNumber nOldRow = 0;
            SalNumber nRow = 0;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                nOldRow = Sal.TblQueryContext(i_hWndSelf);
                nRow = Sys.TBL_MinRow;
                while (true)
                {
                    if (Sal.TblFindNextRow(i_hWndSelf, ref nRow, 0, 0))
                    {
                        Sal.TblSetContext(i_hWndSelf, nRow);
                        if (nOldRow != nRow)
                        {
                            if (colsDefaultFormat.Text == "TRUE")
                            {
                                Sal.TblSetContext(i_hWndSelf, nOldRow);
                                return true;
                            }
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                Sal.TblSetContext(i_hWndSelf, nOldRow);
                // default way of payment is not selected
                return false;
            }
            #endregion
        }

        #endregion

        #region Overrides

        public override SalBoolean vrtDataSourceSaveCheckOk()
        {
            return this.DataSourceSaveCheckOk();
        }

        public override SalBoolean vrtDataRecordPrepareNew()
        {
            return this.DataRecordPrepareNew();
        }

        #endregion

        #region Window Actions

        private void colsDefaultFormat_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_AnyEdit:
                    this.colsDefaultFormat_OnSAM_AnyEdit(sender, e);
                    break;

                case Sys.SAM_SetFocus:
                    this.colsDefaultFormat_OnSAM_SetFocus(sender, e);
                    break;
            }
            #endregion
        }

        private void colsDefaultFormat_OnSAM_AnyEdit(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Sys.SAM_AnyEdit, Sys.wParam, Sys.lParam);
            if (this.sDefVal == "TRUE")
            {
                if (!(this.__CheckPossible()))
                {
                    this.colsDefaultFormat.Text = this.sDefVal;
                }
            }
            else
            {
                if (!(this.__CheckPossible()))
                {
                    this.colsDefaultFormat.Text = this.sDefVal;
                }
                else
                {
                    this.__UncheckDefaults();
                }
            }
            #endregion
        }

        private void colsDefaultFormat_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
            this.sDefVal = this.colsDefaultFormat.Text;
            #endregion
        }

        private void colsOutputFileDir_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.colsOutputFileDir_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        private void colsOutputFileDir_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam))
            {
                if (System.IO.Directory.Exists(colsOutputFileDir.Text))
                {
                    e.Return = Sys.VALIDATE_Ok;
                }
                else
                {
                    Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_InvalidOutputPath, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                    e.Return = Sys.VALIDATE_Cancel;
                }
                return;
            }
            e.Return = Sys.VALIDATE_Cancel;
            return;
            #endregion
        }

        #endregion

        #region Event Handlers

        #endregion

        #region Menu Event Handlers

        private void menu_ChangeCompany_Execute(object sender, Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            #region Actions
            using (new SalContext(this))
            {
                Sal.SendClassMessage(Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Sys.lParam);
            }
            #endregion
        }

        private void menu_ChangeCompany_Inquire(object sender, Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            #region Actions
            ((Ifs.Fnd.Windows.Forms.FndCommand)sender).Enabled = true;
            #endregion
        }

        #endregion

    }
}
