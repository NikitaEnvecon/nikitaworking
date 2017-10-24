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
	/// <param name="sVoucherTypeIn"></param>
	/// <param name="nYearIn"></param>
	/// <param name="sCompany"></param>
	public partial class dlgCreateYear : cDialogBoxFin
	{
		#region Window Parameters
		public SalArray<SalString> sVoucherTypeIn;
		public SalArray<SalNumber> nYearIn;
		public SalString sCompany;
		#endregion
		
		#region Window Variables
		public SalNumber nReturn = 0;
		public SalNumber nYear = 0;
		public SalString sVoucherType = "";
		public SalNumber nExist = 0;
		public SalNumber nNotExist = 0;
		public SalNumber UserGroupExist = 0;
		public SalString lsIIDYes1 = "";
		public SalString sExistsGroup = "";
		public SalBoolean bExist = false;
		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		protected dlgCreateYear()
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
		public static SalNumber ModalDialog(Control owner, SalArray<SalString> sVoucherTypeIn, SalArray<SalNumber> nYearIn, SalString sCompany)
		{
			dlgCreateYear dlg = DialogFactory.CreateInstance<dlgCreateYear>();
			dlg.sVoucherTypeIn = sVoucherTypeIn;
			dlg.nYearIn = nYearIn;
			dlg.sCompany = sCompany;
			SalNumber ret = dlg.ShowDialog(owner);
			return ret;
		}
		
		/// <summary>
		/// Returns the object instance associated with the window handle.
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public new static dlgCreateYear FromHandle(SalWindowHandle handle)
		{
			return ((dlgCreateYear)SalWindow.FromHandle(handle, typeof(dlgCreateYear)));
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
				CheckEditable();
				dfVoucherType.Text = sVoucherTypeIn[0];
				dfCompany.Text = i_sCompany;
				Sal.SendMsg(cmbDefaultType, Sys.SAM_DropDown, 0, 0);
				Sal.SendMsg(cmbAuthorizeLevel, Sys.SAM_DropDown, 0, 0);
				DbListPopulate(cmbUserGroup, cSessionManager.c_hSql, "Select user_group from " + cSessionManager.c_sDbPrefix + "USER_GROUP_FINANCE where company = :i_hWndFrame.dlgCreateYear.i_sCompany");
				DbListPopulate(cmbFunctionGroup, cSessionManager.c_hSql, "Select Function_Group from " + cSessionManager.c_sDbPrefix + "VOUCHER_TYPE_DETAIL where company = :i_hWndFrame.dlgCreateYear.i_sCompany\r\n" +
					"		 		              and voucher_type = :i_hWndFrame.dlgCreateYear.dfVoucherType ");
				return true;
			}
			#endregion
		}
		
		/// <summary>
		/// Stub for all user methods.
		/// Should be overridden with own method for all container classes.
		/// (other classen can override PM_UserMethod instead)
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
				if (sMethod == "OK") 
				{
					return Save(nWhat, sMethod);
				}
				if (sMethod == "Cancel") 
				{
					switch (nWhat)
					{
						case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
							DataSourceClearIt(0);
							return Sal.EndDialog(i_hWndSelf, Sys.IDCANCEL);
						
						case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
							return 1;
						
						case Ifs.Fnd.ApplicationForms.Const.METHOD_GetType:
							return Ifs.Fnd.ApplicationForms.Const.CHILDTYPE_AnyMethod;
					}
				}
				Sal.GetItemName(Sys.hWndItem, ref sName);
				Ifs.Fnd.ApplicationForms.Int.ErrorBox("DESIGN TIME ERROR for item " + sName + "\r\n" +
					"Function UserMethod handling method \"" + sMethod + "\" not written!");
				switch (nWhat)
				{
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
						return 0;
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
						return 0;
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_GetType:
						return Ifs.Fnd.ApplicationForms.Const.CHILDTYPE_AnyMethod;
				}
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber CheckEditable()
		{
			#region Actions
			using (new SalContext(this))
			{
				if (cmbUserGroup.Text != Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
					cmbAuthorizeLevel.EditDataItemSetEdited();
					cmbDefaultType.EditDataItemSetEdited();
					cmbFunctionGroup.EditDataItemSetEdited();
				}
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber GetUserDescription()
		{
			#region Actions
			using (new SalContext(this))
			{
				if (DbPrepareAndExecute(cSessionManager.c_hSql, "Select  " + cSessionManager.c_sDbPrefix + " USER_GROUP_FINANCE_API.Get_User_Group_Description(\r\n" +
					":i_hWndFrame.dlgCreateYear.i_sCompany,:i_hWndFrame.dlgCreateYear.cmbUserGroup) into :i_hWndFrame.dlgCreateYear.dfDescription from DUAL")) 
				{
					DbFetchNext(cSessionManager.c_hSql, ref nReturn);
				}
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// Stub for all user methods.
		/// Should be overridden with own method for all container classes.
		/// (other classen can override PM_UserMethod instead)
		/// </summary>
		/// <param name="nWhat"></param>
		/// <param name="sMethod"></param>
		/// <returns></returns>
		public virtual SalNumber Save(SalNumber nWhat, SalString sMethod)
		{
			#region Local Variables
			SalNumber nIndex = 0;
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				switch (nWhat)
				{
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
						// Bug 77430, Begin added the condition for AuthorizeLevel Approve Only as well
						if (!((cmbAuthorizeLevel.Text == Sal.ListQueryTextX(cmbAuthorizeLevel, 0)) || (cmbAuthorizeLevel.Text == Sal.ListQueryTextX(cmbAuthorizeLevel, 1)) || (cmbAuthorizeLevel.Text == Sal.ListQueryTextX(cmbAuthorizeLevel, 2)))) 
						{
							Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_VoTyUserGroup, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
							return 0;
						}
						// Bug 77430, End
						if (!((cmbDefaultType.Text == Sal.ListQueryTextX(cmbDefaultType, 0)) || (cmbDefaultType.Text == Sal.ListQueryTextX(cmbDefaultType, 1)))) 
						{
							Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_VoTyUserGroup, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
							return 0;
						}
						CheckUserGroupExist();
						if (UserGroupExist == 1) 
						{
							if (DbTransactionBegin(ref cSessionManager.c_hSql)) 
							{
								Sal.WaitCursor(true);
								nIndex = 0;
								while (sVoucherTypeIn[nIndex] != Ifs.Fnd.ApplicationForms.Const.strNULL) 
								{
									sVoucherType = sVoucherTypeIn[nIndex];
									nYear = nYearIn[nIndex];
									if (nYear != SalNumber.Null) 
									{
										using(SignatureHints hints = SignatureHints.NewContext())
										{
											hints.Add("Voucher_Type_User_Group_API.Create_Vou_Type_User_Group", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
											if (!(DbPLSQLBlock(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "Voucher_Type_User_Group_API.Create_Vou_Type_User_Group(\r\n" +
												"   :i_hWndFrame.dlgCreateYear.i_sCompany,\r\n" +
												"   :i_hWndFrame.dlgCreateYear.nYear,\r\n" +
												"   :i_hWndFrame.dlgCreateYear.cmbUserGroup,\r\n" +
												"   :i_hWndFrame.dlgCreateYear.sVoucherType,\r\n" +
												"   :i_hWndFrame.dlgCreateYear.cmbAuthorizeLevel,\r\n" +
												"   :i_hWndFrame.dlgCreateYear.cmbDefaultType,\r\n" +
												"   :i_hWndFrame.dlgCreateYear.cmbFunctionGroup)"))) 
											{
												DbTransactionClear(cSessionManager.c_hSql);
												Sal.WaitCursor(false);
												return 0;
											}
										}
									}
									nIndex = nIndex + 1;
								}
								DbTransactionEnd(cSessionManager.c_hSql);
								Sal.WaitCursor(false);
								return Sal.EndDialog(i_hWndSelf, Sys.IDOK);
							}
						}
						goto case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire;
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
						if (Sal.ListQuerySelection(cmbUserGroup) == Sys.LB_Err) 
						{
							return 0;
						}
						return 1;
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_GetType:
						return Ifs.Fnd.ApplicationForms.Const.CHILDTYPE_AnyMethod;
				}
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber CheckUserGroup()
		{
			#region Actions
			using (new SalContext(this))
			{
				// Bug 83771, start, Modified code block
				using(SignatureHints hints = SignatureHints.NewContext())
				{
					hints.Add("Voucher_Type_User_Group_API.Check_User_Group", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
					if (DbPLSQLBlock(cSessionManager.c_hSql, " :i_hWndFrame.dlgCreateYear.sExistsGroup := &AO.Voucher_Type_User_Group_API.Check_User_Group(\r\n" +
						"					 :i_hWndFrame.dlgCreateYear.i_sCompany,\r\n" +
						"					 :i_hWndFrame.dlgCreateYear.cmbUserGroup,\r\n" +
						"                                                                                 :i_hWndFrame.dlgCreateYear.sVoucherType,\r\n" +
						"                                                                                 :i_hWndFrame.dlgCreateYear.nYear) ")) 
					{
						if (sExistsGroup == "TRUE") 
						{
							nExist = 1;
							bExist = true;
						}
						else
						{
							nNotExist = 1;
							bExist = false;
						}
					}
				}
				// Bug 83771, end
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber CheckUserGroupExist()
		{
			#region Local Variables
			SalNumber nIndex = 0;
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				nExist = 0;
				nNotExist = 0;
				while (sVoucherTypeIn[nIndex] != Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
					sVoucherType = sVoucherTypeIn[nIndex];
					nYear = nYearIn[nIndex];
					CheckUserGroup();
					if (bExist) 
					{
						nYearIn[nIndex] = SalNumber.Null;
					}
					nIndex = nIndex + 1;
				}
				if (nNotExist == 1 && nExist == 1) 
				{
					Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_SomeUserGoupExist, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
					if (Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_VouTypeUserGroup, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Question, (Ifs.Fnd.ApplicationForms.Const.QUESTION_YesNo | Sys.MB_DefButton2)) == Sys.IDYES) 
					{
						UserGroupExist = 1;
					}
				}
				if (nNotExist == 1 && nExist == 0) 
				{
					UserGroupExist = 1;
				}
				if (nNotExist == 0 && nExist == 1) 
				{
					Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_UserGoupExist, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
					UserGroupExist = 0;
				}
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
		private void dlgCreateYear_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Create:
					this.dlgCreateYear_OnSAM_Create(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_Create event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dlgCreateYear_OnSAM_Create(object sender, WindowActionsEventArgs e)
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
		private void cmbUserGroup_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
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
			this.GetUserDescription();
			this.CheckEditable();
			Sal.EnableWindow(this.pbOk);
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void dfDescription_WindowActions(object sender, WindowActionsEventArgs e)
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
