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
using System.Drawing;
using Ifs.Fnd.ApplicationForms;
using Ifs.Fnd.Windows.Forms;
using PPJ.Runtime;
using PPJ.Runtime.Sql;
using PPJ.Runtime.Windows;

namespace Ifs.Application.Fndmig_
{

    /// <summary>
    /// </summary>
    [FndWindowRegistration("INTFACE_JOB_DETAIL", "IntfaceJobDetail")]
    public partial class tbwIntfaceJobDetail : cTableWindow
    {
        #region Window Variables
        public SalString sIntfName = "";
        public SalNumber nMsgReturn = 0;
        public SalString lsInitOk = "";
        public SalString lsBackupName = "";
        public SalString sFileName = "";
        public SalString sPathName = "";
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public tbwIntfaceJobDetail()
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
        public new static tbwIntfaceJobDetail FromHandle(SalWindowHandle handle)
        {
            return ((tbwIntfaceJobDetail)SalWindow.FromHandle(handle, typeof(tbwIntfaceJobDetail)));
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
            #region Actions
            using (new SalContext(this))
            {
                if (sMethod == "LoadFile")
                {
                    return LoadFile(nWhat);
                }
                else if (sMethod == "ExportToFile")
                {
                    return ExportToFile(nWhat);
                }
                return 0;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalBoolean LoadFile(SalNumber nWhat)
        {
            #region Local Variables
            SalString sFileString = "";
            SalArray<SalString> sFilters = new SalArray<SalString>();
            SalNumber nFilters = 0;
            SalNumber nIndex = 0;
            SalBoolean bCommandOk = false;
            SalBoolean bOk = false;
            SalString sDelimiter = "";
            SalNumber nFileLength = 0;
            SalNumber nPathLength = 0;
            SalString sWholePathName = "";
            SalString sFileNameOnClient = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        if (Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceIsDirty, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0))
                        {
                            return false;
                        }
                        else if (frmIntfaceStart.FromHandle(i_hWndParent).dfsFileLocation.Text == frmIntfaceStart.FromHandle(i_hWndParent).lsLocNoFile)
                        {
                            return false;
                        }
                        else if (frmIntfaceStart.FromHandle(i_hWndParent).dfsStatus.Text != frmIntfaceStart.FromHandle(i_hWndParent).lsStatNoFile)
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                        goto case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        if (frmIntfaceStart.FromHandle(i_hWndParent).dfsFileLocation.Text == frmIntfaceStart.FromHandle(i_hWndParent).lsOnClient)
                        {
                            // Retrieves files using standard windows file open dialog
                            sFilters[0] = Properties.Resources.FILE_All;
                            sFilters[1] = "*.*";
                            sFilters[2] = Properties.Resources.FILE_Text;
                            sFilters[3] = "*.txt";
                            sFilters[4] = Properties.Resources.FILE_Dat;
                            sFilters[5] = "*.dat";
                            nFilters = 6;
                            // Set sFileNameOnClient = i_hWndParent.frmIntfaceStart.dfsFileLocation
                            sFileNameOnClient = frmIntfaceStart.FromHandle(i_hWndParent).dfsFileLocationDb.Text;
                            if (sFileNameOnClient == "2")
                            {
                                sFileName = frmIntfaceStart.FromHandle(i_hWndParent).dfsIntfaceFile.Text;
                            }
                            sPathName = frmIntfaceStart.FromHandle(i_hWndParent).dfsIntfacePath.Text;
                            bCommandOk = Sal.DlgOpenFile(Sys.hWndMDI, Properties.Resources.INTF_SelectFile, sFilters, nFilters, ref nIndex, ref sFileName, ref sPathName);
                            if (bCommandOk)
                            {
                                // ASCII 010 = Line Feed
                                sDelimiter = ((SalNumber)10).ToCharacter();
                                bCommandOk = cIntfLight.Load(sPathName, sDelimiter, i_hWndSelf, "file_string");
                                lineLengthCheck();
                                if (bCommandOk)
                                {
                                    // Prepare backup of client file
                                    Ifs.Fnd.ApplicationForms.Var.Console.Add("sPathName " + sPathName);
                                    Ifs.Fnd.ApplicationForms.Var.Console.Add("sFileName " + sFileName);
                                    nFileLength = sFileName.Length;
                                    nPathLength = sPathName.Length;
                                    sWholePathName = sPathName;
                                    sPathName = sPathName.Left((nPathLength - (nFileLength + 1)));
                                    Ifs.Fnd.ApplicationForms.Var.Console.Add("sPathName " + sPathName);
                                    DbImmediate("SELECT " + cSessionManager.c_sDbPrefix + "Intface_Job_Detail_API.Get_Backup_File(:i_hWndParent.frmIntfaceStart.cmbIntfaceName.i_sMyValue,\r\n" +
                                        "                                             :i_hWndSelf.sPathName, :i_hWndSelf.sFileName) INTO :i_hWndSelf.lsBackupName FROM dual");
                                    lsBackupName = lsBackupName.Trim();
                                    Ifs.Fnd.ApplicationForms.Var.Console.Add("lsBackupName " + lsBackupName);
                                    if (lsBackupName != "")
                                    {
                                        // Do backup of client file
                                        bCommandOk = BackupFile(sWholePathName, lsBackupName);
                                    }
                                }
                            }
                            return bCommandOk;
                        }
                        else
                        {
                            // lsFileLoc = 'OnServer'
                            Sal.WaitCursor(true);
                            Sal.GetWindowText(frmIntfaceStart.FromHandle(i_hWndParent).cmbIntfaceName, ref sIntfName, 30);
                            DbTransactionBegin(ref cSessionManager.c_hSql);
                            using (SignatureHints hints = SignatureHints.NewContext())
                            {
                                hints.Add("Intface_Job_Detail_API.Load_Server_File", System.Data.ParameterDirection.Input);
                                if (!(DbPLSQLBlock(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "Intface_Job_Detail_API.Load_Server_File" + "(:i_hWndFrame.tbwIntfaceJobDetail.sIntfName)")))
                                {
                                    DbTransactionClear(cSessionManager.c_hSql);
                                    Sal.WaitCursor(false);
                                    return false;
                                }
                            }
                            DbTransactionEnd(cSessionManager.c_hSql);
                            Sal.WaitCursor(false);
                            frmIntfaceStart.FromHandle(i_hWndParent).cmbIntfaceName.RecordSelectionListSetSelect(frmIntfaceStart.FromHandle(i_hWndParent).cmbIntfaceName.GetSelectedItem());
                            return true;
                        }
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
        public virtual SalBoolean ExportToFile(SalNumber nWhat)
        {
            #region Local Variables
            SalString sFileString = "";
            SalArray<SalString> sFilters = new SalArray<SalString>();
            SalNumber nFilters = 0;
            SalNumber nIndex = 0;
            //cIntfLight cInterface = new cIntfLight();
            SalBoolean bCommandOk = false;
            SalBoolean bOk = false;
            SalString sDelimiter = "";
            SalNumber nFileLength = 0;
            SalNumber nRow = 0;
            SalNumber nPathLength = 0;
            SalString sWholePathName = "";
            SalString sFilePath = "";
            SalString sFileNameOnClient = "";
            SalFileHandle hFile = SalFileHandle.Null;
            SalArray<SalString> sParam = new SalArray<SalString>();
            SalString sRuleFlag = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        if (Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceIsDirty, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0))
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                        goto case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        Ifs.Fnd.ApplicationForms.Var.g_Bind.s[0] = colsIntfaceName.Text;
                        Ifs.Fnd.ApplicationForms.Var.g_Bind.s[1] = "DEPLOYFILE";
                        using (SignatureHints hints = SignatureHints.NewContext())
                        {
                            hints.Add("Intface_Rules_Api.Get_Rule_Flag", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                            if (DbPLSQLBlock(cSessionManager.c_hSql, ":g_Bind.s[2] := &AO.Intface_Rules_Api.Get_Rule_Flag( :g_Bind.s[0] ,:g_Bind.s[1] )"))
                            {
                                using (SignatureHints hints1 = SignatureHints.NewContext())
                                {
                                    hints1.Add("Intface_Rule_Flag_API.Encode", System.Data.ParameterDirection.Input);
                                    if (DbPLSQLBlock(cSessionManager.c_hSql, ":g_Bind.s[3] := &AO.Intface_Rule_Flag_API.Encode( :g_Bind.s[2])"))
                                    {
                                        sRuleFlag = Ifs.Fnd.ApplicationForms.Var.g_Bind.s[3];
                                    }
                                }
                            }
                        }
                        if (sRuleFlag == "1")
                        {
                            sFilters[0] = Properties.Resources.FILE_Ins;
                            sFilters[1] = "*.ins";
                            nFilters = 2;
                            nIndex = 1;
                        }
                        else if (sRuleFlag == "2")
                        {
                            sFilters[0] = Properties.Resources.FILE_Text;
                            sFilters[1] = "*.txt";
                            nFilters = 2;
                            nIndex = 1;
                        }
                        else
                        {
                            sFilters[0] = Properties.Resources.FILE_All;
                            sFilters[1] = "*.*";
                            sFilters[2] = Properties.Resources.FILE_Text;
                            sFilters[3] = "*.txt";
                            sFilters[4] = Properties.Resources.FILE_Ins;
                            sFilters[5] = "*.ins";
                            nFilters = 6;
                            nIndex = 3;
                        }
                        // Set sFileNameOnClient = i_hWndParent.frmIntfaceStart.dfsFileLocation dfsFileLocationDb
                        sFileNameOnClient = frmIntfaceStart.FromHandle(i_hWndParent).dfsFileLocationDb.Text;
                        if (sFileNameOnClient == "2")
                        {
                            sFileName = frmIntfaceStart.FromHandle(i_hWndParent).dfsIntfaceFile.Text;
                        }
                        if (sFileName == Ifs.Fnd.ApplicationForms.Const.strNULL)
                        {
                            sFileName = colsIntfaceName.Text;
                        }
                        sPathName = frmIntfaceStart.FromHandle(i_hWndParent).dfsIntfacePath.Text;
                        bCommandOk = Sal.DlgSaveFile(Sys.hWndMDI, Properties.Resources.INTF_SaveFile, sFilters, nFilters, ref nIndex, ref sFileName, ref sPathName);
                        if (bCommandOk)
                        {
                            Sal.WaitCursor(true);
                            if (hFile.Open(sPathName, ((Sys.OF_Create | Sys.OF_Write) | Sys.OF_Share_Deny_Write)))
                            {
                                sParam[0] = sFileName;
                                MethodProgressStart(i_hWndSelf, Properties.Resources.FNDMIG_Exporting_FileTitle, Ifs.Fnd.ApplicationForms.Int.TranslateConstantWithParams(Properties.Resources.FNDMIG_ExportingMessage, sParam), "WORKING", false, i_hWndSelf);
                                nRow = Sys.TBL_MinRow;
                                while (Sal.TblFindNextRow(i_hWndSelf, ref nRow, 0, 0))
                                {
                                    Sal.TblSetContext(i_hWndSelf, nRow);
                                    hFile.PutString(colFileString.Text);
                                    MethodProgressStep();
                                }
                                MethodProgressDone();
                            }
                            hFile.Close();
                            Sal.WaitCursor(false);
                        }
                        return bCommandOk;

                    default:
                        return false;
                }
            }

            return false;
            #endregion
        }

