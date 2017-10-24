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
using Ifs.Application.Appsrv;
using Ifs.Application.Enterp;
using Ifs.Fnd.ApplicationForms;
using PPJ.Runtime;
using PPJ.Runtime.Sql;
using PPJ.Runtime.Vis;
using PPJ.Runtime.Windows;
using PPJ.Runtime.Windows.QO;
using Ifs.Fnd.Windows.Forms;

namespace Ifs.Application.Accrul
{
	
	/// <summary>
	/// </summary>
    [FndWindowRegistration("VOUCHER", "Voucher")]
    [FndWindowRegistration("VOUCHER_ROW", "VoucherRow")]
    public partial class frmQueryVoucherDetail : cFormWindowFin
    {
        #region Window Variables
        public SalArray<SalString> sPlaceHolders = new SalArray<SalString>();
        public SalNumber nRow = 0;
        public SalString sNoteExist = "";
        public cMessage Msg = new cMessage();
        public cMessage tbl_Msg = new cMessage();
        public SalString sOriginalCompany = "";
        public SalString sOriginalVoucherType = "";
        public SalNumber nOriginalAccYear = 0;
        public SalNumber nOriginalVoucherNo = 0;
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public frmQueryVoucherDetail()
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
        public new static frmQueryVoucherDetail FromHandle(SalWindowHandle handle)
        {
            return ((frmQueryVoucherDetail)SalWindow.FromHandle(handle, typeof(frmQueryVoucherDetail)));
        }
        #endregion

