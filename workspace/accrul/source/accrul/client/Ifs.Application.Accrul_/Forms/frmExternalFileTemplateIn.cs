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
using System.Text;
using System.Drawing;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;
using System.ComponentModel;
using Ifs.Application.Accrul;
using Ifs.Application.Appsrv;
using Ifs.Application.Enterp;
using Ifs.Fnd.ApplicationForms;
using PPJ.Runtime;
using PPJ.Runtime.Sql;
using PPJ.Runtime.Vis;
using PPJ.Runtime.Windows;
using PPJ.Runtime.Windows.QO;
using Ifs.Fnd.Windows.Forms;

namespace Ifs.Application.Accrul_
{
	
	/// <summary>
	/// </summary>
    public partial class frmExternalFileTemplateIn : cFormWindow
    {
        #region Window Variables
        public SalString sLineFound = "";
        public SalBoolean bLinesCountFetched = false;
        public SalBoolean bRet = false;
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public frmExternalFileTemplateIn()
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
        public new static frmExternalFileTemplateIn FromHandle(SalWindowHandle handle)
        {
            return ((frmExternalFileTemplateIn)SalWindow.FromHandle(handle, typeof(frmExternalFileTemplateIn)));
        }
        #endregion

        #region Methods

        
        /// <summary>
        /// </summary>
        /// <param name="p_nWhat"></param>
        /// <returns></returns>
        public virtual SalBoolean UM_ExtFileTemplateControl(SalNumber p_nWhat)
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
                        if ((SourceStateGet() == Ifs.Fnd.ApplicationForms.Const.DATASOURCE_Empty) || ((bool)Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0)))
                        {
                            return false;
                        }
                        return true;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        Sal.WaitCursor(true);
                        sItemNames[0] = "FILE_TEMPLATE_ID";
                        hWndItems[0] = frmExternalFileTemplate.FromHandle(i_hWndParent).ccsFileTemplateId;
                        sItemNames[1] = "FILE_DIRECTION";
                        hWndItems[1] = cmbFileDirection;
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("FILE_TEMPLATE_ID", i_hWndSelf, sItemNames, hWndItems);
                        SessionCreateWindow(Pal.GetActiveInstanceName("frmExternalFileTemplateControl"), Sys.hWndMDI);
                        Sal.WaitCursor(false);
                        return true;
                }
            }

            return false;
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
                // Bug 73500, Begin
                if (Sal.IsNull(dfsFileTemplateId))
                {
                    return false;
                }
                // Bug 73500, End
                // Bug 73500, Begin, Added an IF condition to exclude the server call if the value has already been fetched
                if (!(bLinesCountFetched))
                {
                    using (SignatureHints hints = SignatureHints.NewContext())
                    {
                        hints.Add("In_Ext_File_Template_Dir_API.Check_Rec_Exist", System.Data.ParameterDirection.Input);
                        if (!(DbPLSQLBlock(cSessionManager.c_hSql, ":i_hWndFrame.frmExternalFileTemplateIn.sLineFound :=  " + cSessionManager.c_sDbPrefix + "In_Ext_File_Template_Dir_API.Check_Rec_Exist(\r\n" +
                            ":i_hWndFrame.frmExternalFileTemplateIn.dfsFileTemplateId)")))
                        {
                            sLineFound = "FALSE";
                        }
                    }
                }
                // Bug 73500, End
                // Bug 73500, Begin
                bLinesCountFetched = true;
                // Bug 73500, End
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
        #endregion

        #region Window Actions

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void frmExternalFileTemplateIn_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew:
                    this.frmExternalFileTemplateIn_OnPM_DataRecordNew(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove:
                    this.frmExternalFileTemplateIn_OnPM_DataRecordRemove(sender, e);
                    break;

                // Bug 73500, Begin

                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave:
                    this.frmExternalFileTemplateIn_OnPM_DataSourceSave(sender, e);
                    break;

                // Bug 73500, End
            }
            #endregion
        }

        /// <summary>
        /// PM_DataRecordNew event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmExternalFileTemplateIn_OnPM_DataRecordNew(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire)
            {
                if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew, Sys.wParam, Sys.lParam))
                {
                    if (frmExternalFileTemplate.FromHandle(this.i_hWndParent).cbSystemDefined.Checked == true)
                    {
                        e.Return = false;
                        return;
                    }
                    if (this.IsThereAnyLines())
                    {
                        e.Return = false;
                        return;
                    }
                }
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataRecordRemove event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmExternalFileTemplateIn_OnPM_DataRecordRemove(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire)
            {
                if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove, Sys.wParam, Sys.lParam))
                {
                    if (frmExternalFileTemplate.FromHandle(this.i_hWndParent).cbSystemDefined.Checked == true)
                    {
                        e.Return = false;
                        return;
                    }
                }
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataSourceSave event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmExternalFileTemplateIn_OnPM_DataSourceSave(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.bRet = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Sys.wParam, Sys.lParam);
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                // Reset the flag whenever a change is made
                this.bLinesCountFetched = false;
            }
            e.Return = this.bRet;
            return;
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
            // Bug 71319, Begin.
            if (this.cbSystemDefined.Checked == true)
            {
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                return;
            }
            // Bug 71319, End.
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
        private void cmbFileDirection_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.cmbFileDirection_OnPM_DataItemQueryEnabled(sender, e);
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
            // Bug 71319, Begin.
            if (this.cbSystemDefined.Checked == true)
            {
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                return;
            }
            // Bug 71319, End.
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
        private void cbSkipAllBlanks_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.cbSkipAllBlanks_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cbSkipAllBlanks_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            // Bug 71319, Begin.
            if (this.cbSystemDefined.Checked == true || this.dfsFileTemplateId.Text == Ifs.Fnd.ApplicationForms.Const.strNULL)
            {
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                return;
            }
            // Bug 71319, End.
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
        private void cbSkipInitialBlanks_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.cbSkipInitialBlanks_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cbSkipInitialBlanks_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            // Bug 71319, Begin.
            if (this.cbSystemDefined.Checked == true || this.dfsFileTemplateId.Text == Ifs.Fnd.ApplicationForms.Const.strNULL)
            {
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                return;
            }
            // Bug 71319, End.
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
        private void dfsFileName_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                // Bug 79498 Begin

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.dfsFileName_OnPM_DataItemValidate(sender, e);
                    break;

                // Bug 79498 End
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
            if (((bool)(((SalString)this.dfsFileName.Text).Length + ((SalString)this.dfsInputFilePath.Text).Length > 258)) || ((bool)(((SalString)this.dfsFileName.Text).Length + ((SalString)this.dfsInputFilePathServer.Text).Length > 258)) || ((bool)(
            ((SalString)this.dfsFileName.Text).Length + ((SalString)this.dfsBackupFilePath.Text).Length > 258)) || ((bool)(((SalString)this.dfsFileName.Text).Length + ((SalString)this.dfsBackupFilePathServer.Text).Length > 258)))
            {
                Ifs.Fnd.ApplicationForms.Int.AlertBox(Ifs.Application.Accrul.Properties.Resources.TEXT_MaximumLengthFileName2, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                e.Return = false;
                return;
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
        private void dfsLoadFileTypeList_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.dfsLoadFileTypeList_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsLoadFileTypeList_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            // Bug 71319, Begin.
            if (this.cbSystemDefined.Checked == true || this.dfsFileTemplateId.Text == Ifs.Fnd.ApplicationForms.Const.strNULL)
            {
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                return;
            }
            // Bug 71319, End.
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
        private void dfsInputFilePath_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                // Bug 79498 Begin

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.dfsInputFilePath_OnPM_DataItemValidate(sender, e);
                    break;

                // Bug 79498 End
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsInputFilePath_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (((SalString)this.dfsFileName.Text).Length + ((SalString)this.dfsInputFilePath.Text).Length > 258)
            {
                Ifs.Fnd.ApplicationForms.Int.AlertBox(Ifs.Application.Accrul.Properties.Resources.TEXT_MaximumLengthFileName2, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                e.Return = false;
                return;
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
        private void dfsInputFilePathServer_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                // Bug 79498 Begin

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.dfsInputFilePathServer_OnPM_DataItemValidate(sender, e);
                    break;

                // Bug 79498 End
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsInputFilePathServer_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (((SalString)this.dfsFileName.Text).Length + ((SalString)this.dfsInputFilePathServer.Text).Length > 258)
            {
                Ifs.Fnd.ApplicationForms.Int.AlertBox(Ifs.Application.Accrul.Properties.Resources.TEXT_MaximumLengthFileName2, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                e.Return = false;
                return;
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
        private void dfsBackupFilePath_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                // Bug 79498 Begin

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.dfsBackupFilePath_OnPM_DataItemValidate(sender, e);
                    break;

                // Bug 79498 End
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsBackupFilePath_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (((SalString)this.dfsFileName.Text).Length + ((SalString)this.dfsBackupFilePath.Text).Length > 258)
            {
                Ifs.Fnd.ApplicationForms.Int.AlertBox(Ifs.Application.Accrul.Properties.Resources.TEXT_MaximumLengthFileName2, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                e.Return = false;
                return;
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
        private void dfsBackupFilePathServer_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                // Bug 79498 Begin

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.dfsBackupFilePathServer_OnPM_DataItemValidate(sender, e);
                    break;

                // Bug 79498 End
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsBackupFilePathServer_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (((SalString)this.dfsFileName.Text).Length + ((SalString)this.dfsBackupFilePathServer.Text).Length > 258)
            {
                Ifs.Fnd.ApplicationForms.Int.AlertBox(Ifs.Application.Accrul.Properties.Resources.TEXT_MaximumLengthFileName2, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                e.Return = false;
                return;
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
        private void dfsCharacterSet_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovUserOrderBy:
                    e.Handled = true;
                    e.Return = ((SalString)"CHARACTER_SET").ToHandle();
                    return;
            }
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void cbAllowRecordSetRepeat_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.cbAllowRecordSetRepeat_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cbAllowRecordSetRepeat_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            // Bug 71319, Begin.
            if (this.cbSystemDefined.Checked == true || this.dfsFileTemplateId.Text == Ifs.Fnd.ApplicationForms.Const.strNULL)
            {
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                return;
            }
            // Bug 71319, End.
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
        private void cbAllowOneRecordSetOnly_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.cbAllowOneRecordSetOnly_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cbAllowOneRecordSetOnly_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            // Bug 71319, Begin.
            if (this.cbSystemDefined.Checked == true || this.dfsFileTemplateId.Text == Ifs.Fnd.ApplicationForms.Const.strNULL)
            {
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                return;
            }
            // Bug 71319, End.
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
        private void cbSystemDefined_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    e.Handled = true;
                    e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                    return;
            }
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void dfsApiToCall_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.dfsApiToCall_OnPM_DataItemQueryEnabled(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.dfsApiToCall_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsApiToCall_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            // Bug 71319, Begin.
            if (this.cbSystemDefined.Checked == true || this.dfsFileTemplateId.Text == Ifs.Fnd.ApplicationForms.Const.strNULL)
            {
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                return;
            }
            // Bug 71319, End.
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
        private void dfsApiToCall_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.dfsApiToCall.Text != Ifs.Fnd.ApplicationForms.Const.strNULL)
            {
                if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable(this.dfsApiToCall.Text)))
                {
                    Ifs.Fnd.ApplicationForms.Int.AlertBox(Ifs.Application.Accrul.Properties.Resources.ERROR_Method, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                    this.dfsApiToCall.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                    e.Return = false;
                    return;
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
        private void dfsApiToCallUnpBefore_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.dfsApiToCallUnpBefore_OnPM_DataItemQueryEnabled(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.dfsApiToCallUnpBefore_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsApiToCallUnpBefore_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            // Bug 71319, Begin.
            if (this.cbSystemDefined.Checked == true || this.dfsFileTemplateId.Text == Ifs.Fnd.ApplicationForms.Const.strNULL)
            {
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                return;
            }
            // Bug 71319, End.
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
        private void dfsApiToCallUnpBefore_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.dfsApiToCallUnpBefore.Text != Ifs.Fnd.ApplicationForms.Const.strNULL)
            {
                if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable(this.dfsApiToCallUnpBefore.Text)))
                {
                    Ifs.Fnd.ApplicationForms.Int.AlertBox(Ifs.Application.Accrul.Properties.Resources.ERROR_Method, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                    this.dfsApiToCallUnpBefore.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                    e.Return = false;
                    return;
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
        private void dfsApiToCallUnpAfter_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.dfsApiToCallUnpAfter_OnPM_DataItemQueryEnabled(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.dfsApiToCallUnpAfter_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsApiToCallUnpAfter_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            // Bug 71319, Begin.
            if (this.cbSystemDefined.Checked == true || this.dfsFileTemplateId.Text == Ifs.Fnd.ApplicationForms.Const.strNULL)
            {
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                return;
            }
            // Bug 71319, End.
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
        private void dfsApiToCallUnpAfter_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.dfsApiToCallUnpAfter.Text != Ifs.Fnd.ApplicationForms.Const.strNULL)
            {
                if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable(this.dfsApiToCallUnpAfter.Text)))
                {
                    Ifs.Fnd.ApplicationForms.Int.AlertBox(Ifs.Application.Accrul.Properties.Resources.ERROR_Method, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                    this.dfsApiToCallUnpAfter.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                    e.Return = false;
                    return;
                }
            }
            e.Return = true;
            return;
            #endregion
        }
        #endregion

        #region Late Bind Methods

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        
        #endregion

        #region Event Handlers

        private void menuItem_External_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {

            ((FndCommand)sender).Enabled = UM_ExtFileTemplateControl(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire) ;
        }

        private void menuItem_External_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {

            UM_ExtFileTemplateControl(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        #endregion

    }
}
