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
using Ifs.Fnd.Windows.Forms;
using PPJ.Runtime;
using PPJ.Runtime.Windows;

namespace Ifs.Application.Accrul_
{

    /// <summary>
    /// </summary>
    public partial class dlgRpdGenOnCalendar : cDialogBox
    {
        #region Member Variables
        public SalString sRpdId;
        public SalNumber nStartYear;
        public SalNumber nEndYear;
        public SalNumber nStartRpdYearId;
        public SalNumber nFromCalendarMonth;
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        protected dlgRpdGenOnCalendar()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();            
        }
        #endregion

        #region System Methods/Properties

        /// <summary>
        /// Shows the modal dialog.
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        public static SalNumber ModalDialog(Control owner, SalString sRpdId)
        {
            dlgRpdGenOnCalendar dlg = DialogFactory.CreateInstance<dlgRpdGenOnCalendar>();
            dlg.sRpdId = sRpdId;
            SalNumber ret = dlg.ShowDialog(owner);
            return ret;
        }

        /// <summary>
        /// Returns the object instance associated with the window handle.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public new static dlgRpdGenOnAccPeriods FromHandle(SalWindowHandle handle)
        {
            return ((dlgRpdGenOnAccPeriods)SalWindow.FromHandle(handle, typeof(dlgRpdGenOnAccPeriods)));
        }
        #endregion

        #region Properties
        
        #endregion

        #region Methods
        /// <summary>
        /// Stub for all user methods.
        /// Should be overridden with own method for all container classes.
        /// (other classen can override PM_UserMethod instead)
        /// </summary>
        /// <param name="nWhat"></param>
        /// <param name="sMethod"></param>
        /// <returns></returns>
        public new SalNumber UserMethod(SalNumber nWhat, SalString sMethod)
        {
            #region Local Variables
            SalString sName = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                if (sMethod == "OK")
                {
                    return Ok(nWhat);
                }
                if (sMethod == "Cancel")
                {
                    switch (nWhat)
                    {
                        case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                            return this.EndDialog(Sys.IDCANCEL);

                        case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                            return 1;

                        case Ifs.Fnd.ApplicationForms.Const.METHOD_GetType:
                            return Ifs.Fnd.ApplicationForms.Const.CHILDTYPE_AnyMethod;
                    }
                }
                Sal.GetItemName(Sys.hWndItem, ref sName);
                Ifs.Fnd.ApplicationForms.Int.ErrorBox("DESIGN TIME ERROR for item " + sName + "\r\n" +
                    "Function UserMethod handling method \"" + sMethod + "\" not written!");
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        return 0;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        return 0;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_GetType:
                        return Ifs.Fnd.ApplicationForms.Const.CHILDTYPE_AnyMethod;
                }
            }

            return 0;
            #endregion
        }
        
        protected virtual SalBoolean Ok(SalNumber nWhat)
        {
            #region Local Variables
            
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        return (!(string.IsNullOrEmpty(dfnNumberOfYears.Text)));

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        if (string.IsNullOrEmpty(dfnNumberOfYears.Text) || dfnNumberOfYears.Number < 1)
                        {
                            Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.ERROR_NoOfYears, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                            return false;
                        }
                        this.nStartYear = dfnStartYear.Number;
                        this.nEndYear = nStartYear + dfnNumberOfYears.Number - 1;
                        this.nStartRpdYearId = dfnFirstRpdId.Number;
                        this.nFromCalendarMonth = dfnStartMonth.Number;
                        String sStmt = "Rpd_Identity_API.Generate_Rpd_Periods(:i_hWndFrame.dlgRpdGenOnCalendar.sRpdId                IN , " +
                                       "                                      :i_hWndFrame.dlgRpdGenOnCalendar.nStartYear            IN , " +
                                       "                                      :i_hWndFrame.dlgRpdGenOnCalendar.nEndYear              IN , " +
                                       "                                      :i_hWndFrame.dlgRpdGenOnCalendar.nFromCalendarMonth    IN , " +
                                       "                                      :i_hWndFrame.dlgRpdGenOnCalendar.nStartRpdYearId       IN ) ";
                        if (DbPLSQLTransaction(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + sStmt))
                        {
                            return this.EndDialog(Sys.IDOK);
                        }
                        return false;
                }
            }
            return false;
            #endregion
        }
        #endregion

        #region Overrides
        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalNumber vrtUserMethod(SalNumber nWhat, SalString sMethod)
        {
            return UserMethod(nWhat, sMethod);
        }
        #endregion

        #region Window Actions
        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void dfnStartYear_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_AnyEdit:
                    this.dfnStartYear_OnSAM_AnyEdit(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_AnyEdit event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfnStartYear_OnSAM_AnyEdit(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam))
            {
                this.dfnFirstRpdId.Number = this.dfnStartYear.Number;
            }
            #endregion
        }
        #endregion

        #region Message Actions

        #endregion

        #region Event Handlers

        #endregion

        #region Menu Event Handlers

        #endregion
    }
}