        #region Methods

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public new SalBoolean FrameStartupUser()
        {
            #region Actions
            using (new SalContext(this))
            {
                return true;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public new SalString GetWindowTitle()
        {
            #region Actions
            using (new SalContext(this))
            {
                return Properties.Resources.WH_frmQueryVoucherDetail;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalNumber QueryMultiCompanyVoucher(SalNumber nWhat)
        {
            #region Local Variables
            SalArray<SalString> sItemNames = new SalArray<SalString>();			
            SalArray<SalString> sItemValues = new SalArray<SalString>();			
            SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("frmMCQueryVoucherDetail"))))
                        {
                            return 0;
                        }
                        if (cbMultiCompanyId.Checked == true)
                        {
                            if (!(Sal.IsNull(dfMultiCompanyId)))
                            {
                                // Bug 94795, Begin
                                if (ccVoucherType.i_sMyValue != "R")
                                {
                                    return 1;
                                }
                                // Bug 94795, End
                            }
                        }
                        return 0;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        Sal.WaitCursor(true);
                        dfMCId.Text = tblVoucherDetail_colMultiCompanyId.Text;
                        dfVoucherType.Text = ccVoucherType.i_sMyValue;
                        sItemNames[0] = "VOUCHER_TYPE";
                        hWndItems[0] = dfVoucherType;
                        sItemNames[1] = "VOUCHER_NO";
                        hWndItems[1] = dfVoucherNo;
                        sItemNames[2] = "ACCOUNTING_YEAR";
                        hWndItems[2] = dfAccountingYear;
                        sItemNames[3] = "COMPANY";
                        hWndItems[3] = dfCompany;
                        // Bug 94795, Begin
                        if (!(Sal.IsNull(dfMultiCompanyId)) && !(Sal.IsNull(dfVoucherTypeReference)))
                        {
                            // this is the multi-company. use the reference information if no interim voucher is created otherwise take from the method.
                            // row has multi_company id
                            if (!(DbPLSQLBlock(cSessionManager.c_hSql, "&AO.Multi_Company_Voucher_Util_API.Get_Multi_Company_Info( \r\n" +
                                                                   "    :i_hWndFrame.frmQueryVoucherDetail.sOriginalCompany OUT, \r\n" +
                                                                   "    :i_hWndFrame.frmQueryVoucherDetail.nOriginalAccYear OUT, \r\n" +
                                                                   "    :i_hWndFrame.frmQueryVoucherDetail.sOriginalVoucherType OUT, \r\n" +
                                                                   "    :i_hWndFrame.frmQueryVoucherDetail.nOriginalVoucherNo OUT, \r\n" +
                                                                   "    :i_hWndFrame.frmQueryVoucherDetail.dfCompany IN, \r\n" +
                                                                   "    :i_hWndFrame.frmQueryVoucherDetail.dfAccountingYear IN, \r\n" +
                                                                   "    :i_hWndFrame.frmQueryVoucherDetail.ccVoucherType.i_sMyValue IN, \r\n" +
                                                                   "    :i_hWndFrame.frmQueryVoucherDetail.dfVoucherNo IN)")))
                            {
                                return false;
                            }
                            Ifs.Fnd.ApplicationForms.Var.DataTransfer.SourceNameSet("VOUCHER_DETAIL");
                            sItemValues[0] = sOriginalVoucherType;
                            Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemAdd("VOUCHER_TYPE", sItemValues);
                            sItemValues[0] = nOriginalVoucherNo.ToString();
                            Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemAdd("VOUCHER_NO", sItemValues);
                            sItemValues[0] = nOriginalAccYear.ToString();
                            Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemAdd("ACCOUNTING_YEAR", sItemValues);
                            sItemValues[0] = sOriginalCompany;
                            Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemAdd("COMPANY", sItemValues);
                            SessionCreateWindow(Pal.GetActiveInstanceName("frmMCQueryVoucherDetail"), Sys.hWndMDI);
                            Sal.WaitCursor(false);
                        }
                         else
                        {                            
                            sItemNames[0] = "VOUCHER_TYPE";
                            hWndItems[0] = ccVoucherType;
                            sItemNames[1] = "VOUCHER_NO";
                            hWndItems[1] = dfVoucherNo;
                            sItemNames[2] = "ACCOUNTING_YEAR";
                            hWndItems[2] = dfAccountingYear;
                            sItemNames[3] = "COMPANY";
                            hWndItems[3] = dfCompany;
                            Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("VOUCHER_DETAIL", this, sItemNames, hWndItems);
                            SessionCreateWindow(Pal.GetActiveInstanceName("frmMCQueryVoucherDetail"), Sys.hWndMDI);
                            Sal.WaitCursor(false);
                        }                        
                        // Bug 94795, End                        
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
        public virtual SalNumber FreeText(SalNumber nWhat)
        {
            #region Local Variables
            // Bug 77430,  removed IsText
            // Bug 77430, Begin, added some variables
            SalString sRS = "";
            SalString sKeyAttr = "";
            SalString sPackageName = "";
            SalArray<SalString> sNotes = new SalArray<SalString>();
            SalNumber nTempNoteId = 0;
            // Bug 77430, End
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    // Bug 77430, Begin, changed METHOD_Inquire

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        if (dfCompany.Text == Ifs.Fnd.ApplicationForms.Const.strNULL || dfVoucherNo.Number < 1)
                        {
                            return 0;
                        }
                        return 1;

                    // Bug 77430, End

                    // Bug 77430, Begin, changed METHOD_Execute

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        sRS = ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_RS).ToCharacter();
                        sPackageName = "VOUCHER_NOTE_API";
                        Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("COMPANY", dfCompany.Text, ref sKeyAttr);
                        Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("ACCOUNTING_YEAR", dfAccountingYear.Number.ToString(0), ref sKeyAttr);
                        Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("VOUCHER_TYPE", ccVoucherType.i_sMyValue, ref sKeyAttr);
                        Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("VOUCHER_NO", dfVoucherNo.Number.ToString(0), ref sKeyAttr);
                        sNotes[0] = sPackageName + sRS + Properties.Resources.USER_Voucher_Notes + sRS + sKeyAttr;
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.SourceNameSet("NotesData");
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemAdd("NotesData", sNotes);
                        dlgNotes.ModalDialog(Ifs.Fnd.ApplicationForms.Int.Explorer.ExplorerForm);
                        Sal.SendMsg(i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRefresh, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                        // Update Notes check box
                        CheckNotesExist();
                        return 1;

                    // Bug 77430, End
                }
            }

            return 0;
            #endregion
        }
        // Bug 77430, Begin
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber CheckNotesExist()
        {
            #region Actions
            using (new SalContext(this))
            {
                if (dfCompany.Text != Ifs.Fnd.ApplicationForms.Const.strNULL && dfAccountingYear.Number.ToString(0) != Ifs.Fnd.ApplicationForms.Const.strNULL && ccVoucherType.i_sMyValue != Ifs.Fnd.ApplicationForms.Const.strNULL && dfVoucherNo.Number.ToString(
                    0) != Ifs.Fnd.ApplicationForms.Const.strNULL)
                {
                    using (SignatureHints hints = SignatureHints.NewContext())
                    {
                        hints.Add("Voucher_Note_API.Check_Note_Exist", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                        DbPLSQLBlock(cSessionManager.c_hSql, ":i_hWndFrame.frmQueryVoucherDetail.sNoteExist := &AO.Voucher_Note_API.Check_Note_Exist(\r\n" +
                            "				:i_hWndFrame.frmQueryVoucherDetail.dfCompany,\r\n" +
                            "				:i_hWndFrame.frmQueryVoucherDetail.dfAccountingYear,\r\n" +
                            "			                :i_hWndFrame.frmQueryVoucherDetail.ccVoucherType.i_sMyValue,\r\n" +
                            "                                                                :i_hWndFrame.frmQueryVoucherDetail.dfVoucherNo)");
                    }
                    if (sNoteExist == "TRUE")
                    {
                        cbNotes.Checked = true;
                    }
                    else
                    {
                        cbNotes.Checked = false;
                    }
                }
                else
                {
                    cbNotes.Checked = false;
                }
            }

            return 0;
            #endregion
        }

        public virtual SalBoolean ChangeCompany(SalBoolean nWhat)
        {
            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        return Sal.SendClassMessage(Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Sys.lParam);

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        if (Sal.SendClassMessage(Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Sys.lParam))
                        {
                            return true;
                        }
                        return false;
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
        private void frmQueryVoucherDetail_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate:
                    this.frmQueryVoucherDetail_OnPM_DataSourcePopulate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceQueryFieldName:
                    this.frmQueryVoucherDetail_OnPM_DataSourceQueryFieldName(sender, e);
                    break;

                // Bug 82899, Begin

                case Ifs.Fnd.ApplicationForms.Const.PM_AttachmentKeysGet:
                    this.frmQueryVoucherDetail_OnPM_AttachmentKeysGet(sender, e);
                    break;

                // Bug 82899, End
            }
            #endregion
        }

