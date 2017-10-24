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
	
	public partial class tbwVoucherRow
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
		protected cBackgroundText labeldfDebet;
		public cDataField dfDebet;
		protected cBackgroundText labeldfCredit;
		public cDataField dfCredit;
		protected cBackgroundText labeldfBalance;
		public cDataField dfBalance;
		protected cBackgroundText labeldfVoucherNumber;
		public cDataField dfVoucherNumber;
		protected cBackgroundText labeldfVoucherYear;
		public cDataField dfVoucherYear;
		protected cBackgroundText labeldfVoucherType;
		public cDataField dfVoucherType;
		public cColumn colCompany;
		public cColumn colVoucherNo;
		public cColumn colVoucherType;
		public cColumn colnAccountingYear;
		public cColumn colCorrection;
		public cColumnCodePartFin colnAccount;
		public cColumnCodePartDescFin colsAccountDesc;
		public cColumnCodePartFin colCodeB;
		public cColumnCodePartDescFin colsCodeBDesc;
		public cColumnCodePartFin colCodeC;
		public cColumnCodePartDescFin colsCodeCDesc;
		public cColumnCodePartFin colCodeD;
		public cColumnCodePartDescFin colsCodeDDesc;
		public cColumnCodePartFin colCodeE;
		public cColumnCodePartDescFin colsCodeEDesc;
		public cColumnCodePartFin colCodeF;
		public cColumnCodePartDescFin colsCodeFDesc;
		public cColumnCodePartFin colCodeG;
		public cColumnCodePartDescFin colsCodeGDesc;
		public cColumnCodePartFin colCodeH;
		public cColumnCodePartDescFin colsCodeHDesc;
		public cColumnCodePartFin colCodeI;
		public cColumnCodePartDescFin colsCodeIDesc;
		public cColumnCodePartFin colCodeJ;
		public cColumnCodePartDescFin colsCodeJDesc;
		public cColumn colDebetAmount;
		public cColumn colCreditAmount;
		public cColumn colAmount;
		public cColumn colCurrencyCode;
		public cColumn colCurrencyDebetAmount;
		public cColumn colCurrencyCreditAmount;
		public cColumn colCurrencyAmount;
		public cColumn colCurrencyRate;
		public cColumn colText;
		public cColumn colQuantity;
		public cColumn colProcessCode;
		public cColumn colOptionalCode;
		public cColumn colPartyTypeId;
		public cColumn colTransCode;
		public cColumn colTransferId;
		public cColumn colCorrected;
		public cColumn colReferenceSerie;
		public cColumn colReferenceNumber;
        public cColumnFinEuro colnThirdCurrencyDebitAmount;
        public cColumnFinEuro colnThirdCurrencyCreditAmount;
        public cColumnFinEuro colnThirdCurrencyAmount;
        public cColumn colnParallelCurrencyRate;
        public cColumn colnParallelConversionFactor;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwVoucherRow));
            this.ToolBar = new PPJ.Runtime.Windows.SalFormToolBar();
            this.dfVoucherType = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfVoucherYear = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfVoucherNumber = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfBalance = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfCredit = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfDebet = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfVoucherType = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.labeldfVoucherYear = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.labeldfVoucherNumber = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.labeldfBalance = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.labeldfCredit = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.labeldfDebet = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.StatusBar = new PPJ.Runtime.Windows.SalFormStatusBar();
            this.colCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colVoucherNo = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colVoucherType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colnAccountingYear = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colCorrection = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colnAccount = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.colsAccountDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.colCodeB = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.colsCodeBDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.colCodeC = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.colsCodeCDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.colCodeD = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.colsCodeDDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.colCodeE = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.colsCodeEDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.colCodeF = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.colsCodeFDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.colCodeG = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.colsCodeGDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.colCodeH = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.colsCodeHDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.colCodeI = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.colsCodeIDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.colCodeJ = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.colsCodeJDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.colDebetAmount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colCreditAmount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colAmount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colCurrencyCode = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colCurrencyDebetAmount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colCurrencyCreditAmount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colCurrencyAmount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colCurrencyRate = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colText = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colQuantity = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colProcessCode = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colOptionalCode = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colPartyTypeId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colTransCode = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colTransferId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colCorrected = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colReferenceSerie = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colReferenceNumber = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colnConversionFactor = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colnThirdCurrencyDebitAmount = new Ifs.Application.Accrul.cColumnFinEuro();
            this.colnThirdCurrencyCreditAmount = new Ifs.Application.Accrul.cColumnFinEuro();
            this.colnThirdCurrencyAmount = new Ifs.Application.Accrul.cColumnFinEuro();
            this.colnParallelCurrencyRate = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colnParallelConversionFactor = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsDeliveryTypeId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsDeliveryTypeDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.ToolBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolBar
            // 
            this.ToolBar.Controls.Add(this.dfVoucherType);
            this.ToolBar.Controls.Add(this.dfVoucherYear);
            this.ToolBar.Controls.Add(this.dfVoucherNumber);
            this.ToolBar.Controls.Add(this.dfBalance);
            this.ToolBar.Controls.Add(this.dfCredit);
            this.ToolBar.Controls.Add(this.dfDebet);
            this.ToolBar.Controls.Add(this.labeldfVoucherType);
            this.ToolBar.Controls.Add(this.labeldfVoucherYear);
            this.ToolBar.Controls.Add(this.labeldfVoucherNumber);
            this.ToolBar.Controls.Add(this.labeldfBalance);
            this.ToolBar.Controls.Add(this.labeldfCredit);
            this.ToolBar.Controls.Add(this.labeldfDebet);
            this.ToolBar.Name = "ToolBar";
            resources.ApplyResources(this.ToolBar, "ToolBar");
            this.ToolBar.TabStop = true;
            // 
            // dfVoucherType
            // 
            resources.ApplyResources(this.dfVoucherType, "dfVoucherType");
            this.dfVoucherType.Name = "dfVoucherType";
            this.dfVoucherType.TabStop = false;
            // 
            // dfVoucherYear
            // 
            this.dfVoucherYear.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfVoucherYear, "dfVoucherYear");
            this.dfVoucherYear.Name = "dfVoucherYear";
            this.dfVoucherYear.TabStop = false;
            // 
            // dfVoucherNumber
            // 
            this.dfVoucherNumber.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfVoucherNumber, "dfVoucherNumber");
            this.dfVoucherNumber.Name = "dfVoucherNumber";
            this.dfVoucherNumber.TabStop = false;
            // 
            // dfBalance
            // 
            this.dfBalance.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfBalance, "dfBalance");
            this.dfBalance.Name = "dfBalance";
            this.dfBalance.NamedProperties.Put("EnumerateMethod", "");
            this.dfBalance.NamedProperties.Put("Format", "20");
            this.dfBalance.NamedProperties.Put("LovReference", "");
            this.dfBalance.NamedProperties.Put("ResizeableChildObject", "");
            this.dfBalance.NamedProperties.Put("SqlColumn", "");
            this.dfBalance.NamedProperties.Put("ValidateMethod", "");
            this.dfBalance.TabStop = false;
            // 
            // dfCredit
            // 
            this.dfCredit.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfCredit, "dfCredit");
            this.dfCredit.Name = "dfCredit";
            this.dfCredit.NamedProperties.Put("EnumerateMethod", "");
            this.dfCredit.NamedProperties.Put("Format", "20");
            this.dfCredit.NamedProperties.Put("LovReference", "");
            this.dfCredit.NamedProperties.Put("ResizeableChildObject", "");
            this.dfCredit.NamedProperties.Put("SqlColumn", "");
            this.dfCredit.NamedProperties.Put("ValidateMethod", "");
            this.dfCredit.TabStop = false;
            // 
            // dfDebet
            // 
            this.dfDebet.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfDebet, "dfDebet");
            this.dfDebet.Name = "dfDebet";
            this.dfDebet.NamedProperties.Put("EnumerateMethod", "");
            this.dfDebet.NamedProperties.Put("Format", "20");
            this.dfDebet.NamedProperties.Put("LovReference", "");
            this.dfDebet.NamedProperties.Put("ResizeableChildObject", "");
            this.dfDebet.NamedProperties.Put("SqlColumn", "");
            this.dfDebet.NamedProperties.Put("ValidateMethod", "");
            this.dfDebet.TabStop = false;
            // 
            // labeldfVoucherType
            // 
            resources.ApplyResources(this.labeldfVoucherType, "labeldfVoucherType");
            this.labeldfVoucherType.Name = "labeldfVoucherType";
            // 
            // labeldfVoucherYear
            // 
            resources.ApplyResources(this.labeldfVoucherYear, "labeldfVoucherYear");
            this.labeldfVoucherYear.Name = "labeldfVoucherYear";
            // 
            // labeldfVoucherNumber
            // 
            resources.ApplyResources(this.labeldfVoucherNumber, "labeldfVoucherNumber");
            this.labeldfVoucherNumber.Name = "labeldfVoucherNumber";
            // 
            // labeldfBalance
            // 
            resources.ApplyResources(this.labeldfBalance, "labeldfBalance");
            this.labeldfBalance.Name = "labeldfBalance";
            // 
            // labeldfCredit
            // 
            resources.ApplyResources(this.labeldfCredit, "labeldfCredit");
            this.labeldfCredit.Name = "labeldfCredit";
            // 
            // labeldfDebet
            // 
            resources.ApplyResources(this.labeldfDebet, "labeldfDebet");
            this.labeldfDebet.Name = "labeldfDebet";
            // 
            // StatusBar
            // 
            resources.ApplyResources(this.StatusBar, "StatusBar");
            this.StatusBar.Name = "StatusBar";
            // 
            // colCompany
            // 
            resources.ApplyResources(this.colCompany, "colCompany");
            this.colCompany.MaxLength = 2;
            this.colCompany.Name = "colCompany";
            this.colCompany.NamedProperties.Put("EnumerateMethod", "");
            this.colCompany.NamedProperties.Put("FieldFlags", "128");
            this.colCompany.NamedProperties.Put("LovReference", "");
            this.colCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.colCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.colCompany.NamedProperties.Put("ValidateMethod", "");
            this.colCompany.Position = 3;
            // 
            // colVoucherNo
            // 
            this.colVoucherNo.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.colVoucherNo, "colVoucherNo");
            this.colVoucherNo.MaxLength = 10;
            this.colVoucherNo.Name = "colVoucherNo";
            this.colVoucherNo.NamedProperties.Put("EnumerateMethod", "");
            this.colVoucherNo.NamedProperties.Put("FieldFlags", "128");
            this.colVoucherNo.NamedProperties.Put("LovReference", "");
            this.colVoucherNo.NamedProperties.Put("ResizeableChildObject", "");
            this.colVoucherNo.NamedProperties.Put("SqlColumn", "VOUCHER_NO");
            this.colVoucherNo.NamedProperties.Put("ValidateMethod", "");
            this.colVoucherNo.Position = 4;
            // 
            // colVoucherType
            // 
            resources.ApplyResources(this.colVoucherType, "colVoucherType");
            this.colVoucherType.MaxLength = 3;
            this.colVoucherType.Name = "colVoucherType";
            this.colVoucherType.NamedProperties.Put("EnumerateMethod", "");
            this.colVoucherType.NamedProperties.Put("FieldFlags", "128");
            this.colVoucherType.NamedProperties.Put("LovReference", "");
            this.colVoucherType.NamedProperties.Put("ResizeableChildObject", "");
            this.colVoucherType.NamedProperties.Put("SqlColumn", "VOUCHER_TYPE");
            this.colVoucherType.NamedProperties.Put("ValidateMethod", "");
            this.colVoucherType.Position = 5;
            // 
            // colnAccountingYear
            // 
            this.colnAccountingYear.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.colnAccountingYear, "colnAccountingYear");
            this.colnAccountingYear.MaxLength = 4;
            this.colnAccountingYear.Name = "colnAccountingYear";
            this.colnAccountingYear.NamedProperties.Put("EnumerateMethod", "");
            this.colnAccountingYear.NamedProperties.Put("FieldFlags", "128");
            this.colnAccountingYear.NamedProperties.Put("LovReference", "");
            this.colnAccountingYear.NamedProperties.Put("ResizeableChildObject", "");
            this.colnAccountingYear.NamedProperties.Put("SqlColumn", "ACCOUNTING_YEAR");
            this.colnAccountingYear.NamedProperties.Put("ValidateMethod", "");
            this.colnAccountingYear.Position = 6;
            // 
            // colCorrection
            // 
            this.colCorrection.CellType = PPJ.Runtime.Windows.CellType.CheckBox;
            this.colCorrection.CheckBox.CheckedValue = "Y";
            this.colCorrection.CheckBox.IgnoreCase = true;
            this.colCorrection.CheckBox.UncheckedValue = "N";
            resources.ApplyResources(this.colCorrection, "colCorrection");
            this.colCorrection.Name = "colCorrection";
            this.colCorrection.NamedProperties.Put("EnumerateMethod", "");
            this.colCorrection.NamedProperties.Put("LovReference", "");
            this.colCorrection.NamedProperties.Put("ResizeableChildObject", "");
            this.colCorrection.NamedProperties.Put("SqlColumn", "CORRECTION");
            this.colCorrection.NamedProperties.Put("ValidateMethod", "");
            this.colCorrection.Position = 7;
            // 
            // colnAccount
            // 
            this.colnAccount.MaxLength = 20;
            this.colnAccount.Name = "colnAccount";
            this.colnAccount.NamedProperties.Put("EnumerateMethod", "");
            this.colnAccount.NamedProperties.Put("FieldFlags", "295");
            this.colnAccount.NamedProperties.Put("LovReference", "");
            this.colnAccount.NamedProperties.Put("ResizeableChildObject", "");
            this.colnAccount.NamedProperties.Put("SqlColumn", "ACCOUNT");
            this.colnAccount.NamedProperties.Put("ValidateMethod", "");
            this.colnAccount.Position = 8;
            resources.ApplyResources(this.colnAccount, "colnAccount");
            // 
            // colsAccountDesc
            // 
            this.colsAccountDesc.Name = "colsAccountDesc";
            this.colsAccountDesc.NamedProperties.Put("EnumerateMethod", "");
            this.colsAccountDesc.NamedProperties.Put("FieldFlags", "2304");
            this.colsAccountDesc.NamedProperties.Put("LovReference", "");
            this.colsAccountDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.colsAccountDesc.NamedProperties.Put("SqlColumn", "ACCOUNT_DESC");
            this.colsAccountDesc.NamedProperties.Put("ValidateMethod", "");
            this.colsAccountDesc.Position = 9;
            resources.ApplyResources(this.colsAccountDesc, "colsAccountDesc");
            // 
            // colCodeB
            // 
            this.colCodeB.MaxLength = 20;
            this.colCodeB.Name = "colCodeB";
            this.colCodeB.NamedProperties.Put("EnumerateMethod", "");
            this.colCodeB.NamedProperties.Put("FieldFlags", "294");
            this.colCodeB.NamedProperties.Put("LovReference", "");
            this.colCodeB.NamedProperties.Put("ResizeableChildObject", "");
            this.colCodeB.NamedProperties.Put("SqlColumn", "CODE_B");
            this.colCodeB.NamedProperties.Put("ValidateMethod", "");
            this.colCodeB.Position = 10;
            resources.ApplyResources(this.colCodeB, "colCodeB");
            // 
            // colsCodeBDesc
            // 
            this.colsCodeBDesc.Name = "colsCodeBDesc";
            this.colsCodeBDesc.NamedProperties.Put("EnumerateMethod", "");
            this.colsCodeBDesc.NamedProperties.Put("FieldFlags", "2304");
            this.colsCodeBDesc.NamedProperties.Put("LovReference", "");
            this.colsCodeBDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.colsCodeBDesc.NamedProperties.Put("SqlColumn", "CODE_B_DESC");
            this.colsCodeBDesc.NamedProperties.Put("ValidateMethod", "");
            this.colsCodeBDesc.Position = 11;
            resources.ApplyResources(this.colsCodeBDesc, "colsCodeBDesc");
            // 
            // colCodeC
            // 
            this.colCodeC.MaxLength = 20;
            this.colCodeC.Name = "colCodeC";
            this.colCodeC.NamedProperties.Put("EnumerateMethod", "");
            this.colCodeC.NamedProperties.Put("FieldFlags", "294");
            this.colCodeC.NamedProperties.Put("LovReference", "");
            this.colCodeC.NamedProperties.Put("ResizeableChildObject", "");
            this.colCodeC.NamedProperties.Put("SqlColumn", "CODE_C");
            this.colCodeC.NamedProperties.Put("ValidateMethod", "");
            this.colCodeC.Position = 12;
            resources.ApplyResources(this.colCodeC, "colCodeC");
            // 
            // colsCodeCDesc
            // 
            this.colsCodeCDesc.Name = "colsCodeCDesc";
            this.colsCodeCDesc.NamedProperties.Put("EnumerateMethod", "");
            this.colsCodeCDesc.NamedProperties.Put("FieldFlags", "2304");
            this.colsCodeCDesc.NamedProperties.Put("LovReference", "");
            this.colsCodeCDesc.NamedProperties.Put("SqlColumn", "CODE_C_DESC");
            this.colsCodeCDesc.NamedProperties.Put("ValidateMethod", "");
            this.colsCodeCDesc.Position = 13;
            resources.ApplyResources(this.colsCodeCDesc, "colsCodeCDesc");
            // 
            // colCodeD
            // 
            this.colCodeD.MaxLength = 20;
            this.colCodeD.Name = "colCodeD";
            this.colCodeD.NamedProperties.Put("EnumerateMethod", "");
            this.colCodeD.NamedProperties.Put("FieldFlags", "294");
            this.colCodeD.NamedProperties.Put("LovReference", "");
            this.colCodeD.NamedProperties.Put("ResizeableChildObject", "");
            this.colCodeD.NamedProperties.Put("SqlColumn", "CODE_D");
            this.colCodeD.NamedProperties.Put("ValidateMethod", "");
            this.colCodeD.Position = 14;
            resources.ApplyResources(this.colCodeD, "colCodeD");
            // 
            // colsCodeDDesc
            // 
            this.colsCodeDDesc.Name = "colsCodeDDesc";
            this.colsCodeDDesc.NamedProperties.Put("EnumerateMethod", "");
            this.colsCodeDDesc.NamedProperties.Put("FieldFlags", "2304");
            this.colsCodeDDesc.NamedProperties.Put("LovReference", "");
            this.colsCodeDDesc.NamedProperties.Put("SqlColumn", "CODE_D_DESC");
            this.colsCodeDDesc.NamedProperties.Put("ValidateMethod", "");
            this.colsCodeDDesc.Position = 15;
            resources.ApplyResources(this.colsCodeDDesc, "colsCodeDDesc");
            // 
            // colCodeE
            // 
            this.colCodeE.MaxLength = 20;
            this.colCodeE.Name = "colCodeE";
            this.colCodeE.NamedProperties.Put("EnumerateMethod", "");
            this.colCodeE.NamedProperties.Put("FieldFlags", "294");
            this.colCodeE.NamedProperties.Put("LovReference", "");
            this.colCodeE.NamedProperties.Put("ResizeableChildObject", "");
            this.colCodeE.NamedProperties.Put("SqlColumn", "CODE_E");
            this.colCodeE.NamedProperties.Put("ValidateMethod", "");
            this.colCodeE.Position = 16;
            resources.ApplyResources(this.colCodeE, "colCodeE");
            // 
            // colsCodeEDesc
            // 
            this.colsCodeEDesc.Name = "colsCodeEDesc";
            this.colsCodeEDesc.NamedProperties.Put("EnumerateMethod", "");
            this.colsCodeEDesc.NamedProperties.Put("FieldFlags", "2304");
            this.colsCodeEDesc.NamedProperties.Put("LovReference", "");
            this.colsCodeEDesc.NamedProperties.Put("SqlColumn", "CODE_E_DESC");
            this.colsCodeEDesc.NamedProperties.Put("ValidateMethod", "");
            this.colsCodeEDesc.Position = 17;
            resources.ApplyResources(this.colsCodeEDesc, "colsCodeEDesc");
            // 
            // colCodeF
            // 
            this.colCodeF.MaxLength = 20;
            this.colCodeF.Name = "colCodeF";
            this.colCodeF.NamedProperties.Put("EnumerateMethod", "");
            this.colCodeF.NamedProperties.Put("FieldFlags", "294");
            this.colCodeF.NamedProperties.Put("LovReference", "");
            this.colCodeF.NamedProperties.Put("ResizeableChildObject", "");
            this.colCodeF.NamedProperties.Put("SqlColumn", "CODE_F");
            this.colCodeF.NamedProperties.Put("ValidateMethod", "");
            this.colCodeF.Position = 18;
            resources.ApplyResources(this.colCodeF, "colCodeF");
            // 
            // colsCodeFDesc
            // 
            this.colsCodeFDesc.Name = "colsCodeFDesc";
            this.colsCodeFDesc.NamedProperties.Put("EnumerateMethod", "");
            this.colsCodeFDesc.NamedProperties.Put("FieldFlags", "2304");
            this.colsCodeFDesc.NamedProperties.Put("LovReference", "");
            this.colsCodeFDesc.NamedProperties.Put("SqlColumn", "CODE_F_DESC");
            this.colsCodeFDesc.NamedProperties.Put("ValidateMethod", "");
            this.colsCodeFDesc.Position = 19;
            resources.ApplyResources(this.colsCodeFDesc, "colsCodeFDesc");
            // 
            // colCodeG
            // 
            this.colCodeG.MaxLength = 20;
            this.colCodeG.Name = "colCodeG";
            this.colCodeG.NamedProperties.Put("EnumerateMethod", "");
            this.colCodeG.NamedProperties.Put("FieldFlags", "294");
            this.colCodeG.NamedProperties.Put("LovReference", "");
            this.colCodeG.NamedProperties.Put("ResizeableChildObject", "");
            this.colCodeG.NamedProperties.Put("SqlColumn", "CODE_G");
            this.colCodeG.NamedProperties.Put("ValidateMethod", "");
            this.colCodeG.Position = 20;
            resources.ApplyResources(this.colCodeG, "colCodeG");
            // 
            // colsCodeGDesc
            // 
            this.colsCodeGDesc.Name = "colsCodeGDesc";
            this.colsCodeGDesc.NamedProperties.Put("EnumerateMethod", "");
            this.colsCodeGDesc.NamedProperties.Put("FieldFlags", "2304");
            this.colsCodeGDesc.NamedProperties.Put("LovReference", "");
            this.colsCodeGDesc.NamedProperties.Put("SqlColumn", "CODE_G_DESC");
            this.colsCodeGDesc.NamedProperties.Put("ValidateMethod", "");
            this.colsCodeGDesc.Position = 21;
            resources.ApplyResources(this.colsCodeGDesc, "colsCodeGDesc");
            // 
            // colCodeH
            // 
            this.colCodeH.MaxLength = 20;
            this.colCodeH.Name = "colCodeH";
            this.colCodeH.NamedProperties.Put("EnumerateMethod", "");
            this.colCodeH.NamedProperties.Put("FieldFlags", "294");
            this.colCodeH.NamedProperties.Put("LovReference", "");
            this.colCodeH.NamedProperties.Put("ResizeableChildObject", "");
            this.colCodeH.NamedProperties.Put("SqlColumn", "CODE_H");
            this.colCodeH.NamedProperties.Put("ValidateMethod", "");
            this.colCodeH.Position = 22;
            resources.ApplyResources(this.colCodeH, "colCodeH");
            // 
            // colsCodeHDesc
            // 
            this.colsCodeHDesc.Name = "colsCodeHDesc";
            this.colsCodeHDesc.NamedProperties.Put("EnumerateMethod", "");
            this.colsCodeHDesc.NamedProperties.Put("FieldFlags", "2304");
            this.colsCodeHDesc.NamedProperties.Put("LovReference", "");
            this.colsCodeHDesc.NamedProperties.Put("SqlColumn", "CODE_H_DESC");
            this.colsCodeHDesc.NamedProperties.Put("ValidateMethod", "");
            this.colsCodeHDesc.Position = 23;
            resources.ApplyResources(this.colsCodeHDesc, "colsCodeHDesc");
            // 
            // colCodeI
            // 
            this.colCodeI.MaxLength = 20;
            this.colCodeI.Name = "colCodeI";
            this.colCodeI.NamedProperties.Put("EnumerateMethod", "");
            this.colCodeI.NamedProperties.Put("FieldFlags", "294");
            this.colCodeI.NamedProperties.Put("LovReference", "");
            this.colCodeI.NamedProperties.Put("ResizeableChildObject", "");
            this.colCodeI.NamedProperties.Put("SqlColumn", "CODE_I");
            this.colCodeI.NamedProperties.Put("ValidateMethod", "");
            this.colCodeI.Position = 24;
            resources.ApplyResources(this.colCodeI, "colCodeI");
            // 
            // colsCodeIDesc
            // 
            this.colsCodeIDesc.Name = "colsCodeIDesc";
            this.colsCodeIDesc.NamedProperties.Put("EnumerateMethod", "");
            this.colsCodeIDesc.NamedProperties.Put("FieldFlags", "2304");
            this.colsCodeIDesc.NamedProperties.Put("LovReference", "");
            this.colsCodeIDesc.NamedProperties.Put("SqlColumn", "CODE_I_DESC");
            this.colsCodeIDesc.NamedProperties.Put("ValidateMethod", "");
            this.colsCodeIDesc.Position = 25;
            resources.ApplyResources(this.colsCodeIDesc, "colsCodeIDesc");
            // 
            // colCodeJ
            // 
            this.colCodeJ.MaxLength = 20;
            this.colCodeJ.Name = "colCodeJ";
            this.colCodeJ.NamedProperties.Put("EnumerateMethod", "");
            this.colCodeJ.NamedProperties.Put("FieldFlags", "294");
            this.colCodeJ.NamedProperties.Put("LovReference", "");
            this.colCodeJ.NamedProperties.Put("ResizeableChildObject", "");
            this.colCodeJ.NamedProperties.Put("SqlColumn", "CODE_J");
            this.colCodeJ.NamedProperties.Put("ValidateMethod", "");
            this.colCodeJ.Position = 26;
            resources.ApplyResources(this.colCodeJ, "colCodeJ");
            // 
            // colsCodeJDesc
            // 
            this.colsCodeJDesc.Name = "colsCodeJDesc";
            this.colsCodeJDesc.NamedProperties.Put("EnumerateMethod", "");
            this.colsCodeJDesc.NamedProperties.Put("FieldFlags", "2304");
            this.colsCodeJDesc.NamedProperties.Put("LovReference", "");
            this.colsCodeJDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.colsCodeJDesc.NamedProperties.Put("SqlColumn", "CODE_J_DESC");
            this.colsCodeJDesc.NamedProperties.Put("ValidateMethod", "");
            this.colsCodeJDesc.Position = 27;
            resources.ApplyResources(this.colsCodeJDesc, "colsCodeJDesc");
            // 
            // colDebetAmount
            // 
            this.colDebetAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colDebetAmount.MaxLength = 15;
            this.colDebetAmount.Name = "colDebetAmount";
            this.colDebetAmount.NamedProperties.Put("EnumerateMethod", "");
            this.colDebetAmount.NamedProperties.Put("Format", "20");
            this.colDebetAmount.NamedProperties.Put("LovReference", "");
            this.colDebetAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.colDebetAmount.NamedProperties.Put("SqlColumn", "DEBET_AMOUNT");
            this.colDebetAmount.NamedProperties.Put("ValidateMethod", "");
            this.colDebetAmount.Position = 28;
            this.colDebetAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.colDebetAmount, "colDebetAmount");
            // 
            // colCreditAmount
            // 
            this.colCreditAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colCreditAmount.MaxLength = 15;
            this.colCreditAmount.Name = "colCreditAmount";
            this.colCreditAmount.NamedProperties.Put("EnumerateMethod", "");
            this.colCreditAmount.NamedProperties.Put("Format", "20");
            this.colCreditAmount.NamedProperties.Put("LovReference", "");
            this.colCreditAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.colCreditAmount.NamedProperties.Put("SqlColumn", "CREDIT_AMOUNT");
            this.colCreditAmount.NamedProperties.Put("ValidateMethod", "");
            this.colCreditAmount.Position = 29;
            this.colCreditAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.colCreditAmount, "colCreditAmount");
            // 
            // colAmount
            // 
            this.colAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colAmount.MaxLength = 15;
            this.colAmount.Name = "colAmount";
            this.colAmount.NamedProperties.Put("EnumerateMethod", "");
            this.colAmount.NamedProperties.Put("Format", "20");
            this.colAmount.NamedProperties.Put("LovReference", "");
            this.colAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.colAmount.NamedProperties.Put("SqlColumn", "AMOUNT");
            this.colAmount.NamedProperties.Put("ValidateMethod", "");
            this.colAmount.Position = 30;
            this.colAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.colAmount, "colAmount");
            // 
            // colCurrencyCode
            // 
            this.colCurrencyCode.MaxLength = 3;
            this.colCurrencyCode.Name = "colCurrencyCode";
            this.colCurrencyCode.NamedProperties.Put("EnumerateMethod", "");
            this.colCurrencyCode.NamedProperties.Put("LovReference", "");
            this.colCurrencyCode.NamedProperties.Put("ResizeableChildObject", "");
            this.colCurrencyCode.NamedProperties.Put("SqlColumn", "CURRENCY_CODE");
            this.colCurrencyCode.NamedProperties.Put("ValidateMethod", "");
            this.colCurrencyCode.Position = 31;
            resources.ApplyResources(this.colCurrencyCode, "colCurrencyCode");
            // 
            // colCurrencyDebetAmount
            // 
            this.colCurrencyDebetAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colCurrencyDebetAmount.MaxLength = 15;
            this.colCurrencyDebetAmount.Name = "colCurrencyDebetAmount";
            this.colCurrencyDebetAmount.NamedProperties.Put("EnumerateMethod", "");
            this.colCurrencyDebetAmount.NamedProperties.Put("Format", "20");
            this.colCurrencyDebetAmount.NamedProperties.Put("LovReference", "");
            this.colCurrencyDebetAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.colCurrencyDebetAmount.NamedProperties.Put("SqlColumn", "CURRENCY_DEBET_AMOUNT");
            this.colCurrencyDebetAmount.NamedProperties.Put("ValidateMethod", "");
            this.colCurrencyDebetAmount.Position = 34;
            this.colCurrencyDebetAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.colCurrencyDebetAmount, "colCurrencyDebetAmount");
            // 
            // colCurrencyCreditAmount
            // 
            this.colCurrencyCreditAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colCurrencyCreditAmount.MaxLength = 15;
            this.colCurrencyCreditAmount.Name = "colCurrencyCreditAmount";
            this.colCurrencyCreditAmount.NamedProperties.Put("EnumerateMethod", "");
            this.colCurrencyCreditAmount.NamedProperties.Put("Format", "20");
            this.colCurrencyCreditAmount.NamedProperties.Put("LovReference", "");
            this.colCurrencyCreditAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.colCurrencyCreditAmount.NamedProperties.Put("SqlColumn", "CURRENCY_CREDIT_AMOUNT");
            this.colCurrencyCreditAmount.NamedProperties.Put("ValidateMethod", "");
            this.colCurrencyCreditAmount.Position = 35;
            this.colCurrencyCreditAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.colCurrencyCreditAmount, "colCurrencyCreditAmount");
            // 
            // colCurrencyAmount
            // 
            this.colCurrencyAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colCurrencyAmount.Name = "colCurrencyAmount";
            this.colCurrencyAmount.NamedProperties.Put("EnumerateMethod", "");
            this.colCurrencyAmount.NamedProperties.Put("Format", "20");
            this.colCurrencyAmount.NamedProperties.Put("LovReference", "");
            this.colCurrencyAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.colCurrencyAmount.NamedProperties.Put("SqlColumn", "CURRENCY_AMOUNT");
            this.colCurrencyAmount.NamedProperties.Put("ValidateMethod", "");
            this.colCurrencyAmount.Position = 36;
            this.colCurrencyAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.colCurrencyAmount, "colCurrencyAmount");
            // 
            // colCurrencyRate
            // 
            this.colCurrencyRate.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colCurrencyRate.Name = "colCurrencyRate";
            this.colCurrencyRate.NamedProperties.Put("EnumerateMethod", "");
            this.colCurrencyRate.NamedProperties.Put("FieldFlags", "290");
            this.colCurrencyRate.NamedProperties.Put("Format", "");
            this.colCurrencyRate.NamedProperties.Put("LovReference", "");
            this.colCurrencyRate.NamedProperties.Put("ResizeableChildObject", "");
            this.colCurrencyRate.NamedProperties.Put("SqlColumn", "CURRENCY_RATE");
            this.colCurrencyRate.NamedProperties.Put("ValidateMethod", "");
            this.colCurrencyRate.Position = 32;
            this.colCurrencyRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.colCurrencyRate, "colCurrencyRate");
            // 
            // colText
            // 
            this.colText.Name = "colText";
            this.colText.NamedProperties.Put("EnumerateMethod", "");
            this.colText.NamedProperties.Put("LovReference", "");
            this.colText.NamedProperties.Put("ResizeableChildObject", "");
            this.colText.NamedProperties.Put("SqlColumn", "TEXT");
            this.colText.NamedProperties.Put("ValidateMethod", "");
            this.colText.Position = 42;
            resources.ApplyResources(this.colText, "colText");
            // 
            // colQuantity
            // 
            this.colQuantity.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.NamedProperties.Put("EnumerateMethod", "");
            this.colQuantity.NamedProperties.Put("LovReference", "");
            this.colQuantity.NamedProperties.Put("ResizeableChildObject", "");
            this.colQuantity.NamedProperties.Put("SqlColumn", "QUANTITY");
            this.colQuantity.NamedProperties.Put("ValidateMethod", "");
            this.colQuantity.Position = 43;
            resources.ApplyResources(this.colQuantity, "colQuantity");
            // 
            // colProcessCode
            // 
            this.colProcessCode.Name = "colProcessCode";
            this.colProcessCode.NamedProperties.Put("EnumerateMethod", "");
            this.colProcessCode.NamedProperties.Put("LovReference", "");
            this.colProcessCode.NamedProperties.Put("ResizeableChildObject", "");
            this.colProcessCode.NamedProperties.Put("SqlColumn", "PROCESS_CODE");
            this.colProcessCode.NamedProperties.Put("ValidateMethod", "");
            this.colProcessCode.Position = 44;
            resources.ApplyResources(this.colProcessCode, "colProcessCode");
            // 
            // colOptionalCode
            // 
            this.colOptionalCode.Name = "colOptionalCode";
            this.colOptionalCode.NamedProperties.Put("EnumerateMethod", "");
            this.colOptionalCode.NamedProperties.Put("LovReference", "");
            this.colOptionalCode.NamedProperties.Put("ResizeableChildObject", "");
            this.colOptionalCode.NamedProperties.Put("SqlColumn", "OPTIONAL_CODE");
            this.colOptionalCode.NamedProperties.Put("ValidateMethod", "");
            this.colOptionalCode.Position = 47;
            resources.ApplyResources(this.colOptionalCode, "colOptionalCode");
            // 
            // colPartyTypeId
            // 
            this.colPartyTypeId.MaxLength = 20;
            this.colPartyTypeId.Name = "colPartyTypeId";
            this.colPartyTypeId.NamedProperties.Put("EnumerateMethod", "");
            this.colPartyTypeId.NamedProperties.Put("LovReference", "");
            this.colPartyTypeId.NamedProperties.Put("ResizeableChildObject", "");
            this.colPartyTypeId.NamedProperties.Put("SqlColumn", "PARTY_TYPE_ID");
            this.colPartyTypeId.NamedProperties.Put("ValidateMethod", "");
            this.colPartyTypeId.Position = 48;
            resources.ApplyResources(this.colPartyTypeId, "colPartyTypeId");
            // 
            // colTransCode
            // 
            this.colTransCode.Name = "colTransCode";
            this.colTransCode.NamedProperties.Put("EnumerateMethod", "");
            this.colTransCode.NamedProperties.Put("LovReference", "");
            this.colTransCode.NamedProperties.Put("ResizeableChildObject", "");
            this.colTransCode.NamedProperties.Put("SqlColumn", "TRANS_CODE");
            this.colTransCode.NamedProperties.Put("ValidateMethod", "");
            this.colTransCode.Position = 49;
            resources.ApplyResources(this.colTransCode, "colTransCode");
            // 
            // colTransferId
            // 
            this.colTransferId.Name = "colTransferId";
            this.colTransferId.NamedProperties.Put("EnumerateMethod", "");
            this.colTransferId.NamedProperties.Put("LovReference", "");
            this.colTransferId.NamedProperties.Put("ResizeableChildObject", "");
            this.colTransferId.NamedProperties.Put("SqlColumn", "TRANSFER_ID");
            this.colTransferId.NamedProperties.Put("ValidateMethod", "");
            this.colTransferId.Position = 50;
            resources.ApplyResources(this.colTransferId, "colTransferId");
            // 
            // colCorrected
            // 
            this.colCorrected.Name = "colCorrected";
            this.colCorrected.NamedProperties.Put("EnumerateMethod", "");
            this.colCorrected.NamedProperties.Put("LovReference", "");
            this.colCorrected.NamedProperties.Put("ResizeableChildObject", "");
            this.colCorrected.NamedProperties.Put("SqlColumn", "CORRECTED");
            this.colCorrected.NamedProperties.Put("ValidateMethod", "");
            this.colCorrected.Position = 51;
            resources.ApplyResources(this.colCorrected, "colCorrected");
            // 
            // colReferenceSerie
            // 
            this.colReferenceSerie.MaxLength = 50;
            this.colReferenceSerie.Name = "colReferenceSerie";
            this.colReferenceSerie.NamedProperties.Put("EnumerateMethod", "");
            this.colReferenceSerie.NamedProperties.Put("LovReference", "");
            this.colReferenceSerie.NamedProperties.Put("ResizeableChildObject", "");
            this.colReferenceSerie.NamedProperties.Put("SqlColumn", "REFERENCE_SERIE");
            this.colReferenceSerie.NamedProperties.Put("ValidateMethod", "");
            this.colReferenceSerie.Position = 52;
            resources.ApplyResources(this.colReferenceSerie, "colReferenceSerie");
            // 
            // colReferenceNumber
            // 
            this.colReferenceNumber.MaxLength = 50;
            this.colReferenceNumber.Name = "colReferenceNumber";
            this.colReferenceNumber.NamedProperties.Put("EnumerateMethod", "");
            this.colReferenceNumber.NamedProperties.Put("LovReference", "");
            this.colReferenceNumber.NamedProperties.Put("ResizeableChildObject", "");
            this.colReferenceNumber.NamedProperties.Put("SqlColumn", "REFERENCE_NUMBER");
            this.colReferenceNumber.NamedProperties.Put("ValidateMethod", "");
            this.colReferenceNumber.Position = 53;
            resources.ApplyResources(this.colReferenceNumber, "colReferenceNumber");
            // 
            // colnConversionFactor
            // 
            this.colnConversionFactor.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colnConversionFactor.Name = "colnConversionFactor";
            this.colnConversionFactor.NamedProperties.Put("EnumerateMethod", "");
            this.colnConversionFactor.NamedProperties.Put("FieldFlags", "290");
            this.colnConversionFactor.NamedProperties.Put("Format", "");
            this.colnConversionFactor.NamedProperties.Put("LovReference", "");
            this.colnConversionFactor.NamedProperties.Put("SqlColumn", "CONVERSION_FACTOR");
            this.colnConversionFactor.Position = 33;
            this.colnConversionFactor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.colnConversionFactor, "colnConversionFactor");
            // 
            // colnThirdCurrencyDebitAmount
            // 
            this.colnThirdCurrencyDebitAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colnThirdCurrencyDebitAmount.Name = "colnThirdCurrencyDebitAmount";
            this.colnThirdCurrencyDebitAmount.NamedProperties.Put("EnumerateMethod", "");
            this.colnThirdCurrencyDebitAmount.NamedProperties.Put("FieldFlags", "288");
            this.colnThirdCurrencyDebitAmount.NamedProperties.Put("Format", "20");
            this.colnThirdCurrencyDebitAmount.NamedProperties.Put("LovReference", "");
            this.colnThirdCurrencyDebitAmount.NamedProperties.Put("SqlColumn", "THIRD_CURRENCY_DEBIT_AMOUNT");
            this.colnThirdCurrencyDebitAmount.Position = 39;
            this.colnThirdCurrencyDebitAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.colnThirdCurrencyDebitAmount, "colnThirdCurrencyDebitAmount");
            // 
            // colnThirdCurrencyCreditAmount
            // 
            this.colnThirdCurrencyCreditAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colnThirdCurrencyCreditAmount.Name = "colnThirdCurrencyCreditAmount";
            this.colnThirdCurrencyCreditAmount.NamedProperties.Put("EnumerateMethod", "");
            this.colnThirdCurrencyCreditAmount.NamedProperties.Put("FieldFlags", "288");
            this.colnThirdCurrencyCreditAmount.NamedProperties.Put("Format", "20");
            this.colnThirdCurrencyCreditAmount.NamedProperties.Put("LovReference", "");
            this.colnThirdCurrencyCreditAmount.NamedProperties.Put("SqlColumn", "THIRD_CURRENCY_CREDIT_AMOUNT");
            this.colnThirdCurrencyCreditAmount.Position = 40;
            this.colnThirdCurrencyCreditAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.colnThirdCurrencyCreditAmount, "colnThirdCurrencyCreditAmount");
            // 
            // colnThirdCurrencyAmount
            // 
            this.colnThirdCurrencyAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colnThirdCurrencyAmount.Name = "colnThirdCurrencyAmount";
            this.colnThirdCurrencyAmount.NamedProperties.Put("EnumerateMethod", "");
            this.colnThirdCurrencyAmount.NamedProperties.Put("FieldFlags", "288");
            this.colnThirdCurrencyAmount.NamedProperties.Put("Format", "20");
            this.colnThirdCurrencyAmount.NamedProperties.Put("LovReference", "");
            this.colnThirdCurrencyAmount.NamedProperties.Put("SqlColumn", "THIRD_CURRENCY_AMOUNT");
            this.colnThirdCurrencyAmount.Position = 41;
            this.colnThirdCurrencyAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.colnThirdCurrencyAmount, "colnThirdCurrencyAmount");
            // 
            // colnParallelCurrencyRate
            // 
            this.colnParallelCurrencyRate.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colnParallelCurrencyRate.Name = "colnParallelCurrencyRate";
            this.colnParallelCurrencyRate.NamedProperties.Put("EnumerateMethod", "");
            this.colnParallelCurrencyRate.NamedProperties.Put("FieldFlags", "288");
            this.colnParallelCurrencyRate.NamedProperties.Put("Format", "");
            this.colnParallelCurrencyRate.NamedProperties.Put("LovReference", "");
            this.colnParallelCurrencyRate.NamedProperties.Put("SqlColumn", "PARALLEL_CURRENCY_RATE");
            this.colnParallelCurrencyRate.Position = 37;
            this.colnParallelCurrencyRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.colnParallelCurrencyRate, "colnParallelCurrencyRate");
            // 
            // colnParallelConversionFactor
            // 
            this.colnParallelConversionFactor.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colnParallelConversionFactor.Name = "colnParallelConversionFactor";
            this.colnParallelConversionFactor.NamedProperties.Put("EnumerateMethod", "");
            this.colnParallelConversionFactor.NamedProperties.Put("FieldFlags", "288");
            this.colnParallelConversionFactor.NamedProperties.Put("Format", "");
            this.colnParallelConversionFactor.NamedProperties.Put("LovReference", "");
            this.colnParallelConversionFactor.NamedProperties.Put("SqlColumn", "PARALLEL_CONVERSION_FACTOR");
            this.colnParallelConversionFactor.Position = 38;
            this.colnParallelConversionFactor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.colnParallelConversionFactor, "colnParallelConversionFactor");
            // 
            // colsDeliveryTypeId
            // 
            this.colsDeliveryTypeId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsDeliveryTypeId.MaxLength = 20;
            this.colsDeliveryTypeId.Name = "colsDeliveryTypeId";
            this.colsDeliveryTypeId.NamedProperties.Put("EnumerateMethod", "");
            this.colsDeliveryTypeId.NamedProperties.Put("FieldFlags", "290");
            this.colsDeliveryTypeId.NamedProperties.Put("LovReference", "DELIVERY_TYPE(COMPANY)");
            this.colsDeliveryTypeId.NamedProperties.Put("SqlColumn", "DELIV_TYPE_ID");
            this.colsDeliveryTypeId.Position = 45;
            resources.ApplyResources(this.colsDeliveryTypeId, "colsDeliveryTypeId");
            // 
            // colsDeliveryTypeDescription
            // 
            this.colsDeliveryTypeDescription.MaxLength = 2000;
            this.colsDeliveryTypeDescription.Name = "colsDeliveryTypeDescription";
            this.colsDeliveryTypeDescription.NamedProperties.Put("EnumerateMethod", "");
            this.colsDeliveryTypeDescription.NamedProperties.Put("FieldFlags", "288");
            this.colsDeliveryTypeDescription.NamedProperties.Put("LovReference", "");
            this.colsDeliveryTypeDescription.NamedProperties.Put("ParentName", "colsDeliveryTypeId");
            this.colsDeliveryTypeDescription.NamedProperties.Put("SqlColumn", "Voucher_Row_API.Get_Delivery_Type_Description(COMPANY,DELIV_TYPE_ID)");
            this.colsDeliveryTypeDescription.Position = 46;
            resources.ApplyResources(this.colsDeliveryTypeDescription, "colsDeliveryTypeDescription");
            // 
            // tbwVoucherRow
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colCompany);
            this.Controls.Add(this.colVoucherNo);
            this.Controls.Add(this.colVoucherType);
            this.Controls.Add(this.colnAccountingYear);
            this.Controls.Add(this.colCorrection);
            this.Controls.Add(this.colnAccount);
            this.Controls.Add(this.colsAccountDesc);
            this.Controls.Add(this.colCodeB);
            this.Controls.Add(this.colsCodeBDesc);
            this.Controls.Add(this.colCodeC);
            this.Controls.Add(this.colsCodeCDesc);
            this.Controls.Add(this.colCodeD);
            this.Controls.Add(this.colsCodeDDesc);
            this.Controls.Add(this.colCodeE);
            this.Controls.Add(this.colsCodeEDesc);
            this.Controls.Add(this.colCodeF);
            this.Controls.Add(this.colsCodeFDesc);
            this.Controls.Add(this.colCodeG);
            this.Controls.Add(this.colsCodeGDesc);
            this.Controls.Add(this.colCodeH);
            this.Controls.Add(this.colsCodeHDesc);
            this.Controls.Add(this.colCodeI);
            this.Controls.Add(this.colsCodeIDesc);
            this.Controls.Add(this.colCodeJ);
            this.Controls.Add(this.colsCodeJDesc);
            this.Controls.Add(this.colDebetAmount);
            this.Controls.Add(this.colCreditAmount);
            this.Controls.Add(this.colAmount);
            this.Controls.Add(this.colCurrencyCode);
            this.Controls.Add(this.colCurrencyRate);
            this.Controls.Add(this.colnConversionFactor);
            this.Controls.Add(this.colCurrencyDebetAmount);
            this.Controls.Add(this.colCurrencyCreditAmount);
            this.Controls.Add(this.colCurrencyAmount);
            this.Controls.Add(this.colnParallelCurrencyRate);
            this.Controls.Add(this.colnParallelConversionFactor);
            this.Controls.Add(this.colnThirdCurrencyDebitAmount);
            this.Controls.Add(this.colnThirdCurrencyCreditAmount);
            this.Controls.Add(this.colnThirdCurrencyAmount);
            this.Controls.Add(this.colText);
            this.Controls.Add(this.colQuantity);
            this.Controls.Add(this.colsDeliveryTypeId);
            this.Controls.Add(this.colsDeliveryTypeDescription);
            this.Controls.Add(this.colProcessCode);
            this.Controls.Add(this.colOptionalCode);
            this.Controls.Add(this.colPartyTypeId);
            this.Controls.Add(this.colTransCode);
            this.Controls.Add(this.colTransferId);
            this.Controls.Add(this.colCorrected);
            this.Controls.Add(this.colReferenceSerie);
            this.Controls.Add(this.colReferenceNumber);
            this.Controls.Add(this.ToolBar);
            this.Controls.Add(this.StatusBar);
            this.Name = "tbwVoucherRow";
            this.NamedProperties.Put("DefaultOrderBy", "VOUCHER_TYPE, VOUCHER_NO");
            this.NamedProperties.Put("DefaultWhere", "TRANS_CODE IN ( \'MANUAL\', \'INTERIM\', \'EXTERNAL\', \'External\' )");
            this.NamedProperties.Put("LogicalUnit", "GenLedVoucherRow");
            this.NamedProperties.Put("PackageName", "GEN_LED_VOUCHER_ROW_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "0");
            this.NamedProperties.Put("SourceFlags", "16385");
            this.NamedProperties.Put("ViewName", "GEN_LED_VOUCHER_ROW2");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tbwVoucherRow_WindowActions);
            this.Controls.SetChildIndex(this.StatusBar, 0);
            this.Controls.SetChildIndex(this.ToolBar, 0);
            this.Controls.SetChildIndex(this.colReferenceNumber, 0);
            this.Controls.SetChildIndex(this.colReferenceSerie, 0);
            this.Controls.SetChildIndex(this.colCorrected, 0);
            this.Controls.SetChildIndex(this.colTransferId, 0);
            this.Controls.SetChildIndex(this.colTransCode, 0);
            this.Controls.SetChildIndex(this.colPartyTypeId, 0);
            this.Controls.SetChildIndex(this.colOptionalCode, 0);
            this.Controls.SetChildIndex(this.colProcessCode, 0);
            this.Controls.SetChildIndex(this.colsDeliveryTypeDescription, 0);
            this.Controls.SetChildIndex(this.colsDeliveryTypeId, 0);
            this.Controls.SetChildIndex(this.colQuantity, 0);
            this.Controls.SetChildIndex(this.colText, 0);
            this.Controls.SetChildIndex(this.colnThirdCurrencyAmount, 0);
            this.Controls.SetChildIndex(this.colnThirdCurrencyCreditAmount, 0);
            this.Controls.SetChildIndex(this.colnThirdCurrencyDebitAmount, 0);
            this.Controls.SetChildIndex(this.colnParallelConversionFactor, 0);
            this.Controls.SetChildIndex(this.colnParallelCurrencyRate, 0);
            this.Controls.SetChildIndex(this.colCurrencyAmount, 0);
            this.Controls.SetChildIndex(this.colCurrencyCreditAmount, 0);
            this.Controls.SetChildIndex(this.colCurrencyDebetAmount, 0);
            this.Controls.SetChildIndex(this.colnConversionFactor, 0);
            this.Controls.SetChildIndex(this.colCurrencyRate, 0);
            this.Controls.SetChildIndex(this.colCurrencyCode, 0);
            this.Controls.SetChildIndex(this.colAmount, 0);
            this.Controls.SetChildIndex(this.colCreditAmount, 0);
            this.Controls.SetChildIndex(this.colDebetAmount, 0);
            this.Controls.SetChildIndex(this.colsCodeJDesc, 0);
            this.Controls.SetChildIndex(this.colCodeJ, 0);
            this.Controls.SetChildIndex(this.colsCodeIDesc, 0);
            this.Controls.SetChildIndex(this.colCodeI, 0);
            this.Controls.SetChildIndex(this.colsCodeHDesc, 0);
            this.Controls.SetChildIndex(this.colCodeH, 0);
            this.Controls.SetChildIndex(this.colsCodeGDesc, 0);
            this.Controls.SetChildIndex(this.colCodeG, 0);
            this.Controls.SetChildIndex(this.colsCodeFDesc, 0);
            this.Controls.SetChildIndex(this.colCodeF, 0);
            this.Controls.SetChildIndex(this.colsCodeEDesc, 0);
            this.Controls.SetChildIndex(this.colCodeE, 0);
            this.Controls.SetChildIndex(this.colsCodeDDesc, 0);
            this.Controls.SetChildIndex(this.colCodeD, 0);
            this.Controls.SetChildIndex(this.colsCodeCDesc, 0);
            this.Controls.SetChildIndex(this.colCodeC, 0);
            this.Controls.SetChildIndex(this.colsCodeBDesc, 0);
            this.Controls.SetChildIndex(this.colCodeB, 0);
            this.Controls.SetChildIndex(this.colsAccountDesc, 0);
            this.Controls.SetChildIndex(this.colnAccount, 0);
            this.Controls.SetChildIndex(this.colCorrection, 0);
            this.Controls.SetChildIndex(this.colnAccountingYear, 0);
            this.Controls.SetChildIndex(this.colVoucherType, 0);
            this.Controls.SetChildIndex(this.colVoucherNo, 0);
            this.Controls.SetChildIndex(this.colCompany, 0);
            this.Controls.SetChildIndex(this.@__colObjversion, 0);
            this.Controls.SetChildIndex(this.@__colObjid, 0);
            this.ToolBar.ResumeLayout(false);
            this.ToolBar.PerformLayout();
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

        protected cColumn colnConversionFactor;
        protected cColumn colsDeliveryTypeId;
        protected cColumn colsDeliveryTypeDescription;

	}
}
