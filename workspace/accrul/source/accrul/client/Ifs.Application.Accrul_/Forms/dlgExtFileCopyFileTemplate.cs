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

namespace Ifs.Application.Accrul_
{
	
	/// <summary>
	/// </summary>
	/// <param name="sFileType"></param>
	/// <param name="sFileTemplate"></param>
	/// <param name="sFileTemplateDesc"></param>
	/// <param name="sFileTypeDesc"></param>
	/// <param name="sFileTemplateReturn"></param>
	public partial class dlgExtFileCopyFileTemplate : cDialogBox
	{
		#region Window Parameters
		public SalString sFileType;
		public SalString sFileTemplate;
		public SalString sFileTemplateDesc;
		public SalString sFileTypeDesc;
		public SalString sFileTemplateReturn;
		#endregion
		
		#region Window Variables
		public SalString sAutomaticAllotment = "";
		public SalNumber nTemp1 = 0;
		public SalWindowHandle hWndLovField = SalWindowHandle.Null;
		public SalString sFlag = "";
		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		protected dlgExtFileCopyFileTemplate()
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
		public static SalNumber ModalDialog(Control owner, SalString sFileType, SalString sFileTemplate, SalString sFileTemplateDesc, SalString sFileTypeDesc, ref SalString sFileTemplateReturn)
		{
			dlgExtFileCopyFileTemplate dlg = DialogFactory.CreateInstance<dlgExtFileCopyFileTemplate>();
			dlg.sFileType = sFileType;
			dlg.sFileTemplate = sFileTemplate;
			dlg.sFileTemplateDesc = sFileTemplateDesc;
			dlg.sFileTypeDesc = sFileTypeDesc;
			dlg.sFileTemplateReturn = sFileTemplateReturn;
			SalNumber ret = dlg.ShowDialog(owner);
			sFileTemplateReturn = dlg.sFileTemplateReturn;
			return ret;
		}
		
		/// <summary>
		/// Returns the object instance associated with the window handle.
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public new static dlgExtFileCopyFileTemplate FromHandle(SalWindowHandle handle)
		{
			return ((dlgExtFileCopyFileTemplate)SalWindow.FromHandle(handle, typeof(dlgExtFileCopyFileTemplate)));
		}
		#endregion
		
