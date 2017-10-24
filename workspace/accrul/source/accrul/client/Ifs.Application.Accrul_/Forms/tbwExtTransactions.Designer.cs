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
	
	public partial class tbwExtTransactions
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cColumn colCompany;
		// Bug 71024 , Begin , no need for PM_DataItemValidate since SetCorrection() is removed
		public cColumn colLoadId;
		// Bug 71024 , End
		public cColumn colRecordNo;
		public cColumn colRowState;
		public cColumn colLoadGroupItem;
		public cColumn colLoadError;
		public cColumn colTransactionDate;
		public cColumn colVoucherType;
		public cColumn colVoucherNo;
		public cColumn colAccountingYear;
		public cColumn colAccountingPeriod;
		public cColumn colsUserGroup;
		public cColumn colsUserId;
        public cColumnCodePartFin colAccount;
        public cColumnCodePartDescFin colAccountDesc;
        public cColumnCodePartFin colCodeB;
        public cColumnCodePartDescFin colCodeBDesc;
        public cColumnCodePartFin colCodeC;
        public cColumnCodePartDescFin colCodeCDesc;
        public cColumnCodePartFin colCodeD;
        public cColumnCodePartDescFin colCodeDDesc;
        public cColumnCodePartFin colCodeE;
        public cColumnCodePartDescFin colCodeEDesc;
        public cColumnCodePartFin colCodeF;
        public cColumnCodePartDescFin colCodeFDesc;
        public cColumnCodePartFin colCodeG;
        public cColumnCodePartDescFin colCodeGDesc;
        public cColumnCodePartFin colCodeH;
        public cColumnCodePartDescFin colCodeHDesc;
        public cColumnCodePartFin colCodeI;
        public cColumnCodePartDescFin colCodeIDesc;
        public cColumnCodePartFin colCodeJ;
        public cColumnCodePartDescFin colCodeJDesc;
		public cColumn colCurrencyCode;
        // Bug 71024 begin added new messages
		public cCheckBoxColumn colCorrection;
		// Bug 71024 end
		public cColumn colCurrencyDebetAmount;
		public cColumn colCurrencyCreditAmount;
		public cColumn colCurrencyAmount;
		public cColumn colDebetAmount;
		public cColumn colCreditAmount;
		public cColumn colAmount;
		public cColumn colQuantity;
		public cColumn colProcessCode;
        public cColumn colOptionalCode;
		public cColumn colnProjectActivityId;
		public cColumn colText;
		public cColumn colPartyTypeId;
		public cColumn colReferenceNumber;
		public cColumn colReferenceSerie;
		public cColumn colTransCode;
		public cColumn colExtAlterTrans;
		public cColumn colCodePartsDemand;
		// Bug 110830, Removed. colCodePart
		public cLookupColumn colsTaxDirection;
		public cColumn colnTaxAmount;
		public cColumn colnCurrencyTaxAmount;
		// Bug 74311 Start
		// Bug 71809 Start
		public cColumn coldVoucherDate;
		// Bug 71809 End
		// Bug 74311 End
        // Hidden fields
		public cColumn colsPrevTaxCode;
		// Bug 71024 Begin , not visible
		public cColumn colsCorrectionParam;
		public cColumn colsLoadType;
		// Bug 71024 End
		// Bug 92374 Begin , not visible
		public cColumn colsModifyCodestrCmpl;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwExtTransactions));
            this.menuTbwMethods_menu_Change_Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuOperations_menu_Change_Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.colCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colLoadId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colRecordNo = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colRowState = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colLoadGroupItem = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colLoadError = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colTransactionDate = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colVoucherType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colVoucherNo = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colAccountingYear = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colAccountingPeriod = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsUserGroup = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsUserId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colAccount = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.colAccountDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.colCodeB = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.colCodeBDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.colCodeC = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.colCodeCDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.colCodeD = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.colCodeDDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.colCodeE = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.colCodeEDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.colCodeF = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.colCodeFDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.colCodeG = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.colCodeGDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.colCodeH = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.colCodeHDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.colCodeI = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.colCodeIDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.colCodeJ = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.colCodeJDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.colCurrencyCode = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colCorrection = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.colCurrencyDebetAmount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colCurrencyCreditAmount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colCurrencyAmount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colDebetAmount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colCreditAmount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colAmount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colQuantity = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colProcessCode = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colOptionalCode = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colnProjectActivityId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colText = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colPartyTypeId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colReferenceNumber = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colReferenceSerie = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colTransCode = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colExtAlterTrans = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colCodePartsDemand = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsTaxDirection = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.colnTaxAmount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colnCurrencyTaxAmount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.coldVoucherDate = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsPrevTaxCode = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsCorrectionParam = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsLoadType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsModifyCodestrCmpl = new Ifs.Fnd.ApplicationForms.cColumn();
            this.menuOperations = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem__Change = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuTbwMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem__Change_1 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.coldEventDate = new Ifs.Fnd.ApplicationForms.cColumn();
            this.coldRetroactiveDate = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsTransactionReason = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colnThirdCurrencyDebitAmount = new Ifs.Application.Accrul.cColumnFinEuro();
            this.colnThirdCurrencyCreditAmount = new Ifs.Application.Accrul.cColumnFinEuro();
            this.colnThirdCurrencyAmount = new Ifs.Application.Accrul.cColumnFinEuro();
            this.colnThirdCurrencyTaxAmount = new Ifs.Application.Accrul.cColumnFinEuro();
            this.colsDelivTypeId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsDeliveryTypeDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colCurrencyRateType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsParallelCurrRateType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.menuOperations.SuspendLayout();
            this.menuTbwMethods.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuOperations_menu_Change_Company___);
            this.commandManager.Commands.Add(this.menuTbwMethods_menu_Change_Company___);
            this.commandManager.ContextMenus.Add(this.menuOperations);
            this.commandManager.ContextMenus.Add(this.menuTbwMethods);
            // 
            // menuTbwMethods_menu_Change_Company___
            // 
            resources.ApplyResources(this.menuTbwMethods_menu_Change_Company___, "menuTbwMethods_menu_Change_Company___");
            this.menuTbwMethods_menu_Change_Company___.Name = "menuTbwMethods_menu_Change_Company___";
            this.menuTbwMethods_menu_Change_Company___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Change_1_Execute);
            this.menuTbwMethods_menu_Change_Company___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Change_1_Inquire);
            // 
            // menuOperations_menu_Change_Company___
            // 
            resources.ApplyResources(this.menuOperations_menu_Change_Company___, "menuOperations_menu_Change_Company___");
            this.menuOperations_menu_Change_Company___.Name = "menuOperations_menu_Change_Company___";
            this.menuOperations_menu_Change_Company___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Change_Execute);
            this.menuOperations_menu_Change_Company___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Change_Inquire);
            // 
            // colCompany
            // 
            resources.ApplyResources(this.colCompany, "colCompany");
            this.colCompany.Name = "colCompany";
            this.colCompany.NamedProperties.Put("EnumerateMethod", "");
            this.colCompany.NamedProperties.Put("FieldFlags", "67");
            this.colCompany.NamedProperties.Put("LovReference", "");
            this.colCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.colCompany.NamedProperties.Put("ValidateMethod", "");
            this.colCompany.Position = 3;
            // 
            // colLoadId
            // 
            this.colLoadId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colLoadId.MaxLength = 20;
            this.colLoadId.Name = "colLoadId";
            this.colLoadId.NamedProperties.Put("EnumerateMethod", "");
            this.colLoadId.NamedProperties.Put("FieldFlags", "99");
            this.colLoadId.NamedProperties.Put("LovReference", "EXT_LOAD_INFO(COMPANY)");
            this.colLoadId.NamedProperties.Put("ResizeableChildObject", "");
            this.colLoadId.NamedProperties.Put("SqlColumn", "LOAD_ID");
            this.colLoadId.NamedProperties.Put("ValidateMethod", "");
            this.colLoadId.Position = 4;
            resources.ApplyResources(this.colLoadId, "colLoadId");
            // 
            // colRecordNo
            // 
            this.colRecordNo.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colRecordNo.Name = "colRecordNo";
            this.colRecordNo.NamedProperties.Put("EnumerateMethod", "");
            this.colRecordNo.NamedProperties.Put("FieldFlags", "160");
            this.colRecordNo.NamedProperties.Put("LovReference", "");
            this.colRecordNo.NamedProperties.Put("ResizeableChildObject", "");
            this.colRecordNo.NamedProperties.Put("SqlColumn", "RECORD_NO");
            this.colRecordNo.NamedProperties.Put("ValidateMethod", "");
            this.colRecordNo.Position = 5;
            resources.ApplyResources(this.colRecordNo, "colRecordNo");
            // 
            // colRowState
            // 
            this.colRowState.MaxLength = 20;
            this.colRowState.Name = "colRowState";
            this.colRowState.NamedProperties.Put("EnumerateMethod", "");
            this.colRowState.NamedProperties.Put("FieldFlags", "288");
            this.colRowState.NamedProperties.Put("LovReference", "");
            this.colRowState.NamedProperties.Put("ResizeableChildObject", "");
            this.colRowState.NamedProperties.Put("SqlColumn", "STATE");
            this.colRowState.NamedProperties.Put("ValidateMethod", "");
            this.colRowState.Position = 6;
            resources.ApplyResources(this.colRowState, "colRowState");
            // 
            // colLoadGroupItem
            // 
            this.colLoadGroupItem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colLoadGroupItem.MaxLength = 50;
            this.colLoadGroupItem.Name = "colLoadGroupItem";
            this.colLoadGroupItem.NamedProperties.Put("EnumerateMethod", "");
            this.colLoadGroupItem.NamedProperties.Put("FieldFlags", "295");
            this.colLoadGroupItem.NamedProperties.Put("LovReference", "");
            this.colLoadGroupItem.NamedProperties.Put("ResizeableChildObject", "");
            this.colLoadGroupItem.NamedProperties.Put("SqlColumn", "LOAD_GROUP_ITEM");
            this.colLoadGroupItem.NamedProperties.Put("ValidateMethod", "");
            this.colLoadGroupItem.Position = 7;
            resources.ApplyResources(this.colLoadGroupItem, "colLoadGroupItem");
            // 
            // colLoadError
            // 
            this.colLoadError.MaxLength = 2000;
            this.colLoadError.Name = "colLoadError";
            this.colLoadError.NamedProperties.Put("EnumerateMethod", "");
            this.colLoadError.NamedProperties.Put("FieldFlags", "304");
            this.colLoadError.NamedProperties.Put("LovReference", "");
            this.colLoadError.NamedProperties.Put("ResizeableChildObject", "");
            this.colLoadError.NamedProperties.Put("SqlColumn", "LOAD_ERROR");
            this.colLoadError.NamedProperties.Put("ValidateMethod", "");
            this.colLoadError.Position = 8;
            resources.ApplyResources(this.colLoadError, "colLoadError");
            // 
            // colTransactionDate
            // 
            this.colTransactionDate.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.colTransactionDate.Format = "d";
            this.colTransactionDate.Name = "colTransactionDate";
            this.colTransactionDate.NamedProperties.Put("EnumerateMethod", "");
            this.colTransactionDate.NamedProperties.Put("FieldFlags", "294");
            this.colTransactionDate.NamedProperties.Put("LovReference", "");
            this.colTransactionDate.NamedProperties.Put("SqlColumn", "TRANSACTION_DATE");
            this.colTransactionDate.NamedProperties.Put("ValidateMethod", "");
            this.colTransactionDate.Position = 9;
            resources.ApplyResources(this.colTransactionDate, "colTransactionDate");
            this.colTransactionDate.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colTransactionDate_WindowActions);
            // 
            // colVoucherType
            // 
            this.colVoucherType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colVoucherType.MaxLength = 3;
            this.colVoucherType.Name = "colVoucherType";
            this.colVoucherType.NamedProperties.Put("EnumerateMethod", "");
            this.colVoucherType.NamedProperties.Put("FieldFlags", "294");
            this.colVoucherType.NamedProperties.Put("LovReference", "VOUCHER_TYPE(COMPANY)");
            this.colVoucherType.NamedProperties.Put("SqlColumn", "VOUCHER_TYPE");
            this.colVoucherType.NamedProperties.Put("ValidateMethod", "");
            this.colVoucherType.Position = 10;
            resources.ApplyResources(this.colVoucherType, "colVoucherType");
            this.colVoucherType.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colVoucherType_WindowActions);
            // 
            // colVoucherNo
            // 
            this.colVoucherNo.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colVoucherNo.MaxLength = 10;
            this.colVoucherNo.Name = "colVoucherNo";
            this.colVoucherNo.NamedProperties.Put("EnumerateMethod", "");
            this.colVoucherNo.NamedProperties.Put("FieldFlags", "294");
            this.colVoucherNo.NamedProperties.Put("LovReference", "");
            this.colVoucherNo.NamedProperties.Put("SqlColumn", "VOUCHER_NO");
            this.colVoucherNo.NamedProperties.Put("ValidateMethod", "");
            this.colVoucherNo.Position = 11;
            resources.ApplyResources(this.colVoucherNo, "colVoucherNo");
            // 
            // colAccountingYear
            // 
            this.colAccountingYear.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colAccountingYear.MaxLength = 4;
            this.colAccountingYear.Name = "colAccountingYear";
            this.colAccountingYear.NamedProperties.Put("EnumerateMethod", "");
            this.colAccountingYear.NamedProperties.Put("FieldFlags", "294");
            this.colAccountingYear.NamedProperties.Put("LovReference", "");
            this.colAccountingYear.NamedProperties.Put("SqlColumn", "ACCOUNTING_YEAR");
            this.colAccountingYear.NamedProperties.Put("ValidateMethod", "");
            this.colAccountingYear.Position = 12;
            resources.ApplyResources(this.colAccountingYear, "colAccountingYear");
            this.colAccountingYear.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colAccountingYear_WindowActions);
            // 
            // colAccountingPeriod
            // 
            this.colAccountingPeriod.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colAccountingPeriod.MaxLength = 3;
            this.colAccountingPeriod.Name = "colAccountingPeriod";
            this.colAccountingPeriod.NamedProperties.Put("EnumerateMethod", "");
            this.colAccountingPeriod.NamedProperties.Put("FieldFlags", "288");
            this.colAccountingPeriod.NamedProperties.Put("LovReference", "");
            this.colAccountingPeriod.NamedProperties.Put("ResizeableChildObject", "");
            this.colAccountingPeriod.NamedProperties.Put("SqlColumn", "ACCOUNTING_PERIOD");
            this.colAccountingPeriod.NamedProperties.Put("ValidateMethod", "");
            this.colAccountingPeriod.Position = 13;
            resources.ApplyResources(this.colAccountingPeriod, "colAccountingPeriod");
            // 
            // colsUserGroup
            // 
            this.colsUserGroup.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsUserGroup.MaxLength = 30;
            this.colsUserGroup.Name = "colsUserGroup";
            this.colsUserGroup.NamedProperties.Put("EnumerateMethod", "");
            this.colsUserGroup.NamedProperties.Put("FieldFlags", "294");
            this.colsUserGroup.NamedProperties.Put("LovReference", "USER_GROUP_MEMBER_FINANCE4(COMPANY, USER_ID)");
            this.colsUserGroup.NamedProperties.Put("ResizeableChildObject", "");
            this.colsUserGroup.NamedProperties.Put("SqlColumn", "USER_GROUP");
            this.colsUserGroup.NamedProperties.Put("ValidateMethod", "");
            this.colsUserGroup.Position = 14;
            resources.ApplyResources(this.colsUserGroup, "colsUserGroup");
            this.colsUserGroup.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsUserGroup_WindowActions);
            // 
            // colsUserId
            // 
            this.colsUserId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.colsUserId, "colsUserId");
            this.colsUserId.Name = "colsUserId";
            this.colsUserId.NamedProperties.Put("EnumerateMethod", "");
            this.colsUserId.NamedProperties.Put("FieldFlags", "262");
            this.colsUserId.NamedProperties.Put("LovReference", "");
            this.colsUserId.NamedProperties.Put("ResizeableChildObject", "");
            this.colsUserId.NamedProperties.Put("SqlColumn", "USER_ID");
            this.colsUserId.NamedProperties.Put("ValidateMethod", "");
            this.colsUserId.Position = 15;
            // 
            // colAccount
            // 
            this.colAccount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colAccount.MaxLength = 20;
            this.colAccount.Name = "colAccount";
            this.colAccount.NamedProperties.Put("EnumerateMethod", "");
            this.colAccount.NamedProperties.Put("FieldFlags", "295");
            this.colAccount.NamedProperties.Put("LovReference", "ACCOUNT(COMPANY)");
            this.colAccount.NamedProperties.Put("ResizeableChildObject", "");
            this.colAccount.NamedProperties.Put("SqlColumn", "ACCOUNT");
            this.colAccount.NamedProperties.Put("ValidateMethod", "");
            this.colAccount.Position = 16;
            resources.ApplyResources(this.colAccount, "colAccount");
            this.colAccount.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colAccount_WindowActions);
            // 
            // colAccountDesc
            // 
            this.colAccountDesc.Name = "colAccountDesc";
            this.colAccountDesc.NamedProperties.Put("EnumerateMethod", "");
            this.colAccountDesc.NamedProperties.Put("FieldFlags", "2304");
            this.colAccountDesc.NamedProperties.Put("LovReference", "");
            this.colAccountDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.colAccountDesc.NamedProperties.Put("SqlColumn", "CODE_A_DESC");
            this.colAccountDesc.NamedProperties.Put("ValidateMethod", "");
            this.colAccountDesc.Position = 17;
            resources.ApplyResources(this.colAccountDesc, "colAccountDesc");
            // 
            // colCodeB
            // 
            this.colCodeB.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colCodeB.MaxLength = 20;
            this.colCodeB.Name = "colCodeB";
            this.colCodeB.NamedProperties.Put("EnumerateMethod", "");
            this.colCodeB.NamedProperties.Put("FieldFlags", "294");
            this.colCodeB.NamedProperties.Put("LovReference", "CODE_B(COMPANY)");
            this.colCodeB.NamedProperties.Put("ResizeableChildObject", "");
            this.colCodeB.NamedProperties.Put("SqlColumn", "CODE_B");
            this.colCodeB.NamedProperties.Put("ValidateMethod", "");
            this.colCodeB.Position = 18;
            resources.ApplyResources(this.colCodeB, "colCodeB");
            this.colCodeB.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colCodeB_WindowActions);
            // 
            // colCodeBDesc
            // 
            this.colCodeBDesc.Name = "colCodeBDesc";
            this.colCodeBDesc.NamedProperties.Put("EnumerateMethod", "");
            this.colCodeBDesc.NamedProperties.Put("FieldFlags", "2304");
            this.colCodeBDesc.NamedProperties.Put("LovReference", "");
            this.colCodeBDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.colCodeBDesc.NamedProperties.Put("SqlColumn", "CODE_B_DESC");
            this.colCodeBDesc.NamedProperties.Put("ValidateMethod", "");
            this.colCodeBDesc.Position = 19;
            resources.ApplyResources(this.colCodeBDesc, "colCodeBDesc");
            this.colCodeBDesc.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colCodeBDesc_WindowActions);
            // 
            // colCodeC
            // 
            this.colCodeC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colCodeC.MaxLength = 20;
            this.colCodeC.Name = "colCodeC";
            this.colCodeC.NamedProperties.Put("EnumerateMethod", "");
            this.colCodeC.NamedProperties.Put("FieldFlags", "294");
            this.colCodeC.NamedProperties.Put("LovReference", "CODE_C(COMPANY)");
            this.colCodeC.NamedProperties.Put("ResizeableChildObject", "");
            this.colCodeC.NamedProperties.Put("SqlColumn", "CODE_C");
            this.colCodeC.NamedProperties.Put("ValidateMethod", "");
            this.colCodeC.Position = 20;
            resources.ApplyResources(this.colCodeC, "colCodeC");
            this.colCodeC.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colCodeC_WindowActions);
            // 
            // colCodeCDesc
            // 
            this.colCodeCDesc.Name = "colCodeCDesc";
            this.colCodeCDesc.NamedProperties.Put("EnumerateMethod", "");
            this.colCodeCDesc.NamedProperties.Put("FieldFlags", "2304");
            this.colCodeCDesc.NamedProperties.Put("LovReference", "");
            this.colCodeCDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.colCodeCDesc.NamedProperties.Put("SqlColumn", "CODE_C_DESC");
            this.colCodeCDesc.NamedProperties.Put("ValidateMethod", "");
            this.colCodeCDesc.Position = 21;
            resources.ApplyResources(this.colCodeCDesc, "colCodeCDesc");
            this.colCodeCDesc.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colCodeCDesc_WindowActions);
            // 
            // colCodeD
            // 
            this.colCodeD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colCodeD.MaxLength = 20;
            this.colCodeD.Name = "colCodeD";
            this.colCodeD.NamedProperties.Put("EnumerateMethod", "");
            this.colCodeD.NamedProperties.Put("FieldFlags", "294");
            this.colCodeD.NamedProperties.Put("LovReference", "CODE_D(COMPANY)");
            this.colCodeD.NamedProperties.Put("ResizeableChildObject", "");
            this.colCodeD.NamedProperties.Put("SqlColumn", "CODE_D");
            this.colCodeD.NamedProperties.Put("ValidateMethod", "");
            this.colCodeD.Position = 22;
            resources.ApplyResources(this.colCodeD, "colCodeD");
            this.colCodeD.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colCodeD_WindowActions);
            // 
            // colCodeDDesc
            // 
            this.colCodeDDesc.Name = "colCodeDDesc";
            this.colCodeDDesc.NamedProperties.Put("EnumerateMethod", "");
            this.colCodeDDesc.NamedProperties.Put("FieldFlags", "2304");
            this.colCodeDDesc.NamedProperties.Put("LovReference", "");
            this.colCodeDDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.colCodeDDesc.NamedProperties.Put("SqlColumn", "CODE_D_DESC");
            this.colCodeDDesc.NamedProperties.Put("ValidateMethod", "");
            this.colCodeDDesc.Position = 23;
            resources.ApplyResources(this.colCodeDDesc, "colCodeDDesc");
            this.colCodeDDesc.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colCodeDDesc_WindowActions);
            // 
            // colCodeE
            // 
            this.colCodeE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colCodeE.MaxLength = 20;
            this.colCodeE.Name = "colCodeE";
            this.colCodeE.NamedProperties.Put("EnumerateMethod", "");
            this.colCodeE.NamedProperties.Put("FieldFlags", "294");
            this.colCodeE.NamedProperties.Put("LovReference", "CODE_E(COMPANY)");
            this.colCodeE.NamedProperties.Put("ResizeableChildObject", "");
            this.colCodeE.NamedProperties.Put("SqlColumn", "CODE_E");
            this.colCodeE.NamedProperties.Put("ValidateMethod", "");
            this.colCodeE.Position = 24;
            resources.ApplyResources(this.colCodeE, "colCodeE");
            this.colCodeE.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colCodeE_WindowActions);
            // 
            // colCodeEDesc
            // 
            this.colCodeEDesc.Name = "colCodeEDesc";
            this.colCodeEDesc.NamedProperties.Put("EnumerateMethod", "");
            this.colCodeEDesc.NamedProperties.Put("FieldFlags", "2304");
            this.colCodeEDesc.NamedProperties.Put("LovReference", "");
            this.colCodeEDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.colCodeEDesc.NamedProperties.Put("SqlColumn", "CODE_E_DESC");
            this.colCodeEDesc.NamedProperties.Put("ValidateMethod", "");
            this.colCodeEDesc.Position = 25;
            resources.ApplyResources(this.colCodeEDesc, "colCodeEDesc");
            this.colCodeEDesc.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colCodeEDesc_WindowActions);
            // 
            // colCodeF
            // 
            this.colCodeF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colCodeF.MaxLength = 20;
            this.colCodeF.Name = "colCodeF";
            this.colCodeF.NamedProperties.Put("EnumerateMethod", "");
            this.colCodeF.NamedProperties.Put("FieldFlags", "294");
            this.colCodeF.NamedProperties.Put("LovReference", "CODE_F(COMPANY)");
            this.colCodeF.NamedProperties.Put("ResizeableChildObject", "");
            this.colCodeF.NamedProperties.Put("SqlColumn", "CODE_F");
            this.colCodeF.NamedProperties.Put("ValidateMethod", "");
            this.colCodeF.Position = 26;
            resources.ApplyResources(this.colCodeF, "colCodeF");
            this.colCodeF.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colCodeF_WindowActions);
            // 
            // colCodeFDesc
            // 
            this.colCodeFDesc.Name = "colCodeFDesc";
            this.colCodeFDesc.NamedProperties.Put("EnumerateMethod", "");
            this.colCodeFDesc.NamedProperties.Put("FieldFlags", "2304");
            this.colCodeFDesc.NamedProperties.Put("LovReference", "");
            this.colCodeFDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.colCodeFDesc.NamedProperties.Put("SqlColumn", "CODE_F_DESC");
            this.colCodeFDesc.NamedProperties.Put("ValidateMethod", "");
            this.colCodeFDesc.Position = 27;
            resources.ApplyResources(this.colCodeFDesc, "colCodeFDesc");
            this.colCodeFDesc.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colCodeFDesc_WindowActions);
            // 
            // colCodeG
            // 
            this.colCodeG.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colCodeG.MaxLength = 20;
            this.colCodeG.Name = "colCodeG";
            this.colCodeG.NamedProperties.Put("EnumerateMethod", "");
            this.colCodeG.NamedProperties.Put("FieldFlags", "294");
            this.colCodeG.NamedProperties.Put("LovReference", "CODE_G(COMPANY)");
            this.colCodeG.NamedProperties.Put("ResizeableChildObject", "");
            this.colCodeG.NamedProperties.Put("SqlColumn", "CODE_G");
            this.colCodeG.NamedProperties.Put("ValidateMethod", "");
            this.colCodeG.Position = 28;
            resources.ApplyResources(this.colCodeG, "colCodeG");
            this.colCodeG.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colCodeG_WindowActions);
            // 
            // colCodeGDesc
            // 
            this.colCodeGDesc.Name = "colCodeGDesc";
            this.colCodeGDesc.NamedProperties.Put("EnumerateMethod", "");
            this.colCodeGDesc.NamedProperties.Put("FieldFlags", "2304");
            this.colCodeGDesc.NamedProperties.Put("LovReference", "");
            this.colCodeGDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.colCodeGDesc.NamedProperties.Put("SqlColumn", "CODE_G_DESC");
            this.colCodeGDesc.NamedProperties.Put("ValidateMethod", "");
            this.colCodeGDesc.Position = 29;
            resources.ApplyResources(this.colCodeGDesc, "colCodeGDesc");
            this.colCodeGDesc.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colCodeGDesc_WindowActions);
            // 
            // colCodeH
            // 
            this.colCodeH.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colCodeH.MaxLength = 20;
            this.colCodeH.Name = "colCodeH";
            this.colCodeH.NamedProperties.Put("EnumerateMethod", "");
            this.colCodeH.NamedProperties.Put("FieldFlags", "294");
            this.colCodeH.NamedProperties.Put("LovReference", "CODE_H(COMPANY)");
            this.colCodeH.NamedProperties.Put("ResizeableChildObject", "");
            this.colCodeH.NamedProperties.Put("SqlColumn", "CODE_H");
            this.colCodeH.NamedProperties.Put("ValidateMethod", "");
            this.colCodeH.Position = 30;
            resources.ApplyResources(this.colCodeH, "colCodeH");
            this.colCodeH.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colCodeH_WindowActions);
            // 
            // colCodeHDesc
            // 
            this.colCodeHDesc.Name = "colCodeHDesc";
            this.colCodeHDesc.NamedProperties.Put("EnumerateMethod", "");
            this.colCodeHDesc.NamedProperties.Put("FieldFlags", "2304");
            this.colCodeHDesc.NamedProperties.Put("LovReference", "");
            this.colCodeHDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.colCodeHDesc.NamedProperties.Put("SqlColumn", "CODE_H_DESC");
            this.colCodeHDesc.NamedProperties.Put("ValidateMethod", "");
            this.colCodeHDesc.Position = 31;
            resources.ApplyResources(this.colCodeHDesc, "colCodeHDesc");
            this.colCodeHDesc.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colCodeHDesc_WindowActions);
            // 
            // colCodeI
            // 
            this.colCodeI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colCodeI.MaxLength = 20;
            this.colCodeI.Name = "colCodeI";
            this.colCodeI.NamedProperties.Put("EnumerateMethod", "");
            this.colCodeI.NamedProperties.Put("FieldFlags", "294");
            this.colCodeI.NamedProperties.Put("LovReference", "CODE_I(COMPANY)");
            this.colCodeI.NamedProperties.Put("ResizeableChildObject", "");
            this.colCodeI.NamedProperties.Put("SqlColumn", "CODE_I");
            this.colCodeI.NamedProperties.Put("ValidateMethod", "");
            this.colCodeI.Position = 32;
            resources.ApplyResources(this.colCodeI, "colCodeI");
            this.colCodeI.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colCodeI_WindowActions);
            // 
            // colCodeIDesc
            // 
            this.colCodeIDesc.Name = "colCodeIDesc";
            this.colCodeIDesc.NamedProperties.Put("EnumerateMethod", "");
            this.colCodeIDesc.NamedProperties.Put("FieldFlags", "2304");
            this.colCodeIDesc.NamedProperties.Put("LovReference", "");
            this.colCodeIDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.colCodeIDesc.NamedProperties.Put("SqlColumn", "CODE_I_DESC");
            this.colCodeIDesc.NamedProperties.Put("ValidateMethod", "");
            this.colCodeIDesc.Position = 33;
            resources.ApplyResources(this.colCodeIDesc, "colCodeIDesc");
            this.colCodeIDesc.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colCodeIDesc_WindowActions);
            // 
            // colCodeJ
            // 
            this.colCodeJ.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colCodeJ.MaxLength = 20;
            this.colCodeJ.Name = "colCodeJ";
            this.colCodeJ.NamedProperties.Put("EnumerateMethod", "");
            this.colCodeJ.NamedProperties.Put("FieldFlags", "294");
            this.colCodeJ.NamedProperties.Put("LovReference", "CODE_J(COMPANY)");
            this.colCodeJ.NamedProperties.Put("ResizeableChildObject", "");
            this.colCodeJ.NamedProperties.Put("SqlColumn", "CODE_J");
            this.colCodeJ.NamedProperties.Put("ValidateMethod", "");
            this.colCodeJ.Position = 34;
            resources.ApplyResources(this.colCodeJ, "colCodeJ");
            this.colCodeJ.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colCodeJ_WindowActions);
            // 
            // colCodeJDesc
            // 
            this.colCodeJDesc.Name = "colCodeJDesc";
            this.colCodeJDesc.NamedProperties.Put("EnumerateMethod", "");
            this.colCodeJDesc.NamedProperties.Put("FieldFlags", "2304");
            this.colCodeJDesc.NamedProperties.Put("LovReference", "");
            this.colCodeJDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.colCodeJDesc.NamedProperties.Put("SqlColumn", "CODE_J_DESC");
            this.colCodeJDesc.NamedProperties.Put("ValidateMethod", "");
            this.colCodeJDesc.Position = 35;
            resources.ApplyResources(this.colCodeJDesc, "colCodeJDesc");
            this.colCodeJDesc.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colCodeJDesc_WindowActions);
            // 
            // colCurrencyCode
            // 
            this.colCurrencyCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colCurrencyCode.MaxLength = 3;
            this.colCurrencyCode.Name = "colCurrencyCode";
            this.colCurrencyCode.NamedProperties.Put("EnumerateMethod", "");
            this.colCurrencyCode.NamedProperties.Put("FieldFlags", "295");
            this.colCurrencyCode.NamedProperties.Put("LovReference", "CURRENCY_CODE(COMPANY)");
            this.colCurrencyCode.NamedProperties.Put("SqlColumn", "CURRENCY_CODE");
            this.colCurrencyCode.NamedProperties.Put("ValidateMethod", "");
            this.colCurrencyCode.Position = 36;
            resources.ApplyResources(this.colCurrencyCode, "colCurrencyCode");
            this.colCurrencyCode.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colCurrencyCode_WindowActions);
            // 
            // colCorrection
            // 
            this.colCorrection.MaxLength = 5;
            this.colCorrection.Name = "colCorrection";
            this.colCorrection.NamedProperties.Put("EnumerateMethod", "");
            this.colCorrection.NamedProperties.Put("FieldFlags", "290");
            this.colCorrection.NamedProperties.Put("LovReference", "");
            this.colCorrection.NamedProperties.Put("ResizeableChildObject", "");
            this.colCorrection.NamedProperties.Put("SqlColumn", "CORRECTION");
            this.colCorrection.NamedProperties.Put("ValidateMethod", "");
            this.colCorrection.Position = 39;
            resources.ApplyResources(this.colCorrection, "colCorrection");
            this.colCorrection.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colCorrection_WindowActions);
            // 
            // colCurrencyDebetAmount
            // 
            this.colCurrencyDebetAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colCurrencyDebetAmount.MaxLength = 15;
            this.colCurrencyDebetAmount.Name = "colCurrencyDebetAmount";
            this.colCurrencyDebetAmount.NamedProperties.Put("EnumerateMethod", "");
            this.colCurrencyDebetAmount.NamedProperties.Put("FieldFlags", "294");
            this.colCurrencyDebetAmount.NamedProperties.Put("Format", "20");
            this.colCurrencyDebetAmount.NamedProperties.Put("LovReference", "");
            this.colCurrencyDebetAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.colCurrencyDebetAmount.NamedProperties.Put("SqlColumn", "CURRENCY_DEBET_AMOUNT");
            this.colCurrencyDebetAmount.NamedProperties.Put("ValidateMethod", "");
            this.colCurrencyDebetAmount.Position = 40;
            this.colCurrencyDebetAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.colCurrencyDebetAmount, "colCurrencyDebetAmount");
            this.colCurrencyDebetAmount.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colCurrencyDebetAmount_WindowActions);
            // 
            // colCurrencyCreditAmount
            // 
            this.colCurrencyCreditAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colCurrencyCreditAmount.MaxLength = 15;
            this.colCurrencyCreditAmount.Name = "colCurrencyCreditAmount";
            this.colCurrencyCreditAmount.NamedProperties.Put("EnumerateMethod", "");
            this.colCurrencyCreditAmount.NamedProperties.Put("FieldFlags", "294");
            this.colCurrencyCreditAmount.NamedProperties.Put("Format", "20");
            this.colCurrencyCreditAmount.NamedProperties.Put("LovReference", "");
            this.colCurrencyCreditAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.colCurrencyCreditAmount.NamedProperties.Put("SqlColumn", "CURRENCY_CREDIT_AMOUNT");
            this.colCurrencyCreditAmount.NamedProperties.Put("ValidateMethod", "");
            this.colCurrencyCreditAmount.Position = 41;
            this.colCurrencyCreditAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.colCurrencyCreditAmount, "colCurrencyCreditAmount");
            this.colCurrencyCreditAmount.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colCurrencyCreditAmount_WindowActions);
            // 
            // colCurrencyAmount
            // 
            this.colCurrencyAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colCurrencyAmount.MaxLength = 15;
            this.colCurrencyAmount.Name = "colCurrencyAmount";
            this.colCurrencyAmount.NamedProperties.Put("EnumerateMethod", "");
            this.colCurrencyAmount.NamedProperties.Put("FieldFlags", "294");
            this.colCurrencyAmount.NamedProperties.Put("Format", "20");
            this.colCurrencyAmount.NamedProperties.Put("LovReference", "");
            this.colCurrencyAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.colCurrencyAmount.NamedProperties.Put("SqlColumn", "CURRENCY_AMOUNT");
            this.colCurrencyAmount.NamedProperties.Put("ValidateMethod", "");
            this.colCurrencyAmount.Position = 42;
            this.colCurrencyAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.colCurrencyAmount, "colCurrencyAmount");
            this.colCurrencyAmount.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colCurrencyAmount_WindowActions);
            // 
            // colDebetAmount
            // 
            this.colDebetAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colDebetAmount.MaxLength = 15;
            this.colDebetAmount.Name = "colDebetAmount";
            this.colDebetAmount.NamedProperties.Put("EnumerateMethod", "");
            this.colDebetAmount.NamedProperties.Put("FieldFlags", "294");
            this.colDebetAmount.NamedProperties.Put("Format", "20");
            this.colDebetAmount.NamedProperties.Put("LovReference", "");
            this.colDebetAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.colDebetAmount.NamedProperties.Put("SqlColumn", "DEBET_AMOUNT");
            this.colDebetAmount.NamedProperties.Put("ValidateMethod", "");
            this.colDebetAmount.Position = 43;
            this.colDebetAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.colDebetAmount, "colDebetAmount");
            this.colDebetAmount.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colDebetAmount_WindowActions);
            // 
            // colCreditAmount
            // 
            this.colCreditAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colCreditAmount.MaxLength = 15;
            this.colCreditAmount.Name = "colCreditAmount";
            this.colCreditAmount.NamedProperties.Put("EnumerateMethod", "");
            this.colCreditAmount.NamedProperties.Put("FieldFlags", "294");
            this.colCreditAmount.NamedProperties.Put("Format", "20");
            this.colCreditAmount.NamedProperties.Put("LovReference", "");
            this.colCreditAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.colCreditAmount.NamedProperties.Put("SqlColumn", "CREDIT_AMOUNT");
            this.colCreditAmount.NamedProperties.Put("ValidateMethod", "");
            this.colCreditAmount.Position = 44;
            this.colCreditAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.colCreditAmount, "colCreditAmount");
            this.colCreditAmount.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colCreditAmount_WindowActions);
            // 
            // colAmount
            // 
            this.colAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colAmount.MaxLength = 15;
            this.colAmount.Name = "colAmount";
            this.colAmount.NamedProperties.Put("EnumerateMethod", "");
            this.colAmount.NamedProperties.Put("FieldFlags", "295");
            this.colAmount.NamedProperties.Put("Format", "20");
            this.colAmount.NamedProperties.Put("LovReference", "");
            this.colAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.colAmount.NamedProperties.Put("SqlColumn", "AMOUNT");
            this.colAmount.NamedProperties.Put("ValidateMethod", "");
            this.colAmount.Position = 45;
            this.colAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.colAmount, "colAmount");
            this.colAmount.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colAmount_WindowActions);
            // 
            // colQuantity
            // 
            this.colQuantity.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.NamedProperties.Put("EnumerateMethod", "");
            this.colQuantity.NamedProperties.Put("FieldFlags", "294");
            this.colQuantity.NamedProperties.Put("LovReference", "");
            this.colQuantity.NamedProperties.Put("SqlColumn", "QUANTITY");
            this.colQuantity.NamedProperties.Put("ValidateMethod", "");
            this.colQuantity.Position = 49;
            this.colQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.colQuantity, "colQuantity");
            // 
            // colProcessCode
            // 
            this.colProcessCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colProcessCode.MaxLength = 10;
            this.colProcessCode.Name = "colProcessCode";
            this.colProcessCode.NamedProperties.Put("EnumerateMethod", "");
            this.colProcessCode.NamedProperties.Put("FieldFlags", "294");
            this.colProcessCode.NamedProperties.Put("LovReference", "ACCOUNT_PROCESS_CODE(COMPANY)");
            this.colProcessCode.NamedProperties.Put("ResizeableChildObject", "");
            this.colProcessCode.NamedProperties.Put("SqlColumn", "PROCESS_CODE");
            this.colProcessCode.NamedProperties.Put("ValidateMethod", "");
            this.colProcessCode.Position = 50;
            resources.ApplyResources(this.colProcessCode, "colProcessCode");
            // 
            // colOptionalCode
            // 
            this.colOptionalCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colOptionalCode.MaxLength = 20;
            this.colOptionalCode.Name = "colOptionalCode";
            this.colOptionalCode.NamedProperties.Put("EnumerateMethod", "");
            this.colOptionalCode.NamedProperties.Put("FieldFlags", "294");
            this.colOptionalCode.NamedProperties.Put("LovReference", "STATUTORY_FEE_DEDUCT_MULTIPLE(COMPANY)");
            this.colOptionalCode.NamedProperties.Put("ResizeableChildObject", "");
            this.colOptionalCode.NamedProperties.Put("SqlColumn", "OPTIONAL_CODE");
            this.colOptionalCode.NamedProperties.Put("ValidateMethod", "");
            this.colOptionalCode.Position = 53;
            resources.ApplyResources(this.colOptionalCode, "colOptionalCode");
            this.colOptionalCode.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colOptionalCode_WindowActions);
            // 
            // colnProjectActivityId
            // 
            this.colnProjectActivityId.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colnProjectActivityId.Name = "colnProjectActivityId";
            this.colnProjectActivityId.NamedProperties.Put("EnumerateMethod", "");
            this.colnProjectActivityId.NamedProperties.Put("FieldFlags", "294");
            this.colnProjectActivityId.NamedProperties.Put("LovReference", "PROJECT_ACTIVITY_POSTABLE(PROJECT_ID)");
            this.colnProjectActivityId.NamedProperties.Put("ResizeableChildObject", "");
            this.colnProjectActivityId.NamedProperties.Put("SqlColumn", "PROJECT_ACTIVITY_ID");
            this.colnProjectActivityId.NamedProperties.Put("ValidateMethod", "");
            this.colnProjectActivityId.Position = 58;
            resources.ApplyResources(this.colnProjectActivityId, "colnProjectActivityId");
            this.colnProjectActivityId.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colnProjectActivityId_WindowActions);
            // 
            // colText
            // 
            this.colText.MaxLength = 200;
            this.colText.Name = "colText";
            this.colText.NamedProperties.Put("EnumerateMethod", "");
            this.colText.NamedProperties.Put("FieldFlags", "294");
            this.colText.NamedProperties.Put("LovReference", "");
            this.colText.NamedProperties.Put("ResizeableChildObject", "");
            this.colText.NamedProperties.Put("SqlColumn", "TEXT");
            this.colText.NamedProperties.Put("ValidateMethod", "");
            this.colText.Position = 59;
            resources.ApplyResources(this.colText, "colText");
            // 
            // colPartyTypeId
            // 
            this.colPartyTypeId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colPartyTypeId.MaxLength = 20;
            this.colPartyTypeId.Name = "colPartyTypeId";
            this.colPartyTypeId.NamedProperties.Put("EnumerateMethod", "");
            this.colPartyTypeId.NamedProperties.Put("FieldFlags", "294");
            this.colPartyTypeId.NamedProperties.Put("LovReference", "");
            this.colPartyTypeId.NamedProperties.Put("ResizeableChildObject", "");
            this.colPartyTypeId.NamedProperties.Put("SqlColumn", "PARTY_TYPE_ID");
            this.colPartyTypeId.NamedProperties.Put("ValidateMethod", "");
            this.colPartyTypeId.Position = 60;
            resources.ApplyResources(this.colPartyTypeId, "colPartyTypeId");
            // 
            // colReferenceNumber
            // 
            this.colReferenceNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colReferenceNumber.MaxLength = 50;
            this.colReferenceNumber.Name = "colReferenceNumber";
            this.colReferenceNumber.NamedProperties.Put("EnumerateMethod", "");
            this.colReferenceNumber.NamedProperties.Put("FieldFlags", "294");
            this.colReferenceNumber.NamedProperties.Put("LovReference", "");
            this.colReferenceNumber.NamedProperties.Put("SqlColumn", "REFERENCE_NUMBER");
            this.colReferenceNumber.NamedProperties.Put("ValidateMethod", "");
            this.colReferenceNumber.Position = 61;
            resources.ApplyResources(this.colReferenceNumber, "colReferenceNumber");
            // 
            // colReferenceSerie
            // 
            this.colReferenceSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colReferenceSerie.MaxLength = 50;
            this.colReferenceSerie.Name = "colReferenceSerie";
            this.colReferenceSerie.NamedProperties.Put("EnumerateMethod", "");
            this.colReferenceSerie.NamedProperties.Put("FieldFlags", "294");
            this.colReferenceSerie.NamedProperties.Put("LovReference", "");
            this.colReferenceSerie.NamedProperties.Put("SqlColumn", "REFERENCE_SERIE");
            this.colReferenceSerie.NamedProperties.Put("ValidateMethod", "");
            this.colReferenceSerie.Position = 62;
            resources.ApplyResources(this.colReferenceSerie, "colReferenceSerie");
            // 
            // colTransCode
            // 
            this.colTransCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colTransCode.Name = "colTransCode";
            this.colTransCode.NamedProperties.Put("EnumerateMethod", "");
            this.colTransCode.NamedProperties.Put("FieldFlags", "294");
            this.colTransCode.NamedProperties.Put("LovReference", "");
            this.colTransCode.NamedProperties.Put("SqlColumn", "TRANS_CODE");
            this.colTransCode.NamedProperties.Put("ValidateMethod", "");
            this.colTransCode.Position = 63;
            resources.ApplyResources(this.colTransCode, "colTransCode");
            // 
            // colExtAlterTrans
            // 
            this.colExtAlterTrans.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.colExtAlterTrans, "colExtAlterTrans");
            this.colExtAlterTrans.MaxLength = 10;
            this.colExtAlterTrans.Name = "colExtAlterTrans";
            this.colExtAlterTrans.NamedProperties.Put("EnumerateMethod", "");
            this.colExtAlterTrans.NamedProperties.Put("FieldFlags", "4352");
            this.colExtAlterTrans.NamedProperties.Put("LovReference", "");
            this.colExtAlterTrans.NamedProperties.Put("SqlColumn", "EXT_ALTER_TRANS");
            this.colExtAlterTrans.NamedProperties.Put("ValidateMethod", "");
            this.colExtAlterTrans.Position = 64;
            // 
            // colCodePartsDemand
            // 
            resources.ApplyResources(this.colCodePartsDemand, "colCodePartsDemand");
            this.colCodePartsDemand.Name = "colCodePartsDemand";
            this.colCodePartsDemand.NamedProperties.Put("EnumerateMethod", "");
            this.colCodePartsDemand.NamedProperties.Put("LovReference", "");
            this.colCodePartsDemand.NamedProperties.Put("SqlColumn", "DEMAND_STRING");
            this.colCodePartsDemand.NamedProperties.Put("ValidateMethod", "");
            this.colCodePartsDemand.Position = 65;
            // 
            // colsTaxDirection
            // 
            this.colsTaxDirection.MaxLength = 20;
            this.colsTaxDirection.Name = "colsTaxDirection";
            this.colsTaxDirection.NamedProperties.Put("EnumerateMethod", "TAX_DIRECTION_API.Enumerate");
            this.colsTaxDirection.NamedProperties.Put("FieldFlags", "294");
            this.colsTaxDirection.NamedProperties.Put("LovReference", "");
            this.colsTaxDirection.NamedProperties.Put("ResizeableChildObject", "");
            this.colsTaxDirection.NamedProperties.Put("SqlColumn", "TAX_DIRECTION");
            this.colsTaxDirection.NamedProperties.Put("ValidateMethod", "");
            this.colsTaxDirection.Position = 54;
            resources.ApplyResources(this.colsTaxDirection, "colsTaxDirection");
            this.colsTaxDirection.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsTaxDirection_WindowActions);
            // 
            // colnTaxAmount
            // 
            this.colnTaxAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colnTaxAmount.Name = "colnTaxAmount";
            this.colnTaxAmount.NamedProperties.Put("EnumerateMethod", "");
            this.colnTaxAmount.NamedProperties.Put("FieldFlags", "294");
            this.colnTaxAmount.NamedProperties.Put("Format", "20");
            this.colnTaxAmount.NamedProperties.Put("LovReference", "");
            this.colnTaxAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.colnTaxAmount.NamedProperties.Put("SqlColumn", "TAX_AMOUNT");
            this.colnTaxAmount.NamedProperties.Put("ValidateMethod", "");
            this.colnTaxAmount.Position = 55;
            this.colnTaxAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.colnTaxAmount, "colnTaxAmount");
            this.colnTaxAmount.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colnTaxAmount_WindowActions);
            // 
            // colnCurrencyTaxAmount
            // 
            this.colnCurrencyTaxAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colnCurrencyTaxAmount.Name = "colnCurrencyTaxAmount";
            this.colnCurrencyTaxAmount.NamedProperties.Put("EnumerateMethod", "");
            this.colnCurrencyTaxAmount.NamedProperties.Put("FieldFlags", "294");
            this.colnCurrencyTaxAmount.NamedProperties.Put("Format", "20");
            this.colnCurrencyTaxAmount.NamedProperties.Put("LovReference", "");
            this.colnCurrencyTaxAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.colnCurrencyTaxAmount.NamedProperties.Put("SqlColumn", "CURRENCY_TAX_AMOUNT");
            this.colnCurrencyTaxAmount.NamedProperties.Put("ValidateMethod", "");
            this.colnCurrencyTaxAmount.Position = 56;
            this.colnCurrencyTaxAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.colnCurrencyTaxAmount, "colnCurrencyTaxAmount");
            this.colnCurrencyTaxAmount.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colnCurrencyTaxAmount_WindowActions);
            // 
            // coldVoucherDate
            // 
            this.coldVoucherDate.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            resources.ApplyResources(this.coldVoucherDate, "coldVoucherDate");
            this.coldVoucherDate.Format = "d";
            this.coldVoucherDate.Name = "coldVoucherDate";
            this.coldVoucherDate.NamedProperties.Put("EnumerateMethod", "");
            this.coldVoucherDate.NamedProperties.Put("LovReference", "");
            this.coldVoucherDate.NamedProperties.Put("ResizeableChildObject", "");
            this.coldVoucherDate.NamedProperties.Put("SqlColumn", "VOUCHER_DATE");
            this.coldVoucherDate.NamedProperties.Put("ValidateMethod", "");
            this.coldVoucherDate.Position = 66;
            // 
            // colsPrevTaxCode
            // 
            resources.ApplyResources(this.colsPrevTaxCode, "colsPrevTaxCode");
            this.colsPrevTaxCode.Name = "colsPrevTaxCode";
            this.colsPrevTaxCode.NamedProperties.Put("EnumerateMethod", "");
            this.colsPrevTaxCode.NamedProperties.Put("LovReference", "");
            this.colsPrevTaxCode.NamedProperties.Put("ResizeableChildObject", "");
            this.colsPrevTaxCode.NamedProperties.Put("SqlColumn", "");
            this.colsPrevTaxCode.NamedProperties.Put("ValidateMethod", "");
            this.colsPrevTaxCode.Position = 67;
            // 
            // colsCorrectionParam
            // 
            resources.ApplyResources(this.colsCorrectionParam, "colsCorrectionParam");
            this.colsCorrectionParam.MaxLength = 5;
            this.colsCorrectionParam.Name = "colsCorrectionParam";
            this.colsCorrectionParam.NamedProperties.Put("EnumerateMethod", "");
            this.colsCorrectionParam.NamedProperties.Put("LovReference", "");
            this.colsCorrectionParam.NamedProperties.Put("ResizeableChildObject", "");
            this.colsCorrectionParam.NamedProperties.Put("SqlColumn", "CORRECTION_PARAM");
            this.colsCorrectionParam.NamedProperties.Put("ValidateMethod", "");
            this.colsCorrectionParam.Position = 68;
            // 
            // colsLoadType
            // 
            resources.ApplyResources(this.colsLoadType, "colsLoadType");
            this.colsLoadType.MaxLength = 20;
            this.colsLoadType.Name = "colsLoadType";
            this.colsLoadType.NamedProperties.Put("EnumerateMethod", "");
            this.colsLoadType.NamedProperties.Put("FieldFlags", "262");
            this.colsLoadType.NamedProperties.Put("LovReference", "");
            this.colsLoadType.NamedProperties.Put("ResizeableChildObject", "");
            this.colsLoadType.NamedProperties.Put("SqlColumn", "LOAD_TYPE");
            this.colsLoadType.NamedProperties.Put("ValidateMethod", "");
            this.colsLoadType.Position = 69;
            // 
            // colsModifyCodestrCmpl
            // 
            resources.ApplyResources(this.colsModifyCodestrCmpl, "colsModifyCodestrCmpl");
            this.colsModifyCodestrCmpl.MaxLength = 5;
            this.colsModifyCodestrCmpl.Name = "colsModifyCodestrCmpl";
            this.colsModifyCodestrCmpl.NamedProperties.Put("EnumerateMethod", "");
            this.colsModifyCodestrCmpl.NamedProperties.Put("FieldFlags", "4359");
            this.colsModifyCodestrCmpl.NamedProperties.Put("LovReference", "");
            this.colsModifyCodestrCmpl.NamedProperties.Put("ResizeableChildObject", "");
            this.colsModifyCodestrCmpl.NamedProperties.Put("SqlColumn", "MODIFY_CODESTR_CMPL");
            this.colsModifyCodestrCmpl.NamedProperties.Put("ValidateMethod", "");
            this.colsModifyCodestrCmpl.Position = 70;
            // 
            // menuOperations
            // 
            this.menuOperations.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem__Change});
            this.menuOperations.Name = "menuOperations";
            resources.ApplyResources(this.menuOperations, "menuOperations");
            // 
            // menuItem__Change
            // 
            this.menuItem__Change.Command = this.menuOperations_menu_Change_Company___;
            this.menuItem__Change.Name = "menuItem__Change";
            resources.ApplyResources(this.menuItem__Change, "menuItem__Change");
            this.menuItem__Change.Text = "&Change Company...";
            // 
            // menuTbwMethods
            // 
            this.menuTbwMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem__Change_1});
            this.menuTbwMethods.Name = "menuTbwMethods";
            resources.ApplyResources(this.menuTbwMethods, "menuTbwMethods");
            // 
            // menuItem__Change_1
            // 
            this.menuItem__Change_1.Command = this.menuTbwMethods_menu_Change_Company___;
            this.menuItem__Change_1.Name = "menuItem__Change_1";
            resources.ApplyResources(this.menuItem__Change_1, "menuItem__Change_1");
            this.menuItem__Change_1.Text = "&Change Company...";
            // 
            // coldEventDate
            // 
            this.coldEventDate.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.coldEventDate.Format = "d";
            this.coldEventDate.Name = "coldEventDate";
            this.coldEventDate.NamedProperties.Put("EnumerateMethod", "");
            this.coldEventDate.NamedProperties.Put("FieldFlags", "294");
            this.coldEventDate.NamedProperties.Put("LovReference", "");
            this.coldEventDate.NamedProperties.Put("SqlColumn", "EVENT_DATE");
            this.coldEventDate.Position = 71;
            resources.ApplyResources(this.coldEventDate, "coldEventDate");
            // 
            // coldRetroactiveDate
            // 
            this.coldRetroactiveDate.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.coldRetroactiveDate.Format = "d";
            this.coldRetroactiveDate.Name = "coldRetroactiveDate";
            this.coldRetroactiveDate.NamedProperties.Put("EnumerateMethod", "");
            this.coldRetroactiveDate.NamedProperties.Put("FieldFlags", "294");
            this.coldRetroactiveDate.NamedProperties.Put("LovReference", "");
            this.coldRetroactiveDate.NamedProperties.Put("SqlColumn", "RETROACTIVE_DATE");
            this.coldRetroactiveDate.Position = 72;
            resources.ApplyResources(this.coldRetroactiveDate, "coldRetroactiveDate");
            // 
            // colsTransactionReason
            // 
            this.colsTransactionReason.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsTransactionReason.MaxLength = 20;
            this.colsTransactionReason.Name = "colsTransactionReason";
            this.colsTransactionReason.NamedProperties.Put("EnumerateMethod", "");
            this.colsTransactionReason.NamedProperties.Put("FieldFlags", "294");
            this.colsTransactionReason.NamedProperties.Put("LovReference", "TRANSACTION_REASON_ACQUISITION(COMPANY)");
            this.colsTransactionReason.NamedProperties.Put("SqlColumn", "TRANSACTION_REASON");
            this.colsTransactionReason.Position = 73;
            resources.ApplyResources(this.colsTransactionReason, "colsTransactionReason");
            // 
            // colnThirdCurrencyDebitAmount
            // 
            this.colnThirdCurrencyDebitAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colnThirdCurrencyDebitAmount.Name = "colnThirdCurrencyDebitAmount";
            this.colnThirdCurrencyDebitAmount.NamedProperties.Put("EnumerateMethod", "");
            this.colnThirdCurrencyDebitAmount.NamedProperties.Put("FieldFlags", "294");
            this.colnThirdCurrencyDebitAmount.NamedProperties.Put("Format", "20");
            this.colnThirdCurrencyDebitAmount.NamedProperties.Put("LovReference", "");
            this.colnThirdCurrencyDebitAmount.NamedProperties.Put("SqlColumn", "THIRD_CURRENCY_DEBIT_AMOUNT");
            this.colnThirdCurrencyDebitAmount.Position = 46;
            this.colnThirdCurrencyDebitAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.colnThirdCurrencyDebitAmount, "colnThirdCurrencyDebitAmount");
            this.colnThirdCurrencyDebitAmount.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colnThirdCurrencyDebitAmount_WindowActions);
            // 
            // colnThirdCurrencyCreditAmount
            // 
            this.colnThirdCurrencyCreditAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colnThirdCurrencyCreditAmount.Name = "colnThirdCurrencyCreditAmount";
            this.colnThirdCurrencyCreditAmount.NamedProperties.Put("EnumerateMethod", "");
            this.colnThirdCurrencyCreditAmount.NamedProperties.Put("FieldFlags", "294");
            this.colnThirdCurrencyCreditAmount.NamedProperties.Put("Format", "20");
            this.colnThirdCurrencyCreditAmount.NamedProperties.Put("LovReference", "");
            this.colnThirdCurrencyCreditAmount.NamedProperties.Put("SqlColumn", "THIRD_CURRENCY_CREDIT_AMOUNT");
            this.colnThirdCurrencyCreditAmount.Position = 47;
            this.colnThirdCurrencyCreditAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.colnThirdCurrencyCreditAmount, "colnThirdCurrencyCreditAmount");
            this.colnThirdCurrencyCreditAmount.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colnThirdCurrencyCreditAmount_WindowActions);
            // 
            // colnThirdCurrencyAmount
            // 
            this.colnThirdCurrencyAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colnThirdCurrencyAmount.Name = "colnThirdCurrencyAmount";
            this.colnThirdCurrencyAmount.NamedProperties.Put("EnumerateMethod", "");
            this.colnThirdCurrencyAmount.NamedProperties.Put("FieldFlags", "294");
            this.colnThirdCurrencyAmount.NamedProperties.Put("Format", "20");
            this.colnThirdCurrencyAmount.NamedProperties.Put("LovReference", "");
            this.colnThirdCurrencyAmount.NamedProperties.Put("SqlColumn", "THIRD_CURRENCY_AMOUNT");
            this.colnThirdCurrencyAmount.Position = 48;
            this.colnThirdCurrencyAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.colnThirdCurrencyAmount, "colnThirdCurrencyAmount");
            this.colnThirdCurrencyAmount.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colnThirdCurrencyAmount_WindowActions);
            // 
            // colnThirdCurrencyTaxAmount
            // 
            this.colnThirdCurrencyTaxAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colnThirdCurrencyTaxAmount.Name = "colnThirdCurrencyTaxAmount";
            this.colnThirdCurrencyTaxAmount.NamedProperties.Put("EnumerateMethod", "");
            this.colnThirdCurrencyTaxAmount.NamedProperties.Put("FieldFlags", "294");
            this.colnThirdCurrencyTaxAmount.NamedProperties.Put("Format", "20");
            this.colnThirdCurrencyTaxAmount.NamedProperties.Put("LovReference", "");
            this.colnThirdCurrencyTaxAmount.NamedProperties.Put("SqlColumn", "THIRD_CURRENCY_TAX_AMOUNT");
            this.colnThirdCurrencyTaxAmount.Position = 57;
            this.colnThirdCurrencyTaxAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.colnThirdCurrencyTaxAmount, "colnThirdCurrencyTaxAmount");
            // 
            // colsDelivTypeId
            // 
            this.colsDelivTypeId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsDelivTypeId.MaxLength = 20;
            this.colsDelivTypeId.Name = "colsDelivTypeId";
            this.colsDelivTypeId.NamedProperties.Put("EnumerateMethod", "");
            this.colsDelivTypeId.NamedProperties.Put("FieldFlags", "294");
            this.colsDelivTypeId.NamedProperties.Put("LovReference", "DELIVERY_TYPE(COMPANY)");
            this.colsDelivTypeId.NamedProperties.Put("SqlColumn", "DELIV_TYPE_ID");
            this.colsDelivTypeId.Position = 51;
            resources.ApplyResources(this.colsDelivTypeId, "colsDelivTypeId");
            // 
            // colsDeliveryTypeDescription
            // 
            this.colsDeliveryTypeDescription.MaxLength = 2000;
            this.colsDeliveryTypeDescription.Name = "colsDeliveryTypeDescription";
            this.colsDeliveryTypeDescription.NamedProperties.Put("EnumerateMethod", "");
            this.colsDeliveryTypeDescription.NamedProperties.Put("FieldFlags", "288");
            this.colsDeliveryTypeDescription.NamedProperties.Put("LovReference", "");
            this.colsDeliveryTypeDescription.NamedProperties.Put("ParentName", "colsDelivTypeId");
            this.colsDeliveryTypeDescription.NamedProperties.Put("SqlColumn", "Voucher_Row_API.Get_Delivery_Type_Description(COMPANY,DELIV_TYPE_ID)");
            this.colsDeliveryTypeDescription.Position = 52;
            resources.ApplyResources(this.colsDeliveryTypeDescription, "colsDeliveryTypeDescription");
            // 
            // colCurrencyRateType
            // 
            this.colCurrencyRateType.MaxLength = 10;
            this.colCurrencyRateType.Name = "colCurrencyRateType";
            this.colCurrencyRateType.NamedProperties.Put("FieldFlags", "263");
            this.colCurrencyRateType.NamedProperties.Put("LovReference", "CURRENCY_RATE2(COMPANY, CURRENCY_CODE)");
            this.colCurrencyRateType.NamedProperties.Put("SqlColumn", "CURRENCY_RATE_TYPE");
            this.colCurrencyRateType.Position = 37;
            resources.ApplyResources(this.colCurrencyRateType, "colCurrencyRateType");
            // 
            // colsParallelCurrRateType
            // 
            this.colsParallelCurrRateType.MaxLength = 10;
            this.colsParallelCurrRateType.Name = "colsParallelCurrRateType";
            this.colsParallelCurrRateType.NamedProperties.Put("EnumerateMethod", "");
            this.colsParallelCurrRateType.NamedProperties.Put("FieldFlags", "294");
            this.colsParallelCurrRateType.NamedProperties.Put("LovReference", "CURRENCY_TYPE3(COMPANY)");
            this.colsParallelCurrRateType.NamedProperties.Put("SqlColumn", "PARALLEL_CURR_RATE_TYPE");
            this.colsParallelCurrRateType.Position = 38;
            resources.ApplyResources(this.colsParallelCurrRateType, "colsParallelCurrRateType");
            this.colsParallelCurrRateType.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tableWindow_colsParallelCurrRateType_WindowActions);
            // 
            // tbwExtTransactions
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colCompany);
            this.Controls.Add(this.colLoadId);
            this.Controls.Add(this.colRecordNo);
            this.Controls.Add(this.colRowState);
            this.Controls.Add(this.colLoadGroupItem);
            this.Controls.Add(this.colLoadError);
            this.Controls.Add(this.colTransactionDate);
            this.Controls.Add(this.colVoucherType);
            this.Controls.Add(this.colVoucherNo);
            this.Controls.Add(this.colAccountingYear);
            this.Controls.Add(this.colAccountingPeriod);
            this.Controls.Add(this.colsUserGroup);
            this.Controls.Add(this.colsUserId);
            this.Controls.Add(this.colAccount);
            this.Controls.Add(this.colAccountDesc);
            this.Controls.Add(this.colCodeB);
            this.Controls.Add(this.colCodeBDesc);
            this.Controls.Add(this.colCodeC);
            this.Controls.Add(this.colCodeCDesc);
            this.Controls.Add(this.colCodeD);
            this.Controls.Add(this.colCodeDDesc);
            this.Controls.Add(this.colCodeE);
            this.Controls.Add(this.colCodeEDesc);
            this.Controls.Add(this.colCodeF);
            this.Controls.Add(this.colCodeFDesc);
            this.Controls.Add(this.colCodeG);
            this.Controls.Add(this.colCodeGDesc);
            this.Controls.Add(this.colCodeH);
            this.Controls.Add(this.colCodeHDesc);
            this.Controls.Add(this.colCodeI);
            this.Controls.Add(this.colCodeIDesc);
            this.Controls.Add(this.colCodeJ);
            this.Controls.Add(this.colCodeJDesc);
            this.Controls.Add(this.colCurrencyCode);
            this.Controls.Add(this.colsParallelCurrRateType);
            this.Controls.Add(this.colCurrencyRateType);
            this.Controls.Add(this.colCorrection);
            this.Controls.Add(this.colCurrencyDebetAmount);
            this.Controls.Add(this.colCurrencyCreditAmount);
            this.Controls.Add(this.colCurrencyAmount);
            this.Controls.Add(this.colDebetAmount);
            this.Controls.Add(this.colCreditAmount);
            this.Controls.Add(this.colAmount);
            this.Controls.Add(this.colnThirdCurrencyDebitAmount);
            this.Controls.Add(this.colnThirdCurrencyCreditAmount);
            this.Controls.Add(this.colnThirdCurrencyAmount);
            this.Controls.Add(this.colQuantity);
            this.Controls.Add(this.colProcessCode);
            this.Controls.Add(this.colsDelivTypeId);
            this.Controls.Add(this.colsDeliveryTypeDescription);
            this.Controls.Add(this.colOptionalCode);
            this.Controls.Add(this.colsTaxDirection);
            this.Controls.Add(this.colnTaxAmount);
            this.Controls.Add(this.colnCurrencyTaxAmount);
            this.Controls.Add(this.colnThirdCurrencyTaxAmount);
            this.Controls.Add(this.colnProjectActivityId);
            this.Controls.Add(this.colText);
            this.Controls.Add(this.colPartyTypeId);
            this.Controls.Add(this.colReferenceNumber);
            this.Controls.Add(this.colReferenceSerie);
            this.Controls.Add(this.colTransCode);
            this.Controls.Add(this.colExtAlterTrans);
            this.Controls.Add(this.colCodePartsDemand);
            this.Controls.Add(this.coldVoucherDate);
            this.Controls.Add(this.colsPrevTaxCode);
            this.Controls.Add(this.colsCorrectionParam);
            this.Controls.Add(this.colsLoadType);
            this.Controls.Add(this.colsModifyCodestrCmpl);
            this.Controls.Add(this.coldEventDate);
            this.Controls.Add(this.coldRetroactiveDate);
            this.Controls.Add(this.colsTransactionReason);
            this.Name = "tbwExtTransactions";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "COMPANY= :global.company");
            this.NamedProperties.Put("LogicalUnit", "ExtTransactions");
            this.NamedProperties.Put("PackageName", "EXT_TRANSACTIONS_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("ViewName", "EXT_TRANSACTIONS_NEW");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tbwExtTransactions_WindowActions);
            this.Controls.SetChildIndex(this.colsTransactionReason, 0);
            this.Controls.SetChildIndex(this.coldRetroactiveDate, 0);
            this.Controls.SetChildIndex(this.coldEventDate, 0);
            this.Controls.SetChildIndex(this.colsModifyCodestrCmpl, 0);
            this.Controls.SetChildIndex(this.colsLoadType, 0);
            this.Controls.SetChildIndex(this.colsCorrectionParam, 0);
            this.Controls.SetChildIndex(this.colsPrevTaxCode, 0);
            this.Controls.SetChildIndex(this.coldVoucherDate, 0);
            this.Controls.SetChildIndex(this.colCodePartsDemand, 0);
            this.Controls.SetChildIndex(this.colExtAlterTrans, 0);
            this.Controls.SetChildIndex(this.colTransCode, 0);
            this.Controls.SetChildIndex(this.colReferenceSerie, 0);
            this.Controls.SetChildIndex(this.colReferenceNumber, 0);
            this.Controls.SetChildIndex(this.colPartyTypeId, 0);
            this.Controls.SetChildIndex(this.colText, 0);
            this.Controls.SetChildIndex(this.colnProjectActivityId, 0);
            this.Controls.SetChildIndex(this.colnThirdCurrencyTaxAmount, 0);
            this.Controls.SetChildIndex(this.colnCurrencyTaxAmount, 0);
            this.Controls.SetChildIndex(this.colnTaxAmount, 0);
            this.Controls.SetChildIndex(this.colsTaxDirection, 0);
            this.Controls.SetChildIndex(this.colOptionalCode, 0);
            this.Controls.SetChildIndex(this.colsDeliveryTypeDescription, 0);
            this.Controls.SetChildIndex(this.colsDelivTypeId, 0);
            this.Controls.SetChildIndex(this.colProcessCode, 0);
            this.Controls.SetChildIndex(this.colQuantity, 0);
            this.Controls.SetChildIndex(this.colnThirdCurrencyAmount, 0);
            this.Controls.SetChildIndex(this.colnThirdCurrencyCreditAmount, 0);
            this.Controls.SetChildIndex(this.colnThirdCurrencyDebitAmount, 0);
            this.Controls.SetChildIndex(this.colAmount, 0);
            this.Controls.SetChildIndex(this.colCreditAmount, 0);
            this.Controls.SetChildIndex(this.colDebetAmount, 0);
            this.Controls.SetChildIndex(this.colCurrencyAmount, 0);
            this.Controls.SetChildIndex(this.colCurrencyCreditAmount, 0);
            this.Controls.SetChildIndex(this.colCurrencyDebetAmount, 0);
            this.Controls.SetChildIndex(this.colCorrection, 0);
            this.Controls.SetChildIndex(this.colCurrencyRateType, 0);
            this.Controls.SetChildIndex(this.colsParallelCurrRateType, 0);
            this.Controls.SetChildIndex(this.colCurrencyCode, 0);
            this.Controls.SetChildIndex(this.colCodeJDesc, 0);
            this.Controls.SetChildIndex(this.colCodeJ, 0);
            this.Controls.SetChildIndex(this.colCodeIDesc, 0);
            this.Controls.SetChildIndex(this.colCodeI, 0);
            this.Controls.SetChildIndex(this.colCodeHDesc, 0);
            this.Controls.SetChildIndex(this.colCodeH, 0);
            this.Controls.SetChildIndex(this.colCodeGDesc, 0);
            this.Controls.SetChildIndex(this.colCodeG, 0);
            this.Controls.SetChildIndex(this.colCodeFDesc, 0);
            this.Controls.SetChildIndex(this.colCodeF, 0);
            this.Controls.SetChildIndex(this.colCodeEDesc, 0);
            this.Controls.SetChildIndex(this.colCodeE, 0);
            this.Controls.SetChildIndex(this.colCodeDDesc, 0);
            this.Controls.SetChildIndex(this.colCodeD, 0);
            this.Controls.SetChildIndex(this.colCodeCDesc, 0);
            this.Controls.SetChildIndex(this.colCodeC, 0);
            this.Controls.SetChildIndex(this.colCodeBDesc, 0);
            this.Controls.SetChildIndex(this.colCodeB, 0);
            this.Controls.SetChildIndex(this.colAccountDesc, 0);
            this.Controls.SetChildIndex(this.colAccount, 0);
            this.Controls.SetChildIndex(this.colsUserId, 0);
            this.Controls.SetChildIndex(this.colsUserGroup, 0);
            this.Controls.SetChildIndex(this.colAccountingPeriod, 0);
            this.Controls.SetChildIndex(this.colAccountingYear, 0);
            this.Controls.SetChildIndex(this.colVoucherNo, 0);
            this.Controls.SetChildIndex(this.colVoucherType, 0);
            this.Controls.SetChildIndex(this.colTransactionDate, 0);
            this.Controls.SetChildIndex(this.colLoadError, 0);
            this.Controls.SetChildIndex(this.colLoadGroupItem, 0);
            this.Controls.SetChildIndex(this.colRowState, 0);
            this.Controls.SetChildIndex(this.colRecordNo, 0);
            this.Controls.SetChildIndex(this.colLoadId, 0);
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

        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menu_Change_Company___;
        public Fnd.Windows.Forms.FndCommand menuOperations_menu_Change_Company___;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuOperations;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Change;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTbwMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Change_1;
        protected cColumn coldEventDate;
        protected cColumn coldRetroactiveDate;
        protected cColumn colsTransactionReason;
        protected cColumnFinEuro colnThirdCurrencyDebitAmount;
        protected cColumnFinEuro colnThirdCurrencyCreditAmount;
        protected cColumnFinEuro colnThirdCurrencyAmount;
        protected cColumnFinEuro colnThirdCurrencyTaxAmount;
        protected cColumn colsDelivTypeId;
        protected cColumn colsDeliveryTypeDescription;
        protected cColumn colCurrencyRateType;
        private cColumn colsParallelCurrRateType;
	}
}
