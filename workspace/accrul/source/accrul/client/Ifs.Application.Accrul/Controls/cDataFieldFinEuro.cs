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
	public class cDataFieldFinEuro : cDataFieldFin
	{
		#region Fields
		[ThreadStatic]
		public static SalString c_sCompany;
		[ThreadStatic]
		public static SalString c_sPrevCompany;
		[ThreadStatic]
		public static SalString c_sCurrency;
		[ThreadStatic]
		public static SalString c_sDescription;
		[ThreadStatic]
		public static SalString c_sTemp;
		[ThreadStatic]
		public static SalString c_sLabel;

		#region Static Fields initialization
		[ThreadStatic]
		private static bool threadStaticsInitialized;

		internal static void InitThreadStaticFields()
		{
			if (!threadStaticsInitialized)
			{
				threadStaticsInitialized = true;
				c_sCompany = "";
				c_sPrevCompany = "";
				c_sCurrency = "";
				c_sDescription = "";
				c_sTemp = "";
				c_sLabel = "";
			}
		}
		#endregion

		public SalString __sOldLabel = "";
		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		public cDataFieldFinEuro()
		{
			InitThreadStaticFields();
		
			// This call is required by the Windows Form Designer.
			InitializeComponent();
		}
		
		/// <summary>
		/// Multiple Inheritance: Constructor.
		/// </summary>
		/// <param name="derived"></param>
		public cDataFieldFinEuro(ISalWindow derived)
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
			// cDataFieldFinEuro
			// 
			this.Name = "cDataFieldFinEuro";
			this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cDataFieldFinEuro_WindowActions);
		}
		#endregion
		
		#region Methods
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean cSetCurrencyWindowText()
		{
			#region Local Variables
			SalNumber a = 0;
			SalNumber b = 0;
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				a = __sOldLabel.Scan("@");
				if (a == -1) 
				{
					return false;
				}
				else
				{
					if (((cDataFieldFinEuro.c_sDescription == Ifs.Fnd.ApplicationForms.Const.strNULL) && (cDataFieldFinEuro.c_sCompany != cDataFieldFinEuro.c_sPrevCompany)) || (cDataFieldFinEuro.c_sCompany != cDataFieldFinEuro.c_sPrevCompany)) 
					{
                        cDataFieldFinEuro.c_sDescription = Var.FinlibServices.GetParallelCurrency(cDataFieldFinEuro.c_sCompany);
                        cDataFieldFinEuro.c_sCurrency = Var.FinlibServices.GetAccountingCurrency(cDataFieldFinEuro.c_sCompany);

						cDataFieldFinEuro.c_sPrevCompany = cDataFieldFinEuro.c_sCompany;
					}
					cDataFieldFinEuro.c_sLabel = __sOldLabel.Replace(a, 3, cDataFieldFinEuro.c_sDescription);
					if (cDataFieldFinEuro.c_sDescription == Ifs.Fnd.ApplicationForms.Const.strNULL) 
					{                        
                        Sal.SetWindowLabelText(this, __sOldLabel.Replace(a, 3, "[***]"));						
					}
					else
					{
						Sal.SetWindowLabelText(this, cDataFieldFinEuro.c_sLabel);
					}
					b = __sOldLabel.Scan("@RATE");
					if ((b != -1) && (cDataFieldFinEuro.c_sDescription != Ifs.Fnd.ApplicationForms.Const.strNULL)) 
					{
						cDataFieldFinEuro.c_sTemp = cDataFieldFinEuro.c_sCurrency + "/" + cDataFieldFinEuro.c_sDescription;
						cDataFieldFinEuro.c_sLabel = __sOldLabel.Replace(b, 5, cDataFieldFinEuro.c_sTemp);
						Sal.SetWindowLabelText(this, cDataFieldFinEuro.c_sLabel);
					}
					return true;
				}
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
		private void cDataFieldFinEuro_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Create:
					this.cDataFieldFinEuro_OnSAM_Create(sender, e);
					break;
				
				case Const.PAM_CallChanged:
					this.cDataFieldFinEuro_OnPAM_CallChanged(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_Create event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cDataFieldFinEuro_OnSAM_Create(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (!(Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam))) 
			{
				e.Return = false;
				return;
			}
			// CONVERSION: Static code snippet replaced original source.
			// CONVERSION: Handle latebound problem. Latebound call was there due to compilation problems in CTD
			if (cDataSource.FromHandle(this.i_hWndFrame).UserGlobalValueGet("COMPANY", ref cDataFieldFinEuro.c_sCompany)) 
			{
				Sal.GetWindowLabelText(this.i_hWndSelf, ref this.__sOldLabel, 99);
				this.cSetCurrencyWindowText();
			}
			e.Return = true;
			return;
			#endregion
		}
		
		/// <summary>
		/// PAM_CallChanged event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cDataFieldFinEuro_OnPAM_CallChanged(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			// CONVERSION: Static code snippet replaced original source.
			// CONVERSION: Handle latebound problem. Latebound call was there due to compilation problems in CTD
			if (cDataSource.FromHandle(this.i_hWndFrame).UserGlobalValueGet("COMPANY", ref cDataFieldFinEuro.c_sCompany)) 
			{
				this.cSetCurrencyWindowText();
			}
			e.Return = true;
			return;
			#endregion
		}
		#endregion
		
		#region Multiple Inheritance Operators
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cDataFieldFinEuro to type cEditControlsManager.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cEditControlsManager(cDataFieldFinEuro self)
		{
			return self._cEditControlsManager;
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cDataFieldFinEuro to type cSessionManager.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cSessionManager(cDataFieldFinEuro self)
		{
			return ((cSessionManager)self._cEditControlsManager);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cDataFieldFinEuro to type cResize.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cResize(cDataFieldFinEuro self)
		{
			return self._cResize;
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cEditControlsManager to type cDataFieldFinEuro.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cDataFieldFinEuro(cEditControlsManager super)
		{
			return ((cDataFieldFinEuro)super._derived);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cSessionManager to type cDataFieldFinEuro.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cDataFieldFinEuro(cSessionManager super)
		{
			return ((cDataFieldFinEuro)((cEditControlsManager)super._derived));
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cResize to type cDataFieldFinEuro.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cDataFieldFinEuro(cResize super)
		{
			return ((cDataFieldFinEuro)((cEditControlsManager)super._derived));
		}
		#endregion
		
		#region System Methods/Properties
		
		/// <summary>
		/// Returns the object instance associated with the window handle.
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public new static cDataFieldFinEuro FromHandle(SalWindowHandle handle)
		{
			return ((cDataFieldFinEuro)SalWindow.FromHandle(handle, typeof(cDataFieldFinEuro)));
		}
		#endregion
	}
}