		#region Methods
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean CopyFileDefintion()
		{
			#region Local Variables
			SalBoolean bOk = false;
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				// Security check
				Sal.WaitCursor(true);
				using(SignatureHints hints = SignatureHints.NewContext())
				{
					hints.Add("External_File_Utility_API.Copy_Def_From_File_Def", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
					bOk = DbPLSQLTransaction(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "External_File_Utility_API.Copy_Def_From_File_Def(\r\n" +
						"                       :i_hWndFrame.dlgExtFileCopyFileTemplate.dfFileId,\r\n" +
						"                       :i_hWndFrame.dlgExtFileCopyFileTemplate.dfsTempDescriptionTo,\r\n" +
						"                       :i_hWndFrame.dlgExtFileCopyFileTemplate.dfFromFileId)");
				}
				Sal.WaitCursor(false);
				if (bOk) 
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
		public new SalBoolean FrameStartupUser()
		{
			#region Actions
			using (new SalContext(this))
			{
				dfFromFileId.Text = sFileTemplate;
				dfsTempDescriptionFrom.Text = sFileTemplateDesc;
				dfFileType.Text = sFileType;
				dfsTypeDescriptionFrom.Text = sFileTypeDesc;
				if (dfFromFileId.Text == Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
					Sal.SetFocus(dfFromFileId);
				}
				else
				{
					Sal.SetFocus(dfFileId);
				}
				return true;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nWhatInv"></param>
		/// <param name="sAction"></param>
		/// <returns></returns>
		public new SalNumber UserMethod(SalNumber nWhatInv, SalString sAction)
		{
			#region Actions
			using (new SalContext(this))
			{
				if (sAction == "OKButton") 
				{
					switch (nWhatInv)
					{
						case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
							if (dfFileId.Text == Ifs.Fnd.ApplicationForms.Const.strNULL || dfsTempDescriptionTo.Text == Ifs.Fnd.ApplicationForms.Const.strNULL) 
							{
								return false;
							}
							return true;
						
						case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
							if (CopyFileDefintion()) 
							{
								sFileTemplateReturn = dfFileId.Text;
								Sal.EndDialog(i_hWndFrame, Sys.IDOK);
							}
							else
							{
								Sal.EndDialog(i_hWndFrame, Sys.IDCANCEL);
							}
							break;
					}
				}
				if (sAction == "CancelButton") 
				{
					switch (nWhatInv)
					{
						case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
							return true;
						
						case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
							Sal.EndDialog(i_hWndFrame, Sys.IDCANCEL);
							goto case Ifs.Fnd.ApplicationForms.Const.METHOD_GetType;
						
						case Ifs.Fnd.ApplicationForms.Const.METHOD_GetType:
							return Ifs.Fnd.ApplicationForms.Const.CHILDTYPE_Any;
					}
				}
				if (sAction == "ListButton") 
				{
					switch (nWhatInv)
					{
						case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
							return hWndLovField != SalWindowHandle.Null;
						
						case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
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
							break;
					}
				}
			}

			return false;
			#endregion
		}
		#endregion
		
		#region Window Actions
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void dlgExtFileCopyFileTemplate_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Create:
					this.dlgExtFileCopyFileTemplate_OnSAM_Create(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_Create event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dlgExtFileCopyFileTemplate_OnSAM_Create(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam);
			Sal.CenterWindow(this.i_hWndFrame);
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void dfFromFileId_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Validate:
					this.dfFromFileId_OnSAM_Validate(sender, e);
					break;
				
				case Sys.SAM_SetFocus:
					this.dfFromFileId_OnSAM_SetFocus(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_Validate event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfFromFileId_OnSAM_Validate(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			using(SignatureHints hints = SignatureHints.NewContext())
			{
				hints.Add("Ext_File_Template_API.Get_Description", System.Data.ParameterDirection.Input);
				if (!(this.dfFromFileId.DbPLSQLBlock(cSessionManager.c_hSql, ":i_hWndFrame.dlgExtFileCopyFileTemplate.dfsTempDescriptionFrom :=  " + cSessionManager.c_sDbPrefix + "Ext_File_Template_API.Get_Description(\r\n" +
					":i_hWndFrame.dlgExtFileCopyFileTemplate.dfFromFileId)"))) 
				{
					e.Return = Sys.VALIDATE_Cancel;
					return;
				}
			}
			using(SignatureHints hints = SignatureHints.NewContext())
			{
				hints.Add("Ext_File_Template_API.Get_File_Type", System.Data.ParameterDirection.Input);
				if (!(this.dfFromFileId.DbPLSQLBlock(cSessionManager.c_hSql, ":i_hWndFrame.dlgExtFileCopyFileTemplate.dfFileType :=  " + cSessionManager.c_sDbPrefix + "Ext_File_Template_API.Get_File_Type(\r\n" +
					":i_hWndFrame.dlgExtFileCopyFileTemplate.dfFromFileId)"))) 
				{
					e.Return = Sys.VALIDATE_Cancel;
					return;
				}
			}
			using(SignatureHints hints = SignatureHints.NewContext())
			{
				hints.Add("Ext_File_Type_API.Get_Description", System.Data.ParameterDirection.Input);
				if (!(this.dfFromFileId.DbPLSQLBlock(cSessionManager.c_hSql, ":i_hWndFrame.dlgExtFileCopyFileTemplate.dfsTypeDescriptionFrom :=  " + cSessionManager.c_sDbPrefix + "Ext_File_Type_API.Get_Description(\r\n" +
					":i_hWndFrame.dlgExtFileCopyFileTemplate.dfFileType)"))) 
				{
					e.Return = Sys.VALIDATE_Cancel;
					return;
				}
			}
			e.Return = Sys.VALIDATE_Ok;
			return;
			#endregion
		}
		
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfFromFileId_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam)) 
			{
				if (this.dfFromFileId.p_sLovReference != Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
					this.hWndLovField = this.dfFromFileId.i_hWndSelf;
					cObjectRelationManager.__bLOV = false;
				}
				else
				{
					this.hWndLovField = SalWindowHandle.Null;
				}
				this.pbList.MethodInvestigateState();
			}
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void dfsTempDescriptionFrom_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_SetFocus:
					this.dfsTempDescriptionFrom_OnSAM_SetFocus(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfsTempDescriptionFrom_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam)) 
			{
				if (this.dfsTempDescriptionFrom.p_sLovReference != Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
					this.hWndLovField = this.dfsTempDescriptionFrom.i_hWndSelf;
					cObjectRelationManager.__bLOV = false;
				}
				else
				{
					this.hWndLovField = SalWindowHandle.Null;
				}
				this.pbList.MethodInvestigateState();
			}
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void dfFileType_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_SetFocus:
					this.dfFileType_OnSAM_SetFocus(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfFileType_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam)) 
			{
				if (this.dfFileType.p_sLovReference != Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
					this.hWndLovField = this.dfFileType.i_hWndSelf;
					cObjectRelationManager.__bLOV = false;
				}
				else
				{
					this.hWndLovField = SalWindowHandle.Null;
				}
				this.pbList.MethodInvestigateState();
			}
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void dfsTypeDescriptionFrom_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_SetFocus:
					this.dfsTypeDescriptionFrom_OnSAM_SetFocus(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfsTypeDescriptionFrom_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam)) 
			{
				if (this.dfsTypeDescriptionFrom.p_sLovReference != Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
					this.hWndLovField = this.dfsTypeDescriptionFrom.i_hWndSelf;
					cObjectRelationManager.__bLOV = false;
				}
				else
				{
					this.hWndLovField = SalWindowHandle.Null;
				}
				this.pbList.MethodInvestigateState();
			}
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void dfFileId_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_AnyEdit:
					e.Handled = true;
					this.pbOk.MethodInvestigateState();
					break;
				
				case Sys.SAM_SetFocus:
					this.dfFileId_OnSAM_SetFocus(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
					this.dfFileId_OnPM_DataItemValidate(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfFileId_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam)) 
			{
				if (this.dfFileId.p_sLovReference != Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
					this.hWndLovField = this.dfFileId.i_hWndSelf;
					cObjectRelationManager.__bLOV = false;
				}
				else
				{
					this.hWndLovField = SalWindowHandle.Null;
				}
				this.pbList.MethodInvestigateState();
			}
			#endregion
		}
		
