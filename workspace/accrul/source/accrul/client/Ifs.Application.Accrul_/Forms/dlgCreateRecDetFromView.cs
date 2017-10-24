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
using PPJ.Runtime;
using PPJ.Runtime.Sql;
using PPJ.Runtime.Windows;

namespace Ifs.Application.Accrul_
{

    /// <summary>
    /// </summary>
    /// <param name="sFileType"></param>
    /// <param name="sComponent"></param>
    /// <param name="sRecordTypeId"></param>
    public partial class dlgCreateRecDetFromView : cDialogBox
    {
        #region Window Parameters
        public SalString sFileType;
        public SalString sComponent;
        public SalString sRecordTypeId;
        #endregion

        #region Window Variables
        public SalWindowHandle hWndLovField = SalWindowHandle.Null;
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        protected dlgCreateRecDetFromView()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();
        }
        #endregion

        #region System Methods/Properties

        /// <summary>
        /// Shows the modal dialog.
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        public static SalNumber ModalDialog(Control owner, SalString sFileType, SalString sComponent, SalString sRecordTypeId)
        {
            dlgCreateRecDetFromView dlg = DialogFactory.CreateInstance<dlgCreateRecDetFromView>();
            dlg.sFileType = sFileType;
            dlg.sComponent = sComponent;
            dlg.sRecordTypeId = sRecordTypeId;
            SalNumber ret = dlg.ShowDialog(owner);
            return ret;
        }

        /// <summary>
        /// Returns the object instance associated with the window handle.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public new static dlgCreateRecDetFromView FromHandle(SalWindowHandle handle)
        {
            return ((dlgCreateRecDetFromView)SalWindow.FromHandle(handle, typeof(dlgCreateRecDetFromView)));
        }
        #endregion

        #region Methods

