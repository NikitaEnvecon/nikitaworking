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
using System.Collections.Generic;

namespace Ifs.Application.Accrul_
{
	
	/// <summary>
	/// </summary>
	[FndWindowRegistration("VOUCHER_TYPE", "VoucherType")]
	public partial class dlgVoucherType : cWizardDialogBoxFin
	{
		#region Window Variables
		public SalString lsSubMessage = "";
		public SalString lsMainMessage = "";
		public SalString lsMainMesgTemp = "";
		public SalString lsSubMessageX = "";
		public SalString lsMainMessageX = "";
		public SalString lsMainMesgTempX = "";
		public cMessage MainMessage = new cMessage();
		public cMessage SubMessage = new cMessage();
		public cMessage MainMessageX = new cMessage();
		public cMessage SubMessageX = new cMessage();
		public SalNumber id = 0;
		public SalString sOnline = "";
		public SalString sBatch = "";
		public SalBoolean bAutoAllot = false;
		public SalBoolean bExist = false;
		public SalString sDescription = "";
		public SalString sLedgerID = "";
		public SalString sLedger = "";
		public SalNumber nIndex = 0;
		public SalBoolean bSingle = false;
		public SalBoolean bInternal = false;
		public SalBoolean bIntled = false;
		public SalWindowHandle hWndFocusField = SalWindowHandle.Null;
		public SalWindowHandle hWndTemp = SalWindowHandle.Null;
		public SalNumber nWhat = 0;
		public SalBoolean bFuncGroup = false;
		public SalString sCurrentStep = "";
		public SalString lsPeriodUsed = "";
        public SalString sFunctionGroup = "";
        public SalString sVoucherFunction = "";
        public SalWindowHandle hWithFocus = SalWindowHandle.Null;
        public SalString sCompany = "";
        public SalString sCompanyDescription = "";
        public SalString sEnterAndApprove = "";
        public SalString sDefTypeNo = "";
        #endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		protected dlgVoucherType()
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
		public static SalNumber ModalDialog(Control owner)
		{
			dlgVoucherType dlg = DialogFactory.CreateInstance<dlgVoucherType>();
			SalNumber ret = dlg.ShowDialog(owner);
			return ret;
		}
		
		/// <summary>
		/// Returns the object instance associated with the window handle.
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public new static dlgVoucherType FromHandle(SalWindowHandle handle)
		{
			return ((dlgVoucherType)SalWindow.FromHandle(handle, typeof(dlgVoucherType)));
		}
		#endregion
		
