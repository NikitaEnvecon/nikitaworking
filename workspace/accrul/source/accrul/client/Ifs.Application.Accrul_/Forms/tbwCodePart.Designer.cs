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
	
	public partial class tbwCodePart
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		// Bug 65271,Begin.Changed the F1 prop. Made colCompany parent key and colCodePart a key.
		public cColumn colCompany;
		public cColumn colCodePart;
		// Bug 65271,End.
		public cColumn colCodeName;
		public cLookupColumn colCodeUsed;
		public cLookupColumn colCodePartFunction;
		public cLookupColumn colLogicalCodePart;
		public cColumn colMaxNumberOfChar;
		public cColumn colDescription;
		public cColumn colConsCompany;
		public cColumn colParentCodePart;
		public cColumn colParentCodePartDesc;
		public cColumn colViewName;
		public cColumn colPackageName;
		// MAKRLK, Twin Peaks,Changes for Project Cost Element Setup ,Start
		public cCheckBoxColumn colBaseForPFE;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwCodePart));
            this.menuOperations_menu_Translation___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuOperations_menuChange__Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_menuSet_as_Base_for_Project_Cost_Rev = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_menu_Translation___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_menuChange__Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.colCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colCodePart = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colCodeName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colCodeUsed = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.colCodePartFunction = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.colLogicalCodePart = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.colMaxNumberOfChar = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colConsCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colParentCodePart = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colParentCodePartDesc = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colViewName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colPackageName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colBaseForPFE = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.menuTbwMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_Set = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuSeparator1 = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.menuItem__Translation = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuSeparator2 = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.menuItem_Change = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuOperations = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem__Translation_1 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuSeparator3 = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.menuItem_Change_1 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuTbwMethods.SuspendLayout();
            this.menuOperations.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuTbwMethods_menuSet_as_Base_for_Project_Cost_Rev);
            this.commandManager.Commands.Add(this.menuTbwMethods_menu_Translation___);
            this.commandManager.Commands.Add(this.menuTbwMethods_menuChange__Company___);
            this.commandManager.Commands.Add(this.menuOperations_menu_Translation___);
            this.commandManager.Commands.Add(this.menuOperations_menuChange__Company___);
            this.commandManager.ContextMenus.Add(this.menuTbwMethods);
            this.commandManager.ContextMenus.Add(this.menuOperations);
            // 
            // menuOperations_menu_Translation___
            // 
            resources.ApplyResources(this.menuOperations_menu_Translation___, "menuOperations_menu_Translation___");
            this.menuOperations_menu_Translation___.Name = "menuOperations_menu_Translation___";
            this.menuOperations_menu_Translation___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Translation_1_Execute);
            this.menuOperations_menu_Translation___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Translation_1_Inquire);
            // 
            // menuOperations_menuChange__Company___
            // 
            resources.ApplyResources(this.menuOperations_menuChange__Company___, "menuOperations_menuChange__Company___");
            this.menuOperations_menuChange__Company___.Name = "menuOperations_menuChange__Company___";
            this.menuOperations_menuChange__Company___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Change_1_Execute);
            this.menuOperations_menuChange__Company___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Change_1_Inquire);
            // 
            // menuTbwMethods_menuSet_as_Base_for_Project_Cost_Rev
            // 
            resources.ApplyResources(this.menuTbwMethods_menuSet_as_Base_for_Project_Cost_Rev, "menuTbwMethods_menuSet_as_Base_for_Project_Cost_Rev");
            this.menuTbwMethods_menuSet_as_Base_for_Project_Cost_Rev.Name = "menuTbwMethods_menuSet_as_Base_for_Project_Cost_Rev";
            this.menuTbwMethods_menuSet_as_Base_for_Project_Cost_Rev.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Set_Execute);
            this.menuTbwMethods_menuSet_as_Base_for_Project_Cost_Rev.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Set_Inquire);
            // 
            // menuTbwMethods_menu_Translation___
            // 
            resources.ApplyResources(this.menuTbwMethods_menu_Translation___, "menuTbwMethods_menu_Translation___");
            this.menuTbwMethods_menu_Translation___.Name = "menuTbwMethods_menu_Translation___";
            this.menuTbwMethods_menu_Translation___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Translation_Execute);
            this.menuTbwMethods_menu_Translation___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Translation_Inquire);
            // 
            // menuTbwMethods_menuChange__Company___
            // 
            resources.ApplyResources(this.menuTbwMethods_menuChange__Company___, "menuTbwMethods_menuChange__Company___");
            this.menuTbwMethods_menuChange__Company___.Name = "menuTbwMethods_menuChange__Company___";
            this.menuTbwMethods_menuChange__Company___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Change_Execute);
            this.menuTbwMethods_menuChange__Company___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Change_Inquire);
            // 
            // colCompany
            // 
            resources.ApplyResources(this.colCompany, "colCompany");
            this.colCompany.Name = "colCompany";
            this.colCompany.NamedProperties.Put("EnumerateMethod", "");
            this.colCompany.NamedProperties.Put("FieldFlags", "64");
            this.colCompany.NamedProperties.Put("LovReference", "");
            this.colCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.colCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.colCompany.NamedProperties.Put("ValidateMethod", "");
            this.colCompany.Position = 3;
            // 
            // colCodePart
            // 
            this.colCodePart.MaxLength = 1;
            this.colCodePart.Name = "colCodePart";
            this.colCodePart.NamedProperties.Put("EnumerateMethod", "");
            this.colCodePart.NamedProperties.Put("FieldFlags", "160");
            this.colCodePart.NamedProperties.Put("LovReference", "");
            this.colCodePart.NamedProperties.Put("ResizeableChildObject", "");
            this.colCodePart.NamedProperties.Put("SqlColumn", "CODE_PART");
            this.colCodePart.NamedProperties.Put("ValidateMethod", "");
            this.colCodePart.Position = 4;
            this.colCodePart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            resources.ApplyResources(this.colCodePart, "colCodePart");
            // 
            // colCodeName
            // 
            this.colCodeName.MaxLength = 10;
            this.colCodeName.Name = "colCodeName";
            this.colCodeName.NamedProperties.Put("EnumerateMethod", "");
            this.colCodeName.NamedProperties.Put("FieldFlags", "293");
            this.colCodeName.NamedProperties.Put("LovReference", "");
            this.colCodeName.NamedProperties.Put("ResizeableChildObject", "");
            this.colCodeName.NamedProperties.Put("SqlColumn", "CODE_NAME");
            this.colCodeName.NamedProperties.Put("ValidateMethod", "");
            this.colCodeName.Position = 5;
            resources.ApplyResources(this.colCodeName, "colCodeName");
            // 
            // colCodeUsed
            // 
            this.colCodeUsed.MaxLength = 20;
            this.colCodeUsed.Name = "colCodeUsed";
            this.colCodeUsed.NamedProperties.Put("EnumerateMethod", "ACCOUNTING_CODE_PART_Y_N_API.Enumerate");
            this.colCodeUsed.NamedProperties.Put("FieldFlags", "295");
            this.colCodeUsed.NamedProperties.Put("LovReference", "");
            this.colCodeUsed.NamedProperties.Put("ResizeableChildObject", "");
            this.colCodeUsed.NamedProperties.Put("SqlColumn", "CODE_PART_USED");
            this.colCodeUsed.NamedProperties.Put("ValidateMethod", "");
            this.colCodeUsed.Position = 6;
            this.colCodeUsed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            resources.ApplyResources(this.colCodeUsed, "colCodeUsed");
            this.colCodeUsed.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colCodeUsed_WindowActions);
            // 
            // colCodePartFunction
            // 
            this.colCodePartFunction.MaxLength = 20;
            this.colCodePartFunction.Name = "colCodePartFunction";
            this.colCodePartFunction.NamedProperties.Put("EnumerateMethod", "ACCOUNTING_CODE_PART_FU_API.ENUMERATE");
            this.colCodePartFunction.NamedProperties.Put("FieldFlags", "295");
            this.colCodePartFunction.NamedProperties.Put("LovReference", "");
            this.colCodePartFunction.NamedProperties.Put("ResizeableChildObject", "");
            this.colCodePartFunction.NamedProperties.Put("SqlColumn", "CODE_PART_FUNCTION");
            this.colCodePartFunction.NamedProperties.Put("ValidateMethod", "");
            this.colCodePartFunction.Position = 7;
            resources.ApplyResources(this.colCodePartFunction, "colCodePartFunction");
            // 
            // colLogicalCodePart
            // 
            this.colLogicalCodePart.MaxLength = 200;
            this.colLogicalCodePart.Name = "colLogicalCodePart";
            this.colLogicalCodePart.NamedProperties.Put("EnumerateMethod", "LOGICAL_CODE_PART_API.Enumerate");
            this.colLogicalCodePart.NamedProperties.Put("FieldFlags", "295");
            this.colLogicalCodePart.NamedProperties.Put("LovReference", "");
            this.colLogicalCodePart.NamedProperties.Put("ResizeableChildObject", "");
            this.colLogicalCodePart.NamedProperties.Put("SqlColumn", "LOGICAL_CODE_PART");
            this.colLogicalCodePart.NamedProperties.Put("ValidateMethod", "");
            this.colLogicalCodePart.Position = 8;
            resources.ApplyResources(this.colLogicalCodePart, "colLogicalCodePart");
            this.colLogicalCodePart.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colLogicalCodePart_WindowActions);
            // 
            // colMaxNumberOfChar
            // 
            this.colMaxNumberOfChar.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colMaxNumberOfChar.MaxLength = 2;
            this.colMaxNumberOfChar.Name = "colMaxNumberOfChar";
            this.colMaxNumberOfChar.NamedProperties.Put("EnumerateMethod", "");
            this.colMaxNumberOfChar.NamedProperties.Put("FieldFlags", "261");
            this.colMaxNumberOfChar.NamedProperties.Put("LovReference", "");
            this.colMaxNumberOfChar.NamedProperties.Put("SqlColumn", "MAX_NUMBER_OF_CHAR");
            this.colMaxNumberOfChar.NamedProperties.Put("ValidateMethod", "");
            this.colMaxNumberOfChar.Position = 9;
            this.colMaxNumberOfChar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            resources.ApplyResources(this.colMaxNumberOfChar, "colMaxNumberOfChar");
            this.colMaxNumberOfChar.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colMaxNumberOfChar_WindowActions);
            // 
            // colDescription
            // 
            this.colDescription.MaxLength = 35;
            this.colDescription.Name = "colDescription";
            this.colDescription.NamedProperties.Put("EnumerateMethod", "");
            this.colDescription.NamedProperties.Put("FieldFlags", "278");
            this.colDescription.NamedProperties.Put("LovReference", "");
            this.colDescription.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            this.colDescription.NamedProperties.Put("ValidateMethod", "");
            this.colDescription.Position = 10;
            resources.ApplyResources(this.colDescription, "colDescription");
            // 
            // colConsCompany
            // 
            this.colConsCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.colConsCompany, "colConsCompany");
            this.colConsCompany.MaxLength = 20;
            this.colConsCompany.Name = "colConsCompany";
            this.colConsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.colConsCompany.NamedProperties.Put("LovReference", "");
            this.colConsCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.colConsCompany.NamedProperties.Put("SqlColumn", "CONS_COMPANY");
            this.colConsCompany.NamedProperties.Put("ValidateMethod", "");
            this.colConsCompany.Position = 11;
            // 
            // colParentCodePart
            // 
            this.colParentCodePart.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colParentCodePart.MaxLength = 1;
            this.colParentCodePart.Name = "colParentCodePart";
            this.colParentCodePart.NamedProperties.Put("EnumerateMethod", "");
            this.colParentCodePart.NamedProperties.Put("FieldFlags", "294");
            this.colParentCodePart.NamedProperties.Put("LovReference", "CODE_PARTS_FOR_CONSOLIDATION(CONS_COMPANY)");
            this.colParentCodePart.NamedProperties.Put("ResizeableChildObject", "");
            this.colParentCodePart.NamedProperties.Put("SqlColumn", "PARENT_CODE_PART");
            this.colParentCodePart.NamedProperties.Put("ValidateMethod", "");
            this.colParentCodePart.Position = 12;
            resources.ApplyResources(this.colParentCodePart, "colParentCodePart");
            this.colParentCodePart.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colParentCodePart_WindowActions);
            // 
            // colParentCodePartDesc
            // 
            resources.ApplyResources(this.colParentCodePartDesc, "colParentCodePartDesc");
            this.colParentCodePartDesc.MaxLength = 35;
            this.colParentCodePartDesc.Name = "colParentCodePartDesc";
            this.colParentCodePartDesc.NamedProperties.Put("EnumerateMethod", "");
            this.colParentCodePartDesc.NamedProperties.Put("FieldFlags", "288");
            this.colParentCodePartDesc.NamedProperties.Put("LovReference", "");
            this.colParentCodePartDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.colParentCodePartDesc.NamedProperties.Put("SqlColumn", "Accounting_Code_Parts_API.Get_Name(CONS_COMPANY,PARENT_CODE_PART)");
            this.colParentCodePartDesc.NamedProperties.Put("ValidateMethod", "");
            this.colParentCodePartDesc.Position = 13;
            // 
            // colViewName
            // 
            resources.ApplyResources(this.colViewName, "colViewName");
            this.colViewName.MaxLength = 10;
            this.colViewName.Name = "colViewName";
            this.colViewName.NamedProperties.Put("EnumerateMethod", "");
            this.colViewName.NamedProperties.Put("FieldFlags", "259");
            this.colViewName.NamedProperties.Put("LovReference", "");
            this.colViewName.NamedProperties.Put("ResizeableChildObject", "");
            this.colViewName.NamedProperties.Put("SqlColumn", "VIEW_NAME");
            this.colViewName.NamedProperties.Put("ValidateMethod", "");
            this.colViewName.Position = 14;
            this.colViewName.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colViewName_WindowActions);
            // 
            // colPackageName
            // 
            resources.ApplyResources(this.colPackageName, "colPackageName");
            this.colPackageName.MaxLength = 15;
            this.colPackageName.Name = "colPackageName";
            this.colPackageName.NamedProperties.Put("EnumerateMethod", "");
            this.colPackageName.NamedProperties.Put("FieldFlags", "259");
            this.colPackageName.NamedProperties.Put("LovReference", "");
            this.colPackageName.NamedProperties.Put("ResizeableChildObject", "");
            this.colPackageName.NamedProperties.Put("SqlColumn", "PKG_NAME");
            this.colPackageName.NamedProperties.Put("ValidateMethod", "");
            this.colPackageName.Position = 15;
            this.colPackageName.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colPackageName_WindowActions);
            // 
            // colBaseForPFE
            // 
            this.colBaseForPFE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colBaseForPFE.MaxLength = 5;
            this.colBaseForPFE.Name = "colBaseForPFE";
            this.colBaseForPFE.NamedProperties.Put("EnumerateMethod", "");
            this.colBaseForPFE.NamedProperties.Put("FieldFlags", "290");
            this.colBaseForPFE.NamedProperties.Put("LovReference", "");
            this.colBaseForPFE.NamedProperties.Put("ResizeableChildObject", "");
            this.colBaseForPFE.NamedProperties.Put("SqlColumn", "BASE_FOR_PFE");
            this.colBaseForPFE.NamedProperties.Put("ValidateMethod", "");
            this.colBaseForPFE.Position = 16;
            resources.ApplyResources(this.colBaseForPFE, "colBaseForPFE");
            // 
            // menuTbwMethods
            // 
            this.menuTbwMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_Set,
            this.menuSeparator1,
            this.menuItem__Translation,
            this.menuSeparator2,
            this.menuItem_Change});
            this.menuTbwMethods.Name = "menuTbwMethods";
            resources.ApplyResources(this.menuTbwMethods, "menuTbwMethods");
            // 
            // menuItem_Set
            // 
            this.menuItem_Set.Command = this.menuTbwMethods_menuSet_as_Base_for_Project_Cost_Rev;
            this.menuItem_Set.Name = "menuItem_Set";
            resources.ApplyResources(this.menuItem_Set, "menuItem_Set");
            this.menuItem_Set.Text = "Set as Base for Project Cost/Revenue Element";
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
            // menuSeparator2
            // 
            this.menuSeparator2.Name = "menuSeparator2";
            resources.ApplyResources(this.menuSeparator2, "menuSeparator2");
            // 
            // menuItem_Change
            // 
            this.menuItem_Change.Command = this.menuTbwMethods_menuChange__Company___;
            this.menuItem_Change.Name = "menuItem_Change";
            resources.ApplyResources(this.menuItem_Change, "menuItem_Change");
            this.menuItem_Change.Text = "Change &Company...";
            // 
            // menuOperations
            // 
            this.menuOperations.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem__Translation_1,
            this.menuSeparator3,
            this.menuItem_Change_1});
            this.menuOperations.Name = "menuOperations";
            resources.ApplyResources(this.menuOperations, "menuOperations");
            // 
            // menuItem__Translation_1
            // 
            this.menuItem__Translation_1.Command = this.menuOperations_menu_Translation___;
            this.menuItem__Translation_1.Name = "menuItem__Translation_1";
            resources.ApplyResources(this.menuItem__Translation_1, "menuItem__Translation_1");
            this.menuItem__Translation_1.Text = "&Translation...";
            // 
            // menuSeparator3
            // 
            this.menuSeparator3.Name = "menuSeparator3";
            resources.ApplyResources(this.menuSeparator3, "menuSeparator3");
            // 
            // menuItem_Change_1
            // 
            this.menuItem_Change_1.Command = this.menuOperations_menuChange__Company___;
            this.menuItem_Change_1.Name = "menuItem_Change_1";
            resources.ApplyResources(this.menuItem_Change_1, "menuItem_Change_1");
            this.menuItem_Change_1.Text = "Change &Company...";
            // 
            // tbwCodePart
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colCompany);
            this.Controls.Add(this.colCodePart);
            this.Controls.Add(this.colCodeName);
            this.Controls.Add(this.colCodeUsed);
            this.Controls.Add(this.colCodePartFunction);
            this.Controls.Add(this.colLogicalCodePart);
            this.Controls.Add(this.colMaxNumberOfChar);
            this.Controls.Add(this.colDescription);
            this.Controls.Add(this.colConsCompany);
            this.Controls.Add(this.colParentCodePart);
            this.Controls.Add(this.colParentCodePartDesc);
            this.Controls.Add(this.colViewName);
            this.Controls.Add(this.colPackageName);
            this.Controls.Add(this.colBaseForPFE);
            this.Name = "tbwCodePart";
            this.NamedProperties.Put("DefaultOrderBy", "CODE_PART");
            this.NamedProperties.Put("DefaultWhere", "company = :global.company");
            this.NamedProperties.Put("LogicalUnit", "AccountingCodeParts");
            this.NamedProperties.Put("PackageName", "ACCOUNTING_CODE_PARTS_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "0");
            this.NamedProperties.Put("SourceFlags", "129");
            this.NamedProperties.Put("ViewName", "ACCOUNTING_CODE_PARTS");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tbwCodePart_WindowActions);
            this.Controls.SetChildIndex(this.colBaseForPFE, 0);
            this.Controls.SetChildIndex(this.colPackageName, 0);
            this.Controls.SetChildIndex(this.colViewName, 0);
            this.Controls.SetChildIndex(this.colParentCodePartDesc, 0);
            this.Controls.SetChildIndex(this.colParentCodePart, 0);
            this.Controls.SetChildIndex(this.colConsCompany, 0);
            this.Controls.SetChildIndex(this.colDescription, 0);
            this.Controls.SetChildIndex(this.colMaxNumberOfChar, 0);
            this.Controls.SetChildIndex(this.colLogicalCodePart, 0);
            this.Controls.SetChildIndex(this.colCodePartFunction, 0);
            this.Controls.SetChildIndex(this.colCodeUsed, 0);
            this.Controls.SetChildIndex(this.colCodeName, 0);
            this.Controls.SetChildIndex(this.colCodePart, 0);
            this.Controls.SetChildIndex(this.colCompany, 0);
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

        public Fnd.Windows.Forms.FndCommand menuOperations_menu_Translation___;
        public Fnd.Windows.Forms.FndCommand menuOperations_menuChange__Company___;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menuSet_as_Base_for_Project_Cost_Rev;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menu_Translation___;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menuChange__Company___;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTbwMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Set;
        protected Fnd.Windows.Forms.FndToolStripSeparator menuSeparator1;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Translation;
        protected Fnd.Windows.Forms.FndToolStripSeparator menuSeparator2;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuOperations;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Translation_1;
        protected Fnd.Windows.Forms.FndToolStripSeparator menuSeparator3;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change_1;
	}
}
