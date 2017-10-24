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
    [FndWindowRegistration("ACCOUNT_GROUP", "AccountGroup", FndWindowRegistrationFlags.HomePage)]
    public partial class tbwAccountGroup : cTableWindowFin
    {
        #region Window Variables
        public SalNumber nRetVal = 0;
        public SalString sTemp = "";
        public SalArray<SalString> sPlaceHolders = new SalArray<SalString>();
        public SalString sCompanyName = "";
        public SalArray<SalString> sChanges = new SalArray<SalString>();
        public SalString sID = "";
        public SalNumber nNumChanges = 0;
        public SalString sConsCompany = "";
        public SalString sModule = "";
        public SalString sLu = "";
        public SalString lsAttribute = "";
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public tbwAccountGroup()
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
        public new static tbwAccountGroup FromHandle(SalWindowHandle handle)
        {
            return ((tbwAccountGroup)SalWindow.FromHandle(handle, typeof(tbwAccountGroup)));
        }
        #endregion

        #region Methods
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public override SalNumber vrtActivate(fcURL URL)
        {
            #region Actions
            using (new SalContext(this))
            {
                if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.TypeGet() == "ZOOM")
                {
                    if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.RecCountGet() > 0)
                    {
                        Sal.WaitCursor(true);
                        if (InitFromTransferredData())
                            Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();
                        Sal.WaitCursor(false);
                    }
                }
                if (EnableDisableConsCompany())
                {
                    return base.Activate(URL);
                }
                return false;
            }
            #endregion

        }

        

        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalNumber Translation(SalNumber nWhat)
        {
            #region Local Variables
            SalNumber nRow = 0;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        Sal.WaitCursor(true);
                        sModule = "ACCRUL";
                        sLu = "AccountGroup";
                        lsAttribute = Ifs.Fnd.ApplicationForms.Const.strNULL;
                        nRow = Sys.TBL_MinRow;
                        while (true)
                        {
                            if (Sal.TblFindNextRow(this, ref nRow, Sys.ROW_Selected, 0))
                            {
                                Sal.TblSetContext(this, nRow);
                                lsAttribute = lsAttribute + "'" + colAccntGrpName.Text + "'" + ",";
                            }
                            else
                            {
                                break;
                            }
                        }
                        if (lsAttribute != Ifs.Fnd.ApplicationForms.Const.strNULL)
                        {
                            lsAttribute = lsAttribute.Left(lsAttribute.Length - 1);
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
        public new SalString GetWindowTitle()
        {
            #region Actions
            using (new SalContext(this))
            {
                return Properties.Resources.WM_tbwAccountGroup;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber EnableDisableConsCompany()
        {
            #region Actions
            using (new SalContext(this))
            {
                // check, if company has consolidation comapny defined ....
                Sal.WaitCursor(true);
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("Company_Finance_API.Get_Cons_Company", System.Data.ParameterDirection.Input);
                    if (!(DbPLSQLBlock(cSessionManager.c_hSql, " BEGIN\r\n" +
                        "	  :i_hWndFrame.tbwAccountGroup.sConsCompany :=  \r\n" +
                        "	   &AO.Company_Finance_API.Get_Cons_Company(:i_hWndFrame.tbwAccountGroup.i_sCompany );\r\n	   END; ")))
                    {
                        return false;
                    }
                }
                Sal.WaitCursor(false);
                if (sConsCompany == Ifs.Fnd.ApplicationForms.Const.strNULL)
                {
                    Sal.DisableWindow(colDefaultConsAccnt);
                    Sal.DisableWindow(colDefConsAccountDescription);
                }
                else
                {
                    Sal.EnableWindow(colDefaultConsAccnt);
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
        private void tbwAccountGroup_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_UserProfileChanged:
                    this.tbwAccountGroup_OnPM_UserProfileChanged(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_UserProfileChanged event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwAccountGroup_OnPM_UserProfileChanged(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_UserProfileChanged, Sys.wParam, Sys.lParam))
            {
                e.Return = this.EnableDisableConsCompany();
                return;
            }
            e.Return = false;
            return;
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

        #endregion

    }
}
