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
// DATE          BY        NOTES
// YYYY-MM-DD
// 2012-11-01    Mawelk    Corrected Bug Id 106148, Modified ClearBlockedCodeParts().  
// 2012-11-07    Kagalk    Bug 106222, Restricted currency rate modification for accounting currency.
// 2013-02-05    Kagalk    Bug 106860, Merged.
// 2014-04-18    Nirylk    PBFI-5614,Merged bug 100161. Subscribed to WindowActions of tblVouTemplateRow_colsDeliveryTypeId
// 2014-05-13    Hecolk    PBFI-7498, Corrected filtering of Activity Sequence per Project Id in LOV and Refreshing of record even after a failed Save.      
// 2014-05-13    Hecolk    PBFI-7499, Changed LOV view for Activity sequence from PROJECT_ACTIVITY to PROJECT_ACTIVITY_POSTABLE
// 2014-05-22    Hecolk    PBFI-7504, Added check for Multiple and RDE tax codes in the validation of Tax code in postings
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
using System.Collections.Generic;

namespace Ifs.Application.Accrul_
{
	
	/// <summary>
	/// </summary>
    [FndWindowRegistration("VOUCHER_TEMPLATE", "VoucherTemplate", FndWindowRegistrationFlags.HomePage)]
    public partial class frmVouTemplate : cFormWindowFin
    {
        #region Window Variables
        public SalNumber nConvertionFactorSave = 0;
        public SalNumber nIndex = 0;
        public SalNumber nDecimalsInAmount = 0;
        public SalNumber nAccDecimalsInAmount = 0;
        public SalNumber nDummy = 0;
        public SalString sIsProjectCodePart = "";
        public SalString sDummyCodePart = "";
        public SalString sIsProjectExternallyCreated = "";
        public SalString sTempAccnt = "";
        public SalString sCodePart = "";
        public SalString sTemp = "";
        public SalString sPseudoCodeUser = "";
        public SalArray<SalString> sRecords = new SalArray<SalString>();
        public SalArray<SalString> sUnits = new SalArray<SalString>();
        // Insert new code here...
        public SalArray<SalString> sUserNameArr = new SalArray<SalString>();
        public SalString lsCurrencyCode = "";
        public SalString lsStmt = "";
        public SalString lsTemp = "";
        public SalString lsTemp1 = "";
        public SalString sMultipleTax = "";
        public SalString sTaxType = "";
        public SalNumber nDeduct = 0;
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public frmVouTemplate()
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
        public new static frmVouTemplate FromHandle(SalWindowHandle handle)
        {
            return ((frmVouTemplate)SalWindow.FromHandle(handle, typeof(frmVouTemplate)));
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
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                // Insert new code here...
                sIsProjectCodePart = GetCodePartFunction("PRACC");
                return true;
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
        private void frmVouTemplate_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew:
                    this.frmVouTemplate_OnPM_DataRecordNew(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate:
                    this.frmVouTemplate_OnPM_DataSourcePopulate(sender, e);
                    break;
                // Bug 106222, Begin
                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave:
                    this.frmVouTemplate_OnPM_DataSourceSave(sender, e);
                    break;
                // Bug 106222, End
            }
            #endregion
        }

