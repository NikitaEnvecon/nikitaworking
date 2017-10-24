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
using Ifs.Fnd.Windows.Forms;
using PPJ.Runtime;
using PPJ.Runtime.Sql;
using PPJ.Runtime.Windows;
using PPJ.Runtime.Vis;

namespace Ifs.Application.Fndmig_
{
	
	/// <summary>
	/// </summary>
    [FndWindowRegistration("INTFACE_HEADER", "IntfaceHeader", FndWindowRegistrationFlags.HomePage)]
    [FndWindowRegistration("INTFACE_DETAIL", "IntfaceDetail", FndWindowRegistrationFlags.HomePage)]
    [FndWindowRegistration("INTFACE_RULES", "IntfaceRules", FndWindowRegistrationFlags.HomePage)]
    public partial class frmIntfaceHeader : cMasterDetailTabFormWindow
    {
        #region Window Variables
        public SalArray<SalString> sParamArray = new SalArray<SalString>();
        public SalString sOriginalProcName = "";
        public SalString lsDirection = "";
        public SalString sDirection = "";
        public SalString lsIn = "";
        public SalString lsOut = "";
        public SalString lsConversion = "";
        public SalString lsNone = "";
        public SalString lsExcel = "";
        public SalNumber bReturn = 0;
        public SalString lsInfo = "";
        public SalString sIntfaceName = "";
        public SalString lsDescription = "";
        public SalString sProcedureName = "";
        public SalString sViewName = "";
        public SalString sSourceName = "";
        public SalString lsSourceNameMeth = "";
        public SalString sSourceOwner = "";
        public SalString sExecSeq = "";
        public SalString sMethodName = "";
        public SalString lsNoteText = "";
        public SalString sMethodAction = "";
        public SalString sPrefixOption = "";
        public SalString sInfo = "";
        public SalString sFormName = "";
        public SalString sLineType = "";
        public SalString sTriggerName = "";
        public SalBoolean bOnInsert = false;
        public SalBoolean bOnUpdate = false;
        public SalBoolean bEnabled = false;
        public SalString lsManualMode = "";
        public SalString sMode = "";
        public SalString sAppOwner = "";
        public SalString sTableName = "";
        public SalString sReplCriteria = "";
        public SalString sReplCriteriaDb = "";
        public SalString sServProc = "";
        public SalString sOkServProc = "";
        public SalString sTabClientValue = "";
        public SalNumber nTabDbValue = 11;
        public SalString sDummy;
        public SalString sUpPrivilege;
        public SalNumber nMessage = 0;
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public frmIntfaceHeader()
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
        public new static frmIntfaceHeader FromHandle(SalWindowHandle handle)
        {
            return ((frmIntfaceHeader)SalWindow.FromHandle(handle, typeof(frmIntfaceHeader)));
        }
        #endregion

        #region Methods

