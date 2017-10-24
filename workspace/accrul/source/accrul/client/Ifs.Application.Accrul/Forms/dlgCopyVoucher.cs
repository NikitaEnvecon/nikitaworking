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
	/// <param name="sPCompany"></param>
	/// <param name="sPVoucherType"></param>
	/// <param name="nPVoucherNo"></param>
	/// <param name="nPAccYearPeriod"></param>
	/// <param name="bPReverse"></param>
	/// <param name="bPCorrection"></param>
	public partial class dlgCopyVoucher : cDialogBoxFin
	{
		#region Window Parameters
		public SalString sPCompany;
		public SalString sPVoucherType;
		public SalNumber nPVoucherNo;
		public SalNumber nPAccYearPeriod;
		public SalBoolean bPReverse;
		public SalBoolean bPCorrection;
		#endregion
		
		#region Window Variables
		public SalString sYearPeriod = "";
		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		protected dlgCopyVoucher()
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
		public static SalNumber ModalDialog(Control owner, SalString sPCompany, SalString sPVoucherType, SalNumber nPVoucherNo, SalNumber nPAccYearPeriod, ref SalBoolean bPReverse, ref SalBoolean bPCorrection)
		{
			dlgCopyVoucher dlg = DialogFactory.CreateInstance<dlgCopyVoucher>();
			dlg.sPCompany = sPCompany;
			dlg.sPVoucherType = sPVoucherType;
			dlg.nPVoucherNo = nPVoucherNo;
			dlg.nPAccYearPeriod = nPAccYearPeriod;
			dlg.bPReverse = bPReverse;
			dlg.bPCorrection = bPCorrection;
			SalNumber ret = dlg.ShowDialog(owner);
			bPReverse = dlg.bPReverse;
			bPCorrection = dlg.bPCorrection;
			return ret;
		}
		
		/// <summary>
		/// Returns the object instance associated with the window handle.
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public new static dlgCopyVoucher FromHandle(SalWindowHandle handle)
		{
			return ((dlgCopyVoucher)SalWindow.FromHandle(handle, typeof(dlgCopyVoucher)));
		}
		#endregion
		
		#region Methods
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public new SalBoolean FrameStartupUser()
		{
			#region Actions
			using (new SalContext(this))
			{
				i_sCompany = sPCompany;
				dfAccountingYearPeriod.Number = nPAccYearPeriod;
				dfVoucherType.Text = sPVoucherType;
				dfVoucherNo.Number = nPVoucherNo;
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
		private void dlgCopyVoucher_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Create:
					this.dlgCopyVoucher_OnSAM_Create(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_Create event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dlgCopyVoucher_OnSAM_Create(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.i_sCompany = this.sPCompany;
			Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam);
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void cbCorrection_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Click:
					this.cbCorrection_OnSAM_Click(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_Click event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cbCorrection_OnSAM_Click(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.IsButtonChecked(this.cbCorrection)) 
			{
				this.cbReverse.Checked = false;
			}
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void cbReverse_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Click:
					this.cbReverse_OnSAM_Click(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_Click event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cbReverse_OnSAM_Click(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.IsButtonChecked(this.cbReverse)) 
			{
				this.cbCorrection.Checked = false;
			}
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void pbOk_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Click:
					this.pbOk_OnSAM_Click(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_Click event handler.
		/// </summary>
		/// <param name="message"></param>
		private void pbOk_OnSAM_Click(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.bPReverse = this.cbReverse.Checked;
			this.bPCorrection = this.cbCorrection.Checked;
			Sal.EndDialog(this, 1);
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void pbCancel_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Click:
					e.Handled = true;
					Sal.EndDialog(this, 0);
					break;
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
		#endregion
	}
}
