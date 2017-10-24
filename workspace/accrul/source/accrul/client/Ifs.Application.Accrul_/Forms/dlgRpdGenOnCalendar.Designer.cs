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
using Ifs.Fnd.ApplicationForms;
using PPJ.Runtime;
using PPJ.Runtime.Windows;

namespace Ifs.Application.Accrul_
{

    public partial class dlgRpdGenOnCalendar
    {

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgRpdGenOnCalendar));
            this.commandOk = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.commandCancel = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.pbCancel = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbOk = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.dfnNumberOfYears = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfnStartYear = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfnNumberOfYears = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.labeldfdPeriodStartDate = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfnStartMonth = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfnStartMonth = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfnFirstRpdId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfnFirstRpdId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.gbCalendarYear = new PPJ.Runtime.Windows.SalGroupBox();
            this.gbReportingYear = new PPJ.Runtime.Windows.SalGroupBox();
            this.ClientArea.SuspendLayout();
            this.gbCalendarYear.SuspendLayout();
            this.SuspendLayout();
            // 
            // ClientArea
            // 
            this.ClientArea.BackColor = System.Drawing.SystemColors.Control;
            this.ClientArea.Controls.Add(this.dfnFirstRpdId);
            this.ClientArea.Controls.Add(this.labeldfnFirstRpdId);
            this.ClientArea.Controls.Add(this.pbCancel);
            this.ClientArea.Controls.Add(this.pbOk);
            this.ClientArea.Controls.Add(this.gbCalendarYear);
            this.ClientArea.Controls.Add(this.gbReportingYear);
            resources.ApplyResources(this.ClientArea, "ClientArea");
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.commandOk);
            this.commandManager.Commands.Add(this.commandCancel);
            this.commandManager.Components.Add(this.pbCancel);
            this.commandManager.Components.Add(this.pbOk);
            // 
            // commandOk
            // 
            resources.ApplyResources(this.commandOk, "commandOk");
            this.commandOk.Name = "commandOk";
            // 
            // commandCancel
            // 
            resources.ApplyResources(this.commandCancel, "commandCancel");
            this.commandCancel.Name = "commandCancel";
            // 
            // pbCancel
            // 
            this.pbCancel.AcceleratorKey = System.Windows.Forms.Keys.Escape;
            this.pbCancel.Command = this.commandCancel;
            resources.ApplyResources(this.pbCancel, "pbCancel");
            this.pbCancel.Name = "pbCancel";
            this.pbCancel.NamedProperties.Put("MethodId", "18385");
            this.pbCancel.NamedProperties.Put("MethodParameter", "Cancel");
            this.pbCancel.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // pbOk
            // 
            this.pbOk.AcceleratorKey = System.Windows.Forms.Keys.Return;
            this.pbOk.Command = this.commandOk;
            resources.ApplyResources(this.pbOk, "pbOk");
            this.pbOk.Name = "pbOk";
            this.pbOk.NamedProperties.Put("MethodId", "18385");
            this.pbOk.NamedProperties.Put("MethodParameter", "OK");
            this.pbOk.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // dfnNumberOfYears
            // 
            this.dfnNumberOfYears.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfnNumberOfYears, "dfnNumberOfYears");
            this.dfnNumberOfYears.Format = "#0";
            this.dfnNumberOfYears.Name = "dfnNumberOfYears";
            this.dfnNumberOfYears.NamedProperties.Put("EnumerateMethod", "");
            this.dfnNumberOfYears.NamedProperties.Put("FieldFlags", "263");
            this.dfnNumberOfYears.NamedProperties.Put("LovReference", "");
            this.dfnNumberOfYears.NamedProperties.Put("SqlColumn", "NO_OF_YEARS");
            this.dfnNumberOfYears.NamedProperties.Put("ValidateMethod", "");
            // 
            // dfnStartYear
            // 
            this.dfnStartYear.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfnStartYear, "dfnStartYear");
            this.dfnStartYear.Format = "#0";
            this.dfnStartYear.Name = "dfnStartYear";
            this.dfnStartYear.NamedProperties.Put("EnumerateMethod", "");
            this.dfnStartYear.NamedProperties.Put("FieldFlags", "263");
            this.dfnStartYear.NamedProperties.Put("Format", "");
            this.dfnStartYear.NamedProperties.Put("LovReference", "");
            this.dfnStartYear.NamedProperties.Put("SqlColumn", "START_YEAR");
            this.dfnStartYear.NamedProperties.Put("ValidateMethod", "");
            this.dfnStartYear.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfnStartYear_WindowActions);
            // 
            // labeldfnNumberOfYears
            // 
            resources.ApplyResources(this.labeldfnNumberOfYears, "labeldfnNumberOfYears");
            this.labeldfnNumberOfYears.Name = "labeldfnNumberOfYears";
            // 
            // labeldfdPeriodStartDate
            // 
            resources.ApplyResources(this.labeldfdPeriodStartDate, "labeldfdPeriodStartDate");
            this.labeldfdPeriodStartDate.Name = "labeldfdPeriodStartDate";
            // 
            // dfnStartMonth
            // 
            this.dfnStartMonth.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfnStartMonth, "dfnStartMonth");
            this.dfnStartMonth.Format = "#0";
            this.dfnStartMonth.Name = "dfnStartMonth";
            this.dfnStartMonth.NamedProperties.Put("EnumerateMethod", "");
            this.dfnStartMonth.NamedProperties.Put("FieldFlags", "263");
            this.dfnStartMonth.NamedProperties.Put("Format", "");
            this.dfnStartMonth.NamedProperties.Put("LovReference", "");
            this.dfnStartMonth.NamedProperties.Put("SqlColumn", "START_MONTH");
            this.dfnStartMonth.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfnStartMonth
            // 
            resources.ApplyResources(this.labeldfnStartMonth, "labeldfnStartMonth");
            this.labeldfnStartMonth.Name = "labeldfnStartMonth";
            // 
            // dfnFirstRpdId
            // 
            this.dfnFirstRpdId.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfnFirstRpdId, "dfnFirstRpdId");
            this.dfnFirstRpdId.Format = "#0";
            this.dfnFirstRpdId.Name = "dfnFirstRpdId";
            this.dfnFirstRpdId.NamedProperties.Put("EnumerateMethod", "");
            this.dfnFirstRpdId.NamedProperties.Put("FieldFlags", "263");
            this.dfnFirstRpdId.NamedProperties.Put("Format", "");
            this.dfnFirstRpdId.NamedProperties.Put("LovReference", "");
            this.dfnFirstRpdId.NamedProperties.Put("SqlColumn", "FIRST_RPD_ID");
            this.dfnFirstRpdId.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfnFirstRpdId
            // 
            resources.ApplyResources(this.labeldfnFirstRpdId, "labeldfnFirstRpdId");
            this.labeldfnFirstRpdId.Name = "labeldfnFirstRpdId";
            // 
            // gbCalendarYear
            // 
            this.gbCalendarYear.Controls.Add(this.dfnStartYear);
            this.gbCalendarYear.Controls.Add(this.labeldfnStartMonth);
            this.gbCalendarYear.Controls.Add(this.dfnStartMonth);
            this.gbCalendarYear.Controls.Add(this.labeldfdPeriodStartDate);
            this.gbCalendarYear.Controls.Add(this.dfnNumberOfYears);
            this.gbCalendarYear.Controls.Add(this.labeldfnNumberOfYears);
            resources.ApplyResources(this.gbCalendarYear, "gbCalendarYear");
            this.gbCalendarYear.Name = "gbCalendarYear";
            this.gbCalendarYear.TabStop = false;
            // 
            // gbReportingYear
            // 
            resources.ApplyResources(this.gbReportingYear, "gbReportingYear");
            this.gbReportingYear.Name = "gbReportingYear";
            this.gbReportingYear.TabStop = false;
            // 
            // dlgRpdGenOnCalendar
            // 
            resources.ApplyResources(this, "$this");
            this.DataBound = false;
            this.Name = "dlgRpdGenOnCalendar";
            this.NamedProperties.Put("LogicalUnit", "");
            this.NamedProperties.Put("ViewName", "");
            this.ShowIcon = false;
            this.ClientArea.ResumeLayout(false);
            this.ClientArea.PerformLayout();
            this.gbCalendarYear.ResumeLayout(false);
            this.gbCalendarYear.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        #region System Methods/Properties

        /// <summary>
        /// Release global reference.
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion

        protected Ifs.Fnd.Windows.Forms.FndCommand commandOk;
        protected Ifs.Fnd.Windows.Forms.FndCommand commandCancel;
        public cPushButton pbCancel;
        public cPushButton pbOk;
        public cDataField dfnStartYear;
        protected cBackgroundText labeldfdPeriodStartDate;
        protected cBackgroundText labeldfnNumberOfYears;
        public cDataField dfnNumberOfYears;
        public cDataField dfnFirstRpdId;
        protected cBackgroundText labeldfnFirstRpdId;
        public cDataField dfnStartMonth;
        protected cBackgroundText labeldfnStartMonth;
        protected SalGroupBox gbCalendarYear;
        protected SalGroupBox gbReportingYear;

    }
}
