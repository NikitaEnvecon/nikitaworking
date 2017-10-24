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
	
	public partial class tbwExternalFileTemplate
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cColumn colsFileTemplateId;
		public cColumn colsDescription;
		public cCheckBoxColumn colsSystemDefined;
		public cCheckBoxColumn colsActiveDefinition;
		public cCheckBoxColumn colsValidDefinition;
		public cLookupColumn colsFileFormat;
		public cColumn colsDecimalSymbol;
		public cColumn colsDateFormat;
		public cColumn colsDenominator;
		public cColumn colsFileType;
		public cColumn colExtFileTypeDescription;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwExternalFileTemplate));
            this.menuTbwMethods_menu_Details___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_menuCopy__File_Template___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_menuCreate_File__Template_From_File = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.colsFileTemplateId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsSystemDefined = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.colsActiveDefinition = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.colsValidDefinition = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.colsFileFormat = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.colsDecimalSymbol = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsDateFormat = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsDenominator = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsFileType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colExtFileTypeDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.menuTbwMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem__Details = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem_Copy = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem_Create = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuTbwMethods.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuTbwMethods_menu_Details___);
            this.commandManager.Commands.Add(this.menuTbwMethods_menuCopy__File_Template___);
            this.commandManager.Commands.Add(this.menuTbwMethods_menuCreate_File__Template_From_File);
            this.commandManager.ContextMenus.Add(this.menuTbwMethods);
            // 
            // menuTbwMethods_menu_Details___
            // 
            resources.ApplyResources(this.menuTbwMethods_menu_Details___, "menuTbwMethods_menu_Details___");
            this.menuTbwMethods_menu_Details___.Name = "menuTbwMethods_menu_Details___";
            this.menuTbwMethods_menu_Details___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Details_Execute);
            this.menuTbwMethods_menu_Details___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Details_Inquire);
            // 
            // menuTbwMethods_menuCopy__File_Template___
            // 
            resources.ApplyResources(this.menuTbwMethods_menuCopy__File_Template___, "menuTbwMethods_menuCopy__File_Template___");
            this.menuTbwMethods_menuCopy__File_Template___.Name = "menuTbwMethods_menuCopy__File_Template___";
            this.menuTbwMethods_menuCopy__File_Template___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Copy_Execute);
            this.menuTbwMethods_menuCopy__File_Template___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Copy_Inquire);
            // 
            // menuTbwMethods_menuCreate_File__Template_From_File
            // 
            resources.ApplyResources(this.menuTbwMethods_menuCreate_File__Template_From_File, "menuTbwMethods_menuCreate_File__Template_From_File");
            this.menuTbwMethods_menuCreate_File__Template_From_File.Name = "menuTbwMethods_menuCreate_File__Template_From_File";
            this.menuTbwMethods_menuCreate_File__Template_From_File.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Create_Execute);
            this.menuTbwMethods_menuCreate_File__Template_From_File.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Create_Inquire);
            // 
            // colsFileTemplateId
            // 
            this.colsFileTemplateId.MaxLength = 30;
            this.colsFileTemplateId.Name = "colsFileTemplateId";
            this.colsFileTemplateId.NamedProperties.Put("EnumerateMethod", "");
            this.colsFileTemplateId.NamedProperties.Put("FieldFlags", "163");
            this.colsFileTemplateId.NamedProperties.Put("LovReference", "");
            this.colsFileTemplateId.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsFileTemplateId.NamedProperties.Put("SqlColumn", "FILE_TEMPLATE_ID");
            this.colsFileTemplateId.Position = 3;
            resources.ApplyResources(this.colsFileTemplateId, "colsFileTemplateId");
            // 
            // colsDescription
            // 
            this.colsDescription.MaxLength = 200;
            this.colsDescription.Name = "colsDescription";
            this.colsDescription.NamedProperties.Put("EnumerateMethod", "");
            this.colsDescription.NamedProperties.Put("FieldFlags", "295");
            this.colsDescription.NamedProperties.Put("LovReference", "");
            this.colsDescription.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsDescription.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            this.colsDescription.Position = 4;
            resources.ApplyResources(this.colsDescription, "colsDescription");
            // 
            // colsSystemDefined
            // 
            this.colsSystemDefined.MaxLength = 5;
            this.colsSystemDefined.Name = "colsSystemDefined";
            this.colsSystemDefined.NamedProperties.Put("EnumerateMethod", "");
            this.colsSystemDefined.NamedProperties.Put("FieldFlags", "291");
            this.colsSystemDefined.NamedProperties.Put("LovReference", "");
            this.colsSystemDefined.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsSystemDefined.NamedProperties.Put("ResizeableChildObject", "");
            this.colsSystemDefined.NamedProperties.Put("SqlColumn", "SYSTEM_DEFINED");
            this.colsSystemDefined.NamedProperties.Put("ValidateMethod", "");
            this.colsSystemDefined.Position = 5;
            resources.ApplyResources(this.colsSystemDefined, "colsSystemDefined");
            // 
            // colsActiveDefinition
            // 
            this.colsActiveDefinition.MaxLength = 5;
            this.colsActiveDefinition.Name = "colsActiveDefinition";
            this.colsActiveDefinition.NamedProperties.Put("EnumerateMethod", "");
            this.colsActiveDefinition.NamedProperties.Put("FieldFlags", "291");
            this.colsActiveDefinition.NamedProperties.Put("LovReference", "");
            this.colsActiveDefinition.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsActiveDefinition.NamedProperties.Put("ResizeableChildObject", "");
            this.colsActiveDefinition.NamedProperties.Put("SqlColumn", "ACTIVE_DEFINITION");
            this.colsActiveDefinition.NamedProperties.Put("ValidateMethod", "");
            this.colsActiveDefinition.Position = 6;
            resources.ApplyResources(this.colsActiveDefinition, "colsActiveDefinition");
            // 
            // colsValidDefinition
            // 
            this.colsValidDefinition.MaxLength = 5;
            this.colsValidDefinition.Name = "colsValidDefinition";
            this.colsValidDefinition.NamedProperties.Put("EnumerateMethod", "");
            this.colsValidDefinition.NamedProperties.Put("FieldFlags", "291");
            this.colsValidDefinition.NamedProperties.Put("LovReference", "");
            this.colsValidDefinition.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsValidDefinition.NamedProperties.Put("ResizeableChildObject", "");
            this.colsValidDefinition.NamedProperties.Put("SqlColumn", "VALID_DEFINITION");
            this.colsValidDefinition.NamedProperties.Put("ValidateMethod", "");
            this.colsValidDefinition.Position = 7;
            resources.ApplyResources(this.colsValidDefinition, "colsValidDefinition");
            // 
            // colsFileFormat
            // 
            this.colsFileFormat.MaxLength = 200;
            this.colsFileFormat.Name = "colsFileFormat";
            this.colsFileFormat.NamedProperties.Put("EnumerateMethod", "EXT_FILE_FORMAT_API.Enumerate");
            this.colsFileFormat.NamedProperties.Put("FieldFlags", "294");
            this.colsFileFormat.NamedProperties.Put("LovReference", "");
            this.colsFileFormat.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsFileFormat.NamedProperties.Put("SqlColumn", "FILE_FORMAT");
            this.colsFileFormat.Position = 8;
            resources.ApplyResources(this.colsFileFormat, "colsFileFormat");
            // 
            // colsDecimalSymbol
            // 
            this.colsDecimalSymbol.MaxLength = 1;
            this.colsDecimalSymbol.Name = "colsDecimalSymbol";
            this.colsDecimalSymbol.NamedProperties.Put("EnumerateMethod", "");
            this.colsDecimalSymbol.NamedProperties.Put("FieldFlags", "294");
            this.colsDecimalSymbol.NamedProperties.Put("LovReference", "");
            this.colsDecimalSymbol.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsDecimalSymbol.NamedProperties.Put("SqlColumn", "DECIMAL_SYMBOL");
            this.colsDecimalSymbol.Position = 9;
            resources.ApplyResources(this.colsDecimalSymbol, "colsDecimalSymbol");
            // 
            // colsDateFormat
            // 
            this.colsDateFormat.MaxLength = 20;
            this.colsDateFormat.Name = "colsDateFormat";
            this.colsDateFormat.NamedProperties.Put("EnumerateMethod", "");
            this.colsDateFormat.NamedProperties.Put("FieldFlags", "294");
            this.colsDateFormat.NamedProperties.Put("LovReference", "");
            this.colsDateFormat.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsDateFormat.NamedProperties.Put("SqlColumn", "DATE_FORMAT");
            this.colsDateFormat.Position = 10;
            resources.ApplyResources(this.colsDateFormat, "colsDateFormat");
            // 
            // colsDenominator
            // 
            this.colsDenominator.MaxLength = 2;
            this.colsDenominator.Name = "colsDenominator";
            this.colsDenominator.NamedProperties.Put("EnumerateMethod", "");
            this.colsDenominator.NamedProperties.Put("FieldFlags", "294");
            this.colsDenominator.NamedProperties.Put("LovReference", "");
            this.colsDenominator.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsDenominator.NamedProperties.Put("SqlColumn", "DENOMINATOR");
            this.colsDenominator.Position = 11;
            resources.ApplyResources(this.colsDenominator, "colsDenominator");
            // 
            // colsFileType
            // 
            this.colsFileType.Name = "colsFileType";
            this.colsFileType.NamedProperties.Put("EnumerateMethod", "");
            this.colsFileType.NamedProperties.Put("FieldFlags", "290");
            this.colsFileType.NamedProperties.Put("LovReference", "");
            this.colsFileType.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsFileType.NamedProperties.Put("ResizeableChildObject", "");
            this.colsFileType.NamedProperties.Put("SqlColumn", "FILE_TYPE");
            this.colsFileType.NamedProperties.Put("ValidateMethod", "");
            this.colsFileType.Position = 12;
            resources.ApplyResources(this.colsFileType, "colsFileType");
            // 
            // colExtFileTypeDescription
            // 
            this.colExtFileTypeDescription.MaxLength = 2000;
            this.colExtFileTypeDescription.Name = "colExtFileTypeDescription";
            this.colExtFileTypeDescription.NamedProperties.Put("EnumerateMethod", "");
            this.colExtFileTypeDescription.NamedProperties.Put("FieldFlags", "272");
            this.colExtFileTypeDescription.NamedProperties.Put("LovReference", "");
            this.colExtFileTypeDescription.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colExtFileTypeDescription.NamedProperties.Put("SqlColumn", "EXT_FILE_TYPE_API.Get_Description(FILE_TYPE)");
            this.colExtFileTypeDescription.NamedProperties.Put("ValidateMethod", "");
            this.colExtFileTypeDescription.Position = 13;
            resources.ApplyResources(this.colExtFileTypeDescription, "colExtFileTypeDescription");
            // 
            // menuTbwMethods
            // 
            this.menuTbwMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem__Details,
            this.menuItem_Copy,
            this.menuItem_Create});
            this.menuTbwMethods.Name = "menuTbwMethods";
            resources.ApplyResources(this.menuTbwMethods, "menuTbwMethods");
            // 
            // menuItem__Details
            // 
            this.menuItem__Details.Command = this.menuTbwMethods_menu_Details___;
            this.menuItem__Details.Name = "menuItem__Details";
            resources.ApplyResources(this.menuItem__Details, "menuItem__Details");
            this.menuItem__Details.Text = "&Details...";
            // 
            // menuItem_Copy
            // 
            this.menuItem_Copy.Command = this.menuTbwMethods_menuCopy__File_Template___;
            this.menuItem_Copy.Name = "menuItem_Copy";
            resources.ApplyResources(this.menuItem_Copy, "menuItem_Copy");
            this.menuItem_Copy.Text = "Copy &File Template...";
            // 
            // menuItem_Create
            // 
            this.menuItem_Create.Command = this.menuTbwMethods_menuCreate_File__Template_From_File;
            this.menuItem_Create.Name = "menuItem_Create";
            resources.ApplyResources(this.menuItem_Create, "menuItem_Create");
            this.menuItem_Create.Text = "Create File &Template From File Type...";
            // 
            // tbwExternalFileTemplate
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colsFileTemplateId);
            this.Controls.Add(this.colsDescription);
            this.Controls.Add(this.colsSystemDefined);
            this.Controls.Add(this.colsActiveDefinition);
            this.Controls.Add(this.colsValidDefinition);
            this.Controls.Add(this.colsFileFormat);
            this.Controls.Add(this.colsDecimalSymbol);
            this.Controls.Add(this.colsDateFormat);
            this.Controls.Add(this.colsDenominator);
            this.Controls.Add(this.colsFileType);
            this.Controls.Add(this.colExtFileTypeDescription);
            this.Name = "tbwExternalFileTemplate";
            this.NamedProperties.Put("DefaultOrderBy", "FILE_TEMPLATE_ID");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "ExtFileTemplate");
            this.NamedProperties.Put("PackageName", "EXT_FILE_TEMPLATE_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "257");
            this.NamedProperties.Put("ViewName", "EXT_FILE_TEMPLATE");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tbwExternalFileTemplate_WindowActions);
            this.Controls.SetChildIndex(this.colExtFileTypeDescription, 0);
            this.Controls.SetChildIndex(this.colsFileType, 0);
            this.Controls.SetChildIndex(this.colsDenominator, 0);
            this.Controls.SetChildIndex(this.colsDateFormat, 0);
            this.Controls.SetChildIndex(this.colsDecimalSymbol, 0);
            this.Controls.SetChildIndex(this.colsFileFormat, 0);
            this.Controls.SetChildIndex(this.colsValidDefinition, 0);
            this.Controls.SetChildIndex(this.colsActiveDefinition, 0);
            this.Controls.SetChildIndex(this.colsSystemDefined, 0);
            this.Controls.SetChildIndex(this.colsDescription, 0);
            this.Controls.SetChildIndex(this.colsFileTemplateId, 0);
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

        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menu_Details___;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menuCopy__File_Template___;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menuCreate_File__Template_From_File;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTbwMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Details;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Copy;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Create;
	}
}
