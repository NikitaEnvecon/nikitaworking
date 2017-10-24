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

using System.Windows.Forms;
using Ifs.Fnd.ApplicationForms;
using PPJ.Runtime;
using PPJ.Runtime.Sql;
using PPJ.Runtime.Windows;

namespace Ifs.Application.Accrul
{
	
	/// <summary>
	/// </summary>
	/// <param name="sPFileType"></param>
	/// <param name="sPSetId"></param>
	/// <param name="sPInParam"></param>
	/// <param name="bEditable"></param>
	/// <param name="sPOutParam"></param>
	public partial class dlgExternalFileParam : cDialogBox
	{
		#region Window Parameters
		public SalString sPFileType;
		public SalString sPSetId;
		public SalString sPInParam;
		public SalBoolean bEditable;
		public SalString sPOutParam;
		#endregion
		
		#region Window Variables
		public SalNumber nIndex = 0;
		public SalArray<SalString> strFilters = new SalArray<SalString>("0:5");
		public SalString strFile = "";
		public SalString strPath = "";
		public SalString sFileType = "";
		public SalString sSetId = "";
		public SalString lsParam = "";
		public SalString sParamName = "";
		public SalString sParamValue = "";
		public SalWindowHandle hWndLovField = SalWindowHandle.Null;
		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		protected dlgExternalFileParam()
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
		public static SalNumber ModalDialog(Control owner, SalString sPFileType, SalString sPSetId, SalString sPInParam, SalBoolean bEditable, ref SalString sPOutParam)
		{
			dlgExternalFileParam dlg = DialogFactory.CreateInstance<dlgExternalFileParam>();
			dlg.sPFileType = sPFileType;
			dlg.sPSetId = sPSetId;
			dlg.sPInParam = sPInParam;
			dlg.bEditable = bEditable;
			dlg.sPOutParam = sPOutParam;
			SalNumber ret = dlg.ShowDialog(owner);
			sPOutParam = dlg.sPOutParam;
			return ret;
		}
		
		/// <summary>
		/// Returns the object instance associated with the window handle.
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public new static dlgExternalFileParam FromHandle(SalWindowHandle handle)
		{
			return ((dlgExternalFileParam)SalWindow.FromHandle(handle, typeof(dlgExternalFileParam)));
		}
		#endregion
		
