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
	/// <param name="sTemplateId"></param>
	/// <param name="sCompany"></param>
	/// <param name="sObjectGroupId"></param>
	public partial class dlgCopySelectionTemplate : cDialogBox
	{
		#region Window Parameters
		public SalString sTemplateId;
		public SalString sCompany;
		public SalString sObjectGroupId;
		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		protected dlgCopySelectionTemplate()
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
		public static SalNumber ModalDialog(Control owner, SalString sTemplateId, SalString sCompany, SalString sObjectGroupId)
		{
			dlgCopySelectionTemplate dlg = DialogFactory.CreateInstance<dlgCopySelectionTemplate>();
			dlg.sTemplateId = sTemplateId;
			dlg.sCompany = sCompany;
			dlg.sObjectGroupId = sObjectGroupId;
			SalNumber ret = dlg.ShowDialog(owner);
			return ret;
		}
		
		/// <summary>
		/// Returns the object instance associated with the window handle.
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public new static dlgCopySelectionTemplate FromHandle(SalWindowHandle handle)
		{
			return ((dlgCopySelectionTemplate)SalWindow.FromHandle(handle, typeof(dlgCopySelectionTemplate)));
		}
		#endregion
		
		#region Methods
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean CopyTemplate()
		{
			#region Local Variables
			SalArray<SalString> sItemNames = new SalArray<SalString>();
			SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				Sal.WaitCursor(true);
				cmbOwnership.EditDataItemSetEdited();
				using(SignatureHints hints = SignatureHints.NewContext())
				{
					hints.Add("Fin_Sel_Obj_Templ_API.Copy_Selection_Template", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
					if (DbPLSQLTransaction(cSessionManager.c_hSql, "&AO.Fin_Sel_Obj_Templ_API.Copy_Selection_Template( \r\n" +
						"						:i_hWndFrame.dlgCopySelectionTemplate.sCompany, \r\n" +
						"						:i_hWndFrame.dlgCopySelectionTemplate.sObjectGroupId, \r\n" +
						"						:i_hWndFrame.dlgCopySelectionTemplate.dfsFromTemplateId,\r\n" +
						"						:i_hWndFrame.dlgCopySelectionTemplate.dfsNewTemplateId,\r\n" +
						"						:i_hWndFrame.dlgCopySelectionTemplate.dfsDescription,\r\n" +
						"						:i_hWndFrame.dlgCopySelectionTemplate.cmbOwnership.i_sMyValue)")) 
					{
						sItemNames[0] = "TEMPLATE_ID";
						hWndItems[0] = dfsNewTemplateId;
						Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init(Ifs.Fnd.ApplicationForms.Int.QualifiedItemNameGet(this), this, sItemNames, hWndItems);
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
							if (Sal.IsNull(dfsNewTemplateId) || Sal.IsNull(dfsDescription) || Sal.IsNull(cmbOwnership)) 
							{
								return 0;
							}
							return 1;
						
						case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
							if (CopyTemplate()) 
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
				dfsFromTemplateId.Text = sTemplateId;
				cmbOwnership.LookupInit();
				Sal.ListSetSelect(cmbOwnership, 0);
				sOwnership = Sal.ListQueryTextX(cmbOwnership, 0);
				cmbOwnership.i_sMyValue = sOwnership;
				SetWindowTitle();
			}

			return false;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalString GetWindowTitle()
		{
			#region Actions
			using (new SalContext(this))
			{
                if (sObjectGroupId == "AR")
				   return Properties.Resources.WH_dlgCopySelectionTemplate;
                else
				   return Properties.Resources.WH_dlgCopyAPSelectionTemplate;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean SetWindowTitle()
		{
			#region Local Variables
			SalString sWindowTitle = "";
			SalArray<SalString> sParams = new SalArray<SalString>();
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				sParams[0] = sObjectGroupId;
				sWindowTitle = GetWindowTitle();
				sWindowTitle = Ifs.Fnd.ApplicationForms.Int.TranslateConstantWithParams(sWindowTitle, sParams);
				Sal.SetWindowText(i_hWndSelf, sWindowTitle);
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
		private void dlgCopySelectionTemplate_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Create:
					this.dlgCopySelectionTemplate_OnSAM_Create(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_Create event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dlgCopySelectionTemplate_OnSAM_Create(object sender, WindowActionsEventArgs e)
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
		private void dfsNewTemplateId_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_AnyEdit:
					this.dfsNewTemplateId_OnSAM_AnyEdit(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_AnyEdit event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfsNewTemplateId_OnSAM_AnyEdit(object sender, WindowActionsEventArgs e)
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
