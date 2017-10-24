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
	
	public partial class frmCurrencyRate
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cDataField dfsCompany;
		protected cBackgroundText labelcmbName;
		public cRecListDataField cmbName;
		protected cBackgroundText labeldfsDesc;
		public cDataField dfsDesc;
		protected cBackgroundText labeldfsRefCurrencyCode;
		public cDataField dfsRefCurrencyCode;
		protected cBackgroundText labeldfsRateTypeCategory;
		public cDataField dfsRateTypeCategory;
		public cCheckBox cbValidRates;
        public cCheckBox cbInverted;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCurrencyRate));
            this.menuFrmMethods_menuChange__Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuOperations_menuChange__Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTblMethods_menuChange__Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.dfsCompany = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelcmbName = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbName = new Ifs.Fnd.ApplicationForms.cRecListDataField();
            this.labeldfsDesc = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsDesc = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsRefCurrencyCode = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsRefCurrencyCode = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsRateTypeCategory = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsRateTypeCategory = new Ifs.Fnd.ApplicationForms.cDataField();
            this.cbValidRates = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.cbInverted = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.menuTblMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_Change = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuOperations = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_Change_1 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuFrmMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_Change_2 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.tblRates = new Ifs.Application.Accrul.cChildTableFinBase();
            this.tblRates_colCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblRates_colIdType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblRates_colsRefCurrencyCode = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblRates_colCurrencyCode = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblRates_colDescription = new PPJ.Runtime.Windows.SalTableColumn();
            this.tblRates_colRate = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblRates_colValidFrom = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblRates_colConvFactor = new Ifs.Fnd.ApplicationForms.cColumn();
            this.menuTblMethods.SuspendLayout();
            this.menuOperations.SuspendLayout();
            this.menuFrmMethods.SuspendLayout();
            this.tblRates.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuTblMethods_menuChange__Company___);
            this.commandManager.Commands.Add(this.menuOperations_menuChange__Company___);
            this.commandManager.Commands.Add(this.menuFrmMethods_menuChange__Company___);
            this.commandManager.ContextMenus.Add(this.menuTblMethods);
            this.commandManager.ContextMenus.Add(this.menuOperations);
            this.commandManager.ContextMenus.Add(this.menuFrmMethods);
            this.commandManager.ImageList = null;
            // 
            // menuFrmMethods_menuChange__Company___
            // 
            resources.ApplyResources(this.menuFrmMethods_menuChange__Company___, "menuFrmMethods_menuChange__Company___");
            this.menuFrmMethods_menuChange__Company___.Name = "menuFrmMethods_menuChange__Company___";
            this.menuFrmMethods_menuChange__Company___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Change_2_Execute);
            this.menuFrmMethods_menuChange__Company___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Change_2_Inquire);
            // 
            // menuOperations_menuChange__Company___
            // 
            resources.ApplyResources(this.menuOperations_menuChange__Company___, "menuOperations_menuChange__Company___");
            this.menuOperations_menuChange__Company___.Name = "menuOperations_menuChange__Company___";
            this.menuOperations_menuChange__Company___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Change_1_Execute);
            this.menuOperations_menuChange__Company___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Change_1_Inquire);
            // 
            // menuTblMethods_menuChange__Company___
            // 
            resources.ApplyResources(this.menuTblMethods_menuChange__Company___, "menuTblMethods_menuChange__Company___");
            this.menuTblMethods_menuChange__Company___.Name = "menuTblMethods_menuChange__Company___";
            this.menuTblMethods_menuChange__Company___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Change_Execute);
            this.menuTblMethods_menuChange__Company___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Change_Inquire);
            // 
            // dfsCompany
            // 
            resources.ApplyResources(this.dfsCompany, "dfsCompany");
            this.dfsCompany.Name = "dfsCompany";
            this.dfsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.dfsCompany.NamedProperties.Put("FieldFlags", "64");
            this.dfsCompany.NamedProperties.Put("LovReference", "");
            this.dfsCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.dfsCompany.NamedProperties.Put("ValidateMethod", "");
            // 
            // labelcmbName
            // 
            resources.ApplyResources(this.labelcmbName, "labelcmbName");
            this.labelcmbName.Name = "labelcmbName";
            // 
            // cmbName
            // 
            resources.ApplyResources(this.cmbName, "cmbName");
            this.cmbName.Name = "cmbName";
            this.cmbName.NamedProperties.Put("EnumerateMethod", "");
            this.cmbName.NamedProperties.Put("FieldFlags", "163");
            this.cmbName.NamedProperties.Put("LovReference", "");
            this.cmbName.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbName.NamedProperties.Put("SqlColumn", "CURRENCY_TYPE");
            this.cmbName.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsDesc
            // 
            resources.ApplyResources(this.labeldfsDesc, "labeldfsDesc");
            this.labeldfsDesc.Name = "labeldfsDesc";
            // 
            // dfsDesc
            // 
            resources.ApplyResources(this.dfsDesc, "dfsDesc");
            this.dfsDesc.Name = "dfsDesc";
            this.dfsDesc.NamedProperties.Put("EnumerateMethod", "");
            this.dfsDesc.NamedProperties.Put("FieldFlags", "294");
            this.dfsDesc.NamedProperties.Put("LovReference", "");
            this.dfsDesc.NamedProperties.Put("ParentName", "cmbName");
            this.dfsDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsDesc.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            this.dfsDesc.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsRefCurrencyCode
            // 
            resources.ApplyResources(this.labeldfsRefCurrencyCode, "labeldfsRefCurrencyCode");
            this.labeldfsRefCurrencyCode.Name = "labeldfsRefCurrencyCode";
            // 
            // dfsRefCurrencyCode
            // 
            resources.ApplyResources(this.dfsRefCurrencyCode, "dfsRefCurrencyCode");
            this.dfsRefCurrencyCode.Name = "dfsRefCurrencyCode";
            this.dfsRefCurrencyCode.NamedProperties.Put("EnumerateMethod", "");
            this.dfsRefCurrencyCode.NamedProperties.Put("FieldFlags", "288");
            this.dfsRefCurrencyCode.NamedProperties.Put("LovReference", "");
            this.dfsRefCurrencyCode.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsRefCurrencyCode.NamedProperties.Put("SqlColumn", "REF_CURRENCY_CODE");
            this.dfsRefCurrencyCode.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsRateTypeCategory
            // 
            resources.ApplyResources(this.labeldfsRateTypeCategory, "labeldfsRateTypeCategory");
            this.labeldfsRateTypeCategory.Name = "labeldfsRateTypeCategory";
            // 
            // dfsRateTypeCategory
            // 
            resources.ApplyResources(this.dfsRateTypeCategory, "dfsRateTypeCategory");
            this.dfsRateTypeCategory.Name = "dfsRateTypeCategory";
            this.dfsRateTypeCategory.NamedProperties.Put("EnumerateMethod", "CURR_RATE_TYPE_CATEGORY_API.Enumerate");
            this.dfsRateTypeCategory.NamedProperties.Put("FieldFlags", "288");
            this.dfsRateTypeCategory.NamedProperties.Put("LovReference", "");
            this.dfsRateTypeCategory.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsRateTypeCategory.NamedProperties.Put("SqlColumn", "RATE_TYPE_CATEGORY");
            this.dfsRateTypeCategory.NamedProperties.Put("ValidateMethod", "");
            // 
            // cbValidRates
            // 
            resources.ApplyResources(this.cbValidRates, "cbValidRates");
            this.cbValidRates.Name = "cbValidRates";
            this.cbValidRates.NamedProperties.Put("DataType", "5");
            this.cbValidRates.NamedProperties.Put("EnumerateMethod", "");
            this.cbValidRates.NamedProperties.Put("LovReference", "");
            this.cbValidRates.NamedProperties.Put("ResizeableChildObject", "");
            this.cbValidRates.NamedProperties.Put("SqlColumn", "");
            this.cbValidRates.NamedProperties.Put("ValidateMethod", "");
            this.cbValidRates.NamedProperties.Put("XDataLength", "");
            this.cbValidRates.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cbValidRates_WindowActions);
            // 
            // cbInverted
            // 
            resources.ApplyResources(this.cbInverted, "cbInverted");
            this.cbInverted.Name = "cbInverted";
            this.cbInverted.NamedProperties.Put("DataType", "5");
            this.cbInverted.NamedProperties.Put("EnumerateMethod", "");
            this.cbInverted.NamedProperties.Put("LovReference", "");
            this.cbInverted.NamedProperties.Put("ResizeableChildObject", "");
            this.cbInverted.NamedProperties.Put("SqlColumn", "CURRENCY_CODE_API.Get_Inverted(COMPANY,REF_CURRENCY_CODE)");
            this.cbInverted.NamedProperties.Put("ValidateMethod", "");
            this.cbInverted.NamedProperties.Put("XDataLength", "Default");
            // 
            // menuTblMethods
            // 
            this.menuTblMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_Change});
            this.menuTblMethods.Name = "menuTblMethods";
            resources.ApplyResources(this.menuTblMethods, "menuTblMethods");
            // 
            // menuItem_Change
            // 
            this.menuItem_Change.Command = this.menuTblMethods_menuChange__Company___;
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
            // menuFrmMethods
            // 
            this.menuFrmMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_Change_2});
            this.menuFrmMethods.Name = "menuFrmMethods";
            resources.ApplyResources(this.menuFrmMethods, "menuFrmMethods");
            // 
            // menuItem_Change_2
            // 
            this.menuItem_Change_2.Command = this.menuFrmMethods_menuChange__Company___;
            this.menuItem_Change_2.Name = "menuItem_Change_2";
            resources.ApplyResources(this.menuItem_Change_2, "menuItem_Change_2");
            this.menuItem_Change_2.Text = "Change &Company...";
            // 
            // tblRates
            // 
            this.tblRates.Controls.Add(this.tblRates_colCompany);
            this.tblRates.Controls.Add(this.tblRates_colIdType);
            this.tblRates.Controls.Add(this.tblRates_colsRefCurrencyCode);
            this.tblRates.Controls.Add(this.tblRates_colCurrencyCode);
            this.tblRates.Controls.Add(this.tblRates_colDescription);
            this.tblRates.Controls.Add(this.tblRates_colRate);
            this.tblRates.Controls.Add(this.tblRates_colValidFrom);
            this.tblRates.Controls.Add(this.tblRates_colConvFactor);
            resources.ApplyResources(this.tblRates, "tblRates");
            this.tblRates.Name = "tblRates";
            this.tblRates.NamedProperties.Put("DefaultOrderBy", "CURRENCY_CODE, VALID_FROM");
            this.tblRates.NamedProperties.Put("DefaultWhere", "");
            this.tblRates.NamedProperties.Put("LogicalUnit", "CurrencyRate");
            this.tblRates.NamedProperties.Put("PackageName", "CURRENCY_RATE_API");
            this.tblRates.NamedProperties.Put("ResizeableChildObject", "LLMM");
            this.tblRates.NamedProperties.Put("ViewName", "LATEST_CURRENCY_RATES");
            this.tblRates.NamedProperties.Put("Warnings", "FALSE");
            this.tblRates.DataRecordExecuteNewEvent += new Ifs.Fnd.ApplicationForms.cDataSource.DataRecordExecuteNewEventHandler(this.tblRates_DataRecordExecuteNewEvent);
            this.tblRates.DataRecordGetDefaultsEvent += new System.EventHandler<Ifs.Fnd.ApplicationForms.FndReturnEventArgsSalBoolean>(this.tblRates_DataRecordGetDefaultsEvent);
            this.tblRates.DataSourcePopulateItEvent += new Ifs.Fnd.ApplicationForms.cDataSource.DataSourcePopulateItEventHandler(this.tblRates_DataSourcePopulateItEvent);
            this.tblRates.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblRates_WindowActions);
            this.tblRates.Controls.SetChildIndex(this.tblRates_colConvFactor, 0);
            this.tblRates.Controls.SetChildIndex(this.tblRates_colValidFrom, 0);
            this.tblRates.Controls.SetChildIndex(this.tblRates_colRate, 0);
            this.tblRates.Controls.SetChildIndex(this.tblRates_colDescription, 0);
            this.tblRates.Controls.SetChildIndex(this.tblRates_colCurrencyCode, 0);
            this.tblRates.Controls.SetChildIndex(this.tblRates_colsRefCurrencyCode, 0);
            this.tblRates.Controls.SetChildIndex(this.tblRates_colIdType, 0);
            this.tblRates.Controls.SetChildIndex(this.tblRates_colCompany, 0);
            // 
            // tblRates_colCompany
            // 
            this.tblRates_colCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblRates_colCompany, "tblRates_colCompany");
            this.tblRates_colCompany.MaxLength = 20;
            this.tblRates_colCompany.Name = "tblRates_colCompany";
            this.tblRates_colCompany.NamedProperties.Put("EnumerateMethod", "");
            this.tblRates_colCompany.NamedProperties.Put("FieldFlags", "67");
            this.tblRates_colCompany.NamedProperties.Put("LovReference", "");
            this.tblRates_colCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.tblRates_colCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.tblRates_colCompany.NamedProperties.Put("ValidateMethod", "");
            this.tblRates_colCompany.Position = 3;
            // 
            // tblRates_colIdType
            // 
            resources.ApplyResources(this.tblRates_colIdType, "tblRates_colIdType");
            this.tblRates_colIdType.MaxLength = 10;
            this.tblRates_colIdType.Name = "tblRates_colIdType";
            this.tblRates_colIdType.NamedProperties.Put("FieldFlags", "67");
            this.tblRates_colIdType.NamedProperties.Put("LovReference", "CURRENCY_TYPE(COMPANY,CURRENCY_TYPE)");
            this.tblRates_colIdType.NamedProperties.Put("SqlColumn", "CURRENCY_TYPE");
            this.tblRates_colIdType.Position = 4;
            // 
            // tblRates_colsRefCurrencyCode
            // 
            resources.ApplyResources(this.tblRates_colsRefCurrencyCode, "tblRates_colsRefCurrencyCode");
            this.tblRates_colsRefCurrencyCode.MaxLength = 3;
            this.tblRates_colsRefCurrencyCode.Name = "tblRates_colsRefCurrencyCode";
            this.tblRates_colsRefCurrencyCode.NamedProperties.Put("EnumerateMethod", "");
            this.tblRates_colsRefCurrencyCode.NamedProperties.Put("FieldFlags", "263");
            this.tblRates_colsRefCurrencyCode.NamedProperties.Put("LovReference", "");
            this.tblRates_colsRefCurrencyCode.NamedProperties.Put("SqlColumn", "REF_CURRENCY_CODE");
            this.tblRates_colsRefCurrencyCode.Position = 5;
            // 
            // tblRates_colCurrencyCode
            // 
            this.tblRates_colCurrencyCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblRates_colCurrencyCode.MaxLength = 3;
            this.tblRates_colCurrencyCode.Name = "tblRates_colCurrencyCode";
            this.tblRates_colCurrencyCode.NamedProperties.Put("EnumerateMethod", "");
            this.tblRates_colCurrencyCode.NamedProperties.Put("FieldFlags", "163");
            this.tblRates_colCurrencyCode.NamedProperties.Put("LovReference", "CURRENCY_CODE(COMPANY,CURRENCY_CODE)");
            this.tblRates_colCurrencyCode.NamedProperties.Put("SqlColumn", "CURRENCY_CODE");
            this.tblRates_colCurrencyCode.Position = 6;
            this.tblRates_colCurrencyCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            resources.ApplyResources(this.tblRates_colCurrencyCode, "tblRates_colCurrencyCode");
            this.tblRates_colCurrencyCode.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblRates_colCurrencyCode_WindowActions);
            // 
            // tblRates_colDescription
            // 
            resources.ApplyResources(this.tblRates_colDescription, "tblRates_colDescription");
            this.tblRates_colDescription.Name = "tblRates_colDescription";
            this.tblRates_colDescription.Position = 7;
            // 
            // tblRates_colRate
            // 
            this.tblRates_colRate.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblRates_colRate.Name = "tblRates_colRate";
            this.tblRates_colRate.NamedProperties.Put("EnumerateMethod", "");
            this.tblRates_colRate.NamedProperties.Put("FieldFlags", "295");
            this.tblRates_colRate.NamedProperties.Put("LovReference", "");
            this.tblRates_colRate.NamedProperties.Put("ResizeableChildObject", "");
            this.tblRates_colRate.NamedProperties.Put("SqlColumn", "CURRENCY_RATE");
            this.tblRates_colRate.NamedProperties.Put("ValidateMethod", "");
            this.tblRates_colRate.Position = 8;
            this.tblRates_colRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblRates_colRate, "tblRates_colRate");
            this.tblRates_colRate.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblRates_colRate_WindowActions);
            // 
            // tblRates_colValidFrom
            // 
            this.tblRates_colValidFrom.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.tblRates_colValidFrom.Format = "d";
            this.tblRates_colValidFrom.Name = "tblRates_colValidFrom";
            this.tblRates_colValidFrom.NamedProperties.Put("EnumerateMethod", "");
            this.tblRates_colValidFrom.NamedProperties.Put("FieldFlags", "163");
            this.tblRates_colValidFrom.NamedProperties.Put("LovReference", "");
            this.tblRates_colValidFrom.NamedProperties.Put("SqlColumn", "VALID_FROM");
            this.tblRates_colValidFrom.NamedProperties.Put("ValidateMethod", "");
            this.tblRates_colValidFrom.Position = 9;
            this.tblRates_colValidFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            resources.ApplyResources(this.tblRates_colValidFrom, "tblRates_colValidFrom");
            // 
            // tblRates_colConvFactor
            // 
            this.tblRates_colConvFactor.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblRates_colConvFactor.Name = "tblRates_colConvFactor";
            this.tblRates_colConvFactor.NamedProperties.Put("EnumerateMethod", "");
            this.tblRates_colConvFactor.NamedProperties.Put("FieldFlags", "288");
            this.tblRates_colConvFactor.NamedProperties.Put("LovReference", "");
            this.tblRates_colConvFactor.NamedProperties.Put("ResizeableChildObject", "");
            this.tblRates_colConvFactor.NamedProperties.Put("SqlColumn", "CONV_FACTOR");
            this.tblRates_colConvFactor.NamedProperties.Put("ValidateMethod", "");
            this.tblRates_colConvFactor.Position = 10;
            this.tblRates_colConvFactor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblRates_colConvFactor, "tblRates_colConvFactor");
            // 
            // frmCurrencyRate
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.tblRates);
            this.Controls.Add(this.cbInverted);
            this.Controls.Add(this.cbValidRates);
            this.Controls.Add(this.dfsRateTypeCategory);
            this.Controls.Add(this.dfsRefCurrencyCode);
            this.Controls.Add(this.dfsDesc);
            this.Controls.Add(this.cmbName);
            this.Controls.Add(this.dfsCompany);
            this.Controls.Add(this.labeldfsRateTypeCategory);
            this.Controls.Add(this.labeldfsRefCurrencyCode);
            this.Controls.Add(this.labeldfsDesc);
            this.Controls.Add(this.labelcmbName);
            this.MaximizeBox = true;
            this.Name = "frmCurrencyRate";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "COMPANY = :i_hWndFrame.frmCurrencyRate.i_sCompany");
            this.NamedProperties.Put("LogicalUnit", "CurrencyType");
            this.NamedProperties.Put("PackageName", "CURRENCY_TYPE_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "0");
            this.NamedProperties.Put("ViewName", "CURRENCY_TYPE3");
            this.NamedProperties.Put("Warnings", "TRUE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.frmCurrencyRate_WindowActions);
            this.menuTblMethods.ResumeLayout(false);
            this.menuOperations.ResumeLayout(false);
            this.menuFrmMethods.ResumeLayout(false);
            this.tblRates.ResumeLayout(false);
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
        public Fnd.Windows.Forms.FndCommand menuOperations_menuChange__Company___;
        public Fnd.Windows.Forms.FndCommand menuTblMethods_menuChange__Company___;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTblMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuOperations;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change_1;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuFrmMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change_2;
        public cChildTableFinBase tblRates;
        protected cColumn tblRates_colCompany;
        protected cColumn tblRates_colIdType;
        protected cColumn tblRates_colsRefCurrencyCode;
        protected cColumn tblRates_colCurrencyCode;
        protected SalTableColumn tblRates_colDescription;
        protected cColumn tblRates_colRate;
        protected cColumn tblRates_colValidFrom;
        protected cColumn tblRates_colConvFactor;
	}
}
