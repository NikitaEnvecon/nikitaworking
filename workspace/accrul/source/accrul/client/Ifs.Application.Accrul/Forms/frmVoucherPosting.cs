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
// DATE        BY        NOTES
// YY-MM-DD
// 14-11-15    Chgulk    PRFI-3337, Merged LCS patch 119340.
// 14-09-03    Clstlk    PRFI-1690,Merged bug 118382 .Corrected in CopyDetailVoucher(),SetThirdCurrencyAmounts()and CreateReverseVoucher().
// 14-05-23    Hecolk    PBFI-7553, Recalculate the balances when the value of Account is modified with a "Exclude from Balance" ticked account and vise-versa
// 14-05-23    PRatlk    PBFI-7118,third currency back calculation issue when saving a voucher wich used copy paste functionality.
// 14-04-30    Nirylk    PBFI-5614,Merged bug 100161. Subscribed to WindowActions of tblVoucherPosting_colsDeliveryTypeId.
// 14-04-28    CHARLK    PBFI-3957,Assign value to __lsMessage in method DataRecordFetchEditedUser
// 14-02-21    Clstlk    PBFI-4128,Merged bug 112528 .Corrected in CopyGLVouRow().
// 14-02-21    CHARLK    PBFI-5545,replace this with the tblVoucherPosting in  method TblColumnSum.
// 14-02-20    CHARLK    PBFI-5545,Modified Method tblVoucherPosting_colnThirdCurrencyDebitAmount_OnPM_DataItemValidate()
// 14-02-07    CHARLK    PBFI-3566,Modify Method DataRecordFetchEditedUser().
// 14-02-06    CHARLK    PBFI-3566,Added Method DataRecordFetchEditedUser().
// 12-07-11    THPELK    Bug 102106, Corrected in UM_CopyVoucher()
// 12-07-12    THPELK    Bug 102266, Corrected in CopyGLVouRow()
// 12-07-12    THPELK    Bug 102399, Corrected in SetAnotherValue()
// 12-11-23    JANBLK    DANU-122, Parallel currency implementation.
// 13-05-07    NILILK    Modified ResetTaxAmountFromCurrTaxAmount to calculate third currency tax amount. 
// 13-05-07    NILILK    Modified tblVoucherPosting_colnCurrencyAmount_OnPM_DataItemValidate to Set Third Currency Amounts when changing the Other amount fields.
// 13-05-08    NILILK    Restricted Editing Parallel Currency columns when transaction currency is equal to parallel currecny.
// 13-07-12    AJPELK    Bug 111253, Corrected
// 13-08-23    THPELK    Bug 105544, Corrected tblVoucherPosting_colsAccount_OnPM_DataItemValidate.
// 13-09-18    THPELK    Bug 112503, Corrected in CopyGLVouRow() and removed method GetGrossAmount() sicne it recalculate the amounts when copying.
// 14-06-25    THPELK    LCS Merge (Bug 117597), Corrected in tblVoucherPosting_OnPM_DataRecordPaste().
// 14-06-30    THPELK    LCS Merge PRFI-1011(Bug 117656), Corrected in SetTaxValue().

// 13-05-09    NILILK    Modified validations of Parallel Currency Columns to update other amount columns when transaction currency is equal to parallel currency.
// 13-05-10    NILILK    Modified validations of Amount column to calculate Parallel Currency Amount.
// 13-05-14    NILILK    Modified validations of Amount column and Currency Amount column to calculate Parallel Currency Tax Amount.
// 13-05-14    NILILK    Added validation to tblVoucherPosting_colnParallelCurrTaxAmount, to calculate other amounts when transaction is entered in Parallel Currency. 
// 13-05-14    NILILK    Removed call to Parallel Currency Calculation under fetchRowDone of the child table. 
// 13-05-17    NILILK    Restricted Parallel Currency Calculations when Duplicating a row.
// 13-05-21    NILILK    Modified CopyGLVouRow() Function to copy Parallel Currency Amounts. 
// 13-05-23    NILILK    Restructured Parallel Currency Tax Calculation.
// 13-05-28    NILILK    Restructured Parallel Currency Rate Calculation.
// 13-05-29    NILILK    Modified Parallel Currency Calculation to handle Zero and NULL values entered in Amoutn Fields.
// 13-05-30    NILILK    Modified CalcualteParallelCurrTaxValue() to add a new condition to skip Parallel Curency Tax calculation if parallel currency is not enabled for the company. 
// 13-06-06    NILILK    Modified the validation of Currency Code to calculate Parallel Currency Amounts when changing the Currency Code.
// 13-06-06    NILILK    Modified the validation of tblVoucherPosting_colnTaxAmount to prevent calculating the Parallel Currency Tax Amount when Accounting currency is not same as trans currency or parallel base is not Accounting currency.
// 13-06-07    NILILK    Modified ResetCurrTaxAmountFromTaxAmount() to calculate Parallel Currency Tax Amount amount.
// 13-06-10    NILILK    Modified Parallel Currency Columns to be disabled when Parallel Currency is not defined for the company.
// 13-06-11    NILILK    Modified Parallel Currency Calculation logic when Base is Accounting Currency.
// 13-06-12    NILILK    Modified Use Voucher template logic to calculate Parallel Currency Amounts.
// 13-06-13    NILILK    Modified DataRecordCheckRequired to validate parallel currency amounts. 
// 13-06-14    NILILK    Modified Modified the window actions of column tblVoucherPosting_colnParallelCurrRateType to remove PM_DataItemLovDone.
// 13-06-14    NILILK    Modified CopyGlVoucherRow and UseTemplate Function to set Parallel Currency Rate Type.
// 13-06-25    NILILK    Modified ValidateCurrencyCode() to check Currency rate is defined for Parallel Currency Rate Type .
// 13-07-03    NILILK    Modified DataRecordCheckRequired() and DataRecordExecuteModify() to validate third currency rate. 
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
using System.Collections.Generic;

namespace Ifs.Application.Accrul
{
	/// <summary>
	/// </summary>
    public partial class frmVoucherPosting : cFormWindowFin
    {
        #region Window Variables
        public SalString sIsValidEmuCurrency = "";
        public SalString sVouDate = "";
        public SalString sCurrCode = "";
        public SalString sProjectOriginGlobal = "";
        public SalString IsEmu = "";
        public SalString sUserGroup = "";
        public cCache CacheInfo = new cCache();
        public cCache cTempCache = new cCache();
        public SalBoolean bCopyFromGL = false;
        public SalBoolean bCopyFromTemplate = false;
        public SalString sFinalTemplateList = "";
        public SalString sCallFrmDCAmnt = "";
        public SalString sNullValue = Sys.STRING_Null;
        public SalString sIsRemoved = "FALSE";
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public frmVoucherPosting()
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
        public new static frmVoucherPosting FromHandle(SalWindowHandle handle)
        {
            return ((frmVoucherPosting)SalWindow.FromHandle(handle, typeof(frmVoucherPosting)));
        }
        #endregion

        #region Methods

        /// <summary>
        /// Applications and the framework call the DataSourceActivate function
        /// to indicate that a data source has been activated by the user.
        /// </summary>
        /// <returns></returns>
        public new SalNumber DataSourceActivate()
        {
            #region Local Variables
            SalNumber nPosAccount = 0;
            SalNumber nRow = 0;
            SalWindowHandle hWndCol = SalWindowHandle.Null;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                ((cDataSource)this).DataSourceActivate();
                // Jump to next data source if only F11 is pressed
                nRow = Sal.TblQueryContext(tblVoucherPosting);
                nPosAccount = Sal.TblQueryColumnID(tblVoucherPosting_colsAccount);
                hWndCol = Sal.TblGetColumnWindow(tblVoucherPosting, nPosAccount, Sys.COL_GetPos);
                Sal.TblSetFocusCell(tblVoucherPosting, nRow, hWndCol, 0, 1);
                Sal.SetFocus(tblVoucherPosting); 
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
        private void frmVoucherPosting_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Const.PAM_VoucherDateGet:
                    this.frmVoucherPosting_OnPAM_VoucherDateGet(sender, e);
                    break;

                case Const.PAM_ShowInternalCP:
                    e.Handled = true;
                    e.Return = true;
                    return;

            }
            #endregion
        }

        /// <summary>
        /// PAM_VoucherDateGet event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmVoucherPosting_OnPAM_VoucherDateGet(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.sVouDate = SalString.FromHandle(Sal.SendMsg(this.i_hWndParent, Const.PAM_VoucherDateGet, 0, 0));
            e.Return = this.sVouDate.ToHandle();
            return;
            #endregion
        }


        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblVoucherPosting_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Const.PAM_GetIntPostingInfo:
                    this.tblVoucherPosting_OnPAM_GetIntPostingInfo(sender, e);
                    break;

                case Sys.SAM_FetchRowDone:
                    this.tblVoucherPosting_OnSAM_FetchRowDone(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordDuplicate:
                    this.tblVoucherPosting_OnPM_DataRecordDuplicate(sender, e);
                    break;

                // Bug 74030, Begin, Corrected the class message from PM_DataRecordDuplicate to PM_DataRecordPaste.

                // Changed the logic to paste third amounts too

                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordPaste:
                    this.tblVoucherPosting_OnPM_DataRecordPaste(sender, e);
                    break;

                // Bug 74030, End

                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate:
                    this.tblVoucherPosting_OnPM_DataSourcePopulate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblVoucherPosting_OnPM_DataItemValidate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceQueryFieldName:
                    this.tblVoucherPosting_OnPM_DataSourceQueryFieldName(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_User:
                    e.Handled = true;
                    cChildTableFin.sUserName = this.sUserName[1].Trim();
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove:
                    this.tblVoucherPosting_OnPM_DataRecordRemove(sender, e);
                    break;

                // Bug 81052, Reset the required code string if only a code part is entered.

                case Const.PAM_ValidateCodePartValues:
                    this.tblVoucherPosting_OnPAM_ValidateCodePartValues(sender, e);
                    break;

                // Bug 81052, End.

                case Const.PAM_CodePartBlocked:
                    e.Handled = true;
                    e.Return = this.CodePartBlocked(SalString.FromHandle(Sys.wParam));
                    return;

                case Ifs.Application.Accrul.Const.PAM_CallChanged:
                    e.Handled = true;
                    if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
                    {
                        this.tblVoucherPosting.nInit = 0;
                        cFinlibServices.nCodePartNameCount = 0;
                    }
                    e.Return = Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_CallChanged, Sys.wParam, Sys.lParam);
                    return;

            }
            #endregion
        }

        /// <summary>
        /// PAM_GetIntPostingInfo event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherPosting_OnPAM_GetIntPostingInfo(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.sMessage.Construct();
            this.sMessage.AddAttribute("COMPANY", this.tblVoucherPosting_colsCompany.Text);
            this.sMessage.AddAttribute("LEDGER_ID", this.p_sLedger);
            this.sMessage.AddAttribute("VOUCHER_TYPE", this.tblVoucherPosting_colsVoucherType.Text);
            this.sMessage.AddAttribute("ACCOUNT", this.p_sAccount);
            this.sMessage.AddAttribute("CORRECTION", this.p_sCorrection);
            this.sTempVouDate = frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(this.i_hWndFrame)).dfdVoucherDate.DateTime.ToString();
            this.sMessage.AddAttribute("VOUCHER_DATE", this.sTempVouDate);
            this.sMessage.AddAttribute("ACCOUNTING_YEAR", this.tblVoucherPosting_colnAccountingYear.Number.ToString(0));
            this.sMessage.AddAttribute("VOUCHER_NO", this.tblVoucherPosting_colnVoucherNo.Number.ToString(0));
            this.sMessage.AddAttribute("REF_ROW_NO", this.p_nRefRowNo.ToString(0));
            this.sMessage.AddAttribute("AMOUNT", this.p_nAmount.ToString(frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(this.i_hWndFrame)).nDecimalsInAmount));
            this.sMessage.AddAttribute("CURRENCY_AMOUNT", this.p_nCurrencyAmount.ToString(frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(this.i_hWndFrame)).nDecimalsInAmount));
            this.sMessage.AddAttribute("CURRENCY_RATE", this.p_nCurrRate.ToString(9));
            this.sMessage.AddAttribute("INTERNAL_SEQ_NUMBER", this.p_nInternalSeq.ToString(0));
            this.sMessage.AddAttribute("CONV_FACTOR", frmVoucherPosting.FromHandle(this.i_hWndFrame).i_nFinConversionFactor.ToString(0));
            // Bug 77430, Begin
            if (this.tblVoucherPosting_colsFunctionGroup.Text == "M" || this.tblVoucherPosting_colsFunctionGroup.Text == "Q" || this.tblVoucherPosting_colsFunctionGroup.Text == "K")
            {
                if (frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(this.i_hWndFrame)).sAuthLevel != "ApproveOnly")
                {
                    this.sMessage.AddAttribute("EDITABLE", "Y");
                }
                else
                {
                    this.sMessage.AddAttribute("EDITABLE", "N");
                }
            }
            // Bug 77430, End
            // Bug 72736, Begin
            this.sMessage.AddAttribute("COMP_CURRENCY", frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(this.i_hWndFrame)).sCurrencyCode);
            this.sMessage.AddAttribute("CURRENCY", this.tblVoucherPosting_colsCurrencyCode.Text);
            // Bug 72736, End
            this.sMessage.AddAttribute("DECIMAL_TRANS_ROUND", this.tblVoucherPosting_colnDecimalsInAmount.Number.ToString(0));
            this.sMessage.AddAttribute("DECIMAL_BASE_ROUND", this.tblVoucherPosting_colnAccDecimalsInAmount.Number.ToString(0));
            this.sPackedMessage = this.sMessage.Pack();
            e.Return = this.sPackedMessage.ToHandle();
            return;
            #endregion
        }

        /// <summary>
        /// SAM_FetchRowDone event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherPosting_OnSAM_FetchRowDone(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Sys.SAM_FetchRowDone, Sys.wParam, Sys.lParam);
            this.sAmountMethod = frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(this.i_hWndFrame)).cmbsAmountMethod.Text;
            if (this.sAmountMethod == frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(this.i_hWndFrame)).sAmountMethodGross)
            {
                this.sAmountMethodDb = "GROSS";
                if (this.tblVoucherPosting_colnGrossAmount.Number != Sys.NUMBER_Null)
                {

                    // PPJ: Automatically generated temporary assignments. Properties canot be passed by reference.
                    SalNumber temp1 = this.tblVoucherPosting_colnCurrencyGrossAmount.Number;
                    SalNumber temp2 = this.tblVoucherPosting_colnCurrencyDebetAmount.Number;
                    SalNumber temp3 = this.tblVoucherPosting_colnCurrencyCreditAmount.Number;
                    SalNumber temp4 = this.tblVoucherPosting_colnCurrencyAmount.Number;
                    SalNumber temp5 = this.tblVoucherPosting_colnDebetAmount.Number;
                    SalNumber temp6 = this.tblVoucherPosting_colnCreditAmount.Number;
                    this.ConvertGrossToNet(ref temp1, ref temp2, ref temp3, ref temp4, ref temp5, ref temp6);
                    this.tblVoucherPosting_colnCurrencyGrossAmount.Number = temp1;
                    this.tblVoucherPosting_colnCurrencyDebetAmount.Number = temp2;
                    this.tblVoucherPosting_colnCurrencyCreditAmount.Number = temp3;
                    this.tblVoucherPosting_colnCurrencyAmount.Number = temp4;
                    this.tblVoucherPosting_colnDebetAmount.Number = temp5;
                    this.tblVoucherPosting_colnCreditAmount.Number = temp6;


                    // PPJ: Automatically generated temporary assignments. Properties canot be passed by reference.
                    SalNumber temp7 = this.tblVoucherPosting_colnGrossAmount.Number;
                    SalNumber temp8 = this.tblVoucherPosting_colnDebetAmount.Number;
                    SalNumber temp9 = this.tblVoucherPosting_colnCreditAmount.Number;
                    SalNumber temp10 = this.tblVoucherPosting_colnAmount.Number;
                    SalNumber temp11 = this.tblVoucherPosting_colnCurrencyDebetAmount.Number;
                    SalNumber temp12 = this.tblVoucherPosting_colnCurrencyCreditAmount.Number;
                    this.ConvertGrossToNet(ref temp7, ref temp8, ref temp9, ref temp10, ref temp11, ref temp12);
                    this.tblVoucherPosting_colnGrossAmount.Number = temp7;
                    this.tblVoucherPosting_colnDebetAmount.Number = temp8;
                    this.tblVoucherPosting_colnCreditAmount.Number = temp9;
                    this.tblVoucherPosting_colnAmount.Number = temp10;
                    this.tblVoucherPosting_colnCurrencyDebetAmount.Number = temp11;
                    this.tblVoucherPosting_colnCurrencyCreditAmount.Number = temp12;
                    Sal.TblSetRowFlags(this.tblVoucherPosting, Sal.TblQueryContext(this.tblVoucherPosting), Sys.ROW_Edited, false);
                }
            }
            else
            {
                this.sAmountMethodDb = "NET";
            }
            this.sFinCurrencyCode = this.tblVoucherPosting_colsCurrencyCode.Text;

            //if (!(frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).lsAutoBal == "Y"))
            //{
            //    this.SetThirdCurrencyAmounts();
            //}
            this.tblVoucherPosting_colsPrevAccount.Text = this.tblVoucherPosting_colsAccount.Text;
            this.tblVoucherPosting_colsPrevTaxCode.Text = this.tblVoucherPosting_colsOptionalCode.Text;
            this.tblVoucherPosting_colsPrevCurrencyCode.Text = this.tblVoucherPosting_colsCurrencyCode.Text;
            if (!(Sal.IsNull(this.tblVoucherPosting_colnDebetAmount)))
            {
                this.tblVoucherPosting_colnPrevCurrencyAmount.Number = this.tblVoucherPosting_colnCurrencyDebetAmount.Number;
                this.tblVoucherPosting_colnPrevAmount.Number = this.tblVoucherPosting_colnDebetAmount.Number;
            }
            else if (!(Sal.IsNull(this.tblVoucherPosting_colnCreditAmount)))
            {
                this.tblVoucherPosting_colnPrevCurrencyAmount.Number = this.tblVoucherPosting_colnCurrencyCreditAmount.Number;
                this.tblVoucherPosting_colnPrevAmount.Number = this.tblVoucherPosting_colnCreditAmount.Number;
            }
            e.Return = true;
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataRecordDuplicate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherPosting_OnPM_DataRecordDuplicate(object sender, WindowActionsEventArgs e)
        {
            #region Local Variables
            SalBoolean btblVoucherPosting_colnConversionFactor_FIELD_Insert = true;
            SalBoolean btblVoucherPosting_colnParallelCurrConvFactor_FIELD_Insert = true;
            SalString  sInternal = "FALSE";
            SalNumber  nOldRow = 0;
            SalNumber  nRow = 0;
            #endregion

            #region Actions
            e.Handled = true;

            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                btblVoucherPosting_colnConversionFactor_FIELD_Insert       = tblVoucherPosting_colnConversionFactor.EditDataItemFlagQuery(Ifs.Fnd.ApplicationForms.Const.FIELD_Insert);
                btblVoucherPosting_colnParallelCurrConvFactor_FIELD_Insert = tblVoucherPosting_colnParallelCurrConvFactor.EditDataItemFlagQuery(Ifs.Fnd.ApplicationForms.Const.FIELD_Insert);

                this.tblVoucherPosting_colnConversionFactor.EditDataItemFlagSet(Ifs.Fnd.ApplicationForms.Const.FIELD_Insert, true);
                this.tblVoucherPosting_colnParallelCurrConvFactor.EditDataItemFlagSet(Ifs.Fnd.ApplicationForms.Const.FIELD_Insert, true);
                nRow = Sal.TblQueryContext(this.tblVoucherPosting);
                sInternal = this.tblVoucherPosting_colAddInternal.Text; 
            }

            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordDuplicate, Sys.wParam, Sys.lParam))
            {
                if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
                {
                    nOldRow = Sal.TblQueryContext(this.tblVoucherPosting.i_hWndSelf);
                    Sal.TblSetContext(this.tblVoucherPosting.i_hWndSelf, nRow + 1);
                    this.tblVoucherPosting_colAddInternal.Text = sInternal;
                    Sal.TblSetContext(this.tblVoucherPosting.i_hWndSelf, nOldRow);
                    
                    this.tblVoucherPosting_colsPrevAccount.Text = this.tblVoucherPosting_colsAccount.Text;
                    this.tblVoucherPosting_colsPrevTaxCode.Text = this.tblVoucherPosting_colsOptionalCode.Text;
                    this.tblVoucherPosting_colsPrevCurrencyCode.Text = this.tblVoucherPosting_colsCurrencyCode.Text;
                    this.bIsDupl = true;

                    this.tblVoucherPosting_colnConversionFactor.EditDataItemFlagSet(Ifs.Fnd.ApplicationForms.Const.FIELD_Insert, btblVoucherPosting_colnConversionFactor_FIELD_Insert);
                    this.tblVoucherPosting_colnParallelCurrConvFactor.EditDataItemFlagSet(Ifs.Fnd.ApplicationForms.Const.FIELD_Insert, btblVoucherPosting_colnParallelCurrConvFactor_FIELD_Insert);
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
        /// PM_DataRecordPaste event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherPosting_OnPM_DataRecordPaste(object sender, WindowActionsEventArgs e)
        {
            #region Local Variables
            SalBoolean bOk = false;
            SalNumber nCurRow = 0;
            SalBoolean btblVoucherPosting_colnThirdCurrencyDebitAmount_FIELD_Insert = true;
            SalBoolean btblVoucherPosting_colnThirdCurrencyCreditAmount_FIELD_Insert = true;
            SalBoolean btblVoucherPosting_colnParallelCurrConvFactor_FIELD_Insert = true ;
            #endregion

            #region Actions
            e.Handled = true;
            
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                btblVoucherPosting_colnThirdCurrencyDebitAmount_FIELD_Insert  = tblVoucherPosting_colnThirdCurrencyDebitAmount.EditDataItemFlagQuery(Ifs.Fnd.ApplicationForms.Const.FIELD_Insert);
                btblVoucherPosting_colnThirdCurrencyCreditAmount_FIELD_Insert = tblVoucherPosting_colnThirdCurrencyCreditAmount.EditDataItemFlagQuery(Ifs.Fnd.ApplicationForms.Const.FIELD_Insert);
                btblVoucherPosting_colnParallelCurrConvFactor_FIELD_Insert    = tblVoucherPosting_colnParallelCurrConvFactor.EditDataItemFlagQuery(Ifs.Fnd.ApplicationForms.Const.FIELD_Insert);

                this.tblVoucherPosting_colnThirdCurrencyDebitAmount.EditDataItemFlagSet(Ifs.Fnd.ApplicationForms.Const.FIELD_Insert, true);
                this.tblVoucherPosting_colnThirdCurrencyCreditAmount.EditDataItemFlagSet(Ifs.Fnd.ApplicationForms.Const.FIELD_Insert, true);
                this.tblVoucherPosting_colnParallelCurrConvFactor.EditDataItemFlagSet(Ifs.Fnd.ApplicationForms.Const.FIELD_Insert, true);
                this.tblVoucherPosting_colnConversionFactor.EditDataItemFlagSet(Ifs.Fnd.ApplicationForms.Const.FIELD_Insert, true);
                this.tblVoucherPosting_colnConversionFactor.EditDataItemFlagSet(Ifs.Fnd.ApplicationForms.Const.FIELD_Update, true);                
                this.tblVoucherPosting_colnParallelCurrConvFactor.EditDataItemFlagSet(Ifs.Fnd.ApplicationForms.Const.FIELD_Insert, true);
                this.tblVoucherPosting_colnParallelCurrConvFactor.EditDataItemFlagSet(Ifs.Fnd.ApplicationForms.Const.FIELD_Update, true);                
            }

            // The code in the upper part makes sure that thrid curr debit credit and conversion factor is copied when we use copy and paste options.

            this.bReturnFromDataRecordPaste = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordPaste, Sys.wParam, Sys.lParam);
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                this.tblVoucherPosting_colnThirdCurrencyDebitAmount.EditDataItemFlagSet(Ifs.Fnd.ApplicationForms.Const.FIELD_Insert, btblVoucherPosting_colnThirdCurrencyDebitAmount_FIELD_Insert);
                this.tblVoucherPosting_colnThirdCurrencyCreditAmount.EditDataItemFlagSet(Ifs.Fnd.ApplicationForms.Const.FIELD_Insert, btblVoucherPosting_colnThirdCurrencyCreditAmount_FIELD_Insert);
                this.tblVoucherPosting_colnParallelCurrConvFactor.EditDataItemFlagSet(Ifs.Fnd.ApplicationForms.Const.FIELD_Insert, btblVoucherPosting_colnParallelCurrConvFactor_FIELD_Insert);
			    this.tblVoucherPosting_colnConversionFactor.EditDataItemFlagSet(Ifs.Fnd.ApplicationForms.Const.FIELD_Insert, false);
                this.tblVoucherPosting_colnConversionFactor.EditDataItemFlagSet(Ifs.Fnd.ApplicationForms.Const.FIELD_Update, false);
                this.tblVoucherPosting_colnParallelCurrConvFactor.EditDataItemFlagSet(Ifs.Fnd.ApplicationForms.Const.FIELD_Insert, false);
                this.tblVoucherPosting_colnParallelCurrConvFactor.EditDataItemFlagSet(Ifs.Fnd.ApplicationForms.Const.FIELD_Update, false);
             
                this.tblVoucherPosting_colsPrevAccount.Text = this.tblVoucherPosting_colsAccount.Text;
                this.tblVoucherPosting_colsPrevTaxCode.Text = this.tblVoucherPosting_colsOptionalCode.Text;
                this.tblVoucherPosting_colsPrevCurrencyCode.Text = this.tblVoucherPosting_colsCurrencyCode.Text;
                this.bIsDupl = true;

                sMode = "DUPLICATED";
                // This bug correction was rollbacked since it introduced a back calculation problem in third currency if the client has used
                // Copy paste functionality.
                // Bug 107045, begin
                //bCopy = true;
                // Bug 107045, end
                if (!(Sal.PostMsg(tblVoucherPosting_colsCurrencyCode, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam)))
                {
                    e.Return =  0;
                }
                nCurRow = Sys.TBL_MinRow;
                while (Sal.TblFindNextRow(tblVoucherPosting, ref nCurRow, Sys.ROW_New, 0))
                {
                    Sal.TblSetContext(tblVoucherPosting, nCurRow);
                    tblVoucherPosting_colsPrevTaxCode.Text = tblVoucherPosting_colsOptionalCode.Text;
                    Sal.SetFieldEdit(tblVoucherPosting_colnCurrencyAmount, false);
                    Sal.SetFieldEdit(tblVoucherPosting_colnAmount, false);
                    Sal.SetFieldEdit(tblVoucherPosting_colnThirdCurrencyAmount, false);
                    if (tblVoucherPosting_colsCurrencyCode.Text != Sys.STRING_Null)
                    {
                        if (!(Sal.SendMsg(tblVoucherPosting_colsCurrencyCode, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, 0, 0)))
                        {
                            e.Return = 0;
                        }
                    }
                    if (tblVoucherPosting_colnCurrencyDebetAmount.Number != Sys.NUMBER_Null)
                    {
                        if (!(Sal.SendMsg(tblVoucherPosting_colnCurrencyDebetAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, 0, 0)))
                        {
                            e.Return = 0;
                        }
                    }
                    else if (tblVoucherPosting_colnCurrencyCreditAmount.Number != Sys.NUMBER_Null)
                    {
                        if (!(Sal.SendMsg(tblVoucherPosting_colnCurrencyCreditAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, 0, 0)))
                        {
                            e.Return = 0;
                        }
                    }
                    else if (tblVoucherPosting_colnDebetAmount.Number != Sys.NUMBER_Null)
                    {
                        if (!(Sal.SendMsg(tblVoucherPosting_colnDebetAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, 0, 0)))
                        {
                            e.Return = 0;
                        }
                    }
                    else
                    {
                        if (!(Sal.SendMsg(tblVoucherPosting_colnCreditAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, 0, 0)))
                        {
                            e.Return = 0;
                        }
                    }
                }
                sMode = Ifs.Fnd.ApplicationForms.Const.strNULL;
                bCopyRow = true;
            }
            e.Return = this.bReturnFromDataRecordPaste;
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataSourcePopulate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherPosting_OnPM_DataSourcePopulate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                this.bManualCompleted = false;
                this.bCopyFromGL = false;
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherPosting_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (!(this.CheckTaxCode()))
            {
                e.Return = false;
                return;
            }
            this.ResetTaxAmount();
            #endregion
        }

        /// <summary>
        /// PM_DataSourceQueryFieldName event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherPosting_OnPM_DataSourceQueryFieldName(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (SalString.FromHandle(Sys.lParam) == "PROJECT_ID")
            {
                switch (Sys.wParam)
                {
                    case Vis.DT_Handle:
                        e.Return = SalWindowHandle.Null.ToNumber();
                        return;

                    default:
                        e.Return = (this.i_hWndFrame.ToNumber().ToString(0) + ".frmVoucherPosting.tblVoucherPosting_colsProjectId").ToHandle();
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
        /// PM_DataRecordRemove event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherPosting_OnPM_DataRecordRemove(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove, Sys.wParam, Sys.lParam);
                if (!(Sal.TblAnyRows(this.tblVoucherPosting, Sys.ROW_New, 0)))
                {
                    if (frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(this.i_hWndFrame)).cbUseCorrectionRows.Checked == true)
                    {
                        frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(this.i_hWndFrame)).cbCorrection.Checked = true;
                    }
                    else
                    {
                        frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(this.i_hWndFrame)).cbCorrection.Checked = false;
                    }
                }
                cChildTableFin.sCodePartValue = SalString.Null;
                cChildTableFin.sCodePartDescription = SalString.Null;
                Sal.SendMsgToChildren(this.i_hWndFrame, Const.PAM_SetCodePartValue, 0, 0);
                Sal.SendMsgToChildren(this.i_hWndFrame, Const.PAM_SetCodePartDesc, 0, 0);
                e.Return = true;
                return;
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PAM_ValidateCodePartValues event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherPosting_OnPAM_ValidateCodePartValues(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.IsNull(this.tblVoucherPosting_colsAccount))
            {
                cChildTableFin.sRequiredString = SalString.Null;
            }
            e.Return = Sal.SendClassMessage(Const.PAM_ValidateCodePartValues, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        #endregion

        #region Late Bind Methods

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalNumber vrtDataSourceActivate()
        {
            return this.DataSourceActivate();
        }
        #endregion

        #region ChildTable-tblVoucherPosting

        #region Window Variables
        public SalBoolean bTemplateOrCopyGL = false;
        public SalNumber nAmount = 0;
        public SalNumber nCurrAmount = 0;
        public SalNumber nPrevRate = 0;
        public SalString sPrevCurrType = "";
        public SalString sFormName = "";
        public SalString sMode = "";
        public SalString sParentName = "";
        public SalString sParam = "";
        public SalString sResult = "";
        public SalString sSetRateNotEnabled = "";
        public cMessage sMessage = new cMessage();
        public SalString p_sLedger = "";
        public SalString p_sAccount = "";
        public SalNumber p_nRefRowNo = 0;
        public SalNumber p_nAmount = 0;
        public SalNumber p_nCurrencyAmount = 0;
        public SalNumber p_nCurrRate = 0;
        public SalNumber p_nInternalSeq = 0;
        public SalString sPackedMessage = "";
        public SalString sTaxHandlingValue = "";
        public SalNumber nPrevCurrencyTaxAmount = 0;
        public SalNumber nPrevTaxAmount = 0;
        public SalNumber nTaxPercent = 0;
        public SalString sAmountMethod = "";
        public SalString sAmountMethodDb = "";
        public SalString sLogicalAccountType = "";
        public SalString sTempVouDate = "";
        public SalNumber nCopyRowNo = 0;
        public SalBoolean bAddInternal = false;
        public SalBoolean bManualCompleted = false;
        public SalBoolean bEditedId = false;
        public SalString sStatus = "";
        public SalString sCorrectionStatus = "";
        public SalNumber nNewInternalSequenceNumber = 0;
        public SalString sProjectOrigin = "";
        public SalString sMultipleTax = "";
        public SalString sTaxType = "";
        public SalBoolean bCurrencyAmtChanged = false;
        public SalNumber nPrevActRate = 0;
        public SalBoolean bUseVouTemplate = false;
        public SalBoolean bAmtChanged = false;
        public SalBoolean bIsDupl = false;
        public SalString p_sCorrection = "";
        public SalArray<SalString> sRecords = new SalArray<SalString>();
        public SalArray<SalString> sUnits = new SalArray<SalString>();
        public SalArray<SalString> sUserName = new SalArray<SalString>();
        public SalString sPcaExtProject = "";
        public SalArray<SalNumber> group_parallel_balance = new SalArray<SalNumber>();
        public SalArray<SalNumber> group_balance = new SalArray<SalNumber>();
        public SalArray<SalNumber> group_c_count = new SalArray<SalNumber>();
        public SalArray<SalNumber> group_d_count = new SalArray<SalNumber>();
        public SalArray<SalNumber> group_cor_sta = new SalArray<SalNumber>();
        public SalBoolean bCleared = false;
        public SalBoolean bSkipFocusCheck = false;
        public SalNumber nCalcVATLines = 0;
        public SalNumber nCountListVal = 0;
        public SalBoolean bReturnFromDataRecordPaste = false;
        public SalBoolean bCopyRow = false;
        public SalString sOptionalCode = "";
        public SalString lsAutoBal = "";
        // Bug 97225, Begin
        public SalNumber nCalculatedTaxValue = 0;
        public SalNumber nDeduct = 0;
        public SalNumber nDeductPercent = 0;
        public SalNumber nToTaxAmount = 0;
        public SalNumber nDeductibleAmount = 0;
        public SalString sCalculateTax = "";
        public SalBoolean bTaxCodeChanged = false;
        // Bug 97225, End
        // Bug 102266, Begin
        public SalString sCodePartFunc = "";
        // Bug 102266, End
        // This bug correction was rollbacked since it introduced a back calculation problem in third currency if the client has used
        // Copy paste functionality.
        // Bug 107045, Begin
        //public SalBoolean bCopy = false;
        // Bug 107045, End
        public SalString sThirdInverted = "";
        SalNumber nFinThirdConversionFactor = 0;
        SalNumber nFinThirdCurrencyRate = 0;
        SalString lsFinThirdInverted;
        SalBoolean bIsAutoBal = false;
        public SalBoolean bParallelCurrAmtChanged = false;
        SalNumber nDeductThirdCurrValue = 0;
        public SalBoolean bCalculateParallelCurrTax = true;
        public SalBoolean bCopyParallelCurrRate = true;
        #endregion

        #region Methods

        /// <summary>
        /// This is an overridden function defined in the cChildTableFin class
        /// </summary>
        /// <param name="sSqlColumn"></param>
        /// <returns></returns>
        public virtual new SalBoolean CodePartBlocked(SalString sSqlColumn)
        {
            return Ifs.Fnd.ApplicationForms.Int.PalAttrGet(sSqlColumn, tblVoucherPosting_colsCodeDemand.Text) == "S";
        }

        /// <summary>
        /// Made manipulation for copy Voucher Row, just change the flag and set column became edited
        /// </summary>
        /// <param name="bReverse"></param>
        /// <param name="bCorrection"></param>
        /// <returns></returns>
        public virtual SalNumber CopyDetailVoucher(SalBoolean bReverse, SalBoolean bCorrection)
        {
            #region Local Variables
            SalString sZero = "0";
            SalString sNull = Ifs.Fnd.ApplicationForms.Const.strNULL;
            #endregion

            #region Actions
            SalNumber nRow = Sys.TBL_MinRow;
            if (bReverse)
            {
                sStatus = "REVERSE";
            }
            else if (bCorrection)
            {
                sStatus = "CORRECTION";
            }
            else
            {
                sStatus = "NONE";
            }
            while (Sal.TblFindNextRow(tblVoucherPosting, ref nRow, 0, Sys.ROW_HideMarks))
            {
                Sal.TblSetRowFlags(tblVoucherPosting, nRow, Sys.ROW_New, true);
                Sal.TblSetContext(tblVoucherPosting, nRow);
                DbPLSQLBlock(@"&AO.INTERNAL_POSTINGS_ACCRUL_API.Copy_Internal_Posting({0} OUT,{1} IN,{2} IN,{3} IN,{4} IN,{5} IN)",
                                this.QualifiedVarBindName("nNewInternalSequenceNumber"),
                                this.tblVoucherPosting_colsCompany.QualifiedBindName,
                                this.tblVoucherPosting_colsAccount.QualifiedBindName,
                                this.tblVoucherPosting_colnInternalSeqNumber.QualifiedBindName,
                                this.QualifiedVarBindName("sStatus"),
                                this.tblVoucherPosting_colCorrection.QualifiedBindName);
           
                // Notify others that we are dirty
                if (tblVoucherPosting.i_nDataSourceState != Ifs.Fnd.ApplicationForms.Const.DATASOURCE_Changed)
                {
                    tblVoucherPosting.i_nDataSourceState = Ifs.Fnd.ApplicationForms.Const.DATASOURCE_Changed;
                    cDataSource.FromHandle(this).vrtDataSourceDetailModified(true);
                    MethodStateChanged(Ifs.Fnd.ApplicationForms.Const.CHILDTYPE_SourceMethod);
                }
                MethodStateChanged(Ifs.Fnd.ApplicationForms.Const.CHILDTYPE_ContextMethod);
                SalNumber m = 0;
                while (m < tblVoucherPosting.i_nChildCount)
                {
                    if (Sal.SendMsg(tblVoucherPosting.i_hWndChild[m], Ifs.Fnd.ApplicationForms.Const.PM_DataItemFlagQuery, Ifs.Fnd.ApplicationForms.Const.FIELD_Insert, 0))
                    {
                        Sal.SetFieldEdit(tblVoucherPosting.i_hWndChild[m], true);
                    }
                    m = m + 1;
                }
                // Bug Id 93703, Remove the currency  type setting false in setedited
                Sal.SetFieldEdit(tblVoucherPosting_colnAmount, false);

                Sal.SetFieldEdit(tblVoucherPosting_colnThirdCurrencyAmount, false);
                Sal.SetFieldEdit(tblVoucherPosting_colnCurrencyAmount, false);
                Sal.SetFieldEdit(tblVoucherPosting_colsTextId, false);

                tblVoucherPosting_colnParallelCurrConvFactor.EditDataItemSetEdited();
                if (Sal.IsNull(tblVoucherPosting_colsCurrencyType))
                {
                    tblVoucherPosting_colsCurrencyType.Text = frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfsCurrencyType.Text;
                    Sal.SetFieldEdit(tblVoucherPosting_colsCurrencyType, true);
                }
                tblVoucherPosting_colsTransCode.Text = "MANUAL";
                Sal.SetFieldEdit(tblVoucherPosting_colsTransCode, true);
                Sal.SetFieldEdit(tblVoucherPosting_colnConversionFactor, true);
                tblVoucherPosting_colnInternalSeqNumber.Number = nNewInternalSequenceNumber;
                tblVoucherPosting_colnInternalSeqNumber.EditDataItemSetEdited();
                tblVoucherPosting_colnVoucherNo.EditDataItemValueSet(1, frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfnVoucherNo.Number.ToString(0).ToHandle());
                // Set value according to copy option
                if (bReverse)
                {
                    CreateReverseVoucher();
                }
                else if (bCorrection)
                {
                    CreateCorrectionVoucher();
                }
                else
                {
                    if ((tblVoucherPosting_colnAmount.Number < 0 && tblVoucherPosting_colCorrection.Text == "N") || (tblVoucherPosting_colnAmount.Number > 0 && tblVoucherPosting_colCorrection.Text == "Y"))
                    {
                        tblVoucherPosting_colnCreditAmount.EditDataItemValueSet(1, (-tblVoucherPosting_colnAmount.Number).ToString(tblVoucherPosting_colnAccDecimalsInAmount.Number).ToHandle());
                        tblVoucherPosting_colnDebetAmount.EditDataItemValueSet(1, SalNumber.Null.ToString(tblVoucherPosting_colnAccDecimalsInAmount.Number).ToHandle());
                        // Third currency calculation
                        if (!(frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).sParallelCurrency == Ifs.Fnd.ApplicationForms.Const.strNULL))
                        {
                            tblVoucherPosting_colnThirdCurrencyCreditAmount.Number = -tblVoucherPosting_colnThirdCurrencyAmount.Number;
                            tblVoucherPosting_colnThirdCurrencyCreditAmount.EditDataItemSetEdited();
                            tblVoucherPosting_colnThirdCurrencyDebitAmount.Number = Sys.NUMBER_Null;
                            tblVoucherPosting_colnThirdCurrencyDebitAmount.EditDataItemSetEdited();
                        }                    
                        if (tblVoucherPosting_colnCurrencyAmount.Number != Sys.NUMBER_Null)
                        {
                            tblVoucherPosting_colnCurrencyCreditAmount.EditDataItemValueSet(1, (-tblVoucherPosting_colnCurrencyAmount.Number).ToString(tblVoucherPosting_colnDecimalsInAmount.Number).ToHandle());
                        }
                        tblVoucherPosting_colnCurrencyDebetAmount.EditDataItemValueSet(1, SalNumber.Null.ToString(tblVoucherPosting_colnDecimalsInAmount.Number).ToHandle());
                    }
                    else if (tblVoucherPosting_colnAmount.Number == 0 && tblVoucherPosting_colCorrection.Text == "N" && tblVoucherPosting_colnThirdCurrencyAmount.Number != 0)
                    {
                        tblVoucherPosting_colnCurrencyCreditAmount.EditDataItemValueSet(1, sNull.ToHandle());
                        tblVoucherPosting_colnCurrencyDebetAmount.EditDataItemValueSet(1, sNull.ToHandle());

                        // Third currency calculation
                        if (!(frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).sParallelCurrency == Ifs.Fnd.ApplicationForms.Const.strNULL))
                        {
                            if (tblVoucherPosting_colnThirdCurrencyAmount.Number > 0 || tblVoucherPosting_colnThirdCurrencyAmount.Number == 0)
                            {
                                tblVoucherPosting_colnThirdCurrencyDebitAmount.Number = tblVoucherPosting_colnThirdCurrencyAmount.Number;
                                tblVoucherPosting_colnThirdCurrencyDebitAmount.EditDataItemSetEdited();
                                tblVoucherPosting_colnThirdCurrencyCreditAmount.Number = Sys.NUMBER_Null;
                                tblVoucherPosting_colnThirdCurrencyCreditAmount.EditDataItemSetEdited();

                                tblVoucherPosting_colnDebetAmount.EditDataItemValueSet(1, sZero.ToHandle());
                                tblVoucherPosting_colnCreditAmount.EditDataItemValueSet(1, sNull.ToHandle());
                                
                            }
                            else
                            {
                                tblVoucherPosting_colnThirdCurrencyCreditAmount.Number = -tblVoucherPosting_colnThirdCurrencyAmount.Number;
                                tblVoucherPosting_colnThirdCurrencyCreditAmount.EditDataItemSetEdited();
                                tblVoucherPosting_colnThirdCurrencyDebitAmount.Number = Sys.NUMBER_Null;
                                tblVoucherPosting_colnThirdCurrencyDebitAmount.EditDataItemSetEdited();

                                tblVoucherPosting_colnCreditAmount.EditDataItemValueSet(1, sZero.ToHandle());
                                tblVoucherPosting_colnDebetAmount.EditDataItemValueSet(1, sNull.ToHandle());
                            }
                        }
                    }
                    else if (tblVoucherPosting_colnAmount.Number == 0 && tblVoucherPosting_colCorrection.Text == "Y" && tblVoucherPosting_colnThirdCurrencyAmount.Number != 0)
                    {
                        tblVoucherPosting_colnCurrencyCreditAmount.EditDataItemValueSet(1, sNull.ToHandle());
                        tblVoucherPosting_colnCurrencyDebetAmount.EditDataItemValueSet(1, sNull.ToHandle());

                        // Third currency calculation
                        if (!(frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).sParallelCurrency == Ifs.Fnd.ApplicationForms.Const.strNULL))
                        {
                            if (tblVoucherPosting_colnThirdCurrencyAmount.Number > 0 || tblVoucherPosting_colnThirdCurrencyAmount.Number == 0)
                            {
                                tblVoucherPosting_colnThirdCurrencyCreditAmount.Number = -tblVoucherPosting_colnThirdCurrencyAmount.Number;
                                tblVoucherPosting_colnThirdCurrencyCreditAmount.EditDataItemSetEdited();
                                tblVoucherPosting_colnThirdCurrencyDebitAmount.Number = Sys.NUMBER_Null;
                                tblVoucherPosting_colnThirdCurrencyDebitAmount.EditDataItemSetEdited();

                                tblVoucherPosting_colnCreditAmount.EditDataItemValueSet(1, sZero.ToHandle());
                                tblVoucherPosting_colnDebetAmount.EditDataItemValueSet(1, sNull.ToHandle());
                            }
                            else
                            {
                                tblVoucherPosting_colnThirdCurrencyDebitAmount.Number = tblVoucherPosting_colnThirdCurrencyAmount.Number;
                                tblVoucherPosting_colnThirdCurrencyDebitAmount.EditDataItemSetEdited();
                                tblVoucherPosting_colnThirdCurrencyCreditAmount.Number = Sys.NUMBER_Null;
                                tblVoucherPosting_colnThirdCurrencyCreditAmount.EditDataItemSetEdited();

                                tblVoucherPosting_colnDebetAmount.EditDataItemValueSet(1, sZero.ToHandle());
                                tblVoucherPosting_colnCreditAmount.EditDataItemValueSet(1, sNull.ToHandle());
                            }
                        }

                     }
                     else
                     {
                        tblVoucherPosting_colnDebetAmount.EditDataItemValueSet(1, tblVoucherPosting_colnAmount.Number.ToString(tblVoucherPosting_colnAccDecimalsInAmount.Number).ToHandle());
                        tblVoucherPosting_colnCreditAmount.EditDataItemValueSet(1, SalNumber.Null.ToString(tblVoucherPosting_colnDecimalsInAmount.Number).ToHandle());
                        // Third currency calculation
                        if (!(frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).sParallelCurrency == Ifs.Fnd.ApplicationForms.Const.strNULL))
                        {
                            tblVoucherPosting_colnThirdCurrencyDebitAmount.Number = tblVoucherPosting_colnThirdCurrencyAmount.Number;
                            tblVoucherPosting_colnThirdCurrencyDebitAmount.EditDataItemSetEdited();
                            tblVoucherPosting_colnThirdCurrencyCreditAmount.Number = Sys.NUMBER_Null;
                            tblVoucherPosting_colnThirdCurrencyCreditAmount.EditDataItemSetEdited();
                        }
                        if (tblVoucherPosting_colnCurrencyAmount.Number != Sys.NUMBER_Null)
                        {
                            tblVoucherPosting_colnCurrencyDebetAmount.EditDataItemValueSet(1, tblVoucherPosting_colnCurrencyAmount.Number.ToString(tblVoucherPosting_colnDecimalsInAmount.Number).ToHandle());
                        }
                        tblVoucherPosting_colnCurrencyCreditAmount.EditDataItemValueSet(1, SalNumber.Null.ToString(tblVoucherPosting_colnDecimalsInAmount.Number).ToHandle());
                    }
                }
            }
            

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean CopyGLVouRow()
        {
            #region Local Variables
            SalString IsSelect = "";
            SalString IsSelect2 = "";
            SalString IsSelect3 = "";
            SalString IsTaxSelect = "";
            SalString IsTaxSelect2 = "";
            SalString IsTaxSelect3 = "";
            SalNumber nInd = 0;
            SalNumber nIndTax = 0;
            SalSqlHandle hSql = SalSqlHandle.Null;
            SalSqlHandle hSqlTax = SalSqlHandle.Null;
            // Bug 102266 - Moved sCodePartFunc
            SalNumber nTempVal = 0;
            SalNumber nCount = 0;
            #endregion

            #region Actions
            using (new SalContext(tblVoucherPosting))
            {
                sFormName = ":i_hWndFrame." + Ifs.Fnd.ApplicationForms.Int.QualifiedItemNameGet(i_hWndSelf) + ".";
                sParentName = ":i_hWndParent." + Ifs.Fnd.ApplicationForms.Int.QualifiedItemNameGet(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)) + ".";
                sCodePartFunc = Var.FinlibServices.GetCodePartFunction("CURR");
                nCopyRowNo = SalNumber.Null;
                // Bug  102266, Begin
                IsSelect = " SELECT COMPANY, ROW_GROUP_ID, " + "ACCOUNT, " + "DECODE( '" + sCodePartFunc + "' ,'B', DECODE( CODE_B, NULL,NULL, DECODE(&AO.Account_API.Get_Currency_Balance(COMPANY, ACCOUNT), 'Y', NULL, CODE_B)) , CODE_B)," + "DECODE( '" +
                sCodePartFunc + "' ,'C', DECODE( CODE_C, NULL,NULL, DECODE(&AO.Account_API.Get_Currency_Balance(COMPANY, ACCOUNT), 'Y', NULL, CODE_C)) , CODE_C)," + "DECODE( '" + sCodePartFunc + "' ,'D', DECODE( CODE_D, NULL,NULL, DECODE(&AO.Account_API.Get_Currency_Balance(COMPANY, ACCOUNT), 'Y', NULL, CODE_D)) , CODE_D)," +
                "DECODE( '" + sCodePartFunc + "' ,'E', DECODE( CODE_E, NULL,NULL, DECODE(&AO.Account_API.Get_Currency_Balance(COMPANY, ACCOUNT), 'Y', NULL, CODE_E)) , CODE_E)," + "DECODE( '" + sCodePartFunc + "' ,'F', DECODE( CODE_F, NULL,NULL, DECODE(&AO.Account_API.Get_Currency_Balance(COMPANY, ACCOUNT), 'Y', NULL, CODE_F)) , CODE_F)," +
                "DECODE( '" + sCodePartFunc + "' ,'G', DECODE( CODE_G, NULL,NULL, DECODE(&AO.Account_API.Get_Currency_Balance(COMPANY, ACCOUNT), 'Y', NULL, CODE_G)) , CODE_G)," + "DECODE( '" + sCodePartFunc + "' ,'H', DECODE( CODE_H, NULL,NULL, DECODE(&AO.Account_API.Get_Currency_Balance(COMPANY, ACCOUNT), 'Y', NULL, CODE_H)) , CODE_H)," +
                "DECODE( '" + sCodePartFunc + "' ,'I',  DECODE( CODE_I, NULL,NULL, DECODE(&AO.Account_API.Get_Currency_Balance(COMPANY, ACCOUNT), 'Y', NULL, CODE_I)) , CODE_I)," + "DECODE( '" + sCodePartFunc + "' ,'J', DECODE( CODE_J, NULL,NULL, DECODE(&AO.Account_API.Get_Currency_Balance(COMPANY, ACCOUNT), 'Y', NULL, CODE_J)) , CODE_J)," +
                " ACCOUNT_DESC, CODE_B_DESC, CODE_C_DESC, CODE_D_DESC, CODE_E_DESC, CODE_F_DESC, CODE_G_DESC, CODE_H_DESC, CODE_I_DESC, CODE_J_DESC, " +
                "TRANS_CODE, CURRENCY_DEBET_AMOUNT, CURRENCY_CREDIT_AMOUNT, CURRENCY_AMOUNT," + "DEBET_AMOUNT, CREDIT_AMOUNT, AMOUNT, CORRECTION, CURRENCY_CODE, CONVERSION_FACTOR, QUANTITY," + "PROCESS_CODE, DELIV_TYPE_ID," + cSessionManager.c_sDbPrefix + "VOUCHER_ROW_API.Get_Delivery_Type_Description(COMPANY, DELIV_TYPE_ID)," + "OPTIONAL_CODE, PROJECT_ACTIVITY_ID, TEXT, ROW_NO, CURRENCY_RATE," +
                "TRANS_CODE , AUTO_TAX_VOU_ENTRY ,REFERENCE_NUMBER,REFERENCE_SERIE"
                + "," + "PARALLEL_CURRENCY_RATE," + "PARALLEL_CONVERSION_FACTOR," + "THIRD_CURRENCY_DEBIT_AMOUNT, THIRD_CURRENCY_CREDIT_AMOUNT, NVL(THIRD_CURRENCY_DEBIT_AMOUNT,0) - NVL(THIRD_CURRENCY_CREDIT_AMOUNT,0)," + cSessionManager.c_sDbPrefix + "ACCOUNT_API.Is_Stat_Account(COMPANY,ACCOUNT)";                     
                // Bug 102266, End

                // Bug id 111253, begin, Added ORDER BY ROW_NO 
                IsSelect2 = " INTO " + sFormName + "tblVoucherPosting_colsCompany," + sFormName + "tblVoucherPosting_colnRowGroupId, " + sFormName + "tblVoucherPosting_colsAccount," + sFormName + "tblVoucherPosting_colsCodeB," + sFormName + "tblVoucherPosting_colsCodeC," + sFormName + "tblVoucherPosting_colsCodeD," + sFormName + "tblVoucherPosting_colsCodeE," + sFormName + "tblVoucherPosting_colsCodeF," +
                sFormName + "tblVoucherPosting_colsCodeG," + sFormName + "tblVoucherPosting_colsCodeH," + sFormName + "tblVoucherPosting_colsCodeI," + sFormName + "tblVoucherPosting_colsCodeJ," + sFormName + "tblVoucherPosting_colsAccountDesc," + sFormName + "tblVoucherPosting_colsCodeBDesc," + sFormName + "tblVoucherPosting_colsCodeCDesc," + sFormName + "tblVoucherPosting_colsCodeDDesc," + sFormName +
                "tblVoucherPosting_colsCodeEDesc," + sFormName + "tblVoucherPosting_colsCodeFDesc," + sFormName + "tblVoucherPosting_colsCodeGDesc," + sFormName + "tblVoucherPosting_colsCodeHDesc," + sFormName + "tblVoucherPosting_colsCodeIDesc, " + sFormName + "tblVoucherPosting_colsCodeJDesc," + sFormName + "tblVoucherPosting_colsTransCode," + sFormName + "tblVoucherPosting_colnCurrencyDebetAmount," +
                sFormName + "tblVoucherPosting_colnCurrencyCreditAmount," + sFormName + "tblVoucherPosting_colnCurrencyAmount," + sFormName + "tblVoucherPosting_colnDebetAmount," + sFormName + "tblVoucherPosting_colnCreditAmount," + sFormName + "tblVoucherPosting_colnAmount," + sFormName + "tblVoucherPosting_colCorrection," + sFormName + "tblVoucherPosting_colsCurrencyCode," +
                sFormName + "tblVoucherPosting_colnConversionFactor," + sFormName + "tblVoucherPosting_colnQuantity," + sFormName + "tblVoucherPosting_colsProcessCode," + sFormName + "tblVoucherPosting_colsDeliveryTypeId," + sFormName + "tblVoucherPosting_colsDeliveryTypeDescription," + sFormName + "tblVoucherPosting_colsOptionalCode," + sFormName + "tblVoucherPosting_colnProjectActivityId," + sFormName + "tblVoucherPosting_colsText," + sFormName + "nCopyRowNo," + sFormName +
                "tblVoucherPosting_colnCurrencyRate," + sFormName + "tblVoucherPosting_colsTransCode," + sFormName + "tblVoucherPosting_colsAutoTaxVouEntry," + sFormName + "tblVoucherPosting_colsReferenceNumber," + sFormName + "tblVoucherPosting_colsReferenceSerie" + "," +
                sFormName + "tblVoucherPosting_colnParallelCurrRate," + sFormName + "tblVoucherPosting_colnParallelCurrConvFactor," + sFormName + "tblVoucherPosting_colnThirdCurrencyDebitAmount," + sFormName + "tblVoucherPosting_colnThirdCurrencyCreditAmount," + sFormName + "tblVoucherPosting_colnThirdCurrencyAmount," + sFormName + "tblVoucherPosting_colIsStatAccount";
                IsSelect3 = " FROM " + cSessionManager.c_sDbPrefix + "GEN_LED_VOUCHER_ROW2" + " WHERE COMPANY = " + sParentName + "dfsCompany AND " + cSessionManager.c_sDbPrefix + "VOUCHER_TYPE_API.Get_Voucher_Group(COMPANY, VOUCHER_TYPE) in ('M','Q') AND " +
                " ACCOUNTING_YEAR = " + sParentName + "nYear  AND " + " VOUCHER_NO = " + sParentName + "nVouNumber  AND " + " VOUCHER_TYPE = " + sParentName + "sGlCpyVouType AND " + " ( TRANS_CODE IN ('MANUAL', 'INTERIM', 'EXTERNAL', 'External') OR" +                    
                " TRANS_CODE LIKE '%MANUAL' OR" + " AUTO_TAX_VOU_ENTRY = 'EXT') AND" + " (AUTO_TAX_VOU_ENTRY = 'FALSE' OR " + "AUTO_TAX_VOU_ENTRY = 'EXT')" + 
                " ORDER BY ROW_NO " ;
                // Bug id 111253, end

                bTemplateOrCopyGL = true;
                this.bCopyFromGL = true;
                // Bug Id 80054, Begin
                bCopyRow = true;
                // Bug Id 80054, End
                if (DbConnect(ref hSql))
                {
                    if (DbPrepareAndExecute(hSql, IsSelect + IsSelect2 + IsSelect3))
                    {
                        this.DataRecordNew(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
                        nTempVal = tblVoucherPosting_colnRowGroupId.Number;
                        while (DbFetchNext(hSql, ref nInd))
                        {
                            if (nCount == 0)
                            {
                                tblVoucherPosting_colnRowGroupId.Number = nTempVal;
                                tblVoucherPosting_colnRowGroupId.EditDataItemSetEdited();
                            }
                            else
                            {
                                tblVoucherPosting_colnRowGroupId.Number = nTempVal;
                                tblVoucherPosting_colnRowGroupId.EditDataItemSetEdited();
                            }
                            // Bug 102106, Begin - Modified the IF condition
                            if (((SalString)this.tblVoucherPosting_colsTransCode.Text).ToUpper() != "EXTERNAL" && this.tblVoucherPosting_colsAutoTaxVouEntry.Text == "EXT" && this.tblVoucherPosting_colsOptionalCode.Text != Ifs.Fnd.ApplicationForms.Const.strNULL)                                 
                            {
                                DataSourceClearIt(0);
                                Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_ExternalTransMessage, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                                return false;
                            }
                            // Bug 102106, End
                            tblVoucherPosting.i_nDataSourceState = Ifs.Fnd.ApplicationForms.Const.DATASOURCE_Changed;
                            this.tblVoucherPosting_colsTransCode.Text = "MANUAL";
                                
                            // Bug 102266, Begin - Removed the desc when the codeparts are null  ( e.g for currency balance )                             
                            if (tblVoucherPosting_colsCodeB.Text == Ifs.Fnd.ApplicationForms.Const.strNULL)
                            {
                                Sal.ClearField(tblVoucherPosting_colsCodeBDesc);
                            }
                            if (tblVoucherPosting_colsCodeC.Text == Ifs.Fnd.ApplicationForms.Const.strNULL)
                            {
                                Sal.ClearField(tblVoucherPosting_colsCodeCDesc);
                            }
                            if (tblVoucherPosting_colsCodeD.Text == Ifs.Fnd.ApplicationForms.Const.strNULL)
                            {
                                Sal.ClearField(tblVoucherPosting_colsCodeDDesc);
                            }
                            if (tblVoucherPosting_colsCodeE.Text == Ifs.Fnd.ApplicationForms.Const.strNULL)
                            {
                                Sal.ClearField(tblVoucherPosting_colsCodeEDesc);
                            }
                            if (tblVoucherPosting_colsCodeF.Text == Ifs.Fnd.ApplicationForms.Const.strNULL)
                            {
                                Sal.ClearField(tblVoucherPosting_colsCodeFDesc);
                            }
                            if (tblVoucherPosting_colsCodeG.Text == Ifs.Fnd.ApplicationForms.Const.strNULL)
                            {
                                Sal.ClearField(tblVoucherPosting_colsCodeGDesc);
                            }
                            if (tblVoucherPosting_colsCodeH.Text == Ifs.Fnd.ApplicationForms.Const.strNULL)
                            {
                                Sal.ClearField(tblVoucherPosting_colsCodeHDesc);
                            }
                            if (tblVoucherPosting_colsCodeI.Text == Ifs.Fnd.ApplicationForms.Const.strNULL)
                            {
                                Sal.ClearField(tblVoucherPosting_colsCodeIDesc);
                            }
                            if (tblVoucherPosting_colsCodeJ.Text == Ifs.Fnd.ApplicationForms.Const.strNULL)
                            {
                                Sal.ClearField(tblVoucherPosting_colsCodeJDesc);
                            }
                            // Bug 102266, End                                   
                                
                            if (!(Sal.IsNull(tblVoucherPosting_colsOptionalCode)))
                            {
                                GetTaxType();
                                if (tblVoucherPosting_colsTaxType.Text == "NOTAX")
                                {
                                    tblVoucherPosting_colsTaxDirection.Text = frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).sTaxDirectionNoTax;
                                }
                                else
                                {                                        
                                    if (!(DbPLSQLBlock(@"{0} := &AO.Account_API.Get_Logical_Account_Type_Db({1} IN,{2} IN )",
                                        this.QualifiedVarBindName("sLogicalAccountType"),this.tblVoucherPosting_colsCompany.QualifiedBindName,this.tblVoucherPosting_colsAccount.QualifiedBindName )))
                                    {
                                        return false;
                                    }
                                    
                                    if ((sLogicalAccountType == "A") || (sLogicalAccountType == "C"))
                                    {
                                        tblVoucherPosting_colsTaxDirection.Text = frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).sTaxDirectionReceived;
                                    }
                                    else if ((sLogicalAccountType == "L") || (sLogicalAccountType == "R") || (sLogicalAccountType == "S") || (sLogicalAccountType == "O"))
                                    {
                                        tblVoucherPosting_colsTaxDirection.Text = frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).sTaxDirectionDisbursed;
                                    }
                                }
                                if (tblVoucherPosting_colsTaxType.Text == "VAT")
                                {
                                    IsTaxSelect = " SELECT CURRENCY_AMOUNT, AMOUNT, THIRD_CURRENCY_AMOUNT";
                                    IsTaxSelect2 = " INTO " + sFormName + "tblVoucherPosting_colnCurrencyTaxAmount," + sFormName + "tblVoucherPosting_colnTaxAmount," + sFormName + "tblVoucherPosting_colnParallelCurrTaxAmount";
                                    IsTaxSelect3 = " FROM " + cSessionManager.c_sDbPrefix + "GEN_LED_VOUCHER_ROW2" + " WHERE COMPANY = " + sParentName + "dfsCompany AND " + cSessionManager.c_sDbPrefix + "VOUCHER_TYPE_API.Get_Voucher_Group(COMPANY, VOUCHER_TYPE)  IN ('M','Q') AND " +
                                    " ACCOUNTING_YEAR = " + sParentName + "nYear  AND " + " VOUCHER_NO = " + sParentName + "nVouNumber  AND " + " VOUCHER_TYPE = " + sParentName + "sGlCpyVouType AND " + " REFERENCE_ROW_NO = " + sFormName + "nCopyRowNo AND " + " TRANS_CODE IN ('AP1', 'AP2', 'AP3', 'AP4')";
                                    if (DbConnect(ref hSqlTax))
                                    {
                                        if (DbPrepareAndExecute(hSqlTax, IsTaxSelect + IsTaxSelect2 + IsTaxSelect3))
                                        {
                                            DbFetchNext(hSqlTax, ref nIndTax);
                                        }
                                        DbDisconnect(hSqlTax);
                                    }

                                    if (sAmountMethodDb == "GROSS")
                                    {
                                        // Bug 97225, Begin - calculating Tax in not needed since tax values are not changed only the amount values are changed in SetAnotherValue
                                        sCalculateTax = "FALSE";
										// Bug 112503, Begin - Removed GetGrossAmount() and added code
                                        tblVoucherPosting_colnCurrencyAmount.Number = tblVoucherPosting_colnCurrencyAmount.Number + tblVoucherPosting_colnCurrencyTaxAmount.Number;
										// Bug 112503, End
                                        if ((tblVoucherPosting_colnCurrencyAmount.Number < 0 && tblVoucherPosting_colCorrection.Text == "Y") || (tblVoucherPosting_colnCurrencyAmount.Number >= 0 && tblVoucherPosting_colCorrection.Text == "N"))
                                        {
                                            tblVoucherPosting_colnCurrencyDebetAmount.Number = SetAnotherValue(tblVoucherPosting_colnCurrencyAmount.Number, tblVoucherPosting_colnDebetAmount, "CURRENT_AMOUNT", ref nCalculatedTaxValue);
                                            Sal.SendMsg(tblVoucherPosting_colnCurrencyCreditAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, SalNumber.Null.ToString(0).ToHandle());
                                            Sal.SendMsg(tblVoucherPosting_colnCreditAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, SalNumber.Null.ToString(0).ToHandle());
                                        }
                                        else
                                        {
                                            tblVoucherPosting_colnCurrencyCreditAmount.Number = -SetAnotherValue(tblVoucherPosting_colnCurrencyAmount.Number, tblVoucherPosting_colnCreditAmount, "CURRENT_AMOUNT", ref nCalculatedTaxValue);
                                            Sal.SendMsg(tblVoucherPosting_colnCurrencyDebetAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, SalNumber.Null.ToString(0).ToHandle());
                                            Sal.SendMsg(tblVoucherPosting_colnDebetAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, SalNumber.Null.ToString(0).ToHandle());
                                        }
                                        sCalculateTax = Ifs.Fnd.ApplicationForms.Const.strNULL;
                                        // Bug 97225, End
                                    }
                                }
                                else
                                {
                                    tblVoucherPosting_colnCurrencyTaxAmount.Number = 0;
                                    tblVoucherPosting_colnTaxAmount.Number = 0;
                                }
                            }
                            else
                            {
                                if (!(Sal.IsNull(tblVoucherPosting_colnAmount)) && (tblVoucherPosting_colnAmount.Number != 0))
                                {
                                    tblVoucherPosting_colnCurrencyTaxAmount.Number = 0;
                                    tblVoucherPosting_colnTaxAmount.Number = 0;
                                }
                            }

                            if (frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).sParallelCurrency != Ifs.Fnd.ApplicationForms.Const.strNULL)
                            {

                                DbPLSQLBlock(@"{0} := &AO.Company_Finance_API.Get_Parallel_Rate_Type({1} IN );", 
                                                this.tblVoucherPosting_colnParallelCurrRateType.QualifiedBindName,
                                                this.tblVoucherPosting_colsCompany.QualifiedBindName);

                                tblVoucherPosting_colnParallelCurrRateType.EditDataItemSetEdited();
                            }
                            
                            tblVoucherPosting_colsPrevAccount.Text = tblVoucherPosting_colsAccount.Text;
                            if (tblVoucherPosting_colsAutoTaxVouEntry.Text == "EXT")
                            {
                                tblVoucherPosting_colsAutoTaxVouEntry.Text = "FALSE";
                            }
                            tblVoucherPosting_colsPrevTaxCode.Text = tblVoucherPosting_colsOptionalCode.Text;
                            tblVoucherPosting_colsPrevCurrencyCode.Text = tblVoucherPosting_colsCurrencyCode.Text;
                            if (frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).bReverse)
                            {
                                CreateReverseVoucher();
                            }
                            else if (frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).cbCorrection.Checked || frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).bCorrection)
                            {
                                CreateCorrectionVoucher();
                            }
                            if (!(Sal.IsNull(tblVoucherPosting_colnDebetAmount)))
                            {
                                tblVoucherPosting_colnPrevCurrencyAmount.Number = tblVoucherPosting_colnCurrencyDebetAmount.Number;
                                tblVoucherPosting_colnPrevAmount.Number = tblVoucherPosting_colnDebetAmount.Number;
                            }
                            else if (!(Sal.IsNull(tblVoucherPosting_colnCreditAmount)))
                            {
                                tblVoucherPosting_colnPrevCurrencyAmount.Number = tblVoucherPosting_colnCurrencyCreditAmount.Number;
                                tblVoucherPosting_colnPrevAmount.Number = tblVoucherPosting_colnCreditAmount.Number;
                            }
                            if (tblVoucherPosting_colsTransCode.Text == "INTERIM")
                            {
                                tblVoucherPosting_colsTransCode.Text = "MANUAL";
                            }
                            if (Sal.IsNull(this.tblVoucherPosting_colnCurrencyTaxAmount))
                            {
                                ResetTaxAmount();
                                this.ResetTaxAmountFromCurrTaxAmount(this.tblVoucherPosting_colnCurrencyTaxAmount.Number, this.tblVoucherPosting_colnCurrencyTaxAmount.Number + 1);
                            }

                            if (this.tblVoucherPosting_colnParallelCurrRate.Number != SalNumber.Null)
                            {
                                this.i_nFinThirdCurrencyRate = this.tblVoucherPosting_colnParallelCurrRate.Number;
                                this.i_nFinThirdConversionFactor = this.tblVoucherPosting_colnParallelCurrConvFactor.Number;
                            }

                            if (this.tblVoucherPosting_colnCurrencyRate.Number != SalNumber.Null)
                            {
                                tblVoucherPosting_colnActCurrencyRate.Number = tblVoucherPosting_colnCurrencyRate.Number;
                            }
                                
                            CalcualteParallelCurrTaxValue("RATE");                                
                            SetAllEdited();
                            nCount = nCount + 1;
                            this.DataRecordNew(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
                            nTempVal = tblVoucherPosting_colnRowGroupId.Number;
                        }
                    }
                    this.DataRecordRemove(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
                    DbDisconnect(hSql);
                }
                bTemplateOrCopyGL = false;
                return true;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber CreateCorrectionVoucher()
        {
            if (tblVoucherPosting_colnCurrencyAmount.Number != Sys.NUMBER_Null)
            {
                tblVoucherPosting_colnCurrencyAmount.EditDataItemValueSet(0, (-tblVoucherPosting_colnCurrencyAmount.Number).ToString(tblVoucherPosting_colnDecimalsInAmount.Number).ToHandle());
            }
            tblVoucherPosting_colnAmount.EditDataItemValueSet(0, (-tblVoucherPosting_colnAmount.Number).ToString(tblVoucherPosting_colnAccDecimalsInAmount.Number).ToHandle());
            tblVoucherPosting_colnThirdCurrencyAmount.Number = -tblVoucherPosting_colnThirdCurrencyAmount.Number;
            if (tblVoucherPosting_colCorrection.Text == "Y")
            {
                tblVoucherPosting_colCorrection.EditDataItemValueSet(0, ((SalString)"N").ToHandle());
            }
            else
            {
                tblVoucherPosting_colCorrection.EditDataItemValueSet(0, ((SalString)"Y").ToHandle());
                frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).cbCorrection.Checked = true;
            }
            if (tblVoucherPosting_colnDebetAmount.Number == Sys.NUMBER_Null)
            {
                tblVoucherPosting_colnCreditAmount.EditDataItemValueSet(1, (-tblVoucherPosting_colnCreditAmount.Number).ToString(tblVoucherPosting_colnAccDecimalsInAmount.Number).ToHandle());
                tblVoucherPosting_colnThirdCurrencyCreditAmount.Number = -tblVoucherPosting_colnThirdCurrencyCreditAmount.Number;
                tblVoucherPosting_colnThirdCurrencyCreditAmount.EditDataItemSetEdited();
                if (tblVoucherPosting_colnCurrencyCreditAmount.Number != Sys.NUMBER_Null)
                {
                    tblVoucherPosting_colnCurrencyCreditAmount.EditDataItemValueSet(1, (-tblVoucherPosting_colnCurrencyAmount.Number).ToString(tblVoucherPosting_colnDecimalsInAmount.Number).ToHandle());
                }
            }
            else
            {
                tblVoucherPosting_colnDebetAmount.EditDataItemValueSet(1, (-tblVoucherPosting_colnDebetAmount.Number).ToString(tblVoucherPosting_colnAccDecimalsInAmount.Number).ToHandle());
                tblVoucherPosting_colnThirdCurrencyDebitAmount.Number = -tblVoucherPosting_colnThirdCurrencyDebitAmount.Number;
                tblVoucherPosting_colnThirdCurrencyDebitAmount.EditDataItemSetEdited();
                if (tblVoucherPosting_colnCurrencyDebetAmount.Number != Sys.NUMBER_Null)
                {
                    tblVoucherPosting_colnCurrencyDebetAmount.EditDataItemValueSet(1, tblVoucherPosting_colnCurrencyAmount.Number.ToString(tblVoucherPosting_colnDecimalsInAmount.Number).ToHandle());
                }
            }
            if (tblVoucherPosting_colnCurrencyTaxAmount.Number != Sys.NUMBER_Null)
            {
                tblVoucherPosting_colnCurrencyTaxAmount.Number = -tblVoucherPosting_colnCurrencyTaxAmount.Number;
                tblVoucherPosting_colnCurrencyTaxAmount.EditDataItemSetEdited();
            }
            if (tblVoucherPosting_colnTaxAmount.Number != Sys.NUMBER_Null)
            {
                tblVoucherPosting_colnTaxAmount.Number = -tblVoucherPosting_colnTaxAmount.Number;
                tblVoucherPosting_colnTaxAmount.EditDataItemSetEdited();
            }

            if (tblVoucherPosting_colnParallelCurrTaxAmount.Number != Sys.NUMBER_Null)
            {
                tblVoucherPosting_colnParallelCurrTaxAmount.Number = -tblVoucherPosting_colnParallelCurrTaxAmount.Number;
                tblVoucherPosting_colnParallelCurrTaxAmount.EditDataItemSetEdited();
            }
            tblVoucherPosting_colnQuantity.Number = -tblVoucherPosting_colnQuantity.Number;
            tblVoucherPosting_colnQuantity.EditDataItemSetEdited();
            

            return 0;
         
        }

        /// <summary>
        /// Checks the current record for required fields
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean DataRecordCheckRequired()
        {
            #region Local Variables
            SalNumber n = 0;
            SalNumber nCurrenctRow = 0;
            SalString sSqlColumn = "";
            SalNumber nValueForTax = 0;
            SalNumber nCalculateTaxValue = 0;
            SalNumber nCalculateAccTaxValue = 0;

            SalNumber nCalcculateParallelTaxValue = 0;
            SalNumber nCalculateParallelTaxValue = 0;
            SalNumber nThirdCurrRate = 0;
            #endregion

            #region Actions
            using (new SalContext(tblVoucherPosting))
            {
                // (-)Ersruk Twin Peaks,Balance Sheet by Project, Start
                // If ( tblVoucherPosting_colsProjectActivityIdEnabled = 'Y')  AND SalIsNull( tblVoucherPosting_colnProjectActivityId ) AND Security.IsViewAvailable('PROJECT_ACTIVITY')
                // Call DataRecordShowRequired( tblVoucherPosting_colnProjectActivityId )
                // Return FALSE
                // (-)Ersruk Twin Peaks,Balance Sheet by Project, End
                if (frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfsRowGroupValidation.Text == "Y")
                {
                    if (Sal.IsNull(tblVoucherPosting_colnRowGroupId))
                    {
                        DataRecordShowRequired(tblVoucherPosting_colnRowGroupId);
                        return false;
                    }
                }
                if (bTemplateOrCopyGL == true)
                {
                    return true;
                }
                else
                {
                    // This bug correction was rollbacked since it introduced a back calculation problem in third currency if the client has used
                    // Copy paste functionality.

                    // Bug 107045, begin
                    //if (bCopy == true)
                    //{
                    //    Sal.SendMsg(tblVoucherPosting_colnCurrencyDebetAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, 0, 0);
                    //    Sal.SendMsg(tblVoucherPosting_colnCurrencyCreditAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, 0, 0);
                    //    Sal.SendMsg(tblVoucherPosting_colnCreditAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, 0, 0);
                    //    Sal.SendMsg(tblVoucherPosting_colnDebetAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, 0, 0);
                    //}
                    // Bug 107045, end
                    if (frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).lsAutoBal == "Y")
                    {
                        if ((Sal.IsNull(tblVoucherPosting_colnAmount) || tblVoucherPosting_colnAmount.Number == 0) && this.dfnBalance.Number != 0)
                        {
                            if (!(IsSameCurrCode()))
                            {
                                return false;
                            }

                            nCalculateTaxValue = 0;
                            nCalculateAccTaxValue = 0;
                            nCalculateParallelTaxValue = 0;                                
                            SetTaxValueAutoBal(this.dfnBalance.Number * -1, tblVoucherPosting_colnCurrencyTaxAmount, ref nCalculateTaxValue, ref nCalculateAccTaxValue, ref nCalculateParallelTaxValue);

                            if (sAmountMethodDb == "NET")
                            {
                                tblVoucherPosting_colnCurrencyAmount.Number = (this.dfnCurrencyBalance.Number * -1) + (nCalculateTaxValue * -1);
                                tblVoucherPosting_colnAmount.Number = (this.dfnBalance.Number * -1) + (nCalculateAccTaxValue * -1);
                                tblVoucherPosting_colnThirdCurrencyAmount.Number = (this.dfnParallelCurrBalance.Number * -1) + (nCalculateParallelTaxValue * -1);
                            }
                            else if (sAmountMethodDb == "GROSS")
                            {
                                tblVoucherPosting_colnCurrencyAmount.Number = this.dfnCurrencyBalance.Number * -1;
                                tblVoucherPosting_colnAmount.Number = this.dfnBalance.Number * -1;
                                tblVoucherPosting_colnThirdCurrencyAmount.Number = this.dfnParallelCurrBalance.Number * -1;
                            }
                            this.dfnCurrencyBalance.Number = 0;
                            this.dfnBalance.Number = 0;

                            this.dfnParallelCurrBalance.Number = 0;

                            tblVoucherPosting_colnThirdCurrencyDebitAmount.Number = SalNumber.Null;
                            tblVoucherPosting_colnThirdCurrencyCreditAmount.Number = SalNumber.Null;

                            if (tblVoucherPosting_colnCurrencyAmount.Number > 0)
                            {
                                tblVoucherPosting_colnCurrencyDebetAmount.Number = tblVoucherPosting_colnCurrencyAmount.Number;
                                tblVoucherPosting_colnDebetAmount.Number = tblVoucherPosting_colnAmount.Number;
                                tblVoucherPosting_colnThirdCurrencyDebitAmount.Number = tblVoucherPosting_colnThirdCurrencyAmount.Number;
                            }
                            else
                            {
                                tblVoucherPosting_colnCurrencyCreditAmount.Number = tblVoucherPosting_colnCurrencyAmount.Number * -1;
                                tblVoucherPosting_colnCreditAmount.Number = tblVoucherPosting_colnAmount.Number * -1;
                                tblVoucherPosting_colnThirdCurrencyCreditAmount.Number = tblVoucherPosting_colnThirdCurrencyAmount.Number * -1;
                            }

                            if ((!Sal.IsNull(tblVoucherPosting_colnCurrencyAmount) && tblVoucherPosting_colnCurrencyAmount.Number != 0 && this.i_sFinParallelBaseType == "TRANSACTION_CURRENCY") || (!Sal.IsNull(tblVoucherPosting_colnAmount) && tblVoucherPosting_colnAmount.Number != 0 && this.i_sFinParallelBaseType == "ACCOUNTING_CURRENCY"))
                            {
                                if (tblVoucherPosting_colnThirdCurrencyAmount.Number != 0 && !(Sal.IsNull(tblVoucherPosting_colnThirdCurrencyAmount)))
                                {
                                    if (this.tblVoucherPosting_colsCurrencyCode.Text != this.i_sFinThirdCurrencyCode)
                                    {
                                        this.CalcualteParallelCurrencyRate(tblVoucherPosting_colnAmount.Number, tblVoucherPosting_colnCurrencyAmount.Number, tblVoucherPosting_colnThirdCurrencyAmount.Number, ref nThirdCurrRate);
                                    }
                                    tblVoucherPosting_colnParallelCurrRate.Number = nThirdCurrRate;
                                    tblVoucherPosting_colnParallelCurrRate.EditDataItemSetEdited();
                                }
                            }
                            tblVoucherPosting_colnCurrencyDebetAmount.EditDataItemSetEdited();
                            tblVoucherPosting_colnCurrencyCreditAmount.EditDataItemSetEdited();
                            tblVoucherPosting_colnDebetAmount.EditDataItemSetEdited();
                            tblVoucherPosting_colnCreditAmount.EditDataItemSetEdited();
                            tblVoucherPosting_colnThirdCurrencyDebitAmount.EditDataItemSetEdited();
                            tblVoucherPosting_colnThirdCurrencyCreditAmount.EditDataItemSetEdited();
                        }
                    }
                    if (Sal.IsNull(tblVoucherPosting_colnQuantity) || (tblVoucherPosting_colnQuantity.Number == 0))
                    {
                        if (Sal.IsNull(tblVoucherPosting_colnCurrencyAmount))
                        {
                            if (Sal.IsNull(tblVoucherPosting_colnThirdCurrencyAmount))
                            {
                                Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_VoEn_CurrAmountEmpty, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
                                return false;
                            }
                        }
                    }
                    if (!(Sal.IsNull(tblVoucherPosting_colnQuantity)))
                    {
                        if (!(Sal.IsNull(tblVoucherPosting_colnAmount)) && (tblVoucherPosting_colnAmount.Number != 0))
                        {
                            if (Sal.IsNull(tblVoucherPosting_colnCurrencyAmount))
                            {
                                Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_VoEn_CurrAmountEmpty, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
                                return false;
                            }
                        }
                    }

                    if ((!(Sal.IsNull(tblVoucherPosting_colsOptionalCode))) && (Sal.IsNull(tblVoucherPosting_colnCurrencyTaxAmount) && Sal.IsNull(tblVoucherPosting_colnParallelCurrTaxAmount)))

                    {
                        Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_Vou_CurrTaxAmountNull, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
                        return false;
                    }

                    if (!(Sal.IsNull(tblVoucherPosting_colnCurrencyAmount)) && tblVoucherPosting_colnCurrencyAmount.Number != 0 && this.i_sFinParallelBaseType != Ifs.Fnd.ApplicationForms.Const.strNULL && ((Sal.IsNull(tblVoucherPosting_colnThirdCurrencyAmount)) || tblVoucherPosting_colnThirdCurrencyAmount.Number == 0))
                    {
                        if (tblVoucherPosting_colsCurrencyCode.Text != frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfsCurrencyCode.Text)
                        {
                            Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_Vou_ParallelCurrAmountNull, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
                            return false;
                        }
                    }
                    
                    if (((cDataSource)tblVoucherPosting).DataRecordCheckRequired())
                    {
                        n = 0;
                        while (n < tblVoucherPosting.i_nChildCount)
                        {
                            if (Sal.WindowClassName(tblVoucherPosting.i_hWndChild[n]) == "cColumnCodePartFin")
                            {
                                sSqlColumn = cColumn.FromHandle(tblVoucherPosting.i_hWndChild[n]).p_sSqlColumn;
                                if (Ifs.Fnd.ApplicationForms.Int.PalAttrGet(sSqlColumn, tblVoucherPosting_colsCodeDemand.Text) == "M" && Sal.IsNull(tblVoucherPosting.i_hWndChild[n]))
                                {
                                    DataRecordShowRequired(tblVoucherPosting.i_hWndChild[n]);
                                    return false;
                                }
                            }
                            n = n + 1;
                        }
                        nCurrenctRow = Sal.TblQueryContext(tblVoucherPosting);
                        SetParentKey(nCurrenctRow);
                        return true;
                    }
                    return false;
                }
            }
            #endregion
        }

        /// <summary>
        /// Applications and the framework call the DataRecordDuplicate function
        /// to duplicate the current record in a data source.
        /// </summary>
        /// <param name="nWhat">
        /// Standard method parameter
        /// Standard method parameter. Possible values are METHOD_Inquire, METHOD_Execute, METHOD_GetType.
        /// </param>
        /// <returns>
        /// When nWhat = METHOD_Inquire: the return value is TRUE the new operation is
        /// available, FALSE otherwise.
        /// When nWhat = METHOD_Execute: the return value is TRUE if the record was successfully
        /// created, FALSE otherwise.
        /// When nWhat = METHOD_GetType, the return value is CHILDTYPE_SourceMethod.
        /// </returns>
        public virtual SalNumber DataRecordDuplicate(SalNumber nWhat)
        {
            #region Local Variables
            SalBoolean bOk = false;
            SalNumber nCurRow = 0;
            #endregion

            #region Actions

            sMode = Ifs.Fnd.ApplicationForms.Const.strNULL;
            switch (nWhat)
            {
                case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                    // Bug 77430, Begin, checked for user permission
                    return ((bool)((cChildTableFin)tblVoucherPosting).DataRecordDuplicate(nWhat)) && (((SalString)tblVoucherPosting_colsTransCode.Text).Trim().ToUpper() == "MANUAL") && frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).sAuthLevel != "ApproveOnly";
                    // Bug 77430, End
                    goto case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute;

                case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                    sMode = "DUPLICATED";
                    // Bug 97225, Begin
                    sCalculateTax = "FALSE";
                    // Bug 97225, End

                    // This bug correction was rollbacked since it introduced a back calculation problem in third currency if the client has used
                    // Copy paste functionality.
                    // Bug 107045, begin
                    //bCopy = false;
                    // Bug 107045, end

                    if (!(Sal.PostMsg(tblVoucherPosting_colsCurrencyCode, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam)))
                    {
                        return 0;
                    }
                    bOk = ((cChildTableFin)tblVoucherPosting).DataRecordDuplicate(nWhat);
                    nCurRow = Sys.TBL_MinRow;
                    while (Sal.TblFindNextRow(tblVoucherPosting, ref nCurRow, Sys.ROW_New, 0))
                    {
                        Sal.TblSetContext(tblVoucherPosting, nCurRow);
                        // Bug 97225, Begin
                        tblVoucherPosting_colsPrevTaxCode.Text = tblVoucherPosting_colsOptionalCode.Text;
                        // Bug 97225, End
                        // Bug Id 93703, Remove the currency  type setting false in setedited
                        Sal.SetFieldEdit(tblVoucherPosting_colnCurrencyAmount, false);
                        Sal.SetFieldEdit(tblVoucherPosting_colnAmount, false);

                        Sal.SetFieldEdit(tblVoucherPosting_colnThirdCurrencyAmount, false);
                        if (tblVoucherPosting_colsCurrencyCode.Text != Sys.STRING_Null)
                        {
                            if (!(Sal.SendMsg(tblVoucherPosting_colsCurrencyCode, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, 0, 0)))
                            {
                                return 0;
                            }
                        }
                        if (tblVoucherPosting_colnCurrencyDebetAmount.Number != Sys.NUMBER_Null)
                        {
                            if (!(Sal.SendMsg(tblVoucherPosting_colnCurrencyDebetAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, 0, 0)))
                            {
                                return 0;
                            }
                        }
                        else if (tblVoucherPosting_colnCurrencyCreditAmount.Number != Sys.NUMBER_Null)
                        {
                            if (!(Sal.SendMsg(tblVoucherPosting_colnCurrencyCreditAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, 0, 0)))
                            {
                                return 0;
                            }
                        }
                        else if (tblVoucherPosting_colnDebetAmount.Number != Sys.NUMBER_Null)
                        {
                            if (!(Sal.SendMsg(tblVoucherPosting_colnDebetAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, 0, 0)))
                            {
                                return 0;
                            }
                        }
                        else
                        {
                            if (!(Sal.SendMsg(tblVoucherPosting_colnCreditAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, 0, 0)))
                            {
                                return 0;
                            }
                        }
                    }
                    sMode = Ifs.Fnd.ApplicationForms.Const.strNULL;
                    // Bug 97225, Begin
                    sCalculateTax = Ifs.Fnd.ApplicationForms.Const.strNULL;
                    // Bug 97225, End
                    // Bug Id 80054, Begin
                    bCopyRow = true;
                    // Bug Id 80054, End
                    return bOk;

                case Ifs.Fnd.ApplicationForms.Const.METHOD_GetType:
                    return Ifs.Fnd.ApplicationForms.Const.CHILDTYPE_SourceMethod;
            }
            return 0;
            #endregion
        }
      
    
        public virtual SalNumber DataRecordGetDefaults()
        {
            if (frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).cbCorrection.Checked)
            {
                tblVoucherPosting_colCorrection.Text = "Y";
            }
            else
            {
                tblVoucherPosting_colCorrection.Text = "N";
            }
            tblVoucherPosting_colnAccountingPeriod.EditDataItemValueSet(1, frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfnAccountingPeriod.Number.ToString(0).ToHandle());
            tblVoucherPosting_colnAmount.EditDataItemValueSet(0, ((SalNumber)0).ToString(frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).nDecimalsInAmount).ToHandle());
            // Bug Id 93703, Begin Set the currency  type field to TRUE.
            tblVoucherPosting_colsCurrencyType.EditDataItemValueSet(1, ((SalString)frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfsCurrencyType.Text).ToHandle());
            // Bug Id 93703, End
            tblVoucherPosting_colnDecimalsInAmount.EditDataItemValueSet(0, frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).nDecimalsInAmount.ToString(0).ToHandle());
            tblVoucherPosting_colnAccDecimalsInAmount.EditDataItemValueSet(0, frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).nDecimalsInAmount.ToString(0).ToHandle());
            tblVoucherPosting_colsAutoTaxVouEntry.EditDataItemValueSet(1, ((SalString)"FALSE").ToHandle());
            if (sMode != "DUPLICATED")
            {
                tblVoucherPosting_colsCurrencyCode.EditDataItemValueSet(1, ((SalString)frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfsCurrencyCode.Text).ToHandle());
                tblVoucherPosting_colnCurrencyRate.EditDataItemValueSet(1, frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfnCurrencyRate.Number.ToString(frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).nDecimalsInRate).ToHandle());
                tblVoucherPosting_colnConversionFactor.EditDataItemValueSet(1, frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfnConversionFactor.Number.ToString(0).ToHandle());
                nPrevRate = tblVoucherPosting_colnCurrencyRate.Number;
                tblVoucherPosting_colsTextId.EditDataItemValueSet(1, ((SalString)frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfsTextId.Text).ToHandle());
                tblVoucherPosting_colsText.EditDataItemValueSet(1, ((SalString)frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfsRowText.Text).ToHandle());
                tblVoucherPosting_colnActCurrencyRate.Number = tblVoucherPosting_colnCurrencyRate.Number;
                nPrevActRate = tblVoucherPosting_colnActCurrencyRate.Number;
            }
            else
            {
                tblVoucherPosting_colnActCurrencyRate.Number = nPrevActRate;
            }
            tblVoucherPosting_colsFunctionGroup.EditDataItemValueSet(1, ((SalString)frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfsVoucherGroup.Text).ToHandle());
            bEditedId = false;
            // Fetch Row group id if row group validation is enabled
            if (frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfsRowGroupValidation.Text == "Y")
            {
                CalcRowGroupInfo();
                tblVoucherPosting_colnRowGroupId.Number = GetNextGroupId();
                tblVoucherPosting_colnRowGroupId.EditDataItemSetEdited();
            }
            else
            {
                Sal.ClearField(tblVoucherPosting_colnRowGroupId);
            }
            return 0;
        }

        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalNumber DataRecordNew(SalNumber nWhat)
        {

            #region Local Variables
            SalBoolean bOk = false;
            #endregion
            switch (nWhat)
            {
                case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                    // Bug 77430, Begin, checked for user permission
                    return ((bool)((cDataSource)tblVoucherPosting).DataRecordNew(nWhat)) && 
                        frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfsCompany.Text != Sys.STRING_Null && 
                        frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).sAuthLevel != "ApproveOnly" && 
                        Sal.IsNull(frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfnVoucherNoReference) && 
                        !(frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).cmbsAmountMethod.Text == Ifs.Fnd.ApplicationForms.Const.strNULL);
                    // Bug 77430, End
                    goto case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute;

                case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                    // If the voucher belongs to another function group than 'K', 'M' or 'Q' the amount method should be NULL.
                    // It should then not be possible to add voucher postings
                    if (frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).cmbsAmountMethod.Text == Ifs.Fnd.ApplicationForms.Const.strNULL)
                    {
                        return 0;
                    }
                    if (!(frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).DataRecordCheckRequired()))
                    {
                        return 0;
                    }
                    if (!(frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).GetParallelCurrencyAttributes()))
                    {
                        return 0;
                    }
                    if (frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).cmbsVoucherStatus.Text == Sal.ListQueryTextX(frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).cmbsVoucherStatus, 3))
                    {
                        return 0;
                    }
                    sAmountMethod = frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).cmbsAmountMethod.Text;
                    DbPLSQLBlock(@"{0} := &AO.Def_Amount_Method_API.Encode( {1} IN )",
                        this.QualifiedVarBindName("sAmountMethodDb"),
                        this.QualifiedVarBindName("sAmountMethod"));
                    
                    sPrevCurrType = Ifs.Fnd.ApplicationForms.Const.strNULL;
                    // Bug Id 80054, Begin
                    bCopyRow = false;
                    // Bug Id 80054, End
                    // Bug 95055 Begin
                    this.sCallFrmDCAmnt = "FALSE";
                    // Bug 95055 End

                    bOk = ((cChildTableFin)tblVoucherPosting).DataRecordNew(nWhat);
                    if (bOk && !(bTemplateOrCopyGL))
                    {
                        FetchDefaultParallelCurrRateType();
                    }
                    return bOk;

                case Ifs.Fnd.ApplicationForms.Const.METHOD_GetType:
                    return ((cDataSource)this).DataRecordNew(nWhat);
            }
            

            return 0;
        
        }

        /// <summary>
        /// Removes all selected records
        /// </summary>
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalNumber DataRecordRemove(SalNumber nWhat)
        {
            #region Local Variables
            SalBoolean bOk = false;
            #endregion

            #region Actions

            switch (nWhat)
            {
                case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                    if (frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).cmbsVoucherStatus.Text == Sal.ListQueryTextX(frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).cmbsVoucherStatus, 2))
                    {
                        Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_ErrorSaveAccrul, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
                        return 0;
                    }
                    bOk = ((cChildTableFin)tblVoucherPosting).DataRecordRemove(nWhat);
                    this.RefreshBalances();
                    return bOk;

                case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                    // Bug 77430, Begin, checked for user permission
                    if (frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).sAuthLevel != "ApproveOnly")
                    {
                        return ((cChildTableFin)tblVoucherPosting).DataRecordRemove(nWhat);
                    }
                    // Bug 77430, End
                    goto case Ifs.Fnd.ApplicationForms.Const.METHOD_GetType;

                case Ifs.Fnd.ApplicationForms.Const.METHOD_GetType:
                    return ((cChildTableFin)tblVoucherPosting).DataRecordRemove(nWhat);
            }
            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean DataRecordValidate()
        {
            #region Local Variables
            SalArray<SalString> sParam = new SalArray<SalString>();
            #endregion

            #region Actions
            Sal.SetFieldEdit(tblVoucherPosting_colsTextId, false);
            // Bug Id 93703, Remove the currency  type setting false in setedited
            Sal.SetFieldEdit(tblVoucherPosting_colnCurrencyAmount, false);
            Sal.SetFieldEdit(tblVoucherPosting_colnAmount, false);
            Sal.SetFieldEdit(tblVoucherPosting_colnThirdCurrencyAmount, false);
            Sal.SetFieldEdit(tblVoucherPosting_colCorrection, false);
            Sal.SetFieldEdit(tblVoucherPosting_colnDecimalsInAmount, false);
            Sal.SetFieldEdit(tblVoucherPosting_colnAccDecimalsInAmount, false);
            if (sAmountMethodDb == "GROSS")
            {
                this.tblVoucherPosting_colnCurrencyDebetAmount.EditDataItemSetEdited();
                this.tblVoucherPosting_colnCurrencyCreditAmount.EditDataItemSetEdited();
                this.tblVoucherPosting_colnCurrencyTaxAmount.EditDataItemSetEdited();
                this.tblVoucherPosting_colnCurrencyGrossAmount.EditDataItemSetEdited();

                this.tblVoucherPosting_colnDebetAmount.EditDataItemSetEdited();
                this.tblVoucherPosting_colnCreditAmount.EditDataItemSetEdited();
                this.tblVoucherPosting_colnTaxAmount.EditDataItemSetEdited();
                this.tblVoucherPosting_colnGrossAmount.EditDataItemSetEdited();

                this.tblVoucherPosting_colnThirdCurrencyDebitAmount.EditDataItemSetEdited();
                this.tblVoucherPosting_colnThirdCurrencyCreditAmount.EditDataItemSetEdited();

                this.tblVoucherPosting_colnParallelCurrTaxAmount.EditDataItemSetEdited();
            }
            // row group validation if...
            //   1 row group validation is enabled
            //   2 voucher status is selected a Approved (first)
            if ((frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfsRowGroupValidation.Text == "Y") && (frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).cmbsVoucherStatus.Text == Sal.ListQueryTextX(
                frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).cmbsVoucherStatus, 0)))
            {
                CalcRowGroupInfo();
                ValidateRowGroups();
            }
            // Bug 101870, Removed the code
            return ((cChildTableFin)tblVoucherPosting).DataRecordValidate();
            #endregion
        }

        /// <summary>
        /// Applications should override the DataSourceFormatSqlColumnUser function
        /// to specify extra columns to be included in the select statement for the
        /// data source.
        /// </summary>
        /// <returns></returns>
        public virtual SalString DataSourceFormatSqlColumnUser()
        {
            SalString sAttr = "NVL(CURRENCY_DEBET_AMOUNT,0) - NVL(CURRENCY_CREDIT_AMOUNT,0),";
            sAttr = sAttr + "NVL(DEBET_AMOUNT,0) - NVL(CREDIT_AMOUNT,0)";
            return sAttr;
        }

        /// <summary>
        /// Applications should override the DataSourceFormatSqlIntoUser function
        /// to specify extra bind variables to be included in the select statement for the
        /// data source.
        /// </summary>
        /// <returns></returns>
        public virtual SalString DataSourceFormatSqlIntoUser()
        {   
            return (this.tblVoucherPosting_colnCurrencyAmount.QualifiedBindName +" ," + this.tblVoucherPosting_colnAmount.QualifiedBindName);
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber FetchDefaultParallelCurrRateType()
        {
            tblVoucherPosting_colnParallelCurrRateType.Text = frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).sParallelRateType;
            Sal.SetFieldEdit(this.tblVoucherPosting_colnParallelCurrRateType, true);
            Sal.SendMsg(tblVoucherPosting_colnParallelCurrRateType, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
            return 0;
        }
        
        /// <summary>
        /// This is an overridden function defined in the cChildTableFin class
        /// </summary>
        /// <param name="sCodePartValue"></param>
        /// <returns></returns>
        public virtual new SalBoolean EnableDisableProjectActivityId(SalString sCodePartValue)
        {
            #region Local Variables
            SalArray<SalString> sData = new SalArray<SalString>();
            #endregion

            #region Actions
            sParam = sCodePartValue;
            if (sParam != SalString.Null)
            {
                if (Int.IsGenLedInstalled && Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Accounting_Project_Api.Get_Externally_Created"))
                {
                    if (!(DbPLSQLBlock(@"{0} := &AO.Accounting_Project_Api.Get_Externally_Created({1} IN,{2} IN );
                                         {3} := &AO.Voucher_Row_API.Get_Pca_Ext_Project({1} IN);",
                                            this.tblVoucherPosting_colsProjectActivityIdEnabled.QualifiedBindName,
                                            this.tblVoucherPosting_colsCompany.QualifiedBindName,
                                            this.QualifiedVarBindName("sParam"),
                                            this.QualifiedVarBindName("sPcaExtProject"))))
                    {
                        return false;
                    }   
                }
                else
                {
                    tblVoucherPosting_colsProjectActivityIdEnabled.Text = "Y";
                }
            }
            if ((bUseVouTemplate == false) && (bIsDupl == false) && (tblVoucherPosting_colsProjectActivityIdEnabled.Text == "N"))
            {
                Sal.ClearField(tblVoucherPosting_colnProjectActivityId);
            }
            if (SetValueOfActivityID())
            {
                tblVoucherPosting_colsProjectActivityIdEnabled.Text = "N";
                tblVoucherPosting_colnProjectActivityId.Number = 0;
            }
            else if (this.sProjectOriginGlobal == "FINPROJECT")
            {
                tblVoucherPosting_colsProjectActivityIdEnabled.Text = "N";
                tblVoucherPosting_colnProjectActivityId.Number = Sys.NUMBER_Null;
            }
            else if (this.sProjectOriginGlobal == "JOB")
            {
                tblVoucherPosting_colsProjectActivityIdEnabled.Text = "N";
                tblVoucherPosting_colnProjectActivityId.Number = 0;
            }
            else if (tblVoucherPosting_colsFunctionGroup.Text == "Z" && this.sProjectOriginGlobal != "FINPROJECT")
            {
                if (sPcaExtProject == "FALSE" && sParam != Ifs.Fnd.ApplicationForms.Const.strNULL)
                {
                    sData[0] = tblVoucherPosting_colsCompany.Text;
                    if (Ifs.Fnd.ApplicationForms.Int.AlertBoxWithParams(Properties.Resources.TEXT_ExternalProjectPca, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Warning, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok, sData) == Sys.IDOK)
                    {
                        return Sys.VALIDATE_Cancel;
                    }
                }
                tblVoucherPosting_colsProjectActivityIdEnabled.Text = "N";
                tblVoucherPosting_colnProjectActivityId.Number = Sys.NUMBER_Null;
            }
            else
            {
                if (tblVoucherPosting_colsProjectActivityIdEnabled.Text == "Y")
                {
                    SetValueOfProjectID();
                    tblVoucherPosting_colnProjectActivityId.Number = Sys.NUMBER_Null;
                }
                else
                {
                    tblVoucherPosting_colnProjectActivityId.Number = Sys.NUMBER_Null;
                }
            }
            tblVoucherPosting_colnProjectActivityId.EditDataItemSetEdited();
            return true;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean IsLogicalAccountType()
        {
            DbPLSQLBlock(@"&AO.Account_API.Get_Logical_Accnt_Type({0} OUT,{1} IN, {2} IN )",
                        this.QualifiedVarBindName("sResult"), this.tblVoucherPosting_colsCompany.QualifiedBindName, this.tblVoucherPosting_colsAccount.QualifiedBindName);

            return ((sResult == "Cost") || (sResult == "Revenues") || (sResult == "Statistics"));
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean IsSameCurrCode()
        {
            SalNumber nCurRow = Sys.TBL_MinRow;
            while (Sal.TblFindNextRow(tblVoucherPosting, ref nCurRow, 0, 0))
            {
                Sal.TblSetContext(tblVoucherPosting, nCurRow);
                if (tblVoucherPosting_colsCurrencyCode.Text != frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfsCurrencyCode.Text)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean IsReferenceNull()
        {
            SalNumber nCurRow = Sys.TBL_MinRow;
            while (Sal.TblFindNextRow(tblVoucherPosting, ref nCurRow, 0, 0))
            {
                Sal.TblSetContext(tblVoucherPosting, nCurRow);
                if (tblVoucherPosting_colsReferenceSerie.Text == Ifs.Fnd.ApplicationForms.Const.strNULL || tblVoucherPosting_colsReferenceNumber.Text == Ifs.Fnd.ApplicationForms.Const.strNULL)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Set the accounting period in the rows when the voucher date is modified
        /// </summary>
        /// <param name="nPeriod"></param>
        /// <returns></returns>
        public virtual SalBoolean SetAccountingPeriod(SalNumber nPeriod)
        {
            SalNumber nCurrenctRow = Sal.TblQueryContext(tblVoucherPosting);
            SalNumber nRow = Sys.TBL_MinRow;
            while (Sal.TblFindNextRow(tblVoucherPosting, ref nRow, 0, Sys.ROW_MarkDeleted))
            {
                Sal.TblSetContext(tblVoucherPosting, nRow);
                if (this.tblVoucherPosting_colnAccountingPeriod.Number != nPeriod)
                {
                    this.tblVoucherPosting_colnAccountingPeriod.EditDataItemValueSet(1, nPeriod.ToString(0).ToHandle());
                }
            }
            Sal.TblSetContext(tblVoucherPosting, nCurrenctRow);
            return true;
        }

        /// <summary>
        /// Set's all fields in the child table edited plus calculates third currency amounts as well.
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber SetAllEdited()
        {
            this.tblVoucherPosting_colsCompany.EditDataItemSetEdited();
            this.tblVoucherPosting_colsAccount.EditDataItemSetEdited();
            this.tblVoucherPosting_colsCodeB.EditDataItemSetEdited();
            this.tblVoucherPosting_colsCodeC.EditDataItemSetEdited();
            this.tblVoucherPosting_colsCodeD.EditDataItemSetEdited();
            this.tblVoucherPosting_colsCodeE.EditDataItemSetEdited();
            this.tblVoucherPosting_colsCodeF.EditDataItemSetEdited();
            this.tblVoucherPosting_colsCodeG.EditDataItemSetEdited();
            this.tblVoucherPosting_colsCodeH.EditDataItemSetEdited();
            this.tblVoucherPosting_colsCodeI.EditDataItemSetEdited();
            this.tblVoucherPosting_colsCodeJ.EditDataItemSetEdited();
            this.tblVoucherPosting_colsProcessCode.EditDataItemSetEdited();
            this.tblVoucherPosting_colsCurrencyCode.EditDataItemSetEdited();
            this.tblVoucherPosting_colnConversionFactor.EditDataItemSetEdited();
            this.tblVoucherPosting_colnCurrencyDebetAmount.EditDataItemSetEdited();
            this.tblVoucherPosting_colnCurrencyCreditAmount.EditDataItemSetEdited();
            this.tblVoucherPosting_colnDebetAmount.EditDataItemSetEdited();
            this.tblVoucherPosting_colnCreditAmount.EditDataItemSetEdited();
            this.tblVoucherPosting_colnCurrencyRate.EditDataItemSetEdited();
            this.tblVoucherPosting_colnQuantity.EditDataItemSetEdited();
            this.tblVoucherPosting_colsText.EditDataItemSetEdited();
            this.tblVoucherPosting_colsOptionalCode.EditDataItemSetEdited();
            this.tblVoucherPosting_colnProjectActivityId.EditDataItemSetEdited();
            this.tblVoucherPosting_colsTransCode.EditDataItemSetEdited();
            this.tblVoucherPosting_colsTaxDirection.SetModified(true);  //because this is a cLookUpColumn.
            this.tblVoucherPosting_colnCurrencyTaxAmount.EditDataItemSetEdited();
            this.tblVoucherPosting_colnCurrencyGrossAmount.EditDataItemSetEdited();
            this.tblVoucherPosting_colnTaxAmount.EditDataItemSetEdited();
            this.tblVoucherPosting_colnGrossAmount.EditDataItemSetEdited();
            this.tblVoucherPosting_colsReferenceSerie.EditDataItemSetEdited();
            this.tblVoucherPosting_colsReferenceNumber.EditDataItemSetEdited();
            this.tblVoucherPosting_colnRowGroupId.EditDataItemSetEdited();
            this.tblVoucherPosting_colnThirdCurrencyCreditAmount.EditDataItemSetEdited();
            this.tblVoucherPosting_colnThirdCurrencyDebitAmount.EditDataItemSetEdited();
            this.tblVoucherPosting_colnParallelCurrTaxAmount.EditDataItemSetEdited();
            this.tblVoucherPosting_colnParallelCurrConvFactor.EditDataItemSetEdited();
            this.tblVoucherPosting_colnParallelCurrRate.EditDataItemSetEdited();     
            this.tblVoucherPosting_colsDeliveryTypeId.EditDataItemSetEdited();
            return 0;
        }

        /// <summary>
        /// Set other related rival currency amount, such as if someone enter debit currency amount,
        /// system must set value for currency amount, debit, amount.
        /// </summary>
        /// <param name="nMyValue"></param>
        /// <param name="hWndRival"></param>
        /// <param name="sStatus"></param>
        /// <param name="nCalculatedTaxValue"></param>
        /// <returns></returns>
        /// Bug 97225, Begin
        public virtual SalNumber SetAnotherValue(SalNumber nMyValue, SalWindowHandle hWndRival, SalString sStatus, ref SalNumber nCalculatedTaxValue)
        {
            #region Local Variables
            SalNumber nCalculateValue = 0;
            SalNumber nPosCurrAmount = 0;
            SalNumber nPosAmount = 0;

            SalNumber nPosParallelCurrAmount = 0;
            SalNumber nPosCurrTaxAmount = 0;
            SalNumber nPosTaxAmount = 0;

            SalNumber nPosParallelTaxAmnt = 0;
            #endregion

            #region Actions
            if (tblVoucherPosting_colnCurrencyRate.Number == Sys.NUMBER_Null)
            {
                Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_Curr_Rate_Is_Null, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
                return nMyValue;
            }
            if (sStatus == "RATE")
            {
                this.GetAttributes(tblVoucherPosting_colsCompany.Text, tblVoucherPosting_colsCurrencyCode.Text, frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).sCurrencyCode, tblVoucherPosting_colsCurrencyType.Text, frmEntryVoucher.FromHandle(
                        Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfdVoucherDate.DateTime);
                if (nMyValue != nPrevRate)
                {
                    this.GetBaseCurrAmountForRate(tblVoucherPosting_colnCurrencyAmount.Number, nMyValue, ref nCalculateValue);
                }
                else
                {
                    this.GetBaseCurrencyAmount(tblVoucherPosting_colnCurrencyAmount.Number, ref nCalculateValue);
                }
                if (nCalculateValue == 0)
                {
                    nCalculateValue = SalNumber.Null;
                }
                tblVoucherPosting_colnAmount.Number = nCalculateValue;
                if ((tblVoucherPosting_colnAmount.Number > 0 && tblVoucherPosting_colCorrection.Text == "Y") || (tblVoucherPosting_colnAmount.Number <= 0 && tblVoucherPosting_colCorrection.Text == "N"))
                {
                    tblVoucherPosting_colnCreditAmount.Number = -nCalculateValue;
                    tblVoucherPosting_colnCreditAmount.EditDataItemSetEdited();
                }
                else
                {
                    tblVoucherPosting_colnDebetAmount.Number = nCalculateValue;
                    tblVoucherPosting_colnDebetAmount.EditDataItemSetEdited();
                }
            }
            else if (sStatus == "CURRENT_AMOUNT")
            {
                if (nMyValue != SalNumber.Null)
                {
                    nMyValue = this.RoundOf(nMyValue, tblVoucherPosting_colnDecimalsInAmount.Number);
                }
                this.GetAttributes(tblVoucherPosting_colsCompany.Text, tblVoucherPosting_colsCurrencyCode.Text, frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).sCurrencyCode, tblVoucherPosting_colsCurrencyType.Text, frmEntryVoucher.FromHandle(
                        Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfdVoucherDate.DateTime);

                // Bug 97225, Begin
                if (sMode == "DUPLICATED" && !(Sal.IsNull(tblVoucherPosting_colnCurrencyTaxAmount)))
                {
                    nCalculatedTaxValue = tblVoucherPosting_colnCurrencyTaxAmount.Number;
                }
                if (sCalculateTax != "FALSE")
                {
                    nDeductibleAmount = CalculateTaxValue(nMyValue, tblVoucherPosting_colnPrevCurrencyAmount.Number, tblVoucherPosting_colnCurrencyTaxAmount, sAmountMethodDb, "CURRENT_AMOUNT", ref nCalculatedTaxValue);
                    if (nMyValue != SalNumber.Null)
                    {
                        nMyValue = this.RoundOf(nMyValue + nDeductibleAmount, tblVoucherPosting_colnDecimalsInAmount.Number);
                    }
                }
                // Bug 97225, End

                tblVoucherPosting_colnCurrencyAmount.Number = nMyValue;
                if (tblVoucherPosting_colnActCurrencyRate.Number == Sys.NUMBER_Null)
                {
                    tblVoucherPosting_colnActCurrencyRate.Number = tblVoucherPosting_colnCurrencyRate.Number;
                }
                this.GetBaseCurrAmountForRate(nMyValue, tblVoucherPosting_colnActCurrencyRate.Number, ref nCalculateValue);
                this.GetBaseCurrAmountForRate(nMyValue, tblVoucherPosting_colnCurrencyRate.Number, ref nCalculateValue);
                // Bug 95055 Begin , use sCallFrmDCAmnt to check whether the call /tab from field debit/creit amount
                if (this.sCallFrmDCAmnt == "FALSE")
                {
                    tblVoucherPosting_colnAmount.Number = nCalculateValue;
                }
                else
                {
                    if (frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).sCurrencyCode == tblVoucherPosting_colsCurrencyCode.Text || tblVoucherPosting_colnCurrencyAmount.Number == Sys.NUMBER_Null)
                    {
                        tblVoucherPosting_colnAmount.Number = nCalculateValue;
                    }
                }
                // Bug 95055 End
                if (nCalculateValue != SalNumber.Null)
                {
                    if ((nCalculateValue < 0 && tblVoucherPosting_colCorrection.Text == "N") || (nCalculateValue > 0 && tblVoucherPosting_colCorrection.Text == "Y"))
                    {
                        nCalculateValue = -nCalculateValue;
                    }
                }
                // Bug 95055 Begin
                if ((this.sCallFrmDCAmnt == "FALSE") || (frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).sCurrencyCode == tblVoucherPosting_colsCurrencyCode.Text || tblVoucherPosting_colnCurrencyAmount.Number == Sys.NUMBER_Null))
                {
                    Sal.SendMsg(hWndRival, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, nCalculateValue.ToString(99).ToHandle());
                }
                // Bug 95055 End
            }
            else if (sStatus == "ACCOUNTING_AMOUNT")
            {
                if (nMyValue != SalNumber.Null)
                {
                    nMyValue = this.RoundOf(nMyValue, tblVoucherPosting_colnAccDecimalsInAmount.Number);
                    // Bug 97225, Begin
                    this.sCurrCode = frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).sCurrencyCode;
                    if (sMode == "DUPLICATED" && !(Sal.IsNull(tblVoucherPosting_colnTaxAmount)))
                    {
                        nCalculatedTaxValue = tblVoucherPosting_colnTaxAmount.Number;
                    }
                    if ((sCalculateTax != "FALSE") && (tblVoucherPosting_colsCurrencyCode.Text == this.sCurrCode))
                    {
                        nDeductibleAmount = CalculateTaxValue(nMyValue, tblVoucherPosting_colnPrevAmount.Number, tblVoucherPosting_colnTaxAmount, sAmountMethodDb, "ACCOUNTING_AMOUNT", ref nCalculatedTaxValue);
                        if (nMyValue != SalNumber.Null)
                        {
                            nMyValue = this.RoundOf(nMyValue + nDeductibleAmount, tblVoucherPosting_colnDecimalsInAmount.Number);
                        }
                    }
                    // Bug 97225, End
                    if ((tblVoucherPosting_colnCurrencyAmount.Number != 0) && (tblVoucherPosting_colnCurrencyAmount.Number != Sys.NUMBER_Null))
                    {
                        if ((tblVoucherPosting_colnCurrencyAmount.Number < 0 && nMyValue > 0) || (tblVoucherPosting_colnCurrencyAmount.Number > 0 && nMyValue < 0))
                        {
                            tblVoucherPosting_colnCurrencyAmount.Number = -tblVoucherPosting_colnCurrencyAmount.Number;
                            if (tblVoucherPosting_colnCurrencyDebetAmount.Number == Sys.NUMBER_Null)
                            {
                                tblVoucherPosting_colnCurrencyDebetAmount.Number = tblVoucherPosting_colnCurrencyCreditAmount.Number;
                                tblVoucherPosting_colnCurrencyDebetAmount.EditDataItemSetEdited();
                                tblVoucherPosting_colnCurrencyCreditAmount.Number = Sys.NUMBER_Null;
                                tblVoucherPosting_colnCurrencyCreditAmount.EditDataItemSetEdited();
                            }
                            else
                            {
                                tblVoucherPosting_colnCurrencyCreditAmount.Number = tblVoucherPosting_colnCurrencyDebetAmount.Number;
                                tblVoucherPosting_colnCurrencyCreditAmount.EditDataItemSetEdited();
                                tblVoucherPosting_colnCurrencyDebetAmount.Number = Sys.NUMBER_Null;
                                tblVoucherPosting_colnCurrencyDebetAmount.EditDataItemSetEdited();
                            }
                        }
                        this.GetAttributes(tblVoucherPosting_colsCompany.Text, tblVoucherPosting_colsCurrencyCode.Text, frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).sCurrencyCode, tblVoucherPosting_colsCurrencyType.Text, frmEntryVoucher.FromHandle(
                                Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfdVoucherDate.DateTime);
                        if (nMyValue.Abs() != tblVoucherPosting_colnPrevAmount.Number.Abs())
                        {   
                            DbPLSQLBlock(@"{0} := &AO.Currency_Code_API.Get_Emu({1} IN,{2} IN)", this.QualifiedVarBindName("IsEmu"), this.tblVoucherPosting_colsCompany.QualifiedBindName, this.tblVoucherPosting_colsCurrencyCode.QualifiedBindName);
                            if ((tblVoucherPosting_colsCurrencyCode.Text != this.sCurrCode) && (this.IsEmu == "FALSE"))
                            {
                                // PPJ: Automatically generated temporary assignments. Properties canot be passed by reference.
                                SalNumber temp1 = tblVoucherPosting_colnCurrencyRate.Number;
                                this.GetCurrencyRate(nMyValue, tblVoucherPosting_colnCurrencyAmount.Number, ref temp1);
                                tblVoucherPosting_colnCurrencyRate.Number = temp1;

                                if (tblVoucherPosting_colnActCurrencyRate.Number == Sys.NUMBER_Null)
                                {
                                    tblVoucherPosting_colnActCurrencyRate.Number = tblVoucherPosting_colnCurrencyRate.Number;
                                }

                                // PPJ: Automatically generated temporary assignments. Properties canot be passed by reference.
                                SalNumber temp2 = tblVoucherPosting_colnActCurrencyRate.Number;
                                this.GetActualCurrencyRate(nMyValue, tblVoucherPosting_colnCurrencyAmount.Number, ref temp2);
                                tblVoucherPosting_colnActCurrencyRate.Number = temp2;

                                tblVoucherPosting_colnCurrencyRate.EditDataItemSetEdited();
                            }
                            else
                            {
                                if (tblVoucherPosting_colsCurrencyCode.Text == this.sCurrCode)
                                {
                                    if (tblVoucherPosting_colnCreditAmount.Number == Sys.NUMBER_Null)
                                    {
                                        tblVoucherPosting_colnCurrencyDebetAmount.Number = tblVoucherPosting_colnDebetAmount.Number;
                                        tblVoucherPosting_colnCurrencyDebetAmount.EditDataItemSetEdited();
                                        tblVoucherPosting_colnCurrencyAmount.Number = tblVoucherPosting_colnDebetAmount.Number;
                                        tblVoucherPosting_colnCurrencyAmount.EditDataItemSetEdited();
                                        tblVoucherPosting_colnCurrencyCreditAmount.Number = Sys.NUMBER_Null;
                                        tblVoucherPosting_colnCurrencyCreditAmount.EditDataItemSetEdited();
                                    }
                                    else
                                    {
                                        tblVoucherPosting_colnCurrencyCreditAmount.Number = tblVoucherPosting_colnCreditAmount.Number;
                                        tblVoucherPosting_colnCurrencyCreditAmount.EditDataItemSetEdited();
                                        tblVoucherPosting_colnCurrencyAmount.Number = -tblVoucherPosting_colnCreditAmount.Number;
                                        tblVoucherPosting_colnCurrencyAmount.EditDataItemSetEdited();
                                        tblVoucherPosting_colnCurrencyDebetAmount.Number = Sys.NUMBER_Null;
                                        tblVoucherPosting_colnCurrencyDebetAmount.EditDataItemSetEdited();
                                    }
                                }
                            }
                            nPrevRate = tblVoucherPosting_colnCurrencyRate.Number;
                            nPrevActRate = tblVoucherPosting_colnActCurrencyRate.Number;
                        }
                    }
                    // Bug 102399, Begin - Removed the Check for 0
                    else if ((tblVoucherPosting_colnDebetAmount.Number != Sys.NUMBER_Null) || (tblVoucherPosting_colnCreditAmount.Number != Sys.NUMBER_Null))
                    {
                        // Bug 97225, Moved code above
                        if (tblVoucherPosting_colsCurrencyCode.Text == this.sCurrCode)
                        {
                            if (tblVoucherPosting_colnCreditAmount.Number == Sys.NUMBER_Null)
                            {
                                tblVoucherPosting_colnCurrencyDebetAmount.Number = tblVoucherPosting_colnDebetAmount.Number;
                                tblVoucherPosting_colnCurrencyDebetAmount.EditDataItemSetEdited();
                                tblVoucherPosting_colnCurrencyAmount.Number = tblVoucherPosting_colnDebetAmount.Number;
                                tblVoucherPosting_colnCurrencyAmount.EditDataItemSetEdited();
                                tblVoucherPosting_colnCurrencyCreditAmount.Number = Sys.NUMBER_Null;
                                tblVoucherPosting_colnCurrencyCreditAmount.EditDataItemSetEdited();
                            }
                            else
                            {
                                tblVoucherPosting_colnCurrencyCreditAmount.Number = tblVoucherPosting_colnCreditAmount.Number;
                                tblVoucherPosting_colnCurrencyCreditAmount.EditDataItemSetEdited();
                                tblVoucherPosting_colnCurrencyAmount.Number = -tblVoucherPosting_colnCreditAmount.Number;
                                tblVoucherPosting_colnCurrencyAmount.EditDataItemSetEdited();
                                tblVoucherPosting_colnCurrencyDebetAmount.Number = Sys.NUMBER_Null;
                                tblVoucherPosting_colnCurrencyDebetAmount.EditDataItemSetEdited();
                            }
                        }
                        // Bug 102399, End
                    }
                }
                tblVoucherPosting_colnAmount.Number = nMyValue;
            }
            CheckStatAccount();
            nPosCurrAmount = Sal.TblQueryColumnID(tblVoucherPosting_colnCurrencyAmount);
            nPosAmount = Sal.TblQueryColumnID(tblVoucherPosting_colnAmount);

            nPosParallelCurrAmount = Sal.TblQueryColumnID(tblVoucherPosting_colnThirdCurrencyAmount);
            if (sAmountMethodDb == "GROSS")
            {
                this.dfnCurrencyBalance.Number = Sal.TblColumnSum(tblVoucherPosting, nPosCurrAmount, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1));
                this.dfnBalance.Number = Sal.TblColumnSum(tblVoucherPosting, nPosAmount, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1));

                this.dfnParallelCurrBalance.Number = Sal.TblColumnSum(tblVoucherPosting, nPosParallelCurrAmount, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1));
            }
            if (sAmountMethodDb == "NET")
            {
                nPosCurrTaxAmount = Sal.TblQueryColumnID(tblVoucherPosting_colnCurrencyTaxAmount);
                nPosTaxAmount = Sal.TblQueryColumnID(tblVoucherPosting_colnTaxAmount);

                nPosParallelTaxAmnt = Sal.TblQueryColumnID(tblVoucherPosting_colnParallelCurrTaxAmount);
                this.dfnCurrencyBalance.Number = Sal.TblColumnSum(tblVoucherPosting, nPosCurrAmount, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1)) + Sal.TblColumnSum(tblVoucherPosting, nPosCurrTaxAmount, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1));
                this.dfnBalance.Number = Sal.TblColumnSum(tblVoucherPosting, nPosAmount, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1)) + Sal.TblColumnSum(tblVoucherPosting, nPosTaxAmount, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1));

                this.dfnParallelCurrBalance.Number = Sal.TblColumnSum(tblVoucherPosting, nPosParallelCurrAmount, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1)) + Sal.TblColumnSum(tblVoucherPosting, nPosParallelTaxAmnt, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1));
            }

            // Third currency calculation
            if (bCalculateParallelCurrTax)
            {
                SetThirdCurrencyAmounts();
            }
            return nMyValue;
            
            #endregion
        }

        // Bug 97225, Begin - Added new method to calculate the tax values. ( this contains the tax calculations which were there previously in the SetTaxValue() method )
        /// <summary>
        /// </summary>
        /// <param name="nMyValue"></param>
        /// <param name="nPreviousAmount"></param>
        /// <param name="hWndRivalTax"></param>
        /// <param name="sAmountMethodVoucher"></param>
        /// <param name="sStatus"></param>
        /// <param name="nCalculatedTaxValue"></param>
        /// <returns></returns>
        public virtual SalNumber CalculateTaxValue(SalNumber nMyValue, SalNumber nPreviousAmount, SalWindowHandle hWndRivalTax, SalString sAmountMethodVoucher, SalString sStatus, ref SalNumber nCalculatedTaxValue)
        {
            #region Local Variables
            SalNumber nCalculateTaxValue = 0;
            SalNumber nDeductValue = 0;
            #endregion

            #region Actions
            nDeductValue = SalNumber.Null;
            nCalculatedTaxValue = SalNumber.Null;
            // Bug 97225, Begin
            // bAmtChanged = TRUE and prev value = current value means only the sign has changed. so only change the sign of the tax amount
            if (bAmtChanged && nMyValue.Abs() == nPreviousAmount.Abs())
            {
                nDeductValue = 0;
                nCalculatedTaxValue = tblVoucherPosting_colnTaxAmount.Number * -1;
                return nDeductValue;
            }
            else if (bCurrencyAmtChanged && nMyValue.Abs() == nPreviousAmount.Abs())
            {
                nDeductValue = 0;
                nCalculatedTaxValue = tblVoucherPosting_colnCurrencyTaxAmount.Number * -1;
                return nDeductValue;
            }
            // Bug 97225, End

            if (nMyValue.Abs() != nPreviousAmount.Abs() || (tblVoucherPosting_colnCurrencyTaxAmount.Number == Sys.NUMBER_Null) || ((tblVoucherPosting_colnAmount.Number != Sys.NUMBER_Null) && (tblVoucherPosting_colnTaxAmount.Number == Sys.NUMBER_Null)) || bCurrencyAmtChanged || bAmtChanged || bTaxCodeChanged)
            {
                this.GetAttributes(tblVoucherPosting_colsCompany.Text, tblVoucherPosting_colsCurrencyCode.Text, frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).sCurrencyCode, tblVoucherPosting_colsCurrencyType.Text, frmEntryVoucher.FromHandle(
                        Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfdVoucherDate.DateTime);
                if (!(Sal.IsNull(tblVoucherPosting_colsOptionalCode)) && tblVoucherPosting_colsFunctionGroup.Text != "Q")
                {
                    IDictionary<string, string> namedBindVariables = new Dictionary<string, string>();
                    namedBindVariables.Add("colsCompany", this.tblVoucherPosting_colsCompany.QualifiedBindName);
                    namedBindVariables.Add("colsOptionalCode", this.tblVoucherPosting_colsOptionalCode.QualifiedBindName);
                    namedBindVariables.Add("dfdVoucherDate", ":i_hWndParent.frmEntryVoucher.dfdVoucherDate");
                    namedBindVariables.Add("nDeduct", this.QualifiedVarBindName("nDeduct"));
                    namedBindVariables.Add("nTaxPercent", this.QualifiedVarBindName("nTaxPercent"));
                    if (!(DbPLSQLBlock(@"BEGIN
                                            &AO.Statutory_Fee_API.Get_Fee_Percent( {nTaxPercent} OUT,
                                                                                    {colsCompany} IN,
                                                                                    {colsOptionalCode} IN,
                                                                                    {dfdVoucherDate} IN );
                                            IF ({nTaxPercent} != 0 ) THEN
                                                {nDeduct} := &AO.Statutory_Fee_API.Get_Deductible({colsCompany} IN,{colsOptionalCode} IN );
                                            END IF;
                                            END;",namedBindVariables)))
                    {
                        return 0;
                    }
                    
                    nTaxPercent = nTaxPercent / 100;
                }
                else
                {
                    nTaxPercent = 0;
                }
                if (nDeduct == SalNumber.Null)
                {
                    nDeduct = 100;
                    bIsAutoBal = false;
                }
                else
                {
                    bIsAutoBal = true;
                }
                nDeductPercent = nDeduct / 100;

                if (sAmountMethodVoucher == "NET")
                {
                    nToTaxAmount = nMyValue * nTaxPercent;
                    nCalculateTaxValue = nToTaxAmount * nDeductPercent;
                    nCalculateTaxValue = this.RoundOfTax(frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).sRoundingMethod, nCalculateTaxValue, tblVoucherPosting_colnDecimalsInAmount.Number);
                    nDeductValue = nToTaxAmount - nCalculateTaxValue;
                }
                else if (sAmountMethodVoucher == "GROSS")
                {
                    nToTaxAmount = nMyValue * nTaxPercent / (1 + nTaxPercent);
                    nCalculateTaxValue = nToTaxAmount * nDeductPercent;
                    nCalculateTaxValue = this.RoundOfTax(frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).sRoundingMethod, nCalculateTaxValue, tblVoucherPosting_colnDecimalsInAmount.Number);
                    nDeductValue = 0;
                }
                nCalculatedTaxValue = nCalculateTaxValue;
            }
            return nDeductValue;
            
            #endregion
        }
        // Bug 97225, End
        /// <summary>
        /// </summary>
        /// <param name="nCurrenctRow1"></param>
        /// <returns></returns>
        public virtual SalBoolean SetParentKey(SalNumber nCurrenctRow1)
        {
            SalNumber nRow = Sys.TBL_MinRow;
            while (Sal.TblFindNextRow(tblVoucherPosting, ref nRow, (Sys.ROW_Edited | Sys.ROW_New), Sys.ROW_MarkDeleted))
            {
                Sal.TblSetContext(tblVoucherPosting, nRow);
                if ((tblVoucherPosting_colnAccountingYear.Number == frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfnAccountingYear.Number) && (tblVoucherPosting_colsVoucherType.Text == SalString.FromHandle(frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(
                            i_hWndFrame)).ccsVoucherType.EditDataItemValueGet())) && (tblVoucherPosting_colnVoucherNo.Number == frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfnVoucherNo.Number))
                {
                    Sal.TblSetContext(tblVoucherPosting, nCurrenctRow1);
                    return false;
                }
                tblVoucherPosting_colnAccountingYear.EditDataItemValueSet(1, frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfnAccountingYear.Number.ToString(0).ToHandle());
                tblVoucherPosting_colsVoucherType.EditDataItemValueSet(1, frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).ccsVoucherType.EditDataItemValueGet());
                tblVoucherPosting_colnVoucherNo.EditDataItemValueSet(1, frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfnVoucherNo.Number.ToString(0).ToHandle());
                tblVoucherPosting_colsFunctionGroup.EditDataItemValueSet(1, frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfsVoucherGroup.EditDataItemValueGet());
                if (frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).sParallelCurrency == Ifs.Fnd.ApplicationForms.Const.strNULL)
                {
                    if (!(Sal.IsNull(tblVoucherPosting_colnDebetAmount)))
                    {
                        tblVoucherPosting_colnThirdCurrencyDebitAmount.Number = 0;
                        tblVoucherPosting_colnThirdCurrencyAmount.Number = 0;
                        tblVoucherPosting_colnThirdCurrencyCreditAmount.Number = Sys.NUMBER_Null;
                    }
                    else if (!(Sal.IsNull(tblVoucherPosting_colnCreditAmount)))
                    {
                        tblVoucherPosting_colnThirdCurrencyCreditAmount.Number = 0;
                        tblVoucherPosting_colnThirdCurrencyAmount.Number = 0;
                        tblVoucherPosting_colnThirdCurrencyDebitAmount.Number = Sys.NUMBER_Null;
                    }
                }
            }
            return true;
        }

        public virtual SalNumber GetParallelCurrencyRate()
        {

            #region Local Variables
            SalString sParallelCurrencyBaseType = "";
            #endregion

            sParallelCurrencyBaseType = this.i_sFinParallelBaseType;

            if (sParallelCurrencyBaseType != SalString.Null)
            {
                IDictionary<string, string> namedBindVariables = new Dictionary<string, string>();
                namedBindVariables.Add("nFinThirdCurrencyRate", this.QualifiedVarBindName("nFinThirdCurrencyRate"));
                namedBindVariables.Add("nFinThirdConversionFactor", this.QualifiedVarBindName("nFinThirdConversionFactor"));
                namedBindVariables.Add("lsFinThirdInverted", this.QualifiedVarBindName("lsFinThirdInverted"));
                namedBindVariables.Add("colsCompany", this.tblVoucherPosting_colsCompany.QualifiedBindName);
                namedBindVariables.Add("colsCurrencyCode", this.tblVoucherPosting_colsCurrencyCode.QualifiedBindName);
                namedBindVariables.Add("dfdVoucherDate", ":i_hWndParent.frmEntryVoucher.dfdVoucherDate");
                namedBindVariables.Add("colnParallelCurrRateType", this.tblVoucherPosting_colnParallelCurrRateType.QualifiedBindName);
                namedBindVariables.Add("i_sFinParallelBaseType", this.QualifiedVarBindName("i_sFinParallelBaseType"));
                namedBindVariables.Add("i_sFinBaseCurrencyCode", this.QualifiedVarBindName("i_sFinBaseCurrencyCode"));
                namedBindVariables.Add("i_sFinThirdCurrencyCode", this.QualifiedVarBindName("i_sFinThirdCurrencyCode"));
                namedBindVariables.Add("sNullValue", this.QualifiedVarBindName("sNullValue"));


                if (DbPLSQLBlock(@" BEGIN 
                                       &AO.Currency_Rate_API.Get_Parallel_Currency_Rate({nFinThirdCurrencyRate} OUT, 
                                                                                    {nFinThirdConversionFactor} OUT,  
                                                                                    {lsFinThirdInverted} OUT, 
                                                                                    {colsCompany} IN, 
                                                                                    {colsCurrencyCode} IN, 
                                                                                    {dfdVoucherDate} IN, 
                                                                                    {colnParallelCurrRateType} IN, 
                                                                                    {i_sFinParallelBaseType} IN, 
                                                                                    {i_sFinBaseCurrencyCode} IN, 
                                                                                    {i_sFinThirdCurrencyCode} IN, 
                                                                                    {sNullValue} IN, 
                                                                                    {sNullValue} IN  );                                       
                                    END;", namedBindVariables))
                {
                    this.i_nFinThirdConversionFactor = nFinThirdConversionFactor;
                    this.i_nFinThirdCurrencyRate = nFinThirdCurrencyRate;
                    this.i_lsFinThirdInverted = lsFinThirdInverted;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// To set the values for ThirdCurrency DebitAmount, CreditAmount and Amount
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber SetThirdCurrencyAmounts()
        {
            #region Local Variables
            SalNumber nThirdCurrencyCurrencyAmount = 0;
            SalString sParallelCurrencyBaseType = "";
            #endregion

            #region Actions

            if (sMode != "DUPLICATED")
            {
                sParallelCurrencyBaseType = this.i_sFinParallelBaseType;                

                if (tblVoucherPosting_colnParallelCurrRate.Number != SalNumber.Null && bCopyParallelCurrRate)
                    this.i_nFinThirdCurrencyRate = tblVoucherPosting_colnParallelCurrRate.Number;
                else if (!(bCopyParallelCurrRate))
                {
                    this.tblVoucherPosting_colnParallelCurrRate.Number = this.i_nFinThirdCurrencyRate;
                    tblVoucherPosting_colnParallelCurrRate.EditDataItemSetEdited();
                    this.tblVoucherPosting_colnParallelCurrConvFactor.Number = this.i_nFinThirdConversionFactor;
                    tblVoucherPosting_colnParallelCurrConvFactor.EditDataItemSetEdited();
                }

                using (new SalContext(this))
                {
                    if (frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).sParallelCurrency == Ifs.Fnd.ApplicationForms.Const.strNULL)
                    {
                        if (!(frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).nParallelRate == SalNumber.Null))
                        {
                            if (!(Sal.IsNull(tblVoucherPosting_colnDebetAmount)))
                            {
                                tblVoucherPosting_colnThirdCurrencyDebitAmount.Number = Sys.NUMBER_Null;
                                tblVoucherPosting_colnThirdCurrencyAmount.Number = 0;
                                tblVoucherPosting_colnThirdCurrencyCreditAmount.Number = Sys.NUMBER_Null;
                            }
                            else if (!(Sal.IsNull(tblVoucherPosting_colnCreditAmount)))
                            {
                                tblVoucherPosting_colnThirdCurrencyCreditAmount.Number = Sys.NUMBER_Null;
                                tblVoucherPosting_colnThirdCurrencyAmount.Number = 0;
                                tblVoucherPosting_colnThirdCurrencyDebitAmount.Number = Sys.NUMBER_Null;
                            }
                        }
                    }

                    else if ((Sal.IsNull(tblVoucherPosting_colnCurrencyDebetAmount) || Sal.IsNull(tblVoucherPosting_colnCurrencyCreditAmount)) && Sal.IsNull(tblVoucherPosting_colnCurrencyAmount) && sParallelCurrencyBaseType == "TRANSACTION_CURRENCY")
                    {
                        if (!(Sal.IsNull(tblVoucherPosting_colnDebetAmount)))
                        {
                            tblVoucherPosting_colnThirdCurrencyDebitAmount.Number = 0;
                            tblVoucherPosting_colnThirdCurrencyAmount.Number = 0;
                            tblVoucherPosting_colnThirdCurrencyCreditAmount.Number = Sys.NUMBER_Null;
                        }
                        else if (!(Sal.IsNull(tblVoucherPosting_colnCreditAmount)))
                        {
                            tblVoucherPosting_colnThirdCurrencyCreditAmount.Number = 0;
                            tblVoucherPosting_colnThirdCurrencyAmount.Number = 0;
                            tblVoucherPosting_colnThirdCurrencyDebitAmount.Number = Sys.NUMBER_Null;
                        }
                        else
                        {
                            tblVoucherPosting_colnThirdCurrencyDebitAmount.Number = Sys.NUMBER_Null;
                            tblVoucherPosting_colnThirdCurrencyAmount.Number = 0;
                            tblVoucherPosting_colnThirdCurrencyCreditAmount.Number = Sys.NUMBER_Null;
                        }
                    }
                    else if ((Sal.IsNull(tblVoucherPosting_colnDebetAmount) || Sal.IsNull(tblVoucherPosting_colnCreditAmount)) && Sal.IsNull(tblVoucherPosting_colnAmount) && sParallelCurrencyBaseType == "ACCOUNTING_CURRENCY")
                    {
                        if (!(Sal.IsNull(tblVoucherPosting_colnCurrencyDebetAmount)))
                        {
                            tblVoucherPosting_colnThirdCurrencyDebitAmount.Number = 0;
                            tblVoucherPosting_colnThirdCurrencyAmount.Number = 0;
                            tblVoucherPosting_colnThirdCurrencyCreditAmount.Number = Sys.NUMBER_Null;
                        }
                        else if (!(Sal.IsNull(tblVoucherPosting_colnCurrencyCreditAmount)))
                        {
                            tblVoucherPosting_colnThirdCurrencyCreditAmount.Number = 0;
                            tblVoucherPosting_colnThirdCurrencyAmount.Number = 0;
                            tblVoucherPosting_colnThirdCurrencyDebitAmount.Number = Sys.NUMBER_Null;
                        }
                        else
                        {
                            tblVoucherPosting_colnThirdCurrencyDebitAmount.Number = 0;
                            tblVoucherPosting_colnThirdCurrencyAmount.Number = 0;
                            tblVoucherPosting_colnThirdCurrencyCreditAmount.Number = Sys.NUMBER_Null;
                        }
                    }
                    else
                    {
                        if (frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).sParallelCurrency == tblVoucherPosting_colsCurrencyCode.Text)
                        {
                            if (!(Sal.IsNull(tblVoucherPosting_colnCurrencyDebetAmount)))
                            {
                                tblVoucherPosting_colnThirdCurrencyDebitAmount.Number = tblVoucherPosting_colnCurrencyDebetAmount.Number;
                                tblVoucherPosting_colnThirdCurrencyDebitAmount.EditDataItemSetEdited();
                                tblVoucherPosting_colnThirdCurrencyAmount.Number = tblVoucherPosting_colnCurrencyDebetAmount.Number;
                                tblVoucherPosting_colnThirdCurrencyCreditAmount.Number = Sys.NUMBER_Null;
                                // Bug 87017, Begin
                                tblVoucherPosting_colnThirdCurrencyCreditAmount.EditDataItemSetEdited();
                                // Bug 87017, End
                            }
                            else if (!(Sal.IsNull(tblVoucherPosting_colnCurrencyCreditAmount)))
                            {
                                tblVoucherPosting_colnThirdCurrencyCreditAmount.Number = tblVoucherPosting_colnCurrencyCreditAmount.Number;
                                tblVoucherPosting_colnThirdCurrencyCreditAmount.EditDataItemSetEdited();
                                tblVoucherPosting_colnThirdCurrencyAmount.Number = -tblVoucherPosting_colnCurrencyCreditAmount.Number;
                                tblVoucherPosting_colnThirdCurrencyDebitAmount.Number = Sys.NUMBER_Null;
                                // Bug 87017, Begin
                                tblVoucherPosting_colnThirdCurrencyDebitAmount.EditDataItemSetEdited();
                                // Bug 87017, End
                            }
                        }
                        else
                        {
                            if (!(frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).GetParallelCurrencyAttributes()))
                            {
                                return false;
                            }
                            if (!(frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).nParallelRate == SalNumber.Null))
                            {
                                if (!(Sal.IsNull(tblVoucherPosting_colnDebetAmount)))
                                {

                                    nAmount = tblVoucherPosting_colnDebetAmount.Number;
                                    nCurrAmount = tblVoucherPosting_colnCurrencyDebetAmount.Number;
                                    if (sParallelCurrencyBaseType != SalString.Null)
                                    {
                                        this.GetThirdCurrencyAmount(nAmount, nCurrAmount, ref nThirdCurrencyCurrencyAmount);

                                        tblVoucherPosting_colnThirdCurrencyDebitAmount.Number = nThirdCurrencyCurrencyAmount;
                                        tblVoucherPosting_colnThirdCurrencyAmount.Number = tblVoucherPosting_colnThirdCurrencyDebitAmount.Number;
                                        tblVoucherPosting_colnThirdCurrencyDebitAmount.EditDataItemSetEdited();
                                        tblVoucherPosting_colnThirdCurrencyCreditAmount.Number = Sys.NUMBER_Null;
                                        // Bug 87017, Begin
                                        tblVoucherPosting_colnThirdCurrencyCreditAmount.EditDataItemSetEdited();
                                        // Bug 87017, End
                                    }
                                }
                                else if (!(Sal.IsNull(tblVoucherPosting_colnCreditAmount)))
                                {

                                    nAmount = tblVoucherPosting_colnCreditAmount.Number;
                                    nCurrAmount = tblVoucherPosting_colnCurrencyCreditAmount.Number;
                                    if (sParallelCurrencyBaseType != SalString.Null)
                                    {
                                        this.GetThirdCurrencyAmount(nAmount, nCurrAmount, ref nThirdCurrencyCurrencyAmount);

                                        tblVoucherPosting_colnThirdCurrencyCreditAmount.Number = nThirdCurrencyCurrencyAmount;
                                        tblVoucherPosting_colnThirdCurrencyAmount.Number = -tblVoucherPosting_colnThirdCurrencyCreditAmount.Number;
                                        tblVoucherPosting_colnThirdCurrencyCreditAmount.EditDataItemSetEdited();
                                        tblVoucherPosting_colnThirdCurrencyDebitAmount.Number = Sys.NUMBER_Null;
                                        // Bug 87017, Begin
                                        tblVoucherPosting_colnThirdCurrencyDebitAmount.EditDataItemSetEdited();
                                        // Bug 87017, End
                                    }
                                }
                            }
                        }
                    }
                    CalcualteParallelCurrTaxValue("RATE");
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber SetValueOfProjectID()
        {
            SalString sProjectCodePart = Var.FinlibServices.GetCodePartFunction("PRACC");
            SalNumber nChildCount = 0;
            while (nChildCount < tblVoucherPosting.i_nChildCount)
            {
                if (tblVoucherPosting.i_nChildType[nChildCount] & Ifs.Fnd.ApplicationForms.Const.CHILDTYPE_DataItem)
                {
                    if ((Sal.WindowClassName(tblVoucherPosting.i_hWndChild[nChildCount]) == "cColumnCodePartFin") && (cColumn.FromHandle(tblVoucherPosting.i_hWndChild[nChildCount]).p_sSqlColumn == "CODE_" + sProjectCodePart))
                    {
                        tblVoucherPosting_colsProjectId.Text = SalString.FromHandle(Sal.SendMsg(tblVoucherPosting.i_hWndChild[nChildCount], Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueGet, 0, 0));
                        break;
                    }
                }
                nChildCount = nChildCount + 1;
            }
            return 0;
        }

        /// <summary>
        /// IID 10114 to check job type
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean SetValueOfActivityID()
        {
            #region Local Variables
            SalBoolean sPorjectOriginJob = false;
            SalString sCacheReturn = "";
            #endregion

            #region Actions
            // use cache to avoide unessary server calling
            sProjectOrigin = Ifs.Fnd.ApplicationForms.Const.strNULL;
            sCacheReturn = Ifs.Fnd.ApplicationForms.Const.strNULL;
            if (this.CacheInfo.SessionRetrieve(" frmVoucherPostingtblVoucherPosting " + tblVoucherPosting_colsCompany.Text + sParam, ref sCacheReturn))
            {
                sProjectOrigin = sCacheReturn;
            }
            else
            {
                if (Int.IsGenLedInstalled && Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Accounting_Project_API.Get_Project_Origin_Db"))
                {
                    if (!(DbPLSQLBlock(@"{0} := &AO.Accounting_Project_API.Get_Project_Origin_Db({1} IN,{2} IN );",
                        this.QualifiedVarBindName("sProjectOrigin"),
                        this.tblVoucherPosting_colsCompany.QualifiedBindName,
                        this.QualifiedVarBindName("sParam"))))
                    {
                        return false;
                    }  
                }
                this.CacheInfo.SessionStore(" frmVoucherPostingtblVoucherPosting " + tblVoucherPosting_colsCompany.Text + sParam, sProjectOrigin);
            }
            if (sProjectOrigin == "JOB")
            {
                sPorjectOriginJob = true;
            }
            else if (sProjectOrigin == "FINPROJECT" || sProjectOrigin == "PROJECT")
            {
                sPorjectOriginJob = false;
            }
            else
            {
                sPorjectOriginJob = false;
            }
            this.sProjectOriginGlobal = sProjectOrigin;
            return sPorjectOriginJob;     
            #endregion
        }
        // Bug 69891, Begin. Removed Function SetVoucherNo. Added new function SetHeaderInfo.
        /// <summary>
        /// Set Voucher Number after save the whole Voucher without error if it is Automatic
        /// </summary>
        /// <param name="nVoucherNo"></param>
        /// <param name="sTransferId"></param>
        /// <returns></returns>
        public virtual SalBoolean SetHeaderInfo(SalNumber nVoucherNo, SalString sTransferId)
        {
            SalNumber nRow = Sys.TBL_MinRow;
            if (nVoucherNo != 0)
            {
                while (Sal.TblFindNextRow(tblVoucherPosting, ref nRow, 0, 0))
                {
                    Sal.TblSetContext(tblVoucherPosting, nRow);
                    tblVoucherPosting_colnVoucherNo.Number = nVoucherNo;
                    tblVoucherPosting_colsTransferId.Text = sTransferId;
                    tblVoucherPosting_colsTransferId.EditDataItemSetEdited();
                }
            }
            return true;
        }
        // Bug 69891, End.
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean UseTemplates()
        {
            #region Local Variables
            SalString sIsProjectCodePart = "";
            SalNumber nFetch = 0;
            SalString IsStmt = "";
            SalString IsStmt2 = "";
            SalString IsStmt3 = "";
            SalSqlHandle hSql = SalSqlHandle.Null;
            SalNumber nPosi = 0;
            SalNumber nMinRange = 0;
            SalNumber nMaxRange = 0;
            SalNumber nRow = 0;
            SalNumber nActivitySeq = SalNumber.Null;
            #endregion

            #region Actions
       
            sFormName = this.QualifiedBindName + ".";  
            sIsProjectCodePart = Var.FinlibServices.GetCodePartFunction("PRACC");
            // To get to the last row in the child and remove the selection bar
            Sal.TblQueryScroll(this.tblVoucherPosting, ref nPosi, ref nMinRange, ref nMaxRange);
            Sal.TblSetFocusRow(this.tblVoucherPosting, nMaxRange);

            IsStmt = " SELECT COMPANY,  ACCOUNT, CODE_B, CODE_C, CODE_D, CODE_E, CODE_F, CODE_G, CODE_H, CODE_I, CODE_J, ACCOUNT_DESC, CODE_B_DESC, CODE_C_DESC, CODE_D_DESC, CODE_E_DESC, CODE_F_DESC, CODE_G_DESC, CODE_H_DESC, CODE_I_DESC, CODE_J_DESC, " +
            " PROCESS_CODE, CURRENCY_CODE, CONV_FACTOR, DEBIT_CURRENCY_AMOUNT, CREDIT_CURRENCY_AMOUNT, CURRENCY_AMOUNT, DEBIT_AMOUNT, CREDIT_AMOUNT, AMOUNT, CURRENCY_RATE, CORRECTION, QUANTITY, TEXT, OPTIONAL_CODE, TRANS_CODE, CURRENCY_TYPE, DECIMALS_IN_AMOUNT, ACC_DECIMALS_IN_AMOUNT," +
            "&AO.Account_API.Get_Required_Code_Part(COMPANY, ACCOUNT), PROJECT_ACTIVITY_ID, &AO.ACCOUNT_API.Is_Stat_Account(COMPANY,ACCOUNT), DELIV_TYPE_ID, &AO.VOUCHER_ROW_API.Get_Delivery_Type_Description(COMPANY, DELIV_TYPE_ID)";
            IsStmt2 = " INTO " + sFormName + "tblVoucherPosting_colsCompany," + sFormName + "tblVoucherPosting_colsAccount," + sFormName + "tblVoucherPosting_colsCodeB," + sFormName + "tblVoucherPosting_colsCodeC," + sFormName + "tblVoucherPosting_colsCodeD," + sFormName + "tblVoucherPosting_colsCodeE," + sFormName + "tblVoucherPosting_colsCodeF," + sFormName + "tblVoucherPosting_colsCodeG," +
            sFormName + "tblVoucherPosting_colsCodeH," + sFormName + "tblVoucherPosting_colsCodeI," + sFormName + "tblVoucherPosting_colsCodeJ," + sFormName + "tblVoucherPosting_colsAccountDesc," + sFormName + "tblVoucherPosting_colsCodeBDesc," + sFormName + "tblVoucherPosting_colsCodeCDesc," + sFormName + "tblVoucherPosting_colsCodeDDesc," + sFormName + "tblVoucherPosting_colsCodeEDesc," +
            sFormName + "tblVoucherPosting_colsCodeFDesc," + sFormName + "tblVoucherPosting_colsCodeGDesc," + sFormName + "tblVoucherPosting_colsCodeHDesc," + sFormName + "tblVoucherPosting_colsCodeIDesc, " + sFormName + "tblVoucherPosting_colsCodeJDesc," + sFormName + "tblVoucherPosting_colsProcessCode," + sFormName + "tblVoucherPosting_colsCurrencyCode," + sFormName + "tblVoucherPosting_colnConversionFactor," +
            sFormName + "tblVoucherPosting_colnCurrencyDebetAmount," + sFormName + "tblVoucherPosting_colnCurrencyCreditAmount," + sFormName + "tblVoucherPosting_colnCurrencyAmount," + sFormName + "tblVoucherPosting_colnDebetAmount," + sFormName + "tblVoucherPosting_colnCreditAmount," + sFormName + "tblVoucherPosting_colnAmount," + sFormName + "tblVoucherPosting_colnCurrencyRate," +
            sFormName + "tblVoucherPosting_colCorrection," + sFormName + "tblVoucherPosting_colnQuantity, " + sFormName + "tblVoucherPosting_colsText," + sFormName + "tblVoucherPosting_colsOptionalCode," + sFormName + "tblVoucherPosting_colsTransCode," + sFormName + "tblVoucherPosting_colsCurrencyType," + sFormName + "tblVoucherPosting_colnDecimalsInAmount," + sFormName +
            "tblVoucherPosting_colnAccDecimalsInAmount," + sFormName + "tblVoucherPosting_colsCodeDemand," + sFormName + "tblVoucherPosting_colnProjectActivityId," + sFormName + "tblVoucherPosting_colIsStatAccount," + sFormName + "tblVoucherPosting_colsDeliveryTypeId," + sFormName + "tblVoucherPosting_colsDeliveryTypeDescription";
            sFinalTemplateList = frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).sTemplateList;
            IsStmt3 = " FROM   &AO.VOUCHER_TEMPLATE_ROW  WHERE COMPANY = " + sFormName + "i_sCompany" + "  AND ( TEMPLATE  =  " + sFinalTemplateList + " )";
            this.bCopyFromTemplate = true;
            bTemplateOrCopyGL = true;
            bUseVouTemplate = true;
            if (DbConnect(ref hSql))
            {
                if (DbPrepareAndExecute(hSql, IsStmt + IsStmt2 + IsStmt3))
                {
                    this.DataRecordNew(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
                    while (DbFetchNext(hSql, ref nFetch))
                    {
                        tblVoucherPosting.i_nDataSourceState = Ifs.Fnd.ApplicationForms.Const.DATASOURCE_Changed;
                        bCalculateParallelCurrTax = false;
                        if (!(Sal.IsNull(tblVoucherPosting_colsOptionalCode)))
                        {
                            GetTaxType();
                            if (Sal.IsNull(tblVoucherPosting_colnCurrencyRate) || (tblVoucherPosting_colnCurrencyRate.Number == 0))
                            {
                                if (!(this.GetAttributes(tblVoucherPosting_colsCompany.Text, tblVoucherPosting_colsCurrencyCode.Text, frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).sCurrencyCode, tblVoucherPosting_colsCurrencyType.Text, frmEntryVoucher.FromHandle(
                                        Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfdVoucherDate.DateTime)))
                                {
                                    return false;
                                }
                                nPrevRate = tblVoucherPosting_colnCurrencyRate.Number;
                                tblVoucherPosting_colnCurrencyRate.Number = this.GetRate(tblVoucherPosting_colsCompany.Text, tblVoucherPosting_colsCurrencyCode.Text);
                                tblVoucherPosting_colnActCurrencyRate.Number = tblVoucherPosting_colnCurrencyRate.Number;
                            }
                            else
                            {
                                tblVoucherPosting_colnActCurrencyRate.Number = tblVoucherPosting_colnCurrencyRate.Number;
                            }
                            if (tblVoucherPosting_colsTaxType.Text == "NOTAX")
                            {
                                tblVoucherPosting_colsTaxDirection.Text = frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).sTaxDirectionNoTax;
                            }
                            else
                            {
                          
                                if (!(DbPLSQLBlock(@"{0} := &AO.Account_API.Get_Logical_Account_Type_Db({1} IN, {2} IN )",
                                    this.QualifiedVarBindName("sLogicalAccountType"),
                                    this.tblVoucherPosting_colsCompany.QualifiedBindName,
                                    this.tblVoucherPosting_colsAccount.QualifiedBindName)))
                                {
                                    return false;
                                }
                                
                                if ((sLogicalAccountType == "A") || (sLogicalAccountType == "C"))
                                {
                                    tblVoucherPosting_colsTaxDirection.Text = frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).sTaxDirectionReceived;
                                }
                                else if ((sLogicalAccountType == "L") || (sLogicalAccountType == "R") || (sLogicalAccountType == "S") || (sLogicalAccountType == "O"))
                                {
                                    tblVoucherPosting_colsTaxDirection.Text = frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).sTaxDirectionDisbursed;
                                }
                            }

                            // Bug 97225, Begin

                            if (!(Sal.IsNull(tblVoucherPosting_colnCurrencyAmount)) && (tblVoucherPosting_colnCurrencyAmount.Number != 0))
                            {
                                if (!(Sal.IsNull(tblVoucherPosting_colnCurrencyDebetAmount)))
                                {
                                    tblVoucherPosting_colnCurrencyDebetAmount.Number = SetAnotherValue(tblVoucherPosting_colnCurrencyDebetAmount.Number, tblVoucherPosting_colnDebetAmount, "CURRENT_AMOUNT", ref nCalculatedTaxValue);
                                    SetTaxValue(tblVoucherPosting_colnCurrencyDebetAmount.Number, tblVoucherPosting_colnCurrencyDebetAmount.Number - 1, tblVoucherPosting_colnCurrencyTaxAmount, sAmountMethodDb, "CURRENT_AMOUNT", nCalculatedTaxValue);
                                }
                                else if (!(Sal.IsNull(tblVoucherPosting_colnCurrencyCreditAmount)))
                                {
                                    tblVoucherPosting_colnCurrencyCreditAmount.Number = -SetAnotherValue(-tblVoucherPosting_colnCurrencyCreditAmount.Number, tblVoucherPosting_colnCreditAmount, "CURRENT_AMOUNT", ref nCalculatedTaxValue);
                                    SetTaxValue(tblVoucherPosting_colnCurrencyCreditAmount.Number, tblVoucherPosting_colnCurrencyCreditAmount.Number - 1, tblVoucherPosting_colnCurrencyTaxAmount, sAmountMethodDb, "CURRENT_AMOUNT", nCalculatedTaxValue);
                                }
                            }
                            else if (!(Sal.IsNull(tblVoucherPosting_colnAmount)) && (tblVoucherPosting_colnAmount.Number != 0))
                            {
                                if (!(Sal.IsNull(tblVoucherPosting_colnDebetAmount)))
                                {
                                    tblVoucherPosting_colnDebetAmount.Number = SetAnotherValue(tblVoucherPosting_colnDebetAmount.Number, tblVoucherPosting_colnCurrencyDebetAmount, "ACCOUNTING_AMOUNT", ref nCalculatedTaxValue);
                                    SetTaxValue(tblVoucherPosting_colnDebetAmount.Number, tblVoucherPosting_colnDebetAmount.Number - 1, tblVoucherPosting_colnTaxAmount, sAmountMethodDb, "ACCOUNTING_AMOUNT", nCalculatedTaxValue);
                                }
                                else if (!(Sal.IsNull(tblVoucherPosting_colnCreditAmount)))
                                {
                                    tblVoucherPosting_colnCreditAmount.Number = -SetAnotherValue(-tblVoucherPosting_colnCreditAmount.Number, tblVoucherPosting_colnCurrencyCreditAmount, "ACCOUNTING_AMOUNT", ref nCalculatedTaxValue);
                                    SetTaxValue(tblVoucherPosting_colnCreditAmount.Number, tblVoucherPosting_colnCreditAmount.Number - 1, tblVoucherPosting_colnTaxAmount, sAmountMethodDb, "ACCOUNTING_AMOUNT", nCalculatedTaxValue);
                                }
                            }
                            else if (Sal.IsNull(tblVoucherPosting_colnAmount) || (tblVoucherPosting_colnAmount.Number == 0))
                            {
                                if ((tblVoucherPosting_colnCurrencyAmount.Number < 0 && tblVoucherPosting_colCorrection.Text == "Y") || (tblVoucherPosting_colnCurrencyAmount.Number >= 0 && tblVoucherPosting_colCorrection.Text == "N"))
                                {
                                    if (!(Sal.IsNull(tblVoucherPosting_colnDebetAmount)))
                                    {
                                        tblVoucherPosting_colnCurrencyDebetAmount.Number = SetAnotherValue(tblVoucherPosting_colnCurrencyAmount.Number, tblVoucherPosting_colnDebetAmount, "CURRENT_AMOUNT", ref nCalculatedTaxValue);
                                        SetTaxValue(tblVoucherPosting_colnCurrencyDebetAmount.Number, tblVoucherPosting_colnCurrencyDebetAmount.Number - 1, tblVoucherPosting_colnCurrencyTaxAmount, sAmountMethodDb, "CURRENT_AMOUNT", nCalculatedTaxValue);
                                    }
                                    if (!(Sal.IsNull(tblVoucherPosting_colnCreditAmount)))
                                    {
                                        tblVoucherPosting_colnCurrencyCreditAmount.Number = -SetAnotherValue(tblVoucherPosting_colnCurrencyAmount.Number, tblVoucherPosting_colnCreditAmount, "CURRENT_AMOUNT", ref nCalculatedTaxValue);
                                        SetTaxValue(tblVoucherPosting_colnCreditAmount.Number, tblVoucherPosting_colnCreditAmount.Number - 1, tblVoucherPosting_colnTaxAmount, sAmountMethodDb, "CURRENT_AMOUNT", nCalculatedTaxValue);
                                    }
                                }
                                else
                                {
                                    if (!(Sal.IsNull(tblVoucherPosting_colnDebetAmount)))
                                    {
                                        tblVoucherPosting_colnCurrencyDebetAmount.Number = SetAnotherValue(tblVoucherPosting_colnCurrencyAmount.Number, tblVoucherPosting_colnDebetAmount, "CURRENT_AMOUNT", ref nCalculatedTaxValue);
                                        SetTaxValue(tblVoucherPosting_colnCurrencyDebetAmount.Number, tblVoucherPosting_colnCurrencyDebetAmount.Number - 1, tblVoucherPosting_colnCurrencyTaxAmount, sAmountMethodDb, "CURRENT_AMOUNT", nCalculatedTaxValue);
                                    }
                                    if (!(Sal.IsNull(tblVoucherPosting_colnCreditAmount)))
                                    {
                                        tblVoucherPosting_colnCurrencyCreditAmount.Number = -SetAnotherValue(tblVoucherPosting_colnCurrencyAmount.Number, tblVoucherPosting_colnCreditAmount, "CURRENT_AMOUNT", ref nCalculatedTaxValue);
                                        SetTaxValue(tblVoucherPosting_colnCreditAmount.Number, tblVoucherPosting_colnCreditAmount.Number - 1, tblVoucherPosting_colnTaxAmount, sAmountMethodDb, "CURRENT_AMOUNT", nCalculatedTaxValue);
                                    }
                                }
                            }
                            // Bug 97225, End
                        }
                        else
                        {
                            // Bug 97225, Begin
                            // Since tax code is null we cant calculate the tax values.
                            // Since no tax code no tax calculations is needed
                            sCalculateTax = "FALSE";
                            if (Sal.IsNull(tblVoucherPosting_colnCurrencyRate) || (tblVoucherPosting_colnCurrencyRate.Number == 0))
                            {
                                if (!(this.GetAttributes(tblVoucherPosting_colsCompany.Text, tblVoucherPosting_colsCurrencyCode.Text, frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).sCurrencyCode, tblVoucherPosting_colsCurrencyType.Text, frmEntryVoucher.FromHandle(
                                        Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfdVoucherDate.DateTime)))
                                {
                                    return false;
                                }
                                nPrevRate = tblVoucherPosting_colnCurrencyRate.Number;
                                tblVoucherPosting_colnCurrencyRate.Number = this.GetRate(tblVoucherPosting_colsCompany.Text, tblVoucherPosting_colsCurrencyCode.Text);
                                tblVoucherPosting_colnActCurrencyRate.Number = tblVoucherPosting_colnCurrencyRate.Number;
                            }
                            if (Sal.IsNull(tblVoucherPosting_colnAmount) || (tblVoucherPosting_colnAmount.Number == 0))
                            {
                                if ((tblVoucherPosting_colnCurrencyAmount.Number < 0 && tblVoucherPosting_colCorrection.Text == "Y") || (tblVoucherPosting_colnCurrencyAmount.Number >= 0 && tblVoucherPosting_colCorrection.Text == "N"))
                                {
                                    if (!(Sal.IsNull(tblVoucherPosting_colnDebetAmount)))
                                    {
                                        tblVoucherPosting_colnCurrencyDebetAmount.Number = SetAnotherValue(tblVoucherPosting_colnCurrencyAmount.Number, tblVoucherPosting_colnDebetAmount, "CURRENT_AMOUNT", ref nCalculatedTaxValue);
                                    }
                                    if (!(Sal.IsNull(tblVoucherPosting_colnCreditAmount)))
                                    {
                                        tblVoucherPosting_colnCurrencyCreditAmount.Number = -SetAnotherValue(tblVoucherPosting_colnCurrencyAmount.Number, tblVoucherPosting_colnCreditAmount, "CURRENT_AMOUNT", ref nCalculatedTaxValue);
                                    }
                                }
                                else
                                {
                                    if (!(Sal.IsNull(tblVoucherPosting_colnDebetAmount)))
                                    {
                                        tblVoucherPosting_colnCurrencyDebetAmount.Number = SetAnotherValue(tblVoucherPosting_colnCurrencyAmount.Number, tblVoucherPosting_colnDebetAmount, "CURRENT_AMOUNT", ref nCalculatedTaxValue);
                                    }
                                    if (!(Sal.IsNull(tblVoucherPosting_colnCreditAmount)))
                                    {
                                        tblVoucherPosting_colnCurrencyCreditAmount.Number = -SetAnotherValue(tblVoucherPosting_colnCurrencyAmount.Number, tblVoucherPosting_colnCreditAmount, "CURRENT_AMOUNT", ref nCalculatedTaxValue);
                                    }
                                }
                            }
                            if (!(Sal.IsNull(tblVoucherPosting_colnAmount)) && (tblVoucherPosting_colnAmount.Number != 0))
                            {
                                tblVoucherPosting_colnCurrencyTaxAmount.Number = 0;
                                tblVoucherPosting_colnTaxAmount.Number = 0;
                            }
                            sCalculateTax = Ifs.Fnd.ApplicationForms.Const.strNULL;
                            // Bug 97225, End
                        }
                        bCalculateParallelCurrTax = true;
                        if (this.i_sFinThirdCurrencyCode != SalString.Null)
                        {

                            DbPLSQLBlock(@"{0} := &AO.Company_Finance_API.Get_Parallel_Rate_Type({1} IN );",
                                        this.tblVoucherPosting_colnParallelCurrRateType.QualifiedBindName,
                                        this.tblVoucherPosting_colsCompany.QualifiedBindName);

                            tblVoucherPosting_colnParallelCurrRateType.EditDataItemSetEdited();
                            bCopyParallelCurrRate = false;
                            SetThirdCurrencyAmounts();
                            bCopyParallelCurrRate = true;
                        }
                        tblVoucherPosting_colsPrevAccount.Text = tblVoucherPosting_colsAccount.Text;
                        tblVoucherPosting_colsPrevTaxCode.Text = tblVoucherPosting_colsOptionalCode.Text;
                        tblVoucherPosting_colsPrevCurrencyCode.Text = tblVoucherPosting_colsCurrencyCode.Text;
                        if (frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).cbCorrection.Checked)
                        {
                            CreateCorrectionVoucher();
                        }
                        if (!(Sal.IsNull(tblVoucherPosting_colnDebetAmount)))
                        {
                            tblVoucherPosting_colnPrevCurrencyAmount.Number = tblVoucherPosting_colnCurrencyDebetAmount.Number;
                            tblVoucherPosting_colnPrevAmount.Number = tblVoucherPosting_colnDebetAmount.Number;
                        }
                        else if (!(Sal.IsNull(tblVoucherPosting_colnCreditAmount)))
                        {
                            tblVoucherPosting_colnPrevCurrencyAmount.Number = tblVoucherPosting_colnCurrencyCreditAmount.Number;
                            tblVoucherPosting_colnPrevAmount.Number = tblVoucherPosting_colnCreditAmount.Number;
                        }
                        SetAllEdited();
                        nActivitySeq = tblVoucherPosting_colnProjectActivityId.Number;
                        if (sIsProjectCodePart == "B")
                        {
                            EnableDisableProjectActivityId(tblVoucherPosting_colsCodeB.Text);
                        }
                        if (sIsProjectCodePart == "C")
                        {
                            EnableDisableProjectActivityId(tblVoucherPosting_colsCodeC.Text);
                        }
                        if (sIsProjectCodePart == "D")
                        {
                            EnableDisableProjectActivityId(tblVoucherPosting_colsCodeD.Text);
                        }
                        if (sIsProjectCodePart == "E")
                        {
                            EnableDisableProjectActivityId(tblVoucherPosting_colsCodeE.Text);
                        }
                        if (sIsProjectCodePart == "F")
                        {
                            EnableDisableProjectActivityId(tblVoucherPosting_colsCodeF.Text);
                        }
                        if (sIsProjectCodePart == "G")
                        {
                            EnableDisableProjectActivityId(tblVoucherPosting_colsCodeG.Text);
                        }
                        if (sIsProjectCodePart == "H")
                        {
                            EnableDisableProjectActivityId(tblVoucherPosting_colsCodeH.Text);
                        }
                        if (sIsProjectCodePart == "I")
                        {
                            EnableDisableProjectActivityId(tblVoucherPosting_colsCodeI.Text);
                        }
                        if (sIsProjectCodePart == "J")
                        {
                            EnableDisableProjectActivityId(tblVoucherPosting_colsCodeJ.Text);
                        }
                        tblVoucherPosting_colnProjectActivityId.Number = nActivitySeq;
                        if (this.tblVoucherPosting_colIsStatAccount.Text == "TRUE")
                        {
                            Sal.TblSetRowFlags(tblVoucherPosting, Sal.TblQueryContext(tblVoucherPosting), Sys.ROW_UnusedFlag1, true);
                        }
                        else
                        {
                            Sal.TblSetRowFlags(tblVoucherPosting, Sal.TblQueryContext(tblVoucherPosting), Sys.ROW_UnusedFlag1, false);
                        }

                        this.DataRecordNew(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);                        
                    }
                    this.DataRecordRemove(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);                  
                }
                DbDisconnect(hSql);
            }
            Sal.TblClearSelection(this.tblVoucherPosting);
            if (nMaxRange == -1)
            {
                Sal.TblSetFocusRow(tblVoucherPosting, 0);
            }
            else
            {
                Sal.TblSetFocusRow(tblVoucherPosting, nMaxRange);
            }
            bTemplateOrCopyGL = false;
            bUseVouTemplate = false;
            return true;
            
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber ValidateCurrencyCode()
        {
            #region Actions

                // Added IF condition to skip Validation when tblVoucherPosting_colsCurrencyCode or tblVoucherPosting_colsCurrencyType is NULL   
                if (!(Sal.IsNull(tblVoucherPosting_colsCurrencyCode)) && !(Sal.IsNull(tblVoucherPosting_colsCurrencyType)))
                {
                    if (!(this.GetAttributes(tblVoucherPosting_colsCompany.Text, tblVoucherPosting_colsCurrencyCode.Text, frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).sCurrencyCode, tblVoucherPosting_colsCurrencyType.Text, frmEntryVoucher.FromHandle(
                            Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfdVoucherDate.DateTime)))
                    {
                        return false;
                    }
                    nPrevRate = tblVoucherPosting_colnCurrencyRate.Number;
                    if (!(sMode == "DUPLICATED"))
                    {
                        tblVoucherPosting_colnCurrencyRate.Number = this.GetRate(tblVoucherPosting_colsCompany.Text, tblVoucherPosting_colsCurrencyCode.Text);
                        tblVoucherPosting_colnConversionFactor.Number = this.i_nFinConversionFactor;
                    }
                    tblVoucherPosting_colnActCurrencyRate.Number = tblVoucherPosting_colnCurrencyRate.Number;
                    tblVoucherPosting_colnCurrencyRate.EditDataItemSetEdited();
                    tblVoucherPosting_colnConversionFactor.EditDataItemSetEdited();
                    tblVoucherPosting_colnDecimalsInAmount.Number = this.i_nFinTransRound;

                    if (!Sal.IsNull(tblVoucherPosting_colnParallelCurrRateType) && sMode != "DUPLICATED")
                        Sal.PostMsg(tblVoucherPosting_colnParallelCurrRateType, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);

                    if (!(Sal.IsNull(tblVoucherPosting_colnCurrencyAmount)) && (tblVoucherPosting_colnCurrencyAmount.Number != 0))
                    {
                        // Bug 97225, Begin
                        SetAnotherValue(tblVoucherPosting_colnCurrencyRate.Number, tblVoucherPosting_colnCurrencyAmount, "RATE", ref nCalculatedTaxValue);
                        // Bug 97225, End
                    }
                                      
                    if (!(DbPLSQLBlock(@"{0} := &AO.Currency_Code_API.Get_Valid_Emu({1} IN,{2} IN,{3} IN)",
                                                                        this.QualifiedVarBindName("sIsValidEmuCurrency"),
                                                                        this.tblVoucherPosting_colsCompany.QualifiedBindName,
                                                                        this.tblVoucherPosting_colsCurrencyCode.QualifiedBindName,
                                                                        ":i_hWndParent.frmEntryVoucher.dfdVoucherDate")))
                    {
                        return false;
                    }
                }
                if ((frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).sIsCurrencyEmu == "TRUE") && (tblVoucherPosting_colsCurrencyCode.Text == "EUR"))
                {
                    sSetRateNotEnabled = "TRUE";
                }
                else
                {
                    sSetRateNotEnabled = "FALSE";
                }
                return true;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber ValidateCurrencyType()
        {
            if (!(DbPLSQLBlock(@"&AO.Currency_Type_API.Exist({0} IN,{1} IN )",
                    this.tblVoucherPosting_colsCompany.QualifiedBindName,
                    this.tblVoucherPosting_colsCurrencyType.QualifiedBindName)))
            {
                return false;
            }
                
            // Added IF condition to skip Validation when tblVoucherPosting_colsCurrencyCode or tblVoucherPosting_colsCurrencyType is NULL   
            if (!(Sal.IsNull(tblVoucherPosting_colsCurrencyCode)) && !(Sal.IsNull(tblVoucherPosting_colsCurrencyType)))
            {
                if (!(this.GetAttributes(tblVoucherPosting_colsCompany.Text, tblVoucherPosting_colsCurrencyCode.Text, frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).sCurrencyCode, tblVoucherPosting_colsCurrencyType.Text, frmEntryVoucher.FromHandle(
                        Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfdVoucherDate.DateTime)))
                {
                    return false;
                }
                nPrevRate = tblVoucherPosting_colnCurrencyRate.Number;
                sPrevCurrType = tblVoucherPosting_colsCurrencyType.Text;
                tblVoucherPosting_colnCurrencyRate.Number = this.GetRate(tblVoucherPosting_colsCompany.Text, tblVoucherPosting_colsCurrencyCode.Text);
                tblVoucherPosting_colnActCurrencyRate.Number = tblVoucherPosting_colnCurrencyRate.Number;
                tblVoucherPosting_colnCurrencyRate.EditDataItemSetEdited();
                tblVoucherPosting_colnDecimalsInAmount.Number = this.i_nFinTransRound;
                if (!(Sal.IsNull(tblVoucherPosting_colnCurrencyAmount)) && (tblVoucherPosting_colnCurrencyAmount.Number != 0))
                {
                    // Bug 97225, Begin
                    SetAnotherValue(tblVoucherPosting_colnCurrencyRate.Number, tblVoucherPosting_colnCurrencyAmount, "RATE", ref nCalculatedTaxValue);
                    // Bug 97225, End
                }
            }
            return true;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean GetDefaultTaxCode()
        {
            #region Local Variables
            // Bug 92910, Begin
            SalString sPrevOptionalCode = "";
            SalString sPrevTaxDirection = "";
            // Bug 92910, End
            #endregion

            #region Actions
            IDictionary<string, string> namedBindVariables = new Dictionary<string, string>();
            namedBindVariables.Add("sTaxHandlingValue", this.QualifiedVarBindName("sTaxHandlingValue"));
            namedBindVariables.Add("colsCompany", this.tblVoucherPosting_colsCompany.QualifiedBindName);
            namedBindVariables.Add("colsAccount", this.tblVoucherPosting_colsAccount.QualifiedBindName);
            namedBindVariables.Add("colsOptionalCode", this.tblVoucherPosting_colsOptionalCode.QualifiedBindName);
            namedBindVariables.Add("colsTaxDirection", this.tblVoucherPosting_colsTaxDirection.QualifiedBindName);
                             
            if (sTaxHandlingValue != "BLOCKED")
            {
                // Bug 92910, Begin
                sPrevOptionalCode = tblVoucherPosting_colsOptionalCode.Text;
                sPrevTaxDirection = tblVoucherPosting_colsTaxDirection.Text;
                // Bug 92910, End
                // Bug 97225, Begin
                if (!(DbPLSQLBlock(@"&AO.Account_Tax_Code_API.Get_Default_Tax_Code( {colsOptionalCode} OUT, 
                                                                                    {colsTaxDirection} OUT, 
                                                                                    {colsCompany} IN, 
                                                                                    {colsAccount} IN, 
                                                                                     'TRUE' );",namedBindVariables )))
                   {
                      return false;
                   }
                
                // Bug 97225, End
                // ! Bug 92910, Begin
                // ! if the default tax code is not set and a previous was available, reset back to it.
                if (tblVoucherPosting_colsOptionalCode.Text == Ifs.Fnd.ApplicationForms.Const.strNULL && tblVoucherPosting_colsTaxDirection.Text == Ifs.Fnd.ApplicationForms.Const.strNULL && sPrevOptionalCode != Ifs.Fnd.ApplicationForms.Const.strNULL && sPrevTaxDirection != Ifs.Fnd.ApplicationForms.Const.strNULL)
                {
                    tblVoucherPosting_colsOptionalCode.Text = sPrevOptionalCode;
                    tblVoucherPosting_colsTaxDirection.Text = sPrevTaxDirection;
                }
                // ! Bug 92910, End
                // Bug Id 82380, Begin. Added condition to If statement
                // Bug Id 80054, Begin
                if (Sal.IsNull(tblVoucherPosting_colsOptionalCode) && !(Sal.IsNull(tblVoucherPosting_colsPrevTaxCode)))
                {
                    tblVoucherPosting_colsOptionalCode.Text = tblVoucherPosting_colsPrevTaxCode.Text;
                    // Find the matching tax direction for changed tax code.
                    if (bCopyRow)
                    {
                        if (!(DbPLSQLBlock(@"&AO.Account_Tax_Code_API.Check_Tax_Code({sTaxHandlingValue} OUT, 
                                                                                     {colsTaxDirection} OUT, 
                                                                                     {colsCompany} IN, 
                                                                                     {colsAccount} IN, 
                            		                                                 {colsOptionalCode} IN, 
                                                                                     NULL, 
                                                                                     NULL, 
                                                                                     'TRUE' );",namedBindVariables)))
                        {
                            return false;
                        }
                    }
                }
                // Bug Id 80054, End
                // Bug Id 82380, End
                tblVoucherPosting_colsOptionalCode.EditDataItemSetEdited();
                tblVoucherPosting_colsTaxDirection.EditDataItemSetEdited();
                GetTaxType();
            }
            else
            {
                tblVoucherPosting_colsOptionalCode.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                tblVoucherPosting_colsOptionalCode.EditDataItemSetEdited();
                tblVoucherPosting_colsTaxDirection.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                tblVoucherPosting_colsTaxDirection.EditDataItemSetEdited();
            }
            return true;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean CheckTaxCode()
        {
            IDictionary<string, string> namedBindVariables = new Dictionary<string, string>();
            namedBindVariables.Add("sTaxHandlingValue", this.QualifiedVarBindName("sTaxHandlingValue"));
            namedBindVariables.Add("colsCompany", this.tblVoucherPosting_colsCompany.QualifiedBindName);
            namedBindVariables.Add("colsAccount", this.tblVoucherPosting_colsAccount.QualifiedBindName);
            namedBindVariables.Add("colsOptionalCode", this.tblVoucherPosting_colsOptionalCode.QualifiedBindName);
            namedBindVariables.Add("colsTaxDirection", this.tblVoucherPosting_colsTaxDirection.QualifiedBindName);
     
            if (!(DbPLSQLBlock(@"&AO.Account_Tax_Code_API.Check_Tax_Code({sTaxHandlingValue} OUT, 
                                                                         {colsTaxDirection} OUT, 
                                                                         {colsCompany} IN, 
                                                                         {colsAccount} IN, 
                            		                                     {colsOptionalCode} IN, 
                                                                         NULL, 
                                                                         NULL, 
                                                                         'TRUE' );", namedBindVariables)))
            {
                tblVoucherPosting_colsTaxDirection.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                return false;
            }
                
        // Bug 97225, End
        tblVoucherPosting_colsTaxDirection.EditDataItemSetEdited();
        GetTaxType();
        return true;

        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean GetTaxType()
        {
            if (!(Sal.IsNull(tblVoucherPosting_colsOptionalCode)))
            {
                IDictionary<string, string> namedBindVariables = new Dictionary<string, string>();
                namedBindVariables.Add("colsTaxType", this.tblVoucherPosting_colsTaxType.QualifiedBindName);
                namedBindVariables.Add("colsCompany", this.tblVoucherPosting_colsCompany.QualifiedBindName);
                namedBindVariables.Add("colsOptionalCode", this.tblVoucherPosting_colsOptionalCode.QualifiedBindName);
                namedBindVariables.Add("dfdVoucherDate", ":i_hWndParent.frmEntryVoucher.dfdVoucherDate");

                if (!(DbPLSQLBlock(@"&AO.Statutory_Fee_API.Get_Fee_Type({colsTaxType} OUT,
                                                                        {colsCompany} IN,
                                                                        {colsOptionalCode} IN,
                                                                        {dfdVoucherDate} IN );",namedBindVariables )))
                {
                    return false;
                }      
            }
            else
            {
                tblVoucherPosting_colsTaxType.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
            }
            return true; 
        }

        /// <summary>
        /// </summary>
        /// <param name="nMyValue"></param>
        /// <param name="nPreviousAmount"></param>
        /// <param name="hWndRivalTax"></param>
        /// <param name="sAmountMethodVoucher"></param>
        /// <param name="sStatus"></param>
        /// <param name="nCalculatedTaxValue"></param>
        /// <returns></returns>
        // Bug 97225, Begin
        public virtual SalBoolean SetTaxValue(SalNumber nMyValue, SalNumber nPreviousAmount, SalWindowHandle hWndRivalTax, SalString sAmountMethodVoucher, SalString sStatus, SalNumber nCalculatedTaxValue)
        {
            #region Local Variables
            SalNumber nCalculateTaxValue = 0;
            SalNumber nCalculateAccTaxValue = 0;
            SalNumber nPosCurrAmount = 0;
            SalNumber nPosAmount = 0;

            SalNumber nPosParallelCurrAmount = 0;
            SalNumber nPosCurrTaxAmount = 0;
            SalNumber nPosTaxAmount = 0;

            SalNumber nPosParallelTaxAmnt = 0;
            #endregion

            #region Actions
            if (sMode != "DUPLICATED")
            {
                // Bug 97225, Begin
                if (nMyValue.Abs() != nPreviousAmount.Abs() || (tblVoucherPosting_colnCurrencyTaxAmount.Number == Sys.NUMBER_Null) || ((tblVoucherPosting_colnAmount.Number != Sys.NUMBER_Null) && (tblVoucherPosting_colnTaxAmount.Number == Sys.NUMBER_Null)) || bCurrencyAmtChanged || bAmtChanged || bTaxCodeChanged)
                {
                    this.GetAttributes(tblVoucherPosting_colsCompany.Text, tblVoucherPosting_colsCurrencyCode.Text, frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).sCurrencyCode, tblVoucherPosting_colsCurrencyType.Text, frmEntryVoucher.FromHandle(
                            Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfdVoucherDate.DateTime);
                                                        
                    if (sStatus == "CURRENT_AMOUNT")
                    {
                        if (!(Sal.IsNull(tblVoucherPosting_colnCurrencyAmount)))
                        {
                            Sal.SendMsg(hWndRivalTax, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, nCalculatedTaxValue.ToString(99).ToHandle());
                            if (tblVoucherPosting_colnActCurrencyRate.Number == Sys.NUMBER_Null)
                            {
                                tblVoucherPosting_colnActCurrencyRate.Number = tblVoucherPosting_colnCurrencyRate.Number;
                            }
                            this.GetBaseCurrAmountForRate(nCalculatedTaxValue, tblVoucherPosting_colnCurrencyRate.Number, ref nCalculateAccTaxValue);
                            if ((bCurrencyAmtChanged)  || (bAmtChanged))
                            {
                               this.GetBaseCurrAmountForRate(nCalculatedTaxValue, tblVoucherPosting_colnActCurrencyRate.Number, ref nCalculateAccTaxValue);
                            }
                            tblVoucherPosting_colnTaxAmount.Number = nCalculateAccTaxValue;
                            tblVoucherPosting_colnTaxAmount.EditDataItemSetEdited();
                        }
                        else
                        {
                            tblVoucherPosting_colnCurrencyTaxAmount.Number = Sys.NUMBER_Null;
                            tblVoucherPosting_colnTaxAmount.Number = Sys.NUMBER_Null;
                        }
                        // Bug 84847 Begin , added Else If condition for GROSS
                        if (sAmountMethodVoucher == "NET")
                        {
                            nPosCurrAmount = Sal.TblQueryColumnID(tblVoucherPosting_colnCurrencyAmount);
                            nPosAmount = Sal.TblQueryColumnID(tblVoucherPosting_colnAmount);
                            nPosCurrTaxAmount = Sal.TblQueryColumnID(tblVoucherPosting_colnCurrencyTaxAmount);
                            nPosTaxAmount = Sal.TblQueryColumnID(tblVoucherPosting_colnTaxAmount);

                            nPosParallelTaxAmnt = Sal.TblQueryColumnID(tblVoucherPosting_colnParallelCurrTaxAmount);


                            nPosParallelCurrAmount = Sal.TblQueryColumnID(tblVoucherPosting_colnThirdCurrencyAmount);
                            this.dfnCurrencyBalance.Number = Sal.TblColumnSum(tblVoucherPosting, nPosCurrAmount, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1)) + Sal.TblColumnSum(tblVoucherPosting, nPosCurrTaxAmount, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1));
                            this.dfnBalance.Number = Sal.TblColumnSum(tblVoucherPosting, nPosAmount, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1)) + Sal.TblColumnSum(tblVoucherPosting, nPosTaxAmount, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1));

                            this.dfnParallelCurrBalance.Number = Sal.TblColumnSum(tblVoucherPosting, nPosParallelCurrAmount, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1)) + Sal.TblColumnSum(tblVoucherPosting, nPosParallelTaxAmnt, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1));
                        }
                        else if (sAmountMethodVoucher == "GROSS")
                        {
                            nPosCurrAmount = Sal.TblQueryColumnID(tblVoucherPosting_colnCurrencyAmount);
                            nPosAmount = Sal.TblQueryColumnID(tblVoucherPosting_colnAmount);
                            this.dfnCurrencyBalance.Number = Sal.TblColumnSum(tblVoucherPosting, nPosCurrAmount, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1));
                            this.dfnBalance.Number = Sal.TblColumnSum(tblVoucherPosting, nPosAmount, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1));

                            this.dfnParallelCurrBalance.Number = Sal.TblColumnSum(tblVoucherPosting, nPosParallelCurrAmount, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1));
                        }
                        // Bug 84847 End
                    }
                    else if (sStatus == "ACCOUNTING_AMOUNT")
                    {
                        if (!(Sal.IsNull(tblVoucherPosting_colnAmount)))
                        {
                            if (Sal.IsNull(tblVoucherPosting_colnCurrencyTaxAmount))
                            {
                                Sal.SendMsg(hWndRivalTax, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, nCalculatedTaxValue.ToString(99).ToHandle());
                            }
                            else
                            {
                                if (tblVoucherPosting_colnActCurrencyRate.Number == Sys.NUMBER_Null)
                                {
                                    tblVoucherPosting_colnActCurrencyRate.Number = tblVoucherPosting_colnCurrencyRate.Number;
                                }
                                this.GetBaseCurrAmountForRate(tblVoucherPosting_colnCurrencyTaxAmount.Number, tblVoucherPosting_colnActCurrencyRate.Number, ref nCalculateTaxValue);                       
                                this.GetBaseCurrAmountForRate(tblVoucherPosting_colnCurrencyTaxAmount.Number, tblVoucherPosting_colnCurrencyRate.Number, ref nCalculateTaxValue);
                                if (nMyValue < 0)
                                {
                                    if (tblVoucherPosting_colnCurrencyTaxAmount.Number < 0)
                                    {
                                        tblVoucherPosting_colnCurrencyTaxAmount.Number = tblVoucherPosting_colnCurrencyTaxAmount.Number;
                                        nCalculateTaxValue = nCalculateTaxValue;
                                    }
                                    else if (tblVoucherPosting_colnCurrencyTaxAmount.Number > 0)
                                    {
                                        tblVoucherPosting_colnCurrencyTaxAmount.Number = -tblVoucherPosting_colnCurrencyTaxAmount.Number;
                                        nCalculateTaxValue = -nCalculateTaxValue;
                                    }
                                }
                                else if (nMyValue > 0)
                                {
                                    if (tblVoucherPosting_colnCurrencyTaxAmount.Number < 0)
                                    {
                                        tblVoucherPosting_colnCurrencyTaxAmount.Number = -tblVoucherPosting_colnCurrencyTaxAmount.Number;
                                        nCalculateTaxValue = -nCalculateTaxValue;
                                    }
                                    else if (tblVoucherPosting_colnCurrencyTaxAmount.Number > 0)
                                    {
                                        tblVoucherPosting_colnCurrencyTaxAmount.Number = tblVoucherPosting_colnCurrencyTaxAmount.Number;
                                        nCalculateTaxValue = nCalculateTaxValue;
                                    }
                                }
                                Sal.SendMsg(hWndRivalTax, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, nCalculateTaxValue.ToString(99).ToHandle());
                            }
                            tblVoucherPosting_colnTaxAmount.EditDataItemSetEdited();
                        }
                        else
                        {
                            tblVoucherPosting_colnTaxAmount.Number = Sys.NUMBER_Null;
                        }
                        if (sAmountMethodVoucher == "NET")
                        {
                            nPosAmount = Sal.TblQueryColumnID(tblVoucherPosting_colnAmount);
                            nPosTaxAmount = Sal.TblQueryColumnID(tblVoucherPosting_colnTaxAmount);

                            nPosParallelTaxAmnt = Sal.TblQueryColumnID(tblVoucherPosting_colnParallelCurrTaxAmount);


                            nPosParallelCurrAmount = Sal.TblQueryColumnID(tblVoucherPosting_colnThirdCurrencyAmount);
                            this.dfnBalance.Number = Sal.TblColumnSum(tblVoucherPosting, nPosAmount, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1)) + Sal.TblColumnSum(tblVoucherPosting, nPosTaxAmount, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1));

                            this.dfnParallelCurrBalance.Number = Sal.TblColumnSum(tblVoucherPosting, nPosParallelCurrAmount, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1)) + Sal.TblColumnSum(tblVoucherPosting, nPosParallelTaxAmnt, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1));
                            if (this.sCurrCode != Ifs.Fnd.ApplicationForms.Const.strNULL)
                            {
                                if (tblVoucherPosting_colsCurrencyCode.Text == this.sCurrCode)
                                {
                                    tblVoucherPosting_colnCurrencyTaxAmount.Number = tblVoucherPosting_colnTaxAmount.Number;
                                    tblVoucherPosting_colnCurrencyTaxAmount.EditDataItemSetEdited();
                                    nPosCurrAmount = Sal.TblQueryColumnID(tblVoucherPosting_colnCurrencyAmount);
                                    nPosCurrTaxAmount = Sal.TblQueryColumnID(tblVoucherPosting_colnCurrencyTaxAmount);
                                    this.dfnCurrencyBalance.Number = Sal.TblColumnSum(tblVoucherPosting, nPosCurrAmount, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1)) + Sal.TblColumnSum(tblVoucherPosting, nPosCurrTaxAmount, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1));
                                }
                            }
                        }
                        else if (sAmountMethodVoucher == "GROSS")
                        {
                            if (this.sCurrCode != Ifs.Fnd.ApplicationForms.Const.strNULL)
                            {
                                if (tblVoucherPosting_colsCurrencyCode.Text == this.sCurrCode)
                                {
                                    tblVoucherPosting_colnCurrencyTaxAmount.Number = tblVoucherPosting_colnTaxAmount.Number;
                                }
                            }
                        }
                    }
                }
                // Bug 97225, End
                if (bCalculateParallelCurrTax)
                {
                    CalcualteParallelCurrTaxValue("RATE");
                }
                return true;
            }
            return true;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean ResetTaxAmount()
        {
            // tblVoucherPosting_colnCurrencyAmount + 1 is to pass to control in SetTaxValue if nMyValue is the same as nPreviousValue.
            // Then SetTaxValue is called from here you always wants to perform the action.
            // Bug 97225, Begin
            if (Sal.IsNull(tblVoucherPosting_colsOptionalCode) && !(Sal.IsNull(tblVoucherPosting_colnCurrencyTaxAmount)))
            {
                SetTaxValue(tblVoucherPosting_colnCurrencyAmount.Number, tblVoucherPosting_colnCurrencyAmount.Number + 1, tblVoucherPosting_colnCurrencyTaxAmount, sAmountMethodDb, "CURRENT_AMOUNT", 0);
            }
            else if (Sal.IsNull(tblVoucherPosting_colsOptionalCode) && !(Sal.IsNull(tblVoucherPosting_colnTaxAmount)))
            {
                SetTaxValue(tblVoucherPosting_colnAmount.Number, tblVoucherPosting_colnAmount.Number + 1, tblVoucherPosting_colnTaxAmount, sAmountMethodDb, "ACCOUNTING_AMOUNT", 0);
            }
            else if (!(Sal.IsNull(tblVoucherPosting_colnCurrencyAmount)) && tblVoucherPosting_colnCurrencyAmount.Number != 0)
            {
                if (!(Sal.IsNull(tblVoucherPosting_colnCurrencyCreditAmount)) && (tblVoucherPosting_colnCurrencyCreditAmount.Number != 0))
                {
                    Sal.SendMsg(tblVoucherPosting_colnCurrencyCreditAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
                }
                else if (!(Sal.IsNull(tblVoucherPosting_colnCurrencyDebetAmount)) && (tblVoucherPosting_colnCurrencyDebetAmount.Number != 0))
                {
                    Sal.SendMsg(tblVoucherPosting_colnCurrencyDebetAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
                }
            }
            else if (!(Sal.IsNull(tblVoucherPosting_colnAmount)) && tblVoucherPosting_colnAmount.Number != 0)
            {
                if (!(Sal.IsNull(tblVoucherPosting_colnCreditAmount)) && tblVoucherPosting_colnCreditAmount.Number != 0)
                {
                    Sal.SendMsg(tblVoucherPosting_colnCreditAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
                }
                else if (!(Sal.IsNull(tblVoucherPosting_colnDebetAmount)) && tblVoucherPosting_colnDebetAmount.Number != 0)
                {
                    Sal.SendMsg(tblVoucherPosting_colnDebetAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
                }
            }
            // Bug 97225, End
            return true;
        }

        /// <summary>
        /// </summary>
        /// <param name="nMyValue"></param>
        /// <param name="nPreviousAmount"></param>
        /// <returns></returns>
        public virtual SalBoolean ResetTaxAmountFromCurrTaxAmount(SalNumber nMyValue, SalNumber nPreviousAmount)
        {
            #region Local Variables
            SalNumber nCalculateAccTaxValue = 0;
            SalNumber nPosCurrAmount = 0;
            SalNumber nPosAmount = 0;
            SalNumber nPosParallelCurrAmount = 0;
            SalNumber nPosCurrTaxAmount = 0;
            SalNumber nPosTaxAmount = 0;
            SalNumber nPosParallelTaxAmnt = 0;
            SalNumber nCalculaeThirdCurrTaxAmount = 0;
            #endregion

            #region Actions
            if (nMyValue != nPreviousAmount)
            {
                if (!(Sal.IsNull(tblVoucherPosting_colsOptionalCode)))
                {
                    if (!(Sal.IsNull(tblVoucherPosting_colnCurrencyTaxAmount)))
                    {
                        nMyValue = this.RoundOfTax(frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).sRoundingMethod, nMyValue, tblVoucherPosting_colnDecimalsInAmount.Number);
                        if (tblVoucherPosting_colnActCurrencyRate.Number == Sys.NUMBER_Null)
                        {
                            tblVoucherPosting_colnActCurrencyRate.Number = tblVoucherPosting_colnCurrencyRate.Number;
                        }
                        this.GetBaseCurrAmountForRate(nMyValue, tblVoucherPosting_colnActCurrencyRate.Number, ref nCalculateAccTaxValue);
                        this.GetBaseCurrAmountForRate(nMyValue, tblVoucherPosting_colnCurrencyRate.Number, ref nCalculateAccTaxValue);
                        if (this.tblVoucherPosting_colsCurrencyCode.Text == this.i_sFinThirdCurrencyCode)
                        {
                            nCalculaeThirdCurrTaxAmount = nMyValue;
                        }
                        else
                        {
                            if (this.i_sFinParallelBaseType == "ACCOUNTING_CURRENCY" || tblVoucherPosting_colsCurrencyCode.Text == this.sCurrCode)
                            {
                                if (tblVoucherPosting_colnParallelCurrRate.Number == 0 || tblVoucherPosting_colnParallelCurrRate.Number == Sys.NUMBER_Null)
                                {
                                    nCalculaeThirdCurrTaxAmount = 0;
                                }
                                else
                                {
                                    this.GetParallelCurrAmountForRate(nCalculateAccTaxValue, tblVoucherPosting_colnParallelCurrRate.Number, ref nCalculaeThirdCurrTaxAmount);
                                }
                            }
                            else if (this.i_sFinParallelBaseType == "TRANSACTION_CURRENCY")
                            {
                                if (tblVoucherPosting_colnParallelCurrRate.Number == 0 || tblVoucherPosting_colnParallelCurrRate.Number == Sys.NUMBER_Null)
                                {
                                    nCalculaeThirdCurrTaxAmount = 0;
                                }
                                else
                                {
                                    this.GetParallelCurrAmountForRate(nMyValue, tblVoucherPosting_colnParallelCurrRate.Number, ref nCalculaeThirdCurrTaxAmount);
                                }
                            }
                        }
                        if (!(Sal.IsNull(tblVoucherPosting_colnAmount)))
                        {
                            tblVoucherPosting_colnTaxAmount.Number = nCalculateAccTaxValue;
                            tblVoucherPosting_colnTaxAmount.EditDataItemSetEdited();
                            tblVoucherPosting_colnParallelCurrTaxAmount.Number = nCalculaeThirdCurrTaxAmount;
                            tblVoucherPosting_colnParallelCurrTaxAmount.EditDataItemSetEdited();
                        }
                    }
                    else
                    {
                        tblVoucherPosting_colnTaxAmount.Number = Sys.NUMBER_Null;
                    }
                    if (sAmountMethodDb == "NET")
                    {
                        nPosCurrAmount = Sal.TblQueryColumnID(tblVoucherPosting_colnCurrencyAmount);
                        nPosAmount = Sal.TblQueryColumnID(tblVoucherPosting_colnAmount);
                        nPosCurrTaxAmount = Sal.TblQueryColumnID(tblVoucherPosting_colnCurrencyTaxAmount);
                        nPosTaxAmount = Sal.TblQueryColumnID(tblVoucherPosting_colnTaxAmount);

                        nPosParallelTaxAmnt = Sal.TblQueryColumnID(tblVoucherPosting_colnParallelCurrTaxAmount);


                        nPosParallelCurrAmount = Sal.TblQueryColumnID(tblVoucherPosting_colnThirdCurrencyAmount);
                        this.dfnCurrencyBalance.Number = Sal.TblColumnSum(tblVoucherPosting, nPosCurrAmount, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1)) + Sal.TblColumnSum(tblVoucherPosting, nPosCurrTaxAmount, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1));
                        this.dfnBalance.Number = Sal.TblColumnSum(tblVoucherPosting, nPosAmount, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1)) + Sal.TblColumnSum(tblVoucherPosting, nPosTaxAmount, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1));

                        this.dfnParallelCurrBalance.Number = Sal.TblColumnSum(tblVoucherPosting, nPosParallelCurrAmount, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1)) + Sal.TblColumnSum(tblVoucherPosting, nPosParallelTaxAmnt, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1));
                    }
                }
                else
                {
                    tblVoucherPosting_colnTaxAmount.Number = 0;
                    tblVoucherPosting_colnParallelCurrTaxAmount.Number = 0;
                }
            }
            return true;
            
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="nMyValue"></param>
        /// <param name="nPreviousAmount"></param>
        /// <returns></returns>
        public virtual SalBoolean ResetBalance(SalNumber nMyValue, SalNumber nPreviousAmount)
        {
            #region Local Variables
            SalNumber nCalculateAccTaxValue = 0;
            SalNumber nPosCurrAmount = 0;
            SalNumber nPosAmount = 0;
            SalNumber nPosParallelCurrAmount = 0;
            SalNumber nPosCurrTaxAmount = 0;
            SalNumber nPosTaxAmount = 0;
            SalNumber nPosParallelTaxAmnt = 0;
            #endregion

            #region Actions
            if (nMyValue.Abs() != nPreviousAmount.Abs())
            {
                if (!(Sal.IsNull(tblVoucherPosting_colsOptionalCode)))
                {
                    if (sAmountMethodDb == "NET")
                    {
                        nPosAmount = Sal.TblQueryColumnID(tblVoucherPosting_colnAmount);
                        nPosTaxAmount = Sal.TblQueryColumnID(tblVoucherPosting_colnTaxAmount);

                        nPosParallelTaxAmnt = Sal.TblQueryColumnID(tblVoucherPosting_colnParallelCurrTaxAmount);


                        nPosParallelCurrAmount = Sal.TblQueryColumnID(tblVoucherPosting_colnThirdCurrencyAmount);
                        this.dfnBalance.Number = Sal.TblColumnSum(tblVoucherPosting, nPosAmount, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1)) + Sal.TblColumnSum(tblVoucherPosting, nPosTaxAmount, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1));

                        this.dfnParallelCurrBalance.Number = Sal.TblColumnSum(tblVoucherPosting, nPosParallelCurrAmount, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1)) + Sal.TblColumnSum(tblVoucherPosting, nPosParallelTaxAmnt, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1));
                    }
                }
                else
                {
                    tblVoucherPosting_colnTaxAmount.Number = Sys.NUMBER_Null;
                }
            }
            return true;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="nMyValue"></param>
        /// <param name="hWndRivalTax"></param>
        /// <param name="nCalculateTaxValue"></param>
        /// <param name="nCalculateAccTaxValue"></param>
        /// <param name="nCalculaeThirdCurrTaxAmount"></param>
        /// <returns></returns>
        public virtual SalBoolean SetTaxValueAutoBal(SalNumber nMyValue, SalWindowHandle hWndRivalTax, ref SalNumber nCalculateTaxValue, ref SalNumber nCalculateAccTaxValue, ref SalNumber nCalculaeThirdCurrTaxAmount)
        {                
            if (!(Sal.IsNull(tblVoucherPosting_colsOptionalCode)))
            {
                IDictionary<string, string> namedBindVariables = new Dictionary<string, string>();
                namedBindVariables.Add("nTaxPercent", this.QualifiedVarBindName("nTaxPercent"));
                namedBindVariables.Add("colsCompany", this.tblVoucherPosting_colsCompany.QualifiedBindName);
                namedBindVariables.Add("colsOptionalCode", this.tblVoucherPosting_colsOptionalCode.QualifiedBindName);
                namedBindVariables.Add("dfdVoucherDate", ":i_hWndParent.frmEntryVoucher.dfdVoucherDate"); 
  
                if (!(DbPLSQLBlock(@"&AO.Statutory_Fee_API.Get_Fee_Percent({nTaxPercent} OUT,{colsCompany} IN,{colsOptionalCode} IN,{dfdVoucherDate} IN )", namedBindVariables)))
                {
                    return false;
                }
                    
                nTaxPercent = nTaxPercent / 100;

                nCalculateTaxValue = nMyValue * nTaxPercent / (1 + nTaxPercent);
                nCalculateTaxValue = this.RoundOfTax(frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).sRoundingMethod, nCalculateTaxValue, tblVoucherPosting_colnDecimalsInAmount.Number);
                Sal.SendMsg(hWndRivalTax, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, nCalculateTaxValue.ToString(99).ToHandle());
                this.GetBaseCurrencyAmount(nCalculateTaxValue, ref nCalculateAccTaxValue);
                tblVoucherPosting_colnTaxAmount.Number = nCalculateAccTaxValue;
                tblVoucherPosting_colnTaxAmount.EditDataItemSetEdited();
                this.GetThirdCurrencyAmount(nCalculateAccTaxValue, nCalculateTaxValue, ref nCalculaeThirdCurrTaxAmount);
                tblVoucherPosting_colnParallelCurrTaxAmount.Number = nCalculaeThirdCurrTaxAmount;
                tblVoucherPosting_colnParallelCurrTaxAmount.EditDataItemSetEdited();
            }
            return true;
    
        }
   
        /// <summary>
        /// </summary>
        /// <param name="nGrossAmount"></param>
        /// <param name="nAmountDebit"></param>
        /// <param name="nAmountCredit"></param>
        /// <param name="nAmount"></param>
        /// <param name="nDebitAmount"></param>
        /// <param name="nCreditAmount"></param>
        /// <returns></returns>
        public virtual SalBoolean ConvertGrossToNet(ref SalNumber nGrossAmount, ref SalNumber nAmountDebit, ref SalNumber nAmountCredit, ref SalNumber nAmount, ref SalNumber nDebitAmount, ref SalNumber nCreditAmount)
        {
            if (nGrossAmount == SalNumber.Null)
            {
                nAmountDebit = SalNumber.Null;
                nAmountCredit = SalNumber.Null;
                nAmount = SalNumber.Null;
            }
            else
            {
                if (nGrossAmount > 0)
                {
                    if (nDebitAmount != SalNumber.Null)
                    {
                        nAmountDebit = nGrossAmount;
                        nAmountCredit = SalNumber.Null;
                    }
                    else if (nCreditAmount != SalNumber.Null)
                    {
                        nAmountCredit = nGrossAmount * -1;
                        nAmountDebit = SalNumber.Null;
                    }
                }
                else if (nGrossAmount < 0)
                {
                    if (nCreditAmount != SalNumber.Null)
                    {
                        nAmountCredit = nGrossAmount * -1;
                        nAmountDebit = SalNumber.Null;
                    }
                    else if (nDebitAmount != SalNumber.Null)
                    {
                        nAmountDebit = nGrossAmount;
                        nAmountCredit = SalNumber.Null;
                    }
                }
                nAmount = nGrossAmount;
            }
            return true;

        }

        public virtual SalString GetParallelCurrencyRateType()
        {
            return (tblVoucherPosting_colnParallelCurrRateType.Text);
        }

        public virtual SalNumber CalcualteParallelCurrTaxValue(SalString sBasedOn)
        {
            #region Local Variables
            SalNumber nPosParallelCurrAmount = 0;
            SalNumber nPosParallelCurrTaxAmount = 0;
            SalNumber nCalculateTaxValue = 0;
            SalString sParallelCurrencyBaseType;
            #endregion

            if (frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).sParallelCurrency != Ifs.Fnd.ApplicationForms.Const.strNULL)
            {

                if (sBasedOn == Sys.STRING_Null || sBasedOn == "RATE")
                {
                    sParallelCurrencyBaseType = this.i_sFinParallelBaseType;
                    if (sParallelCurrencyBaseType == "TRANSACTION_CURRENCY" )
                    {
                        if (tblVoucherPosting_colnParallelCurrRate.Number != 0)
                        {
                            this.GetParallelCurrAmountForRate(tblVoucherPosting_colnCurrencyTaxAmount.Number, tblVoucherPosting_colnParallelCurrRate.Number, ref nCalculateTaxValue);
                        }
                        else
                        {
                            nCalculateTaxValue = 0;
                        }
                    }
                    else
                    {
                        if (this.tblVoucherPosting_colsCurrencyCode.Text == this.i_sFinThirdCurrencyCode)
                        {
                            nCalculateTaxValue = tblVoucherPosting_colnCurrencyTaxAmount.Number;
                        }
                        else
                        {
                            if (tblVoucherPosting_colnParallelCurrRate.Number != 0)
                            {
                                this.GetParallelCurrAmountForRate(tblVoucherPosting_colnTaxAmount.Number, tblVoucherPosting_colnParallelCurrRate.Number, ref nCalculateTaxValue);
                            }
                            else
                            {
                                nCalculateTaxValue = 0;
                            }
                        }
                    }

                    tblVoucherPosting_colnParallelCurrTaxAmount.Number = nCalculateTaxValue;
                    tblVoucherPosting_colnParallelCurrTaxAmount.EditDataItemSetEdited();

                    // Calculate deduc
                    if ((!(nDeduct == SalNumber.Null) && bIsAutoBal) || (nDeduct == SalNumber.Null))
                    {

                        if (!(Sal.IsNull(tblVoucherPosting_colsOptionalCode)) && tblVoucherPosting_colsFunctionGroup.Text != "Q")
                        {
                            IDictionary<string, string> namedBindVariables = new Dictionary<string, string>();
                            namedBindVariables.Add("colsCompany", this.tblVoucherPosting_colsCompany.QualifiedBindName);
                            namedBindVariables.Add("colsOptionalCode", this.tblVoucherPosting_colsOptionalCode.QualifiedBindName);
                            namedBindVariables.Add("dfdVoucherDate", ":i_hWndParent.frmEntryVoucher.dfdVoucherDate");
                            namedBindVariables.Add("nDeduct", this.QualifiedVarBindName("nDeduct"));
                            namedBindVariables.Add("nTaxPercent", this.QualifiedVarBindName("nTaxPercent"));
                            if (!(DbPLSQLBlock(@"BEGIN
                                                    &AO.Statutory_Fee_API.Get_Fee_Percent( {nTaxPercent} OUT,
                                                                                            {colsCompany} IN,
                                                                                            {colsOptionalCode} IN,
                                                                                            {dfdVoucherDate} IN );
                                                    IF ({nTaxPercent} != 0 ) THEN
                                                        {nDeduct} := &AO.Statutory_Fee_API.Get_Deductible({colsCompany} IN,{colsOptionalCode} IN );
                                                    END IF;
                                                    END;",namedBindVariables)))
                            {
                                return false;
                            }
                            
                            nTaxPercent = nTaxPercent / 100;
                        }
                        else
                        {
                            nTaxPercent = 0;
                        }

                        if (nDeduct == SalNumber.Null)
                        {
                            nDeduct = 100;
                        }
                        nDeductPercent = nDeduct / 100;

                        if (sAmountMethodDb == "NET")
                        {

                            if (bIsAutoBal)
                            {
                                nToTaxAmount = tblVoucherPosting_colnThirdCurrencyAmount.Number * nTaxPercent;
                                nCalculateTaxValue = nToTaxAmount * nDeductPercent;
                                bIsAutoBal = false;
                                nDeductThirdCurrValue = nToTaxAmount - nCalculateTaxValue;
                                nCalculateTaxValue = this.RoundOfTax(frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).sRoundingMethod, nCalculateTaxValue, tblVoucherPosting_colnDecimalsInAmount.Number);
                            }
                            else
                            {
                                nDeductThirdCurrValue = 0;
                            }

                        }

                    }

                }
                else
                {
                    // Restructured to implement deductible tax functionality.

                    if (tblVoucherPosting_colnCurrencyAmount.Number.Abs() != tblVoucherPosting_colnPrevCurrencyAmount.Number.Abs() || ((tblVoucherPosting_colnThirdCurrencyAmount.Number != Sys.NUMBER_Null) && (tblVoucherPosting_colnParallelCurrTaxAmount.Number == Sys.NUMBER_Null)) || bCurrencyAmtChanged || bAmtChanged || bTaxCodeChanged || bParallelCurrAmtChanged)
                    {

                        if ((!(nDeduct == SalNumber.Null) && bIsAutoBal) || (nDeduct == SalNumber.Null))
                        {

                            if (!(Sal.IsNull(tblVoucherPosting_colsOptionalCode)) && tblVoucherPosting_colsFunctionGroup.Text != "Q")
                            {
                                IDictionary<string, string> namedBindVariables = new Dictionary<string, string>();
                                namedBindVariables.Add("colsCompany", this.tblVoucherPosting_colsCompany.QualifiedBindName);
                                namedBindVariables.Add("colsOptionalCode", this.tblVoucherPosting_colsOptionalCode.QualifiedBindName);
                                namedBindVariables.Add("dfdVoucherDate", ":i_hWndParent.frmEntryVoucher.dfdVoucherDate");
                                namedBindVariables.Add("nDeduct", this.QualifiedVarBindName("nDeduct"));
                                namedBindVariables.Add("nTaxPercent", this.QualifiedVarBindName("nTaxPercent"));
                                if (!(DbPLSQLBlock(@"BEGIN
                                                        &AO.Statutory_Fee_API.Get_Fee_Percent( {nTaxPercent} OUT,
                                                                                               {colsCompany} IN,
                                                                                               {colsOptionalCode} IN,
                                                                                               {dfdVoucherDate} IN );
                                                        IF ({nTaxPercent} != 0 ) THEN
                                                            {nDeduct} := &AO.Statutory_Fee_API.Get_Deductible({colsCompany} IN,{colsOptionalCode} IN );
                                                        END IF;
                                                        END;",namedBindVariables)))
                                {
                                    return false;
                                }
                                
                                nTaxPercent = nTaxPercent / 100;
                            }
                            else
                            {
                                nTaxPercent = 0;
                            }

                            if (nDeduct == SalNumber.Null)
                            {
                                nDeduct = 100;
                            }
                            nDeductPercent = nDeduct / 100;

                            if (sAmountMethodDb == "NET")
                            {

                                if (bIsAutoBal)
                                {
                                    nToTaxAmount = tblVoucherPosting_colnThirdCurrencyAmount.Number * nTaxPercent;
                                    nCalculateTaxValue = nToTaxAmount * nDeductPercent;
                                    bIsAutoBal = false;
                                    nDeductThirdCurrValue = nToTaxAmount - nCalculateTaxValue;
                                    nCalculateTaxValue = this.RoundOfTax(frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).sRoundingMethod, nCalculateTaxValue, tblVoucherPosting_colnDecimalsInAmount.Number);
                                }
                                else
                                {
                                    nCalculateTaxValue = tblVoucherPosting_colnThirdCurrencyAmount.Number * nTaxPercent;
                                    nCalculateTaxValue = this.RoundOfTax(frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).sRoundingMethod, nCalculateTaxValue, tblVoucherPosting_colnDecimalsInAmount.Number);
                                }

                            }
                            else if (sAmountMethodDb == "GROSS")
                            {
                                if (bIsAutoBal)
                                {
                                    nToTaxAmount = tblVoucherPosting_colnThirdCurrencyAmount.Number * nTaxPercent / (1 + nTaxPercent);
                                    nCalculateTaxValue = nToTaxAmount * nDeductPercent;
                                    bIsAutoBal = false;
                                }
                                else
                                {
                                    nCalculateTaxValue = tblVoucherPosting_colnThirdCurrencyAmount.Number * nTaxPercent / (1 + nTaxPercent);
                                }
                                nDeductThirdCurrValue = 0;
                                nCalculateTaxValue = this.RoundOfTax(frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).sRoundingMethod, nCalculateTaxValue, tblVoucherPosting_colnDecimalsInAmount.Number);

                            }

                            tblVoucherPosting_colnParallelCurrTaxAmount.Number = nCalculateTaxValue;
                            tblVoucherPosting_colnParallelCurrTaxAmount.EditDataItemSetEdited();

                        }

                    }
                }

                if (sAmountMethodDb == "NET")
                {
                    nPosParallelCurrAmount = Sal.TblQueryColumnID(tblVoucherPosting_colnThirdCurrencyAmount);
                    nPosParallelCurrTaxAmount = Sal.TblQueryColumnID(tblVoucherPosting_colnParallelCurrTaxAmount);
                    this.dfnParallelCurrBalance.Number = Sal.TblColumnSum(tblVoucherPosting, nPosParallelCurrAmount, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1)) + Sal.TblColumnSum(tblVoucherPosting, nPosParallelCurrTaxAmount, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1));

                }
                else if (sAmountMethodDb == "GROSS")
                {
                    nPosParallelCurrAmount = Sal.TblQueryColumnID(tblVoucherPosting_colnThirdCurrencyAmount);
                    this.dfnParallelCurrBalance.Number = Sal.TblColumnSum(tblVoucherPosting, nPosParallelCurrAmount, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1));

                }
            }

            return 0;
        }

        /// <summary>
        /// </summary>
        /// <param name="hSql"></param>
        /// <returns></returns>
        public virtual SalBoolean DataRecordExecuteModify(SalSqlHandle hSql)
        {
            #region Local Variables
            SalNumber nCount = 0;
            // Bug 77719 Removed variable nContext
            SalNumber nTokens = 0;
            SalNumber nRowNo = 0;
            SalNumber nAmount = 0;
            SalArray<SalString> sTokens = new SalArray<SalString>();
            SalString sAccount = "";
            SalBoolean bOk = false;
            SalBoolean bReturn = false;
            SalString sFullParentName = "";
            #endregion

            #region Actions

            nCount = 0;
            MethodProgressDone();
            IDictionary<string, string> namedBindVariables = new Dictionary<string, string>();
            namedBindVariables.Add("lsAutoBal", this.QualifiedVarBindName("lsAutoBal"));
            namedBindVariables.Add("colsCompany", this.tblVoucherPosting_colsCompany.QualifiedBindName);
            namedBindVariables.Add("colsAccount", this.tblVoucherPosting_colsAccount.QualifiedBindName);
            namedBindVariables.Add("colsCurrencyCode", this.tblVoucherPosting_colsCurrencyCode.QualifiedBindName);
            namedBindVariables.Add("colnParallelCurrRateType", this.tblVoucherPosting_colnParallelCurrRateType.QualifiedBindName);
            namedBindVariables.Add("colsVoucherType", this.tblVoucherPosting_colsVoucherType.QualifiedBindName);
            namedBindVariables.Add("colnInternalSeqNumber", this.tblVoucherPosting_colnInternalSeqNumber.QualifiedBindName);
            namedBindVariables.Add("colsLedgerIds", this.tblVoucherPosting_colsLedgerIds.QualifiedBindName);
            namedBindVariables.Add("dfdVoucherDate", ":i_hWndParent.frmEntryVoucher.dfdVoucherDate");
            namedBindVariables.Add("dfsVoucherGroup", ":i_hWndParent.frmEntryVoucher.dfsVoucherGroup");
            if (!(bManualCompleted))
            {                
                // Bug 89906 begin   
                       
                if (!(DbPLSQLBlock(@"{lsAutoBal} := &AO.Voucher_Type_Detail_API.Get_Automatic_Vou_Balance({colsCompany} IN, {colsVoucherType} IN,{dfsVoucherGroup} IN)",namedBindVariables)))
                {
                    return false;
                }
                    
                if ((frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).cmbsVoucherStatus.Text == Sal.ListQueryTextX(frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).cmbsVoucherStatus, 0)) &&
                (this.dfnBalance.Number != 0) && lsAutoBal == "N")
                {
                    Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_VoEn_AlertBalance, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
                    return false;
                }
                // Bug 89906 end
                // Bug 77719 Removed Call to SalTblQueryContext(tblVoucherPosting)
                // Bug 76624, Begin. Changed the server method Check_If_Manual() to Check_If_Not_Excluded_Manual()
                if (Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Internal_Voucher_Util_Pub_API.Check_If_Not_Excluded_Manual") && Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Voucher_Type_API.Get_Use_Manual") && Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable(
                    "Internal_Ledger_Util_Pub_API.Get_Next_Int_Manual_Post_Seq"))
                {
                    // Bug 76624, Begin. Changed the server method Check_If_Manual() to Check_If_Not_Excluded_Manual() and put the GetParent() method

                    if (!(DbPLSQLBlock(@"BEGIN
	                                        IF (&AO.Voucher_Type_API.Get_Use_Manual({colsCompany} IN,{colsVoucherType} IN) ='TRUE') THEN
		                                        {colsLedgerIds} := &AO.Internal_Voucher_Util_Pub_API.Check_If_Not_Excluded_Manual({colsCompany} IN,
																					                                                {colsAccount} IN,
																					                                                {dfdVoucherDate} IN,
																					                                                {colsVoucherType} IN);
		                                               
		                                        IF ({colsLedgerIds} IS NOT NULL AND {colnInternalSeqNumber} IS NULL) THEN
			                                        {colnInternalSeqNumber} := &AO.Internal_Ledger_Util_Pub_API.Get_Next_Int_Manual_Post_Seq;
		                                        END IF;
	                                        END IF;
                                            END;",namedBindVariables)))
                    {
                        return false;
                    }
                        
                    // Bug 76624, End
                    tblVoucherPosting_colnInternalSeqNumber.EditDataItemSetEdited();
                    if (!(Sal.IsNull(tblVoucherPosting_colsLedgerIds)))
                    {
                        tblVoucherPosting_colAddInternal.Text = "TRUE";
                    }
                    else
                    {
                        tblVoucherPosting_colAddInternal.Text = "FALSE";
                    }
                }
                // Bug 76624, End
                if (tblVoucherPosting_colAddInternal.Text == "TRUE")
                {
                    bOk = true;
                    MethodProgressDone();
                    nTokens = ((SalString)tblVoucherPosting_colsLedgerIds.Text).Tokenize("", "|", sTokens);
                    p_sAccount = tblVoucherPosting_colsAccount.Text;
                    p_nRefRowNo = tblVoucherPosting_colnRowNo.Number;
                    p_nAmount = tblVoucherPosting_colnAmount.Number;
                    p_nCurrencyAmount = tblVoucherPosting_colnCurrencyAmount.Number;
                    p_nCurrRate = tblVoucherPosting_colnCurrencyRate.Number;
                    p_nInternalSeq = tblVoucherPosting_colnInternalSeqNumber.Number;
                    p_sCorrection = tblVoucherPosting_colCorrection.Text;
                    while (nCount < nTokens)
                    {
                        p_sLedger = sTokens[nCount];
                        bOk = ((bool)dlgManualIntPosting.ModalDialog(Ifs.Fnd.ApplicationForms.Int.Explorer.ExplorerForm, tblVoucherPosting)) && bOk;
                        nCount = nCount + 1;
                    }
                }
            }
            // Bug 77719 Removed Call SalTblSetContext(tblVoucherPosting, nContext)
            sFullParentName = ":i_hWndParent." + Ifs.Fnd.ApplicationForms.Int.QualifiedItemNameGet(i_hWndParent);
            if ((sAmountMethodDb == "GROSS") && (tblVoucherPosting_colsOptionalCode.Text != Ifs.Fnd.ApplicationForms.Const.strNULL) && (sFullParentName + ".dfdVoucherDate" != sFullParentName + ".dPrevVoucherDate"))
            {
                this.tblVoucherPosting_colnCurrencyDebetAmount.EditDataItemSetEdited();
                this.tblVoucherPosting_colnCurrencyCreditAmount.EditDataItemSetEdited();
                this.tblVoucherPosting_colnCurrencyTaxAmount.EditDataItemSetEdited();
                this.tblVoucherPosting_colnCurrencyGrossAmount.EditDataItemSetEdited();
                this.tblVoucherPosting_colnDebetAmount.EditDataItemSetEdited();
                this.tblVoucherPosting_colnCreditAmount.EditDataItemSetEdited();
                this.tblVoucherPosting_colnTaxAmount.EditDataItemSetEdited();
                this.tblVoucherPosting_colnGrossAmount.EditDataItemSetEdited();
                this.tblVoucherPosting_colnThirdCurrencyDebitAmount.EditDataItemSetEdited();
                this.tblVoucherPosting_colnThirdCurrencyCreditAmount.EditDataItemSetEdited();
            }
            bReturn = ((cChildTableFin)tblVoucherPosting).DataRecordExecuteModify(hSql);
            if (bOk && !(bManualCompleted))
            {
                tblVoucherPosting_colAddInternal.Text = "FALSE";
                tblVoucherPosting_colsManualAdded.Text = "TRUE";
            }
            return bReturn;
            
            #endregion
        }

        public virtual SalBoolean DataRecordExecuteRemove(SalSqlHandle hSql)
        {
            #region Local Variables
            SalBoolean bReturn = false;
            #endregion

            #region Action

            this.sIsRemoved = "TRUE";

            bReturn = ((cChildTableFin)tblVoucherPosting).DataRecordExecuteRemove(hSql);
            return bReturn;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="p_nWhat"></param>
        /// <returns></returns>
        public virtual SalBoolean UM_IntManualPostings(SalNumber p_nWhat)
        {
            #region Local Variables
            SalNumber nCount = 0;
            SalNumber nTokens = 0;
            SalArray<SalString> sTokens = new SalArray<SalString>();
            SalBoolean bOk = false;
            #endregion

            #region Actions
            switch (p_nWhat)
            {
                case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                    return Sal.TblAnyRows(tblVoucherPosting, Sys.ROW_Selected, 0) && (tblVoucherPosting_colsManualAdded.Text == "TRUE" || tblVoucherPosting_colAddInternal.Text == "TRUE");

                case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                    bOk = true;
                    GetInternalSeqNumberIfNull();
                    nTokens = ((SalString)tblVoucherPosting_colsLedgerIds.Text).Tokenize("", "|", sTokens);
                    p_sAccount = tblVoucherPosting_colsAccount.Text;
                    p_nRefRowNo = tblVoucherPosting_colnRowNo.Number;
                    p_nAmount = tblVoucherPosting_colnAmount.Number;
                    p_nCurrencyAmount = tblVoucherPosting_colnCurrencyAmount.Number;
                    p_nCurrRate = tblVoucherPosting_colnCurrencyRate.Number;
                    p_nInternalSeq = tblVoucherPosting_colnInternalSeqNumber.Number;
                    p_sCorrection = tblVoucherPosting_colCorrection.Text;
                    while (nCount < nTokens)
                    {
                        p_sLedger = sTokens[nCount];
                        bOk = ((bool)dlgManualIntPosting.ModalDialog(Ifs.Fnd.ApplicationForms.Int.Explorer.ExplorerForm, tblVoucherPosting)) && bOk;
                        nCount = nCount + 1;
                    }
                    if (bOk)
                    {
                        tblVoucherPosting_colAddInternal.Text = "FALSE";
                        tblVoucherPosting_colsManualAdded.Text = "TRUE";
                        frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).bIntManPostingsEntered = true;
                    }
                    return true;
            }
            

            return false;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean ManualPostings()
        {
            #region Local Variables
            SalNumber nCount = 0;
            SalNumber nContext = 0;
            SalNumber nTokens = 0;
            SalNumber nRowNo = 0;
            SalNumber nAmount = 0;
            SalArray<SalString> sTokens = new SalArray<SalString>();
            SalString sAccount = "";
            SalBoolean bOk = false;
            #endregion

            #region Actions
            nCount = 0;
            bManualCompleted = true;
            nContext = Sal.TblQueryContext(tblVoucherPosting);
            if (tblVoucherPosting_colAddInternal.Text == "TRUE")
            {
                bOk = true;
                GetInternalSeqNumberIfNull();
                MethodProgressDone();
                nTokens = ((SalString)tblVoucherPosting_colsLedgerIds.Text).Tokenize("", "|", sTokens);
                p_sAccount = tblVoucherPosting_colsAccount.Text;
                p_nRefRowNo = tblVoucherPosting_colnRowNo.Number;
                p_nAmount = tblVoucherPosting_colnAmount.Number;
                p_nCurrencyAmount = tblVoucherPosting_colnCurrencyAmount.Number;
                p_nCurrRate = tblVoucherPosting_colnCurrencyRate.Number;
                p_nInternalSeq = tblVoucherPosting_colnInternalSeqNumber.Number;
                p_sCorrection = tblVoucherPosting_colCorrection.Text;
                while (nCount < nTokens)
                {
                    p_sLedger = sTokens[nCount];
                    bOk = ((bool)dlgManualIntPosting.ModalDialog(Ifs.Fnd.ApplicationForms.Int.Explorer.ExplorerForm, tblVoucherPosting)) && bOk;
                    nCount = nCount + 1;
                }
            }
            Sal.TblSetContext(tblVoucherPosting, nContext);
            if (bOk)
            {
                tblVoucherPosting_colAddInternal.Text = "FALSE";
                tblVoucherPosting_colsManualAdded.Text = "TRUE";
                tblVoucherPosting_colnManualCounter.Number = tblVoucherPosting_colnManualCounter.Number + 1;
                frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).bIntManPostingsEntered = true;
            }
            return true;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber GetInternalSeqNumberIfNull()
        {
            IDictionary<string, string> namedBindVariables = new Dictionary<string, string>();
            namedBindVariables.Add("colsCompany", this.tblVoucherPosting_colsCompany.QualifiedBindName);
            namedBindVariables.Add("colsAccount", this.tblVoucherPosting_colsAccount.QualifiedBindName);     
            namedBindVariables.Add("colsVoucherType", this.tblVoucherPosting_colsVoucherType.QualifiedBindName);
            namedBindVariables.Add("colnInternalSeqNumber", this.tblVoucherPosting_colnInternalSeqNumber.QualifiedBindName);
            namedBindVariables.Add("colsLedgerIds", this.tblVoucherPosting_colsLedgerIds.QualifiedBindName);
            namedBindVariables.Add("dfdVoucherDate", ":i_hWndParent.frmEntryVoucher.dfdVoucherDate");
            
            SalBoolean bNull = (Sal.IsNull(tblVoucherPosting_colnInternalSeqNumber));
          
            if (bNull || Sal.IsNull(tblVoucherPosting_colsLedgerIds))
            {
                if (Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Internal_Ledger_Util_Pub_API.Get_Next_Int_Manual_Post_Seq"))
                {
                    // Bug 76624, Begin. Changed the server method Check_If_Manual() to Check_If_Not_Excluded_Manual()                    
                    if (!(DbPLSQLBlock(@"BEGIN
	                                        IF {colnInternalSeqNumber} IS NULL THEN
		                                        {colnInternalSeqNumber} := &AO.Internal_Ledger_Util_Pub_API.Get_Next_Int_Manual_Post_Seq;
	                                        END IF;
	                                        IF {colsLedgerIds} IS NULL THEN
		                                        {colsLedgerIds} := &AO.Internal_Voucher_Util_Pub_API.Check_If_Not_Excluded_Manual({colsCompany} IN,
																																    {colsAccount} IN,
																																    {dfdVoucherDate} IN,
																																    {colsVoucherType} IN);
	                                        END IF;			  
                                            END;" ,namedBindVariables)))
                    {
                        return false;
                    }
                    
                    // Bug 76624, End
                    if (bNull && !(Sal.IsNull(tblVoucherPosting_colnInternalSeqNumber)))
                    {
                        tblVoucherPosting_colnInternalSeqNumber.EditDataItemSetEdited();
                    }
                }
            }
            this.GetAttributes(tblVoucherPosting_colsCompany.Text, tblVoucherPosting_colsCurrencyCode.Text, frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).sCurrencyCode, tblVoucherPosting_colsCurrencyType.Text, frmEntryVoucher.FromHandle(
                    Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfdVoucherDate.DateTime);
            

            return 0;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber CheckStatAccount()
        {
            SalNumber nContextRow = Sal.TblQueryContext(tblVoucherPosting);
            SalNumber nCurrentRow = Sys.TBL_MinRow;
            while (Sal.TblFindNextRow(tblVoucherPosting, ref nCurrentRow, 0, 0))
            {
                Sal.TblSetContext(tblVoucherPosting, nCurrentRow);
                if (tblVoucherPosting_colIsStatAccount.Text == "TRUE")
                {
                    Sal.TblSetRowFlags(tblVoucherPosting, Sal.TblQueryContext(tblVoucherPosting), Sys.ROW_UnusedFlag1, true);
                }
                else
                {
                    Sal.TblSetRowFlags(tblVoucherPosting, Sal.TblQueryContext(tblVoucherPosting), Sys.ROW_UnusedFlag1, false);
                }
            }
            Sal.TblSetContext(tblVoucherPosting, nContextRow);
            return 0;
          
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean ResetNewButton()
        {
            SalString sFunctionGroup = frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfsVoucherGroup.Text;
            if (!(Sal.IsNull(frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfsVoucherGroup)))
            {
                if (sFunctionGroup == "Z")
                {
                    return (frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfsRevCostClearVoucher.Text == "PCAMA");
                }
                if (!(sFunctionGroup == "M" || sFunctionGroup == "Q" || sFunctionGroup == "K"))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber CheckIntManMethods()
        {
            // Bug 76624, Begin. Changed the server method Check_If_Manual() to Check_If_Not_Excluded_Manual()
            if (Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Internal_Voucher_Util_Pub_API.Check_If_Not_Excluded_Manual") && Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Voucher_Type_API.Get_Use_Manual") && Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable(
                "Internal_Ledger_Util_Pub_API.Get_Next_Int_Manual_Post_Seq"))
            {
                IDictionary<string, string> namedBindVariables = new Dictionary<string, string>();
                namedBindVariables.Add("colsCompany", this.tblVoucherPosting_colsCompany.QualifiedBindName);
                namedBindVariables.Add("colsAccount", this.tblVoucherPosting_colsAccount.QualifiedBindName);                
                namedBindVariables.Add("colsVoucherType", this.tblVoucherPosting_colsVoucherType.QualifiedBindName);
                namedBindVariables.Add("colnInternalSeqNumber", this.tblVoucherPosting_colnInternalSeqNumber.QualifiedBindName);
                namedBindVariables.Add("colsLedgerIds", this.tblVoucherPosting_colsLedgerIds.QualifiedBindName);
                namedBindVariables.Add("dfdVoucherDate", ":i_hWndParent.frmEntryVoucher.dfdVoucherDate");

                SalNumber nContextRow = Sal.TblQueryContext(this);
                SalNumber nCurrentRow = Sys.TBL_MinRow;
                while (Sal.TblFindNextRow(tblVoucherPosting, ref nCurrentRow, 0, 0))
                {
                    Sal.TblSetContext(tblVoucherPosting, nCurrentRow);
                    // Bug 76624, Begin. Changed the server method Check_If_Manual() to Check_If_Not_Excluded_Manual()    
                    if (!(DbPLSQLBlock(@"BEGIN
	                                        IF (&AO.Voucher_Type_API.Get_Use_Manual({colsCompany} IN,{colsVoucherType} IN) ='TRUE') THEN
		                                        {colsLedgerIds} := &AO.Internal_Voucher_Util_Pub_API.Check_If_Not_Excluded_Manual({colsCompany} IN,
																					                                                {colsAccount} IN,
																					                                                {dfdVoucherDate} IN,
																					                                                {colsVoucherType} IN);
		                                               
		                                        IF ({colsLedgerIds} IS NOT NULL AND {colnInternalSeqNumber} IS NULL) THEN
			                                        {colnInternalSeqNumber} := &AO.Internal_Ledger_Util_Pub_API.Get_Next_Int_Manual_Post_Seq;
		                                        END IF;
	                                        END IF;
                                            END;", namedBindVariables)))
                    {
                        return false;
                    }
                    
                    // Bug 76624, End
                    tblVoucherPosting_colnInternalSeqNumber.EditDataItemSetEdited();
                    if ((!(Sal.IsNull(tblVoucherPosting_colsLedgerIds))) && tblVoucherPosting_colsManualAdded.Text != "TRUE")
                    {
                        tblVoucherPosting_colAddInternal.Text = "TRUE";
                    }
                    else
                    {
                        tblVoucherPosting_colAddInternal.Text = "FALSE";
                    }
                }
                Sal.TblSetContext(tblVoucherPosting, nContextRow);
            }
            // Bug 76624, End
            
            return 0;
        }

        /// <summary>
        /// This function checks if all code parts except for account is null and returns TRUE if the condition is satisfied.
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean CheckIfAllCodePartsNull()
        {

            if ((tblVoucherPosting_colsCodeB.Text == Ifs.Fnd.ApplicationForms.Const.strNULL) && (tblVoucherPosting_colsCodeC.Text == Ifs.Fnd.ApplicationForms.Const.strNULL) && (tblVoucherPosting_colsCodeD.Text == Ifs.Fnd.ApplicationForms.Const.strNULL) && (tblVoucherPosting_colsCodeE.Text == Ifs.Fnd.ApplicationForms.Const.strNULL) &&
            (tblVoucherPosting_colsCodeF.Text == Ifs.Fnd.ApplicationForms.Const.strNULL) && (tblVoucherPosting_colsCodeG.Text == Ifs.Fnd.ApplicationForms.Const.strNULL) && (tblVoucherPosting_colsCodeH.Text == Ifs.Fnd.ApplicationForms.Const.strNULL) && (tblVoucherPosting_colsCodeI.Text == Ifs.Fnd.ApplicationForms.Const.strNULL) &&
            (tblVoucherPosting_colsCodeJ.Text == Ifs.Fnd.ApplicationForms.Const.strNULL) && (tblVoucherPosting_colsProcessCode.Text == Ifs.Fnd.ApplicationForms.Const.strNULL) && (tblVoucherPosting_colsText.Text == Ifs.Fnd.ApplicationForms.Const.strNULL))
            {
                   
                tblVoucherPosting.SendMessage(Const.PAM_SetNullCodeParts, 1, 0);
                   
            }
            else
            {
                tblVoucherPosting.SendMessage(Const.PAM_SetNullCodeParts, 0, 0);
            }

            return false;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber EnableSeqId()
        {
            SalString sProjectCodePart = Var.FinlibServices.GetCodePartFunction("PRACC");
            if (sProjectCodePart == "B")
            {
                if (tblVoucherPosting_colsCodeB.Text != Sys.STRING_Null)
                {
                    if (tblVoucherPosting_colsProjectActivityIdEnabled.Text == Sys.STRING_Null)
                    {
                        EnableDisableProjectActivityId(tblVoucherPosting_colsCodeB.Text);
                    }
                }
            }
            if (sProjectCodePart == "C")
            {
                if (tblVoucherPosting_colsCodeC.Text != Sys.STRING_Null)
                {
                    if (tblVoucherPosting_colsProjectActivityIdEnabled.Text == Sys.STRING_Null)
                    {
                        EnableDisableProjectActivityId(tblVoucherPosting_colsCodeC.Text);
                    }
                }
            }
            if (sProjectCodePart == "D")
            {
                if (tblVoucherPosting_colsCodeD.Text != Sys.STRING_Null)
                {
                    if (tblVoucherPosting_colsProjectActivityIdEnabled.Text == Sys.STRING_Null)
                    {
                        EnableDisableProjectActivityId(tblVoucherPosting_colsCodeD.Text);
                    }
                }
            }
            if (sProjectCodePart == "E")
            {
                if (tblVoucherPosting_colsCodeE.Text != Sys.STRING_Null)
                {
                    if (tblVoucherPosting_colsProjectActivityIdEnabled.Text == Sys.STRING_Null)
                    {
                        EnableDisableProjectActivityId(tblVoucherPosting_colsCodeE.Text);
                    }
                }
            }
            if (sProjectCodePart == "F")
            {
                if (tblVoucherPosting_colsCodeF.Text != Sys.STRING_Null)
                {
                    if (tblVoucherPosting_colsProjectActivityIdEnabled.Text == Sys.STRING_Null)
                    {
                        EnableDisableProjectActivityId(tblVoucherPosting_colsCodeF.Text);
                    }
                }
            }
            if (sProjectCodePart == "G")
            {
                if (tblVoucherPosting_colsCodeG.Text != Sys.STRING_Null)
                {
                    if (tblVoucherPosting_colsProjectActivityIdEnabled.Text == Sys.STRING_Null)
                    {
                        EnableDisableProjectActivityId(tblVoucherPosting_colsCodeG.Text);
                    }
                }
            }
            if (sProjectCodePart == "H")
            {
                if (tblVoucherPosting_colsCodeH.Text != Sys.STRING_Null)
                {
                    if (tblVoucherPosting_colsProjectActivityIdEnabled.Text == Sys.STRING_Null)
                    {
                        EnableDisableProjectActivityId(tblVoucherPosting_colsCodeH.Text);
                    }
                }
            }
            if (sProjectCodePart == "I")
            {
                if (tblVoucherPosting_colsCodeI.Text != Sys.STRING_Null)
                {
                    if (tblVoucherPosting_colsProjectActivityIdEnabled.Text == Sys.STRING_Null)
                    {
                        EnableDisableProjectActivityId(tblVoucherPosting_colsCodeI.Text);
                    }
                }
            }
            if (sProjectCodePart == "J")
            {
                if (tblVoucherPosting_colsCodeJ.Text != Sys.STRING_Null)
                {
                    if (tblVoucherPosting_colsProjectActivityIdEnabled.Text == Sys.STRING_Null)
                    {
                        EnableDisableProjectActivityId(tblVoucherPosting_colsCodeJ.Text);
                    }
                }
            }
            

            return 0;
      
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber EnableDisableSeqId(SalString sCodePart)
        {
            #region Actions
            SalString sProjCodePart = Var.FinlibServices.GetCodePartFunction("PRACC");
            if (sProjCodePart == sCodePart)
            {
                this.EnableDisableProjectActivityId(this.tblVoucherPosting_colsCodeG.Text);
            }
            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber CreateReverseVoucher()
        {
            if (tblVoucherPosting_colnCurrencyAmount.Number != Sys.NUMBER_Null)
            {
                tblVoucherPosting_colnCurrencyAmount.EditDataItemValueSet(0, (-tblVoucherPosting_colnCurrencyAmount.Number).ToString(tblVoucherPosting_colnDecimalsInAmount.Number).ToHandle());
            }
            tblVoucherPosting_colnAmount.EditDataItemValueSet(0, (-tblVoucherPosting_colnAmount.Number).ToString(tblVoucherPosting_colnAccDecimalsInAmount.Number).ToHandle());
            tblVoucherPosting_colnThirdCurrencyAmount.Number = -tblVoucherPosting_colnThirdCurrencyAmount.Number;
            if ((tblVoucherPosting_colnAmount.Number < 0 && tblVoucherPosting_colCorrection.Text == "N") || (tblVoucherPosting_colnAmount.Number > 0 && tblVoucherPosting_colCorrection.Text == "Y"))
            {
                tblVoucherPosting_colnCreditAmount.EditDataItemValueSet(1, (-tblVoucherPosting_colnAmount.Number).ToString(tblVoucherPosting_colnAccDecimalsInAmount.Number).ToHandle());
                tblVoucherPosting_colnDebetAmount.EditDataItemValueSet(1, SalNumber.Null.ToString(tblVoucherPosting_colnAccDecimalsInAmount.Number).ToHandle());
                // Third currency calculation
                if (!(frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).sParallelCurrency == Ifs.Fnd.ApplicationForms.Const.strNULL))
                {
                    tblVoucherPosting_colnThirdCurrencyCreditAmount.Number = -tblVoucherPosting_colnThirdCurrencyAmount.Number;
                    tblVoucherPosting_colnThirdCurrencyCreditAmount.EditDataItemSetEdited();
                    tblVoucherPosting_colnThirdCurrencyDebitAmount.Number = Sys.NUMBER_Null;
                    tblVoucherPosting_colnThirdCurrencyDebitAmount.EditDataItemSetEdited();
                }
                if (tblVoucherPosting_colnCurrencyAmount.Number != Sys.NUMBER_Null)
                {
                    tblVoucherPosting_colnCurrencyCreditAmount.EditDataItemValueSet(1, (-tblVoucherPosting_colnCurrencyAmount.Number).ToString(tblVoucherPosting_colnDecimalsInAmount.Number).ToHandle());
                }
                tblVoucherPosting_colnCurrencyDebetAmount.EditDataItemValueSet(1, SalNumber.Null.ToString(tblVoucherPosting_colnDecimalsInAmount.Number).ToHandle());
            }
            else
            {
                tblVoucherPosting_colnDebetAmount.EditDataItemValueSet(1, tblVoucherPosting_colnAmount.Number.ToString(tblVoucherPosting_colnAccDecimalsInAmount.Number).ToHandle());
                tblVoucherPosting_colnCreditAmount.EditDataItemValueSet(1, SalNumber.Null.ToString(tblVoucherPosting_colnDecimalsInAmount.Number).ToHandle());
                // Third currency calculation
                if (!(frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).sParallelCurrency == Ifs.Fnd.ApplicationForms.Const.strNULL))
                {
                    tblVoucherPosting_colnThirdCurrencyDebitAmount.Number = tblVoucherPosting_colnThirdCurrencyAmount.Number;
                    tblVoucherPosting_colnThirdCurrencyDebitAmount.EditDataItemSetEdited();
                    tblVoucherPosting_colnThirdCurrencyCreditAmount.Number = Sys.NUMBER_Null;
                    tblVoucherPosting_colnThirdCurrencyCreditAmount.EditDataItemSetEdited();
                }
                if (tblVoucherPosting_colnCurrencyAmount.Number != Sys.NUMBER_Null)
                {
                    tblVoucherPosting_colnCurrencyDebetAmount.EditDataItemValueSet(1, tblVoucherPosting_colnCurrencyAmount.Number.ToString(tblVoucherPosting_colnDecimalsInAmount.Number).ToHandle());
                }
                tblVoucherPosting_colnCurrencyCreditAmount.EditDataItemValueSet(1, SalNumber.Null.ToString(tblVoucherPosting_colnDecimalsInAmount.Number).ToHandle());
            }
            if (tblVoucherPosting_colnCurrencyTaxAmount.Number != Sys.NUMBER_Null)
            {
                tblVoucherPosting_colnCurrencyTaxAmount.Number = -tblVoucherPosting_colnCurrencyTaxAmount.Number;
                tblVoucherPosting_colnCurrencyTaxAmount.EditDataItemSetEdited();
            }
            if (tblVoucherPosting_colnTaxAmount.Number != Sys.NUMBER_Null)
            {
                tblVoucherPosting_colnTaxAmount.Number = -tblVoucherPosting_colnTaxAmount.Number;
                tblVoucherPosting_colnTaxAmount.EditDataItemSetEdited();
            }

            if (tblVoucherPosting_colnParallelCurrTaxAmount.Number != Sys.NUMBER_Null)
            {
                tblVoucherPosting_colnParallelCurrTaxAmount.Number = -tblVoucherPosting_colnParallelCurrTaxAmount.Number;
                tblVoucherPosting_colnParallelCurrTaxAmount.EditDataItemSetEdited();
            }
            tblVoucherPosting_colnQuantity.Number = -tblVoucherPosting_colnQuantity.Number;
            tblVoucherPosting_colnQuantity.EditDataItemSetEdited();
            

            return 0;

        }

        /// <summary>
        /// </summary>
        /// <param name="nMyValue"></param>
        /// <param name="nPreviousAmount"></param>
        /// <returns></returns>
        public virtual SalBoolean ResetCurrTaxAmountFromTaxAmount(SalNumber nMyValue, SalNumber nPreviousAmount)
        {
            #region Local Variables
            SalNumber nCalculateAccTaxValue = 0;
            SalNumber nPosCurrAmount = 0;
            SalNumber nPosAmount = 0;
            SalNumber nPosCurrTaxAmount = 0;
            SalNumber nPosTaxAmount = 0;

            SalNumber nPosParallelCurrAmount = 0;
            SalNumber nPosParallelTaxAmnt = 0;

            SalNumber nCalculaeThirdCurrTaxAmount = 0;
            #endregion

            #region Actions

            if (nMyValue != nPreviousAmount)
            {
                if (!(Sal.IsNull(tblVoucherPosting_colsOptionalCode)))
                {
                    if (!(Sal.IsNull(tblVoucherPosting_colnTaxAmount)))
                    {
                        nMyValue = this.RoundOf(nMyValue, tblVoucherPosting_colnDecimalsInAmount.Number);
                        if (tblVoucherPosting_colnActCurrencyRate.Number == Sys.NUMBER_Null)
                        {
                            tblVoucherPosting_colnActCurrencyRate.Number = tblVoucherPosting_colnCurrencyRate.Number;
                        }
                        this.GetTransCurrAmountForRate(nMyValue, tblVoucherPosting_colnActCurrencyRate.Number, ref nCalculateAccTaxValue);
                        this.GetTransCurrAmountForRate(nMyValue, tblVoucherPosting_colnCurrencyRate.Number, ref nCalculateAccTaxValue);

                        this.sCurrCode = frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).sCurrencyCode;
                        if (this.i_sFinParallelBaseType == "ACCOUNTING_CURRENCY" || tblVoucherPosting_colsCurrencyCode.Text == this.sCurrCode)
                        {
                            if (tblVoucherPosting_colnParallelCurrRate.Number == 0 || tblVoucherPosting_colnParallelCurrRate.Number == Sys.NUMBER_Null)
                            {
                                nCalculaeThirdCurrTaxAmount = 0;
                            }
                            else
                            {
                                this.GetParallelCurrAmountForRate(nMyValue, tblVoucherPosting_colnParallelCurrRate.Number, ref nCalculaeThirdCurrTaxAmount);
                            }
                        }
                        else if (this.i_sFinParallelBaseType == "TRANSACTION_CURRENCY")
                        {
                            if (tblVoucherPosting_colnParallelCurrRate.Number == 0 || tblVoucherPosting_colnParallelCurrRate.Number == Sys.NUMBER_Null)
                            {
                                nCalculaeThirdCurrTaxAmount = 0;
                            }
                            else
                            {
                                this.GetParallelCurrAmountForRate(nCalculateAccTaxValue, tblVoucherPosting_colnParallelCurrRate.Number, ref nCalculaeThirdCurrTaxAmount);
                            }
                        }
                        if (!(Sal.IsNull(tblVoucherPosting_colnCurrencyAmount)))
                        {
                            tblVoucherPosting_colnCurrencyTaxAmount.Number = nCalculateAccTaxValue;
                            tblVoucherPosting_colnCurrencyTaxAmount.EditDataItemSetEdited();
                            if (this.i_sFinParallelBaseType != Sys.STRING_Null)
                            {
                                tblVoucherPosting_colnParallelCurrTaxAmount.Number = nCalculaeThirdCurrTaxAmount;
                                tblVoucherPosting_colnParallelCurrTaxAmount.EditDataItemSetEdited();
                            }
                        }
                    }
                    else
                    {
                        tblVoucherPosting_colnCurrencyTaxAmount.Number = Sys.NUMBER_Null;
                    }
                    if (sAmountMethodDb == "NET")
                    {
                        nPosCurrAmount = Sal.TblQueryColumnID(tblVoucherPosting_colnCurrencyAmount);
                        nPosAmount = Sal.TblQueryColumnID(tblVoucherPosting_colnAmount);
                        nPosCurrTaxAmount = Sal.TblQueryColumnID(tblVoucherPosting_colnCurrencyTaxAmount);
                        nPosTaxAmount = Sal.TblQueryColumnID(tblVoucherPosting_colnTaxAmount);

                        nPosParallelTaxAmnt = Sal.TblQueryColumnID(tblVoucherPosting_colnParallelCurrTaxAmount);
                        nPosParallelCurrAmount = Sal.TblQueryColumnID(tblVoucherPosting_colnThirdCurrencyAmount);
                        this.dfnCurrencyBalance.Number = Sal.TblColumnSum(tblVoucherPosting, nPosCurrAmount, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1)) + Sal.TblColumnSum(tblVoucherPosting, nPosCurrTaxAmount, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1));
                        this.dfnBalance.Number = Sal.TblColumnSum(tblVoucherPosting, nPosAmount, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1)) + Sal.TblColumnSum(tblVoucherPosting, nPosTaxAmount, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1));
                        this.dfnParallelCurrBalance.Number = Sal.TblColumnSum(tblVoucherPosting, nPosParallelCurrAmount, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1)) + Sal.TblColumnSum(tblVoucherPosting, nPosParallelTaxAmnt, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1));
                    }
                }
                else
                {
                    tblVoucherPosting_colnTaxAmount.Number = 0;
                    tblVoucherPosting_colnParallelCurrTaxAmount.Number = 0;
                }
            }
            return true;
            
            #endregion
        }
        // --- Double Entry Validation methods ----
        /// <summary>
        /// The methods collects information necessary for double entry based on the visible rows.
        /// The info is stored in four dynamic arrays where index is the row group id.
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber CalcRowGroupInfo()
        {
            #region Local Variables
            SalNumber nRowAmount = 0;
            SalNumber nRowParallelAmount = 0;
            SalNumber nRowTransactionCount = 0;
            SalNumber nRowCorrectionStatus = 0;
            #endregion

            #region Actions

            // Reset all info arrays
            group_cor_sta.SetUpperBound(1, -1);
            group_balance.SetUpperBound(1, -1);
            group_c_count.SetUpperBound(1, -1);
            group_d_count.SetUpperBound(1, -1);
            group_parallel_balance.SetUpperBound(1, -1);
            // Bug 74540, Begin.
            nCalcVATLines = 0;
            // Bug 74540, End.
            // Keep current context Row
            SalNumber nContextRow = Sal.TblQueryContext(tblVoucherPosting);
            SalNumber nCurrentRow = Sys.TBL_MinRow;
            while (Sal.TblFindNextRow(tblVoucherPosting, ref nCurrentRow, 0, Sys.ROW_MarkDeleted))
            {
                Sal.TblSetContext(tblVoucherPosting, nCurrentRow);
                if (!(Sal.IsNull(tblVoucherPosting_colnRowGroupId)))
                {
                    // Bug 74540, Begin.
                    if (!(Sal.IsNull(tblVoucherPosting_colsOptionalCode)))
                    {
                        if (Sal.IsNull(tblVoucherPosting_colsTaxType))
                        {
                            GetTaxType();
                        }
                    }
                    else
                    {
                        tblVoucherPosting_colsTaxType.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                    }
                    if ((tblVoucherPosting_colsTaxType.Text == "CALCVAT") && (Sal.ListQuerySelection(tblVoucherPosting_colsTaxDirection) == 0 || Sal.ListQuerySelection(tblVoucherPosting_colsTaxDirection) == Sys.LB_Err))
                    {
                        nCalcVATLines = nCalcVATLines + 1;
                    }
                    // Bug 74540, End.
                    nRowAmount = CalcRowAmount();
                    nRowParallelAmount = CalcRowParallelAmount();
                    nRowTransactionCount = GetRowTransactionCount();
                    nRowCorrectionStatus = GetRowCorrectionStatus();
                    // ----- Balances of the groups -----
                    group_balance[tblVoucherPosting_colnRowGroupId.Number] = group_balance[tblVoucherPosting_colnRowGroupId.Number] + nRowAmount;
                    group_parallel_balance[tblVoucherPosting_colnRowGroupId.Number] = group_parallel_balance[tblVoucherPosting_colnRowGroupId.Number] + nRowParallelAmount;
                    // ----- Cardinality of the groups -----
                    if (nRowAmount > 0)
                    {
                        group_c_count[tblVoucherPosting_colnRowGroupId.Number] = group_c_count[tblVoucherPosting_colnRowGroupId.Number] + nRowTransactionCount;
                    }
                    else if (nRowAmount < 0)
                    {
                        group_d_count[tblVoucherPosting_colnRowGroupId.Number] = group_d_count[tblVoucherPosting_colnRowGroupId.Number] + nRowTransactionCount;
                    }
                    // ----- Corrections status of groups -----
                    if (group_cor_sta[tblVoucherPosting_colnRowGroupId.Number] != -1)
                    {
                        if (group_cor_sta[tblVoucherPosting_colnRowGroupId.Number] == 0)
                        {
                            // initialize
                            group_cor_sta[tblVoucherPosting_colnRowGroupId.Number] = nRowCorrectionStatus;
                        }
                        else if (group_cor_sta[tblVoucherPosting_colnRowGroupId.Number] != nRowCorrectionStatus)
                        {
                            // mark error for this group
                            group_cor_sta[tblVoucherPosting_colnRowGroupId.Number] = -1;
                        }
                    }
                }
            }
            // Restore context
            Sal.TblSetContext(tblVoucherPosting, nContextRow);

            return 0;
            #endregion
        }

        /// <summary>
        /// Double Entry Validation support method
        /// Returns the effective value of this row.
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber CalcRowAmount()
        {
            if (Sal.IsNull(tblVoucherPosting_colnAmount))
            {
                return 0;
            }
            else if (!(Sal.IsNull(tblVoucherPosting_colnAmount)) && Sal.IsNull(tblVoucherPosting_colnTaxAmount))
            {
                return tblVoucherPosting_colnAmount.Number;
            }
            else
            {
                return tblVoucherPosting_colnAmount.Number + tblVoucherPosting_colnTaxAmount.Number;
            }
        }

        public virtual SalNumber CalcRowParallelAmount()
        {
            if (Sal.IsNull(tblVoucherPosting_colnThirdCurrencyAmount))
            {
                return 0;
            }
            else if (!(Sal.IsNull(tblVoucherPosting_colnThirdCurrencyAmount)) && Sal.IsNull(tblVoucherPosting_colnParallelCurrTaxAmount))
            {
                return tblVoucherPosting_colnThirdCurrencyAmount.Number;
            }
            else
            {
                return tblVoucherPosting_colnThirdCurrencyAmount.Number + tblVoucherPosting_colnParallelCurrTaxAmount.Number;
            }
        }

        /// <summary>
        /// Double Entry Validation support method
        /// Perform double entry validation based on data collected by CalcRowGroupInfo() on the info arrays.
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean ValidateRowGroups()
        {
            SalArray<SalString> sParam = new SalArray<SalString>();
            SalNumber nCurrentPos = 0;
            SalNumber nUpperBound = group_c_count.GetUpperBound(1);
            while (nCurrentPos <= nUpperBound)
            {
                // ---------- Check for correct cardinality inside group
                if (group_c_count[nCurrentPos] != SalNumber.Null && group_d_count[nCurrentPos] != SalNumber.Null)
                {
                    if (group_c_count[nCurrentPos] > 1 && group_d_count[nCurrentPos] > 1)
                    {
                        sParam[0] = nCurrentPos.ToString(0);
                        Ifs.Fnd.ApplicationForms.Int.AlertBoxWithParams(Properties.Resources.TEXT_DoubleEntryPostError, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Warning, Ifs.Fnd.ApplicationForms.Const.WARNING_Ok, sParam);
                        return false;
                    }
                }
                // ---------- Check for correction value uniqueness inside group
                if (group_cor_sta[nCurrentPos] == -1)
                {
                    sParam[0] = nCurrentPos.ToString(0);
                    Ifs.Fnd.ApplicationForms.Int.AlertBoxWithParams(Properties.Resources.TEXT_DoubleEntryCorrError, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Warning, Ifs.Fnd.ApplicationForms.Const.WARNING_Ok, sParam);
                    return false;
                }
                // ----------
                nCurrentPos = nCurrentPos + 1;
            }
            return true;
        }

        /// <summary>
        /// Double Entry Validation support method
        /// Calculates the next row group id based on the info arrays calculated by CalcRowGroupInfo()
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber GetNextGroupId()
        {     
            SalNumber nLastBalancedGroup = 0;
            SalNumber nCurrentPos = 0;
            SalNumber nUpperBound = group_balance.GetUpperBound(1);
            while (nCurrentPos <= nUpperBound)
            {
                if (group_balance[nCurrentPos] != SalNumber.Null)
                {
                    if (group_balance[nCurrentPos] != 0 || group_parallel_balance[nCurrentPos] != 0)
                    {   
                        return nCurrentPos; 
                    }
                    else
                    {   
                        nLastBalancedGroup = nCurrentPos; 
                    }
                }
                nCurrentPos = nCurrentPos + 1;
            }
            // Bug 74540, Begin. Added the amount of nCalcVATLines to the Return Value.
            return nLastBalancedGroup + nCalcVATLines + 1;
            // Bug 74540, End. 
        }            

        /// <summary>
        /// Double Entry Validation support method
        /// a row in voucher postings corresponds to 1 or 2 transactions based on the tax code
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber GetRowTransactionCount()
        {
            // Bug 74540, Begin. Modified the IF Condition to include Calc VAT Scenarios.
            if (Sal.IsNull(tblVoucherPosting_colnTaxAmount) || Sal.IsNull(tblVoucherPosting_colsOptionalCode) || (!(Sal.IsNull(tblVoucherPosting_colnTaxAmount)) && !(Sal.IsNull(tblVoucherPosting_colsOptionalCode)) && (tblVoucherPosting_colsTaxType.Text != "")))
            {
                return 1;
            }
            // Bug 74540, End.
            return 2;
        }

        /// <summary>
        /// Double Entry Validation support method
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber GetRowCorrectionStatus()
        {
            if (tblVoucherPosting_colCorrection.Text == "Y")
            {
                return 1;
            }
            return 2;
        }

        protected virtual void checkBlank(Control lparent, Control lchild)
        {
            if (lparent.Text == "")
            {
                lchild.Text = "";
            }
        }

        protected virtual void RefreshBalances()
        {
            #region Local Variables
            SalNumber nPosCurrAmount = 0;
            SalNumber nPosAmount = 0;
            SalNumber nPosParallelAmount = 0;

            SalNumber nPosCurrTaxAmount = 0;
            SalNumber nPosTaxAmount = 0;
            SalNumber nPosParallelTaxAmnt = 0;
            #endregion

            #region Actions

            CheckStatAccount();
            nPosCurrAmount = Sal.TblQueryColumnID(tblVoucherPosting_colnCurrencyAmount);
            nPosAmount = Sal.TblQueryColumnID(tblVoucherPosting_colnAmount);

            nPosParallelAmount = Sal.TblQueryColumnID(tblVoucherPosting_colnThirdCurrencyAmount);
            if (sAmountMethodDb == "GROSS")
            {
                this.dfnCurrencyBalance.Number = Sal.TblColumnSum(tblVoucherPosting, nPosCurrAmount, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1));
                this.dfnBalance.Number = Sal.TblColumnSum(tblVoucherPosting, nPosAmount, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1));

                this.dfnParallelCurrBalance.Number = Sal.TblColumnSum(tblVoucherPosting, nPosParallelAmount, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1));
            }
            else if (sAmountMethodDb == "NET")
            {
                nPosCurrTaxAmount = Sal.TblQueryColumnID(tblVoucherPosting_colnCurrencyTaxAmount);
                nPosTaxAmount = Sal.TblQueryColumnID(tblVoucherPosting_colnTaxAmount);

                nPosParallelTaxAmnt = Sal.TblQueryColumnID(tblVoucherPosting_colnParallelCurrTaxAmount);
                this.dfnCurrencyBalance.Number = Sal.TblColumnSum(tblVoucherPosting, nPosCurrAmount, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1)) + Sal.TblColumnSum(tblVoucherPosting, nPosCurrTaxAmount, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1));
                this.dfnBalance.Number = Sal.TblColumnSum(tblVoucherPosting, nPosAmount, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1)) + Sal.TblColumnSum(tblVoucherPosting, nPosTaxAmount, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1));

                this.dfnParallelCurrBalance.Number = Sal.TblColumnSum(tblVoucherPosting, nPosParallelAmount, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1)) + Sal.TblColumnSum(tblVoucherPosting, nPosParallelTaxAmnt, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1));
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
        private void tblVoucherPosting_colnRowGroupId_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.tblVoucherPosting_colnRowGroupId_OnPM_DataItemQueryEnabled(sender, e);
                    break;

                case Sys.SAM_SetFocus:
                    this.tblVoucherPosting_colnRowGroupId_OnSAM_SetFocus(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblVoucherPosting_colnRowGroupId_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherPosting_colnRowGroupId_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(this.tblVoucherPosting_colnRowGroupId.i_hWndFrame)).dfsRowGroupValidation.Text == "Y")
            {
                e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled, Sys.wParam, Sys.lParam);
                return;
            }
            e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
            return;
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherPosting_colnRowGroupId_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(this.tblVoucherPosting_colnRowGroupId.i_hWndFrame)).dfsRowGroupValidation.Text == "Y")
            {
                e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
                return;
            }
            else
            {
                // Because RowGroupId is the first column it's necessary to use PostMsg to send tab key instead of System.Windows.Forms.SendKeys.Send("{TAB}")
                Sal.PostMsg(this.tblVoucherPosting_colnRowGroupId.i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.WM_KEYDOWN, Vis.VK_Tab, 0);
                e.Return = false;
                return;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherPosting_colnRowGroupId_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.tblVoucherPosting_colnRowGroupId.Number != Sys.NUMBER_Null && this.tblVoucherPosting_colnRowGroupId.Number < 0)
            {
                this.tblVoucherPosting_colnRowGroupId.Number = 1;
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblVoucherPosting_colsAccount_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblVoucherPosting_colsAccount_OnPM_DataItemValidate(sender, e);
                    break;

                // Bug 77719, Removed On SAM_SetFocus

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovDone:
                    this.tblVoucherPosting_colsAccount_OnPM_DataItemLovDone(sender, e);
                    break;

                case Const.PAM_SetCodePartValues:
                    this.tblVoucherPosting_colsAccount_OnPAM_SetCodePartValues(sender, e);
                    break;

            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherPosting_colsAccount_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Local Variables
            SalString sPrevIsStatAccount = "";
            #endregion

            #region Actions
            e.Handled = true;
            this.CheckIfAllCodePartsNull();
            if (!(this.bCopyFromGL || this.bCopyFromTemplate))
            {
                if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam) == Sys.VALIDATE_Cancel)
                {
                    e.Return = Sys.VALIDATE_Cancel;
                    return;
                }
            }
            // Bug 76624, Begin. Changed the server method Check_If_Manual() to Check_If_Not_Excluded_Manual()
            if (Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Internal_Voucher_Util_Pub_API.Check_If_Not_Excluded_Manual") && Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Voucher_Type_API.Get_Use_Manual") && Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable(
                "Internal_Ledger_Util_Pub_API.Get_Next_Int_Manual_Post_Seq"))
            {
                // Bug 76624, Begin. Changed the server method Check_If_Manual() to Check_If_Not_Excluded_Manual()
              
                IDictionary<string, string> namedBindVariables = new Dictionary<string, string>();
                namedBindVariables.Add("colsCompany", this.tblVoucherPosting_colsCompany.QualifiedBindName);
                namedBindVariables.Add("colsAccount", this.tblVoucherPosting_colsAccount.QualifiedBindName);
                namedBindVariables.Add("colsVoucherType", this.tblVoucherPosting_colsVoucherType.QualifiedBindName);
                namedBindVariables.Add("colnInternalSeqNumber", this.tblVoucherPosting_colnInternalSeqNumber.QualifiedBindName);
                namedBindVariables.Add("colsLedgerIds", this.tblVoucherPosting_colsLedgerIds.QualifiedBindName);
                namedBindVariables.Add("colsPrevAccount", this.tblVoucherPosting_colsPrevAccount.QualifiedBindName);
                namedBindVariables.Add("dfdVoucherDate", ":i_hWndParent.frmEntryVoucher.dfdVoucherDate");

                if (!(DbPLSQLBlock(@"BEGIN
	                                    IF (&AO.Voucher_Type_API.Get_Use_Manual({colsCompany} IN,{colsVoucherType} IN) ='TRUE') THEN
		                                    {colsLedgerIds} := &AO.Internal_Voucher_Util_Pub_API.Check_If_Not_Excluded_Manual({colsCompany} IN,
																					                                            {colsAccount} IN,
																					                                            {dfdVoucherDate} IN,
																					                                            {colsVoucherType} IN);
		                                               
		                                    IF ({colsLedgerIds} IS NOT NULL AND {colnInternalSeqNumber} IS NULL) THEN
			                                    {colnInternalSeqNumber} := &AO.Internal_Ledger_Util_Pub_API.Get_Next_Int_Manual_Post_Seq;
		                                    END IF;
	                                    END IF;
                                        END;", namedBindVariables)))
                {
                    e.Return = false;
                    return;
                }
                
                // Bug 76624, End
                this.tblVoucherPosting_colnInternalSeqNumber.EditDataItemSetEdited();
                if (this.tblVoucherPosting_colsManualAdded.Text == "TRUE" && (this.tblVoucherPosting_colsAccount.Text != this.tblVoucherPosting_colsPrevAccount.Text))
                {
                    this.tblVoucherPosting_colnManualCounter.Number = 1;
                    if (Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Internal_Postings_Accrul_API.Remove_Manual_Postings"))
                    {                        
                        DbPLSQLBlock(@"&AO.Internal_Postings_Accrul_API.Remove_Manual_Postings({colsCompany} IN,
                                								                               {colsLedgerIds} IN,
                                								                               {colsPrevAccount} IN,
                                								                               {colnInternalSeqNumber} IN)",namedBindVariables);   
                    }
                }
                if ((!(Sal.IsNull(this.tblVoucherPosting_colsLedgerIds))) && ((this.tblVoucherPosting_colsManualAdded.Text != "TRUE") || (this.tblVoucherPosting_colnManualCounter.Number > 0)))
                {
                    this.tblVoucherPosting_colAddInternal.Text = "TRUE";
                }
                else
                {
                    this.tblVoucherPosting_colAddInternal.Text = "FALSE";
                }
            }
            // Bug 76624, End

            if ((!(Sal.IsNull(this.tblVoucherPosting_colsAccount))) && (this.tblVoucherPosting_colsAccount.Text != this.tblVoucherPosting_colsPrevAccount.Text))
            {
                sPrevIsStatAccount = this.tblVoucherPosting_colIsStatAccount.Text;
                DbPLSQLBlock(@"{0} := &AO.Account_API.Is_Stat_Account({1} IN,{2} IN );",
                                    this.tblVoucherPosting_colIsStatAccount.QualifiedBindName,
                                    this.tblVoucherPosting_colsCompany.QualifiedBindName,
                                    this.tblVoucherPosting_colsAccount.QualifiedBindName);

                if ((tblVoucherPosting_colIsStatAccount.Text != sPrevIsStatAccount) && (!Sal.IsNull(this.tblVoucherPosting_colnCurrencyAmount)))
                {
                    this.RefreshBalances();
                }
                else if (Sal.IsNull(this.tblVoucherPosting_colnCurrencyAmount))
                {
                    this.CheckStatAccount();
                }
            }

            if (this.tblVoucherPosting_colsAccount.Text != this.tblVoucherPosting_colsPrevAccount.Text)
            {
                if (!(Sal.IsNull(this.tblVoucherPosting_colsAccount)))
                {
                    this.GetDefaultTaxCode();
                }
                else
                {
                    this.tblVoucherPosting_colsTaxDirection.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                }
				// Bug 105544, Begin
                if (!(Sal.IsNull(this.tblVoucherPosting_colnTaxAmount)))
                {
                    // Bug 97225, Begin
                    if (this.tblVoucherPosting_colsPrevTaxCode.Text != this.tblVoucherPosting_colsOptionalCode.Text)
                    {
                        this.bTaxCodeChanged = true;
                        // Bug 97225, End
                        this.ResetTaxAmount();
                        this.bTaxCodeChanged = false;
                        this.tblVoucherPosting_colsPrevTaxCode.Text = this.tblVoucherPosting_colsOptionalCode.Text;
                        // Bug 97225, Begin
                    }
                    // Bug 97225, End
                }
                else
                    this.tblVoucherPosting_colsPrevTaxCode.Text = this.tblVoucherPosting_colsOptionalCode.Text;
				// Bug 105544, End
            }
            // Removed code for bug 81403 which Disabled and Enabled tblVoucherPosting_colsTaxDirection. Enable and Disable caused other problems (focus ended up in header part).
            // Instead of Disable the column just set it to not editable and if user try to focus the column then tab to next column
            // Removed code for bug 88632 which was (probably) a workaround caused by the correction of bug 81403
            this.tblVoucherPosting_colsPrevAccount.Text = this.tblVoucherPosting_colsAccount.Text;
            e.Return = Sys.VALIDATE_Ok;
            checkBlank(tblVoucherPosting_colsAccount, tblVoucherPosting_colsAccountDesc);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemLovDone event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherPosting_colsAccount_OnPM_DataItemLovDone(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            SalString.FromHandle(Sys.lParam).Tokenize("", ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_RS).ToCharacter(), this.sRecords);
            this.sRecords[1].Tokenize("", ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_US).ToCharacter(), this.sUnits);
            this.sUnits[1].Tokenize("", "-", this.sUserName);
            Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_User, 0, 0);
            e.Return = true;
            return;
            #endregion
        }

        private void tblVoucherPosting_colsAccount_OnPAM_SetCodePartValues(object sender, WindowActionsEventArgs e)
        {
            #region Local Variables
            SalString sReqField = "";
            #endregion

            #region Actions
            e.Handled = true;
            sReqField = Ifs.Fnd.ApplicationForms.Int.PalAttrGet("PROJECT_ACTIVITY_ID", SalString.FromHandle(e.LParam));

            if (!sReqField.IsEmpty)
            {
                this.tblVoucherPosting_colnProjectActivityId.Text = sReqField;
                this.tblVoucherPosting_colsProjectActivityIdEnabled.Text = "Y";
                this.tblVoucherPosting_colnProjectActivityId.EditDataItemSetEdited();

            }
            e.Return = Sal.SendClassMessage(Const.PAM_SetCodePartValues, e.WParam, e.LParam);
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblVoucherPosting_colsProcessCode_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.tblVoucherPosting_colsProcessCode_OnSAM_SetFocus(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblVoucherPosting_colsProcessCode_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherPosting_colsProcessCode_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (!(Sal.IsNull(this.tblVoucherPosting_colsProcessCode)))
            {
                if (!(DbPLSQLBlock(@"{0} := Account_Process_Code_API.Get_Description({1} IN, {2} IN )",
                                                        this.dfsCodePartDescription.QualifiedBindName,
                                                        this.tblVoucherPosting_colsCompany.QualifiedBindName,
                                                        this.tblVoucherPosting_colsProcessCode.QualifiedBindName)))
                {
                    // Don't translate this message, this message only for programmer not user
                    Ifs.Fnd.ApplicationForms.Int.AlertBox("Design time error in tblVoucherPosting_colsProcessCode !", Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
                    e.Return = false;
                    return;
                }
                
            }
            e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherPosting_colsProcessCode_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (!(Sal.IsNull(this.tblVoucherPosting_colsProcessCode)))
            {
                if (!(DbPLSQLBlock(@"&AO.Voucher_Row_API.Validate_Process_Code__({0} IN,{1} IN,{2} IN )",
                        this.tblVoucherPosting_colsCompany.QualifiedBindName,
                        this.tblVoucherPosting_colsProcessCode.QualifiedBindName,
                        ":i_hWndParent.frmEntryVoucher.dfdVoucherDate")))
                {
                    e.Return = false;
                    return;
                }      
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblVoucherPosting_colsOptionalCode_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                // Removed code for bug corrections 81403, 85151 which was setting focus here and there, checking if LoV was done and disable/enable (caused other problems) tblVoucherPosting_colsTaxDirection and

                // instead handle tblVoucherPosting_colsTaxDirection so that when tblVoucherPosting_colsOptionalCode is null it is not editable and cannot get focus (jump to next column).

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblVoucherPosting_colsOptionalCode_OnPM_DataItemValidate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_EditStateFieldEnabled:
                    this.tblVoucherPosting_colsOptionalCode_OnPM_EditStateFieldEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherPosting_colsOptionalCode_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {


            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam) == Sys.VALIDATE_Cancel)
            {
                e.Return = Sys.VALIDATE_Cancel;
                return;
            }
            if (!(Sal.IsNull(this.tblVoucherPosting_colsOptionalCode)))
            {

                DbPLSQLBlock(@"&AO.Statutory_fee_api.Get_Tax_Code_Info({0} OUT,{1} OUT,{2} OUT,{3} IN, {4} IN,{5} IN);",
                                this.QualifiedVarBindName("sMultipleTax"),
                                this.QualifiedVarBindName("sTaxType"),
                                this.QualifiedVarBindName("nDeduct"),
                                this.tblVoucherPosting_colsCompany.QualifiedBindName,
                                this.tblVoucherPosting_colsOptionalCode.QualifiedBindName,
                                ":i_hWndParent.frmEntryVoucher.dfdVoucherDate");
                
                
                // Bug 97225, End
                if (this.sMultipleTax == "TRUE" || this.sTaxType == "RDE")
                {
                    this.sMultipleTax = SalString.Null;
                    this.sTaxType = SalString.Null;
                    Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_MultipleTax, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Warning, Ifs.Fnd.ApplicationForms.Const.WARNING_Ok);
                    e.Return = Sys.VALIDATE_Cancel;
                    return;
                }
                if (this.tblVoucherPosting_colsFunctionGroup.Text == "Q")
                {
                    Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_NoAutoTaxTrans, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Warning, Ifs.Fnd.ApplicationForms.Const.WARNING_Ok);
                    if (!(this.CheckTaxCode()))
                    {
                        this.tblVoucherPosting_colsPrevTaxCode.Text = this.tblVoucherPosting_colsOptionalCode.Text;
                        e.Return = false;
                        return;
                    }
                }
            }
                
            if (this.tblVoucherPosting_colsOptionalCode.Text != this.tblVoucherPosting_colsPrevTaxCode.Text)
            {
                if (!(Sal.IsNull(this.tblVoucherPosting_colsOptionalCode)))
                {
                    if (!(this.CheckTaxCode()))
                    {
                        this.tblVoucherPosting_colsPrevTaxCode.Text = this.tblVoucherPosting_colsOptionalCode.Text;
                        e.Return = false;
                        return;
                    }
                }
                else
                {
                    this.tblVoucherPosting_colsTaxDirection.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                }
                if (!(Sal.IsNull(this.tblVoucherPosting_colnTaxAmount)))
                {
                    // Bug 97225, Begin
                    this.bTaxCodeChanged = true;
                    this.ResetTaxAmount();
                    this.bTaxCodeChanged = false;
                    // Bug 97225, End
                }
            }
            this.tblVoucherPosting_colsPrevTaxCode.Text = this.tblVoucherPosting_colsOptionalCode.Text;
            e.Return = Sys.VALIDATE_Ok;
            return;
            #endregion
        }

        /// <summary>
        /// PM_EditStateFieldEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherPosting_colsOptionalCode_OnPM_EditStateFieldEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            
            if (this.sTaxHandlingValue == "BLOCKED")
            {
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                return;
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_EditStateFieldEnabled, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblVoucherPosting_colsTaxDirection_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_Click:
                    this.tblVoucherPosting_colsTaxDirection_OnSAM_Click(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_LookupInit:
                    this.tblVoucherPosting_colsTaxDirection_OnPM_LookupInit(sender, e);
                    break;

                case Sys.SAM_SetFocus:
                    this.tblVoucherPosting_colsTaxDirection_OnSAM_SetFocus(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.tblVoucherPosting_colsTaxDirection_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_Click event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherPosting_colsTaxDirection_OnSAM_Click(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (!(Sal.IsNull(this.tblVoucherPosting_colsOptionalCode)))
            {
                if (Sal.IsNull(this.tblVoucherPosting_colsTaxType))
                {
                    this.GetTaxType();
                }
            }
            else
            {
                this.tblVoucherPosting_colsTaxType.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
            }
            this.tblVoucherPosting_colsTaxDirection.LookupInvalidate();
            #endregion
        }

        /// <summary>
        /// PM_LookupInit event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherPosting_colsTaxDirection_OnPM_LookupInit(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_LookupInit, Sys.wParam, Sys.lParam);
            if (this.tblVoucherPosting_colsTaxType.Text == "NOTAX")
            {
                if (Sal.ListDelete(this.tblVoucherPosting_colsTaxDirection, 1) != Sys.LB_Err)
                {
                    Sal.ListDelete(this.tblVoucherPosting_colsTaxDirection, 0);
                }
            }
            else if (this.tblVoucherPosting_colsTaxType.Text == "VAT")
            {
                // Bug 80763 begin
                // If SalListDelete( hWndItem, 2 ) != LB_Err
                Sal.ListDelete(this.tblVoucherPosting_colsTaxDirection, 2);
                // Bug 80763 end
            }
            else if (this.tblVoucherPosting_colsTaxType.Text == "CALCVAT")
            {
                // Bug 80763 begin
                // If SalListDelete( hWndItem, 2 ) != LB_Err
                Sal.ListDelete(this.tblVoucherPosting_colsTaxDirection, 2);
                // Bug 80763 end
            }
            // Bug Id 74604 Begin
            this.nCountListVal = 0;
            this.nCountListVal = Sal.ListQueryCount(this.tblVoucherPosting_colsTaxDirection);
            // Bug 80763 begin
            // If SalListDelete( hWndItem, nCountListVal-1 ) != LB_Err
            Sal.ListDelete(this.tblVoucherPosting_colsTaxDirection, this.nCountListVal - 1);
            // Bug 80763 end
            // Bug Id 74604 End
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherPosting_colsTaxDirection_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.IsNull(this.tblVoucherPosting_colsOptionalCode))
            {
                // Used this method as using Sal.SendMsg,Sal.PostMsg to send Tab key is not working properly in aurora client
                System.Windows.Forms.SendKeys.Send("{TAB}");
                return;
            }
            e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherPosting_colsTaxDirection_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.IsNull(this.tblVoucherPosting_colsOptionalCode))
            {
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                return;
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblVoucherPosting_colsCurrencyCode_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblVoucherPosting_colsCurrencyCode_OnPM_DataItemValidate(sender, e);
                    break;

                case Sys.SAM_SetFocus:
                    this.tblVoucherPosting_colsCurrencyCode_OnSAM_SetFocus(sender, e);
                    break;

                // Bug 68537 - Begin.

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovDone:
                    e.Handled = true;
                    this.bSkipFocusCheck = true;
                    break;

                // Bug 68537 - End.
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherPosting_colsCurrencyCode_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam) == Sys.VALIDATE_Cancel)
            {
                e.Return = Sys.VALIDATE_Cancel;
                return;
            }
            if (!(Sal.IsNull(this.tblVoucherPosting_colsCurrencyCode)))
            {
                if (this.tblVoucherPosting_colsCurrencyCode.Text != this.tblVoucherPosting_colsPrevCurrencyCode.Text)
                {
                    if (this.sCurrCode == Ifs.Fnd.ApplicationForms.Const.strNULL)
                    {
                        this.sCurrCode = frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(this.tblVoucherPosting_colsCurrencyCode.i_hWndFrame)).sCurrencyCode;
                    }
                    this.sCurrCode = Ifs.Fnd.ApplicationForms.Const.strNULL;
                    bCopyParallelCurrRate = false;
                    if (!(this.ValidateCurrencyCode()))
                    {
                        // Bug 72531, Begin
                        this.bSkipFocusCheck = true;
                        this.tblVoucherPosting_colsPrevCurrencyCode.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                        // Bug 72531, End
                        e.Return = Sys.VALIDATE_Cancel;
                        return;
                    }
                    bCopyParallelCurrRate = true;
                    if (!(Sal.IsNull(this.tblVoucherPosting_colnTaxAmount)) && !(sMode == "DUPLICATED"))
                    {
                        if (!(Sal.IsNull(this.tblVoucherPosting_colnCurrencyTaxAmount)))
                        {
                            this.ResetTaxAmountFromCurrTaxAmount(this.tblVoucherPosting_colnCurrencyTaxAmount.Number, this.tblVoucherPosting_colnCurrencyTaxAmount.Number + 1);
                        }
                    }
                }
            }
            this.tblVoucherPosting_colsPrevCurrencyCode.Text = this.tblVoucherPosting_colsCurrencyCode.Text;

            if (i_sFinParallelBaseType != Sys.STRING_Null)
            {
                GetParallelCurrencyRate();
                             
            }

            e.Return = Sys.VALIDATE_Ok;
            return;
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherPosting_colsCurrencyCode_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            // Bug 68537 - Begin.
            if (!(this.bSkipFocusCheck))
            {
                this.tblVoucherPosting_colsPrevCurrencyCode.Text = this.tblVoucherPosting_colsCurrencyCode.Text;
                this.bSkipFocusCheck = false;
            }
            // Bug 68537 - End.
            e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblVoucherPosting_colsCurrencyType_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblVoucherPosting_colsCurrencyType_OnPM_DataItemValidate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovUserWhere:
                    this.tblVoucherPosting_colsCurrencyType_OnPM_DataItemLovUserWhere(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherPosting_colsCurrencyType_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam) == Sys.VALIDATE_Cancel)
            {
                e.Return = Sys.VALIDATE_Cancel;
                return;
            }
            if (!(Sal.IsNull(this.tblVoucherPosting_colsCurrencyType)) && (this.tblVoucherPosting_colsCurrencyType.Text != this.sPrevCurrType))
            {
                if (!(this.ValidateCurrencyType()))
                {
                    e.Return = Sys.VALIDATE_Cancel;
                    return;
                }
            }
            e.Return = Sys.VALIDATE_Ok;
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemLovUserWhere event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherPosting_colsCurrencyType_OnPM_DataItemLovUserWhere(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            e.Return = ((SalString)("&AO.Currency_Type_API.Get_Rate_Type_Category_Db(COMPANY,CURRENCY_TYPE) != 'PARALLEL_CURRENCY'")).ToHandle();
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblVoucherPosting_colnCurrencyDebetAmount_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblVoucherPosting_colnCurrencyDebetAmount_OnPM_DataItemValidate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.tblVoucherPosting_colnCurrencyDebetAmount_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherPosting_colnCurrencyDebetAmount_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.tblVoucherPosting_colnCurrencyDebetAmount.Number != Sys.NUMBER_Null)
            {
                if (this.tblVoucherPosting_colnCurrencyDebetAmount.Number < 0)
                {
                    this.tblVoucherPosting_colnCurrencyDebetAmount.Number = -this.tblVoucherPosting_colnCurrencyDebetAmount.Number;
                }
                if (this.tblVoucherPosting_colCorrection.Text == "Y")
                {
                    this.tblVoucherPosting_colnCurrencyDebetAmount.Number = -this.tblVoucherPosting_colnCurrencyDebetAmount.Number;
                }
            }
                
            if (Sal.IsNull(this.tblVoucherPosting_colnCurrencyCreditAmount))
            {
                this.tblVoucherPosting_colnCurrencyDebetAmount.Number = this.SetAnotherValue(this.tblVoucherPosting_colnCurrencyDebetAmount.Number, this.tblVoucherPosting_colnDebetAmount, "CURRENT_AMOUNT", ref this.nCalculatedTaxValue);
                this.SetTaxValue(this.tblVoucherPosting_colnCurrencyDebetAmount.Number, this.tblVoucherPosting_colnPrevCurrencyAmount.Number, this.tblVoucherPosting_colnCurrencyTaxAmount, this.sAmountMethodDb, "CURRENT_AMOUNT", this.nCalculatedTaxValue);
                if (!(Sal.IsNull(this.tblVoucherPosting_colnCreditAmount)))
                {
                    Sal.SendMsg(this.tblVoucherPosting_colnCreditAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, SalNumber.Null.ToString(0).ToHandle());
                    Sal.SendMsg(this.tblVoucherPosting_colnThirdCurrencyCreditAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, SalNumber.Null.ToString(0).ToHandle());
                }
                this.SetThirdCurrencyAmounts();
            }

            if (this.tblVoucherPosting_colnPrevCurrencyAmount.Number != this.tblVoucherPosting_colnCurrencyDebetAmount.Number && this.tblVoucherPosting_colsManualAdded.Text == "TRUE")
            {
                this.tblVoucherPosting_colAddInternal.Text = "TRUE";
            }

            if (this.tblVoucherPosting_colnCurrencyDebetAmount.Number != Sys.NUMBER_Null)
            {
                this.tblVoucherPosting_colnPrevCurrencyAmount.Number = this.tblVoucherPosting_colnCurrencyDebetAmount.Number;
            }
            if (!(Sal.IsNull(this.tblVoucherPosting_colnAmount)))
            {
                if (!(Sal.IsNull(this.tblVoucherPosting_colnDebetAmount)))
                {
                    this.tblVoucherPosting_colnPrevAmount.Number = this.tblVoucherPosting_colnDebetAmount.Number;
                }
                else if (!(Sal.IsNull(this.tblVoucherPosting_colnCreditAmount)))
                {
                    this.tblVoucherPosting_colnPrevAmount.Number = -this.tblVoucherPosting_colnCreditAmount.Number;
                }
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherPosting_colnCurrencyDebetAmount_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (!(Sal.IsNull(this.tblVoucherPosting_colnCurrencyCreditAmount)))
            {
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                return;
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblVoucherPosting_colnCurrencyCreditAmount_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblVoucherPosting_colnCurrencyCreditAmount_OnPM_DataItemValidate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.tblVoucherPosting_colnCurrencyCreditAmount_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherPosting_colnCurrencyCreditAmount_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.tblVoucherPosting_colnCurrencyCreditAmount.Number != Sys.NUMBER_Null)
            {
                if (this.tblVoucherPosting_colnCurrencyCreditAmount.Number < 0)
                {
                    this.tblVoucherPosting_colnCurrencyCreditAmount.Number = -this.tblVoucherPosting_colnCurrencyCreditAmount.Number;
                }
                if (this.tblVoucherPosting_colCorrection.Text == "Y")
                {
                    this.tblVoucherPosting_colnCurrencyCreditAmount.Number = -this.tblVoucherPosting_colnCurrencyCreditAmount.Number;
                }
            }
                
            if (Sal.IsNull(this.tblVoucherPosting_colnCurrencyDebetAmount))
            {
                this.tblVoucherPosting_colnCurrencyCreditAmount.Number = -this.SetAnotherValue(-this.tblVoucherPosting_colnCurrencyCreditAmount.Number, this.tblVoucherPosting_colnCreditAmount, "CURRENT_AMOUNT", ref this.nCalculatedTaxValue);
                this.SetTaxValue(-this.tblVoucherPosting_colnCurrencyCreditAmount.Number, this.tblVoucherPosting_colnPrevCurrencyAmount.Number, this.tblVoucherPosting_colnCurrencyTaxAmount, this.sAmountMethodDb, "CURRENT_AMOUNT", this.nCalculatedTaxValue);
                if (!(Sal.IsNull(this.tblVoucherPosting_colnDebetAmount)))
                {
                    Sal.SendMsg(this.tblVoucherPosting_colnDebetAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, SalNumber.Null.ToString(0).ToHandle());
                    Sal.SendMsg(this.tblVoucherPosting_colnThirdCurrencyDebitAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, SalNumber.Null.ToString(0).ToHandle());
                }
                this.SetThirdCurrencyAmounts();
            }

			if (this.tblVoucherPosting_colnPrevCurrencyAmount.Number != this.tblVoucherPosting_colnCurrencyCreditAmount.Number && this.tblVoucherPosting_colsManualAdded.Text == "TRUE")
            {
                this.tblVoucherPosting_colAddInternal.Text = "TRUE";
            }				

            if (this.tblVoucherPosting_colnCurrencyCreditAmount.Number != Sys.NUMBER_Null)
            {
                // Bug 92910, Begin
                this.tblVoucherPosting_colnPrevCurrencyAmount.Number = -this.tblVoucherPosting_colnCurrencyCreditAmount.Number;
                // Bug 92910, End
            }
            if (!(Sal.IsNull(this.tblVoucherPosting_colnAmount)))
            {
                if (!(Sal.IsNull(this.tblVoucherPosting_colnDebetAmount)))
                {
                    this.tblVoucherPosting_colnPrevAmount.Number = this.tblVoucherPosting_colnDebetAmount.Number;
                }
                else if (!(Sal.IsNull(this.tblVoucherPosting_colnCreditAmount)))
                {
                    this.tblVoucherPosting_colnPrevAmount.Number = -this.tblVoucherPosting_colnCreditAmount.Number;
                }
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherPosting_colnCurrencyCreditAmount_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (!(Sal.IsNull(this.tblVoucherPosting_colnCurrencyDebetAmount)))
            {
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                return;
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblVoucherPosting_colnCurrencyAmount_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblVoucherPosting_colnCurrencyAmount_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherPosting_colnCurrencyAmount_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            // Bug 97225, Begin, Move code from below to calculate the tax values when only the sign is changed
            if (this.tblVoucherPosting_colnPrevCurrencyAmount.Number != this.tblVoucherPosting_colnCurrencyAmount.Number)
            {
                this.bCurrencyAmtChanged = true;
            }
            // Bug 97225, End
            if ((this.tblVoucherPosting_colnCurrencyAmount.Number < 0 && this.tblVoucherPosting_colCorrection.Text == "Y") || (this.tblVoucherPosting_colnCurrencyAmount.Number > 0 && this.tblVoucherPosting_colCorrection.Text == "N") || (this.tblVoucherPosting_colnCurrencyAmount.Number == 0 && this.tblVoucherPosting_colnCurrencyCreditAmount.Number != 0))
            {
                // Bug 97225, Begin
                bCalculateParallelCurrTax = false;
                this.tblVoucherPosting_colnCurrencyDebetAmount.Number = this.SetAnotherValue(this.tblVoucherPosting_colnCurrencyAmount.Number, this.tblVoucherPosting_colnDebetAmount, "CURRENT_AMOUNT", ref this.nCalculatedTaxValue);
                bCalculateParallelCurrTax = true;
                // Bug 97225, End
                this.tblVoucherPosting_colnCurrencyDebetAmount.EditDataItemSetEdited();
                Sal.SendMsg(this.tblVoucherPosting_colnCurrencyCreditAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, SalNumber.Null.ToString(0).ToHandle());
                Sal.SendMsg(this.tblVoucherPosting_colnCreditAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, SalNumber.Null.ToString(0).ToHandle());   
                Sal.SendMsg(this.tblVoucherPosting_colnThirdCurrencyCreditAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, SalNumber.Null.ToString(0).ToHandle());
                if (this.i_sFinParallelBaseType != Sys.STRING_Null)
                    this.SetThirdCurrencyAmounts();
            }
            else
            {
                // Bug 97225, Begin
                bCalculateParallelCurrTax = false;
                this.tblVoucherPosting_colnCurrencyCreditAmount.Number = -this.SetAnotherValue(this.tblVoucherPosting_colnCurrencyAmount.Number, this.tblVoucherPosting_colnCreditAmount, "CURRENT_AMOUNT", ref this.nCalculatedTaxValue);
                bCalculateParallelCurrTax = true;
                // Bug 97225, End
                this.tblVoucherPosting_colnCurrencyCreditAmount.EditDataItemSetEdited();
                Sal.SendMsg(this.tblVoucherPosting_colnCurrencyDebetAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, SalNumber.Null.ToString(0).ToHandle());
                Sal.SendMsg(this.tblVoucherPosting_colnDebetAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, SalNumber.Null.ToString(0).ToHandle());
                Sal.SendMsg(this.tblVoucherPosting_colnThirdCurrencyDebitAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, SalNumber.Null.ToString(0).ToHandle());
                if (this.i_sFinParallelBaseType != Sys.STRING_Null)
                    this.SetThirdCurrencyAmounts();
            }
            if (this.tblVoucherPosting_colnPrevCurrencyAmount.Number != this.tblVoucherPosting_colnCurrencyAmount.Number && this.tblVoucherPosting_colsManualAdded.Text == "TRUE")
            {
                this.tblVoucherPosting_colAddInternal.Text = "TRUE";
            }
            if (this.tblVoucherPosting_colnPrevCurrencyAmount.Number != this.tblVoucherPosting_colnCurrencyAmount.Number)
            {
                this.bCurrencyAmtChanged = true;
            }
            this.SetTaxValue(this.tblVoucherPosting_colnCurrencyAmount.Number, this.tblVoucherPosting_colnPrevCurrencyAmount.Number, this.tblVoucherPosting_colnCurrencyTaxAmount, this.sAmountMethodDb, "CURRENT_AMOUNT", this.nCalculatedTaxValue);
            Sal.SetFieldEdit(this.tblVoucherPosting_colnCurrencyAmount.i_hWndSelf, false);
            if (this.tblVoucherPosting_colnCurrencyAmount.Number != Sys.NUMBER_Null)
            {
                this.tblVoucherPosting_colnPrevCurrencyAmount.Number = this.tblVoucherPosting_colnCurrencyAmount.Number;
            }
            this.bCurrencyAmtChanged = false;
            if (!(Sal.IsNull(this.tblVoucherPosting_colnAmount)))
            {
                if (!(Sal.IsNull(this.tblVoucherPosting_colnDebetAmount)))
                {
                    this.tblVoucherPosting_colnPrevAmount.Number = this.tblVoucherPosting_colnDebetAmount.Number;
                }
                else if (!(Sal.IsNull(this.tblVoucherPosting_colnCreditAmount)))
                {
                    this.tblVoucherPosting_colnPrevAmount.Number = -this.tblVoucherPosting_colnCreditAmount.Number;
                }
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblVoucherPosting_colnCurrencyTaxAmount_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.tblVoucherPosting_colnCurrencyTaxAmount_OnSAM_SetFocus(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblVoucherPosting_colnCurrencyTaxAmount_OnPM_DataItemValidate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.tblVoucherPosting_colnCurrencyTaxAmount_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherPosting_colnCurrencyTaxAmount_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.nPrevCurrencyTaxAmount = this.tblVoucherPosting_colnCurrencyTaxAmount.Number;
            e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherPosting_colnCurrencyTaxAmount_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.ResetTaxAmountFromCurrTaxAmount(this.tblVoucherPosting_colnCurrencyTaxAmount.Number, this.nPrevCurrencyTaxAmount);
            if (!(Sal.IsNull(this.tblVoucherPosting_colsOptionalCode)))
            {

                if ((this.tblVoucherPosting_colnCurrencyTaxAmount.Number == Sys.NUMBER_Null && (this.tblVoucherPosting_colnParallelCurrTaxAmount.Number == Sys.NUMBER_Null)) && this.tblVoucherPosting_colsTaxType.Text != "NOTAX")

                {
                    Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_Vou_CurrTaxAmountNull, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
                    e.Return = false;
                    return;
                }
                if (((this.tblVoucherPosting_colnCurrencyTaxAmount.Number < 0 && this.tblVoucherPosting_colnCurrencyAmount.Number > 0) || (this.tblVoucherPosting_colnCurrencyTaxAmount.Number > 0 && this.tblVoucherPosting_colnCurrencyAmount.Number < 0)) && this.tblVoucherPosting_colsTaxType.Text != "NOTAX")
                {
                    Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_Vou_CurrTaxAmountSign, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
                    e.Return = false;
                    return;
                }
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherPosting_colnCurrencyTaxAmount_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.IsNull(this.tblVoucherPosting_colsOptionalCode))
            {
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                return;
            }
            if (this.tblVoucherPosting_colsTaxType.Text == "NOTAX")
            {
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                return;
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblVoucherPosting_colnCurrencyRate_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.tblVoucherPosting_colnCurrencyRate_OnSAM_SetFocus(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblVoucherPosting_colnCurrencyRate_OnPM_DataItemValidate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.tblVoucherPosting_colnCurrencyRate_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherPosting_colnCurrencyRate_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.tblVoucherPosting_colnCurrencyRate.Number != Sys.NUMBER_Null)
            {
                this.nPrevRate = this.tblVoucherPosting_colnCurrencyRate.Number;
            }
            e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherPosting_colnCurrencyRate_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if ((this.tblVoucherPosting_colnCurrencyRate.Number <= 0) && (this.tblVoucherPosting_colnCurrencyRate.Number != Sys.NUMBER_Null))
            {
                Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.ACC_ERROR_NegCurrRate, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
                Sal.SetFocus(this.tblVoucherPosting_colnCurrencyRate.i_hWndSelf);
                e.Return = Sys.VALIDATE_Cancel;
                return;
            }
            if (this.tblVoucherPosting_colnCurrencyAmount.Number != 0 && this.tblVoucherPosting_colnCurrencyAmount.Number != Sys.NUMBER_Null)
            {
                if (this.tblVoucherPosting_colnCurrencyRate.Number != this.nPrevRate)
                {
                    // Bug 97225, Begin
                    this.tblVoucherPosting_colnCurrencyRate.Number = this.SetAnotherValue(this.tblVoucherPosting_colnCurrencyRate.Number, this.tblVoucherPosting_colnCurrencyAmount, "RATE", ref this.nCalculatedTaxValue);
                    // Bug 97225, End
                    this.ResetTaxAmountFromCurrTaxAmount(this.tblVoucherPosting_colnCurrencyTaxAmount.Number, this.tblVoucherPosting_colnCurrencyTaxAmount.Number + 1);
                }
            }
            if (!(Sal.IsNull(this.tblVoucherPosting_colnAmount)))
            {
                if (!(Sal.IsNull(this.tblVoucherPosting_colnDebetAmount)))
                {
                    this.tblVoucherPosting_colnPrevAmount.Number = this.tblVoucherPosting_colnDebetAmount.Number;
                }
                else if (!(Sal.IsNull(this.tblVoucherPosting_colnCreditAmount)))
                {
                    this.tblVoucherPosting_colnPrevAmount.Number = this.tblVoucherPosting_colnCreditAmount.Number;
                }
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherPosting_colnCurrencyRate_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if ((((SalString)this.tblVoucherPosting_colsTransCode.Text).Trim().ToUpper() != "MANUAL") || (((SalString)this.tblVoucherPosting_colsCurrencyCode.Text).Trim().ToUpper() == frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(this.tblVoucherPosting_colnCurrencyRate.i_hWndFrame)).sCurrencyCode.Trim().ToUpper()) ||
            (this.sIsValidEmuCurrency == "TRUE") || (this.sSetRateNotEnabled == "TRUE"))
            {
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                return;
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblVoucherPosting_colnDebetAmount_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblVoucherPosting_colnDebetAmount_OnPM_DataItemValidate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.tblVoucherPosting_colnDebetAmount_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherPosting_colnDebetAmount_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.tblVoucherPosting_colnDebetAmount.Number != Sys.NUMBER_Null)
            {
                if (this.tblVoucherPosting_colnDebetAmount.Number < 0)
                {
                    this.tblVoucherPosting_colnDebetAmount.Number = -this.tblVoucherPosting_colnDebetAmount.Number;
                }
                if (this.tblVoucherPosting_colCorrection.Text == "Y")
                {
                    this.tblVoucherPosting_colnDebetAmount.Number = -this.tblVoucherPosting_colnDebetAmount.Number;
                }
            }
                
            if (this.tblVoucherPosting_colnDebetAmount.Number == this.tblVoucherPosting_colnPrevAmount.Number)
            {
                this.tblVoucherPosting_colnPrevAmount.Number = this.tblVoucherPosting_colnAmount.Number;
            }
            if (Sal.IsNull(this.tblVoucherPosting_colnCreditAmount))
            {
                this.tblVoucherPosting_colnDebetAmount.Number = this.SetAnotherValue(this.tblVoucherPosting_colnDebetAmount.Number, this.tblVoucherPosting_colnCurrencyDebetAmount, "ACCOUNTING_AMOUNT", ref this.nCalculatedTaxValue);
                this.SetTaxValue(this.tblVoucherPosting_colnDebetAmount.Number, this.tblVoucherPosting_colnPrevAmount.Number, this.tblVoucherPosting_colnTaxAmount, this.sAmountMethodDb, "ACCOUNTING_AMOUNT", this.nCalculatedTaxValue);
            }
			if (this.tblVoucherPosting_colnPrevAmount.Number != this.tblVoucherPosting_colnDebetAmount.Number && this.tblVoucherPosting_colsManualAdded.Text == "TRUE")
            {
                this.tblVoucherPosting_colAddInternal.Text = "TRUE";
            }
            if (this.tblVoucherPosting_colnDebetAmount.Number != Sys.NUMBER_Null)
            {
                this.tblVoucherPosting_colnPrevAmount.Number = this.tblVoucherPosting_colnDebetAmount.Number;
                this.bCleared = false;
            }
            else
            {
                Sal.ClearField(this.tblVoucherPosting_colnCurrencyDebetAmount);
                this.bCleared = true;
            }
            // Bug 95055 Begin
            this.sCallFrmDCAmnt = "TRUE";
            // Bug 95055 End
            Sal.SendMsg(this.tblVoucherPosting_colnCurrencyDebetAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
            // Bug 95055 Begin
            this.sCallFrmDCAmnt = "FALSE";
            // Bug 95055 End
            if (this.bCleared)
            {
                Sal.ClearField(this.tblVoucherPosting_colnDebetAmount);
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherPosting_colnDebetAmount_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (!(Sal.IsNull(this.tblVoucherPosting_colnCreditAmount)))
            {
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                return;
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblVoucherPosting_colnCreditAmount_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblVoucherPosting_colnCreditAmount_OnPM_DataItemValidate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.tblVoucherPosting_colnCreditAmount_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherPosting_colnCreditAmount_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.tblVoucherPosting_colnCreditAmount.Number != Sys.NUMBER_Null)
            {
                if (this.tblVoucherPosting_colnCreditAmount.Number < 0)
                {
                    this.tblVoucherPosting_colnCreditAmount.Number = -this.tblVoucherPosting_colnCreditAmount.Number;
                }
                if (this.tblVoucherPosting_colCorrection.Text == "Y")
                {
                    this.tblVoucherPosting_colnCreditAmount.Number = -this.tblVoucherPosting_colnCreditAmount.Number;
                }
            }
                
            if (this.tblVoucherPosting_colnCreditAmount.Number == this.tblVoucherPosting_colnPrevAmount.Number)
            {
                this.tblVoucherPosting_colnPrevAmount.Number = this.tblVoucherPosting_colnAmount.Number;
            }
            if (Sal.IsNull(this.tblVoucherPosting_colnDebetAmount))
            {
                this.tblVoucherPosting_colnCreditAmount.Number = -this.SetAnotherValue(-this.tblVoucherPosting_colnCreditAmount.Number, this.tblVoucherPosting_colnCurrencyCreditAmount, "ACCOUNTING_AMOUNT", ref this.nCalculatedTaxValue);
                this.SetTaxValue(-this.tblVoucherPosting_colnCreditAmount.Number, this.tblVoucherPosting_colnPrevAmount.Number, this.tblVoucherPosting_colnTaxAmount, this.sAmountMethodDb, "ACCOUNTING_AMOUNT", this.nCalculatedTaxValue);
            }
			if (this.tblVoucherPosting_colnPrevAmount.Number != this.tblVoucherPosting_colnCreditAmount.Number && this.tblVoucherPosting_colsManualAdded.Text == "TRUE")
            {
                this.tblVoucherPosting_colAddInternal.Text = "TRUE";
            }
            if (this.tblVoucherPosting_colnCreditAmount.Number != Sys.NUMBER_Null)
            {
                this.tblVoucherPosting_colnPrevAmount.Number = -this.tblVoucherPosting_colnCreditAmount.Number;
                this.bCleared = false;
            }
            else
            {
                Sal.ClearField(this.tblVoucherPosting_colnCurrencyCreditAmount);
                this.bCleared = true;
            }
            // Bug 95055 Begin
            this.sCallFrmDCAmnt = "TRUE";
            // Bug 95055 End
            Sal.SendMsg(this.tblVoucherPosting_colnCurrencyCreditAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
            // Bug 95055 Begin
            this.sCallFrmDCAmnt = "FALSE";
            // Bug 95055 End
            if (this.bCleared)
            {
                Sal.ClearField(this.tblVoucherPosting_colnCreditAmount);
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherPosting_colnCreditAmount_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (!(Sal.IsNull(this.tblVoucherPosting_colnDebetAmount)))
            {
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                return;
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblVoucherPosting_colnAmount_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblVoucherPosting_colnAmount_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherPosting_colnAmount_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.sCurrCode = frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(this.tblVoucherPosting_colnAmount.i_hWndFrame)).sCurrencyCode;                
            DbPLSQLBlock(@"{0} := &AO.Currency_Code_API.Get_Emu({1} IN,{2} IN );",
                this.QualifiedVarBindName("IsEmu"),
                this.tblVoucherPosting_colsCompany.QualifiedBindName,
                this.tblVoucherPosting_colsCurrencyCode.QualifiedBindName);
           
            // Bug 97225, Begin - Added the IF condition
            if (this.tblVoucherPosting_colnPrevAmount.Number != this.tblVoucherPosting_colnAmount.Number)
            {
                this.bAmtChanged = true;
            }
            // Bug 97225, End
            if ((this.tblVoucherPosting_colnAmount.Number < 0 && this.tblVoucherPosting_colCorrection.Text == "Y") || (this.tblVoucherPosting_colnAmount.Number >= 0 && this.tblVoucherPosting_colCorrection.Text == "N"))
            {
                // Bug 97225, Begin
                bCalculateParallelCurrTax = false;
                this.tblVoucherPosting_colnDebetAmount.Number = this.SetAnotherValue(this.tblVoucherPosting_colnAmount.Number, this.tblVoucherPosting_colnCurrencyDebetAmount, "ACCOUNTING_AMOUNT", ref this.nCalculatedTaxValue);
                bCalculateParallelCurrTax = true;
                // Bug 97225, End
                this.tblVoucherPosting_colnDebetAmount.EditDataItemSetEdited();
                // Bug Id 80619, Begin
                Sal.SendMsg(this.tblVoucherPosting_colnCreditAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, SalNumber.Null.ToString(0).ToHandle());
                if ((this.tblVoucherPosting_colsCurrencyCode.Text == this.sCurrCode) || (frmVoucherPosting.FromHandle(this.tblVoucherPosting_colnAmount.i_hWndFrame).IsEmu == "TRUE"))
                {
                    this.tblVoucherPosting_colnCurrencyDebetAmount.Number = this.tblVoucherPosting_colnDebetAmount.Number;
                    this.tblVoucherPosting_colnCurrencyDebetAmount.EditDataItemSetEdited();
                    this.tblVoucherPosting_colnCurrencyAmount.Number = this.tblVoucherPosting_colnDebetAmount.Number;
                    this.tblVoucherPosting_colnCurrencyAmount.EditDataItemSetEdited();
                    this.tblVoucherPosting_colnCurrencyCreditAmount.Number = Sys.NUMBER_Null;
                    this.tblVoucherPosting_colnCurrencyCreditAmount.EditDataItemSetEdited();
                    bCalculateParallelCurrTax = false;
                    this.SetTaxValue(this.tblVoucherPosting_colnCurrencyDebetAmount.Number, this.tblVoucherPosting_colnPrevCurrencyAmount.Number, this.tblVoucherPosting_colnCurrencyTaxAmount, this.sAmountMethodDb, "CURRENT_AMOUNT", this.nCalculatedTaxValue);
                    bCalculateParallelCurrTax = true;
                    if (this.tblVoucherPosting_colnCreditAmount.Number == Sys.NUMBER_Null)
                    {
                        this.tblVoucherPosting_colnCurrencyDebetAmount.Number = this.tblVoucherPosting_colnDebetAmount.Number;
                        this.tblVoucherPosting_colnCurrencyDebetAmount.EditDataItemSetEdited();
                        this.tblVoucherPosting_colnCurrencyAmount.Number = this.tblVoucherPosting_colnDebetAmount.Number;
                        this.tblVoucherPosting_colnCurrencyAmount.EditDataItemSetEdited();
                        this.tblVoucherPosting_colnCurrencyCreditAmount.Number = Sys.NUMBER_Null;
                        this.tblVoucherPosting_colnCurrencyCreditAmount.EditDataItemSetEdited();
                        bCalculateParallelCurrTax = false;
                        this.SetTaxValue(this.tblVoucherPosting_colnCurrencyDebetAmount.Number, this.tblVoucherPosting_colnPrevCurrencyAmount.Number, this.tblVoucherPosting_colnCurrencyTaxAmount, this.sAmountMethodDb, "CURRENT_AMOUNT", this.nCalculatedTaxValue);
                        bCalculateParallelCurrTax = true;
                    }
                    else
                    {
                        this.tblVoucherPosting_colnCurrencyCreditAmount.Number = this.tblVoucherPosting_colnCreditAmount.Number;
                        this.tblVoucherPosting_colnCurrencyCreditAmount.EditDataItemSetEdited();
                        this.tblVoucherPosting_colnCurrencyAmount.Number = -this.tblVoucherPosting_colnCreditAmount.Number;
                        this.tblVoucherPosting_colnCurrencyAmount.EditDataItemSetEdited();
                        this.tblVoucherPosting_colnCurrencyDebetAmount.Number = Sys.NUMBER_Null;
                        this.tblVoucherPosting_colnCurrencyDebetAmount.EditDataItemSetEdited();
                        bCalculateParallelCurrTax = false;
                        this.SetTaxValue(-this.tblVoucherPosting_colnCurrencyCreditAmount.Number, this.tblVoucherPosting_colnPrevCurrencyAmount.Number, this.tblVoucherPosting_colnCurrencyTaxAmount, this.sAmountMethodDb, "CURRENT_AMOUNT", this.nCalculatedTaxValue);
                        bCalculateParallelCurrTax = true;
                    }
                }

                if (this.i_sFinParallelBaseType != Sys.STRING_Null)
                    this.SetThirdCurrencyAmounts();
                // Bug Id 80619, End
            }
            else
            {
                bCalculateParallelCurrTax = false;
                this.tblVoucherPosting_colnCreditAmount.Number = -this.SetAnotherValue(this.tblVoucherPosting_colnAmount.Number, this.tblVoucherPosting_colnCurrencyCreditAmount, "ACCOUNTING_AMOUNT", ref this.nCalculatedTaxValue);
                bCalculateParallelCurrTax = true;
                this.tblVoucherPosting_colnCreditAmount.EditDataItemSetEdited();
                // Bug Id 80619, Begin
                Sal.SendMsg(this.tblVoucherPosting_colnDebetAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, SalNumber.Null.ToString(0).ToHandle());
                if ((this.tblVoucherPosting_colsCurrencyCode.Text == this.sCurrCode) || (frmVoucherPosting.FromHandle(this.tblVoucherPosting_colnAmount.i_hWndFrame).IsEmu == "TRUE"))
                {
                    this.tblVoucherPosting_colnCurrencyCreditAmount.Number = this.tblVoucherPosting_colnCreditAmount.Number;
                    this.tblVoucherPosting_colnCurrencyCreditAmount.EditDataItemSetEdited();
                    this.tblVoucherPosting_colnCurrencyAmount.Number = -this.tblVoucherPosting_colnCreditAmount.Number;
                    this.tblVoucherPosting_colnCurrencyAmount.EditDataItemSetEdited();
                    this.tblVoucherPosting_colnCurrencyDebetAmount.Number = Sys.NUMBER_Null;
                    this.tblVoucherPosting_colnCurrencyDebetAmount.EditDataItemSetEdited();
                    bCalculateParallelCurrTax = false;
                    this.SetTaxValue(-this.tblVoucherPosting_colnCurrencyCreditAmount.Number, this.tblVoucherPosting_colnPrevCurrencyAmount.Number, this.tblVoucherPosting_colnCurrencyTaxAmount, this.sAmountMethodDb, "CURRENT_AMOUNT", this.nCalculatedTaxValue);
                    bCalculateParallelCurrTax = true;
                }

                if (this.i_sFinParallelBaseType != Sys.STRING_Null)
                    this.SetThirdCurrencyAmounts();
                // Bug Id 80619, End
            }
            if (this.tblVoucherPosting_colnPrevAmount.Number != this.tblVoucherPosting_colnAmount.Number && this.tblVoucherPosting_colsManualAdded.Text == "TRUE")
            {
                this.tblVoucherPosting_colAddInternal.Text = "TRUE";
            }
            if (this.tblVoucherPosting_colnAmount.Number != Sys.NUMBER_Null)
            {
                this.tblVoucherPosting_colnPrevAmount.Number = this.tblVoucherPosting_colnAmount.Number;
            }
            if (this.tblVoucherPosting_colsCurrencyCode.Text != this.sCurrCode)
            {
                this.SetTaxValue(this.tblVoucherPosting_colnAmount.Number, this.tblVoucherPosting_colnPrevAmount.Number, this.tblVoucherPosting_colnTaxAmount, this.sAmountMethodDb, "ACCOUNTING_AMOUNT", this.nCalculatedTaxValue);
            }
            this.bAmtChanged = false;
            Sal.SetFieldEdit(this.tblVoucherPosting_colnAmount.i_hWndSelf, false);
            this.sCurrCode = Ifs.Fnd.ApplicationForms.Const.strNULL;
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblVoucherPosting_colnTaxAmount_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.tblVoucherPosting_colnTaxAmount_OnSAM_SetFocus(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.tblVoucherPosting_colnTaxAmount_OnPM_DataItemQueryEnabled(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblVoucherPosting_colnTaxAmount_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherPosting_colnTaxAmount_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.nPrevTaxAmount = this.tblVoucherPosting_colnTaxAmount.Number;
            e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherPosting_colnTaxAmount_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.IsNull(this.tblVoucherPosting_colsOptionalCode))
            {
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                return;
            }
            if (this.tblVoucherPosting_colsTaxType.Text == "NOTAX")
            {
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                return;
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherPosting_colnTaxAmount_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.ResetCurrTaxAmountFromTaxAmount(this.tblVoucherPosting_colnTaxAmount.Number, this.nPrevTaxAmount);
            if (!(Sal.IsNull(this.tblVoucherPosting_colsOptionalCode)))
            {
                if (this.tblVoucherPosting_colnTaxAmount.Number == Sys.NUMBER_Null && this.tblVoucherPosting_colsTaxType.Text != "NOTAX")
                {
                    this.tblVoucherPosting_colnTaxAmount.Number = this.nPrevTaxAmount;
                    Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_Vou_TaxAmountNull, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
                    e.Return = false;
                    return;
                }
                if (((this.tblVoucherPosting_colnTaxAmount.Number < 0 && this.tblVoucherPosting_colnCurrencyAmount.Number > 0) || (this.tblVoucherPosting_colnTaxAmount.Number > 0 && this.tblVoucherPosting_colnCurrencyAmount.Number < 0)) && this.tblVoucherPosting_colsTaxType.Text != "NOTAX")
                {
                    Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_Vou_TaxAmountSign, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
                    e.Return = false;
                    return;
                }
            }
            this.ResetBalance(this.tblVoucherPosting_colnTaxAmount.Number, this.nPrevTaxAmount);
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblVoucherPosting_colsTextId_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblVoucherPosting_colsTextId_OnPM_DataItemValidate(sender, e);
                    break;

                case Sys.SAM_AnyEdit:
                    this.tblVoucherPosting_colsTextId_OnSAM_AnyEdit(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherPosting_colsTextId_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (!(Sal.IsNull(this.tblVoucherPosting_colsTextId)) || (this.bEditedId == true))
            {
                if (!(DbPLSQLBlock(@"{0} := substr(&AO.Voucher_Text_API.Get_Description({1} IN, {2} IN ),1,200);",
                    this.tblVoucherPosting_colsText.QualifiedBindName,
                    this.tblVoucherPosting_colsCompany.QualifiedBindName,
                    this.tblVoucherPosting_colsTextId.QualifiedBindName )))
                {
                    e.Return = false;
                    return;
                }  
            }
            Sal.SetFieldEdit(this.tblVoucherPosting_colsTextId, false);
            Sal.SetFieldEdit(this.tblVoucherPosting_colsText, true);
            this.bEditedId = false;
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// SAM_AnyEdit event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherPosting_colsTextId_OnSAM_AnyEdit(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.IsNull(this.tblVoucherPosting_colsTextId))
            {
                this.bEditedId = true;
                Sal.SendClassMessage(Sys.SAM_AnyEdit, Sys.wParam, Sys.lParam);
            }
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblVoucherPosting_colnProjectActivityId_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.tblVoucherPosting_colnProjectActivityId_OnSAM_SetFocus(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovUserWhere:
                    this.tblVoucherPosting_colnProjectActivityId_OnPM_DataItemLovUserWhere(sender, e);
                    break;
            }
            #endregion
        }


        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherPosting_colnProjectActivityId_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if ((this.tblVoucherPosting_colnProjectActivityId.Number == Sys.NUMBER_Null) && (this.tblVoucherPosting_colsProjectActivityIdEnabled.Text == Sys.STRING_Null))
            {
                this.EnableSeqId();
            }
            if (Sal.IsNull(this.tblVoucherPosting_colnProjectActivityId) || this.tblVoucherPosting_colnProjectActivityId.Number == 0)
            {
                if ((this.tblVoucherPosting_colsProjectActivityIdEnabled.Text == "Y") && this.sProjectOriginGlobal != "FINPROJECT")
                {
                    if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsViewAvailable("PROJECT_ACTIVITY_POSTABLE")))
                    {
                        // Used this method as using Sal.SendMsg,Sal.PostMsg to send Tab key is not working properly in aurora client
                        System.Windows.Forms.SendKeys.Send("{TAB}");
                        return;
                    }
                    this.SetValueOfProjectID();
                    e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
                    return;
                }
                // Used this method as using Sal.SendMsg,Sal.PostMsg to send Tab key is not working properly in aurora client
                System.Windows.Forms.SendKeys.Send("{TAB}");
            }
            this.SetValueOfProjectID();
            e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        private void tblVoucherPosting_colnProjectActivityId_OnPM_DataItemLovUserWhere(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.sVouDate = SalString.FromHandle(Sal.SendMsg(this.i_hWndParent, Const.PAM_VoucherDateGet, 0, 0));
            e.Return = ("( TRUNC(EARLY_START) <=  TO_DATE(" + "'" + this.sVouDate + "'" + ", 'YYYY-MM-DD-HH24.MI.SS') AND TRUNC(EARLY_FINISH) >= TO_DATE(" + "'" + this.sVouDate + "'" + ", 'YYYY-MM-DD-HH24.MI.SS'))").ToHandle();
            return;
               
            #endregion
        }

        private void tblVoucherPosting_colnParallelCurrRateType_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovUserWhere:
                    this.tblVoucherPosting_colnParallelCurrRateType_OnPM_DataItemLovUserWhere(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblVoucherPosting_colnParallelCurrRateType_OnPM_DataItemValidate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.tblVoucherPosting_colnParallelCurrRateType_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }


        private void tblVoucherPosting_colnParallelCurrRateType_OnPM_DataItemLovUserWhere(object sender, WindowActionsEventArgs e)
        {
            #region Local Variables

            SalString sParallelCurrencyBaseType;
            SalString sBaseCurrencyCode;

            #endregion

            #region Actions
            e.Handled = true;


            sParallelCurrencyBaseType = this.i_sFinParallelBaseType;
            sBaseCurrencyCode = this.i_sFinBaseCurrencyCode;

            if (sParallelCurrencyBaseType == "TRANSACTION_CURRENCY")
            {
                e.Return = ((SalString)("RATE_TYPE_CATEGORY_DB = 'PARALLEL_CURRENCY'")).ToHandle();
            }
            if (sParallelCurrencyBaseType == "ACCOUNTING_CURRENCY")
            {
                e.Return = ((SalString)("REF_CURRENCY_CODE = '" + sBaseCurrencyCode + "'") + (SalString)(" AND RATE_TYPE_CATEGORY_DB != 'PROJECT'")).ToHandle();
            }

            return;
            #endregion
        }

        private void tblVoucherPosting_colnParallelCurrRateType_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Local Variables
            SalString ParallelCurrencyBaseType;
            #endregion

            #region Actions
            e.Handled = true;
            ParallelCurrencyBaseType = this.i_sFinParallelBaseType;

            if (!Sal.IsNull(tblVoucherPosting_colnParallelCurrRateType))
            {
                if (i_sFinParallelBaseType != Sys.STRING_Null)
                {
                    if (!GetParallelCurrencyRate())
                    {
                        e.Return = Sys.VALIDATE_Cancel;
                        return;
                    }
                    
                    this.tblVoucherPosting_colnParallelCurrRate.Number = nFinThirdCurrencyRate;
                    this.tblVoucherPosting_colnParallelCurrConvFactor.Number = nFinThirdConversionFactor;
                }              

                bCopyParallelCurrRate = false;
                SetThirdCurrencyAmounts();
                bCopyParallelCurrRate = true;
            }
            else
            {
                tblVoucherPosting_colnParallelCurrConvFactor.Text = Sys.STRING_Null;
                tblVoucherPosting_colnParallelCurrRate.Text = Sys.STRING_Null;

            }

            tblVoucherPosting_colnParallelCurrConvFactor.EditDataItemSetEdited();
            tblVoucherPosting_colnParallelCurrRate.EditDataItemSetEdited();
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }


        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherPosting_colnParallelCurrRateType_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;

            if (this.i_sFinThirdCurrencyCode == Ifs.Fnd.ApplicationForms.Const.strNULL)
            {
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                return;
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }


        private void tblVoucherPosting_colnParallelCurrRate_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblVoucherPosting_colnParallelCurrRate_OnPM_DataItemValidate(sender, e);
                    break;
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.tblVoucherPosting_colnParallelCurrRate_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion

        }

        private void tblVoucherPosting_colnParallelCurrRate_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Local Variables
            SalNumber nThirdCurrencyCurrencyAmount = 0;
            #endregion

            #region Actions
            e.Handled = true;

            this.i_nFinThirdCurrencyRate = this.tblVoucherPosting_colnParallelCurrRate.Number;
            if (this.i_sFinThirdCurrencyCode != Ifs.Fnd.ApplicationForms.Const.strNULL)
            {
                if (!(Sal.IsNull(tblVoucherPosting_colnDebetAmount)) && (tblVoucherPosting_colnDebetAmount.Number != 0))
                {

                    nAmount = tblVoucherPosting_colnDebetAmount.Number;
                    nCurrAmount = tblVoucherPosting_colnCurrencyDebetAmount.Number;

                    this.GetThirdCurrencyAmount(nAmount, nCurrAmount, ref nThirdCurrencyCurrencyAmount);
                    tblVoucherPosting_colnThirdCurrencyDebitAmount.Number = nThirdCurrencyCurrencyAmount;
                    tblVoucherPosting_colnThirdCurrencyAmount.Number = tblVoucherPosting_colnThirdCurrencyDebitAmount.Number;
                    tblVoucherPosting_colnThirdCurrencyDebitAmount.EditDataItemSetEdited();
                    tblVoucherPosting_colnThirdCurrencyCreditAmount.Number = Sys.NUMBER_Null;
                    // Bug 87017, Begin
                    tblVoucherPosting_colnThirdCurrencyCreditAmount.EditDataItemSetEdited();
                    // Bug 87017, End
                }
                else if (!(Sal.IsNull(tblVoucherPosting_colnCreditAmount)))
                {

                    nAmount = tblVoucherPosting_colnCreditAmount.Number;
                    nCurrAmount = tblVoucherPosting_colnCurrencyCreditAmount.Number;

                    this.GetThirdCurrencyAmount(nAmount, nCurrAmount, ref nThirdCurrencyCurrencyAmount);
                    tblVoucherPosting_colnThirdCurrencyCreditAmount.Number = nThirdCurrencyCurrencyAmount;
                    tblVoucherPosting_colnThirdCurrencyAmount.Number = -tblVoucherPosting_colnThirdCurrencyCreditAmount.Number;
                    tblVoucherPosting_colnThirdCurrencyCreditAmount.EditDataItemSetEdited();
                    tblVoucherPosting_colnThirdCurrencyDebitAmount.Number = Sys.NUMBER_Null;
                    // Bug 87017, Begin
                    tblVoucherPosting_colnThirdCurrencyDebitAmount.EditDataItemSetEdited();
                    // Bug 87017, End
                }
                bParallelCurrAmtChanged = true;
                bIsAutoBal = true;
                CalcualteParallelCurrTaxValue("RATE");
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherPosting_colnParallelCurrRate_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;

            if (this.tblVoucherPosting_colsCurrencyCode.Text == this.i_sFinThirdCurrencyCode)
            {
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                return;
            }
            if (this.i_sFinThirdCurrencyCode == Ifs.Fnd.ApplicationForms.Const.strNULL)
            {
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                return;
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }
        private void tblVoucherPosting_colnThirdCurrencyDebitAmount_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblVoucherPosting_colnThirdCurrencyDebitAmount_OnPM_DataItemValidate(sender, e);
                    break;
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.tblVoucherPosting_colnThirdCurrencyDebitAmount_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        private void tblVoucherPosting_colnThirdCurrencyDebitAmount_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Local Variables
            SalNumber nThirdCurrRate = 0;
            SalNumber nPosParallelCurrAmount = 0;
            SalNumber nTempDeductThirdCurrValue = 0;
            SalNumber nPosParallelCurrTaxAmount = 0;

            #endregion

            #region Actions
            e.Handled = true;
            if (this.tblVoucherPosting_colnThirdCurrencyDebitAmount.Number != Sys.NUMBER_Null)
            {

                if (this.tblVoucherPosting_colnThirdCurrencyDebitAmount.Number < 0)
                {
                    this.tblVoucherPosting_colnThirdCurrencyDebitAmount.Number = -this.tblVoucherPosting_colnThirdCurrencyDebitAmount.Number;
                }
                if (this.tblVoucherPosting_colCorrection.Text == "Y")
                {
                    this.tblVoucherPosting_colnThirdCurrencyDebitAmount.Number = -this.tblVoucherPosting_colnThirdCurrencyDebitAmount.Number;
                }
                if (tblVoucherPosting_colsOptionalCode.Text != Sys.STRING_Null && (this.tblVoucherPosting_colsCurrencyCode.Text != this.i_sFinThirdCurrencyCode))
                {
                    if (nDeduct == SalNumber.Null)
                    {
                        nDeduct = 100;
                        bIsAutoBal = false;
                    }
                    else
                    {
                        bIsAutoBal = true;
                    }
                    bParallelCurrAmtChanged = true;
                    tblVoucherPosting_colnThirdCurrencyAmount.Number = tblVoucherPosting_colnThirdCurrencyDebitAmount.Number;
                    if ((tblVoucherPosting_colnCurrencyAmount.Number == Sys.NUMBER_Null || tblVoucherPosting_colnCurrencyAmount.Number == 0 && (this.i_sFinParallelBaseType == "TRANSACTION_CURRENCY")) ||
                        (tblVoucherPosting_colnAmount.Number == Sys.NUMBER_Null || tblVoucherPosting_colnAmount.Number == 0 && (this.i_sFinParallelBaseType == "ACCOUNTING_CURRENCY")))
                    {
                        CalcualteParallelCurrTaxValue("AMOUNT");
                    }
                    else
                    {
                        CalcualteParallelCurrTaxValue("RATE");
                    }
                    bParallelCurrAmtChanged = false;
                    bIsAutoBal = false;
                    if (!(nDeductThirdCurrValue == SalNumber.Null || nDeductThirdCurrValue == 0))
                    {
                        tblVoucherPosting_colnThirdCurrencyDebitAmount.Number = tblVoucherPosting_colnThirdCurrencyDebitAmount.Number + nDeductThirdCurrValue;
                        tblVoucherPosting_colnThirdCurrencyDebitAmount.EditDataItemSetEdited();
                        nTempDeductThirdCurrValue = nDeductThirdCurrValue;
                        nDeductThirdCurrValue = 0;
                    }
                }
                if ((!Sal.IsNull(tblVoucherPosting_colnCurrencyAmount) && tblVoucherPosting_colnCurrencyAmount.Number != 0 && this.i_sFinParallelBaseType == "TRANSACTION_CURRENCY") || (!Sal.IsNull(tblVoucherPosting_colnAmount) && tblVoucherPosting_colnAmount.Number != 0 && this.i_sFinParallelBaseType == "ACCOUNTING_CURRENCY"))
                {
                    if (tblVoucherPosting_colnThirdCurrencyDebitAmount.Number > 0)
                    {
                        if (this.tblVoucherPosting_colsCurrencyCode.Text != this.i_sFinThirdCurrencyCode)
                        {
                            this.CalcualteParallelCurrencyRate(tblVoucherPosting_colnAmount.Number, tblVoucherPosting_colnCurrencyAmount.Number, tblVoucherPosting_colnThirdCurrencyDebitAmount.Number, ref nThirdCurrRate);
                        }
                        tblVoucherPosting_colnParallelCurrRate.Number = nThirdCurrRate;
                        tblVoucherPosting_colnParallelCurrRate.EditDataItemSetEdited();
                    }
                    else if (tblVoucherPosting_colnThirdCurrencyDebitAmount.Number == 0)
                    {
                        tblVoucherPosting_colnParallelCurrRate.Number = 0;
                        tblVoucherPosting_colnParallelCurrRate.EditDataItemSetEdited();
                    }
                }
                tblVoucherPosting_colnThirdCurrencyAmount.Number = tblVoucherPosting_colnThirdCurrencyDebitAmount.Number;
                tblVoucherPosting_colnThirdCurrencyAmount.EditDataItemSetEdited();
                nPosParallelCurrAmount = Sal.TblQueryColumnID(tblVoucherPosting_colnThirdCurrencyAmount);

                if (tblVoucherPosting_colsOptionalCode.Text != Sys.STRING_Null)
                {
                    if ((tblVoucherPosting_colnCurrencyAmount.Number == Sys.NUMBER_Null || tblVoucherPosting_colnCurrencyAmount.Number == 0 && (this.i_sFinParallelBaseType == "TRANSACTION_CURRENCY")) ||
                        (tblVoucherPosting_colnAmount.Number == Sys.NUMBER_Null || tblVoucherPosting_colnAmount.Number == 0 && (this.i_sFinParallelBaseType == "ACCOUNTING_CURRENCY")))
                    {
                        CalcualteParallelCurrTaxValue("AMOUNT");
                    }
                    else
                    {
                        CalcualteParallelCurrTaxValue("RATE");
                    }
                }

                if (sAmountMethodDb == "NET")
                {
                    nPosParallelCurrTaxAmount = Sal.TblQueryColumnID(tblVoucherPosting_colnParallelCurrTaxAmount);
                    this.dfnParallelCurrBalance.Number = Sal.TblColumnSum(tblVoucherPosting, nPosParallelCurrAmount, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1)) + Sal.TblColumnSum(tblVoucherPosting, nPosParallelCurrTaxAmount, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1));
                }
                else if (sAmountMethodDb == "GROSS")
                {
                    this.dfnParallelCurrBalance.Number = Sal.TblColumnSum(tblVoucherPosting, nPosParallelCurrAmount, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1));
                }

            }
            else
            {
                if (this.tblVoucherPosting_colnThirdCurrencyCreditAmount.Number == Sys.NUMBER_Null)
                {
                    tblVoucherPosting_colnThirdCurrencyAmount.Number = 0;
                    tblVoucherPosting_colnThirdCurrencyAmount.EditDataItemSetEdited();
                    tblVoucherPosting_colnParallelCurrTaxAmount.Number = 0;
                    tblVoucherPosting_colnParallelCurrTaxAmount.EditDataItemSetEdited();
                    tblVoucherPosting_colnParallelCurrRate.Number = 0;
                    tblVoucherPosting_colnParallelCurrRate.EditDataItemSetEdited();
                    nPosParallelCurrAmount = Sal.TblQueryColumnID(tblVoucherPosting_colnThirdCurrencyAmount);
                    if (sAmountMethodDb == "NET")
                    {
                        nPosParallelCurrTaxAmount = Sal.TblQueryColumnID(tblVoucherPosting_colnParallelCurrTaxAmount);
                        this.dfnParallelCurrBalance.Number = Sal.TblColumnSum(tblVoucherPosting, nPosParallelCurrAmount, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1)) + Sal.TblColumnSum(tblVoucherPosting, nPosParallelCurrTaxAmount, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1));
                    }
                    else if (sAmountMethodDb == "GROSS")
                    {
                        this.dfnParallelCurrBalance.Number = Sal.TblColumnSum(tblVoucherPosting, nPosParallelCurrAmount, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1));
                    }
                }
            }

            if (this.tblVoucherPosting_colsCurrencyCode.Text == this.i_sFinThirdCurrencyCode)
            {
                Sal.SendMsg(this.tblVoucherPosting_colnThirdCurrencyAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
            }

            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherPosting_colnThirdCurrencyDebitAmount_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (!(Sal.IsNull(this.tblVoucherPosting_colnThirdCurrencyCreditAmount)))
            {
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                return;
            }

            if (this.i_sFinThirdCurrencyCode == Ifs.Fnd.ApplicationForms.Const.strNULL)
            {
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                return;
            }

            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        private void tblVoucherPosting_colnThirdCurrencyCreditAmount_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblVoucherPosting_colnThirdCurrencyCreditAmount_OnPM_DataItemValidate(sender, e);
                    break;
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.tblVoucherPosting_colnThirdCurrencyCreditAmount_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        private void tblVoucherPosting_colnThirdCurrencyCreditAmount_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Local Variables
            SalNumber nThirdCurrRate = 0;
            SalNumber nPosParallelCurrAmount = 0;

            SalNumber nPosParallelCurrTaxAmount = 0;

            #endregion

            #region Actions
            e.Handled = true;
            if (this.tblVoucherPosting_colnThirdCurrencyCreditAmount.Number != Sys.NUMBER_Null)
            {
                if (this.tblVoucherPosting_colnThirdCurrencyCreditAmount.Number < 0)
                {
                    this.tblVoucherPosting_colnThirdCurrencyCreditAmount.Number = -this.tblVoucherPosting_colnThirdCurrencyCreditAmount.Number;
                }
                if (this.tblVoucherPosting_colCorrection.Text == "Y")
                {
                    this.tblVoucherPosting_colnThirdCurrencyCreditAmount.Number = -this.tblVoucherPosting_colnThirdCurrencyCreditAmount.Number;
                }
                if (tblVoucherPosting_colsOptionalCode.Text != Sys.STRING_Null)
                {
                    if (nDeduct == SalNumber.Null)
                    {
                        nDeduct = 100;
                        bIsAutoBal = false;
                    }
                    else
                    {
                        bIsAutoBal = true;
                    }
                    bParallelCurrAmtChanged = true;
                    tblVoucherPosting_colnThirdCurrencyAmount.Number = tblVoucherPosting_colnThirdCurrencyCreditAmount.Number;
                    if ((tblVoucherPosting_colnCurrencyAmount.Number == Sys.NUMBER_Null || tblVoucherPosting_colnCurrencyAmount.Number == 0 && (this.i_sFinParallelBaseType == "TRANSACTION_CURRENCY")) ||
                        (tblVoucherPosting_colnAmount.Number == Sys.NUMBER_Null || tblVoucherPosting_colnAmount.Number == 0 && (this.i_sFinParallelBaseType == "ACCOUNTING_CURRENCY")))
                    {
                        CalcualteParallelCurrTaxValue("AMOUNT");
                    }
                    else
                    {
                        CalcualteParallelCurrTaxValue("RATE");
                    }
                    bParallelCurrAmtChanged = false;
                    bIsAutoBal = false;
                    if (!(nDeductThirdCurrValue == SalNumber.Null || nDeductThirdCurrValue == 0))
                    {
                        tblVoucherPosting_colnThirdCurrencyCreditAmount.Number = tblVoucherPosting_colnThirdCurrencyCreditAmount.Number + nDeductThirdCurrValue;
                        tblVoucherPosting_colnThirdCurrencyCreditAmount.EditDataItemSetEdited();
                        nDeductThirdCurrValue = 0;
                    }
                }
                if ((!Sal.IsNull(tblVoucherPosting_colnCurrencyAmount) && tblVoucherPosting_colnCurrencyAmount.Number != 0 && this.i_sFinParallelBaseType == "TRANSACTION_CURRENCY") || (!Sal.IsNull(tblVoucherPosting_colnAmount) && tblVoucherPosting_colnAmount.Number != 0 && this.i_sFinParallelBaseType == "ACCOUNTING_CURRENCY"))
                {
                    if (tblVoucherPosting_colnThirdCurrencyCreditAmount.Number > 0)
                    {
                        if (this.tblVoucherPosting_colsCurrencyCode.Text != this.i_sFinThirdCurrencyCode)
                        {
                            this.CalcualteParallelCurrencyRate(tblVoucherPosting_colnCreditAmount.Number, tblVoucherPosting_colnCurrencyCreditAmount.Number, tblVoucherPosting_colnThirdCurrencyCreditAmount.Number, ref nThirdCurrRate);
                        }
                        tblVoucherPosting_colnParallelCurrRate.Number = nThirdCurrRate;
                        tblVoucherPosting_colnParallelCurrRate.EditDataItemSetEdited();
                    }
                    else if (tblVoucherPosting_colnThirdCurrencyCreditAmount.Number == 0)
                    {
                        tblVoucherPosting_colnParallelCurrRate.Number = 0;
                        tblVoucherPosting_colnParallelCurrRate.EditDataItemSetEdited();
                    }
                }

                tblVoucherPosting_colnThirdCurrencyAmount.Number = -tblVoucherPosting_colnThirdCurrencyCreditAmount.Number;
                tblVoucherPosting_colnThirdCurrencyAmount.EditDataItemSetEdited();
                nPosParallelCurrAmount = Sal.TblQueryColumnID(tblVoucherPosting_colnThirdCurrencyAmount);

                if (tblVoucherPosting_colsOptionalCode.Text != Sys.STRING_Null)
                {
                    if ((tblVoucherPosting_colnCurrencyAmount.Number == Sys.NUMBER_Null || tblVoucherPosting_colnCurrencyAmount.Number == 0 && (this.i_sFinParallelBaseType == "TRANSACTION_CURRENCY")) ||
                        (tblVoucherPosting_colnAmount.Number == Sys.NUMBER_Null || tblVoucherPosting_colnAmount.Number == 0 && (this.i_sFinParallelBaseType == "ACCOUNTING_CURRENCY")))
                    {
                        CalcualteParallelCurrTaxValue("AMOUNT");
                    }
                    else
                    {
                        CalcualteParallelCurrTaxValue("RATE");
                    }
                }

                if (sAmountMethodDb == "NET")
                {
                    nPosParallelCurrTaxAmount = Sal.TblQueryColumnID(tblVoucherPosting_colnParallelCurrTaxAmount);
                    this.dfnParallelCurrBalance.Number = Sal.TblColumnSum(tblVoucherPosting, nPosParallelCurrAmount, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1)) + Sal.TblColumnSum(tblVoucherPosting, nPosParallelCurrTaxAmount, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1));
                }
                else if (sAmountMethodDb == "GROSS")
                {
                    this.dfnParallelCurrBalance.Number = Sal.TblColumnSum(tblVoucherPosting, nPosParallelCurrAmount, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1));
                }

            }
            else
            {
                if (this.tblVoucherPosting_colnThirdCurrencyDebitAmount.Number == Sys.NUMBER_Null)
                {
                    tblVoucherPosting_colnThirdCurrencyAmount.Number = 0;
                    tblVoucherPosting_colnThirdCurrencyAmount.EditDataItemSetEdited();
                    tblVoucherPosting_colnParallelCurrTaxAmount.Number = 0;
                    tblVoucherPosting_colnParallelCurrTaxAmount.EditDataItemSetEdited();
                    tblVoucherPosting_colnParallelCurrRate.Number = 0;
                    tblVoucherPosting_colnParallelCurrRate.EditDataItemSetEdited();
                    nPosParallelCurrAmount = Sal.TblQueryColumnID(tblVoucherPosting_colnThirdCurrencyAmount);
                    if (sAmountMethodDb == "NET")
                    {
                        nPosParallelCurrTaxAmount = Sal.TblQueryColumnID(tblVoucherPosting_colnParallelCurrTaxAmount);
                        this.dfnParallelCurrBalance.Number = Sal.TblColumnSum(tblVoucherPosting, nPosParallelCurrAmount, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1)) + Sal.TblColumnSum(tblVoucherPosting, nPosParallelCurrTaxAmount, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1));
                    }
                    else if (sAmountMethodDb == "GROSS")
                    {
                        this.dfnParallelCurrBalance.Number = Sal.TblColumnSum(tblVoucherPosting, nPosParallelCurrAmount, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1));
                    }
                }
            }

            if (this.tblVoucherPosting_colsCurrencyCode.Text == this.i_sFinThirdCurrencyCode)
            {
                Sal.SendMsg(this.tblVoucherPosting_colnThirdCurrencyAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
            }
            
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherPosting_colnThirdCurrencyCreditAmount_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (!(Sal.IsNull(this.tblVoucherPosting_colnThirdCurrencyDebitAmount)))
            {
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                return;
            }

            if (this.i_sFinThirdCurrencyCode == Ifs.Fnd.ApplicationForms.Const.strNULL)
            {
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                return;
            }

            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        private void tblVoucherPosting_colnThirdCurrencyAmount_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblVoucherPosting_colnThirdCurrencyAmount_OnPM_DataItemValidate(sender, e);
                    break;
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.tblVoucherPosting_colnThirdCurrencyAmount_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        private void tblVoucherPosting_colnThirdCurrencyAmount_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Local Variables
            SalNumber nThirdCurrRate = 0;
            SalNumber nPosParallelCurrAmount = 0;

            SalNumber nPosParallelCurrTaxAmount = 0;
            SalNumber nDummyAmount = 0;

            #endregion

            #region Actions
            e.Handled = true;
            if (tblVoucherPosting_colsOptionalCode.Text != Sys.STRING_Null)
            {
                if (nDeduct == SalNumber.Null)
                {
                    nDeduct = 100;
                    bIsAutoBal = false;
                }
                else
                {
                    bIsAutoBal = true;
                }
                bParallelCurrAmtChanged = true;
                if ((tblVoucherPosting_colnCurrencyAmount.Number == Sys.NUMBER_Null || tblVoucherPosting_colnCurrencyAmount.Number == 0 && (this.i_sFinParallelBaseType == "TRANSACTION_CURRENCY")) ||
                    (tblVoucherPosting_colnAmount.Number == Sys.NUMBER_Null || tblVoucherPosting_colnAmount.Number == 0 && (this.i_sFinParallelBaseType == "ACCOUNTING_CURRENCY"))
                    || (this.tblVoucherPosting_colsCurrencyCode.Text == this.i_sFinThirdCurrencyCode))
                {
                    CalcualteParallelCurrTaxValue("AMOUNT");
                }
                else
                {
                    CalcualteParallelCurrTaxValue("RATE");
                }
                bParallelCurrAmtChanged = false;
                bIsAutoBal = false;
                if (!(nDeductThirdCurrValue == SalNumber.Null || nDeductThirdCurrValue == 0))
                {
                    tblVoucherPosting_colnThirdCurrencyAmount.Number = tblVoucherPosting_colnThirdCurrencyAmount.Number + nDeductThirdCurrValue;
                    tblVoucherPosting_colnThirdCurrencyAmount.EditDataItemSetEdited();
                    nDeductThirdCurrValue = 0;
                }
            }
            if (this.tblVoucherPosting_colnThirdCurrencyAmount.Number < 0 && this.tblVoucherPosting_colCorrection.Text == "Y")
            {
                if (this.tblVoucherPosting_colnThirdCurrencyDebitAmount.Number != Sys.NUMBER_Null)
                {
                    tblVoucherPosting_colnThirdCurrencyDebitAmount.Number = -tblVoucherPosting_colnThirdCurrencyAmount.Number;
                    tblVoucherPosting_colnThirdCurrencyDebitAmount.EditDataItemSetEdited();
                }
                else
                {
                    tblVoucherPosting_colnThirdCurrencyCreditAmount.Number = tblVoucherPosting_colnThirdCurrencyAmount.Number;
                    tblVoucherPosting_colnThirdCurrencyCreditAmount.EditDataItemSetEdited();
                }
            }
            else if (this.tblVoucherPosting_colnThirdCurrencyAmount.Number < 0 && this.tblVoucherPosting_colCorrection.Text == "N")
            {
                if (this.tblVoucherPosting_colnThirdCurrencyDebitAmount.Number != Sys.NUMBER_Null)
                {
                    tblVoucherPosting_colnThirdCurrencyCreditAmount.Number = -tblVoucherPosting_colnThirdCurrencyAmount.Number;
                    tblVoucherPosting_colnThirdCurrencyCreditAmount.EditDataItemSetEdited();
                    tblVoucherPosting_colnThirdCurrencyDebitAmount.Number = Sys.NUMBER_Null;
                    tblVoucherPosting_colnThirdCurrencyDebitAmount.EditDataItemSetEdited();
                }
                else
                {
                    tblVoucherPosting_colnThirdCurrencyCreditAmount.Number = -tblVoucherPosting_colnThirdCurrencyAmount.Number;
                    tblVoucherPosting_colnThirdCurrencyCreditAmount.EditDataItemSetEdited();
                }

            }
            else if (this.tblVoucherPosting_colnThirdCurrencyAmount.Number > 0 && this.tblVoucherPosting_colCorrection.Text == "Y")
            {
                tblVoucherPosting_colnThirdCurrencyCreditAmount.Number  = -tblVoucherPosting_colnThirdCurrencyAmount.Number;
                tblVoucherPosting_colnThirdCurrencyDebitAmount.Number = Sys.NUMBER_Null;
                tblVoucherPosting_colnThirdCurrencyDebitAmount.EditDataItemSetEdited();
                tblVoucherPosting_colnThirdCurrencyCreditAmount.EditDataItemSetEdited();
            }
            else if (this.tblVoucherPosting_colnThirdCurrencyAmount.Number > 0 && this.tblVoucherPosting_colCorrection.Text == "N")
            {
                tblVoucherPosting_colnThirdCurrencyDebitAmount.Number = tblVoucherPosting_colnThirdCurrencyAmount.Number;
                tblVoucherPosting_colnThirdCurrencyCreditAmount.Number = Sys.NUMBER_Null;
                tblVoucherPosting_colnThirdCurrencyCreditAmount.EditDataItemSetEdited();
                tblVoucherPosting_colnThirdCurrencyDebitAmount.EditDataItemSetEdited();
            }
            else if (this.tblVoucherPosting_colnThirdCurrencyAmount.Number == 0)
            {
                tblVoucherPosting_colnThirdCurrencyDebitAmount.Number = 0;
                tblVoucherPosting_colnThirdCurrencyCreditAmount.Number = Sys.NUMBER_Null;
                tblVoucherPosting_colnThirdCurrencyCreditAmount.EditDataItemSetEdited();
                tblVoucherPosting_colnThirdCurrencyDebitAmount.EditDataItemSetEdited();
            }

            if ((!Sal.IsNull(tblVoucherPosting_colnCurrencyAmount) && tblVoucherPosting_colnCurrencyAmount.Number != 0 && this.i_sFinParallelBaseType == "TRANSACTION_CURRENCY" && Sys.wParam == 1) || (!Sal.IsNull(tblVoucherPosting_colnAmount) && tblVoucherPosting_colnAmount.Number != 0 && this.i_sFinParallelBaseType == "ACCOUNTING_CURRENCY" && Sys.wParam == 1))
            {
                if (tblVoucherPosting_colnThirdCurrencyAmount.Number != 0 && tblVoucherPosting_colnThirdCurrencyAmount.Number != Sys.NUMBER_Null)
                {
                    if (this.tblVoucherPosting_colsCurrencyCode.Text != this.i_sFinThirdCurrencyCode)
                    {
                        this.CalcualteParallelCurrencyRate(tblVoucherPosting_colnAmount.Number, tblVoucherPosting_colnCurrencyAmount.Number, tblVoucherPosting_colnThirdCurrencyAmount.Number, ref nThirdCurrRate);
                    }
                    tblVoucherPosting_colnParallelCurrRate.Number = nThirdCurrRate;
                    tblVoucherPosting_colnParallelCurrRate.EditDataItemSetEdited();
                }
                else if (tblVoucherPosting_colnThirdCurrencyAmount.Number == 0 || tblVoucherPosting_colnThirdCurrencyAmount.Number == Sys.NUMBER_Null)
                {
                    tblVoucherPosting_colnParallelCurrRate.Number = 0;
                    tblVoucherPosting_colnParallelCurrRate.EditDataItemSetEdited();
                }
            }

            if (tblVoucherPosting_colsOptionalCode.Text != Sys.STRING_Null && (this.tblVoucherPosting_colsCurrencyCode.Text != this.i_sFinThirdCurrencyCode))
            {
                if (nDeduct == SalNumber.Null)
                {
                    nDeduct = 100;
                    bIsAutoBal = false;
                }
                else
                {
                    bIsAutoBal = true;
                }
                if ((tblVoucherPosting_colnCurrencyAmount.Number == Sys.NUMBER_Null || tblVoucherPosting_colnCurrencyAmount.Number == 0 && (this.i_sFinParallelBaseType == "TRANSACTION_CURRENCY")) ||
                    (tblVoucherPosting_colnAmount.Number == Sys.NUMBER_Null || tblVoucherPosting_colnAmount.Number == 0 && (this.i_sFinParallelBaseType == "ACCOUNTING_CURRENCY")))
                {
                    CalcualteParallelCurrTaxValue("AMOUNT");
                }
                else
                {
                    CalcualteParallelCurrTaxValue("RATE");
                }
            }

            bCalculateParallelCurrTax = false;
            if ((this.tblVoucherPosting_colnThirdCurrencyAmount.Number < 0 && this.tblVoucherPosting_colCorrection.Text == "Y") || (this.tblVoucherPosting_colnThirdCurrencyAmount.Number >= 0 && this.tblVoucherPosting_colCorrection.Text == "N"))
            {
                if (this.tblVoucherPosting_colsCurrencyCode.Text == this.i_sFinThirdCurrencyCode)
                {
                    this.tblVoucherPosting_colnCurrencyDebetAmount.Number = this.tblVoucherPosting_colnThirdCurrencyDebitAmount.Number;
                    this.tblVoucherPosting_colnCurrencyDebetAmount.EditDataItemSetEdited();
                    this.tblVoucherPosting_colnCurrencyAmount.Number = this.tblVoucherPosting_colnThirdCurrencyAmount.Number;
                    this.tblVoucherPosting_colnCurrencyAmount.EditDataItemSetEdited();

                    this.tblVoucherPosting_colnCurrencyCreditAmount.Number = Sys.NUMBER_Null;
                    this.tblVoucherPosting_colnCurrencyCreditAmount.EditDataItemSetEdited();
                    this.SetTaxValue(this.tblVoucherPosting_colnCurrencyDebetAmount.Number, this.tblVoucherPosting_colnPrevCurrencyAmount.Number, this.tblVoucherPosting_colnCurrencyTaxAmount, this.sAmountMethodDb, "CURRENT_AMOUNT", this.tblVoucherPosting_colnParallelCurrTaxAmount.Number);
                    if (this.tblVoucherPosting_colnThirdCurrencyCreditAmount.Number == Sys.NUMBER_Null)
                    {
                        this.tblVoucherPosting_colnCurrencyDebetAmount.Number = this.tblVoucherPosting_colnThirdCurrencyDebitAmount.Number;
                        this.tblVoucherPosting_colnCurrencyDebetAmount.EditDataItemSetEdited();
                        this.tblVoucherPosting_colnCurrencyAmount.Number = this.tblVoucherPosting_colnThirdCurrencyDebitAmount.Number;
                        this.tblVoucherPosting_colnCurrencyAmount.EditDataItemSetEdited();
                        this.tblVoucherPosting_colnCurrencyCreditAmount.Number = Sys.NUMBER_Null;
                        this.tblVoucherPosting_colnCurrencyCreditAmount.EditDataItemSetEdited();
                        this.SetTaxValue(this.tblVoucherPosting_colnCurrencyDebetAmount.Number, this.tblVoucherPosting_colnPrevCurrencyAmount.Number, this.tblVoucherPosting_colnCurrencyTaxAmount, this.sAmountMethodDb, "CURRENT_AMOUNT", this.tblVoucherPosting_colnParallelCurrTaxAmount.Number);
                        sCalculateTax = "FALSE";
                        nDummyAmount = SetAnotherValue(tblVoucherPosting_colnThirdCurrencyAmount.Number, tblVoucherPosting_colnDebetAmount, "CURRENT_AMOUNT", ref nCalculatedTaxValue);
                        sCalculateTax = Ifs.Fnd.ApplicationForms.Const.strNULL;
                    }
                    else
                    {
                        this.tblVoucherPosting_colnCurrencyCreditAmount.Number = this.tblVoucherPosting_colnThirdCurrencyCreditAmount.Number;
                        this.tblVoucherPosting_colnCurrencyCreditAmount.EditDataItemSetEdited();
                        this.tblVoucherPosting_colnCurrencyAmount.Number = -this.tblVoucherPosting_colnThirdCurrencyCreditAmount.Number;
                        this.tblVoucherPosting_colnCurrencyAmount.EditDataItemSetEdited();
                        this.tblVoucherPosting_colnCurrencyDebetAmount.Number = Sys.NUMBER_Null;
                        this.tblVoucherPosting_colnCurrencyDebetAmount.EditDataItemSetEdited();
                        this.SetTaxValue(-this.tblVoucherPosting_colnCurrencyCreditAmount.Number, this.tblVoucherPosting_colnPrevCurrencyAmount.Number, this.tblVoucherPosting_colnCurrencyTaxAmount, this.sAmountMethodDb, "CURRENT_AMOUNT", this.tblVoucherPosting_colnParallelCurrTaxAmount.Number);
                        sCalculateTax = "FALSE";
                        nDummyAmount = -SetAnotherValue(tblVoucherPosting_colnThirdCurrencyAmount.Number, tblVoucherPosting_colnCreditAmount, "CURRENT_AMOUNT", ref nCalculatedTaxValue);
                        sCalculateTax = Ifs.Fnd.ApplicationForms.Const.strNULL;
                    }
                    if (tblVoucherPosting_colnThirdCurrencyAmount.Number != 0 && tblVoucherPosting_colnThirdCurrencyAmount.Number != Sys.NUMBER_Null && ((tblVoucherPosting_colnCurrencyAmount.Number != 0 && this.i_sFinParallelBaseType == "TRANSACTION_CURRENCY") || (tblVoucherPosting_colnAmount.Number != 0 && this.i_sFinParallelBaseType == "ACCOUNTING_CURRENCY")))
                    {
                        this.CalcualteParallelCurrencyRate(tblVoucherPosting_colnAmount.Number, tblVoucherPosting_colnCurrencyAmount.Number, tblVoucherPosting_colnThirdCurrencyAmount.Number.Abs(), ref nThirdCurrRate);
                        tblVoucherPosting_colnParallelCurrRate.Number = nThirdCurrRate;
                        tblVoucherPosting_colnParallelCurrRate.EditDataItemSetEdited();
                    }
                }
            }
            else
            {
                if (this.tblVoucherPosting_colsCurrencyCode.Text == this.i_sFinThirdCurrencyCode)
                {
                    this.tblVoucherPosting_colnCurrencyCreditAmount.Number = this.tblVoucherPosting_colnThirdCurrencyCreditAmount.Number;
                    this.tblVoucherPosting_colnCurrencyCreditAmount.EditDataItemSetEdited();
                    this.tblVoucherPosting_colnCurrencyAmount.Number = this.tblVoucherPosting_colnThirdCurrencyAmount.Number;
                    this.tblVoucherPosting_colnCurrencyAmount.EditDataItemSetEdited();
                    this.tblVoucherPosting_colnCurrencyDebetAmount.Number = Sys.NUMBER_Null;
                    this.tblVoucherPosting_colnCurrencyDebetAmount.EditDataItemSetEdited();
                    this.SetTaxValue(-this.tblVoucherPosting_colnCurrencyCreditAmount.Number, this.tblVoucherPosting_colnPrevCurrencyAmount.Number, this.tblVoucherPosting_colnCurrencyTaxAmount, this.sAmountMethodDb, "CURRENT_AMOUNT", this.tblVoucherPosting_colnParallelCurrTaxAmount.Number);
                    sCalculateTax = "FALSE";
                    nDummyAmount = SetAnotherValue(tblVoucherPosting_colnThirdCurrencyAmount.Number, tblVoucherPosting_colnCreditAmount, "CURRENT_AMOUNT", ref nCalculatedTaxValue);
                    sCalculateTax = Ifs.Fnd.ApplicationForms.Const.strNULL;
                    if (tblVoucherPosting_colnThirdCurrencyAmount.Number != 0 && tblVoucherPosting_colnThirdCurrencyAmount.Number != Sys.NUMBER_Null && ((tblVoucherPosting_colnCurrencyAmount.Number != 0 && this.i_sFinParallelBaseType == "TRANSACTION_CURRENCY") || (tblVoucherPosting_colnAmount.Number != 0 && this.i_sFinParallelBaseType == "ACCOUNTING_CURRENCY")))
                    {
                        this.CalcualteParallelCurrencyRate(tblVoucherPosting_colnAmount.Number, tblVoucherPosting_colnCurrencyAmount.Number, tblVoucherPosting_colnThirdCurrencyAmount.Number, ref nThirdCurrRate);
                        tblVoucherPosting_colnParallelCurrRate.Number = nThirdCurrRate;
                        tblVoucherPosting_colnParallelCurrRate.EditDataItemSetEdited();
                    }
                }
            }
            bCalculateParallelCurrTax = true;

            if (this.tblVoucherPosting_colnThirdCurrencyAmount.Number == Sys.NUMBER_Null)
            {
                tblVoucherPosting_colnParallelCurrTaxAmount.Number = 0;
                tblVoucherPosting_colnParallelCurrTaxAmount.EditDataItemSetEdited();
            }

            nPosParallelCurrAmount = Sal.TblQueryColumnID(tblVoucherPosting_colnThirdCurrencyAmount);

            if (sAmountMethodDb == "NET")
            {
                nPosParallelCurrTaxAmount = Sal.TblQueryColumnID(tblVoucherPosting_colnParallelCurrTaxAmount);
                this.dfnParallelCurrBalance.Number = Sal.TblColumnSum(tblVoucherPosting, nPosParallelCurrAmount, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1)) + Sal.TblColumnSum(tblVoucherPosting, nPosParallelCurrTaxAmount, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1));
            }
            else if (sAmountMethodDb == "GROSS")
            {
                this.dfnParallelCurrBalance.Number = Sal.TblColumnSum(tblVoucherPosting, nPosParallelCurrAmount, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1));
            }

            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherPosting_colnThirdCurrencyAmount_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.i_sFinThirdCurrencyCode == Ifs.Fnd.ApplicationForms.Const.strNULL)
            {
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                return;
            }

            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        private void tblVoucherPosting_colnParallelCurrTaxAmount_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblVoucherPosting_colnParallelCurrTaxAmount_OnPM_DataItemValidate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.tblVoucherPosting_colnParallelCurrTaxAmount_OnPM_DataItemQueryEnabled(sender, e);
                    break;


            }
            #endregion
        }

        private void tblVoucherPosting_colnParallelCurrTaxAmount_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Local Variables

            SalNumber nPosCurrAmount = 0;
            SalNumber nPosAmount = 0;
            SalNumber nPosParallelCurrAmount = 0;
            SalNumber nPosCurrTaxAmount = 0;
            SalNumber nPosTaxAmount = 0;
            SalNumber nPosParallelTaxAmnt = 0;

            #endregion

            #region Actions
            e.Handled = true;

            if (this.tblVoucherPosting_colsCurrencyCode.Text == this.i_sFinThirdCurrencyCode)
            {
                this.tblVoucherPosting_colnCurrencyTaxAmount.Number = this.tblVoucherPosting_colnParallelCurrTaxAmount.Number;
                this.tblVoucherPosting_colnCurrencyTaxAmount.EditDataItemSetEdited();

                this.ResetTaxAmountFromCurrTaxAmount(this.tblVoucherPosting_colnCurrencyTaxAmount.Number, this.nPrevCurrencyTaxAmount);
            }

            if (sAmountMethodDb == "NET")
            {
                nPosCurrAmount = Sal.TblQueryColumnID(tblVoucherPosting_colnCurrencyAmount);
                nPosAmount = Sal.TblQueryColumnID(tblVoucherPosting_colnAmount);
                nPosCurrTaxAmount = Sal.TblQueryColumnID(tblVoucherPosting_colnCurrencyTaxAmount);
                nPosTaxAmount = Sal.TblQueryColumnID(tblVoucherPosting_colnTaxAmount);

                nPosParallelTaxAmnt = Sal.TblQueryColumnID(tblVoucherPosting_colnParallelCurrTaxAmount);


                nPosParallelCurrAmount = Sal.TblQueryColumnID(tblVoucherPosting_colnThirdCurrencyAmount);

                this.dfnCurrencyBalance.Number = Sal.TblColumnSum(tblVoucherPosting, nPosCurrAmount, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1)) + Sal.TblColumnSum(tblVoucherPosting, nPosCurrTaxAmount, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1));
                this.dfnBalance.Number = Sal.TblColumnSum(tblVoucherPosting, nPosAmount, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1)) + Sal.TblColumnSum(tblVoucherPosting, nPosTaxAmount, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1));

                this.dfnParallelCurrBalance.Number = Sal.TblColumnSum(tblVoucherPosting, nPosParallelCurrAmount, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1)) + Sal.TblColumnSum(tblVoucherPosting, nPosParallelTaxAmnt, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1));

            }
            else if (sAmountMethodDb == "GROSS")
            {
                nPosCurrAmount = Sal.TblQueryColumnID(tblVoucherPosting_colnCurrencyAmount);
                nPosAmount = Sal.TblQueryColumnID(tblVoucherPosting_colnAmount);
                this.dfnCurrencyBalance.Number = Sal.TblColumnSum(tblVoucherPosting, nPosCurrAmount, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1));
                this.dfnBalance.Number = Sal.TblColumnSum(tblVoucherPosting, nPosAmount, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1));

                this.dfnParallelCurrBalance.Number = Sal.TblColumnSum(tblVoucherPosting, nPosParallelCurrAmount, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1));

            }

            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherPosting_colnParallelCurrTaxAmount_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;

            if (this.i_sFinThirdCurrencyCode == Ifs.Fnd.ApplicationForms.Const.strNULL)
            {
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                return;
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        private void tblVoucherPosting_colsDeliveryTypeId_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblVoucherPosting_colsDeliveryTypeId_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        private void tblVoucherPosting_colsDeliveryTypeId_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (!(Sal.IsNull(this.tblVoucherPosting_colsDeliveryTypeId)))
            {
                if (!(this.tblVoucherPosting_colsDeliveryTypeId.DbPLSQLBlock(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "Voucher_Row_API.Validate_Delivery_Type_Id__(\r\n" +
                    " :i_hWndFrame.frmVoucherPosting.tblVoucherPosting_colsCompany IN,\r\n" +
                    " :i_hWndFrame.frmVoucherPosting.tblVoucherPosting_colsDeliveryTypeId IN)")))
                {
                    e.Return = false;
                    return;
                }

            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        private void tblVoucherPosting_colsCodeB_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    e.Handled = true;
                    if (Sys.wParam == 1)
                    {
                        EnableDisableSeqId("B");
                    }
                    e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
                    return;
            }
            #endregion
        }

        private void tblVoucherPosting_colsCodeC_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    e.Handled = true;
                    if (Sys.wParam == 1)
                    {
                        EnableDisableSeqId("C");
                    }
                    e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
                    return;
            }
            #endregion
        }

        private void tblVoucherPosting_colsCodeD_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    e.Handled = true;
                    if (Sys.wParam == 1)
                    {
                        EnableDisableSeqId("D");
                    }
                    e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
                    return;
            }
            #endregion
        }

        private void tblVoucherPosting_colsCodeE_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    e.Handled = true;
                    if (Sys.wParam == 1)
                    {
                        EnableDisableSeqId("E");
                    }
                    e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
                    return;
            }
            #endregion
        }

        private void tblVoucherPosting_colsCodeF_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    e.Handled = true;
                    if (Sys.wParam == 1)
                    {
                        EnableDisableSeqId("F");
                    }
                    e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
                    return;
            }
            #endregion
        }

        private void tblVoucherPosting_colsCodeG_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    e.Handled = true;
                    if (Sys.wParam == 1)
                    {
                        EnableDisableSeqId("G");
                    }
                    e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
                    return;
            }
            #endregion
        }

        private void tblVoucherPosting_colsCodeH_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    e.Handled = true;
                    if (Sys.wParam == 1)
                    {
                        EnableDisableSeqId("H");
                    }
                    e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
                    return;
            }
            #endregion
        }

        private void tblVoucherPosting_colsCodeI_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    e.Handled = true;
                    if (Sys.wParam == 1)
                    {
                        EnableDisableSeqId("I");
                    }
                    e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
                    return;
            }
            #endregion
        }

        private void tblVoucherPosting_colsCodeJ_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    e.Handled = true;
                    if (Sys.wParam == 1)
                    {
                        EnableDisableSeqId("J");
                    }
                    e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
                    return;
            }
            #endregion
        }
        #endregion

        #region Window Events
        private void tblVoucherPosting_DataRecordCheckRequiredEvent(object sender, FndReturnEventArgsSalBoolean e)
        {
            e.Handled = true;
            e.ReturnValue = this.DataRecordCheckRequired();
        }

        private void tblVoucherPosting_DataRecordDuplicateEvent(object sender, cDataSource.DataRecordDuplicateEventArgs e)
        {
            e.Handled = true;
            e.ReturnValue = this.DataRecordDuplicate(e.nWhat);
        }

        private void tblVoucherPosting_DataRecordExecuteModifyEvent(object sender, cDataSource.DataRecordExecuteModifyEventArgs e)
        {
            e.Handled = true;
            e.ReturnValue = this.DataRecordExecuteModify(e.hSql);
        }

        private void tblVoucherPosting_DataRecordExecuteRemoveEvent(object sender, cDataSource.DataRecordExecuteRemoveEventArgs e)
        {
            e.Handled = true;
            e.ReturnValue = this.DataRecordExecuteRemove(e.hSql);
        }

        private void tblVoucherPosting_DataRecordGetDefaultsEvent(object sender, FndReturnEventArgsSalBoolean e)
        {
            e.Handled = true;
            e.ReturnValue = this.DataRecordGetDefaults();
        }

        private void tblVoucherPosting_DataRecordNewEvent(object sender, cDataSource.DataRecordNewEventArgs e)
        {
            e.Handled = true;
            e.ReturnValue = DataRecordNew(e.nWhat);
        }

        private void tblVoucherPosting_DataRecordRemoveEvent(object sender, cDataSource.DataRecordRemoveEventArgs e)
        {
            e.Handled = true;
            e.ReturnValue = this.DataRecordRemove(e.nWhat);
        }

        private void tblVoucherPosting_DataRecordValidateEvent(object sender, FndReturnEventArgsSalBoolean e)
        {
            e.Handled = true;
            e.ReturnValue = this.DataRecordValidate();
        }

        private void tblVoucherPosting_DataSourceFormatSqlColumnUserEvent(object sender, FndReturnEventArgsSalString e)
        {
            e.Handled = true;
            e.ReturnValue = this.DataSourceFormatSqlColumnUser();
        }

        private void tblVoucherPosting_DataSourceFormatSqlIntoUserEvent(object sender, FndReturnEventArgsSalString e)
        {
            e.Handled = true;
            e.ReturnValue = this.DataSourceFormatSqlIntoUser();
        }

        private void tblVoucherPosting_EnableDisableProjectActivityIdEvent(object sender, cChildTableFin.cChildTableFinEventArgs e)
        {
            e.Handled = true;
            e.ReturnValue = EnableDisableProjectActivityId(e.sCodePartValue);
        }
        // This is a fale-safe mechanism used to remove the addition of third currency amount to the attribute string.
        // The same functionality is handled in DataRecordValidate() but sometimes this fails, this fale-safe will work
        // in that senario.
        private void tblVoucherPosting_DataSourceSaveCheckEvent(object sender, FndReturnEventArgsSalBoolean e)
        {
            #region Local Varibale
            SalNumber nContextRow;
            SalNumber nCurRow;
            #endregion

            e.Handled = true;
            // - Keep cuurent context row
            nContextRow = Sal.TblQueryContext(tblVoucherPosting);
            nCurRow = Sys.TBL_MinRow;
            while (Sal.TblFindNextRow(tblVoucherPosting, ref nCurRow, Sys.ROW_New, 0))
            {
                Sal.TblSetContext(tblVoucherPosting, nCurRow);
                Sal.SetFieldEdit(this.tblVoucherPosting_colnThirdCurrencyAmount, false);
            }
            // - Restore context
            Sal.TblSetContext(tblVoucherPosting, nContextRow);
            e.ReturnValue = ((cChildTableFin)tblVoucherPosting).DataSourceSaveCheck();
        }
        #endregion

        #endregion
  
        #region Event Handlers

        private void menuItem_Internal_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = this.UM_IntManualPostings(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem_Internal_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            this.UM_IntManualPostings(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        #endregion

    }
}
