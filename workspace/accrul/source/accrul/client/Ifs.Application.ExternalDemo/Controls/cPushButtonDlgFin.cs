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
	public class cPushButtonDlgFin : cPushButton
	{
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		public cPushButtonDlgFin()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
		}
		
		/// <summary>
		/// Multiple Inheritance: Constructor.
		/// </summary>
		/// <param name="derived"></param>
		public cPushButtonDlgFin(ISalWindow derived)
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
			// cPushButtonDlgFin
			// 
			this.Name = "cPushButtonDlgFin";
			this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cPushButtonDlgFin_WindowActions);
		}
		#endregion
		
		#region Window Actions
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void cPushButtonDlgFin_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Const.PAM_DlgSetDefPb:
					this.cPushButtonDlgFin_OnPAM_DlgSetDefPb(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// PAM_DlgSetDefPb event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cPushButtonDlgFin_OnPAM_DlgSetDefPb(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			// Add SalSetDefButton( i_hWndSelf )   if  this button, e.g. Ok button,
			// shall be the default button else just return TRUE
			// Performed in instace message FTR_DlgSetDefPb
			Ifs.Fnd.ApplicationForms.Int.InfoBox(Properties.Resources.FINTXT_DlgLovPbSetDef);
			e.Return = false;
			return;
			#endregion
		}
		#endregion
		
		#region Multiple Inheritance Operators
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cPushButtonDlgFin to type cMethodManager.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cMethodManager(cPushButtonDlgFin self)
		{
			return self._cMethodManager;
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cPushButtonDlgFin to type cSessionManager.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cSessionManager(cPushButtonDlgFin self)
		{
			return ((cSessionManager)self._cMethodManager);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cPushButtonDlgFin to type cResize.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cResize(cPushButtonDlgFin self)
		{
			return self._cResize;
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cMethodManager to type cPushButtonDlgFin.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cPushButtonDlgFin(cMethodManager super)
		{
			return ((cPushButtonDlgFin)super._derived);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cSessionManager to type cPushButtonDlgFin.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cPushButtonDlgFin(cSessionManager super)
		{
			return ((cPushButtonDlgFin)((cMethodManager)super._derived));
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cResize to type cPushButtonDlgFin.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cPushButtonDlgFin(cResize super)
		{
			return ((cPushButtonDlgFin)((cMethodManager)super._derived));
		}
		#endregion
		
		#region System Methods/Properties
		
		/// <summary>
		/// Returns the object instance associated with the window handle.
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public new static cPushButtonDlgFin FromHandle(SalWindowHandle handle)
		{
			return ((cPushButtonDlgFin)SalWindow.FromHandle(handle, typeof(cPushButtonDlgFin)));
		}
		#endregion
	}
}
