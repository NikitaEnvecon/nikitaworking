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
    [FndWindowRegistration("VOUCHER_TYPE", "VoucherType")]
    public partial class frmVouNoSerial : cFormWindowFin
    {
        #region Window Variables
        public SalNumber nYear = 0;
        public SalNumber nTemp = 0;
        public SalString sCompanyName = "";
        public SalString sModule = "";
        public SalString sLu = "";
        public SalString lsAttribute = "";
        public SalString lsPeriodUsed = "";
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public frmVouNoSerial()
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
        public new static frmVouNoSerial FromHandle(SalWindowHandle handle)
        {
            return ((frmVouNoSerial)SalWindow.FromHandle(handle, typeof(frmVouNoSerial)));
        }
        #endregion

        #region Methods

        /// <summary>
        /// </summary>
        /// <returns></returns>

        

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public new SalBoolean SetWindowTitle()
        {
            #region Actions
            using (new SalContext(this))
            {
                if (cmbVoucherType.Text == Ifs.Fnd.ApplicationForms.Const.strNULL)
                {
                    Sal.SetWindowText(this, i_sCompany + " - " + Properties.Resources.WH_frmVouNoSerial);
                }
                else
                {
                    Sal.SetWindowText(this, i_sCompany + " - " + Properties.Resources.WH_frmVouNoSerial + " - " + cmbVoucherType.Text);
                }
            }

            return 0;
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
                        if (cmbVoucherType.Text != Ifs.Fnd.ApplicationForms.Const.strNULL)
                        {
                            lsAttribute = "'" + cmbVoucherType.Text + "'";
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
        public virtual SalNumber EnableDisablePeriod()
        {
            #region Actions
            using (new SalContext(this))
            {
                lsPeriodUsed = SalString.Null;
                DbPLSQLBlock("{0} := &AO.COMPANY_FINANCE_API.Get_Use_Vou_No_Period({1} IN );", this.QualifiedVarBindName("lsPeriodUsed"), this.QualifiedVarBindName("i_sCompany"));
                if (lsPeriodUsed == "FALSE")
                { Sal.HideWindow(tblSeries_colnPeriod); }
                else
                { Sal.ShowWindow(tblSeries_colnPeriod); }
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
        private void frmVouNoSerial_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate:
                    this.frmVouNoSerial_OnPM_DataSourcePopulate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave:
                    this.frmVouNoSerial_OnPM_DataSourceSave(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataSourcePopulate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmVouNoSerial_OnPM_DataSourcePopulate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Sys.wParam, Sys.lParam))
            {
                if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
                {
                    Sal.TblClearSelection(this.tblSeries);
                    // Bug 76574, Removed the call to EnableDisablePeriod
                }
                e.Return = true;
                return;
            }
            e.Return = false;
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataSourceSave event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmVouNoSerial_OnPM_DataSourceSave(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                if (this.SaveData())
                {
                    e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Sys.wParam, Sys.lParam);
                    return;
                }
                else
                {
                    e.Return = false;
                    return;
                }
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }
        #endregion

        #region Late Bind Methods

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalBoolean vrtSetWindowTitle()
        {
            return this.SetWindowTitle();
        }

        
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public override SalNumber vrtActivate(fcURL URL)
        {
            #region Local Variables
            SalString sComp = "";
            SalArray<SalString> sValues = new SalArray<SalString>();
            SalNumber nValues = 0;
            #endregion

            using (new SalContext(this))
            {
                if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.RecCountGet() > 0)
                {
                    Sal.WaitCursor(true);
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet("COMPANY", sValues);
                    nValues = sValues.GetUpperBound(1);
                    if (nValues > -1)
                    {
                        sComp = sValues[0];
                        if (sComp != SalString.Null)
                        {
                            i_sCompany = sComp;
                        }
                    }
                    UserGlobalValueSet("COMPANY", i_sCompany);
                    // Bug 76574, Begin
                    EnableDisablePeriod();
                    // Bug 76574, End
                    InitFromTransferredData();
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();
                    SetWindowTitle();
                    Sal.WaitCursor(false);
                    return false;
                }
                UserGlobalValueGet("COMPANY", ref i_sCompany);
                EnableDisablePeriod();
                SetWindowTitle();
                return base.Activate(URL);
            }
        }
        #endregion

        #region tblSeries

        #region Methods

        /// <summary>
        /// Gets client default values for NEW records
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean tblSeries_DataRecordGetDefaults()
        {
            this.tblSeries_colCompany.Text = this.dfCompany.Text;
            this.tblSeries_colCompany.EditDataItemSetEdited();
            this.tblSeries_colVoucherType.Text = this.cmbVoucherType.Text;
            this.tblSeries_colVoucherType.EditDataItemSetEdited();
            return true;  
        }

        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalNumber Create(SalNumber nWhat)
        {
            #region Local Variables
            SalArray<SalNumber> nYear = new SalArray<SalNumber>();
            SalArray<SalString> sVoucherType = new SalArray<SalString>();
            #endregion

            #region Actions
        
            switch (nWhat)
            {
                case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                    Sal.WaitCursor(true);
                    SalNumber nRow = Sys.TBL_MinRow;
                    SalNumber nIndex = 0;
                    while (Sal.TblFindNextRow(tblSeries, ref nRow, Sys.ROW_Selected, 0))
                    {
                        Sal.TblSetContext(tblSeries, nRow);
                        sVoucherType[nIndex] = this.cmbVoucherType.Text;
                        nYear[nIndex] = tblSeries_colYear.Number;
                        nIndex = nIndex + 1;
                    }
                    Sal.WaitCursor(false);
                    return dlgCreateYear.ModalDialog(Ifs.Fnd.ApplicationForms.Int.Explorer.ExplorerForm, sVoucherType, nYear, tblSeries_colCompany.Text);
                    return 0;

                case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                    if (Sal.SendMsg(i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Sys.wParam, Sys.lParam))
                    {
                        return 0;
                    }
                    return Sal.TblAnyRows(tblSeries, Sys.ROW_Selected, 0);
            }
      

            return 0;
            #endregion
        }

        /// <summary>
        /// Stub for all user methods.
        /// Should be overridden with own method for all container classes.
        /// (other classen can override PM_UserMethod instead)
        /// </summary>
        /// <param name="nWhat"></param>
        /// <param name="sMethod"></param>
        /// <returns></returns>
        public virtual SalNumber tblSeries_UserMethod(SalNumber nWhat, SalString sMethod)
        {
            if (sMethod == "Create")
            { return this.Create(nWhat); }
            return 0;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean SaveData()
        {
            #region Local Variables
            SalNumber nRow = 0;
            SalNumber nRow1 = 0;
            SalNumber FromNumber1 = 0;
            SalNumber UntilNumber1 = 0;
            SalNumber FromNumber2 = 0;
            SalNumber UntilNumber2 = 0;
            SalNumber colYear = 0;
            SalNumber colSerieFrom = 0;
            SalNumber colSerieUntil = 0;
            SalNumber Year1 = 0;
            SalNumber Year2 = 0;
            #endregion

            #region Actions
            nRow = Sys.TBL_MinRow;
            while (true)
            {
                if (Sal.TblFindNextRow(tblSeries, ref nRow, 0, Sys.ROW_MarkDeleted))
                {
                    Sal.TblSetContext(tblSeries, nRow);
                    Year1 = this.tblSeries_colYear.Number;
                    FromNumber1 = this.tblSeries_colSerieFrom.Number;
                    UntilNumber1 = this.tblSeries_colSerieUntil.Number;
                    nRow1 = nRow;
                    while (true)
                    {
                        if (Sal.TblFindPrevRow(tblSeries, ref nRow1, 0, Sys.ROW_MarkDeleted))
                        {
                            Sal.TblSetContext(tblSeries, nRow1);
                            Year2 = this.tblSeries_colYear.Number;
                            FromNumber2 = this.tblSeries_colSerieFrom.Number;
                            UntilNumber2 = this.tblSeries_colSerieUntil.Number;
                            if (!(VouSerialUntil(FromNumber2, UntilNumber2, FromNumber1, UntilNumber1, Year1, Year2)))
                            {
                                Sal.TblSetFocusRow(tblSeries, nRow);
                                return false;
                            }
                        }
                        else
                        { break; }
                    }
                }
                else
                { break; }
            }
            return true;
        
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="FromNumber1">From Voucher# for first period</param>
        /// <param name="UntilNumber1">To Voucher# for first period</param>
        /// <param name="FromNumber2">From Voucher# for second period</param>
        /// <param name="UntilNumber2">To Voucher# for second period</param>
        /// <param name="Year1"></param>
        /// <param name="Year2"></param>
        /// <returns></returns>
        public virtual SalBoolean VouSerialUntil(SalNumber FromNumber1, SalNumber UntilNumber1, SalNumber FromNumber2, SalNumber UntilNumber2, SalNumber Year1, SalNumber Year2)
        {

            if (Year2 != Year1)
            { return true; }
            else
            {
                if (FromNumber2 > UntilNumber1 || UntilNumber2 < FromNumber1)
                { return true; }
                else
                {
                    Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_VouSerialValidate, Properties.Resources.WH_frmVouNoSerial, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                }
            }
            return false;
        }
        #endregion

        #region Window Actions

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblSeries_colYear_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_Validate:
                    this.tblSeries_colYear_OnSAM_Validate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_Validate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblSeries_colYear_OnSAM_Validate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.nTemp = this.tblSeries_colYear.Number.ToString(0).Length;
            if (this.nTemp == 0)
            {
                e.Return = true;
                return;
            }
            if (this.nTemp < 4)
            {
                Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_YearError1, Properties.Resources.WH_frmVouNoSerial, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
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
        private void tblSeries_colnPeriod_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom:
                    this.tblSeries_colnPeriod_OnPM_DataItemZoom(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemZoom event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblSeries_colnPeriod_OnPM_DataItemZoom(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire)
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
        private void tblSeries_colSerieFrom_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblSeries_colSerieFrom_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblSeries_colSerieFrom_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (!(Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam)))
            {
                e.Return = Sys.VALIDATE_Cancel;
                return;
            }
            if (this.tblSeries_colSerieFrom.Number < 0)
            {
                Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_SerieError1, Properties.Resources.WH_frmVouNoSerial, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                e.Return = Sys.VALIDATE_Cancel;
                return;
            }
            this.tblSeries_colActualNumber.Number = this.tblSeries_colSerieFrom.Number;
            this.tblSeries_colActualNumber.EditDataItemSetEdited();
            e.Return = true;
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblSeries_colSerieUntil_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_Validate:
                    this.tblSeries_colSerieUntil_OnSAM_Validate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_Validate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblSeries_colSerieUntil_OnSAM_Validate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.tblSeries_colSerieUntil.Number < 0)
            {
                Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_SerieError2, Properties.Resources.WH_frmVouNoSerial, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                e.Return = false;
                return;
            }
            #endregion
        }
        #endregion

        #region Event Handlers


        private void tblSeries_DataRecordGetDefaultsEvent(object sender, FndReturnEventArgsSalBoolean e)
        {
            e.Handled = true;
            e.ReturnValue = this.tblSeries_DataRecordGetDefaults();
        }

        private void tblSeries_UserMethodEvent(object sender, cMethodManager.UserMethodEventArgs e)
        {
            e.Handled = true;
            e.ReturnValue = this.tblSeries_UserMethod(e.nWhat, e.sMethod);
        }


        #endregion
        #endregion
        
        #region Event Handlers

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

        private void menuItem_User_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = Sal.TblAnyRows(Sys.hWndForm, Sys.ROW_Selected, 0);
        }

        private void menuItem_User_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            #region Local Variables
            SalArray<SalString> sItemNames = new SalArray<SalString>();
            SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
            SalString sVoucherType = "";
            SalString sName = "";
            #endregion


            Sal.WaitCursor(true);
            sVoucherType    = tblSeries_colVoucherType.Text;
            sItemNames[0]   = "ACCOUNTING_YEAR";
            hWndItems[0]    = tblSeries_colYear;
            sItemNames[1]   = "COMPANY";
            hWndItems[1]    = tblSeries_colCompany;
            sItemNames[2]   = "PERIOD";
            hWndItems[2]    = tblSeries_colnPeriod;

            Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("USER_GROUPD_PER_VOU_TYPE", frmVouNoSerial.FromHandle(i_hWndFrame).tblSeries, sItemNames, hWndItems);
            cMessage mParam = new cMessage();
            mParam.AddAttribute("COMPANY", i_sCompany);
            mParam.AddAttribute("VOUCHER_TYPE", sVoucherType);
            SessionNavigateWithParams(Pal.GetActiveInstanceName("frmVouTyUG"), mParam);
            Sal.WaitCursor(false);

        }

        private void menuItem_Create_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            // TODO: Rewrite command event handler not to use tblSeries_UserMethod.
            // Place the logic in tblSeries_UserMethod directly in this event handler.
            ((FndCommand)sender).Enabled = Sal.SendMsg(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, ((SalString)"Create").ToHandle());
        
        }

        private void menuItem_Create_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            // TODO: Rewrite command event handler not to make use of tblSeries_UserMethod.
            // Place the logic in tblSeries_UserMethod directly in this event handler.
            Sal.PostMsg(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, ((SalString)"Create").ToHandle());
        }

        private void menuItem_Change_1_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = ChangeCompany(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem_Change_1_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            ChangeCompany(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);

        }

        private void menuItem_User_1_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = Sal.TblAnyRows(frmVouNoSerial.FromHandle(Sys.hWndForm).tblSeries, Sys.ROW_Selected, 0);
        }

        private void menuItem_User_1_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            #region Local Variables
            SalArray<SalString> sItemNames      = new SalArray<SalString>();
            SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
            SalString sVoucherType              = "";
            SalString sName                     = "";
            #endregion


            Sal.WaitCursor(true);
            sVoucherType    = tblSeries_colVoucherType.Text;
            sItemNames[0]   = "ACCOUNTING_YEAR";
            hWndItems[0]    = tblSeries_colYear;
            sItemNames[1]   = "COMPANY";
            hWndItems[1]    = tblSeries_colCompany;
            sItemNames[2]   = "PERIOD";
            hWndItems[2]    = tblSeries_colnPeriod;

            Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("USER_GROUPD_PER_VOU_TYPE", frmVouNoSerial.FromHandle(i_hWndFrame).tblSeries, sItemNames, hWndItems);
            cMessage mParam = new cMessage();
            mParam.AddAttribute("COMPANY", i_sCompany);
            mParam.AddAttribute("VOUCHER_TYPE", sVoucherType);
            SessionNavigateWithParams(Pal.GetActiveInstanceName("frmVouTyUG"), mParam);
            Sal.WaitCursor(false);

        }

        private void menuItem_Translation_1_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {

            ((FndCommand)sender).Enabled = Translation(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);

        }

        private void menuItem_Translation_1_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            Translation(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem_Change_2_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Sys.lParam);
        }

        private void menuItem_Change_2_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Sys.lParam);

        }

        #endregion



       

    }
}
