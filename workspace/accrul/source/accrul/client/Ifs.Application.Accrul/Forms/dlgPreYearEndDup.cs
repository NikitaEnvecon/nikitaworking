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
// 12-11-23    JANBLK    DANU-122, Parallel currency implementation.
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

namespace Ifs.Application.Accrul
{
	
	/// <summary>
	/// </summary>
	/// <param name="sYear"></param>
	/// <param name="AutoUpdate"></param>
	/// <param name="sCompany"></param>
	public partial class dlgPreYearEndDup : cDialogBoxFin
	{
		#region Window Parameters
		public SalString sYear;
		public SalBoolean AutoUpdate;
		public SalString sCompany;
		#endregion
		
		#region Window Variables
		public SalArray<SalString> sPreYearParams = new SalArray<SalString>();
		public SalWindowHandle hWndLOV = SalWindowHandle.Null;
		public SalWindowHandle hWndLovField = SalWindowHandle.Null;
		public SalString lsFromAccYear = "";
		public SalString lsToAccYear = "";
		public SalNumber nResultKey = 0;
		public SalString lsReportAttr = "";
		public SalString lsParameterAttr = "";
		public SalString lsDistributionList = "";
		public SalString lsFromPeriod = "";
		public SalString lsUntilPeriod = "";
		public SalString lsTemp = "";

        public SalString sNullValue = Sys.STRING_Null;

		
		/// <summary>
		/// State of the Preview and Print Buttons
		/// </summary>
		public SalBoolean PreviewAndPrintEnabled = false;
		
		/// <summary>
		/// LOV possible for field with focus
		/// </summary>
		public SalBoolean ListOfValuesEnabled = false;
		
		/// <summary>
		/// Last object with focus
		/// </summary>
		public SalWindowHandle hLastWithFocus = SalWindowHandle.Null;
		public SalDateTime dToDate = SalDateTime.Null;
		public SalString sThirdCurrencyCode = "";
		public SalString sBaseCurrencyCode = "";
        public SalString sParallelBase = "";
		public SalString sBaseEmu = "";
		public SalString sThirdEmu = "";
		public SalNumber nThirdRate = 0;
		public SalNumber nConvFactor = 0;
		public SalString sInverted = "";
		public SalString sClBalances = "";
		public SalArray<SalString> sYearArr = new SalArray<SalString>();
		public SalArray<SalNumber> nFromYear = new SalArray<SalNumber>();
		public SalNumber nTokens = 0;
		public SalNumber nCount = 0;
		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		protected dlgPreYearEndDup()
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
		public static SalNumber ModalDialog(Control owner, SalString sYear, SalBoolean AutoUpdate, SalString sCompany)
		{
			dlgPreYearEndDup dlg = DialogFactory.CreateInstance<dlgPreYearEndDup>();
			dlg.sYear = sYear;
			dlg.AutoUpdate = AutoUpdate;
			dlg.sCompany = sCompany;
			SalNumber ret = dlg.ShowDialog(owner);
			return ret;
		}
		
		/// <summary>
		/// Returns the object instance associated with the window handle.
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public new static dlgPreYearEndDup FromHandle(SalWindowHandle handle)
		{
			return ((dlgPreYearEndDup)SalWindow.FromHandle(handle, typeof(dlgPreYearEndDup)));
		}
		#endregion
		
