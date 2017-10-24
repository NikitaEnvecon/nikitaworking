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
using Ifs.Application.Appsrv;
using Ifs.Application.Enterp;
using Ifs.Fnd.ApplicationForms;
using PPJ.Runtime;
using PPJ.Runtime.Sql;
using PPJ.Runtime.Vis;
using PPJ.Runtime.Windows;
using PPJ.Runtime.Windows.QO;
using Ifs.Fnd.Windows.Forms;

namespace Ifs.Application.Accrul
{
	
	/// <summary>
	/// </summary>
    public partial class tbwAccrulQueryVoucherRow : cTableWindowFin
    {
        #region Window Variables
        public SalNumber nCredit = 0;
        public SalNumber nDebet = 0;
        public SalNumber nBalance = 0;
        public SalArray<SalString> sPlaceHolders = new SalArray<SalString>();
        public SalNumber nRow = 0;
        public SalString lsSumBalance = "";
        public SalString lsSumDebet = "";
        public SalString lsSumCredit = "";
        public SalString sDataSource = "";
        public SalString lsWhere = "";
        public SalNumber nCreditCorr = 0;
        public SalNumber nDebetCorr = 0;
        public SalString sYes = "";
        public SalString lsSumDebetCorr = "";
        public SalString lsSumCreditCorr = "";
        public SalString lsCompanyRef = "";
        public SalString lsVoucherTypeRef = "";
        public SalNumber nAccountingYearRef = 0;
        public SalNumber nVoucherNoRef = 0;
        public cMessage Msg = new cMessage();
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public tbwAccrulQueryVoucherRow()
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
        public new static tbwAccrulQueryVoucherRow FromHandle(SalWindowHandle handle)
        {
            return ((tbwAccrulQueryVoucherRow)SalWindow.FromHandle(handle, typeof(tbwAccrulQueryVoucherRow)));
        }
        #endregion

        #region Methods
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public override SalNumber vrtActivate(fcURL URL)
        {
            #region Local Variables
            SalNumber nItemIndex = 0;
            SalNumber nItemIndexVouNo = 0;
            SalNumber nItemIndexVouType = 0;
            SalNumber nItemIndexVouYear = 0;
            SalNumber nRowCounter = 0;
            SalNumber nRows = 0;
            SalNumber nRC = 0;
            SalNumber nRowNumber = 0;
            SalString sTmp1 = "";
            SalString sTmp2 = "";
            SalString sTmp3 = "";
            SalString sTmp5 = "";
            SalString sUserWhere = "";
            SalString sUserOrderBy = "";
            SalNumber nItemIndexCompany = 0;
            SalString sTmp4 = "";

            #endregion

            #region Actions
            using (new SalContext(this))
            {
                if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.RecCountGet() > 0)
                {
                    Sal.WaitCursor(true);
                    if (nItemIndex != Ifs.Fnd.ApplicationForms.Const.DTTRF_ColumnNotFound)
                    {
                        nRows = Ifs.Fnd.ApplicationForms.Var.DataTransfer.RecCountGet();
                        // Get Column Positions
                        nItemIndexCompany = Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemIndexGet("COMPANY");
                        nRC = Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemValueStrGet(nItemIndexCompany, 0, ref sTmp4);
                        UserGlobalValueSet("COMPANY", sTmp4);
                        Sal.SendMsg(i_hWndFrame, Ifs.Fnd.ApplicationForms.Const.PM_UserProfileChanged, 0, 0);
                        SetWindowTitle();
                        nItemIndexVouNo = Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemIndexGet("VOUCHER_NO");
                        nItemIndexVouType = Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemIndexGet("VOUCHER_TYPE");
                        nItemIndexVouYear = Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemIndexGet("ACCOUNTING_YEAR");
                        nRowNumber = Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemIndexGet("ROW_NO");
                        sUserWhere = "";
                        nRowCounter = 0;
                        // Build Where-statement dynamic
                        while (nRowCounter <= nRows - 1)
                        {
                            nRC = Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemValueStrGet(nItemIndexVouType, nRowCounter, ref sTmp1);
                            nRC = Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemValueStrGet(nItemIndexVouNo, nRowCounter, ref sTmp2);
                            nRC = Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemValueStrGet(nItemIndexVouYear, nRowCounter, ref sTmp3);
                            nRC = Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemValueStrGet(nItemIndexCompany, nRowCounter, ref sTmp4);
                            nRC = Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemValueStrGet(nRowNumber, nRowCounter, ref sTmp5);
                            sUserWhere = sUserWhere + "COMPANY = " + "'" + sTmp4 + "'" + " AND VOUCHER_TYPE = " + "'" + sTmp1 + "'" + " AND VOUCHER_NO = " + "'" + sTmp2 + "'" + " AND ACCOUNTING_YEAR = " + "'" + sTmp3 + "'" + " AND ROW_NO = " + "'" + sTmp5 +
                            "'";
                            nRowCounter = nRowCounter + 1;
                            if (nRowCounter < nRows)
                            {
                                sUserWhere = sUserWhere + " OR ";
                            }
                        }
                        // Check sUserWhere statement length, to avoid application termination problem.
                        if (sUserWhere.Length < 28000)
                        {
                            // Set Order By Clause
                            sUserOrderBy = " ACCOUNTING_YEAR,VOUCHER_TYPE,VOUCHER_NO ";
                            // Send a message for building a new where-sentence
                            // Set 'User Where Clause' in the data source
                            Sal.SendMsg(i_hWndFrame, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceUserWhere, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, sUserWhere.ToHandle());
                            // Set 'User Order By Clause' in the data source
                            Sal.SendMsg(i_hWndFrame, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceUserOrderBy, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, sUserOrderBy.ToHandle());
                            // Populate the data source with selection from the new where-sentence
                            DataSourcePopulate(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Sys.lParam);
                        }
                        else
                        {
                            Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.ERROR_StringLength, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Warning, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                        }
                    }
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();
                    Sal.WaitCursor(false);
                    return false;
                }
                return base.Activate(URL);
            }

