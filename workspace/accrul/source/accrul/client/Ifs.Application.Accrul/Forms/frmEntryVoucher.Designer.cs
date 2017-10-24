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
	
	public partial class frmEntryVoucher
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
		protected cBackgroundText labelcmbsVoucherStatus;
		// Bug 77430, Begin, increased the length
		public cComboBox cmbsVoucherStatus;
		// Bug 77430, End
		protected cBackgroundText labeldfnAccountingYear;
		public cDataField dfnAccountingYear;
		protected cBackgroundText labeldfnAccountingPeriod;
		public cDataField dfnAccountingPeriod;
		public cDataField dfsPeriodDescription;
		protected cBackgroundText labelcmbsAmountMethod;
		public cComboBox cmbsAmountMethod;
		// Bug 77430, Begin, changed F1 property Column Name
		// Bug 77430, Begin
		public cCheckBox cbFreeText;
		// Bug 77430, End
		public cCheckBox cbCorrection;
		// Don't change value if column is not enabled
		public cCheckBox cbUseCorrectionRows;
		protected cBackgroundText labeldfsTextId;
		public cDataField dfsTextId;
		protected cBackgroundText labeldfsRowText;
		public cDataField dfsRowText;
		protected SalGroupBox gbVoucher_Status_Information;
		protected cBackgroundText labeldfdDateReg;
		public cDataField dfdDateReg;
		protected cBackgroundText labeldfsUserId;
		public cDataField dfsUserId;
		protected cBackgroundText labeldfsEnteredByUserGroup;
		public cDataField dfsEnteredByUserGroup;
		protected cBackgroundText labeldfdApprovalDate;
		public cDataField dfdApprovalDate;
		protected cBackgroundText labeldfsApprovedByUserid;
		public cDataField dfsApprovedByUserid;
		protected cBackgroundText labeldfsApprovedByUserGroup;
		public cDataField dfsApprovedByUserGroup;
		protected SalGroupBox gbAdditional_Infomation;
		protected cBackgroundText labeldfsUpdateError;
		public cDataField dfsUpdateError;
		public cCheckBox cbInterimVoucher;
		// ----- Hiden fields
		public cDataField dfsVoucherGroup;
		// Bug 77430, Removed Background Text and dfsVoucherText
		public cDataField dfStatus;
		public cCheckBox cbAutomatic;
		protected cBackgroundText labeldfsCurrencyType;
		public cDataField dfsCurrencyType;
		protected cBackgroundText labeldfsCurrencyCode;
		public cDataField dfsCurrencyCode;
		public cDataField dfnCurrencyRate;
		public cDataField dfnConversionFactor;
		protected cBackgroundText labeldfnCurrencyBalance;
		public cDataField dfnCurrencyBalance;
		protected cBackgroundText labeldfnBalance;
		public cDataField dfnBalance;
		public cDataField dfsRevCostClearVoucher;
		public cDataField dfsRowGroupValidation;
		public cDataField dfsReferenceMandatory;
		// Bug 80830, Begin - Changed the length in F1 properties to (200) and data type to String.
		// Bug 69891, Begin
		public cDataField dfsTransferId;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEntryVoucher));
            this.menuFrmMethods_menu_Notes___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuFrmMethods_menuCopy__Voucher_in_Hold_Table___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuFrmMethods_menuCopy__GL_Voucher_Rows___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuFrmMethods_menu_Interim_Voucher___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuFrmMethods_menu_Use_Voucher_Template___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuFrmMethods_menuCreate_Voucher__Template___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuFrmMethods_menuInstant_Update_General__Ledger__ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
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
            this.labelcmbsVoucherStatus = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbsVoucherStatus = new Ifs.Fnd.ApplicationForms.cComboBox();
            this.labeldfnAccountingYear = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfnAccountingYear = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfnAccountingPeriod = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfnAccountingPeriod = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsPeriodDescription = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelcmbsAmountMethod = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbsAmountMethod = new Ifs.Fnd.ApplicationForms.cComboBox();
            this.cbFreeText = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.cbCorrection = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.cbUseCorrectionRows = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.labeldfsTextId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsTextId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsRowText = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsRowText = new Ifs.Fnd.ApplicationForms.cDataField();
            this.gbVoucher_Status_Information = new PPJ.Runtime.Windows.SalGroupBox();
            this.labeldfdDateReg = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfdDateReg = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsUserId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsUserId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsEnteredByUserGroup = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsEnteredByUserGroup = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfdApprovalDate = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfdApprovalDate = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsApprovedByUserid = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsApprovedByUserid = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsApprovedByUserGroup = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsApprovedByUserGroup = new Ifs.Fnd.ApplicationForms.cDataField();
            this.gbAdditional_Infomation = new PPJ.Runtime.Windows.SalGroupBox();
            this.labeldfsUpdateError = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsUpdateError = new Ifs.Fnd.ApplicationForms.cDataField();
            this.cbInterimVoucher = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.dfsVoucherGroup = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfStatus = new Ifs.Fnd.ApplicationForms.cDataField();
            this.cbAutomatic = new Ifs.Fnd.ApplicationForms.cCheckBox();
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
            this.dfsRevCostClearVoucher = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsRowGroupValidation = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsReferenceMandatory = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsTransferId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.menuFrmMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem__Notes = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem_Copy = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem_Copy_1 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem__Interim = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem__Use = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem_Create = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem_Instant = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem_Change = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuSeparator1 = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.menuFrmMethods_menuAdd_Investment = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem__AddInvestment = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.labeldfnParallelCurrencyBalance = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfnParallelCurrencyBalance = new Ifs.Fnd.ApplicationForms.cDataField();
            this.cGroupBoxVoucherReferenceDetails = new Ifs.Fnd.ApplicationForms.cGroupBox();
            this.dfsVoucherTypeReference = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelVoucherTypeReference = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfnVoucherNoReference = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelVoucherNoReference = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsReferenceCompany = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfnAccountingYearReference = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelAccountingYearReference = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfnVoucherNoReference1 = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelVoucherNoReference1 = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsVoucherTypeReference1 = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelVoucherTypeReference1 = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.menuFrmMethods.SuspendLayout();
            this.cGroupBoxVoucherReferenceDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // _cTabManager
            // 
            resources.ApplyResources(this._cTabManager, "_cTabManager");
            // 
            // picTab
            // 
            resources.ApplyResources(this.picTab, "picTab");
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuFrmMethods_menu_Notes___);
            this.commandManager.Commands.Add(this.menuFrmMethods_menuCopy__Voucher_in_Hold_Table___);
            this.commandManager.Commands.Add(this.menuFrmMethods_menuCopy__GL_Voucher_Rows___);
            this.commandManager.Commands.Add(this.menuFrmMethods_menu_Interim_Voucher___);
            this.commandManager.Commands.Add(this.menuFrmMethods_menu_Use_Voucher_Template___);
            this.commandManager.Commands.Add(this.menuFrmMethods_menuCreate_Voucher__Template___);
            this.commandManager.Commands.Add(this.menuFrmMethods_menuInstant_Update_General__Ledger__);
            this.commandManager.Commands.Add(this.menuFrmMethods_menuChange__Company___);
            this.commandManager.Commands.Add(this.menuItem__AddInvestment);
            this.commandManager.ContextMenus.Add(this.menuFrmMethods);
            this.commandManager.ImageList = null;
            // 
            // menuFrmMethods_menu_Notes___
            // 
            resources.ApplyResources(this.menuFrmMethods_menu_Notes___, "menuFrmMethods_menu_Notes___");
            this.menuFrmMethods_menu_Notes___.Name = "menuFrmMethods_menu_Notes___";
            this.menuFrmMethods_menu_Notes___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Notes_Execute);
            this.menuFrmMethods_menu_Notes___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Notes_Inquire);
            // 
            // menuFrmMethods_menuCopy__Voucher_in_Hold_Table___
            // 
            resources.ApplyResources(this.menuFrmMethods_menuCopy__Voucher_in_Hold_Table___, "menuFrmMethods_menuCopy__Voucher_in_Hold_Table___");
            this.menuFrmMethods_menuCopy__Voucher_in_Hold_Table___.Name = "menuFrmMethods_menuCopy__Voucher_in_Hold_Table___";
            this.menuFrmMethods_menuCopy__Voucher_in_Hold_Table___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Copy_Execute);
            this.menuFrmMethods_menuCopy__Voucher_in_Hold_Table___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Copy_Inquire);
            // 
            // menuFrmMethods_menuCopy__GL_Voucher_Rows___
            // 
            resources.ApplyResources(this.menuFrmMethods_menuCopy__GL_Voucher_Rows___, "menuFrmMethods_menuCopy__GL_Voucher_Rows___");
            this.menuFrmMethods_menuCopy__GL_Voucher_Rows___.Name = "menuFrmMethods_menuCopy__GL_Voucher_Rows___";
            this.menuFrmMethods_menuCopy__GL_Voucher_Rows___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Copy_1_Execute);
            this.menuFrmMethods_menuCopy__GL_Voucher_Rows___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Copy_1_Inquire);
            // 
            // menuFrmMethods_menu_Interim_Voucher___
            // 
            resources.ApplyResources(this.menuFrmMethods_menu_Interim_Voucher___, "menuFrmMethods_menu_Interim_Voucher___");
            this.menuFrmMethods_menu_Interim_Voucher___.Name = "menuFrmMethods_menu_Interim_Voucher___";
            this.menuFrmMethods_menu_Interim_Voucher___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Interim_Execute);
            this.menuFrmMethods_menu_Interim_Voucher___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Interim_Inquire);
            // 
            // menuFrmMethods_menu_Use_Voucher_Template___
            // 
            resources.ApplyResources(this.menuFrmMethods_menu_Use_Voucher_Template___, "menuFrmMethods_menu_Use_Voucher_Template___");
            this.menuFrmMethods_menu_Use_Voucher_Template___.Name = "menuFrmMethods_menu_Use_Voucher_Template___";
            this.menuFrmMethods_menu_Use_Voucher_Template___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Use_Execute);
            this.menuFrmMethods_menu_Use_Voucher_Template___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Use_Inquire);
            // 
            // menuFrmMethods_menuCreate_Voucher__Template___
            // 
            resources.ApplyResources(this.menuFrmMethods_menuCreate_Voucher__Template___, "menuFrmMethods_menuCreate_Voucher__Template___");
            this.menuFrmMethods_menuCreate_Voucher__Template___.Name = "menuFrmMethods_menuCreate_Voucher__Template___";
            this.menuFrmMethods_menuCreate_Voucher__Template___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Create_Execute);
            this.menuFrmMethods_menuCreate_Voucher__Template___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Create_Inquire);
            // 
            // menuFrmMethods_menuInstant_Update_General__Ledger__
            // 
            resources.ApplyResources(this.menuFrmMethods_menuInstant_Update_General__Ledger__, "menuFrmMethods_menuInstant_Update_General__Ledger__");
            this.menuFrmMethods_menuInstant_Update_General__Ledger__.Name = "menuFrmMethods_menuInstant_Update_General__Ledger__";
            this.menuFrmMethods_menuInstant_Update_General__Ledger__.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Instant_Execute);
            this.menuFrmMethods_menuInstant_Update_General__Ledger__.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Instant_Inquire);
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
            this.dfsUserGroup.NamedProperties.Put("FieldFlags", "294");
            this.dfsUserGroup.NamedProperties.Put("LovReference", "USER_GROUP_MEMBER_FINANCE4(:global.company,FNDUSER)");
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
            this.ccsVoucherType.NamedProperties.Put("LovReference", "VOUCHER_TYPE_USER_GROUP3(:global.company,ACCOUNTING_YEAR,USER_GROUP)");
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
            this.dfnVoucherNo.NamedProperties.Put("FieldFlags", "98");
            this.dfnVoucherNo.NamedProperties.Put("LovReference", "");
            this.dfnVoucherNo.NamedProperties.Put("ParentName", "ccsVoucherType");
            this.dfnVoucherNo.NamedProperties.Put("ResizeableChildObject", "");
            this.dfnVoucherNo.NamedProperties.Put("SqlColumn", "VOUCHER_NO");
            this.dfnVoucherNo.NamedProperties.Put("ValidateMethod", "");
            this.dfnVoucherNo.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfnVoucherNo_WindowActions);
            // 
            // labelcmbsVoucherStatus
            // 
            resources.ApplyResources(this.labelcmbsVoucherStatus, "labelcmbsVoucherStatus");
            this.labelcmbsVoucherStatus.Name = "labelcmbsVoucherStatus";
            // 
            // cmbsVoucherStatus
            // 
            resources.ApplyResources(this.cmbsVoucherStatus, "cmbsVoucherStatus");
            this.cmbsVoucherStatus.Name = "cmbsVoucherStatus";
            this.cmbsVoucherStatus.NamedProperties.Put("EnumerateMethod", "Voucher_Status_API.Enumerate");
            this.cmbsVoucherStatus.NamedProperties.Put("FieldFlags", "295");
            this.cmbsVoucherStatus.NamedProperties.Put("LovReference", "");
            this.cmbsVoucherStatus.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbsVoucherStatus.NamedProperties.Put("SqlColumn", "VOUCHER_STATUS");
            this.cmbsVoucherStatus.NamedProperties.Put("ValidateMethod", "");
            this.cmbsVoucherStatus.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbsVoucherStatus_WindowActions);
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
            this.dfnAccountingYear.NamedProperties.Put("FieldFlags", "99");
            this.dfnAccountingYear.NamedProperties.Put("LovReference", "ACCOUNTING_YEAR(:global.company)");
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
            this.dfnAccountingPeriod.NamedProperties.Put("FieldFlags", "290");
            this.dfnAccountingPeriod.NamedProperties.Put("LovReference", "ACCOUNTING_YEAR_PERIOD(:global.company, ACCOUNTING_YEAR)");
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
            // labelcmbsAmountMethod
            // 
            resources.ApplyResources(this.labelcmbsAmountMethod, "labelcmbsAmountMethod");
            this.labelcmbsAmountMethod.Name = "labelcmbsAmountMethod";
            // 
            // cmbsAmountMethod
            // 
            resources.ApplyResources(this.cmbsAmountMethod, "cmbsAmountMethod");
            this.cmbsAmountMethod.Name = "cmbsAmountMethod";
            this.cmbsAmountMethod.NamedProperties.Put("EnumerateMethod", "DEF_AMOUNT_METHOD_API.Enumerate");
            this.cmbsAmountMethod.NamedProperties.Put("FieldFlags", "295");
            this.cmbsAmountMethod.NamedProperties.Put("LovReference", "");
            this.cmbsAmountMethod.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbsAmountMethod.NamedProperties.Put("SqlColumn", "AMOUNT_METHOD");
            this.cmbsAmountMethod.NamedProperties.Put("ValidateMethod", "");
            this.cmbsAmountMethod.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbsAmountMethod_WindowActions);
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
            // cbCorrection
            // 
            resources.ApplyResources(this.cbCorrection, "cbCorrection");
            this.cbCorrection.Name = "cbCorrection";
            this.cbCorrection.NamedProperties.Put("DataType", "5");
            this.cbCorrection.NamedProperties.Put("EnumerateMethod", "");
            this.cbCorrection.NamedProperties.Put("LovReference", "");
            this.cbCorrection.NamedProperties.Put("ResizeableChildObject", "");
            this.cbCorrection.NamedProperties.Put("SqlColumn", "");
            this.cbCorrection.NamedProperties.Put("ValidateMethod", "");
            this.cbCorrection.NamedProperties.Put("XDataLength", "1");
            this.cbCorrection.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cbCorrection_WindowActions);
            // 
            // cbUseCorrectionRows
            // 
            resources.ApplyResources(this.cbUseCorrectionRows, "cbUseCorrectionRows");
            this.cbUseCorrectionRows.Name = "cbUseCorrectionRows";
            this.cbUseCorrectionRows.NamedProperties.Put("DataType", "5");
            this.cbUseCorrectionRows.NamedProperties.Put("EnumerateMethod", "");
            this.cbUseCorrectionRows.NamedProperties.Put("FieldFlags", "290");
            this.cbUseCorrectionRows.NamedProperties.Put("LovReference", "");
            this.cbUseCorrectionRows.NamedProperties.Put("ResizeableChildObject", "");
            this.cbUseCorrectionRows.NamedProperties.Put("SqlColumn", "USE_CORRECTION_ROWS");
            this.cbUseCorrectionRows.NamedProperties.Put("ValidateMethod", "");
            this.cbUseCorrectionRows.NamedProperties.Put("XDataLength", "5");
            this.cbUseCorrectionRows.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cbUseCorrectionRows_WindowActions);
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
            this.dfsTextId.NamedProperties.Put("FieldFlags", "774");
            this.dfsTextId.NamedProperties.Put("LovReference", "VOUCHER_TEXT(:global.company)");
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
            this.dfsRowText.NamedProperties.Put("SqlColumn", "VOUCHER_TEXT2");
            this.dfsRowText.NamedProperties.Put("ValidateMethod", "");
            // 
            // gbVoucher_Status_Information
            // 
            this.gbVoucher_Status_Information.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.gbVoucher_Status_Information, "Header");
            resources.ApplyResources(this.gbVoucher_Status_Information, "gbVoucher_Status_Information");
            this.gbVoucher_Status_Information.Name = "gbVoucher_Status_Information";
            this.gbVoucher_Status_Information.TabStop = false;
            // 
            // labeldfdDateReg
            // 
            resources.ApplyResources(this.labeldfdDateReg, "labeldfdDateReg");
            this.labeldfdDateReg.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeldfdDateReg, "Header");
            this.labeldfdDateReg.Name = "labeldfdDateReg";
            // 
            // dfdDateReg
            // 
            this.picTab.SetControlTabPages(this.dfdDateReg, "Header");
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
            this.picTab.SetControlTabPages(this.labeldfsUserId, "Header");
            this.labeldfsUserId.Name = "labeldfsUserId";
            // 
            // dfsUserId
            // 
            this.dfsUserId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.picTab.SetControlTabPages(this.dfsUserId, "Header");
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
            // labeldfsEnteredByUserGroup
            // 
            resources.ApplyResources(this.labeldfsEnteredByUserGroup, "labeldfsEnteredByUserGroup");
            this.labeldfsEnteredByUserGroup.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeldfsEnteredByUserGroup, "Header");
            this.labeldfsEnteredByUserGroup.Name = "labeldfsEnteredByUserGroup";
            // 
            // dfsEnteredByUserGroup
            // 
            this.picTab.SetControlTabPages(this.dfsEnteredByUserGroup, "Header");
            resources.ApplyResources(this.dfsEnteredByUserGroup, "dfsEnteredByUserGroup");
            this.dfsEnteredByUserGroup.Name = "dfsEnteredByUserGroup";
            this.dfsEnteredByUserGroup.NamedProperties.Put("EnumerateMethod", "");
            this.dfsEnteredByUserGroup.NamedProperties.Put("FieldFlags", "288");
            this.dfsEnteredByUserGroup.NamedProperties.Put("LovReference", "USER_GROUP_MEMBER_FINANCE3(:global.company,USERID)");
            this.dfsEnteredByUserGroup.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsEnteredByUserGroup.NamedProperties.Put("SqlColumn", "ENTERED_BY_USER_GROUP");
            this.dfsEnteredByUserGroup.NamedProperties.Put("ValidateMethod", "");
            this.dfsEnteredByUserGroup.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsEnteredByUserGroup_WindowActions);
            // 
            // labeldfdApprovalDate
            // 
            resources.ApplyResources(this.labeldfdApprovalDate, "labeldfdApprovalDate");
            this.labeldfdApprovalDate.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeldfdApprovalDate, "Header");
            this.labeldfdApprovalDate.Name = "labeldfdApprovalDate";
            // 
            // dfdApprovalDate
            // 
            this.picTab.SetControlTabPages(this.dfdApprovalDate, "Header");
            this.dfdApprovalDate.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.dfdApprovalDate.Format = "d";
            resources.ApplyResources(this.dfdApprovalDate, "dfdApprovalDate");
            this.dfdApprovalDate.Name = "dfdApprovalDate";
            this.dfdApprovalDate.NamedProperties.Put("EnumerateMethod", "");
            this.dfdApprovalDate.NamedProperties.Put("FieldFlags", "288");
            this.dfdApprovalDate.NamedProperties.Put("LovReference", "");
            this.dfdApprovalDate.NamedProperties.Put("ResizeableChildObject", "");
            this.dfdApprovalDate.NamedProperties.Put("SqlColumn", "APPROVAL_DATE");
            this.dfdApprovalDate.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsApprovedByUserid
            // 
            resources.ApplyResources(this.labeldfsApprovedByUserid, "labeldfsApprovedByUserid");
            this.labeldfsApprovedByUserid.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeldfsApprovedByUserid, "Header");
            this.labeldfsApprovedByUserid.Name = "labeldfsApprovedByUserid";
            // 
            // dfsApprovedByUserid
            // 
            this.picTab.SetControlTabPages(this.dfsApprovedByUserid, "Header");
            resources.ApplyResources(this.dfsApprovedByUserid, "dfsApprovedByUserid");
            this.dfsApprovedByUserid.Name = "dfsApprovedByUserid";
            this.dfsApprovedByUserid.NamedProperties.Put("EnumerateMethod", "");
            this.dfsApprovedByUserid.NamedProperties.Put("FieldFlags", "288");
            this.dfsApprovedByUserid.NamedProperties.Put("LovReference", "");
            this.dfsApprovedByUserid.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsApprovedByUserid.NamedProperties.Put("SqlColumn", "APPROVED_BY_USERID");
            this.dfsApprovedByUserid.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsApprovedByUserGroup
            // 
            resources.ApplyResources(this.labeldfsApprovedByUserGroup, "labeldfsApprovedByUserGroup");
            this.labeldfsApprovedByUserGroup.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeldfsApprovedByUserGroup, "Header");
            this.labeldfsApprovedByUserGroup.Name = "labeldfsApprovedByUserGroup";
            // 
            // dfsApprovedByUserGroup
            // 
            this.picTab.SetControlTabPages(this.dfsApprovedByUserGroup, "Header");
            resources.ApplyResources(this.dfsApprovedByUserGroup, "dfsApprovedByUserGroup");
            this.dfsApprovedByUserGroup.Name = "dfsApprovedByUserGroup";
            this.dfsApprovedByUserGroup.NamedProperties.Put("EnumerateMethod", "");
            this.dfsApprovedByUserGroup.NamedProperties.Put("FieldFlags", "288");
            this.dfsApprovedByUserGroup.NamedProperties.Put("LovReference", "");
            this.dfsApprovedByUserGroup.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsApprovedByUserGroup.NamedProperties.Put("SqlColumn", "APPROVED_BY_USER_GROUP");
            this.dfsApprovedByUserGroup.NamedProperties.Put("ValidateMethod", "");
            // 
            // gbAdditional_Infomation
            // 
            this.gbAdditional_Infomation.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.gbAdditional_Infomation, "Header");
            resources.ApplyResources(this.gbAdditional_Infomation, "gbAdditional_Infomation");
            this.gbAdditional_Infomation.Name = "gbAdditional_Infomation";
            this.gbAdditional_Infomation.TabStop = false;
            // 
            // labeldfsUpdateError
            // 
            resources.ApplyResources(this.labeldfsUpdateError, "labeldfsUpdateError");
            this.labeldfsUpdateError.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeldfsUpdateError, "Header");
            this.labeldfsUpdateError.Name = "labeldfsUpdateError";
            // 
            // dfsUpdateError
            // 
            this.picTab.SetControlTabPages(this.dfsUpdateError, "Header");
            resources.ApplyResources(this.dfsUpdateError, "dfsUpdateError");
            this.dfsUpdateError.Name = "dfsUpdateError";
            this.dfsUpdateError.NamedProperties.Put("EnumerateMethod", "");
            this.dfsUpdateError.NamedProperties.Put("FieldFlags", "308");
            this.dfsUpdateError.NamedProperties.Put("LovReference", "");
            this.dfsUpdateError.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsUpdateError.NamedProperties.Put("SqlColumn", "UPDATE_ERROR");
            this.dfsUpdateError.NamedProperties.Put("ValidateMethod", "");
            this.dfsUpdateError.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsUpdateError_WindowActions);
            // 
            // cbInterimVoucher
            // 
            this.cbInterimVoucher.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.cbInterimVoucher, "Header");
            resources.ApplyResources(this.cbInterimVoucher, "cbInterimVoucher");
            this.cbInterimVoucher.Name = "cbInterimVoucher";
            this.cbInterimVoucher.NamedProperties.Put("EnumerateMethod", "");
            this.cbInterimVoucher.NamedProperties.Put("FieldFlags", "288");
            this.cbInterimVoucher.NamedProperties.Put("LovReference", "");
            this.cbInterimVoucher.NamedProperties.Put("ResizeableChildObject", "");
            this.cbInterimVoucher.NamedProperties.Put("SqlColumn", "INTERIM_VOUCHER");
            this.cbInterimVoucher.NamedProperties.Put("ValidateMethod", "");
            this.cbInterimVoucher.NamedProperties.Put("XDataLength", "1");
            this.cbInterimVoucher.UseVisualStyleBackColor = false;
            this.cbInterimVoucher.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cbInterimVoucher_WindowActions);
            // 
            // dfsVoucherGroup
            // 
            this.dfsVoucherGroup.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsVoucherGroup, "dfsVoucherGroup");
            this.dfsVoucherGroup.Name = "dfsVoucherGroup";
            this.dfsVoucherGroup.NamedProperties.Put("EnumerateMethod", "");
            this.dfsVoucherGroup.NamedProperties.Put("FieldFlags", "262");
            this.dfsVoucherGroup.NamedProperties.Put("LovReference", "");
            this.dfsVoucherGroup.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsVoucherGroup.NamedProperties.Put("SqlColumn", "FUNCTION_GROUP");
            this.dfsVoucherGroup.NamedProperties.Put("ValidateMethod", "");
            // 
            // dfStatus
            // 
            this.dfStatus.Name = "dfStatus";
            this.dfStatus.NamedProperties.Put("EnumerateMethod", "");
            this.dfStatus.NamedProperties.Put("LovReference", "");
            this.dfStatus.NamedProperties.Put("ResizeableChildObject", "");
            this.dfStatus.NamedProperties.Put("SqlColumn", "STATE");
            this.dfStatus.NamedProperties.Put("ValidateMethod", "");
            resources.ApplyResources(this.dfStatus, "dfStatus");
            // 
            // cbAutomatic
            // 
            resources.ApplyResources(this.cbAutomatic, "cbAutomatic");
            this.cbAutomatic.Name = "cbAutomatic";
            this.cbAutomatic.NamedProperties.Put("EnumerateMethod", "");
            this.cbAutomatic.NamedProperties.Put("FieldFlags", "288");
            this.cbAutomatic.NamedProperties.Put("LovReference", "");
            this.cbAutomatic.NamedProperties.Put("ResizeableChildObject", "");
            this.cbAutomatic.NamedProperties.Put("SqlColumn", "AUTOMATIC");
            this.cbAutomatic.NamedProperties.Put("ValidateMethod", "");
            this.cbAutomatic.NamedProperties.Put("XDataLength", "20");
            this.cbAutomatic.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cbAutomatic_WindowActions);
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
            this.dfsCurrencyType.NamedProperties.Put("FieldFlags", "294");
            this.dfsCurrencyType.NamedProperties.Put("LovReference", "CURRENCY_TYPE(:global.company)");
            this.dfsCurrencyType.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsCurrencyType.NamedProperties.Put("SqlColumn", "CURRENCY_TYPE");
            this.dfsCurrencyType.NamedProperties.Put("ValidateMethod", "");
            this.dfsCurrencyType.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsCurrencyType_WindowActions);
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
            this.dfsCurrencyCode.NamedProperties.Put("FieldFlags", "294");
            this.dfsCurrencyCode.NamedProperties.Put("LovReference", "CURRENCY_RATE1(:global.company,CURRENCY_TYPE)");
            this.dfsCurrencyCode.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsCurrencyCode.NamedProperties.Put("SqlColumn", "CURRENCY_CODE");
            this.dfsCurrencyCode.NamedProperties.Put("ValidateMethod", "");
            this.dfsCurrencyCode.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsCurrencyCode_WindowActions);
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
            // dfsRevCostClearVoucher
            // 
            this.dfsRevCostClearVoucher.Name = "dfsRevCostClearVoucher";
            this.dfsRevCostClearVoucher.NamedProperties.Put("EnumerateMethod", "");
            this.dfsRevCostClearVoucher.NamedProperties.Put("LovReference", "");
            this.dfsRevCostClearVoucher.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsRevCostClearVoucher.NamedProperties.Put("SqlColumn", "REVENUE_COST_CLEAR_VOUCHER");
            this.dfsRevCostClearVoucher.NamedProperties.Put("ValidateMethod", "");
            resources.ApplyResources(this.dfsRevCostClearVoucher, "dfsRevCostClearVoucher");
            // 
            // dfsRowGroupValidation
            // 
            this.dfsRowGroupValidation.Name = "dfsRowGroupValidation";
            this.dfsRowGroupValidation.NamedProperties.Put("EnumerateMethod", "");
            this.dfsRowGroupValidation.NamedProperties.Put("LovReference", "");
            this.dfsRowGroupValidation.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsRowGroupValidation.NamedProperties.Put("SqlColumn", "ROW_GROUP_VALIDATION");
            this.dfsRowGroupValidation.NamedProperties.Put("ValidateMethod", "");
            resources.ApplyResources(this.dfsRowGroupValidation, "dfsRowGroupValidation");
            // 
            // dfsReferenceMandatory
            // 
            this.dfsReferenceMandatory.Name = "dfsReferenceMandatory";
            this.dfsReferenceMandatory.NamedProperties.Put("EnumerateMethod", "");
            this.dfsReferenceMandatory.NamedProperties.Put("LovReference", "");
            this.dfsReferenceMandatory.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsReferenceMandatory.NamedProperties.Put("SqlColumn", "REFERENCE_MANDATORY");
            this.dfsReferenceMandatory.NamedProperties.Put("ValidateMethod", "");
            resources.ApplyResources(this.dfsReferenceMandatory, "dfsReferenceMandatory");
            // 
            // dfsTransferId
            // 
            resources.ApplyResources(this.dfsTransferId, "dfsTransferId");
            this.dfsTransferId.Name = "dfsTransferId";
            this.dfsTransferId.NamedProperties.Put("EnumerateMethod", "");
            this.dfsTransferId.NamedProperties.Put("FieldFlags", "294");
            this.dfsTransferId.NamedProperties.Put("LovReference", "");
            this.dfsTransferId.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsTransferId.NamedProperties.Put("SqlColumn", "TRANSFER_ID");
            this.dfsTransferId.NamedProperties.Put("ValidateMethod", "");
            // 
            // menuFrmMethods
            // 
            this.menuFrmMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem__Notes,
            this.menuItem_Copy,
            this.menuItem_Copy_1,
            this.menuItem__Interim,
            this.menuItem__Use,
            this.menuItem_Create,
            this.menuItem_Instant,
            this.menuItem_Change,
            this.menuSeparator1,
            this.menuFrmMethods_menuAdd_Investment});
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
            // menuItem_Copy
            // 
            this.menuItem_Copy.Command = this.menuFrmMethods_menuCopy__Voucher_in_Hold_Table___;
            this.menuItem_Copy.Name = "menuItem_Copy";
            resources.ApplyResources(this.menuItem_Copy, "menuItem_Copy");
            this.menuItem_Copy.Text = "Copy &Voucher in Hold Table...";
            // 
            // menuItem_Copy_1
            // 
            this.menuItem_Copy_1.Command = this.menuFrmMethods_menuCopy__GL_Voucher_Rows___;
            this.menuItem_Copy_1.Name = "menuItem_Copy_1";
            resources.ApplyResources(this.menuItem_Copy_1, "menuItem_Copy_1");
            this.menuItem_Copy_1.Text = "Copy &GL Voucher Rows...";
            // 
            // menuItem__Interim
            // 
            this.menuItem__Interim.Command = this.menuFrmMethods_menu_Interim_Voucher___;
            this.menuItem__Interim.Name = "menuItem__Interim";
            resources.ApplyResources(this.menuItem__Interim, "menuItem__Interim");
            this.menuItem__Interim.Text = "&Interim Voucher...";
            // 
            // menuItem__Use
            // 
            this.menuItem__Use.Command = this.menuFrmMethods_menu_Use_Voucher_Template___;
            this.menuItem__Use.Name = "menuItem__Use";
            resources.ApplyResources(this.menuItem__Use, "menuItem__Use");
            this.menuItem__Use.Text = "&Use Voucher Template...";
            // 
            // menuItem_Create
            // 
            this.menuItem_Create.Command = this.menuFrmMethods_menuCreate_Voucher__Template___;
            this.menuItem_Create.Name = "menuItem_Create";
            resources.ApplyResources(this.menuItem_Create, "menuItem_Create");
            this.menuItem_Create.Text = "Create Voucher &Template...";
            // 
            // menuItem_Instant
            // 
            this.menuItem_Instant.Command = this.menuFrmMethods_menuInstant_Update_General__Ledger__;
            this.menuItem_Instant.Name = "menuItem_Instant";
            resources.ApplyResources(this.menuItem_Instant, "menuItem_Instant");
            this.menuItem_Instant.Text = "Instant Update General &Ledger...";
            // 
            // menuItem_Change
            // 
            this.menuItem_Change.Command = this.menuFrmMethods_menuChange__Company___;
            this.menuItem_Change.Name = "menuItem_Change";
            resources.ApplyResources(this.menuItem_Change, "menuItem_Change");
            this.menuItem_Change.Text = "Change &Company...";
            // 
            // menuSeparator1
            // 
            this.menuSeparator1.Name = "menuSeparator1";
            resources.ApplyResources(this.menuSeparator1, "menuSeparator1");
            // 
            // menuFrmMethods_menuAdd_Investment
            // 
            this.menuFrmMethods_menuAdd_Investment.Command = this.menuItem__AddInvestment;
            this.menuFrmMethods_menuAdd_Investment.Name = "menuFrmMethods_menuAdd_Investment";
            resources.ApplyResources(this.menuFrmMethods_menuAdd_Investment, "menuFrmMethods_menuAdd_Investment");
            this.menuFrmMethods_menuAdd_Investment.Text = "Add Investment Information...";
            // 
            // menuItem__AddInvestment
            // 
            resources.ApplyResources(this.menuItem__AddInvestment, "menuItem__AddInvestment");
            this.menuItem__AddInvestment.Name = "menuItem__AddInvestment";
            this.menuItem__AddInvestment.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__AddInvestment_Execute);
            this.menuItem__AddInvestment.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__AddInvestment_Inquire);
            // 
            // labeldfnParallelCurrencyBalance
            // 
            resources.ApplyResources(this.labeldfnParallelCurrencyBalance, "labeldfnParallelCurrencyBalance");
            this.labeldfnParallelCurrencyBalance.Name = "labeldfnParallelCurrencyBalance";
            // 
            // dfnParallelCurrencyBalance
            // 
            this.dfnParallelCurrencyBalance.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfnParallelCurrencyBalance, "dfnParallelCurrencyBalance");
            this.dfnParallelCurrencyBalance.Name = "dfnParallelCurrencyBalance";
            this.dfnParallelCurrencyBalance.NamedProperties.Put("EnumerateMethod", "");
            this.dfnParallelCurrencyBalance.NamedProperties.Put("FieldFlags", "292");
            this.dfnParallelCurrencyBalance.NamedProperties.Put("Format", "");
            this.dfnParallelCurrencyBalance.NamedProperties.Put("LovReference", "");
            this.dfnParallelCurrencyBalance.NamedProperties.Put("ResizeableChildObject", "");
            this.dfnParallelCurrencyBalance.NamedProperties.Put("SqlColumn", "PARALLEL_CURRENCY_BALANCE");
            this.dfnParallelCurrencyBalance.NamedProperties.Put("ValidateMethod", "");
            // 
            // cGroupBoxVoucherReferenceDetails
            // 
            this.cGroupBoxVoucherReferenceDetails.BackColor = System.Drawing.SystemColors.Window;
            this.cGroupBoxVoucherReferenceDetails.Controls.Add(this.dfsVoucherTypeReference);
            this.cGroupBoxVoucherReferenceDetails.Controls.Add(this.labelVoucherTypeReference);
            this.cGroupBoxVoucherReferenceDetails.Controls.Add(this.dfnVoucherNoReference);
            this.cGroupBoxVoucherReferenceDetails.Controls.Add(this.labelVoucherNoReference);
            this.cGroupBoxVoucherReferenceDetails.Controls.Add(this.dfsReferenceCompany);
            this.cGroupBoxVoucherReferenceDetails.Controls.Add(this.dfnAccountingYearReference);
            this.cGroupBoxVoucherReferenceDetails.Controls.Add(this.labelAccountingYearReference);
            this.cGroupBoxVoucherReferenceDetails.Controls.Add(this.labeldfsCompany);
            resources.ApplyResources(this.cGroupBoxVoucherReferenceDetails, "cGroupBoxVoucherReferenceDetails");
            this.cGroupBoxVoucherReferenceDetails.Name = "cGroupBoxVoucherReferenceDetails";
            this.cGroupBoxVoucherReferenceDetails.TabStop = false;
            // 
            // dfsVoucherTypeReference
            // 
            this.dfsVoucherTypeReference.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.dfsVoucherTypeReference, "dfsVoucherTypeReference");
            this.dfsVoucherTypeReference.Name = "dfsVoucherTypeReference";
            this.dfsVoucherTypeReference.NamedProperties.Put("EnumerateMethod", "");
            this.dfsVoucherTypeReference.NamedProperties.Put("FieldFlags", "294");
            this.dfsVoucherTypeReference.NamedProperties.Put("LovReference", "");
            this.dfsVoucherTypeReference.NamedProperties.Put("SqlColumn", "VOUCHER_TYPE_REFERENCE");
            this.dfsVoucherTypeReference.ReadOnly = true;
            // 
            // labelVoucherTypeReference
            // 
            resources.ApplyResources(this.labelVoucherTypeReference, "labelVoucherTypeReference");
            this.labelVoucherTypeReference.Name = "labelVoucherTypeReference";
            // 
            // dfnVoucherNoReference
            // 
            this.dfnVoucherNoReference.BackColor = System.Drawing.SystemColors.Control;
            this.dfnVoucherNoReference.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfnVoucherNoReference, "dfnVoucherNoReference");
            this.dfnVoucherNoReference.Name = "dfnVoucherNoReference";
            this.dfnVoucherNoReference.NamedProperties.Put("EnumerateMethod", "");
            this.dfnVoucherNoReference.NamedProperties.Put("FieldFlags", "294");
            this.dfnVoucherNoReference.NamedProperties.Put("Format", "");
            this.dfnVoucherNoReference.NamedProperties.Put("LovReference", "");
            this.dfnVoucherNoReference.NamedProperties.Put("SqlColumn", "VOUCHER_NO_REFERENCE");
            this.dfnVoucherNoReference.ReadOnly = true;
            // 
            // labelVoucherNoReference
            // 
            resources.ApplyResources(this.labelVoucherNoReference, "labelVoucherNoReference");
            this.labelVoucherNoReference.Name = "labelVoucherNoReference";
            // 
            // dfsReferenceCompany
            // 
            this.dfsReferenceCompany.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.dfsReferenceCompany, "dfsReferenceCompany");
            this.dfsReferenceCompany.Name = "dfsReferenceCompany";
            this.dfsReferenceCompany.ReadOnly = true;
            // 
            // dfnAccountingYearReference
            // 
            this.dfnAccountingYearReference.BackColor = System.Drawing.Color.White;
            this.dfnAccountingYearReference.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfnAccountingYearReference, "dfnAccountingYearReference");
            this.dfnAccountingYearReference.Name = "dfnAccountingYearReference";
            this.dfnAccountingYearReference.NamedProperties.Put("EnumerateMethod", "");
            this.dfnAccountingYearReference.NamedProperties.Put("FieldFlags", "294");
            this.dfnAccountingYearReference.NamedProperties.Put("Format", "");
            this.dfnAccountingYearReference.NamedProperties.Put("LovReference", "");
            this.dfnAccountingYearReference.NamedProperties.Put("SqlColumn", "ACCOUNTING_YEAR_REFERENCE");
            this.dfnAccountingYearReference.ReadOnly = true;
            // 
            // labelAccountingYearReference
            // 
            resources.ApplyResources(this.labelAccountingYearReference, "labelAccountingYearReference");
            this.labelAccountingYearReference.Name = "labelAccountingYearReference";
            // 
            // dfnVoucherNoReference1
            // 
            this.picTab.SetControlTabPages(this.dfnVoucherNoReference1, "VouPosting");
            this.dfnVoucherNoReference1.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfnVoucherNoReference1, "dfnVoucherNoReference1");
            this.dfnVoucherNoReference1.Name = "dfnVoucherNoReference1";
            this.dfnVoucherNoReference1.NamedProperties.Put("EnumerateMethod", "");
            this.dfnVoucherNoReference1.NamedProperties.Put("FieldFlags", "294");
            this.dfnVoucherNoReference1.NamedProperties.Put("Format", "");
            this.dfnVoucherNoReference1.NamedProperties.Put("LovReference", "");
            this.dfnVoucherNoReference1.NamedProperties.Put("SqlColumn", "VOUCHER_NO_REFERENCE");
            // 
            // labelVoucherNoReference1
            // 
            resources.ApplyResources(this.labelVoucherNoReference1, "labelVoucherNoReference1");
            this.picTab.SetControlTabPages(this.labelVoucherNoReference1, "VouPosting");
            this.labelVoucherNoReference1.Name = "labelVoucherNoReference1";
            // 
            // dfsVoucherTypeReference1
            // 
            this.picTab.SetControlTabPages(this.dfsVoucherTypeReference1, "VouPosting");
            resources.ApplyResources(this.dfsVoucherTypeReference1, "dfsVoucherTypeReference1");
            this.dfsVoucherTypeReference1.Name = "dfsVoucherTypeReference1";
            this.dfsVoucherTypeReference1.NamedProperties.Put("EnumerateMethod", "");
            this.dfsVoucherTypeReference1.NamedProperties.Put("FieldFlags", "294");
            this.dfsVoucherTypeReference1.NamedProperties.Put("LovReference", "");
            this.dfsVoucherTypeReference1.NamedProperties.Put("SqlColumn", "VOUCHER_TYPE_REFERENCE");
            // 
            // labelVoucherTypeReference1
            // 
            resources.ApplyResources(this.labelVoucherTypeReference1, "labelVoucherTypeReference1");
            this.picTab.SetControlTabPages(this.labelVoucherTypeReference1, "VouPosting");
            this.labelVoucherTypeReference1.Name = "labelVoucherTypeReference1";
            // 
            // frmEntryVoucher
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.dfsVoucherTypeReference1);
            this.Controls.Add(this.labelVoucherTypeReference1);
            this.Controls.Add(this.dfnVoucherNoReference1);
            this.Controls.Add(this.labelVoucherNoReference1);
            this.Controls.Add(this.cGroupBoxVoucherReferenceDetails);
            this.Controls.Add(this.dfnParallelCurrencyBalance);
            this.Controls.Add(this.labeldfnParallelCurrencyBalance);
            this.Controls.Add(this.dfsTransferId);
            this.Controls.Add(this.dfsReferenceMandatory);
            this.Controls.Add(this.dfsRowGroupValidation);
            this.Controls.Add(this.dfsRevCostClearVoucher);
            this.Controls.Add(this.dfnBalance);
            this.Controls.Add(this.dfnCurrencyBalance);
            this.Controls.Add(this.dfnConversionFactor);
            this.Controls.Add(this.dfnCurrencyRate);
            this.Controls.Add(this.dfsCurrencyCode);
            this.Controls.Add(this.dfsCurrencyType);
            this.Controls.Add(this.cbAutomatic);
            this.Controls.Add(this.dfStatus);
            this.Controls.Add(this.dfsVoucherGroup);
            this.Controls.Add(this.dfsUpdateError);
            this.Controls.Add(this.dfsApprovedByUserGroup);
            this.Controls.Add(this.dfsApprovedByUserid);
            this.Controls.Add(this.dfdApprovalDate);
            this.Controls.Add(this.dfsEnteredByUserGroup);
            this.Controls.Add(this.dfsUserId);
            this.Controls.Add(this.dfdDateReg);
            this.Controls.Add(this.dfsRowText);
            this.Controls.Add(this.dfsTextId);
            this.Controls.Add(this.cbInterimVoucher);
            this.Controls.Add(this.cbUseCorrectionRows);
            this.Controls.Add(this.cbCorrection);
            this.Controls.Add(this.cbFreeText);
            this.Controls.Add(this.cmbsAmountMethod);
            this.Controls.Add(this.dfsPeriodDescription);
            this.Controls.Add(this.dfnAccountingPeriod);
            this.Controls.Add(this.dfnAccountingYear);
            this.Controls.Add(this.cmbsVoucherStatus);
            this.Controls.Add(this.dfnVoucherNo);
            this.Controls.Add(this.dfsVoucherTypeDescription);
            this.Controls.Add(this.ccsVoucherType);
            this.Controls.Add(this.dfsUserGroup);
            this.Controls.Add(this.dfdVoucherDate);
            this.Controls.Add(this.dfsCompany);
            this.Controls.Add(this.labeldfnBalance);
            this.Controls.Add(this.labeldfnCurrencyBalance);
            this.Controls.Add(this.labeldfsCurrencyCode);
            this.Controls.Add(this.labeldfsCurrencyType);
            this.Controls.Add(this.labeldfdDateReg);
            this.Controls.Add(this.labeldfsUserId);
            this.Controls.Add(this.labeldfsEnteredByUserGroup);
            this.Controls.Add(this.labeldfdApprovalDate);
            this.Controls.Add(this.labeldfsApprovedByUserid);
            this.Controls.Add(this.labeldfsApprovedByUserGroup);
            this.Controls.Add(this.labeldfsUpdateError);
            this.Controls.Add(this.labeldfsRowText);
            this.Controls.Add(this.labeldfsTextId);
            this.Controls.Add(this.labelcmbsAmountMethod);
            this.Controls.Add(this.labeldfnAccountingPeriod);
            this.Controls.Add(this.labeldfnAccountingYear);
            this.Controls.Add(this.labelcmbsVoucherStatus);
            this.Controls.Add(this.labeldfnVoucherNo);
            this.Controls.Add(this.labeldfsVoucherTypeDescription);
            this.Controls.Add(this.labelccsVoucherType);
            this.Controls.Add(this.labeldfsUserGroup);
            this.Controls.Add(this.labeldfdVoucherDate);
            this.Controls.Add(this.gbVoucher_Status_Information);
            this.Controls.Add(this.gbAdditional_Infomation);
            this.Name = "frmEntryVoucher";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "COMPANY = :global.company  AND\r\nVOUCHER_UPDATED_DB=\'N\'");
            this.NamedProperties.Put("LogicalUnit", "Voucher");
            this.NamedProperties.Put("PackageName", "VOUCHER_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("ViewName", "VOUCHER");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.frmEntryVoucher_WindowActions);
            this.Controls.SetChildIndex(this.gbAdditional_Infomation, 0);
            this.Controls.SetChildIndex(this.gbVoucher_Status_Information, 0);
            this.Controls.SetChildIndex(this.picTab, 0);
            this.Controls.SetChildIndex(this.labeldfdVoucherDate, 0);
            this.Controls.SetChildIndex(this.labeldfsUserGroup, 0);
            this.Controls.SetChildIndex(this.labelccsVoucherType, 0);
            this.Controls.SetChildIndex(this.labeldfsVoucherTypeDescription, 0);
            this.Controls.SetChildIndex(this.labeldfnVoucherNo, 0);
            this.Controls.SetChildIndex(this.labelcmbsVoucherStatus, 0);
            this.Controls.SetChildIndex(this.labeldfnAccountingYear, 0);
            this.Controls.SetChildIndex(this.labeldfnAccountingPeriod, 0);
            this.Controls.SetChildIndex(this.labelcmbsAmountMethod, 0);
            this.Controls.SetChildIndex(this.labeldfsTextId, 0);
            this.Controls.SetChildIndex(this.labeldfsRowText, 0);
            this.Controls.SetChildIndex(this.labeldfsUpdateError, 0);
            this.Controls.SetChildIndex(this.labeldfsApprovedByUserGroup, 0);
            this.Controls.SetChildIndex(this.labeldfsApprovedByUserid, 0);
            this.Controls.SetChildIndex(this.labeldfdApprovalDate, 0);
            this.Controls.SetChildIndex(this.labeldfsEnteredByUserGroup, 0);
            this.Controls.SetChildIndex(this.labeldfsUserId, 0);
            this.Controls.SetChildIndex(this.labeldfdDateReg, 0);
            this.Controls.SetChildIndex(this.labeldfsCurrencyType, 0);
            this.Controls.SetChildIndex(this.labeldfsCurrencyCode, 0);
            this.Controls.SetChildIndex(this.labeldfnCurrencyBalance, 0);
            this.Controls.SetChildIndex(this.labeldfnBalance, 0);
            this.Controls.SetChildIndex(this.dfsCompany, 0);
            this.Controls.SetChildIndex(this.dfdVoucherDate, 0);
            this.Controls.SetChildIndex(this.dfsUserGroup, 0);
            this.Controls.SetChildIndex(this.ccsVoucherType, 0);
            this.Controls.SetChildIndex(this.dfsVoucherTypeDescription, 0);
            this.Controls.SetChildIndex(this.dfnVoucherNo, 0);
            this.Controls.SetChildIndex(this.cmbsVoucherStatus, 0);
            this.Controls.SetChildIndex(this.dfnAccountingYear, 0);
            this.Controls.SetChildIndex(this.dfnAccountingPeriod, 0);
            this.Controls.SetChildIndex(this.dfsPeriodDescription, 0);
            this.Controls.SetChildIndex(this.cmbsAmountMethod, 0);
            this.Controls.SetChildIndex(this.cbFreeText, 0);
            this.Controls.SetChildIndex(this.cbCorrection, 0);
            this.Controls.SetChildIndex(this.cbUseCorrectionRows, 0);
            this.Controls.SetChildIndex(this.cbInterimVoucher, 0);
            this.Controls.SetChildIndex(this.dfsTextId, 0);
            this.Controls.SetChildIndex(this.dfsRowText, 0);
            this.Controls.SetChildIndex(this.dfdDateReg, 0);
            this.Controls.SetChildIndex(this.dfsUserId, 0);
            this.Controls.SetChildIndex(this.dfsEnteredByUserGroup, 0);
            this.Controls.SetChildIndex(this.dfdApprovalDate, 0);
            this.Controls.SetChildIndex(this.dfsApprovedByUserid, 0);
            this.Controls.SetChildIndex(this.dfsApprovedByUserGroup, 0);
            this.Controls.SetChildIndex(this.dfsUpdateError, 0);
            this.Controls.SetChildIndex(this.dfsVoucherGroup, 0);
            this.Controls.SetChildIndex(this.dfStatus, 0);
            this.Controls.SetChildIndex(this.cbAutomatic, 0);
            this.Controls.SetChildIndex(this.dfsCurrencyType, 0);
            this.Controls.SetChildIndex(this.dfsCurrencyCode, 0);
            this.Controls.SetChildIndex(this.dfnCurrencyRate, 0);
            this.Controls.SetChildIndex(this.dfnConversionFactor, 0);
            this.Controls.SetChildIndex(this.dfnCurrencyBalance, 0);
            this.Controls.SetChildIndex(this.dfnBalance, 0);
            this.Controls.SetChildIndex(this.dfsRevCostClearVoucher, 0);
            this.Controls.SetChildIndex(this.dfsRowGroupValidation, 0);
            this.Controls.SetChildIndex(this.dfsReferenceMandatory, 0);
            this.Controls.SetChildIndex(this.dfsTransferId, 0);
            this.Controls.SetChildIndex(this.labeldfnParallelCurrencyBalance, 0);
            this.Controls.SetChildIndex(this.dfnParallelCurrencyBalance, 0);
            this.Controls.SetChildIndex(this.cGroupBoxVoucherReferenceDetails, 0);
            this.Controls.SetChildIndex(this.labelVoucherNoReference1, 0);
            this.Controls.SetChildIndex(this.dfnVoucherNoReference1, 0);
            this.Controls.SetChildIndex(this.labelVoucherTypeReference1, 0);
            this.Controls.SetChildIndex(this.dfsVoucherTypeReference1, 0);
            this.menuFrmMethods.ResumeLayout(false);
            this.cGroupBoxVoucherReferenceDetails.ResumeLayout(false);
            this.cGroupBoxVoucherReferenceDetails.PerformLayout();
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

        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menu_Notes___;
        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menuCopy__Voucher_in_Hold_Table___;
        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menuCopy__GL_Voucher_Rows___;
        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menu_Interim_Voucher___;
        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menu_Use_Voucher_Template___;
        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menuCreate_Voucher__Template___;
        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menuInstant_Update_General__Ledger__;
        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menuChange__Company___;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuFrmMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Notes;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Copy;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Copy_1;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Interim;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Use;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Create;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Instant;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change;
        protected Fnd.Windows.Forms.FndCommand menuItem__AddInvestment;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuFrmMethods_menuAdd_Investment;
        protected Fnd.Windows.Forms.FndToolStripSeparator menuSeparator1;
        protected cBackgroundText labeldfnParallelCurrencyBalance;
        public cDataField dfnParallelCurrencyBalance;
        protected cGroupBox cGroupBoxVoucherReferenceDetails;
        protected cDataField dfnAccountingYearReference;
        protected cBackgroundText labelAccountingYearReference;
        protected cDataField dfsReferenceCompany;
        protected cDataField dfsVoucherTypeReference;
        protected cBackgroundText labelVoucherTypeReference;
        protected cBackgroundText labelVoucherNoReference;
        public cDataField dfnVoucherNoReference;
        protected cDataField dfnVoucherNoReference1;
        protected cBackgroundText labelVoucherNoReference1;
        protected cDataField dfsVoucherTypeReference1;
        protected cBackgroundText labelVoucherTypeReference1;
	}
}
