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
	
	public partial class frmTaxLiabilityDateCtrl
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		protected cBackgroundText labeldfsCompany;
		public cDataField dfsCompany;
		protected cBackgroundText labelcmbCustomerLiabilityDate;
		// Bug 68778 Modified enumerate method from Enumerate to Enumerate1
		public cComboBox cmbCustomerLiabilityDate;
		protected cBackgroundText labelcmbSupplierLiabilityDate;
		// Bug 68778 Modified enumerate method from Enumerate to Enumerate3
		public cComboBox cmbSupplierLiabilityDate;
		protected cBackgroundText labelcmbPaymentsLiabilityDate;
		// Bug 68778 Modified enumerate method from Enumerate to Enumerate2
		public cComboBox cmbPaymentsLiabilityDate;
        protected cBackgroundText labeltblTaxLiabilityDateException;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTaxLiabilityDateCtrl));
            this.menuFrmMethods_menuChange__Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.labeldfsCompany = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsCompany = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelcmbCustomerLiabilityDate = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbCustomerLiabilityDate = new Ifs.Fnd.ApplicationForms.cComboBox();
            this.labelcmbSupplierLiabilityDate = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbSupplierLiabilityDate = new Ifs.Fnd.ApplicationForms.cComboBox();
            this.labelcmbPaymentsLiabilityDate = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbPaymentsLiabilityDate = new Ifs.Fnd.ApplicationForms.cComboBox();
            this.labeltblTaxLiabilityDateException = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.menuFrmMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_Change = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.tblTaxLiabilityDateException = new Ifs.Application.Accrul.cChildTableFin();
            this.tblTaxLiabilityDateException_colsCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblTaxLiabilityDateException_colsFeeCode = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblTaxLiabilityDateException_colStatutoryFeeDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblTaxLiabilityDateException_colStatutoryFeeRate = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblTaxLiabilityDateException_colsCustomerLiabilityDate = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.tblTaxLiabilityDateException_colsCustomerCrdtLiabltyDate = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.tblTaxLiabilityDateException_colsSupplierLiabilityDate = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.tblTaxLiabilityDateException_colStatutoryFeeVatDisbursedDb = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblTaxLiabilityDateException_colStatutoryFeeVatReceivedDb = new Ifs.Fnd.ApplicationForms.cColumn();
            this.menuFrmMethods.SuspendLayout();
            this.tblTaxLiabilityDateException.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuFrmMethods_menuChange__Company___);
            this.commandManager.ContextMenus.Add(this.menuFrmMethods);
            this.commandManager.ImageList = null;
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
            this.dfsCompany.NamedProperties.Put("FieldFlags", "131");
            this.dfsCompany.NamedProperties.Put("LovReference", "COMPANY_FINANCE");
            this.dfsCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.dfsCompany.NamedProperties.Put("ValidateMethod", "");
            // 
            // labelcmbCustomerLiabilityDate
            // 
            resources.ApplyResources(this.labelcmbCustomerLiabilityDate, "labelcmbCustomerLiabilityDate");
            this.labelcmbCustomerLiabilityDate.Name = "labelcmbCustomerLiabilityDate";
            // 
            // cmbCustomerLiabilityDate
            // 
            this.cmbCustomerLiabilityDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cmbCustomerLiabilityDate, "cmbCustomerLiabilityDate");
            this.cmbCustomerLiabilityDate.Name = "cmbCustomerLiabilityDate";
            this.cmbCustomerLiabilityDate.NamedProperties.Put("EnumerateMethod", "TAX_LIABILITY_DATE_API.Enumerate1");
            this.cmbCustomerLiabilityDate.NamedProperties.Put("FieldFlags", "263");
            this.cmbCustomerLiabilityDate.NamedProperties.Put("LovReference", "");
            this.cmbCustomerLiabilityDate.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbCustomerLiabilityDate.NamedProperties.Put("SqlColumn", "CUSTOMER_LIABILITY_DATE");
            this.cmbCustomerLiabilityDate.NamedProperties.Put("ValidateMethod", "");
            // 
            // labelcmbSupplierLiabilityDate
            // 
            resources.ApplyResources(this.labelcmbSupplierLiabilityDate, "labelcmbSupplierLiabilityDate");
            this.labelcmbSupplierLiabilityDate.Name = "labelcmbSupplierLiabilityDate";
            // 
            // cmbSupplierLiabilityDate
            // 
            this.cmbSupplierLiabilityDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cmbSupplierLiabilityDate, "cmbSupplierLiabilityDate");
            this.cmbSupplierLiabilityDate.Name = "cmbSupplierLiabilityDate";
            this.cmbSupplierLiabilityDate.NamedProperties.Put("EnumerateMethod", "TAX_LIABILITY_DATE_API.Enumerate3");
            this.cmbSupplierLiabilityDate.NamedProperties.Put("FieldFlags", "263");
            this.cmbSupplierLiabilityDate.NamedProperties.Put("LovReference", "");
            this.cmbSupplierLiabilityDate.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbSupplierLiabilityDate.NamedProperties.Put("SqlColumn", "SUPPLIER_LIABILITY_DATE");
            this.cmbSupplierLiabilityDate.NamedProperties.Put("ValidateMethod", "");
            // 
            // labelcmbPaymentsLiabilityDate
            // 
            resources.ApplyResources(this.labelcmbPaymentsLiabilityDate, "labelcmbPaymentsLiabilityDate");
            this.labelcmbPaymentsLiabilityDate.Name = "labelcmbPaymentsLiabilityDate";
            // 
            // cmbPaymentsLiabilityDate
            // 
            this.cmbPaymentsLiabilityDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cmbPaymentsLiabilityDate, "cmbPaymentsLiabilityDate");
            this.cmbPaymentsLiabilityDate.Name = "cmbPaymentsLiabilityDate";
            this.cmbPaymentsLiabilityDate.NamedProperties.Put("EnumerateMethod", "TAX_LIABILITY_DATE_API.Enumerate2");
            this.cmbPaymentsLiabilityDate.NamedProperties.Put("FieldFlags", "263");
            this.cmbPaymentsLiabilityDate.NamedProperties.Put("LovReference", "");
            this.cmbPaymentsLiabilityDate.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbPaymentsLiabilityDate.NamedProperties.Put("SqlColumn", "PAYMENTS_LIABILITY_DATE");
            this.cmbPaymentsLiabilityDate.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeltblTaxLiabilityDateException
            // 
            resources.ApplyResources(this.labeltblTaxLiabilityDateException, "labeltblTaxLiabilityDateException");
            this.labeltblTaxLiabilityDateException.Name = "labeltblTaxLiabilityDateException";
            // 
            // menuFrmMethods
            // 
            this.menuFrmMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_Change});
            this.menuFrmMethods.Name = "menuFrmMethods";
            resources.ApplyResources(this.menuFrmMethods, "menuFrmMethods");
            // 
            // menuItem_Change
            // 
            this.menuItem_Change.Command = this.menuFrmMethods_menuChange__Company___;
            this.menuItem_Change.Name = "menuItem_Change";
            resources.ApplyResources(this.menuItem_Change, "menuItem_Change");
            this.menuItem_Change.Text = "Change &Company...";
            // 
            // tblTaxLiabilityDateException
            // 
            this.tblTaxLiabilityDateException.Controls.Add(this.tblTaxLiabilityDateException_colsCompany);
            this.tblTaxLiabilityDateException.Controls.Add(this.tblTaxLiabilityDateException_colsFeeCode);
            this.tblTaxLiabilityDateException.Controls.Add(this.tblTaxLiabilityDateException_colStatutoryFeeDescription);
            this.tblTaxLiabilityDateException.Controls.Add(this.tblTaxLiabilityDateException_colStatutoryFeeRate);
            this.tblTaxLiabilityDateException.Controls.Add(this.tblTaxLiabilityDateException_colsCustomerLiabilityDate);
            this.tblTaxLiabilityDateException.Controls.Add(this.tblTaxLiabilityDateException_colsCustomerCrdtLiabltyDate);
            this.tblTaxLiabilityDateException.Controls.Add(this.tblTaxLiabilityDateException_colsSupplierLiabilityDate);
            this.tblTaxLiabilityDateException.Controls.Add(this.tblTaxLiabilityDateException_colStatutoryFeeVatDisbursedDb);
            this.tblTaxLiabilityDateException.Controls.Add(this.tblTaxLiabilityDateException_colStatutoryFeeVatReceivedDb);
            resources.ApplyResources(this.tblTaxLiabilityDateException, "tblTaxLiabilityDateException");
            this.tblTaxLiabilityDateException.Name = "tblTaxLiabilityDateException";
            this.tblTaxLiabilityDateException.NamedProperties.Put("DefaultOrderBy", "");
            this.tblTaxLiabilityDateException.NamedProperties.Put("DefaultWhere", "");
            this.tblTaxLiabilityDateException.NamedProperties.Put("LogicalUnit", "TaxLiabltyDateException");
            this.tblTaxLiabilityDateException.NamedProperties.Put("PackageName", "TAX_LIABLTY_DATE_EXCEPTION_API");
            this.tblTaxLiabilityDateException.NamedProperties.Put("ResizeableChildObject", "LLFF");
            this.tblTaxLiabilityDateException.NamedProperties.Put("ViewName", "TAX_LIABLTY_DATE_EXCEPTION");
            this.tblTaxLiabilityDateException.NamedProperties.Put("Warnings", "FALSE");
            this.tblTaxLiabilityDateException.Controls.SetChildIndex(this.tblTaxLiabilityDateException_colStatutoryFeeVatReceivedDb, 0);
            this.tblTaxLiabilityDateException.Controls.SetChildIndex(this.tblTaxLiabilityDateException_colStatutoryFeeVatDisbursedDb, 0);
            this.tblTaxLiabilityDateException.Controls.SetChildIndex(this.tblTaxLiabilityDateException_colsSupplierLiabilityDate, 0);
            this.tblTaxLiabilityDateException.Controls.SetChildIndex(this.tblTaxLiabilityDateException_colsCustomerCrdtLiabltyDate, 0);
            this.tblTaxLiabilityDateException.Controls.SetChildIndex(this.tblTaxLiabilityDateException_colsCustomerLiabilityDate, 0);
            this.tblTaxLiabilityDateException.Controls.SetChildIndex(this.tblTaxLiabilityDateException_colStatutoryFeeRate, 0);
            this.tblTaxLiabilityDateException.Controls.SetChildIndex(this.tblTaxLiabilityDateException_colStatutoryFeeDescription, 0);
            this.tblTaxLiabilityDateException.Controls.SetChildIndex(this.tblTaxLiabilityDateException_colsFeeCode, 0);
            this.tblTaxLiabilityDateException.Controls.SetChildIndex(this.tblTaxLiabilityDateException_colsCompany, 0);
            // 
            // tblTaxLiabilityDateException_colsCompany
            // 
            this.tblTaxLiabilityDateException_colsCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblTaxLiabilityDateException_colsCompany, "tblTaxLiabilityDateException_colsCompany");
            this.tblTaxLiabilityDateException_colsCompany.MaxLength = 20;
            this.tblTaxLiabilityDateException_colsCompany.Name = "tblTaxLiabilityDateException_colsCompany";
            this.tblTaxLiabilityDateException_colsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.tblTaxLiabilityDateException_colsCompany.NamedProperties.Put("FieldFlags", "67");
            this.tblTaxLiabilityDateException_colsCompany.NamedProperties.Put("LovReference", "COMPANY_FINANCE");
            this.tblTaxLiabilityDateException_colsCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.tblTaxLiabilityDateException_colsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.tblTaxLiabilityDateException_colsCompany.NamedProperties.Put("ValidateMethod", "");
            this.tblTaxLiabilityDateException_colsCompany.Position = 3;
            // 
            // tblTaxLiabilityDateException_colsFeeCode
            // 
            this.tblTaxLiabilityDateException_colsFeeCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblTaxLiabilityDateException_colsFeeCode.MaxLength = 20;
            this.tblTaxLiabilityDateException_colsFeeCode.Name = "tblTaxLiabilityDateException_colsFeeCode";
            this.tblTaxLiabilityDateException_colsFeeCode.NamedProperties.Put("EnumerateMethod", "");
            this.tblTaxLiabilityDateException_colsFeeCode.NamedProperties.Put("FieldFlags", "163");
            this.tblTaxLiabilityDateException_colsFeeCode.NamedProperties.Put("LovReference", "STATUTORY_FEE_DEDUCT_MULTIPLE(COMPANY)");
            this.tblTaxLiabilityDateException_colsFeeCode.NamedProperties.Put("ResizeableChildObject", "");
            this.tblTaxLiabilityDateException_colsFeeCode.NamedProperties.Put("SqlColumn", "FEE_CODE");
            this.tblTaxLiabilityDateException_colsFeeCode.NamedProperties.Put("ValidateMethod", "");
            this.tblTaxLiabilityDateException_colsFeeCode.Position = 4;
            resources.ApplyResources(this.tblTaxLiabilityDateException_colsFeeCode, "tblTaxLiabilityDateException_colsFeeCode");
            this.tblTaxLiabilityDateException_colsFeeCode.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblTaxLiabilityDateException_colsFeeCode_WindowActions);
            // 
            // tblTaxLiabilityDateException_colStatutoryFeeDescription
            // 
            this.tblTaxLiabilityDateException_colStatutoryFeeDescription.MaxLength = 2000;
            this.tblTaxLiabilityDateException_colStatutoryFeeDescription.Name = "tblTaxLiabilityDateException_colStatutoryFeeDescription";
            this.tblTaxLiabilityDateException_colStatutoryFeeDescription.NamedProperties.Put("EnumerateMethod", "");
            this.tblTaxLiabilityDateException_colStatutoryFeeDescription.NamedProperties.Put("FieldFlags", "304");
            this.tblTaxLiabilityDateException_colStatutoryFeeDescription.NamedProperties.Put("LovReference", "");
            this.tblTaxLiabilityDateException_colStatutoryFeeDescription.NamedProperties.Put("ParentName", "tblTaxLiabilityDateException.tblTaxLiabilityDateException_colsFeeCode");
            this.tblTaxLiabilityDateException_colStatutoryFeeDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.tblTaxLiabilityDateException_colStatutoryFeeDescription.NamedProperties.Put("SqlColumn", "STATUTORY_FEE_API.Get_Description(company,FEE_CODE)");
            this.tblTaxLiabilityDateException_colStatutoryFeeDescription.NamedProperties.Put("ValidateMethod", "");
            this.tblTaxLiabilityDateException_colStatutoryFeeDescription.Position = 5;
            resources.ApplyResources(this.tblTaxLiabilityDateException_colStatutoryFeeDescription, "tblTaxLiabilityDateException_colStatutoryFeeDescription");
            // 
            // tblTaxLiabilityDateException_colStatutoryFeeRate
            // 
            this.tblTaxLiabilityDateException_colStatutoryFeeRate.MaxLength = 2000;
            this.tblTaxLiabilityDateException_colStatutoryFeeRate.Name = "tblTaxLiabilityDateException_colStatutoryFeeRate";
            this.tblTaxLiabilityDateException_colStatutoryFeeRate.NamedProperties.Put("EnumerateMethod", "");
            this.tblTaxLiabilityDateException_colStatutoryFeeRate.NamedProperties.Put("FieldFlags", "304");
            this.tblTaxLiabilityDateException_colStatutoryFeeRate.NamedProperties.Put("LovReference", "");
            this.tblTaxLiabilityDateException_colStatutoryFeeRate.NamedProperties.Put("ParentName", "tblTaxLiabilityDateException.tblTaxLiabilityDateException_colsFeeCode");
            this.tblTaxLiabilityDateException_colStatutoryFeeRate.NamedProperties.Put("ResizeableChildObject", "");
            this.tblTaxLiabilityDateException_colStatutoryFeeRate.NamedProperties.Put("SqlColumn", "STATUTORY_FEE_API.Get_Order_Fee_Rate(company,FEE_CODE)");
            this.tblTaxLiabilityDateException_colStatutoryFeeRate.NamedProperties.Put("ValidateMethod", "");
            this.tblTaxLiabilityDateException_colStatutoryFeeRate.Position = 6;
            this.tblTaxLiabilityDateException_colStatutoryFeeRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblTaxLiabilityDateException_colStatutoryFeeRate, "tblTaxLiabilityDateException_colStatutoryFeeRate");
            // 
            // tblTaxLiabilityDateException_colsCustomerLiabilityDate
            // 
            this.tblTaxLiabilityDateException_colsCustomerLiabilityDate.MaxLength = 200;
            this.tblTaxLiabilityDateException_colsCustomerLiabilityDate.Name = "tblTaxLiabilityDateException_colsCustomerLiabilityDate";
            this.tblTaxLiabilityDateException_colsCustomerLiabilityDate.NamedProperties.Put("EnumerateMethod", "TAX_LIABILITY_DATE_API.Enumerate");
            this.tblTaxLiabilityDateException_colsCustomerLiabilityDate.NamedProperties.Put("FieldFlags", "295");
            this.tblTaxLiabilityDateException_colsCustomerLiabilityDate.NamedProperties.Put("LovReference", "");
            this.tblTaxLiabilityDateException_colsCustomerLiabilityDate.NamedProperties.Put("SqlColumn", "CUSTOMER_LIABILITY_DATE");
            this.tblTaxLiabilityDateException_colsCustomerLiabilityDate.Position = 7;
            resources.ApplyResources(this.tblTaxLiabilityDateException_colsCustomerLiabilityDate, "tblTaxLiabilityDateException_colsCustomerLiabilityDate");
            this.tblTaxLiabilityDateException_colsCustomerLiabilityDate.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblTaxLiabilityDateException_colsCustomerLiabilityDate_WindowActions);
            // 
            // tblTaxLiabilityDateException_colsCustomerCrdtLiabltyDate
            // 
            this.tblTaxLiabilityDateException_colsCustomerCrdtLiabltyDate.MaxLength = 200;
            this.tblTaxLiabilityDateException_colsCustomerCrdtLiabltyDate.Name = "tblTaxLiabilityDateException_colsCustomerCrdtLiabltyDate";
            this.tblTaxLiabilityDateException_colsCustomerCrdtLiabltyDate.NamedProperties.Put("EnumerateMethod", "TAX_LIABILITY_DATE_API.Enumerate");
            this.tblTaxLiabilityDateException_colsCustomerCrdtLiabltyDate.NamedProperties.Put("FieldFlags", "295");
            this.tblTaxLiabilityDateException_colsCustomerCrdtLiabltyDate.NamedProperties.Put("LovReference", "");
            this.tblTaxLiabilityDateException_colsCustomerCrdtLiabltyDate.NamedProperties.Put("SqlColumn", "CUSTOMER_CRDT_LIABLTY_DATE");
            this.tblTaxLiabilityDateException_colsCustomerCrdtLiabltyDate.Position = 8;
            resources.ApplyResources(this.tblTaxLiabilityDateException_colsCustomerCrdtLiabltyDate, "tblTaxLiabilityDateException_colsCustomerCrdtLiabltyDate");
            this.tblTaxLiabilityDateException_colsCustomerCrdtLiabltyDate.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblTaxLiabilityDateException_colsCustomerCrdtLiabltyDate_WindowActions);
            // 
            // tblTaxLiabilityDateException_colsSupplierLiabilityDate
            // 
            this.tblTaxLiabilityDateException_colsSupplierLiabilityDate.MaxLength = 200;
            this.tblTaxLiabilityDateException_colsSupplierLiabilityDate.Name = "tblTaxLiabilityDateException_colsSupplierLiabilityDate";
            this.tblTaxLiabilityDateException_colsSupplierLiabilityDate.NamedProperties.Put("EnumerateMethod", "TAX_LIABILITY_DATE_API.Enumerate");
            this.tblTaxLiabilityDateException_colsSupplierLiabilityDate.NamedProperties.Put("FieldFlags", "295");
            this.tblTaxLiabilityDateException_colsSupplierLiabilityDate.NamedProperties.Put("LovReference", "");
            this.tblTaxLiabilityDateException_colsSupplierLiabilityDate.NamedProperties.Put("SqlColumn", "SUPPLIER_LIABILITY_DATE");
            this.tblTaxLiabilityDateException_colsSupplierLiabilityDate.Position = 9;
            resources.ApplyResources(this.tblTaxLiabilityDateException_colsSupplierLiabilityDate, "tblTaxLiabilityDateException_colsSupplierLiabilityDate");
            this.tblTaxLiabilityDateException_colsSupplierLiabilityDate.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblTaxLiabilityDateException_colsSupplierLiabilityDate_WindowActions);
            // 
            // tblTaxLiabilityDateException_colStatutoryFeeVatDisbursedDb
            // 
            this.tblTaxLiabilityDateException_colStatutoryFeeVatDisbursedDb.MaxLength = 2000;
            this.tblTaxLiabilityDateException_colStatutoryFeeVatDisbursedDb.Name = "tblTaxLiabilityDateException_colStatutoryFeeVatDisbursedDb";
            this.tblTaxLiabilityDateException_colStatutoryFeeVatDisbursedDb.NamedProperties.Put("EnumerateMethod", "");
            this.tblTaxLiabilityDateException_colStatutoryFeeVatDisbursedDb.NamedProperties.Put("FieldFlags", "304");
            this.tblTaxLiabilityDateException_colStatutoryFeeVatDisbursedDb.NamedProperties.Put("LovReference", "");
            this.tblTaxLiabilityDateException_colStatutoryFeeVatDisbursedDb.NamedProperties.Put("ParentName", "tblTaxLiabilityDateException.tblTaxLiabilityDateException_colsFeeCode");
            this.tblTaxLiabilityDateException_colStatutoryFeeVatDisbursedDb.NamedProperties.Put("ResizeableChildObject", "");
            this.tblTaxLiabilityDateException_colStatutoryFeeVatDisbursedDb.NamedProperties.Put("SqlColumn", "STATUTORY_FEE_API.Get_Vat_Disbursed(company,FEE_CODE)");
            this.tblTaxLiabilityDateException_colStatutoryFeeVatDisbursedDb.NamedProperties.Put("ValidateMethod", "");
            this.tblTaxLiabilityDateException_colStatutoryFeeVatDisbursedDb.Position = 10;
            resources.ApplyResources(this.tblTaxLiabilityDateException_colStatutoryFeeVatDisbursedDb, "tblTaxLiabilityDateException_colStatutoryFeeVatDisbursedDb");
            // 
            // tblTaxLiabilityDateException_colStatutoryFeeVatReceivedDb
            // 
            this.tblTaxLiabilityDateException_colStatutoryFeeVatReceivedDb.MaxLength = 2000;
            this.tblTaxLiabilityDateException_colStatutoryFeeVatReceivedDb.Name = "tblTaxLiabilityDateException_colStatutoryFeeVatReceivedDb";
            this.tblTaxLiabilityDateException_colStatutoryFeeVatReceivedDb.NamedProperties.Put("EnumerateMethod", "");
            this.tblTaxLiabilityDateException_colStatutoryFeeVatReceivedDb.NamedProperties.Put("FieldFlags", "304");
            this.tblTaxLiabilityDateException_colStatutoryFeeVatReceivedDb.NamedProperties.Put("LovReference", "");
            this.tblTaxLiabilityDateException_colStatutoryFeeVatReceivedDb.NamedProperties.Put("ParentName", "tblTaxLiabilityDateException.tblTaxLiabilityDateException_colsFeeCode");
            this.tblTaxLiabilityDateException_colStatutoryFeeVatReceivedDb.NamedProperties.Put("ResizeableChildObject", "");
            this.tblTaxLiabilityDateException_colStatutoryFeeVatReceivedDb.NamedProperties.Put("SqlColumn", "STATUTORY_FEE_API.Get_Vat_Received(company,FEE_CODE)");
            this.tblTaxLiabilityDateException_colStatutoryFeeVatReceivedDb.NamedProperties.Put("ValidateMethod", "");
            this.tblTaxLiabilityDateException_colStatutoryFeeVatReceivedDb.Position = 11;
            resources.ApplyResources(this.tblTaxLiabilityDateException_colStatutoryFeeVatReceivedDb, "tblTaxLiabilityDateException_colStatutoryFeeVatReceivedDb");
            // 
            // frmTaxLiabilityDateCtrl
            // 
            this.AutoScaleBaseDpi = new System.Drawing.Size(106, 106);
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.cmbPaymentsLiabilityDate);
            this.Controls.Add(this.tblTaxLiabilityDateException);
            this.Controls.Add(this.cmbSupplierLiabilityDate);
            this.Controls.Add(this.cmbCustomerLiabilityDate);
            this.Controls.Add(this.dfsCompany);
            this.Controls.Add(this.labeltblTaxLiabilityDateException);
            this.Controls.Add(this.labelcmbPaymentsLiabilityDate);
            this.Controls.Add(this.labelcmbSupplierLiabilityDate);
            this.Controls.Add(this.labelcmbCustomerLiabilityDate);
            this.Controls.Add(this.labeldfsCompany);
            this.MaximizeBox = true;
            this.Name = "frmTaxLiabilityDateCtrl";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "COMPANY = :i_hWndFrame.frmTaxLiabilityDateCtrl.i_sCompany");
            this.NamedProperties.Put("LogicalUnit", "TaxLiabilityDateCtrl");
            this.NamedProperties.Put("PackageName", "TAX_LIABILITY_DATE_CTRL_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "193");
            this.NamedProperties.Put("ViewName", "TAX_LIABILITY_DATE_CTRL");
            this.NamedProperties.Put("Warnings", "TRUE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.frmTaxLiabilityDateCtrl_WindowActions);
            this.menuFrmMethods.ResumeLayout(false);
            this.tblTaxLiabilityDateException.ResumeLayout(false);
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
		
        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menuChange__Company___;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuFrmMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change;
        public cChildTableFin tblTaxLiabilityDateException;
        protected cColumn tblTaxLiabilityDateException_colsCompany;
        protected cColumn tblTaxLiabilityDateException_colsFeeCode;
        protected cColumn tblTaxLiabilityDateException_colStatutoryFeeDescription;
        protected cColumn tblTaxLiabilityDateException_colStatutoryFeeRate;
        protected cLookupColumn tblTaxLiabilityDateException_colsCustomerLiabilityDate;
        protected cLookupColumn tblTaxLiabilityDateException_colsCustomerCrdtLiabltyDate;
        protected cLookupColumn tblTaxLiabilityDateException_colsSupplierLiabilityDate;
        protected cColumn tblTaxLiabilityDateException_colStatutoryFeeVatDisbursedDb;
        protected cColumn tblTaxLiabilityDateException_colStatutoryFeeVatReceivedDb;
	}
}
