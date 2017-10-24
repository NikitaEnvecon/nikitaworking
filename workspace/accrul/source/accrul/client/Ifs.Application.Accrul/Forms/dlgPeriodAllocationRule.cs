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
using System.Collections.Generic;

namespace Ifs.Application.Accrul
{
	
	/// <summary>
	/// </summary>
	/// <param name="pnAllocationId"></param>
	/// <param name="psCompany"></param>
	/// <param name="psSite"></param>
	/// <param name="psCreator"></param>
	/// <param name="pdFromDate"></param>
	/// <param name="pdUntilDate"></param>
	/// <param name="pnTotalAmount"></param>
	/// <param name="psCurrencyCode"></param>
	/// <param name="pOpenState"></param>
	/// <param name="psDistrType"></param>
	/// <param name="pnAllocationIdReturn"></param>
	public partial class dlgPeriodAllocationRule : cDialogBoxFin
	{
		#region Window Parameters
		public SalNumber pnAllocationId;
		public SalString psCompany;
		public SalString psSite;
		public SalString psCreator;
		public SalDateTime pdFromDate;
		public SalDateTime pdUntilDate;
		public SalNumber pnTotalAmount;
		public SalString psCurrencyCode;
		public SalString pOpenState;
		public SalString psDistrType;
		public SalNumber pnAllocationIdReturn;
		#endregion
		
		#region Window Variables
		public SalNumber nAllocationId = 0;
		public SalString sCompany = "";
		public SalString sSite = "";
		public SalString sCreator = "";
		public SalString sCurrencyCode = "";
		public SalString sOpenState = "";
		public SalString sDistrType = "";
		public SalString sJustDistributed = "";
		public SalDateTime dFromDate = SalDateTime.Null;
		public SalDateTime dUntilDate = SalDateTime.Null;
		public SalString lsStatement = "";
		public SalBoolean bOk = false;
		public SalNumber nLinePercent = 0;
		public SalNumber nLineAmount = 0;
		public SalNumber nTotalAmount = 0;
		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		protected dlgPeriodAllocationRule()
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
		public static SalNumber ModalDialog(Control owner, SalNumber pnAllocationId, SalString psCompany, SalString psSite, SalString psCreator, SalDateTime pdFromDate, SalDateTime pdUntilDate, SalNumber pnTotalAmount, SalString psCurrencyCode, SalString pOpenState, SalString psDistrType, ref SalNumber pnAllocationIdReturn)
		{
			dlgPeriodAllocationRule dlg = DialogFactory.CreateInstance<dlgPeriodAllocationRule>();
			dlg.pnAllocationId = pnAllocationId;
			dlg.psCompany = psCompany;
			dlg.psSite = psSite;
			dlg.psCreator = psCreator;
			dlg.pdFromDate = pdFromDate;
			dlg.pdUntilDate = pdUntilDate;
			dlg.pnTotalAmount = pnTotalAmount;
			dlg.psCurrencyCode = psCurrencyCode;
			dlg.pOpenState = pOpenState;
			dlg.psDistrType = psDistrType;
			dlg.pnAllocationIdReturn = pnAllocationIdReturn;
			SalNumber ret = dlg.ShowDialog(owner);
			pnAllocationIdReturn = dlg.pnAllocationIdReturn;
			return ret;
		}
		
