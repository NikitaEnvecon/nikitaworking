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
	/// To be used in modal dialogs, standard data field that may represent a code part.
	/// May also be used for fields with list of values
	/// </summary>
	public class cDataFieldDlgFin : cDataFieldFin
	{
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		public cDataFieldDlgFin()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
		}
		
		/// <summary>
		/// Multiple Inheritance: Constructor.
		/// </summary>
		/// <param name="derived"></param>
		public cDataFieldDlgFin(ISalWindow derived)
		{
			// Attach derived instance.
			this._derived = derived;
			// This call is required by the Windows Form Designer.
			InitializeComponent();
			// Attach actions handler to derived instance.
			this._derived.AttachMessageActions(this);
		}
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// cDataFieldDlgFin
			// 
			this.Name = "cDataFieldDlgFin";
			this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cDataFieldDlgFin_WindowActions);
		}
		#endregion
		
		#region Window Actions
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void cDataFieldDlgFin_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_AnyEdit:
					this.cDataFieldDlgFin_OnSAM_AnyEdit(sender, e);
					break;
				
				case Sys.SAM_SetFocus:
					this.cDataFieldDlgFin_OnSAM_SetFocus(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLov:
					this.cDataFieldDlgFin_OnPM_DataItemLov(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_AnyEdit event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cDataFieldDlgFin_OnSAM_AnyEdit(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			// This message can probably be removed from Fnd1 release 2.1
			if (!(Sal.SendClassMessage(Sys.SAM_AnyEdit, Sys.wParam, Sys.lParam))) 
			{
				e.Return = false;
				return;
			}
			e.Return = Sal.SendMsg(this.i_hWndParent, Const.PAM_DlgCheckState, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
			return;
			#endregion
		}
		
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cDataFieldDlgFin_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (!(Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam))) 
			{
				e.Return = false;
				return;
			}
			Sal.SendMsg(this.i_hWndParent, Const.PAM_DlgSetLovState, 0, this.i_hWndSelf.ToNumber());
			e.Return = true;
			return;
			#endregion
		}
		
		/// <summary>
		/// PM_DataItemLov event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cDataFieldDlgFin_OnPM_DataItemLov(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (!(Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemLov, Sys.wParam, Sys.lParam))) 
			{
				e.Return = false;
				return;
			}
			if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
			{
				Sal.SetFocus(this.i_hWndSelf);
			}
			e.Return = true;
			return;
			#endregion
		}
		#endregion
		
		#region Multiple Inheritance Operators
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cDataFieldDlgFin to type cEditControlsManager.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cEditControlsManager(cDataFieldDlgFin self)
		{
			return self._cEditControlsManager;
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cDataFieldDlgFin to type cSessionManager.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cSessionManager(cDataFieldDlgFin self)
		{
			return ((cSessionManager)self._cEditControlsManager);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cDataFieldDlgFin to type cResize.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cResize(cDataFieldDlgFin self)
		{
			return self._cResize;
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cEditControlsManager to type cDataFieldDlgFin.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cDataFieldDlgFin(cEditControlsManager super)
		{
			return ((cDataFieldDlgFin)super._derived);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cSessionManager to type cDataFieldDlgFin.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cDataFieldDlgFin(cSessionManager super)
		{
			return ((cDataFieldDlgFin)((cEditControlsManager)super._derived));
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cResize to type cDataFieldDlgFin.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cDataFieldDlgFin(cResize super)
		{
			return ((cDataFieldDlgFin)((cEditControlsManager)super._derived));
		}
		#endregion
		
		#region System Methods/Properties
		
		/// <summary>
		/// Returns the object instance associated with the window handle.
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public new static cDataFieldDlgFin FromHandle(SalWindowHandle handle)
		{
			return ((cDataFieldDlgFin)SalWindow.FromHandle(handle, typeof(cDataFieldDlgFin)));
		}
		#endregion
	}
}
