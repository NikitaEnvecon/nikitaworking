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
	/// <param name="sCurrencyCode"></param>
	/// <param name="dDate"></param>
	public partial class dlgInclude : cDialogBoxFin
	{
		#region Window Parameters
		public SalString sCurrencyCode;
		public SalDateTime dDate;
		#endregion
		
		#region Window Variables
		public SalString sBackgroundText = "";
		public SalString sNewBackgroundText = "";
		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		protected dlgInclude()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
		}
		#endregion
		
		#region System Methods/Properties
		
		/// <summary>
		/// Shows the modal dialog.
		/// </summary>
		/// <param name="owner"></param>
		/// <returns></returns>
		public static SalNumber ModalDialog(Control owner, SalString sCurrencyCode, ref SalDateTime dDate)
		{
			dlgInclude dlg = DialogFactory.CreateInstance<dlgInclude>();
			dlg.sCurrencyCode = sCurrencyCode;
			dlg.dDate = dDate;
			SalNumber ret = dlg.ShowDialog(owner);
			dDate = dlg.dDate;
			return ret;
		}
		
		/// <summary>
		/// Returns the object instance associated with the window handle.
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public new static dlgInclude FromHandle(SalWindowHandle handle)
		{
			return ((dlgInclude)SalWindow.FromHandle(handle, typeof(dlgInclude)));
		}
		#endregion
		
		#region Methods
		
		/// <summary>
		/// </summary>
		/// <param name="nWhat"></param>
		/// <param name="sMethod"></param>
		/// <returns></returns>
		public new SalNumber UserMethod(SalNumber nWhat, SalString sMethod)
		{
			#region Actions
			using (new SalContext(this))
			{
				if (sMethod == "Ok") 
				{
					return MyOk(nWhat);
				}
				else if (sMethod == "Cancel") 
				{
					return MyCancel(nWhat);
				}
				return false;
			}
			#endregion
		}
		
		/// <summary>
		/// Applications override the FrameStartupUser function to perform
		/// actions when a window has been started.
		/// </summary>
		/// <returns></returns>
		public new SalBoolean FrameStartupUser()
		{
			#region Local Variables
			SalNumber a = 0;
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				Sal.GetWindowLabelText(dfEMUValidDate, ref sBackgroundText, 99);
				a = sBackgroundText.Scan("@CUR");
				if (a != -1) 
				{
					sNewBackgroundText = sBackgroundText.Replace(a, 4, sCurrencyCode);
					Sal.SetWindowLabelText(dfEMUValidDate, sNewBackgroundText);
				}
				return true;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nWhat"></param>
		/// <returns></returns>
		public virtual SalBoolean MyOk(SalNumber nWhat)
		{
			#region Actions
			using (new SalContext(this))
			{
				switch (nWhat)
				{
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
						return true;
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
						dDate = dfEMUValidDate.DateTime;
						return Sal.EndDialog(i_hWndSelf, Sys.IDOK);
					
					default:
						return true;
				}
			}

			return false;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nWhat"></param>
		/// <returns></returns>
		public virtual SalBoolean MyCancel(SalNumber nWhat)
		{
			#region Actions
			using (new SalContext(this))
			{
				switch (nWhat)
				{
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
						return true;
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
						return Sal.EndDialog(i_hWndSelf, Sys.IDCANCEL);
					
					default:
						return false;
				}
			}

			return false;
			#endregion
		}
		#endregion
		
		#region Window Actions
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void dlgInclude_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate:
					e.Handled = true;
					e.Return = false;
					return;
			}
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void dfEMUValidDate_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_AnyEdit:
					e.Handled = true;
					e.Return = true;
					return;
				
				case Ifs.Application.Accrul.Const.PAM_CallChanged:
					e.Handled = true;
					e.Return = true;
					return;
			}
			#endregion
		}
		#endregion
		
		#region Late Bind Methods
		
		/// <summary>
		/// Virtual wrapper replacement for late-bound (..) calls.
		/// </summary>
		public override SalBoolean vrtFrameStartupUser()
		{
			return this.FrameStartupUser();
		}
		
		/// <summary>
		/// Virtual wrapper replacement for late-bound (..) calls.
		/// </summary>
		public override SalNumber vrtUserMethod(SalNumber nWhat, SalString sMethod)
		{
			return this.UserMethod(nWhat, sMethod);
		}
		#endregion
	}
}
