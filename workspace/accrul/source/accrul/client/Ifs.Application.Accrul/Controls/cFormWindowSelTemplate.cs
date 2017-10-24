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
using System.Collections.Generic;

namespace Ifs.Application.Accrul
{
	
	/// <summary>
	/// </summary>
	public partial class cFormWindowSelTemplate : cFormWindowFin
	{
		#region Fields
		public SalNumber i_nNum = 0;
		public SalArray<SalString> i_sRecords = new SalArray<SalString>();
		public SalArray<SalString> i_sUnits = new SalArray<SalString>();
		public SalString i_sUserId = "";
		public SalString i_sSecurityInfo = "";
		public SalString i_sPrivate = "";
		public SalString i_sObjGroupId = "";
		public SalString i_sWarning = "";
		public SalString i_sTemplVersion = "";
		public SalString i_sOperatorDbList = "";
		public SalArray<SalString> i_sOperatorDbValues = new SalArray<SalString>();
		public SalString i_sOperatorClientList = "";
		public SalArray<SalString> i_sOperatorClientValues = new SalArray<SalString>();
		public SalString i_sIsCodePart = "";
		public SalString i_sCodePartDesc = "";
		public SalString i_sViewName = "";
		public SalString i_sColumnId = "";
		public SalString i_sColumnDesc = "";
		public SalBoolean i_bChanged = false;
		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		public cFormWindowSelTemplate()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
		}
		
		/// <summary>
		/// Multiple Inheritance: Constructor.
		/// </summary>
		/// <param name="derived"></param>
		public cFormWindowSelTemplate(ISalWindow derived)
		{
			// Attach derived instance.
			this._derived = derived;
			// This call is required by the Windows Form Designer.
			InitializeComponent();
			// Attach actions handler to derived instance.
			this._derived.AttachMessageActions(this);
		}
		#endregion
		