		#region Methods
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public new SalBoolean FrameStartupUser()
		{
			#region Actions
			using (new SalContext(this))
			{
                this.cmbCompany.DbListPopulate(this.cmbCompany, cSessionManager.c_hSql, "SELECT company FROM " + cSessionManager.c_sDbPrefix + "COMPANY_FINANCE");
                UserGlobalValueGet("COMPANY", ref sCompany);
                cmbCompany.Text = sCompany;
                dfsCompany.Text = sCompany;
                GetCompanyDescription();
				Sal.SendMsg(cmbLedger, Sys.SAM_DropDown, 0, 0);
				Sal.SetFocus(dfVoucherType);
				EnableDisablePeriod();
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean AllFieldsValidate()
		{
			#region Actions
			using (new SalContext(this))
			{
				if (Sal.IsButtonChecked(cbFromExisting)) 
				{
					if ((dfVoucherType.Text == Ifs.Fnd.ApplicationForms.Const.strNULL) || (tblFunctionGroup_colsFunctionGroup.Text == Ifs.Fnd.ApplicationForms.Const.strNULL) || (dfVouTypeDesc.Text == Ifs.Fnd.ApplicationForms.Const.strNULL) || (dfsExistingVouType.Text == 
					Ifs.Fnd.ApplicationForms.Const.strNULL)) 
					{
						Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_ValidateAll, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
						return false;
					}
				}
				else
				{
					if ((dfVoucherType.Text == Ifs.Fnd.ApplicationForms.Const.strNULL) || (tblFunctionGroup_colsFunctionGroup.Text == Ifs.Fnd.ApplicationForms.Const.strNULL) || (dfVouTypeDesc.Text == Ifs.Fnd.ApplicationForms.Const.strNULL) || this.IsEmptyField() || 
					(dfUserGroup.Text == Ifs.Fnd.ApplicationForms.Const.strNULL) || (cmbAuthLevel.Text == Ifs.Fnd.ApplicationForms.Const.strNULL) || (cmbDefaultType.Text == Ifs.Fnd.ApplicationForms.Const.strNULL) || (rbSingle.Checked && Sal.IsNull(cmbFunctionGroup))) 
					{
						Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_ValidateAll, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
						return false;
					}
				}
				return true;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="sStep"></param>
		/// <returns></returns>
		public virtual SalBoolean AllFieldsValidate2(SalString sStep)
		{
			#region Actions
			using (new SalContext(this))
			{
				if (sStep == "Step2") 
				{
					if ((dfVoucherType.Text == Ifs.Fnd.ApplicationForms.Const.strNULL) || (dfVouTypeDesc.Text == Ifs.Fnd.ApplicationForms.Const.strNULL)) 
					{
						Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_ValidateAll, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
						return false;
					}
				}
				if (sStep == "Step3") 
				{
					if ((dfVoucherType.Text == Ifs.Fnd.ApplicationForms.Const.strNULL) || (dfVouTypeDesc.Text == Ifs.Fnd.ApplicationForms.Const.strNULL)) 
					{
						Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_ValidateAll, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
						return false;
					}
				}
				return true;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber CreateOnline()
		{
			#region Actions
			using (new SalContext(this))
			{
				using(SignatureHints hints = SignatureHints.NewContext())
				{
					hints.Add("Voucher_Type_API.Create_Voucher_Type", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
					hints.Add("Voucher_Type_Detail_API.Process_Message", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
					hints.Add("Voucher_No_Serial_API.Create_Voucher_No", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
					if (!(DbPLSQLTransaction(cSessionManager.c_hSql, "BEGIN " + cSessionManager.c_sDbPrefix + "Voucher_Type_API.Create_Voucher_Type(\r\n" +
						"	          :i_hWndFrame.dlgVoucherType.dfsCompany,\r\n" +
						"                          :i_hWndFrame.dlgVoucherType.dfVoucherType,\r\n" +
						"                          :i_hWndFrame.dlgVoucherType.dfVouTypeDesc,\r\n" +
						"                          :i_hWndFrame.dlgVoucherType.cbAutomaticAllot,\r\n" +
						"                          :i_hWndFrame.dlgVoucherType.dfsOptionalAutoBalance,\r\n" +
						"                          :i_hWndFrame.dlgVoucherType.dfsStoreOriginal,\r\n" +
						"                          :i_hWndFrame.dlgVoucherType.cbFromExisting,\r\n" +
						"                          :i_hWndFrame.dlgVoucherType.cbSingleFunction,\r\n" +
						"                          :i_hWndFrame.dlgVoucherType.cbSimulationVoucher,\r\n" +
						"                          :i_hWndFrame.dlgVoucherType.cbManualMethods,\r\n" +
						"	          :i_hWndFrame.dlgVoucherType.dfLedgerID,\r\n" +
						"                          :i_hWndFrame.dlgVoucherType.cbBalance );  " + cSessionManager.c_sDbPrefix + "Voucher_Type_Detail_API.Process_Message(\r\n" +
						"                          :i_hWndFrame.dlgVoucherType.lsMainMessage,\r\n" +
						"                          :i_hWndFrame.dlgVoucherType.sOnline); " + cSessionManager.c_sDbPrefix + "Voucher_No_Serial_API.Create_Voucher_No(\r\n" +
						"                          :i_hWndFrame.dlgVoucherType.dfsCompany,\r\n" +
						"                          :i_hWndFrame.dlgVoucherType.dfVoucherType,\r\n" +
						"                          :i_hWndFrame.dlgVoucherType.cbFromExisting,\r\n" +
						"                          :i_hWndFrame.dlgVoucherType.dfUserGroup,\r\n" +
						"                          :i_hWndFrame.dlgVoucherType.cmbDefaultType,\r\n" +
						"                          :i_hWndFrame.dlgVoucherType.cmbAuthLevel,\r\n" +
						"	          :i_hWndFrame.dlgVoucherType.lsMainMessageX,\r\n" +
						"                          :i_hWndFrame.dlgVoucherType.cmbFunctionGroup,\r\n" +
						"	          :i_hWndFrame.dlgVoucherType.dfsExistingVouType); " + "END;"))) 
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
		
		/// <summary>
		/// The DataSourceInquireSave presents a message box asking the user to
		/// save changes.
		/// COMMENTS:
		/// DataSourceInquireSave is called by the DataSourceIsDirty function.
		/// </summary>
		/// <returns>The return value is IDYES, IDNO, or IDCANCEL corresponding to the users choice.</returns>
		public new SalNumber DataSourceInquireSave()
		{
			#region Actions
			using (new SalContext(this))
			{
				return Sys.IDNO;
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
				return Properties.Resources.WH_dlgVoucherType;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nWhat"></param>
		/// <param name="sStep"></param>
		/// <returns>
		/// When nWhat = METHOD_Inquire: applications should return TRUE if the Finish operation
		/// is available, FALSE otherwise.
		/// When nWhat = METHOD_Execute: applications should return TRUE if the Finish operation
		/// was successfully performed, FALSE otherwise.
		/// </returns>
		public new SalBoolean WizardFinish(SalNumber nWhat, SalString sStep)
		{
			#region Local Variables
			SalArray<SalString> sArray = new SalArray<SalString>();
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire) 
				{
					return ((cWizardDialogBoxFin)this).WizardFinish(nWhat, sStep);
				}
				else if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
				{
					if (AllFieldsValidate()) 
					{
						this.SendSelectedRows();
						this.SendVoucherSerieInfo();
						sOnline = "TRUE";
						sBatch = "FALSE";
						if (CreateOnline()) 
						{
							sArray[0] = dfVoucherType.Text;
							Ifs.Fnd.ApplicationForms.Int.AlertBoxWithParams(Properties.Resources.TEXT_VoucherTypeCreated, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok, sArray);
							Sal.EndDialog(this, 0);
						}
						else
						{
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
		/// <param name="nWhat"></param>
		/// <param name="sStep"></param>
		/// <returns></returns>
		public new SalBoolean WizardNext(SalNumber nWhat, SalString sStep)
		{
			#region Local Variables
			SalArray<SalString> sArray = new SalArray<SalString>();
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire) 
				{
					if (sStep == "Step2") 
					{
						if ((dfVoucherType.Text == Ifs.Fnd.ApplicationForms.Const.strNULL) || (dfVouTypeDesc.Text == Ifs.Fnd.ApplicationForms.Const.strNULL)) 
						{
							return false;
						}
						else
						{
							return m_nCurrentPage + 1 < m_nTotalPages;
						}
					}
					else if (sStep == "Step3") 
					{
						if (tblFunctionGroup_colsFunctionGroup.Text == Ifs.Fnd.ApplicationForms.Const.strNULL) 
						{
							return false;
						}
						// Else If (tblFunctionGroup.colsFunctionGroup != strNULL)
						// Return FALSE
						else
						{
							return m_nCurrentPage + 1 < m_nTotalPages;
						}
					}
					return ((cWizardDialogBoxFin)this).WizardNext(nWhat, sStep);
				}
				else
				{
					if (sStep == "Step2") 
					{
						if (AllFieldsValidate2(sStep)) 
						{
							return true;
						}
					}
					else if (sStep == "Step3") 
					{
						if (AllFieldsValidate2(sStep)) 
						{
							return true;
						}
					}
					return false;
				}
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean CheckAutoAllotment()
		{
			#region Local Variables
			SalNumber nRow = 0;
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				nRow = Sys.TBL_MinRow;
				while (true)
				{
					if (Sal.TblFindNextRow(tblFunctionGroup, ref nRow, 0, 0)) 
					{
						Sal.TblSetContext(tblFunctionGroup, nRow);
						if (tblFunctionGroup_colsAutomaticAllot.Text == "Y") 
						{
							Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_AutoAllotReq, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Warning, Ifs.Fnd.ApplicationForms.Const.WARNING_Ok);
							cbAutomaticAllot.EditDataItemValueSet(0, ((SalString)"Y").ToHandle());
							break;
							return false;
						}
					}
					else
					{
						break;
					}
					return true;
				}
			}

			return false;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber GetLedgerID()
		{
			#region Actions
			using (new SalContext(this))
			{
				using(SignatureHints hints = SignatureHints.NewContext())
				{
					hints.Add("Ledger_API.Encode", System.Data.ParameterDirection.Input);
					DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN \r\n" +
						"		 :i_hWndFrame.dlgVoucherType.dfLedgerID := " + cSessionManager.c_sDbPrefix + "Ledger_API.Encode(:i_hWndFrame.dlgVoucherType.cmbLedger.i_sMyValue);											          \r\n		 END;");
				}
				dfLedgerID.EditDataItemSetEdited();
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// Gets client default values for NEW records
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean GetDefaults()
		{
			#region Actions
			using (new SalContext(this))
			{
				dfsCompany.Text = i_sCompany;
				dfsCompany.EditDataItemSetEdited();
				dfsOptionalAutoBalance.Text = "N";
				dfsStoreOriginal.Text = "N";
				dfsLabelPrint.Text = "N";
				// Ledger Selection
				if (bIntled) 
				{
					cmbLedger.EditDataItemValueSet(1, Sal.ListQueryTextX(cmbLedger, 0).ToHandle());
					Sal.EnableWindow(cbManualMethods);
				}
				else
				{
					cmbLedger.EditDataItemValueSet(1, Sal.ListQueryTextX(cmbLedger, 1).ToHandle());
				}
				GetLedgerID();
                DbPLSQLBlock(cSessionManager.c_hSql, 
                                   @"BEGIN
                                        :i_hWndFrame.dlgVoucherType.sEnterAndApprove := &AO.Authorize_Level_API.Decode('Approved');
                                        :i_hWndFrame.dlgVoucherType.sDefTypeNo := &AO.Default_Type_API.Decode('N');
                                     END;");
                Sal.DisableWindow(dfLedgerID);
                cmbAuthLevel.EditDataItemValueSet(1, sEnterAndApprove.ToHandle());
                cmbDefaultType.EditDataItemValueSet(1, sDefTypeNo.ToHandle());
				cbManualMethods.EditDataItemValueSet(1, ((SalString)"FALSE").ToHandle());
				dfLedgerID.EditDataItemSetEdited();
				cbBalance.EditDataItemValueSet(1, ((SalString)"TRUE").ToHandle());
				// Voucher Selection
				cbAutomaticAllot.EditDataItemValueSet(1, ((SalString)"Y").ToHandle());
				cbSimulationVoucher.EditDataItemValueSet(1, ((SalString)"FALSE").ToHandle());
				cbSingleFunction.EditDataItemValueSet(1, ((SalString)"Y").ToHandle());
				dfsOptionalAutoBalance.EditDataItemSetEdited();
				dfsStoreOriginal.EditDataItemSetEdited();
				dfsLabelPrint.EditDataItemSetEdited();

				Sal.DisableWindow(cbBalance);
				this.DisableSelection();
				Sal.SetFocus(dfVoucherType);
				return true;
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
				if (sMethod == "New") 
				{
					switch (nWhat)
					{
						case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
							return 1;
						
						case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
							return Sal.SendMsg(hWndTemp, Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
					}
				}
				if ((sCurrentStep == "Step2") || (sCurrentStep == "Step3")) 
				{
					if (sMethod == "new") 
					{
						if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire) 
						{
							return 1;
						}
						if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
						{
							if (bFuncGroup) 
							{
								return Sal.SendMsg(this.tblFunctionGroup, Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
							}
							else
							{
								return Sal.SendMsg(this.tblVoucherSeries, Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
							}
						}
					}
					else if (sMethod == "remove") 
					{
						if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire) 
						{
							return 1;
						}
						if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
						{
							if (cbSingleFunction.Checked == true && Sal.TblAnyRows(tblFunctionGroup, 0, 0) == true) 
							{
								Sal.EnableWindow(pbNew1);
							}
							if (bFuncGroup) 
							{
								return Sal.SendMsg(this.tblFunctionGroup, Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
							}
							else
							{
								return Sal.SendMsg(this.tblVoucherSeries, Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
							}
						}
					}
				}
				if (sMethod == "Remove") 
				{
					switch (nWhat)
					{
						case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
							return 1;
						
						case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
							return Sal.SendMsg(hWndTemp, Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
					}
				}

                if (sMethod == "List")
                {

                    switch (nWhat)
                    {
                        case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                            return 0;

                        case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                            return Sal.SendMsg(hWithFocus, Ifs.Fnd.ApplicationForms.Const.PM_DataItemLov, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);

                    }

                }
				return ((cWizardDialogBoxFin)this).UserMethod(nWhat, sMethod);
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="sStep"></param>
		/// <returns></returns>
		public new SalNumber WizardStepActivated(SalString sStep)
		{
			#region Actions
			using (new SalContext(this))
			{
				if (sStep == "Step1") 
				{
					Sal.DisableWindowAndLabel(pbNew1);
					Sal.DisableWindowAndLabel(pbRemove1);
					sCurrentStep = sStep;
				}
				else if (sStep == "Step2") 
				{
					Sal.EnableWindowAndLabel(pbNew1);
					Sal.EnableWindowAndLabel(pbRemove1);
					bFuncGroup = true;
					sCurrentStep = sStep;
					if (!(Sal.IsButtonChecked(cbFromExisting))) 
					{
						Sal.DisableWindowAndLabel(dfsExistingVouType);
					}
					else if (Sal.IsButtonChecked(cbFromExisting)) 
					{
						Sal.DisableWindowAndLabel(pbNext);
					}
					Sal.SendMsg(dfsExistingVouType, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
					hWndTemp = tblFunctionGroup;
					Sal.SetFocus(hWndTemp);
					Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, ((SalString)"New").ToHandle());
				}
				else if (sStep == "Step3") 
				{
					Sal.EnableWindowAndLabel(pbNew1);
					Sal.EnableWindowAndLabel(pbRemove1);
					bFuncGroup = false;
					sCurrentStep = sStep;
					hWndTemp = tblVoucherSeries;
					Sal.SetFocus(hWndTemp);
					Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, ((SalString)"New").ToHandle());
				}
				((cWizardDialogBoxFin)this).WizardStepActivated(sStep);
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="FromNumber1">From Voucher# for first period</param>
		/// <param name="UntilNumber1">To Voucher# for first period</param>
		/// <param name="FromNumber2">From Voucher# for second period</param>
		/// <param name="UntilNumber2">To Voucher# for second period</param>
		/// <param name="Year1">Year refered to first period</param>
		/// <param name="Year2">Year refered to second period</param>
		/// <returns></returns>
		public virtual SalBoolean VouSerialValidate(SalNumber FromNumber1, SalNumber UntilNumber1, SalNumber FromNumber2, SalNumber UntilNumber2, SalNumber Year1, SalNumber Year2)
		{
			#region Actions
			using (new SalContext(this))
			{
				if (Year2 != Year1) 
				{
					return true;
				}
				else
				{
					if (FromNumber2 > UntilNumber1 || UntilNumber2 < FromNumber1) 
					{
						return true;
					}
					else
					{
						Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_VouSerialValidate, Properties.Resources.WH_frmVouNoSerial, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
						return false;
					}
				}
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber EnableDisablePeriod()
		{
			#region Actions
			using (new SalContext(this))
			{
				lsPeriodUsed = SalString.Null;
                DbPLSQLBlock("{0} := &AO.COMPANY_FINANCE_API.Get_Use_Vou_No_Period({1} IN);", this.QualifiedVarBindName("lsPeriodUsed"), this.QualifiedVarBindName("i_sCompany"));
				if (lsPeriodUsed == "FALSE") 
				{   Sal.HideWindow(tblVoucherSeries_colnPeriod);    }
				else
				{   Sal.ShowWindow(tblVoucherSeries_colnPeriod);	}
			}
			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public new SalBoolean _DataSourceFocusOnFirst()
		{
			#region Actions
			using (new SalContext(this))
			{
				Sal.SetFocus(dfVoucherType);
			}

			return 0;
			#endregion
		}
        
        protected virtual void GetCompanyDescription()
        {
            #region Actions
            string stmt = @"BEGIN
                                {0}:=&AO.Company_Finance_API.Get_Description({1});
                            END;";

            DbPLSQLBlock(stmt, this.dfCompanyDesc.QualifiedBindName, this.cmbCompany.QualifiedBindName);
            #endregion
        }
		#endregion
		
		#region Window Actions
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void dlgVoucherType_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_CreateComplete:
                    dlgVoucherType_OnSAM_CreateComplete(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceQueryFieldName:
                    dlgVoucherType_OnPM_DataSourceQueryFieldName(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemEntered:
                    dlgVoucherType_OnPM_DataItemEntered(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_CreateComplete event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dlgVoucherType_OnSAM_CreateComplete(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Sys.SAM_CreateComplete, Sys.wParam, Sys.lParam)) 
			{
				Sal.DisableWindowAndLabel(this.pbFinish);
				if (!(Ifs.Fnd.ApplicationForms.Var.Component.IsWindowAvailable(Pal.GetActiveInstanceName("tbwInternalLedger")))) 
				{
					Sal.DisableWindow(this.cmbLedger);
					Sal.DisableWindow(this.cbManualMethods);
					Sal.DisableWindow(this.cbBalance);
					this.bIntled = false;
				}
				else
				{
					Sal.EnableWindow(this.cmbLedger);
					Sal.EnableWindow(this.cbManualMethods);
					Sal.EnableWindow(this.cbBalance);
					this.bIntled = true;
				}
				this.GetDefaults();
				this.dfsCompany.Text = this.i_sCompany;
				Sal.DisableWindowAndLabel(this.pbNew1);
				Sal.DisableWindowAndLabel(this.pbRemove1);
				e.Return = true;
				return;
			}
			#endregion
		}
		
		/// <summary>
		/// PM_DataSourceQueryFieldName event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dlgVoucherType_OnPM_DataSourceQueryFieldName(object sender, WindowActionsEventArgs e)
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
						e.Return = (this.i_hWndFrame.ToNumber().ToString(0) + ".dlgVoucherType.i_sCompany").ToHandle();
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
		/// PM_DataItemEntered event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dlgVoucherType_OnPM_DataItemEntered(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			// Check for LOV settings for the current field
			Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemEntered, Sys.wParam, Sys.lParam);
			this.hWndFocusField = Sys.wParam.ToWindowHandle();
			this.pbList.MethodInvestigateState();
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void dfVoucherType_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
					this.dfVoucherType_OnPM_DataItemValidate(sender, e);
					break;
				
				case Sys.SAM_AnyEdit:
					this.dfVoucherType_OnSAM_AnyEdit(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// PM_DataItemValidate event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfVoucherType_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam)) 
			{
				if (this.dfVoucherType.Text != Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
					using(SignatureHints hints = SignatureHints.NewContext())
					{
						hints.Add("VOUCHER_TYPE_API.Voucher_Type_Exists", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
						if (!(this.dfVoucherType.DbPLSQLBlock(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + " VOUCHER_TYPE_API.Voucher_Type_Exists(\r\n" +
							" :i_hWndFrame.dlgVoucherType.dfsCompany,\r\n" +
							" :i_hWndFrame.dlgVoucherType.dfVoucherType )"))) 
						{
							Sal.DisableWindowAndLabel(this.pbNext);
							e.Return = false;
							return;
						}
					}
					Sal.EnableWindowAndLabel(this.pbNext);
				}
				else
				{
					Sal.DisableWindowAndLabel(this.pbNext);
				}
				e.Return = true;
				return;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_AnyEdit event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfVoucherType_OnSAM_AnyEdit(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if ((this.dfVoucherType.Text == Ifs.Fnd.ApplicationForms.Const.strNULL) || (this.dfVouTypeDesc.Text == Ifs.Fnd.ApplicationForms.Const.strNULL)) 
			{
				Sal.DisableWindowAndLabel(this.pbNext);
			}
			else
			{
				Sal.EnableWindowAndLabel(this.pbNext);
			}
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void dfVouTypeDesc_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_AnyEdit:
					this.dfVouTypeDesc_OnSAM_AnyEdit(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_AnyEdit event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfVouTypeDesc_OnSAM_AnyEdit(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if ((this.dfVoucherType.Text == Ifs.Fnd.ApplicationForms.Const.strNULL) || (this.dfVouTypeDesc.Text == Ifs.Fnd.ApplicationForms.Const.strNULL)) 
			{
				Sal.DisableWindowAndLabel(this.pbNext);
			}
			else
			{
				Sal.EnableWindowAndLabel(this.pbNext);
			}
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void cmbLedger_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Click:
					this.cmbLedger_OnSAM_Click(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_LookupInit:
					this.cmbLedger_OnPM_LookupInit(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_Click event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cmbLedger_OnSAM_Click(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			Sal.SendClassMessage(Sys.SAM_Click, Sys.wParam, Sys.lParam);
			if (Sal.ListQueryState(this.cmbLedger, 2)) 
			{
				// Internal Ledger
				// Ledger Id
				Sal.ClearField(this.dfLedgerID);
				Sal.EnableWindow(this.dfLedgerID);
				this.dfLedgerID.EditDataItemSetEdited();
				// Use Manual Internal Methods
				Sal.DisableWindow(this.cbManualMethods);
				// Balance Mandatory
				Sal.EnableWindow(this.cbBalance);
				this.bInternal = true;
			}
			else
			{
				// All Ledgers or General Ledger
				// Ledger Id
				this.GetLedgerID();
				Sal.DisableWindow(this.dfLedgerID);
				// Use Manual Internal Methods
				if (Sal.ListQueryState(this.cmbLedger, 1)) 
				{
					// General Ledger
					this.cbManualMethods.EditDataItemValueSet(1, ((SalString)"FALSE").ToHandle());
					Sal.DisableWindow(this.cbManualMethods);
				}
				else
				{
					Sal.EnableWindow(this.cbManualMethods);
				}
				// Balance Mandatory
				this.cbBalance.EditDataItemValueSet(1, ((SalString)"TRUE").ToHandle());
				Sal.DisableWindow(this.cbBalance);
				this.bInternal = false;
			}
			this.cmbLedger.EditDataItemValueSet(0, this.cmbLedger.i_sMyValue.ToHandle());
			#endregion
		}
		
		/// <summary>
		/// PM_LookupInit event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cmbLedger_OnPM_LookupInit(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_LookupInit, Sys.wParam, Sys.lParam)) 
			{
				Sal.ListDelete(this.cmbLedger.i_hWndSelf, 3);
				Sal.ListDelete(this.cmbLedger.i_hWndSelf, 3);
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
		private void cbManualMethods_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Create:
					this.cbManualMethods_OnSAM_Create(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_Create event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cbManualMethods_OnSAM_Create(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam)) 
			{
				this.cbManualMethods.i_sCheckedValue = "TRUE";
				this.cbManualMethods.i_sUncheckedValue = "FALSE";
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
		private void cbBalance_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Create:
					this.cbBalance_OnSAM_Create(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_Create event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cbBalance_OnSAM_Create(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam)) 
			{
				this.cbBalance.i_sCheckedValue = "TRUE";
				this.cbBalance.i_sUncheckedValue = "FALSE";
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
		private void tblFunctionGroup_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_CreateComplete:
					this.tblFunctionGroup_OnSAM_CreateComplete(sender, e);
					break;
                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew:
                    this.tblFunctionGroup_OnPM_DataRecordNew(sender,e);
                    break;
				case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove:
					this.tblFunctionGroup_OnPM_DataRecordRemove(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_CreateComplete event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblFunctionGroup_OnSAM_CreateComplete(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Sys.SAM_CreateComplete, Sys.wParam, Sys.lParam)) 
			{
				Sal.DisableWindowAndLabel(this.pbFinish);
				// Bug 75691, Removed the db block since the fetched values arent used anywhere
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
        private void tblFunctionGroup_OnPM_DataRecordNew(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire)
            {
                if (Sal.TblAnyRows(tblFunctionGroup, 0, 0))
                { 
                    this.bSingle = this.cbSingleFunction.Checked; 
                }
                else
                { 
                    this.bSingle = false; 
                }
                e.Return = ((bool)((cDataSource)tblFunctionGroup).DataRecordNew(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire)) && (!(Sal.IsNull(this.dfVoucherType))) && (tblFunctionGroup_colsSingleFunction.Text != "Y") && (this.bSingle != true);
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
		private void tblFunctionGroup_OnPM_DataRecordRemove(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove, Sys.wParam, Sys.lParam)) 
			{
				if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire) 
				{
					e.Return = true;
					return;
				}
				if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
				{
					if (!(Sal.TblAnyRows(dlgVoucherType.FromHandle(this.tblFunctionGroup.i_hWndFrame).tblFunctionGroup, 0, 0))) 
					{
						this.DisableSelection();
					}
					else
					{
						this.EnableSelection();
					}
					e.Return = true;
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
		private void cbAutomaticAllot_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Create:
					this.cbAutomaticAllot_OnSAM_Create(sender, e);
					break;
				
				case Sys.SAM_Click:
					this.cbAutomaticAllot_OnSAM_Click(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_Create event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cbAutomaticAllot_OnSAM_Create(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam)) 
			{
				this.cbAutomaticAllot.i_sCheckedValue = "Y";
				this.cbAutomaticAllot.i_sUncheckedValue = "N";
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
		private void cbAutomaticAllot_OnSAM_Click(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.bAutoAllot = this.cbAutomaticAllot.Checked;
			if (!(Sal.IsNull(this.dfVoucherType))) 
			{
				if (!(this.cbAutomaticAllot.Checked)) 
				{
					this.CheckAutoAllotment();
				}
			}
			Sal.SendClassMessage(Sys.SAM_Click, Sys.wParam, Sys.lParam);
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void cbSingleFunction_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Create:
					this.cbSingleFunction_OnSAM_Create(sender, e);
					break;
				
				case Sys.SAM_Click:
					this.cbSingleFunction_OnSAM_Click(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_Create event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cbSingleFunction_OnSAM_Create(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam)) 
			{
				this.cbSingleFunction.i_sCheckedValue = "Y";
				this.cbSingleFunction.i_sUncheckedValue = "N";
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
		private void cbSingleFunction_OnSAM_Click(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (!(Sal.IsNull(this.dfVoucherType))) 
			{
				if (this.tblFunctionGroup_colsSingleFunction.Text != "Y") 
				{
					if (this.cbSingleFunction.Checked == true) 
					{
						if (!(this.CheckSingleRow())) 
						{
							Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_NoSingleGrp, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
							this.cbSingleFunction.EditDataItemValueSet(0, ((SalString)"N").ToHandle());
						}
					}
				}
				else
				{
					if (this.cbSingleFunction.Checked == false) 
					{
						Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_SingleGrpReq, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
						this.cbSingleFunction.EditDataItemValueSet(0, ((SalString)"Y").ToHandle());
					}
					if (this.cbSingleFunction.Checked == true) 
					{
						if (!(this.CheckSingleRow())) 
						{
							Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_NoSingleGrp, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
							this.cbSingleFunction.EditDataItemValueSet(0, ((SalString)"N").ToHandle());
						}
					}
				}
				if (this.cbSingleFunction.Checked == false) 
				{
					Sal.EnableWindow(this.pbNew1);
				}
				else
				{
					Sal.DisableWindow(this.pbNew1);
				}
			}
			e.Return = Sal.SendClassMessage(Sys.SAM_Click, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void cbSimulationVoucher_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Create:
					this.cbSimulationVoucher_OnSAM_Create(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_Create event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cbSimulationVoucher_OnSAM_Create(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam)) 
			{
				this.cbSimulationVoucher.i_sCheckedValue = "TRUE";
				this.cbSimulationVoucher.i_sUncheckedValue = "FALSE";
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
		private void cbFromExisting_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Click:
					this.cbFromExisting_OnSAM_Click(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_Click event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cbFromExisting_OnSAM_Click(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Sys.SAM_Click, Sys.wParam, Sys.lParam)) 
			{
				if (Sal.IsButtonChecked(this.cbFromExisting)) 
				{
					Sal.EnableWindowAndLabel(this.dfsExistingVouType);
					Sal.DisableWindowAndLabel(this.pbNext);
					if (this.dfsExistingVouType.Text != Ifs.Fnd.ApplicationForms.Const.strNULL) 
					{
						Sal.EnableWindowAndLabel(this.pbFinish);
					}
				}
				else
				{
					Sal.DisableWindowAndLabel(this.dfsExistingVouType);
					Sal.DisableWindowAndLabel(this.pbFinish);
					Sal.EnableWindowAndLabel(this.pbNext);
				}
				e.Return = true;
				return;
			}
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void dfsExistingVouType_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
					this.dfsExistingVouType_OnPM_DataItemValidate(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovDone:
					this.dfsExistingVouType_OnPM_DataItemLovDone(sender, e);
					break;
				
				case Sys.SAM_AnyEdit:
					this.dfsExistingVouType_OnSAM_AnyEdit(sender, e);
					break;

                case Sys.SAM_SetFocus:
                    e.Handled = true;
                    Sal.EnableWindowAndLabel(this.pbList);
                    this.hWithFocus = dfsExistingVouType.i_hWndSelf;
                    break;
			}
			#endregion
		}
		
		/// <summary>
		/// PM_DataItemValidate event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfsExistingVouType_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam)) 
			{
				if (this.dfsExistingVouType.Text != Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
					using(SignatureHints hints = SignatureHints.NewContext())
					{
						hints.Add("VOUCHER_TYPE_API.Exist", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
						if (!(this.dfsExistingVouType.DbPLSQLBlock(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + " VOUCHER_TYPE_API.Exist(\r\n" +
							" :i_hWndFrame.dlgVoucherType.dfsCompany,\r\n" +
							" :i_hWndFrame.dlgVoucherType.dfsExistingVouType )"))) 
						{
							Sal.DisableWindowAndLabel(this.pbFinish);
							e.Return = false;
							return;
						}
						else
						{
							Sal.EnableWindowAndLabel(this.pbFinish);
							e.Return = true;
							return;
						}
					}
				}
				else
				{
					if (Sal.IsButtonChecked(this.cbFromExisting)) 
					{
						Sal.DisableWindowAndLabel(this.pbFinish);
					}
				}
				e.Return = true;
				return;
			}
			#endregion
		}
		
		/// <summary>
		/// PM_DataItemLovDone event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfsExistingVouType_OnPM_DataItemLovDone(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (this.dfsExistingVouType.Text != Ifs.Fnd.ApplicationForms.Const.strNULL) 
			{
				Sal.EnableWindowAndLabel(this.pbFinish);
			}
			else
			{
				Sal.DisableWindowAndLabel(this.pbFinish);
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_AnyEdit event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfsExistingVouType_OnSAM_AnyEdit(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (this.dfsExistingVouType.Text != Ifs.Fnd.ApplicationForms.Const.strNULL) 
			{
				Sal.EnableWindowAndLabel(this.pbFinish);
			}
			else
			{
				Sal.DisableWindowAndLabel(this.pbFinish);
			}
			e.Return = Sal.SendClassMessage(Sys.SAM_AnyEdit, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void dfUserGroupDesc_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_SetFocus:
					this.dfUserGroupDesc_OnSAM_SetFocus(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfUserGroupDesc_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
			Sys.wParam = this.dfUserGroupDesc.i_hWndSelf.ToNumber();
			Sal.SendMsg(this.dfUserGroupDesc.i_hWndFrame, Ifs.Fnd.ApplicationForms.Const.PM_DataItemEntered, Sys.wParam, Sys.lParam);
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void rbSingle_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_SetFocus:
					e.Handled = true;
					Sal.EnableWindow(this.cmbFunctionGroup);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void rbAll_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_SetFocus:
					this.rbAll_OnSAM_SetFocus(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void rbAll_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			Sal.ClearField(this.cmbFunctionGroup);
			Sal.DisableWindow(this.cmbFunctionGroup);
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void cmbFunctionGroup_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_DropDown:
					this.cmbFunctionGroup_OnSAM_DropDown(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_DropDown event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cmbFunctionGroup_OnSAM_DropDown(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			Sal.ListClear(this.cmbFunctionGroup);
			this.PopulateFunctionGroups();
			Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void pbNext_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Click:
					this.pbNext_OnSAM_Click(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_Click event handler.
		/// </summary>
		/// <param name="message"></param>
		private void pbNext_OnSAM_Click(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Sys.SAM_Click, Sys.wParam, Sys.lParam)) 
			{
				Sal.SendMsg(this, Ifs.Application.Accrul.Const.PAM_GetAndSetDefaultCompany, 0, 0);
				e.Return = true;
				return;
			}
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void pbBack_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Click:
					this.pbBack_OnSAM_Click(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_Click event handler.
		/// </summary>
		/// <param name="message"></param>
		private void pbBack_OnSAM_Click(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Sys.SAM_Click, Sys.wParam, Sys.lParam)) 
			{
				Sal.SendMsg(this, Ifs.Application.Accrul.Const.PAM_GetAndSetDefaultCompany, 0, 0);
				e.Return = true;
				return;
			}
			#endregion
		}

        private void dfUserGroup_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    e.Handled = true;
                    this.hWithFocus = dfUserGroup.i_hWndSelf;
                    Sal.EnableWindowAndLabel(this.pbList);
                    break;
            }
            #endregion
        }

        private void dfLedgerID_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    e.Handled = true;
                    this.hWithFocus = dfLedgerID.i_hWndSelf;
                    Sal.EnableWindowAndLabel(this.pbList);
                    break;
            }
            #endregion
        }

        private void cmbCompany_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_Click:
                    this.cmbCompany_OnSAM_Click(sender, e);
                    break;
            }
            #endregion
        }

        private void cmbCompany_OnSAM_Click(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            GetCompanyDescription();
            UserGlobalValueSet("COMPANY", this.cmbCompany.Text);
            Sal.SendMsg(this, Ifs.Application.Accrul.Const.PAM_GetAndSetDefaultCompany, 0, 0);
            dfsCompany.Text = this.cmbCompany.Text;
            EnableDisablePeriod();
            #endregion
        }

		#endregion
		
		#region Late Bind Methods
		
		/// <summary>
		/// Virtual wrapper replacement for late-bound (..) calls.
		/// </summary>
		public override SalNumber vrtDataSourceInquireSave()
		{
			return this.DataSourceInquireSave();
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
		
		/// <summary>
		/// Virtual wrapper replacement for late-bound (..) calls.
		/// </summary>
		public override SalNumber vrtUserMethod(SalNumber nWhat, SalString sMethod)
		{
			return this.UserMethod(nWhat, sMethod);
		}
		
		/// <summary>
		/// Virtual wrapper replacement for late-bound (..) calls.
		/// </summary>
		public override SalBoolean vrtWizardFinish(SalNumber nWhat, SalString sStep)
		{
			return this.WizardFinish(nWhat, sStep);
		}
		
		/// <summary>
		/// Virtual wrapper replacement for late-bound (..) calls.
		/// </summary>
		public override SalBoolean vrtWizardNext(SalNumber nWhat, SalString sStep)
		{
			return this.WizardNext(nWhat, sStep);
		}
		
		/// <summary>
		/// Virtual wrapper replacement for late-bound (..) calls.
		/// </summary>
		public override SalNumber vrtWizardStepActivated(SalString sStep)
		{
			return this.WizardStepActivated(sStep);
		}
		
		/// <summary>
		/// Virtual wrapper replacement for late-bound (..) calls.
		/// </summary>
		public override SalBoolean vrt_DataSourceFocusOnFirst()
		{
			return this._DataSourceFocusOnFirst();
		}
		#endregion

        #region ChildTable-tblFunctionGroup

        #region Methods

        /// <summary>
        /// Gets client default values for NEW records
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean tblFunctionGroup_DataRecordGetDefaults()
        {
            #region Actions
       
            tblFunctionGroup_colsCompany.Text = this.i_sCompany;
            tblFunctionGroup_colsCompany.EditDataItemSetEdited();
            tblFunctionGroup_colsVoucherType.Text = this.dfVoucherType.Text;
            tblFunctionGroup_colsVoucherType.EditDataItemSetEdited();
            tblFunctionGroup_colsAutomaticAllot.EditDataItemValueSet(1, ((SalString)"Y").ToHandle());
            tblFunctionGroup_colsOptionalAutoBalance.EditDataItemValueSet(1, ((SalString)"N").ToHandle());
            tblFunctionGroup_colsSingleFunction.EditDataItemValueSet(1, ((SalString)"N").ToHandle());
            tblFunctionGroup_colsStoreOriginal.EditDataItemValueSet(1, ((SalString)"N").ToHandle());
            return true;
            
            #endregion
        }

        /// <summary>
        /// Check if a Voucher Function exists
        /// </summary>
        /// <param name="p_sVoucherFunction"></param>
        /// <returns></returns>
        public virtual SalBoolean CheckFunctionGroup(SalString p_sVoucherFunction)
        {
            sVoucherFunction = p_sVoucherFunction;
            if (sVoucherFunction == SalString.Null)
            {  return true; }
            if (DbPLSQLBlock("&AO.Function_Group_API.Exist({0} IN)",this.QualifiedVarBindName("sVoucherFunction")))          
            {  return true; }
            return false;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean CheckSingleVoucherFunction()
        {
            #region Local Variables
            SalNumber nMinRow = 0;
            SalNumber nMaxRow = 0;
            SalNumber nPosRow = 0;
            SalNumber nMinRange = 0;
            SalNumber nMaxRange = 0;
            #endregion

            #region Actions
     
            Sal.TblQueryScroll(tblFunctionGroup, ref nPosRow, ref nMinRange, ref nMaxRange);
            nMinRow = nMinRange;
            nMaxRow = nMaxRange;
            return !(nMinRow != nMaxRow);
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean CheckSingleRow()
        {
            #region Local Variables
            SalNumber nMinRow = 0;
            SalNumber nMaxRow = 0;
            SalNumber nPosRow = 0;
            SalNumber nMinRange = 0;
            SalNumber nMaxRange = 0;
            #endregion

            #region Actions
        
            Sal.TblQueryScroll(tblFunctionGroup, ref nPosRow, ref nMinRange, ref nMaxRange);
            nMinRow = nMinRange;
            nMaxRow = nMaxRange;
            return !(nMinRow != nMaxRow);
          
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="p_sFunctionGroup"></param>
        /// <returns></returns>
        public virtual SalBoolean GetAutoAllotSingleFunc(SalString p_sFunctionGroup)
        {
            #region Actions
       
            sFunctionGroup = p_sFunctionGroup;
            IDictionary<string,string> namedBindVariables = new Dictionary<string,string>();
            namedBindVariables.Add("AutomaticAllot",this.tblFunctionGroup_colsAutomaticAllot.QualifiedBindName);
            namedBindVariables.Add("FunctionGroup",this.QualifiedVarBindName("sFunctionGroup"));
            namedBindVariables.Add("SingleFunction",this.tblFunctionGroup_colsSingleFunction.QualifiedBindName);
            string stmt = @"BEGIN
                                &AO.Voucher_Type_Detail_API.Is_Automatic_Allot_Required__({AutomaticAllot} INOUT, {FunctionGroup} IN);                     
                                &AO.Voucher_Type_Detail_API.Is_Single_Function_Required__({SingleFunction} INOUT, {FunctionGroup} IN);
                            END;"; 
            if (DbPLSQLBlock(stmt,namedBindVariables))
            {
                if (tblFunctionGroup_colsAutomaticAllot.Text == "Y")
                {
                    if (!(this.cbAutomaticAllot.Checked))
                    {
                        if (Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_AutoAllotReq, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok))
                        {
                            this.cbAutomaticAllot.EditDataItemValueSet(1, ((SalString)"Y").ToHandle());
                        }
                    }
                }
                if (tblFunctionGroup_colsSingleFunction.Text == "Y" && (!(this.cbSingleFunction.Checked)))
                {
                    if (CheckSingleRow())
                    {
                        if (Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_SingleGrpReq, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok))
                        {
                            this.cbSingleFunction.EditDataItemValueSet(1, ((SalString)"Y").ToHandle());
                        }
                    }
                    else
                    {
                        Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_FuncGrpInVal, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                        return false;
                    }
                }
                return true;
            }
            else
            { return false; }

            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean SendSelectedRows()
        {
            #region Local Variables
            SalNumber nRow = 0;
            SalNumber nRowCount = 0;
            SalNumber count = 0;
            #endregion

            #region Actions
        
            nRowCount = Sys.TBL_MinRow;
            while (Sal.TblFindNextRow(tblFunctionGroup, ref nRowCount, 0, Sys.ROW_MarkDeleted))
            {
                nRowCount = nRowCount;
            }
            this.id = 0;
            nRow = Sys.TBL_MinRow;
            while (nRow < nRowCount)
            {
                this.lsMainMessage = Ifs.Fnd.ApplicationForms.Const.strNULL;
                this.MainMessage.Construct();
                this.MainMessage.SetName("VOUCHER_TYPE_DETAIL");
                count = 0;
                while (Sal.TblFindNextRow(tblFunctionGroup, ref nRow, 0, Sys.ROW_MarkDeleted))
                {
                    Sal.TblSetContext(tblFunctionGroup, nRow);
                    count = count + 1;
                    this.lsSubMessage = Ifs.Fnd.ApplicationForms.Const.strNULL;
                    this.SubMessage.Construct();
                    this.SubMessage.AddAttribute("COMPANY", tblFunctionGroup_colsCompany.Text);
                    this.SubMessage.AddAttribute("VOUCHER_TYPE", tblFunctionGroup_colsVoucherType.Text);
                    this.SubMessage.AddAttribute("FUNCTION_GROUP", tblFunctionGroup_colsFunctionGroup.Text);
                    this.SubMessage.AddAttribute("AUTOMATIC_VOU_BALANCE", tblFunctionGroup_colsOptionalAutoBalance.Text);
                    this.SubMessage.AddAttribute("STORE_ORIGINAL", tblFunctionGroup_colsStoreOriginal.Text);
                    this.SubMessage.AddAttribute("SINGLE_FUNCTION_GROUP", tblFunctionGroup_colsSingleFunction.Text);
                    this.SubMessage.AddAttribute("AUTOMATIC_ALLOT", tblFunctionGroup_colsAutomaticAllot.Text);
                    this.SubMessage.AddAttribute("ROW_GROUP_VALIDATION", tblFunctionGroup_colsRowGrpValidation.Text);
                    this.SubMessage.AddAttribute("REFERENCE_MANDATORY", tblFunctionGroup_colsRefMandetory.Text);
                    this.lsSubMessage = this.SubMessage.Pack();
                    this.MainMessage.AddAttribute((65 + count).ToCharacter(), this.lsSubMessage);
                    this.lsMainMesgTemp = this.MainMessage.Pack();
                }
                this.lsMainMessage = this.MainMessage.Pack();
                return true;
            }
            return false;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber EnableSelection()
        {
            Sal.EnableWindow(this.cbAutomaticAllot);
            Sal.EnableWindow(this.cbSimulationVoucher);
            Sal.EnableWindow(this.cbSingleFunction);
            return 0;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber DisableSelection()
        {
            Sal.DisableWindow(this.cbAutomaticAllot);
            this.cbSingleFunction.EditDataItemValueSet(0, ((SalString)"Y").ToHandle());
            Sal.DisableWindow(this.cbSimulationVoucher);
            Sal.DisableWindow(this.cbSingleFunction);
            return 0; 
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber PopulateFunctionGroups()
        {
            SalNumber nRow = Sys.TBL_MinRow;
            while (Sal.TblFindNextRow(tblFunctionGroup, ref nRow, 0, Sys.ROW_MarkDeleted))
            {
                Sal.TblSetContext(tblFunctionGroup, nRow);
                Sal.ListAdd(this.cmbFunctionGroup, tblFunctionGroup_colsFunctionGroup.Text);
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
        private void tblFunctionGroup_colsFunctionGroup_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.tblFunctionGroup_colsFunctionGroup_OnSAM_SetFocus(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblFunctionGroup_colsFunctionGroup_OnPM_DataItemValidate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovUserOrderBy:
                    e.Handled = true;
                    e.Return = ((SalString)"FUNCTION_GROUP").ToHandle();
                    return;

                case Sys.SAM_KillFocus:
                    this.tblFunctionGroup_colsFunctionGroup_OnSAM_KillFocus(sender, e);
                    break;

                case Sys.SAM_AnyEdit:
                    this.tblFunctionGroup_colsFunctionGroup_OnSAM_AnyEdit(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblFunctionGroup_colsFunctionGroup_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam))
            {
                if (this.bInternal)
                {
                    this.tblFunctionGroup_colsFunctionGroup.p_sLovReference = "FUNCTION_GROUP_INT";
                }
                else
                {
                    this.tblFunctionGroup_colsFunctionGroup.p_sLovReference = "FUNCTION_GROUP";
                }
            }
            // Sys.wParam holds the handle of the window losing the focus;
            // what we need is to send the handled of the current column with PM_DataItemEntered
            // so that dlgVoucherType_OnPM_DataItemEntered will pass it to the correct column.
            Sys.wParam = this.tblFunctionGroup_colsFunctionGroup.i_hWndSelf.ToNumber();
            Sal.SendMsg(this.tblFunctionGroup_colsFunctionGroup.i_hWndFrame, Ifs.Fnd.ApplicationForms.Const.PM_DataItemEntered, Sys.wParam, Sys.lParam);
            Sal.EnableWindowAndLabel(this.pbList);
            this.hWithFocus = this.tblFunctionGroup_colsFunctionGroup.i_hWndSelf;
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblFunctionGroup_colsFunctionGroup_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam))
            {
                if (this.CheckFunctionGroup(this.tblFunctionGroup_colsFunctionGroup.Text))
                {
                    if (!(Sal.IsNull(this.tblFunctionGroup_colsFunctionGroup)))
                    {
                        if ((this.tblFunctionGroup_colsFunctionGroup.Text == "C") || (this.tblFunctionGroup_colsFunctionGroup.Text == "Z") || (this.tblFunctionGroup_colsFunctionGroup.Text == "H") || (this.tblFunctionGroup_colsFunctionGroup.Text == "P") || (this.tblFunctionGroup_colsFunctionGroup.Text == "PPC"))
                        {
                            this.tblFunctionGroup_colsStoreOriginal.Text = "Y";
                            this.tblFunctionGroup_colsStoreOriginal.EditDataItemSetEdited();
                        }
                        else
                        {
                            this.tblFunctionGroup_colsStoreOriginal.Text = "N";
                            this.tblFunctionGroup_colsStoreOriginal.EditDataItemSetEdited();
                        }
                        if ((this.tblFunctionGroup_colsFunctionGroup.Text == "M") || (this.tblFunctionGroup_colsFunctionGroup.Text == "K") || (this.tblFunctionGroup_colsFunctionGroup.Text == "Q"))
                        {
                            Sal.EnableWindow(this.tblFunctionGroup_colsRowGrpValidation);
                            Sal.EnableWindow(this.tblFunctionGroup_colsRefMandetory);
                        }
                        else
                        {
                            this.tblFunctionGroup_colsRowGrpValidation.Text = "N";
                            Sal.DisableWindow(this.tblFunctionGroup_colsRowGrpValidation);
                            this.tblFunctionGroup_colsRefMandetory.Text = "N";
                            Sal.DisableWindow(this.tblFunctionGroup_colsRefMandetory);
                        }
                        this.EnableSelection();
                        if (this.GetAutoAllotSingleFunc(this.tblFunctionGroup_colsFunctionGroup.Text))
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
                    e.Return = Sys.VALIDATE_Ok;
                    return;
                }
                e.Return = Sys.VALIDATE_Cancel;
                return;
            }
            #endregion
        }

        /// <summary>
        /// SAM_KillFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblFunctionGroup_colsFunctionGroup_OnSAM_KillFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.CheckSingleRow() && Sal.IsNull(this.tblFunctionGroup_colsFunctionGroup))
            {
                this.DisableSelection();
            }
            else
            {
                this.EnableSelection();
            }
            if (this.cbSingleFunction.Checked == true && Sal.TblAnyRows(this, 0, 0) == true)
            {
                Sal.DisableWindow(this.pbNew1);
            }
            Sal.SendClassMessage(Sys.SAM_KillFocus, Sys.wParam, Sys.lParam);
            #endregion
        }

        /// <summary>
        /// SAM_AnyEdit event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblFunctionGroup_colsFunctionGroup_OnSAM_AnyEdit(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.tblFunctionGroup_colsFunctionGroup.Text == Ifs.Fnd.ApplicationForms.Const.strNULL)
            {
                Sal.DisableWindowAndLabel(this.pbNext);
            }
            else
            {
                Sal.EnableWindowAndLabel(this.pbNext);
            }
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblFunctionGroup_colDescription_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.tblFunctionGroup_colDescription_OnSAM_SetFocus(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblFunctionGroup_colDescription_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
            Sys.wParam = this.tblFunctionGroup_colDescription.i_hWndSelf.ToNumber();
            Sal.SendMsg(this.tblFunctionGroup_colDescription.i_hWndFrame, Ifs.Fnd.ApplicationForms.Const.PM_DataItemEntered, Sys.wParam, Sys.lParam);
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblFunctionGroup_colsStoreOriginal_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_Click:
                    this.tblFunctionGroup_colsStoreOriginal_OnSAM_Click(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_Click event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblFunctionGroup_colsStoreOriginal_OnSAM_Click(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if ((this.tblFunctionGroup_colsFunctionGroup.Text == "C") || (this.tblFunctionGroup_colsFunctionGroup.Text == "Z") || (this.tblFunctionGroup_colsFunctionGroup.Text == "H") || (this.tblFunctionGroup_colsFunctionGroup.Text == "P") || (this.tblFunctionGroup_colsFunctionGroup.Text == "PPC"))
            {
                Sal.DisableWindow(this.tblFunctionGroup_colsStoreOriginal);
            }
            else
            {
                Sal.EnableWindow(this.tblFunctionGroup_colsStoreOriginal);
            }
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblFunctionGroup_colsRowGrpValidation_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_Click:
                    this.tblFunctionGroup_colsRowGrpValidation_OnSAM_Click(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_Click event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblFunctionGroup_colsRowGrpValidation_OnSAM_Click(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if ((this.tblFunctionGroup_colsFunctionGroup.Text == "M") || (this.tblFunctionGroup_colsFunctionGroup.Text == "K") || (this.tblFunctionGroup_colsFunctionGroup.Text == "Q"))
            {
                Sal.EnableWindow(this.tblFunctionGroup_colsRowGrpValidation);
            }
            else
            {
                this.tblFunctionGroup_colsRowGrpValidation.Text = "N";
                Sal.DisableWindow(this.tblFunctionGroup_colsRowGrpValidation);
            }
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblFunctionGroup_colsRefMandetory_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_Click:
                    this.tblFunctionGroup_colsRefMandetory_OnSAM_Click(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_Click event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblFunctionGroup_colsRefMandetory_OnSAM_Click(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if ((this.tblFunctionGroup_colsFunctionGroup.Text == "M") || (this.tblFunctionGroup_colsFunctionGroup.Text == "K") || (this.tblFunctionGroup_colsFunctionGroup.Text == "Q"))
            {
                Sal.EnableWindow(this.tblFunctionGroup_colsRefMandetory);
            }
            else
            {
                this.tblFunctionGroup_colsRefMandetory.Text = "N";
                Sal.DisableWindow(this.tblFunctionGroup_colsRefMandetory);
            }
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblFunctionGroup_colsSingleFunction_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_AnyEdit:
                    this.tblFunctionGroup_colsSingleFunction_OnSAM_AnyEdit(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_AnyEdit event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblFunctionGroup_colsSingleFunction_OnSAM_AnyEdit(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.tblFunctionGroup_colsSingleFunction.Text == "Y")
            {
                if (!(this.CheckSingleVoucherFunction()))
                {
                    Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_NoSingleGrp, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                    this.tblFunctionGroup_colsSingleFunction.Text = "N";
                    Sal.SetFieldEdit(this.tblFunctionGroup_colsSingleFunction, false);
                    Sal.TblSetRowFlags(this, Sal.TblQueryContext(this), Sys.ROW_Edited, false);
                }
            }
            e.Return = Sal.SendClassMessage(Sys.SAM_AnyEdit, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }
        #endregion

        #region Window Events

        private void tblFunctionGroup_DataRecordGetDefaultsEvent(object sender, FndReturnEventArgsSalBoolean e)
        {
            e.Handled = true;
            e.ReturnValue = tblFunctionGroup_DataRecordGetDefaults();
        }

        #endregion

        #endregion

        #region ChildTable-tblVoucherSeries

        #region Methods
        /// <summary>
        /// Gets client default values for NEW records
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean tblVoucherSeries_DataRecordGetDefaults()
        {
            tblVoucherSeries_colsCompany.Text = this.i_sCompany;
            tblVoucherSeries_colsCompany.EditDataItemSetEdited();
            tblVoucherSeries_colsVoucherType.Text = this.dfVoucherType.Text;
            tblVoucherSeries_colsVoucherType.EditDataItemSetEdited();
            return true; 
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean SendVoucherSerieInfo()
        {
            #region Local Variables
            SalNumber nRow = 0;
            SalNumber nRowCount = 0;
            SalNumber count = 0;
            #endregion

            #region Actions
       
            nRowCount = Sys.TBL_MinRow;
            while (Sal.TblFindNextRow(tblVoucherSeries, ref nRowCount, 0, Sys.ROW_MarkDeleted))
            {
                nRowCount = nRowCount;
            }
            this.id = 0;
            nRow = Sys.TBL_MinRow;
            while (nRow < nRowCount)
            {
                this.lsMainMessageX = Ifs.Fnd.ApplicationForms.Const.strNULL;
                this.MainMessageX.Construct();
                this.MainMessageX.SetName("VOUCHER_SERIE_DETAIL");
                count = 0;
                while (Sal.TblFindNextRow(tblVoucherSeries, ref nRow, 0, Sys.ROW_MarkDeleted))
                {
                    Sal.TblSetContext(tblVoucherSeries, nRow);
                    count = count + 1;
                    this.lsSubMessageX = Ifs.Fnd.ApplicationForms.Const.strNULL;
                    this.SubMessageX.Construct();
                    this.SubMessageX.AddAttribute("COMPANY", tblVoucherSeries_colsCompany.Text);
                    this.SubMessageX.AddAttribute("VOUCHER_TYPE", tblVoucherSeries_colsVoucherType.Text);
                    this.SubMessageX.AddAttribute("ACCOUNTING_YEAR", tblVoucherSeries_colnAccountingYear.Number.ToString(0));
                    DbPLSQLBlock("{0}:= &AO.COMPANY_FINANCE_API.Get_Use_Vou_No_Period({1} IN );", this.QualifiedVarBindName("lsPeriodUsed"), this.QualifiedVarBindName("i_sCompany"));
                    if (this.lsPeriodUsed == "FALSE")
                    {
                        this.SubMessageX.AddAttribute("PERIOD", ((SalNumber)99).ToString(0));
                    }
                    else
                    {
                        this.SubMessageX.AddAttribute("PERIOD", tblVoucherSeries_colnPeriod.Number.ToString(0));
                    }
                    this.SubMessageX.AddAttribute("SERIE_FROM", tblVoucherSeries_colnSerieFrom.Number.ToString(0));
                    this.SubMessageX.AddAttribute("SERIE_UNTIL", tblVoucherSeries_colnSerieUntil.Number.ToString(0));
                    this.SubMessageX.AddAttribute("CURRENT_NUMBER", tblVoucherSeries_colnCurrentNumber.Number.ToString(0));
                    this.lsSubMessageX = this.SubMessageX.Pack();
                    this.MainMessageX.AddAttribute((65 + count).ToCharacter(), this.lsSubMessageX);
                    this.lsMainMesgTempX = this.MainMessageX.Pack();
                }
                this.lsMainMessageX = this.MainMessageX.Pack();
                return true;
            }
         

            return false;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean IsEmptyField()
        {
            return (Sal.IsNull(tblVoucherSeries_colnAccountingYear) || 
                    Sal.IsNull(tblVoucherSeries_colnSerieFrom)      || 
                    Sal.IsNull(tblVoucherSeries_colnSerieUntil)     || 
                    Sal.IsNull(tblVoucherSeries_colnCurrentNumber));
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber PeriodCheck()
        {
            #region Local Variables
            SalNumber nRow = 0;
            SalNumber nRow1 = 0;
            SalNumber FromNumber1 = 0;
            SalNumber UntilNumber1 = 0;
            SalNumber FromNumber2 = 0;
            SalNumber UntilNumber2 = 0;
            SalNumber Year1 = 0;
            SalNumber Year2 = 0;
            #endregion

            #region Actions
       
            nRow = Sys.TBL_MinRow;
            while (true)
            {
                if (Sal.TblFindNextRow(tblVoucherSeries, ref nRow, 0, Sys.ROW_MarkDeleted))
                {
                    Sal.TblSetContext(tblVoucherSeries, nRow);
                    Year1 = tblVoucherSeries_colnAccountingYear.Number;
                    FromNumber1 = tblVoucherSeries_colnSerieFrom.Number;
                    UntilNumber1 = tblVoucherSeries_colnSerieUntil.Number;
                    nRow1 = nRow;
                    while (true)
                    {
                        if (Sal.TblFindPrevRow(tblVoucherSeries, ref nRow1, 0, Sys.ROW_MarkDeleted))
                        {
                            Sal.TblSetContext(tblVoucherSeries, nRow1);
                            Year2 = tblVoucherSeries_colnAccountingYear.Number;
                            FromNumber2 = tblVoucherSeries_colnSerieFrom.Number;
                            UntilNumber2 = tblVoucherSeries_colnSerieUntil.Number;
                            if (!(this.VouSerialValidate(FromNumber2, UntilNumber2, FromNumber1, UntilNumber1, Year1, Year2)))
                            {
                                Sal.TblSetFocusRow(tblVoucherSeries, nRow);
                                return false;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                else
                {
                    break;
                }
            }
            return true;
       
            #endregion
        }
        #endregion

        #region Window Actions

        private void tblVoucherSeries_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew:
                    this.tblVoucherSeries_OnPM_DataRecordNew(sender, e);
                    break;
            }
            #endregion

        }

        /// <summary>
        /// PM_DataRecordNew event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherSeries_OnPM_DataRecordNew(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire)
            {
                e.Return = ((bool)((cDataSource)tblVoucherSeries).DataRecordNew(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire)) && (!(Sal.IsNull(this.dfVoucherType))) && (!(Sal.IsNull(this.tblFunctionGroup_colsFunctionGroup)));
                return;
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblVoucherSeries_colnAccountingYear_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    e.Handled = true;
                    this.hWithFocus = tblVoucherSeries_colnAccountingYear.i_hWndSelf;
                    Sal.EnableWindowAndLabel(this.pbList);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblVoucherSeries_colnSerieFrom_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblVoucherSeries_colnSerieFrom_OnPM_DataItemValidate(sender, e);
                    break;

                case Sys.SAM_SetFocus:
                    e.Handled = true;
                    Sal.DisableWindowAndLabel(this.pbList);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherSeries_colnSerieFrom_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (!(Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam)))
            {
                e.Return = Sys.VALIDATE_Cancel;
                return;
            }
            if (this.tblVoucherSeries_colnSerieFrom.Number < 0)
            {
                Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_SerieError1, Properties.Resources.WH_frmVouNoSerial, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                e.Return = Sys.VALIDATE_Cancel;
                return;
            }
            this.tblVoucherSeries_colnCurrentNumber.Number = this.tblVoucherSeries_colnSerieFrom.Number;
            this.tblVoucherSeries_colnCurrentNumber.EditDataItemSetEdited();
            e.Return = true;
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblVoucherSeries_colnSerieUntil_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    e.Handled = true;
                    Sal.DisableWindowAndLabel(this.pbList);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblVoucherSeries_colnCurrentNumber_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    e.Handled = true;
                    Sal.DisableWindowAndLabel(this.pbList);
                    break;
            }
            #endregion
        }

        private void tblVoucherSeries_colnPeriod_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    e.Handled = true;
                    this.hWithFocus = tblVoucherSeries_colnPeriod.i_hWndSelf;
                    Sal.EnableWindowAndLabel(this.pbList);
                    break;
            }
            #endregion
        }


        #endregion

        #region Window Events

        private void tblVoucherSeries_DataRecordGetDefaultsEvent(object sender, FndReturnEventArgsSalBoolean e)
        {
            e.Handled = true;
            e.ReturnValue = tblVoucherSeries_DataRecordGetDefaults();
        }

        #endregion    
       #endregion


    }
}
