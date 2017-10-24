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
	/// <param name="dVouDate"></param>
	/// <param name="sCompany"></param>
	/// <param name="sMasterUseTemplate">
	/// Receive String: sMasterUseTemplate
	/// Receive Long String: sMasterUseTemplate[ ]
	/// </param>
	public partial class dlgUseVouTemplate : cDialogBoxFin
	{
		#region Window Parameters
		public SalDateTime dVouDate;
		public SalString sCompany;
		public SalArray<SalString> sMasterUseTemplate;
		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		protected dlgUseVouTemplate()
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
		public static SalNumber ModalDialog(Control owner, SalDateTime dVouDate, SalString sCompany, ref SalArray<SalString> sMasterUseTemplate)
		{
			dlgUseVouTemplate dlg = DialogFactory.CreateInstance<dlgUseVouTemplate>();
			dlg.dVouDate = dVouDate;
			dlg.sCompany = sCompany;
			dlg.sMasterUseTemplate = sMasterUseTemplate;
			SalNumber ret = dlg.ShowDialog(owner);
			sMasterUseTemplate = dlg.sMasterUseTemplate;
			return ret;
		}
		
		/// <summary>
		/// Returns the object instance associated with the window handle.
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public new static dlgUseVouTemplate FromHandle(SalWindowHandle handle)
		{
			return ((dlgUseVouTemplate)SalWindow.FromHandle(handle, typeof(dlgUseVouTemplate)));
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
				Sal.SendMsg(tblUseVoucher, Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Sys.lParam);
				pbOK.MethodInvestigateState();
				return false;
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
				if (sMethod == "OK") 
				{
					return MyOK(nWhat);
				}
				if (sMethod == "Cancel") 
				{
					return MyCancel(nWhat);
				}
				else if (sMethod == "Query") 
				{
					return MyQuery(nWhat);
				}
				return 0;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nWhat"></param>
		/// <returns></returns>
		public virtual SalBoolean MyOK(SalNumber nWhat)
		{
			#region Local Variables
			SalNumber nRow = 0;
			SalNumber nItem = 0;
			SalArray<SalString> sParam = new SalArray<SalString>();
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				switch (nWhat)
				{
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
						nRow = Sys.TBL_MinRow;
						if (Sal.TblFindNextRow(tblUseVoucher, ref nRow, Sys.ROW_Selected, 0)) 
						{
							return true;
						}
						return false;
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
						nRow = Sys.TBL_MinRow;
						nItem = 0;
						while (Sal.TblFindNextRow(tblUseVoucher, ref nRow, Sys.ROW_Selected, 0)) 
						{
							Sal.TblSetFocusRow(tblUseVoucher, nRow);
							sParam[0] = tblUseVoucher_colsTemplate.Text;
							if ((tblUseVoucher_coldValidFrom.DateTime > dVouDate) || (tblUseVoucher_coldValidUntil.DateTime < dVouDate)) 
							{
								Ifs.Fnd.ApplicationForms.Int.AlertBoxWithParams(Properties.Resources.TEXT_ExpiredDate, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok, sParam);
								return false;
							}
							sMasterUseTemplate[nItem] = tblUseVoucher_colsTemplate.Text;
							nItem = nItem + 1;
						}
						Sal.EndDialog(i_hWndSelf, Sys.IDOK);
						return true;
						break;
					
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
				if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire) 
				{
					return true;
				}
				else if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
				{
					Sal.SendMsg(tblUseVoucher, Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Ifs.Fnd.ApplicationForms.Const.POPULATE_UseQueryDialog);
					return Sal.BringWindowToTop(i_hWndSelf);
				}
				else
				{
					return Ifs.Fnd.ApplicationForms.Const.CHILDTYPE_SourceMethod;
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
		private void dlgUseVouTemplate_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Create:
					this.dlgUseVouTemplate_OnSAM_Create(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_Create event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dlgUseVouTemplate_OnSAM_Create(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.i_sCompany = this.sCompany;
			Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam);
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void tblUseVoucher_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.WM_LBUTTONUP:
					e.Handled = true;
					this.pbOK.MethodInvestigateState();
					break;
                case Sys.SAM_Click:
                    e.Handled = true;
                    this.pbOK.MethodInvestigateState();
                    break;
				case Ifs.Fnd.ApplicationForms.Const.WM_LBUTTONDBLCLK:
					e.Handled = true;
					e.Return = Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, ((SalString)"OK").ToHandle());
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
