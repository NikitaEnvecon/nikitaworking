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
// -------------------------------------------------------------
// 09-08-27    GADALK    Bug 84001, Modified UM_InstantUpdate.
// 12-01-06    PRatLK    SFI-447, dissabled code parts shown in frmVoucherRow correted.
// 12-04-03    Clstlk    EASTRTM-8352, LCS Merge( Bug 101535) 
// 12-07-11    THPELK    Bug 102106, Corrected in CopyGLVouRow()
// 12-08-06    Mawelk    Bug 104284 Fixed. Changes to UM_InterimVoucher().
// 12-08-17    Umdolk    EDEL-1322, added RMB add investment information and Opened add investment dialog upon save.
// 12-08-21    Umdolk    EDEL-1494, Removed the code for Openning add investment dialog upon save.
// 12-09-06    Umdolk    EDEL-1608, Modified enable logic in add investment info.
// 12-09-17    Umdolk    EDEL-1440, Added a check for negative net value when saving the voucher.
// 12-12-22    Mawelk    Bug 107981 Fixed.
// 12-11-23    JANBLK    DANU-122, Parallel currency implementation.
// 13-05-29    NILILK    DANU-932, Modified GetParallelCurrencyAttributes to fetch Parallel Currency basic data.
// 13-07-04    NILILK    DANU-1302, Added new validate to validate parallel currency rate when saving a voucher row.
// 13-02-20    Shedlk    Bug 108351 Fixed. Changed source in call to frmEntryVoucher_OnPM_DataSourceSave from hWndFirstTab to i_hWndFrame.
// 13-02-28    CLSTLK    Bug 108222, Fixed rounding issue.
// 13-02-28    Shedlk    Bug 108622 Fixed. Added if condition to check for null statement in frmEntryVoucher_OnPM_DataSourceSave 
// 13-04-18    THPELK    Bug 108987 Corrected. Added validation in OnPM_DataSourceSave. 
// 13-07-16    Machlk    Bug 111189 Fixed, Cleared the Third Currency Cache, So that it willfetch the currency rates.
// 13-09-09    Mawelk    Bug 112228 Fixed.
// 14-01-20    MEALLK    PBFI-4640, modifed code in frmEntryVoucher_OnPM_DataSourceSave (Added a condition to validations introduced by CORE Bug 108987).
// 14-04-03    Samllk    PBFI-4130 Merged Bug 114084 
// 14-05-22    Hecolk    PBFI-7504, Moved the DataItemValidate call for Tax Code into the while loop in frmEntryVoucher_OnPM_DataSourceSave
// 14-05-29    Lamalk    PBFI-7218, Added method 'IsGLVoucherSummerized()' to check whether a voucher is summerized before loading voucher rows into the window. 
// 14-08-20    THPELK    PRFI-29 - LCS Merge(Bug 116591).
// 14-11-15    Chgulk    PRFI-3337, Merged LCS patch 119340.
#endregion

using System;
using Ifs.Application.Enterp;
using Ifs.Fnd.ApplicationForms;
using Ifs.Fnd.Windows.Forms;
using PPJ.Runtime;
using PPJ.Runtime.Sql;
using PPJ.Runtime.Windows;
using PPJ.Runtime.Vis;
using System.Collections.Generic;

namespace Ifs.Application.Accrul
{
	
	/// <summary>
	/// Redesign of Voucher Entry
	/// </summary>
    [FndWindowRegistration("VOUCHER", "Voucher")]
    [FndWindowRegistration("VOUCHER_ROW", "VoucherRow")]
    public partial class frmEntryVoucher : cMasterDetailTabFormWindowVou
    {
        #region Window Variables
        public SalString sCurrencyCode = "";
        public SalString sFormName = "";
        public SalString sIsCurrencyEmu = "";
        public SalString sResult = "";
        public SalString sVoucherType = "";
        public SalString lsAutomatic = "";
        public SalDateTime dParallelCurrValidFrom = SalDateTime.Null;
        public SalDateTime dInterimVoucherDate = SalDateTime.Null;
        public SalDateTime dVoucherDate = SalDateTime.Null;
        public SalNumber nAccountingPeriod = 0;
        public SalNumber nAccountingYear = 0;
        public SalNumber nDecimalsInAmount = 0;
        public SalNumber nDecimalsInRate = 0;
        public SalNumber nReturn = 0;
        public SalBoolean bThirdCurrExists = false;
        public SalNumber nParallelRate = 0;
        public SalString sParallelCurrency = "";
        public SalNumber nGLvouno = 0;
        public SalNumber nYear = 0;
        public SalNumber nPeriod = 0;
        public SalNumber nVouNumber = 0;
        public SalString sGlCpyVouType = "";
        public SalString sMasterTemplate = "";
        public SalArray<SalString> sMasterUseTemplate = new SalArray<SalString>();
        public SalString sTemplateList = "";
        public SalString sMasterDesc = "";
        public SalDateTime dMasterValidFrom = SalDateTime.Null;
        public SalDateTime dMasterValidUntil = SalDateTime.Null;
        public SalString sIncludeAmount = "";
        public SalDateTime dCurrentDate = SalDateTime.Null;
        public SalString slUserId = "";
        public SalString lsAuthLevel = "";
        public SalString lsAutoBal = "";
        public SalWindowHandle hWndFirstTab = SalWindowHandle.Null;
        public SalWindowHandle hWndSecondTab = SalWindowHandle.Null;
        public SalString sTempStatus = "";
        public SalArray<SalString> sStatus = new SalArray<SalString>(1);
        public SalString sUserGroup = "";
        public SalString sUser = "";
        public SalString sVouDate = "";
        public SalString sSimulationVoucher = "";
        public SalBoolean bOk = false;
        public SalString sVouType = "";
        public SalString sFunctionGroup = "";
        public SalNumber nCurrentRow = 0;
        public SalString sManualFound = "";
        public SalString sWarningRaised = "";
        public SalString sUseManual = "";
        public SalString sOldStatus = "";
        public SalString sAmountMethodGross = "";
        public SalString sAmountMethodNet = "";
        public SalString sTaxDirectionDisbursed = "";
        public SalString sTaxDirectionReceived = "";
        public SalString sTaxDirectionNoTax = "";
        public SalBoolean bManualFoundInSecond = false;
        public SalString sNewState = "";
        public SalWindowHandle hFirstTab = SalWindowHandle.Null;
        public SalNumber nYearYep = 0;
        public SalNumber nPeriodYep = 0;
        public SalNumber nContextRow = 0;
        public SalString sPrevUserGroup = "";
        public SalBoolean bGetPrelAccYearIsAvailable = false;
        public SalBoolean bIntManPostingsEntered = false;
        public SalString sAutomaticAallot = "";
        public SalBoolean sNewVoucher = false;
        public SalString sInterimVouUserGrp = "";
        public SalString sAutoTax = "";
        public SalNumber nRow = 0;
        public SalBoolean bExtVou = false;
        public SalString sAutoTaxExt = "";
        public SalString sVouExist = "";
        public SalString sPrevVoucherType = "";
        public SalDateTime dPrevVoucherDate = SalDateTime.Null;
        public SalString lsStmtExtRows = "";
        public SalSqlHandle hSql = SalSqlHandle.Null;
        public SalNumber nFetch = 0;
        public SalBoolean bCorrection = false;
        public SalBoolean bReverse = false;
        public SalString sRoundingMethod = "";
        public SalBoolean bIsValidateVouDate = false;
        public SalString sInterimUser = "";
        public SalBoolean bErrState = false;
        public SalString sFndUser = "";
        public SalString sBlocked = "";
        public SalNumber nVoucherNo = 0;
        public SalString sVType = "";
        public SalString sRowText = "";
        public SalNumber nAcYear = 0;
        public SalNumber nFinalVoucherNumber = 0;
        public SalNumber nFictiveVoucherNo = 0;
        public SalString sRefreshRequired = "";
        public SalNumber nTempBalance = 0;
        public SalNumber nTempCurrBalance = 0;
        public SalBoolean bPostingRowsFound = false;
        public SalString sNoteExist = "";
        public SalString sAuthLevel = "";
        public SalString sExistPeriodAlloction = "";
        public SalBoolean bVoucherPostingModified = false;
        public SalString sCancellation = "";
        public SalString sAddInvestment = "FALSE";
        public SalString sNegative = "FALSE";

        public SalNumber nTempParrCurrBalance = 0;


        public SalString sParallelBaseType = "";
        public SalString sParallelRateType = "";
        public SalString sCurrCode = "";
        public SalString sIsAutoBalanceVouType = "N";
        public SalString sSummerizedGLVoucher = "";
        public SalBoolean bIsUpdateGLRefreshed = false;

        private SalString sUserGroupNew = "";
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public frmEntryVoucher()
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
        public new static frmEntryVoucher FromHandle(SalWindowHandle handle)
        {
            return ((frmEntryVoucher)SalWindow.FromHandle(handle, typeof(frmEntryVoucher)));
        }
        #endregion

