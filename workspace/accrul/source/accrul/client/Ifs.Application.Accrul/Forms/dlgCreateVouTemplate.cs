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
	/// <param name="sMasterTemplate"></param>
	/// <param name="sMasterDesc"></param>
	/// <param name="dMasterValidFrom"></param>
	/// <param name="dMasterValidUntil"></param>
	/// <param name="sIncludeAmount"></param>
	/// <param name="sCompany"></param>
	public partial class dlgCreateVouTemplate : cDialogBoxFin
	{
		#region Window Parameters
		public SalString sMasterTemplate;
		public SalString sMasterDesc;
		public SalDateTime dMasterValidFrom;
		public SalDateTime dMasterValidUntil;
		public SalString sIncludeAmount;
		public SalString sCompany;
		#endregion
		
		#region Window Variables
		public SalString sFlag = "";
		public SalString sDlgName = "";
		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		protected dlgCreateVouTemplate()
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
		public static SalNumber ModalDialog(Control owner, ref SalString sMasterTemplate, ref SalString sMasterDesc, ref SalDateTime dMasterValidFrom, ref SalDateTime dMasterValidUntil, ref SalString sIncludeAmount, ref SalString sCompany)
		{
			dlgCreateVouTemplate dlg = DialogFactory.CreateInstance<dlgCreateVouTemplate>();
			dlg.sMasterTemplate = sMasterTemplate;
			dlg.sMasterDesc = sMasterDesc;
			dlg.dMasterValidFrom = dMasterValidFrom;
			dlg.dMasterValidUntil = dMasterValidUntil;
			dlg.sIncludeAmount = sIncludeAmount;
			dlg.sCompany = sCompany;
			SalNumber ret = dlg.ShowDialog(owner);
			sMasterTemplate = dlg.sMasterTemplate;
			sMasterDesc = dlg.sMasterDesc;
			dMasterValidFrom = dlg.dMasterValidFrom;
			dMasterValidUntil = dlg.dMasterValidUntil;
			sIncludeAmount = dlg.sIncludeAmount;
			sCompany = dlg.sCompany;
			return ret;
		}
		
		/// <summary>
		/// Returns the object instance associated with the window handle.
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public new static dlgCreateVouTemplate FromHandle(SalWindowHandle handle)
		{
			return ((dlgCreateVouTemplate)SalWindow.FromHandle(handle, typeof(dlgCreateVouTemplate)));
		}
		#endregion
		
		#region Methods
		
		/// <summary>
		/// </summary>
		/// <returns>
		/// Applications should return FALSE to skip standard window startup logic (such
		/// as exectuing the "startup behavior" settings), or TRUE to allow standard logic.
		/// </returns>
		public new SalBoolean FrameStartupUser()
		{
			#region Actions
			using (new SalContext(this))
			{
				DataRecordNew(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
				SetDefaultData();
			}

			return false;
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
				else if (sMethod == "Cancel") 
				{
					return MyCancel(nWhat);
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
			#region Actions
			using (new SalContext(this))
			{
				switch (nWhat)
				{
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
						return true;
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
						if (InforValidation()) 
						{
							Sal.EndDialog(i_hWndSelf, Sys.IDOK);
						}
						// ! PRECONVERSION: C# case statement do not support fallthrough. Return or Break required. Can be done in Sparx project.
						goto default;
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
		/// <returns></returns>
		public virtual SalNumber SetDefaultData()
		{
			#region Actions
			using (new SalContext(this))
			{
				// Bug 77590, Begin
				cbIncludeAmount.Checked = true;
				// Bug 77590, End
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber InforValidation()
		{
			#region Actions
			using (new SalContext(this))
			{
				if (Sal.IsNull(dfTemplate)) 
				{
					Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_TemplateMandatory, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
					Sal.SetFocus(dfTemplate);
					return false;
				}
				if (Sal.IsNull(dfDescription)) 
				{
					Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_DescriptionMandatory, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
					Sal.SetFocus(dfDescription);
					return false;
				}
				if (Sal.IsNull(dfValidFrom)) 
				{
					Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_ValidFromMandatory, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
					Sal.SetFocus(dfValidFrom);
					return false;
				}
				if (Sal.IsNull(dfValidUntil)) 
				{
					Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_ValidUntilMandatory, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
					Sal.SetFocus(dfValidUntil);
					return false;
				}
				if (dfValidFrom.DateTime > dfValidUntil.DateTime) 
				{
					Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_InvalidDate, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
					Sal.SetFocus(dfValidFrom);
					return false;
				}
				sDlgName = ":i_hWndFrame." + Ifs.Fnd.ApplicationForms.Int.QualifiedItemNameGet(i_hWndSelf) + ".";
				using(SignatureHints hints = SignatureHints.NewContext())
				{
					hints.Add("VOUCHER_TEMPLATE_API.Template_Check_", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
					if (!(DbPLSQLBlock(cSessionManager.c_hSql, sDlgName + "sFlag := " + cSessionManager.c_sDbPrefix + "VOUCHER_TEMPLATE_API.Template_Check_(" + sDlgName + "i_sCompany," + sDlgName + "dfTemplate )"))) 
					{
						return false;
					}
				}
				if (sFlag == "TRUE") 
				{
					Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_TemplateExist, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
					Sal.SetFocus(dfTemplate);
					return false;
				}
				AssignValues();
				return true;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber AssignValues()
		{
			#region Actions
			using (new SalContext(this))
			{
				sMasterTemplate = dfTemplate.Text;
				sMasterDesc = dfDescription.Text;
				dMasterValidFrom = dfValidFrom.DateTime;
				dMasterValidUntil = dfValidUntil.DateTime;
				if (cbIncludeAmount.Checked == true) 
				{
					sIncludeAmount = "TRUE";
				}
				else
				{
					sIncludeAmount = "FALSE";
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
		private void dlgCreateVouTemplate_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Create:
					this.dlgCreateVouTemplate_OnSAM_Create(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_Create event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dlgCreateVouTemplate_OnSAM_Create(object sender, WindowActionsEventArgs e)
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
		private void dfValidUntil_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_KillFocus:
					e.Handled = true;
					Sal.SetFocus(this.pbOK);
					break;
			}
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
				case Sys.SAM_KillFocus:
					e.Handled = true;
					Sal.SetFocus(this.dfTemplate);
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
