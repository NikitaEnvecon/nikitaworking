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
// Date    Assignee  Bug          History
// 120814  CLSTLK    Bug 104246   Corrected in frmMCVoucherRow, added error message for currency_code validation. 
// 130307  Machlk    Bug 107962   Fixed the document connections from docman.
// 140417  Shhelk    PBFI-5948    Removed unnessary sActiveCompany and sOldValue variables and tblVoucherRow_colsCompany_OnSAM_SetFocus methods,
//                                re-wrote tblVoucherRow_colsCompany_OnPM_DataItemValidate method instead of tblVoucherRow_colsCompany_OnSAM_Validate. 
// 140418  Nirylk    PBFI-5614    Bug 100161 merged. Subscribed to WindowActions of tblVoucherRow_colsDeliveryTypeId
// 160104  CLSTLK    Bug 125584   Merged. Modified ClearCompanyData() to get relevant data related to voucher company when duplicating voucher row.
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
using System.Collections.Generic;

namespace Ifs.Application.Accrul
{
	
	/// <summary>
	/// </summary>
    // Bug 107962 Begin
    [FndWindowRegistration("MULTI_COMPANY_VOUCHER_ROW2", "MultiCompanyVoucherRow", FndWindowRegistrationFlags.HomePage)]
    // Bug 107962 End
	public partial class frmMCVoucherRow : cFormWindowFin
	{
		#region Window Variables
		public cCache CacheInfo = new cCache();
		public SalString sProjectOriginGlobal = "";
		public SalNumber nActCurrencyRate = 0;
		public cMessage Msg = new cMessage();
        // Bug 107962 Begin
        public SalString sFromDocman = "";
        // Bug 107962 End
        #endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		public frmMCVoucherRow()
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
		public new static frmMCVoucherRow FromHandle(SalWindowHandle handle)
		{
			return ((frmMCVoucherRow)SalWindow.FromHandle(handle, typeof(frmMCVoucherRow)));
		}
		#endregion
		
