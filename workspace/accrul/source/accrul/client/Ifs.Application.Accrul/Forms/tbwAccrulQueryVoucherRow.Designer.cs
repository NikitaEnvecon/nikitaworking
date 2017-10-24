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
	
	public partial class tbwAccrulQueryVoucherRow
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Accessories
		
		/// <summary>
		/// Toolbar control.
		/// </summary>
		protected SalFormToolBar ToolBar;
		
		/// <summary>
		/// StatusBar control.
		/// </summary>
		protected SalFormStatusBar StatusBar;
		#endregion
		
		
		#region Window Controls
		protected cBackgroundText labeldfDescription;
		public cDataFieldFinDescription dfDescription;
		protected cBackgroundText labeldfCodePartValue;
		public cDataFieldFinContent dfCodePartValue;
		public cColumn colCompany;
		// Bug 73468, Begin , Changed format to UPPERCASE in F1 properties.
		public cColumn colVoucherType;
		// Bug 73468, End
		public cColumn colFunctionGroup;
		public cColumn colVoucherNo;
		public cColumn colVoucherDate;
		public cColumn colAccountingYear;
		public cColumn colAccountingPeriod;
		public cColumn colnYearPeriodKey;
		public cCheckBoxColumn colCorrection;
		public cCheckBoxColumn colMultiCompanyVoucher;
		public SalTableColumn colsParentCompany;
		public SalTableColumn colsVoucherTypeRef;
		public SalTableColumn colnVoucherNoRef;
		public SalTableColumn colnAccountingYearRef;
		public cColumnCodePartFin colAccount;
		public cColumnCodePartDescFin colsAccountDesc;
		public cColumnCodePartFin colCodeB;
		public cColumnCodePartDescFin colsCodeBDesc;
		public cColumnCodePartFin colCodeC;
		public cColumnCodePartDescFin colsCodeCDesc;
		public cColumnCodePartFin colCodeD;
		public cColumnCodePartDescFin colsCodeDDesc;
		public cColumnCodePartFin colCodeE;
		public cColumnCodePartDescFin colsCodeEDesc;
		public cColumnCodePartFin colCodeF;
		public cColumnCodePartDescFin colsCodeFDesc;
		public cColumnCodePartFin colCodeG;
		public cColumnCodePartDescFin colsCodeGDesc;
		public cColumnCodePartFin colCodeH;
		public cColumnCodePartDescFin colsCodeHDesc;
		public cColumnCodePartFin colCodeI;
		public cColumnCodePartDescFin colsCodeIDesc;
		public cColumnCodePartFin colCodeJ;
		public cColumnCodePartDescFin colsCodeJDesc;
		public cColumn colDebetAmount;
		public cColumn colCreditAmount;
		public cColumn colAmount;
		public cColumn colCurrencyCode;
		public cColumn colCurrencyDebetAmount;
		public cColumn colCurrencyCreditAmount;
		public cColumn colCurrencyAmount;
		public cColumn colCurrencyRate;
		public cColumnFinEuro colnThirdCurrencyRate;
		public cColumnFinEuro colnThirdCurrencyDebitAmount;
		public cColumnFinEuro colnThirdCurrencyCreditAmount;
		public cColumnFinEuro colnThirdCurrencyAmount;
		public cColumn colText;
		public cColumn colQuantity;
		public cColumn colProcess_Code;
		public cColumn colOptional_Code;
		public cColumn colProjActivityId;
		public cColumn colParty_Type_Id;
		public cColumn colTrans_Code;
		public cColumn colUpdate_Error;
		public cColumn colTransfer_Id;
		public cColumn colCorrected;
		public cColumn colPeriodical_Allocation;
		public cColumn colReferenceSerie;
		public cColumn colReferenceNumber;
		public cColumn colMultiCompanyId;
		public cCheckBoxColumn colAutoTaxVouEntry;
		public cColumn colsRowNo;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwAccrulQueryVoucherRow));
            this.menuTbwMethods_menuVoucher__Details___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_menuView__Multi_Company_Voucher___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_menuChange__Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuOperations_menuVoucher__Details___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuOperations_menuView__Multi_Company_Voucher___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuOperations_menuChange__Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.ToolBar = new PPJ.Runtime.Windows.SalFormToolBar();
            this.dfCodePartValue = new Ifs.Application.Accrul.cDataFieldFinContent();
            this.dfDescription = new Ifs.Application.Accrul.cDataFieldFinDescription();
            this.labeldfCodePartValue = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.labeldfDescription = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.StatusBar = new PPJ.Runtime.Windows.SalFormStatusBar();
            this.colCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colVoucherType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colFunctionGroup = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colVoucherNo = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colVoucherDate = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colAccountingYear = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colAccountingPeriod = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colnYearPeriodKey = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colCorrection = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.colMultiCompanyVoucher = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.colsParentCompany = new PPJ.Runtime.Windows.SalTableColumn();
            this.colsVoucherTypeRef = new PPJ.Runtime.Windows.SalTableColumn();
            this.colnVoucherNoRef = new PPJ.Runtime.Windows.SalTableColumn();
            this.colnAccountingYearRef = new PPJ.Runtime.Windows.SalTableColumn();
            this.colAccount = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.colsAccountDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.colCodeB = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.colsCodeBDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.colCodeC = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.colsCodeCDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.colCodeD = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.colsCodeDDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.colCodeE = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.colsCodeEDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.colCodeF = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.colsCodeFDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.colCodeG = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.colsCodeGDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.colCodeH = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.colsCodeHDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.colCodeI = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.colsCodeIDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.colCodeJ = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.colsCodeJDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.colDebetAmount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colCreditAmount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colAmount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colCurrencyCode = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colCurrencyDebetAmount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colCurrencyCreditAmount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colCurrencyAmount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colCurrencyRate = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colnThirdCurrencyRate = new Ifs.Application.Accrul.cColumnFinEuro();
            this.colnThirdCurrencyDebitAmount = new Ifs.Application.Accrul.cColumnFinEuro();
            this.colnThirdCurrencyCreditAmount = new Ifs.Application.Accrul.cColumnFinEuro();
            this.colnThirdCurrencyAmount = new Ifs.Application.Accrul.cColumnFinEuro();
            this.colText = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colQuantity = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colProcess_Code = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colOptional_Code = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colProjActivityId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colParty_Type_Id = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colTrans_Code = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colUpdate_Error = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colTransfer_Id = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colCorrected = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colPeriodical_Allocation = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colReferenceSerie = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colReferenceNumber = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colMultiCompanyId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colAutoTaxVouEntry = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.colsRowNo = new Ifs.Fnd.ApplicationForms.cColumn();
            this.menuOperations = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_Voucher = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem_View = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuSeparator1 = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.menuItem_Change = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuTbwMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_Voucher_1 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem_View_1 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuSeparator2 = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.menuItem_Change_1 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.ToolBar.SuspendLayout();
            this.menuOperations.SuspendLayout();
            this.menuTbwMethods.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuOperations_menuVoucher__Details___);
            this.commandManager.Commands.Add(this.menuOperations_menuView__Multi_Company_Voucher___);
            this.commandManager.Commands.Add(this.menuOperations_menuChange__Company___);
            this.commandManager.Commands.Add(this.menuTbwMethods_menuVoucher__Details___);
            this.commandManager.Commands.Add(this.menuTbwMethods_menuView__Multi_Company_Voucher___);
            this.commandManager.Commands.Add(this.menuTbwMethods_menuChange__Company___);
            this.commandManager.ContextMenus.Add(this.menuOperations);
            this.commandManager.ContextMenus.Add(this.menuTbwMethods);
            // 
            // menuTbwMethods_menuVoucher__Details___
            // 
            resources.ApplyResources(this.menuTbwMethods_menuVoucher__Details___, "menuTbwMethods_menuVoucher__Details___");
            this.menuTbwMethods_menuVoucher__Details___.Name = "menuTbwMethods_menuVoucher__Details___";
            this.menuTbwMethods_menuVoucher__Details___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Voucher_1_Execute);
            this.menuTbwMethods_menuVoucher__Details___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Voucher_1_Inquire);
            // 
            // menuTbwMethods_menuView__Multi_Company_Voucher___
            // 
            resources.ApplyResources(this.menuTbwMethods_menuView__Multi_Company_Voucher___, "menuTbwMethods_menuView__Multi_Company_Voucher___");
            this.menuTbwMethods_menuView__Multi_Company_Voucher___.Name = "menuTbwMethods_menuView__Multi_Company_Voucher___";
            this.menuTbwMethods_menuView__Multi_Company_Voucher___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_View_1_Execute);
            this.menuTbwMethods_menuView__Multi_Company_Voucher___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_View_1_Inquire);
            // 
            // menuTbwMethods_menuChange__Company___
            // 
            resources.ApplyResources(this.menuTbwMethods_menuChange__Company___, "menuTbwMethods_menuChange__Company___");
            this.menuTbwMethods_menuChange__Company___.Name = "menuTbwMethods_menuChange__Company___";
            this.menuTbwMethods_menuChange__Company___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Change_1_Execute);
            this.menuTbwMethods_menuChange__Company___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Change_1_Inquire);
            // 
            // menuOperations_menuVoucher__Details___
            // 
            resources.ApplyResources(this.menuOperations_menuVoucher__Details___, "menuOperations_menuVoucher__Details___");
            this.menuOperations_menuVoucher__Details___.Name = "menuOperations_menuVoucher__Details___";
            this.menuOperations_menuVoucher__Details___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Voucher_Execute);
            this.menuOperations_menuVoucher__Details___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Voucher_Inquire);
            // 
            // menuOperations_menuView__Multi_Company_Voucher___
            // 
            resources.ApplyResources(this.menuOperations_menuView__Multi_Company_Voucher___, "menuOperations_menuView__Multi_Company_Voucher___");
            this.menuOperations_menuView__Multi_Company_Voucher___.Name = "menuOperations_menuView__Multi_Company_Voucher___";
            this.menuOperations_menuView__Multi_Company_Voucher___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_View_Execute);
            this.menuOperations_menuView__Multi_Company_Voucher___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_View_Inquire);
            // 
            // menuOperations_menuChange__Company___
            // 
            resources.ApplyResources(this.menuOperations_menuChange__Company___, "menuOperations_menuChange__Company___");
            this.menuOperations_menuChange__Company___.Name = "menuOperations_menuChange__Company___";
            this.menuOperations_menuChange__Company___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Change_Execute);
            this.menuOperations_menuChange__Company___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Change_Inquire);
            // 
            // ToolBar
            // 
            this.ToolBar.Controls.Add(this.dfCodePartValue);
            this.ToolBar.Controls.Add(this.dfDescription);
            this.ToolBar.Controls.Add(this.labeldfCodePartValue);
            this.ToolBar.Controls.Add(this.labeldfDescription);
            this.ToolBar.Name = "ToolBar";
            resources.ApplyResources(this.ToolBar, "ToolBar");
            this.ToolBar.TabStop = true;
            // 
            // dfCodePartValue
            // 
            resources.ApplyResources(this.dfCodePartValue, "dfCodePartValue");
            this.dfCodePartValue.Name = "dfCodePartValue";
            this.dfCodePartValue.NamedProperties.Put("EnumerateMethod", "");
            this.dfCodePartValue.NamedProperties.Put("FieldFlags", "256");
            this.dfCodePartValue.NamedProperties.Put("LovReference", "");
            this.dfCodePartValue.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.dfCodePartValue.NamedProperties.Put("ResizeableChildObject", "");
            this.dfCodePartValue.NamedProperties.Put("SqlColumn", "");
            this.dfCodePartValue.NamedProperties.Put("ValidateMethod", "");
            this.dfCodePartValue.TabStop = false;
            this.dfCodePartValue.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfCodePartValue_WindowActions);
            // 
            // dfDescription
            // 
            resources.ApplyResources(this.dfDescription, "dfDescription");
            this.dfDescription.Name = "dfDescription";
            this.dfDescription.NamedProperties.Put("EnumerateMethod", "");
            this.dfDescription.NamedProperties.Put("FieldFlags", "256");
            this.dfDescription.NamedProperties.Put("LovReference", "");
            this.dfDescription.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.dfDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.dfDescription.NamedProperties.Put("SqlColumn", "");
            this.dfDescription.NamedProperties.Put("ValidateMethod", "");
            this.dfDescription.TabStop = false;
            // 
            // labeldfCodePartValue
            // 
            resources.ApplyResources(this.labeldfCodePartValue, "labeldfCodePartValue");
            this.labeldfCodePartValue.Name = "labeldfCodePartValue";
            // 
            // labeldfDescription
            // 
            resources.ApplyResources(this.labeldfDescription, "labeldfDescription");
            this.labeldfDescription.Name = "labeldfDescription";
            // 
            // StatusBar
            // 
            resources.ApplyResources(this.StatusBar, "StatusBar");
            this.StatusBar.Name = "StatusBar";
            // 
            // colCompany
            // 
            resources.ApplyResources(this.colCompany, "colCompany");
            this.colCompany.MaxLength = 20;
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
            // colVoucherType
            // 
            this.colVoucherType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colVoucherType.MaxLength = 3;
            this.colVoucherType.Name = "colVoucherType";
            this.colVoucherType.NamedProperties.Put("EnumerateMethod", "");
            this.colVoucherType.NamedProperties.Put("FieldFlags", "163");
            this.colVoucherType.NamedProperties.Put("LovReference", "VOUCHER_TYPE(COMPANY)");
            this.colVoucherType.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colVoucherType.NamedProperties.Put("ResizeableChildObject", "");
            this.colVoucherType.NamedProperties.Put("SqlColumn", "VOUCHER_TYPE");
            this.colVoucherType.NamedProperties.Put("ValidateMethod", "");
            this.colVoucherType.Position = 4;
            resources.ApplyResources(this.colVoucherType, "colVoucherType");
            // 
            // colFunctionGroup
            // 
            this.colFunctionGroup.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colFunctionGroup.MaxLength = 20;
            this.colFunctionGroup.Name = "colFunctionGroup";
            this.colFunctionGroup.NamedProperties.Put("EnumerateMethod", "");
            this.colFunctionGroup.NamedProperties.Put("FieldFlags", "256");
            this.colFunctionGroup.NamedProperties.Put("LovReference", "");
            this.colFunctionGroup.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colFunctionGroup.NamedProperties.Put("ResizeableChildObject", "");
            this.colFunctionGroup.NamedProperties.Put("SqlColumn", "FUNCTION_GROUP");
            this.colFunctionGroup.NamedProperties.Put("ValidateMethod", "");
            this.colFunctionGroup.Position = 5;
            resources.ApplyResources(this.colFunctionGroup, "colFunctionGroup");
            // 
            // colVoucherNo
            // 
            this.colVoucherNo.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colVoucherNo.MaxLength = 10;
            this.colVoucherNo.Name = "colVoucherNo";
            this.colVoucherNo.NamedProperties.Put("EnumerateMethod", "");
            this.colVoucherNo.NamedProperties.Put("FieldFlags", "163");
            this.colVoucherNo.NamedProperties.Put("LovReference", "");
            this.colVoucherNo.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colVoucherNo.NamedProperties.Put("SqlColumn", "VOUCHER_NO");
            this.colVoucherNo.NamedProperties.Put("ValidateMethod", "");
            this.colVoucherNo.Position = 6;
            resources.ApplyResources(this.colVoucherNo, "colVoucherNo");
            // 
            // colVoucherDate
            // 
            this.colVoucherDate.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.colVoucherDate.Format = "d";
            this.colVoucherDate.Name = "colVoucherDate";
            this.colVoucherDate.NamedProperties.Put("EnumerateMethod", "");
            this.colVoucherDate.NamedProperties.Put("FieldFlags", "290");
            this.colVoucherDate.NamedProperties.Put("LovReference", "");
            this.colVoucherDate.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colVoucherDate.NamedProperties.Put("SqlColumn", "VOUCHER_DATE");
            this.colVoucherDate.NamedProperties.Put("ValidateMethod", "");
            this.colVoucherDate.Position = 7;
            resources.ApplyResources(this.colVoucherDate, "colVoucherDate");
            // 
            // colAccountingYear
            // 
            this.colAccountingYear.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colAccountingYear.MaxLength = 4;
            this.colAccountingYear.Name = "colAccountingYear";
            this.colAccountingYear.NamedProperties.Put("EnumerateMethod", "");
            this.colAccountingYear.NamedProperties.Put("FieldFlags", "163");
            this.colAccountingYear.NamedProperties.Put("LovReference", "");
            this.colAccountingYear.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colAccountingYear.NamedProperties.Put("ResizeableChildObject", "");
            this.colAccountingYear.NamedProperties.Put("SqlColumn", "ACCOUNTING_YEAR");
            this.colAccountingYear.NamedProperties.Put("ValidateMethod", "");
            this.colAccountingYear.Position = 8;
            resources.ApplyResources(this.colAccountingYear, "colAccountingYear");
            // 
            // colAccountingPeriod
            // 
            this.colAccountingPeriod.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colAccountingPeriod.MaxLength = 2;
            this.colAccountingPeriod.Name = "colAccountingPeriod";
            this.colAccountingPeriod.NamedProperties.Put("EnumerateMethod", "");
            this.colAccountingPeriod.NamedProperties.Put("FieldFlags", "291");
            this.colAccountingPeriod.NamedProperties.Put("LovReference", "");
            this.colAccountingPeriod.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colAccountingPeriod.NamedProperties.Put("ResizeableChildObject", "");
            this.colAccountingPeriod.NamedProperties.Put("SqlColumn", "ACCOUNTING_PERIOD");
            this.colAccountingPeriod.NamedProperties.Put("ValidateMethod", "");
            this.colAccountingPeriod.Position = 9;
            resources.ApplyResources(this.colAccountingPeriod, "colAccountingPeriod");
            // 
            // colnYearPeriodKey
            // 
            this.colnYearPeriodKey.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colnYearPeriodKey.Name = "colnYearPeriodKey";
            this.colnYearPeriodKey.NamedProperties.Put("EnumerateMethod", "");
            this.colnYearPeriodKey.NamedProperties.Put("FieldFlags", "294");
            this.colnYearPeriodKey.NamedProperties.Put("LovReference", "");
            this.colnYearPeriodKey.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colnYearPeriodKey.NamedProperties.Put("SqlColumn", "YEAR_PERIOD_KEY");
            this.colnYearPeriodKey.Position = 10;
            resources.ApplyResources(this.colnYearPeriodKey, "colnYearPeriodKey");
            // 
            // colCorrection
            // 
            this.colCorrection.CheckBox.CheckedValue = "Y";
            this.colCorrection.CheckBox.IgnoreCase = true;
            this.colCorrection.CheckBox.UncheckedValue = "N";
            this.colCorrection.MaxLength = 1;
            this.colCorrection.Name = "colCorrection";
            this.colCorrection.NamedProperties.Put("EnumerateMethod", "");
            this.colCorrection.NamedProperties.Put("FieldFlags", "288");
            this.colCorrection.NamedProperties.Put("LovReference", "");
            this.colCorrection.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colCorrection.NamedProperties.Put("ResizeableChildObject", "");
            this.colCorrection.NamedProperties.Put("SqlColumn", "CORRECTION");
            this.colCorrection.NamedProperties.Put("ValidateMethod", "");
            this.colCorrection.Position = 11;
            resources.ApplyResources(this.colCorrection, "colCorrection");
            // 
            // colMultiCompanyVoucher
            // 
            this.colMultiCompanyVoucher.MaxLength = 2000;
            this.colMultiCompanyVoucher.Name = "colMultiCompanyVoucher";
            this.colMultiCompanyVoucher.NamedProperties.Put("EnumerateMethod", "");
            this.colMultiCompanyVoucher.NamedProperties.Put("FieldFlags", "288");
            this.colMultiCompanyVoucher.NamedProperties.Put("LovReference", "");
            this.colMultiCompanyVoucher.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colMultiCompanyVoucher.NamedProperties.Put("ResizeableChildObject", "");
            this.colMultiCompanyVoucher.NamedProperties.Put("SqlColumn", "IS_MULTI_COMPANY_ROW");
            this.colMultiCompanyVoucher.NamedProperties.Put("ValidateMethod", "");
            this.colMultiCompanyVoucher.Position = 12;
            resources.ApplyResources(this.colMultiCompanyVoucher, "colMultiCompanyVoucher");
            // 
            // colsParentCompany
            // 
            this.colsParentCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.colsParentCompany, "colsParentCompany");
            this.colsParentCompany.MaxLength = 20;
            this.colsParentCompany.Name = "colsParentCompany";
            this.colsParentCompany.Position = 13;
            // 
            // colsVoucherTypeRef
            // 
            this.colsVoucherTypeRef.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.colsVoucherTypeRef, "colsVoucherTypeRef");
            this.colsVoucherTypeRef.MaxLength = 20;
            this.colsVoucherTypeRef.Name = "colsVoucherTypeRef";
            this.colsVoucherTypeRef.NamedProperties.Put("EnumerateMethod", "");
            this.colsVoucherTypeRef.NamedProperties.Put("FieldFlags", "262");
            this.colsVoucherTypeRef.NamedProperties.Put("LovReference", "");
            this.colsVoucherTypeRef.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsVoucherTypeRef.NamedProperties.Put("ResizeableChildObject", "");
            this.colsVoucherTypeRef.NamedProperties.Put("SqlColumn", "");
            this.colsVoucherTypeRef.NamedProperties.Put("ValidateMethod", "");
            this.colsVoucherTypeRef.Position = 14;
            // 
            // colnVoucherNoRef
            // 
            this.colnVoucherNoRef.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.colnVoucherNoRef, "colnVoucherNoRef");
            this.colnVoucherNoRef.Name = "colnVoucherNoRef";
            this.colnVoucherNoRef.NamedProperties.Put("EnumerateMethod", "");
            this.colnVoucherNoRef.NamedProperties.Put("FieldFlags", "262");
            this.colnVoucherNoRef.NamedProperties.Put("LovReference", "");
            this.colnVoucherNoRef.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colnVoucherNoRef.NamedProperties.Put("ResizeableChildObject", "");
            this.colnVoucherNoRef.NamedProperties.Put("SqlColumn", "");
            this.colnVoucherNoRef.NamedProperties.Put("ValidateMethod", "");
            this.colnVoucherNoRef.Position = 15;
            // 
            // colnAccountingYearRef
            // 
            this.colnAccountingYearRef.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.colnAccountingYearRef, "colnAccountingYearRef");
            this.colnAccountingYearRef.Name = "colnAccountingYearRef";
            this.colnAccountingYearRef.NamedProperties.Put("EnumerateMethod", "");
            this.colnAccountingYearRef.NamedProperties.Put("FieldFlags", "262");
            this.colnAccountingYearRef.NamedProperties.Put("LovReference", "");
            this.colnAccountingYearRef.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colnAccountingYearRef.NamedProperties.Put("ResizeableChildObject", "");
            this.colnAccountingYearRef.NamedProperties.Put("SqlColumn", "");
            this.colnAccountingYearRef.NamedProperties.Put("ValidateMethod", "");
            this.colnAccountingYearRef.Position = 16;
            // 
            // colAccount
            // 
            this.colAccount.MaxLength = 20;
            this.colAccount.Name = "colAccount";
            this.colAccount.NamedProperties.Put("EnumerateMethod", "");
            this.colAccount.NamedProperties.Put("FieldFlags", "288");
            this.colAccount.NamedProperties.Put("LovReference", "ACCOUNT(COMPANY)");
            this.colAccount.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colAccount.NamedProperties.Put("ResizeableChildObject", "");
            this.colAccount.NamedProperties.Put("SqlColumn", "ACCOUNT");
            this.colAccount.NamedProperties.Put("ValidateMethod", "");
            this.colAccount.Position = 17;
            resources.ApplyResources(this.colAccount, "colAccount");
            // 
            // colsAccountDesc
            // 
            this.colsAccountDesc.Name = "colsAccountDesc";
            this.colsAccountDesc.NamedProperties.Put("EnumerateMethod", "");
            this.colsAccountDesc.NamedProperties.Put("FieldFlags", "2304");
            this.colsAccountDesc.NamedProperties.Put("LovReference", "");
            this.colsAccountDesc.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsAccountDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.colsAccountDesc.NamedProperties.Put("SqlColumn", "ACCOUNT_DESC");
            this.colsAccountDesc.NamedProperties.Put("ValidateMethod", "");
            this.colsAccountDesc.Position = 18;
            resources.ApplyResources(this.colsAccountDesc, "colsAccountDesc");
            // 
            // colCodeB
            // 
            this.colCodeB.MaxLength = 20;
            this.colCodeB.Name = "colCodeB";
            this.colCodeB.NamedProperties.Put("EnumerateMethod", "");
            this.colCodeB.NamedProperties.Put("FieldFlags", "288");
            this.colCodeB.NamedProperties.Put("LovReference", "CODE_B(COMPANY)");
            this.colCodeB.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colCodeB.NamedProperties.Put("ResizeableChildObject", "");
            this.colCodeB.NamedProperties.Put("SqlColumn", "CODE_B");
            this.colCodeB.NamedProperties.Put("ValidateMethod", "");
            this.colCodeB.Position = 19;
            resources.ApplyResources(this.colCodeB, "colCodeB");
            // 
            // colsCodeBDesc
            // 
            this.colsCodeBDesc.Name = "colsCodeBDesc";
            this.colsCodeBDesc.NamedProperties.Put("EnumerateMethod", "");
            this.colsCodeBDesc.NamedProperties.Put("FieldFlags", "2304");
            this.colsCodeBDesc.NamedProperties.Put("LovReference", "");
            this.colsCodeBDesc.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsCodeBDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.colsCodeBDesc.NamedProperties.Put("SqlColumn", "CODE_B_DESC");
            this.colsCodeBDesc.NamedProperties.Put("ValidateMethod", "");
            this.colsCodeBDesc.Position = 20;
            resources.ApplyResources(this.colsCodeBDesc, "colsCodeBDesc");
            // 
            // colCodeC
            // 
            this.colCodeC.MaxLength = 20;
            this.colCodeC.Name = "colCodeC";
            this.colCodeC.NamedProperties.Put("EnumerateMethod", "");
            this.colCodeC.NamedProperties.Put("FieldFlags", "288");
            this.colCodeC.NamedProperties.Put("LovReference", "CODE_C(COMPANY)");
            this.colCodeC.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colCodeC.NamedProperties.Put("ResizeableChildObject", "");
            this.colCodeC.NamedProperties.Put("SqlColumn", "CODE_C");
            this.colCodeC.NamedProperties.Put("ValidateMethod", "");
            this.colCodeC.Position = 21;
            resources.ApplyResources(this.colCodeC, "colCodeC");
            // 
            // colsCodeCDesc
            // 
            this.colsCodeCDesc.Name = "colsCodeCDesc";
            this.colsCodeCDesc.NamedProperties.Put("EnumerateMethod", "");
            this.colsCodeCDesc.NamedProperties.Put("FieldFlags", "2304");
            this.colsCodeCDesc.NamedProperties.Put("LovReference", "");
            this.colsCodeCDesc.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsCodeCDesc.NamedProperties.Put("SqlColumn", "CODE_C_DESC");
            this.colsCodeCDesc.NamedProperties.Put("ValidateMethod", "");
            this.colsCodeCDesc.Position = 22;
            resources.ApplyResources(this.colsCodeCDesc, "colsCodeCDesc");
            // 
            // colCodeD
            // 
            this.colCodeD.MaxLength = 20;
            this.colCodeD.Name = "colCodeD";
            this.colCodeD.NamedProperties.Put("EnumerateMethod", "");
            this.colCodeD.NamedProperties.Put("FieldFlags", "288");
            this.colCodeD.NamedProperties.Put("LovReference", "CODE_D(COMPANY)");
            this.colCodeD.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colCodeD.NamedProperties.Put("ResizeableChildObject", "");
            this.colCodeD.NamedProperties.Put("SqlColumn", "CODE_D");
            this.colCodeD.NamedProperties.Put("ValidateMethod", "");
            this.colCodeD.Position = 23;
            resources.ApplyResources(this.colCodeD, "colCodeD");
            // 
            // colsCodeDDesc
            // 
            this.colsCodeDDesc.Name = "colsCodeDDesc";
            this.colsCodeDDesc.NamedProperties.Put("EnumerateMethod", "");
            this.colsCodeDDesc.NamedProperties.Put("FieldFlags", "2304");
            this.colsCodeDDesc.NamedProperties.Put("LovReference", "");
            this.colsCodeDDesc.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsCodeDDesc.NamedProperties.Put("SqlColumn", "CODE_D_DESC");
            this.colsCodeDDesc.NamedProperties.Put("ValidateMethod", "");
            this.colsCodeDDesc.Position = 24;
            resources.ApplyResources(this.colsCodeDDesc, "colsCodeDDesc");
            // 
            // colCodeE
            // 
            this.colCodeE.MaxLength = 20;
            this.colCodeE.Name = "colCodeE";
            this.colCodeE.NamedProperties.Put("EnumerateMethod", "");
            this.colCodeE.NamedProperties.Put("FieldFlags", "288");
            this.colCodeE.NamedProperties.Put("LovReference", "CODE_E(COMPANY)");
            this.colCodeE.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colCodeE.NamedProperties.Put("ResizeableChildObject", "");
            this.colCodeE.NamedProperties.Put("SqlColumn", "CODE_E");
            this.colCodeE.NamedProperties.Put("ValidateMethod", "");
            this.colCodeE.Position = 25;
            resources.ApplyResources(this.colCodeE, "colCodeE");
            // 
            // colsCodeEDesc
            // 
            this.colsCodeEDesc.Name = "colsCodeEDesc";
            this.colsCodeEDesc.NamedProperties.Put("EnumerateMethod", "");
            this.colsCodeEDesc.NamedProperties.Put("FieldFlags", "2304");
            this.colsCodeEDesc.NamedProperties.Put("LovReference", "");
            this.colsCodeEDesc.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsCodeEDesc.NamedProperties.Put("SqlColumn", "CODE_E_DESC");
            this.colsCodeEDesc.NamedProperties.Put("ValidateMethod", "");
            this.colsCodeEDesc.Position = 26;
            resources.ApplyResources(this.colsCodeEDesc, "colsCodeEDesc");
            // 
            // colCodeF
            // 
            this.colCodeF.MaxLength = 20;
            this.colCodeF.Name = "colCodeF";
            this.colCodeF.NamedProperties.Put("EnumerateMethod", "");
            this.colCodeF.NamedProperties.Put("FieldFlags", "288");
            this.colCodeF.NamedProperties.Put("LovReference", "CODE_F(COMPANY)");
            this.colCodeF.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colCodeF.NamedProperties.Put("ResizeableChildObject", "");
            this.colCodeF.NamedProperties.Put("SqlColumn", "CODE_F");
            this.colCodeF.NamedProperties.Put("ValidateMethod", "");
            this.colCodeF.Position = 27;
            resources.ApplyResources(this.colCodeF, "colCodeF");
            // 
            // colsCodeFDesc
            // 
            this.colsCodeFDesc.Name = "colsCodeFDesc";
            this.colsCodeFDesc.NamedProperties.Put("EnumerateMethod", "");
            this.colsCodeFDesc.NamedProperties.Put("FieldFlags", "2304");
            this.colsCodeFDesc.NamedProperties.Put("LovReference", "");
            this.colsCodeFDesc.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsCodeFDesc.NamedProperties.Put("SqlColumn", "CODE_F_DESC");
            this.colsCodeFDesc.NamedProperties.Put("ValidateMethod", "");
            this.colsCodeFDesc.Position = 28;
            resources.ApplyResources(this.colsCodeFDesc, "colsCodeFDesc");
            // 
            // colCodeG
            // 
            this.colCodeG.MaxLength = 20;
            this.colCodeG.Name = "colCodeG";
            this.colCodeG.NamedProperties.Put("EnumerateMethod", "");
            this.colCodeG.NamedProperties.Put("FieldFlags", "288");
            this.colCodeG.NamedProperties.Put("LovReference", "CODE_G(COMPANY)");
            this.colCodeG.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colCodeG.NamedProperties.Put("ResizeableChildObject", "");
            this.colCodeG.NamedProperties.Put("SqlColumn", "CODE_G");
            this.colCodeG.NamedProperties.Put("ValidateMethod", "");
            this.colCodeG.Position = 29;
            resources.ApplyResources(this.colCodeG, "colCodeG");
            // 
            // colsCodeGDesc
            // 
            this.colsCodeGDesc.Name = "colsCodeGDesc";
            this.colsCodeGDesc.NamedProperties.Put("EnumerateMethod", "");
            this.colsCodeGDesc.NamedProperties.Put("FieldFlags", "2304");
            this.colsCodeGDesc.NamedProperties.Put("LovReference", "");
            this.colsCodeGDesc.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsCodeGDesc.NamedProperties.Put("SqlColumn", "CODE_G_DESC");
            this.colsCodeGDesc.NamedProperties.Put("ValidateMethod", "");
            this.colsCodeGDesc.Position = 30;
            resources.ApplyResources(this.colsCodeGDesc, "colsCodeGDesc");
            // 
            // colCodeH
            // 
            this.colCodeH.MaxLength = 20;
            this.colCodeH.Name = "colCodeH";
            this.colCodeH.NamedProperties.Put("EnumerateMethod", "");
            this.colCodeH.NamedProperties.Put("FieldFlags", "288");
            this.colCodeH.NamedProperties.Put("LovReference", "CODE_H(COMPANY)");
            this.colCodeH.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colCodeH.NamedProperties.Put("ResizeableChildObject", "");
            this.colCodeH.NamedProperties.Put("SqlColumn", "CODE_H");
            this.colCodeH.NamedProperties.Put("ValidateMethod", "");
            this.colCodeH.Position = 31;
            resources.ApplyResources(this.colCodeH, "colCodeH");
            // 
            // colsCodeHDesc
            // 
            this.colsCodeHDesc.Name = "colsCodeHDesc";
            this.colsCodeHDesc.NamedProperties.Put("EnumerateMethod", "");
            this.colsCodeHDesc.NamedProperties.Put("FieldFlags", "2304");
            this.colsCodeHDesc.NamedProperties.Put("LovReference", "");
            this.colsCodeHDesc.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsCodeHDesc.NamedProperties.Put("SqlColumn", "CODE_H_DESC");
            this.colsCodeHDesc.NamedProperties.Put("ValidateMethod", "");
            this.colsCodeHDesc.Position = 32;
            resources.ApplyResources(this.colsCodeHDesc, "colsCodeHDesc");
            // 
            // colCodeI
            // 
            this.colCodeI.MaxLength = 20;
            this.colCodeI.Name = "colCodeI";
            this.colCodeI.NamedProperties.Put("EnumerateMethod", "");
            this.colCodeI.NamedProperties.Put("FieldFlags", "288");
            this.colCodeI.NamedProperties.Put("LovReference", "CODE_I(COMPANY)");
            this.colCodeI.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colCodeI.NamedProperties.Put("ResizeableChildObject", "");
            this.colCodeI.NamedProperties.Put("SqlColumn", "CODE_I");
            this.colCodeI.NamedProperties.Put("ValidateMethod", "");
            this.colCodeI.Position = 33;
            resources.ApplyResources(this.colCodeI, "colCodeI");
            // 
            // colsCodeIDesc
            // 
            this.colsCodeIDesc.Name = "colsCodeIDesc";
            this.colsCodeIDesc.NamedProperties.Put("EnumerateMethod", "");
            this.colsCodeIDesc.NamedProperties.Put("FieldFlags", "2304");
            this.colsCodeIDesc.NamedProperties.Put("LovReference", "");
            this.colsCodeIDesc.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsCodeIDesc.NamedProperties.Put("SqlColumn", "CODE_I_DESC");
            this.colsCodeIDesc.NamedProperties.Put("ValidateMethod", "");
            this.colsCodeIDesc.Position = 34;
            resources.ApplyResources(this.colsCodeIDesc, "colsCodeIDesc");
            // 
            // colCodeJ
            // 
            this.colCodeJ.MaxLength = 20;
            this.colCodeJ.Name = "colCodeJ";
            this.colCodeJ.NamedProperties.Put("EnumerateMethod", "");
            this.colCodeJ.NamedProperties.Put("FieldFlags", "288");
            this.colCodeJ.NamedProperties.Put("LovReference", "CODE_J(COMPANY)");
            this.colCodeJ.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colCodeJ.NamedProperties.Put("ResizeableChildObject", "");
            this.colCodeJ.NamedProperties.Put("SqlColumn", "CODE_J");
            this.colCodeJ.NamedProperties.Put("ValidateMethod", "");
            this.colCodeJ.Position = 35;
            resources.ApplyResources(this.colCodeJ, "colCodeJ");
            // 
            // colsCodeJDesc
            // 
            this.colsCodeJDesc.Name = "colsCodeJDesc";
            this.colsCodeJDesc.NamedProperties.Put("EnumerateMethod", "");
            this.colsCodeJDesc.NamedProperties.Put("FieldFlags", "2304");
            this.colsCodeJDesc.NamedProperties.Put("LovReference", "");
            this.colsCodeJDesc.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsCodeJDesc.NamedProperties.Put("SqlColumn", "CODE_J_DESC");
            this.colsCodeJDesc.NamedProperties.Put("ValidateMethod", "");
            this.colsCodeJDesc.Position = 36;
            resources.ApplyResources(this.colsCodeJDesc, "colsCodeJDesc");
            // 
            // colDebetAmount
            // 
            this.colDebetAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colDebetAmount.MaxLength = 15;
            this.colDebetAmount.Name = "colDebetAmount";
            this.colDebetAmount.NamedProperties.Put("EnumerateMethod", "");
            this.colDebetAmount.NamedProperties.Put("FieldFlags", "290");
            this.colDebetAmount.NamedProperties.Put("Format", "20");
            this.colDebetAmount.NamedProperties.Put("LovReference", "");
            this.colDebetAmount.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colDebetAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.colDebetAmount.NamedProperties.Put("SqlColumn", "DEBET_AMOUNT");
            this.colDebetAmount.NamedProperties.Put("ValidateMethod", "");
            this.colDebetAmount.Position = 37;
            this.colDebetAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.colDebetAmount, "colDebetAmount");
            // 
            // colCreditAmount
            // 
            this.colCreditAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colCreditAmount.MaxLength = 15;
            this.colCreditAmount.Name = "colCreditAmount";
            this.colCreditAmount.NamedProperties.Put("EnumerateMethod", "");
            this.colCreditAmount.NamedProperties.Put("FieldFlags", "290");
            this.colCreditAmount.NamedProperties.Put("Format", "20");
            this.colCreditAmount.NamedProperties.Put("LovReference", "");
            this.colCreditAmount.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colCreditAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.colCreditAmount.NamedProperties.Put("SqlColumn", "CREDIT_AMOUNT");
            this.colCreditAmount.NamedProperties.Put("ValidateMethod", "");
            this.colCreditAmount.Position = 38;
            this.colCreditAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.colCreditAmount, "colCreditAmount");
            // 
            // colAmount
            // 
            this.colAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colAmount.MaxLength = 15;
            this.colAmount.Name = "colAmount";
            this.colAmount.NamedProperties.Put("EnumerateMethod", "");
            this.colAmount.NamedProperties.Put("FieldFlags", "291");
            this.colAmount.NamedProperties.Put("Format", "20");
            this.colAmount.NamedProperties.Put("LovReference", "");
            this.colAmount.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.colAmount.NamedProperties.Put("SqlColumn", "AMOUNT");
            this.colAmount.NamedProperties.Put("ValidateMethod", "");
            this.colAmount.Position = 39;
            this.colAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.colAmount, "colAmount");
            // 
            // colCurrencyCode
            // 
            this.colCurrencyCode.MaxLength = 3;
            this.colCurrencyCode.Name = "colCurrencyCode";
            this.colCurrencyCode.NamedProperties.Put("EnumerateMethod", "");
            this.colCurrencyCode.NamedProperties.Put("FieldFlags", "288");
            this.colCurrencyCode.NamedProperties.Put("LovReference", "");
            this.colCurrencyCode.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colCurrencyCode.NamedProperties.Put("SqlColumn", "CURRENCY_CODE");
            this.colCurrencyCode.NamedProperties.Put("ValidateMethod", "");
            this.colCurrencyCode.Position = 40;
            resources.ApplyResources(this.colCurrencyCode, "colCurrencyCode");
            // 
            // colCurrencyDebetAmount
            // 
            this.colCurrencyDebetAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colCurrencyDebetAmount.MaxLength = 15;
            this.colCurrencyDebetAmount.Name = "colCurrencyDebetAmount";
            this.colCurrencyDebetAmount.NamedProperties.Put("EnumerateMethod", "");
            this.colCurrencyDebetAmount.NamedProperties.Put("FieldFlags", "290");
            this.colCurrencyDebetAmount.NamedProperties.Put("Format", "20");
            this.colCurrencyDebetAmount.NamedProperties.Put("LovReference", "");
            this.colCurrencyDebetAmount.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colCurrencyDebetAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.colCurrencyDebetAmount.NamedProperties.Put("SqlColumn", "CURRENCY_DEBET_AMOUNT");
            this.colCurrencyDebetAmount.NamedProperties.Put("ValidateMethod", "");
            this.colCurrencyDebetAmount.Position = 41;
            this.colCurrencyDebetAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.colCurrencyDebetAmount, "colCurrencyDebetAmount");
            // 
            // colCurrencyCreditAmount
            // 
            this.colCurrencyCreditAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colCurrencyCreditAmount.MaxLength = 15;
            this.colCurrencyCreditAmount.Name = "colCurrencyCreditAmount";
            this.colCurrencyCreditAmount.NamedProperties.Put("EnumerateMethod", "");
            this.colCurrencyCreditAmount.NamedProperties.Put("FieldFlags", "290");
            this.colCurrencyCreditAmount.NamedProperties.Put("Format", "20");
            this.colCurrencyCreditAmount.NamedProperties.Put("LovReference", "");
            this.colCurrencyCreditAmount.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colCurrencyCreditAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.colCurrencyCreditAmount.NamedProperties.Put("SqlColumn", "CURRENCY_CREDIT_AMOUNT");
            this.colCurrencyCreditAmount.NamedProperties.Put("ValidateMethod", "");
            this.colCurrencyCreditAmount.Position = 42;
            this.colCurrencyCreditAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.colCurrencyCreditAmount, "colCurrencyCreditAmount");
            // 
            // colCurrencyAmount
            // 
            this.colCurrencyAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colCurrencyAmount.Name = "colCurrencyAmount";
            this.colCurrencyAmount.NamedProperties.Put("EnumerateMethod", "");
            this.colCurrencyAmount.NamedProperties.Put("FieldFlags", "290");
            this.colCurrencyAmount.NamedProperties.Put("Format", "20");
            this.colCurrencyAmount.NamedProperties.Put("LovReference", "");
            this.colCurrencyAmount.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colCurrencyAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.colCurrencyAmount.NamedProperties.Put("SqlColumn", "CURRENCY_AMOUNT");
            this.colCurrencyAmount.NamedProperties.Put("ValidateMethod", "");
            this.colCurrencyAmount.Position = 43;
            this.colCurrencyAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.colCurrencyAmount, "colCurrencyAmount");
            // 
            // colCurrencyRate
            // 
            this.colCurrencyRate.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colCurrencyRate.Name = "colCurrencyRate";
            this.colCurrencyRate.NamedProperties.Put("EnumerateMethod", "");
            this.colCurrencyRate.NamedProperties.Put("FieldFlags", "288");
            this.colCurrencyRate.NamedProperties.Put("LovReference", "");
            this.colCurrencyRate.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colCurrencyRate.NamedProperties.Put("ResizeableChildObject", "");
            this.colCurrencyRate.NamedProperties.Put("SqlColumn", "CURRENCY_RATE");
            this.colCurrencyRate.NamedProperties.Put("ValidateMethod", "");
            this.colCurrencyRate.Position = 44;
            this.colCurrencyRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.colCurrencyRate, "colCurrencyRate");
            // 
            // colnThirdCurrencyRate
            // 
            this.colnThirdCurrencyRate.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.colnThirdCurrencyRate, "colnThirdCurrencyRate");
            this.colnThirdCurrencyRate.Name = "colnThirdCurrencyRate";
            this.colnThirdCurrencyRate.NamedProperties.Put("EnumerateMethod", "");
            this.colnThirdCurrencyRate.NamedProperties.Put("FieldFlags", "256");
            this.colnThirdCurrencyRate.NamedProperties.Put("Format", "20");
            this.colnThirdCurrencyRate.NamedProperties.Put("LovReference", "");
            this.colnThirdCurrencyRate.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colnThirdCurrencyRate.NamedProperties.Put("ResizeableChildObject", "");
            this.colnThirdCurrencyRate.NamedProperties.Put("SqlColumn", "THIRD_CURRENCY_RATE");
            this.colnThirdCurrencyRate.NamedProperties.Put("ValidateMethod", "");
            this.colnThirdCurrencyRate.Position = 45;
            this.colnThirdCurrencyRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // colnThirdCurrencyDebitAmount
            // 
            this.colnThirdCurrencyDebitAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colnThirdCurrencyDebitAmount.Name = "colnThirdCurrencyDebitAmount";
            this.colnThirdCurrencyDebitAmount.NamedProperties.Put("EnumerateMethod", "");
            this.colnThirdCurrencyDebitAmount.NamedProperties.Put("FieldFlags", "288");
            this.colnThirdCurrencyDebitAmount.NamedProperties.Put("Format", "20");
            this.colnThirdCurrencyDebitAmount.NamedProperties.Put("LovReference", "");
            this.colnThirdCurrencyDebitAmount.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colnThirdCurrencyDebitAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.colnThirdCurrencyDebitAmount.NamedProperties.Put("SqlColumn", "THIRD_CURRENCY_DEBIT_AMOUNT");
            this.colnThirdCurrencyDebitAmount.NamedProperties.Put("ValidateMethod", "");
            this.colnThirdCurrencyDebitAmount.Position = 46;
            this.colnThirdCurrencyDebitAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.colnThirdCurrencyDebitAmount, "colnThirdCurrencyDebitAmount");
            // 
            // colnThirdCurrencyCreditAmount
            // 
            this.colnThirdCurrencyCreditAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colnThirdCurrencyCreditAmount.Name = "colnThirdCurrencyCreditAmount";
            this.colnThirdCurrencyCreditAmount.NamedProperties.Put("EnumerateMethod", "");
            this.colnThirdCurrencyCreditAmount.NamedProperties.Put("FieldFlags", "288");
            this.colnThirdCurrencyCreditAmount.NamedProperties.Put("Format", "20");
            this.colnThirdCurrencyCreditAmount.NamedProperties.Put("LovReference", "");
            this.colnThirdCurrencyCreditAmount.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colnThirdCurrencyCreditAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.colnThirdCurrencyCreditAmount.NamedProperties.Put("SqlColumn", "THIRD_CURRENCY_CREDIT_AMOUNT");
            this.colnThirdCurrencyCreditAmount.NamedProperties.Put("ValidateMethod", "");
            this.colnThirdCurrencyCreditAmount.Position = 47;
            this.colnThirdCurrencyCreditAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.colnThirdCurrencyCreditAmount, "colnThirdCurrencyCreditAmount");
            // 
            // colnThirdCurrencyAmount
            // 
            this.colnThirdCurrencyAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colnThirdCurrencyAmount.Name = "colnThirdCurrencyAmount";
            this.colnThirdCurrencyAmount.NamedProperties.Put("EnumerateMethod", "");
            this.colnThirdCurrencyAmount.NamedProperties.Put("FieldFlags", "288");
            this.colnThirdCurrencyAmount.NamedProperties.Put("Format", "20");
            this.colnThirdCurrencyAmount.NamedProperties.Put("LovReference", "");
            this.colnThirdCurrencyAmount.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colnThirdCurrencyAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.colnThirdCurrencyAmount.NamedProperties.Put("SqlColumn", "THIRD_CURRENCY_AMOUNT");
            this.colnThirdCurrencyAmount.NamedProperties.Put("ValidateMethod", "");
            this.colnThirdCurrencyAmount.Position = 48;
            this.colnThirdCurrencyAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.colnThirdCurrencyAmount, "colnThirdCurrencyAmount");
            // 
            // colText
            // 
            this.colText.MaxLength = 200;
            this.colText.Name = "colText";
            this.colText.NamedProperties.Put("EnumerateMethod", "");
            this.colText.NamedProperties.Put("FieldFlags", "290");
            this.colText.NamedProperties.Put("LovReference", "");
            this.colText.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colText.NamedProperties.Put("ResizeableChildObject", "");
            this.colText.NamedProperties.Put("SqlColumn", "TEXT");
            this.colText.NamedProperties.Put("ValidateMethod", "");
            this.colText.Position = 49;
            resources.ApplyResources(this.colText, "colText");
            // 
            // colQuantity
            // 
            this.colQuantity.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colQuantity.Format = "#,##0.00";
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.NamedProperties.Put("EnumerateMethod", "");
            this.colQuantity.NamedProperties.Put("FieldFlags", "290");
            this.colQuantity.NamedProperties.Put("LovReference", "");
            this.colQuantity.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colQuantity.NamedProperties.Put("ResizeableChildObject", "");
            this.colQuantity.NamedProperties.Put("SqlColumn", "QUANTITY");
            this.colQuantity.NamedProperties.Put("ValidateMethod", "");
            this.colQuantity.Position = 50;
            this.colQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.colQuantity, "colQuantity");
            // 
            // colProcess_Code
            // 
            this.colProcess_Code.MaxLength = 10;
            this.colProcess_Code.Name = "colProcess_Code";
            this.colProcess_Code.NamedProperties.Put("EnumerateMethod", "");
            this.colProcess_Code.NamedProperties.Put("FieldFlags", "290");
            this.colProcess_Code.NamedProperties.Put("LovReference", "");
            this.colProcess_Code.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colProcess_Code.NamedProperties.Put("ResizeableChildObject", "");
            this.colProcess_Code.NamedProperties.Put("SqlColumn", "PROCESS_CODE");
            this.colProcess_Code.NamedProperties.Put("ValidateMethod", "");
            this.colProcess_Code.Position = 51;
            resources.ApplyResources(this.colProcess_Code, "colProcess_Code");
            // 
            // colOptional_Code
            // 
            this.colOptional_Code.MaxLength = 20;
            this.colOptional_Code.Name = "colOptional_Code";
            this.colOptional_Code.NamedProperties.Put("EnumerateMethod", "");
            this.colOptional_Code.NamedProperties.Put("FieldFlags", "290");
            this.colOptional_Code.NamedProperties.Put("LovReference", "");
            this.colOptional_Code.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colOptional_Code.NamedProperties.Put("ResizeableChildObject", "");
            this.colOptional_Code.NamedProperties.Put("SqlColumn", "OPTIONAL_CODE");
            this.colOptional_Code.NamedProperties.Put("ValidateMethod", "");
            this.colOptional_Code.Position = 52;
            resources.ApplyResources(this.colOptional_Code, "colOptional_Code");
            // 
            // colProjActivityId
            // 
            this.colProjActivityId.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colProjActivityId.Name = "colProjActivityId";
            this.colProjActivityId.NamedProperties.Put("EnumerateMethod", "");
            this.colProjActivityId.NamedProperties.Put("FieldFlags", "290");
            this.colProjActivityId.NamedProperties.Put("LovReference", "");
            this.colProjActivityId.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colProjActivityId.NamedProperties.Put("ResizeableChildObject", "");
            this.colProjActivityId.NamedProperties.Put("SqlColumn", "PROJECT_ACTIVITY_ID");
            this.colProjActivityId.NamedProperties.Put("ValidateMethod", "");
            this.colProjActivityId.Position = 53;
            resources.ApplyResources(this.colProjActivityId, "colProjActivityId");
            // 
            // colParty_Type_Id
            // 
            this.colParty_Type_Id.MaxLength = 20;
            this.colParty_Type_Id.Name = "colParty_Type_Id";
            this.colParty_Type_Id.NamedProperties.Put("EnumerateMethod", "");
            this.colParty_Type_Id.NamedProperties.Put("FieldFlags", "290");
            this.colParty_Type_Id.NamedProperties.Put("LovReference", "");
            this.colParty_Type_Id.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colParty_Type_Id.NamedProperties.Put("ResizeableChildObject", "");
            this.colParty_Type_Id.NamedProperties.Put("SqlColumn", "PARTY_TYPE_ID");
            this.colParty_Type_Id.NamedProperties.Put("ValidateMethod", "");
            this.colParty_Type_Id.Position = 54;
            resources.ApplyResources(this.colParty_Type_Id, "colParty_Type_Id");
            // 
            // colTrans_Code
            // 
            this.colTrans_Code.Name = "colTrans_Code";
            this.colTrans_Code.NamedProperties.Put("EnumerateMethod", "");
            this.colTrans_Code.NamedProperties.Put("FieldFlags", "290");
            this.colTrans_Code.NamedProperties.Put("LovReference", "");
            this.colTrans_Code.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colTrans_Code.NamedProperties.Put("ResizeableChildObject", "");
            this.colTrans_Code.NamedProperties.Put("SqlColumn", "TRANS_CODE");
            this.colTrans_Code.NamedProperties.Put("ValidateMethod", "");
            this.colTrans_Code.Position = 55;
            resources.ApplyResources(this.colTrans_Code, "colTrans_Code");
            // 
            // colUpdate_Error
            // 
            this.colUpdate_Error.MaxLength = 200;
            this.colUpdate_Error.Name = "colUpdate_Error";
            this.colUpdate_Error.NamedProperties.Put("EnumerateMethod", "");
            this.colUpdate_Error.NamedProperties.Put("FieldFlags", "290");
            this.colUpdate_Error.NamedProperties.Put("LovReference", "");
            this.colUpdate_Error.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colUpdate_Error.NamedProperties.Put("ResizeableChildObject", "");
            this.colUpdate_Error.NamedProperties.Put("SqlColumn", "UPDATE_ERROR");
            this.colUpdate_Error.NamedProperties.Put("ValidateMethod", "");
            this.colUpdate_Error.Position = 56;
            resources.ApplyResources(this.colUpdate_Error, "colUpdate_Error");
            // 
            // colTransfer_Id
            // 
            resources.ApplyResources(this.colTransfer_Id, "colTransfer_Id");
            this.colTransfer_Id.MaxLength = 20;
            this.colTransfer_Id.Name = "colTransfer_Id";
            this.colTransfer_Id.NamedProperties.Put("EnumerateMethod", "");
            this.colTransfer_Id.NamedProperties.Put("FieldFlags", "290");
            this.colTransfer_Id.NamedProperties.Put("LovReference", "");
            this.colTransfer_Id.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colTransfer_Id.NamedProperties.Put("ResizeableChildObject", "");
            this.colTransfer_Id.NamedProperties.Put("SqlColumn", "TRANSFER_ID");
            this.colTransfer_Id.NamedProperties.Put("ValidateMethod", "");
            this.colTransfer_Id.Position = 57;
            // 
            // colCorrected
            // 
            this.colCorrected.Name = "colCorrected";
            this.colCorrected.NamedProperties.Put("EnumerateMethod", "");
            this.colCorrected.NamedProperties.Put("FieldFlags", "288");
            this.colCorrected.NamedProperties.Put("LovReference", "");
            this.colCorrected.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colCorrected.NamedProperties.Put("SqlColumn", "CORRECTED");
            this.colCorrected.NamedProperties.Put("ValidateMethod", "");
            this.colCorrected.Position = 58;
            resources.ApplyResources(this.colCorrected, "colCorrected");
            // 
            // colPeriodical_Allocation
            // 
            this.colPeriodical_Allocation.Name = "colPeriodical_Allocation";
            this.colPeriodical_Allocation.NamedProperties.Put("EnumerateMethod", "");
            this.colPeriodical_Allocation.NamedProperties.Put("FieldFlags", "288");
            this.colPeriodical_Allocation.NamedProperties.Put("LovReference", "");
            this.colPeriodical_Allocation.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colPeriodical_Allocation.NamedProperties.Put("ResizeableChildObject", "");
            this.colPeriodical_Allocation.NamedProperties.Put("SqlColumn", "PERIOD_ALLOCATION_API.ANY_ALLOCATION(COMPANY, VOUCHER_TYPE, VOUCHER_NO, ROW_NO, A" +
                    "CCOUNTING_YEAR)");
            this.colPeriodical_Allocation.NamedProperties.Put("ValidateMethod", "");
            this.colPeriodical_Allocation.Position = 59;
            resources.ApplyResources(this.colPeriodical_Allocation, "colPeriodical_Allocation");
            // 
            // colReferenceSerie
            // 
            this.colReferenceSerie.MaxLength = 50;
            this.colReferenceSerie.Name = "colReferenceSerie";
            this.colReferenceSerie.NamedProperties.Put("EnumerateMethod", "");
            this.colReferenceSerie.NamedProperties.Put("FieldFlags", "290");
            this.colReferenceSerie.NamedProperties.Put("LovReference", "");
            this.colReferenceSerie.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colReferenceSerie.NamedProperties.Put("ResizeableChildObject", "");
            this.colReferenceSerie.NamedProperties.Put("SqlColumn", "REFERENCE_SERIE");
            this.colReferenceSerie.NamedProperties.Put("ValidateMethod", "");
            this.colReferenceSerie.Position = 60;
            resources.ApplyResources(this.colReferenceSerie, "colReferenceSerie");
            // 
            // colReferenceNumber
            // 
            this.colReferenceNumber.MaxLength = 50;
            this.colReferenceNumber.Name = "colReferenceNumber";
            this.colReferenceNumber.NamedProperties.Put("EnumerateMethod", "");
            this.colReferenceNumber.NamedProperties.Put("FieldFlags", "290");
            this.colReferenceNumber.NamedProperties.Put("LovReference", "");
            this.colReferenceNumber.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colReferenceNumber.NamedProperties.Put("ResizeableChildObject", "");
            this.colReferenceNumber.NamedProperties.Put("SqlColumn", "REFERENCE_NUMBER");
            this.colReferenceNumber.NamedProperties.Put("ValidateMethod", "");
            this.colReferenceNumber.Position = 61;
            resources.ApplyResources(this.colReferenceNumber, "colReferenceNumber");
            // 
            // colMultiCompanyId
            // 
            resources.ApplyResources(this.colMultiCompanyId, "colMultiCompanyId");
            this.colMultiCompanyId.Name = "colMultiCompanyId";
            this.colMultiCompanyId.NamedProperties.Put("EnumerateMethod", "");
            this.colMultiCompanyId.NamedProperties.Put("FieldFlags", "256");
            this.colMultiCompanyId.NamedProperties.Put("LovReference", "");
            this.colMultiCompanyId.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colMultiCompanyId.NamedProperties.Put("ResizeableChildObject", "");
            this.colMultiCompanyId.NamedProperties.Put("SqlColumn", "MULTI_COMPANY_ID");
            this.colMultiCompanyId.NamedProperties.Put("ValidateMethod", "");
            this.colMultiCompanyId.Position = 62;
            // 
            // colAutoTaxVouEntry
            // 
            this.colAutoTaxVouEntry.MaxLength = 20;
            this.colAutoTaxVouEntry.Name = "colAutoTaxVouEntry";
            this.colAutoTaxVouEntry.NamedProperties.Put("EnumerateMethod", "");
            this.colAutoTaxVouEntry.NamedProperties.Put("FieldFlags", "288");
            this.colAutoTaxVouEntry.NamedProperties.Put("LovReference", "");
            this.colAutoTaxVouEntry.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colAutoTaxVouEntry.NamedProperties.Put("ResizeableChildObject", "");
            this.colAutoTaxVouEntry.NamedProperties.Put("SqlColumn", "AUTO_TAX_VOU_ENTRY");
            this.colAutoTaxVouEntry.NamedProperties.Put("ValidateMethod", "");
            this.colAutoTaxVouEntry.Position = 63;
            resources.ApplyResources(this.colAutoTaxVouEntry, "colAutoTaxVouEntry");
            // 
            // colsRowNo
            // 
            resources.ApplyResources(this.colsRowNo, "colsRowNo");
            this.colsRowNo.Name = "colsRowNo";
            this.colsRowNo.NamedProperties.Put("EnumerateMethod", "");
            this.colsRowNo.NamedProperties.Put("FieldFlags", "160");
            this.colsRowNo.NamedProperties.Put("LovReference", "");
            this.colsRowNo.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsRowNo.NamedProperties.Put("SqlColumn", "ROW_NO");
            this.colsRowNo.NamedProperties.Put("ValidateMethod", "");
            this.colsRowNo.Position = 64;
            // 
            // menuOperations
            // 
            this.menuOperations.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_Voucher,
            this.menuItem_View,
            this.menuSeparator1,
            this.menuItem_Change});
            this.menuOperations.Name = "menuOperations";
            resources.ApplyResources(this.menuOperations, "menuOperations");
            // 
            // menuItem_Voucher
            // 
            this.menuItem_Voucher.Command = this.menuOperations_menuVoucher__Details___;
            this.menuItem_Voucher.Name = "menuItem_Voucher";
            resources.ApplyResources(this.menuItem_Voucher, "menuItem_Voucher");
            this.menuItem_Voucher.Text = "Voucher &Details...";
            // 
            // menuItem_View
            // 
            this.menuItem_View.Command = this.menuOperations_menuView__Multi_Company_Voucher___;
            this.menuItem_View.Name = "menuItem_View";
            resources.ApplyResources(this.menuItem_View, "menuItem_View");
            this.menuItem_View.Text = "View &Multi Company Voucher...";
            // 
            // menuSeparator1
            // 
            this.menuSeparator1.Name = "menuSeparator1";
            resources.ApplyResources(this.menuSeparator1, "menuSeparator1");
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
            this.menuItem_Voucher_1,
            this.menuItem_View_1,
            this.menuSeparator2,
            this.menuItem_Change_1});
            this.menuTbwMethods.Name = "menuTbwMethods";
            resources.ApplyResources(this.menuTbwMethods, "menuTbwMethods");
            // 
            // menuItem_Voucher_1
            // 
            this.menuItem_Voucher_1.Command = this.menuTbwMethods_menuVoucher__Details___;
            this.menuItem_Voucher_1.Name = "menuItem_Voucher_1";
            resources.ApplyResources(this.menuItem_Voucher_1, "menuItem_Voucher_1");
            this.menuItem_Voucher_1.Text = "Voucher &Details...";
            // 
            // menuItem_View_1
            // 
            this.menuItem_View_1.Command = this.menuTbwMethods_menuView__Multi_Company_Voucher___;
            this.menuItem_View_1.Name = "menuItem_View_1";
            resources.ApplyResources(this.menuItem_View_1, "menuItem_View_1");
            this.menuItem_View_1.Text = "View &Multi Company Voucher...";
            // 
            // menuSeparator2
            // 
            this.menuSeparator2.Name = "menuSeparator2";
            resources.ApplyResources(this.menuSeparator2, "menuSeparator2");
            // 
            // menuItem_Change_1
            // 
            this.menuItem_Change_1.Command = this.menuTbwMethods_menuChange__Company___;
            this.menuItem_Change_1.Name = "menuItem_Change_1";
            resources.ApplyResources(this.menuItem_Change_1, "menuItem_Change_1");
            this.menuItem_Change_1.Text = "Change &Company...";
            // 
            // tbwAccrulQueryVoucherRow
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colCompany);
            this.Controls.Add(this.colVoucherType);
            this.Controls.Add(this.colFunctionGroup);
            this.Controls.Add(this.colVoucherNo);
            this.Controls.Add(this.colVoucherDate);
            this.Controls.Add(this.colAccountingYear);
            this.Controls.Add(this.colAccountingPeriod);
            this.Controls.Add(this.colnYearPeriodKey);
            this.Controls.Add(this.colCorrection);
            this.Controls.Add(this.colMultiCompanyVoucher);
            this.Controls.Add(this.colsParentCompany);
            this.Controls.Add(this.colsVoucherTypeRef);
            this.Controls.Add(this.colnVoucherNoRef);
            this.Controls.Add(this.colnAccountingYearRef);
            this.Controls.Add(this.colAccount);
            this.Controls.Add(this.colsAccountDesc);
            this.Controls.Add(this.colCodeB);
            this.Controls.Add(this.colsCodeBDesc);
            this.Controls.Add(this.colCodeC);
            this.Controls.Add(this.colsCodeCDesc);
            this.Controls.Add(this.colCodeD);
            this.Controls.Add(this.colsCodeDDesc);
            this.Controls.Add(this.colCodeE);
            this.Controls.Add(this.colsCodeEDesc);
            this.Controls.Add(this.colCodeF);
            this.Controls.Add(this.colsCodeFDesc);
            this.Controls.Add(this.colCodeG);
            this.Controls.Add(this.colsCodeGDesc);
            this.Controls.Add(this.colCodeH);
            this.Controls.Add(this.colsCodeHDesc);
            this.Controls.Add(this.colCodeI);
            this.Controls.Add(this.colsCodeIDesc);
            this.Controls.Add(this.colCodeJ);
            this.Controls.Add(this.colsCodeJDesc);
            this.Controls.Add(this.colDebetAmount);
            this.Controls.Add(this.colCreditAmount);
            this.Controls.Add(this.colAmount);
            this.Controls.Add(this.colCurrencyCode);
            this.Controls.Add(this.colCurrencyDebetAmount);
            this.Controls.Add(this.colCurrencyCreditAmount);
            this.Controls.Add(this.colCurrencyAmount);
            this.Controls.Add(this.colCurrencyRate);
            this.Controls.Add(this.colnThirdCurrencyRate);
            this.Controls.Add(this.colnThirdCurrencyDebitAmount);
            this.Controls.Add(this.colnThirdCurrencyCreditAmount);
            this.Controls.Add(this.colnThirdCurrencyAmount);
            this.Controls.Add(this.colText);
            this.Controls.Add(this.colQuantity);
            this.Controls.Add(this.colProcess_Code);
            this.Controls.Add(this.colOptional_Code);
            this.Controls.Add(this.colProjActivityId);
            this.Controls.Add(this.colParty_Type_Id);
            this.Controls.Add(this.colTrans_Code);
            this.Controls.Add(this.colUpdate_Error);
            this.Controls.Add(this.colTransfer_Id);
            this.Controls.Add(this.colCorrected);
            this.Controls.Add(this.colPeriodical_Allocation);
            this.Controls.Add(this.colReferenceSerie);
            this.Controls.Add(this.colReferenceNumber);
            this.Controls.Add(this.colMultiCompanyId);
            this.Controls.Add(this.colAutoTaxVouEntry);
            this.Controls.Add(this.colsRowNo);
            this.Controls.Add(this.ToolBar);
            this.Controls.Add(this.StatusBar);
            this.Name = "tbwAccrulQueryVoucherRow";
            this.NamedProperties.Put("DefaultOrderBy", "VOUCHER_TYPE, VOUCHER_NO");
            this.NamedProperties.Put("DefaultWhere", "VOUCHER_UPDATED_DB=\'N\'\r\n\r\n");
            this.NamedProperties.Put("LogicalUnit", "VoucherRow");
            this.NamedProperties.Put("PackageName", "VOUCHER_ROW_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "0");
            this.NamedProperties.Put("SourceFlags", "16385");
            this.NamedProperties.Put("Warning", "FALSE");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.NamedProperties.Put("ViewName", "ACCRUL_VOUCHER_ROW_QRY");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tbwAccrulQueryVoucherRow_WindowActions);
            this.Controls.SetChildIndex(this.StatusBar, 0);
            this.Controls.SetChildIndex(this.ToolBar, 0);
            this.Controls.SetChildIndex(this.colsRowNo, 0);
            this.Controls.SetChildIndex(this.colAutoTaxVouEntry, 0);
            this.Controls.SetChildIndex(this.colMultiCompanyId, 0);
            this.Controls.SetChildIndex(this.colReferenceNumber, 0);
            this.Controls.SetChildIndex(this.colReferenceSerie, 0);
            this.Controls.SetChildIndex(this.colPeriodical_Allocation, 0);
            this.Controls.SetChildIndex(this.colCorrected, 0);
            this.Controls.SetChildIndex(this.colTransfer_Id, 0);
            this.Controls.SetChildIndex(this.colUpdate_Error, 0);
            this.Controls.SetChildIndex(this.colTrans_Code, 0);
            this.Controls.SetChildIndex(this.colParty_Type_Id, 0);
            this.Controls.SetChildIndex(this.colProjActivityId, 0);
            this.Controls.SetChildIndex(this.colOptional_Code, 0);
            this.Controls.SetChildIndex(this.colProcess_Code, 0);
            this.Controls.SetChildIndex(this.colQuantity, 0);
            this.Controls.SetChildIndex(this.colText, 0);
            this.Controls.SetChildIndex(this.colnThirdCurrencyAmount, 0);
            this.Controls.SetChildIndex(this.colnThirdCurrencyCreditAmount, 0);
            this.Controls.SetChildIndex(this.colnThirdCurrencyDebitAmount, 0);
            this.Controls.SetChildIndex(this.colnThirdCurrencyRate, 0);
            this.Controls.SetChildIndex(this.colCurrencyRate, 0);
            this.Controls.SetChildIndex(this.colCurrencyAmount, 0);
            this.Controls.SetChildIndex(this.colCurrencyCreditAmount, 0);
            this.Controls.SetChildIndex(this.colCurrencyDebetAmount, 0);
            this.Controls.SetChildIndex(this.colCurrencyCode, 0);
            this.Controls.SetChildIndex(this.colAmount, 0);
            this.Controls.SetChildIndex(this.colCreditAmount, 0);
            this.Controls.SetChildIndex(this.colDebetAmount, 0);
            this.Controls.SetChildIndex(this.colsCodeJDesc, 0);
            this.Controls.SetChildIndex(this.colCodeJ, 0);
            this.Controls.SetChildIndex(this.colsCodeIDesc, 0);
            this.Controls.SetChildIndex(this.colCodeI, 0);
            this.Controls.SetChildIndex(this.colsCodeHDesc, 0);
            this.Controls.SetChildIndex(this.colCodeH, 0);
            this.Controls.SetChildIndex(this.colsCodeGDesc, 0);
            this.Controls.SetChildIndex(this.colCodeG, 0);
            this.Controls.SetChildIndex(this.colsCodeFDesc, 0);
            this.Controls.SetChildIndex(this.colCodeF, 0);
            this.Controls.SetChildIndex(this.colsCodeEDesc, 0);
            this.Controls.SetChildIndex(this.colCodeE, 0);
            this.Controls.SetChildIndex(this.colsCodeDDesc, 0);
            this.Controls.SetChildIndex(this.colCodeD, 0);
            this.Controls.SetChildIndex(this.colsCodeCDesc, 0);
            this.Controls.SetChildIndex(this.colCodeC, 0);
            this.Controls.SetChildIndex(this.colsCodeBDesc, 0);
            this.Controls.SetChildIndex(this.colCodeB, 0);
            this.Controls.SetChildIndex(this.colsAccountDesc, 0);
            this.Controls.SetChildIndex(this.colAccount, 0);
            this.Controls.SetChildIndex(this.colnAccountingYearRef, 0);
            this.Controls.SetChildIndex(this.colnVoucherNoRef, 0);
            this.Controls.SetChildIndex(this.colsVoucherTypeRef, 0);
            this.Controls.SetChildIndex(this.colsParentCompany, 0);
            this.Controls.SetChildIndex(this.colMultiCompanyVoucher, 0);
            this.Controls.SetChildIndex(this.colCorrection, 0);
            this.Controls.SetChildIndex(this.colnYearPeriodKey, 0);
            this.Controls.SetChildIndex(this.colAccountingPeriod, 0);
            this.Controls.SetChildIndex(this.colAccountingYear, 0);
            this.Controls.SetChildIndex(this.colVoucherDate, 0);
            this.Controls.SetChildIndex(this.colVoucherNo, 0);
            this.Controls.SetChildIndex(this.colFunctionGroup, 0);
            this.Controls.SetChildIndex(this.colVoucherType, 0);
            this.Controls.SetChildIndex(this.colCompany, 0);
            this.Controls.SetChildIndex(this.@__colObjversion, 0);
            this.Controls.SetChildIndex(this.@__colObjid, 0);
            this.ToolBar.ResumeLayout(false);
            this.ToolBar.PerformLayout();
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

        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menuVoucher__Details___;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menuView__Multi_Company_Voucher___;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menuChange__Company___;
        public Fnd.Windows.Forms.FndCommand menuOperations_menuVoucher__Details___;
        public Fnd.Windows.Forms.FndCommand menuOperations_menuView__Multi_Company_Voucher___;
        public Fnd.Windows.Forms.FndCommand menuOperations_menuChange__Company___;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuOperations;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Voucher;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_View;
        protected Fnd.Windows.Forms.FndToolStripSeparator menuSeparator1;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTbwMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Voucher_1;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_View_1;
        protected Fnd.Windows.Forms.FndToolStripSeparator menuSeparator2;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change_1;
	}
}
