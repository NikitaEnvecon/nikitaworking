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
using Ifs.Application.Accrul;
using Ifs.Fnd.ApplicationForms;
using Ifs.Fnd.Windows.Forms;
using PPJ.Runtime;
using PPJ.Runtime.Sql;
using PPJ.Runtime.Windows;
using PPJ.Runtime.Vis;

namespace Ifs.Application.Accrul_
{
	
	/// <summary>
	/// </summary>
    [FndWindowRegistration("VOUCHER_TYPE,VOUCHER_TYPE_FOR_Z", "VoucherType", FndWindowRegistrationFlags.HomePage)]
    public partial class frmVoucherType : cFormWindowFin
    {
        #region Window Variables
        public SalString sModule = "";
        public SalString sLu = "";
        public SalString sLedgerID = "";
        public SalString sLedger = "";
        public SalString sCompany = "";
        public SalString sConnected = "";
        public SalString sIsExcluded = "";
        public SalString lsAttribute = "";
        public SalBoolean bAutoAllot = false;
        public SalBoolean bInternal = false;
        public SalBoolean bDelete = false;
        public SalBoolean bIntled = false;
        public SalNumber nIndex = 0;
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public frmVoucherType()
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
        public new static frmVoucherType FromHandle(SalWindowHandle handle)
        {
            return ((frmVoucherType)SalWindow.FromHandle(handle, typeof(frmVoucherType)));
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
                return Properties.Resources.WH_frmVoucherType;
            }
            #endregion
        }

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
                // Bug 72687, Begin, Only the else part is added
                Sal.SendMsg(cmbLedger, Sys.SAM_DropDown, 0, 0);
                // Insert new code here...
                return ((cFormWindowFin)this).FrameStartupUser();
                // Bug 81580, End
                // Bug 72687, End
            }
            #endregion
        }
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public override SalNumber vrtActivate(fcURL URL)
        {
            #region Local Variables
            SalArray<SalString> sItemValues = new SalArray<SalString>();
            // Bug 81580, Begin
            SalString sProfileString = "";
            // Bug 81580, End
            #endregion

            using (new SalContext(this))
            {
                this.cbUseMIM.i_sCheckedValue = "TRUE";
                this.cbUseMIM.i_sUncheckedValue = "FALSE";
                this.cbBalance.i_sCheckedValue = "TRUE";
                this.cbBalance.i_sUncheckedValue = "FALSE";
                this.cbAutoAllotment.i_sCheckedValue = "Y";
                this.cbAutoAllotment.i_sUncheckedValue = "N";
                this.cbSimulationVou.i_sCheckedValue = "TRUE";
                this.cbSimulationVou.i_sUncheckedValue = "FALSE";
                this.cbSingleFunction.i_sCheckedValue = "Y";
                this.cbSingleFunction.i_sUncheckedValue = "N";

                // Bug 81580, Begin, Modified Code
                if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.RecCountGet() > 0)
                {
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet("COMPANY", sItemValues);
                    sCompany = sItemValues[0];
                    sProfileString = "COMPANY" + "^" + sCompany;
                    Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.AM_UserProfileValueSet, 0, sProfileString.ToHandle());
                    sProfileString = "COMPANY" + ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_US).ToCharacter() + sCompany + ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_RS).ToCharacter();
                    Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_UserProfileChanged, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, sProfileString.ToHandle());
                }
                // Bug 81580, End

            }
            return base.Activate(URL);
        }

        /// <summary>
        /// Gets client default values for NEW records
        /// </summary>
        /// <returns></returns>
        public new SalBoolean DataRecordGetDefaults()
        {
            #region Actions
            using (new SalContext(this))
            {
                dfsCompany.Text = i_sCompany;
                dfsOptionalAutoBalance.Text = "N";
                dfsStoreOriginal.Text = "N";
                dfsLabelPrint.Text = "N";
                dfsCompany.EditDataItemSetEdited();
                cbUseMIM.EditDataItemValueSet(1, ((SalString)"FALSE").ToHandle());
                cbAutoAllotment.EditDataItemValueSet(1, ((SalString)"Y").ToHandle());
                cbSimulationVou.EditDataItemValueSet(1, ((SalString)"FALSE").ToHandle());
                cbSingleFunction.EditDataItemValueSet(1, ((SalString)"Y").ToHandle());
                cbBalance.EditDataItemValueSet(1, ((SalString)"TRUE").ToHandle());
                if (bIntled)
                {
                    cmbLedger.EditDataItemValueSet(1, Sal.ListQueryTextX(cmbLedger, 0).ToHandle());
                    Sal.EnableWindow(cbUseMIM);
                }
                else
                {
                    cmbLedger.EditDataItemValueSet(1, Sal.ListQueryTextX(cmbLedger, 1).ToHandle());
                }
                GetLedgerID();
                dfLedgerID.EditDataItemSetEdited();
                dfsOptionalAutoBalance.EditDataItemSetEdited();
                dfsStoreOriginal.EditDataItemSetEdited();
                dfsLabelPrint.EditDataItemSetEdited();
                Sal.DisableWindow(cbBalance);
                DisableVouSelection();
                return true;
            }
            #endregion
        }

        
        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalNumber Translation(SalNumber nWhat)
        {
            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        Sal.WaitCursor(true);
                        sModule = "ACCRUL";
                        sLu = "VoucherType";
                        lsAttribute = Ifs.Fnd.ApplicationForms.Const.strNULL;
                        if (cmbVoucherType.i_sMyValue != Ifs.Fnd.ApplicationForms.Const.strNULL)
                        {
                            lsAttribute = "'" + cmbVoucherType.i_sMyValue + "'";
                        }
                        Ifs.Fnd.ApplicationForms.Var.Cache.SessionStore("TRANSLATE_COMPANY", i_sCompany);
                        Ifs.Fnd.ApplicationForms.Var.Cache.SessionStore("TRANSLATE_MODULE", sModule);
                        Ifs.Fnd.ApplicationForms.Var.Cache.SessionStore("TRANSLATE_LU", sLu);
                        Ifs.Fnd.ApplicationForms.Var.Cache.SessionStore("TRANSLATE_ATTRIBUTE", lsAttribute);
                        SessionCreateWindow(Pal.GetActiveInstanceName("frmCompanyTranslation"), Sys.hWndMDI);
                        Sal.WaitCursor(false);
                        return 1;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        return !(Sal.SendMsg(i_hWndFrame, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0)) && Ifs.Fnd.ApplicationForms.Var.Component.IsWindowAvailable(Pal.GetActiveInstanceName("frmCompanyTranslation")) && Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(
                            Pal.GetActiveInstanceName("frmCompanyTranslation"));
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean CheckAutoAllotment()
        {
            #region Local Variables
            SalNumber nRow = 0;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                nRow = Sys.TBL_MinRow;
                while (true)
                {
                    if (Sal.TblFindNextRow(tblVoucherTypeDetail, ref nRow, 0, 0))
                    {
                        Sal.TblSetContext(tblVoucherTypeDetail, nRow);
                        if (this.tblVoucherTypeDetail_colsAutomaticAllot.Text == "Y")
                        {
                            Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_AutoAllotReq, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Warning, Ifs.Fnd.ApplicationForms.Const.WARNING_Ok);
                            cbAutoAllotment.EditDataItemValueSet(1, ((SalString)"Y").ToHandle());
                            break;
                            return false;
                        }
                    }
                    else
                    {
                        break;
                    }
                    return true;
                }
            }

            return false;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber GetLedgerID()
        {
            #region Actions
            using (new SalContext(this))
            {
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("Ledger_API.Encode", System.Data.ParameterDirection.Input);
                    DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN \r\n" +
                        "		 :i_hWndFrame.frmVoucherType.dfLedgerID := " + cSessionManager.c_sDbPrefix + "Ledger_API.Encode(:i_hWndFrame.frmVoucherType.cmbLedger.i_sMyValue);											          \r\n		 END;");
                }
                dfLedgerID.EditDataItemSetEdited();
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber DisableVouSelection()
        {
            #region Actions
            using (new SalContext(this))
            {
                Sal.DisableWindow(cbAutoAllotment);
                Sal.DisableWindow(cbSimulationVou);
                Sal.DisableWindow(cbSingleFunction);
                Sal.DisableWindow(dfLedgerID);
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber EnableVouSelection()
        {
            #region Actions
            using (new SalContext(this))
            {
                Sal.EnableWindow(cbAutoAllotment);
                Sal.EnableWindow(cbSimulationVou);
                Sal.EnableWindow(cbSingleFunction);
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber SetLedgerSelection()
        {
            #region Actions
            using (new SalContext(this))
            {
                if (cmbLedger.Text == Sal.ListQueryTextX(cmbLedger, 2))
                {
                    Sal.EnableWindow(dfLedgerID);
                    Sal.EnableWindow(cbBalance);
                    Sal.DisableWindow(cbUseMIM);
                }
                else
                {
                    Sal.DisableWindow(dfLedgerID);
                    Sal.DisableWindow(cbBalance);
                    Sal.EnableWindow(cbUseMIM);
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
        private void frmVoucherType_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_CreateComplete:
                    this.frmVoucherType_OnSAM_CreateComplete(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave:
                    this.frmVoucherType_OnPM_DataSourceSave(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate:
                    this.frmVoucherType_OnPM_DataSourcePopulate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceQueryFieldName:
                    this.frmVoucherType_OnPM_DataSourceQueryFieldName(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordDuplicate:
                    this.frmVoucherType_OnPM_DataRecordDuplicate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_CreateComplete event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmVoucherType_OnSAM_CreateComplete(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (!(Ifs.Fnd.ApplicationForms.Var.Component.IsWindowAvailable(Pal.GetActiveInstanceName("tbwInternalLedger"))))
            {
                Sal.DisableWindow(this.cmbLedger);
                Sal.DisableWindow(this.cbUseMIM);
                Sal.DisableWindow(this.cbBalance);
                this.bIntled = false;
            }
            else
            {
                Sal.EnableWindow(this.cmbLedger);
                Sal.EnableWindow(this.cbUseMIM);
                Sal.EnableWindow(this.cbBalance);
                this.bIntled = true;
            }
            Sal.DisableWindow(this.dfLedgerID);
            Sal.SendClassMessage(Sys.SAM_CreateComplete, Sys.wParam, Sys.lParam);
            #endregion
        }

        /// <summary>
        /// PM_DataSourceSave event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmVoucherType_OnPM_DataSourceSave(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.cmbLedger.EditDataItemValueSet(0, this.cmbLedger.i_sMyValue.ToHandle());
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                this.cmbLedger.EditDataItemValueSet(0, this.cmbLedger.i_sMyValue.ToHandle());
                if (!(Sal.TblAnyRows(this.tblVoucherTypeDetail, 0, 0)))
                {
                    // If not voucher type removed
                    if (!(this.cmbVoucherType.EditDataItemStateGet() == 8))
                    {
                        Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_NoDetail, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                        e.Return = false;
                        return;
                    }
                }
                if (!(Sal.TblAnyRows(this.tblVoucherTypeDetail, 0, Sys.ROW_MarkDeleted)))
                {
                    this.DisableVouSelection();
                }
            }
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Sys.wParam, Sys.lParam))
            {
                e.Return = true;
                return;
            }
            e.Return = false;
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataSourcePopulate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmVoucherType_OnPM_DataSourcePopulate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Sys.wParam, Sys.lParam))
            {
                if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
                {
                    this.EnableVouSelection();
                    if (this.bIntled)
                    {
                        this.SetLedgerSelection();
                    }
                    e.Return = true;
                    return;
                }
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
        private void frmVoucherType_OnPM_DataSourceQueryFieldName(object sender, WindowActionsEventArgs e)
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
                        e.Return = (this.i_hWndFrame.ToNumber().ToString(0) + ".frmVoucherType.i_sCompany").ToHandle();
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
        /// PM_DataRecordDuplicate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmVoucherType_OnPM_DataRecordDuplicate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                this.sLedgerID = frmVoucherType.FromHandle(this.i_hWndFrame).dfLedgerID.Text;
            }
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordDuplicate, Sys.wParam, Sys.lParam))
            {
                if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
                {
                    this.SetLedgerSelection();
                    frmVoucherType.FromHandle(this.i_hWndFrame).dfLedgerID.Text = this.sLedgerID;
                    frmVoucherType.FromHandle(this.i_hWndFrame).dfLedgerID.EditDataItemSetEdited();
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
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void cmbVoucherType_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.cmbVoucherType_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cmbVoucherType_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if ((!(Sal.IsNull(this.cmbVoucherType))) && ((bool)this.cmbVoucherType.MethodInquire(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceIsDirty, 0)))
            {
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("VOUCHER_TYPE_API.Voucher_Type_Exists", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                    if (!(this.cmbVoucherType.DbPLSQLBlock(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + " VOUCHER_TYPE_API.Voucher_Type_Exists(\r\n" +
                        " :i_hWndFrame.frmVoucherType.dfsCompany,\r\n" +
                        " :i_hWndFrame.frmVoucherType.cmbVoucherType.i_sMyValue )")))
                    {
                        e.Return = false;
                        return;
                    }
                }
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void cmbLedger_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_Click:
                    this.cmbLedger_OnSAM_Click(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_LookupInit:
                    this.cmbLedger_OnPM_LookupInit(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_Click event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cmbLedger_OnSAM_Click(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Sys.SAM_Click, Sys.wParam, Sys.lParam);
            if (Sal.ListQueryState(this.cmbLedger, 2))
            {
                // Internal Ledger
                // Ledger Id
                Sal.ClearField(this.dfLedgerID);
                Sal.EnableWindow(this.dfLedgerID);
                this.dfLedgerID.EditDataItemSetEdited();
                // Use Manual Internal Methods
                Sal.DisableWindow(this.cbUseMIM);
                // Balance Mandatory
                Sal.EnableWindow(this.cbBalance);
                this.bInternal = true;
            }
            else
            {
                // All Ledgers or General Ledger
                // Ledger Id
                this.GetLedgerID();
                Sal.DisableWindow(this.dfLedgerID);
                // Use Manual Internal Methods
                if (Sal.ListQueryState(this.cmbLedger, 1))
                {
                    // General Ledger
                    this.cbUseMIM.EditDataItemValueSet(1, ((SalString)"FALSE").ToHandle());
                    Sal.DisableWindow(this.cbUseMIM);
                }
                else
                {
                    Sal.EnableWindow(this.cbUseMIM);
                }
                // Balance Mandatory
                this.cbBalance.EditDataItemValueSet(1, ((SalString)"TRUE").ToHandle());
                Sal.DisableWindow(this.cbBalance);
                this.bInternal = false;
            }
            this.cmbLedger.EditDataItemValueSet(0, this.cmbLedger.i_sMyValue.ToHandle());
            #endregion
        }

        /// <summary>
        /// PM_LookupInit event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cmbLedger_OnPM_LookupInit(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            cmbLedger.EditDataItemFlagSet(Ifs.Fnd.ApplicationForms.Const.FIELD_Required, true);
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_LookupInit, Sys.wParam, Sys.lParam))
            {
                Sal.ListDelete(this.cmbLedger.i_hWndSelf, 3);
                Sal.ListDelete(this.cmbLedger.i_hWndSelf, 3);
                cmbLedger.EditDataItemFlagSet(Ifs.Fnd.ApplicationForms.Const.FIELD_Required, false);
                e.Return = true;
                return;
            }
            cmbLedger.EditDataItemFlagSet(Ifs.Fnd.ApplicationForms.Const.FIELD_Required, false);
            e.Return = false;
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void cbUseMIM_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
            }
            #endregion
        }

        /// <summary>
        /// SAM_Create event handler.
        /// </summary>
        /// <param name="message"></param>

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void cbBalance_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
            }
            #endregion
        }

        /// <summary>
        /// SAM_Create event handler.
        /// </summary>
        /// <param name="message"></param>

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void cbAutoAllotment_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {

                case Sys.SAM_Click:
                    this.cbAutoAllotment_OnSAM_Click(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_Create event handler.
        /// </summary>
        /// <param name="message"></param>

        /// <summary>
        /// SAM_Click event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cbAutoAllotment_OnSAM_Click(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (!(Sal.IsNull(this.cmbVoucherType)))
            {
                if (!(this.cbAutoAllotment.Checked))
                {
                    this.CheckAutoAllotment();
                }
                this.bAutoAllot = this.cbAutoAllotment.Checked;
                if (!(this.bAutoAllot))
                {
                    if (Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_AutoAllotWarning, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Question, Ifs.Fnd.ApplicationForms.Const.QUESTION_YesNo) == Sys.IDNO)
                    {
                        this.cbAutoAllotment.EditDataItemValueSet(1, ((SalString)"Y").ToHandle());
                    }
                }
            }
            Sal.SendClassMessage(Sys.SAM_Click, Sys.wParam, Sys.lParam);
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void cbSimulationVou_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
            }
            #endregion
        }

        /// <summary>
        /// SAM_Create event handler.
        /// </summary>
        /// <param name="message"></param>

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void cbSingleFunction_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {

                case Sys.SAM_Click:
                    this.cbSingleFunction_OnSAM_Click(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_Create event handler.
        /// </summary>
        /// <param name="message"></param>

        /// <summary>
        /// SAM_Click event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cbSingleFunction_OnSAM_Click(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (!(Sal.IsNull(this.cmbVoucherType)))
            {
                if (this.tblVoucherTypeDetail_colsSingleVoucher.Text != "Y")
                {
                    if (this.cbSingleFunction.Checked == true)
                    {
                        if (!(this.CheckSingleRow()))
                        {
                            Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_NoSingleGrp, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                            this.cbSingleFunction.EditDataItemValueSet(0, ((SalString)"N").ToHandle());
                        }
                    }
                }
                else
                {
                    if (this.cbSingleFunction.Checked == false)
                    {
                        if (this.CheckSingleRow())
                        {
                            Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_SingleGrpReq, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                            this.cbSingleFunction.EditDataItemValueSet(1, ((SalString)"Y").ToHandle());
                        }
                    }
                    if (this.cbSingleFunction.Checked == true)
                    {
                        if (!(this.CheckSingleRow()))
                        {
                            Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_NoSingleGrp, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                            this.cbSingleFunction.EditDataItemValueSet(0, ((SalString)"N").ToHandle());
                        }
                    }
                }
            }
            e.Return = Sal.SendClassMessage(Sys.SAM_Click, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblVoucherTypeDetail_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_CreateComplete:
                    this.tblVoucherTypeDetail_OnSAM_CreateComplete(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove:
                    this.tblVoucherTypeDetail_OnPM_DataRecordRemove(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_CreateComplete event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherTypeDetail_OnSAM_CreateComplete(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Sys.SAM_CreateComplete, Sys.wParam, Sys.lParam))
            {
                DbPLSQLBlock(@" {0} := &AO.Automatic_Allotment_API.DECODE('N')  ;
                                {1} := &AO.Function_Group_API.Get_Description('R');",
                                this.QualifiedVarBindName("lsIIDNo"), this.QualifiedVarBindName("lsIIDR"));
                e.Return = true;
                return;
            }
            e.Return = false;
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataRecordRemove event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherTypeDetail_OnPM_DataRecordRemove(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove, Sys.wParam, Sys.lParam))
            {
                if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire)
                {
                    e.Return = true;
                    return;
                }
                if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
                {
                    if (!(Sal.TblAnyRows(this.i_hWndSelf, 0, Sys.ROW_MarkDeleted)))
                    {
                        this.DisableVouSelection();
                    }
                }
            }
            e.Return = true;
            return;
            #endregion
        }
        #endregion

        #region Late Bind Methods

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalBoolean vrtDataRecordGetDefaults()
        {
            return this.DataRecordGetDefaults();
        }

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

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        
        #endregion

        #region ChildTable-tblVoucherTypeDetail

        #region Window Variables
        public SalString IsVouTypeUsed = "";
        public SalString lsIIDNo = "";
        public SalString lsIIDR = "";
        public SalString sVoucherFunction = "";
        public SalString sFunctionGroup = "";
        public SalString sAutoAllot = "";
        public SalString sDummy1 = "";
        public SalString sSingleFunction = "";
        public SalBoolean bSingle = false;
        #endregion

        #region Methods

        /// <summary>
        /// Gets client default values for NEW records
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean tblVoucherTypeDetail_DataRecordGetDefaults()
        {
            tblVoucherTypeDetail_colsCompany.Text = this.i_sCompany;
            tblVoucherTypeDetail_colsCompany.EditDataItemSetEdited();
            tblVoucherTypeDetail_colsOptionalAutoBalance.EditDataItemValueSet(1, ((SalString)"N").ToHandle());
            tblVoucherTypeDetail_colsStoreOriginal.EditDataItemValueSet(1, ((SalString)"N").ToHandle());
            return true;
        }

        /// <summary>
        /// Check if a Function Group exists
        /// </summary>
        /// <param name="p_sVoucherFunction"></param>
        /// <returns></returns>
        public virtual SalBoolean CheckFunctionGroup(SalString p_sVoucherFunction)
        {
            sVoucherFunction = p_sVoucherFunction;
            return ( sVoucherFunction == SalString.Null || DbPLSQLBlock("&AO.Function_Group_API.Exist({0} IN)", this.QualifiedVarBindName("sVoucherFunction")));
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean CheckSingleRow()
        {
            #region Local Variables
            SalNumber nMinRow = 0;
            SalNumber nMaxRow = 0;
            SalNumber nPosRow = 0;
            SalNumber nMinRange = 0;
            SalNumber nMaxRange = 0;
            #endregion

            Sal.TblQueryScroll(tblVoucherTypeDetail, ref nPosRow, ref nMinRange, ref nMaxRange);
            nMinRow = nMinRange;
            nMaxRow = nMaxRange;
            return !((nMinRow != nMaxRow) && nMaxRow > 0);        
        }

        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalNumber tblVoucherTypeDetail_DataRecordNew(SalNumber nWhat)
        {
            switch (nWhat)
            {
                case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                    if (Sal.TblAnyRows(tblVoucherTypeDetail, 0, 0))
                    {
                        bSingle = this.cbSingleFunction.Checked;
                    }
                    else
                    {
                        bSingle = false;
                    }
                    return ((bool)((cDataSource)this).DataRecordNew(nWhat)) && (!(Sal.IsNull(this.cmbVoucherType))) && (tblVoucherTypeDetail_colsSingleVoucher.Text != "Y") && (bSingle != true);

                case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                    return ((cChildTableFin)tblVoucherTypeDetail).DataRecordNew(nWhat);

                case Ifs.Fnd.ApplicationForms.Const.METHOD_GetType:
                    return ((cDataSource)tblVoucherTypeDetail).DataRecordNew(nWhat);
            }
            return 0;
        
        }

        /// <summary>
        /// </summary>
        /// <param name="p_sFunctionGroup"></param>
        /// <returns></returns>
        public virtual SalNumber GetAutoAllotSingleFunc(SalString p_sFunctionGroup)
        {  
            sFunctionGroup = p_sFunctionGroup;
            if (DbPLSQLBlock(@"&AO.Voucher_Type_Detail_API.Is_Automatic_Allot_Required__({0} INOUT, {2} IN);
                                &AO.Voucher_Type_Detail_API.Is_Single_Function_Required__({1} INOUT, {2} IN);",
                                this.tblVoucherTypeDetail_colsAutomaticAllot.QualifiedBindName,
                                this.tblVoucherTypeDetail_colsSingleVoucher.QualifiedBindName, 
                                this.QualifiedVarBindName("sFunctionGroup") ))
            {
                if (tblVoucherTypeDetail_colsAutomaticAllot.Text == "Y")
                {
                    if (!(this.cbAutoAllotment.Checked))
                    {
                        if (Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_AutoAllotReq, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok))
                        {
                            this.cbAutoAllotment.EditDataItemValueSet(1, ((SalString)"Y").ToHandle());
                        }
                    }
                }
                if (CheckSingleRow() && tblVoucherTypeDetail_colsSingleVoucher.Text == "Y")
                {
                    if (!(this.cbSingleFunction.Checked))
                    {
                        if (Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_SingleGrpReq, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok))
                        {
                            this.cbSingleFunction.EditDataItemValueSet(1, ((SalString)"Y").ToHandle());
                        }
                    }
                }
            }
                
            return true;
            
          
        }
        #endregion

        #region Window Actions

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblVoucherTypeDetail_colsVoucherFunction_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.tblVoucherTypeDetail_colsVoucherFunction_OnSAM_SetFocus(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblVoucherTypeDetail_colsVoucherFunction_OnPM_DataItemValidate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovUserOrderBy:
                    e.Handled = true;
                    e.Return = ((SalString)"FUNCTION_GROUP").ToHandle();
                    return;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherTypeDetail_colsVoucherFunction_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (frmVoucherType.FromHandle(this.tblVoucherTypeDetail_colsVoucherFunction.i_hWndFrame).bInternal)
            {
                this.tblVoucherTypeDetail_colsVoucherFunction.p_sLovReference = "FUNCTION_GROUP_INT";
            }
            else
            {
                this.tblVoucherTypeDetail_colsVoucherFunction.p_sLovReference = "FUNCTION_GROUP";
            }
            e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherTypeDetail_colsVoucherFunction_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam))
            {
                if (this.CheckFunctionGroup(this.tblVoucherTypeDetail_colsVoucherFunction.Text))
                {
                    if (!(Sal.IsNull(this.tblVoucherTypeDetail_colsVoucherFunction)))
                    {
		        if ((this.tblVoucherTypeDetail_colsVoucherFunction.Text == "C") || (this.tblVoucherTypeDetail_colsVoucherFunction.Text == "Z") || (this.tblVoucherTypeDetail_colsVoucherFunction.Text == "H") || (this.tblVoucherTypeDetail_colsVoucherFunction.Text == "P") || (this.tblVoucherTypeDetail_colsVoucherFunction.Text == "PPC")) 
                        {
                            this.tblVoucherTypeDetail_colsStoreOriginal.Text = "Y";
                            this.tblVoucherTypeDetail_colsStoreOriginal.EditDataItemSetEdited();
                        }
                        else
                        {
                            this.tblVoucherTypeDetail_colsStoreOriginal.Text = "N";
                            this.tblVoucherTypeDetail_colsStoreOriginal.EditDataItemSetEdited();
                        }
                        if ((this.tblVoucherTypeDetail_colsVoucherFunction.Text == "M") || (this.tblVoucherTypeDetail_colsVoucherFunction.Text == "K") || (this.tblVoucherTypeDetail_colsVoucherFunction.Text == "Q"))
                        {
                            Sal.EnableWindow(this.tblVoucherTypeDetail_colsRowGrpValidation);
                            Sal.EnableWindow(this.tblVoucherTypeDetail_colsRefMandetory);
                        }
                        else
                        {
                            this.tblVoucherTypeDetail_colsRowGrpValidation.Text = "N";
                            Sal.DisableWindow(this.tblVoucherTypeDetail_colsRowGrpValidation);
                            this.tblVoucherTypeDetail_colsRefMandetory.Text = "N";
                            Sal.DisableWindow(this.tblVoucherTypeDetail_colsRefMandetory);
                        }
                        this.EnableVouSelection();
                        this.GetAutoAllotSingleFunc(this.tblVoucherTypeDetail_colsVoucherFunction.Text);
                    }
                    e.Return = Sys.VALIDATE_Ok;
                    return;
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
        private void tblVoucherTypeDetail_colsStoreOriginal_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_Click:
                    this.tblVoucherTypeDetail_colsStoreOriginal_OnSAM_Click(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_Click event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherTypeDetail_colsStoreOriginal_OnSAM_Click(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
	if ((this.tblVoucherTypeDetail_colsVoucherFunction.Text == "C") || (this.tblVoucherTypeDetail_colsVoucherFunction.Text == "Z") || (this.tblVoucherTypeDetail_colsVoucherFunction.Text == "H") || (this.tblVoucherTypeDetail_colsVoucherFunction.Text == "P") || (this.tblVoucherTypeDetail_colsVoucherFunction.Text == "PPC")) 
            {
                Sal.DisableWindow(this.tblVoucherTypeDetail_colsStoreOriginal);
            }
            else
            {
                Sal.EnableWindow(this.tblVoucherTypeDetail_colsStoreOriginal);
            }
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblVoucherTypeDetail_colsRowGrpValidation_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_AnyEdit:
                    this.tblVoucherTypeDetail_colsRowGrpValidation_OnSAM_AnyEdit(sender, e);
                    break;

                case Sys.SAM_Click:
                    this.tblVoucherTypeDetail_colsRowGrpValidation_OnSAM_Click(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_AnyEdit event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherTypeDetail_colsRowGrpValidation_OnSAM_AnyEdit(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.tblVoucherTypeDetail_colsRowGrpValidation.Text == "N")
            {
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("VOUCHER_TYPE_DETAIL_API.Vou_With_Row_Group_Id_Exists__", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                    if (this.tblVoucherTypeDetail_colsRowGrpValidation.DbPLSQLBlock(cSessionManager.c_hSql, " :i_hWndFrame.frmVoucherType.sDummy1 := " + cSessionManager.c_sDbPrefix + "VOUCHER_TYPE_DETAIL_API.Vou_With_Row_Group_Id_Exists__(" + ":i_hWndFrame.tblVoucherTypeDetail_colsCompany," +
                        ":i_hWndFrame.tblVoucherTypeDetail_colsVoucherType)"))
                    {
                        if (this.sDummy1 == "TRUE")
                        {
                            if (Sys.IDNO == Ifs.Fnd.ApplicationForms.Int.AlertBox("REMOVEROWGRPID: There are vouchers of this type with Row Group ID in the Hold table. The Row Group ID will be removed. Do you want to continue?", Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Warning,
                                Ifs.Fnd.ApplicationForms.Const.WARNING_YesNo))
                            {
                                this.tblVoucherTypeDetail_colsRowGrpValidation.Text = "Y";
                            }
                        }
                    }
                }
            }
            Sal.SendClassMessage(Sys.SAM_AnyEdit, Sys.wParam, Sys.lParam);
            #endregion
        }

        /// <summary>
        /// SAM_Click event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherTypeDetail_colsRowGrpValidation_OnSAM_Click(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if ((this.tblVoucherTypeDetail_colsVoucherFunction.Text == "M") || (this.tblVoucherTypeDetail_colsVoucherFunction.Text == "K") || (this.tblVoucherTypeDetail_colsVoucherFunction.Text == "Q"))
            {
                Sal.EnableWindow(this.tblVoucherTypeDetail_colsRowGrpValidation);
            }
            else
            {
                this.tblVoucherTypeDetail_colsRowGrpValidation.Text = "N";
                Sal.DisableWindow(this.tblVoucherTypeDetail_colsRowGrpValidation);
            }
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblVoucherTypeDetail_colsRefMandetory_WindowActions(object sender, WindowActionsEventArgs e)
        {

        }

        /// <summary>
        /// SAM_Click event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblVoucherTypeDetail_colsRefMandetory_OnSAM_Click(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if ((this.tblVoucherTypeDetail_colsVoucherFunction.Text == "M") || (this.tblVoucherTypeDetail_colsVoucherFunction.Text == "K") || (this.tblVoucherTypeDetail_colsVoucherFunction.Text == "Q"))
            {
                Sal.EnableWindow(this.tblVoucherTypeDetail_colsRefMandetory);
            }
            else
            {
                this.tblVoucherTypeDetail_colsRefMandetory.Text = "N";
                Sal.DisableWindow(this.tblVoucherTypeDetail_colsRefMandetory);
            }
            #endregion
        }
        #endregion

        #region Window Events

        private void tblVoucherTypeDetail_DataRecordGetDefaultsEvent(object sender, FndReturnEventArgsSalBoolean e)
        {
            e.Handled = true;
            e.ReturnValue = this.tblVoucherTypeDetail_DataRecordGetDefaults();
        }

        private void tblVoucherTypeDetail_DataRecordNewEvent(object sender, cDataSource.DataRecordNewEventArgs e)
        {
            e.Handled = true;
            e.ReturnValue = this.tblVoucherTypeDetail_DataRecordNew(e.nWhat);
        }
        #endregion
        #endregion

        #region Event Handlers

        private void menuItem__Voucher_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            if (Sal.IsNull(cmbVoucherType))
            {
                ((FndCommand)sender).Enabled = false;
            }
            else if (SourceStateGet() == 2)
            {
                ((FndCommand)sender).Enabled = false;
            }
            else
            {
                ((FndCommand)sender).Enabled = true;
            }
        }

        private void menuItem__Voucher_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            
            #region Local Variables
            SalArray<SalString> sItemNames      = new SalArray<SalString>();
            SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
            SalNumber nYear                     = 0;
            SalString sName                     = "";
            #endregion


            Sal.WaitCursor(true);
            sItemNames[0]    = "VOUCHER_TYPE";
            hWndItems[0]     = cmbVoucherType;
            sItemNames[1]    = "COMPANY";
            hWndItems[1]     = dfsCompany;
            Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("VOUCHER_TYPE", this, sItemNames, hWndItems);
            SessionNavigate(Pal.GetActiveInstanceName("frmVouNoSerial"));
            Sal.WaitCursor(false);
        }

        private void menuItem__Excluded_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            if (Sal.IsNull(cmbVoucherType))
            {
                ((FndCommand)sender).Enabled = false;
            }
            else if (SourceStateGet() == 2)
            {
                ((FndCommand)sender).Enabled = false;
            }
            else if (!Int.IsIntLedInstalled)
            {
                ((FndCommand)sender).Enabled = false;
            }
            else if (!dfLedgerID.Text.Equals("*"))
            {
                ((FndCommand)sender).Enabled = false;
            }
            else
            {
                ((FndCommand)sender).Enabled = true;
            }
        }

        private void menuItem__Excluded_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            #region Local Variables
            SalArray<SalString> sItemNames      = new SalArray<SalString>();
            SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
            SalNumber nYear                     = 0;
            SalString sName                     = "";
            #endregion

            
            using (SignatureHints hints = SignatureHints.NewContext())
            {
                hints.Add("Voucher_Type_Api.Is_Voucher_Type_Excluded", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                DbPLSQLBlock(cSessionManager.c_hSql, " :i_hWndFrame.frmVoucherType.sIsExcluded := &AO.Voucher_Type_Api.Is_Voucher_Type_Excluded (\r\n" +
                    "								   :i_hWndFrame.frmVoucherType.dfsCompany,\r\n" +
                    "								   :i_hWndFrame.frmVoucherType.cmbVoucherType.i_sMyValue )");
            }
            if (sIsExcluded != "FALSE")
            {
                Sal.WaitCursor(true);
                sItemNames[0] = "VOUCHER_TYPE";
                hWndItems[0]  = cmbVoucherType;
                sItemNames[1] = "COMPANY";
                hWndItems[1]  = dfsCompany;
                Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("VOUCHER_TYPE", this, sItemNames, hWndItems);
                SessionNavigate(Pal.GetActiveInstanceName("frmExcludeFromIL"));
                Sal.WaitCursor(false);
            }
            else
            {
                Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_TypeNotExcluded, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
            }
        }

        private void menuItem_Translation_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            
            ((FndCommand)sender).Enabled = Translation(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem_Translation_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            Translation(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem_Change_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Sys.lParam);
        }

        private void menuItem_Change_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Sys.lParam);
        }

        private void menuItem__Voucher_1_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            if (Sal.IsNull(cmbVoucherType))
            {
                ((FndCommand)sender).Enabled = false;
            }
            else if (SourceStateGet() == 2)
            {
                ((FndCommand)sender).Enabled = false;
            }
            else
            {
                ((FndCommand)sender).Enabled = true;
            }
        }

        private void menuItem_Translation_1_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = Translation(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem_Translation_1_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            Translation(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem_Change_1_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Sys.lParam);
        }

        private void menuItem_Change_1_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Sys.lParam);
        }

        #endregion

    }
}
