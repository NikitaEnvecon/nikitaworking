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
	
	public partial class tbwIntfaceJobHistHead
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cColumn colsIntfaceName;
		public cColumn colIntfaceHeaderDescription;
		public cColumn colnExecutionNo;
		public cColumn colLastInfo;
		public cColumn colsExecutedBy;
		public cColumn coldDateExecuted;
		public cLookupColumn colsStatus;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwIntfaceJobHistHead));
            this.menuTbwMethods_menu_Job_History_Details___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.colsIntfaceName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colIntfaceHeaderDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colnExecutionNo = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colLastInfo = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsExecutedBy = new Ifs.Fnd.ApplicationForms.cColumn();
            this.coldDateExecuted = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsStatus = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.menuTbwMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem__Job = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuTbwMethods.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuTbwMethods_menu_Job_History_Details___);
            this.commandManager.ContextMenus.Add(this.menuTbwMethods);
            // 
            // menuTbwMethods_menu_Job_History_Details___
            // 
            resources.ApplyResources(this.menuTbwMethods_menu_Job_History_Details___, "menuTbwMethods_menu_Job_History_Details___");
            this.menuTbwMethods_menu_Job_History_Details___.Name = "menuTbwMethods_menu_Job_History_Details___";
            this.menuTbwMethods_menu_Job_History_Details___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Job_Execute);
            this.menuTbwMethods_menu_Job_History_Details___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Job_Inquire);
            // 
            // colsIntfaceName
            // 
            this.colsIntfaceName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsIntfaceName.MaxLength = 30;
            this.colsIntfaceName.Name = "colsIntfaceName";
            this.colsIntfaceName.NamedProperties.Put("EnumerateMethod", "");
            this.colsIntfaceName.NamedProperties.Put("FieldFlags", "97");
            this.colsIntfaceName.NamedProperties.Put("LovReference", "INTFACE_HEADER");
            this.colsIntfaceName.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsIntfaceName.NamedProperties.Put("SqlColumn", "INTFACE_NAME");
            this.colsIntfaceName.NamedProperties.Put("ValidateMethod", "");
            this.colsIntfaceName.Position = 3;
            resources.ApplyResources(this.colsIntfaceName, "colsIntfaceName");
            // 
            // colIntfaceHeaderDescription
            // 
            this.colIntfaceHeaderDescription.MaxLength = 2000;
            this.colIntfaceHeaderDescription.Name = "colIntfaceHeaderDescription";
            this.colIntfaceHeaderDescription.NamedProperties.Put("EnumerateMethod", "");
            this.colIntfaceHeaderDescription.NamedProperties.Put("FieldFlags", "288");
            this.colIntfaceHeaderDescription.NamedProperties.Put("LovReference", "");
            this.colIntfaceHeaderDescription.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colIntfaceHeaderDescription.NamedProperties.Put("SqlColumn", "INTFACE_HEADER_API.Get_Description(INTFACE_NAME)");
            this.colIntfaceHeaderDescription.NamedProperties.Put("ValidateMethod", "");
            this.colIntfaceHeaderDescription.Position = 4;
            resources.ApplyResources(this.colIntfaceHeaderDescription, "colIntfaceHeaderDescription");
            // 
            // colnExecutionNo
            // 
            this.colnExecutionNo.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colnExecutionNo.Name = "colnExecutionNo";
            this.colnExecutionNo.NamedProperties.Put("EnumerateMethod", "");
            this.colnExecutionNo.NamedProperties.Put("FieldFlags", "161");
            this.colnExecutionNo.NamedProperties.Put("LovReference", "");
            this.colnExecutionNo.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colnExecutionNo.NamedProperties.Put("SqlColumn", "EXECUTION_NO");
            this.colnExecutionNo.NamedProperties.Put("ValidateMethod", "");
            this.colnExecutionNo.Position = 5;
            resources.ApplyResources(this.colnExecutionNo, "colnExecutionNo");
            // 
            // colLastInfo
            // 
            this.colLastInfo.MaxLength = 4000;
            this.colLastInfo.Name = "colLastInfo";
            this.colLastInfo.NamedProperties.Put("EnumerateMethod", "");
            this.colLastInfo.NamedProperties.Put("FieldFlags", "304");
            this.colLastInfo.NamedProperties.Put("LovReference", "");
            this.colLastInfo.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colLastInfo.NamedProperties.Put("SqlColumn", "LAST_INFO");
            this.colLastInfo.NamedProperties.Put("ValidateMethod", "");
            this.colLastInfo.Position = 6;
            resources.ApplyResources(this.colLastInfo, "colLastInfo");
            // 
            // colsExecutedBy
            // 
            this.colsExecutedBy.MaxLength = 30;
            this.colsExecutedBy.Name = "colsExecutedBy";
            this.colsExecutedBy.NamedProperties.Put("EnumerateMethod", "");
            this.colsExecutedBy.NamedProperties.Put("FieldFlags", "289");
            this.colsExecutedBy.NamedProperties.Put("LovReference", "");
            this.colsExecutedBy.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsExecutedBy.NamedProperties.Put("SqlColumn", "EXECUTED_BY");
            this.colsExecutedBy.NamedProperties.Put("ValidateMethod", "");
            this.colsExecutedBy.Position = 7;
            resources.ApplyResources(this.colsExecutedBy, "colsExecutedBy");
            // 
            // coldDateExecuted
            // 
            this.coldDateExecuted.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.coldDateExecuted.Format = "d";
            this.coldDateExecuted.Name = "coldDateExecuted";
            this.coldDateExecuted.NamedProperties.Put("EnumerateMethod", "");
            this.coldDateExecuted.NamedProperties.Put("FieldFlags", "289");
            this.coldDateExecuted.NamedProperties.Put("LovReference", "");
            this.coldDateExecuted.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.coldDateExecuted.NamedProperties.Put("SqlColumn", "DATE_EXECUTED");
            this.coldDateExecuted.NamedProperties.Put("ValidateMethod", "");
            this.coldDateExecuted.Position = 8;
            resources.ApplyResources(this.coldDateExecuted, "coldDateExecuted");
            // 
            // colsStatus
            // 
            this.colsStatus.MaxLength = 200;
            this.colsStatus.Name = "colsStatus";
            this.colsStatus.NamedProperties.Put("EnumerateMethod", "INTFACE_JOB_STATUS_API.Enumerate");
            this.colsStatus.NamedProperties.Put("FieldFlags", "289");
            this.colsStatus.NamedProperties.Put("LovReference", "");
            this.colsStatus.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsStatus.NamedProperties.Put("SqlColumn", "STATUS");
            this.colsStatus.NamedProperties.Put("ValidateMethod", "");
            this.colsStatus.Position = 9;
            resources.ApplyResources(this.colsStatus, "colsStatus");
            // 
            // menuTbwMethods
            // 
            this.menuTbwMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem__Job});
            this.menuTbwMethods.Name = "menuTbwMethods";
            resources.ApplyResources(this.menuTbwMethods, "menuTbwMethods");
            // 
            // menuItem__Job
            // 
            this.menuItem__Job.Command = this.menuTbwMethods_menu_Job_History_Details___;
            this.menuItem__Job.Name = "menuItem__Job";
            resources.ApplyResources(this.menuItem__Job, "menuItem__Job");
            this.menuItem__Job.Text = "&Job History Details...";
            // 
            // tbwIntfaceJobHistHead
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colsIntfaceName);
            this.Controls.Add(this.colIntfaceHeaderDescription);
            this.Controls.Add(this.colnExecutionNo);
            this.Controls.Add(this.colLastInfo);
            this.Controls.Add(this.colsExecutedBy);
            this.Controls.Add(this.coldDateExecuted);
            this.Controls.Add(this.colsStatus);
            this.Name = "tbwIntfaceJobHistHead";
            this.NamedProperties.Put("DefaultOrderBy", "INTFACE_NAME, EXECUTION_NO DESC");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "IntfaceJobHistHead");
            this.NamedProperties.Put("PackageName", "INTFACE_JOB_HIST_HEAD_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "1");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.NamedProperties.Put("ViewName", "INTFACE_JOB_HIST_HEAD");
            this.Controls.SetChildIndex(this.colsStatus, 0);
            this.Controls.SetChildIndex(this.coldDateExecuted, 0);
            this.Controls.SetChildIndex(this.colsExecutedBy, 0);
            this.Controls.SetChildIndex(this.colLastInfo, 0);
            this.Controls.SetChildIndex(this.colnExecutionNo, 0);
            this.Controls.SetChildIndex(this.colIntfaceHeaderDescription, 0);
            this.Controls.SetChildIndex(this.colsIntfaceName, 0);
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

        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menu_Job_History_Details___;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTbwMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Job;
	}
}
