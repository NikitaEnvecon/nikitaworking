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
	public class cColumnFinEuro : cColumnFin
	{
		#region Fields
		[ThreadStatic]
		public static SalString c_sCompany;
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
		public cColumnFinEuro()
		{
			InitThreadStaticFields();
		
			// This call is required by the Windows Form Designer.
			InitializeComponent();
		}
		
		/// <summary>
		/// Multiple Inheritance: Constructor.
		/// </summary>
		/// <param name="derived"></param>
		public cColumnFinEuro(ISalWindow derived)
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
			// cColumnFinEuro
			// 
			this.Name = "cColumnFinEuro";
			this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cColumnFinEuro_WindowActions);
		}
		#endregion
		
		#region Methods
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean cSetCurrencyWindowText()
		{
			#region Actions
			using (new SalContext(this))
			{
				if (string.IsNullOrEmpty(cColumnFinEuro.c_sCompany))
				{
					Ifs.Fnd.ApplicationForms.Var.Console.Add("No Company, Exit method");
					return false;
				}

				if (!Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Company_Finance_API.Get_Parallel_Acc_Currency"))
					return false;

				SalNumber a = __sOldLabel.Scan("@");
				if (a == -1)
						return false;

                            cColumnFinEuro.c_sDescription = Var.FinlibServices.GetParallelCurrency(cColumnFinEuro.c_sCompany);
                            cColumnFinEuro.c_sCurrency = Var.FinlibServices.GetAccountingCurrency(cColumnFinEuro.c_sCompany);

					cColumnFinEuro.c_sLabel = __sOldLabel.Replace(a, 3, cColumnFinEuro.c_sDescription);

				if (string.IsNullOrEmpty(cColumnFinEuro.c_sDescription))
					{
                        Sal.TblSetColumnTitle(this, __sOldLabel.Replace(a, 3, Properties.Resources.TEXT_ParallelCurrency));
					}
					else
					{
						Sal.TblSetColumnTitle(this, cColumnFinEuro.c_sLabel);
					}
                    
				SalNumber b = __sOldLabel.Scan("@RATE");
					if (b != -1)  
					{
                        cColumnFinEuro.c_sLabel = __sOldLabel.Replace(b, 5, Properties.Resources.TEXT_ParallelCurrency);
						Sal.TblSetColumnTitle(this, cColumnFinEuro.c_sLabel);
					}
					return true;
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
		private void cColumnFinEuro_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Create:
					this.cColumnFinEuro_OnSAM_Create(sender, e);
					break;
				
				case Const.PAM_CallChanged:
					this.cColumnFinEuro_OnPAM_CallChanged(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_Create event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cColumnFinEuro_OnSAM_Create(object sender, WindowActionsEventArgs e)
		{
			e.Handled = true;
			Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam);

			if (cDataSource.FromHandle(this.i_hWndFrame).UserGlobalValueGet("COMPANY", ref cColumnFinEuro.c_sCompany)) 
			{
				Sal.TblGetColumnTitle(this.i_hWndSelf, ref this.__sOldLabel, 99);
				this.cSetCurrencyWindowText();
			}
			e.Return = true;
		}
		
		/// <summary>
		/// PAM_CallChanged event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cColumnFinEuro_OnPAM_CallChanged(object sender, WindowActionsEventArgs e)
		{
			e.Handled = true;
			if (cDataSource.FromHandle(this.i_hWndFrame).UserGlobalValueGet("COMPANY", ref cColumnFinEuro.c_sCompany)) 
			{
				this.cSetCurrencyWindowText();
			}
			e.Return = true;
		}
		#endregion
		
		#region Multiple Inheritance Operators
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cColumnFinEuro to type cEditControlsManager.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cEditControlsManager(cColumnFinEuro self)
		{
			return self._cEditControlsManager;
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cColumnFinEuro to type cSessionManager.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cSessionManager(cColumnFinEuro self)
		{
			return ((cSessionManager)self._cEditControlsManager);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cEditControlsManager to type cColumnFinEuro.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cColumnFinEuro(cEditControlsManager super)
		{
			return ((cColumnFinEuro)super._derived);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cSessionManager to type cColumnFinEuro.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cColumnFinEuro(cSessionManager super)
		{
			return ((cColumnFinEuro)((cEditControlsManager)super._derived));
		}
		#endregion
		
		#region System Methods/Properties
		
		/// <summary>
		/// Returns the object instance associated with the window handle.
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public new static cColumnFinEuro FromHandle(SalWindowHandle handle)
		{
			return ((cColumnFinEuro)SalWindow.FromHandle(handle, typeof(cColumnFinEuro)));
		}
		#endregion
	}
}
