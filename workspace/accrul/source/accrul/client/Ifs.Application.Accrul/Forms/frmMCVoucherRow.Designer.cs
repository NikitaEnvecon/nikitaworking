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
	
	public partial class frmMCVoucherRow
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		protected cBackgroundText labeldfsCodePartValue;
		public cDataFieldFinContent dfsCodePartValue;
		protected cBackgroundText labeldfsCodePartDescription;
		public cDataFieldFinDescription dfsCodePartDescription;
		protected cBackgroundText labelcmbsVoucherCompany;
		public SalComboBox cmbsVoucherCompany;
		protected cBackgroundText labeldfsVCCurrency;
		public cDataField dfsVCCurrency;
		protected cBackgroundText labeldfnCurrencyBalance;
		public cDataField dfnCurrencyBalance;
		protected cBackgroundText labeldfnBalance;
        public cDataField dfnBalance;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMCVoucherRow));
            this.labeldfsCodePartValue = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsCodePartValue = new Ifs.Application.Accrul.cDataFieldFinContent();
            this.labeldfsCodePartDescription = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsCodePartDescription = new Ifs.Application.Accrul.cDataFieldFinDescription();
            this.labelcmbsVoucherCompany = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbsVoucherCompany = new PPJ.Runtime.Windows.SalComboBox();
            this.labeldfsVCCurrency = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsVCCurrency = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfnCurrencyBalance = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfnCurrencyBalance = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfnBalance = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfnBalance = new Ifs.Fnd.ApplicationForms.cDataField();
            this.tblVoucherRow = new Ifs.Application.Accrul.cChildTableFin();
            this.tblVoucherRow_colsParentCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherRow_colsVoucherType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherRow_colnAccountingYear = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherRow_colnAccountingPeriod = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherRow_colnVoucherNo = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherRow_colsCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherRow_colnRowGroupId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherRow_colsAccount = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.tblVoucherRow_colsAccountDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.tblVoucherRow_colsCodeB = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.tblVoucherRow_colsCodeBDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.tblVoucherRow_colsCodeC = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.tblVoucherRow_colsCodeCDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.tblVoucherRow_colsCodeD = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.tblVoucherRow_colsCodeDDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.tblVoucherRow_colsCodeE = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.tblVoucherRow_colsCodeEDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.tblVoucherRow_colsCodeF = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.tblVoucherRow_colsCodeFDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.tblVoucherRow_colsCodeG = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.tblVoucherRow_colsCodeGDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.tblVoucherRow_colsCodeH = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.tblVoucherRow_colsCodeHDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.tblVoucherRow_colsCodeI = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.tblVoucherRow_colsCodeIDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.tblVoucherRow_colsCodeJ = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.tblVoucherRow_colsCodeJDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.tblVoucherRow_colsProcessCode = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.tblVoucherRow_colsCurrencyCode = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherRow_colsCurrencyType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherRow_colnCurrencyDebitAmount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherRow_colnCurrencyCreditAmount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherRow_colnCurrencyAmount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherRow_colnCurrencyRate = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherRow_colnConversionFactor = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherRow_colnDebitAmount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherRow_colnCreditAmount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherRow_colnAmount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherRow_colnQuantity = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.tblVoucherRow_colsPeriodAllocation = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherRow_colsText = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.tblVoucherRow_colsDeliveryTypeId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherRow_colsDeliveryTypeDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherRow_colsOptionalCode = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherRow_colsUpdateError = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherRow_colsTransCode = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherRow_colsVoucherTypeCreated = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherRow_colnAccountingYearCreated = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherRow_colnVoucherNoCreated = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherRow_colnRowNoCreated = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherRow_colnProjectActivityId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherRow_colAddInternal = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.tblVoucherRow_colsBaseCurrencyCode = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherRow_colnDecimalsInAmount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherRow_colnAccDecimalsInAmount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherRow_colsCodeDemand = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherRow_colsLedgerIds = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherRow_colnCalculatedAmount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherRow_colsProjectActivityIdEnabled = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherRow_colsProjectId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherRow_colnInternalSeqNumber = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherRow_colsManualAdded = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.tblVoucherRow_colsReferenceSerie = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherRow_colsReferenceNumber = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherRow_colnRowNo = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherRow_colsDuplicateRow = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherRow.SuspendLayout();
            this.SuspendLayout();
            // 
            // labeldfsCodePartValue
            // 
            resources.ApplyResources(this.labeldfsCodePartValue, "labeldfsCodePartValue");
            this.labeldfsCodePartValue.Name = "labeldfsCodePartValue";
            // 
            // dfsCodePartValue
            // 
            resources.ApplyResources(this.dfsCodePartValue, "dfsCodePartValue");
            this.dfsCodePartValue.Name = "dfsCodePartValue";
            this.dfsCodePartValue.NamedProperties.Put("EnumerateMethod", "");
            this.dfsCodePartValue.NamedProperties.Put("LovReference", "");
            this.dfsCodePartValue.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsCodePartValue.NamedProperties.Put("SqlColumn", "");
            this.dfsCodePartValue.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsCodePartDescription
            // 
            resources.ApplyResources(this.labeldfsCodePartDescription, "labeldfsCodePartDescription");
            this.labeldfsCodePartDescription.Name = "labeldfsCodePartDescription";
            // 
            // dfsCodePartDescription
            // 
            resources.ApplyResources(this.dfsCodePartDescription, "dfsCodePartDescription");
            this.dfsCodePartDescription.Name = "dfsCodePartDescription";
            this.dfsCodePartDescription.NamedProperties.Put("EnumerateMethod", "");
            this.dfsCodePartDescription.NamedProperties.Put("LovReference", "");
            this.dfsCodePartDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsCodePartDescription.NamedProperties.Put("SqlColumn", "");
            this.dfsCodePartDescription.NamedProperties.Put("ValidateMethod", "");
            // 
            // labelcmbsVoucherCompany
            // 
            resources.ApplyResources(this.labelcmbsVoucherCompany, "labelcmbsVoucherCompany");
            this.labelcmbsVoucherCompany.Name = "labelcmbsVoucherCompany";
            // 
            // cmbsVoucherCompany
            // 
            resources.ApplyResources(this.cmbsVoucherCompany, "cmbsVoucherCompany");
            this.cmbsVoucherCompany.Name = "cmbsVoucherCompany";
            this.cmbsVoucherCompany.NamedProperties.Put("DataType", "5");
            this.cmbsVoucherCompany.NamedProperties.Put("EnumerateMethod", "");
            this.cmbsVoucherCompany.NamedProperties.Put("FieldFlags", "294");
            this.cmbsVoucherCompany.NamedProperties.Put("Format", "0");
            this.cmbsVoucherCompany.NamedProperties.Put("LovReference", "");
            this.cmbsVoucherCompany.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.cmbsVoucherCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbsVoucherCompany.NamedProperties.Put("SqlColumn", "");
            this.cmbsVoucherCompany.NamedProperties.Put("ValidateMethod", "");
            this.cmbsVoucherCompany.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbsVoucherCompany_WindowActions);
            // 
            // labeldfsVCCurrency
            // 
            resources.ApplyResources(this.labeldfsVCCurrency, "labeldfsVCCurrency");
            this.labeldfsVCCurrency.Name = "labeldfsVCCurrency";
            // 
            // dfsVCCurrency
            // 
            resources.ApplyResources(this.dfsVCCurrency, "dfsVCCurrency");
            this.dfsVCCurrency.Name = "dfsVCCurrency";
            this.dfsVCCurrency.NamedProperties.Put("EnumerateMethod", "");
            this.dfsVCCurrency.NamedProperties.Put("LovReference", "");
            this.dfsVCCurrency.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsVCCurrency.NamedProperties.Put("SqlColumn", "");
            this.dfsVCCurrency.NamedProperties.Put("ValidateMethod", "");
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
            this.dfnCurrencyBalance.NamedProperties.Put("Format", "20");
            this.dfnCurrencyBalance.NamedProperties.Put("LovReference", "");
            this.dfnCurrencyBalance.NamedProperties.Put("ResizeableChildObject", "");
            this.dfnCurrencyBalance.NamedProperties.Put("SqlColumn", "");
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
            this.dfnBalance.NamedProperties.Put("Format", "20");
            this.dfnBalance.NamedProperties.Put("LovReference", "");
            this.dfnBalance.NamedProperties.Put("ResizeableChildObject", "");
            this.dfnBalance.NamedProperties.Put("SqlColumn", "");
            this.dfnBalance.NamedProperties.Put("ValidateMethod", "");
            // 
            // tblVoucherRow
            // 
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colsParentCompany);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colsVoucherType);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colnAccountingYear);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colnAccountingPeriod);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colnVoucherNo);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colsCompany);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colnRowGroupId);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colsAccount);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colsAccountDesc);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colsCodeB);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colsCodeBDesc);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colsCodeC);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colsCodeCDesc);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colsCodeD);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colsCodeDDesc);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colsCodeE);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colsCodeEDesc);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colsCodeF);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colsCodeFDesc);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colsCodeG);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colsCodeGDesc);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colsCodeH);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colsCodeHDesc);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colsCodeI);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colsCodeIDesc);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colsCodeJ);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colsCodeJDesc);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colsProcessCode);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colsCurrencyCode);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colsCurrencyType);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colnCurrencyDebitAmount);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colnCurrencyCreditAmount);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colnCurrencyAmount);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colnCurrencyRate);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colnConversionFactor);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colnDebitAmount);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colnCreditAmount);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colnAmount);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colnQuantity);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colsPeriodAllocation);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colsText);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colsDeliveryTypeId);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colsDeliveryTypeDescription);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colsOptionalCode);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colsUpdateError);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colsTransCode);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colsVoucherTypeCreated);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colnAccountingYearCreated);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colnVoucherNoCreated);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colnRowNoCreated);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colnProjectActivityId);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colAddInternal);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colsBaseCurrencyCode);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colnDecimalsInAmount);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colnAccDecimalsInAmount);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colsCodeDemand);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colsLedgerIds);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colnCalculatedAmount);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colsProjectActivityIdEnabled);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colsProjectId);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colnInternalSeqNumber);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colsManualAdded);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colsReferenceSerie);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colsReferenceNumber);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colnRowNo);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colsDuplicateRow);
            resources.ApplyResources(this.tblVoucherRow, "tblVoucherRow");
            this.tblVoucherRow.Name = "tblVoucherRow";
            this.tblVoucherRow.NamedProperties.Put("DefaultOrderBy", "");
            this.tblVoucherRow.NamedProperties.Put("DefaultWhere", "");
            this.tblVoucherRow.NamedProperties.Put("LogicalUnit", "MultiCompanyVoucherRow");
            this.tblVoucherRow.NamedProperties.Put("PackageName", "MULTI_COMPANY_VOUCHER_ROW_API");
            this.tblVoucherRow.NamedProperties.Put("ResizeableChildObject", "LLFF");
            this.tblVoucherRow.NamedProperties.Put("ViewName", "MULTI_COMPANY_VOUCHER_ROW2");
            this.tblVoucherRow.NamedProperties.Put("Warnings", "FALSE");
            this.tblVoucherRow.EnableDisableProjectActivityIdEvent += new System.EventHandler<Ifs.Application.Accrul.cChildTableFin.cChildTableFinEventArgs>(this.tblVoucherRow_EnableDisableProjectActivityIdEvent);
            this.tblVoucherRow.DataSourceFormatSqlColumnUserEvent += new System.EventHandler<Ifs.Fnd.ApplicationForms.FndReturnEventArgsSalString>(this.tblVoucherRow_DataSourceFormatSqlColumnUserEvent);
            this.tblVoucherRow.DataSourceFormatSqlIntoUserEvent += new System.EventHandler<Ifs.Fnd.ApplicationForms.FndReturnEventArgsSalString>(this.tblVoucherRow_DataSourceFormatSqlIntoUserEvent);
            this.tblVoucherRow.DataRecordCheckRequiredEvent += new System.EventHandler<Ifs.Fnd.ApplicationForms.FndReturnEventArgsSalBoolean>(this.tblVoucherRow_DataRecordCheckRequiredEvent);
            this.tblVoucherRow.DataRecordDuplicateEvent += new Ifs.Fnd.ApplicationForms.cDataSource.DataRecordDuplicateEventHandler(this.tblVoucherRow_DataRecordDuplicateEvent);
            this.tblVoucherRow.DataRecordExecuteModifyEvent += new Ifs.Fnd.ApplicationForms.cDataSource.DataRecordExecuteModifyEventHandler(this.tblVoucherRow_DataRecordExecuteModifyEvent);
            this.tblVoucherRow.DataRecordGetDefaultsEvent += new System.EventHandler<Ifs.Fnd.ApplicationForms.FndReturnEventArgsSalBoolean>(this.tblVoucherRow_DataRecordGetDefaultsEvent);
            this.tblVoucherRow.DataRecordNewEvent += new Ifs.Fnd.ApplicationForms.cDataSource.DataRecordNewEventHandler(this.tblVoucherRow_DataRecordNewEvent);
            this.tblVoucherRow.DataRecordValidateEvent += new System.EventHandler<Ifs.Fnd.ApplicationForms.FndReturnEventArgsSalBoolean>(this.tblVoucherRow_DataRecordValidateEvent);
            this.tblVoucherRow.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVoucherRow_WindowActions);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colsDuplicateRow, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colnRowNo, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colsReferenceNumber, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colsReferenceSerie, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colsManualAdded, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colnInternalSeqNumber, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colsProjectId, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colsProjectActivityIdEnabled, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colnCalculatedAmount, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colsLedgerIds, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colsCodeDemand, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colnAccDecimalsInAmount, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colnDecimalsInAmount, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colsBaseCurrencyCode, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colAddInternal, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colnProjectActivityId, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colnRowNoCreated, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colnVoucherNoCreated, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colnAccountingYearCreated, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colsVoucherTypeCreated, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colsTransCode, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colsUpdateError, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colsOptionalCode, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colsDeliveryTypeDescription, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colsDeliveryTypeId, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colsText, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colsPeriodAllocation, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colnQuantity, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colnAmount, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colnCreditAmount, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colnDebitAmount, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colnConversionFactor, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colnCurrencyRate, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colnCurrencyAmount, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colnCurrencyCreditAmount, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colnCurrencyDebitAmount, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colsCurrencyType, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colsCurrencyCode, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colsProcessCode, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colsCodeJDesc, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colsCodeJ, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colsCodeIDesc, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colsCodeI, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colsCodeHDesc, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colsCodeH, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colsCodeGDesc, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colsCodeG, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colsCodeFDesc, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colsCodeF, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colsCodeEDesc, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colsCodeE, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colsCodeDDesc, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colsCodeD, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colsCodeCDesc, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colsCodeC, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colsCodeBDesc, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colsCodeB, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colsAccountDesc, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colsAccount, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colnRowGroupId, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colsCompany, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colnVoucherNo, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colnAccountingPeriod, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colnAccountingYear, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colsVoucherType, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colsParentCompany, 0);
            // 
            // tblVoucherRow_colsParentCompany
            // 
            this.tblVoucherRow_colsParentCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblVoucherRow_colsParentCompany, "tblVoucherRow_colsParentCompany");
            this.tblVoucherRow_colsParentCompany.MaxLength = 20;
            this.tblVoucherRow_colsParentCompany.Name = "tblVoucherRow_colsParentCompany";
            this.tblVoucherRow_colsParentCompany.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colsParentCompany.NamedProperties.Put("FieldFlags", "67");
            this.tblVoucherRow_colsParentCompany.NamedProperties.Put("LovReference", "COMPANY_FINANCE");
            this.tblVoucherRow_colsParentCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colsParentCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.tblVoucherRow_colsParentCompany.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colsParentCompany.Position = 3;
            // 
            // tblVoucherRow_colsVoucherType
            // 
            this.tblVoucherRow_colsVoucherType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblVoucherRow_colsVoucherType, "tblVoucherRow_colsVoucherType");
            this.tblVoucherRow_colsVoucherType.MaxLength = 3;
            this.tblVoucherRow_colsVoucherType.Name = "tblVoucherRow_colsVoucherType";
            this.tblVoucherRow_colsVoucherType.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colsVoucherType.NamedProperties.Put("FieldFlags", "67");
            this.tblVoucherRow_colsVoucherType.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colsVoucherType.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colsVoucherType.NamedProperties.Put("SqlColumn", "VOUCHER_TYPE");
            this.tblVoucherRow_colsVoucherType.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colsVoucherType.Position = 4;
            // 
            // tblVoucherRow_colnAccountingYear
            // 
            this.tblVoucherRow_colnAccountingYear.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.tblVoucherRow_colnAccountingYear, "tblVoucherRow_colnAccountingYear");
            this.tblVoucherRow_colnAccountingYear.Name = "tblVoucherRow_colnAccountingYear";
            this.tblVoucherRow_colnAccountingYear.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colnAccountingYear.NamedProperties.Put("FieldFlags", "67");
            this.tblVoucherRow_colnAccountingYear.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colnAccountingYear.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colnAccountingYear.NamedProperties.Put("SqlColumn", "ACCOUNTING_YEAR");
            this.tblVoucherRow_colnAccountingYear.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colnAccountingYear.Position = 5;
            // 
            // tblVoucherRow_colnAccountingPeriod
            // 
            this.tblVoucherRow_colnAccountingPeriod.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.tblVoucherRow_colnAccountingPeriod, "tblVoucherRow_colnAccountingPeriod");
            this.tblVoucherRow_colnAccountingPeriod.Format = "00";
            this.tblVoucherRow_colnAccountingPeriod.Name = "tblVoucherRow_colnAccountingPeriod";
            this.tblVoucherRow_colnAccountingPeriod.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colnAccountingPeriod.NamedProperties.Put("FieldFlags", "259");
            this.tblVoucherRow_colnAccountingPeriod.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colnAccountingPeriod.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colnAccountingPeriod.NamedProperties.Put("SqlColumn", "ACCOUNTING_PERIOD");
            this.tblVoucherRow_colnAccountingPeriod.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colnAccountingPeriod.Position = 6;
            this.tblVoucherRow_colnAccountingPeriod.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tblVoucherRow_colnVoucherNo
            // 
            this.tblVoucherRow_colnVoucherNo.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.tblVoucherRow_colnVoucherNo, "tblVoucherRow_colnVoucherNo");
            this.tblVoucherRow_colnVoucherNo.MaxLength = 10;
            this.tblVoucherRow_colnVoucherNo.Name = "tblVoucherRow_colnVoucherNo";
            this.tblVoucherRow_colnVoucherNo.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colnVoucherNo.NamedProperties.Put("FieldFlags", "67");
            this.tblVoucherRow_colnVoucherNo.NamedProperties.Put("LovReference", "VOUCHER(COMPANY,VOUCHER_TYPE,ACCOUNTING_YEAR)");
            this.tblVoucherRow_colnVoucherNo.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colnVoucherNo.NamedProperties.Put("SqlColumn", "VOUCHER_NO");
            this.tblVoucherRow_colnVoucherNo.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colnVoucherNo.Position = 7;
            // 
            // tblVoucherRow_colsCompany
            // 
            this.tblVoucherRow_colsCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblVoucherRow_colsCompany.MaxLength = 20;
            this.tblVoucherRow_colsCompany.Name = "tblVoucherRow_colsCompany";
            this.tblVoucherRow_colsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colsCompany.NamedProperties.Put("FieldFlags", "291");
            this.tblVoucherRow_colsCompany.NamedProperties.Put("LovReference", "COMPANY_FINANCE");
            this.tblVoucherRow_colsCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colsCompany.NamedProperties.Put("SqlColumn", "VOUCHER_COMPANY");
            this.tblVoucherRow_colsCompany.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colsCompany.Position = 8;
            resources.ApplyResources(this.tblVoucherRow_colsCompany, "tblVoucherRow_colsCompany");
            this.tblVoucherRow_colsCompany.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVoucherRow_colsCompany_WindowActions);
            // 
            // tblVoucherRow_colnRowGroupId
            // 
            this.tblVoucherRow_colnRowGroupId.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVoucherRow_colnRowGroupId.MaxLength = 4;
            this.tblVoucherRow_colnRowGroupId.Name = "tblVoucherRow_colnRowGroupId";
            this.tblVoucherRow_colnRowGroupId.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colnRowGroupId.NamedProperties.Put("FieldFlags", "294");
            this.tblVoucherRow_colnRowGroupId.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colnRowGroupId.NamedProperties.Put("SqlColumn", "ROW_GROUP_ID");
            this.tblVoucherRow_colnRowGroupId.Position = 9;
            resources.ApplyResources(this.tblVoucherRow_colnRowGroupId, "tblVoucherRow_colnRowGroupId");
            this.tblVoucherRow_colnRowGroupId.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVoucherRow_colnRowGroupId_WindowActions);
            // 
            // tblVoucherRow_colsAccount
            // 
            this.tblVoucherRow_colsAccount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblVoucherRow_colsAccount.Name = "tblVoucherRow_colsAccount";
            this.tblVoucherRow_colsAccount.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colsAccount.NamedProperties.Put("FieldFlags", "291");
            this.tblVoucherRow_colsAccount.NamedProperties.Put("LovReference", "PS_CODE_ACCOUNT(VOUCHER_COMPANY)");
            this.tblVoucherRow_colsAccount.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colsAccount.NamedProperties.Put("SqlColumn", "ACCOUNT");
            this.tblVoucherRow_colsAccount.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colsAccount.Position = 10;
            resources.ApplyResources(this.tblVoucherRow_colsAccount, "tblVoucherRow_colsAccount");
            this.tblVoucherRow_colsAccount.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVoucherRow_colsAccount_WindowActions);
            // 
            // tblVoucherRow_colsAccountDesc
            // 
            resources.ApplyResources(this.tblVoucherRow_colsAccountDesc, "tblVoucherRow_colsAccountDesc");
            this.tblVoucherRow_colsAccountDesc.Name = "tblVoucherRow_colsAccountDesc";
            this.tblVoucherRow_colsAccountDesc.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colsAccountDesc.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colsAccountDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colsAccountDesc.NamedProperties.Put("SqlColumn", "ACCOUNT_DESC");
            this.tblVoucherRow_colsAccountDesc.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colsAccountDesc.Position = 11;
            // 
            // tblVoucherRow_colsCodeB
            // 
            this.tblVoucherRow_colsCodeB.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblVoucherRow_colsCodeB.MaxLength = 20;
            this.tblVoucherRow_colsCodeB.Name = "tblVoucherRow_colsCodeB";
            this.tblVoucherRow_colsCodeB.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colsCodeB.NamedProperties.Put("FieldFlags", "290");
            this.tblVoucherRow_colsCodeB.NamedProperties.Put("LovReference", "CODE_B(VOUCHER_COMPANY)");
            this.tblVoucherRow_colsCodeB.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colsCodeB.NamedProperties.Put("SqlColumn", "CODE_B");
            this.tblVoucherRow_colsCodeB.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colsCodeB.Position = 12;
            resources.ApplyResources(this.tblVoucherRow_colsCodeB, "tblVoucherRow_colsCodeB");
            // 
            // tblVoucherRow_colsCodeBDesc
            // 
            resources.ApplyResources(this.tblVoucherRow_colsCodeBDesc, "tblVoucherRow_colsCodeBDesc");
            this.tblVoucherRow_colsCodeBDesc.Name = "tblVoucherRow_colsCodeBDesc";
            this.tblVoucherRow_colsCodeBDesc.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colsCodeBDesc.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colsCodeBDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colsCodeBDesc.NamedProperties.Put("SqlColumn", "CODE_B_DESC");
            this.tblVoucherRow_colsCodeBDesc.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colsCodeBDesc.Position = 13;
            // 
            // tblVoucherRow_colsCodeC
            // 
            this.tblVoucherRow_colsCodeC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblVoucherRow_colsCodeC.MaxLength = 20;
            this.tblVoucherRow_colsCodeC.Name = "tblVoucherRow_colsCodeC";
            this.tblVoucherRow_colsCodeC.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colsCodeC.NamedProperties.Put("FieldFlags", "290");
            this.tblVoucherRow_colsCodeC.NamedProperties.Put("LovReference", "CODE_C(VOUCHER_COMPANY)");
            this.tblVoucherRow_colsCodeC.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colsCodeC.NamedProperties.Put("SqlColumn", "CODE_C");
            this.tblVoucherRow_colsCodeC.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colsCodeC.Position = 14;
            resources.ApplyResources(this.tblVoucherRow_colsCodeC, "tblVoucherRow_colsCodeC");
            // 
            // tblVoucherRow_colsCodeCDesc
            // 
            resources.ApplyResources(this.tblVoucherRow_colsCodeCDesc, "tblVoucherRow_colsCodeCDesc");
            this.tblVoucherRow_colsCodeCDesc.Name = "tblVoucherRow_colsCodeCDesc";
            this.tblVoucherRow_colsCodeCDesc.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colsCodeCDesc.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colsCodeCDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colsCodeCDesc.NamedProperties.Put("SqlColumn", "CODE_C_DESC");
            this.tblVoucherRow_colsCodeCDesc.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colsCodeCDesc.Position = 15;
            // 
            // tblVoucherRow_colsCodeD
            // 
            this.tblVoucherRow_colsCodeD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblVoucherRow_colsCodeD.MaxLength = 20;
            this.tblVoucherRow_colsCodeD.Name = "tblVoucherRow_colsCodeD";
            this.tblVoucherRow_colsCodeD.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colsCodeD.NamedProperties.Put("FieldFlags", "290");
            this.tblVoucherRow_colsCodeD.NamedProperties.Put("LovReference", "CODE_D(VOUCHER_COMPANY)");
            this.tblVoucherRow_colsCodeD.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colsCodeD.NamedProperties.Put("SqlColumn", "CODE_D");
            this.tblVoucherRow_colsCodeD.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colsCodeD.Position = 16;
            resources.ApplyResources(this.tblVoucherRow_colsCodeD, "tblVoucherRow_colsCodeD");
            // 
            // tblVoucherRow_colsCodeDDesc
            // 
            resources.ApplyResources(this.tblVoucherRow_colsCodeDDesc, "tblVoucherRow_colsCodeDDesc");
            this.tblVoucherRow_colsCodeDDesc.Name = "tblVoucherRow_colsCodeDDesc";
            this.tblVoucherRow_colsCodeDDesc.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colsCodeDDesc.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colsCodeDDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colsCodeDDesc.NamedProperties.Put("SqlColumn", "CODE_D_DESC");
            this.tblVoucherRow_colsCodeDDesc.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colsCodeDDesc.Position = 17;
            // 
            // tblVoucherRow_colsCodeE
            // 
            this.tblVoucherRow_colsCodeE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblVoucherRow_colsCodeE.MaxLength = 20;
            this.tblVoucherRow_colsCodeE.Name = "tblVoucherRow_colsCodeE";
            this.tblVoucherRow_colsCodeE.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colsCodeE.NamedProperties.Put("FieldFlags", "290");
            this.tblVoucherRow_colsCodeE.NamedProperties.Put("LovReference", "CODE_E(VOUCHER_COMPANY)");
            this.tblVoucherRow_colsCodeE.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colsCodeE.NamedProperties.Put("SqlColumn", "CODE_E");
            this.tblVoucherRow_colsCodeE.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colsCodeE.Position = 18;
            resources.ApplyResources(this.tblVoucherRow_colsCodeE, "tblVoucherRow_colsCodeE");
            // 
            // tblVoucherRow_colsCodeEDesc
            // 
            resources.ApplyResources(this.tblVoucherRow_colsCodeEDesc, "tblVoucherRow_colsCodeEDesc");
            this.tblVoucherRow_colsCodeEDesc.Name = "tblVoucherRow_colsCodeEDesc";
            this.tblVoucherRow_colsCodeEDesc.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colsCodeEDesc.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colsCodeEDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colsCodeEDesc.NamedProperties.Put("SqlColumn", "CODE_E_DESC");
            this.tblVoucherRow_colsCodeEDesc.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colsCodeEDesc.Position = 19;
            // 
            // tblVoucherRow_colsCodeF
            // 
            this.tblVoucherRow_colsCodeF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblVoucherRow_colsCodeF.MaxLength = 20;
            this.tblVoucherRow_colsCodeF.Name = "tblVoucherRow_colsCodeF";
            this.tblVoucherRow_colsCodeF.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colsCodeF.NamedProperties.Put("FieldFlags", "290");
            this.tblVoucherRow_colsCodeF.NamedProperties.Put("LovReference", "CODE_F(VOUCHER_COMPANY)");
            this.tblVoucherRow_colsCodeF.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colsCodeF.NamedProperties.Put("SqlColumn", "CODE_F");
            this.tblVoucherRow_colsCodeF.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colsCodeF.Position = 20;
            resources.ApplyResources(this.tblVoucherRow_colsCodeF, "tblVoucherRow_colsCodeF");
            // 
            // tblVoucherRow_colsCodeFDesc
            // 
            resources.ApplyResources(this.tblVoucherRow_colsCodeFDesc, "tblVoucherRow_colsCodeFDesc");
            this.tblVoucherRow_colsCodeFDesc.Name = "tblVoucherRow_colsCodeFDesc";
            this.tblVoucherRow_colsCodeFDesc.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colsCodeFDesc.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colsCodeFDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colsCodeFDesc.NamedProperties.Put("SqlColumn", "CODE_F_DESC");
            this.tblVoucherRow_colsCodeFDesc.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colsCodeFDesc.Position = 21;
            // 
            // tblVoucherRow_colsCodeG
            // 
            this.tblVoucherRow_colsCodeG.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblVoucherRow_colsCodeG.MaxLength = 20;
            this.tblVoucherRow_colsCodeG.Name = "tblVoucherRow_colsCodeG";
            this.tblVoucherRow_colsCodeG.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colsCodeG.NamedProperties.Put("FieldFlags", "290");
            this.tblVoucherRow_colsCodeG.NamedProperties.Put("LovReference", "CODE_G(VOUCHER_COMPANY)");
            this.tblVoucherRow_colsCodeG.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colsCodeG.NamedProperties.Put("SqlColumn", "CODE_G");
            this.tblVoucherRow_colsCodeG.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colsCodeG.Position = 22;
            resources.ApplyResources(this.tblVoucherRow_colsCodeG, "tblVoucherRow_colsCodeG");
            // 
            // tblVoucherRow_colsCodeGDesc
            // 
            resources.ApplyResources(this.tblVoucherRow_colsCodeGDesc, "tblVoucherRow_colsCodeGDesc");
            this.tblVoucherRow_colsCodeGDesc.Name = "tblVoucherRow_colsCodeGDesc";
            this.tblVoucherRow_colsCodeGDesc.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colsCodeGDesc.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colsCodeGDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colsCodeGDesc.NamedProperties.Put("SqlColumn", "CODE_G_DESC");
            this.tblVoucherRow_colsCodeGDesc.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colsCodeGDesc.Position = 23;
            // 
            // tblVoucherRow_colsCodeH
            // 
            this.tblVoucherRow_colsCodeH.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblVoucherRow_colsCodeH.MaxLength = 20;
            this.tblVoucherRow_colsCodeH.Name = "tblVoucherRow_colsCodeH";
            this.tblVoucherRow_colsCodeH.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colsCodeH.NamedProperties.Put("FieldFlags", "290");
            this.tblVoucherRow_colsCodeH.NamedProperties.Put("LovReference", "CODE_H(VOUCHER_COMPANY)");
            this.tblVoucherRow_colsCodeH.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colsCodeH.NamedProperties.Put("SqlColumn", "CODE_H");
            this.tblVoucherRow_colsCodeH.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colsCodeH.Position = 24;
            resources.ApplyResources(this.tblVoucherRow_colsCodeH, "tblVoucherRow_colsCodeH");
            // 
            // tblVoucherRow_colsCodeHDesc
            // 
            resources.ApplyResources(this.tblVoucherRow_colsCodeHDesc, "tblVoucherRow_colsCodeHDesc");
            this.tblVoucherRow_colsCodeHDesc.Name = "tblVoucherRow_colsCodeHDesc";
            this.tblVoucherRow_colsCodeHDesc.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colsCodeHDesc.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colsCodeHDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colsCodeHDesc.NamedProperties.Put("SqlColumn", "CODE_H_DESC");
            this.tblVoucherRow_colsCodeHDesc.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colsCodeHDesc.Position = 25;
            // 
            // tblVoucherRow_colsCodeI
            // 
            this.tblVoucherRow_colsCodeI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblVoucherRow_colsCodeI.MaxLength = 20;
            this.tblVoucherRow_colsCodeI.Name = "tblVoucherRow_colsCodeI";
            this.tblVoucherRow_colsCodeI.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colsCodeI.NamedProperties.Put("FieldFlags", "290");
            this.tblVoucherRow_colsCodeI.NamedProperties.Put("LovReference", "CODE_I(VOUCHER_COMPANY)");
            this.tblVoucherRow_colsCodeI.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colsCodeI.NamedProperties.Put("SqlColumn", "CODE_I");
            this.tblVoucherRow_colsCodeI.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colsCodeI.Position = 26;
            resources.ApplyResources(this.tblVoucherRow_colsCodeI, "tblVoucherRow_colsCodeI");
            // 
            // tblVoucherRow_colsCodeIDesc
            // 
            resources.ApplyResources(this.tblVoucherRow_colsCodeIDesc, "tblVoucherRow_colsCodeIDesc");
            this.tblVoucherRow_colsCodeIDesc.Name = "tblVoucherRow_colsCodeIDesc";
            this.tblVoucherRow_colsCodeIDesc.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colsCodeIDesc.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colsCodeIDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colsCodeIDesc.NamedProperties.Put("SqlColumn", "CODE_I_DESC");
            this.tblVoucherRow_colsCodeIDesc.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colsCodeIDesc.Position = 27;
            // 
            // tblVoucherRow_colsCodeJ
            // 
            this.tblVoucherRow_colsCodeJ.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblVoucherRow_colsCodeJ.MaxLength = 20;
            this.tblVoucherRow_colsCodeJ.Name = "tblVoucherRow_colsCodeJ";
            this.tblVoucherRow_colsCodeJ.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colsCodeJ.NamedProperties.Put("FieldFlags", "290");
            this.tblVoucherRow_colsCodeJ.NamedProperties.Put("LovReference", "CODE_J(VOUCHER_COMPANY)");
            this.tblVoucherRow_colsCodeJ.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colsCodeJ.NamedProperties.Put("SqlColumn", "CODE_J");
            this.tblVoucherRow_colsCodeJ.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colsCodeJ.Position = 28;
            resources.ApplyResources(this.tblVoucherRow_colsCodeJ, "tblVoucherRow_colsCodeJ");
            // 
            // tblVoucherRow_colsCodeJDesc
            // 
            resources.ApplyResources(this.tblVoucherRow_colsCodeJDesc, "tblVoucherRow_colsCodeJDesc");
            this.tblVoucherRow_colsCodeJDesc.Name = "tblVoucherRow_colsCodeJDesc";
            this.tblVoucherRow_colsCodeJDesc.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colsCodeJDesc.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colsCodeJDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colsCodeJDesc.NamedProperties.Put("SqlColumn", "CODE_J_DESC");
            this.tblVoucherRow_colsCodeJDesc.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colsCodeJDesc.Position = 29;
            // 
            // tblVoucherRow_colsProcessCode
            // 
            this.tblVoucherRow_colsProcessCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblVoucherRow_colsProcessCode.MaxLength = 10;
            this.tblVoucherRow_colsProcessCode.Name = "tblVoucherRow_colsProcessCode";
            this.tblVoucherRow_colsProcessCode.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colsProcessCode.NamedProperties.Put("FieldFlags", "290");
            this.tblVoucherRow_colsProcessCode.NamedProperties.Put("LovReference", "ACCOUNT_PROCESS_CODE(VOUCHER_COMPANY)");
            this.tblVoucherRow_colsProcessCode.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colsProcessCode.NamedProperties.Put("SqlColumn", "PROCESS_CODE");
            this.tblVoucherRow_colsProcessCode.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colsProcessCode.Position = 30;
            resources.ApplyResources(this.tblVoucherRow_colsProcessCode, "tblVoucherRow_colsProcessCode");
            this.tblVoucherRow_colsProcessCode.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVoucherRow_colsProcessCode_WindowActions);
            // 
            // tblVoucherRow_colsCurrencyCode
            // 
            this.tblVoucherRow_colsCurrencyCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblVoucherRow_colsCurrencyCode.MaxLength = 3;
            this.tblVoucherRow_colsCurrencyCode.Name = "tblVoucherRow_colsCurrencyCode";
            this.tblVoucherRow_colsCurrencyCode.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colsCurrencyCode.NamedProperties.Put("FieldFlags", "290");
            this.tblVoucherRow_colsCurrencyCode.NamedProperties.Put("LovReference", "CURRENCY_CODE(VOUCHER_COMPANY)");
            this.tblVoucherRow_colsCurrencyCode.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colsCurrencyCode.NamedProperties.Put("SqlColumn", "CURRENCY_CODE");
            this.tblVoucherRow_colsCurrencyCode.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colsCurrencyCode.Position = 31;
            resources.ApplyResources(this.tblVoucherRow_colsCurrencyCode, "tblVoucherRow_colsCurrencyCode");
            this.tblVoucherRow_colsCurrencyCode.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVoucherRow_colsCurrencyCode_WindowActions);
            // 
            // tblVoucherRow_colsCurrencyType
            // 
            this.tblVoucherRow_colsCurrencyType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblVoucherRow_colsCurrencyType.MaxLength = 10;
            this.tblVoucherRow_colsCurrencyType.Name = "tblVoucherRow_colsCurrencyType";
            this.tblVoucherRow_colsCurrencyType.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colsCurrencyType.NamedProperties.Put("FieldFlags", "290");
            this.tblVoucherRow_colsCurrencyType.NamedProperties.Put("LovReference", "CURRENCY_RATE2(VOUCHER_COMPANY, CURRENCY_CODE)");
            this.tblVoucherRow_colsCurrencyType.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colsCurrencyType.NamedProperties.Put("SqlColumn", "CURRENCY_TYPE");
            this.tblVoucherRow_colsCurrencyType.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colsCurrencyType.Position = 32;
            resources.ApplyResources(this.tblVoucherRow_colsCurrencyType, "tblVoucherRow_colsCurrencyType");
            this.tblVoucherRow_colsCurrencyType.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVoucherRow_colsCurrencyType_WindowActions);
            // 
            // tblVoucherRow_colnCurrencyDebitAmount
            // 
            this.tblVoucherRow_colnCurrencyDebitAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVoucherRow_colnCurrencyDebitAmount.Name = "tblVoucherRow_colnCurrencyDebitAmount";
            this.tblVoucherRow_colnCurrencyDebitAmount.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colnCurrencyDebitAmount.NamedProperties.Put("FieldFlags", "290");
            this.tblVoucherRow_colnCurrencyDebitAmount.NamedProperties.Put("Format", "20");
            this.tblVoucherRow_colnCurrencyDebitAmount.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colnCurrencyDebitAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colnCurrencyDebitAmount.NamedProperties.Put("SqlColumn", "CURRENCY_DEBIT_AMOUNT");
            this.tblVoucherRow_colnCurrencyDebitAmount.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colnCurrencyDebitAmount.Position = 33;
            this.tblVoucherRow_colnCurrencyDebitAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblVoucherRow_colnCurrencyDebitAmount, "tblVoucherRow_colnCurrencyDebitAmount");
            this.tblVoucherRow_colnCurrencyDebitAmount.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVoucherRow_colnCurrencyDebitAmount_WindowActions);
            // 
            // tblVoucherRow_colnCurrencyCreditAmount
            // 
            this.tblVoucherRow_colnCurrencyCreditAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVoucherRow_colnCurrencyCreditAmount.Name = "tblVoucherRow_colnCurrencyCreditAmount";
            this.tblVoucherRow_colnCurrencyCreditAmount.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colnCurrencyCreditAmount.NamedProperties.Put("FieldFlags", "290");
            this.tblVoucherRow_colnCurrencyCreditAmount.NamedProperties.Put("Format", "20");
            this.tblVoucherRow_colnCurrencyCreditAmount.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colnCurrencyCreditAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colnCurrencyCreditAmount.NamedProperties.Put("SqlColumn", "CURRENCY_CREDIT_AMOUNT");
            this.tblVoucherRow_colnCurrencyCreditAmount.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colnCurrencyCreditAmount.Position = 34;
            this.tblVoucherRow_colnCurrencyCreditAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblVoucherRow_colnCurrencyCreditAmount, "tblVoucherRow_colnCurrencyCreditAmount");
            this.tblVoucherRow_colnCurrencyCreditAmount.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVoucherRow_colnCurrencyCreditAmount_WindowActions);
            // 
            // tblVoucherRow_colnCurrencyAmount
            // 
            this.tblVoucherRow_colnCurrencyAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVoucherRow_colnCurrencyAmount.MaxLength = 15;
            this.tblVoucherRow_colnCurrencyAmount.Name = "tblVoucherRow_colnCurrencyAmount";
            this.tblVoucherRow_colnCurrencyAmount.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colnCurrencyAmount.NamedProperties.Put("FieldFlags", "290");
            this.tblVoucherRow_colnCurrencyAmount.NamedProperties.Put("Format", "20");
            this.tblVoucherRow_colnCurrencyAmount.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colnCurrencyAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colnCurrencyAmount.NamedProperties.Put("SqlColumn", "");
            this.tblVoucherRow_colnCurrencyAmount.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colnCurrencyAmount.Position = 35;
            this.tblVoucherRow_colnCurrencyAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblVoucherRow_colnCurrencyAmount, "tblVoucherRow_colnCurrencyAmount");
            this.tblVoucherRow_colnCurrencyAmount.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVoucherRow_colnCurrencyAmount_WindowActions);
            // 
            // tblVoucherRow_colnCurrencyRate
            // 
            this.tblVoucherRow_colnCurrencyRate.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVoucherRow_colnCurrencyRate.Name = "tblVoucherRow_colnCurrencyRate";
            this.tblVoucherRow_colnCurrencyRate.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colnCurrencyRate.NamedProperties.Put("FieldFlags", "290");
            this.tblVoucherRow_colnCurrencyRate.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colnCurrencyRate.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colnCurrencyRate.NamedProperties.Put("SqlColumn", "CURRENCY_RATE");
            this.tblVoucherRow_colnCurrencyRate.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colnCurrencyRate.Position = 36;
            this.tblVoucherRow_colnCurrencyRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblVoucherRow_colnCurrencyRate, "tblVoucherRow_colnCurrencyRate");
            this.tblVoucherRow_colnCurrencyRate.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVoucherRow_colnCurrencyRate_WindowActions);
            // 
            // tblVoucherRow_colnConversionFactor
            // 
            this.tblVoucherRow_colnConversionFactor.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVoucherRow_colnConversionFactor.Name = "tblVoucherRow_colnConversionFactor";
            this.tblVoucherRow_colnConversionFactor.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colnConversionFactor.NamedProperties.Put("FieldFlags", "288");
            this.tblVoucherRow_colnConversionFactor.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colnConversionFactor.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colnConversionFactor.NamedProperties.Put("SqlColumn", "CONV_FACTOR");
            this.tblVoucherRow_colnConversionFactor.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colnConversionFactor.Position = 37;
            this.tblVoucherRow_colnConversionFactor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblVoucherRow_colnConversionFactor, "tblVoucherRow_colnConversionFactor");
            // 
            // tblVoucherRow_colnDebitAmount
            // 
            this.tblVoucherRow_colnDebitAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVoucherRow_colnDebitAmount.Name = "tblVoucherRow_colnDebitAmount";
            this.tblVoucherRow_colnDebitAmount.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colnDebitAmount.NamedProperties.Put("FieldFlags", "290");
            this.tblVoucherRow_colnDebitAmount.NamedProperties.Put("Format", "20");
            this.tblVoucherRow_colnDebitAmount.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colnDebitAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colnDebitAmount.NamedProperties.Put("SqlColumn", "DEBIT_AMOUNT");
            this.tblVoucherRow_colnDebitAmount.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colnDebitAmount.Position = 38;
            this.tblVoucherRow_colnDebitAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblVoucherRow_colnDebitAmount, "tblVoucherRow_colnDebitAmount");
            this.tblVoucherRow_colnDebitAmount.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVoucherRow_colnDebitAmount_WindowActions);
            // 
            // tblVoucherRow_colnCreditAmount
            // 
            this.tblVoucherRow_colnCreditAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVoucherRow_colnCreditAmount.Name = "tblVoucherRow_colnCreditAmount";
            this.tblVoucherRow_colnCreditAmount.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colnCreditAmount.NamedProperties.Put("FieldFlags", "290");
            this.tblVoucherRow_colnCreditAmount.NamedProperties.Put("Format", "20");
            this.tblVoucherRow_colnCreditAmount.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colnCreditAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colnCreditAmount.NamedProperties.Put("SqlColumn", "CREDIT_AMOUNT");
            this.tblVoucherRow_colnCreditAmount.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colnCreditAmount.Position = 39;
            this.tblVoucherRow_colnCreditAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblVoucherRow_colnCreditAmount, "tblVoucherRow_colnCreditAmount");
            this.tblVoucherRow_colnCreditAmount.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVoucherRow_colnCreditAmount_WindowActions);
            // 
            // tblVoucherRow_colnAmount
            // 
            this.tblVoucherRow_colnAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVoucherRow_colnAmount.MaxLength = 15;
            this.tblVoucherRow_colnAmount.Name = "tblVoucherRow_colnAmount";
            this.tblVoucherRow_colnAmount.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colnAmount.NamedProperties.Put("FieldFlags", "290");
            this.tblVoucherRow_colnAmount.NamedProperties.Put("Format", "20");
            this.tblVoucherRow_colnAmount.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colnAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colnAmount.NamedProperties.Put("SqlColumn", "");
            this.tblVoucherRow_colnAmount.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colnAmount.Position = 40;
            this.tblVoucherRow_colnAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblVoucherRow_colnAmount, "tblVoucherRow_colnAmount");
            this.tblVoucherRow_colnAmount.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVoucherRow_colnAmount_WindowActions);
            // 
            // tblVoucherRow_colnQuantity
            // 
            this.tblVoucherRow_colnQuantity.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVoucherRow_colnQuantity.Name = "tblVoucherRow_colnQuantity";
            this.tblVoucherRow_colnQuantity.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colnQuantity.NamedProperties.Put("FieldFlags", "290");
            this.tblVoucherRow_colnQuantity.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colnQuantity.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colnQuantity.NamedProperties.Put("SqlColumn", "QUANTITY");
            this.tblVoucherRow_colnQuantity.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colnQuantity.Position = 41;
            this.tblVoucherRow_colnQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblVoucherRow_colnQuantity, "tblVoucherRow_colnQuantity");
            // 
            // tblVoucherRow_colsPeriodAllocation
            // 
            this.tblVoucherRow_colsPeriodAllocation.CellType = PPJ.Runtime.Windows.CellType.CheckBox;
            this.tblVoucherRow_colsPeriodAllocation.CheckBox.CheckedValue = "Y";
            this.tblVoucherRow_colsPeriodAllocation.CheckBox.IgnoreCase = true;
            this.tblVoucherRow_colsPeriodAllocation.CheckBox.UncheckedValue = "N";
            resources.ApplyResources(this.tblVoucherRow_colsPeriodAllocation, "tblVoucherRow_colsPeriodAllocation");
            this.tblVoucherRow_colsPeriodAllocation.MaxLength = 1;
            this.tblVoucherRow_colsPeriodAllocation.Name = "tblVoucherRow_colsPeriodAllocation";
            this.tblVoucherRow_colsPeriodAllocation.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colsPeriodAllocation.NamedProperties.Put("FieldFlags", "288");
            this.tblVoucherRow_colsPeriodAllocation.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colsPeriodAllocation.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colsPeriodAllocation.NamedProperties.Put("SqlColumn", "PERIOD_ALLOCATION");
            this.tblVoucherRow_colsPeriodAllocation.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colsPeriodAllocation.Position = 42;
            // 
            // tblVoucherRow_colsText
            // 
            this.tblVoucherRow_colsText.MaxLength = 200;
            this.tblVoucherRow_colsText.Name = "tblVoucherRow_colsText";
            this.tblVoucherRow_colsText.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colsText.NamedProperties.Put("FieldFlags", "290");
            this.tblVoucherRow_colsText.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colsText.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colsText.NamedProperties.Put("SqlColumn", "TEXT");
            this.tblVoucherRow_colsText.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colsText.Position = 43;
            resources.ApplyResources(this.tblVoucherRow_colsText, "tblVoucherRow_colsText");
            // 
            // tblVoucherRow_colsDeliveryTypeId
            // 
            this.tblVoucherRow_colsDeliveryTypeId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblVoucherRow_colsDeliveryTypeId.MaxLength = 20;
            this.tblVoucherRow_colsDeliveryTypeId.Name = "tblVoucherRow_colsDeliveryTypeId";
            this.tblVoucherRow_colsDeliveryTypeId.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colsDeliveryTypeId.NamedProperties.Put("FieldFlags", "290");
            this.tblVoucherRow_colsDeliveryTypeId.NamedProperties.Put("LovReference", "DELIVERY_TYPE(VOUCHER_COMPANY)");
            this.tblVoucherRow_colsDeliveryTypeId.NamedProperties.Put("SqlColumn", "DELIV_TYPE_ID");
            this.tblVoucherRow_colsDeliveryTypeId.Position = 44;
            resources.ApplyResources(this.tblVoucherRow_colsDeliveryTypeId, "tblVoucherRow_colsDeliveryTypeId");
            this.tblVoucherRow_colsDeliveryTypeId.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVoucherRow_colsDeliveryTypeId_WindowActions);
            // 
            // tblVoucherRow_colsDeliveryTypeDescription
            // 
            this.tblVoucherRow_colsDeliveryTypeDescription.MaxLength = 2000;
            this.tblVoucherRow_colsDeliveryTypeDescription.Name = "tblVoucherRow_colsDeliveryTypeDescription";
            this.tblVoucherRow_colsDeliveryTypeDescription.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colsDeliveryTypeDescription.NamedProperties.Put("FieldFlags", "288");
            this.tblVoucherRow_colsDeliveryTypeDescription.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colsDeliveryTypeDescription.NamedProperties.Put("ParentName", "tblVoucherRow.tblVoucherRow_colsDeliveryTypeId");
            this.tblVoucherRow_colsDeliveryTypeDescription.NamedProperties.Put("SqlColumn", "Voucher_Row_API.Get_Delivery_Type_Description(VOUCHER_COMPANY,DELIV_TYPE_ID)");
            this.tblVoucherRow_colsDeliveryTypeDescription.Position = 45;
            resources.ApplyResources(this.tblVoucherRow_colsDeliveryTypeDescription, "tblVoucherRow_colsDeliveryTypeDescription");
            // 
            // tblVoucherRow_colsOptionalCode
            // 
            this.tblVoucherRow_colsOptionalCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblVoucherRow_colsOptionalCode.MaxLength = 20;
            this.tblVoucherRow_colsOptionalCode.Name = "tblVoucherRow_colsOptionalCode";
            this.tblVoucherRow_colsOptionalCode.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colsOptionalCode.NamedProperties.Put("FieldFlags", "290");
            this.tblVoucherRow_colsOptionalCode.NamedProperties.Put("LovReference", "STATUTORY_FEE(VOUCHER_COMPANY)");
            this.tblVoucherRow_colsOptionalCode.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colsOptionalCode.NamedProperties.Put("SqlColumn", "OPTIONAL_CODE");
            this.tblVoucherRow_colsOptionalCode.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colsOptionalCode.Position = 46;
            resources.ApplyResources(this.tblVoucherRow_colsOptionalCode, "tblVoucherRow_colsOptionalCode");
            this.tblVoucherRow_colsOptionalCode.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVoucherRow_colsOptionalCode_WindowActions);
            // 
            // tblVoucherRow_colsUpdateError
            // 
            this.tblVoucherRow_colsUpdateError.MaxLength = 200;
            this.tblVoucherRow_colsUpdateError.Name = "tblVoucherRow_colsUpdateError";
            this.tblVoucherRow_colsUpdateError.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colsUpdateError.NamedProperties.Put("FieldFlags", "290");
            this.tblVoucherRow_colsUpdateError.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colsUpdateError.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colsUpdateError.NamedProperties.Put("SqlColumn", "UPDATE_ERROR");
            this.tblVoucherRow_colsUpdateError.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colsUpdateError.Position = 47;
            resources.ApplyResources(this.tblVoucherRow_colsUpdateError, "tblVoucherRow_colsUpdateError");
            // 
            // tblVoucherRow_colsTransCode
            // 
            this.tblVoucherRow_colsTransCode.MaxLength = 10;
            this.tblVoucherRow_colsTransCode.Name = "tblVoucherRow_colsTransCode";
            this.tblVoucherRow_colsTransCode.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colsTransCode.NamedProperties.Put("FieldFlags", "290");
            this.tblVoucherRow_colsTransCode.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colsTransCode.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colsTransCode.NamedProperties.Put("SqlColumn", "TRANS_CODE");
            this.tblVoucherRow_colsTransCode.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colsTransCode.Position = 48;
            resources.ApplyResources(this.tblVoucherRow_colsTransCode, "tblVoucherRow_colsTransCode");
            // 
            // tblVoucherRow_colsVoucherTypeCreated
            // 
            this.tblVoucherRow_colsVoucherTypeCreated.Name = "tblVoucherRow_colsVoucherTypeCreated";
            this.tblVoucherRow_colsVoucherTypeCreated.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colsVoucherTypeCreated.NamedProperties.Put("FieldFlags", "288");
            this.tblVoucherRow_colsVoucherTypeCreated.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colsVoucherTypeCreated.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colsVoucherTypeCreated.NamedProperties.Put("SqlColumn", "VOUCHER_TYPE_REF");
            this.tblVoucherRow_colsVoucherTypeCreated.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colsVoucherTypeCreated.Position = 49;
            resources.ApplyResources(this.tblVoucherRow_colsVoucherTypeCreated, "tblVoucherRow_colsVoucherTypeCreated");
            // 
            // tblVoucherRow_colnAccountingYearCreated
            // 
            this.tblVoucherRow_colnAccountingYearCreated.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVoucherRow_colnAccountingYearCreated.Name = "tblVoucherRow_colnAccountingYearCreated";
            this.tblVoucherRow_colnAccountingYearCreated.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colnAccountingYearCreated.NamedProperties.Put("FieldFlags", "288");
            this.tblVoucherRow_colnAccountingYearCreated.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colnAccountingYearCreated.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colnAccountingYearCreated.NamedProperties.Put("SqlColumn", "ACCOUNTING_YEAR_REF");
            this.tblVoucherRow_colnAccountingYearCreated.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colnAccountingYearCreated.Position = 50;
            resources.ApplyResources(this.tblVoucherRow_colnAccountingYearCreated, "tblVoucherRow_colnAccountingYearCreated");
            // 
            // tblVoucherRow_colnVoucherNoCreated
            // 
            this.tblVoucherRow_colnVoucherNoCreated.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVoucherRow_colnVoucherNoCreated.Name = "tblVoucherRow_colnVoucherNoCreated";
            this.tblVoucherRow_colnVoucherNoCreated.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colnVoucherNoCreated.NamedProperties.Put("FieldFlags", "288");
            this.tblVoucherRow_colnVoucherNoCreated.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colnVoucherNoCreated.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colnVoucherNoCreated.NamedProperties.Put("SqlColumn", "VOUCHER_NO_REF");
            this.tblVoucherRow_colnVoucherNoCreated.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colnVoucherNoCreated.Position = 51;
            resources.ApplyResources(this.tblVoucherRow_colnVoucherNoCreated, "tblVoucherRow_colnVoucherNoCreated");
            // 
            // tblVoucherRow_colnRowNoCreated
            // 
            this.tblVoucherRow_colnRowNoCreated.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVoucherRow_colnRowNoCreated.Name = "tblVoucherRow_colnRowNoCreated";
            this.tblVoucherRow_colnRowNoCreated.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colnRowNoCreated.NamedProperties.Put("FieldFlags", "288");
            this.tblVoucherRow_colnRowNoCreated.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colnRowNoCreated.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colnRowNoCreated.NamedProperties.Put("SqlColumn", "ROW_NO_REF");
            this.tblVoucherRow_colnRowNoCreated.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colnRowNoCreated.Position = 52;
            resources.ApplyResources(this.tblVoucherRow_colnRowNoCreated, "tblVoucherRow_colnRowNoCreated");
            // 
            // tblVoucherRow_colnProjectActivityId
            // 
            this.tblVoucherRow_colnProjectActivityId.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVoucherRow_colnProjectActivityId.Name = "tblVoucherRow_colnProjectActivityId";
            this.tblVoucherRow_colnProjectActivityId.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colnProjectActivityId.NamedProperties.Put("FieldFlags", "258");
            this.tblVoucherRow_colnProjectActivityId.NamedProperties.Put("LovReference", "PROJECT_ACTIVITY_POSTABLE(PROJECT_ID)");
            this.tblVoucherRow_colnProjectActivityId.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colnProjectActivityId.NamedProperties.Put("SqlColumn", "PROJECT_ACTIVITY_ID");
            this.tblVoucherRow_colnProjectActivityId.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colnProjectActivityId.Position = 53;
            resources.ApplyResources(this.tblVoucherRow_colnProjectActivityId, "tblVoucherRow_colnProjectActivityId");
            this.tblVoucherRow_colnProjectActivityId.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVoucherRow_colnProjectActivityId_WindowActions);
            // 
            // tblVoucherRow_colAddInternal
            // 
            this.tblVoucherRow_colAddInternal.Name = "tblVoucherRow_colAddInternal";
            this.tblVoucherRow_colAddInternal.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colAddInternal.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colAddInternal.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colAddInternal.NamedProperties.Put("SqlColumn", "VOUCHER_ROW_API.Is_Add_Internal(COMPANY,INTERNAL_SEQ_NUMBER,ACCOUNT,VOUCHER_TYPE," +
                    "VOUCHER_NO,ACCOUNTING_YEAR)");
            this.tblVoucherRow_colAddInternal.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colAddInternal.Position = 54;
            resources.ApplyResources(this.tblVoucherRow_colAddInternal, "tblVoucherRow_colAddInternal");
            // 
            // tblVoucherRow_colsBaseCurrencyCode
            // 
            this.tblVoucherRow_colsBaseCurrencyCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblVoucherRow_colsBaseCurrencyCode, "tblVoucherRow_colsBaseCurrencyCode");
            this.tblVoucherRow_colsBaseCurrencyCode.MaxLength = 3;
            this.tblVoucherRow_colsBaseCurrencyCode.Name = "tblVoucherRow_colsBaseCurrencyCode";
            this.tblVoucherRow_colsBaseCurrencyCode.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colsBaseCurrencyCode.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colsBaseCurrencyCode.NamedProperties.Put("ParentName", "tblVoucherRow.tblVoucherRow_colsCompany");
            this.tblVoucherRow_colsBaseCurrencyCode.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colsBaseCurrencyCode.NamedProperties.Put("SqlColumn", "Company_Finance_API.Get_Currency_Code(VOUCHER_COMPANY)");
            this.tblVoucherRow_colsBaseCurrencyCode.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colsBaseCurrencyCode.Position = 55;
            this.tblVoucherRow_colsBaseCurrencyCode.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVoucherRow_colsBaseCurrencyCode_WindowActions);
            // 
            // tblVoucherRow_colnDecimalsInAmount
            // 
            this.tblVoucherRow_colnDecimalsInAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.tblVoucherRow_colnDecimalsInAmount, "tblVoucherRow_colnDecimalsInAmount");
            this.tblVoucherRow_colnDecimalsInAmount.Name = "tblVoucherRow_colnDecimalsInAmount";
            this.tblVoucherRow_colnDecimalsInAmount.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colnDecimalsInAmount.NamedProperties.Put("FieldFlags", "258");
            this.tblVoucherRow_colnDecimalsInAmount.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colnDecimalsInAmount.NamedProperties.Put("SqlColumn", "DECIMALS_IN_AMOUNT");
            this.tblVoucherRow_colnDecimalsInAmount.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colnDecimalsInAmount.Position = 56;
            // 
            // tblVoucherRow_colnAccDecimalsInAmount
            // 
            this.tblVoucherRow_colnAccDecimalsInAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.tblVoucherRow_colnAccDecimalsInAmount, "tblVoucherRow_colnAccDecimalsInAmount");
            this.tblVoucherRow_colnAccDecimalsInAmount.Name = "tblVoucherRow_colnAccDecimalsInAmount";
            this.tblVoucherRow_colnAccDecimalsInAmount.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colnAccDecimalsInAmount.NamedProperties.Put("FieldFlags", "258");
            this.tblVoucherRow_colnAccDecimalsInAmount.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colnAccDecimalsInAmount.NamedProperties.Put("SqlColumn", "ACC_DECIMALS_IN_AMOUNT");
            this.tblVoucherRow_colnAccDecimalsInAmount.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colnAccDecimalsInAmount.Position = 57;
            // 
            // tblVoucherRow_colsCodeDemand
            // 
            this.tblVoucherRow_colsCodeDemand.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblVoucherRow_colsCodeDemand, "tblVoucherRow_colsCodeDemand");
            this.tblVoucherRow_colsCodeDemand.MaxLength = 2000;
            this.tblVoucherRow_colsCodeDemand.Name = "tblVoucherRow_colsCodeDemand";
            this.tblVoucherRow_colsCodeDemand.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colsCodeDemand.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colsCodeDemand.NamedProperties.Put("ParentName", "tblVoucherRow.tblVoucherRow_colsAccount");
            this.tblVoucherRow_colsCodeDemand.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colsCodeDemand.NamedProperties.Put("SqlColumn", "Accounting_Code_Part_A_API.Get_Required_Code_Part(VOUCHER_COMPANY, ACCOUNT)");
            this.tblVoucherRow_colsCodeDemand.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colsCodeDemand.Position = 58;
            // 
            // tblVoucherRow_colsLedgerIds
            // 
            resources.ApplyResources(this.tblVoucherRow_colsLedgerIds, "tblVoucherRow_colsLedgerIds");
            this.tblVoucherRow_colsLedgerIds.Name = "tblVoucherRow_colsLedgerIds";
            this.tblVoucherRow_colsLedgerIds.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colsLedgerIds.NamedProperties.Put("FieldFlags", "768");
            this.tblVoucherRow_colsLedgerIds.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colsLedgerIds.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colsLedgerIds.NamedProperties.Put("SqlColumn", "LEDGER_IDS");
            this.tblVoucherRow_colsLedgerIds.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colsLedgerIds.Position = 59;
            // 
            // tblVoucherRow_colnCalculatedAmount
            // 
            this.tblVoucherRow_colnCalculatedAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.tblVoucherRow_colnCalculatedAmount, "tblVoucherRow_colnCalculatedAmount");
            this.tblVoucherRow_colnCalculatedAmount.Name = "tblVoucherRow_colnCalculatedAmount";
            this.tblVoucherRow_colnCalculatedAmount.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colnCalculatedAmount.NamedProperties.Put("Format", "20");
            this.tblVoucherRow_colnCalculatedAmount.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colnCalculatedAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colnCalculatedAmount.NamedProperties.Put("SqlColumn", "");
            this.tblVoucherRow_colnCalculatedAmount.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colnCalculatedAmount.Position = 60;
            this.tblVoucherRow_colnCalculatedAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tblVoucherRow_colsProjectActivityIdEnabled
            // 
            resources.ApplyResources(this.tblVoucherRow_colsProjectActivityIdEnabled, "tblVoucherRow_colsProjectActivityIdEnabled");
            this.tblVoucherRow_colsProjectActivityIdEnabled.MaxLength = 1;
            this.tblVoucherRow_colsProjectActivityIdEnabled.Name = "tblVoucherRow_colsProjectActivityIdEnabled";
            this.tblVoucherRow_colsProjectActivityIdEnabled.Position = 61;
            // 
            // tblVoucherRow_colsProjectId
            // 
            resources.ApplyResources(this.tblVoucherRow_colsProjectId, "tblVoucherRow_colsProjectId");
            this.tblVoucherRow_colsProjectId.MaxLength = 20;
            this.tblVoucherRow_colsProjectId.Name = "tblVoucherRow_colsProjectId";
            this.tblVoucherRow_colsProjectId.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colsProjectId.NamedProperties.Put("FieldFlags", "768");
            this.tblVoucherRow_colsProjectId.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colsProjectId.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colsProjectId.NamedProperties.Put("SqlColumn", "PROJECT_ID");
            this.tblVoucherRow_colsProjectId.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colsProjectId.Position = 62;
            // 
            // tblVoucherRow_colnInternalSeqNumber
            // 
            this.tblVoucherRow_colnInternalSeqNumber.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.tblVoucherRow_colnInternalSeqNumber, "tblVoucherRow_colnInternalSeqNumber");
            this.tblVoucherRow_colnInternalSeqNumber.Name = "tblVoucherRow_colnInternalSeqNumber";
            this.tblVoucherRow_colnInternalSeqNumber.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colnInternalSeqNumber.NamedProperties.Put("FieldFlags", "290");
            this.tblVoucherRow_colnInternalSeqNumber.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colnInternalSeqNumber.NamedProperties.Put("SqlColumn", "INTERNAL_SEQ_NUMBER");
            this.tblVoucherRow_colnInternalSeqNumber.Position = 63;
            // 
            // tblVoucherRow_colsManualAdded
            // 
            resources.ApplyResources(this.tblVoucherRow_colsManualAdded, "tblVoucherRow_colsManualAdded");
            this.tblVoucherRow_colsManualAdded.Name = "tblVoucherRow_colsManualAdded";
            this.tblVoucherRow_colsManualAdded.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colsManualAdded.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colsManualAdded.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colsManualAdded.NamedProperties.Put("SqlColumn", "VOUCHER_ROW_API.Is_Manual_Added(COMPANY,INTERNAL_SEQ_NUMBER,ACCOUNT)");
            this.tblVoucherRow_colsManualAdded.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colsManualAdded.Position = 64;
            // 
            // tblVoucherRow_colsReferenceSerie
            // 
            this.tblVoucherRow_colsReferenceSerie.MaxLength = 50;
            this.tblVoucherRow_colsReferenceSerie.Name = "tblVoucherRow_colsReferenceSerie";
            this.tblVoucherRow_colsReferenceSerie.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colsReferenceSerie.NamedProperties.Put("FieldFlags", "294");
            this.tblVoucherRow_colsReferenceSerie.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colsReferenceSerie.NamedProperties.Put("SqlColumn", "REFERENCE_SERIE");
            this.tblVoucherRow_colsReferenceSerie.Position = 65;
            resources.ApplyResources(this.tblVoucherRow_colsReferenceSerie, "tblVoucherRow_colsReferenceSerie");
            // 
            // tblVoucherRow_colsReferenceNumber
            // 
            this.tblVoucherRow_colsReferenceNumber.MaxLength = 50;
            this.tblVoucherRow_colsReferenceNumber.Name = "tblVoucherRow_colsReferenceNumber";
            this.tblVoucherRow_colsReferenceNumber.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colsReferenceNumber.NamedProperties.Put("FieldFlags", "294");
            this.tblVoucherRow_colsReferenceNumber.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colsReferenceNumber.NamedProperties.Put("SqlColumn", "REFERENCE_NUMBER");
            this.tblVoucherRow_colsReferenceNumber.Position = 66;
            resources.ApplyResources(this.tblVoucherRow_colsReferenceNumber, "tblVoucherRow_colsReferenceNumber");
            // 
            // tblVoucherRow_colnRowNo
            // 
            this.tblVoucherRow_colnRowNo.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.tblVoucherRow_colnRowNo, "tblVoucherRow_colnRowNo");
            this.tblVoucherRow_colnRowNo.Name = "tblVoucherRow_colnRowNo";
            this.tblVoucherRow_colnRowNo.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colnRowNo.NamedProperties.Put("FieldFlags", "160");
            this.tblVoucherRow_colnRowNo.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colnRowNo.NamedProperties.Put("SqlColumn", "ROW_NO");
            this.tblVoucherRow_colnRowNo.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colnRowNo.Position = 67;
            // 
            // tblVoucherRow_colsDuplicateRow
            // 
            this.tblVoucherRow_colsDuplicateRow.Name = "tblVoucherRow_colsDuplicateRow";
            this.tblVoucherRow_colsDuplicateRow.Position = 68;
            resources.ApplyResources(this.tblVoucherRow_colsDuplicateRow, "tblVoucherRow_colsDuplicateRow");
            this.tblVoucherRow_colsDuplicateRow.TitleAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // frmMCVoucherRow
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.tblVoucherRow);
            this.Controls.Add(this.dfnBalance);
            this.Controls.Add(this.dfnCurrencyBalance);
            this.Controls.Add(this.dfsVCCurrency);
            this.Controls.Add(this.cmbsVoucherCompany);
            this.Controls.Add(this.dfsCodePartDescription);
            this.Controls.Add(this.dfsCodePartValue);
            this.Controls.Add(this.labeldfnBalance);
            this.Controls.Add(this.labeldfnCurrencyBalance);
            this.Controls.Add(this.labeldfsVCCurrency);
            this.Controls.Add(this.labelcmbsVoucherCompany);
            this.Controls.Add(this.labeldfsCodePartDescription);
            this.Controls.Add(this.labeldfsCodePartValue);
            this.Name = "frmMCVoucherRow";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "");
            this.NamedProperties.Put("PackageName", "");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("ViewName", "");
            this.NamedProperties.Put("Warnings", "TRUE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.frmMCVoucherRow_WindowActions);
            this.tblVoucherRow.ResumeLayout(false);
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

        public cChildTableFin tblVoucherRow;
        protected cColumn tblVoucherRow_colsParentCompany;
        protected cColumn tblVoucherRow_colsVoucherType;
        protected cColumn tblVoucherRow_colnAccountingYear;
        protected cColumn tblVoucherRow_colnAccountingPeriod;
        protected cColumn tblVoucherRow_colnVoucherNo;
        public cColumn tblVoucherRow_colsCompany;
        protected cColumn tblVoucherRow_colnRowGroupId;
        public cColumnCodePartFin tblVoucherRow_colsAccount;
        protected cColumnCodePartDescFin tblVoucherRow_colsAccountDesc;
        protected cColumnCodePartFin tblVoucherRow_colsCodeB;
        protected cColumnCodePartDescFin tblVoucherRow_colsCodeBDesc;
        protected cColumnCodePartFin tblVoucherRow_colsCodeC;
        protected cColumnCodePartDescFin tblVoucherRow_colsCodeCDesc;
        protected cColumnCodePartFin tblVoucherRow_colsCodeD;
        protected cColumnCodePartDescFin tblVoucherRow_colsCodeDDesc;
        protected cColumnCodePartFin tblVoucherRow_colsCodeE;
        protected cColumnCodePartDescFin tblVoucherRow_colsCodeEDesc;
        protected cColumnCodePartFin tblVoucherRow_colsCodeF;
        protected cColumnCodePartDescFin tblVoucherRow_colsCodeFDesc;
        protected cColumnCodePartFin tblVoucherRow_colsCodeG;
        protected cColumnCodePartDescFin tblVoucherRow_colsCodeGDesc;
        protected cColumnCodePartFin tblVoucherRow_colsCodeH;
        protected cColumnCodePartDescFin tblVoucherRow_colsCodeHDesc;
        protected cColumnCodePartFin tblVoucherRow_colsCodeI;
        protected cColumnCodePartDescFin tblVoucherRow_colsCodeIDesc;
        protected cColumnCodePartFin tblVoucherRow_colsCodeJ;
        protected cColumnCodePartDescFin tblVoucherRow_colsCodeJDesc;
        protected cColumnCodePartFin tblVoucherRow_colsProcessCode;
        protected cColumn tblVoucherRow_colsCurrencyCode;
        protected cColumn tblVoucherRow_colsCurrencyType;
        protected cColumn tblVoucherRow_colnCurrencyDebitAmount;
        protected cColumn tblVoucherRow_colnCurrencyCreditAmount;
        public cColumn tblVoucherRow_colnCurrencyAmount;
        protected cColumn tblVoucherRow_colnCurrencyRate;
        protected cColumn tblVoucherRow_colnConversionFactor;
        protected cColumn tblVoucherRow_colnDebitAmount;
        protected cColumn tblVoucherRow_colnCreditAmount;
        public cColumn tblVoucherRow_colnAmount;
        protected cColumnCodePartFin tblVoucherRow_colnQuantity;
        protected cColumn tblVoucherRow_colsPeriodAllocation;
        protected cColumnCodePartFin tblVoucherRow_colsText;
        protected cColumn tblVoucherRow_colsOptionalCode;
        protected cColumn tblVoucherRow_colsUpdateError;
        protected cColumn tblVoucherRow_colsTransCode;
        protected cColumn tblVoucherRow_colsVoucherTypeCreated;
        protected cColumn tblVoucherRow_colnAccountingYearCreated;
        protected cColumn tblVoucherRow_colnVoucherNoCreated;
        protected cColumn tblVoucherRow_colnRowNoCreated;
        protected cColumn tblVoucherRow_colnProjectActivityId;
        public cCheckBoxColumn tblVoucherRow_colAddInternal;
        protected cColumn tblVoucherRow_colsBaseCurrencyCode;
        protected cColumn tblVoucherRow_colnDecimalsInAmount;
        protected cColumn tblVoucherRow_colnAccDecimalsInAmount;
        protected cColumn tblVoucherRow_colsCodeDemand;
        protected cColumn tblVoucherRow_colsLedgerIds;
        protected cColumn tblVoucherRow_colnCalculatedAmount;
        protected cColumn tblVoucherRow_colsProjectActivityIdEnabled;
        protected cColumn tblVoucherRow_colsProjectId;
        protected cColumn tblVoucherRow_colnInternalSeqNumber;
        public cCheckBoxColumn tblVoucherRow_colsManualAdded;
        protected cColumn tblVoucherRow_colsReferenceSerie;
        protected cColumn tblVoucherRow_colsReferenceNumber;
        protected cColumn tblVoucherRow_colnRowNo;
        protected cColumn tblVoucherRow_colsDeliveryTypeId;
        protected cColumn tblVoucherRow_colsDeliveryTypeDescription;
        public cColumn tblVoucherRow_colsDuplicateRow;
	}
}
