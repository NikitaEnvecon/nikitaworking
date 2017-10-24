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
	/// <param name="p_sTemplateId"></param>
	/// <param name="p_nItemId"></param>
	/// <param name="p_sObjectId"></param>
	public partial class dlgSelectionIncludeExclude : cDialogBox
	{
		#region Window Parameters
		public SalString p_sCompany;
		public SalString p_sObjectGroupId;
		public SalString p_sTemplateId;
		public SalNumber p_nItemId;
		public SalString p_sObjectId;
		#endregion
		
		#region Window Variables
		public SalString sViewName = "";
		public SalString sColumnId = "";
		public SalString sColumnDesc = "";
		public SalString sValue = "";
		public SalString sValueId = "";
		public SalArray<SalString> sValues = new SalArray<SalString>();
		public SalString sUseCompany = "";
		public SalString sManualMode = "";
		public SalString lsValueStr = "";
		public SalArray<SalNumber> nVisibles = new SalArray<SalNumber>();
		public SalNumber nVisible = 0;
		public SalNumber nCount = 0;
		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		protected dlgSelectionIncludeExclude()
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
		public static SalNumber ModalDialog(Control owner, SalString p_sCompany, SalString p_sObjectGroupId, SalString p_sTemplateId, SalNumber p_nItemId, SalString p_sObjectId)
		{
			dlgSelectionIncludeExclude dlg = DialogFactory.CreateInstance<dlgSelectionIncludeExclude>();
			dlg.p_sCompany = p_sCompany;
			dlg.p_sObjectGroupId = p_sObjectGroupId;
			dlg.p_sTemplateId = p_sTemplateId;
			dlg.p_nItemId = p_nItemId;
			dlg.p_sObjectId = p_sObjectId;
			SalNumber ret = dlg.ShowDialog(owner);
			return ret;
		}
		
		/// <summary>
		/// Returns the object instance associated with the window handle.
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public new static dlgSelectionIncludeExclude FromHandle(SalWindowHandle handle)
		{
			return ((dlgSelectionIncludeExclude)SalWindow.FromHandle(handle, typeof(dlgSelectionIncludeExclude)));
		}
		#endregion
		
		#region Methods
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber FetchColumns()
		{
			#region Local Variables
			SalString sSql = "";
			SalNumber nInd = 0;
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				Sal.WaitCursor(true);
				using(SignatureHints hints = SignatureHints.NewContext())
				{
					hints.Add("Fin_Sel_Object_API.Get_Lov_Reference", System.Data.ParameterDirection.Input);
					hints.Add("Fin_Sel_Object_API.Get_Object_Col_Id", System.Data.ParameterDirection.Input);
					hints.Add("Fin_Sel_Object_API.Get_Object_Col_Desc", System.Data.ParameterDirection.Input);
					hints.Add("Fin_Sel_Obj_Templ_Det_API.Get_Manual_Input_Db", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
					DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN \r\n" +
						"				:i_hWndFrame.dlgSelectionIncludeExclude.sViewName := &AO.Fin_Sel_Object_API.Get_Lov_Reference (\r\n" +
						"					:i_hWndFrame.dlgSelectionIncludeExclude.p_sObjectId );\r\n" +
						"	\r\n" +
						"				:i_hWndFrame.dlgSelectionIncludeExclude.sColumnId := &AO.Fin_Sel_Object_API.Get_Object_Col_Id (\r\n" +
						"					:i_hWndFrame.dlgSelectionIncludeExclude.p_sObjectId );\r\n" +
						"	\r\n" +
						"				:i_hWndFrame.dlgSelectionIncludeExclude.sColumnDesc := &AO.Fin_Sel_Object_API.Get_Object_Col_Desc (\r\n" +
						"					:i_hWndFrame.dlgSelectionIncludeExclude.p_sObjectId ); \r\n" +
						"\r\n" +
						"				:i_hWndFrame.dlgSelectionIncludeExclude.sManualMode := &AO.Fin_Sel_Obj_Templ_Det_API.Get_Manual_Input_Db (\r\n" +
						"					:i_hWndFrame.dlgSelectionIncludeExclude.p_sCompany, \r\n" +
						"					:i_hWndFrame.dlgSelectionIncludeExclude.p_sObjectGroupId, \r\n" +
						"					:i_hWndFrame.dlgSelectionIncludeExclude.p_sTemplateId, \r\n" +
						"					:i_hWndFrame.dlgSelectionIncludeExclude.p_nItemId );	\r\n			END;");
				}
				sUseCompany = "FALSE";
				if (sViewName.Scan("(COMPANY)") != -1) 
				{
					sViewName = sViewName.Left(sViewName.Scan("(COMPANY)"));
					sUseCompany = "TRUE";
				}
				nCount = 0;
				if (sManualMode != "TRUE") 
				{
					sSql = "select " + sColumnId + ", " + sColumnId;
					if (sColumnDesc != SalString.Null) 
					{
						sSql = sSql + " || '   '  || " + sColumnDesc;
					}
					sSql = sSql + " , &AO.Fin_Sel_Templ_Values_API.Is_Value_Exist( " + ":i_hWndFrame.dlgSelectionIncludeExclude.p_sCompany, " + ":i_hWndFrame.dlgSelectionIncludeExclude.p_sObjectGroupId, " + ":i_hWndFrame.dlgSelectionIncludeExclude.p_sTemplateId, " + 
					":i_hWndFrame.dlgSelectionIncludeExclude.p_nItemId, " + sColumnId + ") " + " into :i_hWndFrame.dlgSelectionIncludeExclude.sValueId, " + "       :i_hWndFrame.dlgSelectionIncludeExclude.sValue, " + "       :i_hWndFrame.dlgSelectionIncludeExclude.nVisible " + 
					" from &AO." + sViewName;
					if (sUseCompany == "TRUE") 
					{
						sSql = sSql + " where COMPANY = :i_hWndFrame.dlgSelectionIncludeExclude.p_sCompany";
					}
					sSql = sSql + " order by 1";
					nCount = 0;
					if (DbPrepareAndExecute(cSessionManager.c_hSql, sSql)) 
					{
						while (DbFetchNext(cSessionManager.c_hSql, ref nInd)) 
						{
							lbCols.Insert(-1, sValue, nVisible);
							nVisibles[nCount] = nVisible;
							sValues[nCount] = sValueId;
							nCount = nCount + 1;
						}
					}
					Sal.WaitCursor(false);
					if (nCount == 0) 
					{
						Sal.EndDialog(this, 0);
						// Call AlertBox(  TEXT_RmbInformation, CAPTION_Information, MB_Ok )
						// Bug # 22141 End
					}
				}
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean UpdateChanges()
		{
			#region Local Variables
			SalNumber a = 0;
			SalNumber nIndex = 0;
			SalArray<SalString> lsValues = new SalArray<SalString>();
			SalSqlHandle hSql = SalSqlHandle.Null;
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				if (nCount) 
				{
					Sal.WaitCursor(true);
					a = 0;
					nIndex = 0;
					lsValueStr = SalString.Null;
					lsValues.SetUpperBound(1, -1);
					while (a < nCount) 
					{
						nVisible = Sal.ListQueryState(lbCols, a);
						sValue = sValues[a];
						if (nVisible != nVisibles[a]) 
						{
							if ((lsValues[nIndex] + sValue + nVisible.ToString(0) + "^").Length > 32000) 
							{
								nIndex = nIndex + 1;
							}
							lsValues[nIndex] = lsValues[nIndex] + sValue + nVisible.ToString(0) + "^";
							nVisibles[a] = nVisible;
						}
						a = a + 1;
					}
					if (!(lsValues.IsEmpty)) 
					{
						a = 0;
						DbTransactionBegin(ref hSql);
						while (a <= nIndex) 
						{
							lsValueStr = lsValues[a];
							using(SignatureHints hints = SignatureHints.NewContext())
							{
								hints.Add("Fin_Sel_Templ_Values_API.Insert_Values", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
								if (!(DbPLSQLBlock(hSql, "&AO.Fin_Sel_Templ_Values_API.Insert_Values (\r\n" +
									"			:i_hWndFrame.dlgSelectionIncludeExclude.p_sCompany, \r\n" +
									"			:i_hWndFrame.dlgSelectionIncludeExclude.p_sObjectGroupId, \r\n" +
									"			:i_hWndFrame.dlgSelectionIncludeExclude.p_sTemplateId, \r\n" +
									"			:i_hWndFrame.dlgSelectionIncludeExclude.p_nItemId, \r\n" +
									"			:i_hWndFrame.dlgSelectionIncludeExclude.lsValueStr )"))) 
								{
									Sal.WaitCursor(false);
									DbTransactionClear(hSql);
									return false;
								}
							}
							a = a + 1;
						}
						DbTransactionEnd(hSql);
					}
					Sal.WaitCursor(false);
				}
				return true;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber OkPressed()
		{
			#region Actions
			using (new SalContext(this))
			{
				UpdateChanges();
				Sal.EndDialog(this, Sys.IDOK);
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber CancelPressed()
		{
			#region Actions
			using (new SalContext(this))
			{
				Sal.EndDialog(this, Sys.IDCANCEL);
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber SavePressed()
		{
			#region Actions
			using (new SalContext(this))
			{
				UpdateChanges();
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber ManualPressed()
		{
			#region Actions
			using (new SalContext(this))
			{
				UpdateChanges();
				dlgSelectionInclExclAdv.ModalDialog(this, p_sCompany, p_sObjectGroupId, p_sTemplateId, p_nItemId, sViewName, sColumnId, sColumnDesc, sUseCompany);
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
		private void dlgSelectionIncludeExclude_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Create:
					this.dlgSelectionIncludeExclude_OnSAM_Create(sender, e);
					break;
				
				case Sys.SAM_CreateComplete:
					this.dlgSelectionIncludeExclude_OnSAM_CreateComplete(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_Create event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dlgSelectionIncludeExclude_OnSAM_Create(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam);
			Sal.CenterWindow(this);
			this.FetchColumns();
			#endregion
		}
		
		/// <summary>
		/// SAM_CreateComplete event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dlgSelectionIncludeExclude_OnSAM_CreateComplete(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam);
			if (this.sManualMode == "TRUE") 
			{
				this.ManualPressed();
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
					e.Handled = true;
					this.OkPressed();
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
				case Sys.SAM_Click:
					e.Handled = true;
					this.CancelPressed();
					break;
			}
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
					e.Handled = true;
					this.SavePressed();
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void pbManual_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Click:
					e.Handled = true;
					this.ManualPressed();
					break;
			}
			#endregion
		}
		#endregion
	}
}
