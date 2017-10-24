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
	
	public partial class frmIntfaceStart
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		protected SalBackgroundText labelcmbIntfaceName;
		public cRecListDataField cmbIntfaceName;
		protected SalBackgroundText labeldfsDescription;
		public cDataField dfsDescription;
		protected SalBackgroundText labeldfsGroupId;
		public cDataField dfsGroupId;
		protected SalBackgroundText labeldfsIntfacePath;
		public cDataField dfsIntfacePath;
		protected SalBackgroundText labeldfsIntfaceFile;
		public cDataField dfsIntfaceFile;
		protected SalBackgroundText labeldfsFileLocation;
		public cDataField dfsFileLocation;
		protected SalBackgroundText labeldfsStatus;
		public cDataField dfsStatus;
		protected SalBackgroundText labeldfdLastExecuted;
		public cDataField dfdLastExecuted;
		protected SalBackgroundText labeldfsExecutedBy;
		public cDataField dfsExecutedBy;
		protected SalBackgroundText labeldfsLastInfo;
		public cDataField dfsLastInfo;
		// Hidden begin
		protected SalBackgroundText labeldfsProcedureName;
		public cDataField dfsProcedureName;
		protected SalBackgroundText labeldfsDirection;
		public cDataField dfsDirection;
		protected SalBackgroundText labeldfsFileLocationDb;
		public cDataField dfsFileLocationDb;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIntfaceStart));
            this.menuFrmMethods_menuStart_Online = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuFrmMethods_menuRestart_Online = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuFrmMethods_menuSchedule_Job = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuFrmMethods_menuUnpack_File = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuFrmMethods_menuClean_Up = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.labelcmbIntfaceName = new PPJ.Runtime.Windows.SalBackgroundText();
            this.cmbIntfaceName = new Ifs.Fnd.ApplicationForms.cRecListDataField();
            this.labeldfsDescription = new PPJ.Runtime.Windows.SalBackgroundText();
            this.dfsDescription = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsGroupId = new PPJ.Runtime.Windows.SalBackgroundText();
            this.dfsGroupId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsIntfacePath = new PPJ.Runtime.Windows.SalBackgroundText();
            this.dfsIntfacePath = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsIntfaceFile = new PPJ.Runtime.Windows.SalBackgroundText();
            this.dfsIntfaceFile = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsFileLocation = new PPJ.Runtime.Windows.SalBackgroundText();
            this.dfsFileLocation = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsStatus = new PPJ.Runtime.Windows.SalBackgroundText();
            this.dfsStatus = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfdLastExecuted = new PPJ.Runtime.Windows.SalBackgroundText();
            this.dfdLastExecuted = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsExecutedBy = new PPJ.Runtime.Windows.SalBackgroundText();
            this.dfsExecutedBy = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsLastInfo = new PPJ.Runtime.Windows.SalBackgroundText();
            this.dfsLastInfo = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsProcedureName = new PPJ.Runtime.Windows.SalBackgroundText();
            this.dfsProcedureName = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsDirection = new PPJ.Runtime.Windows.SalBackgroundText();
            this.dfsDirection = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsFileLocationDb = new PPJ.Runtime.Windows.SalBackgroundText();
            this.dfsFileLocationDb = new Ifs.Fnd.ApplicationForms.cDataField();
            this.menuFrmMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_Start = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem_Restart = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem_Schedule = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem_Unpack = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem_Clean = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuFrmMethods_menuJob = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuItem_MigJob = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuFrmMethods.SuspendLayout();
            this.SuspendLayout();
            // 
            // picTab
            // 
            resources.ApplyResources(this.picTab, "picTab");
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuFrmMethods_menuStart_Online);
            this.commandManager.Commands.Add(this.menuFrmMethods_menuRestart_Online);
            this.commandManager.Commands.Add(this.menuFrmMethods_menuSchedule_Job);
            this.commandManager.Commands.Add(this.menuFrmMethods_menuUnpack_File);
            this.commandManager.Commands.Add(this.menuFrmMethods_menuClean_Up);
            this.commandManager.Commands.Add(this.menuFrmMethods_menuJob);
            this.commandManager.ContextMenus.Add(this.menuFrmMethods);
            // 
            // menuFrmMethods_menuStart_Online
            // 
            resources.ApplyResources(this.menuFrmMethods_menuStart_Online, "menuFrmMethods_menuStart_Online");
            this.menuFrmMethods_menuStart_Online.Name = "menuFrmMethods_menuStart_Online";
            this.menuFrmMethods_menuStart_Online.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Start_Execute);
            this.menuFrmMethods_menuStart_Online.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Start_Inquire);
            // 
            // menuFrmMethods_menuRestart_Online
            // 
            resources.ApplyResources(this.menuFrmMethods_menuRestart_Online, "menuFrmMethods_menuRestart_Online");
            this.menuFrmMethods_menuRestart_Online.Name = "menuFrmMethods_menuRestart_Online";
            this.menuFrmMethods_menuRestart_Online.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Restart_Execute);
            this.menuFrmMethods_menuRestart_Online.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Restart_Inquire);
            // 
            // menuFrmMethods_menuSchedule_Job
            // 
            resources.ApplyResources(this.menuFrmMethods_menuSchedule_Job, "menuFrmMethods_menuSchedule_Job");
            this.menuFrmMethods_menuSchedule_Job.Name = "menuFrmMethods_menuSchedule_Job";
            this.menuFrmMethods_menuSchedule_Job.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Schedule_Execute);
            this.menuFrmMethods_menuSchedule_Job.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Schedule_Inquire);
            // 
            // menuFrmMethods_menuUnpack_File
            // 
            resources.ApplyResources(this.menuFrmMethods_menuUnpack_File, "menuFrmMethods_menuUnpack_File");
            this.menuFrmMethods_menuUnpack_File.Name = "menuFrmMethods_menuUnpack_File";
            this.menuFrmMethods_menuUnpack_File.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Unpack_Execute);
            this.menuFrmMethods_menuUnpack_File.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Unpack_Inquire);
            // 
            // menuFrmMethods_menuClean_Up
            // 
            resources.ApplyResources(this.menuFrmMethods_menuClean_Up, "menuFrmMethods_menuClean_Up");
            this.menuFrmMethods_menuClean_Up.Name = "menuFrmMethods_menuClean_Up";
            this.menuFrmMethods_menuClean_Up.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Clean_Execute);
            this.menuFrmMethods_menuClean_Up.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Clean_Inquire);
            // 
            // labelcmbIntfaceName
            // 
            resources.ApplyResources(this.labelcmbIntfaceName, "labelcmbIntfaceName");
            this.picTab.SetControlTabPages(this.labelcmbIntfaceName, "");
            this.labelcmbIntfaceName.Name = "labelcmbIntfaceName";
            // 
            // cmbIntfaceName
            // 
            this.cmbIntfaceName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.picTab.SetControlTabPages(this.cmbIntfaceName, "");
            resources.ApplyResources(this.cmbIntfaceName, "cmbIntfaceName");
            this.cmbIntfaceName.Name = "cmbIntfaceName";
            this.cmbIntfaceName.NamedProperties.Put("EnumerateMethod", "");
            this.cmbIntfaceName.NamedProperties.Put("FieldFlags", "163");
            this.cmbIntfaceName.NamedProperties.Put("Format", "9");
            this.cmbIntfaceName.NamedProperties.Put("LovReference", "");
            this.cmbIntfaceName.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbIntfaceName.NamedProperties.Put("SqlColumn", "INTFACE_NAME");
            this.cmbIntfaceName.NamedProperties.Put("ValidateMethod", "");
            this.cmbIntfaceName.NamedProperties.Put("XDataLength", "30");
            this.cmbIntfaceName.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbIntfaceName_WindowActions);
            // 
            // labeldfsDescription
            // 
            resources.ApplyResources(this.labeldfsDescription, "labeldfsDescription");
            this.picTab.SetControlTabPages(this.labeldfsDescription, "");
            this.labeldfsDescription.Name = "labeldfsDescription";
            // 
            // dfsDescription
            // 
            this.picTab.SetControlTabPages(this.dfsDescription, "");
            resources.ApplyResources(this.dfsDescription, "dfsDescription");
            this.dfsDescription.Name = "dfsDescription";
            this.dfsDescription.NamedProperties.Put("EnumerateMethod", "");
            this.dfsDescription.NamedProperties.Put("FieldFlags", "289");
            this.dfsDescription.NamedProperties.Put("LovReference", "");
            this.dfsDescription.NamedProperties.Put("ParentName", "cmbIntfaceName");
            this.dfsDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsDescription.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            this.dfsDescription.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsGroupId
            // 
            resources.ApplyResources(this.labeldfsGroupId, "labeldfsGroupId");
            this.picTab.SetControlTabPages(this.labeldfsGroupId, "");
            this.labeldfsGroupId.Name = "labeldfsGroupId";
            // 
            // dfsGroupId
            // 
            this.dfsGroupId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.picTab.SetControlTabPages(this.dfsGroupId, "");
            resources.ApplyResources(this.dfsGroupId, "dfsGroupId");
            this.dfsGroupId.Name = "dfsGroupId";
            this.dfsGroupId.NamedProperties.Put("EnumerateMethod", "");
            this.dfsGroupId.NamedProperties.Put("FieldFlags", "288");
            this.dfsGroupId.NamedProperties.Put("LovReference", "INTFACE_GROUP");
            this.dfsGroupId.NamedProperties.Put("ResizeableChildObject", "LLCL");
            this.dfsGroupId.NamedProperties.Put("SqlColumn", "GROUP_ID");
            this.dfsGroupId.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsIntfacePath
            // 
            resources.ApplyResources(this.labeldfsIntfacePath, "labeldfsIntfacePath");
            this.picTab.SetControlTabPages(this.labeldfsIntfacePath, "");
            this.labeldfsIntfacePath.Name = "labeldfsIntfacePath";
            // 
            // dfsIntfacePath
            // 
            this.picTab.SetControlTabPages(this.dfsIntfacePath, "");
            resources.ApplyResources(this.dfsIntfacePath, "dfsIntfacePath");
            this.dfsIntfacePath.Name = "dfsIntfacePath";
            this.dfsIntfacePath.NamedProperties.Put("EnumerateMethod", "");
            this.dfsIntfacePath.NamedProperties.Put("FieldFlags", "288");
            this.dfsIntfacePath.NamedProperties.Put("LovReference", "");
            this.dfsIntfacePath.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsIntfacePath.NamedProperties.Put("SqlColumn", "INTFACE_PATH");
            this.dfsIntfacePath.NamedProperties.Put("ValidateMethod", "");
            this.dfsIntfacePath.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsIntfacePath_WindowActions);
            // 
            // labeldfsIntfaceFile
            // 
            resources.ApplyResources(this.labeldfsIntfaceFile, "labeldfsIntfaceFile");
            this.picTab.SetControlTabPages(this.labeldfsIntfaceFile, "");
            this.labeldfsIntfaceFile.Name = "labeldfsIntfaceFile";
            // 
            // dfsIntfaceFile
            // 
            this.picTab.SetControlTabPages(this.dfsIntfaceFile, "");
            resources.ApplyResources(this.dfsIntfaceFile, "dfsIntfaceFile");
            this.dfsIntfaceFile.Name = "dfsIntfaceFile";
            this.dfsIntfaceFile.NamedProperties.Put("EnumerateMethod", "");
            this.dfsIntfaceFile.NamedProperties.Put("FieldFlags", "294");
            this.dfsIntfaceFile.NamedProperties.Put("LovReference", "INTFACE_SERVER_FILES_LOV");
            this.dfsIntfaceFile.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsIntfaceFile.NamedProperties.Put("SqlColumn", "INTFACE_FILE");
            this.dfsIntfaceFile.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsFileLocation
            // 
            resources.ApplyResources(this.labeldfsFileLocation, "labeldfsFileLocation");
            this.picTab.SetControlTabPages(this.labeldfsFileLocation, "");
            this.labeldfsFileLocation.Name = "labeldfsFileLocation";
            // 
            // dfsFileLocation
            // 
            this.picTab.SetControlTabPages(this.dfsFileLocation, "");
            resources.ApplyResources(this.dfsFileLocation, "dfsFileLocation");
            this.dfsFileLocation.Name = "dfsFileLocation";
            this.dfsFileLocation.NamedProperties.Put("EnumerateMethod", "");
            this.dfsFileLocation.NamedProperties.Put("FieldFlags", "288");
            this.dfsFileLocation.NamedProperties.Put("LovReference", "");
            this.dfsFileLocation.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsFileLocation.NamedProperties.Put("SqlColumn", "FILE_LOCATION");
            this.dfsFileLocation.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsStatus
            // 
            resources.ApplyResources(this.labeldfsStatus, "labeldfsStatus");
            this.picTab.SetControlTabPages(this.labeldfsStatus, "");
            this.labeldfsStatus.Name = "labeldfsStatus";
            // 
            // dfsStatus
            // 
            this.picTab.SetControlTabPages(this.dfsStatus, "");
            resources.ApplyResources(this.dfsStatus, "dfsStatus");
            this.dfsStatus.Name = "dfsStatus";
            this.dfsStatus.NamedProperties.Put("EnumerateMethod", "");
            this.dfsStatus.NamedProperties.Put("LovReference", "");
            this.dfsStatus.NamedProperties.Put("ParentName", "cmbIntfaceName");
            this.dfsStatus.NamedProperties.Put("ResizeableChildObject", "LLCL");
            this.dfsStatus.NamedProperties.Put("SqlColumn", "Intface_Job_Detail_API.Get_Min_Status(INTFACE_NAME)");
            this.dfsStatus.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfdLastExecuted
            // 
            resources.ApplyResources(this.labeldfdLastExecuted, "labeldfdLastExecuted");
            this.picTab.SetControlTabPages(this.labeldfdLastExecuted, "");
            this.labeldfdLastExecuted.Name = "labeldfdLastExecuted";
            // 
            // dfdLastExecuted
            // 
            this.picTab.SetControlTabPages(this.dfdLastExecuted, "");
            this.dfdLastExecuted.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.dfdLastExecuted.Format = "G";
            resources.ApplyResources(this.dfdLastExecuted, "dfdLastExecuted");
            this.dfdLastExecuted.Name = "dfdLastExecuted";
            this.dfdLastExecuted.NamedProperties.Put("EnumerateMethod", "");
            this.dfdLastExecuted.NamedProperties.Put("FieldFlags", "290");
            this.dfdLastExecuted.NamedProperties.Put("LovReference", "");
            this.dfdLastExecuted.NamedProperties.Put("ResizeableChildObject", "LLLL");
            this.dfdLastExecuted.NamedProperties.Put("SqlColumn", "LAST_EXECUTED");
            this.dfdLastExecuted.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsExecutedBy
            // 
            resources.ApplyResources(this.labeldfsExecutedBy, "labeldfsExecutedBy");
            this.picTab.SetControlTabPages(this.labeldfsExecutedBy, "");
            this.labeldfsExecutedBy.Name = "labeldfsExecutedBy";
            // 
            // dfsExecutedBy
            // 
            this.picTab.SetControlTabPages(this.dfsExecutedBy, "");
            resources.ApplyResources(this.dfsExecutedBy, "dfsExecutedBy");
            this.dfsExecutedBy.Name = "dfsExecutedBy";
            this.dfsExecutedBy.NamedProperties.Put("EnumerateMethod", "");
            this.dfsExecutedBy.NamedProperties.Put("FieldFlags", "290");
            this.dfsExecutedBy.NamedProperties.Put("LovReference", "");
            this.dfsExecutedBy.NamedProperties.Put("ResizeableChildObject", "LLLL");
            this.dfsExecutedBy.NamedProperties.Put("SqlColumn", "EXECUTED_BY");
            this.dfsExecutedBy.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsLastInfo
            // 
            resources.ApplyResources(this.labeldfsLastInfo, "labeldfsLastInfo");
            this.picTab.SetControlTabPages(this.labeldfsLastInfo, "");
            this.labeldfsLastInfo.Name = "labeldfsLastInfo";
            // 
            // dfsLastInfo
            // 
            this.picTab.SetControlTabPages(this.dfsLastInfo, "");
            resources.ApplyResources(this.dfsLastInfo, "dfsLastInfo");
            this.dfsLastInfo.Name = "dfsLastInfo";
            this.dfsLastInfo.NamedProperties.Put("EnumerateMethod", "");
            this.dfsLastInfo.NamedProperties.Put("FieldFlags", "310");
            this.dfsLastInfo.NamedProperties.Put("LovReference", "");
            this.dfsLastInfo.NamedProperties.Put("ResizeableChildObject", "LLCL");
            this.dfsLastInfo.NamedProperties.Put("SqlColumn", "LAST_INFO");
            this.dfsLastInfo.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsProcedureName
            // 
            resources.ApplyResources(this.labeldfsProcedureName, "labeldfsProcedureName");
            this.picTab.SetControlTabPages(this.labeldfsProcedureName, "");
            this.labeldfsProcedureName.Name = "labeldfsProcedureName";
            // 
            // dfsProcedureName
            // 
            this.dfsProcedureName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.picTab.SetControlTabPages(this.dfsProcedureName, "");
            resources.ApplyResources(this.dfsProcedureName, "dfsProcedureName");
            this.dfsProcedureName.Name = "dfsProcedureName";
            this.dfsProcedureName.NamedProperties.Put("EnumerateMethod", "");
            this.dfsProcedureName.NamedProperties.Put("FieldFlags", "262");
            this.dfsProcedureName.NamedProperties.Put("LovReference", "INTFACE_PROCEDURES");
            this.dfsProcedureName.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsProcedureName.NamedProperties.Put("SqlColumn", "PROCEDURE_NAME");
            this.dfsProcedureName.NamedProperties.Put("ValidateMethod", "");
            this.dfsProcedureName.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsProcedureName_WindowActions);
            // 
            // labeldfsDirection
            // 
            resources.ApplyResources(this.labeldfsDirection, "labeldfsDirection");
            this.picTab.SetControlTabPages(this.labeldfsDirection, "");
            this.labeldfsDirection.Name = "labeldfsDirection";
            // 
            // dfsDirection
            // 
            this.picTab.SetControlTabPages(this.dfsDirection, "");
            resources.ApplyResources(this.dfsDirection, "dfsDirection");
            this.dfsDirection.Name = "dfsDirection";
            this.dfsDirection.NamedProperties.Put("EnumerateMethod", "");
            this.dfsDirection.NamedProperties.Put("LovReference", "");
            this.dfsDirection.NamedProperties.Put("ParentName", "dfsProcedureName");
            this.dfsDirection.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsDirection.NamedProperties.Put("SqlColumn", "INTFACE_PROCEDURES_API.Get_Direction(PROCEDURE_NAME)");
            this.dfsDirection.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsFileLocationDb
            // 
            resources.ApplyResources(this.labeldfsFileLocationDb, "labeldfsFileLocationDb");
            this.picTab.SetControlTabPages(this.labeldfsFileLocationDb, "");
            this.labeldfsFileLocationDb.Name = "labeldfsFileLocationDb";
            // 
            // dfsFileLocationDb
            // 
            this.picTab.SetControlTabPages(this.dfsFileLocationDb, "");
            resources.ApplyResources(this.dfsFileLocationDb, "dfsFileLocationDb");
            this.dfsFileLocationDb.Name = "dfsFileLocationDb";
            this.dfsFileLocationDb.NamedProperties.Put("EnumerateMethod", "");
            this.dfsFileLocationDb.NamedProperties.Put("FieldFlags", "288");
            this.dfsFileLocationDb.NamedProperties.Put("LovReference", "");
            this.dfsFileLocationDb.NamedProperties.Put("SqlColumn", "FILE_LOCATION_DB");
            // 
            // menuFrmMethods
            // 
            this.picTab.SetControlTabPages(this.menuFrmMethods, "");
            this.menuFrmMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_Start,
            this.menuItem_Restart,
            this.menuItem_Schedule,
            this.menuItem_Unpack,
            this.menuItem_Clean,
            this.menuItem_MigJob});
            this.menuFrmMethods.Name = "menuFrmMethods";
            resources.ApplyResources(this.menuFrmMethods, "menuFrmMethods");
            // 
            // menuItem_Start
            // 
            this.menuItem_Start.Command = this.menuFrmMethods_menuStart_Online;
            this.menuItem_Start.Name = "menuItem_Start";
            resources.ApplyResources(this.menuItem_Start, "menuItem_Start");
            this.menuItem_Start.Text = "Start Online";
            // 
            // menuItem_Restart
            // 
            this.menuItem_Restart.Command = this.menuFrmMethods_menuRestart_Online;
            this.menuItem_Restart.Name = "menuItem_Restart";
            resources.ApplyResources(this.menuItem_Restart, "menuItem_Restart");
            this.menuItem_Restart.Text = "Restart Online";
            // 
            // menuItem_Schedule
            // 
            this.menuItem_Schedule.Command = this.menuFrmMethods_menuSchedule_Job;
            this.menuItem_Schedule.Name = "menuItem_Schedule";
            resources.ApplyResources(this.menuItem_Schedule, "menuItem_Schedule");
            this.menuItem_Schedule.Text = "Schedule Job";
            // 
            // menuItem_Unpack
            // 
            this.menuItem_Unpack.Command = this.menuFrmMethods_menuUnpack_File;
            this.menuItem_Unpack.Name = "menuItem_Unpack";
            resources.ApplyResources(this.menuItem_Unpack, "menuItem_Unpack");
            this.menuItem_Unpack.Text = "Unpack File";
            // 
            // menuItem_Clean
            // 
            this.menuItem_Clean.Command = this.menuFrmMethods_menuClean_Up;
            this.menuItem_Clean.Name = "menuItem_Clean";
            resources.ApplyResources(this.menuItem_Clean, "menuItem_Clean");
            this.menuItem_Clean.Text = "Clean Up";
            // 
            // menuFrmMethods_menuJob
            // 
            resources.ApplyResources(this.menuFrmMethods_menuJob, "menuFrmMethods_menuJob");
            this.menuFrmMethods_menuJob.Name = "menuFrmMethods_menuJob";
            this.menuFrmMethods_menuJob.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuFrmMethods_menuJob_Execute);
            this.menuFrmMethods_menuJob.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuFrmMethods_menuJob_Inquire);
            // 
            // menuItem_MigJob
            // 
            this.menuItem_MigJob.Command = this.menuFrmMethods_menuJob;
            this.menuItem_MigJob.Name = "menuItem_MigJob";
            resources.ApplyResources(this.menuItem_MigJob, "menuItem_MigJob");
            this.menuItem_MigJob.Text = "Migration Job...";
            // 
            // frmIntfaceStart
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.dfsFileLocationDb);
            this.Controls.Add(this.dfsDirection);
            this.Controls.Add(this.dfsProcedureName);
            this.Controls.Add(this.dfsLastInfo);
            this.Controls.Add(this.dfsExecutedBy);
            this.Controls.Add(this.dfdLastExecuted);
            this.Controls.Add(this.dfsStatus);
            this.Controls.Add(this.dfsFileLocation);
            this.Controls.Add(this.dfsIntfaceFile);
            this.Controls.Add(this.dfsIntfacePath);
            this.Controls.Add(this.dfsGroupId);
            this.Controls.Add(this.dfsDescription);
            this.Controls.Add(this.cmbIntfaceName);
            this.Controls.Add(this.labeldfsFileLocationDb);
            this.Controls.Add(this.labeldfsDirection);
            this.Controls.Add(this.labeldfsProcedureName);
            this.Controls.Add(this.labeldfsLastInfo);
            this.Controls.Add(this.labeldfsExecutedBy);
            this.Controls.Add(this.labeldfdLastExecuted);
            this.Controls.Add(this.labeldfsStatus);
            this.Controls.Add(this.labeldfsFileLocation);
            this.Controls.Add(this.labeldfsIntfaceFile);
            this.Controls.Add(this.labeldfsIntfacePath);
            this.Controls.Add(this.labeldfsGroupId);
            this.Controls.Add(this.labeldfsDescription);
            this.Controls.Add(this.labelcmbIntfaceName);
            this.Name = "frmIntfaceStart";
            this.NamedProperties.Put("DefaultOrderBy", "INTFACE_NAME");
            this.NamedProperties.Put("DefaultWhere", "PROCEDURE_NAME != \'EXCEL_MIGRATION\' AND\nINTFACE_NAME IN (SELECT INTFACE_NAME\nFROM" +
        " &AO.INTFACE_PR_USER\nWHERE IDENTITY = &AO.Fnd_Session_API.Get_Fnd_User)\n  AND nv" +
        "l(&AO.Intface_Group_API.Get_Hide_Flag(GROUP_ID),\'FALSE\') = \'FALSE\'");
            this.NamedProperties.Put("LogicalUnit", "IntfaceHeader");
            this.NamedProperties.Put("PackageName", "Intface_Header_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "448");
            this.NamedProperties.Put("ViewName", "INTFACE_HEADER");
            this.NamedProperties.Put("Warnings", "TRUE");
            this.Controls.SetChildIndex(this.picTab, 0);
            this.Controls.SetChildIndex(this.labelcmbIntfaceName, 0);
            this.Controls.SetChildIndex(this.labeldfsDescription, 0);
            this.Controls.SetChildIndex(this.labeldfsGroupId, 0);
            this.Controls.SetChildIndex(this.labeldfsIntfacePath, 0);
            this.Controls.SetChildIndex(this.labeldfsIntfaceFile, 0);
            this.Controls.SetChildIndex(this.labeldfsFileLocation, 0);
            this.Controls.SetChildIndex(this.labeldfsStatus, 0);
            this.Controls.SetChildIndex(this.labeldfdLastExecuted, 0);
            this.Controls.SetChildIndex(this.labeldfsExecutedBy, 0);
            this.Controls.SetChildIndex(this.labeldfsLastInfo, 0);
            this.Controls.SetChildIndex(this.labeldfsProcedureName, 0);
            this.Controls.SetChildIndex(this.labeldfsDirection, 0);
            this.Controls.SetChildIndex(this.labeldfsFileLocationDb, 0);
            this.Controls.SetChildIndex(this.cmbIntfaceName, 0);
            this.Controls.SetChildIndex(this.dfsDescription, 0);
            this.Controls.SetChildIndex(this.dfsGroupId, 0);
            this.Controls.SetChildIndex(this.dfsIntfacePath, 0);
            this.Controls.SetChildIndex(this.dfsIntfaceFile, 0);
            this.Controls.SetChildIndex(this.dfsFileLocation, 0);
            this.Controls.SetChildIndex(this.dfsStatus, 0);
            this.Controls.SetChildIndex(this.dfdLastExecuted, 0);
            this.Controls.SetChildIndex(this.dfsExecutedBy, 0);
            this.Controls.SetChildIndex(this.dfsLastInfo, 0);
            this.Controls.SetChildIndex(this.dfsProcedureName, 0);
            this.Controls.SetChildIndex(this.dfsDirection, 0);
            this.Controls.SetChildIndex(this.dfsFileLocationDb, 0);
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

        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menuStart_Online;
        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menuRestart_Online;
        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menuSchedule_Job;
        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menuUnpack_File;
        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menuClean_Up;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuFrmMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Start;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Restart;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Schedule;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Unpack;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Clean;
        protected Fnd.Windows.Forms.FndCommand menuFrmMethods_menuJob;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_MigJob;
	}
}
