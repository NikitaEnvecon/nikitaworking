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
	
	public partial class tbwAttribute
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cColumn colsCompany;
		public cColumn colsAttribute;
		public cColumn colsDescription;
		public cColumn colsCodePart;
		// Bug 83782 Begin , changed Object Title
		public cColumn colsCodeName;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwAttribute));
            this.menuOperations_menu_Attribute_Value___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuOperations_menuC_onnect_Attribute___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuOperations_menu_Change_Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_menu_Attribute_Value___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_menuC_onnect_Attribute___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_menu_Change_Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.colsCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsAttribute = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsCodePart = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsCodeName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.menuTbwMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem__Attribute = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem_Connect = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuSeparator1 = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.menuItem__Change = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuOperations = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem__Attribute_1 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem_Connect_1 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuSeparator2 = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.menuItem__Change_1 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuTbwMethods.SuspendLayout();
            this.menuOperations.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuTbwMethods_menu_Attribute_Value___);
            this.commandManager.Commands.Add(this.menuTbwMethods_menuC_onnect_Attribute___);
            this.commandManager.Commands.Add(this.menuTbwMethods_menu_Change_Company___);
            this.commandManager.Commands.Add(this.menuOperations_menu_Attribute_Value___);
            this.commandManager.Commands.Add(this.menuOperations_menuC_onnect_Attribute___);
            this.commandManager.Commands.Add(this.menuOperations_menu_Change_Company___);
            this.commandManager.ContextMenus.Add(this.menuTbwMethods);
            this.commandManager.ContextMenus.Add(this.menuOperations);
            // 
            // menuOperations_menu_Attribute_Value___
            // 
            resources.ApplyResources(this.menuOperations_menu_Attribute_Value___, "menuOperations_menu_Attribute_Value___");
            this.menuOperations_menu_Attribute_Value___.Name = "menuOperations_menu_Attribute_Value___";
            this.menuOperations_menu_Attribute_Value___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Attribute_1_Execute);
            this.menuOperations_menu_Attribute_Value___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Attribute_1_Inquire);
            // 
            // menuOperations_menuC_onnect_Attribute___
            // 
            resources.ApplyResources(this.menuOperations_menuC_onnect_Attribute___, "menuOperations_menuC_onnect_Attribute___");
            this.menuOperations_menuC_onnect_Attribute___.Name = "menuOperations_menuC_onnect_Attribute___";
            this.menuOperations_menuC_onnect_Attribute___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Connect_1_Execute);
            this.menuOperations_menuC_onnect_Attribute___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Connect_1_Inquire);
            // 
            // menuOperations_menu_Change_Company___
            // 
            resources.ApplyResources(this.menuOperations_menu_Change_Company___, "menuOperations_menu_Change_Company___");
            this.menuOperations_menu_Change_Company___.Name = "menuOperations_menu_Change_Company___";
            this.menuOperations_menu_Change_Company___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Change_1_Execute);
            this.menuOperations_menu_Change_Company___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Change_1_Inquire);
            // 
            // menuTbwMethods_menu_Attribute_Value___
            // 
            resources.ApplyResources(this.menuTbwMethods_menu_Attribute_Value___, "menuTbwMethods_menu_Attribute_Value___");
            this.menuTbwMethods_menu_Attribute_Value___.Name = "menuTbwMethods_menu_Attribute_Value___";
            this.menuTbwMethods_menu_Attribute_Value___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Attribute_Execute);
            this.menuTbwMethods_menu_Attribute_Value___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Attribute_Inquire);
            // 
            // menuTbwMethods_menuC_onnect_Attribute___
            // 
            resources.ApplyResources(this.menuTbwMethods_menuC_onnect_Attribute___, "menuTbwMethods_menuC_onnect_Attribute___");
            this.menuTbwMethods_menuC_onnect_Attribute___.Name = "menuTbwMethods_menuC_onnect_Attribute___";
            this.menuTbwMethods_menuC_onnect_Attribute___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Connect_Execute);
            this.menuTbwMethods_menuC_onnect_Attribute___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Connect_Inquire);
            // 
            // menuTbwMethods_menu_Change_Company___
            // 
            resources.ApplyResources(this.menuTbwMethods_menu_Change_Company___, "menuTbwMethods_menu_Change_Company___");
            this.menuTbwMethods_menu_Change_Company___.Name = "menuTbwMethods_menu_Change_Company___";
            this.menuTbwMethods_menu_Change_Company___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Change_Execute);
            this.menuTbwMethods_menu_Change_Company___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Change_Inquire);
            // 
            // colsCompany
            // 
            resources.ApplyResources(this.colsCompany, "colsCompany");
            this.colsCompany.MaxLength = 20;
            this.colsCompany.Name = "colsCompany";
            this.colsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.colsCompany.NamedProperties.Put("FieldFlags", "131");
            this.colsCompany.NamedProperties.Put("LovReference", "");
            this.colsCompany.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.colsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.colsCompany.NamedProperties.Put("ValidateMethod", "");
            this.colsCompany.Position = 3;
            // 
            // colsAttribute
            // 
            this.colsAttribute.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsAttribute.MaxLength = 20;
            this.colsAttribute.Name = "colsAttribute";
            this.colsAttribute.NamedProperties.Put("EnumerateMethod", "");
            this.colsAttribute.NamedProperties.Put("FieldFlags", "163");
            this.colsAttribute.NamedProperties.Put("LovReference", "ACCOUNTING_ATTRIBUTE(COMPANY)");
            this.colsAttribute.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsAttribute.NamedProperties.Put("ResizeableChildObject", "");
            this.colsAttribute.NamedProperties.Put("SqlColumn", "ATTRIBUTE");
            this.colsAttribute.NamedProperties.Put("ValidateMethod", "");
            this.colsAttribute.Position = 4;
            resources.ApplyResources(this.colsAttribute, "colsAttribute");
            // 
            // colsDescription
            // 
            this.colsDescription.MaxLength = 200;
            this.colsDescription.Name = "colsDescription";
            this.colsDescription.NamedProperties.Put("EnumerateMethod", "");
            this.colsDescription.NamedProperties.Put("FieldFlags", "295");
            this.colsDescription.NamedProperties.Put("LovReference", "");
            this.colsDescription.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.colsDescription.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            this.colsDescription.NamedProperties.Put("ValidateMethod", "");
            this.colsDescription.Position = 5;
            resources.ApplyResources(this.colsDescription, "colsDescription");
            // 
            // colsCodePart
            // 
            this.colsCodePart.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.colsCodePart, "colsCodePart");
            this.colsCodePart.MaxLength = 1;
            this.colsCodePart.Name = "colsCodePart";
            this.colsCodePart.NamedProperties.Put("EnumerateMethod", "");
            this.colsCodePart.NamedProperties.Put("FieldFlags", "263");
            this.colsCodePart.NamedProperties.Put("LovReference", "ACCOUNTING_CODE_PARTS(COMPANY)");
            this.colsCodePart.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsCodePart.NamedProperties.Put("ResizeableChildObject", "");
            this.colsCodePart.NamedProperties.Put("SqlColumn", "CODE_PART");
            this.colsCodePart.NamedProperties.Put("ValidateMethod", "");
            this.colsCodePart.Position = 6;
            // 
            // colsCodeName
            // 
            this.colsCodeName.MaxLength = 32000;
            this.colsCodeName.Name = "colsCodeName";
            this.colsCodeName.NamedProperties.Put("EnumerateMethod", "");
            this.colsCodeName.NamedProperties.Put("FieldFlags", "291");
            this.colsCodeName.NamedProperties.Put("LovReference", "ACCOUNTING_CODE_PARTS_USED2(COMPANY)");
            this.colsCodeName.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsCodeName.NamedProperties.Put("ResizeableChildObject", "");
            this.colsCodeName.NamedProperties.Put("SqlColumn", "CODE_NAME");
            this.colsCodeName.NamedProperties.Put("ValidateMethod", "");
            this.colsCodeName.Position = 7;
            resources.ApplyResources(this.colsCodeName, "colsCodeName");
            this.colsCodeName.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsCodeName_WindowActions);
            // 
            // menuTbwMethods
            // 
            this.menuTbwMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem__Attribute,
            this.menuItem_Connect,
            this.menuSeparator1,
            this.menuItem__Change});
            this.menuTbwMethods.Name = "menuTbwMethods";
            resources.ApplyResources(this.menuTbwMethods, "menuTbwMethods");
            // 
            // menuItem__Attribute
            // 
            this.menuItem__Attribute.Command = this.menuTbwMethods_menu_Attribute_Value___;
            this.menuItem__Attribute.Name = "menuItem__Attribute";
            resources.ApplyResources(this.menuItem__Attribute, "menuItem__Attribute");
            this.menuItem__Attribute.Text = "&Attribute Value...";
            // 
            // menuItem_Connect
            // 
            this.menuItem_Connect.Command = this.menuTbwMethods_menuC_onnect_Attribute___;
            this.menuItem_Connect.Name = "menuItem_Connect";
            resources.ApplyResources(this.menuItem_Connect, "menuItem_Connect");
            this.menuItem_Connect.Text = "C&onnect Attribute...";
            // 
            // menuSeparator1
            // 
            this.menuSeparator1.Name = "menuSeparator1";
            resources.ApplyResources(this.menuSeparator1, "menuSeparator1");
            // 
            // menuItem__Change
            // 
            this.menuItem__Change.Command = this.menuTbwMethods_menu_Change_Company___;
            this.menuItem__Change.Name = "menuItem__Change";
            resources.ApplyResources(this.menuItem__Change, "menuItem__Change");
            this.menuItem__Change.Text = "&Change Company...";
            // 
            // menuOperations
            // 
            this.menuOperations.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem__Attribute_1,
            this.menuItem_Connect_1,
            this.menuSeparator2,
            this.menuItem__Change_1});
            this.menuOperations.Name = "menuOperations";
            resources.ApplyResources(this.menuOperations, "menuOperations");
            // 
            // menuItem__Attribute_1
            // 
            this.menuItem__Attribute_1.Command = this.menuOperations_menu_Attribute_Value___;
            this.menuItem__Attribute_1.Name = "menuItem__Attribute_1";
            resources.ApplyResources(this.menuItem__Attribute_1, "menuItem__Attribute_1");
            this.menuItem__Attribute_1.Text = "&Attribute Value...";
            // 
            // menuItem_Connect_1
            // 
            this.menuItem_Connect_1.Command = this.menuOperations_menuC_onnect_Attribute___;
            this.menuItem_Connect_1.Name = "menuItem_Connect_1";
            resources.ApplyResources(this.menuItem_Connect_1, "menuItem_Connect_1");
            this.menuItem_Connect_1.Text = "C&onnect Attribute...";
            // 
            // menuSeparator2
            // 
            this.menuSeparator2.Name = "menuSeparator2";
            resources.ApplyResources(this.menuSeparator2, "menuSeparator2");
            // 
            // menuItem__Change_1
            // 
            this.menuItem__Change_1.Command = this.menuOperations_menu_Change_Company___;
            this.menuItem__Change_1.Name = "menuItem__Change_1";
            resources.ApplyResources(this.menuItem__Change_1, "menuItem__Change_1");
            this.menuItem__Change_1.Text = "&Change Company...";
            // 
            // tbwAttribute
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colsCompany);
            this.Controls.Add(this.colsAttribute);
            this.Controls.Add(this.colsDescription);
            this.Controls.Add(this.colsCodePart);
            this.Controls.Add(this.colsCodeName);
            this.Name = "tbwAttribute";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "AccountingAttribute");
            this.NamedProperties.Put("PackageName", "ACCOUNTING_ATTRIBUTE_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "0");
            this.NamedProperties.Put("SourceFlags", "449");
            this.NamedProperties.Put("ViewName", "ACCOUNTING_ATTRIBUTE");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tbwAttribute_WindowActions);
            this.Controls.SetChildIndex(this.colsCodeName, 0);
            this.Controls.SetChildIndex(this.colsCodePart, 0);
            this.Controls.SetChildIndex(this.colsDescription, 0);
            this.Controls.SetChildIndex(this.colsAttribute, 0);
            this.Controls.SetChildIndex(this.colsCompany, 0);
            this.Controls.SetChildIndex(this.@__colObjversion, 0);
            this.Controls.SetChildIndex(this.@__colObjid, 0);
            this.menuTbwMethods.ResumeLayout(false);
            this.menuOperations.ResumeLayout(false);
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

        public Fnd.Windows.Forms.FndCommand menuOperations_menu_Attribute_Value___;
        public Fnd.Windows.Forms.FndCommand menuOperations_menuC_onnect_Attribute___;
        public Fnd.Windows.Forms.FndCommand menuOperations_menu_Change_Company___;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menu_Attribute_Value___;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menuC_onnect_Attribute___;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menu_Change_Company___;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTbwMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Attribute;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Connect;
        protected Fnd.Windows.Forms.FndToolStripSeparator menuSeparator1;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Change;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuOperations;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Attribute_1;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Connect_1;
        protected Fnd.Windows.Forms.FndToolStripSeparator menuSeparator2;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Change_1;
	}
}
