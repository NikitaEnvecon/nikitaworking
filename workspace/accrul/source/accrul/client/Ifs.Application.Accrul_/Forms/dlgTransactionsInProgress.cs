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

namespace Ifs.Application.Accrul_
{
	
	/// <summary>
	/// </summary>
	/// <param name="p_hParent"></param>
	/// <param name="p_nMinRow"></param>
	/// <param name="p_sCompany"></param>
	/// <param name="p_nAccountingYear"></param>
	/// <param name="p_sAction"></param>
	public partial class dlgTransactionsInProgress : cDialogBoxFin
	{
		#region Window Parameters
		public SalWindowHandle p_hParent;
		public SalNumber p_nMinRow;
		public SalString p_sCompany;
		public SalNumber p_nAccountingYear;
		public SalString p_sAction;
		#endregion
		
		#region Window Variables
		public SalNumber nVouPostMethodAvailable = 0;
		public SalString sNonUpdatedVouExist = "";
		public SalString sVoucherTransExist = "";
		public SalNumber nPeriodAllocMethodAvailable = 0;
		public SalString sNonUpdPeriodAllocExist = "";
		public SalString sPeriodAllocTransExist = "";
		public SalNumber nInvMethodAvailable = 0;
		public SalString sPostErrInvs = "";
		public SalString sPostErrInvTransExist = "";
        // Bug 109339, Begin 
        public SalNumber nPrelimInvMethodAvailable = 0;
        public SalString sPrelimInvs = "";
        public SalString sPrelimInvsExist = "";
        // Bug 109339, End
		public SalNumber nPrelPayMethodAvailable = 0;
		public SalString sNonApprovedPayExist = "";
		public SalString sPrelPayTransExist = "";
		public SalString sNonApprovedPayType = "";
		public SalNumber nMixPayMethodAvailable = 0;
		public SalString sMixPayApproved = "";
		public SalString sMixPayTransExist = "";
		public SalNumber nCashBoxMethodAvailable = 0;
		public SalString sCashBoxApproved = "";
		public SalString sCashBoxTransExist = "";
		public SalNumber nExtVouMethodAvailable = 0;
		public SalString sNonCreatedExtVouExist = "";
		public SalString sExtVouTransExist = "";
		public SalNumber nExtIncInvMethodAvailable = 0;
		public SalString sNonCreatedExtIncInvExist = "";
		public SalString sExtIncInvTransExist = "";
		public SalNumber nExtOutInvMethodAvailable = 0;
		public SalString sNonCreatedExtOutInvExist = "";
		public SalString sExtOutInvTransExist = "";
		public SalNumber nExtPayMethodAvailable = 0;
		public SalString sNonUsedExtPayExist = "";
		public SalString sExtPayTransExist = "";
		public SalNumber nFaImpTransMethodAvailable = 0;
		public SalString sNonPostedFaImpTransExist = "";
		public SalString sFaImpTransExist = "";
		public SalNumber nFaChangeAcqTransMethodAvailable = 0;
		public SalString sNonPostedFaChangeAcqTransExist = "";
		public SalString sFaChangeAcqTransExist = "";
		public SalNumber nFaChangeNetTransMethodAvailable = 0;
		public SalString sNonPostedFaChangeNetTransExist = "";
		public SalString sFaChangeNetTransExist = "";
		public SalNumber nFaDeprProposalMethodAvailable = 0;
		public SalString sNonPostedFaDeprProposalExist = "";
		public SalString sFaDeprProposalTransExist = "";
		public SalNumber nCurrRevMethodAvailable = 0;
		public SalString sNonPostedCurrRevExist = "";
		public SalString sCurrRevTransExist = "";
		public SalNumber nRevenueMethodAvailable = 0;
		public SalString sNonPostedRevenueExist = "";
		public SalString sRevenueTransExist = "";
		public SalNumber nPcaMethodAvailable = 0;
		public SalString sNonClosedPcaExist = "";
		public SalString sPcaTransExist = "";
		public SalNumber nConsolidationMethodAvailable = 0;
		public SalString sNonConsolidatedBalanceExist = "";
		public SalString sConsBalanceTransExist = "";
		public SalString sSubsCompanies = "";
		public SalNumber nMpccomPostingMethodAvailable = 0;
		public SalString sMpccomPostingsTransferred = "";
		public SalString sMpccomPostingTransExist = "";
		public SalArray<SalString> sParam = new SalArray<SalString>();
		public SalString sYearOpening = "";
		public SalBoolean bTransErrorExist = false;
		public SalNumber nPcmPostingMethodAvailable = 0;
		public SalString sPcmPostingsTransferred = "";
		public SalString sPcmPostingTransExist = "";
		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		protected dlgTransactionsInProgress()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
		}
		#endregion
		
		#region System Methods/Properties
		
		/// <summary>
		/// Shows the modal dialog.
		/// </summary>
		/// <param name="owner"></param>
		/// <returns></returns>
		public static SalNumber ModalDialog(Control owner, SalWindowHandle p_hParent, SalNumber p_nMinRow, SalString p_sCompany, SalNumber p_nAccountingYear, SalString p_sAction)
		{
			dlgTransactionsInProgress dlg = DialogFactory.CreateInstance<dlgTransactionsInProgress>();
			dlg.p_hParent = p_hParent;
			dlg.p_nMinRow = p_nMinRow;
			dlg.p_sCompany = p_sCompany;
			dlg.p_nAccountingYear = p_nAccountingYear;
			dlg.p_sAction = p_sAction;
			SalNumber ret = dlg.ShowDialog(owner);
			return ret;
		}
		
		/// <summary>
		/// Returns the object instance associated with the window handle.
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public new static dlgTransactionsInProgress FromHandle(SalWindowHandle handle)
		{
			return ((dlgTransactionsInProgress)SalWindow.FromHandle(handle, typeof(dlgTransactionsInProgress)));
		}
		#endregion
		
		#region Methods
		
