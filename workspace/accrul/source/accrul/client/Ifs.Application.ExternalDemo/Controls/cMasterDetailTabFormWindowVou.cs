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
	/// This window is specially designed for Voucher Entry
	/// </summary>
	public partial class cMasterDetailTabFormWindowVou : cMasterDetailTabFormWindowFin
	{
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		public cMasterDetailTabFormWindowVou()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
		}
		
		/// <summary>
		/// Multiple Inheritance: Constructor.
		/// </summary>
		/// <param name="derived"></param>
		public cMasterDetailTabFormWindowVou(ISalWindow derived)
		{
			// Attach derived instance.
			this._derived = derived;
			// This call is required by the Windows Form Designer.
			InitializeComponent();
			// Attach actions handler to derived instance.
			this._derived.AttachMessageActions(this);
		}
		#endregion
		
		#region Window Actions
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void cMasterDetailTabFormWindowVou_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_CreateComplete:
					e.Handled = true;
					Sal.SendClassMessage(Sys.SAM_CreateComplete, Sys.wParam, Sys.lParam);
					break;
			}
			#endregion
		}
		#endregion
		
		#region Multiple Inheritance Operators
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cMasterDetailTabFormWindowVou to type cDataSource.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cDataSource(cMasterDetailTabFormWindowVou self)
		{
			return self._cDataSource;
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cMasterDetailTabFormWindowVou to type cSessionManager.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cSessionManager(cMasterDetailTabFormWindowVou self)
		{
			return ((cSessionManager)self._cDataSource);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cMasterDetailTabFormWindowVou to type cWindowTranslation.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cWindowTranslation(cMasterDetailTabFormWindowVou self)
		{
			return ((cWindowTranslation)self._cDataSource);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cMasterDetailTabFormWindowVou to type SalToolTipManager.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator SalToolTipManager(cMasterDetailTabFormWindowVou self)
		{
			return self._SalToolTipManager;
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cMasterDetailTabFormWindowVou to type cTabManager.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cTabManager(cMasterDetailTabFormWindowVou self)
		{
			return self._cTabManager;
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cMasterDetailTabFormWindowVou to type cFinlibServices.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cFinlibServices(cMasterDetailTabFormWindowVou self)
		{
			return self._cFinlibServices;
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cDataSource to type cMasterDetailTabFormWindowVou.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cMasterDetailTabFormWindowVou(cDataSource super)
		{
			return ((cMasterDetailTabFormWindowVou)super._derived);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cSessionManager to type cMasterDetailTabFormWindowVou.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cMasterDetailTabFormWindowVou(cSessionManager super)
		{
			return ((cMasterDetailTabFormWindowVou)((cDataSource)super._derived));
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cWindowTranslation to type cMasterDetailTabFormWindowVou.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cMasterDetailTabFormWindowVou(cWindowTranslation super)
		{
			return ((cMasterDetailTabFormWindowVou)((cDataSource)super._derived));
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type SalToolTipManager to type cMasterDetailTabFormWindowVou.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cMasterDetailTabFormWindowVou(SalToolTipManager super)
		{
			return ((cMasterDetailTabFormWindowVou)((cDataSource)super._derived));
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cTabManager to type cMasterDetailTabFormWindowVou.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cMasterDetailTabFormWindowVou(cTabManager super)
		{
			return ((cMasterDetailTabFormWindowVou)super._derived);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cFinlibServices to type cMasterDetailTabFormWindowVou.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cMasterDetailTabFormWindowVou(cFinlibServices super)
		{
			return ((cMasterDetailTabFormWindowVou)super._derived);
		}
		#endregion
		
		#region System Methods/Properties
		
		/// <summary>
		/// Returns the object instance associated with the window handle.
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public new static cMasterDetailTabFormWindowVou FromHandle(SalWindowHandle handle)
		{
			return ((cMasterDetailTabFormWindowVou)SalWindow.FromHandle(handle, typeof(cMasterDetailTabFormWindowVou)));
		}
		#endregion
	}
}
