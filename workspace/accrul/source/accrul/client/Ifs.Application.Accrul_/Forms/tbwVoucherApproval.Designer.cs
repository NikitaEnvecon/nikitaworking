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
	
	public partial class tbwVoucherApproval
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
		protected SalGroupBox gbVoucher_Info;
		protected cBackgroundText labelcmbUserGroup;
		public cRecSelComboBox cmbUserGroup;
		protected cBackgroundText labeldfUserId;
		public cDataField dfUserId;
		protected cBackgroundText labeldfVoucherDate;
		public cDataField dfVoucherDate;
		public cColumn colsCompany;
		public cColumn colsVoucherStatus;
		public cColumn colsVoucherType;
		public cColumn colnVoucherNo;
		public cColumn coldVoucherDate;
		public cColumn colnAccountingYear;
		public cColumn colnAccountingPeriod;
		public cColumn coldDateReg;
		public cColumn colsEnteredByUserGroup;
		public cColumn colsUserid;
		public cColumn colnSumDebetAmount;
		public cColumn colnSumCreditAmount;
		public cColumn colAmount;
		public cColumn colVoucherText2;
		// Bug 84366, Begin - Enabled the Queryable F1 property and modified the Checked & UnChecked Values.
		// Bug 77430, Begin, changed F1 property Column Name
		public cColumn colsFreeText;
		// Bug 77430, End
		// Bug 84366, End.
		public cColumn colsInterimVoucher;
		public cColumn colsMultiCompanyId;
		// Bug 77430, Removed colVoucherText
		public cColumn colsUserGroup;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwVoucherApproval));
            this.menuTbwMethods_menuVoucher__Entry___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_menuApprove__Voucher___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_menu_Notes___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_menuChange__Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.ToolBar = new PPJ.Runtime.Windows.SalFormToolBar();
            this.dfVoucherDate = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfUserId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.cmbUserGroup = new Ifs.Fnd.ApplicationForms.cRecSelComboBox();
            this.labeldfVoucherDate = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.labeldfUserId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.labelcmbUserGroup = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.gbVoucher_Info = new PPJ.Runtime.Windows.SalGroupBox();
            this.StatusBar = new PPJ.Runtime.Windows.SalFormStatusBar();
            this.colsCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsVoucherStatus = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsVoucherType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colnVoucherNo = new Ifs.Fnd.ApplicationForms.cColumn();
            this.coldVoucherDate = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colnAccountingYear = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colnAccountingPeriod = new Ifs.Fnd.ApplicationForms.cColumn();
            this.coldDateReg = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsEnteredByUserGroup = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsUserid = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colnSumDebetAmount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colnSumCreditAmount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colAmount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colVoucherText2 = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsFreeText = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsInterimVoucher = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsMultiCompanyId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsUserGroup = new Ifs.Fnd.ApplicationForms.cColumn();
            this.menuTbwMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_Voucher = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem_Approve = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuSeparator1 = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.menuItem__Notes = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem_Change = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.colnSumThirdCurrDebetAmount = new Ifs.Application.Accrul.cColumnFinEuro();
            this.colnSumThirdCurrCreditAmount = new Ifs.Application.Accrul.cColumnFinEuro();
            this.colnSumThirdCurrAmount = new Ifs.Application.Accrul.cColumnFinEuro();
            this.ToolBar.SuspendLayout();
            this.menuTbwMethods.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuTbwMethods_menuVoucher__Entry___);
            this.commandManager.Commands.Add(this.menuTbwMethods_menuApprove__Voucher___);
            this.commandManager.Commands.Add(this.menuTbwMethods_menu_Notes___);
            this.commandManager.Commands.Add(this.menuTbwMethods_menuChange__Company___);
            this.commandManager.ContextMenus.Add(this.menuTbwMethods);
            // 
            // menuTbwMethods_menuVoucher__Entry___
            // 
            resources.ApplyResources(this.menuTbwMethods_menuVoucher__Entry___, "menuTbwMethods_menuVoucher__Entry___");
            this.menuTbwMethods_menuVoucher__Entry___.Name = "menuTbwMethods_menuVoucher__Entry___";
            this.menuTbwMethods_menuVoucher__Entry___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Voucher_Execute);
            this.menuTbwMethods_menuVoucher__Entry___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Voucher_Inquire);
            // 
            // menuTbwMethods_menuApprove__Voucher___
            // 
            resources.ApplyResources(this.menuTbwMethods_menuApprove__Voucher___, "menuTbwMethods_menuApprove__Voucher___");
            this.menuTbwMethods_menuApprove__Voucher___.Name = "menuTbwMethods_menuApprove__Voucher___";
            this.menuTbwMethods_menuApprove__Voucher___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Approve_Execute);
            this.menuTbwMethods_menuApprove__Voucher___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Approve_Inquire);
            // 
            // menuTbwMethods_menu_Notes___
            // 
            resources.ApplyResources(this.menuTbwMethods_menu_Notes___, "menuTbwMethods_menu_Notes___");
            this.menuTbwMethods_menu_Notes___.Name = "menuTbwMethods_menu_Notes___";
            this.menuTbwMethods_menu_Notes___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Notes_Execute);
            this.menuTbwMethods_menu_Notes___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Notes_Inquire);
            // 
            // menuTbwMethods_menuChange__Company___
            // 
            resources.ApplyResources(this.menuTbwMethods_menuChange__Company___, "menuTbwMethods_menuChange__Company___");
            this.menuTbwMethods_menuChange__Company___.Name = "menuTbwMethods_menuChange__Company___";
            this.menuTbwMethods_menuChange__Company___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Change_Execute);
            this.menuTbwMethods_menuChange__Company___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Change_Inquire);
            // 
            // ToolBar
            // 
            this.ToolBar.Controls.Add(this.dfVoucherDate);
            this.ToolBar.Controls.Add(this.dfUserId);
            this.ToolBar.Controls.Add(this.cmbUserGroup);
            this.ToolBar.Controls.Add(this.labeldfVoucherDate);
            this.ToolBar.Controls.Add(this.labeldfUserId);
            this.ToolBar.Controls.Add(this.labelcmbUserGroup);
            this.ToolBar.Controls.Add(this.gbVoucher_Info);
            this.ToolBar.Name = "ToolBar";
            resources.ApplyResources(this.ToolBar, "ToolBar");
            this.ToolBar.TabStop = true;
            // 
            // dfVoucherDate
            // 
            this.dfVoucherDate.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.dfVoucherDate.Format = "d";
            resources.ApplyResources(this.dfVoucherDate, "dfVoucherDate");
            this.dfVoucherDate.Name = "dfVoucherDate";
            this.dfVoucherDate.NamedProperties.Put("EnumerateMethod", "");
            this.dfVoucherDate.NamedProperties.Put("LovReference", "");
            this.dfVoucherDate.NamedProperties.Put("ResizeableChildObject", "");
            this.dfVoucherDate.NamedProperties.Put("SqlColumn", "");
            this.dfVoucherDate.NamedProperties.Put("ValidateMethod", "");
            this.dfVoucherDate.TabStop = false;
            this.dfVoucherDate.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfVoucherDate_WindowActions);
            // 
            // dfUserId
            // 
            resources.ApplyResources(this.dfUserId, "dfUserId");
            this.dfUserId.Name = "dfUserId";
            this.dfUserId.NamedProperties.Put("EnumerateMethod", "");
            this.dfUserId.NamedProperties.Put("LovReference", "");
            this.dfUserId.NamedProperties.Put("ResizeableChildObject", "");
            this.dfUserId.NamedProperties.Put("SqlColumn", "");
            this.dfUserId.NamedProperties.Put("ValidateMethod", "");
            this.dfUserId.TabStop = false;
            this.dfUserId.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfUserId_WindowActions);
            // 
            // cmbUserGroup
            // 
            this.cmbUserGroup.DropDownHeight = 205;
            resources.ApplyResources(this.cmbUserGroup, "cmbUserGroup");
            this.cmbUserGroup.Name = "cmbUserGroup";
            this.cmbUserGroup.NamedProperties.Put("EnumerateMethod", "");
            this.cmbUserGroup.NamedProperties.Put("FieldFlags", "260");
            this.cmbUserGroup.NamedProperties.Put("LovReference", "");
            this.cmbUserGroup.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbUserGroup.NamedProperties.Put("SqlColumn", "");
            this.cmbUserGroup.NamedProperties.Put("ValidateMethod", "");
            this.cmbUserGroup.TabStop = false;
            this.cmbUserGroup.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbUserGroup_WindowActions);
            // 
            // labeldfVoucherDate
            // 
            resources.ApplyResources(this.labeldfVoucherDate, "labeldfVoucherDate");
            this.labeldfVoucherDate.Name = "labeldfVoucherDate";
            // 
            // labeldfUserId
            // 
            resources.ApplyResources(this.labeldfUserId, "labeldfUserId");
            this.labeldfUserId.Name = "labeldfUserId";
            // 
            // labelcmbUserGroup
            // 
            resources.ApplyResources(this.labelcmbUserGroup, "labelcmbUserGroup");
            this.labelcmbUserGroup.Name = "labelcmbUserGroup";
            // 
            // gbVoucher_Info
            // 
            resources.ApplyResources(this.gbVoucher_Info, "gbVoucher_Info");
            this.gbVoucher_Info.Name = "gbVoucher_Info";
            this.gbVoucher_Info.TabStop = false;
            // 
            // StatusBar
            // 
            resources.ApplyResources(this.StatusBar, "StatusBar");
            this.StatusBar.Name = "StatusBar";
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
            this.colsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.colsCompany.Position = 3;
            // 
            // colsVoucherStatus
            // 
            this.colsVoucherStatus.Name = "colsVoucherStatus";
            this.colsVoucherStatus.NamedProperties.Put("EnumerateMethod", "");
            this.colsVoucherStatus.NamedProperties.Put("FieldFlags", "288");
            this.colsVoucherStatus.NamedProperties.Put("LovReference", "");
            this.colsVoucherStatus.NamedProperties.Put("ResizeableChildObject", "");
            this.colsVoucherStatus.NamedProperties.Put("SqlColumn", "VOUCHER_STATUS");
            this.colsVoucherStatus.NamedProperties.Put("ValidateMethod", "");
            this.colsVoucherStatus.Position = 4;
            resources.ApplyResources(this.colsVoucherStatus, "colsVoucherStatus");
            // 
            // colsVoucherType
            // 
            this.colsVoucherType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsVoucherType.Name = "colsVoucherType";
            this.colsVoucherType.NamedProperties.Put("EnumerateMethod", "");
            this.colsVoucherType.NamedProperties.Put("FieldFlags", "163");
            this.colsVoucherType.NamedProperties.Put("LovReference", "VOUCHER_TYPE(COMPANY)");
            this.colsVoucherType.NamedProperties.Put("ResizeableChildObject", "");
            this.colsVoucherType.NamedProperties.Put("SqlColumn", "VOUCHER_TYPE");
            this.colsVoucherType.NamedProperties.Put("ValidateMethod", "");
            this.colsVoucherType.Position = 5;
            resources.ApplyResources(this.colsVoucherType, "colsVoucherType");
            // 
            // colnVoucherNo
            // 
            this.colnVoucherNo.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colnVoucherNo.Name = "colnVoucherNo";
            this.colnVoucherNo.NamedProperties.Put("EnumerateMethod", "");
            this.colnVoucherNo.NamedProperties.Put("FieldFlags", "290");
            this.colnVoucherNo.NamedProperties.Put("LovReference", "");
            this.colnVoucherNo.NamedProperties.Put("ResizeableChildObject", "");
            this.colnVoucherNo.NamedProperties.Put("SqlColumn", "VOUCHER_NO");
            this.colnVoucherNo.NamedProperties.Put("ValidateMethod", "");
            this.colnVoucherNo.Position = 6;
            resources.ApplyResources(this.colnVoucherNo, "colnVoucherNo");
            // 
            // coldVoucherDate
            // 
            this.coldVoucherDate.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.coldVoucherDate.Format = "d";
            this.coldVoucherDate.Name = "coldVoucherDate";
            this.coldVoucherDate.NamedProperties.Put("EnumerateMethod", "");
            this.coldVoucherDate.NamedProperties.Put("FieldFlags", "290");
            this.coldVoucherDate.NamedProperties.Put("LovReference", "");
            this.coldVoucherDate.NamedProperties.Put("ResizeableChildObject", "");
            this.coldVoucherDate.NamedProperties.Put("SqlColumn", "VOUCHER_DATE");
            this.coldVoucherDate.NamedProperties.Put("ValidateMethod", "");
            this.coldVoucherDate.Position = 7;
            resources.ApplyResources(this.coldVoucherDate, "coldVoucherDate");
            // 
            // colnAccountingYear
            // 
            this.colnAccountingYear.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colnAccountingYear.Name = "colnAccountingYear";
            this.colnAccountingYear.NamedProperties.Put("EnumerateMethod", "");
            this.colnAccountingYear.NamedProperties.Put("FieldFlags", "290");
            this.colnAccountingYear.NamedProperties.Put("LovReference", "ACCOUNTING_YEAR(COMPANY)");
            this.colnAccountingYear.NamedProperties.Put("ResizeableChildObject", "");
            this.colnAccountingYear.NamedProperties.Put("SqlColumn", "ACCOUNTING_YEAR");
            this.colnAccountingYear.NamedProperties.Put("ValidateMethod", "");
            this.colnAccountingYear.Position = 8;
            resources.ApplyResources(this.colnAccountingYear, "colnAccountingYear");
            // 
            // colnAccountingPeriod
            // 
            this.colnAccountingPeriod.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colnAccountingPeriod.Name = "colnAccountingPeriod";
            this.colnAccountingPeriod.NamedProperties.Put("EnumerateMethod", "");
            this.colnAccountingPeriod.NamedProperties.Put("FieldFlags", "290");
            this.colnAccountingPeriod.NamedProperties.Put("LovReference", "ACCOUNTING_PERIOD(COMPANY,ACCOUNTING_YEAR)");
            this.colnAccountingPeriod.NamedProperties.Put("ResizeableChildObject", "");
            this.colnAccountingPeriod.NamedProperties.Put("SqlColumn", "ACCOUNTING_PERIOD");
            this.colnAccountingPeriod.NamedProperties.Put("ValidateMethod", "");
            this.colnAccountingPeriod.Position = 9;
            resources.ApplyResources(this.colnAccountingPeriod, "colnAccountingPeriod");
            // 
            // coldDateReg
            // 
            this.coldDateReg.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.coldDateReg.Format = "d";
            this.coldDateReg.Name = "coldDateReg";
            this.coldDateReg.NamedProperties.Put("EnumerateMethod", "");
            this.coldDateReg.NamedProperties.Put("FieldFlags", "290");
            this.coldDateReg.NamedProperties.Put("LovReference", "");
            this.coldDateReg.NamedProperties.Put("ResizeableChildObject", "");
            this.coldDateReg.NamedProperties.Put("SqlColumn", "DATE_REG");
            this.coldDateReg.NamedProperties.Put("ValidateMethod", "");
            this.coldDateReg.Position = 10;
            resources.ApplyResources(this.coldDateReg, "coldDateReg");
            // 
            // colsEnteredByUserGroup
            // 
            this.colsEnteredByUserGroup.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsEnteredByUserGroup.MaxLength = 30;
            this.colsEnteredByUserGroup.Name = "colsEnteredByUserGroup";
            this.colsEnteredByUserGroup.NamedProperties.Put("EnumerateMethod", "");
            this.colsEnteredByUserGroup.NamedProperties.Put("FieldFlags", "290");
            this.colsEnteredByUserGroup.NamedProperties.Put("LovReference", "USER_GROUP_FINANCE(COMPANY)");
            this.colsEnteredByUserGroup.NamedProperties.Put("ResizeableChildObject", "");
            this.colsEnteredByUserGroup.NamedProperties.Put("SqlColumn", "ENTERED_BY_USER_GROUP");
            this.colsEnteredByUserGroup.NamedProperties.Put("ValidateMethod", "");
            this.colsEnteredByUserGroup.Position = 11;
            resources.ApplyResources(this.colsEnteredByUserGroup, "colsEnteredByUserGroup");
            // 
            // colsUserid
            // 
            this.colsUserid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsUserid.Name = "colsUserid";
            this.colsUserid.NamedProperties.Put("EnumerateMethod", "");
            this.colsUserid.NamedProperties.Put("FieldFlags", "290");
            this.colsUserid.NamedProperties.Put("LovReference", "USER_FINANCE(COMPANY)");
            this.colsUserid.NamedProperties.Put("ResizeableChildObject", "");
            this.colsUserid.NamedProperties.Put("SqlColumn", "USERID");
            this.colsUserid.NamedProperties.Put("ValidateMethod", "");
            this.colsUserid.Position = 12;
            resources.ApplyResources(this.colsUserid, "colsUserid");
            // 
            // colnSumDebetAmount
            // 
            this.colnSumDebetAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.colnSumDebetAmount, "colnSumDebetAmount");
            this.colnSumDebetAmount.Name = "colnSumDebetAmount";
            this.colnSumDebetAmount.NamedProperties.Put("EnumerateMethod", "");
            this.colnSumDebetAmount.NamedProperties.Put("FieldFlags", "294");
            this.colnSumDebetAmount.NamedProperties.Put("Format", "20");
            this.colnSumDebetAmount.NamedProperties.Put("LovReference", "");
            this.colnSumDebetAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.colnSumDebetAmount.NamedProperties.Put("SqlColumn", "SUM_DEBIT_AMOUNT");
            this.colnSumDebetAmount.NamedProperties.Put("ValidateMethod", "");
            this.colnSumDebetAmount.Position = 13;
            this.colnSumDebetAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // colnSumCreditAmount
            // 
            this.colnSumCreditAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.colnSumCreditAmount, "colnSumCreditAmount");
            this.colnSumCreditAmount.Name = "colnSumCreditAmount";
            this.colnSumCreditAmount.NamedProperties.Put("EnumerateMethod", "");
            this.colnSumCreditAmount.NamedProperties.Put("FieldFlags", "294");
            this.colnSumCreditAmount.NamedProperties.Put("Format", "20");
            this.colnSumCreditAmount.NamedProperties.Put("LovReference", "");
            this.colnSumCreditAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.colnSumCreditAmount.NamedProperties.Put("SqlColumn", "SUM_CREDIT_AMOUNT");
            this.colnSumCreditAmount.NamedProperties.Put("ValidateMethod", "");
            this.colnSumCreditAmount.Position = 14;
            this.colnSumCreditAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // colAmount
            // 
            this.colAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colAmount.Name = "colAmount";
            this.colAmount.NamedProperties.Put("EnumerateMethod", "");
            this.colAmount.NamedProperties.Put("FieldFlags", "288");
            this.colAmount.NamedProperties.Put("Format", "20");
            this.colAmount.NamedProperties.Put("LovReference", "");
            this.colAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.colAmount.NamedProperties.Put("SqlColumn", "nvl(sum_debit_amount, 0) -  nvl(sum_credit_amount,0)  ");
            this.colAmount.NamedProperties.Put("ValidateMethod", "");
            this.colAmount.Position = 15;
            this.colAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.colAmount, "colAmount");
            // 
            // colVoucherText2
            // 
            this.colVoucherText2.MaxLength = 200;
            this.colVoucherText2.Name = "colVoucherText2";
            this.colVoucherText2.NamedProperties.Put("EnumerateMethod", "");
            this.colVoucherText2.NamedProperties.Put("FieldFlags", "288");
            this.colVoucherText2.NamedProperties.Put("LovReference", "");
            this.colVoucherText2.NamedProperties.Put("ResizeableChildObject", "");
            this.colVoucherText2.NamedProperties.Put("SqlColumn", "VOUCHER_TEXT2");
            this.colVoucherText2.NamedProperties.Put("ValidateMethod", "");
            this.colVoucherText2.Position = 19;
            resources.ApplyResources(this.colVoucherText2, "colVoucherText2");
            // 
            // colsFreeText
            // 
            this.colsFreeText.CellType = PPJ.Runtime.Windows.CellType.CheckBox;
            this.colsFreeText.CheckBox.CheckedValue = "TRUE";
            this.colsFreeText.CheckBox.IgnoreCase = true;
            this.colsFreeText.CheckBox.UncheckedValue = "FALSE";
            resources.ApplyResources(this.colsFreeText, "colsFreeText");
            this.colsFreeText.MaxLength = 5;
            this.colsFreeText.Name = "colsFreeText";
            this.colsFreeText.NamedProperties.Put("EnumerateMethod", "");
            this.colsFreeText.NamedProperties.Put("FieldFlags", "290");
            this.colsFreeText.NamedProperties.Put("LovReference", "");
            this.colsFreeText.NamedProperties.Put("ResizeableChildObject", "");
            this.colsFreeText.NamedProperties.Put("SqlColumn", "Voucher_Note_API.Check_Note_Exist(COMPANY,ACCOUNTING_YEAR,VOUCHER_TYPE,VOUCHER_NO" +
                    ")");
            this.colsFreeText.NamedProperties.Put("ValidateMethod", "");
            this.colsFreeText.Position = 20;
            this.colsFreeText.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsFreeText_WindowActions);
            // 
            // colsInterimVoucher
            // 
            this.colsInterimVoucher.CellType = PPJ.Runtime.Windows.CellType.CheckBox;
            this.colsInterimVoucher.CheckBox.CheckedValue = "Y";
            this.colsInterimVoucher.CheckBox.IgnoreCase = true;
            this.colsInterimVoucher.CheckBox.UncheckedValue = "N";
            resources.ApplyResources(this.colsInterimVoucher, "colsInterimVoucher");
            this.colsInterimVoucher.Name = "colsInterimVoucher";
            this.colsInterimVoucher.NamedProperties.Put("EnumerateMethod", "");
            this.colsInterimVoucher.NamedProperties.Put("FieldFlags", "290");
            this.colsInterimVoucher.NamedProperties.Put("LovReference", "");
            this.colsInterimVoucher.NamedProperties.Put("ResizeableChildObject", "");
            this.colsInterimVoucher.NamedProperties.Put("SqlColumn", "INTERIM_VOUCHER");
            this.colsInterimVoucher.NamedProperties.Put("ValidateMethod", "");
            this.colsInterimVoucher.Position = 21;
            // 
            // colsMultiCompanyId
            // 
            this.colsMultiCompanyId.CellType = PPJ.Runtime.Windows.CellType.CheckBox;
            this.colsMultiCompanyId.CheckBox.CheckedValue = "TRUE";
            this.colsMultiCompanyId.CheckBox.IgnoreCase = true;
            this.colsMultiCompanyId.CheckBox.UncheckedValue = "FALSE";
            resources.ApplyResources(this.colsMultiCompanyId, "colsMultiCompanyId");
            this.colsMultiCompanyId.Name = "colsMultiCompanyId";
            this.colsMultiCompanyId.NamedProperties.Put("EnumerateMethod", "");
            this.colsMultiCompanyId.NamedProperties.Put("FieldFlags", "294");
            this.colsMultiCompanyId.NamedProperties.Put("LovReference", "");
            this.colsMultiCompanyId.NamedProperties.Put("ResizeableChildObject", "");
            this.colsMultiCompanyId.NamedProperties.Put("SqlColumn", "VOUCHER_API.Is_Multi_Company_Voucher(COMPANY,VOUCHER_TYPE, ACCOUNTING_YEAR,VOUCHE" +
                    "R_NO)");
            this.colsMultiCompanyId.NamedProperties.Put("ValidateMethod", "");
            this.colsMultiCompanyId.Position = 22;
            // 
            // colsUserGroup
            // 
            resources.ApplyResources(this.colsUserGroup, "colsUserGroup");
            this.colsUserGroup.MaxLength = 30;
            this.colsUserGroup.Name = "colsUserGroup";
            this.colsUserGroup.NamedProperties.Put("EnumerateMethod", "");
            this.colsUserGroup.NamedProperties.Put("FieldFlags", "262");
            this.colsUserGroup.NamedProperties.Put("LovReference", "USER_GROUP_PERIOD(COMPANY,ACCOUNTING_YEAR,ACCOUNTING_PERIOD)");
            this.colsUserGroup.NamedProperties.Put("ResizeableChildObject", "");
            this.colsUserGroup.NamedProperties.Put("SqlColumn", "USER_GROUP");
            this.colsUserGroup.NamedProperties.Put("ValidateMethod", "");
            this.colsUserGroup.Position = 23;
            // 
            // menuTbwMethods
            // 
            this.menuTbwMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_Voucher,
            this.menuItem_Approve,
            this.menuSeparator1,
            this.menuItem__Notes,
            this.menuItem_Change});
            this.menuTbwMethods.Name = "menuTbwMethods";
            resources.ApplyResources(this.menuTbwMethods, "menuTbwMethods");
            // 
            // menuItem_Voucher
            // 
            this.menuItem_Voucher.Command = this.menuTbwMethods_menuVoucher__Entry___;
            this.menuItem_Voucher.Name = "menuItem_Voucher";
            resources.ApplyResources(this.menuItem_Voucher, "menuItem_Voucher");
            this.menuItem_Voucher.Text = "Voucher &Entry...";
            // 
            // menuItem_Approve
            // 
            this.menuItem_Approve.Command = this.menuTbwMethods_menuApprove__Voucher___;
            this.menuItem_Approve.Name = "menuItem_Approve";
            resources.ApplyResources(this.menuItem_Approve, "menuItem_Approve");
            this.menuItem_Approve.Text = "Approve &Voucher...";
            // 
            // menuSeparator1
            // 
            this.menuSeparator1.Name = "menuSeparator1";
            resources.ApplyResources(this.menuSeparator1, "menuSeparator1");
            // 
            // menuItem__Notes
            // 
            this.menuItem__Notes.Command = this.menuTbwMethods_menu_Notes___;
            this.menuItem__Notes.Name = "menuItem__Notes";
            resources.ApplyResources(this.menuItem__Notes, "menuItem__Notes");
            this.menuItem__Notes.Text = "&Notes...";
            // 
            // menuItem_Change
            // 
            this.menuItem_Change.Command = this.menuTbwMethods_menuChange__Company___;
            this.menuItem_Change.Name = "menuItem_Change";
            resources.ApplyResources(this.menuItem_Change, "menuItem_Change");
            this.menuItem_Change.Text = "Change &Company...";
            // 
            // colnSumThirdCurrDebetAmount
            // 
            this.colnSumThirdCurrDebetAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colnSumThirdCurrDebetAmount.Name = "colnSumThirdCurrDebetAmount";
            this.colnSumThirdCurrDebetAmount.NamedProperties.Put("EnumerateMethod", "");
            this.colnSumThirdCurrDebetAmount.NamedProperties.Put("FieldFlags", "288");
            this.colnSumThirdCurrDebetAmount.NamedProperties.Put("Format", "20");
            this.colnSumThirdCurrDebetAmount.NamedProperties.Put("LovReference", "");
            this.colnSumThirdCurrDebetAmount.NamedProperties.Put("SqlColumn", "SUM_THIRD_CURR_DEBIT_AMOUNT");
            this.colnSumThirdCurrDebetAmount.Position = 16;
            this.colnSumThirdCurrDebetAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.colnSumThirdCurrDebetAmount, "colnSumThirdCurrDebetAmount");
            // 
            // colnSumThirdCurrCreditAmount
            // 
            this.colnSumThirdCurrCreditAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colnSumThirdCurrCreditAmount.Name = "colnSumThirdCurrCreditAmount";
            this.colnSumThirdCurrCreditAmount.NamedProperties.Put("EnumerateMethod", "");
            this.colnSumThirdCurrCreditAmount.NamedProperties.Put("FieldFlags", "288");
            this.colnSumThirdCurrCreditAmount.NamedProperties.Put("Format", "20");
            this.colnSumThirdCurrCreditAmount.NamedProperties.Put("LovReference", "");
            this.colnSumThirdCurrCreditAmount.NamedProperties.Put("SqlColumn", "SUM_THIRD_CURR_CREDIT_AMOUNT");
            this.colnSumThirdCurrCreditAmount.Position = 17;
            this.colnSumThirdCurrCreditAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.colnSumThirdCurrCreditAmount, "colnSumThirdCurrCreditAmount");
            // 
            // colnSumThirdCurrAmount
            // 
            this.colnSumThirdCurrAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colnSumThirdCurrAmount.Name = "colnSumThirdCurrAmount";
            this.colnSumThirdCurrAmount.NamedProperties.Put("EnumerateMethod", "");
            this.colnSumThirdCurrAmount.NamedProperties.Put("FieldFlags", "288");
            this.colnSumThirdCurrAmount.NamedProperties.Put("Format", "20");
            this.colnSumThirdCurrAmount.NamedProperties.Put("LovReference", "");
            this.colnSumThirdCurrAmount.NamedProperties.Put("SqlColumn", "nvl(SUM_THIRD_CURR_DEBIT_AMOUNT, 0) -  nvl(SUM_THIRD_CURR_CREDIT_AMOUNT,0)  ");
            this.colnSumThirdCurrAmount.Position = 18;
            this.colnSumThirdCurrAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.colnSumThirdCurrAmount, "colnSumThirdCurrAmount");
            // 
            // tbwVoucherApproval
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colsCompany);
            this.Controls.Add(this.colsVoucherStatus);
            this.Controls.Add(this.colsVoucherType);
            this.Controls.Add(this.colnVoucherNo);
            this.Controls.Add(this.coldVoucherDate);
            this.Controls.Add(this.colnAccountingYear);
            this.Controls.Add(this.colnAccountingPeriod);
            this.Controls.Add(this.coldDateReg);
            this.Controls.Add(this.colsEnteredByUserGroup);
            this.Controls.Add(this.colsUserid);
            this.Controls.Add(this.colnSumDebetAmount);
            this.Controls.Add(this.colnSumCreditAmount);
            this.Controls.Add(this.colAmount);
            this.Controls.Add(this.colnSumThirdCurrDebetAmount);
            this.Controls.Add(this.colnSumThirdCurrCreditAmount);
            this.Controls.Add(this.colnSumThirdCurrAmount);
            this.Controls.Add(this.colVoucherText2);
            this.Controls.Add(this.colsFreeText);
            this.Controls.Add(this.colsInterimVoucher);
            this.Controls.Add(this.colsMultiCompanyId);
            this.Controls.Add(this.colsUserGroup);
            this.Controls.Add(this.ToolBar);
            this.Controls.Add(this.StatusBar);
            this.Name = "tbwVoucherApproval";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "COMPANY=:i_hWndFrame.tbwVoucherApproval.i_sCompany AND\r\nUSER_GROUP=:i_hWndFrame.t" +
                    "bwVoucherApproval.cmbUserGroup\r\n\r\n");
            this.NamedProperties.Put("LogicalUnit", "Voucher");
            this.NamedProperties.Put("PackageName", "VOUCHER_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "16513");
            this.NamedProperties.Put("ViewName", "VOUCHER_APPROVAL");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tbwVoucherApproval_WindowActions);
            this.Controls.SetChildIndex(this.StatusBar, 0);
            this.Controls.SetChildIndex(this.ToolBar, 0);
            this.Controls.SetChildIndex(this.colsUserGroup, 0);
            this.Controls.SetChildIndex(this.colsMultiCompanyId, 0);
            this.Controls.SetChildIndex(this.colsInterimVoucher, 0);
            this.Controls.SetChildIndex(this.colsFreeText, 0);
            this.Controls.SetChildIndex(this.colVoucherText2, 0);
            this.Controls.SetChildIndex(this.colnSumThirdCurrAmount, 0);
            this.Controls.SetChildIndex(this.colnSumThirdCurrCreditAmount, 0);
            this.Controls.SetChildIndex(this.colnSumThirdCurrDebetAmount, 0);
            this.Controls.SetChildIndex(this.colAmount, 0);
            this.Controls.SetChildIndex(this.colnSumCreditAmount, 0);
            this.Controls.SetChildIndex(this.colnSumDebetAmount, 0);
            this.Controls.SetChildIndex(this.colsUserid, 0);
            this.Controls.SetChildIndex(this.colsEnteredByUserGroup, 0);
            this.Controls.SetChildIndex(this.coldDateReg, 0);
            this.Controls.SetChildIndex(this.colnAccountingPeriod, 0);
            this.Controls.SetChildIndex(this.colnAccountingYear, 0);
            this.Controls.SetChildIndex(this.coldVoucherDate, 0);
            this.Controls.SetChildIndex(this.colnVoucherNo, 0);
            this.Controls.SetChildIndex(this.colsVoucherType, 0);
            this.Controls.SetChildIndex(this.colsVoucherStatus, 0);
            this.Controls.SetChildIndex(this.colsCompany, 0);
            this.Controls.SetChildIndex(this.@__colObjversion, 0);
            this.Controls.SetChildIndex(this.@__colObjid, 0);
            this.ToolBar.ResumeLayout(false);
            this.ToolBar.PerformLayout();
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

        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menuVoucher__Entry___;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menuApprove__Voucher___;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menu_Notes___;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menuChange__Company___;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTbwMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Voucher;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Approve;
        protected Fnd.Windows.Forms.FndToolStripSeparator menuSeparator1;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Notes;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change;
        protected  Ifs.Application.Accrul.cColumnFinEuro colnSumThirdCurrDebetAmount;
        protected  Ifs.Application.Accrul.cColumnFinEuro colnSumThirdCurrCreditAmount;
        protected cColumnFinEuro colnSumThirdCurrAmount;
	}
}
