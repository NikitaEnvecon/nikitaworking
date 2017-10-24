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
	/// <param name="sCompany"></param>
	/// <param name="sVoucherTypeIn"></param>
    public partial class frmVouTyUG : cFormWindowFin
    {
        #region Window Parameters
        public SalString sCompany;
        public SalString sVoucherTypeIn;
        #endregion

        #region Window Variables
        public SalNumber nYear = 0;
        public SalString sVoucherType = "";
        public SalString sCompanyName = "";
        public SalString lsIIDYes = "";
        public SalString sModule = "";
        public SalString sLu = "";
        public SalString lsAttribute = "";
        public SalString lsPeriodUsed = "";
        #endregion

        #region Constructors/Destructors
        /// <summary>
        /// The parameterless Constructor.
        /// </summary>
        public frmVouTyUG()
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
        public new static frmVouTyUG FromHandle(SalWindowHandle handle)
        {
            return ((frmVouTyUG)SalWindow.FromHandle(handle, typeof(frmVouTyUG)));
        }
        #endregion

        #region Methods

        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <param name="sMethod"></param>
        /// <returns></returns>
      

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public new SalBoolean SetWindowTitle()
        {
            #region Actions
            using (new SalContext(this))
            {
                if (ccYear.i_sMyValue == Ifs.Fnd.ApplicationForms.Const.strNULL)
                {
                    Sal.SetWindowText(this, i_sCompany + " - " + Properties.Resources.WH_frmVouTyUG);
                }
                else
                {
                    Sal.SetWindowText(this, i_sCompany + " - " + Properties.Resources.WH_frmVouTyUG + " - " + ccYear.i_sMyValue);
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
                        if (dfVoucherType.Text != Ifs.Fnd.ApplicationForms.Const.strNULL)
                        {
                            lsAttribute = "'" + dfVoucherType.Text + "'";
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
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("COMPANY_FINANCE_API.Get_Use_Vou_No_Period", System.Data.ParameterDirection.Input);
                    DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN\r\n" +
                        "		:i_hWndFrame.frmVouTyUG.lsPeriodUsed := " + cSessionManager.c_sDbPrefix + "COMPANY_FINANCE_API.Get_Use_Vou_No_Period(:i_hWndFrame.frmVouTyUG.i_sCompany);\r\n		 END;");
                }
                if (lsPeriodUsed == "FALSE")
                {
                    Sal.HideWindowAndLabel(dfPeriod);
                    Sal.HideWindowAndLabel(dfnSerieFromPer);
                    Sal.HideWindowAndLabel(dfnSerieUntilPer);
                    Sal.HideWindowAndLabel(ccYearP);
                    Sal.ShowWindowAndLabel(dfnSerieFrom);
                    Sal.ShowWindowAndLabel(dfnSerieUntil);
                    Sal.ShowWindowAndLabel(ccYear);
                    dfPeriod.EditDataItemFlagSet(Ifs.Fnd.ApplicationForms.Const.FIELD_Query, false);
                }
                else
                {
                    Sal.HideWindowAndLabel(dfnSerieFrom);
                    Sal.HideWindowAndLabel(dfnSerieUntil);
                    Sal.HideWindowAndLabel(ccYear);
                    Sal.ShowWindowAndLabel(dfPeriod);
                    Sal.ShowWindowAndLabel(dfnSerieFromPer);
                    Sal.ShowWindowAndLabel(dfnSerieUntilPer);
                    Sal.ShowWindowAndLabel(ccYearP);
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
        private void frmVouTyUG_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate:
                    this.frmVouTyUG_OnPM_DataSourcePopulate(sender, e);
                    break;

                case Sys.SAM_CreateComplete:
                    this.frmVouTyUG_OnSAM_CreateComplete(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataSourcePopulate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmVouTyUG_OnPM_DataSourcePopulate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Sys.wParam, Sys.lParam))
            {
                if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
                {
                    Sal.TblClearSelection(this.tblUserGroups);
                }
                SetWindowTitle();
                e.Return = true;
                return;
            }
            e.Return = false;
            return;
            #endregion
        }

        /// <summary>
        /// SAM_CreateComplete event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmVouTyUG_OnSAM_CreateComplete(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Sys.SAM_CreateComplete, Sys.wParam, Sys.lParam))
            {
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("Default_Type_API.DECODE", System.Data.ParameterDirection.Input);
                    this.DbPLSQLBlock(cSessionManager.c_hSql, "   :i_hWndFrame.frmVouTyUG.lsIIDYes   :=  &AO.Default_Type_API.DECODE('Y')  ");
                }
                e.Return = true;
                return;
            }
            e.Return = false;
            return;
            #endregion
        }
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public override SalNumber vrtActivate(fcURL URL)
        {
            using (new SalContext(this))
            {
                EnableDisablePeriod();
                this.i_sCompany = URL.iParameters.GetAttribute("COMPANY");
                this.sVoucherType = URL.iParameters.GetAttribute("VOUCHER_TYPE");
                SetWindowTitle();
                return base.Activate(URL);
            }
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblUserGroups_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_RowValidate:
                    e.Handled = true;
                    break;
            }
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

        #region ChildTable-tblUserGroups

        #region Methods

        /// <summary>
        /// Gets client default values for NEW records
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean tblUserGroups_DataRecordGetDefaults()
        {
            this.tblUserGroups_colCompany.Text = this.dfCompany.Text;
            this.tblUserGroups_colCompany.EditDataItemSetEdited();
            this.tblUserGroups_colVoucherType.Text = this.dfVoucherType.Text;
            this.tblUserGroups_colVoucherType.EditDataItemSetEdited();
            if (this.lsPeriodUsed == "FALSE")
            {
                this.tblUserGroups_colYear.Number = this.ccYear.i_sMyValue.ToNumber();
            }
            else
            {
                this.tblUserGroups_colYear.Number = this.ccYearP.i_sMyValue.ToNumber();
            }
            this.tblUserGroups_colYear.EditDataItemSetEdited();
            return true;
        }
        #endregion

        #region Window Actions

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblUserGroups_colDefaultType_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblUserGroups_colDefaultType_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblUserGroups_colDefaultType_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if ((this.tblUserGroups_colDefaultType2.Text != this.tblUserGroups_colDefaultType.Text) && (this.tblUserGroups_colDefaultType2.Text == this.lsIIDYes) && (this.tblUserGroups.__colObjversion.Text != Ifs.Fnd.ApplicationForms.Const.strNULL))
            {
                Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_DefaultTypeError1, Properties.Resources.WH_frmVouTyUG, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                e.Return = false;
                return;
            }
            this.tblUserGroups_colDefaultType2.Text = this.tblUserGroups_colDefaultType.Text;
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }
        #endregion

        #region Window Events

        private void tblUserGroups_DataRecordGetDefaultsEvent(object sender, FndReturnEventArgsSalBoolean e)
        {
            e.Handled = true;
            e.ReturnValue = this.tblUserGroups_DataRecordGetDefaults();
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
            if (Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Sys.lParam))
            {
                EnableDisablePeriod();
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
            if (Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Sys.lParam))
            {
                EnableDisablePeriod();
                
            }

        }

        private void menuItem_Translation_2_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = Translation(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem_Translation_2_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            Translation(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem_Change_2_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Sys.lParam);
        }

        private void menuItem_Change_2_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            if (Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Sys.lParam))
            {
                EnableDisablePeriod();
            }
        }

        #endregion


    }
}
