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
using Ifs.Fnd.ApplicationForms;
using Ifs.Fnd.Windows.Forms;
using PPJ.Runtime;
using PPJ.Runtime.Sql;
using PPJ.Runtime.Windows;
using PPJ.Runtime.Vis;

namespace Ifs.Application.Accrul
{
	
	/// <summary>
	/// </summary>
    [FndWindowRegistration("ACCOUNTING_CODE_PART_VALUE", "AccountingCodePartValue")]
    public partial class frmCdCompl : cFormWindowFin
    {
        #region Window Variables
        public SalNumber nRetVal = 0;
        public SalString IIDYes = "";
        public SalString sTemp = "";
        public SalString sTemp2 = "";
        public SalString sTemp4 = "";
        public SalString sTemp5 = "";
        public SalString sTemp3 = "";
        public SalString lsTemp = "";
        public SalArray<SalString> sPlaceHolders = new SalArray<SalString>();
        public SalArray<SalString> sChanges = new SalArray<SalString>();
        public SalNumber nNumChanges = 0;
        public SalWindowHandle hWndSource = SalWindowHandle.Null;
        public SalString sAcc = "";
        public SalBoolean bSaved = false;
        public SalBoolean bFirst1 = false;
        public SalBoolean bFirst2 = false;
        public SalNumber nCount = 0;
        public SalSqlHandle h_GUSql = SalSqlHandle.Null;
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public frmCdCompl()
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
        public new static frmCdCompl FromHandle(SalWindowHandle handle)
        {
            return ((frmCdCompl)SalWindow.FromHandle(handle, typeof(frmCdCompl)));
        }
        #endregion

