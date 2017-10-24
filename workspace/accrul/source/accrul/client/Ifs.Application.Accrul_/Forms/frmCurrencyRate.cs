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
// 140217 Charlk  PBFI-4861,Modified tblRates_colConvFactor to insertable when copy or duplicate is executed.
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
    [FndWindowRegistration("CURRENCY_RATE", "CurrencyRate")]
    public partial class frmCurrencyRate : cFormWindowFin
    {
        #region Window Variables
        public SalNumber nDecimals = 0;
        public SalString sCompanyName = "";
        public SalArray<SalString> sPlaceHolders = new SalArray<SalString>();
        public SalArray<SalString> sChanges = new SalArray<SalString>();
        public SalString sT = "";
        public SalString sID = "";
        public SalNumber nNumChanges = 0;
        public SalString lsStmt = "";
        public SalString lsTemp1 = "";
        public SalNumber nTemp1 = 0;
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public frmCurrencyRate()
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
        public new static frmCurrencyRate FromHandle(SalWindowHandle handle)
        {
            return ((frmCurrencyRate)SalWindow.FromHandle(handle, typeof(frmCurrencyRate)));
        }
        #endregion

        #region Methods

        /// <summary>
        /// </summary>
        /// <returns></returns>

       
       

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public new SalString GetWindowTitle()
        {
            #region Actions
            using (new SalContext(this))
            {
                return Properties.Resources.WH_frmCurrencyRate;
            }
            #endregion
        }

        protected virtual SalBoolean ChangeCompany(SalNumber nMethod)
        {

            #region Actions
            using (new SalContext(this))
            {
                if (nMethod == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire)
                {
                    return Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Sys.lParam);

                }
                else
                {
                    return Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Sys.lParam); ;
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
        private void frmCurrencyRate_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew:
                    e.Handled = true;
                    e.Return = false;
                    return;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove:
                    e.Handled = true;
                    e.Return = false;
                    return;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate:
                    this.frmCurrencyRate_OnPM_DataSourcePopulate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_User:
                    e.Handled = true;
                    // Bug 82855: Added IP:Hint.NoSqlParsing
                    // Statement parser was suppressed for this database call during porting
                    using (SignatureHints hints = SignatureHints.NewContext())
                    {
                        hints.Add("Currency_Code_API.Get_Currency_Code_Attribute__", System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                        this.DbPLSQLBlock(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "Currency_Code_API.Get_Currency_Code_Attribute__(\r\n" +
                            "  :i_hWndFrame.frmCurrencyRate.tblRates.colConvFactor,\r\n" +
                            "  :i_hWndFrame.frmCurrencyRate.nDecimals,\r\n" +
                            "  :i_hWndFrame.frmCurrencyRate.tblRates.colCompany,\r\n" +
                            "  :i_hWndFrame.frmCurrencyRate.tblRates.colCurrencyCode)");
                    }
                    break;

                // Bug 82764 Removed PM_DataSourceSave
            }
            #endregion
        }

        /// <summary>
        /// PM_DataSourcePopulate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmCurrencyRate_OnPM_DataSourcePopulate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Sys.wParam, Sys.lParam))
            {
                if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
                {
                    Sal.TblClearSelection(this.tblRates);
                }
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
        private void cbValidRates_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_Click:
                    e.Handled = true;
                    Sal.SendMsg(this.tblRates, Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblRates_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_Create:
                    this.tblRates_OnSAM_Create(sender, e);
                    break;
                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordPaste:
                    this.tblRates_OnPM_DataRecordPaste(sender, e);
                    break;
                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordDuplicate:
                    this.tblRates_OnPM_DataRecordDuplicate(sender, e);
                    break;
                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew:
                    this.tblRates_OnPM_DataRecordNew(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataRecordNew event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblRates_OnPM_DataRecordNew(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew, Sys.wParam, Sys.lParam))
                {
                    Sal.SendMsg(frmCurrencyRate.FromHandle(this.tblRates.i_hWndFrame).tblRates_colValidFrom, Ifs.Fnd.ApplicationForms.Const.PAM_User, 0, 0);
                    this.tblRates_colValidFrom.DateTime = SalDateTime.Current;
                    this.tblRates_colValidFrom.EditDataItemSetEdited();
                    e.Return = true;
                }
            }
            else
            {
                e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew, Sys.wParam, Sys.lParam);
                return;
            }
            #endregion
        }

        private void tblRates_OnPM_DataRecordDuplicate(object sender, WindowActionsEventArgs e)
        {
            e.Handled = true;
            this.tblRates_colConvFactor.EditDataItemFlagSet(Ifs.Fnd.ApplicationForms.Const.FIELD_Insert, true);
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordDuplicate, Sys.wParam, Sys.lParam);
            this.tblRates_colConvFactor.EditDataItemFlagSet(Ifs.Fnd.ApplicationForms.Const.FIELD_Insert, false);
            return;
        }

             private void tblRates_OnPM_DataRecordPaste(object sender, WindowActionsEventArgs e)
        {
            e.Handled = true;
            this.tblRates_colConvFactor.EditDataItemFlagSet(Ifs.Fnd.ApplicationForms.Const.FIELD_Insert, true);
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordPaste, Sys.wParam, Sys.lParam);
            this.tblRates_colConvFactor.EditDataItemFlagSet(Ifs.Fnd.ApplicationForms.Const.FIELD_Insert, false);
           
            return;
        }

        /// <summary>
        /// SAM_Create event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblRates_OnSAM_Create(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SetWindowText(this.tblRates, Properties.Resources.WH_tblRates);
            e.Return = Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam);
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
        public override SalString vrtGetWindowTitle()
        {
            return this.GetWindowTitle();
        }

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public override SalNumber vrtActivate(fcURL URL)
        {
            #region Actions
            using (new SalContext(this))
            {
                if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.RecCountGet() > 0)
                {
                    InitFromTransferredData();
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();
                    Sal.SendMsg(cmbName, Sys.SAM_Click, 0, 0);
                    this.cbValidRates.Checked = false;
                    return false;
                }
                SetWindowTitle();
                return base.Activate(URL);
            }
            #endregion

        }
        #endregion

        #region ChildTable-tblRates

        #region Window Variables
        public SalNumber nRow = 0;
        #endregion

        #region Methods

            

        /// <summary>
        /// This function sets default values for some form's fields
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber DataRecordGetDefaults()
        {
            #region Actions
            tblRates_colConvFactor.EditDataItemSetEdited();
            tblRates_colsRefCurrencyCode.Text = this.dfsRefCurrencyCode.Text;
            tblRates_colsRefCurrencyCode.EditDataItemSetEdited();
            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="hSql"></param>
        /// <returns></returns>
        public virtual SalBoolean DataRecordExecuteNew(SalSqlHandle hSql)
        {
            tblRates_colConvFactor.EditDataItemSetEdited();
            return ((cDataSource)tblRates).DataRecordExecuteNew(hSql);
        }

        /// <summary>
        /// Applications and the framework call the DataSourcePopulateIt function
        /// to populate a top-level window.
        /// COMMENTS:
        /// The DataSourcePopulateIt does not check with the user to save any changes. To
        /// check with the user, applications should use the DataSourcePopulate function.
        /// </summary>
        /// <param name="nParam">
        /// Populate options
        /// Options for the poulate. Specify 0 for normal populate, POPULATE_Single - populate the data items only (ingorning record selection
        /// combo boxes) or POPULATE_KeepFocus - Used to populate for instance a child table and forcing the focus to stay in calling field.
        /// POPULATE_NoConfirm
        /// Do not ask user to confirm changes before populating
        /// POPULATE_UseQueryDialog
        /// Launch query dialog before populating
        /// POPULATE_Single
        /// Do not fill control selection boxes also
        /// Fill only data field part of all items
        /// </param>
        /// <returns>The return value is TRUE if the data source is populated successfully, FALSE otherwise.</returns>
        public virtual SalBoolean DataSourcePopulateIt(SalNumber nParam)
        {
            #region Local Variables
            SalBoolean bOk = false;
            #endregion

            #region Actions

            if (this.cbValidRates.Checked)
            {
                tblRates.p_sViewName = cSessionManager.c_sDbPrefix + "LATEST_CURRENCY_RATES";
            }
            else
            {
                tblRates.p_sViewName = cSessionManager.c_sDbPrefix + "CURRENCY_RATE";
            }
            bOk = ((cChildTable)tblRates).DataSourcePopulateIt(nParam);
            return bOk;
       
            #endregion
        }

            
        #endregion

        #region Window Actions

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblRates_colCurrencyCode_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblRates_colCurrencyCode_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblRates_colCurrencyCode_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam) == Sys.VALIDATE_Cancel)
            {
                e.Return = Sys.VALIDATE_Cancel;
                return;
            }
            if (this.tblRates_colCurrencyCode.Text == Ifs.Fnd.ApplicationForms.Const.strNULL)
            {
                e.Return = Sys.VALIDATE_Ok;
                return;
            }
            this.lsStmt = string.Format(@"&AO.Currency_Code_API.Get_Currency_Code_Attribute__({0} OUT,{1} OUT,{2} OUT,{3} IN,{4} IN )",
                 this.QualifiedVarBindName("lsTemp1"),
                 this.tblRates_colConvFactor.QualifiedBindName,
                 this.QualifiedVarBindName("nTemp1"),
                 this.QualifiedVarBindName("i_sCompany"),
                 this.tblRates_colCurrencyCode.QualifiedBindName);

            if (!(DbPLSQLBlock(this.lsStmt)))
            {
                e.Return = false;
                return;
            }
            
            e.Return = Sys.VALIDATE_Ok;
            return;
            #endregion
        }
        /// <summary>
        /// colValidFrom_WindowActions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colValidFrom_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PAM_User:
                    this.colValidFrom_OnPAM_User(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PAM_User event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colValidFrom_OnPAM_User(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.tblRates_colValidFrom.DateTime = SalDateTime.Current;
            this.tblRates_colValidFrom.EditDataItemSetEdited();
            e.Return = true;
            return;
            #endregion
        }
        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblRates_colRate_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.tblRates_colRate_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblRates_colRate_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.tblRates_colsRefCurrencyCode.Text == this.tblRates_colCurrencyCode.Text)
            {
                this.nRow = Sal.TblQueryContext(tblRates);
                if (Sal.TblQueryRowFlags(tblRates, this.nRow, Sys.ROW_New))
                {
                    e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled, Sys.wParam, Sys.lParam);
                    return;
                }
                else
                {
                    e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                    return;
                }
            }
            else
            {
                e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled, Sys.wParam, Sys.lParam);
                return;
            }
            #endregion
        }
        #endregion

        #region Window Events

        private void tblRates_DataRecordExecuteNewEvent(object sender, cDataSource.DataRecordExecuteNewEventArgs e)
        {
            e.Handled = true;
            e.ReturnValue = this.DataRecordExecuteNew(e.hSql);
        }

        private void tblRates_DataRecordGetDefaultsEvent(object sender, FndReturnEventArgsSalBoolean e)
        {
            e.Handled = true;
            e.ReturnValue = this.DataRecordGetDefaults();
        }

        private void tblRates_DataSourcePopulateItEvent(object sender, cDataSource.DataSourcePopulateItEventArgs e)
        {
            e.Handled = true;
            e.ReturnValue = this.DataSourcePopulateIt(e.nParam);
        }

        #endregion
 
        #endregion

        #region Event Handlers

        private void menuItem_Change_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = this.ChangeCompany(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem_Change_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            this.ChangeCompany(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem_Change_1_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Sys.lParam);
        }

        private void menuItem_Change_1_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Sys.lParam);
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
