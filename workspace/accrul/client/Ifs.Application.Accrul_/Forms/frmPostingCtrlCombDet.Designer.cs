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
	
	public partial class frmPostingCtrlCombDet
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		protected cBackgroundText labeldfsCompany;
		public cDataField dfsCompany;
		protected cBackgroundText labelccPostingType;
		public cRecSelExtComboBox ccPostingType;
		protected cBackgroundText labeldfsCodePart;
		public cDataField dfsCodePart;
		protected cBackgroundText labeldfsCodeName;
		public cDataField dfsCodeName;
		protected cBackgroundText labeldfsControlType;
		public cDataField dfsControlType;
		protected cBackgroundText labeldfPcValidFrom;
		public cDataField dfPcValidFrom;
		protected cBackgroundText labeldfsModule;
		public cDataField dfsModule;
		protected cBackgroundText labeldfsDefaultValue;
		public cDataField dfsDefaultValue;
		protected cBackgroundText labeldfDefaultValueNoCt;
		public cDataField dfDefaultValueNoCt;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPostingCtrlCombDet));
            this.labeldfsCompany = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsCompany = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelccPostingType = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.ccPostingType = new Ifs.Fnd.ApplicationForms.cRecSelExtComboBox();
            this.labeldfsCodePart = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsCodePart = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsCodeName = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsCodeName = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsControlType = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsControlType = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfPcValidFrom = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfPcValidFrom = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsModule = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsModule = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsDefaultValue = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsDefaultValue = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfDefaultValueNoCt = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfDefaultValueNoCt = new Ifs.Fnd.ApplicationForms.cDataField();
            this.tblPostCtrlCombDet = new Ifs.Application.Accrul.cChildTableFinBase();
            this.tblPostCtrlCombDet_colsCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPostCtrlCombDet_colsPostingType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPostCtrlCombDet_colsCodePart = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPostCtrlCombDet_coldPcValidFrom = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPostCtrlCombDet_colsCodePartName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPostCtrlCombDet_colsCombModule = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPostCtrlCombDet_colsCombControlType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPostCtrlCombDet_colsModule1 = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPostCtrlCombDet_colsModule2 = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPostCtrlCombDet_colsControlType1 = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPostCtrlCombDet_colsControlType2 = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPostCtrlCombDet_colsControlType1Value = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPostCtrlCombDet_colsControlType1Description = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPostCtrlCombDet_colsControlType2Value = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPostCtrlCombDet_colsControlType2Description = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPostCtrlCombDet_colsCodePartValue = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPostCtrlCombDet_colsCodePartDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPostCtrlCombDet_colsNoCodePartValueDb = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.tblPostCtrlCombDet_coldValidFrom = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPostCtrlCombDet.SuspendLayout();
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
            // labelccPostingType
            // 
            resources.ApplyResources(this.labelccPostingType, "labelccPostingType");
            this.labelccPostingType.Name = "labelccPostingType";
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
            this.ccPostingType.NamedProperties.Put("XDataLength", "Default");
            this.ccPostingType.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.ccPostingType_WindowActions);
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
            this.dfsCodePart.NamedProperties.Put("ParentName", "ccPostingType");
            this.dfsCodePart.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsCodePart.NamedProperties.Put("SqlColumn", "CODE_PART");
            this.dfsCodePart.NamedProperties.Put("ValidateMethod", "");
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
            this.dfsControlType.NamedProperties.Put("FieldFlags", "289");
            this.dfsControlType.NamedProperties.Put("LovReference", "");
            this.dfsControlType.NamedProperties.Put("ParentName", "ccPostingType");
            this.dfsControlType.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsControlType.NamedProperties.Put("SqlColumn", "CONTROL_TYPE");
            this.dfsControlType.NamedProperties.Put("ValidateMethod", "");
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
            this.dfPcValidFrom.NamedProperties.Put("ParentName", "ccPostingType");
            this.dfPcValidFrom.NamedProperties.Put("ResizeableChildObject", "");
            this.dfPcValidFrom.NamedProperties.Put("SqlColumn", "PC_VALID_FROM");
            this.dfPcValidFrom.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsModule
            // 
            resources.ApplyResources(this.labeldfsModule, "labeldfsModule");
            this.labeldfsModule.Name = "labeldfsModule";
            // 
            // dfsModule
            // 
            this.dfsModule.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsModule, "dfsModule");
            this.dfsModule.Name = "dfsModule";
            this.dfsModule.NamedProperties.Put("EnumerateMethod", "");
            this.dfsModule.NamedProperties.Put("FieldFlags", "259");
            this.dfsModule.NamedProperties.Put("LovReference", "");
            this.dfsModule.NamedProperties.Put("ParentName", "ccPostingType");
            this.dfsModule.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsModule.NamedProperties.Put("SqlColumn", "MODULE");
            this.dfsModule.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsDefaultValue
            // 
            resources.ApplyResources(this.labeldfsDefaultValue, "labeldfsDefaultValue");
            this.labeldfsDefaultValue.Name = "labeldfsDefaultValue";
            // 
            // dfsDefaultValue
            // 
            this.dfsDefaultValue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsDefaultValue, "dfsDefaultValue");
            this.dfsDefaultValue.Name = "dfsDefaultValue";
            this.dfsDefaultValue.NamedProperties.Put("EnumerateMethod", "");
            this.dfsDefaultValue.NamedProperties.Put("FieldFlags", "288");
            this.dfsDefaultValue.NamedProperties.Put("LovReference", "");
            this.dfsDefaultValue.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsDefaultValue.NamedProperties.Put("SqlColumn", "DEFAULT_VALUE");
            this.dfsDefaultValue.NamedProperties.Put("ValidateMethod", "");
            this.dfsDefaultValue.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsDefaultValue_WindowActions);
            // 
            // labeldfDefaultValueNoCt
            // 
            resources.ApplyResources(this.labeldfDefaultValueNoCt, "labeldfDefaultValueNoCt");
            this.labeldfDefaultValueNoCt.Name = "labeldfDefaultValueNoCt";
            // 
            // dfDefaultValueNoCt
            // 
            resources.ApplyResources(this.dfDefaultValueNoCt, "dfDefaultValueNoCt");
            this.dfDefaultValueNoCt.Name = "dfDefaultValueNoCt";
            this.dfDefaultValueNoCt.NamedProperties.Put("EnumerateMethod", "");
            this.dfDefaultValueNoCt.NamedProperties.Put("FieldFlags", "288");
            this.dfDefaultValueNoCt.NamedProperties.Put("LovReference", "");
            this.dfDefaultValueNoCt.NamedProperties.Put("ResizeableChildObject", "");
            this.dfDefaultValueNoCt.NamedProperties.Put("SqlColumn", "DEFAULT_VALUE_NO_CT");
            this.dfDefaultValueNoCt.NamedProperties.Put("ValidateMethod", "");
            // 
            // tblPostCtrlCombDet
            // 
            this.tblPostCtrlCombDet.Controls.Add(this.tblPostCtrlCombDet_colsCompany);
            this.tblPostCtrlCombDet.Controls.Add(this.tblPostCtrlCombDet_colsPostingType);
            this.tblPostCtrlCombDet.Controls.Add(this.tblPostCtrlCombDet_colsCodePart);
            this.tblPostCtrlCombDet.Controls.Add(this.tblPostCtrlCombDet_coldPcValidFrom);
            this.tblPostCtrlCombDet.Controls.Add(this.tblPostCtrlCombDet_colsCodePartName);
            this.tblPostCtrlCombDet.Controls.Add(this.tblPostCtrlCombDet_colsCombModule);
            this.tblPostCtrlCombDet.Controls.Add(this.tblPostCtrlCombDet_colsCombControlType);
            this.tblPostCtrlCombDet.Controls.Add(this.tblPostCtrlCombDet_colsModule1);
            this.tblPostCtrlCombDet.Controls.Add(this.tblPostCtrlCombDet_colsModule2);
            this.tblPostCtrlCombDet.Controls.Add(this.tblPostCtrlCombDet_colsControlType1);
            this.tblPostCtrlCombDet.Controls.Add(this.tblPostCtrlCombDet_colsControlType2);
            this.tblPostCtrlCombDet.Controls.Add(this.tblPostCtrlCombDet_colsControlType1Value);
            this.tblPostCtrlCombDet.Controls.Add(this.tblPostCtrlCombDet_colsControlType1Description);
            this.tblPostCtrlCombDet.Controls.Add(this.tblPostCtrlCombDet_colsControlType2Value);
            this.tblPostCtrlCombDet.Controls.Add(this.tblPostCtrlCombDet_colsControlType2Description);
            this.tblPostCtrlCombDet.Controls.Add(this.tblPostCtrlCombDet_colsCodePartValue);
            this.tblPostCtrlCombDet.Controls.Add(this.tblPostCtrlCombDet_colsCodePartDescription);
            this.tblPostCtrlCombDet.Controls.Add(this.tblPostCtrlCombDet_colsNoCodePartValueDb);
            this.tblPostCtrlCombDet.Controls.Add(this.tblPostCtrlCombDet_coldValidFrom);
            resources.ApplyResources(this.tblPostCtrlCombDet, "tblPostCtrlCombDet");
            this.tblPostCtrlCombDet.Name = "tblPostCtrlCombDet";
            this.tblPostCtrlCombDet.NamedProperties.Put("DefaultOrderBy", "");
            this.tblPostCtrlCombDet.NamedProperties.Put("DefaultWhere", "");
            this.tblPostCtrlCombDet.NamedProperties.Put("LogicalUnit", "PostingCtrlCombDetail");
            this.tblPostCtrlCombDet.NamedProperties.Put("PackageName", "POSTING_CTRL_COMB_DETAIL_API");
            this.tblPostCtrlCombDet.NamedProperties.Put("ResizeableChildObject", "LLFF");
            this.tblPostCtrlCombDet.NamedProperties.Put("ViewName", "POSTING_CTRL_COMB_DETAIL");
            this.tblPostCtrlCombDet.NamedProperties.Put("Warnings", "FALSE");
            this.tblPostCtrlCombDet.DataRecordGetDefaultsEvent += new System.EventHandler<Ifs.Fnd.ApplicationForms.FndReturnEventArgsSalBoolean>(this.tblPostCtrlCombDet_DataRecordGetDefaultsEvent);
            this.tblPostCtrlCombDet.DataRecordPrepareNewEvent += new System.EventHandler<Ifs.Fnd.ApplicationForms.FndReturnEventArgsSalBoolean>(this.tblPostCtrlCombDet_DataRecordPrepareNewEvent);
            this.tblPostCtrlCombDet.DataRecordToFormUserEvent += new Ifs.Fnd.ApplicationForms.cDataSource.DataRecordToFormUserEventHandler(this.tblPostCtrlCombDet_DataRecordToFormUserEvent);
            this.tblPostCtrlCombDet.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblPostCtrlCombDet_WindowActions);
            this.tblPostCtrlCombDet.Controls.SetChildIndex(this.tblPostCtrlCombDet_coldValidFrom, 0);
            this.tblPostCtrlCombDet.Controls.SetChildIndex(this.tblPostCtrlCombDet_colsNoCodePartValueDb, 0);
            this.tblPostCtrlCombDet.Controls.SetChildIndex(this.tblPostCtrlCombDet_colsCodePartDescription, 0);
            this.tblPostCtrlCombDet.Controls.SetChildIndex(this.tblPostCtrlCombDet_colsCodePartValue, 0);
            this.tblPostCtrlCombDet.Controls.SetChildIndex(this.tblPostCtrlCombDet_colsControlType2Description, 0);
            this.tblPostCtrlCombDet.Controls.SetChildIndex(this.tblPostCtrlCombDet_colsControlType2Value, 0);
            this.tblPostCtrlCombDet.Controls.SetChildIndex(this.tblPostCtrlCombDet_colsControlType1Description, 0);
            this.tblPostCtrlCombDet.Controls.SetChildIndex(this.tblPostCtrlCombDet_colsControlType1Value, 0);
            this.tblPostCtrlCombDet.Controls.SetChildIndex(this.tblPostCtrlCombDet_colsControlType2, 0);
            this.tblPostCtrlCombDet.Controls.SetChildIndex(this.tblPostCtrlCombDet_colsControlType1, 0);
            this.tblPostCtrlCombDet.Controls.SetChildIndex(this.tblPostCtrlCombDet_colsModule2, 0);
            this.tblPostCtrlCombDet.Controls.SetChildIndex(this.tblPostCtrlCombDet_colsModule1, 0);
            this.tblPostCtrlCombDet.Controls.SetChildIndex(this.tblPostCtrlCombDet_colsCombControlType, 0);
            this.tblPostCtrlCombDet.Controls.SetChildIndex(this.tblPostCtrlCombDet_colsCombModule, 0);
            this.tblPostCtrlCombDet.Controls.SetChildIndex(this.tblPostCtrlCombDet_colsCodePartName, 0);
            this.tblPostCtrlCombDet.Controls.SetChildIndex(this.tblPostCtrlCombDet_coldPcValidFrom, 0);
            this.tblPostCtrlCombDet.Controls.SetChildIndex(this.tblPostCtrlCombDet_colsCodePart, 0);
            this.tblPostCtrlCombDet.Controls.SetChildIndex(this.tblPostCtrlCombDet_colsPostingType, 0);
            this.tblPostCtrlCombDet.Controls.SetChildIndex(this.tblPostCtrlCombDet_colsCompany, 0);
            // 
            // tblPostCtrlCombDet_colsCompany
            // 
            this.tblPostCtrlCombDet_colsCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblPostCtrlCombDet_colsCompany, "tblPostCtrlCombDet_colsCompany");
            this.tblPostCtrlCombDet_colsCompany.MaxLength = 20;
            this.tblPostCtrlCombDet_colsCompany.Name = "tblPostCtrlCombDet_colsCompany";
            this.tblPostCtrlCombDet_colsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.tblPostCtrlCombDet_colsCompany.NamedProperties.Put("FieldFlags", "67");
            this.tblPostCtrlCombDet_colsCompany.NamedProperties.Put("LovReference", "COMPANY_FINANCE");
            this.tblPostCtrlCombDet_colsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.tblPostCtrlCombDet_colsCompany.Position = 3;
            // 
            // tblPostCtrlCombDet_colsPostingType
            // 
            this.tblPostCtrlCombDet_colsPostingType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblPostCtrlCombDet_colsPostingType, "tblPostCtrlCombDet_colsPostingType");
            this.tblPostCtrlCombDet_colsPostingType.MaxLength = 10;
            this.tblPostCtrlCombDet_colsPostingType.Name = "tblPostCtrlCombDet_colsPostingType";
            this.tblPostCtrlCombDet_colsPostingType.NamedProperties.Put("EnumerateMethod", "");
            this.tblPostCtrlCombDet_colsPostingType.NamedProperties.Put("FieldFlags", "67");
            this.tblPostCtrlCombDet_colsPostingType.NamedProperties.Put("LovReference", "");
            this.tblPostCtrlCombDet_colsPostingType.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPostCtrlCombDet_colsPostingType.NamedProperties.Put("SqlColumn", "POSTING_TYPE");
            this.tblPostCtrlCombDet_colsPostingType.NamedProperties.Put("ValidateMethod", "");
            this.tblPostCtrlCombDet_colsPostingType.Position = 4;
            // 
            // tblPostCtrlCombDet_colsCodePart
            // 
            this.tblPostCtrlCombDet_colsCodePart.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblPostCtrlCombDet_colsCodePart, "tblPostCtrlCombDet_colsCodePart");
            this.tblPostCtrlCombDet_colsCodePart.MaxLength = 1;
            this.tblPostCtrlCombDet_colsCodePart.Name = "tblPostCtrlCombDet_colsCodePart";
            this.tblPostCtrlCombDet_colsCodePart.NamedProperties.Put("EnumerateMethod", "");
            this.tblPostCtrlCombDet_colsCodePart.NamedProperties.Put("FieldFlags", "71");
            this.tblPostCtrlCombDet_colsCodePart.NamedProperties.Put("LovReference", "");
            this.tblPostCtrlCombDet_colsCodePart.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPostCtrlCombDet_colsCodePart.NamedProperties.Put("SqlColumn", "CODE_PART");
            this.tblPostCtrlCombDet_colsCodePart.NamedProperties.Put("ValidateMethod", "");
            this.tblPostCtrlCombDet_colsCodePart.Position = 5;
            // 
            // tblPostCtrlCombDet_coldPcValidFrom
            // 
            this.tblPostCtrlCombDet_coldPcValidFrom.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            resources.ApplyResources(this.tblPostCtrlCombDet_coldPcValidFrom, "tblPostCtrlCombDet_coldPcValidFrom");
            this.tblPostCtrlCombDet_coldPcValidFrom.Format = "d";
            this.tblPostCtrlCombDet_coldPcValidFrom.Name = "tblPostCtrlCombDet_coldPcValidFrom";
            this.tblPostCtrlCombDet_coldPcValidFrom.NamedProperties.Put("EnumerateMethod", "");
            this.tblPostCtrlCombDet_coldPcValidFrom.NamedProperties.Put("FieldFlags", "67");
            this.tblPostCtrlCombDet_coldPcValidFrom.NamedProperties.Put("LovReference", "");
            this.tblPostCtrlCombDet_coldPcValidFrom.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPostCtrlCombDet_coldPcValidFrom.NamedProperties.Put("SqlColumn", "PC_VALID_FROM");
            this.tblPostCtrlCombDet_coldPcValidFrom.NamedProperties.Put("ValidateMethod", "");
            this.tblPostCtrlCombDet_coldPcValidFrom.Position = 6;
            // 
            // tblPostCtrlCombDet_colsCodePartName
            // 
            resources.ApplyResources(this.tblPostCtrlCombDet_colsCodePartName, "tblPostCtrlCombDet_colsCodePartName");
            this.tblPostCtrlCombDet_colsCodePartName.MaxLength = 20;
            this.tblPostCtrlCombDet_colsCodePartName.Name = "tblPostCtrlCombDet_colsCodePartName";
            this.tblPostCtrlCombDet_colsCodePartName.NamedProperties.Put("EnumerateMethod", "");
            this.tblPostCtrlCombDet_colsCodePartName.NamedProperties.Put("FieldFlags", "262");
            this.tblPostCtrlCombDet_colsCodePartName.NamedProperties.Put("LovReference", "ACCOUNTING_CODE_PARTS_USED2(COMPANY)");
            this.tblPostCtrlCombDet_colsCodePartName.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPostCtrlCombDet_colsCodePartName.NamedProperties.Put("SqlColumn", "CODE_PART_NAME");
            this.tblPostCtrlCombDet_colsCodePartName.NamedProperties.Put("ValidateMethod", "");
            this.tblPostCtrlCombDet_colsCodePartName.Position = 7;
            // 
            // tblPostCtrlCombDet_colsCombModule
            // 
            this.tblPostCtrlCombDet_colsCombModule.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblPostCtrlCombDet_colsCombModule, "tblPostCtrlCombDet_colsCombModule");
            this.tblPostCtrlCombDet_colsCombModule.MaxLength = 20;
            this.tblPostCtrlCombDet_colsCombModule.Name = "tblPostCtrlCombDet_colsCombModule";
            this.tblPostCtrlCombDet_colsCombModule.NamedProperties.Put("EnumerateMethod", "");
            this.tblPostCtrlCombDet_colsCombModule.NamedProperties.Put("FieldFlags", "262");
            this.tblPostCtrlCombDet_colsCombModule.NamedProperties.Put("LovReference", "");
            this.tblPostCtrlCombDet_colsCombModule.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPostCtrlCombDet_colsCombModule.NamedProperties.Put("SqlColumn", "COMB_MODULE");
            this.tblPostCtrlCombDet_colsCombModule.NamedProperties.Put("ValidateMethod", "");
            this.tblPostCtrlCombDet_colsCombModule.Position = 8;
            // 
            // tblPostCtrlCombDet_colsCombControlType
            // 
            this.tblPostCtrlCombDet_colsCombControlType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblPostCtrlCombDet_colsCombControlType, "tblPostCtrlCombDet_colsCombControlType");
            this.tblPostCtrlCombDet_colsCombControlType.MaxLength = 10;
            this.tblPostCtrlCombDet_colsCombControlType.Name = "tblPostCtrlCombDet_colsCombControlType";
            this.tblPostCtrlCombDet_colsCombControlType.NamedProperties.Put("EnumerateMethod", "");
            this.tblPostCtrlCombDet_colsCombControlType.NamedProperties.Put("FieldFlags", "135");
            this.tblPostCtrlCombDet_colsCombControlType.NamedProperties.Put("LovReference", "");
            this.tblPostCtrlCombDet_colsCombControlType.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPostCtrlCombDet_colsCombControlType.NamedProperties.Put("SqlColumn", "COMB_CONTROL_TYPE");
            this.tblPostCtrlCombDet_colsCombControlType.NamedProperties.Put("ValidateMethod", "");
            this.tblPostCtrlCombDet_colsCombControlType.Position = 9;
            // 
            // tblPostCtrlCombDet_colsModule1
            // 
            this.tblPostCtrlCombDet_colsModule1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblPostCtrlCombDet_colsModule1, "tblPostCtrlCombDet_colsModule1");
            this.tblPostCtrlCombDet_colsModule1.MaxLength = 20;
            this.tblPostCtrlCombDet_colsModule1.Name = "tblPostCtrlCombDet_colsModule1";
            this.tblPostCtrlCombDet_colsModule1.NamedProperties.Put("EnumerateMethod", "");
            this.tblPostCtrlCombDet_colsModule1.NamedProperties.Put("FieldFlags", "263");
            this.tblPostCtrlCombDet_colsModule1.NamedProperties.Put("LovReference", "");
            this.tblPostCtrlCombDet_colsModule1.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPostCtrlCombDet_colsModule1.NamedProperties.Put("SqlColumn", "MODULE1");
            this.tblPostCtrlCombDet_colsModule1.NamedProperties.Put("ValidateMethod", "");
            this.tblPostCtrlCombDet_colsModule1.Position = 10;
            // 
            // tblPostCtrlCombDet_colsModule2
            // 
            this.tblPostCtrlCombDet_colsModule2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblPostCtrlCombDet_colsModule2, "tblPostCtrlCombDet_colsModule2");
            this.tblPostCtrlCombDet_colsModule2.MaxLength = 20;
            this.tblPostCtrlCombDet_colsModule2.Name = "tblPostCtrlCombDet_colsModule2";
            this.tblPostCtrlCombDet_colsModule2.NamedProperties.Put("EnumerateMethod", "");
            this.tblPostCtrlCombDet_colsModule2.NamedProperties.Put("FieldFlags", "263");
            this.tblPostCtrlCombDet_colsModule2.NamedProperties.Put("LovReference", "");
            this.tblPostCtrlCombDet_colsModule2.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPostCtrlCombDet_colsModule2.NamedProperties.Put("SqlColumn", "MODULE2");
            this.tblPostCtrlCombDet_colsModule2.NamedProperties.Put("ValidateMethod", "");
            this.tblPostCtrlCombDet_colsModule2.Position = 11;
            // 
            // tblPostCtrlCombDet_colsControlType1
            // 
            this.tblPostCtrlCombDet_colsControlType1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblPostCtrlCombDet_colsControlType1, "tblPostCtrlCombDet_colsControlType1");
            this.tblPostCtrlCombDet_colsControlType1.MaxLength = 10;
            this.tblPostCtrlCombDet_colsControlType1.Name = "tblPostCtrlCombDet_colsControlType1";
            this.tblPostCtrlCombDet_colsControlType1.NamedProperties.Put("EnumerateMethod", "");
            this.tblPostCtrlCombDet_colsControlType1.NamedProperties.Put("FieldFlags", "128");
            this.tblPostCtrlCombDet_colsControlType1.NamedProperties.Put("LovReference", "");
            this.tblPostCtrlCombDet_colsControlType1.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPostCtrlCombDet_colsControlType1.NamedProperties.Put("SqlColumn", "CONTROL_TYPE1");
            this.tblPostCtrlCombDet_colsControlType1.NamedProperties.Put("ValidateMethod", "");
            this.tblPostCtrlCombDet_colsControlType1.Position = 12;
            // 
            // tblPostCtrlCombDet_colsControlType2
            // 
            this.tblPostCtrlCombDet_colsControlType2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblPostCtrlCombDet_colsControlType2, "tblPostCtrlCombDet_colsControlType2");
            this.tblPostCtrlCombDet_colsControlType2.MaxLength = 10;
            this.tblPostCtrlCombDet_colsControlType2.Name = "tblPostCtrlCombDet_colsControlType2";
            this.tblPostCtrlCombDet_colsControlType2.NamedProperties.Put("EnumerateMethod", "");
            this.tblPostCtrlCombDet_colsControlType2.NamedProperties.Put("FieldFlags", "128");
            this.tblPostCtrlCombDet_colsControlType2.NamedProperties.Put("LovReference", "");
            this.tblPostCtrlCombDet_colsControlType2.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPostCtrlCombDet_colsControlType2.NamedProperties.Put("SqlColumn", "CONTROL_TYPE2");
            this.tblPostCtrlCombDet_colsControlType2.NamedProperties.Put("ValidateMethod", "");
            this.tblPostCtrlCombDet_colsControlType2.Position = 13;
            // 
            // tblPostCtrlCombDet_colsControlType1Value
            // 
            this.tblPostCtrlCombDet_colsControlType1Value.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblPostCtrlCombDet_colsControlType1Value.Name = "tblPostCtrlCombDet_colsControlType1Value";
            this.tblPostCtrlCombDet_colsControlType1Value.NamedProperties.Put("EnumerateMethod", "");
            this.tblPostCtrlCombDet_colsControlType1Value.NamedProperties.Put("FieldFlags", "163");
            this.tblPostCtrlCombDet_colsControlType1Value.NamedProperties.Put("LovReference", "");
            this.tblPostCtrlCombDet_colsControlType1Value.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPostCtrlCombDet_colsControlType1Value.NamedProperties.Put("SqlColumn", "CONTROL_TYPE1_VALUE");
            this.tblPostCtrlCombDet_colsControlType1Value.NamedProperties.Put("ValidateMethod", "");
            this.tblPostCtrlCombDet_colsControlType1Value.Position = 14;
            resources.ApplyResources(this.tblPostCtrlCombDet_colsControlType1Value, "tblPostCtrlCombDet_colsControlType1Value");
            this.tblPostCtrlCombDet_colsControlType1Value.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblPostCtrlCombDet_colsControlType1Value_WindowActions);
            // 
            // tblPostCtrlCombDet_colsControlType1Description
            // 
            resources.ApplyResources(this.tblPostCtrlCombDet_colsControlType1Description, "tblPostCtrlCombDet_colsControlType1Description");
            this.tblPostCtrlCombDet_colsControlType1Description.MaxLength = 2000;
            this.tblPostCtrlCombDet_colsControlType1Description.Name = "tblPostCtrlCombDet_colsControlType1Description";
            this.tblPostCtrlCombDet_colsControlType1Description.NamedProperties.Put("EnumerateMethod", "");
            this.tblPostCtrlCombDet_colsControlType1Description.NamedProperties.Put("LovReference", "");
            this.tblPostCtrlCombDet_colsControlType1Description.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPostCtrlCombDet_colsControlType1Description.NamedProperties.Put("SqlColumn", "");
            this.tblPostCtrlCombDet_colsControlType1Description.NamedProperties.Put("ValidateMethod", "");
            this.tblPostCtrlCombDet_colsControlType1Description.Position = 15;
            // 
            // tblPostCtrlCombDet_colsControlType2Value
            // 
            this.tblPostCtrlCombDet_colsControlType2Value.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblPostCtrlCombDet_colsControlType2Value.Name = "tblPostCtrlCombDet_colsControlType2Value";
            this.tblPostCtrlCombDet_colsControlType2Value.NamedProperties.Put("EnumerateMethod", "");
            this.tblPostCtrlCombDet_colsControlType2Value.NamedProperties.Put("FieldFlags", "163");
            this.tblPostCtrlCombDet_colsControlType2Value.NamedProperties.Put("LovReference", "");
            this.tblPostCtrlCombDet_colsControlType2Value.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPostCtrlCombDet_colsControlType2Value.NamedProperties.Put("SqlColumn", "CONTROL_TYPE2_VALUE");
            this.tblPostCtrlCombDet_colsControlType2Value.NamedProperties.Put("ValidateMethod", "");
            this.tblPostCtrlCombDet_colsControlType2Value.Position = 16;
            resources.ApplyResources(this.tblPostCtrlCombDet_colsControlType2Value, "tblPostCtrlCombDet_colsControlType2Value");
            this.tblPostCtrlCombDet_colsControlType2Value.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblPostCtrlCombDet_colsControlType2Value_WindowActions);
            // 
            // tblPostCtrlCombDet_colsControlType2Description
            // 
            resources.ApplyResources(this.tblPostCtrlCombDet_colsControlType2Description, "tblPostCtrlCombDet_colsControlType2Description");
            this.tblPostCtrlCombDet_colsControlType2Description.MaxLength = 2000;
            this.tblPostCtrlCombDet_colsControlType2Description.Name = "tblPostCtrlCombDet_colsControlType2Description";
            this.tblPostCtrlCombDet_colsControlType2Description.NamedProperties.Put("EnumerateMethod", "");
            this.tblPostCtrlCombDet_colsControlType2Description.NamedProperties.Put("LovReference", "");
            this.tblPostCtrlCombDet_colsControlType2Description.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPostCtrlCombDet_colsControlType2Description.NamedProperties.Put("SqlColumn", "");
            this.tblPostCtrlCombDet_colsControlType2Description.NamedProperties.Put("ValidateMethod", "");
            this.tblPostCtrlCombDet_colsControlType2Description.Position = 17;
            // 
            // tblPostCtrlCombDet_colsCodePartValue
            // 
            this.tblPostCtrlCombDet_colsCodePartValue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblPostCtrlCombDet_colsCodePartValue.MaxLength = 20;
            this.tblPostCtrlCombDet_colsCodePartValue.Name = "tblPostCtrlCombDet_colsCodePartValue";
            this.tblPostCtrlCombDet_colsCodePartValue.NamedProperties.Put("EnumerateMethod", "");
            this.tblPostCtrlCombDet_colsCodePartValue.NamedProperties.Put("FieldFlags", "294");
            this.tblPostCtrlCombDet_colsCodePartValue.NamedProperties.Put("LovReference", "ACCOUNTING_CODE_PART_VALUE_LOV(COMPANY,CODE_PART)");
            this.tblPostCtrlCombDet_colsCodePartValue.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPostCtrlCombDet_colsCodePartValue.NamedProperties.Put("SqlColumn", "CODE_PART_VALUE");
            this.tblPostCtrlCombDet_colsCodePartValue.NamedProperties.Put("ValidateMethod", "");
            this.tblPostCtrlCombDet_colsCodePartValue.Position = 18;
            resources.ApplyResources(this.tblPostCtrlCombDet_colsCodePartValue, "tblPostCtrlCombDet_colsCodePartValue");
            this.tblPostCtrlCombDet_colsCodePartValue.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblPostCtrlCombDet_colsCodePartValue_WindowActions);
            // 
            // tblPostCtrlCombDet_colsCodePartDescription
            // 
            resources.ApplyResources(this.tblPostCtrlCombDet_colsCodePartDescription, "tblPostCtrlCombDet_colsCodePartDescription");
            this.tblPostCtrlCombDet_colsCodePartDescription.Name = "tblPostCtrlCombDet_colsCodePartDescription";
            this.tblPostCtrlCombDet_colsCodePartDescription.NamedProperties.Put("EnumerateMethod", "");
            this.tblPostCtrlCombDet_colsCodePartDescription.NamedProperties.Put("FieldFlags", "288");
            this.tblPostCtrlCombDet_colsCodePartDescription.NamedProperties.Put("LovReference", "");
            this.tblPostCtrlCombDet_colsCodePartDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPostCtrlCombDet_colsCodePartDescription.NamedProperties.Put("SqlColumn", "ACCOUNTING_CODE_PART_VALUE_API.Get_Description(COMPANY,CODE_PART,CODE_PART_VALUE)" +
                    "");
            this.tblPostCtrlCombDet_colsCodePartDescription.NamedProperties.Put("ValidateMethod", "");
            this.tblPostCtrlCombDet_colsCodePartDescription.Position = 19;
            // 
            // tblPostCtrlCombDet_colsNoCodePartValueDb
            // 
            this.tblPostCtrlCombDet_colsNoCodePartValueDb.Name = "tblPostCtrlCombDet_colsNoCodePartValueDb";
            this.tblPostCtrlCombDet_colsNoCodePartValueDb.NamedProperties.Put("EnumerateMethod", "");
            this.tblPostCtrlCombDet_colsNoCodePartValueDb.NamedProperties.Put("FieldFlags", "295");
            this.tblPostCtrlCombDet_colsNoCodePartValueDb.NamedProperties.Put("LovReference", "");
            this.tblPostCtrlCombDet_colsNoCodePartValueDb.NamedProperties.Put("SqlColumn", "NO_CODE_PART_VALUE_DB");
            this.tblPostCtrlCombDet_colsNoCodePartValueDb.Position = 20;
            resources.ApplyResources(this.tblPostCtrlCombDet_colsNoCodePartValueDb, "tblPostCtrlCombDet_colsNoCodePartValueDb");
            // 
            // tblPostCtrlCombDet_coldValidFrom
            // 
            this.tblPostCtrlCombDet_coldValidFrom.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.tblPostCtrlCombDet_coldValidFrom.Format = "d";
            this.tblPostCtrlCombDet_coldValidFrom.Name = "tblPostCtrlCombDet_coldValidFrom";
            this.tblPostCtrlCombDet_coldValidFrom.NamedProperties.Put("EnumerateMethod", "");
            this.tblPostCtrlCombDet_coldValidFrom.NamedProperties.Put("FieldFlags", "163");
            this.tblPostCtrlCombDet_coldValidFrom.NamedProperties.Put("LovReference", "");
            this.tblPostCtrlCombDet_coldValidFrom.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPostCtrlCombDet_coldValidFrom.NamedProperties.Put("SqlColumn", "VALID_FROM");
            this.tblPostCtrlCombDet_coldValidFrom.NamedProperties.Put("ValidateMethod", "");
            this.tblPostCtrlCombDet_coldValidFrom.Position = 21;
            resources.ApplyResources(this.tblPostCtrlCombDet_coldValidFrom, "tblPostCtrlCombDet_coldValidFrom");
            // 
            // frmPostingCtrlCombDet
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.tblPostCtrlCombDet);
            this.Controls.Add(this.dfDefaultValueNoCt);
            this.Controls.Add(this.dfsDefaultValue);
            this.Controls.Add(this.dfsModule);
            this.Controls.Add(this.dfPcValidFrom);
            this.Controls.Add(this.dfsControlType);
            this.Controls.Add(this.dfsCodeName);
            this.Controls.Add(this.dfsCodePart);
            this.Controls.Add(this.ccPostingType);
            this.Controls.Add(this.dfsCompany);
            this.Controls.Add(this.labeldfDefaultValueNoCt);
            this.Controls.Add(this.labeldfsDefaultValue);
            this.Controls.Add(this.labeldfsModule);
            this.Controls.Add(this.labeldfPcValidFrom);
            this.Controls.Add(this.labeldfsControlType);
            this.Controls.Add(this.labeldfsCodeName);
            this.Controls.Add(this.labeldfsCodePart);
            this.Controls.Add(this.labelccPostingType);
            this.Controls.Add(this.labeldfsCompany);
            this.MaximizeBox = true;
            this.Name = "frmPostingCtrlCombDet";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "COMPANY = :global.company AND \r\nCTRL_TYPE_CATEGORY_DB = \'COMBINATION\'");
            this.NamedProperties.Put("LogicalUnit", "PostingCtrl");
            this.NamedProperties.Put("PackageName", "POSTING_CTRL_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "1");
            this.NamedProperties.Put("ViewName", "POSTING_CTRL_MASTER");
            this.NamedProperties.Put("Warnings", "TRUE");
            this.tblPostCtrlCombDet.ResumeLayout(false);
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

        public cChildTableFinBase tblPostCtrlCombDet;
        protected cColumn tblPostCtrlCombDet_colsCompany;
        protected cColumn tblPostCtrlCombDet_colsPostingType;
        protected cColumn tblPostCtrlCombDet_colsCodePart;
        protected cColumn tblPostCtrlCombDet_coldPcValidFrom;
        protected cColumn tblPostCtrlCombDet_colsCodePartName;
        protected cColumn tblPostCtrlCombDet_colsCombModule;
        protected cColumn tblPostCtrlCombDet_colsCombControlType;
        protected cColumn tblPostCtrlCombDet_colsModule1;
        protected cColumn tblPostCtrlCombDet_colsModule2;
        protected cColumn tblPostCtrlCombDet_colsControlType1;
        protected cColumn tblPostCtrlCombDet_colsControlType2;
        protected cColumn tblPostCtrlCombDet_colsControlType1Value;
        protected cColumn tblPostCtrlCombDet_colsControlType1Description;
        protected cColumn tblPostCtrlCombDet_colsControlType2Value;
        protected cColumn tblPostCtrlCombDet_colsControlType2Description;
        protected cColumn tblPostCtrlCombDet_colsCodePartValue;
        protected cColumn tblPostCtrlCombDet_colsCodePartDescription;
        protected cCheckBoxColumn tblPostCtrlCombDet_colsNoCodePartValueDb;
        protected cColumn tblPostCtrlCombDet_coldValidFrom;
		
		
	}
}