        #region Methods

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public new SalBoolean FrameStartupUser()
        {
            #region Actions
            using (new SalContext(this))
            {
                hWndSource = Ifs.Fnd.ApplicationForms.Var.DataTransfer.i_hWndSource;
                // Insert new code here...
                return true;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public new SalBoolean SetWindowTitle()
        {
            #region Actions
            using (new SalContext(this))
            {
                Sal.SetWindowText(i_hWndSelf, i_sCompany + " - " + Properties.Resources.WH_frmCdCompl);
                return true;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber PopulateNew()
        {
            #region Actions
            using (new SalContext(this))
            {
                DbConnect(ref h_GUSql);
                bSaved = false;
                sTemp = string.Format(@"SELECT  CODE_PART , CODE_NAME
                                          INTO {0}, {1}
                                          FROM &AO.ACCOUNTING_CODE_PARTS
                                         WHERE COMPANY = {2}
                                           AND CODE_PART_USED = {3}
                                         UNION 
                                        SELECT 'P', &AO.Accounting_Codestr_Compl_API.Get_Translated_Code_Fill_Name({2}, 'ACCRUL', 'AccountingCodeParts', 'P') FROM DUAL
                                      ORDER BY 1 ASC ",
                                         this.tblCdCompl_colsCdPartFill.QualifiedBindName,
                                         this.QualifiedVarBindName("tblCdCompl_colsCdPartFillNameStr"),
                                         this.QualifiedVarBindName("i_sCompany"),
                                         this.QualifiedVarBindName("IIDYes"));
                
                DbTblPopulate(tblCdCompl, h_GUSql, sTemp, Sys.TBL_FillAll);
                DbDisconnect(h_GUSql);
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean ValidateFillValue()
        {
            #region Actions
            using (new SalContext(this))
            {
                Sal.WaitCursor(true);
                sTemp = tblCdCompl_colsCompany.Text;
                sTemp2 = this.tblCdCompl_colsCdPartFill.Text;
                sTemp3 = tblCdCompl_colsFillValue.Text;
                if (sTemp2 == "A")
                {
                    using (SignatureHints hints = SignatureHints.NewContext())
                    {
                        hints.Add("ACCOUNT_API.Exist", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                        if (!(DbPLSQLBlock(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "ACCOUNT_API.Exist (\r\n" +
                            ":i_hWndFrame.frmCdCompl.sTemp ,\r\n" +
                            ":i_hWndFrame.frmCdCompl.sTemp3  ) ")))
                        {
                            Sal.WaitCursor(false);
                            return false;
                        }
                    }
                }
                else
                {
                    using (SignatureHints hints = SignatureHints.NewContext())
                    {
                        hints.Add("Accounting_Code_Part_Value_API.Exist", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                        if (!(DbPLSQLBlock(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "Accounting_Code_Part_Value_API.Exist (\r\n" +
                            ":i_hWndFrame.frmCdCompl.sTemp ,\r\n" +
                            ":i_hWndFrame.frmCdCompl.sTemp2 ,\r\n" +
                            ":i_hWndFrame.frmCdCompl.sTemp3  ) ")))
                        {
                            Sal.WaitCursor(false);
                            return false;
                        }
                    }
                }
                Sal.WaitCursor(false);
                return true;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber GetFillValueDesc()
        {
            #region Actions
            using (new SalContext(this))
            {
                Sal.WaitCursor(true);
                sTemp = tblCdCompl_colsCompany.Text;
                sTemp2 = this.tblCdCompl_colsCdPartFill.Text;
                sTemp3 = tblCdCompl_colsFillValue.Text;
                if (sTemp2 == "P")
                {
                    using (SignatureHints hints = SignatureHints.NewContext())
                    {
                        hints.Add("ACCOUNT_PROCESS_CODE_API.GET_DESCRIPTION", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                        DbPLSQLBlock(cSessionManager.c_hSql, " BEGIN\r\n" +
                            "	   :i_hWndFrame.frmCdCompl.lsTemp   :=  \r\n" +
                            "	   &AO. ACCOUNT_PROCESS_CODE_API.GET_DESCRIPTION(\r\n" +
                            "      	   :i_hWndFrame.frmCdCompl.i_sCompany, \r\n" +
                            "	   :i_hWndFrame.frmCdCompl.sTemp3);  \r\n	 END; ");
                    }
                }
                else
                {
                    using (SignatureHints hints = SignatureHints.NewContext())
                    {
                        hints.Add("ACCOUNTING_CODE_PART_VALUE_API.Get_Desc_For_Code_Part", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                        DbPLSQLBlock(cSessionManager.c_hSql, " BEGIN\r\n" +
                            "	  :i_hWndFrame.frmCdCompl.lsTemp   :=  \r\n" +
                            "	   &AO.ACCOUNTING_CODE_PART_VALUE_API.Get_Desc_For_Code_Part(\r\n" +
                            "       	 :i_hWndFrame.frmCdCompl.sTemp,   \r\n" +
                            "       	 :i_hWndFrame.frmCdCompl.sTemp2,\r\n" +
                            "       	 :i_hWndFrame.frmCdCompl.sTemp3); \r\n	 END; ");
                    }
                }
                tblCdCompl_colsFillValueDesc.Text = lsTemp;
                Sal.WaitCursor(false);
                return true;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber GetIIDYes()
        {
            #region Actions
            using (new SalContext(this))
            {
                Sal.WaitCursor(true);
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("ACCOUNTING_CODE_PART_Y_N_API.decode", System.Data.ParameterDirection.Input);
                    DbPLSQLBlock(cSessionManager.c_hSql, " BEGIN\r\n" +
                        "	  :i_hWndFrame.frmCdCompl.lsTemp          :=  \r\n" +
                        "	   &AO.ACCOUNTING_CODE_PART_Y_N_API.decode( 'Y' );\r\n	 END; ");
                }
                IIDYes = lsTemp;
                Sal.WaitCursor(false);
                return true;
            }
            #endregion
        }
        // menu functions
        /// <summary>
        /// </summary>
        /// <param name="p_nWhat"></param>
        /// <returns></returns>
        public virtual new SalNumber ChangeCompany(SalNumber p_nWhat)
        {
            #region Actions
            using (new SalContext(this))
            {
                if (p_nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
                {
                    return Sal.SendClassMessage(Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Sys.lParam);
                }
                else
                {
                    return Sal.SendClassMessage(Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Sys.lParam);
                }
            }
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
        /// <param name="nWhat">
        /// Standard method parameter
        /// Standard method parameter. Possible values are METHOD_Inquire, METHOD_Execute.
        /// </param>
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
            #region Actions
            using (new SalContext(this))
            {
                if (Ifs.Fnd.ApplicationForms.Int.QualifiedItemNameGet(hWndSource) == Pal.GetActiveInstanceName("frmTabProjAcc"))
                {
                    Sal.SendMsg(hWndSource, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceRefresh, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                }
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
        private void frmCdCompl_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_Create:
                    this.frmCdCompl_OnSAM_Create(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceQueryFieldName:
                    this.frmCdCompl_OnPM_DataSourceQueryFieldName(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave:
                    this.frmCdCompl_OnPM_DataSourceSave(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordCopy:
                    e.Handled = true;
                    e.Return = this.tblCdCompl_OnPM_DataRecordCopy(Sys.wParam, Sys.lParam);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordPaste:
                    e.Handled = true;
                    e.Return = this.tblCdCompl_OnPM_DataRecordPaste(Sys.wParam, Sys.lParam);
                    break;

            }
            #endregion
        }

        /// <summary>
        /// SAM_Create event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmCdCompl_OnSAM_Create(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SetWindowText(this, Properties.Resources.WH_frmCdCompl);
            this.nCount = 0;
            e.Return = Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataSourceQueryFieldName event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmCdCompl_OnPM_DataSourceQueryFieldName(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if ((SalString.FromHandle(Sys.lParam) == "COMPANY") && (Sys.wParam != Vis.DT_Handle))
            {
                e.Return = (this.i_hWndFrame.ToNumber().ToString(0) + ".frmCdCompl.i_sCompany").ToHandle();
                return;
            }
            else
            {
                e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceQueryFieldName, Sys.wParam, Sys.lParam);
                return;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataSourceSave event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmCdCompl_OnPM_DataSourceSave(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Sys.wParam, Sys.lParam))
                {
                    Sal.SetFocus(this.cmbsCdPartValue);
                    this.bSaved = true;
                    if (this.nCount == -2)
                    {
                        this.nCount = 0;
                    }
                    e.Return = true;
                    return;
                }
                this.bSaved = false;
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
        private void cmbsCdPartValue_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemPopulate:
                    this.cmbsCdPartValue_OnPM_DataItemPopulate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemPopulate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cmbsCdPartValue_OnPM_DataItemPopulate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.bFirst1 = false;
            this.bFirst2 = false;
            this.bSaved = true;
            this.nCount = 0;
            Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemPopulate, Sys.wParam, Sys.lParam);
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblCdCompl_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_FetchRowDone:
                    this.tblCdCompl_OnSAM_FetchRowDone(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordDuplicate:
                    e.Handled = true;
                    // Duplicate button always should be disabled.
                    e.Return = false;
                    return;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew:
                    this.tblCdCompl_OnPM_DataRecordNew(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_FetchRowDone event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblCdCompl_OnSAM_FetchRowDone(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.nRetVal = Sal.SendClassMessage(Sys.SAM_FetchRowDone, Sys.wParam, Sys.lParam);
            this.RowFetched();
            this.nCount = 1;
            e.Return = this.nRetVal;
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataRecordNew event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblCdCompl_OnPM_DataRecordNew(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.nCount == 0 || this.nCount == -1)
            {
                e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew, Sys.wParam, Sys.lParam);
                return;
            }
            e.Return = false;
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataRecordCopy event handler.
        /// </summary>
        /// <param name="message"></param>
        protected virtual SalNumber tblCdCompl_OnPM_DataRecordCopy(SalNumber nWhat, SalNumber lParam)
        {
            #region Local Variables
            cMessage MsgInner = new cMessage();
            cMessage MsgMain = new cMessage();
            cMessage MsgRecords = new cMessage();
            SalNumber nCurrentRow = 0;
            SalNumber nRowNumber = 0;
            SalString lsClipboard = "";
            SalString lsRecords = "";
            SalBoolean bValuesExist = false;
            #endregion

            #region Actions

            if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordCopy, nWhat, lParam))
                {
                    // Copy the existing clipboard contents with correct IFS message format (we will add records to this)
                    Sal.EditPasteString(ref lsClipboard);
                    MsgMain.Unpack(lsClipboard);

                    // Collect all selected records with a value
                    MsgRecords.Construct();
                    nRowNumber = 0;
                    nCurrentRow = Sys.TBL_MinRow;
                    while (Sal.TblFindNextRow(tblCdCompl, ref nCurrentRow, Sys.ROW_Selected, 0))
                    {
                        Sal.TblSetContext(tblCdCompl, nCurrentRow);
                        if (!(Sal.IsNull(tblCdCompl_colsFillValue)))
                        {
                            MsgInner.Construct();
                            MsgInner.AddAttribute("CODE_PART_FILL", this.tblCdCompl_colsCdPartFill.Text);
                            MsgInner.AddAttribute("FILL_VALUE", tblCdCompl_colsFillValue.Text);
                            MsgRecords.AddAttribute((65 + nRowNumber).ToCharacter(), MsgInner.Pack());
                            nRowNumber = nRowNumber + 1;
                        }
                    }
                    lsRecords = MsgRecords.Pack();

                    MsgMain.AddAttribute("COPIED_RECORDS", lsRecords);
                    lsClipboard = MsgMain.Pack();
                    Sal.EditCopyString(lsClipboard);
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            else if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire)
            {
                // Proceed if there is any value to be copied
                bValuesExist = false;
                nCurrentRow = Sys.TBL_MinRow;
                while (Sal.TblFindNextRow(tblCdCompl, ref nCurrentRow, Sys.ROW_Selected, 0))
                {
                    Sal.TblSetContext(tblCdCompl, nCurrentRow);
                    if (!(Sal.IsNull(tblCdCompl_colsFillValue)))
                    {
                        bValuesExist = true;
                        break;
                    }
                }
                if (bValuesExist)
                {
                    // Proceed to copy
                    return (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordCopy, nWhat, lParam));
                }
                else
                { return 0; }
            }
            else
            { return 0; }
            #endregion
        }

        protected virtual SalNumber tblCdCompl_OnPM_DataRecordPaste(SalNumber nWhat, SalNumber lParam)
        {
            #region Local Variables
            cMessage Msg = new cMessage();
            cMessage MsgMain = new cMessage();
            cMessage MsgRecords = new cMessage();
            SalString lsClipboard = "";
            SalString lsRecords = "";
            SalString sCodePartFill = "";
            SalString sFillValue = "";
            SalNumber nCurrentRow = 0;
            SalArray<SalString> sRecordNames = new SalArray<SalString>();
            SalArray<SalString> sRecordValues = new SalArray<SalString>();
            SalNumber nRows = 0;
            SalNumber nIndex = 0;
            #endregion
            #region Actions

            if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                Sal.EditPasteString(ref lsClipboard);
                if (MsgMain.Unpack(lsClipboard))
                {
                    lsRecords = MsgMain.FindAttribute("COPIED_RECORDS", Ifs.Fnd.ApplicationForms.Const.strNULL);
                    if (lsRecords != Ifs.Fnd.ApplicationForms.Const.strNULL)
                    {
                        // Do a new if its allowed.
                        if (Sal.SendMsg(tblCdCompl, Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0))
                        {
                            Sal.SendMsg(tblCdCompl, Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                        }
                        // Get the records and set values
                        if (MsgRecords.Unpack(lsRecords))
                        {

                            nRows = MsgRecords.EnumAttributes(sRecordNames, sRecordValues);
                            nIndex = 0;
                            while (nIndex < nRows)
                            {
                                if (Msg.Unpack(sRecordValues[nIndex]))
                                {
                                    sCodePartFill = Msg.FindAttribute("CODE_PART_FILL", "");
                                    sFillValue = Msg.FindAttribute("FILL_VALUE", "");
                                    // Call Console.Add( 'Values retrieved  sCodePartFill=' ||  sCodePartFill || ' sFillValue=' || sFillValue)
                                    nCurrentRow = Sys.TBL_MinRow;
                                    while (Sal.TblFindNextRow(tblCdCompl, ref nCurrentRow, 0, 0))
                                    {
                                        Sal.TblSetContext(tblCdCompl, nCurrentRow);
                                        if (this.tblCdCompl_colsCdPartFill.Text == sCodePartFill)
                                        {
                                            // Found correct line, now set the value if allowed.
                                            if (((bool)Sal.SendMsg(tblCdCompl_colsFillValue, Ifs.Fnd.ApplicationForms.Const.PM_EditStateFieldEnabled, 0, 0)) && (tblCdCompl_colsCdPart.Text != this.tblCdCompl_colsCdPartFill.Text) && AmIDemanded(this.tblCdCompl_colsCdPartFill.Text))
                                            {
                                                Sal.SendMsg(tblCdCompl_colsFillValue, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, sFillValue.ToHandle());
                                                Sal.TblSetRowFlags(tblCdCompl, nCurrentRow, Sys.ROW_Edited, true);
                                                // Invoke validations written on set focus
                                                Sal.SendMsg(tblCdCompl_colsFillValue, Sys.SAM_SetFocus, 0, 0);
                                                // Invoke validations
                                                if (Sal.SendMsg(tblCdCompl_colsFillValue, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0) == Sys.VALIDATE_Cancel)
                                                {
                                                    Sal.SendMsg(tblCdCompl_colsFillValue, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, ((SalString)Ifs.Fnd.ApplicationForms.Const.strNULL).ToHandle());
                                                }
                                            }
                                            break;
                                        }
                                    }
                                }
                                nIndex = nIndex + 1;
                            }
                        }
                    }
                }
                Sal.EditCopyString(lsClipboard);
                return 1;
            }
            else if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire)
            {
                // The functionality requires that the "Paste" option is required even when the "New" is not allowed
                // Therefore we need to skip the framework's default handling for inquire
                lsClipboard = Ifs.Fnd.ApplicationForms.Int._PalGetClipboardData();
                if (Msg.Unpack(lsClipboard))
                {
                    // Check the contents of the message
                    return Msg.GetName() == "IFS.COPYOBJECT" && Msg.FindAttribute("LU", "@") == tblCdCompl.p_sLogicalUnit && Msg.FindAttribute("VIEW", "@") == Ifs.Fnd.ApplicationForms.Var.Security._RemoveDbPrefix(tblCdCompl.p_sViewName);
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
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
        public override SalBoolean vrtSetWindowTitle()
        {
            return this.SetWindowTitle();
        }

        #endregion

        #region tblCdCompl

        #region Window Variables
        public SalBoolean bPopulate = false;
        public SalBoolean bInquireNew = false;
        public SalString sDemandBlock = "";
        public SalString sAccount = "";
        public SalArray<SalString> sItemNames = new SalArray<SalString>();
        public SalString sItemName1 = "";
        public SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
        #endregion

        #region Methods

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber tblCdCompl_DataRecordGetDefaults()
        {
            tblCdCompl_colsCompany.Text = this.i_sCompany;
            tblCdCompl_colsCompany.EditDataItemSetEdited();
            return 0;
        }

        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalNumber tblCdCompl_DataRecordNew(SalNumber nWhat)
        {
            #region Local Variables
            SalNumber nRow = 0;
            #endregion

            #region Actions
            switch (nWhat)
            {
                case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:

                    Sal.WaitCursor(true);
                    bPopulate = true;

                    if (this.IIDYes == Ifs.Fnd.ApplicationForms.Const.strNULL)
                    {
                        this.GetIIDYes();
                    }
                    if (!(CheckCodeParts()))
                    {
                        this.PopulateNew();
                    }
                    bPopulate = false;
                    // Notify others that we are dirty
                    if (tblCdCompl.i_nDataSourceState != Ifs.Fnd.ApplicationForms.Const.DATASOURCE_Changed)
                    {
                        tblCdCompl.i_nDataSourceState = Ifs.Fnd.ApplicationForms.Const.DATASOURCE_Changed;
                        tblCdCompl.SendMessageToParent(Ifs.Fnd.ApplicationForms.Const.AM_DataSourceDetailModified, 0, 1);
                        tblCdCompl.MethodStateChanged(Ifs.Fnd.ApplicationForms.Const.CHILDTYPE_SourceMethod);
                    }
                    tblCdCompl.MethodStateChanged(Ifs.Fnd.ApplicationForms.Const.CHILDTYPE_ContextMethod);
                    this.nCount =this.nCount + 1;
                    if (this.dfsCdPart.Text == "A")
                    {
                        GetCodePartDemand(false, Ifs.Fnd.ApplicationForms.Const.strNULL);
                        RefreshDemandTrap();
                    }
                    Sal.WaitCursor(false);
                    return 1;

                case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                    nRow = Sal.TblQueryContext(tblCdCompl);
                    return ((cTableManager)tblCdCompl).DataRecordNew(nWhat);
                    Sal.TblSetContext(tblCdCompl, nRow);
                    return bInquireNew;

                case Ifs.Fnd.ApplicationForms.Const.METHOD_GetType:
                    return Ifs.Fnd.ApplicationForms.Const.CHILDTYPE_SourceMethod;
            }
            

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber SetDataSourceReadOnlyChildTbl()
        {
            Ifs.Fnd.ApplicationForms.Var.Console.TextAdd(Ifs.Fnd.ApplicationForms.Const.CONS_Debug, "Set Data Source Child Table To Read Only");
            tblCdCompl.SourceFlagsSet(Ifs.Fnd.ApplicationForms.Const.SOURCE_Update, false);
            tblCdCompl.SourceFlagsSet(Ifs.Fnd.ApplicationForms.Const.SOURCE_OperationNew, false);
            tblCdCompl.SourceFlagsSet(Ifs.Fnd.ApplicationForms.Const.SOURCE_OperationModify, false);
            tblCdCompl.SourceFlagsSet(Ifs.Fnd.ApplicationForms.Const.SOURCE_OperationRemove, false);
            tblCdCompl.SendMessageToChildren(Ifs.Fnd.ApplicationForms.Const.CHILDTYPE_DataItem, Ifs.Fnd.ApplicationForms.Const.PM_DataItemFlagSet, Ifs.Fnd.ApplicationForms.Const.FIELD_Update, 0);
            return 0;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber RefreshDemandTrap()
        {
            #region Local Variables
            SalNumber nIndex = 0;
            SalNumber nRow = 0;
            #endregion

            #region Actions
            nRow = Sal.TblQueryContext(tblCdCompl);
            // Set stop indicator (so we don't process more rows than neccessary )
            Sal.TblSetRowFlags(tblCdCompl, tblCdCompl.DataSourceRecordsInMemoryCount(), Sys.ROW_UnusedFlag2, true);
            // Process all EDITED records in the table window
            nIndex = Sys.TBL_MinRow;
            while (true)
            {
                // Find row that is either edited or stop indicator
                if (Sal.TblFindNextRow(tblCdCompl, ref nIndex, 0, 0))
                {
                    // Save row if edited and not deleted
                    Sal.TblSetContext(tblCdCompl, nIndex);
                    if (this.tblCdCompl_colsCdPartFill.Text != "A")
                    {
                        if (!(AmIDemanded(this.tblCdCompl_colsCdPartFill.Text)) && !(Sal.IsNull(tblCdCompl_colsFillValue)))
                        {
                            Sal.ClearField(tblCdCompl_colsFillValue);
                            Sal.ClearField(tblCdCompl_colsFillValueDesc);
                            if (this.bSaved == false)
                            {
                                Sal.SetFieldEdit(this.tblCdCompl_colsCdPartFill, true);
                            }
                            else
                            {
                                Sal.SetFieldEdit(this.tblCdCompl_colsCdPartFill, false);
                            }
                            Sal.SetFieldEdit(tblCdCompl_colsFillValue, true);
                        }
                        if (!(AmIDemanded(this.tblCdCompl_colsCdPartFill.Text)))
                        {
                            tblCdCompl_colsCdPartBlocked.Text = "S";
                        }
                        else
                        {
                            tblCdCompl_colsCdPartBlocked.Text = "O";
                        }
                    }
                }
                else
                {
                    break;
                }
                // Abort if we have reached beyond the maximum row in memory
                if (Sal.TblQueryRowFlags(tblCdCompl, nIndex, Sys.ROW_UnusedFlag2))
                {
                    break;
                }
            }
            Sal.TblSetContext(tblCdCompl, nRow);
            return true;
            
            #endregion
        }

        /// <summary>
        /// Removes all selected records
        /// </summary>
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalNumber tblCdCompl_DataRecordRemove(SalNumber nWhat)
        {
            #region Local Variables
            SalNumber nRow = 0;
            SalBoolean bMarked = false;
            SalNumber nNewDataSourceState = 0;
            SalNumber nContext = 0;
            SalBoolean bDatabase = false;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        Sal.WaitCursor(true);
                        nContext = Sal.TblQueryContext(tblCdCompl);
                        // Process REMOVE for  all records
                        nRow = Sys.TBL_MinRow;
                        while (true)
                        {
                            if (Sal.TblFindNextRow(tblCdCompl, ref nRow, 0, Sys.ROW_HideMarks))
                            {
                                // Physically remove records that are NEW and not origin from database
                                if (Sal.TblQueryRowFlags(tblCdCompl, nRow, Sys.ROW_New))
                                {
                                    Sal.TblDeleteRow(tblCdCompl, nRow, Sys.TBL_Adjust);
                                    nRow = nRow - 1;
                                    bDatabase = false;
                                }
                                // Toggle REMOVE marker for database records
                                else
                                {
                                    Sal.TblSetContext(tblCdCompl, nRow);
                                    bMarked = Sal.TblQueryRowFlags(tblCdCompl, nRow, Sys.ROW_MarkDeleted);
                                    if (bMarked)
                                    {
                                        Sal.TblSetRowFlags(tblCdCompl, nRow, Sys.ROW_MarkDeleted, false);
                                    }
                                    else
                                    {
                                        Sal.TblSetRowFlags(tblCdCompl, nRow, Sys.ROW_MarkDeleted, true);
                                    }
                                    bDatabase = true;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                        // Modify state accordingly
                        if (bDatabase == true)
                        {
                            nNewDataSourceState = Ifs.Fnd.ApplicationForms.Const.DATASOURCE_Changed;
                           this.nCount = -2;
                        }
                        else
                        {
                           this.nCount = -1;
                        }
                        if (tblCdCompl.i_nDataSourceState != nNewDataSourceState)
                        {
                            tblCdCompl.i_nDataSourceState = nNewDataSourceState;
                            tblCdCompl.SendMessageToParent(Ifs.Fnd.ApplicationForms.Const.AM_DataSourceDetailModified, 0, (tblCdCompl.i_nDataSourceState == Ifs.Fnd.ApplicationForms.Const.DATASOURCE_Changed));
                            tblCdCompl.MethodStateChanged(Ifs.Fnd.ApplicationForms.Const.CHILDTYPE_SourceMethod);
                        }
                        tblCdCompl.MethodStateChanged(Ifs.Fnd.ApplicationForms.Const.CHILDTYPE_ContextMethod);
                        Sal.WaitCursor(false);
                        return 1;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        return ((bool)(tblCdCompl.p_nSourceFlags & Ifs.Fnd.ApplicationForms.Const.SOURCE_Update)) && ((bool)(tblCdCompl.p_nSourceFlags & Ifs.Fnd.ApplicationForms.Const.SOURCE_OperationRemove)) && (tblCdCompl.i_nDataSourceState != Ifs.Fnd.ApplicationForms.Const.DATASOURCE_Empty);

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_GetType:
                        return Ifs.Fnd.ApplicationForms.Const.CHILDTYPE_SourceMethod;
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// always put on the sDemandBlock  of the  table
        /// </summary>
        /// <param name="bPCheck"></param>
        /// <param name="sAccCodeString"></param>
        /// <returns></returns>
        public virtual SalNumber GetCodePartDemand(SalBoolean bPCheck, SalString sAccCodeString)
        {
            #region Actions

            // check wheter already exist code demand in sDemandBlock
            if (sAccCodeString == Ifs.Fnd.ApplicationForms.Const.strNULL)
            {
                if (bPCheck)
                {
                    if (sDemandBlock != Ifs.Fnd.ApplicationForms.Const.strNULL)
                    {
                        return true;
                    }
                    sAccount = SalString.FromHandle(this.cmbsCdPartValue.EditDataItemValueGet());
                    if (sAccount == Ifs.Fnd.ApplicationForms.Const.strNULL)
                    {
                        return true;
                    }
                }
                this.sTemp5 = SalString.FromHandle(this.cmbsCdPartValue.EditDataItemValueGet());
                Sal.WaitCursor(true);
                if (DbPLSQLBlock(@"&AO.Accounting_Code_Part_A_API.Get_Required_Code_Part({0} OUT, {1} IN, {2} IN )",
                    this.QualifiedVarBindName("sTemp4"),
                    this.QualifiedVarBindName("i_sCompany"),
                    this.QualifiedVarBindName("sTemp5")))
                {
                    sDemandBlock =this.sTemp4;
                    Sal.WaitCursor(false);
                    return true;
                }
                    
            }
            else
            {      
                if (DbPLSQLBlock( @"&AO.Accounting_Code_Part_A_API.Get_Required_Code_Part({0} OUT , {1} IN ,'" + sAccCodeString + "')",
                    this.QualifiedVarBindName("sTemp4"),
                    this.QualifiedVarBindName("i_sCompany")))
                {
                    sDemandBlock =this.sTemp4;
                    Sal.WaitCursor(false);
                    return true;
                }       
            }
            Sal.WaitCursor(false);
            return true;
          
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="sCode"></param>
        /// <returns></returns>
        public virtual SalBoolean AmIDemanded(SalString sCode)
        {
            // not 'S'
            if (((SalString)"ABCDEFGHIJ").Scan(sCode) != -1)
            {
                return sDemandBlock.Mid(sDemandBlock.Scan("CODE_" + sCode) + 7, 1) != "S";
            }
            return sDemandBlock.Mid(sDemandBlock.Scan("PROCESS_CODE") + 13, 1) != "S";
        }
        // message-answer functions
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber RowFetched()
        {
            if (bPopulate)
            {
                Sal.WaitCursor(true);
                tblCdCompl_colsCompany.Text = this.i_sCompany;
                tblCdCompl_colsCompany.EditDataItemSetEdited();
                tblCdCompl_colsCdPart.Text = this.dfsCdPart.Text;
                tblCdCompl_colsCdPart.EditDataItemSetEdited();
                tblCdCompl_colsCdPartValue.Text = SalString.FromHandle(this.cmbsCdPartValue.EditDataItemValueGet());
                tblCdCompl_colsCdPartValue.EditDataItemSetEdited();
                this.tblCdCompl_colsCdPartFillName.Text = this.tblCdCompl_colsCdPartFillNameStr.Text;
                this.tblCdCompl_colsCdPartFill.EditDataItemSetEdited();
                Sal.TblSetRowFlags(tblCdCompl, Sys.lParam, Sys.ROW_New, true);
                Sal.WaitCursor(false);
            }
            return 0;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean CheckCodeParts()
        {
            SalNumber nIndex = Sys.TBL_MinRow;
            Boolean bExist = false;
            while (Sal.TblFindNextRow(tblCdCompl, ref nIndex, 0, 0))
            {
                Sal.TblSetContext(tblCdCompl, nIndex);
                if (!(Sal.IsNull(tblCdCompl_colsFillValue)))
                {
                    bExist = true;
                }
            }
            return bExist;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber GetAccountNumber()
        {
            #region Local Variables
            SalNumber nIndex = 0;
            SalNumber nRow = 0;
            #endregion

            #region Actions

            nRow = Sal.TblQueryContext(tblCdCompl);
            // Set stop indicator (so we don't process more rows than neccessary )
            Sal.TblSetRowFlags(tblCdCompl, tblCdCompl.DataSourceRecordsInMemoryCount(), Sys.ROW_UnusedFlag2, true);
            // Process all EDITED records in the table window
            nIndex = Sys.TBL_MinRow;
            while (true)
            {
                // Find row that is either edited or stop indicator
                if (Sal.TblFindNextRow(tblCdCompl, ref nIndex, 0, 0))
                {
                    // Save row if edited and not deleted
                    Sal.TblSetContext(tblCdCompl, nIndex);
                    if ((this.tblCdCompl_colsCdPartFill.Text == "A") && (this.dfsCdPart.Text != "A"))
                    {
                        this.sAcc = tblCdCompl_colsFillValue.Text;
                        break;
                    }
                }
                else
                {
                    break;
                }
                // Abort if we have reached beyond the maximum row in memory
                if (Sal.TblQueryRowFlags(tblCdCompl, nIndex, Sys.ROW_UnusedFlag2))
                {
                    break;
                }
            }
            Sal.TblSetContext(tblCdCompl, nRow);
            return true;
          
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="hItem"></param>
        /// <returns></returns>
        public virtual SalString GetItemName(SalWindowHandle hItem)
        {
            SalString sItem = "";
            Sal.GetItemName(hItem, ref sItem);
            return sItem;
        }
       
        #endregion

        #region Window Actions

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblCdCompl_colsFillValue_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblCdCompl_colsFillValue_OnPM_DataItemValidate(sender, e);
                    break;

                case Sys.SAM_SetFocus:
                    this.tblCdCompl_colsFillValue_OnSAM_SetFocus(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.WM_CHAR:
                    this.tblCdCompl_colsFillValue_OnWM_CHAR(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.WM_PASTE:
                    this.tblCdCompl_colsFillValue_OnWM_PASTE(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom:
                    this.tblCdCompl_colsFillValue_OnPM_DataItemZoom(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblCdCompl_colsFillValue_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam))
            {
                if (Sal.IsNull(this.tblCdCompl_colsFillValue.i_hWndSelf))
                {
                    this.tblCdCompl_colsFillValueDesc.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                    e.Return = Sys.VALIDATE_Ok;
                    return;
                    if (this.tblCdCompl_colsCdPartFill.Text == "A")
                    {
                       this.sAcc = this.tblCdCompl_colsFillValue.Text;
                    }
                }
                if (!(this.ValidateFillValue()))
                {
                    e.Return = Sys.VALIDATE_Cancel;
                    return;
                }
                else
                {
                   this.GetFillValueDesc();
                   if (this.tblCdCompl_colsCdPartFill.Text == "A")
                    {
                       this.sAcc = this.tblCdCompl_colsFillValue.Text;
                        this.GetCodePartDemand(false, this.tblCdCompl_colsFillValue.Text);
                        this.RefreshDemandTrap();
                    }
                    e.Return = Sys.VALIDATE_Ok;
                    return;
                }
            }
            else
            {
                e.Return = Sys.VALIDATE_Cancel;
                return;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblCdCompl_colsFillValue_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if ((this.dfsCdPart.Text == "A") && (this.bFirst1 == false))
            {
                this.GetCodePartDemand(false, Ifs.Fnd.ApplicationForms.Const.strNULL);
                this.RefreshDemandTrap();
                this.bFirst1 = true;
            }
            else if ((this.dfsCdPart.Text != "A") && (this.bFirst2 == false))
            {
                this.GetAccountNumber();
                if (this.sAcc != Ifs.Fnd.ApplicationForms.Const.strNULL)
                {
                    this.GetCodePartDemand(false,this.sAcc);
                    this.RefreshDemandTrap();
                }
               this.bFirst2 = true;
            }
            if (this.tblCdCompl_colsCdPartBlocked.Text == "S")
            {
                this.tblCdCompl_colsFillValue.p_sLovReference = Ifs.Fnd.ApplicationForms.Const.strNULL;
            }
            else if (this.tblCdCompl_colsCdPartFill.Text == this.dfsCdPart.Text)
            {
                this.tblCdCompl_colsFillValue.p_sLovReference = Ifs.Fnd.ApplicationForms.Const.strNULL;
            }
            else if (this.tblCdCompl_colsCdPartFill.Text == "P")
            {
                this.tblCdCompl_colsFillValue.p_sLovReference = "ACCOUNT_PROCESS_CODE(COMPANY)";
            }
            else
            {
                this.tblCdCompl_colsFillValue.p_sLovReference = "ACCOUNTING_CODE_PART_VALUE_LOV(COMPANY,CODEFILL_CODE_PART)";
            }
            e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// WM_CHAR event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblCdCompl_colsFillValue_OnWM_CHAR(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam != Vis.VK_Tab)
            {
                if (!(Sal.SendMsg(this.tblCdCompl_colsFillValue.i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_EditStateFieldEnabled, 0, 0)))
                {
                    Sal.MessageBeep(0);
                    e.Return = false;
                    return;
                }
                else
                {
                    if (this.tblCdCompl_colsCdPart.Text == this.tblCdCompl_colsCdPartFill.Text)
                    {
                        Sal.MessageBeep(0);
                        e.Return = false;
                        return;
                    }
                    if (!(this.AmIDemanded(this.tblCdCompl_colsCdPartFill.Text)))
                    {
                        Sal.MessageBeep(0);
                        e.Return = false;
                        return;
                    }
                }
            }
            #endregion
        }

        /// <summary>
        /// WM_PASTE event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblCdCompl_colsFillValue_OnWM_PASTE(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (!(Sal.SendMsg(this.tblCdCompl_colsFillValue.i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_EditStateFieldEnabled, 0, 0)) || (this.tblCdCompl_colsCdPart.Text == this.tblCdCompl_colsCdPartFill.Text))
            {
                Sal.MessageBeep(0);
                e.Return = false;
                return;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemZoom event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblCdCompl_colsFillValue_OnPM_DataItemZoom(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                if (this.tblCdCompl_colsCdPartFill.Text == "A")
                {
                    this.sItemName1 = this.GetItemName(this.tblCdCompl_colsFillValue);
                    this.sItemNames[0] = "COMPANY";
                    this.hWndItems[0] = this.tblCdCompl_colsCompany;
                    this.sItemNames[1] = "ACCOUNT";
                    this.hWndItems[1] = this.tblCdCompl_colsFillValue;
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("Account", this, this.sItemNames, this.hWndItems);
                    SessionNavigate(Pal.GetActiveInstanceName("tbwAccountOverview"));
                    e.Return = true;
                    return;
                }
                else
                {
                    Ifs.Fnd.ApplicationForms.Var.bReturn = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom, Sys.wParam, Sys.lParam);
                    Sal.WaitCursor(false);
                    this.sItemName1 = SalString.Null;
                    e.Return = Ifs.Fnd.ApplicationForms.Var.bReturn;
                    return;
                }
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }
        #endregion

        #region Window Events

        private void tblCdCompl_DataRecordGetDefaultsEvent(object sender, FndReturnEventArgsSalBoolean e)
        {
            e.Handled = true;
            e.ReturnValue = tblCdCompl_DataRecordGetDefaults(); ;
        }

        private void tblCdCompl_DataRecordRemoveEvent(object sender, cDataSource.DataRecordRemoveEventArgs e)
        {
            e.Handled = true;
            e.ReturnValue = tblCdCompl_DataRecordRemove(e.nWhat);
        }

        private void tblCdCompl_DataRecordNewEvent(object sender, cDataSource.DataRecordNewEventArgs e)
        {
            e.Handled = true;
            e.ReturnValue = tblCdCompl_DataRecordNew(e.nWhat);
        }

        #endregion 

        #endregion

        #region Event Handlers

        private void menuItem_Change_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = ChangeCompany(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem_Change_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            ChangeCompany(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        #endregion

       
    }
}