		#region Methods
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber BrowseFile()
		{
			#region Actions
			using (new SalContext(this))
			{
				if (tblExternalFileParam_colsBrowsableField.Text == "TRUE") 
				{
					Sal.EnableWindowAndLabel(pbBrowse);
				}
				else
				{
					Sal.DisableWindowAndLabel(pbBrowse);
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
			#region Actions
			using (new SalContext(this))
			{
				strFilters[0] = "Text Files  (*.txt)";
				strFilters[1] = "*.txt";
				strFilters[2] = "All Files  (*.*)";
				strFilters[3] = "*.*";
				this.PopulateFromView();
				this.PopulateValues();
				this.FixLooks();
				Sal.DisableWindowAndLabel(pbBrowse);
				return true;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nWhatInv"></param>
		/// <param name="sAction"></param>
		/// <returns></returns>
		public new SalNumber UserMethod(SalNumber nWhatInv, SalString sAction)
		{
			#region Actions
			using (new SalContext(this))
			{
				if (sAction == "OKButton") 
				{
					switch (nWhatInv)
					{
						case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
							return bEditable;
						
						case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
							Sal.EndDialog(i_hWndFrame, Sys.IDOK);
							break;
					}
				}
				if (sAction == "CancelButton") 
				{
					switch (nWhatInv)
					{
						case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
							return true;
						
						case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
							Sal.EndDialog(i_hWndFrame, Sys.IDCANCEL);
							goto case Ifs.Fnd.ApplicationForms.Const.METHOD_GetType;
						
						case Ifs.Fnd.ApplicationForms.Const.METHOD_GetType:
							return Ifs.Fnd.ApplicationForms.Const.CHILDTYPE_Any;
					}
				}
				if (sAction == "ListButton") 
				{
					switch (nWhatInv)
					{
						case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                            return (tblExternalFileParam_colsLovView.Text != Ifs.Fnd.ApplicationForms.Const.strNULL);
						
						case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                            if (hWndLovField != this.tblExternalFileParam_colsValue)
                                return Sys.IDCANCEL;
                            tblExternalFileParam_colsValue.RuntimeLovReference = this.sViewStatement;
                            tblExternalFileParam_colsValue.EditDataItemLov(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
							return Sys.IDOK;
						
						case Ifs.Fnd.ApplicationForms.Const.METHOD_GetType:
							return Ifs.Fnd.ApplicationForms.Const.CHILDTYPE_Any;
					}
				}
			}

			return false;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean ChangeParamValues()
		{
			#region Actions
			using (new SalContext(this))
			{
				using(SignatureHints hints = SignatureHints.NewContext())
				{
					hints.Add("Ext_File_Message_API.Change_Attr_Parameter_Msg", System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
					if (!(DbPLSQLBlock(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "Ext_File_Message_API.Change_Attr_Parameter_Msg (\r\n" +
						"                  :i_hWndFrame.dlgExternalFileParam.lsParam,\r\n" +
						"	  :i_hWndFrame.dlgExternalFileParam.sParamName,\r\n" +
						"	  :i_hWndFrame.dlgExternalFileParam.sParamValue )"))) 
					{
						Sal.WaitCursor(false);
						DbTransactionEnd(cSessionManager.c_hSql);
						sParamName = Ifs.Fnd.ApplicationForms.Const.strNULL;
						sParamValue = Ifs.Fnd.ApplicationForms.Const.strNULL;
						return false;
					}
				}
				sParamName = Ifs.Fnd.ApplicationForms.Const.strNULL;
				sParamValue = Ifs.Fnd.ApplicationForms.Const.strNULL;
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
		private void dlgExternalFileParam_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Create:
                    this.dlgExternalFileParam_OnSAM_Create(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_Create event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dlgExternalFileParam_OnSAM_Create(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.sFileType = this.sPFileType;
			this.sSetId = this.sPSetId;
			Sal.HideWindowAndLabel(this.tblExternalFileParam_colsHelpText);
			this.lsParam = this.sPInParam;
			this.sPOutParam = this.lsParam;
			Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam);
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void tblExternalFileParam_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_RowHeaderClick:
					this.tblExternalFileParam_OnSAM_RowHeaderClick(sender, e);
					break;
				
				case Sys.SAM_Click:
					this.tblExternalFileParam_OnSAM_Click(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave:
					this.tblExternalFileParam_OnPM_DataSourceSave(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_RowHeaderClick event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblExternalFileParam_OnSAM_RowHeaderClick(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.sSelectedParamId = this.tblExternalFileParam_colsParamId.Text;
			this.BrowseFile();
			this.SetStatusText();
			#endregion
		}
		
		/// <summary>
		/// SAM_Click event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblExternalFileParam_OnSAM_Click(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.sSelectedParamId = this.tblExternalFileParam_colsParamId.Text;
			this.BrowseFile();
			this.SetStatusText();
			#endregion
		}
		
		/// <summary>
		/// PM_DataSourceSave event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblExternalFileParam_OnPM_DataSourceSave(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire) 
			{
				e.Return = false;
				return;
			}
			e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Sys.wParam, Sys.lParam);
			return;
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
					this.pbOk_OnSAM_Click(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_Click event handler.
		/// </summary>
		/// <param name="message"></param>
		private void pbOk_OnSAM_Click(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.sPOutParam = this.lsParam;
			Sal.EndDialog(this.pbOk.i_hWndFrame, Sys.IDOK);
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void pbBrowse_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Click:
					this.pbBrowse_OnSAM_Click(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_Click event handler.
		/// </summary>
		/// <param name="message"></param>
		private void pbBrowse_OnSAM_Click(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			Sal.DlgOpenFile(this, "Open File", this.strFilters, 6, ref this.nIndex, ref this.strFile, ref this.strPath);
			this.tblExternalFileParam_colsValue.Text = this.strPath;
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
		
		#region ChildTable - tblExternalFileParam
			
		#region Window Variables
		public SalString sSelectedParamId = "";
		public SalString sViewStatement = "";
		public SalString sWhereStatement = "";
		public SalString sValueTemp = "";
		public SalString sFuncToCall = "";
		public SalNumber nNum = 0;
		public SalNumber nNumMax = 0;
		public SalNumber nNumUnit = 0;
		public SalArray<SalString> sUnits = new SalArray<SalString>();
		public SalArray<SalString> sRecords = new SalArray<SalString>();
		#endregion
			
		#region Methods
			
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber PopulateFromView()
		{
		    Sal.WaitCursor(true);
            SalString lsStmt = "FILE_TYPE = " + "'" + this.sFileType + "'" + " AND SET_ID = " + "'" + this.sSetId + "'";
            tblExternalFileParam.DataSourceUserWhere(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, lsStmt.ToHandle());
            tblExternalFileParam.DataSourceUserOrderBy(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, ((SalString)"Param_No").ToHandle());
            tblExternalFileParam.SendMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Ifs.Fnd.ApplicationForms.Const.POPULATE_NoConfirm);
		    Sal.WaitCursor(false);
			return 0;
		}
			
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber PopulateValues()
		{
			#region Local Variables
			cMessage MainMessage = new cMessage();
			SalNumber nCountRow = 0;
			SalNumber nCurrentRow = 0;
			SalString sTempValue = "";
			#endregion
				
			#region Actions

            if (this.lsParam != Ifs.Fnd.ApplicationForms.Const.strNULL && Sal.TblAnyRows(tblExternalFileParam, 0, 0)) 
			{
                nCountRow = Sal.TblSetRow(tblExternalFileParam, Sys.TBL_SetLastRow);
                nCurrentRow = Sal.TblSetRow(tblExternalFileParam, Sys.TBL_SetFirstRow);
				MainMessage.Unpack(this.lsParam);
				while (nCurrentRow <= nCountRow) 
				{
                    if (Sal.TblSetContext(tblExternalFileParam, nCurrentRow)) 
					{
                        sTempValue = MainMessage.FindAttribute(tblExternalFileParam_colsParamId.Text, Ifs.Fnd.ApplicationForms.Const.strNULL);
						if (sTempValue != Ifs.Fnd.ApplicationForms.Const.strNULL) 
						{
                            if (tblExternalFileParam_colsEnumerateMethod.Text == Ifs.Fnd.ApplicationForms.Const.strNULL) 
							{
                                tblExternalFileParam_colsValue.Text = sTempValue;
							}
							else
							{
								sValueTemp = sTempValue;
								GetClientValue();
							}
						}
						nCurrentRow = nCurrentRow + 1;
					}
				}
			}
			return 0;
			#endregion
		}
			
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber FixLooks()
		{
            Sal.HideWindowAndLabel(tblExternalFileParam_colsFileType);
            Sal.HideWindowAndLabel(tblExternalFileParam_colsParamId);
            Sal.HideWindowAndLabel(tblExternalFileParam_colnParamNo);
            Sal.ShowWindowAndLabel(tblExternalFileParam_colsValue);
            Sal.TblSetColumnWidth(tblExternalFileParam_colsValue, 3.4m);
            Sal.TblSetColumnWidth(tblExternalFileParam_colsDescription, 2);
            Sal.HideWindowAndLabel(tblExternalFileParam_colsBrowsableField);
			return 0;
		}
			
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber SetStatusText()
		{   
            Sal.StatusSetText(tblExternalFileParam, tblExternalFileParam_colsHelpText.Text);
			return 0;
		}
			
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber BuildParameterString()
		{
			#region Local Variables
			cMessage MainMessage = new cMessage();
			SalNumber nCountRow = 0;
			SalNumber nCurrentRow = 0;
			#endregion
				
			#region Actions
            tblExternalFileParam.SendMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataContextLast, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
            if (Sal.TblAnyRows(tblExternalFileParam, 0, 0)) 
			{
                nCountRow = Sal.TblSetRow(tblExternalFileParam, Sys.TBL_SetLastRow);
                nCurrentRow = Sal.TblSetRow(tblExternalFileParam, Sys.TBL_SetFirstRow);
				MainMessage.Construct();
				MainMessage.SetName("PARAMETER_MESSAGE");
				MainMessage.AddAttribute("FILE_TYPE", this.sFileType);
				MainMessage.AddAttribute("SET_ID", this.sSetId);
				while (nCurrentRow <= nCountRow) 
				{
                    if (Sal.TblSetContext(tblExternalFileParam, nCurrentRow)) 
					{
                        if (tblExternalFileParam_colsParamId.Text != Ifs.Fnd.ApplicationForms.Const.strNULL) 
						{
                            MainMessage.AddAttribute(tblExternalFileParam_colsParamId.Text, tblExternalFileParam_colsValue.Text);
						}
						nCurrentRow = nCurrentRow + 1;
					}
				}
				this.sPOutParam = MainMessage.Pack();
			}
			return 0;
			#endregion
		}
			
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber LovWhereValue()
		{
			#region Local Variables
			SalString sOrgin = "";
			SalString sWhere = "";
			SalString sWhereFinal = "";
			SalNumber nLength = 0;
			SalNumber nOffset = 0;
			SalNumber nActiveRow = 0;
			SalNumber nCountRow = 0;
			SalNumber nCurrentRow = 0;
			SalWindowHandle nCellRow = SalWindowHandle.Null;
			#endregion
				
			#region Actions
            Sal.TblQueryFocus(tblExternalFileParam, ref nActiveRow, ref nCellRow);
			// Bug 71319, Begin. Fully qualified colsLovView.
            sOrgin = this.tblExternalFileParam_colsLovView.Text;
			// Bug 71319, End.
			if (sOrgin.Right(1) == ")") 
			{
				// Bug 71319, Begin. Fully qualified colsLovView.
                nLength = ((SalString)tblExternalFileParam_colsLovView.Text).Length;
				// Bug 71319, End.
				nOffset = sOrgin.Scan("(");
				sViewStatement = sOrgin.Left(nOffset);
				// Lov view seperated
				sOrgin = sOrgin.Right((nLength - nOffset));
				nLength = sOrgin.Length;
				sOrgin = sOrgin.Right((nLength - 1));
				nLength = sOrgin.Length;
				sOrgin = sOrgin.Left((nLength - 1));
				sOrgin = sOrgin + ",";
				while (sOrgin.Scan(",") > 0) 
				{
					nOffset = sOrgin.Scan(",");
					sWhere = sOrgin.Left(nOffset);
                    nCountRow = Sal.TblSetRow(tblExternalFileParam, Sys.TBL_SetLastRow);
                    nCurrentRow = Sal.TblSetRow(tblExternalFileParam, Sys.TBL_SetFirstRow);
					while (nCurrentRow <= nCountRow) 
					{
                        if (Sal.TblSetContext(tblExternalFileParam, nCurrentRow)) 
						{
							// Bug 71319, Begin. Fully qualified colsParamId.
                            if (tblExternalFileParam_colsParamId.Text == sWhere) 
							{
								// Bug 71319, Begin. Fully qualified tblExternalFileParam_colsValue.
								if (tblExternalFileParam_colsValue.Text != Ifs.Fnd.ApplicationForms.Const.strNULL) 
								{
									sWhere = sWhere + " = " + "'" + tblExternalFileParam_colsValue.Text + "'";
									if (sWhereFinal == Ifs.Fnd.ApplicationForms.Const.strNULL) 
									{	sWhereFinal = sWhere;   }
									else
									{	sWhereFinal = sWhereFinal + " AND " + sWhere;   }
								}
								// Bug 71319, End.
								nCurrentRow = nCountRow + 1;
							}
							// Bug 71319, End.
						}
						nCurrentRow = nCurrentRow + 1;
					}
					nOffset = sOrgin.Scan(",");
					nLength = sOrgin.Length;
					sOrgin = sOrgin.Right((nLength - nOffset) - 1);
					sWhereStatement = sWhereFinal;
				}
			}
			else
			{
				sWhereStatement = Ifs.Fnd.ApplicationForms.Const.strNULL;
                sViewStatement = this.tblExternalFileParam_colsLovView.Text;
			}
            Sal.TblSetFocusCell(tblExternalFileParam, nActiveRow, nCellRow, 0, 1);
			return 0;
			#endregion
		}
			
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber GetDbValue()
		{
			
			#region Actions
            SalNumber nOffset = ((SalString)tblExternalFileParam_colsEnumerateMethod.Text).Scan(".");
            SalString sPackage = ((SalString)tblExternalFileParam_colsEnumerateMethod.Text).Left(nOffset);
			this.sFuncToCall = sPackage + ".Encode";
            DbPLSQLBlock("{0} :=" + cSessionManager.c_sDbPrefix + this.sFuncToCall + "({1} IN)", this.QualifiedVarBindName("sParamValue"), this.QualifiedVarBindName("sValueTemp"));
			return 0;
			#endregion
		}
			
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber GetClientValue()
		{
            SalNumber nOffset = ((SalString)tblExternalFileParam_colsEnumerateMethod.Text).Scan(".");
            SalString sPackage = ((SalString)tblExternalFileParam_colsEnumerateMethod.Text).Left(nOffset);
		    sFuncToCall = sPackage + ".Decode";
            DbPLSQLBlock("{0} :=" + cSessionManager.c_sDbPrefix + sFuncToCall + "({1} IN)", this.tblExternalFileParam_colsValue.QualifiedBindName, this.QualifiedVarBindName("sValueTemp"));
			return 0;
		}
			
		/// <summary>
		/// </summary>
		/// <param name="sLOV"></param>
		/// <returns></returns>
		public virtual SalBoolean ViewIsAvailable(SalString sLOV)
		{
			#region Local Variables
			SalString sOrgin = "";
			SalString sViewStatement = "";
			SalNumber nLength = 0;
			SalNumber nOffset = 0;
			#endregion
				
			#region Actions
			sOrgin = sLOV;
			if (sOrgin.Right(1) == ")") 
			{
				nLength = sLOV.Length;
				nOffset = sOrgin.Scan("(");
				sViewStatement = sOrgin.Left(nOffset);
				return Ifs.Fnd.ApplicationForms.Var.Security.IsViewAvailable(sViewStatement);
			}
			else
			{
                return Ifs.Fnd.ApplicationForms.Var.Security.IsViewAvailable(tblExternalFileParam_colsLovView.Text);
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
		private void tblExternalFileParam_colsValue_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_AnyEdit:
					e.Handled = true;
                    Sal.SendMsg(tblExternalFileParam, Ifs.Fnd.ApplicationForms.Const.PM_DataItemStateSet, Ifs.Fnd.ApplicationForms.Const.EDIT_Empty, 0);
					break;
					
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
					this.tblExternalFileParam_colsValue_OnPM_DataItemValidate(sender, e);
					break;
					
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovDone:
					this.tblExternalFileParam_colsValue_OnPM_DataItemLovDone(sender, e);
					break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovUserReturnKeyName:
                    this.tblExternalFileParam_colsValue_OnPM_DataItemLovUserReturnKeyName(sender, e);
					break;
					
				case Sys.SAM_KillFocus:
					e.Handled = true;
                    Sal.SendMsg(tblExternalFileParam, Ifs.Fnd.ApplicationForms.Const.PM_DataItemStateSet, Ifs.Fnd.ApplicationForms.Const.EDIT_Empty, 0);
					break;
					
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
					this.tblExternalFileParam_colsValue_OnPM_DataItemQueryEnabled(sender, e);
					break;
					
				case Sys.SAM_Click:
					this.tblExternalFileParam_colsValue_OnSAM_Click(sender, e);
					break;
					
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovUserWhere:
					e.Handled = true;
					e.Return = this.sWhereStatement.ToHandle();
					return;
			}
			#endregion
		}
			
		/// <summary>
		/// PM_DataItemValidate event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblExternalFileParam_colsValue_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
            if (this.tblExternalFileParam_colsEnumerateMethod.Text != Ifs.Fnd.ApplicationForms.Const.strNULL) 
			{
                this.sValueTemp = this.tblExternalFileParam_colsValue.Text;
				this.GetDbValue();
				if (this.sParamValue == Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
                    this.tblExternalFileParam_colsValue.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
					e.Return = Sys.VALIDATE_Cancel;
					return;
				}
			}
			else
			{
                this.sParamValue = this.tblExternalFileParam_colsValue.Text;
			}
            this.sParamName = this.tblExternalFileParam_colsParamId.Text;
			this.ChangeParamValues();
			e.Return = Sys.VALIDATE_Ok;
			return;
			#endregion
		}
			
		/// <summary>
		/// PM_DataItemLovDone event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblExternalFileParam_colsValue_OnPM_DataItemLovDone(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.nNumMax = SalString.FromHandle(Sys.lParam).Tokenize("", ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_RS).ToCharacter(), this.sRecords);
			this.nNum = 0;
			while (this.nNum != this.nNumMax) 
			{
				this.nNumUnit = this.sRecords[this.nNum].Tokenize("", ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_US).ToCharacter(), this.sUnits);
                if (this.tblExternalFileParam_colsParamId.Text == this.sUnits[0]) 
				{
					this.tblExternalFileParam_colsValue.Text = this.sUnits[1];
                    this.sParamName = this.tblExternalFileParam_colsParamId.Text;
					this.sParamValue = this.tblExternalFileParam_colsValue.Text;
					if (this.ChangeParamValues()) 
					{
						e.Return = Sys.VALIDATE_Ok;
						return;
					}
					e.Return = true;
					return;
				}
				this.nNum = this.nNum + 1;
			}
			if (this.nNum == this.nNumMax) 
			{
				this.tblExternalFileParam_colsValue.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
			}
			Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataItemStateSet, Ifs.Fnd.ApplicationForms.Const.EDIT_Empty, 0);
			#endregion
		}

        private void tblExternalFileParam_colsValue_OnPM_DataItemLovUserReturnKeyName(object sender, WindowActionsEventArgs e)
        {
            e.Handled = true;
            e.Return = Sal.HStringToNumber(this.tblExternalFileParam_colsParamId.Text);
        }
	
		/// <summary>
		/// PM_DataItemQueryEnabled event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblExternalFileParam_colsValue_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (this.bEditable) 
			{
				e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldEnabled;
				return;
			}
			else
			{
				e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
				return;
			}
			#endregion
		}
			
		/// <summary>
		/// SAM_Click event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblExternalFileParam_colsValue_OnSAM_Click(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
            if (this.tblExternalFileParam_colsLovView.Text != Ifs.Fnd.ApplicationForms.Const.strNULL) 
			{
                if (this.ViewIsAvailable(this.tblExternalFileParam_colsLovView.Text)) 
				{
                    this.hWndLovField = this.tblExternalFileParam_colsValue;
                    this.tblExternalFileParam_colsValue.p_sLovReference = this.tblExternalFileParam_colsLovView.Text;
					this.LovWhereValue();
				}
				else
				{
					this.tblExternalFileParam_colsValue.p_sLovReference = Ifs.Fnd.ApplicationForms.Const.strNULL;
				}
			}
			else
			{
				this.tblExternalFileParam_colsValue.p_sLovReference = Ifs.Fnd.ApplicationForms.Const.strNULL;
			}
			this.pbList.MethodInvestigateState();
            if (this.tblExternalFileParam_colsEnumerateMethod.Text != Ifs.Fnd.ApplicationForms.Const.strNULL) 
			{
                if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable(this.tblExternalFileParam_colsEnumerateMethod.Text))) 
				{
					Sal.ListClear(this.tblExternalFileParam_colsValue.i_hWndSelf);
					this.tblExternalFileParam_colsValue.p_sEnumerateMethod = Ifs.Fnd.ApplicationForms.Const.strNULL;
				}
				else
				{
                    this.tblExternalFileParam_colsValue.p_sEnumerateMethod = cSessionManager.c_sDbPrefix + this.tblExternalFileParam_colsEnumerateMethod.Text;
					this.tblExternalFileParam_colsValue.LookupInit();
				}
			}
			else
			{
				Sal.ListClear(this.tblExternalFileParam_colsValue);
				this.tblExternalFileParam_colsValue.p_sEnumerateMethod = Ifs.Fnd.ApplicationForms.Const.strNULL;
			}
			#endregion
		}
		#endregion
		
		#endregion
	}
}
