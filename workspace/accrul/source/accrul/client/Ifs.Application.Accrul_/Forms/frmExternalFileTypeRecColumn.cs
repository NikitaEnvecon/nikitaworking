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
    public partial class frmExternalFileTypeRecColumn : cFormWindow
    {
        #region Window Variables
        public SalString sDestinationColumn = "";
        public SalString sDateType = "";
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public frmExternalFileTypeRecColumn()
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
        public new static frmExternalFileTypeRecColumn FromHandle(SalWindowHandle handle)
        {
            return ((frmExternalFileTypeRecColumn)SalWindow.FromHandle(handle, typeof(frmExternalFileTypeRecColumn)));
        }
        #endregion

        #region Methods

       

        /// <summary>
        /// </summary>
        /// <param name="p_nWhat"></param>
        /// <returns></returns>
        public virtual SalBoolean UM_ExtRowDef(SalNumber p_nWhat)
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
                        sItemNames[0] = "FILE_TYPE";
                        hWndItems[0] = dfsFileType;
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("FILE_TYPE", i_hWndSelf, sItemNames, hWndItems);
                        SessionCreateWindow(Pal.GetActiveInstanceName("frmExternalFileTemplate"), Sys.hWndMDI);
                        Sal.WaitCursor(false);
                        return true;
                        return true;
                }
            }

            return false;
            #endregion
        }
        #endregion

        #region Window Actions

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void dfFileTypeName_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.dfFileTypeName_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfFileTypeName_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
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
        private void dfsGroupId_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.dfsGroupId_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsGroupId_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
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
        private void dfsSubGroupId_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.dfsSubGroupId_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsSubGroupId_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
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
        private void cbFirstInSubGroup_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.cbFirstInSubGroup_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cbFirstInSubGroup_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
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
        private void cbLastInSubGroup_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.cbLastInSubGroup_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cbLastInSubGroup_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
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
        private void tblExtFileTypeRecColumn_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew:
                    this.tblExtFileTypeRecColumn_OnPM_DataRecordNew(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove:
                    this.tblExtFileTypeRecColumn_OnPM_DataRecordRemove(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataRecordNew event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblExtFileTypeRecColumn_OnPM_DataRecordNew(object sender, WindowActionsEventArgs e)
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
        private void tblExtFileTypeRecColumn_OnPM_DataRecordRemove(object sender, WindowActionsEventArgs e)
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

        #region ChildTable-tblExtFileTypeRecColumn
        #region Methods

        /// <summary>
        /// </summary>
        /// <param name="p_sName"></param>
        /// <param name="p_sAttr"></param>
        /// <returns></returns>
        public virtual SalString DecodeValueFromAttr(SalString p_sName, SalString p_sAttr)
        {
            #region Local Variables
            SalArray<SalString> sArray = new SalArray<SalString>();
            SalArray<SalString> sOutput = new SalArray<SalString>();
            SalNumber k = 0;
            SalNumber nNumTokens = 0;
            #endregion

            #region Actions
         
            nNumTokens = p_sAttr.Tokenize("", ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_RS).ToCharacter(), sArray);
            if (nNumTokens == 0)
            {
                return Ifs.Fnd.ApplicationForms.Const.strNULL;
            }
            k = 0;
            while (true)
            {
                sOutput[0] = Ifs.Fnd.ApplicationForms.Const.strNULL;
                sOutput[1] = Ifs.Fnd.ApplicationForms.Const.strNULL;
                nNumTokens = sArray[k].Tokenize("", ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_US).ToCharacter(), sOutput);
                if (nNumTokens == 0)
                {
                    break;
                }
                if (sOutput[0] == p_sName)
                {
                    return sOutput[1];
                }
                k = k + 1;
            }
            return Ifs.Fnd.ApplicationForms.Const.strNULL;
           
            #endregion
        }

        //shhelk - Custom method to avoid code duplication
        protected virtual void CustomDataItemQueryEnabled(WindowActionsEventArgs e)
        {
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
        }
        #endregion

        #region Window Actions

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblExtFileTypeRecColumn_colsFileType_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.tblExtFileTypeRecColumn__colsFileType_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblExtFileTypeRecColumn__colsFileType_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
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
        private void tblExtFileTypeRecColumn_colsGroupId_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.tblExtFileTypeRecColumn_colsGroupId_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblExtFileTypeRecColumn_colsGroupId_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
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
        private void tblExtFileTypeRecColumn_colsColumnId_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLov:
                    this.tblExtFileTypeRecColumn_colsColumnId_OnPM_DataItemLov(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovUserWhere:
                    this.tblExtFileTypeRecColumn_colsColumnId_OnPM_DataItemLovUserWhere(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovDone:
                    this.tblExtFileTypeRecColumn_colsColumnId_OnPM_DataItemLovDone(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.tblExtFileTypeRecColumn_colsColumnId_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemLov event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblExtFileTypeRecColumn_colsColumnId_OnPM_DataItemLov(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire)
            {
                e.Return = this.dfExtFileTypeView_Name.Text != Ifs.Fnd.ApplicationForms.Const.strNULL;
                return;
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemLov, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemLovUserWhere event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblExtFileTypeRecColumn_colsColumnId_OnPM_DataItemLovUserWhere(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.tblExtFileTypeRecColumn_colsDataType.Text == Ifs.Fnd.ApplicationForms.Const.strNULL)
            {
                e.Return = ((SalString)("VIEW_NAME='" + this.dfExtFileTypeView_Name.Text + "'")).ToHandle();
                return;
            }
            else
            {
                e.Return = ((SalString)("VIEW_NAME = '" + this.dfExtFileTypeView_Name.Text + "' and DATA_TYPE = '" + this.tblExtFileTypeRecColumn_colsDataType.Text + "'")).ToHandle();
                return;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemLovDone event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblExtFileTypeRecColumn_colsColumnId_OnPM_DataItemLovDone(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.tblExtFileTypeRecColumn_colsColumnId.Text = this.DecodeValueFromAttr("COLUMN_ID", SalString.FromHandle(Sys.lParam));
            this.tblExtFileTypeRecColumn_colsColumnId.EditDataItemSetEdited();
            this.tblExtFileTypeRecColumn_colsDescription.Text = this.DecodeValueFromAttr("DESCRIPTION", SalString.FromHandle(Sys.lParam));
            this.tblExtFileTypeRecColumn_colsDescription.EditDataItemSetEdited();
            this.tblExtFileTypeRecColumn_colsDataType.Text = this.DecodeValueFromAttr("DATA_TYPE", SalString.FromHandle(Sys.lParam));
            this.tblExtFileTypeRecColumn_colsDataType.EditDataItemSetEdited();
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblExtFileTypeRecColumn_colsColumnId_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
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
        private void tblExtFileTypeRecColumn_colsDescription_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.tblExtFileTypeRecColumn_colsDescription_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblExtFileTypeRecColumn_colsDescription_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
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
        private void tblExtFileTypeRecColumn_colsMandatory_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.tblExtFileTypeRecColumn_colsMandatory_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblExtFileTypeRecColumn_colsMandatory_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
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
        private void tblExtFileTypeRecColumn_colsDataType_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.tblExtFileTypeRecColumn_colsDataType_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblExtFileTypeRecColumn_colsDataType_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
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
        private void tblExtFileTypeRecColumn_colsDestinationColumn_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_Validate:
                    this.tblExtFileTypeRecColumn_colsDestinationColumn_OnSAM_Validate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.tblExtFileTypeRecColumn_colsDestinationColumn_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_Validate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblExtFileTypeRecColumn_colsDestinationColumn_OnSAM_Validate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.sDestinationColumn = this.tblExtFileTypeRecColumn_colsDestinationColumn.Text;
            this.sDateType = this.tblExtFileTypeRecColumn_colsDataType.Text;

            if (!(DbPLSQLBlock("&AO.External_File_Utility_API.Get_Datatype({0} IN, {1} INOUT)", 
                                                this.QualifiedVarBindName("sDestinationColumn"),
                                                this.QualifiedVarBindName("sDateType") )))         
            {
                e.Return = false;
                return;
            }
          
            this.tblExtFileTypeRecColumn_colsDataType.Text = this.sDateType;
            this.tblExtFileTypeRecColumn_colsDataType.EditDataItemSetEdited();
            e.Return = true;
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblExtFileTypeRecColumn_colsDestinationColumn_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            CustomDataItemQueryEnabled(e);
            #endregion
        }
        #endregion
        #endregion

        #region Event Handlers

        private void menuItem__External_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
           ((FndCommand)sender).Enabled = UM_ExtRowDef(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
            
        }

        private void menuItem__External_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            
            UM_ExtRowDef(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        #endregion

    }
}
