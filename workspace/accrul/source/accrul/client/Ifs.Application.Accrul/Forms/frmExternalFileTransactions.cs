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
//Date      By      Notes
//-----     ------  -----------------------------------------------------------------------------------------------
//120301    Raablk  SFI-2472, Merged Bug 101207.
//121114    Charlk  PBFI-2045, Change name of method Get_Load_File_Type_List to Get_Load_File_Type_List_Db
#endregion

using System;
using System.Text;
using System.Drawing;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using Ifs.Application.Appsrv;
using Ifs.Application.Enterp;
using Ifs.Fnd.ApplicationForms;
using PPJ.Runtime;
using PPJ.Runtime.Sql;
using PPJ.Runtime.Vis;
using PPJ.Runtime.Windows;
using PPJ.Runtime.Windows.QO;
using Ifs.Fnd.Windows.Forms;

namespace Ifs.Application.Accrul
{
	
	/// <summary>
	/// </summary>
    [FndWindowRegistration("EXT_FILE_LOAD", "ExtFileLoad", FndWindowRegistrationFlags.HomePage)]
    public partial class frmExternalFileTransactions : cFormWindow
    {
        #region Window Variables
        public SalString sFileTemplateId = "";
        public SalString sRecordTypeId = "";
        public SalString sColumnTranslationMsg = "";
        public SalString lsParam = "";
        public cMessage cColumnTranslationMsg = new cMessage();
        public cMessage cColumnTranslationMsg2 = new cMessage();
        public cMessage cColumnTranslationMsg3 = new cMessage();
        public cMessage cColumnTranslationMsg4 = new cMessage();
        public SalFileHandle hSrcHandle = SalFileHandle.Null;
        public SalString lsMainMesgTemp = "";
        public SalString lsMainMessage = "";
        public SalString lsSubMessage = "";
        public SalString lsOutMsg = "";
        public SalString lsReadFileLine = "";
        public SalString lsParameter = "";
        public cMessage MainMessage = new cMessage();
        public cMessage SubMessage = new cMessage();
        public SalNumber nCounter = 0;
        public SalNumber nIndex = 0;
        public SalNumber nIndexCombo = 0;
        public SalNumber nRetValue = 0;
        public SalNumber nRowCount = 0;
        public SalNumber nRowno = 0;
        public SalNumber nRownoRow = 0;
        public SalString sAction = "";
        public SalString sFormName = "";
        public SalString sLoadFileId = "";
        public SalArray<SalString> sParam = new SalArray<SalString>();
        public SalString sRefCurrency = "";
        public SalString strFile = "";
        public SalArray<SalString> strFilters = new SalArray<SalString>("0:5");
        public SalString strPath = "";
        public SalString sBackPath = "";
        public SalString sState = "";
        public SalString sLineFound = "";
        public SalArray<SalString> sNames = new SalArray<SalString>();
        public SalArray<SalString> sSubNames = new SalArray<SalString>();
        public SalArray<SalString> sValues = new SalArray<SalString>();
        public SalArray<SalString> sSubValues = new SalArray<SalString>();
        public SalString sLastLine = "";
        public SalString sViewName = "";
        public SalString sPackageName = "";
        public SalString lsTemp = "";
        public SalString is_loadProfileFileTypeList = "";
        public SalArray<SalString> l_sDecodedFileList = new SalArray<SalString>();
        public SalString l_sFileNames = "";
        public SalString l_sFilePaths = "";
        public SalNumber l_nCnt = 0;
        public SalNumber l_nDefault = 0;
        public SalBoolean l_bOk = false;
        public SalString sFileName = "";
        public SalString sFileDirection = "";
        public SalString sFileDirectionDb = "";
        public SalString sParamName = "";
        public SalString sClientServer = "";
        public SalString sParamValue = "";
        public SalString sSetId = "";
        public SalBoolean bSaveOk = false;
        public SalString sIsXmlType = "";
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public frmExternalFileTransactions()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();
        }
        #endregion

        #region System Methods/Properties

        /// <summary>
        /// Returns the object instance associated with the window handle.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public new static frmExternalFileTransactions FromHandle(SalWindowHandle handle)
        {
            return ((frmExternalFileTransactions)SalWindow.FromHandle(handle, typeof(frmExternalFileTransactions)));
        }
        #endregion

