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
	public class cColumnExtFileLoad : cColumn
	{
		#region Fields
		public SalString i_sColumnName = "";
		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		public cColumnExtFileLoad()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
		}
		
		/// <summary>
		/// Multiple Inheritance: Constructor.
		/// </summary>
		/// <param name="derived"></param>
		public cColumnExtFileLoad(ISalWindow derived)
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
			// cColumnExtFileLoad
			// 
			this.Name = "cColumnExtFileLoad";
			this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cColumnExtFileLoad_WindowActions);
		}
		#endregion
		
		#region Window Actions
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void cColumnExtFileLoad_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Create:
					this.cColumnExtFileLoad_OnSAM_Create(sender, e);
					break;
				
				case Const.PAM_ExtTranslateTitle:
					this.cColumnExtFileLoad_OnPAM_ExtTranslateTitle(sender, e);
					break;
				
				case Const.PAM_ExtEnableDisable:
					this.cColumnExtFileLoad_OnPAM_ExtEnableDisable(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_Create event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cColumnExtFileLoad_OnSAM_Create(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam)) 
			{
				Sal.HideWindowAndLabel(this.i_hWndSelf);
				e.Return = true;
				return;
			}
			e.Return = false;
			return;
			#endregion
		}
		
		/// <summary>
		/// PAM_ExtTranslateTitle event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cColumnExtFileLoad_OnPAM_ExtTranslateTitle(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (this.p_sSqlColumn == SalString.FromHandle(Sys.wParam)) 
			{
				Sal.ShowWindowAndLabel(this.i_hWndSelf);
				if (SalString.FromHandle(Sys.lParam) == Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
					Sal.TblSetColumnTitle(this.i_hWndSelf, this.p_sSqlColumn);
				}
				else
				{
					Sal.TblSetColumnTitle(this.i_hWndSelf, SalString.FromHandle(Sys.lParam));
				}
			}
			#endregion
		}
		
		/// <summary>
		/// PAM_ExtEnableDisable event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cColumnExtFileLoad_OnPAM_ExtEnableDisable(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sys.wParam == Const.METHOD_ExtDisable) 
			{
				Sal.HideWindowAndLabel(this.i_hWndSelf);
			}
			else if (Sys.wParam == Const.METHOD_ExtEnable) 
			{
				Sal.ShowWindowAndLabel(this.i_hWndSelf);
			}
			else if (Sys.wParam == Const.METHOD_ExtEnableDefault) 
			{
				Sal.TblSetColumnTitle(this.i_hWndSelf, this.i_sColumnName);
				if (this.i_sColumnName == Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
					Sal.HideWindowAndLabel(this.i_hWndSelf);
				}
				else
				{
					Sal.ShowWindowAndLabel(this.i_hWndSelf);
				}
			}
			else
			{
				e.Return = false;
				return;
			}
			#endregion
		}
		#endregion
		
		#region Multiple Inheritance Operators
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cColumnExtFileLoad to type cEditControlsManager.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cEditControlsManager(cColumnExtFileLoad self)
		{
			return self._cEditControlsManager;
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cColumnExtFileLoad to type cSessionManager.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cSessionManager(cColumnExtFileLoad self)
		{
			return ((cSessionManager)self._cEditControlsManager);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cEditControlsManager to type cColumnExtFileLoad.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cColumnExtFileLoad(cEditControlsManager super)
		{
			return ((cColumnExtFileLoad)super._derived);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cSessionManager to type cColumnExtFileLoad.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cColumnExtFileLoad(cSessionManager super)
		{
			return ((cColumnExtFileLoad)((cEditControlsManager)super._derived));
		}
		#endregion
		
		#region System Methods/Properties
		
		/// <summary>
		/// Returns the object instance associated with the window handle.
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public new static cColumnExtFileLoad FromHandle(SalWindowHandle handle)
		{
			return ((cColumnExtFileLoad)SalWindow.FromHandle(handle, typeof(cColumnExtFileLoad)));
		}
		#endregion
	}
}
