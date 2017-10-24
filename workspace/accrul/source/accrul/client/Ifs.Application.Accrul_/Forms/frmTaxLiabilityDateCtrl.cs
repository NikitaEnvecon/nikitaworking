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
    [FndWindowRegistration("TAX_LIABILITY_DATE_CTRL", "TaxLiabilityDateCtrl")]
    public partial class frmTaxLiabilityDateCtrl : cFormWindowFin
    {
        #region Window Variables
        public SalString sOldCompany = "";
        public SalArray<SalNumber> nIndicesOfDeleted = new SalArray<SalNumber>();
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public frmTaxLiabilityDateCtrl()
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
        public new static frmTaxLiabilityDateCtrl FromHandle(SalWindowHandle handle)
        {
            return ((frmTaxLiabilityDateCtrl)SalWindow.FromHandle(handle, typeof(frmTaxLiabilityDateCtrl)));
        }
        #endregion

        #region Methods

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public new SalBoolean SetWindowTitle()
        {
            #region Actions
            using (new SalContext(this))
            {
                Sal.SetWindowText(this, i_sCompany + " - " + Properties.Resources.WH_frmTaxLiabilityDateControl);
            }

            return 0;
            #endregion
        }

        

        /// <summary>
        /// </summary>
        /// <param name="hListBox"></param>
        /// <returns></returns>
        public virtual SalNumber DeleteIIDEntries(SalWindowHandle hListBox)
        {
            #region Local Variables
            SalNumber i = 0;
            SalNumber nNoOfEntries = 0;
            SalNumber nNoOfRemainingItems = 0;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                i = 0;
                nNoOfEntries = Sal.ListQueryCount(hListBox);
                nNoOfRemainingItems = Sal.ListDelete(hListBox, nIndicesOfDeleted[i]);
                i = i + 1;
                while (nIndicesOfDeleted[i] != SalNumber.Null)
                {
                    if (nNoOfRemainingItems != Sys.LB_Err)
                    {
                        // Note: The items get re-arranged after deletion. Hence, the adjustment of the indices like below:
                        // Note:        No. of remaining items after deletion = SalListDelete( List, Original index - (No. of list items originally - No. of remaining items before deletion) )
                        nNoOfRemainingItems = Sal.ListDelete(hListBox, nIndicesOfDeleted[i] - (nNoOfEntries - nNoOfRemainingItems));
                        i = i + 1;
                    }
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
        private void frmTaxLiabilityDateCtrl_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_Create:
                    this.frmTaxLiabilityDateCtrl_OnSAM_Create(sender, e);
                    break;

                case Sys.SAM_CreateComplete:
                    this.frmTaxLiabilityDateCtrl_OnSAM_CreateComplete(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew:
                    this.frmTaxLiabilityDateCtrl_OnPM_DataRecordNew(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_Create event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmTaxLiabilityDateCtrl_OnSAM_Create(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam);
            this.SetWindowTitle();
            #endregion
        }

        /// <summary>
        /// SAM_CreateComplete event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmTaxLiabilityDateCtrl_OnSAM_CreateComplete(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Sys.SAM_CreateComplete, Sys.wParam, Sys.lParam))
            {
                Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Sys.lParam);
                e.Return = true;
                return;
            }
            e.Return = false;
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataRecordNew event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmTaxLiabilityDateCtrl_OnPM_DataRecordNew(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew, Sys.wParam, Sys.lParam))
            {
                if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire)
                {
                    // Note: Allow new entry only if this company doesn't have one (the window populates upon opening).
                    if (this.dfsCompany.Text == Sys.STRING_Null)
                    {
                        e.Return = true;
                        return;
                    }
                    e.Return = false;
                    return;
                }
                if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
                {
                    this.dfsCompany.Text = this.i_sCompany;
                    this.dfsCompany.EditDataItemSetEdited();
                    e.Return = true;
                    return;
                }
            }
            e.Return = false;
            return;
            #endregion
        }
        #endregion

        #region Late Bind Methods

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

        #region ChildTable-tblTaxLiabilityDateException

        #region Window Actions

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblTaxLiabilityDateException_colsFeeCode_WindowActions(object sender, WindowActionsEventArgs e)
        {

        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblTaxLiabilityDateException_colsCustomerLiabilityDate_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_LookupInit:
                    this.tblTaxLiabilityDateException_colsCustomerLiabilityDate_OnPM_LookupInit(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_LookupInit event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblTaxLiabilityDateException_colsCustomerLiabilityDate_OnPM_LookupInit(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_LookupInit, Sys.wParam, Sys.lParam);
            // Note: The list box should only show 'Invoice Date', 'Voucher Date', 'Delivery Date', 'Specified on Company', and 'Manual'.
            this.nIndicesOfDeleted[0] = 3;
            this.nIndicesOfDeleted[1] = 4;
            this.nIndicesOfDeleted[2] = 7;
            this.nIndicesOfDeleted[3] = SalNumber.Null;
            this.DeleteIIDEntries(this.tblTaxLiabilityDateException_colsCustomerLiabilityDate);
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblTaxLiabilityDateException_colsCustomerCrdtLiabltyDate_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_LookupInit:
                    this.tblTaxLiabilityDateException_colsCustomerCrdtLiabltyDate_OnPM_LookupInit(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_LookupInit event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblTaxLiabilityDateException_colsCustomerCrdtLiabltyDate_OnPM_LookupInit(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_LookupInit, Sys.wParam, Sys.lParam);
            // Note: The list box should only show 'Invoice Date', 'Voucher Date', 'Delivery Date', 'Specified on Company', and 'Manual'.
            this.nIndicesOfDeleted[0] = 3;
            this.nIndicesOfDeleted[1] = 4;
            this.nIndicesOfDeleted[2] = 7;
            this.nIndicesOfDeleted[3] = SalNumber.Null;
            this.DeleteIIDEntries(this.tblTaxLiabilityDateException_colsCustomerCrdtLiabltyDate);
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblTaxLiabilityDateException_colsSupplierLiabilityDate_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_LookupInit:
                    this.tblTaxLiabilityDateException_colsSupplierLiabilityDate_OnPM_LookupInit(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_LookupInit event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblTaxLiabilityDateException_colsSupplierLiabilityDate_OnPM_LookupInit(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_LookupInit, Sys.wParam, Sys.lParam);
            // Note: The list box should only show 'Invoice Date', 'Voucher Date', 'Arrival Date', 'Delivery Date', 'Date of Final Posting', 'Specified on Company', and 'Manual'.
            this.nIndicesOfDeleted[0] = 4;
            this.nIndicesOfDeleted[1] = SalNumber.Null;
            this.DeleteIIDEntries(this.tblTaxLiabilityDateException_colsSupplierLiabilityDate);
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

            sOldCompany = dfsCompany.Text;
            if (Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Sys.lParam))
            {
                if (sOldCompany != i_sCompany)
                {
                    Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                }
            }
        }

        #endregion

    }
}
