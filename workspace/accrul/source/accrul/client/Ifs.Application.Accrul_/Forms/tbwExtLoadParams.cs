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
    [FndWindowRegistration("EXT_LOAD_INFO", "ExtLoadInfo", FndWindowRegistrationFlags.HomePage)]
    public partial class tbwExtLoadParams : cTableWindowFin
    {
        #region Window Variables
        public SalArray<SalString> sPlaceHolders = new SalArray<SalString>();
        public SalString lsTemp = "";
        public SalArray<SalString> sParams = new SalArray<SalString>(1);
        public SalNumber nRow = 0;
        public SalArray<SalString> sItemNames = new SalArray<SalString>();
        public SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
        public SalString sResults = "";
        public SalString sUserIdPrv = "";
        public SalString sUserGroupPrv = "";
        public SalString sUserId = "";
        public SalString sUserGroup = "";
        public SalString sPAttr = "";
        // Bug 102564, begin
        public SalString sExistQVoucher = "";
        // Bug 102564, end
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public tbwExtLoadParams()
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
        public new static tbwExtLoadParams FromHandle(SalWindowHandle handle)
        {
            return ((tbwExtLoadParams)SalWindow.FromHandle(handle, typeof(tbwExtLoadParams)));
        }
        #endregion

        #region Methods

        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalNumber CheckTrans(SalNumber nWhat)
        {
            #region Local Variables
            SalArray<SalString> sItemNames = new SalArray<SalString>();
            SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        if (Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("tbwExtTransactions")) && Sal.TblAnyRows(i_hWndSelf, Sys.ROW_Selected, 0))
                        {
                            return true;
                        }
                        return false;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        Sal.WaitCursor(true);
                        sItemNames[0] = "COMPANY";
                        hWndItems[0] = colCompany;
                        sItemNames[1] = "LOAD_ID";
                        hWndItems[1] = colLoadId;
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("LOAD_ID", i_hWndSelf, sItemNames, hWndItems);
                        SessionCreateWindow(Pal.GetActiveInstanceName("tbwExtTransactions"), Sys.hWndMDI);
                        Sal.WaitCursor(false);
                        return true;
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="nWhatInv"></param>
        /// <returns></returns>
        public virtual SalNumber CheckExternalVouchers(SalNumber nWhatInv)
        {
            #region Actions
            using (new SalContext(this))
            {
                switch (nWhatInv)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Ext_Check_API.Check_Transaction__")))
                        {
                            return false;
                        }
                        if (colsExtLoadStateDb.Text == "5")
                        {
                            return false;
                        }
                        if (!(OneLineMarked()))
                        {
                            return false;
                        }
                        return true;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        Sal.WaitCursor(true);
                        using (SignatureHints hints = SignatureHints.NewContext())
                        {
                            hints.Add("Ext_Check_API.Check_Transaction__", System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                            if (!(DbPLSQLTransaction(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "Ext_Check_API.Check_Transaction__(\r\n" +
                                "       :i_hWndFrame.tbwExtLoadParams.lsTemp,\r\n" +
                                "       :i_hWndFrame.tbwExtLoadParams.colCompany,\r\n" +
                                "       :i_hWndFrame.tbwExtLoadParams.colLoadId, 'TRUE')")))
                            {
                                Sal.WaitCursor(false);
                                return false;
                            }
                        }
                        if (!(HandleSqlResult(lsTemp)))
                        {
                            return false;
                        }
                        Sal.SendMsg(i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceRefresh, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                        Sal.WaitCursor(false);
                        break;
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="nWhatInv"></param>
        /// <returns></returns>
        public virtual SalNumber CreateVoucher(SalNumber nWhatInv)
        {
            #region Actions
            using (new SalContext(this))
            {
                switch (nWhatInv)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        if (!(OneLineMarked()))
                        {
                            return false;
                        }
                        if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Ext_Create_API.Create_Voucher")))
                        {
                            return false;
                        }
                        if (colsExtLoadStateDb.Text == "1")
                        {
                            return false;
                        }
                        if (colsExtLoadStateDb.Text == "2")
                        {
                            return false;
                        }
                        if (colsExtLoadStateDb.Text == "5")
                        {
                            return false;
                        }
                        if (colsExtLoadStateDb.Text == "6")
                        {
                            return false;
                        }
                        return true;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        // Bug 102564, begin
                        if (Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_VoucherCreateVoucher, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Warning, Ifs.Fnd.ApplicationForms.Const.QUESTION_YesNo) == Sys.IDYES)
                        {
                            using (SignatureHints hints = SignatureHints.NewContext())
                            {
                                hints.Add("EXT_TRANSACTIONS_API.Check_Exist_Function_Group_Q", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                                DbPLSQLBlock(cSessionManager.c_hSql, " :i_hWndFrame.tbwExtLoadParams.sExistQVoucher := " + cSessionManager.c_sDbPrefix + "EXT_TRANSACTIONS_API.Check_Exist_Function_Group_Q(\r\n" +
                                    "                                                    :i_hWndFrame.tbwExtLoadParams.colCompany,\r\n" +
                                    "                                                    :i_hWndFrame.tbwExtLoadParams.colLoadId ) ");
                            }
                            if (sExistQVoucher == "TRUE")
                            {
                                Ifs.Fnd.ApplicationForms.Int.AlertBox(Ifs.Application.Accrul.Properties.Resources.TEXT_NoAutoTaxTrans, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Warning, Ifs.Fnd.ApplicationForms.Const.WARNING_Ok);
                            }
                            using (SignatureHints hints = SignatureHints.NewContext())
                            {
                                hints.Add("Ext_Create_API.Create_Voucher", System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                                if (!(DbPLSQLTransaction(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "Ext_Create_API.Create_Voucher(\r\n" +
                                    "                                           :i_hWndFrame.tbwExtLoadParams.lsTemp,\r\n" +
                                    "                                           :i_hWndFrame.tbwExtLoadParams.colCompany,\r\n" +
                                    "                                           :i_hWndFrame.tbwExtLoadParams.colLoadId )")))
                                {
                                    Sal.WaitCursor(false);
                                    return false;
                                }
                            }
                            if (!(HandleSqlResult(lsTemp)))
                            {
                                return false;
                            }
                            Sal.SendMsg(i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceRefresh, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                        }
                        return false;
                        // Bug 102564, end
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean OneLineMarked()
        {
            #region Local Variables
            SalNumber nRow = 0;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                nRow = Sys.TBL_MinRow;
                // Bug 96366 Begin
                if (Sal.TblFindNextRow(i_hWndSelf, ref nRow, Sys.ROW_Selected, Sys.ROW_MarkDeleted))
                {
                    if (Sal.TblFindNextRow(i_hWndSelf, ref nRow, Sys.ROW_Selected, Sys.ROW_MarkDeleted))
                    {
                        return true;
                    }
                    return true;
                }
                // Bug 96366 End
                return false;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalNumber RemoveLoads(SalNumber nWhat)
        {
            #region Local Variables
            SalArray<SalString> sPlaceHolders = new SalArray<SalString>();
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        // Bug 96366 Begin
                        if (!(OneLineMarked()))
                        {
                            return false;
                        }
                        // Bug 96366 End
                        if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Ext_Load_Info_API.Complete_Remove")))
                        {
                            return false;
                        }
                        return true;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        sPlaceHolders[0] = colLoadId.Text;
                        if (Ifs.Fnd.ApplicationForms.Int.AlertBoxWithParams(Properties.Resources.TEXT_VoucherRemoveLoad, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Question, (Ifs.Fnd.ApplicationForms.Const.QUESTION_YesNo | Sys.MB_DefButton2), sPlaceHolders) ==
                        Sys.IDYES)
                        {
                            Sal.WaitCursor(true);
                            // Bug 96366 Begin
                            SelectedAllIds(ref sPAttr);
                            using (SignatureHints hints = SignatureHints.NewContext())
                            {
                                hints.Add("Ext_Load_Info_API.Complete_Remove", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                                if (!(DbPLSQLTransaction(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "Ext_Load_Info_API.Complete_Remove(\r\n" +
                                    "                :i_hWndFrame.tbwExtLoadParams.colCompany,\r\n" +
                                    "                :i_hWndFrame.tbwExtLoadParams.sPAttr)")))
                                {
                                    sPAttr = Ifs.Fnd.ApplicationForms.Const.strNULL;
                                    return false;
                                }
                            }
                            Sal.SendMsg(i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                            Sal.WaitCursor(false);
                            sPAttr = Ifs.Fnd.ApplicationForms.Const.strNULL;
                            // Bug 96366 End
                            return true;
                        }
                        break;
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalNumber RemoveError(SalNumber nWhat)
        {
            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        if (!(OneLineMarked()))
                        {
                            return false;
                        }
                        if (colsExtLoadStateDb.Text == "1" || colsExtLoadStateDb.Text == "5")
                        {
                            return false;
                        }
                        if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Ext_Transactions_API.Clear_All_Error")))
                        {
                            return false;
                        }
                        return true;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        if (Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_VoucherRemoveError, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Warning, Ifs.Fnd.ApplicationForms.Const.QUESTION_YesNo) == Sys.IDYES)
                        {
                            Sal.WaitCursor(true);
                            using (SignatureHints hints = SignatureHints.NewContext())
                            {
                                hints.Add("Ext_Transactions_API.Clear_All_Error", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                                if (!(DbPLSQLTransaction(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "Ext_Transactions_API.Clear_All_Error(\r\n" +
                                    "                             :i_hWndFrame.tbwExtLoadParams.colCompany,\r\n" +
                                    "                             :i_hWndFrame.tbwExtLoadParams.colLoadId )")))
                                {
                                    Sal.WaitCursor(false);
                                    DbTransactionClear(cSessionManager.c_hSql);
                                    return false;
                                }
                            }
                            Sal.WaitCursor(false);
                            return true;
                        }
                        break;
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean CheckMarkDelete()
        {
            #region Actions
            using (new SalContext(this))
            {
                sParams[0] = colLoadId.Text;
                if (Ifs.Fnd.ApplicationForms.Int.AlertBoxWithParams(Properties.Resources.TEXT_DeleteExtLoad, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Warning, Ifs.Fnd.ApplicationForms.Const.WARNING_OkCancel, sParams) == Sys.IDOK)
                {
                    nRow = Sys.TBL_MinRow;
                    if (Sal.TblFindNextRow(i_hWndFrame, ref nRow, Sys.ROW_MarkDeleted, 0))
                    {
                        return false;
                    }
                    return true;
                }
                else
                {
                    Sal.SendMsg(i_hWndFrame, Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRefresh, Sys.wParam, Sys.lParam);
                    return false;
                }
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="p_nWhat"></param>
        /// <returns></returns>
        public virtual SalBoolean UM_ExtFileTrans(SalNumber p_nWhat)
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
                        if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsViewAvailable("EXT_FILE_LOAD")))
                        {
                            return false;
                        }
                        if (colnLoadFileId.Number.ToString(0) == Ifs.Fnd.ApplicationForms.Const.strNULL)
                        {
                            return false;
                        }
                        return Sal.TblAnyRows(i_hWndFrame, Sys.ROW_Selected, 0);

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        Sal.WaitCursor(true);
                        sItemNames[0] = "LOAD_FILE_ID";
                        hWndItems[0] = colnLoadFileId;
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("LOAD_FILE_ID", i_hWndSelf, sItemNames, hWndItems);
                        SessionCreateWindow(Pal.GetActiveInstanceName("frmExternalFileTransactions"), Sys.hWndMDI);
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
        public virtual SalBoolean CheckValidations()
        {
            #region Actions
            using (new SalContext(this))
            {
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("EXT_TRANSACTIONS_API.Check_Condition", System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                    if (DbPLSQLBlock(cSessionManager.c_hSql, "&AO.EXT_TRANSACTIONS_API.Check_Condition(\r\n" +
                        "                                           :i_hWndFrame.tbwExtLoadParams.sResults,\r\n" +
                        "                                           :i_hWndFrame.tbwExtLoadParams.sUserIdPrv,\r\n" +
                        "                                           :i_hWndFrame.tbwExtLoadParams.sUserGroupPrv,\r\n" +
                        "                                           :i_hWndFrame.tbwExtLoadParams.sUserId,\r\n" +
                        "                                           :i_hWndFrame.tbwExtLoadParams.sUserGroup,\r\n" +
                        "                                           :i_hWndFrame.tbwExtLoadParams.colCompany,\r\n" +
                        "                                           :i_hWndFrame.tbwExtLoadParams.colLoadId  )"))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="nWhatInv"></param>
        /// <returns></returns>
        public virtual SalBoolean MainCheckExternalVouchers(SalNumber nWhatInv)
        {
            #region Actions
            using (new SalContext(this))
            {
                switch (nWhatInv)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        return CheckExternalVouchers(nWhatInv);

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        if (CheckValidations())
                        {
                            if (sResults == "TRUE")
                            {
                                if (dlgExtNewUserData.ModalDialog(Ifs.Fnd.ApplicationForms.Int.Explorer.ExplorerForm, colCompany.Text, colLoadId.Text, ref sUserId, ref sUserGroup, sUserIdPrv, sUserGroupPrv) == Sys.IDOK)
                                {
                                    return CheckExternalVouchers(nWhatInv);
                                }
                                else
                                {
                                    return true;
                                }
                            }
                            else
                            {
                                return CheckExternalVouchers(nWhatInv);
                            }
                        }
                        return true;
                }
            }

            return false;
            #endregion
        }
        // Bug 96366 Begin
        /// <summary>
        /// Get the selected load_ids
        /// </summary>
        /// <param name="sPAttrTmp"></param>
        /// <returns></returns>
        public virtual SalNumber SelectedAllIds(ref SalString sPAttrTmp)
        {
            #region Local Variables
            SalNumber nRow = 0;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                nRow = Sys.TBL_MinRow;
                while (Sal.TblFindNextRow(i_hWndFrame, ref nRow, Sys.ROW_Selected, 0))
                {
                    Sal.TblSetContext(i_hWndFrame, nRow);
                    sPAttrTmp = sPAttrTmp + "LOAD_FILE_ID" + ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_US).ToCharacter() + colnLoadFileId.Number.ToString(0) + ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_RS).ToCharacter();
                    sPAttrTmp = sPAttrTmp + "LOAD_ID" + ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_US).ToCharacter() + colLoadId.Text + ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_RS).ToCharacter();
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
        private void tbwExtLoadParams_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove:
                    this.tbwExtLoadParams_OnPM_DataRecordRemove(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRefresh:
                    e.Handled = true;
                    e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRefresh, Sys.wParam, Sys.lParam);
                    return;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataRecordRemove event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwExtLoadParams_OnPM_DataRecordRemove(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                if (this.CheckMarkDelete())
                {
                    e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove, Sys.wParam, Sys.lParam);
                    return;
                }
                else
                {
                    e.Return = false;
                    return;
                }
            }
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire)
            {
                e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove, Sys.wParam, Sys.lParam);
                return;
            }
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colVoucherType_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom:
                    this.colVoucherType_OnPM_DataItemZoom(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemZoom event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colVoucherType_OnPM_DataItemZoom(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                this.sItemNames[0] = "COMPANY";
                this.hWndItems[0] = this.colCompany;
                this.sItemNames[1] = "VOUCHER_TYPE";
                this.hWndItems[1] = this.colVoucherType;
                Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("VoucherTypeDetail", this, this.sItemNames, this.hWndItems);
                SessionNavigate(Pal.GetActiveInstanceName("tbwQueryVoucherType"));
                e.Return = true;
                return;
            }
            else
            {
                e.Return = true;
                return;
            }
            #endregion
        }
        #endregion

        #region Late Bind Methods
        #endregion

        #region Event Handlers

        private void menuItem_Show_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = CheckTrans(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem_Show_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            CheckTrans(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem__Change_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Sys.lParam);
        }

        private void menuItem__Change_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Sys.lParam);
        }

        private void menuItem_Show_1_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = CheckTrans(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem_Show_1_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            CheckTrans(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem_Remove_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = RemoveLoads(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem_Remove_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            RemoveLoads(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem_Remove_1_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = RemoveError(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem_Remove_1_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            RemoveError(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem_External_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = UM_ExtFileTrans(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem_External_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            UM_ExtFileTrans(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem_Check_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = MainCheckExternalVouchers(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem_Check_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            MainCheckExternalVouchers(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem_Create_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = CreateVoucher(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem_Create_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            CreateVoucher(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem__Change_1_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Sys.lParam);
        }

        private void menuItem__Change_1_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Sys.lParam);
        }

        #endregion

    }
}
