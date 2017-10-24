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

using Ifs.Fnd.Windows.Forms;

namespace Ifs.Application.Accrul_
{

    /// <summary>
    /// </summary>
    [FndWindowRegistration("RPD_IDENTITY", "RpdIdentity", FndWindowRegistrationFlags.HomePage)]
    public partial class tbwRpdIdentity : cTableWindow
    {
        #region Member Variables

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public tbwRpdIdentity()
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
        public new static tbwRpdIdentity FromHandle(SalWindowHandle handle)
        {
            return ((tbwRpdIdentity)SalWindow.FromHandle(handle, typeof(tbwRpdIdentity)));
        }
        #endregion

        #region Properties

        #endregion

        #region Methods
        protected virtual SalBoolean ReportingPeriods(SalNumber nWhat)
        {
            #region Local Variables
            SalArray<SalString> sItemNames = new SalArray<SalString>();
            SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        return Sal.TblAnyRows(this, Sys.ROW_Selected, 0) && Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("frmRpdYear"));

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        Sal.WaitCursor(true);
                        sItemNames[0] = "RPD_ID";
                        hWndItems[0] = colsRpdId;
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("RpdYear", this, sItemNames, hWndItems);
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.TypeSet("RMB");
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.SourceNameSet(Pal.GetActiveInstanceName("tbwRpdIdentity"));
                        SessionCreateWindow(Pal.GetActiveInstanceName("frmRpdYear"), Sys.hWndMDI);
                        Sal.WaitCursor(false);
                        break;
                }
            }
            return false;
            #endregion
        }

        protected virtual SalBoolean CompaniesPerReportingPeriodDefinition(SalNumber nWhat)
        {
            #region Local Variables
            SalArray<SalString> sItemNames = new SalArray<SalString>();
            SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        return Sal.TblAnyRows(this, Sys.ROW_Selected, 0) && Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("frmRpdCompany"));

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        Sal.WaitCursor(true);
                        sItemNames[0] = "RPD_ID";
                        hWndItems[0] = colsRpdId;
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("RpdCompany", this, sItemNames, hWndItems);
                        SessionCreateWindow(Pal.GetActiveInstanceName("frmRpdCompany"), Sys.hWndMDI);
                        Sal.WaitCursor(false);
                        break;
                }
            }
            return false;
            #endregion
        }

        protected virtual SalBoolean GenerateBasedOnSysCalendar(SalNumber nWhat)
        {
            #region Local Variables
            SalArray<SalString> sItemNames = new SalArray<SalString>();
            SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        return Sal.TblAnyRows(this, Sys.ROW_Selected, 0) 
                            && Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Rpd_Identity_API.Generate_Rpd_Periods")
                            && Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("dlgRpdGenOnCalendar"));

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        Sal.WaitCursor(true);
                        if (dlgRpdGenOnCalendar.ModalDialog(Ifs.Fnd.ApplicationForms.Int.Explorer.ExplorerForm, colsRpdId.Text) == Sys.IDOK)
                        {
                            Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_RpdGeneratedSuccess, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);                            
                        }
                        Sal.WaitCursor(false);
                        break;
                }
            }
            return false;
            #endregion
        }

        protected virtual SalBoolean GenerateBasedOnAccCal(SalNumber nWhat)
        {
            #region Local Variables
            SalArray<SalString> sItemNames = new SalArray<SalString>();
            SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        return Sal.TblAnyRows(this, Sys.ROW_Selected, 0)
                            && Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Rpd_Company_API.Generate_Rpd_Periods")
                            && Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("dlgRpdGenOnAccPeriods"));

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        Sal.WaitCursor(true);
                        if (dlgRpdGenOnAccPeriods.ModalDialog(Ifs.Fnd.ApplicationForms.Int.Explorer.ExplorerForm, colsRpdId.Text) == Sys.IDOK)
                        {
                            Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_RpdGeneratedSuccess, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                        }
                        Sal.WaitCursor(false);
                        break;
                }
            }
            return false;
            #endregion
        }
        
        #endregion

        #region Overrides

        #endregion

        #region Message Actions

        #endregion

        #region Event Handlers

        #endregion

        #region Menu Event Handlers
        private void cmd_menuTbwMethods_MenuItem_GenOnSysCal_Inquire(object sender, Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = GenerateBasedOnSysCalendar(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void cmd_menuTbwMethods_MenuItem_GenOnSysCal_Execute(object sender, Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            GenerateBasedOnSysCalendar(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void cmd_menuTbwMethods_MenuItem_GenOnAccCal_Inquire(object sender, Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = GenerateBasedOnAccCal(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void cmd_menuTbwMethods_MenuItem_GenOnAccCal_Execute(object sender, Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            GenerateBasedOnAccCal(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void cmd_menuTbwMethods_MenuItem_CompaniesPerRPD_Inquire(object sender, Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = CompaniesPerReportingPeriodDefinition(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void cmd_menuTbwMethods_MenuItem_CompaniesPerRPD_Execute(object sender, Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            CompaniesPerReportingPeriodDefinition(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void cmd_menuTbwMethods_MenuItem_RPDPeriods_Inquire(object sender, Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = ReportingPeriods(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }
        
        private void cmd_menuTbwMethods_MenuItem_RPDPeriods_Execute(object sender, Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            ReportingPeriods(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }
        #endregion
    }
}
