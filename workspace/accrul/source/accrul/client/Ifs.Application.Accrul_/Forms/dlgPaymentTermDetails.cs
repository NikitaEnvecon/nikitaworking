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
	/// <param name="sCompany"></param>
	/// <param name="nNoOfInstallments"></param>
	/// <param name="nNoOfFreeDelivMonths"></param>
	/// <param name="nDaysToDueDate"></param>
	/// <param name="nDueDay1"></param>
	/// <param name="nDueDay2"></param>
	/// <param name="nDueDay3"></param>
	/// <param name="sInstituteId"></param>
	/// <param name="sWayId"></param>
	/// <param name="sEndOfMonth"></param>
	/// <param name="bIsVatDist"></param>
	public partial class dlgPaymentTermDetails : cDialogBoxFin
	{
		#region Window Parameters
		public SalString sCompany;
		public SalNumber nNoOfInstallments;
		public SalNumber nNoOfFreeDelivMonths;
		public SalNumber nDaysToDueDate;
		public SalNumber nDueDay1;
		public SalNumber nDueDay2;
		public SalNumber nDueDay3;
		public SalString sInstituteId;
		public SalString sWayId;
		public SalString sEndOfMonth;
		public SalBoolean bIsVatDist;
		#endregion
		
		#region Window Variables
		public SalWindowHandle hWndLovField = SalWindowHandle.Null;
		public SalString sMainCompany = "";
		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		protected dlgPaymentTermDetails()
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
		public static SalNumber ModalDialog(Control owner, ref SalString sCompany, ref SalNumber nNoOfInstallments, ref SalNumber nNoOfFreeDelivMonths, ref SalNumber nDaysToDueDate, ref SalNumber nDueDay1, ref SalNumber nDueDay2, ref SalNumber nDueDay3, ref SalString sInstituteId, ref SalString sWayId, ref SalString sEndOfMonth, ref SalBoolean bIsVatDist)
		{
			dlgPaymentTermDetails dlg = DialogFactory.CreateInstance<dlgPaymentTermDetails>();
			dlg.sCompany = sCompany;
			dlg.nNoOfInstallments = nNoOfInstallments;
			dlg.nNoOfFreeDelivMonths = nNoOfFreeDelivMonths;
			dlg.nDaysToDueDate = nDaysToDueDate;
			dlg.nDueDay1 = nDueDay1;
			dlg.nDueDay2 = nDueDay2;
			dlg.nDueDay3 = nDueDay3;
			dlg.sInstituteId = sInstituteId;
			dlg.sWayId = sWayId;
			dlg.sEndOfMonth = sEndOfMonth;
			dlg.bIsVatDist = bIsVatDist;
			SalNumber ret = dlg.ShowDialog(owner);
			sCompany = dlg.sCompany;
			nNoOfInstallments = dlg.nNoOfInstallments;
			nNoOfFreeDelivMonths = dlg.nNoOfFreeDelivMonths;
			nDaysToDueDate = dlg.nDaysToDueDate;
			nDueDay1 = dlg.nDueDay1;
			nDueDay2 = dlg.nDueDay2;
			nDueDay3 = dlg.nDueDay3;
			sInstituteId = dlg.sInstituteId;
			sWayId = dlg.sWayId;
			sEndOfMonth = dlg.sEndOfMonth;
			bIsVatDist = dlg.bIsVatDist;
			return ret;
		}
		
		/// <summary>
		/// Returns the object instance associated with the window handle.
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public new static dlgPaymentTermDetails FromHandle(SalWindowHandle handle)
		{
			return ((dlgPaymentTermDetails)SalWindow.FromHandle(handle, typeof(dlgPaymentTermDetails)));
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
			#region Actions
			using (new SalContext(this))
			{
				if (sMethod == "Cancel") 
				{
					return Cancel(nWhat);
				}
				if (sMethod == "Ok") 
				{
					return Ok(nWhat);
				}
				if (sMethod == "List") 
				{
					return List(nWhat);
				}
			}

			return false;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nWhat"></param>
		/// <returns></returns>
		public virtual SalBoolean Cancel(SalNumber nWhat)
		{
			#region Actions
			using (new SalContext(this))
			{
				switch (nWhat)
				{
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
						return true;
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
						return Sal.EndDialog(i_hWndSelf, Sys.IDCANCEL);
				}
			}

			return false;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nWhat"></param>
		/// <returns></returns>
		public virtual SalBoolean List(SalNumber nWhat)
		{
			#region Actions
			using (new SalContext(this))
			{
				switch (nWhat)
				{
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
						return false;
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
						if (hWndLovField != SalWindowHandle.Null) 
						{
							if (Sal.SendMsg(hWndLovField, Ifs.Fnd.ApplicationForms.Const.PM_DataItemLov, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0)) 
							{
								Sal.SendMsg(hWndLovField, Sys.SAM_Validate, 0, 0);
								Sal.SetFocus(hWndLovField);
								return Sal.PostMsg(hWndLovField, Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
							}
							else
							{
								Sal.SetFocus(hWndLovField);
							}
						}
						return true;
				}
			}

			return false;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nWhat"></param>
		/// <returns></returns>
		public virtual SalBoolean Ok(SalNumber nWhat)
		{
			#region Actions
			using (new SalContext(this))
			{
				switch (nWhat)
				{
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
						return true;
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
						nNoOfInstallments = dfnNoOfInstallments.Number;
						nNoOfFreeDelivMonths = dfnNoOfFreeDelivMonths.Number;
						nDaysToDueDate = dfnDaysToDueDate.Number;
						nDueDay1 = dfnDueDay1.Number;
						nDueDay2 = dfnDueDay2.Number;
						nDueDay3 = dfnDueDay3.Number;
						sInstituteId = dfsInstituteId.Text;
						sWayId = dfWayId.Text;
						if (!(cbEndOfMonth.Checked)) 
						{
							sEndOfMonth = "FALSE";
						}
						else
						{
							sEndOfMonth = "TRUE";
						}
						if (dfnNoOfInstallments.Number < 1) 
						{
							Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.ERROR_CheckNoOfInstallments, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
							Sal.SetFocus(dfnNoOfInstallments);
							return false;
						}
						return Sal.EndDialog(i_hWndSelf, Sys.IDOK);
				}
			}

			return false;
			#endregion
		}
		
		/// <summary>
		/// Validates This Field
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean ValidateDueDate1()
		{
			#region Actions
			using (new SalContext(this))
			{
				if (Sal.IsNull(dfnDueDay1)) 
				{
					return Sys.VALIDATE_Ok;
				}
				if (dfnDueDay1.Number < 1 || dfnDueDay1.Number > 31) 
				{
					Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.ERROR_DueDateSpecific, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
					dfnDueDay1.Number = Sys.NUMBER_Null;
					return Sys.VALIDATE_Cancel;
				}
				else
				{
					return Sys.VALIDATE_Ok;
				}
			}
			#endregion
		}
		
		/// <summary>
		/// Validates This Field
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean ValidateDueDate2()
		{
			#region Actions
			using (new SalContext(this))
			{
				if (Sal.IsNull(dfnDueDay2)) 
				{
					return Sys.VALIDATE_Ok;
				}
				if (dfnDueDay2.Number < 1 || dfnDueDay2.Number > 31) 
				{
					Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.ERROR_DueDateSpecific, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
					dfnDueDay2.Number = Sys.NUMBER_Null;
					return Sys.VALIDATE_Cancel;
				}
				else
				{
					return Sys.VALIDATE_Ok;
				}
			}
			#endregion
		}
		
		/// <summary>
		/// Validates This Field
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean ValidateDueDate3()
		{
			#region Actions
			using (new SalContext(this))
			{
				if (Sal.IsNull(dfnDueDay3)) 
				{
					return Sys.VALIDATE_Ok;
				}
				if (dfnDueDay3.Number < 1 || dfnDueDay3.Number > 31) 
				{
					Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.ERROR_DueDateSpecific, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
					dfnDueDay3.Number = Sys.NUMBER_Null;
					return Sys.VALIDATE_Cancel;
				}
				else
				{
					return Sys.VALIDATE_Ok;
				}
			}
			#endregion
		}
		
		/// <summary>
		/// Validates This Field
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean ValidateNoOfInstallments()
		{
			#region Actions
			using (new SalContext(this))
			{
				if (Sal.IsNull(dfnNoOfInstallments)) 
				{
					return Sys.VALIDATE_Ok;
				}
				if ((dfnNoOfInstallments.Number < 2) && bIsVatDist) 
				{
					Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.ERROR_NoOfInstallments, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
					dfnNoOfInstallments.Number = Sys.NUMBER_Null;
					return Sys.VALIDATE_Cancel;
				}
				else if (dfnNoOfInstallments.Number < 1) 
				{
					Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.ERROR_CheckNoOfInstallments, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
					dfnNoOfInstallments.Number = Sys.NUMBER_Null;
					return Sys.VALIDATE_Cancel;
				}
				else
				{
					return Sys.VALIDATE_Ok;
				}
			}
			#endregion
		}
		
		/// <summary>
		/// Validates This Field
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean ValidateNoOfFreeDelivMonths()
		{
			#region Actions
			using (new SalContext(this))
			{
				if (Sal.IsNull(dfnNoOfFreeDelivMonths)) 
				{
					return Sys.VALIDATE_Ok;
				}
				if (dfnNoOfFreeDelivMonths.Number < 0) 
				{
					Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.ERROR_NoOfFreeDelivMonths, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
					dfnNoOfFreeDelivMonths.Number = Sys.NUMBER_Null;
					return Sys.VALIDATE_Cancel;
				}
				else
				{
					return Sys.VALIDATE_Ok;
				}
			}
			#endregion
		}
		
		/// <summary>
		/// Validates This Field
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean ValidateDaysToDueDate()
		{
			#region Actions
			using (new SalContext(this))
			{
				if (Sal.IsNull(dfnDaysToDueDate)) 
				{
					return Sys.VALIDATE_Ok;
				}
				if (dfnDaysToDueDate.Number < 1) 
				{
					Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.ERROR_DaysToDueDate, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
					dfnDaysToDueDate.Number = Sys.NUMBER_Null;
					return Sys.VALIDATE_Cancel;
				}
				else
				{
					return Sys.VALIDATE_Ok;
				}
			}
			#endregion
		}
		
		/// <summary>
		/// Validates This Field
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean ValidatePaymentMethod()
		{
			#region Local Variables
			SalBoolean bOk = false;
			SalBoolean bInstituteOk = false;
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				if (Sal.IsNull(dfWayId)) 
				{
					return Sys.VALIDATE_Ok;
				}
				sMainCompany = i_sCompany;
				if (Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("PAYMENT_WAY_API.Exist")) 
				{
					using(SignatureHints hints = SignatureHints.NewContext())
					{
						hints.Add("PAYMENT_WAY_API.Exist", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
						bOk = DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN \r\n" + cSessionManager.c_sDbPrefix + "PAYMENT_WAY_API.Exist(\r\n" +
							" :i_hWndFrame.dlgPaymentTermDetails.sMainCompany, \r\n" +
							" :i_hWndFrame.dlgPaymentTermDetails.dfWayId\r\n" +
							");  \r\n END;");
					}
				}
				else
				{
					dfWayId.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
					return Sys.VALIDATE_Cancel;
				}
				if (bOk && !(Sal.IsNull(dfsInstituteId))) 
				{
					if (Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Payment_Way_Per_Institute_API.New_Exist")) 
					{
						using(SignatureHints hints = SignatureHints.NewContext())
						{
							hints.Add("Payment_Way_Per_Institute_API.New_Exist", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
							bInstituteOk = DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN " + cSessionManager.c_sDbPrefix + "Payment_Way_Per_Institute_API.New_Exist(\r\n" +
								"                                     :i_hWndFrame.dlgPaymentTermDetails.sMainCompany, \r\n" +
								"                                      :i_hWndFrame.dlgPaymentTermDetails.dfsInstituteId,\r\n" +
								"                                     :i_hWndFrame.dlgPaymentTermDetails.dfWayId );  \r\n END;");
						}
					}
					if (bInstituteOk) 
					{
						return Sys.VALIDATE_Ok;
					}
					else
					{
						dfWayId.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
						return Sys.VALIDATE_Cancel;
					}
				}
				else
				{
					return Sys.VALIDATE_Ok;
				}
			}
			#endregion
		}
		
		/// <summary>
		/// Validates This Field
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean ValidatePaymentInstitute()
		{
			#region Local Variables
			SalBoolean bOk = false;
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				if (Sal.IsNull(dfsInstituteId)) 
				{
					return Sys.VALIDATE_Ok;
				}
				sMainCompany = i_sCompany;
				if (Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Payment_Institute_API.Exist")) 
				{
					using(SignatureHints hints = SignatureHints.NewContext())
					{
						hints.Add("Payment_Institute_API.Exist", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
						bOk = DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN " + cSessionManager.c_sDbPrefix + "Payment_Institute_API.Exist(\r\n" +
							"                              :i_hWndFrame.dlgPaymentTermDetails.sMainCompany, \r\n" +
							"                              :i_hWndFrame.dlgPaymentTermDetails.dfsInstituteId );  \r\n END;");
					}
				}
				if (bOk) 
				{
					return Sys.VALIDATE_Ok;
				}
				else
				{
					dfsInstituteId.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
					return Sys.VALIDATE_Cancel;
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
		private void dlgPaymentTermDetails_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Create:
					this.dlgPaymentTermDetails_OnSAM_Create(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_Create event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dlgPaymentTermDetails_OnSAM_Create(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.i_sCompany = this.sCompany;
			this.cbEndOfMonth.Checked = this.sEndOfMonth;
			this.dfnDaysToDueDate.Number = this.nDaysToDueDate;
			this.dfnNoOfFreeDelivMonths.Number = this.nNoOfFreeDelivMonths;
			Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam);
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void dfnNoOfInstallments_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_SetFocus:
					this.dfnNoOfInstallments_OnSAM_SetFocus(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
					e.Handled = true;
					e.Return = this.ValidateNoOfInstallments();
					return;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfnNoOfInstallments_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam)) 
			{
				if (this.dfnNoOfInstallments.p_sLovReference != Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
					Sal.EnableWindow(this.pbList);
					this.hWndLovField = this.dfnNoOfInstallments.i_hWndSelf;
				}
				else
				{
					if (Sal.IsWindowEnabled(this.pbList)) 
					{
						Sal.DisableWindow(this.pbList);
					}
				}
			}
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void dfnNoOfFreeDelivMonths_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_SetFocus:
					this.dfnNoOfFreeDelivMonths_OnSAM_SetFocus(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
					e.Handled = true;
					e.Return = this.ValidateNoOfFreeDelivMonths();
					return;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfnNoOfFreeDelivMonths_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam)) 
			{
				if (this.dfnNoOfFreeDelivMonths.p_sLovReference != Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
					Sal.EnableWindow(this.pbList);
					this.hWndLovField = this.dfnNoOfFreeDelivMonths.i_hWndSelf;
				}
				else
				{
					if (Sal.IsWindowEnabled(this.pbList)) 
					{
						Sal.DisableWindow(this.pbList);
					}
				}
			}
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void dfnDaysToDueDate_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_SetFocus:
					this.dfnDaysToDueDate_OnSAM_SetFocus(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
					e.Handled = true;
					e.Return = this.ValidateDaysToDueDate();
					return;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfnDaysToDueDate_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam)) 
			{
				if (this.dfnDaysToDueDate.p_sLovReference != Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
					Sal.EnableWindow(this.pbList);
					this.hWndLovField = this.dfnDaysToDueDate.i_hWndSelf;
				}
				else
				{
					if (Sal.IsWindowEnabled(this.pbList)) 
					{
						Sal.DisableWindow(this.pbList);
					}
				}
			}
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void cbEndOfMonth_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_SetFocus:
					this.cbEndOfMonth_OnSAM_SetFocus(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cbEndOfMonth_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam)) 
			{
				if (this.cbEndOfMonth.p_sLovReference != Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
					Sal.EnableWindow(this.pbList);
					this.hWndLovField = this.cbEndOfMonth.i_hWndSelf;
				}
				else
				{
					if (Sal.IsWindowEnabled(this.pbList)) 
					{
						Sal.DisableWindow(this.pbList);
					}
				}
			}
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void dfnDueDay1_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_SetFocus:
					this.dfnDueDay1_OnSAM_SetFocus(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
					e.Handled = true;
					e.Return = this.ValidateDueDate1();
					return;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfnDueDay1_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam)) 
			{
				if (this.dfnDueDay1.p_sLovReference != Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
					Sal.EnableWindow(this.pbList);
					this.hWndLovField = this.dfnDueDay1.i_hWndSelf;
				}
				else
				{
					if (Sal.IsWindowEnabled(this.pbList)) 
					{
						Sal.DisableWindow(this.pbList);
					}
				}
			}
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void dfnDueDay2_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_SetFocus:
					this.dfnDueDay2_OnSAM_SetFocus(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
					e.Handled = true;
					e.Return = this.ValidateDueDate2();
					return;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfnDueDay2_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam)) 
			{
				if (this.dfnDueDay2.p_sLovReference != Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
					Sal.EnableWindow(this.pbList);
					this.hWndLovField = this.dfnDueDay2.i_hWndSelf;
				}
				else
				{
					if (Sal.IsWindowEnabled(this.pbList)) 
					{
						Sal.DisableWindow(this.pbList);
					}
				}
			}
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void dfnDueDay3_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_SetFocus:
					this.dfnDueDay3_OnSAM_SetFocus(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
					e.Handled = true;
					e.Return = this.ValidateDueDate3();
					return;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfnDueDay3_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam)) 
			{
				if (this.dfnDueDay3.p_sLovReference != Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
					Sal.EnableWindow(this.pbList);
					this.hWndLovField = this.dfnDueDay3.i_hWndSelf;
				}
				else
				{
					if (Sal.IsWindowEnabled(this.pbList)) 
					{
						Sal.DisableWindow(this.pbList);
					}
				}
			}
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void dfsInstituteId_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_SetFocus:
					this.dfsInstituteId_OnSAM_SetFocus(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovUserWhere:
					this.dfsInstituteId_OnPM_DataItemLovUserWhere(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
					e.Handled = true;
					e.Return = this.ValidatePaymentInstitute();
					return;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfsInstituteId_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (this.dfWayId.Text == Ifs.Fnd.ApplicationForms.Const.strNULL) 
			{
				if (Ifs.Fnd.ApplicationForms.Var.Security.AreAllViewsAvailable("PAYMENT_INSTITUTE")) 
				{
					this.dfsInstituteId.p_sLovReference = "PAYMENT_INSTITUTE(COMPANY)";
				}
				else
				{
					this.dfsInstituteId.p_sLovReference = Ifs.Fnd.ApplicationForms.Const.strNULL;
				}
			}
			else
			{
				if (Ifs.Fnd.ApplicationForms.Var.Security.AreAllViewsAvailable("PAYMENT_INSTITUTE_PER_WAY_ID")) 
				{
					this.dfsInstituteId.p_sLovReference = "PAYMENT_INSTITUTE_PER_WAY_ID(COMPANY, WAY_ID)";
				}
				else
				{
					this.dfsInstituteId.p_sLovReference = Ifs.Fnd.ApplicationForms.Const.strNULL;
				}
			}
			if (Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam)) 
			{
				if (this.dfsInstituteId.p_sLovReference != Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
					Sal.EnableWindow(this.pbList);
					this.hWndLovField = this.dfsInstituteId.i_hWndSelf;
				}
				else
				{
					if (Sal.IsWindowEnabled(this.pbList)) 
					{
						Sal.DisableWindow(this.pbList);
					}
				}
			}
			#endregion
		}
		
		/// <summary>
		/// PM_DataItemLovUserWhere event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfsInstituteId_OnPM_DataItemLovUserWhere(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (this.sCompany == Ifs.Fnd.ApplicationForms.Const.strNULL) 
			{
				e.Return = Ifs.Fnd.ApplicationForms.Const.LOVITEMVALUE_IsNull;
				return;
			}
			else
			{
				if (this.dfWayId.Text != Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
					e.Return = ("COMPANY='" + this.sCompany + "'" + "AND WAY_ID='" + this.dfWayId.Text + "'").ToHandle();
					return;
				}
				else
				{
					e.Return = ("COMPANY='" + this.sCompany + "'").ToHandle();
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
		private void dfWayId_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_SetFocus:
					this.dfWayId_OnSAM_SetFocus(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovUserWhere:
					this.dfWayId_OnPM_DataItemLovUserWhere(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
					e.Handled = true;
					e.Return = this.ValidatePaymentMethod();
					return;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfWayId_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (this.dfsInstituteId.Text == Ifs.Fnd.ApplicationForms.Const.strNULL) 
			{
				if (Ifs.Fnd.ApplicationForms.Var.Security.AreAllViewsAvailable("PAYMENT_WAY")) 
				{
					this.dfWayId.p_sLovReference = "PAYMENT_WAY(:i_hWndFrame.dlgPaymentTermDetail.sCompany)";
				}
				else
				{
					this.dfWayId.p_sLovReference = Ifs.Fnd.ApplicationForms.Const.strNULL;
				}
			}
			else
			{
				if (Ifs.Fnd.ApplicationForms.Var.Security.AreAllViewsAvailable("PAYMENT_WAY_PER_INSTITUTE3")) 
				{
					this.dfWayId.p_sLovReference = "PAYMENT_WAY_PER_INSTITUTE3(:i_hWndFrame.dlgPaymentTermDetail.sCompany, :i_hWndFrame.dlgPaymentTermDetail.dfsInstituteId)";
				}
				else
				{
					this.dfWayId.p_sLovReference = Ifs.Fnd.ApplicationForms.Const.strNULL;
				}
			}
			if (Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam)) 
			{
				if (this.dfWayId.p_sLovReference != Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
					Sal.EnableWindow(this.pbList);
					this.hWndLovField = this.dfWayId.i_hWndSelf;
				}
				else
				{
					if (Sal.IsWindowEnabled(this.pbList)) 
					{
						Sal.DisableWindow(this.pbList);
					}
				}
			}
			#endregion
		}
		
		/// <summary>
		/// PM_DataItemLovUserWhere event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfWayId_OnPM_DataItemLovUserWhere(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (this.sCompany == Ifs.Fnd.ApplicationForms.Const.strNULL) 
			{
				e.Return = Ifs.Fnd.ApplicationForms.Const.LOVITEMVALUE_IsNull;
				return;
			}
			else
			{
				if (this.dfsInstituteId.Text != Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
					e.Return = ("COMPANY='" + this.sCompany + "'" + "AND INSTITUTE_ID='" + this.dfsInstituteId.Text + "'").ToHandle();
					return;
				}
				else
				{
					e.Return = ("COMPANY='" + this.sCompany + "'").ToHandle();
					return;
				}
			}
			#endregion
		}
		#endregion
		
		#region Late Bind Methods
		
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