        /// <summary>
        /// PM_DataSourcePopulate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmQueryVoucherDetail_OnPM_DataSourcePopulate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            // Bug 77430, Begin, Removed msg call PAM_CheckUncheckText
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Sys.wParam, Sys.lParam))
            {
                if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
                {
                    if (this.dfMultiCompanyId.Text != Ifs.Fnd.ApplicationForms.Const.strNULL)
                    {
                        this.cbMultiCompanyId.Checked = true;
                    }
                    else
                    {
                        this.cbMultiCompanyId.Checked = false;
                    }
                    this.dfCodePartValue.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                    this.dfCodePartDescription.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                }
                e.Return = true;
                return;
            }
            else
            {
                e.Return = false;
                return;
            }
            // Bug 77430, End
            #endregion
        }

        /// <summary>
        /// PM_DataSourceQueryFieldName event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmQueryVoucherDetail_OnPM_DataSourceQueryFieldName(object sender, WindowActionsEventArgs e)
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
                        e.Return = (this.i_hWndFrame.ToNumber().ToString(0) + ".frmQueryVoucherDetail.i_sCompany").ToHandle();
                        return;
                }
                // Bug 77430, Begin
                this.CheckNotesExist();
                // Bug 77430, End
            }
            else
            {
                e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceQueryFieldName, Sys.wParam, Sys.lParam);
                return;
            }
            #endregion
        }

        /// <summary>
        /// PM_AttachmentKeysGet event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmQueryVoucherDetail_OnPM_AttachmentKeysGet(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.Msg.Construct();
            this.Msg.AddAttribute("ACCOUNTING_YEAR", Sal.WindowHandleToNumber(this.dfAccountingYear).ToString(0));
            this.Msg.AddAttribute("COMPANY", Sal.WindowHandleToNumber(this.dfCompany).ToString(0));
            this.Msg.AddAttribute("VOUCHER_NO", Sal.WindowHandleToNumber(this.dfVoucherNo).ToString(0));
            this.Msg.AddAttribute("VOUCHER_TYPE", Sal.WindowHandleToNumber(this.ccVoucherType).ToString(0));
            e.Return = this.Msg.Pack().ToHandle();
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void cbNotes_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                // Bug 77430, Begin

                case Ifs.Fnd.ApplicationForms.Const.WM_LBUTTONDBLCLK:
                    this.cbNotes_OnWM_LBUTTONDBLCLK(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.WM_LBUTTONDOWN:
                    e.Handled = true;
                    e.Return = false;
                    return;

                // Bug 77430, End
            }
            #endregion
        }

        /// <summary>
        /// WM_LBUTTONDBLCLK event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cbNotes_OnWM_LBUTTONDBLCLK(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (!(this.dfCompany.EditDataItemStateGet() == Ifs.Fnd.ApplicationForms.Const.EDIT_Empty))
            {
                if (FreeText(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire))
                {
                    FreeText(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
                }
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
        private void tblVoucherDetail_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_AttachmentKeysGet:
                    this.tblVoucherDetail_OnPM_AttachmentKeysGet(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_AttachmentKeysGet event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherDetail_OnPM_AttachmentKeysGet(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.tbl_Msg.Construct();
            this.tbl_Msg.AddAttribute("ACCOUNTING_YEAR", Sal.WindowHandleToNumber(this.tblVoucherDetail_colAccountingYear).ToString(0));
            this.tbl_Msg.AddAttribute("COMPANY", Sal.WindowHandleToNumber(this.tblVoucherDetail_colCompany).ToString(0));
            this.tbl_Msg.AddAttribute("VOUCHER_NO", Sal.WindowHandleToNumber(this.tblVoucherDetail_colVoucherNo).ToString(0));
            this.tbl_Msg.AddAttribute("VOUCHER_TYPE", Sal.WindowHandleToNumber(this.tblVoucherDetail_colVoucherType).ToString(0));
            this.tbl_Msg.AddAttribute("ROW_NO", Sal.WindowHandleToNumber(this.tblVoucherDetail_colRowNo).ToString(0));
            e.Return = this.tbl_Msg.Pack().ToHandle();
            return;
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
        public override SalString vrtGetWindowTitle()
        {
            return this.GetWindowTitle();
        }
        #endregion

        #region Event Handlers

        private void menuItem__Notes_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = FreeText(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem__Notes_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            FreeText(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem_View_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = QueryMultiCompanyVoucher(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem_View_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            QueryMultiCompanyVoucher(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem_Change_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = ChangeCompany(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem_Change_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            ChangeCompany(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem__Notes_1_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = FreeText(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem__Notes_1_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            FreeText(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem_View_1_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = QueryMultiCompanyVoucher(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem_View_1_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            QueryMultiCompanyVoucher(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem_Change_1_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = ChangeCompany(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem_Change_1_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            ChangeCompany(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem__Notes_2_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = FreeText(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem__Notes_2_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            FreeText(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem_View_2_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = QueryMultiCompanyVoucher(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem_View_2_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            QueryMultiCompanyVoucher(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem_Change_2_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = ChangeCompany(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem_Change_2_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            ChangeCompany(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        #endregion

    }
}
