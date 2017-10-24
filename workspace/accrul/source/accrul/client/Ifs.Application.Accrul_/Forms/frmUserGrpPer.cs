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
    [FndWindowRegistration("ACCOUNTING_PERIOD", "AccountingPeriod")]
    public partial class frmUserGrpPer : cFormWindowFin
    {
        #region Window Variables
        public SalString sCompanyName = "";
        public SalArray<SalString> sPlaceHolders = new SalArray<SalString>();
        public SalArray<SalString> sChanges = new SalArray<SalString>();
        public SalString sID = "";
        public SalNumber nNumChanges = 0;
        public SalNumber nPkgNo = 0;
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public frmUserGrpPer()
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
        public new static frmUserGrpPer FromHandle(SalWindowHandle handle)
        {
            return ((frmUserGrpPer)SalWindow.FromHandle(handle, typeof(frmUserGrpPer)));
        }
        #endregion

        #region Methods

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public new SalBoolean FrameStartupUser()
        {
            DbPLSQLBlock(":i_hWndFrame.frmUserGrpPer.nPkgNo := &AO.Transaction_SYS.Package_Is_Installed_Num('INTERNAL_LEDGER_API')");
            if (nPkgNo == 0)
            {
                Sal.HideWindowAndLabel(dfILStatus);
                Sal.HideWindow(tblUserGroups_colsPeriodStatusInt);
            }
            return true;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public new SalString GetWindowTitle()
        {
            #region Actions
            using (new SalContext(this))
            {
                return Properties.Resources.WH_frmUserGrpPer;
            }
            #endregion
        }
        public virtual SalNumber ChangeComp(SalNumber nWhat)
        {
            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        return Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Sys.lParam);

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        return Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Sys.lParam);
                }
                return 0;
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
        private void frmUserGrpPer_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_UserProfileChanged:
                    this.frmUserGrpPer_OnPM_UserProfileChanged(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_UserProfileChanged event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmUserGrpPer_OnPM_UserProfileChanged(object sender, WindowActionsEventArgs e)
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

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
       
        /// <summary>
        /// </summary>
        /// <returns></returns>
       
        #endregion

        #region ChildTable-tblUserGroups
        
        #region Methods

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean tblUserGroups_DataRecordGetDefaults()
        {
            #region Actions
            using (new SalContext(this))
            {
                tblUserGroups_colCompany.Text = this.dfCompany.Text;
                tblUserGroups_colCompany.EditDataItemSetEdited();
                tblUserGroups_colAccountingYear.Text = SalString.FromHandle(this.cmbAccPer.EditDataItemValueGet());
                tblUserGroups_colAccountingYear.EditDataItemSetEdited();
                tblUserGroups_colAccountingPeriod.Number = this.dfPeriod.Number;
                tblUserGroups_colAccountingPeriod.EditDataItemSetEdited();
                return true;
            }
            #endregion
        }
        #endregion

        #region Late Bind Methods

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalBoolean vrtDataRecordGetDefaults()
        {
            return this.tblUserGroups_DataRecordGetDefaults();
        }
        #endregion

        #region Event Handlers

         private void tblUserGroups_DataRecordGetDefaultsEvent(object sender, FndReturnEventArgsSalBoolean e)
        {
            e.Handled = true;
            e.ReturnValue = this.tblUserGroups_DataRecordGetDefaults();
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
            ((FndCommand)sender).Enabled = ChangeComp( Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem_Change_2_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            ChangeComp(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute); 
        }

        #endregion
    }
}
