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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Ifs.Fnd.ApplicationForms;
using PPJ.Runtime;
using PPJ.Runtime.Windows;
using Ifs.Fnd.Windows.Forms;

namespace Ifs.Application.Accrul
{

    /// <summary>
    /// </summary>
    public partial class frmFooterField : cFormWindow
    {
        #region Member Variables
        SalString sFooters;
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public frmFooterField()
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
        [DebuggerStepThrough]
        public new static frmFooterField FromHandle(SalWindowHandle handle)
        {
            return ((frmFooterField)SalWindow.FromHandle(handle, typeof(frmFooterField)));
        }
        #endregion

        #region Properties

        #endregion

        #region Methods

        public SalBoolean DataRecordExecuteRemove(PPJ.Runtime.Sql.SalSqlHandle hSql)
        {
            SalArray<SalString> sParam = new SalArray<SalString>();
            DbPLSQLBlock(cSessionManager.c_hSql,
                @"BEGIN
                        :i_hWndFrame.frmFooterField.sFooters := 
                            &AO.Footer_Definition_API.Get_Footer_Field_Used(
                                :i_hWndFrame.frmFooterField.dfCompany IN,
                                :i_hWndFrame.frmFooterField.cmbFieldId IN);
                      END;");

            if (sFooters != Ifs.Fnd.ApplicationForms.Const.strNULL)
            {
                sParam[0] = sFooters;
				if (Ifs.Fnd.ApplicationForms.Int.AlertBoxWithParams(Properties.Resources.QUESTION_FooterFieldUsed,Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Question,(Ifs.Fnd.ApplicationForms.Const.QUESTION_YesNo | Sys.MB_DefButton2), sParam) == 
				Sys.IDNO) 
				{
					return false;
				}
            }

            return base.DataRecordExecuteRemove(hSql);
        }

        public SalBoolean DataSourceSaveModified()
        {
            bool bModify = false;
            if (this.i_nRecordState & Sys.ROW_Edited)
                bModify = true;

            Ifs.Application.Accrul.frmDocumentFooter.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(this)).bFooterFieldModify = bModify;
            return base.DataSourceSaveModified();
        }

        #endregion

        #region Overrides
        
        public override SalBoolean vrtDataRecordExecuteRemove(PPJ.Runtime.Sql.SalSqlHandle hSql)
        {
            return this.DataRecordExecuteRemove(hSql);
        }

        public override SalBoolean vrtDataSourceSaveModified()
        {
            return this.DataSourceSaveModified();
        }

        #endregion

        #region Message Actions

        private void cbFreeText_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.cbFreeText_PM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        private void cbFreeText_PM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (cbSystemDefined.Checked)
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
            else
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldEnabled;
            #endregion
        }

        private void mlFooterText_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.mlFooterText_PM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        private void mlFooterText_PM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (cbSystemDefined.Checked)
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
            else
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldEnabled;
            #endregion
        }

        #endregion

        private void cmdTranslateFooter_Execute(object sender, Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            #region Local Variables
            SalNumber nRow = 0;
            SalArray<SalString> sItemNames = new SalArray<SalString>();
            SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
            SalString sModule = "";
            SalString sLu = "";
            SalString lsAttribute = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            Sal.WaitCursor(true);
            sModule = "ACCRUL";
            sLu = "FooterField";
            lsAttribute = Ifs.Fnd.ApplicationForms.Const.strNULL;
            lsAttribute =  "'" + cmbFieldId.Text +  "'" ;
            Ifs.Fnd.ApplicationForms.Var.Cache.SessionStore("TRANSLATE_COMPANY", dfCompany.Text);
            Ifs.Fnd.ApplicationForms.Var.Cache.SessionStore("TRANSLATE_MODULE", sModule);
            Ifs.Fnd.ApplicationForms.Var.Cache.SessionStore("TRANSLATE_LU", sLu);
            Ifs.Fnd.ApplicationForms.Var.Cache.SessionStore("TRANSLATE_ATTRIBUTE", lsAttribute);
            SessionCreateWindow(Pal.GetActiveInstanceName("frmCompanyTranslation"), Sys.hWndMDI);
            Sal.WaitCursor(false);
            #endregion 

        }

        private void cmdTranslateFooter_Inquire(object sender, Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            #region Actions

            if ((dfCompany.Text == Ifs.Fnd.ApplicationForms.Const.strNULL) || (Sal.SendMsg(i_hWndFrame, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0)==true))
            {
                ((FndCommand)sender).Enabled = false;
            }
            else
            {
                ((FndCommand)sender).Enabled = true;
            }
            #endregion

        }

        private void cmdImportSystemFooter_Execute(object sender, FndCommandExecuteEventArgs e)
        {
            #region Variables
            SalString sTempCompany;
            #endregion

            #region Actions
            using (new SalContext(this))
            Sal.WaitCursor(true);
            // After deleting a Footer Field and directly running Import System Footer Field the company is empty, get it from parent window
            if (this.dfCompany.Text == Ifs.Fnd.ApplicationForms.Const.strNULL)
            {
                sTempCompany = SalString.FromHandle(Sal.SendMsg(this.i_hWndParent, Ifs.Fnd.ApplicationForms.Const.PM_User, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, ((SalString)"GetCompany").ToHandle()));
                this.dfCompany.Text = sTempCompany;
            }
                            
            DbPLSQLTransaction(cSessionManager.c_hSql,
                @"&AO.Footer_Field_API.Import_System_Footer_Field__(
                                :i_hWndFrame.frmFooterField.dfCompany IN);");
            Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
            Sal.WaitCursor(false);
            #endregion
        }

        private void cmdImportSystemFooter_Inquire(object sender, FndCommandInquireEventArgs e)
        {
            #region Actions
            if (this.i_nDataSourceState == Ifs.Fnd.ApplicationForms.Const.DATASOURCE_Empty)
            {
                ((FndCommand)sender).Enabled = false;
            }
            else
            {
                ((FndCommand)sender).Enabled = true;
            }

            #endregion
        }



        #region Event Handlers
        #endregion

        #region Menu Event Handlers

        #endregion
    }
}
