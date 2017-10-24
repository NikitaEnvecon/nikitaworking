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
	
	public partial class tbwExtTypeParamSet
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cColumn colsFileType;
		public cColumn colsSetId;
		public cColumn colsDescription;
		public cCheckBoxColumn colsSetIdDefault;
		public cCheckBoxColumn colsSystemDefined;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwExtTypeParamSet));
            this.menuTbwMethods_menuExternal_File_Parameters__Per_Se = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_menuCreate_Parameters_Per_Set_From__ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.colsFileType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsSetId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsSetIdDefault = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.colsSystemDefined = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.menuTbwMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_External = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem_Create = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuTbwMethods.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuTbwMethods_menuExternal_File_Parameters__Per_Se);
            this.commandManager.Commands.Add(this.menuTbwMethods_menuCreate_Parameters_Per_Set_From__);
            this.commandManager.ContextMenus.Add(this.menuTbwMethods);
            // 
            // menuTbwMethods_menuExternal_File_Parameters__Per_Se
            // 
            resources.ApplyResources(this.menuTbwMethods_menuExternal_File_Parameters__Per_Se, "menuTbwMethods_menuExternal_File_Parameters__Per_Se");
            this.menuTbwMethods_menuExternal_File_Parameters__Per_Se.Name = "menuTbwMethods_menuExternal_File_Parameters__Per_Se";
            this.menuTbwMethods_menuExternal_File_Parameters__Per_Se.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_External_Execute);
            this.menuTbwMethods_menuExternal_File_Parameters__Per_Se.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_External_Inquire);
            // 
            // menuTbwMethods_menuCreate_Parameters_Per_Set_From__
            // 
            resources.ApplyResources(this.menuTbwMethods_menuCreate_Parameters_Per_Set_From__, "menuTbwMethods_menuCreate_Parameters_Per_Set_From__");
            this.menuTbwMethods_menuCreate_Parameters_Per_Set_From__.Name = "menuTbwMethods_menuCreate_Parameters_Per_Set_From__";
            this.menuTbwMethods_menuCreate_Parameters_Per_Set_From__.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Create_Execute);
            this.menuTbwMethods_menuCreate_Parameters_Per_Set_From__.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Create_Inquire);
            // 
            // colsFileType
            // 
            resources.ApplyResources(this.colsFileType, "colsFileType");
            this.colsFileType.MaxLength = 30;
            this.colsFileType.Name = "colsFileType";
            this.colsFileType.NamedProperties.Put("EnumerateMethod", "");
            this.colsFileType.NamedProperties.Put("FieldFlags", "67");
            this.colsFileType.NamedProperties.Put("LovReference", "EXT_FILE_MODULE_NAME");
            this.colsFileType.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsFileType.NamedProperties.Put("SqlColumn", "FILE_TYPE");
            this.colsFileType.Position = 3;
            this.colsFileType.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsFileType_WindowActions);
            // 
            // colsSetId
            // 
            this.colsSetId.MaxLength = 20;
            this.colsSetId.Name = "colsSetId";
            this.colsSetId.NamedProperties.Put("EnumerateMethod", "");
            this.colsSetId.NamedProperties.Put("FieldFlags", "171");
            this.colsSetId.NamedProperties.Put("LovReference", "");
            this.colsSetId.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsSetId.NamedProperties.Put("ResizeableChildObject", "");
            this.colsSetId.NamedProperties.Put("SqlColumn", "SET_ID");
            this.colsSetId.NamedProperties.Put("ValidateMethod", "");
            this.colsSetId.Position = 4;
            resources.ApplyResources(this.colsSetId, "colsSetId");
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
            this.colsDescription.Position = 5;
            resources.ApplyResources(this.colsDescription, "colsDescription");
            // 
            // colsSetIdDefault
            // 
            this.colsSetIdDefault.MaxLength = 5;
            this.colsSetIdDefault.Name = "colsSetIdDefault";
            this.colsSetIdDefault.NamedProperties.Put("EnumerateMethod", "");
            this.colsSetIdDefault.NamedProperties.Put("FieldFlags", "294");
            this.colsSetIdDefault.NamedProperties.Put("LovReference", "");
            this.colsSetIdDefault.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsSetIdDefault.NamedProperties.Put("ResizeableChildObject", "");
            this.colsSetIdDefault.NamedProperties.Put("SqlColumn", "SET_ID_DEFAULT");
            this.colsSetIdDefault.NamedProperties.Put("ValidateMethod", "");
            this.colsSetIdDefault.Position = 6;
            resources.ApplyResources(this.colsSetIdDefault, "colsSetIdDefault");
            // 
            // colsSystemDefined
            // 
            this.colsSystemDefined.MaxLength = 5;
            this.colsSystemDefined.Name = "colsSystemDefined";
            this.colsSystemDefined.NamedProperties.Put("EnumerateMethod", "");
            this.colsSystemDefined.NamedProperties.Put("FieldFlags", "290");
            this.colsSystemDefined.NamedProperties.Put("LovReference", "");
            this.colsSystemDefined.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsSystemDefined.NamedProperties.Put("ResizeableChildObject", "");
            this.colsSystemDefined.NamedProperties.Put("SqlColumn", "SYSTEM_DEFINED");
            this.colsSystemDefined.NamedProperties.Put("ValidateMethod", "");
            this.colsSystemDefined.Position = 7;
            resources.ApplyResources(this.colsSystemDefined, "colsSystemDefined");
            // 
            // menuTbwMethods
            // 
            this.menuTbwMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_External,
            this.menuItem_Create});
            this.menuTbwMethods.Name = "menuTbwMethods";
            resources.ApplyResources(this.menuTbwMethods, "menuTbwMethods");
            // 
            // menuItem_External
            // 
            this.menuItem_External.Command = this.menuTbwMethods_menuExternal_File_Parameters__Per_Se;
            this.menuItem_External.Name = "menuItem_External";
            resources.ApplyResources(this.menuItem_External, "menuItem_External");
            this.menuItem_External.Text = "External File Parameters &Per Set...";
            // 
            // menuItem_Create
            // 
            this.menuItem_Create.Command = this.menuTbwMethods_menuCreate_Parameters_Per_Set_From__;
            this.menuItem_Create.Name = "menuItem_Create";
            resources.ApplyResources(this.menuItem_Create, "menuItem_Create");
            this.menuItem_Create.Text = "Create Parameters Per Set From &Available Parameters";
            // 
            // tbwExtTypeParamSet
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colsFileType);
            this.Controls.Add(this.colsSetId);
            this.Controls.Add(this.colsDescription);
            this.Controls.Add(this.colsSetIdDefault);
            this.Controls.Add(this.colsSystemDefined);
            this.Name = "tbwExtTypeParamSet";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "ExtTypeParamSet");
            this.NamedProperties.Put("PackageName", "EXT_TYPE_PARAM_SET_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "449");
            this.NamedProperties.Put("ViewName", "EXT_TYPE_PARAM_SET");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tbwExtTypeParamSet_WindowActions);
            this.Controls.SetChildIndex(this.colsSystemDefined, 0);
            this.Controls.SetChildIndex(this.colsSetIdDefault, 0);
            this.Controls.SetChildIndex(this.colsDescription, 0);
            this.Controls.SetChildIndex(this.colsSetId, 0);
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

        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menuExternal_File_Parameters__Per_Se;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menuCreate_Parameters_Per_Set_From__;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTbwMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_External;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Create;
	}
}
