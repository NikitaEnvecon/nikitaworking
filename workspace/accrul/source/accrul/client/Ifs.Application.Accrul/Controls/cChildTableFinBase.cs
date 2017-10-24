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
	public partial class cChildTableFinBase : cChildTable
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
		public cChildTableFinBase()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
		}
		
		/// <summary>
		/// Multiple Inheritance: Constructor.
		/// </summary>
		/// <param name="derived"></param>
		public cChildTableFinBase(ISalWindow derived)
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
		/// Multiple Inheritance: Cast operator from type cChildTableFinBase to type cTableManager.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cTableManager(cChildTableFinBase self)
		{
			return self._cTableManager;
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cChildTableFinBase to type cSessionManager.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cSessionManager(cChildTableFinBase self)
		{
			return ((cSessionManager)self._cTableManager);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cChildTableFinBase to type cWindowTranslation.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cWindowTranslation(cChildTableFinBase self)
		{
			return ((cWindowTranslation)self._cTableManager);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cChildTableFinBase to type cResize.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cResize(cChildTableFinBase self)
		{
			return self._cResize;
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cTableManager to type cChildTableFinBase.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cChildTableFinBase(cTableManager super)
		{
			return ((cChildTableFinBase)super._derived);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cSessionManager to type cChildTableFinBase.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cChildTableFinBase(cSessionManager super)
		{
			return ((cChildTableFinBase)((cTableManager)super._derived));
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cWindowTranslation to type cChildTableFinBase.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cChildTableFinBase(cWindowTranslation super)
		{
			return ((cChildTableFinBase)((cTableManager)super._derived));
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cResize to type cChildTableFinBase.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cChildTableFinBase(cResize super)
		{
			return ((cChildTableFinBase)((cTableManager)super._derived));
		}
		#endregion
		
		#region System Methods/Properties
		
		/// <summary>
		/// Returns the object instance associated with the window handle.
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public new static cChildTableFinBase FromHandle(SalWindowHandle handle)
		{
			return ((cChildTableFinBase)SalWindow.FromHandle(handle, typeof(cChildTableFinBase)));
		}
		#endregion
	}
}
