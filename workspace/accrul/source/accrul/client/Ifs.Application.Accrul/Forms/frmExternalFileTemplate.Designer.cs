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

namespace Ifs.Application.Accrul
{
	
	public partial class frmExternalFileTemplate
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		// Head
		protected cBackgroundText labelccsFileTemplateId;
		public cRecListDataField ccsFileTemplateId;
		protected cBackgroundText labeldfsDescription;
		public cDataField dfsDescription;
		protected cBackgroundText labeldfsFileType;
		public cDataField dfsFileType;
		protected cBackgroundText labeldfExtFileTypeDescription;
		public cDataField dfExtFileTypeDescription;
		public cCheckBoxFin cbValidDefinition;
		public cCheckBox cbActiveDefinition;
		public cCheckBoxFin cbSystemDefined;
		protected SalGroupBox gbLine_Type;
		protected cBackgroundText labelcmbFileFormat;
		public cComboBox cmbFileFormat;
		public cCheckBoxFin cbSeparated;
		protected cBackgroundText labeldfsSeparatorId;
		public cDataField dfsSeparatorId;
		protected cBackgroundText labeldfExtFileSeparatorDescription;
		public cDataField dfExtFileSeparatorDescription;
		protected cBackgroundText labeldfsTextQualifier;
		public cDataField dfsTextQualifier;
		protected SalGroupBox gbNumber_Columns;
		protected cBackgroundText labeldfsDecimalSymbol;
		public cDataField dfsDecimalSymbol;
		protected cBackgroundText labeldfsDenominator;
		public cDataField dfsDenominator;
		protected SalGroupBox gbDate_Columns;
		protected cBackgroundText labeldfsDateFormat;
		public cDataField dfsDateFormat;
		protected cBackgroundText labeldfsDateNlsCalendar;
		public cDataField dfsDateNlsCalendar;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExternalFileTemplate));
            this.menuFrmMethods_menuExternal_File_Separator___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuFrmMethods_menuCheck_If_Definition_is_Valid = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.labelccsFileTemplateId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.ccsFileTemplateId = new Ifs.Fnd.ApplicationForms.cRecListDataField();
            this.labeldfsDescription = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsDescription = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsFileType = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsFileType = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfExtFileTypeDescription = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfExtFileTypeDescription = new Ifs.Fnd.ApplicationForms.cDataField();
            this.cbActiveDefinition = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.gbLine_Type = new PPJ.Runtime.Windows.SalGroupBox();
            this.labelcmbFileFormat = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbFileFormat = new Ifs.Fnd.ApplicationForms.cComboBox();
            this.labeldfsSeparatorId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsSeparatorId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfExtFileSeparatorDescription = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfExtFileSeparatorDescription = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsTextQualifier = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsTextQualifier = new Ifs.Fnd.ApplicationForms.cDataField();
            this.gbNumber_Columns = new PPJ.Runtime.Windows.SalGroupBox();
            this.labeldfsDecimalSymbol = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsDecimalSymbol = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsDenominator = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsDenominator = new Ifs.Fnd.ApplicationForms.cDataField();
            this.gbDate_Columns = new PPJ.Runtime.Windows.SalGroupBox();
            this.labeldfsDateFormat = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsDateFormat = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsDateNlsCalendar = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsDateNlsCalendar = new Ifs.Fnd.ApplicationForms.cDataField();
            this.menuFrmMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_External = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem_Check = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.cbSeparated = new Ifs.Application.Accrul.cCheckBoxFin();
            this.cbSystemDefined = new Ifs.Application.Accrul.cCheckBoxFin();
            this.cbValidDefinition = new Ifs.Application.Accrul.cCheckBoxFin();
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
            this.commandManager.Commands.Add(this.menuFrmMethods_menuExternal_File_Separator___);
            this.commandManager.Commands.Add(this.menuFrmMethods_menuCheck_If_Definition_is_Valid);
            this.commandManager.ContextMenus.Add(this.menuFrmMethods);
            // 
            // menuFrmMethods_menuExternal_File_Separator___
            // 
            resources.ApplyResources(this.menuFrmMethods_menuExternal_File_Separator___, "menuFrmMethods_menuExternal_File_Separator___");
            this.menuFrmMethods_menuExternal_File_Separator___.Name = "menuFrmMethods_menuExternal_File_Separator___";
            this.menuFrmMethods_menuExternal_File_Separator___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_External_Execute);
            this.menuFrmMethods_menuExternal_File_Separator___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_External_Inquire);
            // 
            // menuFrmMethods_menuCheck_If_Definition_is_Valid
            // 
            resources.ApplyResources(this.menuFrmMethods_menuCheck_If_Definition_is_Valid, "menuFrmMethods_menuCheck_If_Definition_is_Valid");
            this.menuFrmMethods_menuCheck_If_Definition_is_Valid.Name = "menuFrmMethods_menuCheck_If_Definition_is_Valid";
            this.menuFrmMethods_menuCheck_If_Definition_is_Valid.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Check_Execute);
            this.menuFrmMethods_menuCheck_If_Definition_is_Valid.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Check_Inquire);
            // 
            // labelccsFileTemplateId
            // 
            resources.ApplyResources(this.labelccsFileTemplateId, "labelccsFileTemplateId");
            this.labelccsFileTemplateId.Name = "labelccsFileTemplateId";
            // 
            // ccsFileTemplateId
            // 
            resources.ApplyResources(this.ccsFileTemplateId, "ccsFileTemplateId");
            this.ccsFileTemplateId.Name = "ccsFileTemplateId";
            this.ccsFileTemplateId.NamedProperties.Put("EnumerateMethod", "");
            this.ccsFileTemplateId.NamedProperties.Put("FieldFlags", "163");
            this.ccsFileTemplateId.NamedProperties.Put("LovReference", "");
            this.ccsFileTemplateId.NamedProperties.Put("ResizeableChildObject", "");
            this.ccsFileTemplateId.NamedProperties.Put("SqlColumn", "FILE_TEMPLATE_ID");
            this.ccsFileTemplateId.NamedProperties.Put("ValidateMethod", "");
            this.ccsFileTemplateId.NamedProperties.Put("XDataLength", "30");
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
            this.dfsDescription.NamedProperties.Put("ParentName", "ccsFileTemplateId");
            this.dfsDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsDescription.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            this.dfsDescription.NamedProperties.Put("ValidateMethod", "");
            this.dfsDescription.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsDescription_WindowActions);
            // 
            // labeldfsFileType
            // 
            resources.ApplyResources(this.labeldfsFileType, "labeldfsFileType");
            this.labeldfsFileType.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeldfsFileType, "Name0;Name1;Name2;Name3");
            this.labeldfsFileType.Name = "labeldfsFileType";
            // 
            // dfsFileType
            // 
            this.picTab.SetControlTabPages(this.dfsFileType, "Name0;Name1;Name2;Name3");
            resources.ApplyResources(this.dfsFileType, "dfsFileType");
            this.dfsFileType.Name = "dfsFileType";
            this.dfsFileType.NamedProperties.Put("EnumerateMethod", "");
            this.dfsFileType.NamedProperties.Put("FieldFlags", "291");
            this.dfsFileType.NamedProperties.Put("LovReference", "EXT_FILE_TYPE");
            this.dfsFileType.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsFileType.NamedProperties.Put("SqlColumn", "FILE_TYPE");
            this.dfsFileType.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfExtFileTypeDescription
            // 
            resources.ApplyResources(this.labeldfExtFileTypeDescription, "labeldfExtFileTypeDescription");
            this.labeldfExtFileTypeDescription.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeldfExtFileTypeDescription, "Name0;Name1;Name2;Name3");
            this.labeldfExtFileTypeDescription.Name = "labeldfExtFileTypeDescription";
            // 
            // dfExtFileTypeDescription
            // 
            this.picTab.SetControlTabPages(this.dfExtFileTypeDescription, "Name0;Name1;Name2;Name3");
            resources.ApplyResources(this.dfExtFileTypeDescription, "dfExtFileTypeDescription");
            this.dfExtFileTypeDescription.Name = "dfExtFileTypeDescription";
            this.dfExtFileTypeDescription.NamedProperties.Put("EnumerateMethod", "");
            this.dfExtFileTypeDescription.NamedProperties.Put("FieldFlags", "272");
            this.dfExtFileTypeDescription.NamedProperties.Put("LovReference", "");
            this.dfExtFileTypeDescription.NamedProperties.Put("ParentName", "dfsFileType");
            this.dfExtFileTypeDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.dfExtFileTypeDescription.NamedProperties.Put("SqlColumn", "EXT_FILE_TYPE_API.Get_Description(FILE_TYPE)");
            this.dfExtFileTypeDescription.NamedProperties.Put("ValidateMethod", "");
            this.dfExtFileTypeDescription.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfExtFileTypeDescription_WindowActions);
            // 
            // cbActiveDefinition
            // 
            resources.ApplyResources(this.cbActiveDefinition, "cbActiveDefinition");
            this.cbActiveDefinition.Name = "cbActiveDefinition";
            this.cbActiveDefinition.NamedProperties.Put("DataType", "5");
            this.cbActiveDefinition.NamedProperties.Put("EnumerateMethod", "");
            this.cbActiveDefinition.NamedProperties.Put("FieldFlags", "295");
            this.cbActiveDefinition.NamedProperties.Put("LovReference", "");
            this.cbActiveDefinition.NamedProperties.Put("ResizeableChildObject", "");
            this.cbActiveDefinition.NamedProperties.Put("SqlColumn", "ACTIVE_DEFINITION");
            this.cbActiveDefinition.NamedProperties.Put("ValidateMethod", "");
            this.cbActiveDefinition.NamedProperties.Put("XDataLength", "5");
            // 
            // gbLine_Type
            // 
            this.gbLine_Type.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.gbLine_Type, "Name0");
            resources.ApplyResources(this.gbLine_Type, "gbLine_Type");
            this.gbLine_Type.Name = "gbLine_Type";
            this.gbLine_Type.TabStop = false;
            // 
            // labelcmbFileFormat
            // 
            resources.ApplyResources(this.labelcmbFileFormat, "labelcmbFileFormat");
            this.labelcmbFileFormat.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labelcmbFileFormat, "Name0");
            this.labelcmbFileFormat.Name = "labelcmbFileFormat";
            // 
            // cmbFileFormat
            // 
            this.picTab.SetControlTabPages(this.cmbFileFormat, "Name0");
            resources.ApplyResources(this.cmbFileFormat, "cmbFileFormat");
            this.cmbFileFormat.Name = "cmbFileFormat";
            this.cmbFileFormat.NamedProperties.Put("EnumerateMethod", "EXT_FILE_FORMAT_API.Enumerate");
            this.cmbFileFormat.NamedProperties.Put("FieldFlags", "294");
            this.cmbFileFormat.NamedProperties.Put("LovReference", "");
            this.cmbFileFormat.NamedProperties.Put("SqlColumn", "FILE_FORMAT");
            this.cmbFileFormat.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbFileFormat_WindowActions);
            // 
            // labeldfsSeparatorId
            // 
            resources.ApplyResources(this.labeldfsSeparatorId, "labeldfsSeparatorId");
            this.labeldfsSeparatorId.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeldfsSeparatorId, "Name0");
            this.labeldfsSeparatorId.Name = "labeldfsSeparatorId";
            // 
            // dfsSeparatorId
            // 
            this.picTab.SetControlTabPages(this.dfsSeparatorId, "Name0");
            resources.ApplyResources(this.dfsSeparatorId, "dfsSeparatorId");
            this.dfsSeparatorId.Name = "dfsSeparatorId";
            this.dfsSeparatorId.NamedProperties.Put("EnumerateMethod", "");
            this.dfsSeparatorId.NamedProperties.Put("FieldFlags", "294");
            this.dfsSeparatorId.NamedProperties.Put("LovReference", "EXT_FILE_SEPARATOR");
            this.dfsSeparatorId.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsSeparatorId.NamedProperties.Put("SqlColumn", "SEPARATOR_ID");
            this.dfsSeparatorId.NamedProperties.Put("ValidateMethod", "");
            this.dfsSeparatorId.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsSeparatorId_WindowActions);
            // 
            // labeldfExtFileSeparatorDescription
            // 
            resources.ApplyResources(this.labeldfExtFileSeparatorDescription, "labeldfExtFileSeparatorDescription");
            this.labeldfExtFileSeparatorDescription.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeldfExtFileSeparatorDescription, "Name0");
            this.labeldfExtFileSeparatorDescription.Name = "labeldfExtFileSeparatorDescription";
            // 
            // dfExtFileSeparatorDescription
            // 
            this.picTab.SetControlTabPages(this.dfExtFileSeparatorDescription, "Name0");
            resources.ApplyResources(this.dfExtFileSeparatorDescription, "dfExtFileSeparatorDescription");
            this.dfExtFileSeparatorDescription.Name = "dfExtFileSeparatorDescription";
            this.dfExtFileSeparatorDescription.NamedProperties.Put("EnumerateMethod", "");
            this.dfExtFileSeparatorDescription.NamedProperties.Put("FieldFlags", "272");
            this.dfExtFileSeparatorDescription.NamedProperties.Put("LovReference", "");
            this.dfExtFileSeparatorDescription.NamedProperties.Put("ParentName", "dfsSeparatorId");
            this.dfExtFileSeparatorDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.dfExtFileSeparatorDescription.NamedProperties.Put("SqlColumn", "EXT_FILE_SEPARATOR_API.Get_Description(SEPARATOR_ID)");
            this.dfExtFileSeparatorDescription.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsTextQualifier
            // 
            resources.ApplyResources(this.labeldfsTextQualifier, "labeldfsTextQualifier");
            this.labeldfsTextQualifier.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeldfsTextQualifier, "Name0");
            this.labeldfsTextQualifier.Name = "labeldfsTextQualifier";
            // 
            // dfsTextQualifier
            // 
            this.picTab.SetControlTabPages(this.dfsTextQualifier, "Name0");
            resources.ApplyResources(this.dfsTextQualifier, "dfsTextQualifier");
            this.dfsTextQualifier.Name = "dfsTextQualifier";
            this.dfsTextQualifier.NamedProperties.Put("EnumerateMethod", "");
            this.dfsTextQualifier.NamedProperties.Put("FieldFlags", "294");
            this.dfsTextQualifier.NamedProperties.Put("LovReference", "");
            this.dfsTextQualifier.NamedProperties.Put("SqlColumn", "TEXT_QUALIFIER");
            this.dfsTextQualifier.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsTextQualifier_WindowActions);
            // 
            // gbNumber_Columns
            // 
            this.gbNumber_Columns.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.gbNumber_Columns, "Name0");
            resources.ApplyResources(this.gbNumber_Columns, "gbNumber_Columns");
            this.gbNumber_Columns.Name = "gbNumber_Columns";
            this.gbNumber_Columns.TabStop = false;
            // 
            // labeldfsDecimalSymbol
            // 
            resources.ApplyResources(this.labeldfsDecimalSymbol, "labeldfsDecimalSymbol");
            this.labeldfsDecimalSymbol.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeldfsDecimalSymbol, "Name0");
            this.labeldfsDecimalSymbol.Name = "labeldfsDecimalSymbol";
            // 
            // dfsDecimalSymbol
            // 
            this.picTab.SetControlTabPages(this.dfsDecimalSymbol, "Name0");
            resources.ApplyResources(this.dfsDecimalSymbol, "dfsDecimalSymbol");
            this.dfsDecimalSymbol.Name = "dfsDecimalSymbol";
            this.dfsDecimalSymbol.NamedProperties.Put("EnumerateMethod", "");
            this.dfsDecimalSymbol.NamedProperties.Put("FieldFlags", "294");
            this.dfsDecimalSymbol.NamedProperties.Put("LovReference", "");
            this.dfsDecimalSymbol.NamedProperties.Put("SqlColumn", "DECIMAL_SYMBOL");
            // 
            // labeldfsDenominator
            // 
            resources.ApplyResources(this.labeldfsDenominator, "labeldfsDenominator");
            this.labeldfsDenominator.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeldfsDenominator, "Name0");
            this.labeldfsDenominator.Name = "labeldfsDenominator";
            // 
            // dfsDenominator
            // 
            this.picTab.SetControlTabPages(this.dfsDenominator, "Name0");
            resources.ApplyResources(this.dfsDenominator, "dfsDenominator");
            this.dfsDenominator.Name = "dfsDenominator";
            this.dfsDenominator.NamedProperties.Put("EnumerateMethod", "");
            this.dfsDenominator.NamedProperties.Put("FieldFlags", "294");
            this.dfsDenominator.NamedProperties.Put("LovReference", "");
            this.dfsDenominator.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsDenominator.NamedProperties.Put("SqlColumn", "DENOMINATOR");
            this.dfsDenominator.NamedProperties.Put("ValidateMethod", "");
            // 
            // gbDate_Columns
            // 
            this.gbDate_Columns.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.gbDate_Columns, "Name0");
            resources.ApplyResources(this.gbDate_Columns, "gbDate_Columns");
            this.gbDate_Columns.Name = "gbDate_Columns";
            this.gbDate_Columns.TabStop = false;
            // 
            // labeldfsDateFormat
            // 
            resources.ApplyResources(this.labeldfsDateFormat, "labeldfsDateFormat");
            this.labeldfsDateFormat.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeldfsDateFormat, "Name0");
            this.labeldfsDateFormat.Name = "labeldfsDateFormat";
            // 
            // dfsDateFormat
            // 
            this.picTab.SetControlTabPages(this.dfsDateFormat, "Name0");
            resources.ApplyResources(this.dfsDateFormat, "dfsDateFormat");
            this.dfsDateFormat.Name = "dfsDateFormat";
            this.dfsDateFormat.NamedProperties.Put("EnumerateMethod", "");
            this.dfsDateFormat.NamedProperties.Put("FieldFlags", "294");
            this.dfsDateFormat.NamedProperties.Put("LovReference", "");
            this.dfsDateFormat.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsDateFormat.NamedProperties.Put("SqlColumn", "DATE_FORMAT");
            this.dfsDateFormat.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsDateNlsCalendar
            // 
            resources.ApplyResources(this.labeldfsDateNlsCalendar, "labeldfsDateNlsCalendar");
            this.labeldfsDateNlsCalendar.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeldfsDateNlsCalendar, "Name0");
            this.labeldfsDateNlsCalendar.Name = "labeldfsDateNlsCalendar";
            // 
            // dfsDateNlsCalendar
            // 
            this.picTab.SetControlTabPages(this.dfsDateNlsCalendar, "Name0");
            resources.ApplyResources(this.dfsDateNlsCalendar, "dfsDateNlsCalendar");
            this.dfsDateNlsCalendar.Name = "dfsDateNlsCalendar";
            this.dfsDateNlsCalendar.NamedProperties.Put("EnumerateMethod", "");
            this.dfsDateNlsCalendar.NamedProperties.Put("FieldFlags", "294");
            this.dfsDateNlsCalendar.NamedProperties.Put("LovReference", "");
            this.dfsDateNlsCalendar.NamedProperties.Put("SqlColumn", "DATE_NLS_CALENDAR");
            // 
            // menuFrmMethods
            // 
            this.menuFrmMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_External,
            this.menuItem_Check});
            this.menuFrmMethods.Name = "menuFrmMethods";
            resources.ApplyResources(this.menuFrmMethods, "menuFrmMethods");
            // 
            // menuItem_External
            // 
            this.menuItem_External.Command = this.menuFrmMethods_menuExternal_File_Separator___;
            this.menuItem_External.Name = "menuItem_External";
            resources.ApplyResources(this.menuItem_External, "menuItem_External");
            this.menuItem_External.Text = "External File Separator...";
            // 
            // menuItem_Check
            // 
            this.menuItem_Check.Command = this.menuFrmMethods_menuCheck_If_Definition_is_Valid;
            this.menuItem_Check.Name = "menuItem_Check";
            resources.ApplyResources(this.menuItem_Check, "menuItem_Check");
            this.menuItem_Check.Text = "Check If Definition is Valid";
            // 
            // cbSeparated
            // 
            resources.ApplyResources(this.cbSeparated, "cbSeparated");
            this.picTab.SetControlTabPages(this.cbSeparated, "Name0");
            this.cbSeparated.Name = "cbSeparated";
            this.cbSeparated.NamedProperties.Put("DataType", "5");
            this.cbSeparated.NamedProperties.Put("EnumerateMethod", "");
            this.cbSeparated.NamedProperties.Put("FieldFlags", "295");
            this.cbSeparated.NamedProperties.Put("LovReference", "");
            this.cbSeparated.NamedProperties.Put("ResizeableChildObject", "");
            this.cbSeparated.NamedProperties.Put("SqlColumn", "SEPARATED");
            this.cbSeparated.NamedProperties.Put("ValidateMethod", "");
            this.cbSeparated.NamedProperties.Put("XDataLength", "5");
            // 
            // cbSystemDefined
            // 
            resources.ApplyResources(this.cbSystemDefined, "cbSystemDefined");
            this.cbSystemDefined.Name = "cbSystemDefined";
            this.cbSystemDefined.NamedProperties.Put("DataType", "5");
            this.cbSystemDefined.NamedProperties.Put("EnumerateMethod", "");
            this.cbSystemDefined.NamedProperties.Put("FieldFlags", "291");
            this.cbSystemDefined.NamedProperties.Put("LovReference", "");
            this.cbSystemDefined.NamedProperties.Put("ResizeableChildObject", "");
            this.cbSystemDefined.NamedProperties.Put("SqlColumn", "SYSTEM_DEFINED");
            this.cbSystemDefined.NamedProperties.Put("ValidateMethod", "");
            this.cbSystemDefined.NamedProperties.Put("XDataLength", "5");
            this.cbSystemDefined.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cbSystemDefined_WindowActions);
            // 
            // cbValidDefinition
            // 
            resources.ApplyResources(this.cbValidDefinition, "cbValidDefinition");
            this.cbValidDefinition.Name = "cbValidDefinition";
            this.cbValidDefinition.NamedProperties.Put("DataType", "5");
            this.cbValidDefinition.NamedProperties.Put("EnumerateMethod", "");
            this.cbValidDefinition.NamedProperties.Put("FieldFlags", "295");
            this.cbValidDefinition.NamedProperties.Put("LovReference", "");
            this.cbValidDefinition.NamedProperties.Put("ResizeableChildObject", "");
            this.cbValidDefinition.NamedProperties.Put("SqlColumn", "VALID_DEFINITION");
            this.cbValidDefinition.NamedProperties.Put("ValidateMethod", "");
            this.cbValidDefinition.NamedProperties.Put("XDataLength", "5");
            this.cbValidDefinition.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cbValidDefinition_WindowActions);
            // 
            // frmExternalFileTemplate
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.cbValidDefinition);
            this.Controls.Add(this.cbSystemDefined);
            this.Controls.Add(this.cbSeparated);
            this.Controls.Add(this.dfsDateNlsCalendar);
            this.Controls.Add(this.dfsDateFormat);
            this.Controls.Add(this.dfsDenominator);
            this.Controls.Add(this.dfsDecimalSymbol);
            this.Controls.Add(this.dfsTextQualifier);
            this.Controls.Add(this.dfExtFileSeparatorDescription);
            this.Controls.Add(this.dfsSeparatorId);
            this.Controls.Add(this.cmbFileFormat);
            this.Controls.Add(this.cbActiveDefinition);
            this.Controls.Add(this.dfExtFileTypeDescription);
            this.Controls.Add(this.dfsFileType);
            this.Controls.Add(this.dfsDescription);
            this.Controls.Add(this.ccsFileTemplateId);
            this.Controls.Add(this.labelcmbFileFormat);
            this.Controls.Add(this.labeldfsSeparatorId);
            this.Controls.Add(this.labeldfExtFileSeparatorDescription);
            this.Controls.Add(this.labeldfsTextQualifier);
            this.Controls.Add(this.labeldfsDecimalSymbol);
            this.Controls.Add(this.labeldfsDenominator);
            this.Controls.Add(this.labeldfsDateFormat);
            this.Controls.Add(this.labeldfsDateNlsCalendar);
            this.Controls.Add(this.labeldfExtFileTypeDescription);
            this.Controls.Add(this.labeldfsFileType);
            this.Controls.Add(this.labeldfsDescription);
            this.Controls.Add(this.labelccsFileTemplateId);
            this.Controls.Add(this.gbLine_Type);
            this.Controls.Add(this.gbNumber_Columns);
            this.Controls.Add(this.gbDate_Columns);
            this.Name = "frmExternalFileTemplate";
            this.NamedProperties.Put("DefaultOrderBy", "FILE_TEMPLATE_ID");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "ExtFileTemplate");
            this.NamedProperties.Put("PackageName", "EXT_FILE_TEMPLATE_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "4545");
            this.NamedProperties.Put("ViewName", "EXT_FILE_TEMPLATE");
            this.NamedProperties.Put("Warnings", "TRUE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.frmExternalFileTemplate_WindowActions);
            this.Controls.SetChildIndex(this.picTab, 0);
            this.Controls.SetChildIndex(this.gbDate_Columns, 0);
            this.Controls.SetChildIndex(this.gbNumber_Columns, 0);
            this.Controls.SetChildIndex(this.gbLine_Type, 0);
            this.Controls.SetChildIndex(this.labelccsFileTemplateId, 0);
            this.Controls.SetChildIndex(this.labeldfsDescription, 0);
            this.Controls.SetChildIndex(this.labeldfsFileType, 0);
            this.Controls.SetChildIndex(this.labeldfExtFileTypeDescription, 0);
            this.Controls.SetChildIndex(this.labeldfsDateNlsCalendar, 0);
            this.Controls.SetChildIndex(this.labeldfsDateFormat, 0);
            this.Controls.SetChildIndex(this.labeldfsDenominator, 0);
            this.Controls.SetChildIndex(this.labeldfsDecimalSymbol, 0);
            this.Controls.SetChildIndex(this.labeldfsTextQualifier, 0);
            this.Controls.SetChildIndex(this.labeldfExtFileSeparatorDescription, 0);
            this.Controls.SetChildIndex(this.labeldfsSeparatorId, 0);
            this.Controls.SetChildIndex(this.labelcmbFileFormat, 0);
            this.Controls.SetChildIndex(this.ccsFileTemplateId, 0);
            this.Controls.SetChildIndex(this.dfsDescription, 0);
            this.Controls.SetChildIndex(this.dfsFileType, 0);
            this.Controls.SetChildIndex(this.dfExtFileTypeDescription, 0);
            this.Controls.SetChildIndex(this.cbActiveDefinition, 0);
            this.Controls.SetChildIndex(this.cmbFileFormat, 0);
            this.Controls.SetChildIndex(this.dfsSeparatorId, 0);
            this.Controls.SetChildIndex(this.dfExtFileSeparatorDescription, 0);
            this.Controls.SetChildIndex(this.dfsTextQualifier, 0);
            this.Controls.SetChildIndex(this.dfsDecimalSymbol, 0);
            this.Controls.SetChildIndex(this.dfsDenominator, 0);
            this.Controls.SetChildIndex(this.dfsDateFormat, 0);
            this.Controls.SetChildIndex(this.dfsDateNlsCalendar, 0);
            this.Controls.SetChildIndex(this.cbSeparated, 0);
            this.Controls.SetChildIndex(this.cbSystemDefined, 0);
            this.Controls.SetChildIndex(this.cbValidDefinition, 0);
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

        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menuExternal_File_Separator___;
        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menuCheck_If_Definition_is_Valid;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuFrmMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_External;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Check;
	}
}