		#region Methods
        // Bug 107962 Begin
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
            SalNumber nItemIndexRowNo = 0;
            SalNumber nItemIndexVouCompany = 0;
            SalNumber nRowCounter = 0;
            SalNumber nRows = 0;
            SalNumber nRC = 0;
            SalString sTmp1 = "";
            SalString sTmp2 = "";
            SalString sTmp3 = "";
            SalString sTmp4 = "";
            SalString sTmp5 = "";
            SalString sUserWhere = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                SetWindowTitle();
                sFromDocman = "FALSE";
                if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.RecCountGet() > 0)
                {
                    if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.SourceNameGet() == "DocReferenceObject")
                    {
                        sFromDocman = "TRUE";
                        if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemIndexGet("COMPANY") >= 0)
                        {
                            Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemValueStrGet(Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemIndexGet("COMPANY"), 0, ref i_sCompany);
                            SetWindowTitle();
                        }
                        Sal.WaitCursor(true);
                        if (nItemIndex != Ifs.Fnd.ApplicationForms.Const.DTTRF_ColumnNotFound)
                        {
                            nRows = Ifs.Fnd.ApplicationForms.Var.DataTransfer.RecCountGet();
                            // Get Column Positions
                            nItemIndexVouNo = Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemIndexGet("VOUCHER_NO");
                            nItemIndexVouType = Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemIndexGet("VOUCHER_TYPE");
                            nItemIndexVouYear = Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemIndexGet("ACCOUNTING_YEAR");
                            nItemIndexRowNo = Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemIndexGet("ROW_NO");
                            sUserWhere = "";
                            nRowCounter = 0;
                            // Build Where-statement dynamic
                            while (nRowCounter <= nRows - 1)
                            {
                                nRC = Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemValueStrGet(nItemIndexVouType, nRowCounter, ref sTmp1);
                                nRC = Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemValueStrGet(nItemIndexVouNo, nRowCounter, ref sTmp2);
                                nRC = Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemValueStrGet(nItemIndexVouYear, nRowCounter, ref sTmp3);
                                nRC = Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemValueStrGet(nItemIndexRowNo, nRowCounter, ref sTmp4);
                                sUserWhere = sUserWhere + " COMPANY = " + "\'" + i_sCompany + "\'" + " AND VOUCHER_TYPE = " + "\'" + sTmp1 + "\'" + " AND VOUCHER_NO = " + "\'" + sTmp2 + "\'" + " AND ACCOUNTING_YEAR = " + "\'" + sTmp3 + "\'" + " AND ROW_NO = " + "\'" +
                                sTmp4 + "\'";
                                nRowCounter = nRowCounter + 1;
                                if (nRowCounter < nRows)
                                {
                                    sUserWhere = sUserWhere + " OR ";
                                }
                            }
                            Sal.SendMsg(frmMCVoucherRow.FromHandle(i_hWndFrame).tblVoucherRow, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceUserWhere, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, sUserWhere.ToHandle());
                            DataSourcePopulate(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Sys.lParam);
                        }
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();
                        Sal.WaitCursor(false);
                    }
                }
                if (sFromDocman == "TRUE")
                {
                    Sal.HideWindowAndLabel(cmbsVoucherCompany);
                    Sal.HideWindowAndLabel(dfsVCCurrency);
                    Sal.HideWindowAndLabel(dfnCurrencyBalance);
                    Sal.HideWindowAndLabel(dfnBalance);
                    return true;
                }
                else
                {
                    Sal.ShowWindowAndLabel(cmbsVoucherCompany);
                    Sal.ShowWindowAndLabel(dfsVCCurrency);
                    Sal.ShowWindowAndLabel(dfnCurrencyBalance);
                    Sal.ShowWindowAndLabel(dfnBalance);
                    return base.Activate(URL);
                }
            }
            #endregion
        }
        // Bug 107962 End
		
		/// <summary>
		/// Applications and the framework call the DataSourceActivate function
		/// to indicate that a data source has been activated by the user.
		/// COMMENTS:
		/// Typically, a data source is activated when a window or a tab is activated.
		/// </summary>
		/// <returns></returns>
		public new SalNumber DataSourceActivate()
		{
			#region Local Variables
			SalNumber nPosCompany = 0;
			SalNumber nRow = 0;
			SalWindowHandle hWndCol = SalWindowHandle.Null;
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				((cDataSource)this).DataSourceActivate();
				nPosCompany = Sal.TblQueryColumnPos(tblVoucherRow_colsCompany);
				nRow = Sal.TblQueryContext(tblVoucherRow);
				hWndCol = Sal.TblGetColumnWindow(tblVoucherRow, nPosCompany, Sys.COL_GetPos);
				Sal.TblSetFocusCell(tblVoucherRow, nRow, hWndCol, 0, 1);
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber GetCurrencyCode()
		{
		    if (!(DbPLSQLBlock(@"{0} := &AO.COMPANY_FINANCE_API.Get_Currency_Code({1} IN);",this.dfsVCCurrency.QualifiedBindName, this.QualifiedVarBindName("cmbsVoucherCompany") ))) 
		    {
			    return false;
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
		private void frmMCVoucherRow_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Const.PAM_ShowInternalCP:
					e.Handled = true;
					e.Return = true;
					return;
                // Bug 107962 Begin
                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove:
                    this.frmMCVoucherRow_OnPM_DataRecordRemove(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew:
                    this.frmMCVoucherRow_OnPM_DataRecordNew(sender, e);
                    break;
                // Bug 107962 End
			}
			#endregion
		}
        // Bug 107962 Begin
        /// <summary>
        /// PM_DataRecordRemove event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmMCVoucherRow_OnPM_DataRecordRemove(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.sFromDocman == "TRUE")
            {
                e.Return = false;
                return;
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataRecordNew event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmMCVoucherRow_OnPM_DataRecordNew(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.sFromDocman == "TRUE")
            {
                e.Return = false;
                return;
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }
        // Bug 107962 End
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void cmbsVoucherCompany_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Click:
					this.cmbsVoucherCompany_OnSAM_Click(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_Click event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cmbsVoucherCompany_OnSAM_Click(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.GetCurrencyCode();
			this.UpdateBalanceList();
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
				case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove:
					this.tblVoucherRow_OnPM_DataRecordRemove(sender, e);
					break;

                // Bug 125584, Removed PM_DataRecordDuplicate;

                //case Sys.SAM_AnyEdit:
                //    this.bDuplicated = false;
                //    break;
		
				case Const.PAM_GetIntPostingInfo:
					this.tblVoucherRow_OnPAM_GetIntPostingInfo(sender, e);
					break;
				
				case Const.PAM_GetMultiCompany:
					e.Handled = true;
					e.Return = ((SalString)this.tblVoucherRow_colsCompany.Text).ToHandle();
					return;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_User:
					e.Handled = true;
					cChildTableFin.sUserName = this.sUserName[1].Trim();
					break;
				
				// Bug 81052, Reset the required code string if only a code part is entered.
				
				case Const.PAM_ValidateCodePartValues:
					this.tblVoucherRow_OnPAM_ValidateCodePartValues(sender, e);
					break;
				
				// Bug 81052, End.
				
				case Ifs.Fnd.ApplicationForms.Const.PM_AttachmentKeysGet:
					this.tblVoucherRow_OnPM_AttachmentKeysGet(sender, e);
					break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordPaste:
                    this.tblVoucherPosting_OnPM_DataRecordPaste(sender, e);
                    break;

                case Const.PAM_CodePartBlocked:
                    e.Handled = true;
                    e.Return = this.CodePartBlocked(SalString.FromHandle(Sys.wParam));
                    return;
			}
			#endregion
		}

        private void tblVoucherPosting_OnPM_DataRecordPaste(object sender, WindowActionsEventArgs e)
        { 
            e.Handled = true;

            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire)
            {
                e.Return = ((bool)( Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordPaste, Sys.wParam, Sys.lParam))) &&  (((SalString)tblVoucherRow_colsTransCode.Text).Trim().ToUpper() == "MANUAL");
            }
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                bIsPaste = true;
                SalBoolean bOk = ((bool)(Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordPaste, Sys.wParam, Sys.lParam)));
                SetFieldEdit();
                bIsPaste = false;
                // Bug 125584 Removed tblVoucherRow_colsDuplicateRow               
                e.Return = bOk;
            }

            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_GetType)
            {
                e.Return = Ifs.Fnd.ApplicationForms.Const.CHILDTYPE_SourceMethod;
            }
        }
		
		/// <summary>
		/// PM_DataRecordRemove event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblVoucherRow_OnPM_DataRecordRemove(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			// Bug 107962 Begin
            if (this.sFromDocman == "TRUE")
            {
                e.Return = false;
                return;
            }
            else
            {
            // Bug 107962 End
                if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove, Sys.wParam, Sys.lParam))
                {
                    if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
                    {
                        this.UpdateCompanyList();
                        this.UpdateBalanceList();
                    }
                    e.Return = true;
                    return;
                }
                e.Return = false;
                return;
            // Bug 107962 Begin
            }
            // Bug 107962 End
			#endregion
		}

        // Bug 125584, Removed OnPM_DataRecordDuplicate
		
		/// <summary>
		/// PAM_GetIntPostingInfo event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblVoucherRow_OnPAM_GetIntPostingInfo(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.sMessage.Construct();
			this.sMessage.AddAttribute("COMPANY", this.p_sCompany);
			this.sMessage.AddAttribute("LEDGER_ID", this.p_sLedger);
			this.sMessage.AddAttribute("VOUCHER_TYPE", this.tblVoucherRow_colsVoucherType.Text);
			this.sMessage.AddAttribute("ACCOUNT", this.p_sAccount);
			this.sMessage.AddAttribute("CORRECTION", "N");
			this.sTempVouDate = frmMCEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(this.i_hWndParent)).dfdVoucherDate.DateTime.ToString();
			this.sMessage.AddAttribute("VOUCHER_DATE", this.sTempVouDate);
			this.sMessage.AddAttribute("ACCOUNTING_YEAR", this.tblVoucherRow_colnAccountingYear.Number.ToString(0));
			this.sMessage.AddAttribute("VOUCHER_NO", this.tblVoucherRow_colnVoucherNo.Number.ToString(0));
			this.sMessage.AddAttribute("REF_ROW_NO", this.p_nRefRowNo.ToString(0));
			this.sMessage.AddAttribute("AMOUNT", this.p_nAmount.ToString(frmMCEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(this.i_hWndFrame)).nDecimalsInAmount));
			this.sMessage.AddAttribute("CURRENCY_AMOUNT", this.p_nCurrencyAmount.ToString(frmMCEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(this.i_hWndFrame)).nDecimalsInAmount));
			this.sMessage.AddAttribute("CURRENCY_RATE", this.p_nCurrRate.ToString(9));
			this.sMessage.AddAttribute("INTERNAL_SEQ_NUMBER", this.p_nInternalSeq.ToString(0));
			this.sMessage.AddAttribute("CONV_FACTOR", frmMCVoucherRow.FromHandle(this.i_hWndFrame).i_nFinConversionFactor.ToString(0));
			// Bug 77430 Begin, Checked for the authorize level
			if (frmMCEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(this.i_hWndFrame)).sAuthLevel != "ApproveOnly") 
			{
				this.sMessage.AddAttribute("EDITABLE", "Y");
			}
			else
			{
				this.sMessage.AddAttribute("EDITABLE", "N");
			}
			// Bug 77430, End
			this.sMessage.AddAttribute("DECIMAL_TRANS_ROUND", this.tblVoucherRow_colnDecimalsInAmount.Number.ToString(0));
			this.sMessage.AddAttribute("DECIMAL_BASE_ROUND", this.tblVoucherRow_colnAccDecimalsInAmount.Number.ToString(0));
			// Bug 92040, Begin
			this.sMessage.AddAttribute("COMP_CURRENCY", frmMCEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(this.i_hWndFrame)).sCurrencyCode);
			this.sMessage.AddAttribute("CURRENCY", this.tblVoucherRow_colsCurrencyCode.Text);
			// Bug 92040, End
			this.sPackedMessage = this.sMessage.Pack();
			e.Return = this.sPackedMessage.ToHandle();
			return;
			#endregion
		}
		
		/// <summary>
		/// PAM_ValidateCodePartValues event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblVoucherRow_OnPAM_ValidateCodePartValues(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.IsNull(this.tblVoucherRow_colsAccount)) 
			{
				cChildTableFin.sRequiredString = SalString.Null;
			}
			e.Return = Sal.SendClassMessage(Const.PAM_ValidateCodePartValues, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
		
		/// <summary>
		/// PM_AttachmentKeysGet event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblVoucherRow_OnPM_AttachmentKeysGet(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.Msg.Construct();
			this.Msg.AddAttribute("ACCOUNTING_YEAR", Sal.WindowHandleToNumber(this.tblVoucherRow_colnAccountingYear).ToString(0));
			this.Msg.AddAttribute("COMPANY", Sal.WindowHandleToNumber(this.tblVoucherRow_colsParentCompany).ToString(0));
			this.Msg.AddAttribute("VOUCHER_NO", Sal.WindowHandleToNumber(this.tblVoucherRow_colnVoucherNo).ToString(0));
			this.Msg.AddAttribute("VOUCHER_TYPE", Sal.WindowHandleToNumber(this.tblVoucherRow_colsVoucherType).ToString(0));
			this.Msg.AddAttribute("ROW_NO", Sal.WindowHandleToNumber(this.tblVoucherRow_colnRowNo).ToString(0));
			e.Return = this.Msg.Pack().ToHandle();
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
        // Bug 107962 Begin
        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalBoolean vrtFrameStartupUser()
        {
            return this.FrameStartupUser();
        }
        // Bug 107962 End
		#endregion
		
		#region ChildTable-tblVoucherRow
			
		#region Window Variables
		public SalNumber nPrevRate = 0;
		public SalNumber nReturn = 0;
		public SalString sFormName = "";
		public SalString sParam = "";
		public SalNumber nRetVal = 0;
		public cMessage sMessage = new cMessage();
		public SalString p_sLedger = "";
		public SalString p_sCompany = "";
		public SalString p_sAccount = "";
		public SalNumber p_nRefRowNo = 0;
		public SalNumber p_nAmount = 0;
		public SalNumber p_nCurrencyAmount = 0;
		public SalNumber p_nInternalSeq = 0;
		public SalNumber p_nCurrRate = 0;
		public SalString sPackedMessage = "";
		public SalString sTempVouDate = "";
		public SalString sProjectOrigin = "";
		public SalString sMultipleTax = "";
		public SalString sFeeType = "";
		public SalArray<SalString> sRecords = new SalArray<SalString>();
		public SalArray<SalString> sUnits = new SalArray<SalString>();
		public SalArray<SalString> sUserName = new SalArray<SalString>();
		public SalBoolean bIsDuplicate = false;
		public SalBoolean bIsPaste = false;
		public SalArray<SalString> sItemNames = new SalArray<SalString>();
		public SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
		public SalArray<SalNumber> group_balance = new SalArray<SalNumber>();
		public SalArray<SalNumber> group_c_count = new SalArray<SalNumber>();
		public SalArray<SalNumber> group_d_count = new SalArray<SalNumber>();
		public SalArray<SalString> group_company = new SalArray<SalString>();
		#endregion
						
		#region Methods
			
		/// <summary>
		/// written one , just to check tax code validation and store in the cache
		/// </summary>
		/// <param name="sCompany"></param>
		/// <param name="sTaxCode"></param>
		/// <returns></returns>
		public virtual SalBoolean CheckTaxCode(SalString sCompany, SalString sTaxCode)
		{
			#region Local Variables
			SalString sReturnTaxCode = "";
			#endregion
				
			#region Actions
		
			sMultipleTax = SalString.Null;
			sFeeType = SalString.Null;
			// if taxcode exist in the cache then it takes from it rather going to db call for combination of " form name || company || taxcode "
			this.CacheInfo.SessionRetrieve(" frmMCVoucherRow.tblVoucherRow " + sCompany + sTaxCode, ref sReturnTaxCode);
			this.CacheInfo.SessionRetrieve(" frmMCVoucherRow.tblVoucherRow " + sCompany + sTaxCode + "MultipleTax", ref sMultipleTax);
			this.CacheInfo.SessionRetrieve(" frmMCVoucherRow.tblVoucherRow " + sCompany + sTaxCode + "FeeType", ref sFeeType);
			if (sReturnTaxCode == Ifs.Fnd.ApplicationForms.Const.strNULL) 
			{
				// if not exist in the cache then go to db call and check .

                IDictionary<string, string> namedBindVariables = new Dictionary<string, string>();
                namedBindVariables.Add("sMultipleTax", this.QualifiedVarBindName("sMultipleTax"));
                namedBindVariables.Add("sFeeType", this.QualifiedVarBindName("sFeeType"));
                namedBindVariables.Add("colsCompany", this.tblVoucherRow_colsCompany.QualifiedBindName);
                namedBindVariables.Add("colsOptionalCode", this.tblVoucherRow_colsOptionalCode.QualifiedBindName);
                namedBindVariables.Add("dfdVoucherDate", ":i_hWndParent.frmMCEntryVoucher.dfdVoucherDate");
				
				if (!(DbPLSQLBlock(@"&AO.Statutory_Fee_API.Exist({colsCompany} IN, 
                                                                 {colsOptionalCode} IN); 
                                     {sMultipleTax} := &AO.Statutory_Fee_API.Get_Multiple_Tax({colsCompany} IN, 
																							  {colsOptionalCode} IN); 
                                     &AO.Statutory_Fee_API.Get_Fee_Type({sFeeType} OUT, 
								                                        {colsCompany} IN, 
									                                    {colsOptionalCode} IN, 
									                                    {dfdVoucherDate} IN);",namedBindVariables))) 
				{
					return false;
				}
				else
				{
					// only okay taxcode values store in the cache..in order to retrieve if it call again.
					this.CacheInfo.SessionStore(" frmMCVoucherRow.tblVoucherRow " + sCompany + sTaxCode, sTaxCode);
					this.CacheInfo.SessionStore(" frmMCVoucherRow.tblVoucherRow " + sCompany + sTaxCode + "MultipleTax", sMultipleTax);
					this.CacheInfo.SessionStore(" frmMCVoucherRow.tblVoucherRow " + sCompany + sTaxCode + "FeeType", sFeeType);
				}
				
			}
			if ((sMultipleTax == "TRUE") || (sFeeType == "RDE")) 
			{
				sMultipleTax = SalString.Null;
				sFeeType = SalString.Null;
				Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_MultipleTax, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Warning, Ifs.Fnd.ApplicationForms.Const.WARNING_Ok);
				return false;
			}
			return true;
			
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
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean ClearCompanyData()
		{
            // Bug 125584 Begin Removed condition which checked colsDuplicateRow 
            // Refresh CodePart Information
            cColumnCodePartFin.sProjectCodePart = SalString.Null;
            frmMCVoucherRow.FromHandle(i_hWndFrame).RefreshCodePartInfo(tblVoucherRow_colsCompany.Text, cSessionManager.c_sDbPrefix);

			tblVoucherRow_colsAccount.EditDataItemValueSet(1, ((SalString)Ifs.Fnd.ApplicationForms.Const.strNULL).ToHandle());
		    tblVoucherRow_colsCodeB.EditDataItemValueSet(1, ((SalString)Ifs.Fnd.ApplicationForms.Const.strNULL).ToHandle());
		    tblVoucherRow_colsCodeC.EditDataItemValueSet(1, ((SalString)Ifs.Fnd.ApplicationForms.Const.strNULL).ToHandle());
		    tblVoucherRow_colsCodeD.EditDataItemValueSet(1, ((SalString)Ifs.Fnd.ApplicationForms.Const.strNULL).ToHandle());
		    tblVoucherRow_colsCodeE.EditDataItemValueSet(1, ((SalString)Ifs.Fnd.ApplicationForms.Const.strNULL).ToHandle());
		    tblVoucherRow_colsCodeF.EditDataItemValueSet(1, ((SalString)Ifs.Fnd.ApplicationForms.Const.strNULL).ToHandle());
		    tblVoucherRow_colsCodeG.EditDataItemValueSet(1, ((SalString)Ifs.Fnd.ApplicationForms.Const.strNULL).ToHandle());
		    tblVoucherRow_colsCodeH.EditDataItemValueSet(1, ((SalString)Ifs.Fnd.ApplicationForms.Const.strNULL).ToHandle());
		    tblVoucherRow_colsCodeI.EditDataItemValueSet(1, ((SalString)Ifs.Fnd.ApplicationForms.Const.strNULL).ToHandle());
		    tblVoucherRow_colsCodeJ.EditDataItemValueSet(1, ((SalString)Ifs.Fnd.ApplicationForms.Const.strNULL).ToHandle());
		    tblVoucherRow_colsProcessCode.EditDataItemValueSet(1, ((SalString)Ifs.Fnd.ApplicationForms.Const.strNULL).ToHandle());

            tblVoucherRow_colsAccountDesc.EditDataItemValueSet(1, ((SalString)Ifs.Fnd.ApplicationForms.Const.strNULL).ToHandle());
            tblVoucherRow_colsCodeBDesc.EditDataItemValueSet(1, ((SalString)Ifs.Fnd.ApplicationForms.Const.strNULL).ToHandle());
            tblVoucherRow_colsCodeCDesc.EditDataItemValueSet(1, ((SalString)Ifs.Fnd.ApplicationForms.Const.strNULL).ToHandle());
            tblVoucherRow_colsCodeDDesc.EditDataItemValueSet(1, ((SalString)Ifs.Fnd.ApplicationForms.Const.strNULL).ToHandle());
            tblVoucherRow_colsCodeEDesc.EditDataItemValueSet(1, ((SalString)Ifs.Fnd.ApplicationForms.Const.strNULL).ToHandle());
            tblVoucherRow_colsCodeFDesc.EditDataItemValueSet(1, ((SalString)Ifs.Fnd.ApplicationForms.Const.strNULL).ToHandle());
            tblVoucherRow_colsCodeGDesc.EditDataItemValueSet(1, ((SalString)Ifs.Fnd.ApplicationForms.Const.strNULL).ToHandle());
            tblVoucherRow_colsCodeHDesc.EditDataItemValueSet(1, ((SalString)Ifs.Fnd.ApplicationForms.Const.strNULL).ToHandle());
            tblVoucherRow_colsCodeIDesc.EditDataItemValueSet(1, ((SalString)Ifs.Fnd.ApplicationForms.Const.strNULL).ToHandle());
            tblVoucherRow_colsCodeJDesc.EditDataItemValueSet(1, ((SalString)Ifs.Fnd.ApplicationForms.Const.strNULL).ToHandle());

            IDictionary<string, string> namedBindVariables = new Dictionary<string, string>();
            namedBindVariables.Add("colsCompany", this.tblVoucherRow_colsCompany.QualifiedBindName);
            namedBindVariables.Add("colsCurrencyType", this.tblVoucherRow_colsCurrencyType.QualifiedBindName);
            namedBindVariables.Add("colsCurrencyCode", this.tblVoucherRow_colsCurrencyCode.QualifiedBindName);
            namedBindVariables.Add("dfdVoucherDate", ":i_hWndParent.frmMCEntryVoucher.dfdVoucherDate");

            SalString lsStmt = @"&AO.COMPANY_FINANCE_API.Exist({colsCompany} IN); 
                               {colsCurrencyCode}  := &AO.COMPANY_FINANCE_API.Get_Currency_Code({colsCompany} IN );
                               IF (&AO.Currency_Code_Api.Get_Valid_Emu({colsCompany} IN, {colsCurrencyCode} IN ,{dfdVoucherDate} IN) = 'TRUE') AND (TO_CHAR( {dfdVoucherDate}, 'YYYY-MM-DD' ) >= '1999-01-01') THEN 
	                               {colsCurrencyType} := &AO.Currency_Type_API.Get_Default_Euro_Type__({colsCompany} IN);
                               ELSE 
	                               {colsCurrencyType} := &AO.Currency_Type_API.Get_Default_Type({colsCompany} IN);
                               END IF;";

             if (!(DbPLSQLBlock(lsStmt, namedBindVariables)))
             {
                 return false;
             }
             tblVoucherRow_colsCurrencyCode.EditDataItemSetEdited();
             tblVoucherRow_colsCurrencyType.EditDataItemSetEdited();
             Sal.PostMsg(tblVoucherRow_colsCurrencyCode, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
			 return true;
            // Bug 125584 End
			
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
			// If ( tblVoucherRow_colsProjectActivityIdEnabled = 'Y' )  And SalIsNull( tblVoucherRow_colnProjectActivityId ) And Security.IsViewAvailable( 'PROJECT_ACTIVITY' )
			// Call DataRecordShowRequired( tblVoucherRow_colnProjectActivityId )
			// Return FALSE
			// (-)Ersruk Twin Peaks,Balance Sheet by Project, End
			if (tblVoucherRow_colnAmount.Number == 0) 
			{
                if (Sal.IsNull(tblVoucherRow_colnQuantity) || tblVoucherRow_colnQuantity.Number == 0) 
				{
					Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_MCVoEn_AlertQuantity, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
					return false;
				}
			}
			if (frmMCEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfsRowGroupValidation.Text == "Y") 
			{
				if (Sal.IsNull(tblVoucherRow_colnRowGroupId)) 
				{
					DataRecordShowRequired(tblVoucherRow_colnRowGroupId);
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
			
			#endregion
		}
			
		/// <summary>
		/// Get default values for new voucher row
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber DataRecordGetDefaults()
		{
			#region Local Variables
			SalNumber nAccountingPeriod = 0;
			SalString sCompnayOfRowGroup = "";
			#endregion
				
			#region Actions
			// Bug 76911, Begin, added frmMCEntryVoucher, before dfsCompany
			tblVoucherRow_colsCompany.EditDataItemValueSet(1, ((SalString)frmMCEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfsCompany.Text).ToHandle());
			// Bug 76911, End
			// Bug 76911, Begin, added frmMCEntryVoucher before dfnAccountingPeriod
			nAccountingPeriod = frmMCEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfnAccountingPeriod.Number;
			// Bug 76911, End
			tblVoucherRow_colnAccountingPeriod.Number = nAccountingPeriod;
			tblVoucherRow_colnAccountingPeriod.EditDataItemSetEdited();
			tblVoucherRow_colsCurrencyType.EditDataItemValueSet(0, ((SalString)frmMCEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfsCurrencyType.Text).ToHandle());
			tblVoucherRow_colsCurrencyCode.EditDataItemValueSet(1, ((SalString)frmMCEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfsCurrencyCode.Text).ToHandle());
			tblVoucherRow_colnCurrencyRate.EditDataItemValueSet(1, frmMCEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfnCurrencyRate.Number.ToString(frmMCEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).nDecimalsInRate).ToHandle());
			// Bug 76911, Begin, added frmMCEntryVoucher before dfnConversionFactor
            tblVoucherRow_colnConversionFactor.EditDataItemValueSet(1, frmMCEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfnConversionFactor.Number.ToString(0).ToHandle());
			// Bug 76911, End
			tblVoucherRow_colsText.EditDataItemValueSet(1, ((SalString)frmMCEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfsRowText.Text).ToHandle());
			tblVoucherRow_colnDecimalsInAmount.EditDataItemValueSet(0, frmMCEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).nDecimalsInAmount.ToString(0).ToHandle());
			tblVoucherRow_colnAccDecimalsInAmount.EditDataItemValueSet(0, frmMCEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).nDecimalsInAmount.ToString(0).ToHandle());
			tblVoucherRow_colsTransCode.EditDataItemValueSet(1, ((SalString)"MANUAL").ToHandle());
			tblVoucherRow_colnAmount.EditDataItemValueSet(1, ((SalNumber)0).ToString(frmMCEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).nDecimalsInAmount).ToHandle());
			this.nActCurrencyRate = tblVoucherRow_colnCurrencyRate.Number;
			nPrevRate = this.nActCurrencyRate;
			// Fetch Row group id if row group validation is enabled
			if (frmMCEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfsRowGroupValidation.Text == "Y") 
			{
				if (CalcRowGroupInfo()) 
				{
					tblVoucherRow_colnRowGroupId.Number = GetNextGroupId();
					tblVoucherRow_colnRowGroupId.EditDataItemSetEdited();
					// check whether the company defaulted is ok with row group
					sCompnayOfRowGroup = group_company[tblVoucherRow_colnRowGroupId.Number];
					if (sCompnayOfRowGroup != Ifs.Fnd.ApplicationForms.Const.strNULL) 
					{
						if (sCompnayOfRowGroup != tblVoucherRow_colsCompany.Text) 
						{
							tblVoucherRow_colsCompany.EditDataItemValueSet(1, group_company[tblVoucherRow_colnRowGroupId.Number].ToHandle());
							// Set sOldValue = tblVoucherRow_colsCompany
						}
					}
				}
				else
				{
					Sal.ClearField(tblVoucherRow_colnRowGroupId);
				}
			}
			else
			{
				Sal.ClearField(tblVoucherRow_colnRowGroupId);
			}
			return 0;
			#endregion
		}
			
		/// <summary>
		/// </summary>
		/// <param name="nWhat"></param>
		/// <returns></returns>
		public virtual SalNumber DataRecordNew(SalNumber nWhat)
		{
            SalNumber returnValue;
			switch (nWhat)
			{
				case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
					// Bug 107962 Begin
					if (Ifs.Fnd.ApplicationForms.Int.QualifiedItemNameGet(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)) == Pal.GetActiveInstanceName("frmMCEntryVoucher")) 
					{
					// Bug 107962 End
                        // Bug 76911, Begin, added frmMCEntryVoucher before dfsCompany
						return ((bool)((cDataSource)tblVoucherRow).DataRecordNew(nWhat)) && frmMCEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfsCompany.Text != Sys.STRING_Null;
						// Bug 76911, End
                    // Bug 107962 Begin
                    }
                    else
                    {
                        return 0;
                    }
                    // Bug 107962 End
					goto case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute;
						
				case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                    returnValue = ((cChildTableFin)tblVoucherRow).DataRecordNew(nWhat);
                    // Bug 125584, Removed code.
                    return returnValue;
						
				case Ifs.Fnd.ApplicationForms.Const.METHOD_GetType:
					return ((cDataSource)tblVoucherRow).DataRecordNew(nWhat);
			}
			return 0;
		}
			
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean DataRecordValidate()
		{
		    Sal.SetFieldEdit(tblVoucherRow_colnAmount, false);
		    Sal.SetFieldEdit(tblVoucherRow_colnCurrencyAmount, false);
		    if (tblVoucherRow_colsOptionalCode.Text != Sys.STRING_Null) 
		    {
			    if (!(Sal.SendMsg(tblVoucherRow_colsOptionalCode, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, 0, 0))) 
			    {
				    return false;
			    }
		    }
            if (((cChildTableFin)tblVoucherRow).DataRecordValidate()) 
		    {
			    // row group validation (if row group validation is enabled)
			    if (frmMCEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfsRowGroupValidation.Text == "Y") 
			    {
				    // dont validate this row when null row group id
				    if (!(Sal.IsNull(tblVoucherRow_colnRowGroupId))) 
				    {
					    if (CalcRowGroupInfo()) 
					    {
						    ValidateRowGroups();
					    }
				    }
			    }
			    return true;
		    }
		    return false;
	
		}
			
		/// <summary>
		/// Applications should override the DataSourceFormatSqlColumnUser function
		/// to specify extra columns to be included in the select statement for the
		/// data source.
		/// </summary>
		/// <returns></returns>
		public virtual SalString DataSourceFormatSqlColumnUser()
		{
			return ("NVL(CURRENCY_DEBIT_AMOUNT,0) - NVL(CURRENCY_CREDIT_AMOUNT,0), NVL(DEBIT_AMOUNT,0) - NVL(CREDIT_AMOUNT,0)");
		}
			
		/// <summary>
		/// Applications should override the DataSourceFormatSqlIntoUser function
		/// to specify extra bind variables to be included in the select statement for the
		/// data source.
		/// </summary>
		/// <returns></returns>
		public virtual SalString DataSourceFormatSqlIntoUser()
		{
			return this.tblVoucherRow_colnCurrencyAmount.QualifiedBindName +","+ this.tblVoucherRow_colnAmount.QualifiedBindName;
		}
			
		/// <summary>
		/// This is an overridden function defined in the cChildTableFin class
		/// </summary>
		/// <param name="sCodePartValue"></param>
		/// <returns></returns>
		public virtual new SalBoolean EnableDisableProjectActivityId(SalString sCodePartValue)
		{
			sParam = sCodePartValue;
			Sal.ClearField(tblVoucherRow_colnProjectActivityId);
			if (sParam != SalString.Null) 
			{
                if (Int.IsGenLedInstalled && Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Accounting_Project_Api.Get_Externally_Created"))
                {
                    if (!(DbPLSQLBlock(@"{0} := Accounting_Project_Api.Get_Externally_Created({1} IN, {2} IN)",
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
			}
			if (CheckJobType()) 
			{
				tblVoucherRow_colsProjectActivityIdEnabled.Text = "N";
				tblVoucherRow_colnProjectActivityId.Number = 0;
			}
			else if (this.sProjectOriginGlobal == "FINPROJECT") 
			{
				tblVoucherRow_colsProjectActivityIdEnabled.Text = "N";
				tblVoucherRow_colnProjectActivityId.Number = Sys.NUMBER_Null;
			}
			else
			{
				if (tblVoucherRow_colsProjectActivityIdEnabled.Text == "N") 
				{
					tblVoucherRow_colnProjectActivityId.Number = Sys.NUMBER_Null;
				}
			}
			tblVoucherRow_colnProjectActivityId.EditDataItemSetEdited();
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
			    // Bug 76911, Begin, added frmMCEntryVoucher before dfsCompany
			    if ((tblVoucherRow_colsCompany.Text == frmMCEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfsCompany.Text) && (tblVoucherRow_colnAccountingPeriod.Number != nPeriod)) 
			    {
				    this.tblVoucherRow_colnAccountingPeriod.EditDataItemValueSet(1, nPeriod.ToString(0).ToHandle());
			    }
			    // Bug 76911, End
		    }
		    Sal.TblSetContext(tblVoucherRow, nCurrenctRow);
		    return true;
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
			#endregion
				
			#region Actions

			// Bug 85764, Begin
			if (tblVoucherRow_colnCurrencyRate.Number == Sys.NUMBER_Null) 
			{
				Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_Curr_Rate_Is_Null, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
				return nMyValue;
			}
			// Bug 85764, End
			if (sStatus == "RATE") 
			{
				frmMCVoucherRow.FromHandle(i_hWndFrame).GetAttributes(tblVoucherRow_colsCompany.Text, tblVoucherRow_colsCurrencyCode.Text, tblVoucherRow_colsBaseCurrencyCode.Text, tblVoucherRow_colsCurrencyType.Text, frmMCEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfdVoucherDate.DateTime);
				if (nMyValue != nPrevRate) 
				{
					frmMCVoucherRow.FromHandle(i_hWndFrame).GetBaseCurrAmountForRate(tblVoucherRow_colnCurrencyAmount.Number, nMyValue, ref nCalculateValue);
					this.nActCurrencyRate = nMyValue;
				}
				else
				{
					frmMCVoucherRow.FromHandle(i_hWndFrame).GetBaseCurrencyAmount(tblVoucherRow_colnCurrencyAmount.Number, ref nCalculateValue);
				}
				if (nCalculateValue == 0) 
				{
					nCalculateValue = SalNumber.Null;
				}
				tblVoucherRow_colnAmount.Number = nCalculateValue;
				if (tblVoucherRow_colnAmount.Number <= 0) 
				{
					tblVoucherRow_colnCreditAmount.Number = -nCalculateValue;
					tblVoucherRow_colnCreditAmount.EditDataItemSetEdited();
				}
				else
				{
					tblVoucherRow_colnDebitAmount.Number = nCalculateValue;
					tblVoucherRow_colnDebitAmount.EditDataItemSetEdited();
				}
			}
			if (sStatus == "CURRENT_AMOUNT") 
			{
				if (nMyValue != SalNumber.Null) 
				{
					nMyValue = frmMCVoucherRow.FromHandle(i_hWndFrame).RoundOf(nMyValue, tblVoucherRow_colnDecimalsInAmount.Number);
				}
				frmMCVoucherRow.FromHandle(i_hWndFrame).GetAttributes(tblVoucherRow_colsCompany.Text, tblVoucherRow_colsCurrencyCode.Text, tblVoucherRow_colsBaseCurrencyCode.Text, tblVoucherRow_colsCurrencyType.Text, frmMCEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfdVoucherDate.DateTime);
				tblVoucherRow_colnCurrencyAmount.Number = nMyValue;
				if (this.nActCurrencyRate == SalNumber.Null) 
				{
					this.nActCurrencyRate = tblVoucherRow_colnCurrencyRate.Number;
				}
				frmMCVoucherRow.FromHandle(i_hWndFrame).GetBaseCurrAmountForRate(nMyValue, this.nActCurrencyRate, ref nCalculateValue);
				frmMCVoucherRow.FromHandle(i_hWndFrame).GetBaseCurrAmountForRate(nMyValue, tblVoucherRow_colnCurrencyRate.Number, ref nCalculateValue);
				tblVoucherRow_colnAmount.Number = nCalculateValue;
				tblVoucherRow_colnCalculatedAmount.Number = tblVoucherRow_colnAmount.Number;
				if (nCalculateValue != SalNumber.Null) 
				{
					if (nCalculateValue < 0) 
					{
						nCalculateValue = -nCalculateValue;
					}
				}
                Sal.SendMsg(hWndRival, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, nCalculateValue.ToString(99).ToHandle());
			}
			if (sStatus == "ACCOUNTING_AMOUNT") 
			{
				if (nMyValue != SalNumber.Null) 
				{
					nMyValue = frmMCVoucherRow.FromHandle(i_hWndFrame).RoundOf(nMyValue, tblVoucherRow_colnAccDecimalsInAmount.Number);
					if (tblVoucherRow_colsCurrencyCode.Text == tblVoucherRow_colsBaseCurrencyCode.Text) 
					{
						tblVoucherRow_colnCurrencyDebitAmount.Number = tblVoucherRow_colnDebitAmount.Number;
						tblVoucherRow_colnCurrencyDebitAmount.EditDataItemSetEdited();
						tblVoucherRow_colnCurrencyAmount.Number = tblVoucherRow_colnDebitAmount.Number;
						tblVoucherRow_colnCurrencyAmount.EditDataItemSetEdited();
						tblVoucherRow_colnCurrencyCreditAmount.Number = Sys.NUMBER_Null;
						tblVoucherRow_colnCurrencyCreditAmount.EditDataItemSetEdited();
						if (tblVoucherRow_colnCreditAmount.Number == Sys.NUMBER_Null) 
						{
							tblVoucherRow_colnCurrencyDebitAmount.Number = tblVoucherRow_colnDebitAmount.Number;
							tblVoucherRow_colnCurrencyDebitAmount.EditDataItemSetEdited();
							tblVoucherRow_colnCurrencyAmount.Number = tblVoucherRow_colnDebitAmount.Number;
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
							tblVoucherRow_colnCurrencyDebitAmount.Number = Sys.NUMBER_Null;
							tblVoucherRow_colnCurrencyDebitAmount.EditDataItemSetEdited();
						}
					}
					else
					{
						if ((tblVoucherRow_colnCurrencyAmount.Number != 0) && (tblVoucherRow_colnCurrencyAmount.Number != Sys.NUMBER_Null)) 
						{
							if ((tblVoucherRow_colnCurrencyAmount.Number < 0 && nMyValue > 0) || (tblVoucherRow_colnCurrencyAmount.Number > 0 && nMyValue < 0)) 
							{
								tblVoucherRow_colnCurrencyAmount.Number = -tblVoucherRow_colnCurrencyAmount.Number;
								if (tblVoucherRow_colnCurrencyDebitAmount.Number == Sys.NUMBER_Null) 
								{
									tblVoucherRow_colnCurrencyDebitAmount.Number = tblVoucherRow_colnCurrencyCreditAmount.Number;
									tblVoucherRow_colnCurrencyDebitAmount.EditDataItemSetEdited();
									tblVoucherRow_colnCurrencyCreditAmount.Number = Sys.NUMBER_Null;
									tblVoucherRow_colnCurrencyCreditAmount.EditDataItemSetEdited();
								}
								else
								{
									tblVoucherRow_colnCurrencyCreditAmount.Number = tblVoucherRow_colnCurrencyDebitAmount.Number;
									tblVoucherRow_colnCurrencyCreditAmount.EditDataItemSetEdited();
									tblVoucherRow_colnCurrencyDebitAmount.Number = Sys.NUMBER_Null;
									tblVoucherRow_colnCurrencyDebitAmount.EditDataItemSetEdited();
								}
							}
							frmMCVoucherRow.FromHandle(i_hWndFrame).GetAttributes(tblVoucherRow_colsCompany.Text, tblVoucherRow_colsCurrencyCode.Text, tblVoucherRow_colsBaseCurrencyCode.Text, tblVoucherRow_colsCurrencyType.Text, frmMCEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfdVoucherDate.DateTime);
							if (nMyValue.Abs() != tblVoucherRow_colnCalculatedAmount.Number.Abs()) 
							{

								// PPJ: Automatically generated temporary assignments. Properties canot be passed by reference.
								SalNumber temp1 = tblVoucherRow_colnCurrencyRate.Number;
								frmMCVoucherRow.FromHandle(i_hWndFrame).GetCurrencyRate(nMyValue, tblVoucherRow_colnCurrencyAmount.Number, ref temp1);
								tblVoucherRow_colnCurrencyRate.Number = temp1;

								tblVoucherRow_colnCurrencyRate.EditDataItemSetEdited();
							}
							nPrevRate = tblVoucherRow_colnCurrencyRate.Number;
						}
					}
				}
				tblVoucherRow_colnAmount.Number = nMyValue;
			}
			if (this.cmbsVoucherCompany.Text == tblVoucherRow_colsCompany.Text) 
			{
				UpdateBalanceList();
			}
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
				if ((this.tblVoucherRow_colnAccountingYear.Number == frmMCEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfnAccountingYear.Number) && (this.tblVoucherRow_colsVoucherType.Text == SalString.FromHandle(frmMCEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(
							i_hWndFrame)).ccsVoucherType.EditDataItemValueGet())) && (this.tblVoucherRow_colnVoucherNo.Number == frmMCEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfnVoucherNo.Number)) 
				{
					Sal.TblSetContext(tblVoucherRow, nCurrenctRow1);
					return false;
				}
				this.tblVoucherRow_colnAccountingYear.EditDataItemValueSet(1, frmMCEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfnAccountingYear.Number.ToString(0).ToHandle());
				this.tblVoucherRow_colsVoucherType.EditDataItemValueSet(1, frmMCEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).ccsVoucherType.EditDataItemValueGet());
				// Bug 76911, Begin, added frmMCEntryVoucher before dfnVoucherNo
				this.tblVoucherRow_colnVoucherNo.EditDataItemValueSet(1, frmMCEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfnVoucherNo.Number.ToString(0).ToHandle());
				// Bug 76911, End
			}
			return true;		
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
		/// to check job type
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean CheckJobType()
		{
			#region Local Variables
			SalBoolean sPorjectOriginJob = false;
			SalString sCacheReturn = "";
			#endregion
				
			#region Actions

			// use cache to avoid unnecessary server calling
			sProjectOrigin = Ifs.Fnd.ApplicationForms.Const.strNULL;
			sCacheReturn = Ifs.Fnd.ApplicationForms.Const.strNULL;
			if (this.CacheInfo.SessionRetrieve(" frmMCVoucherRowtblVoucherRow " + tblVoucherRow_colsCompany.Text + sParam, ref sCacheReturn)) 
			{
				sProjectOrigin = sCacheReturn;
			}
			else
			{
                if (Int.IsGenLedInstalled && Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Accounting_Project_API.Get_Project_Origin_Db"))
                {
                    if (!(DbPLSQLBlock(@"{0} := &AO.Accounting_Project_API.Get_Project_Origin_Db({1} IN, {2} IN )",
                        this.QualifiedVarBindName("sProjectOrigin"),
                        this.tblVoucherRow_colsCompany.QualifiedBindName,
                        this.QualifiedVarBindName("sParam") )))
                    {
                        return false;
                    }
                    
                }                        
				this.CacheInfo.SessionStore(" frmMCVoucherRowtblVoucherRow " + tblVoucherRow_colsCompany.Text + sParam, sProjectOrigin);
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
					if (this.tblVoucherRow_colnAccountingPeriod.Number != frmMCEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfnAccountingPeriod.Number) 
					{
						this.tblVoucherRow_colnAccountingPeriod.EditDataItemValueSet(1, frmMCEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfnAccountingPeriod.Number.ToString(0).ToHandle());
					}
				}
			}
			return true;
		}
			
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean UpdateBalanceList()
		{
            if (Sal.TblAnyRows(tblVoucherRow, 0, Sys.ROW_MarkDeleted))
            {
                SalNumber nCurrentRow = Sal.TblQueryContext(tblVoucherRow);
                this.dfnCurrencyBalance.Number = 0;
                this.dfnBalance.Number = 0;

                ISet<SalNumber> selectedRows = tblVoucherRow.FindAllRows(0, Sys.ROW_MarkDeleted);
                foreach (SalNumber nRow in selectedRows)
                {
                    tblVoucherRow.SetContextRow(nRow);
                    if (this.cmbsVoucherCompany.Text == tblVoucherRow_colsCompany.Text)
                    {
                        this.dfnCurrencyBalance.Number = this.dfnCurrencyBalance.Number + tblVoucherRow_colnCurrencyAmount.Number;
                        this.dfnBalance.Number = this.dfnBalance.Number + this.tblVoucherRow_colnAmount.Number;
                    }
                }
                Sal.TblSetContext(tblVoucherRow, nCurrentRow);
            }
            return true;
		}
			
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean UpdateCompanyList()
		{
		    if (Sal.TblAnyRows(tblVoucherRow, 0, Sys.ROW_MarkDeleted)) 
		    {
			    SalNumber nRow = Sys.TBL_MinRow;
			    SalNumber nCurrentRow = Sal.TblQueryContext(tblVoucherRow);
			    SalNumber nCurrentSelection = Sal.ListQuerySelection(this.cmbsVoucherCompany);
			    if (nCurrentSelection == -1) 
			    {
				    nCurrentSelection = 0;
			    }
			    Sal.ListClear(this.cmbsVoucherCompany);
			    while (Sal.TblFindNextRow(tblVoucherRow, ref nRow, 0, Sys.ROW_MarkDeleted)) 
			    {
				    Sal.TblSetContext(tblVoucherRow, nRow);
				    if (!(IsComboItemExists(this.cmbsVoucherCompany, this.tblVoucherRow_colsCompany.Text))) 
				    {
					    Sal.ListAdd(this.cmbsVoucherCompany, this.tblVoucherRow_colsCompany.Text);
				    }
			    }
			    Sal.TblSetContext(tblVoucherRow, nCurrentRow);
			    Sal.ListSetSelect(this.cmbsVoucherCompany, nCurrentSelection);
				if (!(DbPLSQLBlock(@"{0} := Company_Finance_API.Get_Currency_Code({1} IN);",
                    this.dfsVCCurrency.QualifiedBindName,this.QualifiedVarBindName("cmbsVoucherCompany") ))) 
				{
					return false;
				}  
		    }
		    Ifs.Fnd.ApplicationForms.Var.Console.TextAdd(Ifs.Fnd.ApplicationForms.Const.CONS_Debug, "Company List Updated");
		    return true;
	
		}
			
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber ValidateCurrencyCode()
		{
			if (!(frmMCVoucherRow.FromHandle(i_hWndFrame).GetAttributes(tblVoucherRow_colsCompany.Text, tblVoucherRow_colsCurrencyCode.Text, tblVoucherRow_colsBaseCurrencyCode.Text, tblVoucherRow_colsCurrencyType.Text, frmMCEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfdVoucherDate.DateTime))) 
			{
				return false;
			}
			// Bug 89498, Begin
			nPrevRate = tblVoucherRow_colnCurrencyRate.Number;
			// Bug 89498, End
			if (!(bIsDuplicate) || bIsPaste) 
			{
				tblVoucherRow_colnCurrencyRate.Number = frmMCVoucherRow.FromHandle(i_hWndFrame).GetRate(tblVoucherRow_colsCompany.Text, tblVoucherRow_colsCurrencyCode.Text);
                tblVoucherRow_colnConversionFactor.Number = frmMCVoucherRow.FromHandle(i_hWndFrame).i_nFinConversionFactor;
			}
			// Bug 89498, Begin
			tblVoucherRow_colnCurrencyRate.EditDataItemSetEdited();
			// Bug 89498, End
			this.nActCurrencyRate = tblVoucherRow_colnCurrencyRate.Number;
            tblVoucherRow_colnConversionFactor.EditDataItemSetEdited();
			// Bug 89498 - Moved nPrevRate assignment
			tblVoucherRow_colnDecimalsInAmount.Number = frmMCVoucherRow.FromHandle(i_hWndFrame).i_nFinTransRound;
			tblVoucherRow_colnDecimalsInAmount.EditDataItemSetEdited();
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
		/// <returns></returns>
		public virtual SalNumber ValidateCurrencyType()
		{
			if (!(DbPLSQLBlock(@"&AO.Currency_Type_API.Exist({0} IN, {1} IN )",this.tblVoucherRow_colsCompany.QualifiedBindName,this.tblVoucherRow_colsCurrencyType.QualifiedBindName))) 
			{
				return false;
			}
			if (!(frmMCVoucherRow.FromHandle(i_hWndFrame).GetAttributes(tblVoucherRow_colsCompany.Text, tblVoucherRow_colsCurrencyCode.Text, frmMCEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).sCurrencyCode, tblVoucherRow_colsCurrencyType.Text, frmMCEntryVoucher.FromHandle(
					Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfdVoucherDate.DateTime))) 
			{
				return false;
			}
			tblVoucherRow_colnCurrencyRate.Number = frmMCVoucherRow.FromHandle(i_hWndFrame).GetRate(tblVoucherRow_colsCompany.Text, tblVoucherRow_colsCurrencyCode.Text);
			this.nActCurrencyRate = tblVoucherRow_colnCurrencyRate.Number;
			tblVoucherRow_colnCurrencyRate.EditDataItemSetEdited();
			tblVoucherRow_colnDecimalsInAmount.Number = frmMCVoucherRow.FromHandle(i_hWndFrame).i_nFinTransRound;
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
		/// <param name="hSql"></param>
		/// <returns></returns>
		public virtual SalBoolean DataRecordExecuteModify(SalSqlHandle hSql)
		{
			#region Local Variables
			SalNumber nTokens = 0;
			SalNumber nRowNo = 0;
			SalNumber nAmount = 0;
			SalArray<SalString> sTokens = new SalArray<SalString>();
			SalString sAccount = "";
			SalBoolean bOk = false;
			#endregion
				
			#region Actions
			SalNumber nCount = 0;
			SalNumber nContext = Sal.TblQueryContext(tblVoucherRow);
			// Bug 76624, Begin. Changed the server method Check_If_Manual() to Check_If_Not_Excluded_Manual()
			if (Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Internal_Voucher_Util_Pub_API.Check_If_Not_Excluded_Manual") && Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Voucher_Type_API.Get_Use_Manual") && Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable(
				"Internal_Ledger_Util_Pub_API.Get_Next_Int_Manual_Post_Seq")) 
			{
				// Bug 76624, Begin. Changed the server method Check_If_Manual() to Check_If_Not_Excluded_Manual()
                IDictionary<string, string> namedBindVariables = new Dictionary<string, string>();
                namedBindVariables.Add("colsCompany", this.tblVoucherRow_colsCompany.QualifiedBindName);
                namedBindVariables.Add("colsVoucherType", this.tblVoucherRow_colsVoucherType.QualifiedBindName);
                namedBindVariables.Add("colsAccount", this.tblVoucherRow_colsAccount.QualifiedBindName);
                namedBindVariables.Add("colsLedgerIds", this.tblVoucherRow_colsLedgerIds.QualifiedBindName);
                namedBindVariables.Add("colnInternalSeqNumber", this.tblVoucherRow_colnInternalSeqNumber.QualifiedBindName);
                namedBindVariables.Add("dfdVoucherDate", ":i_hWndParent.frmMCEntryVoucher.dfdVoucherDate");

                string stmt = @"BEGIN 
		                            IF (&AO.Voucher_Type_API.Get_Use_Manual({colsCompany} IN, {colsVoucherType} IN) ='TRUE' ) THEN 
			                            {colsLedgerIds} := &AO.Internal_Voucher_Util_Pub_API.Check_If_Not_Excluded_Manual({colsCompany} IN,
																							                              {colsAccount} IN,  
		                                                                                                                  {dfdVoucherDate} IN,
																							                              {colsVoucherType} IN);
			                            IF ({colsLedgerIds} IS NOT NULL AND {colnInternalSeqNumber} IS NULL) THEN 
				                            {colnInternalSeqNumber} :=   &AO.Internal_Ledger_Util_Pub_API.Get_Next_Int_Manual_Post_Seq; 
			                            END IF; 
		                            END IF;
                                END;";
			    if (!(DbPLSQLBlock(stmt,namedBindVariables))) 
			    {
				    return false;
			    }
				
				// Bug 76624, End.
				tblVoucherRow_colnInternalSeqNumber.EditDataItemSetEdited();
				if ((!(Sal.IsNull(tblVoucherRow_colsLedgerIds))) && tblVoucherRow_colsManualAdded.Text != "TRUE") 
				{
					tblVoucherRow_colAddInternal.Text = "TRUE";
				}
				else
				{
					tblVoucherRow_colAddInternal.Text = "FALSE";
				}
			}
			// Bug 76624, End.
			if (tblVoucherRow_colAddInternal.Text == "TRUE") 
			{
				bOk = true;
				MethodProgressDone();
				nTokens = ((SalString)tblVoucherRow_colsLedgerIds.Text).Tokenize("", "|", sTokens);
				p_sCompany = tblVoucherRow_colsCompany.Text;
				p_sAccount = tblVoucherRow_colsAccount.Text;
				p_nRefRowNo = tblVoucherRow_colnRowNoCreated.Number;
				p_nAmount = tblVoucherRow_colnAmount.Number;
				p_nCurrencyAmount = tblVoucherRow_colnCurrencyAmount.Number;
				p_nCurrRate = tblVoucherRow_colnCurrencyRate.Number;
				p_nInternalSeq = tblVoucherRow_colnInternalSeqNumber.Number;
				while (nCount < nTokens) 
				{
					p_sLedger = sTokens[nCount];
					bOk = ((bool)dlgManualIntPosting.ModalDialog(Ifs.Fnd.ApplicationForms.Int.Explorer.ExplorerForm, i_hWndSelf)) && bOk;
					nCount = nCount + 1;
				}
			}
            Sal.TblSetContext(tblVoucherRow, nContext);
			((cChildTableFin)tblVoucherRow).DataRecordExecuteModify(hSql);
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
					return Sal.TblAnyRows(this, Sys.ROW_Selected, 0) && (tblVoucherRow_colsManualAdded.Text == "TRUE" || tblVoucherRow_colAddInternal.Text == "TRUE");
						
				case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
					bOk = true;
					GetInternalSeqNumberIfNull();
					nTokens = ((SalString)tblVoucherRow_colsLedgerIds.Text).Tokenize("", "|", sTokens);
					p_sCompany = tblVoucherRow_colsCompany.Text;
					p_sAccount = tblVoucherRow_colsAccount.Text;
					p_nRefRowNo = tblVoucherRow_colnRowNoCreated.Number;
					p_nAmount = tblVoucherRow_colnAmount.Number;
					p_nCurrencyAmount = tblVoucherRow_colnCurrencyAmount.Number;
					p_nCurrRate = tblVoucherRow_colnCurrencyRate.Number;
					p_nInternalSeq = tblVoucherRow_colnInternalSeqNumber.Number;
					while (nCount < nTokens) 
					{
						p_sLedger = sTokens[nCount];
						bOk = ((bool)dlgManualIntPosting.ModalDialog(Ifs.Fnd.ApplicationForms.Int.Explorer.ExplorerForm, i_hWndSelf)) && bOk;
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
			SalArray<SalString> sTokens = new SalArray<SalString>();
			SalBoolean bOk = false;
			#endregion
				
			#region Actions

            SalNumber nCount = 0;
            SalNumber nContext = Sal.TblQueryContext(tblVoucherRow);
			if (tblVoucherRow_colAddInternal.Text == "TRUE") 
			{
				bOk = true;
				GetInternalSeqNumberIfNull();
				MethodProgressDone();
                SalNumber nTokens = ((SalString)tblVoucherRow_colsLedgerIds.Text).Tokenize("", "|", sTokens);
				p_sCompany = tblVoucherRow_colsCompany.Text;
				p_sAccount = tblVoucherRow_colsAccount.Text;
				p_nRefRowNo = tblVoucherRow_colnRowNoCreated.Number;
				p_nAmount = tblVoucherRow_colnAmount.Number;
				p_nCurrencyAmount = tblVoucherRow_colnCurrencyAmount.Number;
				p_nCurrRate = tblVoucherRow_colnCurrencyRate.Number;
				p_nInternalSeq = tblVoucherRow_colnInternalSeqNumber.Number;
				while (nCount < nTokens) 
				{
					p_sLedger = sTokens[nCount];
					bOk = ((bool)dlgManualIntPosting.ModalDialog(Ifs.Fnd.ApplicationForms.Int.Explorer.ExplorerForm, i_hWndSelf)) && bOk;
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
            SalBoolean bNull = (Sal.IsNull(tblVoucherRow_colnInternalSeqNumber)); 
		
			if (Sal.IsNull(tblVoucherRow_colnInternalSeqNumber) || Sal.IsNull(tblVoucherRow_colsLedgerIds)) 
			{
				if (Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Internal_Ledger_Util_Pub_API.Get_Next_Int_Manual_Post_Seq")) 
				{
					// Bug 76624, Begin. Changed the server method Check_If_Manual() to Check_If_Not_Excluded_Manual()
                    IDictionary<string, string> namedBindVariables = new Dictionary<string, string>();
                    namedBindVariables.Add("colsCompany", this.tblVoucherRow_colsCompany.QualifiedBindName);
                    namedBindVariables.Add("colsVoucherType", this.tblVoucherRow_colsVoucherType.QualifiedBindName);
                    namedBindVariables.Add("colsAccount", this.tblVoucherRow_colsAccount.QualifiedBindName);
                    namedBindVariables.Add("colsLedgerIds", this.tblVoucherRow_colsLedgerIds.QualifiedBindName);
                    namedBindVariables.Add("colnInternalSeqNumber", this.tblVoucherRow_colnInternalSeqNumber.QualifiedBindName);
                    namedBindVariables.Add("dfdVoucherDate", ":i_hWndParent.frmMCEntryVoucher.dfdVoucherDate");

                    string stmt = @"IF {colnInternalSeqNumber} IS NULL THEN 
	                                    {colnInternalSeqNumber} :=   cSessionManager.c_sDbPrefix  Internal_Ledger_Util_Pub_API.Get_Next_Int_Manual_Post_Seq; 
                                    END IF; 
                                    IF {colsLedgerIds} IS NULL THEN 
	                                   {colsLedgerIds} := &AO.Internal_Voucher_Util_Pub_API.Check_If_Not_Excluded_Manual({colsCompany} IN,
																					                                     {colsAccount} IN,  
																					                                     {dfdVoucherDate} IN,
																					                                     {colsVoucherType} IN); 
                                    END IF;	";
					if (!(DbPLSQLBlock(stmt,namedBindVariables ))) 
					{
						return false;
					}
					
					// Bug 76624, End.
					if (bNull && !(Sal.IsNull(tblVoucherRow_colnInternalSeqNumber))) 
					{
						tblVoucherRow_colnInternalSeqNumber.EditDataItemSetEdited();
					}
				}
			}
			frmMCVoucherRow.FromHandle(i_hWndFrame).GetAttributes(tblVoucherRow_colsCompany.Text, tblVoucherRow_colsCurrencyCode.Text, frmMCEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).sCurrencyCode, tblVoucherRow_colsCurrencyType.Text, frmMCEntryVoucher.FromHandle(
					Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfdVoucherDate.DateTime);
			

			return 0;
	
		}
			
		/// <summary>
		/// This function is used for searching the items available in the ComboBox. Available Centura function
		/// "SalListSelectString" doesn't work as expected for similar form of Strings.
		/// </summary>
		/// <param name="hComboItem"></param>
		/// <param name="sSearchString"></param>
		/// <returns></returns>
		public virtual SalBoolean IsComboItemExists(SalWindowHandle hComboItem, SalString sSearchString)
		{
			#region Local Variables
			SalNumber nItemCount = 0;
			SalNumber nNo = 0;
			SalString sListItem = "";
			SalBoolean bItemExists = false;
			#endregion
				
			#region Actions

			if (Sal.ListQueryCount(hComboItem) < 1) 
			{
				return false;
			}
			else
			{
				nItemCount = Sal.ListQueryCount(hComboItem);
				nNo = 0;
				while (nItemCount > nNo) 
				{
					sListItem = Sal.ListQueryTextX(hComboItem, nNo);
					if (sListItem == sSearchString) 
					{
						bItemExists = true;
						break;
					}
					else
					{
						bItemExists = false;
					}
					nNo = nNo + 1;
				}
				return bItemExists; 
			}
			
			#endregion
		}
			
		/// <summary>
		/// Travers the table and set edit flag on some of the fields.
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber SetFieldEdit()
		{
            #region Local Variables
            SalNumber nCurrentRow = 0;
            #endregion
            SalNumber nCurRow = Sys.TBL_MinRow;
            nCurrentRow = Sal.TblQueryContext(tblVoucherRow);
		    while (Sal.TblFindNextRow(tblVoucherRow, ref nCurRow, Sys.ROW_New, 0)) 
		    {
                Sal.TblSetContext(tblVoucherRow, nCurRow);
                Sal.SetFieldEdit(tblVoucherRow_colnCurrencyAmount, false);
			    Sal.SetFieldEdit(tblVoucherRow_colnAmount, false);
            }
            Sal.TblSetContext(tblVoucherRow, nCurrentRow);
			return 0;
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
			#endregion
				
			#region Actions

			switch (nWhat)
			{
				case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                    return ((bool)((cChildTableFin)tblVoucherRow).DataRecordDuplicate(nWhat)) && (((SalString)tblVoucherRow_colsTransCode.Text).Trim().ToUpper() == "MANUAL");
						
				case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
					bIsDuplicate = true;
                    bOk = ((cChildTableFin)tblVoucherRow).DataRecordDuplicate(nWhat);
					SetFieldEdit();
					bIsDuplicate = false;
					return bOk;
						
				case Ifs.Fnd.ApplicationForms.Const.METHOD_GetType:
					return Ifs.Fnd.ApplicationForms.Const.CHILDTYPE_SourceMethod;
			}
			return 0;
			#endregion
		}
			
		
		// --- Double Entry Validation methods ----
		/// <summary>
		/// The methods collects information necessary for double entry based on the visible rows.
		/// The info is stored in four dynamic arrays where index is the row group id.
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean CalcRowGroupInfo()
		{
			#region Local Variables
			SalNumber nContextRow = 0;
			SalNumber nCurrentRow = 0;
			SalNumber nRowAmount = 0;
			SalArray<SalString> sParam = new SalArray<SalString>(1);
			#endregion
				
			#region Actions
			// - Keep cuurent context row
            nContextRow = Sal.TblQueryContext(tblVoucherRow);
			// -------------------------------------
			// PASS 1 - Compnay - Row Group Id check
			//   < Same group can't have more than one company id >
			// -------------------------------------
			group_company.SetUpperBound(1, -1);
			nCurrentRow = Sys.TBL_MinRow;
            while (Sal.TblFindNextRow(tblVoucherRow, ref nCurrentRow, 0, Sys.ROW_MarkDeleted)) 
			{
                Sal.TblSetContext(tblVoucherRow, nCurrentRow);
				if (!(Sal.IsNull(tblVoucherRow_colnRowGroupId))) 
				{
					if (group_company[tblVoucherRow_colnRowGroupId.Number] == Ifs.Fnd.ApplicationForms.Const.strNULL) 
					{
						group_company[tblVoucherRow_colnRowGroupId.Number] = tblVoucherRow_colsCompany.Text;
					}
					else if (group_company[tblVoucherRow_colnRowGroupId.Number] != tblVoucherRow_colsCompany.Text) 
					{
						sParam[0] = tblVoucherRow_colnRowGroupId.Number.ToString(0);
						Ifs.Fnd.ApplicationForms.Int.AlertBoxWithParams(Properties.Resources.TEXT_MCVoEnCompGroupInvalid, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Warning, Ifs.Fnd.ApplicationForms.Const.WARNING_Ok, sParam);
						return false;
					}
				}
			}
			// -------------------------------------
			// PASS 2 - Double entry info collection
			// -------------------------------------
			group_balance.SetUpperBound(1, -1);
			group_c_count.SetUpperBound(1, -1);
			group_d_count.SetUpperBound(1, -1);
			nCurrentRow = Sys.TBL_MinRow;
            while (Sal.TblFindNextRow(tblVoucherRow, ref nCurrentRow, 0, Sys.ROW_MarkDeleted)) 
			{
                Sal.TblSetContext(tblVoucherRow, nCurrentRow);
				if (!(Sal.IsNull(tblVoucherRow_colnRowGroupId))) 
				{
					nRowAmount = CalcRowAmount();
					// --- Balances of the groups ---
					group_balance[tblVoucherRow_colnRowGroupId.Number] = group_balance[tblVoucherRow_colnRowGroupId.Number] + nRowAmount;
					// --- Cardinality of the groups ---
					if (nRowAmount > 0) 
					{
						group_c_count[tblVoucherRow_colnRowGroupId.Number] = group_c_count[tblVoucherRow_colnRowGroupId.Number] + 1;
					}
					else if (nRowAmount < 0) 
					{
						group_d_count[tblVoucherRow_colnRowGroupId.Number] = group_d_count[tblVoucherRow_colnRowGroupId.Number] + 1;
					}
				}
			}
			// - Restore context
            Sal.TblSetContext(tblVoucherRow, nContextRow);
			return true;	
			#endregion
		}
			
		/// <summary>
		/// Double Entry Validation support method
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber CalcRowAmount()
		{
	        if (Sal.IsNull(tblVoucherRow_colnAmount)) 
	        {
		        return 0;
	        }
	        return tblVoucherRow_colnAmount.Number;
		}
			
		/// <summary>
		/// Double Entry Validation support method
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean ValidateRowGroups()
		{
			#region Local Variables
			SalArray<SalString> sParam = new SalArray<SalString>();
			#endregion
				
			#region Actions
            SalNumber nCurrentPos = 0;
            SalNumber nUpperBound = group_c_count.GetUpperBound(1);
			while (nCurrentPos <= nUpperBound) 
			{
				if (group_c_count[nCurrentPos] != SalNumber.Null && group_d_count[nCurrentPos] != SalNumber.Null) 
				{
					if (group_c_count[nCurrentPos] > 1 && group_d_count[nCurrentPos] > 1) 
					{
						sParam[0] = nCurrentPos.ToString(0);
						Ifs.Fnd.ApplicationForms.Int.AlertBoxWithParams(Properties.Resources.TEXT_DoubleEntryPostError, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Warning, Ifs.Fnd.ApplicationForms.Const.WARNING_Ok, sParam);
						return false;
					}
				}
				nCurrentPos = nCurrentPos + 1;
			}
			return true;
			#endregion
		}
			
		/// <summary>
		/// Double Entry Validation support method
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
					if (group_balance[nCurrentPos] != 0) 
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
			return nLastBalancedGroup + 1;
		}

        #endregion

        #region Window Actions

        /// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void tblVoucherRow_colsCompany_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{			
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
					this.tblVoucherRow_colsCompany_OnPM_DataItemValidate(sender, e);
					break;
					
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom:
					this.tblVoucherRow_colsCompany_OnPM_DataItemZoom(sender, e);
					break;
			}
			#endregion
		}
						
		/// <summary>
		/// SAM_Validate event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblVoucherRow_colsCompany_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam) == Sys.VALIDATE_Cancel)
            {
                e.Return = Sys.VALIDATE_Cancel;
                return;
            }
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                if (this.tblVoucherRow_colsCompany.Text != Ifs.Fnd.ApplicationForms.Const.strNULL)
                {
                    if (!(DbPLSQLBlock("&AO.Company_Finance_API.Exist({0} IN)", this.tblVoucherRow_colsCompany.QualifiedBindName)))
                    {
                        e.Return = Sys.VALIDATE_Cancel;
                        return;
                    }
                    if (!(this.ClearCompanyData()))
                    {
                        e.Return = Sys.VALIDATE_Cancel;
                        return;
                    }
                    this.dfsCodePartValue.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                    this.dfsCodePartDescription.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                    this.UpdateCompanyList();
                }
            }
            e.Return = Sys.VALIDATE_Ok;
            return;
			#endregion
		}
			
		/// <summary>
		/// PM_DataItemZoom event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblVoucherRow_colsCompany_OnPM_DataItemZoom(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			switch (Sys.wParam)
			{
				case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
					this.sItemNames[0] = "COMPANY";
					this.hWndItems[0] = this.tblVoucherRow_colsCompany;
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("CompanyFinance", tblVoucherRow, this.sItemNames, this.hWndItems);
                    SessionNavigate(Pal.GetActiveInstanceName("frmCompany"));
					e.Return = true;
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
		private void tblVoucherRow_colnRowGroupId_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
					this.tblVoucherRow_colnRowGroupId_OnPM_DataItemQueryEnabled(sender, e);
					break;
					
				case Sys.SAM_SetFocus:
					this.tblVoucherRow_colnRowGroupId_OnSAM_SetFocus(sender, e);
					break;
					
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
					this.tblVoucherRow_colnRowGroupId_OnPM_DataItemValidate(sender, e);
					break;
			}
			#endregion
		}
			
		/// <summary>
		/// PM_DataItemQueryEnabled event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblVoucherRow_colnRowGroupId_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (frmMCEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(this.tblVoucherRow_colnRowGroupId.i_hWndFrame)).dfsRowGroupValidation.Text == "Y") 
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
		private void tblVoucherRow_colnRowGroupId_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (frmMCEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(this.tblVoucherRow_colnRowGroupId.i_hWndFrame)).dfsRowGroupValidation.Text == "Y") 
			{
				e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
				return;
			}
			else
			{
                // Used this method as using Sal.SendMsg,Sal.PostMsg to send Tab key is not working properly in aurora client
                System.Windows.Forms.SendKeys.Send("{TAB}");
				e.Return = false;
				return;
			}
			#endregion
		}
			
		/// <summary>
		/// PM_DataItemValidate event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblVoucherRow_colnRowGroupId_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (this.tblVoucherRow_colnRowGroupId.Number < 0) 
			{
				this.tblVoucherRow_colnRowGroupId.Number = 1;
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
		private void tblVoucherRow_colsAccount_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
					this.tblVoucherRow_colsAccount_OnPM_DataItemValidate(sender, e);
					break;
					
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovDone:
					this.tblVoucherRow_colsAccount_OnPM_DataItemLovDone(sender, e);
					break;
			}
			#endregion
		}
			
		/// <summary>
		/// PM_DataItemValidate event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblVoucherRow_colsAccount_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam) == Sys.VALIDATE_Cancel) 
			{
				e.Return = Sys.VALIDATE_Cancel;
				return;
			}
			// Bug 76624, Begin. Changed the server method Check_If_Manual() to Check_If_Not_Excluded_Manual()
			if (Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Internal_Voucher_Util_Pub_API.Check_If_Not_Excluded_Manual") && Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Voucher_Type_API.Get_Use_Manual") && Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable(
				"Internal_Ledger_Util_Pub_API.Get_Next_Int_Manual_Post_Seq")) 
			{
				// Bug 76624, Begin. Changed the server method Check_If_Manual() to Check_If_Not_Excluded_Manual()
                IDictionary<string, string> namedBindVariables = new Dictionary<string, string>();
                namedBindVariables.Add("colsCompany", this.tblVoucherRow_colsCompany.QualifiedBindName);
                namedBindVariables.Add("colsVoucherType", this.tblVoucherRow_colsVoucherType.QualifiedBindName);
                namedBindVariables.Add("colsAccount", this.tblVoucherRow_colsAccount.QualifiedBindName);
                namedBindVariables.Add("colsLedgerIds", this.tblVoucherRow_colsLedgerIds.QualifiedBindName);
                namedBindVariables.Add("colnInternalSeqNumber", this.tblVoucherRow_colnInternalSeqNumber.QualifiedBindName);
                namedBindVariables.Add("dfdVoucherDate", ":i_hWndParent.frmMCEntryVoucher.dfdVoucherDate");

                string stmt = @"BEGIN 
		                            IF (&AO.Voucher_Type_API.Get_Use_Manual({colsCompany} IN, {colsVoucherType} IN) ='TRUE' ) THEN 
			                            {colsLedgerIds} := &AO.Internal_Voucher_Util_Pub_API.Check_If_Not_Excluded_Manual({colsCompany} IN,
																							                          {colsAccount} IN,  
		                                                                                                              {dfdVoucherDate} IN,
																							                          {colsVoucherType} IN);
			                            IF ({colsLedgerIds} IS NOT NULL AND {colnInternalSeqNumber} IS NULL) THEN 
				                            {colnInternalSeqNumber} :=   &AO.Internal_Ledger_Util_Pub_API.Get_Next_Int_Manual_Post_Seq; 
			                            END IF; 
		                            END IF;
                                END;";

				if (!(DbPLSQLBlock(stmt,namedBindVariables)))
			
				{
					e.Return = false;
					return;
				}
				
				// Bug 76624, End.
				this.tblVoucherRow_colnInternalSeqNumber.EditDataItemSetEdited();
				if ((!(Sal.IsNull(this.tblVoucherRow_colsLedgerIds))) && this.tblVoucherRow_colsManualAdded.Text != "TRUE") 
				{
					this.tblVoucherRow_colAddInternal.Text = "TRUE";
				}
				else
				{
					this.tblVoucherRow_colAddInternal.Text = "FALSE";
				}
			}
			// Bug 76624, End.
			e.Return = true;
			return;
			#endregion
		}
			
		/// <summary>
		/// PM_DataItemLovDone event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblVoucherRow_colsAccount_OnPM_DataItemLovDone(object sender, WindowActionsEventArgs e)
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
				if (!(DbPLSQLBlock(@"{0} := &AO.Account_Process_Code_API.Get_Description({1} IN, {2} IN )",
                    this.dfsCodePartDescription.QualifiedBindName,
                    this.tblVoucherRow_colsCompany.QualifiedBindName,
                    this.tblVoucherRow_colsProcessCode.QualifiedBindName))) 
				{
					// Don't translate this message, this message only for programmer not user
					Ifs.Fnd.ApplicationForms.Int.AlertBox("Design time error in tblVoucherRow_colsProcessCode !", Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
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
		private void tblVoucherRow_colsProcessCode_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (!(Sal.IsNull(this.tblVoucherRow_colsProcessCode))) 
			{
			    if (!(DbPLSQLBlock(@"&AO.Voucher_Row_API.Validate_Process_Code__({0} IN,{1} IN, {2} IN )",
                        this.tblVoucherRow_colsCompany.QualifiedBindName,
                        this.tblVoucherRow_colsProcessCode.QualifiedBindName,
                        ":i_hWndParent.frmMCEntryVoucher.dfdVoucherDate" ))) 
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
            // Bug 104246, Begin - Added required validation to currency code
            else
            {
                Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_VouCurrCode, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                e.Return = Sys.VALIDATE_Cancel;
                return;
            }
            // Bug 104246, End
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
			if (!(Sal.IsNull(this.tblVoucherRow_colsCurrencyType)) && (this.tblVoucherRow_colsCurrencyType.Text != frmMCEntryVoucher.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(this.tblVoucherRow_colsCurrencyType.i_hWndFrame)).dfsCurrencyType.Text)) 
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
		private void tblVoucherRow_colnCurrencyDebitAmount_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
					this.tblVoucherRow_colnCurrencyDebitAmount_OnPM_DataItemValidate(sender, e);
					break;
					
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
					this.tblVoucherRow_colnCurrencyDebitAmount_OnPM_DataItemQueryEnabled(sender, e);
					break;
			}
			#endregion
		}
			
		/// <summary>
		/// PM_DataItemValidate event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblVoucherRow_colnCurrencyDebitAmount_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (this.tblVoucherRow_colnCurrencyDebitAmount.Number != Sys.NUMBER_Null) 
			{
				if (this.tblVoucherRow_colnCurrencyDebitAmount.Number < 0) 
				{
					this.tblVoucherRow_colnCurrencyDebitAmount.Number = -this.tblVoucherRow_colnCurrencyDebitAmount.Number;
				}
			}
			if (Sal.IsNull(this.tblVoucherRow_colnCurrencyCreditAmount)) 
			{
				this.tblVoucherRow_colnCurrencyDebitAmount.Number = this.SetAnotherValue(this.tblVoucherRow_colnCurrencyDebitAmount.Number, this.tblVoucherRow_colnDebitAmount, "CURRENT_AMOUNT");
				if (!(Sal.IsNull(this.tblVoucherRow_colnCreditAmount))) 
				{
					Sal.SendMsg(this.tblVoucherRow_colnCreditAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, SalNumber.Null.ToString(0).ToHandle());
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
		private void tblVoucherRow_colnCurrencyDebitAmount_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
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
			}
			if (Sal.IsNull(this.tblVoucherRow_colnCurrencyDebitAmount)) 
			{
				this.tblVoucherRow_colnCurrencyCreditAmount.Number = -this.SetAnotherValue(-this.tblVoucherRow_colnCurrencyCreditAmount.Number, this.tblVoucherRow_colnCreditAmount, "CURRENT_AMOUNT");
				if (!(Sal.IsNull(this.tblVoucherRow_colnDebitAmount))) 
				{
					Sal.SendMsg(this.tblVoucherRow_colnDebitAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, SalNumber.Null.ToString(0).ToHandle());
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
			if (!(Sal.IsNull(this.tblVoucherRow_colnCurrencyDebitAmount))) 
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
			if (this.tblVoucherRow_colnCurrencyAmount.Number >= 0) 
			{
				this.tblVoucherRow_colnCurrencyDebitAmount.Number = this.SetAnotherValue(this.tblVoucherRow_colnCurrencyAmount.Number, this.tblVoucherRow_colnDebitAmount, "CURRENT_AMOUNT");
				this.tblVoucherRow_colnCurrencyDebitAmount.EditDataItemSetEdited();
				Sal.SendMsg(this.tblVoucherRow_colnCurrencyCreditAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, SalNumber.Null.ToString(0).ToHandle());
				Sal.SendMsg(this.tblVoucherRow_colnCreditAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, SalNumber.Null.ToString(0).ToHandle());
			}
			else
			{
				this.tblVoucherRow_colnCurrencyCreditAmount.Number = -this.SetAnotherValue(this.tblVoucherRow_colnCurrencyAmount.Number, this.tblVoucherRow_colnCreditAmount, "CURRENT_AMOUNT");
				this.tblVoucherRow_colnCurrencyCreditAmount.EditDataItemSetEdited();
				Sal.SendMsg(this.tblVoucherRow_colnCurrencyDebitAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, SalNumber.Null.ToString(0).ToHandle());
				Sal.SendMsg(this.tblVoucherRow_colnDebitAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, SalNumber.Null.ToString(0).ToHandle());
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
			if ((this.tblVoucherRow_colnCurrencyRate.Number <= 0) && (this.tblVoucherRow_colnCurrencyRate.Number != Sys.NUMBER_Null)) 
			{
				Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.ACC_ERROR_NegCurrRate, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
				Sal.SetFocus(this.tblVoucherRow_colnCurrencyRate.i_hWndSelf);
				e.Return = Sys.VALIDATE_Cancel;
				return;
			}
			if (this.tblVoucherRow_colnCurrencyAmount.Number != 0 && this.tblVoucherRow_colnCurrencyAmount.Number != Sys.NUMBER_Null) 
			{
				if (this.tblVoucherRow_colnCurrencyRate.Number != this.nPrevRate) 
				{
					this.tblVoucherRow_colnCurrencyRate.Number = this.SetAnotherValue(this.tblVoucherRow_colnCurrencyRate.Number, this.tblVoucherRow_colnCurrencyAmount, "RATE");
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
		private void tblVoucherRow_colnCurrencyRate_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if ((((SalString)this.tblVoucherRow_colsTransCode.Text).Trim().ToUpper() != "MANUAL") || (((SalString)this.tblVoucherRow_colsCurrencyCode.Text).Trim().ToUpper() == ((SalString)this.tblVoucherRow_colsBaseCurrencyCode.Text).Trim().ToUpper())) 
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
		private void tblVoucherRow_colnDebitAmount_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
					this.tblVoucherRow_colnDebitAmount_OnPM_DataItemValidate(sender, e);
					break;
					
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
					this.tblVoucherRow_colnDebitAmount_OnPM_DataItemQueryEnabled(sender, e);
					break;
			}
			#endregion
		}
			
		/// <summary>
		/// PM_DataItemValidate event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblVoucherRow_colnDebitAmount_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (this.tblVoucherRow_colnDebitAmount.Number != Sys.NUMBER_Null) 
			{
				if (this.tblVoucherRow_colnDebitAmount.Number < 0) 
				{
					this.tblVoucherRow_colnDebitAmount.Number = -this.tblVoucherRow_colnDebitAmount.Number;
				}
			}
			if (Sal.IsNull(this.tblVoucherRow_colnCreditAmount)) 
			{
				this.tblVoucherRow_colnDebitAmount.Number = this.SetAnotherValue(this.tblVoucherRow_colnDebitAmount.Number, this.tblVoucherRow_colnCurrencyDebitAmount, "ACCOUNTING_AMOUNT");
			}
			e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
			
		/// <summary>
		/// PM_DataItemQueryEnabled event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblVoucherRow_colnDebitAmount_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
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
			}
			if (Sal.IsNull(this.tblVoucherRow_colnDebitAmount)) 
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
			if (!(Sal.IsNull(this.tblVoucherRow_colnDebitAmount))) 
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
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
					this.tblVoucherRow_colnAmount_OnPM_DataItemValidate(sender, e);
					break;
			}
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
			if (this.tblVoucherRow_colnAmount.Number >= 0) 
			{
				this.tblVoucherRow_colnDebitAmount.Number = this.SetAnotherValue(this.tblVoucherRow_colnAmount.Number, this.tblVoucherRow_colnCurrencyDebitAmount, "ACCOUNTING_AMOUNT");
				this.tblVoucherRow_colnDebitAmount.EditDataItemSetEdited();
				Sal.SendMsg(this.tblVoucherRow_colnCreditAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, SalNumber.Null.ToString(0).ToHandle());
			}
			else
			{
				this.tblVoucherRow_colnCreditAmount.Number = -this.SetAnotherValue(this.tblVoucherRow_colnAmount.Number, this.tblVoucherRow_colnCurrencyCreditAmount, "ACCOUNTING_AMOUNT");
				this.tblVoucherRow_colnCreditAmount.EditDataItemSetEdited();
				Sal.SendMsg(this.tblVoucherRow_colnDebitAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, SalNumber.Null.ToString(0).ToHandle());
			}
			if (this.tblVoucherRow_colsCurrencyCode.Text == this.tblVoucherRow_colsBaseCurrencyCode.Text) 
			{
				this.tblVoucherRow_colnCurrencyDebitAmount.Number = this.tblVoucherRow_colnDebitAmount.Number;
				this.tblVoucherRow_colnCurrencyDebitAmount.EditDataItemSetEdited();
				this.tblVoucherRow_colnCurrencyAmount.Number = this.tblVoucherRow_colnDebitAmount.Number;
				this.tblVoucherRow_colnCurrencyAmount.EditDataItemSetEdited();
				this.tblVoucherRow_colnCurrencyCreditAmount.Number = Sys.NUMBER_Null;
				this.tblVoucherRow_colnCurrencyCreditAmount.EditDataItemSetEdited();
				if (this.tblVoucherRow_colnCreditAmount.Number == Sys.NUMBER_Null) 
				{
					this.tblVoucherRow_colnCurrencyDebitAmount.Number = this.tblVoucherRow_colnDebitAmount.Number;
					this.tblVoucherRow_colnCurrencyDebitAmount.EditDataItemSetEdited();
					this.tblVoucherRow_colnCurrencyAmount.Number = this.tblVoucherRow_colnDebitAmount.Number;
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
					this.tblVoucherRow_colnCurrencyDebitAmount.Number = Sys.NUMBER_Null;
					this.tblVoucherRow_colnCurrencyDebitAmount.EditDataItemSetEdited();
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
		private void tblVoucherRow_colsOptionalCode_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
					this.tblVoucherRow_colsOptionalCode_OnPM_DataItemValidate(sender, e);
					break;
			}
			#endregion
		}
			
		/// <summary>
		/// PM_DataItemValidate event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblVoucherRow_colsOptionalCode_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam) == Sys.VALIDATE_Cancel) 
			{
				e.Return = Sys.VALIDATE_Cancel;
				return;
			}
			if (this.tblVoucherRow_colsOptionalCode.Text != Ifs.Fnd.ApplicationForms.Const.strNULL) 
			{
				if (this.CheckTaxCode(this.tblVoucherRow_colsCompany.Text, this.tblVoucherRow_colsOptionalCode.Text)) 
				{
					e.Return = Sys.VALIDATE_Ok;
					return;
				}
				else
				{
					e.Return = Sys.VALIDATE_Cancel;
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
			if (Sal.IsNull(this.tblVoucherRow_colnProjectActivityId) || this.tblVoucherRow_colnProjectActivityId.Number == 0) 
			{
				if ((SalString.FromHandle(this.tblVoucherRow_colsProjectActivityIdEnabled.EditDataItemValueGet()) == "Y") && this.sProjectOriginGlobal != "FINPROJECT") 
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
			
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void tblVoucherRow_colsBaseCurrencyCode_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
					this.tblVoucherRow_colsBaseCurrencyCode_OnPM_DataItemValidate(sender, e);
					break;
			}
			#endregion
		}
			
		/// <summary>
		/// PM_DataItemValidate event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblVoucherRow_colsBaseCurrencyCode_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam) == Sys.VALIDATE_Cancel) 
			{
				e.Return = Sys.VALIDATE_Cancel;
				return;
			}
			if (!(Sal.IsNull(this.tblVoucherRow_colsBaseCurrencyCode))) 
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
		#endregion
			
		#region Window Events
		
        private void tblVoucherRow_EnableDisableProjectActivityIdEvent(object sender, cChildTableFin.cChildTableFinEventArgs e)
        {
            e.Handled = true;
            e.ReturnValue = this.EnableDisableProjectActivityId(e.sCodePartValue);
        }

        private void tblVoucherRow_DataSourceFormatSqlIntoUserEvent(object sender, FndReturnEventArgsSalString e)
        {
            e.Handled = true;
            e.ReturnValue = this.DataSourceFormatSqlIntoUser();
        }

        private void tblVoucherRow_DataSourceFormatSqlColumnUserEvent(object sender, FndReturnEventArgsSalString e)
        {
            e.Handled = true;
            e.ReturnValue = this.DataSourceFormatSqlColumnUser();
        }

        private void tblVoucherRow_DataRecordValidateEvent(object sender, FndReturnEventArgsSalBoolean e)
        {
            e.Handled = true;
            e.ReturnValue = this.DataRecordValidate();
        }

        private void tblVoucherRow_DataRecordNewEvent(object sender, cDataSource.DataRecordNewEventArgs e)
        {
            e.Handled = true;
            e.ReturnValue = this.DataRecordNew(e.nWhat);
        }
        
        private void tblVoucherRow_DataRecordGetDefaultsEvent(object sender, FndReturnEventArgsSalBoolean e)
        {
            e.Handled = true;
            e.ReturnValue = this.DataRecordGetDefaults();
        }

        private void tblVoucherRow_DataRecordDuplicateEvent(object sender, cDataSource.DataRecordDuplicateEventArgs e)
        {
            e.Handled = true;
            e.ReturnValue = this.DataRecordDuplicate(e.nWhat);
        }

        private void tblVoucherRow_DataRecordCheckRequiredEvent(object sender, FndReturnEventArgsSalBoolean e)
        {
            e.Handled = true;
            e.ReturnValue = this.DataRecordCheckRequired();
        }

        private void tblVoucherRow_DataRecordExecuteModifyEvent(object sender, cDataSource.DataRecordExecuteModifyEventArgs e)
        {
            e.Handled = true;
            e.ReturnValue = DataRecordExecuteModify(e.hSql);
        }
        #endregion

        private void tblVoucherRow_colsDeliveryTypeId_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblVoucherRow_colsDeliveryTypeId_OnPM_DataItemValidate(sender, e);
                    break;
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom:
                    this.tblVoucherRow_colsDeliveryTypeId_OnPM_DataItemZoom(sender, e);
                    break;
            }
            #endregion
        }

        private void tblVoucherRow_colsDeliveryTypeId_OnPM_DataItemZoom(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                this.sItemNames[0] = "COMPANY";
                this.hWndItems[0] = this.tblVoucherRow_colsCompany;
                this.sItemNames[1] = "DELIV_TYPE_ID";
                this.hWndItems[1] = this.tblVoucherRow_colsDeliveryTypeId;
                Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("MultiCompanyVoucherRow", this, this.sItemNames, this.hWndItems);
                SessionNavigate(Pal.GetActiveInstanceName("tbwDeliveryType"));

                e.Return = true;
                return;
            }
            else
            {
                e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom, Sys.wParam, Sys.lParam);
                return;
            }
            #endregion
        }

        private void tblVoucherRow_colsDeliveryTypeId_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (!(Sal.IsNull(this.tblVoucherRow_colsDeliveryTypeId)))
            {
                if (!(this.tblVoucherRow_colsDeliveryTypeId.DbPLSQLBlock(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "Voucher_Row_API.Validate_Delivery_Type_Id__(\r\n" +
                     " :i_hWndFrame.frmMCVoucherRow.tblVoucherRow_colsCompany IN,\r\n" +
                     " :i_hWndFrame.frmMCVoucherRow.tblVoucherRow_colsDeliveryTypeId IN)")))
                {
                    e.Return = false;
                    return;
                }

            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        #endregion
      
    }
}
