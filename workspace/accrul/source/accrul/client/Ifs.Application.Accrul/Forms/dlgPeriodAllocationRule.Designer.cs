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
	
	public partial class dlgPeriodAllocationRule
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cPushButton pbOk;
		public cPushButton pbCancel;
		public cPushButton pbDistr;
		public cPushButton pbNew;
		public cPushButton pbRemove;
		public cPushButton pbSave;
		public cDataField dfnAllocationId;
		public cDataField dfnParentAllocationId;
		protected cBackgroundText labeldfdFromDate;
		public cDataField dfdFromDate;
		protected cBackgroundText labeldfdUntilDate;
		public cDataField dfdUntilDate;
		protected cBackgroundText labeldfsCurrencyCode;
		public cDataField dfsCurrencyCode;
		protected cBackgroundText labeldfnTotalAmount;
		public cDataField dfnTotalAmount;
		protected cBackgroundText labeldfsCreatorDesc;
		public cDataField dfsCreatorDesc;
		protected cBackgroundText labelcmbDistrType;
		public cComboBox cmbDistrType;
		protected cBackgroundText labeldfnSumPercentage;
		public cDataField dfnSumPercentage;
		protected cBackgroundText labeldfnSumAmount;
		public cDataField dfnSumAmount;
		// Hidden Fields
		// Message Actions
		public cDataField dfsCompany;
		public cDataField dfsCreator;
		public cDataField dfsStatus;
		public cDataField dfsDistrTypeDb;
		public cDataField dfnCurrRound;
		// Message Actions
        // Bug 73298 Begin - Changed the derived base class.
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgPeriodAllocationRule));
            this.pbOk = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbCancel = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbDistr = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbNew = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbRemove = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbSave = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.dfnAllocationId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfnParentAllocationId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfdFromDate = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfdFromDate = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfdUntilDate = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfdUntilDate = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsCurrencyCode = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsCurrencyCode = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfnTotalAmount = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfnTotalAmount = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsCreatorDesc = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsCreatorDesc = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelcmbDistrType = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbDistrType = new Ifs.Fnd.ApplicationForms.cComboBox();
            this.labeldfnSumPercentage = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfnSumPercentage = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfnSumAmount = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfnSumAmount = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsCompany = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsCreator = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsStatus = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsDistrTypeDb = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfnCurrRound = new Ifs.Fnd.ApplicationForms.cDataField();
            this.tblPeriod = new Ifs.Application.Accrul.cChildTableFinBase();
            this.tblPeriod_colnAllocationId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPeriod_colnAllocLineId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPeriod_colnAccountingYear = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPeriod_colnAccountingPeriod = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPeriod_colsYearPeriodDisp = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPeriod_colnPercentage = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPeriod_colnAmount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPeriod_colsAllocationDiff = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.ClientArea.SuspendLayout();
            this.tblPeriod.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolBar
            // 
            resources.ApplyResources(this.ToolBar, "ToolBar");
            // 
            // ClientArea
            // 
            this.ClientArea.Controls.Add(this.tblPeriod);
            this.ClientArea.Controls.Add(this.dfnCurrRound);
            this.ClientArea.Controls.Add(this.dfsDistrTypeDb);
            this.ClientArea.Controls.Add(this.dfsStatus);
            this.ClientArea.Controls.Add(this.dfsCreator);
            this.ClientArea.Controls.Add(this.dfsCompany);
            this.ClientArea.Controls.Add(this.dfnSumAmount);
            this.ClientArea.Controls.Add(this.dfnSumPercentage);
            this.ClientArea.Controls.Add(this.cmbDistrType);
            this.ClientArea.Controls.Add(this.dfsCreatorDesc);
            this.ClientArea.Controls.Add(this.dfnTotalAmount);
            this.ClientArea.Controls.Add(this.dfsCurrencyCode);
            this.ClientArea.Controls.Add(this.dfdUntilDate);
            this.ClientArea.Controls.Add(this.dfdFromDate);
            this.ClientArea.Controls.Add(this.dfnParentAllocationId);
            this.ClientArea.Controls.Add(this.dfnAllocationId);
            this.ClientArea.Controls.Add(this.pbSave);
            this.ClientArea.Controls.Add(this.pbRemove);
            this.ClientArea.Controls.Add(this.pbNew);
            this.ClientArea.Controls.Add(this.pbDistr);
            this.ClientArea.Controls.Add(this.pbCancel);
            this.ClientArea.Controls.Add(this.pbOk);
            this.ClientArea.Controls.Add(this.labeldfnSumAmount);
            this.ClientArea.Controls.Add(this.labeldfnSumPercentage);
            this.ClientArea.Controls.Add(this.labelcmbDistrType);
            this.ClientArea.Controls.Add(this.labeldfsCreatorDesc);
            this.ClientArea.Controls.Add(this.labeldfnTotalAmount);
            this.ClientArea.Controls.Add(this.labeldfsCurrencyCode);
            this.ClientArea.Controls.Add(this.labeldfdUntilDate);
            this.ClientArea.Controls.Add(this.labeldfdFromDate);
            resources.ApplyResources(this.ClientArea, "ClientArea");
            // 
            // StatusBar
            // 
            this.StatusBar.Create = true;
            resources.ApplyResources(this.StatusBar, "StatusBar");
            // 
            // commandManager
            // 
            this.commandManager.Components.Add(this.pbSave);
            this.commandManager.Components.Add(this.pbRemove);
            this.commandManager.Components.Add(this.pbNew);
            this.commandManager.Components.Add(this.pbDistr);
            this.commandManager.Components.Add(this.pbCancel);
            this.commandManager.Components.Add(this.pbOk);
            // 
            // pbOk
            // 
            this.pbOk.AcceleratorKey = System.Windows.Forms.Keys.Return;
            resources.ApplyResources(this.pbOk, "pbOk");
            this.pbOk.Name = "pbOk";
            this.pbOk.NamedProperties.Put("MethodId", "18385");
            this.pbOk.NamedProperties.Put("MethodParameter", "Ok");
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
            // pbDistr
            // 
            resources.ApplyResources(this.pbDistr, "pbDistr");
            this.pbDistr.Name = "pbDistr";
            this.pbDistr.NamedProperties.Put("MethodId", "18385");
            this.pbDistr.NamedProperties.Put("MethodParameter", "Distr");
            this.pbDistr.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // pbNew
            // 
            resources.ApplyResources(this.pbNew, "pbNew");
            this.pbNew.Name = "pbNew";
            this.pbNew.NamedProperties.Put("MethodId", "18385");
            this.pbNew.NamedProperties.Put("MethodParameter", "New");
            this.pbNew.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // pbRemove
            // 
            resources.ApplyResources(this.pbRemove, "pbRemove");
            this.pbRemove.Name = "pbRemove";
            this.pbRemove.NamedProperties.Put("MethodId", "18385");
            this.pbRemove.NamedProperties.Put("MethodParameter", "Remove");
            this.pbRemove.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // pbSave
            // 
            resources.ApplyResources(this.pbSave, "pbSave");
            this.pbSave.Name = "pbSave";
            this.pbSave.NamedProperties.Put("MethodId", "18385");
            this.pbSave.NamedProperties.Put("MethodParameter", "Save");
            this.pbSave.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // dfnAllocationId
            // 
            this.dfnAllocationId.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfnAllocationId, "dfnAllocationId");
            this.dfnAllocationId.Name = "dfnAllocationId";
            this.dfnAllocationId.NamedProperties.Put("EnumerateMethod", "");
            this.dfnAllocationId.NamedProperties.Put("FieldFlags", "131");
            this.dfnAllocationId.NamedProperties.Put("LovReference", "");
            this.dfnAllocationId.NamedProperties.Put("ResizeableChildObject", "");
            this.dfnAllocationId.NamedProperties.Put("SqlColumn", "ALLOCATION_ID");
            this.dfnAllocationId.NamedProperties.Put("ValidateMethod", "");
            // 
            // dfnParentAllocationId
            // 
            this.dfnParentAllocationId.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfnParentAllocationId, "dfnParentAllocationId");
            this.dfnParentAllocationId.Name = "dfnParentAllocationId";
            this.dfnParentAllocationId.NamedProperties.Put("EnumerateMethod", "");
            this.dfnParentAllocationId.NamedProperties.Put("FieldFlags", "262");
            this.dfnParentAllocationId.NamedProperties.Put("LovReference", "");
            this.dfnParentAllocationId.NamedProperties.Put("ResizeableChildObject", "");
            this.dfnParentAllocationId.NamedProperties.Put("SqlColumn", "PARENT_ALLOCATION_ID");
            this.dfnParentAllocationId.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfdFromDate
            // 
            resources.ApplyResources(this.labeldfdFromDate, "labeldfdFromDate");
            this.labeldfdFromDate.Name = "labeldfdFromDate";
            // 
            // dfdFromDate
            // 
            this.dfdFromDate.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.dfdFromDate.Format = "d";
            resources.ApplyResources(this.dfdFromDate, "dfdFromDate");
            this.dfdFromDate.Name = "dfdFromDate";
            this.dfdFromDate.NamedProperties.Put("EnumerateMethod", "");
            this.dfdFromDate.NamedProperties.Put("FieldFlags", "263");
            this.dfdFromDate.NamedProperties.Put("LovReference", "");
            this.dfdFromDate.NamedProperties.Put("ResizeableChildObject", "");
            this.dfdFromDate.NamedProperties.Put("SqlColumn", "FROM_DATE");
            this.dfdFromDate.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfdUntilDate
            // 
            resources.ApplyResources(this.labeldfdUntilDate, "labeldfdUntilDate");
            this.labeldfdUntilDate.Name = "labeldfdUntilDate";
            // 
            // dfdUntilDate
            // 
            this.dfdUntilDate.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.dfdUntilDate.Format = "d";
            resources.ApplyResources(this.dfdUntilDate, "dfdUntilDate");
            this.dfdUntilDate.Name = "dfdUntilDate";
            this.dfdUntilDate.NamedProperties.Put("EnumerateMethod", "");
            this.dfdUntilDate.NamedProperties.Put("FieldFlags", "262");
            this.dfdUntilDate.NamedProperties.Put("LovReference", "");
            this.dfdUntilDate.NamedProperties.Put("ResizeableChildObject", "");
            this.dfdUntilDate.NamedProperties.Put("SqlColumn", "UNTIL_DATE");
            this.dfdUntilDate.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsCurrencyCode
            // 
            resources.ApplyResources(this.labeldfsCurrencyCode, "labeldfsCurrencyCode");
            this.labeldfsCurrencyCode.Name = "labeldfsCurrencyCode";
            // 
            // dfsCurrencyCode
            // 
            resources.ApplyResources(this.dfsCurrencyCode, "dfsCurrencyCode");
            this.dfsCurrencyCode.Name = "dfsCurrencyCode";
            this.dfsCurrencyCode.NamedProperties.Put("EnumerateMethod", "");
            this.dfsCurrencyCode.NamedProperties.Put("FieldFlags", "258");
            this.dfsCurrencyCode.NamedProperties.Put("LovReference", "");
            this.dfsCurrencyCode.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsCurrencyCode.NamedProperties.Put("SqlColumn", "CURRENCY_CODE");
            this.dfsCurrencyCode.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfnTotalAmount
            // 
            resources.ApplyResources(this.labeldfnTotalAmount, "labeldfnTotalAmount");
            this.labeldfnTotalAmount.Name = "labeldfnTotalAmount";
            // 
            // dfnTotalAmount
            // 
            this.dfnTotalAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfnTotalAmount, "dfnTotalAmount");
            this.dfnTotalAmount.Name = "dfnTotalAmount";
            this.dfnTotalAmount.NamedProperties.Put("EnumerateMethod", "");
            this.dfnTotalAmount.NamedProperties.Put("FieldFlags", "258");
            this.dfnTotalAmount.NamedProperties.Put("Format", "20");
            this.dfnTotalAmount.NamedProperties.Put("LovReference", "");
            this.dfnTotalAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.dfnTotalAmount.NamedProperties.Put("SqlColumn", "TOTAL_AMOUNT");
            this.dfnTotalAmount.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsCreatorDesc
            // 
            resources.ApplyResources(this.labeldfsCreatorDesc, "labeldfsCreatorDesc");
            this.labeldfsCreatorDesc.Name = "labeldfsCreatorDesc";
            // 
            // dfsCreatorDesc
            // 
            resources.ApplyResources(this.dfsCreatorDesc, "dfsCreatorDesc");
            this.dfsCreatorDesc.Name = "dfsCreatorDesc";
            this.dfsCreatorDesc.NamedProperties.Put("EnumerateMethod", "");
            this.dfsCreatorDesc.NamedProperties.Put("FieldFlags", "290");
            this.dfsCreatorDesc.NamedProperties.Put("LovReference", "");
            this.dfsCreatorDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsCreatorDesc.NamedProperties.Put("SqlColumn", "CREATOR_DESC");
            this.dfsCreatorDesc.NamedProperties.Put("ValidateMethod", "");
            // 
            // labelcmbDistrType
            // 
            resources.ApplyResources(this.labelcmbDistrType, "labelcmbDistrType");
            this.labelcmbDistrType.Name = "labelcmbDistrType";
            // 
            // cmbDistrType
            // 
            resources.ApplyResources(this.cmbDistrType, "cmbDistrType");
            this.cmbDistrType.Name = "cmbDistrType";
            this.cmbDistrType.NamedProperties.Put("EnumerateMethod", "PERIOD_ALLOC_PER_DISTR_API.Enumerate");
            this.cmbDistrType.NamedProperties.Put("FieldFlags", "263");
            this.cmbDistrType.NamedProperties.Put("LovReference", "");
            this.cmbDistrType.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbDistrType.NamedProperties.Put("SqlColumn", "DISTR_TYPE");
            this.cmbDistrType.NamedProperties.Put("ValidateMethod", "");
            this.cmbDistrType.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbDistrType_WindowActions);
            // 
            // labeldfnSumPercentage
            // 
            resources.ApplyResources(this.labeldfnSumPercentage, "labeldfnSumPercentage");
            this.labeldfnSumPercentage.Name = "labeldfnSumPercentage";
            // 
            // dfnSumPercentage
            // 
            resources.ApplyResources(this.dfnSumPercentage, "dfnSumPercentage");
            this.dfnSumPercentage.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.dfnSumPercentage.Name = "dfnSumPercentage";
            this.dfnSumPercentage.NamedProperties.Put("EnumerateMethod", "");
            this.dfnSumPercentage.NamedProperties.Put("FieldFlags", "258");
            this.dfnSumPercentage.NamedProperties.Put("Format", "20");
            this.dfnSumPercentage.NamedProperties.Put("LovReference", "");
            this.dfnSumPercentage.NamedProperties.Put("ResizeableChildObject", "");
            this.dfnSumPercentage.NamedProperties.Put("SqlColumn", "");
            this.dfnSumPercentage.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfnSumAmount
            // 
            resources.ApplyResources(this.labeldfnSumAmount, "labeldfnSumAmount");
            this.labeldfnSumAmount.Name = "labeldfnSumAmount";
            // 
            // dfnSumAmount
            // 
            resources.ApplyResources(this.dfnSumAmount, "dfnSumAmount");
            this.dfnSumAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.dfnSumAmount.Name = "dfnSumAmount";
            this.dfnSumAmount.NamedProperties.Put("EnumerateMethod", "");
            this.dfnSumAmount.NamedProperties.Put("FieldFlags", "258");
            this.dfnSumAmount.NamedProperties.Put("Format", "20");
            this.dfnSumAmount.NamedProperties.Put("LovReference", "");
            this.dfnSumAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.dfnSumAmount.NamedProperties.Put("SqlColumn", "");
            this.dfnSumAmount.NamedProperties.Put("ValidateMethod", "");
            // 
            // dfsCompany
            // 
            this.dfsCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsCompany, "dfsCompany");
            this.dfsCompany.Name = "dfsCompany";
            this.dfsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.dfsCompany.NamedProperties.Put("FieldFlags", "259");
            this.dfsCompany.NamedProperties.Put("LovReference", "");
            this.dfsCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.dfsCompany.NamedProperties.Put("ValidateMethod", "");
            // 
            // dfsCreator
            // 
            resources.ApplyResources(this.dfsCreator, "dfsCreator");
            this.dfsCreator.Name = "dfsCreator";
            this.dfsCreator.NamedProperties.Put("EnumerateMethod", "");
            this.dfsCreator.NamedProperties.Put("FieldFlags", "258");
            this.dfsCreator.NamedProperties.Put("LovReference", "");
            this.dfsCreator.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsCreator.NamedProperties.Put("SqlColumn", "CREATOR");
            this.dfsCreator.NamedProperties.Put("ValidateMethod", "");
            // 
            // dfsStatus
            // 
            resources.ApplyResources(this.dfsStatus, "dfsStatus");
            this.dfsStatus.Name = "dfsStatus";
            this.dfsStatus.NamedProperties.Put("EnumerateMethod", "");
            this.dfsStatus.NamedProperties.Put("FieldFlags", "258");
            this.dfsStatus.NamedProperties.Put("LovReference", "");
            this.dfsStatus.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsStatus.NamedProperties.Put("SqlColumn", "STATUS");
            this.dfsStatus.NamedProperties.Put("ValidateMethod", "");
            // 
            // dfsDistrTypeDb
            // 
            resources.ApplyResources(this.dfsDistrTypeDb, "dfsDistrTypeDb");
            this.dfsDistrTypeDb.Name = "dfsDistrTypeDb";
            this.dfsDistrTypeDb.NamedProperties.Put("EnumerateMethod", "");
            this.dfsDistrTypeDb.NamedProperties.Put("FieldFlags", "263");
            this.dfsDistrTypeDb.NamedProperties.Put("LovReference", "");
            this.dfsDistrTypeDb.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsDistrTypeDb.NamedProperties.Put("SqlColumn", "DISTR_TYPE_DB");
            this.dfsDistrTypeDb.NamedProperties.Put("ValidateMethod", "");
            // 
            // dfnCurrRound
            // 
            this.dfnCurrRound.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfnCurrRound, "dfnCurrRound");
            this.dfnCurrRound.Name = "dfnCurrRound";
            this.dfnCurrRound.NamedProperties.Put("EnumerateMethod", "");
            this.dfnCurrRound.NamedProperties.Put("FieldFlags", "259");
            this.dfnCurrRound.NamedProperties.Put("LovReference", "");
            this.dfnCurrRound.NamedProperties.Put("ResizeableChildObject", "");
            this.dfnCurrRound.NamedProperties.Put("SqlColumn", "&AO.Currency_Code_API.Get_Currency_Rounding(Company,Currency_Code)");
            this.dfnCurrRound.NamedProperties.Put("ValidateMethod", "");
            // 
            // tblPeriod
            // 
            resources.ApplyResources(this.tblPeriod, "tblPeriod");
            this.tblPeriod.Controls.Add(this.tblPeriod_colnAllocationId);
            this.tblPeriod.Controls.Add(this.tblPeriod_colnAllocLineId);
            this.tblPeriod.Controls.Add(this.tblPeriod_colnAccountingYear);
            this.tblPeriod.Controls.Add(this.tblPeriod_colnAccountingPeriod);
            this.tblPeriod.Controls.Add(this.tblPeriod_colsYearPeriodDisp);
            this.tblPeriod.Controls.Add(this.tblPeriod_colnPercentage);
            this.tblPeriod.Controls.Add(this.tblPeriod_colnAmount);
            this.tblPeriod.Controls.Add(this.tblPeriod_colsAllocationDiff);
            this.tblPeriod.Name = "tblPeriod";
            this.tblPeriod.NamedProperties.Put("DefaultOrderBy", "ACCOUNTING_YEAR, ACCOUNTING_PERIOD");
            this.tblPeriod.NamedProperties.Put("DefaultWhere", "");
            this.tblPeriod.NamedProperties.Put("LogicalUnit", "PeriodAllocRuleLine");
            this.tblPeriod.NamedProperties.Put("PackageName", "PERIOD_ALLOC_RULE_LINE_API");
            this.tblPeriod.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPeriod.NamedProperties.Put("ViewName", "PERIOD_ALLOC_RULE_LINE");
            this.tblPeriod.NamedProperties.Put("Warnings", "FALSE");
            this.tblPeriod.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblPeriod_WindowActions);
            this.tblPeriod.Controls.SetChildIndex(this.tblPeriod_colsAllocationDiff, 0);
            this.tblPeriod.Controls.SetChildIndex(this.tblPeriod_colnAmount, 0);
            this.tblPeriod.Controls.SetChildIndex(this.tblPeriod_colnPercentage, 0);
            this.tblPeriod.Controls.SetChildIndex(this.tblPeriod_colsYearPeriodDisp, 0);
            this.tblPeriod.Controls.SetChildIndex(this.tblPeriod_colnAccountingPeriod, 0);
            this.tblPeriod.Controls.SetChildIndex(this.tblPeriod_colnAccountingYear, 0);
            this.tblPeriod.Controls.SetChildIndex(this.tblPeriod_colnAllocLineId, 0);
            this.tblPeriod.Controls.SetChildIndex(this.tblPeriod_colnAllocationId, 0);
            // 
            // tblPeriod_colnAllocationId
            // 
            this.tblPeriod_colnAllocationId.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.tblPeriod_colnAllocationId, "tblPeriod_colnAllocationId");
            this.tblPeriod_colnAllocationId.Name = "tblPeriod_colnAllocationId";
            this.tblPeriod_colnAllocationId.NamedProperties.Put("EnumerateMethod", "");
            this.tblPeriod_colnAllocationId.NamedProperties.Put("FieldFlags", "67");
            this.tblPeriod_colnAllocationId.NamedProperties.Put("LovReference", "");
            this.tblPeriod_colnAllocationId.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPeriod_colnAllocationId.NamedProperties.Put("SqlColumn", "ALLOCATION_ID");
            this.tblPeriod_colnAllocationId.NamedProperties.Put("ValidateMethod", "");
            this.tblPeriod_colnAllocationId.Position = 3;
            // 
            // tblPeriod_colnAllocLineId
            // 
            this.tblPeriod_colnAllocLineId.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.tblPeriod_colnAllocLineId, "tblPeriod_colnAllocLineId");
            this.tblPeriod_colnAllocLineId.Name = "tblPeriod_colnAllocLineId";
            this.tblPeriod_colnAllocLineId.NamedProperties.Put("EnumerateMethod", "");
            this.tblPeriod_colnAllocLineId.NamedProperties.Put("FieldFlags", "130");
            this.tblPeriod_colnAllocLineId.NamedProperties.Put("LovReference", "");
            this.tblPeriod_colnAllocLineId.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPeriod_colnAllocLineId.NamedProperties.Put("SqlColumn", "ALLOC_LINE_ID");
            this.tblPeriod_colnAllocLineId.NamedProperties.Put("ValidateMethod", "");
            this.tblPeriod_colnAllocLineId.Position = 4;
            // 
            // tblPeriod_colnAccountingYear
            // 
            this.tblPeriod_colnAccountingYear.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.tblPeriod_colnAccountingYear, "tblPeriod_colnAccountingYear");
            this.tblPeriod_colnAccountingYear.Name = "tblPeriod_colnAccountingYear";
            this.tblPeriod_colnAccountingYear.NamedProperties.Put("EnumerateMethod", "");
            this.tblPeriod_colnAccountingYear.NamedProperties.Put("FieldFlags", "294");
            this.tblPeriod_colnAccountingYear.NamedProperties.Put("LovReference", "");
            this.tblPeriod_colnAccountingYear.NamedProperties.Put("SqlColumn", "ACCOUNTING_YEAR");
            this.tblPeriod_colnAccountingYear.Position = 5;
            // 
            // tblPeriod_colnAccountingPeriod
            // 
            this.tblPeriod_colnAccountingPeriod.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.tblPeriod_colnAccountingPeriod, "tblPeriod_colnAccountingPeriod");
            this.tblPeriod_colnAccountingPeriod.Name = "tblPeriod_colnAccountingPeriod";
            this.tblPeriod_colnAccountingPeriod.NamedProperties.Put("EnumerateMethod", "");
            this.tblPeriod_colnAccountingPeriod.NamedProperties.Put("FieldFlags", "294");
            this.tblPeriod_colnAccountingPeriod.NamedProperties.Put("LovReference", "");
            this.tblPeriod_colnAccountingPeriod.NamedProperties.Put("SqlColumn", "ACCOUNTING_PERIOD");
            this.tblPeriod_colnAccountingPeriod.Position = 6;
            // 
            // tblPeriod_colsYearPeriodDisp
            // 
            this.tblPeriod_colsYearPeriodDisp.Name = "tblPeriod_colsYearPeriodDisp";
            this.tblPeriod_colsYearPeriodDisp.NamedProperties.Put("EnumerateMethod", "");
            this.tblPeriod_colsYearPeriodDisp.NamedProperties.Put("FieldFlags", "295");
            this.tblPeriod_colsYearPeriodDisp.NamedProperties.Put("LovReference", "");
            this.tblPeriod_colsYearPeriodDisp.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPeriod_colsYearPeriodDisp.NamedProperties.Put("SqlColumn", "YEAR_PERIOD_DISP");
            this.tblPeriod_colsYearPeriodDisp.NamedProperties.Put("ValidateMethod", "");
            this.tblPeriod_colsYearPeriodDisp.Position = 7;
            resources.ApplyResources(this.tblPeriod_colsYearPeriodDisp, "tblPeriod_colsYearPeriodDisp");
            // 
            // tblPeriod_colnPercentage
            // 
            this.tblPeriod_colnPercentage.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblPeriod_colnPercentage.MaxLength = 6;
            this.tblPeriod_colnPercentage.Name = "tblPeriod_colnPercentage";
            this.tblPeriod_colnPercentage.NamedProperties.Put("EnumerateMethod", "");
            this.tblPeriod_colnPercentage.NamedProperties.Put("FieldFlags", "294");
            this.tblPeriod_colnPercentage.NamedProperties.Put("Format", "20");
            this.tblPeriod_colnPercentage.NamedProperties.Put("LovReference", "");
            this.tblPeriod_colnPercentage.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPeriod_colnPercentage.NamedProperties.Put("SqlColumn", "PERCENTAGE");
            this.tblPeriod_colnPercentage.NamedProperties.Put("ValidateMethod", "");
            this.tblPeriod_colnPercentage.Position = 8;
            this.tblPeriod_colnPercentage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblPeriod_colnPercentage, "tblPeriod_colnPercentage");
            this.tblPeriod_colnPercentage.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblPeriod_colnPercentage_WindowActions);
            // 
            // tblPeriod_colnAmount
            // 
            this.tblPeriod_colnAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblPeriod_colnAmount.MaxLength = 15;
            this.tblPeriod_colnAmount.Name = "tblPeriod_colnAmount";
            this.tblPeriod_colnAmount.NamedProperties.Put("EnumerateMethod", "");
            this.tblPeriod_colnAmount.NamedProperties.Put("FieldFlags", "294");
            this.tblPeriod_colnAmount.NamedProperties.Put("Format", "20");
            this.tblPeriod_colnAmount.NamedProperties.Put("LovReference", "");
            this.tblPeriod_colnAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPeriod_colnAmount.NamedProperties.Put("SqlColumn", "AMOUNT");
            this.tblPeriod_colnAmount.NamedProperties.Put("ValidateMethod", "");
            this.tblPeriod_colnAmount.Position = 9;
            this.tblPeriod_colnAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblPeriod_colnAmount, "tblPeriod_colnAmount");
            this.tblPeriod_colnAmount.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblPeriod_colnAmount_WindowActions);
            // 
            // tblPeriod_colsAllocationDiff
            // 
            this.tblPeriod_colsAllocationDiff.Name = "tblPeriod_colsAllocationDiff";
            this.tblPeriod_colsAllocationDiff.NamedProperties.Put("EnumerateMethod", "");
            this.tblPeriod_colsAllocationDiff.NamedProperties.Put("LovReference", "");
            this.tblPeriod_colsAllocationDiff.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPeriod_colsAllocationDiff.NamedProperties.Put("SqlColumn", "ALLOCATION_DIFF");
            this.tblPeriod_colsAllocationDiff.NamedProperties.Put("ValidateMethod", "");
            this.tblPeriod_colsAllocationDiff.Position = 10;
            resources.ApplyResources(this.tblPeriod_colsAllocationDiff, "tblPeriod_colsAllocationDiff");
            // 
            // dlgPeriodAllocationRule
            // 
            resources.ApplyResources(this, "$this");
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Name = "dlgPeriodAllocationRule";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "ALLOCATION_ID=:i_hWndFrame.dlgPeriodAllocationRule.nAllocationId");
            this.NamedProperties.Put("LogicalUnit", "PeriodAllocationRule");
            this.NamedProperties.Put("PackageName", "PERIOD_ALLOCATION_RULE_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "193");
            this.NamedProperties.Put("ViewName", "PERIOD_ALLOCATION_RULE");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.ShowIcon = false;
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dlgPeriodAllocationRule_WindowActions);
            this.ClientArea.ResumeLayout(false);
            this.ClientArea.PerformLayout();
            this.tblPeriod.ResumeLayout(false);
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

        public cChildTableFinBase tblPeriod;
        protected cColumn tblPeriod_colnAllocationId;
        protected cColumn tblPeriod_colnAllocLineId;
        protected cColumn tblPeriod_colnAccountingYear;
        protected cColumn tblPeriod_colnAccountingPeriod;
        protected cColumn tblPeriod_colsYearPeriodDisp;
        protected cColumn tblPeriod_colnPercentage;
        protected cColumn tblPeriod_colnAmount;
        protected cCheckBoxColumn tblPeriod_colsAllocationDiff;
		
	}
}
