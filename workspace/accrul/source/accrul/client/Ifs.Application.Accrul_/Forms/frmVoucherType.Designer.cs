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
	
	public partial class frmVoucherType
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		protected cBackgroundText labeldfsCompany;
		public cDataFieldFin dfsCompany;
		protected cBackgroundText labelcmbVoucherType;
		public cRecSelExtComboBoxFin cmbVoucherType;
		protected cBackgroundText labeldfDescription;
		public cDataFieldFin dfDescription;
		protected SalGroupBox gbLedger_Selection;
		protected cBackgroundText labelcmbLedger;
		public cComboBox cmbLedger;
		protected cBackgroundText labeldfLedgerID;
		public cDataField dfLedgerID;
		public cCheckBoxFin cbUseMIM;
		public cCheckBoxFin cbBalance;
		protected SalGroupBox gbVoucher_Selection;
		public cCheckBoxFin cbAutoAllotment;
		public cCheckBoxFin cbSimulationVou;
        public cCheckBoxFin cbSingleFunction;
		// Hidden Fields
		protected cBackgroundText labeldfsOptionalAutoBalance;
		public cDataFieldFin dfsOptionalAutoBalance;
		protected cBackgroundText labeldfsStoreOriginal;
		public cDataFieldFin dfsStoreOriginal;
		protected cBackgroundText labeldfsLabelPrint;
		public cDataFieldFin dfsLabelPrint;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVoucherType));
            this.menuOperations_menu_Voucher_Series___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuOperations_menuTrans_lation___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuOperations_menuChange__Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuFrmMethods_menu_Voucher_Series___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuFrmMethods_menu_Excluded_From_IL___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuFrmMethods_menuTrans_lation___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuFrmMethods_menuChange__Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.labeldfsCompany = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsCompany = new Ifs.Application.Accrul.cDataFieldFin();
            this.labelcmbVoucherType = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbVoucherType = new Ifs.Application.Accrul.cRecSelExtComboBoxFin();
            this.labeldfDescription = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfDescription = new Ifs.Application.Accrul.cDataFieldFin();
            this.gbLedger_Selection = new PPJ.Runtime.Windows.SalGroupBox();
            this.labelcmbLedger = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbLedger = new Ifs.Fnd.ApplicationForms.cComboBox();
            this.labeldfLedgerID = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfLedgerID = new Ifs.Fnd.ApplicationForms.cDataField();
            this.cbUseMIM = new Ifs.Application.Accrul.cCheckBoxFin();
            this.cbBalance = new Ifs.Application.Accrul.cCheckBoxFin();
            this.gbVoucher_Selection = new PPJ.Runtime.Windows.SalGroupBox();
            this.cbAutoAllotment = new Ifs.Application.Accrul.cCheckBoxFin();
            this.cbSimulationVou = new Ifs.Application.Accrul.cCheckBoxFin();
            this.cbSingleFunction = new Ifs.Application.Accrul.cCheckBoxFin();
            this.labeldfsOptionalAutoBalance = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsOptionalAutoBalance = new Ifs.Application.Accrul.cDataFieldFin();
            this.labeldfsStoreOriginal = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsStoreOriginal = new Ifs.Application.Accrul.cDataFieldFin();
            this.labeldfsLabelPrint = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsLabelPrint = new Ifs.Application.Accrul.cDataFieldFin();
            this.menuFrmMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem__Voucher = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuSeparator1 = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.menuItem__Excluded = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuSeparator2 = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.menuItem_Translation = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuSeparator3 = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.menuItem_Change = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuOperations = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem__Voucher_1 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuSeparator4 = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.menuItem_Translation_1 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuSeparator5 = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.menuItem_Change_1 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.tblVoucherTypeDetail = new Ifs.Application.Accrul.cChildTableFin();
            this.tblVoucherTypeDetail_colsCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherTypeDetail_colsVoucherType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherTypeDetail_colsVoucherFunction = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherTypeDetail_colDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherTypeDetail_colsOptionalAutoBalance = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.tblVoucherTypeDetail_colsStoreOriginal = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.tblVoucherTypeDetail_colsRowGrpValidation = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.tblVoucherTypeDetail_colsRefMandetory = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.tblVoucherTypeDetail_colsAutomaticAllot = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.tblVoucherTypeDetail_colsSingleVoucher = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.menuFrmMethods.SuspendLayout();
            this.menuOperations.SuspendLayout();
            this.tblVoucherTypeDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuFrmMethods_menu_Voucher_Series___);
            this.commandManager.Commands.Add(this.menuFrmMethods_menu_Excluded_From_IL___);
            this.commandManager.Commands.Add(this.menuFrmMethods_menuTrans_lation___);
            this.commandManager.Commands.Add(this.menuFrmMethods_menuChange__Company___);
            this.commandManager.Commands.Add(this.menuOperations_menu_Voucher_Series___);
            this.commandManager.Commands.Add(this.menuOperations_menuTrans_lation___);
            this.commandManager.Commands.Add(this.menuOperations_menuChange__Company___);
            this.commandManager.ContextMenus.Add(this.menuFrmMethods);
            this.commandManager.ContextMenus.Add(this.menuOperations);
            this.commandManager.ImageList = null;
            // 
            // menuOperations_menu_Voucher_Series___
            // 
            resources.ApplyResources(this.menuOperations_menu_Voucher_Series___, "menuOperations_menu_Voucher_Series___");
            this.menuOperations_menu_Voucher_Series___.Name = "menuOperations_menu_Voucher_Series___";
            this.menuOperations_menu_Voucher_Series___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Voucher_1_Execute);
            // 
            // menuOperations_menuTrans_lation___
            // 
            resources.ApplyResources(this.menuOperations_menuTrans_lation___, "menuOperations_menuTrans_lation___");
            this.menuOperations_menuTrans_lation___.Name = "menuOperations_menuTrans_lation___";
            this.menuOperations_menuTrans_lation___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Translation_1_Execute);
            this.menuOperations_menuTrans_lation___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Translation_1_Inquire);
            // 
            // menuOperations_menuChange__Company___
            // 
            resources.ApplyResources(this.menuOperations_menuChange__Company___, "menuOperations_menuChange__Company___");
            this.menuOperations_menuChange__Company___.Name = "menuOperations_menuChange__Company___";
            this.menuOperations_menuChange__Company___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Change_1_Execute);
            this.menuOperations_menuChange__Company___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Change_1_Inquire);
            // 
            // menuFrmMethods_menu_Voucher_Series___
            // 
            resources.ApplyResources(this.menuFrmMethods_menu_Voucher_Series___, "menuFrmMethods_menu_Voucher_Series___");
            this.menuFrmMethods_menu_Voucher_Series___.Name = "menuFrmMethods_menu_Voucher_Series___";
            this.menuFrmMethods_menu_Voucher_Series___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Voucher_Execute);
            this.menuFrmMethods_menu_Voucher_Series___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Voucher_Inquire);
            // 
            // menuFrmMethods_menu_Excluded_From_IL___
            // 
            resources.ApplyResources(this.menuFrmMethods_menu_Excluded_From_IL___, "menuFrmMethods_menu_Excluded_From_IL___");
            this.menuFrmMethods_menu_Excluded_From_IL___.Name = "menuFrmMethods_menu_Excluded_From_IL___";
            this.menuFrmMethods_menu_Excluded_From_IL___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Excluded_Execute);
            this.menuFrmMethods_menu_Excluded_From_IL___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Excluded_Inquire);
            // 
            // menuFrmMethods_menuTrans_lation___
            // 
            resources.ApplyResources(this.menuFrmMethods_menuTrans_lation___, "menuFrmMethods_menuTrans_lation___");
            this.menuFrmMethods_menuTrans_lation___.Name = "menuFrmMethods_menuTrans_lation___";
            this.menuFrmMethods_menuTrans_lation___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Translation_Execute);
            this.menuFrmMethods_menuTrans_lation___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Translation_Inquire);
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
            this.dfsCompany.NamedProperties.Put("FieldFlags", "71");
            this.dfsCompany.NamedProperties.Put("LovReference", "");
            this.dfsCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.dfsCompany.NamedProperties.Put("ValidateMethod", "");
            // 
            // labelcmbVoucherType
            // 
            resources.ApplyResources(this.labelcmbVoucherType, "labelcmbVoucherType");
            this.labelcmbVoucherType.Name = "labelcmbVoucherType";
            // 
            // cmbVoucherType
            // 
            resources.ApplyResources(this.cmbVoucherType, "cmbVoucherType");
            this.cmbVoucherType.Name = "cmbVoucherType";
            this.cmbVoucherType.NamedProperties.Put("EnumerateMethod", "");
            this.cmbVoucherType.NamedProperties.Put("FieldFlags", "99");
            this.cmbVoucherType.NamedProperties.Put("Format", "9");
            this.cmbVoucherType.NamedProperties.Put("LovReference", "");
            this.cmbVoucherType.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbVoucherType.NamedProperties.Put("SqlColumn", "VOUCHER_TYPE");
            this.cmbVoucherType.NamedProperties.Put("ValidateMethod", "");
            this.cmbVoucherType.NamedProperties.Put("XDataLength", "3");
            this.cmbVoucherType.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbVoucherType_WindowActions);
            // 
            // labeldfDescription
            // 
            resources.ApplyResources(this.labeldfDescription, "labeldfDescription");
            this.labeldfDescription.Name = "labeldfDescription";
            // 
            // dfDescription
            // 
            resources.ApplyResources(this.dfDescription, "dfDescription");
            this.dfDescription.Name = "dfDescription";
            this.dfDescription.NamedProperties.Put("EnumerateMethod", "");
            this.dfDescription.NamedProperties.Put("FieldFlags", "263");
            this.dfDescription.NamedProperties.Put("LovReference", "");
            this.dfDescription.NamedProperties.Put("ParentName", "cmbVoucherType");
            this.dfDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.dfDescription.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            this.dfDescription.NamedProperties.Put("ValidateMethod", "");
            // 
            // gbLedger_Selection
            // 
            resources.ApplyResources(this.gbLedger_Selection, "gbLedger_Selection");
            this.gbLedger_Selection.Name = "gbLedger_Selection";
            this.gbLedger_Selection.TabStop = false;
            // 
            // labelcmbLedger
            // 
            resources.ApplyResources(this.labelcmbLedger, "labelcmbLedger");
            this.labelcmbLedger.Name = "labelcmbLedger";
            // 
            // cmbLedger
            // 
            this.cmbLedger.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cmbLedger, "cmbLedger");
            this.cmbLedger.Name = "cmbLedger";
            this.cmbLedger.NamedProperties.Put("DataType", "7");
            this.cmbLedger.NamedProperties.Put("EnumerateMethod", "LEDGER_API.Enumerate");
            this.cmbLedger.NamedProperties.Put("FieldFlags", "294");
            this.cmbLedger.NamedProperties.Put("LovReference", "");
            this.cmbLedger.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbLedger.NamedProperties.Put("SqlColumn", "LEDGER");
            this.cmbLedger.NamedProperties.Put("ValidateMethod", "");
            this.cmbLedger.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbLedger_WindowActions);
            // 
            // labeldfLedgerID
            // 
            resources.ApplyResources(this.labeldfLedgerID, "labeldfLedgerID");
            this.labeldfLedgerID.Name = "labeldfLedgerID";
            // 
            // dfLedgerID
            // 
            this.dfLedgerID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfLedgerID, "dfLedgerID");
            this.dfLedgerID.Name = "dfLedgerID";
            this.dfLedgerID.NamedProperties.Put("EnumerateMethod", "");
            this.dfLedgerID.NamedProperties.Put("FieldFlags", "295");
            this.dfLedgerID.NamedProperties.Put("LovReference", "INTERNAL_LEDGER_CURRENT(COMPANY)");
            this.dfLedgerID.NamedProperties.Put("ResizeableChildObject", "");
            this.dfLedgerID.NamedProperties.Put("SqlColumn", "LEDGER_ID");
            this.dfLedgerID.NamedProperties.Put("ValidateMethod", "");
            // 
            // cbUseMIM
            // 
            resources.ApplyResources(this.cbUseMIM, "cbUseMIM");
            this.cbUseMIM.Name = "cbUseMIM";
            this.cbUseMIM.NamedProperties.Put("DataType", "5");
            this.cbUseMIM.NamedProperties.Put("EnumerateMethod", "");
            this.cbUseMIM.NamedProperties.Put("FieldFlags", "262");
            this.cbUseMIM.NamedProperties.Put("LovReference", "");
            this.cbUseMIM.NamedProperties.Put("ResizeableChildObject", "");
            this.cbUseMIM.NamedProperties.Put("SqlColumn", "USE_MANUAL");
            this.cbUseMIM.NamedProperties.Put("ValidateMethod", "");
            this.cbUseMIM.NamedProperties.Put("XDataLength", "1");
            this.cbUseMIM.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cbUseMIM_WindowActions);
            // 
            // cbBalance
            // 
            resources.ApplyResources(this.cbBalance, "cbBalance");
            this.cbBalance.Name = "cbBalance";
            this.cbBalance.NamedProperties.Put("DataType", "5");
            this.cbBalance.NamedProperties.Put("EnumerateMethod", "");
            this.cbBalance.NamedProperties.Put("FieldFlags", "262");
            this.cbBalance.NamedProperties.Put("LovReference", "");
            this.cbBalance.NamedProperties.Put("ResizeableChildObject", "");
            this.cbBalance.NamedProperties.Put("SqlColumn", "BALANCE");
            this.cbBalance.NamedProperties.Put("ValidateMethod", "");
            this.cbBalance.NamedProperties.Put("XDataLength", "6");
            this.cbBalance.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cbBalance_WindowActions);
            // 
            // gbVoucher_Selection
            // 
            resources.ApplyResources(this.gbVoucher_Selection, "gbVoucher_Selection");
            this.gbVoucher_Selection.Name = "gbVoucher_Selection";
            this.gbVoucher_Selection.TabStop = false;
            // 
            // cbAutoAllotment
            // 
            resources.ApplyResources(this.cbAutoAllotment, "cbAutoAllotment");
            this.cbAutoAllotment.Name = "cbAutoAllotment";
            this.cbAutoAllotment.NamedProperties.Put("DataType", "5");
            this.cbAutoAllotment.NamedProperties.Put("EnumerateMethod", "AUTOMATIC_ALLOTMENT_API.Enumerate");
            this.cbAutoAllotment.NamedProperties.Put("FieldFlags", "294");
            this.cbAutoAllotment.NamedProperties.Put("LovReference", "");
            this.cbAutoAllotment.NamedProperties.Put("ResizeableChildObject", "");
            this.cbAutoAllotment.NamedProperties.Put("SqlColumn", "AUTOMATIC_ALLOT_DB");
            this.cbAutoAllotment.NamedProperties.Put("ValidateMethod", "");
            this.cbAutoAllotment.NamedProperties.Put("XDataLength", "1");
            this.cbAutoAllotment.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cbAutoAllotment_WindowActions);
            // 
            // cbSimulationVou
            // 
            resources.ApplyResources(this.cbSimulationVou, "cbSimulationVou");
            this.cbSimulationVou.Name = "cbSimulationVou";
            this.cbSimulationVou.NamedProperties.Put("DataType", "5");
            this.cbSimulationVou.NamedProperties.Put("EnumerateMethod", "");
            this.cbSimulationVou.NamedProperties.Put("FieldFlags", "294");
            this.cbSimulationVou.NamedProperties.Put("LovReference", "");
            this.cbSimulationVou.NamedProperties.Put("ResizeableChildObject", "");
            this.cbSimulationVou.NamedProperties.Put("SqlColumn", "SIMULATION_VOUCHER");
            this.cbSimulationVou.NamedProperties.Put("ValidateMethod", "");
            this.cbSimulationVou.NamedProperties.Put("XDataLength", "1");
            this.cbSimulationVou.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cbSimulationVou_WindowActions);
            // 
            // cbSingleFunction
            // 
            resources.ApplyResources(this.cbSingleFunction, "cbSingleFunction");
            this.cbSingleFunction.Name = "cbSingleFunction";
            this.cbSingleFunction.NamedProperties.Put("DataType", "5");
            this.cbSingleFunction.NamedProperties.Put("EnumerateMethod", "");
            this.cbSingleFunction.NamedProperties.Put("FieldFlags", "294");
            this.cbSingleFunction.NamedProperties.Put("LovReference", "");
            this.cbSingleFunction.NamedProperties.Put("ResizeableChildObject", "");
            this.cbSingleFunction.NamedProperties.Put("SqlColumn", "SINGLE_FUNCTION_GROUP");
            this.cbSingleFunction.NamedProperties.Put("ValidateMethod", "");
            this.cbSingleFunction.NamedProperties.Put("XDataLength", "1");
            this.cbSingleFunction.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cbSingleFunction_WindowActions);
            // 
            // labeldfsOptionalAutoBalance
            // 
            resources.ApplyResources(this.labeldfsOptionalAutoBalance, "labeldfsOptionalAutoBalance");
            this.labeldfsOptionalAutoBalance.Name = "labeldfsOptionalAutoBalance";
            // 
            // dfsOptionalAutoBalance
            // 
            resources.ApplyResources(this.dfsOptionalAutoBalance, "dfsOptionalAutoBalance");
            this.dfsOptionalAutoBalance.Name = "dfsOptionalAutoBalance";
            this.dfsOptionalAutoBalance.NamedProperties.Put("EnumerateMethod", "");
            this.dfsOptionalAutoBalance.NamedProperties.Put("LovReference", "");
            this.dfsOptionalAutoBalance.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsOptionalAutoBalance.NamedProperties.Put("SqlColumn", "AUTOMATIC_VOU_BALANCE_DB");
            this.dfsOptionalAutoBalance.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsStoreOriginal
            // 
            resources.ApplyResources(this.labeldfsStoreOriginal, "labeldfsStoreOriginal");
            this.labeldfsStoreOriginal.Name = "labeldfsStoreOriginal";
            // 
            // dfsStoreOriginal
            // 
            this.dfsStoreOriginal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsStoreOriginal, "dfsStoreOriginal");
            this.dfsStoreOriginal.Name = "dfsStoreOriginal";
            this.dfsStoreOriginal.NamedProperties.Put("EnumerateMethod", "");
            this.dfsStoreOriginal.NamedProperties.Put("LovReference", "");
            this.dfsStoreOriginal.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsStoreOriginal.NamedProperties.Put("SqlColumn", "STORE_ORIGINAL_DB");
            this.dfsStoreOriginal.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsLabelPrint
            // 
            resources.ApplyResources(this.labeldfsLabelPrint, "labeldfsLabelPrint");
            this.labeldfsLabelPrint.Name = "labeldfsLabelPrint";
            // 
            // dfsLabelPrint
            // 
            resources.ApplyResources(this.dfsLabelPrint, "dfsLabelPrint");
            this.dfsLabelPrint.Name = "dfsLabelPrint";
            this.dfsLabelPrint.NamedProperties.Put("EnumerateMethod", "");
            this.dfsLabelPrint.NamedProperties.Put("LovReference", "");
            this.dfsLabelPrint.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsLabelPrint.NamedProperties.Put("SqlColumn", "LABLE_PRINT_DB");
            this.dfsLabelPrint.NamedProperties.Put("ValidateMethod", "");
            // 
            // menuFrmMethods
            // 
            this.menuFrmMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem__Voucher,
            this.menuSeparator1,
            this.menuItem__Excluded,
            this.menuSeparator2,
            this.menuItem_Translation,
            this.menuSeparator3,
            this.menuItem_Change});
            this.menuFrmMethods.Name = "menuFrmMethods";
            resources.ApplyResources(this.menuFrmMethods, "menuFrmMethods");
            // 
            // menuItem__Voucher
            // 
            this.menuItem__Voucher.Command = this.menuFrmMethods_menu_Voucher_Series___;
            this.menuItem__Voucher.Name = "menuItem__Voucher";
            resources.ApplyResources(this.menuItem__Voucher, "menuItem__Voucher");
            this.menuItem__Voucher.Text = "&Voucher Series...";
            // 
            // menuSeparator1
            // 
            this.menuSeparator1.Name = "menuSeparator1";
            resources.ApplyResources(this.menuSeparator1, "menuSeparator1");
            // 
            // menuItem__Excluded
            // 
            this.menuItem__Excluded.Command = this.menuFrmMethods_menu_Excluded_From_IL___;
            this.menuItem__Excluded.Name = "menuItem__Excluded";
            resources.ApplyResources(this.menuItem__Excluded, "menuItem__Excluded");
            this.menuItem__Excluded.Text = "&Excluded From IL...";
            // 
            // menuSeparator2
            // 
            this.menuSeparator2.Name = "menuSeparator2";
            resources.ApplyResources(this.menuSeparator2, "menuSeparator2");
            // 
            // menuItem_Translation
            // 
            this.menuItem_Translation.Command = this.menuFrmMethods_menuTrans_lation___;
            this.menuItem_Translation.Name = "menuItem_Translation";
            resources.ApplyResources(this.menuItem_Translation, "menuItem_Translation");
            this.menuItem_Translation.Text = "Trans&lation...";
            // 
            // menuSeparator3
            // 
            this.menuSeparator3.Name = "menuSeparator3";
            resources.ApplyResources(this.menuSeparator3, "menuSeparator3");
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
            this.menuItem__Voucher_1,
            this.menuSeparator4,
            this.menuItem_Translation_1,
            this.menuSeparator5,
            this.menuItem_Change_1});
            this.menuOperations.Name = "menuOperations";
            resources.ApplyResources(this.menuOperations, "menuOperations");
            // 
            // menuItem__Voucher_1
            // 
            this.menuItem__Voucher_1.Command = this.menuOperations_menu_Voucher_Series___;
            this.menuItem__Voucher_1.Name = "menuItem__Voucher_1";
            resources.ApplyResources(this.menuItem__Voucher_1, "menuItem__Voucher_1");
            this.menuItem__Voucher_1.Text = "&Voucher Series...";
            // 
            // menuSeparator4
            // 
            this.menuSeparator4.Name = "menuSeparator4";
            resources.ApplyResources(this.menuSeparator4, "menuSeparator4");
            // 
            // menuItem_Translation_1
            // 
            this.menuItem_Translation_1.Command = this.menuOperations_menuTrans_lation___;
            this.menuItem_Translation_1.Name = "menuItem_Translation_1";
            resources.ApplyResources(this.menuItem_Translation_1, "menuItem_Translation_1");
            this.menuItem_Translation_1.Text = "Trans&lation...";
            // 
            // menuSeparator5
            // 
            this.menuSeparator5.Name = "menuSeparator5";
            resources.ApplyResources(this.menuSeparator5, "menuSeparator5");
            // 
            // menuItem_Change_1
            // 
            this.menuItem_Change_1.Command = this.menuOperations_menuChange__Company___;
            this.menuItem_Change_1.Name = "menuItem_Change_1";
            resources.ApplyResources(this.menuItem_Change_1, "menuItem_Change_1");
            this.menuItem_Change_1.Text = "Change &Company...";
            // 
            // tblVoucherTypeDetail
            // 
            this.tblVoucherTypeDetail.Controls.Add(this.tblVoucherTypeDetail_colsCompany);
            this.tblVoucherTypeDetail.Controls.Add(this.tblVoucherTypeDetail_colsVoucherType);
            this.tblVoucherTypeDetail.Controls.Add(this.tblVoucherTypeDetail_colsVoucherFunction);
            this.tblVoucherTypeDetail.Controls.Add(this.tblVoucherTypeDetail_colDescription);
            this.tblVoucherTypeDetail.Controls.Add(this.tblVoucherTypeDetail_colsOptionalAutoBalance);
            this.tblVoucherTypeDetail.Controls.Add(this.tblVoucherTypeDetail_colsStoreOriginal);
            this.tblVoucherTypeDetail.Controls.Add(this.tblVoucherTypeDetail_colsRowGrpValidation);
            this.tblVoucherTypeDetail.Controls.Add(this.tblVoucherTypeDetail_colsRefMandetory);
            this.tblVoucherTypeDetail.Controls.Add(this.tblVoucherTypeDetail_colsAutomaticAllot);
            this.tblVoucherTypeDetail.Controls.Add(this.tblVoucherTypeDetail_colsSingleVoucher);
            resources.ApplyResources(this.tblVoucherTypeDetail, "tblVoucherTypeDetail");
            this.tblVoucherTypeDetail.Name = "tblVoucherTypeDetail";
            this.tblVoucherTypeDetail.NamedProperties.Put("DefaultOrderBy", "function_group");
            this.tblVoucherTypeDetail.NamedProperties.Put("DefaultWhere", "company = :global.company");
            this.tblVoucherTypeDetail.NamedProperties.Put("LogicalUnit", "VoucherTypeDetail");
            this.tblVoucherTypeDetail.NamedProperties.Put("PackageName", "VOUCHER_TYPE_DETAIL_API");
            this.tblVoucherTypeDetail.NamedProperties.Put("ResizeableChildObject", "LLMM");
            this.tblVoucherTypeDetail.NamedProperties.Put("ViewName", "VOUCHER_TYPE_DETAIL");
            this.tblVoucherTypeDetail.NamedProperties.Put("Warnings", "FALSE");
            this.tblVoucherTypeDetail.DataRecordGetDefaultsEvent += new System.EventHandler<Ifs.Fnd.ApplicationForms.FndReturnEventArgsSalBoolean>(this.tblVoucherTypeDetail_DataRecordGetDefaultsEvent);
            this.tblVoucherTypeDetail.DataRecordNewEvent += new Ifs.Fnd.ApplicationForms.cDataSource.DataRecordNewEventHandler(this.tblVoucherTypeDetail_DataRecordNewEvent);
            this.tblVoucherTypeDetail.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVoucherTypeDetail_WindowActions);
            this.tblVoucherTypeDetail.Controls.SetChildIndex(this.tblVoucherTypeDetail_colsSingleVoucher, 0);
            this.tblVoucherTypeDetail.Controls.SetChildIndex(this.tblVoucherTypeDetail_colsAutomaticAllot, 0);
            this.tblVoucherTypeDetail.Controls.SetChildIndex(this.tblVoucherTypeDetail_colsRefMandetory, 0);
            this.tblVoucherTypeDetail.Controls.SetChildIndex(this.tblVoucherTypeDetail_colsRowGrpValidation, 0);
            this.tblVoucherTypeDetail.Controls.SetChildIndex(this.tblVoucherTypeDetail_colsStoreOriginal, 0);
            this.tblVoucherTypeDetail.Controls.SetChildIndex(this.tblVoucherTypeDetail_colsOptionalAutoBalance, 0);
            this.tblVoucherTypeDetail.Controls.SetChildIndex(this.tblVoucherTypeDetail_colDescription, 0);
            this.tblVoucherTypeDetail.Controls.SetChildIndex(this.tblVoucherTypeDetail_colsVoucherFunction, 0);
            this.tblVoucherTypeDetail.Controls.SetChildIndex(this.tblVoucherTypeDetail_colsVoucherType, 0);
            this.tblVoucherTypeDetail.Controls.SetChildIndex(this.tblVoucherTypeDetail_colsCompany, 0);
            // 
            // tblVoucherTypeDetail_colsCompany
            // 
            this.tblVoucherTypeDetail_colsCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblVoucherTypeDetail_colsCompany, "tblVoucherTypeDetail_colsCompany");
            this.tblVoucherTypeDetail_colsCompany.MaxLength = 20;
            this.tblVoucherTypeDetail_colsCompany.Name = "tblVoucherTypeDetail_colsCompany";
            this.tblVoucherTypeDetail_colsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherTypeDetail_colsCompany.NamedProperties.Put("FieldFlags", "67");
            this.tblVoucherTypeDetail_colsCompany.NamedProperties.Put("LovReference", "");
            this.tblVoucherTypeDetail_colsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.tblVoucherTypeDetail_colsCompany.Position = 3;
            // 
            // tblVoucherTypeDetail_colsVoucherType
            // 
            this.tblVoucherTypeDetail_colsVoucherType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblVoucherTypeDetail_colsVoucherType, "tblVoucherTypeDetail_colsVoucherType");
            this.tblVoucherTypeDetail_colsVoucherType.MaxLength = 3;
            this.tblVoucherTypeDetail_colsVoucherType.Name = "tblVoucherTypeDetail_colsVoucherType";
            this.tblVoucherTypeDetail_colsVoucherType.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherTypeDetail_colsVoucherType.NamedProperties.Put("FieldFlags", "67");
            this.tblVoucherTypeDetail_colsVoucherType.NamedProperties.Put("LovReference", "VOUCHER_TYPE(COMPANY)");
            this.tblVoucherTypeDetail_colsVoucherType.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherTypeDetail_colsVoucherType.NamedProperties.Put("SqlColumn", "VOUCHER_TYPE");
            this.tblVoucherTypeDetail_colsVoucherType.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherTypeDetail_colsVoucherType.Position = 4;
            // 
            // tblVoucherTypeDetail_colsVoucherFunction
            // 
            this.tblVoucherTypeDetail_colsVoucherFunction.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblVoucherTypeDetail_colsVoucherFunction.Name = "tblVoucherTypeDetail_colsVoucherFunction";
            this.tblVoucherTypeDetail_colsVoucherFunction.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherTypeDetail_colsVoucherFunction.NamedProperties.Put("FieldFlags", "167");
            this.tblVoucherTypeDetail_colsVoucherFunction.NamedProperties.Put("LovReference", "FUNCTION_GROUP");
            this.tblVoucherTypeDetail_colsVoucherFunction.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherTypeDetail_colsVoucherFunction.NamedProperties.Put("SqlColumn", "FUNCTION_GROUP");
            this.tblVoucherTypeDetail_colsVoucherFunction.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherTypeDetail_colsVoucherFunction.Position = 5;
            resources.ApplyResources(this.tblVoucherTypeDetail_colsVoucherFunction, "tblVoucherTypeDetail_colsVoucherFunction");
            this.tblVoucherTypeDetail_colsVoucherFunction.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVoucherTypeDetail_colsVoucherFunction_WindowActions);
            // 
            // tblVoucherTypeDetail_colDescription
            // 
            this.tblVoucherTypeDetail_colDescription.MaxLength = 2000;
            this.tblVoucherTypeDetail_colDescription.Name = "tblVoucherTypeDetail_colDescription";
            this.tblVoucherTypeDetail_colDescription.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherTypeDetail_colDescription.NamedProperties.Put("FieldFlags", "288");
            this.tblVoucherTypeDetail_colDescription.NamedProperties.Put("LovReference", "");
            this.tblVoucherTypeDetail_colDescription.NamedProperties.Put("ParentName", "tblVoucherTypeDetail.tblVoucherTypeDetail_colsVoucherFunction");
            this.tblVoucherTypeDetail_colDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherTypeDetail_colDescription.NamedProperties.Put("SqlColumn", "FUNCTION_GROUP_API.Get_Description(FUNCTION_GROUP)");
            this.tblVoucherTypeDetail_colDescription.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherTypeDetail_colDescription.Position = 6;
            resources.ApplyResources(this.tblVoucherTypeDetail_colDescription, "tblVoucherTypeDetail_colDescription");
            // 
            // tblVoucherTypeDetail_colsOptionalAutoBalance
            // 
            this.tblVoucherTypeDetail_colsOptionalAutoBalance.CheckBox.CheckedValue = "Y";
            this.tblVoucherTypeDetail_colsOptionalAutoBalance.CheckBox.IgnoreCase = true;
            this.tblVoucherTypeDetail_colsOptionalAutoBalance.CheckBox.UncheckedValue = "N";
            this.tblVoucherTypeDetail_colsOptionalAutoBalance.MaxLength = 1;
            this.tblVoucherTypeDetail_colsOptionalAutoBalance.Name = "tblVoucherTypeDetail_colsOptionalAutoBalance";
            this.tblVoucherTypeDetail_colsOptionalAutoBalance.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherTypeDetail_colsOptionalAutoBalance.NamedProperties.Put("FieldFlags", "294");
            this.tblVoucherTypeDetail_colsOptionalAutoBalance.NamedProperties.Put("LovReference", "");
            this.tblVoucherTypeDetail_colsOptionalAutoBalance.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherTypeDetail_colsOptionalAutoBalance.NamedProperties.Put("SqlColumn", "AUTOMATIC_VOU_BALANCE");
            this.tblVoucherTypeDetail_colsOptionalAutoBalance.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherTypeDetail_colsOptionalAutoBalance.Position = 7;
            resources.ApplyResources(this.tblVoucherTypeDetail_colsOptionalAutoBalance, "tblVoucherTypeDetail_colsOptionalAutoBalance");
            // 
            // tblVoucherTypeDetail_colsStoreOriginal
            // 
            this.tblVoucherTypeDetail_colsStoreOriginal.CheckBox.CheckedValue = "Y";
            this.tblVoucherTypeDetail_colsStoreOriginal.CheckBox.IgnoreCase = true;
            this.tblVoucherTypeDetail_colsStoreOriginal.CheckBox.UncheckedValue = "N";
            this.tblVoucherTypeDetail_colsStoreOriginal.MaxLength = 3;
            this.tblVoucherTypeDetail_colsStoreOriginal.Name = "tblVoucherTypeDetail_colsStoreOriginal";
            this.tblVoucherTypeDetail_colsStoreOriginal.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherTypeDetail_colsStoreOriginal.NamedProperties.Put("FieldFlags", "294");
            this.tblVoucherTypeDetail_colsStoreOriginal.NamedProperties.Put("LovReference", "");
            this.tblVoucherTypeDetail_colsStoreOriginal.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherTypeDetail_colsStoreOriginal.NamedProperties.Put("SqlColumn", "STORE_ORIGINAL_DB");
            this.tblVoucherTypeDetail_colsStoreOriginal.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherTypeDetail_colsStoreOriginal.Position = 8;
            resources.ApplyResources(this.tblVoucherTypeDetail_colsStoreOriginal, "tblVoucherTypeDetail_colsStoreOriginal");
            this.tblVoucherTypeDetail_colsStoreOriginal.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVoucherTypeDetail_colsStoreOriginal_WindowActions);
            // 
            // tblVoucherTypeDetail_colsRowGrpValidation
            // 
            this.tblVoucherTypeDetail_colsRowGrpValidation.CheckBox.CheckedValue = "Y";
            this.tblVoucherTypeDetail_colsRowGrpValidation.CheckBox.IgnoreCase = true;
            this.tblVoucherTypeDetail_colsRowGrpValidation.CheckBox.UncheckedValue = "N";
            this.tblVoucherTypeDetail_colsRowGrpValidation.MaxLength = 3;
            this.tblVoucherTypeDetail_colsRowGrpValidation.Name = "tblVoucherTypeDetail_colsRowGrpValidation";
            this.tblVoucherTypeDetail_colsRowGrpValidation.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherTypeDetail_colsRowGrpValidation.NamedProperties.Put("FieldFlags", "294");
            this.tblVoucherTypeDetail_colsRowGrpValidation.NamedProperties.Put("LovReference", "");
            this.tblVoucherTypeDetail_colsRowGrpValidation.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherTypeDetail_colsRowGrpValidation.NamedProperties.Put("SqlColumn", "ROW_GROUP_VALIDATION");
            this.tblVoucherTypeDetail_colsRowGrpValidation.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherTypeDetail_colsRowGrpValidation.Position = 9;
            resources.ApplyResources(this.tblVoucherTypeDetail_colsRowGrpValidation, "tblVoucherTypeDetail_colsRowGrpValidation");
            this.tblVoucherTypeDetail_colsRowGrpValidation.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVoucherTypeDetail_colsRowGrpValidation_WindowActions);
            // 
            // tblVoucherTypeDetail_colsRefMandetory
            // 
            this.tblVoucherTypeDetail_colsRefMandetory.CheckBox.CheckedValue = "Y";
            this.tblVoucherTypeDetail_colsRefMandetory.CheckBox.IgnoreCase = true;
            this.tblVoucherTypeDetail_colsRefMandetory.CheckBox.UncheckedValue = "N";
            this.tblVoucherTypeDetail_colsRefMandetory.MaxLength = 3;
            this.tblVoucherTypeDetail_colsRefMandetory.Name = "tblVoucherTypeDetail_colsRefMandetory";
            this.tblVoucherTypeDetail_colsRefMandetory.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherTypeDetail_colsRefMandetory.NamedProperties.Put("FieldFlags", "294");
            this.tblVoucherTypeDetail_colsRefMandetory.NamedProperties.Put("LovReference", "");
            this.tblVoucherTypeDetail_colsRefMandetory.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherTypeDetail_colsRefMandetory.NamedProperties.Put("SqlColumn", "REFERENCE_MANDATORY");
            this.tblVoucherTypeDetail_colsRefMandetory.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherTypeDetail_colsRefMandetory.Position = 10;
            resources.ApplyResources(this.tblVoucherTypeDetail_colsRefMandetory, "tblVoucherTypeDetail_colsRefMandetory");
            this.tblVoucherTypeDetail_colsRefMandetory.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVoucherTypeDetail_colsRefMandetory_WindowActions);
            // 
            // tblVoucherTypeDetail_colsAutomaticAllot
            // 
            this.tblVoucherTypeDetail_colsAutomaticAllot.CheckBox.CheckedValue = "Y";
            this.tblVoucherTypeDetail_colsAutomaticAllot.CheckBox.IgnoreCase = true;
            this.tblVoucherTypeDetail_colsAutomaticAllot.CheckBox.UncheckedValue = "N";
            resources.ApplyResources(this.tblVoucherTypeDetail_colsAutomaticAllot, "tblVoucherTypeDetail_colsAutomaticAllot");
            this.tblVoucherTypeDetail_colsAutomaticAllot.MaxLength = 1;
            this.tblVoucherTypeDetail_colsAutomaticAllot.Name = "tblVoucherTypeDetail_colsAutomaticAllot";
            this.tblVoucherTypeDetail_colsAutomaticAllot.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherTypeDetail_colsAutomaticAllot.NamedProperties.Put("FieldFlags", "288");
            this.tblVoucherTypeDetail_colsAutomaticAllot.NamedProperties.Put("LovReference", "");
            this.tblVoucherTypeDetail_colsAutomaticAllot.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherTypeDetail_colsAutomaticAllot.NamedProperties.Put("SqlColumn", "AUTOMATIC_ALLOT_DB");
            this.tblVoucherTypeDetail_colsAutomaticAllot.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherTypeDetail_colsAutomaticAllot.Position = 11;
            // 
            // tblVoucherTypeDetail_colsSingleVoucher
            // 
            this.tblVoucherTypeDetail_colsSingleVoucher.CheckBox.CheckedValue = "Y";
            this.tblVoucherTypeDetail_colsSingleVoucher.CheckBox.IgnoreCase = true;
            this.tblVoucherTypeDetail_colsSingleVoucher.CheckBox.UncheckedValue = "N";
            resources.ApplyResources(this.tblVoucherTypeDetail_colsSingleVoucher, "tblVoucherTypeDetail_colsSingleVoucher");
            this.tblVoucherTypeDetail_colsSingleVoucher.MaxLength = 1;
            this.tblVoucherTypeDetail_colsSingleVoucher.Name = "tblVoucherTypeDetail_colsSingleVoucher";
            this.tblVoucherTypeDetail_colsSingleVoucher.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherTypeDetail_colsSingleVoucher.NamedProperties.Put("FieldFlags", "288");
            this.tblVoucherTypeDetail_colsSingleVoucher.NamedProperties.Put("LovReference", "");
            this.tblVoucherTypeDetail_colsSingleVoucher.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherTypeDetail_colsSingleVoucher.NamedProperties.Put("SqlColumn", "SINGLE_FUNCTION_GROUP");
            this.tblVoucherTypeDetail_colsSingleVoucher.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherTypeDetail_colsSingleVoucher.Position = 12;
            // 
            // frmVoucherType
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.dfsLabelPrint);
            this.Controls.Add(this.dfsStoreOriginal);
            this.Controls.Add(this.dfsOptionalAutoBalance);
            this.Controls.Add(this.tblVoucherTypeDetail);
            this.Controls.Add(this.cbSingleFunction);
            this.Controls.Add(this.cbSimulationVou);
            this.Controls.Add(this.cbAutoAllotment);
            this.Controls.Add(this.cbBalance);
            this.Controls.Add(this.cbUseMIM);
            this.Controls.Add(this.dfLedgerID);
            this.Controls.Add(this.cmbLedger);
            this.Controls.Add(this.dfDescription);
            this.Controls.Add(this.cmbVoucherType);
            this.Controls.Add(this.dfsCompany);
            this.Controls.Add(this.labeldfsLabelPrint);
            this.Controls.Add(this.labeldfsStoreOriginal);
            this.Controls.Add(this.labeldfsOptionalAutoBalance);
            this.Controls.Add(this.labeldfLedgerID);
            this.Controls.Add(this.labelcmbLedger);
            this.Controls.Add(this.labeldfDescription);
            this.Controls.Add(this.labelcmbVoucherType);
            this.Controls.Add(this.labeldfsCompany);
            this.Controls.Add(this.gbVoucher_Selection);
            this.Controls.Add(this.gbLedger_Selection);
            this.MaximizeBox = true;
            this.Name = "frmVoucherType";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "company = :global.company");
            this.NamedProperties.Put("LogicalUnit", "VoucherType");
            this.NamedProperties.Put("PackageName", "VOUCHER_TYPE_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("ViewName", "VOUCHER_TYPE");
            this.NamedProperties.Put("Warnings", "TRUE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.frmVoucherType_WindowActions);
            this.menuFrmMethods.ResumeLayout(false);
            this.menuOperations.ResumeLayout(false);
            this.tblVoucherTypeDetail.ResumeLayout(false);
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
		
		public Fnd.Windows.Forms.FndCommand menuOperations_menu_Voucher_Series___;
        public Fnd.Windows.Forms.FndCommand menuOperations_menuTrans_lation___;
        public Fnd.Windows.Forms.FndCommand menuOperations_menuChange__Company___;
        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menu_Voucher_Series___;
        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menu_Excluded_From_IL___;
        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menuTrans_lation___;
        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menuChange__Company___;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuFrmMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Voucher;
        protected Fnd.Windows.Forms.FndToolStripSeparator menuSeparator1;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Excluded;
        protected Fnd.Windows.Forms.FndToolStripSeparator menuSeparator2;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Translation;
        protected Fnd.Windows.Forms.FndToolStripSeparator menuSeparator3;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuOperations;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Voucher_1;
        protected Fnd.Windows.Forms.FndToolStripSeparator menuSeparator4;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Translation_1;
        protected Fnd.Windows.Forms.FndToolStripSeparator menuSeparator5;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change_1;
        public cChildTableFin tblVoucherTypeDetail;
        protected cColumn tblVoucherTypeDetail_colsCompany;
        protected cColumn tblVoucherTypeDetail_colsVoucherType;
        protected cColumn tblVoucherTypeDetail_colsVoucherFunction;
        protected cColumn tblVoucherTypeDetail_colDescription;
        protected cCheckBoxColumn tblVoucherTypeDetail_colsOptionalAutoBalance;
        protected cCheckBoxColumn tblVoucherTypeDetail_colsStoreOriginal;
        protected cCheckBoxColumn tblVoucherTypeDetail_colsRowGrpValidation;
        protected cCheckBoxColumn tblVoucherTypeDetail_colsRefMandetory;
        protected cCheckBoxColumn tblVoucherTypeDetail_colsAutomaticAllot;
        protected cCheckBoxColumn tblVoucherTypeDetail_colsSingleVoucher;
	}
}
