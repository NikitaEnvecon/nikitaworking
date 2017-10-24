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
	
	public partial class dlgPeriodAllocation
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cPushButton pbOk;
		public cPushButton pbCancel;
		public cPushButton pbNew;
		public cPushButton pbRemove;
		public cPushButton pbSave;
		public cPushButton pbList;
		public cDataField dfsCompany;
		protected SalGroupBox gbOriginal_Transaction_Information;
		protected cBackgroundText labelcmbRowNo;
		public cRecSelExtComboBox cmbRowNo;
		public cDataField dfnRowNo;
		protected cBackgroundText labeldfsVoucherType;
		public cDataField dfsVoucherType;
		protected cBackgroundText labeldfnVoucherNo;
		public cDataField dfnVoucherNo;
		protected cBackgroundText labeldfnPeriod;
		// Bug 74894, Begin, Set as not Editable
		public cDataField dfnPeriod;
		// Bug 74894, End
		protected cBackgroundText labeldfsCurrencyCode;
		public cDataField dfsCurrencyCode;
		protected cBackgroundText labeldfnAmount;
		public cDataField dfnAmount;
		protected SalGroupBox gbFrom_;
		protected cBackgroundText labeldfnFromYear;
		public cDataField dfnFromYear;
		protected cBackgroundText labeldfnFromPeriod;
		public cDataField dfnFromPeriod;
		protected SalGroupBox gbUntil_;
		protected cBackgroundText labeldfnUntilYear;
		public cDataField dfnUntilYear;
		protected cBackgroundText labeldfnUntilPeriod;
		public cDataField dfnUntilPeriod;
		// Bug 69803 Start (Period columns etc changed position and length)
		protected cBackgroundText labeldfsCreatorDesc;
		public cDataField dfsCreatorDesc;
		// Bug 69803 End
		public cCheckBox cbDivide;
		protected cBackgroundText labeldfsUserGroup;
		public cDataField dfsUserGroup;
		protected cBackgroundText labeldfsAllocVouType;
		public cDataField dfsAllocVouType;
		// Hidden Fields
		// Message Actions
		public cDataField dfnAccountingYear;
		public cDataField dfnDecimalsInAmount;
		public cDataField dfsInvAccRowId;
		// Message Actions
        // Bug 73298 Begin - Changed the derived base class.
		// Bug 73298 End.
		public cDataField dfsPartyType;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgPeriodAllocation));
            this.pbOk = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbCancel = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbNew = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbRemove = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbSave = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbList = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.dfsCompany = new Ifs.Fnd.ApplicationForms.cDataField();
            this.gbOriginal_Transaction_Information = new PPJ.Runtime.Windows.SalGroupBox();
            this.labelcmbRowNo = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbRowNo = new Ifs.Fnd.ApplicationForms.cRecSelExtComboBox();
            this.dfnRowNo = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsVoucherType = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsVoucherType = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfnVoucherNo = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfnVoucherNo = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfnPeriod = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfnPeriod = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsCurrencyCode = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsCurrencyCode = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfnAmount = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfnAmount = new Ifs.Fnd.ApplicationForms.cDataField();
            this.gbFrom_ = new PPJ.Runtime.Windows.SalGroupBox();
            this.labeldfnFromYear = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfnFromYear = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfnFromPeriod = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfnFromPeriod = new Ifs.Fnd.ApplicationForms.cDataField();
            this.gbUntil_ = new PPJ.Runtime.Windows.SalGroupBox();
            this.labeldfnUntilYear = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfnUntilYear = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfnUntilPeriod = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfnUntilPeriod = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsCreatorDesc = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsCreatorDesc = new Ifs.Fnd.ApplicationForms.cDataField();
            this.cbDivide = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.labeldfsUserGroup = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsUserGroup = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsAllocVouType = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsAllocVouType = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfnAccountingYear = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfnDecimalsInAmount = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsInvAccRowId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsPartyType = new Ifs.Fnd.ApplicationForms.cDataField();
            this.tblPeriod = new Ifs.Application.Accrul.cChildTableFinBase();
            this.tblPeriod_colsCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPeriod_colsVoucherType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPeriod_colnVoucherNo = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPeriod_colnAccountingYear = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPeriod_colnRowNo = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPeriod_colnAllocPeriod = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPeriod_colCompletePeriod = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPeriod_colnAllocPercent = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPeriod_colnAllocAmount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPeriod_colnAllocYear = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPeriod_colnUntilYear = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPeriod_colnUntilPeriod = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPeriod_colnUserGroup = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPeriod_colnAllocVouType = new Ifs.Fnd.ApplicationForms.cColumn();
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
            this.ClientArea.Controls.Add(this.dfsPartyType);
            this.ClientArea.Controls.Add(this.tblPeriod);
            this.ClientArea.Controls.Add(this.dfsInvAccRowId);
            this.ClientArea.Controls.Add(this.dfnDecimalsInAmount);
            this.ClientArea.Controls.Add(this.dfnAccountingYear);
            this.ClientArea.Controls.Add(this.dfsAllocVouType);
            this.ClientArea.Controls.Add(this.dfsUserGroup);
            this.ClientArea.Controls.Add(this.cbDivide);
            this.ClientArea.Controls.Add(this.dfsCreatorDesc);
            this.ClientArea.Controls.Add(this.dfnUntilPeriod);
            this.ClientArea.Controls.Add(this.dfnUntilYear);
            this.ClientArea.Controls.Add(this.dfnFromPeriod);
            this.ClientArea.Controls.Add(this.dfnFromYear);
            this.ClientArea.Controls.Add(this.dfnAmount);
            this.ClientArea.Controls.Add(this.dfsCurrencyCode);
            this.ClientArea.Controls.Add(this.dfnPeriod);
            this.ClientArea.Controls.Add(this.dfnVoucherNo);
            this.ClientArea.Controls.Add(this.dfsVoucherType);
            this.ClientArea.Controls.Add(this.dfnRowNo);
            this.ClientArea.Controls.Add(this.cmbRowNo);
            this.ClientArea.Controls.Add(this.dfsCompany);
            this.ClientArea.Controls.Add(this.pbList);
            this.ClientArea.Controls.Add(this.pbSave);
            this.ClientArea.Controls.Add(this.pbRemove);
            this.ClientArea.Controls.Add(this.pbNew);
            this.ClientArea.Controls.Add(this.pbCancel);
            this.ClientArea.Controls.Add(this.pbOk);
            this.ClientArea.Controls.Add(this.labeldfsAllocVouType);
            this.ClientArea.Controls.Add(this.labeldfsUserGroup);
            this.ClientArea.Controls.Add(this.labeldfsCreatorDesc);
            this.ClientArea.Controls.Add(this.labeldfnUntilPeriod);
            this.ClientArea.Controls.Add(this.labeldfnUntilYear);
            this.ClientArea.Controls.Add(this.labeldfnFromPeriod);
            this.ClientArea.Controls.Add(this.labeldfnFromYear);
            this.ClientArea.Controls.Add(this.labeldfnAmount);
            this.ClientArea.Controls.Add(this.labeldfsCurrencyCode);
            this.ClientArea.Controls.Add(this.labeldfnPeriod);
            this.ClientArea.Controls.Add(this.labeldfnVoucherNo);
            this.ClientArea.Controls.Add(this.labeldfsVoucherType);
            this.ClientArea.Controls.Add(this.labelcmbRowNo);
            this.ClientArea.Controls.Add(this.gbUntil_);
            this.ClientArea.Controls.Add(this.gbFrom_);
            this.ClientArea.Controls.Add(this.gbOriginal_Transaction_Information);
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
            // pbList
            // 
            resources.ApplyResources(this.pbList, "pbList");
            this.pbList.Name = "pbList";
            this.pbList.NamedProperties.Put("MethodId", "18385");
            this.pbList.NamedProperties.Put("MethodParameter", "List");
            this.pbList.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // dfsCompany
            // 
            this.dfsCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsCompany, "dfsCompany");
            this.dfsCompany.Name = "dfsCompany";
            this.dfsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.dfsCompany.NamedProperties.Put("FieldFlags", "67");
            this.dfsCompany.NamedProperties.Put("LovReference", "");
            this.dfsCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.dfsCompany.NamedProperties.Put("ValidateMethod", "");
            // 
            // gbOriginal_Transaction_Information
            // 
            resources.ApplyResources(this.gbOriginal_Transaction_Information, "gbOriginal_Transaction_Information");
            this.gbOriginal_Transaction_Information.Name = "gbOriginal_Transaction_Information";
            this.gbOriginal_Transaction_Information.TabStop = false;
            // 
            // labelcmbRowNo
            // 
            resources.ApplyResources(this.labelcmbRowNo, "labelcmbRowNo");
            this.labelcmbRowNo.Name = "labelcmbRowNo";
            // 
            // cmbRowNo
            // 
            resources.ApplyResources(this.cmbRowNo, "cmbRowNo");
            this.cmbRowNo.Name = "cmbRowNo";
            this.cmbRowNo.NamedProperties.Put("DataType", "3");
            this.cmbRowNo.NamedProperties.Put("EnumerateMethod", "");
            this.cmbRowNo.NamedProperties.Put("FieldFlags", "163");
            this.cmbRowNo.NamedProperties.Put("LovReference", "");
            this.cmbRowNo.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbRowNo.NamedProperties.Put("SqlColumn", "ROW_NO");
            this.cmbRowNo.NamedProperties.Put("ValidateMethod", "");
            this.cmbRowNo.NamedProperties.Put("XDataLength", "Class Default");
            // 
            // dfnRowNo
            // 
            this.dfnRowNo.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfnRowNo, "dfnRowNo");
            this.dfnRowNo.Name = "dfnRowNo";
            this.dfnRowNo.NamedProperties.Put("EnumerateMethod", "");
            this.dfnRowNo.NamedProperties.Put("FieldFlags", "259");
            this.dfnRowNo.NamedProperties.Put("LovReference", "");
            this.dfnRowNo.NamedProperties.Put("ResizeableChildObject", "");
            this.dfnRowNo.NamedProperties.Put("SqlColumn", "");
            this.dfnRowNo.NamedProperties.Put("ValidateMethod", "");
            this.dfnRowNo.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfnRowNo_WindowActions);
            // 
            // labeldfsVoucherType
            // 
            resources.ApplyResources(this.labeldfsVoucherType, "labeldfsVoucherType");
            this.labeldfsVoucherType.Name = "labeldfsVoucherType";
            // 
            // dfsVoucherType
            // 
            this.dfsVoucherType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsVoucherType, "dfsVoucherType");
            this.dfsVoucherType.Name = "dfsVoucherType";
            this.dfsVoucherType.NamedProperties.Put("EnumerateMethod", "");
            this.dfsVoucherType.NamedProperties.Put("FieldFlags", "67");
            this.dfsVoucherType.NamedProperties.Put("LovReference", "");
            this.dfsVoucherType.NamedProperties.Put("ParentName", "cmbRowNo");
            this.dfsVoucherType.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsVoucherType.NamedProperties.Put("SqlColumn", "VOUCHER_TYPE");
            this.dfsVoucherType.NamedProperties.Put("ValidateMethod", "");
            this.dfsVoucherType.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsVoucherType_WindowActions);
            // 
            // labeldfnVoucherNo
            // 
            resources.ApplyResources(this.labeldfnVoucherNo, "labeldfnVoucherNo");
            this.labeldfnVoucherNo.Name = "labeldfnVoucherNo";
            // 
            // dfnVoucherNo
            // 
            this.dfnVoucherNo.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfnVoucherNo, "dfnVoucherNo");
            this.dfnVoucherNo.Name = "dfnVoucherNo";
            this.dfnVoucherNo.NamedProperties.Put("EnumerateMethod", "");
            this.dfnVoucherNo.NamedProperties.Put("FieldFlags", "67");
            this.dfnVoucherNo.NamedProperties.Put("LovReference", "VOUCHER(COMPANY,VOUCHER_TYPE)");
            this.dfnVoucherNo.NamedProperties.Put("ParentName", "cmbRowNo");
            this.dfnVoucherNo.NamedProperties.Put("ResizeableChildObject", "");
            this.dfnVoucherNo.NamedProperties.Put("SqlColumn", "VOUCHER_NO");
            this.dfnVoucherNo.NamedProperties.Put("ValidateMethod", "");
            this.dfnVoucherNo.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfnVoucherNo_WindowActions);
            // 
            // labeldfnPeriod
            // 
            resources.ApplyResources(this.labeldfnPeriod, "labeldfnPeriod");
            this.labeldfnPeriod.Name = "labeldfnPeriod";
            // 
            // dfnPeriod
            // 
            this.dfnPeriod.BackColor = System.Drawing.SystemColors.Control;
            this.dfnPeriod.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.dfnPeriod.EditMask = "9999 99";
            resources.ApplyResources(this.dfnPeriod, "dfnPeriod");
            this.dfnPeriod.Name = "dfnPeriod";
            this.dfnPeriod.NamedProperties.Put("EnumerateMethod", "");
            this.dfnPeriod.NamedProperties.Put("LovReference", "");
            this.dfnPeriod.NamedProperties.Put("ResizeableChildObject", "");
            this.dfnPeriod.NamedProperties.Put("SqlColumn", "");
            this.dfnPeriod.NamedProperties.Put("ValidateMethod", "");
            this.dfnPeriod.ReadOnly = true;
            this.dfnPeriod.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfnPeriod_WindowActions);
            // 
            // labeldfsCurrencyCode
            // 
            resources.ApplyResources(this.labeldfsCurrencyCode, "labeldfsCurrencyCode");
            this.labeldfsCurrencyCode.Name = "labeldfsCurrencyCode";
            // 
            // dfsCurrencyCode
            // 
            this.dfsCurrencyCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsCurrencyCode, "dfsCurrencyCode");
            this.dfsCurrencyCode.Name = "dfsCurrencyCode";
            this.dfsCurrencyCode.NamedProperties.Put("EnumerateMethod", "");
            this.dfsCurrencyCode.NamedProperties.Put("FieldFlags", "290");
            this.dfsCurrencyCode.NamedProperties.Put("LovReference", "CURRENCY_CODE(COMPANY)");
            this.dfsCurrencyCode.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsCurrencyCode.NamedProperties.Put("SqlColumn", "CURRENCY_CODE");
            this.dfsCurrencyCode.NamedProperties.Put("ValidateMethod", "");
            this.dfsCurrencyCode.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsCurrencyCode_WindowActions);
            // 
            // labeldfnAmount
            // 
            resources.ApplyResources(this.labeldfnAmount, "labeldfnAmount");
            this.labeldfnAmount.Name = "labeldfnAmount";
            // 
            // dfnAmount
            // 
            this.dfnAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfnAmount, "dfnAmount");
            this.dfnAmount.Name = "dfnAmount";
            this.dfnAmount.NamedProperties.Put("EnumerateMethod", "");
            this.dfnAmount.NamedProperties.Put("FieldFlags", "290");
            this.dfnAmount.NamedProperties.Put("Format", "20");
            this.dfnAmount.NamedProperties.Put("LovReference", "");
            this.dfnAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.dfnAmount.NamedProperties.Put("SqlColumn", "CURRENCY_AMOUNT");
            this.dfnAmount.NamedProperties.Put("ValidateMethod", "");
            this.dfnAmount.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfnAmount_WindowActions);
            // 
            // gbFrom_
            // 
            resources.ApplyResources(this.gbFrom_, "gbFrom_");
            this.gbFrom_.Name = "gbFrom_";
            this.gbFrom_.TabStop = false;
            // 
            // labeldfnFromYear
            // 
            resources.ApplyResources(this.labeldfnFromYear, "labeldfnFromYear");
            this.labeldfnFromYear.Name = "labeldfnFromYear";
            // 
            // dfnFromYear
            // 
            this.dfnFromYear.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfnFromYear, "dfnFromYear");
            this.dfnFromYear.Name = "dfnFromYear";
            this.dfnFromYear.NamedProperties.Put("EnumerateMethod", "");
            this.dfnFromYear.NamedProperties.Put("FieldFlags", "262");
            this.dfnFromYear.NamedProperties.Put("LovReference", "");
            this.dfnFromYear.NamedProperties.Put("ParentName", "cmbRowNo");
            this.dfnFromYear.NamedProperties.Put("ResizeableChildObject", "");
            this.dfnFromYear.NamedProperties.Put("SqlColumn", "ACCOUNTING_YEAR");
            this.dfnFromYear.NamedProperties.Put("ValidateMethod", "");
            this.dfnFromYear.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfnFromYear_WindowActions);
            // 
            // labeldfnFromPeriod
            // 
            resources.ApplyResources(this.labeldfnFromPeriod, "labeldfnFromPeriod");
            this.labeldfnFromPeriod.Name = "labeldfnFromPeriod";
            // 
            // dfnFromPeriod
            // 
            this.dfnFromPeriod.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfnFromPeriod, "dfnFromPeriod");
            this.dfnFromPeriod.Name = "dfnFromPeriod";
            this.dfnFromPeriod.NamedProperties.Put("EnumerateMethod", "");
            this.dfnFromPeriod.NamedProperties.Put("FieldFlags", "262");
            this.dfnFromPeriod.NamedProperties.Put("LovReference", "");
            this.dfnFromPeriod.NamedProperties.Put("ParentName", "cmbRowNo");
            this.dfnFromPeriod.NamedProperties.Put("ResizeableChildObject", "");
            this.dfnFromPeriod.NamedProperties.Put("SqlColumn", "ACCOUNTING_PERIOD");
            this.dfnFromPeriod.NamedProperties.Put("ValidateMethod", "");
            this.dfnFromPeriod.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfnFromPeriod_WindowActions);
            // 
            // gbUntil_
            // 
            resources.ApplyResources(this.gbUntil_, "gbUntil_");
            this.gbUntil_.Name = "gbUntil_";
            this.gbUntil_.TabStop = false;
            // 
            // labeldfnUntilYear
            // 
            resources.ApplyResources(this.labeldfnUntilYear, "labeldfnUntilYear");
            this.labeldfnUntilYear.Name = "labeldfnUntilYear";
            // 
            // dfnUntilYear
            // 
            this.dfnUntilYear.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfnUntilYear, "dfnUntilYear");
            this.dfnUntilYear.Name = "dfnUntilYear";
            this.dfnUntilYear.NamedProperties.Put("EnumerateMethod", "");
            this.dfnUntilYear.NamedProperties.Put("FieldFlags", "262");
            this.dfnUntilYear.NamedProperties.Put("LovReference", "");
            this.dfnUntilYear.NamedProperties.Put("ResizeableChildObject", "");
            this.dfnUntilYear.NamedProperties.Put("SqlColumn", "");
            this.dfnUntilYear.NamedProperties.Put("ValidateMethod", "");
            this.dfnUntilYear.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfnUntilYear_WindowActions);
            // 
            // labeldfnUntilPeriod
            // 
            resources.ApplyResources(this.labeldfnUntilPeriod, "labeldfnUntilPeriod");
            this.labeldfnUntilPeriod.Name = "labeldfnUntilPeriod";
            // 
            // dfnUntilPeriod
            // 
            this.dfnUntilPeriod.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfnUntilPeriod, "dfnUntilPeriod");
            this.dfnUntilPeriod.Name = "dfnUntilPeriod";
            this.dfnUntilPeriod.NamedProperties.Put("EnumerateMethod", "");
            this.dfnUntilPeriod.NamedProperties.Put("FieldFlags", "262");
            this.dfnUntilPeriod.NamedProperties.Put("LovReference", "");
            this.dfnUntilPeriod.NamedProperties.Put("ResizeableChildObject", "");
            this.dfnUntilPeriod.NamedProperties.Put("SqlColumn", "");
            this.dfnUntilPeriod.NamedProperties.Put("ValidateMethod", "");
            this.dfnUntilPeriod.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfnUntilPeriod_WindowActions);
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
            // cbDivide
            // 
            resources.ApplyResources(this.cbDivide, "cbDivide");
            this.cbDivide.Name = "cbDivide";
            this.cbDivide.NamedProperties.Put("DataType", "5");
            this.cbDivide.NamedProperties.Put("EnumerateMethod", "");
            this.cbDivide.NamedProperties.Put("FieldFlags", "262");
            this.cbDivide.NamedProperties.Put("LovReference", "");
            this.cbDivide.NamedProperties.Put("ResizeableChildObject", "");
            this.cbDivide.NamedProperties.Put("SqlColumn", "");
            this.cbDivide.NamedProperties.Put("ValidateMethod", "");
            this.cbDivide.NamedProperties.Put("XDataLength", "");
            // 
            // labeldfsUserGroup
            // 
            resources.ApplyResources(this.labeldfsUserGroup, "labeldfsUserGroup");
            this.labeldfsUserGroup.Name = "labeldfsUserGroup";
            // 
            // dfsUserGroup
            // 
            this.dfsUserGroup.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsUserGroup, "dfsUserGroup");
            this.dfsUserGroup.Name = "dfsUserGroup";
            this.dfsUserGroup.NamedProperties.Put("EnumerateMethod", "");
            this.dfsUserGroup.NamedProperties.Put("FieldFlags", "263");
            this.dfsUserGroup.NamedProperties.Put("LovReference", "USER_GROUP_MEMBER_FINANCE4(COMPANY, USERID)");
            this.dfsUserGroup.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsUserGroup.NamedProperties.Put("SqlColumn", "");
            this.dfsUserGroup.NamedProperties.Put("ValidateMethod", "");
            this.dfsUserGroup.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsUserGroup_WindowActions);
            // 
            // labeldfsAllocVouType
            // 
            resources.ApplyResources(this.labeldfsAllocVouType, "labeldfsAllocVouType");
            this.labeldfsAllocVouType.Name = "labeldfsAllocVouType";
            // 
            // dfsAllocVouType
            // 
            this.dfsAllocVouType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsAllocVouType, "dfsAllocVouType");
            this.dfsAllocVouType.Name = "dfsAllocVouType";
            this.dfsAllocVouType.NamedProperties.Put("EnumerateMethod", "");
            this.dfsAllocVouType.NamedProperties.Put("FieldFlags", "263");
            this.dfsAllocVouType.NamedProperties.Put("LovReference", "VOUCHER_TYPE_USER_GRP_ALL_GL(COMPANY)");
            this.dfsAllocVouType.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsAllocVouType.NamedProperties.Put("SqlColumn", "");
            this.dfsAllocVouType.NamedProperties.Put("ValidateMethod", "");
            this.dfsAllocVouType.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsAllocVouType_WindowActions);
            // 
            // dfnAccountingYear
            // 
            this.dfnAccountingYear.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfnAccountingYear, "dfnAccountingYear");
            this.dfnAccountingYear.Name = "dfnAccountingYear";
            this.dfnAccountingYear.NamedProperties.Put("EnumerateMethod", "");
            this.dfnAccountingYear.NamedProperties.Put("FieldFlags", "67");
            this.dfnAccountingYear.NamedProperties.Put("LovReference", "");
            this.dfnAccountingYear.NamedProperties.Put("ResizeableChildObject", "");
            this.dfnAccountingYear.NamedProperties.Put("SqlColumn", "ACCOUNTING_YEAR");
            this.dfnAccountingYear.NamedProperties.Put("ValidateMethod", "");
            // 
            // dfnDecimalsInAmount
            // 
            this.dfnDecimalsInAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfnDecimalsInAmount, "dfnDecimalsInAmount");
            this.dfnDecimalsInAmount.Name = "dfnDecimalsInAmount";
            this.dfnDecimalsInAmount.NamedProperties.Put("EnumerateMethod", "");
            this.dfnDecimalsInAmount.NamedProperties.Put("FieldFlags", "288");
            this.dfnDecimalsInAmount.NamedProperties.Put("LovReference", "");
            this.dfnDecimalsInAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.dfnDecimalsInAmount.NamedProperties.Put("SqlColumn", "DECIMALS_IN_AMOUNT");
            this.dfnDecimalsInAmount.NamedProperties.Put("ValidateMethod", "");
            // 
            // dfsInvAccRowId
            // 
            resources.ApplyResources(this.dfsInvAccRowId, "dfsInvAccRowId");
            this.dfsInvAccRowId.Name = "dfsInvAccRowId";
            this.dfsInvAccRowId.NamedProperties.Put("EnumerateMethod", "");
            this.dfsInvAccRowId.NamedProperties.Put("FieldFlags", "294");
            this.dfsInvAccRowId.NamedProperties.Put("LovReference", "");
            this.dfsInvAccRowId.NamedProperties.Put("SqlColumn", "INV_ACC_ROW_ID");
            // 
            // dfsPartyType
            // 
            resources.ApplyResources(this.dfsPartyType, "dfsPartyType");
            this.dfsPartyType.Name = "dfsPartyType";
            this.dfsPartyType.NamedProperties.Put("EnumerateMethod", "");
            this.dfsPartyType.NamedProperties.Put("FieldFlags", "294");
            this.dfsPartyType.NamedProperties.Put("LovReference", "");
            this.dfsPartyType.NamedProperties.Put("SqlColumn", "PARTY_TYPE");
            // 
            // tblPeriod
            // 
            this.tblPeriod.Controls.Add(this.tblPeriod_colsCompany);
            this.tblPeriod.Controls.Add(this.tblPeriod_colsVoucherType);
            this.tblPeriod.Controls.Add(this.tblPeriod_colnVoucherNo);
            this.tblPeriod.Controls.Add(this.tblPeriod_colnAccountingYear);
            this.tblPeriod.Controls.Add(this.tblPeriod_colnRowNo);
            this.tblPeriod.Controls.Add(this.tblPeriod_colnAllocPeriod);
            this.tblPeriod.Controls.Add(this.tblPeriod_colCompletePeriod);
            this.tblPeriod.Controls.Add(this.tblPeriod_colnAllocPercent);
            this.tblPeriod.Controls.Add(this.tblPeriod_colnAllocAmount);
            this.tblPeriod.Controls.Add(this.tblPeriod_colnAllocYear);
            this.tblPeriod.Controls.Add(this.tblPeriod_colnUntilYear);
            this.tblPeriod.Controls.Add(this.tblPeriod_colnUntilPeriod);
            this.tblPeriod.Controls.Add(this.tblPeriod_colnUserGroup);
            this.tblPeriod.Controls.Add(this.tblPeriod_colnAllocVouType);
            resources.ApplyResources(this.tblPeriod, "tblPeriod");
            this.tblPeriod.Name = "tblPeriod";
            this.tblPeriod.NamedProperties.Put("DefaultOrderBy", "ALLOC_YEAR, ALLOC_PERIOD");
            this.tblPeriod.NamedProperties.Put("DefaultWhere", "");
            this.tblPeriod.NamedProperties.Put("LogicalUnit", "PeriodAllocation");
            this.tblPeriod.NamedProperties.Put("PackageName", "PERIOD_ALLOCATION_API");
            this.tblPeriod.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPeriod.NamedProperties.Put("ViewName", "PERIOD_ALLOCATION");
            this.tblPeriod.NamedProperties.Put("Warnings", "FALSE");
            this.tblPeriod.DataRecordExecuteNewEvent += new Ifs.Fnd.ApplicationForms.cDataSource.DataRecordExecuteNewEventHandler(this.tblPeriod_DataRecordExecuteNewEvent);
            this.tblPeriod.DataSourcePopulateItEvent += new Ifs.Fnd.ApplicationForms.cDataSource.DataSourcePopulateItEventHandler(this.tblPeriod_DataSourcePopulateItEvent);
            this.tblPeriod.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblPeriod_WindowActions);
            this.tblPeriod.Controls.SetChildIndex(this.tblPeriod_colnAllocVouType, 0);
            this.tblPeriod.Controls.SetChildIndex(this.tblPeriod_colnUserGroup, 0);
            this.tblPeriod.Controls.SetChildIndex(this.tblPeriod_colnUntilPeriod, 0);
            this.tblPeriod.Controls.SetChildIndex(this.tblPeriod_colnUntilYear, 0);
            this.tblPeriod.Controls.SetChildIndex(this.tblPeriod_colnAllocYear, 0);
            this.tblPeriod.Controls.SetChildIndex(this.tblPeriod_colnAllocAmount, 0);
            this.tblPeriod.Controls.SetChildIndex(this.tblPeriod_colnAllocPercent, 0);
            this.tblPeriod.Controls.SetChildIndex(this.tblPeriod_colCompletePeriod, 0);
            this.tblPeriod.Controls.SetChildIndex(this.tblPeriod_colnAllocPeriod, 0);
            this.tblPeriod.Controls.SetChildIndex(this.tblPeriod_colnRowNo, 0);
            this.tblPeriod.Controls.SetChildIndex(this.tblPeriod_colnAccountingYear, 0);
            this.tblPeriod.Controls.SetChildIndex(this.tblPeriod_colnVoucherNo, 0);
            this.tblPeriod.Controls.SetChildIndex(this.tblPeriod_colsVoucherType, 0);
            this.tblPeriod.Controls.SetChildIndex(this.tblPeriod_colsCompany, 0);
            // 
            // tblPeriod_colsCompany
            // 
            this.tblPeriod_colsCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblPeriod_colsCompany, "tblPeriod_colsCompany");
            this.tblPeriod_colsCompany.MaxLength = 20;
            this.tblPeriod_colsCompany.Name = "tblPeriod_colsCompany";
            this.tblPeriod_colsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.tblPeriod_colsCompany.NamedProperties.Put("FieldFlags", "67");
            this.tblPeriod_colsCompany.NamedProperties.Put("LovReference", "");
            this.tblPeriod_colsCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPeriod_colsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.tblPeriod_colsCompany.NamedProperties.Put("ValidateMethod", "");
            this.tblPeriod_colsCompany.Position = 3;
            // 
            // tblPeriod_colsVoucherType
            // 
            this.tblPeriod_colsVoucherType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblPeriod_colsVoucherType, "tblPeriod_colsVoucherType");
            this.tblPeriod_colsVoucherType.MaxLength = 3;
            this.tblPeriod_colsVoucherType.Name = "tblPeriod_colsVoucherType";
            this.tblPeriod_colsVoucherType.NamedProperties.Put("EnumerateMethod", "");
            this.tblPeriod_colsVoucherType.NamedProperties.Put("FieldFlags", "67");
            this.tblPeriod_colsVoucherType.NamedProperties.Put("LovReference", "");
            this.tblPeriod_colsVoucherType.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPeriod_colsVoucherType.NamedProperties.Put("SqlColumn", "VOUCHER_TYPE");
            this.tblPeriod_colsVoucherType.NamedProperties.Put("ValidateMethod", "");
            this.tblPeriod_colsVoucherType.Position = 4;
            // 
            // tblPeriod_colnVoucherNo
            // 
            this.tblPeriod_colnVoucherNo.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.tblPeriod_colnVoucherNo, "tblPeriod_colnVoucherNo");
            this.tblPeriod_colnVoucherNo.MaxLength = 10;
            this.tblPeriod_colnVoucherNo.Name = "tblPeriod_colnVoucherNo";
            this.tblPeriod_colnVoucherNo.NamedProperties.Put("EnumerateMethod", "");
            this.tblPeriod_colnVoucherNo.NamedProperties.Put("FieldFlags", "67");
            this.tblPeriod_colnVoucherNo.NamedProperties.Put("LovReference", "");
            this.tblPeriod_colnVoucherNo.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPeriod_colnVoucherNo.NamedProperties.Put("SqlColumn", "VOUCHER_NO");
            this.tblPeriod_colnVoucherNo.NamedProperties.Put("ValidateMethod", "");
            this.tblPeriod_colnVoucherNo.Position = 5;
            // 
            // tblPeriod_colnAccountingYear
            // 
            this.tblPeriod_colnAccountingYear.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.tblPeriod_colnAccountingYear, "tblPeriod_colnAccountingYear");
            this.tblPeriod_colnAccountingYear.MaxLength = 4;
            this.tblPeriod_colnAccountingYear.Name = "tblPeriod_colnAccountingYear";
            this.tblPeriod_colnAccountingYear.NamedProperties.Put("EnumerateMethod", "");
            this.tblPeriod_colnAccountingYear.NamedProperties.Put("FieldFlags", "67");
            this.tblPeriod_colnAccountingYear.NamedProperties.Put("LovReference", "");
            this.tblPeriod_colnAccountingYear.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPeriod_colnAccountingYear.NamedProperties.Put("SqlColumn", "ACCOUNTING_YEAR");
            this.tblPeriod_colnAccountingYear.NamedProperties.Put("ValidateMethod", "");
            this.tblPeriod_colnAccountingYear.Position = 6;
            // 
            // tblPeriod_colnRowNo
            // 
            this.tblPeriod_colnRowNo.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.tblPeriod_colnRowNo, "tblPeriod_colnRowNo");
            this.tblPeriod_colnRowNo.Name = "tblPeriod_colnRowNo";
            this.tblPeriod_colnRowNo.NamedProperties.Put("EnumerateMethod", "");
            this.tblPeriod_colnRowNo.NamedProperties.Put("FieldFlags", "67");
            this.tblPeriod_colnRowNo.NamedProperties.Put("LovReference", "");
            this.tblPeriod_colnRowNo.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPeriod_colnRowNo.NamedProperties.Put("SqlColumn", "ROW_NO");
            this.tblPeriod_colnRowNo.NamedProperties.Put("ValidateMethod", "");
            this.tblPeriod_colnRowNo.Position = 7;
            // 
            // tblPeriod_colnAllocPeriod
            // 
            this.tblPeriod_colnAllocPeriod.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.tblPeriod_colnAllocPeriod, "tblPeriod_colnAllocPeriod");
            this.tblPeriod_colnAllocPeriod.MaxLength = 2;
            this.tblPeriod_colnAllocPeriod.Name = "tblPeriod_colnAllocPeriod";
            this.tblPeriod_colnAllocPeriod.NamedProperties.Put("EnumerateMethod", "");
            this.tblPeriod_colnAllocPeriod.NamedProperties.Put("FieldFlags", "163");
            this.tblPeriod_colnAllocPeriod.NamedProperties.Put("LovReference", "");
            this.tblPeriod_colnAllocPeriod.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPeriod_colnAllocPeriod.NamedProperties.Put("SqlColumn", "ALLOC_PERIOD");
            this.tblPeriod_colnAllocPeriod.NamedProperties.Put("ValidateMethod", "");
            this.tblPeriod_colnAllocPeriod.Position = 8;
            this.tblPeriod_colnAllocPeriod.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblPeriod_colnAllocPeriod_WindowActions);
            // 
            // tblPeriod_colCompletePeriod
            // 
            this.tblPeriod_colCompletePeriod.EditMask = "9999 99";
            this.tblPeriod_colCompletePeriod.MaxLength = 7;
            this.tblPeriod_colCompletePeriod.Name = "tblPeriod_colCompletePeriod";
            this.tblPeriod_colCompletePeriod.NamedProperties.Put("EnumerateMethod", "");
            this.tblPeriod_colCompletePeriod.NamedProperties.Put("LovReference", "");
            this.tblPeriod_colCompletePeriod.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPeriod_colCompletePeriod.NamedProperties.Put("SqlColumn", "");
            this.tblPeriod_colCompletePeriod.NamedProperties.Put("ValidateMethod", "");
            this.tblPeriod_colCompletePeriod.Position = 9;
            resources.ApplyResources(this.tblPeriod_colCompletePeriod, "tblPeriod_colCompletePeriod");
            this.tblPeriod_colCompletePeriod.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblPeriod_colCompletePeriod_WindowActions);
            // 
            // tblPeriod_colnAllocPercent
            // 
            this.tblPeriod_colnAllocPercent.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblPeriod_colnAllocPercent.Format = "P";
            this.tblPeriod_colnAllocPercent.MaxLength = 6;
            this.tblPeriod_colnAllocPercent.Name = "tblPeriod_colnAllocPercent";
            this.tblPeriod_colnAllocPercent.NamedProperties.Put("EnumerateMethod", "");
            this.tblPeriod_colnAllocPercent.NamedProperties.Put("FieldFlags", "294");
            this.tblPeriod_colnAllocPercent.NamedProperties.Put("LovReference", "");
            this.tblPeriod_colnAllocPercent.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPeriod_colnAllocPercent.NamedProperties.Put("SqlColumn", "ALLOC_PERCENT");
            this.tblPeriod_colnAllocPercent.NamedProperties.Put("ValidateMethod", "");
            this.tblPeriod_colnAllocPercent.Position = 10;
            resources.ApplyResources(this.tblPeriod_colnAllocPercent, "tblPeriod_colnAllocPercent");
            this.tblPeriod_colnAllocPercent.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblPeriod_colnAllocPercent_WindowActions);
            // 
            // tblPeriod_colnAllocAmount
            // 
            this.tblPeriod_colnAllocAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblPeriod_colnAllocAmount.MaxLength = 15;
            this.tblPeriod_colnAllocAmount.Name = "tblPeriod_colnAllocAmount";
            this.tblPeriod_colnAllocAmount.NamedProperties.Put("EnumerateMethod", "");
            this.tblPeriod_colnAllocAmount.NamedProperties.Put("FieldFlags", "294");
            this.tblPeriod_colnAllocAmount.NamedProperties.Put("Format", "20");
            this.tblPeriod_colnAllocAmount.NamedProperties.Put("LovReference", "");
            this.tblPeriod_colnAllocAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPeriod_colnAllocAmount.NamedProperties.Put("SqlColumn", "ALLOC_AMOUNT");
            this.tblPeriod_colnAllocAmount.NamedProperties.Put("ValidateMethod", "");
            this.tblPeriod_colnAllocAmount.Position = 11;
            this.tblPeriod_colnAllocAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblPeriod_colnAllocAmount, "tblPeriod_colnAllocAmount");
            this.tblPeriod_colnAllocAmount.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblPeriod_colnAllocAmount_WindowActions);
            // 
            // tblPeriod_colnAllocYear
            // 
            this.tblPeriod_colnAllocYear.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.tblPeriod_colnAllocYear, "tblPeriod_colnAllocYear");
            this.tblPeriod_colnAllocYear.MaxLength = 4;
            this.tblPeriod_colnAllocYear.Name = "tblPeriod_colnAllocYear";
            this.tblPeriod_colnAllocYear.NamedProperties.Put("EnumerateMethod", "");
            this.tblPeriod_colnAllocYear.NamedProperties.Put("FieldFlags", "167");
            this.tblPeriod_colnAllocYear.NamedProperties.Put("LovReference", "");
            this.tblPeriod_colnAllocYear.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPeriod_colnAllocYear.NamedProperties.Put("SqlColumn", "ALLOC_YEAR");
            this.tblPeriod_colnAllocYear.NamedProperties.Put("ValidateMethod", "");
            this.tblPeriod_colnAllocYear.Position = 12;
            // 
            // tblPeriod_colnUntilYear
            // 
            this.tblPeriod_colnUntilYear.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.tblPeriod_colnUntilYear, "tblPeriod_colnUntilYear");
            this.tblPeriod_colnUntilYear.MaxLength = 4;
            this.tblPeriod_colnUntilYear.Name = "tblPeriod_colnUntilYear";
            this.tblPeriod_colnUntilYear.NamedProperties.Put("EnumerateMethod", "");
            this.tblPeriod_colnUntilYear.NamedProperties.Put("FieldFlags", "295");
            this.tblPeriod_colnUntilYear.NamedProperties.Put("LovReference", "");
            this.tblPeriod_colnUntilYear.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPeriod_colnUntilYear.NamedProperties.Put("SqlColumn", "UNTIL_YEAR");
            this.tblPeriod_colnUntilYear.NamedProperties.Put("ValidateMethod", "");
            this.tblPeriod_colnUntilYear.Position = 13;
            // 
            // tblPeriod_colnUntilPeriod
            // 
            this.tblPeriod_colnUntilPeriod.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.tblPeriod_colnUntilPeriod, "tblPeriod_colnUntilPeriod");
            this.tblPeriod_colnUntilPeriod.MaxLength = 2;
            this.tblPeriod_colnUntilPeriod.Name = "tblPeriod_colnUntilPeriod";
            this.tblPeriod_colnUntilPeriod.NamedProperties.Put("EnumerateMethod", "");
            this.tblPeriod_colnUntilPeriod.NamedProperties.Put("FieldFlags", "295");
            this.tblPeriod_colnUntilPeriod.NamedProperties.Put("LovReference", "");
            this.tblPeriod_colnUntilPeriod.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPeriod_colnUntilPeriod.NamedProperties.Put("SqlColumn", "UNTIL_PERIOD");
            this.tblPeriod_colnUntilPeriod.NamedProperties.Put("ValidateMethod", "");
            this.tblPeriod_colnUntilPeriod.Position = 14;
            // 
            // tblPeriod_colnUserGroup
            // 
            resources.ApplyResources(this.tblPeriod_colnUserGroup, "tblPeriod_colnUserGroup");
            this.tblPeriod_colnUserGroup.MaxLength = 30;
            this.tblPeriod_colnUserGroup.Name = "tblPeriod_colnUserGroup";
            this.tblPeriod_colnUserGroup.NamedProperties.Put("EnumerateMethod", "");
            this.tblPeriod_colnUserGroup.NamedProperties.Put("FieldFlags", "263");
            this.tblPeriod_colnUserGroup.NamedProperties.Put("LovReference", "");
            this.tblPeriod_colnUserGroup.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPeriod_colnUserGroup.NamedProperties.Put("SqlColumn", "USER_GROUP");
            this.tblPeriod_colnUserGroup.NamedProperties.Put("ValidateMethod", "");
            this.tblPeriod_colnUserGroup.Position = 15;
            // 
            // tblPeriod_colnAllocVouType
            // 
            resources.ApplyResources(this.tblPeriod_colnAllocVouType, "tblPeriod_colnAllocVouType");
            this.tblPeriod_colnAllocVouType.MaxLength = 3;
            this.tblPeriod_colnAllocVouType.Name = "tblPeriod_colnAllocVouType";
            this.tblPeriod_colnAllocVouType.NamedProperties.Put("EnumerateMethod", "");
            this.tblPeriod_colnAllocVouType.NamedProperties.Put("FieldFlags", "263");
            this.tblPeriod_colnAllocVouType.NamedProperties.Put("LovReference", "");
            this.tblPeriod_colnAllocVouType.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPeriod_colnAllocVouType.NamedProperties.Put("SqlColumn", "ALLOC_VOU_TYPE");
            this.tblPeriod_colnAllocVouType.NamedProperties.Put("ValidateMethod", "");
            this.tblPeriod_colnAllocVouType.Position = 16;
            // 
            // dlgPeriodAllocation
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "dlgPeriodAllocation";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "COMPANY=:i_hWndFrame.dlgPeriodAllocation.i_sCompany");
            this.NamedProperties.Put("LogicalUnit", "VoucherRow");
            this.NamedProperties.Put("PackageName", "VOUCHER_ROW_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("ViewName", "VOUCHER_ROW");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.ShowIcon = false;
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dlgPeriodAllocation_WindowActions);
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
        protected cColumn tblPeriod_colsCompany;
        protected cColumn tblPeriod_colsVoucherType;
        protected cColumn tblPeriod_colnVoucherNo;
        protected cColumn tblPeriod_colnAccountingYear;
        protected cColumn tblPeriod_colnRowNo;
        protected cColumn tblPeriod_colnAllocPeriod;
        protected cColumn tblPeriod_colCompletePeriod;
        protected cColumn tblPeriod_colnAllocPercent;
        protected cColumn tblPeriod_colnAllocAmount;
        protected cColumn tblPeriod_colnAllocYear;
        protected cColumn tblPeriod_colnUntilYear;
        protected cColumn tblPeriod_colnUntilPeriod;
        protected cColumn tblPeriod_colnUserGroup;
        protected cColumn tblPeriod_colnAllocVouType;
		
	}
}
