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
	
	public partial class frmExternalFileTypeDefinition
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		protected cBackgroundText labelccsFileType;
		public cRecListDataField ccsFileType;
		protected cBackgroundText labeldfsDescription;
		public cDataField dfsDescription;
		public cCheckBox cbSystemDefined;
		protected cBackgroundText labeldfsComponent;
		public cDataField dfsComponent;
		protected cBackgroundText labeldfsApiToCallInput;
		public cDataField dfsApiToCallInput;
		protected cBackgroundText labeldfsApiToCallOutput;
		public cDataField dfsApiToCallOutput;
		// Not visible fields start
		protected cBackgroundText labeldfsInputPackage;
		public cDataField dfsInputPackage;
		protected cBackgroundText labeldfsViewName;
		public cDataField dfsViewName;
		protected cBackgroundText labeldfsFormName;
		public cDataField dfsFormName;
		protected cBackgroundText labeldfsTargetDefaultMethod;
		public cDataField dfsTargetDefaultMethod;
		// Not visible fields end
        // Bug 73298 Begin - Changed the derived base class.
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExternalFileTypeDefinition));
            this.menuTblMethods_menuExternal_File_Column__Definition = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTblMethods_menuCreate_Details_From__View_Defini = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuFrmMethods_menu_External_File_Template___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuFrmMethods_menuExternal_File_Type__Parameter_De = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuFrmMethods_menuExternal_File__Load_Parameters__ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.labelccsFileType = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.ccsFileType = new Ifs.Fnd.ApplicationForms.cRecListDataField();
            this.labeldfsDescription = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsDescription = new Ifs.Fnd.ApplicationForms.cDataField();
            this.cbSystemDefined = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.labeldfsComponent = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsComponent = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsApiToCallInput = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsApiToCallInput = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsApiToCallOutput = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsApiToCallOutput = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsInputPackage = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsInputPackage = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsViewName = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsViewName = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsFormName = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsFormName = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsTargetDefaultMethod = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsTargetDefaultMethod = new Ifs.Fnd.ApplicationForms.cDataField();
            this.menuFrmMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem__External = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem_External = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem_External_1 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuTblMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_External_2 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem_Create = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.tblExtFileTypeRec = new Ifs.Application.Accrul.cChildTableFinBase();
            this.tblExtFileTypeRec_colsFileType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExtFileTypeRec_colsGroupId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExtFileTypeRec_colsDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExtFileTypeRec_colsSubGroupId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExtFileTypeRec_colsFirstInSubGroup = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.tblExtFileTypeRec_colsLastInSubGroup = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.tblExtFileTypeRec_colsMandatoryRecord = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.tblExtFileTypeRec_colsParentRecordType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExtFileTypeRec_colsViewName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExtFileTypeRec_colsInputPackage = new Ifs.Fnd.ApplicationForms.cColumn();
            this.menuFrmMethods.SuspendLayout();
            this.menuTblMethods.SuspendLayout();
            this.tblExtFileTypeRec.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuFrmMethods_menu_External_File_Template___);
            this.commandManager.Commands.Add(this.menuFrmMethods_menuExternal_File_Type__Parameter_De);
            this.commandManager.Commands.Add(this.menuFrmMethods_menuExternal_File__Load_Parameters__);
            this.commandManager.Commands.Add(this.menuTblMethods_menuExternal_File_Column__Definition);
            this.commandManager.Commands.Add(this.menuTblMethods_menuCreate_Details_From__View_Defini);
            this.commandManager.ContextMenus.Add(this.menuFrmMethods);
            this.commandManager.ContextMenus.Add(this.menuTblMethods);
            // 
            // menuTblMethods_menuExternal_File_Column__Definition
            // 
            resources.ApplyResources(this.menuTblMethods_menuExternal_File_Column__Definition, "menuTblMethods_menuExternal_File_Column__Definition");
            this.menuTblMethods_menuExternal_File_Column__Definition.Name = "menuTblMethods_menuExternal_File_Column__Definition";
            this.menuTblMethods_menuExternal_File_Column__Definition.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_External_2_Execute);
            this.menuTblMethods_menuExternal_File_Column__Definition.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_External_2_Inquire);
            // 
            // menuTblMethods_menuCreate_Details_From__View_Defini
            // 
            resources.ApplyResources(this.menuTblMethods_menuCreate_Details_From__View_Defini, "menuTblMethods_menuCreate_Details_From__View_Defini");
            this.menuTblMethods_menuCreate_Details_From__View_Defini.Name = "menuTblMethods_menuCreate_Details_From__View_Defini";
            this.menuTblMethods_menuCreate_Details_From__View_Defini.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Create_Execute);
            this.menuTblMethods_menuCreate_Details_From__View_Defini.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Create_Inquire);
            // 
            // menuFrmMethods_menu_External_File_Template___
            // 
            resources.ApplyResources(this.menuFrmMethods_menu_External_File_Template___, "menuFrmMethods_menu_External_File_Template___");
            this.menuFrmMethods_menu_External_File_Template___.Name = "menuFrmMethods_menu_External_File_Template___";
            this.menuFrmMethods_menu_External_File_Template___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__External_Execute);
            this.menuFrmMethods_menu_External_File_Template___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__External_Inquire);
            // 
            // menuFrmMethods_menuExternal_File_Type__Parameter_De
            // 
            resources.ApplyResources(this.menuFrmMethods_menuExternal_File_Type__Parameter_De, "menuFrmMethods_menuExternal_File_Type__Parameter_De");
            this.menuFrmMethods_menuExternal_File_Type__Parameter_De.Name = "menuFrmMethods_menuExternal_File_Type__Parameter_De";
            this.menuFrmMethods_menuExternal_File_Type__Parameter_De.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_External_Execute);
            this.menuFrmMethods_menuExternal_File_Type__Parameter_De.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_External_Inquire);
            // 
            // menuFrmMethods_menuExternal_File__Load_Parameters__
            // 
            resources.ApplyResources(this.menuFrmMethods_menuExternal_File__Load_Parameters__, "menuFrmMethods_menuExternal_File__Load_Parameters__");
            this.menuFrmMethods_menuExternal_File__Load_Parameters__.Name = "menuFrmMethods_menuExternal_File__Load_Parameters__";
            this.menuFrmMethods_menuExternal_File__Load_Parameters__.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_External_1_Execute);
            this.menuFrmMethods_menuExternal_File__Load_Parameters__.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_External_1_Inquire);
            // 
            // labelccsFileType
            // 
            resources.ApplyResources(this.labelccsFileType, "labelccsFileType");
            this.labelccsFileType.Name = "labelccsFileType";
            // 
            // ccsFileType
            // 
            resources.ApplyResources(this.ccsFileType, "ccsFileType");
            this.ccsFileType.Name = "ccsFileType";
            this.ccsFileType.NamedProperties.Put("EnumerateMethod", "");
            this.ccsFileType.NamedProperties.Put("FieldFlags", "163");
            this.ccsFileType.NamedProperties.Put("LovReference", "");
            this.ccsFileType.NamedProperties.Put("ResizeableChildObject", "");
            this.ccsFileType.NamedProperties.Put("SqlColumn", "FILE_TYPE");
            this.ccsFileType.NamedProperties.Put("ValidateMethod", "");
            this.ccsFileType.NamedProperties.Put("XDataLength", "30");
            // 
            // labeldfsDescription
            // 
            resources.ApplyResources(this.labeldfsDescription, "labeldfsDescription");
            this.labeldfsDescription.Name = "labeldfsDescription";
            // 
            // dfsDescription
            // 
            resources.ApplyResources(this.dfsDescription, "dfsDescription");
            this.dfsDescription.Name = "dfsDescription";
            this.dfsDescription.NamedProperties.Put("EnumerateMethod", "");
            this.dfsDescription.NamedProperties.Put("FieldFlags", "295");
            this.dfsDescription.NamedProperties.Put("LovReference", "");
            this.dfsDescription.NamedProperties.Put("ParentName", "ccsFileType");
            this.dfsDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsDescription.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            this.dfsDescription.NamedProperties.Put("ValidateMethod", "");
            this.dfsDescription.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsDescription_WindowActions);
            // 
            // cbSystemDefined
            // 
            resources.ApplyResources(this.cbSystemDefined, "cbSystemDefined");
            this.cbSystemDefined.Name = "cbSystemDefined";
            this.cbSystemDefined.NamedProperties.Put("DataType", "5");
            this.cbSystemDefined.NamedProperties.Put("EnumerateMethod", "");
            this.cbSystemDefined.NamedProperties.Put("FieldFlags", "290");
            this.cbSystemDefined.NamedProperties.Put("LovReference", "");
            this.cbSystemDefined.NamedProperties.Put("ResizeableChildObject", "");
            this.cbSystemDefined.NamedProperties.Put("SqlColumn", "SYSTEM_DEFINED");
            this.cbSystemDefined.NamedProperties.Put("ValidateMethod", "");
            this.cbSystemDefined.NamedProperties.Put("XDataLength", "5");
            this.cbSystemDefined.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cbSystemDefined_WindowActions);
            // 
            // labeldfsComponent
            // 
            resources.ApplyResources(this.labeldfsComponent, "labeldfsComponent");
            this.labeldfsComponent.Name = "labeldfsComponent";
            // 
            // dfsComponent
            // 
            this.dfsComponent.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsComponent, "dfsComponent");
            this.dfsComponent.Name = "dfsComponent";
            this.dfsComponent.NamedProperties.Put("EnumerateMethod", "");
            this.dfsComponent.NamedProperties.Put("FieldFlags", "290");
            this.dfsComponent.NamedProperties.Put("LovReference", "EXT_FILE_MODULE_NAME");
            this.dfsComponent.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsComponent.NamedProperties.Put("SqlColumn", "COMPONENT");
            this.dfsComponent.NamedProperties.Put("ValidateMethod", "");
            this.dfsComponent.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsComponent_WindowActions);
            // 
            // labeldfsApiToCallInput
            // 
            resources.ApplyResources(this.labeldfsApiToCallInput, "labeldfsApiToCallInput");
            this.labeldfsApiToCallInput.Name = "labeldfsApiToCallInput";
            // 
            // dfsApiToCallInput
            // 
            resources.ApplyResources(this.dfsApiToCallInput, "dfsApiToCallInput");
            this.dfsApiToCallInput.Name = "dfsApiToCallInput";
            this.dfsApiToCallInput.NamedProperties.Put("EnumerateMethod", "");
            this.dfsApiToCallInput.NamedProperties.Put("FieldFlags", "294");
            this.dfsApiToCallInput.NamedProperties.Put("LovReference", "");
            this.dfsApiToCallInput.NamedProperties.Put("SqlColumn", "API_TO_CALL_INPUT");
            this.dfsApiToCallInput.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsApiToCallInput_WindowActions);
            // 
            // labeldfsApiToCallOutput
            // 
            resources.ApplyResources(this.labeldfsApiToCallOutput, "labeldfsApiToCallOutput");
            this.labeldfsApiToCallOutput.Name = "labeldfsApiToCallOutput";
            // 
            // dfsApiToCallOutput
            // 
            resources.ApplyResources(this.dfsApiToCallOutput, "dfsApiToCallOutput");
            this.dfsApiToCallOutput.Name = "dfsApiToCallOutput";
            this.dfsApiToCallOutput.NamedProperties.Put("EnumerateMethod", "");
            this.dfsApiToCallOutput.NamedProperties.Put("FieldFlags", "294");
            this.dfsApiToCallOutput.NamedProperties.Put("LovReference", "");
            this.dfsApiToCallOutput.NamedProperties.Put("SqlColumn", "API_TO_CALL_OUTPUT");
            this.dfsApiToCallOutput.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsApiToCallOutput_WindowActions);
            // 
            // labeldfsInputPackage
            // 
            resources.ApplyResources(this.labeldfsInputPackage, "labeldfsInputPackage");
            this.labeldfsInputPackage.Name = "labeldfsInputPackage";
            // 
            // dfsInputPackage
            // 
            resources.ApplyResources(this.dfsInputPackage, "dfsInputPackage");
            this.dfsInputPackage.Name = "dfsInputPackage";
            this.dfsInputPackage.NamedProperties.Put("EnumerateMethod", "");
            this.dfsInputPackage.NamedProperties.Put("LovReference", "");
            this.dfsInputPackage.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsInputPackage.NamedProperties.Put("SqlColumn", "INPUT_PACKAGE");
            this.dfsInputPackage.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsViewName
            // 
            resources.ApplyResources(this.labeldfsViewName, "labeldfsViewName");
            this.labeldfsViewName.Name = "labeldfsViewName";
            // 
            // dfsViewName
            // 
            resources.ApplyResources(this.dfsViewName, "dfsViewName");
            this.dfsViewName.Name = "dfsViewName";
            this.dfsViewName.NamedProperties.Put("EnumerateMethod", "");
            this.dfsViewName.NamedProperties.Put("LovReference", "");
            this.dfsViewName.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsViewName.NamedProperties.Put("SqlColumn", "VIEW_NAME");
            this.dfsViewName.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsFormName
            // 
            resources.ApplyResources(this.labeldfsFormName, "labeldfsFormName");
            this.labeldfsFormName.Name = "labeldfsFormName";
            // 
            // dfsFormName
            // 
            resources.ApplyResources(this.dfsFormName, "dfsFormName");
            this.dfsFormName.Name = "dfsFormName";
            this.dfsFormName.NamedProperties.Put("EnumerateMethod", "");
            this.dfsFormName.NamedProperties.Put("FieldFlags", "262");
            this.dfsFormName.NamedProperties.Put("LovReference", "");
            this.dfsFormName.NamedProperties.Put("SqlColumn", "FORM_NAME");
            this.dfsFormName.NamedProperties.Put("ValidateMethod", "");
            this.dfsFormName.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsFormName_WindowActions);
            // 
            // labeldfsTargetDefaultMethod
            // 
            resources.ApplyResources(this.labeldfsTargetDefaultMethod, "labeldfsTargetDefaultMethod");
            this.labeldfsTargetDefaultMethod.Name = "labeldfsTargetDefaultMethod";
            // 
            // dfsTargetDefaultMethod
            // 
            resources.ApplyResources(this.dfsTargetDefaultMethod, "dfsTargetDefaultMethod");
            this.dfsTargetDefaultMethod.Name = "dfsTargetDefaultMethod";
            this.dfsTargetDefaultMethod.NamedProperties.Put("EnumerateMethod", "");
            this.dfsTargetDefaultMethod.NamedProperties.Put("FieldFlags", "262");
            this.dfsTargetDefaultMethod.NamedProperties.Put("LovReference", "");
            this.dfsTargetDefaultMethod.NamedProperties.Put("SqlColumn", "TARGET_DEFAULT_METHOD");
            this.dfsTargetDefaultMethod.NamedProperties.Put("ValidateMethod", "");
            this.dfsTargetDefaultMethod.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsTargetDefaultMethod_WindowActions);
            // 
            // menuFrmMethods
            // 
            this.menuFrmMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem__External,
            this.menuItem_External,
            this.menuItem_External_1});
            this.menuFrmMethods.Name = "menuFrmMethods";
            resources.ApplyResources(this.menuFrmMethods, "menuFrmMethods");
            // 
            // menuItem__External
            // 
            this.menuItem__External.Command = this.menuFrmMethods_menu_External_File_Template___;
            this.menuItem__External.Name = "menuItem__External";
            resources.ApplyResources(this.menuItem__External, "menuItem__External");
            this.menuItem__External.Text = "&External File Template...";
            // 
            // menuItem_External
            // 
            this.menuItem_External.Command = this.menuFrmMethods_menuExternal_File_Type__Parameter_De;
            this.menuItem_External.Name = "menuItem_External";
            resources.ApplyResources(this.menuItem_External, "menuItem_External");
            this.menuItem_External.Text = "External File Type &Parameter Definition...";
            // 
            // menuItem_External_1
            // 
            this.menuItem_External_1.Command = this.menuFrmMethods_menuExternal_File__Load_Parameters__;
            this.menuItem_External_1.Name = "menuItem_External_1";
            resources.ApplyResources(this.menuItem_External_1, "menuItem_External_1");
            this.menuItem_External_1.Text = "External File &Load Parameters...";
            // 
            // menuTblMethods
            // 
            this.menuTblMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_External_2,
            this.menuItem_Create});
            this.menuTblMethods.Name = "menuTblMethods";
            resources.ApplyResources(this.menuTblMethods, "menuTblMethods");
            // 
            // menuItem_External_2
            // 
            this.menuItem_External_2.Command = this.menuTblMethods_menuExternal_File_Column__Definition;
            this.menuItem_External_2.Name = "menuItem_External_2";
            resources.ApplyResources(this.menuItem_External_2, "menuItem_External_2");
            this.menuItem_External_2.Text = "External File Column &Definition...";
            // 
            // menuItem_Create
            // 
            this.menuItem_Create.Command = this.menuTblMethods_menuCreate_Details_From__View_Defini;
            this.menuItem_Create.Name = "menuItem_Create";
            resources.ApplyResources(this.menuItem_Create, "menuItem_Create");
            this.menuItem_Create.Text = "Create Details From &View Definition...";
            // 
            // tblExtFileTypeRec
            // 
            this.tblExtFileTypeRec.Controls.Add(this.tblExtFileTypeRec_colsFileType);
            this.tblExtFileTypeRec.Controls.Add(this.tblExtFileTypeRec_colsGroupId);
            this.tblExtFileTypeRec.Controls.Add(this.tblExtFileTypeRec_colsDescription);
            this.tblExtFileTypeRec.Controls.Add(this.tblExtFileTypeRec_colsSubGroupId);
            this.tblExtFileTypeRec.Controls.Add(this.tblExtFileTypeRec_colsFirstInSubGroup);
            this.tblExtFileTypeRec.Controls.Add(this.tblExtFileTypeRec_colsLastInSubGroup);
            this.tblExtFileTypeRec.Controls.Add(this.tblExtFileTypeRec_colsMandatoryRecord);
            this.tblExtFileTypeRec.Controls.Add(this.tblExtFileTypeRec_colsParentRecordType);
            this.tblExtFileTypeRec.Controls.Add(this.tblExtFileTypeRec_colsViewName);
            this.tblExtFileTypeRec.Controls.Add(this.tblExtFileTypeRec_colsInputPackage);
            resources.ApplyResources(this.tblExtFileTypeRec, "tblExtFileTypeRec");
            this.tblExtFileTypeRec.Name = "tblExtFileTypeRec";
            this.tblExtFileTypeRec.NamedProperties.Put("DefaultOrderBy", "record_set_id,DECODE(first_in_record_set,\'TRUE\',0,1),DECODE(last_in_record_set,\'T" +
                    "RUE\',1,0)");
            this.tblExtFileTypeRec.NamedProperties.Put("DefaultWhere", "");
            this.tblExtFileTypeRec.NamedProperties.Put("LogicalUnit", "ExtFileTypeRec");
            this.tblExtFileTypeRec.NamedProperties.Put("PackageName", "EXT_FILE_TYPE_REC_API");
            this.tblExtFileTypeRec.NamedProperties.Put("ResizeableChildObject", "LLMM");
            this.tblExtFileTypeRec.NamedProperties.Put("SourceFlags", "16833");
            this.tblExtFileTypeRec.NamedProperties.Put("ViewName", "EXT_FILE_TYPE_REC");
            this.tblExtFileTypeRec.NamedProperties.Put("Warnings", "FALSE");
            this.tblExtFileTypeRec.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblExtFileTypeRec_WindowActions);
            this.tblExtFileTypeRec.Controls.SetChildIndex(this.tblExtFileTypeRec_colsInputPackage, 0);
            this.tblExtFileTypeRec.Controls.SetChildIndex(this.tblExtFileTypeRec_colsViewName, 0);
            this.tblExtFileTypeRec.Controls.SetChildIndex(this.tblExtFileTypeRec_colsParentRecordType, 0);
            this.tblExtFileTypeRec.Controls.SetChildIndex(this.tblExtFileTypeRec_colsMandatoryRecord, 0);
            this.tblExtFileTypeRec.Controls.SetChildIndex(this.tblExtFileTypeRec_colsLastInSubGroup, 0);
            this.tblExtFileTypeRec.Controls.SetChildIndex(this.tblExtFileTypeRec_colsFirstInSubGroup, 0);
            this.tblExtFileTypeRec.Controls.SetChildIndex(this.tblExtFileTypeRec_colsSubGroupId, 0);
            this.tblExtFileTypeRec.Controls.SetChildIndex(this.tblExtFileTypeRec_colsDescription, 0);
            this.tblExtFileTypeRec.Controls.SetChildIndex(this.tblExtFileTypeRec_colsGroupId, 0);
            this.tblExtFileTypeRec.Controls.SetChildIndex(this.tblExtFileTypeRec_colsFileType, 0);
            // 
            // tblExtFileTypeRec_colsFileType
            // 
            resources.ApplyResources(this.tblExtFileTypeRec_colsFileType, "tblExtFileTypeRec_colsFileType");
            this.tblExtFileTypeRec_colsFileType.MaxLength = 30;
            this.tblExtFileTypeRec_colsFileType.Name = "tblExtFileTypeRec_colsFileType";
            this.tblExtFileTypeRec_colsFileType.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTypeRec_colsFileType.NamedProperties.Put("FieldFlags", "67");
            this.tblExtFileTypeRec_colsFileType.NamedProperties.Put("LovReference", "EXT_FILE_TYPE");
            this.tblExtFileTypeRec_colsFileType.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTypeRec_colsFileType.NamedProperties.Put("SqlColumn", "FILE_TYPE");
            this.tblExtFileTypeRec_colsFileType.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTypeRec_colsFileType.Position = 3;
            this.tblExtFileTypeRec_colsFileType.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblExtFileTypeRec_colsFileType_WindowActions);
            // 
            // tblExtFileTypeRec_colsGroupId
            // 
            this.tblExtFileTypeRec_colsGroupId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblExtFileTypeRec_colsGroupId.MaxLength = 20;
            this.tblExtFileTypeRec_colsGroupId.Name = "tblExtFileTypeRec_colsGroupId";
            this.tblExtFileTypeRec_colsGroupId.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTypeRec_colsGroupId.NamedProperties.Put("FieldFlags", "163");
            this.tblExtFileTypeRec_colsGroupId.NamedProperties.Put("LovReference", "");
            this.tblExtFileTypeRec_colsGroupId.NamedProperties.Put("SqlColumn", "RECORD_TYPE_ID");
            this.tblExtFileTypeRec_colsGroupId.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTypeRec_colsGroupId.Position = 4;
            resources.ApplyResources(this.tblExtFileTypeRec_colsGroupId, "tblExtFileTypeRec_colsGroupId");
            this.tblExtFileTypeRec_colsGroupId.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblExtFileTypeRec_colsGroupId_WindowActions);
            // 
            // tblExtFileTypeRec_colsDescription
            // 
            this.tblExtFileTypeRec_colsDescription.MaxLength = 200;
            this.tblExtFileTypeRec_colsDescription.Name = "tblExtFileTypeRec_colsDescription";
            this.tblExtFileTypeRec_colsDescription.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTypeRec_colsDescription.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTypeRec_colsDescription.NamedProperties.Put("LovReference", "");
            this.tblExtFileTypeRec_colsDescription.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            this.tblExtFileTypeRec_colsDescription.Position = 5;
            resources.ApplyResources(this.tblExtFileTypeRec_colsDescription, "tblExtFileTypeRec_colsDescription");
            this.tblExtFileTypeRec_colsDescription.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblExtFileTypeRec_colsDescription_WindowActions);
            // 
            // tblExtFileTypeRec_colsSubGroupId
            // 
            this.tblExtFileTypeRec_colsSubGroupId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblExtFileTypeRec_colsSubGroupId.MaxLength = 20;
            this.tblExtFileTypeRec_colsSubGroupId.Name = "tblExtFileTypeRec_colsSubGroupId";
            this.tblExtFileTypeRec_colsSubGroupId.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTypeRec_colsSubGroupId.NamedProperties.Put("FieldFlags", "295");
            this.tblExtFileTypeRec_colsSubGroupId.NamedProperties.Put("LovReference", "");
            this.tblExtFileTypeRec_colsSubGroupId.NamedProperties.Put("SqlColumn", "RECORD_SET_ID");
            this.tblExtFileTypeRec_colsSubGroupId.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTypeRec_colsSubGroupId.Position = 6;
            resources.ApplyResources(this.tblExtFileTypeRec_colsSubGroupId, "tblExtFileTypeRec_colsSubGroupId");
            this.tblExtFileTypeRec_colsSubGroupId.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblExtFileTypeRec_colsSubGroupId_WindowActions);
            // 
            // tblExtFileTypeRec_colsFirstInSubGroup
            // 
            this.tblExtFileTypeRec_colsFirstInSubGroup.MaxLength = 5;
            this.tblExtFileTypeRec_colsFirstInSubGroup.Name = "tblExtFileTypeRec_colsFirstInSubGroup";
            this.tblExtFileTypeRec_colsFirstInSubGroup.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTypeRec_colsFirstInSubGroup.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTypeRec_colsFirstInSubGroup.NamedProperties.Put("LovReference", "");
            this.tblExtFileTypeRec_colsFirstInSubGroup.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTypeRec_colsFirstInSubGroup.NamedProperties.Put("SqlColumn", "FIRST_IN_RECORD_SET");
            this.tblExtFileTypeRec_colsFirstInSubGroup.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTypeRec_colsFirstInSubGroup.Position = 7;
            resources.ApplyResources(this.tblExtFileTypeRec_colsFirstInSubGroup, "tblExtFileTypeRec_colsFirstInSubGroup");
            this.tblExtFileTypeRec_colsFirstInSubGroup.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblExtFileTypeRec_colsFirstInSubGroup_WindowActions);
            // 
            // tblExtFileTypeRec_colsLastInSubGroup
            // 
            this.tblExtFileTypeRec_colsLastInSubGroup.MaxLength = 5;
            this.tblExtFileTypeRec_colsLastInSubGroup.Name = "tblExtFileTypeRec_colsLastInSubGroup";
            this.tblExtFileTypeRec_colsLastInSubGroup.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTypeRec_colsLastInSubGroup.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTypeRec_colsLastInSubGroup.NamedProperties.Put("LovReference", "");
            this.tblExtFileTypeRec_colsLastInSubGroup.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTypeRec_colsLastInSubGroup.NamedProperties.Put("SqlColumn", "LAST_IN_RECORD_SET");
            this.tblExtFileTypeRec_colsLastInSubGroup.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTypeRec_colsLastInSubGroup.Position = 8;
            resources.ApplyResources(this.tblExtFileTypeRec_colsLastInSubGroup, "tblExtFileTypeRec_colsLastInSubGroup");
            this.tblExtFileTypeRec_colsLastInSubGroup.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblExtFileTypeRec_colsLastInSubGroup_WindowActions);
            // 
            // tblExtFileTypeRec_colsMandatoryRecord
            // 
            this.tblExtFileTypeRec_colsMandatoryRecord.MaxLength = 5;
            this.tblExtFileTypeRec_colsMandatoryRecord.Name = "tblExtFileTypeRec_colsMandatoryRecord";
            this.tblExtFileTypeRec_colsMandatoryRecord.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTypeRec_colsMandatoryRecord.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTypeRec_colsMandatoryRecord.NamedProperties.Put("LovReference", "");
            this.tblExtFileTypeRec_colsMandatoryRecord.NamedProperties.Put("SqlColumn", "MANDATORY_RECORD");
            this.tblExtFileTypeRec_colsMandatoryRecord.Position = 9;
            resources.ApplyResources(this.tblExtFileTypeRec_colsMandatoryRecord, "tblExtFileTypeRec_colsMandatoryRecord");
            this.tblExtFileTypeRec_colsMandatoryRecord.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblExtFileTypeRec_colsMandatoryRecord_WindowActions);
            // 
            // tblExtFileTypeRec_colsParentRecordType
            // 
            this.tblExtFileTypeRec_colsParentRecordType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblExtFileTypeRec_colsParentRecordType.MaxLength = 20;
            this.tblExtFileTypeRec_colsParentRecordType.Name = "tblExtFileTypeRec_colsParentRecordType";
            this.tblExtFileTypeRec_colsParentRecordType.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTypeRec_colsParentRecordType.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTypeRec_colsParentRecordType.NamedProperties.Put("LovReference", "");
            this.tblExtFileTypeRec_colsParentRecordType.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTypeRec_colsParentRecordType.NamedProperties.Put("SqlColumn", "PARENT_RECORD_TYPE");
            this.tblExtFileTypeRec_colsParentRecordType.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTypeRec_colsParentRecordType.Position = 10;
            resources.ApplyResources(this.tblExtFileTypeRec_colsParentRecordType, "tblExtFileTypeRec_colsParentRecordType");
            this.tblExtFileTypeRec_colsParentRecordType.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblExtFileTypeRec_colsParentRecordType_WindowActions);
            // 
            // tblExtFileTypeRec_colsViewName
            // 
            this.tblExtFileTypeRec_colsViewName.MaxLength = 30;
            this.tblExtFileTypeRec_colsViewName.Name = "tblExtFileTypeRec_colsViewName";
            this.tblExtFileTypeRec_colsViewName.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTypeRec_colsViewName.NamedProperties.Put("FieldFlags", "260");
            this.tblExtFileTypeRec_colsViewName.NamedProperties.Put("LovReference", "");
            this.tblExtFileTypeRec_colsViewName.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTypeRec_colsViewName.NamedProperties.Put("SqlColumn", "VIEW_NAME");
            this.tblExtFileTypeRec_colsViewName.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTypeRec_colsViewName.Position = 11;
            resources.ApplyResources(this.tblExtFileTypeRec_colsViewName, "tblExtFileTypeRec_colsViewName");
            this.tblExtFileTypeRec_colsViewName.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblExtFileTypeRec_colsViewName_WindowActions);
            // 
            // tblExtFileTypeRec_colsInputPackage
            // 
            this.tblExtFileTypeRec_colsInputPackage.MaxLength = 30;
            this.tblExtFileTypeRec_colsInputPackage.Name = "tblExtFileTypeRec_colsInputPackage";
            this.tblExtFileTypeRec_colsInputPackage.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTypeRec_colsInputPackage.NamedProperties.Put("FieldFlags", "260");
            this.tblExtFileTypeRec_colsInputPackage.NamedProperties.Put("LovReference", "");
            this.tblExtFileTypeRec_colsInputPackage.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTypeRec_colsInputPackage.NamedProperties.Put("SqlColumn", "INPUT_PACKAGE");
            this.tblExtFileTypeRec_colsInputPackage.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTypeRec_colsInputPackage.Position = 12;
            resources.ApplyResources(this.tblExtFileTypeRec_colsInputPackage, "tblExtFileTypeRec_colsInputPackage");
            this.tblExtFileTypeRec_colsInputPackage.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblExtFileTypeRec_colsInputPackage_WindowActions);
            // 
            // frmExternalFileTypeDefinition
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.tblExtFileTypeRec);
            this.Controls.Add(this.dfsTargetDefaultMethod);
            this.Controls.Add(this.dfsFormName);
            this.Controls.Add(this.dfsViewName);
            this.Controls.Add(this.dfsInputPackage);
            this.Controls.Add(this.dfsApiToCallOutput);
            this.Controls.Add(this.dfsApiToCallInput);
            this.Controls.Add(this.dfsComponent);
            this.Controls.Add(this.cbSystemDefined);
            this.Controls.Add(this.dfsDescription);
            this.Controls.Add(this.ccsFileType);
            this.Controls.Add(this.labeldfsTargetDefaultMethod);
            this.Controls.Add(this.labeldfsFormName);
            this.Controls.Add(this.labeldfsViewName);
            this.Controls.Add(this.labeldfsInputPackage);
            this.Controls.Add(this.labeldfsApiToCallOutput);
            this.Controls.Add(this.labeldfsApiToCallInput);
            this.Controls.Add(this.labeldfsComponent);
            this.Controls.Add(this.labeldfsDescription);
            this.Controls.Add(this.labelccsFileType);
            this.Name = "frmExternalFileTypeDefinition";
            this.NamedProperties.Put("DefaultOrderBy", "FILE_TYPE");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "ExtFileType");
            this.NamedProperties.Put("PackageName", "EXT_FILE_TYPE_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "16833");
            this.NamedProperties.Put("ViewName", "EXT_FILE_TYPE");
            this.NamedProperties.Put("Warnings", "TRUE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.frmExternalFileTypeDefinition_WindowActions);
            this.menuFrmMethods.ResumeLayout(false);
            this.menuTblMethods.ResumeLayout(false);
            this.tblExtFileTypeRec.ResumeLayout(false);
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
		
		public Fnd.Windows.Forms.FndCommand menuTblMethods_menuExternal_File_Column__Definition;
        public Fnd.Windows.Forms.FndCommand menuTblMethods_menuCreate_Details_From__View_Defini;
        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menu_External_File_Template___;
        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menuExternal_File_Type__Parameter_De;
        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menuExternal_File__Load_Parameters__;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuFrmMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__External;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_External;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_External_1;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTblMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_External_2;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Create;
        public Accrul.cChildTableFinBase tblExtFileTypeRec;
        protected cColumn tblExtFileTypeRec_colsFileType;
        protected cColumn tblExtFileTypeRec_colsGroupId;
        protected cColumn tblExtFileTypeRec_colsDescription;
        protected cColumn tblExtFileTypeRec_colsSubGroupId;
        protected cCheckBoxColumn tblExtFileTypeRec_colsFirstInSubGroup;
        protected cCheckBoxColumn tblExtFileTypeRec_colsLastInSubGroup;
        protected cCheckBoxColumn tblExtFileTypeRec_colsMandatoryRecord;
        protected cColumn tblExtFileTypeRec_colsParentRecordType;
        protected cColumn tblExtFileTypeRec_colsViewName;
        protected cColumn tblExtFileTypeRec_colsInputPackage;
	}
}
