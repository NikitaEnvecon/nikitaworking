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
	
	public partial class tbwQueryVoucher
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cColumn colCompany;
		public cColumn colVoucherStatus;
		// Bug 72589 Begin,  Changed Key Flags in F1 Properties to Parent Key
		public cColumn colVoucherType;
		// Bug 72589 End
		public cColumn colsFunctionGroup;
		// Bug 72589 Begin,  Changed Key Flags in F1 Properties to Parent Key
		public cColumn colVoucherNo;
		// Bug 72589 End
		public cColumn colVoucherDate;
		// Bug 72589 Begin,  Changed Key Flags in F1 Properties to Parent Key
		public cColumn colAccountingYear;
		// Bug 72589 End
		public cColumn colAccountingPeriod;
		public cColumn colDateReg;
		public cColumn colUserGroup;
		public cColumn colUserid;
		public cColumn coldApprovalDate;
		public cColumn colsApprovedByUserGroup;
		public cColumn colsApprovedByUserid;
		public cColumn colsVoucherText2;
		public cColumn colUpdateError;
		public cColumn colTransferId;
		// Bug 77430, Begin, changed the f1 property Column Name, and changed the Check and Uncheck values
		public cColumn colText;
		// Bug 77430, End
		// Bug 77430, Removed colVoucherText
		public cColumn colInterimVoucher;
		public cCheckBoxColumn colMultiCompanyVoucher;
		public cColumn colMultiCompanyId;
		public cColumn colVoucherTypeRef;
		public cColumn colVoucherNoRef;
		public cColumn colAccntYearRef;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwQueryVoucher));
            this.menuTbwMethods_menuVoucher__Rows___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_menuVoucher__Details___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_menuView__Multi_Company_Voucher___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_menuChange__Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_menu_Notes___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuOperations_menuVoucher__Rows___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuOperations_menuVoucher__Details___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuOperations_menuView__Multi_Company_Voucher___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuOperations_menuChange__Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuOperations_menu_Notes___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.colCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colVoucherStatus = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colVoucherType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsFunctionGroup = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colVoucherNo = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colVoucherDate = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colAccountingYear = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colAccountingPeriod = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colDateReg = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colUserGroup = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colUserid = new Ifs.Fnd.ApplicationForms.cColumn();
            this.coldApprovalDate = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsApprovedByUserGroup = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsApprovedByUserid = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsVoucherText2 = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colUpdateError = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colTransferId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colText = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colInterimVoucher = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colMultiCompanyVoucher = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.colMultiCompanyId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colVoucherTypeRef = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colVoucherNoRef = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colAccntYearRef = new Ifs.Fnd.ApplicationForms.cColumn();
            this.menuOperations = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_Voucher = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem_Voucher_1 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem_View = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuSeparator1 = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.menuItem_Change = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem__Notes = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuTbwMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_Voucher_2 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem_Voucher_3 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem_View_1 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuSeparator2 = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.menuItem_Change_1 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem__Notes_1 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuOperations.SuspendLayout();
            this.menuTbwMethods.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuOperations_menuVoucher__Rows___);
            this.commandManager.Commands.Add(this.menuOperations_menuVoucher__Details___);
            this.commandManager.Commands.Add(this.menuOperations_menuView__Multi_Company_Voucher___);
            this.commandManager.Commands.Add(this.menuOperations_menuChange__Company___);
            this.commandManager.Commands.Add(this.menuOperations_menu_Notes___);
            this.commandManager.Commands.Add(this.menuTbwMethods_menuVoucher__Rows___);
            this.commandManager.Commands.Add(this.menuTbwMethods_menuVoucher__Details___);
            this.commandManager.Commands.Add(this.menuTbwMethods_menuView__Multi_Company_Voucher___);
            this.commandManager.Commands.Add(this.menuTbwMethods_menuChange__Company___);
            this.commandManager.Commands.Add(this.menuTbwMethods_menu_Notes___);
            this.commandManager.ContextMenus.Add(this.menuOperations);
            this.commandManager.ContextMenus.Add(this.menuTbwMethods);
            // 
            // menuTbwMethods_menuVoucher__Rows___
            // 
            resources.ApplyResources(this.menuTbwMethods_menuVoucher__Rows___, "menuTbwMethods_menuVoucher__Rows___");
            this.menuTbwMethods_menuVoucher__Rows___.Name = "menuTbwMethods_menuVoucher__Rows___";
            this.menuTbwMethods_menuVoucher__Rows___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Voucher_2_Execute);
            this.menuTbwMethods_menuVoucher__Rows___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Voucher_2_Inquire);
            // 
            // menuTbwMethods_menuVoucher__Details___
            // 
            resources.ApplyResources(this.menuTbwMethods_menuVoucher__Details___, "menuTbwMethods_menuVoucher__Details___");
            this.menuTbwMethods_menuVoucher__Details___.Name = "menuTbwMethods_menuVoucher__Details___";
            this.menuTbwMethods_menuVoucher__Details___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Voucher_3_Execute);
            this.menuTbwMethods_menuVoucher__Details___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Voucher_3_Inquire);
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
            // menuTbwMethods_menu_Notes___
            // 
            resources.ApplyResources(this.menuTbwMethods_menu_Notes___, "menuTbwMethods_menu_Notes___");
            this.menuTbwMethods_menu_Notes___.Name = "menuTbwMethods_menu_Notes___";
            this.menuTbwMethods_menu_Notes___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Notes_1_Execute);
            this.menuTbwMethods_menu_Notes___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Notes_1_Inquire);
            // 
            // menuOperations_menuVoucher__Rows___
            // 
            resources.ApplyResources(this.menuOperations_menuVoucher__Rows___, "menuOperations_menuVoucher__Rows___");
            this.menuOperations_menuVoucher__Rows___.Name = "menuOperations_menuVoucher__Rows___";
            this.menuOperations_menuVoucher__Rows___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Voucher_Execute);
            this.menuOperations_menuVoucher__Rows___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Voucher_Inquire);
            // 
            // menuOperations_menuVoucher__Details___
            // 
            resources.ApplyResources(this.menuOperations_menuVoucher__Details___, "menuOperations_menuVoucher__Details___");
            this.menuOperations_menuVoucher__Details___.Name = "menuOperations_menuVoucher__Details___";
            this.menuOperations_menuVoucher__Details___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Voucher_1_Execute);
            this.menuOperations_menuVoucher__Details___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Voucher_1_Inquire);
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
            // menuOperations_menu_Notes___
            // 
            resources.ApplyResources(this.menuOperations_menu_Notes___, "menuOperations_menu_Notes___");
            this.menuOperations_menu_Notes___.Name = "menuOperations_menu_Notes___";
            this.menuOperations_menu_Notes___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Notes_Execute);
            this.menuOperations_menu_Notes___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Notes_Inquire);
            // 
            // colCompany
            // 
            resources.ApplyResources(this.colCompany, "colCompany");
            this.colCompany.Name = "colCompany";
            this.colCompany.NamedProperties.Put("EnumerateMethod", "");
            this.colCompany.NamedProperties.Put("FieldFlags", "67");
            this.colCompany.NamedProperties.Put("LovReference", "");
            this.colCompany.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.colCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.colCompany.NamedProperties.Put("ValidateMethod", "");
            this.colCompany.Position = 3;
            // 
            // colVoucherStatus
            // 
            this.colVoucherStatus.Name = "colVoucherStatus";
            this.colVoucherStatus.NamedProperties.Put("EnumerateMethod", "");
            this.colVoucherStatus.NamedProperties.Put("FieldFlags", "290");
            this.colVoucherStatus.NamedProperties.Put("LovReference", "");
            this.colVoucherStatus.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colVoucherStatus.NamedProperties.Put("ResizeableChildObject", "");
            this.colVoucherStatus.NamedProperties.Put("SqlColumn", "VOUCHER_STATUS");
            this.colVoucherStatus.NamedProperties.Put("ValidateMethod", "");
            this.colVoucherStatus.Position = 4;
            resources.ApplyResources(this.colVoucherStatus, "colVoucherStatus");
            // 
            // colVoucherType
            // 
            this.colVoucherType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colVoucherType.Name = "colVoucherType";
            this.colVoucherType.NamedProperties.Put("EnumerateMethod", "");
            this.colVoucherType.NamedProperties.Put("FieldFlags", "99");
            this.colVoucherType.NamedProperties.Put("LovReference", "VOUCHER_TYPE(COMPANY)");
            this.colVoucherType.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colVoucherType.NamedProperties.Put("ResizeableChildObject", "");
            this.colVoucherType.NamedProperties.Put("SqlColumn", "VOUCHER_TYPE");
            this.colVoucherType.NamedProperties.Put("ValidateMethod", "");
            this.colVoucherType.Position = 5;
            resources.ApplyResources(this.colVoucherType, "colVoucherType");
            // 
            // colsFunctionGroup
            // 
            this.colsFunctionGroup.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsFunctionGroup.MaxLength = 20;
            this.colsFunctionGroup.Name = "colsFunctionGroup";
            this.colsFunctionGroup.NamedProperties.Put("EnumerateMethod", "");
            this.colsFunctionGroup.NamedProperties.Put("FieldFlags", "256");
            this.colsFunctionGroup.NamedProperties.Put("LovReference", "");
            this.colsFunctionGroup.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsFunctionGroup.NamedProperties.Put("ResizeableChildObject", "");
            this.colsFunctionGroup.NamedProperties.Put("SqlColumn", "FUNCTION_GROUP");
            this.colsFunctionGroup.NamedProperties.Put("ValidateMethod", "");
            this.colsFunctionGroup.Position = 6;
            resources.ApplyResources(this.colsFunctionGroup, "colsFunctionGroup");
            // 
            // colVoucherNo
            // 
            this.colVoucherNo.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colVoucherNo.Name = "colVoucherNo";
            this.colVoucherNo.NamedProperties.Put("EnumerateMethod", "");
            this.colVoucherNo.NamedProperties.Put("FieldFlags", "162");
            this.colVoucherNo.NamedProperties.Put("LovReference", "");
            this.colVoucherNo.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colVoucherNo.NamedProperties.Put("ResizeableChildObject", "");
            this.colVoucherNo.NamedProperties.Put("SqlColumn", "VOUCHER_NO");
            this.colVoucherNo.NamedProperties.Put("ValidateMethod", "");
            this.colVoucherNo.Position = 7;
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
            this.colVoucherDate.NamedProperties.Put("ResizeableChildObject", "");
            this.colVoucherDate.NamedProperties.Put("SqlColumn", "VOUCHER_DATE");
            this.colVoucherDate.NamedProperties.Put("ValidateMethod", "");
            this.colVoucherDate.Position = 8;
            resources.ApplyResources(this.colVoucherDate, "colVoucherDate");
            // 
            // colAccountingYear
            // 
            this.colAccountingYear.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colAccountingYear.Name = "colAccountingYear";
            this.colAccountingYear.NamedProperties.Put("EnumerateMethod", "");
            this.colAccountingYear.NamedProperties.Put("FieldFlags", "98");
            this.colAccountingYear.NamedProperties.Put("LovReference", "");
            this.colAccountingYear.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colAccountingYear.NamedProperties.Put("ResizeableChildObject", "");
            this.colAccountingYear.NamedProperties.Put("SqlColumn", "ACCOUNTING_YEAR");
            this.colAccountingYear.NamedProperties.Put("ValidateMethod", "");
            this.colAccountingYear.Position = 9;
            resources.ApplyResources(this.colAccountingYear, "colAccountingYear");
            // 
            // colAccountingPeriod
            // 
            this.colAccountingPeriod.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colAccountingPeriod.Name = "colAccountingPeriod";
            this.colAccountingPeriod.NamedProperties.Put("EnumerateMethod", "");
            this.colAccountingPeriod.NamedProperties.Put("FieldFlags", "290");
            this.colAccountingPeriod.NamedProperties.Put("LovReference", "");
            this.colAccountingPeriod.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colAccountingPeriod.NamedProperties.Put("ResizeableChildObject", "");
            this.colAccountingPeriod.NamedProperties.Put("SqlColumn", "ACCOUNTING_PERIOD");
            this.colAccountingPeriod.NamedProperties.Put("ValidateMethod", "");
            this.colAccountingPeriod.Position = 10;
            resources.ApplyResources(this.colAccountingPeriod, "colAccountingPeriod");
            // 
            // colDateReg
            // 
            this.colDateReg.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.colDateReg.Format = "d";
            this.colDateReg.Name = "colDateReg";
            this.colDateReg.NamedProperties.Put("EnumerateMethod", "");
            this.colDateReg.NamedProperties.Put("FieldFlags", "290");
            this.colDateReg.NamedProperties.Put("LovReference", "");
            this.colDateReg.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colDateReg.NamedProperties.Put("ResizeableChildObject", "");
            this.colDateReg.NamedProperties.Put("SqlColumn", "DATE_REG");
            this.colDateReg.NamedProperties.Put("ValidateMethod", "");
            this.colDateReg.Position = 11;
            resources.ApplyResources(this.colDateReg, "colDateReg");
            // 
            // colUserGroup
            // 
            this.colUserGroup.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colUserGroup.MaxLength = 30;
            this.colUserGroup.Name = "colUserGroup";
            this.colUserGroup.NamedProperties.Put("EnumerateMethod", "");
            this.colUserGroup.NamedProperties.Put("FieldFlags", "290");
            this.colUserGroup.NamedProperties.Put("LovReference", "USER_GROUP_FINANCE(COMPANY)");
            this.colUserGroup.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colUserGroup.NamedProperties.Put("ResizeableChildObject", "");
            this.colUserGroup.NamedProperties.Put("SqlColumn", "ENTERED_BY_USER_GROUP");
            this.colUserGroup.NamedProperties.Put("ValidateMethod", "");
            this.colUserGroup.Position = 12;
            resources.ApplyResources(this.colUserGroup, "colUserGroup");
            // 
            // colUserid
            // 
            this.colUserid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colUserid.Name = "colUserid";
            this.colUserid.NamedProperties.Put("EnumerateMethod", "");
            this.colUserid.NamedProperties.Put("FieldFlags", "290");
            this.colUserid.NamedProperties.Put("LovReference", "");
            this.colUserid.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colUserid.NamedProperties.Put("ResizeableChildObject", "");
            this.colUserid.NamedProperties.Put("SqlColumn", "USERID");
            this.colUserid.NamedProperties.Put("ValidateMethod", "");
            this.colUserid.Position = 13;
            resources.ApplyResources(this.colUserid, "colUserid");
            // 
            // coldApprovalDate
            // 
            this.coldApprovalDate.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.coldApprovalDate.Format = "d";
            this.coldApprovalDate.Name = "coldApprovalDate";
            this.coldApprovalDate.NamedProperties.Put("EnumerateMethod", "");
            this.coldApprovalDate.NamedProperties.Put("FieldFlags", "294");
            this.coldApprovalDate.NamedProperties.Put("LovReference", "");
            this.coldApprovalDate.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.coldApprovalDate.NamedProperties.Put("ResizeableChildObject", "");
            this.coldApprovalDate.NamedProperties.Put("SqlColumn", "APPROVAL_DATE");
            this.coldApprovalDate.NamedProperties.Put("ValidateMethod", "");
            this.coldApprovalDate.Position = 14;
            resources.ApplyResources(this.coldApprovalDate, "coldApprovalDate");
            // 
            // colsApprovedByUserGroup
            // 
            this.colsApprovedByUserGroup.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsApprovedByUserGroup.MaxLength = 30;
            this.colsApprovedByUserGroup.Name = "colsApprovedByUserGroup";
            this.colsApprovedByUserGroup.NamedProperties.Put("EnumerateMethod", "");
            this.colsApprovedByUserGroup.NamedProperties.Put("FieldFlags", "294");
            this.colsApprovedByUserGroup.NamedProperties.Put("LovReference", "USER_GROUP_FINANCE(COMPANY)");
            this.colsApprovedByUserGroup.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsApprovedByUserGroup.NamedProperties.Put("ResizeableChildObject", "");
            this.colsApprovedByUserGroup.NamedProperties.Put("SqlColumn", "APPROVED_BY_USER_GROUP");
            this.colsApprovedByUserGroup.NamedProperties.Put("ValidateMethod", "");
            this.colsApprovedByUserGroup.Position = 15;
            resources.ApplyResources(this.colsApprovedByUserGroup, "colsApprovedByUserGroup");
            // 
            // colsApprovedByUserid
            // 
            this.colsApprovedByUserid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsApprovedByUserid.MaxLength = 30;
            this.colsApprovedByUserid.Name = "colsApprovedByUserid";
            this.colsApprovedByUserid.NamedProperties.Put("EnumerateMethod", "");
            this.colsApprovedByUserid.NamedProperties.Put("FieldFlags", "294");
            this.colsApprovedByUserid.NamedProperties.Put("LovReference", "");
            this.colsApprovedByUserid.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsApprovedByUserid.NamedProperties.Put("ResizeableChildObject", "");
            this.colsApprovedByUserid.NamedProperties.Put("SqlColumn", "APPROVED_BY_USERID");
            this.colsApprovedByUserid.NamedProperties.Put("ValidateMethod", "");
            this.colsApprovedByUserid.Position = 16;
            resources.ApplyResources(this.colsApprovedByUserid, "colsApprovedByUserid");
            // 
            // colsVoucherText2
            // 
            this.colsVoucherText2.MaxLength = 2000;
            this.colsVoucherText2.Name = "colsVoucherText2";
            this.colsVoucherText2.NamedProperties.Put("EnumerateMethod", "");
            this.colsVoucherText2.NamedProperties.Put("FieldFlags", "288");
            this.colsVoucherText2.NamedProperties.Put("LovReference", "");
            this.colsVoucherText2.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsVoucherText2.NamedProperties.Put("ResizeableChildObject", "");
            this.colsVoucherText2.NamedProperties.Put("SqlColumn", "VOUCHER_TEXT2");
            this.colsVoucherText2.NamedProperties.Put("ValidateMethod", "");
            this.colsVoucherText2.Position = 17;
            resources.ApplyResources(this.colsVoucherText2, "colsVoucherText2");
            // 
            // colUpdateError
            // 
            this.colUpdateError.Name = "colUpdateError";
            this.colUpdateError.NamedProperties.Put("EnumerateMethod", "");
            this.colUpdateError.NamedProperties.Put("FieldFlags", "290");
            this.colUpdateError.NamedProperties.Put("LovReference", "");
            this.colUpdateError.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colUpdateError.NamedProperties.Put("ResizeableChildObject", "");
            this.colUpdateError.NamedProperties.Put("SqlColumn", "UPDATE_ERROR");
            this.colUpdateError.NamedProperties.Put("ValidateMethod", "");
            this.colUpdateError.Position = 18;
            resources.ApplyResources(this.colUpdateError, "colUpdateError");
            // 
            // colTransferId
            // 
            resources.ApplyResources(this.colTransferId, "colTransferId");
            this.colTransferId.Name = "colTransferId";
            this.colTransferId.NamedProperties.Put("EnumerateMethod", "");
            this.colTransferId.NamedProperties.Put("FieldFlags", "258");
            this.colTransferId.NamedProperties.Put("LovReference", "");
            this.colTransferId.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colTransferId.NamedProperties.Put("ResizeableChildObject", "");
            this.colTransferId.NamedProperties.Put("SqlColumn", "TRANSFER_ID");
            this.colTransferId.NamedProperties.Put("ValidateMethod", "");
            this.colTransferId.Position = 19;
            // 
            // colText
            // 
            this.colText.CellType = PPJ.Runtime.Windows.CellType.CheckBox;
            this.colText.CheckBox.CheckedValue = "TRUE";
            this.colText.CheckBox.IgnoreCase = true;
            this.colText.CheckBox.UncheckedValue = "FALSE";
            resources.ApplyResources(this.colText, "colText");
            this.colText.MaxLength = 5;
            this.colText.Name = "colText";
            this.colText.NamedProperties.Put("EnumerateMethod", "");
            this.colText.NamedProperties.Put("FieldFlags", "258");
            this.colText.NamedProperties.Put("LovReference", "");
            this.colText.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colText.NamedProperties.Put("ResizeableChildObject", "");
            this.colText.NamedProperties.Put("SqlColumn", "Voucher_Note_API.Check_Note_Exist(COMPANY,ACCOUNTING_YEAR,VOUCHER_TYPE,VOUCHER_NO" +
                    ")");
            this.colText.NamedProperties.Put("ValidateMethod", "");
            this.colText.Position = 20;
            this.colText.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colText_WindowActions);
            // 
            // colInterimVoucher
            // 
            this.colInterimVoucher.CellType = PPJ.Runtime.Windows.CellType.CheckBox;
            this.colInterimVoucher.CheckBox.CheckedValue = "Y";
            this.colInterimVoucher.CheckBox.IgnoreCase = true;
            this.colInterimVoucher.CheckBox.UncheckedValue = "N";
            resources.ApplyResources(this.colInterimVoucher, "colInterimVoucher");
            this.colInterimVoucher.Name = "colInterimVoucher";
            this.colInterimVoucher.NamedProperties.Put("EnumerateMethod", "");
            this.colInterimVoucher.NamedProperties.Put("FieldFlags", "290");
            this.colInterimVoucher.NamedProperties.Put("LovReference", "");
            this.colInterimVoucher.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colInterimVoucher.NamedProperties.Put("ResizeableChildObject", "");
            this.colInterimVoucher.NamedProperties.Put("SqlColumn", "INTERIM_VOUCHER");
            this.colInterimVoucher.NamedProperties.Put("ValidateMethod", "");
            this.colInterimVoucher.Position = 21;
            // 
            // colMultiCompanyVoucher
            // 
            this.colMultiCompanyVoucher.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colMultiCompanyVoucher.MaxLength = 2000;
            this.colMultiCompanyVoucher.Name = "colMultiCompanyVoucher";
            this.colMultiCompanyVoucher.NamedProperties.Put("EnumerateMethod", "");
            this.colMultiCompanyVoucher.NamedProperties.Put("FieldFlags", "304");
            this.colMultiCompanyVoucher.NamedProperties.Put("LovReference", "");
            this.colMultiCompanyVoucher.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colMultiCompanyVoucher.NamedProperties.Put("ResizeableChildObject", "");
            this.colMultiCompanyVoucher.NamedProperties.Put("SqlColumn", "VOUCHER_API.Is_Multi_Company_Voucher(COMPANY,VOUCHER_TYPE, ACCOUNTING_YEAR,VOUCHE" +
                    "R_NO)");
            this.colMultiCompanyVoucher.NamedProperties.Put("ValidateMethod", "");
            this.colMultiCompanyVoucher.Position = 22;
            resources.ApplyResources(this.colMultiCompanyVoucher, "colMultiCompanyVoucher");
            // 
            // colMultiCompanyId
            // 
            this.colMultiCompanyId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.colMultiCompanyId, "colMultiCompanyId");
            this.colMultiCompanyId.MaxLength = 20;
            this.colMultiCompanyId.Name = "colMultiCompanyId";
            this.colMultiCompanyId.NamedProperties.Put("EnumerateMethod", "");
            this.colMultiCompanyId.NamedProperties.Put("FieldFlags", "288");
            this.colMultiCompanyId.NamedProperties.Put("LovReference", "COMPANY_FINANCE");
            this.colMultiCompanyId.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colMultiCompanyId.NamedProperties.Put("ResizeableChildObject", "");
            this.colMultiCompanyId.NamedProperties.Put("SqlColumn", "MULTI_COMPANY_ID");
            this.colMultiCompanyId.NamedProperties.Put("ValidateMethod", "");
            this.colMultiCompanyId.Position = 23;
            // 
            // colVoucherTypeRef
            // 
            this.colVoucherTypeRef.Name = "colVoucherTypeRef";
            this.colVoucherTypeRef.NamedProperties.Put("EnumerateMethod", "");
            this.colVoucherTypeRef.NamedProperties.Put("FieldFlags", "290");
            this.colVoucherTypeRef.NamedProperties.Put("LovReference", "VOUCHER_TYPE(COMPANY)");
            this.colVoucherTypeRef.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colVoucherTypeRef.NamedProperties.Put("ResizeableChildObject", "");
            this.colVoucherTypeRef.NamedProperties.Put("SqlColumn", "VOUCHER_TYPE_REFERENCE");
            this.colVoucherTypeRef.NamedProperties.Put("ValidateMethod", "");
            this.colVoucherTypeRef.Position = 24;
            resources.ApplyResources(this.colVoucherTypeRef, "colVoucherTypeRef");
            this.colVoucherTypeRef.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colVoucherTypeRef_WindowActions);
            // 
            // colVoucherNoRef
            // 
            this.colVoucherNoRef.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colVoucherNoRef.Name = "colVoucherNoRef";
            this.colVoucherNoRef.NamedProperties.Put("EnumerateMethod", "");
            this.colVoucherNoRef.NamedProperties.Put("FieldFlags", "288");
            this.colVoucherNoRef.NamedProperties.Put("LovReference", "");
            this.colVoucherNoRef.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colVoucherNoRef.NamedProperties.Put("SqlColumn", "VOUCHER_NO_REFERENCE");
            this.colVoucherNoRef.NamedProperties.Put("ValidateMethod", "");
            this.colVoucherNoRef.Position = 25;
            resources.ApplyResources(this.colVoucherNoRef, "colVoucherNoRef");
            // 
            // colAccntYearRef
            // 
            this.colAccntYearRef.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colAccntYearRef.Name = "colAccntYearRef";
            this.colAccntYearRef.NamedProperties.Put("EnumerateMethod", "");
            this.colAccntYearRef.NamedProperties.Put("FieldFlags", "288");
            this.colAccntYearRef.NamedProperties.Put("LovReference", "");
            this.colAccntYearRef.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colAccntYearRef.NamedProperties.Put("SqlColumn", "ACCOUNTING_YEAR_REFERENCE");
            this.colAccntYearRef.NamedProperties.Put("ValidateMethod", "");
            this.colAccntYearRef.Position = 26;
            resources.ApplyResources(this.colAccntYearRef, "colAccntYearRef");
            // 
            // menuOperations
            // 
            this.menuOperations.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_Voucher,
            this.menuItem_Voucher_1,
            this.menuItem_View,
            this.menuSeparator1,
            this.menuItem_Change,
            this.menuItem__Notes});
            this.menuOperations.Name = "menuOperations";
            resources.ApplyResources(this.menuOperations, "menuOperations");
            // 
            // menuItem_Voucher
            // 
            this.menuItem_Voucher.Command = this.menuOperations_menuVoucher__Rows___;
            this.menuItem_Voucher.Name = "menuItem_Voucher";
            resources.ApplyResources(this.menuItem_Voucher, "menuItem_Voucher");
            this.menuItem_Voucher.Text = "Voucher &Rows...";
            // 
            // menuItem_Voucher_1
            // 
            this.menuItem_Voucher_1.Command = this.menuOperations_menuVoucher__Details___;
            this.menuItem_Voucher_1.Name = "menuItem_Voucher_1";
            resources.ApplyResources(this.menuItem_Voucher_1, "menuItem_Voucher_1");
            this.menuItem_Voucher_1.Text = "Voucher &Details...";
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
            // menuItem__Notes
            // 
            this.menuItem__Notes.Command = this.menuOperations_menu_Notes___;
            this.menuItem__Notes.Name = "menuItem__Notes";
            resources.ApplyResources(this.menuItem__Notes, "menuItem__Notes");
            this.menuItem__Notes.Text = "&Notes...";
            // 
            // menuTbwMethods
            // 
            this.menuTbwMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_Voucher_2,
            this.menuItem_Voucher_3,
            this.menuItem_View_1,
            this.menuSeparator2,
            this.menuItem_Change_1,
            this.menuItem__Notes_1});
            this.menuTbwMethods.Name = "menuTbwMethods";
            resources.ApplyResources(this.menuTbwMethods, "menuTbwMethods");
            // 
            // menuItem_Voucher_2
            // 
            this.menuItem_Voucher_2.Command = this.menuTbwMethods_menuVoucher__Rows___;
            this.menuItem_Voucher_2.Name = "menuItem_Voucher_2";
            resources.ApplyResources(this.menuItem_Voucher_2, "menuItem_Voucher_2");
            this.menuItem_Voucher_2.Text = "Voucher &Rows...";
            // 
            // menuItem_Voucher_3
            // 
            this.menuItem_Voucher_3.Command = this.menuTbwMethods_menuVoucher__Details___;
            this.menuItem_Voucher_3.Name = "menuItem_Voucher_3";
            resources.ApplyResources(this.menuItem_Voucher_3, "menuItem_Voucher_3");
            this.menuItem_Voucher_3.Text = "Voucher &Details...";
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
            // menuItem__Notes_1
            // 
            this.menuItem__Notes_1.Command = this.menuTbwMethods_menu_Notes___;
            this.menuItem__Notes_1.Name = "menuItem__Notes_1";
            resources.ApplyResources(this.menuItem__Notes_1, "menuItem__Notes_1");
            this.menuItem__Notes_1.Text = "&Notes...";
            // 
            // tbwQueryVoucher
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colCompany);
            this.Controls.Add(this.colVoucherStatus);
            this.Controls.Add(this.colVoucherType);
            this.Controls.Add(this.colsFunctionGroup);
            this.Controls.Add(this.colVoucherNo);
            this.Controls.Add(this.colVoucherDate);
            this.Controls.Add(this.colAccountingYear);
            this.Controls.Add(this.colAccountingPeriod);
            this.Controls.Add(this.colDateReg);
            this.Controls.Add(this.colUserGroup);
            this.Controls.Add(this.colUserid);
            this.Controls.Add(this.coldApprovalDate);
            this.Controls.Add(this.colsApprovedByUserGroup);
            this.Controls.Add(this.colsApprovedByUserid);
            this.Controls.Add(this.colsVoucherText2);
            this.Controls.Add(this.colUpdateError);
            this.Controls.Add(this.colTransferId);
            this.Controls.Add(this.colText);
            this.Controls.Add(this.colInterimVoucher);
            this.Controls.Add(this.colMultiCompanyVoucher);
            this.Controls.Add(this.colMultiCompanyId);
            this.Controls.Add(this.colVoucherTypeRef);
            this.Controls.Add(this.colVoucherNoRef);
            this.Controls.Add(this.colAccntYearRef);
            this.Name = "tbwQueryVoucher";
            this.NamedProperties.Put("DefaultOrderBy", "VOUCHER_TYPE, VOUCHER_NO");
            this.NamedProperties.Put("DefaultWhere", "COMPANY = :global.company  AND\r\nVOUCHER_UPDATED_DB=\'N\'");
            this.NamedProperties.Put("LogicalUnit", "Voucher");
            this.NamedProperties.Put("PackageName", "VOUCHER_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "0");
            this.NamedProperties.Put("SourceFlags", "16385");
            this.NamedProperties.Put("ViewName", "VOUCHER");
            this.NamedProperties.Put("Warning", "FALSE");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tbwQueryVoucher_WindowActions);
            this.Controls.SetChildIndex(this.colAccntYearRef, 0);
            this.Controls.SetChildIndex(this.colVoucherNoRef, 0);
            this.Controls.SetChildIndex(this.colVoucherTypeRef, 0);
            this.Controls.SetChildIndex(this.colMultiCompanyId, 0);
            this.Controls.SetChildIndex(this.colMultiCompanyVoucher, 0);
            this.Controls.SetChildIndex(this.colInterimVoucher, 0);
            this.Controls.SetChildIndex(this.colText, 0);
            this.Controls.SetChildIndex(this.colTransferId, 0);
            this.Controls.SetChildIndex(this.colUpdateError, 0);
            this.Controls.SetChildIndex(this.colsVoucherText2, 0);
            this.Controls.SetChildIndex(this.colsApprovedByUserid, 0);
            this.Controls.SetChildIndex(this.colsApprovedByUserGroup, 0);
            this.Controls.SetChildIndex(this.coldApprovalDate, 0);
            this.Controls.SetChildIndex(this.colUserid, 0);
            this.Controls.SetChildIndex(this.colUserGroup, 0);
            this.Controls.SetChildIndex(this.colDateReg, 0);
            this.Controls.SetChildIndex(this.colAccountingPeriod, 0);
            this.Controls.SetChildIndex(this.colAccountingYear, 0);
            this.Controls.SetChildIndex(this.colVoucherDate, 0);
            this.Controls.SetChildIndex(this.colVoucherNo, 0);
            this.Controls.SetChildIndex(this.colsFunctionGroup, 0);
            this.Controls.SetChildIndex(this.colVoucherType, 0);
            this.Controls.SetChildIndex(this.colVoucherStatus, 0);
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

        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menuVoucher__Rows___;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menuVoucher__Details___;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menuView__Multi_Company_Voucher___;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menuChange__Company___;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menu_Notes___;
        public Fnd.Windows.Forms.FndCommand menuOperations_menuVoucher__Rows___;
        public Fnd.Windows.Forms.FndCommand menuOperations_menuVoucher__Details___;
        public Fnd.Windows.Forms.FndCommand menuOperations_menuView__Multi_Company_Voucher___;
        public Fnd.Windows.Forms.FndCommand menuOperations_menuChange__Company___;
        public Fnd.Windows.Forms.FndCommand menuOperations_menu_Notes___;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuOperations;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Voucher;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Voucher_1;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_View;
        protected Fnd.Windows.Forms.FndToolStripSeparator menuSeparator1;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Notes;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTbwMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Voucher_2;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Voucher_3;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_View_1;
        protected Fnd.Windows.Forms.FndToolStripSeparator menuSeparator2;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change_1;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Notes_1;
	}
}
