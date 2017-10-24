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
	
	public partial class tbwAttributeCon
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cColumn colsCompany;
		public cColumn colsAttribute;
		// Bug 83857, Begin, Checked F1 property queryable
		public cColumn colsAccountingAttributeDesc;
		// Bug 83857, End
		// Bug 83782 Begin , set visible Class Default and changed the position
		public cColumn colsCodePart;
		// Bug 83782 End
		// Bug 83782 Begin , changed object title
		public cColumn colsCodePartName;
		// Bug 83782 End
		// Bug 83857, Begin, Checked F1 property queryable
		public cColumn colsCodePartValue;
		public cColumn colsCodePartValueDescription;
		// Bug 83857, End
		public cColumn colsAttributeValue;
		// Bug 83857, Begin, Checked F1 property queryable
		public cColumn colsAccountingAttributeValueDesc;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwAttributeCon));
            this.menuOperations_menu_Attribute_Value___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuOperations_menu_Change_Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_menu_Attribute_Value___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_menu_Change_Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.colsCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsAttribute = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsAccountingAttributeDesc = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsCodePart = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsCodePartName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsCodePartValue = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsCodePartValueDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsAttributeValue = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsAccountingAttributeValueDesc = new Ifs.Fnd.ApplicationForms.cColumn();
            this.menuTbwMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem__Attribute = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuSeparator1 = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.menuItem__Change = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuOperations = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem__Attribute_1 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuSeparator2 = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.menuItem__Change_1 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuTbwMethods.SuspendLayout();
            this.menuOperations.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuTbwMethods_menu_Attribute_Value___);
            this.commandManager.Commands.Add(this.menuTbwMethods_menu_Change_Company___);
            this.commandManager.Commands.Add(this.menuOperations_menu_Attribute_Value___);
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
            // menuTbwMethods_menu_Change_Company___
            // 
            resources.ApplyResources(this.menuTbwMethods_menu_Change_Company___, "menuTbwMethods_menu_Change_Company___");
            this.menuTbwMethods_menu_Change_Company___.Name = "menuTbwMethods_menu_Change_Company___";
            this.menuTbwMethods_menu_Change_Company___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Change_Execute);
            this.menuTbwMethods_menu_Change_Company___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Change_Inquire);
            // 
            // colsCompany
            // 
            this.colsCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.colsCompany, "colsCompany");
            this.colsCompany.MaxLength = 20;
            this.colsCompany.Name = "colsCompany";
            this.colsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.colsCompany.NamedProperties.Put("FieldFlags", "67");
            this.colsCompany.NamedProperties.Put("LovReference", "");
            this.colsCompany.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
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
            this.colsAttribute.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsAttribute_WindowActions);
            // 
            // colsAccountingAttributeDesc
            // 
            this.colsAccountingAttributeDesc.MaxLength = 200;
            this.colsAccountingAttributeDesc.Name = "colsAccountingAttributeDesc";
            this.colsAccountingAttributeDesc.NamedProperties.Put("EnumerateMethod", "");
            this.colsAccountingAttributeDesc.NamedProperties.Put("FieldFlags", "288");
            this.colsAccountingAttributeDesc.NamedProperties.Put("LovReference", "");
            this.colsAccountingAttributeDesc.NamedProperties.Put("ParentName", "colsAttribute");
            this.colsAccountingAttributeDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.colsAccountingAttributeDesc.NamedProperties.Put("SqlColumn", "ACCOUNTING_ATTRIBUTE_API.Get_Desc(COMPANY,ATTRIBUTE)");
            this.colsAccountingAttributeDesc.NamedProperties.Put("ValidateMethod", "");
            this.colsAccountingAttributeDesc.Position = 5;
            resources.ApplyResources(this.colsAccountingAttributeDesc, "colsAccountingAttributeDesc");
            // 
            // colsCodePart
            // 
            this.colsCodePart.MaxLength = 1;
            this.colsCodePart.Name = "colsCodePart";
            this.colsCodePart.NamedProperties.Put("EnumerateMethod", "");
            this.colsCodePart.NamedProperties.Put("FieldFlags", "67");
            this.colsCodePart.NamedProperties.Put("LovReference", "ACCOUNTING_CODE_PARTS_USED2(COMPANY,CODE_PART)");
            this.colsCodePart.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsCodePart.NamedProperties.Put("ResizeableChildObject", "");
            this.colsCodePart.NamedProperties.Put("SqlColumn", "CODE_PART");
            this.colsCodePart.NamedProperties.Put("ValidateMethod", "");
            this.colsCodePart.Position = 6;
            resources.ApplyResources(this.colsCodePart, "colsCodePart");
            // 
            // colsCodePartName
            // 
            this.colsCodePartName.MaxLength = 10;
            this.colsCodePartName.Name = "colsCodePartName";
            this.colsCodePartName.NamedProperties.Put("EnumerateMethod", "");
            this.colsCodePartName.NamedProperties.Put("FieldFlags", "288");
            this.colsCodePartName.NamedProperties.Put("LovReference", "ACCOUNTING_CODE_PARTS_USED2(COMPANY,CODE_PART)");
            this.colsCodePartName.NamedProperties.Put("ParentName", "colsAttribute");
            this.colsCodePartName.NamedProperties.Put("ResizeableChildObject", "");
            this.colsCodePartName.NamedProperties.Put("SqlColumn", "ACCOUNTING_ATTRIBUTE_API.Get_Code_Part_Name(company,ATTRIBUTE)");
            this.colsCodePartName.NamedProperties.Put("ValidateMethod", "");
            this.colsCodePartName.Position = 7;
            resources.ApplyResources(this.colsCodePartName, "colsCodePartName");
            // 
            // colsCodePartValue
            // 
            this.colsCodePartValue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsCodePartValue.MaxLength = 20;
            this.colsCodePartValue.Name = "colsCodePartValue";
            this.colsCodePartValue.NamedProperties.Put("EnumerateMethod", "");
            this.colsCodePartValue.NamedProperties.Put("FieldFlags", "99");
            this.colsCodePartValue.NamedProperties.Put("LovReference", "CODE_PART_VALUE_FOR_CONS(COMPANY,CODE_PART)");
            this.colsCodePartValue.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsCodePartValue.NamedProperties.Put("ResizeableChildObject", "");
            this.colsCodePartValue.NamedProperties.Put("SqlColumn", "CODE_PART_VALUE");
            this.colsCodePartValue.NamedProperties.Put("ValidateMethod", "");
            this.colsCodePartValue.Position = 8;
            resources.ApplyResources(this.colsCodePartValue, "colsCodePartValue");
            this.colsCodePartValue.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsCodePartValue_WindowActions);
            // 
            // colsCodePartValueDescription
            // 
            this.colsCodePartValueDescription.MaxLength = 200;
            this.colsCodePartValueDescription.Name = "colsCodePartValueDescription";
            this.colsCodePartValueDescription.NamedProperties.Put("EnumerateMethod", "");
            this.colsCodePartValueDescription.NamedProperties.Put("FieldFlags", "288");
            this.colsCodePartValueDescription.NamedProperties.Put("LovReference", "");
            this.colsCodePartValueDescription.NamedProperties.Put("ParentName", "colsCodePartValue");
            this.colsCodePartValueDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.colsCodePartValueDescription.NamedProperties.Put("SqlColumn", "ACCOUNTING_CODE_PART_VALUE_API.Get_Description(company,code_part,CODE_PART_VALUE)" +
                    "");
            this.colsCodePartValueDescription.NamedProperties.Put("ValidateMethod", "");
            this.colsCodePartValueDescription.Position = 9;
            resources.ApplyResources(this.colsCodePartValueDescription, "colsCodePartValueDescription");
            // 
            // colsAttributeValue
            // 
            this.colsAttributeValue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsAttributeValue.Name = "colsAttributeValue";
            this.colsAttributeValue.NamedProperties.Put("EnumerateMethod", "");
            this.colsAttributeValue.NamedProperties.Put("FieldFlags", "167");
            this.colsAttributeValue.NamedProperties.Put("LovReference", "ACCOUNTING_ATTRIBUTE_VALUE(COMPANY,ATTRIBUTE)");
            this.colsAttributeValue.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsAttributeValue.NamedProperties.Put("ResizeableChildObject", "");
            this.colsAttributeValue.NamedProperties.Put("SqlColumn", "ATTRIBUTE_VALUE");
            this.colsAttributeValue.NamedProperties.Put("ValidateMethod", "");
            this.colsAttributeValue.Position = 10;
            resources.ApplyResources(this.colsAttributeValue, "colsAttributeValue");
            this.colsAttributeValue.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsAttributeValue_WindowActions);
            // 
            // colsAccountingAttributeValueDesc
            // 
            this.colsAccountingAttributeValueDesc.MaxLength = 200;
            this.colsAccountingAttributeValueDesc.Name = "colsAccountingAttributeValueDesc";
            this.colsAccountingAttributeValueDesc.NamedProperties.Put("EnumerateMethod", "");
            this.colsAccountingAttributeValueDesc.NamedProperties.Put("FieldFlags", "288");
            this.colsAccountingAttributeValueDesc.NamedProperties.Put("LovReference", "");
            this.colsAccountingAttributeValueDesc.NamedProperties.Put("ParentName", "colsAttributeValue");
            this.colsAccountingAttributeValueDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.colsAccountingAttributeValueDesc.NamedProperties.Put("SqlColumn", "ACCOUNTING_ATTRIBUTE_VALUE_API.Get_Desc(company,attribute,ATTRIBUTE_VALUE)");
            this.colsAccountingAttributeValueDesc.NamedProperties.Put("ValidateMethod", "");
            this.colsAccountingAttributeValueDesc.Position = 11;
            resources.ApplyResources(this.colsAccountingAttributeValueDesc, "colsAccountingAttributeValueDesc");
            // 
            // menuTbwMethods
            // 
            this.menuTbwMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem__Attribute,
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
            // tbwAttributeCon
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colsCompany);
            this.Controls.Add(this.colsAttribute);
            this.Controls.Add(this.colsAccountingAttributeDesc);
            this.Controls.Add(this.colsCodePart);
            this.Controls.Add(this.colsCodePartName);
            this.Controls.Add(this.colsCodePartValue);
            this.Controls.Add(this.colsCodePartValueDescription);
            this.Controls.Add(this.colsAttributeValue);
            this.Controls.Add(this.colsAccountingAttributeValueDesc);
            this.Name = "tbwAttributeCon";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "COMPANY = :global.company");
            this.NamedProperties.Put("LogicalUnit", "AccountingAttributeCon");
            this.NamedProperties.Put("PackageName", "ACCOUNTING_ATTRIBUTE_CON_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "449");
            this.NamedProperties.Put("ViewName", "ACCOUNTING_ATTRIBUTE_CON");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tbwAttributeCon_WindowActions);
            this.Controls.SetChildIndex(this.colsAccountingAttributeValueDesc, 0);
            this.Controls.SetChildIndex(this.colsAttributeValue, 0);
            this.Controls.SetChildIndex(this.colsCodePartValueDescription, 0);
            this.Controls.SetChildIndex(this.colsCodePartValue, 0);
            this.Controls.SetChildIndex(this.colsCodePartName, 0);
            this.Controls.SetChildIndex(this.colsCodePart, 0);
            this.Controls.SetChildIndex(this.colsAccountingAttributeDesc, 0);
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
        public Fnd.Windows.Forms.FndCommand menuOperations_menu_Change_Company___;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menu_Attribute_Value___;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menu_Change_Company___;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTbwMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Attribute;
        protected Fnd.Windows.Forms.FndToolStripSeparator menuSeparator1;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Change;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuOperations;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Attribute_1;
        protected Fnd.Windows.Forms.FndToolStripSeparator menuSeparator2;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Change_1;
	}
}
