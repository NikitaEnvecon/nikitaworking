#region Copyright (c) IFS Research & Development
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
#endregion
#region History
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Ifs.Fnd.ApplicationForms;
using PPJ.Runtime;
using PPJ.Runtime.Windows;

namespace Ifs.Application.Accrul
{

    /// <summary>
    /// </summary>
    public partial class tbwFooterConnection : cTableWindow
    {
        #region Member Variables

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public tbwFooterConnection()
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
        [DebuggerStepThrough]
        public new static tbwFooterConnection FromHandle(SalWindowHandle handle)
        {
            return ((tbwFooterConnection)SalWindow.FromHandle(handle, typeof(tbwFooterConnection)));
        }
        #endregion



        #region Properties

        #endregion

        #region Methods

        #endregion

        #region Overrides

        #endregion

        #region Message Actions
        private void colsContract_WindowActions(object sender, WindowActionsEventArgs e)
        {
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovUserWhere:
                    this.colsContract_OnPM_DataItemLovUserWhere(sender, e);
                    break;
                case Sys.SAM_SetFocus:
                    this.colsContract_OnSAM_SetFocus(sender, e);
                    break;
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom:
                    this.colsContract_OnPM_DataItemZoom(sender, e);
                    break;
            }

        }

        private void colsContract_OnPM_DataItemZoom(object sender, WindowActionsEventArgs e)
        {
            #region Variables
            SalArray<SalString> sItemNames = new SalArray<SalString>();
            SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
            #endregion 

            #region Action
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire)
            {
                if ((this.colsContractDependent.Text == "FALSE") && (this.colsContract.Text == "*"))                
                { 
                    e.Return =  false;
                }
                else if (Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("frmCompanySite")) && Ifs.Fnd.ApplicationForms.Var.Component.IsWindowAvailable(Pal.GetActiveInstanceName("frmCompanySite")))
                {
                    e.Return = true;
                return;
                }

                
            }
            else if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                sItemNames[0] = "CONTRACT";
                hWndItems[0] = this.colsContract;
                Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init(Pal.GetActiveInstanceName("tbwFooterConnection"), this, sItemNames, hWndItems);
                SessionNavigate(Pal.GetActiveInstanceName("frmCompanySite"));
                e.Return = true;
                return;

            }           
            return;
            #endregion
        }


        private void colsContract_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Action
            Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
                        
            if ((Ifs.Fnd.ApplicationForms.Var.Security.IsViewAvailable("FOOTER_WITHOUT_SITE_LOV")) && ((this.colsContractDependent.Text == "FALSE") ))
            {                
                this.colsContract.p_sLovReference = "FOOTER_WITHOUT_SITE_LOV";
            }
            else if (Ifs.Fnd.ApplicationForms.Var.Security.IsViewAvailable("FOOTER_WITH_SITE_LOV")) 
            {
                this.colsContract.p_sLovReference = "FOOTER_WITH_SITE_LOV";
            }
            #endregion
        }
        private void colsContract_OnPM_DataItemLovUserWhere (object sender,WindowActionsEventArgs e) 
        {   
            #region variables 
            SalString sSqlStr;
            #endregion
            
            #region Actions
            e.Handled = true;
            if (this.colsContractDependent.Text == "FALSE")            
            {
                sSqlStr = "";
            }
            else
            {
                sSqlStr = "COMPANY = '" + this.ColsCompany.Text + "' OR COMPANY IS NULL";
            }
            
            e.Return = sSqlStr.ToHandle();
            return;
            
            #endregion
        }

        private void colsReportId_WindowActions(object sender, WindowActionsEventArgs e)
        {
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.colsReportId_OnPM_DataItemValidate(sender, e);
                    break;
            }
        }

        private void colsReportId_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region variables
            SalString sSqlStr;
            #endregion

            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {                
                if (!(DbPLSQLBlock(cSessionManager.c_hSql,
                @"Begin :i_hWndFrame.tbwFooterConnection.colsContractDependent := &AO.Footer_Connection_Master_API.Get_Contract_Dependent_Db(
                                :i_hWndFrame.tbwFooterConnection.colsReportId IN); End;")))
                {
                    e.Return = false;
                    return;
                }
                e.Return = true;
                return;

            }
            e.Return = true;
            return;           

            #endregion
        }
        
        #endregion

        #region Event Handlers

        #endregion

        #region Menu Event Handlers

        #endregion
    }
}
