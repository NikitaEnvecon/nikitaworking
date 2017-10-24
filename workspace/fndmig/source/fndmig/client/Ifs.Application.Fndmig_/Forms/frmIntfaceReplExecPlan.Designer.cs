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
using Ifs.Fnd.ApplicationForms;
using PPJ.Runtime;
using PPJ.Runtime.Sql;
using PPJ.Runtime.Vis;
using PPJ.Runtime.Windows;
using PPJ.Runtime.Windows.QO;

namespace Ifs.Application.Fndmig_
{
	
	public partial class frmIntfaceReplExecPlan
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		protected SalGroupBox gbRepeated_Execution;
		public SalRadioButton rbInterval;
		public SalRadioButton rbDaily;
		public SalRadioButton rbWeekly;
		public SalDataField dfnInterval;
		public SalComboBox cmbInterval;
		public SalDataField dfRepeatedTime;
		public SalCheckBox cbMonday;
		public SalCheckBox cbTuesday;
		public SalCheckBox cbWednesday;
		public SalCheckBox cbThursday;
		public SalCheckBox cbFriday;
		public SalCheckBox cbSaturday;
		public SalCheckBox cbSunday;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIntfaceReplExecPlan));
            this.menuFrmMethods_menuCreate_Execution_Plan = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuFrmMethods_menuSchedule_Insert_Package = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuFrmMethods_menuSchedule_Update_Package = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.gbRepeated_Execution = new PPJ.Runtime.Windows.SalGroupBox();
            this.rbInterval = new PPJ.Runtime.Windows.SalRadioButton();
            this.rbDaily = new PPJ.Runtime.Windows.SalRadioButton();
            this.rbWeekly = new PPJ.Runtime.Windows.SalRadioButton();
            this.dfnInterval = new PPJ.Runtime.Windows.SalDataField();
            this.cmbInterval = new PPJ.Runtime.Windows.SalComboBox();
            this.dfRepeatedTime = new PPJ.Runtime.Windows.SalDataField();
            this.cbMonday = new PPJ.Runtime.Windows.SalCheckBox();
            this.cbTuesday = new PPJ.Runtime.Windows.SalCheckBox();
            this.cbWednesday = new PPJ.Runtime.Windows.SalCheckBox();
            this.cbThursday = new PPJ.Runtime.Windows.SalCheckBox();
            this.cbFriday = new PPJ.Runtime.Windows.SalCheckBox();
            this.cbSaturday = new PPJ.Runtime.Windows.SalCheckBox();
            this.cbSunday = new PPJ.Runtime.Windows.SalCheckBox();
            this.menuFrmMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_Create = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem_Schedule = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem_Schedule_1 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuFrmMethods.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuFrmMethods_menuCreate_Execution_Plan);
            this.commandManager.Commands.Add(this.menuFrmMethods_menuSchedule_Insert_Package);
            this.commandManager.Commands.Add(this.menuFrmMethods_menuSchedule_Update_Package);
            this.commandManager.ContextMenus.Add(this.menuFrmMethods);
            // 
            // menuFrmMethods_menuCreate_Execution_Plan
            // 
            resources.ApplyResources(this.menuFrmMethods_menuCreate_Execution_Plan, "menuFrmMethods_menuCreate_Execution_Plan");
            this.menuFrmMethods_menuCreate_Execution_Plan.Name = "menuFrmMethods_menuCreate_Execution_Plan";
            this.menuFrmMethods_menuCreate_Execution_Plan.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Create_Execute);
            this.menuFrmMethods_menuCreate_Execution_Plan.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Create_Inquire);
            // 
            // menuFrmMethods_menuSchedule_Insert_Package
            // 
            resources.ApplyResources(this.menuFrmMethods_menuSchedule_Insert_Package, "menuFrmMethods_menuSchedule_Insert_Package");
            this.menuFrmMethods_menuSchedule_Insert_Package.Name = "menuFrmMethods_menuSchedule_Insert_Package";
            this.menuFrmMethods_menuSchedule_Insert_Package.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Schedule_Execute);
            this.menuFrmMethods_menuSchedule_Insert_Package.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Schedule_Inquire);
            // 
            // menuFrmMethods_menuSchedule_Update_Package
            // 
            resources.ApplyResources(this.menuFrmMethods_menuSchedule_Update_Package, "menuFrmMethods_menuSchedule_Update_Package");
            this.menuFrmMethods_menuSchedule_Update_Package.Name = "menuFrmMethods_menuSchedule_Update_Package";
            this.menuFrmMethods_menuSchedule_Update_Package.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Schedule_1_Execute);
            this.menuFrmMethods_menuSchedule_Update_Package.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Schedule_1_Inquire);
            // 
            // gbRepeated_Execution
            // 
            resources.ApplyResources(this.gbRepeated_Execution, "gbRepeated_Execution");
            this.gbRepeated_Execution.Name = "gbRepeated_Execution";
            this.gbRepeated_Execution.TabStop = false;
            // 
            // rbInterval
            // 
            resources.ApplyResources(this.rbInterval, "rbInterval");
            this.rbInterval.Name = "rbInterval";
            this.rbInterval.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.rbInterval_WindowActions);
            // 
            // rbDaily
            // 
            resources.ApplyResources(this.rbDaily, "rbDaily");
            this.rbDaily.Name = "rbDaily";
            this.rbDaily.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.rbDaily_WindowActions);
            // 
            // rbWeekly
            // 
            resources.ApplyResources(this.rbWeekly, "rbWeekly");
            this.rbWeekly.Name = "rbWeekly";
            this.rbWeekly.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.rbWeekly_WindowActions);
            // 
            // dfnInterval
            // 
            this.dfnInterval.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfnInterval, "dfnInterval");
            this.dfnInterval.Name = "dfnInterval";
            // 
            // cmbInterval
            // 
            resources.ApplyResources(this.cmbInterval, "cmbInterval");
            this.cmbInterval.Name = "cmbInterval";
            // 
            // dfRepeatedTime
            // 
            this.dfRepeatedTime.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.dfRepeatedTime.EditMask = "99:99";
            resources.ApplyResources(this.dfRepeatedTime, "dfRepeatedTime");
            this.dfRepeatedTime.Format = "HH:mm";
            this.dfRepeatedTime.Name = "dfRepeatedTime";
            // 
            // cbMonday
            // 
            resources.ApplyResources(this.cbMonday, "cbMonday");
            this.cbMonday.Name = "cbMonday";
            // 
            // cbTuesday
            // 
            resources.ApplyResources(this.cbTuesday, "cbTuesday");
            this.cbTuesday.Name = "cbTuesday";
            // 
            // cbWednesday
            // 
            resources.ApplyResources(this.cbWednesday, "cbWednesday");
            this.cbWednesday.Name = "cbWednesday";
            // 
            // cbThursday
            // 
            resources.ApplyResources(this.cbThursday, "cbThursday");
            this.cbThursday.Name = "cbThursday";
            // 
            // cbFriday
            // 
            resources.ApplyResources(this.cbFriday, "cbFriday");
            this.cbFriday.Name = "cbFriday";
            // 
            // cbSaturday
            // 
            resources.ApplyResources(this.cbSaturday, "cbSaturday");
            this.cbSaturday.Name = "cbSaturday";
            // 
            // cbSunday
            // 
            resources.ApplyResources(this.cbSunday, "cbSunday");
            this.cbSunday.Name = "cbSunday";
            // 
            // menuFrmMethods
            // 
            this.menuFrmMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_Create,
            this.menuItem_Schedule,
            this.menuItem_Schedule_1});
            this.menuFrmMethods.Name = "menuFrmMethods";
            resources.ApplyResources(this.menuFrmMethods, "menuFrmMethods");
            // 
            // menuItem_Create
            // 
            this.menuItem_Create.Command = this.menuFrmMethods_menuCreate_Execution_Plan;
            this.menuItem_Create.Name = "menuItem_Create";
            resources.ApplyResources(this.menuItem_Create, "menuItem_Create");
            this.menuItem_Create.Text = "Create Execution Plan";
            // 
            // menuItem_Schedule
            // 
            this.menuItem_Schedule.Command = this.menuFrmMethods_menuSchedule_Insert_Package;
            this.menuItem_Schedule.Name = "menuItem_Schedule";
            resources.ApplyResources(this.menuItem_Schedule, "menuItem_Schedule");
            this.menuItem_Schedule.Text = "Schedule Insert Package";
            // 
            // menuItem_Schedule_1
            // 
            this.menuItem_Schedule_1.Command = this.menuFrmMethods_menuSchedule_Update_Package;
            this.menuItem_Schedule_1.Name = "menuItem_Schedule_1";
            resources.ApplyResources(this.menuItem_Schedule_1, "menuItem_Schedule_1");
            this.menuItem_Schedule_1.Text = "Schedule Update Package";
            // 
            // frmIntfaceReplExecPlan
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.cbSunday);
            this.Controls.Add(this.cbSaturday);
            this.Controls.Add(this.cbFriday);
            this.Controls.Add(this.cbThursday);
            this.Controls.Add(this.cbWednesday);
            this.Controls.Add(this.cbTuesday);
            this.Controls.Add(this.cbMonday);
            this.Controls.Add(this.dfRepeatedTime);
            this.Controls.Add(this.cmbInterval);
            this.Controls.Add(this.dfnInterval);
            this.Controls.Add(this.rbWeekly);
            this.Controls.Add(this.rbDaily);
            this.Controls.Add(this.rbInterval);
            this.Controls.Add(this.gbRepeated_Execution);
            this.Name = "frmIntfaceReplExecPlan";
            this.NamedProperties.Put("SourceFlags", "449");
            this.menuFrmMethods.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

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

        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menuCreate_Execution_Plan;
        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menuSchedule_Insert_Package;
        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menuSchedule_Update_Package;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuFrmMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Create;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Schedule;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Schedule_1;
	}
}
