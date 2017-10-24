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
	/// <param name="p_sCompany"></param>
	/// <param name="p_sObjectGroupId"></param>
	/// <param name="p_sObjectId"></param>
	/// <param name="p_nSelectionId"></param>
	public partial class dlgCreateSelectionTemplate : cDialogBox
	{
		#region Window Parameters
		public SalString p_sCompany;
		public SalString p_sObjectGroupId;
		public SalString p_sObjectId;
		public SalNumber p_nSelectionId;
		#endregion
		
		#region Window Variables
		public SalString lsAttr = "";
		public SalString sWarning = "";
		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		protected dlgCreateSelectionTemplate()
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
		public static SalNumber ModalDialog(Control owner, SalString p_sCompany, SalString p_sObjectGroupId, SalString p_sObjectId, SalNumber p_nSelectionId)
		{
			dlgCreateSelectionTemplate dlg = DialogFactory.CreateInstance<dlgCreateSelectionTemplate>();
			dlg.p_sCompany = p_sCompany;
			dlg.p_sObjectGroupId = p_sObjectGroupId;
			dlg.p_sObjectId = p_sObjectId;
			dlg.p_nSelectionId = p_nSelectionId;
			SalNumber ret = dlg.ShowDialog(owner);
			return ret;
		}
		
		/// <summary>
		/// Returns the object instance associated with the window handle.
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public new static dlgCreateSelectionTemplate FromHandle(SalWindowHandle handle)
		{
			return ((dlgCreateSelectionTemplate)SalWindow.FromHandle(handle, typeof(dlgCreateSelectionTemplate)));
		}
		#endregion
		
		#region Methods
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean CreateTemplate()
		{
			#region Local Variables
			SalArray<SalString> sItemNames = new SalArray<SalString>();
			SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
			SalBoolean bOk = false;
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				Sal.WaitCursor(true);
				bOk = true;
				if (cbDefault.Checked) 
				{
					if (CheckDefaultTemplate()) 
					{
						bOk = true;
					}
					else
					{
						bOk = false;
					}
				}
				if (bOk) 
				{
					Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("TEMPLATE_ID", dfsTemplateId.Text, ref lsAttr);
					Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("DESCRIPTION", dfsDescription.Text, ref lsAttr);
					Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("OWNERSHIP", cmbOwnership.Text, ref lsAttr);
					Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("OWNER", dfOwner.Text, ref lsAttr);
					if (cbExcludeValues.Checked) 
					{
						Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("INCLUDE_VALUES", "FALSE", ref lsAttr);
					}
					else
					{
						Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("INCLUDE_VALUES", "TRUE", ref lsAttr);
					}
					if (cbDefault.Checked) 
					{
						Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("DEFAULT_TEMPLATE", "TRUE", ref lsAttr);
					}
					else
					{
						Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("DEFAULT_TEMPLATE", "FALSE", ref lsAttr);
					}
					using(SignatureHints hints = SignatureHints.NewContext())
					{
						hints.Add("Fin_Object_Selection_API.Create_Selection_Template", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
						if (DbPLSQLTransaction(cSessionManager.c_hSql, "&AO.Fin_Object_Selection_API.Create_Selection_Template(\r\n" +
							"						:i_hWndFrame.dlgCreateSelectionTemplate.p_sCompany,\r\n" +
							"						:i_hWndFrame.dlgCreateSelectionTemplate.p_sObjectGroupId,\r\n" +
							"						:i_hWndFrame.dlgCreateSelectionTemplate.p_sObjectId,\r\n" +
							"						:i_hWndFrame.dlgCreateSelectionTemplate.p_nSelectionId,\r\n" +
							"						:i_hWndFrame.dlgCreateSelectionTemplate.lsAttr)")) 
						{
							Sal.WaitCursor(false);
							return true;
						}
						else
						{
							Sal.WaitCursor(false);
							return false;
						}
					}
				}
				Sal.WaitCursor(false);
				return false;
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
				if (sMethod == "ok") 
				{
					switch (nWhat)
					{
						case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
							if (Sal.IsNull(dfsTemplateId) || Sal.IsNull(dfsDescription) || Sal.IsNull(cmbOwnership)) 
							{
								return 0;
							}
							return 1;
						
						case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
							if (CreateTemplate()) 
							{
								return Sal.EndDialog(this, Sys.IDOK);
							}
							else
							{
								return 1;
							}
							break;
					}
				}
				else if (sMethod == "cancel") 
				{
					switch (nWhat)
					{
						case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
							return 1;
						
						case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
							Sal.EndDialog(this, Sys.IDCANCEL);
							break;
					}
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
			#region Local Variables
			SalString sOwnership = "";
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				dfOwner.Text = Ifs.Fnd.ApplicationForms.Int.FndUser();
				cmbOwnership.LookupInit();
				Sal.ListSetSelect(cmbOwnership, 0);
				sOwnership = Sal.ListQueryTextX(cmbOwnership, 0);
				cmbOwnership.i_sMyValue = sOwnership;
			}

			return false;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean CheckDefaultTemplate()
		{
			#region Actions
			using (new SalContext(this))
			{
				using(SignatureHints hints = SignatureHints.NewContext())
				{
					hints.Add("Fin_Sel_Obj_Templ_API.Check_Default_Template__", System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
					if (DbPLSQLBlock(cSessionManager.c_hSql, "&AO.Fin_Sel_Obj_Templ_API.Check_Default_Template__(\r\n" +
						"			:i_hWndFrame.dlgCreateSelectionTemplate.sWarning,\r\n" +
						"			:i_hWndFrame.dlgCreateSelectionTemplate.p_sCompany,\r\n" +
						"			:i_hWndFrame.dlgCreateSelectionTemplate.p_sObjectGroupId,\r\n" +
						"			:i_hWndFrame.dlgCreateSelectionTemplate.cmbOwnership,\r\n" +
						"			:i_hWndFrame.dlgCreateSelectionTemplate.dfOwner )")) 
					{
						if (sWarning != SalString.Null) 
						{
							switch (Ifs.Fnd.ApplicationForms.Int.PalMessageBox(sWarning, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Warning, (Ifs.Fnd.ApplicationForms.Const.WARNING_YesNo | Sys.MB_DefButton2)))
							{
								case Sys.IDYES:
									return true;
								
								case Sys.IDNO:
									return false;
							}
						}
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
		#endregion
		
		#region Window Actions
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void dlgCreateSelectionTemplate_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Create:
					this.dlgCreateSelectionTemplate_OnSAM_Create(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_Create event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dlgCreateSelectionTemplate_OnSAM_Create(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam);
			Sal.CenterWindow(this);
			e.Return = true;
			return;
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void dfsTemplateId_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_AnyEdit:
					this.dfsTemplateId_OnSAM_AnyEdit(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_AnyEdit event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfsTemplateId_OnSAM_AnyEdit(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.pbOk.MethodInvestigateState();
			e.Return = true;
			return;
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void dfsDescription_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_AnyEdit:
					this.dfsDescription_OnSAM_AnyEdit(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_AnyEdit event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfsDescription_OnSAM_AnyEdit(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.pbOk.MethodInvestigateState();
			e.Return = true;
			return;
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void cmbOwnership_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_AnyEdit:
					this.cmbOwnership_OnSAM_AnyEdit(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_AnyEdit event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cmbOwnership_OnSAM_AnyEdit(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.pbOk.MethodInvestigateState();
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
		#endregion
	}
}
