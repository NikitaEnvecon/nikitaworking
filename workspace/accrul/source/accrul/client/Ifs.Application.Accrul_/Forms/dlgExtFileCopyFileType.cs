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
	/// <param name="sFileDesc"></param>
	/// <param name="sFileTypeReturn"></param>
	public partial class dlgExtFileCopyFileType : cDialogBox
	{
		#region Window Parameters
		public SalString sFileType;
		public SalString sFileDesc;
		public SalString sFileTypeReturn;
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
		protected dlgExtFileCopyFileType()
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
		public static SalNumber ModalDialog(Control owner, SalString sFileType, SalString sFileDesc, ref SalString sFileTypeReturn)
		{
			dlgExtFileCopyFileType dlg = DialogFactory.CreateInstance<dlgExtFileCopyFileType>();
			dlg.sFileType = sFileType;
			dlg.sFileDesc = sFileDesc;
			dlg.sFileTypeReturn = sFileTypeReturn;
			SalNumber ret = dlg.ShowDialog(owner);
			sFileTypeReturn = dlg.sFileTypeReturn;
			return ret;
		}
		
		/// <summary>
		/// Returns the object instance associated with the window handle.
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public new static dlgExtFileCopyFileType FromHandle(SalWindowHandle handle)
		{
			return ((dlgExtFileCopyFileType)SalWindow.FromHandle(handle, typeof(dlgExtFileCopyFileType)));
		}
		#endregion
		
		#region Methods
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean CopyFileType()
		{
			#region Local Variables
			SalBoolean bOk = false;
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				Sal.WaitCursor(true);
				using(SignatureHints hints = SignatureHints.NewContext())
				{
					hints.Add("External_File_Utility_API.Copy_File_Type_From_Type", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
					bOk = DbPLSQLTransaction(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "External_File_Utility_API.Copy_File_Type_From_Type(\r\n" +
						"                       :i_hWndFrame.dlgExtFileCopyFileType.dfFileType,\r\n" +
						"                       :i_hWndFrame.dlgExtFileCopyFileType.dfsDescriptionTo,\r\n" +
						"                       :i_hWndFrame.dlgExtFileCopyFileType.dfFromFileType)");
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
				dfFromFileType.Text = sFileType;
				dfsDescriptionFrom.Text = sFileDesc;
				if (sFileType != Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
					Sal.SetFocus(dfFileType);
				}
				else
				{
					Sal.SetFocus(dfFromFileType);
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
							if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("External_File_Utility_API.Copy_File_Type_From_Type"))) 
							{
								return false;
							}
							if (dfFileType.Text == Ifs.Fnd.ApplicationForms.Const.strNULL || dfsDescriptionTo.Text == Ifs.Fnd.ApplicationForms.Const.strNULL) 
							{
								return false;
							}
							return true;
						
						case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
							if (CopyFileType()) 
							{
								sFileTypeReturn = dfFileType.Text;
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
		#endregion
		
		#region Window Actions
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void dlgExtFileCopyFileType_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Create:
					this.dlgExtFileCopyFileType_OnSAM_Create(sender, e);
					break;
				
				case Sys.SAM_Close:
					e.Handled = true;
					Sal.EndDialog(this.i_hWndFrame, Sys.IDOK);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_Create event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dlgExtFileCopyFileType_OnSAM_Create(object sender, WindowActionsEventArgs e)
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
		private void dfFromFileType_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Validate:
					this.dfFromFileType_OnSAM_Validate(sender, e);
					break;
				
				case Sys.SAM_SetFocus:
					this.dfFromFileType_OnSAM_SetFocus(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_Validate event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfFromFileType_OnSAM_Validate(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			using(SignatureHints hints = SignatureHints.NewContext())
			{
				hints.Add("Ext_File_Type_API.Get_Description", System.Data.ParameterDirection.Input);
				if (!(this.dfFromFileType.DbPLSQLBlock(cSessionManager.c_hSql, ":i_hWndFrame.dlgExtFileCopyFileType.dfsDescriptionFrom :=  " + cSessionManager.c_sDbPrefix + "Ext_File_Type_API.Get_Description(\r\n" +
					":i_hWndFrame.dlgExtFileCopyFileType.dfFromFileType)"))) 
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
		private void dfFromFileType_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam)) 
			{
				if (this.dfFromFileType.p_sLovReference != Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
					this.hWndLovField = this.dfFromFileType.i_hWndSelf;
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
		private void dfsDescriptionFrom_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_SetFocus:
					this.dfsDescriptionFrom_OnSAM_SetFocus(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfsDescriptionFrom_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam)) 
			{
				if (this.dfsDescriptionFrom.p_sLovReference != Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
					this.hWndLovField = this.dfsDescriptionFrom.i_hWndSelf;
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
