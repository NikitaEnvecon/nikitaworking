#region Copyright (c) IFS Research & Development
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
#endregion
#region History
#endregion

using System;
using System.Text;
using System.Drawing;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;
using Ifs.Fnd.ApplicationForms;
using PPJ.Runtime;
using PPJ.Runtime.Vis;
using PPJ.Runtime.Windows;
using Ifs.Fnd.Windows.Forms;
using System.IO;

namespace Ifs.Application.Accrul
{

    /// <summary>
    /// </summary>
    [FndWindowRegistration("AUDIT_SOURCE", "AuditSource")]
    [FndWindowRegistration("AUDIT_STORAGE", "AuditStorage")]
    public partial class dlgAuditInterface : cWizardDialogBox
    {
        #region Member Variables
		public SalString sCompany = "";
        public SalString sSourceType = "";
        public SalString sIsIntled = "";
        public SalString sIsLedgerValid = "";
        public SalString sReportId = "";
        private FolderBrowserDialog folderBrowserDialog1;
        public SalString sObjid = "";
        public SalString sBatch = "";
        public SalString lsReportAttr = "";
        public SalString lsParameter = "";
        public SalNumber nJobId = 0;
        public DateTime dDateFrom;
        public DateTime dDateUntil;
        SalArray<SalString> sParam = new SalArray<SalString>();
        public SalBoolean bStartup = false;
        public SalString sDateTitle = "";
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        protected dlgAuditInterface()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.folderBrowserDialog1.Description = "Output Path";
            this.folderBrowserDialog1.ShowNewFolderButton = false;
            //this.folderBrowserDialog1.RootFolder = Environment.SpecialFolder.Personal;
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
            dlgAuditInterface dlg = DialogFactory.CreateInstance<dlgAuditInterface>();
            SalNumber ret = dlg.ShowDialog(owner);
            return ret;
        }

        /// <summary>
        /// Returns the object instance associated with the window handle.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public new static dlgAuditInterface FromHandle(SalWindowHandle handle)
        {
            return ((dlgAuditInterface)SalWindow.FromHandle(handle, typeof(dlgAuditInterface)));
        }
        #endregion

        #region Properties

        #endregion

        #region Methods

        public new SalBoolean FrameStartupUser()
        {
            #region Local Variables
            String sDate = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                bStartup = true;
                UserGlobalValueGet("COMPANY", ref sCompany);
                dfCompany.Text = sCompany;
                Sal.SendMsg(dfCompany, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                dDateFrom = new System.DateTime(1900, 1, 1);
                dDateUntil = new System.DateTime(2099, 12, 31);
                bStartup = false;
            }

            return 0;
            #endregion
        }

        public new SalNumber DataSourceInquireSave()
        {
            #region Actions
            using (new SalContext(this))
            {
                return Sys.IDNO;
            }
            #endregion
        }

