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
    [FndWindowRegistration("EXT_PARAMETERS", "ExtParameters", FndWindowRegistrationFlags.HomePage)]
    public partial class tbwExtParameters : cTableWindowFin
    {
        #region Window Variables
        public SalBoolean bSave = false;
        public SalNumber nTemp = 0;
        public SalString sTemp = "";
        public SalString sTemp1 = "";
        public SalArray<SalString> sPlaceHolders = new SalArray<SalString>();
        public SalArray<SalString> VouchNoClientVals = new SalArray<SalString>();
        public SalArray<SalString> VouchNoDbVals = new SalArray<SalString>();
        public SalArray<SalString> GroupClientVals = new SalArray<SalString>();
        public SalArray<SalString> GroupDbVals = new SalArray<SalString>();
        public SalString lsStmt = "";
        public SalArray<SalString> sItemNames = new SalArray<SalString>();
        public SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public tbwExtParameters()
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
        public new static tbwExtParameters FromHandle(SalWindowHandle handle)
        {
            return ((tbwExtParameters)SalWindow.FromHandle(handle, typeof(tbwExtParameters)));
        }
        #endregion

        #region Methods

        /// <summary>
        /// This function refreshes the default flag on the window. Checks if there is something in Selections combo box:
        /// if yes - simulates click messae; if not - sends PM_DataSourcePopulate message
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean RefreshForm()
        {
            #region Actions
            using (new SalContext(this))
            {
                Sal.SendMsg(i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
            }

            return false;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean CheckOtherColumnsEdited()
        {
            #region Local Variables
            SalNumber n = 0;
            SalString other_columns_edited = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                other_columns_edited = "FALSE";
                while (n < i_nChildCount)
                {
                    if (Sal.QueryFieldEdit(i_hWndChild[n]))
                    {
                        if (cColumn.FromHandle(i_hWndChild[n]).p_sSqlColumn != "DEF_TYPE")
                        {
                            other_columns_edited = "TRUE";
                            break;
                        }
                    }
                    n = n + 1;
                }
                if (other_columns_edited == "TRUE")
                {
                    return true;
                }
                return false;
            }
            #endregion
        }

        public virtual SalNumber ClearChecked()
        {
            #region Local Variables
            SalNumber nRow = 0;
            SalNumber nCurrentRow = 0;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                nCurrentRow = Sal.TblQueryContext(i_hWndSelf);
                nRow = Sys.TBL_MinRow;
                while (true)
                {
                    if (Sal.TblFindNextRow(i_hWndSelf, ref nRow, 0, 0))
                    {
                        Sal.TblSetContext(i_hWndSelf, nRow);
                        if (nCurrentRow != nRow)
                        {
                            if (colsDefType.Text == "TRUE")
                            {
                                colsDefType.Text = "FALSE";
                                if (!(Sal.TblQueryRowFlags(this, nRow, Sys.ROW_New)))
                                {
                                    Sal.TblSetRowFlags(this, nRow, Sys.ROW_Edited, false);
                                }
                            }
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                Sal.TblSetContext(i_hWndSelf, nCurrentRow);
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
        private void tbwExtParameters_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceQueryFieldName:
                    this.tbwExtParameters_OnPM_DataSourceQueryFieldName(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave:
                    this.tbwExtParameters_OnPM_DataSourceSave(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataSourceQueryFieldName event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwExtParameters_OnPM_DataSourceQueryFieldName(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if ((SalString.FromHandle(Sys.lParam) == "COMPANY") && (Sys.wParam != Vis.DT_Handle))
            {
                e.Return = (this.i_hWndFrame.ToNumber().ToString(0) + ".tbwExtParameters.i_sCompany").ToHandle();
                return;
            }
            else
            {
                e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceQueryFieldName, Sys.wParam, Sys.lParam);
                return;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataSourceSave event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwExtParameters_OnPM_DataSourceSave(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                this.bSave = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Sys.wParam, Sys.lParam);
                if (this.bSave) 
                {
                    this.RefreshForm();
                }
                e.Return = this.bSave;
                return;
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colVoucherType_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom:
                    this.colVoucherType_OnPM_DataItemZoom(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemZoom event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colVoucherType_OnPM_DataItemZoom(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                this.sItemNames[0] = "COMPANY";
                this.hWndItems[0] = this.colCompany;
                this.sItemNames[1] = "VOUCHER_TYPE";
                this.hWndItems[1] = this.colVoucherType;
                Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("VoucherTypeDetail", this, this.sItemNames, this.hWndItems);
                SessionNavigate(Pal.GetActiveInstanceName("tbwQueryVoucherType"));
                e.Return = true;
                return;
            }
            else
            {
                e.Return = true;
                return;
            }
            #endregion
        }
        #endregion

        #region Late Bind Methods
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

        #region Window Actions

        private void colsDefType_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_AnyEdit:
                    this.colsDefType_OnSAM_AnyEdit(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_User:
                    e.Handled = true;
                    // Clear the field edit flag
                    Sal.SetFieldEdit(this.colsDefType.i_hWndSelf, false);
                    break;

            }
            #endregion
        }
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colsDefType_OnSAM_AnyEdit(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.colsDefType.Text == "FALSE")
            {
                this.colsDefType.Text = "TRUE";
                if (Sal.TblQueryRowFlags(this, Sal.TblQueryContext(this), Sys.ROW_New))
                {
                    if (Sal.QueryFieldEdit(this.colsDefType.i_hWndSelf))
                    {
                        e.Return = true;
                        return;
                    }
                }
                else
                {
                    if (!(this.CheckOtherColumnsEdited()))
                    {
                        Sal.PostMsg(this.colsDefType.i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_User, 0, Sys.lParam);
                        Sal.TblSetRowFlags(this, Sys.lParam, Sys.ROW_Edited, false);
                    }
                    e.Return = false;
                    return;
                }
            }
            else
            {
                this.ClearChecked();
                Sal.SendClassMessage(Sys.SAM_AnyEdit, 0, Sys.lParam);
                Sal.SetFieldEdit(this.colsDefType.i_hWndSelf, true);
            }

            #endregion
        }

        #endregion
    }
}
