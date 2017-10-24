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
	
	public partial class frmIntfaceHeader
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
		protected SalBackgroundText labeldfsProcedureName;
		public cDataField dfsProcedureName;
		protected SalBackgroundText labeldfsViewName;
		public cDataField dfsViewName;
		protected SalBackgroundText labeldfsGroupId;
		public cDataField dfsGroupId;
		protected SalBackgroundText labeldfsNoteText;
		public cDataField dfsNoteText;
		protected SalBackgroundText labeldfnGroupSeq;
		public cDataField dfnGroupSeq;
		protected SalBackgroundText labeldfsDirection;
		public cDataField dfsDirection;
		protected SalBackgroundText labelcmbsReplicationMode;
		public cComboBox cmbsReplicationMode;
		protected SalGroupBox gbCriteria;
		protected SalBackgroundText labelcmbsReplCriteria;
		public cComboBox cmbsReplCriteria;
		protected SalBackgroundText labeldfsFromValue;
		public cDataField dfsFromValue;
		protected SalBackgroundText labeldfsValueList;
		public cDataField dfsValueList;
		protected SalGroupBox gbTrigger;
		protected SalBackgroundText labeldfsTableName;
		public cDataField dfsTableName;
		protected SalBackgroundText labeldfsTriggerWhen;
		public cDataField dfsTriggerWhen;
		public cCheckBox cbsEnabled;
		public cCheckBox cbOnInsert;
		public cCheckBox cbOnUpdate;
		protected SalGroupBox gbFile_Information;
		protected SalGroupBox gbFile_Configuration;
		protected SalGroupBox gbDatabase_Information;
		protected SalBackgroundText labeldfsIntfacePath;
		public cDataField dfsIntfacePath;
		protected SalBackgroundText labeldfsIntfaceFile;
		public cDataField dfsIntfaceFile;
		protected SalBackgroundText labelcmbFileLocation;
		public cComboBox cmbFileLocation;
		protected SalBackgroundText labeldfsDateFormat;
		public cDataField dfsDateFormat;
		protected SalBackgroundText labelcmbColumnSeparator;
		public cComboBox cmbColumnSeparator;
		protected SalBackgroundText labelcmbColumnEmbrace;
		public cComboBox cmbColumnEmbrace;
		protected SalBackgroundText labelcmbDecimalPoint;
		public cComboBox cmbDecimalPoint;
		protected SalBackgroundText labelcmbThousandSeparator;
		public cComboBox cmbThousandSeparator;
		protected SalBackgroundText labeldfnMinusPos;
		public cDataField dfnMinusPos;
		protected SalBackgroundText labeldfsSourceName;
		public cDataField dfsSourceName;
		protected SalBackgroundText labeldfsSourceOwner;
		public cDataField dfsSourceOwner;
		protected SalBackgroundText labeldfsWhereClause;
		public cDataField dfsWhereClause;
		protected SalBackgroundText labeldfsOrderByClause;
		public cDataField dfsOrderByClause;
		protected SalBackgroundText labeldfsGroupByClause;
		public cDataField dfsGroupByClause;
		public cDataField dflsHiddenSqlStatement;
		protected SalBackgroundText labeldfsLastInfo;
		public cDataField dfsLastInfo;
		protected SalBackgroundText labeldf23;
        public cDataField df23;
		public cDataField dfsNewName;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIntfaceHeader));
            this.menuFrmMethods_menuQ_uery_Source_Columns = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuFrmMethods_menuCopy__Migration_Job = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuFrmMethods_menuSho_w_Select_Statement = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuFrmMethods_menuSer_ver_Processes___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuFrmMethods_menuSchedule_Job = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.labelecmbIntfaceName = new PPJ.Runtime.Windows.SalBackgroundText();
            this.ecmbIntfaceName = new Ifs.Fnd.ApplicationForms.cRecListDataField();
            this.labeldfsDescription = new PPJ.Runtime.Windows.SalBackgroundText();
            this.dfsDescription = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsProcedureName = new PPJ.Runtime.Windows.SalBackgroundText();
            this.dfsProcedureName = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsViewName = new PPJ.Runtime.Windows.SalBackgroundText();
            this.dfsViewName = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsGroupId = new PPJ.Runtime.Windows.SalBackgroundText();
            this.dfsGroupId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsNoteText = new PPJ.Runtime.Windows.SalBackgroundText();
            this.dfsNoteText = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfnGroupSeq = new PPJ.Runtime.Windows.SalBackgroundText();
            this.dfnGroupSeq = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsDirection = new PPJ.Runtime.Windows.SalBackgroundText();
            this.dfsDirection = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelcmbsReplicationMode = new PPJ.Runtime.Windows.SalBackgroundText();
            this.cmbsReplicationMode = new Ifs.Fnd.ApplicationForms.cComboBox();
            this.gbCriteria = new PPJ.Runtime.Windows.SalGroupBox();
            this.labelcmbsReplCriteria = new PPJ.Runtime.Windows.SalBackgroundText();
            this.cmbsReplCriteria = new Ifs.Fnd.ApplicationForms.cComboBox();
            this.labeldfsFromValue = new PPJ.Runtime.Windows.SalBackgroundText();
            this.dfsFromValue = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsValueList = new PPJ.Runtime.Windows.SalBackgroundText();
            this.dfsValueList = new Ifs.Fnd.ApplicationForms.cDataField();
            this.gbTrigger = new PPJ.Runtime.Windows.SalGroupBox();
            this.labeldfsTableName = new PPJ.Runtime.Windows.SalBackgroundText();
            this.dfsTableName = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsTriggerWhen = new PPJ.Runtime.Windows.SalBackgroundText();
            this.dfsTriggerWhen = new Ifs.Fnd.ApplicationForms.cDataField();
            this.cbsEnabled = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.cbOnInsert = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.cbOnUpdate = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.gbFile_Information = new PPJ.Runtime.Windows.SalGroupBox();
            this.gbFile_Configuration = new PPJ.Runtime.Windows.SalGroupBox();
            this.gbDatabase_Information = new PPJ.Runtime.Windows.SalGroupBox();
            this.labeldfsIntfacePath = new PPJ.Runtime.Windows.SalBackgroundText();
            this.dfsIntfacePath = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsIntfaceFile = new PPJ.Runtime.Windows.SalBackgroundText();
            this.dfsIntfaceFile = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelcmbFileLocation = new PPJ.Runtime.Windows.SalBackgroundText();
            this.cmbFileLocation = new Ifs.Fnd.ApplicationForms.cComboBox();
            this.labeldfsDateFormat = new PPJ.Runtime.Windows.SalBackgroundText();
            this.dfsDateFormat = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelcmbColumnSeparator = new PPJ.Runtime.Windows.SalBackgroundText();
            this.cmbColumnSeparator = new Ifs.Fnd.ApplicationForms.cComboBox();
            this.labelcmbColumnEmbrace = new PPJ.Runtime.Windows.SalBackgroundText();
            this.cmbColumnEmbrace = new Ifs.Fnd.ApplicationForms.cComboBox();
            this.labelcmbDecimalPoint = new PPJ.Runtime.Windows.SalBackgroundText();
            this.cmbDecimalPoint = new Ifs.Fnd.ApplicationForms.cComboBox();
            this.labelcmbThousandSeparator = new PPJ.Runtime.Windows.SalBackgroundText();
            this.cmbThousandSeparator = new Ifs.Fnd.ApplicationForms.cComboBox();
            this.labeldfnMinusPos = new PPJ.Runtime.Windows.SalBackgroundText();
            this.dfnMinusPos = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsSourceName = new PPJ.Runtime.Windows.SalBackgroundText();
            this.dfsSourceName = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsSourceOwner = new PPJ.Runtime.Windows.SalBackgroundText();
            this.dfsSourceOwner = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsWhereClause = new PPJ.Runtime.Windows.SalBackgroundText();
            this.dfsWhereClause = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsOrderByClause = new PPJ.Runtime.Windows.SalBackgroundText();
            this.dfsOrderByClause = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsGroupByClause = new PPJ.Runtime.Windows.SalBackgroundText();
            this.dfsGroupByClause = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dflsHiddenSqlStatement = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsLastInfo = new PPJ.Runtime.Windows.SalBackgroundText();
            this.dfsLastInfo = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldf23 = new PPJ.Runtime.Windows.SalBackgroundText();
            this.df23 = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsNewName = new Ifs.Fnd.ApplicationForms.cDataField();
            this.menuFrmMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_Query = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem_Copy = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem_Show = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem_Server = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem_Schedule = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem_Translation = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuFrmMethods_menuTranslation = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuItem_Exec_Job = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuFrmMethods_menuExecJob = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuItem_History = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuFrmMethods_menuHistory = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuFrmMethods.SuspendLayout();
            this.SuspendLayout();
            // 
            // _cTabManager
            // 
            resources.ApplyResources(this._cTabManager, "_cTabManager");
            // 
            // picTab
            // 
            resources.ApplyResources(this.picTab, "picTab");
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuFrmMethods_menuQ_uery_Source_Columns);
            this.commandManager.Commands.Add(this.menuFrmMethods_menuCopy__Migration_Job);
            this.commandManager.Commands.Add(this.menuFrmMethods_menuSho_w_Select_Statement);
            this.commandManager.Commands.Add(this.menuFrmMethods_menuSer_ver_Processes___);
            this.commandManager.Commands.Add(this.menuFrmMethods_menuSchedule_Job);
            this.commandManager.Commands.Add(this.menuFrmMethods_menuTranslation);
            this.commandManager.Commands.Add(this.menuFrmMethods_menuExecJob);
            this.commandManager.Commands.Add(this.menuFrmMethods_menuHistory);
            this.commandManager.ContextMenus.Add(this.menuFrmMethods);
            this.commandManager.ImageList = null;
            // 
            // menuFrmMethods_menuQ_uery_Source_Columns
            // 
            resources.ApplyResources(this.menuFrmMethods_menuQ_uery_Source_Columns, "menuFrmMethods_menuQ_uery_Source_Columns");
            this.menuFrmMethods_menuQ_uery_Source_Columns.Name = "menuFrmMethods_menuQ_uery_Source_Columns";
            this.menuFrmMethods_menuQ_uery_Source_Columns.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Query_Execute);
            this.menuFrmMethods_menuQ_uery_Source_Columns.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Query_Inquire);
            // 
            // menuFrmMethods_menuCopy__Migration_Job
            // 
            resources.ApplyResources(this.menuFrmMethods_menuCopy__Migration_Job, "menuFrmMethods_menuCopy__Migration_Job");
            this.menuFrmMethods_menuCopy__Migration_Job.Name = "menuFrmMethods_menuCopy__Migration_Job";
            this.menuFrmMethods_menuCopy__Migration_Job.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Copy_Execute);
            this.menuFrmMethods_menuCopy__Migration_Job.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Copy_Inquire);
            // 
            // menuFrmMethods_menuSho_w_Select_Statement
            // 
            resources.ApplyResources(this.menuFrmMethods_menuSho_w_Select_Statement, "menuFrmMethods_menuSho_w_Select_Statement");
            this.menuFrmMethods_menuSho_w_Select_Statement.Name = "menuFrmMethods_menuSho_w_Select_Statement";
            this.menuFrmMethods_menuSho_w_Select_Statement.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Show_Execute);
            this.menuFrmMethods_menuSho_w_Select_Statement.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Show_Inquire);
            // 
            // menuFrmMethods_menuSer_ver_Processes___
            // 
            resources.ApplyResources(this.menuFrmMethods_menuSer_ver_Processes___, "menuFrmMethods_menuSer_ver_Processes___");
            this.menuFrmMethods_menuSer_ver_Processes___.Name = "menuFrmMethods_menuSer_ver_Processes___";
            this.menuFrmMethods_menuSer_ver_Processes___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Server_Execute);
            this.menuFrmMethods_menuSer_ver_Processes___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Server_Inquire);
            // 
            // menuFrmMethods_menuSchedule_Job
            // 
            resources.ApplyResources(this.menuFrmMethods_menuSchedule_Job, "menuFrmMethods_menuSchedule_Job");
            this.menuFrmMethods_menuSchedule_Job.Name = "menuFrmMethods_menuSchedule_Job";
            this.menuFrmMethods_menuSchedule_Job.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Schedule_Execute);
            this.menuFrmMethods_menuSchedule_Job.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Schedule_Inquire);
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
            this.dfsProcedureName.NamedProperties.Put("LovReference", "INTFACE_PROC_LOV_EXCL_REPL");
            this.dfsProcedureName.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsProcedureName.NamedProperties.Put("SqlColumn", "PROCEDURE_NAME");
            this.dfsProcedureName.NamedProperties.Put("ValidateMethod", "");
            this.dfsProcedureName.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsProcedureName_WindowActions);
            // 
            // labeldfsViewName
            // 
            resources.ApplyResources(this.labeldfsViewName, "labeldfsViewName");
            this.picTab.SetControlTabPages(this.labeldfsViewName, "");
            this.labeldfsViewName.Name = "labeldfsViewName";
            // 
            // dfsViewName
            // 
            this.dfsViewName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.picTab.SetControlTabPages(this.dfsViewName, "");
            resources.ApplyResources(this.dfsViewName, "dfsViewName");
            this.dfsViewName.Name = "dfsViewName";
            this.dfsViewName.NamedProperties.Put("EnumerateMethod", "");
            this.dfsViewName.NamedProperties.Put("FieldFlags", "294");
            this.dfsViewName.NamedProperties.Put("LovReference", "INTFACE_VIEWS");
            this.dfsViewName.NamedProperties.Put("ResizeableChildObject", "LLLL");
            this.dfsViewName.NamedProperties.Put("SqlColumn", "VIEW_NAME");
            this.dfsViewName.NamedProperties.Put("ValidateMethod", "");
            this.dfsViewName.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsViewName_WindowActions);
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
            // labeldfnGroupSeq
            // 
            resources.ApplyResources(this.labeldfnGroupSeq, "labeldfnGroupSeq");
            this.picTab.SetControlTabPages(this.labeldfnGroupSeq, "");
            this.labeldfnGroupSeq.Name = "labeldfnGroupSeq";
            // 
            // dfnGroupSeq
            // 
            this.picTab.SetControlTabPages(this.dfnGroupSeq, "");
            this.dfnGroupSeq.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfnGroupSeq, "dfnGroupSeq");
            this.dfnGroupSeq.Name = "dfnGroupSeq";
            this.dfnGroupSeq.NamedProperties.Put("EnumerateMethod", "");
            this.dfnGroupSeq.NamedProperties.Put("FieldFlags", "294");
            this.dfnGroupSeq.NamedProperties.Put("LovReference", "");
            this.dfnGroupSeq.NamedProperties.Put("ResizeableChildObject", "");
            this.dfnGroupSeq.NamedProperties.Put("SqlColumn", "OBJECT_SEQ");
            this.dfnGroupSeq.NamedProperties.Put("ValidateMethod", "");
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
            this.dfsDirection.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsDirection_WindowActions);
            // 
            // labelcmbsReplicationMode
            // 
            resources.ApplyResources(this.labelcmbsReplicationMode, "labelcmbsReplicationMode");
            this.labelcmbsReplicationMode.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labelcmbsReplicationMode, "Replication");
            this.labelcmbsReplicationMode.Name = "labelcmbsReplicationMode";
            // 
            // cmbsReplicationMode
            // 
            this.picTab.SetControlTabPages(this.cmbsReplicationMode, "Replication");
            resources.ApplyResources(this.cmbsReplicationMode, "cmbsReplicationMode");
            this.cmbsReplicationMode.Name = "cmbsReplicationMode";
            this.cmbsReplicationMode.NamedProperties.Put("EnumerateMethod", "INTFACE_MODE_API.ENUMERATE");
            this.cmbsReplicationMode.NamedProperties.Put("FieldFlags", "262");
            this.cmbsReplicationMode.NamedProperties.Put("LovReference", "");
            this.cmbsReplicationMode.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbsReplicationMode.NamedProperties.Put("SqlColumn", "REPLICATION_MODE");
            this.cmbsReplicationMode.NamedProperties.Put("ValidateMethod", "");
            this.cmbsReplicationMode.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbsReplicationMode_WindowActions);
            // 
            // gbCriteria
            // 
            this.gbCriteria.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.gbCriteria, "Replication");
            resources.ApplyResources(this.gbCriteria, "gbCriteria");
            this.gbCriteria.Name = "gbCriteria";
            this.gbCriteria.TabStop = false;
            // 
            // labelcmbsReplCriteria
            // 
            resources.ApplyResources(this.labelcmbsReplCriteria, "labelcmbsReplCriteria");
            this.labelcmbsReplCriteria.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labelcmbsReplCriteria, "Replication");
            this.labelcmbsReplCriteria.Name = "labelcmbsReplCriteria";
            // 
            // cmbsReplCriteria
            // 
            this.picTab.SetControlTabPages(this.cmbsReplCriteria, "Replication");
            resources.ApplyResources(this.cmbsReplCriteria, "cmbsReplCriteria");
            this.cmbsReplCriteria.Name = "cmbsReplCriteria";
            this.cmbsReplCriteria.NamedProperties.Put("EnumerateMethod", "INTFACE_REPLIC_CRITERIA_API.ENUMERATE");
            this.cmbsReplCriteria.NamedProperties.Put("FieldFlags", "294");
            this.cmbsReplCriteria.NamedProperties.Put("LovReference", "");
            this.cmbsReplCriteria.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbsReplCriteria.NamedProperties.Put("SqlColumn", "REPL_CRITERIA");
            this.cmbsReplCriteria.NamedProperties.Put("ValidateMethod", "");
            this.cmbsReplCriteria.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbsReplCriteria_WindowActions);
            // 
            // labeldfsFromValue
            // 
            resources.ApplyResources(this.labeldfsFromValue, "labeldfsFromValue");
            this.labeldfsFromValue.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeldfsFromValue, "Replication");
            this.labeldfsFromValue.Name = "labeldfsFromValue";
            // 
            // dfsFromValue
            // 
            this.dfsFromValue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.picTab.SetControlTabPages(this.dfsFromValue, "Replication");
            resources.ApplyResources(this.dfsFromValue, "dfsFromValue");
            this.dfsFromValue.Name = "dfsFromValue";
            this.dfsFromValue.NamedProperties.Put("EnumerateMethod", "");
            this.dfsFromValue.NamedProperties.Put("FieldFlags", "294");
            this.dfsFromValue.NamedProperties.Put("LovReference", "");
            this.dfsFromValue.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsFromValue.NamedProperties.Put("SqlColumn", "FROM_VALUE");
            this.dfsFromValue.NamedProperties.Put("ValidateMethod", "");
            this.dfsFromValue.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsFromValue_WindowActions);
            // 
            // labeldfsValueList
            // 
            resources.ApplyResources(this.labeldfsValueList, "labeldfsValueList");
            this.labeldfsValueList.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeldfsValueList, "Replication");
            this.labeldfsValueList.Name = "labeldfsValueList";
            // 
            // dfsValueList
            // 
            this.dfsValueList.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.picTab.SetControlTabPages(this.dfsValueList, "Replication");
            resources.ApplyResources(this.dfsValueList, "dfsValueList");
            this.dfsValueList.Name = "dfsValueList";
            this.dfsValueList.NamedProperties.Put("EnumerateMethod", "");
            this.dfsValueList.NamedProperties.Put("FieldFlags", "310");
            this.dfsValueList.NamedProperties.Put("LovReference", "");
            this.dfsValueList.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsValueList.NamedProperties.Put("SqlColumn", "VALUE_LIST");
            this.dfsValueList.NamedProperties.Put("ValidateMethod", "");
            // 
            // gbTrigger
            // 
            this.gbTrigger.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.gbTrigger, "Replication");
            resources.ApplyResources(this.gbTrigger, "gbTrigger");
            this.gbTrigger.Name = "gbTrigger";
            this.gbTrigger.TabStop = false;
            // 
            // labeldfsTableName
            // 
            resources.ApplyResources(this.labeldfsTableName, "labeldfsTableName");
            this.labeldfsTableName.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeldfsTableName, "Replication");
            this.labeldfsTableName.Name = "labeldfsTableName";
            // 
            // dfsTableName
            // 
            this.dfsTableName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.picTab.SetControlTabPages(this.dfsTableName, "Replication");
            resources.ApplyResources(this.dfsTableName, "dfsTableName");
            this.dfsTableName.Name = "dfsTableName";
            this.dfsTableName.NamedProperties.Put("EnumerateMethod", "");
            this.dfsTableName.NamedProperties.Put("FieldFlags", "262");
            this.dfsTableName.NamedProperties.Put("LovReference", "INTFACE_TABLE_NAME_LOV");
            this.dfsTableName.NamedProperties.Put("ResizeableChildObject", "LLLL");
            this.dfsTableName.NamedProperties.Put("SqlColumn", "TABLE_NAME");
            this.dfsTableName.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsTriggerWhen
            // 
            resources.ApplyResources(this.labeldfsTriggerWhen, "labeldfsTriggerWhen");
            this.labeldfsTriggerWhen.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeldfsTriggerWhen, "Replication");
            this.labeldfsTriggerWhen.Name = "labeldfsTriggerWhen";
            // 
            // dfsTriggerWhen
            // 
            this.picTab.SetControlTabPages(this.dfsTriggerWhen, "Replication");
            resources.ApplyResources(this.dfsTriggerWhen, "dfsTriggerWhen");
            this.dfsTriggerWhen.Name = "dfsTriggerWhen";
            this.dfsTriggerWhen.NamedProperties.Put("EnumerateMethod", "");
            this.dfsTriggerWhen.NamedProperties.Put("FieldFlags", "308");
            this.dfsTriggerWhen.NamedProperties.Put("LovReference", "");
            this.dfsTriggerWhen.NamedProperties.Put("ResizeableChildObject", "LLLL");
            this.dfsTriggerWhen.NamedProperties.Put("SqlColumn", "TRIGGER_WHEN");
            this.dfsTriggerWhen.NamedProperties.Put("ValidateMethod", "");
            // 
            // cbsEnabled
            // 
            this.cbsEnabled.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.cbsEnabled, "Replication");
            resources.ApplyResources(this.cbsEnabled, "cbsEnabled");
            this.cbsEnabled.Name = "cbsEnabled";
            this.cbsEnabled.NamedProperties.Put("DataType", "5");
            this.cbsEnabled.NamedProperties.Put("EnumerateMethod", "");
            this.cbsEnabled.NamedProperties.Put("FieldFlags", "294");
            this.cbsEnabled.NamedProperties.Put("LovReference", "");
            this.cbsEnabled.NamedProperties.Put("ResizeableChildObject", "");
            this.cbsEnabled.NamedProperties.Put("SqlColumn", "ENABLED");
            this.cbsEnabled.NamedProperties.Put("ValidateMethod", "");
            this.cbsEnabled.NamedProperties.Put("XDataLength", "5");
            this.cbsEnabled.UseVisualStyleBackColor = false;
            // 
            // cbOnInsert
            // 
            this.cbOnInsert.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.cbOnInsert, "Replication");
            resources.ApplyResources(this.cbOnInsert, "cbOnInsert");
            this.cbOnInsert.Name = "cbOnInsert";
            this.cbOnInsert.NamedProperties.Put("DataType", "5");
            this.cbOnInsert.NamedProperties.Put("EnumerateMethod", "");
            this.cbOnInsert.NamedProperties.Put("FieldFlags", "262");
            this.cbOnInsert.NamedProperties.Put("LovReference", "");
            this.cbOnInsert.NamedProperties.Put("ResizeableChildObject", "");
            this.cbOnInsert.NamedProperties.Put("SqlColumn", "ON_INSERT");
            this.cbOnInsert.NamedProperties.Put("ValidateMethod", "");
            this.cbOnInsert.NamedProperties.Put("XDataLength", "");
            this.cbOnInsert.UseVisualStyleBackColor = false;
            // 
            // cbOnUpdate
            // 
            this.cbOnUpdate.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.cbOnUpdate, "Replication");
            resources.ApplyResources(this.cbOnUpdate, "cbOnUpdate");
            this.cbOnUpdate.Name = "cbOnUpdate";
            this.cbOnUpdate.NamedProperties.Put("DataType", "5");
            this.cbOnUpdate.NamedProperties.Put("EnumerateMethod", "");
            this.cbOnUpdate.NamedProperties.Put("FieldFlags", "262");
            this.cbOnUpdate.NamedProperties.Put("LovReference", "");
            this.cbOnUpdate.NamedProperties.Put("ResizeableChildObject", "");
            this.cbOnUpdate.NamedProperties.Put("SqlColumn", "ON_UPDATE");
            this.cbOnUpdate.NamedProperties.Put("ValidateMethod", "");
            this.cbOnUpdate.NamedProperties.Put("XDataLength", "");
            this.cbOnUpdate.UseVisualStyleBackColor = false;
            // 
            // gbFile_Information
            // 
            this.gbFile_Information.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.gbFile_Information, "Format");
            resources.ApplyResources(this.gbFile_Information, "gbFile_Information");
            this.gbFile_Information.Name = "gbFile_Information";
            this.gbFile_Information.TabStop = false;
            // 
            // gbFile_Configuration
            // 
            this.gbFile_Configuration.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.gbFile_Configuration, "Format");
            resources.ApplyResources(this.gbFile_Configuration, "gbFile_Configuration");
            this.gbFile_Configuration.Name = "gbFile_Configuration";
            this.gbFile_Configuration.TabStop = false;
            // 
            // gbDatabase_Information
            // 
            this.gbDatabase_Information.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.gbDatabase_Information, "Format;Replication");
            resources.ApplyResources(this.gbDatabase_Information, "gbDatabase_Information");
            this.gbDatabase_Information.Name = "gbDatabase_Information";
            this.gbDatabase_Information.TabStop = false;
            // 
            // labeldfsIntfacePath
            // 
            resources.ApplyResources(this.labeldfsIntfacePath, "labeldfsIntfacePath");
            this.labeldfsIntfacePath.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeldfsIntfacePath, "Format");
            this.labeldfsIntfacePath.Name = "labeldfsIntfacePath";
            // 
            // dfsIntfacePath
            // 
            this.picTab.SetControlTabPages(this.dfsIntfacePath, "Format");
            resources.ApplyResources(this.dfsIntfacePath, "dfsIntfacePath");
            this.dfsIntfacePath.Name = "dfsIntfacePath";
            this.dfsIntfacePath.NamedProperties.Put("EnumerateMethod", "");
            this.dfsIntfacePath.NamedProperties.Put("FieldFlags", "294");
            this.dfsIntfacePath.NamedProperties.Put("LovReference", "INTFACE_SERVER_DIR_LOV");
            this.dfsIntfacePath.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsIntfacePath.NamedProperties.Put("SqlColumn", "INTFACE_PATH");
            this.dfsIntfacePath.NamedProperties.Put("ValidateMethod", "");
            this.dfsIntfacePath.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsIntfacePath_WindowActions);
            // 
            // labeldfsIntfaceFile
            // 
            resources.ApplyResources(this.labeldfsIntfaceFile, "labeldfsIntfaceFile");
            this.labeldfsIntfaceFile.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeldfsIntfaceFile, "Format");
            this.labeldfsIntfaceFile.Name = "labeldfsIntfaceFile";
            // 
            // dfsIntfaceFile
            // 
            this.picTab.SetControlTabPages(this.dfsIntfaceFile, "Format");
            resources.ApplyResources(this.dfsIntfaceFile, "dfsIntfaceFile");
            this.dfsIntfaceFile.Name = "dfsIntfaceFile";
            this.dfsIntfaceFile.NamedProperties.Put("EnumerateMethod", "");
            this.dfsIntfaceFile.NamedProperties.Put("FieldFlags", "294");
            this.dfsIntfaceFile.NamedProperties.Put("LovReference", "INTFACE_SERVER_FILES_LOV");
            this.dfsIntfaceFile.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsIntfaceFile.NamedProperties.Put("SqlColumn", "INTFACE_FILE");
            this.dfsIntfaceFile.NamedProperties.Put("ValidateMethod", "");
            // 
            // labelcmbFileLocation
            // 
            resources.ApplyResources(this.labelcmbFileLocation, "labelcmbFileLocation");
            this.labelcmbFileLocation.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labelcmbFileLocation, "Format");
            this.labelcmbFileLocation.Name = "labelcmbFileLocation";
            // 
            // cmbFileLocation
            // 
            this.picTab.SetControlTabPages(this.cmbFileLocation, "Format");
            resources.ApplyResources(this.cmbFileLocation, "cmbFileLocation");
            this.cmbFileLocation.Name = "cmbFileLocation";
            this.cmbFileLocation.NamedProperties.Put("EnumerateMethod", "INTFACE_FILE_LOCATION_API.Enumerate");
            this.cmbFileLocation.NamedProperties.Put("FieldFlags", "295");
            this.cmbFileLocation.NamedProperties.Put("LovReference", "");
            this.cmbFileLocation.NamedProperties.Put("SqlColumn", "FILE_LOCATION");
            // 
            // labeldfsDateFormat
            // 
            resources.ApplyResources(this.labeldfsDateFormat, "labeldfsDateFormat");
            this.labeldfsDateFormat.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeldfsDateFormat, "Format");
            this.labeldfsDateFormat.Name = "labeldfsDateFormat";
            // 
            // dfsDateFormat
            // 
            this.picTab.SetControlTabPages(this.dfsDateFormat, "Format");
            resources.ApplyResources(this.dfsDateFormat, "dfsDateFormat");
            this.dfsDateFormat.Name = "dfsDateFormat";
            this.dfsDateFormat.NamedProperties.Put("EnumerateMethod", "");
            this.dfsDateFormat.NamedProperties.Put("FieldFlags", "294");
            this.dfsDateFormat.NamedProperties.Put("LovReference", "");
            this.dfsDateFormat.NamedProperties.Put("SqlColumn", "DATE_FORMAT");
            // 
            // labelcmbColumnSeparator
            // 
            resources.ApplyResources(this.labelcmbColumnSeparator, "labelcmbColumnSeparator");
            this.labelcmbColumnSeparator.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labelcmbColumnSeparator, "Format");
            this.labelcmbColumnSeparator.Name = "labelcmbColumnSeparator";
            // 
            // cmbColumnSeparator
            // 
            this.picTab.SetControlTabPages(this.cmbColumnSeparator, "Format");
            resources.ApplyResources(this.cmbColumnSeparator, "cmbColumnSeparator");
            this.cmbColumnSeparator.Name = "cmbColumnSeparator";
            this.cmbColumnSeparator.NamedProperties.Put("EnumerateMethod", "INTFACE_FORMAT_CHAR_API.Enumerate");
            this.cmbColumnSeparator.NamedProperties.Put("FieldFlags", "294");
            this.cmbColumnSeparator.NamedProperties.Put("LovReference", "");
            this.cmbColumnSeparator.NamedProperties.Put("SqlColumn", "COLUMN_SEPARATOR");
            // 
            // labelcmbColumnEmbrace
            // 
            resources.ApplyResources(this.labelcmbColumnEmbrace, "labelcmbColumnEmbrace");
            this.labelcmbColumnEmbrace.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labelcmbColumnEmbrace, "Format");
            this.labelcmbColumnEmbrace.Name = "labelcmbColumnEmbrace";
            // 
            // cmbColumnEmbrace
            // 
            this.picTab.SetControlTabPages(this.cmbColumnEmbrace, "Format");
            resources.ApplyResources(this.cmbColumnEmbrace, "cmbColumnEmbrace");
            this.cmbColumnEmbrace.Name = "cmbColumnEmbrace";
            this.cmbColumnEmbrace.NamedProperties.Put("EnumerateMethod", "INTFACE_FORMAT_CHAR_API.Enumerate");
            this.cmbColumnEmbrace.NamedProperties.Put("FieldFlags", "294");
            this.cmbColumnEmbrace.NamedProperties.Put("LovReference", "");
            this.cmbColumnEmbrace.NamedProperties.Put("SqlColumn", "COLUMN_EMBRACE");
            // 
            // labelcmbDecimalPoint
            // 
            resources.ApplyResources(this.labelcmbDecimalPoint, "labelcmbDecimalPoint");
            this.labelcmbDecimalPoint.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labelcmbDecimalPoint, "Format");
            this.labelcmbDecimalPoint.Name = "labelcmbDecimalPoint";
            // 
            // cmbDecimalPoint
            // 
            this.picTab.SetControlTabPages(this.cmbDecimalPoint, "Format");
            resources.ApplyResources(this.cmbDecimalPoint, "cmbDecimalPoint");
            this.cmbDecimalPoint.Name = "cmbDecimalPoint";
            this.cmbDecimalPoint.NamedProperties.Put("EnumerateMethod", "INTFACE_FORMAT_CHAR_API.Enumerate");
            this.cmbDecimalPoint.NamedProperties.Put("FieldFlags", "294");
            this.cmbDecimalPoint.NamedProperties.Put("LovReference", "");
            this.cmbDecimalPoint.NamedProperties.Put("SqlColumn", "DECIMAL_POINT");
            // 
            // labelcmbThousandSeparator
            // 
            resources.ApplyResources(this.labelcmbThousandSeparator, "labelcmbThousandSeparator");
            this.labelcmbThousandSeparator.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labelcmbThousandSeparator, "Format");
            this.labelcmbThousandSeparator.Name = "labelcmbThousandSeparator";
            // 
            // cmbThousandSeparator
            // 
            this.picTab.SetControlTabPages(this.cmbThousandSeparator, "Format");
            resources.ApplyResources(this.cmbThousandSeparator, "cmbThousandSeparator");
            this.cmbThousandSeparator.Name = "cmbThousandSeparator";
            this.cmbThousandSeparator.NamedProperties.Put("EnumerateMethod", "INTFACE_FORMAT_CHAR_API.Enumerate");
            this.cmbThousandSeparator.NamedProperties.Put("FieldFlags", "294");
            this.cmbThousandSeparator.NamedProperties.Put("LovReference", "");
            this.cmbThousandSeparator.NamedProperties.Put("SqlColumn", "THOUSAND_SEPARATOR");
            // 
            // labeldfnMinusPos
            // 
            resources.ApplyResources(this.labeldfnMinusPos, "labeldfnMinusPos");
            this.labeldfnMinusPos.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeldfnMinusPos, "Format");
            this.labeldfnMinusPos.Name = "labeldfnMinusPos";
            // 
            // dfnMinusPos
            // 
            this.picTab.SetControlTabPages(this.dfnMinusPos, "Format");
            this.dfnMinusPos.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfnMinusPos, "dfnMinusPos");
            this.dfnMinusPos.Name = "dfnMinusPos";
            this.dfnMinusPos.NamedProperties.Put("EnumerateMethod", "");
            this.dfnMinusPos.NamedProperties.Put("FieldFlags", "294");
            this.dfnMinusPos.NamedProperties.Put("LovReference", "");
            this.dfnMinusPos.NamedProperties.Put("SqlColumn", "MINUS_POS");
            // 
            // labeldfsSourceName
            // 
            resources.ApplyResources(this.labeldfsSourceName, "labeldfsSourceName");
            this.labeldfsSourceName.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeldfsSourceName, "Format;Replication");
            this.labeldfsSourceName.Name = "labeldfsSourceName";
            // 
            // dfsSourceName
            // 
            this.dfsSourceName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.picTab.SetControlTabPages(this.dfsSourceName, "Format;Replication");
            resources.ApplyResources(this.dfsSourceName, "dfsSourceName");
            this.dfsSourceName.Name = "dfsSourceName";
            this.dfsSourceName.NamedProperties.Put("EnumerateMethod", "");
            this.dfsSourceName.NamedProperties.Put("FieldFlags", "310");
            this.dfsSourceName.NamedProperties.Put("LovReference", "");
            this.dfsSourceName.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsSourceName.NamedProperties.Put("SqlColumn", "SOURCE_NAME");
            this.dfsSourceName.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsSourceOwner
            // 
            resources.ApplyResources(this.labeldfsSourceOwner, "labeldfsSourceOwner");
            this.labeldfsSourceOwner.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeldfsSourceOwner, "Format;Replication");
            this.labeldfsSourceOwner.Name = "labeldfsSourceOwner";
            // 
            // dfsSourceOwner
            // 
            this.dfsSourceOwner.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.picTab.SetControlTabPages(this.dfsSourceOwner, "Format;Replication");
            resources.ApplyResources(this.dfsSourceOwner, "dfsSourceOwner");
            this.dfsSourceOwner.Name = "dfsSourceOwner";
            this.dfsSourceOwner.NamedProperties.Put("EnumerateMethod", "");
            this.dfsSourceOwner.NamedProperties.Put("FieldFlags", "294");
            this.dfsSourceOwner.NamedProperties.Put("LovReference", "");
            this.dfsSourceOwner.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsSourceOwner.NamedProperties.Put("SqlColumn", "SOURCE_OWNER");
            this.dfsSourceOwner.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsWhereClause
            // 
            resources.ApplyResources(this.labeldfsWhereClause, "labeldfsWhereClause");
            this.labeldfsWhereClause.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeldfsWhereClause, "Format;Replication");
            this.labeldfsWhereClause.Name = "labeldfsWhereClause";
            // 
            // dfsWhereClause
            // 
            this.picTab.SetControlTabPages(this.dfsWhereClause, "Format;Replication");
            resources.ApplyResources(this.dfsWhereClause, "dfsWhereClause");
            this.dfsWhereClause.Name = "dfsWhereClause";
            this.dfsWhereClause.NamedProperties.Put("EnumerateMethod", "");
            this.dfsWhereClause.NamedProperties.Put("FieldFlags", "310");
            this.dfsWhereClause.NamedProperties.Put("LovReference", "");
            this.dfsWhereClause.NamedProperties.Put("ResizeableChildObject", "LLLL");
            this.dfsWhereClause.NamedProperties.Put("SqlColumn", "WHERE_CLAUSE");
            this.dfsWhereClause.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsOrderByClause
            // 
            resources.ApplyResources(this.labeldfsOrderByClause, "labeldfsOrderByClause");
            this.labeldfsOrderByClause.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeldfsOrderByClause, "Format;Replication");
            this.labeldfsOrderByClause.Name = "labeldfsOrderByClause";
            // 
            // dfsOrderByClause
            // 
            this.picTab.SetControlTabPages(this.dfsOrderByClause, "Format;Replication");
            resources.ApplyResources(this.dfsOrderByClause, "dfsOrderByClause");
            this.dfsOrderByClause.Name = "dfsOrderByClause";
            this.dfsOrderByClause.NamedProperties.Put("EnumerateMethod", "");
            this.dfsOrderByClause.NamedProperties.Put("FieldFlags", "310");
            this.dfsOrderByClause.NamedProperties.Put("LovReference", "");
            this.dfsOrderByClause.NamedProperties.Put("ResizeableChildObject", "LLLL");
            this.dfsOrderByClause.NamedProperties.Put("SqlColumn", "ORDER_BY_CLAUSE");
            this.dfsOrderByClause.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsGroupByClause
            // 
            resources.ApplyResources(this.labeldfsGroupByClause, "labeldfsGroupByClause");
            this.labeldfsGroupByClause.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeldfsGroupByClause, "Format;Replication");
            this.labeldfsGroupByClause.Name = "labeldfsGroupByClause";
            // 
            // dfsGroupByClause
            // 
            this.picTab.SetControlTabPages(this.dfsGroupByClause, "Format;Replication");
            resources.ApplyResources(this.dfsGroupByClause, "dfsGroupByClause");
            this.dfsGroupByClause.Name = "dfsGroupByClause";
            this.dfsGroupByClause.NamedProperties.Put("EnumerateMethod", "");
            this.dfsGroupByClause.NamedProperties.Put("FieldFlags", "310");
            this.dfsGroupByClause.NamedProperties.Put("LovReference", "");
            this.dfsGroupByClause.NamedProperties.Put("ResizeableChildObject", "LLLL");
            this.dfsGroupByClause.NamedProperties.Put("SqlColumn", "GROUP_BY_CLAUSE");
            this.dfsGroupByClause.NamedProperties.Put("ValidateMethod", "");
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
            // labeldfsLastInfo
            // 
            resources.ApplyResources(this.labeldfsLastInfo, "labeldfsLastInfo");
            this.labeldfsLastInfo.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeldfsLastInfo, "Format;Replication");
            this.labeldfsLastInfo.Name = "labeldfsLastInfo";
            // 
            // dfsLastInfo
            // 
            this.picTab.SetControlTabPages(this.dfsLastInfo, "Format;Replication");
            resources.ApplyResources(this.dfsLastInfo, "dfsLastInfo");
            this.dfsLastInfo.Name = "dfsLastInfo";
            this.dfsLastInfo.NamedProperties.Put("EnumerateMethod", "");
            this.dfsLastInfo.NamedProperties.Put("FieldFlags", "306");
            this.dfsLastInfo.NamedProperties.Put("LovReference", "");
            this.dfsLastInfo.NamedProperties.Put("ResizeableChildObject", "LLLL");
            this.dfsLastInfo.NamedProperties.Put("SqlColumn", "LAST_INFO");
            this.dfsLastInfo.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldf23
            // 
            resources.ApplyResources(this.labeldf23, "labeldf23");
            this.labeldf23.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeldf23, "Format");
            this.labeldf23.Name = "labeldf23";
            // 
            // df23
            // 
            this.df23.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.picTab.SetControlTabPages(this.df23, "Format");
            resources.ApplyResources(this.df23, "df23");
            this.df23.Name = "df23";
            this.df23.NamedProperties.Put("EnumerateMethod", "");
            this.df23.NamedProperties.Put("FieldFlags", "294");
            this.df23.NamedProperties.Put("LovReference", "INTFACE_CHARACTERSET_LOV");
            this.df23.NamedProperties.Put("ResizeableChildObject", "");
            this.df23.NamedProperties.Put("SqlColumn", "CHAR_SET");
            this.df23.NamedProperties.Put("ValidateMethod", "");
            // 
            // dfsNewName
            // 
            this.picTab.SetControlTabPages(this.dfsNewName, "");
            this.dfsNewName.Name = "dfsNewName";
            resources.ApplyResources(this.dfsNewName, "dfsNewName");
            // 
            // menuFrmMethods
            // 
            this.picTab.SetControlTabPages(this.menuFrmMethods, "");
            this.menuFrmMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_Query,
            this.menuItem_Copy,
            this.menuItem_Show,
            this.menuItem_Server,
            this.menuItem_Schedule,
            this.menuItem_Translation,
            this.menuItem_Exec_Job,
            this.menuItem_History});
            this.menuFrmMethods.Name = "menuFrmMethods";
            resources.ApplyResources(this.menuFrmMethods, "menuFrmMethods");
            // 
            // menuItem_Query
            // 
            this.menuItem_Query.Command = this.menuFrmMethods_menuQ_uery_Source_Columns;
            this.menuItem_Query.Name = "menuItem_Query";
            resources.ApplyResources(this.menuItem_Query, "menuItem_Query");
            this.menuItem_Query.Text = "Q&uery Source Columns";
            // 
            // menuItem_Copy
            // 
            this.menuItem_Copy.Command = this.menuFrmMethods_menuCopy__Migration_Job;
            this.menuItem_Copy.Name = "menuItem_Copy";
            resources.ApplyResources(this.menuItem_Copy, "menuItem_Copy");
            this.menuItem_Copy.Text = "Copy &Migration Job";
            // 
            // menuItem_Show
            // 
            this.menuItem_Show.Command = this.menuFrmMethods_menuSho_w_Select_Statement;
            this.menuItem_Show.Name = "menuItem_Show";
            resources.ApplyResources(this.menuItem_Show, "menuItem_Show");
            this.menuItem_Show.Text = "Sho&w Select Statement";
            // 
            // menuItem_Server
            // 
            this.menuItem_Server.Command = this.menuFrmMethods_menuSer_ver_Processes___;
            this.menuItem_Server.Name = "menuItem_Server";
            resources.ApplyResources(this.menuItem_Server, "menuItem_Server");
            this.menuItem_Server.Text = "S&cheduled Migration Jobs...";
            // 
            // menuItem_Schedule
            // 
            this.menuItem_Schedule.Command = this.menuFrmMethods_menuSchedule_Job;
            this.menuItem_Schedule.Name = "menuItem_Schedule";
            resources.ApplyResources(this.menuItem_Schedule, "menuItem_Schedule");
            this.menuItem_Schedule.Text = "Schedule Job";
            // 
            // menuItem_Translation
            // 
            this.menuItem_Translation.Command = this.menuFrmMethods_menuTranslation;
            this.menuItem_Translation.Name = "menuItem_Translation";
            resources.ApplyResources(this.menuItem_Translation, "menuItem_Translation");
            this.menuItem_Translation.Text = "&Translation...";
            // 
            // menuFrmMethods_menuTranslation
            // 
            resources.ApplyResources(this.menuFrmMethods_menuTranslation, "menuFrmMethods_menuTranslation");
            this.menuFrmMethods_menuTranslation.Name = "menuFrmMethods_menuTranslation";
            this.menuFrmMethods_menuTranslation.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuFrmMethods_menuTranslation_Execute);
            this.menuFrmMethods_menuTranslation.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuFrmMethods_menuTranslation_Inquire);
            // 
            // menuItem_Exec_Job
            // 
            this.menuItem_Exec_Job.Command = this.menuFrmMethods_menuExecJob;
            this.menuItem_Exec_Job.Name = "menuItem_Exec_Job";
            resources.ApplyResources(this.menuItem_Exec_Job, "menuItem_Exec_Job");
            this.menuItem_Exec_Job.Text = "&Start Job...";
            // 
            // menuFrmMethods_menuExecJob
            // 
            resources.ApplyResources(this.menuFrmMethods_menuExecJob, "menuFrmMethods_menuExecJob");
            this.menuFrmMethods_menuExecJob.Name = "menuFrmMethods_menuExecJob";
            this.menuFrmMethods_menuExecJob.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuFrmMethods_menuExecJob_Execute);
            this.menuFrmMethods_menuExecJob.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuFrmMethods_menuExecJob_Inquire);
            // 
            // menuItem_History
            // 
            this.menuItem_History.Command = this.menuFrmMethods_menuHistory;
            this.menuItem_History.Name = "menuItem_History";
            resources.ApplyResources(this.menuItem_History, "menuItem_History");
            this.menuItem_History.Text = "Migration Job &History...";
            // 
            // menuFrmMethods_menuHistory
            // 
            resources.ApplyResources(this.menuFrmMethods_menuHistory, "menuFrmMethods_menuHistory");
            this.menuFrmMethods_menuHistory.Name = "menuFrmMethods_menuHistory";
            this.menuFrmMethods_menuHistory.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuFrmMethods_menuHistory_Execute);
            this.menuFrmMethods_menuHistory.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuFrmMethods_menuHistory_Inquire);
            // 
            // frmIntfaceHeader
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.dfsNewName);
            this.Controls.Add(this.df23);
            this.Controls.Add(this.dfsLastInfo);
            this.Controls.Add(this.dflsHiddenSqlStatement);
            this.Controls.Add(this.dfsGroupByClause);
            this.Controls.Add(this.dfsOrderByClause);
            this.Controls.Add(this.dfsWhereClause);
            this.Controls.Add(this.dfsSourceOwner);
            this.Controls.Add(this.dfsSourceName);
            this.Controls.Add(this.dfnMinusPos);
            this.Controls.Add(this.cmbThousandSeparator);
            this.Controls.Add(this.cmbDecimalPoint);
            this.Controls.Add(this.cmbColumnEmbrace);
            this.Controls.Add(this.cmbColumnSeparator);
            this.Controls.Add(this.dfsDateFormat);
            this.Controls.Add(this.cmbFileLocation);
            this.Controls.Add(this.dfsIntfaceFile);
            this.Controls.Add(this.dfsIntfacePath);
            this.Controls.Add(this.dfsTriggerWhen);
            this.Controls.Add(this.dfsTableName);
            this.Controls.Add(this.dfsValueList);
            this.Controls.Add(this.dfsFromValue);
            this.Controls.Add(this.dfsDirection);
            this.Controls.Add(this.dfnGroupSeq);
            this.Controls.Add(this.dfsNoteText);
            this.Controls.Add(this.dfsGroupId);
            this.Controls.Add(this.dfsViewName);
            this.Controls.Add(this.dfsProcedureName);
            this.Controls.Add(this.dfsDescription);
            this.Controls.Add(this.ecmbIntfaceName);
            this.Controls.Add(this.cmbsReplicationMode);
            this.Controls.Add(this.cmbsReplCriteria);
            this.Controls.Add(this.cbsEnabled);
            this.Controls.Add(this.cbOnInsert);
            this.Controls.Add(this.cbOnUpdate);
            this.Controls.Add(this.labeldf23);
            this.Controls.Add(this.labeldfsLastInfo);
            this.Controls.Add(this.labeldfsGroupByClause);
            this.Controls.Add(this.labeldfsOrderByClause);
            this.Controls.Add(this.labeldfsWhereClause);
            this.Controls.Add(this.labeldfsSourceOwner);
            this.Controls.Add(this.labeldfsSourceName);
            this.Controls.Add(this.labeldfnMinusPos);
            this.Controls.Add(this.labelcmbThousandSeparator);
            this.Controls.Add(this.labelcmbDecimalPoint);
            this.Controls.Add(this.labelcmbColumnEmbrace);
            this.Controls.Add(this.labelcmbColumnSeparator);
            this.Controls.Add(this.labeldfsDateFormat);
            this.Controls.Add(this.labelcmbFileLocation);
            this.Controls.Add(this.labeldfsIntfaceFile);
            this.Controls.Add(this.labeldfsIntfacePath);
            this.Controls.Add(this.labelcmbsReplicationMode);
            this.Controls.Add(this.labelcmbsReplCriteria);
            this.Controls.Add(this.labeldfsFromValue);
            this.Controls.Add(this.labeldfsValueList);
            this.Controls.Add(this.labeldfsTableName);
            this.Controls.Add(this.labeldfsTriggerWhen);
            this.Controls.Add(this.labeldfsDirection);
            this.Controls.Add(this.labeldfnGroupSeq);
            this.Controls.Add(this.labeldfsNoteText);
            this.Controls.Add(this.labeldfsGroupId);
            this.Controls.Add(this.labeldfsViewName);
            this.Controls.Add(this.labeldfsProcedureName);
            this.Controls.Add(this.labeldfsDescription);
            this.Controls.Add(this.labelecmbIntfaceName);
            this.Controls.Add(this.gbDatabase_Information);
            this.Controls.Add(this.gbFile_Configuration);
            this.Controls.Add(this.gbFile_Information);
            this.Controls.Add(this.gbTrigger);
            this.Controls.Add(this.gbCriteria);
            this.Name = "frmIntfaceHeader";
            this.NamedProperties.Put("DefaultOrderBy", "INTFACE_NAME");
            this.NamedProperties.Put("DefaultWhere", @"&AO.Intface_User_API.Get_Privilege(&AO.Fnd_Session_API.Get_FND_User) = &AO.Intface_Privilege_API.Get_Client_Value(1) 
AND procedure_name in (select procedure_name from &AO.INTFACE_PROC_LOV_EXCL_REPL)  AND nvl(&AO.Intface_Group_API.Get_Hide_Flag(GROUP_ID),'FALSE') = 'FALSE' AND INTFACE_NAME IN (SELECT INTFACE_NAME FROM &AO.INTFACE_ALLOWED_JOBS)");
            this.NamedProperties.Put("LogicalUnit", "IntfaceHeader");
            this.NamedProperties.Put("PackageName", "INTFACE_HEADER_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "4545");
            this.NamedProperties.Put("ViewName", "INTFACE_HEADER");
            this.NamedProperties.Put("Warnings", "TRUE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.frmIntfaceHeader_WindowActions);
            this.Controls.SetChildIndex(this.gbCriteria, 0);
            this.Controls.SetChildIndex(this.gbTrigger, 0);
            this.Controls.SetChildIndex(this.picTab, 0);
            this.Controls.SetChildIndex(this.gbFile_Information, 0);
            this.Controls.SetChildIndex(this.gbFile_Configuration, 0);
            this.Controls.SetChildIndex(this.gbDatabase_Information, 0);
            this.Controls.SetChildIndex(this.labelecmbIntfaceName, 0);
            this.Controls.SetChildIndex(this.labeldfsDescription, 0);
            this.Controls.SetChildIndex(this.labeldfsProcedureName, 0);
            this.Controls.SetChildIndex(this.labeldfsViewName, 0);
            this.Controls.SetChildIndex(this.labeldfsGroupId, 0);
            this.Controls.SetChildIndex(this.labeldfsNoteText, 0);
            this.Controls.SetChildIndex(this.labeldfnGroupSeq, 0);
            this.Controls.SetChildIndex(this.labeldfsDirection, 0);
            this.Controls.SetChildIndex(this.labeldfsTriggerWhen, 0);
            this.Controls.SetChildIndex(this.labeldfsTableName, 0);
            this.Controls.SetChildIndex(this.labeldfsValueList, 0);
            this.Controls.SetChildIndex(this.labeldfsFromValue, 0);
            this.Controls.SetChildIndex(this.labelcmbsReplCriteria, 0);
            this.Controls.SetChildIndex(this.labelcmbsReplicationMode, 0);
            this.Controls.SetChildIndex(this.labeldfsIntfacePath, 0);
            this.Controls.SetChildIndex(this.labeldfsIntfaceFile, 0);
            this.Controls.SetChildIndex(this.labelcmbFileLocation, 0);
            this.Controls.SetChildIndex(this.labeldfsDateFormat, 0);
            this.Controls.SetChildIndex(this.labelcmbColumnSeparator, 0);
            this.Controls.SetChildIndex(this.labelcmbColumnEmbrace, 0);
            this.Controls.SetChildIndex(this.labelcmbDecimalPoint, 0);
            this.Controls.SetChildIndex(this.labelcmbThousandSeparator, 0);
            this.Controls.SetChildIndex(this.labeldfnMinusPos, 0);
            this.Controls.SetChildIndex(this.labeldfsSourceName, 0);
            this.Controls.SetChildIndex(this.labeldfsSourceOwner, 0);
            this.Controls.SetChildIndex(this.labeldfsWhereClause, 0);
            this.Controls.SetChildIndex(this.labeldfsOrderByClause, 0);
            this.Controls.SetChildIndex(this.labeldfsGroupByClause, 0);
            this.Controls.SetChildIndex(this.labeldfsLastInfo, 0);
            this.Controls.SetChildIndex(this.labeldf23, 0);
            this.Controls.SetChildIndex(this.cbOnUpdate, 0);
            this.Controls.SetChildIndex(this.cbOnInsert, 0);
            this.Controls.SetChildIndex(this.cbsEnabled, 0);
            this.Controls.SetChildIndex(this.cmbsReplCriteria, 0);
            this.Controls.SetChildIndex(this.cmbsReplicationMode, 0);
            this.Controls.SetChildIndex(this.ecmbIntfaceName, 0);
            this.Controls.SetChildIndex(this.dfsDescription, 0);
            this.Controls.SetChildIndex(this.dfsProcedureName, 0);
            this.Controls.SetChildIndex(this.dfsViewName, 0);
            this.Controls.SetChildIndex(this.dfsGroupId, 0);
            this.Controls.SetChildIndex(this.dfsNoteText, 0);
            this.Controls.SetChildIndex(this.dfnGroupSeq, 0);
            this.Controls.SetChildIndex(this.dfsDirection, 0);
            this.Controls.SetChildIndex(this.dfsFromValue, 0);
            this.Controls.SetChildIndex(this.dfsValueList, 0);
            this.Controls.SetChildIndex(this.dfsTableName, 0);
            this.Controls.SetChildIndex(this.dfsTriggerWhen, 0);
            this.Controls.SetChildIndex(this.dfsIntfacePath, 0);
            this.Controls.SetChildIndex(this.dfsIntfaceFile, 0);
            this.Controls.SetChildIndex(this.cmbFileLocation, 0);
            this.Controls.SetChildIndex(this.dfsDateFormat, 0);
            this.Controls.SetChildIndex(this.cmbColumnSeparator, 0);
            this.Controls.SetChildIndex(this.cmbColumnEmbrace, 0);
            this.Controls.SetChildIndex(this.cmbDecimalPoint, 0);
            this.Controls.SetChildIndex(this.cmbThousandSeparator, 0);
            this.Controls.SetChildIndex(this.dfnMinusPos, 0);
            this.Controls.SetChildIndex(this.dfsSourceName, 0);
            this.Controls.SetChildIndex(this.dfsSourceOwner, 0);
            this.Controls.SetChildIndex(this.dfsWhereClause, 0);
            this.Controls.SetChildIndex(this.dfsOrderByClause, 0);
            this.Controls.SetChildIndex(this.dfsGroupByClause, 0);
            this.Controls.SetChildIndex(this.dflsHiddenSqlStatement, 0);
            this.Controls.SetChildIndex(this.dfsLastInfo, 0);
            this.Controls.SetChildIndex(this.df23, 0);
            this.Controls.SetChildIndex(this.dfsNewName, 0);
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

        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menuQ_uery_Source_Columns;
        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menuCopy__Migration_Job;
        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menuSho_w_Select_Statement;
        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menuSer_ver_Processes___;
        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menuSchedule_Job;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuFrmMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Query;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Copy;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Show;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Server;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Schedule;
        protected Fnd.Windows.Forms.FndCommand menuFrmMethods_menuTranslation;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Translation;
        protected Fnd.Windows.Forms.FndCommand menuFrmMethods_menuExecJob;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Exec_Job;
        protected Fnd.Windows.Forms.FndCommand menuFrmMethods_menuHistory;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_History;
	}
}