        public new SalBoolean WizardFinish(SalNumber nWhat, SalString sStep)
        {
            #region Local Variables
            SalNumber nError = 0;
            SalString sFileName = "";
            SalString sXmlFileName = "";
            SalString sStmt = "";
            SalBoolean bOk = false;
            SalString sReturnCompany = "";
            // Bug 123784, Begin
            SalString sTempObjid = "";
            SalNumber nTo;
            SalBoolean bFirst = true;
            SalString sClobData = "";
            // Bug 123784, End
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire)
                {
                    if (m_nCurrentPage == 1)
                    {
                        if (sSourceType == "VIEW")
                        {
                            if (!(dfCountry.Text == Sys.STRING_Null || dfAuditSource.Text == Sys.STRING_Null || dfOutputPath.Text == Sys.STRING_Null ||
                                dfCompany.Text == Sys.STRING_Null || (sDateTitle != Sys.STRING_Null && (dfDateFrom.DateTime == Sys.DATETIME_Null || dfDateUntil.DateTime == Sys.DATETIME_Null)) ||
                                (sIsIntled == "TRUE" && dfLedgerID.Text == Sys.STRING_Null)))
                            {
                                return true;
                            }
                        }
                        else
                        {
                            if (!(dfCountry.Text == Sys.STRING_Null || dfAuditSource.Text == Sys.STRING_Null || dfOutputPath.Text == Sys.STRING_Null))
                            {
                                return true;
                            }
                        }
                    }
                    return false;
                }
                if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
                {
                    sBatch = "FALSE";
                    if (rbBatch.Checked)
                    {
                        sBatch = "TRUE";
                    }
                    
                    if (sSourceType == "REPORT")
                    {
                        lsParameter = Ifs.Fnd.ApplicationForms.Const.strNULL;
                        Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("COMPANY", dfCompany.Text, ref lsParameter);
                        // the company that is selected in the Report Order dialog has to be set to the company field
                        // and has to be validated if the audit format is available in the company
                        if (dlgAuditReportOrder.ModalDialog(Ifs.Fnd.ApplicationForms.Int.Explorer.ExplorerForm, sReportId, ref lsParameter) == Sys.IDOK)
                        {                            
                            Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("REPORT_ID", sReportId, ref lsReportAttr);
                            sStmt = @"&AO.Audit_Util_API.Generate_Report_Output(
                                             :i_hWndFrame.dlgAuditInterface.sObjid OUT,
                                             :i_hWndFrame.dlgAuditInterface.nJobId OUT,
                                             :i_hWndFrame.dlgAuditInterface.dfCompany IN,
                                             :i_hWndFrame.dlgAuditInterface.dfCountry IN,
                                             :i_hWndFrame.dlgAuditInterface.dfAuditSource IN,
                                             :i_hWndFrame.dlgAuditInterface.lsReportAttr IN,
                                             :i_hWndFrame.dlgAuditInterface.lsParameter IN,
                                             :i_hWndFrame.dlgAuditInterface.sBatch IN)";
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        sStmt = @"&AO.Audit_Util_API.Generate_Output(
                                             :i_hWndFrame.dlgAuditInterface.sObjid OUT,
                                             :i_hWndFrame.dlgAuditInterface.nJobId OUT,
                                             :i_hWndFrame.dlgAuditInterface.dfCountry IN,
                                             :i_hWndFrame.dlgAuditInterface.dfAuditSource IN,
                                             :i_hWndFrame.dlgAuditInterface.dfCompany IN,
                                             :i_hWndFrame.dlgAuditInterface.dfDateFrom IN,
                                             :i_hWndFrame.dlgAuditInterface.dfDateUntil IN,
                                             :i_hWndFrame.dlgAuditInterface.sBatch IN)";
                    }

