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
	/// <param name="sPCompany"></param>
	/// <param name="sPSimulationVoucher"></param>
	/// <param name="sPUserId"></param>
	/// <param name="sPUserGroup"></param>
	/// <param name="nPAccYear"></param>
	/// <param name="nPAccPeriod"></param>
	/// <param name="sPVoucherType"></param>
	/// <param name="dPVoucherDate"></param>
	public partial class dlgInterimVoucher : cDialogBoxFin
	{
		#region Window Parameters
		public SalString sPCompany;
		public SalString sPSimulationVoucher;
		public SalString sPUserId;
		public SalString sPUserGroup;
		public SalNumber nPAccYear;
		public SalNumber nPAccPeriod;
		public SalString sPVoucherType;
		public SalDateTime dPVoucherDate;
		#endregion
		
		#region Window Variables
		public SalString lsVoucherGroup = "";
		public SalString lsIsPeriodOpen = "";
		public SalNumber nAccountingPeriod = 0;
		public SalNumber nAccountingYear = 0;
		public SalNumber nIndex = 0;
		public SalString sFormName = "";
		public SalString sIsVoucherValid = "";
		public SalString sIsPeriodOpen = "";
		public SalDateTime dVoucherDate = SalDateTime.Null;
		public SalString sSimulationVoucher = "";
		public SalString sVoucherType1 = "";
		public SalString sAllowedAccPeriod = "";
		public SalNumber nPassedAccPeriod = 0;
		public SalBoolean bYearEndUserGrp = false;
		public SalString sDefVoucherType = "";
		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		protected dlgInterimVoucher()
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
		public static SalNumber ModalDialog(Control owner, SalString sPCompany, SalString sPSimulationVoucher, SalString sPUserId, ref SalString sPUserGroup, ref SalNumber nPAccYear, ref SalNumber nPAccPeriod, ref SalString sPVoucherType, ref SalDateTime dPVoucherDate)
		{
			dlgInterimVoucher dlg = DialogFactory.CreateInstance<dlgInterimVoucher>();
			dlg.sPCompany = sPCompany;
			dlg.sPSimulationVoucher = sPSimulationVoucher;
			dlg.sPUserId = sPUserId;
			dlg.sPUserGroup = sPUserGroup;
			dlg.nPAccYear = nPAccYear;
			dlg.nPAccPeriod = nPAccPeriod;
			dlg.sPVoucherType = sPVoucherType;
			dlg.dPVoucherDate = dPVoucherDate;
			SalNumber ret = dlg.ShowDialog(owner);
			sPUserGroup = dlg.sPUserGroup;
			nPAccYear = dlg.nPAccYear;
			nPAccPeriod = dlg.nPAccPeriod;
			sPVoucherType = dlg.sPVoucherType;
			dPVoucherDate = dlg.dPVoucherDate;
			return ret;
		}
		
		/// <summary>
		/// Returns the object instance associated with the window handle.
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public new static dlgInterimVoucher FromHandle(SalWindowHandle handle)
		{
			return ((dlgInterimVoucher)SalWindow.FromHandle(handle, typeof(dlgInterimVoucher)));
		}
		#endregion
		
		#region Methods
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public new SalBoolean FrameStartupUser()
		{
			#region Local Variables
			SalString lsStmt = "";
			SalString sVoucherType = "";
			SalString sVoucherDate = "";
			SalArray<SalString> sParam = new SalArray<SalString>();
			SalNumber nHoldAccYear = 0;
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				dfVoucherDate.EditDataItemStateSet(Ifs.Fnd.ApplicationForms.Const.EDIT_Changed);
				sFormName = ":i_hWndFrame." + Ifs.Fnd.ApplicationForms.Int.QualifiedItemNameGet(i_hWndSelf) + ".";
				nPassedAccPeriod = nPAccPeriod;
				nHoldAccYear = nPAccYear;
				nPAccPeriod = nPAccPeriod + 1;
				bYearEndUserGrp = false;
				lsStmt = "SELECT  user_group FROM " + cSessionManager.c_sDbPrefix + " USER_GROUP_MEMBER_FINANCE4" + "  WHERE company = " + sFormName + "sPCompany" + "  AND            userid = " + sFormName + "sPUserId" + "  AND  allowed_acc_period_db != '2' ";
				if (!(DbListPopulate(cmbUserGroup, cSessionManager.c_hSql, lsStmt))) 
				{
					Ifs.Fnd.ApplicationForms.Int.AlertBox("Internal Error", Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
					return false;
				}
				if (IsYearEndUserGroup()) 
				{
					bYearEndUserGrp = true;
					// Accounting Year should be Next Year and Period Should be 1 st period
					nPAccPeriod = 1;
					nPAccYear = nPAccYear + 1;
					if (!(Sal.ListQueryCount(cmbUserGroup))) 
					{
						sParam[0] = sPUserId;
						Ifs.Fnd.ApplicationForms.Int.AlertBoxWithParams(Properties.Resources.TEXT_UsrNotReg, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok, sParam);
					}
					else
					{
						Sal.ListSetSelect(cmbUserGroup, 0);
						sPUserGroup = cmbUserGroup.Text;
					}
				}
				else
				{
					cmbUserGroup.Text = sPUserGroup;
				}
				lsStmt = cSessionManager.c_sDbPrefix + "Accounting_Period_API.Get_FirstDate_NextAccPeriod(" + sFormName + "nAccountingPeriod," + sFormName + "nAccountingYear," + sFormName + "dVoucherDate," + sFormName + "sPCompany," + sFormName + "nPAccYear," + 
				sFormName + "sPUserGroup," + sFormName + "nPAccPeriod, 5 );";
				lsStmt = lsStmt + cSessionManager.c_sDbPrefix + "Voucher_Type_User_Group_API.Get_Default_Voucher_Type(" + sFormName + "sDefVoucherType," + sFormName + "sPCompany," + sFormName + "sPUserGroup," + sFormName + "nPAccYear, 'R' );";
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("Accounting_Period_API.Get_FirstDate_NextAccPeriod", System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                    hints.Add("Voucher_Type_User_Group_API.Get_Default_Voucher_Type", System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
				if (!(DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN " + lsStmt + " END;"))) 
				{
					return false;
				}
                }
				sVoucherDate = dVoucherDate.ToString();
				dfVoucherDate.EditDataItemValueSet(0, sVoucherDate.ToHandle());
				dfAccountingYearPeriod.Number = (nAccountingYear * 100) + nAccountingPeriod;
				if ((dfAccountingYearPeriod.Number == 0) && Sal.IsNull(dfVoucherDate)) 
				{
					Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_VoEn_NotOpenStatus, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
					return false;
				}
				sVoucherType = sDefVoucherType;
				if (bYearEndUserGrp) 
				{
					// set nPAccYear to Old Value
					nPAccYear = nHoldAccYear;
				}
				lsStmt = "SELECT  a.Voucher_Type FROM " + cSessionManager.c_sDbPrefix + "voucher_type_user_group a,\r\n	" + cSessionManager.c_sDbPrefix + "voucher_type b WHERE a.company = " + sFormName + "sPCompany\r\n" +
				"	AND a.company = b.company\r\n" +
				"	AND a.voucher_type = b.voucher_type\r\n" +
				"	 AND accounting_year = " + sFormName + "nAccountingYear\r\n" +
				"	AND user_group = " + sFormName + "sPUserGroup AND a.function_group = 'R'\r\n" +
				"                AND ledger_id IN ('*', '00')\r\n" +
				"	AND Simulation_Voucher = " + sFormName + "sPSimulationVoucher";
				if (sPSimulationVoucher == "TRUE") 
				{
					if (!(DbListPopulate(cmbVoucherType, cSessionManager.c_hSql, lsStmt))) 
					{
						Ifs.Fnd.ApplicationForms.Int.AlertBox("Internal Error", Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
						return false;
					}
					if (IsSimulationVoucher(sVoucherType)) 
					{
						cmbVoucherType.Text = sVoucherType;
					}
					else
					{
						Sal.ListSetSelect(cmbVoucherType, 0);
					}
				}
				else
				{
					if (!(DbListPopulate(cmbVoucherType, cSessionManager.c_hSql, lsStmt))) 
					{
						Ifs.Fnd.ApplicationForms.Int.AlertBox("Internal Error", Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
						return false;
					}
					cmbVoucherType.Text = sVoucherType;
				}
				pbOk.MethodInvestigateState();
				return true;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="p_nWhat"></param>
		/// <param name="sMethod"></param>
		/// <returns></returns>
		public new SalNumber UserMethod(SalNumber p_nWhat, SalString sMethod)
		{
			#region Actions
			using (new SalContext(this))
			{
				if (sMethod == "ButtonOk") 
				{
					if (p_nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
					{
						if (Sal.IsNull(dfVoucherDate)) 
						{
							Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_VoEn_RequireDate, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
							return false;
						}
						if (Sal.IsNull(cmbVoucherType)) 
						{
							Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_VoEn_RequireType, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
							return false;
						}
						if (!(IsVoucherValid())) 
						{
							return false;
						}
						nPAccYear = nAccountingYear;
						nPAccPeriod = dfAccountingYearPeriod.Number - (nAccountingYear * 100);
						sPVoucherType = cmbVoucherType.Text;
						dPVoucherDate = dfVoucherDate.DateTime;
						sPUserGroup = cmbUserGroup.Text;
						Sal.EndDialog(this, 1);
					}
					else
					{
						if (Sal.IsNull(dfVoucherDate)) 
						{
							return false;
						}
						if (Sal.IsNull(dfAccountingYearPeriod)) 
						{
							return false;
						}
						if (Sal.IsNull(cmbVoucherType)) 
						{
							return false;
						}
						if (Sal.IsNull(cmbUserGroup)) 
						{
							return false;
						}
						return true;
					}
				}
				else if (sMethod == "ButonCancel") 
				{
					if (p_nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
					{
						Sal.EndDialog(this, 0);
					}
					else
					{
						return true;
					}
				}
				else
				{
					return false;
				}
			}

			return false;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean IsPeriodOpen()
		{
			#region Actions
			using (new SalContext(this))
			{
				nAccountingYear = dfVoucherDate.DateTime.Year();
				using(SignatureHints hints = SignatureHints.NewContext())
				{
					hints.Add("User_Group_Period_API.Is_Period_Open_Date__", System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
					if (!(DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN " + cSessionManager.c_sDbPrefix + "User_Group_Period_API.Is_Period_Open_Date__(" + sFormName + "lsIsPeriodOpen," + sFormName + "sPCompany," + sFormName + "nAccountingYear," + sFormName + 
						"dfVoucherDate," + sFormName + "sPUserGroup ); END;"))) 
					{
						return false;
					}
				}
				if (lsIsPeriodOpen.Trim().ToUpper() != "TRUE") 
				{
					return false;
				}
				using(SignatureHints hints = SignatureHints.NewContext())
				{
					hints.Add("User_Group_Period_API.Get_Period", System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
					if (!(DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN " + cSessionManager.c_sDbPrefix + "User_Group_Period_API.Get_Period(" + sFormName + "nAccountingYear," + sFormName + "nAccountingPeriod," + sFormName + "sPCompany," + sFormName + "sPUserGroup," + 
						sFormName + "dfVoucherDate ); END;"))) 
					{
						return false;
					}
				}
				dfAccountingYearPeriod.Number = (nAccountingYear * 100) + nAccountingPeriod;
				return true;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="p_sVoucherType"></param>
		/// <returns></returns>
		public virtual SalBoolean IsSimulationVoucher(SalString p_sVoucherType)
		{
			#region Actions
			using (new SalContext(this))
			{
				sVoucherType1 = p_sVoucherType;
				using(SignatureHints hints = SignatureHints.NewContext())
				{
					hints.Add("Voucher_Type_API.Get_Simulation_Voucher", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
					if (!(DbPLSQLBlock(cSessionManager.c_hSql, sFormName + "sSimulationVoucher := " + cSessionManager.c_sDbPrefix + "Voucher_Type_API.Get_Simulation_Voucher( " + sFormName + "sPCompany," + sFormName + "sVoucherType1  )"))) 
					{
						return false;
					}
				}
				if (sSimulationVoucher == "TRUE") 
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
		public virtual SalBoolean IsVoucherValid()
		{
			#region Local Variables
			SalString lsStmt = "";
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				lsStmt = sFormName + "lsVoucherGroup := " + cSessionManager.c_sDbPrefix + "Voucher_Type_API.Get_Voucher_Group(" + sFormName + "sPCompany," + sFormName + "cmbVoucherType);";
				lsStmt = lsStmt + cSessionManager.c_sDbPrefix + "Voucher_Type_User_Group_API.Check_If_Voucher_Type_Valid(" + sFormName + "sIsVoucherValid," + sFormName + "sPCompany," + sFormName + "sPUserGroup," + sFormName + "nAccountingYear," + sFormName + 
				"cmbVoucherType );";
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("Voucher_Type_API.Get_Voucher_Group", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                    hints.Add("Voucher_Type_User_Group_API.Check_If_Voucher_Type_Valid", System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
				if (!(DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN " + lsStmt + " END;"))) 
				{
					return false;
				}
                }
				if (lsVoucherGroup.Trim().ToUpper() != "R") 
				{
					Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_InVo_NotGroup, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
					return false;
				}
				return true;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean IsYearEndUserGroup()
		{
			#region Actions
			using (new SalContext(this))
			{
				using(SignatureHints hints = SignatureHints.NewContext())
				{
					hints.Add("USER_GROUP_FINANCE_API.Get_Allowed_Acc_Period", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
					if (!(DbPLSQLBlock(cSessionManager.c_hSql, sFormName + "sAllowedAccPeriod := " + cSessionManager.c_sDbPrefix + "USER_GROUP_FINANCE_API.Get_Allowed_Acc_Period( " + sFormName + "sPCompany," + sFormName + "sPUserGroup  )"))) 
					{
						return false;
					}
				}
				return sAllowedAccPeriod == "2";
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber UserGroupChanged()
		{
			#region Local Variables
			SalString lsStmt = "";
			SalString sVoucherType = "";
			SalString sVoucherDate = "";
			SalNumber nHoldAccYear = 0;
			SalArray<SalString> sParam = new SalArray<SalString>();
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				dfVoucherDate.EditDataItemStateSet(Ifs.Fnd.ApplicationForms.Const.EDIT_Changed);
				nPAccPeriod = nPassedAccPeriod + 1;
				if (bYearEndUserGrp) 
				{
					// Hold value nPAccYear
					nHoldAccYear = nPAccYear;
					// Accounting Year should be Next Year and Period Should be 1 st period
					nPAccPeriod = 1;
					nPAccYear = nPAccYear + 1;
				}
				lsStmt = cSessionManager.c_sDbPrefix + "Accounting_Period_API.Get_FirstDate_NextAccPeriod(" + sFormName + "nAccountingPeriod," + sFormName + "nAccountingYear," + sFormName + "dVoucherDate," + sFormName + "sPCompany," + sFormName + "nPAccYear," + 
				sFormName + "cmbUserGroup," + sFormName + "nPAccPeriod, 5 );";
				lsStmt = lsStmt + cSessionManager.c_sDbPrefix + "Voucher_Type_User_Group_API.Get_Default_Voucher_Type(" + sFormName + "sDefVoucherType," + sFormName + "sPCompany," + sFormName + "cmbUserGroup," + sFormName + "nPAccYear, 'R' );";
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("Accounting_Period_API.Get_FirstDate_NextAccPeriod", System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                    hints.Add("Voucher_Type_User_Group_API.Get_Default_Voucher_Type", System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
				DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN " + lsStmt + " END;");
                }
				sVoucherDate = dVoucherDate.ToString();
				dfVoucherDate.EditDataItemValueSet(0, sVoucherDate.ToHandle());
				dfAccountingYearPeriod.Number = (nAccountingYear * 100) + nAccountingPeriod;
				if ((dfAccountingYearPeriod.Number == 0) && Sal.IsNull(dfVoucherDate)) 
				{
					Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_VoEn_NotOpenStatus, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
				}
				sVoucherType = sDefVoucherType;
				if (bYearEndUserGrp) 
				{
					// set nPAccYear to Old Value
					nPAccYear = nHoldAccYear;
				}
				lsStmt = "SELECT  a.Voucher_Type FROM " + cSessionManager.c_sDbPrefix + "voucher_type_user_group a,\r\n	" + cSessionManager.c_sDbPrefix + "voucher_type b WHERE a.company = " + sFormName + "sPCompany\r\n" +
				"	AND a.company = b.company\r\n" +
				"	AND a.voucher_type = b.voucher_type\r\n" +
				"	 AND accounting_year = " + sFormName + "nAccountingYear\r\n" +
				"	AND user_group = " + sFormName + "cmbUserGroup AND a.function_group = 'R'\r\n" +
				"                AND ledger_id IN ('*', '00')\r\n" +
				"	AND Simulation_Voucher = " + sFormName + "sPSimulationVoucher";
				if (sPSimulationVoucher == "TRUE") 
				{
					if (!(DbListPopulate(cmbVoucherType, cSessionManager.c_hSql, lsStmt))) 
					{
						Ifs.Fnd.ApplicationForms.Int.AlertBox("Internal Error", Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
					}
					if (IsSimulationVoucher(sVoucherType)) 
					{
						cmbVoucherType.Text = sVoucherType;
					}
					else
					{
						Sal.ListSetSelect(cmbVoucherType, 0);
					}
				}
				else
				{
					if (!(DbListPopulate(cmbVoucherType, cSessionManager.c_hSql, lsStmt))) 
					{
						Ifs.Fnd.ApplicationForms.Int.AlertBox("Internal Error", Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
					}
					cmbVoucherType.Text = sVoucherType;
				}
				if ((dfAccountingYearPeriod.Number != 0) && !(Sal.IsNull(dfVoucherDate))) 
				{
					if (!(Sal.ListQueryCount(cmbVoucherType))) 
					{
						sParam[0] = cmbUserGroup.Text;
						sParam[1] = dfAccountingYearPeriod.Number.ToString(0);
						Ifs.Fnd.ApplicationForms.Int.AlertBoxWithParams(Properties.Resources.TEXT_UsrGrpNotAss, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok, sParam);
					}
				}
				sPUserGroup = cmbUserGroup.Text;
				pbOk.MethodInvestigateState();
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
		private void dlgInterimVoucher_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Create:
					this.dlgInterimVoucher_OnSAM_Create(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_Create event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dlgInterimVoucher_OnSAM_Create(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.i_sCompany = this.sPCompany;
			Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam);
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void cmbUserGroup_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
					e.Handled = true;
					e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldEnabled;
					return;
				
				case Sys.SAM_Click:
					this.cmbUserGroup_OnSAM_Click(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_Click event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cmbUserGroup_OnSAM_Click(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			Sal.SendClassMessage(Sys.SAM_Click, Sys.wParam, Sys.lParam);
			this.UserGroupChanged();
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void dfVoucherDate_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_AnyEdit:
					e.Handled = true;
					this.pbOk.MethodInvestigateState();
					break;
				
				case Sys.SAM_Validate:
					this.dfVoucherDate_OnSAM_Validate(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
					e.Handled = true;
					e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldEnabled;
					return;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_Validate event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfVoucherDate_OnSAM_Validate(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.IsNull(this.dfVoucherDate)) 
			{
				e.Return = Sys.VALIDATE_Ok;
				return;
			}
			if (Sal.GetType(Sys.lParam.ToWindowHandle()) == Sys.TYPE_PushButton) 
			{
				e.Return = Sys.VALIDATE_Ok;
				return;
			}
			if (!(this.IsPeriodOpen())) 
			{
				Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_VoEn_NotOpenDate, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
				e.Return = Sys.VALIDATE_Cancel;
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
		private void dfAccountingYearPeriod_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_AnyEdit:
					e.Handled = true;
					this.pbOk.MethodInvestigateState();
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void cmbVoucherType_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
					e.Handled = true;
					e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldEnabled;
					return;
				
				case Sys.SAM_Click:
					this.cmbVoucherType_OnSAM_Click(sender, e);
					break;
				
				case Sys.SAM_AnyEdit:
					e.Handled = true;
					this.pbOk.MethodInvestigateState();
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_Click event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cmbVoucherType_OnSAM_Click(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			Sal.SendClassMessage(Sys.SAM_Click, Sys.wParam, Sys.lParam);
			this.pbOk.MethodInvestigateState();
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
