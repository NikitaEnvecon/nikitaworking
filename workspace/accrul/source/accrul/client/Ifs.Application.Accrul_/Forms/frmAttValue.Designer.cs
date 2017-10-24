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
	
	public partial class frmAttValue
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cDataField dfsCompany;
		protected cBackgroundText labelcmbsAttribute;
		public cRecListDataField cmbsAttribute;
		protected cBackgroundText labeldfsDescription;
		// Bug 83857, Begin, Checked F1 property queryable
		public cDataField dfsDescription;
		protected cBackgroundText labeldfsCodePart;
		public cDataField dfsCodePart;
		// Bug 83782 Begin , changed Object Title
		protected cBackgroundText labeldfsCodePartName;
		public cDataField dfsCodePartName;
		// Bug 83782 End
		// Bug 83857, End
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAttValue));
            this.menuTblMethods_menuC_onnect_Attribute___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTblMethods_menu_Change_Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuOperations_menuC_onnect_Attribute___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuOperations_menu_Change_Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuFrmMethods_menuC_onnect_Attribute___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuFrmMethods_menu_Change_Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.dfsCompany = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelcmbsAttribute = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbsAttribute = new Ifs.Fnd.ApplicationForms.cRecListDataField();
            this.labeldfsDescription = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsDescription = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsCodePart = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsCodePart = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsCodePartName = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsCodePartName = new Ifs.Fnd.ApplicationForms.cDataField();
            this.menuFrmMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_Connect = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuSeparator1 = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.menuItem__Change = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuOperations = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_Connect_1 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuSeparator2 = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.menuItem__Change_1 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuTblMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_Connect_2 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuSeparator3 = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.menuItem__Change_2 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.tblAttValue = new Ifs.Application.Accrul.cChildTableFinBase();
            this.tblAttValue_colsCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblAttValue_colsAttribute = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblAttValue_colsAttributeValue = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblAttValue_colsDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.menuFrmMethods.SuspendLayout();
            this.menuOperations.SuspendLayout();
            this.menuTblMethods.SuspendLayout();
            this.tblAttValue.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuFrmMethods_menuC_onnect_Attribute___);
            this.commandManager.Commands.Add(this.menuFrmMethods_menu_Change_Company___);
            this.commandManager.Commands.Add(this.menuOperations_menuC_onnect_Attribute___);
            this.commandManager.Commands.Add(this.menuOperations_menu_Change_Company___);
            this.commandManager.Commands.Add(this.menuTblMethods_menuC_onnect_Attribute___);
            this.commandManager.Commands.Add(this.menuTblMethods_menu_Change_Company___);
            this.commandManager.ContextMenus.Add(this.menuFrmMethods);
            this.commandManager.ContextMenus.Add(this.menuOperations);
            this.commandManager.ContextMenus.Add(this.menuTblMethods);
            this.commandManager.ImageList = null;
            // 
            // menuTblMethods_menuC_onnect_Attribute___
            // 
            resources.ApplyResources(this.menuTblMethods_menuC_onnect_Attribute___, "menuTblMethods_menuC_onnect_Attribute___");
            this.menuTblMethods_menuC_onnect_Attribute___.Name = "menuTblMethods_menuC_onnect_Attribute___";
            this.menuTblMethods_menuC_onnect_Attribute___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Connect_2_Execute);
            this.menuTblMethods_menuC_onnect_Attribute___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Connect_2_Inquire);
            // 
            // menuTblMethods_menu_Change_Company___
            // 
            resources.ApplyResources(this.menuTblMethods_menu_Change_Company___, "menuTblMethods_menu_Change_Company___");
            this.menuTblMethods_menu_Change_Company___.Name = "menuTblMethods_menu_Change_Company___";
            this.menuTblMethods_menu_Change_Company___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Change_2_Execute);
            this.menuTblMethods_menu_Change_Company___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Change_2_Inquire);
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
            // menuFrmMethods_menuC_onnect_Attribute___
            // 
            resources.ApplyResources(this.menuFrmMethods_menuC_onnect_Attribute___, "menuFrmMethods_menuC_onnect_Attribute___");
            this.menuFrmMethods_menuC_onnect_Attribute___.Name = "menuFrmMethods_menuC_onnect_Attribute___";
            this.menuFrmMethods_menuC_onnect_Attribute___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Connect_Execute);
            this.menuFrmMethods_menuC_onnect_Attribute___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Connect_Inquire);
            // 
            // menuFrmMethods_menu_Change_Company___
            // 
            resources.ApplyResources(this.menuFrmMethods_menu_Change_Company___, "menuFrmMethods_menu_Change_Company___");
            this.menuFrmMethods_menu_Change_Company___.Name = "menuFrmMethods_menu_Change_Company___";
            this.menuFrmMethods_menu_Change_Company___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Change_Execute);
            this.menuFrmMethods_menu_Change_Company___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Change_Inquire);
            // 
            // dfsCompany
            // 
            resources.ApplyResources(this.dfsCompany, "dfsCompany");
            this.dfsCompany.Name = "dfsCompany";
            this.dfsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.dfsCompany.NamedProperties.Put("FieldFlags", "128");
            this.dfsCompany.NamedProperties.Put("LovReference", "");
            this.dfsCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.dfsCompany.NamedProperties.Put("ValidateMethod", "");
            // 
            // labelcmbsAttribute
            // 
            resources.ApplyResources(this.labelcmbsAttribute, "labelcmbsAttribute");
            this.labelcmbsAttribute.Name = "labelcmbsAttribute";
            // 
            // cmbsAttribute
            // 
            this.cmbsAttribute.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.cmbsAttribute, "cmbsAttribute");
            this.cmbsAttribute.Name = "cmbsAttribute";
            this.cmbsAttribute.NamedProperties.Put("EnumerateMethod", "");
            this.cmbsAttribute.NamedProperties.Put("FieldFlags", "160");
            this.cmbsAttribute.NamedProperties.Put("Format", "9");
            this.cmbsAttribute.NamedProperties.Put("LovReference", "ACCOUNTING_ATTRIBUTE(COMPANY)");
            this.cmbsAttribute.NamedProperties.Put("ResizableChildObject", "");
            this.cmbsAttribute.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbsAttribute.NamedProperties.Put("SqlColumn", "ATTRIBUTE");
            this.cmbsAttribute.NamedProperties.Put("ValidateMethod", "");
            this.cmbsAttribute.NamedProperties.Put("XDataLength", "20");
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
            this.dfsDescription.NamedProperties.Put("FieldFlags", "288");
            this.dfsDescription.NamedProperties.Put("LovReference", "");
            this.dfsDescription.NamedProperties.Put("ParentName", "cmbsAttribute");
            this.dfsDescription.NamedProperties.Put("ResizableChildObject", "");
            this.dfsDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsDescription.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            this.dfsDescription.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsCodePart
            // 
            resources.ApplyResources(this.labeldfsCodePart, "labeldfsCodePart");
            this.labeldfsCodePart.Name = "labeldfsCodePart";
            // 
            // dfsCodePart
            // 
            resources.ApplyResources(this.dfsCodePart, "dfsCodePart");
            this.dfsCodePart.Name = "dfsCodePart";
            this.dfsCodePart.NamedProperties.Put("EnumerateMethod", "");
            this.dfsCodePart.NamedProperties.Put("LovReference", "ACCOUNTING_CODE_PARTS_USED2(COMPANY,CODE_PART)");
            this.dfsCodePart.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsCodePart.NamedProperties.Put("SqlColumn", "CODE_PART");
            this.dfsCodePart.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsCodePartName
            // 
            resources.ApplyResources(this.labeldfsCodePartName, "labeldfsCodePartName");
            this.labeldfsCodePartName.Name = "labeldfsCodePartName";
            // 
            // dfsCodePartName
            // 
            resources.ApplyResources(this.dfsCodePartName, "dfsCodePartName");
            this.dfsCodePartName.Name = "dfsCodePartName";
            this.dfsCodePartName.NamedProperties.Put("EnumerateMethod", "");
            this.dfsCodePartName.NamedProperties.Put("FieldFlags", "288");
            this.dfsCodePartName.NamedProperties.Put("LovReference", "ACCOUNTING_CODE_PARTS_USED2(COMPANY)");
            this.dfsCodePartName.NamedProperties.Put("ParentName", "cmbsAttribute");
            this.dfsCodePartName.NamedProperties.Put("ResizableChildObject", "");
            this.dfsCodePartName.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsCodePartName.NamedProperties.Put("SqlColumn", "ACCOUNTING_CODE_PARTS_API.GET_NAME(COMPANY,CODE_PART)");
            this.dfsCodePartName.NamedProperties.Put("ValidateMethod", "");
            // 
            // menuFrmMethods
            // 
            this.menuFrmMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_Connect,
            this.menuSeparator1,
            this.menuItem__Change});
            this.menuFrmMethods.Name = "menuFrmMethods";
            resources.ApplyResources(this.menuFrmMethods, "menuFrmMethods");
            // 
            // menuItem_Connect
            // 
            this.menuItem_Connect.Command = this.menuFrmMethods_menuC_onnect_Attribute___;
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
            this.menuItem__Change.Command = this.menuFrmMethods_menu_Change_Company___;
            this.menuItem__Change.Name = "menuItem__Change";
            resources.ApplyResources(this.menuItem__Change, "menuItem__Change");
            this.menuItem__Change.Text = "&Change Company...";
            // 
            // menuOperations
            // 
            this.menuOperations.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_Connect_1,
            this.menuSeparator2,
            this.menuItem__Change_1});
            this.menuOperations.Name = "menuOperations";
            resources.ApplyResources(this.menuOperations, "menuOperations");
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
            // menuTblMethods
            // 
            this.menuTblMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_Connect_2,
            this.menuSeparator3,
            this.menuItem__Change_2});
            this.menuTblMethods.Name = "menuTblMethods";
            resources.ApplyResources(this.menuTblMethods, "menuTblMethods");
            // 
            // menuItem_Connect_2
            // 
            this.menuItem_Connect_2.Command = this.menuTblMethods_menuC_onnect_Attribute___;
            this.menuItem_Connect_2.Name = "menuItem_Connect_2";
            resources.ApplyResources(this.menuItem_Connect_2, "menuItem_Connect_2");
            this.menuItem_Connect_2.Text = "C&onnect Attribute...";
            // 
            // menuSeparator3
            // 
            this.menuSeparator3.Name = "menuSeparator3";
            resources.ApplyResources(this.menuSeparator3, "menuSeparator3");
            // 
            // menuItem__Change_2
            // 
            this.menuItem__Change_2.Command = this.menuTblMethods_menu_Change_Company___;
            this.menuItem__Change_2.Name = "menuItem__Change_2";
            resources.ApplyResources(this.menuItem__Change_2, "menuItem__Change_2");
            this.menuItem__Change_2.Text = "&Change Company...";
            // 
            // tblAttValue
            // 
            this.tblAttValue.Controls.Add(this.tblAttValue_colsCompany);
            this.tblAttValue.Controls.Add(this.tblAttValue_colsAttribute);
            this.tblAttValue.Controls.Add(this.tblAttValue_colsAttributeValue);
            this.tblAttValue.Controls.Add(this.tblAttValue_colsDescription);
            resources.ApplyResources(this.tblAttValue, "tblAttValue");
            this.tblAttValue.Name = "tblAttValue";
            this.tblAttValue.NamedProperties.Put("DefaultOrderBy", "");
            this.tblAttValue.NamedProperties.Put("DefaultWhere", "");
            this.tblAttValue.NamedProperties.Put("LogicalUnit", "AccountingAttributeValue");
            this.tblAttValue.NamedProperties.Put("PackageName", "ACCOUNTING_ATTRIBUTE_VALUE_API");
            this.tblAttValue.NamedProperties.Put("ResizableChildObject", "LLRR");
            this.tblAttValue.NamedProperties.Put("ResizeableChildObject", "1");
            this.tblAttValue.NamedProperties.Put("ViewName", "ACCOUNTING_ATTRIBUTE_VALUE");
            this.tblAttValue.DataRecordGetDefaultsEvent += new System.EventHandler<Ifs.Fnd.ApplicationForms.FndReturnEventArgsSalBoolean>(this.tblAttValue_DataRecordGetDefaultsEvent);
            this.tblAttValue.Controls.SetChildIndex(this.tblAttValue_colsDescription, 0);
            this.tblAttValue.Controls.SetChildIndex(this.tblAttValue_colsAttributeValue, 0);
            this.tblAttValue.Controls.SetChildIndex(this.tblAttValue_colsAttribute, 0);
            this.tblAttValue.Controls.SetChildIndex(this.tblAttValue_colsCompany, 0);
            // 
            // tblAttValue_colsCompany
            // 
            resources.ApplyResources(this.tblAttValue_colsCompany, "tblAttValue_colsCompany");
            this.tblAttValue_colsCompany.MaxLength = 20;
            this.tblAttValue_colsCompany.Name = "tblAttValue_colsCompany";
            this.tblAttValue_colsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.tblAttValue_colsCompany.NamedProperties.Put("FieldFlags", "67");
            this.tblAttValue_colsCompany.NamedProperties.Put("LovReference", "");
            this.tblAttValue_colsCompany.NamedProperties.Put("ResizableChildObject", "");
            this.tblAttValue_colsCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.tblAttValue_colsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.tblAttValue_colsCompany.NamedProperties.Put("ValidateMethod", "");
            this.tblAttValue_colsCompany.Position = 3;
            // 
            // tblAttValue_colsAttribute
            // 
            resources.ApplyResources(this.tblAttValue_colsAttribute, "tblAttValue_colsAttribute");
            this.tblAttValue_colsAttribute.MaxLength = 20;
            this.tblAttValue_colsAttribute.Name = "tblAttValue_colsAttribute";
            this.tblAttValue_colsAttribute.NamedProperties.Put("EnumerateMethod", "");
            this.tblAttValue_colsAttribute.NamedProperties.Put("FieldFlags", "67");
            this.tblAttValue_colsAttribute.NamedProperties.Put("LovReference", "");
            this.tblAttValue_colsAttribute.NamedProperties.Put("ResizableChildObject", "");
            this.tblAttValue_colsAttribute.NamedProperties.Put("SqlColumn", "ATTRIBUTE");
            this.tblAttValue_colsAttribute.NamedProperties.Put("ValidateMethod", "");
            this.tblAttValue_colsAttribute.Position = 4;
            // 
            // tblAttValue_colsAttributeValue
            // 
            this.tblAttValue_colsAttributeValue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblAttValue_colsAttributeValue.Name = "tblAttValue_colsAttributeValue";
            this.tblAttValue_colsAttributeValue.NamedProperties.Put("EnumerateMethod", "");
            this.tblAttValue_colsAttributeValue.NamedProperties.Put("FieldFlags", "163");
            this.tblAttValue_colsAttributeValue.NamedProperties.Put("LovReference", "ACCOUNTING_ATTRIBUTE_VALUE(COMPANY,ATTRIBUTE)");
            this.tblAttValue_colsAttributeValue.NamedProperties.Put("ResizableChildObject", "");
            this.tblAttValue_colsAttributeValue.NamedProperties.Put("ResizeableChildObject", "");
            this.tblAttValue_colsAttributeValue.NamedProperties.Put("SqlColumn", "ATTRIBUTE_VALUE");
            this.tblAttValue_colsAttributeValue.NamedProperties.Put("ValidateMethod", "");
            this.tblAttValue_colsAttributeValue.Position = 5;
            resources.ApplyResources(this.tblAttValue_colsAttributeValue, "tblAttValue_colsAttributeValue");
            // 
            // tblAttValue_colsDescription
            // 
            this.tblAttValue_colsDescription.MaxLength = 200;
            this.tblAttValue_colsDescription.Name = "tblAttValue_colsDescription";
            this.tblAttValue_colsDescription.NamedProperties.Put("EnumerateMethod", "");
            this.tblAttValue_colsDescription.NamedProperties.Put("FieldFlags", "295");
            this.tblAttValue_colsDescription.NamedProperties.Put("LovReference", "");
            this.tblAttValue_colsDescription.NamedProperties.Put("ResizableChildObject", "");
            this.tblAttValue_colsDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.tblAttValue_colsDescription.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            this.tblAttValue_colsDescription.NamedProperties.Put("ValidateMethod", "");
            this.tblAttValue_colsDescription.Position = 6;
            resources.ApplyResources(this.tblAttValue_colsDescription, "tblAttValue_colsDescription");
            // 
            // frmAttValue
            // 
            this.AutoScaleBaseDpi = new System.Drawing.Size(106, 106);
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.tblAttValue);
            this.Controls.Add(this.dfsCodePartName);
            this.Controls.Add(this.dfsCodePart);
            this.Controls.Add(this.dfsDescription);
            this.Controls.Add(this.cmbsAttribute);
            this.Controls.Add(this.dfsCompany);
            this.Controls.Add(this.labeldfsCodePartName);
            this.Controls.Add(this.labeldfsCodePart);
            this.Controls.Add(this.labeldfsDescription);
            this.Controls.Add(this.labelcmbsAttribute);
            this.MaximizeBox = true;
            this.Name = "frmAttValue";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "COMPANY = :i_hWndFrame.frmAttValue.i_sCompany");
            this.NamedProperties.Put("LogicalUnit", "AccountingAttribute");
            this.NamedProperties.Put("PackageName", "ACCOUNTING_ATTRIBUTE_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "0");
            this.NamedProperties.Put("SourceFlags", "385");
            this.NamedProperties.Put("ViewName", "ACCOUNTING_ATTRIBUTE");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.frmAttValue_WindowActions);
            this.menuFrmMethods.ResumeLayout(false);
            this.menuOperations.ResumeLayout(false);
            this.menuTblMethods.ResumeLayout(false);
            this.tblAttValue.ResumeLayout(false);
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
		
		

        public Fnd.Windows.Forms.FndCommand menuTblMethods_menuC_onnect_Attribute___;
        public Fnd.Windows.Forms.FndCommand menuTblMethods_menu_Change_Company___;
        public Fnd.Windows.Forms.FndCommand menuOperations_menuC_onnect_Attribute___;
        public Fnd.Windows.Forms.FndCommand menuOperations_menu_Change_Company___;
        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menuC_onnect_Attribute___;
        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menu_Change_Company___;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuFrmMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Connect;
        protected Fnd.Windows.Forms.FndToolStripSeparator menuSeparator1;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Change;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuOperations;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Connect_1;
        protected Fnd.Windows.Forms.FndToolStripSeparator menuSeparator2;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Change_1;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTblMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Connect_2;
        protected Fnd.Windows.Forms.FndToolStripSeparator menuSeparator3;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Change_2;
        public Accrul.cChildTableFinBase tblAttValue;
        protected cColumn tblAttValue_colsCompany;
        protected cColumn tblAttValue_colsAttribute;
        protected cColumn tblAttValue_colsAttributeValue;
        protected cColumn tblAttValue_colsDescription;
	}
}
