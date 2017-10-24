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
//  140702  Nudilk  PRFI-1012, Merged Bug 117695,Modified code in cChildTableObjectSelection_OnSAM_FetchRowDone.
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
	public partial class cChildTableObjectSelection : cChildTableFinBase
	{
		#region Fields
		[ThreadStatic]
		public static SalString sValue;
		[ThreadStatic]
		public static SalString sAction;
		[ThreadStatic]
		public static SalString lsAttr;
		[ThreadStatic]
		public static SalBoolean bFoundInCache;
		[ThreadStatic]
		public static SalString sTempCache;
		[ThreadStatic]
		public static SalString sCacheValue;
		[ThreadStatic]
		public static SalString __sDataType;
		[ThreadStatic]
		public static SalString __sLovReference;
		[ThreadStatic]
		public static SalString __sZoomWindow;
		[ThreadStatic]
		public static SalString __sZoomWindowColKey;
		[ThreadStatic]
		public static SalString __sZoomWindowParentColKey;
		[ThreadStatic]
		public static SalString __sObjectColId;
		[ThreadStatic]
		public static SalString __sObjectColDesc;
		[ThreadStatic]
		public static SalString __sManualInput;
		[ThreadStatic]
		public static SalString __sDescription;

		#region Static Fields initialization
		[ThreadStatic]
		private static bool threadStaticsInitialized;

		internal static void InitThreadStaticFields()
		{
			if (!threadStaticsInitialized)
			{
				threadStaticsInitialized = true;
				sValue = "";
				sAction = "";
				lsAttr = "";
				bFoundInCache = false;
				sTempCache = "";
				sCacheValue = "";
				__sDataType = "";
				__sLovReference = "";
				__sZoomWindow = "";
				__sZoomWindowColKey = "";
				__sZoomWindowParentColKey = "";
				__sObjectColId = "";
				__sObjectColDesc = "";
				__sManualInput = "";
				__sDescription = "";
			}
		}
		#endregion

		public SalNumber i_nSelectionId = 0;
		public SalString i_sObjectGroupId = "";
		public SalString i_sObjectId = "";
		public SalString i_sCompany = "";
		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		public cChildTableObjectSelection()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
		}
		
		/// <summary>
		/// Multiple Inheritance: Constructor.
		/// </summary>
		/// <param name="derived"></param>
		public cChildTableObjectSelection(ISalWindow derived)
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
		/// <param name="nWhat"></param>
		/// <returns></returns>
		public virtual SalNumber SaveObjectSelection(SalNumber nWhat)
		{
			#region Local Variables
			SalNumber nRow = 0;
			SalSqlHandle hSql = SalSqlHandle.Null;
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire) 
				{
					return 1;
				}
				else if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
				{
					nRow = Sys.TBL_MinRow;
					DbTransactionBegin(ref hSql);
					while (Sal.TblFindNextRow(i_hWndSelf, ref nRow, ((Sys.ROW_New | Sys.ROW_Edited) | Sys.ROW_MarkDeleted), 0)) 
					{
						Sal.TblSetContext(i_hWndSelf, nRow);
						cChildTableObjectSelection.lsAttr = SalString.Null;
                        if (Sal.TblQueryRowFlags(i_hWndSelf, nRow, Sys.ROW_MarkDeleted)) 
						{
                            Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("COMPANY", colsCompany.Text, ref cChildTableObjectSelection.lsAttr);
                            Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("OBJECT_GROUP_ID", colsObjectGroupId.Text, ref cChildTableObjectSelection.lsAttr);
                            Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("OBJECT_ID", colsObjectId.Text, ref cChildTableObjectSelection.lsAttr);
                            Ifs.Fnd.ApplicationForms.Int.PalAttrAddNumber("SELECTION_ID", colnSelectionId.Number, ref cChildTableObjectSelection.lsAttr);
                            Ifs.Fnd.ApplicationForms.Int.PalAttrAddNumber("ITEM_ID", colnItemId.Number, ref cChildTableObjectSelection.lsAttr);
                            Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("VALUE_EXIST", colsValueExist.Text, ref cChildTableObjectSelection.lsAttr);
                            cChildTableObjectSelection.sAction = "REMOVE";
                        }
						else
						{
                            Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("COMPANY", colsCompany.Text, ref cChildTableObjectSelection.lsAttr);
                            Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("OBJECT_GROUP_ID", colsObjectGroupId.Text, ref cChildTableObjectSelection.lsAttr);
                            Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("OBJECT_ID", colsObjectId.Text, ref cChildTableObjectSelection.lsAttr);
                            Ifs.Fnd.ApplicationForms.Int.PalAttrAddNumber("SELECTION_ID", colnSelectionId.Number, ref cChildTableObjectSelection.lsAttr);
                            Ifs.Fnd.ApplicationForms.Int.PalAttrAddNumber("ITEM_ID", colnItemId.Number, ref cChildTableObjectSelection.lsAttr);
                            Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("SELECTION_OBJECT_ID", colsSelectionObjectId.Text, ref cChildTableObjectSelection.lsAttr);
                            Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("OPERATOR", colsOperator.Text, ref cChildTableObjectSelection.lsAttr);
                            Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("VALUE_FROM", colsFromValue.Text, ref cChildTableObjectSelection.lsAttr);
                            Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("VALUE_TO", colsToValue.Text, ref cChildTableObjectSelection.lsAttr);
                            if (this.colsDataTypeDb.Text == "DATE" || this.colsDataTypeDb.Text == "NUMBER")
                            {
                                if (this.colsFromValue.Text != SalString.Null)
                                {
                                    Sal.SendMsg(this.colsFromValue, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, 0, 0);
                                }
                                if (this.colsToValue.Text != SalString.Null)
                                {
                                    Sal.SendMsg(this.colsToValue, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, 0, 0);
                                }
                            }
                            Ifs.Fnd.ApplicationForms.Int.PalAttrAddNumber("VALUE_FROM_NUMBER", colnFromValue.Number, ref cChildTableObjectSelection.lsAttr);
                            Ifs.Fnd.ApplicationForms.Int.PalAttrAddNumber("VALUE_TO_NUMBER", colnToValue.Number, ref cChildTableObjectSelection.lsAttr);
                            Ifs.Fnd.ApplicationForms.Int.PalAttrAddDate("VALUE_FROM_DATE", coldFromValueDate.DateTime, ref cChildTableObjectSelection.lsAttr);
                            Ifs.Fnd.ApplicationForms.Int.PalAttrAddDate("VALUE_TO_DATE", coldToValueDate.DateTime, ref cChildTableObjectSelection.lsAttr);
                            Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("VALUE_EXIST", colsValueExist.Text, ref cChildTableObjectSelection.lsAttr);
                            Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("MANUAL_INPUT", colsManualInput.Text, ref cChildTableObjectSelection.lsAttr);
                            cChildTableObjectSelection.sAction = "MODIFY";
						}
						using(SignatureHints hints = SignatureHints.NewContext())
						{
							hints.Add("Fin_Object_Selection_API.Save_Temp_Selection__", System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.Input);
							if (!(DbPLSQLBlock(hSql, "&AO.Fin_Object_Selection_API.Save_Temp_Selection__( :cChildTableObjectSelection.lsAttr, :cChildTableObjectSelection.sAction )"))) 
							{
								DbTransactionClear(hSql);
								return 0;
							}
						}
						if (!(Sal.TblQueryRowFlags(i_hWndSelf, nRow, Sys.ROW_MarkDeleted))) 
						{
							if (Sal.TblQueryRowFlags(i_hWndSelf, nRow, Sys.ROW_New)) 
							{
								colnItemId.Number = Ifs.Fnd.ApplicationForms.Int.PalAttrGetNumber("ITEM_ID", cChildTableObjectSelection.lsAttr);
								__sObjid = Ifs.Fnd.ApplicationForms.Int.PalAttrGet("OBJID", cChildTableObjectSelection.lsAttr);
								__lsObjversion = Ifs.Fnd.ApplicationForms.Int.PalAttrGet("OBJVERSION", cChildTableObjectSelection.lsAttr);
								Sal.SetWindowText(__hWndObjid, __sObjid);
								Sal.SetWindowText(__hWndObjversion, __lsObjversion);
							}
							Sal.TblSetRowFlags(i_hWndSelf, nRow, (Sys.ROW_New | Sys.ROW_Edited), false);
						}
						_DataSourceStateSetDirty(false, Ifs.Fnd.ApplicationForms.Const.DATASOURCE_Query);
					}
					// Delete MarkDeleted rows
					nRow = Sys.TBL_MinRow;
					while (Sal.TblFindNextRow(i_hWndSelf, ref nRow, Sys.ROW_MarkDeleted, 0)) 
					{
						Sal.TblDeleteRow(i_hWndSelf, nRow, Sys.TBL_Adjust);
					}
					DbTransactionEnd(hSql);
					return 1;
				}
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public new SalBoolean DataRecordGetDefaults()
		{
			#region Local Variables
			SalString sObjectId = "";
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				colsObjectGroupId.Text = i_sObjectGroupId;
				colsObjectId.Text = i_sObjectId;
				colnSelectionId.Number = i_nSelectionId;
				colsObjectGroupId.EditDataItemSetEdited();
				colsObjectId.EditDataItemSetEdited();
				colnSelectionId.EditDataItemSetEdited();
				return true;
			}
			#endregion
		}
		
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
			using (new SalContext(this))
			{
				Sal.GetItemName(hWndCol, ref sName);
				if (sName == "colsFromValue") 
				{
					return colsOperatorDb.Text != "INCL" && colsOperatorDb.Text != "EXCL";
				}
				else if (sName == "colsToValue") 
				{
					return colsOperatorDb.Text == "BETWEEN" || colsOperatorDb.Text == "NOTBETWEEN";
				}
			}

			return false;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber RefreshValueItems()
		{
			#region Actions
			using (new SalContext(this))
			{
				if (colsFromValue.Text != Sys.STRING_Null) 
				{
					if (colsOperatorDb.Text == "INCL" || colsOperatorDb.Text == "EXCL") 
					{
						colsFromValue.Text = Sys.STRING_Null;
                        colnFromValue.Number = Sys.NUMBER_Null;
                        coldFromValueDate.DateTime = Sys.DATETIME_Null;
						colsFromValue.EditDataItemSetEdited();
                        colnFromValue.EditDataItemSetEdited();
                        coldFromValueDate.EditDataItemSetEdited();
                    }
				}
				if (colsToValue.Text != Sys.STRING_Null) 
				{
					if (colsOperatorDb.Text != "BETWEEN" && colsOperatorDb.Text != "NOTBETWEEN") 
					{
						colsToValue.Text = Sys.STRING_Null;
                        colnToValue.Number = Sys.NUMBER_Null;
                        coldToValueDate.DateTime = Sys.DATETIME_Null;
						colsToValue.EditDataItemSetEdited();
                        colnToValue.EditDataItemSetEdited();
                        coldToValueDate.EditDataItemSetEdited();
					}
				}
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean OneRowSelected()
		{
			#region Local Variables
			SalNumber nCurrentRow = 0;
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				if (Sal.TblAnyRows(this, Sys.ROW_Selected, (Sys.ROW_New | Sys.ROW_MarkDeleted))) 
				{
					nCurrentRow = Sys.TBL_MinRow;
					if (Sal.TblFindNextRow(this, ref nCurrentRow, Sys.ROW_Selected, 0)) 
					{
						return !(Sal.TblFindNextRow(this, ref nCurrentRow, Sys.ROW_Selected, 0));
					}
				}
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
			using (new SalContext(this))
			{
				nTo = sLovReference.Scan("(");
				if (nTo == -1) 
				{
					nTo = sLovReference.Length;
				}
				sView = sLovReference.Left(nTo);
				return Ifs.Fnd.ApplicationForms.Var.Security.IsViewAvailable(sView);
			}
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
			SalBoolean bReturn = false;
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				Ifs.Fnd.ApplicationForms.Var.g_Bind.Clear();
				lsStmt = "SELECT selection_object_id , data_type_db || '^' || lov_reference || '^' || zoom_window || '^' || zoom_window_col_key || '^' || zoom_window_parent_col_key || '^' || object_col_id || '^' || object_col_desc || '^' || manual_input_db || '^' ||" +
				" description\r\n" +
				"	 into :g_Bind.s[0], :g_Bind.s[1]\r\n" +
				"	FROM &AO.FIN_SEL_OBJECT_COMPANY\r\n" +
				"	WHERE company = '" + i_sCompany + "'\r\n" +
				"	AND object_group_id =  '" + i_sObjectGroupId + "'";
				bReturn = DbPrepareAndExecute(cSessionManager.c_hSql, lsStmt);
				while (DbFetchNext(cSessionManager.c_hSql, ref nDummy)) 
				{
					Ifs.Fnd.ApplicationForms.Var.Cache.SessionStore("PAYLED_SELECTION_OBJECT_GROUP=" + i_sObjectGroupId, "TRUE");
					Ifs.Fnd.ApplicationForms.Var.Cache.SessionStore("PAYLED_SELECTION_OBJECT=" + Ifs.Fnd.ApplicationForms.Var.g_Bind.s[0], Ifs.Fnd.ApplicationForms.Var.g_Bind.s[1]);
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
			#region Local Variables
			SalNumber nIndex = 0;
			SalArray<SalString> sCacheTokens = new SalArray<SalString>();
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				sCacheValue.Tokenize(Ifs.Fnd.ApplicationForms.Const.strNULL, "^", sCacheTokens);
				cChildTableObjectSelection.__sDataType = sCacheTokens[0];
				cChildTableObjectSelection.__sLovReference = sCacheTokens[1];
				cChildTableObjectSelection.__sZoomWindow = sCacheTokens[2];
				cChildTableObjectSelection.__sZoomWindowColKey = sCacheTokens[3];
				cChildTableObjectSelection.__sZoomWindowParentColKey = sCacheTokens[4];
				cChildTableObjectSelection.__sObjectColId = sCacheTokens[5];
				cChildTableObjectSelection.__sObjectColDesc = sCacheTokens[6];
				cChildTableObjectSelection.__sManualInput = sCacheTokens[7];
				cChildTableObjectSelection.__sDescription = sCacheTokens[8];
			}

			return "";
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber RefreshButtons()
		{
			#region Actions
			using (new SalContext(this))
			{
				this.vrtRefreshDialogButtons();
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean RefreshDialogButtons()
		{
			#region Actions
			using (new SalContext(this))
			{
				// has to be overiden by the derived objects
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
		private void cChildTableObjectSelection_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_FetchRowDone:
					this.cChildTableObjectSelection_OnSAM_FetchRowDone(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave:
					e.Handled = true;
					e.Return = this.SaveObjectSelection(Sys.wParam);
					return;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew:
					this.cChildTableObjectSelection_OnPM_DataRecordNew(sender, e);
					break;
				
				case Sys.SAM_RowHeaderClick:
					this.cChildTableObjectSelection_OnSAM_RowHeaderClick(sender, e);
					break;
				
				case Sys.SAM_RowHeaderDoubleClick:
					this.cChildTableObjectSelection_OnSAM_RowHeaderDoubleClick(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.AM_MethodStateChanged:
					e.Handled = true;
					this.vrtRefreshDialogButtons();
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.WM_KEYDOWN:
					this.cChildTableObjectSelection_OnWM_KEYDOWN(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_FetchRowDone event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cChildTableObjectSelection_OnSAM_FetchRowDone(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			Sal.SendClassMessage(Sys.SAM_FetchRowDone, Sys.wParam, Sys.lParam);
			if (this.colsDataTypeDb.Text == "DATE") 
			{
				Sal.GetWindowText(this.coldFromValueDate, ref cChildTableObjectSelection.sValue, 50);
				Sal.SetWindowText(this.colsFromValue, cChildTableObjectSelection.sValue);
				Sal.GetWindowText(this.coldToValueDate, ref cChildTableObjectSelection.sValue, 50);
				Sal.SetWindowText(this.colsToValue, cChildTableObjectSelection.sValue);
			}
            else if (this.colsDataTypeDb.Text == "NUMBER")
            {
                Sal.GetWindowText(this.colnFromValue, ref cChildTableObjectSelection.sValue, 50);
                Sal.SetWindowText(this.colsFromValue, cChildTableObjectSelection.sValue);
                Sal.GetWindowText(this.colnToValue, ref cChildTableObjectSelection.sValue, 50);
                Sal.SetWindowText(this.colsToValue, cChildTableObjectSelection.sValue);
                if (colsSelectionObjectId.Text == "REMINDER_LEVEL")
                {
                    colsFromValue.Number = colsFromValue.Number;
                    colsToValue.Number = colsToValue.Number;
                }
            }
            #endregion
		}
		
		/// <summary>
		/// PM_DataRecordNew event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cChildTableObjectSelection_OnPM_DataRecordNew(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew, Sys.wParam, Sys.lParam)) 
			{
				if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
				{
					if (!(Ifs.Fnd.ApplicationForms.Var.Cache.SessionRetrieve("PAYLED_SELECTION_OBJECT_GROUP=" + this.i_sObjectGroupId, ref cChildTableObjectSelection.sTempCache))) 
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
		/// SAM_RowHeaderClick event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cChildTableObjectSelection_OnSAM_RowHeaderClick(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			Sal.SendClassMessage(Sys.SAM_RowHeaderClick, Sys.wParam, Sys.lParam);
			this.RefreshButtons();
			#endregion
		}
		
		/// <summary>
		/// SAM_RowHeaderDoubleClick event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cChildTableObjectSelection_OnSAM_RowHeaderDoubleClick(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			Sal.SendClassMessage(Sys.SAM_RowHeaderDoubleClick, Sys.wParam, Sys.lParam);
			this.RefreshButtons();
			#endregion
		}
		
		/// <summary>
		/// WM_KEYDOWN event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cChildTableObjectSelection_OnWM_KEYDOWN(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			switch (Sys.wParam)
			{
				case Vis.VK_Insert:
					Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.WM_KEYDOWN, Vis.VK_Insert, 0);
					e.Return = false;
					return;
				
				case Vis.VK_Delete:
					Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.WM_KEYDOWN, Vis.VK_Delete, 0);
					e.Return = false;
					return;
				
				case Vis.VK_Right:
					Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.WM_KEYDOWN, Vis.VK_Right, 0);
					e.Return = false;
					return;
				
				case Vis.VK_Home:
				
				case Vis.VK_End:
				
				case Vis.VK_Down:
				
				case Vis.VK_Up:
					Sal.PostMsg(this, Ifs.Fnd.ApplicationForms.Const.AM_MethodStateChanged, 0, 0);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void colsSelectionObjectId_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
					this.colsSelectionObjectId_OnPM_DataItemValidate(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovDone:
					e.Handled = true;
					cObjectRelationManager.__bLOV = false;
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// PM_DataItemValidate event handler.
		/// </summary>
		/// <param name="message"></param>
		private void colsSelectionObjectId_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam)) 
			{
				if (Ifs.Fnd.ApplicationForms.Var.Cache.SessionRetrieve("PAYLED_SELECTION_OBJECT=" + this.colsSelectionObjectId.Text, ref cChildTableObjectSelection.sCacheValue)) 
				{
					cChildTableObjectSelection.bFoundInCache = true;
				}
				else
				{
					cChildTableObjectSelection.bFoundInCache = false;
					// Fetch data for all Selection Objects
					this.GetObjectDataFromDb();
				}
				if (!(cChildTableObjectSelection.bFoundInCache)) 
				{
					if (Ifs.Fnd.ApplicationForms.Var.Cache.SessionRetrieve("PAYLED_SELECTION_OBJECT=" + this.colsSelectionObjectId.Text, ref cChildTableObjectSelection.sCacheValue)) 
					{
						cChildTableObjectSelection.bFoundInCache = true;
					}
				}
				if (cChildTableObjectSelection.bFoundInCache) 
				{
					this.TokenizeCacheValue(cChildTableObjectSelection.sCacheValue);
					this.colsDataTypeDb.Text = cChildTableObjectSelection.__sDataType;
					this.colsObjectViewName.Text = cChildTableObjectSelection.__sLovReference;
					this.colsSelectionObjIdDesc.Text = cChildTableObjectSelection.__sDescription;
				}
				else
				{
					this.colsDataTypeDb.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
					this.colsObjectViewName.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
					this.colsSelectionObjIdDesc.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
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
		private void colsOperator_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
					this.colsOperator_OnPM_DataItemValidate(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// PM_DataItemValidate event handler.
		/// </summary>
		/// <param name="message"></param>
		private void colsOperator_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam)) 
			{
				Ifs.Fnd.ApplicationForms.Var.g_Bind.Clear();
				Ifs.Fnd.ApplicationForms.Var.g_Bind.s[0] = this.colsOperator.Text;
				using(SignatureHints hints = SignatureHints.NewContext())
				{
					hints.Add("Fin_Sel_Object_Operator_API.Encode", System.Data.ParameterDirection.Input);
					this.colsOperator.DbPLSQLBlock(cSessionManager.c_hSql, ":g_Bind.s[1] := &AO.Fin_Sel_Object_Operator_API.Encode( :g_Bind.s[0] )");
				}
				this.colsOperatorDb.Text = Ifs.Fnd.ApplicationForms.Var.g_Bind.s[1];
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
		private void colsFromValue_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_SetFocus:
					this.colsFromValue_OnSAM_SetFocus(sender, e);
					break;
				
				case Sys.SAM_AnyEdit:
					this.colsFromValue_OnSAM_AnyEdit(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
					this.colsFromValue_OnPM_DataItemQueryEnabled(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
					this.colsFromValue_OnPM_DataItemValidate(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLov:
					this.colsFromValue_OnPM_DataItemLov(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void colsFromValue_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.colsFromValue.p_sLovReference = this.colsObjectViewName.Text;
			Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.lParam, Sys.wParam);
			#endregion
		}
		
		/// <summary>
		/// SAM_AnyEdit event handler.
		/// </summary>
		/// <param name="message"></param>
		private void colsFromValue_OnSAM_AnyEdit(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			Sal.SendClassMessage(Sys.SAM_AnyEdit, Sys.wParam, Sys.lParam);
			this.RefreshButtons();
			#endregion
		}
		
		/// <summary>
		/// PM_DataItemQueryEnabled event handler.
		/// </summary>
		/// <param name="message"></param>
		private void colsFromValue_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (!(this.colsOperatorDb.Text != "INCL" && this.colsOperatorDb.Text != "EXCL")) 
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
		private void colsFromValue_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam)) 
			{
				Sal.GetWindowText(this.colsFromValue, ref cChildTableObjectSelection.sValue, 50);
				if (this.colsDataTypeDb.Text == "DATE") 
				{
					if (!(Sal.IsNull(this.colsFromValue))) 
					{
						if (!(Sal.IsValidDateTime(this.colsFromValue))) 
						{
							Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_SEL_TEMPL_InvalidDate, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.WARNING_Ok);
							e.Return = Sys.VALIDATE_Cancel;
							return;
						}
					}
					this.coldFromValueDate.DateTime = cChildTableObjectSelection.sValue.ToDate();
					this.coldFromValueDate.EditDataItemSetEdited();
					Sal.GetWindowText(this.coldFromValueDate, ref cChildTableObjectSelection.sValue, 50);
					Sal.SetWindowText(this.colsFromValue, cChildTableObjectSelection.sValue);
				}
				else if (this.colsDataTypeDb.Text == "NUMBER") 
				{
					if (!(Sal.IsNull(this.colsFromValue))) 
					{
						if (!(Sal.IsValidNumber(this.colsFromValue))) 
						{
							Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_SEL_TEMPL_InvalidNumber, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.WARNING_Ok);
							e.Return = Sys.VALIDATE_Cancel;
							return;
						}
                        this.colnFromValue.Number = cChildTableObjectSelection.sValue.ToNumber();
                        this.colnFromValue.EditDataItemSetEdited();
                        if (colsSelectionObjectId.Text != "REMINDER_LEVEL")
                        {
                            Sal.GetWindowText(this.colnFromValue, ref cChildTableObjectSelection.sValue, 50);
                            Sal.SetWindowText(this.colsFromValue, cChildTableObjectSelection.sValue);
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
		private void colsFromValue_OnPM_DataItemLov(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire) 
			{
				if (this.colsFromValue.p_sLovReference != SalString.Null) 
				{
					if (!(this.IsViewAvailable(this.colsFromValue.p_sLovReference))) 
					{
						e.Return = false;
						return;
					}
				}
			}
			e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemLov, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void colsToValue_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_SetFocus:
					this.colsToValue_OnSAM_SetFocus(sender, e);
					break;
				
				case Sys.SAM_AnyEdit:
					this.colsToValue_OnSAM_AnyEdit(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
					this.colsToValue_OnPM_DataItemQueryEnabled(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
					this.colsToValue_OnPM_DataItemValidate(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLov:
					this.colsToValue_OnPM_DataItemLov(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void colsToValue_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.colsToValue.p_sLovReference = this.colsObjectViewName.Text;
			Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.lParam, Sys.wParam);
			#endregion
		}
		
		/// <summary>
		/// SAM_AnyEdit event handler.
		/// </summary>
		/// <param name="message"></param>
		private void colsToValue_OnSAM_AnyEdit(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			Sal.SendClassMessage(Sys.SAM_AnyEdit, Sys.wParam, Sys.lParam);
			this.RefreshButtons();
			#endregion
		}
		
		/// <summary>
		/// PM_DataItemQueryEnabled event handler.
		/// </summary>
		/// <param name="message"></param>
		private void colsToValue_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (!(this.colsOperatorDb.Text == "BETWEEN" || this.colsOperatorDb.Text == "NOTBETWEEN")) 
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
		private void colsToValue_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam)) 
			{
				Sal.GetWindowText(this.colsToValue, ref cChildTableObjectSelection.sValue, 50);
				if (this.colsDataTypeDb.Text == "DATE") 
				{
					if (!(Sal.IsNull(this.colsToValue))) 
					{
						if (!(Sal.IsValidDateTime(this.colsToValue))) 
						{
							Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_SEL_TEMPL_InvalidDate, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.WARNING_Ok);
							e.Return = Sys.VALIDATE_Cancel;
							return;
						}
					}
					this.coldToValueDate.DateTime = cChildTableObjectSelection.sValue.ToDate();
					this.coldToValueDate.EditDataItemSetEdited();
					Sal.GetWindowText(this.coldToValueDate, ref cChildTableObjectSelection.sValue, 50);
					Sal.SetWindowText(this.colsToValue, cChildTableObjectSelection.sValue);
				}
				else if (this.colsDataTypeDb.Text == "NUMBER") 
				{
					if (!(Sal.IsNull(this.colsToValue))) 
					{
						if (!(Sal.IsValidNumber(this.colsToValue))) 
						{
							Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_SEL_TEMPL_InvalidNumber, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.WARNING_Ok);
							e.Return = Sys.VALIDATE_Cancel;
							return;
						}
                        this.colnToValue.Number = cChildTableObjectSelection.sValue.ToNumber();
                        this.colnToValue.EditDataItemSetEdited();
                        if (colsSelectionObjectId.Text != "REMINDER_LEVEL")
                        {
                            Sal.GetWindowText(this.colnToValue, ref cChildTableObjectSelection.sValue, 50);
                            Sal.SetWindowText(this.colsToValue, cChildTableObjectSelection.sValue);
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
		private void colsToValue_OnPM_DataItemLov(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire) 
			{
				if (this.colsToValue.p_sLovReference != SalString.Null) 
				{
					if (!(this.IsViewAvailable(this.colsToValue.p_sLovReference))) 
					{
						e.Return = false;
						return;
					}
				}
			}
			e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemLov, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void colsManualInput_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
					this.colsManualInput_OnPM_DataItemQueryEnabled(sender, e);
					break;
				
				case Sys.SAM_AnyEdit:
					this.colsManualInput_OnSAM_AnyEdit(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// PM_DataItemQueryEnabled event handler.
		/// </summary>
		/// <param name="message"></param>
		private void colsManualInput_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (!(this.colsOperatorDb.Text == "INCL" || this.colsOperatorDb.Text == "EXCL")) 
			{
				e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
				return;
			}
			e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldEnabled;
			return;
			#endregion
		}
		
		/// <summary>
		/// SAM_AnyEdit event handler.
		/// </summary>
		/// <param name="message"></param>
		private void colsManualInput_OnSAM_AnyEdit(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			Sal.SendClassMessage(Sys.SAM_AnyEdit, Sys.wParam, Sys.lParam);
			this.RefreshButtons();
			#endregion
		}
		#endregion
		
		#region Multiple Inheritance Operators
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cChildTableObjectSelection to type cTableManager.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cTableManager(cChildTableObjectSelection self)
		{
			return self._cTableManager;
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cChildTableObjectSelection to type cSessionManager.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cSessionManager(cChildTableObjectSelection self)
		{
			return ((cSessionManager)self._cTableManager);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cChildTableObjectSelection to type cWindowTranslation.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cWindowTranslation(cChildTableObjectSelection self)
		{
			return ((cWindowTranslation)self._cTableManager);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cChildTableObjectSelection to type cResize.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cResize(cChildTableObjectSelection self)
		{
			return self._cResize;
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cTableManager to type cChildTableObjectSelection.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cChildTableObjectSelection(cTableManager super)
		{
			return ((cChildTableObjectSelection)super._derived);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cSessionManager to type cChildTableObjectSelection.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cChildTableObjectSelection(cSessionManager super)
		{
			return ((cChildTableObjectSelection)((cTableManager)super._derived));
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cWindowTranslation to type cChildTableObjectSelection.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cChildTableObjectSelection(cWindowTranslation super)
		{
			return ((cChildTableObjectSelection)((cTableManager)super._derived));
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cResize to type cChildTableObjectSelection.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cChildTableObjectSelection(cResize super)
		{
			return ((cChildTableObjectSelection)((cTableManager)super._derived));
		}
		#endregion
		
		#region System Methods/Properties
		
		/// <summary>
		/// Returns the object instance associated with the window handle.
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public new static cChildTableObjectSelection FromHandle(SalWindowHandle handle)
		{
			return ((cChildTableObjectSelection)SalWindow.FromHandle(handle, typeof(cChildTableObjectSelection)));
		}
		#endregion
		
		#region Late Bind Methods
		
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
        /// <see cref="cChildTableObjectSelection.RefreshDialogButtons"/>
        /// </summary>
        [DisplayName("RefreshDialogButtons")]
        [CategoryAttribute("Accrul Late Bind Events")]
        [DescriptionAttribute("Occurs when the vrtRefreshDialogButtons method is called.")]
        public event EventHandler<FndReturnEventArgsSalBoolean> RefreshDialogButtonsEvent;

        /// <summary>
        /// Represents a method that will handle the RefreshDialogButtons event.
        /// </summary>
        public delegate void RefreshDialogButtonsEventHandler(object sender, FndReturnEventArgsSalBoolean e);
		
		/// <summary>
		/// Virtual wrapper replacement for late-bound (..) calls.
		/// </summary>
		public virtual SalBoolean vrtRefreshDialogButtons()
		{
			LateBind lateBind = (LateBind)this._derived;
			if (lateBind == null) 
			{
                if (RefreshDialogButtonsEvent != null)
                {
                    FndReturnEventArgsSalBoolean e = new FndReturnEventArgsSalBoolean();
                    RefreshDialogButtonsEvent(this, e);
                    if (e.Handled)
                        return e.ReturnValue;
                }
				return this.RefreshDialogButtons();
			}
			else
			{
				return lateBind.vrtRefreshDialogButtons();
			}
		}
		#endregion
		
		#region Multiple Inheritance Late Bind Interface
		
		public interface LateBind
		{
			SalBoolean vrtDataRecordGetDefaults();
			SalBoolean vrtRefreshDialogButtons();
		}
		#endregion
	}
}
