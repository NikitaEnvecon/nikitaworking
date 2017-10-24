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
//Date     By      Notes
//------   ------  -------------------------------------------------------------------------------------
//101026   LaSeLK  Bug 93702, Overrided vrtWizardNext and vrtWizardPrevious to hide/unhide the labeldfsFileType,dfsFileType,dfsFileTypeDescription,labeldfsFileType2 and dfsFileType2 in relevent steps in dlgExternalFileWizard.
//121206   Machlk  Bug 107093, Saved the historic payment file for MandateToPi.
//130422   THPELK  Bug 109307, Corrected in dlgExternalFileWizard/tblExternalFileParam
//13071    THPELK  Bug 111151, Corrected in dlgExternalFileWizard - Removed window registration for EXT_OUT_INV_HEAD
//131114   Charlk  PBFI-2045,  rename method Get_Load_File_Type_List to Get_Load_File_Type_List_Db
//131114   Charlk  PBFI-3657,  modify method PopulateFromView().
//140402   THPELK  PBFI-5114 LCS Merge (Bug 114993) Corrected.
//140717   MAWELK  PRFI-357 (LCS Merge 117006) Fixed.
//140911   AJPELK  PRFI-2121 LCS Mgere 118511, Corrected.
//141027   Chwilk  Bug 119319, Modified dfsSetIdTest_OnPM_DataItemValidate() and dfsSetIdTest_OnSAM_SetFocus().
//150806   Nudilk  Bug 123877, Corrected in ReadClientFile.
//160504   Chwtlk  Bug 128652, Modified OpenClientFile() and added new method CheckFileEncoding(SalString sPath).
//160727   Chwtlk  Bug 130527, Modified dfsSetIdTest_OnPM_DataItemValidate(), dfsFileTemplateId_OnPM_DataItemValidate(), dfsFileType_OnPM_DataItemValidate() and vrtWizardPrevious().

#endregion

using System.IO;
using System.Text;
using System.Windows.Forms;
using Ifs.Fnd.ApplicationForms;
using PPJ.Runtime;
using PPJ.Runtime.Sql;
using PPJ.Runtime.Windows;
using PPJ.Runtime.Vis;

namespace Ifs.Application.Accrul
{
	
	/// <summary>
	/// </summary>
	[FndWindowRegistration("EXT_FILE_TYPE", "ExtFileType", FndWindowRegistrationFlags.HomePage)]	
	public partial class dlgExternalFileWizard : cWizardDialogBoxFin
	{
		#region Window Variables
		public SalWindowHandle hWndLovField = SalWindowHandle.Null;
		public SalDateTime dCurrDate = SalDateTime.Null;
		public SalDateTime dCurrTime = SalDateTime.Null;
		public SalDateTime dOldRepeatedTime = SalDateTime.Null;
		public SalDateTime dOldScheduledDate = SalDateTime.Null;
		public SalDateTime dOldScheduledTime = SalDateTime.Null;
		public SalFileHandle hSrcHandle = SalFileHandle.Null;
		public SalString lsParamString = "";
		public SalString lsTemp = "";
		public SalString lsMainMesgTemp = "";
		public SalString lsMainMessage = "";
		public SalNumber nIndex = 0;
		public SalNumber nLoadFileId = 0;
		public SalNumber nRowCount = 0;
		public SalNumber nRowno = 0;
		public SalNumber nParamNo = 0;
		public SalString sAction = "";
		public SalString sClientServer = "";
		public SalString sCompany = "";
		public SalString sExecPlan = "";
		public SalString sFileDirection = "";
		public SalString sFileDirectionDb = "";
		public SalString sFuncToCall = "";
		public SalString sParamName = "";
		public SalString sParamValue = "";
		public SalString strFile = "";
		public SalArray<SalString> strFilters = new SalArray<SalString>("0:5");
		public SalString strMultiDirection = "";
		public SalString strUtilFileDirection = "";
		public SalString strPath = "";
		public SalString sViewName = "";
		public SalString sPackageName = "";
		public SalString sState = "";
		public SalString sLoadFileId = "";
		public SalString sBackPath = "";
		public SalString sSpecialLov = "";
		public SalString sFileName = "";
		public SalBoolean bEditFileType = false;
		public SalString sloadProfileFileTypeList = "";
		public SalArray<SalString> sDecodedFileList = new SalArray<SalString>();
		public SalNumber nCnt = 0;
		public SalString sFileNameData = "";
		public SalString sLoadType = "";
		public SalString sExist = "";
		public SalString g_CheckNav = "";
		public SalString sIsXmlType = "";
        // Bug 130527, Begin.
        public SalString sSetId = "";
        public SalString sFileType = "";
        public SalString sFileTemplateId = "";
        public SalBoolean bFileTypeChanged;
        // Bug 130527, End.
		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		protected dlgExternalFileWizard()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
            this.tblExternalFileParam_colsValue.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.AutoResizeButtons = true;
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
			dlgExternalFileWizard dlg = DialogFactory.CreateInstance<dlgExternalFileWizard>();
			SalNumber ret = dlg.ShowDialog(owner);
			return ret;
		}
		
		/// <summary>
		/// Returns the object instance associated with the window handle.
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public new static dlgExternalFileWizard FromHandle(SalWindowHandle handle)
		{
			return ((dlgExternalFileWizard)SalWindow.FromHandle(handle, typeof(dlgExternalFileWizard)));
		}
		#endregion
		
