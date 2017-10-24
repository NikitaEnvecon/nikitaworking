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
	
	public partial class tbwCombControlType
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		// ---------------------------------------------------------- Hidden fields---------------------------------------------
		public cColumn colsCompany;
		public cColumn colsModule;
		public cColumn colsModule1;
		public cColumn colsModule2;
		// ----------------------------------------------------------------------------------------------------------------------------
		public cColumn colsPostingType;
		public cColumn colsPostingTypeDes;
		public cColumn colsCombControlType;
		public cColumn colsCombControlTypeDesc;
		public cColumn colsControlType1;
		public cColumn colsControlType1Des;
		public cColumn colsControlType2;
		public cColumn colsControlType2Des;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwCombControlType));
            this.menuOperations_menuChange__Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_menuChange__Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.colsCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsModule = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsModule1 = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsModule2 = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsPostingType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsPostingTypeDes = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsCombControlType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsCombControlTypeDesc = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsControlType1 = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsControlType1Des = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsControlType2 = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsControlType2Des = new Ifs.Fnd.ApplicationForms.cColumn();
            this.menuTbwMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_Change = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuOperations = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_Change_1 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuTbwMethods.SuspendLayout();
            this.menuOperations.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuTbwMethods_menuChange__Company___);
            this.commandManager.Commands.Add(this.menuOperations_menuChange__Company___);
            this.commandManager.ContextMenus.Add(this.menuTbwMethods);
            this.commandManager.ContextMenus.Add(this.menuOperations);
            // 
            // menuOperations_menuChange__Company___
            // 
            resources.ApplyResources(this.menuOperations_menuChange__Company___, "menuOperations_menuChange__Company___");
            this.menuOperations_menuChange__Company___.Name = "menuOperations_menuChange__Company___";
            this.menuOperations_menuChange__Company___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Change_1_Execute);
            this.menuOperations_menuChange__Company___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Change_1_Inquire);
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
            resources.ApplyResources(this.colsCompany, "colsCompany");
            this.colsCompany.Name = "colsCompany";
            this.colsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.colsCompany.NamedProperties.Put("FieldFlags", "67");
            this.colsCompany.NamedProperties.Put("LovReference", "");
            this.colsCompany.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.colsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.colsCompany.NamedProperties.Put("ValidateMethod", "");
            this.colsCompany.Position = 3;
            // 
            // colsModule
            // 
            resources.ApplyResources(this.colsModule, "colsModule");
            this.colsModule.Name = "colsModule";
            this.colsModule.NamedProperties.Put("EnumerateMethod", "");
            this.colsModule.NamedProperties.Put("FieldFlags", "256");
            this.colsModule.NamedProperties.Put("LovReference", "COMB_CONTROL_TYPE");
            this.colsModule.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsModule.NamedProperties.Put("ResizeableChildObject", "");
            this.colsModule.NamedProperties.Put("SqlColumn", "COMB_MODULE");
            this.colsModule.NamedProperties.Put("ValidateMethod", "");
            this.colsModule.Position = 4;
            // 
            // colsModule1
            // 
            resources.ApplyResources(this.colsModule1, "colsModule1");
            this.colsModule1.Name = "colsModule1";
            this.colsModule1.NamedProperties.Put("EnumerateMethod", "");
            this.colsModule1.NamedProperties.Put("FieldFlags", "262");
            this.colsModule1.NamedProperties.Put("LovReference", "");
            this.colsModule1.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsModule1.NamedProperties.Put("ResizeableChildObject", "");
            this.colsModule1.NamedProperties.Put("SqlColumn", "MODULE1");
            this.colsModule1.NamedProperties.Put("ValidateMethod", "");
            this.colsModule1.Position = 5;
            // 
            // colsModule2
            // 
            resources.ApplyResources(this.colsModule2, "colsModule2");
            this.colsModule2.Name = "colsModule2";
            this.colsModule2.NamedProperties.Put("EnumerateMethod", "");
            this.colsModule2.NamedProperties.Put("FieldFlags", "262");
            this.colsModule2.NamedProperties.Put("LovReference", "");
            this.colsModule2.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsModule2.NamedProperties.Put("ResizeableChildObject", "");
            this.colsModule2.NamedProperties.Put("SqlColumn", "MODULE2");
            this.colsModule2.NamedProperties.Put("ValidateMethod", "");
            this.colsModule2.Position = 6;
            // 
            // colsPostingType
            // 
            this.colsPostingType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsPostingType.MaxLength = 10;
            this.colsPostingType.Name = "colsPostingType";
            this.colsPostingType.NamedProperties.Put("EnumerateMethod", "");
            this.colsPostingType.NamedProperties.Put("FieldFlags", "99");
            this.colsPostingType.NamedProperties.Put("LovReference", "POSTING_CTRL_POSTING_TYPE");
            this.colsPostingType.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsPostingType.NamedProperties.Put("ResizeableChildObject", "");
            this.colsPostingType.NamedProperties.Put("SqlColumn", "POSTING_TYPE");
            this.colsPostingType.NamedProperties.Put("ValidateMethod", "");
            this.colsPostingType.Position = 7;
            resources.ApplyResources(this.colsPostingType, "colsPostingType");
            this.colsPostingType.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsPostingType_WindowActions);
            // 
            // colsPostingTypeDes
            // 
            this.colsPostingTypeDes.Name = "colsPostingTypeDes";
            this.colsPostingTypeDes.NamedProperties.Put("EnumerateMethod", "");
            this.colsPostingTypeDes.NamedProperties.Put("FieldFlags", "256");
            this.colsPostingTypeDes.NamedProperties.Put("LovReference", "");
            this.colsPostingTypeDes.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsPostingTypeDes.NamedProperties.Put("ResizeableChildObject", "");
            this.colsPostingTypeDes.NamedProperties.Put("SqlColumn", "Posting_Ctrl_Posting_Type_API.Get_Description( POSTING_TYPE )");
            this.colsPostingTypeDes.NamedProperties.Put("ValidateMethod", "");
            this.colsPostingTypeDes.Position = 8;
            resources.ApplyResources(this.colsPostingTypeDes, "colsPostingTypeDes");
            // 
            // colsCombControlType
            // 
            this.colsCombControlType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsCombControlType.MaxLength = 10;
            this.colsCombControlType.Name = "colsCombControlType";
            this.colsCombControlType.NamedProperties.Put("EnumerateMethod", "");
            this.colsCombControlType.NamedProperties.Put("FieldFlags", "99");
            this.colsCombControlType.NamedProperties.Put("LovReference", "");
            this.colsCombControlType.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsCombControlType.NamedProperties.Put("ResizeableChildObject", "");
            this.colsCombControlType.NamedProperties.Put("SqlColumn", "COMB_CONTROL_TYPE");
            this.colsCombControlType.NamedProperties.Put("ValidateMethod", "");
            this.colsCombControlType.Position = 9;
            resources.ApplyResources(this.colsCombControlType, "colsCombControlType");
            // 
            // colsCombControlTypeDesc
            // 
            this.colsCombControlTypeDesc.MaxLength = 200;
            this.colsCombControlTypeDesc.Name = "colsCombControlTypeDesc";
            this.colsCombControlTypeDesc.NamedProperties.Put("EnumerateMethod", "");
            this.colsCombControlTypeDesc.NamedProperties.Put("FieldFlags", "262");
            this.colsCombControlTypeDesc.NamedProperties.Put("LovReference", "");
            this.colsCombControlTypeDesc.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsCombControlTypeDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.colsCombControlTypeDesc.NamedProperties.Put("SqlColumn", "COMB_CONTROL_TYPE_DESC");
            this.colsCombControlTypeDesc.NamedProperties.Put("ValidateMethod", "");
            this.colsCombControlTypeDesc.Position = 10;
            resources.ApplyResources(this.colsCombControlTypeDesc, "colsCombControlTypeDesc");
            // 
            // colsControlType1
            // 
            this.colsControlType1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsControlType1.MaxLength = 10;
            this.colsControlType1.Name = "colsControlType1";
            this.colsControlType1.NamedProperties.Put("EnumerateMethod", "");
            this.colsControlType1.NamedProperties.Put("FieldFlags", "295");
            this.colsControlType1.NamedProperties.Put("LovReference", "ALLOWED_CONTROL_TYPE(COMPANY,POSTING_TYPE)");
            this.colsControlType1.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsControlType1.NamedProperties.Put("ResizeableChildObject", "");
            this.colsControlType1.NamedProperties.Put("SqlColumn", "CONTROL_TYPE1");
            this.colsControlType1.NamedProperties.Put("ValidateMethod", "");
            this.colsControlType1.Position = 11;
            resources.ApplyResources(this.colsControlType1, "colsControlType1");
            this.colsControlType1.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsControlType1_WindowActions);
            // 
            // colsControlType1Des
            // 
            this.colsControlType1Des.Name = "colsControlType1Des";
            this.colsControlType1Des.NamedProperties.Put("EnumerateMethod", "");
            this.colsControlType1Des.NamedProperties.Put("FieldFlags", "256");
            this.colsControlType1Des.NamedProperties.Put("LovReference", "");
            this.colsControlType1Des.NamedProperties.Put("ParentName", "colsControlType1");
            this.colsControlType1Des.NamedProperties.Put("ResizeableChildObject", "");
            this.colsControlType1Des.NamedProperties.Put("SqlColumn", "Posting_Ctrl_Control_Type_API.Get_Description(CONTROL_TYPE1,MODULE1,COMPANY)");
            this.colsControlType1Des.NamedProperties.Put("ValidateMethod", "");
            this.colsControlType1Des.Position = 12;
            resources.ApplyResources(this.colsControlType1Des, "colsControlType1Des");
            // 
            // colsControlType2
            // 
            this.colsControlType2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsControlType2.MaxLength = 10;
            this.colsControlType2.Name = "colsControlType2";
            this.colsControlType2.NamedProperties.Put("EnumerateMethod", "");
            this.colsControlType2.NamedProperties.Put("FieldFlags", "295");
            this.colsControlType2.NamedProperties.Put("LovReference", "ALLOWED_CONTROL_TYPE(COMPANY,POSTING_TYPE)");
            this.colsControlType2.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsControlType2.NamedProperties.Put("ResizeableChildObject", "");
            this.colsControlType2.NamedProperties.Put("SqlColumn", "CONTROL_TYPE2");
            this.colsControlType2.NamedProperties.Put("ValidateMethod", "");
            this.colsControlType2.Position = 13;
            resources.ApplyResources(this.colsControlType2, "colsControlType2");
            this.colsControlType2.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsControlType2_WindowActions);
            // 
            // colsControlType2Des
            // 
            this.colsControlType2Des.Name = "colsControlType2Des";
            this.colsControlType2Des.NamedProperties.Put("EnumerateMethod", "");
            this.colsControlType2Des.NamedProperties.Put("FieldFlags", "256");
            this.colsControlType2Des.NamedProperties.Put("LovReference", "");
            this.colsControlType2Des.NamedProperties.Put("ParentName", "colsControlType2");
            this.colsControlType2Des.NamedProperties.Put("ResizeableChildObject", "");
            this.colsControlType2Des.NamedProperties.Put("SqlColumn", "Posting_Ctrl_Control_Type_API.Get_Description(CONTROL_TYPE2,MODULE2,COMPANY)");
            this.colsControlType2Des.NamedProperties.Put("ValidateMethod", "");
            this.colsControlType2Des.Position = 14;
            resources.ApplyResources(this.colsControlType2Des, "colsControlType2Des");
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
            // menuOperations
            // 
            this.menuOperations.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_Change_1});
            this.menuOperations.Name = "menuOperations";
            resources.ApplyResources(this.menuOperations, "menuOperations");
            // 
            // menuItem_Change_1
            // 
            this.menuItem_Change_1.Command = this.menuOperations_menuChange__Company___;
            this.menuItem_Change_1.Name = "menuItem_Change_1";
            resources.ApplyResources(this.menuItem_Change_1, "menuItem_Change_1");
            this.menuItem_Change_1.Text = "Change &Company...";
            // 
            // tbwCombControlType
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colsCompany);
            this.Controls.Add(this.colsModule);
            this.Controls.Add(this.colsModule1);
            this.Controls.Add(this.colsModule2);
            this.Controls.Add(this.colsPostingType);
            this.Controls.Add(this.colsPostingTypeDes);
            this.Controls.Add(this.colsCombControlType);
            this.Controls.Add(this.colsCombControlTypeDesc);
            this.Controls.Add(this.colsControlType1);
            this.Controls.Add(this.colsControlType1Des);
            this.Controls.Add(this.colsControlType2);
            this.Controls.Add(this.colsControlType2Des);
            this.Name = "tbwCombControlType";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "COMPANY = :global.company");
            this.NamedProperties.Put("LogicalUnit", "CombControlType");
            this.NamedProperties.Put("PackageName", "COMB_CONTROL_TYPE_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "449");
            this.NamedProperties.Put("ViewName", "COMB_CONTROL_TYPE");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tbwCombControlType_WindowActions);
            this.Controls.SetChildIndex(this.colsControlType2Des, 0);
            this.Controls.SetChildIndex(this.colsControlType2, 0);
            this.Controls.SetChildIndex(this.colsControlType1Des, 0);
            this.Controls.SetChildIndex(this.colsControlType1, 0);
            this.Controls.SetChildIndex(this.colsCombControlTypeDesc, 0);
            this.Controls.SetChildIndex(this.colsCombControlType, 0);
            this.Controls.SetChildIndex(this.colsPostingTypeDes, 0);
            this.Controls.SetChildIndex(this.colsPostingType, 0);
            this.Controls.SetChildIndex(this.colsModule2, 0);
            this.Controls.SetChildIndex(this.colsModule1, 0);
            this.Controls.SetChildIndex(this.colsModule, 0);
            this.Controls.SetChildIndex(this.colsCompany, 0);
            this.Controls.SetChildIndex(this.@__colObjversion, 0);
            this.Controls.SetChildIndex(this.@__colObjid, 0);
            this.menuTbwMethods.ResumeLayout(false);
            this.menuOperations.ResumeLayout(false);
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

        public Fnd.Windows.Forms.FndCommand menuOperations_menuChange__Company___;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menuChange__Company___;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTbwMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuOperations;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change_1;
	}
}
