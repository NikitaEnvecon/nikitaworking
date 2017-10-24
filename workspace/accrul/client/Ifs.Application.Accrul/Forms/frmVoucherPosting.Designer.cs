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
	
	public partial class frmVoucherPosting
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVoucherPosting));
            this.menuTblMethods_menuInternal_Manual_Postings___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.labeldfsCodePartValue = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsCodePartValue = new Ifs.Application.Accrul.cDataFieldFinContent();
            this.labeldfsCodePartDescription = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsCodePartDescription = new Ifs.Application.Accrul.cDataFieldFinDescription();
            this.labeldfnCurrencyBalance = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfnCurrencyBalance = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfnBalance = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfnBalance = new Ifs.Fnd.ApplicationForms.cDataField();
            this.menuTblMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_Internal = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.labeldfnParallelCurrBalance = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfnParallelCurrBalance = new Ifs.Application.Accrul.cDataFieldFinEuro();
            this.tblVoucherPosting = new Ifs.Application.Accrul.cChildTableFin();
            this.tblVoucherPosting_colsCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherPosting_colsVoucherType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherPosting_colnAccountingYear = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherPosting_colnVoucherNo = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherPosting_colnRowNo = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherPosting_colnRowGroupId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherPosting_colsAccount = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.tblVoucherPosting_colsAccountDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.tblVoucherPosting_colsCodeB = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.tblVoucherPosting_colsCodeBDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.tblVoucherPosting_colsCodeC = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.tblVoucherPosting_colsCodeCDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.tblVoucherPosting_colsCodeD = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.tblVoucherPosting_colsCodeDDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.tblVoucherPosting_colsCodeE = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.tblVoucherPosting_colsCodeEDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.tblVoucherPosting_colsCodeF = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.tblVoucherPosting_colsCodeFDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.tblVoucherPosting_colsCodeG = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.tblVoucherPosting_colsCodeGDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.tblVoucherPosting_colsCodeH = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.tblVoucherPosting_colsCodeHDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.tblVoucherPosting_colsCodeI = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.tblVoucherPosting_colsCodeIDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.tblVoucherPosting_colsCodeJ = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.tblVoucherPosting_colsCodeJDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.tblVoucherPosting_colsProcessCode = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.tblVoucherPosting_colsDeliveryTypeId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherPosting_colsDeliveryTypeDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherPosting_colsOptionalCode = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherPosting_colsTaxDirection = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.tblVoucherPosting_colsCurrencyCode = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherPosting_colsCurrencyType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherPosting_colCorrection = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.tblVoucherPosting_colnCurrencyDebetAmount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherPosting_colnCurrencyCreditAmount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherPosting_colnCurrencyAmount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherPosting_colnCurrencyTaxAmount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherPosting_colnCurrencyGrossAmount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherPosting_colnCurrencyRate = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherPosting_colnConversionFactor = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherPosting_colnDebetAmount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherPosting_colnCreditAmount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherPosting_colnAmount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherPosting_colnTaxAmount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherPosting_colnGrossAmount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherPosting_colnParallelCurrRateType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherPosting_colnParallelCurrRate = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherPosting_colnParallelCurrConvFactor = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherPosting_colnThirdCurrencyDebitAmount = new Ifs.Application.Accrul.cColumnFinEuro();
            this.tblVoucherPosting_colnThirdCurrencyCreditAmount = new Ifs.Application.Accrul.cColumnFinEuro();
            this.tblVoucherPosting_colnThirdCurrencyAmount = new Ifs.Application.Accrul.cColumnFinEuro();
            this.tblVoucherPosting_colnParallelCurrTaxAmount = new Ifs.Application.Accrul.cColumnFinEuro();
            this.tblVoucherPosting_colnQuantity = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherPosting_colsPeriodAllocation = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.tblVoucherPosting_colsTextId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherPosting_colsText = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherPosting_colnProjectActivityId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherPosting_colsUpdateError = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherPosting_colsTransCode = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherPosting_colAddInternal = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.tblVoucherPosting_colnManualCounter = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherPosting_colsReferenceSerie = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherPosting_colsReferenceNumber = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherPosting_colnAccountingPeriod = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherPosting_colIsStatAccount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherPosting_colnDecimalsInAmount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherPosting_colnAccDecimalsInAmount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherPosting_colsCodeDemand = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherPosting_colsLedgerIds = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherPosting_colsAutoTaxVouEntry = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherPosting_colnReferenceRowNo = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherPosting_colsPrevAccount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherPosting_colsPrevTaxCode = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherPosting_colsPrevCurrencyCode = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherPosting_colnPrevAmount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherPosting_colnPrevCurrencyAmount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherPosting_colsTaxType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherPosting_colsProjectActivityIdEnabled = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherPosting_colsProjectId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherPosting_colnInternalSeqNumber = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherPosting_colsManualAdded = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.tblVoucherPosting_colsFunctionGroup = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherPosting_colnActCurrencyRate = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherPosting_colsTransferId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherPosting_colnParallelCurrTaxBaseAmount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherPosting_colnParallelCurrGrossAmount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.menuTblMethods.SuspendLayout();
            this.tblVoucherPosting.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuTblMethods_menuInternal_Manual_Postings___);
            this.commandManager.ContextMenus.Add(this.menuTblMethods);
            // 
            // menuTblMethods_menuInternal_Manual_Postings___
            // 
            resources.ApplyResources(this.menuTblMethods_menuInternal_Manual_Postings___, "menuTblMethods_menuInternal_Manual_Postings___");
            this.menuTblMethods_menuInternal_Manual_Postings___.Name = "menuTblMethods_menuInternal_Manual_Postings___";
            this.menuTblMethods_menuInternal_Manual_Postings___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Internal_Execute);
            this.menuTblMethods_menuInternal_Manual_Postings___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Internal_Inquire);
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
            // menuTblMethods
            // 
            this.menuTblMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_Internal});
            this.menuTblMethods.Name = "menuTblMethods";
            resources.ApplyResources(this.menuTblMethods, "menuTblMethods");
            // 
            // menuItem_Internal
            // 
            this.menuItem_Internal.Command = this.menuTblMethods_menuInternal_Manual_Postings___;
            this.menuItem_Internal.Name = "menuItem_Internal";
            resources.ApplyResources(this.menuItem_Internal, "menuItem_Internal");
            this.menuItem_Internal.Text = "Internal Manual Postings...";
            // 
            // labeldfnParallelCurrBalance
            // 
            resources.ApplyResources(this.labeldfnParallelCurrBalance, "labeldfnParallelCurrBalance");
            this.labeldfnParallelCurrBalance.Name = "labeldfnParallelCurrBalance";
            // 
            // dfnParallelCurrBalance
            // 
            this.dfnParallelCurrBalance.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfnParallelCurrBalance, "dfnParallelCurrBalance");
            this.dfnParallelCurrBalance.Name = "dfnParallelCurrBalance";
            this.dfnParallelCurrBalance.NamedProperties.Put("EnumerateMethod", "");
            this.dfnParallelCurrBalance.NamedProperties.Put("Format", "20");
            this.dfnParallelCurrBalance.NamedProperties.Put("LovReference", "");
            this.dfnParallelCurrBalance.NamedProperties.Put("ResizeableChildObject", "");
            this.dfnParallelCurrBalance.NamedProperties.Put("SqlColumn", "");
            this.dfnParallelCurrBalance.NamedProperties.Put("ValidateMethod", "");
            // 
            // tblVoucherPosting
            // 
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colsCompany);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colsVoucherType);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colnAccountingYear);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colnVoucherNo);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colnRowNo);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colnRowGroupId);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colsAccount);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colsAccountDesc);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colsCodeB);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colsCodeBDesc);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colsCodeC);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colsCodeCDesc);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colsCodeD);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colsCodeDDesc);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colsCodeE);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colsCodeEDesc);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colsCodeF);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colsCodeFDesc);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colsCodeG);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colsCodeGDesc);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colsCodeH);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colsCodeHDesc);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colsCodeI);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colsCodeIDesc);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colsCodeJ);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colsCodeJDesc);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colsProcessCode);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colsDeliveryTypeId);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colsDeliveryTypeDescription);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colsOptionalCode);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colsTaxDirection);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colsCurrencyCode);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colsCurrencyType);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colCorrection);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colnCurrencyDebetAmount);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colnCurrencyCreditAmount);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colnCurrencyAmount);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colnCurrencyTaxAmount);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colnCurrencyGrossAmount);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colnCurrencyRate);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colnConversionFactor);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colnDebetAmount);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colnCreditAmount);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colnAmount);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colnTaxAmount);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colnGrossAmount);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colnParallelCurrRateType);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colnParallelCurrRate);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colnParallelCurrConvFactor);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colnThirdCurrencyDebitAmount);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colnThirdCurrencyCreditAmount);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colnThirdCurrencyAmount);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colnParallelCurrTaxAmount);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colnQuantity);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colsPeriodAllocation);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colsTextId);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colsText);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colnProjectActivityId);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colsUpdateError);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colsTransCode);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colAddInternal);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colnManualCounter);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colsReferenceSerie);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colsReferenceNumber);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colnAccountingPeriod);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colIsStatAccount);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colnDecimalsInAmount);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colnAccDecimalsInAmount);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colsCodeDemand);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colsLedgerIds);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colsAutoTaxVouEntry);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colnReferenceRowNo);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colsPrevAccount);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colsPrevTaxCode);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colsPrevCurrencyCode);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colnPrevAmount);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colnPrevCurrencyAmount);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colsTaxType);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colsProjectActivityIdEnabled);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colsProjectId);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colnInternalSeqNumber);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colsManualAdded);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colsFunctionGroup);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colnActCurrencyRate);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colsTransferId);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colnParallelCurrTaxBaseAmount);
            this.tblVoucherPosting.Controls.Add(this.tblVoucherPosting_colnParallelCurrGrossAmount);
            resources.ApplyResources(this.tblVoucherPosting, "tblVoucherPosting");
            this.tblVoucherPosting.Name = "tblVoucherPosting";
            this.tblVoucherPosting.NamedProperties.Put("DefaultOrderBy", "ROW_NO");
            this.tblVoucherPosting.NamedProperties.Put("DefaultWhere", "AUTO_TAX_VOU_ENTRY = \'FALSE\'");
            this.tblVoucherPosting.NamedProperties.Put("LogicalUnit", "VoucherRow");
            this.tblVoucherPosting.NamedProperties.Put("PackageName", "VOUCHER_ROW_API");
            this.tblVoucherPosting.NamedProperties.Put("ResizeableChildObject", "LLMM");
            this.tblVoucherPosting.NamedProperties.Put("SourceFlags", "16833");
            this.tblVoucherPosting.NamedProperties.Put("ViewName", "VOUCHER_ROW");
            this.tblVoucherPosting.NamedProperties.Put("Warnings", "FALSE");
            this.tblVoucherPosting.EnableDisableProjectActivityIdEvent += new System.EventHandler<Ifs.Application.Accrul.cChildTableFin.cChildTableFinEventArgs>(this.tblVoucherPosting_EnableDisableProjectActivityIdEvent);
            this.tblVoucherPosting.DataSourceFormatSqlColumnUserEvent += new System.EventHandler<Ifs.Fnd.ApplicationForms.FndReturnEventArgsSalString>(this.tblVoucherPosting_DataSourceFormatSqlColumnUserEvent);
            this.tblVoucherPosting.DataSourceFormatSqlIntoUserEvent += new System.EventHandler<Ifs.Fnd.ApplicationForms.FndReturnEventArgsSalString>(this.tblVoucherPosting_DataSourceFormatSqlIntoUserEvent);
            this.tblVoucherPosting.DataRecordCheckRequiredEvent += new System.EventHandler<Ifs.Fnd.ApplicationForms.FndReturnEventArgsSalBoolean>(this.tblVoucherPosting_DataRecordCheckRequiredEvent);
            this.tblVoucherPosting.DataRecordDuplicateEvent += new Ifs.Fnd.ApplicationForms.cDataSource.DataRecordDuplicateEventHandler(this.tblVoucherPosting_DataRecordDuplicateEvent);
            this.tblVoucherPosting.DataRecordExecuteModifyEvent += new Ifs.Fnd.ApplicationForms.cDataSource.DataRecordExecuteModifyEventHandler(this.tblVoucherPosting_DataRecordExecuteModifyEvent);
            this.tblVoucherPosting.DataRecordExecuteRemoveEvent += new Ifs.Fnd.ApplicationForms.cDataSource.DataRecordExecuteRemoveEventHandler(this.tblVoucherPosting_DataRecordExecuteRemoveEvent);
            this.tblVoucherPosting.DataRecordGetDefaultsEvent += new System.EventHandler<Ifs.Fnd.ApplicationForms.FndReturnEventArgsSalBoolean>(this.tblVoucherPosting_DataRecordGetDefaultsEvent);
            this.tblVoucherPosting.DataRecordNewEvent += new Ifs.Fnd.ApplicationForms.cDataSource.DataRecordNewEventHandler(this.tblVoucherPosting_DataRecordNewEvent);
            this.tblVoucherPosting.DataRecordRemoveEvent += new Ifs.Fnd.ApplicationForms.cDataSource.DataRecordRemoveEventHandler(this.tblVoucherPosting_DataRecordRemoveEvent);
            this.tblVoucherPosting.DataRecordValidateEvent += new System.EventHandler<Ifs.Fnd.ApplicationForms.FndReturnEventArgsSalBoolean>(this.tblVoucherPosting_DataRecordValidateEvent);
            this.tblVoucherPosting.DataSourceSaveCheckEvent += new System.EventHandler<Ifs.Fnd.ApplicationForms.FndReturnEventArgsSalBoolean>(this.tblVoucherPosting_DataSourceSaveCheckEvent);
            this.tblVoucherPosting.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVoucherPosting_WindowActions);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colnParallelCurrGrossAmount, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colnParallelCurrTaxBaseAmount, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colsTransferId, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colnActCurrencyRate, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colsFunctionGroup, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colsManualAdded, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colnInternalSeqNumber, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colsProjectId, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colsProjectActivityIdEnabled, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colsTaxType, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colnPrevCurrencyAmount, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colnPrevAmount, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colsPrevCurrencyCode, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colsPrevTaxCode, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colsPrevAccount, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colnReferenceRowNo, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colsAutoTaxVouEntry, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colsLedgerIds, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colsCodeDemand, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colnAccDecimalsInAmount, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colnDecimalsInAmount, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colIsStatAccount, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colnAccountingPeriod, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colsReferenceNumber, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colsReferenceSerie, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colnManualCounter, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colAddInternal, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colsTransCode, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colsUpdateError, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colnProjectActivityId, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colsText, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colsTextId, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colsPeriodAllocation, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colnQuantity, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colnParallelCurrTaxAmount, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colnThirdCurrencyAmount, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colnThirdCurrencyCreditAmount, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colnThirdCurrencyDebitAmount, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colnParallelCurrConvFactor, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colnParallelCurrRate, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colnParallelCurrRateType, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colnGrossAmount, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colnTaxAmount, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colnAmount, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colnCreditAmount, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colnDebetAmount, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colnConversionFactor, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colnCurrencyRate, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colnCurrencyGrossAmount, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colnCurrencyTaxAmount, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colnCurrencyAmount, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colnCurrencyCreditAmount, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colnCurrencyDebetAmount, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colCorrection, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colsCurrencyType, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colsCurrencyCode, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colsTaxDirection, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colsOptionalCode, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colsDeliveryTypeDescription, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colsDeliveryTypeId, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colsProcessCode, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colsCodeJDesc, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colsCodeJ, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colsCodeIDesc, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colsCodeI, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colsCodeHDesc, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colsCodeH, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colsCodeGDesc, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colsCodeG, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colsCodeFDesc, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colsCodeF, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colsCodeEDesc, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colsCodeE, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colsCodeDDesc, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colsCodeD, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colsCodeCDesc, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colsCodeC, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colsCodeBDesc, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colsCodeB, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colsAccountDesc, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colsAccount, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colnRowGroupId, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colnRowNo, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colnVoucherNo, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colnAccountingYear, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colsVoucherType, 0);
            this.tblVoucherPosting.Controls.SetChildIndex(this.tblVoucherPosting_colsCompany, 0);
            // 
            // tblVoucherPosting_colsCompany
            // 
            resources.ApplyResources(this.tblVoucherPosting_colsCompany, "tblVoucherPosting_colsCompany");
            this.tblVoucherPosting_colsCompany.MaxLength = 20;
            this.tblVoucherPosting_colsCompany.Name = "tblVoucherPosting_colsCompany";
            this.tblVoucherPosting_colsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colsCompany.NamedProperties.Put("FieldFlags", "67");
            this.tblVoucherPosting_colsCompany.NamedProperties.Put("LovReference", "");
            this.tblVoucherPosting_colsCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherPosting_colsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.tblVoucherPosting_colsCompany.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherPosting_colsCompany.Position = 3;
            // 
            // tblVoucherPosting_colsVoucherType
            // 
            resources.ApplyResources(this.tblVoucherPosting_colsVoucherType, "tblVoucherPosting_colsVoucherType");
            this.tblVoucherPosting_colsVoucherType.MaxLength = 3;
            this.tblVoucherPosting_colsVoucherType.Name = "tblVoucherPosting_colsVoucherType";
            this.tblVoucherPosting_colsVoucherType.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colsVoucherType.NamedProperties.Put("FieldFlags", "67");
            this.tblVoucherPosting_colsVoucherType.NamedProperties.Put("LovReference", "");
            this.tblVoucherPosting_colsVoucherType.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherPosting_colsVoucherType.NamedProperties.Put("SqlColumn", "VOUCHER_TYPE");
            this.tblVoucherPosting_colsVoucherType.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherPosting_colsVoucherType.Position = 4;
            // 
            // tblVoucherPosting_colnAccountingYear
            // 
            this.tblVoucherPosting_colnAccountingYear.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.tblVoucherPosting_colnAccountingYear, "tblVoucherPosting_colnAccountingYear");
            this.tblVoucherPosting_colnAccountingYear.MaxLength = 4;
            this.tblVoucherPosting_colnAccountingYear.Name = "tblVoucherPosting_colnAccountingYear";
            this.tblVoucherPosting_colnAccountingYear.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colnAccountingYear.NamedProperties.Put("FieldFlags", "67");
            this.tblVoucherPosting_colnAccountingYear.NamedProperties.Put("LovReference", "");
            this.tblVoucherPosting_colnAccountingYear.NamedProperties.Put("SqlColumn", "ACCOUNTING_YEAR");
            this.tblVoucherPosting_colnAccountingYear.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherPosting_colnAccountingYear.Position = 5;
            // 
            // tblVoucherPosting_colnVoucherNo
            // 
            this.tblVoucherPosting_colnVoucherNo.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.tblVoucherPosting_colnVoucherNo, "tblVoucherPosting_colnVoucherNo");
            this.tblVoucherPosting_colnVoucherNo.MaxLength = 10;
            this.tblVoucherPosting_colnVoucherNo.Name = "tblVoucherPosting_colnVoucherNo";
            this.tblVoucherPosting_colnVoucherNo.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colnVoucherNo.NamedProperties.Put("FieldFlags", "67");
            this.tblVoucherPosting_colnVoucherNo.NamedProperties.Put("LovReference", "");
            this.tblVoucherPosting_colnVoucherNo.NamedProperties.Put("SqlColumn", "VOUCHER_NO");
            this.tblVoucherPosting_colnVoucherNo.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherPosting_colnVoucherNo.Position = 6;
            // 
            // tblVoucherPosting_colnRowNo
            // 
            this.tblVoucherPosting_colnRowNo.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.tblVoucherPosting_colnRowNo, "tblVoucherPosting_colnRowNo");
            this.tblVoucherPosting_colnRowNo.Name = "tblVoucherPosting_colnRowNo";
            this.tblVoucherPosting_colnRowNo.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colnRowNo.NamedProperties.Put("FieldFlags", "132");
            this.tblVoucherPosting_colnRowNo.NamedProperties.Put("LovReference", "");
            this.tblVoucherPosting_colnRowNo.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherPosting_colnRowNo.NamedProperties.Put("SqlColumn", "ROW_NO");
            this.tblVoucherPosting_colnRowNo.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherPosting_colnRowNo.Position = 7;
            // 
            // tblVoucherPosting_colnRowGroupId
            // 
            this.tblVoucherPosting_colnRowGroupId.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVoucherPosting_colnRowGroupId.MaxLength = 4;
            this.tblVoucherPosting_colnRowGroupId.Name = "tblVoucherPosting_colnRowGroupId";
            this.tblVoucherPosting_colnRowGroupId.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colnRowGroupId.NamedProperties.Put("FieldFlags", "294");
            this.tblVoucherPosting_colnRowGroupId.NamedProperties.Put("LovReference", "");
            this.tblVoucherPosting_colnRowGroupId.NamedProperties.Put("SqlColumn", "ROW_GROUP_ID");
            this.tblVoucherPosting_colnRowGroupId.Position = 8;
            resources.ApplyResources(this.tblVoucherPosting_colnRowGroupId, "tblVoucherPosting_colnRowGroupId");
            this.tblVoucherPosting_colnRowGroupId.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVoucherPosting_colnRowGroupId_WindowActions);
            // 
            // tblVoucherPosting_colsAccount
            // 
            this.tblVoucherPosting_colsAccount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblVoucherPosting_colsAccount.MaxLength = 20;
            this.tblVoucherPosting_colsAccount.Name = "tblVoucherPosting_colsAccount";
            this.tblVoucherPosting_colsAccount.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colsAccount.NamedProperties.Put("FieldFlags", "295");
            this.tblVoucherPosting_colsAccount.NamedProperties.Put("LovReference", "ACCOUNT_LOV(COMPANY)");
            this.tblVoucherPosting_colsAccount.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherPosting_colsAccount.NamedProperties.Put("SqlColumn", "ACCOUNT");
            this.tblVoucherPosting_colsAccount.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherPosting_colsAccount.Position = 9;
            resources.ApplyResources(this.tblVoucherPosting_colsAccount, "tblVoucherPosting_colsAccount");
            this.tblVoucherPosting_colsAccount.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVoucherPosting_colsAccount_WindowActions);
            // 
            // tblVoucherPosting_colsAccountDesc
            // 
            resources.ApplyResources(this.tblVoucherPosting_colsAccountDesc, "tblVoucherPosting_colsAccountDesc");
            this.tblVoucherPosting_colsAccountDesc.Name = "tblVoucherPosting_colsAccountDesc";
            this.tblVoucherPosting_colsAccountDesc.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colsAccountDesc.NamedProperties.Put("LovReference", "");
            this.tblVoucherPosting_colsAccountDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherPosting_colsAccountDesc.NamedProperties.Put("SqlColumn", "ACCOUNT_DESC");
            this.tblVoucherPosting_colsAccountDesc.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherPosting_colsAccountDesc.Position = 10;
            // 
            // tblVoucherPosting_colsCodeB
            // 
            this.tblVoucherPosting_colsCodeB.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblVoucherPosting_colsCodeB.MaxLength = 20;
            this.tblVoucherPosting_colsCodeB.Name = "tblVoucherPosting_colsCodeB";
            this.tblVoucherPosting_colsCodeB.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colsCodeB.NamedProperties.Put("FieldFlags", "294");
            this.tblVoucherPosting_colsCodeB.NamedProperties.Put("LovReference", "CODE_B(COMPANY)");
            this.tblVoucherPosting_colsCodeB.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherPosting_colsCodeB.NamedProperties.Put("SqlColumn", "CODE_B");
            this.tblVoucherPosting_colsCodeB.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherPosting_colsCodeB.Position = 11;
            resources.ApplyResources(this.tblVoucherPosting_colsCodeB, "tblVoucherPosting_colsCodeB");
            this.tblVoucherPosting_colsCodeB.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVoucherPosting_colsCodeB_WindowActions);
            // 
            // tblVoucherPosting_colsCodeBDesc
            // 
            resources.ApplyResources(this.tblVoucherPosting_colsCodeBDesc, "tblVoucherPosting_colsCodeBDesc");
            this.tblVoucherPosting_colsCodeBDesc.Name = "tblVoucherPosting_colsCodeBDesc";
            this.tblVoucherPosting_colsCodeBDesc.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colsCodeBDesc.NamedProperties.Put("LovReference", "");
            this.tblVoucherPosting_colsCodeBDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherPosting_colsCodeBDesc.NamedProperties.Put("SqlColumn", "CODE_B_DESC");
            this.tblVoucherPosting_colsCodeBDesc.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherPosting_colsCodeBDesc.Position = 12;
            // 
            // tblVoucherPosting_colsCodeC
            // 
            this.tblVoucherPosting_colsCodeC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblVoucherPosting_colsCodeC.MaxLength = 20;
            this.tblVoucherPosting_colsCodeC.Name = "tblVoucherPosting_colsCodeC";
            this.tblVoucherPosting_colsCodeC.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colsCodeC.NamedProperties.Put("FieldFlags", "294");
            this.tblVoucherPosting_colsCodeC.NamedProperties.Put("LovReference", "CODE_C(COMPANY)");
            this.tblVoucherPosting_colsCodeC.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherPosting_colsCodeC.NamedProperties.Put("SqlColumn", "CODE_C");
            this.tblVoucherPosting_colsCodeC.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherPosting_colsCodeC.Position = 13;
            resources.ApplyResources(this.tblVoucherPosting_colsCodeC, "tblVoucherPosting_colsCodeC");
            this.tblVoucherPosting_colsCodeC.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVoucherPosting_colsCodeC_WindowActions);
            // 
            // tblVoucherPosting_colsCodeCDesc
            // 
            resources.ApplyResources(this.tblVoucherPosting_colsCodeCDesc, "tblVoucherPosting_colsCodeCDesc");
            this.tblVoucherPosting_colsCodeCDesc.Name = "tblVoucherPosting_colsCodeCDesc";
            this.tblVoucherPosting_colsCodeCDesc.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colsCodeCDesc.NamedProperties.Put("LovReference", "");
            this.tblVoucherPosting_colsCodeCDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherPosting_colsCodeCDesc.NamedProperties.Put("SqlColumn", "CODE_C_DESC");
            this.tblVoucherPosting_colsCodeCDesc.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherPosting_colsCodeCDesc.Position = 14;
            // 
            // tblVoucherPosting_colsCodeD
            // 
            this.tblVoucherPosting_colsCodeD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblVoucherPosting_colsCodeD.MaxLength = 20;
            this.tblVoucherPosting_colsCodeD.Name = "tblVoucherPosting_colsCodeD";
            this.tblVoucherPosting_colsCodeD.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colsCodeD.NamedProperties.Put("FieldFlags", "294");
            this.tblVoucherPosting_colsCodeD.NamedProperties.Put("LovReference", "CODE_D(COMPANY)");
            this.tblVoucherPosting_colsCodeD.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherPosting_colsCodeD.NamedProperties.Put("SqlColumn", "CODE_D");
            this.tblVoucherPosting_colsCodeD.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherPosting_colsCodeD.Position = 15;
            resources.ApplyResources(this.tblVoucherPosting_colsCodeD, "tblVoucherPosting_colsCodeD");
            this.tblVoucherPosting_colsCodeD.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVoucherPosting_colsCodeD_WindowActions);
            // 
            // tblVoucherPosting_colsCodeDDesc
            // 
            resources.ApplyResources(this.tblVoucherPosting_colsCodeDDesc, "tblVoucherPosting_colsCodeDDesc");
            this.tblVoucherPosting_colsCodeDDesc.Name = "tblVoucherPosting_colsCodeDDesc";
            this.tblVoucherPosting_colsCodeDDesc.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colsCodeDDesc.NamedProperties.Put("LovReference", "");
            this.tblVoucherPosting_colsCodeDDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherPosting_colsCodeDDesc.NamedProperties.Put("SqlColumn", "CODE_D_DESC");
            this.tblVoucherPosting_colsCodeDDesc.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherPosting_colsCodeDDesc.Position = 16;
            // 
            // tblVoucherPosting_colsCodeE
            // 
            this.tblVoucherPosting_colsCodeE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblVoucherPosting_colsCodeE.MaxLength = 20;
            this.tblVoucherPosting_colsCodeE.Name = "tblVoucherPosting_colsCodeE";
            this.tblVoucherPosting_colsCodeE.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colsCodeE.NamedProperties.Put("FieldFlags", "294");
            this.tblVoucherPosting_colsCodeE.NamedProperties.Put("LovReference", "CODE_E(COMPANY)");
            this.tblVoucherPosting_colsCodeE.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherPosting_colsCodeE.NamedProperties.Put("SqlColumn", "CODE_E");
            this.tblVoucherPosting_colsCodeE.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherPosting_colsCodeE.Position = 17;
            resources.ApplyResources(this.tblVoucherPosting_colsCodeE, "tblVoucherPosting_colsCodeE");
            this.tblVoucherPosting_colsCodeE.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVoucherPosting_colsCodeE_WindowActions);
            // 
            // tblVoucherPosting_colsCodeEDesc
            // 
            resources.ApplyResources(this.tblVoucherPosting_colsCodeEDesc, "tblVoucherPosting_colsCodeEDesc");
            this.tblVoucherPosting_colsCodeEDesc.Name = "tblVoucherPosting_colsCodeEDesc";
            this.tblVoucherPosting_colsCodeEDesc.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colsCodeEDesc.NamedProperties.Put("LovReference", "");
            this.tblVoucherPosting_colsCodeEDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherPosting_colsCodeEDesc.NamedProperties.Put("SqlColumn", "CODE_E_DESC");
            this.tblVoucherPosting_colsCodeEDesc.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherPosting_colsCodeEDesc.Position = 18;
            // 
            // tblVoucherPosting_colsCodeF
            // 
            this.tblVoucherPosting_colsCodeF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblVoucherPosting_colsCodeF.MaxLength = 20;
            this.tblVoucherPosting_colsCodeF.Name = "tblVoucherPosting_colsCodeF";
            this.tblVoucherPosting_colsCodeF.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colsCodeF.NamedProperties.Put("FieldFlags", "294");
            this.tblVoucherPosting_colsCodeF.NamedProperties.Put("LovReference", "CODE_F(COMPANY)");
            this.tblVoucherPosting_colsCodeF.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherPosting_colsCodeF.NamedProperties.Put("SqlColumn", "CODE_F");
            this.tblVoucherPosting_colsCodeF.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherPosting_colsCodeF.Position = 19;
            resources.ApplyResources(this.tblVoucherPosting_colsCodeF, "tblVoucherPosting_colsCodeF");
            this.tblVoucherPosting_colsCodeF.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVoucherPosting_colsCodeF_WindowActions);
            // 
            // tblVoucherPosting_colsCodeFDesc
            // 
            resources.ApplyResources(this.tblVoucherPosting_colsCodeFDesc, "tblVoucherPosting_colsCodeFDesc");
            this.tblVoucherPosting_colsCodeFDesc.Name = "tblVoucherPosting_colsCodeFDesc";
            this.tblVoucherPosting_colsCodeFDesc.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colsCodeFDesc.NamedProperties.Put("LovReference", "");
            this.tblVoucherPosting_colsCodeFDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherPosting_colsCodeFDesc.NamedProperties.Put("SqlColumn", "CODE_F_DESC");
            this.tblVoucherPosting_colsCodeFDesc.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherPosting_colsCodeFDesc.Position = 20;
            // 
            // tblVoucherPosting_colsCodeG
            // 
            this.tblVoucherPosting_colsCodeG.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblVoucherPosting_colsCodeG.MaxLength = 20;
            this.tblVoucherPosting_colsCodeG.Name = "tblVoucherPosting_colsCodeG";
            this.tblVoucherPosting_colsCodeG.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colsCodeG.NamedProperties.Put("FieldFlags", "294");
            this.tblVoucherPosting_colsCodeG.NamedProperties.Put("LovReference", "CODE_G(COMPANY)");
            this.tblVoucherPosting_colsCodeG.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherPosting_colsCodeG.NamedProperties.Put("SqlColumn", "CODE_G");
            this.tblVoucherPosting_colsCodeG.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherPosting_colsCodeG.Position = 21;
            resources.ApplyResources(this.tblVoucherPosting_colsCodeG, "tblVoucherPosting_colsCodeG");
            this.tblVoucherPosting_colsCodeG.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVoucherPosting_colsCodeG_WindowActions);
            // 
            // tblVoucherPosting_colsCodeGDesc
            // 
            resources.ApplyResources(this.tblVoucherPosting_colsCodeGDesc, "tblVoucherPosting_colsCodeGDesc");
            this.tblVoucherPosting_colsCodeGDesc.Name = "tblVoucherPosting_colsCodeGDesc";
            this.tblVoucherPosting_colsCodeGDesc.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colsCodeGDesc.NamedProperties.Put("LovReference", "");
            this.tblVoucherPosting_colsCodeGDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherPosting_colsCodeGDesc.NamedProperties.Put("SqlColumn", "CODE_G_DESC");
            this.tblVoucherPosting_colsCodeGDesc.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherPosting_colsCodeGDesc.Position = 22;
            // 
            // tblVoucherPosting_colsCodeH
            // 
            this.tblVoucherPosting_colsCodeH.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblVoucherPosting_colsCodeH.MaxLength = 20;
            this.tblVoucherPosting_colsCodeH.Name = "tblVoucherPosting_colsCodeH";
            this.tblVoucherPosting_colsCodeH.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colsCodeH.NamedProperties.Put("FieldFlags", "294");
            this.tblVoucherPosting_colsCodeH.NamedProperties.Put("LovReference", "CODE_H(COMPANY)");
            this.tblVoucherPosting_colsCodeH.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherPosting_colsCodeH.NamedProperties.Put("SqlColumn", "CODE_H");
            this.tblVoucherPosting_colsCodeH.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherPosting_colsCodeH.Position = 23;
            resources.ApplyResources(this.tblVoucherPosting_colsCodeH, "tblVoucherPosting_colsCodeH");
            this.tblVoucherPosting_colsCodeH.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVoucherPosting_colsCodeH_WindowActions);
            // 
            // tblVoucherPosting_colsCodeHDesc
            // 
            resources.ApplyResources(this.tblVoucherPosting_colsCodeHDesc, "tblVoucherPosting_colsCodeHDesc");
            this.tblVoucherPosting_colsCodeHDesc.Name = "tblVoucherPosting_colsCodeHDesc";
            this.tblVoucherPosting_colsCodeHDesc.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colsCodeHDesc.NamedProperties.Put("LovReference", "");
            this.tblVoucherPosting_colsCodeHDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherPosting_colsCodeHDesc.NamedProperties.Put("SqlColumn", "CODE_H_DESC");
            this.tblVoucherPosting_colsCodeHDesc.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherPosting_colsCodeHDesc.Position = 24;
            // 
            // tblVoucherPosting_colsCodeI
            // 
            this.tblVoucherPosting_colsCodeI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblVoucherPosting_colsCodeI.MaxLength = 20;
            this.tblVoucherPosting_colsCodeI.Name = "tblVoucherPosting_colsCodeI";
            this.tblVoucherPosting_colsCodeI.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colsCodeI.NamedProperties.Put("FieldFlags", "294");
            this.tblVoucherPosting_colsCodeI.NamedProperties.Put("LovReference", "CODE_I(COMPANY)");
            this.tblVoucherPosting_colsCodeI.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherPosting_colsCodeI.NamedProperties.Put("SqlColumn", "CODE_I");
            this.tblVoucherPosting_colsCodeI.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherPosting_colsCodeI.Position = 25;
            resources.ApplyResources(this.tblVoucherPosting_colsCodeI, "tblVoucherPosting_colsCodeI");
            this.tblVoucherPosting_colsCodeI.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVoucherPosting_colsCodeI_WindowActions);
            // 
            // tblVoucherPosting_colsCodeIDesc
            // 
            resources.ApplyResources(this.tblVoucherPosting_colsCodeIDesc, "tblVoucherPosting_colsCodeIDesc");
            this.tblVoucherPosting_colsCodeIDesc.Name = "tblVoucherPosting_colsCodeIDesc";
            this.tblVoucherPosting_colsCodeIDesc.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colsCodeIDesc.NamedProperties.Put("LovReference", "");
            this.tblVoucherPosting_colsCodeIDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherPosting_colsCodeIDesc.NamedProperties.Put("SqlColumn", "CODE_I_DESC");
            this.tblVoucherPosting_colsCodeIDesc.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherPosting_colsCodeIDesc.Position = 26;
            // 
            // tblVoucherPosting_colsCodeJ
            // 
            this.tblVoucherPosting_colsCodeJ.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblVoucherPosting_colsCodeJ.MaxLength = 20;
            this.tblVoucherPosting_colsCodeJ.Name = "tblVoucherPosting_colsCodeJ";
            this.tblVoucherPosting_colsCodeJ.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colsCodeJ.NamedProperties.Put("FieldFlags", "294");
            this.tblVoucherPosting_colsCodeJ.NamedProperties.Put("LovReference", "CODE_J(COMPANY)");
            this.tblVoucherPosting_colsCodeJ.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherPosting_colsCodeJ.NamedProperties.Put("SqlColumn", "CODE_J");
            this.tblVoucherPosting_colsCodeJ.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherPosting_colsCodeJ.Position = 27;
            resources.ApplyResources(this.tblVoucherPosting_colsCodeJ, "tblVoucherPosting_colsCodeJ");
            this.tblVoucherPosting_colsCodeJ.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVoucherPosting_colsCodeJ_WindowActions);
            // 
            // tblVoucherPosting_colsCodeJDesc
            // 
            resources.ApplyResources(this.tblVoucherPosting_colsCodeJDesc, "tblVoucherPosting_colsCodeJDesc");
            this.tblVoucherPosting_colsCodeJDesc.Name = "tblVoucherPosting_colsCodeJDesc";
            this.tblVoucherPosting_colsCodeJDesc.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colsCodeJDesc.NamedProperties.Put("LovReference", "");
            this.tblVoucherPosting_colsCodeJDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherPosting_colsCodeJDesc.NamedProperties.Put("SqlColumn", "CODE_J_DESC");
            this.tblVoucherPosting_colsCodeJDesc.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherPosting_colsCodeJDesc.Position = 28;
            // 
            // tblVoucherPosting_colsProcessCode
            // 
            this.tblVoucherPosting_colsProcessCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblVoucherPosting_colsProcessCode.MaxLength = 10;
            this.tblVoucherPosting_colsProcessCode.Name = "tblVoucherPosting_colsProcessCode";
            this.tblVoucherPosting_colsProcessCode.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colsProcessCode.NamedProperties.Put("FieldFlags", "294");
            this.tblVoucherPosting_colsProcessCode.NamedProperties.Put("LovReference", "ACCOUNT_PROCESS_CODE(COMPANY)");
            this.tblVoucherPosting_colsProcessCode.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherPosting_colsProcessCode.NamedProperties.Put("SqlColumn", "PROCESS_CODE");
            this.tblVoucherPosting_colsProcessCode.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherPosting_colsProcessCode.Position = 29;
            resources.ApplyResources(this.tblVoucherPosting_colsProcessCode, "tblVoucherPosting_colsProcessCode");
            this.tblVoucherPosting_colsProcessCode.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVoucherPosting_colsProcessCode_WindowActions);
            // 
            // tblVoucherPosting_colsDeliveryTypeId
            // 
            this.tblVoucherPosting_colsDeliveryTypeId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblVoucherPosting_colsDeliveryTypeId.MaxLength = 20;
            this.tblVoucherPosting_colsDeliveryTypeId.Name = "tblVoucherPosting_colsDeliveryTypeId";
            this.tblVoucherPosting_colsDeliveryTypeId.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colsDeliveryTypeId.NamedProperties.Put("FieldFlags", "290");
            this.tblVoucherPosting_colsDeliveryTypeId.NamedProperties.Put("LovReference", "DELIVERY_TYPE(COMPANY)");
            this.tblVoucherPosting_colsDeliveryTypeId.NamedProperties.Put("SqlColumn", "DELIV_TYPE_ID");
            this.tblVoucherPosting_colsDeliveryTypeId.Position = 30;
            resources.ApplyResources(this.tblVoucherPosting_colsDeliveryTypeId, "tblVoucherPosting_colsDeliveryTypeId");
            this.tblVoucherPosting_colsDeliveryTypeId.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVoucherPosting_colsDeliveryTypeId_WindowActions);
            // 
            // tblVoucherPosting_colsDeliveryTypeDescription
            // 
            this.tblVoucherPosting_colsDeliveryTypeDescription.MaxLength = 2000;
            this.tblVoucherPosting_colsDeliveryTypeDescription.Name = "tblVoucherPosting_colsDeliveryTypeDescription";
            this.tblVoucherPosting_colsDeliveryTypeDescription.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colsDeliveryTypeDescription.NamedProperties.Put("FieldFlags", "288");
            this.tblVoucherPosting_colsDeliveryTypeDescription.NamedProperties.Put("LovReference", "");
            this.tblVoucherPosting_colsDeliveryTypeDescription.NamedProperties.Put("ParentName", "tblVoucherPosting.tblVoucherPosting_colsDeliveryTypeId");
            this.tblVoucherPosting_colsDeliveryTypeDescription.NamedProperties.Put("SqlColumn", "Voucher_Row_API.Get_Delivery_Type_Description(COMPANY,DELIV_TYPE_ID)");
            this.tblVoucherPosting_colsDeliveryTypeDescription.Position = 31;
            resources.ApplyResources(this.tblVoucherPosting_colsDeliveryTypeDescription, "tblVoucherPosting_colsDeliveryTypeDescription");
            // 
            // tblVoucherPosting_colsOptionalCode
            // 
            this.tblVoucherPosting_colsOptionalCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblVoucherPosting_colsOptionalCode.MaxLength = 20;
            this.tblVoucherPosting_colsOptionalCode.Name = "tblVoucherPosting_colsOptionalCode";
            this.tblVoucherPosting_colsOptionalCode.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colsOptionalCode.NamedProperties.Put("FieldFlags", "294");
            this.tblVoucherPosting_colsOptionalCode.NamedProperties.Put("LovReference", "STATUTORY_FEE_DEDUCT_MULTIPLE(COMPANY)");
            this.tblVoucherPosting_colsOptionalCode.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherPosting_colsOptionalCode.NamedProperties.Put("SqlColumn", "OPTIONAL_CODE");
            this.tblVoucherPosting_colsOptionalCode.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherPosting_colsOptionalCode.Position = 32;
            resources.ApplyResources(this.tblVoucherPosting_colsOptionalCode, "tblVoucherPosting_colsOptionalCode");
            this.tblVoucherPosting_colsOptionalCode.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVoucherPosting_colsOptionalCode_WindowActions);
            // 
            // tblVoucherPosting_colsTaxDirection
            // 
            this.tblVoucherPosting_colsTaxDirection.MaxLength = 20;
            this.tblVoucherPosting_colsTaxDirection.Name = "tblVoucherPosting_colsTaxDirection";
            this.tblVoucherPosting_colsTaxDirection.NamedProperties.Put("EnumerateMethod", "TAX_DIRECTION_API.Enumerate");
            this.tblVoucherPosting_colsTaxDirection.NamedProperties.Put("FieldFlags", "294");
            this.tblVoucherPosting_colsTaxDirection.NamedProperties.Put("LovReference", "");
            this.tblVoucherPosting_colsTaxDirection.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherPosting_colsTaxDirection.NamedProperties.Put("SqlColumn", "TAX_DIRECTION");
            this.tblVoucherPosting_colsTaxDirection.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherPosting_colsTaxDirection.Position = 33;
            resources.ApplyResources(this.tblVoucherPosting_colsTaxDirection, "tblVoucherPosting_colsTaxDirection");
            this.tblVoucherPosting_colsTaxDirection.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVoucherPosting_colsTaxDirection_WindowActions);
            // 
            // tblVoucherPosting_colsCurrencyCode
            // 
            this.tblVoucherPosting_colsCurrencyCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblVoucherPosting_colsCurrencyCode.MaxLength = 3;
            this.tblVoucherPosting_colsCurrencyCode.Name = "tblVoucherPosting_colsCurrencyCode";
            this.tblVoucherPosting_colsCurrencyCode.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colsCurrencyCode.NamedProperties.Put("FieldFlags", "294");
            this.tblVoucherPosting_colsCurrencyCode.NamedProperties.Put("LovReference", "CURRENCY_CODE(COMPANY)");
            this.tblVoucherPosting_colsCurrencyCode.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherPosting_colsCurrencyCode.NamedProperties.Put("SqlColumn", "CURRENCY_CODE");
            this.tblVoucherPosting_colsCurrencyCode.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherPosting_colsCurrencyCode.Position = 34;
            resources.ApplyResources(this.tblVoucherPosting_colsCurrencyCode, "tblVoucherPosting_colsCurrencyCode");
            this.tblVoucherPosting_colsCurrencyCode.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVoucherPosting_colsCurrencyCode_WindowActions);
            // 
            // tblVoucherPosting_colsCurrencyType
            // 
            this.tblVoucherPosting_colsCurrencyType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblVoucherPosting_colsCurrencyType.MaxLength = 10;
            this.tblVoucherPosting_colsCurrencyType.Name = "tblVoucherPosting_colsCurrencyType";
            this.tblVoucherPosting_colsCurrencyType.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colsCurrencyType.NamedProperties.Put("FieldFlags", "294");
            this.tblVoucherPosting_colsCurrencyType.NamedProperties.Put("LovReference", "CURRENCY_RATE2(COMPANY, CURRENCY_CODE)");
            this.tblVoucherPosting_colsCurrencyType.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherPosting_colsCurrencyType.NamedProperties.Put("SqlColumn", "CURRENCY_TYPE");
            this.tblVoucherPosting_colsCurrencyType.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherPosting_colsCurrencyType.Position = 35;
            resources.ApplyResources(this.tblVoucherPosting_colsCurrencyType, "tblVoucherPosting_colsCurrencyType");
            this.tblVoucherPosting_colsCurrencyType.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVoucherPosting_colsCurrencyType_WindowActions);
            // 
            // tblVoucherPosting_colCorrection
            // 
            this.tblVoucherPosting_colCorrection.CheckBox.CheckedValue = "Y";
            this.tblVoucherPosting_colCorrection.CheckBox.IgnoreCase = true;
            this.tblVoucherPosting_colCorrection.CheckBox.UncheckedValue = "N";
            this.tblVoucherPosting_colCorrection.MaxLength = 1;
            this.tblVoucherPosting_colCorrection.Name = "tblVoucherPosting_colCorrection";
            this.tblVoucherPosting_colCorrection.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colCorrection.NamedProperties.Put("FieldFlags", "288");
            this.tblVoucherPosting_colCorrection.NamedProperties.Put("LovReference", "");
            this.tblVoucherPosting_colCorrection.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherPosting_colCorrection.NamedProperties.Put("SqlColumn", "CORRECTION");
            this.tblVoucherPosting_colCorrection.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherPosting_colCorrection.Position = 36;
            resources.ApplyResources(this.tblVoucherPosting_colCorrection, "tblVoucherPosting_colCorrection");
            // 
            // tblVoucherPosting_colnCurrencyDebetAmount
            // 
            this.tblVoucherPosting_colnCurrencyDebetAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVoucherPosting_colnCurrencyDebetAmount.MaxLength = 15;
            this.tblVoucherPosting_colnCurrencyDebetAmount.Name = "tblVoucherPosting_colnCurrencyDebetAmount";
            this.tblVoucherPosting_colnCurrencyDebetAmount.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colnCurrencyDebetAmount.NamedProperties.Put("FieldFlags", "294");
            this.tblVoucherPosting_colnCurrencyDebetAmount.NamedProperties.Put("Format", "20");
            this.tblVoucherPosting_colnCurrencyDebetAmount.NamedProperties.Put("LovReference", "");
            this.tblVoucherPosting_colnCurrencyDebetAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherPosting_colnCurrencyDebetAmount.NamedProperties.Put("SqlColumn", "CURRENCY_DEBET_AMOUNT");
            this.tblVoucherPosting_colnCurrencyDebetAmount.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherPosting_colnCurrencyDebetAmount.Position = 37;
            this.tblVoucherPosting_colnCurrencyDebetAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblVoucherPosting_colnCurrencyDebetAmount, "tblVoucherPosting_colnCurrencyDebetAmount");
            this.tblVoucherPosting_colnCurrencyDebetAmount.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVoucherPosting_colnCurrencyDebetAmount_WindowActions);
            // 
            // tblVoucherPosting_colnCurrencyCreditAmount
            // 
            this.tblVoucherPosting_colnCurrencyCreditAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVoucherPosting_colnCurrencyCreditAmount.MaxLength = 15;
            this.tblVoucherPosting_colnCurrencyCreditAmount.Name = "tblVoucherPosting_colnCurrencyCreditAmount";
            this.tblVoucherPosting_colnCurrencyCreditAmount.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colnCurrencyCreditAmount.NamedProperties.Put("FieldFlags", "294");
            this.tblVoucherPosting_colnCurrencyCreditAmount.NamedProperties.Put("Format", "20");
            this.tblVoucherPosting_colnCurrencyCreditAmount.NamedProperties.Put("LovReference", "");
            this.tblVoucherPosting_colnCurrencyCreditAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherPosting_colnCurrencyCreditAmount.NamedProperties.Put("SqlColumn", "CURRENCY_CREDIT_AMOUNT");
            this.tblVoucherPosting_colnCurrencyCreditAmount.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherPosting_colnCurrencyCreditAmount.Position = 38;
            this.tblVoucherPosting_colnCurrencyCreditAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblVoucherPosting_colnCurrencyCreditAmount, "tblVoucherPosting_colnCurrencyCreditAmount");
            this.tblVoucherPosting_colnCurrencyCreditAmount.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVoucherPosting_colnCurrencyCreditAmount_WindowActions);
            // 
            // tblVoucherPosting_colnCurrencyAmount
            // 
            this.tblVoucherPosting_colnCurrencyAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVoucherPosting_colnCurrencyAmount.MaxLength = 15;
            this.tblVoucherPosting_colnCurrencyAmount.Name = "tblVoucherPosting_colnCurrencyAmount";
            this.tblVoucherPosting_colnCurrencyAmount.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colnCurrencyAmount.NamedProperties.Put("FieldFlags", "262");
            this.tblVoucherPosting_colnCurrencyAmount.NamedProperties.Put("Format", "20");
            this.tblVoucherPosting_colnCurrencyAmount.NamedProperties.Put("LovReference", "");
            this.tblVoucherPosting_colnCurrencyAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherPosting_colnCurrencyAmount.NamedProperties.Put("SqlColumn", "");
            this.tblVoucherPosting_colnCurrencyAmount.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherPosting_colnCurrencyAmount.Position = 39;
            this.tblVoucherPosting_colnCurrencyAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblVoucherPosting_colnCurrencyAmount, "tblVoucherPosting_colnCurrencyAmount");
            this.tblVoucherPosting_colnCurrencyAmount.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVoucherPosting_colnCurrencyAmount_WindowActions);
            // 
            // tblVoucherPosting_colnCurrencyTaxAmount
            // 
            this.tblVoucherPosting_colnCurrencyTaxAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVoucherPosting_colnCurrencyTaxAmount.MaxLength = 15;
            this.tblVoucherPosting_colnCurrencyTaxAmount.Name = "tblVoucherPosting_colnCurrencyTaxAmount";
            this.tblVoucherPosting_colnCurrencyTaxAmount.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colnCurrencyTaxAmount.NamedProperties.Put("FieldFlags", "294");
            this.tblVoucherPosting_colnCurrencyTaxAmount.NamedProperties.Put("Format", "20");
            this.tblVoucherPosting_colnCurrencyTaxAmount.NamedProperties.Put("LovReference", "");
            this.tblVoucherPosting_colnCurrencyTaxAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherPosting_colnCurrencyTaxAmount.NamedProperties.Put("SqlColumn", "CURRENCY_TAX_AMOUNT");
            this.tblVoucherPosting_colnCurrencyTaxAmount.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherPosting_colnCurrencyTaxAmount.Position = 40;
            this.tblVoucherPosting_colnCurrencyTaxAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblVoucherPosting_colnCurrencyTaxAmount, "tblVoucherPosting_colnCurrencyTaxAmount");
            this.tblVoucherPosting_colnCurrencyTaxAmount.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVoucherPosting_colnCurrencyTaxAmount_WindowActions);
            // 
            // tblVoucherPosting_colnCurrencyGrossAmount
            // 
            this.tblVoucherPosting_colnCurrencyGrossAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.tblVoucherPosting_colnCurrencyGrossAmount, "tblVoucherPosting_colnCurrencyGrossAmount");
            this.tblVoucherPosting_colnCurrencyGrossAmount.MaxLength = 15;
            this.tblVoucherPosting_colnCurrencyGrossAmount.Name = "tblVoucherPosting_colnCurrencyGrossAmount";
            this.tblVoucherPosting_colnCurrencyGrossAmount.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colnCurrencyGrossAmount.NamedProperties.Put("FieldFlags", "262");
            this.tblVoucherPosting_colnCurrencyGrossAmount.NamedProperties.Put("Format", "20");
            this.tblVoucherPosting_colnCurrencyGrossAmount.NamedProperties.Put("LovReference", "");
            this.tblVoucherPosting_colnCurrencyGrossAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherPosting_colnCurrencyGrossAmount.NamedProperties.Put("SqlColumn", "CURRENCY_GROSS_AMOUNT");
            this.tblVoucherPosting_colnCurrencyGrossAmount.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherPosting_colnCurrencyGrossAmount.Position = 41;
            this.tblVoucherPosting_colnCurrencyGrossAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tblVoucherPosting_colnCurrencyRate
            // 
            this.tblVoucherPosting_colnCurrencyRate.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVoucherPosting_colnCurrencyRate.Name = "tblVoucherPosting_colnCurrencyRate";
            this.tblVoucherPosting_colnCurrencyRate.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colnCurrencyRate.NamedProperties.Put("FieldFlags", "294");
            this.tblVoucherPosting_colnCurrencyRate.NamedProperties.Put("LovReference", "");
            this.tblVoucherPosting_colnCurrencyRate.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherPosting_colnCurrencyRate.NamedProperties.Put("SqlColumn", "CURRENCY_RATE");
            this.tblVoucherPosting_colnCurrencyRate.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherPosting_colnCurrencyRate.Position = 42;
            this.tblVoucherPosting_colnCurrencyRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblVoucherPosting_colnCurrencyRate, "tblVoucherPosting_colnCurrencyRate");
            this.tblVoucherPosting_colnCurrencyRate.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVoucherPosting_colnCurrencyRate_WindowActions);
            // 
            // tblVoucherPosting_colnConversionFactor
            // 
            this.tblVoucherPosting_colnConversionFactor.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVoucherPosting_colnConversionFactor.Name = "tblVoucherPosting_colnConversionFactor";
            this.tblVoucherPosting_colnConversionFactor.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colnConversionFactor.NamedProperties.Put("FieldFlags", "288");
            this.tblVoucherPosting_colnConversionFactor.NamedProperties.Put("LovReference", "");
            this.tblVoucherPosting_colnConversionFactor.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherPosting_colnConversionFactor.NamedProperties.Put("SqlColumn", "CONVERSION_FACTOR");
            this.tblVoucherPosting_colnConversionFactor.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherPosting_colnConversionFactor.Position = 43;
            this.tblVoucherPosting_colnConversionFactor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblVoucherPosting_colnConversionFactor, "tblVoucherPosting_colnConversionFactor");
            // 
            // tblVoucherPosting_colnDebetAmount
            // 
            this.tblVoucherPosting_colnDebetAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVoucherPosting_colnDebetAmount.MaxLength = 15;
            this.tblVoucherPosting_colnDebetAmount.Name = "tblVoucherPosting_colnDebetAmount";
            this.tblVoucherPosting_colnDebetAmount.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colnDebetAmount.NamedProperties.Put("FieldFlags", "294");
            this.tblVoucherPosting_colnDebetAmount.NamedProperties.Put("Format", "20");
            this.tblVoucherPosting_colnDebetAmount.NamedProperties.Put("LovReference", "");
            this.tblVoucherPosting_colnDebetAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherPosting_colnDebetAmount.NamedProperties.Put("SqlColumn", "DEBET_AMOUNT");
            this.tblVoucherPosting_colnDebetAmount.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherPosting_colnDebetAmount.Position = 44;
            this.tblVoucherPosting_colnDebetAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblVoucherPosting_colnDebetAmount, "tblVoucherPosting_colnDebetAmount");
            this.tblVoucherPosting_colnDebetAmount.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVoucherPosting_colnDebetAmount_WindowActions);
            // 
            // tblVoucherPosting_colnCreditAmount
            // 
            this.tblVoucherPosting_colnCreditAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVoucherPosting_colnCreditAmount.MaxLength = 15;
            this.tblVoucherPosting_colnCreditAmount.Name = "tblVoucherPosting_colnCreditAmount";
            this.tblVoucherPosting_colnCreditAmount.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colnCreditAmount.NamedProperties.Put("FieldFlags", "294");
            this.tblVoucherPosting_colnCreditAmount.NamedProperties.Put("Format", "20");
            this.tblVoucherPosting_colnCreditAmount.NamedProperties.Put("LovReference", "");
            this.tblVoucherPosting_colnCreditAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherPosting_colnCreditAmount.NamedProperties.Put("SqlColumn", "CREDIT_AMOUNT");
            this.tblVoucherPosting_colnCreditAmount.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherPosting_colnCreditAmount.Position = 45;
            this.tblVoucherPosting_colnCreditAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblVoucherPosting_colnCreditAmount, "tblVoucherPosting_colnCreditAmount");
            this.tblVoucherPosting_colnCreditAmount.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVoucherPosting_colnCreditAmount_WindowActions);
            // 
            // tblVoucherPosting_colnAmount
            // 
            this.tblVoucherPosting_colnAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVoucherPosting_colnAmount.MaxLength = 15;
            this.tblVoucherPosting_colnAmount.Name = "tblVoucherPosting_colnAmount";
            this.tblVoucherPosting_colnAmount.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colnAmount.NamedProperties.Put("FieldFlags", "295");
            this.tblVoucherPosting_colnAmount.NamedProperties.Put("Format", "20");
            this.tblVoucherPosting_colnAmount.NamedProperties.Put("LovReference", "");
            this.tblVoucherPosting_colnAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherPosting_colnAmount.NamedProperties.Put("SqlColumn", "");
            this.tblVoucherPosting_colnAmount.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherPosting_colnAmount.Position = 46;
            this.tblVoucherPosting_colnAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblVoucherPosting_colnAmount, "tblVoucherPosting_colnAmount");
            this.tblVoucherPosting_colnAmount.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVoucherPosting_colnAmount_WindowActions);
            // 
            // tblVoucherPosting_colnTaxAmount
            // 
            this.tblVoucherPosting_colnTaxAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVoucherPosting_colnTaxAmount.MaxLength = 15;
            this.tblVoucherPosting_colnTaxAmount.Name = "tblVoucherPosting_colnTaxAmount";
            this.tblVoucherPosting_colnTaxAmount.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colnTaxAmount.NamedProperties.Put("FieldFlags", "294");
            this.tblVoucherPosting_colnTaxAmount.NamedProperties.Put("Format", "20");
            this.tblVoucherPosting_colnTaxAmount.NamedProperties.Put("LovReference", "");
            this.tblVoucherPosting_colnTaxAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherPosting_colnTaxAmount.NamedProperties.Put("SqlColumn", "TAX_AMOUNT");
            this.tblVoucherPosting_colnTaxAmount.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherPosting_colnTaxAmount.Position = 47;
            this.tblVoucherPosting_colnTaxAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblVoucherPosting_colnTaxAmount, "tblVoucherPosting_colnTaxAmount");
            this.tblVoucherPosting_colnTaxAmount.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVoucherPosting_colnTaxAmount_WindowActions);
            // 
            // tblVoucherPosting_colnGrossAmount
            // 
            this.tblVoucherPosting_colnGrossAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.tblVoucherPosting_colnGrossAmount, "tblVoucherPosting_colnGrossAmount");
            this.tblVoucherPosting_colnGrossAmount.MaxLength = 15;
            this.tblVoucherPosting_colnGrossAmount.Name = "tblVoucherPosting_colnGrossAmount";
            this.tblVoucherPosting_colnGrossAmount.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colnGrossAmount.NamedProperties.Put("FieldFlags", "262");
            this.tblVoucherPosting_colnGrossAmount.NamedProperties.Put("Format", "20");
            this.tblVoucherPosting_colnGrossAmount.NamedProperties.Put("LovReference", "");
            this.tblVoucherPosting_colnGrossAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherPosting_colnGrossAmount.NamedProperties.Put("SqlColumn", "GROSS_AMOUNT");
            this.tblVoucherPosting_colnGrossAmount.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherPosting_colnGrossAmount.Position = 48;
            this.tblVoucherPosting_colnGrossAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tblVoucherPosting_colnParallelCurrRateType
            // 
            this.tblVoucherPosting_colnParallelCurrRateType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblVoucherPosting_colnParallelCurrRateType.Name = "tblVoucherPosting_colnParallelCurrRateType";
            this.tblVoucherPosting_colnParallelCurrRateType.NamedProperties.Put("FieldFlags", "294");
            this.tblVoucherPosting_colnParallelCurrRateType.NamedProperties.Put("LovReference", "CURRENCY_TYPE3(COMPANY)");
            this.tblVoucherPosting_colnParallelCurrRateType.NamedProperties.Put("SqlColumn", "PARALLEL_CURR_RATE_TYPE");
            this.tblVoucherPosting_colnParallelCurrRateType.Position = 49;
            this.tblVoucherPosting_colnParallelCurrRateType.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblVoucherPosting_colnParallelCurrRateType, "tblVoucherPosting_colnParallelCurrRateType");
            this.tblVoucherPosting_colnParallelCurrRateType.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVoucherPosting_colnParallelCurrRateType_WindowActions);
            // 
            // tblVoucherPosting_colnParallelCurrRate
            // 
            this.tblVoucherPosting_colnParallelCurrRate.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVoucherPosting_colnParallelCurrRate.Name = "tblVoucherPosting_colnParallelCurrRate";
            this.tblVoucherPosting_colnParallelCurrRate.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colnParallelCurrRate.NamedProperties.Put("FieldFlags", "294");
            this.tblVoucherPosting_colnParallelCurrRate.NamedProperties.Put("Format", "");
            this.tblVoucherPosting_colnParallelCurrRate.NamedProperties.Put("LovReference", "");
            this.tblVoucherPosting_colnParallelCurrRate.NamedProperties.Put("SqlColumn", "PARALLEL_CURRENCY_RATE");
            this.tblVoucherPosting_colnParallelCurrRate.Position = 50;
            this.tblVoucherPosting_colnParallelCurrRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblVoucherPosting_colnParallelCurrRate, "tblVoucherPosting_colnParallelCurrRate");
            this.tblVoucherPosting_colnParallelCurrRate.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVoucherPosting_colnParallelCurrRate_WindowActions);
            // 
            // tblVoucherPosting_colnParallelCurrConvFactor
            // 
            this.tblVoucherPosting_colnParallelCurrConvFactor.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVoucherPosting_colnParallelCurrConvFactor.Name = "tblVoucherPosting_colnParallelCurrConvFactor";
            this.tblVoucherPosting_colnParallelCurrConvFactor.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colnParallelCurrConvFactor.NamedProperties.Put("FieldFlags", "288");
            this.tblVoucherPosting_colnParallelCurrConvFactor.NamedProperties.Put("Format", "");
            this.tblVoucherPosting_colnParallelCurrConvFactor.NamedProperties.Put("LovReference", "");
            this.tblVoucherPosting_colnParallelCurrConvFactor.NamedProperties.Put("SqlColumn", "PARALLEL_CONVERSION_FACTOR");
            this.tblVoucherPosting_colnParallelCurrConvFactor.Position = 51;
            this.tblVoucherPosting_colnParallelCurrConvFactor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblVoucherPosting_colnParallelCurrConvFactor, "tblVoucherPosting_colnParallelCurrConvFactor");
            // 
            // tblVoucherPosting_colnThirdCurrencyDebitAmount
            // 
            this.tblVoucherPosting_colnThirdCurrencyDebitAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVoucherPosting_colnThirdCurrencyDebitAmount.MaxLength = 15;
            this.tblVoucherPosting_colnThirdCurrencyDebitAmount.Name = "tblVoucherPosting_colnThirdCurrencyDebitAmount";
            this.tblVoucherPosting_colnThirdCurrencyDebitAmount.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colnThirdCurrencyDebitAmount.NamedProperties.Put("FieldFlags", "262");
            this.tblVoucherPosting_colnThirdCurrencyDebitAmount.NamedProperties.Put("Format", "20");
            this.tblVoucherPosting_colnThirdCurrencyDebitAmount.NamedProperties.Put("LovReference", "");
            this.tblVoucherPosting_colnThirdCurrencyDebitAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherPosting_colnThirdCurrencyDebitAmount.NamedProperties.Put("SqlColumn", "THIRD_CURRENCY_DEBIT_AMOUNT");
            this.tblVoucherPosting_colnThirdCurrencyDebitAmount.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherPosting_colnThirdCurrencyDebitAmount.Position = 52;
            this.tblVoucherPosting_colnThirdCurrencyDebitAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblVoucherPosting_colnThirdCurrencyDebitAmount, "tblVoucherPosting_colnThirdCurrencyDebitAmount");
            this.tblVoucherPosting_colnThirdCurrencyDebitAmount.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVoucherPosting_colnThirdCurrencyDebitAmount_WindowActions);
            // 
            // tblVoucherPosting_colnThirdCurrencyCreditAmount
            // 
            this.tblVoucherPosting_colnThirdCurrencyCreditAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVoucherPosting_colnThirdCurrencyCreditAmount.MaxLength = 15;
            this.tblVoucherPosting_colnThirdCurrencyCreditAmount.Name = "tblVoucherPosting_colnThirdCurrencyCreditAmount";
            this.tblVoucherPosting_colnThirdCurrencyCreditAmount.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colnThirdCurrencyCreditAmount.NamedProperties.Put("FieldFlags", "262");
            this.tblVoucherPosting_colnThirdCurrencyCreditAmount.NamedProperties.Put("Format", "20");
            this.tblVoucherPosting_colnThirdCurrencyCreditAmount.NamedProperties.Put("LovReference", "");
            this.tblVoucherPosting_colnThirdCurrencyCreditAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherPosting_colnThirdCurrencyCreditAmount.NamedProperties.Put("SqlColumn", "THIRD_CURRENCY_CREDIT_AMOUNT");
            this.tblVoucherPosting_colnThirdCurrencyCreditAmount.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherPosting_colnThirdCurrencyCreditAmount.Position = 53;
            this.tblVoucherPosting_colnThirdCurrencyCreditAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblVoucherPosting_colnThirdCurrencyCreditAmount, "tblVoucherPosting_colnThirdCurrencyCreditAmount");
            this.tblVoucherPosting_colnThirdCurrencyCreditAmount.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVoucherPosting_colnThirdCurrencyCreditAmount_WindowActions);
            // 
            // tblVoucherPosting_colnThirdCurrencyAmount
            // 
            this.tblVoucherPosting_colnThirdCurrencyAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVoucherPosting_colnThirdCurrencyAmount.Name = "tblVoucherPosting_colnThirdCurrencyAmount";
            this.tblVoucherPosting_colnThirdCurrencyAmount.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colnThirdCurrencyAmount.NamedProperties.Put("FieldFlags", "294");
            this.tblVoucherPosting_colnThirdCurrencyAmount.NamedProperties.Put("Format", "20");
            this.tblVoucherPosting_colnThirdCurrencyAmount.NamedProperties.Put("LovReference", "");
            this.tblVoucherPosting_colnThirdCurrencyAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherPosting_colnThirdCurrencyAmount.NamedProperties.Put("SqlColumn", "NVL(THIRD_CURRENCY_DEBIT_AMOUNT,0) - NVL(THIRD_CURRENCY_CREDIT_AMOUNT,0)");
            this.tblVoucherPosting_colnThirdCurrencyAmount.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherPosting_colnThirdCurrencyAmount.Position = 54;
            this.tblVoucherPosting_colnThirdCurrencyAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblVoucherPosting_colnThirdCurrencyAmount, "tblVoucherPosting_colnThirdCurrencyAmount");
            this.tblVoucherPosting_colnThirdCurrencyAmount.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVoucherPosting_colnThirdCurrencyAmount_WindowActions);
            // 
            // tblVoucherPosting_colnParallelCurrTaxAmount
            // 
            this.tblVoucherPosting_colnParallelCurrTaxAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVoucherPosting_colnParallelCurrTaxAmount.Name = "tblVoucherPosting_colnParallelCurrTaxAmount";
            this.tblVoucherPosting_colnParallelCurrTaxAmount.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colnParallelCurrTaxAmount.NamedProperties.Put("FieldFlags", "294");
            this.tblVoucherPosting_colnParallelCurrTaxAmount.NamedProperties.Put("Format", "20");
            this.tblVoucherPosting_colnParallelCurrTaxAmount.NamedProperties.Put("LovReference", "");
            this.tblVoucherPosting_colnParallelCurrTaxAmount.NamedProperties.Put("SqlColumn", "PARALLEL_CURR_TAX_AMOUNT");
            this.tblVoucherPosting_colnParallelCurrTaxAmount.Position = 55;
            this.tblVoucherPosting_colnParallelCurrTaxAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblVoucherPosting_colnParallelCurrTaxAmount, "tblVoucherPosting_colnParallelCurrTaxAmount");
            this.tblVoucherPosting_colnParallelCurrTaxAmount.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVoucherPosting_colnParallelCurrTaxAmount_WindowActions);
            // 
            // tblVoucherPosting_colnQuantity
            // 
            this.tblVoucherPosting_colnQuantity.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVoucherPosting_colnQuantity.Name = "tblVoucherPosting_colnQuantity";
            this.tblVoucherPosting_colnQuantity.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colnQuantity.NamedProperties.Put("FieldFlags", "294");
            this.tblVoucherPosting_colnQuantity.NamedProperties.Put("LovReference", "");
            this.tblVoucherPosting_colnQuantity.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherPosting_colnQuantity.NamedProperties.Put("SqlColumn", "QUANTITY");
            this.tblVoucherPosting_colnQuantity.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherPosting_colnQuantity.Position = 56;
            this.tblVoucherPosting_colnQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblVoucherPosting_colnQuantity, "tblVoucherPosting_colnQuantity");
            // 
            // tblVoucherPosting_colsPeriodAllocation
            // 
            this.tblVoucherPosting_colsPeriodAllocation.CheckBox.CheckedValue = "Y";
            this.tblVoucherPosting_colsPeriodAllocation.CheckBox.IgnoreCase = true;
            this.tblVoucherPosting_colsPeriodAllocation.CheckBox.UncheckedValue = "N";
            resources.ApplyResources(this.tblVoucherPosting_colsPeriodAllocation, "tblVoucherPosting_colsPeriodAllocation");
            this.tblVoucherPosting_colsPeriodAllocation.MaxLength = 20;
            this.tblVoucherPosting_colsPeriodAllocation.Name = "tblVoucherPosting_colsPeriodAllocation";
            this.tblVoucherPosting_colsPeriodAllocation.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colsPeriodAllocation.NamedProperties.Put("FieldFlags", "288");
            this.tblVoucherPosting_colsPeriodAllocation.NamedProperties.Put("LovReference", "");
            this.tblVoucherPosting_colsPeriodAllocation.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherPosting_colsPeriodAllocation.NamedProperties.Put("SqlColumn", "PERIOD_ALLOCATION");
            this.tblVoucherPosting_colsPeriodAllocation.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherPosting_colsPeriodAllocation.Position = 57;
            // 
            // tblVoucherPosting_colsTextId
            // 
            resources.ApplyResources(this.tblVoucherPosting_colsTextId, "tblVoucherPosting_colsTextId");
            this.tblVoucherPosting_colsTextId.Name = "tblVoucherPosting_colsTextId";
            this.tblVoucherPosting_colsTextId.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colsTextId.NamedProperties.Put("FieldFlags", "806");
            this.tblVoucherPosting_colsTextId.NamedProperties.Put("LovReference", "VOUCHER_TEXT(COMPANY)");
            this.tblVoucherPosting_colsTextId.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherPosting_colsTextId.NamedProperties.Put("SqlColumn", "TEXT_ID");
            this.tblVoucherPosting_colsTextId.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherPosting_colsTextId.Position = 58;
            this.tblVoucherPosting_colsTextId.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVoucherPosting_colsTextId_WindowActions);
            // 
            // tblVoucherPosting_colsText
            // 
            this.tblVoucherPosting_colsText.MaxLength = 200;
            this.tblVoucherPosting_colsText.Name = "tblVoucherPosting_colsText";
            this.tblVoucherPosting_colsText.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colsText.NamedProperties.Put("FieldFlags", "294");
            this.tblVoucherPosting_colsText.NamedProperties.Put("LovReference", "");
            this.tblVoucherPosting_colsText.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherPosting_colsText.NamedProperties.Put("SqlColumn", "TEXT");
            this.tblVoucherPosting_colsText.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherPosting_colsText.Position = 59;
            resources.ApplyResources(this.tblVoucherPosting_colsText, "tblVoucherPosting_colsText");
            // 
            // tblVoucherPosting_colnProjectActivityId
            // 
            this.tblVoucherPosting_colnProjectActivityId.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVoucherPosting_colnProjectActivityId.Name = "tblVoucherPosting_colnProjectActivityId";
            this.tblVoucherPosting_colnProjectActivityId.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colnProjectActivityId.NamedProperties.Put("FieldFlags", "294");
            this.tblVoucherPosting_colnProjectActivityId.NamedProperties.Put("LovReference", "PROJECT_ACTIVITY_POSTABLE(PROJECT_ID)");
            this.tblVoucherPosting_colnProjectActivityId.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherPosting_colnProjectActivityId.NamedProperties.Put("SqlColumn", "PROJECT_ACTIVITY_ID");
            this.tblVoucherPosting_colnProjectActivityId.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherPosting_colnProjectActivityId.Position = 60;
            resources.ApplyResources(this.tblVoucherPosting_colnProjectActivityId, "tblVoucherPosting_colnProjectActivityId");
            this.tblVoucherPosting_colnProjectActivityId.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVoucherPosting_colnProjectActivityId_WindowActions);
            // 
            // tblVoucherPosting_colsUpdateError
            // 
            this.tblVoucherPosting_colsUpdateError.MaxLength = 200;
            this.tblVoucherPosting_colsUpdateError.Name = "tblVoucherPosting_colsUpdateError";
            this.tblVoucherPosting_colsUpdateError.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colsUpdateError.NamedProperties.Put("FieldFlags", "290");
            this.tblVoucherPosting_colsUpdateError.NamedProperties.Put("LovReference", "");
            this.tblVoucherPosting_colsUpdateError.NamedProperties.Put("SqlColumn", "UPDATE_ERROR");
            this.tblVoucherPosting_colsUpdateError.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherPosting_colsUpdateError.Position = 61;
            resources.ApplyResources(this.tblVoucherPosting_colsUpdateError, "tblVoucherPosting_colsUpdateError");
            // 
            // tblVoucherPosting_colsTransCode
            // 
            this.tblVoucherPosting_colsTransCode.MaxLength = 10;
            this.tblVoucherPosting_colsTransCode.Name = "tblVoucherPosting_colsTransCode";
            this.tblVoucherPosting_colsTransCode.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colsTransCode.NamedProperties.Put("FieldFlags", "288");
            this.tblVoucherPosting_colsTransCode.NamedProperties.Put("LovReference", "");
            this.tblVoucherPosting_colsTransCode.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherPosting_colsTransCode.NamedProperties.Put("SqlColumn", "TRANS_CODE");
            this.tblVoucherPosting_colsTransCode.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherPosting_colsTransCode.Position = 62;
            resources.ApplyResources(this.tblVoucherPosting_colsTransCode, "tblVoucherPosting_colsTransCode");
            // 
            // tblVoucherPosting_colAddInternal
            // 
            this.tblVoucherPosting_colAddInternal.Name = "tblVoucherPosting_colAddInternal";
            this.tblVoucherPosting_colAddInternal.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colAddInternal.NamedProperties.Put("LovReference", "");
            this.tblVoucherPosting_colAddInternal.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherPosting_colAddInternal.NamedProperties.Put("SqlColumn", "VOUCHER_ROW_API.Is_Manual_Added(COMPANY,INTERNAL_SEQ_NUMBER,ACCOUNT)");
            this.tblVoucherPosting_colAddInternal.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherPosting_colAddInternal.Position = 63;
            resources.ApplyResources(this.tblVoucherPosting_colAddInternal, "tblVoucherPosting_colAddInternal");
            // 
            // tblVoucherPosting_colnManualCounter
            // 
            this.tblVoucherPosting_colnManualCounter.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.tblVoucherPosting_colnManualCounter, "tblVoucherPosting_colnManualCounter");
            this.tblVoucherPosting_colnManualCounter.Name = "tblVoucherPosting_colnManualCounter";
            this.tblVoucherPosting_colnManualCounter.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colnManualCounter.NamedProperties.Put("LovReference", "");
            this.tblVoucherPosting_colnManualCounter.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherPosting_colnManualCounter.NamedProperties.Put("SqlColumn", "");
            this.tblVoucherPosting_colnManualCounter.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherPosting_colnManualCounter.Position = 64;
            // 
            // tblVoucherPosting_colsReferenceSerie
            // 
            this.tblVoucherPosting_colsReferenceSerie.MaxLength = 50;
            this.tblVoucherPosting_colsReferenceSerie.Name = "tblVoucherPosting_colsReferenceSerie";
            this.tblVoucherPosting_colsReferenceSerie.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colsReferenceSerie.NamedProperties.Put("FieldFlags", "294");
            this.tblVoucherPosting_colsReferenceSerie.NamedProperties.Put("LovReference", "");
            this.tblVoucherPosting_colsReferenceSerie.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherPosting_colsReferenceSerie.NamedProperties.Put("SqlColumn", "REFERENCE_SERIE");
            this.tblVoucherPosting_colsReferenceSerie.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherPosting_colsReferenceSerie.Position = 65;
            resources.ApplyResources(this.tblVoucherPosting_colsReferenceSerie, "tblVoucherPosting_colsReferenceSerie");
            // 
            // tblVoucherPosting_colsReferenceNumber
            // 
            this.tblVoucherPosting_colsReferenceNumber.MaxLength = 50;
            this.tblVoucherPosting_colsReferenceNumber.Name = "tblVoucherPosting_colsReferenceNumber";
            this.tblVoucherPosting_colsReferenceNumber.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colsReferenceNumber.NamedProperties.Put("FieldFlags", "294");
            this.tblVoucherPosting_colsReferenceNumber.NamedProperties.Put("LovReference", "");
            this.tblVoucherPosting_colsReferenceNumber.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherPosting_colsReferenceNumber.NamedProperties.Put("SqlColumn", "REFERENCE_NUMBER");
            this.tblVoucherPosting_colsReferenceNumber.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherPosting_colsReferenceNumber.Position = 66;
            resources.ApplyResources(this.tblVoucherPosting_colsReferenceNumber, "tblVoucherPosting_colsReferenceNumber");
            // 
            // tblVoucherPosting_colnAccountingPeriod
            // 
            this.tblVoucherPosting_colnAccountingPeriod.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.tblVoucherPosting_colnAccountingPeriod, "tblVoucherPosting_colnAccountingPeriod");
            this.tblVoucherPosting_colnAccountingPeriod.Name = "tblVoucherPosting_colnAccountingPeriod";
            this.tblVoucherPosting_colnAccountingPeriod.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colnAccountingPeriod.NamedProperties.Put("FieldFlags", "295");
            this.tblVoucherPosting_colnAccountingPeriod.NamedProperties.Put("LovReference", "");
            this.tblVoucherPosting_colnAccountingPeriod.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherPosting_colnAccountingPeriod.NamedProperties.Put("SqlColumn", "ACCOUNTING_PERIOD");
            this.tblVoucherPosting_colnAccountingPeriod.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherPosting_colnAccountingPeriod.Position = 67;
            // 
            // tblVoucherPosting_colIsStatAccount
            // 
            resources.ApplyResources(this.tblVoucherPosting_colIsStatAccount, "tblVoucherPosting_colIsStatAccount");
            this.tblVoucherPosting_colIsStatAccount.Name = "tblVoucherPosting_colIsStatAccount";
            this.tblVoucherPosting_colIsStatAccount.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colIsStatAccount.NamedProperties.Put("LovReference", "");
            this.tblVoucherPosting_colIsStatAccount.NamedProperties.Put("ParentName", "tblVoucherPosting.tblVoucherPosting_colsAccount");
            this.tblVoucherPosting_colIsStatAccount.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherPosting_colIsStatAccount.NamedProperties.Put("SqlColumn", "ACCOUNTING_CODE_PART_A_API.Is_Stat_Account(COMPANY, ACCOUNT)");
            this.tblVoucherPosting_colIsStatAccount.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherPosting_colIsStatAccount.Position = 68;
            // 
            // tblVoucherPosting_colnDecimalsInAmount
            // 
            this.tblVoucherPosting_colnDecimalsInAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.tblVoucherPosting_colnDecimalsInAmount, "tblVoucherPosting_colnDecimalsInAmount");
            this.tblVoucherPosting_colnDecimalsInAmount.Name = "tblVoucherPosting_colnDecimalsInAmount";
            this.tblVoucherPosting_colnDecimalsInAmount.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colnDecimalsInAmount.NamedProperties.Put("LovReference", "");
            this.tblVoucherPosting_colnDecimalsInAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherPosting_colnDecimalsInAmount.NamedProperties.Put("SqlColumn", "DECIMALS_IN_AMOUNT");
            this.tblVoucherPosting_colnDecimalsInAmount.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherPosting_colnDecimalsInAmount.Position = 69;
            // 
            // tblVoucherPosting_colnAccDecimalsInAmount
            // 
            this.tblVoucherPosting_colnAccDecimalsInAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.tblVoucherPosting_colnAccDecimalsInAmount, "tblVoucherPosting_colnAccDecimalsInAmount");
            this.tblVoucherPosting_colnAccDecimalsInAmount.Name = "tblVoucherPosting_colnAccDecimalsInAmount";
            this.tblVoucherPosting_colnAccDecimalsInAmount.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colnAccDecimalsInAmount.NamedProperties.Put("LovReference", "");
            this.tblVoucherPosting_colnAccDecimalsInAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherPosting_colnAccDecimalsInAmount.NamedProperties.Put("SqlColumn", "ACC_DECIMALS_IN_AMOUNT");
            this.tblVoucherPosting_colnAccDecimalsInAmount.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherPosting_colnAccDecimalsInAmount.Position = 70;
            // 
            // tblVoucherPosting_colsCodeDemand
            // 
            this.tblVoucherPosting_colsCodeDemand.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblVoucherPosting_colsCodeDemand, "tblVoucherPosting_colsCodeDemand");
            this.tblVoucherPosting_colsCodeDemand.MaxLength = 2000;
            this.tblVoucherPosting_colsCodeDemand.Name = "tblVoucherPosting_colsCodeDemand";
            this.tblVoucherPosting_colsCodeDemand.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colsCodeDemand.NamedProperties.Put("LovReference", "");
            this.tblVoucherPosting_colsCodeDemand.NamedProperties.Put("ParentName", "tblVoucherPosting.tblVoucherPosting_colsAccount");
            this.tblVoucherPosting_colsCodeDemand.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherPosting_colsCodeDemand.NamedProperties.Put("SqlColumn", "Accounting_Code_Part_A_API.Get_Required_Code_Part(COMPANY, ACCOUNT)");
            this.tblVoucherPosting_colsCodeDemand.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherPosting_colsCodeDemand.Position = 71;
            // 
            // tblVoucherPosting_colsLedgerIds
            // 
            resources.ApplyResources(this.tblVoucherPosting_colsLedgerIds, "tblVoucherPosting_colsLedgerIds");
            this.tblVoucherPosting_colsLedgerIds.Name = "tblVoucherPosting_colsLedgerIds";
            this.tblVoucherPosting_colsLedgerIds.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colsLedgerIds.NamedProperties.Put("FieldFlags", "768");
            this.tblVoucherPosting_colsLedgerIds.NamedProperties.Put("LovReference", "");
            this.tblVoucherPosting_colsLedgerIds.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherPosting_colsLedgerIds.NamedProperties.Put("SqlColumn", "LEDGER_IDS");
            this.tblVoucherPosting_colsLedgerIds.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherPosting_colsLedgerIds.Position = 72;
            // 
            // tblVoucherPosting_colsAutoTaxVouEntry
            // 
            resources.ApplyResources(this.tblVoucherPosting_colsAutoTaxVouEntry, "tblVoucherPosting_colsAutoTaxVouEntry");
            this.tblVoucherPosting_colsAutoTaxVouEntry.MaxLength = 20;
            this.tblVoucherPosting_colsAutoTaxVouEntry.Name = "tblVoucherPosting_colsAutoTaxVouEntry";
            this.tblVoucherPosting_colsAutoTaxVouEntry.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colsAutoTaxVouEntry.NamedProperties.Put("FieldFlags", "290");
            this.tblVoucherPosting_colsAutoTaxVouEntry.NamedProperties.Put("LovReference", "");
            this.tblVoucherPosting_colsAutoTaxVouEntry.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherPosting_colsAutoTaxVouEntry.NamedProperties.Put("SqlColumn", "AUTO_TAX_VOU_ENTRY");
            this.tblVoucherPosting_colsAutoTaxVouEntry.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherPosting_colsAutoTaxVouEntry.Position = 73;
            // 
            // tblVoucherPosting_colnReferenceRowNo
            // 
            this.tblVoucherPosting_colnReferenceRowNo.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.tblVoucherPosting_colnReferenceRowNo, "tblVoucherPosting_colnReferenceRowNo");
            this.tblVoucherPosting_colnReferenceRowNo.Name = "tblVoucherPosting_colnReferenceRowNo";
            this.tblVoucherPosting_colnReferenceRowNo.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colnReferenceRowNo.NamedProperties.Put("FieldFlags", "290");
            this.tblVoucherPosting_colnReferenceRowNo.NamedProperties.Put("LovReference", "");
            this.tblVoucherPosting_colnReferenceRowNo.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherPosting_colnReferenceRowNo.NamedProperties.Put("SqlColumn", "REFERENCE_ROW_NO");
            this.tblVoucherPosting_colnReferenceRowNo.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherPosting_colnReferenceRowNo.Position = 74;
            // 
            // tblVoucherPosting_colsPrevAccount
            // 
            resources.ApplyResources(this.tblVoucherPosting_colsPrevAccount, "tblVoucherPosting_colsPrevAccount");
            this.tblVoucherPosting_colsPrevAccount.Name = "tblVoucherPosting_colsPrevAccount";
            this.tblVoucherPosting_colsPrevAccount.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colsPrevAccount.NamedProperties.Put("LovReference", "");
            this.tblVoucherPosting_colsPrevAccount.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherPosting_colsPrevAccount.NamedProperties.Put("SqlColumn", "");
            this.tblVoucherPosting_colsPrevAccount.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherPosting_colsPrevAccount.Position = 75;
            // 
            // tblVoucherPosting_colsPrevTaxCode
            // 
            resources.ApplyResources(this.tblVoucherPosting_colsPrevTaxCode, "tblVoucherPosting_colsPrevTaxCode");
            this.tblVoucherPosting_colsPrevTaxCode.Name = "tblVoucherPosting_colsPrevTaxCode";
            this.tblVoucherPosting_colsPrevTaxCode.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colsPrevTaxCode.NamedProperties.Put("LovReference", "");
            this.tblVoucherPosting_colsPrevTaxCode.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherPosting_colsPrevTaxCode.NamedProperties.Put("SqlColumn", "");
            this.tblVoucherPosting_colsPrevTaxCode.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherPosting_colsPrevTaxCode.Position = 76;
            // 
            // tblVoucherPosting_colsPrevCurrencyCode
            // 
            resources.ApplyResources(this.tblVoucherPosting_colsPrevCurrencyCode, "tblVoucherPosting_colsPrevCurrencyCode");
            this.tblVoucherPosting_colsPrevCurrencyCode.Name = "tblVoucherPosting_colsPrevCurrencyCode";
            this.tblVoucherPosting_colsPrevCurrencyCode.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colsPrevCurrencyCode.NamedProperties.Put("LovReference", "");
            this.tblVoucherPosting_colsPrevCurrencyCode.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherPosting_colsPrevCurrencyCode.NamedProperties.Put("SqlColumn", "");
            this.tblVoucherPosting_colsPrevCurrencyCode.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherPosting_colsPrevCurrencyCode.Position = 77;
            // 
            // tblVoucherPosting_colnPrevAmount
            // 
            this.tblVoucherPosting_colnPrevAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.tblVoucherPosting_colnPrevAmount, "tblVoucherPosting_colnPrevAmount");
            this.tblVoucherPosting_colnPrevAmount.Name = "tblVoucherPosting_colnPrevAmount";
            this.tblVoucherPosting_colnPrevAmount.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colnPrevAmount.NamedProperties.Put("Format", "20");
            this.tblVoucherPosting_colnPrevAmount.NamedProperties.Put("LovReference", "");
            this.tblVoucherPosting_colnPrevAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherPosting_colnPrevAmount.NamedProperties.Put("SqlColumn", "");
            this.tblVoucherPosting_colnPrevAmount.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherPosting_colnPrevAmount.Position = 78;
            this.tblVoucherPosting_colnPrevAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tblVoucherPosting_colnPrevCurrencyAmount
            // 
            this.tblVoucherPosting_colnPrevCurrencyAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.tblVoucherPosting_colnPrevCurrencyAmount, "tblVoucherPosting_colnPrevCurrencyAmount");
            this.tblVoucherPosting_colnPrevCurrencyAmount.Name = "tblVoucherPosting_colnPrevCurrencyAmount";
            this.tblVoucherPosting_colnPrevCurrencyAmount.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colnPrevCurrencyAmount.NamedProperties.Put("Format", "20");
            this.tblVoucherPosting_colnPrevCurrencyAmount.NamedProperties.Put("LovReference", "");
            this.tblVoucherPosting_colnPrevCurrencyAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherPosting_colnPrevCurrencyAmount.NamedProperties.Put("SqlColumn", "");
            this.tblVoucherPosting_colnPrevCurrencyAmount.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherPosting_colnPrevCurrencyAmount.Position = 79;
            this.tblVoucherPosting_colnPrevCurrencyAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tblVoucherPosting_colsTaxType
            // 
            resources.ApplyResources(this.tblVoucherPosting_colsTaxType, "tblVoucherPosting_colsTaxType");
            this.tblVoucherPosting_colsTaxType.Name = "tblVoucherPosting_colsTaxType";
            this.tblVoucherPosting_colsTaxType.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colsTaxType.NamedProperties.Put("LovReference", "");
            this.tblVoucherPosting_colsTaxType.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherPosting_colsTaxType.NamedProperties.Put("SqlColumn", "");
            this.tblVoucherPosting_colsTaxType.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherPosting_colsTaxType.Position = 80;
            // 
            // tblVoucherPosting_colsProjectActivityIdEnabled
            // 
            resources.ApplyResources(this.tblVoucherPosting_colsProjectActivityIdEnabled, "tblVoucherPosting_colsProjectActivityIdEnabled");
            this.tblVoucherPosting_colsProjectActivityIdEnabled.MaxLength = 1;
            this.tblVoucherPosting_colsProjectActivityIdEnabled.Name = "tblVoucherPosting_colsProjectActivityIdEnabled";
            this.tblVoucherPosting_colsProjectActivityIdEnabled.Position = 81;
            // 
            // tblVoucherPosting_colsProjectId
            // 
            resources.ApplyResources(this.tblVoucherPosting_colsProjectId, "tblVoucherPosting_colsProjectId");
            this.tblVoucherPosting_colsProjectId.MaxLength = 20;
            this.tblVoucherPosting_colsProjectId.Name = "tblVoucherPosting_colsProjectId";
            this.tblVoucherPosting_colsProjectId.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colsProjectId.NamedProperties.Put("FieldFlags", "768");
            this.tblVoucherPosting_colsProjectId.NamedProperties.Put("LovReference", "");
            this.tblVoucherPosting_colsProjectId.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherPosting_colsProjectId.NamedProperties.Put("SqlColumn", "PROJECT_ID");
            this.tblVoucherPosting_colsProjectId.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherPosting_colsProjectId.Position = 82;
            // 
            // tblVoucherPosting_colnInternalSeqNumber
            // 
            this.tblVoucherPosting_colnInternalSeqNumber.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.tblVoucherPosting_colnInternalSeqNumber, "tblVoucherPosting_colnInternalSeqNumber");
            this.tblVoucherPosting_colnInternalSeqNumber.Name = "tblVoucherPosting_colnInternalSeqNumber";
            this.tblVoucherPosting_colnInternalSeqNumber.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colnInternalSeqNumber.NamedProperties.Put("FieldFlags", "258");
            this.tblVoucherPosting_colnInternalSeqNumber.NamedProperties.Put("LovReference", "");
            this.tblVoucherPosting_colnInternalSeqNumber.NamedProperties.Put("SqlColumn", "INTERNAL_SEQ_NUMBER");
            this.tblVoucherPosting_colnInternalSeqNumber.Position = 83;
            // 
            // tblVoucherPosting_colsManualAdded
            // 
            resources.ApplyResources(this.tblVoucherPosting_colsManualAdded, "tblVoucherPosting_colsManualAdded");
            this.tblVoucherPosting_colsManualAdded.Name = "tblVoucherPosting_colsManualAdded";
            this.tblVoucherPosting_colsManualAdded.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colsManualAdded.NamedProperties.Put("LovReference", "");
            this.tblVoucherPosting_colsManualAdded.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherPosting_colsManualAdded.NamedProperties.Put("SqlColumn", "VOUCHER_ROW_API.Is_Manual_Added(COMPANY,INTERNAL_SEQ_NUMBER,ACCOUNT)");
            this.tblVoucherPosting_colsManualAdded.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherPosting_colsManualAdded.Position = 84;
            // 
            // tblVoucherPosting_colsFunctionGroup
            // 
            this.tblVoucherPosting_colsFunctionGroup.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblVoucherPosting_colsFunctionGroup, "tblVoucherPosting_colsFunctionGroup");
            this.tblVoucherPosting_colsFunctionGroup.MaxLength = 20;
            this.tblVoucherPosting_colsFunctionGroup.Name = "tblVoucherPosting_colsFunctionGroup";
            this.tblVoucherPosting_colsFunctionGroup.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colsFunctionGroup.NamedProperties.Put("FieldFlags", "262");
            this.tblVoucherPosting_colsFunctionGroup.NamedProperties.Put("LovReference", "");
            this.tblVoucherPosting_colsFunctionGroup.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherPosting_colsFunctionGroup.NamedProperties.Put("SqlColumn", "FUNCTION_GROUP");
            this.tblVoucherPosting_colsFunctionGroup.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherPosting_colsFunctionGroup.Position = 85;
            // 
            // tblVoucherPosting_colnActCurrencyRate
            // 
            this.tblVoucherPosting_colnActCurrencyRate.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.tblVoucherPosting_colnActCurrencyRate, "tblVoucherPosting_colnActCurrencyRate");
            this.tblVoucherPosting_colnActCurrencyRate.Name = "tblVoucherPosting_colnActCurrencyRate";
            this.tblVoucherPosting_colnActCurrencyRate.Position = 86;
            // 
            // tblVoucherPosting_colsTransferId
            // 
            resources.ApplyResources(this.tblVoucherPosting_colsTransferId, "tblVoucherPosting_colsTransferId");
            this.tblVoucherPosting_colsTransferId.MaxLength = 200;
            this.tblVoucherPosting_colsTransferId.Name = "tblVoucherPosting_colsTransferId";
            this.tblVoucherPosting_colsTransferId.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colsTransferId.NamedProperties.Put("FieldFlags", "258");
            this.tblVoucherPosting_colsTransferId.NamedProperties.Put("LovReference", "");
            this.tblVoucherPosting_colsTransferId.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherPosting_colsTransferId.NamedProperties.Put("SqlColumn", "TRANSFER_ID");
            this.tblVoucherPosting_colsTransferId.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherPosting_colsTransferId.Position = 87;
            // 
            // tblVoucherPosting_colnParallelCurrTaxBaseAmount
            // 
            this.tblVoucherPosting_colnParallelCurrTaxBaseAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVoucherPosting_colnParallelCurrTaxBaseAmount.Name = "tblVoucherPosting_colnParallelCurrTaxBaseAmount";
            this.tblVoucherPosting_colnParallelCurrTaxBaseAmount.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colnParallelCurrTaxBaseAmount.NamedProperties.Put("FieldFlags", "262");
            this.tblVoucherPosting_colnParallelCurrTaxBaseAmount.NamedProperties.Put("Format", "");
            this.tblVoucherPosting_colnParallelCurrTaxBaseAmount.NamedProperties.Put("LovReference", "");
            this.tblVoucherPosting_colnParallelCurrTaxBaseAmount.NamedProperties.Put("SqlColumn", "PARALLEL_CURR_TAX_BASE_AMOUNT");
            this.tblVoucherPosting_colnParallelCurrTaxBaseAmount.Position = 88;
            this.tblVoucherPosting_colnParallelCurrTaxBaseAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblVoucherPosting_colnParallelCurrTaxBaseAmount, "tblVoucherPosting_colnParallelCurrTaxBaseAmount");
            // 
            // tblVoucherPosting_colnParallelCurrGrossAmount
            // 
            this.tblVoucherPosting_colnParallelCurrGrossAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVoucherPosting_colnParallelCurrGrossAmount.Name = "tblVoucherPosting_colnParallelCurrGrossAmount";
            this.tblVoucherPosting_colnParallelCurrGrossAmount.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherPosting_colnParallelCurrGrossAmount.NamedProperties.Put("FieldFlags", "262");
            this.tblVoucherPosting_colnParallelCurrGrossAmount.NamedProperties.Put("Format", "");
            this.tblVoucherPosting_colnParallelCurrGrossAmount.NamedProperties.Put("LovReference", "");
            this.tblVoucherPosting_colnParallelCurrGrossAmount.NamedProperties.Put("SqlColumn", "PARALLEL_CURR_GROSS_AMOUNT");
            this.tblVoucherPosting_colnParallelCurrGrossAmount.Position = 89;
            this.tblVoucherPosting_colnParallelCurrGrossAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblVoucherPosting_colnParallelCurrGrossAmount, "tblVoucherPosting_colnParallelCurrGrossAmount");
            // 
            // frmVoucherPosting
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.labeldfnParallelCurrBalance);
            this.Controls.Add(this.dfnParallelCurrBalance);
            this.Controls.Add(this.tblVoucherPosting);
            this.Controls.Add(this.dfnBalance);
            this.Controls.Add(this.dfnCurrencyBalance);
            this.Controls.Add(this.dfsCodePartDescription);
            this.Controls.Add(this.dfsCodePartValue);
            this.Controls.Add(this.labeldfnBalance);
            this.Controls.Add(this.labeldfnCurrencyBalance);
            this.Controls.Add(this.labeldfsCodePartDescription);
            this.Controls.Add(this.labeldfsCodePartValue);
            this.Name = "frmVoucherPosting";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "");
            this.NamedProperties.Put("PackageName", "");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "129");
            this.NamedProperties.Put("ViewName", "");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.frmVoucherPosting_WindowActions);
            this.menuTblMethods.ResumeLayout(false);
            this.tblVoucherPosting.ResumeLayout(false);
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
		
        public Fnd.Windows.Forms.FndCommand menuTblMethods_menuInternal_Manual_Postings___;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTblMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Internal;        
        public cBackgroundText labeldfnParallelCurrBalance;
        public Ifs.Application.Accrul.cDataFieldFinEuro dfnParallelCurrBalance;
        public cChildTableFin tblVoucherPosting;
        public cColumn tblVoucherPosting_colsCompany;
        public cColumn tblVoucherPosting_colsVoucherType;
        public cColumn tblVoucherPosting_colnAccountingYear;
        public cColumn tblVoucherPosting_colnVoucherNo;
        protected cColumn tblVoucherPosting_colnRowNo;
        protected cColumn tblVoucherPosting_colnRowGroupId;
        public cColumnCodePartFin tblVoucherPosting_colsAccount;
        protected cColumnCodePartDescFin tblVoucherPosting_colsAccountDesc;
        protected cColumnCodePartFin tblVoucherPosting_colsCodeB;
        protected cColumnCodePartDescFin tblVoucherPosting_colsCodeBDesc;
        protected cColumnCodePartFin tblVoucherPosting_colsCodeC;
        protected cColumnCodePartDescFin tblVoucherPosting_colsCodeCDesc;
        protected cColumnCodePartFin tblVoucherPosting_colsCodeD;
        protected cColumnCodePartDescFin tblVoucherPosting_colsCodeDDesc;
        protected cColumnCodePartFin tblVoucherPosting_colsCodeE;
        protected cColumnCodePartDescFin tblVoucherPosting_colsCodeEDesc;
        protected cColumnCodePartFin tblVoucherPosting_colsCodeF;
        protected cColumnCodePartDescFin tblVoucherPosting_colsCodeFDesc;
        protected cColumnCodePartFin tblVoucherPosting_colsCodeG;
        protected cColumnCodePartDescFin tblVoucherPosting_colsCodeGDesc;
        protected cColumnCodePartFin tblVoucherPosting_colsCodeH;
        protected cColumnCodePartDescFin tblVoucherPosting_colsCodeHDesc;
        protected cColumnCodePartFin tblVoucherPosting_colsCodeI;
        protected cColumnCodePartDescFin tblVoucherPosting_colsCodeIDesc;
        protected cColumnCodePartFin tblVoucherPosting_colsCodeJ;
        protected cColumnCodePartDescFin tblVoucherPosting_colsCodeJDesc;
        protected cColumnCodePartFin tblVoucherPosting_colsProcessCode;
        public cColumn tblVoucherPosting_colsOptionalCode;
        protected cLookupColumn tblVoucherPosting_colsTaxDirection;
        public cColumn tblVoucherPosting_colsCurrencyCode;
        public cColumn tblVoucherPosting_colsCurrencyType;
        protected cCheckBoxColumn tblVoucherPosting_colCorrection;
        protected cColumn tblVoucherPosting_colnCurrencyDebetAmount;
        protected cColumn tblVoucherPosting_colnCurrencyCreditAmount;
        public cColumn tblVoucherPosting_colnCurrencyAmount;
        protected cColumn tblVoucherPosting_colnCurrencyTaxAmount;
        protected cColumn tblVoucherPosting_colnCurrencyGrossAmount;
        protected cColumn tblVoucherPosting_colnCurrencyRate;
        protected cColumn tblVoucherPosting_colnConversionFactor;
        protected cColumn tblVoucherPosting_colnDebetAmount;
        protected cColumn tblVoucherPosting_colnCreditAmount;
        public cColumn tblVoucherPosting_colnAmount;
        protected cColumn tblVoucherPosting_colnTaxAmount;
        protected cColumn tblVoucherPosting_colnGrossAmount;
        public cColumn tblVoucherPosting_colnParallelCurrRateType;
        protected cColumn tblVoucherPosting_colnParallelCurrRate;
        protected cColumn tblVoucherPosting_colnParallelCurrConvFactor;
        protected cColumnFinEuro tblVoucherPosting_colnThirdCurrencyDebitAmount;
        protected cColumnFinEuro tblVoucherPosting_colnThirdCurrencyCreditAmount;
        protected cColumnFinEuro tblVoucherPosting_colnParallelCurrTaxAmount;
        public cColumn tblVoucherPosting_colnQuantity;
        protected cCheckBoxColumn tblVoucherPosting_colsPeriodAllocation;
        public cColumn tblVoucherPosting_colsTextId;
        protected cColumn tblVoucherPosting_colsText;
        protected cColumn tblVoucherPosting_colnProjectActivityId;
        protected cColumn tblVoucherPosting_colsUpdateError;
        public cColumn tblVoucherPosting_colsTransCode;
        public cCheckBoxColumn tblVoucherPosting_colAddInternal;
        protected cColumn tblVoucherPosting_colnManualCounter;
        protected cColumn tblVoucherPosting_colsReferenceSerie;
        protected cColumn tblVoucherPosting_colsReferenceNumber;
        protected cColumn tblVoucherPosting_colnAccountingPeriod;
        public cColumn tblVoucherPosting_colIsStatAccount;
        protected cColumn tblVoucherPosting_colnDecimalsInAmount;
        protected cColumn tblVoucherPosting_colnAccDecimalsInAmount;
        protected cColumn tblVoucherPosting_colsCodeDemand;
        protected cColumn tblVoucherPosting_colsLedgerIds;
        public cColumn tblVoucherPosting_colsAutoTaxVouEntry;
        protected cColumn tblVoucherPosting_colnReferenceRowNo;
        protected cColumn tblVoucherPosting_colsPrevAccount;
        protected cColumn tblVoucherPosting_colsPrevTaxCode;
        protected cColumn tblVoucherPosting_colsPrevCurrencyCode;
        protected cColumn tblVoucherPosting_colnPrevAmount;
        protected cColumn tblVoucherPosting_colnPrevCurrencyAmount;
        protected cColumn tblVoucherPosting_colsProjectActivityIdEnabled;
        protected cColumn tblVoucherPosting_colsProjectId;
        protected cColumn tblVoucherPosting_colnInternalSeqNumber;
        public cCheckBoxColumn tblVoucherPosting_colsManualAdded;
        protected cColumn tblVoucherPosting_colsFunctionGroup;
        protected cColumn tblVoucherPosting_colnActCurrencyRate;
        protected cColumn tblVoucherPosting_colsTransferId;
        protected cColumn tblVoucherPosting_colnParallelCurrTaxBaseAmount;
        protected cColumn tblVoucherPosting_colnParallelCurrGrossAmount;
        protected internal cColumnFinEuro tblVoucherPosting_colnThirdCurrencyAmount;
        protected cColumn tblVoucherPosting_colsDeliveryTypeId;
        protected cColumn tblVoucherPosting_colsDeliveryTypeDescription;
        public cColumn tblVoucherPosting_colsTaxType;
	}
}
