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
    public partial class frmExternalFileTypeDefinition : cFormWindow
    {
        #region Window Variables
        public SalBoolean dummy = false;
        public SalString sViewExist = "";
        public SalString sFileType = "";
        public SalString sFormName = "";
        public SalString sLineFound = "";
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public frmExternalFileTypeDefinition()
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
        public new static frmExternalFileTypeDefinition FromHandle(SalWindowHandle handle)
        {
            return ((frmExternalFileTypeDefinition)SalWindow.FromHandle(handle, typeof(frmExternalFileTypeDefinition)));
        }
        #endregion

        #region Methods

        

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
                        return !(Sal.IsNull(ccsFileType));

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        Sal.WaitCursor(true);
                        sItemNames[0] = "FILE_TYPE";
                        hWndItems[0] = ccsFileType;
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("FILE_TYPE", i_hWndSelf, sItemNames, hWndItems);
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
        public virtual SalBoolean UM_FileParamLoad(SalNumber p_nWhat)
        {
            #region Actions
            using (new SalContext(this))
            {
                switch (p_nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        if (!(Sal.IsNull(dfsFormName)))
                        {
                            if (Ifs.Fnd.ApplicationForms.Var.Component.IsWindowAvailable(dfsFormName.Text))
                            {
                                if (Ifs.Fnd.ApplicationForms.Var.Security.IsPresObjectAvailable(dfsFormName.Text))
                                {
                                    return true;
                                }
                            }
                        }
                        return false;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        Sal.WaitCursor(true);
                        SessionCreateWindow(dfsFormName.Text, Sys.hWndMDI);
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
        public virtual SalBoolean UM_FileParamType(SalNumber p_nWhat)
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
                        return !(Sal.IsNull(ccsFileType));

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        Sal.WaitCursor(true);
                        sItemNames[0] = "FILE_TYPE";
                        hWndItems[0] = ccsFileType;
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("FILE_TYPE", i_hWndSelf, sItemNames, hWndItems);
                        SessionCreateWindow(Pal.GetActiveInstanceName("frmExternalFileParam"), Sys.hWndMDI);
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
            sFileType = ccsFileType.i_sMyValue;             
            if (!(DbPLSQLBlock(@"{0} := &AO.Ext_File_Type_Rec_API.Check_Group_Exist( {1} IN);",
                this.QualifiedVarBindName("sLineFound"),
                this.QualifiedVarBindName("sFileType"))))
            {
                this.sLineFound = "FALSE";
            }
            return (this.sLineFound == "TRUE");
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean IsThereAnyColumns()
        {
            sFileType = ccsFileType.i_sMyValue;  
            if (!(DbPLSQLBlock(@"{0} :=  &AO.Ext_File_Type_Rec_Column_API.Check_Column_Exist({1} IN, {2} IN);", 
                this.QualifiedVarBindName("sLineFound"),
                this.QualifiedVarBindName("sFileType"),
                this.tblExtFileTypeRec_colsGroupId.QualifiedBindName)))
            {
                dfsInputPackage.Text = Sys.STRING_Null;
                return false;
            }
            return (this.sLineFound == "TRUE");
    
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber RePopulate()
        {
            #region Actions
            using (new SalContext(this))
            {
                Sal.SendMsg(i_hWndFrame, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceUserWhere, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, DataSourceUserWhereGet().ToHandle());
                Sal.SendMsg(i_hWndFrame, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceUserOrderBy, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, DataSourceUserOrderByGet().ToHandle());
                Sal.SendMsg(i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Ifs.Fnd.ApplicationForms.Const.POPULATE_Single);
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber EnableDisableDataSource()
        {
            #region Actions
            using (new SalContext(this))
            {
                if (cbSystemDefined.Checked == true)
                {
                    SourceFlagsSet((((Ifs.Fnd.ApplicationForms.Const.SOURCE_Update | Ifs.Fnd.ApplicationForms.Const.SOURCE_OperationModify) | Ifs.Fnd.ApplicationForms.Const.SOURCE_OperationNew) | Ifs.Fnd.ApplicationForms.Const.SOURCE_OperationRemove), false);
                }
                else
                {
                    SourceFlagsSet((((Ifs.Fnd.ApplicationForms.Const.SOURCE_Update | Ifs.Fnd.ApplicationForms.Const.SOURCE_OperationModify) | Ifs.Fnd.ApplicationForms.Const.SOURCE_OperationNew) | Ifs.Fnd.ApplicationForms.Const.SOURCE_OperationRemove), true);
                }
            }

            return 0;
            #endregion
        }
        #endregion

        #region Window Actions

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void frmExternalFileTypeDefinition_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove:
                    this.frmExternalFileTypeDefinition_OnPM_DataRecordRemove(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordDuplicate:
                    this.frmExternalFileTypeDefinition_OnPM_DataRecordDuplicate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataRecordRemove event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmExternalFileTypeDefinition_OnPM_DataRecordRemove(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire)
            {
                if (this.cbSystemDefined.Checked)
                {
                    e.Return = false;
                    return;
                }
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataRecordDuplicate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmExternalFileTypeDefinition_OnPM_DataRecordDuplicate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordDuplicate, Sys.wParam, Sys.lParam))
            {
                e.Return = false;
                return;
            }
            else
            {
                e.Return = false;
                return;
            }
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void dfsDescription_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.dfsDescription_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsDescription_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.cbSystemDefined.Checked || this.ccsFileType.i_sMyValue == Ifs.Fnd.ApplicationForms.Const.strNULL)
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
        private void dfsComponent_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.dfsComponent_OnPM_DataItemQueryEnabled(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovUserOrderBy:
                    e.Handled = true;
                    e.Return = ((SalString)"NAME").ToHandle();
                    return;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.dfsComponent_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsComponent_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.cbSystemDefined.Checked || this.ccsFileType.i_sMyValue == Ifs.Fnd.ApplicationForms.Const.strNULL)
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
        private void dfsComponent_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
            if (this.dfsComponent.Text != Ifs.Fnd.ApplicationForms.Const.strNULL)
            {
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("MODULE_API.Exist", System.Data.ParameterDirection.Input);
                    if (this.dfsComponent.DbPLSQLBlock(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "MODULE_API.Exist(\r\n" +
                        ":i_hWndFrame.frmExternalFileTypeDefinition.dfsComponent )"))
                    {
                        e.Return = Sys.VALIDATE_Ok;
                        return;
                    }
                }
                e.Return = Sys.VALIDATE_Cancel;
                return;
            }
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void dfsApiToCallInput_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.dfsApiToCallInput_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsApiToCallInput_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.cbSystemDefined.Checked || this.ccsFileType.i_sMyValue == Ifs.Fnd.ApplicationForms.Const.strNULL)
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
        private void dfsApiToCallOutput_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.dfsApiToCallOutput_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsApiToCallOutput_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.cbSystemDefined.Checked || this.ccsFileType.i_sMyValue == Ifs.Fnd.ApplicationForms.Const.strNULL)
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
        private void dfsFormName_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.dfsFormName_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsFormName_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.cbSystemDefined.Checked || this.ccsFileType.i_sMyValue == Ifs.Fnd.ApplicationForms.Const.strNULL)
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
        private void dfsTargetDefaultMethod_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.dfsTargetDefaultMethod_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsTargetDefaultMethod_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.cbSystemDefined.Checked)
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
        private void tblExtFileTypeRec_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew:
                    this.tblExtFileTypeRec_OnPM_DataRecordNew(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove:
                    this.tblExtFileTypeRec_OnPM_DataRecordRemove(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataRecordNew event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblExtFileTypeRec_OnPM_DataRecordNew(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire)
            {
                if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew, Sys.wParam, Sys.lParam))
                {
                    if (this.cbSystemDefined.Checked == true)
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
        private void tblExtFileTypeRec_OnPM_DataRecordRemove(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire)
            {
                if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove, Sys.wParam, Sys.lParam))
                {
                    if (this.cbSystemDefined.Checked == true)
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
        #endregion

        #region Late Bind Methods

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        
        #endregion

        #region ChildTable-tblExtFileTypeRec

        #region Methods

        /// <summary>
        /// </summary>
        /// <param name="p_nWhat"></param>
        /// <returns></returns>
        public virtual SalBoolean UM_ColumnDefinition(SalNumber p_nWhat)
        {
            #region Local Variables
            SalArray<SalString> sItemNames = new SalArray<SalString>();
            SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
            #endregion

            #region Actions
          
            switch (p_nWhat)
            {
                case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                    return Sal.TblAnyRows(tblExtFileTypeRec, Sys.ROW_Selected, 0);

                case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                    Sal.WaitCursor(true);
                    sItemNames[0] = "FILE_TYPE";
                    hWndItems[0] = tblExtFileTypeRec_colsFileType;
                    sItemNames[1] = "RECORD_TYPE_ID";
                    hWndItems[1] = tblExtFileTypeRec_colsGroupId;
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("ExtFileTypeGroup", tblExtFileTypeRec, sItemNames, hWndItems);
                    SessionCreateWindow(Pal.GetActiveInstanceName("frmExternalFileTypeRecColumn"), Sys.hWndMDI);
                    Sal.WaitCursor(false);
                    return true;
            }
            return false;
            #endregion
        }



        /// <summary>
        /// </summary>
        /// <param name="nWhatInv"></param>
        /// <returns></returns>
        public virtual SalNumber CopyRecDetView(SalNumber nWhatInv)
        {
            #region Local Variables
            SalNumber nRow = 0;
            #endregion

            #region Actions
            switch (nWhatInv)
            {
                case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                    if (Sal.SendMsg(tblExtFileTypeRec, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0))
                    {
                        return false;
                    }
                    if (Sal.TblFindNextRow(tblExtFileTypeRec, ref nRow, Sys.ROW_Selected, 0))
                    {
                        if (Sal.TblFindNextRow(tblExtFileTypeRec, ref nRow, Sys.ROW_Selected, 0))
                        {
                            return false;
                        }
                    }
                    if (this.IsThereAnyColumns())
                    {
                        return false;
                    }
                    return true;
                    if (Sal.TblFindNextRow(tblExtFileTypeRec, ref nRow, Sys.ROW_Selected, 0))
                    {
                        if (Sal.TblFindNextRow(tblExtFileTypeRec, ref nRow, Sys.ROW_Selected, 0))
                        {
                            return false;
                        }
                    }
                    goto case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute;

                case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                    this.sFileType = this.ccsFileType.i_sMyValue;
                    if (dlgCreateRecDetFromView.ModalDialog(Ifs.Fnd.ApplicationForms.Int.Explorer.ExplorerForm, this.sFileType, this.dfsComponent.Text, tblExtFileTypeRec_colsGroupId.Text) == Sys.IDOK)
                    {
                        Sal.SendMsg(tblExtFileTypeRec, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceRefresh, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                        return true;
                    }
                    return false;
                }


            return 0;
            #endregion
        }
        #endregion

        #region Window Actions

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblExtFileTypeRec_colsFileType_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.tblExtFileTypeRec_colsFileType_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblExtFileTypeRec_colsFileType_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.cbSystemDefined.Checked)
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
        private void tblExtFileTypeRec_colsGroupId_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.tblExtFileTypeRec_colsGroupId_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblExtFileTypeRec_colsGroupId_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.cbSystemDefined.Checked)
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
        private void tblExtFileTypeRec_colsDescription_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.tblExtFileTypeRec_colsDescription_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblExtFileTypeRec_colsDescription_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.cbSystemDefined.Checked)
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
        private void tblExtFileTypeRec_colsSubGroupId_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.tblExtFileTypeRec_colsSubGroupId_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblExtFileTypeRec_colsSubGroupId_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.cbSystemDefined.Checked)
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
        private void tblExtFileTypeRec_colsFirstInSubGroup_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.tblExtFileTypeRec_colsFirstInSubGroup_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblExtFileTypeRec_colsFirstInSubGroup_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.cbSystemDefined.Checked)
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
        private void tblExtFileTypeRec_colsLastInSubGroup_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.tblExtFileTypeRec_colsLastInSubGroup_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblExtFileTypeRec_colsLastInSubGroup_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.cbSystemDefined.Checked)
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
        private void tblExtFileTypeRec_colsMandatoryRecord_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.tblExtFileTypeRec_colsMandatoryRecord_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblExtFileTypeRec_colsMandatoryRecord_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.cbSystemDefined.Checked)
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
        private void tblExtFileTypeRec_colsParentRecordType_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.tblExtFileTypeRec_colsParentRecordType_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblExtFileTypeRec_colsParentRecordType_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.cbSystemDefined.Checked)
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
        private void tblExtFileTypeRec_colsViewName_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblExtFileTypeRec_colsViewName_OnPM_DataItemValidate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.tblExtFileTypeRec_colsViewName_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblExtFileTypeRec_colsViewName_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.tblExtFileTypeRec_colsViewName.Text != Ifs.Fnd.ApplicationForms.Const.strNULL)
            {
                if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsViewAvailable(this.tblExtFileTypeRec_colsViewName.Text)))
                {
                    this.tblExtFileTypeRec_colsViewName.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                    Ifs.Fnd.ApplicationForms.Int.AlertBox(Ifs.Application.Accrul.Properties.Resources.TEXT_NotValidView, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                    e.Return = Sys.VALIDATE_Cancel;
                    return;
                }
            }
            e.Return = Sys.VALIDATE_Ok;
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblExtFileTypeRec_colsViewName_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.cbSystemDefined.Checked)
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
        private void tblExtFileTypeRec_colsInputPackage_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblExtFileTypeRec_colsInputPackage_OnPM_DataItemValidate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.tblExtFileTypeRec_colsInputPackage_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblExtFileTypeRec_colsInputPackage_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.tblExtFileTypeRec_colsInputPackage.Text != Ifs.Fnd.ApplicationForms.Const.strNULL)
            {
                if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable(this.tblExtFileTypeRec_colsInputPackage.Text)))
                {
                    Ifs.Fnd.ApplicationForms.Int.AlertBox(Ifs.Application.Accrul.Properties.Resources.TEXT_NotValidPackage, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                    e.Return = Sys.VALIDATE_Cancel;
                    return;
                }
            }
            e.Return = Sys.VALIDATE_Ok;
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblExtFileTypeRec_colsInputPackage_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.cbSystemDefined.Checked)
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
        #endregion

        #endregion

        #region Event Handlers

        private void menuItem__External_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            
            ((FndCommand)sender).Enabled = UM_FileDefinition(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem__External_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            UM_FileDefinition(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem_External_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {

            ((FndCommand)sender).Enabled = UM_FileParamType(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire); 
        }

        private void menuItem_External_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {

            UM_FileParamType(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute); 
        }

        private void menuItem_External_1_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {

            ((FndCommand)sender).Enabled = UM_FileParamLoad(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem_External_1_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            
            UM_FileParamLoad(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem_External_2_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = this.UM_ColumnDefinition( Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem_External_2_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            this.UM_ColumnDefinition(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem_Create_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            
            ((FndCommand)sender).Enabled = this.CopyRecDetView(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire); 
        }

        private void menuItem_Create_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
           this.CopyRecDetView(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute); 
        }

        #endregion

    }
}
