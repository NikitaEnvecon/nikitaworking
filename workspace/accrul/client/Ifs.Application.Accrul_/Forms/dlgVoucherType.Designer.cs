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
	
	public partial class dlgVoucherType
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cPushButton pbNew1;
		public cPushButton pbRemove1;
		// Step 1
		protected cBackgroundText labeldfHeading;
		public cDataField dfHeading;
		public cDataField dfsCompany;
		protected cBackgroundText labeldfVoucherType;
		public cDataField dfVoucherType;
		protected cBackgroundText labeldfVouTypeDesc;
		public cDataField dfVouTypeDesc;
		protected SalGroupBox gbLedger_Selection;
		protected cBackgroundText labelcmbLedger;
		public cComboBox cmbLedger;
		protected cBackgroundText labeldfLedgerID;
		public cDataField dfLedgerID;
		public cCheckBox cbManualMethods;
		public cCheckBoxFin cbBalance;
        // Step 2
		public cPushButtonDlgFin pbNew;
		public cPushButtonDlgFin pbRemove;
		protected SalGroupBox gbVoucher_Selection;
		public cCheckBox cbAutomaticAllot;
		public cCheckBoxFin cbSingleFunction;
		public cCheckBox cbSimulationVoucher;
		protected cBackgroundText labeldfsOptionalAutoBalance;
		public cDataFieldFin dfsOptionalAutoBalance;
		protected cBackgroundText labeldfsStoreOriginal;
		public cDataFieldFin dfsStoreOriginal;
		protected cBackgroundText labeldfsLabelPrint;
		public cDataFieldFin dfsLabelPrint;
		public cCheckBox cbFromExisting;
		protected cBackgroundText labeldfsExistingVouType;
		public cDataFieldFin dfsExistingVouType;
        // Step 3
		protected SalGroupBox gbUser_Group_Selection;
		protected cBackgroundText labeldfUserGroup;
		public cDataField dfUserGroup;
		public cDataField dfUserGroupDesc;
		protected cBackgroundText labelcmbAuthLevel;
		public cComboBox cmbAuthLevel;
		protected cBackgroundText labelcmbDefaultType;
		public cComboBox cmbDefaultType;
		public cRadioButton rbSingle;
		public cRadioButton rbAll;
		protected cBackgroundText labelcmbFunctionGroup;
		public cComboBoxFin cmbFunctionGroup;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgVoucherType));
            this.pbNew1 = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbRemove1 = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.labeldfHeading = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfHeading = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsCompany = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfVoucherType = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfVoucherType = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfVouTypeDesc = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfVouTypeDesc = new Ifs.Fnd.ApplicationForms.cDataField();
            this.gbLedger_Selection = new PPJ.Runtime.Windows.SalGroupBox();
            this.labelcmbLedger = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbLedger = new Ifs.Fnd.ApplicationForms.cComboBox();
            this.labeldfLedgerID = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfLedgerID = new Ifs.Fnd.ApplicationForms.cDataField();
            this.cbManualMethods = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.cbBalance = new Ifs.Application.Accrul.cCheckBoxFin();
            this.pbNew = new Ifs.Application.Accrul.cPushButtonDlgFin();
            this.pbRemove = new Ifs.Application.Accrul.cPushButtonDlgFin();
            this.gbVoucher_Selection = new PPJ.Runtime.Windows.SalGroupBox();
            this.cbAutomaticAllot = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.cbSingleFunction = new Ifs.Application.Accrul.cCheckBoxFin();
            this.cbSimulationVoucher = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.labeldfsOptionalAutoBalance = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsOptionalAutoBalance = new Ifs.Application.Accrul.cDataFieldFin();
            this.labeldfsStoreOriginal = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsStoreOriginal = new Ifs.Application.Accrul.cDataFieldFin();
            this.labeldfsLabelPrint = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsLabelPrint = new Ifs.Application.Accrul.cDataFieldFin();
            this.cbFromExisting = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.labeldfsExistingVouType = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsExistingVouType = new Ifs.Application.Accrul.cDataFieldFin();
            this.gbUser_Group_Selection = new PPJ.Runtime.Windows.SalGroupBox();
            this.labeldfUserGroup = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfUserGroup = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfUserGroupDesc = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelcmbAuthLevel = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.labelcmbDefaultType = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.rbSingle = new Ifs.Fnd.ApplicationForms.cRadioButton();
            this.rbAll = new Ifs.Fnd.ApplicationForms.cRadioButton();
            this.labelcmbFunctionGroup = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbFunctionGroup = new Ifs.Application.Accrul.cComboBoxFin();
            this.Step1 = new Ifs.Fnd.ApplicationForms.@__cWizardStep();
            this.Step2 = new Ifs.Fnd.ApplicationForms.@__cWizardStep();
            this.Step3 = new Ifs.Fnd.ApplicationForms.@__cWizardStep();
            this.tblFunctionGroup = new Ifs.Application.Accrul.cChildTableFin();
            this.tblFunctionGroup_colsCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblFunctionGroup_colsVoucherType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblFunctionGroup_colsFunctionGroup = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblFunctionGroup_colDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblFunctionGroup_colsOptionalAutoBalance = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.tblFunctionGroup_colsStoreOriginal = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.tblFunctionGroup_colsRowGrpValidation = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.tblFunctionGroup_colsRefMandetory = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.tblFunctionGroup_colsSingleFunction = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.tblFunctionGroup_colsAutomaticAllot = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.tblVoucherSeries = new Ifs.Application.Accrul.cChildTableFin();
            this.tblVoucherSeries_colsCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherSeries_colsVoucherType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherSeries_colnAccountingYear = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherSeries_colnPeriod = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherSeries_colnSerieFrom = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherSeries_colnSerieUntil = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherSeries_colnCurrentNumber = new Ifs.Fnd.ApplicationForms.cColumn();
            this.cmbCompany = new Ifs.Fnd.ApplicationForms.cComboBox();
            this.labelcmbCompany = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfCompanyDesc = new Ifs.Fnd.ApplicationForms.cDataField();
            this.cmbAuthLevel = new Ifs.Fnd.ApplicationForms.cComboBox();
            this.cmbDefaultType = new Ifs.Fnd.ApplicationForms.cComboBox();
            this.dfHeading1 = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfHeading1 = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            ((System.ComponentModel.ISupportInitialize)(this.picWizard)).BeginInit();
            this.ToolBar.SuspendLayout();
            this.ClientArea.SuspendLayout();
            this.tblFunctionGroup.SuspendLayout();
            this.tblVoucherSeries.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbFinish
            // 
            resources.ApplyResources(this.pbFinish, "pbFinish");
            // 
            // pbNext
            // 
            resources.ApplyResources(this.pbNext, "pbNext");
            this.pbNext.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.pbNext_WindowActions);
            // 
            // pbBack
            // 
            resources.ApplyResources(this.pbBack, "pbBack");
            this.pbBack.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.pbBack_WindowActions);
            // 
            // pbCancel
            // 
            resources.ApplyResources(this.pbCancel, "pbCancel");
            // 
            // pbList
            // 
            resources.ApplyResources(this.pbList, "pbList");
            // 
            // ToolBar
            // 
            this.ToolBar.Controls.Add(this.pbRemove1);
            this.ToolBar.Controls.Add(this.pbNew1);
            resources.ApplyResources(this.ToolBar, "ToolBar");
            this.ToolBar.Controls.SetChildIndex(this.pbFinish, 0);
            this.ToolBar.Controls.SetChildIndex(this.pbNext, 0);
            this.ToolBar.Controls.SetChildIndex(this.pbBack, 0);
            this.ToolBar.Controls.SetChildIndex(this.pbCancel, 0);
            this.ToolBar.Controls.SetChildIndex(this.pbList, 0);
            this.ToolBar.Controls.SetChildIndex(this.pbNew1, 0);
            this.ToolBar.Controls.SetChildIndex(this.pbRemove1, 0);
            // 
            // ClientArea
            // 
            this.ClientArea.Controls.Add(this.dfHeading1);
            this.ClientArea.Controls.Add(this.dfCompanyDesc);
            this.ClientArea.Controls.Add(this.labelcmbCompany);
            this.ClientArea.Controls.Add(this.cmbCompany);
            this.ClientArea.Controls.Add(this.cmbFunctionGroup);
            this.ClientArea.Controls.Add(this.rbAll);
            this.ClientArea.Controls.Add(this.rbSingle);
            this.ClientArea.Controls.Add(this.cmbDefaultType);
            this.ClientArea.Controls.Add(this.cmbAuthLevel);
            this.ClientArea.Controls.Add(this.dfUserGroupDesc);
            this.ClientArea.Controls.Add(this.dfUserGroup);
            this.ClientArea.Controls.Add(this.tblVoucherSeries);
            this.ClientArea.Controls.Add(this.dfsExistingVouType);
            this.ClientArea.Controls.Add(this.cbFromExisting);
            this.ClientArea.Controls.Add(this.dfsLabelPrint);
            this.ClientArea.Controls.Add(this.dfsStoreOriginal);
            this.ClientArea.Controls.Add(this.dfsOptionalAutoBalance);
            this.ClientArea.Controls.Add(this.cbSimulationVoucher);
            this.ClientArea.Controls.Add(this.cbSingleFunction);
            this.ClientArea.Controls.Add(this.cbAutomaticAllot);
            this.ClientArea.Controls.Add(this.pbRemove);
            this.ClientArea.Controls.Add(this.pbNew);
            this.ClientArea.Controls.Add(this.tblFunctionGroup);
            this.ClientArea.Controls.Add(this.cbBalance);
            this.ClientArea.Controls.Add(this.cbManualMethods);
            this.ClientArea.Controls.Add(this.dfLedgerID);
            this.ClientArea.Controls.Add(this.cmbLedger);
            this.ClientArea.Controls.Add(this.dfVouTypeDesc);
            this.ClientArea.Controls.Add(this.dfVoucherType);
            this.ClientArea.Controls.Add(this.dfsCompany);
            this.ClientArea.Controls.Add(this.dfHeading);
            this.ClientArea.Controls.Add(this.labelcmbFunctionGroup);
            this.ClientArea.Controls.Add(this.labelcmbDefaultType);
            this.ClientArea.Controls.Add(this.labelcmbAuthLevel);
            this.ClientArea.Controls.Add(this.labeldfUserGroup);
            this.ClientArea.Controls.Add(this.labeldfsExistingVouType);
            this.ClientArea.Controls.Add(this.labeldfsLabelPrint);
            this.ClientArea.Controls.Add(this.labeldfsStoreOriginal);
            this.ClientArea.Controls.Add(this.labeldfsOptionalAutoBalance);
            this.ClientArea.Controls.Add(this.labeldfLedgerID);
            this.ClientArea.Controls.Add(this.labelcmbLedger);
            this.ClientArea.Controls.Add(this.labeldfVouTypeDesc);
            this.ClientArea.Controls.Add(this.labeldfVoucherType);
            this.ClientArea.Controls.Add(this.labeldfHeading);
            this.ClientArea.Controls.Add(this.gbUser_Group_Selection);
            this.ClientArea.Controls.Add(this.gbVoucher_Selection);
            this.ClientArea.Controls.Add(this.gbLedger_Selection);
            this.ClientArea.Controls.Add(this.labeldfHeading1);
            resources.ApplyResources(this.ClientArea, "ClientArea");
            this.ClientArea.Controls.SetChildIndex(this.labeldfHeading1, 0);
            this.ClientArea.Controls.SetChildIndex(this.gbLedger_Selection, 0);
            this.ClientArea.Controls.SetChildIndex(this.gbVoucher_Selection, 0);
            this.ClientArea.Controls.SetChildIndex(this.gbUser_Group_Selection, 0);
            this.ClientArea.Controls.SetChildIndex(this.labeldfHeading, 0);
            this.ClientArea.Controls.SetChildIndex(this.labeldfVoucherType, 0);
            this.ClientArea.Controls.SetChildIndex(this.labeldfVouTypeDesc, 0);
            this.ClientArea.Controls.SetChildIndex(this.labelcmbLedger, 0);
            this.ClientArea.Controls.SetChildIndex(this.labeldfLedgerID, 0);
            this.ClientArea.Controls.SetChildIndex(this.labeldfsOptionalAutoBalance, 0);
            this.ClientArea.Controls.SetChildIndex(this.labeldfsStoreOriginal, 0);
            this.ClientArea.Controls.SetChildIndex(this.labeldfsLabelPrint, 0);
            this.ClientArea.Controls.SetChildIndex(this.labeldfsExistingVouType, 0);
            this.ClientArea.Controls.SetChildIndex(this.labeldfUserGroup, 0);
            this.ClientArea.Controls.SetChildIndex(this.labelcmbAuthLevel, 0);
            this.ClientArea.Controls.SetChildIndex(this.labelcmbDefaultType, 0);
            this.ClientArea.Controls.SetChildIndex(this.labelcmbFunctionGroup, 0);
            this.ClientArea.Controls.SetChildIndex(this.dfHeading, 0);
            this.ClientArea.Controls.SetChildIndex(this.dfsCompany, 0);
            this.ClientArea.Controls.SetChildIndex(this.dfVoucherType, 0);
            this.ClientArea.Controls.SetChildIndex(this.dfVouTypeDesc, 0);
            this.ClientArea.Controls.SetChildIndex(this.cmbLedger, 0);
            this.ClientArea.Controls.SetChildIndex(this.dfLedgerID, 0);
            this.ClientArea.Controls.SetChildIndex(this.cbManualMethods, 0);
            this.ClientArea.Controls.SetChildIndex(this.cbBalance, 0);
            this.ClientArea.Controls.SetChildIndex(this.tblFunctionGroup, 0);
            this.ClientArea.Controls.SetChildIndex(this.pbNew, 0);
            this.ClientArea.Controls.SetChildIndex(this.pbRemove, 0);
            this.ClientArea.Controls.SetChildIndex(this.cbAutomaticAllot, 0);
            this.ClientArea.Controls.SetChildIndex(this.cbSingleFunction, 0);
            this.ClientArea.Controls.SetChildIndex(this.cbSimulationVoucher, 0);
            this.ClientArea.Controls.SetChildIndex(this.dfsOptionalAutoBalance, 0);
            this.ClientArea.Controls.SetChildIndex(this.dfsStoreOriginal, 0);
            this.ClientArea.Controls.SetChildIndex(this.dfsLabelPrint, 0);
            this.ClientArea.Controls.SetChildIndex(this.cbFromExisting, 0);
            this.ClientArea.Controls.SetChildIndex(this.dfsExistingVouType, 0);
            this.ClientArea.Controls.SetChildIndex(this.tblVoucherSeries, 0);
            this.ClientArea.Controls.SetChildIndex(this.dfUserGroup, 0);
            this.ClientArea.Controls.SetChildIndex(this.dfUserGroupDesc, 0);
            this.ClientArea.Controls.SetChildIndex(this.cmbAuthLevel, 0);
            this.ClientArea.Controls.SetChildIndex(this.cmbDefaultType, 0);
            this.ClientArea.Controls.SetChildIndex(this.rbSingle, 0);
            this.ClientArea.Controls.SetChildIndex(this.rbAll, 0);
            this.ClientArea.Controls.SetChildIndex(this.cmbFunctionGroup, 0);
            this.ClientArea.Controls.SetChildIndex(this.cmbCompany, 0);
            this.ClientArea.Controls.SetChildIndex(this.labelcmbCompany, 0);
            this.ClientArea.Controls.SetChildIndex(this.dfCompanyDesc, 0);
            this.ClientArea.Controls.SetChildIndex(this.picWizard, 0);
            this.ClientArea.Controls.SetChildIndex(this.dfHeading1, 0);
            // 
            // StatusBar
            // 
            resources.ApplyResources(this.StatusBar, "StatusBar");
            // 
            // commandManager
            // 
            this.commandManager.Components.Add(this.pbRemove1);
            this.commandManager.Components.Add(this.pbNew1);
            this.commandManager.Components.Add(this.pbRemove);
            this.commandManager.Components.Add(this.pbNew);
            // 
            // pbNew1
            // 
            resources.ApplyResources(this.pbNew1, "pbNew1");
            this.pbNew1.Name = "pbNew1";
            this.pbNew1.NamedProperties.Put("MethodId", "18385");
            this.pbNew1.NamedProperties.Put("MethodParameter", "new");
            this.pbNew1.NamedProperties.Put("ResizeableChildObject", "");
            this.pbNew1.TabStop = false;
            // 
            // pbRemove1
            // 
            resources.ApplyResources(this.pbRemove1, "pbRemove1");
            this.pbRemove1.Name = "pbRemove1";
            this.pbRemove1.NamedProperties.Put("MethodId", "18385");
            this.pbRemove1.NamedProperties.Put("MethodParameter", "remove");
            this.pbRemove1.NamedProperties.Put("ResizeableChildObject", "");
            this.pbRemove1.TabStop = false;
            // 
            // labeldfHeading
            // 
            resources.ApplyResources(this.labeldfHeading, "labeldfHeading");
            this.labeldfHeading.Name = "labeldfHeading";
            // 
            // dfHeading
            // 
            resources.ApplyResources(this.dfHeading, "dfHeading");
            this.dfHeading.Name = "dfHeading";
            this.dfHeading.NamedProperties.Put("EnumerateMethod", "");
            this.dfHeading.NamedProperties.Put("FieldFlags", "262");
            this.dfHeading.NamedProperties.Put("LovReference", "");
            this.dfHeading.NamedProperties.Put("ResizeableChildObject", "");
            this.dfHeading.NamedProperties.Put("SqlColumn", "");
            this.dfHeading.NamedProperties.Put("ValidateMethod", "");
            // 
            // dfsCompany
            // 
            resources.ApplyResources(this.dfsCompany, "dfsCompany");
            this.dfsCompany.Name = "dfsCompany";
            this.dfsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.dfsCompany.NamedProperties.Put("FieldFlags", "775");
            this.dfsCompany.NamedProperties.Put("LovReference", "");
            this.dfsCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.dfsCompany.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfVoucherType
            // 
            resources.ApplyResources(this.labeldfVoucherType, "labeldfVoucherType");
            this.labeldfVoucherType.Name = "labeldfVoucherType";
            // 
            // dfVoucherType
            // 
            this.dfVoucherType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfVoucherType, "dfVoucherType");
            this.dfVoucherType.Name = "dfVoucherType";
            this.dfVoucherType.NamedProperties.Put("EnumerateMethod", "");
            this.dfVoucherType.NamedProperties.Put("FieldFlags", "263");
            this.dfVoucherType.NamedProperties.Put("LovReference", "");
            this.dfVoucherType.NamedProperties.Put("ResizeableChildObject", "");
            this.dfVoucherType.NamedProperties.Put("SqlColumn", "VOUCHER_TYPE");
            this.dfVoucherType.NamedProperties.Put("ValidateMethod", "");
            this.dfVoucherType.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfVoucherType_WindowActions);
            // 
            // labeldfVouTypeDesc
            // 
            resources.ApplyResources(this.labeldfVouTypeDesc, "labeldfVouTypeDesc");
            this.labeldfVouTypeDesc.Name = "labeldfVouTypeDesc";
            // 
            // dfVouTypeDesc
            // 
            resources.ApplyResources(this.dfVouTypeDesc, "dfVouTypeDesc");
            this.dfVouTypeDesc.Name = "dfVouTypeDesc";
            this.dfVouTypeDesc.NamedProperties.Put("EnumerateMethod", "");
            this.dfVouTypeDesc.NamedProperties.Put("FieldFlags", "261");
            this.dfVouTypeDesc.NamedProperties.Put("LovReference", "");
            this.dfVouTypeDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.dfVouTypeDesc.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            this.dfVouTypeDesc.NamedProperties.Put("ValidateMethod", "");
            this.dfVouTypeDesc.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfVouTypeDesc_WindowActions);
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
            this.cmbLedger.DropDownHeight = 152;
            resources.ApplyResources(this.cmbLedger, "cmbLedger");
            this.cmbLedger.Name = "cmbLedger";
            this.cmbLedger.NamedProperties.Put("EnumerateMethod", "LEDGER_API.Enumerate");
            this.cmbLedger.NamedProperties.Put("FieldFlags", "295");
            this.cmbLedger.NamedProperties.Put("LovReference", "");
            this.cmbLedger.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbLedger.NamedProperties.Put("SqlColumn", "");
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
            this.dfLedgerID.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfLedgerID_WindowActions);
            // 
            // cbManualMethods
            // 
            resources.ApplyResources(this.cbManualMethods, "cbManualMethods");
            this.cbManualMethods.Name = "cbManualMethods";
            this.cbManualMethods.NamedProperties.Put("DataType", "5");
            this.cbManualMethods.NamedProperties.Put("EnumerateMethod", "");
            this.cbManualMethods.NamedProperties.Put("FieldFlags", "262");
            this.cbManualMethods.NamedProperties.Put("LovReference", "");
            this.cbManualMethods.NamedProperties.Put("ResizeableChildObject", "");
            this.cbManualMethods.NamedProperties.Put("SqlColumn", "");
            this.cbManualMethods.NamedProperties.Put("ValidateMethod", "");
            this.cbManualMethods.NamedProperties.Put("XDataLength", "Class Default");
            this.cbManualMethods.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cbManualMethods_WindowActions);
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
            this.cbBalance.NamedProperties.Put("SqlColumn", "");
            this.cbBalance.NamedProperties.Put("ValidateMethod", "");
            this.cbBalance.NamedProperties.Put("XDataLength", "Default");
            this.cbBalance.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cbBalance_WindowActions);
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
            // gbVoucher_Selection
            // 
            resources.ApplyResources(this.gbVoucher_Selection, "gbVoucher_Selection");
            this.gbVoucher_Selection.Name = "gbVoucher_Selection";
            this.gbVoucher_Selection.TabStop = false;
            // 
            // cbAutomaticAllot
            // 
            resources.ApplyResources(this.cbAutomaticAllot, "cbAutomaticAllot");
            this.cbAutomaticAllot.Name = "cbAutomaticAllot";
            this.cbAutomaticAllot.NamedProperties.Put("DataType", "5");
            this.cbAutomaticAllot.NamedProperties.Put("EnumerateMethod", "");
            this.cbAutomaticAllot.NamedProperties.Put("FieldFlags", "262");
            this.cbAutomaticAllot.NamedProperties.Put("LovReference", "");
            this.cbAutomaticAllot.NamedProperties.Put("ResizeableChildObject", "");
            this.cbAutomaticAllot.NamedProperties.Put("SqlColumn", "");
            this.cbAutomaticAllot.NamedProperties.Put("ValidateMethod", "");
            this.cbAutomaticAllot.NamedProperties.Put("XDataLength", "Class Default");
            this.cbAutomaticAllot.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cbAutomaticAllot_WindowActions);
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
            this.cbSingleFunction.NamedProperties.Put("XDataLength", "Class Default");
            this.cbSingleFunction.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cbSingleFunction_WindowActions);
            // 
            // cbSimulationVoucher
            // 
            resources.ApplyResources(this.cbSimulationVoucher, "cbSimulationVoucher");
            this.cbSimulationVoucher.Name = "cbSimulationVoucher";
            this.cbSimulationVoucher.NamedProperties.Put("DataType", "5");
            this.cbSimulationVoucher.NamedProperties.Put("EnumerateMethod", "");
            this.cbSimulationVoucher.NamedProperties.Put("FieldFlags", "262");
            this.cbSimulationVoucher.NamedProperties.Put("LovReference", "");
            this.cbSimulationVoucher.NamedProperties.Put("ResizeableChildObject", "");
            this.cbSimulationVoucher.NamedProperties.Put("SqlColumn", "");
            this.cbSimulationVoucher.NamedProperties.Put("ValidateMethod", "");
            this.cbSimulationVoucher.NamedProperties.Put("XDataLength", "Class Default");
            this.cbSimulationVoucher.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cbSimulationVoucher_WindowActions);
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
            this.dfsOptionalAutoBalance.NamedProperties.Put("SqlColumn", "");
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
            this.dfsStoreOriginal.NamedProperties.Put("SqlColumn", "");
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
            this.dfsLabelPrint.NamedProperties.Put("SqlColumn", "");
            this.dfsLabelPrint.NamedProperties.Put("ValidateMethod", "");
            // 
            // cbFromExisting
            // 
            resources.ApplyResources(this.cbFromExisting, "cbFromExisting");
            this.cbFromExisting.Name = "cbFromExisting";
            this.cbFromExisting.NamedProperties.Put("DataType", "5");
            this.cbFromExisting.NamedProperties.Put("EnumerateMethod", "");
            this.cbFromExisting.NamedProperties.Put("FieldFlags", "262");
            this.cbFromExisting.NamedProperties.Put("LovReference", "");
            this.cbFromExisting.NamedProperties.Put("ResizeableChildObject", "");
            this.cbFromExisting.NamedProperties.Put("SqlColumn", "");
            this.cbFromExisting.NamedProperties.Put("ValidateMethod", "");
            this.cbFromExisting.NamedProperties.Put("XDataLength", "Class Default");
            this.cbFromExisting.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cbFromExisting_WindowActions);
            // 
            // labeldfsExistingVouType
            // 
            resources.ApplyResources(this.labeldfsExistingVouType, "labeldfsExistingVouType");
            this.labeldfsExistingVouType.Name = "labeldfsExistingVouType";
            // 
            // dfsExistingVouType
            // 
            this.dfsExistingVouType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsExistingVouType, "dfsExistingVouType");
            this.dfsExistingVouType.Name = "dfsExistingVouType";
            this.dfsExistingVouType.NamedProperties.Put("EnumerateMethod", "");
            this.dfsExistingVouType.NamedProperties.Put("FieldFlags", "262");
            this.dfsExistingVouType.NamedProperties.Put("LovReference", "VOUCHER_TYPE(COMPANY)");
            this.dfsExistingVouType.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsExistingVouType.NamedProperties.Put("SqlColumn", "");
            this.dfsExistingVouType.NamedProperties.Put("ValidateMethod", "");
            this.dfsExistingVouType.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsExistingVouType_WindowActions);
            // 
            // gbUser_Group_Selection
            // 
            resources.ApplyResources(this.gbUser_Group_Selection, "gbUser_Group_Selection");
            this.gbUser_Group_Selection.Name = "gbUser_Group_Selection";
            this.gbUser_Group_Selection.TabStop = false;
            // 
            // labeldfUserGroup
            // 
            resources.ApplyResources(this.labeldfUserGroup, "labeldfUserGroup");
            this.labeldfUserGroup.Name = "labeldfUserGroup";
            // 
            // dfUserGroup
            // 
            this.dfUserGroup.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfUserGroup, "dfUserGroup");
            this.dfUserGroup.Name = "dfUserGroup";
            this.dfUserGroup.NamedProperties.Put("EnumerateMethod", "");
            this.dfUserGroup.NamedProperties.Put("FieldFlags", "262");
            this.dfUserGroup.NamedProperties.Put("LovReference", "USER_GROUP_FINANCE(COMPANY)");
            this.dfUserGroup.NamedProperties.Put("ResizeableChildObject", "");
            this.dfUserGroup.NamedProperties.Put("SqlColumn", "");
            this.dfUserGroup.NamedProperties.Put("ValidateMethod", "");
            this.dfUserGroup.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfUserGroup_WindowActions);
            // 
            // dfUserGroupDesc
            // 
            resources.ApplyResources(this.dfUserGroupDesc, "dfUserGroupDesc");
            this.dfUserGroupDesc.Name = "dfUserGroupDesc";
            this.dfUserGroupDesc.NamedProperties.Put("EnumerateMethod", "");
            this.dfUserGroupDesc.NamedProperties.Put("LovReference", "");
            this.dfUserGroupDesc.NamedProperties.Put("ParentName", "dfUserGroup");
            this.dfUserGroupDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.dfUserGroupDesc.NamedProperties.Put("SqlColumn", "USER_GROUP_FINANCE_API.Get_User_Group_Description(:i_hWndFrame.dlgVoucherType.dfs" +
        "Company, :i_hWndFrame.dlgVoucherType.dfUserGroup)");
            this.dfUserGroupDesc.NamedProperties.Put("ValidateMethod", "");
            this.dfUserGroupDesc.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfUserGroupDesc_WindowActions);
            // 
            // labelcmbAuthLevel
            // 
            resources.ApplyResources(this.labelcmbAuthLevel, "labelcmbAuthLevel");
            this.labelcmbAuthLevel.Name = "labelcmbAuthLevel";
            // 
            // labelcmbDefaultType
            // 
            resources.ApplyResources(this.labelcmbDefaultType, "labelcmbDefaultType");
            this.labelcmbDefaultType.Name = "labelcmbDefaultType";
            // 
            // rbSingle
            // 
            resources.ApplyResources(this.rbSingle, "rbSingle");
            this.rbSingle.Name = "rbSingle";
            this.rbSingle.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.rbSingle_WindowActions);
            // 
            // rbAll
            // 
            resources.ApplyResources(this.rbAll, "rbAll");
            this.rbAll.Name = "rbAll";
            this.rbAll.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.rbAll_WindowActions);
            // 
            // labelcmbFunctionGroup
            // 
            resources.ApplyResources(this.labelcmbFunctionGroup, "labelcmbFunctionGroup");
            this.labelcmbFunctionGroup.Name = "labelcmbFunctionGroup";
            // 
            // cmbFunctionGroup
            // 
            this.cmbFunctionGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cmbFunctionGroup, "cmbFunctionGroup");
            this.cmbFunctionGroup.Name = "cmbFunctionGroup";
            this.cmbFunctionGroup.NamedProperties.Put("EnumerateMethod", "");
            this.cmbFunctionGroup.NamedProperties.Put("FieldFlags", "262");
            this.cmbFunctionGroup.NamedProperties.Put("Format", "9");
            this.cmbFunctionGroup.NamedProperties.Put("LovReference", "");
            this.cmbFunctionGroup.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbFunctionGroup.NamedProperties.Put("SqlColumn", "");
            this.cmbFunctionGroup.NamedProperties.Put("ValidateMethod", "");
            this.cmbFunctionGroup.Sorted = true;
            this.cmbFunctionGroup.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbFunctionGroup_WindowActions);
            // 
            // Step1
            // 
            this.Step1.Controls = new string[] {
        "cbBalance",
        "cbManualMethods",
        "cmbLedger",
        "dfHeading",
        "dfLedgerID",
        "dfVoucherType",
        "dfVouTypeDesc",
        "gbLedger_Selection",
        "cmbCompany",
        "dfCompanyDesc",
        "dfHeading1"};
            this.Step1.StepDescription = "Step1";
            resources.ApplyResources(this.Step1, "Step1");
            this.Step1.UseInternalControls = true;
            // 
            // Step2
            // 
            this.Step2.Controls = new string[] {
        "cbAutomaticAllot",
        "cbFromExisting",
        "cbSimulationVoucher",
        "cbSingleFunction",
        "dfsExistingVouType",
        "pbNew",
        "pbRemove",
        "tblFunctionGroup",
        "gbVoucher_Selection"};
            this.Step2.StepDescription = "Step2";
            resources.ApplyResources(this.Step2, "Step2");
            this.Step2.UseInternalControls = true;
            // 
            // Step3
            // 
            this.Step3.Controls = new string[] {
        "cmbAuthLevel",
        "cmbDefaultType",
        "cmbFunctionGroup",
        "dfUserGroup",
        "dfUserGroupDesc",
        "rbAll",
        "rbSingle",
        "tblVoucherSeries",
        "gbUser_Group_Selection"};
            this.Step3.StepDescription = "Step3";
            resources.ApplyResources(this.Step3, "Step3");
            this.Step3.UseInternalControls = true;
            // 
            // tblFunctionGroup
            // 
            this.tblFunctionGroup.Controls.Add(this.tblFunctionGroup_colsCompany);
            this.tblFunctionGroup.Controls.Add(this.tblFunctionGroup_colsVoucherType);
            this.tblFunctionGroup.Controls.Add(this.tblFunctionGroup_colsFunctionGroup);
            this.tblFunctionGroup.Controls.Add(this.tblFunctionGroup_colDescription);
            this.tblFunctionGroup.Controls.Add(this.tblFunctionGroup_colsOptionalAutoBalance);
            this.tblFunctionGroup.Controls.Add(this.tblFunctionGroup_colsStoreOriginal);
            this.tblFunctionGroup.Controls.Add(this.tblFunctionGroup_colsRowGrpValidation);
            this.tblFunctionGroup.Controls.Add(this.tblFunctionGroup_colsRefMandetory);
            this.tblFunctionGroup.Controls.Add(this.tblFunctionGroup_colsSingleFunction);
            this.tblFunctionGroup.Controls.Add(this.tblFunctionGroup_colsAutomaticAllot);
            resources.ApplyResources(this.tblFunctionGroup, "tblFunctionGroup");
            this.tblFunctionGroup.Name = "tblFunctionGroup";
            this.tblFunctionGroup.NamedProperties.Put("DefaultOrderBy", "function_group");
            this.tblFunctionGroup.NamedProperties.Put("DefaultWhere", "company = :global.company");
            this.tblFunctionGroup.NamedProperties.Put("LogicalUnit", "VoucherTypeDetail");
            this.tblFunctionGroup.NamedProperties.Put("PackageName", "VOUCHER_TYPE_DETAIL_API");
            this.tblFunctionGroup.NamedProperties.Put("ResizeableChildObject", "LLMM");
            this.tblFunctionGroup.NamedProperties.Put("ViewName", "VOUCHER_TYPE_DETAIL");
            this.tblFunctionGroup.NamedProperties.Put("Warnings", "FALSE");
            this.tblFunctionGroup.DataRecordGetDefaultsEvent += new System.EventHandler<Ifs.Fnd.ApplicationForms.FndReturnEventArgsSalBoolean>(this.tblFunctionGroup_DataRecordGetDefaultsEvent);
            this.tblFunctionGroup.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblFunctionGroup_WindowActions);
            this.tblFunctionGroup.Controls.SetChildIndex(this.tblFunctionGroup_colsAutomaticAllot, 0);
            this.tblFunctionGroup.Controls.SetChildIndex(this.tblFunctionGroup_colsSingleFunction, 0);
            this.tblFunctionGroup.Controls.SetChildIndex(this.tblFunctionGroup_colsRefMandetory, 0);
            this.tblFunctionGroup.Controls.SetChildIndex(this.tblFunctionGroup_colsRowGrpValidation, 0);
            this.tblFunctionGroup.Controls.SetChildIndex(this.tblFunctionGroup_colsStoreOriginal, 0);
            this.tblFunctionGroup.Controls.SetChildIndex(this.tblFunctionGroup_colsOptionalAutoBalance, 0);
            this.tblFunctionGroup.Controls.SetChildIndex(this.tblFunctionGroup_colDescription, 0);
            this.tblFunctionGroup.Controls.SetChildIndex(this.tblFunctionGroup_colsFunctionGroup, 0);
            this.tblFunctionGroup.Controls.SetChildIndex(this.tblFunctionGroup_colsVoucherType, 0);
            this.tblFunctionGroup.Controls.SetChildIndex(this.tblFunctionGroup_colsCompany, 0);
            // 
            // tblFunctionGroup_colsCompany
            // 
            this.tblFunctionGroup_colsCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblFunctionGroup_colsCompany, "tblFunctionGroup_colsCompany");
            this.tblFunctionGroup_colsCompany.MaxLength = 20;
            this.tblFunctionGroup_colsCompany.Name = "tblFunctionGroup_colsCompany";
            this.tblFunctionGroup_colsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.tblFunctionGroup_colsCompany.NamedProperties.Put("FieldFlags", "67");
            this.tblFunctionGroup_colsCompany.NamedProperties.Put("LovReference", "");
            this.tblFunctionGroup_colsCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.tblFunctionGroup_colsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.tblFunctionGroup_colsCompany.NamedProperties.Put("ValidateMethod", "");
            this.tblFunctionGroup_colsCompany.Position = 3;
            // 
            // tblFunctionGroup_colsVoucherType
            // 
            this.tblFunctionGroup_colsVoucherType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblFunctionGroup_colsVoucherType, "tblFunctionGroup_colsVoucherType");
            this.tblFunctionGroup_colsVoucherType.MaxLength = 3;
            this.tblFunctionGroup_colsVoucherType.Name = "tblFunctionGroup_colsVoucherType";
            this.tblFunctionGroup_colsVoucherType.NamedProperties.Put("EnumerateMethod", "");
            this.tblFunctionGroup_colsVoucherType.NamedProperties.Put("FieldFlags", "67");
            this.tblFunctionGroup_colsVoucherType.NamedProperties.Put("LovReference", "");
            this.tblFunctionGroup_colsVoucherType.NamedProperties.Put("ResizeableChildObject", "");
            this.tblFunctionGroup_colsVoucherType.NamedProperties.Put("SqlColumn", "VOUCHER_TYPE");
            this.tblFunctionGroup_colsVoucherType.NamedProperties.Put("ValidateMethod", "");
            this.tblFunctionGroup_colsVoucherType.Position = 4;
            // 
            // tblFunctionGroup_colsFunctionGroup
            // 
            this.tblFunctionGroup_colsFunctionGroup.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblFunctionGroup_colsFunctionGroup.MaxLength = 20;
            this.tblFunctionGroup_colsFunctionGroup.Name = "tblFunctionGroup_colsFunctionGroup";
            this.tblFunctionGroup_colsFunctionGroup.NamedProperties.Put("EnumerateMethod", "");
            this.tblFunctionGroup_colsFunctionGroup.NamedProperties.Put("FieldFlags", "167");
            this.tblFunctionGroup_colsFunctionGroup.NamedProperties.Put("LovReference", "FUNCTION_GROUP");
            this.tblFunctionGroup_colsFunctionGroup.NamedProperties.Put("ResizeableChildObject", "");
            this.tblFunctionGroup_colsFunctionGroup.NamedProperties.Put("SqlColumn", "FUNCTION_GROUP");
            this.tblFunctionGroup_colsFunctionGroup.NamedProperties.Put("ValidateMethod", "");
            this.tblFunctionGroup_colsFunctionGroup.Position = 5;
            resources.ApplyResources(this.tblFunctionGroup_colsFunctionGroup, "tblFunctionGroup_colsFunctionGroup");
            this.tblFunctionGroup_colsFunctionGroup.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblFunctionGroup_colsFunctionGroup_WindowActions);
            // 
            // tblFunctionGroup_colDescription
            // 
            this.tblFunctionGroup_colDescription.MaxLength = 2000;
            this.tblFunctionGroup_colDescription.Name = "tblFunctionGroup_colDescription";
            this.tblFunctionGroup_colDescription.NamedProperties.Put("EnumerateMethod", "");
            this.tblFunctionGroup_colDescription.NamedProperties.Put("LovReference", "");
            this.tblFunctionGroup_colDescription.NamedProperties.Put("ParentName", "tblFunctionGroup.tblFunctionGroup_colsFunctionGroup");
            this.tblFunctionGroup_colDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.tblFunctionGroup_colDescription.NamedProperties.Put("SqlColumn", "FUNCTION_GROUP_API.Get_Description(FUNCTION_GROUP)");
            this.tblFunctionGroup_colDescription.NamedProperties.Put("ValidateMethod", "");
            this.tblFunctionGroup_colDescription.Position = 6;
            resources.ApplyResources(this.tblFunctionGroup_colDescription, "tblFunctionGroup_colDescription");
            this.tblFunctionGroup_colDescription.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblFunctionGroup_colDescription_WindowActions);
            // 
            // tblFunctionGroup_colsOptionalAutoBalance
            // 
            this.tblFunctionGroup_colsOptionalAutoBalance.CheckBox.CheckedValue = "Y";
            this.tblFunctionGroup_colsOptionalAutoBalance.CheckBox.IgnoreCase = true;
            this.tblFunctionGroup_colsOptionalAutoBalance.CheckBox.UncheckedValue = "N";
            this.tblFunctionGroup_colsOptionalAutoBalance.MaxLength = 1;
            this.tblFunctionGroup_colsOptionalAutoBalance.Name = "tblFunctionGroup_colsOptionalAutoBalance";
            this.tblFunctionGroup_colsOptionalAutoBalance.NamedProperties.Put("EnumerateMethod", "");
            this.tblFunctionGroup_colsOptionalAutoBalance.NamedProperties.Put("FieldFlags", "294");
            this.tblFunctionGroup_colsOptionalAutoBalance.NamedProperties.Put("LovReference", "");
            this.tblFunctionGroup_colsOptionalAutoBalance.NamedProperties.Put("ResizeableChildObject", "");
            this.tblFunctionGroup_colsOptionalAutoBalance.NamedProperties.Put("SqlColumn", "AUTOMATIC_VOU_BALANCE");
            this.tblFunctionGroup_colsOptionalAutoBalance.NamedProperties.Put("ValidateMethod", "");
            this.tblFunctionGroup_colsOptionalAutoBalance.Position = 7;
            resources.ApplyResources(this.tblFunctionGroup_colsOptionalAutoBalance, "tblFunctionGroup_colsOptionalAutoBalance");
            // 
            // tblFunctionGroup_colsStoreOriginal
            // 
            this.tblFunctionGroup_colsStoreOriginal.CellType = PPJ.Runtime.Windows.CellType.CheckBox;
            this.tblFunctionGroup_colsStoreOriginal.CheckBox.CheckedValue = "Y";
            this.tblFunctionGroup_colsStoreOriginal.CheckBox.IgnoreCase = true;
            this.tblFunctionGroup_colsStoreOriginal.CheckBox.UncheckedValue = "N";
            this.tblFunctionGroup_colsStoreOriginal.MaxLength = 1;
            this.tblFunctionGroup_colsStoreOriginal.Name = "tblFunctionGroup_colsStoreOriginal";
            this.tblFunctionGroup_colsStoreOriginal.NamedProperties.Put("EnumerateMethod", "STORE_ORIGINAL_YES_NO_API.Enumerate");
            this.tblFunctionGroup_colsStoreOriginal.NamedProperties.Put("FieldFlags", "294");
            this.tblFunctionGroup_colsStoreOriginal.NamedProperties.Put("LovReference", "");
            this.tblFunctionGroup_colsStoreOriginal.NamedProperties.Put("ResizeableChildObject", "");
            this.tblFunctionGroup_colsStoreOriginal.NamedProperties.Put("SqlColumn", "STORE_ORIGINAL_DB");
            this.tblFunctionGroup_colsStoreOriginal.NamedProperties.Put("ValidateMethod", "");
            this.tblFunctionGroup_colsStoreOriginal.Position = 8;
            resources.ApplyResources(this.tblFunctionGroup_colsStoreOriginal, "tblFunctionGroup_colsStoreOriginal");
            this.tblFunctionGroup_colsStoreOriginal.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblFunctionGroup_colsStoreOriginal_WindowActions);
            // 
            // tblFunctionGroup_colsRowGrpValidation
            // 
            this.tblFunctionGroup_colsRowGrpValidation.CellType = PPJ.Runtime.Windows.CellType.CheckBox;
            this.tblFunctionGroup_colsRowGrpValidation.CheckBox.CheckedValue = "Y";
            this.tblFunctionGroup_colsRowGrpValidation.CheckBox.IgnoreCase = true;
            this.tblFunctionGroup_colsRowGrpValidation.CheckBox.UncheckedValue = "N";
            this.tblFunctionGroup_colsRowGrpValidation.MaxLength = 1;
            this.tblFunctionGroup_colsRowGrpValidation.Name = "tblFunctionGroup_colsRowGrpValidation";
            this.tblFunctionGroup_colsRowGrpValidation.NamedProperties.Put("EnumerateMethod", "STORE_ORIGINAL_YES_NO_API.Enumerate");
            this.tblFunctionGroup_colsRowGrpValidation.NamedProperties.Put("FieldFlags", "294");
            this.tblFunctionGroup_colsRowGrpValidation.NamedProperties.Put("LovReference", "");
            this.tblFunctionGroup_colsRowGrpValidation.NamedProperties.Put("ResizeableChildObject", "");
            this.tblFunctionGroup_colsRowGrpValidation.NamedProperties.Put("SqlColumn", "ROW_GROUP_VALIDATION");
            this.tblFunctionGroup_colsRowGrpValidation.NamedProperties.Put("ValidateMethod", "");
            this.tblFunctionGroup_colsRowGrpValidation.Position = 9;
            resources.ApplyResources(this.tblFunctionGroup_colsRowGrpValidation, "tblFunctionGroup_colsRowGrpValidation");
            this.tblFunctionGroup_colsRowGrpValidation.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblFunctionGroup_colsRowGrpValidation_WindowActions);
            // 
            // tblFunctionGroup_colsRefMandetory
            // 
            this.tblFunctionGroup_colsRefMandetory.CellType = PPJ.Runtime.Windows.CellType.CheckBox;
            this.tblFunctionGroup_colsRefMandetory.CheckBox.CheckedValue = "Y";
            this.tblFunctionGroup_colsRefMandetory.CheckBox.IgnoreCase = true;
            this.tblFunctionGroup_colsRefMandetory.CheckBox.UncheckedValue = "N";
            this.tblFunctionGroup_colsRefMandetory.MaxLength = 1;
            this.tblFunctionGroup_colsRefMandetory.Name = "tblFunctionGroup_colsRefMandetory";
            this.tblFunctionGroup_colsRefMandetory.NamedProperties.Put("EnumerateMethod", "STORE_ORIGINAL_YES_NO_API.Enumerate");
            this.tblFunctionGroup_colsRefMandetory.NamedProperties.Put("FieldFlags", "294");
            this.tblFunctionGroup_colsRefMandetory.NamedProperties.Put("LovReference", "");
            this.tblFunctionGroup_colsRefMandetory.NamedProperties.Put("ResizeableChildObject", "");
            this.tblFunctionGroup_colsRefMandetory.NamedProperties.Put("SqlColumn", "REFERENCE_MANDATORY");
            this.tblFunctionGroup_colsRefMandetory.NamedProperties.Put("ValidateMethod", "");
            this.tblFunctionGroup_colsRefMandetory.Position = 10;
            resources.ApplyResources(this.tblFunctionGroup_colsRefMandetory, "tblFunctionGroup_colsRefMandetory");
            this.tblFunctionGroup_colsRefMandetory.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblFunctionGroup_colsRefMandetory_WindowActions);
            // 
            // tblFunctionGroup_colsSingleFunction
            // 
            this.tblFunctionGroup_colsSingleFunction.CheckBox.CheckedValue = "Y";
            this.tblFunctionGroup_colsSingleFunction.CheckBox.IgnoreCase = true;
            this.tblFunctionGroup_colsSingleFunction.CheckBox.UncheckedValue = "N";
            resources.ApplyResources(this.tblFunctionGroup_colsSingleFunction, "tblFunctionGroup_colsSingleFunction");
            this.tblFunctionGroup_colsSingleFunction.MaxLength = 1;
            this.tblFunctionGroup_colsSingleFunction.Name = "tblFunctionGroup_colsSingleFunction";
            this.tblFunctionGroup_colsSingleFunction.NamedProperties.Put("EnumerateMethod", "");
            this.tblFunctionGroup_colsSingleFunction.NamedProperties.Put("FieldFlags", "294");
            this.tblFunctionGroup_colsSingleFunction.NamedProperties.Put("LovReference", "");
            this.tblFunctionGroup_colsSingleFunction.NamedProperties.Put("ResizeableChildObject", "");
            this.tblFunctionGroup_colsSingleFunction.NamedProperties.Put("SqlColumn", "SINGLE_FUNCTION_GROUP");
            this.tblFunctionGroup_colsSingleFunction.NamedProperties.Put("ValidateMethod", "");
            this.tblFunctionGroup_colsSingleFunction.Position = 11;
            this.tblFunctionGroup_colsSingleFunction.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblFunctionGroup_colsSingleFunction_WindowActions);
            // 
            // tblFunctionGroup_colsAutomaticAllot
            // 
            this.tblFunctionGroup_colsAutomaticAllot.CellType = PPJ.Runtime.Windows.CellType.CheckBox;
            this.tblFunctionGroup_colsAutomaticAllot.CheckBox.CheckedValue = "Y";
            this.tblFunctionGroup_colsAutomaticAllot.CheckBox.IgnoreCase = true;
            this.tblFunctionGroup_colsAutomaticAllot.CheckBox.UncheckedValue = "N";
            resources.ApplyResources(this.tblFunctionGroup_colsAutomaticAllot, "tblFunctionGroup_colsAutomaticAllot");
            this.tblFunctionGroup_colsAutomaticAllot.MaxLength = 1;
            this.tblFunctionGroup_colsAutomaticAllot.Name = "tblFunctionGroup_colsAutomaticAllot";
            this.tblFunctionGroup_colsAutomaticAllot.NamedProperties.Put("EnumerateMethod", "AUTOMATIC_ALLOTMENT_API.Enumerate");
            this.tblFunctionGroup_colsAutomaticAllot.NamedProperties.Put("FieldFlags", "294");
            this.tblFunctionGroup_colsAutomaticAllot.NamedProperties.Put("LovReference", "");
            this.tblFunctionGroup_colsAutomaticAllot.NamedProperties.Put("ResizeableChildObject", "");
            this.tblFunctionGroup_colsAutomaticAllot.NamedProperties.Put("SqlColumn", "AUTOMATIC_ALLOT_DB");
            this.tblFunctionGroup_colsAutomaticAllot.NamedProperties.Put("ValidateMethod", "");
            this.tblFunctionGroup_colsAutomaticAllot.Position = 12;
            // 
            // tblVoucherSeries
            // 
            this.tblVoucherSeries.Controls.Add(this.tblVoucherSeries_colsCompany);
            this.tblVoucherSeries.Controls.Add(this.tblVoucherSeries_colsVoucherType);
            this.tblVoucherSeries.Controls.Add(this.tblVoucherSeries_colnAccountingYear);
            this.tblVoucherSeries.Controls.Add(this.tblVoucherSeries_colnPeriod);
            this.tblVoucherSeries.Controls.Add(this.tblVoucherSeries_colnSerieFrom);
            this.tblVoucherSeries.Controls.Add(this.tblVoucherSeries_colnSerieUntil);
            this.tblVoucherSeries.Controls.Add(this.tblVoucherSeries_colnCurrentNumber);
            resources.ApplyResources(this.tblVoucherSeries, "tblVoucherSeries");
            this.tblVoucherSeries.Name = "tblVoucherSeries";
            this.tblVoucherSeries.NamedProperties.Put("DefaultOrderBy", "");
            this.tblVoucherSeries.NamedProperties.Put("DefaultWhere", "");
            this.tblVoucherSeries.NamedProperties.Put("LogicalUnit", "VoucherNoSerial");
            this.tblVoucherSeries.NamedProperties.Put("PackageName", "VOUCHER_NO_SERIAL_API");
            this.tblVoucherSeries.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherSeries.NamedProperties.Put("ViewName", "VOUCHER_NO_SERIAL");
            this.tblVoucherSeries.NamedProperties.Put("Warnings", "FALSE");
            this.tblVoucherSeries.DataRecordGetDefaultsEvent += new System.EventHandler<Ifs.Fnd.ApplicationForms.FndReturnEventArgsSalBoolean>(this.tblVoucherSeries_DataRecordGetDefaultsEvent);
            this.tblVoucherSeries.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVoucherSeries_WindowActions);
            this.tblVoucherSeries.Controls.SetChildIndex(this.tblVoucherSeries_colnCurrentNumber, 0);
            this.tblVoucherSeries.Controls.SetChildIndex(this.tblVoucherSeries_colnSerieUntil, 0);
            this.tblVoucherSeries.Controls.SetChildIndex(this.tblVoucherSeries_colnSerieFrom, 0);
            this.tblVoucherSeries.Controls.SetChildIndex(this.tblVoucherSeries_colnPeriod, 0);
            this.tblVoucherSeries.Controls.SetChildIndex(this.tblVoucherSeries_colnAccountingYear, 0);
            this.tblVoucherSeries.Controls.SetChildIndex(this.tblVoucherSeries_colsVoucherType, 0);
            this.tblVoucherSeries.Controls.SetChildIndex(this.tblVoucherSeries_colsCompany, 0);
            // 
            // tblVoucherSeries_colsCompany
            // 
            this.tblVoucherSeries_colsCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblVoucherSeries_colsCompany, "tblVoucherSeries_colsCompany");
            this.tblVoucherSeries_colsCompany.MaxLength = 20;
            this.tblVoucherSeries_colsCompany.Name = "tblVoucherSeries_colsCompany";
            this.tblVoucherSeries_colsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherSeries_colsCompany.NamedProperties.Put("FieldFlags", "67");
            this.tblVoucherSeries_colsCompany.NamedProperties.Put("LovReference", "");
            this.tblVoucherSeries_colsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.tblVoucherSeries_colsCompany.Position = 3;
            // 
            // tblVoucherSeries_colsVoucherType
            // 
            this.tblVoucherSeries_colsVoucherType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblVoucherSeries_colsVoucherType, "tblVoucherSeries_colsVoucherType");
            this.tblVoucherSeries_colsVoucherType.MaxLength = 3;
            this.tblVoucherSeries_colsVoucherType.Name = "tblVoucherSeries_colsVoucherType";
            this.tblVoucherSeries_colsVoucherType.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherSeries_colsVoucherType.NamedProperties.Put("FieldFlags", "67");
            this.tblVoucherSeries_colsVoucherType.NamedProperties.Put("LovReference", "");
            this.tblVoucherSeries_colsVoucherType.NamedProperties.Put("SqlColumn", "VOUCHER_TYPE");
            this.tblVoucherSeries_colsVoucherType.Position = 4;
            // 
            // tblVoucherSeries_colnAccountingYear
            // 
            this.tblVoucherSeries_colnAccountingYear.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVoucherSeries_colnAccountingYear.MaxLength = 4;
            this.tblVoucherSeries_colnAccountingYear.Name = "tblVoucherSeries_colnAccountingYear";
            this.tblVoucherSeries_colnAccountingYear.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherSeries_colnAccountingYear.NamedProperties.Put("FieldFlags", "163");
            this.tblVoucherSeries_colnAccountingYear.NamedProperties.Put("LovReference", "ACCOUNTING_YEAR(COMPANY)");
            this.tblVoucherSeries_colnAccountingYear.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherSeries_colnAccountingYear.NamedProperties.Put("SqlColumn", "ACCOUNTING_YEAR");
            this.tblVoucherSeries_colnAccountingYear.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherSeries_colnAccountingYear.Position = 5;
            resources.ApplyResources(this.tblVoucherSeries_colnAccountingYear, "tblVoucherSeries_colnAccountingYear");
            this.tblVoucherSeries_colnAccountingYear.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVoucherSeries_colnAccountingYear_WindowActions);
            // 
            // tblVoucherSeries_colnPeriod
            // 
            this.tblVoucherSeries_colnPeriod.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVoucherSeries_colnPeriod.Name = "tblVoucherSeries_colnPeriod";
            this.tblVoucherSeries_colnPeriod.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherSeries_colnPeriod.NamedProperties.Put("FieldFlags", "162");
            this.tblVoucherSeries_colnPeriod.NamedProperties.Put("LovReference", "ACCOUNTING_PERIOD(COMPANY,ACCOUNTING_YEAR)");
            this.tblVoucherSeries_colnPeriod.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherSeries_colnPeriod.NamedProperties.Put("SqlColumn", "PERIOD");
            this.tblVoucherSeries_colnPeriod.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherSeries_colnPeriod.Position = 6;
            resources.ApplyResources(this.tblVoucherSeries_colnPeriod, "tblVoucherSeries_colnPeriod");
            this.tblVoucherSeries_colnPeriod.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVoucherSeries_colnPeriod_WindowActions);
            // 
            // tblVoucherSeries_colnSerieFrom
            // 
            this.tblVoucherSeries_colnSerieFrom.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVoucherSeries_colnSerieFrom.MaxLength = 10;
            this.tblVoucherSeries_colnSerieFrom.Name = "tblVoucherSeries_colnSerieFrom";
            this.tblVoucherSeries_colnSerieFrom.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherSeries_colnSerieFrom.NamedProperties.Put("FieldFlags", "295");
            this.tblVoucherSeries_colnSerieFrom.NamedProperties.Put("LovReference", "");
            this.tblVoucherSeries_colnSerieFrom.NamedProperties.Put("SqlColumn", "SERIE_FROM");
            this.tblVoucherSeries_colnSerieFrom.Position = 7;
            resources.ApplyResources(this.tblVoucherSeries_colnSerieFrom, "tblVoucherSeries_colnSerieFrom");
            this.tblVoucherSeries_colnSerieFrom.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVoucherSeries_colnSerieFrom_WindowActions);
            // 
            // tblVoucherSeries_colnSerieUntil
            // 
            this.tblVoucherSeries_colnSerieUntil.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVoucherSeries_colnSerieUntil.MaxLength = 10;
            this.tblVoucherSeries_colnSerieUntil.Name = "tblVoucherSeries_colnSerieUntil";
            this.tblVoucherSeries_colnSerieUntil.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherSeries_colnSerieUntil.NamedProperties.Put("FieldFlags", "295");
            this.tblVoucherSeries_colnSerieUntil.NamedProperties.Put("LovReference", "");
            this.tblVoucherSeries_colnSerieUntil.NamedProperties.Put("SqlColumn", "SERIE_UNTIL");
            this.tblVoucherSeries_colnSerieUntil.Position = 8;
            resources.ApplyResources(this.tblVoucherSeries_colnSerieUntil, "tblVoucherSeries_colnSerieUntil");
            this.tblVoucherSeries_colnSerieUntil.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVoucherSeries_colnSerieUntil_WindowActions);
            // 
            // tblVoucherSeries_colnCurrentNumber
            // 
            this.tblVoucherSeries_colnCurrentNumber.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVoucherSeries_colnCurrentNumber.MaxLength = 10;
            this.tblVoucherSeries_colnCurrentNumber.Name = "tblVoucherSeries_colnCurrentNumber";
            this.tblVoucherSeries_colnCurrentNumber.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherSeries_colnCurrentNumber.NamedProperties.Put("FieldFlags", "295");
            this.tblVoucherSeries_colnCurrentNumber.NamedProperties.Put("LovReference", "");
            this.tblVoucherSeries_colnCurrentNumber.NamedProperties.Put("SqlColumn", "CURRENT_NUMBER");
            this.tblVoucherSeries_colnCurrentNumber.Position = 9;
            resources.ApplyResources(this.tblVoucherSeries_colnCurrentNumber, "tblVoucherSeries_colnCurrentNumber");
            // 
            // cmbCompany
            // 
            resources.ApplyResources(this.cmbCompany, "cmbCompany");
            this.cmbCompany.FormattingEnabled = true;
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.NamedProperties.Put("EnumerateMethod", "");
            this.cmbCompany.NamedProperties.Put("FieldFlags", "293");
            this.cmbCompany.NamedProperties.Put("LovReference", "COMPANY_FINANCE");
            this.cmbCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.cmbCompany.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbCompany_WindowActions);
            // 
            // labelcmbCompany
            // 
            resources.ApplyResources(this.labelcmbCompany, "labelcmbCompany");
            this.labelcmbCompany.Name = "labelcmbCompany";
            // 
            // dfCompanyDesc
            // 
            resources.ApplyResources(this.dfCompanyDesc, "dfCompanyDesc");
            this.dfCompanyDesc.Name = "dfCompanyDesc";
            // 
            // cmbAuthLevel
            // 
            resources.ApplyResources(this.cmbAuthLevel, "cmbAuthLevel");
            this.cmbAuthLevel.Name = "cmbAuthLevel";
            this.cmbAuthLevel.NamedProperties.Put("EnumerateMethod", "Authorize_Level_Api.Enumerate");
            this.cmbAuthLevel.NamedProperties.Put("FieldFlags", "263");
            this.cmbAuthLevel.NamedProperties.Put("LovReference", "");
            this.cmbAuthLevel.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbAuthLevel.NamedProperties.Put("SqlColumn", "");
            this.cmbAuthLevel.NamedProperties.Put("ValidateMethod", "");
            // 
            // cmbDefaultType
            // 
            resources.ApplyResources(this.cmbDefaultType, "cmbDefaultType");
            this.cmbDefaultType.Name = "cmbDefaultType";
            this.cmbDefaultType.NamedProperties.Put("EnumerateMethod", "Default_Type_Api.Enumerate");
            this.cmbDefaultType.NamedProperties.Put("FieldFlags", "263");
            this.cmbDefaultType.NamedProperties.Put("LovReference", "");
            this.cmbDefaultType.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbDefaultType.NamedProperties.Put("SqlColumn", "");
            this.cmbDefaultType.NamedProperties.Put("ValidateMethod", "");
            // 
            // dfHeading1
            // 
            resources.ApplyResources(this.dfHeading1, "dfHeading1");
            this.dfHeading1.Name = "dfHeading1";
            this.dfHeading1.NamedProperties.Put("EnumerateMethod", "");
            this.dfHeading1.NamedProperties.Put("FieldFlags", "262");
            this.dfHeading1.NamedProperties.Put("LovReference", "");
            this.dfHeading1.NamedProperties.Put("ResizeableChildObject", "");
            this.dfHeading1.NamedProperties.Put("SqlColumn", "");
            this.dfHeading1.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfHeading1
            // 
            resources.ApplyResources(this.labeldfHeading1, "labeldfHeading1");
            this.labeldfHeading1.Name = "labeldfHeading1";
            // 
            // dlgVoucherType
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "dlgVoucherType";
            this.NamedProperties.Put("Module", "%");
            this.NamedProperties.Put("SourceFlags", "449");
            this.NamedProperties.Put("Step3", @"!3
$STEP=Step4
$CONTROLS=cmbAuthLevel_\u_cmbDefaultType_\u_cmbFunctionGroup_\u_dfFunctionGroup_\u_dfUserGroup_\u_dfUserGroupDesc_\u_rbAll_\u_rbSingle_\u_tblVoucherSeries_\u_User_Group_Selection_\u_
$INTERNAL=T
$PICTURE=bmpAccrulCreateVouTypes
$TITLE=Create Voucher Types
");
            this.ShowIcon = false;
            this.ShowList = true;
            this.ShowPicture = true;
            this.WizardSteps.Add(this.Step1);
            this.WizardSteps.Add(this.Step2);
            this.WizardSteps.Add(this.Step3);
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dlgVoucherType_WindowActions);
            ((System.ComponentModel.ISupportInitialize)(this.picWizard)).EndInit();
            this.ToolBar.ResumeLayout(false);
            this.ClientArea.ResumeLayout(false);
            this.ClientArea.PerformLayout();
            this.tblFunctionGroup.ResumeLayout(false);
            this.tblVoucherSeries.ResumeLayout(false);
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

        protected __cWizardStep Step1;
        protected __cWizardStep Step2;
        protected __cWizardStep Step3;
        public cChildTableFin tblFunctionGroup;
        protected cColumn tblFunctionGroup_colsCompany;
        protected cColumn tblFunctionGroup_colsVoucherType;
        protected cColumn tblFunctionGroup_colsFunctionGroup;
        protected cColumn tblFunctionGroup_colDescription;
        protected cLookupColumn tblFunctionGroup_colsStoreOriginal;
        protected cLookupColumn tblFunctionGroup_colsRowGrpValidation;
        protected cLookupColumn tblFunctionGroup_colsRefMandetory;
        protected cLookupColumn tblFunctionGroup_colsAutomaticAllot;
        public cChildTableFin tblVoucherSeries;
        protected cColumn tblVoucherSeries_colsCompany;
        protected cColumn tblVoucherSeries_colsVoucherType;
        protected cColumn tblVoucherSeries_colnAccountingYear;
        protected cColumn tblVoucherSeries_colnPeriod;
        protected cColumn tblVoucherSeries_colnSerieFrom;
        protected cColumn tblVoucherSeries_colnSerieUntil;
        protected cColumn tblVoucherSeries_colnCurrentNumber;
        protected cCheckBoxColumn tblFunctionGroup_colsOptionalAutoBalance;
        protected cCheckBoxColumn tblFunctionGroup_colsSingleFunction;
        protected cBackgroundText labelcmbCompany;
        protected cComboBox cmbCompany;
        protected cDataField dfCompanyDesc;
        public cDataField dfHeading1;
        protected cBackgroundText labeldfHeading1;
				
	}
}
