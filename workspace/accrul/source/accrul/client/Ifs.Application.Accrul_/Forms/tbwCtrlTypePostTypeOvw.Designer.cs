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
	
	public partial class tbwCtrlTypePostTypeOvw
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cColumn colsPostModule;
		public cColumn colsPostingType;
		public cColumn colsPostingTypeDesc;
		public cColumn colsLedgerAccount;
		public cColumn colsControlType;
		public cColumn colsControlTypeDesc;
		public cColumn colsControlTypeCategory;
		public cColumn colsControlTypeCategoryDb;
		public cColumn colsCodePart;
		public cColumn colsModule;
		public cColumn colsCompany;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwCtrlTypePostTypeOvw));
            this.menuTbwMethods_menuChange__Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.colsPostModule = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsPostingType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsPostingTypeDesc = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsLedgerAccount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsControlType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsControlTypeDesc = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsControlTypeCategory = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsControlTypeCategoryDb = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsCodePart = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsModule = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.menuTbwMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_Change = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuTbwMethods.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuTbwMethods_menuChange__Company___);
            this.commandManager.ContextMenus.Add(this.menuTbwMethods);
            // 
            // menuTbwMethods_menuChange__Company___
            // 
            resources.ApplyResources(this.menuTbwMethods_menuChange__Company___, "menuTbwMethods_menuChange__Company___");
            this.menuTbwMethods_menuChange__Company___.Name = "menuTbwMethods_menuChange__Company___";
            this.menuTbwMethods_menuChange__Company___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Change_Execute);
            this.menuTbwMethods_menuChange__Company___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Change_Inquire);
            // 
            // colsPostModule
            // 
            this.colsPostModule.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsPostModule.MaxLength = 20;
            this.colsPostModule.Name = "colsPostModule";
            this.colsPostModule.NamedProperties.Put("EnumerateMethod", "");
            this.colsPostModule.NamedProperties.Put("FieldFlags", "288");
            this.colsPostModule.NamedProperties.Put("LovReference", "");
            this.colsPostModule.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsPostModule.NamedProperties.Put("ResizeableChildObject", "");
            this.colsPostModule.NamedProperties.Put("SqlColumn", "POST_MODULE");
            this.colsPostModule.NamedProperties.Put("ValidateMethod", "");
            this.colsPostModule.Position = 3;
            resources.ApplyResources(this.colsPostModule, "colsPostModule");
            // 
            // colsPostingType
            // 
            this.colsPostingType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsPostingType.MaxLength = 10;
            this.colsPostingType.Name = "colsPostingType";
            this.colsPostingType.NamedProperties.Put("EnumerateMethod", "");
            this.colsPostingType.NamedProperties.Put("FieldFlags", "160");
            this.colsPostingType.NamedProperties.Put("LovReference", "POSTING_CTRL_POSTING_TYPE");
            this.colsPostingType.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsPostingType.NamedProperties.Put("ResizeableChildObject", "");
            this.colsPostingType.NamedProperties.Put("SqlColumn", "POSTING_TYPE");
            this.colsPostingType.NamedProperties.Put("ValidateMethod", "");
            this.colsPostingType.Position = 4;
            resources.ApplyResources(this.colsPostingType, "colsPostingType");
            this.colsPostingType.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsPostingType_WindowActions);
            // 
            // colsPostingTypeDesc
            // 
            this.colsPostingTypeDesc.MaxLength = 2000;
            this.colsPostingTypeDesc.Name = "colsPostingTypeDesc";
            this.colsPostingTypeDesc.NamedProperties.Put("EnumerateMethod", "");
            this.colsPostingTypeDesc.NamedProperties.Put("FieldFlags", "304");
            this.colsPostingTypeDesc.NamedProperties.Put("LovReference", "");
            this.colsPostingTypeDesc.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsPostingTypeDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.colsPostingTypeDesc.NamedProperties.Put("SqlColumn", "POSTING_TYPE_DESC");
            this.colsPostingTypeDesc.NamedProperties.Put("ValidateMethod", "");
            this.colsPostingTypeDesc.Position = 5;
            resources.ApplyResources(this.colsPostingTypeDesc, "colsPostingTypeDesc");
            // 
            // colsLedgerAccount
            // 
            this.colsLedgerAccount.CellType = PPJ.Runtime.Windows.CellType.CheckBox;
            this.colsLedgerAccount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsLedgerAccount.CheckBox.CheckedValue = "Y";
            this.colsLedgerAccount.CheckBox.UncheckedValue = "N";
            resources.ApplyResources(this.colsLedgerAccount, "colsLedgerAccount");
            this.colsLedgerAccount.MaxLength = 5;
            this.colsLedgerAccount.Name = "colsLedgerAccount";
            this.colsLedgerAccount.NamedProperties.Put("EnumerateMethod", "");
            this.colsLedgerAccount.NamedProperties.Put("FieldFlags", "99");
            this.colsLedgerAccount.NamedProperties.Put("LovReference", "");
            this.colsLedgerAccount.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsLedgerAccount.NamedProperties.Put("ResizeableChildObject", "");
            this.colsLedgerAccount.NamedProperties.Put("SqlColumn", "LEDG_FLAG");
            this.colsLedgerAccount.NamedProperties.Put("ValidateMethod", "");
            this.colsLedgerAccount.Position = 6;
            // 
            // colsControlType
            // 
            this.colsControlType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsControlType.MaxLength = 10;
            this.colsControlType.Name = "colsControlType";
            this.colsControlType.NamedProperties.Put("EnumerateMethod", "");
            this.colsControlType.NamedProperties.Put("FieldFlags", "160");
            this.colsControlType.NamedProperties.Put("LovReference", "POSTING_CTRL_CONTROL_TYPE");
            this.colsControlType.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsControlType.NamedProperties.Put("ResizeableChildObject", "");
            this.colsControlType.NamedProperties.Put("SqlColumn", "CONTROL_TYPE");
            this.colsControlType.NamedProperties.Put("ValidateMethod", "");
            this.colsControlType.Position = 7;
            resources.ApplyResources(this.colsControlType, "colsControlType");
            this.colsControlType.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsControlType_WindowActions);
            // 
            // colsControlTypeDesc
            // 
            this.colsControlTypeDesc.MaxLength = 200;
            this.colsControlTypeDesc.Name = "colsControlTypeDesc";
            this.colsControlTypeDesc.NamedProperties.Put("EnumerateMethod", "");
            this.colsControlTypeDesc.NamedProperties.Put("FieldFlags", "288");
            this.colsControlTypeDesc.NamedProperties.Put("LovReference", "");
            this.colsControlTypeDesc.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsControlTypeDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.colsControlTypeDesc.NamedProperties.Put("SqlColumn", "Posting_Ctrl_Control_Type_API.Get_Description(CONTROL_TYPE,MODULE,:i_hWndFrame.tb" +
                    "wCtrlTypePostTypeOvw.i_sCompany)");
            this.colsControlTypeDesc.NamedProperties.Put("ValidateMethod", "");
            this.colsControlTypeDesc.Position = 8;
            resources.ApplyResources(this.colsControlTypeDesc, "colsControlTypeDesc");
            // 
            // colsControlTypeCategory
            // 
            this.colsControlTypeCategory.MaxLength = 50;
            this.colsControlTypeCategory.Name = "colsControlTypeCategory";
            this.colsControlTypeCategory.NamedProperties.Put("EnumerateMethod", "CTRL_TYPE_CATEGORY_API.Enumerate");
            this.colsControlTypeCategory.NamedProperties.Put("FieldFlags", "304");
            this.colsControlTypeCategory.NamedProperties.Put("LovReference", "");
            this.colsControlTypeCategory.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsControlTypeCategory.NamedProperties.Put("ResizeableChildObject", "");
            this.colsControlTypeCategory.NamedProperties.Put("SqlColumn", "CTRL_TYPE_CATEGORY");
            this.colsControlTypeCategory.NamedProperties.Put("ValidateMethod", "");
            this.colsControlTypeCategory.Position = 9;
            resources.ApplyResources(this.colsControlTypeCategory, "colsControlTypeCategory");
            // 
            // colsControlTypeCategoryDb
            // 
            resources.ApplyResources(this.colsControlTypeCategoryDb, "colsControlTypeCategoryDb");
            this.colsControlTypeCategoryDb.MaxLength = 50;
            this.colsControlTypeCategoryDb.Name = "colsControlTypeCategoryDb";
            this.colsControlTypeCategoryDb.NamedProperties.Put("EnumerateMethod", "");
            this.colsControlTypeCategoryDb.NamedProperties.Put("FieldFlags", "272");
            this.colsControlTypeCategoryDb.NamedProperties.Put("LovReference", "");
            this.colsControlTypeCategoryDb.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsControlTypeCategoryDb.NamedProperties.Put("ResizeableChildObject", "");
            this.colsControlTypeCategoryDb.NamedProperties.Put("SqlColumn", "CTRL_TYPE_CATEGORY_DB");
            this.colsControlTypeCategoryDb.NamedProperties.Put("ValidateMethod", "");
            this.colsControlTypeCategoryDb.Position = 10;
            // 
            // colsCodePart
            // 
            this.colsCodePart.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsCodePart.MaxLength = 1;
            this.colsCodePart.Name = "colsCodePart";
            this.colsCodePart.NamedProperties.Put("EnumerateMethod", "POSTING_CTRL_ALL_CODEPART_API.Enumerate");
            this.colsCodePart.NamedProperties.Put("FieldFlags", "160");
            this.colsCodePart.NamedProperties.Put("LovReference", "");
            this.colsCodePart.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsCodePart.NamedProperties.Put("ResizeableChildObject", "");
            this.colsCodePart.NamedProperties.Put("SqlColumn", "CODE_PART");
            this.colsCodePart.NamedProperties.Put("ValidateMethod", "");
            this.colsCodePart.Position = 11;
            resources.ApplyResources(this.colsCodePart, "colsCodePart");
            // 
            // colsModule
            // 
            this.colsModule.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsModule.MaxLength = 20;
            this.colsModule.Name = "colsModule";
            this.colsModule.NamedProperties.Put("EnumerateMethod", "");
            this.colsModule.NamedProperties.Put("FieldFlags", "160");
            this.colsModule.NamedProperties.Put("LovReference", "POSTING_CTRL_CONTROL_TYPE(CONTROL_TYPE)");
            this.colsModule.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsModule.NamedProperties.Put("ResizeableChildObject", "");
            this.colsModule.NamedProperties.Put("SqlColumn", "MODULE");
            this.colsModule.NamedProperties.Put("ValidateMethod", "");
            this.colsModule.Position = 12;
            resources.ApplyResources(this.colsModule, "colsModule");
            // 
            // colsCompany
            // 
            this.colsCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.colsCompany, "colsCompany");
            this.colsCompany.MaxLength = 20;
            this.colsCompany.Name = "colsCompany";
            this.colsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.colsCompany.NamedProperties.Put("FieldFlags", "1280");
            this.colsCompany.NamedProperties.Put("LovReference", "COMPANY");
            this.colsCompany.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.colsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.colsCompany.NamedProperties.Put("ValidateMethod", "");
            this.colsCompany.Position = 13;
            // 
            // menuTbwMethods
            // 
            this.menuTbwMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_Change});
            this.menuTbwMethods.Name = "menuTbwMethods";
            resources.ApplyResources(this.menuTbwMethods, "menuTbwMethods");
            // 
            // menuItem_Change
            // 
            this.menuItem_Change.Command = this.menuTbwMethods_menuChange__Company___;
            this.menuItem_Change.Name = "menuItem_Change";
            resources.ApplyResources(this.menuItem_Change, "menuItem_Change");
            this.menuItem_Change.Text = "Change &Company...";
            // 
            // tbwCtrlTypePostTypeOvw
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colsPostModule);
            this.Controls.Add(this.colsPostingType);
            this.Controls.Add(this.colsPostingTypeDesc);
            this.Controls.Add(this.colsLedgerAccount);
            this.Controls.Add(this.colsControlType);
            this.Controls.Add(this.colsControlTypeDesc);
            this.Controls.Add(this.colsControlTypeCategory);
            this.Controls.Add(this.colsControlTypeCategoryDb);
            this.Controls.Add(this.colsCodePart);
            this.Controls.Add(this.colsModule);
            this.Controls.Add(this.colsCompany);
            this.Name = "tbwCtrlTypePostTypeOvw";
            this.NamedProperties.Put("DefaultOrderBy", "post_module, sort_order, control_type, code_part");
            this.NamedProperties.Put("DefaultWhere", "NVL(company, :global.company) = :global.company ");
            this.NamedProperties.Put("LogicalUnit", "PostingCtrlAllowedComb");
            this.NamedProperties.Put("PackageName", "POSTING_CTRL_ALLOWED_COMB_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "448");
            this.NamedProperties.Put("ViewName", "POSTING_CTRL_ALWD_COMBINATION");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.Controls.SetChildIndex(this.colsCompany, 0);
            this.Controls.SetChildIndex(this.colsModule, 0);
            this.Controls.SetChildIndex(this.colsCodePart, 0);
            this.Controls.SetChildIndex(this.colsControlTypeCategoryDb, 0);
            this.Controls.SetChildIndex(this.colsControlTypeCategory, 0);
            this.Controls.SetChildIndex(this.colsControlTypeDesc, 0);
            this.Controls.SetChildIndex(this.colsControlType, 0);
            this.Controls.SetChildIndex(this.colsLedgerAccount, 0);
            this.Controls.SetChildIndex(this.colsPostingTypeDesc, 0);
            this.Controls.SetChildIndex(this.colsPostingType, 0);
            this.Controls.SetChildIndex(this.colsPostModule, 0);
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

        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menuChange__Company___;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTbwMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change;
	}
}
