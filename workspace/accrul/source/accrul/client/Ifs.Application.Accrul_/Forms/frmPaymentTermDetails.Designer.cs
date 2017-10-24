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
	
	public partial class frmPaymentTermDetails
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		protected cBackgroundText labeldfsCompany;
		public cDataField dfsCompany;
		protected cBackgroundText labelcmbPayTermId;
		public cRecListDataField cmbPayTermId;
		protected cBackgroundText labeldfsDescription;
		public cDataField dfsDescription;
		protected cBackgroundText labelcmbVatDistribution;
		public cComboBox cmbVatDistribution;
		public cCheckBox cbBlockForDirectDebiting;
		public cCheckBox cbUseCommercialYear;
		public cCheckBox cbConsiderPayVacPeriod;
		public cCheckBox cbExcludeCreditLimit;
        // Bug 73298 Begin - Changed the derived base class.
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPaymentTermDetails));
            this.menuTblMethods_menuPayment_Term_Discounts___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuFrmMethods_menuAutomatic_Installment_Plan___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuFrmMethods_menuChange__Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.labeldfsCompany = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsCompany = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelcmbPayTermId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbPayTermId = new Ifs.Fnd.ApplicationForms.cRecListDataField();
            this.labeldfsDescription = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsDescription = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelcmbVatDistribution = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbVatDistribution = new Ifs.Fnd.ApplicationForms.cComboBox();
            this.cbBlockForDirectDebiting = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.cbUseCommercialYear = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.cbConsiderPayVacPeriod = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.cbExcludeCreditLimit = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.menuFrmMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_Automatic = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuSeparator1 = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.menuItem_Change = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuTblMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_Payment = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.cbSuppressAmount = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.cbCashDiscFixassAcqValueDb = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.tblPaymentTermDetails = new Ifs.Application.Accrul.cChildTableFinBase();
            this.tblPaymentTermDetails_colsCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPaymentTermDetails_colsPayTermId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPaymentTermDetails_colnInstallmentNumber = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPaymentTermDetails_colnDayFrom = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPaymentTermDetails_colnDayTo = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPaymentTermDetails_colnFreeDeliveryMonths = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPaymentTermDetails_colnDaysToDueDate = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPaymentTermDetails_colEndOfMonth = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.tblPaymentTermDetails_colnDueDate1 = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPaymentTermDetails_colnDueDate2 = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPaymentTermDetails_colnDueDate3 = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPaymentTermDetails_colnNetAmountPercentage = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPaymentTermDetails_colsPaymentInstitute = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPaymentTermDetails_colsPaymentMethod = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPaymentTermDetails_colsDiscountSpecified = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.tblPaymentTermDetails_colnDummyInstallmentNumber = new Ifs.Fnd.ApplicationForms.cColumn();
            this.menuFrmMethods.SuspendLayout();
            this.menuTblMethods.SuspendLayout();
            this.tblPaymentTermDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuFrmMethods_menuAutomatic_Installment_Plan___);
            this.commandManager.Commands.Add(this.menuFrmMethods_menuChange__Company___);
            this.commandManager.Commands.Add(this.menuTblMethods_menuPayment_Term_Discounts___);
            this.commandManager.ContextMenus.Add(this.menuFrmMethods);
            this.commandManager.ContextMenus.Add(this.menuTblMethods);
            // 
            // menuTblMethods_menuPayment_Term_Discounts___
            // 
            resources.ApplyResources(this.menuTblMethods_menuPayment_Term_Discounts___, "menuTblMethods_menuPayment_Term_Discounts___");
            this.menuTblMethods_menuPayment_Term_Discounts___.Name = "menuTblMethods_menuPayment_Term_Discounts___";
            this.menuTblMethods_menuPayment_Term_Discounts___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Payment_Execute);
            this.menuTblMethods_menuPayment_Term_Discounts___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Payment_Inquire);
            // 
            // menuFrmMethods_menuAutomatic_Installment_Plan___
            // 
            resources.ApplyResources(this.menuFrmMethods_menuAutomatic_Installment_Plan___, "menuFrmMethods_menuAutomatic_Installment_Plan___");
            this.menuFrmMethods_menuAutomatic_Installment_Plan___.Name = "menuFrmMethods_menuAutomatic_Installment_Plan___";
            this.menuFrmMethods_menuAutomatic_Installment_Plan___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Automatic_Execute);
            this.menuFrmMethods_menuAutomatic_Installment_Plan___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Automatic_Inquire);
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
            this.dfsCompany.NamedProperties.Put("LovReference", "COMPANY_FINANCE");
            this.dfsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            // 
            // labelcmbPayTermId
            // 
            resources.ApplyResources(this.labelcmbPayTermId, "labelcmbPayTermId");
            this.labelcmbPayTermId.Name = "labelcmbPayTermId";
            // 
            // cmbPayTermId
            // 
            this.cmbPayTermId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.cmbPayTermId, "cmbPayTermId");
            this.cmbPayTermId.Name = "cmbPayTermId";
            this.cmbPayTermId.NamedProperties.Put("EnumerateMethod", "");
            this.cmbPayTermId.NamedProperties.Put("FieldFlags", "163");
            this.cmbPayTermId.NamedProperties.Put("Format", "9");
            this.cmbPayTermId.NamedProperties.Put("LovReference", "");
            this.cmbPayTermId.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbPayTermId.NamedProperties.Put("SqlColumn", "PAY_TERM_ID");
            this.cmbPayTermId.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsDescription
            // 
            resources.ApplyResources(this.labeldfsDescription, "labeldfsDescription");
            this.labeldfsDescription.Name = "labeldfsDescription";
            // 
            // dfsDescription
            // 
            resources.ApplyResources(this.dfsDescription, "dfsDescription");
            this.dfsDescription.Name = "dfsDescription";
            this.dfsDescription.NamedProperties.Put("EnumerateMethod", "");
            this.dfsDescription.NamedProperties.Put("FieldFlags", "291");
            this.dfsDescription.NamedProperties.Put("LovReference", "");
            this.dfsDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsDescription.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            this.dfsDescription.NamedProperties.Put("ValidateMethod", "");
            // 
            // labelcmbVatDistribution
            // 
            resources.ApplyResources(this.labelcmbVatDistribution, "labelcmbVatDistribution");
            this.labelcmbVatDistribution.Name = "labelcmbVatDistribution";
            // 
            // cmbVatDistribution
            // 
            this.cmbVatDistribution.DropDownHeight = 179;
            resources.ApplyResources(this.cmbVatDistribution, "cmbVatDistribution");
            this.cmbVatDistribution.Name = "cmbVatDistribution";
            this.cmbVatDistribution.NamedProperties.Put("EnumerateMethod", "VAT_DISTRIBUTION_API.Enumerate");
            this.cmbVatDistribution.NamedProperties.Put("FieldFlags", "293");
            this.cmbVatDistribution.NamedProperties.Put("LovReference", "");
            this.cmbVatDistribution.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbVatDistribution.NamedProperties.Put("SqlColumn", "VAT_DISTRIBUTION");
            this.cmbVatDistribution.NamedProperties.Put("ValidateMethod", "");
            // 
            // cbBlockForDirectDebiting
            // 
            resources.ApplyResources(this.cbBlockForDirectDebiting, "cbBlockForDirectDebiting");
            this.cbBlockForDirectDebiting.Name = "cbBlockForDirectDebiting";
            this.cbBlockForDirectDebiting.NamedProperties.Put("DataType", "5");
            this.cbBlockForDirectDebiting.NamedProperties.Put("EnumerateMethod", "");
            this.cbBlockForDirectDebiting.NamedProperties.Put("FieldFlags", "294");
            this.cbBlockForDirectDebiting.NamedProperties.Put("LovReference", "");
            this.cbBlockForDirectDebiting.NamedProperties.Put("ResizeableChildObject", "");
            this.cbBlockForDirectDebiting.NamedProperties.Put("SqlColumn", "BLOCK_FOR_DIRECT_DEBITING");
            this.cbBlockForDirectDebiting.NamedProperties.Put("ValidateMethod", "");
            this.cbBlockForDirectDebiting.NamedProperties.Put("XDataLength", "");
            // 
            // cbUseCommercialYear
            // 
            resources.ApplyResources(this.cbUseCommercialYear, "cbUseCommercialYear");
            this.cbUseCommercialYear.Name = "cbUseCommercialYear";
            this.cbUseCommercialYear.NamedProperties.Put("DataType", "5");
            this.cbUseCommercialYear.NamedProperties.Put("EnumerateMethod", "");
            this.cbUseCommercialYear.NamedProperties.Put("FieldFlags", "294");
            this.cbUseCommercialYear.NamedProperties.Put("LovReference", "");
            this.cbUseCommercialYear.NamedProperties.Put("ResizeableChildObject", "");
            this.cbUseCommercialYear.NamedProperties.Put("SqlColumn", "USE_COMMERCIAL_YEAR");
            this.cbUseCommercialYear.NamedProperties.Put("ValidateMethod", "");
            this.cbUseCommercialYear.NamedProperties.Put("XDataLength", "");
            // 
            // cbConsiderPayVacPeriod
            // 
            resources.ApplyResources(this.cbConsiderPayVacPeriod, "cbConsiderPayVacPeriod");
            this.cbConsiderPayVacPeriod.Name = "cbConsiderPayVacPeriod";
            this.cbConsiderPayVacPeriod.NamedProperties.Put("DataType", "5");
            this.cbConsiderPayVacPeriod.NamedProperties.Put("EnumerateMethod", "");
            this.cbConsiderPayVacPeriod.NamedProperties.Put("FieldFlags", "294");
            this.cbConsiderPayVacPeriod.NamedProperties.Put("LovReference", "");
            this.cbConsiderPayVacPeriod.NamedProperties.Put("ResizeableChildObject", "");
            this.cbConsiderPayVacPeriod.NamedProperties.Put("SqlColumn", "CONSIDER_PAY_VAC_PERIOD");
            this.cbConsiderPayVacPeriod.NamedProperties.Put("ValidateMethod", "");
            this.cbConsiderPayVacPeriod.NamedProperties.Put("XDataLength", "");
            // 
            // cbExcludeCreditLimit
            // 
            resources.ApplyResources(this.cbExcludeCreditLimit, "cbExcludeCreditLimit");
            this.cbExcludeCreditLimit.Name = "cbExcludeCreditLimit";
            this.cbExcludeCreditLimit.NamedProperties.Put("DataType", "5");
            this.cbExcludeCreditLimit.NamedProperties.Put("EnumerateMethod", "");
            this.cbExcludeCreditLimit.NamedProperties.Put("FieldFlags", "294");
            this.cbExcludeCreditLimit.NamedProperties.Put("LovReference", "");
            this.cbExcludeCreditLimit.NamedProperties.Put("ResizeableChildObject", "");
            this.cbExcludeCreditLimit.NamedProperties.Put("SqlColumn", "EXCLUDE_CREDIT_LIMIT");
            this.cbExcludeCreditLimit.NamedProperties.Put("ValidateMethod", "");
            this.cbExcludeCreditLimit.NamedProperties.Put("XDataLength", "");
            // 
            // menuFrmMethods
            // 
            this.menuFrmMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_Automatic,
            this.menuSeparator1,
            this.menuItem_Change});
            this.menuFrmMethods.Name = "menuFrmMethods";
            resources.ApplyResources(this.menuFrmMethods, "menuFrmMethods");
            // 
            // menuItem_Automatic
            // 
            this.menuItem_Automatic.Command = this.menuFrmMethods_menuAutomatic_Installment_Plan___;
            this.menuItem_Automatic.Name = "menuItem_Automatic";
            resources.ApplyResources(this.menuItem_Automatic, "menuItem_Automatic");
            this.menuItem_Automatic.Text = "Automatic Installment Plan...";
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
            // menuTblMethods
            // 
            this.menuTblMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_Payment});
            this.menuTblMethods.Name = "menuTblMethods";
            resources.ApplyResources(this.menuTblMethods, "menuTblMethods");
            // 
            // menuItem_Payment
            // 
            this.menuItem_Payment.Command = this.menuTblMethods_menuPayment_Term_Discounts___;
            this.menuItem_Payment.Name = "menuItem_Payment";
            resources.ApplyResources(this.menuItem_Payment, "menuItem_Payment");
            this.menuItem_Payment.Text = "Payment Term Discounts...";
            // 
            // cbSuppressAmount
            // 
            resources.ApplyResources(this.cbSuppressAmount, "cbSuppressAmount");
            this.cbSuppressAmount.Name = "cbSuppressAmount";
            this.cbSuppressAmount.NamedProperties.Put("EnumerateMethod", "");
            this.cbSuppressAmount.NamedProperties.Put("FieldFlags", "295");
            this.cbSuppressAmount.NamedProperties.Put("LovReference", "");
            this.cbSuppressAmount.NamedProperties.Put("SqlColumn", "SUPPRESS_AMOUNT");
            // 
            // cbCashDiscFixassAcqValueDb
            // 
            resources.ApplyResources(this.cbCashDiscFixassAcqValueDb, "cbCashDiscFixassAcqValueDb");
            this.cbCashDiscFixassAcqValueDb.Name = "cbCashDiscFixassAcqValueDb";
            this.cbCashDiscFixassAcqValueDb.NamedProperties.Put("EnumerateMethod", "");
            this.cbCashDiscFixassAcqValueDb.NamedProperties.Put("FieldFlags", "294");
            this.cbCashDiscFixassAcqValueDb.NamedProperties.Put("LovReference", "");
            this.cbCashDiscFixassAcqValueDb.NamedProperties.Put("SqlColumn", "CASH_DISC_FIXASS_ACQ_VALUE_DB");
            this.cbCashDiscFixassAcqValueDb.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cbCashDiscFixassAcqValueDb_WindowActions);
            // 
            // tblPaymentTermDetails
            // 
            this.tblPaymentTermDetails.Controls.Add(this.tblPaymentTermDetails_colsCompany);
            this.tblPaymentTermDetails.Controls.Add(this.tblPaymentTermDetails_colsPayTermId);
            this.tblPaymentTermDetails.Controls.Add(this.tblPaymentTermDetails_colnInstallmentNumber);
            this.tblPaymentTermDetails.Controls.Add(this.tblPaymentTermDetails_colnDayFrom);
            this.tblPaymentTermDetails.Controls.Add(this.tblPaymentTermDetails_colnDayTo);
            this.tblPaymentTermDetails.Controls.Add(this.tblPaymentTermDetails_colnFreeDeliveryMonths);
            this.tblPaymentTermDetails.Controls.Add(this.tblPaymentTermDetails_colnDaysToDueDate);
            this.tblPaymentTermDetails.Controls.Add(this.tblPaymentTermDetails_colEndOfMonth);
            this.tblPaymentTermDetails.Controls.Add(this.tblPaymentTermDetails_colnDueDate1);
            this.tblPaymentTermDetails.Controls.Add(this.tblPaymentTermDetails_colnDueDate2);
            this.tblPaymentTermDetails.Controls.Add(this.tblPaymentTermDetails_colnDueDate3);
            this.tblPaymentTermDetails.Controls.Add(this.tblPaymentTermDetails_colnNetAmountPercentage);
            this.tblPaymentTermDetails.Controls.Add(this.tblPaymentTermDetails_colsPaymentInstitute);
            this.tblPaymentTermDetails.Controls.Add(this.tblPaymentTermDetails_colsPaymentMethod);
            this.tblPaymentTermDetails.Controls.Add(this.tblPaymentTermDetails_colsDiscountSpecified);
            this.tblPaymentTermDetails.Controls.Add(this.tblPaymentTermDetails_colnDummyInstallmentNumber);
            resources.ApplyResources(this.tblPaymentTermDetails, "tblPaymentTermDetails");
            this.tblPaymentTermDetails.Name = "tblPaymentTermDetails";
            this.tblPaymentTermDetails.NamedProperties.Put("DefaultOrderBy", "INSTALLMENT_NUMBER");
            this.tblPaymentTermDetails.NamedProperties.Put("DefaultWhere", "");
            this.tblPaymentTermDetails.NamedProperties.Put("LogicalUnit", "PaymentTermDetails");
            this.tblPaymentTermDetails.NamedProperties.Put("PackageName", "PAYMENT_TERM_DETAILS_API");
            this.tblPaymentTermDetails.NamedProperties.Put("ResizeableChildObject", "LLMM");
            this.tblPaymentTermDetails.NamedProperties.Put("ViewName", "PAYMENT_TERM_DETAILS");
            this.tblPaymentTermDetails.NamedProperties.Put("Warnings", "FALSE");
            this.tblPaymentTermDetails.DataRecordGetDefaultsEvent += new System.EventHandler<Ifs.Fnd.ApplicationForms.FndReturnEventArgsSalBoolean>(this.tblPaymentTermDetails_DataRecordGetDefaultsEvent);
            this.tblPaymentTermDetails.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblPaymentTermDetails_WindowActions);
            this.tblPaymentTermDetails.Controls.SetChildIndex(this.tblPaymentTermDetails_colnDummyInstallmentNumber, 0);
            this.tblPaymentTermDetails.Controls.SetChildIndex(this.tblPaymentTermDetails_colsDiscountSpecified, 0);
            this.tblPaymentTermDetails.Controls.SetChildIndex(this.tblPaymentTermDetails_colsPaymentMethod, 0);
            this.tblPaymentTermDetails.Controls.SetChildIndex(this.tblPaymentTermDetails_colsPaymentInstitute, 0);
            this.tblPaymentTermDetails.Controls.SetChildIndex(this.tblPaymentTermDetails_colnNetAmountPercentage, 0);
            this.tblPaymentTermDetails.Controls.SetChildIndex(this.tblPaymentTermDetails_colnDueDate3, 0);
            this.tblPaymentTermDetails.Controls.SetChildIndex(this.tblPaymentTermDetails_colnDueDate2, 0);
            this.tblPaymentTermDetails.Controls.SetChildIndex(this.tblPaymentTermDetails_colnDueDate1, 0);
            this.tblPaymentTermDetails.Controls.SetChildIndex(this.tblPaymentTermDetails_colEndOfMonth, 0);
            this.tblPaymentTermDetails.Controls.SetChildIndex(this.tblPaymentTermDetails_colnDaysToDueDate, 0);
            this.tblPaymentTermDetails.Controls.SetChildIndex(this.tblPaymentTermDetails_colnFreeDeliveryMonths, 0);
            this.tblPaymentTermDetails.Controls.SetChildIndex(this.tblPaymentTermDetails_colnDayTo, 0);
            this.tblPaymentTermDetails.Controls.SetChildIndex(this.tblPaymentTermDetails_colnDayFrom, 0);
            this.tblPaymentTermDetails.Controls.SetChildIndex(this.tblPaymentTermDetails_colnInstallmentNumber, 0);
            this.tblPaymentTermDetails.Controls.SetChildIndex(this.tblPaymentTermDetails_colsPayTermId, 0);
            this.tblPaymentTermDetails.Controls.SetChildIndex(this.tblPaymentTermDetails_colsCompany, 0);
            // 
            // tblPaymentTermDetails_colsCompany
            // 
            this.tblPaymentTermDetails_colsCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblPaymentTermDetails_colsCompany, "tblPaymentTermDetails_colsCompany");
            this.tblPaymentTermDetails_colsCompany.MaxLength = 20;
            this.tblPaymentTermDetails_colsCompany.Name = "tblPaymentTermDetails_colsCompany";
            this.tblPaymentTermDetails_colsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.tblPaymentTermDetails_colsCompany.NamedProperties.Put("FieldFlags", "67");
            this.tblPaymentTermDetails_colsCompany.NamedProperties.Put("LovReference", "");
            this.tblPaymentTermDetails_colsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.tblPaymentTermDetails_colsCompany.Position = 3;
            // 
            // tblPaymentTermDetails_colsPayTermId
            // 
            this.tblPaymentTermDetails_colsPayTermId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblPaymentTermDetails_colsPayTermId, "tblPaymentTermDetails_colsPayTermId");
            this.tblPaymentTermDetails_colsPayTermId.Name = "tblPaymentTermDetails_colsPayTermId";
            this.tblPaymentTermDetails_colsPayTermId.NamedProperties.Put("EnumerateMethod", "");
            this.tblPaymentTermDetails_colsPayTermId.NamedProperties.Put("FieldFlags", "67");
            this.tblPaymentTermDetails_colsPayTermId.NamedProperties.Put("LovReference", "PAYMENT_TERM(COMPANY)");
            this.tblPaymentTermDetails_colsPayTermId.NamedProperties.Put("SqlColumn", "PAY_TERM_ID");
            this.tblPaymentTermDetails_colsPayTermId.Position = 4;
            // 
            // tblPaymentTermDetails_colnInstallmentNumber
            // 
            this.tblPaymentTermDetails_colnInstallmentNumber.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblPaymentTermDetails_colnInstallmentNumber.Name = "tblPaymentTermDetails_colnInstallmentNumber";
            this.tblPaymentTermDetails_colnInstallmentNumber.NamedProperties.Put("EnumerateMethod", "");
            this.tblPaymentTermDetails_colnInstallmentNumber.NamedProperties.Put("FieldFlags", "163");
            this.tblPaymentTermDetails_colnInstallmentNumber.NamedProperties.Put("LovReference", "");
            this.tblPaymentTermDetails_colnInstallmentNumber.NamedProperties.Put("SqlColumn", "INSTALLMENT_NUMBER");
            this.tblPaymentTermDetails_colnInstallmentNumber.Position = 5;
            this.tblPaymentTermDetails_colnInstallmentNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblPaymentTermDetails_colnInstallmentNumber, "tblPaymentTermDetails_colnInstallmentNumber");
            this.tblPaymentTermDetails_colnInstallmentNumber.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblPaymentTermDetails_colnInstallmentNumber_WindowActions);
            // 
            // tblPaymentTermDetails_colnDayFrom
            // 
            this.tblPaymentTermDetails_colnDayFrom.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblPaymentTermDetails_colnDayFrom.Name = "tblPaymentTermDetails_colnDayFrom";
            this.tblPaymentTermDetails_colnDayFrom.NamedProperties.Put("EnumerateMethod", "");
            this.tblPaymentTermDetails_colnDayFrom.NamedProperties.Put("FieldFlags", "163");
            this.tblPaymentTermDetails_colnDayFrom.NamedProperties.Put("LovReference", "");
            this.tblPaymentTermDetails_colnDayFrom.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPaymentTermDetails_colnDayFrom.NamedProperties.Put("SqlColumn", "DAY_FROM");
            this.tblPaymentTermDetails_colnDayFrom.NamedProperties.Put("ValidateMethod", "");
            this.tblPaymentTermDetails_colnDayFrom.Position = 6;
            this.tblPaymentTermDetails_colnDayFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblPaymentTermDetails_colnDayFrom, "tblPaymentTermDetails_colnDayFrom");
            // 
            // tblPaymentTermDetails_colnDayTo
            // 
            this.tblPaymentTermDetails_colnDayTo.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblPaymentTermDetails_colnDayTo.Name = "tblPaymentTermDetails_colnDayTo";
            this.tblPaymentTermDetails_colnDayTo.NamedProperties.Put("EnumerateMethod", "");
            this.tblPaymentTermDetails_colnDayTo.NamedProperties.Put("FieldFlags", "295");
            this.tblPaymentTermDetails_colnDayTo.NamedProperties.Put("LovReference", "");
            this.tblPaymentTermDetails_colnDayTo.NamedProperties.Put("SqlColumn", "DAY_TO");
            this.tblPaymentTermDetails_colnDayTo.Position = 7;
            this.tblPaymentTermDetails_colnDayTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblPaymentTermDetails_colnDayTo, "tblPaymentTermDetails_colnDayTo");
            this.tblPaymentTermDetails_colnDayTo.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblPaymentTermDetails_colnDayTo_WindowActions);
            // 
            // tblPaymentTermDetails_colnFreeDeliveryMonths
            // 
            this.tblPaymentTermDetails_colnFreeDeliveryMonths.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblPaymentTermDetails_colnFreeDeliveryMonths.Name = "tblPaymentTermDetails_colnFreeDeliveryMonths";
            this.tblPaymentTermDetails_colnFreeDeliveryMonths.NamedProperties.Put("EnumerateMethod", "");
            this.tblPaymentTermDetails_colnFreeDeliveryMonths.NamedProperties.Put("FieldFlags", "294");
            this.tblPaymentTermDetails_colnFreeDeliveryMonths.NamedProperties.Put("LovReference", "");
            this.tblPaymentTermDetails_colnFreeDeliveryMonths.NamedProperties.Put("SqlColumn", "FREE_DELIVERY_MONTHS");
            this.tblPaymentTermDetails_colnFreeDeliveryMonths.Position = 8;
            this.tblPaymentTermDetails_colnFreeDeliveryMonths.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblPaymentTermDetails_colnFreeDeliveryMonths, "tblPaymentTermDetails_colnFreeDeliveryMonths");
            this.tblPaymentTermDetails_colnFreeDeliveryMonths.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblPaymentTermDetails_colnFreeDeliveryMonths_WindowActions);
            // 
            // tblPaymentTermDetails_colnDaysToDueDate
            // 
            this.tblPaymentTermDetails_colnDaysToDueDate.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblPaymentTermDetails_colnDaysToDueDate.Name = "tblPaymentTermDetails_colnDaysToDueDate";
            this.tblPaymentTermDetails_colnDaysToDueDate.NamedProperties.Put("EnumerateMethod", "");
            this.tblPaymentTermDetails_colnDaysToDueDate.NamedProperties.Put("FieldFlags", "295");
            this.tblPaymentTermDetails_colnDaysToDueDate.NamedProperties.Put("LovReference", "");
            this.tblPaymentTermDetails_colnDaysToDueDate.NamedProperties.Put("SqlColumn", "DAYS_TO_DUE_DATE");
            this.tblPaymentTermDetails_colnDaysToDueDate.Position = 9;
            this.tblPaymentTermDetails_colnDaysToDueDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblPaymentTermDetails_colnDaysToDueDate, "tblPaymentTermDetails_colnDaysToDueDate");
            this.tblPaymentTermDetails_colnDaysToDueDate.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblPaymentTermDetails_colnDaysToDueDate_WindowActions);
            // 
            // tblPaymentTermDetails_colEndOfMonth
            // 
            this.tblPaymentTermDetails_colEndOfMonth.MaxLength = 5;
            this.tblPaymentTermDetails_colEndOfMonth.Name = "tblPaymentTermDetails_colEndOfMonth";
            this.tblPaymentTermDetails_colEndOfMonth.NamedProperties.Put("EnumerateMethod", "");
            this.tblPaymentTermDetails_colEndOfMonth.NamedProperties.Put("FieldFlags", "262");
            this.tblPaymentTermDetails_colEndOfMonth.NamedProperties.Put("LovReference", "");
            this.tblPaymentTermDetails_colEndOfMonth.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPaymentTermDetails_colEndOfMonth.NamedProperties.Put("SqlColumn", "END_OF_MONTH");
            this.tblPaymentTermDetails_colEndOfMonth.NamedProperties.Put("ValidateMethod", "");
            this.tblPaymentTermDetails_colEndOfMonth.Position = 10;
            resources.ApplyResources(this.tblPaymentTermDetails_colEndOfMonth, "tblPaymentTermDetails_colEndOfMonth");
            // 
            // tblPaymentTermDetails_colnDueDate1
            // 
            this.tblPaymentTermDetails_colnDueDate1.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblPaymentTermDetails_colnDueDate1.Name = "tblPaymentTermDetails_colnDueDate1";
            this.tblPaymentTermDetails_colnDueDate1.NamedProperties.Put("EnumerateMethod", "");
            this.tblPaymentTermDetails_colnDueDate1.NamedProperties.Put("FieldFlags", "294");
            this.tblPaymentTermDetails_colnDueDate1.NamedProperties.Put("LovReference", "");
            this.tblPaymentTermDetails_colnDueDate1.NamedProperties.Put("SqlColumn", "DUE_DATE1");
            this.tblPaymentTermDetails_colnDueDate1.Position = 11;
            this.tblPaymentTermDetails_colnDueDate1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblPaymentTermDetails_colnDueDate1, "tblPaymentTermDetails_colnDueDate1");
            this.tblPaymentTermDetails_colnDueDate1.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblPaymentTermDetails_colnDueDate1_WindowActions);
            // 
            // tblPaymentTermDetails_colnDueDate2
            // 
            this.tblPaymentTermDetails_colnDueDate2.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblPaymentTermDetails_colnDueDate2.Name = "tblPaymentTermDetails_colnDueDate2";
            this.tblPaymentTermDetails_colnDueDate2.NamedProperties.Put("EnumerateMethod", "");
            this.tblPaymentTermDetails_colnDueDate2.NamedProperties.Put("FieldFlags", "294");
            this.tblPaymentTermDetails_colnDueDate2.NamedProperties.Put("LovReference", "");
            this.tblPaymentTermDetails_colnDueDate2.NamedProperties.Put("SqlColumn", "DUE_DATE2");
            this.tblPaymentTermDetails_colnDueDate2.Position = 12;
            this.tblPaymentTermDetails_colnDueDate2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblPaymentTermDetails_colnDueDate2, "tblPaymentTermDetails_colnDueDate2");
            this.tblPaymentTermDetails_colnDueDate2.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblPaymentTermDetails_colnDueDate2_WindowActions);
            // 
            // tblPaymentTermDetails_colnDueDate3
            // 
            this.tblPaymentTermDetails_colnDueDate3.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblPaymentTermDetails_colnDueDate3.Name = "tblPaymentTermDetails_colnDueDate3";
            this.tblPaymentTermDetails_colnDueDate3.NamedProperties.Put("EnumerateMethod", "");
            this.tblPaymentTermDetails_colnDueDate3.NamedProperties.Put("FieldFlags", "294");
            this.tblPaymentTermDetails_colnDueDate3.NamedProperties.Put("LovReference", "");
            this.tblPaymentTermDetails_colnDueDate3.NamedProperties.Put("SqlColumn", "DUE_DATE3");
            this.tblPaymentTermDetails_colnDueDate3.Position = 13;
            this.tblPaymentTermDetails_colnDueDate3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblPaymentTermDetails_colnDueDate3, "tblPaymentTermDetails_colnDueDate3");
            this.tblPaymentTermDetails_colnDueDate3.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblPaymentTermDetails_colnDueDate3_WindowActions);
            // 
            // tblPaymentTermDetails_colnNetAmountPercentage
            // 
            this.tblPaymentTermDetails_colnNetAmountPercentage.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblPaymentTermDetails_colnNetAmountPercentage.Name = "tblPaymentTermDetails_colnNetAmountPercentage";
            this.tblPaymentTermDetails_colnNetAmountPercentage.NamedProperties.Put("EnumerateMethod", "");
            this.tblPaymentTermDetails_colnNetAmountPercentage.NamedProperties.Put("FieldFlags", "294");
            this.tblPaymentTermDetails_colnNetAmountPercentage.NamedProperties.Put("LovReference", "");
            this.tblPaymentTermDetails_colnNetAmountPercentage.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPaymentTermDetails_colnNetAmountPercentage.NamedProperties.Put("SqlColumn", "NET_AMOUNT_PERCENTAGE");
            this.tblPaymentTermDetails_colnNetAmountPercentage.NamedProperties.Put("ValidateMethod", "");
            this.tblPaymentTermDetails_colnNetAmountPercentage.Position = 14;
            this.tblPaymentTermDetails_colnNetAmountPercentage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblPaymentTermDetails_colnNetAmountPercentage, "tblPaymentTermDetails_colnNetAmountPercentage");
            this.tblPaymentTermDetails_colnNetAmountPercentage.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblPaymentTermDetails_colnNetAmountPercentage_WindowActions);
            // 
            // tblPaymentTermDetails_colsPaymentInstitute
            // 
            this.tblPaymentTermDetails_colsPaymentInstitute.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblPaymentTermDetails_colsPaymentInstitute.MaxLength = 20;
            this.tblPaymentTermDetails_colsPaymentInstitute.Name = "tblPaymentTermDetails_colsPaymentInstitute";
            this.tblPaymentTermDetails_colsPaymentInstitute.NamedProperties.Put("EnumerateMethod", "");
            this.tblPaymentTermDetails_colsPaymentInstitute.NamedProperties.Put("FieldFlags", "294");
            this.tblPaymentTermDetails_colsPaymentInstitute.NamedProperties.Put("LovReference", "");
            this.tblPaymentTermDetails_colsPaymentInstitute.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPaymentTermDetails_colsPaymentInstitute.NamedProperties.Put("SqlColumn", "INSTITUTE_ID");
            this.tblPaymentTermDetails_colsPaymentInstitute.NamedProperties.Put("ValidateMethod", "");
            this.tblPaymentTermDetails_colsPaymentInstitute.Position = 15;
            resources.ApplyResources(this.tblPaymentTermDetails_colsPaymentInstitute, "tblPaymentTermDetails_colsPaymentInstitute");
            this.tblPaymentTermDetails_colsPaymentInstitute.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblPaymentTermDetails_colsPaymentInstitute_WindowActions);
            // 
            // tblPaymentTermDetails_colsPaymentMethod
            // 
            this.tblPaymentTermDetails_colsPaymentMethod.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblPaymentTermDetails_colsPaymentMethod.MaxLength = 20;
            this.tblPaymentTermDetails_colsPaymentMethod.Name = "tblPaymentTermDetails_colsPaymentMethod";
            this.tblPaymentTermDetails_colsPaymentMethod.NamedProperties.Put("EnumerateMethod", "");
            this.tblPaymentTermDetails_colsPaymentMethod.NamedProperties.Put("FieldFlags", "294");
            this.tblPaymentTermDetails_colsPaymentMethod.NamedProperties.Put("LovReference", "");
            this.tblPaymentTermDetails_colsPaymentMethod.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPaymentTermDetails_colsPaymentMethod.NamedProperties.Put("SqlColumn", "WAY_ID");
            this.tblPaymentTermDetails_colsPaymentMethod.NamedProperties.Put("ValidateMethod", "");
            this.tblPaymentTermDetails_colsPaymentMethod.Position = 16;
            resources.ApplyResources(this.tblPaymentTermDetails_colsPaymentMethod, "tblPaymentTermDetails_colsPaymentMethod");
            this.tblPaymentTermDetails_colsPaymentMethod.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblPaymentTermDetails_colsPaymentMethod_WindowActions);
            // 
            // tblPaymentTermDetails_colsDiscountSpecified
            // 
            resources.ApplyResources(this.tblPaymentTermDetails_colsDiscountSpecified, "tblPaymentTermDetails_colsDiscountSpecified");
            this.tblPaymentTermDetails_colsDiscountSpecified.MaxLength = 5;
            this.tblPaymentTermDetails_colsDiscountSpecified.Name = "tblPaymentTermDetails_colsDiscountSpecified";
            this.tblPaymentTermDetails_colsDiscountSpecified.NamedProperties.Put("EnumerateMethod", "");
            this.tblPaymentTermDetails_colsDiscountSpecified.NamedProperties.Put("FieldFlags", "290");
            this.tblPaymentTermDetails_colsDiscountSpecified.NamedProperties.Put("LovReference", "");
            this.tblPaymentTermDetails_colsDiscountSpecified.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPaymentTermDetails_colsDiscountSpecified.NamedProperties.Put("SqlColumn", "DISCOUNT_SPECIFIED");
            this.tblPaymentTermDetails_colsDiscountSpecified.NamedProperties.Put("ValidateMethod", "");
            this.tblPaymentTermDetails_colsDiscountSpecified.Position = 17;
            // 
            // tblPaymentTermDetails_colnDummyInstallmentNumber
            // 
            this.tblPaymentTermDetails_colnDummyInstallmentNumber.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.tblPaymentTermDetails_colnDummyInstallmentNumber, "tblPaymentTermDetails_colnDummyInstallmentNumber");
            this.tblPaymentTermDetails_colnDummyInstallmentNumber.Name = "tblPaymentTermDetails_colnDummyInstallmentNumber";
            this.tblPaymentTermDetails_colnDummyInstallmentNumber.Position = 18;
            // 
            // frmPaymentTermDetails
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.cbSuppressAmount);
            this.Controls.Add(this.tblPaymentTermDetails);
            this.Controls.Add(this.cbExcludeCreditLimit);
            this.Controls.Add(this.cbConsiderPayVacPeriod);
            this.Controls.Add(this.cbCashDiscFixassAcqValueDb);
            this.Controls.Add(this.cbUseCommercialYear);
            this.Controls.Add(this.cbBlockForDirectDebiting);
            this.Controls.Add(this.cmbVatDistribution);
            this.Controls.Add(this.dfsDescription);
            this.Controls.Add(this.cmbPayTermId);
            this.Controls.Add(this.dfsCompany);
            this.Controls.Add(this.labelcmbVatDistribution);
            this.Controls.Add(this.labeldfsDescription);
            this.Controls.Add(this.labelcmbPayTermId);
            this.Controls.Add(this.labeldfsCompany);
            this.MaximizeBox = true;
            this.Name = "frmPaymentTermDetails";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "COMPANY= :i_hWndFrame.frmPaymentTermDetails.i_sCompany");
            this.NamedProperties.Put("LogicalUnit", "PaymentTerm");
            this.NamedProperties.Put("PackageName", "PAYMENT_TERM_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("ViewName", "PAYMENT_TERM");
            this.NamedProperties.Put("Warnings", "TRUE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.frmPaymentTermDetails_WindowActions);
            this.menuFrmMethods.ResumeLayout(false);
            this.menuTblMethods.ResumeLayout(false);
            this.tblPaymentTermDetails.ResumeLayout(false);
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
		
		public Fnd.Windows.Forms.FndCommand menuTblMethods_menuPayment_Term_Discounts___;
        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menuAutomatic_Installment_Plan___;
        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menuChange__Company___;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuFrmMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Automatic;
        protected Fnd.Windows.Forms.FndToolStripSeparator menuSeparator1;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTblMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Payment;
        protected cCheckBox cbSuppressAmount;
        protected cCheckBox cbCashDiscFixassAcqValueDb;
        public cChildTableFinBase tblPaymentTermDetails;
        protected cColumn tblPaymentTermDetails_colsCompany;
        protected cColumn tblPaymentTermDetails_colsPayTermId;
        protected cColumn tblPaymentTermDetails_colnInstallmentNumber;
        protected cColumn tblPaymentTermDetails_colnDayFrom;
        protected cColumn tblPaymentTermDetails_colnDayTo;
        protected cColumn tblPaymentTermDetails_colnFreeDeliveryMonths;
        protected cColumn tblPaymentTermDetails_colnDaysToDueDate;
        protected cCheckBoxColumn tblPaymentTermDetails_colEndOfMonth;
        protected cColumn tblPaymentTermDetails_colnDueDate1;
        protected cColumn tblPaymentTermDetails_colnDueDate2;
        protected cColumn tblPaymentTermDetails_colnDueDate3;
        protected cColumn tblPaymentTermDetails_colnNetAmountPercentage;
        protected cColumn tblPaymentTermDetails_colsPaymentInstitute;
        protected cColumn tblPaymentTermDetails_colsPaymentMethod;
        protected cCheckBoxColumn tblPaymentTermDetails_colsDiscountSpecified;
        protected cColumn tblPaymentTermDetails_colnDummyInstallmentNumber;
	}
}
