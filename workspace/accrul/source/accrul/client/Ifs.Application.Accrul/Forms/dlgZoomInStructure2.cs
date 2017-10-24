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
	/// Add a new check box in to dlgZoomln to control Level/Node in structures
	/// </summary>
	/// <param name="p_sCompany"></param>
	/// <param name="p_hWndInvoker"></param>
	/// <param name="p_bVisible"></param>
	/// <param name="p_bCode">Change by pk</param>
	/// <param name="p_sAccYear"></param>
	/// <param name="p_sStructColumnName"></param>
	public partial class dlgZoomInStructure2 : cDialogBoxFin
	{
		#region Window Parameters
		public SalString p_sCompany;
		public SalWindowHandle p_hWndInvoker;
		public SalArray<SalBoolean> p_bVisible;
		public SalArray<SalBoolean> p_bCode;
		public SalString p_sAccYear;
		public SalString p_sStructColumnName;
		#endregion
		
		#region Window Variables
		public SalNumber nTemp = 0;
		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		protected dlgZoomInStructure2()
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
		public static SalNumber ModalDialog(Control owner, SalString p_sCompany, SalWindowHandle p_hWndInvoker, SalArray<SalBoolean> p_bVisible, ref SalArray<SalBoolean> p_bCode, ref SalString p_sAccYear, SalString p_sStructColumnName)
		{
			dlgZoomInStructure2 dlg = DialogFactory.CreateInstance<dlgZoomInStructure2>();
			dlg.p_sCompany = p_sCompany;
			dlg.p_hWndInvoker = p_hWndInvoker;
			dlg.p_bVisible = p_bVisible;
			dlg.p_bCode = p_bCode;
			dlg.p_sAccYear = p_sAccYear;
			dlg.p_sStructColumnName = p_sStructColumnName;
			SalNumber ret = dlg.ShowDialog(owner);
			p_bCode = dlg.p_bCode;
			p_sAccYear = dlg.p_sAccYear;
			return ret;
		}
		
		/// <summary>
		/// Returns the object instance associated with the window handle.
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public new static dlgZoomInStructure2 FromHandle(SalWindowHandle handle)
		{
			return ((dlgZoomInStructure2)SalWindow.FromHandle(handle, typeof(dlgZoomInStructure2)));
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
				if (sMethod == "OK") 
				{
					return OkX(nWhat);
				}
				else if (sMethod == "CANCEL") 
				{
					return CancelX(nWhat);
				}
				// Bug 85079, Removed the condition check for QUERY
				return 0;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public new SalBoolean FrameStartupUser()
		{
			#region Actions
			using (new SalContext(this))
			{
				// disable check according bVisible ( code is used ) from tbwStructBalInfo
				// if ( code is used ) set it according previous code being chosen
				cbPeriod.Checked = p_bCode[1];
				cbAccount.Checked = p_bCode[2];
				if (!(p_bVisible[1])) 
				{
					Sal.DisableWindow(cbCode_B);
				}
				else
				{
					cbCode_B.Checked = p_bCode[3];
				}
				if (!(p_bVisible[2])) 
				{
					Sal.DisableWindow(cbCode_C);
				}
				else
				{
					cbCode_C.Checked = p_bCode[4];
				}
				if (!(p_bVisible[3])) 
				{
					Sal.DisableWindow(cbCode_D);
				}
				else
				{
					cbCode_D.Checked = p_bCode[5];
				}
				if (!(p_bVisible[4])) 
				{
					Sal.DisableWindow(cbCode_E);
				}
				else
				{
					cbCode_E.Checked = p_bCode[6];
				}
				if (!(p_bVisible[5])) 
				{
					Sal.DisableWindow(cbCode_F);
				}
				else
				{
					cbCode_F.Checked = p_bCode[7];
				}
				if (!(p_bVisible[6])) 
				{
					Sal.DisableWindow(cbCode_G);
				}
				else
				{
					cbCode_G.Checked = p_bCode[8];
				}
				if (!(p_bVisible[7])) 
				{
					Sal.DisableWindow(cbCode_H);
				}
				else
				{
					cbCode_H.Checked = p_bCode[9];
				}
				if (!(p_bVisible[8])) 
				{
					Sal.DisableWindow(cbCode_I);
				}
				else
				{
					cbCode_I.Checked = p_bCode[10];
				}
				if (!(p_bVisible[9])) 
				{
					Sal.DisableWindow(cbCode_J);
				}
				else
				{
					cbCode_J.Checked = p_bCode[11];
				}
				// To view or hide structure Level/Node
				cbStrucColomn.Checked = p_bCode[12];
				// Simulation Voucher
				cbSimulation.Checked = p_bCode[13];
				cbNormal.Checked = p_bCode[14];
				if (!(p_bCode[13]) && !(p_bCode[14])) 
				{
					cbNormal.Checked = true;
				}
				cbIncludeHold.Checked = p_bCode[15];
				dfAccYear.Text = p_sAccYear;
				Sal.SetFocus(dfAccYear);
				return true;
			}
			#endregion
		}
		// you query when ever you want
		// and allways set it back to directly by Foundation to UserWhere and UserOrderBy
		// Bug 85079, Removed function QueryX
		// code being chosen according check box
		// and send it to tbwStructBalInfo Invoker to create another tbwStructBalInfo with Code choosen string format
		// and only set it directly to parameter p_bCode if it call by pbQuery of MDI and return it to tbwBalInvoker
		/// <summary>
		/// </summary>
		/// <param name="nWhat"></param>
		/// <returns></returns>
		public virtual SalNumber OkX(SalNumber nWhat)
		{
			#region Local Variables
			SalString sCode = "";
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire) 
				{
					return true;
				}
				else if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
				{
					p_sAccYear = dfAccYear.Text;
					// Simulation Voucher
					if (!(cbNormal.Checked) && !(cbSimulation.Checked)) 
					{
                        return Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_BalTypeUnchecked, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
					}
					// from pbZoomIn
					if (p_bCode[0] == true) 
					{
						if (cbPeriod.Checked) 
						{
							sCode = "1";
						}
						else
						{
							sCode = "0";
						}
						if (cbAccount.Checked) 
						{
							sCode = sCode + "^" + "1";
						}
						else
						{
							sCode = sCode + "^" + "0";
						}
						if (cbCode_B.Checked) 
						{
							sCode = sCode + "^" + "1";
						}
						else
						{
							sCode = sCode + "^" + "0";
						}
						if (cbCode_C.Checked) 
						{
							sCode = sCode + "^" + "1";
						}
						else
						{
							sCode = sCode + "^" + "0";
						}
						if (cbCode_D.Checked) 
						{
							sCode = sCode + "^" + "1";
						}
						else
						{
							sCode = sCode + "^" + "0";
						}
						if (cbCode_E.Checked) 
						{
							sCode = sCode + "^" + "1";
						}
						else
						{
							sCode = sCode + "^" + "0";
						}
						if (cbCode_F.Checked) 
						{
							sCode = sCode + "^" + "1";
						}
						else
						{
							sCode = sCode + "^" + "0";
						}
						if (cbCode_G.Checked) 
						{
							sCode = sCode + "^" + "1";
						}
						else
						{
							sCode = sCode + "^" + "0";
						}
						if (cbCode_H.Checked) 
						{
							sCode = sCode + "^" + "1";
						}
						else
						{
							sCode = sCode + "^" + "0";
						}
						if (cbCode_I.Checked) 
						{
							sCode = sCode + "^" + "1";
						}
						else
						{
							sCode = sCode + "^" + "0";
						}
						if (cbCode_J.Checked) 
						{
							sCode = sCode + "^" + "1";
						}
						else
						{
							sCode = sCode + "^" + "0";
						}
						// To view or hide structure Level/Node
						if (cbStrucColomn.Checked) 
						{
							sCode = sCode + "^" + "1";
						}
						else
						{
							sCode = sCode + "^" + "0";
						}
						if (cbSimulation.Checked) 
						{
							sCode = sCode + "^" + "1";
						}
						else
						{
							sCode = sCode + "^" + "0";
						}
						if (cbNormal.Checked) 
						{
							sCode = sCode + "^" + "1";
						}
						else
						{
							sCode = sCode + "^" + "0";
						}
						if (cbIncludeHold.Checked) 
						{
							sCode = sCode + "^" + "1";
						}
						else
						{
							sCode = sCode + "^" + "0";
						}
						if (dfAccYear.Text != Ifs.Fnd.ApplicationForms.Const.strNULL) 
						{
							Sal.SendMsg(p_hWndInvoker, Const.PAM_SetAccYear, 0, ((SalString)dfAccYear.Text).ToHandle());
						}
						Sal.SendMsg(p_hWndInvoker, Const.PAM_ZoomIn, 0, sCode.ToHandle());
					}
					// from pbQuery
					else
					{
						if (cbPeriod.Checked) 
						{
							p_bCode[1] = true;
						}
						else
						{
							p_bCode[1] = false;
						}
						if (cbAccount.Checked) 
						{
							p_bCode[2] = true;
						}
						else
						{
							p_bCode[2] = false;
						}
						if (cbCode_B.Checked) 
						{
							p_bCode[3] = true;
						}
						else
						{
							p_bCode[3] = false;
						}
						if (cbCode_C.Checked) 
						{
							p_bCode[4] = true;
						}
						else
						{
							p_bCode[4] = false;
						}
						if (cbCode_D.Checked) 
						{
							p_bCode[5] = true;
						}
						else
						{
							p_bCode[5] = false;
						}
						if (cbCode_E.Checked) 
						{
							p_bCode[6] = true;
						}
						else
						{
							p_bCode[6] = false;
						}
						if (cbCode_F.Checked) 
						{
							p_bCode[7] = true;
						}
						else
						{
							p_bCode[7] = false;
						}
						if (cbCode_G.Checked) 
						{
							p_bCode[8] = true;
						}
						else
						{
							p_bCode[8] = false;
						}
						if (cbCode_H.Checked) 
						{
							p_bCode[9] = true;
						}
						else
						{
							p_bCode[9] = false;
						}
						if (cbCode_I.Checked) 
						{
							p_bCode[10] = true;
						}
						else
						{
							p_bCode[10] = false;
						}
						if (cbCode_J.Checked) 
						{
							p_bCode[11] = true;
						}
						else
						{
							p_bCode[11] = false;
						}
						// To view or hide structure Level/Node
						if (cbStrucColomn.Checked) 
						{
							p_bCode[12] = true;
						}
						else
						{
							p_bCode[12] = false;
						}
						if (cbSimulation.Checked) 
						{
							p_bCode[13] = true;
						}
						else
						{
							p_bCode[13] = false;
						}
						if (cbNormal.Checked) 
						{
							p_bCode[14] = true;
						}
						else
						{
							p_bCode[14] = false;
						}
						if (cbIncludeHold.Checked) 
						{
							p_bCode[15] = true;
						}
						else
						{
							p_bCode[15] = false;
						}
					}


					return Sal.EndDialog(this, 1);
				}
				else
				{
					return Ifs.Fnd.ApplicationForms.Const.CHILDTYPE_SourceMethod;
				}
			}
			#endregion
		}
		// normal operation
		/// <summary>
		/// </summary>
		/// <param name="nWhat"></param>
		/// <returns></returns>
		public virtual SalNumber CancelX(SalNumber nWhat)
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
					return Sal.EndDialog(this, 0);
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
		private void dlgZoomInStructure2_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Create:
					this.dlgZoomInStructure2_OnSAM_Create(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_Create event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dlgZoomInStructure2_OnSAM_Create(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.i_sCompany = this.p_sCompany;
			Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam);
			Sal.WaitCursor(false);
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void cbStrucColomn_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Create:
					e.Handled = true;
                    Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam);
					Sal.SetWindowText(this.cbStrucColomn, this.p_sStructColumnName);
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
