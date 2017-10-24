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
	
	public partial class frmPostCtrlDet
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		protected cBackgroundText labeldfCompany;
		public cDataField dfCompany;
		protected cBackgroundText labelccPostingType;
		public cRecSelExtComboBox ccPostingType;
		protected cBackgroundText label3;
		// Bug 75959, Removed dfPostingType
		protected cBackgroundText labeldfCodePart;
		public cDataField dfCodePart;
		protected cBackgroundText labeldfsCodeName;
		public cDataField dfsCodeName;
		protected cBackgroundText labeldfControlType;
		public cDataField dfControlType;
		protected cBackgroundText labeldfPcValidFrom;
		public cDataField dfPcValidFrom;
		protected cBackgroundText labeldfModule;
		public cDataField dfModule;
		protected cBackgroundText labeldfDefaultValue;
		public cDataField dfDefaultValue;
		protected cBackgroundText labeldfDefaultValueNoCt;
		public cDataField dfDefaultValueNoCt;
		public cDataField dfsCtrlTypeCategoryDb;
		// Bug 73298 Begin - Changed the derived base class.
		// Bug 69757, Begin (Increased max rows in memory to 100000)
        // Bug 75959, Begin, replaced dfPostingType in Default 'Where' to ccPostingType.i_sMyValue
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPostCtrlDet));
            this.menuFrmMethods_menu_Copy_Details_Set_up___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTblMethods_menu_Details_Specification___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.labeldfCompany = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfCompany = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelccPostingType = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.ccPostingType = new Ifs.Fnd.ApplicationForms.cRecSelExtComboBox();
            this.label3 = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.labeldfCodePart = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfCodePart = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsCodeName = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsCodeName = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfControlType = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfControlType = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfPcValidFrom = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfPcValidFrom = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfModule = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfModule = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfDefaultValue = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfDefaultValue = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfDefaultValueNoCt = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfDefaultValueNoCt = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsCtrlTypeCategoryDb = new Ifs.Fnd.ApplicationForms.cDataField();
            this.menuTblMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem__Details = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuFrmMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem__Copy = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.tblPostCtrlDet = new Ifs.Application.Accrul.cChildTableFinBase();
            this.tblPostCtrlDet_colCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPostCtrlDet_colPostingType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPostCtrlDet_colCodePart = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPostCtrlDet_colPcValidFrom = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPostCtrlDet_colControlTypeValue = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPostCtrlDet_colControlTypeValueDesc = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPostCtrlDet_colControlType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPostCtrlDet_colCodePartValue = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPostCtrlDet_colCodePartValueDesc = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPostCtrlDet_colsNoCodePartValue = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.tblPostCtrlDet_colsSpecControlType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPostCtrlDet_colsSpecControlTypeDesc = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPostCtrlDet_colsSpecDefaultValue = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPostCtrlDet_colsSpecDefaultValueNoCt = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPostCtrlDet_colValidFrom = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPostCtrlDet_colModule = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPostCtrlDet_colsSpecModule = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPostCtrlDet_colsSpecCtrlTypeCategory = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.tblPostCtrlDet_colsSpecCtrlTypeCategoryDb = new Ifs.Fnd.ApplicationForms.cColumn();
            this.menuTblMethods.SuspendLayout();
            this.menuFrmMethods.SuspendLayout();
            this.tblPostCtrlDet.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuTblMethods_menu_Details_Specification___);
            this.commandManager.Commands.Add(this.menuFrmMethods_menu_Copy_Details_Set_up___);
            this.commandManager.ContextMenus.Add(this.menuTblMethods);
            this.commandManager.ContextMenus.Add(this.menuFrmMethods);
            // 
            // menuFrmMethods_menu_Copy_Details_Set_up___
            // 
            resources.ApplyResources(this.menuFrmMethods_menu_Copy_Details_Set_up___, "menuFrmMethods_menu_Copy_Details_Set_up___");
            this.menuFrmMethods_menu_Copy_Details_Set_up___.Name = "menuFrmMethods_menu_Copy_Details_Set_up___";
            this.menuFrmMethods_menu_Copy_Details_Set_up___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Copy_Execute);
            this.menuFrmMethods_menu_Copy_Details_Set_up___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Copy_Inquire);
            // 
            // menuTblMethods_menu_Details_Specification___
            // 
            resources.ApplyResources(this.menuTblMethods_menu_Details_Specification___, "menuTblMethods_menu_Details_Specification___");
            this.menuTblMethods_menu_Details_Specification___.Name = "menuTblMethods_menu_Details_Specification___";
            this.menuTblMethods_menu_Details_Specification___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Details_Execute);
            this.menuTblMethods_menu_Details_Specification___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Details_Inquire);
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
            this.ccPostingType.NamedProperties.Put("FieldFlags", "288");
            this.ccPostingType.NamedProperties.Put("LovReference", "POSTING_CTRL_POSTING_TYPE");
            this.ccPostingType.NamedProperties.Put("ResizeableChildObject", "");
            this.ccPostingType.NamedProperties.Put("SqlColumn", "POSTING_TYPE");
            this.ccPostingType.NamedProperties.Put("ValidateMethod", "");
            this.ccPostingType.NamedProperties.Put("XDataLength", "");
            this.ccPostingType.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.ccPostingType_WindowActions);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
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
            this.dfPcValidFrom.NamedProperties.Put("ParentName", "ccPostingType");
            this.dfPcValidFrom.NamedProperties.Put("ResizeableChildObject", "");
            this.dfPcValidFrom.NamedProperties.Put("SqlColumn", "PC_VALID_FROM");
            this.dfPcValidFrom.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfModule
            // 
            resources.ApplyResources(this.labeldfModule, "labeldfModule");
            this.labeldfModule.Name = "labeldfModule";
            // 
            // dfModule
            // 
            resources.ApplyResources(this.dfModule, "dfModule");
            this.dfModule.Name = "dfModule";
            this.dfModule.NamedProperties.Put("FieldFlags", "259");
            this.dfModule.NamedProperties.Put("ParentName", "ccPostingType");
            this.dfModule.NamedProperties.Put("ResizeableChildObject", "");
            this.dfModule.NamedProperties.Put("SqlColumn", "MODULE");
            // 
            // labeldfDefaultValue
            // 
            resources.ApplyResources(this.labeldfDefaultValue, "labeldfDefaultValue");
            this.labeldfDefaultValue.Name = "labeldfDefaultValue";
            // 
            // dfDefaultValue
            // 
            resources.ApplyResources(this.dfDefaultValue, "dfDefaultValue");
            this.dfDefaultValue.Name = "dfDefaultValue";
            this.dfDefaultValue.NamedProperties.Put("EnumerateMethod", "");
            this.dfDefaultValue.NamedProperties.Put("FieldFlags", "288");
            this.dfDefaultValue.NamedProperties.Put("LovReference", "");
            this.dfDefaultValue.NamedProperties.Put("ResizeableChildObject", "");
            this.dfDefaultValue.NamedProperties.Put("SqlColumn", "DEFAULT_VALUE");
            this.dfDefaultValue.NamedProperties.Put("ValidateMethod", "");
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
            // dfsCtrlTypeCategoryDb
            // 
            resources.ApplyResources(this.dfsCtrlTypeCategoryDb, "dfsCtrlTypeCategoryDb");
            this.dfsCtrlTypeCategoryDb.Name = "dfsCtrlTypeCategoryDb";
            this.dfsCtrlTypeCategoryDb.NamedProperties.Put("EnumerateMethod", "");
            this.dfsCtrlTypeCategoryDb.NamedProperties.Put("LovReference", "");
            this.dfsCtrlTypeCategoryDb.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsCtrlTypeCategoryDb.NamedProperties.Put("SqlColumn", "CTRL_TYPE_CATEGORY_DB");
            this.dfsCtrlTypeCategoryDb.NamedProperties.Put("ValidateMethod", "");
            // 
            // menuTblMethods
            // 
            this.menuTblMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem__Details});
            this.menuTblMethods.Name = "menuTblMethods";
            resources.ApplyResources(this.menuTblMethods, "menuTblMethods");
            // 
            // menuItem__Details
            // 
            this.menuItem__Details.Command = this.menuTblMethods_menu_Details_Specification___;
            this.menuItem__Details.Name = "menuItem__Details";
            resources.ApplyResources(this.menuItem__Details, "menuItem__Details");
            this.menuItem__Details.Text = "&Details Specification...";
            // 
            // menuFrmMethods
            // 
            this.menuFrmMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem__Copy});
            this.menuFrmMethods.Name = "menuFrmMethods";
            resources.ApplyResources(this.menuFrmMethods, "menuFrmMethods");
            // 
            // menuItem__Copy
            // 
            this.menuItem__Copy.Command = this.menuFrmMethods_menu_Copy_Details_Set_up___;
            this.menuItem__Copy.Name = "menuItem__Copy";
            resources.ApplyResources(this.menuItem__Copy, "menuItem__Copy");
            this.menuItem__Copy.Text = "&Copy Details Set-up...";
            // 
            // tblPostCtrlDet
            // 
            this.tblPostCtrlDet.Controls.Add(this.tblPostCtrlDet_colCompany);
            this.tblPostCtrlDet.Controls.Add(this.tblPostCtrlDet_colPostingType);
            this.tblPostCtrlDet.Controls.Add(this.tblPostCtrlDet_colCodePart);
            this.tblPostCtrlDet.Controls.Add(this.tblPostCtrlDet_colPcValidFrom);
            this.tblPostCtrlDet.Controls.Add(this.tblPostCtrlDet_colControlTypeValue);
            this.tblPostCtrlDet.Controls.Add(this.tblPostCtrlDet_colControlTypeValueDesc);
            this.tblPostCtrlDet.Controls.Add(this.tblPostCtrlDet_colControlType);
            this.tblPostCtrlDet.Controls.Add(this.tblPostCtrlDet_colCodePartValue);
            this.tblPostCtrlDet.Controls.Add(this.tblPostCtrlDet_colCodePartValueDesc);
            this.tblPostCtrlDet.Controls.Add(this.tblPostCtrlDet_colsNoCodePartValue);
            this.tblPostCtrlDet.Controls.Add(this.tblPostCtrlDet_colsSpecControlType);
            this.tblPostCtrlDet.Controls.Add(this.tblPostCtrlDet_colsSpecControlTypeDesc);
            this.tblPostCtrlDet.Controls.Add(this.tblPostCtrlDet_colsSpecDefaultValue);
            this.tblPostCtrlDet.Controls.Add(this.tblPostCtrlDet_colsSpecDefaultValueNoCt);
            this.tblPostCtrlDet.Controls.Add(this.tblPostCtrlDet_colValidFrom);
            this.tblPostCtrlDet.Controls.Add(this.tblPostCtrlDet_colModule);
            this.tblPostCtrlDet.Controls.Add(this.tblPostCtrlDet_colsSpecModule);
            this.tblPostCtrlDet.Controls.Add(this.tblPostCtrlDet_colsSpecCtrlTypeCategory);
            this.tblPostCtrlDet.Controls.Add(this.tblPostCtrlDet_colsSpecCtrlTypeCategoryDb);
            resources.ApplyResources(this.tblPostCtrlDet, "tblPostCtrlDet");
            this.tblPostCtrlDet.Name = "tblPostCtrlDet";
            this.tblPostCtrlDet.NamedProperties.Put("DefaultOrderBy", "");
            this.tblPostCtrlDet.NamedProperties.Put("DefaultWhere", "POSTING_TYPE = :i_hWndFrame.frmPostCtrlDet.ccPostingType.i_sMyValue AND\r\nCODE_PAR" +
                    "T = :i_hWndFrame.frmPostCtrlDet.dfCodePart AND\r\nPC_VALID_FROM = :i_hWndFrame.frm" +
                    "PostCtrlDet.dfPcValidFrom");
            this.tblPostCtrlDet.NamedProperties.Put("LogicalUnit", "PostingCtrlDetail");
            this.tblPostCtrlDet.NamedProperties.Put("PackageName", "POSTING_CTRL_DETAIL_API");
            this.tblPostCtrlDet.NamedProperties.Put("ResizeableChildObject", "LLFF");
            this.tblPostCtrlDet.NamedProperties.Put("ViewName", "POSTING_CTRL_DETAIL");
            this.tblPostCtrlDet.NamedProperties.Put("Warnings", "FALSE");
            this.tblPostCtrlDet.DataSourceFormatSqlColumnUserEvent += new System.EventHandler<Ifs.Fnd.ApplicationForms.FndReturnEventArgsSalString>(this.tblPostCtrlDet_DataSourceFormatSqlColumnUserEvent);
            this.tblPostCtrlDet.DataSourceFormatSqlIntoUserEvent += new System.EventHandler<Ifs.Fnd.ApplicationForms.FndReturnEventArgsSalString>(this.tblPostCtrlDet_DataSourceFormatSqlIntoUserEvent);
            this.tblPostCtrlDet.DataRecordGetDefaultsEvent += new System.EventHandler<Ifs.Fnd.ApplicationForms.FndReturnEventArgsSalBoolean>(this.tblPostCtrlDet_DataRecordGetDefaultsEvent);
            this.tblPostCtrlDet.DataRecordPrepareNewEvent += new System.EventHandler<Ifs.Fnd.ApplicationForms.FndReturnEventArgsSalBoolean>(this.tblPostCtrlDet_DataRecordPrepareNewEvent);
            this.tblPostCtrlDet.DataSourcePopulateItEvent += new Ifs.Fnd.ApplicationForms.cDataSource.DataSourcePopulateItEventHandler(this.tblPostCtrlDet_DataSourcePopulateItEvent);
            this.tblPostCtrlDet.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblPostCtrlDet_WindowActions);
            this.tblPostCtrlDet.Controls.SetChildIndex(this.tblPostCtrlDet_colsSpecCtrlTypeCategoryDb, 0);
            this.tblPostCtrlDet.Controls.SetChildIndex(this.tblPostCtrlDet_colsSpecCtrlTypeCategory, 0);
            this.tblPostCtrlDet.Controls.SetChildIndex(this.tblPostCtrlDet_colsSpecModule, 0);
            this.tblPostCtrlDet.Controls.SetChildIndex(this.tblPostCtrlDet_colModule, 0);
            this.tblPostCtrlDet.Controls.SetChildIndex(this.tblPostCtrlDet_colValidFrom, 0);
            this.tblPostCtrlDet.Controls.SetChildIndex(this.tblPostCtrlDet_colsSpecDefaultValueNoCt, 0);
            this.tblPostCtrlDet.Controls.SetChildIndex(this.tblPostCtrlDet_colsSpecDefaultValue, 0);
            this.tblPostCtrlDet.Controls.SetChildIndex(this.tblPostCtrlDet_colsSpecControlTypeDesc, 0);
            this.tblPostCtrlDet.Controls.SetChildIndex(this.tblPostCtrlDet_colsSpecControlType, 0);
            this.tblPostCtrlDet.Controls.SetChildIndex(this.tblPostCtrlDet_colsNoCodePartValue, 0);
            this.tblPostCtrlDet.Controls.SetChildIndex(this.tblPostCtrlDet_colCodePartValueDesc, 0);
            this.tblPostCtrlDet.Controls.SetChildIndex(this.tblPostCtrlDet_colCodePartValue, 0);
            this.tblPostCtrlDet.Controls.SetChildIndex(this.tblPostCtrlDet_colControlType, 0);
            this.tblPostCtrlDet.Controls.SetChildIndex(this.tblPostCtrlDet_colControlTypeValueDesc, 0);
            this.tblPostCtrlDet.Controls.SetChildIndex(this.tblPostCtrlDet_colControlTypeValue, 0);
            this.tblPostCtrlDet.Controls.SetChildIndex(this.tblPostCtrlDet_colPcValidFrom, 0);
            this.tblPostCtrlDet.Controls.SetChildIndex(this.tblPostCtrlDet_colCodePart, 0);
            this.tblPostCtrlDet.Controls.SetChildIndex(this.tblPostCtrlDet_colPostingType, 0);
            this.tblPostCtrlDet.Controls.SetChildIndex(this.tblPostCtrlDet_colCompany, 0);
            // 
            // tblPostCtrlDet_colCompany
            // 
            this.tblPostCtrlDet_colCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblPostCtrlDet_colCompany, "tblPostCtrlDet_colCompany");
            this.tblPostCtrlDet_colCompany.MaxLength = 20;
            this.tblPostCtrlDet_colCompany.Name = "tblPostCtrlDet_colCompany";
            this.tblPostCtrlDet_colCompany.NamedProperties.Put("EnumerateMethod", "");
            this.tblPostCtrlDet_colCompany.NamedProperties.Put("FieldFlags", "67");
            this.tblPostCtrlDet_colCompany.NamedProperties.Put("LovReference", "");
            this.tblPostCtrlDet_colCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPostCtrlDet_colCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.tblPostCtrlDet_colCompany.NamedProperties.Put("ValidateMethod", "");
            this.tblPostCtrlDet_colCompany.Position = 3;
            // 
            // tblPostCtrlDet_colPostingType
            // 
            this.tblPostCtrlDet_colPostingType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblPostCtrlDet_colPostingType, "tblPostCtrlDet_colPostingType");
            this.tblPostCtrlDet_colPostingType.MaxLength = 10;
            this.tblPostCtrlDet_colPostingType.Name = "tblPostCtrlDet_colPostingType";
            this.tblPostCtrlDet_colPostingType.NamedProperties.Put("EnumerateMethod", "");
            this.tblPostCtrlDet_colPostingType.NamedProperties.Put("FieldFlags", "67");
            this.tblPostCtrlDet_colPostingType.NamedProperties.Put("LovReference", "");
            this.tblPostCtrlDet_colPostingType.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPostCtrlDet_colPostingType.NamedProperties.Put("SqlColumn", "POSTING_TYPE");
            this.tblPostCtrlDet_colPostingType.NamedProperties.Put("ValidateMethod", "");
            this.tblPostCtrlDet_colPostingType.Position = 4;
            // 
            // tblPostCtrlDet_colCodePart
            // 
            this.tblPostCtrlDet_colCodePart.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblPostCtrlDet_colCodePart, "tblPostCtrlDet_colCodePart");
            this.tblPostCtrlDet_colCodePart.MaxLength = 1;
            this.tblPostCtrlDet_colCodePart.Name = "tblPostCtrlDet_colCodePart";
            this.tblPostCtrlDet_colCodePart.NamedProperties.Put("EnumerateMethod", "");
            this.tblPostCtrlDet_colCodePart.NamedProperties.Put("FieldFlags", "67");
            this.tblPostCtrlDet_colCodePart.NamedProperties.Put("LovReference", "");
            this.tblPostCtrlDet_colCodePart.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPostCtrlDet_colCodePart.NamedProperties.Put("SqlColumn", "CODE_PART");
            this.tblPostCtrlDet_colCodePart.NamedProperties.Put("ValidateMethod", "");
            this.tblPostCtrlDet_colCodePart.Position = 5;
            // 
            // tblPostCtrlDet_colPcValidFrom
            // 
            this.tblPostCtrlDet_colPcValidFrom.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            resources.ApplyResources(this.tblPostCtrlDet_colPcValidFrom, "tblPostCtrlDet_colPcValidFrom");
            this.tblPostCtrlDet_colPcValidFrom.Format = "d";
            this.tblPostCtrlDet_colPcValidFrom.Name = "tblPostCtrlDet_colPcValidFrom";
            this.tblPostCtrlDet_colPcValidFrom.NamedProperties.Put("EnumerateMethod", "");
            this.tblPostCtrlDet_colPcValidFrom.NamedProperties.Put("FieldFlags", "99");
            this.tblPostCtrlDet_colPcValidFrom.NamedProperties.Put("LovReference", "");
            this.tblPostCtrlDet_colPcValidFrom.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPostCtrlDet_colPcValidFrom.NamedProperties.Put("SqlColumn", "PC_VALID_FROM");
            this.tblPostCtrlDet_colPcValidFrom.NamedProperties.Put("ValidateMethod", "");
            this.tblPostCtrlDet_colPcValidFrom.Position = 6;
            // 
            // tblPostCtrlDet_colControlTypeValue
            // 
            this.tblPostCtrlDet_colControlTypeValue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblPostCtrlDet_colControlTypeValue.Name = "tblPostCtrlDet_colControlTypeValue";
            this.tblPostCtrlDet_colControlTypeValue.NamedProperties.Put("EnumerateMethod", "");
            this.tblPostCtrlDet_colControlTypeValue.NamedProperties.Put("FieldFlags", "163");
            this.tblPostCtrlDet_colControlTypeValue.NamedProperties.Put("LovReference", "");
            this.tblPostCtrlDet_colControlTypeValue.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPostCtrlDet_colControlTypeValue.NamedProperties.Put("SqlColumn", "CONTROL_TYPE_VALUE");
            this.tblPostCtrlDet_colControlTypeValue.NamedProperties.Put("ValidateMethod", "");
            this.tblPostCtrlDet_colControlTypeValue.Position = 7;
            resources.ApplyResources(this.tblPostCtrlDet_colControlTypeValue, "tblPostCtrlDet_colControlTypeValue");
            this.tblPostCtrlDet_colControlTypeValue.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblPostCtrlDet_colControlTypeValue_WindowActions);
            // 
            // tblPostCtrlDet_colControlTypeValueDesc
            // 
            resources.ApplyResources(this.tblPostCtrlDet_colControlTypeValueDesc, "tblPostCtrlDet_colControlTypeValueDesc");
            this.tblPostCtrlDet_colControlTypeValueDesc.MaxLength = 2000;
            this.tblPostCtrlDet_colControlTypeValueDesc.Name = "tblPostCtrlDet_colControlTypeValueDesc";
            this.tblPostCtrlDet_colControlTypeValueDesc.NamedProperties.Put("EnumerateMethod", "");
            this.tblPostCtrlDet_colControlTypeValueDesc.NamedProperties.Put("LovReference", "");
            this.tblPostCtrlDet_colControlTypeValueDesc.NamedProperties.Put("ParentName", "tblPostCtrlDet.tblPostCtrlDet_colControlTypeValue");
            this.tblPostCtrlDet_colControlTypeValueDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPostCtrlDet_colControlTypeValueDesc.NamedProperties.Put("SqlColumn", "");
            this.tblPostCtrlDet_colControlTypeValueDesc.NamedProperties.Put("ValidateMethod", "");
            this.tblPostCtrlDet_colControlTypeValueDesc.Position = 8;
            // 
            // tblPostCtrlDet_colControlType
            // 
            this.tblPostCtrlDet_colControlType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblPostCtrlDet_colControlType, "tblPostCtrlDet_colControlType");
            this.tblPostCtrlDet_colControlType.MaxLength = 10;
            this.tblPostCtrlDet_colControlType.Name = "tblPostCtrlDet_colControlType";
            this.tblPostCtrlDet_colControlType.NamedProperties.Put("EnumerateMethod", "");
            this.tblPostCtrlDet_colControlType.NamedProperties.Put("FieldFlags", "259");
            this.tblPostCtrlDet_colControlType.NamedProperties.Put("LovReference", "");
            this.tblPostCtrlDet_colControlType.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPostCtrlDet_colControlType.NamedProperties.Put("SqlColumn", "CONTROL_TYPE");
            this.tblPostCtrlDet_colControlType.NamedProperties.Put("ValidateMethod", "");
            this.tblPostCtrlDet_colControlType.Position = 9;
            // 
            // tblPostCtrlDet_colCodePartValue
            // 
            this.tblPostCtrlDet_colCodePartValue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblPostCtrlDet_colCodePartValue.MaxLength = 20;
            this.tblPostCtrlDet_colCodePartValue.Name = "tblPostCtrlDet_colCodePartValue";
            this.tblPostCtrlDet_colCodePartValue.NamedProperties.Put("EnumerateMethod", "");
            this.tblPostCtrlDet_colCodePartValue.NamedProperties.Put("FieldFlags", "294");
            this.tblPostCtrlDet_colCodePartValue.NamedProperties.Put("LovReference", "ACCOUNTING_CODE_PART_VALUE_LOV(COMPANY,CODE_PART)");
            this.tblPostCtrlDet_colCodePartValue.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPostCtrlDet_colCodePartValue.NamedProperties.Put("SqlColumn", "CODE_PART_VALUE");
            this.tblPostCtrlDet_colCodePartValue.NamedProperties.Put("ValidateMethod", "");
            this.tblPostCtrlDet_colCodePartValue.Position = 10;
            resources.ApplyResources(this.tblPostCtrlDet_colCodePartValue, "tblPostCtrlDet_colCodePartValue");
            this.tblPostCtrlDet_colCodePartValue.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblPostCtrlDet_colCodePartValue_WindowActions);
            // 
            // tblPostCtrlDet_colCodePartValueDesc
            // 
            resources.ApplyResources(this.tblPostCtrlDet_colCodePartValueDesc, "tblPostCtrlDet_colCodePartValueDesc");
            this.tblPostCtrlDet_colCodePartValueDesc.Name = "tblPostCtrlDet_colCodePartValueDesc";
            this.tblPostCtrlDet_colCodePartValueDesc.NamedProperties.Put("EnumerateMethod", "");
            this.tblPostCtrlDet_colCodePartValueDesc.NamedProperties.Put("FieldFlags", "288");
            this.tblPostCtrlDet_colCodePartValueDesc.NamedProperties.Put("LovReference", "");
            this.tblPostCtrlDet_colCodePartValueDesc.NamedProperties.Put("ParentName", "tblPostCtrlDet.tblPostCtrlDet_colCodePartValue");
            this.tblPostCtrlDet_colCodePartValueDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPostCtrlDet_colCodePartValueDesc.NamedProperties.Put("SqlColumn", "Accounting_Code_Part_Value_API.Get_Description(COMPANY,CODE_PART,CODE_PART_VALUE)" +
                    "");
            this.tblPostCtrlDet_colCodePartValueDesc.NamedProperties.Put("ValidateMethod", "");
            this.tblPostCtrlDet_colCodePartValueDesc.Position = 11;
            // 
            // tblPostCtrlDet_colsNoCodePartValue
            // 
            this.tblPostCtrlDet_colsNoCodePartValue.CellType = PPJ.Runtime.Windows.CellType.CheckBox;
            this.tblPostCtrlDet_colsNoCodePartValue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblPostCtrlDet_colsNoCodePartValue.CheckBox.CheckedValue = "TRUE";
            this.tblPostCtrlDet_colsNoCodePartValue.CheckBox.IgnoreCase = true;
            this.tblPostCtrlDet_colsNoCodePartValue.CheckBox.UncheckedValue = "FALSE";
            this.tblPostCtrlDet_colsNoCodePartValue.MaxLength = 5;
            this.tblPostCtrlDet_colsNoCodePartValue.Name = "tblPostCtrlDet_colsNoCodePartValue";
            this.tblPostCtrlDet_colsNoCodePartValue.NamedProperties.Put("EnumerateMethod", "");
            this.tblPostCtrlDet_colsNoCodePartValue.NamedProperties.Put("FieldFlags", "295");
            this.tblPostCtrlDet_colsNoCodePartValue.NamedProperties.Put("LovReference", "");
            this.tblPostCtrlDet_colsNoCodePartValue.NamedProperties.Put("SqlColumn", "NO_CODE_PART_VALUE_DB");
            this.tblPostCtrlDet_colsNoCodePartValue.Position = 12;
            resources.ApplyResources(this.tblPostCtrlDet_colsNoCodePartValue, "tblPostCtrlDet_colsNoCodePartValue");
            // 
            // tblPostCtrlDet_colsSpecControlType
            // 
            this.tblPostCtrlDet_colsSpecControlType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblPostCtrlDet_colsSpecControlType.MaxLength = 10;
            this.tblPostCtrlDet_colsSpecControlType.Name = "tblPostCtrlDet_colsSpecControlType";
            this.tblPostCtrlDet_colsSpecControlType.NamedProperties.Put("EnumerateMethod", "");
            this.tblPostCtrlDet_colsSpecControlType.NamedProperties.Put("FieldFlags", "298");
            this.tblPostCtrlDet_colsSpecControlType.NamedProperties.Put("LovReference", "CTRL_TYPE_ALLOWED_VALUE(COMPANY,POSTING_TYPE,CODE_PART)");
            this.tblPostCtrlDet_colsSpecControlType.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPostCtrlDet_colsSpecControlType.NamedProperties.Put("SqlColumn", "SPEC_CONTROL_TYPE");
            this.tblPostCtrlDet_colsSpecControlType.NamedProperties.Put("ValidateMethod", "");
            this.tblPostCtrlDet_colsSpecControlType.Position = 13;
            resources.ApplyResources(this.tblPostCtrlDet_colsSpecControlType, "tblPostCtrlDet_colsSpecControlType");
            this.tblPostCtrlDet_colsSpecControlType.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblPostCtrlDet_colsSpecControlType_WindowActions);
            // 
            // tblPostCtrlDet_colsSpecControlTypeDesc
            // 
            resources.ApplyResources(this.tblPostCtrlDet_colsSpecControlTypeDesc, "tblPostCtrlDet_colsSpecControlTypeDesc");
            this.tblPostCtrlDet_colsSpecControlTypeDesc.Name = "tblPostCtrlDet_colsSpecControlTypeDesc";
            this.tblPostCtrlDet_colsSpecControlTypeDesc.NamedProperties.Put("EnumerateMethod", "");
            this.tblPostCtrlDet_colsSpecControlTypeDesc.NamedProperties.Put("FieldFlags", "288");
            this.tblPostCtrlDet_colsSpecControlTypeDesc.NamedProperties.Put("LovReference", "");
            this.tblPostCtrlDet_colsSpecControlTypeDesc.NamedProperties.Put("SqlColumn", "SPEC_CONTROL_TYPE_DESC");
            this.tblPostCtrlDet_colsSpecControlTypeDesc.Position = 14;
            // 
            // tblPostCtrlDet_colsSpecDefaultValue
            // 
            this.tblPostCtrlDet_colsSpecDefaultValue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblPostCtrlDet_colsSpecDefaultValue.MaxLength = 20;
            this.tblPostCtrlDet_colsSpecDefaultValue.Name = "tblPostCtrlDet_colsSpecDefaultValue";
            this.tblPostCtrlDet_colsSpecDefaultValue.NamedProperties.Put("EnumerateMethod", "");
            this.tblPostCtrlDet_colsSpecDefaultValue.NamedProperties.Put("FieldFlags", "294");
            this.tblPostCtrlDet_colsSpecDefaultValue.NamedProperties.Put("LovReference", "ACCOUNTING_CODE_PART_VALUE_LOV(COMPANY,CODE_PART)");
            this.tblPostCtrlDet_colsSpecDefaultValue.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPostCtrlDet_colsSpecDefaultValue.NamedProperties.Put("SqlColumn", "SPEC_DEFAULT_VALUE");
            this.tblPostCtrlDet_colsSpecDefaultValue.NamedProperties.Put("ValidateMethod", "");
            this.tblPostCtrlDet_colsSpecDefaultValue.Position = 15;
            resources.ApplyResources(this.tblPostCtrlDet_colsSpecDefaultValue, "tblPostCtrlDet_colsSpecDefaultValue");
            this.tblPostCtrlDet_colsSpecDefaultValue.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblPostCtrlDet_colsSpecDefaultValue_WindowActions);
            // 
            // tblPostCtrlDet_colsSpecDefaultValueNoCt
            // 
            this.tblPostCtrlDet_colsSpecDefaultValueNoCt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblPostCtrlDet_colsSpecDefaultValueNoCt.MaxLength = 20;
            this.tblPostCtrlDet_colsSpecDefaultValueNoCt.Name = "tblPostCtrlDet_colsSpecDefaultValueNoCt";
            this.tblPostCtrlDet_colsSpecDefaultValueNoCt.NamedProperties.Put("EnumerateMethod", "");
            this.tblPostCtrlDet_colsSpecDefaultValueNoCt.NamedProperties.Put("FieldFlags", "294");
            this.tblPostCtrlDet_colsSpecDefaultValueNoCt.NamedProperties.Put("LovReference", "ACCOUNTING_CODE_PART_VALUE_LOV(COMPANY,CODE_PART)");
            this.tblPostCtrlDet_colsSpecDefaultValueNoCt.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPostCtrlDet_colsSpecDefaultValueNoCt.NamedProperties.Put("SqlColumn", "SPEC_DEFAULT_VALUE_NO_CT");
            this.tblPostCtrlDet_colsSpecDefaultValueNoCt.NamedProperties.Put("ValidateMethod", "");
            this.tblPostCtrlDet_colsSpecDefaultValueNoCt.Position = 16;
            resources.ApplyResources(this.tblPostCtrlDet_colsSpecDefaultValueNoCt, "tblPostCtrlDet_colsSpecDefaultValueNoCt");
            this.tblPostCtrlDet_colsSpecDefaultValueNoCt.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblPostCtrlDet_colsSpecDefaultValueNoCt_WindowActions);
            // 
            // tblPostCtrlDet_colValidFrom
            // 
            this.tblPostCtrlDet_colValidFrom.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.tblPostCtrlDet_colValidFrom.Format = "d";
            this.tblPostCtrlDet_colValidFrom.Name = "tblPostCtrlDet_colValidFrom";
            this.tblPostCtrlDet_colValidFrom.NamedProperties.Put("EnumerateMethod", "");
            this.tblPostCtrlDet_colValidFrom.NamedProperties.Put("FieldFlags", "163");
            this.tblPostCtrlDet_colValidFrom.NamedProperties.Put("LovReference", "");
            this.tblPostCtrlDet_colValidFrom.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPostCtrlDet_colValidFrom.NamedProperties.Put("SqlColumn", "VALID_FROM");
            this.tblPostCtrlDet_colValidFrom.NamedProperties.Put("ValidateMethod", "");
            this.tblPostCtrlDet_colValidFrom.Position = 17;
            resources.ApplyResources(this.tblPostCtrlDet_colValidFrom, "tblPostCtrlDet_colValidFrom");
            // 
            // tblPostCtrlDet_colModule
            // 
            resources.ApplyResources(this.tblPostCtrlDet_colModule, "tblPostCtrlDet_colModule");
            this.tblPostCtrlDet_colModule.MaxLength = 20;
            this.tblPostCtrlDet_colModule.Name = "tblPostCtrlDet_colModule";
            this.tblPostCtrlDet_colModule.NamedProperties.Put("EnumerateMethod", "");
            this.tblPostCtrlDet_colModule.NamedProperties.Put("FieldFlags", "259");
            this.tblPostCtrlDet_colModule.NamedProperties.Put("LovReference", "");
            this.tblPostCtrlDet_colModule.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPostCtrlDet_colModule.NamedProperties.Put("SqlColumn", "MODULE");
            this.tblPostCtrlDet_colModule.NamedProperties.Put("ValidateMethod", "");
            this.tblPostCtrlDet_colModule.Position = 18;
            // 
            // tblPostCtrlDet_colsSpecModule
            // 
            this.tblPostCtrlDet_colsSpecModule.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblPostCtrlDet_colsSpecModule, "tblPostCtrlDet_colsSpecModule");
            this.tblPostCtrlDet_colsSpecModule.MaxLength = 20;
            this.tblPostCtrlDet_colsSpecModule.Name = "tblPostCtrlDet_colsSpecModule";
            this.tblPostCtrlDet_colsSpecModule.NamedProperties.Put("EnumerateMethod", "");
            this.tblPostCtrlDet_colsSpecModule.NamedProperties.Put("FieldFlags", "294");
            this.tblPostCtrlDet_colsSpecModule.NamedProperties.Put("LovReference", "");
            this.tblPostCtrlDet_colsSpecModule.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPostCtrlDet_colsSpecModule.NamedProperties.Put("SqlColumn", "SPEC_MODULE");
            this.tblPostCtrlDet_colsSpecModule.NamedProperties.Put("ValidateMethod", "");
            this.tblPostCtrlDet_colsSpecModule.Position = 19;
            // 
            // tblPostCtrlDet_colsSpecCtrlTypeCategory
            // 
            resources.ApplyResources(this.tblPostCtrlDet_colsSpecCtrlTypeCategory, "tblPostCtrlDet_colsSpecCtrlTypeCategory");
            this.tblPostCtrlDet_colsSpecCtrlTypeCategory.MaxLength = 50;
            this.tblPostCtrlDet_colsSpecCtrlTypeCategory.Name = "tblPostCtrlDet_colsSpecCtrlTypeCategory";
            this.tblPostCtrlDet_colsSpecCtrlTypeCategory.NamedProperties.Put("EnumerateMethod", "CTRL_TYPE_CATEGORY_API.Enumerate");
            this.tblPostCtrlDet_colsSpecCtrlTypeCategory.NamedProperties.Put("FieldFlags", "262");
            this.tblPostCtrlDet_colsSpecCtrlTypeCategory.NamedProperties.Put("LovReference", "");
            this.tblPostCtrlDet_colsSpecCtrlTypeCategory.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPostCtrlDet_colsSpecCtrlTypeCategory.NamedProperties.Put("SqlColumn", "SPEC_CTRL_TYPE_CATEGORY");
            this.tblPostCtrlDet_colsSpecCtrlTypeCategory.NamedProperties.Put("ValidateMethod", "");
            this.tblPostCtrlDet_colsSpecCtrlTypeCategory.Position = 20;
            // 
            // tblPostCtrlDet_colsSpecCtrlTypeCategoryDb
            // 
            resources.ApplyResources(this.tblPostCtrlDet_colsSpecCtrlTypeCategoryDb, "tblPostCtrlDet_colsSpecCtrlTypeCategoryDb");
            this.tblPostCtrlDet_colsSpecCtrlTypeCategoryDb.MaxLength = 20;
            this.tblPostCtrlDet_colsSpecCtrlTypeCategoryDb.Name = "tblPostCtrlDet_colsSpecCtrlTypeCategoryDb";
            this.tblPostCtrlDet_colsSpecCtrlTypeCategoryDb.NamedProperties.Put("EnumerateMethod", "");
            this.tblPostCtrlDet_colsSpecCtrlTypeCategoryDb.NamedProperties.Put("LovReference", "");
            this.tblPostCtrlDet_colsSpecCtrlTypeCategoryDb.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPostCtrlDet_colsSpecCtrlTypeCategoryDb.NamedProperties.Put("SqlColumn", "SPEC_CTRL_TYPE_CATEGORY_DB");
            this.tblPostCtrlDet_colsSpecCtrlTypeCategoryDb.NamedProperties.Put("ValidateMethod", "");
            this.tblPostCtrlDet_colsSpecCtrlTypeCategoryDb.Position = 21;
            // 
            // frmPostCtrlDet
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.tblPostCtrlDet);
            this.Controls.Add(this.dfDefaultValueNoCt);
            this.Controls.Add(this.dfDefaultValue);
            this.Controls.Add(this.dfsCtrlTypeCategoryDb);
            this.Controls.Add(this.dfModule);
            this.Controls.Add(this.dfPcValidFrom);
            this.Controls.Add(this.dfControlType);
            this.Controls.Add(this.dfsCodeName);
            this.Controls.Add(this.dfCodePart);
            this.Controls.Add(this.ccPostingType);
            this.Controls.Add(this.dfCompany);
            this.Controls.Add(this.labeldfDefaultValueNoCt);
            this.Controls.Add(this.labeldfDefaultValue);
            this.Controls.Add(this.labeldfModule);
            this.Controls.Add(this.labeldfPcValidFrom);
            this.Controls.Add(this.labeldfControlType);
            this.Controls.Add(this.labeldfsCodeName);
            this.Controls.Add(this.labeldfCodePart);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelccPostingType);
            this.Controls.Add(this.labeldfCompany);
            this.MaximizeBox = true;
            this.Name = "frmPostCtrlDet";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "COMPANY = :global.company AND \r\nCTRL_TYPE_CATEGORY_DB != \'COMBINATION\'");
            this.NamedProperties.Put("LogicalUnit", "PostingCtrl");
            this.NamedProperties.Put("PackageName", "POSTING_CTRL_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "0");
            this.NamedProperties.Put("SourceFlags", "448");
            this.NamedProperties.Put("ViewName", "POSTING_CTRL_MASTER");
            this.NamedProperties.Put("Warnings", "TRUE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.frmPostCtrlDet_WindowActions);
            this.menuTblMethods.ResumeLayout(false);
            this.menuFrmMethods.ResumeLayout(false);
            this.tblPostCtrlDet.ResumeLayout(false);
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
		
        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menu_Copy_Details_Set_up___;
        public Fnd.Windows.Forms.FndCommand menuTblMethods_menu_Details_Specification___;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTblMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Details;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuFrmMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Copy;
        public cChildTableFinBase tblPostCtrlDet;
        protected cColumn tblPostCtrlDet_colCompany;
        protected cColumn tblPostCtrlDet_colPostingType;
        protected cColumn tblPostCtrlDet_colCodePart;
        protected cColumn tblPostCtrlDet_colPcValidFrom;
        protected cColumn tblPostCtrlDet_colControlTypeValue;
        protected cColumn tblPostCtrlDet_colControlTypeValueDesc;
        protected cColumn tblPostCtrlDet_colControlType;
        protected cColumn tblPostCtrlDet_colCodePartValue;
        protected cColumn tblPostCtrlDet_colCodePartValueDesc;
        protected cLookupColumn tblPostCtrlDet_colsNoCodePartValue;
        protected cColumn tblPostCtrlDet_colsSpecControlType;
        protected cColumn tblPostCtrlDet_colsSpecControlTypeDesc;
        protected cColumn tblPostCtrlDet_colsSpecDefaultValue;
        protected cColumn tblPostCtrlDet_colsSpecDefaultValueNoCt;
        protected cColumn tblPostCtrlDet_colValidFrom;
        protected cColumn tblPostCtrlDet_colModule;
        protected cColumn tblPostCtrlDet_colsSpecModule;
        protected cLookupColumn tblPostCtrlDet_colsSpecCtrlTypeCategory;
        protected cColumn tblPostCtrlDet_colsSpecCtrlTypeCategoryDb;
	}
}
