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
	
	public partial class tbwCurrencyType
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cColumn colCompany;
		public cColumn colIdType;
		public cColumn colDescription;
		public cColumn colRefCurrencyCode;
		public cLookupColumn colTypeDefault;
		public cLookupColumn colsRateTypeCategory;
		public cColumn colsRateTypeCategoryDb;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwCurrencyType));
            this.menuOperations_menuCurrency_Rates = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuOperations_menuChange__Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_menuCurrency_Rates = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_menuChange__Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.colCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colIdType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colRefCurrencyCode = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colTypeDefault = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.colsRateTypeCategory = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.colsRateTypeCategoryDb = new Ifs.Fnd.ApplicationForms.cColumn();
            this.menuTbwMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_Currency = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuSeparator1 = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.menuItem_Change = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuOperations = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_Currency_1 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuSeparator2 = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.menuItem_Change_1 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuTbwMethods.SuspendLayout();
            this.menuOperations.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuTbwMethods_menuCurrency_Rates);
            this.commandManager.Commands.Add(this.menuTbwMethods_menuChange__Company___);
            this.commandManager.Commands.Add(this.menuOperations_menuCurrency_Rates);
            this.commandManager.Commands.Add(this.menuOperations_menuChange__Company___);
            this.commandManager.ContextMenus.Add(this.menuTbwMethods);
            this.commandManager.ContextMenus.Add(this.menuOperations);
            // 
            // menuOperations_menuCurrency_Rates
            // 
            resources.ApplyResources(this.menuOperations_menuCurrency_Rates, "menuOperations_menuCurrency_Rates");
            this.menuOperations_menuCurrency_Rates.Name = "menuOperations_menuCurrency_Rates";
            this.menuOperations_menuCurrency_Rates.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Currency_1_Execute);
            this.menuOperations_menuCurrency_Rates.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Currency_1_Inquire);
            // 
            // menuOperations_menuChange__Company___
            // 
            resources.ApplyResources(this.menuOperations_menuChange__Company___, "menuOperations_menuChange__Company___");
            this.menuOperations_menuChange__Company___.Name = "menuOperations_menuChange__Company___";
            this.menuOperations_menuChange__Company___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Change_1_Execute);
            this.menuOperations_menuChange__Company___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Change_1_Inquire);
            // 
            // menuTbwMethods_menuCurrency_Rates
            // 
            resources.ApplyResources(this.menuTbwMethods_menuCurrency_Rates, "menuTbwMethods_menuCurrency_Rates");
            this.menuTbwMethods_menuCurrency_Rates.Name = "menuTbwMethods_menuCurrency_Rates";
            this.menuTbwMethods_menuCurrency_Rates.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Currency_Execute);
            this.menuTbwMethods_menuCurrency_Rates.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Currency_Inquire);
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
            this.colCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.colCompany, "colCompany");
            this.colCompany.Name = "colCompany";
            this.colCompany.NamedProperties.Put("EnumerateMethod", "");
            this.colCompany.NamedProperties.Put("FieldFlags", "131");
            this.colCompany.NamedProperties.Put("LovReference", "");
            this.colCompany.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.colCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.colCompany.NamedProperties.Put("ValidateMethod", "");
            this.colCompany.Position = 3;
            // 
            // colIdType
            // 
            this.colIdType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colIdType.MaxLength = 10;
            this.colIdType.Name = "colIdType";
            this.colIdType.NamedProperties.Put("EnumerateMethod", "");
            this.colIdType.NamedProperties.Put("FieldFlags", "163");
            this.colIdType.NamedProperties.Put("LovReference", "");
            this.colIdType.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colIdType.NamedProperties.Put("ResizeableChildObject", "");
            this.colIdType.NamedProperties.Put("SqlColumn", "CURRENCY_TYPE");
            this.colIdType.NamedProperties.Put("ValidateMethod", "");
            this.colIdType.Position = 4;
            this.colIdType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            resources.ApplyResources(this.colIdType, "colIdType");
            // 
            // colDescription
            // 
            this.colDescription.MaxLength = 35;
            this.colDescription.Name = "colDescription";
            this.colDescription.NamedProperties.Put("EnumerateMethod", "");
            this.colDescription.NamedProperties.Put("FieldFlags", "295");
            this.colDescription.NamedProperties.Put("LovReference", "");
            this.colDescription.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.colDescription.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            this.colDescription.NamedProperties.Put("ValidateMethod", "");
            this.colDescription.Position = 5;
            resources.ApplyResources(this.colDescription, "colDescription");
            // 
            // colRefCurrencyCode
            // 
            this.colRefCurrencyCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colRefCurrencyCode.MaxLength = 3;
            this.colRefCurrencyCode.Name = "colRefCurrencyCode";
            this.colRefCurrencyCode.NamedProperties.Put("EnumerateMethod", "");
            this.colRefCurrencyCode.NamedProperties.Put("FieldFlags", "291");
            this.colRefCurrencyCode.NamedProperties.Put("LovReference", "COMPANY_FINANCE1(COMPANY)");
            this.colRefCurrencyCode.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colRefCurrencyCode.NamedProperties.Put("ResizeableChildObject", "");
            this.colRefCurrencyCode.NamedProperties.Put("SqlColumn", "REF_CURRENCY_CODE");
            this.colRefCurrencyCode.NamedProperties.Put("ValidateMethod", "");
            this.colRefCurrencyCode.Position = 6;
            resources.ApplyResources(this.colRefCurrencyCode, "colRefCurrencyCode");
            this.colRefCurrencyCode.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colRefCurrencyCode_WindowActions);
            // 
            // colTypeDefault
            // 
            this.colTypeDefault.MaxLength = 10;
            this.colTypeDefault.Name = "colTypeDefault";
            this.colTypeDefault.NamedProperties.Put("EnumerateMethod", "CURR_TYPE_DEF_API.Enumerate");
            this.colTypeDefault.NamedProperties.Put("FieldFlags", "295");
            this.colTypeDefault.NamedProperties.Put("LovReference", "");
            this.colTypeDefault.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colTypeDefault.NamedProperties.Put("ResizeableChildObject", "");
            this.colTypeDefault.NamedProperties.Put("SqlColumn", "TYPE_DEFAULT");
            this.colTypeDefault.NamedProperties.Put("ValidateMethod", "");
            this.colTypeDefault.Position = 7;
            this.colTypeDefault.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            resources.ApplyResources(this.colTypeDefault, "colTypeDefault");
            this.colTypeDefault.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colTypeDefault_WindowActions);
            // 
            // colsRateTypeCategory
            // 
            this.colsRateTypeCategory.MaxLength = 200;
            this.colsRateTypeCategory.Name = "colsRateTypeCategory";
            this.colsRateTypeCategory.NamedProperties.Put("EnumerateMethod", "CURR_RATE_TYPE_CATEGORY_API.Enumerate");
            this.colsRateTypeCategory.NamedProperties.Put("FieldFlags", "291");
            this.colsRateTypeCategory.NamedProperties.Put("LovReference", "");
            this.colsRateTypeCategory.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsRateTypeCategory.NamedProperties.Put("ResizeableChildObject", "");
            this.colsRateTypeCategory.NamedProperties.Put("SqlColumn", "RATE_TYPE_CATEGORY");
            this.colsRateTypeCategory.NamedProperties.Put("ValidateMethod", "");
            this.colsRateTypeCategory.Position = 8;
            resources.ApplyResources(this.colsRateTypeCategory, "colsRateTypeCategory");
            // 
            // colsRateTypeCategoryDb
            // 
            resources.ApplyResources(this.colsRateTypeCategoryDb, "colsRateTypeCategoryDb");
            this.colsRateTypeCategoryDb.MaxLength = 20;
            this.colsRateTypeCategoryDb.Name = "colsRateTypeCategoryDb";
            this.colsRateTypeCategoryDb.NamedProperties.Put("EnumerateMethod", "");
            this.colsRateTypeCategoryDb.NamedProperties.Put("FieldFlags", "256");
            this.colsRateTypeCategoryDb.NamedProperties.Put("LovReference", "");
            this.colsRateTypeCategoryDb.NamedProperties.Put("ParentName", "colsRateTypeCategory");
            this.colsRateTypeCategoryDb.NamedProperties.Put("ResizeableChildObject", "");
            this.colsRateTypeCategoryDb.NamedProperties.Put("SqlColumn", "Curr_Rate_Type_Category_API.Encode(RATE_TYPE_CATEGORY)");
            this.colsRateTypeCategoryDb.NamedProperties.Put("ValidateMethod", "");
            this.colsRateTypeCategoryDb.Position = 9;
            // 
            // menuTbwMethods
            // 
            this.menuTbwMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_Currency,
            this.menuSeparator1,
            this.menuItem_Change});
            this.menuTbwMethods.Name = "menuTbwMethods";
            resources.ApplyResources(this.menuTbwMethods, "menuTbwMethods");
            // 
            // menuItem_Currency
            // 
            this.menuItem_Currency.Command = this.menuTbwMethods_menuCurrency_Rates;
            this.menuItem_Currency.Name = "menuItem_Currency";
            resources.ApplyResources(this.menuItem_Currency, "menuItem_Currency");
            this.menuItem_Currency.Text = "Currency Rates...";
            // 
            // menuSeparator1
            // 
            this.menuSeparator1.Name = "menuSeparator1";
            resources.ApplyResources(this.menuSeparator1, "menuSeparator1");
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
            this.menuItem_Currency_1,
            this.menuSeparator2,
            this.menuItem_Change_1});
            this.menuOperations.Name = "menuOperations";
            resources.ApplyResources(this.menuOperations, "menuOperations");
            // 
            // menuItem_Currency_1
            // 
            this.menuItem_Currency_1.Command = this.menuOperations_menuCurrency_Rates;
            this.menuItem_Currency_1.Name = "menuItem_Currency_1";
            resources.ApplyResources(this.menuItem_Currency_1, "menuItem_Currency_1");
            this.menuItem_Currency_1.Text = "Currency Rates...";
            // 
            // menuSeparator2
            // 
            this.menuSeparator2.Name = "menuSeparator2";
            resources.ApplyResources(this.menuSeparator2, "menuSeparator2");
            // 
            // menuItem_Change_1
            // 
            this.menuItem_Change_1.Command = this.menuOperations_menuChange__Company___;
            this.menuItem_Change_1.Name = "menuItem_Change_1";
            resources.ApplyResources(this.menuItem_Change_1, "menuItem_Change_1");
            this.menuItem_Change_1.Text = "Change &Company...";
            // 
            // tbwCurrencyType
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colCompany);
            this.Controls.Add(this.colIdType);
            this.Controls.Add(this.colDescription);
            this.Controls.Add(this.colRefCurrencyCode);
            this.Controls.Add(this.colTypeDefault);
            this.Controls.Add(this.colsRateTypeCategory);
            this.Controls.Add(this.colsRateTypeCategoryDb);
            this.Name = "tbwCurrencyType";
            this.NamedProperties.Put("DefaultOrderBy", "CURRENCY_TYPE");
            this.NamedProperties.Put("DefaultWhere", "COMPANY= :global.company");
            this.NamedProperties.Put("LogicalUnit", "CurrencyType");
            this.NamedProperties.Put("PackageName", "CURRENCY_TYPE_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "0");
            this.NamedProperties.Put("SourceFlags", "449");
            this.NamedProperties.Put("ViewName", "CURRENCY_TYPE3");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tbwCurrencyType_WindowActions);
            this.Controls.SetChildIndex(this.colsRateTypeCategoryDb, 0);
            this.Controls.SetChildIndex(this.colsRateTypeCategory, 0);
            this.Controls.SetChildIndex(this.colTypeDefault, 0);
            this.Controls.SetChildIndex(this.colRefCurrencyCode, 0);
            this.Controls.SetChildIndex(this.colDescription, 0);
            this.Controls.SetChildIndex(this.colIdType, 0);
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

        public Fnd.Windows.Forms.FndCommand menuOperations_menuCurrency_Rates;
        public Fnd.Windows.Forms.FndCommand menuOperations_menuChange__Company___;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menuCurrency_Rates;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menuChange__Company___;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTbwMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Currency;
        protected Fnd.Windows.Forms.FndToolStripSeparator menuSeparator1;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuOperations;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Currency_1;
        protected Fnd.Windows.Forms.FndToolStripSeparator menuSeparator2;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change_1;
	}
}
