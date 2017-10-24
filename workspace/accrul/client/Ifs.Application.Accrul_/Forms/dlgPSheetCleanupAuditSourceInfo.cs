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
//  160610  NUDILK  Bug 129775,Created
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

namespace Ifs.Application.Accrul_
{

    /// <summary>
    /// </summary>
    [FndTaskParameterSheet("AUDIT_STORAGE_API.CLEANUP_AUDIT_STORAGE")]
    public partial class dlgPSheetCleanupAuditSourceInfo : cTaskParameterSheet
    {
        #region Member Variables

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        protected dlgPSheetCleanupAuditSourceInfo()
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
        public new static dlgPSheetCleanupAuditSourceInfo FromHandle(SalWindowHandle handle)
        {
            return ((dlgPSheetCleanupAuditSourceInfo)SalWindow.FromHandle(handle, typeof(dlgPSheetCleanupAuditSourceInfo)));
        }

        #endregion

        #region Properties

        #endregion

        #region Methods
        public virtual SalNumber EnableDaysBefore()
        {
            #region Actions
            using (new SalContext(this))
            {
                Sal.EnableWindow(dfDaysBefore);
                Sal.DisableWindow(dfCreatedBefore);
            }

            return 0;
            #endregion
        }

        public virtual SalNumber EnableCreatedBefore()
        {
            #region Actions
            using (new SalContext(this))
            {
                Sal.EnableWindow(dfCreatedBefore);
                Sal.DisableWindow(dfDaysBefore);
            }

            return 0;
            #endregion
        }

        public new SalNumber ParameterDecode(cMessage Mandatory, cMessage NonMandatory)
        {
            #region Local Variables
            SalString sAnalyzeMethod = "";
            SalNumber nYear;
            SalNumber nMonth;
            SalNumber nDay;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                sAnalyzeMethod = Mandatory.FindAttribute("DAYS_CHECKED", Ifs.Fnd.ApplicationForms.Const.strNULL);
                if (sAnalyzeMethod == "TRUE")
                {
                    rbBeforeCurrentDate.Checked = true;
                    EnableDaysBefore();
                }
                else
                {
                    rbCreatedBefore.Checked = true;
                    EnableCreatedBefore();
                }
                sAnalyzeMethod = NonMandatory.FindAttribute("NUMBER_OF_DAYS", Ifs.Fnd.ApplicationForms.Const.strNULL);
                if (sAnalyzeMethod == Ifs.Fnd.ApplicationForms.Const.strNULL)
                {
                    dfDaysBefore.Number = 30;
                }
                else
                {
                    dfDaysBefore.Number = sAnalyzeMethod.ToNumber();
                }
                sAnalyzeMethod = NonMandatory.FindAttribute("BEFORE_DATE", Ifs.Fnd.ApplicationForms.Const.strNULL);
                if (sAnalyzeMethod == Ifs.Fnd.ApplicationForms.Const.strNULL)
                {
                    nYear = Sal.DateYear(Sal.DateCurrent());
                    nMonth = Sal.DateMonth(Sal.DateCurrent()) - 1;
                    nDay = Sal.DateDay(Sal.DateCurrent());
                    dfCreatedBefore.DateTime = Sal.DateConstruct(nYear, nMonth, nDay, 0, 0, 0);
                }
                else
                {
                    dfCreatedBefore.DateTime = sAnalyzeMethod.ToDate();
                }
            }

            return 0;
            #endregion
        }

        public new SalBoolean ParameterEncode(cMessage Mandatory, cMessage NonMandatory)
        {
            #region Local Variables
            SalString sDays = "";
            SalString sBeforeDate = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                if (rbBeforeCurrentDate.Checked)
                {
                    sDays = dfDaysBefore.Number.ToString(0);
                    Mandatory.AddAttribute("DAYS_CHECKED", "TRUE");
                    NonMandatory.AddAttribute("NUMBER_OF_DAYS", sDays);
                }
                else
                {
                    Mandatory.AddAttribute("DAYS_CHECKED", "FALSE");
                    NonMandatory.AddAttribute("NUMBER_OF_DAYS", Ifs.Fnd.ApplicationForms.Const.strNULL);
                }
                if (rbCreatedBefore.Checked)
                {
                    sBeforeDate = Ifs.Fnd.ApplicationForms.Int.PalAttrFormatDate(dfCreatedBefore.DateTime);
                    NonMandatory.AddAttribute("BEFORE_DATE", sBeforeDate);
                }
                else
                {
                    NonMandatory.AddAttribute("BEFORE_DATE", Ifs.Fnd.ApplicationForms.Const.strNULL);
                }
                return true;
            }
            #endregion
        }

        public new SalBoolean ParameterValidate()
        {
            #region Actions
            using (new SalContext(this))
            {
                return true;
            }
            #endregion
        }
        #endregion

        #region Overrides
        public override SalNumber vrtParameterDecode(cMessage Mandatory, cMessage NonMandatory)
        {
            return this.ParameterDecode(Mandatory, NonMandatory);
        }

        public override SalBoolean vrtParameterEncode(cMessage Mandatory, cMessage NonMandatory)
        {
            return this.ParameterEncode(Mandatory, NonMandatory);
        }

        public override SalBoolean vrtParameterValidate()
        {
            return this.ParameterValidate();
        }
        #endregion

        #region Window Actions

        #endregion

        #region Event Handlers
        private void rbBeforeCurrentDate_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_Click:
                    this.rbBeforeCurrentDate_OnSAM_Click(sender, e);
                    break;
            }
            #endregion
        }
        private void rbBeforeCurrentDate_OnSAM_Click(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.EnableDaysBefore();
            this.dfCreatedBefore.DateTime = Sys.DATETIME_Null;
            #endregion
        }

        private void rbCreatedBefore_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_Click:
                    this.rbCreatedBefore_OnSAM_Click(sender, e);
                    break;
            }
            #endregion
        }
        private void rbCreatedBefore_OnSAM_Click(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.EnableCreatedBefore();
            this.dfDaysBefore.Number = Sys.NUMBER_Null;
            #endregion
        }

        private void dfDaysBefore_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    e.Handled = true;
                    e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldEnabled;
                    return;
            }
            #endregion
        }
        private void dfCreatedBefore_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    e.Handled = true;
                    e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldEnabled;
                    return;
            }
            #endregion
        }
        #endregion
        
        #region Menu Event Handlers

        #endregion
    }
}
