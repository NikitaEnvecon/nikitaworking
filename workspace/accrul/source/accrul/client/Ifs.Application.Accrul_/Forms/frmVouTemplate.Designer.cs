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
	
	public partial class frmVouTemplate
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cDataField dfsCompany;
		protected cBackgroundText labelcmbTemplate;
		public cRecListDataField cmbTemplate;
		protected cBackgroundText labeldfsDescription;
		public cDataField dfsDescription;
		protected cBackgroundText labeldfdValidFrom;
		public cDataField dfdValidFrom;
		protected cBackgroundText labeldfdValidUntil;
		public cDataField dfdValidUntil;
		public cCheckBox cbCorrection;
		protected cBackgroundText labeldfCodePartDescription;
		public cDataField dfCodePartDescription;
		// Hidden Fields
		public cDataField dfnConvFactor;
		public cDataField dfsCurrencyType;
		public cDataField dfsCurrencyCode;
		public cDataField dfsDecimalsInRate;
		public cDataField dfsCurrencyRate;
		public cDataField dfnRowNo;
		protected cBackgroundText labeldfCodePartValue;
        public cDataFieldFinContent dfCodePartValue;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVouTemplate));
            this.menuTblMethods_menuChange__Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuOperations_menuChange__Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuFrmMethods_menuChange__Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.dfsCompany = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelcmbTemplate = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbTemplate = new Ifs.Fnd.ApplicationForms.cRecListDataField();
            this.labeldfsDescription = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsDescription = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfdValidFrom = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfdValidFrom = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfdValidUntil = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfdValidUntil = new Ifs.Fnd.ApplicationForms.cDataField();
            this.cbCorrection = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.labeldfCodePartDescription = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfCodePartDescription = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfnConvFactor = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsCurrencyType = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsCurrencyCode = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsDecimalsInRate = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsCurrencyRate = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfnRowNo = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfCodePartValue = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfCodePartValue = new Ifs.Application.Accrul.cDataFieldFinContent();
            this.menuFrmMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_Change = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuOperations = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_Change_1 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuTblMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_Change_2 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.tblVouTemplateRow = new Ifs.Application.Accrul.cChildTableFin();
            this.tblVouTemplateRow_colsCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVouTemplateRow_colsTemplate = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVouTemplateRow_colnRowNo = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVouTemplateRow_colsAccount = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.tblVouTemplateRow_colsAccountDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.tblVouTemplateRow_colsCodeB = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.tblVouTemplateRow_colsCodeBDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.tblVouTemplateRow_colsCodeC = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.tblVouTemplateRow_colsCodeCDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.tblVouTemplateRow_colsCodeD = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.tblVouTemplateRow_colsCodeDDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.tblVouTemplateRow_colsCodeE = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.tblVouTemplateRow_colsCodeEDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.tblVouTemplateRow_colsCodeF = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.tblVouTemplateRow_colsCodeFDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.tblVouTemplateRow_colsCodeG = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.tblVouTemplateRow_colsCodeGDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.tblVouTemplateRow_colsCodeH = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.tblVouTemplateRow_colsCodeHDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.tblVouTemplateRow_colsCodeI = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.tblVouTemplateRow_colsCodeIDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.tblVouTemplateRow_colsCodeJ = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.tblVouTemplateRow_colsCodeJDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.tblVouTemplateRow_colsProcessCodeP = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.tblVouTemplateRow_colsDeliveryTypeId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVouTemplateRow_colsDeliveryTypeDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVouTemplateRow_colsOptionalCode = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVouTemplateRow_colsCurrencyType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVouTemplateRow_colsCurrencyCode = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVouTemplateRow_colsCorrection = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.tblVouTemplateRow_colnDebitCurrencyAmount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVouTemplateRow_colnCreditCurrencyAmount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVouTemplateRow_colnCurrencyAmount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVouTemplateRow_colnCurrencyRate = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVouTemplateRow_colnConversionFactor = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVouTemplateRow_colnDebitAmount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVouTemplateRow_colnCreditAmount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVouTemplateRow_colnAmount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVouTemplateRow_colnQuantityQ = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.tblVouTemplateRow_colsTextT = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.tblVouTemplateRow_colsTransCode = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVouTemplateRow_colsCodePart = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVouTemplateRow_colsDecimalsInAmount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVouTemplateRow_colsAccDecimalsInAmount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVouTemplateRow_colsDecimalsInRate = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVouTemplateRow_colsCodeDemand = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVouTemplateRow_colsRateChanged = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVouTemplateRow_colnProjectActivityId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVouTemplateRow_colProjectActivityIdEnabled = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVouTemplateRow_colProjectId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVouTemplateRow_colsPrevAccount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVouTemplateRow_colsPrevTaxCode = new Ifs.Fnd.ApplicationForms.cColumn();
            this.menuFrmMethods.SuspendLayout();
            this.menuOperations.SuspendLayout();
            this.menuTblMethods.SuspendLayout();
            this.tblVouTemplateRow.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuFrmMethods_menuChange__Company___);
            this.commandManager.Commands.Add(this.menuOperations_menuChange__Company___);
            this.commandManager.Commands.Add(this.menuTblMethods_menuChange__Company___);
            this.commandManager.ContextMenus.Add(this.menuFrmMethods);
            this.commandManager.ContextMenus.Add(this.menuOperations);
            this.commandManager.ContextMenus.Add(this.menuTblMethods);
            // 
            // menuTblMethods_menuChange__Company___
            // 
            resources.ApplyResources(this.menuTblMethods_menuChange__Company___, "menuTblMethods_menuChange__Company___");
            this.menuTblMethods_menuChange__Company___.Name = "menuTblMethods_menuChange__Company___";
            this.menuTblMethods_menuChange__Company___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Change_2_Execute);
            this.menuTblMethods_menuChange__Company___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Change_2_Inquire);
            // 
            // menuOperations_menuChange__Company___
            // 
            resources.ApplyResources(this.menuOperations_menuChange__Company___, "menuOperations_menuChange__Company___");
            this.menuOperations_menuChange__Company___.Name = "menuOperations_menuChange__Company___";
            this.menuOperations_menuChange__Company___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Change_1_Execute);
            this.menuOperations_menuChange__Company___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Change_1_Inquire);
            // 
            // menuFrmMethods_menuChange__Company___
            // 
            resources.ApplyResources(this.menuFrmMethods_menuChange__Company___, "menuFrmMethods_menuChange__Company___");
            this.menuFrmMethods_menuChange__Company___.Name = "menuFrmMethods_menuChange__Company___";
            this.menuFrmMethods_menuChange__Company___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Change_Execute);
            this.menuFrmMethods_menuChange__Company___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Change_Inquire);
            // 
            // dfsCompany
            // 
            this.dfsCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsCompany, "dfsCompany");
            this.dfsCompany.Name = "dfsCompany";
            this.dfsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.dfsCompany.NamedProperties.Put("FieldFlags", "67");
            this.dfsCompany.NamedProperties.Put("LovReference", "COMPANY_FINANCE");
            this.dfsCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.dfsCompany.NamedProperties.Put("ValidateMethod", "");
            // 
            // labelcmbTemplate
            // 
            resources.ApplyResources(this.labelcmbTemplate, "labelcmbTemplate");
            this.labelcmbTemplate.Name = "labelcmbTemplate";
            // 
            // cmbTemplate
            // 
            this.cmbTemplate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.cmbTemplate, "cmbTemplate");
            this.cmbTemplate.Name = "cmbTemplate";
            this.cmbTemplate.NamedProperties.Put("EnumerateMethod", "");
            this.cmbTemplate.NamedProperties.Put("FieldFlags", "291");
            this.cmbTemplate.NamedProperties.Put("Format", "9");
            this.cmbTemplate.NamedProperties.Put("LovReference", "");
            this.cmbTemplate.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbTemplate.NamedProperties.Put("SqlColumn", "TEMPLATE");
            this.cmbTemplate.NamedProperties.Put("ValidateMethod", "");
            this.cmbTemplate.NamedProperties.Put("XDataLength", "10");
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
            this.dfsDescription.NamedProperties.Put("FieldFlags", "295");
            this.dfsDescription.NamedProperties.Put("LovReference", "");
            this.dfsDescription.NamedProperties.Put("ParentName", "cmbTemplate");
            this.dfsDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsDescription.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            this.dfsDescription.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfdValidFrom
            // 
            resources.ApplyResources(this.labeldfdValidFrom, "labeldfdValidFrom");
            this.labeldfdValidFrom.Name = "labeldfdValidFrom";
            // 
            // dfdValidFrom
            // 
            this.dfdValidFrom.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.dfdValidFrom.Format = "d";
            resources.ApplyResources(this.dfdValidFrom, "dfdValidFrom");
            this.dfdValidFrom.Name = "dfdValidFrom";
            this.dfdValidFrom.NamedProperties.Put("EnumerateMethod", "");
            this.dfdValidFrom.NamedProperties.Put("FieldFlags", "295");
            this.dfdValidFrom.NamedProperties.Put("LovReference", "");
            this.dfdValidFrom.NamedProperties.Put("ResizeableChildObject", "");
            this.dfdValidFrom.NamedProperties.Put("SqlColumn", "VALID_FROM");
            this.dfdValidFrom.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfdValidUntil
            // 
            resources.ApplyResources(this.labeldfdValidUntil, "labeldfdValidUntil");
            this.labeldfdValidUntil.Name = "labeldfdValidUntil";
            // 
            // dfdValidUntil
            // 
            this.dfdValidUntil.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.dfdValidUntil.Format = "d";
            resources.ApplyResources(this.dfdValidUntil, "dfdValidUntil");
            this.dfdValidUntil.Name = "dfdValidUntil";
            this.dfdValidUntil.NamedProperties.Put("EnumerateMethod", "");
            this.dfdValidUntil.NamedProperties.Put("FieldFlags", "295");
            this.dfdValidUntil.NamedProperties.Put("LovReference", "");
            this.dfdValidUntil.NamedProperties.Put("ResizeableChildObject", "");
            this.dfdValidUntil.NamedProperties.Put("SqlColumn", "VALID_UNTIL");
            this.dfdValidUntil.NamedProperties.Put("ValidateMethod", "");
            // 
            // cbCorrection
            // 
            resources.ApplyResources(this.cbCorrection, "cbCorrection");
            this.cbCorrection.Name = "cbCorrection";
            this.cbCorrection.NamedProperties.Put("EnumerateMethod", "");
            this.cbCorrection.NamedProperties.Put("FieldFlags", "262");
            this.cbCorrection.NamedProperties.Put("LovReference", "");
            this.cbCorrection.NamedProperties.Put("ResizeableChildObject", "");
            this.cbCorrection.NamedProperties.Put("SqlColumn", "CORRECTION");
            this.cbCorrection.NamedProperties.Put("ValidateMethod", "");
            this.cbCorrection.NamedProperties.Put("XDataLength", "Class Default");
            this.cbCorrection.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cbCorrection_WindowActions);
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
            // dfnConvFactor
            // 
            this.dfnConvFactor.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.dfnConvFactor.Name = "dfnConvFactor";
            this.dfnConvFactor.NamedProperties.Put("EnumerateMethod", "");
            this.dfnConvFactor.NamedProperties.Put("LovReference", "");
            this.dfnConvFactor.NamedProperties.Put("ResizeableChildObject", "");
            this.dfnConvFactor.NamedProperties.Put("SqlColumn", "CONVERSION_FACTOR");
            this.dfnConvFactor.NamedProperties.Put("ValidateMethod", "");
            resources.ApplyResources(this.dfnConvFactor, "dfnConvFactor");
            // 
            // dfsCurrencyType
            // 
            resources.ApplyResources(this.dfsCurrencyType, "dfsCurrencyType");
            this.dfsCurrencyType.Name = "dfsCurrencyType";
            this.dfsCurrencyType.NamedProperties.Put("EnumerateMethod", "");
            this.dfsCurrencyType.NamedProperties.Put("FieldFlags", "262");
            this.dfsCurrencyType.NamedProperties.Put("LovReference", "");
            this.dfsCurrencyType.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsCurrencyType.NamedProperties.Put("SqlColumn", "CURRENCY_TYPE");
            this.dfsCurrencyType.NamedProperties.Put("ValidateMethod", "");
            this.dfsCurrencyType.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsCurrencyType_WindowActions);
            // 
            // dfsCurrencyCode
            // 
            resources.ApplyResources(this.dfsCurrencyCode, "dfsCurrencyCode");
            this.dfsCurrencyCode.Name = "dfsCurrencyCode";
            this.dfsCurrencyCode.NamedProperties.Put("EnumerateMethod", "");
            this.dfsCurrencyCode.NamedProperties.Put("FieldFlags", "262");
            this.dfsCurrencyCode.NamedProperties.Put("LovReference", "");
            this.dfsCurrencyCode.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsCurrencyCode.NamedProperties.Put("SqlColumn", "CURRENCY_CODE");
            this.dfsCurrencyCode.NamedProperties.Put("ValidateMethod", "");
            // 
            // dfsDecimalsInRate
            // 
            this.dfsDecimalsInRate.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfsDecimalsInRate, "dfsDecimalsInRate");
            this.dfsDecimalsInRate.Name = "dfsDecimalsInRate";
            this.dfsDecimalsInRate.NamedProperties.Put("EnumerateMethod", "");
            this.dfsDecimalsInRate.NamedProperties.Put("FieldFlags", "262");
            this.dfsDecimalsInRate.NamedProperties.Put("LovReference", "");
            this.dfsDecimalsInRate.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsDecimalsInRate.NamedProperties.Put("SqlColumn", "DECIMALS_IN_RATE");
            this.dfsDecimalsInRate.NamedProperties.Put("ValidateMethod", "");
            // 
            // dfsCurrencyRate
            // 
            this.dfsCurrencyRate.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfsCurrencyRate, "dfsCurrencyRate");
            this.dfsCurrencyRate.Name = "dfsCurrencyRate";
            this.dfsCurrencyRate.NamedProperties.Put("EnumerateMethod", "");
            this.dfsCurrencyRate.NamedProperties.Put("FieldFlags", "262");
            this.dfsCurrencyRate.NamedProperties.Put("LovReference", "");
            this.dfsCurrencyRate.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsCurrencyRate.NamedProperties.Put("SqlColumn", "CURRENCY_RATE");
            this.dfsCurrencyRate.NamedProperties.Put("ValidateMethod", "");
            // 
            // dfnRowNo
            // 
            this.dfnRowNo.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfnRowNo, "dfnRowNo");
            this.dfnRowNo.Name = "dfnRowNo";
            this.dfnRowNo.NamedProperties.Put("EnumerateMethod", "");
            this.dfnRowNo.NamedProperties.Put("LovReference", "");
            this.dfnRowNo.NamedProperties.Put("ResizeableChildObject", "");
            this.dfnRowNo.NamedProperties.Put("SqlColumn", "VOUCHER_TEMPLATE_ROW_API.GET_MAX_ROW_NO(COMPANY,TEMPLATE)");
            this.dfnRowNo.NamedProperties.Put("ValidateMethod", "");
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
            // menuOperations
            // 
            this.menuOperations.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_Change_1});
            this.menuOperations.Name = "menuOperations";
            resources.ApplyResources(this.menuOperations, "menuOperations");
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
            this.menuItem_Change_2});
            this.menuTblMethods.Name = "menuTblMethods";
            resources.ApplyResources(this.menuTblMethods, "menuTblMethods");
            // 
            // menuItem_Change_2
            // 
            this.menuItem_Change_2.Command = this.menuTblMethods_menuChange__Company___;
            this.menuItem_Change_2.Name = "menuItem_Change_2";
            resources.ApplyResources(this.menuItem_Change_2, "menuItem_Change_2");
            this.menuItem_Change_2.Text = "Change &Company...";
            // 
            // tblVouTemplateRow
            // 
            this.tblVouTemplateRow.Controls.Add(this.tblVouTemplateRow_colsCompany);
            this.tblVouTemplateRow.Controls.Add(this.tblVouTemplateRow_colsTemplate);
            this.tblVouTemplateRow.Controls.Add(this.tblVouTemplateRow_colnRowNo);
            this.tblVouTemplateRow.Controls.Add(this.tblVouTemplateRow_colsAccount);
            this.tblVouTemplateRow.Controls.Add(this.tblVouTemplateRow_colsAccountDesc);
            this.tblVouTemplateRow.Controls.Add(this.tblVouTemplateRow_colsCodeB);
            this.tblVouTemplateRow.Controls.Add(this.tblVouTemplateRow_colsCodeBDesc);
            this.tblVouTemplateRow.Controls.Add(this.tblVouTemplateRow_colsCodeC);
            this.tblVouTemplateRow.Controls.Add(this.tblVouTemplateRow_colsCodeCDesc);
            this.tblVouTemplateRow.Controls.Add(this.tblVouTemplateRow_colsCodeD);
            this.tblVouTemplateRow.Controls.Add(this.tblVouTemplateRow_colsCodeDDesc);
            this.tblVouTemplateRow.Controls.Add(this.tblVouTemplateRow_colsCodeE);
            this.tblVouTemplateRow.Controls.Add(this.tblVouTemplateRow_colsCodeEDesc);
            this.tblVouTemplateRow.Controls.Add(this.tblVouTemplateRow_colsCodeF);
            this.tblVouTemplateRow.Controls.Add(this.tblVouTemplateRow_colsCodeFDesc);
            this.tblVouTemplateRow.Controls.Add(this.tblVouTemplateRow_colsCodeG);
            this.tblVouTemplateRow.Controls.Add(this.tblVouTemplateRow_colsCodeGDesc);
            this.tblVouTemplateRow.Controls.Add(this.tblVouTemplateRow_colsCodeH);
            this.tblVouTemplateRow.Controls.Add(this.tblVouTemplateRow_colsCodeHDesc);
            this.tblVouTemplateRow.Controls.Add(this.tblVouTemplateRow_colsCodeI);
            this.tblVouTemplateRow.Controls.Add(this.tblVouTemplateRow_colsCodeIDesc);
            this.tblVouTemplateRow.Controls.Add(this.tblVouTemplateRow_colsCodeJ);
            this.tblVouTemplateRow.Controls.Add(this.tblVouTemplateRow_colsCodeJDesc);
            this.tblVouTemplateRow.Controls.Add(this.tblVouTemplateRow_colsProcessCodeP);
            this.tblVouTemplateRow.Controls.Add(this.tblVouTemplateRow_colsDeliveryTypeId);
            this.tblVouTemplateRow.Controls.Add(this.tblVouTemplateRow_colsDeliveryTypeDescription);
            this.tblVouTemplateRow.Controls.Add(this.tblVouTemplateRow_colsOptionalCode);
            this.tblVouTemplateRow.Controls.Add(this.tblVouTemplateRow_colsCurrencyType);
            this.tblVouTemplateRow.Controls.Add(this.tblVouTemplateRow_colsCurrencyCode);
            this.tblVouTemplateRow.Controls.Add(this.tblVouTemplateRow_colsCorrection);
            this.tblVouTemplateRow.Controls.Add(this.tblVouTemplateRow_colnDebitCurrencyAmount);
            this.tblVouTemplateRow.Controls.Add(this.tblVouTemplateRow_colnCreditCurrencyAmount);
            this.tblVouTemplateRow.Controls.Add(this.tblVouTemplateRow_colnCurrencyAmount);
            this.tblVouTemplateRow.Controls.Add(this.tblVouTemplateRow_colnCurrencyRate);
            this.tblVouTemplateRow.Controls.Add(this.tblVouTemplateRow_colnConversionFactor);
            this.tblVouTemplateRow.Controls.Add(this.tblVouTemplateRow_colnDebitAmount);
            this.tblVouTemplateRow.Controls.Add(this.tblVouTemplateRow_colnCreditAmount);
            this.tblVouTemplateRow.Controls.Add(this.tblVouTemplateRow_colnAmount);
            this.tblVouTemplateRow.Controls.Add(this.tblVouTemplateRow_colnQuantityQ);
            this.tblVouTemplateRow.Controls.Add(this.tblVouTemplateRow_colsTextT);
            this.tblVouTemplateRow.Controls.Add(this.tblVouTemplateRow_colsTransCode);
            this.tblVouTemplateRow.Controls.Add(this.tblVouTemplateRow_colsCodePart);
            this.tblVouTemplateRow.Controls.Add(this.tblVouTemplateRow_colsDecimalsInAmount);
            this.tblVouTemplateRow.Controls.Add(this.tblVouTemplateRow_colsAccDecimalsInAmount);
            this.tblVouTemplateRow.Controls.Add(this.tblVouTemplateRow_colsDecimalsInRate);
            this.tblVouTemplateRow.Controls.Add(this.tblVouTemplateRow_colsCodeDemand);
            this.tblVouTemplateRow.Controls.Add(this.tblVouTemplateRow_colsRateChanged);
            this.tblVouTemplateRow.Controls.Add(this.tblVouTemplateRow_colnProjectActivityId);
            this.tblVouTemplateRow.Controls.Add(this.tblVouTemplateRow_colProjectActivityIdEnabled);
            this.tblVouTemplateRow.Controls.Add(this.tblVouTemplateRow_colProjectId);
            this.tblVouTemplateRow.Controls.Add(this.tblVouTemplateRow_colsPrevAccount);
            this.tblVouTemplateRow.Controls.Add(this.tblVouTemplateRow_colsPrevTaxCode);
            resources.ApplyResources(this.tblVouTemplateRow, "tblVouTemplateRow");
            this.tblVouTemplateRow.Name = "tblVouTemplateRow";
            this.tblVouTemplateRow.NamedProperties.Put("DefaultOrderBy", "");
            this.tblVouTemplateRow.NamedProperties.Put("DefaultWhere", "");
            this.tblVouTemplateRow.NamedProperties.Put("LogicalUnit", "VoucherTemplateRow");
            this.tblVouTemplateRow.NamedProperties.Put("PackageName", "VOUCHER_TEMPLATE_ROW_API");
            this.tblVouTemplateRow.NamedProperties.Put("ResizeableChildObject", "LLMM");
            this.tblVouTemplateRow.NamedProperties.Put("ViewName", "VOUCHER_TEMPLATE_ROW");
            this.tblVouTemplateRow.NamedProperties.Put("Warnings", "FALSE");
            this.tblVouTemplateRow.EnableDisableProjectActivityIdEvent += new System.EventHandler<Ifs.Application.Accrul.cChildTableFin.cChildTableFinEventArgs>(this.tblVouTemplateRow_EnableDisableProjectActivityIdEvent);
            this.tblVouTemplateRow.DataRecordGetDefaultsEvent += new System.EventHandler<Ifs.Fnd.ApplicationForms.FndReturnEventArgsSalBoolean>(this.tblVouTemplateRow_DataRecordGetDefaultsEvent);
            this.tblVouTemplateRow.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVouTemplateRow_WindowActions);
            this.tblVouTemplateRow.Controls.SetChildIndex(this.tblVouTemplateRow_colsPrevTaxCode, 0);
            this.tblVouTemplateRow.Controls.SetChildIndex(this.tblVouTemplateRow_colsPrevAccount, 0);
            this.tblVouTemplateRow.Controls.SetChildIndex(this.tblVouTemplateRow_colProjectId, 0);
            this.tblVouTemplateRow.Controls.SetChildIndex(this.tblVouTemplateRow_colProjectActivityIdEnabled, 0);
            this.tblVouTemplateRow.Controls.SetChildIndex(this.tblVouTemplateRow_colnProjectActivityId, 0);
            this.tblVouTemplateRow.Controls.SetChildIndex(this.tblVouTemplateRow_colsRateChanged, 0);
            this.tblVouTemplateRow.Controls.SetChildIndex(this.tblVouTemplateRow_colsCodeDemand, 0);
            this.tblVouTemplateRow.Controls.SetChildIndex(this.tblVouTemplateRow_colsDecimalsInRate, 0);
            this.tblVouTemplateRow.Controls.SetChildIndex(this.tblVouTemplateRow_colsAccDecimalsInAmount, 0);
            this.tblVouTemplateRow.Controls.SetChildIndex(this.tblVouTemplateRow_colsDecimalsInAmount, 0);
            this.tblVouTemplateRow.Controls.SetChildIndex(this.tblVouTemplateRow_colsCodePart, 0);
            this.tblVouTemplateRow.Controls.SetChildIndex(this.tblVouTemplateRow_colsTransCode, 0);
            this.tblVouTemplateRow.Controls.SetChildIndex(this.tblVouTemplateRow_colsTextT, 0);
            this.tblVouTemplateRow.Controls.SetChildIndex(this.tblVouTemplateRow_colnQuantityQ, 0);
            this.tblVouTemplateRow.Controls.SetChildIndex(this.tblVouTemplateRow_colnAmount, 0);
            this.tblVouTemplateRow.Controls.SetChildIndex(this.tblVouTemplateRow_colnCreditAmount, 0);
            this.tblVouTemplateRow.Controls.SetChildIndex(this.tblVouTemplateRow_colnDebitAmount, 0);
            this.tblVouTemplateRow.Controls.SetChildIndex(this.tblVouTemplateRow_colnConversionFactor, 0);
            this.tblVouTemplateRow.Controls.SetChildIndex(this.tblVouTemplateRow_colnCurrencyRate, 0);
            this.tblVouTemplateRow.Controls.SetChildIndex(this.tblVouTemplateRow_colnCurrencyAmount, 0);
            this.tblVouTemplateRow.Controls.SetChildIndex(this.tblVouTemplateRow_colnCreditCurrencyAmount, 0);
            this.tblVouTemplateRow.Controls.SetChildIndex(this.tblVouTemplateRow_colnDebitCurrencyAmount, 0);
            this.tblVouTemplateRow.Controls.SetChildIndex(this.tblVouTemplateRow_colsCorrection, 0);
            this.tblVouTemplateRow.Controls.SetChildIndex(this.tblVouTemplateRow_colsCurrencyCode, 0);
            this.tblVouTemplateRow.Controls.SetChildIndex(this.tblVouTemplateRow_colsCurrencyType, 0);
            this.tblVouTemplateRow.Controls.SetChildIndex(this.tblVouTemplateRow_colsOptionalCode, 0);
            this.tblVouTemplateRow.Controls.SetChildIndex(this.tblVouTemplateRow_colsDeliveryTypeDescription, 0);
            this.tblVouTemplateRow.Controls.SetChildIndex(this.tblVouTemplateRow_colsDeliveryTypeId, 0);
            this.tblVouTemplateRow.Controls.SetChildIndex(this.tblVouTemplateRow_colsProcessCodeP, 0);
            this.tblVouTemplateRow.Controls.SetChildIndex(this.tblVouTemplateRow_colsCodeJDesc, 0);
            this.tblVouTemplateRow.Controls.SetChildIndex(this.tblVouTemplateRow_colsCodeJ, 0);
            this.tblVouTemplateRow.Controls.SetChildIndex(this.tblVouTemplateRow_colsCodeIDesc, 0);
            this.tblVouTemplateRow.Controls.SetChildIndex(this.tblVouTemplateRow_colsCodeI, 0);
            this.tblVouTemplateRow.Controls.SetChildIndex(this.tblVouTemplateRow_colsCodeHDesc, 0);
            this.tblVouTemplateRow.Controls.SetChildIndex(this.tblVouTemplateRow_colsCodeH, 0);
            this.tblVouTemplateRow.Controls.SetChildIndex(this.tblVouTemplateRow_colsCodeGDesc, 0);
            this.tblVouTemplateRow.Controls.SetChildIndex(this.tblVouTemplateRow_colsCodeG, 0);
            this.tblVouTemplateRow.Controls.SetChildIndex(this.tblVouTemplateRow_colsCodeFDesc, 0);
            this.tblVouTemplateRow.Controls.SetChildIndex(this.tblVouTemplateRow_colsCodeF, 0);
            this.tblVouTemplateRow.Controls.SetChildIndex(this.tblVouTemplateRow_colsCodeEDesc, 0);
            this.tblVouTemplateRow.Controls.SetChildIndex(this.tblVouTemplateRow_colsCodeE, 0);
            this.tblVouTemplateRow.Controls.SetChildIndex(this.tblVouTemplateRow_colsCodeDDesc, 0);
            this.tblVouTemplateRow.Controls.SetChildIndex(this.tblVouTemplateRow_colsCodeD, 0);
            this.tblVouTemplateRow.Controls.SetChildIndex(this.tblVouTemplateRow_colsCodeCDesc, 0);
            this.tblVouTemplateRow.Controls.SetChildIndex(this.tblVouTemplateRow_colsCodeC, 0);
            this.tblVouTemplateRow.Controls.SetChildIndex(this.tblVouTemplateRow_colsCodeBDesc, 0);
            this.tblVouTemplateRow.Controls.SetChildIndex(this.tblVouTemplateRow_colsCodeB, 0);
            this.tblVouTemplateRow.Controls.SetChildIndex(this.tblVouTemplateRow_colsAccountDesc, 0);
            this.tblVouTemplateRow.Controls.SetChildIndex(this.tblVouTemplateRow_colsAccount, 0);
            this.tblVouTemplateRow.Controls.SetChildIndex(this.tblVouTemplateRow_colnRowNo, 0);
            this.tblVouTemplateRow.Controls.SetChildIndex(this.tblVouTemplateRow_colsTemplate, 0);
            this.tblVouTemplateRow.Controls.SetChildIndex(this.tblVouTemplateRow_colsCompany, 0);
            // 
            // tblVouTemplateRow_colsCompany
            // 
            this.tblVouTemplateRow_colsCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblVouTemplateRow_colsCompany, "tblVouTemplateRow_colsCompany");
            this.tblVouTemplateRow_colsCompany.MaxLength = 20;
            this.tblVouTemplateRow_colsCompany.Name = "tblVouTemplateRow_colsCompany";
            this.tblVouTemplateRow_colsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.tblVouTemplateRow_colsCompany.NamedProperties.Put("FieldFlags", "67");
            this.tblVouTemplateRow_colsCompany.NamedProperties.Put("LovReference", "");
            this.tblVouTemplateRow_colsCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVouTemplateRow_colsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.tblVouTemplateRow_colsCompany.NamedProperties.Put("ValidateMethod", "");
            this.tblVouTemplateRow_colsCompany.Position = 3;
            // 
            // tblVouTemplateRow_colsTemplate
            // 
            resources.ApplyResources(this.tblVouTemplateRow_colsTemplate, "tblVouTemplateRow_colsTemplate");
            this.tblVouTemplateRow_colsTemplate.MaxLength = 10;
            this.tblVouTemplateRow_colsTemplate.Name = "tblVouTemplateRow_colsTemplate";
            this.tblVouTemplateRow_colsTemplate.NamedProperties.Put("EnumerateMethod", "");
            this.tblVouTemplateRow_colsTemplate.NamedProperties.Put("FieldFlags", "67");
            this.tblVouTemplateRow_colsTemplate.NamedProperties.Put("LovReference", "VOUCHER_TEMPLATE(COMPANY)");
            this.tblVouTemplateRow_colsTemplate.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVouTemplateRow_colsTemplate.NamedProperties.Put("SqlColumn", "TEMPLATE");
            this.tblVouTemplateRow_colsTemplate.NamedProperties.Put("ValidateMethod", "");
            this.tblVouTemplateRow_colsTemplate.Position = 4;
            // 
            // tblVouTemplateRow_colnRowNo
            // 
            this.tblVouTemplateRow_colnRowNo.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVouTemplateRow_colnRowNo.Name = "tblVouTemplateRow_colnRowNo";
            this.tblVouTemplateRow_colnRowNo.NamedProperties.Put("EnumerateMethod", "");
            this.tblVouTemplateRow_colnRowNo.NamedProperties.Put("FieldFlags", "160");
            this.tblVouTemplateRow_colnRowNo.NamedProperties.Put("LovReference", "");
            this.tblVouTemplateRow_colnRowNo.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVouTemplateRow_colnRowNo.NamedProperties.Put("SqlColumn", "ROW_NO");
            this.tblVouTemplateRow_colnRowNo.NamedProperties.Put("ValidateMethod", "");
            this.tblVouTemplateRow_colnRowNo.Position = 5;
            resources.ApplyResources(this.tblVouTemplateRow_colnRowNo, "tblVouTemplateRow_colnRowNo");
            // 
            // tblVouTemplateRow_colsAccount
            // 
            this.tblVouTemplateRow_colsAccount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblVouTemplateRow_colsAccount.MaxLength = 20;
            this.tblVouTemplateRow_colsAccount.Name = "tblVouTemplateRow_colsAccount";
            this.tblVouTemplateRow_colsAccount.NamedProperties.Put("EnumerateMethod", "");
            this.tblVouTemplateRow_colsAccount.NamedProperties.Put("FieldFlags", "295");
            this.tblVouTemplateRow_colsAccount.NamedProperties.Put("LovReference", "PS_CODE_ACCOUNT(COMPANY)");
            this.tblVouTemplateRow_colsAccount.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVouTemplateRow_colsAccount.NamedProperties.Put("SqlColumn", "ACCOUNT");
            this.tblVouTemplateRow_colsAccount.NamedProperties.Put("ValidateMethod", "");
            this.tblVouTemplateRow_colsAccount.Position = 6;
            resources.ApplyResources(this.tblVouTemplateRow_colsAccount, "tblVouTemplateRow_colsAccount");
            this.tblVouTemplateRow_colsAccount.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVouTemplateRow_colsAccount_WindowActions);
            // 
            // tblVouTemplateRow_colsAccountDesc
            // 
            resources.ApplyResources(this.tblVouTemplateRow_colsAccountDesc, "tblVouTemplateRow_colsAccountDesc");
            this.tblVouTemplateRow_colsAccountDesc.Name = "tblVouTemplateRow_colsAccountDesc";
            this.tblVouTemplateRow_colsAccountDesc.NamedProperties.Put("EnumerateMethod", "");
            this.tblVouTemplateRow_colsAccountDesc.NamedProperties.Put("LovReference", "");
            this.tblVouTemplateRow_colsAccountDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVouTemplateRow_colsAccountDesc.NamedProperties.Put("SqlColumn", "ACCOUNT_DESC");
            this.tblVouTemplateRow_colsAccountDesc.NamedProperties.Put("ValidateMethod", "");
            this.tblVouTemplateRow_colsAccountDesc.Position = 7;
            // 
            // tblVouTemplateRow_colsCodeB
            // 
            this.tblVouTemplateRow_colsCodeB.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblVouTemplateRow_colsCodeB.MaxLength = 20;
            this.tblVouTemplateRow_colsCodeB.Name = "tblVouTemplateRow_colsCodeB";
            this.tblVouTemplateRow_colsCodeB.NamedProperties.Put("EnumerateMethod", "");
            this.tblVouTemplateRow_colsCodeB.NamedProperties.Put("FieldFlags", "294");
            this.tblVouTemplateRow_colsCodeB.NamedProperties.Put("LovReference", "CODE_B(COMPANY)");
            this.tblVouTemplateRow_colsCodeB.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVouTemplateRow_colsCodeB.NamedProperties.Put("SqlColumn", "CODE_B");
            this.tblVouTemplateRow_colsCodeB.NamedProperties.Put("ValidateMethod", "");
            this.tblVouTemplateRow_colsCodeB.Position = 8;
            resources.ApplyResources(this.tblVouTemplateRow_colsCodeB, "tblVouTemplateRow_colsCodeB");
            this.tblVouTemplateRow_colsCodeB.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVouTemplateRow_colsCodeB_WindowActions);
            // 
            // tblVouTemplateRow_colsCodeBDesc
            // 
            resources.ApplyResources(this.tblVouTemplateRow_colsCodeBDesc, "tblVouTemplateRow_colsCodeBDesc");
            this.tblVouTemplateRow_colsCodeBDesc.Name = "tblVouTemplateRow_colsCodeBDesc";
            this.tblVouTemplateRow_colsCodeBDesc.NamedProperties.Put("EnumerateMethod", "");
            this.tblVouTemplateRow_colsCodeBDesc.NamedProperties.Put("LovReference", "");
            this.tblVouTemplateRow_colsCodeBDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVouTemplateRow_colsCodeBDesc.NamedProperties.Put("SqlColumn", "CODE_B_DESC");
            this.tblVouTemplateRow_colsCodeBDesc.NamedProperties.Put("ValidateMethod", "");
            this.tblVouTemplateRow_colsCodeBDesc.Position = 9;
            // 
            // tblVouTemplateRow_colsCodeC
            // 
            this.tblVouTemplateRow_colsCodeC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblVouTemplateRow_colsCodeC.MaxLength = 20;
            this.tblVouTemplateRow_colsCodeC.Name = "tblVouTemplateRow_colsCodeC";
            this.tblVouTemplateRow_colsCodeC.NamedProperties.Put("EnumerateMethod", "");
            this.tblVouTemplateRow_colsCodeC.NamedProperties.Put("FieldFlags", "294");
            this.tblVouTemplateRow_colsCodeC.NamedProperties.Put("LovReference", "CODE_C(COMPANY)");
            this.tblVouTemplateRow_colsCodeC.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVouTemplateRow_colsCodeC.NamedProperties.Put("SqlColumn", "CODE_C");
            this.tblVouTemplateRow_colsCodeC.NamedProperties.Put("ValidateMethod", "");
            this.tblVouTemplateRow_colsCodeC.Position = 10;
            resources.ApplyResources(this.tblVouTemplateRow_colsCodeC, "tblVouTemplateRow_colsCodeC");
            this.tblVouTemplateRow_colsCodeC.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVouTemplateRow_colsCodeC_WindowActions);
            // 
            // tblVouTemplateRow_colsCodeCDesc
            // 
            resources.ApplyResources(this.tblVouTemplateRow_colsCodeCDesc, "tblVouTemplateRow_colsCodeCDesc");
            this.tblVouTemplateRow_colsCodeCDesc.Name = "tblVouTemplateRow_colsCodeCDesc";
            this.tblVouTemplateRow_colsCodeCDesc.NamedProperties.Put("EnumerateMethod", "");
            this.tblVouTemplateRow_colsCodeCDesc.NamedProperties.Put("LovReference", "");
            this.tblVouTemplateRow_colsCodeCDesc.NamedProperties.Put("SqlColumn", "CODE_C_DESC");
            this.tblVouTemplateRow_colsCodeCDesc.NamedProperties.Put("ValidateMethod", "");
            this.tblVouTemplateRow_colsCodeCDesc.Position = 11;
            // 
            // tblVouTemplateRow_colsCodeD
            // 
            this.tblVouTemplateRow_colsCodeD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblVouTemplateRow_colsCodeD.MaxLength = 20;
            this.tblVouTemplateRow_colsCodeD.Name = "tblVouTemplateRow_colsCodeD";
            this.tblVouTemplateRow_colsCodeD.NamedProperties.Put("EnumerateMethod", "");
            this.tblVouTemplateRow_colsCodeD.NamedProperties.Put("FieldFlags", "294");
            this.tblVouTemplateRow_colsCodeD.NamedProperties.Put("LovReference", "CODE_D(COMPANY)");
            this.tblVouTemplateRow_colsCodeD.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVouTemplateRow_colsCodeD.NamedProperties.Put("SqlColumn", "CODE_D");
            this.tblVouTemplateRow_colsCodeD.NamedProperties.Put("ValidateMethod", "");
            this.tblVouTemplateRow_colsCodeD.Position = 12;
            resources.ApplyResources(this.tblVouTemplateRow_colsCodeD, "tblVouTemplateRow_colsCodeD");
            this.tblVouTemplateRow_colsCodeD.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVouTemplateRow_colsCodeD_WindowActions);
            // 
            // tblVouTemplateRow_colsCodeDDesc
            // 
            resources.ApplyResources(this.tblVouTemplateRow_colsCodeDDesc, "tblVouTemplateRow_colsCodeDDesc");
            this.tblVouTemplateRow_colsCodeDDesc.Name = "tblVouTemplateRow_colsCodeDDesc";
            this.tblVouTemplateRow_colsCodeDDesc.NamedProperties.Put("EnumerateMethod", "");
            this.tblVouTemplateRow_colsCodeDDesc.NamedProperties.Put("LovReference", "");
            this.tblVouTemplateRow_colsCodeDDesc.NamedProperties.Put("SqlColumn", "CODE_D_DESC");
            this.tblVouTemplateRow_colsCodeDDesc.NamedProperties.Put("ValidateMethod", "");
            this.tblVouTemplateRow_colsCodeDDesc.Position = 13;
            // 
            // tblVouTemplateRow_colsCodeE
            // 
            this.tblVouTemplateRow_colsCodeE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblVouTemplateRow_colsCodeE.MaxLength = 20;
            this.tblVouTemplateRow_colsCodeE.Name = "tblVouTemplateRow_colsCodeE";
            this.tblVouTemplateRow_colsCodeE.NamedProperties.Put("EnumerateMethod", "");
            this.tblVouTemplateRow_colsCodeE.NamedProperties.Put("FieldFlags", "294");
            this.tblVouTemplateRow_colsCodeE.NamedProperties.Put("LovReference", "CODE_E(COMPANY)");
            this.tblVouTemplateRow_colsCodeE.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVouTemplateRow_colsCodeE.NamedProperties.Put("SqlColumn", "CODE_E");
            this.tblVouTemplateRow_colsCodeE.NamedProperties.Put("ValidateMethod", "");
            this.tblVouTemplateRow_colsCodeE.Position = 14;
            resources.ApplyResources(this.tblVouTemplateRow_colsCodeE, "tblVouTemplateRow_colsCodeE");
            this.tblVouTemplateRow_colsCodeE.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVouTemplateRow_colsCodeE_WindowActions);
            // 
            // tblVouTemplateRow_colsCodeEDesc
            // 
            resources.ApplyResources(this.tblVouTemplateRow_colsCodeEDesc, "tblVouTemplateRow_colsCodeEDesc");
            this.tblVouTemplateRow_colsCodeEDesc.Name = "tblVouTemplateRow_colsCodeEDesc";
            this.tblVouTemplateRow_colsCodeEDesc.NamedProperties.Put("EnumerateMethod", "");
            this.tblVouTemplateRow_colsCodeEDesc.NamedProperties.Put("LovReference", "");
            this.tblVouTemplateRow_colsCodeEDesc.NamedProperties.Put("SqlColumn", "CODE_E_DESC");
            this.tblVouTemplateRow_colsCodeEDesc.NamedProperties.Put("ValidateMethod", "");
            this.tblVouTemplateRow_colsCodeEDesc.Position = 15;
            // 
            // tblVouTemplateRow_colsCodeF
            // 
            this.tblVouTemplateRow_colsCodeF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblVouTemplateRow_colsCodeF.MaxLength = 20;
            this.tblVouTemplateRow_colsCodeF.Name = "tblVouTemplateRow_colsCodeF";
            this.tblVouTemplateRow_colsCodeF.NamedProperties.Put("EnumerateMethod", "");
            this.tblVouTemplateRow_colsCodeF.NamedProperties.Put("FieldFlags", "294");
            this.tblVouTemplateRow_colsCodeF.NamedProperties.Put("LovReference", "CODE_F(COMPANY)");
            this.tblVouTemplateRow_colsCodeF.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVouTemplateRow_colsCodeF.NamedProperties.Put("SqlColumn", "CODE_F");
            this.tblVouTemplateRow_colsCodeF.NamedProperties.Put("ValidateMethod", "");
            this.tblVouTemplateRow_colsCodeF.Position = 16;
            resources.ApplyResources(this.tblVouTemplateRow_colsCodeF, "tblVouTemplateRow_colsCodeF");
            this.tblVouTemplateRow_colsCodeF.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVouTemplateRow_colsCodeF_WindowActions);
            // 
            // tblVouTemplateRow_colsCodeFDesc
            // 
            resources.ApplyResources(this.tblVouTemplateRow_colsCodeFDesc, "tblVouTemplateRow_colsCodeFDesc");
            this.tblVouTemplateRow_colsCodeFDesc.Name = "tblVouTemplateRow_colsCodeFDesc";
            this.tblVouTemplateRow_colsCodeFDesc.NamedProperties.Put("EnumerateMethod", "");
            this.tblVouTemplateRow_colsCodeFDesc.NamedProperties.Put("LovReference", "");
            this.tblVouTemplateRow_colsCodeFDesc.NamedProperties.Put("SqlColumn", "CODE_F_DESC");
            this.tblVouTemplateRow_colsCodeFDesc.NamedProperties.Put("ValidateMethod", "");
            this.tblVouTemplateRow_colsCodeFDesc.Position = 17;
            // 
            // tblVouTemplateRow_colsCodeG
            // 
            this.tblVouTemplateRow_colsCodeG.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblVouTemplateRow_colsCodeG.MaxLength = 20;
            this.tblVouTemplateRow_colsCodeG.Name = "tblVouTemplateRow_colsCodeG";
            this.tblVouTemplateRow_colsCodeG.NamedProperties.Put("EnumerateMethod", "");
            this.tblVouTemplateRow_colsCodeG.NamedProperties.Put("FieldFlags", "262");
            this.tblVouTemplateRow_colsCodeG.NamedProperties.Put("LovReference", "CODE_G(COMPANY)");
            this.tblVouTemplateRow_colsCodeG.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVouTemplateRow_colsCodeG.NamedProperties.Put("SqlColumn", "CODE_G");
            this.tblVouTemplateRow_colsCodeG.NamedProperties.Put("ValidateMethod", "");
            this.tblVouTemplateRow_colsCodeG.Position = 18;
            resources.ApplyResources(this.tblVouTemplateRow_colsCodeG, "tblVouTemplateRow_colsCodeG");
            this.tblVouTemplateRow_colsCodeG.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVouTemplateRow_colsCodeG_WindowActions);
            // 
            // tblVouTemplateRow_colsCodeGDesc
            // 
            resources.ApplyResources(this.tblVouTemplateRow_colsCodeGDesc, "tblVouTemplateRow_colsCodeGDesc");
            this.tblVouTemplateRow_colsCodeGDesc.Name = "tblVouTemplateRow_colsCodeGDesc";
            this.tblVouTemplateRow_colsCodeGDesc.NamedProperties.Put("EnumerateMethod", "");
            this.tblVouTemplateRow_colsCodeGDesc.NamedProperties.Put("LovReference", "");
            this.tblVouTemplateRow_colsCodeGDesc.NamedProperties.Put("SqlColumn", "CODE_G_DESC");
            this.tblVouTemplateRow_colsCodeGDesc.NamedProperties.Put("ValidateMethod", "");
            this.tblVouTemplateRow_colsCodeGDesc.Position = 19;
            // 
            // tblVouTemplateRow_colsCodeH
            // 
            this.tblVouTemplateRow_colsCodeH.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblVouTemplateRow_colsCodeH.MaxLength = 20;
            this.tblVouTemplateRow_colsCodeH.Name = "tblVouTemplateRow_colsCodeH";
            this.tblVouTemplateRow_colsCodeH.NamedProperties.Put("EnumerateMethod", "");
            this.tblVouTemplateRow_colsCodeH.NamedProperties.Put("FieldFlags", "262");
            this.tblVouTemplateRow_colsCodeH.NamedProperties.Put("LovReference", "CODE_H(COMPANY)");
            this.tblVouTemplateRow_colsCodeH.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVouTemplateRow_colsCodeH.NamedProperties.Put("SqlColumn", "CODE_H");
            this.tblVouTemplateRow_colsCodeH.NamedProperties.Put("ValidateMethod", "");
            this.tblVouTemplateRow_colsCodeH.Position = 20;
            resources.ApplyResources(this.tblVouTemplateRow_colsCodeH, "tblVouTemplateRow_colsCodeH");
            this.tblVouTemplateRow_colsCodeH.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVouTemplateRow_colsCodeH_WindowActions);
            // 
            // tblVouTemplateRow_colsCodeHDesc
            // 
            resources.ApplyResources(this.tblVouTemplateRow_colsCodeHDesc, "tblVouTemplateRow_colsCodeHDesc");
            this.tblVouTemplateRow_colsCodeHDesc.Name = "tblVouTemplateRow_colsCodeHDesc";
            this.tblVouTemplateRow_colsCodeHDesc.NamedProperties.Put("EnumerateMethod", "");
            this.tblVouTemplateRow_colsCodeHDesc.NamedProperties.Put("LovReference", "");
            this.tblVouTemplateRow_colsCodeHDesc.NamedProperties.Put("SqlColumn", "CODE_H_DESC");
            this.tblVouTemplateRow_colsCodeHDesc.NamedProperties.Put("ValidateMethod", "");
            this.tblVouTemplateRow_colsCodeHDesc.Position = 21;
            // 
            // tblVouTemplateRow_colsCodeI
            // 
            this.tblVouTemplateRow_colsCodeI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblVouTemplateRow_colsCodeI.MaxLength = 20;
            this.tblVouTemplateRow_colsCodeI.Name = "tblVouTemplateRow_colsCodeI";
            this.tblVouTemplateRow_colsCodeI.NamedProperties.Put("EnumerateMethod", "");
            this.tblVouTemplateRow_colsCodeI.NamedProperties.Put("FieldFlags", "262");
            this.tblVouTemplateRow_colsCodeI.NamedProperties.Put("LovReference", "CODE_I(COMPANY)");
            this.tblVouTemplateRow_colsCodeI.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVouTemplateRow_colsCodeI.NamedProperties.Put("SqlColumn", "CODE_I");
            this.tblVouTemplateRow_colsCodeI.NamedProperties.Put("ValidateMethod", "");
            this.tblVouTemplateRow_colsCodeI.Position = 22;
            resources.ApplyResources(this.tblVouTemplateRow_colsCodeI, "tblVouTemplateRow_colsCodeI");
            this.tblVouTemplateRow_colsCodeI.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVouTemplateRow_colsCodeI_WindowActions);
            // 
            // tblVouTemplateRow_colsCodeIDesc
            // 
            resources.ApplyResources(this.tblVouTemplateRow_colsCodeIDesc, "tblVouTemplateRow_colsCodeIDesc");
            this.tblVouTemplateRow_colsCodeIDesc.Name = "tblVouTemplateRow_colsCodeIDesc";
            this.tblVouTemplateRow_colsCodeIDesc.NamedProperties.Put("EnumerateMethod", "");
            this.tblVouTemplateRow_colsCodeIDesc.NamedProperties.Put("LovReference", "");
            this.tblVouTemplateRow_colsCodeIDesc.NamedProperties.Put("SqlColumn", "CODE_I_DESC");
            this.tblVouTemplateRow_colsCodeIDesc.NamedProperties.Put("ValidateMethod", "");
            this.tblVouTemplateRow_colsCodeIDesc.Position = 23;
            // 
            // tblVouTemplateRow_colsCodeJ
            // 
            this.tblVouTemplateRow_colsCodeJ.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblVouTemplateRow_colsCodeJ.MaxLength = 20;
            this.tblVouTemplateRow_colsCodeJ.Name = "tblVouTemplateRow_colsCodeJ";
            this.tblVouTemplateRow_colsCodeJ.NamedProperties.Put("EnumerateMethod", "");
            this.tblVouTemplateRow_colsCodeJ.NamedProperties.Put("FieldFlags", "262");
            this.tblVouTemplateRow_colsCodeJ.NamedProperties.Put("LovReference", "CODE_J(COMPANY)");
            this.tblVouTemplateRow_colsCodeJ.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVouTemplateRow_colsCodeJ.NamedProperties.Put("SqlColumn", "CODE_J");
            this.tblVouTemplateRow_colsCodeJ.NamedProperties.Put("ValidateMethod", "");
            this.tblVouTemplateRow_colsCodeJ.Position = 24;
            resources.ApplyResources(this.tblVouTemplateRow_colsCodeJ, "tblVouTemplateRow_colsCodeJ");
            this.tblVouTemplateRow_colsCodeJ.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVouTemplateRow_colsCodeJ_WindowActions);
            // 
            // tblVouTemplateRow_colsCodeJDesc
            // 
            resources.ApplyResources(this.tblVouTemplateRow_colsCodeJDesc, "tblVouTemplateRow_colsCodeJDesc");
            this.tblVouTemplateRow_colsCodeJDesc.Name = "tblVouTemplateRow_colsCodeJDesc";
            this.tblVouTemplateRow_colsCodeJDesc.NamedProperties.Put("EnumerateMethod", "");
            this.tblVouTemplateRow_colsCodeJDesc.NamedProperties.Put("LovReference", "");
            this.tblVouTemplateRow_colsCodeJDesc.NamedProperties.Put("SqlColumn", "CODE_J_DESC");
            this.tblVouTemplateRow_colsCodeJDesc.NamedProperties.Put("ValidateMethod", "");
            this.tblVouTemplateRow_colsCodeJDesc.Position = 25;
            // 
            // tblVouTemplateRow_colsProcessCodeP
            // 
            this.tblVouTemplateRow_colsProcessCodeP.Name = "tblVouTemplateRow_colsProcessCodeP";
            this.tblVouTemplateRow_colsProcessCodeP.NamedProperties.Put("EnumerateMethod", "");
            this.tblVouTemplateRow_colsProcessCodeP.NamedProperties.Put("FieldFlags", "294");
            this.tblVouTemplateRow_colsProcessCodeP.NamedProperties.Put("LovReference", "ACCOUNT_PROCESS_CODE(COMPANY)");
            this.tblVouTemplateRow_colsProcessCodeP.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVouTemplateRow_colsProcessCodeP.NamedProperties.Put("SqlColumn", "PROCESS_CODE");
            this.tblVouTemplateRow_colsProcessCodeP.NamedProperties.Put("ValidateMethod", "");
            this.tblVouTemplateRow_colsProcessCodeP.Position = 26;
            resources.ApplyResources(this.tblVouTemplateRow_colsProcessCodeP, "tblVouTemplateRow_colsProcessCodeP");
            this.tblVouTemplateRow_colsProcessCodeP.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVouTemplateRow_colsProcessCodeP_WindowActions);
            // 
            // tblVouTemplateRow_colsDeliveryTypeId
            // 
            this.tblVouTemplateRow_colsDeliveryTypeId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblVouTemplateRow_colsDeliveryTypeId.MaxLength = 20;
            this.tblVouTemplateRow_colsDeliveryTypeId.Name = "tblVouTemplateRow_colsDeliveryTypeId";
            this.tblVouTemplateRow_colsDeliveryTypeId.NamedProperties.Put("EnumerateMethod", "");
            this.tblVouTemplateRow_colsDeliveryTypeId.NamedProperties.Put("FieldFlags", "294");
            this.tblVouTemplateRow_colsDeliveryTypeId.NamedProperties.Put("LovReference", "DELIVERY_TYPE(COMPANY)");
            this.tblVouTemplateRow_colsDeliveryTypeId.NamedProperties.Put("SqlColumn", "DELIV_TYPE_ID");
            this.tblVouTemplateRow_colsDeliveryTypeId.Position = 27;
            resources.ApplyResources(this.tblVouTemplateRow_colsDeliveryTypeId, "tblVouTemplateRow_colsDeliveryTypeId");
            this.tblVouTemplateRow_colsDeliveryTypeId.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVouTemplateRow_colsDeliveryTypeId_WindowActions);
            // 
            // tblVouTemplateRow_colsDeliveryTypeDescription
            // 
            this.tblVouTemplateRow_colsDeliveryTypeDescription.MaxLength = 2000;
            this.tblVouTemplateRow_colsDeliveryTypeDescription.Name = "tblVouTemplateRow_colsDeliveryTypeDescription";
            this.tblVouTemplateRow_colsDeliveryTypeDescription.NamedProperties.Put("EnumerateMethod", "");
            this.tblVouTemplateRow_colsDeliveryTypeDescription.NamedProperties.Put("FieldFlags", "288");
            this.tblVouTemplateRow_colsDeliveryTypeDescription.NamedProperties.Put("LovReference", "");
            this.tblVouTemplateRow_colsDeliveryTypeDescription.NamedProperties.Put("SqlColumn", "DELIVERY_TYPE_DESC");
            this.tblVouTemplateRow_colsDeliveryTypeDescription.Position = 28;
            resources.ApplyResources(this.tblVouTemplateRow_colsDeliveryTypeDescription, "tblVouTemplateRow_colsDeliveryTypeDescription");
            // 
            // tblVouTemplateRow_colsOptionalCode
            // 
            this.tblVouTemplateRow_colsOptionalCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblVouTemplateRow_colsOptionalCode.MaxLength = 20;
            this.tblVouTemplateRow_colsOptionalCode.Name = "tblVouTemplateRow_colsOptionalCode";
            this.tblVouTemplateRow_colsOptionalCode.NamedProperties.Put("EnumerateMethod", "");
            this.tblVouTemplateRow_colsOptionalCode.NamedProperties.Put("FieldFlags", "294");
            this.tblVouTemplateRow_colsOptionalCode.NamedProperties.Put("LovReference", "STATUTORY_FEE_DEDUCT_MULTIPLE(COMPANY)");
            this.tblVouTemplateRow_colsOptionalCode.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVouTemplateRow_colsOptionalCode.NamedProperties.Put("SqlColumn", "OPTIONAL_CODE");
            this.tblVouTemplateRow_colsOptionalCode.NamedProperties.Put("ValidateMethod", "");
            this.tblVouTemplateRow_colsOptionalCode.Position = 29;
            resources.ApplyResources(this.tblVouTemplateRow_colsOptionalCode, "tblVouTemplateRow_colsOptionalCode");
            this.tblVouTemplateRow_colsOptionalCode.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVouTemplateRow_colsOptionalCode_WindowActions);
            // 
            // tblVouTemplateRow_colsCurrencyType
            // 
            resources.ApplyResources(this.tblVouTemplateRow_colsCurrencyType, "tblVouTemplateRow_colsCurrencyType");
            this.tblVouTemplateRow_colsCurrencyType.Name = "tblVouTemplateRow_colsCurrencyType";
            this.tblVouTemplateRow_colsCurrencyType.NamedProperties.Put("EnumerateMethod", "");
            this.tblVouTemplateRow_colsCurrencyType.NamedProperties.Put("FieldFlags", "262");
            this.tblVouTemplateRow_colsCurrencyType.NamedProperties.Put("LovReference", "");
            this.tblVouTemplateRow_colsCurrencyType.NamedProperties.Put("SqlColumn", "CURRENCY_TYPE");
            this.tblVouTemplateRow_colsCurrencyType.NamedProperties.Put("ValidateMethod", "");
            this.tblVouTemplateRow_colsCurrencyType.Position = 30;
            // 
            // tblVouTemplateRow_colsCurrencyCode
            // 
            this.tblVouTemplateRow_colsCurrencyCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblVouTemplateRow_colsCurrencyCode.MaxLength = 3;
            this.tblVouTemplateRow_colsCurrencyCode.Name = "tblVouTemplateRow_colsCurrencyCode";
            this.tblVouTemplateRow_colsCurrencyCode.NamedProperties.Put("EnumerateMethod", "");
            this.tblVouTemplateRow_colsCurrencyCode.NamedProperties.Put("FieldFlags", "294");
            this.tblVouTemplateRow_colsCurrencyCode.NamedProperties.Put("LovReference", "CURRENCY_CODE(COMPANY)");
            this.tblVouTemplateRow_colsCurrencyCode.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVouTemplateRow_colsCurrencyCode.NamedProperties.Put("SqlColumn", "CURRENCY_CODE");
            this.tblVouTemplateRow_colsCurrencyCode.NamedProperties.Put("ValidateMethod", "");
            this.tblVouTemplateRow_colsCurrencyCode.Position = 31;
            resources.ApplyResources(this.tblVouTemplateRow_colsCurrencyCode, "tblVouTemplateRow_colsCurrencyCode");
            this.tblVouTemplateRow_colsCurrencyCode.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVouTemplateRow_colsCurrencyCode_WindowActions);
            // 
            // tblVouTemplateRow_colsCorrection
            // 
            this.tblVouTemplateRow_colsCorrection.CheckBox.CheckedValue = "Y";
            this.tblVouTemplateRow_colsCorrection.CheckBox.IgnoreCase = true;
            this.tblVouTemplateRow_colsCorrection.CheckBox.UncheckedValue = "N";
            this.tblVouTemplateRow_colsCorrection.Name = "tblVouTemplateRow_colsCorrection";
            this.tblVouTemplateRow_colsCorrection.NamedProperties.Put("EnumerateMethod", "");
            this.tblVouTemplateRow_colsCorrection.NamedProperties.Put("FieldFlags", "290");
            this.tblVouTemplateRow_colsCorrection.NamedProperties.Put("LovReference", "");
            this.tblVouTemplateRow_colsCorrection.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVouTemplateRow_colsCorrection.NamedProperties.Put("SqlColumn", "CORRECTION");
            this.tblVouTemplateRow_colsCorrection.NamedProperties.Put("ValidateMethod", "");
            this.tblVouTemplateRow_colsCorrection.Position = 32;
            resources.ApplyResources(this.tblVouTemplateRow_colsCorrection, "tblVouTemplateRow_colsCorrection");
            // 
            // tblVouTemplateRow_colnDebitCurrencyAmount
            // 
            this.tblVouTemplateRow_colnDebitCurrencyAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVouTemplateRow_colnDebitCurrencyAmount.Name = "tblVouTemplateRow_colnDebitCurrencyAmount";
            this.tblVouTemplateRow_colnDebitCurrencyAmount.NamedProperties.Put("EnumerateMethod", "");
            this.tblVouTemplateRow_colnDebitCurrencyAmount.NamedProperties.Put("FieldFlags", "294");
            this.tblVouTemplateRow_colnDebitCurrencyAmount.NamedProperties.Put("Format", "20");
            this.tblVouTemplateRow_colnDebitCurrencyAmount.NamedProperties.Put("LovReference", "");
            this.tblVouTemplateRow_colnDebitCurrencyAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVouTemplateRow_colnDebitCurrencyAmount.NamedProperties.Put("SqlColumn", "DEBIT_CURRENCY_AMOUNT");
            this.tblVouTemplateRow_colnDebitCurrencyAmount.NamedProperties.Put("ValidateMethod", "");
            this.tblVouTemplateRow_colnDebitCurrencyAmount.Position = 33;
            this.tblVouTemplateRow_colnDebitCurrencyAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblVouTemplateRow_colnDebitCurrencyAmount, "tblVouTemplateRow_colnDebitCurrencyAmount");
            this.tblVouTemplateRow_colnDebitCurrencyAmount.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVouTemplateRow_colnDebitCurrencyAmount_WindowActions);
            // 
            // tblVouTemplateRow_colnCreditCurrencyAmount
            // 
            this.tblVouTemplateRow_colnCreditCurrencyAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVouTemplateRow_colnCreditCurrencyAmount.Name = "tblVouTemplateRow_colnCreditCurrencyAmount";
            this.tblVouTemplateRow_colnCreditCurrencyAmount.NamedProperties.Put("EnumerateMethod", "");
            this.tblVouTemplateRow_colnCreditCurrencyAmount.NamedProperties.Put("FieldFlags", "294");
            this.tblVouTemplateRow_colnCreditCurrencyAmount.NamedProperties.Put("Format", "20");
            this.tblVouTemplateRow_colnCreditCurrencyAmount.NamedProperties.Put("LovReference", "");
            this.tblVouTemplateRow_colnCreditCurrencyAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVouTemplateRow_colnCreditCurrencyAmount.NamedProperties.Put("SqlColumn", "CREDIT_CURRENCY_AMOUNT");
            this.tblVouTemplateRow_colnCreditCurrencyAmount.NamedProperties.Put("ValidateMethod", "");
            this.tblVouTemplateRow_colnCreditCurrencyAmount.Position = 34;
            this.tblVouTemplateRow_colnCreditCurrencyAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblVouTemplateRow_colnCreditCurrencyAmount, "tblVouTemplateRow_colnCreditCurrencyAmount");
            this.tblVouTemplateRow_colnCreditCurrencyAmount.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVouTemplateRow_colnCreditCurrencyAmount_WindowActions);
            // 
            // tblVouTemplateRow_colnCurrencyAmount
            // 
            this.tblVouTemplateRow_colnCurrencyAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVouTemplateRow_colnCurrencyAmount.Name = "tblVouTemplateRow_colnCurrencyAmount";
            this.tblVouTemplateRow_colnCurrencyAmount.NamedProperties.Put("EnumerateMethod", "");
            this.tblVouTemplateRow_colnCurrencyAmount.NamedProperties.Put("FieldFlags", "294");
            this.tblVouTemplateRow_colnCurrencyAmount.NamedProperties.Put("Format", "20");
            this.tblVouTemplateRow_colnCurrencyAmount.NamedProperties.Put("LovReference", "");
            this.tblVouTemplateRow_colnCurrencyAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVouTemplateRow_colnCurrencyAmount.NamedProperties.Put("SqlColumn", "CURRENCY_AMOUNT");
            this.tblVouTemplateRow_colnCurrencyAmount.NamedProperties.Put("ValidateMethod", "");
            this.tblVouTemplateRow_colnCurrencyAmount.Position = 35;
            this.tblVouTemplateRow_colnCurrencyAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblVouTemplateRow_colnCurrencyAmount, "tblVouTemplateRow_colnCurrencyAmount");
            this.tblVouTemplateRow_colnCurrencyAmount.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVouTemplateRow_colnCurrencyAmount_WindowActions);
            // 
            // tblVouTemplateRow_colnCurrencyRate
            // 
            this.tblVouTemplateRow_colnCurrencyRate.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVouTemplateRow_colnCurrencyRate.Name = "tblVouTemplateRow_colnCurrencyRate";
            this.tblVouTemplateRow_colnCurrencyRate.NamedProperties.Put("EnumerateMethod", "");
            this.tblVouTemplateRow_colnCurrencyRate.NamedProperties.Put("FieldFlags", "294");
            this.tblVouTemplateRow_colnCurrencyRate.NamedProperties.Put("LovReference", "");
            this.tblVouTemplateRow_colnCurrencyRate.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVouTemplateRow_colnCurrencyRate.NamedProperties.Put("SqlColumn", "CURRENCY_RATE");
            this.tblVouTemplateRow_colnCurrencyRate.NamedProperties.Put("ValidateMethod", "");
            this.tblVouTemplateRow_colnCurrencyRate.Position = 36;
            this.tblVouTemplateRow_colnCurrencyRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblVouTemplateRow_colnCurrencyRate, "tblVouTemplateRow_colnCurrencyRate");
            this.tblVouTemplateRow_colnCurrencyRate.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVouTemplateRow_colnCurrencyRate_WindowActions);
            // 
            // tblVouTemplateRow_colnConversionFactor
            // 
            this.tblVouTemplateRow_colnConversionFactor.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVouTemplateRow_colnConversionFactor.Name = "tblVouTemplateRow_colnConversionFactor";
            this.tblVouTemplateRow_colnConversionFactor.NamedProperties.Put("EnumerateMethod", "");
            this.tblVouTemplateRow_colnConversionFactor.NamedProperties.Put("FieldFlags", "288");
            this.tblVouTemplateRow_colnConversionFactor.NamedProperties.Put("LovReference", "");
            this.tblVouTemplateRow_colnConversionFactor.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVouTemplateRow_colnConversionFactor.NamedProperties.Put("SqlColumn", "CONV_FACTOR");
            this.tblVouTemplateRow_colnConversionFactor.NamedProperties.Put("ValidateMethod", "");
            this.tblVouTemplateRow_colnConversionFactor.Position = 37;
            this.tblVouTemplateRow_colnConversionFactor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblVouTemplateRow_colnConversionFactor, "tblVouTemplateRow_colnConversionFactor");
            // 
            // tblVouTemplateRow_colnDebitAmount
            // 
            this.tblVouTemplateRow_colnDebitAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVouTemplateRow_colnDebitAmount.Name = "tblVouTemplateRow_colnDebitAmount";
            this.tblVouTemplateRow_colnDebitAmount.NamedProperties.Put("EnumerateMethod", "");
            this.tblVouTemplateRow_colnDebitAmount.NamedProperties.Put("FieldFlags", "294");
            this.tblVouTemplateRow_colnDebitAmount.NamedProperties.Put("Format", "20");
            this.tblVouTemplateRow_colnDebitAmount.NamedProperties.Put("LovReference", "");
            this.tblVouTemplateRow_colnDebitAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVouTemplateRow_colnDebitAmount.NamedProperties.Put("SqlColumn", "DEBIT_AMOUNT");
            this.tblVouTemplateRow_colnDebitAmount.NamedProperties.Put("ValidateMethod", "");
            this.tblVouTemplateRow_colnDebitAmount.Position = 38;
            this.tblVouTemplateRow_colnDebitAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblVouTemplateRow_colnDebitAmount, "tblVouTemplateRow_colnDebitAmount");
            this.tblVouTemplateRow_colnDebitAmount.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVouTemplateRow_colnDebitAmount_WindowActions);
            // 
            // tblVouTemplateRow_colnCreditAmount
            // 
            this.tblVouTemplateRow_colnCreditAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVouTemplateRow_colnCreditAmount.Name = "tblVouTemplateRow_colnCreditAmount";
            this.tblVouTemplateRow_colnCreditAmount.NamedProperties.Put("EnumerateMethod", "");
            this.tblVouTemplateRow_colnCreditAmount.NamedProperties.Put("FieldFlags", "294");
            this.tblVouTemplateRow_colnCreditAmount.NamedProperties.Put("Format", "20");
            this.tblVouTemplateRow_colnCreditAmount.NamedProperties.Put("LovReference", "");
            this.tblVouTemplateRow_colnCreditAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVouTemplateRow_colnCreditAmount.NamedProperties.Put("SqlColumn", "CREDIT_AMOUNT");
            this.tblVouTemplateRow_colnCreditAmount.NamedProperties.Put("ValidateMethod", "");
            this.tblVouTemplateRow_colnCreditAmount.Position = 39;
            this.tblVouTemplateRow_colnCreditAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblVouTemplateRow_colnCreditAmount, "tblVouTemplateRow_colnCreditAmount");
            this.tblVouTemplateRow_colnCreditAmount.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVouTemplateRow_colnCreditAmount_WindowActions);
            // 
            // tblVouTemplateRow_colnAmount
            // 
            this.tblVouTemplateRow_colnAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVouTemplateRow_colnAmount.Name = "tblVouTemplateRow_colnAmount";
            this.tblVouTemplateRow_colnAmount.NamedProperties.Put("EnumerateMethod", "");
            this.tblVouTemplateRow_colnAmount.NamedProperties.Put("FieldFlags", "294");
            this.tblVouTemplateRow_colnAmount.NamedProperties.Put("Format", "20");
            this.tblVouTemplateRow_colnAmount.NamedProperties.Put("LovReference", "");
            this.tblVouTemplateRow_colnAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVouTemplateRow_colnAmount.NamedProperties.Put("SqlColumn", "AMOUNT");
            this.tblVouTemplateRow_colnAmount.NamedProperties.Put("ValidateMethod", "");
            this.tblVouTemplateRow_colnAmount.Position = 40;
            this.tblVouTemplateRow_colnAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblVouTemplateRow_colnAmount, "tblVouTemplateRow_colnAmount");
            this.tblVouTemplateRow_colnAmount.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVouTemplateRow_colnAmount_WindowActions);
            // 
            // tblVouTemplateRow_colnQuantityQ
            // 
            this.tblVouTemplateRow_colnQuantityQ.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVouTemplateRow_colnQuantityQ.Name = "tblVouTemplateRow_colnQuantityQ";
            this.tblVouTemplateRow_colnQuantityQ.NamedProperties.Put("EnumerateMethod", "");
            this.tblVouTemplateRow_colnQuantityQ.NamedProperties.Put("FieldFlags", "294");
            this.tblVouTemplateRow_colnQuantityQ.NamedProperties.Put("LovReference", "");
            this.tblVouTemplateRow_colnQuantityQ.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVouTemplateRow_colnQuantityQ.NamedProperties.Put("SqlColumn", "QUANTITY");
            this.tblVouTemplateRow_colnQuantityQ.NamedProperties.Put("ValidateMethod", "");
            this.tblVouTemplateRow_colnQuantityQ.Position = 41;
            this.tblVouTemplateRow_colnQuantityQ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblVouTemplateRow_colnQuantityQ, "tblVouTemplateRow_colnQuantityQ");
            this.tblVouTemplateRow_colnQuantityQ.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVouTemplateRow_colnQuantityQ_WindowActions);
            // 
            // tblVouTemplateRow_colsTextT
            // 
            this.tblVouTemplateRow_colsTextT.MaxLength = 200;
            this.tblVouTemplateRow_colsTextT.Name = "tblVouTemplateRow_colsTextT";
            this.tblVouTemplateRow_colsTextT.NamedProperties.Put("EnumerateMethod", "");
            this.tblVouTemplateRow_colsTextT.NamedProperties.Put("FieldFlags", "294");
            this.tblVouTemplateRow_colsTextT.NamedProperties.Put("LovReference", "");
            this.tblVouTemplateRow_colsTextT.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVouTemplateRow_colsTextT.NamedProperties.Put("SqlColumn", "TEXT");
            this.tblVouTemplateRow_colsTextT.NamedProperties.Put("ValidateMethod", "");
            this.tblVouTemplateRow_colsTextT.Position = 42;
            resources.ApplyResources(this.tblVouTemplateRow_colsTextT, "tblVouTemplateRow_colsTextT");
            this.tblVouTemplateRow_colsTextT.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVouTemplateRow_colsTextT_WindowActions);
            // 
            // tblVouTemplateRow_colsTransCode
            // 
            this.tblVouTemplateRow_colsTransCode.Name = "tblVouTemplateRow_colsTransCode";
            this.tblVouTemplateRow_colsTransCode.NamedProperties.Put("EnumerateMethod", "");
            this.tblVouTemplateRow_colsTransCode.NamedProperties.Put("FieldFlags", "288");
            this.tblVouTemplateRow_colsTransCode.NamedProperties.Put("LovReference", "");
            this.tblVouTemplateRow_colsTransCode.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVouTemplateRow_colsTransCode.NamedProperties.Put("SqlColumn", "TRANS_CODE");
            this.tblVouTemplateRow_colsTransCode.NamedProperties.Put("ValidateMethod", "");
            this.tblVouTemplateRow_colsTransCode.Position = 43;
            resources.ApplyResources(this.tblVouTemplateRow_colsTransCode, "tblVouTemplateRow_colsTransCode");
            // 
            // tblVouTemplateRow_colsCodePart
            // 
            resources.ApplyResources(this.tblVouTemplateRow_colsCodePart, "tblVouTemplateRow_colsCodePart");
            this.tblVouTemplateRow_colsCodePart.MaxLength = 1;
            this.tblVouTemplateRow_colsCodePart.Name = "tblVouTemplateRow_colsCodePart";
            this.tblVouTemplateRow_colsCodePart.NamedProperties.Put("EnumerateMethod", "");
            this.tblVouTemplateRow_colsCodePart.NamedProperties.Put("LovReference", "");
            this.tblVouTemplateRow_colsCodePart.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVouTemplateRow_colsCodePart.NamedProperties.Put("SqlColumn", "CODE_PART");
            this.tblVouTemplateRow_colsCodePart.NamedProperties.Put("ValidateMethod", "");
            this.tblVouTemplateRow_colsCodePart.Position = 44;
            this.tblVouTemplateRow_colsCodePart.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVouTemplateRow_colsCodePart_WindowActions);
            // 
            // tblVouTemplateRow_colsDecimalsInAmount
            // 
            this.tblVouTemplateRow_colsDecimalsInAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.tblVouTemplateRow_colsDecimalsInAmount, "tblVouTemplateRow_colsDecimalsInAmount");
            this.tblVouTemplateRow_colsDecimalsInAmount.Name = "tblVouTemplateRow_colsDecimalsInAmount";
            this.tblVouTemplateRow_colsDecimalsInAmount.NamedProperties.Put("EnumerateMethod", "");
            this.tblVouTemplateRow_colsDecimalsInAmount.NamedProperties.Put("FieldFlags", "262");
            this.tblVouTemplateRow_colsDecimalsInAmount.NamedProperties.Put("LovReference", "");
            this.tblVouTemplateRow_colsDecimalsInAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVouTemplateRow_colsDecimalsInAmount.NamedProperties.Put("SqlColumn", "DECIMALS_IN_AMOUNT");
            this.tblVouTemplateRow_colsDecimalsInAmount.NamedProperties.Put("ValidateMethod", "");
            this.tblVouTemplateRow_colsDecimalsInAmount.Position = 45;
            // 
            // tblVouTemplateRow_colsAccDecimalsInAmount
            // 
            this.tblVouTemplateRow_colsAccDecimalsInAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.tblVouTemplateRow_colsAccDecimalsInAmount, "tblVouTemplateRow_colsAccDecimalsInAmount");
            this.tblVouTemplateRow_colsAccDecimalsInAmount.Name = "tblVouTemplateRow_colsAccDecimalsInAmount";
            this.tblVouTemplateRow_colsAccDecimalsInAmount.NamedProperties.Put("EnumerateMethod", "");
            this.tblVouTemplateRow_colsAccDecimalsInAmount.NamedProperties.Put("FieldFlags", "262");
            this.tblVouTemplateRow_colsAccDecimalsInAmount.NamedProperties.Put("LovReference", "");
            this.tblVouTemplateRow_colsAccDecimalsInAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVouTemplateRow_colsAccDecimalsInAmount.NamedProperties.Put("SqlColumn", "ACC_DECIMALS_IN_AMOUNT");
            this.tblVouTemplateRow_colsAccDecimalsInAmount.NamedProperties.Put("ValidateMethod", "");
            this.tblVouTemplateRow_colsAccDecimalsInAmount.Position = 46;
            // 
            // tblVouTemplateRow_colsDecimalsInRate
            // 
            this.tblVouTemplateRow_colsDecimalsInRate.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.tblVouTemplateRow_colsDecimalsInRate, "tblVouTemplateRow_colsDecimalsInRate");
            this.tblVouTemplateRow_colsDecimalsInRate.Name = "tblVouTemplateRow_colsDecimalsInRate";
            this.tblVouTemplateRow_colsDecimalsInRate.NamedProperties.Put("EnumerateMethod", "");
            this.tblVouTemplateRow_colsDecimalsInRate.NamedProperties.Put("FieldFlags", "262");
            this.tblVouTemplateRow_colsDecimalsInRate.NamedProperties.Put("LovReference", "");
            this.tblVouTemplateRow_colsDecimalsInRate.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVouTemplateRow_colsDecimalsInRate.NamedProperties.Put("SqlColumn", "DECIMALS_IN_RATE");
            this.tblVouTemplateRow_colsDecimalsInRate.NamedProperties.Put("ValidateMethod", "");
            this.tblVouTemplateRow_colsDecimalsInRate.Position = 47;
            // 
            // tblVouTemplateRow_colsCodeDemand
            // 
            this.tblVouTemplateRow_colsCodeDemand.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblVouTemplateRow_colsCodeDemand, "tblVouTemplateRow_colsCodeDemand");
            this.tblVouTemplateRow_colsCodeDemand.MaxLength = 2000;
            this.tblVouTemplateRow_colsCodeDemand.Name = "tblVouTemplateRow_colsCodeDemand";
            this.tblVouTemplateRow_colsCodeDemand.NamedProperties.Put("EnumerateMethod", "");
            this.tblVouTemplateRow_colsCodeDemand.NamedProperties.Put("FieldFlags", "258");
            this.tblVouTemplateRow_colsCodeDemand.NamedProperties.Put("LovReference", "");
            this.tblVouTemplateRow_colsCodeDemand.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVouTemplateRow_colsCodeDemand.NamedProperties.Put("SqlColumn", "CODE_DEMAND");
            this.tblVouTemplateRow_colsCodeDemand.NamedProperties.Put("ValidateMethod", "");
            this.tblVouTemplateRow_colsCodeDemand.Position = 48;
            // 
            // tblVouTemplateRow_colsRateChanged
            // 
            resources.ApplyResources(this.tblVouTemplateRow_colsRateChanged, "tblVouTemplateRow_colsRateChanged");
            this.tblVouTemplateRow_colsRateChanged.Name = "tblVouTemplateRow_colsRateChanged";
            this.tblVouTemplateRow_colsRateChanged.Position = 49;
            // 
            // tblVouTemplateRow_colnProjectActivityId
            // 
            this.tblVouTemplateRow_colnProjectActivityId.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVouTemplateRow_colnProjectActivityId.Name = "tblVouTemplateRow_colnProjectActivityId";
            this.tblVouTemplateRow_colnProjectActivityId.NamedProperties.Put("EnumerateMethod", "");
            this.tblVouTemplateRow_colnProjectActivityId.NamedProperties.Put("FieldFlags", "294");
            this.tblVouTemplateRow_colnProjectActivityId.NamedProperties.Put("LovReference", "PROJECT_ACTIVITY_POSTABLE(PROJECT_ID)");
            this.tblVouTemplateRow_colnProjectActivityId.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVouTemplateRow_colnProjectActivityId.NamedProperties.Put("SqlColumn", "PROJECT_ACTIVITY_ID");
            this.tblVouTemplateRow_colnProjectActivityId.NamedProperties.Put("ValidateMethod", "");
            this.tblVouTemplateRow_colnProjectActivityId.Position = 50;
            resources.ApplyResources(this.tblVouTemplateRow_colnProjectActivityId, "tblVouTemplateRow_colnProjectActivityId");
            this.tblVouTemplateRow_colnProjectActivityId.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVouTemplateRow_colnProjectActivityId_WindowActions);
            // 
            // tblVouTemplateRow_colProjectActivityIdEnabled
            // 
            resources.ApplyResources(this.tblVouTemplateRow_colProjectActivityIdEnabled, "tblVouTemplateRow_colProjectActivityIdEnabled");
            this.tblVouTemplateRow_colProjectActivityIdEnabled.Name = "tblVouTemplateRow_colProjectActivityIdEnabled";
            this.tblVouTemplateRow_colProjectActivityIdEnabled.Position = 51;
            // 
            // tblVouTemplateRow_colProjectId
            // 
            resources.ApplyResources(this.tblVouTemplateRow_colProjectId, "tblVouTemplateRow_colProjectId");
            this.tblVouTemplateRow_colProjectId.Name = "tblVouTemplateRow_colProjectId";
            this.tblVouTemplateRow_colProjectId.NamedProperties.Put("EnumerateMethod", "");
            this.tblVouTemplateRow_colProjectId.NamedProperties.Put("FieldFlags", "768");
            this.tblVouTemplateRow_colProjectId.NamedProperties.Put("LovReference", "");
            this.tblVouTemplateRow_colProjectId.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVouTemplateRow_colProjectId.NamedProperties.Put("SqlColumn", "PROJECT_ID");
            this.tblVouTemplateRow_colProjectId.NamedProperties.Put("ValidateMethod", "");
            this.tblVouTemplateRow_colProjectId.Position = 52;
            // 
            // tblVouTemplateRow_colsPrevAccount
            // 
            resources.ApplyResources(this.tblVouTemplateRow_colsPrevAccount, "tblVouTemplateRow_colsPrevAccount");
            this.tblVouTemplateRow_colsPrevAccount.Name = "tblVouTemplateRow_colsPrevAccount";
            this.tblVouTemplateRow_colsPrevAccount.NamedProperties.Put("EnumerateMethod", "");
            this.tblVouTemplateRow_colsPrevAccount.NamedProperties.Put("LovReference", "");
            this.tblVouTemplateRow_colsPrevAccount.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVouTemplateRow_colsPrevAccount.NamedProperties.Put("SqlColumn", "");
            this.tblVouTemplateRow_colsPrevAccount.NamedProperties.Put("ValidateMethod", "");
            this.tblVouTemplateRow_colsPrevAccount.Position = 53;
            // 
            // tblVouTemplateRow_colsPrevTaxCode
            // 
            resources.ApplyResources(this.tblVouTemplateRow_colsPrevTaxCode, "tblVouTemplateRow_colsPrevTaxCode");
            this.tblVouTemplateRow_colsPrevTaxCode.Name = "tblVouTemplateRow_colsPrevTaxCode";
            this.tblVouTemplateRow_colsPrevTaxCode.NamedProperties.Put("EnumerateMethod", "");
            this.tblVouTemplateRow_colsPrevTaxCode.NamedProperties.Put("LovReference", "");
            this.tblVouTemplateRow_colsPrevTaxCode.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVouTemplateRow_colsPrevTaxCode.NamedProperties.Put("SqlColumn", "");
            this.tblVouTemplateRow_colsPrevTaxCode.NamedProperties.Put("ValidateMethod", "");
            this.tblVouTemplateRow_colsPrevTaxCode.Position = 54;
            // 
            // frmVouTemplate
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.tblVouTemplateRow);
            this.Controls.Add(this.dfCodePartValue);
            this.Controls.Add(this.dfnRowNo);
            this.Controls.Add(this.dfsCurrencyRate);
            this.Controls.Add(this.dfsDecimalsInRate);
            this.Controls.Add(this.dfsCurrencyCode);
            this.Controls.Add(this.dfsCurrencyType);
            this.Controls.Add(this.dfnConvFactor);
            this.Controls.Add(this.dfCodePartDescription);
            this.Controls.Add(this.cbCorrection);
            this.Controls.Add(this.dfdValidUntil);
            this.Controls.Add(this.dfdValidFrom);
            this.Controls.Add(this.dfsDescription);
            this.Controls.Add(this.cmbTemplate);
            this.Controls.Add(this.dfsCompany);
            this.Controls.Add(this.labeldfCodePartValue);
            this.Controls.Add(this.labeldfCodePartDescription);
            this.Controls.Add(this.labeldfdValidUntil);
            this.Controls.Add(this.labeldfdValidFrom);
            this.Controls.Add(this.labeldfsDescription);
            this.Controls.Add(this.labelcmbTemplate);
            this.MaximizeBox = true;
            this.Name = "frmVouTemplate";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "COMPANY = :global.company");
            this.NamedProperties.Put("LogicalUnit", "VoucherTemplate");
            this.NamedProperties.Put("PackageName", "VOUCHER_TEMPLATE_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("ViewName", "VOUCHER_TEMPLATE");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.frmVouTemplate_WindowActions);
            this.menuFrmMethods.ResumeLayout(false);
            this.menuOperations.ResumeLayout(false);
            this.menuTblMethods.ResumeLayout(false);
            this.tblVouTemplateRow.ResumeLayout(false);
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
		
		public Fnd.Windows.Forms.FndCommand menuTblMethods_menuChange__Company___;
        public Fnd.Windows.Forms.FndCommand menuOperations_menuChange__Company___;
        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menuChange__Company___;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuFrmMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuOperations;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change_1;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTblMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change_2;
        public cChildTableFin tblVouTemplateRow;
        protected cColumn tblVouTemplateRow_colsCompany;
        protected cColumn tblVouTemplateRow_colsTemplate;
        protected cColumn tblVouTemplateRow_colnRowNo;
        protected cColumnCodePartFin tblVouTemplateRow_colsAccount;
        protected cColumnCodePartDescFin tblVouTemplateRow_colsAccountDesc;
        protected cColumnCodePartFin tblVouTemplateRow_colsCodeB;
        protected cColumnCodePartDescFin tblVouTemplateRow_colsCodeBDesc;
        protected cColumnCodePartFin tblVouTemplateRow_colsCodeC;
        protected cColumnCodePartDescFin tblVouTemplateRow_colsCodeCDesc;
        protected cColumnCodePartFin tblVouTemplateRow_colsCodeD;
        protected cColumnCodePartDescFin tblVouTemplateRow_colsCodeDDesc;
        protected cColumnCodePartFin tblVouTemplateRow_colsCodeE;
        protected cColumnCodePartDescFin tblVouTemplateRow_colsCodeEDesc;
        protected cColumnCodePartFin tblVouTemplateRow_colsCodeF;
        protected cColumnCodePartDescFin tblVouTemplateRow_colsCodeFDesc;
        protected cColumnCodePartFin tblVouTemplateRow_colsCodeG;
        protected cColumnCodePartDescFin tblVouTemplateRow_colsCodeGDesc;
        protected cColumnCodePartFin tblVouTemplateRow_colsCodeH;
        protected cColumnCodePartDescFin tblVouTemplateRow_colsCodeHDesc;
        protected cColumnCodePartFin tblVouTemplateRow_colsCodeI;
        protected cColumnCodePartDescFin tblVouTemplateRow_colsCodeIDesc;
        protected cColumnCodePartFin tblVouTemplateRow_colsCodeJ;
        protected cColumnCodePartDescFin tblVouTemplateRow_colsCodeJDesc;
        protected cColumnCodePartFin tblVouTemplateRow_colsProcessCodeP;
        protected cColumn tblVouTemplateRow_colsOptionalCode;
        protected cColumn tblVouTemplateRow_colsCurrencyType;
        protected cColumn tblVouTemplateRow_colsCurrencyCode;
        protected cCheckBoxColumn tblVouTemplateRow_colsCorrection;
        protected cColumn tblVouTemplateRow_colnDebitCurrencyAmount;
        protected cColumn tblVouTemplateRow_colnCreditCurrencyAmount;
        protected cColumn tblVouTemplateRow_colnCurrencyAmount;
        protected cColumn tblVouTemplateRow_colnCurrencyRate;
        protected cColumn tblVouTemplateRow_colnConversionFactor;
        protected cColumn tblVouTemplateRow_colnDebitAmount;
        protected cColumn tblVouTemplateRow_colnCreditAmount;
        protected cColumn tblVouTemplateRow_colnAmount;
        protected cColumnCodePartFin tblVouTemplateRow_colnQuantityQ;
        protected cColumnCodePartFin tblVouTemplateRow_colsTextT;
        protected cColumn tblVouTemplateRow_colsTransCode;
        protected cColumn tblVouTemplateRow_colsCodePart;
        protected cColumn tblVouTemplateRow_colsDecimalsInAmount;
        protected cColumn tblVouTemplateRow_colsAccDecimalsInAmount;
        protected cColumn tblVouTemplateRow_colsDecimalsInRate;
        protected cColumn tblVouTemplateRow_colsCodeDemand;
        protected cColumn tblVouTemplateRow_colsRateChanged;
        protected cColumn tblVouTemplateRow_colnProjectActivityId;
        protected cColumn tblVouTemplateRow_colProjectActivityIdEnabled;
        protected cColumn tblVouTemplateRow_colProjectId;
        protected cColumn tblVouTemplateRow_colsPrevAccount;
        protected cColumn tblVouTemplateRow_colsPrevTaxCode;
        protected cColumn tblVouTemplateRow_colsDeliveryTypeId;
        protected cColumn tblVouTemplateRow_colsDeliveryTypeDescription;
	}
}
