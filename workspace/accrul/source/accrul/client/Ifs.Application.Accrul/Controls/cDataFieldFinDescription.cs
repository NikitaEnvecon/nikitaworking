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
	/// This class can be used to show code part description.This only works when cColumnFin
	/// is used for codeparts.
	/// </summary>
	public class cDataFieldFinDescription : cDataField
	{
		#region Fields
		[ThreadStatic]
		public static SalWindowHandle c_hMyDescHandle;

		#region Static Fields initialization
		[ThreadStatic]
		private static bool threadStaticsInitialized;

		internal static void InitThreadStaticFields()
		{
			if (!threadStaticsInitialized)
			{
				threadStaticsInitialized = true;
				c_hMyDescHandle = SalWindowHandle.Null;
			}
		}
		#endregion

		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		public cDataFieldFinDescription()
		{
			InitThreadStaticFields();
		
			// This call is required by the Windows Form Designer.
			InitializeComponent();
		}
		
		/// <summary>
		/// Multiple Inheritance: Constructor.
		/// </summary>
		/// <param name="derived"></param>
		public cDataFieldFinDescription(ISalWindow derived)
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
			// cDataFieldFinDescription
			// 
			this.Name = "cDataFieldFinDescription";
			this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cDataFieldFinDescription_WindowActions);
		}
		#endregion
		
		#region Window Actions
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void cDataFieldFinDescription_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Const.PAM_DescriptionFind:
					this.cDataFieldFinDescription_OnPAM_DescriptionFind(sender, e);
					break;
				
				case Const.PAM_SetCodePartDesc:
					this.cDataFieldFinDescription_OnPAM_SetCodePartDesc(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// PAM_DescriptionFind event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cDataFieldFinDescription_OnPAM_DescriptionFind(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.IsWindowVisible(this.i_hWndSelf)) 
			{
				cDataFieldFinDescription.c_hMyDescHandle = Sys.lParam.ToWindowHandle();
				Sal.SendMsg(cDataFieldFinDescription.c_hMyDescHandle, Const.PAM_DescriptionFound, Sys.wParam, Sal.WindowHandleToNumber(this));
			}
			#endregion
		}
		
		/// <summary>
		/// PAM_SetCodePartDesc event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cDataFieldFinDescription_OnPAM_SetCodePartDesc(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.IsWindowVisible(this.i_hWndSelf)) 
			{
				Sal.SetWindowText(this.i_hWndSelf, cChildTableFin.sCodePartDescription);
				e.Return = true;
				return;
			}
			#endregion
		}
		#endregion
		
		#region Multiple Inheritance Operators
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cDataFieldFinDescription to type cEditControlsManager.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cEditControlsManager(cDataFieldFinDescription self)
		{
			return self._cEditControlsManager;
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cDataFieldFinDescription to type cSessionManager.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cSessionManager(cDataFieldFinDescription self)
		{
			return ((cSessionManager)self._cEditControlsManager);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cDataFieldFinDescription to type cResize.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cResize(cDataFieldFinDescription self)
		{
			return self._cResize;
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cEditControlsManager to type cDataFieldFinDescription.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cDataFieldFinDescription(cEditControlsManager super)
		{
			return ((cDataFieldFinDescription)super._derived);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cSessionManager to type cDataFieldFinDescription.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cDataFieldFinDescription(cSessionManager super)
		{
			return ((cDataFieldFinDescription)((cEditControlsManager)super._derived));
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cResize to type cDataFieldFinDescription.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cDataFieldFinDescription(cResize super)
		{
			return ((cDataFieldFinDescription)((cEditControlsManager)super._derived));
		}
		#endregion
		
		#region System Methods/Properties
		
		/// <summary>
		/// Returns the object instance associated with the window handle.
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public new static cDataFieldFinDescription FromHandle(SalWindowHandle handle)
		{
			return ((cDataFieldFinDescription)SalWindow.FromHandle(handle, typeof(cDataFieldFinDescription)));
		}
		#endregion
	}
}
