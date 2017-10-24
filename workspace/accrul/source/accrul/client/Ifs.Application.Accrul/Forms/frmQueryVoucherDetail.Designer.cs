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
	
	public partial class frmQueryVoucherDetail
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		protected cBackgroundText labeldfCompany;
		public cDataField dfCompany;
		public cDataField dfVoucherType;
		protected cBackgroundText labelccVoucherType;
		// Bug 72589 Begin,  Changed Key Flags in F1 Properties to Parent Key
		// Bug 73468, Begin , Changed format to UPPERCASE in F1 properties.
		public cRecListDataField ccVoucherType;
		// Bug 73468, End
		// Bug 72589 End
		protected cBackgroundText labeldfVoucherNo;
		public cDataField dfVoucherNo;
		protected cBackgroundText labeldfVoucherDate;
		public cDataField dfVoucherDate;
		protected cBackgroundText labeldfVoucherStatus;
		public cDataField dfVoucherStatus;
		protected cBackgroundText labeldfDateReg;
		public cDataField dfDateReg;
		// Bug 77430, Begin, changed F1 property Column Name
		// Bug 77430, Begin
		public cCheckBox cbNotes;
		// Bug 77430, End
		protected SalGroupBox gbAccounting_Period;
		protected cBackgroundText labeldfAccountingYear;
		// Bug 72589 Begin,  Changed Key Flags in F1 Properties to Parent Key
		public cDataField dfAccountingYear;
		// Bug 72589 End
		protected cBackgroundText labeldfAccountingPeriod;
		public cDataField dfAccountingPeriod;
		protected SalGroupBox gbVoucher_Reference;
		protected cBackgroundText labeldfVoucherTypeReference;
		public cDataField dfVoucherTypeReference;
		protected cBackgroundText labeldfVoucherNoReference;
		public cDataField dfVoucherNoReference;
		protected cBackgroundText labeldfAccountingYearReference;
		public cDataField dfAccountingYearReference;
		protected SalGroupBox gbVoucher_Entry_By_User;
		protected cBackgroundText labeldfUserid;
		public cDataField dfUserid;
		protected cBackgroundText labeldfUserGroup;
		public cDataField dfUserGroup;
		protected cBackgroundText labeldfUpdateError;
		public cDataField dfUpdateError;
		public cCheckBox cbMultiCompanyId;
		protected cBackgroundText labeldfMultiCompanyId;
		public cDataField dfMultiCompanyId;
		protected cBackgroundText labeldfCodePartValue;
		public cDataFieldFinContent dfCodePartValue;
		protected cBackgroundText labeldfCodePartDescription;
		public cDataFieldFinDescription dfCodePartDescription;
		// Bug 77430, Removed dfVoucherText and Background Text
		protected cBackgroundText labeldfsVoucherText2;
		public cDataField dfsVoucherText2;
		protected cBackgroundText labeldfdApprovalDate;
		public cDataField dfdApprovalDate;
		protected cBackgroundText labeldfsApprovedByUserid;
		public cDataField dfsApprovedByUserid;
		protected cBackgroundText labeldfsApprovedByUserGroup;
		public cDataField dfsApprovedByUserGroup;
		protected SalGroupBox gbVoucher_Approval_By_User;
        // Bug 76068 Begin Increased max row Memory
		// Bug 76068 End
		public cDataField dfRefCompany;
		protected cBackgroundText labeldfMCId;
		public cDataField dfMCId;
		protected cBackgroundText labeldfFunctionGroup;
		public cDataField dfFunctionGroup;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQueryVoucherDetail));
            this.menuTblMethods_menu_Notes___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTblMethods_menuView__Multi_Company_Voucher___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTblMethods_menuChange__Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuOperations_menu_Notes___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuOperations_menuView__Multi_Company_Voucher___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuOperations_menuChange__Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuFrmMethods_menu_Notes___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuFrmMethods_menuView__Multi_Company_Voucher___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuFrmMethods_menuChange__Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.labeldfCompany = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfCompany = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfVoucherType = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelccVoucherType = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.ccVoucherType = new Ifs.Fnd.ApplicationForms.cRecListDataField();
            this.labeldfVoucherNo = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfVoucherNo = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfVoucherDate = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfVoucherDate = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfVoucherStatus = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfVoucherStatus = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfDateReg = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfDateReg = new Ifs.Fnd.ApplicationForms.cDataField();
            this.cbNotes = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.gbAccounting_Period = new PPJ.Runtime.Windows.SalGroupBox();
            this.labeldfAccountingYear = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfAccountingYear = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfAccountingPeriod = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfAccountingPeriod = new Ifs.Fnd.ApplicationForms.cDataField();
            this.gbVoucher_Reference = new PPJ.Runtime.Windows.SalGroupBox();
            this.labeldfVoucherTypeReference = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfVoucherTypeReference = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfVoucherNoReference = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfVoucherNoReference = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfAccountingYearReference = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfAccountingYearReference = new Ifs.Fnd.ApplicationForms.cDataField();
            this.gbVoucher_Entry_By_User = new PPJ.Runtime.Windows.SalGroupBox();
            this.labeldfUserid = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfUserid = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfUserGroup = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfUserGroup = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfUpdateError = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfUpdateError = new Ifs.Fnd.ApplicationForms.cDataField();
            this.cbMultiCompanyId = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.labeldfMultiCompanyId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfMultiCompanyId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfCodePartValue = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfCodePartValue = new Ifs.Application.Accrul.cDataFieldFinContent();
            this.labeldfCodePartDescription = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfCodePartDescription = new Ifs.Application.Accrul.cDataFieldFinDescription();
            this.labeldfsVoucherText2 = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsVoucherText2 = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfdApprovalDate = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfdApprovalDate = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsApprovedByUserid = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsApprovedByUserid = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsApprovedByUserGroup = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsApprovedByUserGroup = new Ifs.Fnd.ApplicationForms.cDataField();
            this.gbVoucher_Approval_By_User = new PPJ.Runtime.Windows.SalGroupBox();
            this.dfRefCompany = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfMCId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfMCId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfFunctionGroup = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfFunctionGroup = new Ifs.Fnd.ApplicationForms.cDataField();
            this.menuFrmMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem__Notes = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem_View = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuSeparator1 = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.menuItem_Change = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuOperations = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem__Notes_1 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem_View_1 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuSeparator2 = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.menuItem_Change_1 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuTblMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem__Notes_2 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem_View_2 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuSeparator3 = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.menuItem_Change_2 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.tblVoucherDetail = new Ifs.Application.Accrul.cChildTableFin();
            this.tblVoucherDetail_colCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherDetail_colAccountingYear = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherDetail_colVoucherType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherDetail_colVoucherNo = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherDetail_colRowNo = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherDetail_colAccount = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.tblVoucherDetail_colsAccountDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.tblVoucherDetail_colCodeB = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.tblVoucherDetail_colsCodeBDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.tblVoucherDetail_colCodeC = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.tblVoucherDetail_colsCodeCDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.tblVoucherDetail_colCodeD = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.tblVoucherDetail_colsCodeDDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.tblVoucherDetail_colCodeE = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.tblVoucherDetail_colsCodeEDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.tblVoucherDetail_colCodeF = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.tblVoucherDetail_colsCodeFDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.tblVoucherDetail_colCodeG = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.tblVoucherDetail_colsCodeGDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.tblVoucherDetail_colCodeH = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.tblVoucherDetail_colsCodeHDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.tblVoucherDetail_colCodeI = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.tblVoucherDetail_colsCodeIDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.tblVoucherDetail_colCodeJ = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.tblVoucherDetail_colsCodeJDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.tblVoucherDetail_colMultiCompanyId = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.tblVoucherDetail_colCorrection = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherDetail_colCurrencyCode = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherDetail_colCurrencyRate = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherDetail_colConversionFactor = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherDetail_colDebetAmount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherDetail_colCreditAmount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherDetail_colAmount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherDetail_colCurrencyDebetAmount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherDetail_colCurrencyCreditAmount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherDetail_colCurrencyAmount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherDetail_colnThirdCurrencyRate = new Ifs.Application.Accrul.cColumnFinEuro();
            this.tblVoucherDetail_colnThirdCurrencyDebitAmount = new Ifs.Application.Accrul.cColumnFinEuro();
            this.tblVoucherDetail_colnThirdCurrencyCreditAmount = new Ifs.Application.Accrul.cColumnFinEuro();
            this.tblVoucherDetail_colnThirdCurrencyAmount = new Ifs.Application.Accrul.cColumnFinEuro();
            this.tblVoucherDetail_colnParallelCurrencyRate = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherDetail_colnParallelConversionFactor = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherDetail_colText = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherDetail_colQuantity = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherDetail_colProcessCode = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherDetail_colsDeliveryTypeId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherDetail_colsDeliveryTypeDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherDetail_colOptionalCode = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherDetail_colProjActivityId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherDetail_colPartyTypeId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherDetail_colTransCode = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherDetail_colTransferId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherDetail_colUpdateError = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherDetail_colCorrected = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherDetail_colPeriodical_Allocation = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherDetail_colReferenceSerie = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherDetail_colReferenceNumber = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherDetail_colAutoTaxVouEntry = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.tblVoucherDetail_colnRowGroupId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.menuFrmMethods.SuspendLayout();
            this.menuOperations.SuspendLayout();
            this.menuTblMethods.SuspendLayout();
            this.tblVoucherDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuFrmMethods_menu_Notes___);
            this.commandManager.Commands.Add(this.menuFrmMethods_menuView__Multi_Company_Voucher___);
            this.commandManager.Commands.Add(this.menuFrmMethods_menuChange__Company___);
            this.commandManager.Commands.Add(this.menuOperations_menu_Notes___);
            this.commandManager.Commands.Add(this.menuOperations_menuView__Multi_Company_Voucher___);
            this.commandManager.Commands.Add(this.menuOperations_menuChange__Company___);
            this.commandManager.Commands.Add(this.menuTblMethods_menu_Notes___);
            this.commandManager.Commands.Add(this.menuTblMethods_menuView__Multi_Company_Voucher___);
            this.commandManager.Commands.Add(this.menuTblMethods_menuChange__Company___);
            this.commandManager.ContextMenus.Add(this.menuFrmMethods);
            this.commandManager.ContextMenus.Add(this.menuOperations);
            this.commandManager.ContextMenus.Add(this.menuTblMethods);
            // 
            // menuTblMethods_menu_Notes___
            // 
            resources.ApplyResources(this.menuTblMethods_menu_Notes___, "menuTblMethods_menu_Notes___");
            this.menuTblMethods_menu_Notes___.Name = "menuTblMethods_menu_Notes___";
            this.menuTblMethods_menu_Notes___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Notes_2_Execute);
            this.menuTblMethods_menu_Notes___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Notes_2_Inquire);
            // 
            // menuTblMethods_menuView__Multi_Company_Voucher___
            // 
            resources.ApplyResources(this.menuTblMethods_menuView__Multi_Company_Voucher___, "menuTblMethods_menuView__Multi_Company_Voucher___");
            this.menuTblMethods_menuView__Multi_Company_Voucher___.Name = "menuTblMethods_menuView__Multi_Company_Voucher___";
            this.menuTblMethods_menuView__Multi_Company_Voucher___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_View_2_Execute);
            this.menuTblMethods_menuView__Multi_Company_Voucher___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_View_2_Inquire);
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
            // menuOperations_menuView__Multi_Company_Voucher___
            // 
            resources.ApplyResources(this.menuOperations_menuView__Multi_Company_Voucher___, "menuOperations_menuView__Multi_Company_Voucher___");
            this.menuOperations_menuView__Multi_Company_Voucher___.Name = "menuOperations_menuView__Multi_Company_Voucher___";
            this.menuOperations_menuView__Multi_Company_Voucher___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_View_1_Execute);
            this.menuOperations_menuView__Multi_Company_Voucher___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_View_1_Inquire);
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
            // menuFrmMethods_menuView__Multi_Company_Voucher___
            // 
            resources.ApplyResources(this.menuFrmMethods_menuView__Multi_Company_Voucher___, "menuFrmMethods_menuView__Multi_Company_Voucher___");
            this.menuFrmMethods_menuView__Multi_Company_Voucher___.Name = "menuFrmMethods_menuView__Multi_Company_Voucher___";
            this.menuFrmMethods_menuView__Multi_Company_Voucher___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_View_Execute);
            this.menuFrmMethods_menuView__Multi_Company_Voucher___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_View_Inquire);
            // 
            // menuFrmMethods_menuChange__Company___
            // 
            resources.ApplyResources(this.menuFrmMethods_menuChange__Company___, "menuFrmMethods_menuChange__Company___");
            this.menuFrmMethods_menuChange__Company___.Name = "menuFrmMethods_menuChange__Company___";
            this.menuFrmMethods_menuChange__Company___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Change_Execute);
            this.menuFrmMethods_menuChange__Company___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Change_Inquire);
            // 
            // labeldfCompany
            // 
            resources.ApplyResources(this.labeldfCompany, "labeldfCompany");
            this.labeldfCompany.Name = "labeldfCompany";
            // 
            // dfCompany
            // 
            resources.ApplyResources(this.dfCompany, "dfCompany");
            this.dfCompany.Name = "dfCompany";
            this.dfCompany.NamedProperties.Put("EnumerateMethod", "");
            this.dfCompany.NamedProperties.Put("FieldFlags", "67");
            this.dfCompany.NamedProperties.Put("LovReference", "");
            this.dfCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            // 
            // dfVoucherType
            // 
            resources.ApplyResources(this.dfVoucherType, "dfVoucherType");
            this.dfVoucherType.Name = "dfVoucherType";
            this.dfVoucherType.NamedProperties.Put("EnumerateMethod", "");
            this.dfVoucherType.NamedProperties.Put("LovReference", "");
            this.dfVoucherType.NamedProperties.Put("ResizeableChildObject", "");
            this.dfVoucherType.NamedProperties.Put("SqlColumn", "");
            this.dfVoucherType.NamedProperties.Put("ValidateMethod", "");
            // 
            // labelccVoucherType
            // 
            resources.ApplyResources(this.labelccVoucherType, "labelccVoucherType");
            this.labelccVoucherType.Name = "labelccVoucherType";
            // 
            // ccVoucherType
            // 
            this.ccVoucherType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.ccVoucherType, "ccVoucherType");
            this.ccVoucherType.Name = "ccVoucherType";
            this.ccVoucherType.NamedProperties.Put("EnumerateMethod", "");
            this.ccVoucherType.NamedProperties.Put("FieldFlags", "96");
            this.ccVoucherType.NamedProperties.Put("Format", "9");
            this.ccVoucherType.NamedProperties.Put("LovReference", "VOUCHER_TYPE(COMPANY)");
            this.ccVoucherType.NamedProperties.Put("ResizeableChildObject", "");
            this.ccVoucherType.NamedProperties.Put("SqlColumn", "VOUCHER_TYPE");
            this.ccVoucherType.NamedProperties.Put("ValidateMethod", "");
            this.ccVoucherType.NamedProperties.Put("XDataLength", "");
            // 
            // labeldfVoucherNo
            // 
            resources.ApplyResources(this.labeldfVoucherNo, "labeldfVoucherNo");
            this.labeldfVoucherNo.Name = "labeldfVoucherNo";
            // 
            // dfVoucherNo
            // 
            this.dfVoucherNo.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfVoucherNo, "dfVoucherNo");
            this.dfVoucherNo.Name = "dfVoucherNo";
            this.dfVoucherNo.NamedProperties.Put("EnumerateMethod", "");
            this.dfVoucherNo.NamedProperties.Put("FieldFlags", "163");
            this.dfVoucherNo.NamedProperties.Put("LovReference", "");
            this.dfVoucherNo.NamedProperties.Put("ParentName", "ccVoucherType");
            this.dfVoucherNo.NamedProperties.Put("ResizeableChildObject", "");
            this.dfVoucherNo.NamedProperties.Put("SqlColumn", "VOUCHER_NO");
            this.dfVoucherNo.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfVoucherDate
            // 
            resources.ApplyResources(this.labeldfVoucherDate, "labeldfVoucherDate");
            this.labeldfVoucherDate.Name = "labeldfVoucherDate";
            // 
            // dfVoucherDate
            // 
            this.dfVoucherDate.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.dfVoucherDate.Format = "d";
            resources.ApplyResources(this.dfVoucherDate, "dfVoucherDate");
            this.dfVoucherDate.Name = "dfVoucherDate";
            this.dfVoucherDate.NamedProperties.Put("EnumerateMethod", "");
            this.dfVoucherDate.NamedProperties.Put("FieldFlags", "290");
            this.dfVoucherDate.NamedProperties.Put("LovReference", "");
            this.dfVoucherDate.NamedProperties.Put("ResizeableChildObject", "");
            this.dfVoucherDate.NamedProperties.Put("SqlColumn", "VOUCHER_DATE");
            this.dfVoucherDate.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfVoucherStatus
            // 
            resources.ApplyResources(this.labeldfVoucherStatus, "labeldfVoucherStatus");
            this.labeldfVoucherStatus.Name = "labeldfVoucherStatus";
            // 
            // dfVoucherStatus
            // 
            resources.ApplyResources(this.dfVoucherStatus, "dfVoucherStatus");
            this.dfVoucherStatus.Name = "dfVoucherStatus";
            this.dfVoucherStatus.NamedProperties.Put("EnumerateMethod", "");
            this.dfVoucherStatus.NamedProperties.Put("FieldFlags", "294");
            this.dfVoucherStatus.NamedProperties.Put("LovReference", "");
            this.dfVoucherStatus.NamedProperties.Put("ResizeableChildObject", "");
            this.dfVoucherStatus.NamedProperties.Put("SqlColumn", "VOUCHER_STATUS");
            this.dfVoucherStatus.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfDateReg
            // 
            resources.ApplyResources(this.labeldfDateReg, "labeldfDateReg");
            this.labeldfDateReg.Name = "labeldfDateReg";
            // 
            // dfDateReg
            // 
            this.dfDateReg.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.dfDateReg.Format = "d";
            resources.ApplyResources(this.dfDateReg, "dfDateReg");
            this.dfDateReg.Name = "dfDateReg";
            this.dfDateReg.NamedProperties.Put("EnumerateMethod", "");
            this.dfDateReg.NamedProperties.Put("FieldFlags", "294");
            this.dfDateReg.NamedProperties.Put("LovReference", "");
            this.dfDateReg.NamedProperties.Put("ResizeableChildObject", "");
            this.dfDateReg.NamedProperties.Put("SqlColumn", "DATE_REG");
            this.dfDateReg.NamedProperties.Put("ValidateMethod", "");
            // 
            // cbNotes
            // 
            resources.ApplyResources(this.cbNotes, "cbNotes");
            this.cbNotes.Name = "cbNotes";
            this.cbNotes.NamedProperties.Put("DataType", "5");
            this.cbNotes.NamedProperties.Put("EnumerateMethod", "");
            this.cbNotes.NamedProperties.Put("FieldFlags", "288");
            this.cbNotes.NamedProperties.Put("LovReference", "");
            this.cbNotes.NamedProperties.Put("ResizeableChildObject", "");
            this.cbNotes.NamedProperties.Put("SqlColumn", "Voucher_Note_API.Check_Note_Exist(COMPANY,ACCOUNTING_YEAR,VOUCHER_TYPE,VOUCHER_NO" +
        ")");
            this.cbNotes.NamedProperties.Put("ValidateMethod", "");
            this.cbNotes.NamedProperties.Put("XDataLength", "");
            this.cbNotes.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cbNotes_WindowActions);
            // 
            // gbAccounting_Period
            // 
            resources.ApplyResources(this.gbAccounting_Period, "gbAccounting_Period");
            this.gbAccounting_Period.Name = "gbAccounting_Period";
            this.gbAccounting_Period.TabStop = false;
            // 
            // labeldfAccountingYear
            // 
            resources.ApplyResources(this.labeldfAccountingYear, "labeldfAccountingYear");
            this.labeldfAccountingYear.Name = "labeldfAccountingYear";
            // 
            // dfAccountingYear
            // 
            this.dfAccountingYear.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfAccountingYear, "dfAccountingYear");
            this.dfAccountingYear.Name = "dfAccountingYear";
            this.dfAccountingYear.NamedProperties.Put("EnumerateMethod", "");
            this.dfAccountingYear.NamedProperties.Put("FieldFlags", "99");
            this.dfAccountingYear.NamedProperties.Put("LovReference", "");
            this.dfAccountingYear.NamedProperties.Put("ParentName", "ccVoucherType");
            this.dfAccountingYear.NamedProperties.Put("ResizeableChildObject", "");
            this.dfAccountingYear.NamedProperties.Put("SqlColumn", "ACCOUNTING_YEAR");
            this.dfAccountingYear.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfAccountingPeriod
            // 
            resources.ApplyResources(this.labeldfAccountingPeriod, "labeldfAccountingPeriod");
            this.labeldfAccountingPeriod.Name = "labeldfAccountingPeriod";
            // 
            // dfAccountingPeriod
            // 
            this.dfAccountingPeriod.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfAccountingPeriod, "dfAccountingPeriod");
            this.dfAccountingPeriod.Name = "dfAccountingPeriod";
            this.dfAccountingPeriod.NamedProperties.Put("EnumerateMethod", "");
            this.dfAccountingPeriod.NamedProperties.Put("FieldFlags", "294");
            this.dfAccountingPeriod.NamedProperties.Put("LovReference", "");
            this.dfAccountingPeriod.NamedProperties.Put("ResizeableChildObject", "");
            this.dfAccountingPeriod.NamedProperties.Put("SqlColumn", "ACCOUNTING_PERIOD");
            this.dfAccountingPeriod.NamedProperties.Put("ValidateMethod", "");
            // 
            // gbVoucher_Reference
            // 
            resources.ApplyResources(this.gbVoucher_Reference, "gbVoucher_Reference");
            this.gbVoucher_Reference.Name = "gbVoucher_Reference";
            this.gbVoucher_Reference.TabStop = false;
            // 
            // labeldfVoucherTypeReference
            // 
            resources.ApplyResources(this.labeldfVoucherTypeReference, "labeldfVoucherTypeReference");
            this.labeldfVoucherTypeReference.Name = "labeldfVoucherTypeReference";
            // 
            // dfVoucherTypeReference
            // 
            resources.ApplyResources(this.dfVoucherTypeReference, "dfVoucherTypeReference");
            this.dfVoucherTypeReference.Name = "dfVoucherTypeReference";
            this.dfVoucherTypeReference.NamedProperties.Put("EnumerateMethod", "");
            this.dfVoucherTypeReference.NamedProperties.Put("FieldFlags", "294");
            this.dfVoucherTypeReference.NamedProperties.Put("LovReference", "");
            this.dfVoucherTypeReference.NamedProperties.Put("ResizeableChildObject", "");
            this.dfVoucherTypeReference.NamedProperties.Put("SqlColumn", "VOUCHER_TYPE_REFERENCE");
            this.dfVoucherTypeReference.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfVoucherNoReference
            // 
            resources.ApplyResources(this.labeldfVoucherNoReference, "labeldfVoucherNoReference");
            this.labeldfVoucherNoReference.Name = "labeldfVoucherNoReference";
            // 
            // dfVoucherNoReference
            // 
            this.dfVoucherNoReference.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfVoucherNoReference, "dfVoucherNoReference");
            this.dfVoucherNoReference.Name = "dfVoucherNoReference";
            this.dfVoucherNoReference.NamedProperties.Put("EnumerateMethod", "");
            this.dfVoucherNoReference.NamedProperties.Put("FieldFlags", "294");
            this.dfVoucherNoReference.NamedProperties.Put("LovReference", "");
            this.dfVoucherNoReference.NamedProperties.Put("ResizeableChildObject", "");
            this.dfVoucherNoReference.NamedProperties.Put("SqlColumn", "VOUCHER_NO_REFERENCE");
            this.dfVoucherNoReference.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfAccountingYearReference
            // 
            resources.ApplyResources(this.labeldfAccountingYearReference, "labeldfAccountingYearReference");
            this.labeldfAccountingYearReference.Name = "labeldfAccountingYearReference";
            // 
            // dfAccountingYearReference
            // 
            this.dfAccountingYearReference.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfAccountingYearReference, "dfAccountingYearReference");
            this.dfAccountingYearReference.Name = "dfAccountingYearReference";
            this.dfAccountingYearReference.NamedProperties.Put("EnumerateMethod", "");
            this.dfAccountingYearReference.NamedProperties.Put("FieldFlags", "294");
            this.dfAccountingYearReference.NamedProperties.Put("LovReference", "");
            this.dfAccountingYearReference.NamedProperties.Put("ResizeableChildObject", "");
            this.dfAccountingYearReference.NamedProperties.Put("SqlColumn", "ACCOUNTING_YEAR_REFERENCE");
            this.dfAccountingYearReference.NamedProperties.Put("ValidateMethod", "");
            // 
            // gbVoucher_Entry_By_User
            // 
            resources.ApplyResources(this.gbVoucher_Entry_By_User, "gbVoucher_Entry_By_User");
            this.gbVoucher_Entry_By_User.Name = "gbVoucher_Entry_By_User";
            this.gbVoucher_Entry_By_User.TabStop = false;
            // 
            // labeldfUserid
            // 
            resources.ApplyResources(this.labeldfUserid, "labeldfUserid");
            this.labeldfUserid.Name = "labeldfUserid";
            // 
            // dfUserid
            // 
            resources.ApplyResources(this.dfUserid, "dfUserid");
            this.dfUserid.Name = "dfUserid";
            this.dfUserid.NamedProperties.Put("EnumerateMethod", "");
            this.dfUserid.NamedProperties.Put("FieldFlags", "294");
            this.dfUserid.NamedProperties.Put("LovReference", "");
            this.dfUserid.NamedProperties.Put("ResizeableChildObject", "");
            this.dfUserid.NamedProperties.Put("SqlColumn", "USERID");
            this.dfUserid.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfUserGroup
            // 
            resources.ApplyResources(this.labeldfUserGroup, "labeldfUserGroup");
            this.labeldfUserGroup.Name = "labeldfUserGroup";
            // 
            // dfUserGroup
            // 
            resources.ApplyResources(this.dfUserGroup, "dfUserGroup");
            this.dfUserGroup.Name = "dfUserGroup";
            this.dfUserGroup.NamedProperties.Put("EnumerateMethod", "");
            this.dfUserGroup.NamedProperties.Put("FieldFlags", "294");
            this.dfUserGroup.NamedProperties.Put("LovReference", "USER_GROUP_FINANCE(COMPANY)");
            this.dfUserGroup.NamedProperties.Put("ResizeableChildObject", "");
            this.dfUserGroup.NamedProperties.Put("SqlColumn", "ENTERED_BY_USER_GROUP");
            this.dfUserGroup.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfUpdateError
            // 
            resources.ApplyResources(this.labeldfUpdateError, "labeldfUpdateError");
            this.labeldfUpdateError.Name = "labeldfUpdateError";
            // 
            // dfUpdateError
            // 
            resources.ApplyResources(this.dfUpdateError, "dfUpdateError");
            this.dfUpdateError.Name = "dfUpdateError";
            this.dfUpdateError.NamedProperties.Put("EnumerateMethod", "");
            this.dfUpdateError.NamedProperties.Put("FieldFlags", "294");
            this.dfUpdateError.NamedProperties.Put("LovReference", "");
            this.dfUpdateError.NamedProperties.Put("ResizeableChildObject", "");
            this.dfUpdateError.NamedProperties.Put("SqlColumn", "UPDATE_ERROR");
            this.dfUpdateError.NamedProperties.Put("ValidateMethod", "");
            // 
            // cbMultiCompanyId
            // 
            resources.ApplyResources(this.cbMultiCompanyId, "cbMultiCompanyId");
            this.cbMultiCompanyId.Name = "cbMultiCompanyId";
            this.cbMultiCompanyId.NamedProperties.Put("DataType", "5");
            this.cbMultiCompanyId.NamedProperties.Put("EnumerateMethod", "");
            this.cbMultiCompanyId.NamedProperties.Put("FieldFlags", "288");
            this.cbMultiCompanyId.NamedProperties.Put("LovReference", "");
            this.cbMultiCompanyId.NamedProperties.Put("ResizeableChildObject", "");
            this.cbMultiCompanyId.NamedProperties.Put("SqlColumn", "VOUCHER_API.Is_Multi_Company_Voucher(COMPANY,VOUCHER_TYPE,ACCOUNTING_YEAR,VOUCHER" +
        "_NO)");
            this.cbMultiCompanyId.NamedProperties.Put("ValidateMethod", "");
            this.cbMultiCompanyId.NamedProperties.Put("XDataLength", "2000");
            // 
            // labeldfMultiCompanyId
            // 
            resources.ApplyResources(this.labeldfMultiCompanyId, "labeldfMultiCompanyId");
            this.labeldfMultiCompanyId.Name = "labeldfMultiCompanyId";
            // 
            // dfMultiCompanyId
            // 
            resources.ApplyResources(this.dfMultiCompanyId, "dfMultiCompanyId");
            this.dfMultiCompanyId.Name = "dfMultiCompanyId";
            this.dfMultiCompanyId.NamedProperties.Put("EnumerateMethod", "");
            this.dfMultiCompanyId.NamedProperties.Put("FieldFlags", "258");
            this.dfMultiCompanyId.NamedProperties.Put("LovReference", "");
            this.dfMultiCompanyId.NamedProperties.Put("ResizeableChildObject", "");
            this.dfMultiCompanyId.NamedProperties.Put("SqlColumn", "MULTI_COMPANY_ID");
            this.dfMultiCompanyId.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfCodePartValue
            // 
            resources.ApplyResources(this.labeldfCodePartValue, "labeldfCodePartValue");
            this.labeldfCodePartValue.Name = "labeldfCodePartValue";
            // 
            // dfCodePartValue
            // 
            resources.ApplyResources(this.dfCodePartValue, "dfCodePartValue");
            this.dfCodePartValue.Name = "dfCodePartValue";
            this.dfCodePartValue.NamedProperties.Put("EnumerateMethod", "");
            this.dfCodePartValue.NamedProperties.Put("LovReference", "");
            this.dfCodePartValue.NamedProperties.Put("ResizeableChildObject", "");
            this.dfCodePartValue.NamedProperties.Put("SqlColumn", "");
            this.dfCodePartValue.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfCodePartDescription
            // 
            resources.ApplyResources(this.labeldfCodePartDescription, "labeldfCodePartDescription");
            this.labeldfCodePartDescription.Name = "labeldfCodePartDescription";
            // 
            // dfCodePartDescription
            // 
            resources.ApplyResources(this.dfCodePartDescription, "dfCodePartDescription");
            this.dfCodePartDescription.Name = "dfCodePartDescription";
            this.dfCodePartDescription.NamedProperties.Put("EnumerateMethod", "");
            this.dfCodePartDescription.NamedProperties.Put("LovReference", "");
            this.dfCodePartDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.dfCodePartDescription.NamedProperties.Put("SqlColumn", "");
            this.dfCodePartDescription.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsVoucherText2
            // 
            resources.ApplyResources(this.labeldfsVoucherText2, "labeldfsVoucherText2");
            this.labeldfsVoucherText2.Name = "labeldfsVoucherText2";
            // 
            // dfsVoucherText2
            // 
            resources.ApplyResources(this.dfsVoucherText2, "dfsVoucherText2");
            this.dfsVoucherText2.Name = "dfsVoucherText2";
            this.dfsVoucherText2.NamedProperties.Put("EnumerateMethod", "");
            this.dfsVoucherText2.NamedProperties.Put("FieldFlags", "294");
            this.dfsVoucherText2.NamedProperties.Put("LovReference", "");
            this.dfsVoucherText2.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsVoucherText2.NamedProperties.Put("SqlColumn", "VOUCHER_TEXT2");
            this.dfsVoucherText2.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfdApprovalDate
            // 
            resources.ApplyResources(this.labeldfdApprovalDate, "labeldfdApprovalDate");
            this.labeldfdApprovalDate.Name = "labeldfdApprovalDate";
            // 
            // dfdApprovalDate
            // 
            this.dfdApprovalDate.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.dfdApprovalDate.Format = "d";
            resources.ApplyResources(this.dfdApprovalDate, "dfdApprovalDate");
            this.dfdApprovalDate.Name = "dfdApprovalDate";
            this.dfdApprovalDate.NamedProperties.Put("EnumerateMethod", "");
            this.dfdApprovalDate.NamedProperties.Put("FieldFlags", "294");
            this.dfdApprovalDate.NamedProperties.Put("LovReference", "");
            this.dfdApprovalDate.NamedProperties.Put("ResizeableChildObject", "");
            this.dfdApprovalDate.NamedProperties.Put("SqlColumn", "APPROVAL_DATE");
            this.dfdApprovalDate.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsApprovedByUserid
            // 
            resources.ApplyResources(this.labeldfsApprovedByUserid, "labeldfsApprovedByUserid");
            this.labeldfsApprovedByUserid.Name = "labeldfsApprovedByUserid";
            // 
            // dfsApprovedByUserid
            // 
            resources.ApplyResources(this.dfsApprovedByUserid, "dfsApprovedByUserid");
            this.dfsApprovedByUserid.Name = "dfsApprovedByUserid";
            this.dfsApprovedByUserid.NamedProperties.Put("EnumerateMethod", "");
            this.dfsApprovedByUserid.NamedProperties.Put("FieldFlags", "294");
            this.dfsApprovedByUserid.NamedProperties.Put("LovReference", "");
            this.dfsApprovedByUserid.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsApprovedByUserid.NamedProperties.Put("SqlColumn", "APPROVED_BY_USERID");
            this.dfsApprovedByUserid.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsApprovedByUserGroup
            // 
            resources.ApplyResources(this.labeldfsApprovedByUserGroup, "labeldfsApprovedByUserGroup");
            this.labeldfsApprovedByUserGroup.Name = "labeldfsApprovedByUserGroup";
            // 
            // dfsApprovedByUserGroup
            // 
            resources.ApplyResources(this.dfsApprovedByUserGroup, "dfsApprovedByUserGroup");
            this.dfsApprovedByUserGroup.Name = "dfsApprovedByUserGroup";
            this.dfsApprovedByUserGroup.NamedProperties.Put("EnumerateMethod", "");
            this.dfsApprovedByUserGroup.NamedProperties.Put("FieldFlags", "294");
            this.dfsApprovedByUserGroup.NamedProperties.Put("LovReference", "");
            this.dfsApprovedByUserGroup.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsApprovedByUserGroup.NamedProperties.Put("SqlColumn", "APPROVED_BY_USER_GROUP");
            this.dfsApprovedByUserGroup.NamedProperties.Put("ValidateMethod", "");
            // 
            // gbVoucher_Approval_By_User
            // 
            resources.ApplyResources(this.gbVoucher_Approval_By_User, "gbVoucher_Approval_By_User");
            this.gbVoucher_Approval_By_User.Name = "gbVoucher_Approval_By_User";
            this.gbVoucher_Approval_By_User.TabStop = false;
            // 
            // dfRefCompany
            // 
            resources.ApplyResources(this.dfRefCompany, "dfRefCompany");
            this.dfRefCompany.Name = "dfRefCompany";
            this.dfRefCompany.NamedProperties.Put("EnumerateMethod", "");
            this.dfRefCompany.NamedProperties.Put("LovReference", "");
            this.dfRefCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.dfRefCompany.NamedProperties.Put("SqlColumn", "VOUCHER_API.GET_REFERENCE_COMPANY__(COMPANY,VOUCHER_TYPE,ACCOUNTING_YEAR,VOUCHER_" +
        "NO)");
            this.dfRefCompany.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfMCId
            // 
            resources.ApplyResources(this.labeldfMCId, "labeldfMCId");
            this.labeldfMCId.Name = "labeldfMCId";
            // 
            // dfMCId
            // 
            this.dfMCId.Name = "dfMCId";
            resources.ApplyResources(this.dfMCId, "dfMCId");
            // 
            // labeldfFunctionGroup
            // 
            resources.ApplyResources(this.labeldfFunctionGroup, "labeldfFunctionGroup");
            this.labeldfFunctionGroup.Name = "labeldfFunctionGroup";
            // 
            // dfFunctionGroup
            // 
            this.dfFunctionGroup.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfFunctionGroup, "dfFunctionGroup");
            this.dfFunctionGroup.Name = "dfFunctionGroup";
            this.dfFunctionGroup.NamedProperties.Put("EnumerateMethod", "");
            this.dfFunctionGroup.NamedProperties.Put("LovReference", "");
            this.dfFunctionGroup.NamedProperties.Put("ResizeableChildObject", "");
            this.dfFunctionGroup.NamedProperties.Put("SqlColumn", "FUNCTION_GROUP");
            this.dfFunctionGroup.NamedProperties.Put("ValidateMethod", "");
            // 
            // menuFrmMethods
            // 
            this.menuFrmMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem__Notes,
            this.menuItem_View,
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
            // menuItem_View
            // 
            this.menuItem_View.Command = this.menuFrmMethods_menuView__Multi_Company_Voucher___;
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
            this.menuItem_Change.Command = this.menuFrmMethods_menuChange__Company___;
            this.menuItem_Change.Name = "menuItem_Change";
            resources.ApplyResources(this.menuItem_Change, "menuItem_Change");
            this.menuItem_Change.Text = "Change &Company...";
            // 
            // menuOperations
            // 
            this.menuOperations.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem__Notes_1,
            this.menuItem_View_1,
            this.menuSeparator2,
            this.menuItem_Change_1});
            this.menuOperations.Name = "menuOperations";
            resources.ApplyResources(this.menuOperations, "menuOperations");
            // 
            // menuItem__Notes_1
            // 
            this.menuItem__Notes_1.Command = this.menuOperations_menu_Notes___;
            this.menuItem__Notes_1.Name = "menuItem__Notes_1";
            resources.ApplyResources(this.menuItem__Notes_1, "menuItem__Notes_1");
            this.menuItem__Notes_1.Text = "&Notes...";
            // 
            // menuItem_View_1
            // 
            this.menuItem_View_1.Command = this.menuOperations_menuView__Multi_Company_Voucher___;
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
            this.menuItem_Change_1.Command = this.menuOperations_menuChange__Company___;
            this.menuItem_Change_1.Name = "menuItem_Change_1";
            resources.ApplyResources(this.menuItem_Change_1, "menuItem_Change_1");
            this.menuItem_Change_1.Text = "Change &Company...";
            // 
            // menuTblMethods
            // 
            this.menuTblMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem__Notes_2,
            this.menuItem_View_2,
            this.menuSeparator3,
            this.menuItem_Change_2});
            this.menuTblMethods.Name = "menuTblMethods";
            resources.ApplyResources(this.menuTblMethods, "menuTblMethods");
            // 
            // menuItem__Notes_2
            // 
            this.menuItem__Notes_2.Command = this.menuTblMethods_menu_Notes___;
            this.menuItem__Notes_2.Name = "menuItem__Notes_2";
            resources.ApplyResources(this.menuItem__Notes_2, "menuItem__Notes_2");
            this.menuItem__Notes_2.Text = "&Notes...";
            // 
            // menuItem_View_2
            // 
            this.menuItem_View_2.Command = this.menuTblMethods_menuView__Multi_Company_Voucher___;
            this.menuItem_View_2.Name = "menuItem_View_2";
            resources.ApplyResources(this.menuItem_View_2, "menuItem_View_2");
            this.menuItem_View_2.Text = "View &Multi Company Voucher...";
            // 
            // menuSeparator3
            // 
            this.menuSeparator3.Name = "menuSeparator3";
            resources.ApplyResources(this.menuSeparator3, "menuSeparator3");
            // 
            // menuItem_Change_2
            // 
            this.menuItem_Change_2.Command = this.menuTblMethods_menuChange__Company___;
            this.menuItem_Change_2.Name = "menuItem_Change_2";
            resources.ApplyResources(this.menuItem_Change_2, "menuItem_Change_2");
            this.menuItem_Change_2.Text = "Change &Company...";
            // 
            // tblVoucherDetail
            // 
            this.tblVoucherDetail.Controls.Add(this.tblVoucherDetail_colCompany);
            this.tblVoucherDetail.Controls.Add(this.tblVoucherDetail_colAccountingYear);
            this.tblVoucherDetail.Controls.Add(this.tblVoucherDetail_colVoucherType);
            this.tblVoucherDetail.Controls.Add(this.tblVoucherDetail_colVoucherNo);
            this.tblVoucherDetail.Controls.Add(this.tblVoucherDetail_colRowNo);
            this.tblVoucherDetail.Controls.Add(this.tblVoucherDetail_colAccount);
            this.tblVoucherDetail.Controls.Add(this.tblVoucherDetail_colsAccountDesc);
            this.tblVoucherDetail.Controls.Add(this.tblVoucherDetail_colCodeB);
            this.tblVoucherDetail.Controls.Add(this.tblVoucherDetail_colsCodeBDesc);
            this.tblVoucherDetail.Controls.Add(this.tblVoucherDetail_colCodeC);
            this.tblVoucherDetail.Controls.Add(this.tblVoucherDetail_colsCodeCDesc);
            this.tblVoucherDetail.Controls.Add(this.tblVoucherDetail_colCodeD);
            this.tblVoucherDetail.Controls.Add(this.tblVoucherDetail_colsCodeDDesc);
            this.tblVoucherDetail.Controls.Add(this.tblVoucherDetail_colCodeE);
            this.tblVoucherDetail.Controls.Add(this.tblVoucherDetail_colsCodeEDesc);
            this.tblVoucherDetail.Controls.Add(this.tblVoucherDetail_colCodeF);
            this.tblVoucherDetail.Controls.Add(this.tblVoucherDetail_colsCodeFDesc);
            this.tblVoucherDetail.Controls.Add(this.tblVoucherDetail_colCodeG);
            this.tblVoucherDetail.Controls.Add(this.tblVoucherDetail_colsCodeGDesc);
            this.tblVoucherDetail.Controls.Add(this.tblVoucherDetail_colCodeH);
            this.tblVoucherDetail.Controls.Add(this.tblVoucherDetail_colsCodeHDesc);
            this.tblVoucherDetail.Controls.Add(this.tblVoucherDetail_colCodeI);
            this.tblVoucherDetail.Controls.Add(this.tblVoucherDetail_colsCodeIDesc);
            this.tblVoucherDetail.Controls.Add(this.tblVoucherDetail_colCodeJ);
            this.tblVoucherDetail.Controls.Add(this.tblVoucherDetail_colsCodeJDesc);
            this.tblVoucherDetail.Controls.Add(this.tblVoucherDetail_colMultiCompanyId);
            this.tblVoucherDetail.Controls.Add(this.tblVoucherDetail_colCorrection);
            this.tblVoucherDetail.Controls.Add(this.tblVoucherDetail_colCurrencyCode);
            this.tblVoucherDetail.Controls.Add(this.tblVoucherDetail_colCurrencyRate);
            this.tblVoucherDetail.Controls.Add(this.tblVoucherDetail_colConversionFactor);
            this.tblVoucherDetail.Controls.Add(this.tblVoucherDetail_colDebetAmount);
            this.tblVoucherDetail.Controls.Add(this.tblVoucherDetail_colCreditAmount);
            this.tblVoucherDetail.Controls.Add(this.tblVoucherDetail_colAmount);
            this.tblVoucherDetail.Controls.Add(this.tblVoucherDetail_colCurrencyDebetAmount);
            this.tblVoucherDetail.Controls.Add(this.tblVoucherDetail_colCurrencyCreditAmount);
            this.tblVoucherDetail.Controls.Add(this.tblVoucherDetail_colCurrencyAmount);
            this.tblVoucherDetail.Controls.Add(this.tblVoucherDetail_colnThirdCurrencyRate);
            this.tblVoucherDetail.Controls.Add(this.tblVoucherDetail_colnThirdCurrencyDebitAmount);
            this.tblVoucherDetail.Controls.Add(this.tblVoucherDetail_colnThirdCurrencyCreditAmount);
            this.tblVoucherDetail.Controls.Add(this.tblVoucherDetail_colnThirdCurrencyAmount);
            this.tblVoucherDetail.Controls.Add(this.tblVoucherDetail_colnParallelCurrencyRate);
            this.tblVoucherDetail.Controls.Add(this.tblVoucherDetail_colnParallelConversionFactor);
            this.tblVoucherDetail.Controls.Add(this.tblVoucherDetail_colText);
            this.tblVoucherDetail.Controls.Add(this.tblVoucherDetail_colQuantity);
            this.tblVoucherDetail.Controls.Add(this.tblVoucherDetail_colProcessCode);
            this.tblVoucherDetail.Controls.Add(this.tblVoucherDetail_colsDeliveryTypeId);
            this.tblVoucherDetail.Controls.Add(this.tblVoucherDetail_colsDeliveryTypeDescription);
            this.tblVoucherDetail.Controls.Add(this.tblVoucherDetail_colOptionalCode);
            this.tblVoucherDetail.Controls.Add(this.tblVoucherDetail_colProjActivityId);
            this.tblVoucherDetail.Controls.Add(this.tblVoucherDetail_colPartyTypeId);
            this.tblVoucherDetail.Controls.Add(this.tblVoucherDetail_colTransCode);
            this.tblVoucherDetail.Controls.Add(this.tblVoucherDetail_colTransferId);
            this.tblVoucherDetail.Controls.Add(this.tblVoucherDetail_colUpdateError);
            this.tblVoucherDetail.Controls.Add(this.tblVoucherDetail_colCorrected);
            this.tblVoucherDetail.Controls.Add(this.tblVoucherDetail_colPeriodical_Allocation);
            this.tblVoucherDetail.Controls.Add(this.tblVoucherDetail_colReferenceSerie);
            this.tblVoucherDetail.Controls.Add(this.tblVoucherDetail_colReferenceNumber);
            this.tblVoucherDetail.Controls.Add(this.tblVoucherDetail_colAutoTaxVouEntry);
            this.tblVoucherDetail.Controls.Add(this.tblVoucherDetail_colnRowGroupId);
            resources.ApplyResources(this.tblVoucherDetail, "tblVoucherDetail");
            this.tblVoucherDetail.Name = "tblVoucherDetail";
            this.tblVoucherDetail.NamedProperties.Put("DefaultOrderBy", "ROW_NO");
            this.tblVoucherDetail.NamedProperties.Put("DefaultWhere", @"COMPANY = :global.company
AND VOUCHER_TYPE = :i_hWndFrame.frmQueryVoucherDetail.ccVoucherType.i_sMyValue
AND VOUCHER_NO = to_number(:i_hWndFrame.frmQueryVoucherDetail.dfVoucherNo)
AND ACCOUNTING_YEAR = to_number(:i_hWndFrame.frmQueryVoucherDetail.dfAccountingYear)");
            this.tblVoucherDetail.NamedProperties.Put("LogicalUnit", "VoucherRow");
            this.tblVoucherDetail.NamedProperties.Put("PackageName", "VOUCHER_ROW_API");
            this.tblVoucherDetail.NamedProperties.Put("ResizeableChildObject", "LLMM");
            this.tblVoucherDetail.NamedProperties.Put("SourceFlags", "16832");
            this.tblVoucherDetail.NamedProperties.Put("ViewName", "VOUCHER_ROW");
            this.tblVoucherDetail.NamedProperties.Put("Warnings", "FALSE");
            this.tblVoucherDetail.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVoucherDetail_WindowActions);
            this.tblVoucherDetail.Controls.SetChildIndex(this.tblVoucherDetail_colnRowGroupId, 0);
            this.tblVoucherDetail.Controls.SetChildIndex(this.tblVoucherDetail_colAutoTaxVouEntry, 0);
            this.tblVoucherDetail.Controls.SetChildIndex(this.tblVoucherDetail_colReferenceNumber, 0);
            this.tblVoucherDetail.Controls.SetChildIndex(this.tblVoucherDetail_colReferenceSerie, 0);
            this.tblVoucherDetail.Controls.SetChildIndex(this.tblVoucherDetail_colPeriodical_Allocation, 0);
            this.tblVoucherDetail.Controls.SetChildIndex(this.tblVoucherDetail_colCorrected, 0);
            this.tblVoucherDetail.Controls.SetChildIndex(this.tblVoucherDetail_colUpdateError, 0);
            this.tblVoucherDetail.Controls.SetChildIndex(this.tblVoucherDetail_colTransferId, 0);
            this.tblVoucherDetail.Controls.SetChildIndex(this.tblVoucherDetail_colTransCode, 0);
            this.tblVoucherDetail.Controls.SetChildIndex(this.tblVoucherDetail_colPartyTypeId, 0);
            this.tblVoucherDetail.Controls.SetChildIndex(this.tblVoucherDetail_colProjActivityId, 0);
            this.tblVoucherDetail.Controls.SetChildIndex(this.tblVoucherDetail_colOptionalCode, 0);
            this.tblVoucherDetail.Controls.SetChildIndex(this.tblVoucherDetail_colsDeliveryTypeDescription, 0);
            this.tblVoucherDetail.Controls.SetChildIndex(this.tblVoucherDetail_colsDeliveryTypeId, 0);
            this.tblVoucherDetail.Controls.SetChildIndex(this.tblVoucherDetail_colProcessCode, 0);
            this.tblVoucherDetail.Controls.SetChildIndex(this.tblVoucherDetail_colQuantity, 0);
            this.tblVoucherDetail.Controls.SetChildIndex(this.tblVoucherDetail_colText, 0);
            this.tblVoucherDetail.Controls.SetChildIndex(this.tblVoucherDetail_colnParallelConversionFactor, 0);
            this.tblVoucherDetail.Controls.SetChildIndex(this.tblVoucherDetail_colnParallelCurrencyRate, 0);
            this.tblVoucherDetail.Controls.SetChildIndex(this.tblVoucherDetail_colnThirdCurrencyAmount, 0);
            this.tblVoucherDetail.Controls.SetChildIndex(this.tblVoucherDetail_colnThirdCurrencyCreditAmount, 0);
            this.tblVoucherDetail.Controls.SetChildIndex(this.tblVoucherDetail_colnThirdCurrencyDebitAmount, 0);
            this.tblVoucherDetail.Controls.SetChildIndex(this.tblVoucherDetail_colnThirdCurrencyRate, 0);
            this.tblVoucherDetail.Controls.SetChildIndex(this.tblVoucherDetail_colCurrencyAmount, 0);
            this.tblVoucherDetail.Controls.SetChildIndex(this.tblVoucherDetail_colCurrencyCreditAmount, 0);
            this.tblVoucherDetail.Controls.SetChildIndex(this.tblVoucherDetail_colCurrencyDebetAmount, 0);
            this.tblVoucherDetail.Controls.SetChildIndex(this.tblVoucherDetail_colAmount, 0);
            this.tblVoucherDetail.Controls.SetChildIndex(this.tblVoucherDetail_colCreditAmount, 0);
            this.tblVoucherDetail.Controls.SetChildIndex(this.tblVoucherDetail_colDebetAmount, 0);
            this.tblVoucherDetail.Controls.SetChildIndex(this.tblVoucherDetail_colConversionFactor, 0);
            this.tblVoucherDetail.Controls.SetChildIndex(this.tblVoucherDetail_colCurrencyRate, 0);
            this.tblVoucherDetail.Controls.SetChildIndex(this.tblVoucherDetail_colCurrencyCode, 0);
            this.tblVoucherDetail.Controls.SetChildIndex(this.tblVoucherDetail_colCorrection, 0);
            this.tblVoucherDetail.Controls.SetChildIndex(this.tblVoucherDetail_colMultiCompanyId, 0);
            this.tblVoucherDetail.Controls.SetChildIndex(this.tblVoucherDetail_colsCodeJDesc, 0);
            this.tblVoucherDetail.Controls.SetChildIndex(this.tblVoucherDetail_colCodeJ, 0);
            this.tblVoucherDetail.Controls.SetChildIndex(this.tblVoucherDetail_colsCodeIDesc, 0);
            this.tblVoucherDetail.Controls.SetChildIndex(this.tblVoucherDetail_colCodeI, 0);
            this.tblVoucherDetail.Controls.SetChildIndex(this.tblVoucherDetail_colsCodeHDesc, 0);
            this.tblVoucherDetail.Controls.SetChildIndex(this.tblVoucherDetail_colCodeH, 0);
            this.tblVoucherDetail.Controls.SetChildIndex(this.tblVoucherDetail_colsCodeGDesc, 0);
            this.tblVoucherDetail.Controls.SetChildIndex(this.tblVoucherDetail_colCodeG, 0);
            this.tblVoucherDetail.Controls.SetChildIndex(this.tblVoucherDetail_colsCodeFDesc, 0);
            this.tblVoucherDetail.Controls.SetChildIndex(this.tblVoucherDetail_colCodeF, 0);
            this.tblVoucherDetail.Controls.SetChildIndex(this.tblVoucherDetail_colsCodeEDesc, 0);
            this.tblVoucherDetail.Controls.SetChildIndex(this.tblVoucherDetail_colCodeE, 0);
            this.tblVoucherDetail.Controls.SetChildIndex(this.tblVoucherDetail_colsCodeDDesc, 0);
            this.tblVoucherDetail.Controls.SetChildIndex(this.tblVoucherDetail_colCodeD, 0);
            this.tblVoucherDetail.Controls.SetChildIndex(this.tblVoucherDetail_colsCodeCDesc, 0);
            this.tblVoucherDetail.Controls.SetChildIndex(this.tblVoucherDetail_colCodeC, 0);
            this.tblVoucherDetail.Controls.SetChildIndex(this.tblVoucherDetail_colsCodeBDesc, 0);
            this.tblVoucherDetail.Controls.SetChildIndex(this.tblVoucherDetail_colCodeB, 0);
            this.tblVoucherDetail.Controls.SetChildIndex(this.tblVoucherDetail_colsAccountDesc, 0);
            this.tblVoucherDetail.Controls.SetChildIndex(this.tblVoucherDetail_colAccount, 0);
            this.tblVoucherDetail.Controls.SetChildIndex(this.tblVoucherDetail_colRowNo, 0);
            this.tblVoucherDetail.Controls.SetChildIndex(this.tblVoucherDetail_colVoucherNo, 0);
            this.tblVoucherDetail.Controls.SetChildIndex(this.tblVoucherDetail_colVoucherType, 0);
            this.tblVoucherDetail.Controls.SetChildIndex(this.tblVoucherDetail_colAccountingYear, 0);
            this.tblVoucherDetail.Controls.SetChildIndex(this.tblVoucherDetail_colCompany, 0);
            // 
            // tblVoucherDetail_colCompany
            // 
            resources.ApplyResources(this.tblVoucherDetail_colCompany, "tblVoucherDetail_colCompany");
            this.tblVoucherDetail_colCompany.MaxLength = 20;
            this.tblVoucherDetail_colCompany.Name = "tblVoucherDetail_colCompany";
            this.tblVoucherDetail_colCompany.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherDetail_colCompany.NamedProperties.Put("FieldFlags", "71");
            this.tblVoucherDetail_colCompany.NamedProperties.Put("LovReference", "");
            this.tblVoucherDetail_colCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherDetail_colCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.tblVoucherDetail_colCompany.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherDetail_colCompany.Position = 3;
            // 
            // tblVoucherDetail_colAccountingYear
            // 
            this.tblVoucherDetail_colAccountingYear.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.tblVoucherDetail_colAccountingYear, "tblVoucherDetail_colAccountingYear");
            this.tblVoucherDetail_colAccountingYear.MaxLength = 4;
            this.tblVoucherDetail_colAccountingYear.Name = "tblVoucherDetail_colAccountingYear";
            this.tblVoucherDetail_colAccountingYear.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherDetail_colAccountingYear.NamedProperties.Put("FieldFlags", "103");
            this.tblVoucherDetail_colAccountingYear.NamedProperties.Put("LovReference", "");
            this.tblVoucherDetail_colAccountingYear.NamedProperties.Put("SqlColumn", "ACCOUNTING_YEAR");
            this.tblVoucherDetail_colAccountingYear.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherDetail_colAccountingYear.Position = 4;
            // 
            // tblVoucherDetail_colVoucherType
            // 
            resources.ApplyResources(this.tblVoucherDetail_colVoucherType, "tblVoucherDetail_colVoucherType");
            this.tblVoucherDetail_colVoucherType.MaxLength = 3;
            this.tblVoucherDetail_colVoucherType.Name = "tblVoucherDetail_colVoucherType";
            this.tblVoucherDetail_colVoucherType.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherDetail_colVoucherType.NamedProperties.Put("FieldFlags", "99");
            this.tblVoucherDetail_colVoucherType.NamedProperties.Put("LovReference", "");
            this.tblVoucherDetail_colVoucherType.NamedProperties.Put("SqlColumn", "VOUCHER_TYPE");
            this.tblVoucherDetail_colVoucherType.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherDetail_colVoucherType.Position = 5;
            // 
            // tblVoucherDetail_colVoucherNo
            // 
            this.tblVoucherDetail_colVoucherNo.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.tblVoucherDetail_colVoucherNo, "tblVoucherDetail_colVoucherNo");
            this.tblVoucherDetail_colVoucherNo.MaxLength = 10;
            this.tblVoucherDetail_colVoucherNo.Name = "tblVoucherDetail_colVoucherNo";
            this.tblVoucherDetail_colVoucherNo.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherDetail_colVoucherNo.NamedProperties.Put("FieldFlags", "99");
            this.tblVoucherDetail_colVoucherNo.NamedProperties.Put("LovReference", "");
            this.tblVoucherDetail_colVoucherNo.NamedProperties.Put("SqlColumn", "VOUCHER_NO");
            this.tblVoucherDetail_colVoucherNo.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherDetail_colVoucherNo.Position = 6;
            // 
            // tblVoucherDetail_colRowNo
            // 
            this.tblVoucherDetail_colRowNo.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVoucherDetail_colRowNo.MaxLength = 5;
            this.tblVoucherDetail_colRowNo.Name = "tblVoucherDetail_colRowNo";
            this.tblVoucherDetail_colRowNo.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherDetail_colRowNo.NamedProperties.Put("FieldFlags", "163");
            this.tblVoucherDetail_colRowNo.NamedProperties.Put("LovReference", "");
            this.tblVoucherDetail_colRowNo.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherDetail_colRowNo.NamedProperties.Put("SqlColumn", "ROW_NO");
            this.tblVoucherDetail_colRowNo.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherDetail_colRowNo.Position = 7;
            resources.ApplyResources(this.tblVoucherDetail_colRowNo, "tblVoucherDetail_colRowNo");
            // 
            // tblVoucherDetail_colAccount
            // 
            this.tblVoucherDetail_colAccount.MaxLength = 20;
            this.tblVoucherDetail_colAccount.Name = "tblVoucherDetail_colAccount";
            this.tblVoucherDetail_colAccount.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherDetail_colAccount.NamedProperties.Put("FieldFlags", "288");
            this.tblVoucherDetail_colAccount.NamedProperties.Put("LovReference", "ACCOUNTS_CONSOLIDATION(COMPANY)");
            this.tblVoucherDetail_colAccount.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherDetail_colAccount.NamedProperties.Put("SqlColumn", "ACCOUNT");
            this.tblVoucherDetail_colAccount.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherDetail_colAccount.Position = 8;
            resources.ApplyResources(this.tblVoucherDetail_colAccount, "tblVoucherDetail_colAccount");
            // 
            // tblVoucherDetail_colsAccountDesc
            // 
            this.tblVoucherDetail_colsAccountDesc.Name = "tblVoucherDetail_colsAccountDesc";
            this.tblVoucherDetail_colsAccountDesc.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherDetail_colsAccountDesc.NamedProperties.Put("FieldFlags", "2304");
            this.tblVoucherDetail_colsAccountDesc.NamedProperties.Put("LovReference", "");
            this.tblVoucherDetail_colsAccountDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherDetail_colsAccountDesc.NamedProperties.Put("SqlColumn", "ACCOUNT_DESC");
            this.tblVoucherDetail_colsAccountDesc.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherDetail_colsAccountDesc.Position = 9;
            resources.ApplyResources(this.tblVoucherDetail_colsAccountDesc, "tblVoucherDetail_colsAccountDesc");
            // 
            // tblVoucherDetail_colCodeB
            // 
            this.tblVoucherDetail_colCodeB.MaxLength = 20;
            this.tblVoucherDetail_colCodeB.Name = "tblVoucherDetail_colCodeB";
            this.tblVoucherDetail_colCodeB.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherDetail_colCodeB.NamedProperties.Put("FieldFlags", "288");
            this.tblVoucherDetail_colCodeB.NamedProperties.Put("LovReference", "CODE_B(COMPANY)");
            this.tblVoucherDetail_colCodeB.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherDetail_colCodeB.NamedProperties.Put("SqlColumn", "CODE_B");
            this.tblVoucherDetail_colCodeB.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherDetail_colCodeB.Position = 10;
            resources.ApplyResources(this.tblVoucherDetail_colCodeB, "tblVoucherDetail_colCodeB");
            // 
            // tblVoucherDetail_colsCodeBDesc
            // 
            this.tblVoucherDetail_colsCodeBDesc.Name = "tblVoucherDetail_colsCodeBDesc";
            this.tblVoucherDetail_colsCodeBDesc.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherDetail_colsCodeBDesc.NamedProperties.Put("FieldFlags", "2304");
            this.tblVoucherDetail_colsCodeBDesc.NamedProperties.Put("LovReference", "");
            this.tblVoucherDetail_colsCodeBDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherDetail_colsCodeBDesc.NamedProperties.Put("SqlColumn", "CODE_B_DESC");
            this.tblVoucherDetail_colsCodeBDesc.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherDetail_colsCodeBDesc.Position = 11;
            resources.ApplyResources(this.tblVoucherDetail_colsCodeBDesc, "tblVoucherDetail_colsCodeBDesc");
            // 
            // tblVoucherDetail_colCodeC
            // 
            this.tblVoucherDetail_colCodeC.MaxLength = 20;
            this.tblVoucherDetail_colCodeC.Name = "tblVoucherDetail_colCodeC";
            this.tblVoucherDetail_colCodeC.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherDetail_colCodeC.NamedProperties.Put("FieldFlags", "288");
            this.tblVoucherDetail_colCodeC.NamedProperties.Put("LovReference", "CODE_C(COMPANY)");
            this.tblVoucherDetail_colCodeC.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherDetail_colCodeC.NamedProperties.Put("SqlColumn", "CODE_C");
            this.tblVoucherDetail_colCodeC.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherDetail_colCodeC.Position = 12;
            resources.ApplyResources(this.tblVoucherDetail_colCodeC, "tblVoucherDetail_colCodeC");
            // 
            // tblVoucherDetail_colsCodeCDesc
            // 
            this.tblVoucherDetail_colsCodeCDesc.Name = "tblVoucherDetail_colsCodeCDesc";
            this.tblVoucherDetail_colsCodeCDesc.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherDetail_colsCodeCDesc.NamedProperties.Put("FieldFlags", "2304");
            this.tblVoucherDetail_colsCodeCDesc.NamedProperties.Put("LovReference", "");
            this.tblVoucherDetail_colsCodeCDesc.NamedProperties.Put("SqlColumn", "CODE_C_DESC");
            this.tblVoucherDetail_colsCodeCDesc.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherDetail_colsCodeCDesc.Position = 13;
            resources.ApplyResources(this.tblVoucherDetail_colsCodeCDesc, "tblVoucherDetail_colsCodeCDesc");
            // 
            // tblVoucherDetail_colCodeD
            // 
            this.tblVoucherDetail_colCodeD.MaxLength = 20;
            this.tblVoucherDetail_colCodeD.Name = "tblVoucherDetail_colCodeD";
            this.tblVoucherDetail_colCodeD.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherDetail_colCodeD.NamedProperties.Put("FieldFlags", "288");
            this.tblVoucherDetail_colCodeD.NamedProperties.Put("LovReference", "CODE_D(COMPANY)");
            this.tblVoucherDetail_colCodeD.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherDetail_colCodeD.NamedProperties.Put("SqlColumn", "CODE_D");
            this.tblVoucherDetail_colCodeD.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherDetail_colCodeD.Position = 14;
            resources.ApplyResources(this.tblVoucherDetail_colCodeD, "tblVoucherDetail_colCodeD");
            // 
            // tblVoucherDetail_colsCodeDDesc
            // 
            this.tblVoucherDetail_colsCodeDDesc.Name = "tblVoucherDetail_colsCodeDDesc";
            this.tblVoucherDetail_colsCodeDDesc.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherDetail_colsCodeDDesc.NamedProperties.Put("FieldFlags", "2304");
            this.tblVoucherDetail_colsCodeDDesc.NamedProperties.Put("LovReference", "");
            this.tblVoucherDetail_colsCodeDDesc.NamedProperties.Put("SqlColumn", "CODE_D_DESC");
            this.tblVoucherDetail_colsCodeDDesc.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherDetail_colsCodeDDesc.Position = 15;
            resources.ApplyResources(this.tblVoucherDetail_colsCodeDDesc, "tblVoucherDetail_colsCodeDDesc");
            // 
            // tblVoucherDetail_colCodeE
            // 
            this.tblVoucherDetail_colCodeE.MaxLength = 20;
            this.tblVoucherDetail_colCodeE.Name = "tblVoucherDetail_colCodeE";
            this.tblVoucherDetail_colCodeE.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherDetail_colCodeE.NamedProperties.Put("FieldFlags", "288");
            this.tblVoucherDetail_colCodeE.NamedProperties.Put("LovReference", "CODE_E(COMPANY)");
            this.tblVoucherDetail_colCodeE.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherDetail_colCodeE.NamedProperties.Put("SqlColumn", "CODE_E");
            this.tblVoucherDetail_colCodeE.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherDetail_colCodeE.Position = 16;
            resources.ApplyResources(this.tblVoucherDetail_colCodeE, "tblVoucherDetail_colCodeE");
            // 
            // tblVoucherDetail_colsCodeEDesc
            // 
            this.tblVoucherDetail_colsCodeEDesc.Name = "tblVoucherDetail_colsCodeEDesc";
            this.tblVoucherDetail_colsCodeEDesc.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherDetail_colsCodeEDesc.NamedProperties.Put("FieldFlags", "2304");
            this.tblVoucherDetail_colsCodeEDesc.NamedProperties.Put("LovReference", "");
            this.tblVoucherDetail_colsCodeEDesc.NamedProperties.Put("SqlColumn", "CODE_E_DESC");
            this.tblVoucherDetail_colsCodeEDesc.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherDetail_colsCodeEDesc.Position = 17;
            resources.ApplyResources(this.tblVoucherDetail_colsCodeEDesc, "tblVoucherDetail_colsCodeEDesc");
            // 
            // tblVoucherDetail_colCodeF
            // 
            this.tblVoucherDetail_colCodeF.MaxLength = 20;
            this.tblVoucherDetail_colCodeF.Name = "tblVoucherDetail_colCodeF";
            this.tblVoucherDetail_colCodeF.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherDetail_colCodeF.NamedProperties.Put("FieldFlags", "288");
            this.tblVoucherDetail_colCodeF.NamedProperties.Put("LovReference", "CODE_F(COMPANY)");
            this.tblVoucherDetail_colCodeF.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherDetail_colCodeF.NamedProperties.Put("SqlColumn", "CODE_F");
            this.tblVoucherDetail_colCodeF.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherDetail_colCodeF.Position = 18;
            resources.ApplyResources(this.tblVoucherDetail_colCodeF, "tblVoucherDetail_colCodeF");
            // 
            // tblVoucherDetail_colsCodeFDesc
            // 
            this.tblVoucherDetail_colsCodeFDesc.Name = "tblVoucherDetail_colsCodeFDesc";
            this.tblVoucherDetail_colsCodeFDesc.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherDetail_colsCodeFDesc.NamedProperties.Put("FieldFlags", "2304");
            this.tblVoucherDetail_colsCodeFDesc.NamedProperties.Put("LovReference", "");
            this.tblVoucherDetail_colsCodeFDesc.NamedProperties.Put("SqlColumn", "CODE_F_DESC");
            this.tblVoucherDetail_colsCodeFDesc.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherDetail_colsCodeFDesc.Position = 19;
            resources.ApplyResources(this.tblVoucherDetail_colsCodeFDesc, "tblVoucherDetail_colsCodeFDesc");
            // 
            // tblVoucherDetail_colCodeG
            // 
            this.tblVoucherDetail_colCodeG.MaxLength = 20;
            this.tblVoucherDetail_colCodeG.Name = "tblVoucherDetail_colCodeG";
            this.tblVoucherDetail_colCodeG.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherDetail_colCodeG.NamedProperties.Put("FieldFlags", "288");
            this.tblVoucherDetail_colCodeG.NamedProperties.Put("LovReference", "CODE_G(COMPANY)");
            this.tblVoucherDetail_colCodeG.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherDetail_colCodeG.NamedProperties.Put("SqlColumn", "CODE_G");
            this.tblVoucherDetail_colCodeG.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherDetail_colCodeG.Position = 20;
            resources.ApplyResources(this.tblVoucherDetail_colCodeG, "tblVoucherDetail_colCodeG");
            // 
            // tblVoucherDetail_colsCodeGDesc
            // 
            this.tblVoucherDetail_colsCodeGDesc.Name = "tblVoucherDetail_colsCodeGDesc";
            this.tblVoucherDetail_colsCodeGDesc.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherDetail_colsCodeGDesc.NamedProperties.Put("FieldFlags", "2304");
            this.tblVoucherDetail_colsCodeGDesc.NamedProperties.Put("LovReference", "");
            this.tblVoucherDetail_colsCodeGDesc.NamedProperties.Put("SqlColumn", "CODE_G_DESC");
            this.tblVoucherDetail_colsCodeGDesc.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherDetail_colsCodeGDesc.Position = 21;
            resources.ApplyResources(this.tblVoucherDetail_colsCodeGDesc, "tblVoucherDetail_colsCodeGDesc");
            // 
            // tblVoucherDetail_colCodeH
            // 
            this.tblVoucherDetail_colCodeH.MaxLength = 20;
            this.tblVoucherDetail_colCodeH.Name = "tblVoucherDetail_colCodeH";
            this.tblVoucherDetail_colCodeH.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherDetail_colCodeH.NamedProperties.Put("FieldFlags", "288");
            this.tblVoucherDetail_colCodeH.NamedProperties.Put("LovReference", "CODE_H(COMPANY)");
            this.tblVoucherDetail_colCodeH.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherDetail_colCodeH.NamedProperties.Put("SqlColumn", "CODE_H");
            this.tblVoucherDetail_colCodeH.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherDetail_colCodeH.Position = 22;
            resources.ApplyResources(this.tblVoucherDetail_colCodeH, "tblVoucherDetail_colCodeH");
            // 
            // tblVoucherDetail_colsCodeHDesc
            // 
            this.tblVoucherDetail_colsCodeHDesc.Name = "tblVoucherDetail_colsCodeHDesc";
            this.tblVoucherDetail_colsCodeHDesc.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherDetail_colsCodeHDesc.NamedProperties.Put("FieldFlags", "2304");
            this.tblVoucherDetail_colsCodeHDesc.NamedProperties.Put("LovReference", "");
            this.tblVoucherDetail_colsCodeHDesc.NamedProperties.Put("SqlColumn", "CODE_H_DESC");
            this.tblVoucherDetail_colsCodeHDesc.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherDetail_colsCodeHDesc.Position = 23;
            resources.ApplyResources(this.tblVoucherDetail_colsCodeHDesc, "tblVoucherDetail_colsCodeHDesc");
            // 
            // tblVoucherDetail_colCodeI
            // 
            this.tblVoucherDetail_colCodeI.MaxLength = 20;
            this.tblVoucherDetail_colCodeI.Name = "tblVoucherDetail_colCodeI";
            this.tblVoucherDetail_colCodeI.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherDetail_colCodeI.NamedProperties.Put("FieldFlags", "288");
            this.tblVoucherDetail_colCodeI.NamedProperties.Put("LovReference", "CODE_I(COMPANY)");
            this.tblVoucherDetail_colCodeI.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherDetail_colCodeI.NamedProperties.Put("SqlColumn", "CODE_I");
            this.tblVoucherDetail_colCodeI.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherDetail_colCodeI.Position = 24;
            resources.ApplyResources(this.tblVoucherDetail_colCodeI, "tblVoucherDetail_colCodeI");
            // 
            // tblVoucherDetail_colsCodeIDesc
            // 
            this.tblVoucherDetail_colsCodeIDesc.Name = "tblVoucherDetail_colsCodeIDesc";
            this.tblVoucherDetail_colsCodeIDesc.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherDetail_colsCodeIDesc.NamedProperties.Put("FieldFlags", "2304");
            this.tblVoucherDetail_colsCodeIDesc.NamedProperties.Put("LovReference", "");
            this.tblVoucherDetail_colsCodeIDesc.NamedProperties.Put("SqlColumn", "CODE_I_DESC");
            this.tblVoucherDetail_colsCodeIDesc.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherDetail_colsCodeIDesc.Position = 25;
            resources.ApplyResources(this.tblVoucherDetail_colsCodeIDesc, "tblVoucherDetail_colsCodeIDesc");
            // 
            // tblVoucherDetail_colCodeJ
            // 
            this.tblVoucherDetail_colCodeJ.MaxLength = 20;
            this.tblVoucherDetail_colCodeJ.Name = "tblVoucherDetail_colCodeJ";
            this.tblVoucherDetail_colCodeJ.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherDetail_colCodeJ.NamedProperties.Put("FieldFlags", "288");
            this.tblVoucherDetail_colCodeJ.NamedProperties.Put("LovReference", "CODE_J(COMPANY)");
            this.tblVoucherDetail_colCodeJ.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherDetail_colCodeJ.NamedProperties.Put("SqlColumn", "CODE_J");
            this.tblVoucherDetail_colCodeJ.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherDetail_colCodeJ.Position = 26;
            resources.ApplyResources(this.tblVoucherDetail_colCodeJ, "tblVoucherDetail_colCodeJ");
            // 
            // tblVoucherDetail_colsCodeJDesc
            // 
            this.tblVoucherDetail_colsCodeJDesc.Name = "tblVoucherDetail_colsCodeJDesc";
            this.tblVoucherDetail_colsCodeJDesc.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherDetail_colsCodeJDesc.NamedProperties.Put("FieldFlags", "2304");
            this.tblVoucherDetail_colsCodeJDesc.NamedProperties.Put("LovReference", "");
            this.tblVoucherDetail_colsCodeJDesc.NamedProperties.Put("SqlColumn", "CODE_J_DESC");
            this.tblVoucherDetail_colsCodeJDesc.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherDetail_colsCodeJDesc.Position = 27;
            resources.ApplyResources(this.tblVoucherDetail_colsCodeJDesc, "tblVoucherDetail_colsCodeJDesc");
            // 
            // tblVoucherDetail_colMultiCompanyId
            // 
            this.tblVoucherDetail_colMultiCompanyId.MaxLength = 2000;
            this.tblVoucherDetail_colMultiCompanyId.Name = "tblVoucherDetail_colMultiCompanyId";
            this.tblVoucherDetail_colMultiCompanyId.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherDetail_colMultiCompanyId.NamedProperties.Put("FieldFlags", "288");
            this.tblVoucherDetail_colMultiCompanyId.NamedProperties.Put("LovReference", "");
            this.tblVoucherDetail_colMultiCompanyId.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherDetail_colMultiCompanyId.NamedProperties.Put("SqlColumn", "VOUCHER_ROW_API.Is_Multi_Company_Voucher_Row(COMPANY,VOUCHER_TYPE,ACCOUNTING_YEAR" +
        ",VOUCHER_NO,ROW_NO)");
            this.tblVoucherDetail_colMultiCompanyId.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherDetail_colMultiCompanyId.Position = 28;
            resources.ApplyResources(this.tblVoucherDetail_colMultiCompanyId, "tblVoucherDetail_colMultiCompanyId");
            // 
            // tblVoucherDetail_colCorrection
            // 
            this.tblVoucherDetail_colCorrection.Name = "tblVoucherDetail_colCorrection";
            this.tblVoucherDetail_colCorrection.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherDetail_colCorrection.NamedProperties.Put("FieldFlags", "290");
            this.tblVoucherDetail_colCorrection.NamedProperties.Put("LovReference", "");
            this.tblVoucherDetail_colCorrection.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherDetail_colCorrection.NamedProperties.Put("SqlColumn", "CORRECTION");
            this.tblVoucherDetail_colCorrection.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherDetail_colCorrection.Position = 29;
            resources.ApplyResources(this.tblVoucherDetail_colCorrection, "tblVoucherDetail_colCorrection");
            // 
            // tblVoucherDetail_colCurrencyCode
            // 
            this.tblVoucherDetail_colCurrencyCode.MaxLength = 3;
            this.tblVoucherDetail_colCurrencyCode.Name = "tblVoucherDetail_colCurrencyCode";
            this.tblVoucherDetail_colCurrencyCode.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherDetail_colCurrencyCode.NamedProperties.Put("FieldFlags", "290");
            this.tblVoucherDetail_colCurrencyCode.NamedProperties.Put("LovReference", "");
            this.tblVoucherDetail_colCurrencyCode.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherDetail_colCurrencyCode.NamedProperties.Put("SqlColumn", "CURRENCY_CODE");
            this.tblVoucherDetail_colCurrencyCode.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherDetail_colCurrencyCode.Position = 30;
            resources.ApplyResources(this.tblVoucherDetail_colCurrencyCode, "tblVoucherDetail_colCurrencyCode");
            // 
            // tblVoucherDetail_colCurrencyRate
            // 
            this.tblVoucherDetail_colCurrencyRate.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVoucherDetail_colCurrencyRate.Name = "tblVoucherDetail_colCurrencyRate";
            this.tblVoucherDetail_colCurrencyRate.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherDetail_colCurrencyRate.NamedProperties.Put("FieldFlags", "288");
            this.tblVoucherDetail_colCurrencyRate.NamedProperties.Put("LovReference", "");
            this.tblVoucherDetail_colCurrencyRate.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherDetail_colCurrencyRate.NamedProperties.Put("SqlColumn", "CURRENCY_RATE");
            this.tblVoucherDetail_colCurrencyRate.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherDetail_colCurrencyRate.Position = 31;
            this.tblVoucherDetail_colCurrencyRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblVoucherDetail_colCurrencyRate, "tblVoucherDetail_colCurrencyRate");
            // 
            // tblVoucherDetail_colConversionFactor
            // 
            this.tblVoucherDetail_colConversionFactor.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVoucherDetail_colConversionFactor.Name = "tblVoucherDetail_colConversionFactor";
            this.tblVoucherDetail_colConversionFactor.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherDetail_colConversionFactor.NamedProperties.Put("FieldFlags", "288");
            this.tblVoucherDetail_colConversionFactor.NamedProperties.Put("LovReference", "");
            this.tblVoucherDetail_colConversionFactor.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherDetail_colConversionFactor.NamedProperties.Put("SqlColumn", "CONVERSION_FACTOR");
            this.tblVoucherDetail_colConversionFactor.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherDetail_colConversionFactor.Position = 32;
            this.tblVoucherDetail_colConversionFactor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblVoucherDetail_colConversionFactor, "tblVoucherDetail_colConversionFactor");
            // 
            // tblVoucherDetail_colDebetAmount
            // 
            this.tblVoucherDetail_colDebetAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVoucherDetail_colDebetAmount.MaxLength = 15;
            this.tblVoucherDetail_colDebetAmount.Name = "tblVoucherDetail_colDebetAmount";
            this.tblVoucherDetail_colDebetAmount.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherDetail_colDebetAmount.NamedProperties.Put("FieldFlags", "290");
            this.tblVoucherDetail_colDebetAmount.NamedProperties.Put("Format", "20");
            this.tblVoucherDetail_colDebetAmount.NamedProperties.Put("LovReference", "");
            this.tblVoucherDetail_colDebetAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherDetail_colDebetAmount.NamedProperties.Put("SqlColumn", "DEBET_AMOUNT");
            this.tblVoucherDetail_colDebetAmount.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherDetail_colDebetAmount.Position = 33;
            this.tblVoucherDetail_colDebetAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblVoucherDetail_colDebetAmount, "tblVoucherDetail_colDebetAmount");
            // 
            // tblVoucherDetail_colCreditAmount
            // 
            this.tblVoucherDetail_colCreditAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVoucherDetail_colCreditAmount.MaxLength = 15;
            this.tblVoucherDetail_colCreditAmount.Name = "tblVoucherDetail_colCreditAmount";
            this.tblVoucherDetail_colCreditAmount.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherDetail_colCreditAmount.NamedProperties.Put("FieldFlags", "290");
            this.tblVoucherDetail_colCreditAmount.NamedProperties.Put("Format", "20");
            this.tblVoucherDetail_colCreditAmount.NamedProperties.Put("LovReference", "");
            this.tblVoucherDetail_colCreditAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherDetail_colCreditAmount.NamedProperties.Put("SqlColumn", "CREDIT_AMOUNT");
            this.tblVoucherDetail_colCreditAmount.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherDetail_colCreditAmount.Position = 34;
            this.tblVoucherDetail_colCreditAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblVoucherDetail_colCreditAmount, "tblVoucherDetail_colCreditAmount");
            // 
            // tblVoucherDetail_colAmount
            // 
            this.tblVoucherDetail_colAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVoucherDetail_colAmount.MaxLength = 15;
            this.tblVoucherDetail_colAmount.Name = "tblVoucherDetail_colAmount";
            this.tblVoucherDetail_colAmount.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherDetail_colAmount.NamedProperties.Put("FieldFlags", "291");
            this.tblVoucherDetail_colAmount.NamedProperties.Put("Format", "20");
            this.tblVoucherDetail_colAmount.NamedProperties.Put("LovReference", "");
            this.tblVoucherDetail_colAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherDetail_colAmount.NamedProperties.Put("SqlColumn", "AMOUNT");
            this.tblVoucherDetail_colAmount.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherDetail_colAmount.Position = 35;
            this.tblVoucherDetail_colAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblVoucherDetail_colAmount, "tblVoucherDetail_colAmount");
            // 
            // tblVoucherDetail_colCurrencyDebetAmount
            // 
            this.tblVoucherDetail_colCurrencyDebetAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVoucherDetail_colCurrencyDebetAmount.MaxLength = 15;
            this.tblVoucherDetail_colCurrencyDebetAmount.Name = "tblVoucherDetail_colCurrencyDebetAmount";
            this.tblVoucherDetail_colCurrencyDebetAmount.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherDetail_colCurrencyDebetAmount.NamedProperties.Put("FieldFlags", "290");
            this.tblVoucherDetail_colCurrencyDebetAmount.NamedProperties.Put("Format", "20");
            this.tblVoucherDetail_colCurrencyDebetAmount.NamedProperties.Put("LovReference", "");
            this.tblVoucherDetail_colCurrencyDebetAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherDetail_colCurrencyDebetAmount.NamedProperties.Put("SqlColumn", "CURRENCY_DEBET_AMOUNT");
            this.tblVoucherDetail_colCurrencyDebetAmount.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherDetail_colCurrencyDebetAmount.Position = 36;
            this.tblVoucherDetail_colCurrencyDebetAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblVoucherDetail_colCurrencyDebetAmount, "tblVoucherDetail_colCurrencyDebetAmount");
            // 
            // tblVoucherDetail_colCurrencyCreditAmount
            // 
            this.tblVoucherDetail_colCurrencyCreditAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVoucherDetail_colCurrencyCreditAmount.MaxLength = 15;
            this.tblVoucherDetail_colCurrencyCreditAmount.Name = "tblVoucherDetail_colCurrencyCreditAmount";
            this.tblVoucherDetail_colCurrencyCreditAmount.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherDetail_colCurrencyCreditAmount.NamedProperties.Put("FieldFlags", "290");
            this.tblVoucherDetail_colCurrencyCreditAmount.NamedProperties.Put("Format", "20");
            this.tblVoucherDetail_colCurrencyCreditAmount.NamedProperties.Put("LovReference", "");
            this.tblVoucherDetail_colCurrencyCreditAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherDetail_colCurrencyCreditAmount.NamedProperties.Put("SqlColumn", "CURRENCY_CREDIT_AMOUNT");
            this.tblVoucherDetail_colCurrencyCreditAmount.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherDetail_colCurrencyCreditAmount.Position = 37;
            this.tblVoucherDetail_colCurrencyCreditAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblVoucherDetail_colCurrencyCreditAmount, "tblVoucherDetail_colCurrencyCreditAmount");
            // 
            // tblVoucherDetail_colCurrencyAmount
            // 
            this.tblVoucherDetail_colCurrencyAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVoucherDetail_colCurrencyAmount.MaxLength = 15;
            this.tblVoucherDetail_colCurrencyAmount.Name = "tblVoucherDetail_colCurrencyAmount";
            this.tblVoucherDetail_colCurrencyAmount.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherDetail_colCurrencyAmount.NamedProperties.Put("FieldFlags", "291");
            this.tblVoucherDetail_colCurrencyAmount.NamedProperties.Put("Format", "20");
            this.tblVoucherDetail_colCurrencyAmount.NamedProperties.Put("LovReference", "");
            this.tblVoucherDetail_colCurrencyAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherDetail_colCurrencyAmount.NamedProperties.Put("SqlColumn", "CURRENCY_AMOUNT");
            this.tblVoucherDetail_colCurrencyAmount.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherDetail_colCurrencyAmount.Position = 38;
            this.tblVoucherDetail_colCurrencyAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblVoucherDetail_colCurrencyAmount, "tblVoucherDetail_colCurrencyAmount");
            // 
            // tblVoucherDetail_colnThirdCurrencyRate
            // 
            this.tblVoucherDetail_colnThirdCurrencyRate.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.tblVoucherDetail_colnThirdCurrencyRate, "tblVoucherDetail_colnThirdCurrencyRate");
            this.tblVoucherDetail_colnThirdCurrencyRate.Name = "tblVoucherDetail_colnThirdCurrencyRate";
            this.tblVoucherDetail_colnThirdCurrencyRate.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherDetail_colnThirdCurrencyRate.NamedProperties.Put("Format", "20");
            this.tblVoucherDetail_colnThirdCurrencyRate.NamedProperties.Put("LovReference", "");
            this.tblVoucherDetail_colnThirdCurrencyRate.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherDetail_colnThirdCurrencyRate.NamedProperties.Put("SqlColumn", "THIRD_CURRENCY_RATE");
            this.tblVoucherDetail_colnThirdCurrencyRate.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherDetail_colnThirdCurrencyRate.Position = 39;
            this.tblVoucherDetail_colnThirdCurrencyRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tblVoucherDetail_colnThirdCurrencyDebitAmount
            // 
            this.tblVoucherDetail_colnThirdCurrencyDebitAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVoucherDetail_colnThirdCurrencyDebitAmount.MaxLength = 15;
            this.tblVoucherDetail_colnThirdCurrencyDebitAmount.Name = "tblVoucherDetail_colnThirdCurrencyDebitAmount";
            this.tblVoucherDetail_colnThirdCurrencyDebitAmount.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherDetail_colnThirdCurrencyDebitAmount.NamedProperties.Put("FieldFlags", "288");
            this.tblVoucherDetail_colnThirdCurrencyDebitAmount.NamedProperties.Put("Format", "20");
            this.tblVoucherDetail_colnThirdCurrencyDebitAmount.NamedProperties.Put("LovReference", "");
            this.tblVoucherDetail_colnThirdCurrencyDebitAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherDetail_colnThirdCurrencyDebitAmount.NamedProperties.Put("SqlColumn", "THIRD_CURRENCY_DEBIT_AMOUNT");
            this.tblVoucherDetail_colnThirdCurrencyDebitAmount.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherDetail_colnThirdCurrencyDebitAmount.Position = 40;
            this.tblVoucherDetail_colnThirdCurrencyDebitAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblVoucherDetail_colnThirdCurrencyDebitAmount, "tblVoucherDetail_colnThirdCurrencyDebitAmount");
            // 
            // tblVoucherDetail_colnThirdCurrencyCreditAmount
            // 
            this.tblVoucherDetail_colnThirdCurrencyCreditAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVoucherDetail_colnThirdCurrencyCreditAmount.MaxLength = 15;
            this.tblVoucherDetail_colnThirdCurrencyCreditAmount.Name = "tblVoucherDetail_colnThirdCurrencyCreditAmount";
            this.tblVoucherDetail_colnThirdCurrencyCreditAmount.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherDetail_colnThirdCurrencyCreditAmount.NamedProperties.Put("FieldFlags", "288");
            this.tblVoucherDetail_colnThirdCurrencyCreditAmount.NamedProperties.Put("Format", "20");
            this.tblVoucherDetail_colnThirdCurrencyCreditAmount.NamedProperties.Put("LovReference", "");
            this.tblVoucherDetail_colnThirdCurrencyCreditAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherDetail_colnThirdCurrencyCreditAmount.NamedProperties.Put("SqlColumn", "THIRD_CURRENCY_CREDIT_AMOUNT");
            this.tblVoucherDetail_colnThirdCurrencyCreditAmount.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherDetail_colnThirdCurrencyCreditAmount.Position = 41;
            this.tblVoucherDetail_colnThirdCurrencyCreditAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblVoucherDetail_colnThirdCurrencyCreditAmount, "tblVoucherDetail_colnThirdCurrencyCreditAmount");
            // 
            // tblVoucherDetail_colnThirdCurrencyAmount
            // 
            this.tblVoucherDetail_colnThirdCurrencyAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVoucherDetail_colnThirdCurrencyAmount.Name = "tblVoucherDetail_colnThirdCurrencyAmount";
            this.tblVoucherDetail_colnThirdCurrencyAmount.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherDetail_colnThirdCurrencyAmount.NamedProperties.Put("FieldFlags", "288");
            this.tblVoucherDetail_colnThirdCurrencyAmount.NamedProperties.Put("Format", "20");
            this.tblVoucherDetail_colnThirdCurrencyAmount.NamedProperties.Put("LovReference", "");
            this.tblVoucherDetail_colnThirdCurrencyAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherDetail_colnThirdCurrencyAmount.NamedProperties.Put("SqlColumn", "NVL(THIRD_CURRENCY_DEBIT_AMOUNT,-THIRD_CURRENCY_CREDIT_AMOUNT)");
            this.tblVoucherDetail_colnThirdCurrencyAmount.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherDetail_colnThirdCurrencyAmount.Position = 42;
            this.tblVoucherDetail_colnThirdCurrencyAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblVoucherDetail_colnThirdCurrencyAmount, "tblVoucherDetail_colnThirdCurrencyAmount");
            // 
            // tblVoucherDetail_colnParallelCurrencyRate
            // 
            this.tblVoucherDetail_colnParallelCurrencyRate.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVoucherDetail_colnParallelCurrencyRate.Name = "tblVoucherDetail_colnParallelCurrencyRate";
            this.tblVoucherDetail_colnParallelCurrencyRate.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherDetail_colnParallelCurrencyRate.NamedProperties.Put("FieldFlags", "294");
            this.tblVoucherDetail_colnParallelCurrencyRate.NamedProperties.Put("Format", "");
            this.tblVoucherDetail_colnParallelCurrencyRate.NamedProperties.Put("LovReference", "");
            this.tblVoucherDetail_colnParallelCurrencyRate.NamedProperties.Put("SqlColumn", "PARALLEL_CURRENCY_RATE");
            this.tblVoucherDetail_colnParallelCurrencyRate.Position = 43;
            this.tblVoucherDetail_colnParallelCurrencyRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblVoucherDetail_colnParallelCurrencyRate, "tblVoucherDetail_colnParallelCurrencyRate");
            // 
            // tblVoucherDetail_colnParallelConversionFactor
            // 
            this.tblVoucherDetail_colnParallelConversionFactor.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVoucherDetail_colnParallelConversionFactor.Name = "tblVoucherDetail_colnParallelConversionFactor";
            this.tblVoucherDetail_colnParallelConversionFactor.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherDetail_colnParallelConversionFactor.NamedProperties.Put("FieldFlags", "294");
            this.tblVoucherDetail_colnParallelConversionFactor.NamedProperties.Put("Format", "");
            this.tblVoucherDetail_colnParallelConversionFactor.NamedProperties.Put("LovReference", "");
            this.tblVoucherDetail_colnParallelConversionFactor.NamedProperties.Put("SqlColumn", "PARALLEL_CONVERSION_FACTOR");
            this.tblVoucherDetail_colnParallelConversionFactor.Position = 44;
            this.tblVoucherDetail_colnParallelConversionFactor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblVoucherDetail_colnParallelConversionFactor, "tblVoucherDetail_colnParallelConversionFactor");
            // 
            // tblVoucherDetail_colText
            // 
            this.tblVoucherDetail_colText.MaxLength = 200;
            this.tblVoucherDetail_colText.Name = "tblVoucherDetail_colText";
            this.tblVoucherDetail_colText.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherDetail_colText.NamedProperties.Put("FieldFlags", "290");
            this.tblVoucherDetail_colText.NamedProperties.Put("LovReference", "");
            this.tblVoucherDetail_colText.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherDetail_colText.NamedProperties.Put("SqlColumn", "TEXT");
            this.tblVoucherDetail_colText.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherDetail_colText.Position = 45;
            resources.ApplyResources(this.tblVoucherDetail_colText, "tblVoucherDetail_colText");
            // 
            // tblVoucherDetail_colQuantity
            // 
            this.tblVoucherDetail_colQuantity.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVoucherDetail_colQuantity.Name = "tblVoucherDetail_colQuantity";
            this.tblVoucherDetail_colQuantity.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherDetail_colQuantity.NamedProperties.Put("FieldFlags", "290");
            this.tblVoucherDetail_colQuantity.NamedProperties.Put("LovReference", "");
            this.tblVoucherDetail_colQuantity.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherDetail_colQuantity.NamedProperties.Put("SqlColumn", "QUANTITY");
            this.tblVoucherDetail_colQuantity.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherDetail_colQuantity.Position = 46;
            resources.ApplyResources(this.tblVoucherDetail_colQuantity, "tblVoucherDetail_colQuantity");
            // 
            // tblVoucherDetail_colProcessCode
            // 
            this.tblVoucherDetail_colProcessCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblVoucherDetail_colProcessCode.MaxLength = 10;
            this.tblVoucherDetail_colProcessCode.Name = "tblVoucherDetail_colProcessCode";
            this.tblVoucherDetail_colProcessCode.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherDetail_colProcessCode.NamedProperties.Put("FieldFlags", "290");
            this.tblVoucherDetail_colProcessCode.NamedProperties.Put("LovReference", "ACCOUNT_PROCESS_CODE(COMPANY)");
            this.tblVoucherDetail_colProcessCode.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherDetail_colProcessCode.NamedProperties.Put("SqlColumn", "PROCESS_CODE");
            this.tblVoucherDetail_colProcessCode.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherDetail_colProcessCode.Position = 47;
            resources.ApplyResources(this.tblVoucherDetail_colProcessCode, "tblVoucherDetail_colProcessCode");
            // 
            // tblVoucherDetail_colsDeliveryTypeId
            // 
            this.tblVoucherDetail_colsDeliveryTypeId.MaxLength = 20;
            this.tblVoucherDetail_colsDeliveryTypeId.Name = "tblVoucherDetail_colsDeliveryTypeId";
            this.tblVoucherDetail_colsDeliveryTypeId.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherDetail_colsDeliveryTypeId.NamedProperties.Put("FieldFlags", "290");
            this.tblVoucherDetail_colsDeliveryTypeId.NamedProperties.Put("LovReference", "DELIVERY_TYPE(COMPANY)");
            this.tblVoucherDetail_colsDeliveryTypeId.NamedProperties.Put("SqlColumn", "DELIV_TYPE_ID");
            this.tblVoucherDetail_colsDeliveryTypeId.Position = 48;
            resources.ApplyResources(this.tblVoucherDetail_colsDeliveryTypeId, "tblVoucherDetail_colsDeliveryTypeId");
            // 
            // tblVoucherDetail_colsDeliveryTypeDescription
            // 
            this.tblVoucherDetail_colsDeliveryTypeDescription.MaxLength = 2000;
            this.tblVoucherDetail_colsDeliveryTypeDescription.Name = "tblVoucherDetail_colsDeliveryTypeDescription";
            this.tblVoucherDetail_colsDeliveryTypeDescription.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherDetail_colsDeliveryTypeDescription.NamedProperties.Put("FieldFlags", "288");
            this.tblVoucherDetail_colsDeliveryTypeDescription.NamedProperties.Put("LovReference", "");
            this.tblVoucherDetail_colsDeliveryTypeDescription.NamedProperties.Put("ParentName", "tblVoucherDetail.tblVoucherDetail_colsDeliveryTypeId");
            this.tblVoucherDetail_colsDeliveryTypeDescription.NamedProperties.Put("SqlColumn", "Voucher_Row_API.Get_Delivery_Type_Description(COMPANY,DELIV_TYPE_ID)");
            this.tblVoucherDetail_colsDeliveryTypeDescription.Position = 49;
            resources.ApplyResources(this.tblVoucherDetail_colsDeliveryTypeDescription, "tblVoucherDetail_colsDeliveryTypeDescription");
            // 
            // tblVoucherDetail_colOptionalCode
            // 
            this.tblVoucherDetail_colOptionalCode.MaxLength = 20;
            this.tblVoucherDetail_colOptionalCode.Name = "tblVoucherDetail_colOptionalCode";
            this.tblVoucherDetail_colOptionalCode.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherDetail_colOptionalCode.NamedProperties.Put("FieldFlags", "290");
            this.tblVoucherDetail_colOptionalCode.NamedProperties.Put("LovReference", "");
            this.tblVoucherDetail_colOptionalCode.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherDetail_colOptionalCode.NamedProperties.Put("SqlColumn", "OPTIONAL_CODE");
            this.tblVoucherDetail_colOptionalCode.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherDetail_colOptionalCode.Position = 50;
            resources.ApplyResources(this.tblVoucherDetail_colOptionalCode, "tblVoucherDetail_colOptionalCode");
            // 
            // tblVoucherDetail_colProjActivityId
            // 
            this.tblVoucherDetail_colProjActivityId.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVoucherDetail_colProjActivityId.Name = "tblVoucherDetail_colProjActivityId";
            this.tblVoucherDetail_colProjActivityId.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherDetail_colProjActivityId.NamedProperties.Put("FieldFlags", "290");
            this.tblVoucherDetail_colProjActivityId.NamedProperties.Put("LovReference", "");
            this.tblVoucherDetail_colProjActivityId.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherDetail_colProjActivityId.NamedProperties.Put("SqlColumn", "PROJECT_ACTIVITY_ID");
            this.tblVoucherDetail_colProjActivityId.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherDetail_colProjActivityId.Position = 51;
            resources.ApplyResources(this.tblVoucherDetail_colProjActivityId, "tblVoucherDetail_colProjActivityId");
            // 
            // tblVoucherDetail_colPartyTypeId
            // 
            this.tblVoucherDetail_colPartyTypeId.MaxLength = 20;
            this.tblVoucherDetail_colPartyTypeId.Name = "tblVoucherDetail_colPartyTypeId";
            this.tblVoucherDetail_colPartyTypeId.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherDetail_colPartyTypeId.NamedProperties.Put("FieldFlags", "290");
            this.tblVoucherDetail_colPartyTypeId.NamedProperties.Put("LovReference", "");
            this.tblVoucherDetail_colPartyTypeId.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherDetail_colPartyTypeId.NamedProperties.Put("SqlColumn", "PARTY_TYPE_ID");
            this.tblVoucherDetail_colPartyTypeId.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherDetail_colPartyTypeId.Position = 52;
            resources.ApplyResources(this.tblVoucherDetail_colPartyTypeId, "tblVoucherDetail_colPartyTypeId");
            // 
            // tblVoucherDetail_colTransCode
            // 
            this.tblVoucherDetail_colTransCode.Name = "tblVoucherDetail_colTransCode";
            this.tblVoucherDetail_colTransCode.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherDetail_colTransCode.NamedProperties.Put("FieldFlags", "290");
            this.tblVoucherDetail_colTransCode.NamedProperties.Put("LovReference", "");
            this.tblVoucherDetail_colTransCode.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherDetail_colTransCode.NamedProperties.Put("SqlColumn", "TRANS_CODE");
            this.tblVoucherDetail_colTransCode.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherDetail_colTransCode.Position = 53;
            resources.ApplyResources(this.tblVoucherDetail_colTransCode, "tblVoucherDetail_colTransCode");
            // 
            // tblVoucherDetail_colTransferId
            // 
            resources.ApplyResources(this.tblVoucherDetail_colTransferId, "tblVoucherDetail_colTransferId");
            this.tblVoucherDetail_colTransferId.MaxLength = 20;
            this.tblVoucherDetail_colTransferId.Name = "tblVoucherDetail_colTransferId";
            this.tblVoucherDetail_colTransferId.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherDetail_colTransferId.NamedProperties.Put("FieldFlags", "258");
            this.tblVoucherDetail_colTransferId.NamedProperties.Put("LovReference", "");
            this.tblVoucherDetail_colTransferId.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherDetail_colTransferId.NamedProperties.Put("SqlColumn", "TRANSFER_ID");
            this.tblVoucherDetail_colTransferId.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherDetail_colTransferId.Position = 54;
            // 
            // tblVoucherDetail_colUpdateError
            // 
            this.tblVoucherDetail_colUpdateError.Name = "tblVoucherDetail_colUpdateError";
            this.tblVoucherDetail_colUpdateError.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherDetail_colUpdateError.NamedProperties.Put("FieldFlags", "288");
            this.tblVoucherDetail_colUpdateError.NamedProperties.Put("LovReference", "");
            this.tblVoucherDetail_colUpdateError.NamedProperties.Put("SqlColumn", "UPDATE_ERROR");
            this.tblVoucherDetail_colUpdateError.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherDetail_colUpdateError.Position = 55;
            resources.ApplyResources(this.tblVoucherDetail_colUpdateError, "tblVoucherDetail_colUpdateError");
            // 
            // tblVoucherDetail_colCorrected
            // 
            this.tblVoucherDetail_colCorrected.MaxLength = 20;
            this.tblVoucherDetail_colCorrected.Name = "tblVoucherDetail_colCorrected";
            this.tblVoucherDetail_colCorrected.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherDetail_colCorrected.NamedProperties.Put("FieldFlags", "290");
            this.tblVoucherDetail_colCorrected.NamedProperties.Put("LovReference", "");
            this.tblVoucherDetail_colCorrected.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherDetail_colCorrected.NamedProperties.Put("SqlColumn", "CORRECTED");
            this.tblVoucherDetail_colCorrected.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherDetail_colCorrected.Position = 56;
            resources.ApplyResources(this.tblVoucherDetail_colCorrected, "tblVoucherDetail_colCorrected");
            // 
            // tblVoucherDetail_colPeriodical_Allocation
            // 
            this.tblVoucherDetail_colPeriodical_Allocation.MaxLength = 1;
            this.tblVoucherDetail_colPeriodical_Allocation.Name = "tblVoucherDetail_colPeriodical_Allocation";
            this.tblVoucherDetail_colPeriodical_Allocation.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherDetail_colPeriodical_Allocation.NamedProperties.Put("FieldFlags", "288");
            this.tblVoucherDetail_colPeriodical_Allocation.NamedProperties.Put("LovReference", "");
            this.tblVoucherDetail_colPeriodical_Allocation.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherDetail_colPeriodical_Allocation.NamedProperties.Put("SqlColumn", "PERIOD_ALLOCATION_API.ANY_ALLOCATION(COMPANY, VOUCHER_TYPE, VOUCHER_NO, ROW_NO, A" +
        "CCOUNTING_YEAR)");
            this.tblVoucherDetail_colPeriodical_Allocation.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherDetail_colPeriodical_Allocation.Position = 57;
            resources.ApplyResources(this.tblVoucherDetail_colPeriodical_Allocation, "tblVoucherDetail_colPeriodical_Allocation");
            // 
            // tblVoucherDetail_colReferenceSerie
            // 
            this.tblVoucherDetail_colReferenceSerie.MaxLength = 50;
            this.tblVoucherDetail_colReferenceSerie.Name = "tblVoucherDetail_colReferenceSerie";
            this.tblVoucherDetail_colReferenceSerie.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherDetail_colReferenceSerie.NamedProperties.Put("FieldFlags", "290");
            this.tblVoucherDetail_colReferenceSerie.NamedProperties.Put("LovReference", "");
            this.tblVoucherDetail_colReferenceSerie.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherDetail_colReferenceSerie.NamedProperties.Put("SqlColumn", "REFERENCE_SERIE");
            this.tblVoucherDetail_colReferenceSerie.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherDetail_colReferenceSerie.Position = 58;
            resources.ApplyResources(this.tblVoucherDetail_colReferenceSerie, "tblVoucherDetail_colReferenceSerie");
            // 
            // tblVoucherDetail_colReferenceNumber
            // 
            this.tblVoucherDetail_colReferenceNumber.MaxLength = 50;
            this.tblVoucherDetail_colReferenceNumber.Name = "tblVoucherDetail_colReferenceNumber";
            this.tblVoucherDetail_colReferenceNumber.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherDetail_colReferenceNumber.NamedProperties.Put("FieldFlags", "290");
            this.tblVoucherDetail_colReferenceNumber.NamedProperties.Put("LovReference", "");
            this.tblVoucherDetail_colReferenceNumber.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherDetail_colReferenceNumber.NamedProperties.Put("SqlColumn", "REFERENCE_NUMBER");
            this.tblVoucherDetail_colReferenceNumber.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherDetail_colReferenceNumber.Position = 59;
            resources.ApplyResources(this.tblVoucherDetail_colReferenceNumber, "tblVoucherDetail_colReferenceNumber");
            // 
            // tblVoucherDetail_colAutoTaxVouEntry
            // 
            this.tblVoucherDetail_colAutoTaxVouEntry.MaxLength = 20;
            this.tblVoucherDetail_colAutoTaxVouEntry.Name = "tblVoucherDetail_colAutoTaxVouEntry";
            this.tblVoucherDetail_colAutoTaxVouEntry.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherDetail_colAutoTaxVouEntry.NamedProperties.Put("FieldFlags", "288");
            this.tblVoucherDetail_colAutoTaxVouEntry.NamedProperties.Put("LovReference", "");
            this.tblVoucherDetail_colAutoTaxVouEntry.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherDetail_colAutoTaxVouEntry.NamedProperties.Put("SqlColumn", "AUTO_TAX_VOU_ENTRY");
            this.tblVoucherDetail_colAutoTaxVouEntry.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherDetail_colAutoTaxVouEntry.Position = 60;
            resources.ApplyResources(this.tblVoucherDetail_colAutoTaxVouEntry, "tblVoucherDetail_colAutoTaxVouEntry");
            // 
            // tblVoucherDetail_colnRowGroupId
            // 
            this.tblVoucherDetail_colnRowGroupId.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVoucherDetail_colnRowGroupId.Name = "tblVoucherDetail_colnRowGroupId";
            this.tblVoucherDetail_colnRowGroupId.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherDetail_colnRowGroupId.NamedProperties.Put("FieldFlags", "294");
            this.tblVoucherDetail_colnRowGroupId.NamedProperties.Put("LovReference", "");
            this.tblVoucherDetail_colnRowGroupId.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherDetail_colnRowGroupId.NamedProperties.Put("SqlColumn", "ROW_GROUP_ID");
            this.tblVoucherDetail_colnRowGroupId.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherDetail_colnRowGroupId.Position = 61;
            resources.ApplyResources(this.tblVoucherDetail_colnRowGroupId, "tblVoucherDetail_colnRowGroupId");
            // 
            // frmQueryVoucherDetail
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.dfFunctionGroup);
            this.Controls.Add(this.dfMCId);
            this.Controls.Add(this.dfRefCompany);
            this.Controls.Add(this.tblVoucherDetail);
            this.Controls.Add(this.dfsApprovedByUserGroup);
            this.Controls.Add(this.dfsApprovedByUserid);
            this.Controls.Add(this.dfdApprovalDate);
            this.Controls.Add(this.dfsVoucherText2);
            this.Controls.Add(this.dfCodePartDescription);
            this.Controls.Add(this.dfCodePartValue);
            this.Controls.Add(this.dfMultiCompanyId);
            this.Controls.Add(this.cbMultiCompanyId);
            this.Controls.Add(this.dfUpdateError);
            this.Controls.Add(this.dfUserGroup);
            this.Controls.Add(this.dfUserid);
            this.Controls.Add(this.dfAccountingYearReference);
            this.Controls.Add(this.dfVoucherNoReference);
            this.Controls.Add(this.dfVoucherTypeReference);
            this.Controls.Add(this.dfAccountingPeriod);
            this.Controls.Add(this.dfAccountingYear);
            this.Controls.Add(this.cbNotes);
            this.Controls.Add(this.dfDateReg);
            this.Controls.Add(this.dfVoucherStatus);
            this.Controls.Add(this.dfVoucherDate);
            this.Controls.Add(this.dfVoucherNo);
            this.Controls.Add(this.ccVoucherType);
            this.Controls.Add(this.dfVoucherType);
            this.Controls.Add(this.dfCompany);
            this.Controls.Add(this.labeldfFunctionGroup);
            this.Controls.Add(this.labeldfMCId);
            this.Controls.Add(this.labeldfsApprovedByUserGroup);
            this.Controls.Add(this.labeldfsApprovedByUserid);
            this.Controls.Add(this.labeldfdApprovalDate);
            this.Controls.Add(this.labeldfsVoucherText2);
            this.Controls.Add(this.labeldfCodePartDescription);
            this.Controls.Add(this.labeldfCodePartValue);
            this.Controls.Add(this.labeldfMultiCompanyId);
            this.Controls.Add(this.labeldfUpdateError);
            this.Controls.Add(this.labeldfUserGroup);
            this.Controls.Add(this.labeldfUserid);
            this.Controls.Add(this.labeldfAccountingYearReference);
            this.Controls.Add(this.labeldfVoucherNoReference);
            this.Controls.Add(this.labeldfVoucherTypeReference);
            this.Controls.Add(this.labeldfAccountingPeriod);
            this.Controls.Add(this.labeldfAccountingYear);
            this.Controls.Add(this.labeldfDateReg);
            this.Controls.Add(this.labeldfVoucherStatus);
            this.Controls.Add(this.labeldfVoucherDate);
            this.Controls.Add(this.labeldfVoucherNo);
            this.Controls.Add(this.labelccVoucherType);
            this.Controls.Add(this.labeldfCompany);
            this.Controls.Add(this.gbVoucher_Approval_By_User);
            this.Controls.Add(this.gbVoucher_Entry_By_User);
            this.Controls.Add(this.gbVoucher_Reference);
            this.Controls.Add(this.gbAccounting_Period);
            this.MaximizeBox = true;
            this.Name = "frmQueryVoucherDetail";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "COMPANY = :global.company  AND\r\nVOUCHER_UPDATED_DB=\'N\'");
            this.NamedProperties.Put("LogicalUnit", "Voucher");
            this.NamedProperties.Put("PackageName", "VOUCHER_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "0");
            this.NamedProperties.Put("SourceFlags", "1");
            this.NamedProperties.Put("ViewName", "VOUCHER");
            this.NamedProperties.Put("Warning", "TRUE");
            this.NamedProperties.Put("Warnings", "TRUE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.frmQueryVoucherDetail_WindowActions);
            this.menuFrmMethods.ResumeLayout(false);
            this.menuOperations.ResumeLayout(false);
            this.menuTblMethods.ResumeLayout(false);
            this.tblVoucherDetail.ResumeLayout(false);
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
		
        public Fnd.Windows.Forms.FndCommand menuTblMethods_menu_Notes___;
        public Fnd.Windows.Forms.FndCommand menuTblMethods_menuView__Multi_Company_Voucher___;
        public Fnd.Windows.Forms.FndCommand menuTblMethods_menuChange__Company___;
        public Fnd.Windows.Forms.FndCommand menuOperations_menu_Notes___;
        public Fnd.Windows.Forms.FndCommand menuOperations_menuView__Multi_Company_Voucher___;
        public Fnd.Windows.Forms.FndCommand menuOperations_menuChange__Company___;
        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menu_Notes___;
        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menuView__Multi_Company_Voucher___;
        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menuChange__Company___;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuFrmMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Notes;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_View;
        protected Fnd.Windows.Forms.FndToolStripSeparator menuSeparator1;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuOperations;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Notes_1;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_View_1;
        protected Fnd.Windows.Forms.FndToolStripSeparator menuSeparator2;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change_1;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTblMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Notes_2;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_View_2;
        protected Fnd.Windows.Forms.FndToolStripSeparator menuSeparator3;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change_2;
        public cChildTableFin tblVoucherDetail;
        protected cColumn tblVoucherDetail_colCompany;
        protected cColumn tblVoucherDetail_colAccountingYear;
        protected cColumn tblVoucherDetail_colVoucherType;
        protected cColumn tblVoucherDetail_colVoucherNo;
        protected cColumn tblVoucherDetail_colRowNo;
        protected cColumnCodePartFin tblVoucherDetail_colAccount;
        protected cColumnCodePartDescFin tblVoucherDetail_colsAccountDesc;
        protected cColumnCodePartFin tblVoucherDetail_colCodeB;
        protected cColumnCodePartDescFin tblVoucherDetail_colsCodeBDesc;
        protected cColumnCodePartFin tblVoucherDetail_colCodeC;
        protected cColumnCodePartDescFin tblVoucherDetail_colsCodeCDesc;
        protected cColumnCodePartFin tblVoucherDetail_colCodeD;
        protected cColumnCodePartDescFin tblVoucherDetail_colsCodeDDesc;
        protected cColumnCodePartFin tblVoucherDetail_colCodeE;
        protected cColumnCodePartDescFin tblVoucherDetail_colsCodeEDesc;
        protected cColumnCodePartFin tblVoucherDetail_colCodeF;
        protected cColumnCodePartDescFin tblVoucherDetail_colsCodeFDesc;
        protected cColumnCodePartFin tblVoucherDetail_colCodeG;
        protected cColumnCodePartDescFin tblVoucherDetail_colsCodeGDesc;
        protected cColumnCodePartFin tblVoucherDetail_colCodeH;
        protected cColumnCodePartDescFin tblVoucherDetail_colsCodeHDesc;
        protected cColumnCodePartFin tblVoucherDetail_colCodeI;
        protected cColumnCodePartDescFin tblVoucherDetail_colsCodeIDesc;
        protected cColumnCodePartFin tblVoucherDetail_colCodeJ;
        protected cColumnCodePartDescFin tblVoucherDetail_colsCodeJDesc;
        protected cCheckBoxColumn tblVoucherDetail_colMultiCompanyId;
        protected cColumn tblVoucherDetail_colCorrection;
        protected cColumn tblVoucherDetail_colCurrencyCode;
        protected cColumn tblVoucherDetail_colCurrencyRate;
        protected cColumn tblVoucherDetail_colConversionFactor;
        protected cColumn tblVoucherDetail_colDebetAmount;
        protected cColumn tblVoucherDetail_colCreditAmount;
        protected cColumn tblVoucherDetail_colAmount;
        protected cColumn tblVoucherDetail_colCurrencyDebetAmount;
        protected cColumn tblVoucherDetail_colCurrencyCreditAmount;
        protected cColumn tblVoucherDetail_colCurrencyAmount;
        protected cColumnFinEuro tblVoucherDetail_colnThirdCurrencyRate;
        protected cColumnFinEuro tblVoucherDetail_colnThirdCurrencyDebitAmount;
        protected cColumnFinEuro tblVoucherDetail_colnThirdCurrencyCreditAmount;
        protected cColumnFinEuro tblVoucherDetail_colnThirdCurrencyAmount;
        protected cColumn tblVoucherDetail_colnParallelCurrencyRate;
        protected cColumn tblVoucherDetail_colnParallelConversionFactor;
        protected cColumn tblVoucherDetail_colText;
        protected cColumn tblVoucherDetail_colQuantity;
        protected cColumn tblVoucherDetail_colProcessCode;
        protected cColumn tblVoucherDetail_colOptionalCode;
        protected cColumn tblVoucherDetail_colProjActivityId;
        protected cColumn tblVoucherDetail_colPartyTypeId;
        protected cColumn tblVoucherDetail_colTransCode;
        protected cColumn tblVoucherDetail_colTransferId;
        protected cColumn tblVoucherDetail_colUpdateError;
        protected cColumn tblVoucherDetail_colCorrected;
        protected cColumn tblVoucherDetail_colPeriodical_Allocation;
        protected cColumn tblVoucherDetail_colReferenceSerie;
        protected cColumn tblVoucherDetail_colReferenceNumber;
        protected cCheckBoxColumn tblVoucherDetail_colAutoTaxVouEntry;
        protected cColumn tblVoucherDetail_colnRowGroupId;
        protected cColumn tblVoucherDetail_colsDeliveryTypeId;
        protected cColumn tblVoucherDetail_colsDeliveryTypeDescription;
	}
}
