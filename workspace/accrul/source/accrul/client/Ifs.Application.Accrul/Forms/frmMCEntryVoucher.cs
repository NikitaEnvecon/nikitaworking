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
    [FndWindowRegistration("MULTI_COMPANY_VOUCHER2", "MultiCompanyVoucher")]
    [FndWindowRegistration("MULTI_COMPANY_VOUCHER_ROW2", "MultiCompanyVoucherRow")]
    public partial class frmMCEntryVoucher : cMasterDetailTabFormWindowFin
    {
        #region Window Variables
        public SalString sCurrencyCode = "";
        public SalString sDummyVoucherType = "";
        public SalString sFormName = "";
        public SalString sResult = "";
        public SalString sVoucherType = "";
        public SalString sSimulationVoucher = "";
        public SalString lsAutomatic = "";
        public SalDateTime dVoucherDate = SalDateTime.Null;
        public SalNumber nAccountingPeriod = 0;
        public SalNumber nAccountingYear = 0;
        public SalNumber nDecimalsInAmount = 0;
        public SalNumber nDecimalsInRate = 0;
        public SalNumber nReturn = 0;
        public SalNumber nCntRow = 0;
        public SalNumber nYearYep = 0;
        public SalNumber nPeriodYep = 0;
        public SalWindowHandle hWndFirstTab = SalWindowHandle.Null;
        public SalNumber nCurrentRow = 0;
        public SalString sManualFound = "";
        public SalString sWarningRaised = "";
        public SalString sTextId = "";
        public SalNumber nVoucherNo = 0;
        public SalString sVType = "";
        public SalString sRowText = "";
        public SalNumber nYear = 0;
        public SalString sNoteExist = "";
        public SalString sAuthLevel = "";
        public cMessage Msg = new cMessage();
        #endregion
        private static SalString ValidateUserGroup_sPrevUserGroup = "";

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public frmMCEntryVoucher()
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
        public new static frmMCEntryVoucher FromHandle(SalWindowHandle handle)
        {
            return ((frmMCEntryVoucher)SalWindow.FromHandle(handle, typeof(frmMCEntryVoucher)));
        }
        #endregion

        #region Methods

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public new SalBoolean FrameStartupUser()
        {
            #region Local Variables
            SalNumber nRows = 0;
            SalNumber nPosAccount = 0;
            SalString sValue = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                hWndFirstTab = TabAttachedWindowHandleGet(picTab.FindName("MCVouRow"));
                Ifs.Fnd.ApplicationForms.Var.Profile.ValueStringGet("frmMCVoucherRow.tblVoucherRow", "ColLockNumber", "8888", ref sValue);
                if (sValue == "8888")
                {
                    nPosAccount = Sal.TblQueryColumnPos(frmMCVoucherRow.FromHandle(hWndFirstTab).tblVoucherRow_colsAccount);
                    Sal.TblSetLockedColumns(frmMCVoucherRow.FromHandle(hWndFirstTab).tblVoucherRow, nPosAccount);
                }
                return true;
            }
            #endregion
        }
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public override SalNumber vrtActivate(fcURL URL)
        {
            #region Local Variables
            SalNumber nRows = 0;
            SalNumber nPosAccount = 0;
            SalString sValue = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                nRows = Ifs.Fnd.ApplicationForms.Var.DataTransfer.RecCountGet();
                hWndFirstTab = TabAttachedWindowHandleGet(picTab.FindName("MCVouRow"));

                if (nRows > 0 && Ifs.Fnd.ApplicationForms.Var.DataTransfer.SourceNameGet() == "VOUCHER")
                {
                    Sal.WaitCursor(true);
                    InitFromTransferedData();
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();
                    Sal.WaitCursor(false);
                    StartupDbCalls();
                    return false;
                }
                StartupDbCalls();
                return base.Activate(URL);
            }
            #endregion

        }

        /// <summary>
        /// Returns TRUE, if there are ANY rows in voucher rows table
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean AreVoucherRows()
        {
            #region Actions
            using (new SalContext(this))
            {
                return Sal.TblAnyRows(frmMCVoucherRow.FromHandle(hWndFirstTab).tblVoucherRow, 0, 0);
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean CheckHomeCompanyRow()
        {
            #region Local Variables
            SalNumber nRow = 0;
            SalNumber nRowAtHome = 0;
            SalNumber nCurrentRow = 0;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                nRow = Sys.TBL_MinRow;
                nRowAtHome = 0;
                nCurrentRow = Sal.TblQueryContext(frmMCVoucherRow.FromHandle(hWndFirstTab).tblVoucherRow);
                while (Sal.TblFindNextRow(frmMCVoucherRow.FromHandle(hWndFirstTab).tblVoucherRow, ref nRow, 0, Sys.ROW_MarkDeleted))
                {
                    Sal.TblSetContext(frmMCVoucherRow.FromHandle(hWndFirstTab).tblVoucherRow, nRow);
                    if (frmMCVoucherRow.FromHandle(hWndFirstTab).tblVoucherRow_colsCompany.Text == i_sCompany)
                    {
                        nRowAtHome = nRowAtHome + 1;
                    }
                }
                Sal.TblSetContext(frmMCVoucherRow.FromHandle(hWndFirstTab).tblVoucherRow, nCurrentRow);
                if (nRowAtHome == 0)
                {
                    return false;
                }
                return true;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="hSql"></param>
        /// <returns></returns>
        public new SalBoolean DataRecordExecuteNew(SalSqlHandle hSql)
        {
            #region Actions
            using (new SalContext(this))
            {
                if (lsAutomatic == "Y")
                {
                    if (dfnVoucherNo.Number != 0)
                    {
                        dfnVoucherNo.Number = 0;
                    }
                    dfnVoucherNo.EditDataItemSetEdited();
                    if (((cMasterDetailTabFormWindow)this).DataRecordExecuteNew(hSql))
                    {
                        frmMCVoucherRow.FromHandle(hWndFirstTab).SetVoucherNo(dfnVoucherNo.Number);
                        return true;
                    }
                }
                else
                {
                    return ((cMasterDetailTabFormWindow)this).DataRecordExecuteNew(hSql);
                }
            }

            return false;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="hSql"></param>
        /// <returns></returns>
        public new SalBoolean DataRecordExecuteModify(SalSqlHandle hSql)
        {
            #region Actions
            using (new SalContext(this))
            {
                frmMCVoucherRow.FromHandle(hWndFirstTab).SetAccountingPeriod(dfnAccountingPeriod.Number);
                return ((cMasterDetailTabFormWindow)this).DataRecordExecuteModify(hSql);
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public new SalBoolean DataRecordValidate()
        {
            #region Local Variables
            SalNumber nCurrencyBalanceIndex = 0;
            SalNumber nMaxIndex = 0;
            SalNumber nIndex = 0;
            SalNumber nRow = 0;
            SalNumber nCurrentRow = 0;
            SalBoolean BalanceOk = false;
            SalBoolean CurrencyBalanceOk = false;
            SalString sCompanyNotBalance = "";
            SalArray<SalString> sParam = new SalArray<SalString>();
            SalString sVoucherCompany = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                if (((cDataSource)this).DataRecordValidate())
                {
                    if (Sal.IsNull(dfnCurrencyBalance))
                    {
                        dfnCurrencyBalance.Number = 0;
                    }
                    if (Sal.IsNull(dfnBalance))
                    {
                        dfnBalance.Number = 0;
                    }
                    nIndex = 0;
                    BalanceOk = true;
                    CurrencyBalanceOk = true;
                    nMaxIndex = Sal.ListQueryCount(frmMCVoucherRow.FromHandle(hWndFirstTab).cmbsVoucherCompany);
                    while (nIndex <= nMaxIndex)
                    {
                        dfnCurrencyBalance.Number = 0;
                        dfnBalance.Number = 0;
                        nRow = Sys.TBL_MinRow;
                        sVoucherCompany = Sal.ListQueryTextX(frmMCVoucherRow.FromHandle(hWndFirstTab).cmbsVoucherCompany, nIndex);
                        nCurrentRow = Sal.TblQueryContext(frmMCVoucherRow.FromHandle(hWndFirstTab).tblVoucherRow);
                        while (Sal.TblFindNextRow(frmMCVoucherRow.FromHandle(hWndFirstTab).tblVoucherRow, ref nRow, 0, Sys.ROW_MarkDeleted))
                        {
                            Sal.TblSetContext(frmMCVoucherRow.FromHandle(hWndFirstTab).tblVoucherRow, nRow);
                            if (sVoucherCompany == frmMCVoucherRow.FromHandle(hWndFirstTab).tblVoucherRow_colsCompany.Text)
                            {
                                dfnCurrencyBalance.Number = dfnCurrencyBalance.Number + frmMCVoucherRow.FromHandle(hWndFirstTab).tblVoucherRow_colnCurrencyAmount.Number;
                                dfnBalance.Number = dfnBalance.Number + frmMCVoucherRow.FromHandle(hWndFirstTab).tblVoucherRow_colnAmount.Number;
                            }
                        }
                        Sal.TblSetContext(frmMCVoucherRow.FromHandle(hWndFirstTab).tblVoucherRow, nCurrentRow);
                        if (dfnBalance.Number != 0)
                        {
                            BalanceOk = false;
                            break;
                        }
                        if (dfnCurrencyBalance.Number != 0)
                        {
                            nCurrencyBalanceIndex = nIndex;
                            CurrencyBalanceOk = false;
                        }
                        nIndex = nIndex + 1;
                    }
                    if (!(BalanceOk))
                    {
                        sParam[1] = sVoucherCompany;
                        Ifs.Fnd.ApplicationForms.Int.AlertBoxWithParams(Properties.Resources.TEXT_MCVoEn_AlertBalance, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok, sParam);
                        return false;
                    }
                    if (!(CurrencyBalanceOk))
                    {
                        sCompanyNotBalance = Sal.ListQueryTextX(frmMCVoucherRow.FromHandle(hWndFirstTab).cmbsVoucherCompany, nCurrencyBalanceIndex);
                        if (Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_MCVoEn_AlertBalanceCurr + sCompanyNotBalance, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_OkCancel) != Sys.IDOK)
                        {
                            return false;
                        }
                    }
                    return true;
                }
                return false;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public new SalBoolean DataSourceSaveCheckOk()
        {
            #region Actions
            using (new SalContext(this))
            {
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("Multi_Company_Voucher_API.Voucher_Save_Ok", System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                    if (!(DbPLSQLBlock(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "Multi_Company_Voucher_API.Voucher_Save_Ok(\r\n" +
                        "                        :i_hWndFrame.frmMCEntryVoucher.sResult,\r\n" +
                        "                        :i_hWndFrame.frmMCEntryVoucher.dfsCompany,\r\n" +
                        "                        :i_hWndFrame.frmMCEntryVoucher.ccsVoucherType.i_sMyValue,\r\n" +
                        "                        :i_hWndFrame.frmMCEntryVoucher.dfnVoucherNo,\r\n" +
                        "                        :i_hWndFrame.frmMCEntryVoucher.dfnAccountingYear)")))
                    {
                        if (lsAutomatic == "Y")
                        {
                            dfnVoucherNo.Number = 0;
                            dfnVoucherNo.EditDataItemSetEdited();
                        }
                        return false;
                    }
                }
                if (sResult == "FALSE")
                {
                    Ifs.Fnd.ApplicationForms.Int.ErrorBox(Properties.Resources.VOUCHER_MCNoRows);
                    return false;
                }
                return true;
            }
            #endregion
        }

        /// <summary>
        /// All the server calls needed at startup were included here
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean StartupDbCalls()
        {
            #region Local Variables
            SalString lsStmt = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                sFormName = ":i_hWndFrame." + Ifs.Fnd.ApplicationForms.Int.QualifiedItemNameGet(i_hWndSelf) + ".";
                lsStmt = "Select SYSDATE into " + sFormName + "dVoucherDate from DUAL;";
                lsStmt = lsStmt + "Curr_Code := " + cSessionManager.c_sDbPrefix + "Company_Finance_API.Get_Currency_Code(" + sFormName + "i_sCompany );";
                lsStmt = lsStmt + sFormName + "sCurrencyCode := Curr_Code;";
                lsStmt = lsStmt + sFormName + "nDecimalsInAmount := NVL( " + cSessionManager.c_sDbPrefix + "Currency_Code_API.Get_Currency_Rounding(" + sFormName + "i_sCompany, Curr_Code	), 0); ";
                lsStmt = lsStmt + sFormName + "nDecimalsInRate := NVL( " + cSessionManager.c_sDbPrefix + "Currency_Code_API.Get_No_Of_Decimals_In_Rate(" + sFormName + "i_sCompany, Curr_Code), 0); ";
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("Company_Finance_API.Get_Currency_Code", System.Data.ParameterDirection.Input);
                    hints.Add("Currency_Code_API.Get_Currency_Rounding", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                    hints.Add("Currency_Code_API.Get_No_Of_Decimals_In_Rate", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                    if (!(DbPLSQLBlock(cSessionManager.c_hSql, "DECLARE Curr_Code VARCHAR2(20); BEGIN " + lsStmt + "END;")))
                    {
                        return false;
                    }
                }
                return true;
            }
            #endregion
        }

        /// <summary>
        /// call dialog to enter free text
        /// </summary>
        /// <param name="p_nWhat"></param>
        /// <returns></returns>
        public virtual SalBoolean UM_FreeText(SalNumber p_nWhat)
        {
            #region Local Variables
            // Bug 77430,  removed IsText
            // Bug 77430, Begin, added some variables
            SalString sRS = "";
            SalString sKeyAttr = "";
            SalString sPackageName = "";
            SalArray<SalString> sNotes = new SalArray<SalString>();
            SalNumber nTempNoteId = 0;
            // Bug 77430, End
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                switch (p_nWhat)
                {
                    // Bug 77430, Begin, changed METHOD_Inquire

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        if (dfsCompany.Text == Ifs.Fnd.ApplicationForms.Const.strNULL || dfnVoucherNo.Number < 1)
                        {
                            return false;
                        }
                        return true;

                    // Bug 77430, End

                    // Bug 77430, Begin, changed METHOD_Execute

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        sRS = ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_RS).ToCharacter();
                        sPackageName = "VOUCHER_NOTE_API";
                        Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("COMPANY", dfsCompany.Text, ref sKeyAttr);
                        Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("ACCOUNTING_YEAR", dfnAccountingYear.Number.ToString(0), ref sKeyAttr);
                        Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("VOUCHER_TYPE", ccsVoucherType.i_sMyValue, ref sKeyAttr);
                        Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("VOUCHER_NO", dfnVoucherNo.Number.ToString(0), ref sKeyAttr);
                        sNotes[0] = sPackageName + sRS + Properties.Resources.USER_Voucher_Notes + sRS + sKeyAttr;
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.SourceNameSet("NotesData");
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemAdd("NotesData", sNotes);
                        dlgNotes.ModalDialog(Ifs.Fnd.ApplicationForms.Int.Explorer.ExplorerForm);
                        // Update Notes check box
                        using (SignatureHints hints = SignatureHints.NewContext())
                        {
                            hints.Add("Voucher_Note_API.Check_Note_Exist", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                            DbPLSQLBlock(cSessionManager.c_hSql, ":i_hWndFrame.frmMCEntryVoucher.sNoteExist := &AO.Voucher_Note_API.Check_Note_Exist(\r\n" +
                                "				:i_hWndFrame.frmMCEntryVoucher.dfsCompany,\r\n" +
                                "				:i_hWndFrame.frmMCEntryVoucher.dfnAccountingYear,\r\n" +
                                "			                :i_hWndFrame.frmMCEntryVoucher.ccsVoucherType.i_sMyValue,\r\n" +
                                "                                                                :i_hWndFrame.frmMCEntryVoucher.dfnVoucherNo)");
                        }
                        if (sNoteExist == "TRUE")
                        {
                            cbFreeText.Checked = true;
                        }
                        else
                        {
                            cbFreeText.Checked = false;
                        }
                        return true;

                    // Bug 77430, End
                }
            }

            return false;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber ValidateUserGroup()
        {
            #region Actions
            using (new SalContext(this))
            {
                if (dfsUserGroup.Text != ValidateUserGroup_sPrevUserGroup)
                {
                    using (SignatureHints hints = SignatureHints.NewContext())
                    {
                        hints.Add("Voucher_Type_API.Get_Voucher_Group", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                        if (!(DbPLSQLBlock(cSessionManager.c_hSql, sFormName + "dfsVoucherGroup  := " + cSessionManager.c_sDbPrefix + "Voucher_Type_API.Get_Voucher_Group( " + sFormName + "dfsCompany," + sFormName + "ccsVoucherType.i_sMyValue )")))
                        {
                            return Sys.VALIDATE_Cancel;
                        }
                    }
                    if (dfsVoucherGroup.Text == "M" || dfsVoucherGroup.Text == "Q" || dfsVoucherGroup.Text == "K")
                    {
                        using (SignatureHints hints = SignatureHints.NewContext())
                        {
                            hints.Add("Voucher_Type_User_Group_Api.Get_Default_Voucher_Type", System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                            if (!(DbPLSQLBlock(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "Voucher_Type_User_Group_Api.Get_Default_Voucher_Type( " + sFormName + "sVoucherType," + sFormName + "dfsCompany," + sFormName + "dfsUserGroup," + sFormName + "dfnAccountingYear, 'M' )")))
                            {
                                return Sys.VALIDATE_Cancel;
                            }
                        }
                        ccsVoucherType.EditDataItemValueSet(1, sVoucherType.ToHandle());
                        ValidateVoucherType();
                    }
                    return Sys.VALIDATE_Ok;
                }
                return Sys.VALIDATE_Ok;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean ValidateVoucherDate()
        {
            #region Actions
            using (new SalContext(this))
            {
                if (dfdVoucherDate.DateTime != Sys.DATETIME_Null)
                {
                    nAccountingYear = dfnAccountingYear.Number;
                    nAccountingPeriod = dfnAccountingPeriod.Number;
                    using (SignatureHints hints = SignatureHints.NewContext())
                    {
                        hints.Add("Accounting_Period_Api.Get_Accounting_Year", System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                        hints.Add("Accounting_Period_Api.Get_YearPer_For_YearEnd_User", System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                        if (!(DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN\r\n" +
                            "				&AO.Accounting_Period_Api.Get_Accounting_Year(\r\n" +
                            "					:i_hWndFrame.frmMCEntryVoucher.nAccountingYear,\r\n" +
                            "					:i_hWndFrame.frmMCEntryVoucher.nAccountingPeriod,\r\n" +
                            "					:i_hWndFrame.frmMCEntryVoucher.dfsCompany,\r\n" +
                            "					:i_hWndFrame.frmMCEntryVoucher.dfdVoucherDate,\r\n" +
                            "					:i_hWndFrame.frmMCEntryVoucher.dfsUserGroup );\r\n" +
                            "				&AO.Accounting_Period_Api.Get_YearPer_For_YearEnd_User(\r\n" +
                            "					:i_hWndFrame.frmMCEntryVoucher.nYearYep,\r\n" +
                            "					:i_hWndFrame.frmMCEntryVoucher.nPeriodYep,\r\n" +
                            "					:i_hWndFrame.frmMCEntryVoucher.dfsCompany,\r\n" +
                            "					:i_hWndFrame.frmMCEntryVoucher.dfsUserGroup,\r\n" +
                            "					:i_hWndFrame.frmMCEntryVoucher.dfdVoucherDate );\r\n" +
                            "			     END;")))
                        {
                            return false;
                        }
                    }
                    if ((nYearYep != 0) && (nPeriodYep != 0))
                    {
                        nAccountingYear = nYearYep;
                        nAccountingPeriod = nPeriodYep;
                    }
                    dfnAccountingYear.EditDataItemValueSet(1, nAccountingYear.ToString(0).ToHandle());
                    dfnAccountingPeriod.EditDataItemValueSet(1, nAccountingPeriod.ToString(0).ToHandle());
                    frmMCVoucherRow.FromHandle(hWndFirstTab).SetAccountingPeriod(dfnAccountingPeriod.Number);
                }
                return Sys.VALIDATE_Ok;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean ValidateVoucherType()
        {
            #region Local Variables
            SalBoolean bCommandOk = false;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("Voucher_API.Validate_Voucher_Type__", System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                    hints.Add("Voucher_Type_API.Is_Row_Group_Validated", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                    bCommandOk = DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN\r\n" +
                        "	&AO.Voucher_API.Validate_Voucher_Type__(\r\n" +
                        "        	:i_hWndFrame.frmMCEntryVoucher.lsAutomatic,\r\n" +
                        "		:i_hWndFrame.frmMCEntryVoucher.sSimulationVoucher,\r\n" +
                        "                :i_hWndFrame.frmMCEntryVoucher.dfsVoucherTypeDescription,\r\n" +
                        "                :i_hWndFrame.frmMCEntryVoucher.dfsCompany,\r\n" +
                        "                :i_hWndFrame.frmMCEntryVoucher.ccsVoucherType.i_sMyValue,\r\n" +
                        "                :i_hWndFrame.frmMCEntryVoucher.dfsUserGroup,\r\n" +
                        "                :i_hWndFrame.frmMCEntryVoucher.dfnAccountingYear );\r\n" +
                        "	:i_hWndFrame.frmMCEntryVoucher.dfsRowGroupValidation := &AO.Voucher_Type_API.Is_Row_Group_Validated(\r\n" +
                        "		:i_hWndFrame.frmMCEntryVoucher.dfsCompany,\r\n" +
                        "		:i_hWndFrame.frmMCEntryVoucher.ccsVoucherType.i_sMyValue);\r\nEND;");
                }
                if (!(bCommandOk))
                {
                    return Sys.VALIDATE_Cancel;
                }
                if (lsAutomatic == "Y")
                {
                    dfnVoucherNo.Number = 0;
                }
                dfnVoucherNo.EditDataItemSetEdited();
                return Sys.VALIDATE_Ok;
            }
            #endregion
        }
        // Bug 77430, Begin
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber EnableEditing()
        {
            #region Actions
            using (new SalContext(this))
            {
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("Voucher_Type_User_Group_API.Get_Authorize_Level", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                    hints.Add("Authorize_Level_API.Encode", System.Data.ParameterDirection.Input);
                    DbPLSQLBlock(cSessionManager.c_hSql, ":i_hWndFrame.frmMCEntryVoucher.sAuthLevel := &AO.Authorize_Level_API.Encode(\r\n" +
                        "							             &AO.Voucher_Type_User_Group_API.Get_Authorize_Level( :i_hWndFrame.frmMCEntryVoucher.dfsCompany,\r\n" +
                        "												 	:i_hWndFrame.frmMCEntryVoucher.dfnAccountingYear,\r\n" +
                        "													:i_hWndFrame.frmMCEntryVoucher.dfsUserGroup,\r\n" +
                        "													:i_hWndFrame.frmMCEntryVoucher.ccsVoucherType.i_sMyValue))");
                }
                if (!(sAuthLevel == Ifs.Fnd.ApplicationForms.Const.strNULL))
                {
                    if (sAuthLevel == "ApproveOnly")
                    {
                        Sal.DisableWindow(frmMCVoucherRow.FromHandle(hWndFirstTab).tblVoucherRow);
                        Sal.DisableWindow(dfdVoucherDate);
                        Sal.DisableWindow(dfnVoucherNo);
                        Sal.DisableWindow(dfsTextId);
                        Sal.DisableWindow(dfsRowText);
                        Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_ApproveOnlyPermission, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, 0);
                    }
                    else
                    {
                        Sal.EnableWindow(frmMCVoucherRow.FromHandle(hWndFirstTab).tblVoucherRow);
                        Sal.EnableWindow(dfdVoucherDate);
                        Sal.EnableWindow(dfnVoucherNo);
                        Sal.EnableWindow(dfsTextId);
                        Sal.EnableWindow(dfsRowText);
                    }
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// Applications should override the DataSourceFormatSqlColumnUser function
        /// to specify extra columns to be included in the select statement for the
        /// data source.
        /// COMMENTS:
        /// The columns specified returned here must match the bind variables returned
        /// by function DataSourceFormatSqlIntoUser.
        /// 
        /// The DataSourceFormatSqlColumnUser is intended to be used when applications
        /// need information from the data source, that don't need to be presented to the
        /// user. Using DataSourceFormatSqlColumnUser and DataSourceFormatSqlIntoUser, the
        /// application can retrive this information into window variables instead of
        /// data items, hence reducing the number of objects in the window, speeding up
        /// window creation times, and reducing the size of the application.
        /// EXAMPLE:
        /// Function: DataSourceFormatSqlColumnUser
        /// 	Actions
        /// 		Return "id, name"
        /// </summary>
        /// <returns>
        /// The return value should a list of comma-separated column names, with no comma sign after
        /// the last column.
        /// </returns>
        public new SalString DataSourceFormatSqlColumnUser()
        {
            #region Actions
            using (new SalContext(this))
            {
                return "&AO.Authorize_Level_API.Encode( &AO.Voucher_Type_User_Group_API.Get_Authorize_Level( :i_hWndFrame.frmMCEntryVoucher.dfsCompany,\r\n" +
                "										 	:i_hWndFrame.frmMCEntryVoucher.dfnAccountingYear,\r\n" +
                "											:i_hWndFrame.frmMCEntryVoucher.dfsUserGroup,\r\n" +
                "											:i_hWndFrame.frmMCEntryVoucher.ccsVoucherType.i_sMyValue))";
            }
            #endregion
        }

        /// <summary>
        /// Applications should override the DataSourceFormatSqlIntoUser function
        /// to specify extra bind variables to be included in the select statement for the
        /// data source.
        /// COMMENTS:
        /// The bind variables specified returned here must match the columns returned
        /// by function DataSourceFormatSqlColumnUser.
        /// 
        /// The DataSourceFormatSqlIntoUser is intended to be used when applications
        /// need information from the data source, that don't need to be presented to the
        /// user. Using DataSourceFormatSqlColumnUser and DataSourceFormatSqlIntoUser, the
        /// application can retrive this information into window variables instead of
        /// data items, hence reducing the number of objects in the window, speeding up
        /// window creation times, and reducing the size of the application.
        /// EXAMPLE:
        /// Function: DataSourceFormatSqlIntoUser
        /// 	Actions
        /// 		Return ":i_hWndFrame.frmEmployee.sId, :i_hWndFrame.frmEmployee.sName"
        /// </summary>
        /// <returns>
        /// The return value should a list of comma-separated bind variables, with no comma sign after
        /// the last column.
        /// </returns>
        public new SalString DataSourceFormatSqlIntoUser()
        {
            #region Actions
            using (new SalContext(this))
            {
                return ":i_hWndFrame.frmMCEntryVoucher.sAuthLevel";
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
        private void frmMCEntryVoucher_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordDuplicate:
                    this.frmMCEntryVoucher_OnPM_DataRecordDuplicate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew:
                    this.frmMCEntryVoucher_OnPM_DataRecordNew(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate:
                    this.frmMCEntryVoucher_OnPM_DataSourcePopulate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave:
                    this.frmMCEntryVoucher_OnPM_DataSourceSave(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_UserProfileChanged:
                    this.frmMCEntryVoucher_OnPM_UserProfileChanged(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceQueryFieldName:
                    this.frmMCEntryVoucher_OnPM_DataSourceQueryFieldName(sender, e);
                    break;

                // Bug 77430, Begin

                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove:
                    this.frmMCEntryVoucher_OnPM_DataRecordRemove(sender, e);
                    break;

                // Bug 77430, End

                case Ifs.Fnd.ApplicationForms.Const.PM_AttachmentKeysGet:
                    this.frmMCEntryVoucher_OnPM_AttachmentKeysGet(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataRecordDuplicate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmMCEntryVoucher_OnPM_DataRecordDuplicate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire)
            {
                e.Return = false;
                return;
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordDuplicate, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataRecordNew event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmMCEntryVoucher_OnPM_DataRecordNew(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew, Sys.wParam, Sys.lParam))
            {
                if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
                {
                    Sal.ListClear(frmMCVoucherRow.FromHandle(this.hWndFirstTab).cmbsVoucherCompany);
                    Sal.SendMsg(this.ccsVoucherType, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
                }
                // Bug 77430, Begin
                else
                {
                    if (this.sAuthLevel == "ApproveOnly")
                    {
                        e.Return = false;
                        return;
                    }
                    else
                    {
                        e.Return = true;
                        return;
                    }
                }
                // Bug 77430, End
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
        /// PM_DataSourcePopulate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmMCEntryVoucher_OnPM_DataSourcePopulate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                this.nReturn = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Sys.wParam, Sys.lParam);
                frmMCVoucherRow.FromHandle(this.hWndFirstTab).dfnCurrencyBalance.Number = this.dfnCurrencyBalance.Number;
                frmMCVoucherRow.FromHandle(this.hWndFirstTab).dfnBalance.Number = this.dfnBalance.Number;
                frmMCVoucherRow.FromHandle(this.hWndFirstTab).UpdateCompanyList();
                frmMCVoucherRow.FromHandle(this.hWndFirstTab).dfsCodePartValue.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                frmMCVoucherRow.FromHandle(this.hWndFirstTab).dfsCodePartDescription.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                // Bug 72229, Begin
                if (Sal.IsNull(this.dfsRowText) || (this.nVoucherNo != this.dfnVoucherNo.Number) || (this.ccsVoucherType.i_sMyValue != this.sVType) || (this.sRowText != this.dfsRowText.Text) || (this.nYear != this.dfnAccountingYear.Number))
                {
                    if (!(this.nVoucherNo == 0))
                    {
                        Sal.ClearField(this.dfsTextId);
                        this.sTextId = Ifs.Fnd.ApplicationForms.Const.strNULL;
                    }
                    else
                    {
                        this.dfsTextId.Text = this.sTextId;
                    }
                }
                else
                {
                    this.dfsTextId.Text = this.sTextId;
                }
                // Bug 72229, End
                e.Return = this.nReturn;
                return;
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataSourceSave event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmMCEntryVoucher_OnPM_DataSourceSave(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                if (!(this.AreVoucherRows()))
                {
                    Ifs.Fnd.ApplicationForms.Int.ErrorBox(Properties.Resources.VOUCHER_MCNoRows);
                    e.Return = false;
                    return;
                }
                if (!(this.CheckHomeCompanyRow()))
                {
                    Ifs.Fnd.ApplicationForms.Int.ErrorBox(Properties.Resources.VOUCHER_MCNoRowsAtHome);
                    e.Return = false;
                    return;
                }
                this.sManualFound = "FALSE";
                this.sWarningRaised = "FALSE";
                this.nCurrentRow = Sys.TBL_MinRow;
                this.nCntRow = Sal.TblQueryContext(frmMCVoucherRow.FromHandle(this.hWndFirstTab).tblVoucherRow);
                while (Sal.TblFindNextRow(frmMCVoucherRow.FromHandle(this.hWndFirstTab).tblVoucherRow, ref this.nCurrentRow, 0, 0))
                {
                    Sal.TblSetContext(frmMCVoucherRow.FromHandle(this.hWndFirstTab).tblVoucherRow, this.nCurrentRow);
                    if (frmMCVoucherRow.FromHandle(this.hWndFirstTab).tblVoucherRow_colAddInternal.Text == "TRUE")
                    {
                        // The warning should be raised only once even if several rows requires manual postings
                        if (this.sWarningRaised == "FALSE")
                        {
                            Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_NoManualPost, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Warning, Ifs.Fnd.ApplicationForms.Const.WARNING_Ok);
                            this.sWarningRaised = "TRUE";
                        }
                        frmMCVoucherRow.FromHandle(this.hWndFirstTab).ManualPostings();

                        // The voucher shall not be saved if any manual postings must be added
                        this.sManualFound = "TRUE";

                        // This row has a manual posting connected
                        frmMCVoucherRow.FromHandle(this.hWndFirstTab).tblVoucherRow_colsManualAdded.Text = "TRUE";
                    }
                }
                Sal.TblSetContext(frmMCVoucherRow.FromHandle(this.hWndFirstTab).tblVoucherRow, this.nCntRow);
                // The voucher shall be saved only if no manual postings are required
                if (this.sManualFound == "FALSE")
                {
                    if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Sys.wParam, Sys.lParam))
                    {
                        if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
                        {
                            this.DataSourceRefresh(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
                        }
                        e.Return = true;
                        return;
                    }
                    else
                    {
                        e.Return = false;
                        return;
                    }
                }
                else
                {
                    e.Return = false;
                    return;
                }
            }
            // Bug 72229, Begin
            this.nVoucherNo = this.dfnVoucherNo.Number;
            this.sVType = this.ccsVoucherType.i_sMyValue;
            this.sRowText = this.dfsRowText.Text;
            this.nYear = this.dfnAccountingYear.Number;
            // Bug 72229, End
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_UserProfileChanged event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmMCEntryVoucher_OnPM_UserProfileChanged(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_UserProfileChanged, Sys.wParam, Sys.lParam))
            {
                this.StartupDbCalls();
                e.Return = true;
                return;
            }
            e.Return = false;
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataSourceQueryFieldName event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmMCEntryVoucher_OnPM_DataSourceQueryFieldName(object sender, WindowActionsEventArgs e)
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
                        e.Return = (this.i_hWndFrame.ToNumber().ToString(0) + ".frmMCEntryVoucher.i_sCompany").ToHandle();
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
        private void frmMCEntryVoucher_OnPM_DataRecordRemove(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire)
            {
                if (this.sAuthLevel == "ApproveOnly")
                {
                    e.Return = false;
                    return;
                }
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_AttachmentKeysGet event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmMCEntryVoucher_OnPM_AttachmentKeysGet(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.Msg.Construct();
            this.Msg.AddAttribute("ACCOUNTING_YEAR", Sal.WindowHandleToNumber(this.dfnAccountingYear).ToString(0));
            this.Msg.AddAttribute("COMPANY", Sal.WindowHandleToNumber(this.dfsCompany).ToString(0));
            this.Msg.AddAttribute("VOUCHER_NO", Sal.WindowHandleToNumber(this.dfnVoucherNo).ToString(0));
            this.Msg.AddAttribute("VOUCHER_TYPE", Sal.WindowHandleToNumber(this.ccsVoucherType).ToString(0));
            e.Return = this.Msg.Pack().ToHandle();
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void dfdVoucherDate_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.dfdVoucherDate_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfdVoucherDate_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            // Bug 77430, Begin
            this.EnableEditing();
            // Bug 77430, End
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam) == Sys.VALIDATE_Cancel)
            {
                e.Return = Sys.VALIDATE_Cancel;
                return;
            }
            if (!(Sal.IsNull(this.dfdVoucherDate)))
            {
                if (!(this.ValidateVoucherDate()))
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
        private void dfsUserGroup_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.dfsUserGroup_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsUserGroup_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            // Bug 77430, Begin
            this.EnableEditing();
            // Bug 77430, End
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam) == Sys.VALIDATE_Cancel)
            {
                e.Return = Sys.VALIDATE_Cancel;
                return;
            }
            if (this.dfsUserId.EditDataItemStateGet() == Ifs.Fnd.ApplicationForms.Const.EDIT_Query)
            {
                e.Return = this.ValidateVoucherType();
                return;
            }
            else
            {
                e.Return = this.ValidateUserGroup();
                return;
            }
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void ccsVoucherType_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.ccsVoucherType_OnPM_DataItemValidate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovUserWhere:
                    e.Handled = true;
                    e.Return = ((SalString)"SIMULATION_VOUCHER = 'FALSE'").ToHandle();
                    return;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void ccsVoucherType_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            // Bug 77430, Begin
            this.EnableEditing();
            // Bug 77430, End
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam) == Sys.VALIDATE_Cancel)
            {
                e.Return = Sys.VALIDATE_Cancel;
                return;
            }
            if ((!(Sal.IsNull(this.ccsVoucherType))) && this.ccsVoucherType.EditDataItemStateGet() == Ifs.Fnd.ApplicationForms.Const.EDIT_Changed)
            {
                e.Return = this.ValidateVoucherType();
                return;
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
        private void dfsVoucherTypeDescription_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    e.Handled = true;
                    e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                    return;
            }
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void dfnVoucherNo_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.dfnVoucherNo_OnPM_DataItemQueryEnabled(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.dfnVoucherNo_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfnVoucherNo_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.lsAutomatic == "N")
            {
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldEnabled;
                return;
            }
            e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfnVoucherNo_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.lsAutomatic == "N")
            {
                this.dfnVoucherNo.EditDataItemSetEdited();
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
        private void dfnAccountingYear_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    e.Handled = true;
                    e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                    return;
            }
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void dfnAccountingPeriod_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    e.Handled = true;
                    e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                    return;
            }
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void cbFreeText_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                // Bug 77430, Begin, changed the message action

                case Ifs.Fnd.ApplicationForms.Const.WM_LBUTTONDBLCLK:
                    this.cbFreeText_OnWM_LBUTTONDBLCLK(sender, e);
                    break;

                // Bug 77430, End

                // Bug 77430, Begin, added new message action

                case Ifs.Fnd.ApplicationForms.Const.WM_LBUTTONDOWN:
                    e.Handled = true;
                    e.Return = false;
                    return;

                // Bug 77430, End
            }
            #endregion
        }

        /// <summary>
        /// WM_LBUTTONDBLCLK event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cbFreeText_OnWM_LBUTTONDBLCLK(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (!(this.dfsCompany.EditDataItemStateGet() == Ifs.Fnd.ApplicationForms.Const.EDIT_Empty))
            {
                if (UM_FreeText(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire))
                {
                    UM_FreeText(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
                }
                e.Return = false;
                return;
            }
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void dfsTextId_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.dfsTextId_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsTextId_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            using (SignatureHints hints = SignatureHints.NewContext())
            {
                hints.Add("Voucher_Text_API.Get_Description", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                if (!(this.dfsTextId.DbPLSQLBlock(cSessionManager.c_hSql, this.sFormName + "dfsRowText := substr(" + cSessionManager.c_sDbPrefix + "Voucher_Text_API.Get_Description( " + this.sFormName + "dfsCompany," + this.sFormName + "dfsTextId ),1,200)")))
                {
                    e.Return = false;
                    return;
                }
            }
            Sal.SetFieldEdit(this.dfsTextId, false);
            Sal.SetFieldEdit(this.dfsRowText, true);
            // Bug 72229, Begin
            this.sTextId = this.dfsTextId.Text;
            // Bug 72229, End
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void dfdDateReg_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    e.Handled = true;
                    e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                    return;
            }
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void dfsUserId_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    e.Handled = true;
                    e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                    return;
            }
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void dfsUpdateError_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    e.Handled = true;
                    e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                    return;
            }
            #endregion
        }
        #endregion

        #region Late Bind Methods

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalBoolean vrtDataRecordExecuteModify(SalSqlHandle hSql)
        {
            return this.DataRecordExecuteModify(hSql);
        }

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalBoolean vrtDataRecordExecuteNew(SalSqlHandle hSql)
        {
            return this.DataRecordExecuteNew(hSql);
        }

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalBoolean vrtDataRecordValidate()
        {
            return this.DataRecordValidate();
        }

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalString vrtDataSourceFormatSqlColumnUser()
        {
            return this.DataSourceFormatSqlColumnUser();
        }

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalString vrtDataSourceFormatSqlIntoUser()
        {
            return this.DataSourceFormatSqlIntoUser();
        }

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalBoolean vrtDataSourceSaveCheckOk()
        {
            return this.DataSourceSaveCheckOk();
        }

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalBoolean vrtFrameStartupUser()
        {
            return this.FrameStartupUser();
        }
        #endregion

        #region Event Handlers

        private void menuItem__Notes_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = UM_FreeText(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem__Notes_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            UM_FreeText(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem_Change_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = Sal.SendClassMessage(Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Sys.lParam);
        }

        private void menuItem_Change_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            Sal.SendClassMessage(Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Sys.lParam);
        }

        private void menuItem__Notes_1_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = UM_FreeText(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem__Notes_1_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            UM_FreeText(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem_Change_1_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = Sal.SendClassMessage(Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Sys.lParam);
        }

        private void menuItem_Change_1_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            Sal.SendClassMessage(Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Sys.lParam);
        }

        private void menuItem_Change_2_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = Sal.SendClassMessage(Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Sys.lParam);
        }

        private void menuItem_Change_2_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            Sal.SendClassMessage(Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Sys.lParam);
        }

        #endregion

    }
}
