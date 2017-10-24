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

namespace Ifs.Application.Accrul
{
	
	/// <summary>
	/// </summary>
	/// <param name="hWndOwner"></param>
	public partial class dlgManualIntPosting : cDialogBoxFin
	{
		#region Window Parameters
		public SalWindowHandle hWndOwner;
		#endregion
		
		#region Window Variables
		public SalString sManualCodeParts = "";
		public SalNumber nAmount = 0;
		public SalNumber nCurrencyAmount = 0;
		public SalNumber nCurrRate = 0;
		public SalWindowHandle hLastWithFocus = SalWindowHandle.Null;
		public SalString sDecimalSeparator = "";
		public SalString sThousandSeparator = "";
		public SalString sNumberGrouping = "";
		public SalDateTime dVoucherDate = SalDateTime.Null;
		public SalString sCorrection = "";
		public SalString sEditable = "";
		public SalString sCompCurrency = "";
		public SalString sCurrency = "";
		public SalNumber nBase = 0;
		public SalNumber nTrans = 0;
		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		protected dlgManualIntPosting()
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
		public static SalNumber ModalDialog(Control owner, SalWindowHandle hWndOwner)
		{
			dlgManualIntPosting dlg = DialogFactory.CreateInstance<dlgManualIntPosting>();
			dlg.hWndOwner = hWndOwner;
			SalNumber ret = dlg.ShowDialog(owner);
			return ret;
		}
		
		/// <summary>
		/// Returns the object instance associated with the window handle.
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public new static dlgManualIntPosting FromHandle(SalWindowHandle handle)
		{
			return ((dlgManualIntPosting)SalWindow.FromHandle(handle, typeof(dlgManualIntPosting)));
		}
		#endregion
		
