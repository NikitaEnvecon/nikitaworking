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

namespace Ifs.Application.Fndmig_
{

    public partial class tbwIntfaceServerProcesses
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwIntfaceServerProcesses));
            this.colnScheduleId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsScheduleName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsActiveDb = new Ifs.Fnd.ApplicationForms.cColumn();
            this.coldEndDate = new Ifs.Fnd.ApplicationForms.cColumn();
            this.coldNextExecutionDate = new Ifs.Fnd.ApplicationForms.cColumn();
            this.coldModifiedDate = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colnExecutions = new Ifs.Fnd.ApplicationForms.cColumn();
            this.menuTbwMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItemExecuteJob = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuTbwMethods_menu_Execute_Job = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuItemViewSchedule = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuTbwMethods_menu_View_Schedule = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.coldStartDate = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsTaskName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsModuleName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsScheduledBy = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsExecutionPlan = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsLangCode = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.colsIntfaceName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.menuTbwMethods.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuTbwMethods_menu_Execute_Job);
            this.commandManager.Commands.Add(this.menuTbwMethods_menu_View_Schedule);
            this.commandManager.ContextMenus.Add(this.menuTbwMethods);
            // 
            // colnScheduleId
            // 
            this.colnScheduleId.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colnScheduleId.Name = "colnScheduleId";
            this.colnScheduleId.NamedProperties.Put("EnumerateMethod", "");
            this.colnScheduleId.NamedProperties.Put("FieldFlags", "160");
            this.colnScheduleId.NamedProperties.Put("Format", "");
            this.colnScheduleId.NamedProperties.Put("LovReference", "");
            this.colnScheduleId.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colnScheduleId.NamedProperties.Put("SqlColumn", "SCHEDULE_ID");
            this.colnScheduleId.Position = 3;
            this.colnScheduleId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.colnScheduleId, "colnScheduleId");
            // 
            // colsScheduleName
            // 
            this.colsScheduleName.MaxLength = 200;
            this.colsScheduleName.Name = "colsScheduleName";
            this.colsScheduleName.NamedProperties.Put("EnumerateMethod", "");
            this.colsScheduleName.NamedProperties.Put("FieldFlags", "295");
            this.colsScheduleName.NamedProperties.Put("LovReference", "");
            this.colsScheduleName.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsScheduleName.NamedProperties.Put("SqlColumn", "SCHEDULE_NAME");
            this.colsScheduleName.Position = 4;
            resources.ApplyResources(this.colsScheduleName, "colsScheduleName");
            // 
            // colsActiveDb
            // 
            this.colsActiveDb.CellType = PPJ.Runtime.Windows.CellType.CheckBox;
            this.colsActiveDb.CheckBox.CheckedValue = "TRUE";
            this.colsActiveDb.CheckBox.IgnoreCase = true;
            this.colsActiveDb.CheckBox.UncheckedValue = "FALSE";
            resources.ApplyResources(this.colsActiveDb, "colsActiveDb");
            this.colsActiveDb.MaxLength = 20;
            this.colsActiveDb.Name = "colsActiveDb";
            this.colsActiveDb.NamedProperties.Put("EnumerateMethod", "");
            this.colsActiveDb.NamedProperties.Put("FieldFlags", "288");
            this.colsActiveDb.NamedProperties.Put("LovReference", "");
            this.colsActiveDb.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsActiveDb.NamedProperties.Put("SqlColumn", "ACTIVE_DB");
            this.colsActiveDb.Position = 7;
            // 
            // coldEndDate
            // 
            this.coldEndDate.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.coldEndDate.Format = "G";
            this.coldEndDate.Name = "coldEndDate";
            this.coldEndDate.NamedProperties.Put("EnumerateMethod", "");
            this.coldEndDate.NamedProperties.Put("FieldFlags", "294");
            this.coldEndDate.NamedProperties.Put("LovReference", "");
            this.coldEndDate.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.coldEndDate.NamedProperties.Put("SqlColumn", "END_DATE");
            this.coldEndDate.Position = 10;
            resources.ApplyResources(this.coldEndDate, "coldEndDate");
            // 
            // coldNextExecutionDate
            // 
            this.coldNextExecutionDate.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.coldNextExecutionDate.Format = "G";
            this.coldNextExecutionDate.Name = "coldNextExecutionDate";
            this.coldNextExecutionDate.NamedProperties.Put("EnumerateMethod", "");
            this.coldNextExecutionDate.NamedProperties.Put("FieldFlags", "294");
            this.coldNextExecutionDate.NamedProperties.Put("LovReference", "");
            this.coldNextExecutionDate.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.coldNextExecutionDate.NamedProperties.Put("SqlColumn", "NEXT_EXECUTION_DATE");
            this.coldNextExecutionDate.Position = 11;
            resources.ApplyResources(this.coldNextExecutionDate, "coldNextExecutionDate");
            // 
            // coldModifiedDate
            // 
            this.coldModifiedDate.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.coldModifiedDate.Format = "G";
            this.coldModifiedDate.Name = "coldModifiedDate";
            this.coldModifiedDate.NamedProperties.Put("EnumerateMethod", "");
            this.coldModifiedDate.NamedProperties.Put("FieldFlags", "288");
            this.coldModifiedDate.NamedProperties.Put("LovReference", "");
            this.coldModifiedDate.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.coldModifiedDate.NamedProperties.Put("SqlColumn", "MODIFIED_DATE");
            this.coldModifiedDate.Position = 13;
            resources.ApplyResources(this.coldModifiedDate, "coldModifiedDate");
            // 
            // colnExecutions
            // 
            this.colnExecutions.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colnExecutions.Name = "colnExecutions";
            this.colnExecutions.NamedProperties.Put("EnumerateMethod", "");
            this.colnExecutions.NamedProperties.Put("FieldFlags", "288");
            this.colnExecutions.NamedProperties.Put("Format", "");
            this.colnExecutions.NamedProperties.Put("LovReference", "");
            this.colnExecutions.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colnExecutions.NamedProperties.Put("SqlColumn", "EXECUTIONS");
            this.colnExecutions.Position = 15;
            this.colnExecutions.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.colnExecutions, "colnExecutions");
            // 
            // menuTbwMethods
            // 
            this.menuTbwMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemExecuteJob,
            this.menuItemViewSchedule});
            this.menuTbwMethods.Name = "menuFrmMethods";
            resources.ApplyResources(this.menuTbwMethods, "menuTbwMethods");
            // 
            // menuItemExecuteJob
            // 
            this.menuItemExecuteJob.Command = this.menuTbwMethods_menu_Execute_Job;
            this.menuItemExecuteJob.Name = "menuItemExecuteJob";
            resources.ApplyResources(this.menuItemExecuteJob, "menuItemExecuteJob");
            this.menuItemExecuteJob.Text = "&Run";
            // 
            // menuTbwMethods_menu_Execute_Job
            // 
            resources.ApplyResources(this.menuTbwMethods_menu_Execute_Job, "menuTbwMethods_menu_Execute_Job");
            this.menuTbwMethods_menu_Execute_Job.Name = "menuTbwMethods_menu_Execute_Job";
            this.menuTbwMethods_menu_Execute_Job.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuTbwMethods_menu_Execute_Job_Execute);
            this.menuTbwMethods_menu_Execute_Job.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuTbwMethods_menu_Execute_Job_Inquire);
            // 
            // menuItemViewSchedule
            // 
            this.menuItemViewSchedule.Command = this.menuTbwMethods_menu_View_Schedule;
            this.menuItemViewSchedule.Name = "menuItemViewSchedule";
            resources.ApplyResources(this.menuItemViewSchedule, "menuItemViewSchedule");
            this.menuItemViewSchedule.Text = "&View Schedule";
            // 
            // menuTbwMethods_menu_View_Schedule
            // 
            resources.ApplyResources(this.menuTbwMethods_menu_View_Schedule, "menuTbwMethods_menu_View_Schedule");
            this.menuTbwMethods_menu_View_Schedule.Name = "menuTbwMethods_menu_View_Schedule";
            this.menuTbwMethods_menu_View_Schedule.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuTbwMethods_menu_View_Schedule_Execute);
            this.menuTbwMethods_menu_View_Schedule.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuTbwMethods_menu_View_Schedule_Inquire);
            // 
            // coldStartDate
            // 
            this.coldStartDate.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.coldStartDate.Format = "G";
            this.coldStartDate.Name = "coldStartDate";
            this.coldStartDate.NamedProperties.Put("EnumerateMethod", "");
            this.coldStartDate.NamedProperties.Put("FieldFlags", "295");
            this.coldStartDate.NamedProperties.Put("LovReference", "");
            this.coldStartDate.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.coldStartDate.NamedProperties.Put("SqlColumn", "START_DATE");
            this.coldStartDate.Position = 9;
            resources.ApplyResources(this.coldStartDate, "coldStartDate");
            // 
            // colsTaskName
            // 
            this.colsTaskName.MaxLength = 200;
            this.colsTaskName.Name = "colsTaskName";
            this.colsTaskName.NamedProperties.Put("EnumerateMethod", "");
            this.colsTaskName.NamedProperties.Put("FieldFlags", "288");
            this.colsTaskName.NamedProperties.Put("LovReference", "");
            this.colsTaskName.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsTaskName.NamedProperties.Put("SqlColumn", "TASK_NAME");
            this.colsTaskName.Position = 5;
            resources.ApplyResources(this.colsTaskName, "colsTaskName");
            // 
            // colsModuleName
            // 
            this.colsModuleName.MaxLength = 2000;
            this.colsModuleName.Name = "colsModuleName";
            this.colsModuleName.NamedProperties.Put("EnumerateMethod", "");
            this.colsModuleName.NamedProperties.Put("FieldFlags", "288");
            this.colsModuleName.NamedProperties.Put("LovReference", "");
            this.colsModuleName.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsModuleName.NamedProperties.Put("SqlColumn", "Module_API.Get_Name(MODULE)");
            this.colsModuleName.Position = 6;
            resources.ApplyResources(this.colsModuleName, "colsModuleName");
            // 
            // colsScheduledBy
            // 
            this.colsScheduledBy.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsScheduledBy.MaxLength = 30;
            this.colsScheduledBy.Name = "colsScheduledBy";
            this.colsScheduledBy.NamedProperties.Put("EnumerateMethod", "");
            this.colsScheduledBy.NamedProperties.Put("FieldFlags", "288");
            this.colsScheduledBy.NamedProperties.Put("LovReference", "");
            this.colsScheduledBy.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsScheduledBy.NamedProperties.Put("SqlColumn", "SCHEDULED_BY");
            this.colsScheduledBy.Position = 12;
            resources.ApplyResources(this.colsScheduledBy, "colsScheduledBy");
            // 
            // colsExecutionPlan
            // 
            this.colsExecutionPlan.MaxLength = 2000;
            this.colsExecutionPlan.Name = "colsExecutionPlan";
            this.colsExecutionPlan.NamedProperties.Put("EnumerateMethod", "");
            this.colsExecutionPlan.NamedProperties.Put("FieldFlags", "288");
            this.colsExecutionPlan.NamedProperties.Put("LovReference", "");
            this.colsExecutionPlan.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsExecutionPlan.NamedProperties.Put("SqlColumn", "Batch_Schedule_API.Get_Translated_Execution_Plan(SCHEDULE_ID, NULL, :i_hWndFrame." +
                    "tbwIntfaceServerProcesses.sDateFormat, :i_hWndFrame.tbwIntfaceServerProcesses.sT" +
                    "imeFormat)");
            this.colsExecutionPlan.Position = 8;
            resources.ApplyResources(this.colsExecutionPlan, "colsExecutionPlan");
            // 
            // colsLangCode
            // 
            this.colsLangCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.colsLangCode.MaxLength = 5;
            this.colsLangCode.Name = "colsLangCode";
            this.colsLangCode.NamedProperties.Put("EnumerateMethod", "LANGUAGE_CODE_API.Enumerate");
            this.colsLangCode.NamedProperties.Put("FieldFlags", "288");
            this.colsLangCode.NamedProperties.Put("LovReference", "LANGUAGE_CODE");
            this.colsLangCode.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsLangCode.NamedProperties.Put("SqlColumn", "LANG_CODE");
            this.colsLangCode.Position = 14;
            resources.ApplyResources(this.colsLangCode, "colsLangCode");
            // 
            // colsIntfaceName
            // 
            this.colsIntfaceName.MaxLength = 2000;
            this.colsIntfaceName.Name = "colsIntfaceName";
            this.colsIntfaceName.NamedProperties.Put("EnumerateMethod", "");
            this.colsIntfaceName.NamedProperties.Put("FieldFlags", "6912");
            this.colsIntfaceName.NamedProperties.Put("LovReference", "");
            this.colsIntfaceName.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsIntfaceName.NamedProperties.Put("SqlColumn", "Intface_Util_API.Get_Schedule_Intface_Name_(SCHEDULE_ID)");
            this.colsIntfaceName.Position = 16;
            resources.ApplyResources(this.colsIntfaceName, "colsIntfaceName");
            // 
            // tbwIntfaceServerProcesses
            // 
            resources.ApplyResources(this, "$this");
            this.ContextMenuStrip = this.menuTbwMethods;
            this.Controls.Add(this.colnScheduleId);
            this.Controls.Add(this.colsScheduleName);
            this.Controls.Add(this.colsTaskName);
            this.Controls.Add(this.colsModuleName);
            this.Controls.Add(this.colsActiveDb);
            this.Controls.Add(this.colsExecutionPlan);
            this.Controls.Add(this.coldStartDate);
            this.Controls.Add(this.coldEndDate);
            this.Controls.Add(this.coldNextExecutionDate);
            this.Controls.Add(this.colsScheduledBy);
            this.Controls.Add(this.coldModifiedDate);
            this.Controls.Add(this.colsLangCode);
            this.Controls.Add(this.colnExecutions);
            this.Controls.Add(this.colsIntfaceName);
            this.Name = "tbwIntfaceServerProcesses";
            this.NamedProperties.Put("DefaultWhere", "MODULE=\'FNDMIG\'");
            this.NamedProperties.Put("LogicalUnit", "BatchSchedule");
            this.NamedProperties.Put("SourceFlags", "16384");
            this.NamedProperties.Put("ViewName", "BATCH_SCHEDULE_TASK");
            this.Controls.SetChildIndex(this.colsIntfaceName, 0);
            this.Controls.SetChildIndex(this.colnExecutions, 0);
            this.Controls.SetChildIndex(this.colsLangCode, 0);
            this.Controls.SetChildIndex(this.coldModifiedDate, 0);
            this.Controls.SetChildIndex(this.colsScheduledBy, 0);
            this.Controls.SetChildIndex(this.coldNextExecutionDate, 0);
            this.Controls.SetChildIndex(this.coldEndDate, 0);
            this.Controls.SetChildIndex(this.coldStartDate, 0);
            this.Controls.SetChildIndex(this.colsExecutionPlan, 0);
            this.Controls.SetChildIndex(this.colsActiveDb, 0);
            this.Controls.SetChildIndex(this.colsModuleName, 0);
            this.Controls.SetChildIndex(this.colsTaskName, 0);
            this.Controls.SetChildIndex(this.colsScheduleName, 0);
            this.Controls.SetChildIndex(this.colnScheduleId, 0);
            this.Controls.SetChildIndex(this.@__colObjversion, 0);
            this.Controls.SetChildIndex(this.@__colObjid, 0);
            this.menuTbwMethods.ResumeLayout(false);
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

        protected cColumn colnScheduleId;
        protected cColumn colsScheduleName;
        protected cColumn colsActiveDb;
        protected cColumn coldEndDate;
        protected cColumn coldNextExecutionDate;
        protected cColumn coldModifiedDate;
        protected cColumn colnExecutions;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTbwMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItemExecuteJob;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItemViewSchedule;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menu_Execute_Job;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menu_View_Schedule;
        protected cColumn coldStartDate;
        protected cColumn colsTaskName;
        protected cColumn colsModuleName;
        protected cColumn colsScheduledBy;
        protected cColumn colsExecutionPlan;
        protected cLookupColumn colsLangCode;
        protected cColumn colsIntfaceName;
    }
}
