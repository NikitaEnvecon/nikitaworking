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
	public class cDataFieldAC : cDataField
	{
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		public cDataFieldAC()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
		}
		
		/// <summary>
		/// Multiple Inheritance: Constructor.
		/// </summary>
		/// <param name="derived"></param>
		public cDataFieldAC(ISalWindow derived)
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
			// cDataFieldAC
			// 
			this.Name = "cDataFieldAC";
			this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cDataFieldAC_WindowActions);
		}
		#endregion
		
		#region Methods
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public new SalBoolean _EditStateFieldEnabled()
		{
			#region Actions
			using (new SalContext(this))
			{
                if (!(Sal.SendMsg(i_hWndSelf, Ifs.Application.Accrul.Const.PM_ACFieldEnabled, 0, 0))) 
				{
					return false;
				}
				return ((cDataField)this)._EditStateFieldEnabled();
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
		private void cDataFieldAC_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
                case Ifs.Application.Accrul.Const.PM_ACFieldEnabled:
					e.Handled = true;
					e.Return = false;
					return;
			}
			#endregion
		}
		#endregion
		
		#region Multiple Inheritance Operators
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cDataFieldAC to type cEditControlsManager.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cEditControlsManager(cDataFieldAC self)
		{
			return self._cEditControlsManager;
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cDataFieldAC to type cSessionManager.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cSessionManager(cDataFieldAC self)
		{
			return ((cSessionManager)self._cEditControlsManager);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cDataFieldAC to type cResize.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cResize(cDataFieldAC self)
		{
			return self._cResize;
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cEditControlsManager to type cDataFieldAC.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cDataFieldAC(cEditControlsManager super)
		{
			return ((cDataFieldAC)super._derived);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cSessionManager to type cDataFieldAC.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cDataFieldAC(cSessionManager super)
		{
			return ((cDataFieldAC)((cEditControlsManager)super._derived));
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cResize to type cDataFieldAC.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cDataFieldAC(cResize super)
		{
			return ((cDataFieldAC)((cEditControlsManager)super._derived));
		}
		#endregion
		
		#region System Methods/Properties
		
		/// <summary>
		/// Returns the object instance associated with the window handle.
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public new static cDataFieldAC FromHandle(SalWindowHandle handle)
		{
			return ((cDataFieldAC)SalWindow.FromHandle(handle, typeof(cDataFieldAC)));
		}
		#endregion
		
		#region Late Bind Methods
		
		/// <summary>
		/// Virtual wrapper replacement for late-bound (..) calls.
		/// </summary>
		public override SalBoolean vrt_EditStateFieldEnabled()
		{
			LateBind lateBind = (LateBind)this._derived;
			if (lateBind == null) 
			{
				return this._EditStateFieldEnabled();
			}
			else
			{
				return lateBind.vrt_EditStateFieldEnabled();
			}
		}
		#endregion
		
		#region Multiple Inheritance Late Bind Interface
		
		public interface LateBind
		{
			SalBoolean vrt_EditStateFieldEnabled();
		}
		#endregion
	}
}
