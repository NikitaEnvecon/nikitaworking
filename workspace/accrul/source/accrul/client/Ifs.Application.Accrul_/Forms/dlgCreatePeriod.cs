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
	/// <param name="nYearIn"></param>
	/// <param name="nPeriodIn"></param>
	/// <param name="sPeriodStatusIn"></param>
	/// <param name="sCompany"></param>
	public partial class dlgCreatePeriod : cDialogBoxFin
	{
		#region Window Parameters
		public SalArray<SalNumber> nYearIn;
		public SalArray<SalNumber> nPeriodIn;
		public SalArray<SalString> sPeriodStatusIn;
		public SalString sCompany;
		#endregion
		
		#region Window Variables
		public SalNumber nYear = 0;
		public SalNumber nPeriod = 0;
		public SalString sPeriodStatus = "";
		public SalNumber nReturn = 0;
		public SalArray<SalString> sParam = new SalArray<SalString>();
		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		protected dlgCreatePeriod()
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
		public static SalNumber ModalDialog(Control owner, SalArray<SalNumber> nYearIn, SalArray<SalNumber> nPeriodIn, SalArray<SalString> sPeriodStatusIn, SalString sCompany)
		{
			dlgCreatePeriod dlg = DialogFactory.CreateInstance<dlgCreatePeriod>();
			dlg.nYearIn = nYearIn;
			dlg.nPeriodIn = nPeriodIn;
			dlg.sPeriodStatusIn = sPeriodStatusIn;
			dlg.sCompany = sCompany;
			SalNumber ret = dlg.ShowDialog(owner);
			return ret;
		}
		
		/// <summary>
		/// Returns the object instance associated with the window handle.
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public new static dlgCreatePeriod FromHandle(SalWindowHandle handle)
		{
			return ((dlgCreatePeriod)SalWindow.FromHandle(handle, typeof(dlgCreatePeriod)));
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
				dfCompany.Text = i_sCompany;
				DbListPopulate(cmbUserGroup, cSessionManager.c_hSql, "Select user_group from " + cSessionManager.c_sDbPrefix + "USER_GROUP_FINANCE where company=:i_hWndFrame.dlgCreatePeriod.i_sCompany");
				return true;
			}
			#endregion
		}
		
		/// <summary>
		/// Stub for all user methods.
		/// Should be overridden with own method for all container classes.
		/// (other classen can override PM_UserMethod instead)
		/// </summary>
		/// <param name="nWhat"></param>
		/// <param name="sMethod"></param>
		/// <returns></returns>
		public new SalNumber UserMethod(SalNumber nWhat, SalString sMethod)
		{
			#region Local Variables
			SalString sName = "";
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				if (sMethod == "OK") 
				{
					return Save(nWhat, sMethod);
				}
				if (sMethod == "Cancel") 
				{
					switch (nWhat)
					{
						case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
							DataSourceClearIt(0);
							return Sal.EndDialog(i_hWndSelf, Sys.IDCANCEL);
						
						case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
							return 1;
						
						case Ifs.Fnd.ApplicationForms.Const.METHOD_GetType:
							return Ifs.Fnd.ApplicationForms.Const.CHILDTYPE_AnyMethod;
					}
				}
				Sal.GetItemName(Sys.hWndItem, ref sName);
				Ifs.Fnd.ApplicationForms.Int.ErrorBox("DESIGN TIME ERROR for item " + sName + "\r\n" +
					"Function UserMethod handling method \"" + sMethod + "\" not written!");
				switch (nWhat)
				{
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
						return 0;
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
						return 0;
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_GetType:
						return Ifs.Fnd.ApplicationForms.Const.CHILDTYPE_AnyMethod;
				}
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// Stub for all user methods.
		/// Should be overridden with own method for all container classes.
		/// (other classen can override PM_UserMethod instead)
		/// </summary>
		/// <param name="nWhat"></param>
		/// <param name="sMethod"></param>
		/// <returns></returns>
		public virtual SalNumber Save(SalNumber nWhat, SalString sMethod)
		{
			#region Local Variables
			SalNumber nIndex = 0;
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				switch (nWhat)
				{
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
						if (DbTransactionBegin(ref cSessionManager.c_hSql)) 
						{
							Sal.WaitCursor(true);
							nIndex = 0;
							while (nPeriodIn[nIndex] != -1) 
							{
								nYear = nYearIn[nIndex];
								nPeriod = nPeriodIn[nIndex];
								sPeriodStatus = sPeriodStatusIn[nIndex];
								using(SignatureHints hints = SignatureHints.NewContext())
								{
									hints.Add("User_Group_Period_API.Insert_User_Group", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
									if (!(DbPLSQLBlock(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "User_Group_Period_API.Insert_User_Group(\r\n" +
										"   :i_hWndFrame.dlgCreatePeriod.i_sCompany,\r\n" +
										"   :i_hWndFrame.dlgCreatePeriod.cmbUserGroup,\r\n" +
										"   :i_hWndFrame.dlgCreatePeriod.nYear,\r\n" +
										"   :i_hWndFrame.dlgCreatePeriod.nPeriod,\r\n" +
										"   :i_hWndFrame.dlgCreatePeriod.sPeriodStatus)"))) 
									{
										DbTransactionClear(cSessionManager.c_hSql);
										Sal.WaitCursor(false);
										return 0;
									}
								}
								nIndex = nIndex + 1;
							}
							DbTransactionEnd(cSessionManager.c_hSql);
							Sal.WaitCursor(false);
							return Sal.EndDialog(i_hWndSelf, Sys.IDOK);
						}
						goto case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire;
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
						if (Sal.ListQuerySelection(cmbUserGroup) == Sys.LB_Err) 
						{
							return 0;
						}
						return 1;
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_GetType:
						return Ifs.Fnd.ApplicationForms.Const.CHILDTYPE_AnyMethod;
				}
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber GetUserDescription()
		{
			#region Actions
			using (new SalContext(this))
			{
				if (DbPrepareAndExecute(cSessionManager.c_hSql, "Select  " + cSessionManager.c_sDbPrefix + " USER_GROUP_FINANCE_API.Get_User_Group_Description(\r\n" +
					":i_hWndFrame.dlgCreatePeriod.i_sCompany,:i_hWndFrame.dlgCreatePeriod.cmbUserGroup) into :i_hWndFrame.dlgCreatePeriod.dfsDescription from DUAL")) 
				{
					DbFetchNext(cSessionManager.c_hSql, ref nReturn);
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
		private void dlgCreatePeriod_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Create:
					this.dlgCreatePeriod_OnSAM_Create(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_Create event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dlgCreatePeriod_OnSAM_Create(object sender, WindowActionsEventArgs e)
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
		private void cmbUserGroup_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Click:
					this.cmbUserGroup_OnSAM_Click(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_Click event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cmbUserGroup_OnSAM_Click(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.GetUserDescription();
			Sal.EnableWindow(this.pbOk);
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
