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
	
	public partial class tbwCodeG
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cColumn colsCompany;
		public cColumnFin colsCodeG;
		public cColumn colsDescription;
		public cColumn coldValidFrom;
		public cColumn coldValidUntil;
		// Bug 82101, Begin. Wrapped
		public cCheckBoxColumn colsCBCodeStr;
		// Bug 82101, End
		// Bug 70804, Begin. Made Editable 'No'.
		public cCheckBoxColumn colsCBText;
		// Bug 70804, End.
		public cColumn colText;
		// Bug 82101, Begin. Wrapped
		public cCheckBoxColumn colsCBAttribute;
		// Bug 82101, End
		public cColumn colsConsCompany;
		public cColumn colsConsCodePart;
		// Bug 82101, Begin. Wrapped
		public cColumn colsConsCodePartValue;
		// Bug 82101, End
		public cColumn colsConsCodePartValDesc;
		public cColumn colCodePart;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwCodeG));
            this.menuTbwMethods_menuCode__String_Completion___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_menu_Translation___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_menu_Code_Part_Attribute_Connection_ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_menu_Notes___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_menuChange_Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.colsCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsCodeG = new Ifs.Application.Accrul.cColumnFin();
            this.colsDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.coldValidFrom = new Ifs.Fnd.ApplicationForms.cColumn();
            this.coldValidUntil = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsCBCodeStr = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.colsCBText = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.colText = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsCBAttribute = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.colsConsCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsConsCodePart = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsConsCodePartValue = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsConsCodePartValDesc = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colCodePart = new Ifs.Fnd.ApplicationForms.cColumn();
            this.menuTbwMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_Code = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuSeparator1 = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.menuItem__Translation = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem__Code = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem__Notes = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuSeparator2 = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.menuItem_Change = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuTbwMethods.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuTbwMethods_menuCode__String_Completion___);
            this.commandManager.Commands.Add(this.menuTbwMethods_menu_Translation___);
            this.commandManager.Commands.Add(this.menuTbwMethods_menu_Code_Part_Attribute_Connection_);
            this.commandManager.Commands.Add(this.menuTbwMethods_menu_Notes___);
            this.commandManager.Commands.Add(this.menuTbwMethods_menuChange_Company___);
            this.commandManager.ContextMenus.Add(this.menuTbwMethods);
            // 
            // menuTbwMethods_menuCode__String_Completion___
            // 
            resources.ApplyResources(this.menuTbwMethods_menuCode__String_Completion___, "menuTbwMethods_menuCode__String_Completion___");
            this.menuTbwMethods_menuCode__String_Completion___.Name = "menuTbwMethods_menuCode__String_Completion___";
            this.menuTbwMethods_menuCode__String_Completion___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Code_Execute);
            this.menuTbwMethods_menuCode__String_Completion___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Code_Inquire);
            // 
            // menuTbwMethods_menu_Translation___
            // 
            resources.ApplyResources(this.menuTbwMethods_menu_Translation___, "menuTbwMethods_menu_Translation___");
            this.menuTbwMethods_menu_Translation___.Name = "menuTbwMethods_menu_Translation___";
            this.menuTbwMethods_menu_Translation___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Translation_Execute);
            this.menuTbwMethods_menu_Translation___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Translation_Inquire);
            // 
            // menuTbwMethods_menu_Code_Part_Attribute_Connection_
            // 
            resources.ApplyResources(this.menuTbwMethods_menu_Code_Part_Attribute_Connection_, "menuTbwMethods_menu_Code_Part_Attribute_Connection_");
            this.menuTbwMethods_menu_Code_Part_Attribute_Connection_.Name = "menuTbwMethods_menu_Code_Part_Attribute_Connection_";
            this.menuTbwMethods_menu_Code_Part_Attribute_Connection_.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Code_Execute);
            this.menuTbwMethods_menu_Code_Part_Attribute_Connection_.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Code_Inquire);
            // 
            // menuTbwMethods_menu_Notes___
            // 
            resources.ApplyResources(this.menuTbwMethods_menu_Notes___, "menuTbwMethods_menu_Notes___");
            this.menuTbwMethods_menu_Notes___.Name = "menuTbwMethods_menu_Notes___";
            this.menuTbwMethods_menu_Notes___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Notes_Execute);
            this.menuTbwMethods_menu_Notes___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Notes_Inquire);
            // 
            // menuTbwMethods_menuChange_Company___
            // 
            resources.ApplyResources(this.menuTbwMethods_menuChange_Company___, "menuTbwMethods_menuChange_Company___");
            this.menuTbwMethods_menuChange_Company___.Name = "menuTbwMethods_menuChange_Company___";
            this.menuTbwMethods_menuChange_Company___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Change_Execute);
            this.menuTbwMethods_menuChange_Company___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Change_Inquire);
            // 
            // colsCompany
            // 
            this.colsCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.colsCompany, "colsCompany");
            this.colsCompany.MaxLength = 20;
            this.colsCompany.Name = "colsCompany";
            this.colsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.colsCompany.NamedProperties.Put("FieldFlags", "67");
            this.colsCompany.NamedProperties.Put("LovReference", "COMPANY_FINANCE");
            this.colsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.colsCompany.Position = 3;
            // 
            // colsCodeG
            // 
            this.colsCodeG.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsCodeG.MaxLength = 10;
            this.colsCodeG.Name = "colsCodeG";
            this.colsCodeG.NamedProperties.Put("EnumerateMethod", "");
            this.colsCodeG.NamedProperties.Put("FieldFlags", "163");
            this.colsCodeG.NamedProperties.Put("LovReference", "");
            this.colsCodeG.NamedProperties.Put("ResizeableChildObject", "");
            this.colsCodeG.NamedProperties.Put("SqlColumn", "CODE_G");
            this.colsCodeG.NamedProperties.Put("ValidateMethod", "");
            this.colsCodeG.Position = 4;
            resources.ApplyResources(this.colsCodeG, "colsCodeG");
            this.colsCodeG.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsCodeG_WindowActions);
            // 
            // colsDescription
            // 
            this.colsDescription.Name = "colsDescription";
            this.colsDescription.NamedProperties.Put("EnumerateMethod", "");
            this.colsDescription.NamedProperties.Put("FieldFlags", "295");
            this.colsDescription.NamedProperties.Put("LovReference", "");
            this.colsDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.colsDescription.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            this.colsDescription.NamedProperties.Put("ValidateMethod", "");
            this.colsDescription.Position = 5;
            resources.ApplyResources(this.colsDescription, "colsDescription");
            // 
            // coldValidFrom
            // 
            this.coldValidFrom.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.coldValidFrom.Format = "d";
            this.coldValidFrom.Name = "coldValidFrom";
            this.coldValidFrom.NamedProperties.Put("EnumerateMethod", "");
            this.coldValidFrom.NamedProperties.Put("FieldFlags", "295");
            this.coldValidFrom.NamedProperties.Put("LovReference", "");
            this.coldValidFrom.NamedProperties.Put("ResizeableChildObject", "");
            this.coldValidFrom.NamedProperties.Put("SqlColumn", "VALID_FROM");
            this.coldValidFrom.NamedProperties.Put("ValidateMethod", "");
            this.coldValidFrom.Position = 6;
            resources.ApplyResources(this.coldValidFrom, "coldValidFrom");
            // 
            // coldValidUntil
            // 
            this.coldValidUntil.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.coldValidUntil.Format = "d";
            this.coldValidUntil.Name = "coldValidUntil";
            this.coldValidUntil.NamedProperties.Put("EnumerateMethod", "");
            this.coldValidUntil.NamedProperties.Put("FieldFlags", "295");
            this.coldValidUntil.NamedProperties.Put("LovReference", "");
            this.coldValidUntil.NamedProperties.Put("ResizeableChildObject", "");
            this.coldValidUntil.NamedProperties.Put("SqlColumn", "VALID_UNTIL");
            this.coldValidUntil.NamedProperties.Put("ValidateMethod", "");
            this.coldValidUntil.Position = 7;
            resources.ApplyResources(this.coldValidUntil, "coldValidUntil");
            // 
            // colsCBCodeStr
            // 
            this.colsCBCodeStr.CheckBox.CheckedValue = "T";
            this.colsCBCodeStr.CheckBox.IgnoreCase = true;
            this.colsCBCodeStr.CheckBox.UncheckedValue = "F";
            this.colsCBCodeStr.MaxLength = 1;
            this.colsCBCodeStr.Name = "colsCBCodeStr";
            this.colsCBCodeStr.NamedProperties.Put("EnumerateMethod", "");
            this.colsCBCodeStr.NamedProperties.Put("FieldFlags", "288");
            this.colsCBCodeStr.NamedProperties.Put("LovReference", "");
            this.colsCBCodeStr.NamedProperties.Put("ResizeableChildObject", "");
            this.colsCBCodeStr.NamedProperties.Put("SqlColumn", "ACCOUNTING_CODESTR_COMPL_API.Connect_To_Account(COMPANY,\'G\',CODE_G)");
            this.colsCBCodeStr.NamedProperties.Put("ValidateMethod", "");
            this.colsCBCodeStr.Position = 8;
            resources.ApplyResources(this.colsCBCodeStr, "colsCBCodeStr");
            // 
            // colsCBText
            // 
            resources.ApplyResources(this.colsCBText, "colsCBText");
            this.colsCBText.Name = "colsCBText";
            this.colsCBText.NamedProperties.Put("EnumerateMethod", "");
            this.colsCBText.NamedProperties.Put("FieldFlags", "800");
            this.colsCBText.NamedProperties.Put("LovReference", "");
            this.colsCBText.NamedProperties.Put("ResizeableChildObject", "");
            this.colsCBText.NamedProperties.Put("SqlColumn", "CB_TEXT");
            this.colsCBText.NamedProperties.Put("ValidateMethod", "");
            this.colsCBText.Position = 9;
            this.colsCBText.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsCBText_WindowActions);
            // 
            // colText
            // 
            resources.ApplyResources(this.colText, "colText");
            this.colText.MaxLength = 2000;
            this.colText.Name = "colText";
            this.colText.NamedProperties.Put("EnumerateMethod", "");
            this.colText.NamedProperties.Put("FieldFlags", "278");
            this.colText.NamedProperties.Put("LovReference", "");
            this.colText.NamedProperties.Put("SqlColumn", "TEXT");
            this.colText.NamedProperties.Put("ValidateMethod", "");
            this.colText.Position = 10;
            // 
            // colsCBAttribute
            // 
            this.colsCBAttribute.CheckBox.CheckedValue = "T";
            this.colsCBAttribute.CheckBox.IgnoreCase = true;
            this.colsCBAttribute.CheckBox.UncheckedValue = "F";
            this.colsCBAttribute.Name = "colsCBAttribute";
            this.colsCBAttribute.NamedProperties.Put("EnumerateMethod", "");
            this.colsCBAttribute.NamedProperties.Put("FieldFlags", "288");
            this.colsCBAttribute.NamedProperties.Put("LovReference", "");
            this.colsCBAttribute.NamedProperties.Put("ResizeableChildObject", "");
            this.colsCBAttribute.NamedProperties.Put("SqlColumn", "ACCOUNTING_ATTRIBUTE_CON_API.Connect_To_Attribute(COMPANY,\'G\',CODE_G)");
            this.colsCBAttribute.NamedProperties.Put("ValidateMethod", "");
            this.colsCBAttribute.Position = 11;
            resources.ApplyResources(this.colsCBAttribute, "colsCBAttribute");
            // 
            // colsConsCompany
            // 
            this.colsConsCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.colsConsCompany, "colsConsCompany");
            this.colsConsCompany.MaxLength = 20;
            this.colsConsCompany.Name = "colsConsCompany";
            this.colsConsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.colsConsCompany.NamedProperties.Put("LovReference", "");
            this.colsConsCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.colsConsCompany.NamedProperties.Put("SqlColumn", "CONS_COMPANY");
            this.colsConsCompany.NamedProperties.Put("ValidateMethod", "");
            this.colsConsCompany.Position = 12;
            // 
            // colsConsCodePart
            // 
            this.colsConsCodePart.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.colsConsCodePart, "colsConsCodePart");
            this.colsConsCodePart.MaxLength = 1;
            this.colsConsCodePart.Name = "colsConsCodePart";
            this.colsConsCodePart.NamedProperties.Put("EnumerateMethod", "");
            this.colsConsCodePart.NamedProperties.Put("LovReference", "");
            this.colsConsCodePart.NamedProperties.Put("ResizeableChildObject", "");
            this.colsConsCodePart.NamedProperties.Put("SqlColumn", "CONS_CODE_PART");
            this.colsConsCodePart.NamedProperties.Put("ValidateMethod", "");
            this.colsConsCodePart.Position = 13;
            // 
            // colsConsCodePartValue
            // 
            this.colsConsCodePartValue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsConsCodePartValue.MaxLength = 20;
            this.colsConsCodePartValue.Name = "colsConsCodePartValue";
            this.colsConsCodePartValue.NamedProperties.Put("EnumerateMethod", "");
            this.colsConsCodePartValue.NamedProperties.Put("FieldFlags", "294");
            this.colsConsCodePartValue.NamedProperties.Put("LovReference", "ACCOUNTING_CODE_PART_VALUE_LOV(CONS_COMPANY,CONS_CODE_PART)");
            this.colsConsCodePartValue.NamedProperties.Put("ResizeableChildObject", "");
            this.colsConsCodePartValue.NamedProperties.Put("SqlColumn", "CONS_CODE_PART_VALUE");
            this.colsConsCodePartValue.NamedProperties.Put("ValidateMethod", "");
            this.colsConsCodePartValue.Position = 14;
            resources.ApplyResources(this.colsConsCodePartValue, "colsConsCodePartValue");
            this.colsConsCodePartValue.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsConsCodePartValue_WindowActions);
            // 
            // colsConsCodePartValDesc
            // 
            resources.ApplyResources(this.colsConsCodePartValDesc, "colsConsCodePartValDesc");
            this.colsConsCodePartValDesc.Name = "colsConsCodePartValDesc";
            this.colsConsCodePartValDesc.NamedProperties.Put("EnumerateMethod", "");
            this.colsConsCodePartValDesc.NamedProperties.Put("FieldFlags", "288");
            this.colsConsCodePartValDesc.NamedProperties.Put("LovReference", "");
            this.colsConsCodePartValDesc.NamedProperties.Put("ParentName", "colsConsCodePartValue");
            this.colsConsCodePartValDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.colsConsCodePartValDesc.NamedProperties.Put("SqlColumn", "Accounting_Code_Part_Value_API.Get_Description(CONS_COMPANY,CONS_CODE_PART,CONS_C" +
        "ODE_PART_VALUE)");
            this.colsConsCodePartValDesc.NamedProperties.Put("ValidateMethod", "");
            this.colsConsCodePartValDesc.Position = 15;
            // 
            // colCodePart
            // 
            resources.ApplyResources(this.colCodePart, "colCodePart");
            this.colCodePart.Name = "colCodePart";
            this.colCodePart.NamedProperties.Put("EnumerateMethod", "");
            this.colCodePart.NamedProperties.Put("FieldFlags", "768");
            this.colCodePart.NamedProperties.Put("LovReference", "");
            this.colCodePart.NamedProperties.Put("ResizeableChildObject", "");
            this.colCodePart.NamedProperties.Put("SqlColumn", "CODE_PART");
            this.colCodePart.NamedProperties.Put("ValidateMethod", "");
            this.colCodePart.Position = 16;
            // 
            // menuTbwMethods
            // 
            this.menuTbwMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_Code,
            this.menuSeparator1,
            this.menuItem__Translation,
            this.menuItem__Code,
            this.menuItem__Notes,
            this.menuSeparator2,
            this.menuItem_Change});
            this.menuTbwMethods.Name = "menuTbwMethods";
            resources.ApplyResources(this.menuTbwMethods, "menuTbwMethods");
            // 
            // menuItem_Code
            // 
            this.menuItem_Code.Command = this.menuTbwMethods_menuCode__String_Completion___;
            this.menuItem_Code.Name = "menuItem_Code";
            resources.ApplyResources(this.menuItem_Code, "menuItem_Code");
            this.menuItem_Code.Text = "Code &String Completion...";
            // 
            // menuSeparator1
            // 
            this.menuSeparator1.Name = "menuSeparator1";
            resources.ApplyResources(this.menuSeparator1, "menuSeparator1");
            // 
            // menuItem__Translation
            // 
            this.menuItem__Translation.Command = this.menuTbwMethods_menu_Translation___;
            this.menuItem__Translation.Name = "menuItem__Translation";
            resources.ApplyResources(this.menuItem__Translation, "menuItem__Translation");
            this.menuItem__Translation.Text = "&Translation...";
            // 
            // menuItem__Code
            // 
            this.menuItem__Code.Command = this.menuTbwMethods_menu_Code_Part_Attribute_Connection_;
            this.menuItem__Code.Name = "menuItem__Code";
            resources.ApplyResources(this.menuItem__Code, "menuItem__Code");
            this.menuItem__Code.Text = "&Code Part Attribute Connection...";
            // 
            // menuItem__Notes
            // 
            this.menuItem__Notes.Command = this.menuTbwMethods_menu_Notes___;
            this.menuItem__Notes.Name = "menuItem__Notes";
            resources.ApplyResources(this.menuItem__Notes, "menuItem__Notes");
            this.menuItem__Notes.Text = "&Notes...";
            // 
            // menuSeparator2
            // 
            this.menuSeparator2.Name = "menuSeparator2";
            resources.ApplyResources(this.menuSeparator2, "menuSeparator2");
            // 
            // menuItem_Change
            // 
            this.menuItem_Change.Command = this.menuTbwMethods_menuChange_Company___;
            this.menuItem_Change.Name = "menuItem_Change";
            resources.ApplyResources(this.menuItem_Change, "menuItem_Change");
            this.menuItem_Change.Text = "Change Company...";
            // 
            // tbwCodeG
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colsCompany);
            this.Controls.Add(this.colsCodeG);
            this.Controls.Add(this.colsDescription);
            this.Controls.Add(this.coldValidFrom);
            this.Controls.Add(this.coldValidUntil);
            this.Controls.Add(this.colsCBCodeStr);
            this.Controls.Add(this.colsCBText);
            this.Controls.Add(this.colText);
            this.Controls.Add(this.colsCBAttribute);
            this.Controls.Add(this.colsConsCompany);
            this.Controls.Add(this.colsConsCodePart);
            this.Controls.Add(this.colsConsCodePartValue);
            this.Controls.Add(this.colsConsCodePartValDesc);
            this.Controls.Add(this.colCodePart);
            this.Name = "tbwCodeG";
            this.NamedProperties.Put("DefaultOrderBy", "SORT_VALUE");
            this.NamedProperties.Put("DefaultWhere", "COMPANY = :global.company");
            this.NamedProperties.Put("LogicalUnit", "CodeG");
            this.NamedProperties.Put("PackageName", "CODE_G_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "449");
            this.NamedProperties.Put("ViewName", "CODE_G");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tbwCodeG_WindowActions);
            this.Controls.SetChildIndex(this.colCodePart, 0);
            this.Controls.SetChildIndex(this.colsConsCodePartValDesc, 0);
            this.Controls.SetChildIndex(this.colsConsCodePartValue, 0);
            this.Controls.SetChildIndex(this.colsConsCodePart, 0);
            this.Controls.SetChildIndex(this.colsConsCompany, 0);
            this.Controls.SetChildIndex(this.colsCBAttribute, 0);
            this.Controls.SetChildIndex(this.colText, 0);
            this.Controls.SetChildIndex(this.colsCBText, 0);
            this.Controls.SetChildIndex(this.colsCBCodeStr, 0);
            this.Controls.SetChildIndex(this.coldValidUntil, 0);
            this.Controls.SetChildIndex(this.coldValidFrom, 0);
            this.Controls.SetChildIndex(this.colsDescription, 0);
            this.Controls.SetChildIndex(this.colsCodeG, 0);
            this.Controls.SetChildIndex(this.colsCompany, 0);
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

        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menuCode__String_Completion___;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menu_Translation___;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menu_Code_Part_Attribute_Connection_;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menu_Notes___;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menuChange_Company___;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTbwMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Code;
        protected Fnd.Windows.Forms.FndToolStripSeparator menuSeparator1;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Translation;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Code;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Notes;
        protected Fnd.Windows.Forms.FndToolStripSeparator menuSeparator2;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change;
	}
}
