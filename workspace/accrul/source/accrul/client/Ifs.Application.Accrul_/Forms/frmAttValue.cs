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
    [FndWindowRegistration("ACCOUNTING_ATTRIBUTE_VALUE", "AccountingAttributeValue")]
    public partial class frmAttValue : cFormWindowFin
    {
        #region Window Variables
        public SalNumber nRetVal = 0;
        public SalString sCompanyName = "";
        public SalArray<SalString> sPlaceHolders = new SalArray<SalString>();
        public SalArray<SalString> sChanges = new SalArray<SalString>();
        public SalString sID = "";
        public SalNumber nNumChanges = 0;
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public frmAttValue()
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
        public new static frmAttValue FromHandle(SalWindowHandle handle)
        {
            return ((frmAttValue)SalWindow.FromHandle(handle, typeof(frmAttValue)));
        }
        #endregion

        #region Methods

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public new SalString GetWindowTitle()
        {
            #region Actions
            using (new SalContext(this))
            {
                return Ifs.Application.Accrul.Properties.Resources.WH_AttributeValue;
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
        private void frmAttValue_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
            }
            #endregion
        }

        protected virtual SalBoolean ChangeCompanay(SalNumber nMethod)
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
            #endregion
        }
        #endregion

        #region Late Bind Methods

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalString vrtGetWindowTitle()
        {
            return this.GetWindowTitle();
        }
       
        #endregion

        #region ChildTable-tblAttValue    

        #region Methods

        /// <summary>
        /// Gets client default values for NEW records
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean tblAttValue_DataRecordGetDefaults()
        {
            tblAttValue_colsCompany.Text = frmAttValue.FromHandle(i_hWndFrame).i_sCompany;
            tblAttValue_colsCompany.EditDataItemSetEdited();

            tblAttValue_colsAttribute.Text = this.cmbsAttribute.i_sMyValue;
            tblAttValue_colsAttribute.EditDataItemSetEdited();

            return true; 
        }

        #endregion

        #endregion

        #region Event Handlers

        private void menuItem_Connect_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            if (Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("frmAttributeConnection")))
            {
                ((FndCommand)sender).Enabled = true;
            }
            else
            {
                ((FndCommand)sender).Enabled = false;
            }

        }

        private void menuItem_Connect_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            #region Local Variables
            SalString                     sName = "";
            SalArray<SalString>      sItemNames = new SalArray<SalString>();
            SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
            #endregion
                                  
            {
                sItemNames[0] = "COMPANY";
                hWndItems[0]  = dfsCompany;
                sItemNames[1] = "ATTRIBUTE";
                hWndItems[1]  = cmbsAttribute;
                sItemNames[2] = "CODE_PART";
                hWndItems[2]  = dfsCodePart;
                Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("ATTRIBUTE", this, sItemNames, hWndItems);
                SessionCreateWindow(Pal.GetActiveInstanceName("frmAttributeConnection"), Sys.hWndMDI);
            }
            
        }

        private void menuItem__Change_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Sys.lParam);
        }

        private void menuItem__Change_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Sys.lParam);
        }

        private void menuItem_Connect_1_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            if (Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("frmAttributeConnection")))
            {
                ((FndCommand)sender).Enabled = true; 
            }
            ((FndCommand)sender).Enabled = false;
        }

        private void menuItem_Connect_1_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            #region Local Variables
            SalString                     sName = "";
            SalArray<SalString>      sItemNames = new SalArray<SalString>();
            SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
            #endregion
                                  
            {
                sItemNames[0] = "COMPANY";
                hWndItems[0]  = dfsCompany;
                sItemNames[1] = "ATTRIBUTE";
                hWndItems[1]  = cmbsAttribute;
                sItemNames[2] = "CODE_PART";
                hWndItems[2]  = dfsCodePart;
                Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("ATTRIBUTE", this, sItemNames, hWndItems);
                SessionCreateWindow(Pal.GetActiveInstanceName("frmAttributeConnection"), Sys.hWndMDI);
            }
        }

        private void menuItem__Change_1_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Sys.lParam);
        }

        private void menuItem__Change_1_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Sys.lParam);
        }

        private void menuItem_Connect_2_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            

            ((FndCommand)sender).Enabled = (Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("frmAttributeConnection")));

        }

        private void menuItem_Connect_2_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            #region Local Variables
            SalString sName = "";
            SalArray<SalString> sItemNames = new SalArray<SalString>();
            SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
            #endregion

            {
                sItemNames[0] = "COMPANY";
                hWndItems[0] = dfsCompany;
                sItemNames[1] = "ATTRIBUTE";
                hWndItems[1] = cmbsAttribute;
                sItemNames[2] = "CODE_PART";
                hWndItems[2] = dfsCodePart;
                Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("ATTRIBUTE", this, sItemNames, hWndItems);
                SessionCreateWindow(Pal.GetActiveInstanceName("frmAttributeConnection"), Sys.hWndMDI);
            }
        }

        private void menuItem__Change_2_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = this.ChangeCompanay(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem__Change_2_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            this.ChangeCompanay(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void tblAttValue_DataRecordGetDefaultsEvent(object sender, FndReturnEventArgsSalBoolean e)
        {
            e.Handled = true;
            e.ReturnValue = tblAttValue_DataRecordGetDefaults();

        }

        #endregion

    }
}


