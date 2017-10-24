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
	
	public partial class tbwPostingCtrl
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		// ----------------------------------------------Hidden Fields--------------------------------------------
		public cColumn colsCompany;
		public cColumn colsCombControlType;
		public cColumn colModule;
		public cColumn colsCodePart;
		public cColumn colsCtrlTypeCategoryDb;
		public cLookupColumn colsCtrlTypeCategory;
		// ----------------------------------------------------------------------------------------------------------------
		// Bug 67620, Begin, Set as Primary Key in F1 Properties.
		public cColumn colPostingType;
		// Bug 67620, End
		public cColumn colPostingTypeDesc;
		public cColumn colsCodeName;
		public cColumn colControlType;
		public cColumn colControlTypeDesc;
		public cColumn colDefaultValue;
		public cColumn colDefaultValueNoCt;
		public cLookupColumn colOverride;
		// Bug 67620, Begin, Set as Not Editable in F1 Properties
		public cColumn coldPcValidFrom;
		// Bug 67620, End
		public cColumn colPostModule;
		public cColumn colsExistCombInDetail;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwPostingCtrl));
            this.menuTbwMethods_menu_Details___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_menu_Copy_Details_Set_up___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_menuChange__Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.colsCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsCombControlType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colModule = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsCodePart = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsCtrlTypeCategoryDb = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsCtrlTypeCategory = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.colPostingType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colPostingTypeDesc = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsCodeName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colControlType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colControlTypeDesc = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colDefaultValue = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colDefaultValueNoCt = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colOverride = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.coldPcValidFrom = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colPostModule = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsExistCombInDetail = new Ifs.Fnd.ApplicationForms.cColumn();
            this.menuTbwMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem__Details = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem__Copy = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuSeparator1 = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.menuItem_Change = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuTbwMethods.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuTbwMethods_menu_Details___);
            this.commandManager.Commands.Add(this.menuTbwMethods_menu_Copy_Details_Set_up___);
            this.commandManager.Commands.Add(this.menuTbwMethods_menuChange__Company___);
            this.commandManager.ContextMenus.Add(this.menuTbwMethods);
            this.commandManager.ImageList = null;
            // 
            // menuTbwMethods_menu_Details___
            // 
            resources.ApplyResources(this.menuTbwMethods_menu_Details___, "menuTbwMethods_menu_Details___");
            this.menuTbwMethods_menu_Details___.Name = "menuTbwMethods_menu_Details___";
            this.menuTbwMethods_menu_Details___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Details_Execute);
            this.menuTbwMethods_menu_Details___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Details_Inquire);
            // 
            // menuTbwMethods_menu_Copy_Details_Set_up___
            // 
            resources.ApplyResources(this.menuTbwMethods_menu_Copy_Details_Set_up___, "menuTbwMethods_menu_Copy_Details_Set_up___");
            this.menuTbwMethods_menu_Copy_Details_Set_up___.Name = "menuTbwMethods_menu_Copy_Details_Set_up___";
            this.menuTbwMethods_menu_Copy_Details_Set_up___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Copy_Execute);
            this.menuTbwMethods_menu_Copy_Details_Set_up___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Copy_Inquire);
            // 
            // menuTbwMethods_menuChange__Company___
            // 
            resources.ApplyResources(this.menuTbwMethods_menuChange__Company___, "menuTbwMethods_menuChange__Company___");
            this.menuTbwMethods_menuChange__Company___.Name = "menuTbwMethods_menuChange__Company___";
            this.menuTbwMethods_menuChange__Company___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Change_Execute);
            this.menuTbwMethods_menuChange__Company___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Change_Inquire);
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
            this.colsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.colsCompany.Position = 3;
            // 
            // colsCombControlType
            // 
            resources.ApplyResources(this.colsCombControlType, "colsCombControlType");
            this.colsCombControlType.Name = "colsCombControlType";
            this.colsCombControlType.Position = 4;
            // 
            // colModule
            // 
            resources.ApplyResources(this.colModule, "colModule");
            this.colModule.MaxLength = 20;
            this.colModule.Name = "colModule";
            this.colModule.NamedProperties.Put("EnumerateMethod", "");
            this.colModule.NamedProperties.Put("FieldFlags", "258");
            this.colModule.NamedProperties.Put("LovReference", "");
            this.colModule.NamedProperties.Put("ResizeableChildObject", "");
            this.colModule.NamedProperties.Put("SqlColumn", "MODULE");
            this.colModule.NamedProperties.Put("ValidateMethod", "");
            this.colModule.Position = 5;
            // 
            // colsCodePart
            // 
            this.colsCodePart.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.colsCodePart, "colsCodePart");
            this.colsCodePart.MaxLength = 1;
            this.colsCodePart.Name = "colsCodePart";
            this.colsCodePart.NamedProperties.Put("EnumerateMethod", "");
            this.colsCodePart.NamedProperties.Put("FieldFlags", "66");
            this.colsCodePart.NamedProperties.Put("LovReference", "");
            this.colsCodePart.NamedProperties.Put("ResizeableChildObject", "");
            this.colsCodePart.NamedProperties.Put("SqlColumn", "CODE_PART");
            this.colsCodePart.NamedProperties.Put("ValidateMethod", "");
            this.colsCodePart.Position = 6;
            // 
            // colsCtrlTypeCategoryDb
            // 
            resources.ApplyResources(this.colsCtrlTypeCategoryDb, "colsCtrlTypeCategoryDb");
            this.colsCtrlTypeCategoryDb.MaxLength = 20;
            this.colsCtrlTypeCategoryDb.Name = "colsCtrlTypeCategoryDb";
            this.colsCtrlTypeCategoryDb.NamedProperties.Put("EnumerateMethod", "");
            this.colsCtrlTypeCategoryDb.NamedProperties.Put("LovReference", "");
            this.colsCtrlTypeCategoryDb.NamedProperties.Put("ResizeableChildObject", "");
            this.colsCtrlTypeCategoryDb.NamedProperties.Put("SqlColumn", "CTRL_TYPE_CATEGORY_DB");
            this.colsCtrlTypeCategoryDb.NamedProperties.Put("ValidateMethod", "");
            this.colsCtrlTypeCategoryDb.Position = 7;
            // 
            // colsCtrlTypeCategory
            // 
            resources.ApplyResources(this.colsCtrlTypeCategory, "colsCtrlTypeCategory");
            this.colsCtrlTypeCategory.MaxLength = 50;
            this.colsCtrlTypeCategory.Name = "colsCtrlTypeCategory";
            this.colsCtrlTypeCategory.NamedProperties.Put("EnumerateMethod", "CTRL_TYPE_CATEGORY_API.Enumerate");
            this.colsCtrlTypeCategory.NamedProperties.Put("FieldFlags", "262");
            this.colsCtrlTypeCategory.NamedProperties.Put("LovReference", "");
            this.colsCtrlTypeCategory.NamedProperties.Put("ResizeableChildObject", "");
            this.colsCtrlTypeCategory.NamedProperties.Put("SqlColumn", "CTRL_TYPE_CATEGORY");
            this.colsCtrlTypeCategory.NamedProperties.Put("ValidateMethod", "");
            this.colsCtrlTypeCategory.Position = 8;
            // 
            // colPostingType
            // 
            this.colPostingType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colPostingType.MaxLength = 10;
            this.colPostingType.Name = "colPostingType";
            this.colPostingType.NamedProperties.Put("EnumerateMethod", "");
            this.colPostingType.NamedProperties.Put("FieldFlags", "99");
            this.colPostingType.NamedProperties.Put("LovReference", "POSTING_CTRL_POSTING_TYPE");
            this.colPostingType.NamedProperties.Put("ResizeableChildObject", "");
            this.colPostingType.NamedProperties.Put("SqlColumn", "POSTING_TYPE");
            this.colPostingType.NamedProperties.Put("ValidateMethod", "");
            this.colPostingType.Position = 9;
            resources.ApplyResources(this.colPostingType, "colPostingType");
            this.colPostingType.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colPostingType_WindowActions);
            // 
            // colPostingTypeDesc
            // 
            resources.ApplyResources(this.colPostingTypeDesc, "colPostingTypeDesc");
            this.colPostingTypeDesc.Name = "colPostingTypeDesc";
            this.colPostingTypeDesc.NamedProperties.Put("EnumerateMethod", "");
            this.colPostingTypeDesc.NamedProperties.Put("FieldFlags", "290");
            this.colPostingTypeDesc.NamedProperties.Put("LovReference", "");
            this.colPostingTypeDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.colPostingTypeDesc.NamedProperties.Put("SqlColumn", "POSTING_TYPE_DESC");
            this.colPostingTypeDesc.NamedProperties.Put("ValidateMethod", "");
            this.colPostingTypeDesc.Position = 10;
            // 
            // colsCodeName
            // 
            this.colsCodeName.MaxLength = 30;
            this.colsCodeName.Name = "colsCodeName";
            this.colsCodeName.NamedProperties.Put("EnumerateMethod", "");
            this.colsCodeName.NamedProperties.Put("FieldFlags", "291");
            this.colsCodeName.NamedProperties.Put("LovReference", "ACCOUNTING_CODE_PARTS_USED2(COMPANY)");
            this.colsCodeName.NamedProperties.Put("ResizeableChildObject", "");
            this.colsCodeName.NamedProperties.Put("SqlColumn", "CODE_NAME");
            this.colsCodeName.NamedProperties.Put("ValidateMethod", "");
            this.colsCodeName.Position = 11;
            resources.ApplyResources(this.colsCodeName, "colsCodeName");
            this.colsCodeName.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsCodeName_WindowActions);
            // 
            // colControlType
            // 
            this.colControlType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colControlType.MaxLength = 10;
            this.colControlType.Name = "colControlType";
            this.colControlType.NamedProperties.Put("EnumerateMethod", "");
            this.colControlType.NamedProperties.Put("FieldFlags", "291");
            this.colControlType.NamedProperties.Put("LovReference", "CTRL_TYPE_ALLOWED_VALUE(COMPANY,POSTING_TYPE,CODE_PART)");
            this.colControlType.NamedProperties.Put("ResizeableChildObject", "");
            this.colControlType.NamedProperties.Put("SqlColumn", "CONTROL_TYPE");
            this.colControlType.NamedProperties.Put("ValidateMethod", "");
            this.colControlType.Position = 12;
            resources.ApplyResources(this.colControlType, "colControlType");
            this.colControlType.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colControlType_WindowActions);
            // 
            // colControlTypeDesc
            // 
            resources.ApplyResources(this.colControlTypeDesc, "colControlTypeDesc");
            this.colControlTypeDesc.Name = "colControlTypeDesc";
            this.colControlTypeDesc.NamedProperties.Put("EnumerateMethod", "");
            this.colControlTypeDesc.NamedProperties.Put("FieldFlags", "290");
            this.colControlTypeDesc.NamedProperties.Put("LovReference", "");
            this.colControlTypeDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.colControlTypeDesc.NamedProperties.Put("SqlColumn", "CONTROL_TYPE_DESC");
            this.colControlTypeDesc.NamedProperties.Put("ValidateMethod", "");
            this.colControlTypeDesc.Position = 13;
            // 
            // colDefaultValue
            // 
            this.colDefaultValue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colDefaultValue.MaxLength = 20;
            this.colDefaultValue.Name = "colDefaultValue";
            this.colDefaultValue.NamedProperties.Put("EnumerateMethod", "");
            this.colDefaultValue.NamedProperties.Put("FieldFlags", "294");
            this.colDefaultValue.NamedProperties.Put("LovReference", "ACCOUNTING_CODE_PART_VALUE_LOV(COMPANY,CODE_PART)");
            this.colDefaultValue.NamedProperties.Put("ResizeableChildObject", "");
            this.colDefaultValue.NamedProperties.Put("SqlColumn", "DEFAULT_VALUE");
            this.colDefaultValue.NamedProperties.Put("ValidateMethod", "");
            this.colDefaultValue.Position = 14;
            resources.ApplyResources(this.colDefaultValue, "colDefaultValue");
            this.colDefaultValue.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colDefaultValue_WindowActions);
            // 
            // colDefaultValueNoCt
            // 
            this.colDefaultValueNoCt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colDefaultValueNoCt.MaxLength = 20;
            this.colDefaultValueNoCt.Name = "colDefaultValueNoCt";
            this.colDefaultValueNoCt.NamedProperties.Put("EnumerateMethod", "");
            this.colDefaultValueNoCt.NamedProperties.Put("FieldFlags", "294");
            this.colDefaultValueNoCt.NamedProperties.Put("LovReference", "ACCOUNTING_CODE_PART_VALUE_LOV(COMPANY,CODE_PART)");
            this.colDefaultValueNoCt.NamedProperties.Put("ResizeableChildObject", "");
            this.colDefaultValueNoCt.NamedProperties.Put("SqlColumn", "DEFAULT_VALUE_NO_CT");
            this.colDefaultValueNoCt.NamedProperties.Put("ValidateMethod", "");
            this.colDefaultValueNoCt.Position = 15;
            resources.ApplyResources(this.colDefaultValueNoCt, "colDefaultValueNoCt");
            this.colDefaultValueNoCt.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colDefaultValueNoCt_WindowActions);
            // 
            // colOverride
            // 
            this.colOverride.MaxLength = 20;
            this.colOverride.Name = "colOverride";
            this.colOverride.NamedProperties.Put("EnumerateMethod", "POSTING_CTRL_COMP_CODE_STR_API.Enumerate");
            this.colOverride.NamedProperties.Put("FieldFlags", "295");
            this.colOverride.NamedProperties.Put("LovReference", "");
            this.colOverride.NamedProperties.Put("ResizeableChildObject", "");
            this.colOverride.NamedProperties.Put("SqlColumn", "OVERRIDE");
            this.colOverride.NamedProperties.Put("ValidateMethod", "");
            this.colOverride.Position = 16;
            resources.ApplyResources(this.colOverride, "colOverride");
            // 
            // coldPcValidFrom
            // 
            this.coldPcValidFrom.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.coldPcValidFrom.Format = "d";
            this.coldPcValidFrom.MaxLength = 0;
            this.coldPcValidFrom.Name = "coldPcValidFrom";
            this.coldPcValidFrom.NamedProperties.Put("EnumerateMethod", "");
            this.coldPcValidFrom.NamedProperties.Put("FieldFlags", "163");
            this.coldPcValidFrom.NamedProperties.Put("LovReference", "");
            this.coldPcValidFrom.NamedProperties.Put("ResizeableChildObject", "");
            this.coldPcValidFrom.NamedProperties.Put("SqlColumn", "PC_VALID_FROM");
            this.coldPcValidFrom.NamedProperties.Put("ValidateMethod", "");
            this.coldPcValidFrom.Position = 17;
            resources.ApplyResources(this.coldPcValidFrom, "coldPcValidFrom");
            // 
            // colPostModule
            // 
            this.colPostModule.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.colPostModule, "colPostModule");
            this.colPostModule.MaxLength = 20;
            this.colPostModule.Name = "colPostModule";
            this.colPostModule.NamedProperties.Put("EnumerateMethod", "");
            this.colPostModule.NamedProperties.Put("FieldFlags", "291");
            this.colPostModule.NamedProperties.Put("LovReference", "");
            this.colPostModule.NamedProperties.Put("ResizeableChildObject", "");
            this.colPostModule.NamedProperties.Put("SqlColumn", "POST_MODULE");
            this.colPostModule.NamedProperties.Put("ValidateMethod", "");
            this.colPostModule.Position = 18;
            // 
            // colsExistCombInDetail
            // 
            resources.ApplyResources(this.colsExistCombInDetail, "colsExistCombInDetail");
            this.colsExistCombInDetail.MaxLength = 5;
            this.colsExistCombInDetail.Name = "colsExistCombInDetail";
            this.colsExistCombInDetail.NamedProperties.Put("EnumerateMethod", "");
            this.colsExistCombInDetail.NamedProperties.Put("FieldFlags", "260");
            this.colsExistCombInDetail.NamedProperties.Put("LovReference", "");
            this.colsExistCombInDetail.NamedProperties.Put("ResizeableChildObject", "");
            this.colsExistCombInDetail.NamedProperties.Put("SqlColumn", "Posting_Ctrl_API.Exist_Comb_In_Detail(company, posting_type, code_part, pc_valid_" +
                    "from)");
            this.colsExistCombInDetail.NamedProperties.Put("ValidateMethod", "");
            this.colsExistCombInDetail.Position = 19;
            // 
            // menuTbwMethods
            // 
            this.menuTbwMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem__Details,
            this.menuItem__Copy,
            this.menuSeparator1,
            this.menuItem_Change});
            this.menuTbwMethods.Name = "menuTbwMethods";
            resources.ApplyResources(this.menuTbwMethods, "menuTbwMethods");
            // 
            // menuItem__Details
            // 
            this.menuItem__Details.Command = this.menuTbwMethods_menu_Details___;
            this.menuItem__Details.Name = "menuItem__Details";
            resources.ApplyResources(this.menuItem__Details, "menuItem__Details");
            this.menuItem__Details.Text = "&Details...";
            // 
            // menuItem__Copy
            // 
            this.menuItem__Copy.Command = this.menuTbwMethods_menu_Copy_Details_Set_up___;
            this.menuItem__Copy.Name = "menuItem__Copy";
            resources.ApplyResources(this.menuItem__Copy, "menuItem__Copy");
            this.menuItem__Copy.Text = "&Copy Details Set-up...";
            // 
            // menuSeparator1
            // 
            this.menuSeparator1.Name = "menuSeparator1";
            resources.ApplyResources(this.menuSeparator1, "menuSeparator1");
            // 
            // menuItem_Change
            // 
            this.menuItem_Change.Command = this.menuTbwMethods_menuChange__Company___;
            this.menuItem_Change.Name = "menuItem_Change";
            resources.ApplyResources(this.menuItem_Change, "menuItem_Change");
            this.menuItem_Change.Text = "Change &Company...";
            // 
            // tbwPostingCtrl
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colsCompany);
            this.Controls.Add(this.colsCombControlType);
            this.Controls.Add(this.colModule);
            this.Controls.Add(this.colsCodePart);
            this.Controls.Add(this.colsCtrlTypeCategoryDb);
            this.Controls.Add(this.colsCtrlTypeCategory);
            this.Controls.Add(this.colPostingType);
            this.Controls.Add(this.colPostingTypeDesc);
            this.Controls.Add(this.colsCodeName);
            this.Controls.Add(this.colControlType);
            this.Controls.Add(this.colControlTypeDesc);
            this.Controls.Add(this.colDefaultValue);
            this.Controls.Add(this.colDefaultValueNoCt);
            this.Controls.Add(this.colOverride);
            this.Controls.Add(this.coldPcValidFrom);
            this.Controls.Add(this.colPostModule);
            this.Controls.Add(this.colsExistCombInDetail);
            this.Name = "tbwPostingCtrl";
            this.NamedProperties.Put("DefaultOrderBy", "post_module, sort_order, code_part, pc_valid_from");
            this.NamedProperties.Put("DefaultWhere", "company= :global.company");
            this.NamedProperties.Put("LogicalUnit", "PostingCtrl");
            this.NamedProperties.Put("PackageName", "POSTING_CTRL_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "0");
            this.NamedProperties.Put("SourceFlags", "449");
            this.NamedProperties.Put("ViewName", "POSTING_CTRL_MASTER");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tbwPostingCtrl_WindowActions);
            this.Controls.SetChildIndex(this.colsExistCombInDetail, 0);
            this.Controls.SetChildIndex(this.colPostModule, 0);
            this.Controls.SetChildIndex(this.coldPcValidFrom, 0);
            this.Controls.SetChildIndex(this.colOverride, 0);
            this.Controls.SetChildIndex(this.colDefaultValueNoCt, 0);
            this.Controls.SetChildIndex(this.colDefaultValue, 0);
            this.Controls.SetChildIndex(this.colControlTypeDesc, 0);
            this.Controls.SetChildIndex(this.colControlType, 0);
            this.Controls.SetChildIndex(this.colsCodeName, 0);
            this.Controls.SetChildIndex(this.colPostingTypeDesc, 0);
            this.Controls.SetChildIndex(this.colPostingType, 0);
            this.Controls.SetChildIndex(this.colsCtrlTypeCategory, 0);
            this.Controls.SetChildIndex(this.colsCtrlTypeCategoryDb, 0);
            this.Controls.SetChildIndex(this.colsCodePart, 0);
            this.Controls.SetChildIndex(this.colModule, 0);
            this.Controls.SetChildIndex(this.colsCombControlType, 0);
            this.Controls.SetChildIndex(this.colsCompany, 0);
            this.Controls.SetChildIndex(this.@__colObjversion, 0);
            this.Controls.SetChildIndex(this.@__colObjid, 0);
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

        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menu_Details___;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menu_Copy_Details_Set_up___;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menuChange__Company___;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTbwMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Details;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Copy;
        protected Fnd.Windows.Forms.FndToolStripSeparator menuSeparator1;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change;
	}
}