		#region Methods
		// ------------- late bound functions --------------------
		/// <summary>
		/// </summary>
		/// <param name="nWhat"></param>
		/// <param name="sMethod"></param>
		/// <returns></returns>
		public new SalNumber UserMethod(SalNumber nWhat, SalString sMethod)
		{
			#region Actions
			using (new SalContext(this))
			{
				if (sMethod == "Ok") 
				{
					return OK_Clicked(nWhat);
				}
				else if (sMethod == "Cancel") 
				{
					return Cancel_Clicked(nWhat);
				}
				else if (sMethod == "Preview") 
				{
					return PreviewOrPrint_Clicked(nWhat, "Preview");
				}
				else if (sMethod == "Print") 
				{
					return PreviewOrPrint_Clicked(nWhat, "Print");
				}
				else if (sMethod == "List") 
				{
					return List_Clicked(nWhat);
				}
			}

			return false;
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
				dfToAccYear.EditDataItemStateSet(Ifs.Fnd.ApplicationForms.Const.EDIT_Changed);
				dfFromAccYear.EditDataItemStateSet(Ifs.Fnd.ApplicationForms.Const.EDIT_Changed);
				cbCalculateAll.EditDataItemStateSet(Ifs.Fnd.ApplicationForms.Const.EDIT_Changed);
				dfRate.EditDataItemStateSet(Ifs.Fnd.ApplicationForms.Const.EDIT_Changed);
				dfConvFactor.EditDataItemStateSet(Ifs.Fnd.ApplicationForms.Const.EDIT_Changed);
				Sal.SendMsg(dfFromAccYear, Ifs.Fnd.ApplicationForms.Const.PM_DataItemPopulate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
				Sal.SetFocus(dfFromAccYear);
				PreviewAndPrintEnabled = false;
				RefreshButtonsState();
				Sal.DisableWindowAndLabel(dfRate);
				Sal.DisableWindowAndLabel(dfConvFactor);
				if (AutoUpdate == true) 
				{
					nTokens = sYear.Tokenize(" ", ",", sYearArr);
					nCount = nTokens - 1;
					while (nTokens > 1) 
					{
						nTokens = nTokens - 1;
						nFromYear[nTokens] = sYearArr[nTokens].ToNumber();
					}
					dfFromAccYear.Number = nFromYear[1];
					dfToAccYear.Number = nFromYear[1] + 1;
					if (GetData() == false) 
					{
						return false;
					}
				}				
                if (!(DbPLSQLBlock(cSessionManager.c_hSql,
                    @"DECLARE
                        company_rec_ &AO.Company_Finance_Api.Public_Rec;
                      BEGIN 
                        company_rec_ := &AO.Company_Finance_Api.Get(:i_hWndFrame.dlgPreYearEndDup.i_sCompany);
                        :i_hWndFrame.dlgPreYearEndDup.sBaseCurrencyCode := company_rec_.currency_code;
                        :i_hWndFrame.dlgPreYearEndDup.sParallelBase := company_rec_.parallel_base;                        
                      END;")))
                {
                    return false;
                }
                Sal.EnableWindowAndLabel(cbCalculateAll);
                if (sParallelBase != "ACCOUNTING_CURRENCY")
                    Sal.DisableWindowAndLabel(cbCalculateAll);

				return true;
			}
			#endregion
		}
		// ------------- message answer functions ----------------
		/// <summary>
		/// </summary>
		/// <param name="p_nWhat"></param>
		/// <returns></returns>
		public virtual SalBoolean OK_Clicked(SalNumber p_nWhat)
		{
			// Bug 82855, Removed obsoleted lsStmt
			
			#region Actions
			using (new SalContext(this))
			{
				if (p_nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire) 
				{
					if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Accounting_Period_Api.Get_Date_From"))) 
					{
						return false;
					}
					if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Company_Finance_Api.Get_Parallel_Acc_Currency"))) 
					{
						return false;
					}
					if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Accounting_Period_API.Check_Accounting_Year"))) 
					{
						return false;
					}
					if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Accounting_Balance_API.Cal_Bal_Insert_Or_Modify"))) 
					{
						return false;
					}
					if (dfFromAccYear.Number == Sys.NUMBER_Null) 
					{
						return false;
					}
					if (dfToAccYear.Number == Sys.NUMBER_Null) 
					{
						return false;
					}
					return true;
				}
				else if (p_nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
				{
					if (!(CheckNextYear())) 
					{
						RefreshButtonsState();
						return false;
					}
					if (!(PossibleToTransfer())) 
					{
						Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_Dup_BalTransferred, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
						RefreshButtonsState();
						return false;
					}
					if (dfCalculateAll.Text == "Y") 
					{
						if (Sal.IsNull(dfRate)) 
						{
							Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_Dup_Rate, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
							return false;
						}
						else if (Sal.IsNull(dfConvFactor)) 
						{
							Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_Dup_Factor, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
							return false;
						}
						if (!(dfToAccYear.Number == Sys.NUMBER_Null)) 
						{
							// Bug 82855 Begin, Re-arranged server call code to suite Rising requirement; Removed variable assignment lsCheck
							using(SignatureHints hints = SignatureHints.NewContext())
							{
								hints.Add("Accounting_Period_Api.Get_Date_From", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
								hints.Add("Company_Finance_Api.Get_Parallel_Acc_Currency", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
								if (!(DbPLSQLBlock(cSessionManager.c_hSql, "DECLARE\r\n" +
									"				DATE_TO  DATE;\r\n" +
									"			BEGIN \r\n" +
									"				DATE_TO := &AO.Accounting_Period_Api.Get_Date_From(:i_hWndFrame.dlgPreYearEndDup.i_sCompany, :i_hWndFrame.dlgPreYearEndDup.dfToAccYear,1); \r\n" +
									"				:i_hWndFrame.dlgPreYearEndDup.dToDate := DATE_TO; \r\n" +
									"				IF ( DATE_TO IS NOT NULL ) THEN \r\n" +
									"					:i_hWndFrame.dlgPreYearEndDup.sThirdCurrencyCode := \r\n" +
									"						&AO.Company_Finance_Api.Get_Parallel_Acc_Currency(\r\n" +
									"							:i_hWndFrame.dlgPreYearEndDup.i_sCompany, \r\n" +
									"							:i_hWndFrame.dlgPreYearEndDup.dToDate); \r\n" +
									"				END IF;\r\n			END;"))) 
								{
									return false;
								}
							}
							// Bug 82855 End
							if (sThirdCurrencyCode == Ifs.Fnd.ApplicationForms.Const.strNULL) 
							{
								Sal.ClearField(cbCalculateAll);
								Sal.ClearField(dfRate);
								Sal.ClearField(dfConvFactor);
								dfCalculateAll.Text = "N";
								dfRate.Number = Sys.NUMBER_Null;
								dfConvFactor.Number = Sys.NUMBER_Null;
							}
						}
					}
					Sal.WaitCursor(true);
					// Bug 82855 Begin, Re-arranged server call code to suite Rising requirement; Removed variable assignment lsCheck
					using(SignatureHints hints = SignatureHints.NewContext())
					{
						hints.Add("Accounting_Period_API.Check_Accounting_Year", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
						hints.Add("Accounting_Balance_API.Cal_Bal_Insert_Or_Modify", System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
						if (DbPLSQLTransaction(cSessionManager.c_hSql, "&AO.Accounting_Period_API.Check_Accounting_Year(\r\n" +
							"		:i_hWndFrame.dlgPreYearEndDup.i_sCompany,\r\n" +
							"		:i_hWndFrame.dlgPreYearEndDup.dfFromAccYear);\r\n" +
							"	&AO.Accounting_Period_API.Check_Accounting_Year(\r\n" +
							"		:i_hWndFrame.dlgPreYearEndDup.i_sCompany,\r\n" +
							"		:i_hWndFrame.dlgPreYearEndDup.dfToAccYear);\r\n" +
							"	&AO.Accounting_Balance_API.Cal_Bal_Insert_Or_Modify( \r\n" +
							"		:i_hWndFrame.dlgPreYearEndDup.lsTemp, \r\n" +
							"		:i_hWndFrame.dlgPreYearEndDup.i_sCompany,\r\n" +
							"		:i_hWndFrame.dlgPreYearEndDup.dfFromAccYear, \r\n" +
							"		:i_hWndFrame.dlgPreYearEndDup.dfToAccYear, \r\n" +
							"		:i_hWndFrame.dlgPreYearEndDup.dfCalculateAll,\r\n" +
							"		:i_hWndFrame.dlgPreYearEndDup.dfRate,  \r\n" +
							"		:i_hWndFrame.dlgPreYearEndDup.dfConvFactor);")) 
						{
							Sal.WaitCursor(false);
							nTokens = nTokens + 1;
							if ((nCount >= nTokens) && (nCount > 1)) 
							{
								dfFromAccYear.Number = nFromYear[nTokens];
								dfToAccYear.Number = nFromYear[nTokens] + 1;
							}
							lsFromAccYear = dfFromAccYear.Number.ToString(0);
							lsToAccYear = dfToAccYear.Number.ToString(0);
							if (!(HandleSqlResult(lsTemp))) 
							{
								return false;
							}
							PreviewAndPrintEnabled = true;
							if (!(UpdateYearData())) 
							{
								RefreshButtonsState();
								return false;
							}
							RefreshButtonsState();
							return true;
						}
						// Bug 82855 End
						else
						{
							Sal.WaitCursor(false);
							RefreshButtonsState();
							return false;
						}
					}
				}
			}

			return false;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="p_nWhat"></param>
		/// <returns></returns>
		public virtual SalBoolean Cancel_Clicked(SalNumber p_nWhat)
		{
			#region Actions
			using (new SalContext(this))
			{
				if (p_nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire) 
				{
					return true;
				}
				else if (p_nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
				{
					return Sal.EndDialog(this, 0);
				}
			}

			return false;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="p_nWhat"></param>
		/// <param name="p_sType"></param>
		/// <returns></returns>
		public virtual SalBoolean PreviewOrPrint_Clicked(SalNumber p_nWhat, SalString p_sType)
		{
			#region Local Variables
			// Bug 81049, Begin
			SalString lsPrintAttr = "";
			// Bug 81049, End
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				if (p_nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire) 
				{
					if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsViewAvailable("ACCOUNTING_BALANCE_REP"))) 
					{
						return false;
					}
					return PreviewAndPrintEnabled;
				}
				else if (p_nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
				{
					lsFromPeriod = dfFromAccYear.Number.ToString(0);
					lsUntilPeriod = dfToAccYear.Number.ToString(0);
					Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("REPORT_ID", "ACCOUNTING_BALANCE_REP", ref lsReportAttr);
					Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("COMPANY", this.i_sCompany, ref lsParameterAttr);
					Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("ACCOUNTING_YEAR", lsFromPeriod, ref lsParameterAttr);
					Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("ACCOUNTING_YEAR_TO", lsUntilPeriod, ref lsParameterAttr);
					Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("TRANS_TYPE", "PRELIMINARY", ref lsParameterAttr);
					if (p_sType == "Preview") 
					{
						// Bug 81049, Begin
						Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("OUTPUT", "PREVIEW", ref lsPrintAttr);
						// Bug 81049, End
					}
					else if (p_sType == "Print") 
					{
						// Bug 81049, Begin
						Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("OUTPUT", "PRINT", ref lsPrintAttr);
						// Bug 81049, End
					}
					// Bug 81049, Begin
					Ifs.Fnd.ApplicationForms.Var.InfoService.ReportExecuteAndPrint(ref nResultKey, lsReportAttr, lsParameterAttr, lsDistributionList, lsPrintAttr);
					// Bug 81049, End
					Sal.EndDialog(this, 0);
				}
			}

			return false;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="p_nWhat"></param>
		/// <returns></returns>
		public virtual SalBoolean List_Clicked(SalNumber p_nWhat)
		{
			#region Actions
			using (new SalContext(this))
			{
				if (p_nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire) 
				{
					return ListOfValuesEnabled;
				}
				else if (p_nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
				{
					Sal.SendMsg(hLastWithFocus, Ifs.Fnd.ApplicationForms.Const.PM_DataItemLov, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
					return Sal.SendMsg(hLastWithFocus, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
				}
			}

			return false;
			#endregion
		}
		// ------------- internal functions ----------------------
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean CheckNextYear()
		{
			#region Actions
			using (new SalContext(this))
			{
				if (dfToAccYear.Number != dfFromAccYear.Number + 1) 
				{
					Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_Dup_NotNextYear, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
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
		public virtual SalNumber RefreshButtonsState()
		{
			#region Actions
			using (new SalContext(this))
			{
				pbOK.MethodInvestigateState();
				pbCancel.MethodInvestigateState();
				pbPreview.MethodInvestigateState();
				pbPrint.MethodInvestigateState();
				pbList.MethodInvestigateState();
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean PossibleToTransfer()
		{
			#region Actions
			using (new SalContext(this))
			{
				using(SignatureHints hints = SignatureHints.NewContext())
				{
					hints.Add("Accounting_Year_Api.Get_Closing_Balances_db", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
					if (!(DbPLSQLBlock(cSessionManager.c_hSql, " BEGIN\r\n" +
						"	       :i_hWndFrame.dlgPreYearEndDup.sClBalances  :=  \r\n" +
						"	       &AO.Accounting_Year_Api.Get_Closing_Balances_db(\r\n" +
						"      	      :i_hWndFrame.dlgPreYearEndDup.i_sCompany, \r\n" +
						"	      :i_hWndFrame.dlgPreYearEndDup.dfFromAccYear);\r\n	 END; "))) 
					{
						return false;
					}
				}
				if (dlgPreYearEndDup.FromHandle(i_hWndFrame).sClBalances == "F") 
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
		public virtual SalBoolean UpdateYearData()
		{
			#region Actions
			using (new SalContext(this))
			{
				using(SignatureHints hints = SignatureHints.NewContext())
				{
					hints.Add("Accounting_year_API.Preliminary_Year_End", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
					if (!(DbPLSQLTransaction(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "Accounting_year_API.Preliminary_Year_End(\r\n" +
						"                                                     :i_hWndFrame.dlgPreYearEndDup.i_sCompany,:i_hWndFrame.dlgPreYearEndDup.dfFromAccYear,\r\n" +
						"                                                     :i_hWndFrame.dlgPreYearEndDup.dfToAccYear)"))) 
					{
						return false;
					}
				}
			}

			return false;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean GetData()
		{
			#region Actions
			using (new SalContext(this))
			{
				if (!(dfToAccYear.Number == Sys.NUMBER_Null)) 
				{
					using(SignatureHints hints = SignatureHints.NewContext())
					{
						hints.Add("Accounting_Period_Api.Get_Date_From", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
						if (!(DbPLSQLBlock(cSessionManager.c_hSql, " BEGIN\r\n" +
							"	      :i_hWndFrame.dlgPreYearEndDup.dToDate :=  \r\n" +
							"	       &AO.Accounting_Period_Api.Get_Date_From(\r\n" +
							"	      :i_hWndFrame.dlgPreYearEndDup.i_sCompany, \r\n" +
							"	      :i_hWndFrame.dlgPreYearEndDup.dfToAccYear,1);\r\n	 END; "))) 
						{
							return false;
						}
					}
					if (!(dToDate == SalDateTime.Null)) 
					{
						using(SignatureHints hints = SignatureHints.NewContext())
						{
							hints.Add("Company_Finance_Api.Get_Parallel_Acc_Currency", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
							if (!(DbPLSQLBlock(cSessionManager.c_hSql, " BEGIN\r\n" +
								"	      	 :i_hWndFrame.dlgPreYearEndDup.sThirdCurrencyCode :=  \r\n" +
								"	      	 &AO.Company_Finance_Api.Get_Parallel_Acc_Currency(\r\n" +
								"		:i_hWndFrame.dlgPreYearEndDup.i_sCompany,\r\n" +
								"		:i_hWndFrame.dlgPreYearEndDup.dToDate);\r\n	 END; "))) 
							{
								return false;
							}
						}
						using(SignatureHints hints = SignatureHints.NewContext())
						{
							hints.Add("Currency_Code_Api.Get_Valid_Emu", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
							if (!(DbPLSQLBlock(cSessionManager.c_hSql, " BEGIN\r\n" +
								"	  	:i_hWndFrame.dlgPreYearEndDup.sBaseEmu   :=  \r\n" +
								"	     	 &AO.Currency_Code_Api.Get_Valid_Emu(\r\n" +
								"		:i_hWndFrame.dlgPreYearEndDup.i_sCompany, \r\n" +
								"		:i_hWndFrame.dlgPreYearEndDup.sBaseCurrencyCode, \r\n" +
								"		:i_hWndFrame.dlgPreYearEndDup.dToDate) ;\r\n	 END; "))) 
							{
								return false;
							}
						}
						using(SignatureHints hints = SignatureHints.NewContext())
						{
							hints.Add("Currency_Code_Api.Get_Valid_Emu", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
							if (!(DbPLSQLBlock(cSessionManager.c_hSql, " BEGIN\r\n" +
								"	  :i_hWndFrame.dlgPreYearEndDup.sThirdEmu  :=  \r\n" +
								"	      	 &AO.Currency_Code_Api.Get_Valid_Emu(\r\n" +
								"		:i_hWndFrame.dlgPreYearEndDup.i_sCompany,\r\n" +
								"		:i_hWndFrame.dlgPreYearEndDup.sThirdCurrencyCode, \r\n" +
								"		:i_hWndFrame.dlgPreYearEndDup.dToDate) ;\r\n	 END; "))) 
							{
								return false;
							}
						}
					}
				}
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
		private void dlgPreYearEndDup_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceQueryFieldName:
					this.dlgPreYearEndDup_OnPM_DataSourceQueryFieldName(sender, e);
					break;
				
				case Sys.SAM_Create:
					this.dlgPreYearEndDup_OnSAM_Create(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// PM_DataSourceQueryFieldName event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dlgPreYearEndDup_OnPM_DataSourceQueryFieldName(object sender, WindowActionsEventArgs e)
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
						e.Return = (this.i_hWndFrame.ToNumber().ToString(0) + ".dlgPreYearEndDup.i_sCompany").ToHandle();
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
		/// SAM_Create event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dlgPreYearEndDup_OnSAM_Create(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.i_sCompany = this.sCompany;
			Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam);
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void dfFromAccYear_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_AnyEdit:
					e.Handled = true;
					this.RefreshButtonsState();
					break;
				
				case Sys.SAM_SetFocus:
					this.dfFromAccYear_OnSAM_SetFocus(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovQueryValue:
					e.Handled = true;
					e.Return = Ifs.Fnd.ApplicationForms.Const.LOVITEMVALUE_MyValue;
					return;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfFromAccYear_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
			this.hLastWithFocus = this.dfFromAccYear.i_hWndSelf;
			this.ListOfValuesEnabled = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemLov, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0);
			this.RefreshButtonsState();
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void dfToAccYear_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_AnyEdit:
					e.Handled = true;
					this.RefreshButtonsState();
					break;
				
				case Sys.SAM_SetFocus:
					this.dfToAccYear_OnSAM_SetFocus(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovQueryValue:
					e.Handled = true;
					e.Return = Ifs.Fnd.ApplicationForms.Const.LOVITEMVALUE_MyValue;
					return;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
					this.dfToAccYear_OnPM_DataItemValidate(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfToAccYear_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
			this.hLastWithFocus = this.dfToAccYear.i_hWndSelf;
			this.ListOfValuesEnabled = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemLov, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0);
			this.RefreshButtonsState();
			#endregion
		}
		
		/// <summary>
		/// PM_DataItemValidate event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfToAccYear_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (this.GetData() == false) 
			{
				e.Return = false;
				return;
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
		private void cbCalculateAll_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Create:
					this.cbCalculateAll_OnSAM_Create(sender, e);
					break;
				
				case Sys.SAM_Click:
					this.cbCalculateAll_OnSAM_Click(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_Create event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cbCalculateAll_OnSAM_Create(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam)) 
			{
				this.cbCalculateAll.i_sCheckedValue = "Y";
				this.cbCalculateAll.i_sUncheckedValue = "N";
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
		private void cbCalculateAll_OnSAM_Click(object sender, WindowActionsEventArgs e)
        {

            #region Local Variables
            SalBoolean bOk = false;
            #endregion


            #region Actions
            e.Handled = true;
			if (Sal.SendClassMessage(Sys.SAM_Click, Sys.wParam, Sys.lParam)) 
			{
				if (this.sThirdCurrencyCode == Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
					Sal.ClearField(this.cbCalculateAll);
					Sal.ClearField(this.dfRate);
					Sal.ClearField(this.dfConvFactor);
					Sal.DisableWindowAndLabel(this.dfRate);
					Sal.DisableWindowAndLabel(this.dfConvFactor);
				}
				else
				{
					if (Sal.IsButtonChecked(this.cbCalculateAll)) 
					{
						using(SignatureHints hints = SignatureHints.NewContext())
						{

                            bOk = DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN\r\n " + cSessionManager.c_sDbPrefix +
                                  "Currency_Rate_API.Get_Parallel_Currency_Rate( " + ":i_hWndFrame.dlgPreYearEndDup.nThirdRate INOUT, " 
                                                                                 + ":i_hWndFrame.dlgPreYearEndDup.nConvFactor INOUT, "
                                                                                 + ":i_hWndFrame.dlgPreYearEndDup.sInverted INOUT, " 
                                                                                 + ":i_hWndFrame.dlgPreYearEndDup.i_sCompany IN, "
                                                                                 + ":i_hWndFrame.dlgPreYearEndDup.sBaseCurrencyCode IN, "// pasing acc curr for trans curr
                                                                                 + ":i_hWndFrame.dlgPreYearEndDup.dToDate IN, "
                                                                                 + ":i_hWndFrame.dlgPreYearEndDup.sNullValue IN,\r\n"
                                                                                 + ":i_hWndFrame.dlgPreYearEndDup.sNullValue IN,\r\n"
                                                                                 + ":i_hWndFrame.dlgPreYearEndDup.sBaseCurrencyCode IN, "
                                                                                 + ":i_hWndFrame.dlgPreYearEndDup.sThirdCurrencyCode IN, " 
                                                                                 + ":i_hWndFrame.dlgPreYearEndDup.sBaseEmu IN ," 
                                                                                 + ":i_hWndFrame.dlgPreYearEndDup.sThirdEmu IN ); END;"); 
                            if(!bOk)
                            {
                                e.Return = false;
                                return;
                            }

						}
						this.dfRate.Number = this.nThirdRate;
						this.dfConvFactor.Number = this.nConvFactor;
						this.dfCalculateAll.Text = "Y";
						if (!((this.sBaseEmu == "TRUE" && this.sThirdCurrencyCode == "EUR") || (this.sBaseCurrencyCode == "EUR" && this.sThirdEmu == "TRUE"))) 
						{
							Sal.EnableWindowAndLabel(this.dfRate);
							Sal.EnableWindowAndLabel(this.dfConvFactor);
						}
					}
					else
					{
						Sal.ClearField(this.dfRate);
						Sal.DisableWindowAndLabel(this.dfRate);
						Sal.ClearField(this.dfConvFactor);
						Sal.DisableWindowAndLabel(this.dfConvFactor);
						this.dfCalculateAll.Text = "N";
					}
					e.Return = true;
					return;
				}
			}
			e.Return = false;
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
		public override SalNumber vrtUserMethod(SalNumber nWhat, SalString sMethod)
		{
			return this.UserMethod(nWhat, sMethod);
		}
		#endregion
	}
}