        /// <summary>
        /// </summary>
        /// <returns>
        /// Applications should return FALSE to skip standard window startup logic (such
        /// as exectuing the "startup behavior" settings), or TRUE to allow standard logic.
        /// </returns>
        public new SalBoolean FrameStartupUser()
        {
            #region Actions
            using (new SalContext(this))
            {
                DbImmediate("SELECT " + cSessionManager.c_sDbPrefix + "Intface_Direction_API.Get_Client_Value(0),\r\n" +
                                    "                                            " + cSessionManager.c_sDbPrefix + "Intface_Direction_API.Get_Client_Value(1),\r\n" +
                                    "                                            " + cSessionManager.c_sDbPrefix + "Intface_Direction_API.Get_Client_Value(2),  \r\n" +
                                    "                                            " + cSessionManager.c_sDbPrefix + "Intface_Direction_API.Get_Client_Value(3), \r\n" +
                                    "                                            " + cSessionManager.c_sDbPrefix + "Intface_Direction_API.Get_Client_Value(5), \r\n" +
                                    "                                            " + cSessionManager.c_sDbPrefix + "Intface_Mode_API.Get_Client_Value(0)\r\n" +
                                    "                                  INTO :i_hWndFrame.frmIntfaceHeader.lsIn, \r\n" +
                                    "                                            :i_hWndFrame.frmIntfaceHeader.lsOut, \r\n" +
                                    "                                            :i_hWndFrame.frmIntfaceHeader.lsNone, \r\n" +
                                    "                                            :i_hWndFrame.frmIntfaceHeader.lsConversion, \r\n" +
                                    "                                            :i_hWndFrame.frmIntfaceHeader.lsExcel, \r\n" +
                                    "                                            :i_hWndFrame.frmIntfaceHeader.lsManualMode FROM dual");
                // Insert new code here...
                return true;
            }
            #endregion
        }
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public override SalNumber vrtActivate(fcURL URL)
        {
            using (new SalContext(this))
            {
                if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.RecCountGet() > 0)
                {
                    Sal.WaitCursor(true);
                    if (InitFromTransferredData())
                    {
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();
                    }
                    Sal.WaitCursor(false);
                    return false;
                }
                else
                {
                    return base.Activate(URL);
                }
            }
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
                if (sMethod == "CopyIntface")
                {
                    return CopyIntface(nWhat);
                }
                if (sMethod == "ShowSqlStmt")
                {
                    return ShowSqlStmt(nWhat);
                }
                if (sMethod == "QuerySourceCols")
                {
                    return QuerySourceCols(nWhat);
                }
                if (sMethod == "ExportTemplate")
                {
                    return ExportTemplate(nWhat);
                }
                if (sMethod == "ShowProcesses")
                {
                    return ShowProcesses(nWhat);
                }
                if (sMethod == "ScheduleJob")
                {
                    return ExecutePlan(nWhat);
                }
                return 0;
            }
            #endregion
        }

        /// <summary>
        /// Function to show window title/text
        /// </summary>
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalBoolean InvalidateTitle(SalNumber nWhat)
        {
            #region Actions
            using (new SalContext(this))
            {
                if (nWhat == Ifs.Fnd.ApplicationForms.Const.PM_DataItemPopulate || nWhat == Ifs.Fnd.ApplicationForms.Const.PM_DataItemSave)
                {
                    sParamArray[0] = SalString.FromHandle(ecmbIntfaceName.EditDataItemValueGet());
                    Sal.SetWindowText(i_hWndFrame, Ifs.Fnd.ApplicationForms.Int.TranslateConstantWithParams(Properties.Resources.WH_frmIntfaceHeader, sParamArray));
                    return true;
                }
                else if (nWhat == Ifs.Fnd.ApplicationForms.Const.PM_DataItemClear || nWhat == Ifs.Fnd.ApplicationForms.Const.PM_DataItemNew)
                {
                    Sal.SetWindowText(this, Properties.Resources.WH_frmIntfHeaderClear);
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
        /// <returns></returns>
        public virtual SalNumber DisableField()
        {
            #region Actions
            using (new SalContext(this))
            {
                sDirection = dfsDirection.Text;
                if (sDirection == lsIn || sDirection == lsNone || Sal.IsNull(dfsDirection))
                {
                    Sal.DisableWindowAndLabel(dfsWhereClause);
                }
                else
                {
                    Sal.EnableWindowAndLabel(dfsWhereClause);
                    Sal.EnableWindowAndLabel(dfsOrderByClause);
                    Sal.EnableWindowAndLabel(dfsGroupByClause);
                    Sal.EnableWindowAndLabel(dfnMinusPos);
                    Sal.EnableWindowAndLabel(dfsIntfacePath);
                    Sal.EnableWindowAndLabel(dfsIntfaceFile);
                    Sal.EnableWindowAndLabel(cmbFileLocation);
                    Sal.EnableWindowAndLabel(dfsDateFormat);
                    Sal.EnableWindowAndLabel(cmbColumnSeparator);
                    Sal.EnableWindowAndLabel(cmbColumnEmbrace);
                    Sal.EnableWindowAndLabel(cmbDecimalPoint);
                    Sal.EnableWindowAndLabel(cmbThousandSeparator);
                }
                if (sDirection == lsConversion)
                {
                    Sal.EnableWindowAndLabel(dfsSourceName);
                    Sal.EnableWindowAndLabel(dfsSourceOwner);
                    Sal.DisableWindowAndLabel(dfsIntfacePath);
                    Sal.DisableWindowAndLabel(dfsIntfaceFile);
                    Sal.DisableWindowAndLabel(cmbFileLocation);
                    Sal.DisableWindowAndLabel(dfsDateFormat);
                    Sal.DisableWindowAndLabel(cmbColumnSeparator);
                    Sal.DisableWindowAndLabel(cmbColumnEmbrace);
                    Sal.DisableWindowAndLabel(cmbDecimalPoint);
                    Sal.DisableWindowAndLabel(cmbThousandSeparator);
                    Sal.DisableWindowAndLabel(dfnMinusPos);
                }
                else if (sDirection == lsExcel)
                {
                    DbPLSQLBlock(cSessionManager.c_hSql,
                        @" BEGIN 
                            :i_hWndFrame.frmIntfaceHeader.sTabClientValue := 
                                 &AO.Intface_Format_Char_API.Get_Client_Value(
                                       :i_hWndFrame.frmIntfaceHeader.nTabDbValue IN); 
                        END;");
                    cmbColumnSeparator.Text = sTabClientValue;
                    Sal.DisableWindowAndLabel(dfsIntfacePath);
                    Sal.DisableWindowAndLabel(dfsIntfaceFile);
                    Sal.DisableWindowAndLabel(cmbFileLocation);
                    Sal.DisableWindowAndLabel(dfsSourceName);
                    Sal.DisableWindowAndLabel(dfsSourceOwner);
                    Sal.DisableWindowAndLabel(dfsDateFormat);
                    Sal.DisableWindowAndLabel(cmbColumnEmbrace);
                    Sal.DisableWindowAndLabel(cmbDecimalPoint);
                    Sal.DisableWindowAndLabel(cmbThousandSeparator);
                    Sal.DisableWindowAndLabel(dfnMinusPos);
                    Sal.DisableWindowAndLabel(cmbColumnSeparator);
                    Sal.DisableWindowAndLabel(dfsOrderByClause);
                    Sal.DisableWindowAndLabel(dfsGroupByClause);
                    Sal.DisableWindowAndLabel(dfsWhereClause);
                }
                else
                {
                    Sal.DisableWindowAndLabel(dfsSourceName);
                    Sal.DisableWindowAndLabel(dfsSourceOwner);
                    Sal.DisableWindowAndLabel(dfsOrderByClause);
                    Sal.DisableWindowAndLabel(dfsGroupByClause);
                    Sal.EnableWindowAndLabel(dfsIntfacePath);
                    Sal.EnableWindowAndLabel(dfsIntfaceFile);
                    Sal.EnableWindowAndLabel(cmbFileLocation);
                    Sal.EnableWindowAndLabel(dfsDateFormat);
                    Sal.EnableWindowAndLabel(cmbColumnSeparator);
                    Sal.EnableWindowAndLabel(cmbColumnEmbrace);
                    Sal.EnableWindowAndLabel(cmbDecimalPoint);
                    Sal.EnableWindowAndLabel(cmbThousandSeparator);
                    Sal.EnableWindowAndLabel(dfnMinusPos);
                }
                if (sDirection == lsOut)
                {
                    Sal.EnableWindowAndLabel(dfsOrderByClause);
                    Sal.EnableWindowAndLabel(dfsSourceName);
                    Sal.EnableWindowAndLabel(dfsSourceOwner);
                    Sal.EnableWindowAndLabel(dfsGroupByClause);
                }
                picTab.Enable(picTab.FindName("tbwIntfaceMethodList"), sDirection == lsConversion || sDirection == lsExcel);
                picTab.Enable(picTab.FindName("tbwIntfaceDetailConversion"), sDirection == lsConversion || sDirection == lsExcel);
                picTab.Enable(picTab.FindName("tbwIntfaceDetail"), sDirection != lsConversion && sDirection != lsExcel);
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalBoolean CopyIntface(SalNumber nWhat)
        {
            #region Local Variables
            SalBoolean bCommandOk = false;
            SalArray<SalString> sArray = new SalArray<SalString>();
            SalArray<SalString> sNewNameArray = new SalArray<SalString>();
            SalArray<SalWindowHandle> hWndArray = new SalArray<SalWindowHandle>();
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
                        Sal.WaitCursor(true);
                        Sal.GetWindowText(ecmbIntfaceName, ref sIntfaceName, 30);
                        if (Ifs.Fnd.ApplicationForms.Int.InputDialog(Properties.Resources.TEXT_IntfaceCopyTitle, Properties.Resources.TEXT_IntfaceCopyLabel, ref sInfo))
                        {
                            DbTransactionBegin(ref cSessionManager.c_hSql);
                            sInfo = sInfo.ToUpper();
                            sArray[0] = "INTFACE_NAME";
                            dfsNewName.Text = sInfo;
                            hWndArray[0] = dfsNewName;
                            using (SignatureHints hints = SignatureHints.NewContext())
                            {
                                hints.Add("Intface_Header_API.Copy_Intface", System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.Input);
                                if (DbPLSQLBlock(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "Intface_Header_API.Copy_Intface" + "(  :i_hWndFrame.frmIntfaceHeader.sInfo,\r\n" +
                                    "                                :i_hWndFrame.frmIntfaceHeader.sIntfaceName)"))
                                {
                                    DbTransactionEnd(cSessionManager.c_hSql);
                                }
                                else
                                {
                                    DbTransactionClear(cSessionManager.c_hSql);
                                    Sal.WaitCursor(false);
                                    return false;
                                }
                            }
                            Sal.WaitCursor(false);
                            Ifs.Fnd.ApplicationForms.Int.AlertBox(sInfo, Properties.Resources.ALERT_TitleCopyIntface, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                            Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init(Pal.GetActiveInstanceName("frmIntfaceHeader"), this, sArray, hWndArray);
                            InitFromTransferredData();
                            Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();
                            ecmbIntfaceName.RecordSelectionListSetSelect(0);
                            Sal.WaitCursor(false);
                            // Call SalCreateWindow ( 'frmIntfaceHeader', hWndMDI )
                            // Call Refresh(METHOD_Execute)
                            sInfo = Ifs.Fnd.ApplicationForms.Const.strNULL;
                            return true;
                        }
                        else
                        {
                            return false;
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
        public virtual SalBoolean ShowSqlStmt(SalNumber nWhat)
        {
            #region Local Variables
            SalBoolean bCommandOk = false;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        if (sDirection == lsConversion)
                        {
                            return true;
                        }
                        else if (Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceIsDirty, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0))
                        {
                            return false;
                        }
                        else
                        {
                            return false;
                        }
                        goto case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        Sal.WaitCursor(true);
                        Sal.GetWindowText(ecmbIntfaceName, ref sIntfaceName, 30);
                        DbTransactionBegin(ref cSessionManager.c_hSql);
                        using (SignatureHints hints = SignatureHints.NewContext())
                        {
                            hints.Add("Intface_Header_API.Show_Select_Stmt", System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.Input);
                            if (DbPLSQLBlock(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "Intface_Header_API.Show_Select_Stmt" + "(  :i_hWndFrame.frmIntfaceHeader.dflsHiddenSqlStatement,\r\n" +
                                "                                :i_hWndFrame.frmIntfaceHeader.sIntfaceName)"))
                            {
                                DbTransactionEnd(cSessionManager.c_hSql);
                            }
                            else
                            {
                                DbTransactionClear(cSessionManager.c_hSql);
                                Sal.WaitCursor(false);
                                return false;
                            }
                        }
                        Sal.WaitCursor(false);
                        Sal.SendMsg(frmIntfaceHeader.FromHandle(i_hWndFrame).dflsHiddenSqlStatement, Ifs.Fnd.ApplicationForms.Const.PM_DataItemEditor, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                        // Call Refresh(METHOD_Execute)
                        // Set sInfo = strNULL
                        return true;

                    default:
                        return false;
                }
            }

            return false;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="strLine"></param>
        /// <param name="strPrefix"></param>
        /// <returns></returns>
        public virtual SalString ReadLine(SalString strLine, SalString strPrefix)
        {
            #region Local Variables
            SalString strNull = "";
            SalNumber nOffset = 0;
            SalString strReturnString = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                strNull = "";
                Ifs.Fnd.ApplicationForms.Var.Console.Add("strPrefix: " + strPrefix);
                nOffset = strLine.Scan(strPrefix);
                Ifs.Fnd.ApplicationForms.Var.Console.Add("strLine: " + strLine);
                if (nOffset == -1)
                {
                    return strNull;
                }
                else
                {
                    strReturnString = Vis.StrSubstitute(strLine, strPrefix, strNull);
                    Ifs.Fnd.ApplicationForms.Var.Console.Add("strReturnString: " + strReturnString);
                    return strReturnString;
                }
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalBoolean ExportTemplate(SalNumber nWhat)
        {
            #region Local Variables
            SalNumber bCommandOk = 0;
            SalArray<SalString> sFilters = new SalArray<SalString>("0:3");
            SalNumber nFilters = 0;
            SalNumber nIndex = 0;
            SalString sFileName = "";
            SalString sPath = "";
            SalFileHandle fhDestFile = SalFileHandle.Null;
            SalSqlHandle c_hSql = SalSqlHandle.Null;
            SalString sMethodListCur = "";
            SalNumber nInd = 0;
            SalString sIntfaceNameFrom = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        if (sDirection == lsConversion)
                        {
                            return true;
                        }
                        else if (Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceIsDirty, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0))
                        {
                            return false;
                        }
                        else
                        {
                            return false;
                        }
                        goto case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        Sal.WaitCursor(true);
                        Sal.GetWindowText(ecmbIntfaceName, ref sIntfaceName, 30);
                        sFileName = sIntfaceName + ".tem";
                        sFilters[0] = "Template Files";
                        sFilters[1] = "*.tem";
                        sFilters[2] = "All Files";
                        sFilters[3] = "*.*";
                        nFilters = 4;
                        nIndex = 1;
                        if (Sal.DlgSaveFile(this, Properties.Resources.TEXT_ExportFile, sFilters, nFilters, ref nIndex, ref sFileName, ref sPath))
                        {
                            if (fhDestFile.Open(sFileName, (Sys.OF_Create | Sys.OF_Write)))
                            {
                                if (DbTransactionBegin(ref c_hSql))
                                {
                                    if (DbPrepareAndExecute(c_hSql, "SELECT to_char(execute_seq), view_name, method_name, note_text, action_db, prefix_option_db, source_name" + " FROM " + cSessionManager.c_sDbPrefix + "intface_method_list" + " INTO :i_hWndFrame.frmIntfaceHeader.sExecSeq, :i_hWndFrame.frmIntfaceHeader.sViewName,  :i_hWndFrame.frmIntfaceHeader.sMethodName," +
                                        " :i_hWndFrame.frmIntfaceHeader.lsNoteText,  :i_hWndFrame.frmIntfaceHeader.sMethodAction,  :i_hWndFrame.frmIntfaceHeader.sPrefixOption, :i_hWndFrame.frmIntfaceHeader.lsSourceNameMeth" + " WHERE intface_name = :i_hWndFrame.frmIntfaceHeader.ecmbIntfaceName.i_sMyValue" +
                                        " ORDER BY SIGN(INSTR(upper(method_name), " + "'" + "NEW" + "'" + ")) desc, execute_seq"))
                                    {
                                        if (!(fhDestFile.PutString("<INTFACE_HEAD>")))
                                        {
                                            fhDestFile.Close();
                                            Sal.MessageBox("Error Writing To File: " + sPath + sFileName, "FILE_ERROR", Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                                        }
                                        if (!(fhDestFile.PutString("<INTFACE_NAME>" + sIntfaceName + "<INTFACE_NAME>")))
                                        {
                                            fhDestFile.Close();
                                            Sal.MessageBox("Error Writing To File: " + sPath + sFileName, "FILE_ERROR", Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                                        }
                                        if (!(fhDestFile.PutString("<DESCRIPTION>" + dfsDescription.Text + "<DESCRIPTION>")))
                                        {
                                            fhDestFile.Close();
                                            Sal.MessageBox("Error Writing To File: " + sPath + sFileName, "FILE_ERROR", Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                                        }
                                        if (!(fhDestFile.PutString("<VIEW_NAME>" + dfsViewName.Text + "<VIEW_NAME>")))
                                        {
                                            fhDestFile.Close();
                                            Sal.MessageBox("Error Writing To File: " + sPath + sFileName, "FILE_ERROR", Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                                        }
                                        if (!(fhDestFile.PutString("<SOURCE_NAME>" + dfsSourceName.Text + "<SOURCE_NAME>")))
                                        {
                                            fhDestFile.Close();
                                            Sal.MessageBox("Error Writing To File: " + sPath + sFileName, "FILE_ERROR", Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                                        }
                                        if (!(fhDestFile.PutString("<SOURCE_OWNER>" + dfsSourceOwner.Text + "<SOURCE_OWNER>")))
                                        {
                                            fhDestFile.Close();
                                            Sal.MessageBox("Error Writing To File: " + sPath + sFileName, "FILE_ERROR", Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                                        }
                                        if (!(fhDestFile.PutString("<PROCEDURE_NAME>" + dfsProcedureName.Text + "<PROCEDURE_NAME>")))
                                        {
                                            fhDestFile.Close();
                                            Sal.MessageBox("Error Writing To File: " + sPath + sFileName, "FILE_ERROR", Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                                        }
                                        if (!(fhDestFile.PutString("<INTFACE_HEAD>")))
                                        {
                                            fhDestFile.Close();
                                            Sal.MessageBox("Error Writing To File: " + sPath + sFileName, "FILE_ERROR", Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                                        }
                                        while (true)
                                        {
                                            DbFetchNext(c_hSql, ref nInd);
                                            if (nInd == Sys.FETCH_EOF)
                                            {
                                                break;
                                            }
                                            if (!(fhDestFile.PutString("<INTFACE_METHOD>")))
                                            {
                                                fhDestFile.Close();
                                                Sal.MessageBox("Error Writing To File: " + sPath + sFileName, "FILE_ERROR", Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                                            }
                                            Ifs.Fnd.ApplicationForms.Var.Console.Add("lsSourceNameMeth: " + lsSourceNameMeth);
                                            if (!(fhDestFile.PutString("<EXECUTE_SEQ>" + sExecSeq + "<EXECUTE_SEQ>")))
                                            {
                                                fhDestFile.Close();
                                                Sal.MessageBox("Error Writing To File: " + sPath + sFileName, "FILE_ERROR", Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                                            }
                                            if (!(fhDestFile.PutString("<VIEW_NAME>" + sViewName + "<VIEW_NAME>")))
                                            {
                                                fhDestFile.Close();
                                                Sal.MessageBox("Error Writing To File: " + sPath + sFileName, "FILE_ERROR", Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                                            }
                                            if (!(fhDestFile.PutString("<METHOD_NAME>" + sMethodName + "<METHOD_NAME>")))
                                            {
                                                fhDestFile.Close();
                                                Sal.MessageBox("Error Writing To File: " + sPath + sFileName, "FILE_ERROR", Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                                            }
                                            if (!(fhDestFile.PutString("<METHOD_ACTION>" + sMethodAction + "<METHOD_ACTION>")))
                                            {
                                                fhDestFile.Close();
                                                Sal.MessageBox("Error Writing To File: " + sPath + sFileName, "FILE_ERROR", Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                                            }
                                            if (!(fhDestFile.PutString("<PREFIX_OPTION>" + sPrefixOption + "<PREFIX_OPTION>")))
                                            {
                                                fhDestFile.Close();
                                                Sal.MessageBox("Error Writing To File: " + sPath + sFileName, "FILE_ERROR", Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                                            }
                                            if (!(fhDestFile.PutString("<SOURCE_NAME_METH>" + lsSourceNameMeth + "<SOURCE_NAME_METH>")))
                                            {
                                                fhDestFile.Close();
                                                Sal.MessageBox("Error Writing To File: " + sPath + sFileName, "FILE_ERROR", Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                                            }
                                            if (!(fhDestFile.PutString("<INTFACE_METHOD>")))
                                            {
                                                fhDestFile.Close();
                                                Sal.MessageBox("Error Writing To File: " + sPath + sFileName, "FILE_ERROR", Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                                            }
                                        }
                                    }
                                    DbTransactionEnd(c_hSql);
                                }
                            }
                            else
                            {
                                Sal.MessageBox("Error Opening File: " + sPath + sFileName, "FILE_ERROR", Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                            }
                            fhDestFile.Close();
                        }
                        Sal.WaitCursor(false);
                        return true;

                    default:
                        return false;
                }
            }

            return false;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="bPopulateSingle"></param>
        /// <returns></returns>
        public SalBoolean DataSourcePopulateIt(SalBoolean bPopulateSingle)
        {
            #region Local Variables
            SalBoolean bOk = false;
            SalString sPrevDirection = "";
            SalString sPrevProcedureName = "";
            SalNumber nTabActive = 0;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                sPrevDirection = dfsDirection.Text;
                sPrevProcedureName = dfsProcedureName.Text;
                bOk = ((cDataSource)this).DataSourcePopulateIt(bPopulateSingle);
                picTab.Enable(picTab.FindName("Format"), dfsProcedureName.Text != "REPLICATION");
                picTab.Enable(picTab.FindName("Replication"), dfsProcedureName.Text == "REPLICATION");
                if (!(sPrevDirection == "" || sPrevProcedureName == ""))
                {
                    nTabActive = picTab.GetTop();
                    if ((sPrevDirection == dfsDirection.Text) && (nTabActive != 0) && (nTabActive != 1))
                    {
                        Sal.SetFocus(ecmbIntfaceName);
                        picTab.Enable(picTab.FindName("Format"), dfsProcedureName.Text != "REPLICATION");
                        picTab.Enable(picTab.FindName("Replication"), dfsProcedureName.Text == "REPLICATION");
                        return bOk;
                    }
                }
                if (dfsProcedureName.Text == "REPLICATION")
                {
                    picTab.BringToTop(1, true);
                }
                else
                {
                    picTab.BringToTop(0, true);
                }
                Sal.SetFocus(ecmbIntfaceName);
                return bOk;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalBoolean QuerySourceCols(SalNumber nWhat)
        {
            #region Local Variables
            SalBoolean bCommandOk = false;
            SalArray<SalString> sItemNames = new SalArray<SalString>();
            SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        if (sDirection == lsConversion)
                        {
                            return true;
                        }
                        else if (Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceIsDirty, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0))
                        {
                            return false;
                        }
                        else
                        {
                            return false;
                        }
                        goto case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        sItemNames[0] = "SOURCE_OWNER";
                        hWndItems[0] = dfsSourceOwner;
                        sItemNames[1] = "SOURCE_NAME";
                        hWndItems[1] = dfsSourceName;
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init(Ifs.Fnd.ApplicationForms.Int.QualifiedItemNameGet(this), this, sItemNames, hWndItems);
                        SessionNavigate(Pal.GetActiveInstanceName("tbwIntfaceSourceCols"));
                        // Call SalCreateWindow ( tbwIntfaceSourceCols, hWndNULL )
                        return true;

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
        public virtual SalBoolean Refresh(SalNumber nWhat)
        {
            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        return false;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        ecmbIntfaceName.RecordSelectionListSetSelect(ecmbIntfaceName.GetSelectedItem());
                        return true;

                    default:
                        return false;
                }
            }

            return false;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="sWindowName"></param>
        /// <returns></returns>
        public new SalNumber DataSourcePrepareKeyTransfer(SalString sWindowName)
        {
            #region Local Variables
            SalArray<SalString> sItemNames = new SalArray<SalString>();
            SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                if (sWindowName == Pal.GetActiveInstanceName("tbwIntfaceSourceCols"))
                {
                    sItemNames[0] = "SOURCE_OWNER";
                    hWndItems[0] = dfsSourceOwner;
                    sItemNames[1] = "SOURCE_NAME";
                    hWndItems[1] = dfsSourceName;
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init(Ifs.Fnd.ApplicationForms.Int.QualifiedItemNameGet(this), this, sItemNames, hWndItems);
                }
                else
                {
                    ((cDataSource)this).DataSourcePrepareKeyTransfer(sWindowName);
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber GetReplDefaultValues()
        {
            #region Actions
            using (new SalContext(this))
            {
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("Intface_Header_API.Get_Repl_Defaults", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output);
                    if (!(DbPLSQLBlock(cSessionManager.c_hSql, "&AO.Intface_Header_API.Get_Repl_Defaults(:i_hWndSelf.frmIntfaceHeader.dfsViewName, :i_hWndSelf.frmIntfaceHeader.sAppOwner,\r\n" +
                        ":i_hWndSelf.frmIntfaceHeader.sTableName, :i_hWndSelf.frmIntfaceHeader.sReplCriteria,\r\n" +
                        ":i_hWndSelf.frmIntfaceHeader.sReplCriteriaDb )")))
                    {
                        return false;
                    }
                }
                Sal.SendMsg(dfsSourceOwner, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, sAppOwner.ToHandle());
                Sal.SendMsg(dfsTableName, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, sTableName.ToHandle());
                Sal.SendMsg(cmbsReplCriteria, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, sReplCriteria.ToHandle());
                Sal.SendMsg(dfsSourceName, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, ((SalString)dfsViewName.Text).ToHandle());
                return true;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual void SetGlobalProc()
        {
            //setting the database context
            this.PLSQLContext.Set("INTFACE_RULES_API.INTF_PROCEDURE_NAME_", this.dfsProcedureName.Text);
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual void SetGlobalPath()
        {
            //setting the database context
            this.PLSQLContext.Set("INTFACE_SERVER_FILE_API.CURRENT_DIRECTORY_", this.dfsIntfacePath.Text);
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber GetTriggerWhen()
        {
            #region Actions
            using (new SalContext(this))
            {
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("Intface_Header_API.Make_Trigger_When", System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                    if (!(DbPLSQLBlock(cSessionManager.c_hSql, "&AO.Intface_Header_API.Make_Trigger_When(:i_hWndSelf.frmIntfaceHeader.dfsTriggerWhen, :i_hWndSelf.frmIntfaceHeader.cmbsReplCriteria,\r\n" +
                        ":i_hWndSelf.frmIntfaceHeader.dfsFromValue )")))
                    {
                        return false;
                    }
                }
                Sal.SetFieldEdit(dfsTriggerWhen, true);
                return true;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean GetServerProcFlag()
        {
            #region Actions
            using (new SalContext(this))
            {
                Sal.GetWindowText(ecmbIntfaceName, ref sIntfaceName, 30);
                DbImmediate("SELECT " + cSessionManager.c_sDbPrefix + "Intface_Repl_Maint_Util_API.Serv_Proc_Exists(:i_hWndFrame.frmIntfaceHeader.sIntfaceName)\r\n" +
                    "                                  INTO :i_hWndFrame.frmIntfaceHeader.sServProc FROM dual");
                return true;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean CheckServProc()
        {
            #region Actions
            using (new SalContext(this))
            {
                if (GetServerProcFlag())
                {
                    if (sServProc == "TRUE")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
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
        /// <returns></returns>
        public virtual SalNumber PrepareLaunch()
        {
            #region Local Variables
            SalArray<SalString> sArray = new SalArray<SalString>();
            SalArray<SalWindowHandle> hWndArray = new SalArray<SalWindowHandle>();
            SalNumber nCurrentTableRow = 0;
            // Variables for printing report
            SalNumber nResultKey = 0;
            SalString sPrintMode = "";
            SalString sReservResult = "";
            // Window handles for AlertBox
            SalNumber nReturn = 0;
            SalNumber hBtnPrint = 0;
            SalNumber hBtnPreview = 0;
            SalNumber hBtnCancel = 0;
            SalArray<SalNumber> hButtonArray = new SalArray<SalNumber>();
            SalString lsReportAttr = "";
            SalString lsParamAttr = "";
            SalNumber nIndex = 0;
            SalNumber nPrintJobId = 0;
            SalArray<SalString> lsInstanceAttr = new SalArray<SalString>();
            SalNumber nRow = 0;
            SalNumber nPrint = 0;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                Sal.WaitCursor(true);
                // We cannot use INTFACE name anymore to call tbwIntfaceServerProcesses
                // sArray[0] = "INTFACE_NAME";
                sArray[0] = "Intface_Util_API.Get_Schedule_Intface_Name_(SCHEDULE_ID)";
                hWndArray[0] = ecmbIntfaceName;
                Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init(Pal.GetActiveInstanceName("frmIntfaceHeader"), this, sArray, hWndArray);
                SessionNavigate(Pal.GetActiveInstanceName("tbwIntfaceServerProcesses"));
                Sal.WaitCursor(false);
                return true;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalBoolean ShowProcesses(SalNumber nWhat)
        {
            #region Local Variables
            SalBoolean bCommandOk = false;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        return CheckServProc();

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        PrepareLaunch();
                        return true;

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
        public virtual SalBoolean ExecutePlan(SalNumber nWhat)
        {
            #region Local Variables
            SalBoolean bCommandOk = false;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        if (Sal.IsNull(dfsProcedureName))
                        {
                            return false;
                        }
                        else if (dfsProcedureName.Text.Equals("EXCEL_MIGRATION"))
                        {
                            return false;
                        }
                        else if (Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceIsDirty, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0))
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                        goto case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        Sal.GetWindowText(this.ecmbIntfaceName, ref sIntfaceName, 30);
                        if (dlgExecPlan.ModalDialog(Ifs.Fnd.ApplicationForms.Int.Explorer.ExplorerForm, sIntfaceName, ref sInfo) == Sys.IDOK)
                        {
                            Ifs.Fnd.ApplicationForms.Int.AlertBox(sInfo, Properties.Resources.ALERT_TitleEx, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                            return true;
                        }
                        return false;

                    default:
                        return false;
                }
            }

            return false;
            #endregion
        }

        public new SalNumber DataRecordFetchEditedUser(ref SalString lsAttr)
        {

            #region Actions
            using (new SalContext(this))
            {
                if (dfsProcedureName.Text == "EXCEL_MIGRATION")
                {
                    Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("COLUMN_SEPARATOR", sTabClientValue, ref lsAttr);
                }
            }
            return 0;
            #endregion
        }

        /// <summary>
        /// Check if the current migration job has history details
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean HasHistoryDetail()
        {
            #region Actions
            Sal.GetWindowText(ecmbIntfaceName, ref sIntfaceName, 30);
            if (DbImmediate("SELECT 1 INTO :i_hWndFrame.frmIntfaceHeader.sDummy " +
                            "FROM " + cSessionManager.c_sDbPrefix + "Intface_Job_Hist_Head " +
                            "WHERE intface_name = :i_hWndFrame.frmIntfaceHeader.sIntfaceName"))
            {
                return sDummy == "1";
            }
            else
            {
                return false;
            }
            #endregion
        }

        public virtual SalBoolean ChangeAllowed()
        {
            #region Actions
            //If already have a value use it
            if (!string.IsNullOrEmpty(sUpPrivilege))
            {
                return sUpPrivilege.Equals("TRUE");
            }
            if (DbPLSQLBlock(cSessionManager.c_hSql, ":i_hWndFrame.frmIntfaceHeader.sUpPrivilege := &AO.Intface_User_API.Has_Update_Privilege"))
            {
                return (sUpPrivilege == "TRUE");
            }
            else
            {
                return false;
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
        private void frmIntfaceHeader_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_Create:
                    this.frmIntfaceHeader_OnSAM_Create(sender, e);
                    break;
                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew:
                    this.frmIntfaceHeader_OnPM_DataRecordNew(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_Create event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmIntfaceHeader_OnSAM_Create(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam);
            this.sFormName = ":i_hWndFrame." + Ifs.Fnd.ApplicationForms.Int.QualifiedItemNameGet(this);
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void ecmbIntfaceName_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemClear:
                    this.ecmbIntfaceName_OnPM_DataItemClear(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemSave:
                    this.ecmbIntfaceName_OnPM_DataItemSave(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemPopulate:
                    this.ecmbIntfaceName_OnPM_DataItemPopulate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemNew:
                    this.ecmbIntfaceName_OnPM_DataItemNew(sender, e);
                    break;

                case Sys.SAM_FieldEdit:
                    this.ecmbIntfaceName_OnSAM_FieldEdit(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemClear event handler.
        /// </summary>
        /// <param name="message"></param>
        private void ecmbIntfaceName_OnPM_DataItemClear(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.InvalidateTitle(Ifs.Fnd.ApplicationForms.Const.PM_DataItemClear);
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemClear, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemSave event handler.
        /// </summary>
        /// <param name="message"></param>
        private void ecmbIntfaceName_OnPM_DataItemSave(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.InvalidateTitle(Ifs.Fnd.ApplicationForms.Const.PM_DataItemSave);
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemSave, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemPopulate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void ecmbIntfaceName_OnPM_DataItemPopulate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemPopulate, Sys.wParam, Sys.lParam);
            this.InvalidateTitle(Ifs.Fnd.ApplicationForms.Const.PM_DataItemPopulate);
            e.Return = true;
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemNew event handler.
        /// </summary>
        /// <param name="message"></param>
        private void ecmbIntfaceName_OnPM_DataItemNew(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.InvalidateTitle(Ifs.Fnd.ApplicationForms.Const.PM_DataItemNew);
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemNew, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// SAM_FieldEdit event handler.
        /// </summary>
        /// <param name="message"></param>
        private void ecmbIntfaceName_OnSAM_FieldEdit(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Ifs.Fnd.ApplicationForms.Var.Console.Add("Inne i SAM FieldEdit");
            Sal.SetFieldEdit(this.ecmbIntfaceName, true);
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void dfsProcedureName_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemPopulate:
                    this.dfsProcedureName_OnPM_DataItemPopulate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.dfsProcedureName_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemPopulate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsProcedureName_OnPM_DataItemPopulate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemPopulate, Sys.wParam, Sys.lParam);
            this.picTab.Enable(this.picTab.FindName("Format"), this.dfsProcedureName.Text != "REPLICATION");
            this.picTab.Enable(this.picTab.FindName("Replication"), this.dfsProcedureName.Text == "REPLICATION");
            this.SetGlobalProc();
            e.Return = true;
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsProcedureName_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam) == Sys.VALIDATE_Cancel)
            {
                e.Return = Sys.VALIDATE_Cancel;
                return;
            }
            Ifs.Fnd.ApplicationForms.Int.PostMessage(this.dfsDirection, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, 0, SalString.Null);
            this.picTab.Enable(this.picTab.FindName("Format"), this.dfsProcedureName.Text != "REPLICATION");
            this.picTab.Enable(this.picTab.FindName("Replication"), this.dfsProcedureName.Text == "REPLICATION");
            if (this.dfsProcedureName.Text == "REPLICATION")
            {
                this.picTab.BringToTop(1, true);
            }
            else
            {
                this.picTab.BringToTop(0, true);
            }
            this.SetGlobalProc();
            e.Return = Sys.VALIDATE_Ok;
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void dfsViewName_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.dfsViewName_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsViewName_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.GetReplDefaultValues();
            e.Return = Sys.VALIDATE_Ok;
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void dfsDirection_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemPopulate:
                    this.dfsDirection_OnPM_DataItemPopulate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.dfsDirection_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemPopulate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsDirection_OnPM_DataItemPopulate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemPopulate, Sys.wParam, Sys.lParam);
            this.DisableField();
            e.Return = true;
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsDirection_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam) == Sys.VALIDATE_Cancel)
            {
                e.Return = Sys.VALIDATE_Cancel;
                return;
            }
            this.DisableField();
            e.Return = Sys.VALIDATE_Ok;
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void cmbsReplicationMode_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemPopulate:
                    this.cmbsReplicationMode_OnPM_DataItemPopulate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.cmbsReplicationMode_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemPopulate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cmbsReplicationMode_OnPM_DataItemPopulate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemPopulate, Sys.wParam, Sys.lParam);
            if (this.cmbsReplicationMode.i_sMyValue == this.lsManualMode)
            {
                Sal.DisableWindowAndLabel(this.dfsTableName);
                Sal.DisableWindowAndLabel(this.cbsEnabled);
                Sal.DisableWindowAndLabel(this.dfsTriggerWhen);
                Sal.DisableWindowAndLabel(this.cbOnInsert);
                Sal.DisableWindowAndLabel(this.cbOnUpdate);
                Sal.DisableWindowAndLabel(this.dfsFromValue);
            }
            else
            {
                Sal.EnableWindowAndLabel(this.dfsTableName);
                Sal.EnableWindowAndLabel(this.dfsTriggerWhen);
                Sal.EnableWindowAndLabel(this.cbsEnabled);
                Sal.EnableWindowAndLabel(this.cbOnInsert);
                Sal.EnableWindowAndLabel(this.cbOnUpdate);
                Sal.EnableWindowAndLabel(this.dfsFromValue);
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cmbsReplicationMode_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.cmbsReplicationMode.i_sMyValue == this.lsManualMode)
            {
                Sal.DisableWindowAndLabel(this.dfsTableName);
                Sal.DisableWindowAndLabel(this.cbsEnabled);
                Sal.DisableWindowAndLabel(this.dfsTriggerWhen);
                Sal.DisableWindowAndLabel(this.cbOnInsert);
                Sal.DisableWindowAndLabel(this.cbOnUpdate);
                Sal.DisableWindowAndLabel(this.dfsFromValue);
            }
            else
            {
                Sal.EnableWindowAndLabel(this.dfsTableName);
                Sal.EnableWindowAndLabel(this.dfsTriggerWhen);
                Sal.EnableWindowAndLabel(this.cbsEnabled);
                Sal.EnableWindowAndLabel(this.cbOnInsert);
                Sal.EnableWindowAndLabel(this.cbOnUpdate);
                Sal.EnableWindowAndLabel(this.dfsFromValue);
                // If SalIsNullSalIsNull( dfsTriggerWhen )
            }
            e.Return = Sys.VALIDATE_Ok;
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void cmbsReplCriteria_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.cmbsReplCriteria_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cmbsReplCriteria_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.GetTriggerWhen();
            e.Return = Sys.VALIDATE_Ok;
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void dfsFromValue_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.dfsFromValue_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsFromValue_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.GetTriggerWhen();
            e.Return = Sys.VALIDATE_Ok;
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void dfsIntfacePath_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemPopulate:
                    this.dfsIntfacePath_OnPM_DataItemPopulate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.dfsIntfacePath_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemPopulate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsIntfacePath_OnPM_DataItemPopulate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemPopulate, Sys.wParam, Sys.lParam);
            this.SetGlobalPath();
            e.Return = true;
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsIntfacePath_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.SetGlobalPath();
            e.Return = Sys.VALIDATE_Ok;
            return;
            #endregion
        }
        #endregion

        #region Late Bind Methods

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalBoolean vrtDataSourcePopulateIt(SalNumber nParam)
        {
            return this.DataSourcePopulateIt(nParam);
        }

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalNumber vrtDataSourcePrepareKeyTransfer(SalString sWindowName)
        {
            return this.DataSourcePrepareKeyTransfer(sWindowName);
        }

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalBoolean vrtFrameStartupUser()
        {
            return this.FrameStartupUser();
        }

        public override SalNumber vrtDataRecordFetchEditedUser(ref SalString lsAttr)
        {
            return this.DataRecordFetchEditedUser(ref lsAttr);
        }

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalNumber vrtUserMethod(SalNumber nWhat, SalString sMethod)
        {
            return this.UserMethod(nWhat, sMethod);
        }

        /// <summary>
        /// PM_DataRecordNew event handler.
        /// </summary>
        /// <param name="message"></param>
        public void frmIntfaceHeader_OnPM_DataRecordNew(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.nMessage = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew, Sys.wParam, Sys.lParam);
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire)
            {
                if (!ChangeAllowed())
                {
                    e.Return = false;
                    return;
                }
                else
                {
                    e.Return = this.nMessage;
                    return;
                }
            }
            if (((bool)this.nMessage) && Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                e.Return = this.nMessage;
                return;
            }
            #endregion
        }
        
        #endregion

        #region Event Handlers

        private void menuItem_Query_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            // TODO: Rewrite command event handler not to use UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            ((FndCommand)sender).Enabled = Sal.SendMsg(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, ((SalString)"QuerySourceCols").ToHandle());
        }

        private void menuItem_Query_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            // TODO: Rewrite command event handler not to make use of UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            Sal.PostMsg(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, ((SalString)"QuerySourceCols").ToHandle());
        }

        private void menuItem_Copy_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            // TODO: Rewrite command event handler not to use UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            ((FndCommand)sender).Enabled = Sal.SendMsg(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, ((SalString)"CopyIntface").ToHandle());
        }

        private void menuItem_Copy_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            // TODO: Rewrite command event handler not to make use of UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            Ifs.Fnd.ApplicationForms.Int.PostMessage(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, "CopyIntface");
        }

        private void menuItem_Show_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            // TODO: Rewrite command event handler not to use UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            ((FndCommand)sender).Enabled = Sal.SendMsg(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, ((SalString)"ShowSqlStmt").ToHandle());
        }

        private void menuItem_Show_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            // TODO: Rewrite command event handler not to make use of UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            Sal.PostMsg(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, ((SalString)"ShowSqlStmt").ToHandle());
        }

        private void menuItem_Server_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            // TODO: Rewrite command event handler not to use UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            ((FndCommand)sender).Enabled = Sal.SendMsg(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, ((SalString)"ShowProcesses").ToHandle());
        }

        private void menuItem_Server_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            // TODO: Rewrite command event handler not to make use of UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            Sal.PostMsg(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, ((SalString)"ShowProcesses").ToHandle());
        }

        private void menuItem_Schedule_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            // TODO: Rewrite command event handler not to use UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            ((FndCommand)sender).Enabled = Sal.SendMsg(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, ((SalString)"ScheduleJob").ToHandle());
        }

        private void menuItem_Schedule_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            // TODO: Rewrite command event handler not to make use of UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            Sal.PostMsg(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, ((SalString)"ScheduleJob").ToHandle());
        }

        private void menuFrmMethods_menuTranslation_Execute(object sender, FndCommandExecuteEventArgs e)
        {
            #region Local Variables
            SalArray<SalString> sModule = new SalArray<SalString>();
            SalArray<SalString> sLu = new SalArray<SalString>();
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                sModule[0] = "FNDMIG";
                sLu[0] = "IntfaceHeader";
                Ifs.Fnd.ApplicationForms.Var.DataTransfer.SourceNameSet(Pal.GetActiveInstanceName("frmIntfaceHeader"));
                Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemAdd("MODULE", sModule);
                Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemAdd("LU", sLu);
                SessionNavigate(Pal.GetActiveInstanceName("frmBasicDataTranslation"));
            }
            #endregion
        }

        private void menuFrmMethods_menuTranslation_Inquire(object sender, FndCommandInquireEventArgs e)
        {
            #region Action
            if (dfsProcedureName.Text == "EXCEL_MIGRATION")
            {
                ((FndCommand)sender).Enabled = true;
            }
            else
            {
                ((FndCommand)sender).Enabled = false;
            }
            #endregion
        }

        private void menuFrmMethods_menuExecJob_Execute(object sender, FndCommandExecuteEventArgs e)
        {
            #region Local Variables
            SalArray<SalString> sIntfaceName = new SalArray<SalString>();
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                Sal.WaitCursor(true);
                sIntfaceName[0] = ecmbIntfaceName.Text;
                Ifs.Fnd.ApplicationForms.Var.DataTransfer.SourceNameSet(Pal.GetActiveInstanceName("frmIntfaceHeader"));
                Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemAdd("INTFACE_NAME", sIntfaceName);
                SessionNavigate(Pal.GetActiveInstanceName("frmIntfaceStart"));
                Sal.WaitCursor(false);
            }
            #endregion
        }

        private void menuFrmMethods_menuExecJob_Inquire(object sender, FndCommandInquireEventArgs e)
        {
            #region Action
            if (string.IsNullOrEmpty(ecmbIntfaceName.Text) || dfsProcedureName.Text.Equals("EXCEL_MIGRATION"))
            {
                ((FndCommand)sender).Enabled = false;
            }
            else
            {
                ((FndCommand)sender).Enabled = true;
            }
            #endregion
        }

        private void menuFrmMethods_menuHistory_Execute(object sender, FndCommandExecuteEventArgs e)
        {
            #region Local Variables
            SalArray<SalString> sIntfaceName = new SalArray<SalString>();
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                Sal.WaitCursor(true);
                sIntfaceName[0] = ecmbIntfaceName.Text;
                Ifs.Fnd.ApplicationForms.Var.DataTransfer.SourceNameSet(Pal.GetActiveInstanceName("frmIntfaceHeader"));
                Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemAdd("INTFACE_NAME", sIntfaceName);
                SessionNavigate(Pal.GetActiveInstanceName("frmIntfaceJobHistHead"));
                Sal.WaitCursor(false);
            }
            #endregion
        }

        private void menuFrmMethods_menuHistory_Inquire(object sender, FndCommandInquireEventArgs e)
        {
            #region Action
            if (string.IsNullOrEmpty(ecmbIntfaceName.Text) || dfsProcedureName.Text.Equals("EXCEL_MIGRATION") || !HasHistoryDetail())
            {
                ((FndCommand)sender).Enabled = false;
            }
            else
            {
                ((FndCommand)sender).Enabled = true;
            }
            #endregion
        }
        #endregion
    }
}