		/// <summary>
		/// PM_DataItemValidate event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfFileId_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
			if (this.dfFileId.Text != Ifs.Fnd.ApplicationForms.Const.strNULL) 
			{
				using(SignatureHints hints = SignatureHints.NewContext())
				{
					hints.Add("Ext_File_Template_API.Already_Exist", System.Data.ParameterDirection.Input);
					if (this.dfFileId.DbPLSQLBlock(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "Ext_File_Template_API.Already_Exist(\r\n" +
						":i_hWndFrame.dlgExtFileCopyFileTemplate.dfFileId )")) 
					{
						this.pbOk.MethodInvestigateState();
						e.Return = Sys.VALIDATE_Ok;
						return;
					}
				}
				this.pbOk.MethodInvestigateState();
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
		private void dfsTempDescriptionTo_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_AnyEdit:
					e.Handled = true;
					this.pbOk.MethodInvestigateState();
					break;
				
				case Sys.SAM_SetFocus:
					this.dfsTempDescriptionTo_OnSAM_SetFocus(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfsTempDescriptionTo_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam)) 
			{
				if (this.dfsTempDescriptionTo.p_sLovReference != Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
					this.hWndLovField = this.dfsTempDescriptionTo.i_hWndSelf;
					cObjectRelationManager.__bLOV = false;
				}
				else
				{
					this.hWndLovField = SalWindowHandle.Null;
				}
				this.pbList.MethodInvestigateState();
			}
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
