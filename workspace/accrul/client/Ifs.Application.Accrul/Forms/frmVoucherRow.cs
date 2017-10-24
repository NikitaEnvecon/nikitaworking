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
//------------------------------------------------------------
// 12-11-23 JANBLK DANU-122,Parallel currency implementation.
// 14-01-07 CHARLK PBFI-4425,Change Method UM_LaunchPeriodAllocation. 
// 14-11-20 Mawelk PRFI-3607(Bug 119686), Modified UM_LaunchPeriodAllocation
// 15-08-20 THPELK FISU-275, Corrected.

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
	/// NOTE! This form is remade to a read only form. Much of the code that belongs
	/// to it is not in use any more!!!
	/// </summary>
    public partial class frmVoucherRow : cFormWindowFin
    {
        #region Window Variables
        public SalString sIsValidEmuCurrency = "";
        public SalString sVouDate = "";
        public SalString sCurrCode = "";
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public frmVoucherRow()
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
        public new static frmVoucherRow FromHandle(SalWindowHandle handle)
        {
            return ((frmVoucherRow)SalWindow.FromHandle(handle, typeof(frmVoucherRow)));
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
                nRow = Sal.TblQueryContext(tblVoucherRow);
                nPosAccount = Sal.TblQueryColumnID(tblVoucherRow_colsAccount);
                hWndCol = Sal.TblGetColumnWindow(tblVoucherRow, nPosAccount, Sys.COL_GetPos);
                Sal.TblSetFocusCell(tblVoucherRow, nRow, hWndCol, 0, 1);
            }

            return 0;
            #endregion
        }

        public override SalNumber vrtFrameActivate()
        {
            Sal.SendMsg(this.tblVoucherRow, Ifs.Application.Accrul.Const.PAM_CallChanged, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
            return base.vrtFrameActivate();
        }
        #endregion

        #region Window Actions

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void frmVoucherRow_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Const.PAM_VoucherDateGet:
                    frmVoucherRow_OnPAM_VoucherDateGet(sender, e);
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
        private void frmVoucherRow_OnPAM_VoucherDateGet(object sender, WindowActionsEventArgs e)
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
        private void tblVoucherRow_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Const.PAM_GetIntPostingInfo:
                    this.tblVoucherRow_OnPAM_GetIntPostingInfo(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate:
                    this.tblVoucherRow_OnPM_DataSourcePopulate(sender, e);
                    break;

                case Sys.SAM_FetchRowDone:
                    this.tblVoucherRow_OnSAM_FetchRowDone(sender, e);
                    break;

                case Const.PAM_CodePartBlocked:
                    e.Handled = true;
                    e.Return = this.CodePartBlocked(SalString.FromHandle(Sys.wParam));
                    return;

                case Const.PAM_CodePartDescBlocked:
                    e.Handled = true;
                    e.Return = this.CodePartDescBlocked(SalString.FromHandle(Sys.wParam));
                    return;
            }
            #endregion
        }

        /// <summary>
        /// PAM_GetIntPostingInfo event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherRow_OnPAM_GetIntPostingInfo(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
           this.sMessage.Construct();
           this.sMessage.AddAttribute("COMPANY", this.tblVoucherRow_colsCompany.Text);
           this.sMessage.AddAttribute("LEDGER_ID",this.p_sLedger);
           this.sMessage.AddAttribute("VOUCHER_TYPE", this.tblVoucherRow_colsVoucherType.Text);
           this.sMessage.AddAttribute("ACCOUNT",this.p_sAccount);
           this.sMessage.AddAttribute("CORRECTION",this.p_sCorrection);
           this.sTempVouDate = frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfdVoucherDate.DateTime.ToString();
           this.sMessage.AddAttribute("VOUCHER_DATE",this.sTempVouDate);
           this.sMessage.AddAttribute("ACCOUNTING_YEAR", this.tblVoucherRow_colnAccountingYear.Number.ToString(0));
           this.sMessage.AddAttribute("VOUCHER_NO", this.tblVoucherRow_colnVoucherNo.Number.ToString(0));
           this.sMessage.AddAttribute("REF_ROW_NO",this.p_nRefRowNo.ToString(0));
           this.sMessage.AddAttribute("AMOUNT",this.p_nAmount.ToString(frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).nDecimalsInAmount));
           this.sMessage.AddAttribute("CURRENCY_AMOUNT",this.p_nCurrencyAmount.ToString(frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).nDecimalsInAmount));
           this.sMessage.AddAttribute("CURRENCY_RATE",this.p_nCurrRate.ToString(9));
           this.sMessage.AddAttribute("INTERNAL_SEQ_NUMBER",this.p_nInternalSeq.ToString(0));
            if (frmVoucherRow.FromHandle(i_hWndFrame).i_nFinConversionFactor == 0)
            {
                frmVoucherRow.FromHandle(i_hWndFrame).GetAttributes(this.tblVoucherRow_colsCompany.Text, this.tblVoucherRow_colsCurrencyCode.Text, frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).sCurrencyCode,
                    this.tblVoucherRow_colsCurrencyType.Text, frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfdVoucherDate.DateTime);
            }
           this.sMessage.AddAttribute("CONV_FACTOR", frmVoucherRow.FromHandle(i_hWndFrame).i_nFinConversionFactor.ToString(0));
            // Bug 77430, Begin, checked the authorization level
            if (this.tblVoucherRow_colsFunctionGroup.Text == "M" ||this.tblVoucherRow_colsFunctionGroup.Text == "Q" ||this.tblVoucherRow_colsFunctionGroup.Text == "K" && this.tblVoucherRow_colAutoTaxVouEntry.Text == "FALSE")
            {
                if (frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).sAuthLevel != "ApproveOnly")
                {
                   this.sMessage.AddAttribute("EDITABLE", "Y");
                }
                else
                {
                   this.sMessage.AddAttribute("EDITABLE", "N");
                }
            }
            // Bug 77430, End
            else
            {
               this.sMessage.AddAttribute("EDITABLE", "N");
            }
            // Bug 76119, Begin - Added the missing attributes
           this.sMessage.AddAttribute("COMP_CURRENCY", frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).sCurrencyCode);
           this.sMessage.AddAttribute("CURRENCY", this.tblVoucherRow_colsCurrencyCode.Text);
            // Bug 76119, End
           this.sMessage.AddAttribute("DECIMAL_TRANS_ROUND", this.tblVoucherRow_colnDecimalsInAmount.Number.ToString(0));
           this.sMessage.AddAttribute("DECIMAL_BASE_ROUND", this.tblVoucherRow_colnAccDecimalsInAmount.Number.ToString(0));
           this.sPackedMessage =this.sMessage.Pack();
            e.Return =this.sPackedMessage.ToHandle();
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataSourcePopulate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherRow_OnPM_DataSourcePopulate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
               this.bManualCompleted = false;
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// SAM_FetchRowDone event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherRow_OnSAM_FetchRowDone(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Sys.SAM_FetchRowDone, Sys.wParam, Sys.lParam);
            if (this.tblVoucherRow_colCorrection.Text == "Y")
            {
                frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).cbUseCorrectionRows.Checked = true;
            }
            else
            {
                frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).cbUseCorrectionRows.Checked = false;
            }
            e.Return = true;
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

        #region ChildTable-tblVoucherRow

        #region Window Variables
        public SalBoolean bTemplateOrCopyGL = false;
        public SalNumber nCurrencyAmount = 0;
        public SalNumber nAmount = 0;
        public SalNumber nCurrencyRate = 0;
        public SalNumber nThirdCurrencyAmount = 0;
        public SalNumber nPrevAmount = 0;
        public SalNumber nPrevRate = 0;
        public SalString sFormName = "";
        public SalString sMode = "";
        public SalString sParentName = "";
        public SalString sParam = "";
        public SalString sResult = "";
        public SalString sResult1 = "";
        public SalString sSetRateNotEnabled = "";
        public cMessage sMessage = new cMessage();
        public SalString p_sLedger = "";
        public SalString p_sAccount = "";
        public SalNumber p_nRefRowNo = 0;
        public SalNumber p_nAmount = 0;
        public SalNumber p_nCurrRate = 0;
        public SalNumber p_nCurrencyAmount = 0;
        public SalNumber p_nInternalSeq = 0;
        public SalString sPackedMessage = "";
        public SalString sTempVouDate = "";
        public SalBoolean bManualCompleted = false;
        public SalString p_sCorrection = "";
        public SalString sIsStatAccount = "";
        #endregion

        #region Methods

        /// <summary>
        /// </summary>
        /// <param name="p_nWhat"></param>
        /// <returns></returns>
        public virtual SalBoolean AddPseudoCode(SalNumber p_nWhat)
        {
            #region Actions
            switch (p_nWhat)
            {
                case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                    SendDataToAddPseudoCodeDlg();
                    if (!(SessionModalDialog(Pal.GetActiveInstanceName("dlgAddPseudoCode"), Ifs.Fnd.ApplicationForms.Int.Explorer.ExplorerForm) == Sys.IDOK))
                    {
                        return false;
                    }
                    return true;

                case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                    SalNumber ln_currentTableRow = Sys.TBL_MinRow;
                    SalNumber nCounter = 0;
                    while (Sal.TblFindNextRow(tblVoucherRow, ref ln_currentTableRow, Sys.ROW_Selected, 0))
                    {
                        Sal.TblSetContext(tblVoucherRow, ln_currentTableRow);
                        nCounter = nCounter + 1;
                    }
                    if ((nCounter == 1 && !(DataSourceSave(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire))) && Ifs.Fnd.ApplicationForms.Var.Security.IsViewAvailable("PRIVATE_PSEUDO_CODES"))
                    {
                        return true;
                    }
                    return false;
            }
            return false;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber SendDataToAddPseudoCodeDlg()
        {
            #region Local Variables
            SalString sRS = "";
            SalString sUS = "";
            SalArray<SalString> sPseudoCodeData = new SalArray<SalString>();
            SalString sQuantity = "";
            #endregion

            #region Actions
            sRS = ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_RS).ToCharacter();
            sUS = ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_US).ToCharacter();
            if (Sal.IsNull(tblVoucherRow_colnQuantity))
            {
                sQuantity = SalString.Null;
            }
            else
            {
                sQuantity = tblVoucherRow_colnQuantity.Number.ToString(0);
            }

            sPseudoCodeData[0] = "COMPANY" + sUS + tblVoucherRow_colsCompany.Text + sRS + "ACCOUNT" + sUS + tblVoucherRow_colsAccount.Text + sRS + "CODE_B" + sUS + tblVoucherRow_colsCodeB.Text + sRS + "CODE_C" + sUS + tblVoucherRow_colsCodeC.Text + sRS + "CODE_D" + sUS + tblVoucherRow_colsCodeD.Text + sRS + "CODE_E" +
            sUS + tblVoucherRow_colsCodeE.Text + sRS + "CODE_F" + sUS + tblVoucherRow_colsCodeF.Text + sRS + "CODE_G" + sUS + tblVoucherRow_colsCodeG.Text + sRS + "CODE_H" + sUS + tblVoucherRow_colsCodeH.Text + sRS + "CODE_I" + sUS + tblVoucherRow_colsCodeI.Text + sRS + "CODE_J" + sUS + tblVoucherRow_colsCodeJ.Text + sRS + "PROCESS_CODE" +
            sUS + tblVoucherRow_colsProcessCode.Text + sRS + "QUANTITY" + sUS + sQuantity + sRS + "PROJECT_ACTIVITY_ID" + sUS + tblVoucherRow_colnProjectActivityId.Text + sRS;
            Ifs.Fnd.ApplicationForms.Var.DataTransfer.SourceNameSet("AddPseudoCode");
            Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemAdd("AddPseudoCode", sPseudoCodeData);
            return 0;
            #endregion
        }

        /// <summary>
        /// This is an overridden function defined in the cChildTableFin class
        /// </summary>
        /// <param name="sSqlColumn"></param>
        /// <returns></returns>
        public virtual new SalBoolean CodePartBlocked(SalString sSqlColumn)
        {
            return Ifs.Fnd.ApplicationForms.Int.PalAttrGet(sSqlColumn, tblVoucherRow_colsCodeDemand.Text) == "S";
        }

        /// <summary>
        /// This is an overridden function defined in the cChildTableFin class
        /// </summary>
        /// <param name="sSqlColumn"></param>
        /// <returns></returns>
        public virtual new SalBoolean CodePartDescBlocked(SalString sSqlColumn)
        {
            if (sSqlColumn == "ACCOUNT_DESC")
            {
                sSqlColumn = "ACCOUNT";
            }
            if (sSqlColumn == "CODE_B_DESC")
            {
                sSqlColumn = "CODE_B";
            }
            if (sSqlColumn == "CODE_C_DESC")
            {
                sSqlColumn = "CODE_C";
            }
            if (sSqlColumn == "CODE_D_DESC")
            {
                sSqlColumn = "CODE_D";
            }
            if (sSqlColumn == "CODE_E_DESC")
            {
                sSqlColumn = "CODE_E";
            }
            if (sSqlColumn == "CODE_F_DESC")
            {
                sSqlColumn = "CODE_F";
            }
            if (sSqlColumn == "CODE_G_DESC")
            {
                sSqlColumn = "CODE_G";
            }
            if (sSqlColumn == "CODE_H_DESC")
            {
                sSqlColumn = "CODE_H";
            }
            if (sSqlColumn == "CODE_I_DESC")
            {
                sSqlColumn = "CODE_I";
            }
            if (sSqlColumn == "CODE_J_DESC")
            {
                sSqlColumn = "CODE_J";
            }
            return Ifs.Fnd.ApplicationForms.Int.PalAttrGet(sSqlColumn, tblVoucherRow_colsCodeDemand.Text) == "S";
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber CreateCorrectionVoucher()
        {
            if (tblVoucherRow_colnCurrencyAmount.Number != Sys.NUMBER_Null)
            {
                tblVoucherRow_colnCurrencyAmount.EditDataItemValueSet(0, (-tblVoucherRow_colnCurrencyAmount.Number).ToString(tblVoucherRow_colnDecimalsInAmount.Number).ToHandle());
            }
            tblVoucherRow_colnAmount.EditDataItemValueSet(0, (-tblVoucherRow_colnAmount.Number).ToString(tblVoucherRow_colnAccDecimalsInAmount.Number).ToHandle());
            tblVoucherRow_colnThirdCurrencyAmount.Number = -tblVoucherRow_colnThirdCurrencyAmount.Number;
            if (tblVoucherRow_colCorrection.Text == "Y")
            {
                tblVoucherRow_colCorrection.EditDataItemValueSet(0, ((SalString)"N").ToHandle());
            }
            else
            {
                tblVoucherRow_colCorrection.EditDataItemValueSet(0, ((SalString)"Y").ToHandle());
                frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).cbCorrection.Checked = true;
            }
            if (tblVoucherRow_colnDebetAmount.Number == Sys.NUMBER_Null)
            {
                tblVoucherRow_colnCreditAmount.EditDataItemValueSet(1, (-tblVoucherRow_colnCreditAmount.Number).ToString(tblVoucherRow_colnAccDecimalsInAmount.Number).ToHandle());
                tblVoucherRow_colnThirdCurrencyCreditAmount.Number = -tblVoucherRow_colnThirdCurrencyCreditAmount.Number;
                tblVoucherRow_colnThirdCurrencyCreditAmount.EditDataItemSetEdited();
                if (tblVoucherRow_colnCurrencyCreditAmount.Number != Sys.NUMBER_Null)
                {
                    tblVoucherRow_colnCurrencyCreditAmount.EditDataItemValueSet(1, (-tblVoucherRow_colnCurrencyAmount.Number).ToString(tblVoucherRow_colnDecimalsInAmount.Number).ToHandle());
                }
            }
            else
            {
                tblVoucherRow_colnDebetAmount.EditDataItemValueSet(1, (-tblVoucherRow_colnDebetAmount.Number).ToString(tblVoucherRow_colnAccDecimalsInAmount.Number).ToHandle());
                tblVoucherRow_colnThirdCurrencyDebitAmount.Number = -tblVoucherRow_colnThirdCurrencyDebitAmount.Number;
                tblVoucherRow_colnThirdCurrencyDebitAmount.EditDataItemSetEdited();
                if (tblVoucherRow_colnCurrencyDebetAmount.Number != Sys.NUMBER_Null)
                {
                    tblVoucherRow_colnCurrencyDebetAmount.EditDataItemValueSet(1, tblVoucherRow_colnCurrencyAmount.Number.ToString(tblVoucherRow_colnDecimalsInAmount.Number).ToHandle());
                }
            }
            tblVoucherRow_colnQuantity.Number = -tblVoucherRow_colnQuantity.Number;
            tblVoucherRow_colnQuantity.EditDataItemSetEdited();
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
            #endregion

            #region Actions

            // (-)Ersruk Twin Peaks,Balance Sheet by Project, Start
            // If ( tblVoucherRow_colsProjectActivityIdEnabled = 'Y')  AND SalIsNull( tblVoucherRow_colnProjectActivityId ) AND Security.IsViewAvailable('PROJECT_ACTIVITY')
            // Call DataRecordShowRequired( tblVoucherRow_colnProjectActivityId )
            // Return FALSE
            // (-)Ersruk Twin Peaks,Balance Sheet by Project, End
            if (bTemplateOrCopyGL == true)
            {
                return true;
            }
            else
            {
                if (frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).lsAutoBal == "Y")
                {
                    if ((Sal.IsNull(tblVoucherRow_colnAmount) || tblVoucherRow_colnAmount.Number == 0) && this.dfnBalance.Number != 0)
                    {
                        if (!(IsSameCurrCode()))
                        {
                            return false;
                        }
                        tblVoucherRow_colnCurrencyAmount.Number = this.dfnCurrencyBalance.Number * -1;
                        tblVoucherRow_colnAmount.Number = this.dfnBalance.Number * -1;
                        this.dfnCurrencyBalance.Number = 0;
                        this.dfnBalance.Number = 0;

                        this.dfnParallelCurrBalance.Number = 0;

                        if (tblVoucherRow_colnCurrencyAmount.Number > 0)
                        {
                            tblVoucherRow_colnCurrencyDebetAmount.Number = tblVoucherRow_colnCurrencyAmount.Number;
                            tblVoucherRow_colnDebetAmount.Number = tblVoucherRow_colnAmount.Number;
                        }
                        else
                        {
                            tblVoucherRow_colnCurrencyCreditAmount.Number = tblVoucherRow_colnCurrencyAmount.Number * -1;
                            tblVoucherRow_colnCreditAmount.Number = tblVoucherRow_colnAmount.Number * -1;
                        }
                        tblVoucherRow_colnCurrencyDebetAmount.EditDataItemSetEdited();
                        tblVoucherRow_colnCurrencyCreditAmount.EditDataItemSetEdited();
                        tblVoucherRow_colnDebetAmount.EditDataItemSetEdited();
                        tblVoucherRow_colnCreditAmount.EditDataItemSetEdited();
                        SetThirdCurrencyAmounts();
                    }
                }
                if (tblVoucherRow_colnAmount.Number == 0)
                {
                    if (Sal.IsNull(tblVoucherRow_colnQuantity) || tblVoucherRow_colnQuantity.Number == 0)
                    {
                        Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_VoEn_AlertQuantity, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
                        return false;
                    }
                }
                if (((cDataSource)tblVoucherRow).DataRecordCheckRequired())
                {
                    n = 0;
                    while (n < tblVoucherRow.i_nChildCount)
                    {
                        if (Sal.WindowClassName(tblVoucherRow.i_hWndChild[n]) == "cColumnCodePartFin")
                        {
                            sSqlColumn = cColumn.FromHandle(tblVoucherRow.i_hWndChild[n]).p_sSqlColumn;
                            if (Ifs.Fnd.ApplicationForms.Int.PalAttrGet(sSqlColumn, tblVoucherRow_colsCodeDemand.Text) == "M" && Sal.IsNull(tblVoucherRow.i_hWndChild[n]))
                            {
                                DataRecordShowRequired(tblVoucherRow.i_hWndChild[n]);
                                return false;
                            }
                        }
                        n = n + 1;
                    }
                    nCurrenctRow = Sal.TblQueryContext(tblVoucherRow);
                    SetParentKey(nCurrenctRow);
                    return true;
                }
                return false;
            }
            #endregion

        }

        /// <summary>
        /// Applications and the framework call the DataRecordDuplicate function
        /// to duplicate the current record in a data source.
        /// </summary>
        /// <param name="nWhat"></param>
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
            #endregion

            #region Actions

            sMode = Ifs.Fnd.ApplicationForms.Const.strNULL;
            switch (nWhat)
            {
                case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                    return ((bool)((cChildTableFin)tblVoucherRow).DataRecordDuplicate(nWhat)) && (((SalString)tblVoucherRow_colsTransCode.Text).Trim().ToUpper() == "MANUAL");

                case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                    sMode = "DUPLICATED";
                    if (!(Sal.PostMsg(tblVoucherRow_colsCurrencyCode, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam)))
                    {
                        return 0;
                    }
                    bOk = ((cChildTableFin)tblVoucherRow).DataRecordDuplicate(nWhat);
                    if (tblVoucherRow_colnCurrencyDebetAmount.Number != Sys.NUMBER_Null)
                    {
                        if (!(Sal.SendMsg(tblVoucherRow_colnCurrencyDebetAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, 0, 0)))
                        {
                            return 0;
                        }
                    }
                    else if (tblVoucherRow_colnCurrencyCreditAmount.Number != Sys.NUMBER_Null)
                    {
                        if (!(Sal.SendMsg(tblVoucherRow_colnCurrencyCreditAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, 0, 0)))
                        {
                            return 0;
                        }
                    }
                    else if (tblVoucherRow_colnDebetAmount.Number != Sys.NUMBER_Null)
                    {
                        if (!(Sal.SendMsg(tblVoucherRow_colnDebetAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, 0, 0)))
                        {
                            return 0;
                        }
                    }
                    else
                    {
                        if (!(Sal.SendMsg(tblVoucherRow_colnCreditAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, 0, 0)))
                        {
                            return 0;
                        }
                    }
                    sMode = Ifs.Fnd.ApplicationForms.Const.strNULL;
                    return bOk;

                case Ifs.Fnd.ApplicationForms.Const.METHOD_GetType:
                    return Ifs.Fnd.ApplicationForms.Const.CHILDTYPE_SourceMethod;
            }
            

            return 0;
            #endregion
        }

        /// <summary>
        /// Get default values for new voucher row
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber DataRecordGetDefaults()
        {
            if (frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).cbCorrection.Checked)
            {
                tblVoucherRow_colCorrection.Text = "Y";
            }
            else
            {
                tblVoucherRow_colCorrection.Text = "N";
            }
            tblVoucherRow_colnAccountingPeriod.EditDataItemValueSet(1, frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfnAccountingPeriod.Number.ToString(0).ToHandle());
            tblVoucherRow_colnAmount.EditDataItemValueSet(0, ((SalNumber)0).ToString(frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).nDecimalsInAmount).ToHandle());
            tblVoucherRow_colsCurrencyType.EditDataItemValueSet(0, ((SalString)frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfsCurrencyType.Text).ToHandle());
            tblVoucherRow_colnDecimalsInAmount.EditDataItemValueSet(0, frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).nDecimalsInAmount.ToString(0).ToHandle());
            tblVoucherRow_colnAccDecimalsInAmount.EditDataItemValueSet(0, frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).nDecimalsInAmount.ToString(0).ToHandle());
            if (sMode != "DUPLICATED")
            {
                tblVoucherRow_colsCurrencyCode.EditDataItemValueSet(1, ((SalString)frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfsCurrencyCode.Text).ToHandle());
                tblVoucherRow_colnCurrencyRate.EditDataItemValueSet(1, frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfnCurrencyRate.Number.ToString(frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).nDecimalsInRate).ToHandle());
                tblVoucherRow_colsText.EditDataItemValueSet(1, ((SalString)frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfsRowText.Text).ToHandle());
            }
            return 0;
        }

        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalNumber DataRecordNew(SalNumber nWhat)
        {
            switch (nWhat)
            {
                case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                    return ((bool)((cDataSource)tblVoucherRow).DataRecordNew(nWhat)) && frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfsCompany.Text != Sys.STRING_Null;

                case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                    if (!(frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).DataRecordCheckRequired()))
                    {
                        return 0;
                    }
                    if (!(frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).GetParallelCurrencyAttributes()))
                    {
                        return 0;
                    }
                    tblVoucherRow_colsFunctionGroup.EditDataItemValueSet(1, ((SalString)frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfsVoucherGroup.Text).ToHandle());
                    return ((cChildTableFin)tblVoucherRow).DataRecordNew(nWhat);

                case Ifs.Fnd.ApplicationForms.Const.METHOD_GetType:
                    return ((cDataSource)tblVoucherRow).DataRecordNew(nWhat);
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
            SalNumber nPosCurrAmount = 0;
            SalNumber nPosAmount = 0;

            SalNumber nPosParrCurrAmount = 0;

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
                    bOk = ((cChildTableFin)tblVoucherRow).DataRecordRemove(nWhat);
                    if (tblVoucherRow_colIsStatAccount.Text == "TRUE")
                    {
                        Sal.TblSetRowFlags(tblVoucherRow, Sal.TblQueryContext(tblVoucherRow), Sys.ROW_UnusedFlag1, true);
                    }
                    else
                    {
                        Sal.TblSetRowFlags(tblVoucherRow, Sal.TblQueryContext(tblVoucherRow), Sys.ROW_UnusedFlag1, false);
                    }
                    nPosCurrAmount = Sal.TblQueryColumnID(tblVoucherRow_colnCurrencyAmount);
                    nPosAmount = Sal.TblQueryColumnID(tblVoucherRow_colnAmount);

                    nPosParrCurrAmount = Sal.TblQueryColumnID(tblVoucherRow_colnThirdCurrencyAmount);

                    this.dfnCurrencyBalance.Number = Sal.TblColumnSum(tblVoucherRow, nPosCurrAmount, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1));
                    this.dfnBalance.Number = Sal.TblColumnSum(tblVoucherRow, nPosAmount, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1));

                    this.dfnParallelCurrBalance.Number = Sal.TblColumnSum(tblVoucherRow, nPosParrCurrAmount, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1));

                    return bOk;

                case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                    return ((cChildTableFin)tblVoucherRow).DataRecordRemove(nWhat);

                case Ifs.Fnd.ApplicationForms.Const.METHOD_GetType:
                    return ((cChildTableFin)tblVoucherRow).DataRecordRemove(nWhat);
            }
            

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean DataRecordValidate()
        {
            Sal.SetFieldEdit(tblVoucherRow_colsTextId, false);
            Sal.SetFieldEdit(tblVoucherRow_colsCurrencyType, false);
            Sal.SetFieldEdit(tblVoucherRow_colnAmount, false);
            Sal.SetFieldEdit(tblVoucherRow_colnCurrencyAmount, false);
            Sal.SetFieldEdit(tblVoucherRow_colCorrection, false);
            Sal.SetFieldEdit(tblVoucherRow_colnDecimalsInAmount, false);
            Sal.SetFieldEdit(tblVoucherRow_colnAccDecimalsInAmount, false);
            return ((cChildTableFin)tblVoucherRow).DataRecordValidate();
        }

        /// <summary>
        /// Applications should override the DataSourceFormatSqlColumnUser function
        /// to specify extra columns to be included in the select statement for the
        /// data source.
        /// </summary>
        /// <returns></returns>
        public virtual SalString DataSourceFormatSqlColumnUser()
        {
            SalString sAttr  = "NVL(CURRENCY_DEBET_AMOUNT,0) - NVL(CURRENCY_CREDIT_AMOUNT,0),";
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
            return this.tblVoucherRow_colnCurrencyAmount.QualifiedBindName + "," + this.tblVoucherRow_colnAmount.QualifiedBindName;
        }

        /// <summary>
        /// This is an overridden function defined in the cChildTableFin class
        /// </summary>
        /// <param name="sCodePartValue"></param>
        /// <returns></returns>
        public virtual new SalNumber EnableDisableProjectActivityId(SalString sCodePartValue)
        {    
            sParam = sCodePartValue;
            Sal.ClearField(tblVoucherRow_colnProjectActivityId);
            if (Int.IsGenLedInstalled && Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Accounting_Project_Api.Get_Externally_Created"))
            {
                if (!(DbPLSQLBlock("{0} := &AO.Accounting_Project_Api.Get_Externally_Created({1} IN, {2} IN )",
                        this.tblVoucherRow_colsProjectActivityIdEnabled.QualifiedBindName,
                        this.tblVoucherRow_colsCompany.QualifiedBindName,
                        this.QualifiedVarBindName("sParam") )))
                {
                    return false;
                }
            }
            else
            {
                tblVoucherRow_colsProjectActivityIdEnabled.Text = "Y";
            } 
            return 0;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean IsLogicalAccountType()
        {   
            DbPLSQLBlock(@"{0} := &AO.Account_API.Get_Logical_Account_Type_Db({1} IN, {2} IN );",
                                        this.QualifiedVarBindName("sResult"),
                                        this.tblVoucherRow_colsCompany.QualifiedBindName,
                                        this.tblVoucherRow_colsAccount.QualifiedBindName);
            return ((sResult == "C") || (sResult == "R") || (sResult == "S")); 
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean IsLedgerTaxAccount()
        {
            DbPLSQLBlock(@"&AO.Account_API.Is_ledger_Account({0} OUT, {2} IN, {3} IN );
                            &AO.Account_API.Is_Tax_Account({1} OUT, {2} IN, {3} IN );",
                            this.QualifiedVarBindName("sResult1"),
                            this.QualifiedVarBindName("sResult"),
                            this.tblVoucherRow_colsCompany.QualifiedBindName,
                            this.tblVoucherRow_colsAccount.QualifiedBindName);
            return (sResult == "TRUE" || sResult1 == "TRUE");     
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean IsSameCurrCode()
        {
            SalNumber nCurRow = Sys.TBL_MinRow;
            while (Sal.TblFindNextRow(tblVoucherRow, ref nCurRow, 0, 0))
            {
                Sal.TblSetContext(tblVoucherRow, nCurRow);
                if (tblVoucherRow_colsCurrencyCode.Text != frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfsCurrencyCode.Text)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Set the accounting period in the rows when the voucher date is modified
        /// </summary>
        /// <param name="nPeriod"></param>
        /// <returns></returns>
        public virtual SalBoolean SetAccountingPeriod(SalNumber nPeriod)
        {
            SalNumber nCurrenctRow = Sal.TblQueryContext(tblVoucherRow);
            SalNumber nRow = Sys.TBL_MinRow;
            while (Sal.TblFindNextRow(tblVoucherRow, ref nRow, 0, Sys.ROW_MarkDeleted))
            {
                Sal.TblSetContext(tblVoucherRow, nRow);
                if (this.tblVoucherRow_colnAccountingPeriod.Number != nPeriod)
                {
                    this.tblVoucherRow_colnAccountingPeriod.EditDataItemValueSet(1, nPeriod.ToString(0).ToHandle());
                }
            }
            Sal.TblSetContext(tblVoucherRow, nCurrenctRow);
            return true;
        }

        /// <summary>
        /// Set's all fields in the child table edited plus calculates third currency amounts as well.
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber SetAllEdited()
        {
            this.tblVoucherRow_colsCompany.EditDataItemSetEdited();
            this.tblVoucherRow_colsAccount.EditDataItemSetEdited();
            this.tblVoucherRow_colsCodeB.EditDataItemSetEdited();
            this.tblVoucherRow_colsCodeC.EditDataItemSetEdited();
            this.tblVoucherRow_colsCodeD.EditDataItemSetEdited();
            this.tblVoucherRow_colsCodeE.EditDataItemSetEdited();
            this.tblVoucherRow_colsCodeF.EditDataItemSetEdited();
            this.tblVoucherRow_colsCodeG.EditDataItemSetEdited();
            this.tblVoucherRow_colsCodeH.EditDataItemSetEdited();
            this.tblVoucherRow_colsCodeI.EditDataItemSetEdited();
            this.tblVoucherRow_colsCodeJ.EditDataItemSetEdited();
            this.tblVoucherRow_colsProcessCode.EditDataItemSetEdited();
            this.tblVoucherRow_colsCurrencyCode.EditDataItemSetEdited();
            this.tblVoucherRow_colnCurrencyDebetAmount.EditDataItemSetEdited();
            this.tblVoucherRow_colnCurrencyCreditAmount.EditDataItemSetEdited();
            this.tblVoucherRow_colnDebetAmount.EditDataItemSetEdited();
            this.tblVoucherRow_colnCreditAmount.EditDataItemSetEdited();
            this.tblVoucherRow_colnCurrencyRate.EditDataItemSetEdited();
            this.tblVoucherRow_colnQuantity.EditDataItemSetEdited();
            this.tblVoucherRow_colsText.EditDataItemSetEdited();
            this.tblVoucherRow_colsOptionalCode.EditDataItemSetEdited();
            this.tblVoucherRow_colnProjectActivityId.EditDataItemSetEdited();
            this.tblVoucherRow_colsTransCode.EditDataItemSetEdited();

            // For each row that is being copied the third currency amount is being calculated...
            this.SetThirdCurrencyAmounts();
            return 0;
        }

        /// <summary>
        /// Set other related rival currency amount, such as if someone enter debit currency amount,
        /// system must set value for currency amount, debit, amount.
        /// </summary>
        /// <param name="nMyValue"></param>
        /// <param name="hWndRival"></param>
        /// <param name="sStatus"></param>
        /// <returns></returns>
        public virtual SalNumber SetAnotherValue(SalNumber nMyValue, SalWindowHandle hWndRival, SalString sStatus)
        {
            #region Local Variables
            SalNumber nCalculateValue = 0;
            SalNumber nPosCurrAmount = 0;
            SalNumber nPosAmount = 0;

            SalNumber nPosParrCurrAmount = 0;

            #endregion

            #region Actions
            if (sStatus == "RATE")
            {
                this.GetAttributes(tblVoucherRow_colsCompany.Text, tblVoucherRow_colsCurrencyCode.Text, frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).sCurrencyCode, tblVoucherRow_colsCurrencyType.Text, frmEntryVoucher.FromHandle(
                        Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfdVoucherDate.DateTime);
                if (nMyValue != nPrevRate)
                {
                    this.GetBaseCurrAmountForRate(tblVoucherRow_colnCurrencyAmount.Number, nMyValue, ref nCalculateValue);
                }
                else
                {
                    this.GetBaseCurrencyAmount(tblVoucherRow_colnCurrencyAmount.Number, ref nCalculateValue);
                }
                if (nCalculateValue == 0)
                {
                    nCalculateValue = SalNumber.Null;
                }
                tblVoucherRow_colnAmount.Number = nCalculateValue;
                if ((tblVoucherRow_colnAmount.Number > 0 && tblVoucherRow_colCorrection.Text == "Y") || (tblVoucherRow_colnAmount.Number <= 0 && tblVoucherRow_colCorrection.Text == "N"))
                {
                    tblVoucherRow_colnCreditAmount.Number = -nCalculateValue;
                    tblVoucherRow_colnCreditAmount.EditDataItemSetEdited();
                }
                else
                {
                    tblVoucherRow_colnDebetAmount.Number = nCalculateValue;
                    tblVoucherRow_colnDebetAmount.EditDataItemSetEdited();
                }
            }
            else if (sStatus == "CURRENT_AMOUNT")
            {
                if (nMyValue != SalNumber.Null)
                {
                    nMyValue = this.RoundOf(nMyValue, tblVoucherRow_colnDecimalsInAmount.Number);
                }
                this.GetAttributes(tblVoucherRow_colsCompany.Text, tblVoucherRow_colsCurrencyCode.Text, frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).sCurrencyCode, tblVoucherRow_colsCurrencyType.Text, frmEntryVoucher.FromHandle(
                        Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfdVoucherDate.DateTime);
                tblVoucherRow_colnCurrencyAmount.Number = nMyValue;
                this.GetBaseCurrencyAmount(nMyValue, ref nCalculateValue);
                tblVoucherRow_colnAmount.Number = nCalculateValue;
                if (nCalculateValue != SalNumber.Null)
                {
                    if ((nCalculateValue < 0 && tblVoucherRow_colCorrection.Text == "N") || (nCalculateValue > 0 && tblVoucherRow_colCorrection.Text == "Y"))
                    {
                        nCalculateValue = -nCalculateValue;
                    }
                }
                Sal.SendMsg(hWndRival, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, nCalculateValue.ToString(100).ToHandle());
            }
            else if (sStatus == "ACCOUNTING_AMOUNT")
            {
                if (nMyValue != SalNumber.Null)
                {
                    nMyValue = this.RoundOf(nMyValue, tblVoucherRow_colnAccDecimalsInAmount.Number);
                    if ((tblVoucherRow_colnCurrencyAmount.Number != 0) && (tblVoucherRow_colnCurrencyAmount.Number != Sys.NUMBER_Null))
                    {
                        if ((tblVoucherRow_colnCurrencyAmount.Number < 0 && nMyValue > 0) || (tblVoucherRow_colnCurrencyAmount.Number > 0 && nMyValue < 0))
                        {
                            tblVoucherRow_colnCurrencyAmount.Number = -tblVoucherRow_colnCurrencyAmount.Number;
                            if (tblVoucherRow_colnCurrencyDebetAmount.Number == Sys.NUMBER_Null)
                            {
                                tblVoucherRow_colnCurrencyDebetAmount.Number = tblVoucherRow_colnCurrencyCreditAmount.Number;
                                tblVoucherRow_colnCurrencyDebetAmount.EditDataItemSetEdited();
                                tblVoucherRow_colnCurrencyCreditAmount.Number = Sys.NUMBER_Null;
                                tblVoucherRow_colnCurrencyCreditAmount.EditDataItemSetEdited();
                            }
                            else
                            {
                                tblVoucherRow_colnCurrencyCreditAmount.Number = tblVoucherRow_colnCurrencyDebetAmount.Number;
                                tblVoucherRow_colnCurrencyCreditAmount.EditDataItemSetEdited();
                                tblVoucherRow_colnCurrencyDebetAmount.Number = Sys.NUMBER_Null;
                                tblVoucherRow_colnCurrencyDebetAmount.EditDataItemSetEdited();
                            }
                        }
                        this.GetAttributes(tblVoucherRow_colsCompany.Text, tblVoucherRow_colsCurrencyCode.Text, frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).sCurrencyCode, tblVoucherRow_colsCurrencyType.Text, frmEntryVoucher.FromHandle(
                                Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfdVoucherDate.DateTime);
                        if (nMyValue.Abs() != nPrevAmount.Abs())
                        {                              
                            DbPLSQLBlock(@"{0} := &AO.Company_Finance_API.Get_Currency_Code({1} IN )",this.QualifiedVarBindName("sCurrCode"),this.tblVoucherRow_colsCompany.QualifiedBindName);
                               
                            if (tblVoucherRow_colsCurrencyCode.Text != this.sCurrCode)
                            {

                                // PPJ: Automatically generated temporary assignments. Properties canot be passed by reference.
                                SalNumber temp1 = tblVoucherRow_colnCurrencyRate.Number;
                                this.GetCurrencyRate(nMyValue, tblVoucherRow_colnCurrencyAmount.Number, ref temp1);
                                tblVoucherRow_colnCurrencyRate.Number = temp1;

                                tblVoucherRow_colnCurrencyRate.EditDataItemSetEdited();
                            }
                            else
                            {
                                if (tblVoucherRow_colnCreditAmount.Number == Sys.NUMBER_Null)
                                {
                                    tblVoucherRow_colnCurrencyDebetAmount.Number = tblVoucherRow_colnDebetAmount.Number;
                                    tblVoucherRow_colnCurrencyDebetAmount.EditDataItemSetEdited();
                                    tblVoucherRow_colnCurrencyAmount.Number = tblVoucherRow_colnDebetAmount.Number;
                                    tblVoucherRow_colnCurrencyAmount.EditDataItemSetEdited();
                                    tblVoucherRow_colnCurrencyCreditAmount.Number = Sys.NUMBER_Null;
                                    tblVoucherRow_colnCurrencyCreditAmount.EditDataItemSetEdited();
                                }
                                else
                                {
                                    tblVoucherRow_colnCurrencyCreditAmount.Number = tblVoucherRow_colnCreditAmount.Number;
                                    tblVoucherRow_colnCurrencyCreditAmount.EditDataItemSetEdited();
                                    tblVoucherRow_colnCurrencyAmount.Number = -tblVoucherRow_colnCreditAmount.Number;
                                    tblVoucherRow_colnCurrencyAmount.EditDataItemSetEdited();
                                    tblVoucherRow_colnCurrencyDebetAmount.Number = Sys.NUMBER_Null;
                                    tblVoucherRow_colnCurrencyDebetAmount.EditDataItemSetEdited();
                                }
                            }
                        }
                    }
                }
                tblVoucherRow_colnAmount.Number = nMyValue;
            }
            // to exclude stat acc
            if (tblVoucherRow_colIsStatAccount.Text == "TRUE")
            {
                Sal.TblSetRowFlags(tblVoucherRow, Sal.TblQueryContext(tblVoucherRow), Sys.ROW_UnusedFlag1, true);
            }
            else
            {
                Sal.TblSetRowFlags(tblVoucherRow, Sal.TblQueryContext(tblVoucherRow), Sys.ROW_UnusedFlag1, false);
            }
            nPosCurrAmount = Sal.TblQueryColumnID(tblVoucherRow_colnCurrencyAmount);
            nPosAmount = Sal.TblQueryColumnID(tblVoucherRow_colnAmount);

            nPosParrCurrAmount = Sal.TblQueryColumnID(tblVoucherRow_colnThirdCurrencyAmount);

            this.dfnCurrencyBalance.Number = Sal.TblColumnSum(tblVoucherRow, nPosCurrAmount, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1));
            this.dfnBalance.Number = Sal.TblColumnSum(tblVoucherRow, nPosAmount, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1));

            this.dfnParallelCurrBalance.Number = Sal.TblColumnSum(tblVoucherRow, nPosParrCurrAmount, 0, (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag1));

            // Third currency calculation
            SetThirdCurrencyAmounts();
            return nMyValue;
            
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="nCurrenctRow1"></param>
        /// <returns></returns>
        public virtual SalBoolean SetParentKey(SalNumber nCurrenctRow1)
        {
            SalNumber nRow = Sys.TBL_MinRow;
            while (Sal.TblFindNextRow(tblVoucherRow, ref nRow, (Sys.ROW_Edited | Sys.ROW_New), Sys.ROW_MarkDeleted))
            {
                Sal.TblSetContext(tblVoucherRow, nRow);
                if ((tblVoucherRow_colnAccountingYear.Number == frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfnAccountingYear.Number) && (tblVoucherRow_colsVoucherType.Text == SalString.FromHandle(frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(
                            i_hWndFrame)).ccsVoucherType.EditDataItemValueGet())) && (tblVoucherRow_colnVoucherNo.Number == frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfnVoucherNo.Number))
                {
                    Sal.TblSetContext(tblVoucherRow, nCurrenctRow1);
                    return false;
                }
                tblVoucherRow_colnAccountingYear.EditDataItemValueSet(1, frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfnAccountingYear.Number.ToString(0).ToHandle());
                tblVoucherRow_colsVoucherType.EditDataItemValueSet(1, frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).ccsVoucherType.EditDataItemValueGet());
                tblVoucherRow_colnVoucherNo.EditDataItemValueSet(1, frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfnVoucherNo.Number.ToString(0).ToHandle());
                if (frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).sParallelCurrency == Ifs.Fnd.ApplicationForms.Const.strNULL)
                {
                    if (!(Sal.IsNull(tblVoucherRow_colnDebetAmount)))
                    {
                        tblVoucherRow_colnThirdCurrencyDebitAmount.Number = 0;
                        tblVoucherRow_colnThirdCurrencyAmount.Number = 0;
                        tblVoucherRow_colnThirdCurrencyCreditAmount.Number = Sys.NUMBER_Null;
                    }
                    else if (!(Sal.IsNull(tblVoucherRow_colnCreditAmount)))
                    {
                        tblVoucherRow_colnThirdCurrencyCreditAmount.Number = 0;
                        tblVoucherRow_colnThirdCurrencyAmount.Number = 0;
                        tblVoucherRow_colnThirdCurrencyDebitAmount.Number = Sys.NUMBER_Null;
                    }
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
            #endregion

            #region Actions

            if (frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).sParallelCurrency == Ifs.Fnd.ApplicationForms.Const.strNULL)
            {
                if (!(frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).nParallelRate == SalNumber.Null))
                {
                    if (!(Sal.IsNull(tblVoucherRow_colnDebetAmount)))
                    {
                        tblVoucherRow_colnThirdCurrencyDebitAmount.Number = 0;
                        tblVoucherRow_colnThirdCurrencyAmount.Number = 0;
                        tblVoucherRow_colnThirdCurrencyCreditAmount.Number = Sys.NUMBER_Null;
                    }
                    else if (!(Sal.IsNull(tblVoucherRow_colnCreditAmount)))
                    {
                        tblVoucherRow_colnThirdCurrencyCreditAmount.Number = 0;
                        tblVoucherRow_colnThirdCurrencyAmount.Number = 0;
                        tblVoucherRow_colnThirdCurrencyDebitAmount.Number = Sys.NUMBER_Null;
                    }
                }
            }
            else
            {
                if (frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).sParallelCurrency == tblVoucherRow_colsCurrencyCode.Text)
                {
                    if (!(Sal.IsNull(tblVoucherRow_colnCurrencyDebetAmount)))
                    {
                        tblVoucherRow_colnThirdCurrencyDebitAmount.Number = tblVoucherRow_colnCurrencyDebetAmount.Number;
                        tblVoucherRow_colnThirdCurrencyDebitAmount.EditDataItemSetEdited();
                        tblVoucherRow_colnThirdCurrencyAmount.Number = tblVoucherRow_colnCurrencyDebetAmount.Number;
                        tblVoucherRow_colnThirdCurrencyCreditAmount.Number = Sys.NUMBER_Null;
                    }
                    else if (!(Sal.IsNull(tblVoucherRow_colnCurrencyCreditAmount)))
                    {
                        tblVoucherRow_colnThirdCurrencyCreditAmount.Number = tblVoucherRow_colnCurrencyCreditAmount.Number;
                        tblVoucherRow_colnThirdCurrencyCreditAmount.EditDataItemSetEdited();
                        tblVoucherRow_colnThirdCurrencyAmount.Number = -tblVoucherRow_colnCurrencyCreditAmount.Number;
                        tblVoucherRow_colnThirdCurrencyDebitAmount.Number = Sys.NUMBER_Null;
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
                        if (!(Sal.IsNull(tblVoucherRow_colnDebetAmount)) && (tblVoucherRow_colnDebetAmount.Number != 0))
                        {
                            nAmount = tblVoucherRow_colnDebetAmount.Number;
                            this.GetThirdCurrencyAmount(nAmount, ref nThirdCurrencyCurrencyAmount);
                            tblVoucherRow_colnThirdCurrencyDebitAmount.Number = nThirdCurrencyCurrencyAmount;
                            tblVoucherRow_colnThirdCurrencyAmount.Number = tblVoucherRow_colnThirdCurrencyDebitAmount.Number;
                            tblVoucherRow_colnThirdCurrencyDebitAmount.EditDataItemSetEdited();
                            tblVoucherRow_colnThirdCurrencyCreditAmount.Number = Sys.NUMBER_Null;
                        }
                        else if (!(Sal.IsNull(tblVoucherRow_colnCreditAmount)))
                        {
                            nAmount = tblVoucherRow_colnCreditAmount.Number;
                            this.GetThirdCurrencyAmount(nAmount, ref nThirdCurrencyCurrencyAmount);
                            tblVoucherRow_colnThirdCurrencyCreditAmount.Number = nThirdCurrencyCurrencyAmount;
                            tblVoucherRow_colnThirdCurrencyAmount.Number = -tblVoucherRow_colnThirdCurrencyCreditAmount.Number;
                            tblVoucherRow_colnThirdCurrencyCreditAmount.EditDataItemSetEdited();
                            tblVoucherRow_colnThirdCurrencyDebitAmount.Number = Sys.NUMBER_Null;
                        }
                    }
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
            while (nChildCount < tblVoucherRow.i_nChildCount)
            {
                if (tblVoucherRow.i_nChildType[nChildCount] & Ifs.Fnd.ApplicationForms.Const.CHILDTYPE_DataItem)
                {
                    if ((Sal.WindowClassName(tblVoucherRow.i_hWndChild[nChildCount]) == "cColumnCodePartFin") && (cColumn.FromHandle(tblVoucherRow.i_hWndChild[nChildCount]).p_sSqlColumn == "CODE_" + sProjectCodePart))
                    {
                        tblVoucherRow_colsProjectId.Text = SalString.FromHandle(Sal.SendMsg(tblVoucherRow.i_hWndChild[nChildCount], Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueGet, 0, 0));
                        break;
                    }
                }
                nChildCount = nChildCount + 1;
            }
            return 0;
        }

        /// <summary>
        /// Set Voucher Number after save the whole Voucher without error if it is Automatic
        /// </summary>
        /// <param name="nVoucherNo"></param>
        /// <returns></returns>
        public virtual SalBoolean SetVoucherNo(SalNumber nVoucherNo)
        {
            if (nVoucherNo != 0)
            {
                SalNumber nRow = Sys.TBL_MinRow;
                while (Sal.TblFindNextRow(tblVoucherRow, ref nRow, 0, 0))
                {
                    Sal.TblSetContext(tblVoucherRow, nRow);
                    tblVoucherRow_colnVoucherNo.Number = nVoucherNo;
                }
            }
            return true;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber ValidateCurrencyCode()
        {
            if (!(this.GetAttributes(tblVoucherRow_colsCompany.Text, tblVoucherRow_colsCurrencyCode.Text, frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).sCurrencyCode, tblVoucherRow_colsCurrencyType.Text, frmEntryVoucher.FromHandle(
                    Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfdVoucherDate.DateTime)))
            {
                return false;
            }
            tblVoucherRow_colnCurrencyRate.Number = this.GetRate(tblVoucherRow_colsCompany.Text, tblVoucherRow_colsCurrencyCode.Text);
            tblVoucherRow_colnCurrencyRate.EditDataItemSetEdited();
            tblVoucherRow_colnDecimalsInAmount.Number = this.i_nFinTransRound;
            if (!(Sal.IsNull(tblVoucherRow_colnCurrencyAmount)))
            {
                if (!(Sal.SendMsg(tblVoucherRow_colnCurrencyRate, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, 0, 0)))
                {
                    // Don't translate this message, this message only for programmer not user
                    Ifs.Fnd.ApplicationForms.Int.AlertBox("Design time error in colnCurrencyCode !", Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
                    return false;
                }
            }

            if (!(DbPLSQLBlock(@"{0} := &AO.Currency_Code_API.Get_Valid_Emu({1} IN, {2} IN, {3} IN);",
                                    this.QualifiedVarBindName("sIsValidEmuCurrency"),
                                    this.tblVoucherRow_colsCompany.QualifiedBindName,
                                    this.tblVoucherRow_colsCurrencyCode.QualifiedBindName,
                                    frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfdVoucherDate.QualifiedBindName )))
            {
                return false;
            }

            if ((frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).sIsCurrencyEmu == "TRUE") && (tblVoucherRow_colsCurrencyCode.Text == "EUR"))
            {
                sSetRateNotEnabled = "TRUE";
            }
            else
            {
                sSetRateNotEnabled = "FALSE";
            }
            return true;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber ValidateCurrencyType()
        {               
            if (!(DbPLSQLBlock(@"&AO.Currency_Type_API.Exist({0} IN, {1} IN)", this.tblVoucherRow_colsCompany.QualifiedBindName, this.tblVoucherRow_colsCurrencyCode.QualifiedBindName)))
            {
                return false;
            }
                
            if (!(this.GetAttributes(tblVoucherRow_colsCompany.Text, tblVoucherRow_colsCurrencyCode.Text, frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).sCurrencyCode, tblVoucherRow_colsCurrencyType.Text, frmEntryVoucher.FromHandle(
                    Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfdVoucherDate.DateTime)))
            {
                return false;
            }
            tblVoucherRow_colnCurrencyRate.Number = this.GetRate(tblVoucherRow_colsCompany.Text, tblVoucherRow_colsCurrencyCode.Text);
            tblVoucherRow_colnCurrencyRate.EditDataItemSetEdited();
            tblVoucherRow_colnDecimalsInAmount.Number = this.i_nFinTransRound;
            if (!(Sal.IsNull(tblVoucherRow_colnCurrencyAmount)))
            {
                if (!(Sal.SendMsg(tblVoucherRow_colnCurrencyRate, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, 0, 0)))
                {
                    // Don't translate this message, this message only for programmer not user
                    Ifs.Fnd.ApplicationForms.Int.AlertBox("Design time error in colnCurrencyCode !", Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// </summary>
        /// <param name="p_nWhat"></param>
        /// <returns></returns>
        public virtual SalBoolean UM_LaunchPeriodAllocation(SalNumber p_nWhat)
        {
            #region Local Variables
            SalBoolean bAllowed = false;
            SalNumber nRow = 0;
            SalArray<SalString> sArray = new SalArray<SalString>();
            SalArray<SalWindowHandle> hWndArray = new SalArray<SalWindowHandle>();
            SalNumber nIndex = 0;
            #endregion

            #region Actions

            switch (p_nWhat)
            {
                case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                    if (frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfsRevCostClearVoucher.Text == "TRUE")
                    {
                        return false;
                    }                    
                    if (this.tblVoucherRow_colsFunctionGroup.Text == "Z")
                    {
                        return false;
                    }
                    nIndex = Sys.TBL_MinRow;
                    if (Sal.TblFindNextRow(tblVoucherRow, ref nIndex, Sys.ROW_Selected, 0))
                    {
                        if (Sal.TblFindNextRow(tblVoucherRow, ref nIndex, Sys.ROW_Selected, 0))
                        {
                            return false;
                        }
                    }
                    if ( frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).sCancellation == "TRUE" && Sal.TblAnyRows(tblVoucherRow, Sys.ROW_Selected, 0) && Ifs.Fnd.ApplicationForms.Var.Security.IsViewAvailable(
                        "PERIOD_ALLOCATION") && (this.tblVoucherRow_colsPeriodAllocation.Text == "Y"))
                    {
                        return true;
                    }
                    else if (Sal.TblAnyRows(tblVoucherRow, Sys.ROW_Selected, 0) && !(DataSourceSave(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire)) && (frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).sSimulationVoucher == "FALSE") && Ifs.Fnd.ApplicationForms.Var.Security.IsViewAvailable(
                        "PERIOD_ALLOCATION"))
                    {
                        nRow = Sys.TBL_MinRow;
                        bAllowed = false;
                        while (Sal.TblFindNextRow(tblVoucherRow, ref nRow, Sys.ROW_Selected, 0))
                        {
                            Sal.TblSetContext(tblVoucherRow, nRow);
                            if (!(Sal.IsNull(this.tblVoucherRow_colnCurrencyAmount) || this.tblVoucherRow_colnCurrencyAmount.Number == 0) && IsLogicalAccountType() && !(IsLedgerTaxAccount()) && !(this.tblVoucherRow_colnAmount.Number == 0 || Sal.IsNull(this.tblVoucherRow_colnAmount)))
                            {
                                bAllowed = true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        return bAllowed && IsNotExcludedFromVoucherBalance() && (frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).sCancellation != "TRUE");
                    }
                    else
                    {
                        return false;
                    }
                    goto case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute;

                case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                    sArray[0] = "ACCOUNTING_YEAR";
                    sArray[1] = "VOUCHER_TYPE";
                    sArray[2] = "VOUCHER_NO";
                    sArray[3] = "ROW_NO";
                    hWndArray[0] = this.tblVoucherRow_colnAccountingYear;
                    hWndArray[1] = this.tblVoucherRow_colsVoucherType;
                    hWndArray[2] = this.tblVoucherRow_colnVoucherNo;
                    hWndArray[3] = this.tblVoucherRow_colnRowNo;
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("tblVoucherRow", tblVoucherRow, sArray, hWndArray);
                 
                    if (dlgPeriodAllocation.ModalDialog(Ifs.Fnd.ApplicationForms.Int.Explorer.ExplorerForm, frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfsCompany.Text, frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfnAccountingPeriod.Number, frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).sCancellation.Value))
                    {
                        nRow = Sys.TBL_MinRow;
                        sFormName = ":i_hWndFrame." + Ifs.Fnd.ApplicationForms.Int.QualifiedItemNameGet(i_hWndSelf) + ".";
                        while (Sal.TblFindNextRow(tblVoucherRow, ref nRow, Sys.ROW_Selected, Sys.ROW_MarkDeleted))
                        {
                           Sal.TblSetContext(tblVoucherRow, nRow);

                           if (!(DbPLSQLBlock(@"{0} := &AO.Period_Allocation_API.Any_Allocation({1} IN, {2} IN, {3} IN, {4} IN, {5} IN);",
                                                                                this.tblVoucherRow_colsPeriodAllocation.QualifiedBindName,
                                                                                this.tblVoucherRow_colsCompany.QualifiedBindName,
                                                                                this.tblVoucherRow_colsVoucherType.QualifiedBindName,
                                                                                this.tblVoucherRow_colnVoucherNo.QualifiedBindName,
                                                                                this.tblVoucherRow_colnRowNo.QualifiedBindName,
                                                                                this.tblVoucherRow_colnAccountingYear.QualifiedBindName)))
                                                                   
                            {
                                // Don't transfer this message, this message only for programmer, not user
                                Ifs.Fnd.ApplicationForms.Int.AlertBox("Internal Error", Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
                                return false;
                            }
                        }
                    }
                    return true;
            }
            return false;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="hSql"></param>
        /// <returns></returns>
        public virtual SalBoolean DataRecordExecuteModify(SalSqlHandle hSql)
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
            MethodProgressDone();
            if (!(bManualCompleted))
            {
                nContext = Sal.TblQueryContext(tblVoucherRow);
                // Bug 76624, Begin. Changed the server method Check_If_Manual() to Check_If_Not_Excluded_Manual()
                if (Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Internal_Voucher_Util_Pub_API.Check_If_Not_Excluded_Manual") && Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Voucher_Type_API.Get_Use_Manual") && Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable(
                    "Internal_Ledger_Util_Pub_API.Get_Next_Int_Manual_Post_Seq"))
                {
                    IDictionary<string, string> namedBindVariables = new Dictionary<string, string>();
                    namedBindVariables.Add("colsCompany", this.tblVoucherRow_colsCompany.QualifiedBindName);
                    namedBindVariables.Add("colsVoucherType", this.tblVoucherRow_colsVoucherType.QualifiedBindName);
                    namedBindVariables.Add("colsAccount", this.tblVoucherRow_colsAccount.QualifiedBindName);
                    namedBindVariables.Add("colsLedgerIds", this.tblVoucherRow_colsLedgerIds.QualifiedBindName);
                    namedBindVariables.Add("colnInternalSeqNumber", this.tblVoucherRow_colnInternalSeqNumber.QualifiedBindName);
                    namedBindVariables.Add("dfdVoucherDate", ":i_hWndParent.frmEntryVoucher.dfdVoucherDate");
                    
                    if (!(DbPLSQLBlock(@"DECLARE
	                                        ledger_ids_	 VARCHAR2(2000) := NULL;
                                         BEGIN 
                                            IF (&AO.Voucher_Type_API.Get_Use_Manual({colsCompany} IN,{colsVoucherType} IN) = 'TRUE') THEN
		                                       ledger_ids_ := &AO.Internal_Voucher_Util_Pub_API.Check_If_Not_Excluded_Manual({colsCompany} IN,
												     							                                             {colsAccount} IN,
																					                                         {dfdVoucherDate} IN,
																					                                         {colsVoucherType} IN);
                                               {colsLedgerIds} := ledger_ids_;
		                                       IF (ledger_ids_ IS NOT NULL AND {colnInternalSeqNumber} IS NULL) THEN
			                                      {colnInternalSeqNumber} := &AO.Internal_Ledger_Util_Pub_API.Get_Next_Int_Manual_Post_Seq;
                                               END IF;
                                            END IF;
                                         END;",namedBindVariables)))
                    {
                        return false;
                    }
                    
                    // Bug 76624, End
                    tblVoucherRow_colnInternalSeqNumber.EditDataItemSetEdited();
                    if (!(Sal.IsNull(tblVoucherRow_colsLedgerIds)))
                    {
                        tblVoucherRow_colAddInternal.Text = "TRUE";
                    }
                    else
                    {
                        tblVoucherRow_colAddInternal.Text = "FALSE";
                    }
                }
                // Bug 76624, End
                if (tblVoucherRow_colAddInternal.Text == "TRUE")
                {
                    bOk = true;
                    MethodProgressDone();
                    nTokens = ((SalString)tblVoucherRow_colsLedgerIds.Text).Tokenize("", "|", sTokens);
                    p_sAccount = tblVoucherRow_colsAccount.Text;
                    p_nRefRowNo = tblVoucherRow_colnRowNo.Number;
                    p_nAmount = tblVoucherRow_colnAmount.Number;
                    p_nCurrencyAmount = tblVoucherRow_colnCurrencyAmount.Number;
                    p_nCurrRate = tblVoucherRow_colnCurrencyRate.Number;
                    p_nInternalSeq = tblVoucherRow_colnInternalSeqNumber.Number;
                    p_sCorrection = tblVoucherRow_colCorrection.Text;
                    while (nCount < nTokens)
                    {
                        p_sLedger = sTokens[nCount];
                        bOk = ((bool)dlgManualIntPosting.ModalDialog(Ifs.Fnd.ApplicationForms.Int.Explorer.ExplorerForm, tblVoucherRow)) && bOk;
                        nCount = nCount + 1;
                    }
                }
                Sal.TblSetContext(tblVoucherRow, nContext);
            }
            ((cChildTableFin)tblVoucherRow).DataRecordExecuteModify(hSql);
            if (bOk && !(bManualCompleted))
            {
                tblVoucherRow_colAddInternal.Text = "FALSE";
                tblVoucherRow_colsManualAdded.Text = "TRUE";
            }
            return true;
            
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
                    return Sal.TblAnyRows(tblVoucherRow, Sys.ROW_Selected, 0) && (tblVoucherRow_colsManualAdded.Text == "TRUE" || tblVoucherRow_colAddInternal.Text == "TRUE") && (frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).sCancellation != "TRUE");

                case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                    bOk = true;
                    GetInternalSeqNumberIfNull();
                    nTokens = ((SalString)tblVoucherRow_colsLedgerIds.Text).Tokenize("", "|", sTokens);
                    p_sAccount = tblVoucherRow_colsAccount.Text;
                    p_nRefRowNo = tblVoucherRow_colnRowNo.Number;
                    p_nAmount = tblVoucherRow_colnAmount.Number;
                    p_nCurrencyAmount = tblVoucherRow_colnCurrencyAmount.Number;
                    p_nCurrRate = tblVoucherRow_colnCurrencyRate.Number;
                    p_nInternalSeq = tblVoucherRow_colnInternalSeqNumber.Number;
                    p_sCorrection = tblVoucherRow_colCorrection.Text;
                    while (nCount < nTokens)
                    {
                        p_sLedger = sTokens[nCount];
                        bOk = ((bool)dlgManualIntPosting.ModalDialog(Ifs.Fnd.ApplicationForms.Int.Explorer.ExplorerForm, tblVoucherRow)) && bOk;
                        nCount = nCount + 1;
                    }
                    if (bOk)
                    {
                        tblVoucherRow_colAddInternal.Text = "FALSE";
                        tblVoucherRow_colsManualAdded.Text = "TRUE";
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
            nContext = Sal.TblQueryContext(this);
            if (tblVoucherRow_colAddInternal.Text == "TRUE")
            {
                bOk = true;
                GetInternalSeqNumberIfNull();
                MethodProgressDone();
                nTokens = ((SalString)tblVoucherRow_colsLedgerIds.Text).Tokenize("", "|", sTokens);
                p_sAccount = tblVoucherRow_colsAccount.Text;
                p_nRefRowNo = tblVoucherRow_colnRowNo.Number;
                p_nAmount = tblVoucherRow_colnAmount.Number;
                p_nCurrencyAmount = tblVoucherRow_colnCurrencyAmount.Number;
                p_nCurrRate = tblVoucherRow_colnCurrencyRate.Number;
                p_nInternalSeq = tblVoucherRow_colnInternalSeqNumber.Number;
                p_sCorrection = tblVoucherRow_colCorrection.Text;
                while (nCount < nTokens)
                {
                    p_sLedger = sTokens[nCount];
                    bOk = ((bool)dlgManualIntPosting.ModalDialog(Ifs.Fnd.ApplicationForms.Int.Explorer.ExplorerForm, tblVoucherRow)) && bOk;
                    nCount = nCount + 1;
                }
            }
            Sal.TblSetContext(tblVoucherRow, nContext);
            if (bOk)
            {
                tblVoucherRow_colAddInternal.Text = "FALSE";
                tblVoucherRow_colsManualAdded.Text = "TRUE";
            }
            return true;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber GetInternalSeqNumberIfNull()
        {
            #region Local Variables
            SalBoolean bNull = false;
            #endregion

            #region Actions
            if (Sal.IsNull(tblVoucherRow_colnInternalSeqNumber))
            {
                bNull = true;
            }
            else
            {
                bNull = false;
            }
            if (Sal.IsNull(tblVoucherRow_colnInternalSeqNumber) || Sal.IsNull(tblVoucherRow_colsLedgerIds))
            {
                if (Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Internal_Ledger_Util_Pub_API.Get_Next_Int_Manual_Post_Seq"))
                {
                    // Bug 76624, Begin. Changed the server method Check_If_Manual() to Check_If_Not_Excluded_Manual()
                    using (SignatureHints hints = SignatureHints.NewContext())
                    {
                        IDictionary<string, string> namedBindVariables = new Dictionary<string, string>();
                        namedBindVariables.Add("colsCompany", this.tblVoucherRow_colsCompany.QualifiedBindName);
                        namedBindVariables.Add("colsVoucherType", this.tblVoucherRow_colsVoucherType.QualifiedBindName);
                        namedBindVariables.Add("colsAccount", this.tblVoucherRow_colsAccount.QualifiedBindName);
                        namedBindVariables.Add("colsLedgerIds", this.tblVoucherRow_colsLedgerIds.QualifiedBindName);
                        namedBindVariables.Add("colnInternalSeqNumber", this.tblVoucherRow_colnInternalSeqNumber.QualifiedBindName);
                        namedBindVariables.Add("dfdVoucherDate", ":i_hWndParent.frmEntryVoucher.dfdVoucherDate");

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
                                             END;",namedBindVariables)))
                        {
                            return false;
                        }
                    }
                    // Bug 76624, End
                    if (bNull && !(Sal.IsNull(tblVoucherRow_colnInternalSeqNumber)))
                    {
                        tblVoucherRow_colnInternalSeqNumber.EditDataItemSetEdited();
                    }
                }
            }
            this.GetAttributes(tblVoucherRow_colsCompany.Text, tblVoucherRow_colsCurrencyCode.Text, frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).sCurrencyCode, tblVoucherRow_colsCurrencyType.Text, frmEntryVoucher.FromHandle(
                    Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfdVoucherDate.DateTime);
            
            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        // Insert new code here...
        //public override SalNumber vrtActivate(fcURL URL)
        //{
        //    bManualCompleted = false;
        //    return base.Activate(URL);
        //}

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean IsNotExcludedFromVoucherBalance()
        {
            SalBoolean bReturnValue = true;
            SalNumber nPrevContextRow = Sal.TblQueryContext(tblVoucherRow);
            if (Sal.TblAnyRows(tblVoucherRow, Sys.ROW_Selected, 0))
            {
                SalNumber nCurrentRow = Sys.TBL_MinRow;
                while (Sal.TblFindNextRow(tblVoucherRow, ref nCurrentRow, Sys.ROW_Selected, 0))
                {
                    Sal.TblSetContext(tblVoucherRow, nCurrentRow);    
                    DbPLSQLTransaction(@"{0} := &AO.Account_API.Is_Stat_Account( {1} IN,{2} IN );",
                                                this.QualifiedVarBindName("sIsStatAccount"),
                                                this.tblVoucherRow_colsCompany.QualifiedBindName,
                                                this.tblVoucherRow_colsAccount.QualifiedBindName);
                    
                    if (sIsStatAccount == "TRUE")
                    {
                        bReturnValue = false;
                        break;
                    }
                }
            }
            Sal.TblSetContext(tblVoucherRow, nPrevContextRow);
            return bReturnValue;
        }
        #endregion

        #region Window Actions

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblVoucherRow_colsProcessCode_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.tblVoucherRow_colsProcessCode_OnSAM_SetFocus(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblVoucherRow_colsProcessCode_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherRow_colsProcessCode_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (!(Sal.IsNull(this.tblVoucherRow_colsProcessCode)))
            {
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("Account_Process_Code_API.Get_Description", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                    if (!(this.tblVoucherRow_colsProcessCode.DbPLSQLBlock(cSessionManager.c_hSql, ":i_hWndFrame.frmVoucherRow.dfsCodePartDescription := " + cSessionManager.c_sDbPrefix + "Account_Process_Code_API.Get_Description(\r\n" +
                        ":i_hWndFrame.frmVoucherRow.tblVoucherRow_colsCompany, :i_hWndFrame.frmVoucherRow.tblVoucherRow_colsProcessCode )")))
                    {
                        // Don't translate this message, this message only for programmer not user
                        Ifs.Fnd.ApplicationForms.Int.AlertBox("Design time error in tblVoucherRow_colsProcessCode !", Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
                        e.Return = false;
                        return;
                    }
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
        private void tblVoucherRow_colsProcessCode_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (!(Sal.IsNull(this.tblVoucherRow_colsProcessCode)))
            {
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("Voucher_Row_API.Validate_Process_Code__", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                    if (!(this.tblVoucherRow_colsProcessCode.DbPLSQLBlock(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "Voucher_Row_API.Validate_Process_Code__(\r\n" +
                        " :i_hWndFrame.frmVoucherRow.tblVoucherRow_colsCompany,\r\n" +
                        " :i_hWndFrame.frmVoucherRow.tblVoucherRow_colsProcessCode,\r\n" +
                        " :i_hWndParent.frmEntryVoucher.dfdVoucherDate )")))
                    {
                        e.Return = false;
                        return;
                    }
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
        private void tblVoucherRow_colsCurrencyCode_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblVoucherRow_colsCurrencyCode_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherRow_colsCurrencyCode_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam) == Sys.VALIDATE_Cancel)
            {
                e.Return = Sys.VALIDATE_Cancel;
                return;
            }
            if (!(Sal.IsNull(this.tblVoucherRow_colsCurrencyCode)))
            {
                if (!(this.ValidateCurrencyCode()))
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
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblVoucherRow_colsCurrencyType_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblVoucherRow_colsCurrencyType_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherRow_colsCurrencyType_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam) == Sys.VALIDATE_Cancel)
            {
                e.Return = Sys.VALIDATE_Cancel;
                return;
            }
            if (!(Sal.IsNull(this.tblVoucherRow_colsCurrencyType)) && (this.tblVoucherRow_colsCurrencyType.Text != frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(this.tblVoucherRow_colsCurrencyType.i_hWndFrame)).dfsCurrencyType.Text))
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
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblVoucherRow_colnCurrencyDebetAmount_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblVoucherRow_colnCurrencyDebetAmount_OnPM_DataItemValidate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.tblVoucherRow_colnCurrencyDebetAmount_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherRow_colnCurrencyDebetAmount_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.tblVoucherRow_colnCurrencyDebetAmount.Number != Sys.NUMBER_Null)
            {
                if (this.tblVoucherRow_colnCurrencyDebetAmount.Number < 0)
                {
                    this.tblVoucherRow_colnCurrencyDebetAmount.Number = -this.tblVoucherRow_colnCurrencyDebetAmount.Number;
                }
                if (this.tblVoucherRow_colCorrection.Text == "Y")
                {
                    this.tblVoucherRow_colnCurrencyDebetAmount.Number = -this.tblVoucherRow_colnCurrencyDebetAmount.Number;
                }
            }
            if (Sal.IsNull(this.tblVoucherRow_colnCurrencyCreditAmount))
            {
                this.tblVoucherRow_colnCurrencyDebetAmount.Number = this.SetAnotherValue(this.tblVoucherRow_colnCurrencyDebetAmount.Number, this.tblVoucherRow_colnDebetAmount, "CURRENT_AMOUNT");
                if (!(Sal.IsNull(this.tblVoucherRow_colnCreditAmount)))
                {
                    Sal.SendMsg(this.tblVoucherRow_colnCreditAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, SalNumber.Null.ToString(0).ToHandle());
                    Sal.SendMsg(this.tblVoucherRow_colnThirdCurrencyCreditAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, SalNumber.Null.ToString(0).ToHandle());
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
        private void tblVoucherRow_colnCurrencyDebetAmount_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (!(Sal.IsNull(this.tblVoucherRow_colnCurrencyCreditAmount)))
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
        private void tblVoucherRow_colnCurrencyCreditAmount_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblVoucherRow_colnCurrencyCreditAmount_OnPM_DataItemValidate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.tblVoucherRow_colnCurrencyCreditAmount_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherRow_colnCurrencyCreditAmount_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.tblVoucherRow_colnCurrencyCreditAmount.Number != Sys.NUMBER_Null)
            {
                if (this.tblVoucherRow_colnCurrencyCreditAmount.Number < 0)
                {
                    this.tblVoucherRow_colnCurrencyCreditAmount.Number = -this.tblVoucherRow_colnCurrencyCreditAmount.Number;
                }
                if (this.tblVoucherRow_colCorrection.Text == "Y")
                {
                    this.tblVoucherRow_colnCurrencyCreditAmount.Number = -this.tblVoucherRow_colnCurrencyCreditAmount.Number;
                }
            }
            if (Sal.IsNull(this.tblVoucherRow_colnCurrencyDebetAmount))
            {
                this.tblVoucherRow_colnCurrencyCreditAmount.Number = -this.SetAnotherValue(-this.tblVoucherRow_colnCurrencyCreditAmount.Number, this.tblVoucherRow_colnCreditAmount, "CURRENT_AMOUNT");
                if (!(Sal.IsNull(this.tblVoucherRow_colnDebetAmount)))
                {
                    Sal.SendMsg(this.tblVoucherRow_colnDebetAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, SalNumber.Null.ToString(0).ToHandle());
                    Sal.SendMsg(this.tblVoucherRow_colnThirdCurrencyDebitAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, SalNumber.Null.ToString(0).ToHandle());
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
        private void tblVoucherRow_colnCurrencyCreditAmount_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (!(Sal.IsNull(this.tblVoucherRow_colnCurrencyDebetAmount)))
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
        private void tblVoucherRow_colnCurrencyAmount_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblVoucherRow_colnCurrencyAmount_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherRow_colnCurrencyAmount_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if ((this.tblVoucherRow_colnCurrencyAmount.Number < 0 && this.tblVoucherRow_colCorrection.Text == "Y") || (this.tblVoucherRow_colnCurrencyAmount.Number >= 0 && this.tblVoucherRow_colCorrection.Text == "N"))
            {
                this.tblVoucherRow_colnCurrencyDebetAmount.Number = this.SetAnotherValue(this.tblVoucherRow_colnCurrencyAmount.Number, this.tblVoucherRow_colnDebetAmount, "CURRENT_AMOUNT");
                this.tblVoucherRow_colnCurrencyDebetAmount.EditDataItemSetEdited();
                Sal.SendMsg(this.tblVoucherRow_colnCurrencyCreditAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, SalNumber.Null.ToString(0).ToHandle());
                Sal.SendMsg(this.tblVoucherRow_colnCreditAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, SalNumber.Null.ToString(0).ToHandle());
            }
            else
            {
                this.tblVoucherRow_colnCurrencyCreditAmount.Number = -this.SetAnotherValue(this.tblVoucherRow_colnCurrencyAmount.Number, this.tblVoucherRow_colnCreditAmount, "CURRENT_AMOUNT");
                this.tblVoucherRow_colnCurrencyCreditAmount.EditDataItemSetEdited();
                Sal.SendMsg(this.tblVoucherRow_colnCurrencyDebetAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, SalNumber.Null.ToString(0).ToHandle());
                Sal.SendMsg(this.tblVoucherRow_colnDebetAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, SalNumber.Null.ToString(0).ToHandle());
            }
            Sal.SetFieldEdit(this.tblVoucherRow_colnCurrencyAmount.i_hWndSelf, false);
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblVoucherRow_colnCurrencyRate_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.tblVoucherRow_colnCurrencyRate_OnSAM_SetFocus(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblVoucherRow_colnCurrencyRate_OnPM_DataItemValidate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.tblVoucherRow_colnCurrencyRate_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherRow_colnCurrencyRate_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.tblVoucherRow_colnCurrencyRate.Number != Sys.NUMBER_Null)
            {
                this.nPrevRate = this.tblVoucherRow_colnCurrencyRate.Number;
            }
            e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherRow_colnCurrencyRate_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.tblVoucherRow_colnCurrencyRate.Number < 0 && this.tblVoucherRow_colnCurrencyRate.Number != Sys.NUMBER_Null)
            {
                this.tblVoucherRow_colnCurrencyRate.Number = -this.tblVoucherRow_colnCurrencyRate.Number;
            }
            if (this.tblVoucherRow_colnCurrencyAmount.Number != 0 && this.tblVoucherRow_colnCurrencyAmount.Number != Sys.NUMBER_Null)
            {
                this.tblVoucherRow_colnCurrencyRate.Number = this.SetAnotherValue(this.tblVoucherRow_colnCurrencyRate.Number, this.tblVoucherRow_colnCurrencyAmount, "RATE");
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherRow_colnCurrencyRate_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if ((((SalString)this.tblVoucherRow_colsTransCode.Text).Trim().ToUpper() != "MANUAL") || (((SalString)this.tblVoucherRow_colsCurrencyCode.Text).Trim().ToUpper() == frmEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(this.tblVoucherRow_colnCurrencyRate.i_hWndFrame)).sCurrencyCode.Trim().ToUpper()) ||
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
        private void tblVoucherRow_colnDebetAmount_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.tblVoucherRow_colnDebetAmount_OnSAM_SetFocus(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblVoucherRow_colnDebetAmount_OnPM_DataItemValidate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.tblVoucherRow_colnDebetAmount_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherRow_colnDebetAmount_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.tblVoucherRow_colnDebetAmount.Number != Sys.NUMBER_Null)
            {
                this.nPrevAmount = this.tblVoucherRow_colnDebetAmount.Number;
            }
            e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherRow_colnDebetAmount_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.tblVoucherRow_colnDebetAmount.Number != Sys.NUMBER_Null)
            {
                if (this.tblVoucherRow_colnDebetAmount.Number < 0)
                {
                    this.tblVoucherRow_colnDebetAmount.Number = -this.tblVoucherRow_colnDebetAmount.Number;
                }
                if (this.tblVoucherRow_colCorrection.Text == "Y")
                {
                    this.tblVoucherRow_colnDebetAmount.Number = -this.tblVoucherRow_colnDebetAmount.Number;
                }
            }
            if (Sal.IsNull(this.tblVoucherRow_colnCreditAmount))
            {
                this.tblVoucherRow_colnDebetAmount.Number = this.SetAnotherValue(this.tblVoucherRow_colnDebetAmount.Number, this.tblVoucherRow_colnCurrencyDebetAmount, "ACCOUNTING_AMOUNT");
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherRow_colnDebetAmount_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (!(Sal.IsNull(this.tblVoucherRow_colnCreditAmount)))
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
        private void tblVoucherRow_colnCreditAmount_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.tblVoucherRow_colnCreditAmount_OnSAM_SetFocus(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblVoucherRow_colnCreditAmount_OnPM_DataItemValidate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.tblVoucherRow_colnCreditAmount_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherRow_colnCreditAmount_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.tblVoucherRow_colnCreditAmount.Number != Sys.NUMBER_Null)
            {
                this.nPrevAmount = this.tblVoucherRow_colnCreditAmount.Number;
            }
            e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherRow_colnCreditAmount_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.tblVoucherRow_colnCreditAmount.Number != Sys.NUMBER_Null)
            {
                if (this.tblVoucherRow_colnCreditAmount.Number < 0)
                {
                    this.tblVoucherRow_colnCreditAmount.Number = -this.tblVoucherRow_colnCreditAmount.Number;
                }
                if (this.tblVoucherRow_colCorrection.Text == "Y")
                {
                    this.tblVoucherRow_colnCreditAmount.Number = -this.tblVoucherRow_colnCreditAmount.Number;
                }
            }
            if (Sal.IsNull(this.tblVoucherRow_colnDebetAmount))
            {
                this.tblVoucherRow_colnCreditAmount.Number = -this.SetAnotherValue(-this.tblVoucherRow_colnCreditAmount.Number, this.tblVoucherRow_colnCurrencyCreditAmount, "ACCOUNTING_AMOUNT");
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherRow_colnCreditAmount_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (!(Sal.IsNull(this.tblVoucherRow_colnDebetAmount)))
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
        private void tblVoucherRow_colnAmount_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.tblVoucherRow_colnAmount_OnSAM_SetFocus(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblVoucherRow_colnAmount_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherRow_colnAmount_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.tblVoucherRow_colnAmount.Number != Sys.NUMBER_Null)
            {
                this.nPrevAmount = this.tblVoucherRow_colnAmount.Number;
            }
            e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherRow_colnAmount_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            using (SignatureHints hints = SignatureHints.NewContext())
            {
                hints.Add("Company_Finance_API.Get_Currency_Code", System.Data.ParameterDirection.Input);
                this.tblVoucherRow_colnAmount.DbPLSQLBlock(cSessionManager.c_hSql, ":i_hWndFrame.frmVoucherRow.sCurrCode := " + cSessionManager.c_sDbPrefix + "Company_Finance_API.Get_Currency_Code(\r\n" +
                    ":i_hWndFrame.frmVoucherRow.tblVoucherRow_colsCompany )");
            }
            if ((this.tblVoucherRow_colnAmount.Number < 0 && this.tblVoucherRow_colCorrection.Text == "Y") || (this.tblVoucherRow_colnAmount.Number >= 0 && this.tblVoucherRow_colCorrection.Text == "N"))
            {
                this.tblVoucherRow_colnDebetAmount.Number = this.SetAnotherValue(this.tblVoucherRow_colnAmount.Number, this.tblVoucherRow_colnCurrencyDebetAmount, "ACCOUNTING_AMOUNT");
                this.tblVoucherRow_colnDebetAmount.EditDataItemSetEdited();
                Sal.SendMsg(this.tblVoucherRow_colnCreditAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, SalNumber.Null.ToString(0).ToHandle());
                if (this.tblVoucherRow_colsCurrencyCode.Text == this.sCurrCode)
                {
                    this.tblVoucherRow_colnCurrencyDebetAmount.Number = this.tblVoucherRow_colnDebetAmount.Number;
                    this.tblVoucherRow_colnCurrencyDebetAmount.EditDataItemSetEdited();
                    this.tblVoucherRow_colnCurrencyAmount.Number = this.tblVoucherRow_colnDebetAmount.Number;
                    this.tblVoucherRow_colnCurrencyAmount.EditDataItemSetEdited();
                    this.tblVoucherRow_colnCurrencyCreditAmount.Number = Sys.NUMBER_Null;
                    this.tblVoucherRow_colnCurrencyCreditAmount.EditDataItemSetEdited();
                    if (this.tblVoucherRow_colnCreditAmount.Number == Sys.NUMBER_Null)
                    {
                        this.tblVoucherRow_colnCurrencyDebetAmount.Number = this.tblVoucherRow_colnDebetAmount.Number;
                        this.tblVoucherRow_colnCurrencyDebetAmount.EditDataItemSetEdited();
                        this.tblVoucherRow_colnCurrencyAmount.Number = this.tblVoucherRow_colnDebetAmount.Number;
                        this.tblVoucherRow_colnCurrencyAmount.EditDataItemSetEdited();
                        this.tblVoucherRow_colnCurrencyCreditAmount.Number = Sys.NUMBER_Null;
                        this.tblVoucherRow_colnCurrencyCreditAmount.EditDataItemSetEdited();
                    }
                    else
                    {
                        this.tblVoucherRow_colnCurrencyCreditAmount.Number = this.tblVoucherRow_colnCreditAmount.Number;
                        this.tblVoucherRow_colnCurrencyCreditAmount.EditDataItemSetEdited();
                        this.tblVoucherRow_colnCurrencyAmount.Number = -this.tblVoucherRow_colnCreditAmount.Number;
                        this.tblVoucherRow_colnCurrencyAmount.EditDataItemSetEdited();
                        this.tblVoucherRow_colnCurrencyDebetAmount.Number = Sys.NUMBER_Null;
                        this.tblVoucherRow_colnCurrencyDebetAmount.EditDataItemSetEdited();
                    }
                }
            }
            else
            {
                this.tblVoucherRow_colnCreditAmount.Number = -this.SetAnotherValue(this.tblVoucherRow_colnAmount.Number, this.tblVoucherRow_colnCurrencyCreditAmount, "ACCOUNTING_AMOUNT");
                this.tblVoucherRow_colnCreditAmount.EditDataItemSetEdited();
                Sal.SendMsg(this.tblVoucherRow_colnDebetAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, SalNumber.Null.ToString(0).ToHandle());
                if (this.tblVoucherRow_colsCurrencyCode.Text == this.sCurrCode)
                {
                    this.tblVoucherRow_colnCurrencyCreditAmount.Number = this.tblVoucherRow_colnCreditAmount.Number;
                    this.tblVoucherRow_colnCurrencyCreditAmount.EditDataItemSetEdited();
                    this.tblVoucherRow_colnCurrencyAmount.Number = -this.tblVoucherRow_colnCreditAmount.Number;
                    this.tblVoucherRow_colnCurrencyAmount.EditDataItemSetEdited();
                    this.tblVoucherRow_colnCurrencyDebetAmount.Number = Sys.NUMBER_Null;
                    this.tblVoucherRow_colnCurrencyDebetAmount.EditDataItemSetEdited();
                }
            }
            Sal.SetFieldEdit(this.tblVoucherRow_colnAmount.i_hWndSelf, false);
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblVoucherRow_colsTextId_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblVoucherRow_colsTextId_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherRow_colsTextId_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            using (SignatureHints hints = SignatureHints.NewContext())
            {
                hints.Add("Voucher_Text_API.Get_Description", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                if (!(this.tblVoucherRow_colsTextId.DbPLSQLBlock(cSessionManager.c_hSql, ":i_hWndFrame.frmVoucherRow.tblVoucherRow_colsText := substr(" + cSessionManager.c_sDbPrefix + "Voucher_Text_API.Get_Description( " + ":i_hWndFrame.frmVoucherRow.tblVoucherRow_colsCompany," +
                    " :i_hWndFrame.frmVoucherRow.tblVoucherRow_colsTextId ),1,200)")))
                {
                    e.Return = false;
                    return;
                }
            }
            Sal.SetFieldEdit(this.tblVoucherRow_colsTextId, false);
            Sal.SetFieldEdit(this.tblVoucherRow_colsText, true);
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblVoucherRow_colnProjectActivityId_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.tblVoucherRow_colnProjectActivityId_OnSAM_SetFocus(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherRow_colnProjectActivityId_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.IsNull(this.tblVoucherRow_colnProjectActivityId))
            {
                if (this.tblVoucherRow_colsProjectActivityIdEnabled.Text == "Y")
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
        #endregion

        #region Window Events

        private void tblVoucherRow_DataRecordCheckRequiredEvent(object sender, FndReturnEventArgsSalBoolean e)
        {
            e.Handled = true;
            e.ReturnValue = this.DataRecordCheckRequired();
        }

        private void tblVoucherRow_DataRecordDuplicateEvent(object sender, cDataSource.DataRecordDuplicateEventArgs e)
        {
            e.Handled = true;
            e.ReturnValue = this.DataRecordDuplicate(e.nWhat);
        }

        private void tblVoucherRow_DataRecordExecuteModifyEvent(object sender, cDataSource.DataRecordExecuteModifyEventArgs e)
        {
            e.Handled = true;
            e.ReturnValue = this.DataRecordExecuteModify(e.hSql);
        }

        private void tblVoucherRow_DataRecordGetDefaultsEvent(object sender, FndReturnEventArgsSalBoolean e)
        {
            e.Handled = true;
            e.ReturnValue = this.DataRecordGetDefaults();
        }

        private void tblVoucherRow_DataRecordNewEvent(object sender, cDataSource.DataRecordNewEventArgs e)
        {
            e.Handled = true;
            e.ReturnValue = this.DataRecordNew(e.nWhat);
        }

        private void tblVoucherRow_DataRecordRemoveEvent(object sender, cDataSource.DataRecordRemoveEventArgs e)
        {
            e.Handled = true;
            e.ReturnValue = this.DataRecordNew(e.nWhat);
        }

        private void tblVoucherRow_DataRecordValidateEvent(object sender, FndReturnEventArgsSalBoolean e)
        {
            e.Handled = true;
            e.ReturnValue = this.DataRecordValidate();
        }

        private void tblVoucherRow_DataSourceFormatSqlColumnUserEvent(object sender, FndReturnEventArgsSalString e)
        {
            e.Handled = true;
            e.ReturnValue = this.DataSourceFormatSqlColumnUser();
        }

        private void tblVoucherRow_DataSourceFormatSqlIntoUserEvent(object sender, FndReturnEventArgsSalString e)
        {
            e.Handled = true;
            e.ReturnValue = this.DataSourceFormatSqlIntoUser();
        }

        private void tblVoucherRow_EnableDisableProjectActivityIdEvent(object sender, cChildTableFin.cChildTableFinEventArgs e)
        {
            e.Handled = true;
            e.ReturnValue = EnableDisableProjectActivityId(e.sCodePartValue);
        }
        
        #endregion
        #endregion

        #region Event Handlers

        private void menuItem_Period_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = this.UM_LaunchPeriodAllocation(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire) && tblVoucherRow_colsTransCode.Text != "INTERIM";
        }

        private void menuItem_Period_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            this.UM_LaunchPeriodAllocation(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem_Internal_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = this.UM_IntManualPostings(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem_Internal_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            this.UM_IntManualPostings(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem__Add_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = this.AddPseudoCode(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem__Add_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            this.AddPseudoCode(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        #endregion


    }
}