		#region Methods
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public new SalBoolean FrameStartupUser()
		{
			#region Local Variables
			SalString sOut = "";
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				((cFormWindowFin)this).FrameStartupUser();
				i_sUserId = Ifs.Fnd.ApplicationForms.Int.FndUser();
				using(SignatureHints hints = SignatureHints.NewContext())
				{
					hints.Add("Security_SYS.Has_System_Privilege", System.Data.ParameterDirection.Input);
					hints.Add("Fin_Sel_Templ_Ownership_API.Decode", System.Data.ParameterDirection.Input);
					hints.Add("Fin_Sel_Object_Operator_API.Enumerate_Db", System.Data.ParameterDirection.Output);
					hints.Add("Fin_Sel_Object_Operator_API.Enumerate", System.Data.ParameterDirection.Output);
					DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN\r\n" +
						"				:i_hWndFrame.cFormWindowSelTemplate.i_sSecurityInfo := &AO.Security_SYS.Has_System_Privilege( 'ADMINISTRATOR');\r\n" +
						"				:i_hWndFrame.cFormWindowSelTemplate.i_sPrivate := &AO.Fin_Sel_Templ_Ownership_API.Decode( 'PRIVATE' );\r\n" +
						"				&AO.Fin_Sel_Object_Operator_API.Enumerate_Db(:i_hWndFrame.cFormWindowSelTemplate.i_sOperatorDbList);\r\n" +
						"				&AO.Fin_Sel_Object_Operator_API.Enumerate(:i_hWndFrame.cFormWindowSelTemplate.i_sOperatorClientList);\r\n			END;");
				}
				if (i_sOperatorDbList != Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
					i_sOperatorClientValues.SetUpperBound(1, -1);
					i_sOperatorDbValues.SetUpperBound(1, -1);
					i_sOperatorClientList.Tokenize(Ifs.Fnd.ApplicationForms.Const.strNULL, Ifs.Fnd.ApplicationForms.Var.g_sCHAR_US, i_sOperatorClientValues);
					i_sOperatorDbList.Tokenize(Ifs.Fnd.ApplicationForms.Const.strNULL, Ifs.Fnd.ApplicationForms.Var.g_sCHAR_US, i_sOperatorDbValues);
				}
				cmbOwnership.LookupInit();
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
			#region Local Variables
			SalString sName = "";
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				if (sMethod == "ChangeCompany") 
				{
					switch (nWhat)
					{
						case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
							return Sal.SendClassMessage(Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Sys.lParam);
						
						case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
							Sal.SendClassMessage(Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Sys.lParam);
							break;
					}
				}
				else if (sMethod == "CopyTemplate") 
				{
					return CopyTemplate(nWhat);
				}
				return 0;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public new SalBoolean DataRecordGetDefaults()
		{
			#region Actions
			using (new SalContext(this))
			{
				dfsObjectGroupId.Text = i_sObjGroupId;
				dfsObjectGroupId.EditDataItemSetEdited();
				dfsTemplateOwner.Text = i_sUserId;
				dfsTemplateOwner.EditDataItemSetEdited();
				Sal.ListSetSelect(cmbOwnership, 0);
				cmbOwnership.EditDataItemSetEdited();
				return true;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="hSql"></param>
		/// <returns></returns>
		public new SalBoolean DataRecordCheckNew(SalSqlHandle hSql)
		{
			#region Actions
			using (new SalContext(this))
			{
				if (((cDataSource)this).DataRecordCheckNew(hSql)) 
				{
					if (cbDefault.Checked) 
					{
                        if (!CheckDefaultTemplate())
                        {
                            SalString lsAttr = "";
  						    i_bChanged = false;
                            cbDefault.EditDataItemValueSet(1, ((SalString)"FALSE").ToHandle());
                        }
                    }
					return true;
				}
				return false;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="hSql"></param>
		/// <returns></returns>
		public new SalBoolean DataRecordCheckModify(SalSqlHandle hSql)
		{
			#region Actions
			using (new SalContext(this))
			{
				if (((cDataSource)this).DataRecordCheckModify(hSql)) 
				{
					if (cbDefault.Checked && i_bChanged) 
					{
						i_bChanged = false;
                        return CheckDefaultTemplate();
					}
					return true;
				}
				return false;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean CheckDefaultTemplate()
		{
			#region Actions
			using (new SalContext(this))
			{
				using(SignatureHints hints = SignatureHints.NewContext())
				{
					hints.Add("Fin_Sel_Obj_Templ_API.Check_Default_Template__", System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
					if (DbPLSQLBlock(cSessionManager.c_hSql, "&AO.Fin_Sel_Obj_Templ_API.Check_Default_Template__(\r\n" +
						"			:i_hWndFrame.cFormWindowSelTemplate.i_sWarning,\r\n" +
						"			:i_hWndFrame.cFormWindowSelTemplate.dfsCompany,\r\n" +
						"			:i_hWndFrame.cFormWindowSelTemplate.dfsObjectGroupId,\r\n" +
						"			:i_hWndFrame.cFormWindowSelTemplate.cmbOwnership,\r\n" +
						"			:i_hWndFrame.cFormWindowSelTemplate.dfsTemplateOwner )")) 
					{
						if (i_sWarning != SalString.Null) 
						{
							switch (Ifs.Fnd.ApplicationForms.Int.PalMessageBox(i_sWarning, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Warning, (Ifs.Fnd.ApplicationForms.Const.WARNING_YesNo | Sys.MB_DefButton2)))
							{
								case Sys.IDYES:
									return true;
								
								case Sys.IDNO:
									return false;
							}
						}
						return true;
					}
					else
					{
						return false;
					}
				}
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean IsValidTemplate()
		{
			#region Actions
			using (new SalContext(this))
			{
				if (cmbOwnership.Text != i_sPrivate) 
				{
					return true;
				}
				else
				{
					if (dfsTemplateOwner.Text == i_sUserId || i_sSecurityInfo == "%") 
					{
						return true;
					}
					return false;
				}
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nWhat"></param>
		/// <returns></returns>
		public virtual SalNumber CopyTemplate(SalNumber nWhat)
		{
			#region Actions
			using (new SalContext(this))
			{
				switch (nWhat)
				{
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
						if (((bool)DataSourceIsDirty(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire)) || i_nDataSourceState == Ifs.Fnd.ApplicationForms.Const.DATASOURCE_Empty) 
						{
							return 0;
						}
						return Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("dlgCopySelectionTemplate"));
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
						if (dlgCopySelectionTemplate.ModalDialog(this, cmbTemplateId.i_sMyValue, dfsCompany.Text, dfsObjectGroupId.Text)) 
						{
							if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.RecCountGet() > 0) 
							{
								Sal.WaitCursor(true);
								InitFromTransferedData();
								Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();
								cmbTemplateId.RecordSelectionListSetSelect(0);
								Sal.PostMsg(i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceRefresh, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
								Sal.WaitCursor(false);
								return 0;
							}
						}
						return 1;
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
		private void cFormWindowSelTemplate_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove:
					this.cFormWindowSelTemplate_OnPM_DataRecordRemove(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// PM_DataRecordRemove event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cFormWindowSelTemplate_OnPM_DataRecordRemove(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (!(this.IsValidTemplate())) 
			{
				e.Return = false;
				return;
			}
			e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void dfsTemplateDescription_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
					this.dfsTemplateDescription_OnPM_DataItemQueryEnabled(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// PM_DataItemQueryEnabled event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfsTemplateDescription_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (this.dfsTemplateDescription.EditDataItemStateGet() != Ifs.Fnd.ApplicationForms.Const.EDIT_New) 
			{
				if (!(this.IsValidTemplate())) 
				{
					e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
					return;
				}
			}
			e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void cmbOwnership_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
					this.cmbOwnership_OnPM_DataItemQueryEnabled(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// PM_DataItemQueryEnabled event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cmbOwnership_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (this.cmbOwnership.EditDataItemStateGet() != Ifs.Fnd.ApplicationForms.Const.EDIT_New) 
			{
				if (this.dfsTemplateOwner.Text != this.i_sUserId) 
				{
					e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
					return;
				}
			}
			e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void cbDefault_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
					this.cbDefault_OnPM_DataItemQueryEnabled(sender, e);
					break;
				
				case Sys.SAM_Click:
					this.cbDefault_OnSAM_Click(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// PM_DataItemQueryEnabled event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cbDefault_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (this.cbDefault.EditDataItemStateGet() != Ifs.Fnd.ApplicationForms.Const.EDIT_New) 
			{
				if (!(this.IsValidTemplate())) 
				{
					e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
					return;
				}
			}
			e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
		
		/// <summary>
		/// SAM_Click event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cbDefault_OnSAM_Click(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.i_bChanged = true;
			e.Return = Sal.SendClassMessage(Sys.SAM_Click, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void tblSelectionItems_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_FetchRowDone:
					this.tblSelectionItems_OnSAM_FetchRowDone(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew:
					this.tblSelectionItems_OnPM_DataRecordNew(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove:
					this.tblSelectionItems_OnPM_DataRecordRemove(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordDuplicate:
					this.tblSelectionItems_OnPM_DataRecordDuplicate(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_FetchRowDone event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblSelectionItems_OnSAM_FetchRowDone(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			Sal.SendClassMessage(Sys.SAM_FetchRowDone, Sys.wParam, Sys.lParam);
			if (this.tblSelectionItems_colsDataTypeDb.Text == "DATE") 
			{
				Sal.GetWindowText(this.tblSelectionItems_coldFromValueDate, ref this.sValue, 50);
				Sal.SetWindowText(this.tblSelectionItems_colsFromValue, this.sValue);
				Sal.GetWindowText(this.tblSelectionItems_coldToValueDate, ref this.sValue, 50);
				Sal.SetWindowText(this.tblSelectionItems_colsToValue, this.sValue);
			}
			#endregion
		}
		
		/// <summary>
		/// PM_DataRecordNew event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblSelectionItems_OnPM_DataRecordNew(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (cFormWindowSelTemplate.FromHandle(this.tblSelectionItems.i_hWndParent).i_nDataSourceState != Ifs.Fnd.ApplicationForms.Const.DATASOURCE_Query && cFormWindowSelTemplate.FromHandle(this.tblSelectionItems.i_hWndParent).i_nDataSourceState != 
			Ifs.Fnd.ApplicationForms.Const.DATASOURCE_DetailChanged) 
			{
				e.Return = false;
				return;
			}
			if (!(this.IsValidTemplate())) 
			{
				e.Return = false;
				return;
			}
			if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew, Sys.wParam, Sys.lParam)) 
			{
				if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
				{
					if (!(Ifs.Fnd.ApplicationForms.Var.Cache.SessionRetrieve("ACCRUL_SELECTION_OBJECT_GROUP=" + this.i_sObjGroupId, ref this.sTempCache))) 
					{
						this.GetObjectDataFromDb();
					}
				}
				e.Return = true;
				return;
			}
			e.Return = false;
			return;
			#endregion
		}
		
		/// <summary>
		/// PM_DataRecordRemove event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblSelectionItems_OnPM_DataRecordRemove(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (cFormWindowSelTemplate.FromHandle(this.tblSelectionItems.i_hWndParent).i_nDataSourceState != Ifs.Fnd.ApplicationForms.Const.DATASOURCE_Query && cFormWindowSelTemplate.FromHandle(this.tblSelectionItems.i_hWndParent).i_nDataSourceState != 
			Ifs.Fnd.ApplicationForms.Const.DATASOURCE_DetailChanged) 
			{
				e.Return = false;
				return;
			}
			if (!(this.IsValidTemplate())) 
			{
				e.Return = false;
				return;
			}
			e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
		
		/// <summary>
		/// PM_DataRecordDuplicate event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblSelectionItems_OnPM_DataRecordDuplicate(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordDuplicate, Sys.wParam, Sys.lParam)) 
			{
				if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
				{
					this.tblSelectionItems_colsOperatorDb.Text = this.GetOperatorDb(this.tblSelectionItems_colsOperator.Text);
				}
				e.Return = true;
				return;
			}
			else
			{
				e.Return = false;
				return;
			}
			#endregion
		}
		#endregion
		
		#region Multiple Inheritance Operators
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cFormWindowSelTemplate to type cDataSource.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cDataSource(cFormWindowSelTemplate self)
		{
			return self._cDataSource;
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cFormWindowSelTemplate to type cSessionManager.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cSessionManager(cFormWindowSelTemplate self)
		{
			return ((cSessionManager)self._cDataSource);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cFormWindowSelTemplate to type cWindowTranslation.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cWindowTranslation(cFormWindowSelTemplate self)
		{
			return ((cWindowTranslation)self._cDataSource);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cFormWindowSelTemplate to type SalToolTipManager.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator SalToolTipManager(cFormWindowSelTemplate self)
		{
			return self._SalToolTipManager;
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cFormWindowSelTemplate to type cFinlibServices.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cFinlibServices(cFormWindowSelTemplate self)
		{
			return self._cFinlibServices;
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cDataSource to type cFormWindowSelTemplate.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cFormWindowSelTemplate(cDataSource super)
		{
			return ((cFormWindowSelTemplate)super._derived);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cSessionManager to type cFormWindowSelTemplate.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cFormWindowSelTemplate(cSessionManager super)
		{
			return ((cFormWindowSelTemplate)((cDataSource)super._derived));
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cWindowTranslation to type cFormWindowSelTemplate.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cFormWindowSelTemplate(cWindowTranslation super)
		{
			return ((cFormWindowSelTemplate)((cDataSource)super._derived));
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type SalToolTipManager to type cFormWindowSelTemplate.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cFormWindowSelTemplate(SalToolTipManager super)
		{
			return ((cFormWindowSelTemplate)((cDataSource)super._derived));
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cFinlibServices to type cFormWindowSelTemplate.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cFormWindowSelTemplate(cFinlibServices super)
		{
			return ((cFormWindowSelTemplate)super._derived);
		}
		#endregion
		
		#region System Methods/Properties
		
		/// <summary>
		/// Returns the object instance associated with the window handle.
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public new static cFormWindowSelTemplate FromHandle(SalWindowHandle handle)
		{
			return ((cFormWindowSelTemplate)SalWindow.FromHandle(handle, typeof(cFormWindowSelTemplate)));
		}
		#endregion
		
		#region Late Bind Methods
		
		/// <summary>
		/// Virtual wrapper replacement for late-bound (..) calls.
		/// </summary>
		public override SalBoolean vrtDataRecordCheckModify(SalSqlHandle hSql)
		{
			LateBind lateBind = (LateBind)this._derived;
			if (lateBind == null) 
			{
				return this.DataRecordCheckModify(hSql);
			}
			else
			{
				return lateBind.vrtDataRecordCheckModify(hSql);
			}
		}
		
		/// <summary>
		/// Virtual wrapper replacement for late-bound (..) calls.
		/// </summary>
		public override SalBoolean vrtDataRecordCheckNew(SalSqlHandle hSql)
		{
			LateBind lateBind = (LateBind)this._derived;
			if (lateBind == null) 
			{
				return this.DataRecordCheckNew(hSql);
			}
			else
			{
				return lateBind.vrtDataRecordCheckNew(hSql);
			}
		}
		
		/// <summary>
		/// Virtual wrapper replacement for late-bound (..) calls.
		/// </summary>
		public override SalBoolean vrtDataRecordGetDefaults()
		{
			LateBind lateBind = (LateBind)this._derived;
			if (lateBind == null) 
			{
				return this.DataRecordGetDefaults();
			}
			else
			{
				return lateBind.vrtDataRecordGetDefaults();
			}
		}
		
		/// <summary>
		/// Virtual wrapper replacement for late-bound (..) calls.
		/// </summary>
		public override SalBoolean vrtFrameStartupUser()
		{
			LateBind lateBind = (LateBind)this._derived;
			if (lateBind == null) 
			{
				return this.FrameStartupUser();
			}
			else
			{
				return lateBind.vrtFrameStartupUser();
			}
		}
		
		/// <summary>
		/// Virtual wrapper replacement for late-bound (..) calls.
		/// </summary>
		public override SalNumber vrtUserMethod(SalNumber nWhat, SalString sMethod)
		{
			LateBind lateBind = (LateBind)this._derived;
			if (lateBind == null) 
			{
				return this.UserMethod(nWhat, sMethod);
			}
			else
			{
				return lateBind.vrtUserMethod(nWhat, sMethod);
			}
		}
		#endregion
		
		#region ChildTable-tblSelectionItems
					
		#region Window Variables
		public SalString sValue = "";
		public SalString sViewName = "";
		public SalBoolean bFoundInCache = false;
		public SalString sTempCache = "";
		public SalString sCacheValue = "";
		public SalArray<SalString> sCacheTokens = new SalArray<SalString>();
		public SalString __sDataType = "";
		public SalString __sLovReference = "";
		public SalString __sZoomWindow = "";
		public SalString __sZoomWindowColKey = "";
		public SalString __sZoomWindowParentColKey = "";
		public SalString __sObjectColId = "";
		public SalString __sObjectColDesc = "";
		public SalString __sManualInput = "";
		public SalString sColumnId = "";
		public SalString sColumnDesc = "";
		public SalString sUseCompany = "";
		#endregion
						
		#region Methods
			
		/// <summary>
		/// </summary>
		/// <param name="hWndCol"></param>
		/// <returns></returns>
		public virtual SalBoolean IsEditable(SalWindowHandle hWndCol)
		{
			#region Local Variables
			SalString sName = "";
			#endregion
				
			#region Actions
			
			if (!(this.IsValidTemplate())) 
			{
				return false;
			}
			Sal.GetItemName(hWndCol, ref sName);

			if (sName == tblSelectionItems_colsFromValue.Name) 
			{
                return tblSelectionItems_colsOperatorDb.Text != "INCL" && tblSelectionItems_colsOperatorDb.Text != "EXCL";
			}
			else if (sName == tblSelectionItems_colsToValue.Name) 
			{
                return tblSelectionItems_colsOperatorDb.Text == "BETWEEN" || tblSelectionItems_colsOperatorDb.Text == "NOTBETWEEN";
			}
			return false;
			#endregion
		}
			
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber RefreshValueItems()
		{
			if (tblSelectionItems_colsFromValue.Text != Sys.STRING_Null) 
			{
                if (tblSelectionItems_colsOperatorDb.Text == "INCL" || tblSelectionItems_colsOperatorDb.Text == "EXCL") 
				{
                    tblSelectionItems_colsFromValue.Text = Sys.STRING_Null;
                    tblSelectionItems_coldFromValueDate.DateTime = Sys.DATETIME_Null;
                    tblSelectionItems_colsFromValue.EditDataItemSetEdited();
                    tblSelectionItems_coldFromValueDate.EditDataItemSetEdited();
				}
			}
            if (tblSelectionItems_colsToValue.Text != Sys.STRING_Null) 
			{
                if (tblSelectionItems_colsOperatorDb.Text == "INCL" || tblSelectionItems_colsOperatorDb.Text == "EXCL") 
				{
                    tblSelectionItems_colsToValue.Text = Sys.STRING_Null;
                    tblSelectionItems_coldToValueDate.DateTime = Sys.DATETIME_Null;
                    tblSelectionItems_colsToValue.EditDataItemSetEdited();
                    tblSelectionItems_coldToValueDate.EditDataItemSetEdited();
				}
                if (tblSelectionItems_colsOperatorDb.Text != "BETWEEN" && tblSelectionItems_colsOperatorDb.Text != "NOTBETWEEN") 
				{
                    tblSelectionItems_colsToValue.Text = Sys.STRING_Null;
                    tblSelectionItems_coldToValueDate.DateTime = Sys.DATETIME_Null;
                    tblSelectionItems_colsToValue.EditDataItemSetEdited();
                    tblSelectionItems_coldToValueDate.EditDataItemSetEdited();
				}
			}
			return 0;
		}
			
		/// <summary>
		/// </summary>
		/// <param name="nWhat"></param>
		/// <param name="sMethod"></param>
		/// <returns></returns>
        public virtual SalBoolean tblSelectionItems_UserMethod(SalNumber nWhat, SalString sMethod)
        {
            if (sMethod == "IncludeExclude")
            {
                return LaunchIncludeExclude(nWhat);
            }
            return true;
        }
			
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean OneRowSelected()
		{
            if (Sal.TblAnyRows(tblSelectionItems, Sys.ROW_Selected, (Sys.ROW_New | Sys.ROW_MarkDeleted)))
            {
                SalNumber nCurrentRow = Sys.TBL_MinRow;
                if (Sal.TblFindNextRow(tblSelectionItems, ref nCurrentRow, Sys.ROW_Selected, 0))
                {
                    return !(Sal.TblFindNextRow(tblSelectionItems, ref nCurrentRow, Sys.ROW_Selected, 0));
                }
            }
			return false;
		}
			
		/// <summary>
		/// </summary>
		/// <param name="nWhat"></param>
		/// <returns></returns>
		public virtual SalBoolean LaunchIncludeExclude(SalNumber nWhat)
		{
			#region Local Variables
			SalArray<SalString> sArray = new SalArray<SalString>();
			SalArray<SalWindowHandle> hWndArray = new SalArray<SalWindowHandle>();
			SalString stmt = "";
			#endregion
				
			#region Actions
			
			switch (nWhat)
			{
				case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                    if (Sal.SendMsg(this.tblSelectionItems, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0))
                    {
                        return false;
                    }
                    if (!(IsViewAvailable(tblSelectionItems_colsObjectViewName.Text))) 
					{
						return false;
					}
                    return this.IsValidTemplate() && OneRowSelected() && (tblSelectionItems_colsOperatorDb.Text == "INCL" || tblSelectionItems_colsOperatorDb.Text == "EXCL");
						
				case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                    IDictionary<string, string> namedBindVariables = new Dictionary<string, string>();
                    namedBindVariables.Add("sViewName", this.QualifiedVarBindName("sViewName"));
                    namedBindVariables.Add("sColumnId", this.QualifiedVarBindName("sColumnId"));
                    namedBindVariables.Add("sColumnDesc", this.QualifiedVarBindName("sColumnDesc"));
                    namedBindVariables.Add("colsSelectionObjectId", this.tblSelectionItems_colsSelectionObjectId.QualifiedBindName);
                    namedBindVariables.Add("colsCompany", this.tblSelectionItems_colsCompany.QualifiedBindName);
                    namedBindVariables.Add("colsTemplateId", this.tblSelectionItems_colsTemplateId.QualifiedBindName);
                    namedBindVariables.Add("colsObjectGroupId", this.tblSelectionItems_colsObjectGroupId.QualifiedBindName);
                    namedBindVariables.Add("colnItemId", this.tblSelectionItems_colnItemId.QualifiedBindName);
                    namedBindVariables.Add("colsValueExist",this.tblSelectionItems_colsValueExist.QualifiedBindName);

                    if (tblSelectionItems_colsManualInput.Text == "TRUE") 
					{
                        if (Ifs.Fnd.ApplicationForms.Var.Cache.SessionRetrieve("ACCRUL_SELECTION_OBJECT=" + tblSelectionItems_colsSelectionObjectId.Text, ref sCacheValue)) 
						{
							TokenizeCacheValue(sCacheValue);
							sViewName = __sLovReference;
							sColumnId = __sObjectColId;
							sColumnDesc = __sObjectColDesc;
						}
						else
						{
                            stmt = @"{sViewName} := &AO.Fin_Sel_Object_API.Get_Lov_Reference({colsSelectionObjectId} IN );                                            			
                                     {sColumnId} := &AO.Fin_Sel_Object_API.Get_Object_Col_Id ({colsSelectionObjectId} IN );
                                     {sColumnDesc} := &AO.Fin_Sel_Object_API.Get_Object_Col_Desc ({colsSelectionObjectId} IN );"; 
							DbPLSQLBlock(stmt,namedBindVariables);
								
						}
						sUseCompany = "FALSE";
						if (sViewName.Scan("(COMPANY)") != -1) 
						{
							sViewName = sViewName.Left(sViewName.Scan("(COMPANY)"));
							sUseCompany = "TRUE";
						}
                        if (dlgSelectionInclExclAdv.ModalDialog(Sys.hWndForm, tblSelectionItems_colsCompany.Text, tblSelectionItems_colsObjectGroupId.Text, tblSelectionItems_colsTemplateId.Text, tblSelectionItems_colnItemId.Number, sViewName, sColumnId, sColumnDesc, sUseCompany) == Sys.IDOK) 
						{
                            stmt = @"{colsValueExist} := &AO.Fin_Sel_Templ_Values_API.Is_Value_Exist ({colsCompany} IN,
														                                              {colsObjectGroupId} IN,
														                                              {colsTemplateId} IN,
														                                              {colnItemId} IN )";
							DbPLSQLBlock(stmt,namedBindVariables );
							return true;
						}
					}
					else
					{
                        if (dlgSelectionIncludeExclude.ModalDialog(Ifs.Fnd.ApplicationForms.Int.Explorer.ExplorerForm, tblSelectionItems_colsCompany.Text, tblSelectionItems_colsObjectGroupId.Text, tblSelectionItems_colsTemplateId.Text, tblSelectionItems_colnItemId.Number, tblSelectionItems_colsSelectionObjectId.Text) == Sys.IDOK) 
						{
                            stmt = @"{colsValueExist} := &AO.Fin_Sel_Templ_Values_API.Is_Value_Exist ({colsCompany} IN,
															                                          {colsObjectGroupId} IN,
															                                          {colsTemplateId} IN,
															                                          {colnItemId} IN )";
								
							DbPLSQLBlock(stmt,namedBindVariables);
							return true;
						}
					}
					break;
			}

			return false;
			#endregion
		}
			
		/// <summary>
		/// </summary>
		/// <param name="nWhat"></param>
		/// <param name="sLovRef"></param>
		/// <param name="hWndItem"></param>
		/// <param name="sZoomWindow"></param>
		/// <param name="sZoomWindowColKey"></param>
		/// <param name="sZoomWindowParentColKey"></param>
		/// <returns></returns>
		public virtual SalBoolean Zoom(SalNumber nWhat, SalString sLovRef, SalWindowHandle hWndItem, SalString sZoomWindow, SalString sZoomWindowColKey, SalString sZoomWindowParentColKey)
		{
			#region Local Variables
			SalString sWindowName = "";
			SalString sViewName = "";
			SalString sLu = "";
			SalArray<SalString> sItemNames = new SalArray<SalString>();
			SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
			SalNumber i = 0;
			#endregion
				
			#region Actions
				sWindowName = sZoomWindow;
				// The zoom functionality should rely on the information stored by Component.WindowRegister
				// But since this data is not that accurate support has been added to set the zoom window in the meta data
				// Set sViewName = SalStrLeftX( sLovRef, SalStrScan( sLovRef, '(' ) )
				// Set sLu = DbNameToClientName( sViewName )
				// Set sWindowName = Component.LUDefaultWindowGet( sLu )
				// If sWindowName = strNULL
				// Set sWindowName = Component.ViewDefaultWindowGet( sViewName )
				if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire) 
				{
					if (sWindowName == Ifs.Fnd.ApplicationForms.Const.strNULL) 
					{
						return false;
					}
					else
					{
						return Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(sWindowName) && Ifs.Fnd.ApplicationForms.Var.Component.IsWindowAvailable(sWindowName);
					}
				}
				else if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
				{
					i = 0;
					// Special handle the Code parts since they have the keys in the client in wrong order or has special coding in the client
					if (sLovRef.Scan("CODE_") != -1) 
					{
						// Check if company is in the LoV Reference
						sItemNames[i] = sZoomWindowColKey;
						hWndItems[i] = hWndItem;
						i = i + 1;
						if (sZoomWindowParentColKey.Scan("COMPANY") != -1) 
						{
							sItemNames[i] = "COMPANY";
                            hWndItems[i] = tblSelectionItems_colsCompany;
							i = i + 1;
						}
					}
					else
					{
						// Check if company is in the sZoomWindowParentColKey
						if (sZoomWindowParentColKey.Scan("COMPANY") != -1) 
						{
							sItemNames[i] = "COMPANY";
                            hWndItems[i] = tblSelectionItems_colsCompany;
							i = i + 1;
						}
						sItemNames[i] = sZoomWindowColKey;
						hWndItems[i] = hWndItem;
					}
					Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init(sWindowName, Sys.hWndForm, sItemNames, hWndItems);
					Ifs.Fnd.ApplicationForms.Var.DataTransfer.TypeSet("ZOOM");
					SessionCreateWindow(sWindowName, Sys.hWndMDI);
				}
				else
				{
					return false;
				}
		

			return false;
			#endregion
		}
			
		/// <summary>
		/// </summary>
		/// <param name="sLovReference"></param>
		/// <returns></returns>
		public virtual SalBoolean IsViewAvailable(SalString sLovReference)
		{
			#region Local Variables
			SalString sView = "";
			SalNumber nTo = 0;
			#endregion
				
			#region Actions
			nTo = sLovReference.Scan("(");
			if (nTo == -1) 
			{
				nTo = sLovReference.Length;
			}
			sView = sLovReference.Left(nTo);
			return Ifs.Fnd.ApplicationForms.Var.Security.IsViewAvailable(sView);
			#endregion
		}
			
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber GetObjectDataFromDb()
		{
			// String: sObjectId
				
			#region Local Variables
			SalString lsStmt = "";
			SalNumber i = 0;
			SalNumber nDummy = 0;
			SalArray<SalString> sSelectionObjects = new SalArray<SalString>();
			SalArray<SalString> sObjectData = new SalArray<SalString>();
			SalBoolean bReturn = false;
			#endregion
				
			#region Actions
			using (new SalContext(tblSelectionItems))
			{
				Ifs.Fnd.ApplicationForms.Var.g_Bind.Clear();
				lsStmt = "SELECT selection_object_id , data_type_db || '^' || lov_reference || '^' || zoom_window || '^' || zoom_window_col_key || '^' || zoom_window_parent_col_key || '^' || object_col_id || '^' || object_col_desc || '^' || manual_input_db into\r\n" +
				"	:g_Bind.s[0], :g_Bind.s[1]\r\n" +
				"	FROM &AO.FIN_SEL_OBJECT_COMPANY\r\n" +
				"	WHERE company = :i_hWndFrame.cFormWindowSelTemplate.dfsCompany\r\n" +
				"	AND object_group_id =  :i_hWndFrame.cFormWindowSelTemplate.i_sObjGroupId ";
				bReturn = DbPrepareAndExecute(cSessionManager.c_hSql, lsStmt);
				while (DbFetchNext(cSessionManager.c_hSql, ref nDummy)) 
				{
					sSelectionObjects[i] = Ifs.Fnd.ApplicationForms.Var.g_Bind.s[0];
					sObjectData[i] = Ifs.Fnd.ApplicationForms.Var.g_Bind.s[1];
					Ifs.Fnd.ApplicationForms.Var.Cache.SessionStore("ACCRUL_SELECTION_OBJECT_GROUP=" + cFormWindowSelTemplate.FromHandle(tblSelectionItems.i_hWndParent).i_sObjGroupId, "TRUE");
					Ifs.Fnd.ApplicationForms.Var.Cache.SessionStore("ACCRUL_SELECTION_OBJECT=" + Ifs.Fnd.ApplicationForms.Var.g_Bind.s[0], Ifs.Fnd.ApplicationForms.Var.g_Bind.s[1]);
					i = i + 1;
				}
			}

			return 0;
			#endregion
		}
			
		/// <summary>
		/// </summary>
		/// <param name="sCacheValue"></param>
		/// <returns></returns>
		public virtual SalString TokenizeCacheValue(SalString sCacheValue)
		{
			sCacheValue.Tokenize(Ifs.Fnd.ApplicationForms.Const.strNULL, "^", sCacheTokens);
			__sDataType = sCacheTokens[0];
			__sLovReference = sCacheTokens[1];
			__sZoomWindow = sCacheTokens[2];
			__sZoomWindowColKey = sCacheTokens[3];
			__sZoomWindowParentColKey = sCacheTokens[4];
			__sObjectColId = sCacheTokens[5];
			__sObjectColDesc = sCacheTokens[6];
			__sManualInput = sCacheTokens[7];
			return "";
		}

		/// <summary>
		/// </summary>
		/// <param name="sClientValue"></param>
		/// <returns></returns>
		public virtual SalString GetOperatorDb(SalString sClientValue)
		{				
			#region Actions
			using (new SalContext(this))
			{
				SalNumber nIndex = Vis.ArrayFindString(this.i_sOperatorClientValues, sClientValue);
				if (nIndex != SalNumber.Null) 
				{
					return this.i_sOperatorDbValues[nIndex];
				}
				else
				{
					return Ifs.Fnd.ApplicationForms.Const.strNULL;
				}
			}
			#endregion
		}
			
		/// <summary>
		/// </summary>
		/// <param name="sReference"></param>
		/// <param name="sReturnKeyName"></param>
		/// <param name="sColumnNames"></param>
		/// <param name="sColumnPrompts"></param>
		/// <returns></returns>
		public virtual new SalBoolean DataSourceReferenceItems(SalString sReference, SalString sReturnKeyName, SalArray<SalString> sColumnNames, SalArray<SalString> sColumnPrompts)
		{
            IDictionary<string, string> namedBindVariables = new Dictionary<string, string>();
            namedBindVariables.Add("colsSelectionObjectId", tblSelectionItems_colsSelectionObjectId.QualifiedBindName);
            namedBindVariables.Add("colsCompany", tblSelectionItems_colsCompany.QualifiedBindName);
            namedBindVariables.Add("i_sIsCodePart", this.QualifiedVarBindName("i_sIsCodePart"));
            namedBindVariables.Add("i_sCodePartDesc", this.QualifiedVarBindName("i_sCodePartDesc"));

            string stmt = @"{i_sIsCodePart} := &AO.Fin_Sel_Object_API.Get_Is_Code_Part( {colsSelectionObjectId} IN );
                            IF {i_sIsCodePart} = 'TRUE' THEN
                        	   {i_sCodePartDesc} := &AO.Fin_Sel_Object_API.Get_Description( {colsCompany} IN, {colsSelectionObjectId} IN );
                            END IF;";
		    DbPLSQLBlock(stmt, namedBindVariables);
		    if (this.i_sIsCodePart == "TRUE") 
		    {
			    sColumnPrompts[0] = this.i_sCodePartDesc;
		    }
		    return true;
		}
		#endregion
			
		#region Window Actions
			
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void tblSelectionItems_colsSelectionObjectId_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
					this.tblSelectionItems_colsSelectionObjectId_OnPM_DataItemValidate(sender, e);
					break;
			}
			#endregion
		}
			
		/// <summary>
		/// PM_DataItemValidate event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblSelectionItems_colsSelectionObjectId_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam)) 
			{
                if (Ifs.Fnd.ApplicationForms.Var.Cache.SessionRetrieve("ACCRUL_SELECTION_OBJECT=" + this.tblSelectionItems_colsSelectionObjectId.Text, ref this.sCacheValue)) 
				{
					this.bFoundInCache = true;
				}
				else
				{
					this.bFoundInCache = false;
					// Fetch data for all Selection Objects
					this.GetObjectDataFromDb();
				}
				if (!(this.bFoundInCache)) 
				{
                    if (Ifs.Fnd.ApplicationForms.Var.Cache.SessionRetrieve("ACCRUL_SELECTION_OBJECT=" + this.tblSelectionItems_colsSelectionObjectId.Text, ref this.sCacheValue)) 
					{
						this.bFoundInCache = true;
					}
				}
				if (this.bFoundInCache) 
				{
					this.TokenizeCacheValue(this.sCacheValue);
                    this.tblSelectionItems_colsDataTypeDb.Text = this.__sDataType;
                    this.tblSelectionItems_colsObjectViewName.Text = this.__sLovReference;
                    this.tblSelectionItems_colsObjectColId.Text = this.__sObjectColId;
                    this.tblSelectionItems_colsZoomWindow.Text = this.__sZoomWindow;
                    this.tblSelectionItems_colsZoomWindowColKey.Text = this.__sZoomWindowColKey;
                    this.tblSelectionItems_colsZoomWindowParentColKey.Text = this.__sZoomWindowParentColKey;
				}
				else
				{
                    this.tblSelectionItems_colsDataTypeDb.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                    this.tblSelectionItems_colsObjectViewName.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                    this.tblSelectionItems_colsObjectColId.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                    this.tblSelectionItems_colsZoomWindow.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                    this.tblSelectionItems_colsZoomWindowColKey.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
				}
                if (this.tblSelectionItems_colsObjectViewName.Text != Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
                    this.tblSelectionItems_colsFromValue.p_sLovReference = this.tblSelectionItems_colsObjectViewName.Text;
				}
				e.Return = Sys.VALIDATE_Ok;
				return;
			}
			e.Return = Sys.VALIDATE_Cancel;
			return;
			#endregion
		}
			
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void tblSelectionItems_colsOperator_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
					this.tblSelectionItems_colsOperator_OnPM_DataItemValidate(sender, e);
					break;
			}
			#endregion
		}
			
		/// <summary>
		/// PM_DataItemValidate event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblSelectionItems_colsOperator_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam)) 
			{
                this.tblSelectionItems_colsOperatorDb.Text = this.GetOperatorDb(this.tblSelectionItems_colsOperator.Text);
				this.RefreshValueItems();
				e.Return = Sys.VALIDATE_Ok;
				return;
			}
			e.Return = Sys.VALIDATE_Cancel;
			return;
			#endregion
		}
			
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void tblSelectionItems_colsFromValue_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
					this.tblSelectionItems_colsFromValue_OnPM_DataItemQueryEnabled(sender, e);
					break;
					
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
					this.tblSelectionItems_colsFromValue_OnPM_DataItemValidate(sender, e);
					break;
					
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLov:
					this.tblSelectionItems_colsFromValue_OnPM_DataItemLov(sender, e);
					break;
					
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom:
					this.tblSelectionItems_colsFromValue_OnPM_DataItemZoom(sender, e);
					break;
			}
			#endregion
		}
			
		/// <summary>
		/// PM_DataItemQueryEnabled event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblSelectionItems_colsFromValue_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
            if (!(this.IsEditable(this.tblSelectionItems_colsFromValue.i_hWndSelf))) 
			{
				e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
				return;
			}
			e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldEnabled;
			return;
			#endregion
		}
			
		/// <summary>
		/// PM_DataItemValidate event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblSelectionItems_colsFromValue_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam)) 
			{
                Sal.GetWindowText(this.tblSelectionItems_colsFromValue.i_hWndSelf, ref this.sValue, 50);
                if (this.tblSelectionItems_colsDataTypeDb.Text == "DATE") 
				{
                    if (!(Sal.IsNull(this.tblSelectionItems_colsFromValue.i_hWndSelf))) 
					{
                        if (!(Sal.IsValidDateTime(this.tblSelectionItems_colsFromValue.i_hWndSelf))) 
						{
							Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_SEL_TEMPL_InvalidDate, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.WARNING_Ok);
							e.Return = Sys.VALIDATE_Cancel;
							return;
						}
					}
                    this.tblSelectionItems_coldFromValueDate.DateTime = this.sValue.ToDate();
                    this.tblSelectionItems_coldFromValueDate.EditDataItemSetEdited();
                    Sal.GetWindowText(this.tblSelectionItems_coldFromValueDate, ref this.sValue, 50);
                    Sal.SetWindowText(this.tblSelectionItems_colsFromValue.i_hWndSelf, this.sValue);
				}
                else if (this.tblSelectionItems_colsDataTypeDb.Text == "NUMBER") 
				{
                    if (!(Sal.IsNull(this.tblSelectionItems_colsFromValue.i_hWndSelf))) 
					{
                        if (!(Sal.IsValidNumber(this.tblSelectionItems_colsFromValue.i_hWndSelf))) 
						{
							Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_SEL_TEMPL_InvalidNumber, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.WARNING_Ok);
							e.Return = Sys.VALIDATE_Cancel;
							return;
						}
					}
				}
				e.Return = Sys.VALIDATE_Ok;
				return;
			}
			e.Return = Sys.VALIDATE_Cancel;
			return;
			#endregion
		}
			
		/// <summary>
		/// PM_DataItemLov event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblSelectionItems_colsFromValue_OnPM_DataItemLov(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
            this.tblSelectionItems_colsFromValue.p_sLovReference = this.tblSelectionItems_colsObjectViewName.Text;
            if (this.tblSelectionItems_colsFromValue.p_sLovReference != SalString.Null) 
			{
                if (!(this.IsViewAvailable(this.tblSelectionItems_colsFromValue.p_sLovReference))) 
				{
					e.Return = false;
					return;
				}
			}
			e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemLov, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
			
		/// <summary>
		/// PM_DataItemZoom event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblSelectionItems_colsFromValue_OnPM_DataItemZoom(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
			{
                e.Return = this.Zoom(Sys.wParam, this.tblSelectionItems_colsFromValue.p_sLovReference, this.tblSelectionItems_colsFromValue.i_hWndSelf, this.tblSelectionItems_colsZoomWindow.Text, this.tblSelectionItems_colsZoomWindowColKey.Text, this.tblSelectionItems_colsZoomWindowParentColKey.Text);
				return;
			}
			else if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire) 
			{
                e.Return = this.Zoom(Sys.wParam, this.tblSelectionItems_colsFromValue.p_sLovReference, this.tblSelectionItems_colsFromValue.i_hWndSelf, this.tblSelectionItems_colsZoomWindow.Text, this.tblSelectionItems_colsZoomWindowColKey.Text, this.tblSelectionItems_colsZoomWindowParentColKey.Text);
				return;
			}
			e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
			
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void tblSelectionItems_colsToValue_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
					this.tblSelectionItems_colsToValue_OnPM_DataItemQueryEnabled(sender, e);
					break;
					
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
					this.tblSelectionItems_colsToValue_OnPM_DataItemValidate(sender, e);
					break;
					
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLov:
					this.tblSelectionItems_colsToValue_OnPM_DataItemLov(sender, e);
					break;
					
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom:
					this.tblSelectionItems_colsToValue_OnPM_DataItemZoom(sender, e);
					break;
			}
			#endregion
		}
			
		/// <summary>
		/// PM_DataItemQueryEnabled event handler.
		/// </summary>
		/// <param name="message"></param>
        private void tblSelectionItems_colsToValue_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (!(this.IsEditable(this.tblSelectionItems_colsToValue.i_hWndSelf))) 
			{
				e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
				return;
			}
			e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldEnabled;
			return;
			#endregion
		}
			
		/// <summary>
		/// PM_DataItemValidate event handler.
		/// </summary>
		/// <param name="message"></param>
        private void tblSelectionItems_colsToValue_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam)) 
			{
                Sal.GetWindowText(this.tblSelectionItems_colsToValue.i_hWndSelf, ref this.sValue, 50);
                if (this.tblSelectionItems_colsDataTypeDb.Text == "DATE") 
				{
                    if (!(Sal.IsNull(this.tblSelectionItems_colsToValue.i_hWndSelf))) 
					{
                        if (!(Sal.IsValidDateTime(this.tblSelectionItems_colsToValue.i_hWndSelf))) 
						{
							Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_SEL_TEMPL_InvalidDate, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.WARNING_Ok);
							e.Return = Sys.VALIDATE_Cancel;
							return;
						}
					}
                    this.tblSelectionItems_coldToValueDate.DateTime = this.sValue.ToDate();
                    this.tblSelectionItems_coldToValueDate.EditDataItemSetEdited();
                    Sal.GetWindowText(this.tblSelectionItems_coldToValueDate, ref this.sValue, 50);
                    Sal.SetWindowText(this.tblSelectionItems_colsToValue.i_hWndSelf, this.sValue);
				}
                else if (this.tblSelectionItems_colsDataTypeDb.Text == "NUMBER") 
				{
                    if (!(Sal.IsNull(this.tblSelectionItems_colsToValue.i_hWndSelf))) 
					{
                        if (!(Sal.IsValidNumber(this.tblSelectionItems_colsToValue.i_hWndSelf))) 
						{
							Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_SEL_TEMPL_InvalidNumber, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.WARNING_Ok);
							e.Return = Sys.VALIDATE_Cancel;
							return;
						}
					}
				}
				e.Return = Sys.VALIDATE_Ok;
				return;
			}
			e.Return = Sys.VALIDATE_Cancel;
			return;
			#endregion
		}
			
		/// <summary>
		/// PM_DataItemLov event handler.
		/// </summary>
		/// <param name="message"></param>
        private void tblSelectionItems_colsToValue_OnPM_DataItemLov(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
            this.tblSelectionItems_colsToValue.p_sLovReference = this.tblSelectionItems_colsObjectViewName.Text;
            if (this.tblSelectionItems_colsToValue.p_sLovReference != SalString.Null) 
			{
                if (!(this.IsViewAvailable(this.tblSelectionItems_colsToValue.p_sLovReference))) 
				{
					e.Return = false;
					return;
				}
			}
			e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemLov, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
			
		/// <summary>
		/// PM_DataItemZoom event handler.
		/// </summary>
		/// <param name="message"></param>
        private void tblSelectionItems_colsToValue_OnPM_DataItemZoom(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
			{
                e.Return = this.Zoom(Sys.wParam, this.tblSelectionItems_colsToValue.p_sLovReference, this.tblSelectionItems_colsToValue.i_hWndSelf, this.tblSelectionItems_colsZoomWindow.Text, this.tblSelectionItems_colsZoomWindowColKey.Text, this.tblSelectionItems_colsZoomWindowParentColKey.Text);
                e.Return = this.Zoom(Sys.wParam, this.tblSelectionItems_colsToValue.p_sLovReference, this.tblSelectionItems_colsToValue.i_hWndSelf, this.tblSelectionItems_colsZoomWindow.Text, this.tblSelectionItems_colsZoomWindowColKey.Text, this.tblSelectionItems_colsZoomWindowParentColKey.Text);
				return;
			}
			else if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire) 
			{
                e.Return = this.Zoom(Sys.wParam, this.tblSelectionItems_colsToValue.p_sLovReference, this.tblSelectionItems_colsToValue.i_hWndSelf, this.tblSelectionItems_colsZoomWindow.Text, this.tblSelectionItems_colsZoomWindowColKey.Text, this.tblSelectionItems_colsZoomWindowParentColKey.Text);
				return;
			}
			e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
			
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void tblSelectionItems_colsManualInput_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
					this.tblSelectionItems_colsManualInput_OnPM_DataItemQueryEnabled(sender, e);
					break;
			}
			#endregion
		}
			
