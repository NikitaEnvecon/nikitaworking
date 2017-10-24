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
	/// In the Internal ledger , code parts demands given by the accounting rules need not to be checked.
	/// </summary>
	public class cColumnCodePartInt : cColumnCodePartFin
	{
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		public cColumnCodePartInt()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
		}
		
		/// <summary>
		/// Multiple Inheritance: Constructor.
		/// </summary>
		/// <param name="derived"></param>
		public cColumnCodePartInt(ISalWindow derived)
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
			// cColumnCodePartInt
			// 
			this.Name = "cColumnCodePartInt";
			this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cColumnCodePartInt_WindowActions);
		}
		#endregion
		
		#region Methods
		
		/// <summary>
		/// Get code part demand (Blocked, Can, Mandatory) and set value if exists
		/// </summary>
		/// <param name="nPLength"></param>
		/// <param name="nPAttr"></param>
		/// <returns></returns>
		public virtual new SalNumber SetCodePartValues(SalNumber nPLength, SalNumber nPAttr)
		{
			#region Local Variables
			SalNumber i_nStrLength = 0;
			SalString i_lsAttr = "";
			SalString i_sReqAttr = "";
			SalString i_sReqAttrValue = "";
			SalString sReqField = "";
			SalString sReqFieldValue = "";
			SalString sColumnName = "";
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				i_lsAttr = SalString.FromHandle(nPAttr);
				i_nStrLength = i_lsAttr.Length;
				i_sReqAttr = i_lsAttr.Left(nPLength);
				i_nStrLength = i_nStrLength - nPLength;
				i_sReqAttrValue = i_lsAttr.Right(i_nStrLength);
				sColumnName = cColumn.FromHandle(i_hWndSelf).p_sSqlColumn;
				sReqField = Ifs.Fnd.ApplicationForms.Int.PalAttrGet(sColumnName, i_sReqAttr);
				sReqFieldValue = Ifs.Fnd.ApplicationForms.Int.PalAttrGet(sColumnName, i_sReqAttrValue);
				if (Sal.IsNull(this) || (sColumnName == "ACCOUNT")) 
				{
					Sal.SendMsg(i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, sReqFieldValue.ToHandle());
				}
				else
				{
					Sal.SendMsg(i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, sReqFieldValue.ToHandle());
				}
			}

			return 0;
			#endregion
		}
		#endregion
		
		#region Window Actions
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void cColumnCodePartInt_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Const.PAM_SetCodePartValues:
					e.Handled = true;
					this.SetCodePartValues(Sys.wParam, Sys.lParam);
					break;
			}
			#endregion
		}
		#endregion
		
		#region Multiple Inheritance Operators
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cColumnCodePartInt to type cEditControlsManager.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cEditControlsManager(cColumnCodePartInt self)
		{
			return self._cEditControlsManager;
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cColumnCodePartInt to type cSessionManager.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cSessionManager(cColumnCodePartInt self)
		{
			return ((cSessionManager)self._cEditControlsManager);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cEditControlsManager to type cColumnCodePartInt.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cColumnCodePartInt(cEditControlsManager super)
		{
			return ((cColumnCodePartInt)super._derived);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cSessionManager to type cColumnCodePartInt.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cColumnCodePartInt(cSessionManager super)
		{
			return ((cColumnCodePartInt)((cEditControlsManager)super._derived));
		}
		#endregion
		
		#region System Methods/Properties
		
		/// <summary>
		/// Returns the object instance associated with the window handle.
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public new static cColumnCodePartInt FromHandle(SalWindowHandle handle)
		{
			return ((cColumnCodePartInt)SalWindow.FromHandle(handle, typeof(cColumnCodePartInt)));
		}
		#endregion
	}
}
