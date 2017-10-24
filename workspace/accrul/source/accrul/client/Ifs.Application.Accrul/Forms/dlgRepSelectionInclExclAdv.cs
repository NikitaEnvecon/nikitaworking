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
	/// <param name="p_sCompany"></param>
	/// <param name="p_sObjectGroupId"></param>
	/// <param name="p_sObjectId"></param>
	/// <param name="p_nSelectionId"></param>
	/// <param name="p_nItemId"></param>
	/// <param name="p_sView"></param>
	/// <param name="p_sColId"></param>
	/// <param name="p_sColDesc"></param>
	/// <param name="p_sUseCompany"></param>
	public partial class dlgRepSelectionInclExclAdv : cDialogBox
	{
		#region Window Parameters
		public SalString p_sCompany;
		public SalString p_sObjectGroupId;
		public SalString p_sObjectId;
		public SalNumber p_nSelectionId;
		public SalNumber p_nItemId;
		public SalString p_sView;
		public SalString p_sColId;
		public SalString p_sColDesc;
		public SalString p_sUseCompany;
		#endregion
		
		#region Window Variables
		public SalString sDescription = "";
		public SalString sView = "";
		public SalWindowHandle hWndFocusField = SalWindowHandle.Null;
		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		protected dlgRepSelectionInclExclAdv()
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
		public static SalNumber ModalDialog(Control owner, SalString p_sCompany, SalString p_sObjectGroupId, SalString p_sObjectId, SalNumber p_nSelectionId, SalNumber p_nItemId, SalString p_sView, SalString p_sColId, SalString p_sColDesc, SalString p_sUseCompany)
		{
			dlgRepSelectionInclExclAdv dlg = DialogFactory.CreateInstance<dlgRepSelectionInclExclAdv>();
			dlg.p_sCompany = p_sCompany;
			dlg.p_sObjectGroupId = p_sObjectGroupId;
			dlg.p_sObjectId = p_sObjectId;
			dlg.p_nSelectionId = p_nSelectionId;
			dlg.p_nItemId = p_nItemId;
			dlg.p_sView = p_sView;
			dlg.p_sColId = p_sColId;
			dlg.p_sColDesc = p_sColDesc;
			dlg.p_sUseCompany = p_sUseCompany;
			SalNumber ret = dlg.ShowDialog(owner);
			return ret;
		}
		
		/// <summary>
		/// Returns the object instance associated with the window handle.
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public new static dlgRepSelectionInclExclAdv FromHandle(SalWindowHandle handle)
		{
			return ((dlgRepSelectionInclExclAdv)SalWindow.FromHandle(handle, typeof(dlgRepSelectionInclExclAdv)));
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
				sView = p_sView;
				if (p_sUseCompany == "TRUE") 
				{
					sView = sView + "(COMPANY)";
				}
				Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
				tblValues_colValue.p_sLovReference = sView;
			}

			return 0;
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
				if (sMethod == "LOV") 
				{
					if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire) 
					{
						return Sal.SendMsg(tblValues_colValue, Ifs.Fnd.ApplicationForms.Const.PM_DataItemLov, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0);
					}
					if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
					{
						Sal.SendMsg(tblValues_colValue, Ifs.Fnd.ApplicationForms.Const.PM_DataItemLov, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
						Sal.TblSetFocusCell(tblValues, Sal.TblQueryContext(tblValues), tblValues_colValue, 0, -1);
					}
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
		private void dlgRepSelectionInclExclAdv_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Create:
                    this.dlgRepSelectionInclExclAdv_OnSAM_Create(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_Create event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dlgRepSelectionInclExclAdv_OnSAM_Create(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam);
			Sal.CenterWindow(this);
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void tblValues_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_FetchRowDone:
					this.tblValues_OnSAM_FetchRowDone(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_FetchRowDone event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblValues_OnSAM_FetchRowDone(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			Sal.SendClassMessage(Sys.SAM_FetchRowDone, Sys.wParam, Sys.lParam);
			this.GetStatusAndDescription();
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void pbSave_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Click:
					this.pbSave_OnSAM_Click(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_Click event handler.
		/// </summary>
		/// <param name="message"></param>
		private void pbSave_OnSAM_Click(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0)) 
			{
				Sal.EndDialog(this, Sys.IDOK);
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
				case Sys.SAM_Click:
					e.Handled = true;
					Sal.EndDialog(this, Sys.IDCANCEL);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void pbRemove_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Click:
					e.Handled = true;
					this.RemoveRow();
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
		
		#region ChildTables-tblValues
			
		#region Methods
			
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual new SalNumber DataRecordGetDefaults()
		{
		    tblValues_colCompany.Text = this.p_sCompany;
		    tblValues_colObjectGroupId.Text = this.p_sObjectGroupId;
		    tblValues_colObjectId.Text = this.p_sObjectId;
		    tblValues_colSelectionId.Number = this.p_nSelectionId;
		    tblValues_colItemId.Number = this.p_nItemId;
		    tblValues_colCompany.EditDataItemSetEdited();
		    tblValues_colObjectGroupId.EditDataItemSetEdited();
		    tblValues_colObjectId.EditDataItemSetEdited();
		    tblValues_colSelectionId.EditDataItemSetEdited();
		    tblValues_colItemId.EditDataItemSetEdited();
			return 0;
		}
			
		/// <summary>
		/// This function return both description and status for current argument
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber GetStatusAndDescription()
		{
			#region Local Variables
			SalString sSqlStatment = "";
			SalNumber nInd = 0;
			#endregion
				
			#region Actions
			using (new SalContext(tblValues))
			{
				if (this.p_sColDesc != Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
					sSqlStatment = "SELECT " + this.p_sColDesc;
				}
				else
				{
					sSqlStatment = "SELECT " + this.p_sColId;
				}
				sSqlStatment = sSqlStatment + " INTO\r\n" +
				"    :i_hWndFrame.dlgRepSelectionInclExclAdv.sDescription\r\n" +
				" FROM &AO." + this.p_sView;
				if (this.p_sUseCompany == "TRUE") 
				{
					sSqlStatment = sSqlStatment + " WHERE COMPANY=:i_hWndFrame.dlgRepSelectionInclExclAdv.p_sCompany\r\n" +
					"        AND " + this.p_sColId + " = :i_hWndFrame.dlgRepSelectionInclExclAdv.tblValues_colValue";
				}
				else
				{
					sSqlStatment = sSqlStatment + " WHERE " + this.p_sColId + " = :i_hWndFrame.dlgRepSelectionInclExclAdv.tblValues_colValue";
				}
				if (DbPrepareAndExecute(cSessionManager.c_hSql, sSqlStatment)) 
				{
					if (DbFetchNext(cSessionManager.c_hSql, ref nInd)) 
					{
						tblValues_colDescription.Text = this.sDescription;
						tblValues_colStatus.Text = Properties.Resources.TEXT_SEL_TEMPL_ArgumentExist;
					}
					else
					{
						tblValues_colDescription.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
						tblValues_colStatus.Text = Properties.Resources.TEXT_SEL_TEMPL_ArgumentNotExist;
					}
				}
			}

			return 0;
			#endregion
		}
			
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber RemoveRow()
		{
			#region Actions
			using (new SalContext(tblValues))
			{
				if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0)) 
				{
					Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
				}
				else
				{
					Sal.MessageBeep(0);
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
		private void tblValues_colValue_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
					this.tblValues_colValue_OnPM_DataItemValidate(sender, e);
					break;
					
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovDone:
					e.Handled = true;
					this.GetStatusAndDescription();
					break;
					
				// On SAM_SetFocus
					
				// Set colValue.p_sLovReference = sView
					
				// Call SalSendClassMessage( SAM_SetFocus, lParam, wParam )
					
				// Call pbLov.MethodInvestigateState()
			}
			#endregion
		}
			
		/// <summary>
		/// PM_DataItemValidate event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblValues_colValue_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (!(Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam))) 
			{
				e.Return = false;
				return;
			}
			this.GetStatusAndDescription();
			e.Return = true;
			return;
			#endregion
		}
			
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void tblValues_colDescription_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
					e.Handled = true;
					e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
					return;
			}
			#endregion
		}
		#endregion
			
		#region Late Bind Methods

        private void tblValues_DataRecordGetDefaultsEvent(object sender, FndReturnEventArgsSalBoolean e)
        {
            e.Handled = true;
            e.ReturnValue = this.DataRecordGetDefaults();
        }
		#endregion

		#endregion
	}
}
