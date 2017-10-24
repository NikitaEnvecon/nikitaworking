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
	
	public partial class dlgManualIntPosting
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cDataFieldDlgFin dfsCompany;
		public cDataFieldDlgFin dfsLedgerId;
		public cDataFieldDlgFin dfnInternalSeqNumber;
		protected cBackgroundText labeldfAccount;
		public cDataFieldDlgFin dfAccount;
		public cDataFieldDlgFin dfsVoucherType;
		public cDataFieldDlgFin dfnAccountingYear;
		public cDataFieldDlgFin dfnVoucherNo;
		public cDataFieldDlgFin dfnRefRowNo;
		protected cBackgroundText labeldfAccntDescription;
		public cDataFieldDlgFin dfAccntDescription;
		protected cBackgroundText labeldfSumPercentage;
		public cDataFieldDlgFin dfSumPercentage;
		// Currency Balance and Balance will be displayed with switch in sign
		protected cBackgroundText labeldfCurrBalance;
		public cDataFieldDlgFin dfCurrBalance;
		protected cBackgroundText labeldfBalance;
        public cDataFieldDlgFin dfBalance;
		public cPushButton pbOk;
		public cPushButton pbCancel;
		public cPushButton pbNew;
		public cPushButton pbRemove;
		public cPushButton pbSave;
		public cPushButton pbList;
		protected SalGroupBox gbEntry_Based_On;
		public cRadioButton rbAmount;
		public cRadioButton rbPercentage;
		protected cBackgroundText labeldfsCodePartValue;
		public cDataFieldFinContent dfsCodePartValue;
		protected cBackgroundText labeldfsCodePartDescription;
		public cDataFieldFinDescription dfsCodePartDescription;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgManualIntPosting));
            this.dfsCompany = new Ifs.Application.Accrul.cDataFieldDlgFin();
            this.dfsLedgerId = new Ifs.Application.Accrul.cDataFieldDlgFin();
            this.dfnInternalSeqNumber = new Ifs.Application.Accrul.cDataFieldDlgFin();
            this.labeldfAccount = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfAccount = new Ifs.Application.Accrul.cDataFieldDlgFin();
            this.dfsVoucherType = new Ifs.Application.Accrul.cDataFieldDlgFin();
            this.dfnAccountingYear = new Ifs.Application.Accrul.cDataFieldDlgFin();
            this.dfnVoucherNo = new Ifs.Application.Accrul.cDataFieldDlgFin();
            this.dfnRefRowNo = new Ifs.Application.Accrul.cDataFieldDlgFin();
            this.labeldfAccntDescription = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfAccntDescription = new Ifs.Application.Accrul.cDataFieldDlgFin();
            this.labeldfSumPercentage = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfSumPercentage = new Ifs.Application.Accrul.cDataFieldDlgFin();
            this.labeldfCurrBalance = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfCurrBalance = new Ifs.Application.Accrul.cDataFieldDlgFin();
            this.labeldfBalance = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfBalance = new Ifs.Application.Accrul.cDataFieldDlgFin();
            this.pbOk = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbCancel = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbNew = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbRemove = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbSave = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbList = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.gbEntry_Based_On = new PPJ.Runtime.Windows.SalGroupBox();
            this.rbAmount = new Ifs.Fnd.ApplicationForms.cRadioButton();
            this.rbPercentage = new Ifs.Fnd.ApplicationForms.cRadioButton();
            this.labeldfsCodePartValue = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsCodePartValue = new Ifs.Application.Accrul.cDataFieldFinContent();
            this.labeldfsCodePartDescription = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsCodePartDescription = new Ifs.Application.Accrul.cDataFieldFinDescription();
            this.tblIntPostings = new Ifs.Application.Accrul.cChildTableFin();
            this.tblIntPostings_colsCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblIntPostings_colsLedgerId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblIntPostings_colnInternalSeqNumber = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblIntPostings_colsAccount = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.tblIntPostings_colsAccountDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.tblIntPostings_colnRefRowNo = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblIntPostings_colsVoucherType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblIntPostings_colnAccountingYear = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblIntPostings_colnVoucherNo = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblIntPostings_colsCodeB = new Ifs.Application.Accrul.cColumnCodePartInt();
            this.tblIntPostings_colsCodeBDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.tblIntPostings_colsCodeC = new Ifs.Application.Accrul.cColumnCodePartInt();
            this.tblIntPostings_colsCodeCDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.tblIntPostings_colsCodeD = new Ifs.Application.Accrul.cColumnCodePartInt();
            this.tblIntPostings_colsCodeDDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.tblIntPostings_colsCodeE = new Ifs.Application.Accrul.cColumnCodePartInt();
            this.tblIntPostings_colsCodeEDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.tblIntPostings_colsCodeF = new Ifs.Application.Accrul.cColumnCodePartInt();
            this.tblIntPostings_colsCodeFDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.tblIntPostings_colsCodeG = new Ifs.Application.Accrul.cColumnCodePartInt();
            this.tblIntPostings_colsCodeGDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.tblIntPostings_colsCodeH = new Ifs.Application.Accrul.cColumnCodePartInt();
            this.tblIntPostings_colsCodeHDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.tblIntPostings_colsCodeI = new Ifs.Application.Accrul.cColumnCodePartInt();
            this.tblIntPostings_colsCodeIDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.tblIntPostings_colsCodeJ = new Ifs.Application.Accrul.cColumnCodePartInt();
            this.tblIntPostings_colsCodeJDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.tblIntPostings_colnPercentage = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblIntPostings_colnCurrencyDebitAmount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblIntPostings_colnCurrencyCreditAmount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblIntPostings_colnCurrencyAmount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblIntPostings_colnDebitAmount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblIntPostings_colnCreditAmount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblIntPostings_colnAmount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblIntPostings_colnCurrencyRate = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblIntPostings_colsText = new Ifs.Fnd.ApplicationForms.cColumn();
            this.ClientArea.SuspendLayout();
            this.tblIntPostings.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolBar
            // 
            resources.ApplyResources(this.ToolBar, "ToolBar");
            // 
            // ClientArea
            // 
            this.ClientArea.Controls.Add(this.dfsCodePartDescription);
            this.ClientArea.Controls.Add(this.dfsCodePartValue);
            this.ClientArea.Controls.Add(this.rbPercentage);
            this.ClientArea.Controls.Add(this.rbAmount);
            this.ClientArea.Controls.Add(this.pbList);
            this.ClientArea.Controls.Add(this.pbSave);
            this.ClientArea.Controls.Add(this.pbRemove);
            this.ClientArea.Controls.Add(this.pbNew);
            this.ClientArea.Controls.Add(this.pbCancel);
            this.ClientArea.Controls.Add(this.pbOk);
            this.ClientArea.Controls.Add(this.tblIntPostings);
            this.ClientArea.Controls.Add(this.dfBalance);
            this.ClientArea.Controls.Add(this.dfCurrBalance);
            this.ClientArea.Controls.Add(this.dfSumPercentage);
            this.ClientArea.Controls.Add(this.dfAccntDescription);
            this.ClientArea.Controls.Add(this.dfnRefRowNo);
            this.ClientArea.Controls.Add(this.dfnVoucherNo);
            this.ClientArea.Controls.Add(this.dfnAccountingYear);
            this.ClientArea.Controls.Add(this.dfsVoucherType);
            this.ClientArea.Controls.Add(this.dfAccount);
            this.ClientArea.Controls.Add(this.dfnInternalSeqNumber);
            this.ClientArea.Controls.Add(this.dfsLedgerId);
            this.ClientArea.Controls.Add(this.dfsCompany);
            this.ClientArea.Controls.Add(this.labeldfsCodePartDescription);
            this.ClientArea.Controls.Add(this.labeldfsCodePartValue);
            this.ClientArea.Controls.Add(this.labeldfBalance);
            this.ClientArea.Controls.Add(this.labeldfCurrBalance);
            this.ClientArea.Controls.Add(this.labeldfSumPercentage);
            this.ClientArea.Controls.Add(this.labeldfAccntDescription);
            this.ClientArea.Controls.Add(this.labeldfAccount);
            this.ClientArea.Controls.Add(this.gbEntry_Based_On);
            resources.ApplyResources(this.ClientArea, "ClientArea");
            // 
            // StatusBar
            // 
            resources.ApplyResources(this.StatusBar, "StatusBar");
            // 
            // commandManager
            // 
            this.commandManager.Components.Add(this.pbList);
            this.commandManager.Components.Add(this.pbSave);
            this.commandManager.Components.Add(this.pbRemove);
            this.commandManager.Components.Add(this.pbNew);
            this.commandManager.Components.Add(this.pbCancel);
            this.commandManager.Components.Add(this.pbOk);
            // 
            // dfsCompany
            // 
            this.dfsCompany.Name = "dfsCompany";
            this.dfsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.dfsCompany.NamedProperties.Put("FieldFlags", "768");
            this.dfsCompany.NamedProperties.Put("LovReference", "");
            this.dfsCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.dfsCompany.NamedProperties.Put("ValidateMethod", "");
            resources.ApplyResources(this.dfsCompany, "dfsCompany");
            // 
            // dfsLedgerId
            // 
            this.dfsLedgerId.Name = "dfsLedgerId";
            this.dfsLedgerId.NamedProperties.Put("EnumerateMethod", "");
            this.dfsLedgerId.NamedProperties.Put("FieldFlags", "768");
            this.dfsLedgerId.NamedProperties.Put("LovReference", "");
            this.dfsLedgerId.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsLedgerId.NamedProperties.Put("SqlColumn", "LEDGER_ID");
            this.dfsLedgerId.NamedProperties.Put("ValidateMethod", "");
            resources.ApplyResources(this.dfsLedgerId, "dfsLedgerId");
            // 
            // dfnInternalSeqNumber
            // 
            this.dfnInternalSeqNumber.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfnInternalSeqNumber, "dfnInternalSeqNumber");
            this.dfnInternalSeqNumber.Name = "dfnInternalSeqNumber";
            this.dfnInternalSeqNumber.NamedProperties.Put("EnumerateMethod", "");
            this.dfnInternalSeqNumber.NamedProperties.Put("FieldFlags", "768");
            this.dfnInternalSeqNumber.NamedProperties.Put("LovReference", "");
            this.dfnInternalSeqNumber.NamedProperties.Put("ResizeableChildObject", "");
            this.dfnInternalSeqNumber.NamedProperties.Put("SqlColumn", "INTERNAL_SEQ_NUMBER");
            this.dfnInternalSeqNumber.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfAccount
            // 
            resources.ApplyResources(this.labeldfAccount, "labeldfAccount");
            this.labeldfAccount.Name = "labeldfAccount";
            // 
            // dfAccount
            // 
            this.dfAccount.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.dfAccount, "dfAccount");
            this.dfAccount.Name = "dfAccount";
            this.dfAccount.NamedProperties.Put("EnumerateMethod", "");
            this.dfAccount.NamedProperties.Put("FieldFlags", "768");
            this.dfAccount.NamedProperties.Put("LovReference", "");
            this.dfAccount.NamedProperties.Put("ResizeableChildObject", "");
            this.dfAccount.NamedProperties.Put("SqlColumn", "ACCOUNT");
            this.dfAccount.NamedProperties.Put("ValidateMethod", "");
            this.dfAccount.ReadOnly = true;
            // 
            // dfsVoucherType
            // 
            resources.ApplyResources(this.dfsVoucherType, "dfsVoucherType");
            this.dfsVoucherType.Name = "dfsVoucherType";
            this.dfsVoucherType.NamedProperties.Put("EnumerateMethod", "");
            this.dfsVoucherType.NamedProperties.Put("FieldFlags", "768");
            this.dfsVoucherType.NamedProperties.Put("LovReference", "");
            this.dfsVoucherType.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsVoucherType.NamedProperties.Put("SqlColumn", "VOUCHER_TYPE");
            this.dfsVoucherType.NamedProperties.Put("ValidateMethod", "");
            // 
            // dfnAccountingYear
            // 
            this.dfnAccountingYear.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfnAccountingYear, "dfnAccountingYear");
            this.dfnAccountingYear.Name = "dfnAccountingYear";
            this.dfnAccountingYear.NamedProperties.Put("EnumerateMethod", "");
            this.dfnAccountingYear.NamedProperties.Put("FieldFlags", "768");
            this.dfnAccountingYear.NamedProperties.Put("LovReference", "");
            this.dfnAccountingYear.NamedProperties.Put("ResizeableChildObject", "");
            this.dfnAccountingYear.NamedProperties.Put("SqlColumn", "ACCOUNTING_YEAR");
            this.dfnAccountingYear.NamedProperties.Put("ValidateMethod", "");
            // 
            // dfnVoucherNo
            // 
            this.dfnVoucherNo.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfnVoucherNo, "dfnVoucherNo");
            this.dfnVoucherNo.Name = "dfnVoucherNo";
            this.dfnVoucherNo.NamedProperties.Put("EnumerateMethod", "");
            this.dfnVoucherNo.NamedProperties.Put("FieldFlags", "768");
            this.dfnVoucherNo.NamedProperties.Put("LovReference", "");
            this.dfnVoucherNo.NamedProperties.Put("ResizeableChildObject", "");
            this.dfnVoucherNo.NamedProperties.Put("SqlColumn", "VOUCHER_NO");
            this.dfnVoucherNo.NamedProperties.Put("ValidateMethod", "");
            // 
            // dfnRefRowNo
            // 
            this.dfnRefRowNo.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfnRefRowNo, "dfnRefRowNo");
            this.dfnRefRowNo.Name = "dfnRefRowNo";
            this.dfnRefRowNo.NamedProperties.Put("EnumerateMethod", "");
            this.dfnRefRowNo.NamedProperties.Put("FieldFlags", "768");
            this.dfnRefRowNo.NamedProperties.Put("LovReference", "");
            this.dfnRefRowNo.NamedProperties.Put("ResizeableChildObject", "");
            this.dfnRefRowNo.NamedProperties.Put("SqlColumn", "VOUCHER_NO");
            this.dfnRefRowNo.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfAccntDescription
            // 
            resources.ApplyResources(this.labeldfAccntDescription, "labeldfAccntDescription");
            this.labeldfAccntDescription.Name = "labeldfAccntDescription";
            // 
            // dfAccntDescription
            // 
            this.dfAccntDescription.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.dfAccntDescription, "dfAccntDescription");
            this.dfAccntDescription.Name = "dfAccntDescription";
            this.dfAccntDescription.NamedProperties.Put("EnumerateMethod", "");
            this.dfAccntDescription.NamedProperties.Put("FieldFlags", "768");
            this.dfAccntDescription.NamedProperties.Put("LovReference", "");
            this.dfAccntDescription.NamedProperties.Put("ParentName", "dfAccount");
            this.dfAccntDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.dfAccntDescription.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            this.dfAccntDescription.NamedProperties.Put("ValidateMethod", "");
            this.dfAccntDescription.ReadOnly = true;
            // 
            // labeldfSumPercentage
            // 
            resources.ApplyResources(this.labeldfSumPercentage, "labeldfSumPercentage");
            this.labeldfSumPercentage.Name = "labeldfSumPercentage";
            // 
            // dfSumPercentage
            // 
            this.dfSumPercentage.BackColor = System.Drawing.SystemColors.Control;
            this.dfSumPercentage.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfSumPercentage, "dfSumPercentage");
            this.dfSumPercentage.Name = "dfSumPercentage";
            this.dfSumPercentage.NamedProperties.Put("EnumerateMethod", "");
            this.dfSumPercentage.NamedProperties.Put("LovReference", "");
            this.dfSumPercentage.NamedProperties.Put("ResizeableChildObject", "");
            this.dfSumPercentage.NamedProperties.Put("SqlColumn", "");
            this.dfSumPercentage.NamedProperties.Put("ValidateMethod", "");
            this.dfSumPercentage.ReadOnly = true;
            // 
            // labeldfCurrBalance
            // 
            resources.ApplyResources(this.labeldfCurrBalance, "labeldfCurrBalance");
            this.labeldfCurrBalance.Name = "labeldfCurrBalance";
            // 
            // dfCurrBalance
            // 
            this.dfCurrBalance.BackColor = System.Drawing.SystemColors.Control;
            this.dfCurrBalance.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfCurrBalance, "dfCurrBalance");
            this.dfCurrBalance.Name = "dfCurrBalance";
            this.dfCurrBalance.NamedProperties.Put("EnumerateMethod", "");
            this.dfCurrBalance.NamedProperties.Put("FieldFlags", "260");
            this.dfCurrBalance.NamedProperties.Put("Format", "20");
            this.dfCurrBalance.NamedProperties.Put("LovReference", "");
            this.dfCurrBalance.NamedProperties.Put("ResizeableChildObject", "");
            this.dfCurrBalance.NamedProperties.Put("SqlColumn", "");
            this.dfCurrBalance.NamedProperties.Put("ValidateMethod", "");
            this.dfCurrBalance.ReadOnly = true;
            // 
            // labeldfBalance
            // 
            resources.ApplyResources(this.labeldfBalance, "labeldfBalance");
            this.labeldfBalance.Name = "labeldfBalance";
            // 
            // dfBalance
            // 
            this.dfBalance.BackColor = System.Drawing.SystemColors.Control;
            this.dfBalance.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.dfBalance.Format = "N";
            resources.ApplyResources(this.dfBalance, "dfBalance");
            this.dfBalance.Name = "dfBalance";
            this.dfBalance.NamedProperties.Put("EnumerateMethod", "");
            this.dfBalance.NamedProperties.Put("FieldFlags", "260");
            this.dfBalance.NamedProperties.Put("Format", "20");
            this.dfBalance.NamedProperties.Put("LovReference", "");
            this.dfBalance.NamedProperties.Put("ResizeableChildObject", "");
            this.dfBalance.NamedProperties.Put("SqlColumn", "");
            this.dfBalance.NamedProperties.Put("ValidateMethod", "");
            this.dfBalance.ReadOnly = true;
            // 
            // pbOk
            // 
            this.pbOk.AcceleratorKey = System.Windows.Forms.Keys.Return;
            resources.ApplyResources(this.pbOk, "pbOk");
            this.pbOk.Name = "pbOk";
            this.pbOk.NamedProperties.Put("MethodId", "18385");
            this.pbOk.NamedProperties.Put("MethodParameter", "OK");
            this.pbOk.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // pbCancel
            // 
            this.pbCancel.AcceleratorKey = System.Windows.Forms.Keys.Escape;
            resources.ApplyResources(this.pbCancel, "pbCancel");
            this.pbCancel.Name = "pbCancel";
            this.pbCancel.NamedProperties.Put("MethodId", "18385");
            this.pbCancel.NamedProperties.Put("MethodParameter", "Cancel");
            this.pbCancel.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // pbNew
            // 
            this.pbNew.AcceleratorKey = System.Windows.Forms.Keys.F5;
            resources.ApplyResources(this.pbNew, "pbNew");
            this.pbNew.Name = "pbNew";
            this.pbNew.NamedProperties.Put("MethodId", "18385");
            this.pbNew.NamedProperties.Put("MethodParameter", "New");
            this.pbNew.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // pbRemove
            // 
            this.pbRemove.AcceleratorKey = System.Windows.Forms.Keys.F7;
            resources.ApplyResources(this.pbRemove, "pbRemove");
            this.pbRemove.Name = "pbRemove";
            this.pbRemove.NamedProperties.Put("MethodId", "18385");
            this.pbRemove.NamedProperties.Put("MethodParameter", "Remove");
            this.pbRemove.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // pbSave
            // 
            this.pbSave.AcceleratorKey = System.Windows.Forms.Keys.F12;
            resources.ApplyResources(this.pbSave, "pbSave");
            this.pbSave.Name = "pbSave";
            this.pbSave.NamedProperties.Put("MethodId", "18385");
            this.pbSave.NamedProperties.Put("MethodParameter", "Save");
            this.pbSave.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // pbList
            // 
            this.pbList.AcceleratorKey = System.Windows.Forms.Keys.F8;
            resources.ApplyResources(this.pbList, "pbList");
            this.pbList.Name = "pbList";
            this.pbList.NamedProperties.Put("MethodId", "18385");
            this.pbList.NamedProperties.Put("MethodParameter", "List");
            this.pbList.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // gbEntry_Based_On
            // 
            resources.ApplyResources(this.gbEntry_Based_On, "gbEntry_Based_On");
            this.gbEntry_Based_On.Name = "gbEntry_Based_On";
            this.gbEntry_Based_On.TabStop = false;
            // 
            // rbAmount
            // 
            resources.ApplyResources(this.rbAmount, "rbAmount");
            this.rbAmount.Name = "rbAmount";
            // 
            // rbPercentage
            // 
            resources.ApplyResources(this.rbPercentage, "rbPercentage");
            this.rbPercentage.Name = "rbPercentage";
            // 
            // labeldfsCodePartValue
            // 
            resources.ApplyResources(this.labeldfsCodePartValue, "labeldfsCodePartValue");
            this.labeldfsCodePartValue.Name = "labeldfsCodePartValue";
            // 
            // dfsCodePartValue
            // 
            this.dfsCodePartValue.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.dfsCodePartValue, "dfsCodePartValue");
            this.dfsCodePartValue.Name = "dfsCodePartValue";
            this.dfsCodePartValue.NamedProperties.Put("EnumerateMethod", "");
            this.dfsCodePartValue.NamedProperties.Put("LovReference", "");
            this.dfsCodePartValue.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsCodePartValue.NamedProperties.Put("SqlColumn", "");
            this.dfsCodePartValue.NamedProperties.Put("ValidateMethod", "");
            this.dfsCodePartValue.ReadOnly = true;
            // 
            // labeldfsCodePartDescription
            // 
            resources.ApplyResources(this.labeldfsCodePartDescription, "labeldfsCodePartDescription");
            this.labeldfsCodePartDescription.Name = "labeldfsCodePartDescription";
            // 
            // dfsCodePartDescription
            // 
            this.dfsCodePartDescription.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.dfsCodePartDescription, "dfsCodePartDescription");
            this.dfsCodePartDescription.Name = "dfsCodePartDescription";
            this.dfsCodePartDescription.NamedProperties.Put("EnumerateMethod", "");
            this.dfsCodePartDescription.NamedProperties.Put("LovReference", "");
            this.dfsCodePartDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsCodePartDescription.NamedProperties.Put("SqlColumn", "");
            this.dfsCodePartDescription.NamedProperties.Put("ValidateMethod", "");
            this.dfsCodePartDescription.ReadOnly = true;
            // 
            // tblIntPostings
            // 
            this.tblIntPostings.Controls.Add(this.tblIntPostings_colsCompany);
            this.tblIntPostings.Controls.Add(this.tblIntPostings_colsLedgerId);
            this.tblIntPostings.Controls.Add(this.tblIntPostings_colnInternalSeqNumber);
            this.tblIntPostings.Controls.Add(this.tblIntPostings_colsAccount);
            this.tblIntPostings.Controls.Add(this.tblIntPostings_colsAccountDesc);
            this.tblIntPostings.Controls.Add(this.tblIntPostings_colnRefRowNo);
            this.tblIntPostings.Controls.Add(this.tblIntPostings_colsVoucherType);
            this.tblIntPostings.Controls.Add(this.tblIntPostings_colnAccountingYear);
            this.tblIntPostings.Controls.Add(this.tblIntPostings_colnVoucherNo);
            this.tblIntPostings.Controls.Add(this.tblIntPostings_colsCodeB);
            this.tblIntPostings.Controls.Add(this.tblIntPostings_colsCodeBDesc);
            this.tblIntPostings.Controls.Add(this.tblIntPostings_colsCodeC);
            this.tblIntPostings.Controls.Add(this.tblIntPostings_colsCodeCDesc);
            this.tblIntPostings.Controls.Add(this.tblIntPostings_colsCodeD);
            this.tblIntPostings.Controls.Add(this.tblIntPostings_colsCodeDDesc);
            this.tblIntPostings.Controls.Add(this.tblIntPostings_colsCodeE);
            this.tblIntPostings.Controls.Add(this.tblIntPostings_colsCodeEDesc);
            this.tblIntPostings.Controls.Add(this.tblIntPostings_colsCodeF);
            this.tblIntPostings.Controls.Add(this.tblIntPostings_colsCodeFDesc);
            this.tblIntPostings.Controls.Add(this.tblIntPostings_colsCodeG);
            this.tblIntPostings.Controls.Add(this.tblIntPostings_colsCodeGDesc);
            this.tblIntPostings.Controls.Add(this.tblIntPostings_colsCodeH);
            this.tblIntPostings.Controls.Add(this.tblIntPostings_colsCodeHDesc);
            this.tblIntPostings.Controls.Add(this.tblIntPostings_colsCodeI);
            this.tblIntPostings.Controls.Add(this.tblIntPostings_colsCodeIDesc);
            this.tblIntPostings.Controls.Add(this.tblIntPostings_colsCodeJ);
            this.tblIntPostings.Controls.Add(this.tblIntPostings_colsCodeJDesc);
            this.tblIntPostings.Controls.Add(this.tblIntPostings_colnPercentage);
            this.tblIntPostings.Controls.Add(this.tblIntPostings_colnCurrencyDebitAmount);
            this.tblIntPostings.Controls.Add(this.tblIntPostings_colnCurrencyCreditAmount);
            this.tblIntPostings.Controls.Add(this.tblIntPostings_colnCurrencyAmount);
            this.tblIntPostings.Controls.Add(this.tblIntPostings_colnDebitAmount);
            this.tblIntPostings.Controls.Add(this.tblIntPostings_colnCreditAmount);
            this.tblIntPostings.Controls.Add(this.tblIntPostings_colnAmount);
            this.tblIntPostings.Controls.Add(this.tblIntPostings_colnCurrencyRate);
            this.tblIntPostings.Controls.Add(this.tblIntPostings_colsText);
            resources.ApplyResources(this.tblIntPostings, "tblIntPostings");
            this.tblIntPostings.Name = "tblIntPostings";
            this.tblIntPostings.NamedProperties.Put("DefaultOrderBy", "");
            this.tblIntPostings.NamedProperties.Put("DefaultWhere", "COMPANY = :global.company AND\r\nLEDGER_ID = :i_hWndFrame.dlgManualIntPosting.dfsLe" +
                    "dgerId AND\r\nACCOUNT = :i_hWndFrame.dlgManualIntPosting.dfAccount AND\r\nINTERNAL_S" +
                    "EQ_NUMBER = :i_hWndFrame.dlgManualIntPosting.dfnInternalSeqNumber");
            this.tblIntPostings.NamedProperties.Put("LogicalUnit", "InternalPostingsAccrul");
            this.tblIntPostings.NamedProperties.Put("PackageName", "INTERNAL_POSTINGS_ACCRUL_API");
            this.tblIntPostings.NamedProperties.Put("ResizeableChildObject", "");
            this.tblIntPostings.NamedProperties.Put("ViewName", "INTERNAL_POSTINGS_ACCRUL");
            this.tblIntPostings.NamedProperties.Put("Warnings", "FALSE");
            this.tblIntPostings.EnableDisableProjectActivityIdEvent += new System.EventHandler<Ifs.Application.Accrul.cChildTableFin.cChildTableFinEventArgs>(this.tblIntPostings_EnableDisableProjectActivityIdEvent);
            this.tblIntPostings.DataRecordExecuteModifyEvent += new Ifs.Fnd.ApplicationForms.cDataSource.DataRecordExecuteModifyEventHandler(this.tblIntPostings_DataRecordExecuteModifyEvent);
            this.tblIntPostings.DataRecordExecuteNewEvent += new Ifs.Fnd.ApplicationForms.cDataSource.DataRecordExecuteNewEventHandler(this.tblIntPostings_DataRecordExecuteNewEvent);
            this.tblIntPostings.DataRecordFetchEditedUserEvent += new Ifs.Fnd.ApplicationForms.cDataSource.DataRecordFetchEditedUserEventHandler(this.tblIntPostings_DataRecordFetchEditedUserEvent);
            this.tblIntPostings.DataRecordGetDefaultsEvent += new System.EventHandler<Ifs.Fnd.ApplicationForms.FndReturnEventArgsSalBoolean>(this.tblIntPostings_DataRecordGetDefaultsEvent);
            this.tblIntPostings.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblIntPostings_WindowActions);
            this.tblIntPostings.Controls.SetChildIndex(this.tblIntPostings_colsText, 0);
            this.tblIntPostings.Controls.SetChildIndex(this.tblIntPostings_colnCurrencyRate, 0);
            this.tblIntPostings.Controls.SetChildIndex(this.tblIntPostings_colnAmount, 0);
            this.tblIntPostings.Controls.SetChildIndex(this.tblIntPostings_colnCreditAmount, 0);
            this.tblIntPostings.Controls.SetChildIndex(this.tblIntPostings_colnDebitAmount, 0);
            this.tblIntPostings.Controls.SetChildIndex(this.tblIntPostings_colnCurrencyAmount, 0);
            this.tblIntPostings.Controls.SetChildIndex(this.tblIntPostings_colnCurrencyCreditAmount, 0);
            this.tblIntPostings.Controls.SetChildIndex(this.tblIntPostings_colnCurrencyDebitAmount, 0);
            this.tblIntPostings.Controls.SetChildIndex(this.tblIntPostings_colnPercentage, 0);
            this.tblIntPostings.Controls.SetChildIndex(this.tblIntPostings_colsCodeJDesc, 0);
            this.tblIntPostings.Controls.SetChildIndex(this.tblIntPostings_colsCodeJ, 0);
            this.tblIntPostings.Controls.SetChildIndex(this.tblIntPostings_colsCodeIDesc, 0);
            this.tblIntPostings.Controls.SetChildIndex(this.tblIntPostings_colsCodeI, 0);
            this.tblIntPostings.Controls.SetChildIndex(this.tblIntPostings_colsCodeHDesc, 0);
            this.tblIntPostings.Controls.SetChildIndex(this.tblIntPostings_colsCodeH, 0);
            this.tblIntPostings.Controls.SetChildIndex(this.tblIntPostings_colsCodeGDesc, 0);
            this.tblIntPostings.Controls.SetChildIndex(this.tblIntPostings_colsCodeG, 0);
            this.tblIntPostings.Controls.SetChildIndex(this.tblIntPostings_colsCodeFDesc, 0);
            this.tblIntPostings.Controls.SetChildIndex(this.tblIntPostings_colsCodeF, 0);
            this.tblIntPostings.Controls.SetChildIndex(this.tblIntPostings_colsCodeEDesc, 0);
            this.tblIntPostings.Controls.SetChildIndex(this.tblIntPostings_colsCodeE, 0);
            this.tblIntPostings.Controls.SetChildIndex(this.tblIntPostings_colsCodeDDesc, 0);
            this.tblIntPostings.Controls.SetChildIndex(this.tblIntPostings_colsCodeD, 0);
            this.tblIntPostings.Controls.SetChildIndex(this.tblIntPostings_colsCodeCDesc, 0);
            this.tblIntPostings.Controls.SetChildIndex(this.tblIntPostings_colsCodeC, 0);
            this.tblIntPostings.Controls.SetChildIndex(this.tblIntPostings_colsCodeBDesc, 0);
            this.tblIntPostings.Controls.SetChildIndex(this.tblIntPostings_colsCodeB, 0);
            this.tblIntPostings.Controls.SetChildIndex(this.tblIntPostings_colnVoucherNo, 0);
            this.tblIntPostings.Controls.SetChildIndex(this.tblIntPostings_colnAccountingYear, 0);
            this.tblIntPostings.Controls.SetChildIndex(this.tblIntPostings_colsVoucherType, 0);
            this.tblIntPostings.Controls.SetChildIndex(this.tblIntPostings_colnRefRowNo, 0);
            this.tblIntPostings.Controls.SetChildIndex(this.tblIntPostings_colsAccountDesc, 0);
            this.tblIntPostings.Controls.SetChildIndex(this.tblIntPostings_colsAccount, 0);
            this.tblIntPostings.Controls.SetChildIndex(this.tblIntPostings_colnInternalSeqNumber, 0);
            this.tblIntPostings.Controls.SetChildIndex(this.tblIntPostings_colsLedgerId, 0);
            this.tblIntPostings.Controls.SetChildIndex(this.tblIntPostings_colsCompany, 0);
            // 
            // tblIntPostings_colsCompany
            // 
            this.tblIntPostings_colsCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblIntPostings_colsCompany, "tblIntPostings_colsCompany");
            this.tblIntPostings_colsCompany.MaxLength = 20;
            this.tblIntPostings_colsCompany.Name = "tblIntPostings_colsCompany";
            this.tblIntPostings_colsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.tblIntPostings_colsCompany.NamedProperties.Put("FieldFlags", "99");
            this.tblIntPostings_colsCompany.NamedProperties.Put("LovReference", "");
            this.tblIntPostings_colsCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.tblIntPostings_colsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.tblIntPostings_colsCompany.NamedProperties.Put("ValidateMethod", "");
            this.tblIntPostings_colsCompany.Position = 3;
            // 
            // tblIntPostings_colsLedgerId
            // 
            resources.ApplyResources(this.tblIntPostings_colsLedgerId, "tblIntPostings_colsLedgerId");
            this.tblIntPostings_colsLedgerId.MaxLength = 10;
            this.tblIntPostings_colsLedgerId.Name = "tblIntPostings_colsLedgerId";
            this.tblIntPostings_colsLedgerId.NamedProperties.Put("EnumerateMethod", "");
            this.tblIntPostings_colsLedgerId.NamedProperties.Put("FieldFlags", "99");
            this.tblIntPostings_colsLedgerId.NamedProperties.Put("LovReference", "");
            this.tblIntPostings_colsLedgerId.NamedProperties.Put("ResizeableChildObject", "");
            this.tblIntPostings_colsLedgerId.NamedProperties.Put("SqlColumn", "LEDGER_ID");
            this.tblIntPostings_colsLedgerId.NamedProperties.Put("ValidateMethod", "");
            this.tblIntPostings_colsLedgerId.Position = 4;
            // 
            // tblIntPostings_colnInternalSeqNumber
            // 
            this.tblIntPostings_colnInternalSeqNumber.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.tblIntPostings_colnInternalSeqNumber, "tblIntPostings_colnInternalSeqNumber");
            this.tblIntPostings_colnInternalSeqNumber.Name = "tblIntPostings_colnInternalSeqNumber";
            this.tblIntPostings_colnInternalSeqNumber.NamedProperties.Put("EnumerateMethod", "");
            this.tblIntPostings_colnInternalSeqNumber.NamedProperties.Put("FieldFlags", "163");
            this.tblIntPostings_colnInternalSeqNumber.NamedProperties.Put("LovReference", "");
            this.tblIntPostings_colnInternalSeqNumber.NamedProperties.Put("SqlColumn", "INTERNAL_SEQ_NUMBER");
            this.tblIntPostings_colnInternalSeqNumber.Position = 5;
            // 
            // tblIntPostings_colsAccount
            // 
            this.tblIntPostings_colsAccount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblIntPostings_colsAccount, "tblIntPostings_colsAccount");
            this.tblIntPostings_colsAccount.MaxLength = 20;
            this.tblIntPostings_colsAccount.Name = "tblIntPostings_colsAccount";
            this.tblIntPostings_colsAccount.NamedProperties.Put("EnumerateMethod", "");
            this.tblIntPostings_colsAccount.NamedProperties.Put("FieldFlags", "99");
            this.tblIntPostings_colsAccount.NamedProperties.Put("LovReference", "ACCOUNT(COMPANY)");
            this.tblIntPostings_colsAccount.NamedProperties.Put("ResizeableChildObject", "");
            this.tblIntPostings_colsAccount.NamedProperties.Put("SqlColumn", "ACCOUNT");
            this.tblIntPostings_colsAccount.NamedProperties.Put("ValidateMethod", "");
            this.tblIntPostings_colsAccount.Position = 6;
            // 
            // tblIntPostings_colsAccountDesc
            // 
            resources.ApplyResources(this.tblIntPostings_colsAccountDesc, "tblIntPostings_colsAccountDesc");
            this.tblIntPostings_colsAccountDesc.Name = "tblIntPostings_colsAccountDesc";
            this.tblIntPostings_colsAccountDesc.NamedProperties.Put("EnumerateMethod", "");
            this.tblIntPostings_colsAccountDesc.NamedProperties.Put("LovReference", "");
            this.tblIntPostings_colsAccountDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.tblIntPostings_colsAccountDesc.NamedProperties.Put("SqlColumn", "ACCOUNT_DESC");
            this.tblIntPostings_colsAccountDesc.NamedProperties.Put("ValidateMethod", "");
            this.tblIntPostings_colsAccountDesc.Position = 7;
            // 
            // tblIntPostings_colnRefRowNo
            // 
            this.tblIntPostings_colnRefRowNo.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.tblIntPostings_colnRefRowNo, "tblIntPostings_colnRefRowNo");
            this.tblIntPostings_colnRefRowNo.Name = "tblIntPostings_colnRefRowNo";
            this.tblIntPostings_colnRefRowNo.NamedProperties.Put("EnumerateMethod", "");
            this.tblIntPostings_colnRefRowNo.NamedProperties.Put("FieldFlags", "290");
            this.tblIntPostings_colnRefRowNo.NamedProperties.Put("LovReference", "");
            this.tblIntPostings_colnRefRowNo.NamedProperties.Put("ResizeableChildObject", "");
            this.tblIntPostings_colnRefRowNo.NamedProperties.Put("SqlColumn", "REF_ROW_NO");
            this.tblIntPostings_colnRefRowNo.NamedProperties.Put("ValidateMethod", "");
            this.tblIntPostings_colnRefRowNo.Position = 8;
            // 
            // tblIntPostings_colsVoucherType
            // 
            this.tblIntPostings_colsVoucherType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblIntPostings_colsVoucherType, "tblIntPostings_colsVoucherType");
            this.tblIntPostings_colsVoucherType.MaxLength = 3;
            this.tblIntPostings_colsVoucherType.Name = "tblIntPostings_colsVoucherType";
            this.tblIntPostings_colsVoucherType.NamedProperties.Put("EnumerateMethod", "");
            this.tblIntPostings_colsVoucherType.NamedProperties.Put("FieldFlags", "291");
            this.tblIntPostings_colsVoucherType.NamedProperties.Put("LovReference", "");
            this.tblIntPostings_colsVoucherType.NamedProperties.Put("ResizeableChildObject", "");
            this.tblIntPostings_colsVoucherType.NamedProperties.Put("SqlColumn", "VOUCHER_TYPE");
            this.tblIntPostings_colsVoucherType.NamedProperties.Put("ValidateMethod", "");
            this.tblIntPostings_colsVoucherType.Position = 9;
            // 
            // tblIntPostings_colnAccountingYear
            // 
            this.tblIntPostings_colnAccountingYear.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.tblIntPostings_colnAccountingYear, "tblIntPostings_colnAccountingYear");
            this.tblIntPostings_colnAccountingYear.MaxLength = 4;
            this.tblIntPostings_colnAccountingYear.Name = "tblIntPostings_colnAccountingYear";
            this.tblIntPostings_colnAccountingYear.NamedProperties.Put("EnumerateMethod", "");
            this.tblIntPostings_colnAccountingYear.NamedProperties.Put("FieldFlags", "291");
            this.tblIntPostings_colnAccountingYear.NamedProperties.Put("LovReference", "");
            this.tblIntPostings_colnAccountingYear.NamedProperties.Put("ResizeableChildObject", "");
            this.tblIntPostings_colnAccountingYear.NamedProperties.Put("SqlColumn", "ACCOUNTING_YEAR");
            this.tblIntPostings_colnAccountingYear.NamedProperties.Put("ValidateMethod", "");
            this.tblIntPostings_colnAccountingYear.Position = 10;
            // 
            // tblIntPostings_colnVoucherNo
            // 
            this.tblIntPostings_colnVoucherNo.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.tblIntPostings_colnVoucherNo, "tblIntPostings_colnVoucherNo");
            this.tblIntPostings_colnVoucherNo.MaxLength = 10;
            this.tblIntPostings_colnVoucherNo.Name = "tblIntPostings_colnVoucherNo";
            this.tblIntPostings_colnVoucherNo.NamedProperties.Put("EnumerateMethod", "");
            this.tblIntPostings_colnVoucherNo.NamedProperties.Put("FieldFlags", "291");
            this.tblIntPostings_colnVoucherNo.NamedProperties.Put("LovReference", "");
            this.tblIntPostings_colnVoucherNo.NamedProperties.Put("ResizeableChildObject", "");
            this.tblIntPostings_colnVoucherNo.NamedProperties.Put("SqlColumn", "VOUCHER_NO");
            this.tblIntPostings_colnVoucherNo.NamedProperties.Put("ValidateMethod", "");
            this.tblIntPostings_colnVoucherNo.Position = 11;
            // 
            // tblIntPostings_colsCodeB
            // 
            this.tblIntPostings_colsCodeB.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblIntPostings_colsCodeB.MaxLength = 20;
            this.tblIntPostings_colsCodeB.Name = "tblIntPostings_colsCodeB";
            this.tblIntPostings_colsCodeB.NamedProperties.Put("EnumerateMethod", "");
            this.tblIntPostings_colsCodeB.NamedProperties.Put("FieldFlags", "294");
            this.tblIntPostings_colsCodeB.NamedProperties.Put("LovReference", "CODE_B(COMPANY)");
            this.tblIntPostings_colsCodeB.NamedProperties.Put("ResizeableChildObject", "");
            this.tblIntPostings_colsCodeB.NamedProperties.Put("SqlColumn", "CODE_B");
            this.tblIntPostings_colsCodeB.NamedProperties.Put("ValidateMethod", "");
            this.tblIntPostings_colsCodeB.Position = 12;
            resources.ApplyResources(this.tblIntPostings_colsCodeB, "tblIntPostings_colsCodeB");
            this.tblIntPostings_colsCodeB.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblIntPostings_colsCodeB_WindowActions);
            // 
            // tblIntPostings_colsCodeBDesc
            // 
            resources.ApplyResources(this.tblIntPostings_colsCodeBDesc, "tblIntPostings_colsCodeBDesc");
            this.tblIntPostings_colsCodeBDesc.Name = "tblIntPostings_colsCodeBDesc";
            this.tblIntPostings_colsCodeBDesc.NamedProperties.Put("EnumerateMethod", "");
            this.tblIntPostings_colsCodeBDesc.NamedProperties.Put("LovReference", "");
            this.tblIntPostings_colsCodeBDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.tblIntPostings_colsCodeBDesc.NamedProperties.Put("SqlColumn", "CODE_B_DESC");
            this.tblIntPostings_colsCodeBDesc.NamedProperties.Put("ValidateMethod", "");
            this.tblIntPostings_colsCodeBDesc.Position = 13;
            // 
            // tblIntPostings_colsCodeC
            // 
            this.tblIntPostings_colsCodeC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblIntPostings_colsCodeC.MaxLength = 20;
            this.tblIntPostings_colsCodeC.Name = "tblIntPostings_colsCodeC";
            this.tblIntPostings_colsCodeC.NamedProperties.Put("EnumerateMethod", "");
            this.tblIntPostings_colsCodeC.NamedProperties.Put("FieldFlags", "294");
            this.tblIntPostings_colsCodeC.NamedProperties.Put("LovReference", "CODE_C(COMPANY)");
            this.tblIntPostings_colsCodeC.NamedProperties.Put("ResizeableChildObject", "");
            this.tblIntPostings_colsCodeC.NamedProperties.Put("SqlColumn", "CODE_C");
            this.tblIntPostings_colsCodeC.NamedProperties.Put("ValidateMethod", "");
            this.tblIntPostings_colsCodeC.Position = 14;
            resources.ApplyResources(this.tblIntPostings_colsCodeC, "tblIntPostings_colsCodeC");
            this.tblIntPostings_colsCodeC.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblIntPostings_colsCodeC_WindowActions);
            // 
            // tblIntPostings_colsCodeCDesc
            // 
            resources.ApplyResources(this.tblIntPostings_colsCodeCDesc, "tblIntPostings_colsCodeCDesc");
            this.tblIntPostings_colsCodeCDesc.Name = "tblIntPostings_colsCodeCDesc";
            this.tblIntPostings_colsCodeCDesc.NamedProperties.Put("EnumerateMethod", "");
            this.tblIntPostings_colsCodeCDesc.NamedProperties.Put("LovReference", "");
            this.tblIntPostings_colsCodeCDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.tblIntPostings_colsCodeCDesc.NamedProperties.Put("SqlColumn", "CODE_C_DESC");
            this.tblIntPostings_colsCodeCDesc.NamedProperties.Put("ValidateMethod", "");
            this.tblIntPostings_colsCodeCDesc.Position = 15;
            // 
            // tblIntPostings_colsCodeD
            // 
            this.tblIntPostings_colsCodeD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblIntPostings_colsCodeD.MaxLength = 20;
            this.tblIntPostings_colsCodeD.Name = "tblIntPostings_colsCodeD";
            this.tblIntPostings_colsCodeD.NamedProperties.Put("EnumerateMethod", "");
            this.tblIntPostings_colsCodeD.NamedProperties.Put("FieldFlags", "294");
            this.tblIntPostings_colsCodeD.NamedProperties.Put("LovReference", "CODE_D(COMPANY)");
            this.tblIntPostings_colsCodeD.NamedProperties.Put("ResizeableChildObject", "");
            this.tblIntPostings_colsCodeD.NamedProperties.Put("SqlColumn", "CODE_D");
            this.tblIntPostings_colsCodeD.NamedProperties.Put("ValidateMethod", "");
            this.tblIntPostings_colsCodeD.Position = 16;
            resources.ApplyResources(this.tblIntPostings_colsCodeD, "tblIntPostings_colsCodeD");
            this.tblIntPostings_colsCodeD.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblIntPostings_colsCodeD_WindowActions);
            // 
            // tblIntPostings_colsCodeDDesc
            // 
            resources.ApplyResources(this.tblIntPostings_colsCodeDDesc, "tblIntPostings_colsCodeDDesc");
            this.tblIntPostings_colsCodeDDesc.Name = "tblIntPostings_colsCodeDDesc";
            this.tblIntPostings_colsCodeDDesc.NamedProperties.Put("EnumerateMethod", "");
            this.tblIntPostings_colsCodeDDesc.NamedProperties.Put("LovReference", "");
            this.tblIntPostings_colsCodeDDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.tblIntPostings_colsCodeDDesc.NamedProperties.Put("SqlColumn", "CODE_D_DESC");
            this.tblIntPostings_colsCodeDDesc.NamedProperties.Put("ValidateMethod", "");
            this.tblIntPostings_colsCodeDDesc.Position = 17;
            // 
            // tblIntPostings_colsCodeE
            // 
            this.tblIntPostings_colsCodeE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblIntPostings_colsCodeE.MaxLength = 20;
            this.tblIntPostings_colsCodeE.Name = "tblIntPostings_colsCodeE";
            this.tblIntPostings_colsCodeE.NamedProperties.Put("EnumerateMethod", "");
            this.tblIntPostings_colsCodeE.NamedProperties.Put("FieldFlags", "294");
            this.tblIntPostings_colsCodeE.NamedProperties.Put("LovReference", "CODE_E(COMPANY)");
            this.tblIntPostings_colsCodeE.NamedProperties.Put("ResizeableChildObject", "");
            this.tblIntPostings_colsCodeE.NamedProperties.Put("SqlColumn", "CODE_E");
            this.tblIntPostings_colsCodeE.NamedProperties.Put("ValidateMethod", "");
            this.tblIntPostings_colsCodeE.Position = 18;
            resources.ApplyResources(this.tblIntPostings_colsCodeE, "tblIntPostings_colsCodeE");
            this.tblIntPostings_colsCodeE.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblIntPostings_colsCodeE_WindowActions);
            // 
            // tblIntPostings_colsCodeEDesc
            // 
            resources.ApplyResources(this.tblIntPostings_colsCodeEDesc, "tblIntPostings_colsCodeEDesc");
            this.tblIntPostings_colsCodeEDesc.Name = "tblIntPostings_colsCodeEDesc";
            this.tblIntPostings_colsCodeEDesc.NamedProperties.Put("EnumerateMethod", "");
            this.tblIntPostings_colsCodeEDesc.NamedProperties.Put("LovReference", "");
            this.tblIntPostings_colsCodeEDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.tblIntPostings_colsCodeEDesc.NamedProperties.Put("SqlColumn", "CODE_E_DESC");
            this.tblIntPostings_colsCodeEDesc.NamedProperties.Put("ValidateMethod", "");
            this.tblIntPostings_colsCodeEDesc.Position = 19;
            // 
            // tblIntPostings_colsCodeF
            // 
            this.tblIntPostings_colsCodeF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblIntPostings_colsCodeF.MaxLength = 20;
            this.tblIntPostings_colsCodeF.Name = "tblIntPostings_colsCodeF";
            this.tblIntPostings_colsCodeF.NamedProperties.Put("EnumerateMethod", "");
            this.tblIntPostings_colsCodeF.NamedProperties.Put("FieldFlags", "294");
            this.tblIntPostings_colsCodeF.NamedProperties.Put("LovReference", "CODE_F(COMPANY)");
            this.tblIntPostings_colsCodeF.NamedProperties.Put("ResizeableChildObject", "");
            this.tblIntPostings_colsCodeF.NamedProperties.Put("SqlColumn", "CODE_F");
            this.tblIntPostings_colsCodeF.NamedProperties.Put("ValidateMethod", "");
            this.tblIntPostings_colsCodeF.Position = 20;
            resources.ApplyResources(this.tblIntPostings_colsCodeF, "tblIntPostings_colsCodeF");
            this.tblIntPostings_colsCodeF.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblIntPostings_colsCodeF_WindowActions);
            // 
            // tblIntPostings_colsCodeFDesc
            // 
            resources.ApplyResources(this.tblIntPostings_colsCodeFDesc, "tblIntPostings_colsCodeFDesc");
            this.tblIntPostings_colsCodeFDesc.Name = "tblIntPostings_colsCodeFDesc";
            this.tblIntPostings_colsCodeFDesc.NamedProperties.Put("EnumerateMethod", "");
            this.tblIntPostings_colsCodeFDesc.NamedProperties.Put("LovReference", "");
            this.tblIntPostings_colsCodeFDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.tblIntPostings_colsCodeFDesc.NamedProperties.Put("SqlColumn", "CODE_F_DESC");
            this.tblIntPostings_colsCodeFDesc.NamedProperties.Put("ValidateMethod", "");
            this.tblIntPostings_colsCodeFDesc.Position = 21;
            // 
            // tblIntPostings_colsCodeG
            // 
            this.tblIntPostings_colsCodeG.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblIntPostings_colsCodeG.MaxLength = 20;
            this.tblIntPostings_colsCodeG.Name = "tblIntPostings_colsCodeG";
            this.tblIntPostings_colsCodeG.NamedProperties.Put("EnumerateMethod", "");
            this.tblIntPostings_colsCodeG.NamedProperties.Put("FieldFlags", "294");
            this.tblIntPostings_colsCodeG.NamedProperties.Put("LovReference", "CODE_G(COMPANY)");
            this.tblIntPostings_colsCodeG.NamedProperties.Put("ResizeableChildObject", "");
            this.tblIntPostings_colsCodeG.NamedProperties.Put("SqlColumn", "CODE_G");
            this.tblIntPostings_colsCodeG.NamedProperties.Put("ValidateMethod", "");
            this.tblIntPostings_colsCodeG.Position = 22;
            resources.ApplyResources(this.tblIntPostings_colsCodeG, "tblIntPostings_colsCodeG");
            this.tblIntPostings_colsCodeG.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblIntPostings_colsCodeG_WindowActions);
            // 
            // tblIntPostings_colsCodeGDesc
            // 
            resources.ApplyResources(this.tblIntPostings_colsCodeGDesc, "tblIntPostings_colsCodeGDesc");
            this.tblIntPostings_colsCodeGDesc.Name = "tblIntPostings_colsCodeGDesc";
            this.tblIntPostings_colsCodeGDesc.NamedProperties.Put("EnumerateMethod", "");
            this.tblIntPostings_colsCodeGDesc.NamedProperties.Put("LovReference", "");
            this.tblIntPostings_colsCodeGDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.tblIntPostings_colsCodeGDesc.NamedProperties.Put("SqlColumn", "CODE_G_DESC");
            this.tblIntPostings_colsCodeGDesc.NamedProperties.Put("ValidateMethod", "");
            this.tblIntPostings_colsCodeGDesc.Position = 23;
            // 
            // tblIntPostings_colsCodeH
            // 
            this.tblIntPostings_colsCodeH.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblIntPostings_colsCodeH.MaxLength = 20;
            this.tblIntPostings_colsCodeH.Name = "tblIntPostings_colsCodeH";
            this.tblIntPostings_colsCodeH.NamedProperties.Put("EnumerateMethod", "");
            this.tblIntPostings_colsCodeH.NamedProperties.Put("FieldFlags", "294");
            this.tblIntPostings_colsCodeH.NamedProperties.Put("LovReference", "CODE_H(COMPANY)");
            this.tblIntPostings_colsCodeH.NamedProperties.Put("ResizeableChildObject", "");
            this.tblIntPostings_colsCodeH.NamedProperties.Put("SqlColumn", "CODE_H");
            this.tblIntPostings_colsCodeH.NamedProperties.Put("ValidateMethod", "");
            this.tblIntPostings_colsCodeH.Position = 24;
            resources.ApplyResources(this.tblIntPostings_colsCodeH, "tblIntPostings_colsCodeH");
            this.tblIntPostings_colsCodeH.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblIntPostings_colsCodeH_WindowActions);
            // 
            // tblIntPostings_colsCodeHDesc
            // 
            resources.ApplyResources(this.tblIntPostings_colsCodeHDesc, "tblIntPostings_colsCodeHDesc");
            this.tblIntPostings_colsCodeHDesc.Name = "tblIntPostings_colsCodeHDesc";
            this.tblIntPostings_colsCodeHDesc.NamedProperties.Put("EnumerateMethod", "");
            this.tblIntPostings_colsCodeHDesc.NamedProperties.Put("LovReference", "");
            this.tblIntPostings_colsCodeHDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.tblIntPostings_colsCodeHDesc.NamedProperties.Put("SqlColumn", "CODE_H_DESC");
            this.tblIntPostings_colsCodeHDesc.NamedProperties.Put("ValidateMethod", "");
            this.tblIntPostings_colsCodeHDesc.Position = 25;
            // 
            // tblIntPostings_colsCodeI
            // 
            this.tblIntPostings_colsCodeI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblIntPostings_colsCodeI.MaxLength = 20;
            this.tblIntPostings_colsCodeI.Name = "tblIntPostings_colsCodeI";
            this.tblIntPostings_colsCodeI.NamedProperties.Put("EnumerateMethod", "");
            this.tblIntPostings_colsCodeI.NamedProperties.Put("FieldFlags", "294");
            this.tblIntPostings_colsCodeI.NamedProperties.Put("LovReference", "CODE_I(COMPANY)");
            this.tblIntPostings_colsCodeI.NamedProperties.Put("ResizeableChildObject", "");
            this.tblIntPostings_colsCodeI.NamedProperties.Put("SqlColumn", "CODE_I");
            this.tblIntPostings_colsCodeI.NamedProperties.Put("ValidateMethod", "");
            this.tblIntPostings_colsCodeI.Position = 26;
            resources.ApplyResources(this.tblIntPostings_colsCodeI, "tblIntPostings_colsCodeI");
            this.tblIntPostings_colsCodeI.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblIntPostings_colsCodeI_WindowActions);
            // 
            // tblIntPostings_colsCodeIDesc
            // 
            resources.ApplyResources(this.tblIntPostings_colsCodeIDesc, "tblIntPostings_colsCodeIDesc");
            this.tblIntPostings_colsCodeIDesc.Name = "tblIntPostings_colsCodeIDesc";
            this.tblIntPostings_colsCodeIDesc.NamedProperties.Put("EnumerateMethod", "");
            this.tblIntPostings_colsCodeIDesc.NamedProperties.Put("LovReference", "");
            this.tblIntPostings_colsCodeIDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.tblIntPostings_colsCodeIDesc.NamedProperties.Put("SqlColumn", "CODE_I_DESC");
            this.tblIntPostings_colsCodeIDesc.NamedProperties.Put("ValidateMethod", "");
            this.tblIntPostings_colsCodeIDesc.Position = 27;
            // 
            // tblIntPostings_colsCodeJ
            // 
            this.tblIntPostings_colsCodeJ.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblIntPostings_colsCodeJ.MaxLength = 20;
            this.tblIntPostings_colsCodeJ.Name = "tblIntPostings_colsCodeJ";
            this.tblIntPostings_colsCodeJ.NamedProperties.Put("EnumerateMethod", "");
            this.tblIntPostings_colsCodeJ.NamedProperties.Put("FieldFlags", "294");
            this.tblIntPostings_colsCodeJ.NamedProperties.Put("LovReference", "CODE_J(COMPANY)");
            this.tblIntPostings_colsCodeJ.NamedProperties.Put("ResizeableChildObject", "");
            this.tblIntPostings_colsCodeJ.NamedProperties.Put("SqlColumn", "CODE_J");
            this.tblIntPostings_colsCodeJ.NamedProperties.Put("ValidateMethod", "");
            this.tblIntPostings_colsCodeJ.Position = 28;
            resources.ApplyResources(this.tblIntPostings_colsCodeJ, "tblIntPostings_colsCodeJ");
            this.tblIntPostings_colsCodeJ.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblIntPostings_colsCodeJ_WindowActions);
            // 
            // tblIntPostings_colsCodeJDesc
            // 
            resources.ApplyResources(this.tblIntPostings_colsCodeJDesc, "tblIntPostings_colsCodeJDesc");
            this.tblIntPostings_colsCodeJDesc.Name = "tblIntPostings_colsCodeJDesc";
            this.tblIntPostings_colsCodeJDesc.NamedProperties.Put("EnumerateMethod", "");
            this.tblIntPostings_colsCodeJDesc.NamedProperties.Put("LovReference", "");
            this.tblIntPostings_colsCodeJDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.tblIntPostings_colsCodeJDesc.NamedProperties.Put("SqlColumn", "CODE_J_DESC");
            this.tblIntPostings_colsCodeJDesc.NamedProperties.Put("ValidateMethod", "");
            this.tblIntPostings_colsCodeJDesc.Position = 29;
            // 
            // tblIntPostings_colnPercentage
            // 
            this.tblIntPostings_colnPercentage.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblIntPostings_colnPercentage.Format = "N";
            this.tblIntPostings_colnPercentage.Name = "tblIntPostings_colnPercentage";
            this.tblIntPostings_colnPercentage.NamedProperties.Put("EnumerateMethod", "");
            this.tblIntPostings_colnPercentage.NamedProperties.Put("FieldFlags", "294");
            this.tblIntPostings_colnPercentage.NamedProperties.Put("LovReference", "");
            this.tblIntPostings_colnPercentage.NamedProperties.Put("ResizeableChildObject", "");
            this.tblIntPostings_colnPercentage.NamedProperties.Put("SqlColumn", "PERCENTAGE");
            this.tblIntPostings_colnPercentage.NamedProperties.Put("ValidateMethod", "");
            this.tblIntPostings_colnPercentage.Position = 30;
            this.tblIntPostings_colnPercentage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblIntPostings_colnPercentage, "tblIntPostings_colnPercentage");
            this.tblIntPostings_colnPercentage.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblIntPostings_colnPercentage_WindowActions);
            // 
            // tblIntPostings_colnCurrencyDebitAmount
            // 
            this.tblIntPostings_colnCurrencyDebitAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblIntPostings_colnCurrencyDebitAmount.MaxLength = 15;
            this.tblIntPostings_colnCurrencyDebitAmount.Name = "tblIntPostings_colnCurrencyDebitAmount";
            this.tblIntPostings_colnCurrencyDebitAmount.NamedProperties.Put("EnumerateMethod", "");
            this.tblIntPostings_colnCurrencyDebitAmount.NamedProperties.Put("FieldFlags", "294");
            this.tblIntPostings_colnCurrencyDebitAmount.NamedProperties.Put("Format", "20");
            this.tblIntPostings_colnCurrencyDebitAmount.NamedProperties.Put("LovReference", "");
            this.tblIntPostings_colnCurrencyDebitAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.tblIntPostings_colnCurrencyDebitAmount.NamedProperties.Put("SqlColumn", "CURRENCY_DEBIT_AMOUNT");
            this.tblIntPostings_colnCurrencyDebitAmount.NamedProperties.Put("ValidateMethod", "");
            this.tblIntPostings_colnCurrencyDebitAmount.Position = 31;
            this.tblIntPostings_colnCurrencyDebitAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblIntPostings_colnCurrencyDebitAmount, "tblIntPostings_colnCurrencyDebitAmount");
            this.tblIntPostings_colnCurrencyDebitAmount.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblIntPostings_colnCurrencyDebitAmount_WindowActions);
            // 
            // tblIntPostings_colnCurrencyCreditAmount
            // 
            this.tblIntPostings_colnCurrencyCreditAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblIntPostings_colnCurrencyCreditAmount.MaxLength = 15;
            this.tblIntPostings_colnCurrencyCreditAmount.Name = "tblIntPostings_colnCurrencyCreditAmount";
            this.tblIntPostings_colnCurrencyCreditAmount.NamedProperties.Put("EnumerateMethod", "");
            this.tblIntPostings_colnCurrencyCreditAmount.NamedProperties.Put("FieldFlags", "294");
            this.tblIntPostings_colnCurrencyCreditAmount.NamedProperties.Put("Format", "20");
            this.tblIntPostings_colnCurrencyCreditAmount.NamedProperties.Put("LovReference", "");
            this.tblIntPostings_colnCurrencyCreditAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.tblIntPostings_colnCurrencyCreditAmount.NamedProperties.Put("SqlColumn", "CURRENCY_CREDIT_AMOUNT");
            this.tblIntPostings_colnCurrencyCreditAmount.NamedProperties.Put("ValidateMethod", "");
            this.tblIntPostings_colnCurrencyCreditAmount.Position = 32;
            this.tblIntPostings_colnCurrencyCreditAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblIntPostings_colnCurrencyCreditAmount, "tblIntPostings_colnCurrencyCreditAmount");
            this.tblIntPostings_colnCurrencyCreditAmount.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblIntPostings_colnCurrencyCreditAmount_WindowActions);
            // 
            // tblIntPostings_colnCurrencyAmount
            // 
            this.tblIntPostings_colnCurrencyAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblIntPostings_colnCurrencyAmount.MaxLength = 15;
            this.tblIntPostings_colnCurrencyAmount.Name = "tblIntPostings_colnCurrencyAmount";
            this.tblIntPostings_colnCurrencyAmount.NamedProperties.Put("EnumerateMethod", "");
            this.tblIntPostings_colnCurrencyAmount.NamedProperties.Put("FieldFlags", "294");
            this.tblIntPostings_colnCurrencyAmount.NamedProperties.Put("Format", "20");
            this.tblIntPostings_colnCurrencyAmount.NamedProperties.Put("LovReference", "");
            this.tblIntPostings_colnCurrencyAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.tblIntPostings_colnCurrencyAmount.NamedProperties.Put("SqlColumn", "CURRENCY_AMOUNT");
            this.tblIntPostings_colnCurrencyAmount.NamedProperties.Put("ValidateMethod", "");
            this.tblIntPostings_colnCurrencyAmount.Position = 33;
            this.tblIntPostings_colnCurrencyAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblIntPostings_colnCurrencyAmount, "tblIntPostings_colnCurrencyAmount");
            this.tblIntPostings_colnCurrencyAmount.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblIntPostings_colnCurrencyAmount_WindowActions);
            // 
            // tblIntPostings_colnDebitAmount
            // 
            this.tblIntPostings_colnDebitAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblIntPostings_colnDebitAmount.MaxLength = 15;
            this.tblIntPostings_colnDebitAmount.Name = "tblIntPostings_colnDebitAmount";
            this.tblIntPostings_colnDebitAmount.NamedProperties.Put("EnumerateMethod", "");
            this.tblIntPostings_colnDebitAmount.NamedProperties.Put("FieldFlags", "294");
            this.tblIntPostings_colnDebitAmount.NamedProperties.Put("Format", "20");
            this.tblIntPostings_colnDebitAmount.NamedProperties.Put("LovReference", "");
            this.tblIntPostings_colnDebitAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.tblIntPostings_colnDebitAmount.NamedProperties.Put("SqlColumn", "DEBIT_AMOUNT");
            this.tblIntPostings_colnDebitAmount.NamedProperties.Put("ValidateMethod", "");
            this.tblIntPostings_colnDebitAmount.Position = 34;
            this.tblIntPostings_colnDebitAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblIntPostings_colnDebitAmount, "tblIntPostings_colnDebitAmount");
            this.tblIntPostings_colnDebitAmount.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblIntPostings_colnDebitAmount_WindowActions);
            // 
            // tblIntPostings_colnCreditAmount
            // 
            this.tblIntPostings_colnCreditAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblIntPostings_colnCreditAmount.MaxLength = 15;
            this.tblIntPostings_colnCreditAmount.Name = "tblIntPostings_colnCreditAmount";
            this.tblIntPostings_colnCreditAmount.NamedProperties.Put("EnumerateMethod", "");
            this.tblIntPostings_colnCreditAmount.NamedProperties.Put("FieldFlags", "294");
            this.tblIntPostings_colnCreditAmount.NamedProperties.Put("Format", "20");
            this.tblIntPostings_colnCreditAmount.NamedProperties.Put("LovReference", "");
            this.tblIntPostings_colnCreditAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.tblIntPostings_colnCreditAmount.NamedProperties.Put("SqlColumn", "CREDIT_AMOUNT");
            this.tblIntPostings_colnCreditAmount.NamedProperties.Put("ValidateMethod", "");
            this.tblIntPostings_colnCreditAmount.Position = 35;
            this.tblIntPostings_colnCreditAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblIntPostings_colnCreditAmount, "tblIntPostings_colnCreditAmount");
            this.tblIntPostings_colnCreditAmount.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblIntPostings_colnCreditAmount_WindowActions);
            // 
            // tblIntPostings_colnAmount
            // 
            this.tblIntPostings_colnAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblIntPostings_colnAmount.MaxLength = 15;
            this.tblIntPostings_colnAmount.Name = "tblIntPostings_colnAmount";
            this.tblIntPostings_colnAmount.NamedProperties.Put("EnumerateMethod", "");
            this.tblIntPostings_colnAmount.NamedProperties.Put("FieldFlags", "294");
            this.tblIntPostings_colnAmount.NamedProperties.Put("Format", "20");
            this.tblIntPostings_colnAmount.NamedProperties.Put("LovReference", "");
            this.tblIntPostings_colnAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.tblIntPostings_colnAmount.NamedProperties.Put("SqlColumn", "AMOUNT");
            this.tblIntPostings_colnAmount.NamedProperties.Put("ValidateMethod", "");
            this.tblIntPostings_colnAmount.Position = 36;
            this.tblIntPostings_colnAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblIntPostings_colnAmount, "tblIntPostings_colnAmount");
            this.tblIntPostings_colnAmount.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblIntPostings_colnAmount_WindowActions);
            // 
            // tblIntPostings_colnCurrencyRate
            // 
            this.tblIntPostings_colnCurrencyRate.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.tblIntPostings_colnCurrencyRate, "tblIntPostings_colnCurrencyRate");
            this.tblIntPostings_colnCurrencyRate.Name = "tblIntPostings_colnCurrencyRate";
            this.tblIntPostings_colnCurrencyRate.NamedProperties.Put("EnumerateMethod", "");
            this.tblIntPostings_colnCurrencyRate.NamedProperties.Put("FieldFlags", "294");
            this.tblIntPostings_colnCurrencyRate.NamedProperties.Put("LovReference", "");
            this.tblIntPostings_colnCurrencyRate.NamedProperties.Put("ResizeableChildObject", "");
            this.tblIntPostings_colnCurrencyRate.NamedProperties.Put("SqlColumn", "CURRENCY_RATE");
            this.tblIntPostings_colnCurrencyRate.NamedProperties.Put("ValidateMethod", "");
            this.tblIntPostings_colnCurrencyRate.Position = 37;
            this.tblIntPostings_colnCurrencyRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tblIntPostings_colsText
            // 
            this.tblIntPostings_colsText.Name = "tblIntPostings_colsText";
            this.tblIntPostings_colsText.NamedProperties.Put("EnumerateMethod", "");
            this.tblIntPostings_colsText.NamedProperties.Put("FieldFlags", "294");
            this.tblIntPostings_colsText.NamedProperties.Put("LovReference", "");
            this.tblIntPostings_colsText.NamedProperties.Put("ResizeableChildObject", "");
            this.tblIntPostings_colsText.NamedProperties.Put("SqlColumn", "TEXT");
            this.tblIntPostings_colsText.NamedProperties.Put("ValidateMethod", "");
            this.tblIntPostings_colsText.Position = 38;
            resources.ApplyResources(this.tblIntPostings_colsText, "tblIntPostings_colsText");
            this.tblIntPostings_colsText.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblIntPostings_colsText_WindowActions);
            // 
            // dlgManualIntPosting
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "dlgManualIntPosting";
            this.ShowIcon = false;
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dlgManualIntPosting_WindowActions);
            this.ClientArea.ResumeLayout(false);
            this.ClientArea.PerformLayout();
            this.tblIntPostings.ResumeLayout(false);
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

        public cChildTableFin tblIntPostings;
        protected cColumn tblIntPostings_colsCompany;
        protected cColumn tblIntPostings_colsLedgerId;
        protected cColumn tblIntPostings_colnInternalSeqNumber;
        protected cColumnCodePartFin tblIntPostings_colsAccount;
        protected cColumnCodePartDescFin tblIntPostings_colsAccountDesc;
        protected cColumn tblIntPostings_colnRefRowNo;
        protected cColumn tblIntPostings_colsVoucherType;
        protected cColumn tblIntPostings_colnAccountingYear;
        protected cColumn tblIntPostings_colnVoucherNo;
        protected cColumnCodePartInt tblIntPostings_colsCodeB;
        protected cColumnCodePartDescFin tblIntPostings_colsCodeBDesc;
        protected cColumnCodePartInt tblIntPostings_colsCodeC;
        protected cColumnCodePartDescFin tblIntPostings_colsCodeCDesc;
        protected cColumnCodePartInt tblIntPostings_colsCodeD;
        protected cColumnCodePartDescFin tblIntPostings_colsCodeDDesc;
        protected cColumnCodePartInt tblIntPostings_colsCodeE;
        protected cColumnCodePartDescFin tblIntPostings_colsCodeEDesc;
        protected cColumnCodePartInt tblIntPostings_colsCodeF;
        protected cColumnCodePartDescFin tblIntPostings_colsCodeFDesc;
        protected cColumnCodePartInt tblIntPostings_colsCodeG;
        protected cColumnCodePartDescFin tblIntPostings_colsCodeGDesc;
        protected cColumnCodePartInt tblIntPostings_colsCodeH;
        protected cColumnCodePartDescFin tblIntPostings_colsCodeHDesc;
        protected cColumnCodePartInt tblIntPostings_colsCodeI;
        protected cColumnCodePartDescFin tblIntPostings_colsCodeIDesc;
        protected cColumnCodePartInt tblIntPostings_colsCodeJ;
        protected cColumnCodePartDescFin tblIntPostings_colsCodeJDesc;
        protected cColumn tblIntPostings_colnPercentage;
        protected cColumn tblIntPostings_colnCurrencyDebitAmount;
        protected cColumn tblIntPostings_colnCurrencyCreditAmount;
        protected cColumn tblIntPostings_colnCurrencyAmount;
        protected cColumn tblIntPostings_colnDebitAmount;
        protected cColumn tblIntPostings_colnCreditAmount;
        protected cColumn tblIntPostings_colnAmount;
        protected cColumn tblIntPostings_colnCurrencyRate;
        protected cColumn tblIntPostings_colsText;
	}
}
