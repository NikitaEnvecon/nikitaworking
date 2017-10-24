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
//  Date        By      Notes 
//  YY-MM-DD  ------  ------------------------------------------------------------------- 
//  12-01-10  PRatLK  SFI-865, wrong title error when using navigator corrected
//  12-02-20  Shedlk  SFI-2398, Merged bug 101078
//  12-08-09  Kagalk  Bug 101446, Enabled to use Count Hits for Notes column
//  14-11-22  Chgulk  PRFI-3703, Merged LCS patch 119831.
#endregion

using System.Collections.Generic;
using Ifs.Fnd.ApplicationForms;
using Ifs.Fnd.Windows.Forms;
using PPJ.Runtime;
using PPJ.Runtime.Sql;
using PPJ.Runtime.Windows;
using PPJ.Runtime.Vis;

namespace Ifs.Application.Accrul
{
	
	/// <summary>
	/// </summary>
    [FndWindowRegistration("ACCOUNT,TAX_ACCOUNT,PS_CODE_ACCOUNT,ACCOUNTS_CONSOLIDATION,ACCOUNTING_CODEPART_A,ACCOUNT_LOV,ACCOUNT_CODE_A1,STAT_ACCOUNT_LOV", "Account", FndWindowRegistrationFlags.HomePage)]
    [FndWindowRegistration("PS_CODE_ACCOUNTING_CODE_PART_A", "TabAccounting", FndWindowRegistrationFlags.HomePage)]
    public partial class frmTabAccount : cTabFormWindowFin
    {
        #region Window Variables
        public SalNumber nRetVal = 0;
        public SalString sTemp = "";
        public SalString sTemp1 = "";
        public SalString sTemp2 = "";
        public SalString sTemp3 = "";
        public SalString sTemp4 = "";
        public SalString sTemp5 = "";
        public SalString sTemp6 = "";
        public SalString sTemp7 = "";
        public SalString sTemp8 = "";
        public SalString sTemp9 = "";
        public SalString sTemp10 = "";
        public SalString sTemp11 = "";
        public SalString sTemp12 = "";
        public SalString sBudTemp1 = "";
        public SalString sBudTemp2 = "";
        public SalString sBudTemp3 = "";
        public SalString sBudTemp4 = "";
        public SalString sBudTemp5 = "";
        public SalString sBudTemp6 = "";
        public SalString sBudTemp7 = "";
        public SalString sBudTemp8 = "";
        public SalString sBudTemp9 = "";
        public SalString sBudTemp10 = "";
        public SalString sConsCompany = "";
        public SalNumber nIndex = 0;
        public SalString sTextType = "";
        public SalString sDummyLedgFlag = "";
        public SalString sDummyCurrBalance = "";
        public SalString sDummyBudAccount = "";
        public SalString sDummyStatAccount = "";
        public SalString lsLedgFlag = "";
        public SalString lsCurrBalance = "";
        public SalString lsBudAccount = "";
        public SalString lsStatAccount = "";
        public SalString lsTextTypeValue = "";
        public SalString lsLookupText = "";
        public SalString sOldValue = "";
        public SalBoolean bEditFlag = false;
        public SalNumber nRC = 0;
        public SalString sTmp = "";
        public SalNumber nItemIndexCompany = 0;
        public SalString sTaxHandlingValue = "";
        public SalString sPrevTaxHandlingValue = "";
        public SalString sBaseForPFE = "";
        private SalString sAccountConsBalExist = "FALSE";

        // All enumerations programatically used by this form.
        protected cEnumeration accountRequest;
        protected cEnumeration accountRequestText;
        protected cEnumeration taxHandlingValue;

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public frmTabAccount()
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
        public new static frmTabAccount FromHandle(SalWindowHandle handle)
        {
            return ((frmTabAccount)SalWindow.FromHandle(handle, typeof(frmTabAccount)));
        }
        #endregion

        #region Methods
        //Finds out if an account has balances in the consolidation balances tab.
        protected virtual void GetAccountConsolBalExist()
        {
            #region Actions
            if (Ifs.Fnd.ApplicationForms.Int.IsSystemComponentInstalled("GROCON"))
            {
                DbPLSQLBlock(":i_hWndFrame.frmTabAccount.sAccountConsBalExist := &AO.Consol_Balances_API.Acc_Bal_Exist(:i_hWndFrame.frmTabAccount.dfsCompany IN ,:i_hWndFrame.frmTabAccount.cmbAccount IN);");
            }
            #endregion
        }

