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
	public class cDataFieldFinContent : cDataField
	{
		#region Fields
		[ThreadStatic]
		public static SalWindowHandle c_hMySellContHandle;

		#region Static Fields initialization
		[ThreadStatic]
		private static bool threadStaticsInitialized;

		internal static void InitThreadStaticFields()
		{
			if (!threadStaticsInitialized)
			{
				threadStaticsInitialized = true;
				c_hMySellContHandle = SalWindowHandle.Null;
			}
		}
		#endregion

		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		public cDataFieldFinContent()
		{
			InitThreadStaticFields();
		
			// This call is required by the Windows Form Designer.
			InitializeComponent();
		}
		
		/// <summary>
		/// Multiple Inheritance: Constructor.
		/// </summary>
		/// <param name="derived"></param>
		public cDataFieldFinContent(ISalWindow derived)
		{
			InitThreadStaticFields();
		
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
			// cDataFieldFinContent
			// 
			this.Name = "cDataFieldFinContent";
			this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cDataFieldFinContent_WindowActions);
		}
		#endregion
		
		#region Window Actions
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void cDataFieldFinContent_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Const.PAM_CellContentFind:
					this.cDataFieldFinContent_OnPAM_CellContentFind(sender, e);
					break;
				
				case Const.PAM_SetCodePartValue:
					this.cDataFieldFinContent_OnPAM_SetCodePartValue(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// PAM_CellContentFind event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cDataFieldFinContent_OnPAM_CellContentFind(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.IsWindowVisible(this.i_hWndSelf)) 
			{
				cDataFieldFinContent.c_hMySellContHandle = Sys.lParam.ToWindowHandle();
				Sal.SendMsg(cDataFieldFinContent.c_hMySellContHandle, Const.PAM_CellContentFound, Sys.wParam, Sal.WindowHandleToNumber(this));
			}
			#endregion
		}
		
		/// <summary>
		/// PAM_SetCodePartValue event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cDataFieldFinContent_OnPAM_SetCodePartValue(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.IsWindowVisible(this.i_hWndSelf)) 
			{
				Sal.SetWindowText(this.i_hWndSelf, cChildTableFin.sCodePartValue);
				e.Return = true;
				return;
			}
			#endregion
		}
		#endregion
		
		#region Multiple Inheritance Operators
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cDataFieldFinContent to type cEditControlsManager.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cEditControlsManager(cDataFieldFinContent self)
		{
			return self._cEditControlsManager;
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cDataFieldFinContent to type cSessionManager.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cSessionManager(cDataFieldFinContent self)
		{
			return ((cSessionManager)self._cEditControlsManager);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cDataFieldFinContent to type cResize.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cResize(cDataFieldFinContent self)
		{
			return self._cResize;
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cEditControlsManager to type cDataFieldFinContent.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cDataFieldFinContent(cEditControlsManager super)
		{
			return ((cDataFieldFinContent)super._derived);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cSessionManager to type cDataFieldFinContent.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cDataFieldFinContent(cSessionManager super)
		{
			return ((cDataFieldFinContent)((cEditControlsManager)super._derived));
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cResize to type cDataFieldFinContent.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cDataFieldFinContent(cResize super)
		{
			return ((cDataFieldFinContent)((cEditControlsManager)super._derived));
		}
		#endregion
		
		#region System Methods/Properties
		
		/// <summary>
		/// Returns the object instance associated with the window handle.
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public new static cDataFieldFinContent FromHandle(SalWindowHandle handle)
		{
			return ((cDataFieldFinContent)SalWindow.FromHandle(handle, typeof(cDataFieldFinContent)));
		}
		#endregion
	}
}
