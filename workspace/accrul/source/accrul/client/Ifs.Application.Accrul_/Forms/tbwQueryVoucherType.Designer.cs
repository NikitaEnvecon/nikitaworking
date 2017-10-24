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
	
	public partial class tbwQueryVoucherType
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cColumn colsCompany;
		public cColumn colsVoucherType;
		public cColumn colsVtDescription;
		public cColumn colsVoucherFunction;
		public cColumn colsFunctionGrpDesc;
		public cColumn colsLedger;
		public cColumn colsLedgerId;
		public cColumn colsBalance;
		public cColumn colsUseManual;
		public cColumn colsAutomaticAllotDb;
		public cColumn colsVtSingleFunctionGroup;
		public cColumn colsSimulationVoucher;
		public cColumn colsAutomaticVouBalance;
		public cColumn colsStoreOriginalDb;
		public cColumn colsRowGrpValidation;
		public cColumn colsRefMandetory;
		public cColumn colsJournalId;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwQueryVoucherType));
            this.menuTbwMethods_menuChange__Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuOperations_menuChange__Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.colsCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsVoucherType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsVtDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsVoucherFunction = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsFunctionGrpDesc = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsLedger = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsLedgerId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsBalance = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsUseManual = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsAutomaticAllotDb = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsVtSingleFunctionGroup = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsSimulationVoucher = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsAutomaticVouBalance = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsStoreOriginalDb = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsRowGrpValidation = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsRefMandetory = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsJournalId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.menuOperations = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_Change = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuTbwMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_Change_1 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuOperations.SuspendLayout();
            this.menuTbwMethods.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuOperations_menuChange__Company___);
            this.commandManager.Commands.Add(this.menuTbwMethods_menuChange__Company___);
            this.commandManager.ContextMenus.Add(this.menuOperations);
            this.commandManager.ContextMenus.Add(this.menuTbwMethods);
            // 
            // menuTbwMethods_menuChange__Company___
            // 
            resources.ApplyResources(this.menuTbwMethods_menuChange__Company___, "menuTbwMethods_menuChange__Company___");
            this.menuTbwMethods_menuChange__Company___.Name = "menuTbwMethods_menuChange__Company___";
            this.menuTbwMethods_menuChange__Company___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Change_1_Execute);
            this.menuTbwMethods_menuChange__Company___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Change_1_Inquire);
            // 
            // menuOperations_menuChange__Company___
            // 
            resources.ApplyResources(this.menuOperations_menuChange__Company___, "menuOperations_menuChange__Company___");
            this.menuOperations_menuChange__Company___.Name = "menuOperations_menuChange__Company___";
            this.menuOperations_menuChange__Company___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Change_Execute);
            this.menuOperations_menuChange__Company___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Change_Inquire);
            // 
            // colsCompany
            // 
            this.colsCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.colsCompany, "colsCompany");
            this.colsCompany.MaxLength = 20;
            this.colsCompany.Name = "colsCompany";
            this.colsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.colsCompany.NamedProperties.Put("FieldFlags", "67");
            this.colsCompany.NamedProperties.Put("LovReference", "");
            this.colsCompany.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.colsCompany.Position = 3;
            // 
            // colsVoucherType
            // 
            this.colsVoucherType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsVoucherType.MaxLength = 3;
            this.colsVoucherType.Name = "colsVoucherType";
            this.colsVoucherType.NamedProperties.Put("EnumerateMethod", "");
            this.colsVoucherType.NamedProperties.Put("FieldFlags", "99");
            this.colsVoucherType.NamedProperties.Put("LovReference", "VOUCHER_TYPE(COMPANY)");
            this.colsVoucherType.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsVoucherType.NamedProperties.Put("ResizeableChildObject", "");
            this.colsVoucherType.NamedProperties.Put("SqlColumn", "VOUCHER_TYPE");
            this.colsVoucherType.NamedProperties.Put("ValidateMethod", "");
            this.colsVoucherType.Position = 4;
            resources.ApplyResources(this.colsVoucherType, "colsVoucherType");
            // 
            // colsVtDescription
            // 
            this.colsVtDescription.Name = "colsVtDescription";
            this.colsVtDescription.NamedProperties.Put("EnumerateMethod", "");
            this.colsVtDescription.NamedProperties.Put("FieldFlags", "295");
            this.colsVtDescription.NamedProperties.Put("LovReference", "");
            this.colsVtDescription.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsVtDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.colsVtDescription.NamedProperties.Put("SqlColumn", "VT_DESCRIPTION");
            this.colsVtDescription.NamedProperties.Put("ValidateMethod", "");
            this.colsVtDescription.Position = 5;
            resources.ApplyResources(this.colsVtDescription, "colsVtDescription");
            // 
            // colsVoucherFunction
            // 
            this.colsVoucherFunction.Name = "colsVoucherFunction";
            this.colsVoucherFunction.NamedProperties.Put("EnumerateMethod", "");
            this.colsVoucherFunction.NamedProperties.Put("FieldFlags", "163");
            this.colsVoucherFunction.NamedProperties.Put("LovReference", "FUNCTION_GROUP");
            this.colsVoucherFunction.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsVoucherFunction.NamedProperties.Put("ResizeableChildObject", "");
            this.colsVoucherFunction.NamedProperties.Put("SqlColumn", "FUNCTION_GROUP");
            this.colsVoucherFunction.NamedProperties.Put("ValidateMethod", "");
            this.colsVoucherFunction.Position = 6;
            resources.ApplyResources(this.colsVoucherFunction, "colsVoucherFunction");
            this.colsVoucherFunction.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsVoucherFunction_WindowActions);
            // 
            // colsFunctionGrpDesc
            // 
            this.colsFunctionGrpDesc.MaxLength = 2000;
            this.colsFunctionGrpDesc.Name = "colsFunctionGrpDesc";
            this.colsFunctionGrpDesc.NamedProperties.Put("EnumerateMethod", "");
            this.colsFunctionGrpDesc.NamedProperties.Put("FieldFlags", "288");
            this.colsFunctionGrpDesc.NamedProperties.Put("LovReference", "");
            this.colsFunctionGrpDesc.NamedProperties.Put("ParentName", "colsVoucherFunction");
            this.colsFunctionGrpDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.colsFunctionGrpDesc.NamedProperties.Put("SqlColumn", "FUNCTION_GROUP_API.Get_Description(FUNCTION_GROUP)");
            this.colsFunctionGrpDesc.NamedProperties.Put("ValidateMethod", "");
            this.colsFunctionGrpDesc.Position = 7;
            resources.ApplyResources(this.colsFunctionGrpDesc, "colsFunctionGrpDesc");
            // 
            // colsLedger
            // 
            resources.ApplyResources(this.colsLedger, "colsLedger");
            this.colsLedger.Name = "colsLedger";
            this.colsLedger.NamedProperties.Put("EnumerateMethod", "LEDGER_API.Enumerate");
            this.colsLedger.NamedProperties.Put("FieldFlags", "288");
            this.colsLedger.NamedProperties.Put("LovReference", "");
            this.colsLedger.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsLedger.NamedProperties.Put("ResizeableChildObject", "");
            this.colsLedger.NamedProperties.Put("SqlColumn", "LEDGER");
            this.colsLedger.NamedProperties.Put("ValidateMethod", "");
            this.colsLedger.Position = 8;
            // 
            // colsLedgerId
            // 
            resources.ApplyResources(this.colsLedgerId, "colsLedgerId");
            this.colsLedgerId.Name = "colsLedgerId";
            this.colsLedgerId.NamedProperties.Put("EnumerateMethod", "");
            this.colsLedgerId.NamedProperties.Put("FieldFlags", "288");
            this.colsLedgerId.NamedProperties.Put("LovReference", "INTERNAL_LEDGER(COMPANY)");
            this.colsLedgerId.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsLedgerId.NamedProperties.Put("ResizeableChildObject", "");
            this.colsLedgerId.NamedProperties.Put("SqlColumn", "LEDGER_ID");
            this.colsLedgerId.NamedProperties.Put("ValidateMethod", "");
            this.colsLedgerId.Position = 9;
            // 
            // colsBalance
            // 
            this.colsBalance.CellType = PPJ.Runtime.Windows.CellType.CheckBox;
            this.colsBalance.CheckBox.CheckedValue = "TRUE";
            this.colsBalance.CheckBox.IgnoreCase = true;
            this.colsBalance.CheckBox.UncheckedValue = "FALSE";
            resources.ApplyResources(this.colsBalance, "colsBalance");
            this.colsBalance.Name = "colsBalance";
            this.colsBalance.NamedProperties.Put("EnumerateMethod", "");
            this.colsBalance.NamedProperties.Put("FieldFlags", "288");
            this.colsBalance.NamedProperties.Put("LovReference", "");
            this.colsBalance.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsBalance.NamedProperties.Put("SqlColumn", "BALANCE");
            this.colsBalance.Position = 10;
            // 
            // colsUseManual
            // 
            this.colsUseManual.CellType = PPJ.Runtime.Windows.CellType.CheckBox;
            this.colsUseManual.CheckBox.CheckedValue = "TRUE";
            this.colsUseManual.CheckBox.IgnoreCase = true;
            this.colsUseManual.CheckBox.UncheckedValue = "FALSE";
            resources.ApplyResources(this.colsUseManual, "colsUseManual");
            this.colsUseManual.MaxLength = 5;
            this.colsUseManual.Name = "colsUseManual";
            this.colsUseManual.NamedProperties.Put("EnumerateMethod", "");
            this.colsUseManual.NamedProperties.Put("FieldFlags", "295");
            this.colsUseManual.NamedProperties.Put("LovReference", "");
            this.colsUseManual.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsUseManual.NamedProperties.Put("SqlColumn", "USE_MANUAL");
            this.colsUseManual.Position = 11;
            // 
            // colsAutomaticAllotDb
            // 
            this.colsAutomaticAllotDb.CellType = PPJ.Runtime.Windows.CellType.CheckBox;
            this.colsAutomaticAllotDb.CheckBox.CheckedValue = "Y";
            this.colsAutomaticAllotDb.CheckBox.IgnoreCase = true;
            this.colsAutomaticAllotDb.CheckBox.UncheckedValue = "N";
            resources.ApplyResources(this.colsAutomaticAllotDb, "colsAutomaticAllotDb");
            this.colsAutomaticAllotDb.MaxLength = 1;
            this.colsAutomaticAllotDb.Name = "colsAutomaticAllotDb";
            this.colsAutomaticAllotDb.NamedProperties.Put("EnumerateMethod", "");
            this.colsAutomaticAllotDb.NamedProperties.Put("FieldFlags", "294");
            this.colsAutomaticAllotDb.NamedProperties.Put("LovReference", "");
            this.colsAutomaticAllotDb.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsAutomaticAllotDb.NamedProperties.Put("ResizeableChildObject", "");
            this.colsAutomaticAllotDb.NamedProperties.Put("SqlColumn", "AUTOMATIC_ALLOT_DB");
            this.colsAutomaticAllotDb.NamedProperties.Put("ValidateMethod", "");
            this.colsAutomaticAllotDb.Position = 12;
            // 
            // colsVtSingleFunctionGroup
            // 
            this.colsVtSingleFunctionGroup.CellType = PPJ.Runtime.Windows.CellType.CheckBox;
            this.colsVtSingleFunctionGroup.CheckBox.CheckedValue = "Y";
            this.colsVtSingleFunctionGroup.CheckBox.IgnoreCase = true;
            this.colsVtSingleFunctionGroup.CheckBox.UncheckedValue = "N";
            resources.ApplyResources(this.colsVtSingleFunctionGroup, "colsVtSingleFunctionGroup");
            this.colsVtSingleFunctionGroup.Name = "colsVtSingleFunctionGroup";
            this.colsVtSingleFunctionGroup.NamedProperties.Put("EnumerateMethod", "");
            this.colsVtSingleFunctionGroup.NamedProperties.Put("FieldFlags", "288");
            this.colsVtSingleFunctionGroup.NamedProperties.Put("LovReference", "");
            this.colsVtSingleFunctionGroup.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsVtSingleFunctionGroup.NamedProperties.Put("SqlColumn", "VT_SINGLE_FUNCTION_GROUP");
            this.colsVtSingleFunctionGroup.Position = 13;
            // 
            // colsSimulationVoucher
            // 
            this.colsSimulationVoucher.CellType = PPJ.Runtime.Windows.CellType.CheckBox;
            this.colsSimulationVoucher.CheckBox.CheckedValue = "TRUE";
            this.colsSimulationVoucher.CheckBox.IgnoreCase = true;
            this.colsSimulationVoucher.CheckBox.UncheckedValue = "FALSE";
            resources.ApplyResources(this.colsSimulationVoucher, "colsSimulationVoucher");
            this.colsSimulationVoucher.MaxLength = 5;
            this.colsSimulationVoucher.Name = "colsSimulationVoucher";
            this.colsSimulationVoucher.NamedProperties.Put("EnumerateMethod", "");
            this.colsSimulationVoucher.NamedProperties.Put("FieldFlags", "295");
            this.colsSimulationVoucher.NamedProperties.Put("LovReference", "");
            this.colsSimulationVoucher.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsSimulationVoucher.NamedProperties.Put("SqlColumn", "SIMULATION_VOUCHER");
            this.colsSimulationVoucher.Position = 14;
            // 
            // colsAutomaticVouBalance
            // 
            this.colsAutomaticVouBalance.CellType = PPJ.Runtime.Windows.CellType.CheckBox;
            this.colsAutomaticVouBalance.CheckBox.CheckedValue = "Y";
            this.colsAutomaticVouBalance.CheckBox.IgnoreCase = true;
            this.colsAutomaticVouBalance.CheckBox.UncheckedValue = "N";
            resources.ApplyResources(this.colsAutomaticVouBalance, "colsAutomaticVouBalance");
            this.colsAutomaticVouBalance.Name = "colsAutomaticVouBalance";
            this.colsAutomaticVouBalance.NamedProperties.Put("EnumerateMethod", "");
            this.colsAutomaticVouBalance.NamedProperties.Put("FieldFlags", "288");
            this.colsAutomaticVouBalance.NamedProperties.Put("LovReference", "");
            this.colsAutomaticVouBalance.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsAutomaticVouBalance.NamedProperties.Put("ResizeableChildObject", "");
            this.colsAutomaticVouBalance.NamedProperties.Put("SqlColumn", "AUTOMATIC_VOU_BALANCE");
            this.colsAutomaticVouBalance.NamedProperties.Put("ValidateMethod", "");
            this.colsAutomaticVouBalance.Position = 15;
            // 
            // colsStoreOriginalDb
            // 
            this.colsStoreOriginalDb.CellType = PPJ.Runtime.Windows.CellType.CheckBox;
            this.colsStoreOriginalDb.CheckBox.CheckedValue = "Y";
            this.colsStoreOriginalDb.CheckBox.IgnoreCase = true;
            this.colsStoreOriginalDb.CheckBox.UncheckedValue = "N";
            resources.ApplyResources(this.colsStoreOriginalDb, "colsStoreOriginalDb");
            this.colsStoreOriginalDb.MaxLength = 20;
            this.colsStoreOriginalDb.Name = "colsStoreOriginalDb";
            this.colsStoreOriginalDb.NamedProperties.Put("EnumerateMethod", "");
            this.colsStoreOriginalDb.NamedProperties.Put("FieldFlags", "288");
            this.colsStoreOriginalDb.NamedProperties.Put("LovReference", "");
            this.colsStoreOriginalDb.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsStoreOriginalDb.NamedProperties.Put("ResizeableChildObject", "");
            this.colsStoreOriginalDb.NamedProperties.Put("SqlColumn", "STORE_ORIGINAL_DB");
            this.colsStoreOriginalDb.NamedProperties.Put("ValidateMethod", "");
            this.colsStoreOriginalDb.Position = 16;
            // 
            // colsRowGrpValidation
            // 
            this.colsRowGrpValidation.CellType = PPJ.Runtime.Windows.CellType.CheckBox;
            this.colsRowGrpValidation.CheckBox.CheckedValue = "Y";
            this.colsRowGrpValidation.CheckBox.IgnoreCase = true;
            this.colsRowGrpValidation.CheckBox.UncheckedValue = "N";
            resources.ApplyResources(this.colsRowGrpValidation, "colsRowGrpValidation");
            this.colsRowGrpValidation.MaxLength = 20;
            this.colsRowGrpValidation.Name = "colsRowGrpValidation";
            this.colsRowGrpValidation.NamedProperties.Put("EnumerateMethod", "");
            this.colsRowGrpValidation.NamedProperties.Put("FieldFlags", "288");
            this.colsRowGrpValidation.NamedProperties.Put("LovReference", "");
            this.colsRowGrpValidation.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsRowGrpValidation.NamedProperties.Put("ResizeableChildObject", "");
            this.colsRowGrpValidation.NamedProperties.Put("SqlColumn", "ROW_GROUP_VALIDATION");
            this.colsRowGrpValidation.NamedProperties.Put("ValidateMethod", "");
            this.colsRowGrpValidation.Position = 17;
            // 
            // colsRefMandetory
            // 
            this.colsRefMandetory.CellType = PPJ.Runtime.Windows.CellType.CheckBox;
            this.colsRefMandetory.CheckBox.CheckedValue = "Y";
            this.colsRefMandetory.CheckBox.IgnoreCase = true;
            this.colsRefMandetory.CheckBox.UncheckedValue = "N";
            resources.ApplyResources(this.colsRefMandetory, "colsRefMandetory");
            this.colsRefMandetory.MaxLength = 20;
            this.colsRefMandetory.Name = "colsRefMandetory";
            this.colsRefMandetory.NamedProperties.Put("EnumerateMethod", "");
            this.colsRefMandetory.NamedProperties.Put("FieldFlags", "288");
            this.colsRefMandetory.NamedProperties.Put("LovReference", "");
            this.colsRefMandetory.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsRefMandetory.NamedProperties.Put("ResizeableChildObject", "");
            this.colsRefMandetory.NamedProperties.Put("SqlColumn", "REFERENCE_MANDATORY");
            this.colsRefMandetory.NamedProperties.Put("ValidateMethod", "");
            this.colsRefMandetory.Position = 18;
            // 
            // colsJournalId
            // 
            this.colsJournalId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsJournalId.MaxLength = 20;
            this.colsJournalId.Name = "colsJournalId";
            this.colsJournalId.NamedProperties.Put("EnumerateMethod", "");
            this.colsJournalId.NamedProperties.Put("FieldFlags", "288");
            this.colsJournalId.NamedProperties.Put("LovReference", "");
            this.colsJournalId.NamedProperties.Put("ParentName", "colsVoucherType");
            this.colsJournalId.NamedProperties.Put("ResizeableChildObject", "");
            this.colsJournalId.NamedProperties.Put("SqlColumn", "VOUCHER_UTIL_PUB_API.Get_Acc_Journal(COMPANY,VOUCHER_TYPE)");
            this.colsJournalId.NamedProperties.Put("ValidateMethod", "");
            this.colsJournalId.Position = 19;
            resources.ApplyResources(this.colsJournalId, "colsJournalId");
            // 
            // menuOperations
            // 
            this.menuOperations.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_Change});
            this.menuOperations.Name = "menuOperations";
            resources.ApplyResources(this.menuOperations, "menuOperations");
            // 
            // menuItem_Change
            // 
            this.menuItem_Change.Command = this.menuOperations_menuChange__Company___;
            this.menuItem_Change.Name = "menuItem_Change";
            resources.ApplyResources(this.menuItem_Change, "menuItem_Change");
            this.menuItem_Change.Text = "Change &Company...";
            // 
            // menuTbwMethods
            // 
            this.menuTbwMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_Change_1});
            this.menuTbwMethods.Name = "menuTbwMethods";
            resources.ApplyResources(this.menuTbwMethods, "menuTbwMethods");
            // 
            // menuItem_Change_1
            // 
            this.menuItem_Change_1.Command = this.menuTbwMethods_menuChange__Company___;
            this.menuItem_Change_1.Name = "menuItem_Change_1";
            resources.ApplyResources(this.menuItem_Change_1, "menuItem_Change_1");
            this.menuItem_Change_1.Text = "Change &Company...";
            // 
            // tbwQueryVoucherType
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colsCompany);
            this.Controls.Add(this.colsVoucherType);
            this.Controls.Add(this.colsVtDescription);
            this.Controls.Add(this.colsVoucherFunction);
            this.Controls.Add(this.colsFunctionGrpDesc);
            this.Controls.Add(this.colsLedger);
            this.Controls.Add(this.colsLedgerId);
            this.Controls.Add(this.colsBalance);
            this.Controls.Add(this.colsUseManual);
            this.Controls.Add(this.colsAutomaticAllotDb);
            this.Controls.Add(this.colsVtSingleFunctionGroup);
            this.Controls.Add(this.colsSimulationVoucher);
            this.Controls.Add(this.colsAutomaticVouBalance);
            this.Controls.Add(this.colsStoreOriginalDb);
            this.Controls.Add(this.colsRowGrpValidation);
            this.Controls.Add(this.colsRefMandetory);
            this.Controls.Add(this.colsJournalId);
            this.Name = "tbwQueryVoucherType";
            this.NamedProperties.Put("DefaultOrderBy", "voucher_type");
            this.NamedProperties.Put("DefaultWhere", "company = :global.company");
            this.NamedProperties.Put("LogicalUnit", "VoucherTypeDetail");
            this.NamedProperties.Put("PackageName", "VOUCHER_TYPE_DETAIL_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "1");
            this.NamedProperties.Put("ViewName", "VOUCHER_TYPE_DETAIL_QUERY");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tbwQueryVoucherType_WindowActions);
            this.Controls.SetChildIndex(this.colsJournalId, 0);
            this.Controls.SetChildIndex(this.colsRefMandetory, 0);
            this.Controls.SetChildIndex(this.colsRowGrpValidation, 0);
            this.Controls.SetChildIndex(this.colsStoreOriginalDb, 0);
            this.Controls.SetChildIndex(this.colsAutomaticVouBalance, 0);
            this.Controls.SetChildIndex(this.colsSimulationVoucher, 0);
            this.Controls.SetChildIndex(this.colsVtSingleFunctionGroup, 0);
            this.Controls.SetChildIndex(this.colsAutomaticAllotDb, 0);
            this.Controls.SetChildIndex(this.colsUseManual, 0);
            this.Controls.SetChildIndex(this.colsBalance, 0);
            this.Controls.SetChildIndex(this.colsLedgerId, 0);
            this.Controls.SetChildIndex(this.colsLedger, 0);
            this.Controls.SetChildIndex(this.colsFunctionGrpDesc, 0);
            this.Controls.SetChildIndex(this.colsVoucherFunction, 0);
            this.Controls.SetChildIndex(this.colsVtDescription, 0);
            this.Controls.SetChildIndex(this.colsVoucherType, 0);
            this.Controls.SetChildIndex(this.colsCompany, 0);
            this.Controls.SetChildIndex(this.@__colObjversion, 0);
            this.Controls.SetChildIndex(this.@__colObjid, 0);
            this.menuOperations.ResumeLayout(false);
            this.menuTbwMethods.ResumeLayout(false);
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

        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menuChange__Company___;
        public Fnd.Windows.Forms.FndCommand menuOperations_menuChange__Company___;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuOperations;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTbwMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change_1;
	}
}