		/// <summary>
		/// Returns the object instance associated with the window handle.
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public new static dlgPeriodAllocationRule FromHandle(SalWindowHandle handle)
		{
			return ((dlgPeriodAllocationRule)SalWindow.FromHandle(handle, typeof(dlgPeriodAllocationRule)));
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
				nAllocationId = pnAllocationId;
				sOpenState = pOpenState;
				sCreator = psCreator;
				sSite = psSite;
				sJustDistributed = "FALSE";
				if (nAllocationId == SalNumber.Null || nAllocationId == 0) 
				{
					sCompany = psCompany;
					sSite = psSite;
					sCreator = psCreator;
					sCurrencyCode = psCurrencyCode;
					sDistrType = psDistrType;
					dFromDate = pdFromDate;
					dUntilDate = pdUntilDate;
					nTotalAmount = pnTotalAmount;
					using(SignatureHints hints = SignatureHints.NewContext())
					{
						hints.Add("Period_Allocation_Rule_API.Create_New_Allocation_Head", System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
						if (!(DbPLSQLTransaction(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "Period_Allocation_Rule_API.Create_New_Allocation_Head(\r\n" +
							" 	  :i_hWndFrame.dlgPeriodAllocationRule.nAllocationId,\r\n" +
							"                  :i_hWndFrame.dlgPeriodAllocationRule.sCompany,\r\n" +
							"                  :i_hWndFrame.dlgPeriodAllocationRule.sSite,\r\n" +
							"                  :i_hWndFrame.dlgPeriodAllocationRule.sCreator,\r\n" +
							"                  :i_hWndFrame.dlgPeriodAllocationRule.dFromDate,\r\n" +
							"                  :i_hWndFrame.dlgPeriodAllocationRule.dUntilDate,\r\n" +
							"                  :i_hWndFrame.dlgPeriodAllocationRule.nTotalAmount,\r\n" +
							"                  :i_hWndFrame.dlgPeriodAllocationRule.sCurrencyCode,\r\n" +
							"                  :i_hWndFrame.dlgPeriodAllocationRule.sDistrType)"))) 
						{
							DbTransactionEnd(cSessionManager.c_hSql);
							return false;
						}
					}
				}
				else
				{
					if (sOpenState == "M") 
					{
						GetAllocationStatus();
					}
				}
				if (sOpenState == "Q") 
				{
					Sal.DisableWindow(dfdFromDate);
					Sal.DisableWindow(dfdUntilDate);
					Sal.DisableWindow(cmbDistrType);
					Sal.DisableWindow(tblPeriod_colsYearPeriodDisp);
					Sal.DisableWindow(tblPeriod_colnPercentage);
					Sal.DisableWindow(tblPeriod_colnAmount);
				}
				Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
				SumPercentageAmount();
				// Jeguse Test Begin
				pnAllocationIdReturn = 0;
				// Jeguse Test End
				return true;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nWhatAcc"></param>
		/// <param name="sMethod"></param>
		/// <returns></returns>
		public new SalNumber UserMethod(SalNumber nWhatAcc, SalString sMethod)
		{
			#region Actions
			using (new SalContext(this))
			{
				if (sMethod == "Ok") 
				{
					return UM_Ok(nWhatAcc);
				}
				else if (sMethod == "Cancel") 
				{
					return UM_Cancel(nWhatAcc);
				}
				else if (sMethod == "New") 
				{
					return UM_New(nWhatAcc);
				}
				else if (sMethod == "Remove") 
				{
					return UM_Remove(nWhatAcc);
				}
				else if (sMethod == "Save") 
				{
					return UM_Save(nWhatAcc);
				}
				else if (sMethod == "Distr") 
				{
					return UM_Distr(nWhatAcc);
				}
				return false;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nWhatAcc"></param>
		/// <returns></returns>
		public virtual SalBoolean UM_Ok(SalNumber nWhatAcc)
		{
			#region Actions
			using (new SalContext(this))
			{
				switch (nWhatAcc)
				{
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        if (!Sal.TblAnyRows(tblPeriod, 0, 0))
                        {
                            return false;
                        }
						if (dfnSumAmount.Number != 0) 
						{
							if (dfnTotalAmount.Number != dfnSumAmount.Number) 
							{
								return false;
							}
						}
						return true;
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
						if (sOpenState == "Q") 
						{
							return Sal.EndDialog(this, Ifs.Fnd.ApplicationForms.Var.bReturn);
						}
						using(SignatureHints hints = SignatureHints.NewContext())
						{
							hints.Add("Period_Allocation_Rule_API.Compare_Distribution", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
							if (!(DbPLSQLBlock(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "Period_Allocation_Rule_API.Compare_Distribution(\r\n" +
								" 	  :i_hWndFrame.dlgPeriodAllocationRule.dfnTotalAmount,\r\n" +
								"                  :i_hWndFrame.dlgPeriodAllocationRule.nAllocationId)"))) 
							{
								return false;
							}
						}
						pnAllocationIdReturn = nAllocationId;
						if (Sal.SendMsg(tblPeriod, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0)) 
						{
							switch (DataSourceInquireSave())
							{
								case Sys.IDCANCEL:
									return false;
								
								case Sys.IDYES:
									if (Sal.SendMsg(tblPeriod, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0)) 
									{
										return Sal.EndDialog(this, 1);
									}
									return false;
								
								case Sys.IDNO:
									return Sal.EndDialog(this, 0);
							}
						}
						else
						{
							return Sal.EndDialog(this, Ifs.Fnd.ApplicationForms.Var.bReturn);
						}
						break;
				}
			}

			return false;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nWhatAcc"></param>
		/// <returns></returns>
		public virtual SalBoolean UM_Distr(SalNumber nWhatAcc)
		{
			#region Actions
			using (new SalContext(this))
			{
				switch (nWhatAcc)
				{
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        if ((sOpenState == "Q") || (this.tblPeriod.DataSourceIsDirty(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire) == 1))  
						{
							return false;
						}
						return true;
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
						if (DistributePeriods()) 
						{
							Sal.SendMsg(i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceRefresh, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
							SumPercentageAmount();
							return true;
						}
						else
						{
							return false;
						}
						break;
				}
			}

			return false;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nWhatAcc"></param>
		/// <returns></returns>
		public virtual SalBoolean UM_Cancel(SalNumber nWhatAcc)
		{
			#region Actions
			using (new SalContext(this))
			{
				switch (nWhatAcc)
				{
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
						if (sOpenState == "Q") 
						{
							return false;
						}
						return true;
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
						// Bug 80401 Begin
						if (pnAllocationIdReturn != 0) 
						{
							using(SignatureHints hints = SignatureHints.NewContext())
							{
								hints.Add("Period_Allocation_Rule_API.Compare_Distribution", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
								if (!(DbPLSQLBlock(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "Period_Allocation_Rule_API.Compare_Distribution(\r\n" +
									" 	  :i_hWndFrame.dlgPeriodAllocationRule.dfnTotalAmount,\r\n" +
									"                  :i_hWndFrame.dlgPeriodAllocationRule.nAllocationId)"))) 
								{
									return false;
								}
							}
							return Sal.EndDialog(this, Ifs.Fnd.ApplicationForms.Var.bReturn);
						}
						// Bug 80401 End
						pnAllocationIdReturn = 0;
						bOk = DbTransactionClear(cSessionManager.c_hSql);
                        if (nAllocationId != 0)
                        {
                            DbPLSQLTransaction(cSessionManager.c_hSql, 
                                @"&AO.Period_Allocation_Rule_API.Exist_Any_Line( :i_hWndFrame.dlgPeriodAllocationRule.nAllocationId INOUT)");
                        }
						return Sal.EndDialog(this, Ifs.Fnd.ApplicationForms.Var.bReturn);
				}
			}

			return false;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nWhatAcc"></param>
		/// <returns></returns>
		public virtual SalBoolean UM_New(SalNumber nWhatAcc)
		{
			#region Actions
			using (new SalContext(this))
			{
				switch (nWhatAcc)
				{
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
						if (sOpenState == "Q") 
						{
							return false;
						}
						return Sal.SendMsg(tblPeriod, Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0);
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
						return Sal.SendMsg(tblPeriod, Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
				}
			}

			return false;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nWhatAcc"></param>
		/// <returns></returns>
		public virtual SalBoolean UM_Remove(SalNumber nWhatAcc)
		{
			#region Actions
			using (new SalContext(this))
			{
				switch (nWhatAcc)
				{
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
						if (sOpenState == "Q") 
						{
							return false;
						}
						return Sal.SendMsg(tblPeriod, Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0);
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
						return Sal.SendMsg(tblPeriod, Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
				}
			}

			return false;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nWhatAcc"></param>
		/// <returns></returns>
		public virtual SalBoolean UM_Save(SalNumber nWhatAcc)
		{
			#region Actions
			using (new SalContext(this))
			{
				switch (nWhatAcc)
				{
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
						if (sOpenState == "Q") 
						{
							bOk = DbTransactionClear(cSessionManager.c_hSql);
							return false;
						}
						if (sJustDistributed == "TRUE") 
						{
							return true;
						}
						if (dfnSumAmount.Number != 0) 
						{
							if (dfnTotalAmount.Number != dfnSumAmount.Number) 
							{
								return false;
							}
						}
						return Sal.SendMsg(tblPeriod, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0);
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
						Ifs.Fnd.ApplicationForms.Var.bReturn = true;
						sJustDistributed = "FALSE";
						// Bug 80401 Begin
						pnAllocationIdReturn = nAllocationId;
						// Bug 80401 End
						pbSave.MethodInvestigateState();
						return Sal.SendMsg(tblPeriod, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
				}
			}

			return false;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean DistributePeriods()
		{
			#region Actions
            SalSqlHandle hTempSql;
			using (new SalContext(this))
			{
				Sal.WaitCursor(true);
                // Bug 76042,Begin.
				using(SignatureHints hints = SignatureHints.NewContext())
				{
					hints.Add("Period_Allocation_Rule_API.Create_New_Allocation_Lines", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                    bOk = DbPLSQLBlock(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "Period_Allocation_Rule_API.Create_New_Allocation_Lines(\r\n" +
						"                       :i_hWndFrame.dlgPeriodAllocationRule.dfnAllocationId,\r\n" +
						"                       :i_hWndFrame.dlgPeriodAllocationRule.dfsDistrTypeDb,\r\n" +
						"                       :i_hWndFrame.dlgPeriodAllocationRule.dfdFromDate,\r\n" +
						"                       :i_hWndFrame.dlgPeriodAllocationRule.dfdUntilDate,\r\n" +
						"                       :i_hWndFrame.dlgPeriodAllocationRule.dfnTotalAmount,\r\n" +
						"                       :i_hWndFrame.dlgPeriodAllocationRule.dfsCurrencyCode)");
				}
				// Bug 76042,End.
				Sal.WaitCursor(false);
				if (bOk) 
				{
					sJustDistributed = "TRUE";
					pbOk.MethodInvestigateState();
					pbSave.MethodInvestigateState();
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
		public virtual SalNumber EncodePeriodDistribution()
		{
			#region Actions
			using (new SalContext(this))
			{
				Sal.WaitCursor(true);
				using(SignatureHints hints = SignatureHints.NewContext())
				{
					hints.Add("Period_Alloc_Per_Distr_API.Encode", System.Data.ParameterDirection.Input);
					if (!(DbPLSQLBlock(cSessionManager.c_hSql, ":i_hWndFrame.dlgPeriodAllocationRule.dfsDistrTypeDb :=\r\n" +
						"                  &AO.Period_Alloc_Per_Distr_API.Encode(:i_hWndFrame.dlgPeriodAllocationRule.cmbDistrType)"))) 
					{
						return false;
					}
				}
				Sal.WaitCursor(false);
				return true;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber GetAllocationStatus()
		{
			#region Actions
			using (new SalContext(this))
			{
				Sal.WaitCursor(true);
				using(SignatureHints hints = SignatureHints.NewContext())
				{
					hints.Add("Period_Allocation_Rule_API.Get_Open_Status", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
					if (!(DbPLSQLBlock(cSessionManager.c_hSql, ":i_hWndFrame.dlgPeriodAllocationRule.sOpenState :=\r\n" +
						"                  &AO.Period_Allocation_Rule_API.Get_Open_Status(:i_hWndFrame.dlgPeriodAllocationRule.nAllocationId,:i_hWndFrame.dlgPeriodAllocationRule.sCreator)"))) 
					{
						return false;
					}
				}
				Sal.WaitCursor(false);
				return true;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber SumPercentageAmount()
		{
			#region Actions
			using (new SalContext(this))
			{
				if (Sal.TblAnyRows(tblPeriod, 0, 0)) 
				{
					dfnSumPercentage.Number = Sal.TblColumnSum(tblPeriod, 8, 0, Sys.ROW_MarkDeleted);
					dfnSumAmount.Number = Sal.TblColumnSum(tblPeriod, 9, 0, Sys.ROW_MarkDeleted);
				}
				else
				{
					dfnSumPercentage.Number = 0;
					dfnSumAmount.Number = 0;
				}
				return true;
			}
			#endregion
		}

        public new SalBoolean SetWindowTitle()
        {
            #region Local Variables
            SalString sWinTitle = "";
            #endregion

            #region Actions
            Sal.GetWindowText(this, ref sWinTitle, 200);
            return Sal.SetWindowText(this, psCompany + " - " + sWinTitle);
            #endregion
        }

		#endregion
		
		#region Window Actions
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void dlgPeriodAllocationRule_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceIsDirty:
					e.Handled = true;
					e.Return = Sal.SendMsg(this.tblPeriod, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceIsDirty, Sys.wParam, Sys.lParam);
					return;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave:
					this.dlgPeriodAllocationRule_OnPM_DataSourceSave(sender, e);
					break;
				
				// Bug 80401 Begin
				
				case Sys.SAM_Close:
					this.dlgPeriodAllocationRule_OnSAM_Close(sender, e);
					break;
				
				// Bug 80401 End
			}
			#endregion
		}
		
		/// <summary>
		/// PM_DataSourceSave event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dlgPeriodAllocationRule_OnPM_DataSourceSave(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (this.dfnTotalAmount.Number != this.dfnSumAmount.Number) 
			{
				e.Return = true;
				return;
			}
			e.Return = Sal.SendMsg(this.tblPeriod, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
		
		/// <summary>
		/// SAM_Close event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dlgPeriodAllocationRule_OnSAM_Close(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (this.pnAllocationIdReturn != 0) 
			{
				using(SignatureHints hints = SignatureHints.NewContext())
				{
					hints.Add("Period_Allocation_Rule_API.Compare_Distribution", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
					if (!(this.DbPLSQLBlock(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "Period_Allocation_Rule_API.Compare_Distribution(\r\n" +
						" 	  :i_hWndFrame.dlgPeriodAllocationRule.dfnTotalAmount,\r\n" +
						"                  :i_hWndFrame.dlgPeriodAllocationRule.nAllocationId)"))) 
					{
						e.Return = false;
						return;
					}
				}
				e.Return = Sal.EndDialog(this, Ifs.Fnd.ApplicationForms.Var.bReturn);
				return;
			}
			this.pnAllocationIdReturn = 0;
			this.bOk = this.DbTransactionClear(cSessionManager.c_hSql);
            if (nAllocationId != 0)
            {
                DbPLSQLTransaction(cSessionManager.c_hSql,
                    @"&AO.Period_Allocation_Rule_API.Exist_Any_Line( :i_hWndFrame.dlgPeriodAllocationRule.nAllocationId INOUT)");
            }
            e.Return = Sal.EndDialog(this, Ifs.Fnd.ApplicationForms.Var.bReturn);
			return;
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void cmbDistrType_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Click:
					this.cmbDistrType_OnSAM_Click(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_Click event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cmbDistrType_OnSAM_Click(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			Sal.SendClassMessage(Sys.SAM_Click, Sys.wParam, Sys.lParam);
			this.EncodePeriodDistribution();
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void tblPeriod_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_RowHeaderDoubleClick:
					this.tblPeriod_OnSAM_RowHeaderDoubleClick(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew:
					this.tblPeriod_OnPM_DataRecordNew(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove:
					this.tblPeriod_OnPM_DataRecordRemove(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_RowHeaderDoubleClick event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblPeriod_OnSAM_RowHeaderDoubleClick(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			Sal.MessageBeep(0);
			e.Return = false;
			return;
			#endregion
		}
		
		/// <summary>
		/// PM_DataRecordNew event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblPeriod_OnPM_DataRecordNew(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire) 
			{
                // Code has been commented to disable a new record being created when + is clicked.
                return;
			}
			e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
		
		/// <summary>
		/// PM_DataRecordRemove event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblPeriod_OnPM_DataRecordRemove(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire) 
			{
				if (this.sOpenState == "Q") 
				{
					e.Return = false;
					return;
				}
				e.Return = true;
				return;
			}
			Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove, Sys.wParam, Sys.lParam);
			this.SumPercentageAmount();
			e.Return = true;
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

        public override SalBoolean vrtSetWindowTitle()
        {
            return this.SetWindowTitle();
        }
		#endregion

        #region ChildTable-tblPeriod

        #region Methods

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber CalcPercentFromAmount()
        {
            #region Actions
          
            this.nLinePercent = tblPeriod_colnPercentage.Number;
            this.nLineAmount = tblPeriod_colnAmount.Number;
            this.nTotalAmount = this.dfnTotalAmount.Number;
            Sal.WaitCursor(true);
            IDictionary<string, string> namedBindvariables = new Dictionary<string, string>();
            namedBindvariables.Add("LinePercent", this.QualifiedVarBindName("nLinePercent"));
            namedBindvariables.Add("Company", this.dfsCompany.QualifiedBindName);
            namedBindvariables.Add("TotalAmount", this.QualifiedVarBindName("nTotalAmount"));
            namedBindvariables.Add("LineAmount", this.QualifiedVarBindName("nLineAmount"));

            this.lsStatement = @"&AO.Period_Allocation_Rule_API.Calc_Percent_From_Amount(
                                                                    {LinePercent} INOUT,
                                                                    {Company} IN,
                                                                    {TotalAmount} IN,
                                                                    {LineAmount} IN); ";
            this.bOk = DbPLSQLBlock(this.lsStatement, namedBindvariables);
            Sal.WaitCursor(false);
            tblPeriod_colnPercentage.Number = this.nLinePercent;
            tblPeriod_colnPercentage.EditDataItemSetEdited();
            return true;
            
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber CalcAmountFromPercent()
        {
            #region Actions
            using (new SalContext(this))
         
            this.nLinePercent = tblPeriod_colnPercentage.Number;
            this.nLineAmount = tblPeriod_colnAmount.Number;
            this.nTotalAmount = this.dfnTotalAmount.Number;
            Sal.WaitCursor(true);
            IDictionary<string, string> namedBindvariables = new Dictionary<string, string>();
            namedBindvariables.Add("LineAmount",this.QualifiedVarBindName("nLineAmount"));
            namedBindvariables.Add("Company", this.dfsCompany.QualifiedBindName);
            namedBindvariables.Add("TotalAmount", this.QualifiedVarBindName("nTotalAmount"));
            namedBindvariables.Add("LinePercent", this.QualifiedVarBindName("nLinePercent"));

            this.lsStatement = @"&AO.Period_Allocation_Rule_API.Calc_Amount_From_Percent(
                                                                    {LineAmount} INOUT,
                                                                    {Company} IN,
                                                                    {TotalAmount} IN,
                                                                    {LinePercent} IN); ";
            this.bOk = DbPLSQLBlock(this.lsStatement,namedBindvariables);
            Sal.WaitCursor(false);
            tblPeriod_colnAmount.Number = this.nLineAmount;
            tblPeriod_colnAmount.EditDataItemSetEdited();
            return true;
        
            #endregion
        }
        #endregion

        #region Window Actions

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblPeriod_colnPercentage_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblPeriod_colnPercentage_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblPeriod_colnPercentage_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam) == Sys.VALIDATE_Cancel)
            {
                e.Return = Sys.VALIDATE_Cancel;
                return;
            }
            this.CalcAmountFromPercent();
            this.SumPercentageAmount();
            this.pbOk.MethodInvestigateState();
            if (this.sJustDistributed == "FALSE")
            {
                this.pbSave.MethodInvestigateState();
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
        private void tblPeriod_colnAmount_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblPeriod_colnAmount_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblPeriod_colnAmount_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam) == Sys.VALIDATE_Cancel)
            {
                e.Return = Sys.VALIDATE_Cancel;
                return;
            }
            this.tblPeriod_colnAmount.Number = this.tblPeriod_colnAmount.Number.ToString(this.dfnCurrRound.Number).ToNumber();
            this.CalcPercentFromAmount();
            this.SumPercentageAmount();
            this.pbOk.MethodInvestigateState();
            if (this.sJustDistributed == "FALSE")
            {
                this.pbSave.MethodInvestigateState();
            }
            e.Return = Sys.VALIDATE_Ok;
            return;
            #endregion
        }
        #endregion
        
        #endregion

        
	}
}
