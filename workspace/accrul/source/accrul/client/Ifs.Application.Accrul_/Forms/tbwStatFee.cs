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
    [FndWindowRegistration("STATUTORY_FEE_DEDUCTIBLE, STATUTORY_FEE, STATUTORY_FEE_NON_VAT, STATUTORY_FEE_NON_RDE_MULTIPLE, STATUTORY_FEE_TAX_WITHHOLD, STATUTORY_FEE_DEDUCT_MULTIPLE", "StatutoryFee", FndWindowRegistrationFlags.HomePage)]
    [FndWindowRegistration("STATUTORY_FEE_MULTIPLE", "StatutoryFee", FndWindowRegistrationFlags.HomePage | FndWindowRegistrationFlags.NoSecurity)]
    public partial class tbwStatFee : cTableWindowFin
    {
        #region Window Variables
        public SalArray<SalString> sPlaceHolders = new SalArray<SalString>();
        public SalString sCompanyName = "";
        public SalArray<SalString> sChanges = new SalArray<SalString>();
        public SalString sID = "";
        public SalNumber nNumChanges = 0;
        public SalString sVat = "";
        public SalString sTaxWithhold = "";
        public SalString sRDE = "";
        public SalString sSaleTx = "";
        public SalString sUseTx = "";
        public SalString sTemp = "";
        public SalString sModule = "";
        public SalString sLu = "";
        public SalString lsAttribute = "";
        public SalString sCompTaxAmtLimit = "";
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public tbwStatFee()
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
        public new static tbwStatFee FromHandle(SalWindowHandle handle)
        {
            return ((tbwStatFee)SalWindow.FromHandle(handle, typeof(tbwStatFee)));
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
                return Properties.Resources.WH_tbwStatFee;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalNumber Translation(SalNumber nWhat)
        {
            #region Local Variables
            SalNumber nRow = 0;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        Sal.WaitCursor(true);
                        sModule = "ACCRUL";
                        sLu = "StatutoryFee";
                        lsAttribute = Ifs.Fnd.ApplicationForms.Const.strNULL;
                        nRow = Sys.TBL_MinRow;
                        while (true)
                        {
                            if (Sal.TblFindNextRow(this, ref nRow, Sys.ROW_Selected, 0))
                            {
                                Sal.TblSetContext(this, nRow);
                                lsAttribute = lsAttribute + "'" + colFeeCode.Text + "'" + ",";
                            }
                            else
                            {
                                break;
                            }
                        }
                        if (lsAttribute != Ifs.Fnd.ApplicationForms.Const.strNULL)
                        {
                            lsAttribute = lsAttribute.Left(lsAttribute.Length - 1);
                        }
                        Ifs.Fnd.ApplicationForms.Var.Cache.SessionStore("TRANSLATE_COMPANY", i_sCompany);
                        Ifs.Fnd.ApplicationForms.Var.Cache.SessionStore("TRANSLATE_MODULE", sModule);
                        Ifs.Fnd.ApplicationForms.Var.Cache.SessionStore("TRANSLATE_LU", sLu);
                        Ifs.Fnd.ApplicationForms.Var.Cache.SessionStore("TRANSLATE_ATTRIBUTE", lsAttribute);
                        SessionCreateWindow(Pal.GetActiveInstanceName("frmCompanyTranslation"), Sys.hWndMDI);
                        Sal.WaitCursor(false);
                        return 1;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        return !(Sal.SendMsg(i_hWndFrame, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0)) && Ifs.Fnd.ApplicationForms.Var.Component.IsWindowAvailable(Pal.GetActiveInstanceName("frmCompanyTranslation")) && Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(
                            Pal.GetActiveInstanceName("frmCompanyTranslation"));
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// Applications should return FALSE to skip standard window startup logic (such
        /// as exectuing the "startup behavior" settings), or TRUE to allow standard logic.
        /// </returns>
        public new SalBoolean FrameStartupUser()
        {
            #region Local Variables
            SalNumber nRC = 0;
            SalNumber nItemIndex = 0;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                GetWindowTitle();
                // Insert new code here...
                TaxDecode();
                Sal.WaitCursor(false);
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
            SalNumber nRC = 0;
            SalNumber nItemIndex = 0;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.RecCountGet() > 0)
                {
                    if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.TypeGet() == "ZOOM")
                    {
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.i_sItemNames[0] = "FEE_CODE";
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.i_sItemNames[1] = "COMPANY";
                    }
                    nItemIndex = Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemIndexGet("COMPANY");
                    if (nItemIndex >= 0)
                    {
                        nRC = Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemValueStrGet(nItemIndex, 0, ref i_sCompany);
                    }
                    SetCompany(i_sCompany);
                    if (InitFromTransferredData())
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();
                    Sal.WaitCursor(false);
                    return false;
                }
                Sal.WaitCursor(false);
                CompanyTaxAmtLimit();
                return base.Activate(URL);
            }
            #endregion

        }

        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalBoolean TaxTextsPerTaxCode(SalNumber nWhat)
        {
            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        if (!(Sal.TblAnyRows(this, Sys.ROW_Selected, 0)))
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                        goto case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceCreateWindow, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, ((SalString)Pal.GetActiveInstanceName("tbwTaxCodeTexts")).ToHandle());
                        return true;
                }
            }

            return false;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="sWindowName"></param>
        /// <returns></returns>
        public new SalNumber DataSourcePrepareKeyTransfer(SalString sWindowName)
        {
            #region Local Variables
            SalArray<SalString> sItemNames = new SalArray<SalString>();
            SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                if (sWindowName == Pal.GetActiveInstanceName("tbwTaxCodeTexts"))
                {
                    sItemNames[0] = "COMPANY";
                    hWndItems[0] = colCompany;
                    sItemNames[0] = "FEE_CODE";
                    hWndItems[0] = colFeeCode;
                }
                else
                {
                    return ((cDataSource)this).DataSourcePrepareKeyTransfer(sWindowName);
                }
                Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init(sWindowName, this, sItemNames, hWndItems);
                Ifs.Fnd.ApplicationForms.Var.DataTransfer.TypeSet("CREATE_WINDOW");
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalBoolean Details(SalNumber nWhat)
        {
            #region Local Variables
            SalArray<SalString> sItemNames = new SalArray<SalString>();
            SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
            SalNumber nMyCurrentRow = 0;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        nMyCurrentRow = Sys.TBL_MinRow;
                        if (Sal.TblFindNextRow(i_hWndSelf, ref nMyCurrentRow, Sys.ROW_Selected, 0))
                        {
                            Sal.TblSetContext(i_hWndSelf, nMyCurrentRow);
                            if (Sal.TblFindNextRow(i_hWndSelf, ref nMyCurrentRow, Sys.ROW_Selected, 0))
                            {
                                return false;
                            }
                            else
                            {
                                if (colsFeeTypeDb.Text == Ifs.Fnd.ApplicationForms.Const.strNULL)
                                {
                                    SetFeeTypeDb();
                                }
                                if ((colsFeeTypeDb.Text == "VAT") || (colsFeeTypeDb.Text == "SALETX"))
                                {
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                        }
                        else
                        {
                            return false;
                        }
                        goto case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        sItemNames[0] = "FEE_CODE";
                        hWndItems[0] = colFeeCode;
                        sItemNames[1] = "COMPANY";
                        hWndItems[1] = colCompany;
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("StatutoryFee", this, sItemNames, hWndItems);
                        SessionCreateWindow(Pal.GetActiveInstanceName("frmStatFeeDetail"), Sys.hWndMDI);
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
        public virtual SalBoolean TaxWithholding(SalNumber nWhat)
        {
            #region Local Variables
            SalArray<SalString> sItemNames = new SalArray<SalString>();
            SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
            SalNumber nMyCurrentRow = 0;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        nMyCurrentRow = Sys.TBL_MinRow;
                        if (Sal.TblFindNextRow(i_hWndSelf, ref nMyCurrentRow, Sys.ROW_Selected, 0))
                        {
                            Sal.TblSetContext(i_hWndSelf, nMyCurrentRow);
                            if (Sal.TblFindNextRow(i_hWndSelf, ref nMyCurrentRow, Sys.ROW_Selected, 0))
                            {
                                return false;
                            }
                            else
                            {
                                // The row should not be in edit mode
                                if (Sal.TblQueryRowFlags(i_hWndSelf, Sal.TblQueryContext(i_hWndSelf), (Sys.ROW_Edited | Sys.ROW_MarkDeleted)))
                                {
                                    return false;
                                }
                                if (colFeeType.Text == sTaxWithhold)
                                {
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                        }
                        else
                        {
                            return false;
                        }
                        goto case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        sItemNames[0] = "FEE_CODE";
                        hWndItems[0] = colFeeCode;
                        sItemNames[1] = "COMPANY";
                        hWndItems[1] = colCompany;
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("StatutoryFee", this, sItemNames, hWndItems);
                        SessionCreateWindow(Pal.GetActiveInstanceName("tbwTaxWithhold"), Sys.hWndMDI);
                        break;
                }
            }

            return false;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean CheckPossibility()
        {
            #region Actions
            using (new SalContext(this))
            {
                if (colFeeType.Text == sVat)
                {
                    return false;
                }
                else if (colFeeType.Text == sTaxWithhold)
                {
                    return false;
                }
                else if (colFeeType.Text == sRDE)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber TaxDecode()
        {
            #region Actions
            using (new SalContext(this))
            {
                sVat = SalString.Null;
                sTaxWithhold = SalString.Null;
                sRDE = SalString.Null;
                // Bug 73500, Begin, Merged the DbBlocks
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("FEE_TYPE_API.Decode", System.Data.ParameterDirection.Input);
                    DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN\r\n" +
                        "				:i_hWndFrame.tbwStatFee.sVat :=" + cSessionManager.c_sDbPrefix + "FEE_TYPE_API.Decode('VAT');\r\n" +
                        "				:i_hWndFrame.tbwStatFee.sTaxWithhold :=" + cSessionManager.c_sDbPrefix + "FEE_TYPE_API.Decode('IRS1099TX');\r\n" +
                        "				:i_hWndFrame.tbwStatFee.sRDE :=" + cSessionManager.c_sDbPrefix + "FEE_TYPE_API.Decode('RDE');\r\n" +
                        "				:i_hWndFrame.tbwStatFee.sSaleTx :=" + cSessionManager.c_sDbPrefix + "FEE_TYPE_API.Decode('SALETX');\r\n" +
                        "				:i_hWndFrame.tbwStatFee.sUseTx :=" + cSessionManager.c_sDbPrefix + "FEE_TYPE_API.Decode('USETX');\r\n			END;");
                }
                // Bug 73500, End
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber CompanyTaxAmtLimit()
        {
            #region Actions
            using (new SalContext(this))
            {
                this.sCompTaxAmtLimit = SalString.Null;
                this.sCompanyName = i_sCompany;
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("STATUTORY_FEE_API.Get_Comp_Tax_Amt_Limit_Lines", System.Data.ParameterDirection.Input);
                    DbPLSQLBlock(cSessionManager.c_hSql, ":i_hWndFrame.tbwStatFee.sCompTaxAmtLimit := &AO.STATUTORY_FEE_API.Get_Comp_Tax_Amt_Limit_Lines(:i_hWndFrame.tbwStatFee.sCompanyName)");
                }
            }

            return 0;
            #endregion
        }
        // Bug 86773, Begin
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean CheckTaxType()
        {
            #region Actions
            using (new SalContext(this))
            {
                if (colFeeType.Text == "Sales Tax")
                {
                    return true;
                }
                if (colFeeType.Text == "Use Tax")
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
        public virtual SalBoolean CheckTaxRepCat()
        {
            #region Actions
            using (new SalContext(this))
            {
                if (colTaxReportingCategory.Text == "EU Services")
                {
                    return true;
                }
                if (colTaxReportingCategory.Text == "Tripartite EU Trade")
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

        public virtual void SetFeeTypeDb()
        {
            #region Actions
            if (DbPLSQLBlock(cSessionManager.c_hSql, ":i_hWndFrame.tbwStatFee.colsFeeTypeDb := &AO.STATUTORY_FEE_API.Get_Fee_Type_Db(:i_hWndFrame.tbwStatFee.colCompany, :i_hWndFrame.tbwStatFee.colFeeCode)"))
            {
                return;
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
        private void tbwStatFee_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordDuplicate:
                    this.tbwStatFee_OnPM_DataRecordDuplicate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew:
                    this.tbwStatFee_OnPM_DataRecordNew(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate:
                    this.tbwStatFee_OnPM_DataSourcePopulate(sender, e);
                    break;

                // Bug 86773, Begin

                case Sys.SAM_AnyEdit:
                    this.tbwStatFee_OnSAM_AnyEdit(sender, e);
                    break;

                // Bug 86773, End
            }
            #endregion
        }

        /// <summary>
        /// PM_DataRecordDuplicate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwStatFee_OnPM_DataRecordDuplicate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                // Bug 89816 - Removed bRowDuplicate
                if (this.sCompTaxAmtLimit != "TRUE")
                {
                    Sal.DisableWindow(this.colTaxAmountLimit);
                }
                else
                {
                    Sal.EnableWindow(this.colTaxAmountLimit);
                }
                e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordDuplicate, Sys.wParam, Sys.lParam);
                return;
            }
            else
            {
                e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordDuplicate, Sys.wParam, Sys.lParam);
                return;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataRecordNew event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwStatFee_OnPM_DataRecordNew(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                // Bug 89816 - Removed bRowDuplicate
                if (this.sCompTaxAmtLimit != "TRUE")
                {
                    Sal.DisableWindow(this.colTaxAmountLimit);
                }
                else
                {
                    Sal.EnableWindow(this.colTaxAmountLimit);
                }
                if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew, Sys.wParam, Sys.lParam))
                {
                    Sal.SendMsg(tbwStatFee.FromHandle(this.i_hWndFrame).colValidFrom, Ifs.Fnd.ApplicationForms.Const.PAM_User, 0, 0);
                }
            }
            else
            {
                e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew, Sys.wParam, Sys.lParam);
                return;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataSourcePopulate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwStatFee_OnPM_DataSourcePopulate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                if (this.sCompTaxAmtLimit != "TRUE")
                {
                    Sal.DisableWindow(this.colTaxAmountLimit);
                }
                else
                {
                    Sal.EnableWindow(this.colTaxAmountLimit);
                }
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// SAM_AnyEdit event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwStatFee_OnSAM_AnyEdit(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.colTaxReportingCategory.Text == Ifs.Fnd.ApplicationForms.Const.strNULL)
            {
                this.colTaxReportingCategory.Text = " ";
            }
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colValidFrom_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PAM_User:
                    this.colValidFrom_OnPAM_User(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PAM_User event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colValidFrom_OnPAM_User(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.colValidFrom.DateTime = SalDateTime.Current;
            this.colValidFrom.EditDataItemSetEdited();
            e.Return = true;
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colFeeType_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                // Bug 86773, Begin

                case Sys.SAM_DropDown:
                    this.colFeeType_OnSAM_DropDown(sender, e);
                    break;

                // Bug 86773, End
            }
            #endregion
        }

        /// <summary>
        /// SAM_DropDown event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colFeeType_OnSAM_DropDown(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.CheckTaxRepCat())
            {
                this.colFeeType.LookupInit();
                Sal.ListDelete(this.colFeeType.i_hWndSelf, 3);
                if (this.colTaxReportingCategory.Text == "EU Services")
                {
                    Sal.ListDelete(this.colFeeType.i_hWndSelf, 2);
                }
                else if (this.colTaxReportingCategory.Text == "Tripartite EU Trade")
                {
                    Sal.ListDelete(this.colFeeType.i_hWndSelf, 2);
                }
                e.Return = true;
                return;
            }
            else
            {
                e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_LookupInit, Sys.wParam, Sys.lParam);
                return;
            }
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colsVatReceived_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_DropDown:
                    this.colsVatReceived_OnSAM_DropDown(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_DropDown event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colsVatReceived_OnSAM_DropDown(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.CheckPossibility())
            {
                this.colsVatReceived.LookupInit();
                if (this.colFeeType.Text == this.sSaleTx)
                {
                    Sal.ListDelete(this.colsVatReceived.i_hWndSelf, 1);
                }
                else if (this.colFeeType.Text == this.sUseTx)
                {
                    Sal.ListDelete(this.colsVatReceived.i_hWndSelf, 1);
                }
                e.Return = true;
                return;
            }
            else
            {
                e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_LookupInit, Sys.wParam, Sys.lParam);
                return;
            }
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colsVatDisbursed_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_LookupInit:
                    this.colsVatDisbursed_OnPM_LookupInit(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_LookupInit event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colsVatDisbursed_OnPM_LookupInit(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_LookupInit, Sys.wParam, Sys.lParam);
            // Bug 83771, start
            Sal.ListDelete(this.colsVatDisbursed, 1);
            // Bug 83771, end
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colTaxReportingCategory_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_DropDown:
                    this.colTaxReportingCategory_OnSAM_DropDown(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_DropDown event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colTaxReportingCategory_OnSAM_DropDown(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.CheckTaxType())
            {
                this.colTaxReportingCategory.LookupInit();
                Sal.ListDelete(this.colTaxReportingCategory.i_hWndSelf, 2);
                if (this.colFeeType.Text == "Sales Tax")
                {
                    Sal.ListDelete(this.colTaxReportingCategory.i_hWndSelf, 1);
                }
                else if (this.colFeeType.Text == "Use Tax")
                {
                    Sal.ListDelete(this.colTaxReportingCategory.i_hWndSelf, 1);
                }
                e.Return = true;
                return;
            }
            else
            {
                e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_LookupInit, Sys.wParam, Sys.lParam);
                return;
            }
            #endregion
        }
        #endregion

        #region Late Bind Methods

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

        private void menuItem__Details_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = Details(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire) && Ifs.Fnd.ApplicationForms.Var.Security.IsPresObjectAvailable(Pal.GetActiveInstanceName("frmStatFeeDetail"));
        }

        private void menuItem__Details_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            Details(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem__Translation_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = Translation(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem__Translation_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            Translation(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem__Tax_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = TaxTextsPerTaxCode(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem__Tax_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            TaxTextsPerTaxCode(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem__Tax_1_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = TaxWithholding(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire) && Ifs.Fnd.ApplicationForms.Var.Security.IsPresObjectAvailable(Pal.GetActiveInstanceName("tbwTaxWithhold"));
        }

        private void menuItem__Tax_1_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            TaxWithholding(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem__Change_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Sys.lParam);
        }

        private void menuItem__Change_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Sys.lParam);
            CompanyTaxAmtLimit();
        }

        private void menuItem__Translation_1_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = Translation(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem__Translation_1_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            Translation(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem__Tax_2_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = TaxWithholding(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire) && Ifs.Fnd.ApplicationForms.Var.Security.IsPresObjectAvailable(Pal.GetActiveInstanceName("tbwTaxWithhold"));
        }

        private void menuItem__Tax_2_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            TaxWithholding(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem__Change_1_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Sys.lParam);
        }

        private void menuItem__Change_1_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Sys.lParam);
            CompanyTaxAmtLimit();
        }

        #endregion

    }
}