		/// <summary>
		/// </summary>
		/// <param name="nWhat"></param>
		/// <param name="sMethod"></param>
		/// <returns></returns>
		public new SalNumber UserMethod(SalNumber nWhat, SalString sMethod)
		{
			#region Local Variables
			SalString sName = "";
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				if (sMethod == "Cancel") 
				{
					if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire) 
					{
						return 1;
					}
					else if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
					{
						Sal.EndDialog(i_hWndSelf, Sys.IDCANCEL);
						return 1;
					}
				}
				if (sMethod == "OK") 
				{
					if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire) 
					{
						if (p_sAction == "VALIDATE") 
						{
							return 1;
						}
						return 0;
					}
					else if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
					{
						Sal.EndDialog(i_hWndSelf, Sys.IDOK);
						return 1;
					}
				}
				if (sMethod == "ClosePeriod") 
				{
					if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire) 
					{
						if (p_sAction == "CLOSE" && !(bTransErrorExist)) 
						{
							return 1;
						}
						return 0;
					}
					else if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
					{
						Sal.EndDialog(i_hWndSelf, 10);
						return 1;
					}
				}
				if (sMethod == "CloseFinally") 
				{
					if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire) 
					{
						if (p_sAction == "CLOSE_FIN" && !(bTransErrorExist)) 
						{
							return 1;
						}
						return 0;
					}
					else if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
					{
						Sal.EndDialog(i_hWndSelf, 20);
						return 1;
					}
				}
				else
				{
					return 0;
				}
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public new SalBoolean FrameStartupUser()
		{
			#region Actions
			using (new SalContext(this))
			{
				Sal.WaitCursor(true);
                // Bug 109339, Begin, added method for preliminary invoices
				using(SignatureHints hints = SignatureHints.NewContext())
				{
					hints.Add("Period_Type_API.Decode", System.Data.ParameterDirection.Input);
					hints.Add("Dictionary_SYS.Method_Is_Installed_Num", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
					if (!(DbPLSQLBlock(cSessionManager.c_hSql, " BEGIN\r\n" +
						"				:i_hWndFrame.dlgTransactionsInProgress.sYearOpening := &AO.Period_Type_API.Decode('YEAROPEN');\r\n" +
						"				:i_hWndFrame.dlgTransactionsInProgress.nVouPostMethodAvailable :=\r\n" +
						"				&AO.Dictionary_SYS.Method_Is_Installed_Num('VOUCHER_API','Check_If_Postings_In_Voucher');\r\n" +
						"				:i_hWndFrame.dlgTransactionsInProgress.nPeriodAllocMethodAvailable :=\r\n" +
						"				&AO.Dictionary_SYS.Method_Is_Installed_Num('Period_Allocation_API','Check_Year_Period_Exist');\r\n" +
						"				:i_hWndFrame.dlgTransactionsInProgress.nInvMethodAvailable :=\r\n" +
						"				&AO.Dictionary_SYS.Method_Is_Installed_Num('INVOICE_API','POST_ERROR_INVS_EXIST');\r\n" +
                        "				:i_hWndFrame.dlgTransactionsInProgress.nPrelimInvMethodAvailable :=\r\n" +
                        "				&AO.Dictionary_SYS.Method_Is_Installed_Num('INVOICE_UTILITY_PUB_API', 'Preliminary_Invs_Exist');\r\n" +
						"				:i_hWndFrame.dlgTransactionsInProgress.nPrelPayMethodAvailable :=\r\n" +
						"				&AO.Dictionary_SYS.Method_Is_Installed_Num('PREL_PAYMENT_TRANS_UTIL_API','CHECK_NON_APPROVED_PAYM_EXISTS');\r\n" +
						"				:i_hWndFrame.dlgTransactionsInProgress.nMixPayMethodAvailable :=\r\n" +
						"				&AO.Dictionary_SYS.Method_Is_Installed_Num('MIXED_PAYMENT_API','ALL_APPROVED_FOR_PERIOD');\r\n" +
						"				:i_hWndFrame.dlgTransactionsInProgress.nCashBoxMethodAvailable :=\r\n" +
						"				&AO.Dictionary_SYS.Method_Is_Installed_Num('CASH_BOX_API','ALL_APPROVED_FOR_PERIOD');\r\n" +
						"				:i_hWndFrame.dlgTransactionsInProgress.nExtVouMethodAvailable :=\r\n" +
						"				&AO.Dictionary_SYS.Method_Is_Installed_Num('EXT_LOAD_INFO_API','Check_Non_Created_ExtVou_Exist');\r\n" +
						"				:i_hWndFrame.dlgTransactionsInProgress.nExtIncInvMethodAvailable :=\r\n" +
						"				&AO.Dictionary_SYS.Method_Is_Installed_Num('EXT_INC_INV_LOAD_INFO_API','Check_Non_Created_Inv_Exist');\r\n" +
						"				:i_hWndFrame.dlgTransactionsInProgress.nExtOutInvMethodAvailable :=\r\n" +
						"				&AO.Dictionary_SYS.Method_Is_Installed_Num('EXT_OUT_INV_LOAD_INFO_API','Check_Non_Created_Inv_Exist');\r\n" +
						"				:i_hWndFrame.dlgTransactionsInProgress.nExtPayMethodAvailable :=\r\n" +
						"				&AO.Dictionary_SYS.Method_Is_Installed_Num('EXT_PAYMENT_HEAD_API','Check_Non_Used_Pay_Exist');\r\n" +
						"				:i_hWndFrame.dlgTransactionsInProgress.nFaImpTransMethodAvailable :=\r\n" +
						"				&AO.Dictionary_SYS.Method_Is_Installed_Num('FA_OBJECT_TRANSACTION_API','All_Imp_Trans_Post_For_Period');\r\n" +
						"				:i_hWndFrame.dlgTransactionsInProgress.nFaChangeAcqTransMethodAvailable :=\r\n" +
						"				&AO.Dictionary_SYS.Method_Is_Installed_Num('CHANGE_OBJECT_VALUE_TEMP_API','All_Change_Acq_Post_For_Period');\r\n" +
						"				:i_hWndFrame.dlgTransactionsInProgress.nFaChangeNetTransMethodAvailable :=\r\n" +
						"				&AO.Dictionary_SYS.Method_Is_Installed_Num('CHANGE_OBJECT_VALUE_TEMP_API','All_Change_Net_Post_For_Period');\r\n" +
						"				:i_hWndFrame.dlgTransactionsInProgress.nFaDeprProposalMethodAvailable :=\r\n" +
						"				&AO.Dictionary_SYS.Method_Is_Installed_Num('DEPR_PROPOSAL_API','All_Proposal_Post_For_Period');\r\n" +
						"				:i_hWndFrame.dlgTransactionsInProgress.nCurrRevMethodAvailable :=\r\n" +
						"				&AO.Dictionary_SYS.Method_Is_Installed_Num('CURRENCY_REVALUATION_API','Check_Non_Posted_Reval_Exist');\r\n" +
						"				:i_hWndFrame.dlgTransactionsInProgress.nRevenueMethodAvailable :=\r\n" +
						"				&AO.Dictionary_SYS.Method_Is_Installed_Num('REVENUE_RECOGNITION_API','All_Posted_For_Period');\r\n" +
						"				:i_hWndFrame.dlgTransactionsInProgress.nPcaMethodAvailable :=\r\n" +
						"				&AO.Dictionary_SYS.Method_Is_Installed_Num('COST_ALLOCATION_PROCEDURE_API','Check_Non_Closed_Proc_Exist');\r\n" +
						"				:i_hWndFrame.dlgTransactionsInProgress.nConsolidationMethodAvailable :=\r\n" +
						"				&AO.Dictionary_SYS.Method_Is_Installed_Num('COMPANY_CONS_TRANS_API','All_Bal_Trans_Cons_For_Period');\r\n" +
						"				:i_hWndFrame.dlgTransactionsInProgress.nMpccomPostingMethodAvailable :=\r\n" +
						"				&AO.Dictionary_SYS.Method_Is_Installed_Num('MPCCOM_ACCOUNTING_API','All_Postings_Transferred');\r\n" +
						"				:i_hWndFrame.dlgTransactionsInProgress.nPcmPostingMethodAvailable :=\r\n" +
						"               &AO.Dictionary_SYS.Method_Is_Installed_Num('PCM_ACCOUNTING_API','All_Postings_Transferred');\r\n			END;"))) 
					{
						Sal.WaitCursor(false);
						return false;
					}
				}
                // Bug 109339, End

				// Validate transactions and populate form anly if user have access to all server functions
				bTransErrorExist = false;
                // Bug 109339, Begin, added method for preliminary invoices
                if ((nVouPostMethodAvailable == 1 && !(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Voucher_API.Check_If_Postings_In_Voucher"))) || (nPeriodAllocMethodAvailable == 1 && !(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable(
                    "Period_Allocation_API.Check_Year_Period_Exist"))) || (nInvMethodAvailable == 1 && !(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Invoice_API.Post_Error_Invs_Exist"))) || (nPrelimInvMethodAvailable == 1 && !(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable(
                    "Invoice_Utility_Pub_API.Preliminary_Invs_Exist"))) || (nPrelPayMethodAvailable == 1 && !(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("PREL_PAYMENT_TRANS_UTIL_API.CHECK_NON_APPROVED_PAYM_EXISTS"))) || (nMixPayMethodAvailable ==
                1 && !(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Mixed_Payment_API.All_Approved_For_Period"))) || (nCashBoxMethodAvailable == 1 && !(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Cash_Box_API.All_Approved_For_Period"))) ||
                (nExtVouMethodAvailable == 1 && !(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Ext_Load_Info_API.Check_Non_Created_ExtVou_Exist"))) || (nExtIncInvMethodAvailable == 1 && !(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable(
                    "Ext_Inc_Inv_Load_Info_API.Check_Non_Created_Inv_Exist"))) || (nExtOutInvMethodAvailable == 1 && !(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Ext_Out_Inv_Load_Info_API.Check_Non_Created_Inv_Exist"))) || (nExtPayMethodAvailable ==
                1 && !(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Ext_Payment_Head_API.Check_Non_Used_Pay_Exist"))) || (nFaImpTransMethodAvailable == 1 && !(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Fa_Object_Transaction_API.All_Imp_Trans_Post_For_Period"))) ||
                (nFaChangeAcqTransMethodAvailable == 1 && !(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Change_Object_Value_Temp_API.All_Change_Acq_Post_For_Period"))) || (nFaChangeNetTransMethodAvailable == 1 && !(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable(
                    "Change_Object_Value_Temp_API.All_Change_Net_Post_For_Period"))) || (nFaDeprProposalMethodAvailable == 1 && !(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Depr_Proposal_API.All_Proposal_Post_For_Period"))) || (nCurrRevMethodAvailable ==
                1 && !(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Currency_Revaluation_API.Check_Non_Posted_Reval_Exist"))) || (nRevenueMethodAvailable == 1 && !(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Revenue_Recognition_API.All_Posted_For_Period"))) ||
                (nPcaMethodAvailable == 1 && !(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Cost_Allocation_Procedure_API.Check_Non_Closed_Proc_Exist"))) || (nConsolidationMethodAvailable == 1 && !(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable(
                    "Company_Cons_Trans_API.All_Bal_Trans_Cons_For_Period"))) || (nMpccomPostingMethodAvailable == 1 && !(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Mpccom_Accounting_API.All_Postings_Transferred"))) || (nPcmPostingMethodAvailable ==
                1 && !(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Pcm_Accounting_API.All_Postings_Transferred")))) 
				{
					bTransErrorExist = true;
				}
				else
				{
					CheckTransInProgress();
					PopulateForm();
				}
                // Bug 109339, End
				pbClosePeriod.MethodInvestigateState();
				pbCloseFinally.MethodInvestigateState();
				Sal.SetDefButton(pbCancel);
				Sal.WaitCursor(false);
				return true;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean CheckTransInProgress()
		{
			#region Local Variables
			SalString lsStmt = "";
			SalString lsStmt1 = "";
			SalString lsStmt2 = "";
			SalNumber nCurrentRow = 0;
			SalNumber nOldRow = 0;
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				// Validation for all types of periods (lsStmt1)
				if (nVouPostMethodAvailable == 1) 
				{
					lsStmt1 = lsStmt1 + "&AO.Voucher_API.Check_If_Postings_In_Voucher(\r\n" +
					"			:i_hWndFrame.dlgTransactionsInProgress.sNonUpdatedVouExist, \r\n" +
					"			:i_hWndFrame.dlgTransactionsInProgress.p_sCompany,\r\n" +
					"			:i_hWndFrame.dlgTransactionsInProgress.p_hParent.frmAccPer.tblAccPerDetail_colAccountingPeriod,\r\n" +
					"			:i_hWndFrame.dlgTransactionsInProgress.p_nAccountingYear); ";
				}
				if (nPeriodAllocMethodAvailable == 1) 
				{
					lsStmt1 = lsStmt1 + " :i_hWndFrame.dlgTransactionsInProgress.sNonUpdPeriodAllocExist :=\r\n" +
					"			&AO.Period_Allocation_API.Check_Year_Period_Exist(\r\n" +
					"			:i_hWndFrame.dlgTransactionsInProgress.p_sCompany,\r\n" +
					"			:i_hWndFrame.dlgTransactionsInProgress.p_nAccountingYear,\r\n" +
					"			:i_hWndFrame.dlgTransactionsInProgress.p_hParent.frmAccPer.tblAccPerDetail_colAccountingPeriod); ";
				}
				if (nPcaMethodAvailable == 1) 
				{
					lsStmt1 = lsStmt1 + " :i_hWndFrame.dlgTransactionsInProgress.sNonClosedPcaExist :=\r\n" +
					"			&AO.Cost_Allocation_Procedure_API.Check_Non_Closed_Proc_Exist(\r\n" +
					"			:i_hWndFrame.dlgTransactionsInProgress.p_sCompany,\r\n" +
					"			:i_hWndFrame.dlgTransactionsInProgress.p_nAccountingYear,\r\n" +
					"			:i_hWndFrame.dlgTransactionsInProgress.p_hParent.frmAccPer.tblAccPerDetail_colAccountingPeriod); ";
				}
				if (nCurrRevMethodAvailable == 1) 
				{
					lsStmt1 = lsStmt1 + " :i_hWndFrame.dlgTransactionsInProgress.sNonPostedCurrRevExist :=\r\n" +
					"			&AO.Currency_Revaluation_API.Check_Non_Posted_Reval_Exist(\r\n" +
					"			:i_hWndFrame.dlgTransactionsInProgress.p_sCompany,\r\n" +
					"			:i_hWndFrame.dlgTransactionsInProgress.p_nAccountingYear,\r\n" +
					"			:i_hWndFrame.dlgTransactionsInProgress.p_hParent.frmAccPer.tblAccPerDetail_colAccountingPeriod); ";
				}
				if (nRevenueMethodAvailable == 1) 
				{
					lsStmt1 = lsStmt1 + " :i_hWndFrame.dlgTransactionsInProgress.sNonPostedRevenueExist :=\r\n" +
					"			&AO.Revenue_Recognition_API.All_Posted_For_Period(\r\n" +
					"			:i_hWndFrame.dlgTransactionsInProgress.p_sCompany,\r\n" +
					"			:i_hWndFrame.dlgTransactionsInProgress.p_nAccountingYear,\r\n" +
					"			:i_hWndFrame.dlgTransactionsInProgress.p_hParent.frmAccPer.tblAccPerDetail_colAccountingPeriod); ";
				}
				if (nConsolidationMethodAvailable == 1) 
				{
					lsStmt1 = lsStmt1 + " :i_hWndFrame.dlgTransactionsInProgress.sSubsCompanies :=\r\n" +
					"			&AO.Company_Cons_Trans_API.All_Bal_Trans_Cons_For_Period(                                                \r\n" +
					"			:i_hWndFrame.dlgTransactionsInProgress.p_sCompany,\r\n" +
					"			:i_hWndFrame.dlgTransactionsInProgress.p_nAccountingYear,\r\n" +
					"			:i_hWndFrame.dlgTransactionsInProgress.p_hParent.frmAccPer.tblAccPerDetail_colAccountingPeriod); ";
				}
				// Bug Id 91840,Begin
				if (nMpccomPostingMethodAvailable == 1) 
				{
					lsStmt1 = lsStmt1 + " :i_hWndFrame.dlgTransactionsInProgress.sMpccomPostingsTransferred :=\r\n" +
					"			&AO.Mpccom_Accounting_API.All_Postings_Transferred(\r\n" +
					"			:i_hWndFrame.dlgTransactionsInProgress.p_sCompany,\r\n" +
					"			:i_hWndFrame.dlgTransactionsInProgress.p_hParent.frmAccPer.tblAccPerDetail_coldDateFrom,\r\n" +
					"			:i_hWndFrame.dlgTransactionsInProgress.p_hParent.frmAccPer.tblAccPerDetail_coldDateUntil); ";
				}
				// Bug Id 91840, End
				if (nPcmPostingMethodAvailable == 1) 
				{
					lsStmt1 = lsStmt1 + " :i_hWndFrame.dlgTransactionsInProgress.sPcmPostingsTransferred :=\r\n" +
					"			&AO.Pcm_Accounting_API.All_Postings_Transferred(\r\n" +
					"			:i_hWndFrame.dlgTransactionsInProgress.p_sCompany,\r\n" +
					"			:i_hWndFrame.dlgTransactionsInProgress.p_hParent.frmAccPer.tblAccPerDetail_coldDateFrom,\r\n" +
					"			:i_hWndFrame.dlgTransactionsInProgress.p_hParent.frmAccPer.tblAccPerDetail_coldDateUntil); ";
				}
				// Don't do this validation for Opening Period (lsStmt2)
				if (nInvMethodAvailable == 1) 
				{
					lsStmt2 = lsStmt2 + " &AO.Invoice_API.Post_Error_Invs_Exist(\r\n" +
					"			:i_hWndFrame.dlgTransactionsInProgress.sPostErrInvs,\r\n" +
					"			:i_hWndFrame.dlgTransactionsInProgress.p_sCompany,\r\n" +
					"			:i_hWndFrame.dlgTransactionsInProgress.p_nAccountingYear,\r\n" +
					"			:i_hWndFrame.dlgTransactionsInProgress.p_hParent.frmAccPer.tblAccPerDetail_colAccountingPeriod,\r\n" +
					"			:i_hWndFrame.dlgTransactionsInProgress.p_hParent.frmAccPer.tblAccPerDetail_coldDateFrom,\r\n" +
					"			:i_hWndFrame.dlgTransactionsInProgress.p_hParent.frmAccPer.tblAccPerDetail_coldDateUntil);";
				}
                // Bug 109339, Begin
                if (nPrelimInvMethodAvailable == 1)
                {
                    lsStmt2 = lsStmt2 + " &AO.Invoice_Utility_Pub_API.Preliminary_Invs_Exist(\r\n" +
                    "			:i_hWndFrame.dlgTransactionsInProgress.sPrelimInvs,\r\n" +
                    "			:i_hWndFrame.dlgTransactionsInProgress.p_sCompany,\r\n" +
                    "			:i_hWndFrame.dlgTransactionsInProgress.p_nAccountingYear,\r\n" +
                    "			:i_hWndFrame.dlgTransactionsInProgress.p_hParent.frmAccPer.tblAccPerDetail_colAccountingPeriod,\r\n" +
                    "			:i_hWndFrame.dlgTransactionsInProgress.p_hParent.frmAccPer.tblAccPerDetail_coldDateFrom,\r\n" +
                    "			:i_hWndFrame.dlgTransactionsInProgress.p_hParent.frmAccPer.tblAccPerDetail_coldDateUntil);";
                }
                // Bug 109339, End
				if (nPrelPayMethodAvailable == 1) 
				{
					lsStmt2 = lsStmt2 + " &AO.PREL_PAYMENT_TRANS_UTIL_API.CHECK_NON_APPROVED_PAYM_EXISTS(\r\n" +
					"			:i_hWndFrame.dlgTransactionsInProgress.sNonApprovedPayExist,\r\n" +
					"			:i_hWndFrame.dlgTransactionsInProgress.sNonApprovedPayType,\r\n" +
					"			:i_hWndFrame.dlgTransactionsInProgress.p_sCompany,\r\n" +
					"			:i_hWndFrame.dlgTransactionsInProgress.p_nAccountingYear,\r\n" +
					"			:i_hWndFrame.dlgTransactionsInProgress.p_hParent.frmAccPer.tblAccPerDetail_colAccountingPeriod,\r\n" +
					"			:i_hWndFrame.dlgTransactionsInProgress.p_hParent.frmAccPer.tblAccPerDetail_coldDateFrom,\r\n" +
					"			:i_hWndFrame.dlgTransactionsInProgress.p_hParent.frmAccPer.tblAccPerDetail_coldDateUntil);";
				}
				if (nMixPayMethodAvailable == 1) 
				{
					lsStmt2 = lsStmt2 + " :i_hWndFrame.dlgTransactionsInProgress.sMixPayApproved :=\r\n" +
					"			&AO.Mixed_Payment_API.All_Approved_For_Period(\r\n" +
					"			:i_hWndFrame.dlgTransactionsInProgress.p_sCompany,\r\n" +
					"			:i_hWndFrame.dlgTransactionsInProgress.p_nAccountingYear,\r\n" +
					"			:i_hWndFrame.dlgTransactionsInProgress.p_hParent.frmAccPer.tblAccPerDetail_colAccountingPeriod,\r\n" +
					"			:i_hWndFrame.dlgTransactionsInProgress.p_hParent.frmAccPer.tblAccPerDetail_coldDateFrom,\r\n" +
					"			:i_hWndFrame.dlgTransactionsInProgress.p_hParent.frmAccPer.tblAccPerDetail_coldDateUntil);";
				}
				if (nCashBoxMethodAvailable == 1) 
				{
					lsStmt2 = lsStmt2 + " :i_hWndFrame.dlgTransactionsInProgress.sCashBoxApproved :=\r\n" +
					"			&AO.Cash_Box_API.All_Approved_For_Period(\r\n" +
					"			:i_hWndFrame.dlgTransactionsInProgress.p_sCompany,\r\n" +
					"			:i_hWndFrame.dlgTransactionsInProgress.p_nAccountingYear,\r\n" +
					"			:i_hWndFrame.dlgTransactionsInProgress.p_hParent.frmAccPer.tblAccPerDetail_colAccountingPeriod,\r\n" +
					"			:i_hWndFrame.dlgTransactionsInProgress.p_hParent.frmAccPer.tblAccPerDetail_coldDateFrom,\r\n" +
					"			:i_hWndFrame.dlgTransactionsInProgress.p_hParent.frmAccPer.tblAccPerDetail_coldDateUntil); ";
				}
				if (nFaImpTransMethodAvailable == 1) 
				{
					lsStmt2 = lsStmt2 + " :i_hWndFrame.dlgTransactionsInProgress.sNonPostedFaImpTransExist :=\r\n" +
					"			&AO.Fa_Object_Transaction_API.All_Imp_Trans_Post_For_Period(\r\n" +
					"			:i_hWndFrame.dlgTransactionsInProgress.p_sCompany,			\r\n" +
					"			:i_hWndFrame.dlgTransactionsInProgress.p_hParent.frmAccPer.tblAccPerDetail_coldDateFrom,\r\n" +
					"			:i_hWndFrame.dlgTransactionsInProgress.p_hParent.frmAccPer.tblAccPerDetail_coldDateUntil); ";
				}
				if (nFaChangeAcqTransMethodAvailable == 1) 
				{
					lsStmt2 = lsStmt2 + " :i_hWndFrame.dlgTransactionsInProgress.sNonPostedFaChangeAcqTransExist :=\r\n" +
					"			&AO.Change_Object_Value_Temp_API.All_Change_Acq_Post_For_Period(\r\n" +
					"			:i_hWndFrame.dlgTransactionsInProgress.p_sCompany,			\r\n" +
					"			:i_hWndFrame.dlgTransactionsInProgress.p_hParent.frmAccPer.tblAccPerDetail_coldDateFrom,\r\n" +
					"			:i_hWndFrame.dlgTransactionsInProgress.p_hParent.frmAccPer.tblAccPerDetail_coldDateUntil); ";
				}
				if (nFaChangeNetTransMethodAvailable == 1) 
				{
					lsStmt2 = lsStmt2 + " :i_hWndFrame.dlgTransactionsInProgress.sNonPostedFaChangeNetTransExist :=\r\n" +
					"			&AO.Change_Object_Value_Temp_API.All_Change_Net_Post_For_Period(\r\n" +
					"			:i_hWndFrame.dlgTransactionsInProgress.p_sCompany,			\r\n" +
					"			:i_hWndFrame.dlgTransactionsInProgress.p_hParent.frmAccPer.tblAccPerDetail_coldDateFrom,\r\n" +
					"			:i_hWndFrame.dlgTransactionsInProgress.p_hParent.frmAccPer.tblAccPerDetail_coldDateUntil); ";
				}
				if (nFaDeprProposalMethodAvailable == 1) 
				{
					lsStmt2 = lsStmt2 + " :i_hWndFrame.dlgTransactionsInProgress.sNonPostedFaDeprProposalExist :=\r\n" +
					"			&AO.Depr_Proposal_API.All_Proposal_Post_For_Period(\r\n" +
					"			:i_hWndFrame.dlgTransactionsInProgress.p_sCompany,\r\n" +
					"			:i_hWndFrame.dlgTransactionsInProgress.p_nAccountingYear,\r\n" +
					"			:i_hWndFrame.dlgTransactionsInProgress.p_hParent.frmAccPer.tblAccPerDetail_colAccountingPeriod); ";
				}
				if (nExtVouMethodAvailable == 1) 
				{
					lsStmt2 = lsStmt2 + " :i_hWndFrame.dlgTransactionsInProgress.sNonCreatedExtVouExist :=\r\n" +
					"			&AO.Ext_Load_Info_API.Check_Non_Created_ExtVou_Exist(\r\n" +
					"			:i_hWndFrame.dlgTransactionsInProgress.p_sCompany,			\r\n" +
					"			:i_hWndFrame.dlgTransactionsInProgress.p_hParent.frmAccPer.tblAccPerDetail_coldDateFrom,\r\n" +
					"			:i_hWndFrame.dlgTransactionsInProgress.p_hParent.frmAccPer.tblAccPerDetail_coldDateUntil); ";
				}
				if (nExtIncInvMethodAvailable == 1) 
				{
					lsStmt2 = lsStmt2 + " :i_hWndFrame.dlgTransactionsInProgress.sNonCreatedExtIncInvExist :=\r\n" +
					"			&AO.Ext_Inc_Inv_Load_Info_API.Check_Non_Created_Inv_Exist(\r\n" +
					"			:i_hWndFrame.dlgTransactionsInProgress.p_sCompany,\r\n" +
					"			:i_hWndFrame.dlgTransactionsInProgress.p_nAccountingYear,\r\n" +
					"			:i_hWndFrame.dlgTransactionsInProgress.p_hParent.frmAccPer.tblAccPerDetail_colAccountingPeriod,\r\n" +
					"			:i_hWndFrame.dlgTransactionsInProgress.p_hParent.frmAccPer.tblAccPerDetail_coldDateFrom,\r\n" +
					"			:i_hWndFrame.dlgTransactionsInProgress.p_hParent.frmAccPer.tblAccPerDetail_coldDateUntil); ";
				}
				if (nExtOutInvMethodAvailable == 1) 
				{
					lsStmt2 = lsStmt2 + " :i_hWndFrame.dlgTransactionsInProgress.sNonCreatedExtOutInvExist :=\r\n" +
					"			&AO.Ext_Out_Inv_Load_Info_API.Check_Non_Created_Inv_Exist(\r\n" +
					"			:i_hWndFrame.dlgTransactionsInProgress.p_sCompany,\r\n" +
					"			:i_hWndFrame.dlgTransactionsInProgress.p_nAccountingYear,\r\n" +
					"			:i_hWndFrame.dlgTransactionsInProgress.p_hParent.frmAccPer.tblAccPerDetail_colAccountingPeriod,\r\n" +
					"			:i_hWndFrame.dlgTransactionsInProgress.p_hParent.frmAccPer.tblAccPerDetail_coldDateFrom,\r\n" +
					"			:i_hWndFrame.dlgTransactionsInProgress.p_hParent.frmAccPer.tblAccPerDetail_coldDateUntil); ";
				}
				if (nExtPayMethodAvailable == 1) 
				{
					lsStmt2 = lsStmt2 + " :i_hWndFrame.dlgTransactionsInProgress.sNonUsedExtPayExist :=\r\n" +
					"			&AO.Ext_Payment_Head_API.Check_Non_Used_Pay_Exist(\r\n" +
					"			:i_hWndFrame.dlgTransactionsInProgress.p_sCompany,\r\n" +
					"			:i_hWndFrame.dlgTransactionsInProgress.p_nAccountingYear,\r\n" +
					"			:i_hWndFrame.dlgTransactionsInProgress.p_hParent.frmAccPer.tblAccPerDetail_colAccountingPeriod,\r\n" +
					"			:i_hWndFrame.dlgTransactionsInProgress.p_hParent.frmAccPer.tblAccPerDetail_coldDateFrom,\r\n" +
					"			:i_hWndFrame.dlgTransactionsInProgress.p_hParent.frmAccPer.tblAccPerDetail_coldDateUntil); ";
				}
				// Bug Id 91840, Begin- Removed the nMpccomPostingMethodAvailable variable check to error section

				sNonUpdatedVouExist = "FALSE";
				sNonUpdPeriodAllocExist = "FALSE";
				sPostErrInvTransExist = "FALSE";
                // Bug 109339, Begin
                sPrelimInvsExist = "FALSE";
                // Bug 109339, End
				sPrelPayTransExist = "FALSE";
				sMixPayTransExist = "FALSE";
				sCashBoxTransExist = "FALSE";
				sExtVouTransExist = "FALSE";
				sExtIncInvTransExist = "FALSE";
				sExtOutInvTransExist = "FALSE";
				sExtPayTransExist = "FALSE";
				sFaImpTransExist = "FALSE";
				sFaChangeAcqTransExist = "FALSE";
				sFaChangeNetTransExist = "FALSE";
				sFaDeprProposalTransExist = "FALSE";
				sCurrRevTransExist = "FALSE";
				sRevenueTransExist = "FALSE";
				sConsBalanceTransExist = "FALSE";
				sPcaTransExist = "FALSE";
				sMpccomPostingTransExist = "FALSE";
				sPcmPostingTransExist = "FALSE";

				nOldRow = Sal.TblQueryContext(frmAccPer.FromHandle(p_hParent).tblAccPerDetail);
				nCurrentRow = p_nMinRow;
				while (Sal.TblFindNextRow(frmAccPer.FromHandle(p_hParent).tblAccPerDetail, ref nCurrentRow, Sys.ROW_Selected, 0)) 
				{
					Sal.TblSetContext(frmAccPer.FromHandle(p_hParent).tblAccPerDetail, nCurrentRow);
					lsStmt = "BEGIN " + lsStmt1;
					// Don't do this validation for Opening Period (lsStmt2)
					if (frmAccPer.FromHandle(p_hParent).tblAccPerDetail_colsPeriodType.Text != sYearOpening) 
					{
						lsStmt = lsStmt + lsStmt2;
					}
					lsStmt = lsStmt + " END;";
					// Bug 83777, Added IP hint
					// Statement parser was suppressed for this database call during porting
                    using (SignatureHints hints = SignatureHints.NewContext())
                    {
                        hints.Add("Voucher_API.Check_If_Postings_In_Voucher", System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                        hints.Add("Period_Allocation_API.Check_Year_Period_Exist", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                        hints.Add("Cost_Allocation_Procedure_API.Check_Non_Closed_Proc_Exist", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                        hints.Add("Currency_Revaluation_API.Check_Non_Posted_Reval_Exist", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                        hints.Add("Revenue_Recognition_API.All_Posted_For_Period", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                        hints.Add("Company_Cons_Trans_API.All_Bal_Trans_Cons_For_Period", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                        hints.Add("Invoice_API.Post_Error_Invs_Exist", System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                        hints.Add("PREL_PAYMENT_TRANS_UTIL_API.CHECK_NON_APPROVED_PAYM_EXISTS", System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                        hints.Add("Mixed_Payment_API.All_Approved_For_Period", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                        hints.Add("Cash_Box_API.All_Approved_For_Period", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                        hints.Add("Fa_Object_Transaction_API.All_Imp_Trans_Post_For_Period", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                        hints.Add("Change_Object_Value_Temp_API.All_Change_Acq_Post_For_Period", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                        hints.Add("Change_Object_Value_Temp_API.All_Change_Net_Post_For_Period", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                        hints.Add("Depr_Proposal_API.All_Proposal_Post_For_Period", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                        hints.Add("Ext_Load_Info_API.Check_Non_Created_ExtVou_Exist", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                        hints.Add("Ext_Inc_Inv_Load_Info_API.Check_Non_Created_Inv_Exist", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                        hints.Add("Ext_Out_Inv_Load_Info_API.Check_Non_Created_Inv_Exist", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                        hints.Add("Ext_Payment_Head_API.Check_Non_Used_Pay_Exist", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                        hints.Add("Mpccom_Accounting_API.All_Postings_Transferred", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                        hints.Add("Pcm_Accounting_API.All_Postings_Transferred", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
					if (DbPLSQLBlock(cSessionManager.c_hSql, lsStmt)) 
					{
						if (sNonUpdatedVouExist == "TRUE") 
						{
							sVoucherTransExist = "TRUE";
						}
						if (sNonUpdPeriodAllocExist == "TRUE") 
						{
							sPeriodAllocTransExist = "TRUE";
						}
						if (sNonClosedPcaExist == "TRUE") 
						{
							sPcaTransExist = "TRUE";
						}
						if (sNonPostedCurrRevExist == "TRUE") 
						{
							sCurrRevTransExist = "TRUE";
						}
						if (sNonPostedRevenueExist == "FALSE") 
						{
							sRevenueTransExist = "TRUE";
						}
						if (sSubsCompanies != Ifs.Fnd.ApplicationForms.Const.strNULL) 
						{
							sConsBalanceTransExist = "TRUE";
							sParam[0] = sSubsCompanies;
						}
						// Bug Id 91840,Begin
						if (sMpccomPostingsTransferred == "FALSE") 
						{
							sMpccomPostingTransExist = "TRUE";
						}
						// Bug Id 91840,End
						if (sPcmPostingsTransferred == "FALSE") 
						{
							sPcmPostingTransExist = "TRUE";
						}
						if (frmAccPer.FromHandle(p_hParent).tblAccPerDetail_colsPeriodType.Text != sYearOpening) 
						{
							if (sPostErrInvs == "TRUE") 
							{
								sPostErrInvTransExist = "TRUE";
							}
                            // Bug 109339, Begin
                            if (sPrelimInvs == "TRUE")
                            {
                                sPrelimInvsExist = "TRUE";
                            }
                            // Bug 109339, End
							if (sNonApprovedPayExist == "TRUE") 
							{
								sPrelPayTransExist = "TRUE";
							}
							if (sMixPayApproved == "FALSE") 
							{
								sMixPayTransExist = "TRUE";
							}
							if (sCashBoxApproved == "FALSE") 
							{
								sCashBoxTransExist = "TRUE";
							}
							if (sNonPostedFaImpTransExist == "FALSE") 
							{
								sFaImpTransExist = "TRUE";
							}
							if (sNonPostedFaChangeAcqTransExist == "FALSE") 
							{
								sFaChangeAcqTransExist = "TRUE";
							}
							if (sNonPostedFaChangeNetTransExist == "FALSE") 
							{
								sFaChangeNetTransExist = "TRUE";
							}
							if (sNonPostedFaDeprProposalExist == "FALSE") 
							{
								sFaDeprProposalTransExist = "TRUE";
							}
							if (sNonCreatedExtVouExist == "TRUE") 
							{
								sExtVouTransExist = "TRUE";
							}
							if (sNonCreatedExtIncInvExist == "TRUE") 
							{
								sExtIncInvTransExist = "TRUE";
							}
							if (sNonCreatedExtOutInvExist == "TRUE") 
							{
								sExtOutInvTransExist = "TRUE";
							}
							if (sNonUsedExtPayExist == "TRUE") 
							{
								sExtPayTransExist = "TRUE";
							}
							// Bug Id 91840, Removed the code of sMpccomPostingsTransferred variable. Move it to the error section
						}

					}
					else
					{
						return false;
					}
                    }
				}
				Sal.TblSetContext(frmAccPer.FromHandle(p_hParent).tblAccPerDetail, nOldRow);
				// Bug Id 91840,Begin. Added sMpccomPostingsTransferred variable as well.
				if (sVoucherTransExist == "TRUE" || sPeriodAllocTransExist == "TRUE" || sCurrRevTransExist == "TRUE" || sRevenueTransExist == "TRUE" || sPcaTransExist == "TRUE" || sConsBalanceTransExist == "TRUE" || sMpccomPostingTransExist == "TRUE" || 
				sPcmPostingTransExist == "TRUE") 
				{
					bTransErrorExist = true;
				}
				// Bug Id 91840,End
				else
				{
					bTransErrorExist = false;
				}
				return true;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber PopulateForm()
		{
			#region Actions
			using (new SalContext(this))
			{
				// ERRORS
				// Accrul
				if (nVouPostMethodAvailable == 1) 
				{
					InsertRow(Properties.Resources.TEXT_ValidTrans_Error, Properties.Resources.TEXT_NonUpdatedVoucher, sVoucherTransExist);
				}
				if (nPcaMethodAvailable == 1) 
				{
					InsertRow(Properties.Resources.TEXT_ValidTrans_Error, Properties.Resources.TEXT_NonUpdatedPeriodAlloc, sPeriodAllocTransExist);
				}
				// Genled
				if (nCurrRevMethodAvailable == 1) 
				{
					InsertRow(Properties.Resources.TEXT_ValidTrans_Error, Properties.Resources.TEXT_NonPostedCurrRevExist, sCurrRevTransExist);
				}
				if (nRevenueMethodAvailable == 1) 
				{
					InsertRow(Properties.Resources.TEXT_ValidTrans_Error, Properties.Resources.TEXT_NonPostedRevenue, sRevenueTransExist);
				}
				// Percos
				if (nPcaMethodAvailable == 1) 
				{
					InsertRow(Properties.Resources.TEXT_ValidTrans_Error, Properties.Resources.TEXT_NonClosedPcaExist, sPcaTransExist);
				}
				// Connac
				if (nConsolidationMethodAvailable == 1) 
				{
					InsertRow(Properties.Resources.TEXT_ValidTrans_Error, Properties.Resources.TEXT_NonConsolidatedBalance, sConsBalanceTransExist);
					// sSubsCompanies
				}
				// Bug Id 91840, Begin .Moved the erro text from warnings sections.
				// Distribution
				if (nMpccomPostingMethodAvailable == 1) 
				{
					InsertRow(Properties.Resources.TEXT_ValidTrans_Error, Properties.Resources.TEXT_NonTransferredTransDistrib, sMpccomPostingTransExist);
				}
				// Bug Id 91840, End
				// PCM
				if (nPcmPostingMethodAvailable == 1) 
				{
					InsertRow(Properties.Resources.TEXT_ValidTrans_Error, Properties.Resources.TEXT_NonTransferredTransMaint, sPcmPostingTransExist);
				}

				// WARNINGS
				// Invoic
				if (nInvMethodAvailable == 1) 
				{
					InsertRow(Properties.Resources.TEXT_ValidTrans_Warning, Properties.Resources.TEXT_PostErrInvs, sPostErrInvTransExist);
				}
                // Bug 109339, Begin
                if (nPrelimInvMethodAvailable == 1)
                {
                    InsertRow(Properties.Resources.TEXT_ValidTrans_Warning, Properties.Resources.TEXT_PrelimInvs, sPrelimInvsExist);
                }
                // Bug 109339, End
				// Payled
				if (nPrelPayMethodAvailable == 1) 
				{
					InsertRow(Properties.Resources.TEXT_ValidTrans_Warning, Properties.Resources.TEXT_NonApprovedPayments, sPrelPayTransExist);
				}
				if (nMixPayMethodAvailable == 1) 
				{
					InsertRow(Properties.Resources.TEXT_ValidTrans_Warning, Properties.Resources.TEXT_NonApprovedMixPay, sMixPayTransExist);
				}
				if (nCashBoxMethodAvailable == 1) 
				{
					InsertRow(Properties.Resources.TEXT_ValidTrans_Warning, Properties.Resources.TEXT_NonApprovedCashBox, sCashBoxTransExist);
				}
				// Fixass
				if (nFaImpTransMethodAvailable == 1) 
				{
					InsertRow(Properties.Resources.TEXT_ValidTrans_Warning, Properties.Resources.TEXT_NonPostedFaImpTrans, sFaImpTransExist);
				}
				if (nFaChangeAcqTransMethodAvailable == 1) 
				{
					InsertRow(Properties.Resources.TEXT_ValidTrans_Warning, Properties.Resources.TEXT_NonPostedFaChangeAcqTrans, sFaChangeAcqTransExist);
				}
				if (nFaChangeNetTransMethodAvailable == 1) 
				{
					InsertRow(Properties.Resources.TEXT_ValidTrans_Warning, Properties.Resources.TEXT_NonPostedFaChangeNetTrans, sFaChangeNetTransExist);
				}
				if (nFaDeprProposalMethodAvailable == 1) 
				{
					InsertRow(Properties.Resources.TEXT_ValidTrans_Warning, Properties.Resources.TEXT_NonPostedFaDeprProposal, sFaDeprProposalTransExist);
				}
				// External
				if (nExtVouMethodAvailable == 1) 
				{
					InsertRow(Properties.Resources.TEXT_ValidTrans_Warning, Properties.Resources.TEXT_NonCreatedExtVouExist, sExtVouTransExist);
				}
				if (nExtIncInvMethodAvailable == 1) 
				{
					InsertRow(Properties.Resources.TEXT_ValidTrans_Warning, Properties.Resources.TEXT_NonCreatedExtIncInvExist, sExtIncInvTransExist);
				}
				if (nExtOutInvMethodAvailable == 1) 
				{
					InsertRow(Properties.Resources.TEXT_ValidTrans_Warning, Properties.Resources.TEXT_NonCreatedExtOutInvExist, sExtOutInvTransExist);
				}
				if (nExtPayMethodAvailable == 1) 
				{
					InsertRow(Properties.Resources.TEXT_ValidTrans_Warning, Properties.Resources.TEXT_NonUsedExtPayExist, sExtPayTransExist);
				}

				// Bug Id 91840, Remove error text from warnings and moved to error section.

			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="sMsgType"></param>
		/// <param name="sMsgText"></param>
		/// <param name="sTransExist"></param>
		/// <returns></returns>
		public virtual SalNumber InsertRow(SalString sMsgType, SalString sMsgText, SalString sTransExist)
		{
			#region Local Variables
			SalNumber nNewRow = 0;
			#endregion
			
			#region Actions
            using (new SalContext(this))
			{
				nNewRow = Sal.TblInsertRow(tblTransInProgress, Sys.TBL_MaxRow);
				Sal.TblSetRowFlags(tblTransInProgress, nNewRow, Sys.ROW_New, false);
				Sal.TblSetContext(tblTransInProgress, nNewRow);

				tblTransInProgress_colsMessageType.Text = sMsgType;
				tblTransInProgress_colsMessageText.Text = sMsgText;
				tblTransInProgress_colsTransExist.Text = sTransExist;
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
		private void dlgTransactionsInProgress_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Create:
					this.dlgTransactionsInProgress_OnSAM_Create(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_Create event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dlgTransactionsInProgress_OnSAM_Create(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.i_sCompany = this.p_sCompany;
			Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam);
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
		public override SalNumber vrtUserMethod(SalNumber nWhat, SalString sMethod)
		{
			return this.UserMethod(nWhat, sMethod);
		}
		#endregion
		
	}
}
