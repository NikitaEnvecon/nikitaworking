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
	/// <param name="p_sOutputFileName"></param>
	public partial class dlgAuditFileResult : cDialogBox
	{
		#region Window Parameters
		public SalString p_sFileName;
        public SalString p_sXmlFileName;
        #endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
        protected dlgAuditFileResult()
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
        public static SalNumber ModalDialog(Control owner, SalString p_sFileName, SalString p_sXmlFileName)
		{
            dlgAuditFileResult dlg = DialogFactory.CreateInstance<dlgAuditFileResult>();
            dlg.p_sFileName = p_sFileName;
            dlg.p_sXmlFileName = p_sXmlFileName;
			SalNumber ret = dlg.ShowDialog(owner);
			return ret;
		}
		
		/// <summary>
		/// Returns the object instance associated with the window handle.
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public new static dlgAuditFileResult FromHandle(SalWindowHandle handle)
		{
			return ((dlgAuditFileResult)SalWindow.FromHandle(handle, typeof(dlgAuditFileResult)));
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
				//Sal.SetWindowText(i_hWndSelf, p_sCompany + " - " + Properties.Resources.WH_dlgAuditFileResult);
				dfsOutputFileName.Text = p_sFileName + "\r\n" + p_sXmlFileName;
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
			#region Local Variables
			SalString sName = "";
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				if (sMethod == "Ok_Button") 
				{
					if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
					{
						OkPressed();
						return 1;
					}
					else
					{
						return 1;
					}
				}
				else
				{
					// message not handled
					Sal.GetItemName(Sys.hWndItem, ref sName);
					Ifs.Fnd.ApplicationForms.Int.ErrorBox("DESIGN TIME ERROR for item " + sName + "\r\n" +
						"               Function UserMethod handling method \"" + sMethod + "\" not written!");
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
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber OkPressed()
		{
			#region Actions
			using (new SalContext(this))
			{
				Sal.EndDialog(i_hWndSelf, Sys.IDOK);
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
		private void dlgAuditFileResult_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Create:
					this.dlgAuditFileResult_OnSAM_Create(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave:
					this.dlgAuditFileResult_OnPM_DataSourceSave(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_Create event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dlgAuditFileResult_OnSAM_Create(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam);
			Sal.CenterWindow(this);
			#endregion
		}
		
		/// <summary>
		/// PM_DataSourceSave event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dlgAuditFileResult_OnPM_DataSourceSave(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire) 
			{
				e.Return = false;
				return;
			}
			e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Sys.wParam, Sys.lParam);
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
