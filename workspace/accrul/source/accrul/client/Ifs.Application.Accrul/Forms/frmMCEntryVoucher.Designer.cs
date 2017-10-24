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
	
	public partial class frmMCEntryVoucher
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		protected cBackgroundText labeldfsCompany;
		public cDataField dfsCompany;
		protected cBackgroundText labeldfdVoucherDate;
		// Bug 77430, Begin
		public cDataField dfdVoucherDate;
		protected cBackgroundText labeldfsUserGroup;
		// Bug 77430, Begin
		public cDataField dfsUserGroup;
		protected cBackgroundText labelccsVoucherType;
		// Bug 77430, Begin
		public cRecListDataField ccsVoucherType;
		protected cBackgroundText labeldfsVoucherTypeDescription;
		public cDataField dfsVoucherTypeDescription;
		protected cBackgroundText labeldfnVoucherNo;
		public cDataField dfnVoucherNo;
		protected cBackgroundText labeldfnAccountingYear;
		public cDataField dfnAccountingYear;
		protected cBackgroundText labeldfnAccountingPeriod;
		public cDataField dfnAccountingPeriod;
		public cDataField dfsPeriodDescription;
		// Bug 77430, Begin, changed F1 property Column Name
		// Bug 77430, Begin, changed the message action
		public cCheckBox cbFreeText;
		// Bug 77430, End
		protected cBackgroundText labeldfsTextId;
		public cDataField dfsTextId;
		protected cBackgroundText labeldfsRowText;
		// Bug 72229, Begin, Changed the Field length
		public cDataField dfsRowText;
		// Bug 72229, End
		protected SalGroupBox gbAdditional_Information;
		protected cBackgroundText labeldfdDateReg;
		public cDataField dfdDateReg;
		protected cBackgroundText labeldfsUserId;
		public cDataField dfsUserId;
		protected cBackgroundText labeldfsUpdateError;
		public cDataField dfsUpdateError;
		// ! ! ----- Hiden fields
		public cDataField dfsVoucherGroup;
		protected cBackgroundText labeldfsCurrencyType;
		public cDataField dfsCurrencyType;
		protected cBackgroundText labeldfsCurrencyCode;
		public cDataField dfsCurrencyCode;
		public cDataField dfnCurrencyRate;
		public cDataField dfnConversionFactor;
		// Bug 77430, Removed Background Text and dfsVoucherText
		protected cBackgroundText labeldfnCurrencyBalance;
		public cDataField dfnCurrencyBalance;
		protected cBackgroundText labeldfnBalance;
		public cDataField dfnBalance;
		protected cBackgroundText labeldfsRowGroupValidation;
		public cDataField dfsRowGroupValidation;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMCEntryVoucher));
            this.menuTblMethods_menuChange__Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuOperations_menu_Notes___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuOperations_menuChange__Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuFrmMethods_menu_Notes___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuFrmMethods_menuChange__Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.labeldfsCompany = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsCompany = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfdVoucherDate = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfdVoucherDate = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsUserGroup = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsUserGroup = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelccsVoucherType = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.ccsVoucherType = new Ifs.Fnd.ApplicationForms.cRecListDataField();
            this.labeldfsVoucherTypeDescription = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsVoucherTypeDescription = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfnVoucherNo = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfnVoucherNo = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfnAccountingYear = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfnAccountingYear = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfnAccountingPeriod = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfnAccountingPeriod = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsPeriodDescription = new Ifs.Fnd.ApplicationForms.cDataField();
            this.cbFreeText = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.labeldfsTextId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsTextId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsRowText = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsRowText = new Ifs.Fnd.ApplicationForms.cDataField();
            this.gbAdditional_Information = new PPJ.Runtime.Windows.SalGroupBox();
            this.labeldfdDateReg = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfdDateReg = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsUserId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsUserId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsUpdateError = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsUpdateError = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsVoucherGroup = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsCurrencyType = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsCurrencyType = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsCurrencyCode = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsCurrencyCode = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfnCurrencyRate = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfnConversionFactor = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfnCurrencyBalance = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfnCurrencyBalance = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfnBalance = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfnBalance = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsRowGroupValidation = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsRowGroupValidation = new Ifs.Fnd.ApplicationForms.cDataField();
            this.menuFrmMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem__Notes = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuSeparator1 = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.menuItem_Change = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuOperations = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuSeparator2 = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.menuItem__Notes_1 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuSeparator3 = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.menuItem_Change_1 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuTblMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_Change_2 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuFrmMethods.SuspendLayout();
            this.menuOperations.SuspendLayout();
            this.menuTblMethods.SuspendLayout();
            this.SuspendLayout();
            // 
            // picTab
            // 
            resources.ApplyResources(this.picTab, "picTab");
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuFrmMethods_menu_Notes___);
            this.commandManager.Commands.Add(this.menuFrmMethods_menuChange__Company___);
            this.commandManager.Commands.Add(this.menuOperations_menu_Notes___);
            this.commandManager.Commands.Add(this.menuOperations_menuChange__Company___);
            this.commandManager.Commands.Add(this.menuTblMethods_menuChange__Company___);
            this.commandManager.ContextMenus.Add(this.menuFrmMethods);
            this.commandManager.ContextMenus.Add(this.menuOperations);
            this.commandManager.ContextMenus.Add(this.menuTblMethods);
            this.commandManager.ImageList = null;
            // 
            // menuTblMethods_menuChange__Company___
            // 
            resources.ApplyResources(this.menuTblMethods_menuChange__Company___, "menuTblMethods_menuChange__Company___");
            this.menuTblMethods_menuChange__Company___.Name = "menuTblMethods_menuChange__Company___";
            this.menuTblMethods_menuChange__Company___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Change_2_Execute);
            this.menuTblMethods_menuChange__Company___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Change_2_Inquire);
            // 
            // menuOperations_menu_Notes___
            // 
            resources.ApplyResources(this.menuOperations_menu_Notes___, "menuOperations_menu_Notes___");
            this.menuOperations_menu_Notes___.Name = "menuOperations_menu_Notes___";
            this.menuOperations_menu_Notes___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Notes_1_Execute);
            this.menuOperations_menu_Notes___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Notes_1_Inquire);
            // 
            // menuOperations_menuChange__Company___
            // 
            resources.ApplyResources(this.menuOperations_menuChange__Company___, "menuOperations_menuChange__Company___");
            this.menuOperations_menuChange__Company___.Name = "menuOperations_menuChange__Company___";
            this.menuOperations_menuChange__Company___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Change_1_Execute);
            this.menuOperations_menuChange__Company___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Change_1_Inquire);
            // 
            // menuFrmMethods_menu_Notes___
            // 
            resources.ApplyResources(this.menuFrmMethods_menu_Notes___, "menuFrmMethods_menu_Notes___");
            this.menuFrmMethods_menu_Notes___.Name = "menuFrmMethods_menu_Notes___";
            this.menuFrmMethods_menu_Notes___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Notes_Execute);
            this.menuFrmMethods_menu_Notes___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Notes_Inquire);
            // 
            // menuFrmMethods_menuChange__Company___
            // 
            resources.ApplyResources(this.menuFrmMethods_menuChange__Company___, "menuFrmMethods_menuChange__Company___");
            this.menuFrmMethods_menuChange__Company___.Name = "menuFrmMethods_menuChange__Company___";
            this.menuFrmMethods_menuChange__Company___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Change_Execute);
            this.menuFrmMethods_menuChange__Company___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Change_Inquire);
            // 
            // labeldfsCompany
            // 
            resources.ApplyResources(this.labeldfsCompany, "labeldfsCompany");
            this.labeldfsCompany.Name = "labeldfsCompany";
            // 
            // dfsCompany
            // 
            this.dfsCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsCompany, "dfsCompany");
            this.dfsCompany.Name = "dfsCompany";
            this.dfsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.dfsCompany.NamedProperties.Put("FieldFlags", "67");
            this.dfsCompany.NamedProperties.Put("LovReference", "");
            this.dfsCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.dfsCompany.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfdVoucherDate
            // 
            resources.ApplyResources(this.labeldfdVoucherDate, "labeldfdVoucherDate");
            this.labeldfdVoucherDate.Name = "labeldfdVoucherDate";
            // 
            // dfdVoucherDate
            // 
            this.dfdVoucherDate.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.dfdVoucherDate.Format = "d";
            resources.ApplyResources(this.dfdVoucherDate, "dfdVoucherDate");
            this.dfdVoucherDate.Name = "dfdVoucherDate";
            this.dfdVoucherDate.NamedProperties.Put("EnumerateMethod", "");
            this.dfdVoucherDate.NamedProperties.Put("FieldFlags", "295");
            this.dfdVoucherDate.NamedProperties.Put("LovReference", "");
            this.dfdVoucherDate.NamedProperties.Put("ResizeableChildObject", "");
            this.dfdVoucherDate.NamedProperties.Put("SqlColumn", "VOUCHER_DATE");
            this.dfdVoucherDate.NamedProperties.Put("ValidateMethod", "");
            this.dfdVoucherDate.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfdVoucherDate_WindowActions);
            // 
            // labeldfsUserGroup
            // 
            resources.ApplyResources(this.labeldfsUserGroup, "labeldfsUserGroup");
            this.labeldfsUserGroup.Name = "labeldfsUserGroup";
            // 
            // dfsUserGroup
            // 
            this.dfsUserGroup.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsUserGroup, "dfsUserGroup");
            this.dfsUserGroup.Name = "dfsUserGroup";
            this.dfsUserGroup.NamedProperties.Put("EnumerateMethod", "");
            this.dfsUserGroup.NamedProperties.Put("FieldFlags", "295");
            this.dfsUserGroup.NamedProperties.Put("LovReference", "USER_GROUP_MEMBER_FINANCE4(COMPANY, USERID)");
            this.dfsUserGroup.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsUserGroup.NamedProperties.Put("SqlColumn", "USER_GROUP");
            this.dfsUserGroup.NamedProperties.Put("ValidateMethod", "");
            this.dfsUserGroup.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsUserGroup_WindowActions);
            // 
            // labelccsVoucherType
            // 
            resources.ApplyResources(this.labelccsVoucherType, "labelccsVoucherType");
            this.labelccsVoucherType.Name = "labelccsVoucherType";
            // 
            // ccsVoucherType
            // 
            this.ccsVoucherType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.ccsVoucherType, "ccsVoucherType");
            this.ccsVoucherType.Name = "ccsVoucherType";
            this.ccsVoucherType.NamedProperties.Put("EnumerateMethod", "");
            this.ccsVoucherType.NamedProperties.Put("FieldFlags", "99");
            this.ccsVoucherType.NamedProperties.Put("Format", "9");
            this.ccsVoucherType.NamedProperties.Put("LovReference", "VOUCHER_TYPE_USER_GROUP3(COMPANY,ACCOUNTING_YEAR,USER_GROUP)");
            this.ccsVoucherType.NamedProperties.Put("ResizeableChildObject", "");
            this.ccsVoucherType.NamedProperties.Put("SqlColumn", "VOUCHER_TYPE");
            this.ccsVoucherType.NamedProperties.Put("ValidateMethod", "");
            this.ccsVoucherType.NamedProperties.Put("XDataLength", "3");
            this.ccsVoucherType.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.ccsVoucherType_WindowActions);
            // 
            // labeldfsVoucherTypeDescription
            // 
            resources.ApplyResources(this.labeldfsVoucherTypeDescription, "labeldfsVoucherTypeDescription");
            this.labeldfsVoucherTypeDescription.Name = "labeldfsVoucherTypeDescription";
            // 
            // dfsVoucherTypeDescription
            // 
            resources.ApplyResources(this.dfsVoucherTypeDescription, "dfsVoucherTypeDescription");
            this.dfsVoucherTypeDescription.Name = "dfsVoucherTypeDescription";
            this.dfsVoucherTypeDescription.NamedProperties.Put("EnumerateMethod", "");
            this.dfsVoucherTypeDescription.NamedProperties.Put("LovReference", "");
            this.dfsVoucherTypeDescription.NamedProperties.Put("ParentName", "ccsVoucherType");
            this.dfsVoucherTypeDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsVoucherTypeDescription.NamedProperties.Put("SqlColumn", "DESC_VOUCHER_TYPE");
            this.dfsVoucherTypeDescription.NamedProperties.Put("ValidateMethod", "");
            this.dfsVoucherTypeDescription.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsVoucherTypeDescription_WindowActions);
            // 
            // labeldfnVoucherNo
            // 
            resources.ApplyResources(this.labeldfnVoucherNo, "labeldfnVoucherNo");
            this.labeldfnVoucherNo.Name = "labeldfnVoucherNo";
            // 
            // dfnVoucherNo
            // 
            this.dfnVoucherNo.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfnVoucherNo, "dfnVoucherNo");
            this.dfnVoucherNo.Name = "dfnVoucherNo";
            this.dfnVoucherNo.NamedProperties.Put("EnumerateMethod", "");
            this.dfnVoucherNo.NamedProperties.Put("FieldFlags", "163");
            this.dfnVoucherNo.NamedProperties.Put("LovReference", "");
            this.dfnVoucherNo.NamedProperties.Put("ParentName", "ccsVoucherType");
            this.dfnVoucherNo.NamedProperties.Put("ResizeableChildObject", "");
            this.dfnVoucherNo.NamedProperties.Put("SqlColumn", "VOUCHER_NO");
            this.dfnVoucherNo.NamedProperties.Put("ValidateMethod", "");
            this.dfnVoucherNo.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfnVoucherNo_WindowActions);
            // 
            // labeldfnAccountingYear
            // 
            resources.ApplyResources(this.labeldfnAccountingYear, "labeldfnAccountingYear");
            this.labeldfnAccountingYear.Name = "labeldfnAccountingYear";
            // 
            // dfnAccountingYear
            // 
            this.dfnAccountingYear.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfnAccountingYear, "dfnAccountingYear");
            this.dfnAccountingYear.Name = "dfnAccountingYear";
            this.dfnAccountingYear.NamedProperties.Put("EnumerateMethod", "");
            this.dfnAccountingYear.NamedProperties.Put("FieldFlags", "163");
            this.dfnAccountingYear.NamedProperties.Put("LovReference", "");
            this.dfnAccountingYear.NamedProperties.Put("ParentName", "ccsVoucherType");
            this.dfnAccountingYear.NamedProperties.Put("ResizeableChildObject", "");
            this.dfnAccountingYear.NamedProperties.Put("SqlColumn", "ACCOUNTING_YEAR");
            this.dfnAccountingYear.NamedProperties.Put("ValidateMethod", "");
            this.dfnAccountingYear.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfnAccountingYear_WindowActions);
            // 
            // labeldfnAccountingPeriod
            // 
            resources.ApplyResources(this.labeldfnAccountingPeriod, "labeldfnAccountingPeriod");
            this.labeldfnAccountingPeriod.Name = "labeldfnAccountingPeriod";
            // 
            // dfnAccountingPeriod
            // 
            this.dfnAccountingPeriod.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.dfnAccountingPeriod.Format = "00";
            resources.ApplyResources(this.dfnAccountingPeriod, "dfnAccountingPeriod");
            this.dfnAccountingPeriod.Name = "dfnAccountingPeriod";
            this.dfnAccountingPeriod.NamedProperties.Put("EnumerateMethod", "");
            this.dfnAccountingPeriod.NamedProperties.Put("FieldFlags", "291");
            this.dfnAccountingPeriod.NamedProperties.Put("LovReference", "");
            this.dfnAccountingPeriod.NamedProperties.Put("ResizeableChildObject", "");
            this.dfnAccountingPeriod.NamedProperties.Put("SqlColumn", "ACCOUNTING_PERIOD");
            this.dfnAccountingPeriod.NamedProperties.Put("ValidateMethod", "");
            this.dfnAccountingPeriod.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfnAccountingPeriod_WindowActions);
            // 
            // dfsPeriodDescription
            // 
            resources.ApplyResources(this.dfsPeriodDescription, "dfsPeriodDescription");
            this.dfsPeriodDescription.Name = "dfsPeriodDescription";
            this.dfsPeriodDescription.NamedProperties.Put("EnumerateMethod", "");
            this.dfsPeriodDescription.NamedProperties.Put("LovReference", "");
            this.dfsPeriodDescription.NamedProperties.Put("ParentName", "dfnAccountingPeriod");
            this.dfsPeriodDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsPeriodDescription.NamedProperties.Put("SqlColumn", "ACCOUNTING_PERIOD_API.Get_Period_Description(COMPANY,ACCOUNTING_YEAR,ACCOUNTING_P" +
                    "ERIOD)");
            this.dfsPeriodDescription.NamedProperties.Put("ValidateMethod", "");
            // 
            // cbFreeText
            // 
            resources.ApplyResources(this.cbFreeText, "cbFreeText");
            this.cbFreeText.Name = "cbFreeText";
            this.cbFreeText.NamedProperties.Put("DataType", "5");
            this.cbFreeText.NamedProperties.Put("EnumerateMethod", "");
            this.cbFreeText.NamedProperties.Put("FieldFlags", "288");
            this.cbFreeText.NamedProperties.Put("LovReference", "");
            this.cbFreeText.NamedProperties.Put("ResizeableChildObject", "");
            this.cbFreeText.NamedProperties.Put("SqlColumn", "Voucher_Note_API.Check_Note_Exist(COMPANY,ACCOUNTING_YEAR,VOUCHER_TYPE,VOUCHER_NO" +
                    ")");
            this.cbFreeText.NamedProperties.Put("ValidateMethod", "");
            this.cbFreeText.NamedProperties.Put("XDataLength", "5");
            this.cbFreeText.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cbFreeText_WindowActions);
            // 
            // labeldfsTextId
            // 
            resources.ApplyResources(this.labeldfsTextId, "labeldfsTextId");
            this.labeldfsTextId.Name = "labeldfsTextId";
            // 
            // dfsTextId
            // 
            this.dfsTextId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsTextId, "dfsTextId");
            this.dfsTextId.Name = "dfsTextId";
            this.dfsTextId.NamedProperties.Put("EnumerateMethod", "");
            this.dfsTextId.NamedProperties.Put("FieldFlags", "262");
            this.dfsTextId.NamedProperties.Put("LovReference", "VOUCHER_TEXT(COMPANY)");
            this.dfsTextId.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsTextId.NamedProperties.Put("SqlColumn", "TEXT_ID");
            this.dfsTextId.NamedProperties.Put("ValidateMethod", "");
            this.dfsTextId.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsTextId_WindowActions);
            // 
            // labeldfsRowText
            // 
            resources.ApplyResources(this.labeldfsRowText, "labeldfsRowText");
            this.labeldfsRowText.Name = "labeldfsRowText";
            // 
            // dfsRowText
            // 
            resources.ApplyResources(this.dfsRowText, "dfsRowText");
            this.dfsRowText.Name = "dfsRowText";
            this.dfsRowText.NamedProperties.Put("EnumerateMethod", "");
            this.dfsRowText.NamedProperties.Put("FieldFlags", "294");
            this.dfsRowText.NamedProperties.Put("LovReference", "");
            this.dfsRowText.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsRowText.NamedProperties.Put("SqlColumn", "VOUCHER_TEXT");
            this.dfsRowText.NamedProperties.Put("ValidateMethod", "");
            // 
            // gbAdditional_Information
            // 
            this.gbAdditional_Information.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.gbAdditional_Information, "MCHeader");
            resources.ApplyResources(this.gbAdditional_Information, "gbAdditional_Information");
            this.gbAdditional_Information.Name = "gbAdditional_Information";
            this.gbAdditional_Information.TabStop = false;
            // 
            // labeldfdDateReg
            // 
            resources.ApplyResources(this.labeldfdDateReg, "labeldfdDateReg");
            this.labeldfdDateReg.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeldfdDateReg, "MCHeader");
            this.labeldfdDateReg.Name = "labeldfdDateReg";
            // 
            // dfdDateReg
            // 
            this.picTab.SetControlTabPages(this.dfdDateReg, "MCHeader");
            this.dfdDateReg.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.dfdDateReg.Format = "d";
            resources.ApplyResources(this.dfdDateReg, "dfdDateReg");
            this.dfdDateReg.Name = "dfdDateReg";
            this.dfdDateReg.NamedProperties.Put("EnumerateMethod", "");
            this.dfdDateReg.NamedProperties.Put("FieldFlags", "288");
            this.dfdDateReg.NamedProperties.Put("LovReference", "");
            this.dfdDateReg.NamedProperties.Put("ResizeableChildObject", "");
            this.dfdDateReg.NamedProperties.Put("SqlColumn", "DATE_REG");
            this.dfdDateReg.NamedProperties.Put("ValidateMethod", "");
            this.dfdDateReg.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfdDateReg_WindowActions);
            // 
            // labeldfsUserId
            // 
            resources.ApplyResources(this.labeldfsUserId, "labeldfsUserId");
            this.labeldfsUserId.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeldfsUserId, "MCHeader");
            this.labeldfsUserId.Name = "labeldfsUserId";
            // 
            // dfsUserId
            // 
            this.dfsUserId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.picTab.SetControlTabPages(this.dfsUserId, "MCHeader");
            resources.ApplyResources(this.dfsUserId, "dfsUserId");
            this.dfsUserId.Name = "dfsUserId";
            this.dfsUserId.NamedProperties.Put("EnumerateMethod", "");
            this.dfsUserId.NamedProperties.Put("FieldFlags", "288");
            this.dfsUserId.NamedProperties.Put("LovReference", "");
            this.dfsUserId.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsUserId.NamedProperties.Put("SqlColumn", "USERID");
            this.dfsUserId.NamedProperties.Put("ValidateMethod", "");
            this.dfsUserId.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsUserId_WindowActions);
            // 
            // labeldfsUpdateError
            // 
            resources.ApplyResources(this.labeldfsUpdateError, "labeldfsUpdateError");
            this.labeldfsUpdateError.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeldfsUpdateError, "MCHeader");
            this.labeldfsUpdateError.Name = "labeldfsUpdateError";
            // 
            // dfsUpdateError
            // 
            this.picTab.SetControlTabPages(this.dfsUpdateError, "MCHeader");
            resources.ApplyResources(this.dfsUpdateError, "dfsUpdateError");
            this.dfsUpdateError.Name = "dfsUpdateError";
            this.dfsUpdateError.NamedProperties.Put("EnumerateMethod", "");
            this.dfsUpdateError.NamedProperties.Put("FieldFlags", "294");
            this.dfsUpdateError.NamedProperties.Put("LovReference", "");
            this.dfsUpdateError.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsUpdateError.NamedProperties.Put("SqlColumn", "UPDATE_ERROR");
            this.dfsUpdateError.NamedProperties.Put("ValidateMethod", "");
            this.dfsUpdateError.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsUpdateError_WindowActions);
            // 
            // dfsVoucherGroup
            // 
            resources.ApplyResources(this.dfsVoucherGroup, "dfsVoucherGroup");
            this.dfsVoucherGroup.Name = "dfsVoucherGroup";
            this.dfsVoucherGroup.NamedProperties.Put("EnumerateMethod", "");
            this.dfsVoucherGroup.NamedProperties.Put("LovReference", "");
            this.dfsVoucherGroup.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsVoucherGroup.NamedProperties.Put("SqlColumn", "Voucher_Type_API.Get_Voucher_Group(COMPANY,VOUCHER_TYPE)");
            this.dfsVoucherGroup.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsCurrencyType
            // 
            resources.ApplyResources(this.labeldfsCurrencyType, "labeldfsCurrencyType");
            this.labeldfsCurrencyType.Name = "labeldfsCurrencyType";
            // 
            // dfsCurrencyType
            // 
            this.dfsCurrencyType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsCurrencyType, "dfsCurrencyType");
            this.dfsCurrencyType.Name = "dfsCurrencyType";
            this.dfsCurrencyType.NamedProperties.Put("EnumerateMethod", "");
            this.dfsCurrencyType.NamedProperties.Put("FieldFlags", "261");
            this.dfsCurrencyType.NamedProperties.Put("LovReference", "CURRENCY_TYPE(COMPANY)");
            this.dfsCurrencyType.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsCurrencyType.NamedProperties.Put("SqlColumn", "CURRENCY_TYPE");
            this.dfsCurrencyType.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsCurrencyCode
            // 
            resources.ApplyResources(this.labeldfsCurrencyCode, "labeldfsCurrencyCode");
            this.labeldfsCurrencyCode.Name = "labeldfsCurrencyCode";
            // 
            // dfsCurrencyCode
            // 
            this.dfsCurrencyCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsCurrencyCode, "dfsCurrencyCode");
            this.dfsCurrencyCode.Name = "dfsCurrencyCode";
            this.dfsCurrencyCode.NamedProperties.Put("EnumerateMethod", "");
            this.dfsCurrencyCode.NamedProperties.Put("LovReference", "CURRENCY_RATE1(COMPANY,CURRENCY_TYPE)");
            this.dfsCurrencyCode.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsCurrencyCode.NamedProperties.Put("SqlColumn", "CURRENCY_CODE");
            this.dfsCurrencyCode.NamedProperties.Put("ValidateMethod", "");
            // 
            // dfnCurrencyRate
            // 
            this.dfnCurrencyRate.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfnCurrencyRate, "dfnCurrencyRate");
            this.dfnCurrencyRate.Name = "dfnCurrencyRate";
            this.dfnCurrencyRate.NamedProperties.Put("EnumerateMethod", "");
            this.dfnCurrencyRate.NamedProperties.Put("LovReference", "");
            this.dfnCurrencyRate.NamedProperties.Put("ResizeableChildObject", "");
            this.dfnCurrencyRate.NamedProperties.Put("SqlColumn", "CURRENCY_RATE");
            this.dfnCurrencyRate.NamedProperties.Put("ValidateMethod", "");
            // 
            // dfnConversionFactor
            // 
            this.dfnConversionFactor.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfnConversionFactor, "dfnConversionFactor");
            this.dfnConversionFactor.Name = "dfnConversionFactor";
            this.dfnConversionFactor.NamedProperties.Put("EnumerateMethod", "");
            this.dfnConversionFactor.NamedProperties.Put("LovReference", "");
            this.dfnConversionFactor.NamedProperties.Put("ResizeableChildObject", "");
            this.dfnConversionFactor.NamedProperties.Put("SqlColumn", "CONVERTION_FACTOR");
            this.dfnConversionFactor.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfnCurrencyBalance
            // 
            resources.ApplyResources(this.labeldfnCurrencyBalance, "labeldfnCurrencyBalance");
            this.labeldfnCurrencyBalance.Name = "labeldfnCurrencyBalance";
            // 
            // dfnCurrencyBalance
            // 
            this.dfnCurrencyBalance.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfnCurrencyBalance, "dfnCurrencyBalance");
            this.dfnCurrencyBalance.Name = "dfnCurrencyBalance";
            this.dfnCurrencyBalance.NamedProperties.Put("EnumerateMethod", "");
            this.dfnCurrencyBalance.NamedProperties.Put("FieldFlags", "292");
            this.dfnCurrencyBalance.NamedProperties.Put("Format", "20");
            this.dfnCurrencyBalance.NamedProperties.Put("LovReference", "");
            this.dfnCurrencyBalance.NamedProperties.Put("ResizeableChildObject", "");
            this.dfnCurrencyBalance.NamedProperties.Put("SqlColumn", "CURRENCY_BALANCE");
            this.dfnCurrencyBalance.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfnBalance
            // 
            resources.ApplyResources(this.labeldfnBalance, "labeldfnBalance");
            this.labeldfnBalance.Name = "labeldfnBalance";
            // 
            // dfnBalance
            // 
            this.dfnBalance.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfnBalance, "dfnBalance");
            this.dfnBalance.Name = "dfnBalance";
            this.dfnBalance.NamedProperties.Put("EnumerateMethod", "");
            this.dfnBalance.NamedProperties.Put("FieldFlags", "292");
            this.dfnBalance.NamedProperties.Put("Format", "20");
            this.dfnBalance.NamedProperties.Put("LovReference", "");
            this.dfnBalance.NamedProperties.Put("ResizeableChildObject", "");
            this.dfnBalance.NamedProperties.Put("SqlColumn", "BALANCE");
            this.dfnBalance.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsRowGroupValidation
            // 
            resources.ApplyResources(this.labeldfsRowGroupValidation, "labeldfsRowGroupValidation");
            this.labeldfsRowGroupValidation.Name = "labeldfsRowGroupValidation";
            // 
            // dfsRowGroupValidation
            // 
            this.dfsRowGroupValidation.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.dfsRowGroupValidation, "dfsRowGroupValidation");
            this.dfsRowGroupValidation.Name = "dfsRowGroupValidation";
            this.dfsRowGroupValidation.NamedProperties.Put("EnumerateMethod", "");
            this.dfsRowGroupValidation.NamedProperties.Put("LovReference", "");
            this.dfsRowGroupValidation.NamedProperties.Put("ParentName", "ccsVoucherType");
            this.dfsRowGroupValidation.NamedProperties.Put("SqlColumn", "ROW_GROUP_VALIDATION");
            this.dfsRowGroupValidation.NamedProperties.Put("ValidateMethod", "");
            this.dfsRowGroupValidation.ReadOnly = true;
            // 
            // menuFrmMethods
            // 
            this.menuFrmMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem__Notes,
            this.menuSeparator1,
            this.menuItem_Change});
            this.menuFrmMethods.Name = "menuFrmMethods";
            resources.ApplyResources(this.menuFrmMethods, "menuFrmMethods");
            // 
            // menuItem__Notes
            // 
            this.menuItem__Notes.Command = this.menuFrmMethods_menu_Notes___;
            this.menuItem__Notes.Name = "menuItem__Notes";
            resources.ApplyResources(this.menuItem__Notes, "menuItem__Notes");
            this.menuItem__Notes.Text = "&Notes...";
            // 
            // menuSeparator1
            // 
            this.menuSeparator1.Name = "menuSeparator1";
            resources.ApplyResources(this.menuSeparator1, "menuSeparator1");
            // 
            // menuItem_Change
            // 
            this.menuItem_Change.Command = this.menuFrmMethods_menuChange__Company___;
            this.menuItem_Change.Name = "menuItem_Change";
            resources.ApplyResources(this.menuItem_Change, "menuItem_Change");
            this.menuItem_Change.Text = "Change &Company...";
            // 
            // menuOperations
            // 
            this.menuOperations.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSeparator2,
            this.menuItem__Notes_1,
            this.menuSeparator3,
            this.menuItem_Change_1});
            this.menuOperations.Name = "menuOperations";
            resources.ApplyResources(this.menuOperations, "menuOperations");
            // 
            // menuSeparator2
            // 
            this.menuSeparator2.Name = "menuSeparator2";
            resources.ApplyResources(this.menuSeparator2, "menuSeparator2");
            // 
            // menuItem__Notes_1
            // 
            this.menuItem__Notes_1.Command = this.menuOperations_menu_Notes___;
            this.menuItem__Notes_1.Name = "menuItem__Notes_1";
            resources.ApplyResources(this.menuItem__Notes_1, "menuItem__Notes_1");
            this.menuItem__Notes_1.Text = "&Notes...";
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
            // menuTblMethods
            // 
            this.menuTblMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_Change_2});
            this.menuTblMethods.Name = "menuTblMethods";
            resources.ApplyResources(this.menuTblMethods, "menuTblMethods");
            // 
            // menuItem_Change_2
            // 
            this.menuItem_Change_2.Command = this.menuTblMethods_menuChange__Company___;
            this.menuItem_Change_2.Name = "menuItem_Change_2";
            resources.ApplyResources(this.menuItem_Change_2, "menuItem_Change_2");
            this.menuItem_Change_2.Text = "Change &Company...";
            // 
            // frmMCEntryVoucher
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.dfsRowGroupValidation);
            this.Controls.Add(this.dfnBalance);
            this.Controls.Add(this.dfnCurrencyBalance);
            this.Controls.Add(this.dfnConversionFactor);
            this.Controls.Add(this.dfnCurrencyRate);
            this.Controls.Add(this.dfsCurrencyCode);
            this.Controls.Add(this.dfsCurrencyType);
            this.Controls.Add(this.dfsVoucherGroup);
            this.Controls.Add(this.dfsUpdateError);
            this.Controls.Add(this.dfsUserId);
            this.Controls.Add(this.dfdDateReg);
            this.Controls.Add(this.dfsRowText);
            this.Controls.Add(this.dfsTextId);
            this.Controls.Add(this.cbFreeText);
            this.Controls.Add(this.dfsPeriodDescription);
            this.Controls.Add(this.dfnAccountingPeriod);
            this.Controls.Add(this.dfnAccountingYear);
            this.Controls.Add(this.dfnVoucherNo);
            this.Controls.Add(this.dfsVoucherTypeDescription);
            this.Controls.Add(this.ccsVoucherType);
            this.Controls.Add(this.dfsUserGroup);
            this.Controls.Add(this.dfdVoucherDate);
            this.Controls.Add(this.dfsCompany);
            this.Controls.Add(this.labeldfsRowGroupValidation);
            this.Controls.Add(this.labeldfnBalance);
            this.Controls.Add(this.labeldfnCurrencyBalance);
            this.Controls.Add(this.labeldfsCurrencyCode);
            this.Controls.Add(this.labeldfsCurrencyType);
            this.Controls.Add(this.labeldfdDateReg);
            this.Controls.Add(this.labeldfsUserId);
            this.Controls.Add(this.labeldfsUpdateError);
            this.Controls.Add(this.labeldfsRowText);
            this.Controls.Add(this.labeldfsTextId);
            this.Controls.Add(this.labeldfnAccountingPeriod);
            this.Controls.Add(this.labeldfnAccountingYear);
            this.Controls.Add(this.labeldfnVoucherNo);
            this.Controls.Add(this.labeldfsVoucherTypeDescription);
            this.Controls.Add(this.labelccsVoucherType);
            this.Controls.Add(this.labeldfsUserGroup);
            this.Controls.Add(this.labeldfdVoucherDate);
            this.Controls.Add(this.labeldfsCompany);
            this.Controls.Add(this.gbAdditional_Information);
            this.Name = "frmMCEntryVoucher";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "COMPANY = :global.company");
            this.NamedProperties.Put("LogicalUnit", "MultiCompanyVoucher");
            this.NamedProperties.Put("PackageName", "MULTI_COMPANY_VOUCHER_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "4545");
            this.NamedProperties.Put("ViewName", "MULTI_COMPANY_VOUCHER2");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.frmMCEntryVoucher_WindowActions);
            this.Controls.SetChildIndex(this.gbAdditional_Information, 0);
            this.Controls.SetChildIndex(this.picTab, 0);
            this.Controls.SetChildIndex(this.labeldfsCompany, 0);
            this.Controls.SetChildIndex(this.labeldfdVoucherDate, 0);
            this.Controls.SetChildIndex(this.labeldfsUserGroup, 0);
            this.Controls.SetChildIndex(this.labelccsVoucherType, 0);
            this.Controls.SetChildIndex(this.labeldfsVoucherTypeDescription, 0);
            this.Controls.SetChildIndex(this.labeldfnVoucherNo, 0);
            this.Controls.SetChildIndex(this.labeldfnAccountingYear, 0);
            this.Controls.SetChildIndex(this.labeldfnAccountingPeriod, 0);
            this.Controls.SetChildIndex(this.labeldfsTextId, 0);
            this.Controls.SetChildIndex(this.labeldfsRowText, 0);
            this.Controls.SetChildIndex(this.labeldfsUpdateError, 0);
            this.Controls.SetChildIndex(this.labeldfsUserId, 0);
            this.Controls.SetChildIndex(this.labeldfdDateReg, 0);
            this.Controls.SetChildIndex(this.labeldfsCurrencyType, 0);
            this.Controls.SetChildIndex(this.labeldfsCurrencyCode, 0);
            this.Controls.SetChildIndex(this.labeldfnCurrencyBalance, 0);
            this.Controls.SetChildIndex(this.labeldfnBalance, 0);
            this.Controls.SetChildIndex(this.labeldfsRowGroupValidation, 0);
            this.Controls.SetChildIndex(this.dfsCompany, 0);
            this.Controls.SetChildIndex(this.dfdVoucherDate, 0);
            this.Controls.SetChildIndex(this.dfsUserGroup, 0);
            this.Controls.SetChildIndex(this.ccsVoucherType, 0);
            this.Controls.SetChildIndex(this.dfsVoucherTypeDescription, 0);
            this.Controls.SetChildIndex(this.dfnVoucherNo, 0);
            this.Controls.SetChildIndex(this.dfnAccountingYear, 0);
            this.Controls.SetChildIndex(this.dfnAccountingPeriod, 0);
            this.Controls.SetChildIndex(this.dfsPeriodDescription, 0);
            this.Controls.SetChildIndex(this.cbFreeText, 0);
            this.Controls.SetChildIndex(this.dfsTextId, 0);
            this.Controls.SetChildIndex(this.dfsRowText, 0);
            this.Controls.SetChildIndex(this.dfdDateReg, 0);
            this.Controls.SetChildIndex(this.dfsUserId, 0);
            this.Controls.SetChildIndex(this.dfsUpdateError, 0);
            this.Controls.SetChildIndex(this.dfsVoucherGroup, 0);
            this.Controls.SetChildIndex(this.dfsCurrencyType, 0);
            this.Controls.SetChildIndex(this.dfsCurrencyCode, 0);
            this.Controls.SetChildIndex(this.dfnCurrencyRate, 0);
            this.Controls.SetChildIndex(this.dfnConversionFactor, 0);
            this.Controls.SetChildIndex(this.dfnCurrencyBalance, 0);
            this.Controls.SetChildIndex(this.dfnBalance, 0);
            this.Controls.SetChildIndex(this.dfsRowGroupValidation, 0);
            this.menuFrmMethods.ResumeLayout(false);
            this.menuOperations.ResumeLayout(false);
            this.menuTblMethods.ResumeLayout(false);
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

        public Fnd.Windows.Forms.FndCommand menuTblMethods_menuChange__Company___;
        public Fnd.Windows.Forms.FndCommand menuOperations_menu_Notes___;
        public Fnd.Windows.Forms.FndCommand menuOperations_menuChange__Company___;
        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menu_Notes___;
        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menuChange__Company___;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuFrmMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Notes;
        protected Fnd.Windows.Forms.FndToolStripSeparator menuSeparator1;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuOperations;
        protected Fnd.Windows.Forms.FndToolStripSeparator menuSeparator2;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Notes_1;
        protected Fnd.Windows.Forms.FndToolStripSeparator menuSeparator3;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change_1;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTblMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change_2;
	}
}
