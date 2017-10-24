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
	
	public partial class frmCreateCompany
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cDataField dfCompany;
		// Bug 92714, Begin remove queryable in F1 properties
		public cDataField dfDescription;
		// Bug 92714, End
		public cDataField dfDummy;
		public cDataField dfDummy2;
		public cDataField dfDummy3;
		protected cBackgroundText labeldfCurrencyCode;
		public cDataField dfCurrencyCode;
		protected cBackgroundText labeldfValidFrom;
		public cDataField dfValidFrom;
		protected cBackgroundText labeldfParallelAccCurrency;
		// Bug 84667, Begin
		public cDataField dfParallelAccCurrency;
		protected cBackgroundText labeldfsTimeStamp;
		public cDataField dfsTimeStamp;
		protected cBackgroundText labelcmbCorrectionType;
		public cComboBox cmbCorrectionType;
		protected cBackgroundText labelcmbReverseVouCorrType;
		public cComboBox cmbReverseVouCorrType;
		// Bug 82373, Begin
		protected cBackgroundText labelcmbPeriodClosingMethod;
		public cComboBox cmbPeriodClosingMethod;
		// Bug 82373, End
		protected cBackgroundText labeldfDefAmountMethod;
		public cComboBox dfDefAmountMethod;
		protected cBackgroundText labelcmbTaxRoundingMethod;
		public cComboBox cmbTaxRoundingMethod;
		protected SalGroupBox gbMax_Overwriting_Level_on_Tax;
		protected cBackgroundText labeldfnLevelInPercent;
		public cDataField dfnLevelInPercent;
		protected cBackgroundText labeldfnLevelInAccCurrency;
		public cDataField dfnLevelInAccCurrency;
		protected SalGroupBox gbDefault_Tax_Codes_for_Vertex_Sal;
		protected cBackgroundText labeldfsCityTaxCode;
		public cDataField dfsCityTaxCode;
		protected cBackgroundText labeldfsStateTaxCode;
		public cDataField dfsStateTaxCode;
		// Bug 92714, Begin Arrage the order
		protected cBackgroundText labeldfsCountyTaxCode;
		public cDataField dfsCountyTaxCode;
		// Bug 92714, End
		protected cBackgroundText labeldfsDistrictTaxCode;
		public cDataField dfsDistrictTaxCode;
		public cCheckBox cbUsePeriod;
		public cDataField dfsCreationFinished;
		protected cBackgroundText labelpicTab;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCreateCompany));
            this.dfCompany = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfDescription = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfDummy = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfDummy2 = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfDummy3 = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfCurrencyCode = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfCurrencyCode = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfValidFrom = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfValidFrom = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfParallelAccCurrency = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfParallelAccCurrency = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsTimeStamp = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsTimeStamp = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelcmbCorrectionType = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbCorrectionType = new Ifs.Fnd.ApplicationForms.cComboBox();
            this.labelcmbReverseVouCorrType = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbReverseVouCorrType = new Ifs.Fnd.ApplicationForms.cComboBox();
            this.labelcmbPeriodClosingMethod = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbPeriodClosingMethod = new Ifs.Fnd.ApplicationForms.cComboBox();
            this.labeldfDefAmountMethod = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfDefAmountMethod = new Ifs.Fnd.ApplicationForms.cComboBox();
            this.labelcmbTaxRoundingMethod = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbTaxRoundingMethod = new Ifs.Fnd.ApplicationForms.cComboBox();
            this.gbMax_Overwriting_Level_on_Tax = new PPJ.Runtime.Windows.SalGroupBox();
            this.labeldfnLevelInPercent = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfnLevelInPercent = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfnLevelInAccCurrency = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfnLevelInAccCurrency = new Ifs.Fnd.ApplicationForms.cDataField();
            this.gbDefault_Tax_Codes_for_Vertex_Sal = new PPJ.Runtime.Windows.SalGroupBox();
            this.labeldfsCityTaxCode = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsCityTaxCode = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsStateTaxCode = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsStateTaxCode = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsCountyTaxCode = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsCountyTaxCode = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsDistrictTaxCode = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsDistrictTaxCode = new Ifs.Fnd.ApplicationForms.cDataField();
            this.cbUsePeriod = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.dfsCreationFinished = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelpicTab = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.labelParallelBase = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsParallelRateType = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelParallelRateType = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsParallelBase = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsParallelBaseDb = new Ifs.Fnd.ApplicationForms.cDataField();
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
            // dfCompany
            // 
            this.dfCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfCompany, "dfCompany");
            this.dfCompany.Name = "dfCompany";
            this.dfCompany.NamedProperties.Put("EnumerateMethod", "");
            this.dfCompany.NamedProperties.Put("FieldFlags", "67");
            this.dfCompany.NamedProperties.Put("LovReference", "");
            this.dfCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.dfCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.dfCompany.NamedProperties.Put("ValidateMethod", "");
            // 
            // dfDescription
            // 
            resources.ApplyResources(this.dfDescription, "dfDescription");
            this.dfDescription.Name = "dfDescription";
            this.dfDescription.NamedProperties.Put("EnumerateMethod", "");
            this.dfDescription.NamedProperties.Put("FieldFlags", "259");
            this.dfDescription.NamedProperties.Put("LovReference", "");
            this.dfDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.dfDescription.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            this.dfDescription.NamedProperties.Put("ValidateMethod", "");
            // 
            // dfDummy
            // 
            resources.ApplyResources(this.dfDummy, "dfDummy");
            this.dfDummy.Name = "dfDummy";
            this.dfDummy.NamedProperties.Put("EnumerateMethod", "");
            this.dfDummy.NamedProperties.Put("FieldFlags", "288");
            this.dfDummy.NamedProperties.Put("LovReference", "");
            this.dfDummy.NamedProperties.Put("ResizeableChildObject", "");
            this.dfDummy.NamedProperties.Put("SqlColumn", "");
            this.dfDummy.NamedProperties.Put("ValidateMethod", "");
            // 
            // dfDummy2
            // 
            resources.ApplyResources(this.dfDummy2, "dfDummy2");
            this.dfDummy2.Name = "dfDummy2";
            this.dfDummy2.NamedProperties.Put("EnumerateMethod", "");
            this.dfDummy2.NamedProperties.Put("FieldFlags", "288");
            this.dfDummy2.NamedProperties.Put("LovReference", "");
            this.dfDummy2.NamedProperties.Put("ResizeableChildObject", "");
            this.dfDummy2.NamedProperties.Put("SqlColumn", "");
            this.dfDummy2.NamedProperties.Put("ValidateMethod", "");
            // 
            // dfDummy3
            // 
            resources.ApplyResources(this.dfDummy3, "dfDummy3");
            this.dfDummy3.Name = "dfDummy3";
            this.dfDummy3.NamedProperties.Put("EnumerateMethod", "");
            this.dfDummy3.NamedProperties.Put("FieldFlags", "288");
            this.dfDummy3.NamedProperties.Put("LovReference", "");
            this.dfDummy3.NamedProperties.Put("ResizeableChildObject", "");
            this.dfDummy3.NamedProperties.Put("SqlColumn", "");
            this.dfDummy3.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfCurrencyCode
            // 
            resources.ApplyResources(this.labeldfCurrencyCode, "labeldfCurrencyCode");
            this.labeldfCurrencyCode.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeldfCurrencyCode, "GeneralData");
            this.labeldfCurrencyCode.Name = "labeldfCurrencyCode";
            // 
            // dfCurrencyCode
            // 
            this.dfCurrencyCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.picTab.SetControlTabPages(this.dfCurrencyCode, "GeneralData");
            resources.ApplyResources(this.dfCurrencyCode, "dfCurrencyCode");
            this.dfCurrencyCode.Name = "dfCurrencyCode";
            this.dfCurrencyCode.NamedProperties.Put("EnumerateMethod", "ISO_CURRENCY_API.Enumerate");
            this.dfCurrencyCode.NamedProperties.Put("FieldFlags", "291");
            this.dfCurrencyCode.NamedProperties.Put("LovReference", "ISO_CURRENCY");
            this.dfCurrencyCode.NamedProperties.Put("SqlColumn", "CURRENCY_CODE");
            // 
            // labeldfValidFrom
            // 
            resources.ApplyResources(this.labeldfValidFrom, "labeldfValidFrom");
            this.labeldfValidFrom.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeldfValidFrom, "GeneralData");
            this.labeldfValidFrom.Name = "labeldfValidFrom";
            // 
            // dfValidFrom
            // 
            this.picTab.SetControlTabPages(this.dfValidFrom, "GeneralData");
            this.dfValidFrom.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.dfValidFrom.Format = "d";
            resources.ApplyResources(this.dfValidFrom, "dfValidFrom");
            this.dfValidFrom.Name = "dfValidFrom";
            this.dfValidFrom.NamedProperties.Put("EnumerateMethod", "");
            this.dfValidFrom.NamedProperties.Put("FieldFlags", "291");
            this.dfValidFrom.NamedProperties.Put("LovReference", "");
            this.dfValidFrom.NamedProperties.Put("SqlColumn", "VALID_FROM");
            // 
            // labeldfParallelAccCurrency
            // 
            resources.ApplyResources(this.labeldfParallelAccCurrency, "labeldfParallelAccCurrency");
            this.labeldfParallelAccCurrency.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeldfParallelAccCurrency, "GeneralData");
            this.labeldfParallelAccCurrency.Name = "labeldfParallelAccCurrency";
            // 
            // dfParallelAccCurrency
            // 
            this.dfParallelAccCurrency.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.picTab.SetControlTabPages(this.dfParallelAccCurrency, "GeneralData");
            resources.ApplyResources(this.dfParallelAccCurrency, "dfParallelAccCurrency");
            this.dfParallelAccCurrency.Name = "dfParallelAccCurrency";
            this.dfParallelAccCurrency.NamedProperties.Put("EnumerateMethod", "ISO_CURRENCY_API.Enumerate");
            this.dfParallelAccCurrency.NamedProperties.Put("FieldFlags", "288");
            this.dfParallelAccCurrency.NamedProperties.Put("LovReference", "ISO_CURRENCY");
            this.dfParallelAccCurrency.NamedProperties.Put("ResizeableChildObject", "");
            this.dfParallelAccCurrency.NamedProperties.Put("SqlColumn", "PARALLEL_ACC_CURRENCY");
            this.dfParallelAccCurrency.NamedProperties.Put("ValidateMethod", "");
            this.dfParallelAccCurrency.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfParallelAccCurrency_WindowActions);
            // 
            // labeldfsTimeStamp
            // 
            resources.ApplyResources(this.labeldfsTimeStamp, "labeldfsTimeStamp");
            this.labeldfsTimeStamp.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeldfsTimeStamp, "GeneralData");
            this.labeldfsTimeStamp.Name = "labeldfsTimeStamp";
            // 
            // dfsTimeStamp
            // 
            this.picTab.SetControlTabPages(this.dfsTimeStamp, "GeneralData");
            this.dfsTimeStamp.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.dfsTimeStamp.Format = "d";
            resources.ApplyResources(this.dfsTimeStamp, "dfsTimeStamp");
            this.dfsTimeStamp.Name = "dfsTimeStamp";
            this.dfsTimeStamp.NamedProperties.Put("EnumerateMethod", "");
            this.dfsTimeStamp.NamedProperties.Put("FieldFlags", "290");
            this.dfsTimeStamp.NamedProperties.Put("LovReference", "");
            this.dfsTimeStamp.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsTimeStamp.NamedProperties.Put("SqlColumn", "TIME_STAMP");
            this.dfsTimeStamp.NamedProperties.Put("ValidateMethod", "");
            // 
            // labelcmbCorrectionType
            // 
            resources.ApplyResources(this.labelcmbCorrectionType, "labelcmbCorrectionType");
            this.labelcmbCorrectionType.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labelcmbCorrectionType, "GeneralData");
            this.labelcmbCorrectionType.Name = "labelcmbCorrectionType";
            // 
            // cmbCorrectionType
            // 
            this.picTab.SetControlTabPages(this.cmbCorrectionType, "GeneralData");
            resources.ApplyResources(this.cmbCorrectionType, "cmbCorrectionType");
            this.cmbCorrectionType.Name = "cmbCorrectionType";
            this.cmbCorrectionType.NamedProperties.Put("EnumerateMethod", "CORRECTION_TYPE_API.Enumerate");
            this.cmbCorrectionType.NamedProperties.Put("FieldFlags", "295");
            this.cmbCorrectionType.NamedProperties.Put("LovReference", "");
            this.cmbCorrectionType.NamedProperties.Put("SqlColumn", "CORRECTION_TYPE");
            this.cmbCorrectionType.NamedProperties.Put("ValidateMethod", "");
            // 
            // labelcmbReverseVouCorrType
            // 
            resources.ApplyResources(this.labelcmbReverseVouCorrType, "labelcmbReverseVouCorrType");
            this.labelcmbReverseVouCorrType.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labelcmbReverseVouCorrType, "GeneralData");
            this.labelcmbReverseVouCorrType.Name = "labelcmbReverseVouCorrType";
            // 
            // cmbReverseVouCorrType
            // 
            this.picTab.SetControlTabPages(this.cmbReverseVouCorrType, "GeneralData");
            resources.ApplyResources(this.cmbReverseVouCorrType, "cmbReverseVouCorrType");
            this.cmbReverseVouCorrType.Name = "cmbReverseVouCorrType";
            this.cmbReverseVouCorrType.NamedProperties.Put("EnumerateMethod", "CORRECTION_TYPE_API.Enumerate");
            this.cmbReverseVouCorrType.NamedProperties.Put("FieldFlags", "295");
            this.cmbReverseVouCorrType.NamedProperties.Put("LovReference", "");
            this.cmbReverseVouCorrType.NamedProperties.Put("SqlColumn", "REVERSE_VOU_CORR_TYPE");
            // 
            // labelcmbPeriodClosingMethod
            // 
            resources.ApplyResources(this.labelcmbPeriodClosingMethod, "labelcmbPeriodClosingMethod");
            this.labelcmbPeriodClosingMethod.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labelcmbPeriodClosingMethod, "GeneralData");
            this.labelcmbPeriodClosingMethod.Name = "labelcmbPeriodClosingMethod";
            // 
            // cmbPeriodClosingMethod
            // 
            this.picTab.SetControlTabPages(this.cmbPeriodClosingMethod, "GeneralData");
            resources.ApplyResources(this.cmbPeriodClosingMethod, "cmbPeriodClosingMethod");
            this.cmbPeriodClosingMethod.Name = "cmbPeriodClosingMethod";
            this.cmbPeriodClosingMethod.NamedProperties.Put("EnumerateMethod", "PERIOD_CLOSING_METHOD_API.Enumerate");
            this.cmbPeriodClosingMethod.NamedProperties.Put("FieldFlags", "295");
            this.cmbPeriodClosingMethod.NamedProperties.Put("LovReference", "");
            this.cmbPeriodClosingMethod.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbPeriodClosingMethod.NamedProperties.Put("SqlColumn", "PERIOD_CLOSING_METHOD");
            this.cmbPeriodClosingMethod.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfDefAmountMethod
            // 
            resources.ApplyResources(this.labeldfDefAmountMethod, "labeldfDefAmountMethod");
            this.labeldfDefAmountMethod.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeldfDefAmountMethod, "GeneralData");
            this.labeldfDefAmountMethod.Name = "labeldfDefAmountMethod";
            // 
            // dfDefAmountMethod
            // 
            this.picTab.SetControlTabPages(this.dfDefAmountMethod, "GeneralData");
            resources.ApplyResources(this.dfDefAmountMethod, "dfDefAmountMethod");
            this.dfDefAmountMethod.Name = "dfDefAmountMethod";
            this.dfDefAmountMethod.NamedProperties.Put("EnumerateMethod", "DEF_AMOUNT_METHOD_API.Enumerate");
            this.dfDefAmountMethod.NamedProperties.Put("FieldFlags", "295");
            this.dfDefAmountMethod.NamedProperties.Put("LovReference", "");
            this.dfDefAmountMethod.NamedProperties.Put("ResizeableChildObject", "");
            this.dfDefAmountMethod.NamedProperties.Put("SqlColumn", "DEF_AMOUNT_METHOD");
            this.dfDefAmountMethod.NamedProperties.Put("ValidateMethod", "");
            // 
            // labelcmbTaxRoundingMethod
            // 
            resources.ApplyResources(this.labelcmbTaxRoundingMethod, "labelcmbTaxRoundingMethod");
            this.labelcmbTaxRoundingMethod.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labelcmbTaxRoundingMethod, "GeneralData");
            this.labelcmbTaxRoundingMethod.Name = "labelcmbTaxRoundingMethod";
            // 
            // cmbTaxRoundingMethod
            // 
            this.picTab.SetControlTabPages(this.cmbTaxRoundingMethod, "GeneralData");
            resources.ApplyResources(this.cmbTaxRoundingMethod, "cmbTaxRoundingMethod");
            this.cmbTaxRoundingMethod.Name = "cmbTaxRoundingMethod";
            this.cmbTaxRoundingMethod.NamedProperties.Put("EnumerateMethod", "TAX_ROUNDING_METHOD_API.Enumerate");
            this.cmbTaxRoundingMethod.NamedProperties.Put("FieldFlags", "295");
            this.cmbTaxRoundingMethod.NamedProperties.Put("LovReference", "");
            this.cmbTaxRoundingMethod.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbTaxRoundingMethod.NamedProperties.Put("SqlColumn", "TAX_ROUNDING_METHOD");
            this.cmbTaxRoundingMethod.NamedProperties.Put("ValidateMethod", "");
            // 
            // gbMax_Overwriting_Level_on_Tax
            // 
            this.gbMax_Overwriting_Level_on_Tax.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.gbMax_Overwriting_Level_on_Tax, "GeneralData");
            resources.ApplyResources(this.gbMax_Overwriting_Level_on_Tax, "gbMax_Overwriting_Level_on_Tax");
            this.gbMax_Overwriting_Level_on_Tax.Name = "gbMax_Overwriting_Level_on_Tax";
            this.gbMax_Overwriting_Level_on_Tax.TabStop = false;
            // 
            // labeldfnLevelInPercent
            // 
            resources.ApplyResources(this.labeldfnLevelInPercent, "labeldfnLevelInPercent");
            this.labeldfnLevelInPercent.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeldfnLevelInPercent, "GeneralData");
            this.labeldfnLevelInPercent.Name = "labeldfnLevelInPercent";
            // 
            // dfnLevelInPercent
            // 
            this.picTab.SetControlTabPages(this.dfnLevelInPercent, "GeneralData");
            this.dfnLevelInPercent.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.dfnLevelInPercent.Format = "N";
            resources.ApplyResources(this.dfnLevelInPercent, "dfnLevelInPercent");
            this.dfnLevelInPercent.Name = "dfnLevelInPercent";
            this.dfnLevelInPercent.NamedProperties.Put("EnumerateMethod", "");
            this.dfnLevelInPercent.NamedProperties.Put("FieldFlags", "262");
            this.dfnLevelInPercent.NamedProperties.Put("LovReference", "");
            this.dfnLevelInPercent.NamedProperties.Put("ResizeableChildObject", "");
            this.dfnLevelInPercent.NamedProperties.Put("SqlColumn", "LEVEL_IN_PERCENT");
            this.dfnLevelInPercent.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfnLevelInAccCurrency
            // 
            resources.ApplyResources(this.labeldfnLevelInAccCurrency, "labeldfnLevelInAccCurrency");
            this.labeldfnLevelInAccCurrency.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeldfnLevelInAccCurrency, "GeneralData");
            this.labeldfnLevelInAccCurrency.Name = "labeldfnLevelInAccCurrency";
            // 
            // dfnLevelInAccCurrency
            // 
            this.picTab.SetControlTabPages(this.dfnLevelInAccCurrency, "GeneralData");
            this.dfnLevelInAccCurrency.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfnLevelInAccCurrency, "dfnLevelInAccCurrency");
            this.dfnLevelInAccCurrency.Name = "dfnLevelInAccCurrency";
            this.dfnLevelInAccCurrency.NamedProperties.Put("EnumerateMethod", "");
            this.dfnLevelInAccCurrency.NamedProperties.Put("FieldFlags", "262");
            this.dfnLevelInAccCurrency.NamedProperties.Put("Format", "20");
            this.dfnLevelInAccCurrency.NamedProperties.Put("LovReference", "");
            this.dfnLevelInAccCurrency.NamedProperties.Put("ResizeableChildObject", "");
            this.dfnLevelInAccCurrency.NamedProperties.Put("SqlColumn", "LEVEL_IN_ACC_CURRENCY");
            this.dfnLevelInAccCurrency.NamedProperties.Put("ValidateMethod", "");
            // 
            // gbDefault_Tax_Codes_for_Vertex_Sal
            // 
            this.gbDefault_Tax_Codes_for_Vertex_Sal.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.gbDefault_Tax_Codes_for_Vertex_Sal, "GeneralData");
            resources.ApplyResources(this.gbDefault_Tax_Codes_for_Vertex_Sal, "gbDefault_Tax_Codes_for_Vertex_Sal");
            this.gbDefault_Tax_Codes_for_Vertex_Sal.Name = "gbDefault_Tax_Codes_for_Vertex_Sal";
            this.gbDefault_Tax_Codes_for_Vertex_Sal.TabStop = false;
            // 
            // labeldfsCityTaxCode
            // 
            resources.ApplyResources(this.labeldfsCityTaxCode, "labeldfsCityTaxCode");
            this.labeldfsCityTaxCode.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeldfsCityTaxCode, "GeneralData");
            this.labeldfsCityTaxCode.Name = "labeldfsCityTaxCode";
            // 
            // dfsCityTaxCode
            // 
            this.dfsCityTaxCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.picTab.SetControlTabPages(this.dfsCityTaxCode, "GeneralData");
            resources.ApplyResources(this.dfsCityTaxCode, "dfsCityTaxCode");
            this.dfsCityTaxCode.Name = "dfsCityTaxCode";
            this.dfsCityTaxCode.NamedProperties.Put("EnumerateMethod", "");
            this.dfsCityTaxCode.NamedProperties.Put("FieldFlags", "294");
            this.dfsCityTaxCode.NamedProperties.Put("LovReference", "STATUTORY_FEE_NON_VAT(COMPANY)");
            this.dfsCityTaxCode.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsCityTaxCode.NamedProperties.Put("SqlColumn", "CITY_TAX_CODE");
            this.dfsCityTaxCode.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsStateTaxCode
            // 
            resources.ApplyResources(this.labeldfsStateTaxCode, "labeldfsStateTaxCode");
            this.labeldfsStateTaxCode.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeldfsStateTaxCode, "GeneralData");
            this.labeldfsStateTaxCode.Name = "labeldfsStateTaxCode";
            // 
            // dfsStateTaxCode
            // 
            this.dfsStateTaxCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.picTab.SetControlTabPages(this.dfsStateTaxCode, "GeneralData");
            resources.ApplyResources(this.dfsStateTaxCode, "dfsStateTaxCode");
            this.dfsStateTaxCode.Name = "dfsStateTaxCode";
            this.dfsStateTaxCode.NamedProperties.Put("EnumerateMethod", "");
            this.dfsStateTaxCode.NamedProperties.Put("FieldFlags", "294");
            this.dfsStateTaxCode.NamedProperties.Put("LovReference", "STATUTORY_FEE_NON_VAT(COMPANY)");
            this.dfsStateTaxCode.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsStateTaxCode.NamedProperties.Put("SqlColumn", "STATE_TAX_CODE");
            this.dfsStateTaxCode.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsCountyTaxCode
            // 
            resources.ApplyResources(this.labeldfsCountyTaxCode, "labeldfsCountyTaxCode");
            this.labeldfsCountyTaxCode.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeldfsCountyTaxCode, "GeneralData");
            this.labeldfsCountyTaxCode.Name = "labeldfsCountyTaxCode";
            // 
            // dfsCountyTaxCode
            // 
            this.dfsCountyTaxCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.picTab.SetControlTabPages(this.dfsCountyTaxCode, "GeneralData");
            resources.ApplyResources(this.dfsCountyTaxCode, "dfsCountyTaxCode");
            this.dfsCountyTaxCode.Name = "dfsCountyTaxCode";
            this.dfsCountyTaxCode.NamedProperties.Put("EnumerateMethod", "");
            this.dfsCountyTaxCode.NamedProperties.Put("FieldFlags", "294");
            this.dfsCountyTaxCode.NamedProperties.Put("LovReference", "STATUTORY_FEE_NON_VAT(COMPANY)");
            this.dfsCountyTaxCode.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsCountyTaxCode.NamedProperties.Put("SqlColumn", "COUNTY_TAX_CODE");
            this.dfsCountyTaxCode.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsDistrictTaxCode
            // 
            resources.ApplyResources(this.labeldfsDistrictTaxCode, "labeldfsDistrictTaxCode");
            this.labeldfsDistrictTaxCode.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeldfsDistrictTaxCode, "GeneralData");
            this.labeldfsDistrictTaxCode.Name = "labeldfsDistrictTaxCode";
            // 
            // dfsDistrictTaxCode
            // 
            this.dfsDistrictTaxCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.picTab.SetControlTabPages(this.dfsDistrictTaxCode, "GeneralData");
            resources.ApplyResources(this.dfsDistrictTaxCode, "dfsDistrictTaxCode");
            this.dfsDistrictTaxCode.Name = "dfsDistrictTaxCode";
            this.dfsDistrictTaxCode.NamedProperties.Put("EnumerateMethod", "");
            this.dfsDistrictTaxCode.NamedProperties.Put("FieldFlags", "294");
            this.dfsDistrictTaxCode.NamedProperties.Put("LovReference", "STATUTORY_FEE_NON_VAT(COMPANY)");
            this.dfsDistrictTaxCode.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsDistrictTaxCode.NamedProperties.Put("SqlColumn", "DISTRICT_TAX_CODE");
            this.dfsDistrictTaxCode.NamedProperties.Put("ValidateMethod", "");
            // 
            // cbUsePeriod
            // 
            this.cbUsePeriod.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.cbUsePeriod, "GeneralData");
            resources.ApplyResources(this.cbUsePeriod, "cbUsePeriod");
            this.cbUsePeriod.Name = "cbUsePeriod";
            this.cbUsePeriod.NamedProperties.Put("DataType", "7");
            this.cbUsePeriod.NamedProperties.Put("EnumerateMethod", "");
            this.cbUsePeriod.NamedProperties.Put("FieldFlags", "304");
            this.cbUsePeriod.NamedProperties.Put("LovReference", "");
            this.cbUsePeriod.NamedProperties.Put("ResizeableChildObject", "");
            this.cbUsePeriod.NamedProperties.Put("SqlColumn", "USE_VOU_NO_PERIOD");
            this.cbUsePeriod.NamedProperties.Put("ValidateMethod", "");
            this.cbUsePeriod.NamedProperties.Put("XDataLength", "2000");
            this.cbUsePeriod.UseVisualStyleBackColor = false;
            // 
            // dfsCreationFinished
            // 
            resources.ApplyResources(this.dfsCreationFinished, "dfsCreationFinished");
            this.dfsCreationFinished.Name = "dfsCreationFinished";
            this.dfsCreationFinished.NamedProperties.Put("EnumerateMethod", "");
            this.dfsCreationFinished.NamedProperties.Put("LovReference", "");
            this.dfsCreationFinished.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsCreationFinished.NamedProperties.Put("SqlColumn", "CREATION_FINISHED");
            this.dfsCreationFinished.NamedProperties.Put("ValidateMethod", "");
            // 
            // labelpicTab
            // 
            resources.ApplyResources(this.labelpicTab, "labelpicTab");
            this.labelpicTab.Name = "labelpicTab";
            // 
            // labelParallelBase
            // 
            resources.ApplyResources(this.labelParallelBase, "labelParallelBase");
            this.labelParallelBase.Name = "labelParallelBase";
            // 
            // dfsParallelRateType
            // 
            this.picTab.SetControlTabPages(this.dfsParallelRateType, "GeneralData");
            resources.ApplyResources(this.dfsParallelRateType, "dfsParallelRateType");
            this.dfsParallelRateType.Name = "dfsParallelRateType";
            this.dfsParallelRateType.NamedProperties.Put("EnumerateMethod", "");
            this.dfsParallelRateType.NamedProperties.Put("FieldFlags", "294");
            this.dfsParallelRateType.NamedProperties.Put("LovReference", "CURRENCY_TYPE3(COMPANY)");
            this.dfsParallelRateType.NamedProperties.Put("SqlColumn", "PARALLEL_RATE_TYPE");
            this.dfsParallelRateType.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsParallelRateType_WindowActions);
            // 
            // labelParallelRateType
            // 
            resources.ApplyResources(this.labelParallelRateType, "labelParallelRateType");
            this.picTab.SetControlTabPages(this.labelParallelRateType, "GeneralData");
            this.labelParallelRateType.Name = "labelParallelRateType";
            // 
            // dfsParallelBase
            // 
            this.picTab.SetControlTabPages(this.dfsParallelBase, "GeneralData");
            resources.ApplyResources(this.dfsParallelBase, "dfsParallelBase");
            this.dfsParallelBase.Name = "dfsParallelBase";
            this.dfsParallelBase.NamedProperties.Put("EnumerateMethod", "");
            this.dfsParallelBase.NamedProperties.Put("FieldFlags", "290");
            this.dfsParallelBase.NamedProperties.Put("LovReference", "");
            this.dfsParallelBase.NamedProperties.Put("SqlColumn", "PARALLEL_BASE");
            // 
            // dfsParallelBaseDb
            // 
            resources.ApplyResources(this.dfsParallelBaseDb, "dfsParallelBaseDb");
            this.dfsParallelBaseDb.Name = "dfsParallelBaseDb";
            this.dfsParallelBaseDb.NamedProperties.Put("EnumerateMethod", "");
            this.dfsParallelBaseDb.NamedProperties.Put("FieldFlags", "288");
            this.dfsParallelBaseDb.NamedProperties.Put("LovReference", "");
            this.dfsParallelBaseDb.NamedProperties.Put("SqlColumn", "PARALLEL_BASE_DB");
            // 
            // frmCreateCompany
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.dfsParallelBaseDb);
            this.Controls.Add(this.dfsParallelBase);
            this.Controls.Add(this.dfsParallelRateType);
            this.Controls.Add(this.labelParallelRateType);
            this.Controls.Add(this.labelParallelBase);
            this.Controls.Add(this.dfsCreationFinished);
            this.Controls.Add(this.dfsDistrictTaxCode);
            this.Controls.Add(this.dfsCountyTaxCode);
            this.Controls.Add(this.dfsStateTaxCode);
            this.Controls.Add(this.dfsCityTaxCode);
            this.Controls.Add(this.dfnLevelInAccCurrency);
            this.Controls.Add(this.dfnLevelInPercent);
            this.Controls.Add(this.dfsTimeStamp);
            this.Controls.Add(this.dfParallelAccCurrency);
            this.Controls.Add(this.dfValidFrom);
            this.Controls.Add(this.dfCurrencyCode);
            this.Controls.Add(this.dfDescription);
            this.Controls.Add(this.cmbCorrectionType);
            this.Controls.Add(this.cmbReverseVouCorrType);
            this.Controls.Add(this.cmbPeriodClosingMethod);
            this.Controls.Add(this.dfDefAmountMethod);
            this.Controls.Add(this.cmbTaxRoundingMethod);
            this.Controls.Add(this.cbUsePeriod);
            this.Controls.Add(this.labelpicTab);
            this.Controls.Add(this.labeldfValidFrom);
            this.Controls.Add(this.labeldfParallelAccCurrency);
            this.Controls.Add(this.labeldfsTimeStamp);
            this.Controls.Add(this.labelcmbCorrectionType);
            this.Controls.Add(this.labelcmbReverseVouCorrType);
            this.Controls.Add(this.labelcmbPeriodClosingMethod);
            this.Controls.Add(this.labeldfDefAmountMethod);
            this.Controls.Add(this.labelcmbTaxRoundingMethod);
            this.Controls.Add(this.labeldfnLevelInPercent);
            this.Controls.Add(this.labeldfnLevelInAccCurrency);
            this.Controls.Add(this.labeldfsCityTaxCode);
            this.Controls.Add(this.labeldfsStateTaxCode);
            this.Controls.Add(this.labeldfsCountyTaxCode);
            this.Controls.Add(this.labeldfsDistrictTaxCode);
            this.Controls.Add(this.labeldfCurrencyCode);
            this.Controls.Add(this.gbDefault_Tax_Codes_for_Vertex_Sal);
            this.Controls.Add(this.gbMax_Overwriting_Level_on_Tax);
            this.Controls.Add(this.dfCompany);
            this.Controls.Add(this.dfDummy3);
            this.Controls.Add(this.dfDummy2);
            this.Controls.Add(this.dfDummy);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmCreateCompany";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "CompanyFinance");
            this.NamedProperties.Put("PackageName", "COMPANY_FINANCE_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizableChildObject", "");
            this.NamedProperties.Put("ResizeableChildObject", "0");
            this.NamedProperties.Put("SourceFlags", "4225");
            this.NamedProperties.Put("ViewName", "COMPANY_FINANCE");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.frmCreateCompany_WindowActions);
            this.Controls.SetChildIndex(this.dfDummy, 0);
            this.Controls.SetChildIndex(this.dfDummy2, 0);
            this.Controls.SetChildIndex(this.dfDummy3, 0);
            this.Controls.SetChildIndex(this.dfCompany, 0);
            this.Controls.SetChildIndex(this.gbMax_Overwriting_Level_on_Tax, 0);
            this.Controls.SetChildIndex(this.gbDefault_Tax_Codes_for_Vertex_Sal, 0);
            this.Controls.SetChildIndex(this.picTab, 0);
            this.Controls.SetChildIndex(this.labeldfCurrencyCode, 0);
            this.Controls.SetChildIndex(this.labeldfsDistrictTaxCode, 0);
            this.Controls.SetChildIndex(this.labeldfsCountyTaxCode, 0);
            this.Controls.SetChildIndex(this.labeldfsStateTaxCode, 0);
            this.Controls.SetChildIndex(this.labeldfsCityTaxCode, 0);
            this.Controls.SetChildIndex(this.labeldfnLevelInAccCurrency, 0);
            this.Controls.SetChildIndex(this.labeldfnLevelInPercent, 0);
            this.Controls.SetChildIndex(this.labelcmbTaxRoundingMethod, 0);
            this.Controls.SetChildIndex(this.labeldfDefAmountMethod, 0);
            this.Controls.SetChildIndex(this.labelcmbPeriodClosingMethod, 0);
            this.Controls.SetChildIndex(this.labelcmbReverseVouCorrType, 0);
            this.Controls.SetChildIndex(this.labelcmbCorrectionType, 0);
            this.Controls.SetChildIndex(this.labeldfsTimeStamp, 0);
            this.Controls.SetChildIndex(this.labeldfParallelAccCurrency, 0);
            this.Controls.SetChildIndex(this.labeldfValidFrom, 0);
            this.Controls.SetChildIndex(this.labelpicTab, 0);
            this.Controls.SetChildIndex(this.cbUsePeriod, 0);
            this.Controls.SetChildIndex(this.cmbTaxRoundingMethod, 0);
            this.Controls.SetChildIndex(this.dfDefAmountMethod, 0);
            this.Controls.SetChildIndex(this.cmbPeriodClosingMethod, 0);
            this.Controls.SetChildIndex(this.cmbReverseVouCorrType, 0);
            this.Controls.SetChildIndex(this.cmbCorrectionType, 0);
            this.Controls.SetChildIndex(this.dfDescription, 0);
            this.Controls.SetChildIndex(this.dfCurrencyCode, 0);
            this.Controls.SetChildIndex(this.dfValidFrom, 0);
            this.Controls.SetChildIndex(this.dfParallelAccCurrency, 0);
            this.Controls.SetChildIndex(this.dfsTimeStamp, 0);
            this.Controls.SetChildIndex(this.dfnLevelInPercent, 0);
            this.Controls.SetChildIndex(this.dfnLevelInAccCurrency, 0);
            this.Controls.SetChildIndex(this.dfsCityTaxCode, 0);
            this.Controls.SetChildIndex(this.dfsStateTaxCode, 0);
            this.Controls.SetChildIndex(this.dfsCountyTaxCode, 0);
            this.Controls.SetChildIndex(this.dfsDistrictTaxCode, 0);
            this.Controls.SetChildIndex(this.dfsCreationFinished, 0);
            this.Controls.SetChildIndex(this.labelParallelBase, 0);
            this.Controls.SetChildIndex(this.labelParallelRateType, 0);
            this.Controls.SetChildIndex(this.dfsParallelRateType, 0);
            this.Controls.SetChildIndex(this.dfsParallelBase, 0);
            this.Controls.SetChildIndex(this.dfsParallelBaseDb, 0);
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

        protected cBackgroundText labelParallelBase;
        protected cDataField dfsParallelRateType;
        protected cBackgroundText labelParallelRateType;
        protected cDataField dfsParallelBase;
        protected cDataField dfsParallelBaseDb;
        protected Fnd.Windows.Forms.FndCommandManager commandManager;
	}
}
