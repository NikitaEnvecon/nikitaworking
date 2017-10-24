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
	
	public partial class frmExternalFileTypeRecColumn
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		protected cBackgroundText labeldfsFileType;
		public cRecListDataField dfsFileType;
		protected cBackgroundText labeldfFileTypeName;
		public cDataField dfFileTypeName;
		protected cBackgroundText labeldfsGroupId;
		public cDataField dfsGroupId;
		protected cBackgroundText labeldfsDescription;
		public cDataField dfsDescription;
		protected cBackgroundText labeldfsSubGroupId;
		public cDataField dfsSubGroupId;
		public cCheckBox cbFirstInSubGroup;
		public cCheckBox cbLastInSubGroup;
		public cCheckBoxFin cbSystemDefined;
		protected cBackgroundText labeldfExtFileTypeView_Name;
		public cDataField dfExtFileTypeView_Name;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExternalFileTypeRecColumn));
            this.menuFrmMethods_menu_External_File_Template___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.labeldfsFileType = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsFileType = new Ifs.Fnd.ApplicationForms.cRecListDataField();
            this.labeldfFileTypeName = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfFileTypeName = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsGroupId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsGroupId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsDescription = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsDescription = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsSubGroupId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsSubGroupId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.cbFirstInSubGroup = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.cbLastInSubGroup = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.cbSystemDefined = new Ifs.Application.Accrul.cCheckBoxFin();
            this.labeldfExtFileTypeView_Name = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfExtFileTypeView_Name = new Ifs.Fnd.ApplicationForms.cDataField();
            this.menuFrmMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem__External = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.tblExtFileTypeRecColumn = new Ifs.Application.Accrul.cChildTableFinBase();
            this.tblExtFileTypeRecColumn_colsFileType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExtFileTypeRecColumn_colsGroupId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExtFileTypeRecColumn_colsColumnId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExtFileTypeRecColumn_colsDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExtFileTypeRecColumn_colsMandatory = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.tblExtFileTypeRecColumn_colsDataType = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.tblExtFileTypeRecColumn_colsDestinationColumn = new Ifs.Fnd.ApplicationForms.cColumn();
            this.menuFrmMethods.SuspendLayout();
            this.tblExtFileTypeRecColumn.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuFrmMethods_menu_External_File_Template___);
            this.commandManager.ContextMenus.Add(this.menuFrmMethods);
            // 
            // menuFrmMethods_menu_External_File_Template___
            // 
            resources.ApplyResources(this.menuFrmMethods_menu_External_File_Template___, "menuFrmMethods_menu_External_File_Template___");
            this.menuFrmMethods_menu_External_File_Template___.Name = "menuFrmMethods_menu_External_File_Template___";
            this.menuFrmMethods_menu_External_File_Template___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__External_Execute);
            this.menuFrmMethods_menu_External_File_Template___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__External_Inquire);
            // 
            // labeldfsFileType
            // 
            resources.ApplyResources(this.labeldfsFileType, "labeldfsFileType");
            this.labeldfsFileType.Name = "labeldfsFileType";
            // 
            // dfsFileType
            // 
            resources.ApplyResources(this.dfsFileType, "dfsFileType");
            this.dfsFileType.Name = "dfsFileType";
            this.dfsFileType.NamedProperties.Put("EnumerateMethod", "");
            this.dfsFileType.NamedProperties.Put("LovReference", "");
            this.dfsFileType.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsFileType.NamedProperties.Put("SqlColumn", "FILE_TYPE");
            this.dfsFileType.NamedProperties.Put("ValidateMethod", "");
            this.dfsFileType.NamedProperties.Put("XDataLength", "");
            // 
            // labeldfFileTypeName
            // 
            resources.ApplyResources(this.labeldfFileTypeName, "labeldfFileTypeName");
            this.labeldfFileTypeName.Name = "labeldfFileTypeName";
            // 
            // dfFileTypeName
            // 
            resources.ApplyResources(this.dfFileTypeName, "dfFileTypeName");
            this.dfFileTypeName.Name = "dfFileTypeName";
            this.dfFileTypeName.NamedProperties.Put("EnumerateMethod", "");
            this.dfFileTypeName.NamedProperties.Put("LovReference", "");
            this.dfFileTypeName.NamedProperties.Put("ParentName", "dfsFileType");
            this.dfFileTypeName.NamedProperties.Put("ResizeableChildObject", "");
            this.dfFileTypeName.NamedProperties.Put("SqlColumn", "Ext_File_Type_API.Get_Description(FILE_TYPE)");
            this.dfFileTypeName.NamedProperties.Put("ValidateMethod", "");
            this.dfFileTypeName.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfFileTypeName_WindowActions);
            // 
            // labeldfsGroupId
            // 
            resources.ApplyResources(this.labeldfsGroupId, "labeldfsGroupId");
            this.labeldfsGroupId.Name = "labeldfsGroupId";
            // 
            // dfsGroupId
            // 
            this.dfsGroupId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsGroupId, "dfsGroupId");
            this.dfsGroupId.Name = "dfsGroupId";
            this.dfsGroupId.NamedProperties.Put("EnumerateMethod", "");
            this.dfsGroupId.NamedProperties.Put("FieldFlags", "163");
            this.dfsGroupId.NamedProperties.Put("LovReference", "");
            this.dfsGroupId.NamedProperties.Put("ParentName", "dfsFileType");
            this.dfsGroupId.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsGroupId.NamedProperties.Put("SqlColumn", "RECORD_TYPE_ID");
            this.dfsGroupId.NamedProperties.Put("ValidateMethod", "");
            this.dfsGroupId.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsGroupId_WindowActions);
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
            this.dfsDescription.NamedProperties.Put("FieldFlags", "294");
            this.dfsDescription.NamedProperties.Put("LovReference", "");
            this.dfsDescription.NamedProperties.Put("ParentName", "dfsFileType");
            this.dfsDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsDescription.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            this.dfsDescription.NamedProperties.Put("ValidateMethod", "");
            this.dfsDescription.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsDescription_WindowActions);
            // 
            // labeldfsSubGroupId
            // 
            resources.ApplyResources(this.labeldfsSubGroupId, "labeldfsSubGroupId");
            this.labeldfsSubGroupId.Name = "labeldfsSubGroupId";
            // 
            // dfsSubGroupId
            // 
            resources.ApplyResources(this.dfsSubGroupId, "dfsSubGroupId");
            this.dfsSubGroupId.Name = "dfsSubGroupId";
            this.dfsSubGroupId.NamedProperties.Put("EnumerateMethod", "");
            this.dfsSubGroupId.NamedProperties.Put("FieldFlags", "295");
            this.dfsSubGroupId.NamedProperties.Put("LovReference", "");
            this.dfsSubGroupId.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsSubGroupId.NamedProperties.Put("SqlColumn", "RECORD_SET_ID");
            this.dfsSubGroupId.NamedProperties.Put("ValidateMethod", "");
            this.dfsSubGroupId.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsSubGroupId_WindowActions);
            // 
            // cbFirstInSubGroup
            // 
            resources.ApplyResources(this.cbFirstInSubGroup, "cbFirstInSubGroup");
            this.cbFirstInSubGroup.Name = "cbFirstInSubGroup";
            this.cbFirstInSubGroup.NamedProperties.Put("DataType", "5");
            this.cbFirstInSubGroup.NamedProperties.Put("EnumerateMethod", "");
            this.cbFirstInSubGroup.NamedProperties.Put("FieldFlags", "295");
            this.cbFirstInSubGroup.NamedProperties.Put("LovReference", "");
            this.cbFirstInSubGroup.NamedProperties.Put("ResizeableChildObject", "");
            this.cbFirstInSubGroup.NamedProperties.Put("SqlColumn", "FIRST_IN_RECORD_SET");
            this.cbFirstInSubGroup.NamedProperties.Put("ValidateMethod", "");
            this.cbFirstInSubGroup.NamedProperties.Put("XDataLength", "5");
            this.cbFirstInSubGroup.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cbFirstInSubGroup_WindowActions);
            // 
            // cbLastInSubGroup
            // 
            resources.ApplyResources(this.cbLastInSubGroup, "cbLastInSubGroup");
            this.cbLastInSubGroup.Name = "cbLastInSubGroup";
            this.cbLastInSubGroup.NamedProperties.Put("DataType", "5");
            this.cbLastInSubGroup.NamedProperties.Put("EnumerateMethod", "");
            this.cbLastInSubGroup.NamedProperties.Put("FieldFlags", "295");
            this.cbLastInSubGroup.NamedProperties.Put("LovReference", "");
            this.cbLastInSubGroup.NamedProperties.Put("ResizeableChildObject", "");
            this.cbLastInSubGroup.NamedProperties.Put("SqlColumn", "LAST_IN_RECORD_SET");
            this.cbLastInSubGroup.NamedProperties.Put("ValidateMethod", "");
            this.cbLastInSubGroup.NamedProperties.Put("XDataLength", "5");
            this.cbLastInSubGroup.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cbLastInSubGroup_WindowActions);
            // 
            // cbSystemDefined
            // 
            resources.ApplyResources(this.cbSystemDefined, "cbSystemDefined");
            this.cbSystemDefined.Name = "cbSystemDefined";
            this.cbSystemDefined.NamedProperties.Put("DataType", "7");
            this.cbSystemDefined.NamedProperties.Put("EnumerateMethod", "");
            this.cbSystemDefined.NamedProperties.Put("FieldFlags", "291");
            this.cbSystemDefined.NamedProperties.Put("LovReference", "");
            this.cbSystemDefined.NamedProperties.Put("ResizeableChildObject", "");
            this.cbSystemDefined.NamedProperties.Put("SqlColumn", "EXT_FILE_TYPE_API.Get_System_Defined(FILE_TYPE)");
            this.cbSystemDefined.NamedProperties.Put("ValidateMethod", "");
            this.cbSystemDefined.NamedProperties.Put("XDataLength", "2000");
            this.cbSystemDefined.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cbSystemDefined_WindowActions);
            // 
            // labeldfExtFileTypeView_Name
            // 
            resources.ApplyResources(this.labeldfExtFileTypeView_Name, "labeldfExtFileTypeView_Name");
            this.labeldfExtFileTypeView_Name.Name = "labeldfExtFileTypeView_Name";
            // 
            // dfExtFileTypeView_Name
            // 
            resources.ApplyResources(this.dfExtFileTypeView_Name, "dfExtFileTypeView_Name");
            this.dfExtFileTypeView_Name.Name = "dfExtFileTypeView_Name";
            this.dfExtFileTypeView_Name.NamedProperties.Put("EnumerateMethod", "");
            this.dfExtFileTypeView_Name.NamedProperties.Put("FieldFlags", "272");
            this.dfExtFileTypeView_Name.NamedProperties.Put("LovReference", "");
            this.dfExtFileTypeView_Name.NamedProperties.Put("SqlColumn", "EXT_FILE_TYPE_API.Get_View_Name(FILE_TYPE)");
            this.dfExtFileTypeView_Name.NamedProperties.Put("ValidateMethod", "");
            // 
            // menuFrmMethods
            // 
            this.menuFrmMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem__External});
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
            // tblExtFileTypeRecColumn
            // 
            this.tblExtFileTypeRecColumn.Controls.Add(this.tblExtFileTypeRecColumn_colsFileType);
            this.tblExtFileTypeRecColumn.Controls.Add(this.tblExtFileTypeRecColumn_colsGroupId);
            this.tblExtFileTypeRecColumn.Controls.Add(this.tblExtFileTypeRecColumn_colsColumnId);
            this.tblExtFileTypeRecColumn.Controls.Add(this.tblExtFileTypeRecColumn_colsDescription);
            this.tblExtFileTypeRecColumn.Controls.Add(this.tblExtFileTypeRecColumn_colsMandatory);
            this.tblExtFileTypeRecColumn.Controls.Add(this.tblExtFileTypeRecColumn_colsDataType);
            this.tblExtFileTypeRecColumn.Controls.Add(this.tblExtFileTypeRecColumn_colsDestinationColumn);
            resources.ApplyResources(this.tblExtFileTypeRecColumn, "tblExtFileTypeRecColumn");
            this.tblExtFileTypeRecColumn.Name = "tblExtFileTypeRecColumn";
            this.tblExtFileTypeRecColumn.NamedProperties.Put("DefaultOrderBy", "RECORD_TYPE_ID,COLUMN_ID");
            this.tblExtFileTypeRecColumn.NamedProperties.Put("DefaultWhere", "");
            this.tblExtFileTypeRecColumn.NamedProperties.Put("LogicalUnit", "ExtFileTypeRecColumn");
            this.tblExtFileTypeRecColumn.NamedProperties.Put("PackageName", "EXT_FILE_TYPE_REC_COLUMN_API");
            this.tblExtFileTypeRecColumn.NamedProperties.Put("ResizeableChildObject", "LLMM");
            this.tblExtFileTypeRecColumn.NamedProperties.Put("ViewName", "EXT_FILE_TYPE_REC_COLUMN");
            this.tblExtFileTypeRecColumn.NamedProperties.Put("Warnings", "FALSE");
            this.tblExtFileTypeRecColumn.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblExtFileTypeRecColumn_WindowActions);
            this.tblExtFileTypeRecColumn.Controls.SetChildIndex(this.tblExtFileTypeRecColumn_colsDestinationColumn, 0);
            this.tblExtFileTypeRecColumn.Controls.SetChildIndex(this.tblExtFileTypeRecColumn_colsDataType, 0);
            this.tblExtFileTypeRecColumn.Controls.SetChildIndex(this.tblExtFileTypeRecColumn_colsMandatory, 0);
            this.tblExtFileTypeRecColumn.Controls.SetChildIndex(this.tblExtFileTypeRecColumn_colsDescription, 0);
            this.tblExtFileTypeRecColumn.Controls.SetChildIndex(this.tblExtFileTypeRecColumn_colsColumnId, 0);
            this.tblExtFileTypeRecColumn.Controls.SetChildIndex(this.tblExtFileTypeRecColumn_colsGroupId, 0);
            this.tblExtFileTypeRecColumn.Controls.SetChildIndex(this.tblExtFileTypeRecColumn_colsFileType, 0);
            // 
            // tblExtFileTypeRecColumn_colsFileType
            // 
            resources.ApplyResources(this.tblExtFileTypeRecColumn_colsFileType, "tblExtFileTypeRecColumn_colsFileType");
            this.tblExtFileTypeRecColumn_colsFileType.MaxLength = 30;
            this.tblExtFileTypeRecColumn_colsFileType.Name = "tblExtFileTypeRecColumn_colsFileType";
            this.tblExtFileTypeRecColumn_colsFileType.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTypeRecColumn_colsFileType.NamedProperties.Put("FieldFlags", "67");
            this.tblExtFileTypeRecColumn_colsFileType.NamedProperties.Put("LovReference", "");
            this.tblExtFileTypeRecColumn_colsFileType.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTypeRecColumn_colsFileType.NamedProperties.Put("SqlColumn", "FILE_TYPE");
            this.tblExtFileTypeRecColumn_colsFileType.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTypeRecColumn_colsFileType.Position = 3;
            this.tblExtFileTypeRecColumn_colsFileType.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblExtFileTypeRecColumn_colsFileType_WindowActions);
            // 
            // tblExtFileTypeRecColumn_colsGroupId
            // 
            resources.ApplyResources(this.tblExtFileTypeRecColumn_colsGroupId, "tblExtFileTypeRecColumn_colsGroupId");
            this.tblExtFileTypeRecColumn_colsGroupId.MaxLength = 20;
            this.tblExtFileTypeRecColumn_colsGroupId.Name = "tblExtFileTypeRecColumn_colsGroupId";
            this.tblExtFileTypeRecColumn_colsGroupId.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTypeRecColumn_colsGroupId.NamedProperties.Put("FieldFlags", "67");
            this.tblExtFileTypeRecColumn_colsGroupId.NamedProperties.Put("LovReference", "");
            this.tblExtFileTypeRecColumn_colsGroupId.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTypeRecColumn_colsGroupId.NamedProperties.Put("SqlColumn", "RECORD_TYPE_ID");
            this.tblExtFileTypeRecColumn_colsGroupId.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTypeRecColumn_colsGroupId.Position = 4;
            this.tblExtFileTypeRecColumn_colsGroupId.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblExtFileTypeRecColumn_colsGroupId_WindowActions);
            // 
            // tblExtFileTypeRecColumn_colsColumnId
            // 
            this.tblExtFileTypeRecColumn_colsColumnId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblExtFileTypeRecColumn_colsColumnId.MaxLength = 30;
            this.tblExtFileTypeRecColumn_colsColumnId.Name = "tblExtFileTypeRecColumn_colsColumnId";
            this.tblExtFileTypeRecColumn_colsColumnId.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTypeRecColumn_colsColumnId.NamedProperties.Put("FieldFlags", "163");
            this.tblExtFileTypeRecColumn_colsColumnId.NamedProperties.Put("LovReference", "EXT_FILE_VIEW_LOV");
            this.tblExtFileTypeRecColumn_colsColumnId.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTypeRecColumn_colsColumnId.NamedProperties.Put("SqlColumn", "COLUMN_ID");
            this.tblExtFileTypeRecColumn_colsColumnId.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTypeRecColumn_colsColumnId.Position = 5;
            resources.ApplyResources(this.tblExtFileTypeRecColumn_colsColumnId, "tblExtFileTypeRecColumn_colsColumnId");
            this.tblExtFileTypeRecColumn_colsColumnId.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblExtFileTypeRecColumn_colsColumnId_WindowActions);
            // 
            // tblExtFileTypeRecColumn_colsDescription
            // 
            this.tblExtFileTypeRecColumn_colsDescription.MaxLength = 200;
            this.tblExtFileTypeRecColumn_colsDescription.Name = "tblExtFileTypeRecColumn_colsDescription";
            this.tblExtFileTypeRecColumn_colsDescription.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTypeRecColumn_colsDescription.NamedProperties.Put("FieldFlags", "295");
            this.tblExtFileTypeRecColumn_colsDescription.NamedProperties.Put("LovReference", "");
            this.tblExtFileTypeRecColumn_colsDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTypeRecColumn_colsDescription.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            this.tblExtFileTypeRecColumn_colsDescription.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTypeRecColumn_colsDescription.Position = 6;
            resources.ApplyResources(this.tblExtFileTypeRecColumn_colsDescription, "tblExtFileTypeRecColumn_colsDescription");
            this.tblExtFileTypeRecColumn_colsDescription.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblExtFileTypeRecColumn_colsDescription_WindowActions);
            // 
            // tblExtFileTypeRecColumn_colsMandatory
            // 
            this.tblExtFileTypeRecColumn_colsMandatory.MaxLength = 5;
            this.tblExtFileTypeRecColumn_colsMandatory.Name = "tblExtFileTypeRecColumn_colsMandatory";
            this.tblExtFileTypeRecColumn_colsMandatory.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTypeRecColumn_colsMandatory.NamedProperties.Put("FieldFlags", "295");
            this.tblExtFileTypeRecColumn_colsMandatory.NamedProperties.Put("LovReference", "");
            this.tblExtFileTypeRecColumn_colsMandatory.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTypeRecColumn_colsMandatory.NamedProperties.Put("SqlColumn", "MANDATORY");
            this.tblExtFileTypeRecColumn_colsMandatory.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTypeRecColumn_colsMandatory.Position = 7;
            resources.ApplyResources(this.tblExtFileTypeRecColumn_colsMandatory, "tblExtFileTypeRecColumn_colsMandatory");
            this.tblExtFileTypeRecColumn_colsMandatory.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblExtFileTypeRecColumn_colsMandatory_WindowActions);
            // 
            // tblExtFileTypeRecColumn_colsDataType
            // 
            this.tblExtFileTypeRecColumn_colsDataType.MaxLength = 200;
            this.tblExtFileTypeRecColumn_colsDataType.Name = "tblExtFileTypeRecColumn_colsDataType";
            this.tblExtFileTypeRecColumn_colsDataType.NamedProperties.Put("EnumerateMethod", "EXTY_DATA_TYPE_API.Enumerate");
            this.tblExtFileTypeRecColumn_colsDataType.NamedProperties.Put("FieldFlags", "295");
            this.tblExtFileTypeRecColumn_colsDataType.NamedProperties.Put("LovReference", "");
            this.tblExtFileTypeRecColumn_colsDataType.NamedProperties.Put("SqlColumn", "DATA_TYPE");
            this.tblExtFileTypeRecColumn_colsDataType.Position = 8;
            resources.ApplyResources(this.tblExtFileTypeRecColumn_colsDataType, "tblExtFileTypeRecColumn_colsDataType");
            this.tblExtFileTypeRecColumn_colsDataType.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblExtFileTypeRecColumn_colsDataType_WindowActions);
            // 
            // tblExtFileTypeRecColumn_colsDestinationColumn
            // 
            this.tblExtFileTypeRecColumn_colsDestinationColumn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblExtFileTypeRecColumn_colsDestinationColumn.MaxLength = 30;
            this.tblExtFileTypeRecColumn_colsDestinationColumn.Name = "tblExtFileTypeRecColumn_colsDestinationColumn";
            this.tblExtFileTypeRecColumn_colsDestinationColumn.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTypeRecColumn_colsDestinationColumn.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTypeRecColumn_colsDestinationColumn.NamedProperties.Put("LovReference", "");
            this.tblExtFileTypeRecColumn_colsDestinationColumn.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTypeRecColumn_colsDestinationColumn.NamedProperties.Put("SqlColumn", "DESTINATION_COLUMN");
            this.tblExtFileTypeRecColumn_colsDestinationColumn.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTypeRecColumn_colsDestinationColumn.Position = 9;
            resources.ApplyResources(this.tblExtFileTypeRecColumn_colsDestinationColumn, "tblExtFileTypeRecColumn_colsDestinationColumn");
            this.tblExtFileTypeRecColumn_colsDestinationColumn.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblExtFileTypeRecColumn_colsDestinationColumn_WindowActions);
            // 
            // frmExternalFileTypeRecColumn
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.tblExtFileTypeRecColumn);
            this.Controls.Add(this.dfExtFileTypeView_Name);
            this.Controls.Add(this.cbSystemDefined);
            this.Controls.Add(this.cbLastInSubGroup);
            this.Controls.Add(this.cbFirstInSubGroup);
            this.Controls.Add(this.dfsSubGroupId);
            this.Controls.Add(this.dfsDescription);
            this.Controls.Add(this.dfsGroupId);
            this.Controls.Add(this.dfFileTypeName);
            this.Controls.Add(this.dfsFileType);
            this.Controls.Add(this.labeldfExtFileTypeView_Name);
            this.Controls.Add(this.labeldfsSubGroupId);
            this.Controls.Add(this.labeldfsDescription);
            this.Controls.Add(this.labeldfsGroupId);
            this.Controls.Add(this.labeldfFileTypeName);
            this.Controls.Add(this.labeldfsFileType);
            this.Name = "frmExternalFileTypeRecColumn";
            this.NamedProperties.Put("DefaultOrderBy", "FILE_TYPE,RECORD_TYPE_ID");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "ExtFileTypeGroup");
            this.NamedProperties.Put("PackageName", "EXT_FILE_TYPE_REC_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "1");
            this.NamedProperties.Put("ViewName", "EXT_FILE_TYPE_REC");
            this.NamedProperties.Put("Warnings", "TRUE");
            this.menuFrmMethods.ResumeLayout(false);
            this.tblExtFileTypeRecColumn.ResumeLayout(false);
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
		
        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menu_External_File_Template___;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuFrmMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__External;
        public cChildTableFinBase tblExtFileTypeRecColumn;
        protected cColumn tblExtFileTypeRecColumn_colsFileType;
        protected cColumn tblExtFileTypeRecColumn_colsGroupId;
        protected cColumn tblExtFileTypeRecColumn_colsColumnId;
        protected cColumn tblExtFileTypeRecColumn_colsDescription;
        protected cCheckBoxColumn tblExtFileTypeRecColumn_colsMandatory;
        protected cLookupColumn tblExtFileTypeRecColumn_colsDataType;
        protected cColumn tblExtFileTypeRecColumn_colsDestinationColumn;
	}
}
