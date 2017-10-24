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
    [FndWindowRegistration("ACCOUNT", "Account")]
    public partial class frmAccountTaxCode : cFormWindowFin
    {
        #region Window Variables
        public SalString sTaxHandlingValue = "";
        public SalNumber nCurrentRow = 0;
        public SalNumber nCurrentRowTemp = 0;
        public SalNumber nRow = 0;
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public frmAccountTaxCode()
        {
            // to translate sWindowTitle according to the code part value translation
            i_bTranslateForCodePart = true;
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
        public new static frmAccountTaxCode FromHandle(SalWindowHandle handle)
        {
            return ((frmAccountTaxCode)SalWindow.FromHandle(handle, typeof(frmAccountTaxCode)));
        }
        #endregion

        #region Methods

        
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
                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordDuplicate:
                    this.tblTaxCodes_OnPM_DataRecordDuplicate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataRecordDuplicate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblTaxCodes_OnPM_DataRecordDuplicate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordDuplicate, Sys.wParam, Sys.lParam))
            {
                if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
                {
                    if (this.sTaxHandlingValue == "RESTRICTED")
                    {
                        this.tblTaxCodes_colsDefaultTaxCode.Text = "N";
                    }
                }
                e.Return = true;
                return;
            }
            e.Return = false;
            return;
            #endregion
        }
        #endregion

        #region Late Bind Methods
        // Insert new code here...

        
        #endregion

        #region ChildTable-tblTaxCodes

        #region Methods

        /// <summary>
        /// Gets client default values for NEW records
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean tblTaxCodes_DataRecordGetDefaults()
        {
            cSessionManager.c_lsStmt = String.Format("{0} := &AO.ACCOUNT_API.Get_Tax_Handling_Value( {1} IN, {2} IN)", 
                                                             this.QualifiedVarBindName("sTaxHandlingValue"),
                                                             this.dfsCompany.QualifiedBindName,
                                                             this.QualifiedVarBindName("cmbAccount.i_sMyValue"));
            DbPLSQLBlock(cSessionManager.c_lsStmt);
      
            if (this.sTaxHandlingValue == "ALL")
            {   this.tblTaxCodes_colsDefaultTaxCode.Text = "Y"; }
            else
            {   this.tblTaxCodes_colsDefaultTaxCode.Text = "N"; }
            tblTaxCodes_colsDefaultTaxCode.EditDataItemSetEdited();
            return true;

        }
        #endregion

        #region Window Actions

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblTaxCodes_colsDefaultTaxCode_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_Click:
                    this.tblTaxCodes_colsDefaultTaxCode_OnSAM_Click(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_Click event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblTaxCodes_colsDefaultTaxCode_OnSAM_Click(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Sys.SAM_Validate, Sys.wParam, Sys.lParam))
            {
                if (this.tblTaxCodes_colsDefaultTaxCode.Text == "N")
                {
                    this.nCurrentRow = Sal.TblQueryContext(this);
                    this.nRow = Sys.TBL_MinRow;
                    while (true)
                    {
                        if (Sal.TblFindNextRow(this, ref this.nRow, 0, 0))
                        {
                            Sal.TblSetContext(this, this.nRow);
                            if (this.tblTaxCodes_colsDefaultTaxCode.Text == "Y")
                            {
                                this.tblTaxCodes_colsDefaultTaxCode.Text = "N";
                                this.nCurrentRowTemp = Sal.TblQueryContext(this);
                                this.tblTaxCodes_colsDefaultTaxCode.EditDataItemSetEdited();
                                Sal.TblSetRowFlags(this, this.nCurrentRowTemp, Sys.ROW_Edited, true);
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                    Sal.TblSetContext(this, this.nCurrentRow);
                }
                e.Return = true;
                return;
            }
            e.Return = false;
            return;
            #endregion
        }
        #endregion

        #region Window Events

        private void tblTaxCodes_DataRecordGetDefaultsEvent(object sender, FndReturnEventArgsSalBoolean e)
        {
            e.Handled = true;
            e.ReturnValue = tblTaxCodes_DataRecordGetDefaults();

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