                    if (DbPLSQLTransaction(cSessionManager.c_hSql, sStmt))
                    {
                        if (sBatch == "FALSE")
                        {
                            sFileName = dfOutputPath.Text + "\\" + dfAuditSource.Text;
                            sXmlFileName = dfOutputPath.Text + "\\" + dfAuditSource.Text + "_I.XML";
                            // Bug 123784, Begin                            
                            sTempObjid = sObjid;
                            bFirst = true;
                            while (true)
                            {
                                nTo = sTempObjid.Scan(";");
                                if (nTo == -1)
                                    break;
                                sObjid = sTempObjid.Mid(0, nTo);
                                if (bFirst)
                                {
                                    bOk = DbLobReadToFile(cSessionManager.c_hSql, "XML_DATA", "AUDIT_STORAGE", sObjid, sXmlFileName, ref nError);
                                    File.WriteAllText(sFileName, sClobData);
                                    bFirst = false;
                                }
                                sClobData = "";
                                bOk = DbLobRead(cSessionManager.c_hSql, "DATA", "AUDIT_STORAGE", sObjid, ref sClobData);
                                File.AppendAllText(sFileName, sClobData);
                                sTempObjid = sTempObjid.Mid(nTo + 1, 2000);
                            }
                            // Bug 123784, End
                            dlgAuditFileResult.ModalDialog(Ifs.Fnd.ApplicationForms.Int.Explorer.ExplorerForm, sFileName, sXmlFileName);
                        }
                        else
                        {
                            sParam[0] = nJobId.ToString();
                            Ifs.Fnd.ApplicationForms.Int.AlertBoxWithParams(Properties.Resources.TEXT_AuditBackJobCreated, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok, sParam);
                        }
                        return Sal.EndDialog(this, 0);
                    }
                    return false;
                }
            }

            return false;
            #endregion
        }

        public new SalBoolean WizardNext(SalNumber nWhat, SalString sStep)
        {
            #region Local Variables
            SalString sDrive = "";
            SalString sDir = "";
            SalString sFile = "";
            SalString sExt = "";
            SalArray<SalString> sParam = new SalArray<SalString>();
            SalWindowHandle hWndStep = null;
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
                        if (dfCountry.Text == Sys.STRING_Null || dfAuditSource.Text == Sys.STRING_Null || dfOutputPath.Text == Sys.STRING_Null ||
                            dfCompany.Text == Sys.STRING_Null || dfDateFrom.DateTime == Sys.DATETIME_Null || dfDateFrom.DateTime == Sys.DATETIME_Null)
                        {
                            return false;
                        }
                        if (sSourceType == "VIEW")
                        {
                            return false;
                        }
                        return false;
                    }
                    return false;
                }
                else if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
                {
                    if (sStep == "Step2")
                    {
                        if (rbOnline.Checked)
                        { 
                            Sal.EnableWindowAndLabel(dfOutputPath);
                            Sal.EnableWindow(pbBrowse);
                        }
                        else
                        {
                            Sal.DisableWindowAndLabel(dfOutputPath);
                            Sal.DisableWindow(pbBrowse);
                        }
                        if (dfCountry.Text != Ifs.Fnd.ApplicationForms.Const.strNULL)
                        {
                            GetOutputPath();
                        }
                        if (Sal.IsNull(dfAuditSource))
                        {
                            Sal.DisableWindow(gbSelection);
                        }
                    }
                    return true;
                }
            }

            return false;
            #endregion
        }

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
                    return true;
                }
            }

            return false;
            #endregion
        }

        public virtual void GetOutputPath()
        {
            #region Local Variables
            SalString lsStmt = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                if (rbOnline.Checked)
                {
                    lsStmt = @":i_hWndFrame.dlgAuditInterface.dfOutputPath := 
                                        &AO.Audit_Format_API.Get_Output_File_Dir(
                                                :i_hWndFrame.dlgAuditInterface.dfCompany,
                                                :i_hWndFrame.dlgAuditInterface.dfCountry)";
                }
                else
                {
                    lsStmt = @":i_hWndFrame.dlgAuditInterface.dfOutputPath := 
                                        &AO.Audit_Format_API.Get_Output_File_Dir_Server(
                                                :i_hWndFrame.dlgAuditInterface.dfCompany,
                                                :i_hWndFrame.dlgAuditInterface.dfCountry)";
                }
                DbPLSQLBlock(cSessionManager.c_hSql, lsStmt);
            }
            #endregion
        }
        #endregion

        #region Overrides

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
        public override SalBoolean vrtWizardFinish(SalNumber nWhat, SalString sStep)
        {
            return this.WizardFinish(nWhat, sStep);
        }
        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalBoolean vrtWizardNext(SalNumber nWhat, SalString sStep)
        {
            return this.WizardNext(nWhat, sStep);
        }

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalBoolean vrtWizardPrevious(SalNumber nWhat, SalString sStep)
        {
            return this.WizardPrevious(nWhat, sStep);
        }

        #endregion

        #region Window Actions

        private void dlgAuditInterface_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceQueryFieldName:
                    this.dlgAuditInterface_OnPM_DataSourceQueryFieldName(sender, e);
                    break;
            }
            #endregion
        }

        private void dlgAuditInterface_OnPM_DataSourceQueryFieldName(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (SalString.FromHandle(Sys.lParam) == "COMPANY")
            {
				switch (Sys.wParam)
				{
					case Vis.DT_Handle:
						e.Return = SalWindowHandle.Null.ToNumber();
						return;
					
					default:
						e.Return = (this.i_hWndFrame.ToNumber().ToString(0) + ".dlgAuditInterface.dfCompany").ToHandle();
						return;
				}
			}
			else
			{
				e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceQueryFieldName, Sys.wParam, Sys.lParam);
				return;
			}
            #endregion
        }

        private void dfCompany_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.dfCompany_OnPM_DataItemValidate(sender, e);
                    break;

                case Sys.SAM_AnyEdit:
                    e.Handled = true;
                    break;
            }
            #endregion
        }

        private void dfCompany_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Local Variables
            SalString lsStmt = "";
            #endregion

            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam))
            {
                if (this.dfCompany.Text != Ifs.Fnd.ApplicationForms.Const.strNULL)
                {
                    lsStmt = @"BEGIN
                                    &AO.Company_Finance_API.Exist(:i_hWndFrame.dlgAuditInterface.dfCompany);
                                    :i_hWndFrame.dlgAuditInterface.dfCompanyDesc := &AO.Company_API.Get_Name(:i_hWndFrame.dlgAuditInterface.dfCompany);
                                    :i_hWndFrame.dlgAuditInterface.dfCountry := &AO.Audit_Format_API.Get_Default_Country(:i_hWndFrame.dlgAuditInterface.dfCompany);
                               END;";
                    if (!DbPLSQLBlock(cSessionManager.c_hSql, lsStmt))
                    {
                        e.Return = Sys.VALIDATE_Cancel;
                        return;
                    }
                    // raise error message only if the validation is not come from FrameStartupUser()
                    if (dfCountry.Text == Sys.STRING_Null && !bStartup)
                    {
                        sParam[0] = dfCompany.Text;
                        Ifs.Fnd.ApplicationForms.Int.AlertBoxWithParams(Properties.Resources.TEXT_NoDefAuditCountry, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.INFO_Ok, sParam);
                        dfAuditSource.Text = Sys.STRING_Null;
                        dfOutputPath.Text = Sys.STRING_Null;
                        e.Return = Sys.VALIDATE_Cancel;
                        return;
                    }
                    Sal.SendMsg(dfCountry, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                    pbFinish.MethodInvestigateState();
                }
                e.Return = Sys.VALIDATE_Ok;
                return;
            }
            e.Return = Sys.VALIDATE_Cancel;
            return;
            #endregion
        }

        private void dfCountry_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.dfCountry_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        private void dfCountry_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Local Variables
            SalString lsStmt = "";
            #endregion

            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam))
            {
                if (this.dfCountry.Text != Ifs.Fnd.ApplicationForms.Const.strNULL)
                {
                    lsStmt = @"&AO.Audit_Format_API.Audit_Format_Exist(:i_hWndFrame.dlgAuditInterface.dfCompany, :i_hWndFrame.dlgAuditInterface.dfCountry)";
                    if (!DbPLSQLBlock(cSessionManager.c_hSql, lsStmt))
                    {
                        e.Return = Sys.VALIDATE_Cancel;
                        return;
                    }
                    GetOutputPath();
                }
                e.Return = Sys.VALIDATE_Ok;
                return;
            }
            e.Return = Sys.VALIDATE_Cancel;
            return;
            #endregion
        }

        private void dfAuditSource_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.dfAuditSource_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        private void dfAuditSource_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Local Variables
            SalString lsStmt = "";
            #endregion

            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam))
            {
                if (this.dfAuditSource.Text != Ifs.Fnd.ApplicationForms.Const.strNULL)
                {
                    lsStmt = @"DECLARE
                                    source_type_ VARCHAR(20);
                                    pub_rec_     &AO.Audit_Source_API.Public_Rec;
                                    ledger_id_   VARCHAR2(20);
                               BEGIN
                                    &AO.Audit_Source_API.Exist(:i_hWndFrame.dlgAuditInterface.dfAuditSource);
                                    pub_rec_ := &AO.Audit_Source_API.Get(:i_hWndFrame.dlgAuditInterface.dfAuditSource);
                                    IF pub_rec_.source_type = 'REPORT' THEN
                                        :i_hWndFrame.dlgAuditInterface.sReportId :=  
                                                &AO.Audit_Source_API.Get_Report_Id(:i_hWndFrame.dlgAuditInterface.dfAuditSource);
                                    END IF;
                                    IF pub_rec_.internal_ledger = 'TRUE' THEN
                                        ledger_id_ :=  &AO.Internal_Ledger_User_API.Get_Default_Ledger(:i_hWndFrame.dlgAuditInterface.dfCompany, 
                                                                                                       &AO.Fnd_Session_API.Get_Fnd_User);
                                        :i_hWndFrame.dlgAuditInterface.dfLedgerID := ledger_id_;
                                        :i_hWndFrame.dlgAuditInterface.dfLedgerDesc := &AO.Internal_Ledger_API.Get_Description(:i_hWndFrame.dlgAuditInterface.dfCompany, 
                                                                                                                             ledger_id_);    
                                    END IF;
                                    :i_hWndFrame.dlgAuditInterface.sDateTitle := &AO.Audit_Source_Column_API.Get_Selection_Date_Title(:i_hWndFrame.dlgAuditInterface.dfAuditSource);
                                    :i_hWndFrame.dlgAuditInterface.sSourceType := pub_rec_.source_type;
                                    :i_hWndFrame.dlgAuditInterface.sIsIntled := pub_rec_.internal_ledger;
                               END;";
                    if (!DbPLSQLBlock(cSessionManager.c_hSql, lsStmt))
                    {
                        e.Return = Sys.VALIDATE_Cancel;
                        return;
                    }
                    if (sSourceType == "VIEW")
                    {
                        Sal.EnableWindow(gbSelection);
                        if (sIsIntled == "TRUE")
                        {
                            Sal.EnableWindowAndLabel(dfLedgerID);
                        }
                        else
                        {
                            Sal.DisableWindowAndLabel(dfLedgerID);
                            dfLedgerID.Text = Sys.STRING_Null;
                            dfLedgerDesc.Text = Sys.STRING_Null;
                        }
                        gbDateTitle.Text = sDateTitle;
                        if (sDateTitle == Sys.STRING_Null)
                        {
                            dfDateFrom.DateTime = Sys.DATETIME_Null;
                            dfDateUntil.DateTime = Sys.DATETIME_Null;
                            Sal.DisableWindow(gbDateTitle);
                            //Sal.DisableWindowAndLabel(dfDateFrom);
                            //Sal.DisableWindowAndLabel(dfDateUntil);
                        }
                        else
                        {
                            dfDateFrom.DateTime = dDateFrom;
                            dfDateUntil.DateTime = dDateUntil;
                            Sal.EnableWindow(gbDateTitle);
                            //Sal.EnableWindowAndLabel(dfDateFrom);
                            //Sal.EnableWindowAndLabel(dfDateUntil);
                        }
                    }
                    else
                    {
                        Sal.DisableWindow(gbSelection);
                        dfDateFrom.DateTime = Sys.DATETIME_Null;
                        dfDateUntil.DateTime = Sys.DATETIME_Null;
                        dfLedgerID.Text = Sys.STRING_Null;
                        dfLedgerDesc.Text = Sys.STRING_Null;
                    }
                    pbNext.MethodInvestigateState();
                    pbFinish.MethodInvestigateState();
                }
                e.Return = Sys.VALIDATE_Ok;
                return;
            }
            e.Return = Sys.VALIDATE_Cancel;
            return;
            #endregion
        }

        private void dfDateFrom_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.dfDateFrom_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        private void dfDateFrom_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam))
            {
                pbFinish.MethodInvestigateState();
                e.Return = Sys.VALIDATE_Ok;
                return;
            }
            e.Return = Sys.VALIDATE_Cancel;
            return;
            #endregion
        }

        private void dfDateUntil_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.dfDateUntil_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        private void dfDateUntil_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam))
            {
                pbFinish.MethodInvestigateState();
                e.Return = Sys.VALIDATE_Ok;
                return;
            }
            e.Return = Sys.VALIDATE_Cancel;
            return;
            #endregion
        }

        private void dfOutputPath_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.dfOutputPath_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        private void dfOutputPath_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam))
            {
                if (this.dfOutputPath.Text != Ifs.Fnd.ApplicationForms.Const.strNULL)
                {
                    if (!System.IO.Directory.Exists(dfOutputPath.Text))
                    {
                        Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_InvalidOutputPath, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                        e.Return = Sys.VALIDATE_Cancel;
                        return;
                    }
                }
                pbFinish.MethodInvestigateState();
                e.Return = Sys.VALIDATE_Ok;
                return;
            }
            e.Return = Sys.VALIDATE_Cancel;
            return;
            #endregion
        }

        private void dfLedgerID_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.dfLedgerID_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        private void dfLedgerID_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam))
            {
                dfLedgerDesc.Text = Sys.STRING_Null;
                if (this.dfLedgerID.Text != Ifs.Fnd.ApplicationForms.Const.strNULL)
                {
                    DbPLSQLBlock(cSessionManager.c_hSql,
                            @":i_hWndFrame.dlgAuditInterface.sIsLedgerValid := &AO.Internal_Ledger_API.Ledger_Id_Exist_User(
                                                                                        :i_hWndFrame.dlgAuditInterface.dfCompany,
                                                                                        :i_hWndFrame.dlgAuditInterface.dfLedgerID)");
                    if (this.sIsLedgerValid == "FALSE")
                    {
                        Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_InvalidLederID, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                        e.Return = Sys.VALIDATE_Cancel;
                        return;
                    }
                    DbPLSQLBlock(cSessionManager.c_hSql,
                            @":i_hWndFrame.dlgAuditInterface.dfLedgerDesc := &AO.Internal_Ledger_API.Get_Description(
                                                                                        :i_hWndFrame.dlgAuditInterface.dfCompany,
                                                                                        :i_hWndFrame.dlgAuditInterface.dfLedgerID)");
                }
                pbFinish.MethodInvestigateState();
                e.Return = Sys.VALIDATE_Ok;
                return;
            }
            e.Return = Sys.VALIDATE_Cancel;
            return;
            #endregion
        }

        #endregion

        #region Event Handlers

        private void cmdBrowse_Inquire(object sender, Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            #region Local Variables
            FndCommand command = (FndCommand)sender;
            #endregion

            #region Actions
            command.Enabled = rbOnline.Checked;
            #endregion;
        }

        private void cmdBrowse_Execute(object sender, Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            #region Local Variables
            SalArray<SalString> sList = new SalArray<SalString>();
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                DialogResult result = folderBrowserDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    dfOutputPath.Text = folderBrowserDialog1.SelectedPath;
                }
            }
            #endregion
        }

        #endregion

        #region Menu Event Handlers

        #endregion
    }
}