		#region Methods
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean CheckLoadDate()
		{
			#region Actions
			using (new SalContext(this))
			{
				dfdLoadDate.DateTime = sParamValue.ToDate();
				sParamValue = sParamValue.ToDate().ToString("yyyy-MM-dd");
				if (dfdLoadDate.DateTime == Sys.DATETIME_Null) 
				{
					return false;
				}
				return true;
			}
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
						"                  :i_hWndFrame.dlgExternalFileWizard.lsParamString,\r\n" +
						"	  :i_hWndFrame.dlgExternalFileWizard.sParamName,\r\n" +
						"	  :i_hWndFrame.dlgExternalFileWizard.sParamValue )"))) 
					{
						Sal.WaitCursor(false);
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
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber PopulateParamValues()
		{
			#region Local Variables
			cMessage Msg = new cMessage();
			SalString sDrive = "";
			SalString sDir = "";
			SalString sFile = "";
			SalString sExt = "";
			SalString sPathOrg = "";
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				Msg.Unpack(lsParamString);
				dfsFileTemplateId.Text = Msg.FindAttribute("FILE_TEMPLATE_ID", Ifs.Fnd.ApplicationForms.Const.strNULL);
				sFileDirectionDb = Msg.FindAttribute("FILE_DIRECTION_DB", Ifs.Fnd.ApplicationForms.Const.strNULL);
				dfsFileName.Text = Msg.FindAttribute("FILE_NAME", Ifs.Fnd.ApplicationForms.Const.strNULL);
				strPath = dfsFileName.Text;
				sPathOrg = dfsFileName.Text;
				if (rbOnline.Checked) 
				{
					if (dfsFileName.Text != Ifs.Fnd.ApplicationForms.Const.strNULL) 
					{
						Vis.DosSplitPath(dfsFileName.Text, ref sDrive, ref sDir, ref sFile, ref sExt);
						// Bug 79498 Begin
						// If sFileDirectionDb = '1'
						// Input
						// If not VisDosExist( (dfsFileName ) )
						// If VisDosGetEnvString( 'TEMP' ) != strNULL
						// Set dfsFileName = PalStrAppendWithSeparator( VisDosGetEnvString( 'TEMP' ), sFile, '\\' ) || sExt
						// Else If VisDosGetEnvString( 'TMP' ) != strNULL
						// Set dfsFileName = PalStrAppendWithSeparator( VisDosGetEnvString( 'TEMP' ), sFile, '\\' ) || sExt
						// Else
						// If SalFileGetCurrentDirectory ( sDir )
						// Set dfsFileName = PalStrAppendWithSeparator( sDir, sFile, '\\' ) || sExt
						// Else
						// Set dfsFileName = strNULL
						if (sFileDirectionDb != "1") 
						{
							// Output
							if (!(Vis.DosExist((sDrive + sDir)))) 
							{
								if (!(Sal.FileGetCurrentDirectory(ref sDir))) 
								{
									if (Vis.DosGetEnvString("TEMP") != Ifs.Fnd.ApplicationForms.Const.strNULL) 
									{
										dfsFileName.Text = Ifs.Fnd.ApplicationForms.Int.PalStrAppendWithSeparator(Vis.DosGetEnvString("TEMP"), sFile, "\\") + sExt;
									}
									else if (Vis.DosGetEnvString("TMP") != Ifs.Fnd.ApplicationForms.Const.strNULL) 
									{
										dfsFileName.Text = Ifs.Fnd.ApplicationForms.Int.PalStrAppendWithSeparator(Vis.DosGetEnvString("TEMP"), sFile, "\\") + sExt;
									}
									else
									{
										dfsFileName.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
									}
								}
								else
								{
									if (Sal.FileGetCurrentDirectory(ref sDir)) 
									{
										dfsFileName.Text = Ifs.Fnd.ApplicationForms.Int.PalStrAppendWithSeparator(sDir, sFile, "\\") + sExt;
									}
									else
									{
										dfsFileName.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
									}
								}
							}
							if ((sDrive + sDir).Length == 1) 
							{
								if (!(Sal.FileGetCurrentDirectory(ref sDir))) 
								{
									if (Vis.DosGetEnvString("TEMP") != Ifs.Fnd.ApplicationForms.Const.strNULL) 
									{
										dfsFileName.Text = Ifs.Fnd.ApplicationForms.Int.PalStrAppendWithSeparator(Vis.DosGetEnvString("TEMP"), sFile, "\\") + sExt;
									}
									else if (Vis.DosGetEnvString("TMP") != Ifs.Fnd.ApplicationForms.Const.strNULL) 
									{
										dfsFileName.Text = Ifs.Fnd.ApplicationForms.Int.PalStrAppendWithSeparator(Vis.DosGetEnvString("TEMP"), sFile, "\\") + sExt;
									}
									else
									{
										dfsFileName.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
									}
								}
								else
								{
									if (Sal.FileGetCurrentDirectory(ref sDir)) 
									{
										dfsFileName.Text = Ifs.Fnd.ApplicationForms.Int.PalStrAppendWithSeparator(sDir, sFile, "\\") + sExt;
									}
									else
									{
										dfsFileName.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
									}
								}
							}
						}
					}
				}
				strFile = dfsFileName.Text;
				if (dfsFileTemplateId.Text != Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
					using(SignatureHints hints = SignatureHints.NewContext())
					{
						hints.Add("Ext_File_Template_Dir_API.Get_Multi_Direction", System.Data.ParameterDirection.Input);
						if (!(DbPLSQLBlock(cSessionManager.c_hSql, ":i_hWndFrame.dlgExternalFileWizard.strMultiDirection :=  " + cSessionManager.c_sDbPrefix + "Ext_File_Template_Dir_API.Get_Multi_Direction(\r\n" +
							":i_hWndFrame.dlgExternalFileWizard.dfsFileTemplateId)"))) 
						{
							return false;
						}
					}
				}
				if (sFileDirectionDb == "1") 
				{
					cbInput.Checked = true;
					cbOutput.Checked = false;
				}
				else
				{
					cbOutput.Checked = true;
					cbInput.Checked = false;
				}
				if (strFile != dfsFileName.Text) 
				{
					sParamName = "FILE_NAME";
					sParamValue = dfsFileName.Text;
					strPath = dfsFileName.Text;
					ChangeParamValues();
					PopulateParamValues();
				}
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber CreateParam()
		{
			#region Local Variables
			// Bug 86956, Begin
			cMessage TempMsg = new cMessage();
			SalString sTempValue = "";
			// Bug 86956, End
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				Sal.WaitCursor(true);
				// Bug 71930, Begin - Added check for 'NEW_COMPANY'
				// Bug 67661, Begin
                if (sParamName != "NEW_LOAD_TYPE" && sParamName != "NEW_COMPANY" && sParamName != "FILE_DIRECTION_DB") 
				{
					lsParamString = Ifs.Fnd.ApplicationForms.Const.strNULL;
				}
				// Bug 67661, End
				// Bug 71930, End
				sFileNameData = Ifs.Fnd.ApplicationForms.Const.strNULL;
				using(SignatureHints hints = SignatureHints.NewContext())
				{
					hints.Add("Ext_File_Message_API.Return_For_Trans_Form", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
					DbPLSQLBlock(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "Ext_File_Message_API.Return_For_Trans_Form (\r\n" +
						"                  :i_hWndFrame.dlgExternalFileWizard.dfsFileType,\r\n" +
						"	  :i_hWndFrame.dlgExternalFileWizard.dfsSetIdTest,\r\n" +
						"	  :i_hWndFrame.dlgExternalFileWizard.lsParamString,\r\n" +
						"	  :i_hWndFrame.dlgExternalFileWizard.dfsFileTemplateId ,\r\n" +
						"	  :i_hWndFrame.dlgExternalFileWizard.sFileDirectionDb ,\r\n" +
						"	  :i_hWndFrame.dlgExternalFileWizard.sFileDirection ,\r\n" +
						"	  :i_hWndFrame.dlgExternalFileWizard.dfsFileName ,\r\n" +
						"	  :i_hWndFrame.dlgExternalFileWizard.sCompany,\r\n" +
						"	  :i_hWndFrame.dlgExternalFileWizard.sClientServer,\r\n" +
						"	  :i_hWndFrame.dlgExternalFileWizard.sParamName,\r\n" +
						"	  :i_hWndFrame.dlgExternalFileWizard.sParamValue  )");
				}
				// Bug 86956, Begin
				// NOTE File Types such as 'ExtVoucher' will not have attribute NEW_COMPANY and new company value will get updated in both lsParamString.COMPANY and sCompany through Return_For_Trans_Form().
				// But File Types such as 'Bank Statement' will have attribute NEW_COMPANY and new company value will not get updated in both lsParamString.COMPANY and sCompany through Return_For_Trans_Form().
				TempMsg.Unpack(lsParamString);
				sTempValue = TempMsg.FindAttribute("NEW_COMPANY", Ifs.Fnd.ApplicationForms.Const.strNULL);
				if (sTempValue != Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
					sCompany = sTempValue;
					TempMsg.SetAttribute("COMPANY", sCompany);
					if (TempMsg.Pack() != lsParamString) 
					{
						lsParamString = TempMsg.Pack();
					}
				}
				// Bug 86956, End
				dfsFileName.EditDataItemSetEdited();
				dfsSetIdTest.EditDataItemSetEdited();
				sParamName = Ifs.Fnd.ApplicationForms.Const.strNULL;
				sParamValue = Ifs.Fnd.ApplicationForms.Const.strNULL;
				Sal.WaitCursor(false);
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber BrowseFile()
		{
			#region Local Variables
			cMessage MainMessage = new cMessage();
			SalString sDirection = "";
			SalBoolean bOk = false;
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				MainMessage.Unpack(lsParamString);
				sDirection = MainMessage.FindAttribute("FILE_DIRECTION_DB", Ifs.Fnd.ApplicationForms.Const.strNULL);
				using(SignatureHints hints = SignatureHints.NewContext())
				{
					hints.Add("In_Ext_File_Template_Dir_API.Get_Load_File_Type_List_Db", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
					if (!(DbPLSQLBlock(cSessionManager.c_hSql, ":i_hWndFrame.dlgExternalFileWizard.sloadProfileFileTypeList :=  &AO.In_Ext_File_Template_Dir_API.Get_Load_File_Type_List_Db(\r\n" +
						"                                                              :i_hWndFrame.dlgExternalFileWizard.dfsFileTemplateId,\r\n" +
						"                                                              :i_hWndFrame.dlgExternalFileWizard.sFileDirectionDb)"))) 
					{
						sloadProfileFileTypeList = "All Types^*";
					}
				}
				bOk = UnpackFileTypeList(sloadProfileFileTypeList, sDecodedFileList, ref nCnt);
				if (sDirection == "1") 
				{
					if (bOk) 
					{
						if (Sal.DlgOpenFile(i_hWndFrame, "Open File", sDecodedFileList, nCnt, ref nIndex, ref strFile, ref strPath) == true) 
						{
							// Bug 79498 Begin
							if (strPath.Length > 259) 
							{
								Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_MaximumLengthFileName, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
								return false;
							}
							// Bug 79498 End
							dfsFileName.Text = strPath;
						}
					}
				}
				else if (sDirection == "2") 
				{
					if (Sal.DlgSaveFile(i_hWndFrame, "Save File", strFilters, 6, ref nIndex, ref strFile, ref strPath)) 
					{
						dfsFileName.Text = strPath;
					}
				}
				sParamName = "FILE_NAME";
				sParamValue = dfsFileName.Text;
				ChangeParamValues();
				pbNext.MethodInvestigateState();
				pbFinish.MethodInvestigateState();
				return true;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="sPlanStr"></param>
		/// <returns></returns>
		public virtual SalBoolean BuildExecPlan(ref SalString sPlanStr)
		{
			#region Local Variables
			SalString sDate = "";
			SalString sTime = "";
			SalString sDays = "";
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				if (rbOnline.Checked) 
				{
					sPlanStr = "ONLINE";
				}
			}

			return false;
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
				UserGlobalValueGet("COMPANY", ref sCompany);
				// Bug 72340,  Removed unnecessary code.
				bEditFileType = false;
				// Disable Batch if not Utl_File_Dir exists
				if (strUtilFileDirection == "NULL") 
				{
					Sal.DisableWindowAndLabel(rbBatch);
				}
				else
				{
					Sal.EnableWindowAndLabel(rbBatch);
				}
				strMultiDirection = "FALSE";
				return true;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean CreateLoadId()
		{
			#region Actions
			using (new SalContext(this))
			{
				using(SignatureHints hints = SignatureHints.NewContext())
				{
					hints.Add("EXT_FILE_LOAD_API.Create_Load_Id_Param", System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.Input);
					if (!(DbPLSQLTransaction(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "EXT_FILE_LOAD_API.Create_Load_Id_Param(\r\n" +
						"                :i_hWndFrame.dlgExternalFileWizard.nLoadFileId,\r\n" +
						"                :i_hWndFrame.dlgExternalFileWizard.lsParamString )"))) 
					{
						return false;
					}
				}
				return true;
			}
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
				if (sMethod == "Browse") 
				{
					if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire) 
					{
						if (rbBatch.Checked) 
						{
							return false;
						}
						if (lsParamString == Ifs.Fnd.ApplicationForms.Const.strNULL) 
						{
							return false;
						}
						return true;
					}
					if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
					{
						BrowseFile();
					}
				}
				if (sMethod == "List") 
				{
					switch (nWhat)
					{
						case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                            return (hWndLovField != SalWindowHandle.Null);
						
						case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                            if (hWndLovField != SalWindowHandle.Null) 
                            {
                                if (sSpecialLov != Ifs.Fnd.ApplicationForms.Const.strNULL) 
                                    return hWndLovField.SendMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemLov, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                                else
                                    Sal.SetFocus(hWndLovField);
                            }
                            break;
					}
				}
				return ((cWizardDialogBox)this).UserMethod(nWhat, sMethod);
			}
			#endregion
		}
		
		/// <summary>
		/// This is called when the 'Finish' option is selected.
		/// To check the possibility of terminating the application
		/// a METHOD_Inquire is passed.
		/// To terminate the application a METHOD_Execute is passed.
		/// </summary>
		/// <param name="nWhat"></param>
		/// <param name="sStep"></param>
		/// <returns></returns>
		public new SalBoolean WizardFinish(SalNumber nWhat, SalString sStep)
		{
			#region Local Variables
			cMessage MainMessage = new cMessage();
			cMessage Mandatory = new cMessage();
			cMessage NonMandatory = new cMessage();
			SalString sDirection = "";
            SalString sFileType = "";
			SalString sDrive = "";
			SalString sDir = "";
			SalString sFile = "";
			SalString sExt = "";
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire) 
				{
					if (sStep == "step3") 
					{
						return true;
					}
					return false;
				}
				if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
				{
					if (rbOnline.Checked) 
					{
						MainMessage.Unpack(lsParamString);
						sDirection = MainMessage.FindAttribute("FILE_DIRECTION_DB", Ifs.Fnd.ApplicationForms.Const.strNULL);
						if (sDirection == "1") 
						{
							// Bug 68596,  Begin
							sLoadType = MainMessage.FindAttribute("LOAD_TYPE", "NOT_EXISTS");
                            sFileType = MainMessage.FindAttribute("FILE_TYPE", Ifs.Fnd.ApplicationForms.Const.strNULL);
                            if (sLoadType == SalString.Null && sFileType == "ExtVoucher") 
							{
								Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_LoadTypeMissing, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
								return false;
							}
							// Bug 68596,  End
							if (!(OnlineReadFile())) 
							{
								return false;
							}
						}
						else if (sDirection == "2") 
						{
							OnlineWriteFile();
						}
						return Sal.EndDialog(this, 0);
					}
					if (rbBatch.Checked) 
					{
						using(SignatureHints hints = SignatureHints.NewContext())
						{
							hints.Add("Ext_File_Batch_Param_API.New_Batch_Param", System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Input);
							if (DbPLSQLTransaction(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "Ext_File_Batch_Param_API.New_Batch_Param(\r\n" +
								"                :i_hWndFrame.dlgExternalFileWizard.nParamNo,\r\n" +
								"                :i_hWndFrame.dlgExternalFileWizard.lsParamString )")) 
							{
								if (!(HandleSqlResult(lsTemp))) 
								{
									return false;
								}
								Mandatory.AddAttribute("PARAMETER_STRING_", nParamNo.ToString(0));
								Ifs.Fnd.ApplicationForms.Var.TaskScheduler.ScheduleWithParams(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, "EXTERNAL_FILE_UTILITY_API.EXECUTE_BATCH_PROCESS2", Mandatory, NonMandatory);
								return Sal.EndDialog(this, 0);
							}
						}
						return true;
					}
				}
			}

			return false;
			#endregion
		}
		
		/// <summary>
		/// The WizardNext hook function is called by the framework when the user
		/// selectes the Next button. Applications should override this function to
		/// add extra checks to see if the Next operation is available, or extra
		/// statements to be executed when the user chooses Next.
		/// COMMENTS:
		/// If standard behavior is desired, there is no need to override this function.
		/// </summary>
		/// <param name="nWhat"></param>
		/// <param name="sStep">
		/// Step name
		/// Name of the next step - the step that will be acivated after this function returns.
		/// </param>
		/// <returns></returns>
		public new SalBoolean WizardNext(SalNumber nWhat, SalString sStep)
		{
			#region Local Variables
			SalString sDrive = "";
			SalString sDir = "";
			SalString sFile = "";
			SalString sExt = "";
			// Bug 69856 Begin
			SalArray<SalString> sParam = new SalArray<SalString>();
			// Bug 69856 End
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire) 
				{
					if (m_nCurrentPage == 0) 
					{
						return true;
					}
					if (m_nCurrentPage == 1) 
					{
						// Bug 69856 Start
						if (dfsSetIdTest.Text == Ifs.Fnd.ApplicationForms.Const.strNULL) 
						{
							return false;
						}
						// Bug 69856 End
						if (rbOnline.Checked) 
						{
							if (cbInput.Checked) 
							{
								// Bug 79498 Begin
								// If VisDosExist (dfsFileName) AND dfsFileType != strNULL AND dfsFileTemplateId != strNULL
								// Return TRUE
								return true;
								// Bug 79498 End
							}
							if (cbOutput.Checked) 
							{
								Vis.DosSplitPath(dfsFileName.Text, ref sDrive, ref sDir, ref sFile, ref sExt);
								if (Vis.DosExist(sDrive + sDir) && sFile != Ifs.Fnd.ApplicationForms.Const.strNULL) 
								{
									return true;
								}
							}
						}
						if (rbBatch.Checked) 
						{
							if (dfsFileName.Text != Ifs.Fnd.ApplicationForms.Const.strNULL && dfsFileTemplateId.Text != Ifs.Fnd.ApplicationForms.Const.strNULL && dfsFileTemplateId.Text != Ifs.Fnd.ApplicationForms.Const.strNULL) 
							{
								return true;
							}
						}
					}
					return false;
				}
				else if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
				{
					// Bug 72340, Begin.
					if (g_CheckNav == "EXTCUSTINV") 
					{
						_i_Step[m_nCurrentPage + 1].i_sTitle = Properties.Resources.TEXT_ExtCustInvoice;
					}
					else if (g_CheckNav == "EXTSUPPINV") 
					{
						_i_Step[m_nCurrentPage + 1].i_sTitle = Properties.Resources.TEXT_ExtSuppInvoice;
					}
					else if (g_CheckNav == "EXTVOUCHER") 
					{
						_i_Step[m_nCurrentPage + 1].i_sTitle = Properties.Resources.TEXT_ExtFileVoucher;
					}
					else if (g_CheckNav == "EXTCURUPD") 
					{
						_i_Step[m_nCurrentPage + 1].i_sTitle = Properties.Resources.TEXT_ExtCurrUpd;
					}
					// Bug 72340, End.
					// Bug 92463 Begin
					else if (g_CheckNav == "MANDATETOPI") 
					{
						_i_Step[m_nCurrentPage + 1].i_sTitle = Properties.Resources.TEXT_MandateToPi;
					}
					// Bug 92463 End
					if (sStep == "step4") 
					{
						WizardIsLastStep();
						return true;
					}
					if (sStep == "step3") 
					{
						// Bug 69856 Begin, ',' is added as a parameter just in a case if character , causes a prob for another lang
						// Bug 69856 Start
						if (dfsSetIdTest.Text == Ifs.Fnd.ApplicationForms.Const.strNULL) 
						{
							sParam[0] = ",";
							Ifs.Fnd.ApplicationForms.Int.AlertBoxWithParams(Properties.Resources.TEXT_SetIdMissing, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.INFO_Ok, sParam);
							return false;
						}
						else
						{
							using(SignatureHints hints = SignatureHints.NewContext())
							{
								hints.Add("EXT_TYPE_PARAM_SET_API.Check_Exist", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
								if (!(DbPLSQLBlock(cSessionManager.c_hSql, ":i_hWndFrame.dlgExternalFileWizard.sExist := " + cSessionManager.c_sDbPrefix + "EXT_TYPE_PARAM_SET_API.Check_Exist(\r\n" +
									"                                                                             :i_hWndFrame.dlgExternalFileWizard.dfsFileType,\r\n" +
									"                                                                             :i_hWndFrame.dlgExternalFileWizard.dfsSetIdTest)"))) 
								{
									return false;
								}
							}
							if (sExist == "FALSE") 
							{
								Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_SetIdError, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
								return false;
							}
						}
						// Bug 69856 End
						// Bug 69856 End
						// Bug 79498 Begin
						if (rbOnline.Checked) 
						{
							if (cbInput.Checked) 
							{
								if (!(Vis.DosExist(strPath)) && strPath != Ifs.Fnd.ApplicationForms.Const.strNULL && dfsFileType.Text != Ifs.Fnd.ApplicationForms.Const.strNULL && dfsFileTemplateId.Text != Ifs.Fnd.ApplicationForms.Const.strNULL) 
								{
									Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_ExtFilePathDoesNotExist, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
									return false;
								}
							}
						}
						if (strPath.Length > 259) 
						{
							Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_MaximumLengthFileName, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
							return false;
						}
						// Bug 79498 End
						dfsFileType2.Text = dfsFileType.Text;
						dfsSetId2.Text = dfsSetIdTest.Text;
						using(SignatureHints hints = SignatureHints.NewContext())
						{
							hints.Add("EXT_TYPE_PARAM_SET_API.Get_Description", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
							if (!(DbPLSQLBlock(cSessionManager.c_hSql, ":i_hWndFrame.dlgExternalFileWizard.dfsSetIdDescription := " + cSessionManager.c_sDbPrefix + "EXT_TYPE_PARAM_SET_API.Get_Description(\r\n" +
								"                                                                             :i_hWndFrame.dlgExternalFileWizard.dfsFileType,\r\n" +
								"                                                                             :i_hWndFrame.dlgExternalFileWizard.dfsSetIdTest)"))) 
							{
								return false;
							}
						}
						using(SignatureHints hints = SignatureHints.NewContext())
						{
							hints.Add("EXT_FILE_TYPE_API.Get_Description", System.Data.ParameterDirection.Input);
							if (!(DbPLSQLBlock(cSessionManager.c_hSql, ":i_hWndFrame.dlgExternalFileWizard.dfsFileTypeDescription := " + cSessionManager.c_sDbPrefix + "EXT_FILE_TYPE_API.Get_Description(\r\n" +
								"                                                                             :i_hWndFrame.dlgExternalFileWizard.dfsFileType)"))) 
							{
								return false;
							}
						}
						this.PopulateFromView();
						this.PopulateValues();
						this.FixLooks();
						WizardCurrentStepSet("step3");
                        Sal.HideWindow(labeldfsFileType);
                        Sal.HideWindow(dfsFileType);
                        Sal.ShowWindow(dfsFileTypeDescription);
                        Sal.ShowWindow(labeldfsFileType2);
                        Sal.ShowWindow(dfsFileType2);
					}
					if (sStep == "step2") 
					{
						// Bug 72340, Begin.
						// bug 90267 begin
						if (rbOnline.Checked) 
						{
							sClientServer = "C";
							Sal.ShowWindowAndLabel(pbBrowse);
						}
						else
						{
							sClientServer = "S";
							Sal.HideWindowAndLabel(pbBrowse);
						}
						// bug 90267 end
						Sal.HideWindowAndLabel(dfHeading);
						Sal.HideWindowAndLabel(dfHeadingVou);
						Sal.HideWindowAndLabel(dfHeadingCustInv);
						Sal.HideWindowAndLabel(dfHeadingSuppInv);
						Sal.HideWindowAndLabel(dfHeadingCurrUpd);
						// Bug 92463 Begin
						Sal.HideWindowAndLabel(dfHeadingMandToPi);
						// Bug 92463 End
						// Bug 72340, End.
						// bug 90267 begin
						if (g_CheckNav == "EXTCUSTINV") 
						{
							dfsFileType.Text = "ExtCustInv";
							dfsFileType.EditDataItemSetEdited();
							Sal.SendMsg(dfsFileType, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
							bEditFileType = true;
						}
						if (g_CheckNav == "EXTSUPPINV") 
						{
							dfsFileType.Text = "ExtSuppInv";
							dfsFileType.EditDataItemSetEdited();
							Sal.SendMsg(dfsFileType, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
							bEditFileType = true;
						}
						if (g_CheckNav == "EXTVOUCHER") 
						{
							dfsFileType.Text = "ExtVoucher";
							dfsFileType.EditDataItemSetEdited();
							Sal.SendMsg(dfsFileType, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
							bEditFileType = true;
						}
						if (g_CheckNav == "EXTCURUPD") 
						{
							dfsFileType.Text = "ExtCurrency";
							dfsFileType.EditDataItemSetEdited();
							Sal.SendMsg(dfsFileType, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
							bEditFileType = true;
						}
						// bug 90267 end
						// Bug 92463 Begin
						if (g_CheckNav == "MANDATETOPI") 
						{
							dfsFileType.Text = "MandateToPi";
							dfsFileType.EditDataItemSetEdited();
							Sal.SendMsg(dfsFileType, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
							bEditFileType = true;
						}
						// Bug 92463 End
						pbBrowse.MethodInvestigateState();
						return true;
					}
				}
			}

			return false;
			#endregion
		}
		
		/// <summary>
		/// The WizardPrevious hook function is called by the framework when the user
		/// selectes the Previous button. Applications should override this function to
		/// add extra checks to see if the Previous operation is available, or extra
		/// statements to be executed when the user chooses Previous.
		/// COMMENTS:
		/// If standard behavior is desired, there is no need to override this function.
		/// </summary>
		/// <param name="nWhat"></param>
		/// <param name="sStep">
		/// Step name
		/// Name of the previous step - the step that will be acivated after this function returns.
		/// </param>
		/// <returns></returns>
		public new SalBoolean WizardPrevious(SalNumber nWhat, SalString sStep)
		{
			#region Actions
			using (new SalContext(this))
			{
				if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire) 
				{
					return m_nCurrentPage > 0;
				}
				else
				{
					// Bug 67661, Begin
					sSpecialLov = Ifs.Fnd.ApplicationForms.Const.strNULL;
					// Bug 67661, End
					// Bug 72340, Begin
					if (g_CheckNav == "EXTCUSTINV") 
					{
						_i_Step[m_nCurrentPage - 1].i_sTitle = Properties.Resources.TEXT_ExtCustInvoice;
						if (m_nCurrentPage == 1) 
						{
							Sal.ShowWindowAndLabel(dfHeadingCustInv);
						}
					}
					else if (g_CheckNav == "EXTSUPPINV") 
					{
						_i_Step[m_nCurrentPage - 1].i_sTitle = Properties.Resources.TEXT_ExtSuppInvoice;
						if (m_nCurrentPage == 1) 
						{
							Sal.ShowWindowAndLabel(dfHeadingSuppInv);
						}
					}
					else if (g_CheckNav == "EXTVOUCHER") 
					{
						_i_Step[m_nCurrentPage - 1].i_sTitle = Properties.Resources.TEXT_ExtFileVoucher;
						if (m_nCurrentPage == 1) 
						{
							Sal.ShowWindowAndLabel(dfHeadingVou);
						}
					}
					else if (g_CheckNav == "EXTCURUPD") 
					{
						_i_Step[m_nCurrentPage - 1].i_sTitle = Properties.Resources.TEXT_ExtCurrUpd;
						if (m_nCurrentPage == 1) 
						{
							Sal.ShowWindowAndLabel(dfHeadingCurrUpd);
						}
					}
					// Bug 92463 Begin
					else if (g_CheckNav == "MANDATETOPI") 
					{
						_i_Step[m_nCurrentPage - 1].i_sTitle = Properties.Resources.TEXT_MandateToPi;
						if (m_nCurrentPage == 1) 
						{
							Sal.ShowWindowAndLabel(dfHeadingSuppInv);
						}
					}
					// Bug 92463 End
					else
					{
						if (m_nCurrentPage == 1) 
						{
							Sal.ShowWindowAndLabel(dfHeading);
						}
					}
					// Bug 72340, End.
					if (rbBatch.Checked) 
					{
						if (m_nCurrentPage == 1) 
						{
							WizardCurrentStepSet("step1");
						}
						if (m_nCurrentPage == 2) 
						{
							WizardCurrentStepSet("step2");
						}
						if (m_nCurrentPage == 3) 
						{
							if (dfsSetIdTest.Text == Ifs.Fnd.ApplicationForms.Const.strNULL) 
							{
								WizardCurrentStepSet("step2");
							}
							else
							{
								WizardCurrentStepSet("step3");
							}
						}
					}
					else
					{
						return true;
					}
				}
			}

			return false;
			#endregion
		}
		
		/// <summary>
		/// The WizardIsLastStep function checks if the currently active step is the last
		/// step (as defined in Foundation1 properties).
		/// </summary>
		/// <returns></returns>
		public virtual new SalBoolean WizardIsLastStep()
		{
			#region Actions
			using (new SalContext(this))
			{
				if (rbOnline.Checked) 
				{
					return m_nCurrentPage == (m_nTotalPages - 1);
				}
				else
				{
					return m_nCurrentPage == (m_nTotalPages - 2);
				}
			}
			#endregion
		}
		// Output Online
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber OnlineWriteFile()
		{
			#region Actions
			using (new SalContext(this))
			{
				Sal.WaitCursor(true);
				if (CreateLoadId()) 
				{
					// Bug 77126 Begin
					using(SignatureHints hints = SignatureHints.NewContext())
					{
						hints.Add("External_File_Utility_API.Start_Api_To_Call", System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.Input);
						if (DbPLSQLTransaction(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "External_File_Utility_API.Start_Api_To_Call (\r\n" +
							"                  :i_hWndFrame.dlgExternalFileWizard.lsTemp,\r\n" +
							"	  :i_hWndFrame.dlgExternalFileWizard.nLoadFileId )")) 
						{
							using(SignatureHints hints1 = SignatureHints.NewContext())
							{
								hints1.Add("External_File_Utility_API.Pack_Out_Ext_Line", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
								if (DbPLSQLTransaction(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "External_File_Utility_API.Pack_Out_Ext_Line(\r\n" +
									"                  :i_hWndFrame.dlgExternalFileWizard.dfsFileType,\r\n" +
									"	  :i_hWndFrame.dlgExternalFileWizard.dfsFileTemplateId,\r\n" +
									"                  :i_hWndFrame.dlgExternalFileWizard.nLoadFileId,\r\n" +
									"	  :i_hWndFrame.dlgExternalFileWizard.sCompany )")) 
								{
									using(SignatureHints hints2 = SignatureHints.NewContext())
									{
										hints2.Add("External_File_Utility_API.Modify_File_Name", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.InputOutput);
										if (DbPLSQLTransaction(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "External_File_Utility_API.Modify_File_Name(\r\n" +
											"                  :i_hWndFrame.dlgExternalFileWizard.nLoadFileId,\r\n" +
											"	  :i_hWndFrame.dlgExternalFileWizard.dfsFileName )")) 
										{
											strPath = dfsFileName.Text;
											sState = "7";
											using(SignatureHints hints3 = SignatureHints.NewContext())
											{
												hints3.Add("Ext_File_Load_API.Update_State", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
												if (DbPLSQLTransaction(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "Ext_File_Load_API.Update_State(\r\n" +
													"                  :i_hWndFrame.dlgExternalFileWizard.nLoadFileId,\r\n" +
													"	  :i_hWndFrame.dlgExternalFileWizard.sState )")) 
												{
													if (!(HandleSqlResult(lsTemp))) 
													{
														Sal.WaitCursor(false);
														return false;
													}
													Sal.WaitCursor(false);
												}
											}
										}
										}
									using(SignatureHints hints2 = SignatureHints.NewContext())
									{
										hints2.Add("External_File_Utility_API.Create_Xml_File", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Output);
										if (!(DbPLSQLTransaction(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "External_File_Utility_API.Create_Xml_File(\r\n" +
											"                  :i_hWndFrame.dlgExternalFileWizard.nLoadFileId,\r\n" +
											"	  :i_hWndFrame.dlgExternalFileWizard.sIsXmlType )"))) 
										{
											HandleSqlResult(lsTemp);
											return false;
										}
									}
								}
								}
						}
							}
					if (sIsXmlType == "FALSE") 
					{
						if (!(HandleSqlResult(lsTemp))) 
						{
							Sal.WaitCursor(false);
							return false;
						}
						if (OpenOutClientFile()) 
						{
							OutputClientFile();
							Sal.WaitCursor(false);
							return true;
						}
						else
						{
							Sal.WaitCursor(false);
							return false;
						}
					}
					// Bug 77126 End
				}
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean OpenOutClientFile()
		{
			#region Actions
			using (new SalContext(this))
			{
				if (!(hSrcHandle.Open(strPath, (Sys.OF_Create | Sys.OF_Write)))) 
				{
					Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.ERROR_FileWrite, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
					return false;
				}
				return true;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber OutputClientFile()
		{
			#region Local Variables
			cMessage MainMessage = new cMessage();
			cMessage SubMessage = new cMessage();
			SalString lsFileLine = "";
			SalNumber nCount = 0;
			SalNumber nNum = 0;
			SalNumber nSubNum = 0;
			SalNumber nRowWrite = 0;
			SalArray<SalString> sNames = new SalArray<SalString>();
			SalArray<SalString> sSubNames = new SalArray<SalString>();
			SalArray<SalString> sValues = new SalArray<SalString>();
			SalArray<SalString> sSubValues = new SalArray<SalString>();
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				nRowno = 0;
				nRowWrite = 0;
				sAction = "FALSE";
				nRowCount = 0;
				while (sAction == "FALSE") 
				{
					// Do not user DbPLSQLTransaction!! This is done in a loop
					using(SignatureHints hints = SignatureHints.NewContext())
					{
						hints.Add("External_File_Utility_API.Create_Output_Message", System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.Input);
						if (!(DbPLSQLBlock(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "External_File_Utility_API.Create_Output_Message(\r\n" +
							" 	  :i_hWndFrame.dlgExternalFileWizard.lsParamString,\r\n" +
							"                  :i_hWndFrame.dlgExternalFileWizard.sAction,\r\n" +
							"	  :i_hWndFrame.dlgExternalFileWizard.nRowCount,\r\n" +
							"                  :i_hWndFrame.dlgExternalFileWizard.nRowno,\r\n" +
							"                  :i_hWndFrame.dlgExternalFileWizard.nLoadFileId )"))) 
						{
							return false;
						}
					}
					MainMessage.Unpack(lsParamString);
					nNum = MainMessage.EnumAttributes(sNames, sValues);
					nNum = nRowCount;
					nCount = 0;
					while (nNum > 0) 
					{
						SubMessage.Unpack(sValues[nCount]);
						nCount = nCount + 1;
						nRowWrite = nRowWrite + 1;
						nSubNum = SubMessage.EnumAttributes(sSubNames, sSubValues);
						lsFileLine = SubMessage.GetAttribute("FILE_LINE");
						if (!(hSrcHandle.PutString(lsFileLine))) 
						{
							Sal.WaitCursor(false);
							Ifs.Fnd.ApplicationForms.Int.ErrorBox(Properties.Resources.ERROR_FileWrite);
							return false;
						}
						nNum = nNum - 1;
					}
					Sal.WaitCursor(false);
				}
				MethodProgressStep();
				hSrcHandle.Close();
				if (nRowWrite == 0) 
				{
					Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_NoFileLineWritten, Properties.Resources.TEXT_TitleExternalFileOutput, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
				}
				else
				{
                    // Bug 107093 Begin
                    if (Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("EXT_PAYMENT_HISTORY_API") && dfsFileType.Text == "MandateToPi") 
                    {
                        Sal.WaitCursor(true);
                        using (SignatureHints hints = SignatureHints.NewContext())
                        {
                            hints.Add("Ext_Payment_History_API.Make_New", System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                            DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN &AO.Ext_Payment_History_API.Make_New(\r\n" +
                                "                               :i_hWndFrame.dlgExternalFileWizard.dfsFileName,\r\n" +
                                "                               :i_hWndFrame.dlgExternalFileWizard.sCompany,\r\n" +
                                "                               '*',\r\n" +
                                "                               'FALSE',\r\n" +
                                "                               'FALSE',\r\n" +
                                "                               'FALSE',\r\n" +
                                "                               'FALSE'); END;");
                        }
                        Sal.WaitCursor(false);
                    }
                    // Bug 107093 End
					Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_FinishWriteFile, Properties.Resources.TEXT_TitleExternalFileOutput, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
				}
				return true;
			}
			#endregion
		}
		// Input online
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber LoadClientFile()
		{
			#region Actions
			using (new SalContext(this))
			{
				// Do not user DbPLSQLTransaction!! This is done in a loop
				using(SignatureHints hints = SignatureHints.NewContext())
				{
					hints.Add("External_File_Utility_API.Load_Client_File_", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
					if (!(DbPLSQLBlock(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "External_File_Utility_API.Load_Client_File_(\r\n" +
						" 	  :i_hWndFrame.dlgExternalFileWizard.sAction,\r\n" +
						"                  :i_hWndFrame.dlgExternalFileWizard.nLoadFileId,\r\n" +
						"	  :i_hWndFrame.dlgExternalFileWizard.dfsFileTemplateId,\r\n" +
						"                  :i_hWndFrame.dlgExternalFileWizard.dfsFileType,\r\n" +
						"                  :i_hWndFrame.dlgExternalFileWizard.lsMainMesgTemp,\r\n" +
						"	  :i_hWndFrame.dlgExternalFileWizard.sCompany,\r\n" +
						"                  :i_hWndFrame.dlgExternalFileWizard.strPath )"))) 
					{
						return false;
					}
				}
				return true;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber OnlineReadFile()
		{
			#region Actions
			using (new SalContext(this))
			{
				Sal.WaitCursor(true);
				// Note: Before copying, Load Id should be created. After copying, the OpenClientFile() will open the backup file for processing
				if (CreateLoadId()) 
				{
					if (CopyClientFile()) 
					{
						if (OpenClientFile()) 
						{
							ReadClientFile(0);
							DbTransactionEnd(cSessionManager.c_hSql);
							using(SignatureHints hints = SignatureHints.NewContext())
							{
								hints.Add("External_File_Utility_API.Unpack_Ext_Line", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
								if (DbPLSQLTransaction(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "External_File_Utility_API.Unpack_Ext_Line(\r\n" +
									"                  :i_hWndFrame.dlgExternalFileWizard.dfsFileType,\r\n" +
									"	  :i_hWndFrame.dlgExternalFileWizard.dfsFileTemplateId,\r\n" +
									"                  :i_hWndFrame.dlgExternalFileWizard.nLoadFileId,\r\n" +
									"	  :i_hWndFrame.dlgExternalFileWizard.sCompany )")) 
								{
									using(SignatureHints hints1 = SignatureHints.NewContext())
									{
										hints1.Add("External_File_Utility_API.Store_File_Identities", System.Data.ParameterDirection.Input);
										if (DbPLSQLTransaction(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "External_File_Utility_API.Store_File_Identities (\r\n" +
											"                  :i_hWndFrame.dlgExternalFileWizard.nLoadFileId )")) 
										{
											using(SignatureHints hints2 = SignatureHints.NewContext())
											{
												hints2.Add("External_File_Utility_API.Start_Api_To_Call", System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.Input);
												if (DbPLSQLTransaction(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "External_File_Utility_API.Start_Api_To_Call (\r\n" +
													"                  :i_hWndFrame.dlgExternalFileWizard.lsTemp,\r\n" +
													"	  :i_hWndFrame.dlgExternalFileWizard.nLoadFileId )")) 
												{
													Sal.WaitCursor(false);
													if (!(HandleSqlResult(lsTemp))) 
													{
														return false;
													}
													return true;
												}
											}
										}
										}
								}
									}
							if (!(HandleSqlResult(lsTemp))) 
							{
								return false;
							}
							Sal.WaitCursor(false);
						}
					}
				}
				Sal.WaitCursor(false);
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean OpenClientFile()
		{
			#region Local Variables
			SalString sPath = "";
			cMessage Msg = new cMessage();
            SalString lsReadFileLine = ""; 
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				Msg.Unpack(lsParamString);
				if (Msg.FindAttribute("FILE_NAME", Ifs.Fnd.ApplicationForms.Const.strNULL) != Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
					// Note: File name set to strPath which points to backup file created by CopyClientFile().
					sPath = strPath;
					sFileName = sPath;
                    // Bug 128652, Begin, If the encoding is UTF-8, open using UTF-8.
                    if (CheckFileEncoding(sPath))
                    {
                        if (hSrcHandle.Open(sPath, Sys.OF_Read | Sys.OF_UTF8))
                        {
                            return true;
                        }
                    }
                    else
                    {
                        if (hSrcHandle.Open(sPath, Sys.OF_Read))
                        {
                            return true;
                        }
                    }
                    // Bug 128652, End.
					Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.ERROR_FileRead, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
				}
				return false;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="p_nMess"></param>
		/// <returns></returns>
		public virtual SalNumber ReadClientFile(SalNumber p_nMess)
		{
			#region Local Variables
			SalBoolean bNewMsg = false;
			cMessage MainMessage = new cMessage();
			cMessage SubMessage = new cMessage();
			SalString lsReadFileLine = "";
			SalString lsSubMessage = "";
			SalNumber nCounter = 0;
			SalNumber nId = 0;
			SalNumber nRetValue = 0;
			SalNumber nRowCount = 0;
			SalArray<SalString> sParam = new SalArray<SalString>();
            SalArray<SalString> sSpecialChars = new SalArray<SalString>();
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
                // The following special characters should be ignored when reading the external file as they are used by foundation for special purposes.
                sSpecialChars[0] = ((char)28).ToString();
                sSpecialChars[1] = ((char)27).ToString();
                sSpecialChars[2] = ((char)26).ToString();
                sSpecialChars[3] = ((char)25).ToString();
                sSpecialChars[4] = ((char)24).ToString();
                sSpecialChars[5] = ((char)23).ToString();
                sSpecialChars[6] = ((char)22).ToString();
                sSpecialChars[7] = ((char)21).ToString();
                sSpecialChars[8] = ((char)20).ToString();
                sSpecialChars[9] = ((char)19).ToString();
                sSpecialChars[10] = ((char)18).ToString();
                sSpecialChars[11] = ((char)17).ToString();
                sSpecialChars[12] = ((char)16).ToString();
                sSpecialChars[13] = ((char)15).ToString();
                sSpecialChars[14] = ((char)14).ToString();

                MethodProgressStart(i_hWndSelf, Properties.Resources.TEXT_TitleExternalFileExt, Properties.Resources.TEXT_ReadExtFileOnlineExt, "FETCH", true, SalWindowHandle.Null);
				MethodProgressStepAdd(GetNumberOfLines());
				if (DbTransactionBegin(ref cSessionManager.c_hSql)) 
				{
					nRetValue = hSrcHandle.GetString(ref lsReadFileLine, 4009);
                    // Bug 123877,Begin.
                    cFinlibServices.RemoveBomCharactorFromString(ref lsReadFileLine);
                    // Bug 123877,End.                    
                    for (int i = 0; lsReadFileLine.Length > 0 && i < sSpecialChars.Length; i++)
                    {
                        lsReadFileLine = (SalString)lsReadFileLine.ToString().Replace(sSpecialChars[i], "");
                    }

					if (lsReadFileLine.Length > 4000) 
					{
						Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_FileLineExceedsLength, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
						hSrcHandle.Close();
						MethodProgressDone();
						return false;
					}
					nId = 0;
					bNewMsg = true;
					sAction = "NEW";
					nRowCount = 0;
					nCounter = 0;
					while (nRetValue > 0) 
					{
						nId = nId + 1;
						if (bNewMsg) 
						{
							lsMainMessage = Ifs.Fnd.ApplicationForms.Const.strNULL;
							MainMessage.Construct();
							MainMessage.SetName("EXT_FILE_INFO");
						}
                        while ((lsMainMesgTemp.Length < 16000) && (nRetValue > 0)) 
						{
                            if (lsReadFileLine.Length > 0)
                            {
                                MethodProgressStep();
                                nCounter = nCounter + 1;
                                sParam[0] = nCounter.ToString(0);
                                MethodProgressMessage(Ifs.Fnd.ApplicationForms.Int.TranslateConstantWithParams(Properties.Resources.TEXT_ReadingExtLineExt, sParam));
                                lsSubMessage = Ifs.Fnd.ApplicationForms.Const.strNULL;
                                SubMessage.Construct();
                                SubMessage.AddAttribute("FILE_LINE", lsReadFileLine);
                                lsSubMessage = SubMessage.Pack();
                                MainMessage.AddAttribute(nCounter.ToString(0), lsSubMessage);
                                lsMainMesgTemp = MainMessage.Pack();
                                nRowCount = nRowCount + 1;
                            }
                            
							nRetValue = hSrcHandle.GetString(ref lsReadFileLine, 4009);
                            for (int i = 0; lsReadFileLine.Length > 0 && i < sSpecialChars.Length; i++)
                            {
                                lsReadFileLine = (SalString)lsReadFileLine.ToString().Replace(sSpecialChars[i], "");
                            }
							if (lsReadFileLine.Length > 4000) 
							{
								Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_FileLineExceedsLength, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
								hSrcHandle.Close();
								MethodProgressDone();
								return false;
							}
						}
                        if (lsMainMesgTemp.Length >= 16000) 
						{
							bNewMsg = true;
							sAction = "ADD";
							LoadClientFile();
							nRowCount = 0;
							lsMainMesgTemp = SalString.Null;
						}
						sAction = "EXE";
					}
					MethodProgressStep();
					hSrcHandle.Close();
					if (sAction == "EXE") 
					{
						if (p_nMess == 1) 
						{
							if (nCounter == 0) 
							{
								Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_NoFileLineFoundExt, Properties.Resources.TEXT_TitleExternalFileExt, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
							}
							else
							{
								Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_FinishLoadFileExt, Properties.Resources.TEXT_TitleExternalFileExt, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
							}
						}
						MethodProgressDone();
						return LoadClientFile();
					}
					if (p_nMess == 1) 
					{
						if (nCounter == 0) 
						{
							Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_NoFileLineFoundExt, Properties.Resources.TEXT_TitleExternalFileExt, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
						}
						else
						{
							Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_FinishLoadFileExt, Properties.Resources.TEXT_TitleExternalFileExt, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
						}
					}
					MethodProgressDone();
					return true;
				}
				else
				{
					MethodProgressDone();
					return false;
				}
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean CopyClientFile()
		{
			#region Local Variables
			SalNumber nStatus = 0;
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				sLoadFileId = nLoadFileId.ToString(0);
				using(SignatureHints hints = SignatureHints.NewContext())
				{
					hints.Add("Ext_File_Template_API.Get_Backup_File_Name", System.Data.ParameterDirection.Input);
					if (!(DbPLSQLBlock(cSessionManager.c_hSql, ":i_hWndFrame.dlgExternalFileWizard.sBackPath :=  " + cSessionManager.c_sDbPrefix + "Ext_File_Template_API.Get_Backup_File_Name(\r\n" +
						":i_hWndFrame.dlgExternalFileWizard.sLoadFileId)"))) 
					{
						return false;
					}
				}
				if (sBackPath == Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
					return true;
				}
				nStatus = Sal.FileCopy(strPath, sBackPath, true);
				if (nStatus != 0) 
				{
                    Ifs.Fnd.ApplicationForms.Int.AlertBox("Filecopying failed. Destination: " + sBackPath + " Error code: " + nStatus.ToString(0), "Filecopy error", Ifs.Fnd.ApplicationForms.Const.WARNING_Ok);
					return false;
				}
				else
				{
					Vis.FileDelete(strPath);
					// Note: Set Original file path to backup file path. This needs to be done because it is the backup file that will be processed.
					strPath = sBackPath;
					return true;
				}
			}
			#endregion
		}
		
		/// <summary>
		/// The method will return an estimated number for the total number of lines
		/// in the file. This avoids going through the whole file.
		/// This estimates the number of files of the text mode file by dividing the size of the
		/// file with the width of the first line. Assuming the file is "square" the area is
		/// divided by the width to get the height (number of lines).
		/// IMPORTANT:
		/// Before calling this method:
		/// * file should be opened.
		/// * sFileName should point to the file.
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber GetNumberOfLines()
		{
			#region Local Variables
			SalNumber nFileSize = 0;
			SalNumber nRetValue = 0;
			SalString lsReadFileLine = "";
			SalNumber nTotalLineEstimate = 0;
			SalNumber nFileWidthEstimate = 0;
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				nFileSize = Vis.FileGetSize(sFileName);
				hSrcHandle.Seek(0, Sys.FILE_SeekBegin);
				// read the first line...
				nRetValue = hSrcHandle.GetString(ref lsReadFileLine, 4000);
				if (nRetValue > 0) 
				{
					nFileWidthEstimate = lsReadFileLine.Length;
					if (nFileWidthEstimate > 0) 
					{
						// read the next line also...
						nRetValue = hSrcHandle.GetString(ref lsReadFileLine, 4000);
						if (nRetValue > 0) 
						{
							nFileWidthEstimate = (nFileWidthEstimate + lsReadFileLine.Length) / 2;
						}
						// Estimate...
						nTotalLineEstimate = nFileSize / nFileWidthEstimate;
						Ifs.Fnd.ApplicationForms.Var.Console.Add("The estimated number of lines in the file: " + nTotalLineEstimate.ToString(0));
						hSrcHandle.Seek(0, Sys.FILE_SeekBegin);
						return nTotalLineEstimate;
					}
				}
				hSrcHandle.Seek(0, Sys.FILE_SeekBegin);
				return 1;
			}
			#endregion
		}
		
		/// <summary>
		/// Decodes the filetype list which is received from
		/// the server, and puts the decoded result into
		/// an array.
		/// </summary>
		/// <param name="p_sFileTypeListString"></param>
		/// <param name="p_sFileTypeListArray"></param>
		/// <param name="p_nRowCount"></param>
		/// <returns></returns>
		public virtual SalBoolean UnpackFileTypeList(SalString p_sFileTypeListString, SalArray<SalString> p_sFileTypeListArray, ref SalNumber p_nRowCount)
		{
			#region Local Variables
			SalNumber l_nElementCounter = 0;
            #endregion
			
			#region Actions
			using (new SalContext(this))
			{
				p_nRowCount = p_sFileTypeListString.Tokenize("", Ifs.Fnd.ApplicationForms.Const.OBJCON_KeySeparator, p_sFileTypeListArray);
                if (p_nRowCount == 0 || p_nRowCount.Mod(2) > 0) 
				{
					Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.EXTFILELIST_ColError + p_sFileTypeListString, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
					return false;
				}
				while (l_nElementCounter < p_nRowCount) 
				{
					if (l_nElementCounter.Mod(2) > 0) 
					{
                        if (p_sFileTypeListArray[0]== "All Types" || p_sFileTypeListArray[0]== "*")
                        {
                            // To support the old code when all files and types are defined
                            p_sFileTypeListArray[l_nElementCounter] = "*." + p_sFileTypeListArray[l_nElementCounter];
                        }
                        else
                        {
                            // To support the new code when a particular file name and all types are defined
                            p_sFileTypeListArray[l_nElementCounter] =  p_sFileTypeListArray[0] + "."  + p_sFileTypeListArray[l_nElementCounter];
                        }
                   	}
					l_nElementCounter = l_nElementCounter + 1;
				}
				return true;
			}
			#endregion
		}
		// Bug 72340, Begin
		/// <summary>
		/// The WizardCreate function is executed when a wizard is being created. Applications
		/// may override this function to perform startup activities in the wizard.
		/// COMMENTS:
		/// WizardCreate is executed after all the design-time steps have been created, but
		/// before the first step is activated.
		/// </summary>
		/// <returns></returns>
		public new SalNumber WizardCreate()
		{
			#region Local Variables
			SalString sOut = "";
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				g_CheckNav = iURL.iParameters.FindAttribute("VERSION", sOut);
				if (g_CheckNav == "EXTVOUCHER") 
				{
					Sal.ShowWindowAndLabel(dfHeadingVou);
				}
				else if (g_CheckNav == "EXTCUSTINV") 
				{
					Sal.ShowWindowAndLabel(dfHeadingCustInv);
				}
				else if (g_CheckNav == "EXTSUPPINV") 
				{
					Sal.ShowWindowAndLabel(dfHeadingSuppInv);
				}
				else if (g_CheckNav == "EXTCURUPD") 
				{
					Sal.ShowWindowAndLabel(dfHeadingCurrUpd);
				}
				// Bug 92463 Begin
				else if (g_CheckNav == "MANDATETOPI") 
				{
					Sal.ShowWindowAndLabel(dfHeadingMandToPi);
				}
				// Bug 92463 End
				else
				{
					Sal.ShowWindowAndLabel(dfHeading);
				}
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public new SalBoolean SetWindowTitle()
		{
			#region Local Variables
			SalString sNav = "";
			SalString sOut = "";
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				if (g_CheckNav == "EXTCUSTINV") 
				{
					return Sal.SetWindowText(i_hWndSelf, Properties.Resources.TEXT_ExtCustInvoice);
				}
				else if (g_CheckNav == "EXTSUPPINV") 
				{
					return Sal.SetWindowText(i_hWndSelf, Properties.Resources.TEXT_ExtSuppInvoice);
				}
				else if (g_CheckNav == "EXTVOUCHER") 
				{
					return Sal.SetWindowText(i_hWndSelf, Properties.Resources.TEXT_ExtFileVoucher);
				}
				else if (g_CheckNav == "EXTCURUPD") 
				{
					return Sal.SetWindowText(i_hWndSelf, Properties.Resources.TEXT_ExtCurrUpd);
				}
				// Bug 92463 Begin
				else if (g_CheckNav == "MANDATETOPI") 
				{
					return Sal.SetWindowText(i_hWndSelf, Properties.Resources.TEXT_MandateToPi);
				}
				// Bug 92463 End
			}

			return false;
			#endregion
		}

        // Bug 128652, Begin. 
        /// <summary>
        /// Check whether the encoding is UTF-8 or not.
        /// </summary>
        /// <param name="sPath"></param>
        /// <returns></returns>
        public virtual SalNumber CheckFileEncoding(SalString sPath)
        {
            #region Local Variables
            FileStream file;
            long originalSize;
            StreamReader reader;
            UTF8Encoding unicodeUtf8;
            byte[] inputFile;
            #endregion

            #region Actions
            file = new FileStream(sPath, FileMode.Open);
            originalSize = file.Length;
            reader = new StreamReader(file);
            file.Position = 0;
            unicodeUtf8 = new System.Text.UTF8Encoding();
            inputFile = unicodeUtf8.GetBytes(reader.ReadToEnd());
            file.Close();

            // TRUE if the encoding is UTF-8
            if (inputFile.Length == originalSize)
            {
                return true;
            }
            return false;
            #endregion
        }
        // Bug 128652, End.
		#endregion
		
		#region Window Actions
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void dlgExternalFileWizard_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Close:
					e.Handled = true;
					Sal.EndDialog(this.i_hWndFrame, Sys.IDOK);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void dfsFileType_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovUserOrderBy:
					e.Handled = true;
					e.Return = ((SalString)"FILE_TYPE").ToHandle();
					return;
				
				case Sys.SAM_SetFocus:
					this.dfsFileType_OnSAM_SetFocus(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
					this.dfsFileType_OnPM_DataItemValidate(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
					this.dfsFileType_OnPM_DataItemQueryEnabled(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovDone:
					e.Handled = true;
					e.Return = Sal.SendMsg(this.dfsFileType, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
					return;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfsFileType_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam)) 
			{
				if (this.dfsFileType.p_sLovReference != Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
					if (this.bEditFileType) 
					{
						this.hWndLovField = SalWindowHandle.Null;
					}
					else
					{
						this.hWndLovField = this.dfsFileType.i_hWndSelf;
					}
				}
				else
				{
					this.hWndLovField = SalWindowHandle.Null;
				}
				this.pbList.MethodInvestigateState();
			}
			#endregion
		}
		
		/// <summary>
		/// PM_DataItemValidate event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfsFileType_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
            // Bug 130527, Begin, Check whether the file type is changed, before performing the validate.
            if (this.dfsFileType.Text != Ifs.Fnd.ApplicationForms.Const.strNULL && (this.sFileType == Ifs.Fnd.ApplicationForms.Const.strNULL || this.dfsFileType.Text != this.sFileType))
			{
				Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
				this.dfsFileName.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
				this.dfsSetIdTest.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
				this.lsParamString = Ifs.Fnd.ApplicationForms.Const.strNULL;
				using(SignatureHints hints = SignatureHints.NewContext())
				{
					hints.Add("Ext_File_Type_API.Get_View_Name", System.Data.ParameterDirection.Input);
					hints.Add("Ext_File_Type_API.Get_Api_To_Call_Output", System.Data.ParameterDirection.Input);
					hints.Add("Ext_File_Message_API.Return_For_Trans_Form", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
					hints.Add("Accrul_Attribute_API.Get_Attribute_Value", System.Data.ParameterDirection.Input);
					if (!(this.dfsFileType.DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN :i_hWndFrame.dlgExternalFileWizard.sViewName := &AO.Ext_File_Type_API.Get_View_Name(\r\n" +
						"				:i_hWndFrame.dlgExternalFileWizard.dfsFileType);\r\n" +
						"				:i_hWndFrame.dlgExternalFileWizard.sPackageName := &AO.Ext_File_Type_API.Get_Api_To_Call_Output(\r\n" +
						"				:i_hWndFrame.dlgExternalFileWizard.dfsFileType);\r\n" +
						"				&AO.Ext_File_Message_API.Return_For_Trans_Form (\r\n" +
						"                  				:i_hWndFrame.dlgExternalFileWizard.dfsFileType,\r\n" +
						"	  				:i_hWndFrame.dlgExternalFileWizard.dfsSetIdTest,\r\n" +
						"	  				:i_hWndFrame.dlgExternalFileWizard.lsParamString,\r\n" +
						"	  				:i_hWndFrame.dlgExternalFileWizard.dfsFileTemplateId,\r\n" +
						"	  				:i_hWndFrame.dlgExternalFileWizard.sFileDirectionDb,\r\n" +
						"	  				:i_hWndFrame.dlgExternalFileWizard.sFileDirection,\r\n" +
						"	  				:i_hWndFrame.dlgExternalFileWizard.dfsFileName,\r\n" +
						"	  				:i_hWndFrame.dlgExternalFileWizard.sCompany,\r\n" +
						"	  				:i_hWndFrame.dlgExternalFileWizard.sClientServer,\r\n" +
						"	  				:i_hWndFrame.dlgExternalFileWizard.sParamName,\r\n" +
						"	  				:i_hWndFrame.dlgExternalFileWizard.sParamValue );\r\n" +
						"				:i_hWndFrame.dlgExternalFileWizard.strUtilFileDirection := &AO.Accrul_Attribute_API.Get_Attribute_Value(\r\n" +
						"				'UTL_FILE_DIR');\r\n" +
						"			    END;"))) 
					{
						e.Return = false;
						return;
					}
				}
				if (this.sViewName != Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
					if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsViewAvailable(this.sViewName))) 
					{
						this.dfsFileType.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
						Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.ERROR_FileTemplate, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
						e.Return = Sys.VALIDATE_Cancel;
						return;
					}
				}
				else
				{
					if (this.sPackageName != Ifs.Fnd.ApplicationForms.Const.strNULL) 
					{
						if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable(this.sPackageName))) 
						{
							this.dfsFileType.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
							Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.ERROR_FileTemplate, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
							e.Return = Sys.VALIDATE_Cancel;
							return;
						}
					}
				}
				this.dfsFileType.EditDataItemSetEdited();
				this.dfsFileName.EditDataItemSetEdited();
				this.dfsSetIdTest.EditDataItemSetEdited();
				this.sParamName = Ifs.Fnd.ApplicationForms.Const.strNULL;
				this.sParamValue = Ifs.Fnd.ApplicationForms.Const.strNULL;
				this.PopulateParamValues();
				if (this.dfsFileTemplateId.Text == Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
					this.dfsFileType.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
					e.Return = Sys.VALIDATE_Cancel;
					return;
				}
				this.pbFinish.MethodInvestigateState();
				this.pbNext.MethodInvestigateState();
				if (this.sClientServer == "C") 
				{
					this.pbBrowse.MethodInvestigateState();
				}
                // Bug 130527, Begin.
                bFileTypeChanged = true;
                this.sFileType = this.dfsFileType.Text;
                this.sSetId = this.dfsSetIdTest.Text;
                this.sFileTemplateId = this.dfsFileTemplateId.Text;
                Sal.SendMsg(this.dfsSetIdTest, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
                // Bug 130527, End.
				e.Return = Sys.VALIDATE_Ok;
				return;
			}
            // Bug 130527, End.
			e.Return = Sys.VALIDATE_Ok;
			return;
			#endregion
		}
		
		/// <summary>
		/// PM_DataItemQueryEnabled event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfsFileType_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (this.bEditFileType) 
			{
				e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
				return;
			}
			else
			{
				e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldEnabled;
				return;
			}
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void dfsSetIdTest_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
					this.dfsSetIdTest_OnPM_DataItemValidate(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovUserWhere:
					e.Handled = true;
					e.Return = ((SalString)("FILE_TYPE='" + this.dfsFileType.Text + "'")).ToHandle();
					return;
				
				case Sys.SAM_SetFocus:
					this.dfsSetIdTest_OnSAM_SetFocus(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// PM_DataItemValidate event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfsSetIdTest_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
            // Bug 130527, Begin, Perform validation only if SetId or FileType is changed.
            if (this.sSetId == Ifs.Fnd.ApplicationForms.Const.strNULL || this.dfsSetIdTest.Text != this.sSetId || bFileTypeChanged)
            {
                if (this.sFileDirectionDb == "1")
                {
                    using (SignatureHints hints = SignatureHints.NewContext())
                    {
                        hints.Add("Ext_File_Type_API.Get_Api_To_Call_Input", System.Data.ParameterDirection.Input);
                        if (!(this.dfsSetIdTest.DbPLSQLBlock(cSessionManager.c_hSql, ":i_hWndFrame.dlgExternalFileWizard.sPackageName :=  " + cSessionManager.c_sDbPrefix + "Ext_File_Type_API.Get_Api_To_Call_Input(\r\n" +
                            ":i_hWndFrame.dlgExternalFileWizard.dfsFileType)")))
                        {
                            e.Return = false;
                            return;
                        }
                    }
                    if (this.sPackageName != Ifs.Fnd.ApplicationForms.Const.strNULL)
                    {
                        if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable(this.sPackageName)))
                        {
                            this.dfsSetIdTest.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                            Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.ERROR_FileTemplate, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                            e.Return = Sys.VALIDATE_Cancel;
                            return;
                        }
                    }
                }
                this.sParamName = "SET_ID";
                this.sParamValue = this.dfsSetIdTest.Text;
                this.lsParamString = Ifs.Fnd.ApplicationForms.Const.strNULL;
                this.CreateParam();
                this.PopulateParamValues();
                this.sSetId = this.dfsSetIdTest.Text;
            }
            // Bug 130527, End.
			if (this.sClientServer == "C") 
			{
				this.pbBrowse.MethodInvestigateState();
			}
			this.pbFinish.MethodInvestigateState();
			this.pbNext.MethodInvestigateState();
			e.Return = Sys.VALIDATE_Ok;
			return;
			#endregion
		}
		
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfsSetIdTest_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam)) 
			{
				if (this.dfsSetIdTest.p_sLovReference != Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
					this.hWndLovField = this.dfsSetIdTest.i_hWndSelf;
				}
				else
				{
					this.hWndLovField = SalWindowHandle.Null;
				}
				this.pbList.MethodInvestigateState();
			}
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void dfsFileTemplateId_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovUserWhere:
					e.Handled = true;
					e.Return = ((SalString)("FILE_TYPE='" + this.dfsFileType.Text + "'")).ToHandle();
					return;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
					this.dfsFileTemplateId_OnPM_DataItemValidate(sender, e);
					break;
				
				case Sys.SAM_SetFocus:
					this.dfsFileTemplateId_OnSAM_SetFocus(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovDone:
					e.Handled = true;
					e.Return = Sal.SendMsg(this.dfsFileTemplateId, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
					return;
			}
			#endregion
		}
		
		/// <summary>
		/// PM_DataItemValidate event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfsFileTemplateId_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
		{
			#region Actions
            e.Handled = true;
            // Bug 130527, Begin, Perform validation only if FileTemplate is changed.
            if (this.sFileTemplateId == Ifs.Fnd.ApplicationForms.Const.strNULL || this.dfsFileTemplateId.Text != this.sFileTemplateId)
            {
                this.sParamName = "FILE_TEMPLATE_ID";
                this.sParamValue = this.dfsFileTemplateId.Text;
                this.dfsFileName.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                this.CreateParam();
                this.PopulateParamValues();
                this.pbFinish.MethodInvestigateState();
                this.pbNext.MethodInvestigateState();
                if (this.sClientServer == "C")
                {
                    this.pbBrowse.MethodInvestigateState();
                }
                this.sFileTemplateId = this.dfsFileTemplateId.Text;
            }
            // Bug 130527, End.
			e.Return = Sys.VALIDATE_Ok;
			return;
			#endregion
		}
		
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfsFileTemplateId_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam)) 
			{
				if (this.dfsFileTemplateId.p_sLovReference != Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
					this.hWndLovField = this.dfsFileTemplateId.i_hWndSelf;
				}
				else
				{
					this.hWndLovField = SalWindowHandle.Null;
				}
				this.pbList.MethodInvestigateState();
			}
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void cbInput_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Click:
					this.cbInput_OnSAM_Click(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_Click event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cbInput_OnSAM_Click(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (this.strMultiDirection != "TRUE") 
			{
				if (this.sFileDirection == "InputFile") 
				{
					this.cbInput.Checked = true;
					this.cbOutput.Checked = false;
				}
				else if (this.sFileDirection == "OutputFile") 
				{
					this.cbOutput.Checked = true;
					this.cbInput.Checked = false;
				}
				else
				{
					this.cbOutput.Checked = false;
					this.cbInput.Checked = false;
				}
				e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
				return;
			}
			else
			{
				this.cbInput.Checked = true;
				this.cbOutput.Checked = false;
				this.sFileDirection = "InputFile";
				this.sFileDirectionDb = "1";
				this.sParamName = "FILE_DIRECTION_DB";
				this.sParamValue = "1";
				this.dfsFileName.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                this.CreateParam();
				
			}
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void cbOutput_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Click:
					this.cbOutput_OnSAM_Click(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_Click event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cbOutput_OnSAM_Click(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (this.strMultiDirection != "TRUE") 
			{
				if (this.sFileDirection == "InputFile") 
				{
					this.cbInput.Checked = true;
					this.cbOutput.Checked = false;
				}
				else if (this.sFileDirection == "OutputFile") 
				{
					this.cbOutput.Checked = true;
					this.cbInput.Checked = false;
				}
				else
				{
					this.cbOutput.Checked = false;
					this.cbInput.Checked = false;
				}
				e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
				return;
			}
			else
			{
				this.cbOutput.Checked = true;
				this.cbInput.Checked = false;
				this.sFileDirection = "OutputFile";
				this.sFileDirectionDb = "2";
				this.sParamName = "FILE_DIRECTION_DB";
				this.sParamValue = "2";
				this.dfsFileName.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
				this.CreateParam();
				this.PopulateParamValues();
			}
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void dfsFileName_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
					this.dfsFileName_OnPM_DataItemValidate(sender, e);
					break;
				
				case Sys.SAM_SetFocus:
					this.dfsFileName_OnSAM_SetFocus(sender, e);
					break;
				
				case Sys.SAM_AnyEdit:
					this.dfsFileName_OnSAM_AnyEdit(sender, e);
					break;
				
				// bug 90267 begin
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
					this.dfsFileName_OnPM_DataItemQueryEnabled(sender, e);
					break;
				
				// bug 90267 end
			}
			#endregion
		}
		
		/// <summary>
		/// PM_DataItemValidate event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfsFileName_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.dfsFileName.EditDataItemSetEdited();
			this.sParamName = "FILE_NAME";
			this.sParamValue = this.dfsFileName.Text;
			this.strPath = this.dfsFileName.Text;
			this.ChangeParamValues();
            this.pbFinish.MethodInvestigateState();
			this.pbNext.MethodInvestigateState();
			e.Return = Sys.VALIDATE_Ok;
			return;
			#endregion
		}
		
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfsFileName_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam)) 
			{
				if (this.dfsFileName.p_sLovReference != Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
					this.hWndLovField = this.dfsFileName.i_hWndSelf;
				}
				else
				{
					this.hWndLovField = SalWindowHandle.Null;
				}
				this.pbList.MethodInvestigateState();
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_AnyEdit event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfsFileName_OnSAM_AnyEdit(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (this.rbBatch.Checked) 
			{
				this.pbNext.MethodInvestigateState();
			}
			#endregion
		}
		
		/// <summary>
		/// PM_DataItemQueryEnabled event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfsFileName_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (!(this.rbOnline.Checked)) 
			{
				e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
				return;
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
		public override SalBoolean vrtSetWindowTitle()
		{
			return this.SetWindowTitle();
		}
		
		/// <summary>
		/// Virtual wrapper replacement for late-bound (..) calls.
		/// </summary>
		public override SalNumber vrtUserMethod(SalNumber nWhat, SalString sMethod)
		{
			return this.UserMethod(nWhat, sMethod);
		}
		
		/// <summary>
		/// Virtual wrapper replacement for late-bound (..) calls.
		/// </summary>
		public override SalNumber vrtWizardCreate()
		{
            m_nTotalPages = 3;
			return this.WizardCreate();
		}
		
		/// <summary>
		/// Virtual wrapper replacement for late-bound (..) calls.
		/// </summary>
		public override SalBoolean vrtWizardFinish(SalNumber nWhat, SalString sStep)
		{
			return this.WizardFinish(nWhat, sStep);
		}
		
		/// <summary>
		/// Virtual wrapper replacement for late-bound (..) calls.
		/// </summary>
		public override SalBoolean vrtWizardNext(SalNumber nWhat, SalString sStep)
		{
            // Bug 93702 , Begin - Correction is only done in IEE.
            if (sStep == "step4")
            {
                Sal.HideWindow(labeldfsFileType);
                Sal.HideWindow(dfsFileType);
                Sal.ShowWindow(dfsFileTypeDescription);
                Sal.ShowWindow(labeldfsFileType2);
                Sal.ShowWindow(dfsFileType2);
                return this.WizardNext(nWhat, sStep);
            }
            else
            {
                return this.WizardNext(nWhat, sStep);
            }
            // Bug 93702, End
		}
		
		/// <summary>
		/// Virtual wrapper replacement for late-bound (..) calls.
		/// </summary>
		public override SalBoolean vrtWizardPrevious(SalNumber nWhat, SalString sStep)
		{
            // Bug 93702 , Begin-Correction is only done in IEE.
            if (sStep == "step2")
            {
                Sal.ShowWindow(labeldfsFileType);
                Sal.ShowWindow(dfsFileType);
                Sal.HideWindow(labeldfsFileType2);
                Sal.HideWindow(dfsFileType2);
                Sal.HideWindow(dfsFileTypeDescription);
                // Bug 130527, Begin.
                this.bFileTypeChanged = false;
                // Bug 130527, End.
                return this.WizardPrevious(nWhat, sStep);
            }
            else
            {
                return this.WizardPrevious(nWhat, sStep);
            }
            // Bug 93702 , End
		}
		#endregion
		
		#region ChildTable - tblExternalFileParam
			
		#region Window Variables
		public SalNumber nNum = 0;
		public SalNumber nNumMax = 0;
		public SalNumber nNumUnit = 0;
		public SalNumber nFocusRow = 0;
		public SalArray<SalString> sUnits = new SalArray<SalString>();
		public SalArray<SalString> sRecords = new SalArray<SalString>();
		public SalString sSelectedParamId = "";
		public SalString sWhereStatement = "";
		public SalString sViewStatement = "";
		public SalString sValueTemp = "";
		#endregion
						
		#region Methods
			
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber BuildParameterString()
		{
			#region Local Variables
			cMessage MainMessage = new cMessage();
			SalNumber nCountRow = 0;
			SalNumber nCurrentRow = 0;
			SalNumber nActiveRow = 0;
			#endregion
				
			#region Actions
		
            if (Sal.TblAnyRows(tblExternalFileParam, 0, 0)) 
			{
                nActiveRow = Sal.TblQueryContext(tblExternalFileParam);
                Sal.SendMsg(tblExternalFileParam, Ifs.Fnd.ApplicationForms.Const.PM_DataContextLast, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
				MainMessage.Unpack(this.lsParamString);
                nCountRow = Sal.TblSetRow(tblExternalFileParam, Sys.TBL_SetLastRow);
                nCurrentRow = Sal.TblSetRow(tblExternalFileParam, Sys.TBL_SetFirstRow);
				while (nCurrentRow <= nCountRow) 
				{
                    if (Sal.TblSetContext(tblExternalFileParam, nCurrentRow)) 
					{
                        if (this.tblExternalFileParam_colsValue.Text != MainMessage.FindAttribute(this.tblExternalFileParam_colsParamId.Text, Ifs.Fnd.ApplicationForms.Const.strNULL)) 
						{
                            MainMessage.SetAttribute(this.tblExternalFileParam_colsParamId.Text, this.tblExternalFileParam_colsValue.Text);
						}
						nCurrentRow = nCurrentRow + 1;
					}
				}
				if (MainMessage.Pack() != this.lsParamString) 
				{
					this.lsParamString = MainMessage.Pack();
				}
                Sal.TblSetContext(tblExternalFileParam, nActiveRow);
			}

			return 0;
			#endregion
		}
			
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber PopulateFromView()
		{
			Sal.WaitCursor(true);
            SalString lsStmt = "FILE_TYPE = " + "'" + this.dfsFileType.Text + "'" + " AND SET_ID = " + "'" + this.dfsSetIdTest.Text + "'";
            tblExternalFileParam.DataSourceUserWhere(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, lsStmt.ToHandle());
            tblExternalFileParam.DataSourceUserOrderBy(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, ((SalString)"Param_No").ToHandle());
            Sal.SendMsg(tblExternalFileParam, Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Ifs.Fnd.ApplicationForms.Const.POPULATE_NoConfirm);
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

            if (this.lsParamString != Ifs.Fnd.ApplicationForms.Const.strNULL && Sal.TblAnyRows(tblExternalFileParam, 0, 0)) 
			{
                nCountRow = Sal.TblSetRow(tblExternalFileParam, Sys.TBL_SetLastRow);
                nCurrentRow = Sal.TblSetRow(tblExternalFileParam, Sys.TBL_SetFirstRow);
				MainMessage.Unpack(this.lsParamString);
				while (nCurrentRow <= nCountRow) 
				{
                    if (Sal.TblSetContext(tblExternalFileParam, nCurrentRow)) 
					{
                        sTempValue = MainMessage.FindAttribute(tblExternalFileParam_colsParamId.Text, Ifs.Fnd.ApplicationForms.Const.strNULL);
                        if (tblExternalFileParam_colsParamId.Text == "LOAD_DATE") 
						{
							sTempValue = Ifs.Fnd.ApplicationForms.Int.PalFmtFormatDateTimeToStr(sTempValue.ToDate(), Sys.FMT_Format_Date);
						}
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
            Sal.HideWindowAndLabel(tblExternalFileParam_colsHelpText);
            Sal.HideWindowAndLabel(tblExternalFileParam_colsInputableAtLoad);
            Sal.HideWindowAndLabel(tblExternalFileParam_colnParamNo);
            Sal.ShowWindowAndLabel(tblExternalFileParam_colsValue);
            Sal.HideWindowAndLabel(tblExternalFileParam_colsBrowsableField);
			return 0;
		}
			
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber SetStatusText()
		{
            this.dfsHelpText.Text = tblExternalFileParam_colsHelpText.Text;
			return 0;
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

			Sal.TblQueryFocus(this.tblExternalFileParam, ref nActiveRow, ref nCellRow);
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
                                if (sViewStatement == "USER_GROUP_MEMBER_FINANCE2")
                                {
                                    if (sWhere == "USER_ID")
                                    {
                                        sWhere = "USERID";
                                    }
                                }
                                // Bug 71319, Begin. Fully qualified colsValue.
                                if (tblExternalFileParam_colsValue.Text != Ifs.Fnd.ApplicationForms.Const.strNULL) 
								{
                                    sWhere = sWhere + " = " + "'" + tblExternalFileParam_colsValue.Text + "'";
									if (sWhereFinal == Ifs.Fnd.ApplicationForms.Const.strNULL) 
									{
										sWhereFinal = sWhere;
									}
									else
									{
										sWhereFinal = sWhereFinal + " AND " + sWhere;
									}
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
			#region Local Variables
			SalString sPackage = "";
			SalNumber nOffset = 0;
			#endregion
				
			#region Actions

            nOffset = ((SalString)tblExternalFileParam_colsEnumerateMethod.Text).Scan(".");
            sPackage = ((SalString)tblExternalFileParam_colsEnumerateMethod.Text).Left(nOffset);
            this.sFuncToCall = sPackage + ".Encode";
            DbPLSQLBlock("{0} :=\r\n  " + cSessionManager.c_sDbPrefix + this.sFuncToCall + "({1} IN )", this.QualifiedVarBindName("sParamValue"), this.QualifiedVarBindName("sValueTemp"));
            return 0;

			#endregion
		}
			
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber GetClientValue()
		{
			#region Local Variables
			SalString sPackage = "";
			SalNumber nOffset = 0;
			#endregion
				
			#region Actions

            nOffset = ((SalString)tblExternalFileParam_colsEnumerateMethod.Text).Scan(".");
            sPackage = ((SalString)tblExternalFileParam_colsEnumerateMethod.Text).Left(nOffset);
			this.sFuncToCall = sPackage + ".Decode";
       		DbPLSQLBlock("{0} :=\r\n  " + cSessionManager.c_sDbPrefix + this.sFuncToCall + "({1} IN)", this.tblExternalFileParam_colsValue.QualifiedBindName, this.QualifiedVarBindName("sValueTemp"));
            Sal.SetFieldEdit(tblExternalFileParam_colsValue, false);
			return 0;

			#endregion
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
			    return Ifs.Fnd.ApplicationForms.Var.Security.IsViewAvailable(sLOV);
		    }
		
			#endregion
		}
			
		/// <summary>
		/// </summary>
		/// <param name="sFunc"></param>
		/// <returns></returns>
		public virtual SalBoolean FuncIsAvailable(SalString sFunc)
		{
			#region Local Variables
			SalString sOrgin = "";
			SalString sViewStatement = "";
			SalNumber nLength = 0;
			SalNumber nOffset = 0;
			#endregion
				
			#region Actions
			sOrgin = sFunc;
			if (sOrgin.Right(1) == ")") 
			{
				nLength = sFunc.Length;
				nOffset = sOrgin.Scan("(");
				sViewStatement = sOrgin.Left(nOffset);
				return Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable(sViewStatement);
			}
			else
			{
				return Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable(sFunc);
			}
			#endregion
		}
			
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean RefreshValueLovInfo()
		{
			#region Actions
		
            if (tblExternalFileParam_colsParamId.Text == "USER_ID") 
			{
                tblExternalFileParam_colsLovView.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
			}
            if (tblExternalFileParam_colsLovView.Text != Ifs.Fnd.ApplicationForms.Const.strNULL) 
			{
                if (ViewIsAvailable(tblExternalFileParam_colsLovView.Text)) 
				{
					LovWhereValue();
                    tblExternalFileParam_colsValue.RuntimeLovReference = tblExternalFileParam_colsLovView.Text;
                    this.hWndLovField = tblExternalFileParam_colsValue;
                    this.sSpecialLov = tblExternalFileParam_colsParamId.Text;
					Sal.EnableWindowAndLabel(this.pbList);
				}
				else
				{
					Sal.DisableWindowAndLabel(this.pbList);
                    tblExternalFileParam_colsValue.RuntimeLovReference = Ifs.Fnd.ApplicationForms.Const.strNULL;
					this.sSpecialLov = Ifs.Fnd.ApplicationForms.Const.strNULL;
				}
			}
			else
			{
                tblExternalFileParam_colsValue.RuntimeLovReference = Ifs.Fnd.ApplicationForms.Const.strNULL;
				this.sSpecialLov = Ifs.Fnd.ApplicationForms.Const.strNULL;
				Sal.DisableWindowAndLabel(this.pbList);
			}
            if (tblExternalFileParam_colsEnumerateMethod.Text != Ifs.Fnd.ApplicationForms.Const.strNULL) 
			{
                if (!(FuncIsAvailable(tblExternalFileParam_colsEnumerateMethod.Text))) 
				{
                    Sal.ListClear(tblExternalFileParam_colsValue);
                    tblExternalFileParam_colsValue.p_sEnumerateMethod = Ifs.Fnd.ApplicationForms.Const.strNULL;
				}
				else
				{
                    tblExternalFileParam_colsValue.p_sEnumerateMethod = cSessionManager.c_sDbPrefix + tblExternalFileParam_colsEnumerateMethod.Text;
                    tblExternalFileParam_colsValue.LookupInit();
				}
			}
			else
			{
                Sal.ListClear(tblExternalFileParam_colsValue);
                tblExternalFileParam_colsValue.p_sEnumerateMethod = Ifs.Fnd.ApplicationForms.Const.strNULL;
			}
			return true;
			
			#endregion
		}
		#endregion
			
		#region Window Actions
			
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void tblExternalFileParam__colsValue_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_AnyEdit:
					e.Handled = true;
					Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataItemStateSet, Ifs.Fnd.ApplicationForms.Const.EDIT_Empty, 0);
					break;
					
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
					this.tblExternalFileParam_colsValue_OnPM_DataItemValidate(sender, e);
					break;
					
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
					this.tblExternalFileParam_colsValue_OnPM_DataItemQueryEnabled(sender, e);
					break;
					
				case Sys.SAM_Click:
					this.tblExternalFileParam_colsValue_OnSAM_Click(sender, e);
					break;
										
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovDone:
					this.tblExternalFileParam_colsValue_OnPM_DataItemLovDone(sender, e);
					break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovUserWhere:
                    e.Handled = true;
                    e.Return = this.sWhereStatement.ToHandle();
                    return;
                
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovUserReturnKeyName:
                    this.tblExternalFileParam_colsValue_OnPM_DataItemLovUserReturnKeyName(sender, e);
                    break;

            }
			#endregion
		}

        private void tblExternalFileParam_colsValue_OnPM_DataItemLovUserReturnKeyName(object sender, WindowActionsEventArgs e)
        {
            e.Handled = true;
            if (sSpecialLov == Ifs.Fnd.ApplicationForms.Const.strNULL)
                return;

            SalString sReturnColumnName = this.tblExternalFileParam_colsParamId.Text;
            if (sReturnColumnName == "VOUCHER_TYPE_FINAL_POSTING")
                sReturnColumnName = "VOUCHER_TYPE";

            e.Return = Sal.HStringToNumber(sReturnColumnName);
        }
			
		/// <summary>
		/// PM_DataItemValidate event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblExternalFileParam_colsValue_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
            if (this.tblExternalFileParam_colsValue.Text != Ifs.Fnd.ApplicationForms.Const.strNULL) 
			{
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
				if (this.sParamName == "LOAD_TYPE" || this.sParamName == "COMPANY") 
				{
					if (this.sParamName == "LOAD_TYPE") 
					{
						this.sParamName = "NEW_LOAD_TYPE";
					}
					else
					{
						this.sParamName = "NEW_COMPANY";
					}
					this.CreateParam();
					this.PopulateValues();
					Sal.TblSetFocusRow(this, this.nFocusRow);
					this.RefreshValueLovInfo();
                    Sal.TblSetFocusCell(this, this.nFocusRow, this.tblExternalFileParam_colsValue, 0, -1);
					e.Return = Sys.VALIDATE_Ok;
					return;
				}
				else
				{
					if (this.sParamName == "LOAD_DATE") 
					{
						if (!(this.CheckLoadDate())) 
						{
							Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_InvalidDateFormat, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
							e.Return = Sys.VALIDATE_Cancel;
							return;
						}
                        this.tblExternalFileParam_colsValue.Text = Ifs.Fnd.ApplicationForms.Int.PalFmtFormatDateTimeToStr(((SalString)this.tblExternalFileParam_colsValue.Text).ToDate(), Sys.FMT_Format_Date);
					}
					if (this.ChangeParamValues()) 
					{
						e.Return = Sys.VALIDATE_Ok;
						return;
					}
				}
                this.tblExternalFileParam_colsValue.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
				e.Return = Sys.VALIDATE_Cancel;
				return;
			}
            else if (this.tblExternalFileParam_colsParamId.Text == "LOAD_DATE" && this.rbBatch.Checked)
            {
                this.sParamValue = this.tblExternalFileParam_colsValue.Text;
                this.sParamName = this.tblExternalFileParam_colsParamId.Text;
                this.ChangeParamValues();
                e.Return = Sys.VALIDATE_Ok;
                return;
            }
			this.RefreshValueLovInfo();
			e.Return = Sys.VALIDATE_Ok;
			return;
			#endregion
		}
			
		/// <summary>
		/// PM_DataItemQueryEnabled event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblExternalFileParam_colsValue_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
            if (this.tblExternalFileParam_colsInputableAtLoad.Text == "FALSE") 
			{
				e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
				return;
			}
			else
			{
				e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldEnabled;
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
            this.nFocusRow = Sal.TblQueryContext(tblExternalFileParam);
			this.RefreshValueLovInfo();
            Sal.TblSetFocusCell(tblExternalFileParam, this.nFocusRow, this.tblExternalFileParam_colsValue, 0, -1);
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
                // Bug 109307, Begin - Added the OR condition
                if (this.tblExternalFileParam_colsParamId.Text == this.sUnits[0] || (this.tblExternalFileParam_colsParamId.Text == "VOUCHER_TYPE_FINAL_POSTING" && this.sUnits[0] == "VOUCHER_TYPE")) 
				{
                    this.tblExternalFileParam_colsValue.Text = this.sUnits[1];
                    this.sParamName = this.tblExternalFileParam_colsParamId.Text;
                    this.sParamValue = this.tblExternalFileParam_colsValue.Text;
					// Bug 86956, Removed IF code block used to assign value to sCompany (Set sCompany = sParamValue)
					if (this.sParamName == "LOAD_TYPE" || this.sParamName == "COMPANY") 
					{
						if (this.sParamName == "LOAD_TYPE") 
						{
							this.sParamName = "NEW_LOAD_TYPE";
						}
						else
						{
							this.sParamName = "NEW_COMPANY";
						}
						this.CreateParam();
						// Bug 86956, Begin
						this.PopulateValues();
						// Bug 86956, End
						Sal.TblSetFocusRow(this, this.nFocusRow);
						this.RefreshValueLovInfo();
                        Sal.TblSetFocusCell(this, this.nFocusRow, this.tblExternalFileParam_colsValue, 0, -1);
						e.Return = Sys.VALIDATE_Ok;
						return;
					}
					else
					{
						if (this.ChangeParamValues()) 
						{
							e.Return = Sys.VALIDATE_Ok;
							return;
						}
					}
					e.Return = true;
					return;
				}
                // Bug 109307, End
				this.nNum = this.nNum + 1;
			}
			if (this.nNum == this.nNumMax) 
			{
				this.tblExternalFileParam_colsValue.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
			}
			Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataItemStateSet, Ifs.Fnd.ApplicationForms.Const.EDIT_Empty, 0);
			#endregion
		}
		#endregion

        private void labeldfsSetId2_Click(object sender, System.EventArgs e)
        {

        }

		#endregion
	}
}