        protected override void OnPamCreate()
        {
            // Initialize all enumeration that are used programatically upon creation!
            IDictionary<string, cEnumeration> IIDs = cEnumeration.GetMulti("AccountRequest", "AccountRequestText", "TaxHandlingValue");
            accountRequest = IIDs["AccountRequest"];
            accountRequestText = IIDs["AccountRequestText"];
            taxHandlingValue = IIDs["TaxHandlingValue"];
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public new SalBoolean FrameStartupUser()
        {
            using (new SalContext(this))
            {
                // Bug 72228, Begin. (Set the Codepart value)
                dfsCodePart.Text = "A";
                // Bug 72228, End.
                // Above code moved to vrtActivate
                // Bug 76138, Moved the server call to SAM_CreateComplete
                Sal.WaitCursor(false);
                return true;
            }
        }
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public override SalNumber vrtActivate(fcURL URL)
        {
            bool AccountOpenedFromTransfer = false;

            using (new SalContext(this))
            {
                // Code moved from FrameStartupUser
                if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.RecCountGet() > 0)
                {
                    Sal.WaitCursor(true);
                    if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.TypeGet() == "ZOOM")
                    {
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.i_sItemNames[0] = "ACCOUNT";
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.i_sItemNames[1] = "COMPANY";
                        // Below code moved from frmTabAccount_OnSAM_Create
                        this.nItemIndexCompany = Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemIndexGet("VOUCHER_COMPANY");
                        if (this.nItemIndexCompany >= 0)
                        {
                            this.nRC = Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemValueStrGet(this.nItemIndexCompany, 0, ref this.sTmp);
                        }
                        else
                        {
                            this.nItemIndexCompany = Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemIndexGet("COMPANY");
                            if (this.nItemIndexCompany >= 0)
                            {
                                this.nRC = Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemValueStrGet(this.nItemIndexCompany, 0, ref this.sTmp);
                            }
                        }
                        if (this.sTmp != Ifs.Fnd.ApplicationForms.Const.strNULL)
                        {
                            this.i_sCompany = this.sTmp;
                            // to ensure that the correct company is set in the UserGlobaValue list.
                            UserGlobalValueSet("COMPANY", this.i_sCompany);
                        }
                    }
                    AccountOpenedFromTransfer = true;
                    InitFromTransferredData();
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();
                    Sal.WaitCursor(false);

                }
                EnableDisableCodeParts();
                Sal.SendMsg(cmbCostCenter, Sys.SAM_DropDown, 0, 0);
                Sal.SendMsg(cmbCodeC, Sys.SAM_DropDown, 0, 0);
                Sal.SendMsg(cmbCodeD, Sys.SAM_DropDown, 0, 0);
                Sal.SendMsg(cmbCodeG, Sys.SAM_DropDown, 0, 0);
                Sal.SendMsg(cmbCodeH, Sys.SAM_DropDown, 0, 0);
                Sal.SendMsg(cmbCodeI, Sys.SAM_DropDown, 0, 0);
                Sal.SendMsg(cmbCodeJ, Sys.SAM_DropDown, 0, 0);
                Sal.SendMsg(cmbQuantity, Sys.SAM_DropDown, 0, 0);
                Sal.SendMsg(cmbObject, Sys.SAM_DropDown, 0, 0);
                Sal.SendMsg(cmbProject, Sys.SAM_DropDown, 0, 0);
                Sal.SendMsg(cmbText, Sys.SAM_DropDown, 0, 0);
                Sal.SendMsg(cmbReqProcessCode, Sys.SAM_DropDown, 0, 0);
                Sal.WaitCursor(false);
                if (AccountOpenedFromTransfer)
                    return false;
                // Here when activate is called the form get populated with proper data therefore when calling setWindowTitle
                // after activate ensures that the proper window title is set when using the form through the navigator.
                bool bReturn = base.Activate(URL);
                this.SetWindowTitle();
                return bReturn;
            }
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public new SalString GetWindowTitle()
        {
            using (new SalContext(this))
            {
                SalString sTranslatedTitle = i_sOldLabel;
                FinTranslateStringCodePart(i_sCompany, string.Empty, ref sTranslatedTitle);
                if (cmbAccount.i_sMyValue == Ifs.Fnd.ApplicationForms.Const.strNULL)
                    return sTranslatedTitle;

                return sTranslatedTitle + " - " + cmbAccount.i_sMyValue;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalNumber CodestrCompl(SalNumber nWhat)
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
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:

                        Sal.WaitCursor(true);
                        // Bug 79375 Begin
                        dfsCodePart.Text = "A";
                        // Bug 79375 End
                        sItemNames[0] = "COMPANY";
                        hWndItems[0] = dfsCompany;
                        sItemNames[1] = "CODE_PART_VALUE";
                        hWndItems[1] = cmbAccount;
                        // Bug 72228, Begin. (Additionally adding the codepart during the DataTransfer)
                        sItemNames[2] = "CODE_PART";
                        hWndItems[2] = dfsCodePart;
                        // Bug 72228, End.

                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("OBJECT_ID", this, sItemNames, hWndItems);
                        SessionCreateWindow(Pal.GetActiveInstanceName("frmCdCompl"), Sys.hWndMDI);
                        Sal.WaitCursor(false);
                        return 1;

                        goto case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        return !(Sal.SendMsg(i_hWndFrame, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0)) && Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("frmCdCompl"));
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalNumber TaxCodePerAccount(SalNumber nWhat)
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
                        if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("frmAccountTaxCode"))))
                        {
                            return 0;
                        }
                        // Bug 82084 Begin change cmbAccount to cmbAccount.i_sMyValue
                        if (cmbAccount.i_sMyValue == Ifs.Fnd.ApplicationForms.Const.strNULL)
                        {
                            return 0;
                        }
                        cSessionManager.c_lsStmt = ":i_hWndFrame.frmTabAccount.sTaxHandlingValue :=\r\n" +
                        "                        &AO.ACCOUNT_API.Get_Tax_Handling_Value(\r\n" +
                        "                        :i_hWndFrame.frmTabAccount.dfsCompany,\r\n" +
                        "                        :i_hWndFrame.frmTabAccount.cmbAccount.i_sMyValue)";
                        // Bug 82084 End
                        using (SignatureHints hints = SignatureHints.NewContext())
                        {
                            hints.Add("ACCOUNT_API.Get_Tax_Handling_Value", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                            DbPLSQLBlock(cSessionManager.c_hSql, cSessionManager.c_lsStmt);
                        }
                        if (sTaxHandlingValue == "BLOCKED")
                        {
                            return 0;
                        }
                        return 1;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        Sal.WaitCursor(true);
                        sItemNames[0] = "COMPANY";
                        hWndItems[0] = dfsCompany;
                        sItemNames[1] = "ACCOUNT";
                        hWndItems[1] = cmbAccount;

                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("OBJECT_ID", this, sItemNames, hWndItems);
                        SessionCreateWindow(Pal.GetActiveInstanceName("frmAccountTaxCode"), Sys.hWndMDI);
                        Sal.WaitCursor(false);
                        return 1;
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalNumber Translation(SalNumber nWhat)
        {
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        return !(Sal.SendMsg(i_hWndFrame, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0)) &&
                            Ifs.Fnd.ApplicationForms.Var.Component.IsWindowAvailable(Pal.GetActiveInstanceName("frmCompanyTranslation")) &&
                            Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("frmCompanyTranslation"));

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        string sAttribute = Ifs.Fnd.ApplicationForms.Const.strNULL;
                        if (cmbAccount.i_sMyValue != Ifs.Fnd.ApplicationForms.Const.strNULL)
                            sAttribute = string.Format("'{0}'", cmbAccount.i_sMyValue);

                        Ifs.Fnd.ApplicationForms.Var.Cache.SessionStore("TRANSLATE_COMPANY", i_sCompany);
                        Ifs.Fnd.ApplicationForms.Var.Cache.SessionStore("TRANSLATE_MODULE", "ACCRUL");
                        Ifs.Fnd.ApplicationForms.Var.Cache.SessionStore("TRANSLATE_LU", "Account");
                        Ifs.Fnd.ApplicationForms.Var.Cache.SessionStore("TRANSLATE_ATTRIBUTE", sAttribute);
                        SessionNavigate(Pal.GetActiveInstanceName("frmCompanyTranslation"));
                        return 1;
                }
            }

            return 0;
        }

        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalNumber FreeText(SalNumber nWhat)
        {
            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        Sal.WaitCursor(false);
                        SalString sTemp = mlsText.Text;
                        if (frmTabAccount.FromHandle(i_hWndFrame).mlsText.EditLaunchEditor() == Sys.IDOK)
                        {
                            mlsText.EditDataItemValueSet(1, sTemp.ToHandle());
                            Sal.SendMsg(cbFreeText, Const.PAM_AccntCheckUncheckCBText, 0, 0);
                        }
                        return 1;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        return mlsText.EditDataItemStateGet() != Ifs.Fnd.ApplicationForms.Const.EDIT_Empty;
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// Gets client default values for NEW records
        /// </summary>
        /// <returns></returns>
        public new SalBoolean DataRecordGetDefaults()
        {
            #region Actions
            using (new SalContext(this))
            {
                dfsCompany.Text = i_sCompany;
                dfNoArchiveTrans.Text = "FALSE";
                dfNoArchiveTrans.EditDataItemSetEdited();
                // Bug 77590, Begin
                rbAllTrans.Checked = true;
                // Bug 77590, End
                cbLedgFlag.Checked = false;
                cbCurrBalance.Checked = false;
                cbBudAccount.Checked = false;
                cbStatisticalAccount.Checked = false;
                cbTaxAccount.Checked = false;
                if (!(DbPrepareAndExecute(cSessionManager.c_hSql, "SELECT " + cSessionManager.c_sDbPrefix + "Company_Finance_API.Get_Cons_Company(:i_hWndFrame.frmTabAccount.dfsCompany) INTO :i_hWndFrame.frmTabAccount.sConsCompany\r\nFROM Dual")))
                {
                    return false;
                }
                if (!(DbFetchNext(cSessionManager.c_hSql, ref nIndex)))
                {
                    return false;
                }
                dfConsCompany.Text = sConsCompany.Trim();
                dfsCompany.EditDataItemSetEdited();

                return true;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber EnableDisableCodeParts()
        {
            #region Actions
            using (new SalContext(this))
            {
                if (cFinlibServices.lsDisplayCodePart[1] == "N")
                {
                    Sal.DisableWindowAndLabel(cmbCostCenter);
                    Sal.DisableWindowAndLabel(cmbReqBudgetCodeB);
                }
                else
                {
                    Sal.EnableWindowAndLabel(cmbCostCenter);
                    Sal.EnableWindowAndLabel(cmbReqBudgetCodeB);
                }
                if (cFinlibServices.lsDisplayCodePart[2] == "N")
                {
                    Sal.DisableWindowAndLabel(cmbCodeC);
                    Sal.DisableWindowAndLabel(cmbReqBudgetCodeC);
                }
                else
                {
                    Sal.EnableWindowAndLabel(cmbCodeC);
                    Sal.EnableWindowAndLabel(cmbReqBudgetCodeC);
                }
                if (cFinlibServices.lsDisplayCodePart[3] == "N")
                {
                    Sal.DisableWindowAndLabel(cmbCodeD);
                    Sal.DisableWindowAndLabel(cmbReqBudgetCodeD);
                }
                else
                {
                    Sal.EnableWindowAndLabel(cmbCodeD);
                    Sal.EnableWindowAndLabel(cmbReqBudgetCodeD);
                }
                if (cFinlibServices.lsDisplayCodePart[4] == "N")
                {
                    Sal.DisableWindowAndLabel(cmbObject);
                    Sal.DisableWindowAndLabel(cmbReqBudgetCodeE);
                }
                else
                {
                    Sal.EnableWindowAndLabel(cmbObject);
                    Sal.EnableWindowAndLabel(cmbReqBudgetCodeE);
                }
                if (cFinlibServices.lsDisplayCodePart[5] == "N")
                {
                    Sal.DisableWindowAndLabel(cmbProject);
                    Sal.DisableWindowAndLabel(cmbReqBudgetCodeF);
                }
                else
                {
                    Sal.EnableWindowAndLabel(cmbProject);
                    Sal.EnableWindowAndLabel(cmbReqBudgetCodeF);
                }
                if (cFinlibServices.lsDisplayCodePart[6] == "N")
                {
                    Sal.DisableWindowAndLabel(cmbCodeG);
                    Sal.DisableWindowAndLabel(cmbReqBudgetCodeG);
                }
                else
                {
                    Sal.EnableWindowAndLabel(cmbCodeG);
                    Sal.EnableWindowAndLabel(cmbReqBudgetCodeG);
                }
                if (cFinlibServices.lsDisplayCodePart[7] == "N")
                {
                    Sal.DisableWindowAndLabel(cmbCodeH);
                    Sal.DisableWindowAndLabel(cmbReqBudgetCodeH);
                }
                else
                {
                    Sal.EnableWindowAndLabel(cmbCodeH);
                    Sal.EnableWindowAndLabel(cmbReqBudgetCodeH);
                }
                if (cFinlibServices.lsDisplayCodePart[8] == "N")
                {
                    Sal.DisableWindowAndLabel(cmbCodeI);
                    Sal.DisableWindowAndLabel(cmbReqBudgetCodeI);
                }
                else
                {
                    Sal.EnableWindowAndLabel(cmbCodeI);
                    Sal.EnableWindowAndLabel(cmbReqBudgetCodeI);
                }
                if (cFinlibServices.lsDisplayCodePart[9] == "N")
                {
                    Sal.DisableWindowAndLabel(cmbCodeJ);
                    Sal.DisableWindowAndLabel(cmbReqBudgetCodeJ);
                }
                else
                {
                    Sal.EnableWindowAndLabel(cmbCodeJ);
                    Sal.EnableWindowAndLabel(cmbReqBudgetCodeJ);
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="sCode"></param>
        /// <returns></returns>
        public virtual SalString GetIID(string dbValue)
        {
            return accountRequest.Decode(dbValue);
        }

        /// <summary>
        /// </summary>
        /// <param name="p_bEnable"></param>
        /// <returns></returns>
        public virtual SalNumber EnableConsolidationInfo(SalBoolean p_bEnable)
        {
            #region Actions
            using (new SalContext(this))
            {
                if (p_bEnable)
                {
                    Sal.EnableWindowAndLabel(dfsConsolidAccount);
                }
                else
                {
                    Sal.DisableWindowAndLabel(dfsConsolidAccount);
                    Sal.DisableWindow(dfsConsolidAccntDescription);
                    Sal.ClearField(dfsConsolidAccount);
                    Sal.ClearField(dfsConsolidAccntDescription);
                }
            }

            return 0;
            #endregion
        }
        // Menu
        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalNumber ConnectAttribute(SalNumber nWhat)
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
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        Sal.WaitCursor(true);
                        sItemNames[0] = "COMPANY";
                        hWndItems[0] = dfsCompany;
                        sItemNames[1] = "CODE_PART_VALUE";
                        hWndItems[1] = cmbAccount;
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("AttributeCon", this, sItemNames, hWndItems);
                        SessionCreateWindow(Pal.GetActiveInstanceName("tbwAttributeCon"), Sys.hWndMDI);
                        Sal.WaitCursor(false);
                        return 1;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        if (Sal.SendMsg(i_hWndFrame, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0))
                        {
                            return 0;
                        }
                        // Bug 82084 Begin change cmbAccount to cmbAccount.i_sMyValue
                        if (cmbAccount.i_sMyValue == Ifs.Fnd.ApplicationForms.Const.strNULL)
                        {
                            return 0;
                        }
                        // Bug 82084 End
                        // Bug 79351, Begin. Added IsDataSourceAvailable()
                        if (!(Ifs.Fnd.ApplicationForms.Var.Component.IsWindowAvailable(Pal.GetActiveInstanceName("tbwAttributeCon")) && Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("tbwAttributeCon"))))
                        {
                            return 0;
                        }
                        // Bug 79351, End
                        return 1;
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalNumber ConnProjectCostElement(SalNumber nWhat)
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
                        if (Sal.SendMsg(i_hWndFrame, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0))
                        {
                            return 0;
                        }
                        if (!(Ifs.Fnd.ApplicationForms.Var.Component.IsWindowAvailable(Pal.GetActiveInstanceName("tbwCostElementToAccount"))))
                        {
                            return 0;
                        }
                        GetBaseForPFE();
                        if (sBaseForPFE != "A")
                        {
                            return 0;
                        }
                        return 1;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        Sal.WaitCursor(true);
                        sItemNames[0] = "COMPANY";
                        hWndItems[0] = dfsCompany;
                        sItemNames[1] = "ACCOUNT";
                        hWndItems[1] = cmbAccount;
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init(Pal.GetActiveInstanceName("tbwCostElementToAccount"), this, sItemNames, hWndItems);
                        if (Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("tbwCostElementToAccount")))
                        {
                            SessionCreateWindow(Pal.GetActiveInstanceName("tbwCostElementToAccount"), Sys.hWndMDI);
                        }
                        Sal.WaitCursor(false);
                        return 1;
                }
            }

            return 0;
            #endregion
        }
        // This function is to return Account Type and Account Group when populate query dialog
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public new SalNumber DataRecordQueryDialog()
        {
            #region Actions
            using (new SalContext(this))
            {
                if (Sal.IsNull(dfsCompany))
                {
                    dfsCompany.Text = i_sCompany;
                }
                return ((cDataSource)this).DataRecordQueryDialog();
            }
            #endregion
        }
        // Bug 89313, Removed the method GetArchiveTransDb
        // Bug 65271, Begin.
        /// <summary>
        /// </summary>
        /// <param name="sWindowName"></param>
        /// <returns></returns>
        public new SalNumber DataSourcePrepareKeyTransfer(SalString sWindowName)
        {
            #region Local Variables
            SalArray<SalString> sArray = new SalArray<SalString>();
            SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                if (sWindowName == Pal.GetActiveInstanceName("frmHistoryLog"))
                {
                    dfsCodePart.Text = "A";
                    sArray[0] = "COMPANY";
                    sArray[1] = "CODE_PART";
                    sArray[2] = "CODE_PART_VALUE";
                    hWndItems[0] = dfsCompany;
                    hWndItems[1] = dfsCodePart;
                    hWndItems[2] = cmbAccount;
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("Account", this, sArray, hWndItems);
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.TypeSet("CREATE_WINDOW");
                }
                else
                {
                    ((cDataSource)this).DataSourcePrepareKeyTransfer(sWindowName);
                }
            }

            return 0;
            #endregion
        }
        // Bug 65271, End.
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber GetBaseForPFE()
        {
            #region Actions
            using (new SalContext(this))
            {
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("Accounting_Code_Parts_API.Get_Base_For_Followup_Element", System.Data.ParameterDirection.Input);
                    DbPLSQLBlock(cSessionManager.c_hSql, " :i_hWndFrame.frmTabAccount.sBaseForPFE:= &AO.Accounting_Code_Parts_API.Get_Base_For_Followup_Element(\r\n" +
                        "	      :i_hWndFrame.frmTabAccount.dfsCompany)");
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        public virtual SalString FormatWhereClause(SalNumber wParam, SalNumber lParam)
        {
            #region Local Variables
            SalString sWhere = "";
            SalString sFormattedWhere = "";
            SalNumber nOffset = 0;
            // Bug 101446, begin
            SalNumber nEnd = 0;
            SalNumber nLength = 0;
            SalString sStmt = "";
            SalString sModifiedStmt = "";
            string newWhere;
            // Bug 101446, end            
            #endregion
            
            #region Actions
            using (new SalContext(this))
            {
                sWhere = SalString.FromHandle(lParam);
                // Bug 101446, begin
                sStmt = "CB_TEXT = :_gBs@TRUE";
                nOffset = sWhere.Scan(sStmt);
                if (nOffset != -1)
                {
                    sModifiedStmt = "TEXT IS NOT NULL";
                }
                else
                {
                    sStmt = "CB_TEXT = :_gBs@FALSE";
                    nOffset = sWhere.Scan(sStmt);
                    if (nOffset != -1)
                    {
                        sModifiedStmt = "TEXT IS NULL";
                    }
                    else
                    {
                        sStmt = "upper( CB_TEXT ) = upper( :_gBs@TRUE )";
                        nOffset = sWhere.Scan(sStmt);
                        if (nOffset != -1)
                        {
                            sModifiedStmt = "TEXT IS NOT NULL";
                        }
                        else
                        {
                            sStmt = "upper( CB_TEXT ) = upper( :_gBs@FALSE )";
                            nOffset = sWhere.Scan(sStmt);
                            if (nOffset != -1)
                            {
                                sModifiedStmt = "TEXT IS NULL";
                            }
                        }

                    }

                }
                if (nOffset != -1)
                {
                    nLength = sStmt.Length;
                    sFormattedWhere = sWhere.Left(nOffset) + sModifiedStmt + sWhere.Right(sWhere.Length - (nOffset + nLength));
                    sWhere = sFormattedWhere;
                }
                // Bug 101446, end
                
                return sWhere;
            }

            return "";
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        public virtual SalString FormatOrderByClause(SalNumber wParam, SalNumber lParam)
        {
            #region Local Variables
            SalString sOrderBy = "";
            SalString sFormattedOrderBy = "";
            SalNumber nOffset = 0;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                sOrderBy = SalString.FromHandle(lParam);
                nOffset = sOrderBy.Scan("CB_TEXT DESC");
                if (nOffset != -1)
                {
                    sFormattedOrderBy = sOrderBy.Replace(nOffset, 12, "TEXT ASC");
                    return sFormattedOrderBy;
                }
               
                else
                {
                    nOffset = sOrderBy.Scan("CB_TEXT");
                    if (nOffset != -1)
                    {
                        sFormattedOrderBy = sOrderBy.Replace(nOffset, 7, "TEXT DESC");
                        return sFormattedOrderBy;
                    }
                }
                return sOrderBy;
            }

            return "";
            #endregion
        }
        #endregion

        #region Window Actions

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void frmTabAccount_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_CreateComplete:
                    this.frmTabAccount_OnSAM_CreateComplete(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate:
                    this.frmTabAccount_OnPM_DataSourcePopulate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceRefresh:
                    this.frmTabAccount_OnPM_DataSourceRefresh(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceClear:
                    this.frmTabAccount_OnPM_DataSourceClear(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew:
                    this.frmTabAccount_OnPM_DataRecordNew(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_UserProfileChanged:
                    this.frmTabAccount_OnPM_UserProfileChanged(sender, e);
                    break;

                case Const.PM_TranslateCodePartTab:
                    e.Handled = true;
                    e.Return = true;
                    return;

                case Sys.SAM_Create:
                    this.frmTabAccount_OnSAM_Create(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordDuplicate:
                    this.frmTabAccount_OnPM_DataRecordDuplicate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave:
                    this.frmTabAccount_OnPM_DataSourceSave(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceUserWhere:
                    this.frmTabAccount_OnPM_DataSourceUserWhere(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceUserOrderBy:
                    this.frmTabAccount_OnPM_DataSourceUserOrderBy(sender, e);
                    break;
                // Bug 101446, begin
                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceHitCount:
                    this.frmTabAccount_OnPM_DataSourceHitCount(sender, e);
                    break;
                // Bug 101446, end

            }
            #endregion
        }

        /// <summary>
        /// SAM_CreateComplete event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmTabAccount_OnSAM_CreateComplete(object sender, WindowActionsEventArgs e)
        {
            e.Handled = true;
            Sal.SendClassMessage(Sys.SAM_CreateComplete, Sys.wParam, Sys.lParam);

            // Remove the tab "BudgetDemand" if GenLed is not installed.
            if (!Int.IsGenLedInstalled)
                this.picTabs.Enable(this.picTabs.FindName("tabBudgetDemand"), false);
        }

        /// <summary>
        /// PM_DataSourceRefresh event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmTabAccount_OnPM_DataSourceRefresh(object sender, WindowActionsEventArgs e)
        {
            e.Handled = true;
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceRefresh, Sys.wParam, Sys.lParam);
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                GetAccountConsolBalExist();
                if ((this.dfsLogicalAccountType.Text == "S" || this.dfsLogicalAccountType.Text == "O") && (Ifs.Application.Accrul.Var.FinlibServices.IsMasterCompany(dfsCompany.Text) == "TRUE") && (cbStatisticalAccount.Checked) && (sAccountConsBalExist == "FALSE"))
                {
                    Sal.EnableWindow(cbExcludeCurrTrans);
                    return;
                }
                else
                {
                    Sal.DisableWindow(cbExcludeCurrTrans);
                    return;
                }
            }
        }

        /// <summary>
        /// PM_DataSourcePopulate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmTabAccount_OnPM_DataSourcePopulate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.nRetVal = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Sys.wParam, Sys.lParam);
            // Bug 89313, Removed the IF condition which calls the GetArchiveTransDb()
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute && ((bool)this.nRetVal))
            {
                this.SetWindowTitle();
                if (this.dfConsCompany.Text == Ifs.Fnd.ApplicationForms.Const.strNULL)
                {
                    this.EnableConsolidationInfo(false);
                }
                else
                {
                    this.EnableConsolidationInfo(true);
                }
                if (this.dfNoArchiveTrans.Text == "FALSE")
                {
                    // Bug 77590, Begin
                    this.rbAllTrans.Checked = true;
                    // Bug 77590, End
                }
                else
                {
                    // Bug 77590, Begin
                    this.rbMatchedTrans.Checked = true;
                    // Bug 77590, End
                }
                this.sPrevTaxHandlingValue = this.cmbTaxHandlingValue.Text;
                // Logic Related to the exclude from curr trans check box.
                GetAccountConsolBalExist();
                if ((this.dfsLogicalAccountType.Text == "S" || this.dfsLogicalAccountType.Text == "O") && (Ifs.Application.Accrul.Var.FinlibServices.IsMasterCompany(dfsCompany.Text) == "TRUE") && (cbStatisticalAccount.Checked) && (sAccountConsBalExist == "FALSE"))
                {
                    Sal.EnableWindow(cbExcludeCurrTrans);
                }
                else
                {
                    Sal.DisableWindow(cbExcludeCurrTrans);
                }
            }
            e.Return = this.nRetVal;
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataSourceClear event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmTabAccount_OnPM_DataSourceClear(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.nRetVal = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceClear, Sys.wParam, Sys.lParam);
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute && ((bool)this.nRetVal))
            {
                this.cbLedgFlag.Checked = false;
                this.cbCurrBalance.Checked = false;
                this.cbBudAccount.Checked = false;
                this.cbStatisticalAccount.Checked = false;
                this.cbTaxAccount.Checked = false;
                this.SetWindowTitle();
                this.EnableConsolidationInfo(true);
                sAccountConsBalExist = "FALSE";
                Sal.EnableWindow(cbExcludeCurrTrans);
            }
            e.Return = this.nRetVal;
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataRecordNew event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmTabAccount_OnPM_DataRecordNew(object sender, WindowActionsEventArgs e)
        {
            #region Local Variables
            SalString sFalseValue = "FALSE";
            #endregion

            #region Actions
            e.Handled = true;
            this.nRetVal = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew, Sys.wParam, Sys.lParam);
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute && ((bool)this.nRetVal))
            {
                this.cbLedgFlag.Checked = false;
                this.cbCurrBalance.Checked = false;
                this.cbBudAccount.Checked = false;
                this.cbStatisticalAccount.Checked = false;
                this.cbTaxAccount.Checked = false;
                this.SetWindowTitle();
                if (this.dfConsCompany.Text == Ifs.Fnd.ApplicationForms.Const.strNULL)
                {
                    this.EnableConsolidationInfo(false);
                }
                else
                {
                    this.EnableConsolidationInfo(true);
                }
                this.sPrevTaxHandlingValue = taxHandlingValue.Decode("ALL");
                Sal.DisableWindow(this.cbExcludeProjFollowup);
                Sal.EnableWindow(cbExcludeCurrTrans);
                sAccountConsBalExist = "FALSE";
                cbExcludeCurrTrans.Checked = false;
                cbExcludeCurrTrans.EditDataItemValueSet(1, sFalseValue.ToHandle());
            }
            e.Return = this.nRetVal;
            return;
            #endregion
        }

        /// <summary>
        /// PM_UserProfileChanged event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmTabAccount_OnPM_UserProfileChanged(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_UserProfileChanged, Sys.wParam, Sys.lParam))
            {
                this.EnableDisableCodeParts();
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
        /// SAM_Create event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmTabAccount_OnSAM_Create(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam);
            e.Return = true;
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataRecordDuplicate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmTabAccount_OnPM_DataRecordDuplicate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordDuplicate, Sys.wParam, Sys.lParam))
            {
                if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
                {
                    Sal.SendMsg(this.dfsAccountType, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, 0, 0);
                    if (this.dfNoArchiveTrans.Text == "FALSE")
                    {
                        // Bug 77590, Begin
                        this.rbAllTrans.Checked = true;
                        // Bug 77590, End
                    }
                    else
                    {
                        // Bug 77590, Begin
                        this.rbMatchedTrans.Checked = true;
                        // Bug 77590, End
                    }
                    sAccountConsBalExist = "FALSE";

                }
                e.Return = true;
                return;
            }
            e.Return = false;
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataSourceSave event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmTabAccount_OnPM_DataSourceSave(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Sys.wParam, Sys.lParam))
            {
                if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
                {
                    this.SetWindowTitle();
                    if ((this.dfsLogicalAccountType.Text == "S" || this.dfsLogicalAccountType.Text == "O") && (Ifs.Application.Accrul.Var.FinlibServices.IsMasterCompany(dfsCompany.Text) == "TRUE") && (cbStatisticalAccount.Checked) && (sAccountConsBalExist = "FALSE"))
                    {
                        Sal.EnableWindow(cbExcludeCurrTrans);
                        return;
                    }
                    else
                    {
                        Sal.DisableWindow(cbExcludeCurrTrans);
                        return;
                    }
                }
                e.Return = true;
                return;
            }
            e.Return = false;
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataSourceUserWhere event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmTabAccount_OnPM_DataSourceUserWhere(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceUserWhere, Sys.wParam, this.FormatWhereClause(Sys.wParam, Sys.lParam).ToHandle());
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataSourceUserOrderBy event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmTabAccount_OnPM_DataSourceUserOrderBy(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceUserOrderBy, Sys.wParam, this.FormatOrderByClause(Sys.wParam, Sys.lParam).ToHandle());
            return;
            #endregion
        }

        // Bug 101446, begin
        /// <summary>
        /// PM_DataSourceHitCount event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmTabAccount_OnPM_DataSourceHitCount(object sender, WindowActionsEventArgs e)
        {           
            #region Actions
            e.Handled = true;
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceHitCount, Sys.wParam, this.FormatWhereClause(Sys.wParam, Sys.lParam).ToHandle());
            return;
            #endregion
        }
        // Bug 101446, end
        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void cmbAccount_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_Validate:
                    this.cmbAccount_OnSAM_Validate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_Validate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cmbAccount_OnSAM_Validate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.cmbAccount.i_sMyValue = this.cmbAccount.i_sMyValue.ToUpper();
            if ((this.cmbAccount.i_sMyValue.Scan("&") >= 0) || (this.cmbAccount.i_sMyValue.Scan("'") >= 0))
            {
                Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_InvalidCharacterAccount, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                e.Return = Sys.VALIDATE_Cancel;
                return;
            }
            e.Return = Sal.SendClassMessage(Sys.SAM_Validate, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void dfsCompany_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemNew:
                    this.dfsCompany_OnPM_DataItemNew(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemNew event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsCompany_OnPM_DataItemNew(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemNew, Sys.wParam, Sys.lParam))
            {
                Sal.PostMsg(this.dfConsCompany, Ifs.Fnd.ApplicationForms.Const.PM_DataItemPopulate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                e.Return = true;
                return;
            }
            e.Return = false;
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void dfsAccountType_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.dfsAccountType_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsAccountType_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam))
            {
                // Bug 85877, Begin, checked for the permission to edit
                if (this.dfsAccountType.Text != Ifs.Fnd.ApplicationForms.Const.strNULL && Sal.SendMsg(this.dfsAccountType.i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled, 0, 0) == Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldEnabled)
                {
                    Sal.WaitCursor(true);
                    this.sTemp = this.dfsAccountType.Text;
                    using (SignatureHints hints = SignatureHints.NewContext())
                    {
                        hints.Add("Account_Type_API.Get_Default_Codepart_Demands_", System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                        hints.Add("ACCOUNT_TYPE_API.Get_Logical_Account_Type", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                        hints.Add("ACCOUNT_TYPE_VALUE_API.Encode", System.Data.ParameterDirection.Input);
                        if (!(this.dfsAccountType.DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN " + cSessionManager.c_sDbPrefix + "Account_Type_API.Get_Default_Codepart_Demands_(\r\n" +
                            "		:i_hWndFrame.frmTabAccount.sTemp1 ,\r\n" +
                            "		:i_hWndFrame.frmTabAccount.sTemp2 ,\r\n" +
                            "		:i_hWndFrame.frmTabAccount.sTemp3 ,\r\n" +
                            "		:i_hWndFrame.frmTabAccount.sTemp4 ,\r\n" +
                            "		:i_hWndFrame.frmTabAccount.sTemp5 ,\r\n" +
                            "		:i_hWndFrame.frmTabAccount.sTemp6 ,\r\n" +
                            "		:i_hWndFrame.frmTabAccount.sTemp7 ,\r\n" +
                            "		:i_hWndFrame.frmTabAccount.sTemp8 ,\r\n" +
                            "		:i_hWndFrame.frmTabAccount.sTemp9 ,\r\n" +
                            "		:i_hWndFrame.frmTabAccount.sTemp10 ,\r\n" +
                            "		:i_hWndFrame.frmTabAccount.sTemp11,\r\n" +
                            "		:i_hWndFrame.frmTabAccount.sTemp12,\r\n" +
                            "		:i_hWndFrame.frmTabAccount.sBudTemp1 ,\r\n" +
                            "		:i_hWndFrame.frmTabAccount.sBudTemp2 ,\r\n" +
                            "		:i_hWndFrame.frmTabAccount.sBudTemp3 ,\r\n" +
                            "		:i_hWndFrame.frmTabAccount.sBudTemp4 ,\r\n" +
                            "		:i_hWndFrame.frmTabAccount.sBudTemp5 ,\r\n" +
                            "		:i_hWndFrame.frmTabAccount.sBudTemp6 ,\r\n" +
                            "		:i_hWndFrame.frmTabAccount.sBudTemp7 ,\r\n" +
                            "		:i_hWndFrame.frmTabAccount.sBudTemp8 ,\r\n" +
                            "		:i_hWndFrame.frmTabAccount.sBudTemp9 ,\r\n" +
                            "		:i_hWndFrame.frmTabAccount.sBudTemp10 ,\r\n" +
                            "		:i_hWndFrame.frmTabAccount.i_sCompany,\r\n" +
                            "		:i_hWndFrame.frmTabAccount.sTemp ) ;\r\n" +
                            "		:i_hWndFrame.frmTabAccount.dfsLogicalAccountType :=  SUBSTR(" + cSessionManager.c_sDbPrefix + "ACCOUNT_TYPE_VALUE_API.Encode (\r\n" +
                            "                                           					            " + cSessionManager.c_sDbPrefix + "ACCOUNT_TYPE_API.Get_Logical_Account_Type(\r\n" +
                            "                                            					            :i_hWndFrame.frmTabAccount.i_sCompany,:i_hWndFrame.frmTabAccount.dfsAccountType)),1,20)  ;\r\n	END;")))
                        {
                            Sal.WaitCursor(false);
                            e.Return = false;
                            return;
                        }
                    }
                    this.cmbCostCenter.Text = this.GetIID(this.sTemp1);
                    this.cmbCodeC.Text = this.GetIID(this.sTemp2);
                    this.cmbCodeD.Text = this.GetIID(this.sTemp3);
                    this.cmbObject.Text = this.GetIID(this.sTemp4);
                    this.cmbProject.Text = this.GetIID(this.sTemp5);
                    this.cmbCodeG.Text = this.GetIID(this.sTemp6);
                    this.cmbCodeH.Text = this.GetIID(this.sTemp7);
                    this.cmbCodeI.Text = this.GetIID(this.sTemp8);
                    this.cmbCodeJ.Text = this.GetIID(this.sTemp9);
                    this.cmbQuantity.Text = this.GetIID(this.sTemp10);
                    this.cmbText.Text = this.GetIID(this.sTemp11);
                    this.cmbReqProcessCode.Text = this.GetIID(this.sTemp12);

                    this.cmbReqBudgetCodeB.Text = this.GetIID(this.sBudTemp1);
                    this.cmbReqBudgetCodeC.Text = this.GetIID(this.sBudTemp2);
                    this.cmbReqBudgetCodeD.Text = this.GetIID(this.sBudTemp3);
                    this.cmbReqBudgetCodeE.Text = this.GetIID(this.sBudTemp4);
                    this.cmbReqBudgetCodeF.Text = this.GetIID(this.sBudTemp5);
                    this.cmbReqBudgetCodeG.Text = this.GetIID(this.sBudTemp6);
                    this.cmbReqBudgetCodeH.Text = this.GetIID(this.sBudTemp7);
                    this.cmbReqBudgetCodeI.Text = this.GetIID(this.sBudTemp8);
                    this.cmbReqBudgetCodeJ.Text = this.GetIID(this.sBudTemp9);
                    this.cmbReqBudgetQuantity.Text = this.GetIID(this.sBudTemp10);

                    this.cmbCostCenter.EditDataItemSetEdited();
                    this.cmbCodeC.EditDataItemSetEdited();
                    this.cmbCodeD.EditDataItemSetEdited();
                    this.cmbObject.EditDataItemSetEdited();
                    this.cmbProject.EditDataItemSetEdited();
                    this.cmbCodeG.EditDataItemSetEdited();
                    this.cmbCodeH.EditDataItemSetEdited();
                    this.cmbCodeI.EditDataItemSetEdited();
                    this.cmbCodeJ.EditDataItemSetEdited();
                    this.cmbQuantity.EditDataItemSetEdited();
                    this.cmbText.EditDataItemSetEdited();
                    this.cmbReqProcessCode.EditDataItemSetEdited();

                    this.cmbReqBudgetCodeB.EditDataItemSetEdited();
                    this.cmbReqBudgetCodeC.EditDataItemSetEdited();
                    this.cmbReqBudgetCodeD.EditDataItemSetEdited();
                    this.cmbReqBudgetCodeE.EditDataItemSetEdited();
                    this.cmbReqBudgetCodeF.EditDataItemSetEdited();
                    this.cmbReqBudgetCodeG.EditDataItemSetEdited();
                    this.cmbReqBudgetCodeH.EditDataItemSetEdited();
                    this.cmbReqBudgetCodeI.EditDataItemSetEdited();
                    this.cmbReqBudgetCodeJ.EditDataItemSetEdited();
                    this.cmbReqBudgetQuantity.EditDataItemSetEdited();

                    this.dfsLogicalAccountType.EditDataItemSetEdited();

					if (this.dfsLogicalAccountType.Text == "A" || this.dfsLogicalAccountType.Text == "L" || this.dfsLogicalAccountType.Text == "O") 
					{
						Sal.EnableWindow(this.cbExcludeProjFollowup);						
					}
					else
					{
						Sal.DisableWindow(this.cbExcludeProjFollowup);						
					}
                    Sal.WaitCursor(false);
                    e.Return = Sys.VALIDATE_Ok;
                    return;
                }
                // Bug 85877, End
            }
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void cmbTaxHandlingValue_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.cmbTaxHandlingValue_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cmbTaxHandlingValue_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam) == Sys.VALIDATE_Cancel)
            {
                e.Return = Sys.VALIDATE_Cancel;
                return;
            }
            if (this.cmbTaxHandlingValue.Text != this.sPrevTaxHandlingValue)
            {
                if (this.cmbTaxHandlingValue.Text == taxHandlingValue.Decode("BLOCKED"))
                {
                    Sal.SendMsg(this.cbTaxCodeMandatory, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, ((SalString)"FALSE").ToHandle());
                }
            }
            this.sPrevTaxHandlingValue = this.cmbTaxHandlingValue.Text;
            e.Return = Sys.VALIDATE_Ok;
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void cbTaxCodeMandatory_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.cbTaxCodeMandatory_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cbTaxCodeMandatory_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.cmbTaxHandlingValue.Text == taxHandlingValue.Decode("BLOCKED"))
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
        private void cbTaxAccount_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_Create:
                    this.cbTaxAccount_OnSAM_Create(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.cbTaxAccount_OnPM_DataItemQueryEnabled(sender, e);
                    break;

                case Sys.SAM_Click:
                    this.cbTaxAccount_OnSAM_Click(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_Create event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cbTaxAccount_OnSAM_Create(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam))
            {
                this.cbTaxAccount.i_sCheckedValue = "Y";
                this.cbTaxAccount.i_sUncheckedValue = "N";
                e.Return = true;
                return;
            }
            e.Return = false;
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cbTaxAccount_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.cbBudAccount.Checked == true || this.cbStatisticalAccount.Checked == true)
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
        /// SAM_Click event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cbTaxAccount_OnSAM_Click(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            // Bug 85877, Begin, checked whether the chcek box is editable and return the SAM_Click back to framework
            if (Sal.SendMsg(this.cbTaxAccount.i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled, 0, 0) == Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldEnabled)
            {
                if (this.cbTaxAccount.Checked == true)
                {
                    if (this.cbBudAccount.Checked == false && this.cbStatisticalAccount.Checked == false)
                    {
                        Sal.SendMsg(this.cbLedgFlag, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, ((SalString)"Y").ToHandle());
                        Sal.SendMsg(this.cbTaxAccount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, ((SalString)"Y").ToHandle());
                    }
                }
                else
                {
                    Sal.SendMsg(this.cbTaxAccount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, ((SalString)"N").ToHandle());
                }
            }
            Sal.SendClassMessage(Sys.SAM_Click, Sys.wParam, Sys.lParam);
            // Bug 85877, End
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void cbLedgFlag_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_Create:
                    this.cbLedgFlag_OnSAM_Create(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.cbLedgFlag_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_Create event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cbLedgFlag_OnSAM_Create(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam))
            {
                this.cbLedgFlag.i_sCheckedValue = "Y";
                this.cbLedgFlag.i_sUncheckedValue = "N";
                e.Return = true;
                return;
            }
            e.Return = false;
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cbLedgFlag_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.cbBudAccount.Checked == true || this.cbStatisticalAccount.Checked == true)
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
        private void cbCurrBalance_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_Create:
                    this.cbCurrBalance_OnSAM_Create(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.cbCurrBalance_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_Create event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cbCurrBalance_OnSAM_Create(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam))
            {
                this.cbCurrBalance.i_sCheckedValue = "Y";
                this.cbCurrBalance.i_sUncheckedValue = "N";
                e.Return = true;
                return;
            }
            e.Return = false;
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cbCurrBalance_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.cbBudAccount.Checked == true)
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
        private void cbBudAccount_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_Create:
                    this.cbBudAccount_OnSAM_Create(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.cbBudAccount_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_Create event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cbBudAccount_OnSAM_Create(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam))
            {
                this.cbBudAccount.i_sCheckedValue = "Y";
                this.cbBudAccount.i_sUncheckedValue = "N";
                e.Return = true;
                return;
            }
            e.Return = false;
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cbBudAccount_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.cbLedgFlag.Checked == true || this.cbCurrBalance.Checked == true)
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
        private void cbStatisticalAccount_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_Create:
                    this.cbStatisticalAccount_OnSAM_Create(sender, e);
                    break;

                case Sys.SAM_Click:
                    this.cbStatisticalAccount_OnSAM_Click(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.cbStatisticalAccount_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_Create event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cbStatisticalAccount_OnSAM_Create(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam))
            {
                this.cbStatisticalAccount.i_sCheckedValue = "Y";
                this.cbStatisticalAccount.i_sUncheckedValue = "N";
                e.Return = true;
                return;
            }
            e.Return = false;
            return;
            #endregion
        }

        /// <summary>
        /// SAM_Click event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cbStatisticalAccount_OnSAM_Click(object sender, WindowActionsEventArgs e)
        {
            #region Local Variables
            SalString sFalseValue = "FALSE";
            #endregion

            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Sys.SAM_Click, Sys.wParam, Sys.lParam))
            {
                if (!cbStatisticalAccount.Checked)
                {
                    cbExcludeCurrTrans.Checked = false;
                    cbExcludeCurrTrans.EditDataItemValueSet(1, sFalseValue.ToHandle());
                    Sal.DisableWindow(cbExcludeCurrTrans);
                }
                else
                {
                    GetAccountConsolBalExist();
                    if ((this.dfsLogicalAccountType.Text == "S" || this.dfsLogicalAccountType.Text == "O") && (Ifs.Application.Accrul.Var.FinlibServices.IsMasterCompany(dfsCompany.Text) == "TRUE") && (cbStatisticalAccount.Checked) && (sAccountConsBalExist == "FALSE"))
                    {
                        Sal.EnableWindow(cbExcludeCurrTrans);
                        return;
                    }
                    else
                    {
                        Sal.DisableWindow(cbExcludeCurrTrans);
                        return;
                    }
                }
                e.Return = true;
                return;
            }
            e.Return = false;
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cbStatisticalAccount_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendMsg(this.dfsAccountType, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, 0, 0);
            if (this.cbLedgFlag.Checked == true || (this.dfsLogicalAccountType.Text != "S" && this.dfsLogicalAccountType.Text != "O"))
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
        private void mlsText_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_AnyEdit:
                    e.Handled = true;
                    Sal.SendMsg(this.cbFreeText, Const.PAM_AccntCheckUncheckCBText, 0, 0);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void cbCodeStr_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_Create:
                    this.cbCodeStr_OnSAM_Create(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_Create event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cbCodeStr_OnSAM_Create(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam))
            {
                this.cbCodeStr.i_sCheckedValue = "T";
                this.cbCodeStr.i_sUncheckedValue = "F";
                e.Return = true;
                return;
            }
            e.Return = false;
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void cbAttribute_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_Create:
                    this.cbAttribute_OnSAM_Create(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_Create event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cbAttribute_OnSAM_Create(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam))
            {
                this.cbAttribute.i_sCheckedValue = "T";
                this.cbAttribute.i_sUncheckedValue = "F";
                e.Return = true;
                return;
            }
            e.Return = false;
            return;
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
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemPopulate:
                    this.cbFreeText_OnPM_DataItemPopulate(sender, e);
                    break;

                case Const.PAM_AccntCheckUncheckCBText:
                    e.Handled = true;
                    this.cbFreeText.Checked = this.mlsText.Text != Ifs.Fnd.ApplicationForms.Const.strNULL;
                    break;

                case Ifs.Fnd.ApplicationForms.Const.WM_LBUTTONDBLCLK:
                    this.cbFreeText_OnWM_LBUTTONDBLCLK(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemPopulate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cbFreeText_OnPM_DataItemPopulate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemPopulate, Sys.wParam, Sys.lParam))
            {
                Sal.SendMsg(this.cbFreeText.i_hWndSelf, Const.PAM_AccntCheckUncheckCBText, 0, 0);
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
        /// WM_LBUTTONDBLCLK event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cbFreeText_OnWM_LBUTTONDBLCLK(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.WM_LBUTTONDBLCLK, Sys.wParam, Sys.lParam))
            {
                if (this.mlsText.EditDataItemStateGet() != Ifs.Fnd.ApplicationForms.Const.EDIT_Empty)
                {
                    e.Return = this.FreeText(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
                    return;
                }
            }
            e.Return = false;
			return;
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void cmbExcludePeriodicalCap_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.cmbExcludePeriodicalCap_OnPM_DataItemValidate(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// PM_DataItemPopulate event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cmbExcludePeriodicalCap_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam))
            {                 
                if ((Sal.ListQuerySelection(this.cmbExcludePeriodicalCap) > 0) && ((this.dfsLogicalAccountType.Text == "A" || this.dfsLogicalAccountType.Text == "L" || this.dfsLogicalAccountType.Text == "O" || this.dfsLogicalAccountType.Text == Sys.STRING_Null)))
                {
                    Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_PeriodicalCap, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                    Sal.ListSetSelect(this.cmbExcludePeriodicalCap, 0);
                    e.Return = Sys.VALIDATE_Cancel;
                    return;
                }
                else
                {
                    e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
                    return;
                }
            }			
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void cbExcludeProjFollowup_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemPopulate:
					this.cbExcludeProjFollowup_OnPM_DataItemPopulate(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// PM_DataItemPopulate event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cbExcludeProjFollowup_OnPM_DataItemPopulate(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (this.dfsLogicalAccountType.Text == "A" || this.dfsLogicalAccountType.Text == "L" || this.dfsLogicalAccountType.Text == "O") 
			{
				Sal.EnableWindow(this.cbExcludeProjFollowup);
			}
			else
			{
				Sal.DisableWindow(this.cbExcludeProjFollowup);
			}
			e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemPopulate, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }
        
        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void cmbCostCenter_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_LookupInit:
                    this.cmbCostCenter_OnPM_LookupInit(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_LookupInit event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cmbCostCenter_OnPM_LookupInit(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.sOldValue = this.cmbCostCenter.Text;
            this.bEditFlag = Sal.QueryFieldEdit(this.cmbCostCenter.i_hWndSelf);
            Sal.ListClear(this.cmbCostCenter.i_hWndSelf);
            Vis.ListArrayPopulate(this.cmbCostCenter.i_hWndSelf, this.EnumerateAccountRequest);
            Sal.SetWindowText(this.cmbCostCenter.i_hWndSelf, this.sOldValue);
            Sal.SetFieldEdit(this.cmbCostCenter.i_hWndSelf, this.bEditFlag);
            e.Return = true;
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void cmbCodeC_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_LookupInit:
                    this.cmbCodeC_OnPM_LookupInit(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_LookupInit event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cmbCodeC_OnPM_LookupInit(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.sOldValue = this.cmbCodeC.Text;
            this.bEditFlag = Sal.QueryFieldEdit(this.cmbCodeC.i_hWndSelf);
            Sal.ListClear(this.cmbCodeC.i_hWndSelf);
            Vis.ListArrayPopulate(this.cmbCodeC.i_hWndSelf, this.EnumerateAccountRequest);
            Sal.SetWindowText(this.cmbCodeC.i_hWndSelf, this.sOldValue);
            Sal.SetFieldEdit(this.cmbCodeC.i_hWndSelf, this.bEditFlag);
            e.Return = true;
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void cmbCodeD_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_LookupInit:
                    this.cmbCodeD_OnPM_LookupInit(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_LookupInit event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cmbCodeD_OnPM_LookupInit(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.sOldValue = this.cmbCodeD.Text;
            this.bEditFlag = Sal.QueryFieldEdit(this.cmbCodeD.i_hWndSelf);
            Sal.ListClear(this.cmbCodeD.i_hWndSelf);
            Vis.ListArrayPopulate(this.cmbCodeD.i_hWndSelf, this.EnumerateAccountRequest);
            Sal.SetWindowText(this.cmbCodeD.i_hWndSelf, this.sOldValue);
            Sal.SetFieldEdit(this.cmbCodeD.i_hWndSelf, this.bEditFlag);
            e.Return = true;
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void cmbObject_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_LookupInit:
                    this.cmbObject_OnPM_LookupInit(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_LookupInit event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cmbObject_OnPM_LookupInit(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.sOldValue = this.cmbObject.Text;
            this.bEditFlag = Sal.QueryFieldEdit(this.cmbObject.i_hWndSelf);
            Sal.ListClear(this.cmbObject.i_hWndSelf);
            Vis.ListArrayPopulate(this.cmbObject.i_hWndSelf, this.EnumerateAccountRequest);
            Sal.SetWindowText(this.cmbObject.i_hWndSelf, this.sOldValue);
            Sal.SetFieldEdit(this.cmbObject.i_hWndSelf, this.bEditFlag);
            e.Return = true;
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void cmbProject_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_LookupInit:
                    this.cmbProject_OnPM_LookupInit(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_LookupInit event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cmbProject_OnPM_LookupInit(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.sOldValue = this.cmbProject.Text;
            this.bEditFlag = Sal.QueryFieldEdit(this.cmbProject.i_hWndSelf);
            Sal.ListClear(this.cmbProject.i_hWndSelf);
            Vis.ListArrayPopulate(this.cmbProject.i_hWndSelf, this.EnumerateAccountRequest);
            Sal.SetWindowText(this.cmbProject.i_hWndSelf, this.sOldValue);
            Sal.SetFieldEdit(this.cmbProject.i_hWndSelf, this.bEditFlag);
            e.Return = true;
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void cmbCodeG_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_LookupInit:
                    this.cmbCodeG_OnPM_LookupInit(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_LookupInit event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cmbCodeG_OnPM_LookupInit(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.sOldValue = this.cmbCodeG.Text;
            this.bEditFlag = Sal.QueryFieldEdit(this.cmbCodeG.i_hWndSelf);
            Sal.ListClear(this.cmbCodeG.i_hWndSelf);
            Vis.ListArrayPopulate(this.cmbCodeG.i_hWndSelf, this.EnumerateAccountRequest);
            Sal.SetWindowText(this.cmbCodeG.i_hWndSelf, this.sOldValue);
            Sal.SetFieldEdit(this.cmbCodeG.i_hWndSelf, this.bEditFlag);
            e.Return = true;
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void cmbCodeH_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_LookupInit:
                    this.cmbCodeH_OnPM_LookupInit(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_LookupInit event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cmbCodeH_OnPM_LookupInit(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.sOldValue = this.cmbCodeH.Text;
            this.bEditFlag = Sal.QueryFieldEdit(this.cmbCodeH.i_hWndSelf);
            Sal.ListClear(this.cmbCodeH.i_hWndSelf);
            Vis.ListArrayPopulate(this.cmbCodeH.i_hWndSelf, this.EnumerateAccountRequest);
            Sal.SetWindowText(this.cmbCodeH.i_hWndSelf, this.sOldValue);
            Sal.SetFieldEdit(this.cmbCodeH.i_hWndSelf, this.bEditFlag);
            e.Return = true;
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void cmbCodeI_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_LookupInit:
                    this.cmbCodeI_OnPM_LookupInit(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_LookupInit event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cmbCodeI_OnPM_LookupInit(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.sOldValue = this.cmbCodeI.Text;
            this.bEditFlag = Sal.QueryFieldEdit(this.cmbCodeI.i_hWndSelf);
            Sal.ListClear(this.cmbCodeI.i_hWndSelf);
            Vis.ListArrayPopulate(this.cmbCodeI.i_hWndSelf, this.EnumerateAccountRequest);
            Sal.SetWindowText(this.cmbCodeI.i_hWndSelf, this.sOldValue);
            Sal.SetFieldEdit(this.cmbCodeI.i_hWndSelf, this.bEditFlag);
            e.Return = true;
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void cmbCodeJ_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_LookupInit:
                    this.cmbCodeJ_OnPM_LookupInit(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_LookupInit event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cmbCodeJ_OnPM_LookupInit(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.sOldValue = this.cmbCodeJ.Text;
            this.bEditFlag = Sal.QueryFieldEdit(this.cmbCodeJ.i_hWndSelf);
            Sal.ListClear(this.cmbCodeJ.i_hWndSelf);
            Vis.ListArrayPopulate(this.cmbCodeJ.i_hWndSelf, this.EnumerateAccountRequest);
            Sal.SetWindowText(this.cmbCodeJ.i_hWndSelf, this.sOldValue);
            Sal.SetFieldEdit(this.cmbCodeJ.i_hWndSelf, this.bEditFlag);
            e.Return = true;
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void cmbQuantity_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_LookupInit:
                    this.cmbQuantity_OnPM_LookupInit(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_LookupInit event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cmbQuantity_OnPM_LookupInit(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.sOldValue = this.cmbQuantity.Text;
            this.bEditFlag = Sal.QueryFieldEdit(this.cmbQuantity.i_hWndSelf);
            Sal.ListClear(this.cmbQuantity.i_hWndSelf);
            Vis.ListArrayPopulate(this.cmbQuantity.i_hWndSelf, this.EnumerateAccountRequest);
            Sal.SetWindowText(this.cmbQuantity.i_hWndSelf, this.sOldValue);
            Sal.SetFieldEdit(this.cmbQuantity.i_hWndSelf, this.bEditFlag);
            e.Return = true;
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void cmbReqProcessCode_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_LookupInit:
                    this.cmbReqProcessCode_OnPM_LookupInit(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_LookupInit event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cmbReqProcessCode_OnPM_LookupInit(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.sOldValue = this.cmbReqProcessCode.Text;
            this.bEditFlag = Sal.QueryFieldEdit(this.cmbReqProcessCode.i_hWndSelf);
            Sal.ListClear(this.cmbReqProcessCode.i_hWndSelf);
            Vis.ListArrayPopulate(this.cmbReqProcessCode.i_hWndSelf, this.EnumerateAccountRequest);
            Sal.SetWindowText(this.cmbReqProcessCode.i_hWndSelf, this.sOldValue);
            Sal.SetFieldEdit(this.cmbReqProcessCode.i_hWndSelf, this.bEditFlag);
            e.Return = true;
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void cmbText_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_LookupInit:
                    this.cmbText_OnPM_LookupInit(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_LookupInit event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cmbText_OnPM_LookupInit(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.sOldValue = this.cmbText.Text;
            this.bEditFlag = Sal.QueryFieldEdit(this.cmbText.i_hWndSelf);
            Sal.ListClear(this.cmbText.i_hWndSelf);
            Vis.ListArrayPopulate(this.cmbText.i_hWndSelf, this.EnumerateAccountRequestText);
            Sal.SetWindowText(this.cmbText.i_hWndSelf, this.sOldValue);
            Sal.SetFieldEdit(this.cmbText.i_hWndSelf, this.bEditFlag);
            e.Return = true;
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void dfsConsolidAccount_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_Validate:
                    this.dfsConsolidAccount_OnSAM_Validate(sender, e);
                    break;

                // Hery give this action because there would be a problem if data is NULL

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.dfsConsolidAccount_OnPM_DataItemValidate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemPopulate:
                    this.dfsConsolidAccount_OnPM_DataItemPopulate(sender, e);
                    break;

                // Hery ----- 11/12/96
            }
            #endregion
        }

        /// <summary>
        /// SAM_Validate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsConsolidAccount_OnSAM_Validate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Sys.SAM_Validate, Sys.wParam, Sys.lParam))
            {
                if (this.dfsConsolidAccount.Text == Ifs.Fnd.ApplicationForms.Const.strNULL)
                {
                    this.dfsConsolidAccntDescription.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                }
                e.Return = true;
                return;
            }
            e.Return = false;
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsConsolidAccount_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (!(Sal.IsNull(this.dfsConsolidAccount)))
            {
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("Account_API.Exist_", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                    hints.Add("Accounting_Code_Part_A_API.Get_Description", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                    if (!(this.dfsConsolidAccount.DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN " + cSessionManager.c_sDbPrefix + "Account_API.Exist_(:i_hWndFrame.frmTabAccount.dfConsCompany, :i_hWndFrame.frmTabAccount.dfsConsolidAccount) ;\r\n" +
                        "			:i_hWndFrame.frmTabAccount.dfsConsolidAccntDescription := " + cSessionManager.c_sDbPrefix + "Accounting_Code_Part_A_API.Get_Description(:i_hWndFrame.frmTabAccount.dfConsCompany,\r\n" +
                        "															          :i_hWndFrame.frmTabAccount.dfsConsolidAccount) ;\r\n		 END;")))
                    {
                        this.dfsConsolidAccntDescription.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                        e.Return = false;
                        return;
                    }
                }
            }
            else
            {
                Sal.ClearField(this.dfsConsolidAccntDescription);
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemPopulate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsConsolidAccount_OnPM_DataItemPopulate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemPopulate, Sys.wParam, Sys.lParam))
            {
                Sal.ClearField(this.dfsConsolidAccntDescription);
                if ((!(Sal.IsNull(this.dfsConsolidAccount))) && (!(Sal.IsNull(this.dfConsCompany))))
                {
                    if (!(this.dfsConsolidAccount.DbPrepareAndExecute(cSessionManager.c_hSql, "SELECT " + cSessionManager.c_sDbPrefix + "Accounting_Code_Part_A_API.Get_Description(:i_hWndFrame.frmTabAccount.dfConsCompany,\r\n" +
                        ":i_hWndFrame.frmTabAccount.dfsConsolidAccount) INTO :i_hWndFrame.frmTabAccount.dfsConsolidAccntDescription FROM Dual")))
                    {
                        e.Return = false;
                        return;
                    }
                    if (!(this.dfsConsolidAccount.DbFetchNext(cSessionManager.c_hSql, ref this.nIndex)))
                    {
                        e.Return = false;
                        return;
                    }
                }
                e.Return = true;
                return;
            }
            e.Return = false;
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void cmbReqBudgetCodeB_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_LookupInit:
                    this.cmbReqBudgetCodeB_OnPM_LookupInit(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_LookupInit event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cmbReqBudgetCodeB_OnPM_LookupInit(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.sOldValue = this.cmbReqBudgetCodeB.Text;
            this.bEditFlag = Sal.QueryFieldEdit(this.cmbReqBudgetCodeB.i_hWndSelf);
            Sal.ListClear(this.cmbReqBudgetCodeB.i_hWndSelf);
            Vis.ListArrayPopulate(this.cmbReqBudgetCodeB.i_hWndSelf, this.EnumerateAccountRequest);
            Sal.SetWindowText(this.cmbReqBudgetCodeB.i_hWndSelf, this.sOldValue);
            Sal.SetFieldEdit(this.cmbReqBudgetCodeB.i_hWndSelf, this.bEditFlag);
            e.Return = true;
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void cmbReqBudgetCodeC_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_LookupInit:
                    this.cmbReqBudgetCodeC_OnPM_LookupInit(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_LookupInit event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cmbReqBudgetCodeC_OnPM_LookupInit(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.sOldValue = this.cmbReqBudgetCodeC.Text;
            this.bEditFlag = Sal.QueryFieldEdit(this.cmbReqBudgetCodeC.i_hWndSelf);
            Sal.ListClear(this.cmbReqBudgetCodeC.i_hWndSelf);
            Vis.ListArrayPopulate(this.cmbReqBudgetCodeC.i_hWndSelf, this.EnumerateAccountRequest);
            Sal.SetWindowText(this.cmbReqBudgetCodeC.i_hWndSelf, this.sOldValue);
            Sal.SetFieldEdit(this.cmbReqBudgetCodeC.i_hWndSelf, this.bEditFlag);
            e.Return = true;
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void cmbReqBudgetCodeD_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_LookupInit:
                    this.cmbReqBudgetCodeD_OnPM_LookupInit(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_LookupInit event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cmbReqBudgetCodeD_OnPM_LookupInit(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.sOldValue = this.cmbReqBudgetCodeD.Text;
            this.bEditFlag = Sal.QueryFieldEdit(this.cmbReqBudgetCodeD.i_hWndSelf);
            Sal.ListClear(this.cmbReqBudgetCodeD.i_hWndSelf);
            Vis.ListArrayPopulate(this.cmbReqBudgetCodeD.i_hWndSelf, this.EnumerateAccountRequest);
            Sal.SetWindowText(this.cmbReqBudgetCodeD.i_hWndSelf, this.sOldValue);
            Sal.SetFieldEdit(this.cmbReqBudgetCodeD.i_hWndSelf, this.bEditFlag);
            e.Return = true;
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void cmbReqBudgetCodeE_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_LookupInit:
                    this.cmbReqBudgetCodeE_OnPM_LookupInit(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_LookupInit event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cmbReqBudgetCodeE_OnPM_LookupInit(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.sOldValue = this.cmbReqBudgetCodeE.Text;
            this.bEditFlag = Sal.QueryFieldEdit(this.cmbReqBudgetCodeE.i_hWndSelf);
            Sal.ListClear(this.cmbReqBudgetCodeE.i_hWndSelf);
            Vis.ListArrayPopulate(this.cmbReqBudgetCodeE.i_hWndSelf, this.EnumerateAccountRequest);
            Sal.SetWindowText(this.cmbReqBudgetCodeE.i_hWndSelf, this.sOldValue);
            Sal.SetFieldEdit(this.cmbReqBudgetCodeE.i_hWndSelf, this.bEditFlag);
            e.Return = true;
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void cmbReqBudgetCodeF_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_LookupInit:
                    this.cmbReqBudgetCodeF_OnPM_LookupInit(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_LookupInit event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cmbReqBudgetCodeF_OnPM_LookupInit(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.sOldValue = this.cmbReqBudgetCodeF.Text;
            this.bEditFlag = Sal.QueryFieldEdit(this.cmbReqBudgetCodeF.i_hWndSelf);
            Sal.ListClear(this.cmbReqBudgetCodeF.i_hWndSelf);
            Vis.ListArrayPopulate(this.cmbReqBudgetCodeF.i_hWndSelf, this.EnumerateAccountRequest);
            Sal.SetWindowText(this.cmbReqBudgetCodeF.i_hWndSelf, this.sOldValue);
            Sal.SetFieldEdit(this.cmbReqBudgetCodeF.i_hWndSelf, this.bEditFlag);
            e.Return = true;
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void cmbReqBudgetCodeG_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_LookupInit:
                    this.cmbReqBudgetCodeG_OnPM_LookupInit(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_LookupInit event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cmbReqBudgetCodeG_OnPM_LookupInit(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.sOldValue = this.cmbReqBudgetCodeG.Text;
            this.bEditFlag = Sal.QueryFieldEdit(this.cmbReqBudgetCodeG.i_hWndSelf);
            Sal.ListClear(this.cmbReqBudgetCodeG.i_hWndSelf);
            Vis.ListArrayPopulate(this.cmbReqBudgetCodeG.i_hWndSelf, this.EnumerateAccountRequest);
            Sal.SetWindowText(this.cmbReqBudgetCodeG.i_hWndSelf, this.sOldValue);
            Sal.SetFieldEdit(this.cmbReqBudgetCodeG.i_hWndSelf, this.bEditFlag);
            e.Return = true;
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void cmbReqBudgetCodeH_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_LookupInit:
                    this.cmbReqBudgetCodeH_OnPM_LookupInit(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_LookupInit event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cmbReqBudgetCodeH_OnPM_LookupInit(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.sOldValue = this.cmbReqBudgetCodeH.Text;
            this.bEditFlag = Sal.QueryFieldEdit(this.cmbReqBudgetCodeH.i_hWndSelf);
            Sal.ListClear(this.cmbReqBudgetCodeH.i_hWndSelf);
            Vis.ListArrayPopulate(this.cmbReqBudgetCodeH.i_hWndSelf, this.EnumerateAccountRequest);
            Sal.SetWindowText(this.cmbReqBudgetCodeH.i_hWndSelf, this.sOldValue);
            Sal.SetFieldEdit(this.cmbReqBudgetCodeH.i_hWndSelf, this.bEditFlag);
            e.Return = true;
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void cmbReqBudgetCodeI_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_LookupInit:
                    this.cmbReqBudgetCodeI_OnPM_LookupInit(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_LookupInit event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cmbReqBudgetCodeI_OnPM_LookupInit(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.sOldValue = this.cmbReqBudgetCodeI.Text;
            this.bEditFlag = Sal.QueryFieldEdit(this.cmbReqBudgetCodeI.i_hWndSelf);
            Sal.ListClear(this.cmbReqBudgetCodeI.i_hWndSelf);
            Vis.ListArrayPopulate(this.cmbReqBudgetCodeI.i_hWndSelf, this.EnumerateAccountRequest);
            Sal.SetWindowText(this.cmbReqBudgetCodeI.i_hWndSelf, this.sOldValue);
            Sal.SetFieldEdit(this.cmbReqBudgetCodeI.i_hWndSelf, this.bEditFlag);
            e.Return = true;
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void cmbReqBudgetCodeJ_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_LookupInit:
                    this.cmbReqBudgetCodeJ_OnPM_LookupInit(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_LookupInit event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cmbReqBudgetCodeJ_OnPM_LookupInit(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.sOldValue = this.cmbReqBudgetCodeJ.Text;
            this.bEditFlag = Sal.QueryFieldEdit(this.cmbReqBudgetCodeJ.i_hWndSelf);
            Sal.ListClear(this.cmbReqBudgetCodeJ.i_hWndSelf);
            Vis.ListArrayPopulate(this.cmbReqBudgetCodeJ.i_hWndSelf, this.EnumerateAccountRequest);
            Sal.SetWindowText(this.cmbReqBudgetCodeJ.i_hWndSelf, this.sOldValue);
            Sal.SetFieldEdit(this.cmbReqBudgetCodeJ.i_hWndSelf, this.bEditFlag);
            e.Return = true;
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void cmbReqBudgetQuantity_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_LookupInit:
                    this.cmbReqBudgetQuantity_OnPM_LookupInit(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_LookupInit event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cmbReqBudgetQuantity_OnPM_LookupInit(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.sOldValue = this.cmbReqBudgetQuantity.Text;
            this.bEditFlag = Sal.QueryFieldEdit(this.cmbReqBudgetQuantity.i_hWndSelf);
            Sal.ListClear(this.cmbReqBudgetQuantity.i_hWndSelf);
            Vis.ListArrayPopulate(this.cmbReqBudgetQuantity.i_hWndSelf, this.EnumerateAccountRequest);
            Sal.SetWindowText(this.cmbReqBudgetQuantity.i_hWndSelf, this.sOldValue);
            Sal.SetFieldEdit(this.cmbReqBudgetQuantity.i_hWndSelf, this.bEditFlag);
            e.Return = true;
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void rbAllTrans_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_Click:
                    this.rbAllTrans_OnSAM_Click(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_Click event handler.
        /// </summary>
        /// <param name="message"></param>
        private void rbAllTrans_OnSAM_Click(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            // Bug 85877, Begin, checked for the permission to edit the dfNoArchiveTrans
            if (Sal.SendMsg(this.dfNoArchiveTrans, Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled, 0, 0) == Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldEnabled)
            {
                this.dfNoArchiveTrans.Text = "FALSE";
                this.dfNoArchiveTrans.EditDataItemSetEdited();
            }
            // Bug 85877, End
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void rbMatchedTrans_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_Click:
                    this.rbMatchedTrans_OnSAM_Click(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_Click event handler.
        /// </summary>
        /// <param name="message"></param>
        private void rbMatchedTrans_OnSAM_Click(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            // Bug 85877, Begin, checked for the permission to edit the dfNoArchiveTrans
            if (Sal.SendMsg(this.dfNoArchiveTrans, Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled, 0, 0) == Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldEnabled)
            {
                this.dfNoArchiveTrans.Text = "TRUE";
                this.dfNoArchiveTrans.EditDataItemSetEdited();
            }
            // Bug 85877, End
            #endregion
        }

        private void cbExcludeCurrTrans_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.cbExcludeCurrTrans_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cbExcludeCurrTrans_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Local Variables
            SalNumber nClassMessageReturn;
            #endregion

            #region Actions
            e.Handled = true;
            Sal.SendMsg(this.dfsAccountType, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, 0, 0);
            nClassMessageReturn = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled, Sys.wParam, Sys.lParam);
            if (nClassMessageReturn == Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldEnabled)
            {
                if ((this.dfsLogicalAccountType.Text == "S" || this.dfsLogicalAccountType.Text == "O") && (Ifs.Application.Accrul.Var.FinlibServices.IsMasterCompany(dfsCompany.Text) == "TRUE") && (cbStatisticalAccount.Checked) && (sAccountConsBalExist == "FALSE"))
                {
                    e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldEnabled;
                    return;
                }
                else
                {
                    e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                    return;
                }
            }
            else
            {
                e.Return = nClassMessageReturn;
                return;
            }
            #endregion
        }

        #endregion

        #region Late Bind Methods

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalBoolean vrtDataRecordGetDefaults()
        {
            return this.DataRecordGetDefaults();
        }

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalNumber vrtDataRecordQueryDialog()
        {
            return this.DataRecordQueryDialog();
        }

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalNumber vrtDataSourcePrepareKeyTransfer(SalString sWindowName)
        {
            return this.DataSourcePrepareKeyTransfer(sWindowName);
        }

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalBoolean vrtFrameStartupUser()
        {
            return this.FrameStartupUser();
        }

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalString vrtGetWindowTitle()
        {
            return this.GetWindowTitle();
        }
        #endregion

        #region Event Handlers

        private void menuItem_Code_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = CodestrCompl(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem_Code_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            CodestrCompl(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem__Tax_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = TaxCodePerAccount(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem__Tax_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            TaxCodePerAccount(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem__Code_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = ConnectAttribute(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem__Code_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            ConnectAttribute(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem__Project_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = ConnProjectCostElement(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem__Project_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            ConnProjectCostElement(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem_Translation_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = Translation(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem_Translation_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            Translation(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem__Notes_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = FreeText(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem__Notes_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            FreeText(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem_Change_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = Sal.SendClassMessage(Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Sys.lParam);
        }

        private void menuItem_Change_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            Sal.SendClassMessage(Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Sys.lParam);
        }

        #endregion

        #region Properties

        protected SalArray<SalString> EnumerateAccountRequest
        {
            get
            {
                SalArray<SalString> temp = new SalArray<SalString>();
                foreach (string clientValue in accountRequest.ClientValues)
                    temp.Add(clientValue);   

                return temp;
            }
        }

        protected SalArray<SalString> EnumerateAccountRequestText
        {
            get
            {
                SalArray<SalString> temp = new SalArray<SalString>();
                foreach (string clientValue in accountRequestText.ClientValues)
                    temp.Add(clientValue);

                return temp;
            }
        }

        #endregion
    }
}
