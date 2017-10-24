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
// Date    By      Notes
// ------  ------  -------------------------------------------------------------------------------------
// 130208  Machlk  Bug 107870 Begin, Changed VALIDATE_Cancel to VALIDATE_Ok
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
	/// <param name="sComponent"></param>
	/// <param name="sFileType"></param>
	public partial class dlgCreateFileTypeTemplFromView : cDialogBox
	{
		#region Window Parameters
		public SalString sComponent;
		public SalString sFileType;
		#endregion
		
		#region Window Variables
		public SalString sAutomaticAllotment = "";
		public SalNumber nTemp1 = 0;
		public SalWindowHandle hWndLovField = SalWindowHandle.Null;
		public SalString sFlag = "";
		public SalString sTemp = "";
		public SalString sViewType = "";
		public SalNumber nNum = 0;
		public SalNumber nNumMax = 0;
		public SalArray<SalString> sRecords = new SalArray<SalString>();
		public SalArray<SalString> sUnits = new SalArray<SalString>();
		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		protected dlgCreateFileTypeTemplFromView()
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
		public static SalNumber ModalDialog(Control owner, SalString sComponent, ref SalString sFileType)
		{
			dlgCreateFileTypeTemplFromView dlg = DialogFactory.CreateInstance<dlgCreateFileTypeTemplFromView>();
			dlg.sComponent = sComponent;
			dlg.sFileType = sFileType;
			SalNumber ret = dlg.ShowDialog(owner);
			sFileType = dlg.sFileType;
			return ret;
		}
		
		/// <summary>
		/// Returns the object instance associated with the window handle.
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public new static dlgCreateFileTypeTemplFromView FromHandle(SalWindowHandle handle)
		{
			return ((dlgCreateFileTypeTemplFromView)SalWindow.FromHandle(handle, typeof(dlgCreateFileTypeTemplFromView)));
		}
		#endregion
		
		#region Methods
		
		/// <summary>
		/// </summary>
		/// <param name="nWhatInv"></param>
		/// <returns></returns>
		public virtual SalNumber CopyViewDefinition(SalNumber nWhatInv)
		{
			#region Local Variables
			SalBoolean bOk = false;
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				switch (nWhatInv)
				{
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
						return true;
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
						using(SignatureHints hints = SignatureHints.NewContext())
						{
							hints.Add("External_File_Utility_API.Copy_File_Type_From_View", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
							bOk = DbPLSQLTransaction(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "External_File_Utility_API.Copy_File_Type_From_View(\r\n" +
								"                  :i_hWndFrame.dlgCreateFileTypeTemplFromView.dfsViewName1,\r\n" +
								"                  :i_hWndFrame.dlgCreateFileTypeTemplFromView.dfsInputPackage,\r\n" +
								"                  :i_hWndFrame.dlgCreateFileTypeTemplFromView.dfsComponent,\r\n" +
								"                  :i_hWndFrame.dlgCreateFileTypeTemplFromView.dfFileType,\r\n" +
								"                  :i_hWndFrame.dlgCreateFileTypeTemplFromView.dfsDescriptionTo,\r\n" +
								"                  :i_hWndFrame.dlgCreateFileTypeTemplFromView.dfFileTemplate,\r\n" +
								"                  :i_hWndFrame.dlgCreateFileTypeTemplFromView.dfsDescriptionTemplate,\r\n" +
								"                  :i_hWndFrame.dlgCreateFileTypeTemplFromView.cbCreateInput,\r\n" +
								"                  :i_hWndFrame.dlgCreateFileTypeTemplFromView.cbCreateOutput )");
						}
						if (bOk) 
						{
							return true;
						}
						else
						{
							return false;
						}
						break;
				}
			}

			return 0;
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
							if (dfsComponent.Text == Ifs.Fnd.ApplicationForms.Const.strNULL || dfsViewName1.Text == Ifs.Fnd.ApplicationForms.Const.strNULL || dfFileType.Text == Ifs.Fnd.ApplicationForms.Const.strNULL || dfsDescriptionTo.Text == Ifs.Fnd.ApplicationForms.Const.strNULL) 
							{
								return false;
							}
							if (cCreateTemplate.Checked != false) 
							{
								if (dfFileTemplate.Text == Ifs.Fnd.ApplicationForms.Const.strNULL || dfsDescriptionTemplate.Text == Ifs.Fnd.ApplicationForms.Const.strNULL) 
								{
									return false;
								}
								if (cbCreateInput.Checked != false && dfsInputPackage.Text == Ifs.Fnd.ApplicationForms.Const.strNULL) 
								{
									return false;
								}
							}
							return true;
						
						case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
							if (CopyViewDefinition(nWhatInv)) 
							{
								sFileType = dfFileType.Text;
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
							Sal.EndDialog(i_hWndFrame, Sys.IDOK);
							break;
					}
				}
				if (sAction == "ListButton") 
				{
					switch (nWhatInv)
					{
						case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
							if (hWndLovField != SalWindowHandle.Null) 
							{
								return true;
							}
							return false;
						
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
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public new SalBoolean FrameStartupUser()
		{
			#region Actions
			using (new SalContext(this))
			{
				cCreateTemplate.Checked = true;
				cbCreateInput.Checked = false;
				cbCreateOutput.Checked = true;
				Sal.DisableWindowAndLabel(cbCreateInput);
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
		private void dlgCreateFileTypeTemplFromView_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Create:
					this.dlgCreateFileTypeTemplFromView_OnSAM_Create(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_Create event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dlgCreateFileTypeTemplFromView_OnSAM_Create(object sender, WindowActionsEventArgs e)
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
		private void dfsComponent_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovUserOrderBy:
					e.Handled = true;
					e.Return = ((SalString)"NAME").ToHandle();
					return;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
					this.dfsComponent_OnPM_DataItemValidate(sender, e);
					break;
				
				case Sys.SAM_SetFocus:
					this.dfsComponent_OnSAM_SetFocus(sender, e);
					break;
				
				case Sys.SAM_KillFocus:
					this.dfsComponent_OnSAM_KillFocus(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// PM_DataItemValidate event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfsComponent_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
			if (this.dfsComponent.Text != Ifs.Fnd.ApplicationForms.Const.strNULL) 
			{
				using(SignatureHints hints = SignatureHints.NewContext())
				{
					hints.Add("MODULE_API.Exist", System.Data.ParameterDirection.Input);
					if (this.dfsComponent.DbPLSQLBlock(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "MODULE_API.Exist(\r\n" +
						":i_hWndFrame.dlgCreateFileTypeTemplFromView.dfsComponent )")) 
					{
						this.pbOk.MethodInvestigateState();
						e.Return = Sys.VALIDATE_Ok;
						return;
					}
				}
				this.pbOk.MethodInvestigateState();
			}
			e.Return = Sys.VALIDATE_Ok;
			return;
			#endregion
		}
		
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfsComponent_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam)) 
			{
				if (this.dfsComponent.p_sLovReference != Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
					this.hWndLovField = this.dfsComponent.i_hWndSelf;
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
		/// SAM_KillFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfsComponent_OnSAM_KillFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sys.wParam.ToWindowHandle() != this.pbList.i_hWndSelf) 
			{
				this.hWndLovField = SalWindowHandle.Null;
				this.pbList.MethodInvestigateState();
			}
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void dfsViewName1_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
					this.dfsViewName1_OnPM_DataItemValidate(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovUserWhere:
					this.dfsViewName1_OnPM_DataItemLovUserWhere(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovUserOrderBy:
					e.Handled = true;
					e.Return = ((SalString)"VIEW_NAME").ToHandle();
					return;
				
				case Sys.SAM_SetFocus:
					this.dfsViewName1_OnSAM_SetFocus(sender, e);
					break;
				
				case Sys.SAM_KillFocus:
					this.dfsViewName1_OnSAM_KillFocus(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// PM_DataItemValidate event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfsViewName1_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
			Sal.DisableWindowAndLabel(this.cbCreateInput);
			this.cbCreateInput.Checked = false;
			if (this.dfsViewName1.Text != Ifs.Fnd.ApplicationForms.Const.strNULL) 
			{
				if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsViewAvailable(this.dfsViewName1.Text))) 
				{
                    Ifs.Fnd.ApplicationForms.Int.AlertBox(Ifs.Application.Accrul.Properties.Resources.TEXT_NotValidView, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
					this.dfsViewName1.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
					this.dfsInputPackage.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
					this.pbOk.MethodInvestigateState();
                    // Bug 107870 Begin, Changed VALIDATE_Cancel to VALIDATE_Ok
					e.Return = Sys.VALIDATE_Ok;
                    // Bug 107870 End.
					return;
				}
				else
				{
					using(SignatureHints hints = SignatureHints.NewContext())
					{
						hints.Add("External_File_Utility_API.Get_Input_Package", System.Data.ParameterDirection.Input);
						if (!(this.dfsViewName1.DbPLSQLBlock(cSessionManager.c_hSql, ":i_hWndFrame.dlgCreateFileTypeTemplFromView.dfsInputPackage :=  " + cSessionManager.c_sDbPrefix + "External_File_Utility_API.Get_Input_Package(:i_hWndFrame.dlgCreateFileTypeTemplFromView.dfsViewName1)"))) 
						{
							this.dfsInputPackage.Text = Sys.STRING_Null;
							this.dfsInputPackage.EditDataItemSetEdited();
							e.Return = Sys.VALIDATE_Ok;
							return;
						}
						else
						{
							if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable(this.dfsInputPackage.Text))) 
							{
                                Ifs.Fnd.ApplicationForms.Int.AlertBox(Ifs.Application.Accrul.Properties.Resources.TEXT_NotValidPackage, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
								this.dfsInputPackage.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
							}
							this.dfsInputPackage.EditDataItemSetEdited();
							Sal.EnableWindowAndLabel(this.cbCreateInput);
						}
					}
				}
				this.pbOk.MethodInvestigateState();
				e.Return = Sys.VALIDATE_Ok;
				return;
			}
            // Bug 107870 Begin
            this.pbOk.MethodInvestigateState();
            e.Return = Sys.VALIDATE_Ok;
            // Bug 107870 End.
            return;
			#endregion
		}
		
		/// <summary>
		/// PM_DataItemLovUserWhere event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfsViewName1_OnPM_DataItemLovUserWhere(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (this.dfsComponent.Text != Ifs.Fnd.ApplicationForms.Const.strNULL) 
			{
				e.Return = ((SalString)("COMPONENT = '" + this.dfsComponent.Text + "'")).ToHandle();
				return;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfsViewName1_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam)) 
			{
				this.sViewType = Ifs.Fnd.ApplicationForms.Const.strNULL;
				if (this.dfsComponent.Text != Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
					if (this.dfsViewName1.p_sLovReference != Ifs.Fnd.ApplicationForms.Const.strNULL) 
					{
						this.hWndLovField = this.dfsViewName1.i_hWndSelf;
						cObjectRelationManager.__bLOV = false;
					}
					else
					{
						this.hWndLovField = SalWindowHandle.Null;
					}
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
		/// SAM_KillFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfsViewName1_OnSAM_KillFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sys.wParam.ToWindowHandle() != this.pbList.i_hWndSelf) 
			{
				this.hWndLovField = SalWindowHandle.Null;
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
				
				case Sys.SAM_AnyEdit:
					e.Handled = true;
					this.pbOk.MethodInvestigateState();
					break;
				
				case Sys.SAM_KillFocus:
					this.dfFileType_OnSAM_KillFocus(sender, e);
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
		/// SAM_KillFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfFileType_OnSAM_KillFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.dfFileTemplate.Text = this.dfFileType.Text;
			this.pbOk.MethodInvestigateState();
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void dfsDescriptionTo_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_SetFocus:
					this.dfsDescriptionTo_OnSAM_SetFocus(sender, e);
					break;
				
				case Sys.SAM_AnyEdit:
					e.Handled = true;
					this.pbOk.MethodInvestigateState();
					break;
				
				case Sys.SAM_KillFocus:
					this.dfsDescriptionTo_OnSAM_KillFocus(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfsDescriptionTo_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam)) 
			{
				if (this.dfsDescriptionTo.p_sLovReference != Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
					this.hWndLovField = this.dfsDescriptionTo.i_hWndSelf;
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
		/// SAM_KillFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfsDescriptionTo_OnSAM_KillFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.dfsDescriptionTemplate.Text = this.dfsDescriptionTo.Text;
			this.pbOk.MethodInvestigateState();
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void cCreateTemplate_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Click:
					this.cCreateTemplate_OnSAM_Click(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_Click event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cCreateTemplate_OnSAM_Click(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (this.cCreateTemplate.Checked) 
			{
				this.dfFileTemplate.Text = this.dfFileType.Text;
				this.dfsDescriptionTemplate.Text = this.dfsDescriptionTo.Text;
				this.cbCreateInput.Checked = false;
				this.cbCreateOutput.Checked = true;
				Sal.EnableWindowAndLabel(this.dfFileTemplate);
				Sal.EnableWindowAndLabel(this.dfsDescriptionTemplate);
				Sal.EnableWindowAndLabel(this.cbCreateInput);
				Sal.EnableWindowAndLabel(this.cbCreateOutput);
			}
			else
			{
				this.dfFileTemplate.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
				this.dfsDescriptionTemplate.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
				this.cbCreateInput.Checked = false;
				this.cbCreateOutput.Checked = false;
				Sal.DisableWindowAndLabel(this.dfFileTemplate);
				Sal.DisableWindowAndLabel(this.dfsDescriptionTemplate);
				Sal.DisableWindowAndLabel(this.cbCreateInput);
				Sal.DisableWindowAndLabel(this.cbCreateOutput);
			}
			this.pbOk.MethodInvestigateState();
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void dfFileTemplate_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_SetFocus:
					this.dfFileTemplate_OnSAM_SetFocus(sender, e);
					break;
				
				case Sys.SAM_AnyEdit:
					e.Handled = true;
					this.pbOk.MethodInvestigateState();
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfFileTemplate_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam)) 
			{
				if (this.dfFileTemplate.p_sLovReference != Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
					this.hWndLovField = this.dfFileTemplate.i_hWndSelf;
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
		private void dfsDescriptionTemplate_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_SetFocus:
					this.dfsDescriptionTemplate_OnSAM_SetFocus(sender, e);
					break;
				
				case Sys.SAM_AnyEdit:
					e.Handled = true;
					this.pbOk.MethodInvestigateState();
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfsDescriptionTemplate_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam)) 
			{
				if (this.dfsDescriptionTemplate.p_sLovReference != Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
					this.hWndLovField = this.dfsDescriptionTemplate.i_hWndSelf;
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
		private void cbCreateInput_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Click:
					this.cbCreateInput_OnSAM_Click(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_Click event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cbCreateInput_OnSAM_Click(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (this.dfsInputPackage.Text == Ifs.Fnd.ApplicationForms.Const.strNULL) 
			{
				this.cbCreateInput.Checked = false;
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
