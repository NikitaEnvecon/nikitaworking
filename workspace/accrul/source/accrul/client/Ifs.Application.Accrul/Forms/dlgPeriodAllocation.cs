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
// 2014-01-22  CHARLK    PBFI-4425.MOdify Method tblPeriod_OnSAM_FetchRowDone and New().
// 2014-01-27  MEALLK    PBFI-4425.MOdified Method tblPeriod_OnSAM_FetchRowDone.
// 2014-02-20  MEALLK    PBFI-5516, added pbSave.MethodInvestigateState() to tblPeriod_OnPM_DataSourceSave.
// 2014-04-23  Umdolk    PBFI-5988, Adjust the rounding difference to the last row.
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
	/// <param name="sPCompany"></param>
	/// <param name="nPAccountingPeriod"></param>
	public partial class dlgPeriodAllocation : cDialogBoxFin
	{
		#region Window Parameters
		public SalString sPCompany;
		public SalNumber nPAccountingPeriod;
		#endregion
		
		#region Window Variables
		public SalWindowHandle hWndLovField = SalWindowHandle.Null;
		public SalNumber nFromPeriod = 0;
		public SalNumber nUntilPeriod = 0;
		public SalNumber nRowNo = 0;
		public SalNumber nFromYear = 0;
		public SalNumber nUntilYear = 0;
		public SalNumber nSplitContext = 0;
		public SalNumber nYear = 0;
		public SalNumber nPeriod = 0;
		public SalString lsReturn = "";
		public SalString sFormName = "";
		public SalString sUserId = "";
		public SalString sDefUserGroup = "";
		public SalString sDefVouType = "";
		public SalString sAllocUserGroup = "";
		public SalString sAllocVouType = "";
		public SalArray<SalString> sRecords = new SalArray<SalString>();
		public SalArray<SalString> sUnits = new SalArray<SalString>();
		public SalNumber nAllocationId = 0;
		public SalNumber nCurrencyRate = 0;
		public SalNumber nCrrRow = 0;
		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		protected dlgPeriodAllocation()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
            // TODO: Temporary Fix for truncation in the number when a space is given in the Mask (9999 99).
            this.dfnPeriod.MaxLength = 7;
		}
		#endregion
		
		#region System Methods/Properties
		
		/// <summary>
		/// Shows the modal dialog.
		/// </summary>
		/// <param name="owner"></param>
		/// <returns></returns>
		public static SalNumber ModalDialog(Control owner, SalString sPCompany, SalNumber nPAccountingPeriod)
		{
			dlgPeriodAllocation dlg = DialogFactory.CreateInstance<dlgPeriodAllocation>();
			dlg.sPCompany = sPCompany;
			dlg.nPAccountingPeriod = nPAccountingPeriod;
			SalNumber ret = dlg.ShowDialog(owner);
			return ret;
		}
		
		/// <summary>
		/// Returns the object instance associated with the window handle.
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public new static dlgPeriodAllocation FromHandle(SalWindowHandle handle)
		{
			return ((dlgPeriodAllocation)SalWindow.FromHandle(handle, typeof(dlgPeriodAllocation)));
		}
		#endregion
		
		#region Methods
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public new SalBoolean FrameStartupUser()
		{
			#region Local Variables
			SalNumber nRecords = 0;
			SalNumber nFetch = 0;
			SalString lsStmt = "";
			SalString lsStmt2 = "";
			SalString sDeclare = "";
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				nRecords = Ifs.Fnd.ApplicationForms.Var.DataTransfer.RecCountGet();
				if (nRecords > 0) 
				{
					InitFromTransferedData();
					cmbRowNo.RecordSelectionListSetSelect(0);
					Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();
				}
				// Get until and from period
				sFormName = ":i_hWndFrame." + Ifs.Fnd.ApplicationForms.Int.QualifiedItemNameGet(i_hWndSelf) + ".";
				nRowNo = SalString.FromHandle(cmbRowNo.EditDataItemValueGet()).ToNumber();
				sDeclare = " DECLARE FROM_YEAR_ NUMBER; UNTIL_YEAR_ NUMBER; ";
				lsStmt = "SELECT min(alloc_year), max(alloc_year)\r\n" +
				"                        INTO FROM_YEAR_, UNTIL_YEAR_\r\n" +
				"                        FROM " + cSessionManager.c_sDbPrefix + "PERIOD_ALLOCATION\r\n" +
				"                        WHERE company =" + sFormName + "dfsCompany\r\n" +
				"                          AND voucher_type =" + sFormName + "dfsVoucherType\r\n" +
				"                          AND voucher_no =" + sFormName + "dfnVoucherNo\r\n" +
				"                          AND accounting_year =" + sFormName + "dfnAccountingYear\r\n" +
				"                          AND row_no =" + sFormName + "nRowNo;";
				lsStmt = lsStmt + sFormName + "nFromYear := FROM_YEAR_;";
				lsStmt = lsStmt + sFormName + "nUntilYear := UNTIL_YEAR_;";
				lsStmt = lsStmt + "SELECT min(alloc_period)\r\n" +
				"                        INTO " + sFormName + "nFromPeriod\r\n" +
				"                        FROM " + cSessionManager.c_sDbPrefix + "PERIOD_ALLOCATION\r\n" +
				"                        WHERE company =" + sFormName + "dfsCompany\r\n" +
				"                          AND voucher_type =" + sFormName + "dfsVoucherType\r\n" +
				"                          AND voucher_no =" + sFormName + "dfnVoucherNo\r\n" +
				"                          AND accounting_year =" + sFormName + "dfnAccountingYear\r\n" +
				"                          AND row_no =" + sFormName + "nRowNo\r\n" +
				"	          AND alloc_year = FROM_YEAR_;";
				lsStmt = lsStmt + "SELECT max(alloc_period)\r\n" +
				"                        INTO " + sFormName + "nUntilPeriod\r\n" +
				"                        FROM " + cSessionManager.c_sDbPrefix + "PERIOD_ALLOCATION\r\n" +
				"                        WHERE company =" + sFormName + "dfsCompany\r\n" +
				"                          AND voucher_type =" + sFormName + "dfsVoucherType\r\n" +
				"                          AND voucher_no =" + sFormName + "dfnVoucherNo\r\n" +
				"                          AND accounting_year =" + sFormName + "dfnAccountingYear\r\n" +
				"                          AND row_no =" + sFormName + "nRowNo\r\n" +
				"	          AND alloc_year = UNTIL_YEAR_;";
				if (!(DbPLSQLBlock(cSessionManager.c_hSql, sDeclare + " BEGIN " + lsStmt + " END;"))) 
				{
					return false;
				}
				if ((nFromYear != SalNumber.Null) && (nFromPeriod != SalNumber.Null) && (nUntilYear != SalNumber.Null) && (nUntilPeriod != SalNumber.Null)) 
				{
					dfnFromYear.Number = nFromYear;
					dfnUntilYear.Number = nUntilYear;
					dfnFromPeriod.Number = nFromPeriod;
					dfnUntilPeriod.Number = nUntilPeriod;
					lsStmt2 = "SELECT distinct user_group, alloc_vou_type\r\n" +
					"                        INTO " + sFormName + "sAllocUserGroup,\r\n		  " + sFormName + "sAllocVouType\r\n" +
					"                        FROM " + cSessionManager.c_sDbPrefix + "PERIOD_ALLOCATION\r\n" +
					"                        WHERE company =" + sFormName + "dfsCompany\r\n" +
					"                          AND voucher_type =" + sFormName + "dfsVoucherType\r\n" +
					"                          AND voucher_no =" + sFormName + "dfnVoucherNo\r\n" +
					"                          AND accounting_year =" + sFormName + "dfnAccountingYear\r\n" +
					"                          AND row_no =" + sFormName + "nRowNo";
					if (!(DbPrepareAndExecute(cSessionManager.c_hSql, lsStmt2))) 
					{
						return false;
					}
					else
					{
						DbFetchNext(cSessionManager.c_hSql, ref nFetch);
						dfsUserGroup.Text = sAllocUserGroup;
						dfsAllocVouType.Text = sAllocVouType;
					}
				}
				dfnPeriod.Number = (dfnAccountingYear.Number * 100) + nPAccountingPeriod;
				if (!(Sal.IsNull(dfnUntilYear) || Sal.IsNull(dfnUntilPeriod) || Sal.IsNull(dfnFromYear) || Sal.IsNull(dfnFromPeriod))) 
				{
					Sal.DisableWindow(dfnFromYear);
					Sal.DisableWindow(dfnUntilYear);
					Sal.DisableWindow(dfnFromPeriod);
					Sal.DisableWindow(dfnUntilPeriod);
					Sal.DisableWindow(dfsUserGroup);
					Sal.DisableWindow(dfsAllocVouType);
				}
				else
				{
					SetAllocUserGrpVouType();
				}
				// ! Bug 69803 Start
				GetAllocationId();
				if (nAllocationId != SalNumber.Null && nAllocationId != 0) 
				{
					Sal.DisableWindow(dfnFromYear);
					Sal.DisableWindow(dfnUntilYear);
					Sal.DisableWindow(dfnFromPeriod);
					Sal.DisableWindow(dfnUntilPeriod);
					// Call SalDisableWindow( dfsUserGroup )
					// Call SalDisableWindow( dfsAllocVouType )
					Sal.DisableWindow(cbDivide);
					Sal.DisableWindow(tblPeriod_colnAllocPercent);
					Sal.DisableWindow(tblPeriod_colnAllocAmount);
					Sal.EnableWindow(dfsUserGroup);
					Sal.EnableWindow(dfsAllocVouType);
				}
				// ! Bug 69803 End
				Sal.SetFocus(dfnFromYear);
				if (nRecords > 0) 
				{
					return false;
				}
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
				else if (sMethod == "List") 
				{
					return UM_List(nWhatAcc);
				}
				return false;
			}
			#endregion
		}
		// Until this section come from foundation1
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
						return Sal.TblColumnSum(tblPeriod, 10, 0, 0) > 0;
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
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
		public virtual SalBoolean UM_Cancel(SalNumber nWhatAcc)
		{
			#region Actions
			using (new SalContext(this))
			{
				switch (nWhatAcc)
				{
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
						// ! Bug 69803 Start
						if (nAllocationId != SalNumber.Null && nAllocationId != 0) 
						{
							return false;
						}
						// ! Bug 69803 End
						return true;
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
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
				nFromPeriod = dfnFromYear.Number * 100 + dfnFromPeriod.Number;
				nUntilPeriod = dfnUntilYear.Number * 100 + dfnUntilPeriod.Number;
				switch (nWhatAcc)
				{
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
						// ! Bug 69803 Start
						if (nAllocationId != SalNumber.Null && nAllocationId != 0) 
						{
							return false;
						}
						// ! Bug 69803 End
						if (dfnFromYear.Number == Sys.NUMBER_Null || dfnFromPeriod.Number == Sys.NUMBER_Null || (dfsPartyType.Text == "SUPPLIER" && !(Sal.IsNull(dfsInvAccRowId)))) 
						{
							return false;
						}
						if (Sal.IsNull(dfsUserGroup) || Sal.IsNull(dfsAllocVouType)) 
						{
							return false;
						}
						if (nUntilPeriod >= nFromPeriod) 
						{
							return true;
						}
						return false;
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
						// Bug 71922, Begin
						if (!(ValidateVoucherType())) 
						{
							return false;
						}
						else
						{
							if (!(UpdAllocUserGrpVouType())) 
							{
								return false;
							}
						}
						// Bug 71922, End
						return this.New();
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
						// ! Bug 69803 Start
						if (nAllocationId != SalNumber.Null && nAllocationId != 0) 
						{
							return false;
						}
						// ! Bug 69803 End
						if (dfsPartyType.Text == "SUPPLIER" && !(Sal.IsNull(dfsInvAccRowId))) 
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
		public virtual SalBoolean UM_List(SalNumber nWhatAcc)
		{
			#region Actions
			using (new SalContext(this))
			{
				switch (nWhatAcc)
				{
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
						if (hWndLovField != SalWindowHandle.Null) 
						{
							return Sal.SendMsg(hWndLovField, Ifs.Fnd.ApplicationForms.Const.PM_DataItemLov, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0);
						}
						return false;
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
						if (hWndLovField != SalWindowHandle.Null) 
						{
							return Sal.SendMsg(hWndLovField, Ifs.Fnd.ApplicationForms.Const.PM_DataItemLov, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
						}
						return false;
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_GetType:
						return Ifs.Fnd.ApplicationForms.Const.CHILDTYPE_Any;
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
						if (dfsPartyType.Text == "SUPPLIER" && !(Sal.IsNull(dfsInvAccRowId))) 
						{
							return false;
						}
						return Sal.SendMsg(tblPeriod, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0);
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
						Ifs.Fnd.ApplicationForms.Var.bReturn = true;
						return Sal.SendMsg(tblPeriod, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
				}
			}

			return false;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nPYear"></param>
		/// <param name="nPPeriod"></param>
		/// <returns></returns>
		public virtual SalBoolean Validate_Period(SalNumber nPYear, SalNumber nPPeriod)
		{
			#region Actions
			using (new SalContext(this))
			{
				nYear = nPYear;
				nPeriod = nPPeriod;
				using(SignatureHints hints = SignatureHints.NewContext())
				{
					hints.Add("Accounting_Period_API.Is_Period_Open", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
					if (!(DbPLSQLBlock(cSessionManager.c_hSql, sFormName + "lsReturn := " + cSessionManager.c_sDbPrefix + "Accounting_Period_API.Is_Period_Open(" + sFormName + "dfsCompany," + sFormName + "nYear," + sFormName + "nPeriod )"))) 
					{
						// Don't translate this message, this message only for programmer not user
						Ifs.Fnd.ApplicationForms.Int.AlertBox("Design time error in function Period_Exist !", Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
						return false;
					}
				}
				if (lsReturn == "TRUE") 
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
		/// Set default User Group and Voucher Type for PA.
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber SetAllocUserGrpVouType()
		{
			#region Local Variables
			SalString lsStmt = "";
			SalString sDeclare = "";
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				if (Sal.IsNull(dfsUserGroup)) 
				{
					sUserId = Ifs.Fnd.ApplicationForms.Int.FndUser();
					sDeclare = " DECLARE user_group_ VARCHAR2(30); ";
					lsStmt = " user_group_ := &AO.User_Group_Member_Finance_API.Get_Default_Group(" + sFormName + "dfsCompany, " + sFormName + "sUserId);";
					lsStmt = lsStmt + sFormName + "sDefUserGroup := user_group_;";
					lsStmt = lsStmt + "&AO.Voucher_Type_User_Group_API.Get_Default_Voucher_Type(" + sFormName + "sDefVouType," + sFormName + "dfsCompany,\r\n" +
					"								               user_group_," + sFormName + "dfnFromYear," + " 'X' );";
                    using (SignatureHints hints = SignatureHints.NewContext())
                    {
                       hints.Add("User_Group_Member_Finance_API.Get_Default_Group", System.Data.ParameterDirection.Input,System.Data.ParameterDirection.Input);
                       hints.Add("Voucher_Type_User_Group_API.Get_Default_Voucher_Type", System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input,System.Data.ParameterDirection.Input);
					if (DbPLSQLBlock(cSessionManager.c_hSql, sDeclare + " BEGIN " + lsStmt + " END;")) 
					{
						dfsUserGroup.Text = sDefUserGroup;
					}
                    }
				}
				else
				{
					using(SignatureHints hints = SignatureHints.NewContext())
					{
						hints.Add("Voucher_Type_User_Group_API.Get_Default_Voucher_Type", System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
						DbPLSQLBlock(cSessionManager.c_hSql, "&AO.Voucher_Type_User_Group_API.Get_Default_Voucher_Type(" + sFormName + "sDefVouType," + sFormName + "dfsCompany," + sFormName + "dfsUserGroup," + sFormName + "dfnFromYear," + " 'X' )");
					}
				}
				dfsAllocVouType.Text = sDefVouType;
			}

			return 0;
			#endregion
		}
		// ! Bug 69803 Start
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber GetAllocationId()
		{
			#region Actions
			using (new SalContext(this))
			{
				Sal.WaitCursor(true);
				using(SignatureHints hints = SignatureHints.NewContext())
				{
					hints.Add("Voucher_Row_API.Get_Allocation_Id", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
					if (!(DbPLSQLBlock(cSessionManager.c_hSql, ":i_hWndFrame.dlgPeriodAllocation.nAllocationId :=\r\n" +
						"                  &AO.Voucher_Row_API.Get_Allocation_Id(:i_hWndFrame.dlgPeriodAllocation.dfsCompany,\r\n" +
						"                                                                                      :i_hWndFrame.dlgPeriodAllocation.dfsVoucherType,\r\n" +
						"                                                                                      :i_hWndFrame.dlgPeriodAllocation.dfnAccountingYear,\r\n" +
						"                                                                                      :i_hWndFrame.dlgPeriodAllocation.dfnVoucherNo,\r\n" +
						"                                                                                      :i_hWndFrame.dlgPeriodAllocation.nRowNo)"))) 
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
		/// Set default User Group and Voucher Type for PA.
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean UpdAllocUserGrpVouType()
		{
			#region Local Variables
			SalString lsStmt = "";
			SalString sDeclare = "";
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				using(SignatureHints hints = SignatureHints.NewContext())
				{
					hints.Add("Period_Allocation_API.Update_Alloc_Vou_Type", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
					return DbPLSQLTransaction(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "Period_Allocation_API.Update_Alloc_Vou_Type(\r\n" +
						"                                                                                      :i_hWndFrame.dlgPeriodAllocation.dfsCompany,\r\n" +
						"                                                                                      :i_hWndFrame.dlgPeriodAllocation.dfsVoucherType,\r\n" +
						"                                                                                      :i_hWndFrame.dlgPeriodAllocation.dfnVoucherNo,\r\n" +
						"                                                                                      :i_hWndFrame.dlgPeriodAllocation.nRowNo,\r\n" +
						"                                                                                      :i_hWndFrame.dlgPeriodAllocation.dfnAccountingYear,\r\n" +
						"                                                                                      :i_hWndFrame.dlgPeriodAllocation.dfsUserGroup,\r\n" +
						"                                                                                      :i_hWndFrame.dlgPeriodAllocation.dfsAllocVouType)");
				}
			}
			#endregion
		}
		// ! Bug 69803 End
		// Bug 71922, Begin
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean ValidateVoucherType()
		{
			#region Actions
			using (new SalContext(this))
			{
				using(SignatureHints hints = SignatureHints.NewContext())
				{
					hints.Add("Voucher_Type_API.Validate_Vou_Type_Vou_Grp", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
					if (DbPLSQLBlock(cSessionManager.c_hSql, "&AO.Voucher_Type_API.Validate_Vou_Type_Vou_Grp(" + sFormName + "dfsCompany," + sFormName + "dfsAllocVouType," + " 'X' )")) 
					{
						using(SignatureHints hints1 = SignatureHints.NewContext())
						{
							hints1.Add("Voucher_Type_API.Validate_Vou_Type_All_Gen", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
							if (DbPLSQLBlock(cSessionManager.c_hSql, "&AO.Voucher_Type_API.Validate_Vou_Type_All_Gen(" + sFormName + "dfsCompany," + sFormName + "dfsAllocVouType )")) 
							{
								using(SignatureHints hints2 = SignatureHints.NewContext())
								{
									hints2.Add("Voucher_Type_User_Group_API.Validate_Voucher_Type", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
									return DbPLSQLBlock(cSessionManager.c_hSql, "&AO.Voucher_Type_User_Group_API.Validate_Voucher_Type(" + sFormName + "dfsCompany," + sFormName + "dfsAllocVouType," + " 'X' ," + sFormName + "dfnFromYear," + sFormName + "dfsUserGroup )");
								}
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
						}
			}
			#endregion
		}
		// Bug 71922, End
		// Bug 93512, Begin
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean ValidateUserGroup()
		{
			#region Actions
			using (new SalContext(this))
			{
				using(SignatureHints hints = SignatureHints.NewContext())
				{
					hints.Add("USER_GROUP_MEMBER_FINANCE_API.Check_Valid_User", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
					if (DbPLSQLBlock(cSessionManager.c_hSql, "&AO.USER_GROUP_MEMBER_FINANCE_API.Check_Valid_User(:i_hWndFrame.dlgPeriodAllocation.dfsCompany,:i_hWndFrame.dlgPeriodAllocation.dfsUserGroup )")) 
					{
						return false;
					}
					else
					{
						return true;
					}
				}
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
		private void dlgPeriodAllocation_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Create:
					this.dlgPeriodAllocation_OnSAM_Create(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate:
					this.dlgPeriodAllocation_OnPM_DataSourcePopulate(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceIsDirty:
					e.Handled = true;
					e.Return = Sal.SendMsg(this.tblPeriod, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceIsDirty, Sys.wParam, Sys.lParam);
					return;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave:
					e.Handled = true;
					e.Return = Sal.SendMsg(this.tblPeriod, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Sys.wParam, Sys.lParam);
					return;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_Create event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dlgPeriodAllocation_OnSAM_Create(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.i_sCompany = this.sPCompany;
			e.Return = Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
		
		/// <summary>
		/// PM_DataSourcePopulate event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dlgPeriodAllocation_OnPM_DataSourcePopulate(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Sys.wParam, Sys.lParam)) 
			{
				if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
				{
					Sal.EnableWindow(this.dfnFromYear);
					Sal.EnableWindow(this.dfnUntilYear);
					Sal.EnableWindow(this.dfnFromPeriod);
					Sal.EnableWindow(this.dfnUntilPeriod);
					this.CalculatePeriods();
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
		private void dfnRowNo_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_SetFocus:
					this.dfnRowNo_OnSAM_SetFocus(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfnRowNo_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
			this.hWndLovField = SalWindowHandle.Null;
			this.pbList.MethodInvestigateState();
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void dfsVoucherType_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_SetFocus:
					this.dfsVoucherType_OnSAM_SetFocus(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfsVoucherType_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
			this.hWndLovField = SalWindowHandle.Null;
			this.pbList.MethodInvestigateState();
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
				case Sys.SAM_SetFocus:
					this.dfnVoucherNo_OnSAM_SetFocus(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfnVoucherNo_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
			this.hWndLovField = SalWindowHandle.Null;
			this.pbList.MethodInvestigateState();
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void dfnPeriod_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_SetFocus:
					this.dfnPeriod_OnSAM_SetFocus(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfnPeriod_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
			this.hWndLovField = SalWindowHandle.Null;
			this.pbList.MethodInvestigateState();
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
				case Sys.SAM_SetFocus:
					this.dfsCurrencyCode_OnSAM_SetFocus(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfsCurrencyCode_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
			this.hWndLovField = SalWindowHandle.Null;
			this.pbList.MethodInvestigateState();
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void dfnAmount_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_SetFocus:
					this.dfnAmount_OnSAM_SetFocus(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfnAmount_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
			this.hWndLovField = SalWindowHandle.Null;
			this.pbList.MethodInvestigateState();
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void dfnFromYear_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_AnyEdit:
					e.Handled = true;
					this.MethodStateChanged(Ifs.Fnd.ApplicationForms.Const.CHILDTYPE_SourceMethod);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
					this.dfnFromYear_OnPM_DataItemQueryEnabled(sender, e);
					break;
				
				case Sys.SAM_SetFocus:
					this.dfnFromYear_OnSAM_SetFocus(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// PM_DataItemQueryEnabled event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfnFromYear_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (this.dfsPartyType.Text == "SUPPLIER") 
			{
				if (!(Sal.IsNull(this.dfsInvAccRowId))) 
				{
					e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
					return;
				}
			}
			e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
		
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfnFromYear_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
			this.hWndLovField = SalWindowHandle.Null;
			this.pbList.MethodInvestigateState();
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void dfnFromPeriod_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_AnyEdit:
					e.Handled = true;
					this.MethodStateChanged(Ifs.Fnd.ApplicationForms.Const.CHILDTYPE_SourceMethod);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
					this.dfnFromPeriod_OnPM_DataItemQueryEnabled(sender, e);
					break;
				
				case Sys.SAM_SetFocus:
					this.dfnFromPeriod_OnSAM_SetFocus(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// PM_DataItemQueryEnabled event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfnFromPeriod_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (this.dfsPartyType.Text == "SUPPLIER") 
			{
				if (!(Sal.IsNull(this.dfsInvAccRowId))) 
				{
					e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
					return;
				}
			}
			e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
		
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfnFromPeriod_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
			this.hWndLovField = SalWindowHandle.Null;
			this.pbList.MethodInvestigateState();
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void dfnUntilYear_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_AnyEdit:
					e.Handled = true;
					this.MethodStateChanged(Ifs.Fnd.ApplicationForms.Const.CHILDTYPE_SourceMethod);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
					this.dfnUntilYear_OnPM_DataItemQueryEnabled(sender, e);
					break;
				
				case Sys.SAM_SetFocus:
					this.dfnUntilYear_OnSAM_SetFocus(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// PM_DataItemQueryEnabled event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfnUntilYear_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (this.dfsPartyType.Text == "SUPPLIER") 
			{
				if (!(Sal.IsNull(this.dfsInvAccRowId))) 
				{
					e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
					return;
				}
			}
			e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
		
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfnUntilYear_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
			this.hWndLovField = SalWindowHandle.Null;
			this.pbList.MethodInvestigateState();
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void dfnUntilPeriod_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_AnyEdit:
					this.dfnUntilPeriod_OnSAM_AnyEdit(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
					this.dfnUntilPeriod_OnPM_DataItemQueryEnabled(sender, e);
					break;
				
				case Sys.SAM_SetFocus:
					this.dfnUntilPeriod_OnSAM_SetFocus(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_AnyEdit event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfnUntilPeriod_OnSAM_AnyEdit(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.cbDivide.Checked = true;
			this.MethodStateChanged(Ifs.Fnd.ApplicationForms.Const.CHILDTYPE_SourceMethod);
			#endregion
		}
		
		/// <summary>
		/// PM_DataItemQueryEnabled event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfnUntilPeriod_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (this.dfsPartyType.Text == "SUPPLIER") 
			{
				if (!(Sal.IsNull(this.dfsInvAccRowId))) 
				{
					e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
					return;
				}
			}
			e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
		
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfnUntilPeriod_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
			this.hWndLovField = SalWindowHandle.Null;
			this.pbList.MethodInvestigateState();
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
				case Sys.SAM_SetFocus:
					this.dfsUserGroup_OnSAM_SetFocus(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovUserWhere:
					this.dfsUserGroup_OnPM_DataItemLovUserWhere(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovDone:
					this.dfsUserGroup_OnPM_DataItemLovDone(sender, e);
					break;
				
				case Sys.SAM_AnyEdit:
					e.Handled = true;
					// Bug 71922, Begin.Removed the call to UpdAllocUserGrpVouType()
					this.pbNew.MethodInvestigateState();
					break;
				
				// ! Bug 93512, Begin
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
					this.dfsUserGroup_OnPM_DataItemValidate(sender, e);
					break;
				
				// Bug 93512, End
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfsUserGroup_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
			this.hWndLovField = this.dfsUserGroup.i_hWndSelf;
			this.pbList.MethodInvestigateState();
			#endregion
		}
		
		/// <summary>
		/// PM_DataItemLovUserWhere event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfsUserGroup_OnPM_DataItemLovUserWhere(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.sUserId = Ifs.Fnd.ApplicationForms.Int.FndUser();
			e.Return = ((SalString)" USERID = :i_hWndFrame.dlgPeriodAllocation.sUserId\r\n" +
			"			AND ALLOWED_ACC_PERIOD_DB = '1'").ToHandle();
			return;
			#endregion
		}
		
		/// <summary>
		/// PM_DataItemLovDone event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfsUserGroup_OnPM_DataItemLovDone(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			SalString.FromHandle(Sys.lParam).Tokenize("", ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_RS).ToCharacter(), this.sRecords);
			this.sRecords[0].Tokenize("", ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_US).ToCharacter(), this.sUnits);
			if (this.sUnits[0] == "USER_GROUP") 
			{
				this.dfsUserGroup.Text = this.sUnits[1];
				this.SetAllocUserGrpVouType();
				// Bug 71922, Begin.Removed the call to UpdAllocUserGrpVouType()
				this.pbNew.MethodInvestigateState();
			}
			e.Return = true;
			return;
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
			if (this.ValidateUserGroup()) 
			{
				e.Return = Sys.VALIDATE_Cancel;
				return;
			}
			else
			{
				e.Return = Sys.VALIDATE_Ok;
				return;
			}
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void dfsAllocVouType_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_SetFocus:
					this.dfsAllocVouType_OnSAM_SetFocus(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovUserWhere:
					e.Handled = true;
					e.Return = ((SalString)"ACCOUNTING_YEAR = :i_hWndFrame.dlgPeriodAllocation.dfnFromYear\r\n" +
					"			AND USER_GROUP = :i_hWndFrame.dlgPeriodAllocation.dfsUserGroup").ToHandle();
					return;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovDone:
					this.dfsAllocVouType_OnPM_DataItemLovDone(sender, e);
					break;
				
				case Sys.SAM_AnyEdit:
					e.Handled = true;
					// Bug 71922, Begin.Removed the call to UpdAllocUserGrpVouType()
					this.pbNew.MethodInvestigateState();
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfsAllocVouType_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
			if (Sal.IsNull(this.dfsUserGroup)) 
			{
				this.hWndLovField = SalWindowHandle.Null;
			}
			else
			{
				this.hWndLovField = this.dfsAllocVouType.i_hWndSelf;
			}
			this.pbList.MethodInvestigateState();
			#endregion
		}
		
		/// <summary>
		/// PM_DataItemLovDone event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfsAllocVouType_OnPM_DataItemLovDone(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			SalString.FromHandle(Sys.lParam).Tokenize("", ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_RS).ToCharacter(), this.sRecords);
			this.sRecords[0].Tokenize("", ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_US).ToCharacter(), this.sUnits);
			if (this.sUnits[0] == "VOUCHER_TYPE") 
			{
				this.dfsAllocVouType.Text = this.sUnits[1];
			}
			// Bug 71922, Begin.Removed the call to UpdAllocUserGrpVouType()
			e.Return = true;
			return;
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
				case Sys.SAM_Create:
					this.tblPeriod_OnSAM_Create(sender, e);
					break;
				
				case Sys.SAM_FetchRowDone:
					this.tblPeriod_OnSAM_FetchRowDone(sender, e);
					break;
				
				case Sys.SAM_RowHeaderDoubleClick:
					this.tblPeriod_OnSAM_RowHeaderDoubleClick(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave:
					this.tblPeriod_OnPM_DataSourceSave(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove:
					this.tblPeriod_OnPM_DataRecordRemove(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew:
					this.tblPeriod_OnPM_DataRecordNew(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_Create event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblPeriod_OnSAM_Create(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			e.Return = Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
		
		/// <summary>
		/// SAM_FetchRowDone event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblPeriod_OnSAM_FetchRowDone(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Sys.SAM_FetchRowDone, Sys.wParam, Sys.lParam)) 
			{
				this.tblPeriod_colCompletePeriod.Text = this.tblPeriod_colnAllocYear.Number.ToString(0) + " " + ("0" + this.tblPeriod_colnAllocPeriod.Number.ToString(0)).Right(2);
                if (this.tblPeriod.RecordStateGet() == Sys.ROW_New) 
				{
					Sal.TblSetContext(tblPeriod, Sys.lParam);
					this.tblPeriod_colsCompany.EditDataItemValueSet(1, this.sPCompany.ToHandle());
					this.tblPeriod_colsVoucherType.EditDataItemValueSet(1, ((SalString)this.dfsVoucherType.Text).ToHandle());
					this.tblPeriod_colnVoucherNo.EditDataItemValueSet(1, this.dfnVoucherNo.Number.ToString(0).ToHandle());
					this.tblPeriod_colnAccountingYear.EditDataItemValueSet(1, this.dfnAccountingYear.Number.ToString(0).ToHandle());
					this.tblPeriod_colnRowNo.EditDataItemValueSet(1, this.cmbRowNo.EditDataItemValueGet());
					this.tblPeriod_colnAllocPeriod.EditDataItemValueSet(1, this.tblPeriod_colnAllocPeriod.Number.ToString(0).ToHandle());
					this.tblPeriod_colnAllocYear.EditDataItemValueSet(1, this.tblPeriod_colnAllocYear.Number.ToString(0).ToHandle());
					this.tblPeriod_colnUntilYear.EditDataItemValueSet(1, (this.dfnUntilPeriod.Number / 100).ToString(0).ToHandle());
					this.tblPeriod_colnUntilPeriod.EditDataItemValueSet(1, this.dfnUntilPeriod.Number.Mod(100).ToString(0).ToHandle());
					if (this.cbDivide.Checked == true) 
					{
                        this.tblPeriod_colnAllocAmount.EditDataItemValueSet(1, (this.dfnAmount.Number / this.nActualRows).ToString(this.dfnDecimalsInAmount.Number).ToHandle());                        
						this.tblPeriod_colnAllocPercent.EditDataItemValueSet(1, (this.tblPeriod_colnAllocAmount.Number / this.dfnAmount.Number).ToString(4).ToHandle());						
					}
					Sal.TblSetRowFlags(tblPeriod, Sys.lParam, Sys.ROW_New, true);
				}
                else
                {
                    this.tblPeriod_colnAllocPercent.Number = (this.tblPeriod_colnAllocAmount.Number / this.dfnAmount.Number);
                }
				e.Return = true;
				return;
			}
			e.Return = false;
			return;
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
		/// PM_DataSourceSave event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblPeriod_OnPM_DataSourceSave(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
			{
				// give message if amount not the same as it should be, and let it save if all rows removed
				if (!(this.CheckCurrAllocation())) 
				{
					e.Return = false;
					return;
				}
				if (!(this.CheckAuthLevel())) 
				{
					e.Return = false;
					return;
				}
				this.bRemoveAll = this.RemoveAll();
				if ((Sal.TblColumnSum(tblPeriod, 11, 0, Sys.ROW_MarkDeleted) != this.dfnAmount.Number) && (this.bRemoveAll == false)) 
				{
					Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_PeAl_AmountNotEqual, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
					e.Return = false;
					return;
				}
			}
			Sal.TblSetContext(tblPeriod, 0);
			if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Sys.wParam, Sys.lParam)) 
			{
				if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
				{
					// If all rows removed set dfFromPeriod and dfUntilPeriod become edited, so user can enter new row(s) again
					if (this.bRemoveAll == true) 
					{
						this.dfnUntilYear.Number = Sys.NUMBER_Null;
						this.dfnUntilPeriod.Number = Sys.NUMBER_Null;
						this.cbDivide.Checked = false;
						Sal.EnableWindow(this.dfnFromYear);
						Sal.EnableWindow(this.dfnUntilYear);
						Sal.EnableWindow(this.dfnFromPeriod);
						Sal.EnableWindow(this.dfnUntilPeriod);
						Sal.EnableWindow(this.dfsUserGroup);
						Sal.EnableWindow(this.dfsAllocVouType);
						Sal.TblDefineSplitWindow(tblPeriod, 0, Sys.TBL_Split_Adjustable);
					}
                    pbSave.MethodInvestigateState();
				}
				// Bug 74726 begin
				this.SetRoundedCurrency();
				// Bug 74726 end
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
		private void tblPeriod_OnPM_DataRecordRemove(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove, Sys.wParam, Sys.lParam)) 
			{
				// Bug 69803 Start
				if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire) 
				{
					if (this.nAllocationId != SalNumber.Null && this.nAllocationId != 0) 
					{
						e.Return = false;
						return;
					}
				}
				// Bug 69803 End
				if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
				{
					this.nCurrentContext = Sal.TblQueryContext(tblPeriod);
					Sal.TblQuerySplitWindow(tblPeriod, ref this.nRowsLowerHalf, ref this.bDragAdjust);
					if (this.nRowsLowerHalf == 0) 
					{
						if (Sal.TblDefineSplitWindow(tblPeriod, 1, Sys.TBL_Split_Adjustable)) 
						{
							this.nSplitContext = Sal.TblInsertRow(tblPeriod, Sys.TBL_MinSplitRow);
							Sal.TblSetRowFlags(tblPeriod, this.nSplitContext, Sys.ROW_New, false);
							Sal.TblSetContext(tblPeriod, this.nSplitContext);
							this.tblPeriod_colCompletePeriod.Text = Properties.Resources.TEXT_VoEn_Total;
						}
					}
					Sal.TblSetContext(tblPeriod, this.nSplitContext);
					this.tblPeriod_colnAllocPercent.Number = Sal.TblColumnSum(tblPeriod, 10, 0, Sys.ROW_MarkDeleted);
					this.tblPeriod_colnAllocAmount.Number = Sal.TblColumnSum(tblPeriod, 11, 0, Sys.ROW_MarkDeleted);
					this.CalculatePeriods();
					Sal.TblSetContext(tblPeriod, this.nCurrentContext);
					this.MethodStateChanged(Ifs.Fnd.ApplicationForms.Const.CHILDTYPE_SourceMethod);
				}
				e.Return = true;
				return;
			}
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
			// ! Bug 69803 Start
			if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire) 
			{
                // Code has been commented to disable a new record being created when + is clicked.
                return;
			}
			// ! Bug 69803 End
			if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
			{
				Sal.TblSetContext(tblPeriod, Sys.TBL_MinRow);
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
		public override SalNumber vrtUserMethod(SalNumber nWhat, SalString sMethod)
		{
			return this.UserMethod(nWhat, sMethod);
		}
		#endregion
		
		#region ChildTable-tblPeriod
					
		#region Window Variables
		public SalBoolean bDragAdjust = false;
		public SalBoolean bRemoveAll = false;
		public SalNumber nActualRows = 0;
		public SalNumber nCurrentContext = 0;
		public SalNumber nPeriodShouldBe = 0;
		public SalNumber nRowsLowerHalf = 0;
		public SalString sAuthLevel = "";
		#endregion
			
		#region Methods
			
		/// <summary>
		/// Create new row with all period that have been specified before
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean New()
		{
			#region Local Variables
			SalString sSQLStatement = "";
			SalNumber nCurrentRow = 0;
			SalArray<SalString> sParam = new SalArray<SalString>();
			#endregion
				
			#region Actions

			this.nFromPeriod = this.dfnFromYear.Number * 100 + this.dfnFromPeriod.Number;
			this.nUntilPeriod = this.dfnUntilYear.Number * 100 + this.dfnUntilPeriod.Number;
			if (!(this.Validate_Period(this.dfnFromYear.Number, this.dfnFromPeriod.Number))) 
			{
				Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.WM_FromPeriodNotExist, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.WARNING_Ok);
				return false;
			}
			else if (!(this.Validate_Period(this.dfnUntilYear.Number, this.dfnUntilPeriod.Number))) 
			{
				Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.WM_UntilPeriodNotExist, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.WARNING_Ok);
				return false;
			}
			// Tell I'm new
            tblPeriod.i_nRecordState = Sys.ROW_New;
			// Get how many period that should be there & actual row(s) that should be there

            IDictionary<string, string> namedBindVariables = new Dictionary<string, string>();
            namedBindVariables.Add("nPeriodShouldBe",this.QualifiedVarBindName("nPeriodShouldBe"));
            namedBindVariables.Add("dfsCompany", this.dfsCompany.QualifiedBindName);
            namedBindVariables.Add("nFromPeriod", this.QualifiedVarBindName("nFromPeriod"));
            namedBindVariables.Add("nUntilPeriod", this.QualifiedVarBindName("nUntilPeriod"));
            namedBindVariables.Add("nActualRows", this.QualifiedVarBindName("nActualRows"));
            namedBindVariables.Add("dfsUserGroup", this.dfsUserGroup.QualifiedBindName);

            sSQLStatement = @"SELECT count(*) INTO {nPeriodShouldBe}
				                FROM &AO.Accounting_Period   
				               WHERE company = {dfsCompany} 
				                 AND (accounting_year * 100 + accounting_period ) BETWEEN {nFromPeriod} AND {nUntilPeriod} 
				                 AND year_end_period_db = 'ORDINARY';
			                  SELECT count(*) INTO {nActualRows}
				                FROM &AO.Accounting_Period   
				               WHERE company = {dfsCompany}
				                 AND (accounting_year * 100 + accounting_period ) BETWEEN {nFromPeriod} AND {nUntilPeriod}
				                 AND &AO.User_Group_Period_API.Is_Period_Open_( company, accounting_year, accounting_period, {dfsUserGroup} IN) = 'TRUE' 
				                 AND year_end_period_db = 'ORDINARY';"; 

                
			if (!(DbPLSQLBlock (sSQLStatement,namedBindVariables))) 
			{
				// Don't translate this message, this message only for programmer not user
				Ifs.Fnd.ApplicationForms.Int.AlertBox("Design time error in function New !", Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
				return false;
			}
                
			if (nActualRows != nPeriodShouldBe) 
			{
				sParam[0] = this.dfsUserGroup.Text;
				Ifs.Fnd.ApplicationForms.Int.AlertBoxWithParams(Properties.Resources.WM_SomePeriodClosed, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Warning, Ifs.Fnd.ApplicationForms.Const.WARNING_Ok, sParam);
				return false;
					
			}
			// Fill all column with period that should be there

            sSQLStatement = string.Format(@"SELECT accounting_year, accounting_period 
				                              FROM &AO.Accounting_Period INTO {0}, {1} 
				                             WHERE company = {2} 
				                               AND ( accounting_year * 100 + accounting_period ) BETWEEN {3} AND {4}
				                               AND &AO.User_Group_Period_API.Is_Period_Open_( company, accounting_year, accounting_period, {5}) = 'TRUE'
		                                     ORDER BY accounting_year, accounting_period",
                                              this.tblPeriod_colnAllocYear.QualifiedBindName,
                                              this.tblPeriod_colnAllocPeriod.QualifiedBindName,
                                              this.dfsCompany.QualifiedBindName,
                                              this.QualifiedVarBindName("nFromPeriod"),
                                              this.QualifiedVarBindName("nUntilPeriod"),
                                              this.dfsUserGroup.QualifiedBindName);

			tblPeriod.DbTblPopulate(tblPeriod, cSessionManager.c_hSql, sSQLStatement, Sys.TBL_FillNormal);
			nCurrentRow = Sys.TBL_MinRow;
			while (true)
			{
				if (Sal.TblFindNextRow(tblPeriod, ref nCurrentRow, 0, Sys.ROW_MarkDeleted)) 
				{
                    Sal.TblSetContext(tblPeriod, nCurrentRow);
					tblPeriod_colnUserGroup.Text = SalString.FromHandle(this.dfsUserGroup.EditDataItemValueGet());
                    tblPeriod_colnUserGroup.EditDataItemSetEdited();
                    tblPeriod_colnAllocVouType.Text = SalString.FromHandle(this.dfsAllocVouType.EditDataItemValueGet());
                    tblPeriod_colnAllocVouType.EditDataItemSetEdited();
				}
				else
				{
					break;
				}
			}

            // adjust the value in last row
            if (this.cbDivide.Checked == true)
            {
                tblPeriod_colnAllocAmount.Number = tblPeriod_colnAllocAmount.Number + (dfnAmount.Number - Sal.TblColumnSum(tblPeriod, 11, 0, Sys.ROW_MarkDeleted));
                tblPeriod_colnAllocPercent.Number = tblPeriod_colnAllocPercent.Number + (1 - Sal.TblColumnSum(tblPeriod, 10, 0, Sys.ROW_MarkDeleted));
            }

			// Split window to create total
            nCurrentContext = Sal.TblQueryContext(tblPeriod);           

            if (Sal.TblDefineSplitWindow(tblPeriod, 1, Sys.TBL_Split_Adjustable)) 
			{
                this.nSplitContext = Sal.TblInsertRow(tblPeriod, Sys.TBL_MinSplitRow);
                Sal.TblSetRowFlags(tblPeriod, this.nSplitContext, Sys.ROW_New, false);
                Sal.TblSetContext(tblPeriod, this.nSplitContext);
                tblPeriod_colCompletePeriod.Text = Properties.Resources.TEXT_VoEn_Total;
                tblPeriod_colnAllocPercent.Number = Sal.TblColumnSum(tblPeriod, 10, 0, Sys.ROW_MarkDeleted);
                tblPeriod_colnAllocAmount.Number = Sal.TblColumnSum(tblPeriod, 11, 0, Sys.ROW_MarkDeleted);
			}
           
            Sal.TblSetContext(tblPeriod, nCurrentContext);
			Sal.DisableWindow(this.dfnFromYear);
			Sal.DisableWindow(this.dfnUntilYear);
			Sal.DisableWindow(this.dfnFromPeriod);
			Sal.DisableWindow(this.dfnUntilPeriod);
			Sal.DisableWindow(this.dfsUserGroup);
			Sal.DisableWindow(this.dfsAllocVouType);

			// Just to make sure data really new
			i_nDataSourceState = Ifs.Fnd.ApplicationForms.Const.DATASOURCE_Changed;
			this.MethodStateChanged(Ifs.Fnd.ApplicationForms.Const.CHILDTYPE_SourceMethod);
			return true;

            #endregion
        }
			
		/// <summary>
		/// Check if all row remark as deleted, user can delete Period Allocation, other wise, give some message, according to amount
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean RemoveAll()
		{
			#region Local Variables
			SalNumber nRow = 0;
			SalNumber nRowDeleted = 0;
			#endregion
				
			#region Actions
            nRow = Sys.TBL_MinRow;
            while (Sal.TblFindNextRow(tblPeriod, ref nRow, 0, 0)) 
			{
                if (Sal.TblQueryRowFlags(tblPeriod, nRow, Sys.ROW_MarkDeleted)) 
				{
					nRowDeleted = nRowDeleted + 1;
				}
			}
            return !((nRowDeleted != nRow + 1) && (nRow >= 0)); 
			#endregion
		}
			
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber CalculatePeriods()
		{
			#region Local Variables
			SalNumber nCurrentRow = 0;
			SalNumber nCurrentContext = 0;
			SalNumber nMinYear = 0;
			SalNumber nMinPeriod = 0;
			SalNumber nMaxYear = 0;
			SalNumber nMaxPeriod = 0;
			#endregion
				
			#region Actions
		
			nCurrentRow = Sys.TBL_MinRow;
			nMinPeriod = SalNumber.Null;
			nMaxPeriod = SalNumber.Null;
			nCurrentContext = Sal.TblQueryContext(this);

			while (true)
			{
                if (Sal.TblFindNextRow(tblPeriod, ref nCurrentRow, 0, Sys.ROW_MarkDeleted)) 
				{
                    Sal.TblSetContext(tblPeriod, nCurrentRow);
					if (!(Sal.IsNull(tblPeriod_colnUntilPeriod))) 
					{
						if (nMinPeriod == SalNumber.Null) 
						{
                            nMinYear = tblPeriod_colnAllocYear.Number;
                            nMinPeriod = tblPeriod_colnAllocPeriod.Number;
						}
						else
						{
                            if (tblPeriod_colnAllocYear.Number * 100 + tblPeriod_colnAllocPeriod.Number < nMinYear * 100 + nMinPeriod) 
							{
                                nMinYear = tblPeriod_colnAllocYear.Number;
                                nMinPeriod = tblPeriod_colnAllocPeriod.Number;
							}
						}
						if (nMaxPeriod == SalNumber.Null) 
						{
                            nMaxYear = tblPeriod_colnAllocYear.Number;
                            nMaxPeriod = tblPeriod_colnAllocPeriod.Number;
						}
						else
						{
                            if (tblPeriod_colnAllocYear.Number * 100 + tblPeriod_colnAllocPeriod.Number > nMaxYear * 100 + nMaxPeriod) 
							{
                                nMaxYear = tblPeriod_colnAllocYear.Number;
                                nMaxPeriod = tblPeriod_colnAllocPeriod.Number;
							}
						}
					}
                    
				}
				else
				{
					break;
				}
			}

            // adjust the value in last row
            tblPeriod_colnAllocPercent.Number = tblPeriod_colnAllocPercent.Number + (1 - Sal.TblColumnSum(tblPeriod, 10, 0, Sys.ROW_MarkDeleted));

			if (!((nMinPeriod == SalNumber.Null) || (nMaxPeriod == SalNumber.Null))) 
			{
				this.dfnFromYear.Number = nMinYear;
				this.dfnUntilYear.Number = nMaxYear;
				this.dfnFromPeriod.Number = nMinPeriod;
				this.dfnUntilPeriod.Number = nMaxPeriod;
				Sal.DisableWindow(this.dfnFromYear);
				Sal.DisableWindow(this.dfnUntilYear);
				Sal.DisableWindow(this.dfnFromPeriod);
				Sal.DisableWindow(this.dfnUntilPeriod);
			}
			else
			{
				// Enable from & to periods if all the rows were removed before saving
                if (!(Sal.TblAnyRows(tblPeriod, Sys.ROW_MarkDeleted, 0))) 
				{
					this.dfnUntilYear.Number = Sys.NUMBER_Null;
					this.dfnUntilPeriod.Number = Sys.NUMBER_Null;
					this.cbDivide.Checked = false;
					Sal.EnableWindow(this.dfnFromYear);
					Sal.EnableWindow(this.dfnUntilYear);
					Sal.EnableWindow(this.dfnFromPeriod);
					Sal.EnableWindow(this.dfnUntilPeriod);
					Sal.EnableWindow(this.dfsUserGroup);
					Sal.EnableWindow(this.dfsAllocVouType);
				}
			}
            Sal.TblSetContext(tblPeriod, nCurrentContext);
			return 0;
			#endregion
		}

        protected virtual void AdjustRoundingDifferences()
        {
            #region Local Variables
            SalNumber nCurrentRow = 0;
            SalNumber nCurrentContext = 0;
            #endregion

            #region Actions

            nCurrentRow = Sys.TBL_MinRow;   
        
            nCurrentContext = Sal.TblQueryContext(this);

            while (Sal.TblFindNextRow(tblPeriod, ref nCurrentRow, 0, Sys.ROW_MarkDeleted))
            {
               Sal.TblSetContext(tblPeriod, nCurrentRow);                    
            }

            // adjust the value in last row
            tblPeriod_colnAllocPercent.Number = tblPeriod_colnAllocPercent.Number + (1 - Sal.TblColumnSum(tblPeriod, 10, 0, Sys.ROW_MarkDeleted));
            Sal.TblSetContext(tblPeriod, nCurrentContext);
            #endregion

        }

		/// <summary>
		/// </summary>
		/// <param name="bPopulateSingle"></param>
		/// <returns></returns>
		public virtual SalBoolean tblPeriod_DataSourcePopulateIt(SalBoolean bPopulateSingle)
		{
            SalBoolean bOk = ((cChildTableFinBase)tblPeriod).DataSourcePopulateIt(bPopulateSingle);
            
            AdjustRoundingDifferences();

            if (Sal.TblDefineSplitWindow(tblPeriod, 1, Sys.TBL_Split_Adjustable)) 
			{
                this.nSplitContext = Sal.TblInsertRow(tblPeriod, Sys.TBL_MinSplitRow);
                Sal.TblSetRowFlags(tblPeriod, this.nSplitContext, Sys.ROW_New, false);
                Sal.TblSetContext(tblPeriod, this.nSplitContext);
                tblPeriod_colCompletePeriod.Text = Properties.Resources.TEXT_VoEn_Total;
                if (Sal.TblAnyRows(tblPeriod, 0, 0)) 
				{
                    tblPeriod_colnAllocPercent.Number = Sal.TblColumnSum(tblPeriod, 10, 0, Sys.ROW_MarkDeleted);
                    tblPeriod_colnAllocAmount.Number = Sal.TblColumnSum(tblPeriod, 11, 0, Sys.ROW_MarkDeleted);
				}
				else
				{
                    tblPeriod_colnAllocPercent.Number = 0;
                    tblPeriod_colnAllocAmount.Number = 0;
				}
			}
			return bOk;
		}
			
		/// <summary>
		/// </summary>
		/// <param name="hSql"></param>
		/// <returns></returns>
		public virtual SalBoolean tblPeriod_DataRecordExecuteNew(SalSqlHandle hSql)
		{
            if (tblPeriod_colnAllocPercent.Number == 0 || tblPeriod_colnAllocPercent.Number == Sys.NUMBER_Null) 
		    {
			    Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_ZeroPercent, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
			    return false;
		    }
            return ((cChildTable)tblPeriod).DataRecordExecuteNew(hSql);
		}
			
		/// <summary>
		/// Check if the period allocation is done only for the current period and gives an error msg accordingly.
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean CheckCurrAllocation()
		{				
			SalNumber nRowCount = 0;
			// To check if theres only one record in the table.
            SalNumber nRow = Sys.TBL_MinRow;
			while (true)
			{
				if (Sal.TblFindNextRow(tblPeriod, ref nRow, Sys.ROW_New, 0)) 
				{
                    if (Sal.TblQueryRowFlags(tblPeriod, nRow, Sys.ROW_New)) 
					{
						nRowCount = nRowCount + 1;
					}
				}
				else
				{
					break;
				}
			}
			// If there only one row and if it is the basic period gives the error msg.
			if (nRowCount == 1) 
			{
                if (tblPeriod_colCompletePeriod.Text == this.dfnPeriod.Number.ToString(0)) 
				{
					Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_CurrPeriodAllocation, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
					return false;
				}
			}
			return true;
		}
			
		/// <summary>
		/// Checks the authorization level of the user group and gives a error msg if he doesnt have enter and approve authority.
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean CheckAuthLevel()
		{
		    if (DbPLSQLBlock("{0} := &AO.Authorize_Level_API.Encode(&AO.Voucher_Type_User_Group_API.Get_Authorize_Level({1} IN, {2} IN,{3} IN,{4} IN))",
                                                this.QualifiedVarBindName("sAuthLevel"),
                                                this.dfsCompany.QualifiedBindName,
                                                this.dfnAccountingYear.QualifiedBindName,
                                                this.dfsUserGroup.QualifiedBindName,
                                                this.dfsAllocVouType.QualifiedBindName)) 
		    {
			    if (this.sAuthLevel == "Not Approved") 
			    {
				    Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_AuthPeriodAllocation, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
				    return false;
			    }
		    }
			return true;	
		}
		// Bug 74726 begin
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber GetRoundedCurrency()
		{
			#region Local Variables
			SalBoolean bRes = false;
			#endregion
				
			#region Actions

			bRes = DbPLSQLBlock(@"{0} := &AO.CURRENCY_AMOUNT_API.Get_Rounded_Amount( {1} IN, {2} IN, {3} IN );",
                                                     this.QualifiedVarBindName("nCurrencyRate"),
                                                     this.dfsCompany.QualifiedBindName,
                                                     this.dfsCurrencyCode.QualifiedBindName,
                                                     this.tblPeriod_colnAllocAmount.QualifiedBindName);
				
			
			Sal.WaitCursor(false);
			if (!(bRes)) 
			{
				return Sys.VALIDATE_Ok;
			}
			return this.nCurrencyRate;
		
			#endregion
		}
			
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber SetRoundedCurrency()
		{
            SalNumber nOldRow = Sal.TblQueryContext(tblPeriod);
		    this.nCrrRow = Sys.TBL_MinRow;
            while (Sal.TblFindNextRow(tblPeriod, ref this.nCrrRow, Sys.ROW_New, (Sys.ROW_Hidden | Sys.ROW_HideMarks))) 
		    {
                Sal.TblSetContext(tblPeriod, this.nCrrRow);
			    if (GetRoundedCurrency()) 
			    {
                    tblPeriod_colnAllocAmount.Number = this.nCurrencyRate;
                    tblPeriod_colnAllocAmount.EditDataItemSetEdited();
			    }
		    }
            Sal.TblSetContext(tblPeriod, nOldRow);
            return 0;
		}
		#endregion
			
		#region Window Actions
			
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void tblPeriod_colnAllocPeriod_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
					this.tblPeriod_colnAllocPeriod_OnPM_DataItemValidate(sender, e);
					break;
					
				case Sys.SAM_SetFocus:
					this.tblPeriod_colnAllocPeriod_OnSAM_SetFocus(sender, e);
					break;
			}
			#endregion
		}
			
		/// <summary>
		/// PM_DataItemValidate event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblPeriod_colnAllocPeriod_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam) == Sys.VALIDATE_Cancel) 
			{
				e.Return = Sys.VALIDATE_Cancel;
				return;
			}
			this.CalculatePeriods();
			e.Return = Sys.VALIDATE_Ok;
			return;
			#endregion
		}
			
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblPeriod_colnAllocPeriod_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
			this.hWndLovField = SalWindowHandle.Null;
			this.pbList.MethodInvestigateState();
			#endregion
		}
			
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void tblPeriod_colCompletePeriod_WindowActions(object sender, WindowActionsEventArgs e)
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
		private void tblPeriod_colnAllocPercent_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
					this.tblPeriod_colnAllocPercent_OnPM_DataItemValidate(sender, e);
					break;
					
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
					this.tblPeriod_colnAllocPercent_OnPM_DataItemQueryEnabled(sender, e);
					break;
					
				case Sys.SAM_SetFocus:
					this.tblPeriod_colnAllocPercent_OnSAM_SetFocus(sender, e);
					break;
			}
			#endregion
		}
			
		/// <summary>
		/// PM_DataItemValidate event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblPeriod_colnAllocPercent_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			// Bug 73733, Begin. Added IF condition.
			if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
			{
                this.tblPeriod_colnAllocAmount.EditDataItemValueSet(1, (this.tblPeriod_colnAllocPercent.Number * this.dfnAmount.Number).ToString(this.dfnDecimalsInAmount.Number).ToHandle());
				this.nCurrentContext = Sal.TblQueryContext(this);
                Sal.TblSetContext(tblPeriod, this.nSplitContext);
                if (Sal.TblAnyRows(tblPeriod, 0, 0)) 
				{
                    this.tblPeriod_colnAllocPercent.Number = Sal.TblColumnSum(tblPeriod, 10, 0, Sys.ROW_MarkDeleted);
                    this.tblPeriod_colnAllocAmount.Number = Sal.TblColumnSum(tblPeriod, 11, 0, Sys.ROW_MarkDeleted);
				}
				else
				{
                    this.tblPeriod_colnAllocPercent.Number = 0;
					this.tblPeriod_colnAllocAmount.Number = 0;
				}
                Sal.TblSetContext(tblPeriod, this.nCurrentContext);
				// Until this section process to set total percentage and total amount
				this.MethodStateChanged(Ifs.Fnd.ApplicationForms.Const.CHILDTYPE_SourceMethod);
			}
			// Bug 73733, End.
			e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
			
		/// <summary>
		/// PM_DataItemQueryEnabled event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblPeriod_colnAllocPercent_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
            if ((Sal.TblQueryContext(tblPeriod) > Sys.TBL_MinRow) && (Sal.TblQueryContext(tblPeriod) < 0) || (this.dfsPartyType.Text == "SUPPLIER" && !(Sal.IsNull(this.dfsInvAccRowId)))) 
			{
				e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
				return;
			}
			e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
			
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblPeriod_colnAllocPercent_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
			this.hWndLovField = SalWindowHandle.Null;
			this.pbList.MethodInvestigateState();
			#endregion
		}
			
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void tblPeriod_colnAllocAmount_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
					this.tblPeriod_colnAllocAmount_OnPM_DataItemValidate(sender, e);
					break;
					
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
					this.tblPeriod_colnAllocAmount_OnPM_DataItemQueryEnabled(sender, e);
					break;
					
				case Sys.SAM_SetFocus:
					this.tblPeriod_colnAllocAmount_OnSAM_SetFocus(sender, e);
					break;
			}
			#endregion
		}
			
		/// <summary>
		/// PM_DataItemValidate event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblPeriod_colnAllocAmount_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
            this.tblPeriod_colnAllocAmount.Number = this.tblPeriod_colnAllocAmount.Number.ToString(this.dfnDecimalsInAmount.Number).ToNumber();
            this.tblPeriod_colnAllocPercent.EditDataItemValueSet(1, (tblPeriod_colnAllocAmount.Number / this.dfnAmount.Number).ToString(4).ToHandle());
            this.nCurrentContext = Sal.TblQueryContext(tblPeriod);
            Sal.TblSetContext(tblPeriod, this.nSplitContext);
            if (Sal.TblAnyRows(tblPeriod, 0, 0)) 
			{
                this.tblPeriod_colnAllocPercent.Number = Sal.TblColumnSum(tblPeriod, 10, 0, Sys.ROW_MarkDeleted);
                this.tblPeriod_colnAllocAmount.Number = Sal.TblColumnSum(tblPeriod, 11, 0, Sys.ROW_MarkDeleted);
			}
			else
			{
                this.tblPeriod_colnAllocPercent.Number = 0;
                this.tblPeriod_colnAllocAmount.Number = 0;
			}
            Sal.TblSetContext(tblPeriod, this.nCurrentContext);
			// Until this section process to set total percentage and total amount
			this.MethodStateChanged(Ifs.Fnd.ApplicationForms.Const.CHILDTYPE_SourceMethod);
			e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
			
		/// <summary>
		/// PM_DataItemQueryEnabled event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblPeriod_colnAllocAmount_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
            if ((Sal.TblQueryContext(tblPeriod) > Sys.TBL_MinRow) && (Sal.TblQueryContext(tblPeriod) < 0) || (this.dfsPartyType.Text == "SUPPLIER" && !(Sal.IsNull(this.dfsInvAccRowId)))) 
			{
				e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
				return;
			}
			e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
			
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblPeriod_colnAllocAmount_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
			this.hWndLovField = SalWindowHandle.Null;
			this.pbList.MethodInvestigateState();
			#endregion
		}
		#endregion
			
		#region Window Events
			
        private void tblPeriod_DataSourcePopulateItEvent(object sender, cDataSource.DataSourcePopulateItEventArgs e)
        {
            e.Handled = true;
            e.ReturnValue = this.tblPeriod_DataSourcePopulateIt(e.nParam);
        }

        private void tblPeriod_DataRecordExecuteNewEvent(object sender, cDataSource.DataRecordExecuteNewEventArgs e)
        {
            e.Handled = true;
            e.ReturnValue = this.tblPeriod_DataRecordExecuteNew(e.hSql);
        }

		#endregion

        #endregion

    }
}
