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
	
	public partial class tbwStatFee
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cColumn colCompany;
		// Bug 89816, Begin - Removed Validate
		public cColumn colFeeCode;
		// Bug 89816, End
		public cColumn colDescription;
		public cColumn colPercentage;
		// Bug 88078, Begin, Changed F1 property to attribute
		public cColumn colValidFrom;
		// Bug 88078, End
		public cColumn colValidUntil;
		public cLookupColumn colFeeType;
		public cLookupColumn colsVatReceived;
		public cLookupColumn colsVatDisbursed;
		public cColumn colnDeductible;
		public cCheckBoxColumn colMultipleTax;
		public cCheckBoxColumn colsTaxRecoverable;
		public cColumn colsFeeTypeDb;
		public cLookupColumn colTaxAmountAtInvPrint;
		public cColumn colTaxAmountLimit;
		// Bug 86773, Begin
		public cLookupColumn colTaxReportingCategory;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwStatFee));
            this.menuOperations_menu_Translation___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuOperations_menu_Tax_Withholding___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuOperations_menu_Change_Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_menu_Details___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_menu_Translation___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_menu_Tax_Texts_per_Tax_Code___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_menu_Tax_Withholding___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_menu_Change_Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.colCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colFeeCode = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colPercentage = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colValidFrom = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colValidUntil = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colFeeType = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.colsVatReceived = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.colsVatDisbursed = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.colnDeductible = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colMultipleTax = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.colsTaxRecoverable = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.colsFeeTypeDb = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colTaxAmountAtInvPrint = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.colTaxAmountLimit = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colTaxReportingCategory = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.menuTbwMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem__Details = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem__Translation = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem__Tax = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem__Tax_1 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuSeparator1 = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.menuItem__Change = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuOperations = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem__Translation_1 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem__Tax_2 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuSeparator2 = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.menuItem__Change_1 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuSeparator3 = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.menuTbwMethods.SuspendLayout();
            this.menuOperations.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuTbwMethods_menu_Details___);
            this.commandManager.Commands.Add(this.menuTbwMethods_menu_Translation___);
            this.commandManager.Commands.Add(this.menuTbwMethods_menu_Tax_Texts_per_Tax_Code___);
            this.commandManager.Commands.Add(this.menuTbwMethods_menu_Tax_Withholding___);
            this.commandManager.Commands.Add(this.menuTbwMethods_menu_Change_Company___);
            this.commandManager.Commands.Add(this.menuOperations_menu_Translation___);
            this.commandManager.Commands.Add(this.menuOperations_menu_Tax_Withholding___);
            this.commandManager.Commands.Add(this.menuOperations_menu_Change_Company___);
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
            // menuOperations_menu_Tax_Withholding___
            // 
            resources.ApplyResources(this.menuOperations_menu_Tax_Withholding___, "menuOperations_menu_Tax_Withholding___");
            this.menuOperations_menu_Tax_Withholding___.Name = "menuOperations_menu_Tax_Withholding___";
            this.menuOperations_menu_Tax_Withholding___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Tax_2_Execute);
            this.menuOperations_menu_Tax_Withholding___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Tax_2_Inquire);
            // 
            // menuOperations_menu_Change_Company___
            // 
            resources.ApplyResources(this.menuOperations_menu_Change_Company___, "menuOperations_menu_Change_Company___");
            this.menuOperations_menu_Change_Company___.Name = "menuOperations_menu_Change_Company___";
            this.menuOperations_menu_Change_Company___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Change_1_Execute);
            this.menuOperations_menu_Change_Company___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Change_1_Inquire);
            // 
            // menuTbwMethods_menu_Details___
            // 
            resources.ApplyResources(this.menuTbwMethods_menu_Details___, "menuTbwMethods_menu_Details___");
            this.menuTbwMethods_menu_Details___.Name = "menuTbwMethods_menu_Details___";
            this.menuTbwMethods_menu_Details___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Details_Execute);
            this.menuTbwMethods_menu_Details___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Details_Inquire);
            // 
            // menuTbwMethods_menu_Translation___
            // 
            resources.ApplyResources(this.menuTbwMethods_menu_Translation___, "menuTbwMethods_menu_Translation___");
            this.menuTbwMethods_menu_Translation___.Name = "menuTbwMethods_menu_Translation___";
            this.menuTbwMethods_menu_Translation___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Translation_Execute);
            this.menuTbwMethods_menu_Translation___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Translation_Inquire);
            // 
            // menuTbwMethods_menu_Tax_Texts_per_Tax_Code___
            // 
            resources.ApplyResources(this.menuTbwMethods_menu_Tax_Texts_per_Tax_Code___, "menuTbwMethods_menu_Tax_Texts_per_Tax_Code___");
            this.menuTbwMethods_menu_Tax_Texts_per_Tax_Code___.Name = "menuTbwMethods_menu_Tax_Texts_per_Tax_Code___";
            this.menuTbwMethods_menu_Tax_Texts_per_Tax_Code___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Tax_Execute);
            this.menuTbwMethods_menu_Tax_Texts_per_Tax_Code___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Tax_Inquire);
            // 
            // menuTbwMethods_menu_Tax_Withholding___
            // 
            resources.ApplyResources(this.menuTbwMethods_menu_Tax_Withholding___, "menuTbwMethods_menu_Tax_Withholding___");
            this.menuTbwMethods_menu_Tax_Withholding___.Name = "menuTbwMethods_menu_Tax_Withholding___";
            this.menuTbwMethods_menu_Tax_Withholding___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Tax_1_Execute);
            this.menuTbwMethods_menu_Tax_Withholding___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Tax_1_Inquire);
            // 
            // menuTbwMethods_menu_Change_Company___
            // 
            resources.ApplyResources(this.menuTbwMethods_menu_Change_Company___, "menuTbwMethods_menu_Change_Company___");
            this.menuTbwMethods_menu_Change_Company___.Name = "menuTbwMethods_menu_Change_Company___";
            this.menuTbwMethods_menu_Change_Company___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Change_Execute);
            this.menuTbwMethods_menu_Change_Company___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Change_Inquire);
            // 
            // colCompany
            // 
            resources.ApplyResources(this.colCompany, "colCompany");
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
            // colFeeCode
            // 
            this.colFeeCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colFeeCode.MaxLength = 20;
            this.colFeeCode.Name = "colFeeCode";
            this.colFeeCode.NamedProperties.Put("EnumerateMethod", "");
            this.colFeeCode.NamedProperties.Put("FieldFlags", "163");
            this.colFeeCode.NamedProperties.Put("LovReference", "");
            this.colFeeCode.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colFeeCode.NamedProperties.Put("ResizeableChildObject", "");
            this.colFeeCode.NamedProperties.Put("SqlColumn", "FEE_CODE");
            this.colFeeCode.NamedProperties.Put("ValidateMethod", "");
            this.colFeeCode.Position = 4;
            resources.ApplyResources(this.colFeeCode, "colFeeCode");
            // 
            // colDescription
            // 
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
            // colPercentage
            // 
            this.colPercentage.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colPercentage.Name = "colPercentage";
            this.colPercentage.NamedProperties.Put("EnumerateMethod", "");
            this.colPercentage.NamedProperties.Put("FieldFlags", "295");
            this.colPercentage.NamedProperties.Put("LovReference", "");
            this.colPercentage.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colPercentage.NamedProperties.Put("ResizeableChildObject", "");
            this.colPercentage.NamedProperties.Put("SqlColumn", "FEE_RATE");
            this.colPercentage.NamedProperties.Put("ValidateMethod", "");
            this.colPercentage.Position = 6;
            this.colPercentage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.colPercentage, "colPercentage");
            // 
            // colValidFrom
            // 
            this.colValidFrom.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.colValidFrom.Format = "d";
            this.colValidFrom.Name = "colValidFrom";
            this.colValidFrom.NamedProperties.Put("EnumerateMethod", "");
            this.colValidFrom.NamedProperties.Put("FieldFlags", "291");
            this.colValidFrom.NamedProperties.Put("LovReference", "");
            this.colValidFrom.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colValidFrom.NamedProperties.Put("SqlColumn", "VALID_FROM");
            this.colValidFrom.NamedProperties.Put("ValidateMethod", "");
            this.colValidFrom.Position = 7;
            resources.ApplyResources(this.colValidFrom, "colValidFrom");
            this.colValidFrom.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colValidFrom_WindowActions);
            // 
            // colValidUntil
            // 
            this.colValidUntil.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.colValidUntil.Format = "d";
            this.colValidUntil.Name = "colValidUntil";
            this.colValidUntil.NamedProperties.Put("EnumerateMethod", "");
            this.colValidUntil.NamedProperties.Put("FieldFlags", "295");
            this.colValidUntil.NamedProperties.Put("LovReference", "");
            this.colValidUntil.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colValidUntil.NamedProperties.Put("SqlColumn", "VALID_UNTIL");
            this.colValidUntil.NamedProperties.Put("ValidateMethod", "");
            this.colValidUntil.Position = 8;
            resources.ApplyResources(this.colValidUntil, "colValidUntil");
            // 
            // colFeeType
            // 
            this.colFeeType.MaxLength = 20;
            this.colFeeType.Name = "colFeeType";
            this.colFeeType.NamedProperties.Put("EnumerateMethod", "FEE_TYPE_API.Enumerate");
            this.colFeeType.NamedProperties.Put("FieldFlags", "295");
            this.colFeeType.NamedProperties.Put("LovReference", "");
            this.colFeeType.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colFeeType.NamedProperties.Put("ResizeableChildObject", "");
            this.colFeeType.NamedProperties.Put("SqlColumn", "FEE_TYPE");
            this.colFeeType.NamedProperties.Put("ValidateMethod", "");
            this.colFeeType.Position = 9;
            resources.ApplyResources(this.colFeeType, "colFeeType");
            this.colFeeType.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colFeeType_WindowActions);
            // 
            // colsVatReceived
            // 
            this.colsVatReceived.MaxLength = 20;
            this.colsVatReceived.Name = "colsVatReceived";
            this.colsVatReceived.NamedProperties.Put("EnumerateMethod", "VAT_METHOD_API.Enumerate_Supp");
            this.colsVatReceived.NamedProperties.Put("FieldFlags", "295");
            this.colsVatReceived.NamedProperties.Put("LovReference", "");
            this.colsVatReceived.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsVatReceived.NamedProperties.Put("ResizeableChildObject", "");
            this.colsVatReceived.NamedProperties.Put("SqlColumn", "VAT_RECEIVED");
            this.colsVatReceived.NamedProperties.Put("ValidateMethod", "");
            this.colsVatReceived.Position = 10;
            resources.ApplyResources(this.colsVatReceived, "colsVatReceived");
            this.colsVatReceived.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsVatReceived_WindowActions);
            // 
            // colsVatDisbursed
            // 
            this.colsVatDisbursed.MaxLength = 20;
            this.colsVatDisbursed.Name = "colsVatDisbursed";
            this.colsVatDisbursed.NamedProperties.Put("EnumerateMethod", "VAT_METHOD_API.Enumerate_Cust");
            this.colsVatDisbursed.NamedProperties.Put("FieldFlags", "295");
            this.colsVatDisbursed.NamedProperties.Put("LovReference", "");
            this.colsVatDisbursed.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsVatDisbursed.NamedProperties.Put("ResizeableChildObject", "");
            this.colsVatDisbursed.NamedProperties.Put("SqlColumn", "VAT_DISBURSED");
            this.colsVatDisbursed.NamedProperties.Put("ValidateMethod", "");
            this.colsVatDisbursed.Position = 11;
            resources.ApplyResources(this.colsVatDisbursed, "colsVatDisbursed");
            this.colsVatDisbursed.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsVatDisbursed_WindowActions);
            // 
            // colnDeductible
            // 
            this.colnDeductible.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colnDeductible.Name = "colnDeductible";
            this.colnDeductible.NamedProperties.Put("EnumerateMethod", "");
            this.colnDeductible.NamedProperties.Put("FieldFlags", "295");
            this.colnDeductible.NamedProperties.Put("LovReference", "");
            this.colnDeductible.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colnDeductible.NamedProperties.Put("ResizeableChildObject", "");
            this.colnDeductible.NamedProperties.Put("SqlColumn", "DEDUCTIBLE");
            this.colnDeductible.NamedProperties.Put("ValidateMethod", "");
            this.colnDeductible.Position = 12;
            this.colnDeductible.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.colnDeductible, "colnDeductible");
            // 
            // colMultipleTax
            // 
            this.colMultipleTax.Name = "colMultipleTax";
            this.colMultipleTax.NamedProperties.Put("EnumerateMethod", "");
            this.colMultipleTax.NamedProperties.Put("FieldFlags", "288");
            this.colMultipleTax.NamedProperties.Put("LovReference", "");
            this.colMultipleTax.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colMultipleTax.NamedProperties.Put("ResizeableChildObject", "");
            this.colMultipleTax.NamedProperties.Put("SqlColumn", "MULTIPLE_TAX");
            this.colMultipleTax.NamedProperties.Put("ValidateMethod", "");
            this.colMultipleTax.Position = 13;
            resources.ApplyResources(this.colMultipleTax, "colMultipleTax");
            // 
            // colsTaxRecoverable
            // 
            this.colsTaxRecoverable.CheckBox.CheckedValue = "TRUE";
            this.colsTaxRecoverable.CheckBox.IgnoreCase = false;
            this.colsTaxRecoverable.CheckBox.UncheckedValue = "FALSE";
            this.colsTaxRecoverable.MaxLength = 5;
            this.colsTaxRecoverable.Name = "colsTaxRecoverable";
            this.colsTaxRecoverable.NamedProperties.Put("EnumerateMethod", "");
            this.colsTaxRecoverable.NamedProperties.Put("FieldFlags", "295");
            this.colsTaxRecoverable.NamedProperties.Put("LovReference", "");
            this.colsTaxRecoverable.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsTaxRecoverable.NamedProperties.Put("ResizeableChildObject", "");
            this.colsTaxRecoverable.NamedProperties.Put("SqlColumn", "TAX_RECOVERABLE");
            this.colsTaxRecoverable.NamedProperties.Put("ValidateMethod", "");
            this.colsTaxRecoverable.Position = 14;
            resources.ApplyResources(this.colsTaxRecoverable, "colsTaxRecoverable");
            // 
            // colsFeeTypeDb
            // 
            resources.ApplyResources(this.colsFeeTypeDb, "colsFeeTypeDb");
            this.colsFeeTypeDb.MaxLength = 20;
            this.colsFeeTypeDb.Name = "colsFeeTypeDb";
            this.colsFeeTypeDb.NamedProperties.Put("EnumerateMethod", "");
            this.colsFeeTypeDb.NamedProperties.Put("FieldFlags", "288");
            this.colsFeeTypeDb.NamedProperties.Put("LovReference", "");
            this.colsFeeTypeDb.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsFeeTypeDb.NamedProperties.Put("SqlColumn", "FEE_TYPE_DB");
            this.colsFeeTypeDb.Position = 15;
            // 
            // colTaxAmountAtInvPrint
            // 
            this.colTaxAmountAtInvPrint.MaxLength = 40;
            this.colTaxAmountAtInvPrint.Name = "colTaxAmountAtInvPrint";
            this.colTaxAmountAtInvPrint.NamedProperties.Put("EnumerateMethod", "TAX_AMOUNT_AT_INV_PRINT_API.Enumerate");
            this.colTaxAmountAtInvPrint.NamedProperties.Put("FieldFlags", "295");
            this.colTaxAmountAtInvPrint.NamedProperties.Put("LovReference", "");
            this.colTaxAmountAtInvPrint.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colTaxAmountAtInvPrint.NamedProperties.Put("ResizeableChildObject", "");
            this.colTaxAmountAtInvPrint.NamedProperties.Put("SqlColumn", "TAX_AMOUNT_AT_INV_PRINT");
            this.colTaxAmountAtInvPrint.NamedProperties.Put("ValidateMethod", "");
            this.colTaxAmountAtInvPrint.Position = 16;
            resources.ApplyResources(this.colTaxAmountAtInvPrint, "colTaxAmountAtInvPrint");
            this.colTaxAmountAtInvPrint.WordWrap = true;
            // 
            // colTaxAmountLimit
            // 
            this.colTaxAmountLimit.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colTaxAmountLimit.Name = "colTaxAmountLimit";
            this.colTaxAmountLimit.NamedProperties.Put("EnumerateMethod", "");
            this.colTaxAmountLimit.NamedProperties.Put("FieldFlags", "262");
            this.colTaxAmountLimit.NamedProperties.Put("LovReference", "");
            this.colTaxAmountLimit.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colTaxAmountLimit.NamedProperties.Put("ResizeableChildObject", "");
            this.colTaxAmountLimit.NamedProperties.Put("SqlColumn", "TAX_AMT_LIMIT");
            this.colTaxAmountLimit.NamedProperties.Put("ValidateMethod", "");
            this.colTaxAmountLimit.Position = 17;
            this.colTaxAmountLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.colTaxAmountLimit, "colTaxAmountLimit");
            // 
            // colTaxReportingCategory
            // 
            this.colTaxReportingCategory.Name = "colTaxReportingCategory";
            this.colTaxReportingCategory.NamedProperties.Put("EnumerateMethod", "TAX_REPORTING_CATEGORY_API.Enumerate");
            this.colTaxReportingCategory.NamedProperties.Put("FieldFlags", "295");
            this.colTaxReportingCategory.NamedProperties.Put("LovReference", "");
            this.colTaxReportingCategory.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colTaxReportingCategory.NamedProperties.Put("ResizeableChildObject", "");
            this.colTaxReportingCategory.NamedProperties.Put("SqlColumn", "TAX_REPORTING_CATEGORY");
            this.colTaxReportingCategory.NamedProperties.Put("ValidateMethod", "");
            this.colTaxReportingCategory.Position = 18;
            resources.ApplyResources(this.colTaxReportingCategory, "colTaxReportingCategory");
            this.colTaxReportingCategory.WordWrap = true;
            this.colTaxReportingCategory.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colTaxReportingCategory_WindowActions);
            // 
            // menuTbwMethods
            // 
            this.menuTbwMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem__Details,
            this.menuItem__Translation,
            this.menuItem__Tax,
            this.menuItem__Tax_1,
            this.menuSeparator1,
            this.menuItem__Change});
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
            // menuItem__Translation
            // 
            this.menuItem__Translation.Command = this.menuTbwMethods_menu_Translation___;
            this.menuItem__Translation.Name = "menuItem__Translation";
            resources.ApplyResources(this.menuItem__Translation, "menuItem__Translation");
            this.menuItem__Translation.Text = "&Translation...";
            // 
            // menuItem__Tax
            // 
            this.menuItem__Tax.Command = this.menuTbwMethods_menu_Tax_Texts_per_Tax_Code___;
            this.menuItem__Tax.Name = "menuItem__Tax";
            resources.ApplyResources(this.menuItem__Tax, "menuItem__Tax");
            this.menuItem__Tax.Text = "&Tax Texts per Tax Code...";
            // 
            // menuItem__Tax_1
            // 
            this.menuItem__Tax_1.Command = this.menuTbwMethods_menu_Tax_Withholding___;
            this.menuItem__Tax_1.Name = "menuItem__Tax_1";
            resources.ApplyResources(this.menuItem__Tax_1, "menuItem__Tax_1");
            this.menuItem__Tax_1.Text = "&Tax Withholding...";
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
            this.menuItem__Translation_1,
            this.menuItem__Tax_2,
            this.menuSeparator2,
            this.menuItem__Change_1,
            this.menuSeparator3});
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
            // menuItem__Tax_2
            // 
            this.menuItem__Tax_2.Command = this.menuOperations_menu_Tax_Withholding___;
            this.menuItem__Tax_2.Name = "menuItem__Tax_2";
            resources.ApplyResources(this.menuItem__Tax_2, "menuItem__Tax_2");
            this.menuItem__Tax_2.Text = "&Tax Withholding...";
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
            // menuSeparator3
            // 
            this.menuSeparator3.Name = "menuSeparator3";
            resources.ApplyResources(this.menuSeparator3, "menuSeparator3");
            // 
            // tbwStatFee
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colCompany);
            this.Controls.Add(this.colFeeCode);
            this.Controls.Add(this.colDescription);
            this.Controls.Add(this.colPercentage);
            this.Controls.Add(this.colValidFrom);
            this.Controls.Add(this.colValidUntil);
            this.Controls.Add(this.colFeeType);
            this.Controls.Add(this.colsVatReceived);
            this.Controls.Add(this.colsVatDisbursed);
            this.Controls.Add(this.colnDeductible);
            this.Controls.Add(this.colMultipleTax);
            this.Controls.Add(this.colsTaxRecoverable);
            this.Controls.Add(this.colsFeeTypeDb);
            this.Controls.Add(this.colTaxAmountAtInvPrint);
            this.Controls.Add(this.colTaxAmountLimit);
            this.Controls.Add(this.colTaxReportingCategory);
            this.Name = "tbwStatFee";
            this.NamedProperties.Put("DefaultOrderBy", "fee_type,fee_code");
            this.NamedProperties.Put("DefaultWhere", "company = :i_hWndFrame.tbwStatFee.i_sCompany");
            this.NamedProperties.Put("LogicalUnit", "StatutoryFee");
            this.NamedProperties.Put("PackageName", "STATUTORY_FEE_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "0");
            this.NamedProperties.Put("SourceFlags", "449");
            this.NamedProperties.Put("ViewName", "STATUTORY_FEE_DEDUCT_MULTIPLE");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tbwStatFee_WindowActions);
            this.Controls.SetChildIndex(this.colTaxReportingCategory, 0);
            this.Controls.SetChildIndex(this.colTaxAmountLimit, 0);
            this.Controls.SetChildIndex(this.colTaxAmountAtInvPrint, 0);
            this.Controls.SetChildIndex(this.colsFeeTypeDb, 0);
            this.Controls.SetChildIndex(this.colsTaxRecoverable, 0);
            this.Controls.SetChildIndex(this.colMultipleTax, 0);
            this.Controls.SetChildIndex(this.colnDeductible, 0);
            this.Controls.SetChildIndex(this.colsVatDisbursed, 0);
            this.Controls.SetChildIndex(this.colsVatReceived, 0);
            this.Controls.SetChildIndex(this.colFeeType, 0);
            this.Controls.SetChildIndex(this.colValidUntil, 0);
            this.Controls.SetChildIndex(this.colValidFrom, 0);
            this.Controls.SetChildIndex(this.colPercentage, 0);
            this.Controls.SetChildIndex(this.colDescription, 0);
            this.Controls.SetChildIndex(this.colFeeCode, 0);
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
        public Fnd.Windows.Forms.FndCommand menuOperations_menu_Tax_Withholding___;
        public Fnd.Windows.Forms.FndCommand menuOperations_menu_Change_Company___;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menu_Details___;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menu_Translation___;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menu_Tax_Texts_per_Tax_Code___;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menu_Tax_Withholding___;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menu_Change_Company___;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTbwMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Details;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Translation;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Tax;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Tax_1;
        protected Fnd.Windows.Forms.FndToolStripSeparator menuSeparator1;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Change;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuOperations;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Translation_1;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Tax_2;
        protected Fnd.Windows.Forms.FndToolStripSeparator menuSeparator2;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Change_1;
        protected Fnd.Windows.Forms.FndToolStripSeparator menuSeparator3;
	}
}
