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
	
	public partial class frmPostCtrlDetSpec
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		protected cBackgroundText labeldfCompany;
		public cDataField dfCompany;
		protected cBackgroundText labeldfsPostingType;
		public cDataField dfsPostingType;
		public cRecSelExtComboBox ccPostingType;
		protected cBackgroundText labeldfPostingType;
		public cDataField dfPostingType;
		protected cBackgroundText labeldfCodePart;
		public cDataField dfCodePart;
		protected cBackgroundText labeldfPcValidFrom;
		public cDataField dfPcValidFrom;
		protected cBackgroundText labeldfsControlTypeValue;
		public cDataField dfsControlTypeValue;
		protected cBackgroundText labeldfdValidFrom;
		public cDataField dfdValidFrom;
		protected cBackgroundText labeldfsCodeName;
		public cDataField dfsCodeName;
		protected cBackgroundText labeldfControlType;
		public cDataField dfControlType;
		protected cBackgroundText labeldfsControlTypeDesc;
		public cDataField dfsControlTypeDesc;
		protected cBackgroundText labeldfsSpecControlType;
		public cDataField dfsSpecControlType;
		protected cBackgroundText labeldfsSpecControlTypeDesc;
		public cDataField dfsSpecControlTypeDesc;
		protected cBackgroundText labeldfsSpecDefaultValue;
		public cDataField dfsSpecDefaultValue;
		protected cBackgroundText labeldfsSpecDefaultValueNoCt;
		public cDataField dfsSpecDefaultValueNoCt;
		protected cBackgroundText labeldfsSpecModule;
		public cDataField dfsSpecModule;
		public cDataField dfsSpecCtrlTypeCategoryDb;
		// Bug 73298 Begin - Changed the derived base class.
        // Bug 69757, Begin (Increased max rows in memory to 100000)
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPostCtrlDetSpec));
            this.labeldfCompany = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfCompany = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsPostingType = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsPostingType = new Ifs.Fnd.ApplicationForms.cDataField();
            this.ccPostingType = new Ifs.Fnd.ApplicationForms.cRecSelExtComboBox();
            this.labeldfPostingType = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfPostingType = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfCodePart = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfCodePart = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfPcValidFrom = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfPcValidFrom = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsControlTypeValue = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsControlTypeValue = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfdValidFrom = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfdValidFrom = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsCodeName = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsCodeName = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfControlType = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfControlType = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsControlTypeDesc = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsControlTypeDesc = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsSpecControlType = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsSpecControlType = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsSpecControlTypeDesc = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsSpecControlTypeDesc = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsSpecDefaultValue = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsSpecDefaultValue = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsSpecDefaultValueNoCt = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsSpecDefaultValueNoCt = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsSpecModule = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsSpecModule = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsSpecCtrlTypeCategoryDb = new Ifs.Fnd.ApplicationForms.cDataField();
            this.tblPostCtrlDetSpec = new Ifs.Application.Accrul.cChildTableFinBase();
            this.tblPostCtrlDetSpec_colCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPostCtrlDetSpec_colPostingType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPostCtrlDetSpec_colCodePart = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPostCtrlDetSpec_colPcValidFrom = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPostCtrlDetSpec_colsControlTypeValue = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPostCtrlDetSpec_coldValidFrom = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPostCtrlDetSpec_colSpecControlType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPostCtrlDetSpec_colSpecModule = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPostCtrlDetSpec_colSpecControlTypeValue = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPostCtrlDetSpec_colSpecControlTypeValueDesc = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPostCtrlDetSpec_colCodePartValue = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPostCtrlDetSpec_colCodePartValueDesc = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPostCtrlDetSpec_colsNoCodePartValueDb = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.tblPostCtrlDetSpec.SuspendLayout();
            this.SuspendLayout();
            // 
            // labeldfCompany
            // 
            resources.ApplyResources(this.labeldfCompany, "labeldfCompany");
            this.labeldfCompany.Name = "labeldfCompany";
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
            // labeldfsPostingType
            // 
            resources.ApplyResources(this.labeldfsPostingType, "labeldfsPostingType");
            this.labeldfsPostingType.Name = "labeldfsPostingType";
            // 
            // dfsPostingType
            // 
            resources.ApplyResources(this.dfsPostingType, "dfsPostingType");
            this.dfsPostingType.Name = "dfsPostingType";
            this.dfsPostingType.NamedProperties.Put("EnumerateMethod", "");
            this.dfsPostingType.NamedProperties.Put("LovReference", "");
            this.dfsPostingType.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsPostingType.NamedProperties.Put("SqlColumn", "POSTING_TYPE");
            this.dfsPostingType.NamedProperties.Put("ValidateMethod", "");
            // 
            // ccPostingType
            // 
            resources.ApplyResources(this.ccPostingType, "ccPostingType");
            this.ccPostingType.Name = "ccPostingType";
            this.ccPostingType.NamedProperties.Put("EnumerateMethod", "");
            this.ccPostingType.NamedProperties.Put("FieldFlags", "288");
            this.ccPostingType.NamedProperties.Put("LovReference", "POSTING_CTRL_POSTING_TYPE");
            this.ccPostingType.NamedProperties.Put("ResizeableChildObject", "");
            this.ccPostingType.NamedProperties.Put("SqlColumn", "POSTING_TYPE");
            this.ccPostingType.NamedProperties.Put("ValidateMethod", "");
            this.ccPostingType.NamedProperties.Put("XDataLength", "");
            // 
            // labeldfPostingType
            // 
            resources.ApplyResources(this.labeldfPostingType, "labeldfPostingType");
            this.labeldfPostingType.Name = "labeldfPostingType";
            // 
            // dfPostingType
            // 
            resources.ApplyResources(this.dfPostingType, "dfPostingType");
            this.dfPostingType.Name = "dfPostingType";
            this.dfPostingType.NamedProperties.Put("ResizeableChildObject", "");
            this.dfPostingType.NamedProperties.Put("SqlColumn", "POSTING_TYPE");
            // 
            // labeldfCodePart
            // 
            resources.ApplyResources(this.labeldfCodePart, "labeldfCodePart");
            this.labeldfCodePart.Name = "labeldfCodePart";
            // 
            // dfCodePart
            // 
            resources.ApplyResources(this.dfCodePart, "dfCodePart");
            this.dfCodePart.Name = "dfCodePart";
            this.dfCodePart.NamedProperties.Put("EnumerateMethod", "");
            this.dfCodePart.NamedProperties.Put("LovReference", "");
            this.dfCodePart.NamedProperties.Put("ParentName", "ccPostingType");
            this.dfCodePart.NamedProperties.Put("ResizeableChildObject", "");
            this.dfCodePart.NamedProperties.Put("SqlColumn", "CODE_PART");
            this.dfCodePart.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfPcValidFrom
            // 
            resources.ApplyResources(this.labeldfPcValidFrom, "labeldfPcValidFrom");
            this.labeldfPcValidFrom.Name = "labeldfPcValidFrom";
            // 
            // dfPcValidFrom
            // 
            this.dfPcValidFrom.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.dfPcValidFrom.Format = "d";
            resources.ApplyResources(this.dfPcValidFrom, "dfPcValidFrom");
            this.dfPcValidFrom.Name = "dfPcValidFrom";
            this.dfPcValidFrom.NamedProperties.Put("EnumerateMethod", "");
            this.dfPcValidFrom.NamedProperties.Put("LovReference", "");
            this.dfPcValidFrom.NamedProperties.Put("ResizeableChildObject", "");
            this.dfPcValidFrom.NamedProperties.Put("SqlColumn", "PC_VALID_FROM");
            this.dfPcValidFrom.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsControlTypeValue
            // 
            resources.ApplyResources(this.labeldfsControlTypeValue, "labeldfsControlTypeValue");
            this.labeldfsControlTypeValue.Name = "labeldfsControlTypeValue";
            // 
            // dfsControlTypeValue
            // 
            this.dfsControlTypeValue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsControlTypeValue, "dfsControlTypeValue");
            this.dfsControlTypeValue.Name = "dfsControlTypeValue";
            this.dfsControlTypeValue.NamedProperties.Put("EnumerateMethod", "");
            this.dfsControlTypeValue.NamedProperties.Put("FieldFlags", "99");
            this.dfsControlTypeValue.NamedProperties.Put("LovReference", "");
            this.dfsControlTypeValue.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsControlTypeValue.NamedProperties.Put("SqlColumn", "CONTROL_TYPE_VALUE");
            this.dfsControlTypeValue.NamedProperties.Put("ValidateMethod", "");
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
            this.dfdValidFrom.NamedProperties.Put("FieldFlags", "103");
            this.dfdValidFrom.NamedProperties.Put("LovReference", "");
            this.dfdValidFrom.NamedProperties.Put("ResizeableChildObject", "");
            this.dfdValidFrom.NamedProperties.Put("SqlColumn", "VALID_FROM");
            this.dfdValidFrom.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsCodeName
            // 
            resources.ApplyResources(this.labeldfsCodeName, "labeldfsCodeName");
            this.labeldfsCodeName.Name = "labeldfsCodeName";
            // 
            // dfsCodeName
            // 
            resources.ApplyResources(this.dfsCodeName, "dfsCodeName");
            this.dfsCodeName.Name = "dfsCodeName";
            this.dfsCodeName.NamedProperties.Put("EnumerateMethod", "");
            this.dfsCodeName.NamedProperties.Put("FieldFlags", "291");
            this.dfsCodeName.NamedProperties.Put("LovReference", "ACCOUNTING_CODE_PARTS_USED2(COMPANY)");
            this.dfsCodeName.NamedProperties.Put("ParentName", "ccPostingType");
            this.dfsCodeName.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsCodeName.NamedProperties.Put("SqlColumn", "CODE_NAME");
            this.dfsCodeName.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfControlType
            // 
            resources.ApplyResources(this.labeldfControlType, "labeldfControlType");
            this.labeldfControlType.Name = "labeldfControlType";
            // 
            // dfControlType
            // 
            this.dfControlType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfControlType, "dfControlType");
            this.dfControlType.Name = "dfControlType";
            this.dfControlType.NamedProperties.Put("EnumerateMethod", "");
            this.dfControlType.NamedProperties.Put("FieldFlags", "291");
            this.dfControlType.NamedProperties.Put("LovReference", "");
            this.dfControlType.NamedProperties.Put("ParentName", "ccPostingType");
            this.dfControlType.NamedProperties.Put("ResizeableChildObject", "");
            this.dfControlType.NamedProperties.Put("SqlColumn", "CONTROL_TYPE");
            this.dfControlType.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsControlTypeDesc
            // 
            resources.ApplyResources(this.labeldfsControlTypeDesc, "labeldfsControlTypeDesc");
            this.labeldfsControlTypeDesc.Name = "labeldfsControlTypeDesc";
            // 
            // dfsControlTypeDesc
            // 
            resources.ApplyResources(this.dfsControlTypeDesc, "dfsControlTypeDesc");
            this.dfsControlTypeDesc.Name = "dfsControlTypeDesc";
            this.dfsControlTypeDesc.NamedProperties.Put("EnumerateMethod", "");
            this.dfsControlTypeDesc.NamedProperties.Put("FieldFlags", "288");
            this.dfsControlTypeDesc.NamedProperties.Put("LovReference", "");
            this.dfsControlTypeDesc.NamedProperties.Put("SqlColumn", "CONTROL_TYPE_DESC");
            // 
            // labeldfsSpecControlType
            // 
            resources.ApplyResources(this.labeldfsSpecControlType, "labeldfsSpecControlType");
            this.labeldfsSpecControlType.Name = "labeldfsSpecControlType";
            // 
            // dfsSpecControlType
            // 
            this.dfsSpecControlType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsSpecControlType, "dfsSpecControlType");
            this.dfsSpecControlType.Name = "dfsSpecControlType";
            this.dfsSpecControlType.NamedProperties.Put("EnumerateMethod", "");
            this.dfsSpecControlType.NamedProperties.Put("FieldFlags", "294");
            this.dfsSpecControlType.NamedProperties.Put("LovReference", "CTRL_TYPE_ALLOWED_VALUE(POSTING_TYPE, SPEC_CODE_PART)");
            this.dfsSpecControlType.NamedProperties.Put("SqlColumn", "SPEC_CONTROL_TYPE");
            // 
            // labeldfsSpecControlTypeDesc
            // 
            resources.ApplyResources(this.labeldfsSpecControlTypeDesc, "labeldfsSpecControlTypeDesc");
            this.labeldfsSpecControlTypeDesc.Name = "labeldfsSpecControlTypeDesc";
            // 
            // dfsSpecControlTypeDesc
            // 
            resources.ApplyResources(this.dfsSpecControlTypeDesc, "dfsSpecControlTypeDesc");
            this.dfsSpecControlTypeDesc.Name = "dfsSpecControlTypeDesc";
            this.dfsSpecControlTypeDesc.NamedProperties.Put("EnumerateMethod", "");
            this.dfsSpecControlTypeDesc.NamedProperties.Put("FieldFlags", "288");
            this.dfsSpecControlTypeDesc.NamedProperties.Put("LovReference", "");
            this.dfsSpecControlTypeDesc.NamedProperties.Put("SqlColumn", "SPEC_CONTROL_TYPE_DESC");
            // 
            // labeldfsSpecDefaultValue
            // 
            resources.ApplyResources(this.labeldfsSpecDefaultValue, "labeldfsSpecDefaultValue");
            this.labeldfsSpecDefaultValue.Name = "labeldfsSpecDefaultValue";
            // 
            // dfsSpecDefaultValue
            // 
            this.dfsSpecDefaultValue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsSpecDefaultValue, "dfsSpecDefaultValue");
            this.dfsSpecDefaultValue.Name = "dfsSpecDefaultValue";
            this.dfsSpecDefaultValue.NamedProperties.Put("EnumerateMethod", "");
            this.dfsSpecDefaultValue.NamedProperties.Put("FieldFlags", "294");
            this.dfsSpecDefaultValue.NamedProperties.Put("LovReference", "ACCOUNTING_CODEPART_VAL_FINREP(COMPANY,CODE_PART)");
            this.dfsSpecDefaultValue.NamedProperties.Put("SqlColumn", "SPEC_DEFAULT_VALUE");
            // 
            // labeldfsSpecDefaultValueNoCt
            // 
            resources.ApplyResources(this.labeldfsSpecDefaultValueNoCt, "labeldfsSpecDefaultValueNoCt");
            this.labeldfsSpecDefaultValueNoCt.Name = "labeldfsSpecDefaultValueNoCt";
            // 
            // dfsSpecDefaultValueNoCt
            // 
            this.dfsSpecDefaultValueNoCt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsSpecDefaultValueNoCt, "dfsSpecDefaultValueNoCt");
            this.dfsSpecDefaultValueNoCt.Name = "dfsSpecDefaultValueNoCt";
            this.dfsSpecDefaultValueNoCt.NamedProperties.Put("EnumerateMethod", "");
            this.dfsSpecDefaultValueNoCt.NamedProperties.Put("FieldFlags", "294");
            this.dfsSpecDefaultValueNoCt.NamedProperties.Put("LovReference", "ACCOUNTING_CODEPART_VAL_FINREP(COMPANY,CODE_PART)");
            this.dfsSpecDefaultValueNoCt.NamedProperties.Put("SqlColumn", "SPEC_DEFAULT_VALUE_NO_CT");
            // 
            // labeldfsSpecModule
            // 
            resources.ApplyResources(this.labeldfsSpecModule, "labeldfsSpecModule");
            this.labeldfsSpecModule.Name = "labeldfsSpecModule";
            // 
            // dfsSpecModule
            // 
            this.dfsSpecModule.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsSpecModule, "dfsSpecModule");
            this.dfsSpecModule.Name = "dfsSpecModule";
            this.dfsSpecModule.NamedProperties.Put("EnumerateMethod", "");
            this.dfsSpecModule.NamedProperties.Put("FieldFlags", "294");
            this.dfsSpecModule.NamedProperties.Put("LovReference", "");
            this.dfsSpecModule.NamedProperties.Put("SqlColumn", "SPEC_MODULE");
            // 
            // dfsSpecCtrlTypeCategoryDb
            // 
            this.dfsSpecCtrlTypeCategoryDb.Name = "dfsSpecCtrlTypeCategoryDb";
            this.dfsSpecCtrlTypeCategoryDb.NamedProperties.Put("EnumerateMethod", "");
            this.dfsSpecCtrlTypeCategoryDb.NamedProperties.Put("LovReference", "");
            this.dfsSpecCtrlTypeCategoryDb.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsSpecCtrlTypeCategoryDb.NamedProperties.Put("SqlColumn", "SPEC_CTRL_TYPE_CATEGORY_DB");
            this.dfsSpecCtrlTypeCategoryDb.NamedProperties.Put("ValidateMethod", "");
            resources.ApplyResources(this.dfsSpecCtrlTypeCategoryDb, "dfsSpecCtrlTypeCategoryDb");
            // 
            // tblPostCtrlDetSpec
            // 
            this.tblPostCtrlDetSpec.Controls.Add(this.tblPostCtrlDetSpec_colCompany);
            this.tblPostCtrlDetSpec.Controls.Add(this.tblPostCtrlDetSpec_colPostingType);
            this.tblPostCtrlDetSpec.Controls.Add(this.tblPostCtrlDetSpec_colCodePart);
            this.tblPostCtrlDetSpec.Controls.Add(this.tblPostCtrlDetSpec_colPcValidFrom);
            this.tblPostCtrlDetSpec.Controls.Add(this.tblPostCtrlDetSpec_colsControlTypeValue);
            this.tblPostCtrlDetSpec.Controls.Add(this.tblPostCtrlDetSpec_coldValidFrom);
            this.tblPostCtrlDetSpec.Controls.Add(this.tblPostCtrlDetSpec_colSpecControlType);
            this.tblPostCtrlDetSpec.Controls.Add(this.tblPostCtrlDetSpec_colSpecModule);
            this.tblPostCtrlDetSpec.Controls.Add(this.tblPostCtrlDetSpec_colSpecControlTypeValue);
            this.tblPostCtrlDetSpec.Controls.Add(this.tblPostCtrlDetSpec_colSpecControlTypeValueDesc);
            this.tblPostCtrlDetSpec.Controls.Add(this.tblPostCtrlDetSpec_colCodePartValue);
            this.tblPostCtrlDetSpec.Controls.Add(this.tblPostCtrlDetSpec_colCodePartValueDesc);
            this.tblPostCtrlDetSpec.Controls.Add(this.tblPostCtrlDetSpec_colsNoCodePartValueDb);
            resources.ApplyResources(this.tblPostCtrlDetSpec, "tblPostCtrlDetSpec");
            this.tblPostCtrlDetSpec.Name = "tblPostCtrlDetSpec";
            this.tblPostCtrlDetSpec.NamedProperties.Put("DefaultOrderBy", "");
            this.tblPostCtrlDetSpec.NamedProperties.Put("DefaultWhere", "");
            this.tblPostCtrlDetSpec.NamedProperties.Put("LogicalUnit", "PostingCtrlDetailSpec");
            this.tblPostCtrlDetSpec.NamedProperties.Put("PackageName", "POSTING_CTRL_DETAIL_SPEC_API");
            this.tblPostCtrlDetSpec.NamedProperties.Put("ResizeableChildObject", "LLFF");
            this.tblPostCtrlDetSpec.NamedProperties.Put("ViewName", "POSTING_CTRL_DETAIL_SPEC");
            this.tblPostCtrlDetSpec.NamedProperties.Put("Warnings", "FALSE");
            this.tblPostCtrlDetSpec.DataRecordGetDefaultsEvent += new System.EventHandler<Ifs.Fnd.ApplicationForms.FndReturnEventArgsSalBoolean>(this.tblPostCtrlDetSpec_DataRecordGetDefaultsEvent);
            this.tblPostCtrlDetSpec.DataRecordPrepareNewEvent += new System.EventHandler<Ifs.Fnd.ApplicationForms.FndReturnEventArgsSalBoolean>(this.tblPostCtrlDetSpec_DataRecordPrepareNewEvent);
            this.tblPostCtrlDetSpec.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblPostCtrlDetSpec_WindowActions);
            this.tblPostCtrlDetSpec.Controls.SetChildIndex(this.tblPostCtrlDetSpec_colsNoCodePartValueDb, 0);
            this.tblPostCtrlDetSpec.Controls.SetChildIndex(this.tblPostCtrlDetSpec_colCodePartValueDesc, 0);
            this.tblPostCtrlDetSpec.Controls.SetChildIndex(this.tblPostCtrlDetSpec_colCodePartValue, 0);
            this.tblPostCtrlDetSpec.Controls.SetChildIndex(this.tblPostCtrlDetSpec_colSpecControlTypeValueDesc, 0);
            this.tblPostCtrlDetSpec.Controls.SetChildIndex(this.tblPostCtrlDetSpec_colSpecControlTypeValue, 0);
            this.tblPostCtrlDetSpec.Controls.SetChildIndex(this.tblPostCtrlDetSpec_colSpecModule, 0);
            this.tblPostCtrlDetSpec.Controls.SetChildIndex(this.tblPostCtrlDetSpec_colSpecControlType, 0);
            this.tblPostCtrlDetSpec.Controls.SetChildIndex(this.tblPostCtrlDetSpec_coldValidFrom, 0);
            this.tblPostCtrlDetSpec.Controls.SetChildIndex(this.tblPostCtrlDetSpec_colsControlTypeValue, 0);
            this.tblPostCtrlDetSpec.Controls.SetChildIndex(this.tblPostCtrlDetSpec_colPcValidFrom, 0);
            this.tblPostCtrlDetSpec.Controls.SetChildIndex(this.tblPostCtrlDetSpec_colCodePart, 0);
            this.tblPostCtrlDetSpec.Controls.SetChildIndex(this.tblPostCtrlDetSpec_colPostingType, 0);
            this.tblPostCtrlDetSpec.Controls.SetChildIndex(this.tblPostCtrlDetSpec_colCompany, 0);
            // 
            // tblPostCtrlDetSpec_colCompany
            // 
            this.tblPostCtrlDetSpec_colCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblPostCtrlDetSpec_colCompany, "tblPostCtrlDetSpec_colCompany");
            this.tblPostCtrlDetSpec_colCompany.MaxLength = 20;
            this.tblPostCtrlDetSpec_colCompany.Name = "tblPostCtrlDetSpec_colCompany";
            this.tblPostCtrlDetSpec_colCompany.NamedProperties.Put("EnumerateMethod", "");
            this.tblPostCtrlDetSpec_colCompany.NamedProperties.Put("FieldFlags", "67");
            this.tblPostCtrlDetSpec_colCompany.NamedProperties.Put("LovReference", "");
            this.tblPostCtrlDetSpec_colCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPostCtrlDetSpec_colCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.tblPostCtrlDetSpec_colCompany.NamedProperties.Put("ValidateMethod", "");
            this.tblPostCtrlDetSpec_colCompany.Position = 3;
            // 
            // tblPostCtrlDetSpec_colPostingType
            // 
            this.tblPostCtrlDetSpec_colPostingType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblPostCtrlDetSpec_colPostingType, "tblPostCtrlDetSpec_colPostingType");
            this.tblPostCtrlDetSpec_colPostingType.MaxLength = 10;
            this.tblPostCtrlDetSpec_colPostingType.Name = "tblPostCtrlDetSpec_colPostingType";
            this.tblPostCtrlDetSpec_colPostingType.NamedProperties.Put("EnumerateMethod", "");
            this.tblPostCtrlDetSpec_colPostingType.NamedProperties.Put("FieldFlags", "67");
            this.tblPostCtrlDetSpec_colPostingType.NamedProperties.Put("LovReference", "");
            this.tblPostCtrlDetSpec_colPostingType.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPostCtrlDetSpec_colPostingType.NamedProperties.Put("SqlColumn", "POSTING_TYPE");
            this.tblPostCtrlDetSpec_colPostingType.NamedProperties.Put("ValidateMethod", "");
            this.tblPostCtrlDetSpec_colPostingType.Position = 4;
            // 
            // tblPostCtrlDetSpec_colCodePart
            // 
            this.tblPostCtrlDetSpec_colCodePart.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblPostCtrlDetSpec_colCodePart, "tblPostCtrlDetSpec_colCodePart");
            this.tblPostCtrlDetSpec_colCodePart.MaxLength = 1;
            this.tblPostCtrlDetSpec_colCodePart.Name = "tblPostCtrlDetSpec_colCodePart";
            this.tblPostCtrlDetSpec_colCodePart.NamedProperties.Put("EnumerateMethod", "");
            this.tblPostCtrlDetSpec_colCodePart.NamedProperties.Put("FieldFlags", "67");
            this.tblPostCtrlDetSpec_colCodePart.NamedProperties.Put("LovReference", "");
            this.tblPostCtrlDetSpec_colCodePart.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPostCtrlDetSpec_colCodePart.NamedProperties.Put("SqlColumn", "CODE_PART");
            this.tblPostCtrlDetSpec_colCodePart.NamedProperties.Put("ValidateMethod", "");
            this.tblPostCtrlDetSpec_colCodePart.Position = 5;
            // 
            // tblPostCtrlDetSpec_colPcValidFrom
            // 
            this.tblPostCtrlDetSpec_colPcValidFrom.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            resources.ApplyResources(this.tblPostCtrlDetSpec_colPcValidFrom, "tblPostCtrlDetSpec_colPcValidFrom");
            this.tblPostCtrlDetSpec_colPcValidFrom.Format = "d";
            this.tblPostCtrlDetSpec_colPcValidFrom.Name = "tblPostCtrlDetSpec_colPcValidFrom";
            this.tblPostCtrlDetSpec_colPcValidFrom.NamedProperties.Put("EnumerateMethod", "");
            this.tblPostCtrlDetSpec_colPcValidFrom.NamedProperties.Put("FieldFlags", "67");
            this.tblPostCtrlDetSpec_colPcValidFrom.NamedProperties.Put("LovReference", "");
            this.tblPostCtrlDetSpec_colPcValidFrom.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPostCtrlDetSpec_colPcValidFrom.NamedProperties.Put("SqlColumn", "PC_VALID_FROM");
            this.tblPostCtrlDetSpec_colPcValidFrom.NamedProperties.Put("ValidateMethod", "");
            this.tblPostCtrlDetSpec_colPcValidFrom.Position = 6;
            // 
            // tblPostCtrlDetSpec_colsControlTypeValue
            // 
            this.tblPostCtrlDetSpec_colsControlTypeValue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblPostCtrlDetSpec_colsControlTypeValue, "tblPostCtrlDetSpec_colsControlTypeValue");
            this.tblPostCtrlDetSpec_colsControlTypeValue.MaxLength = 20;
            this.tblPostCtrlDetSpec_colsControlTypeValue.Name = "tblPostCtrlDetSpec_colsControlTypeValue";
            this.tblPostCtrlDetSpec_colsControlTypeValue.NamedProperties.Put("EnumerateMethod", "");
            this.tblPostCtrlDetSpec_colsControlTypeValue.NamedProperties.Put("FieldFlags", "67");
            this.tblPostCtrlDetSpec_colsControlTypeValue.NamedProperties.Put("LovReference", "");
            this.tblPostCtrlDetSpec_colsControlTypeValue.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPostCtrlDetSpec_colsControlTypeValue.NamedProperties.Put("SqlColumn", "CONTROL_TYPE_VALUE");
            this.tblPostCtrlDetSpec_colsControlTypeValue.NamedProperties.Put("ValidateMethod", "");
            this.tblPostCtrlDetSpec_colsControlTypeValue.Position = 7;
            // 
            // tblPostCtrlDetSpec_coldValidFrom
            // 
            this.tblPostCtrlDetSpec_coldValidFrom.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            resources.ApplyResources(this.tblPostCtrlDetSpec_coldValidFrom, "tblPostCtrlDetSpec_coldValidFrom");
            this.tblPostCtrlDetSpec_coldValidFrom.Format = "d";
            this.tblPostCtrlDetSpec_coldValidFrom.Name = "tblPostCtrlDetSpec_coldValidFrom";
            this.tblPostCtrlDetSpec_coldValidFrom.NamedProperties.Put("EnumerateMethod", "");
            this.tblPostCtrlDetSpec_coldValidFrom.NamedProperties.Put("FieldFlags", "67");
            this.tblPostCtrlDetSpec_coldValidFrom.NamedProperties.Put("LovReference", "POSTING_CTRL_DETAIL(COMPANY,CODE_PART,PC_VALID_FROM,POSTING_TYPE,CONTROL_TYPE_VAL" +
                    "UE)");
            this.tblPostCtrlDetSpec_coldValidFrom.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPostCtrlDetSpec_coldValidFrom.NamedProperties.Put("SqlColumn", "VALID_FROM");
            this.tblPostCtrlDetSpec_coldValidFrom.NamedProperties.Put("ValidateMethod", "");
            this.tblPostCtrlDetSpec_coldValidFrom.Position = 8;
            // 
            // tblPostCtrlDetSpec_colSpecControlType
            // 
            this.tblPostCtrlDetSpec_colSpecControlType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblPostCtrlDetSpec_colSpecControlType, "tblPostCtrlDetSpec_colSpecControlType");
            this.tblPostCtrlDetSpec_colSpecControlType.MaxLength = 10;
            this.tblPostCtrlDetSpec_colSpecControlType.Name = "tblPostCtrlDetSpec_colSpecControlType";
            this.tblPostCtrlDetSpec_colSpecControlType.NamedProperties.Put("EnumerateMethod", "");
            this.tblPostCtrlDetSpec_colSpecControlType.NamedProperties.Put("FieldFlags", "259");
            this.tblPostCtrlDetSpec_colSpecControlType.NamedProperties.Put("LovReference", "");
            this.tblPostCtrlDetSpec_colSpecControlType.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPostCtrlDetSpec_colSpecControlType.NamedProperties.Put("SqlColumn", "SPEC_CONTROL_TYPE");
            this.tblPostCtrlDetSpec_colSpecControlType.NamedProperties.Put("ValidateMethod", "");
            this.tblPostCtrlDetSpec_colSpecControlType.Position = 9;
            // 
            // tblPostCtrlDetSpec_colSpecModule
            // 
            resources.ApplyResources(this.tblPostCtrlDetSpec_colSpecModule, "tblPostCtrlDetSpec_colSpecModule");
            this.tblPostCtrlDetSpec_colSpecModule.MaxLength = 20;
            this.tblPostCtrlDetSpec_colSpecModule.Name = "tblPostCtrlDetSpec_colSpecModule";
            this.tblPostCtrlDetSpec_colSpecModule.NamedProperties.Put("EnumerateMethod", "");
            this.tblPostCtrlDetSpec_colSpecModule.NamedProperties.Put("FieldFlags", "259");
            this.tblPostCtrlDetSpec_colSpecModule.NamedProperties.Put("LovReference", "");
            this.tblPostCtrlDetSpec_colSpecModule.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPostCtrlDetSpec_colSpecModule.NamedProperties.Put("SqlColumn", "SPEC_MODULE");
            this.tblPostCtrlDetSpec_colSpecModule.NamedProperties.Put("ValidateMethod", "");
            this.tblPostCtrlDetSpec_colSpecModule.Position = 10;
            // 
            // tblPostCtrlDetSpec_colSpecControlTypeValue
            // 
            this.tblPostCtrlDetSpec_colSpecControlTypeValue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblPostCtrlDetSpec_colSpecControlTypeValue.Name = "tblPostCtrlDetSpec_colSpecControlTypeValue";
            this.tblPostCtrlDetSpec_colSpecControlTypeValue.NamedProperties.Put("EnumerateMethod", "");
            this.tblPostCtrlDetSpec_colSpecControlTypeValue.NamedProperties.Put("FieldFlags", "163");
            this.tblPostCtrlDetSpec_colSpecControlTypeValue.NamedProperties.Put("LovReference", "");
            this.tblPostCtrlDetSpec_colSpecControlTypeValue.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPostCtrlDetSpec_colSpecControlTypeValue.NamedProperties.Put("SqlColumn", "SPEC_CONTROL_TYPE_VALUE");
            this.tblPostCtrlDetSpec_colSpecControlTypeValue.NamedProperties.Put("ValidateMethod", "");
            this.tblPostCtrlDetSpec_colSpecControlTypeValue.Position = 11;
            resources.ApplyResources(this.tblPostCtrlDetSpec_colSpecControlTypeValue, "tblPostCtrlDetSpec_colSpecControlTypeValue");
            this.tblPostCtrlDetSpec_colSpecControlTypeValue.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblPostCtrlDetSpec_colSpecControlTypeValue_WindowActions);
            // 
            // tblPostCtrlDetSpec_colSpecControlTypeValueDesc
            // 
            resources.ApplyResources(this.tblPostCtrlDetSpec_colSpecControlTypeValueDesc, "tblPostCtrlDetSpec_colSpecControlTypeValueDesc");
            this.tblPostCtrlDetSpec_colSpecControlTypeValueDesc.MaxLength = 2000;
            this.tblPostCtrlDetSpec_colSpecControlTypeValueDesc.Name = "tblPostCtrlDetSpec_colSpecControlTypeValueDesc";
            this.tblPostCtrlDetSpec_colSpecControlTypeValueDesc.NamedProperties.Put("EnumerateMethod", "");
            this.tblPostCtrlDetSpec_colSpecControlTypeValueDesc.NamedProperties.Put("LovReference", "");
            this.tblPostCtrlDetSpec_colSpecControlTypeValueDesc.NamedProperties.Put("ParentName", "tblPostCtrlDetSpec.tblPostCtrlDetSpec_colSpecControlTypeValue");
            this.tblPostCtrlDetSpec_colSpecControlTypeValueDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPostCtrlDetSpec_colSpecControlTypeValueDesc.NamedProperties.Put("SqlColumn", "");
            this.tblPostCtrlDetSpec_colSpecControlTypeValueDesc.NamedProperties.Put("ValidateMethod", "");
            this.tblPostCtrlDetSpec_colSpecControlTypeValueDesc.Position = 12;
            // 
            // tblPostCtrlDetSpec_colCodePartValue
            // 
            this.tblPostCtrlDetSpec_colCodePartValue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblPostCtrlDetSpec_colCodePartValue.MaxLength = 20;
            this.tblPostCtrlDetSpec_colCodePartValue.Name = "tblPostCtrlDetSpec_colCodePartValue";
            this.tblPostCtrlDetSpec_colCodePartValue.NamedProperties.Put("EnumerateMethod", "");
            this.tblPostCtrlDetSpec_colCodePartValue.NamedProperties.Put("FieldFlags", "294");
            this.tblPostCtrlDetSpec_colCodePartValue.NamedProperties.Put("LovReference", "ACCOUNTING_CODE_PART_VALUE_LOV(COMPANY,CODE_PART)");
            this.tblPostCtrlDetSpec_colCodePartValue.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPostCtrlDetSpec_colCodePartValue.NamedProperties.Put("SqlColumn", "CODE_PART_VALUE");
            this.tblPostCtrlDetSpec_colCodePartValue.NamedProperties.Put("ValidateMethod", "");
            this.tblPostCtrlDetSpec_colCodePartValue.Position = 13;
            resources.ApplyResources(this.tblPostCtrlDetSpec_colCodePartValue, "tblPostCtrlDetSpec_colCodePartValue");
            this.tblPostCtrlDetSpec_colCodePartValue.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblPostCtrlDetSpec_colCodePartValue_WindowActions);
            // 
            // tblPostCtrlDetSpec_colCodePartValueDesc
            // 
            resources.ApplyResources(this.tblPostCtrlDetSpec_colCodePartValueDesc, "tblPostCtrlDetSpec_colCodePartValueDesc");
            this.tblPostCtrlDetSpec_colCodePartValueDesc.Name = "tblPostCtrlDetSpec_colCodePartValueDesc";
            this.tblPostCtrlDetSpec_colCodePartValueDesc.NamedProperties.Put("EnumerateMethod", "");
            this.tblPostCtrlDetSpec_colCodePartValueDesc.NamedProperties.Put("FieldFlags", "288");
            this.tblPostCtrlDetSpec_colCodePartValueDesc.NamedProperties.Put("LovReference", "");
            this.tblPostCtrlDetSpec_colCodePartValueDesc.NamedProperties.Put("ParentName", "tblPostCtrlDetSpec.tblPostCtrlDetSpec_colCodePartValue");
            this.tblPostCtrlDetSpec_colCodePartValueDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPostCtrlDetSpec_colCodePartValueDesc.NamedProperties.Put("SqlColumn", "Accounting_Code_Part_Value_API.Get_Description(COMPANY,CODE_PART,CODE_PART_VALUE)" +
                    "");
            this.tblPostCtrlDetSpec_colCodePartValueDesc.NamedProperties.Put("ValidateMethod", "");
            this.tblPostCtrlDetSpec_colCodePartValueDesc.Position = 14;
            // 
            // tblPostCtrlDetSpec_colsNoCodePartValueDb
            // 
            this.tblPostCtrlDetSpec_colsNoCodePartValueDb.Name = "tblPostCtrlDetSpec_colsNoCodePartValueDb";
            this.tblPostCtrlDetSpec_colsNoCodePartValueDb.NamedProperties.Put("EnumerateMethod", "");
            this.tblPostCtrlDetSpec_colsNoCodePartValueDb.NamedProperties.Put("FieldFlags", "295");
            this.tblPostCtrlDetSpec_colsNoCodePartValueDb.NamedProperties.Put("LovReference", "");
            this.tblPostCtrlDetSpec_colsNoCodePartValueDb.NamedProperties.Put("SqlColumn", "NO_CODE_PART_VALUE_DB");
            this.tblPostCtrlDetSpec_colsNoCodePartValueDb.Position = 15;
            resources.ApplyResources(this.tblPostCtrlDetSpec_colsNoCodePartValueDb, "tblPostCtrlDetSpec_colsNoCodePartValueDb");
            // 
            // frmPostCtrlDetSpec
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.tblPostCtrlDetSpec);
            this.Controls.Add(this.dfsSpecCtrlTypeCategoryDb);
            this.Controls.Add(this.dfsSpecModule);
            this.Controls.Add(this.dfsSpecDefaultValueNoCt);
            this.Controls.Add(this.dfsSpecDefaultValue);
            this.Controls.Add(this.dfsSpecControlTypeDesc);
            this.Controls.Add(this.dfsSpecControlType);
            this.Controls.Add(this.dfsControlTypeDesc);
            this.Controls.Add(this.dfControlType);
            this.Controls.Add(this.dfsCodeName);
            this.Controls.Add(this.dfdValidFrom);
            this.Controls.Add(this.dfsControlTypeValue);
            this.Controls.Add(this.dfPcValidFrom);
            this.Controls.Add(this.dfCodePart);
            this.Controls.Add(this.dfPostingType);
            this.Controls.Add(this.ccPostingType);
            this.Controls.Add(this.dfsPostingType);
            this.Controls.Add(this.dfCompany);
            this.Controls.Add(this.labeldfsSpecModule);
            this.Controls.Add(this.labeldfsSpecDefaultValueNoCt);
            this.Controls.Add(this.labeldfsSpecDefaultValue);
            this.Controls.Add(this.labeldfsSpecControlTypeDesc);
            this.Controls.Add(this.labeldfsSpecControlType);
            this.Controls.Add(this.labeldfsControlTypeDesc);
            this.Controls.Add(this.labeldfControlType);
            this.Controls.Add(this.labeldfsCodeName);
            this.Controls.Add(this.labeldfdValidFrom);
            this.Controls.Add(this.labeldfsControlTypeValue);
            this.Controls.Add(this.labeldfPcValidFrom);
            this.Controls.Add(this.labeldfCodePart);
            this.Controls.Add(this.labeldfPostingType);
            this.Controls.Add(this.labeldfsPostingType);
            this.Controls.Add(this.labeldfCompany);
            this.MaximizeBox = true;
            this.Name = "frmPostCtrlDetSpec";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "COMPANY = :global.company\r\nand spec_control_type is not null");
            this.NamedProperties.Put("LogicalUnit", "PostingCtrlDetail");
            this.NamedProperties.Put("PackageName", "POSTING_CTRL_DETAIL_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "0");
            this.NamedProperties.Put("SourceFlags", "1");
            this.NamedProperties.Put("ViewName", "POSTING_CTRL_DETAIL");
            this.NamedProperties.Put("Warnings", "TRUE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.frmPostCtrlDetSpec_WindowActions);
            this.tblPostCtrlDetSpec.ResumeLayout(false);
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

        public cChildTableFinBase tblPostCtrlDetSpec;
        protected cColumn tblPostCtrlDetSpec_colCompany;
        protected cColumn tblPostCtrlDetSpec_colPostingType;
        protected cColumn tblPostCtrlDetSpec_colCodePart;
        protected cColumn tblPostCtrlDetSpec_colPcValidFrom;
        protected cColumn tblPostCtrlDetSpec_colsControlTypeValue;
        protected cColumn tblPostCtrlDetSpec_coldValidFrom;
        protected cColumn tblPostCtrlDetSpec_colSpecControlType;
        protected cColumn tblPostCtrlDetSpec_colSpecModule;
        protected cColumn tblPostCtrlDetSpec_colSpecControlTypeValue;
        protected cColumn tblPostCtrlDetSpec_colSpecControlTypeValueDesc;
        protected cColumn tblPostCtrlDetSpec_colCodePartValue;
        protected cColumn tblPostCtrlDetSpec_colCodePartValueDesc;
        protected cCheckBoxColumn tblPostCtrlDetSpec_colsNoCodePartValueDb;
		
	}
}
