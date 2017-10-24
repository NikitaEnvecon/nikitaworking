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
// Date    By      Notes
// ------  ------  -------------------------------------------------------------------------------------
// 150217  PKurlk  PRFI-5570, Modified the 1st parameter of dlgInstantUpdate.ModalDialog().
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
    [FndWindowRegistration("VOUCHER_APPROVAL", "Voucher")]
    public partial class tbwVoucherApproval : cTableWindowFin
    {
        #region Window Variables
        public SalString lsTemp = "";
        public SalArray<SalNumber> nVouNo = new SalArray<SalNumber>();
        public SalArray<SalString> sVouType = new SalArray<SalString>();
        public SalString sUserGroup = "";
        public SalNumber nAppVou = 0;
        public SalArray<SalNumber> nAccountingYear = new SalArray<SalNumber>();
        public SalDateTime dtVoucherDate = SalDateTime.Null;
        public SalBoolean bApproved = false;
        public SalString sApp = "";
        public SalString sAllInfo = "";
        public SalSqlHandle hSql = SalSqlHandle.Null;
        public SalNumber nNoErr = 0;
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public tbwVoucherApproval()
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
        public new static tbwVoucherApproval FromHandle(SalWindowHandle handle)
        {
            return ((tbwVoucherApproval)SalWindow.FromHandle(handle, typeof(tbwVoucherApproval)));
        }
        #endregion

        #region Methods

        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalNumber Voucher(SalNumber nWhat)
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
                        return Sal.TblAnyRows(this, Sys.ROW_Selected, 0);

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        Sal.WaitCursor(true);
                        sItemNames[0] = "VOUCHER_TYPE";
                        hWndItems[0] = colsVoucherType;
                        sItemNames[1] = "VOUCHER_NO";
                        hWndItems[1] = colnVoucherNo;
                        sItemNames[2] = "ACCOUNTING_YEAR";
                        hWndItems[2] = colnAccountingYear;
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("VOUCHER_APPROVAL", this, sItemNames, hWndItems);
                        SessionCreateWindow(Pal.GetActiveInstanceName("frmEntryVoucher"), Sys.hWndMDI);
                        Sal.WaitCursor(false);
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
        public virtual SalBoolean VoucherApproval(SalNumber nWhat)
        {
            #region Local Variables
            SalString sTempParam = "";
            SalNumber nRow = 0;
            SalBoolean bApproveDone = false;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        // Bug 86488 Begin
                        if ((!(Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("dlgInstantUpdate")))) || (!(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Voucher_API.Approve_Voucher__"))))
                        {
                            return false;
                        }
                        // Bug 86488 End
                        return Sal.TblAnyRows(this, Sys.ROW_Selected, 0);

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        nRow = Sys.TBL_MinRow;
                        sTempParam = Ifs.Fnd.ApplicationForms.Const.strNULL;
                        nAppVou = 0;
                        nNoErr = 0;
                        bApproved = false;
                        while (Sal.TblFindNextRow(i_hWndSelf, ref nRow, Sys.ROW_Selected, 0))
                        {
                            Sal.TblSetContext(i_hWndSelf, nRow);
                            if (colAmount.Number != 0)
                            {
                                sTempParam = sTempParam + SalString.FromHandle(Sal.SendMsg(colnVoucherNo, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueGet, 0, 0)) + " ,";
                                Sal.TblSetRowFlags(i_hWndSelf, nRow, Sys.ROW_Selected, false);
                            }
                            else
                            {
                                nVouNo[nAppVou] = colnVoucherNo.Number;
                                sVouType[nAppVou] = colsVoucherType.Text;
                                nAccountingYear[nAppVou] = colnAccountingYear.Number;
                                nAppVou = nAppVou + 1;
                                // Did  not remove substr below beacuse the particular usage requires the function
                                using (SignatureHints hints = SignatureHints.NewContext())
                                {
                                    hints.Add("Voucher_API.Approve_Voucher__", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                                    bApproveDone = DbPLSQLTransaction(cSessionManager.c_hSql, "\r\n" +
                                        "				&AO.Voucher_API.Approve_Voucher__(\r\n" +
                                        "						:i_hWndFrame.tbwVoucherApproval.colsCompany ,\r\n" +
                                        "						:i_hWndFrame.tbwVoucherApproval.colnAccountingYear ,\r\n" +
                                        "						:i_hWndFrame.tbwVoucherApproval.colsVoucherType ,\r\n" +
                                        "						:i_hWndFrame.tbwVoucherApproval.colnVoucherNo ,\r\n" +
                                        "						:i_hWndFrame.tbwVoucherApproval.cmbUserGroup);\r\n" +
                                        "				:i_hWndFrame.tbwVoucherApproval.sAllInfo :=&AO.CLIENT_SYS.Get_All_Info;\r\n" +
                                        "				&AO.Client_SYS.clear_Info\r\n			");
                                }
                                sApp = sAllInfo.Mid(5, 1);
                                bApproved = true;
                                if (sApp == "N" || bApproveDone == 0)
                                {
                                    bApproved = false;
                                }
                            }
                        }
                        if (sTempParam != Ifs.Fnd.ApplicationForms.Const.strNULL)
                        {
                            Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_VouNotBal, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
                        }
                        if (bApproved == true && nAppVou > 0)
                        {
                            if (Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_VouUpdate, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Question, (Ifs.Fnd.ApplicationForms.Const.QUESTION_YesNo | Sys.MB_DefButton2)) == Sys.IDYES)
                            {
                                return InstantUpdate();
                            }
                            else
                            {
                                return Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Sys.wParam, 0);
                            }
                        }
                        if (sApp == "N")
                        {
                            Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_NotAppAddManPost, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
                        }
                        return true;
                }
            }

            return false;
            #endregion
        }
        // Bug 77430, Begin, changed the return type to boolean
        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalBoolean FreeText(SalNumber nWhat)
        {
            #region Local Variables
            // Bug 77430, Begin, added some variables
            SalString sRS = "";
            SalString sKeyAttr = "";
            SalString sPackageName = "";
            SalArray<SalString> sVoucherNotes = new SalArray<SalString>();
            // Bug 77430, End
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    // Bug 77430, Begin, changed the condition

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        return Sal.TblAnyRows(this, Sys.ROW_Selected, 0);

                    // Bug 77430, End

                    // Bug 77430, Begin, changed the METHOD_Execute

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        sRS = ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_RS).ToCharacter();
                        sPackageName = "VOUCHER_NOTE_API";
                        Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("COMPANY", colsCompany.Text, ref sKeyAttr);
                        Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("ACCOUNTING_YEAR", colnAccountingYear.Number.ToString(0), ref sKeyAttr);
                        Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("VOUCHER_TYPE", colsVoucherType.Text, ref sKeyAttr);
                        Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("VOUCHER_NO", colnVoucherNo.Number.ToString(0), ref sKeyAttr);
                        // ! ! Construct a string containing the Package Name, Window Title and the keys as an attribute string.
                        sVoucherNotes[0] = sPackageName + sRS + Ifs.Application.Accrul.Properties.Resources.USER_Voucher_Notes + sRS + sKeyAttr;
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.SourceNameSet("NotesData");
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemAdd("NotesData", sVoucherNotes);
                        dlgNotes.ModalDialog(Ifs.Fnd.ApplicationForms.Int.Explorer.ExplorerForm);
                        Sal.SendMsg(i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRefresh, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                        return true;

                    // Bug 77430, End
                }
            }

            return false;
            #endregion
        }
        // Bug 77430, End
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean InstantUpdate()
        {
            #region Actions
            using (new SalContext(this))
            {
                if (dlgInstantUpdate.ModalDialog(Ifs.Fnd.ApplicationForms.Int.Explorer.ExplorerForm, i_sCompany, nVouNo, sVouType, nAccountingYear, nAppVou) == Sys.IDOK)
                {
                    i_lsUserWhere = DataSourceUserWhereGet();
                }
                return Sal.SendMsg(i_hWndFrame, Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Ifs.Fnd.ApplicationForms.Const.POPULATE_Single);
            }
            #endregion
        }
        // Bug 78024, Begin
        /// <summary>
        /// </summary>
        /// <param name="sWindowName">
        /// Window name
        /// Intendend receiver window of the data transfer. When overriding DataSourcePrepareKeyTransfer,
        /// applications can use this parameter to initialize data transfer in different ways for
        /// different receiver windows.
        /// </param>
        /// <returns></returns>
        public new SalNumber DataSourcePrepareKeyTransfer(SalString sWindowName)
        {
            #region Local Variables
            SalString sSourceName = "";
            SalWindowHandle hWndSource = SalWindowHandle.Null;
            SalArray<SalString> sItemNames = new SalArray<SalString>();
            SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                sSourceName = p_sLogicalUnit;
                hWndSource = i_hWndSelf;
                if (sWindowName == Pal.GetActiveInstanceName("frmObjectConnection"))
                {
                    sItemNames[0] = "ACCOUNTING_YEAR";
                    sItemNames[1] = "COMPANY";
                    sItemNames[2] = "VOUCHER_NO";
                    sItemNames[3] = "VOUCHER_TYPE";
                    hWndItems[0] = tbwVoucherApproval.FromHandle(i_hWndFrame).colnAccountingYear;
                    hWndItems[1] = tbwVoucherApproval.FromHandle(i_hWndFrame).colsCompany;
                    hWndItems[2] = tbwVoucherApproval.FromHandle(i_hWndFrame).colnVoucherNo;
                    hWndItems[3] = tbwVoucherApproval.FromHandle(i_hWndFrame).colsVoucherType;
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init(sSourceName, hWndSource, sItemNames, hWndItems);
                    return Ifs.Fnd.ApplicationForms.Var.DataTransfer.TypeSet("CREATE_WINDOW");
                }
                return ((cTableWindowFin)this).DataSourcePrepareKeyTransfer(sWindowName);
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
        private void tbwVoucherApproval_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_CreateComplete:
                    this.tbwVoucherApproval_OnSAM_CreateComplete(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_UserProfileChanged:
                    this.tbwVoucherApproval_OnPM_UserProfileChanged(sender, e);
                    break;

                case Const.PAM_GetUserGroup:
                    e.Handled = true;
                    e.Return = ((SalString)this.cmbUserGroup.Text).ToHandle();
                    return;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceQueryFieldName:
                    this.tbwVoucherApproval_OnPM_DataSourceQueryFieldName(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_CreateComplete event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwVoucherApproval_OnSAM_CreateComplete(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Sys.SAM_CreateComplete, Sys.wParam, Sys.lParam))
            {
                this.dfUserId.Text = Ifs.Fnd.ApplicationForms.Int.FndUser();
                e.Return = true;
                return;
            }
            e.Return = false;
            return;
            #endregion
        }

        /// <summary>
        /// PM_UserProfileChanged event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwVoucherApproval_OnPM_UserProfileChanged(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_UserProfileChanged, Sys.wParam, Sys.lParam))
            {
                this.dfUserId.Text = Ifs.Fnd.ApplicationForms.Int.FndUser();
                this.DbListPopulate(this.cmbUserGroup, cSessionManager.c_hSql, "SELECT USER_GROUP from " + cSessionManager.c_sDbPrefix + "user_group_member_finance WHERE company = :i_hWndFrame.tbwVoucherApproval.i_sCompany AND userid=:i_hWndFrame.tbwVoucherApproval.dfUserId");
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("User_Group_Member_Finance_Api.get_default_group", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                    this.DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN \r\n" +
                        "				:i_hWndFrame.tbwVoucherApproval.sUserGroup := " + cSessionManager.c_sDbPrefix + "User_Group_Member_Finance_Api.get_default_group(:i_hWndFrame.tbwVoucherApproval.i_sCompany,:i_hWndFrame.tbwVoucherApproval.dfUserId);\r\n" +
                        "				:i_hWndFrame.tbwVoucherApproval.dtVoucherDate := SYSDATE;\r\n" +
                        "			   END;");
                }
                Sal.SetWindowText(this.cmbUserGroup, this.sUserGroup);
                e.Return = true;
                return;
            }
            e.Return = false;
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataSourceQueryFieldName event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwVoucherApproval_OnPM_DataSourceQueryFieldName(object sender, WindowActionsEventArgs e)
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
                        e.Return = (this.i_hWndFrame.ToNumber().ToString(0) + ".tbwVoucherApproval.i_sCompany").ToHandle();
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

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colsFreeText_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_DoubleClick:
                    this.colsFreeText_OnSAM_DoubleClick(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_DoubleClick event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colsFreeText_OnSAM_DoubleClick(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (FreeText(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire))
            {
                FreeText(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
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
        private void cmbUserGroup_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_Click:
                    this.cmbUserGroup_OnSAM_Click(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_Click event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cmbUserGroup_OnSAM_Click(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendMsg(this.cmbUserGroup.i_hWndFrame, Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Sys.lParam);
            this.dfUserId.Text = Ifs.Fnd.ApplicationForms.Int.FndUser();
            this.dfVoucherDate.DateTime = this.dtVoucherDate;
            e.Return = true;
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void dfUserId_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemClear:
                    e.Handled = true;
                    e.Return = true;
                    return;
            }
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void dfVoucherDate_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemPopulate:
                    this.dfVoucherDate_OnPM_DataItemPopulate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemClear:
                    e.Handled = true;
                    e.Return = true;
                    return;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemPopulate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfVoucherDate_OnPM_DataItemPopulate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemPopulate, Sys.wParam, Sys.lParam))
            {
                this.dfVoucherDate.DateTime = this.dtVoucherDate;
                e.Return = true;
                return;
            }
            #endregion
        }
        #endregion

        #region Late Bind Methods

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalNumber vrtDataSourcePrepareKeyTransfer(SalString sWindowName)
        {
            return this.DataSourcePrepareKeyTransfer(sWindowName);
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public override SalNumber vrtActivate(fcURL URL)
        {
            #region Actions
            using (new SalContext(this))
            {
                // from SAM_CreateComplete
                this.DbListPopulate(this.cmbUserGroup, cSessionManager.c_hSql, "SELECT USER_GROUP \r\n" +
                    " FROM  " + cSessionManager.c_sDbPrefix + "USER_GROUP_MEMBER_FINANCE \r\n" +
                    " WHERE  company          = :i_hWndFrame.tbwVoucherApproval.i_sCompany \r\n" +
                    " AND       userid                =:i_hWndFrame.tbwVoucherApproval.dfUserId ");
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("User_Group_Member_Finance_Api.get_default_group", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                    this.DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN \r\n" +
                        "   :i_hWndFrame.tbwVoucherApproval.sUserGroup := " + cSessionManager.c_sDbPrefix + "User_Group_Member_Finance_Api.get_default_group(:i_hWndFrame.tbwVoucherApproval.i_sCompany,:i_hWndFrame.tbwVoucherApproval.dfUserId);\r\n" +
                        "   :i_hWndFrame.tbwVoucherApproval.dtVoucherDate := SYSDATE;\r\n" +
                        "   :i_hWndFrame.tbwVoucherApproval.dfVoucherDate := SYSDATE;\r\n" +
                        " END;");
                }
                Sal.SetWindowText(this.cmbUserGroup, this.sUserGroup);
                return base.Activate(URL);
            }
            #endregion
        }
        #endregion

        #region Event Handlers

        private void menuItem_Voucher_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = Voucher(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem_Voucher_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            Voucher(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem_Approve_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = VoucherApproval(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem_Approve_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            VoucherApproval(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem__Notes_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = FreeText(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem__Notes_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            FreeText(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem_Change_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Sys.lParam);
        }

        private void menuItem_Change_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Sys.lParam);
        }

        #endregion

    }
}