        /// <summary>
        /// </summary>
        /// <param name="nWhatInv"></param>
        /// <returns></returns>
        public virtual SalNumber CopyViewDefinition(SalNumber nWhatInv)
        {
            #region Actions
            using (new SalContext(this))
            {
                switch (nWhatInv)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        if (dfsViewName1.Text == Ifs.Fnd.ApplicationForms.Const.strNULL)
                        {
                            return false;
                        }
                        return true;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        // Bug 70517, Begin. Passed component to method.
                        using (SignatureHints hints = SignatureHints.NewContext())
                        {
                            hints.Add("External_File_Utility_API.Create_Rec_Det_From_View", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                            if (!(DbPLSQLTransaction(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "External_File_Utility_API.Create_Rec_Det_From_View(\r\n" +
                                "                  :i_hWndFrame.dlgCreateRecDetFromView.dfFileType,\r\n" +
                                "                  :i_hWndFrame.dlgCreateRecDetFromView.dfsViewName1,\r\n" +
                                "                  :i_hWndFrame.dlgCreateRecDetFromView.dfsInputPackage,\r\n" +
                                "                  :i_hWndFrame.dlgCreateRecDetFromView.dfRecordTypeId,\r\n" +
                                "	  :i_hWndFrame.dlgCreateRecDetFromView.dfsComponent )")))
                            {
                                return false;
                            }
                        }
                        // Bug 70517, End.
                        return true;
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="nWhatInv"></param>
        /// <param name="sAction"></param>
        /// <returns></returns>
        public new SalNumber UserMethod(SalNumber nWhatInv, SalString sAction)
        {
            #region Actions
            using (new SalContext(this))
            {
                if (sAction == "OKButton")
                {
                    switch (nWhatInv)
                    {
                        case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                            if (dfsViewName1.Text != Ifs.Fnd.ApplicationForms.Const.strNULL && dfFileType.Text != Ifs.Fnd.ApplicationForms.Const.strNULL && dfsDescriptionTo.Text != Ifs.Fnd.ApplicationForms.Const.strNULL)
                            {
                                return true;
                            }
                            return false;

                        case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                            // Bug 70517, Begin. Removed Else condition.
                            if (CopyViewDefinition(nWhatInv))
                            {
                                Sal.EndDialog(i_hWndFrame, Sys.IDOK);
                            }
                            // Bug 70517, End.
                            return false;
                    }
                }
                if (sAction == "CancelButton")
                {
                    switch (nWhatInv)
                    {
                        case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                            return true;

                        case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                            Sal.EndDialog(i_hWndFrame, Sys.IDCANCEL);
                            break;
                    }
                }
                if (sAction == "ListButton")
                {
                    switch (nWhatInv)
                    {
                        case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                            if (hWndLovField != SalWindowHandle.Null)
                            {
                                return true;
                            }
                            goto case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute;

                        case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                            if (hWndLovField != SalWindowHandle.Null)
                            {
                                if (Sal.SendMsg(hWndLovField, Ifs.Fnd.ApplicationForms.Const.PM_DataItemLov, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0))
                                {
                                    Sal.SetFocus(hWndLovField);
                                    Sal.SendMsg(hWndLovField, Sys.SAM_Validate, 0, 0);
                                }
                                else
                                {
                                    Sal.SetFocus(hWndLovField);
                                }
                            }
                            break;
                    }
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
            return true;
        }
        #endregion

        #region Window Actions

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void dlgCreateRecDetFromView_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_Create:
                    this.dlgCreateRecDetFromView_OnSAM_Create(sender, e);
                    break;

                case Sys.SAM_CreateComplete:
                    this.dlgCreateRecDetFromView_OnSAM_CreateComplete(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_Create event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dlgCreateRecDetFromView_OnSAM_Create(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam);
            Sal.CenterWindow(this.i_hWndFrame);
            #endregion
        }

        /// <summary>
        /// SAM_CreateComplete event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dlgCreateRecDetFromView_OnSAM_CreateComplete(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Sys.SAM_CreateComplete, Sys.wParam, Sys.lParam))
            {
                this.dfFileType.Text = this.sFileType;
                this.dfRecordTypeId.Text = this.sRecordTypeId;
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("Ext_File_Type_API.Get_Description", System.Data.ParameterDirection.Input);
                    if (!(this.DbPLSQLBlock(cSessionManager.c_hSql, ":i_hWndFrame.dlgCreateRecDetFromView.dfsDescriptionTo :=  " + cSessionManager.c_sDbPrefix + "Ext_File_Type_API.Get_Description(\r\n" +
                        ":i_hWndFrame.dlgCreateRecDetFromView.dfFileType)")))
                    {
                        e.Return = false;
                        return;
                    }
                }
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("Ext_File_Type_Rec_API.Get_Description", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                    if (!(this.DbPLSQLBlock(cSessionManager.c_hSql, ":i_hWndFrame.dlgCreateRecDetFromView.dfsRecDescriptionTo :=  " + cSessionManager.c_sDbPrefix + "Ext_File_Type_Rec_API.Get_Description(\r\n" +
                        ":i_hWndFrame.dlgCreateRecDetFromView.dfFileType, :i_hWndFrame.dlgCreateRecDetFromView.dfRecordTypeId)")))
                    {
                        e.Return = false;
                        return;
                    }
                }
                Sal.EnableWindow(this.pbList);
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
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovUserOrderBy:
                    e.Handled = true;
                    e.Return = ((SalString)"NAME").ToHandle();
                    return;

                case Sys.SAM_SetFocus:
                    this.dfsComponent_OnSAM_SetFocus(sender, e);
                    break;

                case Sys.SAM_KillFocus:
                    this.dfsComponent_OnSAM_KillFocus(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsComponent_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam))
            {
                if (this.dfsComponent.p_sLovReference != Ifs.Fnd.ApplicationForms.Const.strNULL)
                {
                    this.hWndLovField = this.dfsComponent.i_hWndSelf;
                    cObjectRelationManager.__bLOV = false;
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
        /// SAM_KillFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsComponent_OnSAM_KillFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam.ToWindowHandle() != this.pbList.i_hWndSelf)
            {
                this.hWndLovField = SalWindowHandle.Null;
                this.pbList.MethodInvestigateState();
            }
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void dfsViewName1_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.dfsViewName1_OnPM_DataItemValidate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovUserWhere:
                    this.dfsViewName1_OnPM_DataItemLovUserWhere(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovUserOrderBy:
                    e.Handled = true;
                    e.Return = ((SalString)"VIEW_NAME").ToHandle();
                    return;

                case Sys.SAM_SetFocus:
                    this.dfsViewName1_OnSAM_SetFocus(sender, e);
                    break;

                case Sys.SAM_KillFocus:
                    this.dfsViewName1_OnSAM_KillFocus(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsViewName1_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
            if (this.dfsViewName1.Text != Ifs.Fnd.ApplicationForms.Const.strNULL)
            {
                if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsViewAvailable(this.dfsViewName1.Text)))
                {
                    Ifs.Fnd.ApplicationForms.Int.AlertBox(Ifs.Application.Accrul.Properties.Resources.TEXT_NotValidView, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                    this.dfsViewName1.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                    this.pbOk.MethodInvestigateState();
                    e.Return = Sys.VALIDATE_Cancel;
                    return;
                }
                else
                {
                    using (SignatureHints hints = SignatureHints.NewContext())
                    {
                        hints.Add("External_File_Utility_API.Get_Input_Package", System.Data.ParameterDirection.Input);
                        if (!(this.dfsViewName1.DbPLSQLBlock(cSessionManager.c_hSql, ":i_hWndFrame.dlgCreateRecDetFromView.dfsInputPackage :=  " + cSessionManager.c_sDbPrefix + "External_File_Utility_API.Get_Input_Package(:i_hWndFrame.dlgCreateRecDetFromView.dfsViewName1)")))
                        {
                            this.dfsInputPackage.Text = Sys.STRING_Null;
                            this.dfsInputPackage.EditDataItemSetEdited();
                            e.Return = Sys.VALIDATE_Ok;
                            return;
                        }
                        else
                        {
                            if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable(this.dfsInputPackage.Text)))
                            {
                                Ifs.Fnd.ApplicationForms.Int.AlertBox(Ifs.Application.Accrul.Properties.Resources.TEXT_NotValidPackage, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                                this.dfsInputPackage.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                            }
                            this.dfsInputPackage.EditDataItemSetEdited();
                        }
                    }
                }
            }
            // Bug 92394 Begin
            if (this.dfRecordTypeId.Text == Ifs.Fnd.ApplicationForms.Const.strNULL)
            {
                Sal.DisableWindow(this.pbOk);
            }
            else
            {
                // Bug 70517, Begin
                this.pbOk.MethodInvestigateState();
            }
            // Bug 92394 End
            e.Return = Sys.VALIDATE_Ok;
            return;
            // Bug 70517, End
            #endregion
        }

        /// <summary>
        /// PM_DataItemLovUserWhere event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsViewName1_OnPM_DataItemLovUserWhere(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.dfsComponent.Text != Ifs.Fnd.ApplicationForms.Const.strNULL)
            {
                e.Return = ((SalString)("COMPONENT = '" + this.dfsComponent.Text + "'")).ToHandle();
                return;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsViewName1_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam))
            {
                if (this.dfsComponent.Text != Ifs.Fnd.ApplicationForms.Const.strNULL)
                {
                    if (this.dfsViewName1.p_sLovReference != Ifs.Fnd.ApplicationForms.Const.strNULL)
                    {
                        this.hWndLovField = this.dfsViewName1.i_hWndSelf;
                        cObjectRelationManager.__bLOV = false;
                    }
                    else
                    {
                        this.hWndLovField = SalWindowHandle.Null;
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
        /// SAM_KillFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsViewName1_OnSAM_KillFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam.ToWindowHandle() != this.pbList.i_hWndSelf)
            {
                this.hWndLovField = SalWindowHandle.Null;
                this.pbList.MethodInvestigateState();
            }
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
        public override SalNumber vrtUserMethod(SalNumber nWhat, SalString sMethod)
        {
            return this.UserMethod(nWhat, sMethod);
        }
        #endregion
    }
}
