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
// Date     By      Notes
// -----    ------  ---------------------------------------------------------------------------------
// 111031   Umdolk  SFI-218. Corrected Assertion errors.
// 140418   Nirylk  PBFI-5614, Merged bug 100161. Subscribed to WindowActions of tblVoucherRow_colsDeliveryTypeId
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
    [FndWindowRegistration("MULTI_COMPANY_VOUCHER2", "MultiCompanyVoucher", FndWindowRegistrationFlags.HomePage)]
    public partial class frmMCQueryVoucherDetail : cFormWindowFin
    {
        #region Window Variables
        public SalArray<SalString> sPlaceHolders = new SalArray<SalString>();
        public SalNumber nRow = 0;
        public SalString lsTemp = "";
        public SalString sNoteExist = "";
        public cMessage Msg = new cMessage();
        public cMessage tblMsg = new cMessage();
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public frmMCQueryVoucherDetail()
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
        public new static frmMCQueryVoucherDetail FromHandle(SalWindowHandle handle)
        {
            return ((frmMCQueryVoucherDetail)SalWindow.FromHandle(handle, typeof(frmMCQueryVoucherDetail)));
        }
        #endregion

        #region Methods

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public new SalBoolean FrameStartupUser()
        {
            #region Local Variables
            // Insert new code here...
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                // Insert new code here...
                return true;
            }
            #endregion
        }
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public override SalNumber vrtActivate(fcURL URL)
        {
            #region Local Variables
            SalNumber nItemIndexCompany = 0;
            #endregion
            #region Actions
            using (new SalContext(this))
            {
                if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.RecCountGet() > 0)
                {
                    // Data transfer kod
                    Sal.WaitCursor(true);
                    nItemIndexCompany = Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemIndexGet("COMPANY");
                    if (!(Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemValueStrGet(nItemIndexCompany, 0, ref i_sCompany)))
                    {
                        return false;
                    }
                    SetWindowTitle();
                    if (InitFromTransferredData())
                    {
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();
                    }
                    Sal.WaitCursor(false);
                    return false;
                }
                return base.Activate(URL);
            }
            #endregion

        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public new SalBoolean SetWindowTitle()
        {
            #region Actions
            using (new SalContext(this))
            {
                Sal.SetWindowText(this, i_sCompany + " - " + Ifs.Application.Accrul.Properties.Resources.WH_frmMCQueryVoucherDetail);
            }

            return 0;
            #endregion
        }

        

        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalNumber Notes(SalNumber nWhat)
        {
            #region Local Variables
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
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        // Bug 77430, Begin
                        if (dfCompany.Text == Ifs.Fnd.ApplicationForms.Const.strNULL || dfVoucherNo.Number < 1)
                        {
                            return 0;
                        }
                        // Bug 77430, End
                        nRow = Sys.TBL_MinRow;
                        if (Sal.TblFindNextRow(i_hWndFrame, ref nRow, Sys.ROW_Selected, 0))
                        {
                            if (Sal.TblFindNextRow(i_hWndFrame, ref nRow, Sys.ROW_Selected, 0))
                            {
                                return 0;
                            }
                            else if (cbNotes.Checked == true)
                            {
                                return 1;
                            }
                            else
                            {
                                return 0;
                            }
                        }
                        else if (cbNotes.Checked == true)
                        {
                            return 1;
                        }
                        else
                        {
                            return 0;
                        }

                    // Bug 77430, Begin, changed METHOD_Execute

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        sRS = ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_RS).ToCharacter();
                        sPackageName = "VOUCHER_NOTE_API";
                        Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("COMPANY", dfCompany.Text, ref sKeyAttr);
                        Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("ACCOUNTING_YEAR", dfAccountingYear.Number.ToString(0), ref sKeyAttr);
                        Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("VOUCHER_TYPE", ccVoucherType.i_sMyValue, ref sKeyAttr);
                        Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("VOUCHER_NO", dfVoucherNo.Number.ToString(0), ref sKeyAttr);
                        sNotes[0] = sPackageName + sRS + Ifs.Application.Accrul.Properties.Resources.USER_Voucher_Notes + sRS + sKeyAttr;
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.SourceNameSet("NotesData");
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemAdd("NotesData", sNotes);
                        dlgNotes.ModalDialog(Ifs.Fnd.ApplicationForms.Int.Explorer.ExplorerForm);
                        // Update Notes check box
                        using (SignatureHints hints = SignatureHints.NewContext())
                        {
                            hints.Add("Voucher_Note_API.Check_Note_Exist", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                            DbPLSQLBlock(cSessionManager.c_hSql, ":i_hWndFrame.frmMCQueryVoucherDetail.sNoteExist := &AO.Voucher_Note_API.Check_Note_Exist(\r\n" +
                                "				:i_hWndFrame.frmMCQueryVoucherDetail.dfCompany,\r\n" +
                                "				:i_hWndFrame.frmMCQueryVoucherDetail.dfAccountingYear,\r\n" +
                                "			                :i_hWndFrame.frmMCQueryVoucherDetail.ccVoucherType.i_sMyValue,\r\n" +
                                "                                                                :i_hWndFrame.frmMCQueryVoucherDetail.dfVoucherNo)");
                        }
                        if (sNoteExist == "TRUE")
                        {
                            cbNotes.Checked = true;
                        }
                        else
                        {
                            cbNotes.Checked = false;
                        }
                        return 1;

                    // Bug 77430, End
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
        private void frmMCQueryVoucherDetail_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate:
                    this.frmMCQueryVoucherDetail_OnPM_DataSourcePopulate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew:
                    e.Handled = true;
                    e.Return = false;
                    return;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordDuplicate:
                    e.Handled = true;
                    e.Return = false;
                    return;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove:
                    e.Handled = true;
                    e.Return = false;
                    return;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave:
                    e.Handled = true;
                    e.Return = false;
                    return;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceQueryFieldName:
                    this.frmMCQueryVoucherDetail_OnPM_DataSourceQueryFieldName(sender, e);
                    break;

                // Bug 82855, Begin

                case Ifs.Fnd.ApplicationForms.Const.PM_AttachmentKeysGet:
                    this.frmMCQueryVoucherDetail_OnPM_AttachmentKeysGet(sender, e);
                    break;

                // Bug 82855, End
            }
            #endregion
        }

        /// <summary>
        /// PM_DataSourcePopulate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmMCQueryVoucherDetail_OnPM_DataSourcePopulate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                this.dfCodePartValue.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                this.dfCodePartDescription.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
            }
            // Bug 77430, Begin, Removed class message PAM_MCCheckUncheckText
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Sys.wParam, Sys.lParam))
            {
                e.Return = true;
                return;
            }
            // Bug 77430, End
            else
            {
                e.Return = false;
                return;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataSourceQueryFieldName event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmMCQueryVoucherDetail_OnPM_DataSourceQueryFieldName(object sender, WindowActionsEventArgs e)
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
                        e.Return = (this.i_hWndFrame.ToNumber().ToString(0) + ".frmMCQueryVoucherDetail.i_sCompany").ToHandle();
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
        /// PM_AttachmentKeysGet event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmMCQueryVoucherDetail_OnPM_AttachmentKeysGet(object sender, WindowActionsEventArgs e)
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
                // Bug 77430, Begin, changed the message action

                case Ifs.Fnd.ApplicationForms.Const.WM_LBUTTONDBLCLK:
                    this.cbNotes_OnWM_LBUTTONDBLCLK(sender, e);
                    break;

                // Bug 77430, End

                // Bug 77430, Begin, added new message action

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
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.WM_LBUTTONDBLCLK, Sys.wParam, Sys.lParam))
            {
                if (!(this.dfCompany.EditDataItemStateGet() == Ifs.Fnd.ApplicationForms.Const.EDIT_Empty))
                {
                    e.Return = this.Notes(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
                    return;
                }
            }
            e.Return = false;
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblVoucherRow_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew:
                    e.Handled = true;
                    e.Return = false;
                    return;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordDuplicate:
                    e.Handled = true;
                    e.Return = false;
                    return;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove:
                    e.Handled = true;
                    e.Return = false;
                    return;

                case Ifs.Application.Accrul.Const.PAM_GetMultiCompany:
                    e.Handled = true;
                    e.Return = ((SalString)this.tblVoucherRow_colVoucherCompany.Text).ToHandle();
                    return;

                case Ifs.Fnd.ApplicationForms.Const.PM_AttachmentKeysGet:
                    this.tblVoucherRow_OnPM_AttachmentKeysGet(sender, e);
                    break;

                case Sys.SAM_FetchRowDone:
                    this.tblVoucherRow_OnSAM_FetchRowDone(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_AttachmentKeysGet event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherRow_OnPM_AttachmentKeysGet(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.tblMsg.Construct();
            this.tblMsg.AddAttribute("ACCOUNTING_YEAR", Sal.WindowHandleToNumber(this.tblVoucherRow_colAccountingYear).ToString(0));
            this.tblMsg.AddAttribute("COMPANY", Sal.WindowHandleToNumber(this.tblVoucherRow_colCompany).ToString(0));
            this.tblMsg.AddAttribute("VOUCHER_NO", Sal.WindowHandleToNumber(this.tblVoucherRow_colVoucherNo).ToString(0));
            this.tblMsg.AddAttribute("VOUCHER_TYPE", Sal.WindowHandleToNumber(this.tblVoucherRow_colVoucherType).ToString(0));
            this.tblMsg.AddAttribute("ROW_NO", Sal.WindowHandleToNumber(this.tblVoucherRow_colRowNo).ToString(0));
            e.Return = this.tblMsg.Pack().ToHandle();
            return;
            #endregion
        }

        /// <summary>
        /// SAM_FetchRowDone event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherRow_OnSAM_FetchRowDone(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Sys.SAM_FetchRowDone, Sys.wParam, Sys.lParam);
            this.tblVoucherRow_colConvertionFactor.Text = this.tblVoucherRow_colConversionFactor.Text;
            e.Return = true;
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
        public override SalBoolean vrtSetWindowTitle()
        {
            return this.SetWindowTitle();
        }

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        
        #endregion

        #region ChildTable-tblVoucherRow

        #region Window Actions

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colRowNo_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.colRowNo_OnSAM_SetFocus(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    e.Handled = true;
                    e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                    return;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colRowNo_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam))
            {
                Sal.TblSetFocusCell(this, Sal.TblQueryContext(this), this.tblVoucherRow_colAccount, 0, -1);
                e.Return = true;
                return;
            }
            e.Return = false;
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colVoucherCompany_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Application.Accrul.Const.PAM_GetChildCompany:
                    e.Handled = true;
                    cColumnFin.c_sCompany = this.tblVoucherRow_colVoucherCompany.Text;
                    break;
            }
            #endregion
        }

        private void tblVoucherRow_colsDeliveryTypeId_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom:
                    this.tblVoucherRow_colsDeliveryTypeId_OnPM_DataItemZoom(sender, e);
                    break;
            }
            #endregion
        }

        private void tblVoucherRow_colsDeliveryTypeId_OnPM_DataItemZoom(object sender, WindowActionsEventArgs e)
        {
            #region Local Variables
            SalArray<SalString> sItemNames = new SalArray<SalString>();
            SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
            #endregion

            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                sItemNames[0] = "COMPANY";
                hWndItems[0] = this.tblVoucherRow_colVoucherCompany;
                sItemNames[1] = "DELIV_TYPE_ID";
                hWndItems[1] = this.tblVoucherRow_colsDeliveryTypeId;
                Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("MultiCompanyVoucherRow", this, sItemNames, hWndItems);
                SessionNavigate(Pal.GetActiveInstanceName("tbwDeliveryType"));

                e.Return = true;
                return;
            }
            else
            {
                e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom, Sys.wParam, Sys.lParam);
                return;
            }
            #endregion

        }
        #endregion
        #endregion

        #region Event Handlers

        private void menuItem_Change_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
           ((FndCommand)sender).Enabled = !(Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0));
        }

        private void menuItem_Change_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            DoChangeCompany(this);
        }

        private void menuItem_Change_1_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
             ((FndCommand)sender).Enabled = !(Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0));
        }

        private void menuItem_Change_1_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            DoChangeCompany(this);
        }

        private void menuItem_Change_2_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = !(Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0));
        }

        private void menuItem_Change_2_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            DoChangeCompany(this);
        }

        #endregion

    }
}
