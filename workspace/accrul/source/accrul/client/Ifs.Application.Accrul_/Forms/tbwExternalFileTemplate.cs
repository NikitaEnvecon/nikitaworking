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
    [FndWindowRegistration("EXT_FILE_TEMPLATE,EXT_FILE_TEMPLATE_LOV2", "ExtFileTemplate", FndWindowRegistrationFlags.HomePage)]
    public partial class tbwExternalFileTemplate : cTableWindowFinBase
    {

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public tbwExternalFileTemplate()
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
        public new static tbwExternalFileTemplate FromHandle(SalWindowHandle handle)
        {
            return ((tbwExternalFileTemplate)SalWindow.FromHandle(handle, typeof(tbwExternalFileTemplate)));
        }
        #endregion

        #region Methods

        /// <summary>
        /// </summary>
        /// <param name="nWhatInv"></param>
        /// <returns></returns>
        public virtual SalNumber CopyFileType(SalNumber nWhatInv)
        {
            #region Local Variables
            SalString sFileTemplateReturn = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                switch (nWhatInv)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        // Bug 76417, Begin, checked for security permission
                        if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("dlgCreateTemplateFromType"))))
                        {
                            return false;
                        }
                        if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("EXTERNAL_FILE_UTILITY_API.Copy_Def_From_File_Type")))
                        {
                            return false;
                        }
                        // Bug 76417, End
                        return true;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        if (dlgCreateTemplateFromType.ModalDialog(Ifs.Fnd.ApplicationForms.Int.Explorer.ExplorerForm, colsFileType.Text, colExtFileTypeDescription.Text, ref sFileTemplateReturn) == Sys.IDOK)
                        {
                            if (sFileTemplateReturn != Ifs.Fnd.ApplicationForms.Const.strNULL)
                            {
                                Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceUserWhere, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, ("FILE_TEMPLATE_ID ='" + sFileTemplateReturn + "'").ToHandle());
                                return Sal.SendMsg(i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Ifs.Fnd.ApplicationForms.Const.POPULATE_NoConfirm);
                            }
                            return true;
                        }
                        return false;
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="p_nWhat"></param>
        /// <returns></returns>
        public virtual SalBoolean Details(SalNumber p_nWhat)
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
                        return true;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        Sal.WaitCursor(true);
                        if (Sal.TblAnyRows(i_hWndSelf, Sys.ROW_Selected, 0))
                        {
                            sItemNames[0] = "FILE_TEMPLATE_ID";
                            hWndItems[0] = colsFileTemplateId;
                            Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("LOAD_ID", i_hWndSelf, sItemNames, hWndItems);
                        }
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
        /// <param name="nWhatInv"></param>
        /// <returns></returns>
        public virtual SalNumber CopyFileDefinition(SalNumber nWhatInv)
        {
            #region Local Variables
            SalString sFileTemplateReturn = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                switch (nWhatInv)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        // Bug 76417, Begin, checked for security permission
                        if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("dlgExtFileCopyFileTemplate"))))
                        {
                            return false;
                        }
                        if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("EXTERNAL_FILE_UTILITY_API.Copy_Def_From_File_Def")))
                        {
                            return false;
                        }
                        // Bug 76417, End
                        return true;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        if (dlgExtFileCopyFileTemplate.ModalDialog(Ifs.Fnd.ApplicationForms.Int.Explorer.ExplorerForm, colsFileType.Text, colsFileTemplateId.Text, colsDescription.Text, colExtFileTypeDescription.Text, ref sFileTemplateReturn) == Sys.IDOK)
                        {
                            if (sFileTemplateReturn != Ifs.Fnd.ApplicationForms.Const.strNULL)
                            {
                                Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceUserWhere, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, ("FILE_TEMPLATE_ID ='" + sFileTemplateReturn + "'").ToHandle());
                                return Sal.SendMsg(i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Ifs.Fnd.ApplicationForms.Const.POPULATE_NoConfirm);
                            }
                            return true;
                        }
                        return false;
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
        private void tbwExternalFileTemplate_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove:
                    this.tbwExternalFileTemplate_OnPM_DataRecordRemove(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataRecordRemove event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwExternalFileTemplate_OnPM_DataRecordRemove(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire)
            {
                if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove, Sys.wParam, Sys.lParam))
                {
                    if (this.colsSystemDefined.Text != "FALSE")
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
        #endregion

        #region Event Handlers

        private void menuItem__Details_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = Details(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem__Details_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            Details(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem_Copy_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = CopyFileDefinition(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem_Copy_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            CopyFileDefinition(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem_Create_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = CopyFileType(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem_Create_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            CopyFileType(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        #endregion

    }
}
