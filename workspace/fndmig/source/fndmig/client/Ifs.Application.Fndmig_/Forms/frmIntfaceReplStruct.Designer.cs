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

using Ifs.Fnd.ApplicationForms;
using PPJ.Runtime.Windows;

namespace Ifs.Application.Fndmig_
{
	
	public partial class frmIntfaceReplStruct
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		protected SalBackgroundText labelecmbIntfaceName;
		public cRecListDataField ecmbIntfaceName;
		protected SalBackgroundText labeldfsDescription;
		public cDataField dfsDescription;
		protected SalBackgroundText labelcmbReplicationMode;
		public cComboBox cmbReplicationMode;
		protected SalBackgroundText labeldfsProcedureName;
		public cDataField dfsProcedureName;
		protected SalBackgroundText labeldfsGroupId;
		public cDataField dfsGroupId;
		protected SalBackgroundText labeldfsMessageName;
		public cDataField dfsMessageName;
		protected SalBackgroundText labelcmbMessageType;
		public cComboBox cmbMessageType;
		protected SalBackgroundText labeldfsMessageSender;
		public cDataField dfsMessageSender;
		protected SalBackgroundText labeldfsMessageReceiver;
		public cDataField dfsMessageReceiver;
		protected SalBackgroundText labeldfsDateFormat;
		public cDataField dfsDateFormat;
		protected SalBackgroundText labeldfsNoteText;
		public cDataField dfsNoteText;
		protected SalBackgroundText labeldfsDirection;
        public cDataField dfsDirection;
		protected SalBackgroundText labelcmbFileLocation;
		public cComboBox cmbFileLocation;
		protected SalBackgroundText labeldflsHiddenSqlStatement;
		public cDataField dflsHiddenSqlStatement;
		protected SalBackgroundText labeldfnServerProcess;
		public cDataField dfnServerProcess;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIntfaceReplStruct));
            this.menuTblMethodsObjects = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_ShowSource = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.cmdShowSourceText = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.cmdDefineColumns = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuFrmMethods_menu_Copy_Migration_Job = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuFrmMethods_menuStart__Insert_Package = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuFrmMethods_menuStart__Update_Package = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuFrmMethods_menuCompile__Packages = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuFrmMethods_menuCompile__Triggers = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuFrmMethods_menu_Enable_Triggers = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuFrmMethods_menu_Disable_Triggers = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuFrmMethods_menuShow__Server_Processes = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuFrmMethods_menuShow__Log = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuFrmMethods_menuCreate__XSD_File = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.labelecmbIntfaceName = new PPJ.Runtime.Windows.SalBackgroundText();
            this.ecmbIntfaceName = new Ifs.Fnd.ApplicationForms.cRecListDataField();
            this.labeldfsDescription = new PPJ.Runtime.Windows.SalBackgroundText();
            this.dfsDescription = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelcmbReplicationMode = new PPJ.Runtime.Windows.SalBackgroundText();
            this.cmbReplicationMode = new Ifs.Fnd.ApplicationForms.cComboBox();
            this.labeldfsProcedureName = new PPJ.Runtime.Windows.SalBackgroundText();
            this.dfsProcedureName = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsGroupId = new PPJ.Runtime.Windows.SalBackgroundText();
            this.dfsGroupId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsMessageName = new PPJ.Runtime.Windows.SalBackgroundText();
            this.dfsMessageName = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelcmbMessageType = new PPJ.Runtime.Windows.SalBackgroundText();
            this.cmbMessageType = new Ifs.Fnd.ApplicationForms.cComboBox();
            this.labeldfsMessageSender = new PPJ.Runtime.Windows.SalBackgroundText();
            this.dfsMessageSender = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsMessageReceiver = new PPJ.Runtime.Windows.SalBackgroundText();
            this.dfsMessageReceiver = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsDateFormat = new PPJ.Runtime.Windows.SalBackgroundText();
            this.dfsDateFormat = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsNoteText = new PPJ.Runtime.Windows.SalBackgroundText();
            this.dfsNoteText = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsDirection = new PPJ.Runtime.Windows.SalBackgroundText();
            this.dfsDirection = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelcmbFileLocation = new PPJ.Runtime.Windows.SalBackgroundText();
            this.cmbFileLocation = new Ifs.Fnd.ApplicationForms.cComboBox();
            this.labeldflsHiddenSqlStatement = new PPJ.Runtime.Windows.SalBackgroundText();
            this.dflsHiddenSqlStatement = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfnServerProcess = new PPJ.Runtime.Windows.SalBackgroundText();
            this.dfnServerProcess = new Ifs.Fnd.ApplicationForms.cDataField();
            this.menuFrmMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem__Copy = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem_Start = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem_Start_1 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem_Compile = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuSeparator1 = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.menuItem_Compile_1 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem__Enable = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem__Disable = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuSeparator2 = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.menuItem_Show = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem_Show_1 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem_Create = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuTblMethodsStructure = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_Define = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.tblStructure = new Ifs.Fnd.ApplicationForms.cChildTable();
            this.tblStructure_colsIntfaceName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblStructure_colnStructureSeq = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblStructure_colsViewName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblStructure_colnParentSeq = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblStructure_colsTriggerTable = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblStructure_colsOnInsert = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.tblStructure_colsOnUpdate = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.tblStructure_colsRecordName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblStructure_colsElementName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblStructure_colsElementType = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.tblStructure_colSelectWhere = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblStructure_colTriggerWhen = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblStructure_colsStartPoint = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.tblStructure_colNoteText = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblStructure_colnPos = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblObjects = new Ifs.Fnd.ApplicationForms.cChildTable();
            this.tblObjects_colsObjectName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblObjects_colsObjectType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblObjects_colsStatus = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblObjects_colsTableName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblObjects_colErrorText = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblObjects_coldCreated = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblObjects_colsIntfaceName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblObjects_coldLastDdlTime = new Ifs.Fnd.ApplicationForms.cColumn();
            this.menuTblMethodsObjects.SuspendLayout();
            this.menuFrmMethods.SuspendLayout();
            this.menuTblMethodsStructure.SuspendLayout();
            this.tblStructure.SuspendLayout();
            this.tblObjects.SuspendLayout();
            this.SuspendLayout();
            // 
            // picTab
            // 
            resources.ApplyResources(this.picTab, "picTab");
            // 
            // _cTabManager
            // 
            resources.ApplyResources(this._cTabManager, "_cTabManager");
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuFrmMethods_menu_Copy_Migration_Job);
            this.commandManager.Commands.Add(this.menuFrmMethods_menuStart__Insert_Package);
            this.commandManager.Commands.Add(this.menuFrmMethods_menuStart__Update_Package);
            this.commandManager.Commands.Add(this.menuFrmMethods_menuCompile__Packages);
            this.commandManager.Commands.Add(this.menuFrmMethods_menuCompile__Triggers);
            this.commandManager.Commands.Add(this.menuFrmMethods_menu_Enable_Triggers);
            this.commandManager.Commands.Add(this.menuFrmMethods_menu_Disable_Triggers);
            this.commandManager.Commands.Add(this.menuFrmMethods_menuShow__Server_Processes);
            this.commandManager.Commands.Add(this.menuFrmMethods_menuShow__Log);
            this.commandManager.Commands.Add(this.menuFrmMethods_menuCreate__XSD_File);
            this.commandManager.Commands.Add(this.cmdShowSourceText);
            this.commandManager.Commands.Add(this.cmdDefineColumns);
            this.commandManager.ContextMenus.Add(this.menuFrmMethods);
            this.commandManager.ContextMenus.Add(this.menuTblMethodsStructure);
            this.commandManager.ContextMenus.Add(this.menuTblMethodsObjects);
            this.commandManager.ImageList = null;
            // 
            // menuTblMethodsObjects
            // 
            this.picTab.SetControlTabPages(this.menuTblMethodsObjects, "");
            this.menuTblMethodsObjects.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_ShowSource});
            this.menuTblMethodsObjects.Name = "menuTblMethodsObjects";
            resources.ApplyResources(this.menuTblMethodsObjects, "menuTblMethodsObjects");
            // 
            // menuItem_ShowSource
            // 
            this.menuItem_ShowSource.Command = this.cmdShowSourceText;
            this.menuItem_ShowSource.Name = "menuItem_ShowSource";
            resources.ApplyResources(this.menuItem_ShowSource, "menuItem_ShowSource");
            this.menuItem_ShowSource.Text = "Show Source Text...";
            // 
            // cmdShowSourceText
            // 
            resources.ApplyResources(this.cmdShowSourceText, "cmdShowSourceText");
            this.cmdShowSourceText.Name = "cmdShowSourceText";
            this.cmdShowSourceText.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.cmdShowSourceText_Execute);
            this.cmdShowSourceText.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.cmdShowSourceText_Inquire);
            // 
            // cmdDefineColumns
            // 
            resources.ApplyResources(this.cmdDefineColumns, "cmdDefineColumns");
            this.cmdDefineColumns.Name = "cmdDefineColumns";
            this.cmdDefineColumns.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.cmdDefineColumns_Execute);
            this.cmdDefineColumns.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.cmdDefineColumns_Inquire);
            // 
            // menuFrmMethods_menu_Copy_Migration_Job
            // 
            resources.ApplyResources(this.menuFrmMethods_menu_Copy_Migration_Job, "menuFrmMethods_menu_Copy_Migration_Job");
            this.menuFrmMethods_menu_Copy_Migration_Job.Name = "menuFrmMethods_menu_Copy_Migration_Job";
            this.menuFrmMethods_menu_Copy_Migration_Job.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Copy_Execute);
            this.menuFrmMethods_menu_Copy_Migration_Job.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Copy_Inquire);
            // 
            // menuFrmMethods_menuStart__Insert_Package
            // 
            resources.ApplyResources(this.menuFrmMethods_menuStart__Insert_Package, "menuFrmMethods_menuStart__Insert_Package");
            this.menuFrmMethods_menuStart__Insert_Package.Name = "menuFrmMethods_menuStart__Insert_Package";
            this.menuFrmMethods_menuStart__Insert_Package.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Start_Execute);
            this.menuFrmMethods_menuStart__Insert_Package.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Start_Inquire);
            // 
            // menuFrmMethods_menuStart__Update_Package
            // 
            resources.ApplyResources(this.menuFrmMethods_menuStart__Update_Package, "menuFrmMethods_menuStart__Update_Package");
            this.menuFrmMethods_menuStart__Update_Package.Name = "menuFrmMethods_menuStart__Update_Package";
            this.menuFrmMethods_menuStart__Update_Package.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Start_1_Execute);
            this.menuFrmMethods_menuStart__Update_Package.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Start_1_Inquire);
            // 
            // menuFrmMethods_menuCompile__Packages
            // 
            resources.ApplyResources(this.menuFrmMethods_menuCompile__Packages, "menuFrmMethods_menuCompile__Packages");
            this.menuFrmMethods_menuCompile__Packages.Name = "menuFrmMethods_menuCompile__Packages";
            this.menuFrmMethods_menuCompile__Packages.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Compile_Execute);
            this.menuFrmMethods_menuCompile__Packages.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Compile_Inquire);
            // 
            // menuFrmMethods_menuCompile__Triggers
            // 
            resources.ApplyResources(this.menuFrmMethods_menuCompile__Triggers, "menuFrmMethods_menuCompile__Triggers");
            this.menuFrmMethods_menuCompile__Triggers.Name = "menuFrmMethods_menuCompile__Triggers";
            this.menuFrmMethods_menuCompile__Triggers.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Compile_1_Execute);
            this.menuFrmMethods_menuCompile__Triggers.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Compile_1_Inquire);
            // 
            // menuFrmMethods_menu_Enable_Triggers
            // 
            resources.ApplyResources(this.menuFrmMethods_menu_Enable_Triggers, "menuFrmMethods_menu_Enable_Triggers");
            this.menuFrmMethods_menu_Enable_Triggers.Name = "menuFrmMethods_menu_Enable_Triggers";
            this.menuFrmMethods_menu_Enable_Triggers.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Enable_Execute);
            this.menuFrmMethods_menu_Enable_Triggers.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Enable_Inquire);
            // 
            // menuFrmMethods_menu_Disable_Triggers
            // 
            resources.ApplyResources(this.menuFrmMethods_menu_Disable_Triggers, "menuFrmMethods_menu_Disable_Triggers");
            this.menuFrmMethods_menu_Disable_Triggers.Name = "menuFrmMethods_menu_Disable_Triggers";
            this.menuFrmMethods_menu_Disable_Triggers.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Disable_Execute);
            this.menuFrmMethods_menu_Disable_Triggers.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Disable_Inquire);
            // 
            // menuFrmMethods_menuShow__Server_Processes
            // 
            resources.ApplyResources(this.menuFrmMethods_menuShow__Server_Processes, "menuFrmMethods_menuShow__Server_Processes");
            this.menuFrmMethods_menuShow__Server_Processes.Name = "menuFrmMethods_menuShow__Server_Processes";
            this.menuFrmMethods_menuShow__Server_Processes.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Show_Execute);
            this.menuFrmMethods_menuShow__Server_Processes.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Show_Inquire);
            // 
            // menuFrmMethods_menuShow__Log
            // 
            resources.ApplyResources(this.menuFrmMethods_menuShow__Log, "menuFrmMethods_menuShow__Log");
            this.menuFrmMethods_menuShow__Log.Name = "menuFrmMethods_menuShow__Log";
            this.menuFrmMethods_menuShow__Log.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Show_1_Execute);
            this.menuFrmMethods_menuShow__Log.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Show_1_Inquire);
            // 
            // menuFrmMethods_menuCreate__XSD_File
            // 
            resources.ApplyResources(this.menuFrmMethods_menuCreate__XSD_File, "menuFrmMethods_menuCreate__XSD_File");
            this.menuFrmMethods_menuCreate__XSD_File.Name = "menuFrmMethods_menuCreate__XSD_File";
            this.menuFrmMethods_menuCreate__XSD_File.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Create_Execute);
            this.menuFrmMethods_menuCreate__XSD_File.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Create_Inquire);
            // 
            // labelecmbIntfaceName
            // 
            resources.ApplyResources(this.labelecmbIntfaceName, "labelecmbIntfaceName");
            this.picTab.SetControlTabPages(this.labelecmbIntfaceName, "");
            this.labelecmbIntfaceName.Name = "labelecmbIntfaceName";
            // 
            // ecmbIntfaceName
            // 
            this.ecmbIntfaceName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.picTab.SetControlTabPages(this.ecmbIntfaceName, "");
            resources.ApplyResources(this.ecmbIntfaceName, "ecmbIntfaceName");
            this.ecmbIntfaceName.Name = "ecmbIntfaceName";
            this.ecmbIntfaceName.NamedProperties.Put("EnumerateMethod", "");
            this.ecmbIntfaceName.NamedProperties.Put("FieldFlags", "163");
            this.ecmbIntfaceName.NamedProperties.Put("Format", "9");
            this.ecmbIntfaceName.NamedProperties.Put("LovReference", "");
            this.ecmbIntfaceName.NamedProperties.Put("ResizeableChildObject", "");
            this.ecmbIntfaceName.NamedProperties.Put("SqlColumn", "INTFACE_NAME");
            this.ecmbIntfaceName.NamedProperties.Put("ValidateMethod", "");
            this.ecmbIntfaceName.NamedProperties.Put("XDataLength", "30");
            this.ecmbIntfaceName.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.ecmbIntfaceName_WindowActions);
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
            this.dfsDescription.NamedProperties.Put("FieldFlags", "295");
            this.dfsDescription.NamedProperties.Put("LovReference", "");
            this.dfsDescription.NamedProperties.Put("ParentName", "ecmbIntfaceName");
            this.dfsDescription.NamedProperties.Put("ResizeableChildObject", "LLLL");
            this.dfsDescription.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            this.dfsDescription.NamedProperties.Put("ValidateMethod", "");
            // 
            // labelcmbReplicationMode
            // 
            resources.ApplyResources(this.labelcmbReplicationMode, "labelcmbReplicationMode");
            this.picTab.SetControlTabPages(this.labelcmbReplicationMode, "");
            this.labelcmbReplicationMode.Name = "labelcmbReplicationMode";
            // 
            // cmbReplicationMode
            // 
            this.picTab.SetControlTabPages(this.cmbReplicationMode, "");
            resources.ApplyResources(this.cmbReplicationMode, "cmbReplicationMode");
            this.cmbReplicationMode.Name = "cmbReplicationMode";
            this.cmbReplicationMode.NamedProperties.Put("EnumerateMethod", "INTFACE_MODE_API.Enumerate");
            this.cmbReplicationMode.NamedProperties.Put("FieldFlags", "295");
            this.cmbReplicationMode.NamedProperties.Put("LovReference", "");
            this.cmbReplicationMode.NamedProperties.Put("SqlColumn", "REPLICATION_MODE");
            this.cmbReplicationMode.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbReplicationMode_WindowActions);
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
            this.dfsProcedureName.NamedProperties.Put("FieldFlags", "295");
            this.dfsProcedureName.NamedProperties.Put("LovReference", "INTFACE_PROC_LOV_INCL_REPL");
            this.dfsProcedureName.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsProcedureName.NamedProperties.Put("SqlColumn", "PROCEDURE_NAME");
            this.dfsProcedureName.NamedProperties.Put("ValidateMethod", "");
            this.dfsProcedureName.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsProcedureName_WindowActions);
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
            this.dfsGroupId.NamedProperties.Put("FieldFlags", "294");
            this.dfsGroupId.NamedProperties.Put("LovReference", "INTFACE_GROUP");
            this.dfsGroupId.NamedProperties.Put("ParentName", "ecmbIntfaceName");
            this.dfsGroupId.NamedProperties.Put("ResizeableChildObject", "LLLL");
            this.dfsGroupId.NamedProperties.Put("SqlColumn", "GROUP_ID");
            this.dfsGroupId.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsMessageName
            // 
            resources.ApplyResources(this.labeldfsMessageName, "labeldfsMessageName");
            this.picTab.SetControlTabPages(this.labeldfsMessageName, "");
            this.labeldfsMessageName.Name = "labeldfsMessageName";
            // 
            // dfsMessageName
            // 
            this.picTab.SetControlTabPages(this.dfsMessageName, "");
            resources.ApplyResources(this.dfsMessageName, "dfsMessageName");
            this.dfsMessageName.Name = "dfsMessageName";
            this.dfsMessageName.NamedProperties.Put("EnumerateMethod", "");
            this.dfsMessageName.NamedProperties.Put("FieldFlags", "294");
            this.dfsMessageName.NamedProperties.Put("LovReference", "");
            this.dfsMessageName.NamedProperties.Put("SqlColumn", "MESSAGE_NAME");
            // 
            // labelcmbMessageType
            // 
            resources.ApplyResources(this.labelcmbMessageType, "labelcmbMessageType");
            this.picTab.SetControlTabPages(this.labelcmbMessageType, "");
            this.labelcmbMessageType.Name = "labelcmbMessageType";
            // 
            // cmbMessageType
            // 
            this.picTab.SetControlTabPages(this.cmbMessageType, "");
            resources.ApplyResources(this.cmbMessageType, "cmbMessageType");
            this.cmbMessageType.Name = "cmbMessageType";
            this.cmbMessageType.NamedProperties.Put("EnumerateMethod", "INTFACE_REPL_MESS_TYPE_API.Enumerate");
            this.cmbMessageType.NamedProperties.Put("FieldFlags", "294");
            this.cmbMessageType.NamedProperties.Put("LovReference", "");
            this.cmbMessageType.NamedProperties.Put("SqlColumn", "MESSAGE_TYPE");
            // 
            // labeldfsMessageSender
            // 
            resources.ApplyResources(this.labeldfsMessageSender, "labeldfsMessageSender");
            this.picTab.SetControlTabPages(this.labeldfsMessageSender, "");
            this.labeldfsMessageSender.Name = "labeldfsMessageSender";
            // 
            // dfsMessageSender
            // 
            this.picTab.SetControlTabPages(this.dfsMessageSender, "");
            resources.ApplyResources(this.dfsMessageSender, "dfsMessageSender");
            this.dfsMessageSender.Name = "dfsMessageSender";
            this.dfsMessageSender.NamedProperties.Put("EnumerateMethod", "");
            this.dfsMessageSender.NamedProperties.Put("FieldFlags", "294");
            this.dfsMessageSender.NamedProperties.Put("LovReference", "");
            this.dfsMessageSender.NamedProperties.Put("SqlColumn", "MESSAGE_SENDER");
            // 
            // labeldfsMessageReceiver
            // 
            resources.ApplyResources(this.labeldfsMessageReceiver, "labeldfsMessageReceiver");
            this.picTab.SetControlTabPages(this.labeldfsMessageReceiver, "");
            this.labeldfsMessageReceiver.Name = "labeldfsMessageReceiver";
            // 
            // dfsMessageReceiver
            // 
            this.picTab.SetControlTabPages(this.dfsMessageReceiver, "");
            resources.ApplyResources(this.dfsMessageReceiver, "dfsMessageReceiver");
            this.dfsMessageReceiver.Name = "dfsMessageReceiver";
            this.dfsMessageReceiver.NamedProperties.Put("EnumerateMethod", "");
            this.dfsMessageReceiver.NamedProperties.Put("FieldFlags", "294");
            this.dfsMessageReceiver.NamedProperties.Put("LovReference", "");
            this.dfsMessageReceiver.NamedProperties.Put("SqlColumn", "MESSAGE_RECEIVER");
            // 
            // labeldfsDateFormat
            // 
            resources.ApplyResources(this.labeldfsDateFormat, "labeldfsDateFormat");
            this.picTab.SetControlTabPages(this.labeldfsDateFormat, "");
            this.labeldfsDateFormat.Name = "labeldfsDateFormat";
            // 
            // dfsDateFormat
            // 
            this.picTab.SetControlTabPages(this.dfsDateFormat, "");
            resources.ApplyResources(this.dfsDateFormat, "dfsDateFormat");
            this.dfsDateFormat.Name = "dfsDateFormat";
            this.dfsDateFormat.NamedProperties.Put("EnumerateMethod", "");
            this.dfsDateFormat.NamedProperties.Put("FieldFlags", "294");
            this.dfsDateFormat.NamedProperties.Put("LovReference", "");
            this.dfsDateFormat.NamedProperties.Put("SqlColumn", "DATE_FORMAT");
            // 
            // labeldfsNoteText
            // 
            resources.ApplyResources(this.labeldfsNoteText, "labeldfsNoteText");
            this.picTab.SetControlTabPages(this.labeldfsNoteText, "");
            this.labeldfsNoteText.Name = "labeldfsNoteText";
            // 
            // dfsNoteText
            // 
            this.picTab.SetControlTabPages(this.dfsNoteText, "");
            resources.ApplyResources(this.dfsNoteText, "dfsNoteText");
            this.dfsNoteText.Name = "dfsNoteText";
            this.dfsNoteText.NamedProperties.Put("EnumerateMethod", "");
            this.dfsNoteText.NamedProperties.Put("FieldFlags", "310");
            this.dfsNoteText.NamedProperties.Put("LovReference", "");
            this.dfsNoteText.NamedProperties.Put("ResizeableChildObject", "LLLL");
            this.dfsNoteText.NamedProperties.Put("SqlColumn", "NOTE_TEXT");
            this.dfsNoteText.NamedProperties.Put("ValidateMethod", "");
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
            this.dfsDirection.NamedProperties.Put("ResizeableChildObject", "LLLL");
            this.dfsDirection.NamedProperties.Put("SqlColumn", "&AO.Intface_Procedures_API.Get_Direction(PROCEDURE_NAME)");
            this.dfsDirection.NamedProperties.Put("ValidateMethod", "");
            // 
            // labelcmbFileLocation
            // 
            resources.ApplyResources(this.labelcmbFileLocation, "labelcmbFileLocation");
            this.picTab.SetControlTabPages(this.labelcmbFileLocation, "");
            this.labelcmbFileLocation.Name = "labelcmbFileLocation";
            // 
            // cmbFileLocation
            // 
            this.picTab.SetControlTabPages(this.cmbFileLocation, "");
            resources.ApplyResources(this.cmbFileLocation, "cmbFileLocation");
            this.cmbFileLocation.Name = "cmbFileLocation";
            this.cmbFileLocation.NamedProperties.Put("EnumerateMethod", "INTFACE_FILE_LOCATION_API.Enumerate");
            this.cmbFileLocation.NamedProperties.Put("FieldFlags", "295");
            this.cmbFileLocation.NamedProperties.Put("LovReference", "");
            this.cmbFileLocation.NamedProperties.Put("SqlColumn", "FILE_LOCATION");
            // 
            // labeldflsHiddenSqlStatement
            // 
            resources.ApplyResources(this.labeldflsHiddenSqlStatement, "labeldflsHiddenSqlStatement");
            this.labeldflsHiddenSqlStatement.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeldflsHiddenSqlStatement, "Struct");
            this.labeldflsHiddenSqlStatement.Name = "labeldflsHiddenSqlStatement";
            // 
            // dflsHiddenSqlStatement
            // 
            this.picTab.SetControlTabPages(this.dflsHiddenSqlStatement, "");
            resources.ApplyResources(this.dflsHiddenSqlStatement, "dflsHiddenSqlStatement");
            this.dflsHiddenSqlStatement.Name = "dflsHiddenSqlStatement";
            this.dflsHiddenSqlStatement.NamedProperties.Put("EnumerateMethod", "");
            this.dflsHiddenSqlStatement.NamedProperties.Put("FieldFlags", "276");
            this.dflsHiddenSqlStatement.NamedProperties.Put("LovReference", "");
            this.dflsHiddenSqlStatement.NamedProperties.Put("ResizeableChildObject", "");
            this.dflsHiddenSqlStatement.NamedProperties.Put("SqlColumn", "");
            this.dflsHiddenSqlStatement.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfnServerProcess
            // 
            resources.ApplyResources(this.labeldfnServerProcess, "labeldfnServerProcess");
            this.picTab.SetControlTabPages(this.labeldfnServerProcess, "");
            this.labeldfnServerProcess.Name = "labeldfnServerProcess";
            // 
            // dfnServerProcess
            // 
            this.picTab.SetControlTabPages(this.dfnServerProcess, "");
            resources.ApplyResources(this.dfnServerProcess, "dfnServerProcess");
            this.dfnServerProcess.Name = "dfnServerProcess";
            this.dfnServerProcess.NamedProperties.Put("EnumerateMethod", "");
            this.dfnServerProcess.NamedProperties.Put("FieldFlags", "260");
            this.dfnServerProcess.NamedProperties.Put("LovReference", "");
            this.dfnServerProcess.NamedProperties.Put("ResizeableChildObject", "");
            this.dfnServerProcess.NamedProperties.Put("SqlColumn", "&AO.INTFACE_REPL_MAINT_UTIL_API.Count_Server_Processes(INTFACE_NAME)");
            this.dfnServerProcess.NamedProperties.Put("ValidateMethod", "");
            // 
            // menuFrmMethods
            // 
            this.picTab.SetControlTabPages(this.menuFrmMethods, "");
            this.menuFrmMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem__Copy,
            this.menuItem_Start,
            this.menuItem_Start_1,
            this.menuItem_Compile,
            this.menuSeparator1,
            this.menuItem_Compile_1,
            this.menuItem__Enable,
            this.menuItem__Disable,
            this.menuSeparator2,
            this.menuItem_Show,
            this.menuItem_Show_1,
            this.menuItem_Create});
            this.menuFrmMethods.Name = "menuFrmMethods";
            resources.ApplyResources(this.menuFrmMethods, "menuFrmMethods");
            // 
            // menuItem__Copy
            // 
            this.menuItem__Copy.Command = this.menuFrmMethods_menu_Copy_Migration_Job;
            this.menuItem__Copy.Name = "menuItem__Copy";
            resources.ApplyResources(this.menuItem__Copy, "menuItem__Copy");
            this.menuItem__Copy.Text = "&Copy Migration Job";
            // 
            // menuItem_Start
            // 
            this.menuItem_Start.Command = this.menuFrmMethods_menuStart__Insert_Package;
            this.menuItem_Start.Name = "menuItem_Start";
            resources.ApplyResources(this.menuItem_Start, "menuItem_Start");
            this.menuItem_Start.Text = "Start &Insert Package";
            // 
            // menuItem_Start_1
            // 
            this.menuItem_Start_1.Command = this.menuFrmMethods_menuStart__Update_Package;
            this.menuItem_Start_1.Name = "menuItem_Start_1";
            resources.ApplyResources(this.menuItem_Start_1, "menuItem_Start_1");
            this.menuItem_Start_1.Text = "Start &Update Package";
            // 
            // menuItem_Compile
            // 
            this.menuItem_Compile.Command = this.menuFrmMethods_menuCompile__Packages;
            this.menuItem_Compile.Name = "menuItem_Compile";
            resources.ApplyResources(this.menuItem_Compile, "menuItem_Compile");
            this.menuItem_Compile.Text = "Compile &Packages";
            // 
            // menuSeparator1
            // 
            this.menuSeparator1.Name = "menuSeparator1";
            resources.ApplyResources(this.menuSeparator1, "menuSeparator1");
            // 
            // menuItem_Compile_1
            // 
            this.menuItem_Compile_1.Command = this.menuFrmMethods_menuCompile__Triggers;
            this.menuItem_Compile_1.Name = "menuItem_Compile_1";
            resources.ApplyResources(this.menuItem_Compile_1, "menuItem_Compile_1");
            this.menuItem_Compile_1.Text = "Compile &Triggers";
            // 
            // menuItem__Enable
            // 
            this.menuItem__Enable.Command = this.menuFrmMethods_menu_Enable_Triggers;
            this.menuItem__Enable.Name = "menuItem__Enable";
            resources.ApplyResources(this.menuItem__Enable, "menuItem__Enable");
            this.menuItem__Enable.Text = "&Enable Triggers";
            // 
            // menuItem__Disable
            // 
            this.menuItem__Disable.Command = this.menuFrmMethods_menu_Disable_Triggers;
            this.menuItem__Disable.Name = "menuItem__Disable";
            resources.ApplyResources(this.menuItem__Disable, "menuItem__Disable");
            this.menuItem__Disable.Text = "&Disable Triggers";
            // 
            // menuSeparator2
            // 
            this.menuSeparator2.Name = "menuSeparator2";
            resources.ApplyResources(this.menuSeparator2, "menuSeparator2");
            // 
            // menuItem_Show
            // 
            this.menuItem_Show.Command = this.menuFrmMethods_menuShow__Server_Processes;
            this.menuItem_Show.Name = "menuItem_Show";
            resources.ApplyResources(this.menuItem_Show, "menuItem_Show");
            this.menuItem_Show.Text = "Show &Scheduled Migration Jobs";
            // 
            // menuItem_Show_1
            // 
            this.menuItem_Show_1.Command = this.menuFrmMethods_menuShow__Log;
            this.menuItem_Show_1.Name = "menuItem_Show_1";
            resources.ApplyResources(this.menuItem_Show_1, "menuItem_Show_1");
            this.menuItem_Show_1.Text = "Show &Log";
            // 
            // menuItem_Create
            // 
            this.menuItem_Create.Command = this.menuFrmMethods_menuCreate__XSD_File;
            this.menuItem_Create.Name = "menuItem_Create";
            resources.ApplyResources(this.menuItem_Create, "menuItem_Create");
            this.menuItem_Create.Text = "Create &XSD File";
            // 
            // menuTblMethodsStructure
            // 
            this.picTab.SetControlTabPages(this.menuTblMethodsStructure, "");
            this.menuTblMethodsStructure.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_Define});
            this.menuTblMethodsStructure.Name = "menuTblMethodsStructure";
            resources.ApplyResources(this.menuTblMethodsStructure, "menuTblMethodsStructure");
            // 
            // menuItem_Define
            // 
            this.menuItem_Define.Command = this.cmdDefineColumns;
            this.menuItem_Define.Name = "menuItem_Define";
            resources.ApplyResources(this.menuItem_Define, "menuItem_Define");
            this.menuItem_Define.Text = "Define Columns...";
            // 
            // tblStructure
            // 
            this.tblStructure.ContextMenuStrip = this.menuTblMethodsStructure;
            this.tblStructure.Controls.Add(this.tblStructure_colsIntfaceName);
            this.tblStructure.Controls.Add(this.tblStructure_colnStructureSeq);
            this.tblStructure.Controls.Add(this.tblStructure_colsViewName);
            this.tblStructure.Controls.Add(this.tblStructure_colnParentSeq);
            this.tblStructure.Controls.Add(this.tblStructure_colsTriggerTable);
            this.tblStructure.Controls.Add(this.tblStructure_colsOnInsert);
            this.tblStructure.Controls.Add(this.tblStructure_colsOnUpdate);
            this.tblStructure.Controls.Add(this.tblStructure_colsRecordName);
            this.tblStructure.Controls.Add(this.tblStructure_colsElementName);
            this.tblStructure.Controls.Add(this.tblStructure_colsElementType);
            this.tblStructure.Controls.Add(this.tblStructure_colSelectWhere);
            this.tblStructure.Controls.Add(this.tblStructure_colTriggerWhen);
            this.tblStructure.Controls.Add(this.tblStructure_colsStartPoint);
            this.tblStructure.Controls.Add(this.tblStructure_colNoteText);
            this.tblStructure.Controls.Add(this.tblStructure_colnPos);
            this.picTab.SetControlTabPages(this.tblStructure, "Struct");
            resources.ApplyResources(this.tblStructure, "tblStructure");
            this.tblStructure.Name = "tblStructure";
            this.tblStructure.NamedProperties.Put("DefaultOrderBy", "pos");
            this.tblStructure.NamedProperties.Put("DefaultWhere", "");
            this.tblStructure.NamedProperties.Put("LogicalUnit", "IntfaceReplStructure");
            this.tblStructure.NamedProperties.Put("PackageName", "INTFACE_REPL_STRUCTURE_API");
            this.tblStructure.NamedProperties.Put("ResizeableChildObject", "LLRL");
            this.tblStructure.NamedProperties.Put("Warnings", "FALSE");
            this.tblStructure.NamedProperties.Put("ViewName", "INTFACE_REPL_STRUCTURE");
            this.tblStructure.Controls.SetChildIndex(this.tblStructure_colnPos, 0);
            this.tblStructure.Controls.SetChildIndex(this.tblStructure_colNoteText, 0);
            this.tblStructure.Controls.SetChildIndex(this.tblStructure_colsStartPoint, 0);
            this.tblStructure.Controls.SetChildIndex(this.tblStructure_colTriggerWhen, 0);
            this.tblStructure.Controls.SetChildIndex(this.tblStructure_colSelectWhere, 0);
            this.tblStructure.Controls.SetChildIndex(this.tblStructure_colsElementType, 0);
            this.tblStructure.Controls.SetChildIndex(this.tblStructure_colsElementName, 0);
            this.tblStructure.Controls.SetChildIndex(this.tblStructure_colsRecordName, 0);
            this.tblStructure.Controls.SetChildIndex(this.tblStructure_colsOnUpdate, 0);
            this.tblStructure.Controls.SetChildIndex(this.tblStructure_colsOnInsert, 0);
            this.tblStructure.Controls.SetChildIndex(this.tblStructure_colsTriggerTable, 0);
            this.tblStructure.Controls.SetChildIndex(this.tblStructure_colnParentSeq, 0);
            this.tblStructure.Controls.SetChildIndex(this.tblStructure_colsViewName, 0);
            this.tblStructure.Controls.SetChildIndex(this.tblStructure_colnStructureSeq, 0);
            this.tblStructure.Controls.SetChildIndex(this.tblStructure_colsIntfaceName, 0);
            // 
            // tblStructure_colsIntfaceName
            // 
            this.tblStructure_colsIntfaceName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.picTab.SetControlTabPages(this.tblStructure_colsIntfaceName, "");
            resources.ApplyResources(this.tblStructure_colsIntfaceName, "tblStructure_colsIntfaceName");
            this.tblStructure_colsIntfaceName.MaxLength = 30;
            this.tblStructure_colsIntfaceName.Name = "tblStructure_colsIntfaceName";
            this.tblStructure_colsIntfaceName.NamedProperties.Put("EnumerateMethod", "");
            this.tblStructure_colsIntfaceName.NamedProperties.Put("FieldFlags", "2115");
            this.tblStructure_colsIntfaceName.NamedProperties.Put("LovReference", "INTFACE_HEADER");
            this.tblStructure_colsIntfaceName.NamedProperties.Put("ResizeableChildObject", "");
            this.tblStructure_colsIntfaceName.NamedProperties.Put("SqlColumn", "INTFACE_NAME");
            this.tblStructure_colsIntfaceName.NamedProperties.Put("ValidateMethod", "");
            this.tblStructure_colsIntfaceName.Position = 3;
            // 
            // tblStructure_colnStructureSeq
            // 
            this.picTab.SetControlTabPages(this.tblStructure_colnStructureSeq, "");
            this.tblStructure_colnStructureSeq.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblStructure_colnStructureSeq.Name = "tblStructure_colnStructureSeq";
            this.tblStructure_colnStructureSeq.NamedProperties.Put("EnumerateMethod", "");
            this.tblStructure_colnStructureSeq.NamedProperties.Put("FieldFlags", "163");
            this.tblStructure_colnStructureSeq.NamedProperties.Put("LovReference", "");
            this.tblStructure_colnStructureSeq.NamedProperties.Put("SqlColumn", "STRUCTURE_SEQ");
            this.tblStructure_colnStructureSeq.Position = 4;
            resources.ApplyResources(this.tblStructure_colnStructureSeq, "tblStructure_colnStructureSeq");
            // 
            // tblStructure_colsViewName
            // 
            this.picTab.SetControlTabPages(this.tblStructure_colsViewName, "");
            this.tblStructure_colsViewName.Name = "tblStructure_colsViewName";
            this.tblStructure_colsViewName.NamedProperties.Put("EnumerateMethod", "");
            this.tblStructure_colsViewName.NamedProperties.Put("FieldFlags", "295");
            this.tblStructure_colsViewName.NamedProperties.Put("LovReference", "INTFACE_VIEWS");
            this.tblStructure_colsViewName.NamedProperties.Put("ResizeableChildObject", "");
            this.tblStructure_colsViewName.NamedProperties.Put("SqlColumn", "VIEW_NAME");
            this.tblStructure_colsViewName.NamedProperties.Put("ValidateMethod", "");
            this.tblStructure_colsViewName.Position = 5;
            resources.ApplyResources(this.tblStructure_colsViewName, "tblStructure_colsViewName");
            // 
            // tblStructure_colnParentSeq
            // 
            this.picTab.SetControlTabPages(this.tblStructure_colnParentSeq, "");
            this.tblStructure_colnParentSeq.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblStructure_colnParentSeq.Name = "tblStructure_colnParentSeq";
            this.tblStructure_colnParentSeq.NamedProperties.Put("EnumerateMethod", "");
            this.tblStructure_colnParentSeq.NamedProperties.Put("FieldFlags", "294");
            this.tblStructure_colnParentSeq.NamedProperties.Put("LovReference", "INTFACE_REPL_PARENT_LOV(intface_name)");
            this.tblStructure_colnParentSeq.NamedProperties.Put("ResizeableChildObject", "");
            this.tblStructure_colnParentSeq.NamedProperties.Put("SqlColumn", "PARENT_SEQ");
            this.tblStructure_colnParentSeq.NamedProperties.Put("ValidateMethod", "");
            this.tblStructure_colnParentSeq.Position = 6;
            resources.ApplyResources(this.tblStructure_colnParentSeq, "tblStructure_colnParentSeq");
            // 
            // tblStructure_colsTriggerTable
            // 
            this.picTab.SetControlTabPages(this.tblStructure_colsTriggerTable, "");
            this.tblStructure_colsTriggerTable.MaxLength = 30;
            this.tblStructure_colsTriggerTable.Name = "tblStructure_colsTriggerTable";
            this.tblStructure_colsTriggerTable.NamedProperties.Put("EnumerateMethod", "");
            this.tblStructure_colsTriggerTable.NamedProperties.Put("FieldFlags", "294");
            this.tblStructure_colsTriggerTable.NamedProperties.Put("LovReference", "INTFACE_REPL_TABLE_LOV");
            this.tblStructure_colsTriggerTable.NamedProperties.Put("ResizeableChildObject", "");
            this.tblStructure_colsTriggerTable.NamedProperties.Put("SqlColumn", "TRIGGER_TABLE");
            this.tblStructure_colsTriggerTable.NamedProperties.Put("ValidateMethod", "");
            this.tblStructure_colsTriggerTable.Position = 7;
            resources.ApplyResources(this.tblStructure_colsTriggerTable, "tblStructure_colsTriggerTable");
            // 
            // tblStructure_colsOnInsert
            // 
            this.picTab.SetControlTabPages(this.tblStructure_colsOnInsert, "");
            this.tblStructure_colsOnInsert.MaxLength = 5;
            this.tblStructure_colsOnInsert.Name = "tblStructure_colsOnInsert";
            this.tblStructure_colsOnInsert.NamedProperties.Put("EnumerateMethod", "");
            this.tblStructure_colsOnInsert.NamedProperties.Put("FieldFlags", "295");
            this.tblStructure_colsOnInsert.NamedProperties.Put("LovReference", "");
            this.tblStructure_colsOnInsert.NamedProperties.Put("SqlColumn", "ON_INSERT");
            this.tblStructure_colsOnInsert.Position = 8;
            resources.ApplyResources(this.tblStructure_colsOnInsert, "tblStructure_colsOnInsert");
            // 
            // tblStructure_colsOnUpdate
            // 
            this.picTab.SetControlTabPages(this.tblStructure_colsOnUpdate, "");
            this.tblStructure_colsOnUpdate.MaxLength = 5;
            this.tblStructure_colsOnUpdate.Name = "tblStructure_colsOnUpdate";
            this.tblStructure_colsOnUpdate.NamedProperties.Put("EnumerateMethod", "");
            this.tblStructure_colsOnUpdate.NamedProperties.Put("FieldFlags", "295");
            this.tblStructure_colsOnUpdate.NamedProperties.Put("LovReference", "");
            this.tblStructure_colsOnUpdate.NamedProperties.Put("SqlColumn", "ON_UPDATE");
            this.tblStructure_colsOnUpdate.Position = 9;
            resources.ApplyResources(this.tblStructure_colsOnUpdate, "tblStructure_colsOnUpdate");
            // 
            // tblStructure_colsRecordName
            // 
            this.picTab.SetControlTabPages(this.tblStructure_colsRecordName, "");
            this.tblStructure_colsRecordName.Name = "tblStructure_colsRecordName";
            this.tblStructure_colsRecordName.NamedProperties.Put("EnumerateMethod", "");
            this.tblStructure_colsRecordName.NamedProperties.Put("FieldFlags", "294");
            this.tblStructure_colsRecordName.NamedProperties.Put("LovReference", "");
            this.tblStructure_colsRecordName.NamedProperties.Put("SqlColumn", "RECORD_NAME");
            this.tblStructure_colsRecordName.Position = 10;
            resources.ApplyResources(this.tblStructure_colsRecordName, "tblStructure_colsRecordName");
            // 
            // tblStructure_colsElementName
            // 
            this.picTab.SetControlTabPages(this.tblStructure_colsElementName, "");
            this.tblStructure_colsElementName.Name = "tblStructure_colsElementName";
            this.tblStructure_colsElementName.NamedProperties.Put("EnumerateMethod", "");
            this.tblStructure_colsElementName.NamedProperties.Put("FieldFlags", "294");
            this.tblStructure_colsElementName.NamedProperties.Put("LovReference", "");
            this.tblStructure_colsElementName.NamedProperties.Put("SqlColumn", "ELEMENT_NAME");
            this.tblStructure_colsElementName.Position = 11;
            resources.ApplyResources(this.tblStructure_colsElementName, "tblStructure_colsElementName");
            // 
            // tblStructure_colsElementType
            // 
            this.picTab.SetControlTabPages(this.tblStructure_colsElementType, "");
            this.tblStructure_colsElementType.MaxLength = 200;
            this.tblStructure_colsElementType.Name = "tblStructure_colsElementType";
            this.tblStructure_colsElementType.NamedProperties.Put("EnumerateMethod", "INTFACE_REPL_ELEM_TYPE_API.Enumerate");
            this.tblStructure_colsElementType.NamedProperties.Put("FieldFlags", "295");
            this.tblStructure_colsElementType.NamedProperties.Put("LovReference", "");
            this.tblStructure_colsElementType.NamedProperties.Put("SqlColumn", "ELEMENT_TYPE");
            this.tblStructure_colsElementType.Position = 12;
            resources.ApplyResources(this.tblStructure_colsElementType, "tblStructure_colsElementType");
            // 
            // tblStructure_colSelectWhere
            // 
            this.picTab.SetControlTabPages(this.tblStructure_colSelectWhere, "");
            this.tblStructure_colSelectWhere.MaxLength = 2000;
            this.tblStructure_colSelectWhere.Name = "tblStructure_colSelectWhere";
            this.tblStructure_colSelectWhere.NamedProperties.Put("EnumerateMethod", "");
            this.tblStructure_colSelectWhere.NamedProperties.Put("FieldFlags", "310");
            this.tblStructure_colSelectWhere.NamedProperties.Put("LovReference", "");
            this.tblStructure_colSelectWhere.NamedProperties.Put("SqlColumn", "SELECT_WHERE");
            this.tblStructure_colSelectWhere.Position = 13;
            resources.ApplyResources(this.tblStructure_colSelectWhere, "tblStructure_colSelectWhere");
            // 
            // tblStructure_colTriggerWhen
            // 
            this.picTab.SetControlTabPages(this.tblStructure_colTriggerWhen, "");
            this.tblStructure_colTriggerWhen.MaxLength = 2000;
            this.tblStructure_colTriggerWhen.Name = "tblStructure_colTriggerWhen";
            this.tblStructure_colTriggerWhen.NamedProperties.Put("EnumerateMethod", "");
            this.tblStructure_colTriggerWhen.NamedProperties.Put("FieldFlags", "310");
            this.tblStructure_colTriggerWhen.NamedProperties.Put("LovReference", "");
            this.tblStructure_colTriggerWhen.NamedProperties.Put("SqlColumn", "TRIGGER_WHEN");
            this.tblStructure_colTriggerWhen.Position = 14;
            resources.ApplyResources(this.tblStructure_colTriggerWhen, "tblStructure_colTriggerWhen");
            // 
            // tblStructure_colsStartPoint
            // 
            this.picTab.SetControlTabPages(this.tblStructure_colsStartPoint, "");
            this.tblStructure_colsStartPoint.MaxLength = 5;
            this.tblStructure_colsStartPoint.Name = "tblStructure_colsStartPoint";
            this.tblStructure_colsStartPoint.NamedProperties.Put("EnumerateMethod", "");
            this.tblStructure_colsStartPoint.NamedProperties.Put("FieldFlags", "295");
            this.tblStructure_colsStartPoint.NamedProperties.Put("LovReference", "");
            this.tblStructure_colsStartPoint.NamedProperties.Put("SqlColumn", "START_POINT");
            this.tblStructure_colsStartPoint.Position = 15;
            resources.ApplyResources(this.tblStructure_colsStartPoint, "tblStructure_colsStartPoint");
            // 
            // tblStructure_colNoteText
            // 
            this.picTab.SetControlTabPages(this.tblStructure_colNoteText, "");
            this.tblStructure_colNoteText.MaxLength = 2000;
            this.tblStructure_colNoteText.Name = "tblStructure_colNoteText";
            this.tblStructure_colNoteText.NamedProperties.Put("EnumerateMethod", "");
            this.tblStructure_colNoteText.NamedProperties.Put("FieldFlags", "310");
            this.tblStructure_colNoteText.NamedProperties.Put("LovReference", "");
            this.tblStructure_colNoteText.NamedProperties.Put("SqlColumn", "NOTE_TEXT");
            this.tblStructure_colNoteText.Position = 16;
            resources.ApplyResources(this.tblStructure_colNoteText, "tblStructure_colNoteText");
            // 
            // tblStructure_colnPos
            // 
            this.picTab.SetControlTabPages(this.tblStructure_colnPos, "");
            this.tblStructure_colnPos.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.tblStructure_colnPos, "tblStructure_colnPos");
            this.tblStructure_colnPos.Name = "tblStructure_colnPos";
            this.tblStructure_colnPos.NamedProperties.Put("EnumerateMethod", "");
            this.tblStructure_colnPos.NamedProperties.Put("FieldFlags", "294");
            this.tblStructure_colnPos.NamedProperties.Put("LovReference", "");
            this.tblStructure_colnPos.NamedProperties.Put("ResizeableChildObject", "");
            this.tblStructure_colnPos.NamedProperties.Put("SqlColumn", "POS");
            this.tblStructure_colnPos.NamedProperties.Put("ValidateMethod", "");
            this.tblStructure_colnPos.Position = 17;
            // 
            // tblObjects
            // 
            this.tblObjects.ContextMenuStrip = this.menuTblMethodsObjects;
            this.tblObjects.Controls.Add(this.tblObjects_colsObjectName);
            this.tblObjects.Controls.Add(this.tblObjects_colsObjectType);
            this.tblObjects.Controls.Add(this.tblObjects_colsStatus);
            this.tblObjects.Controls.Add(this.tblObjects_colsTableName);
            this.tblObjects.Controls.Add(this.tblObjects_colErrorText);
            this.tblObjects.Controls.Add(this.tblObjects_coldCreated);
            this.tblObjects.Controls.Add(this.tblObjects_colsIntfaceName);
            this.tblObjects.Controls.Add(this.tblObjects_coldLastDdlTime);
            this.picTab.SetControlTabPages(this.tblObjects, "Struct");
            resources.ApplyResources(this.tblObjects, "tblObjects");
            this.tblObjects.Name = "tblObjects";
            this.tblObjects.NamedProperties.Put("DefaultOrderBy", "OBJECT_TYPE, OBJECT_NAME");
            this.tblObjects.NamedProperties.Put("DefaultWhere", "");
            this.tblObjects.NamedProperties.Put("LogicalUnit", "IntfaceReplDbObjects");
            this.tblObjects.NamedProperties.Put("PackageName", "INTFACE_REPL_DB_OBJECTS_API");
            this.tblObjects.NamedProperties.Put("ResizeableChildObject", "LLRR");
            this.tblObjects.NamedProperties.Put("SourceFlags", "0");
            this.tblObjects.NamedProperties.Put("Warnings", "FALSE");
            this.tblObjects.NamedProperties.Put("ViewName", "INTFACE_REPL_DB_OBJECTS");
            this.tblObjects.Controls.SetChildIndex(this.tblObjects_coldLastDdlTime, 0);
            this.tblObjects.Controls.SetChildIndex(this.tblObjects_colsIntfaceName, 0);
            this.tblObjects.Controls.SetChildIndex(this.tblObjects_coldCreated, 0);
            this.tblObjects.Controls.SetChildIndex(this.tblObjects_colErrorText, 0);
            this.tblObjects.Controls.SetChildIndex(this.tblObjects_colsTableName, 0);
            this.tblObjects.Controls.SetChildIndex(this.tblObjects_colsStatus, 0);
            this.tblObjects.Controls.SetChildIndex(this.tblObjects_colsObjectType, 0);
            this.tblObjects.Controls.SetChildIndex(this.tblObjects_colsObjectName, 0);
            // 
            // tblObjects_colsObjectName
            // 
            this.tblObjects_colsObjectName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.picTab.SetControlTabPages(this.tblObjects_colsObjectName, "");
            this.tblObjects_colsObjectName.MaxLength = 128;
            this.tblObjects_colsObjectName.Name = "tblObjects_colsObjectName";
            this.tblObjects_colsObjectName.NamedProperties.Put("EnumerateMethod", "");
            this.tblObjects_colsObjectName.NamedProperties.Put("FieldFlags", "288");
            this.tblObjects_colsObjectName.NamedProperties.Put("LovReference", "");
            this.tblObjects_colsObjectName.NamedProperties.Put("SqlColumn", "OBJECT_NAME");
            this.tblObjects_colsObjectName.Position = 3;
            resources.ApplyResources(this.tblObjects_colsObjectName, "tblObjects_colsObjectName");
            // 
            // tblObjects_colsObjectType
            // 
            this.tblObjects_colsObjectType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.picTab.SetControlTabPages(this.tblObjects_colsObjectType, "");
            this.tblObjects_colsObjectType.Name = "tblObjects_colsObjectType";
            this.tblObjects_colsObjectType.NamedProperties.Put("EnumerateMethod", "");
            this.tblObjects_colsObjectType.NamedProperties.Put("FieldFlags", "288");
            this.tblObjects_colsObjectType.NamedProperties.Put("LovReference", "");
            this.tblObjects_colsObjectType.NamedProperties.Put("SqlColumn", "OBJECT_TYPE");
            this.tblObjects_colsObjectType.Position = 4;
            resources.ApplyResources(this.tblObjects_colsObjectType, "tblObjects_colsObjectType");
            // 
            // tblObjects_colsStatus
            // 
            this.tblObjects_colsStatus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.picTab.SetControlTabPages(this.tblObjects_colsStatus, "");
            this.tblObjects_colsStatus.MaxLength = 30;
            this.tblObjects_colsStatus.Name = "tblObjects_colsStatus";
            this.tblObjects_colsStatus.NamedProperties.Put("EnumerateMethod", "");
            this.tblObjects_colsStatus.NamedProperties.Put("FieldFlags", "288");
            this.tblObjects_colsStatus.NamedProperties.Put("LovReference", "");
            this.tblObjects_colsStatus.NamedProperties.Put("SqlColumn", "STATUS");
            this.tblObjects_colsStatus.NamedProperties.Put("ValidateMethod", "");
            this.tblObjects_colsStatus.Position = 5;
            resources.ApplyResources(this.tblObjects_colsStatus, "tblObjects_colsStatus");
            // 
            // tblObjects_colsTableName
            // 
            this.tblObjects_colsTableName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.picTab.SetControlTabPages(this.tblObjects_colsTableName, "");
            this.tblObjects_colsTableName.Name = "tblObjects_colsTableName";
            this.tblObjects_colsTableName.NamedProperties.Put("EnumerateMethod", "");
            this.tblObjects_colsTableName.NamedProperties.Put("FieldFlags", "288");
            this.tblObjects_colsTableName.NamedProperties.Put("LovReference", "");
            this.tblObjects_colsTableName.NamedProperties.Put("SqlColumn", "TABLE_NAME");
            this.tblObjects_colsTableName.NamedProperties.Put("ValidateMethod", "");
            this.tblObjects_colsTableName.Position = 6;
            resources.ApplyResources(this.tblObjects_colsTableName, "tblObjects_colsTableName");
            // 
            // tblObjects_colErrorText
            // 
            this.picTab.SetControlTabPages(this.tblObjects_colErrorText, "");
            this.tblObjects_colErrorText.MaxLength = 2000;
            this.tblObjects_colErrorText.Name = "tblObjects_colErrorText";
            this.tblObjects_colErrorText.NamedProperties.Put("EnumerateMethod", "");
            this.tblObjects_colErrorText.NamedProperties.Put("FieldFlags", "304");
            this.tblObjects_colErrorText.NamedProperties.Put("LovReference", "");
            this.tblObjects_colErrorText.NamedProperties.Put("SqlColumn", "ERROR_TEXT");
            this.tblObjects_colErrorText.NamedProperties.Put("ValidateMethod", "");
            this.tblObjects_colErrorText.Position = 7;
            resources.ApplyResources(this.tblObjects_colErrorText, "tblObjects_colErrorText");
            // 
            // tblObjects_coldCreated
            // 
            this.picTab.SetControlTabPages(this.tblObjects_coldCreated, "");
            this.tblObjects_coldCreated.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.tblObjects_coldCreated.Format = "G";
            this.tblObjects_coldCreated.Name = "tblObjects_coldCreated";
            this.tblObjects_coldCreated.NamedProperties.Put("EnumerateMethod", "");
            this.tblObjects_coldCreated.NamedProperties.Put("FieldFlags", "288");
            this.tblObjects_coldCreated.NamedProperties.Put("LovReference", "");
            this.tblObjects_coldCreated.NamedProperties.Put("SqlColumn", "CREATED");
            this.tblObjects_coldCreated.Position = 8;
            resources.ApplyResources(this.tblObjects_coldCreated, "tblObjects_coldCreated");
            // 
            // tblObjects_colsIntfaceName
            // 
            this.tblObjects_colsIntfaceName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.picTab.SetControlTabPages(this.tblObjects_colsIntfaceName, "");
            resources.ApplyResources(this.tblObjects_colsIntfaceName, "tblObjects_colsIntfaceName");
            this.tblObjects_colsIntfaceName.Name = "tblObjects_colsIntfaceName";
            this.tblObjects_colsIntfaceName.NamedProperties.Put("EnumerateMethod", "");
            this.tblObjects_colsIntfaceName.NamedProperties.Put("FieldFlags", "67");
            this.tblObjects_colsIntfaceName.NamedProperties.Put("LovReference", "INTFACE_HEADER");
            this.tblObjects_colsIntfaceName.NamedProperties.Put("ResizeableChildObject", "");
            this.tblObjects_colsIntfaceName.NamedProperties.Put("SqlColumn", "INTFACE_NAME");
            this.tblObjects_colsIntfaceName.NamedProperties.Put("ValidateMethod", "");
            this.tblObjects_colsIntfaceName.Position = 9;
            // 
            // tblObjects_coldLastDdlTime
            // 
            this.picTab.SetControlTabPages(this.tblObjects_coldLastDdlTime, "");
            this.tblObjects_coldLastDdlTime.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.tblObjects_coldLastDdlTime.Format = "G";
            this.tblObjects_coldLastDdlTime.Name = "tblObjects_coldLastDdlTime";
            this.tblObjects_coldLastDdlTime.NamedProperties.Put("EnumerateMethod", "");
            this.tblObjects_coldLastDdlTime.NamedProperties.Put("FieldFlags", "288");
            this.tblObjects_coldLastDdlTime.NamedProperties.Put("LovReference", "");
            this.tblObjects_coldLastDdlTime.NamedProperties.Put("SqlColumn", "LAST_DDL_TIME");
            this.tblObjects_coldLastDdlTime.Position = 10;
            resources.ApplyResources(this.tblObjects_coldLastDdlTime, "tblObjects_coldLastDdlTime");
            // 
            // frmIntfaceReplStruct
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.dfnServerProcess);
            this.Controls.Add(this.dflsHiddenSqlStatement);
            this.Controls.Add(this.cmbFileLocation);
            this.Controls.Add(this.tblStructure);
            this.Controls.Add(this.tblObjects);
            this.Controls.Add(this.dfsDirection);
            this.Controls.Add(this.dfsNoteText);
            this.Controls.Add(this.dfsDateFormat);
            this.Controls.Add(this.dfsMessageReceiver);
            this.Controls.Add(this.dfsMessageSender);
            this.Controls.Add(this.cmbMessageType);
            this.Controls.Add(this.dfsMessageName);
            this.Controls.Add(this.dfsGroupId);
            this.Controls.Add(this.dfsProcedureName);
            this.Controls.Add(this.cmbReplicationMode);
            this.Controls.Add(this.dfsDescription);
            this.Controls.Add(this.ecmbIntfaceName);
            this.Controls.Add(this.labeldfnServerProcess);
            this.Controls.Add(this.labeldflsHiddenSqlStatement);
            this.Controls.Add(this.labelcmbFileLocation);
            this.Controls.Add(this.labeldfsDirection);
            this.Controls.Add(this.labeldfsNoteText);
            this.Controls.Add(this.labeldfsDateFormat);
            this.Controls.Add(this.labeldfsMessageReceiver);
            this.Controls.Add(this.labeldfsMessageSender);
            this.Controls.Add(this.labelcmbMessageType);
            this.Controls.Add(this.labeldfsMessageName);
            this.Controls.Add(this.labeldfsGroupId);
            this.Controls.Add(this.labeldfsProcedureName);
            this.Controls.Add(this.labelcmbReplicationMode);
            this.Controls.Add(this.labeldfsDescription);
            this.Controls.Add(this.labelecmbIntfaceName);
            this.Name = "frmIntfaceReplStruct";
            this.NamedProperties.Put("DefaultOrderBy", "INTFACE_NAME");
            this.NamedProperties.Put("DefaultWhere", @"&AO.Intface_User_API.Get_Privilege(&AO.Fnd_Session_API.Get_FND_User) = &AO.Intface_Privilege_API.Get_Client_Value(1)
AND procedure_name in (select procedure_name from &AO.INTFACE_PROC_LOV_INCL_REPL)  AND nvl(&AO.Intface_Group_API.Get_Hide_Flag(GROUP_ID),'FALSE') = 'FALSE' AND INTFACE_NAME IN (SELECT INTFACE_NAME FROM &AO.INTFACE_ALLOWED_JOBS)");
            this.NamedProperties.Put("LogicalUnit", "IntfaceHeader");
            this.NamedProperties.Put("PackageName", "INTFACE_HEADER_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "4545");
            this.NamedProperties.Put("Warnings", "TRUE");
            this.NamedProperties.Put("ViewName", "INTFACE_HEADER");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.frmIntfaceReplStruct_WindowActions);
            this.Controls.SetChildIndex(this.picTab, 0);
            this.Controls.SetChildIndex(this.labelecmbIntfaceName, 0);
            this.Controls.SetChildIndex(this.labeldfsDescription, 0);
            this.Controls.SetChildIndex(this.labelcmbReplicationMode, 0);
            this.Controls.SetChildIndex(this.labeldfsProcedureName, 0);
            this.Controls.SetChildIndex(this.labeldfsGroupId, 0);
            this.Controls.SetChildIndex(this.labeldfsMessageName, 0);
            this.Controls.SetChildIndex(this.labelcmbMessageType, 0);
            this.Controls.SetChildIndex(this.labeldfsMessageSender, 0);
            this.Controls.SetChildIndex(this.labeldfsMessageReceiver, 0);
            this.Controls.SetChildIndex(this.labeldfsDateFormat, 0);
            this.Controls.SetChildIndex(this.labeldfsNoteText, 0);
            this.Controls.SetChildIndex(this.labeldfsDirection, 0);
            this.Controls.SetChildIndex(this.labelcmbFileLocation, 0);
            this.Controls.SetChildIndex(this.labeldflsHiddenSqlStatement, 0);
            this.Controls.SetChildIndex(this.labeldfnServerProcess, 0);
            this.Controls.SetChildIndex(this.ecmbIntfaceName, 0);
            this.Controls.SetChildIndex(this.dfsDescription, 0);
            this.Controls.SetChildIndex(this.cmbReplicationMode, 0);
            this.Controls.SetChildIndex(this.dfsProcedureName, 0);
            this.Controls.SetChildIndex(this.dfsGroupId, 0);
            this.Controls.SetChildIndex(this.dfsMessageName, 0);
            this.Controls.SetChildIndex(this.cmbMessageType, 0);
            this.Controls.SetChildIndex(this.dfsMessageSender, 0);
            this.Controls.SetChildIndex(this.dfsMessageReceiver, 0);
            this.Controls.SetChildIndex(this.dfsDateFormat, 0);
            this.Controls.SetChildIndex(this.dfsNoteText, 0);
            this.Controls.SetChildIndex(this.dfsDirection, 0);
            this.Controls.SetChildIndex(this.tblObjects, 0);
            this.Controls.SetChildIndex(this.tblStructure, 0);
            this.Controls.SetChildIndex(this.cmbFileLocation, 0);
            this.Controls.SetChildIndex(this.dflsHiddenSqlStatement, 0);
            this.Controls.SetChildIndex(this.dfnServerProcess, 0);
            this.menuTblMethodsObjects.ResumeLayout(false);
            this.menuFrmMethods.ResumeLayout(false);
            this.menuTblMethodsStructure.ResumeLayout(false);
            this.tblStructure.ResumeLayout(false);
            this.tblObjects.ResumeLayout(false);
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
				
        public Fnd.Windows.Forms.FndCommand cmdShowSourceText;
        public Fnd.Windows.Forms.FndCommand cmdDefineColumns;
        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menu_Copy_Migration_Job;
        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menuStart__Insert_Package;
        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menuStart__Update_Package;
        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menuCompile__Packages;
        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menuCompile__Triggers;
        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menu_Enable_Triggers;
        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menu_Disable_Triggers;
        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menuShow__Server_Processes;
        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menuShow__Log;
        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menuCreate__XSD_File;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuFrmMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Copy;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Start;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Start_1;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Compile;
        protected Fnd.Windows.Forms.FndToolStripSeparator menuSeparator1;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Compile_1;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Enable;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Disable;
        protected Fnd.Windows.Forms.FndToolStripSeparator menuSeparator2;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Show;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Show_1;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Create;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTblMethodsStructure;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Define;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTblMethodsObjects;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_ShowSource;
        public cChildTable tblStructure;
        protected cColumn tblStructure_colsIntfaceName;
        protected cColumn tblStructure_colnStructureSeq;
        protected cColumn tblStructure_colsViewName;
        protected cColumn tblStructure_colnParentSeq;
        protected cColumn tblStructure_colsTriggerTable;
        protected cCheckBoxColumn tblStructure_colsOnInsert;
        protected cCheckBoxColumn tblStructure_colsOnUpdate;
        protected cColumn tblStructure_colsRecordName;
        protected cColumn tblStructure_colsElementName;
        protected cLookupColumn tblStructure_colsElementType;
        protected cColumn tblStructure_colSelectWhere;
        protected cColumn tblStructure_colTriggerWhen;
        protected cCheckBoxColumn tblStructure_colsStartPoint;
        protected cColumn tblStructure_colNoteText;
        protected cColumn tblStructure_colnPos;
        public cChildTable tblObjects;
        protected cColumn tblObjects_colsObjectName;
        protected cColumn tblObjects_colsObjectType;
        protected cColumn tblObjects_colsStatus;
        protected cColumn tblObjects_colsTableName;
        protected cColumn tblObjects_colErrorText;
        protected cColumn tblObjects_coldCreated;
        protected cColumn tblObjects_colsIntfaceName;
        protected cColumn tblObjects_coldLastDdlTime;
	}
}
