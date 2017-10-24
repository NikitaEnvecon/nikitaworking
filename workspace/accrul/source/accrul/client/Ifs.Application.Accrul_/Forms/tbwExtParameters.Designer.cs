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
	
	public partial class tbwExtParameters
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cColumn colCompany;
		public cColumn colsLoadType;
		public cColumn colVoucherType;
		public cCheckBoxColumn colsDefType;
		public cLookupColumn colExtVoucherNoAlloc;
		public cLookupColumn colExtVoucherDiff;
		public cLookupColumn colExtGroupItem;
		public cLookupColumn colExtVoucherDate;
		public cCheckBoxColumn colExtAlterTrans;
		public cCheckBoxColumn colCorrection;
		public cLookupColumn colsValidateCodeString;
		// Bug 92374 Begin
		public cCheckBoxColumn colsUseCodestrCompl;
		// Bug 92374 End
		public cLookupColumn colAutoTaxCalc;
		public cCheckBoxColumn colsCheckWhenLoaded;
		public cCheckBoxColumn colsCreateWhenChecked;
		public cCheckBoxColumn colsAllowPartialCreate;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwExtParameters));
            this.menuTbwMethods_menuChange__Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuOperations_menuChange__Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.colCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsLoadType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colVoucherType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsDefType = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.colExtVoucherNoAlloc = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.colExtVoucherDiff = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.colExtGroupItem = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.colExtVoucherDate = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.colExtAlterTrans = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.colCorrection = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.colsValidateCodeString = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.colsUseCodestrCompl = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.colAutoTaxCalc = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.colsCheckWhenLoaded = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.colsCreateWhenChecked = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.colsAllowPartialCreate = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.menuOperations = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_Change = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuTbwMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_Change_1 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuOperations.SuspendLayout();
            this.menuTbwMethods.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuOperations_menuChange__Company___);
            this.commandManager.Commands.Add(this.menuTbwMethods_menuChange__Company___);
            this.commandManager.ContextMenus.Add(this.menuOperations);
            this.commandManager.ContextMenus.Add(this.menuTbwMethods);
            // 
            // menuTbwMethods_menuChange__Company___
            // 
            resources.ApplyResources(this.menuTbwMethods_menuChange__Company___, "menuTbwMethods_menuChange__Company___");
            this.menuTbwMethods_menuChange__Company___.Name = "menuTbwMethods_menuChange__Company___";
            this.menuTbwMethods_menuChange__Company___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Change_1_Execute);
            this.menuTbwMethods_menuChange__Company___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Change_1_Inquire);
            // 
            // menuOperations_menuChange__Company___
            // 
            resources.ApplyResources(this.menuOperations_menuChange__Company___, "menuOperations_menuChange__Company___");
            this.menuOperations_menuChange__Company___.Name = "menuOperations_menuChange__Company___";
            this.menuOperations_menuChange__Company___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Change_Execute);
            this.menuOperations_menuChange__Company___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Change_Inquire);
            // 
            // colCompany
            // 
            this.colCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.colCompany, "colCompany");
            this.colCompany.MaxLength = 20;
            this.colCompany.Name = "colCompany";
            this.colCompany.NamedProperties.Put("EnumerateMethod", "");
            this.colCompany.NamedProperties.Put("FieldFlags", "67");
            this.colCompany.NamedProperties.Put("LovReference", "COMPANY_FINANCE");
            this.colCompany.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.colCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.colCompany.NamedProperties.Put("ValidateMethod", "");
            this.colCompany.Position = 3;
            // 
            // colsLoadType
            // 
            this.colsLoadType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsLoadType.MaxLength = 20;
            this.colsLoadType.Name = "colsLoadType";
            this.colsLoadType.NamedProperties.Put("EnumerateMethod", "");
            this.colsLoadType.NamedProperties.Put("FieldFlags", "163");
            this.colsLoadType.NamedProperties.Put("LovReference", "");
            this.colsLoadType.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsLoadType.NamedProperties.Put("ResizeableChildObject", "");
            this.colsLoadType.NamedProperties.Put("SqlColumn", "LOAD_TYPE");
            this.colsLoadType.NamedProperties.Put("ValidateMethod", "");
            this.colsLoadType.Position = 4;
            resources.ApplyResources(this.colsLoadType, "colsLoadType");
            // 
            // colVoucherType
            // 
            this.colVoucherType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colVoucherType.MaxLength = 3;
            this.colVoucherType.Name = "colVoucherType";
            this.colVoucherType.NamedProperties.Put("EnumerateMethod", "");
            this.colVoucherType.NamedProperties.Put("FieldFlags", "295");
            this.colVoucherType.NamedProperties.Put("LovReference", "VOUCHER_TYPE(COMPANY)");
            this.colVoucherType.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colVoucherType.NamedProperties.Put("ResizeableChildObject", "");
            this.colVoucherType.NamedProperties.Put("SqlColumn", "VOUCHER_TYPE");
            this.colVoucherType.NamedProperties.Put("ValidateMethod", "");
            this.colVoucherType.Position = 5;
            resources.ApplyResources(this.colVoucherType, "colVoucherType");
            this.colVoucherType.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colVoucherType_WindowActions);
            // 
            // colsDefType
            // 
            this.colsDefType.MaxLength = 5;
            this.colsDefType.Name = "colsDefType";
            this.colsDefType.NamedProperties.Put("EnumerateMethod", "");
            this.colsDefType.NamedProperties.Put("FieldFlags", "295");
            this.colsDefType.NamedProperties.Put("LovReference", "");
            this.colsDefType.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsDefType.NamedProperties.Put("ResizeableChildObject", "");
            this.colsDefType.NamedProperties.Put("SqlColumn", "DEF_TYPE");
            this.colsDefType.NamedProperties.Put("ValidateMethod", "");
            this.colsDefType.Position = 6;
            resources.ApplyResources(this.colsDefType, "colsDefType");
            this.colsDefType.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsDefType_WindowActions);
            // 
            // colExtVoucherNoAlloc
            // 
            this.colExtVoucherNoAlloc.MaxLength = 20;
            this.colExtVoucherNoAlloc.Name = "colExtVoucherNoAlloc";
            this.colExtVoucherNoAlloc.NamedProperties.Put("EnumerateMethod", "EXT_VOUCHER_NO_ALLOC_API.Enumerate");
            this.colExtVoucherNoAlloc.NamedProperties.Put("FieldFlags", "295");
            this.colExtVoucherNoAlloc.NamedProperties.Put("LovReference", "");
            this.colExtVoucherNoAlloc.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colExtVoucherNoAlloc.NamedProperties.Put("SqlColumn", "EXT_VOUCHER_NO_ALLOC");
            this.colExtVoucherNoAlloc.NamedProperties.Put("ValidateMethod", "");
            this.colExtVoucherNoAlloc.Position = 7;
            resources.ApplyResources(this.colExtVoucherNoAlloc, "colExtVoucherNoAlloc");
            // 
            // colExtVoucherDiff
            // 
            this.colExtVoucherDiff.MaxLength = 20;
            this.colExtVoucherDiff.Name = "colExtVoucherDiff";
            this.colExtVoucherDiff.NamedProperties.Put("EnumerateMethod", "EXT_VOUCHER_DIFF_API.Enumerate");
            this.colExtVoucherDiff.NamedProperties.Put("FieldFlags", "295");
            this.colExtVoucherDiff.NamedProperties.Put("LovReference", "");
            this.colExtVoucherDiff.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colExtVoucherDiff.NamedProperties.Put("SqlColumn", "EXT_VOUCHER_DIFF");
            this.colExtVoucherDiff.NamedProperties.Put("ValidateMethod", "");
            this.colExtVoucherDiff.Position = 8;
            resources.ApplyResources(this.colExtVoucherDiff, "colExtVoucherDiff");
            // 
            // colExtGroupItem
            // 
            this.colExtGroupItem.MaxLength = 20;
            this.colExtGroupItem.Name = "colExtGroupItem";
            this.colExtGroupItem.NamedProperties.Put("EnumerateMethod", "EXT_GROUP_ITEM_API.Enumerate");
            this.colExtGroupItem.NamedProperties.Put("FieldFlags", "295");
            this.colExtGroupItem.NamedProperties.Put("LovReference", "");
            this.colExtGroupItem.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colExtGroupItem.NamedProperties.Put("SqlColumn", "EXT_GROUP_ITEM");
            this.colExtGroupItem.NamedProperties.Put("ValidateMethod", "");
            this.colExtGroupItem.Position = 9;
            resources.ApplyResources(this.colExtGroupItem, "colExtGroupItem");
            // 
            // colExtVoucherDate
            // 
            this.colExtVoucherDate.MaxLength = 20;
            this.colExtVoucherDate.Name = "colExtVoucherDate";
            this.colExtVoucherDate.NamedProperties.Put("EnumerateMethod", "EXT_VOUCHER_DATE_API.Enumerate");
            this.colExtVoucherDate.NamedProperties.Put("FieldFlags", "295");
            this.colExtVoucherDate.NamedProperties.Put("LovReference", "");
            this.colExtVoucherDate.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colExtVoucherDate.NamedProperties.Put("SqlColumn", "EXT_VOUCHER_DATE");
            this.colExtVoucherDate.NamedProperties.Put("ValidateMethod", "");
            this.colExtVoucherDate.Position = 10;
            resources.ApplyResources(this.colExtVoucherDate, "colExtVoucherDate");
            // 
            // colExtAlterTrans
            // 
            this.colExtAlterTrans.MaxLength = 5;
            this.colExtAlterTrans.Name = "colExtAlterTrans";
            this.colExtAlterTrans.NamedProperties.Put("EnumerateMethod", "");
            this.colExtAlterTrans.NamedProperties.Put("FieldFlags", "295");
            this.colExtAlterTrans.NamedProperties.Put("LovReference", "");
            this.colExtAlterTrans.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colExtAlterTrans.NamedProperties.Put("ResizeableChildObject", "");
            this.colExtAlterTrans.NamedProperties.Put("SqlColumn", "EXT_ALTER_TRANS");
            this.colExtAlterTrans.NamedProperties.Put("ValidateMethod", "");
            this.colExtAlterTrans.Position = 11;
            resources.ApplyResources(this.colExtAlterTrans, "colExtAlterTrans");
            // 
            // colCorrection
            // 
            this.colCorrection.MaxLength = 5;
            this.colCorrection.Name = "colCorrection";
            this.colCorrection.NamedProperties.Put("EnumerateMethod", "");
            this.colCorrection.NamedProperties.Put("FieldFlags", "294");
            this.colCorrection.NamedProperties.Put("LovReference", "");
            this.colCorrection.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colCorrection.NamedProperties.Put("ResizeableChildObject", "");
            this.colCorrection.NamedProperties.Put("SqlColumn", "CORRECTION");
            this.colCorrection.NamedProperties.Put("ValidateMethod", "");
            this.colCorrection.Position = 12;
            resources.ApplyResources(this.colCorrection, "colCorrection");
            // 
            // colsValidateCodeString
            // 
            this.colsValidateCodeString.MaxLength = 200;
            this.colsValidateCodeString.Name = "colsValidateCodeString";
            this.colsValidateCodeString.NamedProperties.Put("EnumerateMethod", "VALIDATE_CODE_STRING_API.Enumerate");
            this.colsValidateCodeString.NamedProperties.Put("FieldFlags", "295");
            this.colsValidateCodeString.NamedProperties.Put("LovReference", "");
            this.colsValidateCodeString.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsValidateCodeString.NamedProperties.Put("ResizeableChildObject", "");
            this.colsValidateCodeString.NamedProperties.Put("SqlColumn", "VALIDATE_CODE_STRING");
            this.colsValidateCodeString.NamedProperties.Put("ValidateMethod", "");
            this.colsValidateCodeString.Position = 13;
            resources.ApplyResources(this.colsValidateCodeString, "colsValidateCodeString");
            // 
            // colsUseCodestrCompl
            // 
            this.colsUseCodestrCompl.MaxLength = 5;
            this.colsUseCodestrCompl.Name = "colsUseCodestrCompl";
            this.colsUseCodestrCompl.NamedProperties.Put("EnumerateMethod", "");
            this.colsUseCodestrCompl.NamedProperties.Put("FieldFlags", "295");
            this.colsUseCodestrCompl.NamedProperties.Put("LovReference", "");
            this.colsUseCodestrCompl.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsUseCodestrCompl.NamedProperties.Put("ResizeableChildObject", "");
            this.colsUseCodestrCompl.NamedProperties.Put("SqlColumn", "USE_CODESTR_COMPL");
            this.colsUseCodestrCompl.NamedProperties.Put("ValidateMethod", "");
            this.colsUseCodestrCompl.Position = 14;
            resources.ApplyResources(this.colsUseCodestrCompl, "colsUseCodestrCompl");
            // 
            // colAutoTaxCalc
            // 
            this.colAutoTaxCalc.MaxLength = 20;
            this.colAutoTaxCalc.Name = "colAutoTaxCalc";
            this.colAutoTaxCalc.NamedProperties.Put("EnumerateMethod", "FINANCE_YES_NO_API.Enumerate");
            this.colAutoTaxCalc.NamedProperties.Put("FieldFlags", "295");
            this.colAutoTaxCalc.NamedProperties.Put("LovReference", "");
            this.colAutoTaxCalc.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colAutoTaxCalc.NamedProperties.Put("ResizeableChildObject", "");
            this.colAutoTaxCalc.NamedProperties.Put("SqlColumn", "AUTO_TAX_CALC");
            this.colAutoTaxCalc.NamedProperties.Put("ValidateMethod", "");
            this.colAutoTaxCalc.Position = 15;
            resources.ApplyResources(this.colAutoTaxCalc, "colAutoTaxCalc");
            // 
            // colsCheckWhenLoaded
            // 
            this.colsCheckWhenLoaded.MaxLength = 5;
            this.colsCheckWhenLoaded.Name = "colsCheckWhenLoaded";
            this.colsCheckWhenLoaded.NamedProperties.Put("EnumerateMethod", "");
            this.colsCheckWhenLoaded.NamedProperties.Put("FieldFlags", "295");
            this.colsCheckWhenLoaded.NamedProperties.Put("LovReference", "");
            this.colsCheckWhenLoaded.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsCheckWhenLoaded.NamedProperties.Put("ResizeableChildObject", "");
            this.colsCheckWhenLoaded.NamedProperties.Put("SqlColumn", "CHECK_WHEN_LOADED");
            this.colsCheckWhenLoaded.NamedProperties.Put("ValidateMethod", "");
            this.colsCheckWhenLoaded.Position = 16;
            resources.ApplyResources(this.colsCheckWhenLoaded, "colsCheckWhenLoaded");
            // 
            // colsCreateWhenChecked
            // 
            this.colsCreateWhenChecked.MaxLength = 5;
            this.colsCreateWhenChecked.Name = "colsCreateWhenChecked";
            this.colsCreateWhenChecked.NamedProperties.Put("EnumerateMethod", "");
            this.colsCreateWhenChecked.NamedProperties.Put("FieldFlags", "295");
            this.colsCreateWhenChecked.NamedProperties.Put("LovReference", "");
            this.colsCreateWhenChecked.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsCreateWhenChecked.NamedProperties.Put("ResizeableChildObject", "");
            this.colsCreateWhenChecked.NamedProperties.Put("SqlColumn", "CREATE_WHEN_CHECKED");
            this.colsCreateWhenChecked.NamedProperties.Put("ValidateMethod", "");
            this.colsCreateWhenChecked.Position = 17;
            resources.ApplyResources(this.colsCreateWhenChecked, "colsCreateWhenChecked");
            // 
            // colsAllowPartialCreate
            // 
            this.colsAllowPartialCreate.MaxLength = 5;
            this.colsAllowPartialCreate.Name = "colsAllowPartialCreate";
            this.colsAllowPartialCreate.NamedProperties.Put("EnumerateMethod", "");
            this.colsAllowPartialCreate.NamedProperties.Put("FieldFlags", "295");
            this.colsAllowPartialCreate.NamedProperties.Put("LovReference", "");
            this.colsAllowPartialCreate.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsAllowPartialCreate.NamedProperties.Put("ResizeableChildObject", "");
            this.colsAllowPartialCreate.NamedProperties.Put("SqlColumn", "ALLOW_PARTIAL_CREATE");
            this.colsAllowPartialCreate.NamedProperties.Put("ValidateMethod", "");
            this.colsAllowPartialCreate.Position = 18;
            resources.ApplyResources(this.colsAllowPartialCreate, "colsAllowPartialCreate");
            // 
            // menuOperations
            // 
            this.menuOperations.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_Change});
            this.menuOperations.Name = "menuOperations";
            resources.ApplyResources(this.menuOperations, "menuOperations");
            // 
            // menuItem_Change
            // 
            this.menuItem_Change.Command = this.menuOperations_menuChange__Company___;
            this.menuItem_Change.Name = "menuItem_Change";
            resources.ApplyResources(this.menuItem_Change, "menuItem_Change");
            this.menuItem_Change.Text = "Change &Company...";
            // 
            // menuTbwMethods
            // 
            this.menuTbwMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_Change_1});
            this.menuTbwMethods.Name = "menuTbwMethods";
            resources.ApplyResources(this.menuTbwMethods, "menuTbwMethods");
            // 
            // menuItem_Change_1
            // 
            this.menuItem_Change_1.Command = this.menuTbwMethods_menuChange__Company___;
            this.menuItem_Change_1.Name = "menuItem_Change_1";
            resources.ApplyResources(this.menuItem_Change_1, "menuItem_Change_1");
            this.menuItem_Change_1.Text = "Change &Company...";
            // 
            // tbwExtParameters
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colCompany);
            this.Controls.Add(this.colsLoadType);
            this.Controls.Add(this.colVoucherType);
            this.Controls.Add(this.colsDefType);
            this.Controls.Add(this.colExtVoucherNoAlloc);
            this.Controls.Add(this.colExtVoucherDiff);
            this.Controls.Add(this.colExtGroupItem);
            this.Controls.Add(this.colExtVoucherDate);
            this.Controls.Add(this.colExtAlterTrans);
            this.Controls.Add(this.colCorrection);
            this.Controls.Add(this.colsValidateCodeString);
            this.Controls.Add(this.colsUseCodestrCompl);
            this.Controls.Add(this.colAutoTaxCalc);
            this.Controls.Add(this.colsCheckWhenLoaded);
            this.Controls.Add(this.colsCreateWhenChecked);
            this.Controls.Add(this.colsAllowPartialCreate);
            this.Name = "tbwExtParameters";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "COMPANY= :global.company");
            this.NamedProperties.Put("LogicalUnit", "ExtParameters");
            this.NamedProperties.Put("PackageName", "EXT_PARAMETERS_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "449");
            this.NamedProperties.Put("ViewName", "EXT_PARAMETERS");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tbwExtParameters_WindowActions);
            this.Controls.SetChildIndex(this.colsAllowPartialCreate, 0);
            this.Controls.SetChildIndex(this.colsCreateWhenChecked, 0);
            this.Controls.SetChildIndex(this.colsCheckWhenLoaded, 0);
            this.Controls.SetChildIndex(this.colAutoTaxCalc, 0);
            this.Controls.SetChildIndex(this.colsUseCodestrCompl, 0);
            this.Controls.SetChildIndex(this.colsValidateCodeString, 0);
            this.Controls.SetChildIndex(this.colCorrection, 0);
            this.Controls.SetChildIndex(this.colExtAlterTrans, 0);
            this.Controls.SetChildIndex(this.colExtVoucherDate, 0);
            this.Controls.SetChildIndex(this.colExtGroupItem, 0);
            this.Controls.SetChildIndex(this.colExtVoucherDiff, 0);
            this.Controls.SetChildIndex(this.colExtVoucherNoAlloc, 0);
            this.Controls.SetChildIndex(this.colsDefType, 0);
            this.Controls.SetChildIndex(this.colVoucherType, 0);
            this.Controls.SetChildIndex(this.colsLoadType, 0);
            this.Controls.SetChildIndex(this.colCompany, 0);
            this.Controls.SetChildIndex(this.@__colObjversion, 0);
            this.Controls.SetChildIndex(this.@__colObjid, 0);
            this.menuOperations.ResumeLayout(false);
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

        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menuChange__Company___;
        public Fnd.Windows.Forms.FndCommand menuOperations_menuChange__Company___;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuOperations;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTbwMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change_1;
	}
}