		#region Methods
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public new SalBoolean FrameStartupUser()
		{
			#region Local Variables
			SalString sWindowTitle = "";
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.RecCountGet() > 0) 
				{
					InitFromTransferedData();
					Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();
				}
				Sal.GetWindowText(i_hWndSelf, ref sWindowTitle, 50);
				sWindowTitle = sWindowTitle + " ( " + Properties.Resources.TEXT_AccrulLedger + " " + dfsLedgerId.Text + " ) ";
				Sal.SetWindowText(i_hWndSelf, sWindowTitle);
				if (Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("ACCOUNT_API.Get_Description")) 
				{
					using(SignatureHints hints = SignatureHints.NewContext())
					{
						hints.Add("ACCOUNT_API.Get_Description", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
						DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN \r\n" +
							"			          :i_hWndFrame.dlgManualIntPosting.dfAccntDescription := " + cSessionManager.c_sDbPrefix + "ACCOUNT_API.Get_Description(:i_hWndFrame.dlgManualIntPosting.dfsCompany, :i_hWndFrame.dlgManualIntPosting.dfAccount); \r\n" +
							"		               END;");
					}
				}
				DisableEnableCodeParts();
				Sal.SendMsg(tblIntPostings, Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Sys.lParam);
				Ifs.Fnd.ApplicationForms.Var.bReturn = false;
				if (dfCurrBalance.Number == 0) 
				{
					dfBalance.Number = 0;
				}
				if (dfBalance.Number == Sys.NUMBER_Null || dfBalance.Number == 0) 
				{
					dfSumPercentage.Number = 0;
				}
				return true;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public new SalString GetWindowTitle()
		{
			#region Actions
			using (new SalContext(this))
			{
				return Properties.Resources.WH_dlgManualIntPosting;
			}
			#endregion
		}
		
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
				if (sMethod == "OK") 
				{
					return UM_Ok(nWhat);
				}
				else if (sMethod == "Cancel") 
				{
					return UM_Cancel(nWhat);
				}
				else if (sMethod == "New") 
				{
					return UM_New(nWhat);
				}
				else if (sMethod == "Remove") 
				{
					return UM_Remove(nWhat);
				}
				else if (sMethod == "Save") 
				{
					return UM_Save(nWhat);
				}
				else if (sMethod == "List") 
				{
					return UM_List(nWhat);
				}
				return false;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nWhat"></param>
		/// <returns></returns>
		public virtual SalBoolean UM_Ok(SalNumber nWhat)
		{
			#region Actions
			using (new SalContext(this))
			{
				switch (nWhat)
				{
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
						return (dfCurrBalance.Number == 0) && (dfBalance.Number == 0);
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
						if (!((dfCurrBalance.Number == 0) && (dfBalance.Number == 0))) 
						{
							return false;
						}
						else
						{
							if (Sal.SendMsg(tblIntPostings, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0)) 
							{
								switch (DataSourceInquireSave())
								{
									case Sys.IDCANCEL:
										return false;
									
									case Sys.IDYES:
										if (!(CheckRows())) 
										{
											return false;
										}
										if (Sal.SendMsg(tblIntPostings, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0)) 
										{
											return Sal.EndDialog(this, 1);
										}
										return false;
									
									case Sys.IDNO:
										return false;
								}
							}
							else
							{
								return Sal.EndDialog(this, Ifs.Fnd.ApplicationForms.Var.bReturn);
							}
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
		public virtual SalBoolean UM_Cancel(SalNumber nWhat)
		{
			#region Actions
			using (new SalContext(this))
			{
				switch (nWhat)
				{
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
						return true;
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
						if (Sal.SendMsg(tblIntPostings, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0)) 
						{
							switch (DataSourceInquireSave())
							{
								case Sys.IDCANCEL:
									return false;
								
								case Sys.IDYES:
									if (!(CheckRows())) 
									{
										return false;
									}
									if (!((dfCurrBalance.Number == 0) && (dfBalance.Number == 0))) 
									{
										return false;
									}
									if (Sal.SendMsg(tblIntPostings, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0)) 
									{
										return Sal.EndDialog(this, 1);
									}
									return false;
								
								case Sys.IDNO:
									return Sal.EndDialog(this, 0);
							}
						}
						return Sal.EndDialog(this, Ifs.Fnd.ApplicationForms.Var.bReturn);
				}
			}

			return false;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nWhat"></param>
		/// <returns></returns>
		public virtual SalBoolean UM_New(SalNumber nWhat)
		{
			#region Actions
			using (new SalContext(this))
			{
				switch (nWhat)
				{
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
						if (sEditable == "N") 
						{
							return false;
						}
						return true;
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
						return Sal.SendMsg(tblIntPostings, Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
				}
			}

			return false;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nWhat"></param>
		/// <returns></returns>
		public virtual SalBoolean UM_Remove(SalNumber nWhat)
		{
			#region Actions
			using (new SalContext(this))
			{
				switch (nWhat)
				{
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
						if (sEditable == "N") 
						{
							return false;
						}
						return Sal.SendMsg(tblIntPostings, Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0);
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
						return Sal.SendMsg(tblIntPostings, Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
				}
			}

			return false;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nWhat"></param>
		/// <returns></returns>
		public virtual SalBoolean UM_Save(SalNumber nWhat)
		{
			#region Actions
			using (new SalContext(this))
			{
				switch (nWhat)
				{
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
						return ((bool)Sal.SendMsg(tblIntPostings, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0)) && ((dfCurrBalance.Number == 0) && (dfBalance.Number == 0));
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
						if (!(CheckRows())) 
						{
							return false;
						}
						if (Sal.SendMsg(tblIntPostings, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0)) 
						{
							Ifs.Fnd.ApplicationForms.Var.bReturn = true;
							return true;
						}
						return false;
				}
			}

			return false;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nWhat"></param>
		/// <returns></returns>
		public virtual SalBoolean UM_List(SalNumber nWhat)
		{
			#region Actions
			using (new SalContext(this))
			{
				switch (nWhat)
				{
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
						return Sal.SendMsg(hLastWithFocus, Ifs.Fnd.ApplicationForms.Const.PM_DataItemLov, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0);
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
						Sal.SendMsg(hLastWithFocus, Ifs.Fnd.ApplicationForms.Const.PM_DataItemLov, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
						Sal.TblSetFocusCell(this.tblIntPostings, Sal.TblQueryContext(this.tblIntPostings), hLastWithFocus, 0, 0);
						return Sal.SendMsg(hLastWithFocus, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
				}
			}

			return false;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber DisableEnableCodeParts()
		{
			#region Local Variables
			SalNumber nCount = 0;
			SalNumber nCountCodeParts = 0;
			SalString sManual = "";
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				if (Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Int_Posting_Method_API.Get_Manual_Code_Parts")) 
				{
					using(SignatureHints hints = SignatureHints.NewContext())
					{
						hints.Add("Int_Posting_Method_API.Get_Manual_Code_Parts", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
						if (!(DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN \r\n" +
							"				:i_hWndFrame.dlgManualIntPosting.sManualCodeParts := " + cSessionManager.c_sDbPrefix + "Int_Posting_Method_API.Get_Manual_Code_Parts(\r\n" +
							"				:i_hWndFrame.dlgManualIntPosting.dfsCompany, :i_hWndFrame.dlgManualIntPosting.dfsLedgerId, :i_hWndFrame.dlgManualIntPosting.dfAccount,:i_hWndFrame.dlgManualIntPosting.dVoucherDate); \r\n" +
							"			   END;"))) 
						{
							return false;
						}
					}
				}
				nCount = 0;
				nCountCodeParts = 0;
				if (sManualCodeParts != Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
					while (nCountCodeParts < 9) 
					{
						sManual = sManualCodeParts.Mid(nCountCodeParts, 1);
						if (sManual == "M") 
						{
							Sal.ShowWindow(tblIntPostings.i_hWndChild[nCount + 9]);
							Sal.ShowWindow(tblIntPostings.i_hWndChild[nCount + 10]);
						}
						else
						{
							Sal.HideWindow(tblIntPostings.i_hWndChild[nCount + 9]);
							Sal.SetWindowText(tblIntPostings.i_hWndChild[nCount + 9], Ifs.Fnd.ApplicationForms.Const.strNULL);
							Sal.HideWindow(tblIntPostings.i_hWndChild[nCount + 10]);
							Sal.SetWindowText(tblIntPostings.i_hWndChild[nCount + 10], Ifs.Fnd.ApplicationForms.Const.strNULL);
						}
						nCount = nCount + 2;
						nCountCodeParts = nCountCodeParts + 1;
					}
				}
				Sal.HideWindow(tblIntPostings_colsAccount);
				Sal.HideWindow(tblIntPostings_colsAccountDesc);
			}

			return 0;
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
				this.pbOk.MethodInvestigateState();
                this.pbCancel.MethodInvestigateState();
                this.pbNew.MethodInvestigateState();
                this.pbRemove.MethodInvestigateState();
                this.pbSave.MethodInvestigateState();
                this.pbList.MethodInvestigateState();
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber GetIntitialData()
		{
			#region Local Variables
			cMessage sMessage = new cMessage();
			SalString sPackedMessage = "";
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				sPackedMessage = SalString.FromHandle(Sal.SendMsg(hWndOwner, Const.PAM_GetIntPostingInfo, 0, 0));
				sMessage.Unpack(sPackedMessage);
				this.i_sCompany = sMessage.GetAttribute("COMPANY");
				dfsCompany.Text = i_sCompany;
				dfsLedgerId.Text = sMessage.GetAttribute("LEDGER_ID");
				dfsVoucherType.Text = sMessage.GetAttribute("VOUCHER_TYPE");
				dfAccount.Text = sMessage.GetAttribute("ACCOUNT");
				sCorrection = sMessage.GetAttribute("CORRECTION");
				dVoucherDate = sMessage.GetAttribute("VOUCHER_DATE").ToDate();
				dfnInternalSeqNumber.Number = sMessage.GetAttribute("INTERNAL_SEQ_NUMBER").ToNumber();
				dfnAccountingYear.Number = MessageStringToNumber(sMessage.GetAttribute("ACCOUNTING_YEAR"));
				dfnVoucherNo.Number = MessageStringToNumber(sMessage.GetAttribute("VOUCHER_NO"));
				dfnRefRowNo.Number = MessageStringToNumber(sMessage.GetAttribute("REF_ROW_NO"));
                nCurrencyAmount = Ifs.Fnd.ApplicationForms.Int.PalStrToNumber(sMessage.GetAttribute("CURRENCY_AMOUNT"));
                nAmount = Ifs.Fnd.ApplicationForms.Int.PalStrToNumber(sMessage.GetAttribute("AMOUNT"));
                nCurrRate = Ifs.Fnd.ApplicationForms.Int.PalStrToNumber(sMessage.GetAttribute("CURRENCY_RATE"));
				((cFinlibServices)this).i_nFinConversionFactor = MessageStringToNumber(sMessage.GetAttribute("CONV_FACTOR"));
				((cFinlibServices)this).i_nFinTransRound = MessageStringToNumber(sMessage.GetAttribute("DECIMAL_TRANS_ROUND"));
				((cFinlibServices)this).i_nFinBaseRound = MessageStringToNumber(sMessage.GetAttribute("DECIMAL_BASE_ROUND"));
				nBase = ((cFinlibServices)this).i_nFinBaseRound;
				nTrans = ((cFinlibServices)this).i_nFinTransRound;
				sEditable = sMessage.GetAttribute("EDITABLE");
				// Bug 72736, Begin
				sCompCurrency = sMessage.GetAttribute("COMP_CURRENCY");
				sCurrency = sMessage.GetAttribute("CURRENCY");
				// Bug 72736, End
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean CheckRows()
		{
			#region Local Variables
			SalNumber nCount = 0;
			SalNumber nCountCodeParts = 0;
			SalString sManual = "";
			SalBoolean bCompleted = false;
			// Bug 81344, Begin
			SalNumber nChildTblContextRow = 0;
			SalNumber nChildTblCurrentRow = 0;
			SalString sCodePartText = "";
			// Bug 81344, End
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				nCountCodeParts = 0;
				nCount = 0;
				bCompleted = true;
				// Bug 81344, Begin. Changed logic since aurora interprets alphanumeric characters as zero. New while loop added to replace SalTblColumnSum.
				if (sManualCodeParts != Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
					while (nCountCodeParts < 9) 
					{
						sManual = sManualCodeParts.Mid(nCountCodeParts, 1);
						if (sManual == "M") 
						{
							// Check whether the current column is not completed in any row
							nChildTblContextRow = Sal.TblQueryContext(tblIntPostings);
							nChildTblCurrentRow = Sys.TBL_MinRow;
							while (Sal.TblFindNextRow(tblIntPostings, ref nChildTblCurrentRow, 0, Sys.ROW_MarkDeleted)) 
							{
								Sal.TblSetContext(tblIntPostings, nChildTblCurrentRow);
								Sal.TblGetColumnText(tblIntPostings, nCount + 12, ref sCodePartText);
								if (sCodePartText == Ifs.Fnd.ApplicationForms.Const.strNULL) 
								{
									bCompleted = false;
									break;
								}
							}
							Sal.TblSetContext(tblIntPostings, nChildTblContextRow);
						}
						// If the current column not completed, return
						if (!(bCompleted)) 
						{
							Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_IntPostNotCompleted, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
							return false;
						}
						nCountCodeParts = nCountCodeParts + 1;
						nCount = nCount + 2;
					}
				}
				// Bug 81344, End
				return true;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="sInNumber"></param>
		/// <returns></returns>
		public virtual SalNumber MessageStringToNumber(SalString sInNumber)
		{
			#region Local Variables
			SalNumber nOutNumber = 0;
			SalString sWorkNumber = "";
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				sWorkNumber = sInNumber;
				if (sThousandSeparator != "") 
				{
					sWorkNumber = Vis.StrSubstitute(sWorkNumber, sThousandSeparator, "");
				}
				if (sNumberGrouping != "") 
				{
					sWorkNumber = Vis.StrSubstitute(sWorkNumber, sNumberGrouping, "");
				}
				if (sDecimalSeparator != ".") 
				{
					sWorkNumber = Vis.StrSubstitute(sWorkNumber, sDecimalSeparator, ".");
				}
				return sWorkNumber.ToNumber();
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
		private void dlgManualIntPosting_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Create:
					this.dlgManualIntPosting_OnSAM_Create(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave:
					this.dlgManualIntPosting_OnPM_DataSourceSave(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_Create event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dlgManualIntPosting_OnSAM_Create(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam)) 
			{
				this.sDecimalSeparator = Ifs.Fnd.ApplicationForms.Int.PalGetLocaleInfo(Ifs.Fnd.ApplicationForms.Const.LOCALE_SDECIMAL);
				this.sThousandSeparator = Ifs.Fnd.ApplicationForms.Int.PalGetLocaleInfo(Ifs.Fnd.ApplicationForms.Const.LOCALE_STHOUSAND);
				this.sNumberGrouping = Ifs.Fnd.ApplicationForms.Int.PalGetLocaleInfo(Ifs.Fnd.ApplicationForms.Const.LOCALE_SGROUPING);
				this.GetIntitialData();
				if (this.dfBalance.Number == Sys.NUMBER_Null) 
				{
					this.dfSumPercentage.Number = 0;
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
		private void dlgManualIntPosting_OnPM_DataSourceSave(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute && !((this.dfCurrBalance.Number == 0) && (this.dfBalance.Number == 0))) 
			{
				e.Return = false;
				return;
			}
			e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void tblIntPostings_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate:
					this.tblIntPostings_OnPM_DataSourcePopulate(sender, e);
					break;
				
				case Sys.SAM_FetchRowDone:
					this.tblIntPostings_OnSAM_FetchRowDone(sender, e);
					break;
				
				case Sys.SAM_Create:
					this.tblIntPostings_OnSAM_Create(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove:
					this.tblIntPostings_OnPM_DataRecordRemove(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave:
					this.tblIntPostings_OnPM_DataSourceSave(sender, e);
					break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew:
                    this.tblIntPostings_OnPM_DataRecordNew(sender, e);
                    break;
			}
			#endregion
		}
		
		/// <summary>
		/// PM_DataSourcePopulate event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblIntPostings_OnPM_DataSourcePopulate(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Sys.wParam, Sys.lParam)) 
			{
				if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
				{
					if (this.nCurrencyAmount != 0) 
					{
						this.tblIntPostings_colnPercentage.Number = (this.tblIntPostings_colnCurrencyAmount.Number / this.nCurrencyAmount * 100).Abs();
						if (this.sCorrection == "Y") 
						{
							this.dfCurrBalance.Number = this.nCurrencyAmount - Sal.TblColumnSum(this.tblIntPostings, 33, 0, Sys.ROW_MarkDeleted);
						}
						else
						{
							this.dfCurrBalance.Number = -(this.nCurrencyAmount - Sal.TblColumnSum(this.tblIntPostings, 33, 0, Sys.ROW_MarkDeleted));
						}
					}
					else if (this.nAmount != 0) 
					{
						this.tblIntPostings_colnPercentage.Number = (this.tblIntPostings_colnAmount.Number / this.nAmount * 100).Abs();
						if (this.sCorrection == "Y") 
						{
							this.dfBalance.Number = this.nAmount - Sal.TblColumnSum(this.tblIntPostings, 36, 0, Sys.ROW_MarkDeleted);
						}
						else
						{
							this.dfBalance.Number = -(this.nAmount - Sal.TblColumnSum(this.tblIntPostings, 36, 0, Sys.ROW_MarkDeleted));
						}
					}
					else
					{
						this.tblIntPostings_colnPercentage.Number = 0;
					}
					this.dfSumPercentage.Number = 100 - Sal.TblColumnSum(this.tblIntPostings, 30, 0, Sys.ROW_MarkDeleted);
					if (this.dfCurrBalance.Number != 0) 
					{
						this.CalCulateBalance();
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
		/// SAM_FetchRowDone event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblIntPostings_OnSAM_FetchRowDone(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Sys.SAM_FetchRowDone, Sys.wParam, Sys.lParam)) 
			{
				if (this.nCurrencyAmount != 0) 
				{
					this.tblIntPostings_colnPercentage.Number = (this.tblIntPostings_colnCurrencyAmount.Number / this.nCurrencyAmount * 100).Abs();
				}
				else if (this.nAmount != 0) 
				{
					this.tblIntPostings_colnPercentage.Number = (this.tblIntPostings_colnAmount.Number / this.nAmount * 100).Abs();
				}
				else
				{
					this.tblIntPostings_colnPercentage.Number = 0;
				}
				e.Return = true;
				return;
			}
			e.Return = false;
			return;
			#endregion
		}
		
		/// <summary>
		/// SAM_Create event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblIntPostings_OnSAM_Create(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam)) 
			{
				if (!(Sal.SendMsg(this.hWndOwner, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0))) 
				{
					this.SourceFlagsSet(Ifs.Fnd.ApplicationForms.Const.SOURCE_OperationModify, false);
					if (this.sEditable == "Y") 
					{
						this.SourceFlagsSet(Ifs.Fnd.ApplicationForms.Const.SOURCE_OperationNew, true);
						this.SourceFlagsSet(Ifs.Fnd.ApplicationForms.Const.SOURCE_OperationRemove, true);
					}
					else
					{
						this.SourceFlagsSet(Ifs.Fnd.ApplicationForms.Const.SOURCE_OperationNew, false);
						this.SourceFlagsSet(Ifs.Fnd.ApplicationForms.Const.SOURCE_OperationRemove, false);
					}
					SalNumber nSumCurrencyAmount = Sal.TblQueryColumnID(this.tblIntPostings_colnCurrencyAmount);
					SalNumber nSumAmount = Sal.TblQueryColumnID(this.tblIntPostings_colnAmount);
				}
				e.Return = true;
				return;
			}
			e.Return = false;
			return;
			#endregion
		}
		
		/// <summary>
		/// PM_DataRecordRemove event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblIntPostings_OnPM_DataRecordRemove(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove, Sys.wParam, Sys.lParam)) 
			{
				if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
				{
					this.dfSumPercentage.Number = 100 - Sal.TblColumnSum(this.tblIntPostings, 30, 0, Sys.ROW_MarkDeleted);
					if (this.sCorrection == "Y") 
					{
						this.dfCurrBalance.Number = this.nCurrencyAmount - Sal.TblColumnSum(this.tblIntPostings, 33, 0, Sys.ROW_MarkDeleted);
					}
					else
					{
						this.dfCurrBalance.Number = -(this.nCurrencyAmount - Sal.TblColumnSum(this.tblIntPostings, 34, 0, Sys.ROW_MarkDeleted));
					}
					if (this.sCorrection == "Y") 
					{
						this.dfBalance.Number = this.nAmount - Sal.TblColumnSum(this.tblIntPostings, 36, 0, Sys.ROW_MarkDeleted);
					}
					else
					{
						this.dfBalance.Number = -(this.nAmount - Sal.TblColumnSum(this.tblIntPostings, 36, 0, Sys.ROW_MarkDeleted));
					}
					this.RefreshButtonsState();
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
		private void tblIntPostings_OnPM_DataSourceSave(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
			{
				this.DisableEnableCodePartsChild();
				this.SetAccountEditedFlag();
			}
			e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}

        /// <summary>
        /// PM_DataRecordNew event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblIntPostings_OnPM_DataRecordNew(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire)
            {
                if (this.sEditable == "N")
                {
                    e.Return = false;
                    return;
                }

            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew, Sys.wParam, Sys.lParam);
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
		public override SalString vrtGetWindowTitle()
		{
			return this.GetWindowTitle();
		}
		
		/// <summary>
		/// Virtual wrapper replacement for late-bound (..) calls.
		/// </summary>
		public override SalNumber vrtUserMethod(SalNumber nWhat, SalString sMethod)
		{
			return this.UserMethod(nWhat, sMethod);
		}
		#endregion
		
		#region Childtable-tblIntPostings
			
		#region Methods
			
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean DataRecordGetDefaults()
		{
			tblIntPostings_colsCompany.Text = this.dfsCompany.Text;
			tblIntPostings_colsLedgerId.Text = this.dfsLedgerId.Text;
			tblIntPostings_colsAccount.Text = this.dfAccount.Text;
			tblIntPostings_colnRefRowNo.Number = this.dfnRefRowNo.Number;
			tblIntPostings_colsVoucherType.Text = this.dfsVoucherType.Text;
			tblIntPostings_colnAccountingYear.Number = this.dfnAccountingYear.Number;
			tblIntPostings_colnVoucherNo.Number = this.dfnVoucherNo.Number;
			tblIntPostings_colnCurrencyRate.Number = this.nCurrRate;
			tblIntPostings_colnInternalSeqNumber.Number = this.dfnInternalSeqNumber.Number;
			tblIntPostings_colsCompany.EditDataItemSetEdited();
			tblIntPostings_colsLedgerId.EditDataItemSetEdited();
			tblIntPostings_colsAccount.EditDataItemSetEdited();
			tblIntPostings_colnRefRowNo.EditDataItemSetEdited();
			tblIntPostings_colsVoucherType.EditDataItemSetEdited();
			tblIntPostings_colnAccountingYear.EditDataItemSetEdited();
			tblIntPostings_colnVoucherNo.EditDataItemSetEdited();
			tblIntPostings_colnCurrencyRate.EditDataItemSetEdited();
			tblIntPostings_colnInternalSeqNumber.EditDataItemSetEdited();
			return false;
		}
			
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean CalCulateBalance()
		{
			// PPJ: Automatically generated temporary assignments. Properties canot be passed by reference.
			SalNumber temp1 = this.dfBalance.Number;
			this.GetBaseCurrAmountForRate(this.dfCurrBalance.Number, this.nCurrRate, ref temp1);
			this.dfBalance.Number = temp1;
			return true;
		}
			
		/// <summary>
		/// </summary>
		/// <param name="sDebitCredit"></param>
		/// <returns></returns>
		public virtual SalBoolean CalCulateBaseCurrAmount(SalString sDebitCredit)
		{
			if (sDebitCredit == "C") 
			{
				// Bug 72736, Begin. Added IF condition.
				if (tblIntPostings_colnCurrencyCreditAmount.Number != Sys.NUMBER_Null) 
				{
					// Bug 71319, Begin. Removed unnecessary GetParent.

					// PPJ: Automatically generated temporary assignments. Properties canot be passed by reference.
					SalNumber temp1 = tblIntPostings_colnCreditAmount.Number;
					this.GetBaseCurrAmountForRate(tblIntPostings_colnCurrencyCreditAmount.Number, this.nCurrRate, ref temp1);
					tblIntPostings_colnCreditAmount.Number = temp1;

					// Bug 71319, End.
					tblIntPostings_colnCreditAmount.EditDataItemSetEdited();
					Sal.SendMsg(tblIntPostings_colnCreditAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
				}
				else
				{
					tblIntPostings_colnCreditAmount.Number = Sys.NUMBER_Null;
					tblIntPostings_colnAmount.Number = Sys.NUMBER_Null;
					tblIntPostings_colnCurrencyAmount.Number = Sys.NUMBER_Null;
				}
				// Bug 72736, End.
			}
			else
			{
				// Bug 72736, Begin. Added IF condition.
				if (tblIntPostings_colnCurrencyDebitAmount.Number != Sys.NUMBER_Null) 
				{
					// Bug 71319, Begin. Removed unnecessary GetParent.

					// PPJ: Automatically generated temporary assignments. Properties canot be passed by reference.
					SalNumber temp2 = tblIntPostings_colnDebitAmount.Number;
					this.GetBaseCurrAmountForRate(tblIntPostings_colnCurrencyDebitAmount.Number, this.nCurrRate, ref temp2);
					tblIntPostings_colnDebitAmount.Number = temp2;

					// Bug 71319, End.
					tblIntPostings_colnDebitAmount.EditDataItemSetEdited();
					Sal.SendMsg(tblIntPostings_colnDebitAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
				}
				else
				{
					tblIntPostings_colnDebitAmount.Number = Sys.NUMBER_Null;
					tblIntPostings_colnAmount.Number = Sys.NUMBER_Null;
					tblIntPostings_colnCurrencyAmount.Number = Sys.NUMBER_Null;
				}
				// Bug 72736, End.
			}
			return true;

		}
			
		/// <summary>
		/// </summary>
		/// <param name="hSql"></param>
		/// <returns></returns>
		public virtual SalBoolean DataRecordExecuteNew(SalSqlHandle hSql)
		{
			Sal.SetFieldEdit(tblIntPostings_colnCurrencyAmount, false);
			Sal.SetFieldEdit(tblIntPostings_colnAmount, false);
			return ((cChildTableFin)tblIntPostings).DataRecordExecuteNew(hSql);	
		}
			
		/// <summary>
		/// </summary>
		/// <param name="hSql"></param>
		/// <returns></returns>
		public virtual SalBoolean DataRecordExecuteModify(SalSqlHandle hSql)
		{
			Sal.SetFieldEdit(tblIntPostings_colnCurrencyAmount, false);
			Sal.SetFieldEdit(tblIntPostings_colnAmount, false);
			return ((cChildTableFin)tblIntPostings).DataRecordExecuteModify(hSql);
		}
			
		/// <summary>
		/// </summary>
		/// <param name="lsAttr"></param>
		/// <returns></returns>
		public virtual SalNumber DataRecordFetchEditedUser(ref SalString lsAttr)
		{
		    if (this.dfnVoucherNo.Number > 0) 
		    {
			    Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("MODIFY", "TRUE", ref lsAttr);
		    }
			return 0;
		}
			
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber DisableEnableCodePartsChild()
		{
			#region Local Variables
			SalNumber nCount = 0;
			SalNumber nCountCodeParts = 0;
			SalString sManual = "";
			SalNumber nRow = 0;
			#endregion
				
			#region Actions

			if (Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Int_Posting_Method_API.Get_Manual_Code_Parts")) 
			{				
			    if (!(DbPLSQLBlock(@"{0} := &AO.Int_Posting_Method_API.Get_Manual_Code_Parts({1} IN, {2} IN, {3} IN, {4} IN);",
                        this.QualifiedVarBindName("sManualCodeParts"),
                        this.dfsCompany.QualifiedBindName,
                        this.dfsLedgerId.QualifiedBindName,
                        this.dfAccount.QualifiedBindName,
                        this.QualifiedVarBindName("dVoucherDate") ))) 
			    {
				    return false;
			    }
				
			}
			Sal.TblSetContext(tblIntPostings, Sys.TBL_MinRow);
			nRow = Sys.TBL_MinRow;
            while (Sal.TblFindNextRow(tblIntPostings, ref nRow, 0, 0)) 
			{
                Sal.TblSetContext(tblIntPostings, nRow);
				nCount = 0;
				nCountCodeParts = 0;
				if (this.sManualCodeParts != Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
					while (nCountCodeParts < 9) 
					{
						sManual = this.sManualCodeParts.Mid(nCountCodeParts, 1);
						if (sManual == "M") 
						{
                            Sal.ShowWindow(tblIntPostings.i_hWndChild[nCount + 9]);
                            Sal.ShowWindow(tblIntPostings.i_hWndChild[nCount + 10]);
						}
						else
						{
                            Sal.HideWindow(tblIntPostings.i_hWndChild[nCount + 9]);
                            Sal.SetWindowText(tblIntPostings.i_hWndChild[nCount + 9], Ifs.Fnd.ApplicationForms.Const.strNULL);
                            Sal.HideWindow(tblIntPostings.i_hWndChild[nCount + 10]);
                            Sal.SetWindowText(tblIntPostings.i_hWndChild[nCount + 10], Ifs.Fnd.ApplicationForms.Const.strNULL);
						}
						nCount = nCount + 2;
						nCountCodeParts = nCountCodeParts + 1;
					}
				}
				Sal.HideWindow(tblIntPostings_colsAccount);
				Sal.HideWindow(tblIntPostings_colsAccountDesc);
			}
			
			return 0;
			#endregion
		}
			
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber SetAccountEditedFlag()
		{		
		    SalNumber nCurrentRow = Sys.TBL_MinRow;
            SalNumber nContextRow = Sal.TblQueryContext(tblIntPostings);
            while (Sal.TblFindNextRow(tblIntPostings, ref nCurrentRow, Sys.ROW_Edited, Sys.ROW_New)) 
		    {
                Sal.TblSetContext(tblIntPostings, nCurrentRow);
			    Sal.SetFieldEdit(tblIntPostings_colsAccount, false);
		    }
            Sal.TblSetContext(tblIntPostings, nContextRow);
			return 0;
		}
			
		/// <summary>
		/// Override this function to check whether a project is an extrnally created project
		/// </summary>
		/// <param name="sCodePartValue"></param>
		/// <returns></returns>
		public virtual new SalBoolean EnableDisableProjectActivityId(SalString sCodePartValue)
		{
            return true;
		}
		// Bug 72736, Begin
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean GetAmounts()
		{
		    if (this.sCompCurrency == this.sCurrency) 
		    {
			    if (tblIntPostings_colnCreditAmount.Number == Sys.NUMBER_Null) 
			    {
				    tblIntPostings_colnCurrencyDebitAmount.Number = tblIntPostings_colnDebitAmount.Number;
				    tblIntPostings_colnCurrencyDebitAmount.EditDataItemSetEdited();
				    tblIntPostings_colnCurrencyAmount.Number = tblIntPostings_colnDebitAmount.Number;
				    tblIntPostings_colnCurrencyAmount.EditDataItemSetEdited();
				    tblIntPostings_colnCurrencyCreditAmount.Number = Sys.NUMBER_Null;
				    tblIntPostings_colnCurrencyCreditAmount.EditDataItemSetEdited();
			    }
			    else if (tblIntPostings_colnCreditAmount.Number != 0 && tblIntPostings_colnDebitAmount.Number == Sys.NUMBER_Null) 
			    {
				    tblIntPostings_colnCurrencyCreditAmount.Number = tblIntPostings_colnCreditAmount.Number;
				    tblIntPostings_colnCurrencyCreditAmount.EditDataItemSetEdited();
				    tblIntPostings_colnCurrencyAmount.Number = -tblIntPostings_colnCreditAmount.Number;
				    tblIntPostings_colnCurrencyAmount.EditDataItemSetEdited();
				    tblIntPostings_colnCurrencyDebitAmount.Number = Sys.NUMBER_Null;
				    tblIntPostings_colnCurrencyDebitAmount.EditDataItemSetEdited();
			    }
		    }
		    else
		    {
			    if (tblIntPostings_colnCurrencyCreditAmount.Number == Sys.NUMBER_Null && tblIntPostings_colnCurrencyDebitAmount.Number == Sys.NUMBER_Null) 
			    {
				    tblIntPostings_colnDebitAmount.Number = Sys.NUMBER_Null;
				    tblIntPostings_colnCreditAmount.Number = Sys.NUMBER_Null;
				    tblIntPostings_colnAmount.Number = Sys.NUMBER_Null;
				    tblIntPostings_colnPercentage.Number = Sys.NUMBER_Null;
			    }
		    }
		    return true;
		}
		// Bug 72736, End
		/// <summary>
		/// Set the rounded value based on base currency.
		/// </summary>
		/// <param name="nMyValue"></param>
		/// <returns></returns>
		public virtual SalNumber SetBaseRoundValue(SalNumber nMyValue)
		{
		    if (nMyValue != SalNumber.Null) 
		    {
			    nMyValue = this.RoundOf(nMyValue, this.nBase);
		    }
		    return nMyValue;
		}
			
		/// <summary>
		/// Set the rounded value based on transaction currency.
		/// </summary>
		/// <param name="nMyValue"></param>
		/// <returns></returns>
		public virtual SalNumber SetTransRoundValue(SalNumber nMyValue)
		{
	        if (nMyValue != SalNumber.Null) 
	        {
		        nMyValue = this.RoundOf(nMyValue, this.nTrans);
	        }
	        return nMyValue;
		}
		#endregion
			
		#region Window Actions
			
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void tblIntPostings_colsCodeB_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_SetFocus:
					this.tblIntPostings_colsCodeB_OnSAM_SetFocus(sender, e);
					break;
			}
			#endregion
		}
			
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblIntPostings_colsCodeB_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.hLastWithFocus = this.tblIntPostings_colsCodeB.i_hWndSelf;
			this.RefreshButtonsState();
			e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
			
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void tblIntPostings_colsCodeC_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_SetFocus:
					this.tblIntPostings_colsCodeC_OnSAM_SetFocus(sender, e);
					break;
			}
			#endregion
		}
			
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblIntPostings_colsCodeC_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.hLastWithFocus = this.tblIntPostings_colsCodeC.i_hWndSelf;
			this.RefreshButtonsState();
			e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
			
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void tblIntPostings_colsCodeD_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_SetFocus:
					this.tblIntPostings_colsCodeD_OnSAM_SetFocus(sender, e);
					break;
			}
			#endregion
		}
			
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblIntPostings_colsCodeD_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.hLastWithFocus = this.tblIntPostings_colsCodeD.i_hWndSelf;
			this.RefreshButtonsState();
			e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
			
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void tblIntPostings_colsCodeE_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_SetFocus:
					this.tblIntPostings_colsCodeE_OnSAM_SetFocus(sender, e);
					break;
			}
			#endregion
		}
			
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblIntPostings_colsCodeE_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.hLastWithFocus = this.tblIntPostings_colsCodeE.i_hWndSelf;
			this.RefreshButtonsState();
			e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
			
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void tblIntPostings_colsCodeF_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_SetFocus:
					this.tblIntPostings_colsCodeF_OnSAM_SetFocus(sender, e);
					break;
			}
			#endregion
		}
			
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblIntPostings_colsCodeF_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.hLastWithFocus = this.tblIntPostings_colsCodeF.i_hWndSelf;
			this.RefreshButtonsState();
			e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
			
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void tblIntPostings_colsCodeG_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_SetFocus:
					this.tblIntPostings_colsCodeG_OnSAM_SetFocus(sender, e);
					break;
			}
			#endregion
		}
			
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblIntPostings_colsCodeG_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.hLastWithFocus = this.tblIntPostings_colsCodeG.i_hWndSelf;
			this.RefreshButtonsState();
			e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
			
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void tblIntPostings_colsCodeH_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_SetFocus:
					this.tblIntPostings_colsCodeH_OnSAM_SetFocus(sender, e);
					break;
			}
			#endregion
		}
			
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblIntPostings_colsCodeH_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.hLastWithFocus = this.tblIntPostings_colsCodeH.i_hWndSelf;
			this.RefreshButtonsState();
			e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
			
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void tblIntPostings_colsCodeI_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_SetFocus:
					this.tblIntPostings_colsCodeI_OnSAM_SetFocus(sender, e);
					break;
			}
			#endregion
		}
			
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblIntPostings_colsCodeI_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.hLastWithFocus = this.tblIntPostings_colsCodeI.i_hWndSelf;
			this.RefreshButtonsState();
			e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
			
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void tblIntPostings_colsCodeJ_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_SetFocus:
					this.tblIntPostings_colsCodeJ_OnSAM_SetFocus(sender, e);
					break;
			}
			#endregion
		}
			
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblIntPostings_colsCodeJ_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.hLastWithFocus = this.tblIntPostings_colsCodeJ.i_hWndSelf;
			this.RefreshButtonsState();
			e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
			
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void tblIntPostings_colnPercentage_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
					this.tblIntPostings_colnPercentage_OnPM_DataItemValidate(sender, e);
					break;
					
				case Sys.SAM_SetFocus:
					this.tblIntPostings_colnPercentage_OnSAM_SetFocus(sender, e);
					break;
					
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
					this.tblIntPostings_colnPercentage_OnPM_DataItemQueryEnabled(sender, e);
					break;
			}
			#endregion
		}
			
		/// <summary>
		/// PM_DataItemValidate event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblIntPostings_colnPercentage_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam)) 
			{
				this.dfSumPercentage.Number = Sal.TblColumnSum(this, 30, 0, Sys.ROW_MarkDeleted);
				if (this.nCurrencyAmount != 0 || this.nCurrencyAmount != SalNumber.Null) 
				{
					if (this.sCorrection == "Y") 
					{
						if (this.nCurrencyAmount > 0) 
						{
							this.tblIntPostings_colnCurrencyCreditAmount.Number = -this.tblIntPostings_colnPercentage.Number * this.nCurrencyAmount / 100;
							this.tblIntPostings_colnCurrencyCreditAmount.EditDataItemSetEdited();
							Sal.SendMsg(this.tblIntPostings_colnCurrencyCreditAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
						}
						else
						{
							this.tblIntPostings_colnCurrencyDebitAmount.Number = this.tblIntPostings_colnPercentage.Number * this.nCurrencyAmount / 100;
							this.tblIntPostings_colnCurrencyDebitAmount.EditDataItemSetEdited();
							Sal.SendMsg(this.tblIntPostings_colnCurrencyDebitAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
						}
					}
					else
					{
						if (this.nCurrencyAmount > 0) 
						{
							this.tblIntPostings_colnCurrencyDebitAmount.Number = this.tblIntPostings_colnPercentage.Number * this.nCurrencyAmount / 100;
							this.tblIntPostings_colnCurrencyDebitAmount.EditDataItemSetEdited();
							Sal.SendMsg(this.tblIntPostings_colnCurrencyDebitAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
						}
						else
						{
							this.tblIntPostings_colnCurrencyCreditAmount.Number = -this.tblIntPostings_colnPercentage.Number * this.nCurrencyAmount / 100;
							this.tblIntPostings_colnCurrencyCreditAmount.EditDataItemSetEdited();
							Sal.SendMsg(this.tblIntPostings_colnCurrencyCreditAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
						}
					}
				}
				else if (this.nAmount != 0 || this.nAmount != SalNumber.Null) 
				{
					if (this.sCorrection == "Y") 
					{
						if (this.nAmount > 0) 
						{
							this.tblIntPostings_colnCreditAmount.Number = -this.tblIntPostings_colnPercentage.Number * this.nAmount / 100;
							this.tblIntPostings_colnCreditAmount.EditDataItemSetEdited();
							Sal.SendMsg(this.tblIntPostings_colnCreditAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
						}
						else
						{
							this.tblIntPostings_colnDebitAmount.Number = this.tblIntPostings_colnPercentage.Number * this.nAmount / 100;
							this.tblIntPostings_colnDebitAmount.EditDataItemSetEdited();
							Sal.SendMsg(this.tblIntPostings_colnDebitAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
						}
					}
					else
					{
						if (this.nAmount > 0) 
						{
							this.tblIntPostings_colnDebitAmount.Number = this.tblIntPostings_colnPercentage.Number * this.nAmount / 100;
							this.tblIntPostings_colnDebitAmount.EditDataItemSetEdited();
							Sal.SendMsg(this.tblIntPostings_colnDebitAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
						}
						else
						{
							this.tblIntPostings_colnCreditAmount.Number = -this.tblIntPostings_colnPercentage.Number * this.nAmount / 100;
							this.tblIntPostings_colnCreditAmount.EditDataItemSetEdited();
							Sal.SendMsg(this.tblIntPostings_colnCreditAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
						}
					}
				}
			}
			e.Return = true;
			return;
			#endregion
		}
			
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblIntPostings_colnPercentage_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.hLastWithFocus = this.tblIntPostings_colnPercentage.i_hWndSelf;
			this.RefreshButtonsState();
			e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
			
		/// <summary>
		/// PM_DataItemQueryEnabled event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblIntPostings_colnPercentage_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (this.rbAmount.Checked) 
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
		private void tblIntPostings_colnCurrencyDebitAmount_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
					this.tblIntPostings_colnCurrencyDebitAmount_OnPM_DataItemValidate(sender, e);
					break;
					
				case Sys.SAM_SetFocus:
					this.tblIntPostings_colnCurrencyDebitAmount_OnSAM_SetFocus(sender, e);
					break;
					
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
					this.tblIntPostings_colnCurrencyDebitAmount_OnPM_DataItemQueryEnabled(sender, e);
					break;
			}
			#endregion
		}
			
		/// <summary>
		/// PM_DataItemValidate event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblIntPostings_colnCurrencyDebitAmount_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam)) 
			{
				// Bug 72736, Begin. Added IF condition
				if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
				{
					this.tblIntPostings_colnCurrencyDebitAmount.Number = this.SetTransRoundValue(this.tblIntPostings_colnCurrencyDebitAmount.Number);
					this.tblIntPostings_colnCurrencyAmount.Number = this.tblIntPostings_colnCurrencyDebitAmount.Number;
					if (this.nCurrencyAmount != 0) 
					{
						this.tblIntPostings_colnPercentage.Number = (this.tblIntPostings_colnCurrencyDebitAmount.Number / this.nCurrencyAmount * 100).Abs();
						this.dfSumPercentage.Number = 100 - Sal.TblColumnSum(this, 30, 0, Sys.ROW_MarkDeleted);
						if (this.sCorrection == "Y") 
						{
                            this.dfCurrBalance.Number = this.nCurrencyAmount - Sal.TblColumnSum(this.tblIntPostings, 33, 0, Sys.ROW_MarkDeleted);
						}
						else
						{
                            this.dfCurrBalance.Number = -(this.nCurrencyAmount - Sal.TblColumnSum(this.tblIntPostings, 33, 0, Sys.ROW_MarkDeleted));
						}
						this.CalCulateBalance();
					}
					else
					{
						this.tblIntPostings_colnPercentage.Number = 0;
					}
					this.CalCulateBaseCurrAmount("D");
					if (!(Sal.IsNull(this.tblIntPostings_colnCurrencyDebitAmount.i_hWndSelf))) 
					{
						Sal.ClearField(this.tblIntPostings_colnCurrencyCreditAmount);
						Sal.ClearField(this.tblIntPostings_colnCreditAmount);
					}
				}
				// Bug 72736, End
			}
			this.RefreshButtonsState();
			Sal.SetFieldEdit(this.tblIntPostings_colnPercentage, true);
			if (this.dfBalance.Number == 0) 
			{
				this.dfSumPercentage.Number = 0;
			}
			e.Return = true;
			return;
			#endregion
		}
			
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblIntPostings_colnCurrencyDebitAmount_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.hLastWithFocus = this.tblIntPostings_colnCurrencyDebitAmount.i_hWndSelf;
			this.RefreshButtonsState();
			e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
			
		/// <summary>
		/// PM_DataItemQueryEnabled event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblIntPostings_colnCurrencyDebitAmount_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (!(Sal.IsNull(this.tblIntPostings_colnCurrencyCreditAmount))) 
			{
				e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
				return;
			}
			if (this.rbPercentage.Checked) 
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
		private void tblIntPostings_colnCurrencyCreditAmount_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
					this.tblIntPostings_colnCurrencyCreditAmount_OnPM_DataItemValidate(sender, e);
					break;
					
				case Sys.SAM_SetFocus:
					this.tblIntPostings_colnCurrencyCreditAmount_OnSAM_SetFocus(sender, e);
					break;
					
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
					this.tblIntPostings_colnCurrencyCreditAmount_OnPM_DataItemQueryEnabled(sender, e);
					break;
			}
			#endregion
		}
			
		/// <summary>
		/// PM_DataItemValidate event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblIntPostings_colnCurrencyCreditAmount_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam)) 
			{
				// Bug 72736, Begin. Added IF condition
				if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
				{
					this.tblIntPostings_colnCurrencyCreditAmount.Number = this.SetTransRoundValue(this.tblIntPostings_colnCurrencyCreditAmount.Number);
					this.tblIntPostings_colnCurrencyAmount.Number = -1 * this.tblIntPostings_colnCurrencyCreditAmount.Number;
					if (this.nCurrencyAmount != 0) 
					{
						this.tblIntPostings_colnPercentage.Number = (this.tblIntPostings_colnCurrencyCreditAmount.Number / this.nCurrencyAmount * 100).Abs();
						this.dfSumPercentage.Number = 100 - Sal.TblColumnSum(this, 30, 0, Sys.ROW_MarkDeleted);
						if (this.sCorrection == "Y") 
						{
                            this.dfCurrBalance.Number = this.nCurrencyAmount - Sal.TblColumnSum(this.tblIntPostings, 33, 0, Sys.ROW_MarkDeleted);
						}
						else
						{
                            this.dfCurrBalance.Number = -(this.nCurrencyAmount - Sal.TblColumnSum(this.tblIntPostings, 33, 0, Sys.ROW_MarkDeleted));
						}
						this.CalCulateBalance();
					}
					else
					{
						this.tblIntPostings_colnPercentage.Number = 0;
					}
					this.CalCulateBaseCurrAmount("C");
					if (!(Sal.IsNull(this.tblIntPostings_colnCurrencyCreditAmount.i_hWndSelf))) 
					{
						Sal.ClearField(this.tblIntPostings_colnCurrencyDebitAmount);
						Sal.ClearField(this.tblIntPostings_colnDebitAmount);
					}
				}
				// Bug 72736, End
			}
			this.RefreshButtonsState();
			Sal.SetFieldEdit(this.tblIntPostings_colnPercentage, true);
			if (this.dfBalance.Number == 0) 
			{
				this.dfSumPercentage.Number = 0;
			}
			e.Return = true;
			return;
			#endregion
		}
			
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblIntPostings_colnCurrencyCreditAmount_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.hLastWithFocus = this.tblIntPostings_colnCurrencyCreditAmount.i_hWndSelf;
			this.RefreshButtonsState();
			e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
			
		/// <summary>
		/// PM_DataItemQueryEnabled event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblIntPostings_colnCurrencyCreditAmount_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (!(Sal.IsNull(this.tblIntPostings_colnCurrencyDebitAmount))) 
			{
				e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
				return;
			}
			if (this.rbPercentage.Checked) 
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
		private void tblIntPostings_colnCurrencyAmount_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_SetFocus:
					this.tblIntPostings_colnCurrencyAmount_OnSAM_SetFocus(sender, e);
					break;
					
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
					this.tblIntPostings_colnCurrencyAmount_OnPM_DataItemValidate(sender, e);
					break;
			}
			#endregion
		}
			
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblIntPostings_colnCurrencyAmount_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.hLastWithFocus = this.tblIntPostings_colnCurrencyAmount.i_hWndSelf;
			this.RefreshButtonsState();
			e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
			
		/// <summary>
		/// PM_DataItemValidate event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblIntPostings_colnCurrencyAmount_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			// Bug 72736, Begin. Added IF condition
			if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
			{
				if (this.sCorrection == "Y") 
				{
					if (this.tblIntPostings_colnCurrencyAmount.Number > 0) 
					{
						this.tblIntPostings_colnCurrencyCreditAmount.Number = -this.tblIntPostings_colnCurrencyAmount.Number;
						this.tblIntPostings_colnCurrencyCreditAmount.EditDataItemSetEdited();
						Sal.SendMsg(this.tblIntPostings_colnCurrencyDebitAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, SalNumber.Null.ToString(0).ToHandle());
						Sal.SendMsg(this.tblIntPostings_colnCurrencyCreditAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
					}
					else
					{
						this.tblIntPostings_colnCurrencyDebitAmount.Number = this.tblIntPostings_colnCurrencyAmount.Number;
						this.tblIntPostings_colnCurrencyDebitAmount.EditDataItemSetEdited();
						Sal.SendMsg(this.tblIntPostings_colnCurrencyCreditAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, SalNumber.Null.ToString(0).ToHandle());
						Sal.SendMsg(this.tblIntPostings_colnCurrencyDebitAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
					}
				}
				else
				{
					if (this.tblIntPostings_colnCurrencyAmount.Number > 0) 
					{
						this.tblIntPostings_colnCurrencyDebitAmount.Number = this.tblIntPostings_colnCurrencyAmount.Number;
						this.tblIntPostings_colnCurrencyDebitAmount.EditDataItemSetEdited();
						Sal.SendMsg(this.tblIntPostings_colnCurrencyCreditAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, SalNumber.Null.ToString(0).ToHandle());
						Sal.SendMsg(this.tblIntPostings_colnCurrencyDebitAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
					}
					// Bug 72736, Begin. Added IF condition.
					else if (this.tblIntPostings_colnCurrencyAmount.Number == Sys.NUMBER_Null) 
					{
						this.tblIntPostings_colnCurrencyCreditAmount.Number = Sys.NUMBER_Null;
						this.tblIntPostings_colnCurrencyDebitAmount.Number = Sys.NUMBER_Null;
						this.tblIntPostings_colnDebitAmount.Number = Sys.NUMBER_Null;
						this.tblIntPostings_colnCreditAmount.Number = Sys.NUMBER_Null;
						this.tblIntPostings_colnAmount.Number = Sys.NUMBER_Null;
						this.tblIntPostings_colnPercentage.Number = 0;
						Sal.SendMsg(this.tblIntPostings_colnCurrencyDebitAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
					}
					// Bug 72736, End.
					else
					{
						this.tblIntPostings_colnCurrencyCreditAmount.Number = -this.tblIntPostings_colnCurrencyAmount.Number;
						this.tblIntPostings_colnCurrencyCreditAmount.EditDataItemSetEdited();
						Sal.SendMsg(this.tblIntPostings_colnCurrencyDebitAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, SalNumber.Null.ToString(0).ToHandle());
						Sal.SendMsg(this.tblIntPostings_colnCurrencyCreditAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
					}
				}
				Sal.SetFieldEdit(this.tblIntPostings_colnCurrencyAmount.i_hWndSelf, false);
				Sal.SetFieldEdit(this.tblIntPostings_colnPercentage, true);
				if (this.dfBalance.Number == 0) 
				{
					this.dfSumPercentage.Number = 0;
				}
			}
			// Bug 72736, End.
			e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
			
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void tblIntPostings_colnDebitAmount_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
					this.tblIntPostings_colnDebitAmount_OnPM_DataItemValidate(sender, e);
					break;
					
				case Sys.SAM_SetFocus:
					this.tblIntPostings_colnDebitAmount_OnSAM_SetFocus(sender, e);
					break;
					
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
					this.tblIntPostings_colnDebitAmount_OnPM_DataItemQueryEnabled(sender, e);
					break;
			}
			#endregion
		}
			
		/// <summary>
		/// PM_DataItemValidate event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblIntPostings_colnDebitAmount_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam)) 
			{
				// Bug 72736, Begin. Added IF condition
				if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
				{
					this.tblIntPostings_colnDebitAmount.Number = this.SetBaseRoundValue(this.tblIntPostings_colnDebitAmount.Number);
					this.tblIntPostings_colnAmount.Number = this.tblIntPostings_colnDebitAmount.Number;
					if ((this.sCompCurrency != this.sCurrency && this.tblIntPostings_colnCurrencyDebitAmount.Number != Sys.NUMBER_Null) || (this.sCompCurrency == this.sCurrency)) 
					{
						if (this.nAmount != 0) 
						{
							this.tblIntPostings_colnPercentage.Number = (this.tblIntPostings_colnDebitAmount.Number / this.nAmount * 100).Abs();
							this.dfSumPercentage.Number = 100 - Sal.TblColumnSum(this, 30, 0, Sys.ROW_MarkDeleted);
							if (this.sCorrection == "Y") 
							{
								this.dfBalance.Number = this.nAmount - Sal.TblColumnSum(this.tblIntPostings, 36, 0, Sys.ROW_MarkDeleted);
							}
							else
							{
                                this.dfBalance.Number = -(this.nAmount - Sal.TblColumnSum(this.tblIntPostings, 36, 0, Sys.ROW_MarkDeleted));
							}
						}
						else
						{
							this.tblIntPostings_colnPercentage.Number = 0;
						}
					}
					// Bug 72736, Begin
					if (this.tblIntPostings_colnDebitAmount.Number != Sys.NUMBER_Null) 
					{
						this.GetAmounts();
					}
					if (this.sCompCurrency == this.sCurrency) 
					{
						this.dfCurrBalance.Number = this.dfBalance.Number;
						if (!(Sal.IsNull(this.tblIntPostings_colnDebitAmount.i_hWndSelf))) 
						{
							Sal.ClearField(this.tblIntPostings_colnCurrencyCreditAmount);
							Sal.ClearField(this.tblIntPostings_colnCreditAmount);
						}
						else
						{
							Sal.ClearField(this.tblIntPostings_colnCurrencyDebitAmount);
							Sal.ClearField(this.tblIntPostings_colnDebitAmount);
							Sal.ClearField(this.tblIntPostings_colnCurrencyAmount);
							Sal.ClearField(this.tblIntPostings_colnAmount);
						}
					}
					// Bug 72736, End
				}
				// Bug 72736, End
			}
			this.RefreshButtonsState();
			Sal.SetFieldEdit(this.tblIntPostings_colnPercentage, true);
			if (this.dfBalance.Number == 0) 
			{
				this.dfSumPercentage.Number = 0;
			}
			e.Return = true;
			return;
			#endregion
		}
			
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblIntPostings_colnDebitAmount_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.hLastWithFocus = this.tblIntPostings_colnDebitAmount.i_hWndSelf;
			this.RefreshButtonsState();
			e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
			
		/// <summary>
		/// PM_DataItemQueryEnabled event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblIntPostings_colnDebitAmount_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (!(Sal.IsNull(this.tblIntPostings_colnCreditAmount))) 
			{
				e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
				return;
			}
			if (this.rbPercentage.Checked) 
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
		private void tblIntPostings_colnCreditAmount_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
					this.tblIntPostings_colnCreditAmount_OnPM_DataItemValidate(sender, e);
					break;
					
				case Sys.SAM_SetFocus:
					this.tblIntPostings_colnCreditAmount_OnSAM_SetFocus(sender, e);
					break;
					
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
					this.tblIntPostings_colnCreditAmount_OnPM_DataItemQueryEnabled(sender, e);
					break;
			}
			#endregion
		}
			
		/// <summary>
		/// PM_DataItemValidate event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblIntPostings_colnCreditAmount_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam)) 
			{
				// Bug 72736, Begin. Added IF condition
				if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
				{
					this.tblIntPostings_colnCreditAmount.Number = this.SetBaseRoundValue(this.tblIntPostings_colnCreditAmount.Number);
					// Bug 72736, Begin
					if (this.tblIntPostings_colnCreditAmount.Number != Sys.NUMBER_Null) 
					{
						this.tblIntPostings_colnAmount.Number = -1 * this.tblIntPostings_colnCreditAmount.Number;
					}
					else
					{
						Sal.ClearField(this.tblIntPostings_colnAmount);
					}
					if ((this.sCompCurrency != this.sCurrency && this.tblIntPostings_colnCurrencyCreditAmount.Number != Sys.NUMBER_Null) || (this.sCompCurrency == this.sCurrency)) 
					{
						if (this.nAmount != 0) 
						{
							this.tblIntPostings_colnPercentage.Number = (this.tblIntPostings_colnCreditAmount.Number / this.nAmount * 100).Abs();
							this.dfSumPercentage.Number = 100 - Sal.TblColumnSum(this, 30, 0, Sys.ROW_MarkDeleted);
							if (this.sCorrection == "Y") 
							{
                                this.dfBalance.Number = this.nAmount - Sal.TblColumnSum(this.tblIntPostings, 36, 0, Sys.ROW_MarkDeleted);
							}
							else
							{
                                this.dfBalance.Number = -(this.nAmount - Sal.TblColumnSum(this.tblIntPostings, 36, 0, Sys.ROW_MarkDeleted));
							}
						}
						else
						{
							this.tblIntPostings_colnPercentage.Number = 0;
						}
					}
					if (this.tblIntPostings_colnCreditAmount.Number != Sys.NUMBER_Null) 
					{
						this.GetAmounts();
					}
					if (this.sCompCurrency == this.sCurrency) 
					{
						this.dfCurrBalance.Number = this.dfBalance.Number;
						if (!(Sal.IsNull(this.tblIntPostings_colnCreditAmount.i_hWndSelf))) 
						{
							Sal.ClearField(this.tblIntPostings_colnCurrencyDebitAmount);
							Sal.ClearField(this.tblIntPostings_colnDebitAmount);
						}
						else
						{
							Sal.ClearField(this.tblIntPostings_colnCurrencyCreditAmount);
							Sal.ClearField(this.tblIntPostings_colnCreditAmount);
							Sal.ClearField(this.tblIntPostings_colnCurrencyAmount);
							Sal.ClearField(this.tblIntPostings_colnAmount);
						}
					}
					// Bug 72736, End
				}
				// Bug 72736, End
			}
			this.RefreshButtonsState();
			Sal.SetFieldEdit(this.tblIntPostings_colnPercentage, true);
			if (this.dfBalance.Number == 0) 
			{
				this.dfSumPercentage.Number = 0;
			}
			e.Return = true;
			return;
			#endregion
		}
			
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblIntPostings_colnCreditAmount_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.hLastWithFocus = this.tblIntPostings_colnCreditAmount.i_hWndSelf;
			this.RefreshButtonsState();
			e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
			
		/// <summary>
		/// PM_DataItemQueryEnabled event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblIntPostings_colnCreditAmount_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (!(Sal.IsNull(this.tblIntPostings_colnDebitAmount))) 
			{
				e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
				return;
			}
			if (this.rbPercentage.Checked) 
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
		private void tblIntPostings_colnAmount_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_SetFocus:
					this.tblIntPostings_colnAmount_OnSAM_SetFocus(sender, e);
					break;
					
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
					this.tblIntPostings_colnAmount_OnPM_DataItemValidate(sender, e);
					break;
			}
			#endregion
		}
			
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblIntPostings_colnAmount_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.hLastWithFocus = this.tblIntPostings_colnAmount.i_hWndSelf;
			this.RefreshButtonsState();
			e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
			
		/// <summary>
		/// PM_DataItemValidate event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblIntPostings_colnAmount_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			// Bug 72736, Begin. Added IF condition
			if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
			{
				if (this.sCorrection == "Y") 
				{
					if (this.tblIntPostings_colnAmount.Number > 0) 
					{
						this.tblIntPostings_colnCreditAmount.Number = -this.tblIntPostings_colnAmount.Number;
						this.tblIntPostings_colnCreditAmount.EditDataItemSetEdited();
						Sal.SendMsg(this.tblIntPostings_colnDebitAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, SalNumber.Null.ToString(0).ToHandle());
						Sal.SendMsg(this.tblIntPostings_colnCreditAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
					}
					else
					{
						this.tblIntPostings_colnDebitAmount.Number = this.tblIntPostings_colnAmount.Number;
						this.tblIntPostings_colnDebitAmount.EditDataItemSetEdited();
						Sal.SendMsg(this.tblIntPostings_colnCreditAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, SalNumber.Null.ToString(0).ToHandle());
						Sal.SendMsg(this.tblIntPostings_colnDebitAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
					}
				}
				else
				{
					if (this.tblIntPostings_colnAmount.Number > 0) 
					{
						this.tblIntPostings_colnDebitAmount.Number = this.tblIntPostings_colnAmount.Number;
						this.tblIntPostings_colnDebitAmount.EditDataItemSetEdited();
						Sal.SendMsg(this.tblIntPostings_colnCreditAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, SalNumber.Null.ToString(0).ToHandle());
						Sal.SendMsg(this.tblIntPostings_colnDebitAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
					}
					// Bug 72736, Begin. Added IF condition.
					else if (this.tblIntPostings_colnAmount.Number == Sys.NUMBER_Null) 
					{
						if (this.sCompCurrency == this.sCurrency) 
						{
							this.tblIntPostings_colnCurrencyCreditAmount.Number = Sys.NUMBER_Null;
							this.tblIntPostings_colnCurrencyDebitAmount.Number = Sys.NUMBER_Null;
							this.tblIntPostings_colnCurrencyAmount.Number = Sys.NUMBER_Null;
						}
						this.tblIntPostings_colnDebitAmount.Number = Sys.NUMBER_Null;
						this.tblIntPostings_colnCreditAmount.Number = Sys.NUMBER_Null;
						this.tblIntPostings_colnPercentage.Number = 0;
						Sal.SendMsg(this.tblIntPostings_colnDebitAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
					}
					// Bug 72736, End.
					else
					{
						this.tblIntPostings_colnCreditAmount.Number = -this.tblIntPostings_colnAmount.Number;
						this.tblIntPostings_colnCreditAmount.EditDataItemSetEdited();
						Sal.SendMsg(this.tblIntPostings_colnDebitAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, SalNumber.Null.ToString(0).ToHandle());
						Sal.SendMsg(this.tblIntPostings_colnCreditAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
					}
				}

				// Bug 72736, Begin
				if (this.tblIntPostings_colnCurrencyCreditAmount.Number != Sys.NUMBER_Null) 
				{
					this.tblIntPostings_colnCurrencyAmount.Number = -1 * this.tblIntPostings_colnCurrencyCreditAmount.Number;
				}
				else
				{
					this.tblIntPostings_colnCurrencyAmount.Number = this.tblIntPostings_colnCurrencyDebitAmount.Number;
				}
				// Bug 72736, End
				if (this.nCurrencyAmount != 0) 
				{
					this.tblIntPostings_colnPercentage.Number = (this.tblIntPostings_colnAmount.Number / this.nCurrencyAmount * 100).Abs();
					this.dfSumPercentage.Number = 100 - Sal.TblColumnSum(this, 30, 0, Sys.ROW_MarkDeleted);
					if (this.sCorrection == "Y") 
					{
                        this.dfCurrBalance.Number = this.nCurrencyAmount - Sal.TblColumnSum(this.tblIntPostings, 33, 0, Sys.ROW_MarkDeleted);
					}
					else
					{
                        this.dfCurrBalance.Number = -(this.nCurrencyAmount - Sal.TblColumnSum(this.tblIntPostings, 33, 0, Sys.ROW_MarkDeleted));
					}
				}
				else
				{
					this.tblIntPostings_colnPercentage.Number = 0;
				}

				if (this.dfBalance.Number == 0) 
				{
					this.dfSumPercentage.Number = 0;
					this.dfCurrBalance.Number = 0;
					this.tblIntPostings_colnPercentage.EditDataItemSetEdited();
				}
			}
			// Bug 72736, End
			e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
			
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void tblIntPostings_colsText_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_SetFocus:
					this.tblIntPostings_colsText_OnSAM_SetFocus(sender, e);
					break;
			}
			#endregion
		}
			
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblIntPostings_colsText_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.hLastWithFocus = this.tblIntPostings_colsText.i_hWndSelf;
			this.RefreshButtonsState();
			e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
		#endregion
			
		#region Window Events
		
        private void tblIntPostings_DataRecordExecuteModifyEvent(object sender, cDataSource.DataRecordExecuteModifyEventArgs e)
        {
            e.Handled = true;
            e.ReturnValue = this.DataRecordExecuteModify(e.hSql);
        }

        private void tblIntPostings_DataRecordExecuteNewEvent(object sender, cDataSource.DataRecordExecuteNewEventArgs e)
        {
            e.Handled = true;
            e.ReturnValue = this.DataRecordExecuteNew(e.hSql);
        }

        private void tblIntPostings_DataRecordFetchEditedUserEvent(object sender, cDataSource.DataRecordFetchEditedUserEventArgs e)
        {
            e.Handled = true;
            SalString lsAttr = e.lsAttr;
            e.ReturnValue = this.DataRecordFetchEditedUser(ref lsAttr);
            e.lsAttr = lsAttr;
        }

        private void tblIntPostings_DataRecordGetDefaultsEvent(object sender, FndReturnEventArgsSalBoolean e)
        {
            e.Handled = true;
            e.ReturnValue = this.DataRecordGetDefaults();
        }

        private void tblIntPostings_EnableDisableProjectActivityIdEvent(object sender, cChildTableFin.cChildTableFinEventArgs e)
        {
            e.Handled = true;
            e.ReturnValue = this.EnableDisableProjectActivityId(e.sCodePartValue);
        }
			
		#endregion
		
		#endregion
	}
}