        #region Methods

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber CheckPath()
        {
            #region Local Variables
            SalString sDrive = "";
            SalString sDir = "";
            SalString sFile = "";
            SalString sExt = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                if (dfFileName.Text != Ifs.Fnd.ApplicationForms.Const.strNULL)
                {
                    Vis.DosSplitPath(dfFileName.Text, ref sDrive, ref sDir, ref sFile, ref sExt);
                    // Bug 79498 Begin
                    // If dfsFileDirectionDb = '1'
                    // If not VisDosExist( (dfFileName ) )
                    // Set dfFileName = strNULL
                    // Else
                    // If SalFileGetCurrentDirectory ( sDir )
                    // Set dfFileName = PalStrAppendWithSeparator( sDir, sFile, '\\' ) || sExt
                    // Else
                    // Set dfFileName = strNULL
                    if (dfsFileDirectionDb.Text != "1")
                    {
                        if (!(Vis.DosExist((sDrive + sDir))))
                        {
                            if (!(Sal.FileGetCurrentDirectory(ref sDir)))
                            {
                                if (Vis.DosGetEnvString("TEMP") != Ifs.Fnd.ApplicationForms.Const.strNULL)
                                {
                                    dfFileName.Text = Ifs.Fnd.ApplicationForms.Int.PalStrAppendWithSeparator(Vis.DosGetEnvString("TEMP"), sFile, "\\") + sExt;
                                }
                                else if (Vis.DosGetEnvString("TMP") != Ifs.Fnd.ApplicationForms.Const.strNULL)
                                {
                                    dfFileName.Text = Ifs.Fnd.ApplicationForms.Int.PalStrAppendWithSeparator(Vis.DosGetEnvString("TEMP"), sFile, "\\") + sExt;
                                }
                                else
                                {
                                    dfFileName.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                                }
                            }
                            else
                            {
                                if (Sal.FileGetCurrentDirectory(ref sDir))
                                {
                                    dfFileName.Text = Ifs.Fnd.ApplicationForms.Int.PalStrAppendWithSeparator(sDir, sFile, "\\") + sExt;
                                }
                                else
                                {
                                    dfFileName.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                                }
                            }
                        }
                    }
                    // Bug 79498 End
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="nWhatInv"></param>
        /// <returns></returns>
        public virtual SalNumber ExtParam(SalNumber nWhatInv)
        {
            #region Actions
            using (new SalContext(this))
            {
                switch (nWhatInv)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        return dfsParameterString.Text != Ifs.Fnd.ApplicationForms.Const.strNULL;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        OpenParamDialog();
                        return true;
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="nWhatInv"></param>
        /// <returns></returns>
        public virtual SalNumber ExtLog(SalNumber nWhatInv)
        {
            #region Local Variables
            SalArray<SalString> sItemNames = new SalArray<SalString>();
            SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                switch (nWhatInv)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        if (cmdLoadFileId.i_sMyValue == Ifs.Fnd.ApplicationForms.Const.strNULL)
                        {
                            return false;
                        }
                        return Ifs.Fnd.ApplicationForms.Var.Security.IsViewAvailable("EXT_FILE_LOG");

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        Sal.WaitCursor(true);
                        sItemNames[0] = "LOAD_FILE_ID";
                        hWndItems[0] = cmdLoadFileId;
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("ExtFileLog", i_hWndSelf, sItemNames, hWndItems);
                        SessionCreateWindow(Pal.GetActiveInstanceName("frmExternalFileLog"), Sys.hWndMDI);
                        return true;
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// Gets client default values for NEW records
        /// </summary>
        /// <returns></returns>
        public new SalBoolean DataRecordGetDefaults()
        {
            #region Actions
            using (new SalContext(this))
            {

                // PPJ: Automatically generated temporary assignments. Properties canot be passed by reference.
                SalString temp1 = dfsCompany.Text;
                UserGlobalValueGet("COMPANY", ref temp1);
                dfsCompany.Text = temp1;

                dfsCompany.EditDataItemSetEdited();
                return true;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean IsThereAnyLines()
        {
            #region Actions
            using (new SalContext(this))
            {
                if (sLineFound == "TRUE")
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
        // Bug 79427, Removed CheckExistFileTrans
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber BuildParameterString()
        {
            #region Actions
            using (new SalContext(this))
            {
                MainMessage.Construct();
                MainMessage.AddAttribute("COMPANY", dfsCompany.Text);
                MainMessage.AddAttribute("FILE_NAME", dfFileName.Text);
                MainMessage.AddAttribute("FILE_TEMPLATE_ID", dfsFileTemplateId.Text);
                MainMessage.AddAttribute("FILE_TYPE", dfsFileType.Text);
                lsMainMesgTemp = MainMessage.Pack();
            }

            return 0;
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
                    Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.FILELIST_ColError + p_sFileTypeListString, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                    return false;
                }
                while (l_nElementCounter < p_nRowCount)
                {
                    if (l_nElementCounter.Mod(2) > 0)
                    {
                        p_sFileTypeListArray[l_nElementCounter] = "*." + p_sFileTypeListArray[l_nElementCounter];
                    }
                    l_nElementCounter = l_nElementCounter + 1;
                }
                return true;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber RePopulate()
        {
            #region Actions
            using (new SalContext(this))
            {
                Sal.SendMsg(i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceRefresh, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                Sal.SendMsg(frmExternalFileTransactions.FromHandle(i_hWndSelf).tblExtFileTrans, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceRefresh, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="sOnOff"></param>
        /// <returns></returns>
        public virtual SalNumber DisableEnableForm(SalString sOnOff)
        {
            #region Actions
            using (new SalContext(this))
            {
                if (sOnOff == "Disable")
                {
                    SourceFlagsSet(Ifs.Fnd.ApplicationForms.Const.SOURCE_OperationModify, false);
                    Sal.DisableWindowAndLabel(pbBrowser);
                }
                else
                {
                    SourceFlagsSet(Ifs.Fnd.ApplicationForms.Const.SOURCE_OperationModify, true);
                    Sal.EnableWindowAndLabel(pbBrowser);
                }
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
            SalBoolean Edited = false;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                Edited = false;
                if (dfsFileDirectionDb.Text == "1")
                {
                    using (SignatureHints hints = SignatureHints.NewContext())
                    {
                        hints.Add("External_File_Utility_API.Get_File_Path", System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Input);
                        if (!(DbPLSQLBlock(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "External_File_Utility_API.Get_File_Path(\r\n" +
                            " 	  :i_hWndFrame.frmExternalFileTransactions.strFile,\r\n" +
                            "                  :i_hWndFrame.frmExternalFileTransactions.strPath,\r\n" +
                            "	  :i_hWndFrame.frmExternalFileTransactions.dfFileName )")))
                        {
                            return false;
                        }
                    }
                    using (SignatureHints hints = SignatureHints.NewContext())
                    {
                        hints.Add("In_Ext_File_Template_Dir_API.Get_Load_File_Type_List_Db", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                        if (!(DbPLSQLBlock(cSessionManager.c_hSql, ":i_hWndFrame.is_loadProfileFileTypeList :=  " + cSessionManager.c_sDbPrefix + "In_Ext_File_Template_Dir_API.Get_Load_File_Type_List_Db(\r\n" +
                            ":i_hWndFrame.dfsFileTemplateId,\r\n" +
                            ":i_hWndFrame.dfsFileDirectionDb)")))
                        {
                            is_loadProfileFileTypeList = "All Types^*";
                        }
                    }
                    l_bOk = UnpackFileTypeList(is_loadProfileFileTypeList, l_sDecodedFileList, ref l_nCnt);
                    if (l_bOk)
                    {
                        if (Sal.DlgOpenFile(i_hWndFrame, "Open File", l_sDecodedFileList, l_nCnt, ref nIndex, ref strFile, ref strPath))
                        {
                            // Bug 79498 Begin
                            if (strPath.Length > 259)
                            {
                                Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_MaximumLengthFileName, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                                return false;
                            }
                            // Bug 79498 End
                            dfFileName.Text = strPath;
                            dfFileName.EditDataItemSetEdited();
                            Edited = true;
                        }
                    }
                }
                if (dfsFileDirectionDb.Text == "2")
                {
                    if (Sal.DlgSaveFile(i_hWndFrame, "Save File", strFilters, 6, ref nIndex, ref strFile, ref strPath))
                    {
                        dfFileName.Text = strPath;
                        dfFileName.EditDataItemSetEdited();
                        Edited = true;
                    }
                }
                if (Edited)
                {
                    sParamName = "FILE_NAME";
                    using (SignatureHints hints = SignatureHints.NewContext())
                    {
                        hints.Add("Ext_File_Message_API.Change_Attr_Parameter_Msg", System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                        if (DbPLSQLBlock(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "Ext_File_Message_API.Change_Attr_Parameter_Msg (\r\n" +
                            "                  :i_hWndFrame.dfsParameterString,\r\n" +
                            "	  :i_hWndFrame.sParamName ,\r\n" +
                            "	  :i_hWndFrame.dfFileName )"))
                        {
                            dfFileName.EditDataItemSetEdited();
                            dfsParameterString.EditDataItemSetEdited();
                            return true;
                        }
                    }
                }
                Sal.WaitCursor(false);
                return false;
            }
            #endregion
        }
        // Input File
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean OpenClientFile()
        {
            #region Actions
            using (new SalContext(this))
            {
                if (!(hSrcHandle.Open(strPath, Sys.OF_Read)))
                {
                    sParam[0] = dfFileName.Text;
                    return false;
                }
                return true;
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
                sLoadFileId = cmdLoadFileId.i_sMyValue;
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("Ext_File_Template_API.Get_Backup_File_Name", System.Data.ParameterDirection.Input);
                    if (!(DbPLSQLBlock(cSessionManager.c_hSql, ":i_hWndFrame.frmExternalFileTransactions.sBackPath :=  " + cSessionManager.c_sDbPrefix + "Ext_File_Template_API.Get_Backup_File_Name(\r\n" +
                        ":i_hWndFrame.frmExternalFileTransactions.sLoadFileId)")))
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
                    Sal.WaitCursor(true);
                    sLoadFileId = cmdLoadFileId.i_sMyValue;
                    using (SignatureHints hints = SignatureHints.NewContext())
                    {
                        hints.Add("Ext_File_Load_API.Update_File_Name", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                        if (!(DbPLSQLTransaction(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "Ext_File_Load_API.Update_File_Name(\r\n" +
                            "                  :i_hWndFrame.frmExternalFileTransactions.sLoadFileId,\r\n" +
                            "	  :i_hWndFrame.frmExternalFileTransactions.sBackPath )")))
                        {
                            Sal.WaitCursor(false);
                            return false;
                        }
                    }
                    Sal.WaitCursor(false);
                    Vis.FileDelete(strPath);
                    return true;
                }
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber LoadClientFile()
        {
            #region Actions
            using (new SalContext(this))
            {
                sLoadFileId = cmdLoadFileId.i_sMyValue;
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("External_File_Utility_API.Load_Client_File_", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                    if (!(DbPLSQLBlock(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "External_File_Utility_API.Load_Client_File_(\r\n" +
                        " 	  :i_hWndFrame.frmExternalFileTransactions.sAction,\r\n" +
                        "                  :i_hWndFrame.frmExternalFileTransactions.sLoadFileId,\r\n" +
                        "	  :i_hWndFrame.frmExternalFileTransactions.dfsFileTemplateId,\r\n" +
                        "                  :i_hWndFrame.frmExternalFileTransactions.dfsFileType,\r\n" +
                        "                  :i_hWndFrame.frmExternalFileTransactions.lsMainMesgTemp,\r\n" +
                        "	  :i_hWndFrame.frmExternalFileTransactions.dfsCompany,\r\n" +
                        "                   :i_hWndFrame.frmExternalFileTransactions.dfFileName )")))
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
        /// <param name="p_nMess"></param>
        /// <returns></returns>
        public virtual SalNumber ReadClientFile(SalNumber p_nMess)
        {
            #region Local Variables
            SalNumber nRetValue = 0;
            SalNumber nId = 0;
            SalBoolean bNewMsg = false;

            SalArray<SalString> sSpecialChars = new SalArray<SalString>();

            #endregion

            #region Actions
            using (new SalContext(this))
            {
                // The following special characters should be ignored when reading the external file as they are used by foundation for special purposes.
                sSpecialChars[0]  = ((char)28).ToString();
                sSpecialChars[1]  = ((char)27).ToString();
                sSpecialChars[2]  = ((char)26).ToString();
                sSpecialChars[3]  = ((char)25).ToString();
                sSpecialChars[4]  = ((char)24).ToString();
                sSpecialChars[5]  = ((char)23).ToString();
                sSpecialChars[6]  = ((char)22).ToString();
                sSpecialChars[7]  = ((char)21).ToString();
                sSpecialChars[8]  = ((char)20).ToString();
                sSpecialChars[9]  = ((char)19).ToString();
                sSpecialChars[10] = ((char)18).ToString();
                sSpecialChars[11] = ((char)17).ToString();
                sSpecialChars[12] = ((char)16).ToString();
                sSpecialChars[13] = ((char)15).ToString();
                sSpecialChars[14] = ((char)14).ToString();

                MethodProgressStart(i_hWndSelf, Properties.Resources.TEXT_TitleExternalFileExt, Properties.Resources.TEXT_ReadExtFileOnlineExt, "FETCH", true, SalWindowHandle.Null);
                MethodProgressStepAdd(4);
                MethodProgressStep();
                if (DbTransactionBegin(ref cSessionManager.c_hSql))
                {
                    nRetValue = hSrcHandle.GetString(ref lsReadFileLine, 2000);

                    for (int i = 0; lsReadFileLine.Length > 0 && i < sSpecialChars.Length; i++)
                    {
                        lsReadFileLine = (SalString)lsReadFileLine.ToString().Replace(sSpecialChars[i], "");
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
                                MethodProgressSteps(2);
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
                            nRetValue = hSrcHandle.GetString(ref lsReadFileLine, 2000);
                            for (int i = 0; lsReadFileLine.Length > 0 && i < sSpecialChars.Length; i++)
                            {
                                lsReadFileLine = (SalString)lsReadFileLine.ToString().Replace(sSpecialChars[i], "");
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
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean UM_Input()
        {
            if (dfsFileDirectionDb.Text == "1")
            {
                if (dfsViewName.Text != Ifs.Fnd.ApplicationForms.Const.strNULL)
                {
                    if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsViewAvailable(dfsViewName.Text)))
                    {
                        return false;
                    }
                }
                if (dfsStateDb.Text == "4")
                {
                    return false;
                }
                if (dfsStateDb.Text == "8")
                {
                    return false;
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean UM_Output()
        {
            if (cmbFileDirection.Text == "OutputFile")
            {
                if (dfsViewName.Text != Ifs.Fnd.ApplicationForms.Const.strNULL)
                {
                    if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsViewAvailable(dfsViewName.Text)))
                    {
                        return false;
                    }
                }
                if (dfsStateDb.Text == "7")
                {
                    return false;
                }
                if (dfsStateDb.Text == "8")
                {
                    return false;
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// </summary>
        /// <param name="p_nWhat"></param>
        /// <returns></returns>
        public virtual SalBoolean UM_InpLoadFile(SalNumber p_nWhat)
        {
            #region Actions
            using (new SalContext(this))
            {
                switch (p_nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        if (dfsFileDirectionDb.Text == "2")
                        {
                            return false;
                        }
                        if (dfsStateDb.Text == "4")
                        {
                            return false;
                        }
                        if (dfFileName.Text == Ifs.Fnd.ApplicationForms.Const.strNULL)
                        {
                            return false;
                        }
                        if ((SourceStateGet() == Ifs.Fnd.ApplicationForms.Const.DATASOURCE_Empty) || ((bool)Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0)))
                        {
                            return false;
                        }
                        return true;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        Sal.WaitCursor(true);
                        strPath = dfFileName.Text;
                        sFileTemplateId = dfsFileTemplateId.Text;
                        lsMainMesgTemp = SalString.Null;
                        DbTransactionBegin(ref cSessionManager.c_hSql);
                        if (IsThereAnyLines())
                        {
                            if (Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_AlreadyLoadedExt, Properties.Resources.TEXT_TitleExternalFileExt, Ifs.Fnd.ApplicationForms.Const.QUESTION_YesNo) == Sys.IDNO)
                            {
                                Sal.WaitCursor(false);
                                return false;
                            }
                        }
                        if (OpenClientFile())
                        {
                            ReadClientFile(1);
                            Sal.WaitCursor(false);
                            RePopulate();
                            cmdLoadFileId.RecordSelectionListSetSelect(cmdLoadFileId.GetSelectedItem());
                            CopyClientFile();
                        }
                        DbTransactionEnd(cSessionManager.c_hSql);
                        RePopulate();
                        Sal.WaitCursor(false);
                        return true;
                }
            }

            return false;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="p_nWhat"></param>
        /// <returns></returns>
        public virtual SalBoolean UM_InpUnpackFile(SalNumber p_nWhat)
        {
            #region Actions
            using (new SalContext(this))
            {
                switch (p_nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        if (dfsStateDb.Text == "4")
                        {
                            return false;
                        }
                        if (dfsFileDirectionDb.Text == "2")
                        {
                            return false;
                        }
                        if (!(IsThereAnyLines()))
                        {
                            return false;
                        }
                        if ((!(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("External_File_Utility_API.Unpack_Ext_Line")) && SourceStateGet() == Ifs.Fnd.ApplicationForms.Const.DATASOURCE_Empty) || ((bool)Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave,
                            Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0)))
                        {
                            Sal.WaitCursor(false);
                            return false;
                        }
                        Sal.WaitCursor(false);
                        return true;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        Sal.WaitCursor(true);
                        sLoadFileId = cmdLoadFileId.i_sMyValue;
                        using (SignatureHints hints = SignatureHints.NewContext())
                        {
                            hints.Add("External_File_Utility_API.Unpack_Ext_Line", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                            if (!(DbPLSQLTransaction(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "External_File_Utility_API.Unpack_Ext_Line(\r\n" +
                                "                  :i_hWndFrame.frmExternalFileTransactions.dfsFileType,\r\n" +
                                "	  :i_hWndFrame.frmExternalFileTransactions.dfsFileTemplateId,\r\n" +
                                "                  :i_hWndFrame.frmExternalFileTransactions.sLoadFileId,\r\n" +
                                "	  :i_hWndFrame.frmExternalFileTransactions.dfsCompany )")))
                            {
                                Sal.WaitCursor(false);
                                HandleSqlResult(lsTemp);
                                RePopulate();
                                return false;
                            }
                        }
                        Sal.WaitCursor(false);
                        RePopulate();
                        cmdLoadFileId.RecordSelectionListSetSelect(cmdLoadFileId.GetSelectedItem());
                        return true;
                }
            }

            return false;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="p_nWhat"></param>
        /// <returns></returns>
        public virtual SalBoolean UM_InpPackageMethod(SalNumber p_nWhat)
        {
            #region Actions
            using (new SalContext(this))
            {
                switch (p_nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        if (dfsFileDirectionDb.Text == "2")
                        {
                            return false;
                        }
                        if (dfsStateDb.Text == "4")
                        {
                            return false;
                        }
                        if (!(IsThereAnyLines()))
                        {
                            return false;
                        }
                        if (dfsApiToCall.Text == Ifs.Fnd.ApplicationForms.Const.strNULL)
                        {
                            return false;
                        }
                        if ((!(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("External_File_Utility_API.Start_Api_To_Call")) && SourceStateGet() == Ifs.Fnd.ApplicationForms.Const.DATASOURCE_Empty) || ((bool)Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave,
                            Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0)))
                        {
                            Sal.WaitCursor(false);
                            return false;
                        }
                        Sal.WaitCursor(false);
                        return true;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        Sal.WaitCursor(true);
                        sLoadFileId = cmdLoadFileId.i_sMyValue;
                        using (SignatureHints hints = SignatureHints.NewContext())
                        {
                            hints.Add("External_File_Utility_API.Store_File_Identities", System.Data.ParameterDirection.Input);
                            if (!(DbPLSQLTransaction(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "External_File_Utility_API.Store_File_Identities (\r\n" +
                                "                  :i_hWndFrame.frmExternalFileTransactions.sLoadFileId )")))
                            {
                                Sal.WaitCursor(false);
                                HandleSqlResult(lsTemp);
                                return false;
                            }
                        }
                        using (SignatureHints hints = SignatureHints.NewContext())
                        {
                            hints.Add("External_File_Utility_API.Start_Api_To_Call", System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.Input);
                            if (!(DbPLSQLTransaction(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "External_File_Utility_API.Start_Api_To_Call (\r\n" +
                                "                  :i_hWndFrame.frmExternalFileTransactions.lsTemp,\r\n" +
                                "	  :i_hWndFrame.frmExternalFileTransactions.sLoadFileId )")))
                            {
                                Sal.WaitCursor(false);
                                HandleSqlResult(lsTemp);
                                return false;
                            }
                        }
                        if (!(HandleSqlResult(lsTemp)))
                        {
                            return false;
                        }
                        Sal.WaitCursor(false);
                        RePopulate();
                        cmdLoadFileId.RecordSelectionListSetSelect(cmdLoadFileId.GetSelectedItem());
                        return true;
                }
            }

            return false;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="p_nWhat"></param>
        /// <returns></returns>
        public virtual SalBoolean UM_InpCompFlow(SalNumber p_nWhat)
        {
            #region Actions
            using (new SalContext(this))
            {
                switch (p_nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        if (dfsFileDirectionDb.Text == "2")
                        {
                            return false;
                        }
                        if (dfsStateDb.Text == "4" || dfsStateDb.Text == "9" || dfsStateDb.Text == "10")
                        {
                            return false;
                        }
                        if (dfFileName.Text == Ifs.Fnd.ApplicationForms.Const.strNULL)
                        {
                            return false;
                        }
                        if (dfsApiToCall.Text == Ifs.Fnd.ApplicationForms.Const.strNULL)
                        {
                            return false;
                        }
                        if ((SourceStateGet() == Ifs.Fnd.ApplicationForms.Const.DATASOURCE_Empty) || ((bool)Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0)))
                        {
                            return false;
                        }
                        return true;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        Sal.WaitCursor(true);
                        sFileTemplateId = dfsFileTemplateId.Text;
                        strPath = dfFileName.Text;
                        lsMainMesgTemp = SalString.Null;
                        if (IsThereAnyLines())
                        {
                            if (Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_AlreadyLoadedExt, Properties.Resources.TEXT_TitleExternalFileExt, Ifs.Fnd.ApplicationForms.Const.QUESTION_YesNo) == Sys.IDNO)
                            {
                                Sal.WaitCursor(false);
                                return false;
                            }
                        }
                        if (OpenClientFile())
                        {
                            ReadClientFile(0);
                            DbTransactionEnd(cSessionManager.c_hSql);
                            sLoadFileId = cmdLoadFileId.i_sMyValue;
                            using (SignatureHints hints = SignatureHints.NewContext())
                            {
                                hints.Add("External_File_Utility_API.Unpack_Ext_Line", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                                if (DbPLSQLTransaction(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "External_File_Utility_API.Unpack_Ext_Line(\r\n" +
                                    "                  :i_hWndFrame.frmExternalFileTransactions.dfsFileType,\r\n" +
                                    "	  :i_hWndFrame.frmExternalFileTransactions.dfsFileTemplateId,\r\n" +
                                    "                  :i_hWndFrame.frmExternalFileTransactions.sLoadFileId,\r\n" +
                                    "	  :i_hWndFrame.frmExternalFileTransactions.dfsCompany )"))
                                {
                                    using (SignatureHints hints1 = SignatureHints.NewContext())
                                    {
                                        hints1.Add("External_File_Utility_API.Store_File_Identities", System.Data.ParameterDirection.Input);
                                        if (DbPLSQLTransaction(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "External_File_Utility_API.Store_File_Identities (\r\n" +
                                            "                  :i_hWndFrame.frmExternalFileTransactions.sLoadFileId )"))
                                        {
                                            using (SignatureHints hints2 = SignatureHints.NewContext())
                                            {
                                                hints2.Add("External_File_Utility_API.Start_Api_To_Call", System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.Input);
                                                if (DbPLSQLTransaction(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "External_File_Utility_API.Start_Api_To_Call (\r\n" +
                                                    "                  :i_hWndFrame.frmExternalFileTransactions.lsTemp,\r\n" +
                                                    "	  :i_hWndFrame.frmExternalFileTransactions.sLoadFileId )"))
                                                {
                                                    Sal.WaitCursor(false);
                                                    HandleSqlResult(lsTemp);
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
                            cmdLoadFileId.RecordSelectionListSetSelect(cmdLoadFileId.GetSelectedItem());
                            CopyClientFile();
                        }
                        RePopulate();
                        Sal.WaitCursor(false);
                        return true;
                }
            }

            return false;
            #endregion
        }
        // Output File
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
                    sParam[0] = dfFileName.Text;
                    return false;
                }
                return true;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="p_nWhat"></param>
        /// <returns></returns>
        public virtual SalBoolean UM_OutPackageMethod(SalNumber p_nWhat)
        {
            #region Actions
            using (new SalContext(this))
            {
                switch (p_nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        if (dfsFileDirectionDb.Text == "1")
                        {
                            return false;
                        }
                        if (dfsStateDb.Text == "4")
                        {
                            return false;
                        }
                        if (dfsStateDb.Text == "6")
                        {
                            return false;
                        }
                        if (dfsStateDb.Text == "7")
                        {
                            return false;
                        }
                        if (dfsApiToCall.Text == Ifs.Fnd.ApplicationForms.Const.strNULL)
                        {
                            return false;
                        }
                        if ((!(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("External_File_Utility_API.Start_Api_To_Call")) && SourceStateGet() == Ifs.Fnd.ApplicationForms.Const.DATASOURCE_Empty) || ((bool)Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave,
                            Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0)))
                        {
                            Sal.WaitCursor(false);
                            return false;
                        }
                        Sal.WaitCursor(false);
                        return true;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        Sal.WaitCursor(true);
                        sLoadFileId = cmdLoadFileId.i_sMyValue;
                        using (SignatureHints hints = SignatureHints.NewContext())
                        {
                            hints.Add("External_File_Utility_API.Start_Api_To_Call", System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.Input);
                            if (!(DbPLSQLTransaction(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "External_File_Utility_API.Start_Api_To_Call (\r\n" +
                                "                  :i_hWndFrame.frmExternalFileTransactions.lsTemp,\r\n" +
                                "	  :i_hWndFrame.frmExternalFileTransactions.sLoadFileId )")))
                            {
                                Sal.WaitCursor(false);
                                HandleSqlResult(lsTemp);
                                return false;
                            }
                        }
                        if (!(HandleSqlResult(lsTemp)))
                        {
                            return false;
                        }
                        Sal.WaitCursor(false);
                        RePopulate();
                        cmdLoadFileId.RecordSelectionListSetSelect(cmdLoadFileId.GetSelectedItem());
                        return true;
                }
            }

            return false;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="p_nWhat"></param>
        /// <returns></returns>
        public virtual SalBoolean UM_OutPackFile(SalNumber p_nWhat)
        {
            #region Actions
            using (new SalContext(this))
            {
                switch (p_nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        if (dfsFileDirectionDb.Text == "1")
                        {
                            return false;
                        }
                        if (dfsStateDb.Text == "4")
                        {
                            return false;
                        }
                        if (!(IsThereAnyLines()))
                        {
                            return false;
                        }
                        if ((!(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("External_File_Utility_API.Pack_Out_Ext_Line")) && SourceStateGet() == Ifs.Fnd.ApplicationForms.Const.DATASOURCE_Empty) || ((bool)Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave,
                            Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0)))
                        {
                            Sal.WaitCursor(false);
                            return false;
                        }
                        Sal.WaitCursor(false);
                        return true;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        Sal.WaitCursor(true);
                        sLoadFileId = cmdLoadFileId.i_sMyValue;
                        using (SignatureHints hints = SignatureHints.NewContext())
                        {
                            hints.Add("External_File_Utility_API.Pack_Out_Ext_Line", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                            if (!(DbPLSQLTransaction(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "External_File_Utility_API.Pack_Out_Ext_Line(\r\n" +
                                "                  :i_hWndFrame.frmExternalFileTransactions.dfsFileType,\r\n" +
                                "	  :i_hWndFrame.frmExternalFileTransactions.dfsFileTemplateId,\r\n" +
                                "                  :i_hWndFrame.frmExternalFileTransactions.sLoadFileId,\r\n" +
                                "	  :i_hWndFrame.frmExternalFileTransactions.dfsCompany )")))
                            {
                                Sal.WaitCursor(false);
                                HandleSqlResult(lsTemp);
                                return false;
                            }
                        }
                        Sal.WaitCursor(false);
                        HandleSqlResult(lsTemp);
                        RePopulate();
                        cmdLoadFileId.RecordSelectionListSetSelect(cmdLoadFileId.GetSelectedItem());
                        return true;
                }
            }

            return false;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="p_nWhat"></param>
        /// <returns></returns>
        public virtual SalBoolean UM_OutPutFile(SalNumber p_nWhat)
        {
            #region Local Variables
            SalString sFileName = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                switch (p_nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        if (dfsFileDirectionDb.Text == "1")
                        {
                            return false;
                        }
                        if (dfFileName.Text == Ifs.Fnd.ApplicationForms.Const.strNULL)
                        {
                            return false;
                        }
                        if ((SourceStateGet() == Ifs.Fnd.ApplicationForms.Const.DATASOURCE_Empty) || ((bool)Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0)))
                        {
                            return false;
                        }
                        if (Sal.IsNull(dfsStateDb) || (dfsStateDb.Text == "1"))
                        {
                            return false;
                        }
                        return true;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        Sal.WaitCursor(true);
                        strPath = dfFileName.Text;
                        sLoadFileId = cmdLoadFileId.i_sMyValue;
                        sFileName = dfFileName.Text;
                        // Bug 77126 Begin
                        Sal.WaitCursor(true);
                        using (SignatureHints hints = SignatureHints.NewContext())
                        {
                            hints.Add("External_File_Utility_API.Create_Xml_File", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Output);
                            if (!(DbPLSQLTransaction(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "External_File_Utility_API.Create_Xml_File(\r\n" +
                                "                  :i_hWndFrame.frmExternalFileTransactions.sLoadFileId,\r\n" +
                                "	  :i_hWndFrame.frmExternalFileTransactions.sIsXmlType )")))
                            {
                                Sal.WaitCursor(false);
                                HandleSqlResult(lsTemp);
                                return false;
                            }
                        }
                        Sal.WaitCursor(false);
                        if (sIsXmlType == "FALSE")
                        {
                            using (SignatureHints hints = SignatureHints.NewContext())
                            {
                                hints.Add("External_File_Utility_API.Modify_File_Name", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.InputOutput);
                                if (!(DbPLSQLTransaction(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "External_File_Utility_API.Modify_File_Name(\r\n" +
                                    "                  :i_hWndFrame.frmExternalFileTransactions.sLoadFileId,\r\n" +
                                    "	  :i_hWndFrame.frmExternalFileTransactions.dfFileName )")))
                                {
                                    Sal.WaitCursor(false);
                                    return false;
                                }
                            }
                            strPath = dfFileName.Text;
                            if (OpenOutClientFile())
                            {
                                OutputClientFile();
                                sState = "7";
                                using (SignatureHints hints = SignatureHints.NewContext())
                                {
                                    hints.Add("Ext_File_Load_API.Update_State", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                                    if (!(DbPLSQLTransaction(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "Ext_File_Load_API.Update_State(\r\n" +
                                        "                  :i_hWndFrame.sLoadFileId,\r\n" +
                                        "	  :i_hWndFrame.sState )")))
                                    {
                                        Sal.WaitCursor(false);
                                        return false;
                                    }
                                }
                                RePopulate();
                                cmdLoadFileId.RecordSelectionListSetSelect(cmdLoadFileId.GetSelectedItem());
                                Sal.WaitCursor(false);
                                RePopulate();
                                return true;
                            }
                            else
                            {
                                Sal.WaitCursor(false);
                                RePopulate();
                            }
                        }
                        // Bug 77126 End
                        break;
                }
            }

            return false;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="p_nWhat"></param>
        /// <returns></returns>
        public virtual SalBoolean UM_OutCompFlow(SalNumber p_nWhat)
        {
            #region Actions
            using (new SalContext(this))
            {
                switch (p_nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        if (dfsFileDirectionDb.Text == "1")
                        {
                            return false;
                        }
                        if (dfsStateDb.Text != "1")
                        {
                            return false;
                        }
                        if (dfFileName.Text == Ifs.Fnd.ApplicationForms.Const.strNULL)
                        {
                            return false;
                        }
                        if (dfsApiToCall.Text == Ifs.Fnd.ApplicationForms.Const.strNULL)
                        {
                            return false;
                        }
                        if ((SourceStateGet() == Ifs.Fnd.ApplicationForms.Const.DATASOURCE_Empty) || ((bool)Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0)))
                        {
                            return false;
                        }
                        return true;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        Sal.WaitCursor(true);
                        sLoadFileId = cmdLoadFileId.i_sMyValue;
                        using (SignatureHints hints = SignatureHints.NewContext())
                        {
                            hints.Add("External_File_Utility_API.Start_Api_To_Call", System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.Input);
                            if (!(DbPLSQLTransaction(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "External_File_Utility_API.Start_Api_To_Call (\r\n" +
                                "                  :i_hWndFrame.frmExternalFileTransactions.lsTemp,\r\n" +
                                "	  :i_hWndFrame.frmExternalFileTransactions.sLoadFileId )")))
                            {
                                Sal.WaitCursor(false);
                                HandleSqlResult(lsTemp);
                                return false;
                            }
                        }
                        if (!(HandleSqlResult(lsTemp)))
                        {
                            Sal.WaitCursor(false);
                            return false;
                        }
                        Sal.WaitCursor(false);

                        Sal.WaitCursor(true);
                        sLoadFileId = cmdLoadFileId.i_sMyValue;
                        using (SignatureHints hints = SignatureHints.NewContext())
                        {
                            hints.Add("External_File_Utility_API.Pack_Out_Ext_Line", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                            if (!(DbPLSQLTransaction(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "External_File_Utility_API.Pack_Out_Ext_Line(\r\n" +
                                "                  :i_hWndFrame.frmExternalFileTransactions.dfsFileType,\r\n" +
                                "	  :i_hWndFrame.frmExternalFileTransactions.dfsFileTemplateId,\r\n" +
                                "                  :i_hWndFrame.frmExternalFileTransactions.sLoadFileId,\r\n" +
                                "	  :i_hWndFrame.frmExternalFileTransactions.dfsCompany )")))
                            {
                                Sal.WaitCursor(false);
                                HandleSqlResult(lsTemp);
                                return false;
                            }
                        }
                        Sal.WaitCursor(false);
                        // Bug 77126 Begin
                        Sal.WaitCursor(true);
                        using (SignatureHints hints = SignatureHints.NewContext())
                        {
                            hints.Add("External_File_Utility_API.Create_Xml_File", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Output);
                            if (!(DbPLSQLTransaction(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "External_File_Utility_API.Create_Xml_File(\r\n" +
                                "                  :i_hWndFrame.frmExternalFileTransactions.sLoadFileId,\r\n" +
                                "	  :i_hWndFrame.frmExternalFileTransactions.sIsXmlType )")))
                            {
                                Sal.WaitCursor(false);
                                HandleSqlResult(lsTemp);
                                return false;
                            }
                        }
                        Sal.WaitCursor(false);
                        if (sIsXmlType == "FALSE")
                        {

                            Sal.WaitCursor(true);
                            strPath = dfFileName.Text;
                            sLoadFileId = cmdLoadFileId.i_sMyValue;
                            sFileName = dfFileName.Text;
                            using (SignatureHints hints = SignatureHints.NewContext())
                            {
                                hints.Add("External_File_Utility_API.Modify_File_Name", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.InputOutput);
                                if (!(DbPLSQLTransaction(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "External_File_Utility_API.Modify_File_Name(\r\n" +
                                    "                  :i_hWndFrame.frmExternalFileTransactions.sLoadFileId,\r\n" +
                                    "	  :i_hWndFrame.frmExternalFileTransactions.dfFileName )")))
                                {
                                    Sal.WaitCursor(false);
                                    return false;
                                }
                            }
                            strPath = dfFileName.Text;
                            if (OpenOutClientFile())
                            {
                                OutputClientFile();
                                sState = "7";
                                using (SignatureHints hints = SignatureHints.NewContext())
                                {
                                    hints.Add("Ext_File_Load_API.Update_State", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                                    if (!(DbPLSQLTransaction(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "Ext_File_Load_API.Update_State(\r\n" +
                                        "                  :i_hWndFrame.sLoadFileId,\r\n" +
                                        "	  :i_hWndFrame.sState )")))
                                    {
                                        Sal.WaitCursor(false);
                                        return false;
                                    }
                                }
                                RePopulate();
                                cmdLoadFileId.RecordSelectionListSetSelect(cmdLoadFileId.GetSelectedItem());
                                Sal.WaitCursor(false);
                                RePopulate();
                                return true;
                            }
                            else
                            {
                                Sal.WaitCursor(false);
                                RePopulate();
                            }
                        }
                        // Bug 77126 End
                        break;
                }
            }

            return false;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber OutputClientFile()
        {
            #region Local Variables
            SalNumber nCount = 0;
            SalNumber nNum = 0;
            SalNumber nSubNum = 0;
            SalNumber nRowWrite = 0;
            SalString lsFileLine = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                sFormName = ":i_hWndFrame." + Ifs.Fnd.ApplicationForms.Int.QualifiedItemNameGet(i_hWndSelf) + ".";
                sLoadFileId = cmdLoadFileId.i_sMyValue;
                nRowno = 0;
                nRowWrite = 0;
                sLastLine = "FALSE";
                nRowCount = 0;
                while (sLastLine == "FALSE")
                {
                    using (SignatureHints hints = SignatureHints.NewContext())
                    {
                        hints.Add("External_File_Utility_API.Create_Output_Message", System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.Input);
                        if (!(DbPLSQLBlock(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "External_File_Utility_API.Create_Output_Message(\r\n" +
                            " 	  :i_hWndFrame.frmExternalFileTransactions.lsOutMsg,\r\n" +
                            "                  :i_hWndFrame.frmExternalFileTransactions.sLastLine,\r\n" +
                            "	  :i_hWndFrame.frmExternalFileTransactions.nRowCount,\r\n" +
                            "                  :i_hWndFrame.frmExternalFileTransactions.nRowno,\r\n" +
                            "                  :i_hWndFrame.frmExternalFileTransactions.sLoadFileId )")))
                        {
                            return false;
                        }
                    }
                    MainMessage.Unpack(lsOutMsg);
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
                    Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_FinishWriteFile, Properties.Resources.TEXT_TitleExternalFileOutput, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                }
                return true;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="p_nWhat"></param>
        /// <returns></returns>
        public virtual SalBoolean UM_FileDefinition(SalNumber p_nWhat)
        {
            #region Local Variables
            SalArray<SalString> sItemNames = new SalArray<SalString>();
            SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                switch (p_nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        return !(Sal.IsNull(dfsFileType));

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        Sal.WaitCursor(true);
                        sItemNames[0] = "FILE_TEMPLATE_ID";
                        hWndItems[0] = dfsFileTemplateId;
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("FILE_TEMPLATE_ID", i_hWndSelf, sItemNames, hWndItems);
                        SessionCreateWindow(Pal.GetActiveInstanceName("frmExternalFileTemplate"), Sys.hWndMDI);
                        Sal.WaitCursor(false);
                        return true;
                }
            }

            return false;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="p_nWhat"></param>
        /// <returns></returns>
        public virtual SalBoolean UM_RemoveTrans(SalNumber p_nWhat)
        {
            #region Local Variables
            SalArray<SalString> sPlaceHolders = new SalArray<SalString>();
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                switch (p_nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        if (!(Sal.TblAnyRows(frmExternalFileTransactions.FromHandle(i_hWndSelf).tblExtFileTrans, 0, 0)))
                        {
                            return false;
                        }
                        if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Ext_File_Trans_API.Remove_File_Trans")))
                        {
                            return false;
                        }
                        if (dfsStateDb.Text == "7")
                        {
                            return false;
                        }
                        if (dfsStateDb.Text == "4")
                        {
                            return false;
                        }
                        if (dfsStateDb.Text == "8")
                        {
                            return false;
                        }
                        return true;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        sPlaceHolders[0] = cmdLoadFileId.i_sMyValue;
                        if (Ifs.Fnd.ApplicationForms.Int.AlertBoxWithParams(Properties.Resources.TEXT_RemoveTransFin, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Question, (Ifs.Fnd.ApplicationForms.Const.QUESTION_YesNo | Sys.MB_DefButton2), sPlaceHolders) ==
                        Sys.IDYES)
                        {
                            Sal.WaitCursor(true);
                            sLoadFileId = cmdLoadFileId.i_sMyValue;
                            using (SignatureHints hints = SignatureHints.NewContext())
                            {
                                hints.Add("Ext_File_Trans_API.Remove_File_Trans", System.Data.ParameterDirection.Input);
                                if (!(DbPLSQLTransaction(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "Ext_File_Trans_API.Remove_File_Trans( :i_hWndFrame.sLoadFileId)")))
                                {
                                    Sal.WaitCursor(false);
                                    return false;
                                }
                            }
                            RePopulate();
                            this.HideAllColumns();
                            Sal.DisableWindowAndLabel(tblExtFileTransColumn);
                            Sal.WaitCursor(false);
                            return true;
                        }
                        break;
                }
            }

            return false;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean OpenParamDialog()
        {
            #region Local Variables
            SalBoolean bEditable = false;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                bEditable = 1;
                if (dfsStateDb.Text == "4")
                {
                    bEditable = 0;
                }
                if (dfsStateDb.Text == "7")
                {
                    bEditable = 0;
                }
                // Bug 69856 (Changed from dfsSetId to dfsSetIdTest)
                if (dlgExternalFileParam.ModalDialog(i_hWndFrame, dfsFileType.Text, dfsSetIdTest.Text, dfsParameterString.Text, bEditable, ref lsParam) == Sys.IDOK)
                {
                    if (dfsParameterString.Text != lsParam)
                    {
                        dfsParameterString.Text = lsParam;
                        dfsParameterString.EditDataItemSetEdited();
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
        public virtual SalNumber CreateParam()
        {
            #region Local Variables
            SalString sDrive = "";
            SalString sDir = "";
            SalString sFile = "";
            SalString sExt = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                // Bug 69856 (Changed from dfsSetId to dfsSetIdTest)
                sSetId = dfsSetIdTest.Text;
                Sal.WaitCursor(true);
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("Ext_File_Message_API.Return_For_Trans_Form", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                    DbPLSQLBlock(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "Ext_File_Message_API.Return_For_Trans_Form (\r\n" +
                        "                  :i_hWndFrame.frmExternalFileTransactions.dfsFileType,\r\n" +
                        "	  :i_hWndFrame.frmExternalFileTransactions.sSetId,\r\n" +
                        "	  :i_hWndFrame.frmExternalFileTransactions.dfsParameterString,\r\n" +
                        "	  :i_hWndFrame.frmExternalFileTransactions.dfsFileTemplateId ,\r\n" +
                        "	  :i_hWndFrame.frmExternalFileTransactions.dfsFileDirectionDb ,\r\n" +
                        "	  :i_hWndFrame.frmExternalFileTransactions.cmbFileDirection ,\r\n" +
                        "	  :i_hWndFrame.frmExternalFileTransactions.dfFileName ,\r\n" +
                        "	  :i_hWndFrame.frmExternalFileTransactions.dfsCompany,\r\n" +
                        "	  :i_hWndFrame.frmExternalFileTransactions.sClientServer,\r\n" +
                        "	  :i_hWndFrame.frmExternalFileTransactions.sParamName,\r\n" +
                        "	  :i_hWndFrame.frmExternalFileTransactions.sParamValue  )");
                }
                dfsParameterString.EditDataItemSetEdited();
                if (dfFileName.Text != Ifs.Fnd.ApplicationForms.Const.strNULL)
                {
                    Vis.DosSplitPath(dfFileName.Text, ref sDrive, ref sDir, ref sFile, ref sExt);
                    if (dfsFileDirectionDb.Text == "1")
                    {
                        if (!(Vis.DosExist(dfFileName.Text)))
                        {
                            if (Vis.DosGetEnvString("TEMP") != Ifs.Fnd.ApplicationForms.Const.strNULL)
                            {
                                dfFileName.Text = Ifs.Fnd.ApplicationForms.Int.PalStrAppendWithSeparator(Vis.DosGetEnvString("TEMP"), sFile, "\\") + sExt;
                            }
                            else if (Vis.DosGetEnvString("TMP") != Ifs.Fnd.ApplicationForms.Const.strNULL)
                            {
                                dfFileName.Text = Ifs.Fnd.ApplicationForms.Int.PalStrAppendWithSeparator(Vis.DosGetEnvString("TEMP"), sFile, "\\") + sExt;
                            }
                            else
                            {
                                if (Sal.FileGetCurrentDirectory(ref sDir))
                                {
                                    dfFileName.Text = Ifs.Fnd.ApplicationForms.Int.PalStrAppendWithSeparator(sDir, sFile, "\\") + sExt;
                                }
                                else
                                {
                                    dfFileName.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (!(Vis.DosExist((sDrive + sDir))))
                        {
                            if (Vis.DosGetEnvString("TEMP") != Ifs.Fnd.ApplicationForms.Const.strNULL)
                            {
                                dfFileName.Text = Ifs.Fnd.ApplicationForms.Int.PalStrAppendWithSeparator(Vis.DosGetEnvString("TEMP"), sFile, "\\") + sExt;
                            }
                            else if (Vis.DosGetEnvString("TMP") != Ifs.Fnd.ApplicationForms.Const.strNULL)
                            {
                                dfFileName.Text = Ifs.Fnd.ApplicationForms.Int.PalStrAppendWithSeparator(Vis.DosGetEnvString("TEMP"), sFile, "\\") + sExt;
                            }
                            else
                            {
                                if (Sal.FileGetCurrentDirectory(ref sDir))
                                {
                                    dfFileName.Text = Ifs.Fnd.ApplicationForms.Int.PalStrAppendWithSeparator(sDir, sFile, "\\") + sExt;
                                }
                                else
                                {
                                    dfFileName.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                                }
                            }
                        }
                    }
                }
                sParamName = Ifs.Fnd.ApplicationForms.Const.strNULL;
                sParamValue = Ifs.Fnd.ApplicationForms.Const.strNULL;
                Sal.WaitCursor(false);
                return true;
            }
            #endregion
        }
        // Bug 79427, Begin
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public new SalString DataSourceFormatSqlColumnUser()
        {
            #region Actions
            using (new SalContext(this))
            {
                return "&AO.Ext_File_Trans_API.Check_Exist_File_Trans2(LOAD_FILE_ID)";
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public new SalString DataSourceFormatSqlIntoUser()
        {
            #region Actions
            using (new SalContext(this))
            {
                sFormName = ":i_hWndFrame." + Ifs.Fnd.ApplicationForms.Int.QualifiedItemNameGet(i_hWndSelf) + ".";
                return sFormName + "sLineFound";
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
        private void frmExternalFileTransactions_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate:
                    this.frmExternalFileTransactions_OnPM_DataSourcePopulate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove:
                    this.frmExternalFileTransactions_OnPM_DataRecordRemove(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew:
                    this.frmExternalFileTransactions_OnPM_DataRecordNew(sender, e);
                    break;

                // ! Bug 68737 - Begin.

                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave:
                    this.frmExternalFileTransactions_OnPM_DataSourceSave(sender, e);
                    break;

                // ! Bug 68737 - End.
            }
            #endregion
        }

        /// <summary>
        /// PM_DataSourcePopulate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmExternalFileTransactions_OnPM_DataSourcePopulate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Sys.wParam, Sys.lParam))
                {
                    Sal.TblClearSelection(this.tblExtFileTrans);
                    this.HideAllColumns();
                    this.sRecordTypeId = "";
                    this.nRownoRow = 0;
                    Sal.DisableWindowAndLabel(this.tblExtFileTransColumn);
                    Sal.EnableWindowAndLabel(this.pbBrowser);
                    e.Return = true;
                    return;
                }
                e.Return = false;
                return;
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataRecordRemove event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmExternalFileTransactions_OnPM_DataRecordRemove(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove, Sys.wParam, Sys.lParam))
            {
                if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
                {
                    this.HideAllColumns();
                    this.sRecordTypeId = "";
                    this.nRownoRow = 0;
                    Sal.DisableWindowAndLabel(this.tblExtFileTransColumn);
                    Sal.DisableWindowAndLabel(this.pbBrowser);
                    e.Return = false;
                    return;
                }
                e.Return = true;
                return;
            }
            e.Return = false;
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataRecordNew event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmExternalFileTransactions_OnPM_DataRecordNew(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                this.nRownoRow = 0;
                this.sRecordTypeId = "";
                this.cmdLoadFileId.SetSelectedItem(0);
                this.HideAllColumns();
                Sal.DisableWindowAndLabel(this.tblExtFileTransColumn);
                Sal.DisableWindowAndLabel(this.tblExtFileTrans);
                Sal.EnableWindowAndLabel(this.pbBrowser);
                Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew, Sys.wParam, Sys.lParam);
                Sal.SetFocus(this.dfsFileType);
                e.Return = true;
                return;
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataSourceSave event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmExternalFileTransactions_OnPM_DataSourceSave(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.bSaveOk = this.DataSourceSave(Sys.wParam);
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute && this.bSaveOk == true)
            {
                this.DataSourceRefresh(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
            }
            e.Return = this.bSaveOk;
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void cmdLoadFileId_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemNew:
                    this.cmdLoadFileId_OnPM_DataItemNew(sender, e);
                    break;

                // Bug 79427, Removed PM_DataItemPopulate
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemNew event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cmdLoadFileId_OnPM_DataItemNew(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemNew, Sys.wParam, Sys.lParam);
            this.sLineFound = "FALSE";
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void dfdLoadDate_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.dfdLoadDate_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfdLoadDate_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.dfsStateDb.Text == "4" || this.dfsStateDb.Text == "7" || this.cmdLoadFileId.i_sMyValue == Ifs.Fnd.ApplicationForms.Const.strNULL)
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
        private void dfsCompany_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.dfsCompany_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsCompany_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.dfsStateDb.Text == "4")
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
        private void dfsFileType_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovUserOrderBy:
                    e.Handled = true;
                    e.Return = ((SalString)"FILE_TYPE").ToHandle();
                    return;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.dfsFileType_OnPM_DataItemValidate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.dfsFileType_OnPM_DataItemQueryEnabled(sender, e);
                    break;
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
            Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
            if (this.dfsFileType.Text != Ifs.Fnd.ApplicationForms.Const.strNULL)
            {
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("Ext_File_Type_API.Get_View_Name", System.Data.ParameterDirection.Input);
                    if (!(this.dfsFileType.DbPLSQLBlock(cSessionManager.c_hSql, ":i_hWndFrame.frmExternalFileTransactions.sViewName :=  " + cSessionManager.c_sDbPrefix + "Ext_File_Type_API.Get_View_Name(\r\n" +
                        ":i_hWndFrame.frmExternalFileTransactions.dfsFileType)")))
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
                        e.Return = Sys.VALIDATE_Cancel;
                        return;
                    }
                }
                else
                {
                    using (SignatureHints hints = SignatureHints.NewContext())
                    {
                        hints.Add("Ext_File_Type_API.Get_Api_To_Call_Output", System.Data.ParameterDirection.Input);
                        if (!(this.dfsFileType.DbPLSQLBlock(cSessionManager.c_hSql, ":i_hWndFrame.frmExternalFileTransactions.sPackageName :=  " + cSessionManager.c_sDbPrefix + "Ext_File_Type_API.Get_Api_To_Call_Output(\r\n" +
                            ":i_hWndFrame.frmExternalFileTransactions.dfsFileType)")))
                        {
                            e.Return = false;
                            return;
                        }
                    }
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
                    else
                    {
                        using (SignatureHints hints = SignatureHints.NewContext())
                        {
                            hints.Add("Ext_File_Type_API.Get_Api_To_Call_Input", System.Data.ParameterDirection.Input);
                            if (!(this.dfsFileType.DbPLSQLBlock(cSessionManager.c_hSql, ":i_hWndFrame.dlgExternalFileWizard.sPackageName :=  " + cSessionManager.c_sDbPrefix + "Ext_File_Type_API.Get_Api_To_Call_Input(\r\n" +
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
                                // Bug 69856 (Changed from dfsSetId to dfsSetIdTest)
                                this.dfsSetIdTest.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                                Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.ERROR_FileTemplate, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                                e.Return = Sys.VALIDATE_Cancel;
                                return;
                            }
                        }
                    }
                }
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("Ext_File_Template_API.Get_File_Template_Id", System.Data.ParameterDirection.Input);
                    if (!(this.dfsFileType.DbPLSQLBlock(cSessionManager.c_hSql, ":i_hWndFrame.frmExternalFileTransactions.dfsFileTemplateId :=  " + cSessionManager.c_sDbPrefix + "Ext_File_Template_API.Get_File_Template_Id(\r\n" +
                        ":i_hWndFrame.frmExternalFileTransactions.dfsFileType)")))
                    {
                        this.dfsFileTemplateId.Text = Sys.STRING_Null;
                        e.Return = Sys.VALIDATE_Cancel;
                        return;
                    }
                }
                Sal.SendMsg(frmExternalFileTransactions.FromHandle(this.dfsFileType.i_hWndFrame).dfsFileTemplateId, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
                this.dfsFileTemplateId.EditDataItemSetEdited();
                // Bug 69856 (Changed from dfsSetId to dfsSetIdTest)
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("Ext_Type_Param_Set_API.Get_Default_Set_Id", System.Data.ParameterDirection.Input);
                    if (!(this.dfsFileType.DbPLSQLBlock(cSessionManager.c_hSql, ":i_hWndFrame.frmExternalFileTransactions.dfsSetIdTest :=  " + cSessionManager.c_sDbPrefix + "Ext_Type_Param_Set_API.Get_Default_Set_Id(\r\n" +
                        ":i_hWndFrame.frmExternalFileTransactions.dfsFileType)")))
                    {
                        this.dfsFileTemplateId.Text = Sys.STRING_Null;
                        e.Return = Sys.VALIDATE_Cancel;
                        return;
                    }
                }
            }
            // Bug 69856 (Changed from dfsSetId to dfsSetIdTest)
            this.dfsSetIdTest.EditDataItemSetEdited();
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
            if (this.dfsStateDb.Text == "4" || this.dfsStateDb.Text == "7" || this.cmdLoadFileId.i_sMyValue == Ifs.Fnd.ApplicationForms.Const.strNULL)
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

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.dfsSetIdTest_OnPM_DataItemQueryEnabled(sender, e);
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
            // Bug 69856 Start
            if (this.dfsSetIdTest.Text != Ifs.Fnd.ApplicationForms.Const.strNULL)
            {
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("Ext_Type_Param_Set_API.Exist_Cntrl", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                    if (!(this.dfsSetIdTest.DbPLSQLBlock(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "Ext_Type_Param_Set_API.Exist_Cntrl(\r\n" +
                        " 	  :i_hWndFrame.frmExternalFileTransactions.dfsFileType,\r\n" +
                        "                  :i_hWndFrame.frmExternalFileTransactions.dfsSetIdTest)")))
                    {
                        e.Return = Sys.VALIDATE_Cancel;
                        return;
                    }
                }
            }
            // Bug 69856 End
            this.dfsSetIdTest.DbTransactionBegin(ref cSessionManager.c_hSql);
            this.dfsParameterString.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
            this.dfsSetIdTest.EditDataItemSetEdited();
            this.sParamName = "SET_ID";
            this.sParamValue = this.dfsSetIdTest.Text;
            this.sClientServer = "C";
            this.CreateParam();
            this.dfsParameterString.EditDataItemSetEdited();
            this.dfsFileTemplateId.EditDataItemSetEdited();
            this.dfsFileDirectionDb.EditDataItemSetEdited();
            this.cmbFileDirection.EditDataItemSetEdited();
            this.dfFileName.EditDataItemSetEdited();
            this.dfsCompany.EditDataItemSetEdited();
            this.dfsSetIdTest.DbTransactionEnd(cSessionManager.c_hSql);
            e.Return = Sys.VALIDATE_Ok;
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsSetIdTest_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.dfsStateDb.Text == "4" || this.dfsStateDb.Text == "7" || this.cmdLoadFileId.i_sMyValue == Ifs.Fnd.ApplicationForms.Const.strNULL)
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
        private void dfsFileTemplateId_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.dfsFileTemplateId_OnPM_DataItemQueryEnabled(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.dfsFileTemplateId_OnPM_DataItemValidate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovDone:
                    this.dfsFileTemplateId_OnPM_DataItemLovDone(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemPopulate:
                    this.dfsFileTemplateId_OnPM_DataItemPopulate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsFileTemplateId_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.dfsStateDb.Text == "4" || this.dfsStateDb.Text == "7" || this.cmdLoadFileId.i_sMyValue == Ifs.Fnd.ApplicationForms.Const.strNULL)
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
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsFileTemplateId_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
            if (this.dfsFileTemplateId.Text != Ifs.Fnd.ApplicationForms.Const.strNULL)
            {
                this.dfsFileTemplateId.DbTransactionBegin(ref cSessionManager.c_hSql);
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("Ext_File_Template_Dir_API.Get_Direction_Info", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.InputOutput);
                    if (!(this.dfsFileTemplateId.DbPLSQLBlock(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "Ext_File_Template_Dir_API.Get_Direction_Info(\r\n" +
                        " 	  :i_hWndFrame.frmExternalFileTransactions.dfsFileTemplateId,\r\n" +
                        "                  :i_hWndFrame.frmExternalFileTransactions.dfFileTemplateIdName,\r\n" +
                        "                  :i_hWndFrame.frmExternalFileTransactions.dfsMultiDirection,\r\n" +
                        "                  :i_hWndFrame.frmExternalFileTransactions.dfsApiToCall,\r\n" +
                        "                  :i_hWndFrame.frmExternalFileTransactions.dfsViewName,\r\n" +
                        "                  :i_hWndFrame.frmExternalFileTransactions.dfsFormName,\r\n" +
                        "                  :i_hWndFrame.frmExternalFileTransactions.dfsTargetDefaultMethod)")))
                    {
                        this.dfsFileTemplateId.DbTransactionEnd(cSessionManager.c_hSql);
                        e.Return = Sys.VALIDATE_Cancel;
                        return;
                    }
                }
                this.dfsFileTemplateId.DbTransactionEnd(cSessionManager.c_hSql);
                this.dfsFileTemplateId.DbTransactionBegin(ref cSessionManager.c_hSql);
                this.sParamName = "FILE_TEMPLATE_ID";
                this.sParamValue = this.dfsFileTemplateId.Text;
                this.sClientServer = "C";
                this.CreateParam();
                this.dfsParameterString.EditDataItemSetEdited();
                this.dfsFileDirectionDb.EditDataItemSetEdited();
                this.cmbFileDirection.EditDataItemSetEdited();
                this.dfFileName.EditDataItemSetEdited();
                this.dfsCompany.EditDataItemSetEdited();
                this.dfsFileTemplateId.DbTransactionEnd(cSessionManager.c_hSql);
            }
            this.dfsParameterString.EditDataItemSetEdited();
            e.Return = Sys.VALIDATE_Ok;
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemLovDone event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsFileTemplateId_OnPM_DataItemLovDone(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.dfsFileTemplateId.Text != Ifs.Fnd.ApplicationForms.Const.strNULL)
            {
                this.dfsFileTemplateId.DbTransactionBegin(ref cSessionManager.c_hSql);
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("Ext_File_Template_Dir_API.Get_Direction_Info", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.InputOutput);
                    if (!(this.dfsFileTemplateId.DbPLSQLBlock(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "Ext_File_Template_Dir_API.Get_Direction_Info(\r\n" +
                        " 	  :i_hWndFrame.frmExternalFileTransactions.dfsFileTemplateId,\r\n" +
                        "                  :i_hWndFrame.frmExternalFileTransactions.dfFileTemplateIdName,\r\n" +
                        "                  :i_hWndFrame.frmExternalFileTransactions.dfsMultiDirection,\r\n" +
                        "                  :i_hWndFrame.frmExternalFileTransactions.dfsApiToCall,\r\n" +
                        "                  :i_hWndFrame.frmExternalFileTransactions.dfsViewName,\r\n" +
                        "                  :i_hWndFrame.frmExternalFileTransactions.dfsFormName,\r\n" +
                        "                  :i_hWndFrame.frmExternalFileTransactions.dfsTargetDefaultMethod)")))
                    {
                        this.dfsFileTemplateId.DbTransactionEnd(cSessionManager.c_hSql);
                        e.Return = false;
                        return;
                    }
                }
                this.dfsFileTemplateId.DbTransactionEnd(cSessionManager.c_hSql);
                this.dfsFileTemplateId.DbTransactionBegin(ref cSessionManager.c_hSql);
                this.sParamName = "FILE_TEMPLATE_ID";
                this.sParamValue = this.dfsFileTemplateId.Text;
                this.sClientServer = "C";
                this.CreateParam();
                this.dfsFileTemplateId.EditDataItemSetEdited();
                this.dfsParameterString.EditDataItemSetEdited();
                this.dfsFileDirectionDb.EditDataItemSetEdited();
                this.cmbFileDirection.EditDataItemSetEdited();
                this.dfFileName.EditDataItemSetEdited();
                this.dfsCompany.EditDataItemSetEdited();
                this.dfsFileTemplateId.DbTransactionEnd(cSessionManager.c_hSql);
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemPopulate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsFileTemplateId_OnPM_DataItemPopulate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.dfsFileTemplateId.Text != Ifs.Fnd.ApplicationForms.Const.strNULL)
            {
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("Ext_File_Template_Dir_API.Get_Direction_Info", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.InputOutput);
                    if (!(this.dfsFileTemplateId.DbPLSQLBlock(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "Ext_File_Template_Dir_API.Get_Direction_Info(\r\n" +
                        " 	  :i_hWndFrame.frmExternalFileTransactions.dfsFileTemplateId,\r\n" +
                        "                  :i_hWndFrame.frmExternalFileTransactions.dfFileTemplateIdName,\r\n" +
                        "                  :i_hWndFrame.frmExternalFileTransactions.dfsMultiDirection,\r\n" +
                        "                  :i_hWndFrame.frmExternalFileTransactions.dfsApiToCall,\r\n" +
                        "                  :i_hWndFrame.frmExternalFileTransactions.dfsViewName,\r\n" +
                        "                  :i_hWndFrame.frmExternalFileTransactions.dfsFormName,\r\n" +
                        "                  :i_hWndFrame.frmExternalFileTransactions.dfsTargetDefaultMethod)")))
                    {
                        this.dfsFileTemplateId.DbTransactionEnd(cSessionManager.c_hSql);
                        e.Return = false;
                        return;
                    }
                }
            }
            Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemPopulate, Sys.wParam, Sys.lParam);
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void cmbFileDirection_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.cmbFileDirection_OnPM_DataItemQueryEnabled(sender, e);
                    break;

                case Sys.SAM_Click:
                    this.cmbFileDirection_OnSAM_Click(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cmbFileDirection_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            // Bug 69856 (Changed from dfsSetId to dfsSetIdTest)
            if (this.dfsSetIdTest.Text != Ifs.Fnd.ApplicationForms.Const.strNULL)
            {
                if (this.dfsStateDb.Text == "4" || this.dfsStateDb.Text == "7")
                {
                    e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                    return;
                }
                if (this.dfsMultiDirection.Text == "TRUE" && this.dfsStateDb.Text == "1")
                {
                    e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldEnabled;
                    return;
                }
                else
                {
                    e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                    return;
                }
            }
            else if (this.cmdLoadFileId.i_sMyValue == Ifs.Fnd.ApplicationForms.Const.strNULL)
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
        private void cmbFileDirection_OnSAM_Click(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.nIndexCombo = Sal.ListQuerySelection(this.cmbFileDirection);
            if (this.nIndexCombo == 0)
            {
                this.dfsFileDirectionDb.Text = "1";
            }
            if (this.nIndexCombo == 1)
            {
                this.dfsFileDirectionDb.Text = "2";
            }
            this.dfsFileDirectionDb.EditDataItemSetEdited();
            this.cmbFileDirection.DbTransactionBegin(ref cSessionManager.c_hSql);
            this.sParamName = "FILE_DIRECTION_DB";
            this.sParamValue = this.dfsFileDirectionDb.Text;
            this.sClientServer = "C";
            this.CreateParam();
            this.dfsParameterString.EditDataItemSetEdited();
            this.dfsFileTemplateId.EditDataItemSetEdited();
            this.dfsFileDirectionDb.EditDataItemSetEdited();
            this.cmbFileDirection.EditDataItemSetEdited();
            this.dfFileName.EditDataItemSetEdited();
            this.dfsCompany.EditDataItemSetEdited();
            this.cmbFileDirection.DbTransactionEnd(cSessionManager.c_hSql);
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void pbBrowser_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_Click:
                    this.pbBrowser_OnSAM_Click(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_Click event handler.
        /// </summary>
        /// <param name="message"></param>
        private void pbBrowser_OnSAM_Click(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.dfsStateDb.Text == "4" || this.dfsStateDb.Text == "5" || this.dfsStateDb.Text == "7" || this.dfsStateDb.Text == "8")
            {
                e.Return = false;
                return;
            }
            e.Return = this.BrowseFile();
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void dfFileName_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.dfFileName_OnPM_DataItemQueryEnabled(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.dfFileName_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfFileName_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.dfsStateDb.Text == "4" || this.dfsStateDb.Text == "7" || this.cmdLoadFileId.i_sMyValue == Ifs.Fnd.ApplicationForms.Const.strNULL)
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
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfFileName_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.sParamName = "FILE_NAME";
            // Bug 79498 Begin
            if (this.dfsFileDirectionDb.Text == "1")
            {
                if (!(Vis.DosExist(this.dfFileName.Text)) && this.dfFileName.Text != Ifs.Fnd.ApplicationForms.Const.strNULL && this.dfsFileType.Text != Ifs.Fnd.ApplicationForms.Const.strNULL && this.dfsFileTemplateId.Text != Ifs.Fnd.ApplicationForms.Const.strNULL)
                {
                    Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_ExtFilePathDoesNotExist, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                    e.Return = false;
                    return;
                }
            }
            if (((SalString)this.dfFileName.Text).Length > 259)
            {
                Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_MaximumLengthFileName, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                e.Return = false;
                return;
            }
            // Bug 79498 End
            this.CheckPath();
            using (SignatureHints hints = SignatureHints.NewContext())
            {
                hints.Add("Ext_File_Message_API.Change_Attr_Parameter_Msg", System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                if (!(this.dfFileName.DbPLSQLBlock(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "Ext_File_Message_API.Change_Attr_Parameter_Msg (\r\n" +
                    "                  :i_hWndFrame.frmExternalFileTransactions.dfsParameterString,\r\n" +
                    "	  :i_hWndFrame.frmExternalFileTransactions.sParamName ,\r\n" +
                    "	  :i_hWndFrame.frmExternalFileTransactions.dfFileName )")))
                {
                    Sal.WaitCursor(false);
                    e.Return = Sys.VALIDATE_Cancel;
                    return;
                }
            }
            this.dfsParameterString.EditDataItemSetEdited();
            this.dfFileName.EditDataItemSetEdited();
            e.Return = Sys.VALIDATE_Ok;
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void dfsStateDb_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemPopulate:
                    this.dfsStateDb_OnPM_DataItemPopulate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemPopulate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsStateDb_OnPM_DataItemPopulate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.DisableEnableForm("Enable");
            if (this.dfsStateDb.Text == "1")
            {
                // State Empty
                this.HideAllColumns();
                Sal.DisableWindowAndLabel(this.tblExtFileTransColumn);
                Sal.DisableWindowAndLabel(this.tblExtFileTrans);
            }
            else if (this.dfsStateDb.Text == "2")
            {
                // State Loaded
                this.HideAllColumns();
                Sal.DisableWindowAndLabel(this.tblExtFileTransColumn);
                Sal.EnableWindowAndLabel(this.tblExtFileTrans);
            }
            else if (this.dfsStateDb.Text == "3")
            {
                // State Unpacked
                Sal.EnableWindowAndLabel(this.tblExtFileTransColumn);
                Sal.EnableWindowAndLabel(this.tblExtFileTrans);
            }
            else if (this.dfsStateDb.Text == "4")
            {
                // State Transferred
                Sal.EnableWindowAndLabel(this.tblExtFileTransColumn);
                Sal.EnableWindowAndLabel(this.tblExtFileTrans);
                this.DisableEnableForm("Disable");
            }
            else if (this.dfsStateDb.Text == "5")
            {
                // State Aborted
                Sal.EnableWindowAndLabel(this.tblExtFileTransColumn);
                Sal.EnableWindowAndLabel(this.tblExtFileTrans);
            }
            else if (this.dfsStateDb.Text == "6")
            {
                // State Packed
                Sal.EnableWindowAndLabel(this.tblExtFileTransColumn);
                Sal.EnableWindowAndLabel(this.tblExtFileTrans);
            }
            else if (this.dfsStateDb.Text == "7")
            {
                // State FileCreated
                Sal.EnableWindowAndLabel(this.tblExtFileTransColumn);
                Sal.EnableWindowAndLabel(this.tblExtFileTrans);
                // Call DisableEnableForm('Enable')
            }
            else if (this.dfsStateDb.Text == "8")
            {
                // State Removed
                this.HideAllColumns();
                Sal.DisableWindowAndLabel(this.tblExtFileTransColumn);
                Sal.DisableWindowAndLabel(this.tblExtFileTrans);
            }
            else if (this.dfsStateDb.Text == "9")
            {
                // State TransferError
                Sal.EnableWindowAndLabel(this.tblExtFileTransColumn);
                Sal.EnableWindowAndLabel(this.tblExtFileTrans);
            }
            else if (this.dfsStateDb.Text == "10")
            {
                // State PartlyTransferred
                Sal.EnableWindowAndLabel(this.tblExtFileTransColumn);
                Sal.EnableWindowAndLabel(this.tblExtFileTrans);
            }
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblExtFileTransColumn_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate:
                    this.tblExtFileTransColumn_OnPM_DataSourcePopulate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataSourcePopulate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblExtFileTransColumn_OnPM_DataSourcePopulate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Sys.wParam, Sys.lParam))
                {
                    this.ChangeColumnTitles();
                    e.Return = true;
                    return;
                }
                e.Return = false;
                return;
            }
            e.Return = false;
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblExtFileTrans_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_RowHeaderClick:
                    this.tblExtFileTrans_OnSAM_RowHeaderClick(sender, e);
                    break;

                case Sys.SAM_Click:
                    this.tblExtFileTrans_OnSAM_Click(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate:
                    this.tblExtFileTrans_OnPM_DataSourcePopulate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove:
                    this.tblExtFileTrans_OnPM_DataRecordRemove(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_RowHeaderClick event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblExtFileTrans_OnSAM_RowHeaderClick(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (!(this.nRownoRow == this.tblExtFileTrans_colnRowNo.Number))
            {
                Sal.EnableWindowAndLabel(this.tblExtFileTransColumn);
                Sal.SendMsg(frmExternalFileTransactions.FromHandle(this.tblExtFileTrans.i_hWndFrame).tblExtFileTransColumn, Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                this.nRownoRow = this.tblExtFileTrans_colnRowNo.Number;
                Sal.SetFocus(this.tblExtFileTrans);
                Sal.TblClearSelection(this.tblExtFileTransColumn);
            }
            #endregion
        }

        /// <summary>
        /// SAM_Click event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblExtFileTrans_OnSAM_Click(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (!(this.nRownoRow == this.tblExtFileTrans_colnRowNo.Number))
            {
                Sal.EnableWindowAndLabel(this.tblExtFileTransColumn);
                Sal.SendMsg(frmExternalFileTransactions.FromHandle(this.tblExtFileTrans.i_hWndFrame).tblExtFileTransColumn, Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                this.nRownoRow = this.tblExtFileTrans_colnRowNo.Number;
                Sal.SetFocus(this.tblExtFileTrans);
                Sal.TblClearSelection(this.tblExtFileTransColumn);
            }
            #endregion
        }

        /// <summary>
        /// PM_DataSourcePopulate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblExtFileTrans_OnPM_DataSourcePopulate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Sys.wParam, Sys.lParam))
                {
                    Sal.TblClearSelection(this.tblExtFileTrans);
                    e.Return = true;
                    return;
                }
                e.Return = false;
                return;
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataRecordRemove event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblExtFileTrans_OnPM_DataRecordRemove(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove, Sys.wParam, Sys.lParam))
                {
                    this.HideAllColumns();
                    Sal.DisableWindowAndLabel(this.tblExtFileTransColumn);
                    e.Return = true;
                    return;
                }
                e.Return = false;
                return;
            }
            else if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire)
            {
                if ((this.dfsStateDb.Text == "4") || (this.dfsStateDb.Text == "7"))
                {
                    e.Return = false;
                    return;
                }
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }
        #endregion

        #region Late Bind Methods

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalBoolean vrtDataRecordGetDefaults()
        {
            return this.DataRecordGetDefaults();
        }

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalString vrtDataSourceFormatSqlColumnUser()
        {
            return this.DataSourceFormatSqlColumnUser();
        }

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalString vrtDataSourceFormatSqlIntoUser()
        {
            return this.DataSourceFormatSqlIntoUser();
        }

        #endregion

        #region ChildTable-tblExtFileTransColumn

        #region Methods

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber ChangeColumnTitles()
        {
            #region Local Variables
            SalNumber nRows = 0;
            SalNumber n = 0;
            SalArray<SalString> sNames = new SalArray<SalString>();
            SalArray<SalString> sValues = new SalArray<SalString>();
            SalNumber nRows2 = 0;
            SalNumber n2 = 0;
            SalArray<SalString> sNames2 = new SalArray<SalString>();
            SalArray<SalString> sValues2 = new SalArray<SalString>();
            SalNumber nRows3 = 0;
            SalNumber n3 = 0;
            SalArray<SalString> sNames3 = new SalArray<SalString>();
            SalArray<SalString> sValues3 = new SalArray<SalString>();
            SalString sColName = "";
            SalString sColDesc = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                this.sFileTemplateId = this.dfsFileTemplateId.Text;
                this.sRecordTypeId = this.tblExtFileTrans_colsRecordTypeId.Text;
                IDictionary<string, string> namedBindVariables = new Dictionary<string, string>();
                namedBindVariables.Add("ColumnTranslationMsg",this.QualifiedVarBindName("sColumnTranslationMsg"));
                namedBindVariables.Add("FileTemplateId", this.QualifiedVarBindName("sFileTemplateId"));
                namedBindVariables.Add("RecordTypeId", this.tblExtFileTrans_colsRecordTypeId.QualifiedBindName);
                string stmt = @"&AO.EXT_FILE_TRANS_API.Get_Column_Names({ColumnTranslationMsg} OUT, {FileTemplateId} IN, {RecordTypeId} IN );";
               
                if (DbPLSQLBlock(stmt,namedBindVariables))
                {
                    this.cColumnTranslationMsg.Unpack(this.sColumnTranslationMsg);
                    if (this.cColumnTranslationMsg.GetName() == "COLUMNNAMES")
                    {
                        Sal.SendMsgToChildren(this.tblExtFileTransColumn, Const.PAM_ExtEnableDisable, Const.METHOD_ExtDisable, Sys.lParam);
                        nRows = this.cColumnTranslationMsg.EnumAttributes(sNames, sValues);
                        n = 0;
                        while (n < nRows)
                        {
                            this.cColumnTranslationMsg2.Unpack(sValues[n]);
                            if (this.cColumnTranslationMsg2.GetName() == "DETAILS")
                            {
                                nRows2 = this.cColumnTranslationMsg2.EnumAttributes(sNames2, sValues2);
                                n2 = 0;
                                if (nRows2 < 1)
                                {
                                    Sal.SendMsgToChildren(this.tblExtFileTransColumn, Const.PAM_ExtEnableDisable, Const.METHOD_ExtEnableDefault, Sys.lParam);
                                }
                                else
                                {
                                    while (n2 < nRows2)
                                    {
                                        this.cColumnTranslationMsg3.Unpack(sValues2[n2]);
                                        if (this.cColumnTranslationMsg3.GetName() == "LINE")
                                        {
                                            nRows3 = this.cColumnTranslationMsg3.EnumAttributes(sNames3, sValues3);
                                            n3 = 0;
                                            sColName = this.cColumnTranslationMsg3.FindAttribute("NAME", Ifs.Fnd.ApplicationForms.Const.strNULL);
                                            sColDesc = this.cColumnTranslationMsg3.FindAttribute("TRANS", Ifs.Fnd.ApplicationForms.Const.strNULL);
                                            if (sColName != Ifs.Fnd.ApplicationForms.Const.strNULL)
                                            {
                                                Sal.SendMsgToChildren(this.tblExtFileTransColumn, Const.PAM_ExtTranslateTitle, sColName.ToHandle(), sColDesc.ToHandle());
                                            }
                                        }
                                        n2 = n2 + 1;
                                    }
                                }
                            }
                            n = n + 1;
                        }
                    }
                    Sal.PostMsg(this.tblExtFileTransColumn, Ifs.Fnd.ApplicationForms.Const.PM_TableColumnsOptimize, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                }
                else
                {
                    Sal.SendMsgToChildren(this.tblExtFileTransColumn, Const.PAM_ExtEnableDisable, Const.METHOD_ExtDisable, Sys.lParam);
                }
                
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean HideAllColumns()
        {
            #region Actions
            using (new SalContext(this))
            {
                Sal.SendMsgToChildren(this.tblExtFileTransColumn, Const.PAM_ExtEnableDisable, Const.METHOD_ExtDisable, Sys.lParam);
                Sal.PostMsg(this.tblExtFileTransColumn, Ifs.Fnd.ApplicationForms.Const.PM_TableColumnsOptimize, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                return true;
            }
            #endregion
        }
        #endregion

        #endregion

        #region ChildTable-tblExtFileTrans

        #region Methods
        //Shhelk - Introduced this custom method to avoid code duplication in window actions 
        protected virtual void CustomDataItemQueryEnabled(WindowActionsEventArgs e)
        {
            if ((this.dfsStateDb.Text == "4") || (this.dfsStateDb.Text == "7"))
            {
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                return;
            }
            else
            {
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldEnabled;
                return;
            }
        }
        #endregion

        #region Window Actions

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblExtFileTransColumn_colnLoadFileId_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.tblExtFileTransColumn_colnLoadFileId_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblExtFileTransColumn_colnLoadFileId_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            CustomDataItemQueryEnabled(e);
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblExtFileTransColumn_colnRowNo_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.tblExtFileTransColumn_colnRowNo_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblExtFileTransColumn_colnRowNo_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            CustomDataItemQueryEnabled(e);
            #endregion
        }

       

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblExtFileTransColumn_colFileLine_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.tblExtFileTransColumn_colFileLine_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblExtFileTransColumn_colFileLine_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            CustomDataItemQueryEnabled(e);
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblExtFileTransColumn_colsRowState_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.tblExtFileTransColumn_colsRowState_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblExtFileTransColumn_colsRowState_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            CustomDataItemQueryEnabled(e);
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblExtFileTransColumn_colnRecordSetNo_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.tblExtFileTransColumn_colnRecordSetNo_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblExtFileTransColumn_colnRecordSetNo_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            CustomDataItemQueryEnabled(e);
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblExtFileTransColumn_colsRecordTypeId_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.tblExtFileTransColumn_tblExtFileTransColumn_colsRecordTypeId_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblExtFileTransColumn_tblExtFileTransColumn_colsRecordTypeId_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            CustomDataItemQueryEnabled(e);
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblExtFileTransColumn_colErrorText_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.tblExtFileTransColumn_colErrorText_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblExtFileTransColumn_colErrorText_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            CustomDataItemQueryEnabled(e);
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblExtFileTransColumn_colsControlId_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.tblExtFileTransColumn_colsControlId_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblExtFileTransColumn_colsControlId_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            CustomDataItemQueryEnabled(e);
            #endregion
        }
        #endregion

        #endregion

        #region Event Handlers

        private void menuItem__Load_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = ExtParam(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem__Load_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            ExtParam(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem__External_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = ExtLog(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem__External_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            ExtLog(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void popupMenu__Input_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = UM_Input();
        }

        private void menuItem__Load_1_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = UM_InpLoadFile(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem__Load_1_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            UM_InpLoadFile(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem__Unpack_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = UM_InpUnpackFile(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem__Unpack_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            UM_InpUnpackFile(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem_Call_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = UM_InpPackageMethod(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem_Call_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            UM_InpPackageMethod(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem_Complete_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = UM_InpCompFlow(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem_Complete_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            UM_InpCompFlow(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void popupMenu__Output_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = UM_Output();
        }

        private void menuItem_Call_1_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = UM_OutPackageMethod(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem_Call_1_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            UM_OutPackageMethod(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem__Pack_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = UM_OutPackFile(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem__Pack_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            UM_OutPackFile(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem_Create_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = UM_OutPutFile(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem_Create_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            UM_OutPutFile(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem__Complete_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = UM_OutCompFlow(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem__Complete_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            UM_OutCompFlow(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem__External_1_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = UM_FileDefinition(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem__External_1_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            UM_FileDefinition(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem_Remove_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = UM_RemoveTrans(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem_Remove_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            UM_RemoveTrans(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        #endregion

    }
}
