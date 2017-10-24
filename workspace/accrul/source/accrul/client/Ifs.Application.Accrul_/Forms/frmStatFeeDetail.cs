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
using System.Collections.Generic;

namespace Ifs.Application.Accrul_
{
	
	/// <summary>
	/// </summary>
    public partial class frmStatFeeDetail : cFormWindowFin
    {
        #region Window Variables
        public SalBoolean bStartUp = false;
        public SalString sFeeTypeDb = "";
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public frmStatFeeDetail()
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
        public new static frmStatFeeDetail FromHandle(SalWindowHandle handle)
        {
            return ((frmStatFeeDetail)SalWindow.FromHandle(handle, typeof(frmStatFeeDetail)));
        }
        #endregion

        #region Methods

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public new SalString GetWindowTitle()
        {
            return Properties.Resources.WH_frmStatFeeDetail;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalString SetFeeCodeLovUserWhere()
        {
            #region Local Variables
            SalString sStmt = "";
            #endregion

            #region Actions

            if (sFeeTypeDb == "SALETX")
            { sStmt = "fee_type_db IN ( 'SALETX' )"; }
            else if (sFeeTypeDb == "VAT")
            { sStmt = "fee_type_db IN ( 'RDE' )"; }
            else
            { sStmt = SalString.Null; }
            return sStmt;

            #endregion
        }
        #endregion

        #region Window Actions

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void dfsFeeType_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemPopulate:
                    this.dfsFeeType_OnPM_DataItemPopulate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemPopulate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsFeeType_OnPM_DataItemPopulate(object sender, WindowActionsEventArgs e)
        {

            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemPopulate, Sys.wParam, Sys.lParam))
            {
                DbPLSQLBlock(":i_hWndFrame.frmStatFeeDetail.sFeeTypeDb := &AO.Fee_Type_API.Encode(:i_hWndFrame.frmStatFeeDetail.dfsFeeType)");      
                e.Return = true;
                return;
            }
            e.Return = false;
            return;
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblStatFeeDet_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew:
                    this.tblStatFeeDet_OnPM_DataRecordNew(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataRecordNew event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblStatFeeDet_OnPM_DataRecordNew(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire)
            {
                Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew, Sys.wParam, Sys.lParam);
                e.Return = true;
                return;
            }
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew, Sys.wParam, Sys.lParam);
                this.tblStatFeeDet_colsFeeCode.Text = this.ccTaxCode.i_sMyValue;
                this.tblStatFeeDet_colsFeeCode.EditDataItemSetEdited();
                this.tblStatFeeDet_colsCompany.Text = this.dfsCompany.Text;
                this.tblStatFeeDet_colsCompany.EditDataItemSetEdited();
                e.Return = true;
                return;
            }
            #endregion
        }
        #endregion

        #region Late Bind Methods
        // Insert new code here...

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

        #region ChildTable-tblStatFeeDet
        
        #region Methods

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber GetDetails()
        {
            IDictionary<string, string> namedBindVariables = new Dictionary<string, string>();
            namedBindVariables.Add("Description", tblStatFeeDet_colDescription.QualifiedBindName);
            namedBindVariables.Add("Company", tblStatFeeDet_colsCompany.QualifiedBindName);
            namedBindVariables.Add("AttFeeCode", tblStatFeeDet_colsAttFeeCode.QualifiedBindName);
            namedBindVariables.Add("FeeRate", tblStatFeeDet_colnFeeRate.QualifiedBindName);

            string stmt = @"BEGIN
                            {Description} := &AO.STATUTORY_FEE_API.Get_Description({Company} IN, {AttFeeCode} IN );
                            {FeeRate} := &AO.STATUTORY_FEE_API.Get_Fee_Rate({Company} IN, {AttFeeCode} IN );
                           END;";
            DbPLSQLBlock(stmt,namedBindVariables);           
            return 0;
         }
        #endregion

        #region Window Actions

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colsAttFeeCode_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_Validate:
                    this.colsAttFeeCode_OnSAM_Validate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovUserWhere:
                    e.Handled = true;
                    e.Return = this.SetFeeCodeLovUserWhere().ToHandle();
                    return;
            }
            #endregion
        }

        /// <summary>
        /// SAM_Validate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colsAttFeeCode_OnSAM_Validate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (!(Sal.IsNull(tblStatFeeDet_colsFeeCode)))
            {
                this.GetDetails();
            }
            e.Return = Sal.SendClassMessage(Sys.SAM_Validate, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }
        #endregion
    
        #endregion

        #region Event Handlers

        private void menuItem__Change_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Sys.lParam);

        }

        private void menuItem__Change_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {            
            Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Sys.lParam);
        }

        #endregion

    }
}