        /// <summary>
        /// PM_DataRecordNew event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmVouTemplate_OnPM_DataRecordNew(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew, Sys.wParam, Sys.lParam))
            {
                if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
                {
                    using (SignatureHints hints = SignatureHints.NewContext())
                    {
                        hints.Add("CURRENCY_TYPE_API.Get_Default_Type", System.Data.ParameterDirection.Input);
                        hints.Add("Company_Finance_API.Get_Currency_Code", System.Data.ParameterDirection.Input);
                        hints.Add("CURRENCY_CODE_API.No_Of_Decimals_In_Rate_", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                        if (!(this.DbPLSQLBlock(cSessionManager.c_hSql, "DECLARE " + "CurrencyCode_ 	VARCHAR2(20); " + " BEGIN" + " :i_hWndFrame.frmVouTemplate.dfsCurrencyType     := substr(" + cSessionManager.c_sDbPrefix + "CURRENCY_TYPE_API.Get_Default_Type(:i_hWndFrame.frmVouTemplate.i_sCompany),1,10);" +
                            " CurrencyCode_    			      := substr(" + cSessionManager.c_sDbPrefix + "Company_Finance_API.Get_Currency_Code(:i_hWndFrame.frmVouTemplate.i_sCompany ),1,20);" + " :i_hWndFrame.frmVouTemplate.dfsCurrencyCode     := CurrencyCode_; " + " :i_hWndFrame.frmVouTemplate.dfsDecimalsInRate  := NVL( " +
                            cSessionManager.c_sDbPrefix + "CURRENCY_CODE_API.No_Of_Decimals_In_Rate_(:i_hWndFrame.frmVouTemplate.i_sCompany, CurrencyCode_),0); " + " END;")))
                        {
                            e.Return = false;
                            return;
                        }
                    }
                    this.GetAttributes(this.dfsCompany.Text, this.dfsCurrencyCode.Text, this.dfsCurrencyCode.Text, this.dfsCurrencyType.Text, this.dfdValidFrom.DateTime);
                    this.dfsCurrencyRate.Number = this.GetRate(this.dfsCompany.Text, this.dfsCurrencyCode.Text);
                    this.dfnConvFactor.Number = frmVouTemplate.FromHandle(this.i_hWndFrame).i_nFinConversionFactor;
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
        /// PM_DataSourcePopulate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmVouTemplate_OnPM_DataSourcePopulate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                this.dfCodePartValue.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                this.dfCodePartDescription.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Sys.wParam, Sys.lParam);
                return;
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        // Bug 106222, Begin
        private void frmVouTemplate_OnPM_DataSourceSave(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Sys.wParam, Sys.lParam);
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute && e.Return == 1)
            {
                Sal.SendMsg(i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceRefresh, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
            }
            return;
            #endregion
        }
        // Bug 106222, End

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void cbCorrection_WindowActions(object sender, WindowActionsEventArgs e)
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
        // Insert new code here...
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public override SalNumber vrtActivate(fcURL URL)
        {
            using (new SalContext(this))
            {
                if (this.i_bCompanyChangedFin)
                {
                    Sal.SendMsg(this.tblVouTemplateRow, Ifs.Application.Accrul.Const.PAM_CallChanged, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                    i_bCompanyChangedFin = false;
                }
                this.cbCorrection.i_sCheckedValue = "Y";
                this.cbCorrection.i_sUncheckedValue = "N";
                sIsProjectCodePart = GetCodePartFunction("PRACC");
            }
            return base.Activate(URL);
        }

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
                    if (!(this.dfsCurrencyType.DbPLSQLBlock(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "Currency_Type_API.Exist( :i_hWndFrame.frmVouTemplate.dfsCompany,\r\n" +
                        ":i_hWndFrame.frmVouTemplate.dfsCurrencyType )")))
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
        private void tblVouTemplateRow_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew:
                    this.tblVouTemplateRow_OnPM_DataRecordNew(sender, e);
                    break;

                case Sys.SAM_FetchRowDone:
                    this.tblVouTemplateRow_OnSAM_FetchRowDone(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordDuplicate:
                    this.tblVouTemplateRow_OnPM_DataRecordDuplicate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove:
                    this.tblVouTemplateRow_OnPM_DataRecordRemove(sender, e);
                    break;

                case Ifs.Application.Accrul.Const.PAM_CallChanged:
                    e.Handled = true;
                    if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
                    {
                        this.tblVouTemplateRow.nInit = 0;
                        cFinlibServices.nCodePartNameCount = 0;
                    }
                    e.Return = Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_CallChanged, Sys.wParam, Sys.lParam);
                    return;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataRecordNew event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVouTemplateRow_OnPM_DataRecordNew(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew, Sys.wParam, Sys.lParam))
            {
                if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
                {
                    if (Sal.IsNull(frmVouTemplate.FromHandle(this.tblVouTemplateRow.i_hWndFrame).cmbTemplate))
                    {
                        Ifs.Fnd.ApplicationForms.Int.AlertBox("Template must have a value", Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
                        Sal.SetFocus(frmVouTemplate.FromHandle(this.tblVouTemplateRow.i_hWndFrame).cmbTemplate);
                    }
                    if (frmVouTemplate.FromHandle(this.tblVouTemplateRow.i_hWndFrame).cbCorrection.Checked)
                    {
                        this.tblVouTemplateRow_colsCorrection.Text = "Y";
                    }
                    else
                    {
                        this.tblVouTemplateRow_colsCorrection.Text = "N";
                    }
                    string sStatment = string.Format(@" {0}:= &AO.CURRENCY_CODE_API.Get_Currency_Rounding({1} IN, {2} IN);", QualifiedVarBindName("nAccDecimalsInAmount"),
                                                                                                                     QualifiedVarBindName("i_sCompany"),
                                                                                                                     dfsCurrencyCode.QualifiedBindName);
                    if (! DbPLSQLBlock(cSessionManager.c_hSql,  sStatment))
                    {
                         e.Return = false;
                         return;
                    }
                    this.tblVouTemplateRow_colsAccDecimalsInAmount.Number = this.nAccDecimalsInAmount;
                    this.dfCodePartValue.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                    this.dfCodePartDescription.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;

                    SalNumber nRow = Sal.TblQueryContext(tblVouTemplateRow);
                    SalNumber nPosAccount = Sal.TblQueryColumnID(tblVouTemplateRow_colsAccount);
                    SalWindowHandle hWndCol = Sal.TblGetColumnWindow(tblVouTemplateRow, nPosAccount, Sys.COL_GetPos);
                    Sal.TblSetFocusCell(tblVouTemplateRow, nRow, hWndCol, 0, 1);
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
        /// SAM_FetchRowDone event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVouTemplateRow_OnSAM_FetchRowDone(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Sys.SAM_FetchRowDone, Sys.wParam, Sys.lParam);
            this.tblVouTemplateRow_colsPrevAccount.Text = this.tblVouTemplateRow_colsAccount.Text;
            this.tblVouTemplateRow_colsPrevTaxCode.Text = this.tblVouTemplateRow_colsOptionalCode.Text;
            e.Return = true;
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataRecordDuplicate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVouTemplateRow_OnPM_DataRecordDuplicate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordDuplicate, Sys.wParam, Sys.lParam))
            {
                if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
                {
                    this.tblVouTemplateRow_colsPrevAccount.Text = this.tblVouTemplateRow_colsAccount.Text;
                    this.tblVouTemplateRow_colsPrevTaxCode.Text = this.tblVouTemplateRow_colsOptionalCode.Text;
                    this.dfCodePartValue.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                    this.dfCodePartDescription.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                    using (SignatureHints hints = SignatureHints.NewContext())
                    {
                        hints.Add("CURRENCY_CODE_API.Get_Currency_Rounding", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                        if (!(this.tblVouTemplateRow.DbPLSQLBlock(cSessionManager.c_hSql, " BEGIN\r\n" +
                            "		:i_hWndFrame.frmVouTemplate.nAccDecimalsInAmount :=\r\n" +
                            "		NVL( &AO.CURRENCY_CODE_API.Get_Currency_Rounding(\r\n" +
                            "		:i_hWndFrame.frmVouTemplate.i_sCompany,\r\n" +
                            "		:i_hWndFrame.frmVouTemplate.dfsCurrencyCode),0);\r\n	  END; ")))
                        {
                            e.Return = false;
                            return;
                        }
                    }
                    this.tblVouTemplateRow_colsAccDecimalsInAmount.Number = this.nAccDecimalsInAmount;
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
        /// PM_DataRecordRemove event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVouTemplateRow_OnPM_DataRecordRemove(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove, Sys.wParam, Sys.lParam))
            {
                if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
                {
                    this.dfCodePartValue.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                    this.dfCodePartDescription.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
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

        private void tblVouTemplateRow_colsDeliveryTypeId_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblVouTemplateRow_colsDeliveryTypeId_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        private void tblVouTemplateRow_colsDeliveryTypeId_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;

            if (!(Sal.IsNull(this.tblVouTemplateRow_colsDeliveryTypeId)))
            {
                if (!(this.tblVouTemplateRow_colsDeliveryTypeId.DbPLSQLBlock(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "Voucher_Row_API.Validate_Delivery_Type_Id__(\r\n" +
                    " :i_hWndFrame.frmVouTemplate.tblVouTemplateRow_colsCompany IN,\r\n" +
                    " :i_hWndFrame.frmVouTemplate.tblVouTemplateRow_colsDeliveryTypeId IN)")))
                {
                    e.Return = false;
                    return;
                }

                this.tblVouTemplateRow_colsDeliveryTypeId.DbPLSQLBlock(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "Voucher_Template_Row_API.Get_Delivery_Type_Description(\r\n" +
                " :i_hWndFrame.frmVouTemplate.tblVouTemplateRow_colsDeliveryTypeDescription OUT,\r\n" +
                " :i_hWndFrame.frmVouTemplate.tblVouTemplateRow_colsCompany IN,\r\n" +
                " :i_hWndFrame.frmVouTemplate.tblVouTemplateRow_colsDeliveryTypeId IN)");
            }
            else
            {
                this.tblVouTemplateRow_colsDeliveryTypeDescription.Text = null;
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }
        #endregion

        #region Late Bind Methods

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
        
        #endregion

        #region tblVouTemplateRow

        #region Window Variables
        public SalArray<SalString> sCodeParts = new SalArray<SalString>();
        public SalString sCodePartValue = "";
        public SalString sParam = "";  
        public SalString sTaxHandlingValue = "";
        public SalString sDummy = "";
        public SalString __sRequiredString = "";
        public SalString __sRequiredStringComplete = "";
        public SalString p_sCodePartTemp = "";
        public SalString p_sCodePartValueTemp = "";
        public SalString sTempLovReference = "";
        public SalBoolean bReturn = false;
        private SalString sProjectOrigin = "";
        #endregion

        #region Methods
        /// <summary>
        /// Get default values for new voucher row
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber DataRecordGetDefaults()
        {
            #region Actions
            using (new SalContext(tblVouTemplateRow))
            {
                tblVouTemplateRow_colsTransCode.EditDataItemValueSet(1, ((SalString)"MANUAL").ToHandle());
                tblVouTemplateRow_colsCurrencyCode.EditDataItemValueSet(1, ((SalString)this.dfsCurrencyCode.Text).ToHandle());
                tblVouTemplateRow_colnCurrencyRate.EditDataItemValueSet(1, this.dfsCurrencyRate.Number.ToString(this.dfsDecimalsInRate.Number).ToHandle());
                tblVouTemplateRow_colnConversionFactor.EditDataItemValueSet(1, this.dfnConvFactor.Number.ToString(0).ToHandle());
                this.dfnRowNo.Number = this.dfnRowNo.Number + 1;
                tblVouTemplateRow_colnRowNo.EditDataItemValueSet(1, this.dfnRowNo.Number.ToString(0).ToHandle());
                tblVouTemplateRow_colsPrevAccount.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                tblVouTemplateRow_colsPrevTaxCode.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
            
                if (!(DbPLSQLBlock(@"{0} := NVL( &AO.CURRENCY_CODE_API.Get_Currency_Rounding({1} IN, {2} IN),0);",
                                   this.QualifiedVarBindName("nAccDecimalsInAmount"),
                                   this.QualifiedVarBindName("i_sCompany"),
                                   this.dfsCurrencyCode.QualifiedBindName )))
                {
                    return false;
                }
              
                tblVouTemplateRow_colsAccDecimalsInAmount.Number = this.nAccDecimalsInAmount;
            }

            return 0;
            #endregion
        }
        // Amount  Calculation
        /// <summary>
        /// Get multiplier to make decimals rounding
        /// </summary>
        /// <param name="nDecimals"></param>
        /// <returns></returns>
        public virtual SalNumber GetMultiplier(SalNumber nDecimals)
        {
            SalString sMultiplier = "1";
            SalNumber nDec = 0;
            while (nDec < nDecimals)
            {
                sMultiplier = sMultiplier + "0";
                nDec = nDec + 1;
            } 
            return sMultiplier.ToNumber();
        }

        /// <summary>
        /// Round number of decimals
        /// </summary>
        /// <param name="nValue"></param>
        /// <param name="nNumberOfDecimals"></param>
        /// <returns></returns>
        public virtual SalNumber RoundedDecimals(SalNumber nValue, SalNumber nNumberOfDecimals)
        {
            #region Local Variables
            SalNumber nMult = 0;
            SalNumber nNeValue = 0;
            #endregion

            #region Actions
            if (nValue == SalNumber.Null)
            {
                return nValue;
            }
            if (nNumberOfDecimals == 0)
            {
                return nValue.Round();
            }
            nMult = GetMultiplier(nNumberOfDecimals);
            if (nValue < 0)
            {
                nNeValue = -nValue;
                nNeValue = (nNeValue * nMult).Round();
                nValue = -nNeValue;
            }
            else
            {
                nValue = (nValue * nMult).Round();
            }
            return nValue / nMult;
            
            #endregion
        }

        /// <summary>
        /// Set other related rival currency amount, such as if someone enter debit currency amount,
        /// system must set value for currency amount, debit, amount.
        /// </summary>
        /// <param name="nMyValue"></param>
        /// <param name="hWndRival"></param>
        /// <param name="nDecimalsCurrent"></param>
        /// <param name="nDecimalsRival"></param>
        /// <param name="sStatus"></param>
        /// <returns></returns>
        public virtual SalNumber SetAnotherValue(SalNumber nMyValue, SalWindowHandle hWndRival, SalNumber nDecimalsCurrent, SalNumber nDecimalsRival, SalString sStatus)
        {
            #region Local Variables
            SalNumber nCalculateValue = 0;
            SalNumber nCurrencyAmount = 0;
            SalString sWindowValue = "";
            #endregion

            #region Actions
         
            if (sStatus == "RATE")
            {
                nCurrencyAmount = tblVouTemplateRow_colnCurrencyAmount.Number;
                this.GetAttributes(dfsCompany.Text, tblVouTemplateRow_colsCurrencyCode.Text, dfsCurrencyCode.Text, dfsCurrencyType.Text, dfdValidFrom.DateTime);
                if (tblVouTemplateRow_colsRateChanged.Text == "TRUE")
                {
                    if (this.i_lsFinInverted == "TRUE")
                    {
                        nCalculateValue = RoundedDecimals(tblVouTemplateRow_colnCurrencyAmount.Number / (nMyValue / this.i_nFinConversionFactor), nDecimalsCurrent);
                    }
                    else
                    {
                        nCalculateValue = RoundedDecimals(tblVouTemplateRow_colnCurrencyAmount.Number * (nMyValue / this.i_nFinConversionFactor), nDecimalsCurrent);
                    }
                    if (nCalculateValue == 0)
                    {
                        nCalculateValue = SalNumber.Null;
                    }
                    Sal.SendMsg(tblVouTemplateRow_colnAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, nCalculateValue.ToString(nDecimalsCurrent).ToHandle());
                }
                else
                {
                    this.GetBaseCurrencyAmount(nCurrencyAmount, ref nCalculateValue);
                    if (nCalculateValue == 0)
                    {
                        nCalculateValue = SalNumber.Null;
                    }
                    tblVouTemplateRow_colnAmount.Number = nCalculateValue;
                    tblVouTemplateRow_colnAmount.EditDataItemSetEdited();
                }
                if (nCalculateValue == 0)
                {
                    nCalculateValue = SalNumber.Null;
                }
                tblVouTemplateRow_colnAmount.Number = nCalculateValue;
                tblVouTemplateRow_colnAmount.EditDataItemSetEdited();
                if (tblVouTemplateRow_colnAmount.Number > 0)
                {
                    if (tblVouTemplateRow_colsCorrection.Text == "Y")
                    {
                        tblVouTemplateRow_colnCreditAmount.Number = -nCalculateValue;
                        tblVouTemplateRow_colnCreditAmount.EditDataItemSetEdited();
                    }
                    else
                    {
                        tblVouTemplateRow_colnDebitAmount.Number = nCalculateValue;
                        tblVouTemplateRow_colnDebitAmount.EditDataItemSetEdited();
                    }
                }
                else
                {
                    if (tblVouTemplateRow_colsCorrection.Text == "Y")
                    {
                        tblVouTemplateRow_colnDebitAmount.Number = nCalculateValue;
                        tblVouTemplateRow_colnDebitAmount.EditDataItemSetEdited();
                    }
                    else
                    {
                        tblVouTemplateRow_colnCreditAmount.Number = -nCalculateValue;
                        tblVouTemplateRow_colnCreditAmount.EditDataItemSetEdited();
                    }
                }
            }
            if (sStatus == "CURRENT_AMOUNT")
            {
                nMyValue = RoundedDecimals(nMyValue, nDecimalsCurrent);
                this.GetAttributes(this.dfsCompany.Text, tblVouTemplateRow_colsCurrencyCode.Text, this.dfsCurrencyCode.Text, this.dfsCurrencyType.Text, this.dfdValidFrom.DateTime);
                if (tblVouTemplateRow_colsRateChanged.Text == "TRUE")
                {
                    if (this.i_lsFinInverted == "TRUE")
                    {
                        nCalculateValue = RoundedDecimals(nMyValue / (tblVouTemplateRow_colnCurrencyRate.Number / this.i_nFinConversionFactor), nDecimalsRival);
                    }
                    else
                    {
                        nCalculateValue = RoundedDecimals(nMyValue * (tblVouTemplateRow_colnCurrencyRate.Number / this.i_nFinConversionFactor), nDecimalsRival);
                    }
                    Sal.SendMsg(tblVouTemplateRow_colnAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, nCalculateValue.ToString(nDecimalsRival).ToHandle());
                }
                else
                {
                    this.GetBaseCurrencyAmount(nMyValue, ref nCalculateValue);
                    tblVouTemplateRow_colnAmount.Number = nCalculateValue;
                    tblVouTemplateRow_colnAmount.EditDataItemSetEdited();
                }
                tblVouTemplateRow_colnAmount.Number = nCalculateValue;
                tblVouTemplateRow_colnAmount.EditDataItemSetEdited();
                tblVouTemplateRow_colnCurrencyAmount.Number = nMyValue;
                tblVouTemplateRow_colnCurrencyAmount.EditDataItemSetEdited();
                if (nCalculateValue != SalNumber.Null)
                {
                    if ((nCalculateValue < 0 && tblVouTemplateRow_colsCorrection.Text == "N") || (nCalculateValue > 0 && tblVouTemplateRow_colsCorrection.Text == "Y"))
                    {
                        nCalculateValue = -nCalculateValue;
                    }
                }
                Sal.SendMsg(hWndRival, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, nCalculateValue.ToString(99).ToHandle());
            }
            if (sStatus == "ACCOUNTING_AMOUNT")
            {
                nMyValue = RoundedDecimals(nMyValue, nDecimalsCurrent);
                if (nMyValue != SalNumber.Null)
                {
                    Sal.GetWindowText(tblVouTemplateRow_colnCurrencyAmount, ref sWindowValue, 100);
                    if (sWindowValue.ToNumber() != 0)
                    {
                        if ((tblVouTemplateRow_colnCurrencyAmount.Number < 0 && nMyValue > 0) || (tblVouTemplateRow_colnCurrencyAmount.Number > 0 && nMyValue < 0))
                        {
                            tblVouTemplateRow_colnCurrencyAmount.Number = -tblVouTemplateRow_colnCurrencyAmount.Number;
                            tblVouTemplateRow_colnCurrencyAmount.EditDataItemSetEdited();
                            if (tblVouTemplateRow_colnDebitCurrencyAmount.Number == Sys.NUMBER_Null)
                            {
                                tblVouTemplateRow_colnDebitCurrencyAmount.Number = tblVouTemplateRow_colnCreditCurrencyAmount.Number;
                                tblVouTemplateRow_colnDebitCurrencyAmount.EditDataItemSetEdited();
                                tblVouTemplateRow_colnCreditCurrencyAmount.Number = Sys.NUMBER_Null;
                                tblVouTemplateRow_colnCreditCurrencyAmount.EditDataItemSetEdited();
                            }
                            else
                            {
                                tblVouTemplateRow_colnCreditCurrencyAmount.Number = tblVouTemplateRow_colnDebitCurrencyAmount.Number;
                                tblVouTemplateRow_colnCreditCurrencyAmount.EditDataItemSetEdited();
                                tblVouTemplateRow_colnDebitCurrencyAmount.Number = Sys.NUMBER_Null;
                                tblVouTemplateRow_colnDebitCurrencyAmount.EditDataItemSetEdited();
                            }
                        }
                        this.GetAttributes(this.dfsCompany.Text, tblVouTemplateRow_colsCurrencyCode.Text, this.dfsCurrencyCode.Text, this.dfsCurrencyType.Text, this.dfdValidFrom.DateTime);
                        if (((SalString)tblVouTemplateRow_colsCurrencyCode.Text).Trim().ToUpper() != ((SalString)this.dfsCurrencyCode.Text).Trim().ToUpper())
                        {

                            // PPJ: Automatically generated temporary assignments. Properties canot be passed by reference.
                            SalNumber temp1 = tblVouTemplateRow_colnCurrencyRate.Number;
                            this.GetCurrencyRate(nMyValue, tblVouTemplateRow_colnCurrencyAmount.Number, ref temp1);
                            tblVouTemplateRow_colnCurrencyRate.Number = temp1;
                        }
                    }
                }
                tblVouTemplateRow_colnAmount.Number = nMyValue;
                tblVouTemplateRow_colnAmount.EditDataItemSetEdited();
            }
            return nMyValue;
            
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean ValidateCurrencyCode()
        {
            string stmt = @"{colsDecimalsInRate}   := NVL( &AO.CURRENCY_CODE_API.No_Of_Decimals_In_Rate_( {dfsCompany} IN, {colsCurrencyCode} IN),0); 
		                    {colsDecimalsInAmount} := NVL(&AO.CURRENCY_CODE_API.Get_Currency_Rounding({dfsCompany} IN,{colsCurrencyCode} IN),0);";

            IDictionary<string, string> namedBindVariables = new Dictionary<string, string>();
            namedBindVariables.Add("colsDecimalsInRate", this.tblVouTemplateRow_colsDecimalsInRate.QualifiedBindName);
            namedBindVariables.Add("dfsCompany", this.dfsCompany.QualifiedBindName);
            namedBindVariables.Add("colsCurrencyCode", this.tblVouTemplateRow_colsCurrencyCode.QualifiedBindName);
            namedBindVariables.Add("colsDecimalsInAmount", this.tblVouTemplateRow_colsDecimalsInAmount.QualifiedBindName);
            
            return (DbPLSQLBlock(stmt, namedBindVariables));
        }

        /// <summary>
        /// to display code part value description
        /// </summary>
        /// <param name="sPCodePart"></param>
        /// <param name="sPCodePartValue"></param>
        /// <returns></returns>
        public virtual SalBoolean GetCodePartDescription(SalString sPCodePart, SalString sPCodePartValue)
        {
 
            sCodePartValue = sPCodePartValue;           
            if (!(DbPLSQLBlock(@"{0} := &AO.Accounting_Code_Part_Value_API.Get_Description({1} IN, {2} IN,{3} IN );",
                                this.dfCodePartDescription.QualifiedBindName,
                                this.dfsCompany.QualifiedBindName,
                                this.tblVouTemplateRow_colsCodePart.QualifiedBindName,
                                this.QualifiedVarBindName("sCodePartValue") )))
            {
                // Don't translate this message, this message only for programmer not user
                Ifs.Fnd.ApplicationForms.Int.AlertBox("Design time error in function GetCodePartDescription !", Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
                return false;
            }
         
            return true;
            
        }
        // These Functions are for Codepart Demand
        // This function does all the processing that is required when the Focus is
        //   set on a free code part (colCodeB to colCodeJ and Process code, Text + Quantity)
        /// <summary>
        /// </summary>
        /// <param name="hPWindow"></param>
        /// <param name="sPCodePart"></param>
        /// <param name="sPCodeValue"></param>
        /// <returns></returns>
        public virtual SalBoolean CodePartSetFocus(SalWindowHandle hPWindow, SalString sPCodePart, SalString sPCodeValue)
        {
    
            if (AmIBlocked(hPWindow))
            {
                // Used this method as using Sal.SendMsg,Sal.PostMsg to send Tab key is not working properly in aurora client
                System.Windows.Forms.SendKeys.Send("{TAB}");
                return false;
            }
            else
            {
                tblVouTemplateRow_colsCodePart.Text = sPCodePart;
                return true;
            }
         
        }

        /// <summary>
        /// </summary>
        /// <param name="hWindow"></param>
        /// <returns></returns>
        public virtual SalBoolean AmIBlocked(SalWindowHandle hWindow)
        {
            return (this.GetMyDemand(hWindow) == "S");
        }

        /// <summary>
        /// </summary>
        /// <param name="hWindow"></param>
        /// <returns></returns>
        public virtual SalString GetMyDemand(SalWindowHandle hWindow)
        {
            #region Local Variables
            SalString sColName = "";
            SalNumber nCodePartNum = 0;
            SalString sMyDemand = "";
            SalNumber nPos = 0;
            #endregion

            #region Actions
            nPos = 1;
            Sal.GetItemName(tblVouTemplateRow, ref sColName);
            nCodePartNum = ((SalString)"BCDEFGHIJPTQ").Scan(sColName.Right(1));
            // This is to use the below code for codes more than 10 positions
            switch (nCodePartNum)
            {
                case 9:
                    nPos = 2;
                    break;

                case 10:
                    nPos = 3;
                    break;

                case 11:
                    nPos = 4;
                    break;
            }
            sMyDemand = ((SalString)tblVouTemplateRow_colsCodeDemand.Text).Mid(nCodePartNum * 2 + nPos, 1);
            return sMyDemand;
           
            #endregion
        }
        // Build the Foundation Attr String for the child values
        /// <summary>
        /// </summary>
        /// <param name="sPAttr"></param>
        /// <returns></returns>
        public virtual SalNumber BuildAttrForChildTable(ref SalString sPAttr)
        {
            #region Local Variables
            SalString sValue = "";
            SalWindowHandle hWndCol = SalWindowHandle.Null;
            #endregion

            #region Actions
            using (new SalContext(tblVouTemplateRow))
            {
                sPAttr = Ifs.Fnd.ApplicationForms.Const.strNULL;
                this.nIndex = 1;
                while (true)
                {
                    hWndCol = Sal.TblGetColumnWindow(tblVouTemplateRow, this.nIndex, Sys.COL_GetID);
                    if (hWndCol == SalWindowHandle.Null)
                    {
                        break;
                    }
                    if (Sal.WindowIsDerivedFromClass(hWndCol, typeof(cColumn)))
                    {
                        sValue = SalString.FromHandle(Sal.SendMsg(hWndCol, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueGet, 0, 0));
                        sPAttr = sPAttr + cColumn.FromHandle(hWndCol).p_sSqlColumn + ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_US).ToCharacter() + sValue + ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_RS).ToCharacter();
                    }
                    this.nIndex = this.nIndex + 1;
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// Copy server attributes from string to variable.
        /// </summary>
        /// <param name="sPAttr"></param>
        /// <param name="sPCodePart"></param>
        /// <returns></returns>
        public virtual SalNumber AttrDecodeCodePart(SalString sPAttr, SalArray<SalString> sPCodePart)
        {
            #region Local Variables
            SalArray<SalString> sAttr = new SalArray<SalString>();
            SalArray<SalString> sField = new SalArray<SalString>();
            SalNumber n = 0;
            SalString sResult = "";
            #endregion

            #region Actions

            Ifs.Fnd.ApplicationForms.Var.Console.TextAdd(Ifs.Fnd.ApplicationForms.Const.CONS_Debug, "  ===  AttrDecodeCodePart( '" + sPAttr + "')");
            sPAttr.Tokenize(Ifs.Fnd.ApplicationForms.Const.strNULL, ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_RS).ToCharacter(), sAttr);
            n = 0;
            sResult = Ifs.Fnd.ApplicationForms.Const.strNULL;
            while (sAttr[n] != Ifs.Fnd.ApplicationForms.Const.strNULL)
            {
                sField[1] = Ifs.Fnd.ApplicationForms.Const.strNULL;
                sAttr[n].Tokenize(Ifs.Fnd.ApplicationForms.Const.strNULL, ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_US).ToCharacter(), sField);
                // There are 9 code parts
                sPCodePart[n] = sField[1];
                n = n + 1;
            }
            sPAttr = sResult;
 
            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber ClearBlockedCodeParts()
        {
            #region Local Variables
            SalString sMyDemand = "";
            SalNumber nColumnId = 0;
            SalNumber nColumnIdQuantity = 0;
            SalNumber nId = 0;
            SalWindowHandle hWndCol = SalWindowHandle.Null;
            SalWindowHandle hWndColQty = SalWindowHandle.Null;
            #endregion

            #region Actions
   
            // Loop thru the Free Code Part Columns
            // Get to the Free Code Parts
            nColumnId = Sal.TblQueryColumnID(tblVouTemplateRow_colsCodeB);
            nColumnIdQuantity = Sal.TblQueryColumnID(tblVouTemplateRow_colnQuantityQ);
            nId = 1;
            // Get the Demand of each column from colCodeDemand
            // For the columns where demand set to 'S', clear the field using SalClearField() function
            while (nId < 11)
            {
                hWndCol = Sal.TblGetColumnWindow(tblVouTemplateRow, nColumnId + nId - 1, Sys.COL_GetID);
                sMyDemand = GetMyDemand(hWndCol);
                if (!(Sal.IsNull(hWndCol)) && sMyDemand == "S")
                {
                    Sal.ClearField(hWndCol);
                    Sal.SetFieldEdit(hWndCol, true);
                }
                // Bug Id 106148 Begin Change 1 to 2
                nId = nId + 2;
                // Bug Id 106148 End

                hWndColQty = Sal.TblGetColumnWindow(tblVouTemplateRow, nColumnIdQuantity, Sys.COL_GetID);
                sMyDemand = GetMyDemand(hWndColQty);
                if (!(Sal.IsNull(hWndColQty)) && sMyDemand == "S")
                {
                    Sal.ClearField(hWndColQty);
                    Sal.SetFieldEdit(hWndColQty, true);
                }

            }
            
            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="sCodePartValue"></param>
        /// <returns></returns>
        public virtual new SalBoolean EnableDisableProjectActivityId(SalString sCodePartValue)
        {
            #region Actions
            using (new SalContext(this))
            {
                sParam = sCodePartValue;
                if (sParam != SalString.Null)
                {
                    if (Ifs.Application.Accrul.Int.IsGenLedInstalled && Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Accounting_Project_Api.Get_Externally_Created"))
                    {
                        if (!(DbPLSQLBlock(@"{0}:= &AO.Accounting_Project_Api.Get_Externally_Created( {1} IN, {2} IN ) ;",
                                        this.tblVouTemplateRow_colProjectActivityIdEnabled.QualifiedBindName,
                                        this.QualifiedVarBindName("i_sCompany"),
                                        this.QualifiedVarBindName("sParam"))))
                        {
                            return false;
                        }

                    }
                    else
                    {
                        tblVouTemplateRow_colProjectActivityIdEnabled.Text = "Y";
                    }

                    if (Ifs.Application.Accrul.Int.IsGenLedInstalled && Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("ACCOUNTING_PROJECT_API.Get_Project_Origin_Db"))
                    {
                        using (SignatureHints hints = SignatureHints.NewContext())
                        {
                            if (!(DbPLSQLBlock(@"{0} := &AO.ACCOUNTING_PROJECT_API.Get_Project_Origin_Db( {1} IN, {2} IN ) ;",
                                 this.QualifiedVarBindName("sProjectOrigin"),
                                 this.tblVouTemplateRow_colsCompany.QualifiedBindName,
                                 this.QualifiedVarBindName("sParam"))))
                            {
                                return false;
                            }
                        }
                    }

                    if (sProjectOrigin == "JOB")
                    {
                        tblVouTemplateRow_colProjectActivityIdEnabled.Text = "N";
                        tblVouTemplateRow_colnProjectActivityId.Number = 0;
                    }
                    else if (sProjectOrigin == "FINPROJECT")
                    {
                        tblVouTemplateRow_colProjectActivityIdEnabled.Text = "N";
                        tblVouTemplateRow_colnProjectActivityId.Number = Sys.NUMBER_Null;
                    }
                    else
                    {

                        if (tblVouTemplateRow_colProjectActivityIdEnabled.Text == "Y")
                        {
                            SetValueOfProjectID();
                        }
                        else
                        {
                            tblVouTemplateRow_colnProjectActivityId.Number = Sys.NUMBER_Null;
                        }
                    }
                }

                tblVouTemplateRow_colnProjectActivityId.EditDataItemSetEdited();
                return true;

            }
            #endregion
        }
        // The following function sets tblVouTemplateRow_colProjectId with the PROJECT_ID which is needed
        //   for Lov purposes to obtain the PROJECT_ACTIVITY_ID
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber SetValueOfProjectID()
        {
            SalNumber nChildCount = 0;
            while (nChildCount < tblVouTemplateRow.i_nChildCount)
            {
                if (tblVouTemplateRow.i_nChildType[nChildCount] & Ifs.Fnd.ApplicationForms.Const.CHILDTYPE_DataItem)
                {
                    if ((Sal.WindowClassName(tblVouTemplateRow.i_hWndChild[nChildCount]) == "cColumnCodePartFin") && (cColumn.FromHandle(tblVouTemplateRow.i_hWndChild[nChildCount]).p_sSqlColumn == "CODE_" + this.sIsProjectCodePart))
                    {
                        tblVouTemplateRow_colProjectId.Text = SalString.FromHandle(Sal.SendMsg(tblVouTemplateRow.i_hWndChild[nChildCount], Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueGet, 0, 0));
                        break;
                    }
                }
                nChildCount = nChildCount + 1;
            }
            return 0;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber ClearProjectActivityID()
        {
            #region Local Variables
            SalNumber nChildCount = 0;
            SalString sColumn = "";
            #endregion

            #region Actions
            using (new SalContext(tblVouTemplateRow))
            {
                nChildCount = 0;
                while (nChildCount < i_nChildCount)
                {
                    if (i_nChildType[nChildCount] & Ifs.Fnd.ApplicationForms.Const.CHILDTYPE_DataItem)
                    {
                        Sal.GetItemName(i_hWndChild[nChildCount], ref sColumn);
                        if ((sColumn.Scan("colsCode") != -1) && (cColumn.FromHandle(i_hWndChild[nChildCount]).p_sSqlColumn == "CODE_" + this.sIsProjectCodePart))
                        {
                            SalString sTemp1 = SalString.FromHandle(Sal.SendMsg(i_hWndChild[nChildCount], Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueGet, 0, 0));
                            if (sTemp1 == Ifs.Fnd.ApplicationForms.Const.strNULL)
                            {
                                Sal.ClearField(tblVouTemplateRow_colnProjectActivityId);
                            }
                            break;
                        }
                    }
                    nChildCount = nChildCount + 1;
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean GetDefaultTaxCode()
        {
            if (!(DbPLSQLBlock(@"{0} := &AO.Account_API.Get_Tax_Handling_Value({1} IN, {2} IN )",
                                this.QualifiedVarBindName("sTaxHandlingValue"),
                                this.tblVouTemplateRow_colsCompany.QualifiedBindName,
                                this.tblVouTemplateRow_colsAccount.QualifiedBindName) ))
            {
                return false;
            }
               
            if (sTaxHandlingValue != "BLOCKED")
            {
                if (!(DbPLSQLBlock(@"&AO.Account_Tax_Code_API.Get_Default_Tax_Code( {0} OUT, {1} OUT, {2} IN, {3} IN,  'TRUE' )",
                                    this.tblVouTemplateRow_colsOptionalCode.QualifiedBindName,
                                    this.QualifiedVarBindName("sDummy"),
                                    this.tblVouTemplateRow_colsCompany.QualifiedBindName,
                                    this.tblVouTemplateRow_colsAccount.QualifiedBindName)))
                {
                    return false;
                }

                tblVouTemplateRow_colsOptionalCode.EditDataItemSetEdited();
            }
            else
            {
                tblVouTemplateRow_colsOptionalCode.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                tblVouTemplateRow_colsOptionalCode.EditDataItemSetEdited();
            }
            return true;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean CheckTaxCode()
        {
            IDictionary<string, string> namedBindVariables = new Dictionary<string, string>();
            namedBindVariables.Add("sTaxHandlingValue", this.QualifiedVarBindName("sTaxHandlingValue"));
            namedBindVariables.Add("sDummy", this.QualifiedVarBindName("sDummy"));
            namedBindVariables.Add("colsCompany", this.tblVouTemplateRow_colsCompany.QualifiedBindName);
            namedBindVariables.Add("colsAccount", this.tblVouTemplateRow_colsAccount.QualifiedBindName);
            namedBindVariables.Add("colsOptionalCode", this.tblVouTemplateRow_colsOptionalCode.QualifiedBindName);

            return (DbPLSQLBlock(@"&AO.Account_Tax_Code_API.Check_Tax_Code( {sTaxHandlingValue} OUT, 
                                                                            {sDummy} OUT, 
                                                                            {colsCompany} IN, 
                                                                            {colsAccount} IN, 
                                                                            {colsOptionalCode} IN, 
                                                                            NULL, 
                                                                            NULL, 
                                                                            'TRUE')", namedBindVariables));
        }

        /// <summary>
        /// </summary>
        /// <param name="p_sCodepart"></param>
        /// <param name="p_sValue"></param>
        /// <returns></returns>
        public virtual SalNumber CodepartChanged(SalString p_sCodepart, SalString p_sValue)
        {
            if (p_sValue != Ifs.Fnd.ApplicationForms.Const.strNULL)
            {
                return ValidateCodePart(p_sCodepart, p_sValue);
            }
            return Sys.VALIDATE_Ok;         
        }

        /// <summary>
        /// </summary>
        /// <param name="p_sCodePart"></param>
        /// <param name="p_sCodePartValue"></param>
        /// <returns></returns>
        public virtual new SalBoolean ValidateCodePart(SalString p_sCodePart, SalString p_sCodePartValue)
        {
            #region Local Variables
            SalBoolean bCommandOk = false;
            SalString lsStmt = "";
            SalString sCodePart = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                p_sCodePartTemp = p_sCodePart;
                p_sCodePartValueTemp = p_sCodePartValue;

                AttrFetchCodePart(ref __sRequiredStringComplete);
                if (p_sCodePart == "ACCOUNT")
                {
                    if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Accounting_Code_Part_A_API.Validate_Account_Pseudo__")))
                    {
                        return Sys.VALIDATE_Cancel;
                    }
                    lsStmt = string.Format(@"&AO.Accounting_Code_Part_A_API.Validate_Account_Pseudo__({0} IN, {1} IN, {2} IN, TO_DATE(NULL), {3} OUT,{4} INOUT );",
                                           this.tblVouTemplateRow_colsCompany.QualifiedBindName,
                                           this.QualifiedVarBindName("p_sCodePartTemp"),
                                           this.QualifiedVarBindName("p_sCodePartValueTemp"),
                                           this.QualifiedVarBindName("__sRequiredString"),
                                           this.QualifiedVarBindName("__sRequiredStringComplete"));
                    bCommandOk = DbPLSQLBlock(lsStmt);      
                }
                else
                {
                    sCodePart = p_sCodePart.Right(1);
                    if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Accounting_Code_Part_Value_API.Exist")))
                    {
                        return Sys.VALIDATE_Cancel;
                    }
                    if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Accounting_Codestr_API.Complete_Codestring")))
                    {
                        return Sys.VALIDATE_Cancel;
                    }
                    lsStmt = string.Format(@"&AO.Accounting_Code_Part_Value_API.Exist({0} IN, {1} IN,{2} IN);
                                             &AO.Accounting_Codestr_API.Complete_Codestring({3} INOUT, {0} IN, NULL, TO_DATE(NULL), {4} IN )",
                                             this.tblVouTemplateRow_colsCompany.QualifiedBindName,
                                             this.QualifiedVarBindName("p_sCodePartTemp"),
                                             this.QualifiedVarBindName("p_sCodePartValueTemp"),
                                             this.QualifiedVarBindName("__sRequiredStringComplete"),
                                             this.QualifiedVarBindName("p_sCodePartTemp"));
                    bCommandOk = DbPLSQLBlock(lsStmt);
                    
                }
                if (bCommandOk)
                {
                    if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Text_Field_Translation_API.Get_Text")))
                    {
                        return Sys.VALIDATE_Cancel;
                    }
                     
                    if (!(DbPLSQLBlock(@"{0} :=  &AO.Text_Field_Translation_API.Get_Text( {1} IN, 'CODE' || {2} IN, {3} IN)",
                                        this.dfCodePartDescription.QualifiedBindName,
                                        this.tblVouTemplateRow_colsCompany.QualifiedBindName,
                                        this.QualifiedVarBindName("p_sCodePartTemp"),
                                        this.QualifiedVarBindName("p_sCodePartValueTemp"))))
                    {
                        return false;
                    }
                    this.dfCodePartValue.Text = p_sCodePartValueTemp;

                    SetCodePartValues(ref __sRequiredStringComplete);
                    Ifs.Fnd.ApplicationForms.Var.Console.Add("__sRequiredString: " + __sRequiredString);
                    Ifs.Fnd.ApplicationForms.Var.Console.Add("__sRequiredStringComplete: " + __sRequiredStringComplete);
                    return Sys.VALIDATE_Ok;
                }
                return Sys.VALIDATE_Cancel;
            }
            #endregion
        }

        /// <summary>
        /// get all code parts and values
        /// </summary>
        /// <param name="sPAttr"></param>
        /// <returns></returns>
        public virtual void AttrFetchCodePart(ref SalString sPAttr)
        {
            sPAttr = Ifs.Fnd.ApplicationForms.Const.strNULL;
            sPAttr = sPAttr + "ACCOUNT" + ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_US).ToCharacter() + tblVouTemplateRow_colsAccount.Text + ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_RS).ToCharacter();
            sPAttr = sPAttr + "CODE_B" + ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_US).ToCharacter() + tblVouTemplateRow_colsCodeB.Text + ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_RS).ToCharacter();
            sPAttr = sPAttr + "CODE_C" + ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_US).ToCharacter() + tblVouTemplateRow_colsCodeC.Text + ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_RS).ToCharacter();
            sPAttr = sPAttr + "CODE_D" + ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_US).ToCharacter() + tblVouTemplateRow_colsCodeD.Text + ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_RS).ToCharacter();
            sPAttr = sPAttr + "CODE_E" + ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_US).ToCharacter() + tblVouTemplateRow_colsCodeE.Text + ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_RS).ToCharacter();
            sPAttr = sPAttr + "CODE_F" + ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_US).ToCharacter() + tblVouTemplateRow_colsCodeF.Text + ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_RS).ToCharacter();
            sPAttr = sPAttr + "CODE_G" + ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_US).ToCharacter() + tblVouTemplateRow_colsCodeG.Text + ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_RS).ToCharacter();
            sPAttr = sPAttr + "CODE_H" + ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_US).ToCharacter() + tblVouTemplateRow_colsCodeH.Text + ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_RS).ToCharacter();
            sPAttr = sPAttr + "CODE_I" + ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_US).ToCharacter() + tblVouTemplateRow_colsCodeI.Text + ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_RS).ToCharacter();
            sPAttr = sPAttr + "CODE_J" + ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_US).ToCharacter() + tblVouTemplateRow_colsCodeJ.Text + ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_RS).ToCharacter();
            Ifs.Fnd.ApplicationForms.Var.Console.Add("~~AttrFetchCodePart( '" + sPAttr + "'~~"); 
        }

        /// <summary>
        /// Get code part demand (Blocked, Can, Mandatory) and set value if exists
        /// </summary>
        /// <param name="p_nFlagPos"></param>
        /// <param name="sPAttrValue"></param>
        /// <param name="sColumnName"></param>
        /// <param name="hWndColumn"></param>
        /// <returns></returns>
        public virtual SalNumber SetCodePartValue(SalNumber p_nFlagPos, ref SalString sPAttrValue, SalString sColumnName, SalWindowHandle hWndColumn)
        {   
            SalString sReqFieldValue = Ifs.Fnd.ApplicationForms.Int.PalAttrGet(sColumnName, sPAttrValue);
            Sal.SendMsg(hWndColumn, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, sReqFieldValue.ToHandle());
            return 0;     
        }

        /// <summary>
        /// Get code part demand (Blocked, Can, Mandatory) and set value if exists
        /// </summary>
        /// <param name="sPAttrValue"></param>
        /// <returns></returns>
        public virtual SalNumber SetCodePartValues(ref SalString sPAttrValue)
        {
            SetCodePartValue(SalNumber.Null, ref sPAttrValue, "ACCOUNT", tblVouTemplateRow_colsAccount);
            SetCodePartValue(Const.FLAG1_EnableCodeB, ref sPAttrValue, "CODE_B", tblVouTemplateRow_colsCodeB);
            SetCodePartValue(Const.FLAG1_EnableCodeC, ref sPAttrValue, "CODE_C", tblVouTemplateRow_colsCodeC);
            SetCodePartValue(Const.FLAG1_EnableCodeD, ref sPAttrValue, "CODE_D", tblVouTemplateRow_colsCodeD);
            SetCodePartValue(Const.FLAG1_EnableCodeE, ref sPAttrValue, "CODE_E", tblVouTemplateRow_colsCodeE);
            SetCodePartValue(Const.FLAG1_EnableCodeF, ref sPAttrValue, "CODE_F", tblVouTemplateRow_colsCodeF);
            SetCodePartValue(Const.FLAG1_EnableCodeG, ref sPAttrValue, "CODE_G", tblVouTemplateRow_colsCodeG);
            SetCodePartValue(Const.FLAG1_EnableCodeH, ref sPAttrValue, "CODE_H", tblVouTemplateRow_colsCodeH);
            SetCodePartValue(Const.FLAG1_EnableCodeI, ref sPAttrValue, "CODE_I", tblVouTemplateRow_colsCodeI);
            SetCodePartValue(Const.FLAG1_EnableCodeJ, ref sPAttrValue, "CODE_J", tblVouTemplateRow_colsCodeJ);
            return 0;
        }

        // Bug 102101, Begin
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber EnableSeqId()
        {
            SalString sProjectCodePart = Ifs.Application.Accrul.Var.FinlibServices.GetCodePartFunction("PRACC");
            if (sProjectCodePart == "B")
            {
                if (tblVouTemplateRow_colsCodeB.Text != Sys.STRING_Null)
                {
                    if (tblVouTemplateRow_colProjectActivityIdEnabled.Text == Sys.STRING_Null)
                    {
                        EnableDisableProjectActivityId(tblVouTemplateRow_colsCodeB.Text);
                    }
                }
            }
            if (sProjectCodePart == "C")
            {
                if (tblVouTemplateRow_colsCodeC.Text != Sys.STRING_Null)
                {
                    if (tblVouTemplateRow_colProjectActivityIdEnabled.Text == Sys.STRING_Null)
                    {
                        EnableDisableProjectActivityId(tblVouTemplateRow_colsCodeC.Text);
                    }
                }
            }
            if (sProjectCodePart == "D")
            {
                if (tblVouTemplateRow_colsCodeD.Text != Sys.STRING_Null)
                {
                    if (tblVouTemplateRow_colProjectActivityIdEnabled.Text == Sys.STRING_Null)
                    {
                        EnableDisableProjectActivityId(tblVouTemplateRow_colsCodeD.Text);
                    }
                }
            }
            if (sProjectCodePart == "E")
            {
                if (tblVouTemplateRow_colsCodeE.Text != Sys.STRING_Null)
                {
                    if (tblVouTemplateRow_colProjectActivityIdEnabled.Text == Sys.STRING_Null)
                    {
                        EnableDisableProjectActivityId(tblVouTemplateRow_colsCodeE.Text);
                    }
                }
            }
            if (sProjectCodePart == "F")
            {
                if (tblVouTemplateRow_colsCodeF.Text != Sys.STRING_Null)
                {
                    if (tblVouTemplateRow_colProjectActivityIdEnabled.Text == Sys.STRING_Null)
                    {
                        EnableDisableProjectActivityId(tblVouTemplateRow_colsCodeF.Text);
                    }
                }
            }
            if (sProjectCodePart == "G")
            {
                if (tblVouTemplateRow_colsCodeG.Text != Sys.STRING_Null)
                {
                    if (tblVouTemplateRow_colProjectActivityIdEnabled.Text == Sys.STRING_Null)
                    {
                        EnableDisableProjectActivityId(tblVouTemplateRow_colsCodeG.Text);
                    }
                }
            }
            if (sProjectCodePart == "H")
            {
                if (tblVouTemplateRow_colsCodeH.Text != Sys.STRING_Null)
                {
                    if (tblVouTemplateRow_colProjectActivityIdEnabled.Text == Sys.STRING_Null)
                    {
                        EnableDisableProjectActivityId(tblVouTemplateRow_colsCodeH.Text);
                    }
                }
            }
            if (sProjectCodePart == "I")
            {
                if (tblVouTemplateRow_colsCodeI.Text != Sys.STRING_Null)
                {
                    if (tblVouTemplateRow_colProjectActivityIdEnabled.Text == Sys.STRING_Null)
                    {
                        EnableDisableProjectActivityId(tblVouTemplateRow_colsCodeI.Text);
                    }
                }
            }
            if (sProjectCodePart == "J")
            {
                if (tblVouTemplateRow_colsCodeJ.Text != Sys.STRING_Null)
                {
                    if (tblVouTemplateRow_colProjectActivityIdEnabled.Text == Sys.STRING_Null)
                    {
                        EnableDisableProjectActivityId(tblVouTemplateRow_colsCodeJ.Text);
                    }
                }
            }
        return 0;   
        }
        #endregion

        #region Window Actions

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblVouTemplateRow_colsAccount_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.tblVouTemplateRow_colsAccount_OnSAM_SetFocus(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblVouTemplateRow_colsAccount_OnPM_DataItemValidate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovDone:
                    this.tblVouTemplateRow_colsAccount_OnPM_DataItemLovDone(sender, e);
                    break;

                case Ifs.Application.Accrul.Const.PAM_SetCodePartValues:
                    this.tblVouTemplateRow_OnPAM_SetCodePartValues(sender, e);
                    break;
            }
            #endregion
        }

        private void tblVouTemplateRow_OnPAM_SetCodePartValues(object sender, WindowActionsEventArgs e)
        {
            #region Local Variables
            SalString sReqField = "";
            #endregion

            #region Actions
            e.Handled = true;
            sReqField = Ifs.Fnd.ApplicationForms.Int.PalAttrGet("PROJECT_ACTIVITY_ID", SalString.FromHandle(e.LParam));

            if (!sReqField.IsEmpty)
            {
                this.tblVouTemplateRow_colnProjectActivityId.Text = sReqField;
                this.tblVouTemplateRow_colProjectActivityIdEnabled.Text = "Y";
                this.tblVouTemplateRow_colnProjectActivityId.EditDataItemSetEdited();
            }
            else
            {
                this.tblVouTemplateRow_colnProjectActivityId.Text = SalString.Null;
                this.tblVouTemplateRow_colProjectActivityIdEnabled.Text = "N";
                this.tblVouTemplateRow_colnProjectActivityId.EditDataItemSetEdited();
            }
            e.Return = Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_SetCodePartValues, e.WParam, e.LParam);
            #endregion

        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVouTemplateRow_colsAccount_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.tblVouTemplateRow_colsCodePart.Text = "A";
            if (!(Sal.IsNull(this.tblVouTemplateRow_colsAccount)))
            {
                if (!(this.GetCodePartDescription("A", this.tblVouTemplateRow_colsAccount.Text)))
                {
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
        private void tblVouTemplateRow_colsAccount_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam))
            {
                if (Sal.IsNull(this.tblVouTemplateRow_colsAccount.i_hWndSelf))
                {
                    this.tblVouTemplateRow_colsOptionalCode.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                    // Set the Free Code Parts blocked
                    this.tblVouTemplateRow_colsCodeDemand.Text = "1S2S3S4S5S6S7S8S9S";
                    this.ClearProjectActivityID();
                    e.Return = true;
                    return;
                }
                else
                {
                    if (this.tblVouTemplateRow_colsAccount.Text != this.tblVouTemplateRow_colsPrevAccount.Text)
                    {
                        this.GetDefaultTaxCode();
                    }
                    this.tblVouTemplateRow_colsPrevAccount.Text = this.tblVouTemplateRow_colsAccount.Text;
                    this.sTemp = this.tblVouTemplateRow_colsAccount.Text;
                
                        IDictionary<string, string> namedBindVariables = new Dictionary<string, string>();
                        namedBindVariables.Add("i_sCompany", this.QualifiedVarBindName("i_sCompany"));
                        namedBindVariables.Add("sTemp", this.QualifiedVarBindName("sTemp"));
                        namedBindVariables.Add("lsTemp", this.QualifiedVarBindName("lsTemp"));
                        namedBindVariables.Add("sTempAccnt", this.QualifiedVarBindName("sTempAccnt"));
                        namedBindVariables.Add("sPseudoCodeUser", this.QualifiedVarBindName("sPseudoCodeUser"));

                        string sql = @"&AO.Account_API.Exist_Account_And_Pseudo({i_sCompany} IN,
                                                                                {sTemp} IN );
                                       &AO.Pseudo_Codes_API.Get_Demand_String_Pseudo({lsTemp} OUT,
											                                         {sTempAccnt} OUT,
											                                         {i_sCompany} IN,
											                                         {sTemp} IN,
											                                         {sPseudoCodeUser} IN);";

                        if (!(DbPLSQLBlock(sql,namedBindVariables)))
                        {
                            e.Return = false;
                            return;
                        }
                    
                    if (this.lsTemp.Trim() == "")
                    {
                        e.Return = false;
                        return;
                    }
                    this.tblVouTemplateRow_colsCodeDemand.Text = this.lsTemp.Left(29);
                    // There are two cases here. User would either like the Fixed Code String or the Code String Completion
                    // Get the complete code string
                    if (Var.g_bUseTemFCS)
                    {

                        this.tblVouTemplateRow_colsCodeB.Text = Var.g_sFCSTemCodeB;
                        this.tblVouTemplateRow_colsCodeC.Text = Var.g_sFCSTemCodeC;
                        this.tblVouTemplateRow_colsCodeD.Text = Var.g_sFCSTemCodeD;
                        this.tblVouTemplateRow_colsCodeE.Text = Var.g_sFCSTemCodeE;
                        this.tblVouTemplateRow_colsCodeF.Text = Var.g_sFCSTemCodeF;
                        this.tblVouTemplateRow_colsCodeG.Text = Var.g_sFCSTemCodeG;
                        this.tblVouTemplateRow_colsCodeH.Text = Var.g_sFCSTemCodeH;
                        this.tblVouTemplateRow_colsCodeI.Text = Var.g_sFCSTemCodeI;
                        this.tblVouTemplateRow_colsCodeJ.Text = Var.g_sFCSTemCodeJ;
                    }
                    else
                    {
                        this.lsTemp = Ifs.Fnd.ApplicationForms.Const.strNULL;
                        this.lsTemp1 = Ifs.Fnd.ApplicationForms.Const.strNULL;
                        this.BuildAttrForChildTable(ref this.lsTemp1);        
                        if (!(DbPLSQLBlock(@"&AO.VOUCHER_TEMPLATE_ROW_API.Validate_Account_Pseudo__({0} OUT,{1} INOUT,{2} IN,{3} IN,{4} IN,{5} IN)",
                                                                            this.QualifiedVarBindName("lsStmt"),
                                                                            this.QualifiedVarBindName("lsTemp1"),
                                                                            this.QualifiedVarBindName("i_sCompany"),
                                                                            this.tblVouTemplateRow_colsAccount.QualifiedBindName,
                                                                            this.dfdValidFrom.QualifiedBindName,
                                                                            this.QualifiedVarBindName("sPseudoCodeUser") )))
                        {
                            e.Return = false;
                            return;
                        }

                        this.AttrDecodeCodePart(this.lsTemp1, this.sCodeParts);
                        this.tblVouTemplateRow_colsAccount.Text = this.sTempAccnt;
                        this.tblVouTemplateRow_colsCodeB.Text = this.sCodeParts[1];
                        this.tblVouTemplateRow_colsCodeC.Text = this.sCodeParts[2];
                        this.tblVouTemplateRow_colsCodeD.Text = this.sCodeParts[3];
                        this.tblVouTemplateRow_colsCodeE.Text = this.sCodeParts[4];
                        this.tblVouTemplateRow_colsCodeF.Text = this.sCodeParts[5];
                        this.tblVouTemplateRow_colsCodeG.Text = this.sCodeParts[6];
                        this.tblVouTemplateRow_colsCodeH.Text = this.sCodeParts[7];
                        this.tblVouTemplateRow_colsCodeI.Text = this.sCodeParts[8];
                        this.tblVouTemplateRow_colsCodeJ.Text = this.sCodeParts[9];
                        this.tblVouTemplateRow_colsProcessCodeP.Text = this.sCodeParts[10];
                        this.tblVouTemplateRow_colsTextT.Text = this.sCodeParts[11];
                        this.tblVouTemplateRow_colnQuantityQ.Number = this.sCodeParts[12].ToNumber();
                        this.tblVouTemplateRow_colsCodeB.EditDataItemSetEdited();
                        this.tblVouTemplateRow_colsCodeC.EditDataItemSetEdited();
                        this.tblVouTemplateRow_colsCodeD.EditDataItemSetEdited();
                        this.tblVouTemplateRow_colsCodeE.EditDataItemSetEdited();
                        this.tblVouTemplateRow_colsCodeF.EditDataItemSetEdited();
                        this.tblVouTemplateRow_colsCodeG.EditDataItemSetEdited();
                        this.tblVouTemplateRow_colsCodeH.EditDataItemSetEdited();
                        this.tblVouTemplateRow_colsCodeI.EditDataItemSetEdited();
                        this.tblVouTemplateRow_colsCodeJ.EditDataItemSetEdited();
                    }
                    this.ClearBlockedCodeParts();
                    this.p_sCodePartTemp = "A";
                    this.p_sCodePartValueTemp = this.tblVouTemplateRow_colsAccount.Text;
                    if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Text_Field_Translation_API.Get_Text")))
                    {
                        e.Return = Sys.VALIDATE_Cancel;
                        return;
                    }
                         
                    if (!(DbPLSQLBlock(@"{0}:= substr( &AO.Text_Field_Translation_API.Get_Text({1} IN,'CODE' || {2} IN,{3} IN),1,100)",
                                        this.dfCodePartDescription.QualifiedBindName,
                                        this.tblVouTemplateRow_colsCompany.QualifiedBindName,
                                        this.QualifiedVarBindName("p_sCodePartTemp"),
                                        this.QualifiedVarBindName("p_sCodePartValueTemp"))))
                    {
                        e.Return = false;
                        return;
                    }
                    
                    this.dfCodePartValue.Text = this.p_sCodePartValueTemp;
                    e.Return = true;
                    return;
                }
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemLovDone event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVouTemplateRow_colsAccount_OnPM_DataItemLovDone(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            SalString.FromHandle(Sys.lParam).Tokenize("", ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_RS).ToCharacter(), this.sRecords);
            this.sRecords[1].Tokenize("", ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_US).ToCharacter(), this.sUnits);
            // Insert new code here...
            // CONVERSION: Renamed sUserName to sUserNameArr due to conversion context problems in PPJ
            // PPJ Does not check for the type. In this case sUserName also resides in cChildTableFin (as a string)
            this.sUnits[1].Tokenize("", "-", this.sUserNameArr);
            this.sPseudoCodeUser = this.sUserNameArr[1].Trim();
            e.Return = true;
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblVouTemplateRow_colsCodeB_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.tblVouTemplateRow_colsCodeB_OnSAM_SetFocus(sender, e);
                    break;

                case Sys.SAM_KillFocus:
                    this.tblVouTemplateRow_colsCodeB_OnSAM_KillFocus(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblVouTemplateRow_colsCodeB_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVouTemplateRow_colsCodeB_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.tblVouTemplateRow_colsCodePart.Text = "B";
            if (!(Sal.IsNull(this.tblVouTemplateRow_colsCodeB)))
            {
                if (!(this.GetCodePartDescription("B", this.tblVouTemplateRow_colsCodeB.Text)))
                {
                    e.Return = false;
                    return;
                }
            }
            if (this.CodePartSetFocus(this.tblVouTemplateRow_colsCodeB.i_hWndSelf, "B", this.tblVouTemplateRow_colsCodeB.Text))
            {
                Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
                e.Return = true;
                return;
            }
            e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// SAM_KillFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVouTemplateRow_colsCodeB_OnSAM_KillFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Sys.SAM_KillFocus, Sys.wParam, Sys.lParam))
            {
                if (Sal.QueryFieldEdit(this.tblVouTemplateRow_colsCodeB) && this.tblVouTemplateRow_colsCodePart.Text == this.sIsProjectCodePart)
                {
                    this.EnableDisableProjectActivityId(this.tblVouTemplateRow_colsCodeB.Text);
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
        private void tblVouTemplateRow_colsCodeB_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam) == Sys.VALIDATE_Cancel)
            {
                e.Return = Sys.VALIDATE_Cancel;
                return;
            }
            e.Return = this.CodepartChanged("B", this.tblVouTemplateRow_colsCodeB.Text);
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblVouTemplateRow_colsCodeC_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.tblVouTemplateRow_colsCodeC_OnSAM_SetFocus(sender, e);
                    break;

                case Sys.SAM_KillFocus:
                    this.tblVouTemplateRow_colsCodeC_OnSAM_KillFocus(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblVouTemplateRow_colsCodeC_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVouTemplateRow_colsCodeC_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.tblVouTemplateRow_colsCodePart.Text = "C";
            if (!(Sal.IsNull(this.tblVouTemplateRow_colsCodeC)))
            {
                if (!(this.GetCodePartDescription("C", this.tblVouTemplateRow_colsCodeC.Text)))
                {
                    e.Return = false;
                    return;
                }
            }
            if (this.CodePartSetFocus(this.tblVouTemplateRow_colsCodeC.i_hWndSelf, "C", this.tblVouTemplateRow_colsCodeC.Text))
            {
                Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
                e.Return = true;
                return;
            }
            e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// SAM_KillFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVouTemplateRow_colsCodeC_OnSAM_KillFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Sys.SAM_KillFocus, Sys.wParam, Sys.lParam))
            {
                if (Sal.QueryFieldEdit(this.tblVouTemplateRow_colsCodeC) && this.tblVouTemplateRow_colsCodePart.Text == this.sIsProjectCodePart)
                {
                    this.EnableDisableProjectActivityId(this.tblVouTemplateRow_colsCodeC.Text);
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
        private void tblVouTemplateRow_colsCodeC_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam) == Sys.VALIDATE_Cancel)
            {
                e.Return = Sys.VALIDATE_Cancel;
                return;
            }
            e.Return = this.CodepartChanged("C", this.tblVouTemplateRow_colsCodeC.Text);
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblVouTemplateRow_colsCodeD_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.tblVouTemplateRow_colsCodeD_OnSAM_SetFocus(sender, e);
                    break;

                case Sys.SAM_KillFocus:
                    this.tblVouTemplateRow_colsCodeD_OnSAM_KillFocus(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblVouTemplateRow_colsCodeD_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVouTemplateRow_colsCodeD_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.tblVouTemplateRow_colsCodePart.Text = "D";
            if (!(Sal.IsNull(this.tblVouTemplateRow_colsCodeD)))
            {
                if (!(this.GetCodePartDescription("D", this.tblVouTemplateRow_colsCodeD.Text)))
                {
                    e.Return = false;
                    return;
                }
            }
            if (this.CodePartSetFocus(this.tblVouTemplateRow_colsCodeD.i_hWndSelf, "D", this.tblVouTemplateRow_colsCodeD.Text))
            {
                Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
                e.Return = true;
                return;
            }
            e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// SAM_KillFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVouTemplateRow_colsCodeD_OnSAM_KillFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Sys.SAM_KillFocus, Sys.wParam, Sys.lParam))
            {
                if (Sal.QueryFieldEdit(this.tblVouTemplateRow_colsCodeD) && this.tblVouTemplateRow_colsCodePart.Text == this.sIsProjectCodePart)
                {
                    this.EnableDisableProjectActivityId(this.tblVouTemplateRow_colsCodeD.Text);
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
        private void tblVouTemplateRow_colsCodeD_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam) == Sys.VALIDATE_Cancel)
            {
                e.Return = Sys.VALIDATE_Cancel;
                return;
            }
            e.Return = this.CodepartChanged("D", this.tblVouTemplateRow_colsCodeD.Text);
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblVouTemplateRow_colsCodeE_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.tblVouTemplateRow_colsCodeE_OnSAM_SetFocus(sender, e);
                    break;

                case Sys.SAM_KillFocus:
                    this.tblVouTemplateRow_colsCodeE_OnSAM_KillFocus(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblVouTemplateRow_colsCodeE_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVouTemplateRow_colsCodeE_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.tblVouTemplateRow_colsCodePart.Text = "E";
            if (!(Sal.IsNull(this.tblVouTemplateRow_colsCodeE)))
            {
                if (!(this.GetCodePartDescription("E", this.tblVouTemplateRow_colsCodeE.Text)))
                {
                    e.Return = false;
                    return;
                }
            }
            if (this.CodePartSetFocus(this.tblVouTemplateRow_colsCodeE.i_hWndSelf, "E", this.tblVouTemplateRow_colsCodeE.Text))
            {
                Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
                e.Return = true;
                return;
            }
            e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// SAM_KillFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVouTemplateRow_colsCodeE_OnSAM_KillFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Sys.SAM_KillFocus, Sys.wParam, Sys.lParam))
            {
                if (Sal.QueryFieldEdit(this.tblVouTemplateRow_colsCodeE) && this.tblVouTemplateRow_colsCodePart.Text == this.sIsProjectCodePart)
                {
                    this.EnableDisableProjectActivityId(this.tblVouTemplateRow_colsCodeE.Text);
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
        private void tblVouTemplateRow_colsCodeE_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam) == Sys.VALIDATE_Cancel)
            {
                e.Return = Sys.VALIDATE_Cancel;
                return;
            }
            e.Return = this.CodepartChanged("E", this.tblVouTemplateRow_colsCodeE.Text);
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblVouTemplateRow_colsCodeF_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.tblVouTemplateRow_colsCodeF_OnSAM_SetFocus(sender, e);
                    break;

                case Sys.SAM_KillFocus:
                    this.tblVouTemplateRow_colsCodeF_OnSAM_KillFocus(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblVouTemplateRow_colsCodeF_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVouTemplateRow_colsCodeF_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.tblVouTemplateRow_colsCodePart.Text = "F";
            if (!(Sal.IsNull(this.tblVouTemplateRow_colsCodeF)))
            {
                if (!(this.GetCodePartDescription("F", this.tblVouTemplateRow_colsCodeF.Text)))
                {
                    e.Return = false;
                    return;
                }
            }
            if (this.CodePartSetFocus(this.tblVouTemplateRow_colsCodeF.i_hWndSelf, "F", this.tblVouTemplateRow_colsCodeF.Text))
            {
                Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
                e.Return = true;
                return;
            }
            e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// SAM_KillFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVouTemplateRow_colsCodeF_OnSAM_KillFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Sys.SAM_KillFocus, Sys.wParam, Sys.lParam))
            {
                if (Sal.QueryFieldEdit(this.tblVouTemplateRow_colsCodeF) && this.tblVouTemplateRow_colsCodePart.Text == this.sIsProjectCodePart)
                {
                    this.EnableDisableProjectActivityId(this.tblVouTemplateRow_colsCodeF.Text);
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
        private void tblVouTemplateRow_colsCodeF_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam) == Sys.VALIDATE_Cancel)
            {
                e.Return = Sys.VALIDATE_Cancel;
                return;
            }
            e.Return = this.CodepartChanged("F", this.tblVouTemplateRow_colsCodeF.Text);
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblVouTemplateRow_colsCodeG_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.tblVouTemplateRow_colsCodeG_OnSAM_SetFocus(sender, e);
                    break;

                case Sys.SAM_KillFocus:
                    this.tblVouTemplateRow_colsCodeG_OnSAM_KillFocus(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblVouTemplateRow_colsCodeG_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVouTemplateRow_colsCodeG_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.tblVouTemplateRow_colsCodePart.Text = "G";
            if (!(Sal.IsNull(this.tblVouTemplateRow_colsCodeG)))
            {
                if (!(this.GetCodePartDescription("G", this.tblVouTemplateRow_colsCodeG.Text)))
                {
                    e.Return = false;
                    return;
                }
            }
            if (this.CodePartSetFocus(this.tblVouTemplateRow_colsCodeG.i_hWndSelf, "G", this.tblVouTemplateRow_colsCodeG.Text))
            {
                Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
                e.Return = true;
                return;
            }
            e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// SAM_KillFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVouTemplateRow_colsCodeG_OnSAM_KillFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Sys.SAM_KillFocus, Sys.wParam, Sys.lParam))
            {
                if (Sal.QueryFieldEdit(this.tblVouTemplateRow_colsCodeG) && this.tblVouTemplateRow_colsCodePart.Text == this.sIsProjectCodePart)
                {
                    this.EnableDisableProjectActivityId(this.tblVouTemplateRow_colsCodeG.Text);
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
        private void tblVouTemplateRow_colsCodeG_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam) == Sys.VALIDATE_Cancel)
            {
                e.Return = Sys.VALIDATE_Cancel;
                return;
            }
            this.EnableDisableProjectActivityId(this.tblVouTemplateRow_colsCodeG.Text);
            e.Return = this.CodepartChanged("G", this.tblVouTemplateRow_colsCodeG.Text);
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblVouTemplateRow_colsCodeH_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.tblVouTemplateRow_colsCodeH_OnSAM_SetFocus(sender, e);
                    break;

                case Sys.SAM_KillFocus:
                    this.tblVouTemplateRow_colsCodeH_OnSAM_KillFocus(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblVouTemplateRow_colsCodeH_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVouTemplateRow_colsCodeH_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.tblVouTemplateRow_colsCodePart.Text = "H";
            if (!(Sal.IsNull(this.tblVouTemplateRow_colsCodeH)))
            {
                if (!(this.GetCodePartDescription("H", this.tblVouTemplateRow_colsCodeH.Text)))
                {
                    e.Return = false;
                    return;
                }
            }
            if (this.CodePartSetFocus(this.tblVouTemplateRow_colsCodeH.i_hWndSelf, "H", this.tblVouTemplateRow_colsCodeH.Text))
            {
                Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
                e.Return = true;
                return;
            }
            e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// SAM_KillFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVouTemplateRow_colsCodeH_OnSAM_KillFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Sys.SAM_KillFocus, Sys.wParam, Sys.lParam))
            {
                if (Sal.QueryFieldEdit(this.tblVouTemplateRow_colsCodeH) && this.tblVouTemplateRow_colsCodePart.Text == this.sIsProjectCodePart)
                {
                    this.EnableDisableProjectActivityId(this.tblVouTemplateRow_colsCodeH.Text);
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
        private void tblVouTemplateRow_colsCodeH_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam) == Sys.VALIDATE_Cancel)
            {
                e.Return = Sys.VALIDATE_Cancel;
                return;
            }
            e.Return = this.CodepartChanged("H", this.tblVouTemplateRow_colsCodeH.Text);
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblVouTemplateRow_colsCodeI_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.tblVouTemplateRow_colsCodeI_OnSAM_SetFocus(sender, e);
                    break;

                case Sys.SAM_KillFocus:
                    this.tblVouTemplateRow_colsCodeI_OnSAM_KillFocus(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblVouTemplateRow_colsCodeI_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVouTemplateRow_colsCodeI_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.tblVouTemplateRow_colsCodePart.Text = "I";
            if (!(Sal.IsNull(this.tblVouTemplateRow_colsCodeI)))
            {
                if (!(this.GetCodePartDescription("I", this.tblVouTemplateRow_colsCodeI.Text)))
                {
                    e.Return = false;
                    return;
                }
            }
            if (this.CodePartSetFocus(this.tblVouTemplateRow_colsCodeI.i_hWndSelf, "I", this.tblVouTemplateRow_colsCodeI.Text))
            {
                Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
                e.Return = true;
                return;
            }
            e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// SAM_KillFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVouTemplateRow_colsCodeI_OnSAM_KillFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Sys.SAM_KillFocus, Sys.wParam, Sys.lParam))
            {
                if (Sal.QueryFieldEdit(this.tblVouTemplateRow_colsCodeI) && this.tblVouTemplateRow_colsCodePart.Text == this.sIsProjectCodePart)
                {
                    this.EnableDisableProjectActivityId(this.tblVouTemplateRow_colsCodeI.Text);
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
        private void tblVouTemplateRow_colsCodeI_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam) == Sys.VALIDATE_Cancel)
            {
                e.Return = Sys.VALIDATE_Cancel;
                return;
            }
            e.Return = this.CodepartChanged("I", this.tblVouTemplateRow_colsCodeI.Text);
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblVouTemplateRow_colsCodeJ_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.tblVouTemplateRow_colsCodeJ_OnSAM_SetFocus(sender, e);
                    break;

                case Sys.SAM_KillFocus:
                    this.tblVouTemplateRow_colsCodeJ_OnSAM_KillFocus(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblVouTemplateRow_colsCodeJ_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVouTemplateRow_colsCodeJ_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.tblVouTemplateRow_colsCodePart.Text = "J";
            if (!(Sal.IsNull(this.tblVouTemplateRow_colsCodeJ)))
            {
                if (!(this.GetCodePartDescription("J", this.tblVouTemplateRow_colsCodeJ.Text)))
                {
                    e.Return = false;
                    return;
                }
            }
            if (this.CodePartSetFocus(this.tblVouTemplateRow_colsCodeJ.i_hWndSelf, "J", this.tblVouTemplateRow_colsCodeJ.Text))
            {
                Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
                e.Return = true;
                return;
            }
            e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// SAM_KillFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVouTemplateRow_colsCodeJ_OnSAM_KillFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Sys.SAM_KillFocus, Sys.wParam, Sys.lParam))
            {
                if (Sal.QueryFieldEdit(this.tblVouTemplateRow_colsCodeJ) && this.tblVouTemplateRow_colsCodePart.Text == this.sIsProjectCodePart)
                {
                    this.EnableDisableProjectActivityId(this.tblVouTemplateRow_colsCodeJ.Text);
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
        private void tblVouTemplateRow_colsCodeJ_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam) == Sys.VALIDATE_Cancel)
            {
                e.Return = Sys.VALIDATE_Cancel;
                return;
            }
            e.Return = this.CodepartChanged("J", this.tblVouTemplateRow_colsCodeJ.Text);
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblVouTemplateRow_colsProcessCodeP_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.tblVouTemplateRow_colsProcessCodeP_OnSAM_SetFocus(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVouTemplateRow_colsProcessCodeP_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.CodePartSetFocus(this.tblVouTemplateRow_colsProcessCodeP.i_hWndSelf, "P", this.tblVouTemplateRow_colsProcessCodeP.Text))
            {
                Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
                e.Return = true;
                return;
            }
            e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblVouTemplateRow_colsOptionalCode_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.tblVouTemplateRow_colsOptionalCode_OnPM_DataItemQueryEnabled(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblVouTemplateRow_colsOptionalCode_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVouTemplateRow_colsOptionalCode_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (((SalString)this.tblVouTemplateRow_colsTransCode.Text).Trim().ToUpper() != "MANUAL")
            {
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                return;
            }
            if (Sal.IsNull(this.tblVouTemplateRow_colsAccount))
            {
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                return;
            }
            DbPLSQLBlock(@"{0} := &AO.Account_API.Get_Tax_Handling_Value({1} IN, {2} IN )",
                                    this.QualifiedVarBindName("sTaxHandlingValue"),
                                    this.tblVouTemplateRow_colsCompany.QualifiedBindName,
                                    this.tblVouTemplateRow_colsAccount.QualifiedBindName);
            if (this.sTaxHandlingValue == "BLOCKED")
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
        private void tblVouTemplateRow_colsOptionalCode_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam) == Sys.VALIDATE_Cancel)
            {
                e.Return = Sys.VALIDATE_Cancel;
                return;
            }
            if (this.tblVouTemplateRow_colsOptionalCode.Text != this.tblVouTemplateRow_colsPrevTaxCode.Text)
            {
                if (!(Sal.IsNull(this.tblVouTemplateRow_colsOptionalCode)))
                {
                    DbPLSQLBlock(@"&AO.Statutory_Fee_API.Get_Tax_Code_Info({0} OUT,{1} OUT,{2} OUT,{3} IN, {4} IN,{5} IN);",
                                    this.QualifiedVarBindName("sMultipleTax"),
                                    this.QualifiedVarBindName("sTaxType"),
                                    this.QualifiedVarBindName("nDeduct"),
                                    this.tblVouTemplateRow_colsCompany.QualifiedBindName,
                                    this.tblVouTemplateRow_colsOptionalCode.QualifiedBindName,
                                    this.dfdValidUntil.QualifiedBindName);

                    if (this.sMultipleTax == "TRUE" || this.sTaxType == "RDE")
                    {
                        this.sMultipleTax = SalString.Null;
                        this.sTaxType = SalString.Null;
                        Ifs.Fnd.ApplicationForms.Int.AlertBox(Ifs.Application.Accrul.Properties.Resources.TEXT_MultipleTax, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Warning, Ifs.Fnd.ApplicationForms.Const.WARNING_Ok);
                        e.Return = Sys.VALIDATE_Cancel;
                        return;
                    }

                    if (!(this.CheckTaxCode()))
                    {
                        e.Return = Sys.VALIDATE_Cancel;
                        return;
                    }
                }
            }
            this.tblVouTemplateRow_colsPrevTaxCode.Text = this.tblVouTemplateRow_colsOptionalCode.Text;
            e.Return = Sys.VALIDATE_Ok;
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblVouTemplateRow_colsCurrencyCode_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblVouTemplateRow_colsCurrencyCode_OnPM_DataItemValidate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLov:
                    this.tblVouTemplateRow_colsCurrencyCode_OnPM_DataItemLov(sender, e);
                    break;

                // Bug 81879 begin

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom:
                    this.tblVouTemplateRow_colsCurrencyCode_OnPM_DataItemZoom(sender, e);
                    break;

                // Bug 81879 end
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVouTemplateRow_colsCurrencyCode_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (!(Sal.IsNull(this.tblVouTemplateRow_colsCurrencyCode)))
            {
                if (!(frmVouTemplate.FromHandle(this.tblVouTemplateRow_colsCurrencyCode.i_hWndFrame).GetAttributes(this.dfsCompany.Text, this.tblVouTemplateRow_colsCurrencyCode.Text, this.dfsCurrencyCode.Text, this.dfsCurrencyType.Text, this.dfdValidFrom.DateTime)))
                {
                    e.Return = false;
                    return;
                }
                this.ValidateCurrencyCode();

                if (!(Sal.IsNull(this.tblVouTemplateRow_colnCurrencyAmount)))
                {
                    // Recalculate accounting amount
                    this.tblVouTemplateRow_colsRateChanged.Text = "DUMMY";
                    if (!(Sal.SendMsg(this.tblVouTemplateRow_colnCurrencyRate, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, 0, 0)))
                    {
                        // Don't translate this message, this message only for programmer not user
                        Ifs.Fnd.ApplicationForms.Int.AlertBox("Design time error in colCurrencyCode !", Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
                        e.Return = false;
                        return;
                    }
                }
                else
                {
                    Sal.SendMsg(this.tblVouTemplateRow_colnCurrencyRate, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 0, this.tblVouTemplateRow_colnCurrencyRate.Number.ToString(this.tblVouTemplateRow_colsDecimalsInRate.Number).ToHandle());
                }

                this.tblVouTemplateRow_colnCurrencyRate.Number = frmVouTemplate.FromHandle(this.tblVouTemplateRow_colsCurrencyCode.i_hWndFrame).GetRate(this.dfsCompany.Text, this.tblVouTemplateRow_colsCurrencyCode.Text);
                this.tblVouTemplateRow_colnConversionFactor.Number = frmVouTemplate.FromHandle(this.tblVouTemplateRow_colsCurrencyCode.i_hWndFrame).i_nFinConversionFactor;
                tblVouTemplateRow_colnCurrencyRate.EditDataItemSetEdited();
                this.tblVouTemplateRow_colsRateChanged.Text = "FALSE";
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemLov event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVouTemplateRow_colsCurrencyCode_OnPM_DataItemLov(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.tblVouTemplateRow_colsCurrencyType.EditDataItemValueSet(0, ((SalString)frmVouTemplate.FromHandle(this.tblVouTemplateRow_colsCurrencyCode.i_hWndFrame).dfsCurrencyType.Text).ToHandle());
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemLov, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemZoom event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVouTemplateRow_colsCurrencyCode_OnPM_DataItemZoom(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                this.sTempLovReference = this.tblVouTemplateRow_colsCurrencyCode.p_sLovReference;
                this.tblVouTemplateRow_colsCurrencyCode.p_sLovReference = "CURRENCY_CODE(COMPANY)";
                this.bReturn = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom, Sys.wParam, Sys.lParam);
                this.tblVouTemplateRow_colsCurrencyCode.p_sLovReference = this.sTempLovReference;
                e.Return = this.bReturn;
                return;
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblVouTemplateRow_colnDebitCurrencyAmount_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblVouTemplateRow_colnDebitCurrencyAmount_OnPM_DataItemValidate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.tblVouTemplateRow_colnDebitCurrencyAmount_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVouTemplateRow_colnDebitCurrencyAmount_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.tblVouTemplateRow_colnDebitCurrencyAmount.Number != Sys.NUMBER_Null)
            {
                if (this.tblVouTemplateRow_colnDebitCurrencyAmount.Number < 0)
                {
                    this.tblVouTemplateRow_colnDebitCurrencyAmount.Number = -this.tblVouTemplateRow_colnDebitCurrencyAmount.Number;
                }
                if (this.tblVouTemplateRow_colsCorrection.Text == "Y")
                {
                    this.tblVouTemplateRow_colnDebitCurrencyAmount.Number = -this.tblVouTemplateRow_colnDebitCurrencyAmount.Number;
                }
            }
            if (Sal.IsNull(this.tblVouTemplateRow_colnCreditCurrencyAmount))
            {
                this.ValidateCurrencyCode();
                this.tblVouTemplateRow_colnDebitCurrencyAmount.Number = this.SetAnotherValue(this.tblVouTemplateRow_colnDebitCurrencyAmount.Number, this.tblVouTemplateRow_colnDebitAmount, this.tblVouTemplateRow_colsDecimalsInAmount.Number, this.tblVouTemplateRow_colsAccDecimalsInAmount.Number, "CURRENT_AMOUNT");
                if (!(Sal.IsNull(this.tblVouTemplateRow_colnCreditAmount)))
                {
                    Sal.SendMsg(this.tblVouTemplateRow_colnCreditAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, SalNumber.Null.ToString(0).ToHandle());
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
        private void tblVouTemplateRow_colnDebitCurrencyAmount_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if ((((SalString)this.tblVouTemplateRow_colsTransCode.Text).Trim().ToUpper() != "MANUAL") || !(Sal.IsNull(this.tblVouTemplateRow_colnCreditCurrencyAmount)))
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
        private void tblVouTemplateRow_colnCreditCurrencyAmount_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblVouTemplateRow_colnCreditCurrencyAmount_OnPM_DataItemValidate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.tblVouTemplateRow_colnCreditCurrencyAmount_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVouTemplateRow_colnCreditCurrencyAmount_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.tblVouTemplateRow_colnCreditCurrencyAmount.Number != Sys.NUMBER_Null)
            {
                if (this.tblVouTemplateRow_colnCreditCurrencyAmount.Number < 0)
                {
                    this.tblVouTemplateRow_colnCreditCurrencyAmount.Number = -this.tblVouTemplateRow_colnCreditCurrencyAmount.Number;
                }
                if (this.tblVouTemplateRow_colsCorrection.Text == "Y")
                {
                    this.tblVouTemplateRow_colnCreditCurrencyAmount.Number = -this.tblVouTemplateRow_colnCreditCurrencyAmount.Number;
                }
            }
            if (Sal.IsNull(this.tblVouTemplateRow_colnDebitCurrencyAmount))
            {
                this.ValidateCurrencyCode();
                this.tblVouTemplateRow_colnCreditCurrencyAmount.Number = -this.SetAnotherValue(-this.tblVouTemplateRow_colnCreditCurrencyAmount.Number, this.tblVouTemplateRow_colnCreditAmount, this.tblVouTemplateRow_colsDecimalsInAmount.Number, this.tblVouTemplateRow_colsAccDecimalsInAmount.Number, "CURRENT_AMOUNT");
                if (!(Sal.IsNull(this.tblVouTemplateRow_colnDebitAmount)))
                {
                    Sal.SendMsg(this.tblVouTemplateRow_colnDebitAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, SalNumber.Null.ToString(0).ToHandle());
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
        private void tblVouTemplateRow_colnCreditCurrencyAmount_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if ((((SalString)this.tblVouTemplateRow_colsTransCode.Text).Trim().ToUpper() != "MANUAL") || !(Sal.IsNull(this.tblVouTemplateRow_colnDebitCurrencyAmount)))
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
        private void tblVouTemplateRow_colnCurrencyAmount_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblVouTemplateRow_colnCurrencyAmount_OnPM_DataItemValidate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.tblVouTemplateRow_colnCurrencyAmount_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVouTemplateRow_colnCurrencyAmount_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.ValidateCurrencyCode();
            if (this.tblVouTemplateRow_colnCurrencyAmount.Number < 0)
            {
                if (this.tblVouTemplateRow_colsCorrection.Text == "Y")
                {
                    this.tblVouTemplateRow_colnDebitCurrencyAmount.Number = this.SetAnotherValue(this.tblVouTemplateRow_colnCurrencyAmount.Number, this.tblVouTemplateRow_colnDebitAmount, this.tblVouTemplateRow_colsDecimalsInAmount.Number, this.tblVouTemplateRow_colsAccDecimalsInAmount.Number, "CURRENT_AMOUNT");
                    this.tblVouTemplateRow_colnDebitCurrencyAmount.EditDataItemSetEdited();
                    Sal.SendMsg(this.tblVouTemplateRow_colnCreditCurrencyAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, SalNumber.Null.ToString(0).ToHandle());
                    Sal.SendMsg(this.tblVouTemplateRow_colnCreditAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, SalNumber.Null.ToString(0).ToHandle());
                }
                else
                {
                    this.tblVouTemplateRow_colnCreditCurrencyAmount.Number = -this.SetAnotherValue(this.tblVouTemplateRow_colnCurrencyAmount.Number, this.tblVouTemplateRow_colnCreditAmount, this.tblVouTemplateRow_colsDecimalsInAmount.Number, this.tblVouTemplateRow_colsAccDecimalsInAmount.Number, "CURRENT_AMOUNT");
                    this.tblVouTemplateRow_colnCreditCurrencyAmount.EditDataItemSetEdited();
                    Sal.SendMsg(this.tblVouTemplateRow_colnDebitCurrencyAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, SalNumber.Null.ToString(0).ToHandle());
                    Sal.SendMsg(this.tblVouTemplateRow_colnDebitAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, SalNumber.Null.ToString(0).ToHandle());
                }
            }
            else
            {
                if ((this.tblVouTemplateRow_colsCorrection.Text == "Y") && !(this.tblVouTemplateRow_colnCurrencyAmount.Number == 0 && this.tblVouTemplateRow_colnDebitCurrencyAmount.Number == 0))
                {
                    this.tblVouTemplateRow_colnCreditCurrencyAmount.Number = -this.SetAnotherValue(this.tblVouTemplateRow_colnCurrencyAmount.Number, this.tblVouTemplateRow_colnCreditAmount, this.tblVouTemplateRow_colsDecimalsInAmount.Number, this.tblVouTemplateRow_colsAccDecimalsInAmount.Number, "CURRENT_AMOUNT");
                    this.tblVouTemplateRow_colnCreditCurrencyAmount.EditDataItemSetEdited();
                    Sal.SendMsg(this.tblVouTemplateRow_colnDebitCurrencyAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, SalNumber.Null.ToString(0).ToHandle());
                    Sal.SendMsg(this.tblVouTemplateRow_colnDebitAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, SalNumber.Null.ToString(0).ToHandle());
                }
                else if (!(this.tblVouTemplateRow_colnCurrencyAmount.Number == 0 && this.tblVouTemplateRow_colnCreditCurrencyAmount.Number == 0))
                {
                    this.tblVouTemplateRow_colnDebitCurrencyAmount.Number = this.SetAnotherValue(this.tblVouTemplateRow_colnCurrencyAmount.Number, this.tblVouTemplateRow_colnDebitAmount, this.tblVouTemplateRow_colsDecimalsInAmount.Number, this.tblVouTemplateRow_colsAccDecimalsInAmount.Number, "CURRENT_AMOUNT");
                    this.tblVouTemplateRow_colnDebitCurrencyAmount.EditDataItemSetEdited();
                    Sal.SendMsg(this.tblVouTemplateRow_colnCreditCurrencyAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, SalNumber.Null.ToString(0).ToHandle());
                    Sal.SendMsg(this.tblVouTemplateRow_colnCreditAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, SalNumber.Null.ToString(0).ToHandle());
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
        private void tblVouTemplateRow_colnCurrencyAmount_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (((SalString)this.tblVouTemplateRow_colsTransCode.Text).Trim().ToUpper() != "MANUAL")
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
        private void tblVouTemplateRow_colnCurrencyRate_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblVouTemplateRow_colnCurrencyRate_OnPM_DataItemValidate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.tblVouTemplateRow_colnCurrencyRate_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVouTemplateRow_colnCurrencyRate_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if ((this.tblVouTemplateRow_colnCurrencyRate.Number <= 0) && (this.tblVouTemplateRow_colnCurrencyRate.Number != Sys.NUMBER_Null))
            {
                Ifs.Fnd.ApplicationForms.Int.AlertBox(Ifs.Application.Accrul.Properties.Resources.ACC_ERROR_NegCurrRate, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
                Sal.SetFocus(this.tblVouTemplateRow_colnCurrencyRate.i_hWndSelf);
                e.Return = Sys.VALIDATE_Cancel;
                return;
            }
            this.tblVouTemplateRow_colnCurrencyRate.Number = this.RoundedDecimals(this.tblVouTemplateRow_colnCurrencyRate.Number, this.tblVouTemplateRow_colsDecimalsInRate.Number);
            if (this.tblVouTemplateRow_colnCurrencyAmount.Number != 0 && this.tblVouTemplateRow_colnCurrencyAmount.Number != Sys.NUMBER_Null)
            {
                if (this.tblVouTemplateRow_colsRateChanged.Text != "DUMMY")
                {
                    this.tblVouTemplateRow_colsRateChanged.Text = "TRUE";
                }
                this.tblVouTemplateRow_colnCurrencyRate.Number = this.SetAnotherValue(this.tblVouTemplateRow_colnCurrencyRate.Number, this.tblVouTemplateRow_colnCurrencyAmount, this.tblVouTemplateRow_colsAccDecimalsInAmount.Number, this.tblVouTemplateRow_colsDecimalsInAmount.Number, "RATE");
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVouTemplateRow_colnCurrencyRate_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            // Bug 106222, Modified condition
            if ((((SalString)this.tblVouTemplateRow_colsTransCode.Text).Trim().ToUpper() != "MANUAL") || (((SalString)this.tblVouTemplateRow_colsCurrencyCode.Text).Trim().ToUpper() == ((SalString)this.dfsCurrencyCode.Text).Trim().ToUpper()))
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
        private void tblVouTemplateRow_colnDebitAmount_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblVouTemplateRow_colnDebitAmount_OnPM_DataItemValidate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.tblVouTemplateRow_colnDebitAmount_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVouTemplateRow_colnDebitAmount_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            string stmt = string.Format(@"{0} := &AO.Company_Finance_API.Get_Currency_Code({1} IN )",
                                            this.QualifiedVarBindName("lsCurrencyCode"),
                                            this.tblVouTemplateRow_colsCompany.QualifiedBindName);

            DbPLSQLBlock(stmt);
                
           
            if (this.tblVouTemplateRow_colnDebitAmount.Number != Sys.NUMBER_Null)
            {
                if (this.tblVouTemplateRow_colnDebitAmount.Number < 0)
                {
                    this.tblVouTemplateRow_colnDebitAmount.Number = -this.tblVouTemplateRow_colnDebitAmount.Number;
                }
                if (this.tblVouTemplateRow_colsCorrection.Text == "Y")
                {
                    this.tblVouTemplateRow_colnDebitAmount.Number = -this.tblVouTemplateRow_colnDebitAmount.Number;
                }
            }
            if (Sal.IsNull(this.tblVouTemplateRow_colnCreditAmount))
            {
                this.tblVouTemplateRow_colnDebitAmount.Number = this.SetAnotherValue(this.tblVouTemplateRow_colnDebitAmount.Number, this.tblVouTemplateRow_colnDebitCurrencyAmount, this.tblVouTemplateRow_colsAccDecimalsInAmount.Number, this.tblVouTemplateRow_colsDecimalsInAmount.Number, "ACCOUNTING_AMOUNT");
                if (this.tblVouTemplateRow_colsCurrencyCode.Text == this.lsCurrencyCode)
                {
                    this.tblVouTemplateRow_colnDebitCurrencyAmount.Number = this.tblVouTemplateRow_colnDebitAmount.Number;
                    this.tblVouTemplateRow_colnDebitCurrencyAmount.EditDataItemSetEdited();
                    this.tblVouTemplateRow_colnCurrencyAmount.Number = this.tblVouTemplateRow_colnDebitAmount.Number;
                    this.tblVouTemplateRow_colnCurrencyAmount.EditDataItemSetEdited();
                    this.tblVouTemplateRow_colnCreditCurrencyAmount.Number = Sys.NUMBER_Null;
                    this.tblVouTemplateRow_colnCreditCurrencyAmount.EditDataItemSetEdited();
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
        private void tblVouTemplateRow_colnDebitAmount_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if ((((SalString)this.tblVouTemplateRow_colsTransCode.Text).Trim().ToUpper() != "MANUAL") || !(Sal.IsNull(this.tblVouTemplateRow_colnCreditAmount)))
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
        private void tblVouTemplateRow_colnCreditAmount_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblVouTemplateRow_colnCreditAmount_OnPM_DataItemValidate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.tblVouTemplateRow_colnCreditAmount_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVouTemplateRow_colnCreditAmount_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            DbPLSQLBlock(@"{0} := &AO.Company_Finance_API.Get_Currency_Code({1} IN )", this.QualifiedVarBindName("lsCurrencyCode"), this.tblVouTemplateRow_colsCompany.QualifiedBindName);
     
            if (this.tblVouTemplateRow_colnCreditAmount.Number != Sys.NUMBER_Null)
            {
                if (this.tblVouTemplateRow_colnCreditAmount.Number < 0)
                {
                    this.tblVouTemplateRow_colnCreditAmount.Number = -this.tblVouTemplateRow_colnCreditAmount.Number;
                }
                if (this.tblVouTemplateRow_colsCorrection.Text == "Y")
                {
                    this.tblVouTemplateRow_colnCreditAmount.Number = -this.tblVouTemplateRow_colnCreditAmount.Number;
                }
            }
            if (Sal.IsNull(this.tblVouTemplateRow_colnDebitAmount))
            {
                this.tblVouTemplateRow_colnCreditAmount.Number = -this.SetAnotherValue(-this.tblVouTemplateRow_colnCreditAmount.Number, this.tblVouTemplateRow_colnCreditCurrencyAmount, this.tblVouTemplateRow_colsAccDecimalsInAmount.Number, this.tblVouTemplateRow_colsDecimalsInAmount.Number, "ACCOUNTING_AMOUNT");
                if (this.tblVouTemplateRow_colsCurrencyCode.Text == this.lsCurrencyCode)
                {
                    this.tblVouTemplateRow_colnCreditCurrencyAmount.Number = this.tblVouTemplateRow_colnCreditAmount.Number;
                    this.tblVouTemplateRow_colnCreditCurrencyAmount.EditDataItemSetEdited();
                    this.tblVouTemplateRow_colnCurrencyAmount.Number = -this.tblVouTemplateRow_colnCreditAmount.Number;
                    this.tblVouTemplateRow_colnCurrencyAmount.EditDataItemSetEdited();
                    this.tblVouTemplateRow_colnDebitCurrencyAmount.Number = Sys.NUMBER_Null;
                    this.tblVouTemplateRow_colnDebitCurrencyAmount.EditDataItemSetEdited();
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
        private void tblVouTemplateRow_colnCreditAmount_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if ((((SalString)this.tblVouTemplateRow_colsTransCode.Text).Trim().ToUpper() != "MANUAL") || !(Sal.IsNull(this.tblVouTemplateRow_colnDebitAmount)))
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
        private void tblVouTemplateRow_colnAmount_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblVouTemplateRow_colnAmount_OnPM_DataItemValidate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.tblVouTemplateRow_colnAmount_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVouTemplateRow_colnAmount_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            DbPLSQLBlock(@"{0} := &AO.Company_Finance_API.Get_Currency_Code({1} IN )", this.QualifiedVarBindName("lsCurrencyCode"), this.tblVouTemplateRow_colsCompany.QualifiedBindName);
          
            if (this.tblVouTemplateRow_colnAmount.Number < 0)
            {
                if (this.tblVouTemplateRow_colsCorrection.Text == "Y")
                {
                    this.tblVouTemplateRow_colnDebitAmount.Number = this.SetAnotherValue(this.tblVouTemplateRow_colnAmount.Number, this.tblVouTemplateRow_colnDebitCurrencyAmount, this.tblVouTemplateRow_colsAccDecimalsInAmount.Number, this.tblVouTemplateRow_colsDecimalsInAmount.Number, "ACCOUNTING_AMOUNT");
                    this.tblVouTemplateRow_colnDebitAmount.EditDataItemSetEdited();
                    Sal.SendMsg(this.tblVouTemplateRow_colnCreditAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, SalNumber.Null.ToString(0).ToHandle());
                }
                else
                {
                    this.tblVouTemplateRow_colnCreditAmount.Number = -this.SetAnotherValue(this.tblVouTemplateRow_colnAmount.Number, this.tblVouTemplateRow_colnCreditCurrencyAmount, this.tblVouTemplateRow_colsAccDecimalsInAmount.Number, this.tblVouTemplateRow_colsDecimalsInAmount.Number, "ACCOUNTING_AMOUNT");
                    this.tblVouTemplateRow_colnCreditAmount.EditDataItemSetEdited();
                    Sal.SendMsg(this.tblVouTemplateRow_colnDebitAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, SalNumber.Null.ToString(0).ToHandle());
                    if (this.tblVouTemplateRow_colsCurrencyCode.Text == this.lsCurrencyCode)
                    {
                        this.tblVouTemplateRow_colnCreditCurrencyAmount.Number = this.tblVouTemplateRow_colnCreditAmount.Number;
                        this.tblVouTemplateRow_colnCreditCurrencyAmount.EditDataItemSetEdited();
                        this.tblVouTemplateRow_colnCurrencyAmount.Number = -this.tblVouTemplateRow_colnCreditAmount.Number;
                        this.tblVouTemplateRow_colnCurrencyAmount.EditDataItemSetEdited();
                        this.tblVouTemplateRow_colnDebitCurrencyAmount.Number = Sys.NUMBER_Null;
                        this.tblVouTemplateRow_colnDebitCurrencyAmount.EditDataItemSetEdited();
                    }
                }
            }
            else
            {
                if ((this.tblVouTemplateRow_colsCorrection.Text == "Y") && !(this.tblVouTemplateRow_colnAmount.Number == 0 && this.tblVouTemplateRow_colnDebitAmount.Number == 0))
                {
                    this.tblVouTemplateRow_colnCreditAmount.Number = -this.SetAnotherValue(this.tblVouTemplateRow_colnAmount.Number, this.tblVouTemplateRow_colnCreditCurrencyAmount, this.tblVouTemplateRow_colsAccDecimalsInAmount.Number, this.tblVouTemplateRow_colsDecimalsInAmount.Number, "ACCOUNTING_AMOUNT");
                    this.tblVouTemplateRow_colnCreditAmount.EditDataItemSetEdited();
                    Sal.SendMsg(this.tblVouTemplateRow_colnDebitAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, SalNumber.Null.ToString(0).ToHandle());
                }
                else if (!(this.tblVouTemplateRow_colnAmount.Number == 0 && this.tblVouTemplateRow_colnCreditAmount.Number == 0))
                {
                    this.tblVouTemplateRow_colnDebitAmount.Number = this.SetAnotherValue(this.tblVouTemplateRow_colnAmount.Number, this.tblVouTemplateRow_colnDebitCurrencyAmount, this.tblVouTemplateRow_colsAccDecimalsInAmount.Number, this.tblVouTemplateRow_colsDecimalsInAmount.Number, "ACCOUNTING_AMOUNT");
                    this.tblVouTemplateRow_colnDebitAmount.EditDataItemSetEdited();
                    Sal.SendMsg(this.tblVouTemplateRow_colnCreditAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, SalNumber.Null.ToString(0).ToHandle());
                    if (this.tblVouTemplateRow_colsCurrencyCode.Text == this.lsCurrencyCode)
                    {
                        this.tblVouTemplateRow_colnDebitCurrencyAmount.Number = this.tblVouTemplateRow_colnDebitAmount.Number;
                        this.tblVouTemplateRow_colnDebitCurrencyAmount.EditDataItemSetEdited();
                        this.tblVouTemplateRow_colnCurrencyAmount.Number = this.tblVouTemplateRow_colnDebitAmount.Number;
                        this.tblVouTemplateRow_colnCurrencyAmount.EditDataItemSetEdited();
                        this.tblVouTemplateRow_colnCreditCurrencyAmount.Number = Sys.NUMBER_Null;
                        this.tblVouTemplateRow_colnCreditCurrencyAmount.EditDataItemSetEdited();
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
        private void tblVouTemplateRow_colnAmount_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (((SalString)this.tblVouTemplateRow_colsTransCode.Text).Trim().ToUpper() != "MANUAL")
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
        private void tblVouTemplateRow_colnQuantityQ_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.tblVouTemplateRow_colnQuantityQ_OnSAM_SetFocus(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVouTemplateRow_colnQuantityQ_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            SalString sMyValueQuantity = this.tblVouTemplateRow_colnQuantityQ.Number.ToString(0);
            if (this.CodePartSetFocus(this.tblVouTemplateRow_colnQuantityQ.i_hWndSelf, "Q", sMyValueQuantity))
            {
                Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
                e.Return = true;
                return;
            }
            e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblVouTemplateRow_colsTextT_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.tblVouTemplateRow_colsTextT_OnSAM_SetFocus(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVouTemplateRow_colsTextT_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.CodePartSetFocus(this.tblVouTemplateRow_colsTextT.i_hWndSelf, "T", this.tblVouTemplateRow_colsTextT.Text))
            {
                Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
                e.Return = true;
                return;
            }
            e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblVouTemplateRow_colsCodePart_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemNew:
                    e.Handled = true;
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
        private void tblVouTemplateRow_colnProjectActivityId_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.tblVouTemplateRow_colnProjectActivityId_OnSAM_SetFocus(sender, e);
                    break;

                // Bug 96016,Begin

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.tblVouTemplateRow_colnProjectActivityId_OnPM_DataItemQueryEnabled(sender, e);
                    break;

                // Bug 96016,End
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVouTemplateRow_colnProjectActivityId_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            // Bug 102101, Begin Added new function to get ProjectActivityId
            if ((this.tblVouTemplateRow_colnProjectActivityId.Number == Sys.NUMBER_Null) && (this.tblVouTemplateRow_colProjectActivityIdEnabled.Text == Sys.STRING_Null))
            {
                this.EnableSeqId();
            }
            // Bug 102101, End
            // Bug 102101, Begin
            if (Sal.IsNull(this.tblVouTemplateRow_colnProjectActivityId) || this.tblVouTemplateRow_colnProjectActivityId.Number == 0)
            {

                if (this.tblVouTemplateRow_colProjectActivityIdEnabled.Text == "Y" && this.sProjectOrigin != "FINPROJECT")
                {
                    // Bug 96016,Removed code line
                    this.SetValueOfProjectID();
                    e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
                    return;
                }
                // Bug 96016,Removed code line
                System.Windows.Forms.SendKeys.Send("{TAB}");
            }
            // Bug 102101, End
            this.SetValueOfProjectID();
            e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVouTemplateRow_colnProjectActivityId_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.IsNull(this.tblVouTemplateRow_colnProjectActivityId))
            {
                if (SalString.FromHandle(this.tblVouTemplateRow_colProjectActivityIdEnabled.EditDataItemValueGet()) == "Y")
                {
                    if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsViewAvailable("PROJECT_ACTIVITY_POSTABLE")))
                    {
                        e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                        return;
                    }
                    else
                    {
                        e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled, Sys.wParam, Sys.lParam);
                        return;
                    }
                }
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                return;
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }
        #endregion

        #region Window Events

        private void tblVouTemplateRow_DataRecordGetDefaultsEvent(object sender, FndReturnEventArgsSalBoolean e)
        {
            e.Handled = true;
            e.ReturnValue = this.DataRecordGetDefaults();
        }

        private void tblVouTemplateRow_EnableDisableProjectActivityIdEvent(object sender, cChildTableFin.cChildTableFinEventArgs e)
        {
            e.Handled = true;
            e.ReturnValue = this.EnableDisableProjectActivityId(e.sCodePartValue);
        }
        #endregion
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

        private void menuItem_Change_2_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = this.ChangeCompany(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem_Change_2_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            this.ChangeCompany(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        #endregion       

    }
}