        /// <summary>
        /// Take copy of source file and put it in destination directory,
        /// and then source file is deleted.
        /// </summary>
        /// <param name="sScourceFile"></param>
        /// <param name="sDestFile"></param>
        /// <returns></returns>
        public virtual SalBoolean BackupFile(SalString sScourceFile, SalString sDestFile)
        {
            #region Local Variables
            SalNumber nFileStatus = 0;
            SalBoolean bOk = false;
            SalArray<SalString> sDummyArray = new SalArray<SalString>();
            SalFileHandle hFile = SalFileHandle.Null;
            SalString sErrMsg = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                if (sDestFile.ToUpper() == sScourceFile.ToUpper())
                {
                    // If source file is the same as the destination file, then moving is meaningless
                    return true;
                }
                nFileStatus = Sal.FileCopy(sScourceFile, sDestFile, true);
                Ifs.Fnd.ApplicationForms.Var.Console.Add("nFileStatus " + nFileStatus.ToString(0));
                if (nFileStatus == Sys.FILE_CopyOK)
                {
                    // Delete source file
                    bOk = hFile.Open(sScourceFile, Sys.OF_Delete);
                    if (!(bOk))
                    {
                        // Set sParamArray[0] = sScourceFile
                        // Set sErrMsg = TranslateConstantWithParams(INTF_DeleteError, sParamArray)
                        sErrMsg = Properties.Resources.INTF_DeleteError;
                    }
                }
                else
                {
                    bOk = false;
                    // Set sParamArray[0] = sScourceFile
                    // Set sErrMsg = TranslateConstantWithParams(INTF_CopyError, sParamArray)
                    sErrMsg = Properties.Resources.INTF_CopyError;
                }
                // Set bOK = (nFileStatus = FILE_CopyOK)
                if (!(bOk))
                {
                    sDummyArray.SetUpperBound(1, -1);
                    sDummyArray[0] = sScourceFile;
                    sDummyArray[1] = sDestFile;
                    Ifs.Fnd.ApplicationForms.Int.AlertBoxWithParams(sErrMsg, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Warning, Ifs.Fnd.ApplicationForms.Const.WARNING_Ok, sDummyArray);
                }
                return bOk;
            }
            #endregion
        }
        public virtual void lineLengthCheck()
        {
            Boolean errorExists = false;
            Color warningColor = Color.FromArgb(192, 225, 110);
            SalNumber nRow = Sys.TBL_MinRow;
            while (Sal.TblFindNextRow(i_hWndSelf, ref nRow, 0, 0))
            {
                Sal.TblSetContext(i_hWndSelf, nRow);
                if (colFileString.Text.Length == 4000)
                {
                    colFileString.CellColor = warningColor;
                    colnLineNo.CellColor = warningColor;
                    colAttributeString.CellColor = warningColor;
                    colErrorMessage.CellColor = warningColor;
                    colsStatus.CellColor = warningColor;
                    colnExecutionNo.CellColor = warningColor;
                    errorExists = true;
                }
            }
            if (errorExists)
            {
                Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_LineLengthError, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Warning, Ifs.Fnd.ApplicationForms.Const.WARNING_Ok);
            }
        }
        #endregion

        #region Late Bind Methods

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalNumber vrtUserMethod(SalNumber nWhat, SalString sMethod)
        {
            return this.UserMethod(nWhat, sMethod);
        }

        public override SalBoolean vrtDataRecordGetDefaults()
        {
            SalString lparam_text = null;
            SalString line_no_text = null;


            using (new SalContext(this))
            {

                lparam_text = Sal.NumberToHString(Sys.lParam);
                if (lparam_text.Scan("line_no:") == 0)
                {
                    line_no_text = lparam_text.Replace(0, 8, "");
                    if (line_no_text.IsValidInteger())
                    {
                        colnLineNo.SetText(line_no_text);
                        colnLineNo.EditDataItemSetEdited();
                    }

                }

            }
            return base.vrtDataRecordGetDefaults();
        }
        #endregion

        #region Event Handlers

        private void menuItem_Load_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            // TODO: Rewrite command event handler not to use UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            ((FndCommand)sender).Enabled = Sal.SendMsg(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, ((SalString)"LoadFile").ToHandle());
        }

        private void menuItem_Load_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            // TODO: Rewrite command event handler not to make use of UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            Sal.PostMsg(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, ((SalString)"LoadFile").ToHandle());
        }

        private void menuItem_Export_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            // TODO: Rewrite command event handler not to use UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            ((FndCommand)sender).Enabled = Sal.SendMsg(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, ((SalString)"ExportToFile").ToHandle());
        }

        private void menuItem_Export_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            // TODO: Rewrite command event handler not to make use of UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            Sal.PostMsg(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, ((SalString)"ExportToFile").ToHandle());
        }

        #endregion
    }
}
