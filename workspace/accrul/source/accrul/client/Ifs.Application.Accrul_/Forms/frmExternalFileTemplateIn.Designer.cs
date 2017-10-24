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
using Ifs.Application.Accrul;
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
	
	public partial class frmExternalFileTemplateIn
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		// Bug 71319, Begin.
		public cDataField dfsFileTemplateId;
		public cComboBox cmbFileDirection;
		protected SalGroupBox gbFile_Unpack_Options;
		public cCheckBoxFin cbLogInvalidLines;
		public cCheckBoxFin cbLogSkippedLines;
		public cCheckBoxFin cbAbortImmediatly;
		protected SalGroupBox gbProcessing_Options;
		// Bug 71319, Begin.
		public cCheckBoxFin cbSkipAllBlanks;
		// Bug 71319, Begin.
		public cCheckBoxFin cbSkipInitialBlanks;
		protected SalGroupBox gbFile_Name_Path_Options;
		protected cBackgroundText labeldfsFileName;
		// Bug 79498 Increased length to 259
		// Bug 79498 Begin
		public cDataField dfsFileName;
		protected cBackgroundText labeldfsLoadFileTypeList;
		// Bug 71319, Begin.
		public cDataField dfsLoadFileTypeList;
		protected cBackgroundText labeldfsInputFilePath;
		// Bug 79498 Increased length to 259
		// Bug 79498 Begin
		public cDataField dfsInputFilePath;
		protected cBackgroundText labeldfsInputFilePathServer;
		// Bug 79498 Increased length to 259
		// Bug 79498 Begin
		public cDataField dfsInputFilePathServer;
		protected cBackgroundText labeldfsBackupFilePath;
		// Bug 79498 Increased length to 259
		// Bug 79498 Begin
		public cDataField dfsBackupFilePath;
		protected cBackgroundText labeldfsBackupFilePathServer;
		// Bug 79498 Increased length to 259
		// Bug 79498 Begin
		public cDataField dfsBackupFilePathServer;
		protected cBackgroundText labeldfsCharacterSet;
		public cDataField dfsCharacterSet;
		protected SalGroupBox gbRemove_Transaction_Options;
		protected cBackgroundText labeldfnRemoveDays;
		public cDataField dfnRemoveDays;
		public cCheckBox cbRemoveComplete;
		protected SalGroupBox gbRecord_Handling_Options;
		// Bug 71319, Begin.
		public cCheckBoxFin cbAllowRecordSetRepeat;
		// Bug 71319, Begin.
		public cCheckBoxFin cbAllowOneRecordSetOnly;
		public cCheckBoxFin cbSystemDefined;
		protected cBackgroundText labeldfsApiToCall;
		// Bug 71319, Begin.
		public cDataField dfsApiToCall;
		protected cBackgroundText labeldfsApiToCallUnpBefore;
		// Bug 71319, Begin.
		public cDataField dfsApiToCallUnpBefore;
		protected cBackgroundText labeldfsApiToCallUnpAfter;
		// Bug 71319, Begin.
		public cDataField dfsApiToCallUnpAfter;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExternalFileTemplateIn));
            this.menuFrmMethods_menuExternal_File_Template_C_ontrol_ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.dfsFileTemplateId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.cmbFileDirection = new Ifs.Fnd.ApplicationForms.cComboBox();
            this.gbFile_Unpack_Options = new PPJ.Runtime.Windows.SalGroupBox();
            this.gbProcessing_Options = new PPJ.Runtime.Windows.SalGroupBox();
            this.gbFile_Name_Path_Options = new PPJ.Runtime.Windows.SalGroupBox();
            this.labeldfsFileName = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsFileName = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsLoadFileTypeList = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsLoadFileTypeList = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsInputFilePath = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsInputFilePath = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsInputFilePathServer = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsInputFilePathServer = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsBackupFilePath = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsBackupFilePath = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsBackupFilePathServer = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsBackupFilePathServer = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsCharacterSet = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsCharacterSet = new Ifs.Fnd.ApplicationForms.cDataField();
            this.gbRemove_Transaction_Options = new PPJ.Runtime.Windows.SalGroupBox();
            this.labeldfnRemoveDays = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfnRemoveDays = new Ifs.Fnd.ApplicationForms.cDataField();
            this.cbRemoveComplete = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.gbRecord_Handling_Options = new PPJ.Runtime.Windows.SalGroupBox();
            this.labeldfsApiToCall = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsApiToCall = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsApiToCallUnpBefore = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsApiToCallUnpBefore = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsApiToCallUnpAfter = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsApiToCallUnpAfter = new Ifs.Fnd.ApplicationForms.cDataField();
            this.menuFrmMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_External = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.cbSystemDefined = new Ifs.Application.Accrul.cCheckBoxFin();
            this.cbAllowOneRecordSetOnly = new Ifs.Application.Accrul.cCheckBoxFin();
            this.cbAllowRecordSetRepeat = new Ifs.Application.Accrul.cCheckBoxFin();
            this.cbSkipInitialBlanks = new Ifs.Application.Accrul.cCheckBoxFin();
            this.cbSkipAllBlanks = new Ifs.Application.Accrul.cCheckBoxFin();
            this.cbAbortImmediatly = new Ifs.Application.Accrul.cCheckBoxFin();
            this.cbLogSkippedLines = new Ifs.Application.Accrul.cCheckBoxFin();
            this.cbLogInvalidLines = new Ifs.Application.Accrul.cCheckBoxFin();
            this.menuFrmMethods.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuFrmMethods_menuExternal_File_Template_C_ontrol_);
            this.commandManager.ContextMenus.Add(this.menuFrmMethods);
            // 
            // menuFrmMethods_menuExternal_File_Template_C_ontrol_
            // 
            resources.ApplyResources(this.menuFrmMethods_menuExternal_File_Template_C_ontrol_, "menuFrmMethods_menuExternal_File_Template_C_ontrol_");
            this.menuFrmMethods_menuExternal_File_Template_C_ontrol_.Name = "menuFrmMethods_menuExternal_File_Template_C_ontrol_";
            this.menuFrmMethods_menuExternal_File_Template_C_ontrol_.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_External_Execute);
            this.menuFrmMethods_menuExternal_File_Template_C_ontrol_.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_External_Inquire);
            // 
            // dfsFileTemplateId
            // 
            resources.ApplyResources(this.dfsFileTemplateId, "dfsFileTemplateId");
            this.dfsFileTemplateId.Name = "dfsFileTemplateId";
            this.dfsFileTemplateId.NamedProperties.Put("EnumerateMethod", "");
            this.dfsFileTemplateId.NamedProperties.Put("FieldFlags", "67");
            this.dfsFileTemplateId.NamedProperties.Put("LovReference", "EXT_FILE_TEMPLATE");
            this.dfsFileTemplateId.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsFileTemplateId.NamedProperties.Put("SqlColumn", "FILE_TEMPLATE_ID");
            this.dfsFileTemplateId.NamedProperties.Put("ValidateMethod", "");
            this.dfsFileTemplateId.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsFileTemplateId_WindowActions);
            // 
            // cmbFileDirection
            // 
            resources.ApplyResources(this.cmbFileDirection, "cmbFileDirection");
            this.cmbFileDirection.Name = "cmbFileDirection";
            this.cmbFileDirection.NamedProperties.Put("EnumerateMethod", "FILE_DIRECTION_API.Enumerate");
            this.cmbFileDirection.NamedProperties.Put("FieldFlags", "135");
            this.cmbFileDirection.NamedProperties.Put("LovReference", "");
            this.cmbFileDirection.NamedProperties.Put("SqlColumn", "FILE_DIRECTION");
            this.cmbFileDirection.NamedProperties.Put("ValidateMethod", "");
            this.cmbFileDirection.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbFileDirection_WindowActions);
            // 
            // gbFile_Unpack_Options
            // 
            resources.ApplyResources(this.gbFile_Unpack_Options, "gbFile_Unpack_Options");
            this.gbFile_Unpack_Options.Name = "gbFile_Unpack_Options";
            this.gbFile_Unpack_Options.TabStop = false;
            // 
            // gbProcessing_Options
            // 
            resources.ApplyResources(this.gbProcessing_Options, "gbProcessing_Options");
            this.gbProcessing_Options.Name = "gbProcessing_Options";
            this.gbProcessing_Options.TabStop = false;
            // 
            // gbFile_Name_Path_Options
            // 
            resources.ApplyResources(this.gbFile_Name_Path_Options, "gbFile_Name_Path_Options");
            this.gbFile_Name_Path_Options.Name = "gbFile_Name_Path_Options";
            this.gbFile_Name_Path_Options.TabStop = false;
            // 
            // labeldfsFileName
            // 
            resources.ApplyResources(this.labeldfsFileName, "labeldfsFileName");
            this.labeldfsFileName.Name = "labeldfsFileName";
            // 
            // dfsFileName
            // 
            resources.ApplyResources(this.dfsFileName, "dfsFileName");
            this.dfsFileName.Name = "dfsFileName";
            this.dfsFileName.NamedProperties.Put("EnumerateMethod", "");
            this.dfsFileName.NamedProperties.Put("FieldFlags", "294");
            this.dfsFileName.NamedProperties.Put("LovReference", "");
            this.dfsFileName.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsFileName.NamedProperties.Put("SqlColumn", "FILE_NAME");
            this.dfsFileName.NamedProperties.Put("ValidateMethod", "");
            this.dfsFileName.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsFileName_WindowActions);
            // 
            // labeldfsLoadFileTypeList
            // 
            resources.ApplyResources(this.labeldfsLoadFileTypeList, "labeldfsLoadFileTypeList");
            this.labeldfsLoadFileTypeList.Name = "labeldfsLoadFileTypeList";
            // 
            // dfsLoadFileTypeList
            // 
            resources.ApplyResources(this.dfsLoadFileTypeList, "dfsLoadFileTypeList");
            this.dfsLoadFileTypeList.Name = "dfsLoadFileTypeList";
            this.dfsLoadFileTypeList.NamedProperties.Put("EnumerateMethod", "");
            this.dfsLoadFileTypeList.NamedProperties.Put("FieldFlags", "295");
            this.dfsLoadFileTypeList.NamedProperties.Put("LovReference", "");
            this.dfsLoadFileTypeList.NamedProperties.Put("SqlColumn", "LOAD_FILE_TYPE_LIST");
            this.dfsLoadFileTypeList.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsLoadFileTypeList_WindowActions);
            // 
            // labeldfsInputFilePath
            // 
            resources.ApplyResources(this.labeldfsInputFilePath, "labeldfsInputFilePath");
            this.labeldfsInputFilePath.Name = "labeldfsInputFilePath";
            // 
            // dfsInputFilePath
            // 
            resources.ApplyResources(this.dfsInputFilePath, "dfsInputFilePath");
            this.dfsInputFilePath.Name = "dfsInputFilePath";
            this.dfsInputFilePath.NamedProperties.Put("EnumerateMethod", "");
            this.dfsInputFilePath.NamedProperties.Put("FieldFlags", "294");
            this.dfsInputFilePath.NamedProperties.Put("LovReference", "");
            this.dfsInputFilePath.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsInputFilePath.NamedProperties.Put("SqlColumn", "FILE_PATH");
            this.dfsInputFilePath.NamedProperties.Put("ValidateMethod", "");
            this.dfsInputFilePath.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsInputFilePath_WindowActions);
            // 
            // labeldfsInputFilePathServer
            // 
            resources.ApplyResources(this.labeldfsInputFilePathServer, "labeldfsInputFilePathServer");
            this.labeldfsInputFilePathServer.Name = "labeldfsInputFilePathServer";
            // 
            // dfsInputFilePathServer
            // 
            resources.ApplyResources(this.dfsInputFilePathServer, "dfsInputFilePathServer");
            this.dfsInputFilePathServer.Name = "dfsInputFilePathServer";
            this.dfsInputFilePathServer.NamedProperties.Put("EnumerateMethod", "");
            this.dfsInputFilePathServer.NamedProperties.Put("FieldFlags", "294");
            this.dfsInputFilePathServer.NamedProperties.Put("LovReference", "");
            this.dfsInputFilePathServer.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsInputFilePathServer.NamedProperties.Put("SqlColumn", "FILE_PATH_SERVER");
            this.dfsInputFilePathServer.NamedProperties.Put("ValidateMethod", "");
            this.dfsInputFilePathServer.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsInputFilePathServer_WindowActions);
            // 
            // labeldfsBackupFilePath
            // 
            resources.ApplyResources(this.labeldfsBackupFilePath, "labeldfsBackupFilePath");
            this.labeldfsBackupFilePath.Name = "labeldfsBackupFilePath";
            // 
            // dfsBackupFilePath
            // 
            resources.ApplyResources(this.dfsBackupFilePath, "dfsBackupFilePath");
            this.dfsBackupFilePath.Name = "dfsBackupFilePath";
            this.dfsBackupFilePath.NamedProperties.Put("EnumerateMethod", "");
            this.dfsBackupFilePath.NamedProperties.Put("FieldFlags", "294");
            this.dfsBackupFilePath.NamedProperties.Put("LovReference", "");
            this.dfsBackupFilePath.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsBackupFilePath.NamedProperties.Put("SqlColumn", "BACKUP_FILE_PATH");
            this.dfsBackupFilePath.NamedProperties.Put("ValidateMethod", "");
            this.dfsBackupFilePath.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsBackupFilePath_WindowActions);
            // 
            // labeldfsBackupFilePathServer
            // 
            resources.ApplyResources(this.labeldfsBackupFilePathServer, "labeldfsBackupFilePathServer");
            this.labeldfsBackupFilePathServer.Name = "labeldfsBackupFilePathServer";
            // 
            // dfsBackupFilePathServer
            // 
            resources.ApplyResources(this.dfsBackupFilePathServer, "dfsBackupFilePathServer");
            this.dfsBackupFilePathServer.Name = "dfsBackupFilePathServer";
            this.dfsBackupFilePathServer.NamedProperties.Put("EnumerateMethod", "");
            this.dfsBackupFilePathServer.NamedProperties.Put("FieldFlags", "294");
            this.dfsBackupFilePathServer.NamedProperties.Put("LovReference", "");
            this.dfsBackupFilePathServer.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsBackupFilePathServer.NamedProperties.Put("SqlColumn", "BACKUP_FILE_PATH_SERVER");
            this.dfsBackupFilePathServer.NamedProperties.Put("ValidateMethod", "");
            this.dfsBackupFilePathServer.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsBackupFilePathServer_WindowActions);
            // 
            // labeldfsCharacterSet
            // 
            resources.ApplyResources(this.labeldfsCharacterSet, "labeldfsCharacterSet");
            this.labeldfsCharacterSet.Name = "labeldfsCharacterSet";
            // 
            // dfsCharacterSet
            // 
            this.dfsCharacterSet.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsCharacterSet, "dfsCharacterSet");
            this.dfsCharacterSet.Name = "dfsCharacterSet";
            this.dfsCharacterSet.NamedProperties.Put("EnumerateMethod", "");
            this.dfsCharacterSet.NamedProperties.Put("FieldFlags", "294");
            this.dfsCharacterSet.NamedProperties.Put("LovReference", "");
            this.dfsCharacterSet.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsCharacterSet.NamedProperties.Put("SqlColumn", "CHARACTER_SET");
            this.dfsCharacterSet.NamedProperties.Put("ValidateMethod", "");
            this.dfsCharacterSet.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsCharacterSet_WindowActions);
            // 
            // gbRemove_Transaction_Options
            // 
            resources.ApplyResources(this.gbRemove_Transaction_Options, "gbRemove_Transaction_Options");
            this.gbRemove_Transaction_Options.Name = "gbRemove_Transaction_Options";
            this.gbRemove_Transaction_Options.TabStop = false;
            // 
            // labeldfnRemoveDays
            // 
            resources.ApplyResources(this.labeldfnRemoveDays, "labeldfnRemoveDays");
            this.labeldfnRemoveDays.Name = "labeldfnRemoveDays";
            // 
            // dfnRemoveDays
            // 
            this.dfnRemoveDays.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfnRemoveDays, "dfnRemoveDays");
            this.dfnRemoveDays.Name = "dfnRemoveDays";
            this.dfnRemoveDays.NamedProperties.Put("EnumerateMethod", "");
            this.dfnRemoveDays.NamedProperties.Put("FieldFlags", "294");
            this.dfnRemoveDays.NamedProperties.Put("LovReference", "");
            this.dfnRemoveDays.NamedProperties.Put("SqlColumn", "REMOVE_DAYS");
            // 
            // cbRemoveComplete
            // 
            resources.ApplyResources(this.cbRemoveComplete, "cbRemoveComplete");
            this.cbRemoveComplete.Name = "cbRemoveComplete";
            this.cbRemoveComplete.NamedProperties.Put("DataType", "5");
            this.cbRemoveComplete.NamedProperties.Put("EnumerateMethod", "");
            this.cbRemoveComplete.NamedProperties.Put("FieldFlags", "295");
            this.cbRemoveComplete.NamedProperties.Put("LovReference", "");
            this.cbRemoveComplete.NamedProperties.Put("ResizeableChildObject", "");
            this.cbRemoveComplete.NamedProperties.Put("SqlColumn", "REMOVE_COMPLETE");
            this.cbRemoveComplete.NamedProperties.Put("ValidateMethod", "");
            this.cbRemoveComplete.NamedProperties.Put("XDataLength", "5");
            // 
            // gbRecord_Handling_Options
            // 
            resources.ApplyResources(this.gbRecord_Handling_Options, "gbRecord_Handling_Options");
            this.gbRecord_Handling_Options.Name = "gbRecord_Handling_Options";
            this.gbRecord_Handling_Options.TabStop = false;
            // 
            // labeldfsApiToCall
            // 
            resources.ApplyResources(this.labeldfsApiToCall, "labeldfsApiToCall");
            this.labeldfsApiToCall.Name = "labeldfsApiToCall";
            // 
            // dfsApiToCall
            // 
            resources.ApplyResources(this.dfsApiToCall, "dfsApiToCall");
            this.dfsApiToCall.Name = "dfsApiToCall";
            this.dfsApiToCall.NamedProperties.Put("EnumerateMethod", "");
            this.dfsApiToCall.NamedProperties.Put("FieldFlags", "294");
            this.dfsApiToCall.NamedProperties.Put("LovReference", "");
            this.dfsApiToCall.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsApiToCall.NamedProperties.Put("SqlColumn", "API_TO_CALL");
            this.dfsApiToCall.NamedProperties.Put("ValidateMethod", "");
            this.dfsApiToCall.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsApiToCall_WindowActions);
            // 
            // labeldfsApiToCallUnpBefore
            // 
            resources.ApplyResources(this.labeldfsApiToCallUnpBefore, "labeldfsApiToCallUnpBefore");
            this.labeldfsApiToCallUnpBefore.Name = "labeldfsApiToCallUnpBefore";
            // 
            // dfsApiToCallUnpBefore
            // 
            resources.ApplyResources(this.dfsApiToCallUnpBefore, "dfsApiToCallUnpBefore");
            this.dfsApiToCallUnpBefore.Name = "dfsApiToCallUnpBefore";
            this.dfsApiToCallUnpBefore.NamedProperties.Put("EnumerateMethod", "");
            this.dfsApiToCallUnpBefore.NamedProperties.Put("FieldFlags", "294");
            this.dfsApiToCallUnpBefore.NamedProperties.Put("LovReference", "");
            this.dfsApiToCallUnpBefore.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsApiToCallUnpBefore.NamedProperties.Put("SqlColumn", "API_TO_CALL_UNP_BEFORE");
            this.dfsApiToCallUnpBefore.NamedProperties.Put("ValidateMethod", "");
            this.dfsApiToCallUnpBefore.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsApiToCallUnpBefore_WindowActions);
            // 
            // labeldfsApiToCallUnpAfter
            // 
            resources.ApplyResources(this.labeldfsApiToCallUnpAfter, "labeldfsApiToCallUnpAfter");
            this.labeldfsApiToCallUnpAfter.Name = "labeldfsApiToCallUnpAfter";
            // 
            // dfsApiToCallUnpAfter
            // 
            resources.ApplyResources(this.dfsApiToCallUnpAfter, "dfsApiToCallUnpAfter");
            this.dfsApiToCallUnpAfter.Name = "dfsApiToCallUnpAfter";
            this.dfsApiToCallUnpAfter.NamedProperties.Put("EnumerateMethod", "");
            this.dfsApiToCallUnpAfter.NamedProperties.Put("FieldFlags", "294");
            this.dfsApiToCallUnpAfter.NamedProperties.Put("LovReference", "");
            this.dfsApiToCallUnpAfter.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsApiToCallUnpAfter.NamedProperties.Put("SqlColumn", "API_TO_CALL_UNP_AFTER");
            this.dfsApiToCallUnpAfter.NamedProperties.Put("ValidateMethod", "");
            this.dfsApiToCallUnpAfter.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsApiToCallUnpAfter_WindowActions);
            // 
            // menuFrmMethods
            // 
            this.menuFrmMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_External});
            this.menuFrmMethods.Name = "menuFrmMethods";
            resources.ApplyResources(this.menuFrmMethods, "menuFrmMethods");
            // 
            // menuItem_External
            // 
            this.menuItem_External.Command = this.menuFrmMethods_menuExternal_File_Template_C_ontrol_;
            this.menuItem_External.Name = "menuItem_External";
            resources.ApplyResources(this.menuItem_External, "menuItem_External");
            this.menuItem_External.Text = "External File Template C&ontrol...";
            // 
            // cbSystemDefined
            // 
            resources.ApplyResources(this.cbSystemDefined, "cbSystemDefined");
            this.cbSystemDefined.Name = "cbSystemDefined";
            this.cbSystemDefined.NamedProperties.Put("DataType", "7");
            this.cbSystemDefined.NamedProperties.Put("EnumerateMethod", "");
            this.cbSystemDefined.NamedProperties.Put("FieldFlags", "259");
            this.cbSystemDefined.NamedProperties.Put("LovReference", "");
            this.cbSystemDefined.NamedProperties.Put("ParentName", "dfsFileTemplateId");
            this.cbSystemDefined.NamedProperties.Put("ResizeableChildObject", "");
            this.cbSystemDefined.NamedProperties.Put("SqlColumn", "EXT_FILE_TEMPLATE_API.Get_System_Defined(FILE_TEMPLATE_ID)");
            this.cbSystemDefined.NamedProperties.Put("ValidateMethod", "");
            this.cbSystemDefined.NamedProperties.Put("XDataLength", "2000");
            this.cbSystemDefined.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cbSystemDefined_WindowActions);
            // 
            // cbAllowOneRecordSetOnly
            // 
            resources.ApplyResources(this.cbAllowOneRecordSetOnly, "cbAllowOneRecordSetOnly");
            this.cbAllowOneRecordSetOnly.Name = "cbAllowOneRecordSetOnly";
            this.cbAllowOneRecordSetOnly.NamedProperties.Put("DataType", "5");
            this.cbAllowOneRecordSetOnly.NamedProperties.Put("EnumerateMethod", "");
            this.cbAllowOneRecordSetOnly.NamedProperties.Put("FieldFlags", "294");
            this.cbAllowOneRecordSetOnly.NamedProperties.Put("LovReference", "");
            this.cbAllowOneRecordSetOnly.NamedProperties.Put("ResizeableChildObject", "");
            this.cbAllowOneRecordSetOnly.NamedProperties.Put("SqlColumn", "ALLOW_ONE_RECORD_SET_ONLY");
            this.cbAllowOneRecordSetOnly.NamedProperties.Put("ValidateMethod", "");
            this.cbAllowOneRecordSetOnly.NamedProperties.Put("XDataLength", "5");
            this.cbAllowOneRecordSetOnly.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cbAllowOneRecordSetOnly_WindowActions);
            // 
            // cbAllowRecordSetRepeat
            // 
            resources.ApplyResources(this.cbAllowRecordSetRepeat, "cbAllowRecordSetRepeat");
            this.cbAllowRecordSetRepeat.Name = "cbAllowRecordSetRepeat";
            this.cbAllowRecordSetRepeat.NamedProperties.Put("DataType", "5");
            this.cbAllowRecordSetRepeat.NamedProperties.Put("EnumerateMethod", "");
            this.cbAllowRecordSetRepeat.NamedProperties.Put("FieldFlags", "294");
            this.cbAllowRecordSetRepeat.NamedProperties.Put("LovReference", "");
            this.cbAllowRecordSetRepeat.NamedProperties.Put("ResizeableChildObject", "");
            this.cbAllowRecordSetRepeat.NamedProperties.Put("SqlColumn", "ALLOW_RECORD_SET_REPEAT");
            this.cbAllowRecordSetRepeat.NamedProperties.Put("ValidateMethod", "");
            this.cbAllowRecordSetRepeat.NamedProperties.Put("XDataLength", "5");
            this.cbAllowRecordSetRepeat.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cbAllowRecordSetRepeat_WindowActions);
            // 
            // cbSkipInitialBlanks
            // 
            resources.ApplyResources(this.cbSkipInitialBlanks, "cbSkipInitialBlanks");
            this.cbSkipInitialBlanks.Name = "cbSkipInitialBlanks";
            this.cbSkipInitialBlanks.NamedProperties.Put("DataType", "5");
            this.cbSkipInitialBlanks.NamedProperties.Put("EnumerateMethod", "");
            this.cbSkipInitialBlanks.NamedProperties.Put("FieldFlags", "295");
            this.cbSkipInitialBlanks.NamedProperties.Put("LovReference", "");
            this.cbSkipInitialBlanks.NamedProperties.Put("ResizeableChildObject", "");
            this.cbSkipInitialBlanks.NamedProperties.Put("SqlColumn", "SKIP_INITIAL_BLANKS");
            this.cbSkipInitialBlanks.NamedProperties.Put("ValidateMethod", "");
            this.cbSkipInitialBlanks.NamedProperties.Put("XDataLength", "5");
            this.cbSkipInitialBlanks.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cbSkipInitialBlanks_WindowActions);
            // 
            // cbSkipAllBlanks
            // 
            resources.ApplyResources(this.cbSkipAllBlanks, "cbSkipAllBlanks");
            this.cbSkipAllBlanks.Name = "cbSkipAllBlanks";
            this.cbSkipAllBlanks.NamedProperties.Put("DataType", "5");
            this.cbSkipAllBlanks.NamedProperties.Put("EnumerateMethod", "");
            this.cbSkipAllBlanks.NamedProperties.Put("FieldFlags", "295");
            this.cbSkipAllBlanks.NamedProperties.Put("LovReference", "");
            this.cbSkipAllBlanks.NamedProperties.Put("ResizeableChildObject", "");
            this.cbSkipAllBlanks.NamedProperties.Put("SqlColumn", "SKIP_ALL_BLANKS");
            this.cbSkipAllBlanks.NamedProperties.Put("ValidateMethod", "");
            this.cbSkipAllBlanks.NamedProperties.Put("XDataLength", "5");
            this.cbSkipAllBlanks.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cbSkipAllBlanks_WindowActions);
            // 
            // cbAbortImmediatly
            // 
            resources.ApplyResources(this.cbAbortImmediatly, "cbAbortImmediatly");
            this.cbAbortImmediatly.Name = "cbAbortImmediatly";
            this.cbAbortImmediatly.NamedProperties.Put("DataType", "5");
            this.cbAbortImmediatly.NamedProperties.Put("EnumerateMethod", "");
            this.cbAbortImmediatly.NamedProperties.Put("FieldFlags", "295");
            this.cbAbortImmediatly.NamedProperties.Put("LovReference", "");
            this.cbAbortImmediatly.NamedProperties.Put("ResizeableChildObject", "");
            this.cbAbortImmediatly.NamedProperties.Put("SqlColumn", "ABORT_IMMEDIATLY");
            this.cbAbortImmediatly.NamedProperties.Put("ValidateMethod", "");
            this.cbAbortImmediatly.NamedProperties.Put("XDataLength", "5");
            // 
            // cbLogSkippedLines
            // 
            resources.ApplyResources(this.cbLogSkippedLines, "cbLogSkippedLines");
            this.cbLogSkippedLines.Name = "cbLogSkippedLines";
            this.cbLogSkippedLines.NamedProperties.Put("DataType", "5");
            this.cbLogSkippedLines.NamedProperties.Put("EnumerateMethod", "");
            this.cbLogSkippedLines.NamedProperties.Put("FieldFlags", "295");
            this.cbLogSkippedLines.NamedProperties.Put("LovReference", "");
            this.cbLogSkippedLines.NamedProperties.Put("ResizeableChildObject", "");
            this.cbLogSkippedLines.NamedProperties.Put("SqlColumn", "LOG_SKIPPED_LINES");
            this.cbLogSkippedLines.NamedProperties.Put("ValidateMethod", "");
            this.cbLogSkippedLines.NamedProperties.Put("XDataLength", "5");
            // 
            // cbLogInvalidLines
            // 
            resources.ApplyResources(this.cbLogInvalidLines, "cbLogInvalidLines");
            this.cbLogInvalidLines.Name = "cbLogInvalidLines";
            this.cbLogInvalidLines.NamedProperties.Put("DataType", "5");
            this.cbLogInvalidLines.NamedProperties.Put("EnumerateMethod", "");
            this.cbLogInvalidLines.NamedProperties.Put("FieldFlags", "295");
            this.cbLogInvalidLines.NamedProperties.Put("LovReference", "");
            this.cbLogInvalidLines.NamedProperties.Put("ResizeableChildObject", "");
            this.cbLogInvalidLines.NamedProperties.Put("SqlColumn", "LOG_INVALID_LINES");
            this.cbLogInvalidLines.NamedProperties.Put("ValidateMethod", "");
            this.cbLogInvalidLines.NamedProperties.Put("XDataLength", "5");
            // 
            // frmExternalFileTemplateIn
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.dfsApiToCallUnpAfter);
            this.Controls.Add(this.dfsApiToCallUnpBefore);
            this.Controls.Add(this.dfsApiToCall);
            this.Controls.Add(this.cbSystemDefined);
            this.Controls.Add(this.cbAllowOneRecordSetOnly);
            this.Controls.Add(this.cbAllowRecordSetRepeat);
            this.Controls.Add(this.cbRemoveComplete);
            this.Controls.Add(this.dfnRemoveDays);
            this.Controls.Add(this.dfsCharacterSet);
            this.Controls.Add(this.dfsBackupFilePathServer);
            this.Controls.Add(this.dfsBackupFilePath);
            this.Controls.Add(this.dfsInputFilePathServer);
            this.Controls.Add(this.dfsInputFilePath);
            this.Controls.Add(this.dfsLoadFileTypeList);
            this.Controls.Add(this.dfsFileName);
            this.Controls.Add(this.cbSkipInitialBlanks);
            this.Controls.Add(this.cbSkipAllBlanks);
            this.Controls.Add(this.cbAbortImmediatly);
            this.Controls.Add(this.cbLogSkippedLines);
            this.Controls.Add(this.cbLogInvalidLines);
            this.Controls.Add(this.cmbFileDirection);
            this.Controls.Add(this.dfsFileTemplateId);
            this.Controls.Add(this.labeldfsApiToCallUnpAfter);
            this.Controls.Add(this.labeldfsApiToCallUnpBefore);
            this.Controls.Add(this.labeldfsApiToCall);
            this.Controls.Add(this.labeldfnRemoveDays);
            this.Controls.Add(this.labeldfsCharacterSet);
            this.Controls.Add(this.labeldfsBackupFilePathServer);
            this.Controls.Add(this.labeldfsBackupFilePath);
            this.Controls.Add(this.labeldfsInputFilePathServer);
            this.Controls.Add(this.labeldfsInputFilePath);
            this.Controls.Add(this.labeldfsLoadFileTypeList);
            this.Controls.Add(this.labeldfsFileName);
            this.Controls.Add(this.gbRecord_Handling_Options);
            this.Controls.Add(this.gbRemove_Transaction_Options);
            this.Controls.Add(this.gbFile_Name_Path_Options);
            this.Controls.Add(this.gbProcessing_Options);
            this.Controls.Add(this.gbFile_Unpack_Options);
            this.Name = "frmExternalFileTemplateIn";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "InExtFileTemplateDir");
            this.NamedProperties.Put("PackageName", "IN_EXT_FILE_TEMPLATE_DIR_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("ViewName", "IN_EXT_FILE_TEMPLATE_DIR");
            this.NamedProperties.Put("Warnings", "TRUE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.frmExternalFileTemplateIn_WindowActions);
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

        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menuExternal_File_Template_C_ontrol_;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuFrmMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_External;
	}
}
