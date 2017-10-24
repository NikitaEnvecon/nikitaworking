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
    [FndWindowRegistration("VOUCHER", "Voucher")]
    public partial class tbwQueryVoucher : cTableWindowFin
    {
        #region Window Variables
        public SalString sCompanyName = "";
        public SalArray<SalString> sPlaceHolders = new SalArray<SalString>();
        public SalNumber nRow = 0;
        public SalArray<SalString> sChanges = new SalArray<SalString>();
        public SalString sID = "";
        public SalNumber nNumChanges = 0;
        public SalNumber nRetVal = 0;
        public SalString lsTemp = "";
        public SalArray<SalString> CorrectionIIDClientVals = new SalArray<SalString>();
        public SalArray<SalString> CorrectionIIDDbVals = new SalArray<SalString>();
        public SalArray<SalString> InterimVouIIDClientVals = new SalArray<SalString>();
        public SalArray<SalString> InterimVouIIDDbVals = new SalArray<SalString>();
        public SalString sTemp1 = "";
        public SalString sTemp2 = "";
        public SalArray<SalString> sItemNames = new SalArray<SalString>();
        public SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
        public cMessage Msg = new cMessage();        
        public SalString sOriginalCompany = "";
        public SalString sOriginalVoucherType = "";
        public SalNumber nOriginalAccYear = 0;
        public SalNumber nOriginalVoucherNo = 0;
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public tbwQueryVoucher()
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
        public new static tbwQueryVoucher FromHandle(SalWindowHandle handle)
        {
            return ((tbwQueryVoucher)SalWindow.FromHandle(handle, typeof(tbwQueryVoucher)));
        }
        #endregion

        #region Methods

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public new SalString GetWindowTitle()
        {
            #region Actions
            using (new SalContext(this))
            {
                return Ifs.Application.Accrul.Properties.Resources.WH_tbwQueryVoucher;
            }
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
            SalArray<SalString> sNotes = new SalArray<SalString>();
            SalNumber nTempNoteId = 0;
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

                    // Bug 77430, Begin, added the detailed notes functionality, removed existing code

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        sRS = ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_RS).ToCharacter();
                        sPackageName = "VOUCHER_NOTE_API";
                        Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("COMPANY", colCompany.Text, ref sKeyAttr);
                        Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("ACCOUNTING_YEAR", colAccountingYear.Number.ToString(0), ref sKeyAttr);
                        Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("VOUCHER_TYPE", colVoucherType.Text, ref sKeyAttr);
                        Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("VOUCHER_NO", colVoucherNo.Number.ToString(0), ref sKeyAttr);
                        sNotes[0] = sPackageName + sRS + Ifs.Application.Accrul.Properties.Resources.USER_Voucher_Notes + sRS + sKeyAttr;
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.SourceNameSet("NotesData");
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemAdd("NotesData", sNotes);
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
        /// <param name="nWhat"></param>
        /// <param name="sMethod"></param>
        /// <returns></returns>
        public virtual SalNumber Voucher(SalNumber nWhat, SalString sMethod)
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
                        hWndItems[0] = colVoucherType;
                        sItemNames[1] = "VOUCHER_NO";
                        hWndItems[1] = colVoucherNo;
                        sItemNames[2] = "ACCOUNTING_YEAR";
                        hWndItems[2] = colAccountingYear;
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("VOUCHER_TYPE", this, sItemNames, hWndItems);
                        if (sMethod == "VoucherRow")
                        {
                            SessionCreateWindow(Pal.GetActiveInstanceName("tbwQueryVoucherRow"), Sys.hWndMDI);
                        }
                        else if (sMethod == "VoucherDetail")
                        {
                            SessionCreateWindow(Pal.GetActiveInstanceName("frmQueryVoucherDetail"), Sys.hWndMDI);
                        }
                        Sal.WaitCursor(false);
                        break;
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// This function gets the Client Value for Correction
        /// </summary>
        /// <param name="ClientValueIn"></param>
        /// <param name="DbValueOut"></param>
        /// <returns></returns>
        public virtual SalBoolean EncodeCorrectionIID(SalString ClientValueIn, ref SalString DbValueOut)
        {
            #region Local Variables
            SalNumber nArrInd = 0;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                nArrInd = 1;
                while (true)
                {
                    if (CorrectionIIDClientVals[nArrInd] != Ifs.Fnd.ApplicationForms.Const.strNULL)
                    {
                        if (ClientValueIn == CorrectionIIDClientVals[nArrInd])
                        {
                            DbValueOut = CorrectionIIDDbVals[nArrInd];
                            return true;
                        }
                    }
                    else
                    {
                        // Fetch theDb Value using Encode function
                        sTemp1 = ClientValueIn;
                        lsTemp = "SELECT " + cSessionManager.c_sDbPrefix + "Voucher_Correction_API.Encode( :i_hWndFrame.tbwQueryVoucher.sTemp1 )\r\n" +
                        "into :i_hWndFrame.tbwQueryVoucher.sTemp2 from DUAL ";
                        if (DbPrepareAndExecute(cSessionManager.c_hSql, lsTemp))
                        {
                            if (DbFetchNext(cSessionManager.c_hSql, ref nRetVal))
                            {
                                CorrectionIIDClientVals[nArrInd] = ClientValueIn;
                                CorrectionIIDDbVals[nArrInd] = sTemp2;
                                DbValueOut = sTemp2;
                                return true;
                            }
                        }
                        return false;
                    }
                    nArrInd = nArrInd + 1;
                }
            }

            return false;
            #endregion
        }

        /// <summary>
        /// This function gets the Client Value for Correction
        /// </summary>
        /// <param name="ClientValueIn"></param>
        /// <param name="DbValueOut"></param>
        /// <returns></returns>
        public virtual SalBoolean EncodeInterimVoucherIID(SalString ClientValueIn, ref SalString DbValueOut)
        {
            #region Local Variables
            SalNumber nArrInd = 0;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                nArrInd = 1;
                while (true)
                {
                    if (InterimVouIIDClientVals[nArrInd] != Ifs.Fnd.ApplicationForms.Const.strNULL)
                    {
                        if (ClientValueIn == InterimVouIIDClientVals[nArrInd])
                        {
                            DbValueOut = InterimVouIIDDbVals[nArrInd];
                            return true;
                        }
                    }
                    else
                    {
                        // Fetch theDb Value using Encode function
                        sTemp1 = ClientValueIn;
                        lsTemp = "SELECT " + cSessionManager.c_sDbPrefix + "Voucher_Interim_API.Encode( :i_hWndFrame.tbwQueryVoucher.sTemp1 )\r\n" +
                        "into :i_hWndFrame.tbwQueryVoucher.sTemp2 from DUAL ";
                        if (DbPrepareAndExecute(cSessionManager.c_hSql, lsTemp))
                        {
                            if (DbFetchNext(cSessionManager.c_hSql, ref nRetVal))
                            {
                                InterimVouIIDClientVals[nArrInd] = ClientValueIn;
                                InterimVouIIDDbVals[nArrInd] = sTemp2;
                                DbValueOut = sTemp2;
                                return true;
                            }
                        }
                        return false;
                    }
                    nArrInd = nArrInd + 1;
                }
            }

            return false;
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
            SalNumber nRow = 0;
            SalString VouType = "";
            SalBoolean bTemp = false;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        bTemp = false;
                        nRow = Sys.TBL_MinRow;
                        if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("frmMCQueryVoucherDetail"))))
                        {
                            return 0;
                        }
                        while (Sal.TblFindNextRow(i_hWndSelf, ref nRow, Sys.ROW_Selected, 0))
                        {
                            if (colMultiCompanyVoucher.Text == "TRUE")
                            {
                                if (!(Sal.IsNull(colMultiCompanyId)))
                                {
                                    // Bug 94795, Begin
                                    if (colVoucherType.Text != "R")
                                    {
                                        bTemp = true;
                                    }
                                    // Bug 94795, End
                                }
                            }
                        }
                        return bTemp;
                        return 0;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        Sal.WaitCursor(true);                                                
                        if (!(Sal.IsNull(colMultiCompanyId)) && !(Sal.IsNull(colVoucherTypeRef)) && colMultiCompanyId.Text != colCompany.Text)
                        {
                            // this is the multi-company. use the reference information if no interim voucher is created otherwise take from the method.                            
                            if (!(DbPLSQLBlock(cSessionManager.c_hSql, "&AO.Multi_Company_Voucher_Util_API.Get_Multi_Company_Info( \r\n" +
                                                                   "    :i_hWndFrame.tbwQueryVoucher.sOriginalCompany OUT, \r\n" +
                                                                   "    :i_hWndFrame.tbwQueryVoucher.nOriginalAccYear OUT, \r\n" +
                                                                   "    :i_hWndFrame.tbwQueryVoucher.sOriginalVoucherType OUT, \r\n" +
                                                                   "    :i_hWndFrame.tbwQueryVoucher.nOriginalVoucherNo OUT, \r\n" +
                                                                   "    :i_hWndFrame.tbwQueryVoucher.colCompany IN, \r\n" +
                                                                   "    :i_hWndFrame.tbwQueryVoucher.colAccountingYear IN, \r\n" +
                                                                   "    :i_hWndFrame.tbwQueryVoucher.colVoucherType IN, \r\n" +
                                                                   "    :i_hWndFrame.tbwQueryVoucher.colVoucherNo IN)")))
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
                            hWndItems[0] = colVoucherType;
                            sItemNames[1] = "VOUCHER_NO";
                            hWndItems[1] = colVoucherNo;
                            sItemNames[2] = "ACCOUNTING_YEAR";
                            hWndItems[2] = colAccountingYear;
                            sItemNames[3] = "COMPANY";
                            hWndItems[3] = colCompany;

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
        /// This function returns TRUE, if only one row in table window is selected
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean OnlyOneRowSelected()
        {
            #region Local Variables
            SalNumber nOldRow = 0;
            SalNumber nRow = 0;
            SalNumber nSelRows = 0;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                nOldRow = Sal.TblQueryContext(i_hWndSelf);
                nRow = Sys.TBL_MinRow;
                nSelRows = 0;
                while (true)
                {
                    if (Sal.TblFindNextRow(i_hWndSelf, ref nRow, Sys.ROW_Selected, Sys.ROW_MarkDeleted))
                    {
                        Sal.TblSetContext(i_hWndSelf, nRow);
                        nSelRows = nSelRows + 1;
                    }
                    else
                    {
                        break;
                    }
                }
                Sal.TblSetContext(i_hWndSelf, nOldRow);
                if (nSelRows != 1)
                {
                    return false;
                }
                return true;
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
        private void tbwQueryVoucher_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_UserProfileChanged:
                    this.tbwQueryVoucher_OnPM_UserProfileChanged(sender, e);
                    break;

                // Bug 77430, Removed On SAM_FetchRowDone

                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate:
                    this.tbwQueryVoucher_OnPM_DataSourcePopulate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceQueryFieldName:
                    this.tbwQueryVoucher_OnPM_DataSourceQueryFieldName(sender, e);
                    break;

                // Bug 82899, Begin

                case Ifs.Fnd.ApplicationForms.Const.PM_AttachmentKeysGet:
                    this.tbwQueryVoucher_OnPM_AttachmentKeysGet(sender, e);
                    break;

                // Bug 82899, End
            }
            #endregion
        }

        /// <summary>
        /// PM_UserProfileChanged event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwQueryVoucher_OnPM_UserProfileChanged(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            // Get all changed variables
            this.nNumChanges = SalString.FromHandle(Sys.lParam).Tokenize("", ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_RS).ToCharacter(), this.sChanges);
            if (Ifs.Fnd.ApplicationForms.Int.PalStrSplitLeft(this.sChanges[0], ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_US).ToCharacter()) == "COMPANY")
            {
                this.i_sCompany = Ifs.Fnd.ApplicationForms.Int.PalStrSplitRight(this.sChanges[0], ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_US).ToCharacter());
            }
            // Clear form
            this.DataSourceClear(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
            this.SetWindowTitle();
            #endregion
        }

        /// <summary>
        /// PM_DataSourcePopulate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwQueryVoucher_OnPM_DataSourcePopulate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Sys.wParam, Sys.lParam))
            {
                if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
                {
                    Sal.SetFocus(this);
                }
                e.Return = true;
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
        /// PM_DataSourceQueryFieldName event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwQueryVoucher_OnPM_DataSourceQueryFieldName(object sender, WindowActionsEventArgs e)
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
                        e.Return = (this.i_hWndFrame.ToNumber().ToString(0) + ".tbwQueryVoucher.i_sCompany").ToHandle();
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
        private void tbwQueryVoucher_OnPM_AttachmentKeysGet(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.Msg.Construct();
            this.Msg.AddAttribute("ACCOUNTING_YEAR", Sal.WindowHandleToNumber(this.colAccountingYear).ToString(0));
            this.Msg.AddAttribute("COMPANY", Sal.WindowHandleToNumber(this.colCompany).ToString(0));
            this.Msg.AddAttribute("VOUCHER_NO", Sal.WindowHandleToNumber(this.colVoucherNo).ToString(0));
            this.Msg.AddAttribute("VOUCHER_TYPE", Sal.WindowHandleToNumber(this.colVoucherType).ToString(0));
            e.Return = this.Msg.Pack().ToHandle();
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colText_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_DoubleClick:
                    this.colText_OnSAM_DoubleClick(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_DoubleClick event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colText_OnSAM_DoubleClick(object sender, WindowActionsEventArgs e)
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
        private void colVoucherTypeRef_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                // Bug 81879 begin

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom:
                    this.colVoucherTypeRef_OnPM_DataItemZoom(sender, e);
                    break;

                // Bug 81879 end
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemZoom event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colVoucherTypeRef_OnPM_DataItemZoom(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                this.sItemNames[0] = "COMPANY";
                this.hWndItems[0] = this.colCompany;
                this.sItemNames[1] = "VOUCHER_TYPE";
                this.hWndItems[1] = this.colVoucherTypeRef;
                Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("VoucherType", this, this.sItemNames, this.hWndItems);
                SessionNavigate(Pal.GetActiveInstanceName("frmVoucherType"));
                e.Return = true;
                return;
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }
        #endregion

        #region Late Bind Methods

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalString vrtGetWindowTitle()
        {
            return this.GetWindowTitle();
        }
        #endregion

        #region Event Handlers

        private void menuItem_Voucher_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = Voucher(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, "VoucherRow");
        }

        private void menuItem_Voucher_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            Voucher(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, "VoucherRow");
        }

        private void menuItem_Voucher_1_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = Voucher(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, "VoucherDetail");
        }

        private void menuItem_Voucher_1_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            Voucher(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, "VoucherDetail");
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
            ((FndCommand)sender).Enabled = Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Sys.lParam);
        }

        private void menuItem_Change_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Sys.lParam);
        }

        private void menuItem__Notes_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = FreeText(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem__Notes_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            FreeText(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem_Voucher_2_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = Voucher(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, "VoucherRow");
        }

        private void menuItem_Voucher_2_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            Voucher(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, "VoucherRow");
        }

        private void menuItem_Voucher_3_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = Voucher(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, "VoucherDetail");
        }

        private void menuItem_Voucher_3_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            Voucher(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, "VoucherDetail");
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
            ((FndCommand)sender).Enabled = Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Sys.lParam);
        }

        private void menuItem_Change_1_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Sys.lParam);
        }

        private void menuItem__Notes_1_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = FreeText(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem__Notes_1_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            FreeText(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        #endregion

    }
}
