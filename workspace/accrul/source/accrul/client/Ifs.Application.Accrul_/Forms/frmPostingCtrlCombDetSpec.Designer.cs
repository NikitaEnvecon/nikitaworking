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
	
	public partial class frmPostingCtrlCombDetSpec
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		protected cBackgroundText labeldfsCompany;
		public cDataField dfsCompany;
		protected cBackgroundText labeldfsPostingType;
		public cDataField dfsPostingType;
		public cRecSelComboBox ccPostingType;
		protected cBackgroundText labeldfsCodePart;
		public cDataField dfsCodePart;
		protected cBackgroundText labeldfPcValidFrom;
		public cDataField dfPcValidFrom;
		protected cBackgroundText labeldfsControlType;
		public cDataField dfsControlType;
		protected cBackgroundText labeldfsControlTypeDesc;
		public cDataField dfsControlTypeDesc;
		protected cBackgroundText labeldfsSpecControlTypeValue;
		public cDataField dfsSpecControlTypeValue;
		protected cBackgroundText labeldfdValidFrom;
		public cDataField dfdValidFrom;
		protected cBackgroundText labeldfsCodeName;
		public cDataField dfsCodeName;
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
		// Bug 73298 Begin - Changed the derived base class.
		// Bug 69757, Begin (Increased max rows in memory to 100000)
        // --------------------------------------------------Hidden fields---------------------------------
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPostingCtrlCombDetSpec));
            this.labeldfsCompany = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsCompany = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsPostingType = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsPostingType = new Ifs.Fnd.ApplicationForms.cDataField();
            this.ccPostingType = new Ifs.Fnd.ApplicationForms.cRecSelComboBox();
            this.labeldfsCodePart = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsCodePart = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfPcValidFrom = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfPcValidFrom = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsControlType = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsControlType = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsControlTypeDesc = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsControlTypeDesc = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsSpecControlTypeValue = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsSpecControlTypeValue = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfdValidFrom = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfdValidFrom = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsCodeName = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsCodeName = new Ifs.Fnd.ApplicationForms.cDataField();
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
            this.tblPostCtrlCombDetSpec = new Ifs.Application.Accrul.cChildTableFinBase();
            this.tblPostCtrlCombDetSpec_colsCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPostCtrlCombDetSpec_colsPostingType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPostCtrlCombDetSpec_colsCodePart = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPostCtrlCombDetSpec_coldPcValidFrom = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPostCtrlCombDetSpec_colsControlTypeValue = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPostCtrlCombDetSpec_coldValidFrom = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPostCtrlCombDetSpec_colsSpecCombControlType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPostCtrlCombDetSpec_colsSpecModule1 = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPostCtrlCombDetSpec_colsSpecModule2 = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPostCtrlCombDetSpec_colsSpecControlType1 = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPostCtrlCombDetSpec_colsSpecControlType2 = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPostCtrlCombDetSpec_colsSpecControlType1Value = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPostCtrlCombDetSpec_colsSpecControlType1Description = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPostCtrlCombDetSpec_colsSpecControlType2Value = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPostCtrlCombDetSpec_colsSpecControlType2Description = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPostCtrlCombDetSpec_colsCodePartValue = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPostCtrlCombDetSpec_colsCodePartDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPostCtrlCombDetSpec_colsNoCodePartValueDb = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.tblPostCtrlCombDetSpec.SuspendLayout();
            this.SuspendLayout();
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
            this.dfsCompany.NamedProperties.Put("FieldFlags", "67");
            this.dfsCompany.NamedProperties.Put("LovReference", "");
            this.dfsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
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
            this.ccPostingType.NamedProperties.Put("FieldFlags", "96");
            this.ccPostingType.NamedProperties.Put("LovReference", "POSTING_CTRL_POSTING_TYPE");
            this.ccPostingType.NamedProperties.Put("ResizeableChildObject", "");
            this.ccPostingType.NamedProperties.Put("SqlColumn", "POSTING_TYPE");
            this.ccPostingType.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsCodePart
            // 
            resources.ApplyResources(this.labeldfsCodePart, "labeldfsCodePart");
            this.labeldfsCodePart.Name = "labeldfsCodePart";
            // 
            // dfsCodePart
            // 
            this.dfsCodePart.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsCodePart, "dfsCodePart");
            this.dfsCodePart.Name = "dfsCodePart";
            this.dfsCodePart.NamedProperties.Put("EnumerateMethod", "");
            this.dfsCodePart.NamedProperties.Put("FieldFlags", "67");
            this.dfsCodePart.NamedProperties.Put("LovReference", "ACCOUNTING_CODE_PARTS(COMPANY)");
            this.dfsCodePart.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsCodePart.NamedProperties.Put("SqlColumn", "CODE_PART");
            this.dfsCodePart.NamedProperties.Put("ValidateMethod", "");
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
            this.dfPcValidFrom.NamedProperties.Put("FieldFlags", "65");
            this.dfPcValidFrom.NamedProperties.Put("LovReference", "");
            this.dfPcValidFrom.NamedProperties.Put("ResizeableChildObject", "");
            this.dfPcValidFrom.NamedProperties.Put("SqlColumn", "PC_VALID_FROM");
            this.dfPcValidFrom.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsControlType
            // 
            resources.ApplyResources(this.labeldfsControlType, "labeldfsControlType");
            this.labeldfsControlType.Name = "labeldfsControlType";
            // 
            // dfsControlType
            // 
            this.dfsControlType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsControlType, "dfsControlType");
            this.dfsControlType.Name = "dfsControlType";
            this.dfsControlType.NamedProperties.Put("EnumerateMethod", "");
            this.dfsControlType.NamedProperties.Put("FieldFlags", "291");
            this.dfsControlType.NamedProperties.Put("LovReference", "");
            this.dfsControlType.NamedProperties.Put("SqlColumn", "CONTROL_TYPE");
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
            this.dfsControlTypeDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsControlTypeDesc.NamedProperties.Put("SqlColumn", "CONTROL_TYPE_DESC");
            this.dfsControlTypeDesc.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsSpecControlTypeValue
            // 
            resources.ApplyResources(this.labeldfsSpecControlTypeValue, "labeldfsSpecControlTypeValue");
            this.labeldfsSpecControlTypeValue.Name = "labeldfsSpecControlTypeValue";
            // 
            // dfsSpecControlTypeValue
            // 
            this.dfsSpecControlTypeValue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsSpecControlTypeValue, "dfsSpecControlTypeValue");
            this.dfsSpecControlTypeValue.Name = "dfsSpecControlTypeValue";
            this.dfsSpecControlTypeValue.NamedProperties.Put("EnumerateMethod", "");
            this.dfsSpecControlTypeValue.NamedProperties.Put("FieldFlags", "163");
            this.dfsSpecControlTypeValue.NamedProperties.Put("LovReference", "");
            this.dfsSpecControlTypeValue.NamedProperties.Put("SqlColumn", "CONTROL_TYPE_VALUE");
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
            this.dfdValidFrom.NamedProperties.Put("FieldFlags", "167");
            this.dfdValidFrom.NamedProperties.Put("LovReference", "");
            this.dfdValidFrom.NamedProperties.Put("SqlColumn", "VALID_FROM");
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
            this.dfsCodeName.NamedProperties.Put("FieldFlags", "288");
            this.dfsCodeName.NamedProperties.Put("LovReference", "ACCOUNTING_CODE_PARTS_USED2(COMPANY)");
            this.dfsCodeName.NamedProperties.Put("ParentName", "ccPostingType");
            this.dfsCodeName.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsCodeName.NamedProperties.Put("SqlColumn", "CODE_NAME");
            this.dfsCodeName.NamedProperties.Put("ValidateMethod", "");
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
            this.dfsSpecControlType.NamedProperties.Put("FieldFlags", "289");
            this.dfsSpecControlType.NamedProperties.Put("LovReference", "");
            this.dfsSpecControlType.NamedProperties.Put("ParentName", "ccPostingType");
            this.dfsSpecControlType.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsSpecControlType.NamedProperties.Put("SqlColumn", "SPEC_CONTROL_TYPE");
            this.dfsSpecControlType.NamedProperties.Put("ValidateMethod", "");
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
            this.dfsSpecModule.NamedProperties.Put("FieldFlags", "259");
            this.dfsSpecModule.NamedProperties.Put("LovReference", "");
            this.dfsSpecModule.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsSpecModule.NamedProperties.Put("SqlColumn", "MODULE");
            this.dfsSpecModule.NamedProperties.Put("ValidateMethod", "");
            // 
            // tblPostCtrlCombDetSpec
            // 
            this.tblPostCtrlCombDetSpec.Controls.Add(this.tblPostCtrlCombDetSpec_colsCompany);
            this.tblPostCtrlCombDetSpec.Controls.Add(this.tblPostCtrlCombDetSpec_colsPostingType);
            this.tblPostCtrlCombDetSpec.Controls.Add(this.tblPostCtrlCombDetSpec_colsCodePart);
            this.tblPostCtrlCombDetSpec.Controls.Add(this.tblPostCtrlCombDetSpec_coldPcValidFrom);
            this.tblPostCtrlCombDetSpec.Controls.Add(this.tblPostCtrlCombDetSpec_colsControlTypeValue);
            this.tblPostCtrlCombDetSpec.Controls.Add(this.tblPostCtrlCombDetSpec_coldValidFrom);
            this.tblPostCtrlCombDetSpec.Controls.Add(this.tblPostCtrlCombDetSpec_colsSpecCombControlType);
            this.tblPostCtrlCombDetSpec.Controls.Add(this.tblPostCtrlCombDetSpec_colsSpecModule1);
            this.tblPostCtrlCombDetSpec.Controls.Add(this.tblPostCtrlCombDetSpec_colsSpecModule2);
            this.tblPostCtrlCombDetSpec.Controls.Add(this.tblPostCtrlCombDetSpec_colsSpecControlType1);
            this.tblPostCtrlCombDetSpec.Controls.Add(this.tblPostCtrlCombDetSpec_colsSpecControlType2);
            this.tblPostCtrlCombDetSpec.Controls.Add(this.tblPostCtrlCombDetSpec_colsSpecControlType1Value);
            this.tblPostCtrlCombDetSpec.Controls.Add(this.tblPostCtrlCombDetSpec_colsSpecControlType1Description);
            this.tblPostCtrlCombDetSpec.Controls.Add(this.tblPostCtrlCombDetSpec_colsSpecControlType2Value);
            this.tblPostCtrlCombDetSpec.Controls.Add(this.tblPostCtrlCombDetSpec_colsSpecControlType2Description);
            this.tblPostCtrlCombDetSpec.Controls.Add(this.tblPostCtrlCombDetSpec_colsCodePartValue);
            this.tblPostCtrlCombDetSpec.Controls.Add(this.tblPostCtrlCombDetSpec_colsCodePartDescription);
            this.tblPostCtrlCombDetSpec.Controls.Add(this.tblPostCtrlCombDetSpec_colsNoCodePartValueDb);
            resources.ApplyResources(this.tblPostCtrlCombDetSpec, "tblPostCtrlCombDetSpec");
            this.tblPostCtrlCombDetSpec.Name = "tblPostCtrlCombDetSpec";
            this.tblPostCtrlCombDetSpec.NamedProperties.Put("DefaultOrderBy", "");
            this.tblPostCtrlCombDetSpec.NamedProperties.Put("DefaultWhere", "");
            this.tblPostCtrlCombDetSpec.NamedProperties.Put("LogicalUnit", "PostingCtrlCombDetSpec");
            this.tblPostCtrlCombDetSpec.NamedProperties.Put("PackageName", "POSTING_CTRL_COMB_DET_SPEC_API");
            this.tblPostCtrlCombDetSpec.NamedProperties.Put("ResizeableChildObject", "LLFF");
            this.tblPostCtrlCombDetSpec.NamedProperties.Put("ViewName", "POSTING_CTRL_COMB_DET_SPEC");
            this.tblPostCtrlCombDetSpec.NamedProperties.Put("Warnings", "FALSE");
            this.tblPostCtrlCombDetSpec.DataRecordToFormUserEvent += new Ifs.Fnd.ApplicationForms.cDataSource.DataRecordToFormUserEventHandler(this.tblPostCtrlCombDetSpec_DataRecordToFormUserEvent);
            this.tblPostCtrlCombDetSpec.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblPostCtrlCombDetSpec_WindowActions);
            this.tblPostCtrlCombDetSpec.Controls.SetChildIndex(this.tblPostCtrlCombDetSpec_colsNoCodePartValueDb, 0);
            this.tblPostCtrlCombDetSpec.Controls.SetChildIndex(this.tblPostCtrlCombDetSpec_colsCodePartDescription, 0);
            this.tblPostCtrlCombDetSpec.Controls.SetChildIndex(this.tblPostCtrlCombDetSpec_colsCodePartValue, 0);
            this.tblPostCtrlCombDetSpec.Controls.SetChildIndex(this.tblPostCtrlCombDetSpec_colsSpecControlType2Description, 0);
            this.tblPostCtrlCombDetSpec.Controls.SetChildIndex(this.tblPostCtrlCombDetSpec_colsSpecControlType2Value, 0);
            this.tblPostCtrlCombDetSpec.Controls.SetChildIndex(this.tblPostCtrlCombDetSpec_colsSpecControlType1Description, 0);
            this.tblPostCtrlCombDetSpec.Controls.SetChildIndex(this.tblPostCtrlCombDetSpec_colsSpecControlType1Value, 0);
            this.tblPostCtrlCombDetSpec.Controls.SetChildIndex(this.tblPostCtrlCombDetSpec_colsSpecControlType2, 0);
            this.tblPostCtrlCombDetSpec.Controls.SetChildIndex(this.tblPostCtrlCombDetSpec_colsSpecControlType1, 0);
            this.tblPostCtrlCombDetSpec.Controls.SetChildIndex(this.tblPostCtrlCombDetSpec_colsSpecModule2, 0);
            this.tblPostCtrlCombDetSpec.Controls.SetChildIndex(this.tblPostCtrlCombDetSpec_colsSpecModule1, 0);
            this.tblPostCtrlCombDetSpec.Controls.SetChildIndex(this.tblPostCtrlCombDetSpec_colsSpecCombControlType, 0);
            this.tblPostCtrlCombDetSpec.Controls.SetChildIndex(this.tblPostCtrlCombDetSpec_coldValidFrom, 0);
            this.tblPostCtrlCombDetSpec.Controls.SetChildIndex(this.tblPostCtrlCombDetSpec_colsControlTypeValue, 0);
            this.tblPostCtrlCombDetSpec.Controls.SetChildIndex(this.tblPostCtrlCombDetSpec_coldPcValidFrom, 0);
            this.tblPostCtrlCombDetSpec.Controls.SetChildIndex(this.tblPostCtrlCombDetSpec_colsCodePart, 0);
            this.tblPostCtrlCombDetSpec.Controls.SetChildIndex(this.tblPostCtrlCombDetSpec_colsPostingType, 0);
            this.tblPostCtrlCombDetSpec.Controls.SetChildIndex(this.tblPostCtrlCombDetSpec_colsCompany, 0);
            // 
            // tblPostCtrlCombDetSpec_colsCompany
            // 
            this.tblPostCtrlCombDetSpec_colsCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblPostCtrlCombDetSpec_colsCompany, "tblPostCtrlCombDetSpec_colsCompany");
            this.tblPostCtrlCombDetSpec_colsCompany.MaxLength = 20;
            this.tblPostCtrlCombDetSpec_colsCompany.Name = "tblPostCtrlCombDetSpec_colsCompany";
            this.tblPostCtrlCombDetSpec_colsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.tblPostCtrlCombDetSpec_colsCompany.NamedProperties.Put("FieldFlags", "67");
            this.tblPostCtrlCombDetSpec_colsCompany.NamedProperties.Put("LovReference", "COMPANY_FINANCE");
            this.tblPostCtrlCombDetSpec_colsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.tblPostCtrlCombDetSpec_colsCompany.Position = 3;
            // 
            // tblPostCtrlCombDetSpec_colsPostingType
            // 
            this.tblPostCtrlCombDetSpec_colsPostingType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblPostCtrlCombDetSpec_colsPostingType, "tblPostCtrlCombDetSpec_colsPostingType");
            this.tblPostCtrlCombDetSpec_colsPostingType.MaxLength = 10;
            this.tblPostCtrlCombDetSpec_colsPostingType.Name = "tblPostCtrlCombDetSpec_colsPostingType";
            this.tblPostCtrlCombDetSpec_colsPostingType.NamedProperties.Put("EnumerateMethod", "");
            this.tblPostCtrlCombDetSpec_colsPostingType.NamedProperties.Put("FieldFlags", "67");
            this.tblPostCtrlCombDetSpec_colsPostingType.NamedProperties.Put("LovReference", "");
            this.tblPostCtrlCombDetSpec_colsPostingType.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPostCtrlCombDetSpec_colsPostingType.NamedProperties.Put("SqlColumn", "POSTING_TYPE");
            this.tblPostCtrlCombDetSpec_colsPostingType.NamedProperties.Put("ValidateMethod", "");
            this.tblPostCtrlCombDetSpec_colsPostingType.Position = 4;
            // 
            // tblPostCtrlCombDetSpec_colsCodePart
            // 
            this.tblPostCtrlCombDetSpec_colsCodePart.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblPostCtrlCombDetSpec_colsCodePart, "tblPostCtrlCombDetSpec_colsCodePart");
            this.tblPostCtrlCombDetSpec_colsCodePart.MaxLength = 1;
            this.tblPostCtrlCombDetSpec_colsCodePart.Name = "tblPostCtrlCombDetSpec_colsCodePart";
            this.tblPostCtrlCombDetSpec_colsCodePart.NamedProperties.Put("EnumerateMethod", "");
            this.tblPostCtrlCombDetSpec_colsCodePart.NamedProperties.Put("FieldFlags", "71");
            this.tblPostCtrlCombDetSpec_colsCodePart.NamedProperties.Put("LovReference", "");
            this.tblPostCtrlCombDetSpec_colsCodePart.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPostCtrlCombDetSpec_colsCodePart.NamedProperties.Put("SqlColumn", "CODE_PART");
            this.tblPostCtrlCombDetSpec_colsCodePart.NamedProperties.Put("ValidateMethod", "");
            this.tblPostCtrlCombDetSpec_colsCodePart.Position = 5;
            // 
            // tblPostCtrlCombDetSpec_coldPcValidFrom
            // 
            this.tblPostCtrlCombDetSpec_coldPcValidFrom.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            resources.ApplyResources(this.tblPostCtrlCombDetSpec_coldPcValidFrom, "tblPostCtrlCombDetSpec_coldPcValidFrom");
            this.tblPostCtrlCombDetSpec_coldPcValidFrom.Format = "d";
            this.tblPostCtrlCombDetSpec_coldPcValidFrom.Name = "tblPostCtrlCombDetSpec_coldPcValidFrom";
            this.tblPostCtrlCombDetSpec_coldPcValidFrom.NamedProperties.Put("EnumerateMethod", "");
            this.tblPostCtrlCombDetSpec_coldPcValidFrom.NamedProperties.Put("FieldFlags", "67");
            this.tblPostCtrlCombDetSpec_coldPcValidFrom.NamedProperties.Put("LovReference", "");
            this.tblPostCtrlCombDetSpec_coldPcValidFrom.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPostCtrlCombDetSpec_coldPcValidFrom.NamedProperties.Put("SqlColumn", "PC_VALID_FROM");
            this.tblPostCtrlCombDetSpec_coldPcValidFrom.NamedProperties.Put("ValidateMethod", "");
            this.tblPostCtrlCombDetSpec_coldPcValidFrom.Position = 6;
            // 
            // tblPostCtrlCombDetSpec_colsControlTypeValue
            // 
            this.tblPostCtrlCombDetSpec_colsControlTypeValue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblPostCtrlCombDetSpec_colsControlTypeValue, "tblPostCtrlCombDetSpec_colsControlTypeValue");
            this.tblPostCtrlCombDetSpec_colsControlTypeValue.MaxLength = 20;
            this.tblPostCtrlCombDetSpec_colsControlTypeValue.Name = "tblPostCtrlCombDetSpec_colsControlTypeValue";
            this.tblPostCtrlCombDetSpec_colsControlTypeValue.NamedProperties.Put("EnumerateMethod", "");
            this.tblPostCtrlCombDetSpec_colsControlTypeValue.NamedProperties.Put("FieldFlags", "71");
            this.tblPostCtrlCombDetSpec_colsControlTypeValue.NamedProperties.Put("LovReference", "");
            this.tblPostCtrlCombDetSpec_colsControlTypeValue.NamedProperties.Put("SqlColumn", "CONTROL_TYPE_VALUE");
            this.tblPostCtrlCombDetSpec_colsControlTypeValue.Position = 7;
            // 
            // tblPostCtrlCombDetSpec_coldValidFrom
            // 
            this.tblPostCtrlCombDetSpec_coldValidFrom.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            resources.ApplyResources(this.tblPostCtrlCombDetSpec_coldValidFrom, "tblPostCtrlCombDetSpec_coldValidFrom");
            this.tblPostCtrlCombDetSpec_coldValidFrom.Format = "d";
            this.tblPostCtrlCombDetSpec_coldValidFrom.Name = "tblPostCtrlCombDetSpec_coldValidFrom";
            this.tblPostCtrlCombDetSpec_coldValidFrom.NamedProperties.Put("EnumerateMethod", "");
            this.tblPostCtrlCombDetSpec_coldValidFrom.NamedProperties.Put("FieldFlags", "71");
            this.tblPostCtrlCombDetSpec_coldValidFrom.NamedProperties.Put("LovReference", "POSTING_CTRL_DETAIL(COMPANY,CODE_PART,PC_VALID_FROM,POSTING_TYPE,CONTROL_TYPE_VAL" +
                    "UE)");
            this.tblPostCtrlCombDetSpec_coldValidFrom.NamedProperties.Put("SqlColumn", "VALID_FROM");
            this.tblPostCtrlCombDetSpec_coldValidFrom.Position = 8;
            // 
            // tblPostCtrlCombDetSpec_colsSpecCombControlType
            // 
            this.tblPostCtrlCombDetSpec_colsSpecCombControlType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblPostCtrlCombDetSpec_colsSpecCombControlType, "tblPostCtrlCombDetSpec_colsSpecCombControlType");
            this.tblPostCtrlCombDetSpec_colsSpecCombControlType.MaxLength = 10;
            this.tblPostCtrlCombDetSpec_colsSpecCombControlType.Name = "tblPostCtrlCombDetSpec_colsSpecCombControlType";
            this.tblPostCtrlCombDetSpec_colsSpecCombControlType.NamedProperties.Put("EnumerateMethod", "");
            this.tblPostCtrlCombDetSpec_colsSpecCombControlType.NamedProperties.Put("FieldFlags", "131");
            this.tblPostCtrlCombDetSpec_colsSpecCombControlType.NamedProperties.Put("LovReference", "");
            this.tblPostCtrlCombDetSpec_colsSpecCombControlType.NamedProperties.Put("SqlColumn", "SPEC_COMB_CONTROL_TYPE");
            this.tblPostCtrlCombDetSpec_colsSpecCombControlType.NamedProperties.Put("ValidateMethod", "");
            this.tblPostCtrlCombDetSpec_colsSpecCombControlType.Position = 9;
            // 
            // tblPostCtrlCombDetSpec_colsSpecModule1
            // 
            this.tblPostCtrlCombDetSpec_colsSpecModule1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblPostCtrlCombDetSpec_colsSpecModule1, "tblPostCtrlCombDetSpec_colsSpecModule1");
            this.tblPostCtrlCombDetSpec_colsSpecModule1.MaxLength = 20;
            this.tblPostCtrlCombDetSpec_colsSpecModule1.Name = "tblPostCtrlCombDetSpec_colsSpecModule1";
            this.tblPostCtrlCombDetSpec_colsSpecModule1.NamedProperties.Put("EnumerateMethod", "");
            this.tblPostCtrlCombDetSpec_colsSpecModule1.NamedProperties.Put("FieldFlags", "263");
            this.tblPostCtrlCombDetSpec_colsSpecModule1.NamedProperties.Put("LovReference", "");
            this.tblPostCtrlCombDetSpec_colsSpecModule1.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPostCtrlCombDetSpec_colsSpecModule1.NamedProperties.Put("SqlColumn", "SPEC_MODULE1");
            this.tblPostCtrlCombDetSpec_colsSpecModule1.NamedProperties.Put("ValidateMethod", "");
            this.tblPostCtrlCombDetSpec_colsSpecModule1.Position = 10;
            // 
            // tblPostCtrlCombDetSpec_colsSpecModule2
            // 
            this.tblPostCtrlCombDetSpec_colsSpecModule2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblPostCtrlCombDetSpec_colsSpecModule2, "tblPostCtrlCombDetSpec_colsSpecModule2");
            this.tblPostCtrlCombDetSpec_colsSpecModule2.MaxLength = 20;
            this.tblPostCtrlCombDetSpec_colsSpecModule2.Name = "tblPostCtrlCombDetSpec_colsSpecModule2";
            this.tblPostCtrlCombDetSpec_colsSpecModule2.NamedProperties.Put("EnumerateMethod", "");
            this.tblPostCtrlCombDetSpec_colsSpecModule2.NamedProperties.Put("FieldFlags", "263");
            this.tblPostCtrlCombDetSpec_colsSpecModule2.NamedProperties.Put("LovReference", "");
            this.tblPostCtrlCombDetSpec_colsSpecModule2.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPostCtrlCombDetSpec_colsSpecModule2.NamedProperties.Put("SqlColumn", "SPEC_MODULE2");
            this.tblPostCtrlCombDetSpec_colsSpecModule2.NamedProperties.Put("ValidateMethod", "");
            this.tblPostCtrlCombDetSpec_colsSpecModule2.Position = 11;
            // 
            // tblPostCtrlCombDetSpec_colsSpecControlType1
            // 
            this.tblPostCtrlCombDetSpec_colsSpecControlType1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblPostCtrlCombDetSpec_colsSpecControlType1, "tblPostCtrlCombDetSpec_colsSpecControlType1");
            this.tblPostCtrlCombDetSpec_colsSpecControlType1.MaxLength = 10;
            this.tblPostCtrlCombDetSpec_colsSpecControlType1.Name = "tblPostCtrlCombDetSpec_colsSpecControlType1";
            this.tblPostCtrlCombDetSpec_colsSpecControlType1.NamedProperties.Put("EnumerateMethod", "");
            this.tblPostCtrlCombDetSpec_colsSpecControlType1.NamedProperties.Put("LovReference", "");
            this.tblPostCtrlCombDetSpec_colsSpecControlType1.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPostCtrlCombDetSpec_colsSpecControlType1.NamedProperties.Put("SqlColumn", "SPEC_CONTROL_TYPE1");
            this.tblPostCtrlCombDetSpec_colsSpecControlType1.NamedProperties.Put("ValidateMethod", "");
            this.tblPostCtrlCombDetSpec_colsSpecControlType1.Position = 12;
            // 
            // tblPostCtrlCombDetSpec_colsSpecControlType2
            // 
            this.tblPostCtrlCombDetSpec_colsSpecControlType2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblPostCtrlCombDetSpec_colsSpecControlType2, "tblPostCtrlCombDetSpec_colsSpecControlType2");
            this.tblPostCtrlCombDetSpec_colsSpecControlType2.MaxLength = 10;
            this.tblPostCtrlCombDetSpec_colsSpecControlType2.Name = "tblPostCtrlCombDetSpec_colsSpecControlType2";
            this.tblPostCtrlCombDetSpec_colsSpecControlType2.NamedProperties.Put("EnumerateMethod", "");
            this.tblPostCtrlCombDetSpec_colsSpecControlType2.NamedProperties.Put("LovReference", "");
            this.tblPostCtrlCombDetSpec_colsSpecControlType2.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPostCtrlCombDetSpec_colsSpecControlType2.NamedProperties.Put("SqlColumn", "SPEC_CONTROL_TYPE2");
            this.tblPostCtrlCombDetSpec_colsSpecControlType2.NamedProperties.Put("ValidateMethod", "");
            this.tblPostCtrlCombDetSpec_colsSpecControlType2.Position = 13;
            // 
            // tblPostCtrlCombDetSpec_colsSpecControlType1Value
            // 
            this.tblPostCtrlCombDetSpec_colsSpecControlType1Value.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblPostCtrlCombDetSpec_colsSpecControlType1Value.Name = "tblPostCtrlCombDetSpec_colsSpecControlType1Value";
            this.tblPostCtrlCombDetSpec_colsSpecControlType1Value.NamedProperties.Put("EnumerateMethod", "");
            this.tblPostCtrlCombDetSpec_colsSpecControlType1Value.NamedProperties.Put("FieldFlags", "163");
            this.tblPostCtrlCombDetSpec_colsSpecControlType1Value.NamedProperties.Put("LovReference", "");
            this.tblPostCtrlCombDetSpec_colsSpecControlType1Value.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPostCtrlCombDetSpec_colsSpecControlType1Value.NamedProperties.Put("SqlColumn", "SPEC_CONTROL_TYPE1_VALUE");
            this.tblPostCtrlCombDetSpec_colsSpecControlType1Value.NamedProperties.Put("ValidateMethod", "");
            this.tblPostCtrlCombDetSpec_colsSpecControlType1Value.Position = 14;
            resources.ApplyResources(this.tblPostCtrlCombDetSpec_colsSpecControlType1Value, "tblPostCtrlCombDetSpec_colsSpecControlType1Value");
            this.tblPostCtrlCombDetSpec_colsSpecControlType1Value.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblPostCtrlCombDetSpec_colsSpecControlType1Value_WindowActions);
            // 
            // tblPostCtrlCombDetSpec_colsSpecControlType1Description
            // 
            resources.ApplyResources(this.tblPostCtrlCombDetSpec_colsSpecControlType1Description, "tblPostCtrlCombDetSpec_colsSpecControlType1Description");
            this.tblPostCtrlCombDetSpec_colsSpecControlType1Description.MaxLength = 2000;
            this.tblPostCtrlCombDetSpec_colsSpecControlType1Description.Name = "tblPostCtrlCombDetSpec_colsSpecControlType1Description";
            this.tblPostCtrlCombDetSpec_colsSpecControlType1Description.NamedProperties.Put("EnumerateMethod", "");
            this.tblPostCtrlCombDetSpec_colsSpecControlType1Description.NamedProperties.Put("LovReference", "");
            this.tblPostCtrlCombDetSpec_colsSpecControlType1Description.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPostCtrlCombDetSpec_colsSpecControlType1Description.NamedProperties.Put("SqlColumn", "");
            this.tblPostCtrlCombDetSpec_colsSpecControlType1Description.NamedProperties.Put("ValidateMethod", "");
            this.tblPostCtrlCombDetSpec_colsSpecControlType1Description.Position = 15;
            // 
            // tblPostCtrlCombDetSpec_colsSpecControlType2Value
            // 
            this.tblPostCtrlCombDetSpec_colsSpecControlType2Value.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblPostCtrlCombDetSpec_colsSpecControlType2Value.Name = "tblPostCtrlCombDetSpec_colsSpecControlType2Value";
            this.tblPostCtrlCombDetSpec_colsSpecControlType2Value.NamedProperties.Put("EnumerateMethod", "");
            this.tblPostCtrlCombDetSpec_colsSpecControlType2Value.NamedProperties.Put("FieldFlags", "163");
            this.tblPostCtrlCombDetSpec_colsSpecControlType2Value.NamedProperties.Put("LovReference", "");
            this.tblPostCtrlCombDetSpec_colsSpecControlType2Value.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPostCtrlCombDetSpec_colsSpecControlType2Value.NamedProperties.Put("SqlColumn", "SPEC_CONTROL_TYPE2_VALUE");
            this.tblPostCtrlCombDetSpec_colsSpecControlType2Value.NamedProperties.Put("ValidateMethod", "");
            this.tblPostCtrlCombDetSpec_colsSpecControlType2Value.Position = 16;
            resources.ApplyResources(this.tblPostCtrlCombDetSpec_colsSpecControlType2Value, "tblPostCtrlCombDetSpec_colsSpecControlType2Value");
            this.tblPostCtrlCombDetSpec_colsSpecControlType2Value.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblPostCtrlCombDetSpec_colsSpecControlType2Value_WindowActions);
            // 
            // tblPostCtrlCombDetSpec_colsSpecControlType2Description
            // 
            resources.ApplyResources(this.tblPostCtrlCombDetSpec_colsSpecControlType2Description, "tblPostCtrlCombDetSpec_colsSpecControlType2Description");
            this.tblPostCtrlCombDetSpec_colsSpecControlType2Description.MaxLength = 2000;
            this.tblPostCtrlCombDetSpec_colsSpecControlType2Description.Name = "tblPostCtrlCombDetSpec_colsSpecControlType2Description";
            this.tblPostCtrlCombDetSpec_colsSpecControlType2Description.NamedProperties.Put("EnumerateMethod", "");
            this.tblPostCtrlCombDetSpec_colsSpecControlType2Description.NamedProperties.Put("LovReference", "");
            this.tblPostCtrlCombDetSpec_colsSpecControlType2Description.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPostCtrlCombDetSpec_colsSpecControlType2Description.NamedProperties.Put("SqlColumn", "");
            this.tblPostCtrlCombDetSpec_colsSpecControlType2Description.NamedProperties.Put("ValidateMethod", "");
            this.tblPostCtrlCombDetSpec_colsSpecControlType2Description.Position = 17;
            // 
            // tblPostCtrlCombDetSpec_colsCodePartValue
            // 
            this.tblPostCtrlCombDetSpec_colsCodePartValue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblPostCtrlCombDetSpec_colsCodePartValue.MaxLength = 20;
            this.tblPostCtrlCombDetSpec_colsCodePartValue.Name = "tblPostCtrlCombDetSpec_colsCodePartValue";
            this.tblPostCtrlCombDetSpec_colsCodePartValue.NamedProperties.Put("EnumerateMethod", "");
            this.tblPostCtrlCombDetSpec_colsCodePartValue.NamedProperties.Put("FieldFlags", "294");
            this.tblPostCtrlCombDetSpec_colsCodePartValue.NamedProperties.Put("LovReference", "ACCOUNTING_CODE_PART_VALUE_LOV(COMPANY,CODE_PART)");
            this.tblPostCtrlCombDetSpec_colsCodePartValue.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPostCtrlCombDetSpec_colsCodePartValue.NamedProperties.Put("SqlColumn", "CODE_PART_VALUE");
            this.tblPostCtrlCombDetSpec_colsCodePartValue.NamedProperties.Put("ValidateMethod", "");
            this.tblPostCtrlCombDetSpec_colsCodePartValue.Position = 18;
            resources.ApplyResources(this.tblPostCtrlCombDetSpec_colsCodePartValue, "tblPostCtrlCombDetSpec_colsCodePartValue");
            this.tblPostCtrlCombDetSpec_colsCodePartValue.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblPostCtrlCombDetSpec_colsCodePartValue_WindowActions);
            // 
            // tblPostCtrlCombDetSpec_colsCodePartDescription
            // 
            resources.ApplyResources(this.tblPostCtrlCombDetSpec_colsCodePartDescription, "tblPostCtrlCombDetSpec_colsCodePartDescription");
            this.tblPostCtrlCombDetSpec_colsCodePartDescription.Name = "tblPostCtrlCombDetSpec_colsCodePartDescription";
            this.tblPostCtrlCombDetSpec_colsCodePartDescription.NamedProperties.Put("EnumerateMethod", "");
            this.tblPostCtrlCombDetSpec_colsCodePartDescription.NamedProperties.Put("FieldFlags", "288");
            this.tblPostCtrlCombDetSpec_colsCodePartDescription.NamedProperties.Put("LovReference", "");
            this.tblPostCtrlCombDetSpec_colsCodePartDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPostCtrlCombDetSpec_colsCodePartDescription.NamedProperties.Put("SqlColumn", "ACCOUNTING_CODE_PART_VALUE_API.Get_Description(COMPANY,CODE_PART,CODE_PART_VALUE)" +
                    "");
            this.tblPostCtrlCombDetSpec_colsCodePartDescription.NamedProperties.Put("ValidateMethod", "");
            this.tblPostCtrlCombDetSpec_colsCodePartDescription.Position = 19;
            // 
            // tblPostCtrlCombDetSpec_colsNoCodePartValueDb
            // 
            this.tblPostCtrlCombDetSpec_colsNoCodePartValueDb.Name = "tblPostCtrlCombDetSpec_colsNoCodePartValueDb";
            this.tblPostCtrlCombDetSpec_colsNoCodePartValueDb.NamedProperties.Put("EnumerateMethod", "");
            this.tblPostCtrlCombDetSpec_colsNoCodePartValueDb.NamedProperties.Put("FieldFlags", "295");
            this.tblPostCtrlCombDetSpec_colsNoCodePartValueDb.NamedProperties.Put("LovReference", "");
            this.tblPostCtrlCombDetSpec_colsNoCodePartValueDb.NamedProperties.Put("SqlColumn", "NO_CODE_PART_VALUE_DB");
            this.tblPostCtrlCombDetSpec_colsNoCodePartValueDb.Position = 20;
            resources.ApplyResources(this.tblPostCtrlCombDetSpec_colsNoCodePartValueDb, "tblPostCtrlCombDetSpec_colsNoCodePartValueDb");
            // 
            // frmPostingCtrlCombDetSpec
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.tblPostCtrlCombDetSpec);
            this.Controls.Add(this.dfsSpecModule);
            this.Controls.Add(this.dfsSpecDefaultValueNoCt);
            this.Controls.Add(this.dfsSpecDefaultValue);
            this.Controls.Add(this.dfsSpecControlTypeDesc);
            this.Controls.Add(this.dfsSpecControlType);
            this.Controls.Add(this.dfsCodeName);
            this.Controls.Add(this.dfdValidFrom);
            this.Controls.Add(this.dfsSpecControlTypeValue);
            this.Controls.Add(this.dfsControlTypeDesc);
            this.Controls.Add(this.dfsControlType);
            this.Controls.Add(this.dfPcValidFrom);
            this.Controls.Add(this.dfsCodePart);
            this.Controls.Add(this.ccPostingType);
            this.Controls.Add(this.dfsPostingType);
            this.Controls.Add(this.dfsCompany);
            this.Controls.Add(this.labeldfsSpecModule);
            this.Controls.Add(this.labeldfsSpecDefaultValueNoCt);
            this.Controls.Add(this.labeldfsSpecDefaultValue);
            this.Controls.Add(this.labeldfsSpecControlTypeDesc);
            this.Controls.Add(this.labeldfsSpecControlType);
            this.Controls.Add(this.labeldfsCodeName);
            this.Controls.Add(this.labeldfdValidFrom);
            this.Controls.Add(this.labeldfsSpecControlTypeValue);
            this.Controls.Add(this.labeldfsControlTypeDesc);
            this.Controls.Add(this.labeldfsControlType);
            this.Controls.Add(this.labeldfPcValidFrom);
            this.Controls.Add(this.labeldfsCodePart);
            this.Controls.Add(this.labeldfsPostingType);
            this.Controls.Add(this.labeldfsCompany);
            this.MaximizeBox = true;
            this.Name = "frmPostingCtrlCombDetSpec";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "COMPANY = :global.company\r\nand spec_control_type is not null");
            this.NamedProperties.Put("LogicalUnit", "PostingCtrlDetail");
            this.NamedProperties.Put("PackageName", "POSTING_CTRL_DETAIL_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "1");
            this.NamedProperties.Put("ViewName", "POSTING_CTRL_DETAIL");
            this.NamedProperties.Put("Warnings", "TRUE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.frmPostingCtrlCombDetSpec_WindowActions);
            this.tblPostCtrlCombDetSpec.ResumeLayout(false);
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

        public cChildTableFinBase tblPostCtrlCombDetSpec;
        protected cColumn tblPostCtrlCombDetSpec_colsCompany;
        protected cColumn tblPostCtrlCombDetSpec_colsPostingType;
        protected cColumn tblPostCtrlCombDetSpec_colsCodePart;
        protected cColumn tblPostCtrlCombDetSpec_coldPcValidFrom;
        protected cColumn tblPostCtrlCombDetSpec_colsControlTypeValue;
        protected cColumn tblPostCtrlCombDetSpec_coldValidFrom;
        protected cColumn tblPostCtrlCombDetSpec_colsSpecCombControlType;
        protected cColumn tblPostCtrlCombDetSpec_colsSpecModule1;
        protected cColumn tblPostCtrlCombDetSpec_colsSpecModule2;
        protected cColumn tblPostCtrlCombDetSpec_colsSpecControlType1;
        protected cColumn tblPostCtrlCombDetSpec_colsSpecControlType2;
        protected cColumn tblPostCtrlCombDetSpec_colsSpecControlType1Value;
        protected cColumn tblPostCtrlCombDetSpec_colsSpecControlType1Description;
        protected cColumn tblPostCtrlCombDetSpec_colsSpecControlType2Value;
        protected cColumn tblPostCtrlCombDetSpec_colsSpecControlType2Description;
        protected cColumn tblPostCtrlCombDetSpec_colsCodePartValue;
        protected cColumn tblPostCtrlCombDetSpec_colsCodePartDescription;
        protected cCheckBoxColumn tblPostCtrlCombDetSpec_colsNoCodePartValueDb;
	}
}
