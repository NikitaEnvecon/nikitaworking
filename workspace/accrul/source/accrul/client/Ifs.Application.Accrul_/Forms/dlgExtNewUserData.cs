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
	/// <param name="p_sCompany"></param>
	/// <param name="p_nLoadId"></param>
	/// <param name="p_sUserId"></param>
	/// <param name="p_sUserGroup"></param>
	/// <param name="p_sUserIdPrv"></param>
	/// <param name="p_sUserGroupPrv"></param>
	public partial class dlgExtNewUserData : cDialogBoxFin
	{
		#region Window Parameters
		public SalString p_sCompany;
		public SalString p_nLoadId;
		public SalString p_sUserId;
		public SalString p_sUserGroup;
		public SalString p_sUserIdPrv;
		public SalString p_sUserGroupPrv;
		#endregion
		
		#region Window Variables
		public SalWindowHandle hWndLOV = SalWindowHandle.Null;
		public SalString sUserIdTemp = "";
		public SalString sUserGroupTemp = "";
		public SalString sReturnValue = "";
		public SalNumber nNumber = 0;
		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		protected dlgExtNewUserData()
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
		public static SalNumber ModalDialog(Control owner, SalString p_sCompany, SalString p_nLoadId, ref SalString p_sUserId, ref SalString p_sUserGroup, SalString p_sUserIdPrv, SalString p_sUserGroupPrv)
		{
			dlgExtNewUserData dlg = DialogFactory.CreateInstance<dlgExtNewUserData>();
			dlg.p_sCompany = p_sCompany;
			dlg.p_nLoadId = p_nLoadId;
			dlg.p_sUserId = p_sUserId;
			dlg.p_sUserGroup = p_sUserGroup;
			dlg.p_sUserIdPrv = p_sUserIdPrv;
			dlg.p_sUserGroupPrv = p_sUserGroupPrv;
			SalNumber ret = dlg.ShowDialog(owner);
			p_sUserId = dlg.p_sUserId;
			p_sUserGroup = dlg.p_sUserGroup;
			return ret;
		}
		
		/// <summary>
		/// Returns the object instance associated with the window handle.
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public new static dlgExtNewUserData FromHandle(SalWindowHandle handle)
		{
			return ((dlgExtNewUserData)SalWindow.FromHandle(handle, typeof(dlgExtNewUserData)));
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
				((cDialogBoxFin)this).FrameStartupUser();
				dfsCompany.Text = p_sCompany;
				dfsUserId.Text = p_sUserId;
				dfsUserGroup.Text = p_sUserGroup;
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
				return Properties.Resources.WH_dlgExtNewUserData;
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
				if (sMethod == "Ok") 
				{
					return UM_Ok(nWhat);
				}
				if (sMethod == "Cancel") 
				{
					return UM_Cancel(nWhat);
				}
				if (sMethod == "List") 
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
		public virtual SalNumber UM_Ok(SalNumber nWhat)
		{
			#region Actions
			using (new SalContext(this))
			{
				switch (nWhat)
				{
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
						return Check();
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
						if (dfsUserId.Text != p_sUserIdPrv || dfsUserGroup.Text != p_sUserGroupPrv) 
						{
							if (UpdateNewUserData()) 
							{
								return Sal.EndDialog(i_hWndSelf, 1);
							}
							else
							{
								return false;
							}
						}
						else
						{
							return Sal.EndDialog(i_hWndSelf, 1);
						}
						break;
				}
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nWhat"></param>
		/// <returns></returns>
		public virtual SalNumber UM_Cancel(SalNumber nWhat)
		{
			#region Actions
			using (new SalContext(this))
			{
				switch (nWhat)
				{
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
						return true;
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
						return Sal.EndDialog(i_hWndSelf, 0);
				}
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nWhat"></param>
		/// <returns></returns>
		public virtual SalNumber UM_List(SalNumber nWhat)
		{
			#region Local Variables
			SalWindowHandle hWndLovField = SalWindowHandle.Null;
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				switch (nWhat)
				{
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
						return true;
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
						hWndLovField = hWndLOV;
						if (hWndLovField != SalWindowHandle.Null) 
						{
							if (Sal.SendMsg(hWndLovField, Ifs.Fnd.ApplicationForms.Const.PM_DataItemLov, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0)) 
							{
								Sal.SetFocus(hWndLovField);
								Sal.SendMsg(hWndLovField, Sys.SAM_Validate, 0, 0);
							}
							else
							{
								Sal.SetFocus(hWndLovField);
							}
						}
						return true;
				}
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean ValidityOfFields()
		{
			#region Actions
			using (new SalContext(this))
			{
				if (sUserIdTemp != dfsUserId.Text || sUserGroupTemp != dfsUserGroup.Text) 
				{
					using(SignatureHints hints = SignatureHints.NewContext())
					{
						hints.Add("EXT_TRANSACTIONS_API.Validate_User_Data", System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
						if (DbPLSQLBlock(cSessionManager.c_hSql, " &AO.EXT_TRANSACTIONS_API.Validate_User_Data(\r\n" +
							"                                             :i_hWndFrame.dlgExtNewUserData.sReturnValue,\r\n" +
							"                                             :i_hWndFrame.dlgExtNewUserData.p_sCompany,\r\n" +
							"                                             :i_hWndFrame.dlgExtNewUserData.dfsUserId,\r\n" +
							"                                             :i_hWndFrame.dlgExtNewUserData.dfsUserGroup )")) 
						{
							sUserIdTemp = dfsUserId.Text;
							sUserGroupTemp = dfsUserGroup.Text;
							if (sReturnValue == "TRUE") 
							{
								return true;
							}
							else
							{
								return false;
							}
						}
						else
						{
							return false;
						}
					}
				}
				return true;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean UpdateNewUserData()
		{
			#region Actions
			using (new SalContext(this))
			{
				using(SignatureHints hints = SignatureHints.NewContext())
				{
					hints.Add("EXT_TRANSACTIONS_API.Update_New_User_Data", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
					if (DbPLSQLBlock(cSessionManager.c_hSql, "&AO.EXT_TRANSACTIONS_API.Update_New_User_Data(\r\n" +
						"                                           :i_hWndFrame.dlgExtNewUserData.p_sCompany,\r\n" +
						"                                           :i_hWndFrame.dlgExtNewUserData.p_nLoadId,\r\n" +
						"                                           :i_hWndFrame.dlgExtNewUserData.dfsUserId,\r\n" +
						"                                           :i_hWndFrame.dlgExtNewUserData.dfsUserGroup,\r\n" +
						"                                           :i_hWndFrame.dlgExtNewUserData.p_sUserIdPrv,\r\n" +
						"                                           :i_hWndFrame.dlgExtNewUserData.p_sUserGroupPrv )")) 
					{
						return true;
					}
					else
					{
						return false;
					}
				}
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean Check()
		{
			#region Actions
			using (new SalContext(this))
			{
				if (dfsUserId.Text == Ifs.Fnd.ApplicationForms.Const.strNULL || dfsUserGroup.Text == Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
					return false;
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
		private void dfsUserId_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
					e.Handled = true;
					e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldEnabled;
					return;
				
				case Sys.SAM_AnyEdit:
					this.dfsUserId_OnSAM_AnyEdit(sender, e);
					break;
				
				case Sys.SAM_SetFocus:
					this.dfsUserId_OnSAM_SetFocus(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_AnyEdit event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfsUserId_OnSAM_AnyEdit(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (!(this.ValidityOfFields())) 
			{
				Sal.DisableWindow(this.pbOk);
			}
			else
			{
				Sal.EnableWindow(this.pbOk);
			}
			e.Return = true;
			return;
			#endregion
		}
		
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfsUserId_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (this.dfsUserId.p_sLovReference != Ifs.Fnd.ApplicationForms.Const.strNULL) 
			{
				if (this.dfsUserId.EditDataItemLov(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire)) 
				{
					if (!(Sal.IsWindowEnabled(this.pbList))) 
					{
						Sal.EnableWindow(this.pbList);
					}
					this.hWndLOV = this.dfsUserId.i_hWndSelf;
				}
			}
			else
			{
				if (Sal.IsWindowEnabled(this.pbList)) 
				{
					Sal.DisableWindow(this.pbList);
				}
			}
			e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
			return;
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
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
					e.Handled = true;
					e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldEnabled;
					return;
				
				case Sys.SAM_AnyEdit:
					this.dfsUserGroup_OnSAM_AnyEdit(sender, e);
					break;
				
				case Sys.SAM_SetFocus:
					this.dfsUserGroup_OnSAM_SetFocus(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_AnyEdit event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfsUserGroup_OnSAM_AnyEdit(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (!(this.ValidityOfFields())) 
			{
				Sal.DisableWindow(this.pbOk);
			}
			else
			{
				Sal.EnableWindow(this.pbOk);
			}
			e.Return = true;
			return;
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
			if (this.dfsUserGroup.p_sLovReference != Ifs.Fnd.ApplicationForms.Const.strNULL) 
			{
				if (this.dfsUserGroup.EditDataItemLov(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire)) 
				{
					if (!(Sal.IsWindowEnabled(this.pbList))) 
					{
						Sal.EnableWindow(this.pbList);
					}
					this.hWndLOV = this.dfsUserGroup.i_hWndSelf;
				}
			}
			else
			{
				if (Sal.IsWindowEnabled(this.pbList)) 
				{
					Sal.DisableWindow(this.pbList);
				}
			}
			e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
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
	}
}
