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
	public partial class tbwVoucherRow : cTableWindowFin
	{
		#region Window Variables
		public SalNumber nCredit = 0;
		public SalNumber nDebet = 0;
		public SalNumber nBalance = 0;
		public SalNumber nPosDebetAmount = 0;
		public SalNumber nPosCreditAmount = 0;
		public SalNumber nReturn = 0;
		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		public tbwVoucherRow()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
		}
		#endregion
		
		#region System Methods/Properties
		
		
		/// <summary>
		/// Returns the object instance associated with the window handle.
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public new static tbwVoucherRow FromHandle(SalWindowHandle handle)
		{
			return ((tbwVoucherRow)SalWindow.FromHandle(handle, typeof(tbwVoucherRow)));
		}
		#endregion
		
		#region Methods
        // Insert new code here...
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean VoucherRowPopult()
		{
			#region Actions
			using (new SalContext(this))
			{
				if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.RecCountGet() > 0) 
				{
					Sal.WaitCursor(true);
                    InitFromTransferredData();
					Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();
					Sal.WaitCursor(false);
					return true;
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
		private void tbwVoucherRow_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate:
					this.tbwVoucherRow_OnPM_DataSourcePopulate(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// PM_DataSourcePopulate event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tbwVoucherRow_OnPM_DataSourcePopulate(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			switch (Sys.wParam)
			{
				case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
					e.Return = false;
					return;
				
				case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
					this.nReturn = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Sys.wParam, Sys.lParam);
					this.dfVoucherNumber.Number = this.colVoucherNo.Number;
					this.dfVoucherYear.Number = this.colnAccountingYear.Number;
					this.dfVoucherType.Text = this.colVoucherType.Text;
					this.nPosDebetAmount = Sal.TblQueryColumnID(this.colDebetAmount);
					this.nPosCreditAmount = Sal.TblQueryColumnID(this.colCreditAmount);
					// Bug 71277, Begin. Passed i_hWndFrame instead of window name to SalTblColumnSum.
					this.dfDebet.Number = Sal.TblColumnSum(this.i_hWndFrame, this.nPosDebetAmount, 0, 0);
					this.dfCredit.Number = Sal.TblColumnSum(this.i_hWndFrame, this.nPosCreditAmount, 0, 0);
					// Bug 71277, End.
					this.dfBalance.Number = this.dfDebet.Number - this.dfCredit.Number;
					e.Return = this.nReturn;
					return;
			}
			#endregion
		}
		#endregion
		
		#region Late Bind Methods
        // Insert new code here...
		#endregion
	}
}
