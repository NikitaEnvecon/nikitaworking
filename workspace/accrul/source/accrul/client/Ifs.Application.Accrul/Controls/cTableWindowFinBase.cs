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
	public partial class cTableWindowFinBase : cTableWindow
	{
		#region Fields
		public SalString i_sReportCompany = "";
		public SalString i_sTempReportCompany = "";
		public SalString i_sCompanyName = "";
		public SalString i_sCompanyLogoPath = "";
		public SalString i_sLogoData = "";
		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		public cTableWindowFinBase()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
		}
		
		/// <summary>
		/// Multiple Inheritance: Constructor.
		/// </summary>
		/// <param name="derived"></param>
		public cTableWindowFinBase(ISalWindow derived)
		{
			// Attach derived instance.
			this._derived = derived;
			// This call is required by the Windows Form Designer.
			InitializeComponent();
			// Attach actions handler to derived instance.
			this._derived.AttachMessageActions(this);
		}
		#endregion
		
		#region Multiple Inheritance Operators
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cTableWindowFinBase to type cTableManager.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cTableManager(cTableWindowFinBase self)
		{
			return self._cTableManager;
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cTableWindowFinBase to type cSessionManager.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cSessionManager(cTableWindowFinBase self)
		{
			return ((cSessionManager)self._cTableManager);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cTableWindowFinBase to type cWindowTranslation.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cWindowTranslation(cTableWindowFinBase self)
		{
			return ((cWindowTranslation)self._cTableManager);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cTableWindowFinBase to type SalToolTipManager.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator SalToolTipManager(cTableWindowFinBase self)
		{
			return self._SalToolTipManager;
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cTableManager to type cTableWindowFinBase.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cTableWindowFinBase(cTableManager super)
		{
			return ((cTableWindowFinBase)super._derived);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cSessionManager to type cTableWindowFinBase.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cTableWindowFinBase(cSessionManager super)
		{
			return ((cTableWindowFinBase)((cTableManager)super._derived));
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cWindowTranslation to type cTableWindowFinBase.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cTableWindowFinBase(cWindowTranslation super)
		{
			return ((cTableWindowFinBase)((cTableManager)super._derived));
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type SalToolTipManager to type cTableWindowFinBase.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cTableWindowFinBase(SalToolTipManager super)
		{
			return ((cTableWindowFinBase)((cTableManager)super._derived));
		}
		#endregion
		
		#region System Methods/Properties
		
		/// <summary>
		/// Returns the object instance associated with the window handle.
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public new static cTableWindowFinBase FromHandle(SalWindowHandle handle)
		{
			return ((cTableWindowFinBase)SalWindow.FromHandle(handle, typeof(cTableWindowFinBase)));
		}
		#endregion
	}
}
