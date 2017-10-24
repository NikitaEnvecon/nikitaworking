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
	/// <param name="sCompany"></param>
	/// <param name="nCopyYear"></param>
	/// <param name="nCopyPeriod"></param>
	/// <param name="nCopyVoucher"></param>
	/// <param name="nCopyVoucherType"></param>
	/// <param name="bCorrection"></param>
	/// <param name="bReverse"></param>
	public partial class dlgGLVoucher : cDialogBoxFin
	{
		#region Window Parameters
		public SalString sCompany;
		public SalNumber nCopyYear;
		public SalNumber nCopyPeriod;
		public SalNumber nCopyVoucher;
		public SalString nCopyVoucherType;
		public SalBoolean bCorrection;
		public SalBoolean bReverse;
		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		protected dlgGLVoucher()
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
		public static SalNumber ModalDialog(Control owner, SalString sCompany, ref SalNumber nCopyYear, ref SalNumber nCopyPeriod, ref SalNumber nCopyVoucher, ref SalString nCopyVoucherType, ref SalBoolean bCorrection, ref SalBoolean bReverse)
		{
			dlgGLVoucher dlg = DialogFactory.CreateInstance<dlgGLVoucher>();
			dlg.sCompany = sCompany;
			dlg.nCopyYear = nCopyYear;
			dlg.nCopyPeriod = nCopyPeriod;
			dlg.nCopyVoucher = nCopyVoucher;
			dlg.nCopyVoucherType = nCopyVoucherType;
			dlg.bCorrection = bCorrection;
			dlg.bReverse = bReverse;
			SalNumber ret = dlg.ShowDialog(owner);
			nCopyYear = dlg.nCopyYear;
			nCopyPeriod = dlg.nCopyPeriod;
			nCopyVoucher = dlg.nCopyVoucher;
			nCopyVoucherType = dlg.nCopyVoucherType;
			bCorrection = dlg.bCorrection;
			bReverse = dlg.bReverse;
			return ret;
		}
		
		/// <summary>
		/// Returns the object instance associated with the window handle.
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public new static dlgGLVoucher FromHandle(SalWindowHandle handle)
		{
			return ((dlgGLVoucher)SalWindow.FromHandle(handle, typeof(dlgGLVoucher)));
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
				MyQuery(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
				pbCopy.MethodInvestigateState();
				pbVourow.MethodInvestigateState();
				if (bCorrection) 
				{
					Sal.DisableWindowAndLabel(cbCorrection);
					Sal.DisableWindowAndLabel(cbReverse);
				}
				else
				{
					Sal.EnableWindowAndLabel(cbCorrection);
					Sal.EnableWindowAndLabel(cbReverse);
				}
				return true;
			}
			#endregion
		}
		
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
				if (sMethod == "Copy") 
				{
					return MyCopy(nWhat);
				}
				else if (sMethod == "Cancel") 
				{
					return MyCancel(nWhat);
				}
				else if (sMethod == "Query") 
				{
					return MyQuery(nWhat);
				}
				else if (sMethod == "Vourow") 
				{
					return MyVourow(nWhat);
				}
				return 0;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nWhat"></param>
		/// <returns></returns>
		public virtual SalBoolean MyCopy(SalNumber nWhat)
		{
			#region Local Variables
			SalNumber nRow = 0;
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				switch (nWhat)
				{
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
						nRow = Sys.TBL_MinRow;
						if (Sal.TblFindNextRow(tblGLVoucher, ref nRow, Sys.ROW_Selected, 0)) 
						{
							if (Sal.TblFindNextRow(tblGLVoucher, ref nRow, Sys.ROW_Selected, 0)) 
							{
								return false;
							}
							return true;
						}
						return false;
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
						nCopyYear = tblGLVoucher_colnAccountingYear.Number;
						nCopyPeriod = tblGLVoucher_colnAccountingPeriod.Number;
						nCopyVoucher = tblGLVoucher_colVoucherNo.Number;
						nCopyVoucherType = tblGLVoucher_colVoucherType.Text;
						if (cbCorrection.Checked == true) 
						{
							bCorrection = true;
						}
						else
						{
							bCorrection = false;
						}
						if (cbReverse.Checked == true) 
						{
							bReverse = true;
						}
						else
						{
							bReverse = false;
						}
						Sal.EndDialog(i_hWndSelf, 1);
						// PRECONVERSION: C# case statement do not support fallthrough. Return or Break required. Can be done in Sparx project.
						return true;
						break;
					
					default:
						return false;
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
						return Sal.EndDialog(i_hWndSelf, 0);
					
					default:
						return false;
				}
			}

			return false;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nWhat"></param>
		/// <returns></returns>
		public virtual SalNumber MyQuery(SalNumber nWhat)
		{
			#region Actions
			using (new SalContext(this))
			{
				switch (nWhat)
				{
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
						return true;
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
						Sal.SendMsg(tblGLVoucher, Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Ifs.Fnd.ApplicationForms.Const.POPULATE_UseQueryDialog);
						return Sal.BringWindowToTop(i_hWndSelf);
					
					default:
						return false;
				}
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nWhat"></param>
		/// <returns></returns>
		public virtual SalBoolean MyVourow(SalNumber nWhat)
		{
			#region Local Variables
			SalNumber nRow = 0;
			SalArray<SalString> sItemNames = new SalArray<SalString>();
			SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				switch (nWhat)
				{
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
						nRow = Sys.TBL_MinRow;
						if (Sal.TblFindNextRow(tblGLVoucher, ref nRow, Sys.ROW_Selected, 0)) 
						{
							if (Sal.TblFindNextRow(tblGLVoucher, ref nRow, Sys.ROW_Selected, 0)) 
							{
								return false;
							}
							return true;
						}
						return false;
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
						Sal.WaitCursor(true);
						sItemNames[0] = "VOUCHER_TYPE";
						hWndItems[0] = tblGLVoucher_colVoucherType;
						sItemNames[1] = "VOUCHER_NO";
						hWndItems[1] = tblGLVoucher_colVoucherNo;
						sItemNames[2] = "ACCOUNTING_YEAR";
						hWndItems[2] = tblGLVoucher_colnAccountingYear;
						sItemNames[3] = "COMPANY";
						hWndItems[3] = tblGLVoucher_colCompany;
						SetCompany(i_sCompany);
						Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("VOUCHER_TYPE", tblGLVoucher, sItemNames, hWndItems);
                        cSessionManager.FromHandle(this.i_hWndSelf).SessionNavigateWithParams(Pal.GetActiveInstanceName("tbwVoucherRow"), new cMessage(), true);
						// PRECONVERSION: C# case statement do not support fallthrough. Return or Break required. Can be done in Sparx project.
						return true;
						break;
					
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
		private void dlgGLVoucher_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Create:
					this.dlgGLVoucher_OnSAM_Create(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_Create event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dlgGLVoucher_OnSAM_Create(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			Sal.CenterWindow(this);
			this.i_sCompany = this.sCompany;
			Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam);
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void tblGLVoucher_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.WM_LBUTTONUP:
					this.tblGLVoucher_OnWM_LBUTTONUP(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.WM_LBUTTONDBLCLK:
					e.Handled = true;
					this.MyCopy(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// WM_LBUTTONUP event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblGLVoucher_OnWM_LBUTTONUP(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.pbCopy.MethodInvestigateState();
			this.pbVourow.MethodInvestigateState();
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
