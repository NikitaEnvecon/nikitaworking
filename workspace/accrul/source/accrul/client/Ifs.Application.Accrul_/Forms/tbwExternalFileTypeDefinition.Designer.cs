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
	
	public partial class tbwExternalFileTypeDefinition
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cColumn colsFileType;
		public cColumn colsDescription;
		public cColumn colsComponent;
		public cCheckBoxColumn colsSystemDefined;
		public cColumn colnUsableCount;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwExternalFileTypeDefinition));
            this.menuTbwMethods_menu_Details___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_menuCopy__File_Type___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_menuCreate_File_Type_And_File_Templa = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.colsFileType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsComponent = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsSystemDefined = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.colnUsableCount = new Ifs.Fnd.ApplicationForms.cColumn();
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
            this.commandManager.Commands.Add(this.menuTbwMethods_menuCopy__File_Type___);
            this.commandManager.Commands.Add(this.menuTbwMethods_menuCreate_File_Type_And_File_Templa);
            this.commandManager.ContextMenus.Add(this.menuTbwMethods);
            // 
            // menuTbwMethods_menu_Details___
            // 
            resources.ApplyResources(this.menuTbwMethods_menu_Details___, "menuTbwMethods_menu_Details___");
            this.menuTbwMethods_menu_Details___.Name = "menuTbwMethods_menu_Details___";
            this.menuTbwMethods_menu_Details___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Details_Execute);
            this.menuTbwMethods_menu_Details___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Details_Inquire);
            // 
            // menuTbwMethods_menuCopy__File_Type___
            // 
            resources.ApplyResources(this.menuTbwMethods_menuCopy__File_Type___, "menuTbwMethods_menuCopy__File_Type___");
            this.menuTbwMethods_menuCopy__File_Type___.Name = "menuTbwMethods_menuCopy__File_Type___";
            this.menuTbwMethods_menuCopy__File_Type___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Copy_Execute);
            this.menuTbwMethods_menuCopy__File_Type___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Copy_Inquire);
            // 
            // menuTbwMethods_menuCreate_File_Type_And_File_Templa
            // 
            resources.ApplyResources(this.menuTbwMethods_menuCreate_File_Type_And_File_Templa, "menuTbwMethods_menuCreate_File_Type_And_File_Templa");
            this.menuTbwMethods_menuCreate_File_Type_And_File_Templa.Name = "menuTbwMethods_menuCreate_File_Type_And_File_Templa";
            this.menuTbwMethods_menuCreate_File_Type_And_File_Templa.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Create_Execute);
            this.menuTbwMethods_menuCreate_File_Type_And_File_Templa.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Create_Inquire);
            // 
            // colsFileType
            // 
            this.colsFileType.MaxLength = 30;
            this.colsFileType.Name = "colsFileType";
            this.colsFileType.NamedProperties.Put("EnumerateMethod", "");
            this.colsFileType.NamedProperties.Put("FieldFlags", "163");
            this.colsFileType.NamedProperties.Put("LovReference", "");
            this.colsFileType.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsFileType.NamedProperties.Put("SqlColumn", "FILE_TYPE");
            this.colsFileType.Position = 3;
            resources.ApplyResources(this.colsFileType, "colsFileType");
            // 
            // colsDescription
            // 
            this.colsDescription.Name = "colsDescription";
            this.colsDescription.NamedProperties.Put("EnumerateMethod", "");
            this.colsDescription.NamedProperties.Put("FieldFlags", "294");
            this.colsDescription.NamedProperties.Put("LovReference", "");
            this.colsDescription.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsDescription.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            this.colsDescription.Position = 4;
            resources.ApplyResources(this.colsDescription, "colsDescription");
            // 
            // colsComponent
            // 
            this.colsComponent.MaxLength = 10;
            this.colsComponent.Name = "colsComponent";
            this.colsComponent.NamedProperties.Put("EnumerateMethod", "");
            this.colsComponent.NamedProperties.Put("FieldFlags", "294");
            this.colsComponent.NamedProperties.Put("LovReference", "");
            this.colsComponent.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsComponent.NamedProperties.Put("SqlColumn", "COMPONENT");
            this.colsComponent.Position = 5;
            resources.ApplyResources(this.colsComponent, "colsComponent");
            // 
            // colsSystemDefined
            // 
            this.colsSystemDefined.MaxLength = 5;
            this.colsSystemDefined.Name = "colsSystemDefined";
            this.colsSystemDefined.NamedProperties.Put("EnumerateMethod", "");
            this.colsSystemDefined.NamedProperties.Put("FieldFlags", "294");
            this.colsSystemDefined.NamedProperties.Put("LovReference", "");
            this.colsSystemDefined.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsSystemDefined.NamedProperties.Put("ResizeableChildObject", "");
            this.colsSystemDefined.NamedProperties.Put("SqlColumn", "SYSTEM_DEFINED");
            this.colsSystemDefined.NamedProperties.Put("ValidateMethod", "");
            this.colsSystemDefined.Position = 6;
            resources.ApplyResources(this.colsSystemDefined, "colsSystemDefined");
            // 
            // colnUsableCount
            // 
            this.colnUsableCount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colnUsableCount.Name = "colnUsableCount";
            this.colnUsableCount.NamedProperties.Put("EnumerateMethod", "");
            this.colnUsableCount.NamedProperties.Put("FieldFlags", "256");
            this.colnUsableCount.NamedProperties.Put("LovReference", "");
            this.colnUsableCount.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colnUsableCount.NamedProperties.Put("ResizeableChildObject", "");
            this.colnUsableCount.NamedProperties.Put("SqlColumn", "Ext_File_Template_API.Count_Usable_File_Template(FILE_TYPE)");
            this.colnUsableCount.NamedProperties.Put("ValidateMethod", "");
            this.colnUsableCount.Position = 7;
            this.colnUsableCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.colnUsableCount, "colnUsableCount");
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
            this.menuItem_Copy.Command = this.menuTbwMethods_menuCopy__File_Type___;
            this.menuItem_Copy.Name = "menuItem_Copy";
            resources.ApplyResources(this.menuItem_Copy, "menuItem_Copy");
            this.menuItem_Copy.Text = "Copy &File Type...";
            // 
            // menuItem_Create
            // 
            this.menuItem_Create.Command = this.menuTbwMethods_menuCreate_File_Type_And_File_Templa;
            this.menuItem_Create.Name = "menuItem_Create";
            resources.ApplyResources(this.menuItem_Create, "menuItem_Create");
            this.menuItem_Create.Text = "Create File Type And File Template From &View Definition...";
            // 
            // tbwExternalFileTypeDefinition
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colsFileType);
            this.Controls.Add(this.colsDescription);
            this.Controls.Add(this.colsComponent);
            this.Controls.Add(this.colsSystemDefined);
            this.Controls.Add(this.colnUsableCount);
            this.Name = "tbwExternalFileTypeDefinition";
            this.NamedProperties.Put("DefaultOrderBy", "FILE_TYPE");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "ExtFileType");
            this.NamedProperties.Put("PackageName", "EXT_FILE_TYPE_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "257");
            this.NamedProperties.Put("ViewName", "EXT_FILE_TYPE");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tbwExternalFileTypeDefinition_WindowActions);
            this.Controls.SetChildIndex(this.colnUsableCount, 0);
            this.Controls.SetChildIndex(this.colsSystemDefined, 0);
            this.Controls.SetChildIndex(this.colsComponent, 0);
            this.Controls.SetChildIndex(this.colsDescription, 0);
            this.Controls.SetChildIndex(this.colsFileType, 0);
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
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menuCopy__File_Type___;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menuCreate_File_Type_And_File_Templa;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTbwMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Details;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Copy;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Create;
	}
}
