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
    [FndWindowRegistration("TAX_CODES_PER_TAX_CLASS", "TaxCodesPerTaxClass")]
    public partial class frmTaxCodesPerTaxClass : cFormWindowFin
    {
        #region Window Variables
        public SalString sTaxHandlingValue = "";
        public SalNumber nCurrentRow = 0;
        public SalNumber nCurrentRowTemp = 0;
        public SalNumber nRow = 0;
        public SalString sStmt = "";
        public SalString sCountry = "";
        public SalArray<SalString> sItemNames = new SalArray<SalString>();
        public SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public frmTaxCodesPerTaxClass()
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
        public new static frmTaxCodesPerTaxClass FromHandle(SalWindowHandle handle)
        {
            return ((frmTaxCodesPerTaxClass)SalWindow.FromHandle(handle, typeof(frmTaxCodesPerTaxClass)));
        }
        #endregion

        #region Methods

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public new SalBoolean FrameStartupUser()
        {
            #region Local Variables
            SalNumber nRC = 0;
            SalNumber nItemIndex = 0;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                GetWindowTitle();
                // Insert new code here...
                return true;
            }
            #endregion
        }
        public override SalNumber vrtActivate(fcURL URL)
        {
            #region Actions
            using (new SalContext(this))
            {
                return base.Activate(URL);
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
                return Properties.Resources.WH_frmTaxCodesPerTaxClass;
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
        private void tblTaxCodes_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemNew:
                    this.tblTaxCodes_OnPM_DataItemNew(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemNew event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblTaxCodes_OnPM_DataItemNew(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew, Sys.wParam, Sys.lParam))
            {
                if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
                {
                    this.tblTaxCodes_colsTaxClassId.Text = this.ccTaxClass.i_sMyValue;
                    this.tblTaxCodes_colValidFrom.DateTime = SalDateTime.Current;
                    this.tblTaxCodes_colValidFrom.EditDataItemSetEdited();
                }
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

        #region tblTaxCodes-ChildTable

        #region Methods

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber FetchValidFrom()
        {       
            return (DbPLSQLBlock(@"{0} := &AO.Statutory_Fee_API.Get_Valid_From({1} IN, {2} IN );",
                                                this.tblTaxCodes_colValidFrom.QualifiedBindName,
                                                this.tblTaxCodes_colsCompany.QualifiedBindName,
                                                this.tblTaxCodes_colsFeeCode.QualifiedBindName));
              
        }
        #endregion

        #region Window Actions

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblTaxCodes_colsTaxLiability_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovUserWhere:
                    this.tblTaxCodes_colsTaxLiability_OnPM_DataItemLovUserWhere(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemLovUserWhere event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblTaxCodes_colsTaxLiability_OnPM_DataItemLovUserWhere(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.sCountry = "*";
            this.sStmt = "( (COUNTRY = :i_hWndFrame.frmTaxCodesPerTaxClass.tblTaxCodes_colsDeliveryCountry OR COUNTRY = :i_hWndFrame.frmTaxCodesPerTaxClass.sCountry) AND TAXABLE_DB ! = 'EXM')";
            e.Return = this.sStmt.ToHandle();
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblTaxCodes_colsFeeCode_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblTaxCodes_colsFeeCode_OnPM_DataItemValidate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom:
                    this.tblTaxCodes_colsFeeCode_OnPM_DataItemZoom(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblTaxCodes_colsFeeCode_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.FetchValidFrom())
            {
                this.tblTaxCodes_colValidFrom.EditDataItemSetEdited();
                e.Return = true;
                return;
            }
            e.Return = false;
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemZoom event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblTaxCodes_colsFeeCode_OnPM_DataItemZoom(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            switch (Sys.wParam)
            {
                case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                    if (Ifs.Fnd.ApplicationForms.Var.Security.IsViewAvailable("STATUTORY_FEE_MULTIPLE"))
                    {
                        e.Return = true;
                        return;
                    }
                    goto case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute;

                case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                    this.sItemNames[0] = "FEE_CODE";
                    this.hWndItems[0] = this.tblTaxCodes_colsFeeCode;
                    this.sItemNames[1] = "COMPANY";
                    this.hWndItems[1] = this.tblTaxCodes_colsCompany;
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("STATUTORY_FEE_MULTIPLE", tblTaxCodes, this.sItemNames, this.hWndItems);
                    SessionNavigate(Pal.GetActiveInstanceName("tbwStatFee"), true);

                    break;
            }
            e.Return = true;
            return;
            #endregion
        }
        #endregion
        #endregion

        #region Event Handlers

        private void menuItem_Change_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Sys.lParam);

        }

        private void menuItem_Change_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Sys.lParam);

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
