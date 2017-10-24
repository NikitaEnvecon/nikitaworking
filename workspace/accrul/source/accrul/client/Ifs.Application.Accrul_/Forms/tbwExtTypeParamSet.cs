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

using Ifs.Application.Accrul;
using Ifs.Fnd.ApplicationForms;
using Ifs.Fnd.Windows.Forms;
using PPJ.Runtime;
using PPJ.Runtime.Sql;
using PPJ.Runtime.Windows;

namespace Ifs.Application.Accrul_
{

    /// <summary>
    /// </summary>
    public partial class tbwExtTypeParamSet : cTableWindowFin
    {

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public tbwExtTypeParamSet()
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
        public new static tbwExtTypeParamSet FromHandle(SalWindowHandle handle)
        {
            return ((tbwExtTypeParamSet)SalWindow.FromHandle(handle, typeof(tbwExtTypeParamSet)));
        }
        #endregion

        #region Methods

        /// <summary>
        /// </summary>
        /// <param name="p_nWhat"></param>
        /// <returns></returns>
        public virtual SalBoolean UM_ParamPerSet(SalNumber p_nWhat)
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
                        return Sal.TblAnyRows(i_hWndSelf, Sys.ROW_Selected, 0);

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        Sal.WaitCursor(true);
                        sItemNames[0] = "FILE_TYPE";
                        hWndItems[0] = colsFileType;
                        sItemNames[1] = "SET_ID";
                        hWndItems[1] = colsSetId;
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("FILE_TYPE", i_hWndSelf, sItemNames, hWndItems);
                        SessionCreateWindow(Pal.GetActiveInstanceName("frmExternalFileParamSet"), Sys.hWndMDI);
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
        public virtual SalNumber CopyParameters(SalNumber nWhatInv)
        {
            #region Local Variables
            SalArray<SalString> sItemNames = new SalArray<SalString>();
            SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                switch (nWhatInv)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        return Sal.TblAnyRows(i_hWndSelf, Sys.ROW_Selected, 0);

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        using (SignatureHints hints = SignatureHints.NewContext())
                        {
                            hints.Add("Ext_Type_Param_Per_Set_API.Copy_Param_Set", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                            if (!(DbPLSQLTransaction(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "Ext_Type_Param_Per_Set_API.Copy_Param_Set(\r\n" +
                                "                  :i_hWndFrame.tbwExtTypeParamSet.colsFileType,\r\n" +
                                "                  :i_hWndFrame.tbwExtTypeParamSet.colsSetId )")))
                            {
                                return false;
                            }
                        }
                        Sal.SendMsg(i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRefresh, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                        sItemNames[0] = "FILE_TYPE";
                        hWndItems[0] = colsFileType;
                        sItemNames[1] = "SET_ID";
                        hWndItems[1] = colsSetId;
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("FILE_TYPE", i_hWndSelf, sItemNames, hWndItems);
                        SessionCreateWindow(Pal.GetActiveInstanceName("frmExternalFileParamSet"), Sys.hWndMDI);
                        return true;
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
        private void tbwExtTypeParamSet_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove:
                    this.tbwExtTypeParamSet_OnPM_DataRecordRemove(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataRecordRemove event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwExtTypeParamSet_OnPM_DataRecordRemove(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire)
            {
                if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove, Sys.wParam, Sys.lParam))
                {
                    if (this.colsSystemDefined.Text == "TRUE")
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
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colsFileType_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.colsFileType_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colsFileType_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            e.Handled = true;
            if (!i_hWndParent.IsDerivedFromClass(typeof(frmExternalFileParam)))
                return;

            e.Return = (frmExternalFileParam.FromHandle(i_hWndParent).cbSystemDefined.Checked ? Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled : Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldEnabled);
        }
        #endregion

        #region Late Bind Methods
        #endregion

        #region Event Handlers

        private void menuItem_External_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = UM_ParamPerSet(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem_External_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            UM_ParamPerSet(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem_Create_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = CopyParameters(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem_Create_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            CopyParameters(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        #endregion

    }
}
