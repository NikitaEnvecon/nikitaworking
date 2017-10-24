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
using Ifs.Application.Appsrv;
using Ifs.Application.Enterp;
using Ifs.Fnd.ApplicationForms;
using PPJ.Runtime;
using PPJ.Runtime.Sql;
using PPJ.Runtime.Vis;
using PPJ.Runtime.Windows;
using PPJ.Runtime.Windows.QO;

namespace Ifs.Application.Accrul_
{
	
	public partial class tbwExtFileBatchJobs
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cColumn colnScheduleId;
		public cColumn colsFileType;
		public cColumn colsFileTemplate;
		public cColumn colExecutionPlan;
		public cColumn coldStartDate;
		public cColumn coldStopDate;
		public cColumn colsUsername;
		public cColumn coldModifiedDate;
		public cColumn coldNextExecutionDate;
		public cColumn colsStatus;
		public cColumn colnExecutions;
		public cColumn colnScheduleMethodId;
		public cColumn colExtFileBatchParam;
		public cColumn colScheduleName;
		public cColumn colParamString;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwExtFileBatchJobs));
            this.menuTbwMethods_menu_Load_Parameters_ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.colnScheduleId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsFileType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsFileTemplate = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colExecutionPlan = new Ifs.Fnd.ApplicationForms.cColumn();
            this.coldStartDate = new Ifs.Fnd.ApplicationForms.cColumn();
            this.coldStopDate = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsUsername = new Ifs.Fnd.ApplicationForms.cColumn();
            this.coldModifiedDate = new Ifs.Fnd.ApplicationForms.cColumn();
            this.coldNextExecutionDate = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsStatus = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colnExecutions = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colnScheduleMethodId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colExtFileBatchParam = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colScheduleName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colParamString = new Ifs.Fnd.ApplicationForms.cColumn();
            this.menuTbwMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem__Load = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuTbwMethods.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuTbwMethods_menu_Load_Parameters_);
            this.commandManager.ContextMenus.Add(this.menuTbwMethods);
            // 
            // menuTbwMethods_menu_Load_Parameters_
            // 
            resources.ApplyResources(this.menuTbwMethods_menu_Load_Parameters_, "menuTbwMethods_menu_Load_Parameters_");
            this.menuTbwMethods_menu_Load_Parameters_.Name = "menuTbwMethods_menu_Load_Parameters_";
            this.menuTbwMethods_menu_Load_Parameters_.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Load_Execute);
            this.menuTbwMethods_menu_Load_Parameters_.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Load_Inquire);
            // 
            // colnScheduleId
            // 
            this.colnScheduleId.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colnScheduleId.Name = "colnScheduleId";
            this.colnScheduleId.NamedProperties.Put("EnumerateMethod", "");
            this.colnScheduleId.NamedProperties.Put("FieldFlags", "160");
            this.colnScheduleId.NamedProperties.Put("LovReference", "");
            this.colnScheduleId.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colnScheduleId.NamedProperties.Put("SqlColumn", "SCHEDULE_ID");
            this.colnScheduleId.Position = 3;
            resources.ApplyResources(this.colnScheduleId, "colnScheduleId");
            // 
            // colsFileType
            // 
            this.colsFileType.MaxLength = 30;
            this.colsFileType.Name = "colsFileType";
            this.colsFileType.NamedProperties.Put("EnumerateMethod", "");
            this.colsFileType.NamedProperties.Put("FieldFlags", "288");
            this.colsFileType.NamedProperties.Put("LovReference", "");
            this.colsFileType.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsFileType.NamedProperties.Put("SqlColumn", "FILE_TYPE");
            this.colsFileType.Position = 4;
            resources.ApplyResources(this.colsFileType, "colsFileType");
            // 
            // colsFileTemplate
            // 
            this.colsFileTemplate.MaxLength = 30;
            this.colsFileTemplate.Name = "colsFileTemplate";
            this.colsFileTemplate.NamedProperties.Put("EnumerateMethod", "");
            this.colsFileTemplate.NamedProperties.Put("FieldFlags", "288");
            this.colsFileTemplate.NamedProperties.Put("LovReference", "");
            this.colsFileTemplate.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsFileTemplate.NamedProperties.Put("SqlColumn", "FILE_TEMPLATE");
            this.colsFileTemplate.Position = 5;
            resources.ApplyResources(this.colsFileTemplate, "colsFileTemplate");
            // 
            // colExecutionPlan
            // 
            this.colExecutionPlan.MaxLength = 765;
            this.colExecutionPlan.Name = "colExecutionPlan";
            this.colExecutionPlan.NamedProperties.Put("EnumerateMethod", "");
            this.colExecutionPlan.NamedProperties.Put("FieldFlags", "304");
            this.colExecutionPlan.NamedProperties.Put("LovReference", "");
            this.colExecutionPlan.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colExecutionPlan.NamedProperties.Put("SqlColumn", "EXECUTION_PLAN");
            this.colExecutionPlan.Position = 6;
            resources.ApplyResources(this.colExecutionPlan, "colExecutionPlan");
            // 
            // coldStartDate
            // 
            this.coldStartDate.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.coldStartDate.Format = "G";
            this.coldStartDate.Name = "coldStartDate";
            this.coldStartDate.NamedProperties.Put("EnumerateMethod", "");
            this.coldStartDate.NamedProperties.Put("FieldFlags", "288");
            this.coldStartDate.NamedProperties.Put("LovReference", "");
            this.coldStartDate.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.coldStartDate.NamedProperties.Put("SqlColumn", "START_DATE");
            this.coldStartDate.Position = 7;
            resources.ApplyResources(this.coldStartDate, "coldStartDate");
            // 
            // coldStopDate
            // 
            this.coldStopDate.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.coldStopDate.Format = "G";
            this.coldStopDate.Name = "coldStopDate";
            this.coldStopDate.NamedProperties.Put("EnumerateMethod", "");
            this.coldStopDate.NamedProperties.Put("FieldFlags", "288");
            this.coldStopDate.NamedProperties.Put("LovReference", "");
            this.coldStopDate.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.coldStopDate.NamedProperties.Put("SqlColumn", "STOP_DATE");
            this.coldStopDate.Position = 8;
            resources.ApplyResources(this.coldStopDate, "coldStopDate");
            // 
            // colsUsername
            // 
            this.colsUsername.MaxLength = 90;
            this.colsUsername.Name = "colsUsername";
            this.colsUsername.NamedProperties.Put("EnumerateMethod", "");
            this.colsUsername.NamedProperties.Put("FieldFlags", "288");
            this.colsUsername.NamedProperties.Put("LovReference", "");
            this.colsUsername.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsUsername.NamedProperties.Put("SqlColumn", "USERNAME");
            this.colsUsername.Position = 9;
            resources.ApplyResources(this.colsUsername, "colsUsername");
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
            this.coldModifiedDate.Position = 10;
            resources.ApplyResources(this.coldModifiedDate, "coldModifiedDate");
            // 
            // coldNextExecutionDate
            // 
            this.coldNextExecutionDate.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.coldNextExecutionDate.Format = "G";
            this.coldNextExecutionDate.Name = "coldNextExecutionDate";
            this.coldNextExecutionDate.NamedProperties.Put("EnumerateMethod", "");
            this.coldNextExecutionDate.NamedProperties.Put("FieldFlags", "288");
            this.coldNextExecutionDate.NamedProperties.Put("LovReference", "");
            this.coldNextExecutionDate.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.coldNextExecutionDate.NamedProperties.Put("SqlColumn", "NEXT_EXECUTION_DATE");
            this.coldNextExecutionDate.Position = 11;
            resources.ApplyResources(this.coldNextExecutionDate, "coldNextExecutionDate");
            // 
            // colsStatus
            // 
            this.colsStatus.MaxLength = 200;
            this.colsStatus.Name = "colsStatus";
            this.colsStatus.NamedProperties.Put("EnumerateMethod", "");
            this.colsStatus.NamedProperties.Put("FieldFlags", "288");
            this.colsStatus.NamedProperties.Put("LovReference", "");
            this.colsStatus.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsStatus.NamedProperties.Put("SqlColumn", "STATUS");
            this.colsStatus.Position = 12;
            resources.ApplyResources(this.colsStatus, "colsStatus");
            // 
            // colnExecutions
            // 
            this.colnExecutions.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colnExecutions.Name = "colnExecutions";
            this.colnExecutions.NamedProperties.Put("EnumerateMethod", "");
            this.colnExecutions.NamedProperties.Put("FieldFlags", "288");
            this.colnExecutions.NamedProperties.Put("LovReference", "");
            this.colnExecutions.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colnExecutions.NamedProperties.Put("SqlColumn", "EXECUTIONS");
            this.colnExecutions.Position = 13;
            resources.ApplyResources(this.colnExecutions, "colnExecutions");
            // 
            // colnScheduleMethodId
            // 
            this.colnScheduleMethodId.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colnScheduleMethodId.Name = "colnScheduleMethodId";
            this.colnScheduleMethodId.NamedProperties.Put("EnumerateMethod", "");
            this.colnScheduleMethodId.NamedProperties.Put("FieldFlags", "288");
            this.colnScheduleMethodId.NamedProperties.Put("LovReference", "");
            this.colnScheduleMethodId.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colnScheduleMethodId.NamedProperties.Put("SqlColumn", "SCHEDULE_METHOD_ID");
            this.colnScheduleMethodId.Position = 14;
            resources.ApplyResources(this.colnScheduleMethodId, "colnScheduleMethodId");
            // 
            // colExtFileBatchParam
            // 
            this.colExtFileBatchParam.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colExtFileBatchParam.Name = "colExtFileBatchParam";
            this.colExtFileBatchParam.NamedProperties.Put("EnumerateMethod", "");
            this.colExtFileBatchParam.NamedProperties.Put("FieldFlags", "310");
            this.colExtFileBatchParam.NamedProperties.Put("LovReference", "");
            this.colExtFileBatchParam.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colExtFileBatchParam.NamedProperties.Put("ResizeableChildObject", "");
            this.colExtFileBatchParam.NamedProperties.Put("SqlColumn", "VALUE");
            this.colExtFileBatchParam.NamedProperties.Put("ValidateMethod", "");
            this.colExtFileBatchParam.Position = 15;
            resources.ApplyResources(this.colExtFileBatchParam, "colExtFileBatchParam");
            // 
            // colScheduleName
            // 
            this.colScheduleName.MaxLength = 600;
            this.colScheduleName.Name = "colScheduleName";
            this.colScheduleName.NamedProperties.Put("EnumerateMethod", "");
            this.colScheduleName.NamedProperties.Put("FieldFlags", "304");
            this.colScheduleName.NamedProperties.Put("LovReference", "");
            this.colScheduleName.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colScheduleName.NamedProperties.Put("SqlColumn", "SCHEDULE_NAME");
            this.colScheduleName.Position = 16;
            resources.ApplyResources(this.colScheduleName, "colScheduleName");
            // 
            // colParamString
            // 
            this.colParamString.MaxLength = 2000;
            this.colParamString.Name = "colParamString";
            this.colParamString.NamedProperties.Put("EnumerateMethod", "");
            this.colParamString.NamedProperties.Put("FieldFlags", "306");
            this.colParamString.NamedProperties.Put("LovReference", "");
            this.colParamString.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colParamString.NamedProperties.Put("ResizeableChildObject", "");
            this.colParamString.NamedProperties.Put("SqlColumn", "PARAM_STRING");
            this.colParamString.NamedProperties.Put("ValidateMethod", "");
            this.colParamString.Position = 17;
            resources.ApplyResources(this.colParamString, "colParamString");
            // 
            // menuTbwMethods
            // 
            this.menuTbwMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem__Load});
            this.menuTbwMethods.Name = "menuTbwMethods";
            resources.ApplyResources(this.menuTbwMethods, "menuTbwMethods");
            // 
            // menuItem__Load
            // 
            this.menuItem__Load.Command = this.menuTbwMethods_menu_Load_Parameters_;
            this.menuItem__Load.Name = "menuItem__Load";
            resources.ApplyResources(this.menuItem__Load, "menuItem__Load");
            this.menuItem__Load.Text = "&Load Parameters.";
            // 
            // tbwExtFileBatchJobs
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colnScheduleId);
            this.Controls.Add(this.colsFileType);
            this.Controls.Add(this.colsFileTemplate);
            this.Controls.Add(this.colExecutionPlan);
            this.Controls.Add(this.coldStartDate);
            this.Controls.Add(this.coldStopDate);
            this.Controls.Add(this.colsUsername);
            this.Controls.Add(this.coldModifiedDate);
            this.Controls.Add(this.coldNextExecutionDate);
            this.Controls.Add(this.colsStatus);
            this.Controls.Add(this.colnExecutions);
            this.Controls.Add(this.colnScheduleMethodId);
            this.Controls.Add(this.colExtFileBatchParam);
            this.Controls.Add(this.colScheduleName);
            this.Controls.Add(this.colParamString);
            this.Name = "tbwExtFileBatchJobs";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "ExtFileBatchParam");
            this.NamedProperties.Put("PackageName", "EXT_FILE_BATCH_PARAM_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "1");
            this.NamedProperties.Put("ViewName", "EXT_FILE_BATCH_JOBS");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tbwExtFileBatchJobs_WindowActions);
            this.Controls.SetChildIndex(this.colParamString, 0);
            this.Controls.SetChildIndex(this.colScheduleName, 0);
            this.Controls.SetChildIndex(this.colExtFileBatchParam, 0);
            this.Controls.SetChildIndex(this.colnScheduleMethodId, 0);
            this.Controls.SetChildIndex(this.colnExecutions, 0);
            this.Controls.SetChildIndex(this.colsStatus, 0);
            this.Controls.SetChildIndex(this.coldNextExecutionDate, 0);
            this.Controls.SetChildIndex(this.coldModifiedDate, 0);
            this.Controls.SetChildIndex(this.colsUsername, 0);
            this.Controls.SetChildIndex(this.coldStopDate, 0);
            this.Controls.SetChildIndex(this.coldStartDate, 0);
            this.Controls.SetChildIndex(this.colExecutionPlan, 0);
            this.Controls.SetChildIndex(this.colsFileTemplate, 0);
            this.Controls.SetChildIndex(this.colsFileType, 0);
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

        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menu_Load_Parameters_;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTbwMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Load;
	}
}