        #region Methods

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public new SalBoolean FrameStartupUser()
        {
            #region Local Variables
            SalNumber nPosAccount = 0;
            SalString sValue = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                hWndFirstTab = TabAttachedWindowHandleGet(picTab.FindName("VouPosting"));
                sFormName = ":i_hWndFrame." + Ifs.Fnd.ApplicationForms.Int.QualifiedItemNameGet(i_hWndSelf) + ".";
                // Insert new code here...
                Ifs.Fnd.ApplicationForms.Var.Profile.ValueStringGet("frmVoucherPosting.tblVoucherPosting", "ColLockNumber", "8888", ref sValue);
                if (sValue == "8888" && hWndFirstTab != Sys.hWndNULL)
                {
                    nPosAccount = Sal.TblQueryColumnPos(frmVoucherPosting.FromHandle(hWndFirstTab).tblVoucherPosting_colsAccount);
                    Sal.TblSetLockedColumns(frmVoucherPosting.FromHandle(hWndFirstTab).tblVoucherPosting, nPosAccount);
                }
                // Here the second tab which is connected with frmVoucherRow is activated
                // so it will show only the used code-part columns.Otherwise until a company change is not done
                // all the code part columns will be shown.
                this.picTab.BringToTop(picTab.FindName("ViewVouRow"), false);
                this.picTab.BringToTop(picTab.FindName("VouPosting"), false);
                // Insert new code here...
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
            SalBoolean bDataTrfrHandled = false;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                if (this.i_bCompanyChangedFin)
                {
                    Sal.SendMsg(frmVoucherPosting.FromHandle(hWndFirstTab).tblVoucherPosting, Ifs.Application.Accrul.Const.PAM_CallChanged, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                    i_bCompanyChangedFin = false;
                }
                //from SAM_Create
                this.cbInterimVoucher.i_sCheckedValue = "Y";
                this.cbInterimVoucher.i_sUncheckedValue = "N";
                this.cbAutomatic.i_sCheckedValue = "Y";
                this.cbAutomatic.i_sUncheckedValue = "N";

                nRows = Ifs.Fnd.ApplicationForms.Var.DataTransfer.RecCountGet();
                if (nRows > 0)
                {
                    Sal.WaitCursor(true);
                    if (InitFromTransferredData())
                    {
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();
                    }
                    Sal.WaitCursor(false);
                    if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.SourceNameGet() == "VOUCHER_APPROVAL")
                    {
                        dfsApprovedByUserGroup.Text = sUserGroup;
                    }
                    bDataTrfrHandled = true;
                }
                StartupDbCalls();
                sNewVoucher = false;
                cmbsVoucherStatus.LookupInit();

                if (bDataTrfrHandled)
                {
                    return false;
                }
                return base.Activate(URL);
            }
            #endregion

        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber CopyHeaderVoucher()
        {
            #region Local Variables
            SalNumber m = 0;
            SalNumber nIndex = 0;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                if ((i_nDataSourceState == Ifs.Fnd.ApplicationForms.Const.DATASOURCE_Changed) || (i_nDataSourceState == Ifs.Fnd.ApplicationForms.Const.DATASOURCE_DetailChanged))
                {
                    switch (((cDataSource)this).DataSourceInquireSave())
                    {
                        case Sys.IDCANCEL:
                            return false;

                        case Sys.IDYES:
                            ((cDataSource)this).DataSourceSave(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
                            break;

                        case Sys.IDNO:
                            break;
                    }
                }
                // Create the new record
                i_nRecordState = Sys.ROW_New;
                m = 0;
                while (m < i_nChildCount)
                {
                    if (Sal.SendMsg(i_hWndChild[m], Ifs.Fnd.ApplicationForms.Const.PM_DataItemFlagQuery, Ifs.Fnd.ApplicationForms.Const.FIELD_Insert, 0))
                    {
                        Sal.SendMsg(i_hWndChild[m], Ifs.Fnd.ApplicationForms.Const.PM_DataItemStateSet, Ifs.Fnd.ApplicationForms.Const.EDIT_New, 0);
                        Sal.SetFieldEdit(i_hWndChild[m], true);
                    }
                    m = m + 1;
                }
                // Set default voucher status to Confirmed
                ccsVoucherType.EditDataItemValueSet(1, ccsVoucherType.EditDataItemValueGet());
                cmbsVoucherStatus.EditDataItemValueSet(1, Sal.ListQueryTextX(cmbsVoucherStatus, 0).ToHandle());
                cbInterimVoucher.EditDataItemValueSet(1, ((SalString)"N").ToHandle());
                dfnVoucherNo.EditDataItemValueSet(1, ((SalNumber)0).ToString(0).ToHandle());
                Sal.SetFieldEdit(dfsRowText, false);
                Sal.SetFieldEdit(dfsTextId, false);
                if (cmbsAmountMethod.Text == Sys.STRING_Null)
                {
                    // If Amount Method missing set the Net Amount method
                    cmbsAmountMethod.EditDataItemValueSet(1, sAmountMethodNet.ToHandle());
                }
                SetEntryAndApprovedToDefValues();
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("User_Group_Member_Finance_API.Get_User_Group_", System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                    DbPLSQLBlock(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "User_Group_Member_Finance_API.Get_User_Group_(" + sFormName + "dfsUserGroup," + sFormName + "dfsCompany," + sFormName + "dfsUserId)");
                }
                dfsUserGroup.EditDataItemSetEdited();
                ccsVoucherType.EditDataItemSetEdited();
                // Modify data source state
                if (i_nDataSourceState != Ifs.Fnd.ApplicationForms.Const.DATASOURCE_Changed)
                {
                    i_nDataSourceState = Ifs.Fnd.ApplicationForms.Const.DATASOURCE_Changed;
                    cDataSource.FromHandle(i_hWndParent).vrtDataSourceDetailModified(true);
                    MethodStateChanged(Ifs.Fnd.ApplicationForms.Const.CHILDTYPE_SourceMethod);
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// Save actual interim voucher
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean CreateInterimVoucher()
        {
            #region Actions
            using (new SalContext(this))
            {
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("Voucher_API.Interim_Voucher", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                    if (!(DbPLSQLBlock(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "Voucher_API.Interim_Voucher(" + sFormName + "ccsVoucherType.i_sMyValue," + sFormName + "dfnVoucherNo," + sFormName + "dfnAccountingYear," + sFormName + "dfsCompany," +
                        sFormName + "sVoucherType," + sFormName + "dInterimVoucherDate," + sFormName + "nAccountingYear," + sFormName + "nAccountingPeriod," + sFormName + "sInterimVouUserGrp )")))
                    {
                        return false;
                    }
                }
                return true;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber CreateTemplates()
        {
            #region Actions
            using (new SalContext(this))
            {
                sVoucherType = ccsVoucherType.i_sMyValue;
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("VOUCHER_TEMPLATE_API.Insert_Table_", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                    DbPLSQLTransaction(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "VOUCHER_TEMPLATE_API.Insert_Table_(" + sFormName + "i_sCompany," + sFormName + "sMasterTemplate," + sFormName + "sMasterDesc," + sFormName + "dMasterValidFrom," +
                        sFormName + "dMasterValidUntil," + sFormName + "dfnAccountingYear," + sFormName + "sVoucherType," + sFormName + "dfnVoucherNo," + sFormName + "sIncludeAmount)");
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// The framework calls the DataRecordPrepareNew function to retrive
        /// server default values for new records.
        /// </summary>
        /// <returns>The return value is TRUE if default values were sucessfully retrived, FALSE otherwise.</returns>
        public new SalBoolean DataRecordPrepareNew()
        {
            #region Local Variables
            SalString sVoucherDate = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                dfdVoucherDate.DateTime = dVoucherDate;
                dfdVoucherDate.EditDataItemSetEdited();
                dfsVoucherGroup.Text = "M";
                return ((cMasterDetailTabFormWindow)this).DataRecordPrepareNew();
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
                if (cbAutomatic.Checked == true)
                {
                    if (dfnVoucherNo.Number != 0)
                    {
                        dfnVoucherNo.Number = 0;
                    }
                }
                dfnVoucherNo.EditDataItemSetEdited();
                if (((cMasterDetailTabFormWindow)this).DataRecordExecuteNew(hSql))
                {
                    // Bug 69891, Begin. Removed Call hWndFirstTab.frmVoucherPosting.tblVoucherPosting.SetVoucherNo (dfnVoucherNo). Used Following instead.
                    frmVoucherPosting.FromHandle(hWndFirstTab).SetHeaderInfo(nFictiveVoucherNo, dfsTransferId.Text);
                    // Bug 69891, End
                    dVoucherDate = dfdVoucherDate.DateTime;
                }
                GetVoucherTypeInfo();
                return true;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public new SalBoolean DataRecordValidate()
        {
            #region Actions
            using (new SalContext(this))
            {
                Sal.SetFieldEdit(dfsTextId, true);
                if (((cDataSource)this).DataRecordValidate())
                {
                    Sal.SetFieldEdit(dfsTextId, false);
                    Sal.SetFieldEdit(dfsCurrencyCode, false);
                    Sal.SetFieldEdit(dfsCurrencyType, false);
                    Sal.SetFieldEdit(cbAutomatic, false);
                    Sal.SetFieldEdit(cbFreeText, false);
                    if (Sal.IsNull(frmVoucherPosting.FromHandle(hWndFirstTab).dfnCurrencyBalance))
                    {
                        frmVoucherPosting.FromHandle(hWndFirstTab).dfnCurrencyBalance.Number = 0;
                    }
                    if (Sal.IsNull(frmVoucherPosting.FromHandle(hWndFirstTab).dfnBalance))
                    {
                        frmVoucherPosting.FromHandle(hWndFirstTab).dfnBalance.Number = 0;
                    }

                    if (Sal.IsNull(frmVoucherPosting.FromHandle(hWndFirstTab).dfnParallelCurrBalance))
                    {
                        frmVoucherPosting.FromHandle(hWndFirstTab).dfnParallelCurrBalance.Number = 0;
                    }

                    lsAutoBal = sIsAutoBalanceVouType;

                    if ((cmbsVoucherStatus.Text == Sal.ListQueryTextX(cmbsVoucherStatus, 0)) && ((frmVoucherPosting.FromHandle(hWndFirstTab).dfnBalance.Number != 0) || (frmVoucherPosting.FromHandle(hWndFirstTab).dfnParallelCurrBalance.Number != 0)) && lsAutoBal == "N")
                    {
                        Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_VoEn_AlertBalance, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
                        Sal.SetFieldEdit(dfsTextId, true);
                        return false;
                    }
                    // Bug 77430, Begin, checked for 'Awaiting Approval' as well
                    if ((cmbsVoucherStatus.Text == Sal.ListQueryTextX(cmbsVoucherStatus, 4)) && ((frmVoucherPosting.FromHandle(hWndFirstTab).dfnBalance.Number != 0) || (frmVoucherPosting.FromHandle(hWndFirstTab).dfnParallelCurrBalance.Number != 0)) && lsAutoBal == "N")
                    {
                        Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_VoEnAwait_AlertBalance, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
                        Sal.SetFieldEdit(dfsTextId, true);
                        return false;
                    }
                    // Bug 77430, End



                    if ((cmbsVoucherStatus.Text == Sal.ListQueryTextX(cmbsVoucherStatus, 0)) && ((frmVoucherPosting.FromHandle(hWndFirstTab).dfnCurrencyBalance.Number != 0) || (frmVoucherPosting.FromHandle(hWndFirstTab).dfnParallelCurrBalance.Number != 0)) && lsAutoBal == "N")
                    {
                        if (Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_VoEn_AlertBalanceCurr, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_OkCancel) != Sys.IDOK)
                        {
                            Sal.SetFieldEdit(dfsTextId, true);
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
            #region Local Variables
            SalString sTempStatus = "";
            SalArray<SalString> sStatus = new SalArray<SalString>(1);
            SalNumber nIndex = 0;
            // Bug 74810, Begin.
            SalNumber nRow = 0;
            // Bug 74810, End.
            // Bug 101870, Begin
            SalArray<SalString> sParam = new SalArray<SalString>();
            // Bug 101870, End
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                if (frmVoucherPosting.FromHandle(hWndFirstTab).sIsRemoved == "TRUE")
                {
                    if (!(DbPLSQLBlock(cSessionManager.c_hSql, "&AO.Voucher_Row_API.Update_Row_No(\r\n" +
                               "                        :i_hWndFrame.frmEntryVoucher.dfsCompany,\r\n" +
                               "                        :i_hWndFrame.frmEntryVoucher.ccsVoucherType.i_sMyValue,\r\n" +
                               "                        :i_hWndFrame.frmEntryVoucher.dfnVoucherNo,\r\n" +
                               "                        :i_hWndFrame.frmEntryVoucher.dfnAccountingYear)")))
                    {
                        frmVoucherPosting.FromHandle(hWndFirstTab).sIsRemoved = "FALSE";
                        return false;
                    }
                    frmVoucherPosting.FromHandle(hWndFirstTab).sIsRemoved = "FALSE";

                }
                // Bug 74810, Begin - Passed :i_hWndFrame.frmEntryVoucher.dfnVoucherNo and :i_hWndFrame.frmEntryVoucher.nFictiveVoucherNo when necessary.
                // Bug 74066, Changed :i_hWndFrame.frmEntryVoucher.dfnVoucherNo to :i_hWndFrame.frmEntryVoucher.nFictiveVoucherNo
                if (dfnVoucherNo.Number == 0)
                {
                    using (SignatureHints hints = SignatureHints.NewContext())
                    {
                        hints.Add("Voucher_API.Check_Double_Entry__", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                        if (!(DbPLSQLBlock(cSessionManager.c_hSql, "&AO.Voucher_API.Check_Double_Entry__(\r\n" +
                            "	:i_hWndFrame.frmEntryVoucher.dfsCompany,\r\n" +
                            "	:i_hWndFrame.frmEntryVoucher.dfnAccountingYear,\r\n" +
                            "	:i_hWndFrame.frmEntryVoucher.ccsVoucherType.i_sMyValue,\r\n" +
                            "	:i_hWndFrame.frmEntryVoucher.nFictiveVoucherNo,\r\n" +
                            "	:i_hWndFrame.frmEntryVoucher.cmbsVoucherStatus)")))
                        {
                            if (cbAutomatic.Checked == true)
                            {
                                dfnVoucherNo.Number = 0;
                                dfnVoucherNo.EditDataItemSetEdited();
                            }
                            // Bug 74540, Removed the IF Condition of dfsRowGroupValidation
                            return false;
                        }
                    }
                }
                else
                {
                    using (SignatureHints hints = SignatureHints.NewContext())
                    {
                        hints.Add("Voucher_API.Check_Double_Entry__", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                        if (!(DbPLSQLBlock(cSessionManager.c_hSql, "&AO.Voucher_API.Check_Double_Entry__(\r\n" +
                            "	:i_hWndFrame.frmEntryVoucher.dfsCompany,\r\n" +
                            "	:i_hWndFrame.frmEntryVoucher.dfnAccountingYear,\r\n" +
                            "	:i_hWndFrame.frmEntryVoucher.ccsVoucherType.i_sMyValue,\r\n" +
                            "	:i_hWndFrame.frmEntryVoucher.dfnVoucherNo,\r\n" +
                            "	:i_hWndFrame.frmEntryVoucher.cmbsVoucherStatus)")))
                        {
                            // Bug 74540, Removed the IF Condition of dfsRowGroupValidation
                            return false;
                        }
                    }
                }
                // Bug 74066, End
                // Bug 74810, End
                nIndex = 0;
                sTempStatus = cmbsVoucherStatus.Text;
                if (((bool)(RecordStateGet() & Sys.ROW_New)) && Sal.IsNull(cmbsVoucherStatus))
                {
                    cmbsVoucherStatus.Text = dfStatus.Text;
                }
                else
                {
                    if (sTempStatus == Sal.ListQueryTextX(cmbsVoucherStatus, 0))  // Confirmed
                    {
                        if (!(DataRecordExecuteStateEvent(cSessionManager.c_hSql, "ReadyToUpdate")))
                        {
                            return false;
                        }
                        // Bug 69891, Begin
                        if (dfnVoucherNo.Number == 0)
                        {
                            if (!(FinalizeVoucher()))
                            {
                                return false;
                            }
                        }
                        // Bug 69891, End
                    }
                    // Bug 77430, Begin
                    if (sTempStatus == Sal.ListQueryTextX(cmbsVoucherStatus, 4))
                    {
                        if (!(DataRecordExecuteStateEvent(cSessionManager.c_hSql, "ReadyApprove")))
                        {
                            return false;
                        }
                        if (dfnVoucherNo.Number == 0)
                        {
                            if (!(FinalizeVoucher()))
                            {
                                return false;
                            }
                        }
                    }
                    // Bug 77430, End
                    else if ((!(RecordStateGet() & Sys.ROW_MarkDeleted)) && (sTempStatus == Sal.ListQueryTextX(cmbsVoucherStatus, 1)))  // Waiting
                    {
                        if (!(DataRecordExecuteStateEvent(cSessionManager.c_hSql, "DelayUpdate")))
                        {
                            return false;
                        }
                        // Bug 69891, Begin
                        if (dfnVoucherNo.Number == 0)
                        {
                            if (!(FinalizeVoucher()))
                            {
                                return false;
                            }
                        }
                        // Bug 69891, End
                    }
                    else if (sTempStatus == Sal.ListQueryTextX(cmbsVoucherStatus, 3))  // Cancelled
                    {
                        sStatus[0] = sTempStatus;
                        Ifs.Fnd.ApplicationForms.Int.AlertBoxWithParams(Properties.Resources.VOUCHER_ErrorState, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.WARNING_Ok, sStatus);
                        return false;
                    }
                    else if (bErrState == 1)  // Error - New Entry
                    {
                        return false;
                    }
                }
                Sal.SetFocus(dfdVoucherDate);
                // Bug 101870, Begin
                // Reference Mandatory if...
                //   1 Reference Mandatory is enabled
                //   2 voucher status is selected a Approved (first)
                if (frmVoucherPosting.FromHandle(hWndFirstTab).IsReferenceNull())
                {
                    using (SignatureHints hints = SignatureHints.NewContext())
                    {
                        hints.Add("Voucher_Type_API.Is_Reference_Mandatory", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                        DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN\r\n" +
                            "			      :i_hWndFrame.frmEntryVoucher.dfsReferenceMandatory := &AO.Voucher_Type_API.Is_Reference_Mandatory(\r\n" +
                            "									       	:i_hWndFrame.frmEntryVoucher.dfsCompany,\r\n" +
                            "								                       	:i_hWndFrame.frmEntryVoucher.ccsVoucherType.i_sMyValue);\r\n			END;");
                    }
                    if (dfsReferenceMandatory.Text == "Y" && (frmEntryVoucher.FromHandle(i_hWndFrame).cmbsVoucherStatus.Text == Sal.ListQueryTextX(frmEntryVoucher.FromHandle(i_hWndFrame).cmbsVoucherStatus, 0)))
                    {
                        sParam[0] = SalString.FromHandle(ccsVoucherType.EditDataItemValueGet());
                        Ifs.Fnd.ApplicationForms.Int.AlertBoxWithParams(Properties.Resources.TEXT_RefNo_RefSeriesNull, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok, sParam);
                        return false;
                    }
                }
                else
                {
                    return true;
                }
                // Bug 101870, End
                return true;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean GetParallelCurrencyAttributes()
        {
            #region Actions
            using (new SalContext(this))
            {                
                if (!(bThirdCurrExists))
                {
                    using (SignatureHints hints = SignatureHints.NewContext())
                    {
                        hints.Add("Company_Finance_API.Get_Parallel_Acc_Currency", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);

                        hints.Add("Company_Finance_API.Get_Parallel_Base_Db", System.Data.ParameterDirection.Input);
                        hints.Add("Company_Finance_API.Get_Parallel_Rate_Type", System.Data.ParameterDirection.Input);
                        if (!(DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN :i_hWndFrame.frmEntryVoucher.sParallelCurrency :=  " + cSessionManager.c_sDbPrefix + "Company_Finance_API.Get_Parallel_Acc_Currency(\r\n" +
                            ":i_hWndFrame.frmEntryVoucher.dfsCompany, :i_hWndFrame.frmEntryVoucher.dfdVoucherDate);\r\n" +
                            ":i_hWndFrame.frmEntryVoucher.sParallelBaseType := " + cSessionManager.c_sDbPrefix + "Company_Finance_API.Get_Parallel_Base_Db(\r\n" +
                            ":i_hWndFrame.frmEntryVoucher.dfsCompany);\r\n" +
                            ":i_hWndFrame.frmEntryVoucher.sParallelRateType := NVL(:i_hWndFrame.frmEntryVoucher.sParallelRateType," + cSessionManager.c_sDbPrefix + "Company_Finance_API.Get_Parallel_Rate_Type(\r\n" +
                            ":i_hWndFrame.frmEntryVoucher.dfsCompany));  END;")))

                        {
                            return false;
                        }
                    }
                    if (sParallelCurrency != Ifs.Fnd.ApplicationForms.Const.strNULL)
                    {
                        bThirdCurrExists = true;
                    }
                }
                if (sParallelCurrency != Ifs.Fnd.ApplicationForms.Const.strNULL)
                {

                    if (frmVoucherPosting.FromHandle(hWndFirstTab).GetParallelCurrencyRateType() != Sys.STRING_Null)
                        sParallelRateType = frmVoucherPosting.FromHandle(hWndFirstTab).GetParallelCurrencyRateType();

                    if (!(frmVoucherPosting.FromHandle(hWndFirstTab).GetThirdCurrencyAttributes(dfsCompany.Text, sParallelCurrency, sCurrencyCode, dfdVoucherDate.DateTime, "DUMMY", "DUMMY", sParallelBaseType, sParallelRateType)))
                    {
                        return false;
                    }
                    nParallelRate = frmVoucherPosting.FromHandle(hWndFirstTab).GetThirdCurrencyRate(dfsCompany.Text, sParallelCurrency);
                }
                else
                {
                    frmVoucherPosting.FromHandle(hWndFirstTab).i_sFinParallelBaseType = SalString.Null;
                    frmVoucherPosting.FromHandle(hWndFirstTab).i_sFinThirdCurrencyCode = SalString.Null;
                    frmVoucherPosting.FromHandle(hWndFirstTab).i_nFinThirdConversionFactor = SalNumber.Null;
                    frmVoucherPosting.FromHandle(hWndFirstTab).i_nFinThirdCurrencyRate = SalNumber.Null;
                    sParallelCurrency = SalString.Null;
                    sParallelBaseType = SalString.Null;
                    sParallelRateType = SalString.Null;

                }
                return true;
            }
            #endregion
        }
        

        /// <summary>
        /// Used specially for copy voucher and copy GL voucher
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean SetEntryAndApprovedToDefValues()
        {
            #region Actions
            using (new SalContext(this))
            {
                if (!(DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN " + sFormName + "dCurrentDate := SYSDATE; " + sFormName + "slUserId := " + cSessionManager.c_sDbPrefix + "User_Finance_API.User_Id; END;")))
                {
                    return false;
                }
                dfdDateReg.DateTime = dCurrentDate;
                dfsUserId.Text = slUserId;
                dfsEnteredByUserGroup.Text = dfsUserGroup.Text;
                dfdApprovalDate.DateTime = Sys.DATETIME_Null;
                dfsApprovedByUserid.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                dfsApprovedByUserGroup.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                dfdDateReg.EditDataItemSetEdited();
                dfsUserId.EditDataItemSetEdited();
                dfsEnteredByUserGroup.EditDataItemSetEdited();
                dfdApprovalDate.EditDataItemSetEdited();
                dfsApprovedByUserid.EditDataItemSetEdited();
                dfsApprovedByUserGroup.EditDataItemSetEdited();
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
                lsStmt = sFormName + "dVoucherDate := SYSDATE; ";
                lsStmt = lsStmt + "Curr_Code :=  &AO.Company_Finance_API.Get_Currency_Code(" + sFormName + "i_sCompany );";
                lsStmt = lsStmt + sFormName + "sCurrencyCode := Curr_Code;";
                lsStmt = lsStmt + sFormName + "sIsCurrencyEmu  :=  &AO.Currency_Code_API.Get_Valid_Emu(" + sFormName + "i_sCompany, Curr_Code, SYSDATE );";
                lsStmt = lsStmt + sFormName + "nDecimalsInAmount := NVL( &AO.Currency_Code_API.Get_Currency_Rounding(" + sFormName + "i_sCompany, Curr_Code	), 0); ";
                lsStmt = lsStmt + sFormName + "nDecimalsInRate := NVL( &AO.Currency_Code_API.Get_No_Of_Decimals_In_Rate(" + sFormName + "i_sCompany, Curr_Code), 0); ";
                lsStmt = lsStmt + sFormName + "sParallelCurrency :=  &AO.Company_Finance_API.Get_Parallel_Acc_Currency(" + sFormName + "i_sCompany, SYSDATE); ";
                lsStmt = lsStmt + sFormName + "dParallelCurrValidFrom := &AO.Company_Finance_API.Get_Time_Stamp(" + sFormName + "i_sCompany); ";
                lsStmt = lsStmt + sFormName + "sRoundingMethod := &AO.Company_Finance_API.Get_Tax_Rounding_Method_Db(" + sFormName + "i_sCompany); ";
                lsStmt = lsStmt + sFormName + "sAmountMethodGross := &AO.Def_Amount_Method_API.Decode( 'GROSS' ); ";
                lsStmt = lsStmt + sFormName + "sAmountMethodNet := &AO.Def_Amount_Method_API.Decode( 'NET' ); ";
                lsStmt = lsStmt + sFormName + "sTaxDirectionDisbursed := &AO.Tax_Direction_API.Decode( 'TAXDISBURSED' ); ";
                lsStmt = lsStmt + sFormName + "sTaxDirectionReceived := &AO.Tax_Direction_API.Decode( 'TAXRECEIVED' ); ";
                lsStmt = lsStmt + sFormName + "sTaxDirectionNoTax := &AO.Tax_Direction_API.Decode( 'NOTAX' ); ";

                lsStmt = lsStmt + sFormName + "sParallelBaseType := &AO.Company_Finance_API.Get_Parallel_Base_Db(" + sFormName + "i_sCompany); ";
                lsStmt = lsStmt + sFormName + "sParallelRateType := &AO.Company_Finance_API.Get_Parallel_Rate_Type(" + sFormName + "i_sCompany); ";
                lsStmt = lsStmt + "  IF (&AO.Transaction_SYS.METHOD_IS_INSTALLED('GEN_LED_VOUCHER_API','Get_Preliminary_Acc_Year_') ) THEN\r\n" +
                "                                         :i_hWndFrame.frmEntryVoucher.bGetPrelAccYearIsAvailable := 1;\r\n" +
                "                                    ELSE\r\n" +
                "                                           :i_hWndFrame.frmEntryVoucher.bGetPrelAccYearIsAvailable := 0;\r\n" +
                "                                    END IF;\r\n" +
                "                               ";
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("Company_Finance_API.Get_Currency_Code", System.Data.ParameterDirection.Input);
                    hints.Add("Currency_Code_API.Get_Valid_Emu", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                    hints.Add("Currency_Code_API.Get_Currency_Rounding", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                    hints.Add("Currency_Code_API.Get_No_Of_Decimals_In_Rate", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                    hints.Add("Company_Finance_API.Get_Parallel_Acc_Currency", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                    hints.Add("Company_Finance_API.Get_Time_Stamp", System.Data.ParameterDirection.Input);
                    hints.Add("Company_Finance_API.Get_Tax_Rounding_Method_Db", System.Data.ParameterDirection.Input);

                    hints.Add("Company_Finance_API.Get_Parallel_Base_Db", System.Data.ParameterDirection.Input);
                    hints.Add("Company_Finance_API.Get_Parallel_Rate_Type", System.Data.ParameterDirection.Input);
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
                    // Bug 77430, Begin

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        if (dfsCompany.Text == Ifs.Fnd.ApplicationForms.Const.strNULL || dfnVoucherNo.Number < 1)
                        {
                            return false;
                        }
                        if (sCancellation == "TRUE")
                        {
                            return false;
                        }
                        return true;

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
                            DbPLSQLBlock(cSessionManager.c_hSql, ":i_hWndFrame.frmEntryVoucher.sNoteExist := &AO.Voucher_Note_API.Check_Note_Exist(\r\n" +
                                "				:i_hWndFrame.frmEntryVoucher.dfsCompany,\r\n" +
                                "				:i_hWndFrame.frmEntryVoucher.dfnAccountingYear,\r\n" +
                                "			                :i_hWndFrame.frmEntryVoucher.ccsVoucherType.i_sMyValue,\r\n" +
                                "                                                                :i_hWndFrame.frmEntryVoucher.dfnVoucherNo)");
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
        /// <param name="p_nWhat"></param>
        /// <returns></returns>
        public virtual SalBoolean UM_CopyGLVoucher(SalNumber p_nWhat)
        {
            #region Actions
            using (new SalContext(this))
            {
                switch (p_nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        if (((SourceStateGet() == Ifs.Fnd.ApplicationForms.Const.DATASOURCE_Empty) || !(Sal.SendMsg(i_hWndFrame, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0))) && Ifs.Fnd.ApplicationForms.Var.Security.IsViewAvailable(
                            "gen_led_voucher"))
                        {
                            return false;
                        }
                        if (sCancellation == "TRUE")
                        {
                            return false;
                        }
                        return true;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        if (cbCorrection.Checked == true)
                        {
                            bCorrection = true;
                        }
                        else
                        {
                            bCorrection = false;
                        }
                        if (dlgGLVoucher.ModalDialog(i_hWndFrame, i_sCompany, ref nYear, ref nPeriod, ref nVouNumber, ref sGlCpyVouType, ref bCorrection, ref bReverse) == Sys.IDOK)
                        {
                            // Bug 79831, Begin
                            if (ExistPeriodAlloction())
                            {
                                Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_PeriodInfoNotCopy, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                            }
                            // Bug 79831, End
                            if (IsGLVoucherSummerized())
                            {
                                Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_GLVouRowsNoCopy, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                            }
                            else
                            {
                                SetEntryAndApprovedToDefValues();
                                frmVoucherPosting.FromHandle(hWndFirstTab).CopyGLVouRow();
                                frmVoucherPosting.FromHandle(hWndFirstTab).bCopyFromGL = false;
                            }
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
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalBoolean UM_CopyVoucher(SalNumber nWhat)
        {
            frmVoucherRow voucherRow = null;
            SalNumber nRow = Sys.TBL_MinRow;

            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        if ((SourceStateGet() == Ifs.Fnd.ApplicationForms.Const.DATASOURCE_Empty) ||
                            ((bool)Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0)) ||
                            !Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("dlgCopyVoucher")))
                            return false;

                        if ((cbInterimVoucher.Checked == true) && (dfsVoucherGroup.Text != "M"))
                            return false;

                        if (dfsVoucherGroup.Text != "M" && dfsVoucherGroup.Text != "K" && dfsVoucherGroup.Text != "Q")
                            return false;

                        if (cmbsVoucherStatus.Text == Sal.ListQueryTextX(cmbsVoucherStatus, 3))
                            return false;

                        if (sCancellation == "TRUE")
                            return false;

                        // In case the tab is not activated at the time hWndSecondTab is assinged it is assinged again
                        hWndSecondTab = TabAttachedWindowHandleGet(picTab.FindName("ViewVouRow"));
                        nRow = Sys.TBL_MinRow;
                        if (hWndSecondTab != Sys.hWndNULL)
                        {
                            voucherRow = frmVoucherRow.FromHandle(hWndSecondTab);
                            while (Sal.TblFindNextRow(voucherRow.tblVoucherRow, ref nRow, 0, 0))
                            {
                                Sal.TblSetContext(voucherRow.tblVoucherRow, nRow);
                                if ((((SalString)voucherRow.tblVoucherRow_colsTransCode.Text).Trim().ToUpper() != "MANUAL") && (dfsVoucherGroup.Text != "M"))
                                    return false;

                                // Bug 77430, Begin
                                if (sAuthLevel == "ApproveOnly")
                                    return false;

                                // Bug 77430, End
                            }
                        }
                        return true;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:

                        SalBoolean bReverse = false;
                        SalBoolean bCorrection = false;
                        SalBoolean bExternalVou = false;
                        SalBoolean bTaxCodeExists = false;
                        SalString strSql = "";
                        SalString strSql1 = "";
                        SalString strSql2 = "";
                        SalString strSql3 = "";

                        if (hWndSecondTab != Sys.hWndNULL)
                        {
                            nRow = Sys.TBL_MinRow;
                            voucherRow = frmVoucherRow.FromHandle(hWndSecondTab);
                            while (Sal.TblFindNextRow(voucherRow.tblVoucherRow, ref nRow, 0, 0))
                            {
                                Sal.TblSetFocusRow(voucherRow.tblVoucherRow, nRow);
                                if (((SalString)voucherRow.tblVoucherRow_colsTransCode.Text).ToUpper() == "EXTERNAL")
                                    bExternalVou = true;

                                // Bug 102106, Begin - Modified the IF condition
                                if (((SalString)frmVoucherRow.FromHandle(hWndSecondTab).tblVoucherRow_colsTransCode.Text).ToUpper() != "EXTERNAL" && frmVoucherRow.FromHandle(hWndSecondTab).tblVoucherRow_colsOptionalCode.Text != Ifs.Fnd.ApplicationForms.Const.strNULL)
                                    bTaxCodeExists = true;

                                // Bug 102106, End
                                if (bExternalVou && bTaxCodeExists)
                                {
                                    Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_ExternalTransMessage, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                                    return false;
                                }

                                if (((SalString)voucherRow.tblVoucherRow_colsPeriodAllocation.Text).Trim().ToUpper() == "Y")
                                    Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_PeriodInfoNotCopy, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);

                            }
                        }
                        sVouType = this.ccsVoucherType.i_sMyValue;
                        nYear = this.dfnAccountingYear.Number;
                        nVouNumber = this.dfnVoucherNo.Number;
                        if (dlgCopyVoucher.ModalDialog(Ifs.Fnd.ApplicationForms.Int.Explorer.ExplorerForm, dfsCompany.Text, ccsVoucherType.i_sMyValue, dfnVoucherNo.Number, (dfnAccountingYear.Number * 100) + dfnAccountingPeriod.Number, ref bReverse, ref bCorrection))
                        {
                            Sal.WaitCursor(true);
                            CopyHeaderVoucher();
                            frmVoucherPosting voucherPosting = frmVoucherPosting.FromHandle(hWndFirstTab);
                            nRow = Sys.TBL_MinRow;
                            if (Sal.TblFindNextRow(voucherPosting.tblVoucherPosting, ref nRow, 0, 0))
                                voucherPosting.CopyDetailVoucher(bReverse, bCorrection);

                            picTab.BringToTop(0, true);
                            nRow = Sys.TBL_MinRow;
                            if (!Sal.TblFindNextRow(voucherPosting.tblVoucherPosting, ref nRow, 0, 0))
                            {
                                nRow = Sys.TBL_MinRow;
                                sAutoTax = "TRUE";
                                if (hWndSecondTab != Sys.hWndNULL)
                                {
                                    if (Sal.TblFindNextRow(voucherRow.tblVoucherRow, ref nRow, 0, 0))
                                    {
                                        strSql1 = " SELECT ROW_NO, ROW_GROUP_ID, ACCOUNT,CODE_B,CODE_C,CODE_D,CODE_E,CODE_F,CODE_G,CODE_H,CODE_I,CODE_J," + "PROCESS_CODE,OPTIONAL_CODE,TAX_DIRECTION,CURRENCY_CODE,CURRENCY_TYPE,CONVERSION_FACTOR," + "CORRECTION,CURRENCY_DEBET_AMOUNT,CURRENCY_CREDIT_AMOUNT,CURRENCY_TAX_AMOUNT," +
                                        "CURRENCY_GROSS_AMOUNT,CURRENCY_RATE,DEBET_AMOUNT,CREDIT_AMOUNT," + "TAX_AMOUNT,GROSS_AMOUNT,THIRD_CURRENCY_DEBIT_AMOUNT,THIRD_CURRENCY_CREDIT_AMOUNT," + "NVL(THIRD_CURRENCY_DEBIT_AMOUNT,0) - NVL(THIRD_CURRENCY_CREDIT_AMOUNT,0)," +
                                        "QUANTITY,PERIOD_ALLOCATION,TEXT,PROJECT_ACTIVITY_ID,UPDATE_ERROR," + "ACCOUNTING_PERIOD,DECIMALS_IN_AMOUNT,ACC_DECIMALS_IN_AMOUNT," + "REFERENCE_ROW_NO,INTERNAL_SEQ_NUMBER,FUNCTION_GROUP,REFERENCE_NUMBER,REFERENCE_SERIE" +
                                        "," + "PARALLEL_CURR_RATE_TYPE, PARALLEL_CURRENCY_RATE, PARALLEL_CONVERSION_FACTOR, PARALLEL_CURR_TAX_AMOUNT, PARALLEL_CURR_GROSS_AMOUNT, PARALLEL_CURR_TAX_BASE_AMOUNT";
                                        strSql2 = " INTO :hWndFirstTab.frmVoucherPosting.tblVoucherPosting_colnRowNo," + ":hWndFirstTab.frmVoucherPosting.tblVoucherPosting_colnRowGroupId," + ":hWndFirstTab.frmVoucherPosting.tblVoucherPosting_colsAccount," + ":hWndFirstTab.frmVoucherPosting.tblVoucherPosting_colsCodeB," +
                                        ":hWndFirstTab.frmVoucherPosting.tblVoucherPosting_colsCodeC," + ":hWndFirstTab.frmVoucherPosting.tblVoucherPosting_colsCodeD," + ":hWndFirstTab.frmVoucherPosting.tblVoucherPosting_colsCodeE," + ":hWndFirstTab.frmVoucherPosting.tblVoucherPosting_colsCodeF," +
                                        ":hWndFirstTab.frmVoucherPosting.tblVoucherPosting_colsCodeG," + ":hWndFirstTab.frmVoucherPosting.tblVoucherPosting_colsCodeH," + ":hWndFirstTab.frmVoucherPosting.tblVoucherPosting_colsCodeI," + ":hWndFirstTab.frmVoucherPosting.tblVoucherPosting_colsCodeJ," +
                                        ":hWndFirstTab.frmVoucherPosting.tblVoucherPosting_colsProcessCode," + ":hWndFirstTab.frmVoucherPosting.tblVoucherPosting_colsOptionalCode," + ":hWndFirstTab.frmVoucherPosting.tblVoucherPosting_colsTaxDirection," + ":hWndFirstTab.frmVoucherPosting.tblVoucherPosting_colsCurrencyCode," +
                                        ":hWndFirstTab.frmVoucherPosting.tblVoucherPosting_colsCurrencyType," + ":hWndFirstTab.frmVoucherPosting.tblVoucherPosting_colnConversionFactor," + ":hWndFirstTab.frmVoucherPosting.tblVoucherPosting_colCorrection," + ":hWndFirstTab.frmVoucherPosting.tblVoucherPosting_colnCurrencyDebetAmount," +
                                        ":hWndFirstTab.frmVoucherPosting.tblVoucherPosting_colnCurrencyCreditAmount," + ":hWndFirstTab.frmVoucherPosting.tblVoucherPosting_colnCurrencyTaxAmount," + ":hWndFirstTab.frmVoucherPosting.tblVoucherPosting_colnCurrencyGrossAmount," +
                                        ":hWndFirstTab.frmVoucherPosting.tblVoucherPosting_colnCurrencyRate," + ":hWndFirstTab.frmVoucherPosting.tblVoucherPosting_colnDebetAmount," + ":hWndFirstTab.frmVoucherPosting.tblVoucherPosting_colnCreditAmount," + ":hWndFirstTab.frmVoucherPosting.tblVoucherPosting_colnTaxAmount," +
                                        ":hWndFirstTab.frmVoucherPosting.tblVoucherPosting_colnGrossAmount," + ":hWndFirstTab.frmVoucherPosting.tblVoucherPosting_colnThirdCurrencyDebitAmount," + ":hWndFirstTab.frmVoucherPosting.tblVoucherPosting_colnThirdCurrencyCreditAmount," +
                                        ":hWndFirstTab.frmVoucherPosting.tblVoucherPosting_colnThirdCurrencyAmount," + ":hWndFirstTab.frmVoucherPosting.tblVoucherPosting_colnQuantity," + ":hWndFirstTab.frmVoucherPosting.tblVoucherPosting_colsPeriodAllocation," + ":hWndFirstTab.frmVoucherPosting.tblVoucherPosting_colsText," +
                                        ":hWndFirstTab.frmVoucherPosting.tblVoucherPosting_colnProjectActivityId," + ":hWndFirstTab.frmVoucherPosting.tblVoucherPosting_colsUpdateError," + ":hWndFirstTab.frmVoucherPosting.tblVoucherPosting_colnAccountingPeriod," + ":hWndFirstTab.frmVoucherPosting.tblVoucherPosting_colnDecimalsInAmount," +
                                        ":hWndFirstTab.frmVoucherPosting.tblVoucherPosting_colnAccDecimalsInAmount," + ":hWndFirstTab.frmVoucherPosting.tblVoucherPosting_colnReferenceRowNo," + ":hWndFirstTab.frmVoucherPosting.tblVoucherPosting_colnInternalSeqNumber," + ":hWndFirstTab.frmVoucherPosting.tblVoucherPosting_colsFunctionGroup," +
                                        ":hWndFirstTab.frmVoucherPosting.tblVoucherPosting_colsReferenceNumber," + ":hWndFirstTab.frmVoucherPosting.tblVoucherPosting_colsReferenceSerie" +
                                        "," +
                                        ":hWndFirstTab.frmVoucherPosting.tblVoucherPosting_colnParallelCurrRateType," + ":hWndFirstTab.frmVoucherPosting.tblVoucherPosting_colnParallelCurrRate," + ":hWndFirstTab.frmVoucherPosting.tblVoucherPosting_colnParallelCurrConvFactor," +
                                        ":hWndFirstTab.frmVoucherPosting.tblVoucherPosting_colnParallelCurrTaxAmount," + ":hWndFirstTab.frmVoucherPosting.tblVoucherPosting_colnParallelCurrGrossAmount," + ":hWndFirstTab.frmVoucherPosting.tblVoucherPosting_colnParallelCurrTaxBaseAmount";
                                        strSql3 = " FROM " + cSessionManager.c_sDbPrefix + "VOUCHER_ROW WHERE COMPANY = :i_hWndFrame.frmEntryVoucher.dfsCompany AND VOUCHER_TYPE = :i_hWndFrame.frmEntryVoucher.sVouType AND" + " ACCOUNTING_YEAR = :i_hWndFrame.frmEntryVoucher.nYear AND" +
                                        " VOUCHER_NO = :i_hWndFrame.frmEntryVoucher.nVouNumber";
                                        Sal.TblPopulate(voucherPosting.tblVoucherPosting, cSessionManager.c_hSql, strSql1 + strSql2 + strSql3, Sys.TBL_FillAll);
                                        nRow = Sys.TBL_MinRow;
                                        while (Sal.TblFindNextRow(voucherPosting.tblVoucherPosting, ref nRow, 0, 0))
                                        {
                                            Sal.TblSetFocusRow(voucherPosting.tblVoucherPosting, nRow);
                                            voucherPosting.tblVoucherPosting_colsTransCode.Text = "MANUAL";
                                            voucherPosting.tblVoucherPosting_colsCompany.Text = this.dfsCompany.Text;
                                            voucherPosting.tblVoucherPosting_colsVoucherType.Text = this.sVouType;
                                            voucherPosting.tblVoucherPosting_colnAccountingYear.Number = this.nYear;
                                            voucherPosting.tblVoucherPosting_colnVoucherNo.Number = this.nVouNumber;
                                            voucherPosting.tblVoucherPosting_colsAutoTaxVouEntry.Text = "FALSE";
                                            if (Sal.IsNull(voucherPosting.tblVoucherPosting_colsCurrencyType))
                                                voucherPosting.tblVoucherPosting_colsCurrencyType.Text = this.dfsCurrencyType.Text;

                                            strSql = "SELECT &AO.VOUCHER_ROW_API.Is_Add_Internal( :i_hWndFrame.frmEntryVoucher.hWndFirstTab.frmVoucherPosting.tblVoucherPosting_colsCompany, :i_hWndFrame.frmEntryVoucher.hWndFirstTab.frmVoucherPosting.tblVoucherPosting_colnInternalSeqNumber," +
                                            ":i_hWndFrame.frmEntryVoucher.hWndFirstTab.frmVoucherPosting.tblVoucherPosting_colsAccount, :i_hWndFrame.frmEntryVoucher.hWndFirstTab.frmVoucherPosting.tblVoucherPosting_colsVoucherType, :i_hWndFrame.frmEntryVoucher.i_hWndFrame.frmEntryVoucher.nVouNumber,:i_hWndFrame.frmEntryVoucher.nYear), " +
                                            "&AO.ACCOUNTING_CODE_PART_A_API.Is_Stat_Account( :i_hWndFrame.frmEntryVoucher.hWndFirstTab.frmVoucherPosting.tblVoucherPosting_colsCompany, :i_hWndFrame.frmEntryVoucher.hWndFirstTab.frmVoucherPosting.tblVoucherPosting_colsAccount), " +
                                            "&AO.Accounting_Code_Part_A_API.Get_Required_Code_Part( :i_hWndFrame.frmEntryVoucher.hWndFirstTab.frmVoucherPosting.tblVoucherPosting_colsCompany, :i_hWndFrame.frmEntryVoucher.hWndFirstTab.frmVoucherPosting.tblVoucherPosting_colsAccount), " +
                                            "&AO.VOUCHER_ROW_API.Is_Manual_Added( :i_hWndFrame.frmEntryVoucher.hWndFirstTab.frmVoucherPosting.tblVoucherPosting_colsCompany, :i_hWndFrame.frmEntryVoucher.hWndFirstTab.frmVoucherPosting.tblVoucherPosting_colnInternalSeqNumber," +
                                            ":i_hWndFrame.frmEntryVoucher.hWndFirstTab.frmVoucherPosting.tblVoucherPosting_colsAccount) INTO :i_hWndFrame.frmEntryVoucher.hWndFirstTab.frmVoucherPosting.tblVoucherPosting_colAddInternal, :i_hWndFrame.frmEntryVoucher.hWndFirstTab.frmVoucherPosting.tblVoucherPosting_colIsStatAccount," +
                                            ":i_hWndFrame.frmEntryVoucher.hWndFirstTab.frmVoucherPosting.tblVoucherPosting_colsCodeDemand, :i_hWndFrame.frmEntryVoucher.hWndFirstTab.frmVoucherPosting.tblVoucherPosting_colsManualAdded FROM DUAL";
                                            using (SignatureHints hints = SignatureHints.NewContext())
                                            {
                                                hints.Add("VOUCHER_ROW_API.Is_Add_Internal", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                                                hints.Add("ACCOUNTING_CODE_PART_A_API.Is_Stat_Account", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                                                hints.Add("Accounting_Code_Part_A_API.Get_Required_Code_Part", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                                                hints.Add("VOUCHER_ROW_API.Is_Manual_Added", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                                                DbPLSQLBlock(strSql);
                                            }
                                            Sal.SendMsgToChildren(voucherPosting.tblVoucherPosting, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
                                        }
                                        Sal.TblSetFocusRow(voucherPosting.tblVoucherPosting, 0);
                                    }
                                }
                                voucherPosting.CopyDetailVoucher(bReverse, bCorrection);
                            }
                            Sal.WaitCursor(false);
                            return true;
                        }
                        return false;
                }

                return false;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="p_nWhat"></param>
        /// <returns></returns>
        public virtual SalBoolean UM_CreateVouTemplate(SalNumber p_nWhat)
        {
            #region Local Variables
            SalString sCompany = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                switch (p_nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        if (sCancellation == "TRUE")
                        {
                            return false;
                        }
                        if ((cmbsVoucherStatus.Text == Sal.ListQueryTextX(cmbsVoucherStatus, 0) || cmbsVoucherStatus.Text == Sal.ListQueryTextX(cmbsVoucherStatus, 1)) && !(Sal.SendMsg(i_hWndFrame, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire,
                            0)) && (cmbsVoucherStatus.Text != Ifs.Fnd.ApplicationForms.Const.strNULL) && Ifs.Fnd.ApplicationForms.Var.Security.IsViewAvailable("voucher_template"))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                        goto case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        sCompany = dfsCompany.Text;
                        if (dlgCreateVouTemplate.ModalDialog(Ifs.Fnd.ApplicationForms.Int.Explorer.ExplorerForm, ref sMasterTemplate, ref sMasterDesc, ref dMasterValidFrom, ref dMasterValidUntil, ref sIncludeAmount, ref sCompany) == Sys.IDOK)
                        {
                            CreateTemplates();
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
        public virtual SalBoolean UM_InstantUpdate(SalNumber p_nWhat)
        {
            #region Local Variables
            SalArray<SalNumber> nVouNo = new SalArray<SalNumber>();
            SalArray<SalString> sVouType = new SalArray<SalString>();
            SalArray<SalNumber> nAccountingYear = new SalArray<SalNumber>();
            SalString sObjid = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                switch (p_nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        if (bGetPrelAccYearIsAvailable)
                        {
                            if ((cmbsVoucherStatus.Text == Sal.ListQueryTextX(cmbsVoucherStatus, 0) || cmbsVoucherStatus.Text == Sal.ListQueryTextX(cmbsVoucherStatus, 3)) && (cmbsVoucherStatus.Text != Ifs.Fnd.ApplicationForms.Const.strNULL) && (!(Sal.SendMsg(i_hWndFrame,
                                Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0))) && Ifs.Fnd.ApplicationForms.Var.Security.IsViewAvailable("gen_led_voucher"))
                            {
                                if (IsPcaUpdateBlocked())
                                {
                                    return false;
                                }
                                else
                                {
                                    return true;
                                }
                            }
                        }
                        return false;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        nVouNo[0] = dfnVoucherNo.Number;
                        sVouType[0] = ccsVoucherType.i_sMyValue;
                        nAccountingYear[0] = dfnAccountingYear.Number;
                        if (dlgInstantUpdate.ModalDialog(Ifs.Fnd.ApplicationForms.Int.Explorer.ExplorerForm, i_sCompany, nVouNo, sVouType, nAccountingYear, 1) == Sys.IDOK)
                        {
                            // Above code fails in correctly updating the record selector (clicking on it will only update it).
                            bIsUpdateGLRefreshed = true;
                            SalNumber nReturnValue = Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceRefresh, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                            Sal.SetFocus(this.dfdVoucherDate);
                            return nReturnValue;

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
        public virtual SalBoolean UM_InterimVoucher(SalNumber p_nWhat)
        {
            #region Local Variables
            SalString __sValue = "";
            SalString sObjid = "";
            SalString lsTransCode = "";
            SalNumber nRow = 0;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                switch (p_nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        if ((SourceStateGet() == Ifs.Fnd.ApplicationForms.Const.DATASOURCE_Empty) || ((bool)Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0)))
                        {
                            return false;
                        }
                        if ((cmbsVoucherStatus.Text != Sal.ListQueryTextX(cmbsVoucherStatus, 0)) || (cbInterimVoucher.Checked == true))
                        {
                            return false;
                        }
                        if ((!(Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("dlgInterimVoucher")))) || (!(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Voucher_API.Interim_Voucher"))))
                        {
                            return false;
                        }
                        if ((!(Ifs.Fnd.ApplicationForms.Var.Security.IsViewAvailable("USER_GROUP_MEMBER_FINANCE4"))) || (!(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("USER_GROUP_FINANCE_API.Get_Allowed_Acc_Period"))))
                        {
                            return false;
                        }
                        if (dfsRevCostClearVoucher.Text == "TRUE")
                        {
                            return false;
                        }
                        if (sCancellation == "TRUE")
                        {
                            return false;
                        }
                        // Bug 104284 Begin
                        if (dfsVoucherGroup.Text == "Z")
                        {
                            return false;
                        }
                        // Bug 104284 End
                        nRow = Sys.TBL_MinRow;
                        if (hWndSecondTab != Sys.hWndNULL)
                        {
                            while (Sal.TblFindNextRow(frmVoucherRow.FromHandle(hWndSecondTab).tblVoucherRow, ref nRow, 0, 0))
                            {
                                Sal.TblSetContext(frmVoucherRow.FromHandle(hWndSecondTab).tblVoucherRow, nRow);
                                if (((SalString)frmVoucherRow.FromHandle(hWndSecondTab).tblVoucherRow_colsPeriodAllocation.Text).Trim().ToUpper() == "Y")
                                {
                                    return false;
                                }
                                lsTransCode = ((SalString)frmVoucherRow.FromHandle(hWndSecondTab).tblVoucherRow_colsTransCode.Text).Trim().ToUpper();
                                // Bug 79335 , Begin. Check for allowed transaction codes for interim voucher
                                if (!((lsTransCode == "MANUAL") || (lsTransCode == "AP1") || (lsTransCode == "AP2") || (lsTransCode == "AP3") || (lsTransCode == "AP4")) && !((lsTransCode == "EXTERNAL") && (dfsVoucherGroup.Text == "M" || dfsVoucherGroup.Text == "K" ||
                                dfsVoucherGroup.Text == "Q")))
                                {
                                    return false;
                                }
                                // Bug 79335 , End.
                                if (((SalString)frmVoucherRow.FromHandle(hWndSecondTab).tblVoucherRow_colCorrection.Text).Trim().ToUpper() == "Y")
                                {
                                    return false;
                                }
                            }
                        }
                        return true;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        __sValue = SalString.FromHandle(ccsVoucherType.EditDataItemValueGet());
                        sVoucherType = __sValue;
                        dVoucherDate = dfdVoucherDate.DateTime;
                        nAccountingYear = dfnAccountingYear.Number;
                        nAccountingPeriod = dfnAccountingPeriod.Number;
                        // The User group selected from dlgInterimVoucher needs to be obtained in this form Hence Pass it as Receive Parameter
                        // First Assign value of dfsUserGroup to sInterimVouUserGrp
                        sInterimVouUserGrp = dfsUserGroup.Text;
                        sInterimUser = Ifs.Fnd.ApplicationForms.Int.FndUser();
                        // Now Pass it to  dlgInterimVoucher
                        if (dlgInterimVoucher.ModalDialog(Ifs.Fnd.ApplicationForms.Int.Explorer.ExplorerForm, dfsCompany.Text, sSimulationVoucher, sInterimUser, ref sInterimVouUserGrp, ref nAccountingYear, ref nAccountingPeriod, ref sVoucherType, ref dInterimVoucherDate))
                        {
                            // MethodProgress... FUNCTION use to display progress bar
                            MethodProgressStart(i_hWndFrame, Properties.Resources.WH_InterimVoucher, Properties.Resources.TEXT_InVo_Process, "FETCH", true, SalWindowHandle.Null);
                            MethodProgressStepAdd(4);
                            MethodProgressStep();
                            if (DbTransactionBegin(ref cSessionManager.c_hSql))
                            {
                                MethodProgressStep();
                                DataSourcePrepareRollback();
                                if (CreateInterimVoucher())
                                {
                                    MethodProgressStep();
                                    
                                    if (DbTransactionEnd(cSessionManager.c_hSql))
                                    {
                                        MethodProgressStep();
                                        DataSourceSaveMarkCommitted();
                                        MethodProgressDone();
                                        cbInterimVoucher.EditDataItemValueSet(0, ((SalString)"Y").ToHandle());
                                        sObjid = DataRecordIdGet();
                                        DataSourceUserWhere(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, ("Objid = " + "'" + sObjid + "'").ToHandle());
                                        DataSourcePopulateIt(Ifs.Fnd.ApplicationForms.Const.POPULATE_Single);
                                        if (!(Sal.IsNull(this.dfnVoucherNoReference)))
                                        {
                                            this.dfsReferenceCompany.Text = this.dfsCompany.Text;
                                        }
                                        Sal.WaitCursor(false);
                                        return true;
                                    }
                                }
                                DataSourceMarkRollback();
                                DbTransactionClear(cSessionManager.c_hSql);
                                MethodProgressDone();
                                Sal.WaitCursor(false);
                                return false;
                            }
                        }
                        return true;
                }
            }

            return false;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="p_nWhat"></param>
        /// <returns></returns>
        public virtual SalBoolean UM_UseVouTemplate(SalNumber p_nWhat)
        {
            #region Local Variables
            SalDateTime dVoucherDate = SalDateTime.Null;
            SalString sCompany = "";
            SalNumber i = 0;
            SalNumber nItems = 0;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                switch (p_nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        if ((cmbsVoucherStatus.Text == Ifs.Fnd.ApplicationForms.Const.strNULL) || (!(Ifs.Fnd.ApplicationForms.Var.Security.IsViewAvailable("voucher_template"))) || (cmbsVoucherStatus.Text == Sal.ListQueryTextX(cmbsVoucherStatus, 3)))
                        {
                            return false;
                        }
                        if (dfsVoucherGroup.Text == "Z")
                        {
                            return CheckIfPCAManual();
                        }
                        if (dfsVoucherGroup.Text != "M" && dfsVoucherGroup.Text != "K" && dfsVoucherGroup.Text != "Q")
                        {
                            return false;
                        }
                        // Bug 77430, Begin
                        if (sAuthLevel == "ApproveOnly")
                        {
                            return false;
                        }
                        // Bug 77430, End
                        if (sCancellation == "TRUE")
                        {
                            return false;
                        }
                        return true;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        dVoucherDate = dfdVoucherDate.DateTime;
                        sCompany = dfsCompany.Text;
                        sMasterUseTemplate.SetUpperBound(1, -1);
                        if (dlgUseVouTemplate.ModalDialog(Ifs.Fnd.ApplicationForms.Int.Explorer.ExplorerForm, dVoucherDate, sCompany, ref sMasterUseTemplate) == Sys.IDOK)
                        {
                            nItems = sMasterUseTemplate.GetUpperBound(1);
                            if (nItems == 0)
                            {
                                sTemplateList = ":i_hWndParent.frmEntryVoucher.sMasterUseTemplate[ 0 ]";
                            }
                            else
                            {
                                i = 1;
                                sTemplateList = ":i_hWndParent.frmEntryVoucher.sMasterUseTemplate[" + ((SalNumber)0).ToString(0) + "]";
                                while (i < (nItems + 1))
                                {
                                    sTemplateList = sTemplateList + " OR TEMPLATE =  :i_hWndParent.frmEntryVoucher.sMasterUseTemplate[" + i.ToString(0) + "]";
                                    i = i + 1;
                                }
                            }
                            frmVoucherPosting.FromHandle(hWndFirstTab).UseTemplates();
                            frmVoucherPosting.FromHandle(hWndFirstTab).bCopyFromTemplate = false;
                        }
                        break;
                }
            }

            return false;
            #endregion
        }

        public virtual SalBoolean ChangeCompany(SalNumber p_nWhat)
        {
            #region Actions
            using (new SalContext(this))
            {
                if (p_nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
                {
                    return Sal.SendClassMessage(Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Sys.lParam);
                }
                else
                {
                    return Sal.SendClassMessage(Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Sys.lParam);
                }
            }
            #endregion

        }      

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber ValidateUserGroup()
        {
            #region Local Variables
            SalString lsStmt = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                IDictionary<string, string> namedBindVariables = new Dictionary<string, string>();
                namedBindVariables.Add("sVouExist", this.QualifiedVarBindName("sVouExist"));
                namedBindVariables.Add("dfsCompany", dfsCompany.QualifiedBindName);
                namedBindVariables.Add("ccsVoucherType", ccsVoucherType.QualifiedBindName);
                namedBindVariables.Add("dfnAccountingYear", dfnAccountingYear.QualifiedBindName);
                namedBindVariables.Add("dfnVoucherNo", dfnVoucherNo.QualifiedBindName);
                namedBindVariables.Add("dfsVoucherGroup", dfsVoucherGroup.QualifiedBindName);
                namedBindVariables.Add("dfsUserGroup", dfsUserGroup.QualifiedBindName);
                namedBindVariables.Add("sVoucherType", this.QualifiedVarBindName("sVoucherType"));
                namedBindVariables.Add("sPrevUserGroup", this.QualifiedVarBindName("sPrevUserGroup"));

                if (!DbPLSQLBlock(@" DECLARE
                                        voucher_group_ VARCHAR2(10);
                                     BEGIN 
                                        {sVouExist} := &AO.Voucher_API.Is_Voucher_Exist({dfsCompany} IN, {ccsVoucherType} IN,
                                                                                 {dfnAccountingYear} IN, {dfnVoucherNo} IN);
                                        IF ({sVouExist} = 'FALSE') THEN
                                            voucher_group_ := &AO.Voucher_Type_API.Get_Voucher_Group( {dfsCompany} IN, {ccsVoucherType} IN);
                                            voucher_group_ := NVL(voucher_group_, 'M');
                                            
                                            IF (voucher_group_ = 'M' OR voucher_group_ = 'Q' OR voucher_group_ = 'K') THEN
                                                &AO.Voucher_Type_User_Group_Api.Get_Default_Voucher_Type( {sVoucherType} OUT, {dfsCompany} IN, {dfsUserGroup} IN, {dfnAccountingYear} IN, 'M');
                                            END IF;
                                            {dfsVoucherGroup} := voucher_group_;
                                        ELSE
                                            IF {dfsUserGroup} != {sPrevUserGroup} THEN
                                               voucher_group_ := &AO.Voucher_Type_API.Get_Voucher_Group( {dfsCompany} IN, {ccsVoucherType} IN);
                                               {dfsVoucherGroup} := voucher_group_;
                                            END IF;
                                        END IF;
                                        
                                    END;
                          ", namedBindVariables))
                {
                    return Sys.VALIDATE_Cancel;
                }

                if (sVouExist == "FALSE")
                {                    
                    if (dfsVoucherGroup.Text == Sys.STRING_Null)
                    {
                        dfsVoucherGroup.Text = "M";
                    }
                    if (dfsVoucherGroup.Text == "M" || dfsVoucherGroup.Text == "Q" || dfsVoucherGroup.Text == "K")
                    {
                        ccsVoucherType.EditDataItemValueSet(1, sVoucherType.ToHandle());
                        if (sVoucherType != SalString.Null)
                        {
                            ValidateVoucherType();
                            ccsVoucherType.i_sMyValue = sVoucherType;
                        }
                    }
                    return Sys.VALIDATE_Ok;
                }
                else
                {
                    if (dfsUserGroup.Text != sPrevUserGroup)
                    {
                        if (dfsVoucherGroup.Text == "M" || dfsVoucherGroup.Text == "Q" || dfsVoucherGroup.Text == "K")
                        {
                            sVoucherType = ccsVoucherType.i_sMyValue;
                            if (sVoucherType != SalString.Null)
                            {
                                ValidateVoucherType();
                            }
                        }
                        sPrevUserGroup = dfsUserGroup.Text;
                        return Sys.VALIDATE_Ok;
                    }
                }
                return Sys.VALIDATE_Ok;
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean ValidateVoucherDate()
        {
            #region Local Variables
            SalString lsStmt = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                if (!(Sal.IsNull(dfdVoucherDate)))
                {
                    // Initialise parallel currency when date is changed
                    if (dfdVoucherDate.DateTime < dParallelCurrValidFrom)
                    {
                        sParallelCurrency = SalString.Null;
                        bThirdCurrExists = false;
                    }
                    else if ((sParallelCurrency == SalString.Null) && (dParallelCurrValidFrom != SalDateTime.Null))
                    {
                        lsStmt = lsStmt + " {sParallelCurrency} :=  &AO.Company_Finance_API.Get_Parallel_Acc_Currency({i_sCompany} IN, SYSDATE); ";

                    }
                    nAccountingYear = dfnAccountingYear.Number;
                    nAccountingPeriod = dfnAccountingPeriod.Number;
                    if ((sIsCurrencyEmu == "TRUE") && (dfdVoucherDate.DateTime >= ((SalString)"1999/01/01").ToDate()))
                    {
                        lsStmt = lsStmt + " {dfsCurrencyType} :=  &AO.Currency_Type_API.Get_Default_Euro_Type__({i_sCompany} IN); ";                                               
                    }
                    else
                    {
                        lsStmt = lsStmt + " {dfsCurrencyType} :=  &AO.Currency_Type_API.Get_Default_Type({i_sCompany} IN);";                        
                    }
                    
                    lsStmt = "BEGIN "
                                 + lsStmt
                                 + @" &AO.Accounting_Period_API.Get_Accounting_Year( {nAccountingYear} OUT, {nAccountingPeriod} OUT, {dfsCompany} IN, {dfdVoucherDate} IN, {dfsUserGroup} IN); 
                                         &AO.Accounting_Period_Api.Get_YearPer_For_YearEnd_User( {nYearYep} OUT, {nPeriodYep} OUT, {dfsCompany} IN, {dfsUserGroup} IN, {dfdVoucherDate} IN  );
                             END;";

                    IDictionary<string, string> namedBindVariables = new Dictionary<string, string>();
                    namedBindVariables.Add("sParallelCurrency", this.QualifiedVarBindName("sParallelCurrency"));
                    namedBindVariables.Add("i_sCompany", this.QualifiedVarBindName("i_sCompany"));
                    namedBindVariables.Add("dfsCurrencyType", dfsCurrencyType.QualifiedBindName);
                    namedBindVariables.Add("nAccountingYear", this.QualifiedVarBindName("nAccountingYear"));
                    namedBindVariables.Add("nAccountingPeriod", this.QualifiedVarBindName("nAccountingPeriod"));
                    namedBindVariables.Add("dfsCompany", dfsCompany.QualifiedBindName);
                    namedBindVariables.Add("dfdVoucherDate", dfdVoucherDate.QualifiedBindName);
                    namedBindVariables.Add("dfsUserGroup", dfsUserGroup.QualifiedBindName);
                    namedBindVariables.Add("nYearYep", this.QualifiedVarBindName("nYearYep"));
                    namedBindVariables.Add("nPeriodYep", this.QualifiedVarBindName("nPeriodYep"));
                    
                    if (!DbPLSQLBlock(lsStmt, namedBindVariables))
                    {
                        return Sys.VALIDATE_Cancel;
                    }

                    if (sParallelCurrency != SalString.Null)
                    {
                        bThirdCurrExists = true;
                    }
                    

                    if ((nYearYep != 0) && (nPeriodYep != 0))
                    {
                        nAccountingYear = nYearYep;
                        nAccountingPeriod = nPeriodYep;
                    }
                    dfnAccountingYear.EditDataItemValueSet(1, nAccountingYear.ToString(0).ToHandle());
                    dfnAccountingPeriod.EditDataItemValueSet(1, nAccountingPeriod.ToString(0).ToHandle());
                    frmVoucherPosting.FromHandle(hWndFirstTab).SetAccountingPeriod(dfnAccountingPeriod.Number);
                }
                return true;
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
            SalString lsStmt = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                IDictionary<string, string> namedBindVariables = new Dictionary<string, string>();
                namedBindVariables.Add("lsAutomatic", this.QualifiedVarBindName("lsAutomatic"));
                namedBindVariables.Add("sSimulationVoucher", this.QualifiedVarBindName("sSimulationVoucher"));
                namedBindVariables.Add("dfsCompany", dfsCompany.QualifiedBindName);
                namedBindVariables.Add("dfsVoucherTypeDescription", dfsVoucherTypeDescription.QualifiedBindName);
                namedBindVariables.Add("ccsVoucherType", ccsVoucherType.QualifiedBindName);
                namedBindVariables.Add("dfsUserGroup", dfsUserGroup.QualifiedBindName);
                namedBindVariables.Add("dfnAccountingYear", dfnAccountingYear.QualifiedBindName);

                namedBindVariables.Add("lsAuthLevel", this.QualifiedVarBindName("lsAuthLevel"));
                namedBindVariables.Add("dfsRowGroupValidation", dfsRowGroupValidation.QualifiedBindName);
                namedBindVariables.Add("sFunctionGroup", this.QualifiedVarBindName("sFunctionGroup"));

                bCommandOk = DbPLSQLBlock(@"BEGIN 
                                                {sFunctionGroup} := &AO.Voucher_Type_API.Get_Voucher_Group( {dfsCompany} IN, {ccsVoucherType} IN);
                                                &AO.Voucher_API.Validate_Voucher_Type__( {lsAutomatic} INOUT, {sSimulationVoucher} INOUT, {dfsVoucherTypeDescription} INOUT,
                                                                                         {dfsCompany} IN, {ccsVoucherType} IN, {dfsUserGroup} IN, {dfnAccountingYear} IN ); 
                                                {lsAuthLevel} := &AO.Authorize_Level_API.Encode( &AO.Voucher_Type_User_Group_API.Get_Authorize_Level( {dfsCompany} IN, {dfnAccountingYear} IN, {dfsUserGroup} IN, {ccsVoucherType} IN ));
                                                {dfsRowGroupValidation} := &AO.Voucher_Type_API.Is_Row_Group_Validated( {dfsCompany} IN, {ccsVoucherType} IN );
                                             END;", namedBindVariables);

                dfsVoucherGroup.Text = sFunctionGroup;

                if (!(bCommandOk))
                {
                    return Sys.VALIDATE_Cancel;
                }
                cbAutomatic.EditDataItemValueSet(0, lsAutomatic.Trim().ToHandle());
                if (cbAutomatic.Checked && !(dfdDateReg.EditDataItemStateGet() == Ifs.Fnd.ApplicationForms.Const.EDIT_Query))
                {
                    dfnVoucherNo.Number = 0;
                    dfnVoucherNo.EditDataItemSetEdited();
                }
                cmbsVoucherStatus.LookupInit();
                if (lsAuthLevel == "Approved")
                {
                    Sal.ListSetSelect(cmbsVoucherStatus, 0);
                }
                // Bug 77430, Begin, changed the voucher status to 4
                else if (lsAuthLevel == "Not Approved")
                {
                    Sal.ListSetSelect(cmbsVoucherStatus, 4);
                }
                // Bug 77430, End
                cmbsVoucherStatus.EditDataItemSetEdited();
                return Sys.VALIDATE_Ok;
            }
            #endregion
        }

        // Bug 101870, removed function ValidateVoucherStatus
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean GetAccPeriodDescription()
        {
            #region Actions
            using (new SalContext(this))
            {
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("ACCOUNTING_PERIOD_API.Get_Period_Description", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                    if (!(DbPLSQLBlock(cSessionManager.c_hSql, sFormName + "dfsPeriodDescription  := " + cSessionManager.c_sDbPrefix + "ACCOUNTING_PERIOD_API.Get_Period_Description( " + sFormName + "dfsCompany," + sFormName + "dfnAccountingYear," + sFormName +
                        "dfnAccountingPeriod  )")))
                    {
                        return false;
                    }
                }
                return true;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber GetVoucherTypeInfo()
        {
            #region Actions
            using (new SalContext(this))
            {
                if (!(Sal.IsNull(ccsVoucherType)))
                {
                    sVouType = ccsVoucherType.i_sMyValue.ToUpper();
                    DbPLSQLBlock(@"BEGIN 
                                      {0} := &AO.Voucher_Type_API.Get_Voucher_Group( {1} IN, {2} IN);
                                      {3} := &AO.Voucher_Type_API.Get_Description( {1} IN, {2} IN);
                                      {4} := &AO.Voucher_Type_API.Get_Simulation_Voucher( {1} IN, {2} IN);                             
                                   END;", this.QualifiedVarBindName("sFunctionGroup"),
                                          this.dfsCompany.QualifiedBindName,
                                          this.QualifiedVarBindName("sVouType"),
                                          this.dfsVoucherTypeDescription.QualifiedBindName,
                                          this.QualifiedVarBindName("sSimulationVoucher"));
                    
                    dfsVoucherGroup.Text = sFunctionGroup;
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean CheckEnabled()
        {
            #region Actions
            using (new SalContext(this))
            {
                if (hWndFirstTab == Sys.hWndNULL)
                {
                    return false;
                }

                if (Sal.TblAnyRows(frmVoucherPosting.FromHandle(hWndFirstTab).tblVoucherPosting, 0, Sys.ROW_MarkDeleted))
                {
                    return false;
                }
                hWndSecondTab = TabAttachedWindowHandleGet(picTab.FindName("ViewVouRow"));
                if (hWndSecondTab != Sys.hWndNULL)
                {
                    if (Sal.TblAnyRows(frmVoucherRow.FromHandle(hWndSecondTab).tblVoucherRow, 0, 0))
                    {
                        return false;
                    }
                }
                // If the voucher belongs to another function group than 'K', 'M' or 'Q' the amount method should be NULL.
                // It should then neither be possible to change this.
                if ((sFunctionGroup == "K" ) || (sFunctionGroup == "M") || (sFunctionGroup == "Q"))
                {
                    return true;
                }
                else if (cmbsAmountMethod.Text == Ifs.Fnd.ApplicationForms.Const.strNULL) 
                {
                    return false;
                }
                return true;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber CheckAutomatic()
        {
            #region Actions
            using (new SalContext(this))
            {
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("Voucher_Type_API.Check_Automatic", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                    DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN\r\n" +
                        "		 :i_hWndFrame.frmEntryVoucher.sAutomaticAallot := " + cSessionManager.c_sDbPrefix + "Voucher_Type_API.Check_Automatic(\r\n" +
                        "		 :i_hWndFrame.frmEntryVoucher.dfsCompany,\r\n" +
                        "                                 :i_hWndFrame.frmEntryVoucher.ccsVoucherType.i_sMyValue);\r\n		 END;");
                }
                sNewVoucher = false;
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean CheckIfPCAManual()
        {
            #region Actions
            using (new SalContext(this))
            {
                if (dfsRevCostClearVoucher.Text == "PCAMA")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean IsPcaUpdateBlocked()
        {
            #region Actions
            using (new SalContext(this))
            {
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("Voucher_API.Is_Pca_Update_Blocked", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                    if (!(DbPLSQLBlock(cSessionManager.c_hSql, sFormName + "sBlocked := " + cSessionManager.c_sDbPrefix + "Voucher_API.Is_Pca_Update_Blocked(" + sFormName + "i_sCompany," + sFormName + "dfsVoucherGroup)")))
                    {
                        return false;
                    }
                }
                if (sBlocked == "TRUE")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            #endregion
        }
        // Bug 69891, Begin
        /// <summary>
        /// Applications override the DataRecordToFormUser function to
        /// take care of object attributes not handled by the framework.
        /// COMMENTS:
        /// Overriding the DataRecordToFormUser function is useful when
        /// an application is using instance or window variables (instead
        /// of invisible data items) to hold information. For instance,
        /// DataRecordToFormUser can be used to put default values into these
        /// varibles.
        /// </summary>
        /// <param name="lsServerAttr">
        /// Server attributes
        /// Object attributes sent from the server to the client. Although it is possible
        /// for applications to modify the attributes, doing so is not recommended.
        /// </param>
        /// <param name="bMarkAsEdited">
        /// Server attributes
        /// Object attributes sent from the server to the client. Although it is possible
        /// for applications to modify the attributes, doing so is not recommended.
        /// </param>
        /// <returns></returns>
        public new SalNumber DataRecordToFormUser(ref SalString lsServerAttr, ref SalBoolean bMarkAsEdited)
        {
            #region Local Variables
            SalString lsTempAttr = "";
            SalString lsNewAttrString = "";
            SalNumber nPos1 = 0;
            SalNumber nPos2 = 0;
            SalNumber nLength = 0;
            SalNumber n = 0;
            SalArray<SalString> sAttrs = new SalArray<SalString>();
            SalArray<SalString> sFields = new SalArray<SalString>();
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                lsTempAttr = lsServerAttr;
                nFictiveVoucherNo = Ifs.Fnd.ApplicationForms.Int.PalAttrGetNumber("VOUCHER_NO", lsTempAttr);
                if (nFictiveVoucherNo < 0)
                {
                    lsTempAttr.Tokenize(Ifs.Fnd.ApplicationForms.Const.strNULL, Ifs.Fnd.ApplicationForms.Var.g_sCHAR_RS, sAttrs);
                    n = 0;
                    lsNewAttrString = Ifs.Fnd.ApplicationForms.Const.strNULL;
                    while (sAttrs[n] != Ifs.Fnd.ApplicationForms.Const.strNULL)
                    {
                        sFields[1] = Ifs.Fnd.ApplicationForms.Const.strNULL;
                        sAttrs[n].Tokenize(Ifs.Fnd.ApplicationForms.Const.strNULL, Ifs.Fnd.ApplicationForms.Var.g_sCHAR_US, sFields);
                        if (sFields[0] == "VOUCHER_NO")
                        {
                            Ifs.Fnd.ApplicationForms.Int.PalAttrAdd(sFields[0], "0", ref lsNewAttrString);
                        }
                        else
                        {
                            Ifs.Fnd.ApplicationForms.Int.PalAttrAdd(sFields[0], sFields[1], ref lsNewAttrString);
                        }
                        n = n + 1;
                    }
                    lsServerAttr = lsNewAttrString;
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// This Function will Finalize the new voucher with Final Voucher Number
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean FinalizeVoucher()
        {
            #region Local Variables
            SalString lsStmt = Sys.STRING_Null;
            #endregion 

            #region Actions
            using (new SalContext(this))
            {
                lsStmt = "&AO.Voucher_API.Finalize_Manual_Voucher__( {3} OUT, {0} IN, {1} IN, {2} IN );";

                if (dfStatus.Text == "Confirmed")
                {
                   lsStmt = lsStmt +  " {5} := &AO.Voucher_API.Check_Negative_Amount( {0} IN, {1} IN, {4}  IN, {3}  IN);";
                }

                if (!(DbPLSQLBlock( " BEGIN  " + lsStmt + " END; " , 
                                            dfsCompany.QualifiedBindName,
                                            ccsVoucherType.QualifiedBindName,
                                            dfsTransferId.QualifiedBindName,
                                            QualifiedVarBindName("nFinalVoucherNumber"),
                                            dfnAccountingYear.QualifiedBindName,
                                            QualifiedVarBindName("sNegative"))))                        
                {
                    return false;
                }

                if (nFinalVoucherNumber > 0)
                {
                    dfnVoucherNo.EditDataItemValueSet(0, nFinalVoucherNumber.ToString(0).ToHandle());
                    sRefreshRequired = "TRUE";
                }
                return true;
            }
            #endregion
        }
        // Bug 69891, End
        // Bug 77430, Begin
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber EnableEditing()
        {
            #region Actions
            using (new SalContext(this))
            {
                // Bug 83697 Begin , SalStrTrimX methods are no need here , so there are removed.
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("Voucher_Type_User_Group_API.Get_Authorize_Level", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                    hints.Add("Authorize_Level_API.Encode", System.Data.ParameterDirection.Input);
                    DbPLSQLBlock(cSessionManager.c_hSql, ":i_hWndFrame.frmEntryVoucher.sAuthLevel := &AO.Authorize_Level_API.Encode(\r\n" +
                        "							        &AO.Voucher_Type_User_Group_API.Get_Authorize_Level( :i_hWndFrame.frmEntryVoucher.dfsCompany,\r\n" +
                        "												 	:i_hWndFrame.frmEntryVoucher.dfnAccountingYear,\r\n" +
                        "													:i_hWndFrame.frmEntryVoucher.dfsUserGroup,\r\n" +
                        "													:i_hWndFrame.frmEntryVoucher.ccsVoucherType.i_sMyValue))");
                }
                if (!(sAuthLevel == Ifs.Fnd.ApplicationForms.Const.strNULL))
                {
                    if (sAuthLevel == "ApproveOnly")
                    {
                        if (hWndFirstTab != Sys.hWndNULL)
                        {
                            Sal.DisableWindow(frmVoucherPosting.FromHandle(hWndFirstTab).tblVoucherPosting);
                        }
                        Sal.DisableWindow(dfdVoucherDate);
                        Sal.DisableWindow(dfnVoucherNo);
                        Sal.DisableWindow(dfsTextId);
                        Sal.DisableWindow(dfsRowText);
                        Sal.DisableWindow(cbUseCorrectionRows);
                        if (dfnVoucherNo.Number == 0)
                        {
                            Sal.ClearField(ccsVoucherType);
                            Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_ApproveOnlyPermission, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, 0);
                        }
                    }
                    else
                    {
                        if (hWndFirstTab != Sys.hWndNULL)
                        {
                            Sal.EnableWindow(frmVoucherPosting.FromHandle(hWndFirstTab).tblVoucherPosting);
                        }
                        Sal.EnableWindow(dfdVoucherDate);
                        Sal.EnableWindow(dfnVoucherNo);
                        Sal.EnableWindow(dfsTextId);
                        Sal.EnableWindow(dfsRowText);
                        Sal.EnableWindow(cbUseCorrectionRows);
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
                return @"&AO.Authorize_Level_API.Encode(&AO.Voucher_Type_User_Group_API.Get_Authorize_Level( :i_hWndFrame.frmEntryVoucher.dfsCompany,
                										 	:i_hWndFrame.frmEntryVoucher.dfnAccountingYear,
                											:i_hWndFrame.frmEntryVoucher.dfsUserGroup,
                											:i_hWndFrame.frmEntryVoucher.ccsVoucherType.i_sMyValue)),
                &AO.Voucher_API.Is_Cancellation_Voucher__( COMPANY,
                				           VOUCHER_TYPE,
                				           ACCOUNTING_YEAR,
                				           VOUCHER_NO), 
               &AO.Voucher_Type_API.Get_Simulation_Voucher(COMPANY, VOUCHER_TYPE),
               &AO.Add_Investment_Info_API.Exist_Add_Investment_Info( 'VOUCHER',
                                                                      COMPANY, 
                                                                      VOUCHER_NO, 
                                                                      VOUCHER_TYPE,
                                                                      ACCOUNTING_YEAR, 
                                                                      NULL ,
                                                                      '*'),
              &AO.USER_GROUP_MEMBER_FINANCE_API.Get_User_Group_Of_User_( COMPANY,
                                                                         USER_GROUP,
                                                                         :i_hWndFrame.frmEntryVoucher.dfsUserId)";
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
                return ":i_hWndFrame.frmEntryVoucher.sAuthLevel, :i_hWndFrame.frmEntryVoucher.sCancellation , :i_hWndFrame.frmEntryVoucher.sSimulationVoucher, :i_hWndFrame.frmEntryVoucher.sAddInvestment, :i_hWndFrame.frmEntryVoucher.sUserGroupNew";
            }
            #endregion
        }
        // Bug 77430, End
        // Bug 79831, Begin
        /// <summary>
        /// This Function will check whether a period allocation information exists for the selected GL voucher to be copied.
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean ExistPeriodAlloction()
        {
            #region Actions
            using (new SalContext(this))
            {
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("Gen_Led_Voucher_API.Exist_Period_Alloction", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                    if (!(DbPLSQLBlock(cSessionManager.c_hSql, " :i_hWndFrame.frmEntryVoucher.sExistPeriodAlloction := &AO.Gen_Led_Voucher_API.Exist_Period_Alloction(\r\n" +
                        "	:i_hWndFrame.frmEntryVoucher.i_sCompany,\r\n" +
                        "                :i_hWndFrame.frmEntryVoucher.sGlCpyVouType,\r\n" +
                        "                :i_hWndFrame.frmEntryVoucher.nYear,\r\n" +
                        "                :i_hWndFrame.frmEntryVoucher.nVouNumber )")))
                    {
                        return false;
                    }
                }
                if (sExistPeriodAlloction == "Y")
                {
                    return true;
                }
                return false;
            }
            #endregion
        }
        /// <summary>
        /// This Function will check whether any summerized lines exist in the GL voucher.
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean IsGLVoucherSummerized()
        {
            #region Actions
            using (new SalContext(this))
            {
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    //hints.Add("Gen_Led_Voucher_API.Exist_Period_Alloction", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                    if (!(DbPLSQLBlock(cSessionManager.c_hSql, " :i_hWndFrame.frmEntryVoucher.sSummerizedGLVoucher := &AO.Gen_Led_Voucher_API.Is_Voucher_Summerized(\r\n" +
                        "	:i_hWndFrame.frmEntryVoucher.i_sCompany,\r\n" +
                        "                :i_hWndFrame.frmEntryVoucher.sGlCpyVouType,\r\n" +
                        "                :i_hWndFrame.frmEntryVoucher.nYear,\r\n" +
                        "                :i_hWndFrame.frmEntryVoucher.nVouNumber )")))
                    {
                        return false;
                    }
                }
                if (sSummerizedGLVoucher == "Y")
                {
                    return true;
                }
                return false;
            }
            #endregion
        }
        // Bug 79831, End
        // Bug 92935 Begin
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean GetVoucherTypeDesc()
        {
            #region Actions
            using (new SalContext(this))
            {
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("Voucher_Type_API.Get_Description", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                    if (!(DbPLSQLBlock(cSessionManager.c_hSql, " :i_hWndFrame.frmEntryVoucher.dfsVoucherTypeDescription := &AO.Voucher_Type_API.Get_Description(\r\n" +
                        "                :i_hWndFrame.frmEntryVoucher.dfsCompany,\r\n" +
                        "                :i_hWndFrame.frmEntryVoucher.ccsVoucherType.i_sMyValue )")))
                    {
                        return false;
                    }
                }
                return true;
            }
            #endregion
        }

        public virtual SalString GetAddInvestmentStmt()
        {
            #region Actions
            using (new SalContext(this))
            {
                // Bug 107981 Begin, Added a if condition 
                if (Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Add_Investment_Info_API.Exist_Add_Investment_Info"))
                {
                    return this.sFormName + "sAddInvestment := &AO.Add_Investment_Info_API.Exist_Add_Investment_Info( 'VOUCHER'," + " " + this.sFormName + "dfsCompany IN, " + this.sFormName + "dfnVoucherNo IN, " + this.sFormName + "ccsVoucherType.i_sMyValue IN, " + this.sFormName + "dfnAccountingYear IN, NULL ,'*'); \r\n ";
                }
                else
                {
                    return SalString.Empty;
                }
                // Bug 107981 End
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
        private void frmEntryVoucher_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordDuplicate:
                    this.frmEntryVoucher_OnPM_DataRecordDuplicate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew:
                    this.frmEntryVoucher_OnPM_DataRecordNew(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove:
                    this.frmEntryVoucher_OnPM_DataRecordRemove(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate:
                    this.frmEntryVoucher_OnPM_DataSourcePopulate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave:
                    this.frmEntryVoucher_OnPM_DataSourceSave(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceQueryFieldName:
                    this.frmEntryVoucher_OnPM_DataSourceQueryFieldName(sender, e);
                    break;

                case Const.PAM_VoucherDateGet:
                    e.Handled = true;
                    e.Return = Sal.SendMsg(this.dfdVoucherDate, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueGet, 0, 0);
                    return;

                case Const.PAM_UserGroupGet:
                    e.Handled = true;
                    e.Return = Sal.SendMsg(this.dfsUserGroup, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueGet, 0, 0);
                    return;
            }
            #endregion
        }        

        /// <summary>
        /// PM_DataRecordDuplicate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmEntryVoucher_OnPM_DataRecordDuplicate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire)
            {
                e.Return = false;
                return;
            }
            this.sNewVoucher = true;
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordDuplicate, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataRecordNew event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmEntryVoucher_OnPM_DataRecordNew(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew, Sys.wParam, Sys.lParam))
            {
                if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
                {
                    this.cbCorrection.Checked = false;
                    this.sCancellation = SalString.Null;
                    if (this.sParallelCurrency == Ifs.Fnd.ApplicationForms.Const.strNULL)
                    {
                        this.bThirdCurrExists = false;
                    }
                    else
                    {
                        this.bThirdCurrExists = true;
                    }
                    frmVoucherPosting.FromHandle(this.hWndFirstTab).GetAttributes(this.dfsCompany.Text, this.dfsCurrencyCode.Text, this.sCurrencyCode, this.dfsCurrencyType.Text, this.dfdVoucherDate.DateTime);
                    //Bug 111189 Begin, clear the cached third currency code
                    if (bThirdCurrExists)
                    {
                        frmVoucherPosting.FromHandle(this.hWndFirstTab).SetFinThirdCache(this.dfsCompany.Text, Ifs.Fnd.ApplicationForms.Const.strNULL, this.sCurrencyCode, this.dfdVoucherDate.DateTime, "DUMMY", "DUMMY");
                    }
                    //Bug 111189 End
                    this.dfnCurrencyRate.Number = frmVoucherPosting.FromHandle(this.hWndFirstTab).GetRate(this.dfsCompany.Text, this.dfsCurrencyCode.Text);
                    this.dfnConversionFactor.Number = frmVoucherPosting.FromHandle(this.hWndFirstTab).i_nFinConversionFactor;                    
                    this.picTab.BringToTop(0, true);
                    this.sNewVoucher = true;
                    Sal.SetFocus(this.dfsUserGroup);
                    Sal.SetFocus(this.dfdVoucherDate);
                    this.lsAutoBal = Ifs.Fnd.ApplicationForms.Const.strNULL;
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
        /// PM_DataRecordRemove event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmEntryVoucher_OnPM_DataRecordRemove(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire)
            {
                if (dfsCompany.EditDataItemStateGet() == Ifs.Fnd.ApplicationForms.Const.EDIT_Changed)
                {
                    e.Return = true;
                    return;
                }
                // Bug 77430, Begin
                if (this.sAuthLevel == "ApproveOnly")
                {
                    e.Return = false;
                    return;
                }
                // Bug 77430, End
                this.sTempStatus = this.cmbsVoucherStatus.Text;
                if ((this.sSimulationVoucher == "TRUE") && (this.sTempStatus == Sal.ListQueryTextX(this.cmbsVoucherStatus, 1)))  // Not Approved
                {
                    e.Return = true;
                    return;
                }
                else
                {
                    e.Return = false;
                    return;
                }
                // Bug 77430, Begin
                e.Return = true;
                return;
                // Bug 77430, End
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataSourcePopulate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmEntryVoucher_OnPM_DataSourcePopulate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                this.nReturn = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Sys.wParam, Sys.lParam);
                if (hWndFirstTab != Sys.hWndNULL)
                {
                    frmVoucherPosting.FromHandle(this.hWndFirstTab).dfnCurrencyBalance.Number = this.dfnCurrencyBalance.Number;
                    frmVoucherPosting.FromHandle(this.hWndFirstTab).dfnBalance.Number = this.dfnBalance.Number;

                    frmVoucherPosting.FromHandle(this.hWndFirstTab).dfnParallelCurrBalance.Number = this.dfnParallelCurrencyBalance.Number;
                    frmVoucherPosting.FromHandle(this.hWndFirstTab).dfsCodePartValue.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                    frmVoucherPosting.FromHandle(this.hWndFirstTab).dfsCodePartDescription.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                }
                this.sOldStatus = this.cmbsVoucherStatus.Text;
                this.sNewVoucher = false;
                this.sUser = Ifs.Fnd.ApplicationForms.Int.FndUser();
                if (!bIsUpdateGLRefreshed)
                {
                   dfsUserGroup.Text = this.sUserGroupNew;
                }
               
               
                if ((this.dfsUserId.Text == this.dfsApprovedByUserid.Text) && !(Sal.IsNull(this.dfsApprovedByUserid)))
                {
                    if (this.sUser == this.dfsApprovedByUserid.Text)
                    {
                        this.dfsUserGroup.Text = this.dfsApprovedByUserGroup.Text;
                    }
                }
                if (this.dfsRowText.Text == Ifs.Fnd.ApplicationForms.Const.strNULL)
                {
                    Sal.ClearField(this.dfsTextId);
                }
                this.picTab.BringToTop(1, true);
                this.hWndSecondTab = this.TabAttachedWindowHandleGet(this.picTab.FindName("ViewVouRow"));
                if (hWndSecondTab != Sys.hWndNULL)
                {
                    frmVoucherRow.FromHandle(this.hWndSecondTab).dfnCurrencyBalance.Number = this.dfnCurrencyBalance.Number;
                    frmVoucherRow.FromHandle(this.hWndSecondTab).dfnBalance.Number = this.dfnBalance.Number;

                    frmVoucherRow.FromHandle(this.hWndSecondTab).dfnParallelCurrBalance.Number = this.dfnParallelCurrencyBalance.Number;
                    frmVoucherRow.FromHandle(this.hWndSecondTab).dfsCodePartValue.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                    frmVoucherRow.FromHandle(this.hWndSecondTab).dfsCodePartDescription.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                    this.dfsReferenceCompany.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                    if (!(Sal.IsNull(this.dfnVoucherNoReference)))
                    {
                        this.dfsReferenceCompany.Text = this.dfsCompany.Text;
                    }
                }
                // Bug 72229, Begin
                if ((this.nVoucherNo != this.dfnVoucherNo.Number) || (this.ccsVoucherType.i_sMyValue != this.sVType) || (this.sRowText != this.dfsRowText.Text) || (this.nAcYear != this.dfnAccountingYear.Number))
                {
                    if (!(this.nVoucherNo == 0))
                    {
                        Sal.ClearField(this.dfsTextId);
                    }
                }
                // Bug 72229, End
                // Bug 77430, Begin
                this.EnableEditing();
                // Bug 77430, End
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
        private void frmEntryVoucher_OnPM_DataSourceSave(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                // Bug 69891, Begin
                this.sRefreshRequired = "FALSE";
                // Bug 69891, End
                Sal.SetFocus(this.dfdVoucherDate);
                if (!(this.bIsValidateVouDate))
                {
                    if (!(this.ValidateVoucherDate()))
                    {
                        e.Return = false;
                        return;
                    }
                }
                this.sTempStatus = this.cmbsVoucherStatus.Text;
                this.dfsUserGroup.EditDataItemSetEdited();
                // Bug 77430, Begin
                if (this.sAuthLevel != "ApproveOnly")
                {
                    this.dfsEnteredByUserGroup.Text = this.dfsUserGroup.Text;
                }
                // Bug 77430, End
                this.dfsEnteredByUserGroup.EditDataItemSetEdited();
                this.dfsVoucherGroup.EditDataItemSetEdited();
                this.CheckAutomatic();
                this.sNewVoucher = false;

                if (this.cmbsAmountMethod.Text != Sys.STRING_Null)
                {
                    this.cmbsAmountMethod.EditDataItemSetEdited();
                }
                if ((dfsVoucherGroup.Text == "K") || (dfsVoucherGroup.Text == "M") || (dfsVoucherGroup.Text == "Q"))
                {
                    cmbsAmountMethod.EditDataItemFlagSet(Ifs.Fnd.ApplicationForms.Const.FIELD_Required, true);
                }
                else
                {
                    cmbsAmountMethod.EditDataItemFlagSet(Ifs.Fnd.ApplicationForms.Const.FIELD_Required, false);
                }
                if (this.sTempStatus == Sal.ListQueryTextX(this.cmbsVoucherStatus, 3))  // Cancelled
                {
                    this.sStatus[0] = this.sTempStatus;
                    Ifs.Fnd.ApplicationForms.Int.AlertBoxWithParams(Properties.Resources.VOUCHER_ErrorState, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.WARNING_Ok, this.sStatus);
                    e.Return = false;
                    return;
                }
                else if ((this.sSimulationVoucher == "TRUE") && (this.cbInterimVoucher.Checked == false) && (this.sTempStatus == Sal.ListQueryTextX(this.cmbsVoucherStatus, 0)))  // Approved
                {
                    if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Sys.wParam, Sys.lParam))
                    {
                        this.UM_InterimVoucher(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
                        // Bug 69891, Begin
                        if (this.sRefreshRequired == "TRUE")
                        {
                            this.sRefreshRequired = "FALSE";
                            // Bug 74066, Begin
                            this.nTempBalance = frmVoucherPosting.FromHandle(this.hWndFirstTab).dfnBalance.Number;
                            this.nTempCurrBalance = frmVoucherPosting.FromHandle(this.hWndFirstTab).dfnCurrencyBalance.Number;
                            // Bug 74066, End

                            this.nTempParrCurrBalance = frmVoucherPosting.FromHandle(this.hWndFirstTab).dfnParallelCurrBalance.Number;
                            Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceRefresh, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                            // Bug 108222, Begin, modified 0 into nDecimalsInAmount to get rounded amount.
                            // Bug 74066, Begin
                            frmVoucherPosting.FromHandle(this.hWndFirstTab).dfnBalance.EditDataItemValueSet(0, this.nTempBalance.ToString(this.nDecimalsInAmount).ToHandle());
                            frmVoucherPosting.FromHandle(this.hWndFirstTab).dfnCurrencyBalance.EditDataItemValueSet(0, this.nTempCurrBalance.ToString(this.nDecimalsInAmount).ToHandle());
                            // Bug 74066, End

                            frmVoucherPosting.FromHandle(this.hWndFirstTab).dfnParallelCurrBalance.Number = this.nTempParrCurrBalance;
                            // Bug 108222, End
                        }
                        // Bug 69891, End
                        e.Return = true;
                        return;
                    }
                    else
                    {
                        e.Return = false;
                        return;
                    }
                }
                else if (this.sTempStatus == Sal.ListQueryTextX(this.cmbsVoucherStatus, 0))  // Confirmed
                {
                    using (SignatureHints hints = SignatureHints.NewContext())
                    {
                        hints.Add("Voucher_Type_User_Group_API.Get_Authorize_Level", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                        hints.Add("Authorize_Level_API.Encode", System.Data.ParameterDirection.Input);
                        this.DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN\r\n" +
                            "			      :i_hWndFrame.frmEntryVoucher.sNewState := " + cSessionManager.c_sDbPrefix + "Authorize_Level_API.Encode(" + cSessionManager.c_sDbPrefix + "Voucher_Type_User_Group_API.Get_Authorize_Level(\r\n" +
                            "									       	:i_hWndFrame.frmEntryVoucher.dfsCompany,\r\n" +
                            "									       	:i_hWndFrame.frmEntryVoucher.dfnAccountingYear,\r\n" +
                            "		               							       	:i_hWndFrame.frmEntryVoucher.dfsUserGroup,\r\n" +
                            "								                       	:i_hWndFrame.frmEntryVoucher.ccsVoucherType.i_sMyValue));\r\n			END;");
                    }
                    if (this.sNewState == "Not Approved")
                    {
                        this.sStatus[0] = this.sNewState;
                        Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.VOUCHER_ErrorStateUserGroup, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.WARNING_Ok);
                        e.Return = false;
                        return;
                    }
                }
                // Bug 89644, Begin
                // Bug 77430, Begin
                else if (this.sTempStatus == Sal.ListQueryTextX(this.cmbsVoucherStatus, 1) && (this.sOldStatus == Sal.ListQueryTextX(this.cmbsVoucherStatus, 0) || this.sOldStatus == Sal.ListQueryTextX(this.cmbsVoucherStatus, 4)))
                {
                    if (frmVoucherRow.FromHandle(this.hWndSecondTab).tblVoucherRow_colsTransCode.Text != "INTERIM")
                    {
                        if (UM_FreeText(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire))
                        {
                            UM_FreeText(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
                        }
                    }
                }
                // Bug 77430, End
                // Bug 89644, End
                this.sManualFound = "FALSE";
                this.sWarningRaised = "FALSE";
                this.nContextRow = Sal.TblQueryContext(frmVoucherPosting.FromHandle(this.hWndFirstTab).tblVoucherPosting);
                this.nCurrentRow = Sys.TBL_MinRow;
                // Bug 76119, Begin
                this.bPostingRowsFound = false;
                // Bug 76119, End
                DbPLSQLBlock("{0} := &AO.Voucher_Type_Detail_API.Get_Automatic_Vou_Balance({1} IN, {2} IN, {3} IN);", 
                                     QualifiedVarBindName("sIsAutoBalanceVouType"),
                                     dfsCompany.QualifiedBindName,
                                     ccsVoucherType.QualifiedBindName,
                                     dfsVoucherGroup.QualifiedBindName);
                while (Sal.TblFindNextRow(frmVoucherPosting.FromHandle(this.hWndFirstTab).tblVoucherPosting, ref this.nCurrentRow, 0, 0))
                {
                    Sal.TblSetContext(frmVoucherPosting.FromHandle(this.hWndFirstTab).tblVoucherPosting, this.nCurrentRow);

                    sCurrCode = frmVoucherPosting.FromHandle(this.hWndFirstTab).tblVoucherPosting_colsCurrencyCode.Text;
                    sParallelRateType = frmVoucherPosting.FromHandle(this.hWndFirstTab).tblVoucherPosting_colnParallelCurrRateType.Text;

                    if ((!(Sal.IsNull(frmVoucherPosting.FromHandle(this.hWndFirstTab).tblVoucherPosting_colsOptionalCode))) && ((dfsVoucherGroup.Text == "K") || (dfsVoucherGroup.Text == "M") || (dfsVoucherGroup.Text == "Q")))
                    {
                        if (!Sal.SendMsg(frmVoucherPosting.FromHandle(this.hWndFirstTab).tblVoucherPosting_colsOptionalCode, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam))
                        {
                            e.Return = false;
                            return;
                        }
                    }
                    

                    if (frmVoucherPosting.FromHandle(this.hWndFirstTab).i_sFinParallelBaseType == Ifs.Fnd.ApplicationForms.Const.strNULL)
                    {
                        // Bug 108987, Begin - Added check to validate the rows before saving
                        if (Sal.IsNull(frmVoucherPosting.FromHandle(this.hWndFirstTab).tblVoucherPosting_colnAmount) || (frmVoucherPosting.FromHandle(this.hWndFirstTab).tblVoucherPosting_colnAmount.Number == 0))
                        {
                            if (Sal.IsNull(frmVoucherPosting.FromHandle(this.hWndFirstTab).tblVoucherPosting_colnQuantity) || (frmVoucherPosting.FromHandle(this.hWndFirstTab).tblVoucherPosting_colnQuantity.Number == 0))
                            {
                                if (frmVoucherPosting.FromHandle(this.hWndFirstTab).i_sFinParallelBaseType == Ifs.Fnd.ApplicationForms.Const.strNULL)
                                {
                                    if ((Sal.IsNull(frmVoucherPosting.FromHandle(this.hWndFirstTab).tblVoucherPosting_colnQuantity) || (frmVoucherPosting.FromHandle(this.hWndFirstTab).tblVoucherPosting_colnQuantity.Number == 0)) && (sIsAutoBalanceVouType == "N"))
                                    {
                                        Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_VoEn_AlertQuantity, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
                                        e.Return = false;
                                        return;
                                    }
                                }
                            }
                        }
                        if (Sal.IsNull(frmVoucherPosting.FromHandle(this.hWndFirstTab).tblVoucherPosting_colnQuantity) || (frmVoucherPosting.FromHandle(this.hWndFirstTab).tblVoucherPosting_colnQuantity.Number == 0))
                        {
                            if (Sal.IsNull(frmVoucherPosting.FromHandle(this.hWndFirstTab).tblVoucherPosting_colnCurrencyAmount) && (sIsAutoBalanceVouType == "N"))
                            {
                                Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_VoEn_CurrAmountEmpty, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
                                e.Return = false;
                                return;
                            }
                        }
                        if (!(Sal.IsNull(frmVoucherPosting.FromHandle(this.hWndFirstTab).tblVoucherPosting_colnQuantity)))
                        {
                            if (!(Sal.IsNull(frmVoucherPosting.FromHandle(this.hWndFirstTab).tblVoucherPosting_colnAmount)) && (frmVoucherPosting.FromHandle(this.hWndFirstTab).tblVoucherPosting_colnAmount.Number != 0))
                            {
                                if (Sal.IsNull(frmVoucherPosting.FromHandle(this.hWndFirstTab).tblVoucherPosting_colnCurrencyAmount) && (sIsAutoBalanceVouType == "N"))
                                {
                                    Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_VoEn_CurrAmountEmpty, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
                                    e.Return = false;
                                    return;
                                }
                            }
                        }
                        // Bug 108987, End
                    }
                    

                    // Bug 76119, Begin
                    this.bPostingRowsFound = true;
                    // Bug 76119, End
                    Sal.SetFieldEdit(frmVoucherPosting.FromHandle(this.hWndFirstTab).tblVoucherPosting_colnAmount, false);
                    Sal.SetFieldEdit(frmVoucherPosting.FromHandle(this.hWndFirstTab).tblVoucherPosting_colnCurrencyAmount, false);
                    Sal.SetFieldEdit(frmVoucherPosting.FromHandle(this.hWndFirstTab).tblVoucherPosting_colsTextId, false);
                    if (frmVoucherPosting.FromHandle(this.hWndFirstTab).tblVoucherPosting_colIsStatAccount.Text == "TRUE")
                    {
                        Sal.TblSetRowFlags(frmVoucherPosting.FromHandle(this.hWndFirstTab).tblVoucherPosting, Sal.TblQueryContext(frmVoucherPosting.FromHandle(this.hWndFirstTab).tblVoucherPosting), Sys.ROW_UnusedFlag1, false);
                        Sal.SetFieldEdit(frmVoucherPosting.FromHandle(this.hWndFirstTab).tblVoucherPosting_colsTextId, false);
                    }
                    if (frmVoucherPosting.FromHandle(this.hWndFirstTab).tblVoucherPosting_colAddInternal.Text == "TRUE")
                    {
                        // The warning should be raised only once even if several rows requires manual postings
                        if (this.sWarningRaised == "FALSE")
                        {
                            Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_NoManualPost, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Warning, Ifs.Fnd.ApplicationForms.Const.WARNING_Ok);
                            this.sWarningRaised = "TRUE";
                            Sal.TblSetContext(frmVoucherPosting.FromHandle(this.hWndFirstTab).tblVoucherPosting, this.nCurrentRow);
                        }
                        frmVoucherPosting.FromHandle(this.hWndFirstTab).ManualPostings();
                        // The voucher shall not be saved if any manual postings must be added
                        this.sManualFound = "TRUE";
                        if (this.bIntManPostingsEntered)
                        {
                            frmVoucherPosting.FromHandle(this.hWndFirstTab).tblVoucherPosting_colsManualAdded.Text = "TRUE";
                        }
                    }
                }
                this.hWndSecondTab = this.TabAttachedWindowHandleGet(this.picTab.FindName("ViewVouRow"));
                if (hWndSecondTab != Sys.hWndNULL)
                {
                    // Bug 76119 Begin - Added the IF condition (If no lines in tblVoucherPosting means Automatic voucher, since its not possible to edit internal manual postings for automatic vouchers no need for the error message and the dialog pop up.
                    if (this.bPostingRowsFound)
                    {
                        while (Sal.TblFindNextRow(frmVoucherRow.FromHandle(this.hWndSecondTab).tblVoucherRow, ref this.nCurrentRow, 0, 0))
                        {
                            Sal.TblSetContext(frmVoucherRow.FromHandle(this.hWndSecondTab).tblVoucherRow, this.nCurrentRow);
                            if (frmVoucherRow.FromHandle(this.hWndSecondTab).tblVoucherRow_colAddInternal.Text == "TRUE")
                            {
                                // The warning should be raised only once even if several rows requires manual postings
                                if (this.sWarningRaised == "FALSE")
                                {
                                    Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_NoManualPost, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Warning, Ifs.Fnd.ApplicationForms.Const.WARNING_Ok);
                                    this.sWarningRaised = "TRUE";
                                }
                                frmVoucherRow.FromHandle(this.hWndSecondTab).ManualPostings();

                                // The voucher shall not be saved if any manual postings must be added
                                this.sManualFound = "TRUE";
                                this.bManualFoundInSecond = true;

                                // This row has a manual posting connected
                                frmVoucherRow.FromHandle(this.hWndSecondTab).tblVoucherRow_colsManualAdded.Text = "TRUE";
                            }
                        }
                    }
                    // Bug 76119 End
                    frmVoucherRow.FromHandle(this.hWndSecondTab).dfnCurrencyBalance.Number = frmVoucherPosting.FromHandle(this.hWndFirstTab).dfnCurrencyBalance.Number;
                    frmVoucherRow.FromHandle(this.hWndSecondTab).dfnBalance.Number = frmVoucherPosting.FromHandle(this.hWndFirstTab).dfnBalance.Number;

                    frmVoucherRow.FromHandle(this.hWndSecondTab).dfnParallelCurrBalance.Number = frmVoucherPosting.FromHandle(this.hWndFirstTab).dfnParallelCurrBalance.Number;
                }
                Sal.TblSetContext(frmVoucherPosting.FromHandle(this.hWndFirstTab).tblVoucherPosting, this.nContextRow);
                // Bug 80633, Begin - Added the bVoucherPostingModified to get datasource state and added the OR condition to the IF condition.
                this.bVoucherPostingModified = frmVoucherPosting.FromHandle(this.hWndFirstTab).DataSourceIsDirty(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
                if (this.sManualFound == "FALSE" || (!(this.bVoucherPostingModified)))
                {                    
                    if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Sys.wParam, Sys.lParam))
                    {
                        if (dfStatus.Text == "Confirmed" )
                        {                           
                            if (sNegative == "TRUE")
                            {
                                sNegative = "FALSE";
                                Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_NegativeNetBookValue, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);                                
                            }
                        }                       
                        if (this.picTab.GetTop() == 1)
                        {
                            this.picTab.BringToTop(1, true);
                            this.hWndSecondTab = this.TabAttachedWindowHandleGet(this.picTab.FindName("ViewVouRow"));
                            Sal.SendMsg(this.hWndSecondTab, Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                            Sal.SetFocus(this.dfdVoucherDate);
                        }
                        else
                        {
                            // Bug 69891, Begin
                            if (this.sRefreshRequired == "TRUE")
                            {
                                this.sRefreshRequired = "FALSE";
                                // Bug 74066, Begin
                                this.nTempBalance = frmVoucherPosting.FromHandle(this.hWndFirstTab).dfnBalance.Number;
                                this.nTempCurrBalance = frmVoucherPosting.FromHandle(this.hWndFirstTab).dfnCurrencyBalance.Number;

                                this.nTempParrCurrBalance = frmVoucherPosting.FromHandle(this.hWndFirstTab).dfnParallelCurrBalance.Number;
                                // Bug 74066, End
                                // Bug 81003, Begin. Replaced hWndForm with hWndFirstTab.
                                // Bug 108351, Begin. Replaced hWndFirstTab with i_hWndFrame
                                Sal.SendMsg(this.i_hWndFrame, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceRefresh, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                                // Bug 108351, End
                                // Bug 81003, End.
                                // Bug 87697, Begin.
                                Sal.SendMsg(this.hWndSecondTab, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceRefresh, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                                // Bug 87697, End.
                                // Bug 108222, Begin, modified 0 into nDecimalsInAmount to get rounded amount.
                                // Bug 74066, Begin
                                frmVoucherPosting.FromHandle(this.hWndFirstTab).dfnBalance.EditDataItemValueSet(0, this.nTempBalance.ToString(this.nDecimalsInAmount).ToHandle());
                                frmVoucherPosting.FromHandle(this.hWndFirstTab).dfnCurrencyBalance.EditDataItemValueSet(0, this.nTempCurrBalance.ToString(this.nDecimalsInAmount).ToHandle());


                                frmVoucherPosting.FromHandle(this.hWndFirstTab).dfnParallelCurrBalance.EditDataItemValueSet(0, this.nTempParrCurrBalance.ToString(0).ToHandle()); 
                                // Bug 74066, End
                                // Bug 108222, End
                                this.hWndSecondTab = this.TabAttachedWindowHandleGet(this.picTab.FindName("ViewVouRow"));
                                this.picTab.BringToTop(0, true);
                                Sal.SetFocus(this.dfdVoucherDate);
                                e.Return = false;
                                return;
                            }
                            // Bug 69891, End
                            this.hWndSecondTab = this.TabAttachedWindowHandleGet(this.picTab.FindName("ViewVouRow"));
                            if (hWndSecondTab != Sys.hWndNULL)
                            {
                                Sal.SendMsg(this.hWndSecondTab, Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                            }
                            this.picTab.BringToTop(0, true);
                            Sal.SetFocus(this.dfdVoucherDate);
                            e.Return = false;
                            return;
                        }
                    }
                    else
                    {
                        e.Return = false;
                        return;
                    }
                    // Bug 69891, Begin
                    if (this.sRefreshRequired == "TRUE")
                    {
                        this.sRefreshRequired = "FALSE";
                        // Bug 74066, Begin
                        this.nTempBalance = frmVoucherPosting.FromHandle(this.hWndFirstTab).dfnBalance.Number;
                        this.nTempCurrBalance = frmVoucherPosting.FromHandle(this.hWndFirstTab).dfnCurrencyBalance.Number;
                        // Bug 74066, End

                        this.nTempParrCurrBalance = frmVoucherPosting.FromHandle(this.hWndFirstTab).dfnParallelCurrBalance.Number;
                        Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceRefresh, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                        // Bug 108222, Begin, modified 0 into nDecimalsInAmount to get rounded amount.
                        // Bug 74066, Begin
                        frmVoucherPosting.FromHandle(this.hWndFirstTab).dfnBalance.EditDataItemValueSet(0, this.nTempBalance.ToString(this.nDecimalsInAmount).ToHandle());
                        frmVoucherPosting.FromHandle(this.hWndFirstTab).dfnCurrencyBalance.EditDataItemValueSet(0, this.nTempCurrBalance.ToString(this.nDecimalsInAmount).ToHandle());
                        // Bug 74066, End


                        frmVoucherPosting.FromHandle(this.hWndFirstTab).dfnParallelCurrBalance.EditDataItemValueSet(0, this.nTempParrCurrBalance.ToString(0).ToHandle());
                        // Bug 108222, End
                    }
                    // Bug 69891, End
                    e.Return = true;
                    return;
                }
                else
                {
                    if (this.picTab.GetTop() != 0)
                    {
                        this.picTab.BringToTop(1, true);
                        e.Return = false;
                        return;
                    }
                    else
                    {
                        this.hWndSecondTab = this.TabAttachedWindowHandleGet(this.picTab.FindName("ViewVouRow"));
                        if (hWndSecondTab != Sys.hWndNULL)
                        {
                            Sal.SendMsg(this.hWndSecondTab, Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                        }
                        this.picTab.BringToTop(0, true);
                        // Bug 69891, Begin
                        if (this.sRefreshRequired == "TRUE")
                        {
                            this.sRefreshRequired = "FALSE";
                            // Bug 74066, Begin
                            this.nTempBalance = frmVoucherPosting.FromHandle(this.hWndFirstTab).dfnBalance.Number;
                            this.nTempCurrBalance = frmVoucherPosting.FromHandle(this.hWndFirstTab).dfnCurrencyBalance.Number;

                            this.nTempParrCurrBalance = frmVoucherPosting.FromHandle(this.hWndFirstTab).dfnParallelCurrBalance.Number;
                            // Bug 74066, End
                            Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceRefresh, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                            // Bug 108222, Begin, modified 0 into nDecimalsInAmount to get rounded amount.
                            // Bug 74066, Begin
                            frmVoucherPosting.FromHandle(this.hWndFirstTab).dfnBalance.EditDataItemValueSet(0, this.nTempBalance.ToString(this.nDecimalsInAmount).ToHandle());
                            frmVoucherPosting.FromHandle(this.hWndFirstTab).dfnCurrencyBalance.EditDataItemValueSet(0, this.nTempCurrBalance.ToString(this.nDecimalsInAmount).ToHandle());

                            frmVoucherPosting.FromHandle(this.hWndFirstTab).dfnParallelCurrBalance.EditDataItemValueSet(0, this.nTempParrCurrBalance.ToString(0).ToHandle());
                            // Bug 74066, End
                            // Bug 108222, End
                        }
                        // Bug 69891, End
                        e.Return = true;
                        return;
                    }
                }
                // Bug 80633, End
            }
            // Bug 72229, Begin
            this.nVoucherNo = this.dfnVoucherNo.Number;
            this.sVType = this.ccsVoucherType.i_sMyValue;
            this.sRowText = this.dfsRowText.Text;
            this.nAcYear = this.dfnAccountingYear.Number;
            // Bug 72229, End
            // Bug 89391, Removed the code added by 69891 and 74066
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }


        protected virtual void AddInvestmentDialog()
        {
            #region Local Variables
            SalString sRS = "";
            SalString sKeyAttr = "";
            SalArray<SalString> sVoucherAddInv = new SalArray<SalString>();
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("SOURCE_REF", "VOUCHER", ref sKeyAttr);
                Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("COMPANY", dfsCompany.Text, ref sKeyAttr);
                Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("KEYREF1", dfnVoucherNo.Text, ref sKeyAttr);
                Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("KEYREF2", ccsVoucherType.Text, ref sKeyAttr);
                Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("KEYREF3", dfnAccountingYear.Text, ref sKeyAttr);
                Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("VOUCHER_DATE", dfdVoucherDate.Text, ref sKeyAttr);
                Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("USER_GROUP", dfsUserGroup.Text, ref sKeyAttr);
                Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("VOUCHER_TYPE", dfsVoucherGroup.Text, ref sKeyAttr);                                
                sVoucherAddInv[0] = sKeyAttr;
                Ifs.Fnd.ApplicationForms.Var.DataTransfer.SourceNameSet("SOURCE_REF");
                Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemAdd("SOURCE_REF", sVoucherAddInv);
                SessionModalDialog(Pal.GetActiveInstanceName("dlgAddInvestmentInfo"), Ifs.Fnd.ApplicationForms.Int.Explorer.ExplorerForm);
                sAddInvestment = "TRUE";
            }
            #endregion
        }

        public virtual Boolean AddInvestment(SalNumber p_nWhat)
        {
            #region Actions
            using (new SalContext(this))
            {
                if (p_nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire)
                {
                    if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("dlgAddInvestmentInfo")) || Ifs.Fnd.ApplicationForms.Var.Component.IsWindowAvailable(Pal.GetActiveInstanceName("dlgAddInvestmentInfo"))))
                    {                        
                        return false;
                    }                    
                    else if (sAddInvestment == "FALSE")
                    {
                        return false;
                    }
                    return !(DataSourceIsDirty(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire));
                }
                else if (p_nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
                {
                    AddInvestmentDialog();
                }
                return true;
            }
            #endregion

        }

        /// <summary>
        /// PM_DataSourceQueryFieldName event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmEntryVoucher_OnPM_DataSourceQueryFieldName(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (SalString.FromHandle(Sys.lParam) == "FNDUSER")
            {
                switch (Sys.wParam)
                {
                    case Vis.DT_Handle:
                        e.Return = SalWindowHandle.Null.ToNumber();
                        return;

                    default:
                        this.sFndUser = Ifs.Fnd.ApplicationForms.Int.FndUser();
                        e.Return = (this.i_hWndFrame.ToNumber().ToString(0) + ".frmEntryVoucher.sFndUser").ToHandle();
                        return;
                }
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceQueryFieldName, Sys.wParam, Sys.lParam);
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

                case Sys.SAM_SetFocus:
                    this.dfdVoucherDate_OnSAM_SetFocus(sender, e);
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
                this.bIsValidateVouDate = true;
                if (!(this.ValidateVoucherDate()))
                {
                    e.Return = Sys.VALIDATE_Cancel;
                    return;
                }
            }
            if (this.dfdVoucherDate.EditDataItemStateGet() == Ifs.Fnd.ApplicationForms.Const.EDIT_Changed)
            {
                frmVoucherPosting.FromHandle(this.hWndFirstTab).CheckIntManMethods(); // Bug # 21517  Re correction
            }
            e.Return = Sys.VALIDATE_Ok;
            return;
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfdVoucherDate_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.bIsValidateVouDate = false;
            this.dPrevVoucherDate = this.dfdVoucherDate.DateTime;
            Sal.PostMsg(this.dfdVoucherDate.i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.EM_SETSEL, 0, -1);
            e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
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

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.dfsUserGroup_OnPM_DataItemQueryEnabled(sender, e);
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
            if (this.dfsUserId.EditDataItemStateGet() == Ifs.Fnd.ApplicationForms.Const.EDIT_Query && this.ccsVoucherType.EditDataItemStateGet() == Ifs.Fnd.ApplicationForms.Const.EDIT_Changed)
            {
                e.Return = this.ValidateVoucherType();
                return;
            }
            else
            {
                if (this.ValidateUserGroup())
                {
                    e.Return = this.ValidateVoucherDate();
                    return;
                    e.Return = Sys.VALIDATE_Ok;
                    return;
                }
                e.Return = Sys.VALIDATE_Cancel;
                return;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsUserGroup_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (hWndSecondTab != Sys.hWndNULL)
            {
                if (Sal.TblAnyRows(frmVoucherRow.FromHandle(this.hWndSecondTab).tblVoucherRow, 0, 0) && !(Sal.TblAnyRows(frmVoucherPosting.FromHandle(this.hWndFirstTab).tblVoucherPosting, 0, 0)))
                {
                    e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                    return;
                }
            }
            e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldEnabled;
            return;
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
            if (!(Sal.IsNull(this.ccsVoucherType)) && this.ccsVoucherType.EditDataItemStateGet() == Ifs.Fnd.ApplicationForms.Const.EDIT_Changed)
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
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.dfnVoucherNo_OnPM_DataItemValidate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.dfnVoucherNo_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
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
            if (!(Sal.IsNull(this.dfnVoucherNo)))
            {
                if (!(this.cbAutomatic.Checked))
                {
                    using (SignatureHints hints = SignatureHints.NewContext())
                    {
                        hints.Add("Voucher_No_Serial_API.Check_Voucher_No", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                        if (!(this.dfnVoucherNo.DbPLSQLBlock(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "Voucher_No_Serial_API.Check_Voucher_No(\r\n" +
                            "	:i_hWndFrame.frmEntryVoucher.dfsCompany,\r\n" +
                            "	:i_hWndFrame.frmEntryVoucher.dfdVoucherDate,\r\n" +
                            "	:i_hWndFrame.frmEntryVoucher.ccsVoucherType.i_sMyValue,\r\n" +
                            "	:i_hWndFrame.frmEntryVoucher.dfnVoucherNo,\r\n" +
                            "   :i_hWndFrame.frmEntryVoucher.dfnAccountingYear,\r\n" +
							"   :i_hWndFrame.frmEntryVoucher.dfnAccountingPeriod )")))
                        {
                            e.Return = Sys.VALIDATE_Cancel;
                            return;
                        }
                    }
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
        private void dfnVoucherNo_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.cbAutomatic.Checked == true)
            {
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                return;
            }
            else
            {
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldEnabled;
                return;
            }
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void cmbsVoucherStatus_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.cmbsVoucherStatus_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cmbsVoucherStatus_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.bErrState = 0;
            if (this.cmbsVoucherStatus.Text == Sal.ListQueryTextX(this.cmbsVoucherStatus, 2))
            {
                this.bErrState = 1;
            }
            // Bug 101870, removed code ValidateVoucherStatus()
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
        private void cmbsAmountMethod_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.cmbsAmountMethod_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cmbsAmountMethod_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (!(this.CheckEnabled()))
            {
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                return;
            }
            else
            {
                e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled, Sys.wParam, Sys.lParam);
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
                // Bug 77430, Begin

                case Ifs.Fnd.ApplicationForms.Const.WM_LBUTTONDBLCLK:
                    this.cbFreeText_OnWM_LBUTTONDBLCLK(sender, e);
                    break;

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
        private void cbUseCorrectionRows_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_Click:
                    this.cbUseCorrectionRows_OnSAM_Click(sender, e);
                    break;

                // Bug 70189, Begin

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.cbUseCorrectionRows_OnPM_DataItemQueryEnabled(sender, e);
                    break;

                // Bug 70189, End
            }
            #endregion
        }

        /// <summary>
        /// SAM_Click event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cbUseCorrectionRows_OnSAM_Click(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            // Don't change value if column is not enabled
            if (Sal.SendMsg(this.cbUseCorrectionRows.i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled, 0, 0) == Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled)
            {
                this.cbUseCorrectionRows.Checked = !(this.cbUseCorrectionRows.Checked);
                Sal.SetFieldEdit(this.cbUseCorrectionRows, false);
                e.Return = false;
                return;
            }
            if (this.cbUseCorrectionRows.Checked)
            {
                this.cbUseCorrectionRows.__sValue = this.cbUseCorrectionRows.i_sCheckedValue;
            }
            else
            {
                this.cbUseCorrectionRows.__sValue = this.cbUseCorrectionRows.i_sUncheckedValue;
            }
            this.cbUseCorrectionRows.EditDataItemSetEdited();
            this.cbCorrection.Checked = this.cbUseCorrectionRows.Checked;
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cbUseCorrectionRows_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            // Bug 89413, Begin, Modified the ELSE IF condition to check for PCA voucher group (dfsVoucherGroup = 'Z').
            if (this.sNewVoucher)
            {
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldEnabled;
                return;
            }
            else if ((this.dfsVoucherGroup.Text == "M" || this.dfsVoucherGroup.Text == "K" || this.dfsVoucherGroup.Text == "Q" || this.dfsVoucherGroup.Text == "Z") && (this.cmbsVoucherStatus.Text == Sal.ListQueryTextX(this.cmbsVoucherStatus, 1)))
            {
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldEnabled;
                return;
            }
            // Bug 89413, End
            // Bug Id 112228 Begin
            else if ((this.dfsVoucherGroup.Text == "M" || this.dfsVoucherGroup.Text == "K" || this.dfsVoucherGroup.Text == "Q") && (this.cmbsVoucherStatus.Text == Sal.ListQueryTextX(this.cmbsVoucherStatus, 0) || this.cmbsVoucherStatus.Text == Sal.ListQueryTextX(this.cmbsVoucherStatus, 4)))
            {

                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldEnabled;
                return;
            }
            // Bug Id 112228 End
            e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
            return;
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
                else
                {
                    this.dfsRowText.EditDataItemSetEdited();
                }
            }
            if (Sal.IsNull(this.dfsRowText) && !(Sal.IsNull(this.dfsTextId)))
            {
                Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_InvalTextId, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
                e.Return = false;
                return;
            }
            else
            {
                e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
                return;
            }
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
        private void dfsEnteredByUserGroup_WindowActions(object sender, WindowActionsEventArgs e)
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

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void cbInterimVoucher_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
            }
            #endregion
        }

        /// <summary>
        /// SAM_Create event handler.
        /// </summary>
        /// <param name="message"></param>

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void cbAutomatic_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
            }
            #endregion
        }

        /// <summary>
        /// SAM_Create event handler.
        /// </summary>
        /// <param name="message"></param>

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void dfsCurrencyType_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.dfsCurrencyType_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsCurrencyType_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (!(Sal.IsNull(this.dfsCurrencyType)))
            {
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("Currency_Type_API.Exist", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                    if (!(this.dfsCurrencyType.DbPLSQLBlock(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "Currency_Type_API.Exist(\r\n" +
                        "   :i_hWndFrame.frmEntryVoucher.dfsCompany,\r\n" +
                        "   :i_hWndFrame.frmEntryVoucher.dfsCurrencyType )")))
                    {
                        e.Return = Sys.VALIDATE_Cancel;
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
        private void dfsCurrencyCode_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.dfsCurrencyCode_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsCurrencyCode_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam) == Sys.VALIDATE_Cancel)
            {
                e.Return = Sys.VALIDATE_Cancel;
                return;
            }
            if (!(Sal.IsNull(this.dfsCurrencyCode)))
            {
                frmVoucherPosting.FromHandle(this.hWndFirstTab).GetAttributes(this.dfsCompany.Text, this.dfsCurrencyCode.Text, this.sCurrencyCode, this.dfsCurrencyType.Text, this.dfdVoucherDate.DateTime);
                this.dfnCurrencyRate.Number = frmVoucherPosting.FromHandle(this.hWndFirstTab).GetRate(this.dfsCompany.Text, this.dfsCurrencyCode.Text);
                this.nDecimalsInRate = frmVoucherPosting.FromHandle(this.hWndFirstTab).i_nFinRound;
                this.dfnConversionFactor.Number = frmVoucherPosting.FromHandle(this.hWndFirstTab).i_nFinConversionFactor;
                this.nDecimalsInAmount = frmVoucherPosting.FromHandle(this.hWndFirstTab).i_nFinTransRound;
            }
            e.Return = Sys.VALIDATE_Ok;
            return;
            #endregion
        }
        #endregion

        #region Late Bind Methods

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
        public override SalBoolean vrtDataRecordPrepareNew()
        {
            return this.DataRecordPrepareNew();
        }

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalNumber vrtDataRecordToFormUser(ref SalString lsServerAttr, ref SalBoolean bMarkAsEdited)
        {
            return this.DataRecordToFormUser(ref lsServerAttr, ref bMarkAsEdited);
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

        private void menuItem_Copy_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = UM_CopyVoucher(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem_Copy_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            UM_CopyVoucher(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem_Copy_1_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = UM_CopyGLVoucher(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem_Copy_1_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            UM_CopyGLVoucher(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem__Interim_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = UM_InterimVoucher(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem__Interim_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            UM_InterimVoucher(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem__Use_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = UM_UseVouTemplate(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem__Use_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            UM_UseVouTemplate(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem_Create_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = UM_CreateVouTemplate(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem_Create_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            UM_CreateVouTemplate(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem_Instant_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = UM_InstantUpdate(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem_Instant_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            UM_InstantUpdate(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem_Change_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = ChangeCompany(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem_Change_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            ChangeCompany(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem__AddInvestment_Execute(object sender, FndCommandExecuteEventArgs e)
        {
            AddInvestment(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem__AddInvestment_Inquire(object sender, FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = AddInvestment(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        #endregion

        private void cbCorrection_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Click:
					this.cbCorrection_OnSAM_Click(sender, e);
					break;
			}
			#endregion

        }

        private void cbCorrection_OnSAM_Click(object sender, WindowActionsEventArgs e)
        {
            #region Actions
                e.Handled = true;
                e.Return = true;
                return;
            #endregion

        }


    }
}
