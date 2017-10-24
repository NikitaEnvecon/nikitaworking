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
// DATE        BY        NOTES
// YY-MM-DD
// 12-07-19    Hiralk    EDEL-1141, Added SelTemplSetValues().
// 14-04-20    Dihelk    PBFI-4119, Bug 113435, Merged.
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
	public partial class dlgReportSelTemplInfo : cDialogBox
	{
		#region Window Variables
		public SalString sObjectId = "";
		public SalWindowHandle hWndFocusField = SalWindowHandle.Null;
		public SalNumber nSelectionId = 0;
		public SalString sOldTemplate = "";
		public SalString sOperatorDbList = "";
		public SalArray<SalString> sOperatorDbValues = new SalArray<SalString>();
		public SalString sOperatorClientList = "";
		public SalArray<SalString> sOperatorClientValues = new SalArray<SalString>();
		public SalString lsSelectionInfo = "";
		public SalNumber nWidthParent = 0;
		public SalNumber nHeightParent = 0;
		public SalNumber nWidth = 0;
		public SalNumber nHeight = 0;
		public SalNumber nX = 0;
		public SalNumber nY = 0;
        private SalBoolean bIsFrameStartupUser;
		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		protected dlgReportSelTemplInfo()
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
		public static SalNumber ModalDialog(Control owner)
		{
			dlgReportSelTemplInfo dlg = DialogFactory.CreateInstance<dlgReportSelTemplInfo>();
			SalNumber ret = dlg.ShowDialog(owner);
			return ret;
		}
		
		/// <summary>
		/// Returns the object instance associated with the window handle.
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public new static dlgReportSelTemplInfo FromHandle(SalWindowHandle handle)
		{
			return ((dlgReportSelTemplInfo)SalWindow.FromHandle(handle, typeof(dlgReportSelTemplInfo)));
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
			#region Local Variables
			SalNumber nFocusRow = 0;
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				if (sMethod == "OK") 
				{
					return OkClicked(nWhat);
				}
				else if (sMethod == "Cancel") 
				{
					return CancelClicked(nWhat);
				}
				else if (sMethod == "List") 
				{
					if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire) 
					{
						// Return SalSendMsg(SalGetFocus(),PM_DataItemLov,METHOD_Inquire,0)
						return Sal.SendMsg(hWndFocusField, Ifs.Fnd.ApplicationForms.Const.PM_DataItemLov, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0);
					}
					if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
					{
						Sal.SendMsg(hWndFocusField, Ifs.Fnd.ApplicationForms.Const.PM_DataItemLov, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
						Sal.SendMsg(hWndFocusField, Sys.SAM_Validate, 0, 0);
						if (Sal.GetType(hWndFocusField) == Sys.TYPE_TableColumn) 
						{
							Sal.TblSetFocusCell(tblReportSelection, Sal.TblQueryContext(tblReportSelection), hWndFocusField, 0, -1);
						}
						else
						{
							Sal.SetFocus(hWndFocusField);
						}
					}
				}
				else if (sMethod == "IncludeExclude") 
				{
					return this.LaunchIncludeExclude(nWhat);
				}
				else if (sMethod == "Save") 
				{
					if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire) 
					{
						return Sal.TblAnyRows(tblReportSelection, ((Sys.ROW_New | Sys.ROW_Edited) | Sys.ROW_MarkDeleted), 0);
					}
					else if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
					{
						nFocusRow = Sal.TblQueryContext(tblReportSelection);
						Sal.SendMsg(tblReportSelection, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                        Sal.TblSetFocusRow(tblReportSelection, nFocusRow);
                        Sal.TblSetContext(tblReportSelection, nFocusRow);
                        Sal.TblSetRowFlags(tblReportSelection, nFocusRow, Sys.ROW_Selected, true);
						// Call SalSendMsg( tblReportSelection, PM_DataSourcePopulate, METHOD_Execute, 0 )
						RefreshPushbuttons();
					}
				}
				else if (sMethod == "New") 
				{
					if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire) 
					{
						if (Sal.IsNull(dfTemplateID)) 
						{
							return 0;
						}
						return Sal.SendMsg(tblReportSelection, Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0);
					}
					else if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
					{
						Sal.SendMsg(tblReportSelection, Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
					}
				}
				else if (sMethod == "Remove") 
				{
					if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire) 
					{
						return Sal.TblAnyRows(tblReportSelection, (Sys.ROW_Selected | Sys.ROW_New), 0);
					}
					else if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
					{
						Sal.SendMsg(tblReportSelection, Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
						RefreshPushbuttons();
					}
				}
				else if (sMethod == "CreateTempl") 
				{
					return CreateSelectionTemplate(nWhat);
				}
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public new SalBoolean FrameStartupUser()
		{
			#region Local Variables
			SalBoolean bRes = false;
			SalString sTempCompany = "";
			SalString sParameters = "";
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				sObjectId = SalString.FromHandle(Sal.SendMsg(i_hWndParent, Ifs.Fnd.ApplicationForms.Const.PM_QueryActionSendToParent, Const.QUERYACTION_GetObjectId, 0));
				Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
				sTempCompany = SalString.FromHandle(Sal.SendMsg(i_hWndParent, Ifs.Fnd.ApplicationForms.Const.PM_QueryActionSendToParent, Const.QUERYACTION_ParentCompany, 0));
				dfObjectGroupId.Text = SalString.FromHandle(Sal.SendMsg(i_hWndParent, Ifs.Fnd.ApplicationForms.Const.PM_QueryActionSendToParent, Const.QUERYACTION_GetObjectGroupId, 0));
				sParameters = SalString.FromHandle(Sal.SendMsg(i_hWndParent, Ifs.Fnd.ApplicationForms.Const.PM_QueryActionSendToParent, Const.QUERYACTION_GetDefParameters, 0));
				dfCompany.EditDataItemStateSet(Ifs.Fnd.ApplicationForms.Const.EDIT_New);
				dfObjectGroupId.EditDataItemStateSet(Ifs.Fnd.ApplicationForms.Const.EDIT_New);
				dfTemplateID.EditDataItemStateSet(Ifs.Fnd.ApplicationForms.Const.EDIT_New);
				dfCompany.Text = sTempCompany;
				tblReportSelection.i_sCompany = dfCompany.Text;
				tblReportSelection.i_sObjectGroupId = dfObjectGroupId.Text;
				tblReportSelection.i_sObjectId = sObjectId;
				dfCompany.EditDataItemSetEdited();
				dfObjectGroupId.EditDataItemSetEdited();
                nSelectionId = Ifs.Fnd.ApplicationForms.Int.PalAttrGetNumber("SELECTION_ID", sParameters);
				if (nSelectionId != 0 && nSelectionId != Sys.NUMBER_Null) 
				{
					dfTemplateID.Text = Ifs.Fnd.ApplicationForms.Int.PalAttrGet("TEMPLATE_ID", sParameters);
					sOldTemplate = dfTemplateID.Text;
					GetTemplateInfo();
					tblReportSelection.i_nSelectionId = nSelectionId;
					Sal.SendMsg(tblReportSelection, Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
					RefreshPushbuttons();
				}
				else
				{
					using(SignatureHints hints = SignatureHints.NewContext())
					{
						hints.Add("Fin_Sel_Obj_Templ_API.Get_User_Default_Template", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
						bRes = DbPLSQLBlock(cSessionManager.c_hSql, "DECLARE\r\n" +
							"	template_id_ VARCHAR2(20);\r\n" +
							"BEGIN\r\n" +
							"	template_id_ := &AO.Fin_Sel_Obj_Templ_API.Get_User_Default_Template(\r\n" +
							"					:i_hWndFrame.dlgReportSelTemplInfo.dfCompany,\r\n" +
							"					:i_hWndFrame.dlgReportSelTemplInfo.dfObjectGroupId );\r\n" +
							"	:i_hWndFrame.dlgReportSelTemplInfo.dfTemplateID := template_id_;\r\nEND; ");
					}
					if (bRes) 
					{
						dfTemplateID.EditDataItemSetEdited();
						if (dfTemplateID.Text != Sys.STRING_Null) 
						{
                            sOldTemplate = Sys.STRING_Null;
							Sal.SendMsg(dfTemplateID, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, 0, 0);
						}
						using(SignatureHints hints = SignatureHints.NewContext())
						{
							hints.Add("Fin_Sel_Object_Operator_API.Enumerate_Db", System.Data.ParameterDirection.Output);
							hints.Add("Fin_Sel_Object_Operator_API.Enumerate", System.Data.ParameterDirection.Output);
							DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN\r\n" +
								"				&AO.Fin_Sel_Object_Operator_API.Enumerate_Db(:i_hWndFrame.dlgReportSelTemplInfo.sOperatorDbList);\r\n" +
								"				&AO.Fin_Sel_Object_Operator_API.Enumerate(:i_hWndFrame.dlgReportSelTemplInfo.sOperatorClientList);\r\n			END;");
						}
						if (sOperatorDbList != Ifs.Fnd.ApplicationForms.Const.strNULL) 
						{
							sOperatorClientValues.SetUpperBound(1, -1);
							sOperatorDbValues.SetUpperBound(1, -1);
							sOperatorClientList.Tokenize(Ifs.Fnd.ApplicationForms.Const.strNULL, Ifs.Fnd.ApplicationForms.Var.g_sCHAR_US, sOperatorClientValues);
							sOperatorDbList.Tokenize(Ifs.Fnd.ApplicationForms.Const.strNULL, Ifs.Fnd.ApplicationForms.Var.g_sCHAR_US, sOperatorDbValues);
						}
						sOldTemplate = dfTemplateID.Text;
						RefreshPushbuttons();
						Sal.SetFocus(dfTemplateID);
					}
				}
                SelTemplSetValues();
                bIsFrameStartupUser = true;
				return true;
			}
			#endregion
		}

        /// <summary>
        /// SelTemplSetValues.
        /// </summary>
        /// <param name="message"></param>
        protected virtual void SelTemplSetValues()
        {
            #region Local Variables
            SalString sValues = "";
            SalString sCustomer = "";
            SalString sPayer = "";
            SalString sIsPayer = "";
            SalNumber nRow = 0;
            SalString sValueSet = "";
            #endregion

            #region Actions
            sValues = SalString.FromHandle(Sal.SendMsg(i_hWndParent, Ifs.Fnd.ApplicationForms.Const.PM_QueryActionSendToParent, Const.QUERYACTION_SetValues, 0));
            if (sValues != SalString.Null)
            {
                sIsPayer = Ifs.Fnd.ApplicationForms.Int.PalAttrGet("IS_PAYER", sValues);
                if (sIsPayer == "TRUE")
                {
                    sPayer = Ifs.Fnd.ApplicationForms.Int.PalAttrGet("PAYER", sValues);
                }
                else
                {
                    sCustomer = Ifs.Fnd.ApplicationForms.Int.PalAttrGet("CUSTOMER_ID", sValues);
                } 
                
                nRow = Sys.TBL_MinRow;
                while (Sal.TblFindNextRow(tblReportSelection, ref nRow, 0, 0))
                {
                    Sal.TblSetContext(tblReportSelection, nRow);
                    if (sCustomer != SalString.Null && tblReportSelection.colsSelectionObjectId.Text == "CUSTOMER_ID")
                    {
                        tblReportSelection.colsFromValue.Text = sCustomer;
                        sValueSet = "Customer";                        
                    }
                    else if (sPayer != SalString.Null && tblReportSelection.colsSelectionObjectId.Text == "PAYER")
                    {
                        tblReportSelection.colsFromValue.Text = sPayer;
                        sValueSet = "Payer";                        
                    }

                    if (sValueSet != SalString.Null)
                    {
                        tblReportSelection.colsFromValue.EditDataItemSetEdited();
                        tblReportSelection.colsOperatorDb.Text = "EQUAL";
                        tblReportSelection.colsOperatorDb.EditDataItemSetEdited();
                        tblReportSelection.colsOperator.SetText(this.GetOperatorClient("EQUAL"));
                        if (tblReportSelection.colsToValue.Text != SalString.Null)
                        {
                            tblReportSelection.colsToValue.Text = SalString.Null;
                            tblReportSelection.colsToValue.EditDataItemSetEdited();
                        }
                        if (tblReportSelection.colsValueExist.Text == "TRUE")
                        {
                            tblReportSelection.colsValueExist.Text = "FALSE";
                            tblReportSelection.colsValueExist.EditDataItemSetEdited();
                        }
                        if (tblReportSelection.colsManualInput.Text == "TRUE")
                        {
                            tblReportSelection.colsManualInput.Text = "FALSE";
                            tblReportSelection.colsManualInput.EditDataItemSetEdited();
                        }
                        break;
                    }
                }
                
            }
            #endregion
        }

		/// <summary>
		/// </summary>
		/// <param name="p_nWhat"></param>
		/// <returns></returns>
		public virtual SalBoolean OkClicked(SalNumber p_nWhat)
		{
			#region Actions
			using (new SalContext(this))
			{
				if (p_nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire) 
				{
					return true;
				}
				else if (p_nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
				{
					if (Sal.TblAnyRows(tblReportSelection, ((Sys.ROW_New | Sys.ROW_Edited) | Sys.ROW_MarkDeleted), 0)) 
					{
						if (Ifs.Fnd.ApplicationForms.Int.PalMessageBox(Properties.Resources.TEXT_SEL_TEMPL_SaveChanges, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Warning, Ifs.Fnd.ApplicationForms.Const.WARNING_YesNo) == Sys.IDYES) 
						{
							Sal.SendMsg(tblReportSelection, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
						}
					}
					Sal.EndDialog(this, Sys.IDCANCEL);
				}
				return true;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="p_nWhat"></param>
		/// <returns></returns>
		public virtual SalBoolean CancelClicked(SalNumber p_nWhat)
		{
			#region Actions
			using (new SalContext(this))
			{
				if (p_nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire) 
				{
					return true;
				}
				else if (p_nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
				{
					Sal.EndDialog(this, Sys.IDCANCEL);
				}
				return true;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber RefreshPushbuttons()
		{
			#region Actions
			using (new SalContext(this))
			{
				pbNew.MethodInvestigateState();
				pbRemove.MethodInvestigateState();
				pbSave.MethodInvestigateState();
				pbInclExcl.MethodInvestigateState();
				pbCreateTempl.MethodInvestigateState();
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean CopyDefaultTemplate()
		{
			#region Actions
			using (new SalContext(this))
			{
				using(SignatureHints hints = SignatureHints.NewContext())
				{
					hints.Add("Fin_Object_Selection_API.Copy_Selection_Template", System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
					if (!(DbPLSQLTransaction(cSessionManager.c_hSql, "&AO.Fin_Object_Selection_API.Copy_Selection_Template (\r\n" +
						"                                			:i_hWndFrame.dlgReportSelTemplInfo.nSelectionId,\r\n" +
						"					:i_hWndFrame.dlgReportSelTemplInfo.dfCompany,\r\n" +
						"					:i_hWndFrame.dlgReportSelTemplInfo.dfObjectGroupId,\r\n" +
						"                                			:i_hWndFrame.dlgReportSelTemplInfo.sObjectId,\r\n" +
						"                                			:i_hWndFrame.dlgReportSelTemplInfo.dfTemplateID)"))) 
					{
						nSelectionId = 0;
					}
				}
				Sal.SendMsg(i_hWndParent, Ifs.Fnd.ApplicationForms.Const.PM_QueryActionSendToParent, Const.QUERYACTION_SetSelectionId, nSelectionId);
				return true;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nWhat"></param>
		/// <returns></returns>
		public virtual SalNumber CreateSelectionTemplate(SalNumber nWhat)
		{
			#region Actions
			using (new SalContext(this))
			{
				switch (nWhat)
				{
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
						return Sal.TblAnyRows(tblReportSelection, 0, ((Sys.ROW_New | Sys.ROW_MarkDeleted) | Sys.ROW_Edited));
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
						dlgCreateSelectionTemplate.ModalDialog(Ifs.Fnd.ApplicationForms.Int.Explorer.ExplorerForm, dfCompany.Text, dfObjectGroupId.Text, sObjectId, nSelectionId);
						return 1;
				}
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public new SalNumber DataSourceInquireSave()
		{
			#region Actions
			using (new SalContext(this))
			{
				return Sys.IDNO;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber GetTemplateInfo()
		{
			#region Actions
			using (new SalContext(this))
			{
				using(SignatureHints hints = SignatureHints.NewContext())
				{
					hints.Add("Fin_Sel_Obj_Templ_API.Get_Description", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
					hints.Add("Fin_Sel_Obj_Templ_API.Get_Ownership", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
					hints.Add("Fin_Sel_Obj_Templ_API.Get_Owner", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
					DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN\r\n" +
						"		:i_hWndFrame.dlgReportSelTemplInfo.dfTemplateDescription := &AO.Fin_Sel_Obj_Templ_API.Get_Description( \r\n" +
						"					:i_hWndFrame.dlgReportSelTemplInfo.dfCompany,\r\n" +
						"					:i_hWndFrame.dlgReportSelTemplInfo.dfObjectGroupId,\r\n" +
						"					:i_hWndFrame.dlgReportSelTemplInfo.dfTemplateID );\r\n" +
						"		:i_hWndFrame.dlgReportSelTemplInfo.dfTemplateOwnership := &AO.Fin_Sel_Obj_Templ_API.Get_Ownership( \r\n" +
						"					:i_hWndFrame.dlgReportSelTemplInfo.dfCompany,\r\n" +
						"					:i_hWndFrame.dlgReportSelTemplInfo.dfObjectGroupId,\r\n" +
						"					:i_hWndFrame.dlgReportSelTemplInfo.dfTemplateID );\r\n" +
						"		:i_hWndFrame.dlgReportSelTemplInfo.dfTemplateOwner := &AO.Fin_Sel_Obj_Templ_API.Get_Owner( \r\n" +
						"					:i_hWndFrame.dlgReportSelTemplInfo.dfCompany,\r\n" +
						"					:i_hWndFrame.dlgReportSelTemplInfo.dfObjectGroupId,\r\n" +
						"					:i_hWndFrame.dlgReportSelTemplInfo.dfTemplateID );\r\n	END;");
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
		private void dlgReportSelTemplInfo_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Create:
					this.dlgReportSelTemplInfo_OnSAM_Create(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemEntered:
					this.dlgReportSelTemplInfo_OnPM_DataItemEntered(sender, e);
					break;
				
				case Const.PAM_GetSelectionInfo:
					this.dlgReportSelTemplInfo_OnPAM_GetSelectionInfo(sender, e);
					break;
				
				case Const.PAM_SelTemplSetFocusField:
					this.dlgReportSelTemplInfo_OnPAM_SelTemplSetFocusField(sender, e);
					break;
				
				case Const.PAM_SaveSelectionTemplate:
					e.Handled = true;
					e.Return = Sal.SendMsg(this.tblReportSelection, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
					return;
				
				case Const.PAM_ValidateSelectionTemplate:
					this.dlgReportSelTemplInfo_OnPAM_ValidateSelectionTemplate(sender, e);
					break;               
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_Create event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dlgReportSelTemplInfo_OnSAM_Create(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam);
			Sal.CenterWindow(this);
			#endregion
		}
		
		/// <summary>
		/// PM_DataItemEntered event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dlgReportSelTemplInfo_OnPM_DataItemEntered(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.hWndFocusField = Sys.wParam.ToWindowHandle();
			Sal.SendMsg(this.i_hWndParent, Ifs.Fnd.ApplicationForms.Const.PM_QueryActionSendToParent, Const.QUERYACTION_FocusField, Sys.wParam);
			#endregion
		}
		
		/// <summary>
		/// PAM_GetSelectionInfo event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dlgReportSelTemplInfo_OnPAM_GetSelectionInfo(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			Ifs.Fnd.ApplicationForms.Int.PalAttrAddNumber("SELECTION_ID", this.nSelectionId, ref this.lsSelectionInfo);
			Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("TEMPLATE_ID", this.dfTemplateID.Text, ref this.lsSelectionInfo);
			e.Return = this.lsSelectionInfo.ToHandle();
			return;
			#endregion
		}
		
		/// <summary>
		/// PAM_SelTemplSetFocusField event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dlgReportSelTemplInfo_OnPAM_SelTemplSetFocusField(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.hWndFocusField = Sys.wParam.ToWindowHandle();
			Sal.SetFocus(this.hWndFocusField);
			#endregion
		}
		
		/// <summary>
		/// PAM_ValidateSelectionTemplate event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dlgReportSelTemplInfo_OnPAM_ValidateSelectionTemplate(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.IsNull(this.dfTemplateID)) 
			{
				Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_SEL_TEMPL_EmptyTemplate, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
				e.Return = false;
				return;
			}
            else
            {
                if (this.sOldTemplate != this.dfTemplateID.Text)
                {
                    this.CopyDefaultTemplate();
                }
            }
			e.Return = true;
			return;
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void dfTemplateID_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_SetFocus:
					this.dfTemplateID_OnSAM_SetFocus(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
					this.dfTemplateID_OnPM_DataItemValidate(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovDone:
					e.Handled = true;
					// Set __bLOV = FALSE
					Sal.SendMsg(this.dfTemplateID.i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, 0, 0);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfTemplateID_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
			this.sOldTemplate = this.dfTemplateID.Text;
			#endregion
		}
		
		/// <summary>
		/// PM_DataItemValidate event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfTemplateID_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam)) 
			{
                if (!Sal.IsNull(dfTemplateID))
                {
                    using (SignatureHints hints = SignatureHints.NewContext())
                    {
                        hints.Add("Fin_Sel_Obj_Templ_API.Check_Template_Exists", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                        if (!(DbPLSQLTransaction(cSessionManager.c_hSql, "&AO.Fin_Sel_Obj_Templ_API.Check_Template_Exists (\r\n" +
                                                                               "		:i_hWndFrame.dlgReportSelTemplInfo.dfCompany,\r\n" +
                                                                               "   		:i_hWndFrame.dlgReportSelTemplInfo.dfObjectGroupId,\r\n" +
                                                                               "        :i_hWndFrame.dlgReportSelTemplInfo.dfTemplateID)")))
                        {
                            e.Return = Sys.VALIDATE_Cancel;
                            return;
                        }
                    }
                }

				if (this.sOldTemplate != this.dfTemplateID.Text) 
				{
					this.sOldTemplate = this.dfTemplateID.Text;
					this.GetTemplateInfo();
					this.CopyDefaultTemplate();
					this.tblReportSelection.i_nSelectionId = this.nSelectionId;
					Sal.SendMsg(this.tblReportSelection, Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
					this.RefreshPushbuttons();
                    if (bIsFrameStartupUser)
                    {
                        SelTemplSetValues();
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
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void tblReportSelection_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemEntered:
					e.Handled = true;
					Sal.SendMsg(Ifs.Fnd.ApplicationForms.Int.GetParent(this.tblReportSelection.i_hWndParent), Ifs.Fnd.ApplicationForms.Const.PM_QueryActionSendToParent, Const.QUERYACTION_FocusField, Sys.wParam);
					break;
				
				case Const.PAM_SelTemplSetFocusField:
					this.tblReportSelection_OnPAM_SelTemplSetFocusField(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew:
					this.tblReportSelection_OnPM_DataRecordNew(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// PAM_SelTemplSetFocusField event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblReportSelection_OnPAM_SelTemplSetFocusField(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.hWndFocusField = Sys.wParam.ToWindowHandle();
			Sal.TblSetFocusCell(this.tblReportSelection, Sal.TblQueryContext(this.tblReportSelection), this.hWndFocusField, 0, -1);
			#endregion
		}
		
		/// <summary>
		/// PM_DataRecordNew event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblReportSelection_OnPM_DataRecordNew(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew, Sys.wParam, Sys.lParam)) 
			{
                if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire)
                {
                    if (Sal.IsNull(this.dfTemplateID))
                    {
                        e.Return = false;
                        return;
                    }
                }
				if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
				{
					this.RefreshPushbuttons();
				}
				e.Return = true;
				return;
			}
			e.Return = false;
			return;
			#endregion
		}
		#endregion
		
		#region Late Bind Methods
		
		/// <summary>
		/// Virtual wrapper replacement for late-bound (..) calls.
		/// </summary>
		public override SalNumber vrtDataSourceInquireSave()
		{
			return this.DataSourceInquireSave();
		}
		
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

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalBoolean vrtDataSourceReferenceItems(SalString sReference, SalString sReturnKeyName, SalArray<SalString> sColumnNames, SalArray<SalString> sColumnPrompts)
        {
            return this.DataSourceReferenceItems(sReference, sReturnKeyName, sColumnNames, sColumnPrompts);
        }
		
		#region ChildTable-tblReportSelection
        
        #region Window Variables
        public SalString sIsCodePart = "";
        public SalString sCodePartDesc = "";
        public SalString sViewName = "";
        public SalString sColumnId = "";
        public SalString sColumnDesc = "";
        public SalString sUseCompany = "";
        #endregion

        #region Methods

        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <param name="sMethod"></param>
        /// <returns></returns>
        public virtual SalBoolean tblReportSelection_UserMethod(SalNumber nWhat, SalString sMethod)
        {
            if (sMethod == "IncludeExclude")
            {
                return this.LaunchIncludeExclude(nWhat);
            }
            return true;
        }

        /// <summary>
        /// </summary>
        /// <param name="sClientValue"></param>
        /// <returns></returns>
        public virtual SalString GetOperatorDb(SalString sClientValue)
        {
            SalNumber nIndex = Vis.ArrayFindString(this.sOperatorClientValues, sClientValue);
            if (nIndex != SalNumber.Null)
            { return this.sOperatorDbValues[nIndex]; }
            else
            { return Ifs.Fnd.ApplicationForms.Const.strNULL; }
        }

        /// <summary>
        /// </summary>
        /// <param name="sClientValue"></param>
        /// <returns></returns>
        public virtual SalString GetOperatorClient(SalString sDbValue)
        {
            using (new SalContext(this))
            {
                SalNumber nIndex = Vis.ArrayFindString(this.sOperatorDbValues, sDbValue);
                if (nIndex != SalNumber.Null)
                { return this.sOperatorClientValues[nIndex]; }
                else
                { return Ifs.Fnd.ApplicationForms.Const.strNULL; }
            }
           
        }

        //shhelk- Removed unnecessary RefreshDialogButtons() method during refactor since it's using the RefreshPushbuttons() method 
        
        /// <summary>
        /// </summary>
        /// <param name="sReference"></param>
        /// <param name="sReturnKeyName"></param>
        /// <param name="sColumnNames"></param>
        /// <param name="sColumnPrompts"></param>
        /// <returns></returns>
        public SalBoolean DataSourceReferenceItems(SalString sReference, SalString sReturnKeyName, SalArray<SalString> sColumnNames, SalArray<SalString> sColumnPrompts)
        {
            IDictionary<string, string> namedBindVariables = new Dictionary<string, string>();
            namedBindVariables.Add("SelectionObjectId", this.tblReportSelection.colsSelectionObjectId.QualifiedBindName);
            namedBindVariables.Add("Company",this.tblReportSelection.colsCompany.QualifiedBindName);
            namedBindVariables.Add("IsCodePart", this.QualifiedVarBindName("sIsCodePart"));
            namedBindVariables.Add("CodePartDesc", this.QualifiedVarBindName("sCodePartDesc"));

            string stmt = @"BEGIN
                        		{IsCodePart} := &AO.Fin_Sel_Object_API.Get_Is_Code_Part( {SelectionObjectId} IN );
                        		IF {IsCodePart} = 'TRUE' THEN
                        			{CodePartDesc} := &AO.Fin_Sel_Object_API.Get_Description( {Company} IN, {SelectionObjectId} IN);
                        		END IF;
                            END;";
            DbPLSQLBlock(stmt,namedBindVariables);

            if (sIsCodePart == "TRUE")
            { sColumnPrompts[0] = sCodePartDesc; }
            return true;
        }

        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalBoolean LaunchIncludeExclude(SalNumber nWhat)
        {

            switch (nWhat)
            {
                case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                    if (Sal.TblAnyRows(tblReportSelection, ((Sys.ROW_New | Sys.ROW_Edited) | Sys.ROW_MarkDeleted), 0))
                    {
                        return false;
                    }
                    if (!(tblReportSelection.IsViewAvailable(tblReportSelection.colsObjectViewName.Text)))
                    {
                        return false;
                    }
                    return tblReportSelection.OneRowSelected() && (tblReportSelection.colsOperatorDb.Text == "INCL" || tblReportSelection.colsOperatorDb.Text == "EXCL");

                case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                    IDictionary<string, string> namedBindVariables = new Dictionary<string, string>();
                    namedBindVariables.Add("ColumnId", this.QualifiedVarBindName("sColumnId"));
                    namedBindVariables.Add("SelectionObjectId", this.tblReportSelection.colsSelectionObjectId.QualifiedBindName);
                    namedBindVariables.Add("ColumnDesc", this.QualifiedVarBindName("sColumnDesc"));
                    namedBindVariables.Add("colsValueExist", this.tblReportSelection.colsValueExist.QualifiedBindName);
                    namedBindVariables.Add("colsCompany", this.tblReportSelection.colsCompany.QualifiedBindName);
                    namedBindVariables.Add("colsObjectGroupId", this.tblReportSelection.colsObjectGroupId.QualifiedBindName);
                    namedBindVariables.Add("colsObjectId", this.tblReportSelection.colsObjectId.QualifiedBindName);
                    namedBindVariables.Add("colnSelectionId", this.tblReportSelection.colnSelectionId.QualifiedBindName);
                    namedBindVariables.Add("colnItemId", this.tblReportSelection.colnItemId.QualifiedBindName);

                    if (tblReportSelection.colsManualInput.Text == "TRUE")
                    {
                        DbPLSQLBlock(@"BEGIN
                                        {ColumnId}   := &AO.Fin_Sel_Object_API.Get_Object_Col_Id ( {SelectionObjectId} IN );
                                        {ColumnDesc} := &AO.Fin_Sel_Object_API.Get_Object_Col_Desc ( {SelectionObjectId} IN );
                                        END",namedBindVariables);
                            
                        sViewName = tblReportSelection.colsObjectViewName.Text;
                        sUseCompany = "FALSE";
                        if (sViewName.Scan("(COMPANY)") != -1)
                        {
                            sViewName = sViewName.Left(sViewName.Scan("(COMPANY)"));
                            sUseCompany = "TRUE";
                        }
                        if (dlgRepSelectionInclExclAdv.ModalDialog(Sys.hWndForm, tblReportSelection.colsCompany.Text, tblReportSelection.colsObjectGroupId.Text, tblReportSelection.colsObjectId.Text, tblReportSelection.colnSelectionId.Number, tblReportSelection.colnItemId.Number, sViewName, sColumnId, sColumnDesc, sUseCompany) == Sys.IDOK)
                        {    
                            DbPLSQLBlock( @"{colsValueExist} := &AO.Fin_Obj_Selection_Values_API.Is_Value_Exist ({colsCompany} IN,
                                                                                                                 {colsObjectGroupId} IN,
                                                                                                                 {colsObjectId} IN,
                                                                                                                 {colnSelectionId} IN,
                                                                                                                 {colnItemId} IN );",namedBindVariables); 
                            return true;
                        }
                    }
                    else
                    {
                        if (dlgRepSelectIncludeExclude.ModalDialog(Ifs.Fnd.ApplicationForms.Int.Explorer.ExplorerForm, tblReportSelection.colsCompany.Text, tblReportSelection.colsObjectGroupId.Text, tblReportSelection.colsObjectId.Text, tblReportSelection.colnSelectionId.Number, tblReportSelection.colnItemId.Number, tblReportSelection.colsSelectionObjectId.Text) == Sys.IDOK)
                        {
                            DbPLSQLBlock(@"{colsValueExist} := &AO.Fin_Obj_Selection_Values_API.Is_Value_Exist ({colsCompany} IN,
                                                                                                                {colsObjectGroupId} IN,
                                                                                                                {colsObjectId} IN,
                                                                                                                {colnSelectionId} IN,
                                                                                                                {colnItemId} IN );", namedBindVariables);
                            return true;
                        }
                    }
                    return true;
            }
            return false;
        }

        #endregion

        #region Window Events

        private void tblReportSelection_UserMethodEvent(object sender, cMethodManager.UserMethodEventArgs e)
        {
            e.Handled = true;
            e.ReturnValue = tblReportSelection_UserMethod(e.nWhat, e.sMethod);
        }

        private void tblReportSelection_RefreshDialogButtonsEvent(object sender, FndReturnEventArgsSalBoolean e)
        {
            e.Handled = true;
            e.ReturnValue = this.RefreshPushbuttons();
        }
        #endregion

        #endregion
    }
}
