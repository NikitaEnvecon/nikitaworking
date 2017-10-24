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
/*  Date    Sign    History
   140725   THPELK  PRFI-264, LCS Merge(Bug 105417) - Modified Unpack_Check_Update___().
*/

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
	/// <param name="nVoucherNo"></param>
	/// <param name="sVoucherType"></param>
	/// <param name="nAccountingYear"></param>
	/// <param name="nAppVou"></param>
	public partial class dlgInstantUpdate : cDialogBoxFin
	{
		#region Window Parameters
		public SalString sCompany;
		public SalArray<SalNumber> nVoucherNo;
		public SalArray<SalString> sVoucherType;
		public SalArray<SalNumber> nAccountingYear;
		public SalNumber nAppVou;
		#endregion
		
		#region Window Variables
		public SalNumber nJouNo = 0;
		public SalString sVoucherNumb = "";
		public SalNumber nMinPeriod = 0;
		public SalNumber nMaxPeriod = 0;
		public SalNumber nMinYear = 0;
		public SalNumber nMaxYear = 0;
		public SalString sMinType = "";
		public SalString sMaxType = "";
		public SalString sMinUser = "";
		public SalString sMaxUser = "";
		public SalBoolean bAutoUpdate = false;
		public SalArray<SalString> sPreYearArr = new SalArray<SalString>();
		public SalArray<SalNumber> nYear = new SalArray<SalNumber>();
		public SalNumber nTokens = 0;
		public SalString sPreYear = "";
		public SalString lsMsg = "";
		public SalNumber nDummy = 0;
		public SalNumber nSeqNo = 0;
        public SalNumber nErrorCount = 0;
		public SalString sPrintJournal = "";
		public SalString sDetJournal = "";
        public SalString sPostToQueue = "";
		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		protected dlgInstantUpdate()
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
		public static SalNumber ModalDialog(Control owner, SalString sCompany, SalArray<SalNumber> nVoucherNo, SalArray<SalString> sVoucherType, SalArray<SalNumber> nAccountingYear, SalNumber nAppVou)
		{
			dlgInstantUpdate dlg = DialogFactory.CreateInstance<dlgInstantUpdate>();
			dlg.sCompany = sCompany;
			dlg.nVoucherNo = nVoucherNo;
			dlg.sVoucherType = sVoucherType;
			dlg.nAccountingYear = nAccountingYear;
			dlg.nAppVou = nAppVou;
			SalNumber ret = dlg.ShowDialog(owner);
			return ret;
		}
		
		/// <summary>
		/// Returns the object instance associated with the window handle.
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public new static dlgInstantUpdate FromHandle(SalWindowHandle handle)
		{
			return ((dlgInstantUpdate)SalWindow.FromHandle(handle, typeof(dlgInstantUpdate)));
		}
		#endregion
		
		#region Methods
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public new SalBoolean FrameStartupUser()
		{
			#region Local Variables
			SalNumber nRowNum = 0;
			SalNumber nRowType = 0;
			SalString lsVouWhere = "";
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				cbAutoPopulate.EditDataItemStateSet(Ifs.Fnd.ApplicationForms.Const.EDIT_Changed);
                                                   
                if (!(DbPLSQLBlock(cSessionManager.c_hSql, " :i_hWndFrame.dlgInstantUpdate.sPostToQueue := &AO.ACCRUL_ATTRIBUTE_API.Get_Attribute_Value('GL_UPDATE_BATCH_QUEUE')")))
                {
                    return false;
                }
                
                if (sPostToQueue == "TRUE")
                {
                    Sal.DisableWindowAndLabel(cbAutoUpdate);
                }

				if (AutoPopulate()) 
				{
					cbAutoPopulate.Checked = true;
					Sal.SendMsg(tblInstVouUpdate, Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
					Sal.TblClearSelection(tblInstVouUpdate);
					while (nAppVou > 0) 
					{
						nRowType = Vis.TblFindString(tblInstVouUpdate, 0, tblInstVouUpdate_colsVoucherType, sVoucherType[nAppVou - 1]);
						while (tblInstVouUpdate_colsVoucherType.Text != sVoucherType[nAppVou - 1]) 
						{
							nRowType = Vis.TblFindString(tblInstVouUpdate, nRowType + 1, tblInstVouUpdate_colsVoucherType, sVoucherType[nAppVou - 1]);
						}
						nRowNum = Vis.TblFindNumber(tblInstVouUpdate, nRowType, tblInstVouUpdate_colnVoucherNo, nVoucherNo[nAppVou - 1]);
						nRowNum = Vis.TblFindNumber(tblInstVouUpdate, nRowNum, tblInstVouUpdate_colnAccountingYear, nAccountingYear[nAppVou - 1]);
						if (nRowNum > -1) 
						{
							Sal.TblSetFocusRow(tblInstVouUpdate, nRowNum);
							Sal.TblSetContext(tblInstVouUpdate, nRowNum);
							Sal.TblSetRowFlags(tblInstVouUpdate, nRowNum, Sys.ROW_Selected, true);
						}
						nAppVou = nAppVou - 1;
					}
					Sal.TblScroll(tblInstVouUpdate, nRowNum, Sys.hWndNULL, Sys.TBL_AutoScroll);
				}
				else
				{
					cbAutoPopulate.Checked = false;
					lsVouWhere = GetWhereClause();
					Sal.SendMsg(tblInstVouUpdate, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceUserWhere, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, lsVouWhere.ToHandle());
					Sal.SendMsg(tblInstVouUpdate, Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                    pbUpdate.MethodInvestigateState();
					return true;
				}
                pbUpdate.MethodInvestigateState();
				return false;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="p_nWhat"></param>
		/// <param name="sMethod"></param>
		/// <returns></returns>
		public new SalNumber UserMethod(SalNumber p_nWhat, SalString sMethod)
		{
			#region Actions
			using (new SalContext(this))
			{
				if (sMethod == "MyOK") 
				{
					return DoInstantUpdate(p_nWhat);
				}
				else if (sMethod == "MyCancel") 
				{
					if (p_nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
					{
						Sal.EndDialog(this, 0);
					}
					else
					{
						return true;
					}
				}
				else if (sMethod == "MyQuery") 
				{
					return QueryVouchers(p_nWhat);
				}
				else
				{
					return false;
				}
			}

			return false;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean PreYearPossible()
		{
			#region Actions
			using (new SalContext(this))
			{
				using(SignatureHints hints = SignatureHints.NewContext())
				{
					hints.Add("GEN_LED_VOUCHER_API.Get_Preliminary_Acc_Year_", System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
					if (!(DbPLSQLBlock(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "GEN_LED_VOUCHER_API.Get_Preliminary_Acc_Year_\r\n" +
						"( :i_hWndFrame.dlgInstantUpdate.sPreYear, :i_hWndFrame.dlgInstantUpdate.i_sCompany, :i_hWndFrame.dlgInstantUpdate.nJouNo)"))) 
					{
						return false;
					}
				}
				nTokens = sPreYear.Tokenize(" ", ",", sPreYearArr);
				if (nTokens > 1) 
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nWhat"></param>
		/// <returns></returns>
		public virtual SalNumber DoInstantUpdate(SalNumber nWhat)
		{
			#region Local Variables
			SalBoolean bAutoUpdate = false;
			SalBoolean bFirst = false;
			SalNumber nRow = 0;
			SalArray<SalString> sValue = new SalArray<SalString>(2);
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				switch (nWhat)
				{
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
						if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("GEN_LED_VOUCHER_UPDATE_API.Instant_Update"))) 
						{
							return false;
						}
						return Sal.TblAnyRows(tblInstVouUpdate, Sys.ROW_Selected, 0);
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
						Sal.WaitCursor(true);
						_ResetInstantUpdateParams();
						bFirst = true;
						lsMsg = Ifs.Fnd.ApplicationForms.Const.strNULL;
						nRow = Sys.TBL_MinRow;
						while (Sal.TblFindNextRow(tblInstVouUpdate, ref nRow, Sys.ROW_Selected, 0)) 
						{
							Sal.TblSetContext(tblInstVouUpdate, nRow);
							lsMsg = lsMsg + i_sCompany + "^";
							lsMsg = lsMsg + tblInstVouUpdate_colnAccountingYear.Number.ToString(0) + "^";
							lsMsg = lsMsg + tblInstVouUpdate_colsVoucherType.Text + "^";
							lsMsg = lsMsg + tblInstVouUpdate_colnVoucherNo.Number.ToString(0) + "^" + "$";
							if (lsMsg.Length > 31000) 
							{
								if (bFirst) 
								{
									bFirst = false;
                                    if (!(_DbExecInstantUpdate(lsMsg, "NEW", sPostToQueue))) 
									{
										Sal.WaitCursor(false);
										return false;
									}
								}
								else
								{
                                    if (!(_DbExecInstantUpdate(lsMsg, "ADD", sPostToQueue))) 
									{
										Sal.WaitCursor(false);
										return false;
									}
								}
								lsMsg = Ifs.Fnd.ApplicationForms.Const.strNULL;
							}
						}
                        if (!(_DbExecInstantUpdate(lsMsg, "EXEC", sPostToQueue))) 
						{
							Sal.WaitCursor(false);
							return false;
						}
						sValue[0] = nJouNo.ToString(0);
						if (nJouNo != SalNumber.Null) 
						{
                            if (sPostToQueue == "TRUE")
                            {
                                Ifs.Fnd.ApplicationForms.Int.AlertBoxWithParams(Properties.Resources.TEXT_GlUpdPostedToQueue, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok, sValue);
                            }
                            else
                            {
                                if (nErrorCount > 0)
                                {
                                    sValue[1] = nErrorCount.ToString(0);
                                    Ifs.Fnd.ApplicationForms.Int.AlertBoxWithParams(Properties.Resources.TEXT_UpdJournalReadyWithErr, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok, sValue);
                                }
                                else
                                {
                                    Ifs.Fnd.ApplicationForms.Int.AlertBoxWithParams(Properties.Resources.TEXT_InstUpdJournal, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok, sValue);
                                }
                            }
						}
						else
						{
							Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_InstUpdFails, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.WARNING_Ok);
						}
						Sal.WaitCursor(false);
						Sal.EndDialog(this, Sys.IDOK);
						if (cbAutoUpdate.Checked == true) 
						{
							if (nJouNo != SalNumber.Null) 
							{
								if (PreYearPossible()) 
								{
									bAutoUpdate = true;
									Sal.EndDialog(this, 0);
									dlgPreYearEndDup.ModalDialog(Ifs.Fnd.ApplicationForms.Int.Explorer.ExplorerForm, sPreYear, bAutoUpdate, i_sCompany);
								}
								else
								{
									Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_Dup_AutoUpdate, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
									return false;
								}
							}
							else
							{
								return false;
							}
						}
						return true;
					
					default:
						return false;
				}
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="lsMsg"></param>
		/// <param name="sAction"></param>
        /// <param name="sPostToQueue"></param>
		/// <returns></returns>
        public virtual SalBoolean _DbExecInstantUpdate(SalString lsMsg, SalString sAction, SalString sPostToQueue)
		{
			#region Local Variables
			SalString lsStmt = "";
			SalString sRef = "";
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				sRef = ":i_hWndFrame." + Ifs.Fnd.ApplicationForms.Int.QualifiedItemNameGet(i_hWndSelf) + ".";
				sDetJournal = "N";
				sPrintJournal = "N";
				// Bug 87303, Begin, passed the company as a dynamic variable
				if (lsMsg != Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
                    lsStmt = "&AO.GEN_LED_VOUCHER_UPDATE_API.Instant_Update( " + sRef + "nJouNo, " + sRef + "nSeqNo, " + sRef + "nDummy, " + sRef + "nErrorCount, " + sRef + "lsMsg, '" + sAction + "'," + sRef + "i_sCompany," + sRef + "sPrintJournal," + sRef + "sDetJournal," + sRef + "sPostToQueue" + ")";
					using(SignatureHints hints = SignatureHints.NewContext())
					{
						hints.Add("GEN_LED_VOUCHER_UPDATE_API.Instant_Update", System.Data.ParameterDirection.Output, System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
						return DbPLSQLTransaction(cSessionManager.c_hSql, lsStmt);
					}
				}
				// Bug 87303, End
				return false;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber _ResetInstantUpdateParams()
		{
			#region Actions
			using (new SalContext(this))
			{
				nDummy = SalNumber.Null;
				nJouNo = SalNumber.Null;
				nSeqNo = SalNumber.Null;
                nErrorCount = SalNumber.Null;
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nWhat"></param>
		/// <returns></returns>
		public virtual SalNumber QueryVouchers(SalNumber nWhat)
		{
			#region Actions
			using (new SalContext(this))
			{
				switch (nWhat)
				{
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
						return true;
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
						Sal.SendMsg(tblInstVouUpdate, Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Ifs.Fnd.ApplicationForms.Const.POPULATE_UseQueryDialog);
						return Sal.BringWindowToTop(i_hWndSelf);
					
					default:
						return false;
				}
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// Applications override the FrameShutdownUser to perform shutdown
		/// logic for a window.
		/// COMMENTS:
		/// The framework calls FrameShutdownUser with METHOD_Inquire when the
		/// user selects to close the window (while the SAM_Close message is
		/// being processed), and with METHOD_Execute just before the window
		/// is destroyed.
		/// </summary>
		/// <param name="nWhat"></param>
		/// <returns>
		/// When nWhat = METHOD_Inquire: applications should return TRUE if the window
		/// can be shut down, FALSE otherwise. Returning FALSE will prevent the window
		/// from being closed.
		/// When nWhat = METHOD_Execute: applications should return TRUE if the shutdown
		/// actions were performed successfully, FALSE otherwise. Returning FALSE will prevent
		/// the window from being closed.
		/// </returns>
		public new SalBoolean FrameShutdownUser(SalNumber nWhat)
		{
			#region Local Variables
			SalString sAutoPopulate = "";
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire) 
				{
					return true;
				}
				else
				{
					if (cbAutoPopulate.Checked) 
					{
						sAutoPopulate = "TRUE";
					}
					else
					{
						sAutoPopulate = "FALSE";
					}
					SetProfileValue(i_hWndSelf, "AutoPopulate", sAutoPopulate);
				}
			}

			return false;
			#endregion
		}
		
		/// <summary>
		/// Applications override the FrameShutdownUser to perform shutdown
		/// logic for a window.
		/// COMMENTS:
		/// The framework calls FrameShutdownUser with METHOD_Inquire when the
		/// user selects to close the window (while the SAM_Close message is
		/// being processed), and with METHOD_Execute just before the window
		/// is destroyed.
		/// </summary>
		/// <returns></returns>
		public virtual SalString GetWhereClause()
		{
			#region Local Variables
			SalString lsTempWhere = "";
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				lsTempWhere = "ACCOUNTING_YEAR  =  " + nAccountingYear[0].ToString(0) + " AND  VOUCHER_TYPE = '" + sVoucherType[0] + "' AND VOUCHER_NO = " + nVoucherNo[0].ToString(0);
				return lsTempWhere;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean AutoPopulate()
		{
			#region Local Variables
			SalBoolean bAutoPopulate = false;
			SalString sProfileValue = "";
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				sProfileValue = GetProfileValue(i_hWndSelf, "AutoPopulate", "TRUE");
				return sProfileValue == "TRUE";
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
		private void dlgInstantUpdate_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Create:
					this.dlgInstantUpdate_OnSAM_Create(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_Create event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dlgInstantUpdate_OnSAM_Create(object sender, WindowActionsEventArgs e)
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
		private void tblInstVouUpdate_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.WM_LBUTTONUP:
					e.Handled = true;
					this.pbUpdate.MethodInvestigateState();
					break;
				
				case Sys.SAM_Click:
					e.Handled = true;
					this.pbUpdate.MethodInvestigateState();
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.WM_KEYDOWN:
					this.tblInstVouUpdate_OnWM_KEYDOWN(sender, e);
					break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew:
                    e.Handled = true;
                    e.Return = false;
                    break;
                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordCopy:
                    e.Handled = true;
                    e.Return = false;
                    break;
                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove:
                    e.Handled = true;
                    e.Return = false;
                    break;
                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordDuplicate:
                    e.Handled = true;
                    e.Return = false;
                    break;
			}
			#endregion
		}
		
		/// <summary>
		/// WM_KEYDOWN event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblInstVouUpdate_OnWM_KEYDOWN(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sys.wParam == Vis.VK_Tab) 
			{
				Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.WM_KEYDOWN, Sys.wParam, Sys.lParam);
				Sal.SetFocus(this.pbUpdate);
			}
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void cbAutoUpdate_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_EditStateFieldEnabled:
					e.Handled = true;
					e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldEnabled;
					return;
			}
			#endregion
		}
		#endregion
		
		#region Late Bind Methods
		
		/// <summary>
		/// Virtual wrapper replacement for late-bound (..) calls.
		/// </summary>
		public override SalBoolean vrtFrameShutdownUser(SalNumber nWhat)
		{
			return this.FrameShutdownUser(nWhat);
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
		
	}
}