            #endregion

        }

        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalNumber Voucher(SalNumber nWhat)
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
                        return Sal.TblAnyRows(this, Sys.ROW_Selected, 0);

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        Sal.WaitCursor(true);
                        sItemNames[0] = "VOUCHER_TYPE";
                        hWndItems[0] = colVoucherType;
                        sItemNames[1] = "VOUCHER_NO";
                        hWndItems[1] = colVoucherNo;
                        sItemNames[2] = "ACCOUNTING_YEAR";
                        hWndItems[2] = colAccountingYear;
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("VoucherType", this, sItemNames, hWndItems);
                        SessionCreateWindow(Pal.GetActiveInstanceName("frmQueryVoucherDetail"), Sys.hWndMDI);
                        Sal.WaitCursor(false);
                        break;
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalNumber QueryMultiCompanyVoucher(SalNumber nWhat)
        {
            #region Local Variables
            SalArray<SalString> sItemNames = new SalArray<SalString>();
            SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
            SalString sFullName = "";
            SalNumber nRow = 0;
            SalBoolean bTemp = false;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        nRow = Sys.TBL_MinRow;
                        bTemp = false;
                        if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("frmMCQueryVoucherDetail"))))
                        {
                            return 0;
                        }
                        while (Sal.TblFindNextRow(i_hWndSelf, ref nRow, Sys.ROW_Selected, 0))
                        {
                            if (colMultiCompanyVoucher.Text == "TRUE")
                            {
                                if (!(Sal.IsNull(colMultiCompanyId)))
                                {
                                    // Bug 94795, Begin
                                    if (colVoucherType.Text != "R")
                                    {
                                        bTemp = true;
                                    }
                                    // Bug 94795, End
                                }
                            }
                        }
                        return bTemp;
                        return 0;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        Sal.WaitCursor(true);
                        sFullName = ":i_hWndFrame." + Ifs.Fnd.ApplicationForms.Int.QualifiedItemNameGet(this) + ".";
                        sItemNames[0] = "VOUCHER_TYPE";
                        hWndItems[0] = colVoucherType;
                        sItemNames[1] = "VOUCHER_NO";
                        hWndItems[1] = colVoucherNo;
                        sItemNames[2] = "ACCOUNTING_YEAR";
                        hWndItems[2] = colAccountingYear;
                        sItemNames[3] = "COMPANY";
                        hWndItems[3] = colCompany;
                        // Bug 94795, Begin
                        if (!(Sal.IsNull(colMultiCompanyId)) && !(Sal.IsNull(colsVoucherTypeRef)))
                        {
                            // Set VouType = colsVoucherTypeRef
                            i_sCompany = colMultiCompanyId.Text;
                            sItemNames[0] = "VOUCHER_TYPE";
                            hWndItems[0] = colsVoucherTypeRef;
                            sItemNames[1] = "VOUCHER_NO";
                            hWndItems[1] = colnVoucherNoRef;
                            sItemNames[2] = "ACCOUNTING_YEAR";
                            hWndItems[2] = colnAccountingYearRef;
                            sItemNames[3] = "COMPANY";
                            hWndItems[3] = colMultiCompanyId;
                        }
                        // Bug 94795, End
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("VOUCHER_DETAIL", this, sItemNames, hWndItems);
                        SessionCreateWindow(Pal.GetActiveInstanceName("frmMCQueryVoucherDetail"), Sys.hWndMDI);
                        Sal.WaitCursor(false);
                        break;
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public new SalString GetWindowTitle()
        {
            #region Actions
            using (new SalContext(this))
            {
                // Bug Bug 82977, Begin
                return Properties.Resources.WH_tbwAccrulQueryVoucherRow;
                // Bug Bug 82977, End
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
        private void tbwAccrulQueryVoucherRow_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_UserProfileChanged:
                    this.tbwAccrulQueryVoucherRow_OnPM_UserProfileChanged(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceQueryFieldName:
                    this.tbwAccrulQueryVoucherRow_OnPM_DataSourceQueryFieldName(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate:
                    this.tbwAccrulQueryVoucherRow_OnPM_DataSourcePopulate(sender, e);
                    break;

                // Bug 82899, Begin

                case Ifs.Fnd.ApplicationForms.Const.PM_AttachmentKeysGet:
                    this.tbwAccrulQueryVoucherRow_OnPM_AttachmentKeysGet(sender, e);
                    break;

                // Bug 82899, End
            }
            #endregion
        }

        /// <summary>
        /// PM_UserProfileChanged event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwAccrulQueryVoucherRow_OnPM_UserProfileChanged(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_UserProfileChanged, Sys.wParam, Sys.lParam))
            {
                this.nBalance = 0;
                this.nCredit = 0;
                this.nDebet = 0;
            }
            else
            {
                e.Return = false;
                return;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataSourceQueryFieldName event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwAccrulQueryVoucherRow_OnPM_DataSourceQueryFieldName(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (SalString.FromHandle(Sys.lParam) == "COMPANY")
            {
                switch (Sys.wParam)
                {
                    case Vis.DT_Handle:
                        e.Return = SalWindowHandle.Null.ToNumber();
                        return;

                    default:
                        // Bug 71319, Begin. Replaced tbwQueryVoucherRow with tbwAccrulQueryVoucherRow.
                        e.Return = (this.i_hWndFrame.ToNumber().ToString(0) + ".tbwAccrulQueryVoucherRow.i_sCompany").ToHandle();
                        return;
                        // Bug 71319, End.
                        break;
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
        /// PM_DataSourcePopulate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwAccrulQueryVoucherRow_OnPM_DataSourcePopulate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Sys.wParam, Sys.lParam))
            {
                // Bug 82419 Begin
                if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire)
                {
                    e.Return = false;
                    return;
                }
                // Bug 82419 End
                if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
                {
                    // Bug 71319, Begin. Changed incorrect qualifications.
                    this.dfCodePartValue.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                    this.dfDescription.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                    // Bug 71319, End.
                }
                e.Return = true;
                return;
            }
            else
            {
                e.Return = false;
                return;
            }
            #endregion
        }

        /// <summary>
        /// PM_AttachmentKeysGet event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwAccrulQueryVoucherRow_OnPM_AttachmentKeysGet(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.Msg.Construct();
            this.Msg.AddAttribute("ACCOUNTING_YEAR", Sal.WindowHandleToNumber(this.colAccountingYear).ToString(0));
            this.Msg.AddAttribute("COMPANY", Sal.WindowHandleToNumber(this.colCompany).ToString(0));
            this.Msg.AddAttribute("VOUCHER_NO", Sal.WindowHandleToNumber(this.colVoucherNo).ToString(0));
            this.Msg.AddAttribute("VOUCHER_TYPE", Sal.WindowHandleToNumber(this.colVoucherType).ToString(0));
            this.Msg.AddAttribute("ROW_NO", Sal.WindowHandleToNumber(this.colsRowNo).ToString(0));
            e.Return = this.Msg.Pack().ToHandle();
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void dfCodePartValue_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Const.PAM_SetCodePartValue:
                    this.dfCodePartValue_OnPAM_SetCodePartValue(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PAM_SetCodePartValue event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfCodePartValue_OnPAM_SetCodePartValue(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.IsWindowVisible(this.dfCodePartValue.i_hWndSelf))
            {
                Sal.SetWindowText(this.dfCodePartValue.i_hWndSelf, cTableWindowFin.sCodePartValue);
                e.Return = true;
                return;
            }
            #endregion
        }
        #endregion

        #region Late Bind Methods
        // Insert new code here...

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalString vrtGetWindowTitle()
        {
            return this.GetWindowTitle();
        }
        #endregion

        #region Event Handlers

        private void menuItem_Voucher_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = Voucher(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem_Voucher_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            Voucher(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem_View_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = QueryMultiCompanyVoucher(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem_View_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            QueryMultiCompanyVoucher(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem_Change_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = Sal.SendClassMessage(Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Sys.lParam);
        }

        private void menuItem_Change_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            Sal.SendClassMessage(Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Sys.lParam);
        }

        private void menuItem_Voucher_1_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = Voucher(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem_Voucher_1_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            Voucher(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem_View_1_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = QueryMultiCompanyVoucher(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem_View_1_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            QueryMultiCompanyVoucher(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem_Change_1_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = Sal.SendClassMessage(Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Sys.lParam);
        }

        private void menuItem_Change_1_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            Sal.SendClassMessage(Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Sys.lParam);
        }

        #endregion

    }
}