		/// <summary>
		/// PM_DataItemQueryEnabled event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblSelectionItems_colsManualInput_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
            if (!(this.tblSelectionItems_colsOperatorDb.Text == "INCL" || this.tblSelectionItems_colsOperatorDb.Text == "EXCL")) 
			{
				e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
				return;
			}
			e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldEnabled;
			return;
			#endregion
		}
		#endregion
			
		#region Window Events

        private void tblSelectionItems_DataSourceReferenceItemsEvent(object sender, cDataSource.DataSourceReferenceItemsEventArgs e)
        {
            e.Handled = true;
            e.ReturnValue = this.DataSourceReferenceItems(e.sReference, e.sReturnKeyName, e.sColumnNames, e.sColumnPrompts);
        }

        private void tblSelectionItems_UserMethodEvent(object sender, cMethodManager.UserMethodEventArgs e)
        {
            e.Handled = true;
            e.ReturnValue = this.UserMethod(e.nWhat, e.sMethod);
        }
		#endregion
		
		#endregion
		
		#region Multiple Inheritance Late Bind Interface
		
		public interface LateBind
		{
			SalBoolean vrtDataRecordCheckModify(SalSqlHandle hSql);
			SalBoolean vrtDataRecordCheckNew(SalSqlHandle hSql);
			SalBoolean vrtDataRecordGetDefaults();
			SalBoolean vrtFrameStartupUser();
			SalNumber vrtUserMethod(SalNumber nWhat, SalString sMethod);
		}
		#endregion


	}
}
