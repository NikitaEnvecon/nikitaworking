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
	
	public partial class tbwOverviewVouTemplate
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cColumn colCompany;
		public cColumn colTemplate;
		public cColumn colDescription;
		public cColumn colValidFrom;
		public cColumn colValidUntil;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwOverviewVouTemplate));
            this.menuTbwMethods_menu_Voucher_Template___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_menuChange__Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuOperations_menu_Voucher_Template___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuOperations_menuChange__Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.colCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colTemplate = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colValidFrom = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colValidUntil = new Ifs.Fnd.ApplicationForms.cColumn();
            this.menuOperations = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem__Voucher = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem_Change = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuTbwMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem__Voucher_1 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuSeparator1 = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.menuItem_Change_1 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuOperations.SuspendLayout();
            this.menuTbwMethods.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuOperations_menu_Voucher_Template___);
            this.commandManager.Commands.Add(this.menuOperations_menuChange__Company___);
            this.commandManager.Commands.Add(this.menuTbwMethods_menu_Voucher_Template___);
            this.commandManager.Commands.Add(this.menuTbwMethods_menuChange__Company___);
            this.commandManager.ContextMenus.Add(this.menuOperations);
            this.commandManager.ContextMenus.Add(this.menuTbwMethods);
            // 
            // menuTbwMethods_menu_Voucher_Template___
            // 
            resources.ApplyResources(this.menuTbwMethods_menu_Voucher_Template___, "menuTbwMethods_menu_Voucher_Template___");
            this.menuTbwMethods_menu_Voucher_Template___.Name = "menuTbwMethods_menu_Voucher_Template___";
            this.menuTbwMethods_menu_Voucher_Template___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Voucher_1_Execute);
            this.menuTbwMethods_menu_Voucher_Template___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Voucher_1_Inquire);
            // 
            // menuTbwMethods_menuChange__Company___
            // 
            resources.ApplyResources(this.menuTbwMethods_menuChange__Company___, "menuTbwMethods_menuChange__Company___");
            this.menuTbwMethods_menuChange__Company___.Name = "menuTbwMethods_menuChange__Company___";
            this.menuTbwMethods_menuChange__Company___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Change_1_Execute);
            this.menuTbwMethods_menuChange__Company___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Change_1_Inquire);
            // 
            // menuOperations_menu_Voucher_Template___
            // 
            resources.ApplyResources(this.menuOperations_menu_Voucher_Template___, "menuOperations_menu_Voucher_Template___");
            this.menuOperations_menu_Voucher_Template___.Name = "menuOperations_menu_Voucher_Template___";
            this.menuOperations_menu_Voucher_Template___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Voucher_Execute);
            this.menuOperations_menu_Voucher_Template___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Voucher_Inquire);
            // 
            // menuOperations_menuChange__Company___
            // 
            resources.ApplyResources(this.menuOperations_menuChange__Company___, "menuOperations_menuChange__Company___");
            this.menuOperations_menuChange__Company___.Name = "menuOperations_menuChange__Company___";
            this.menuOperations_menuChange__Company___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Change_Execute);
            this.menuOperations_menuChange__Company___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Change_Inquire);
            // 
            // colCompany
            // 
            this.colCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.colCompany, "colCompany");
            this.colCompany.MaxLength = 20;
            this.colCompany.Name = "colCompany";
            this.colCompany.NamedProperties.Put("EnumerateMethod", "");
            this.colCompany.NamedProperties.Put("FieldFlags", "67");
            this.colCompany.NamedProperties.Put("LovReference", "COMPANY_FINANCE");
            this.colCompany.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.colCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.colCompany.NamedProperties.Put("ValidateMethod", "");
            this.colCompany.Position = 3;
            // 
            // colTemplate
            // 
            this.colTemplate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colTemplate.MaxLength = 10;
            this.colTemplate.Name = "colTemplate";
            this.colTemplate.NamedProperties.Put("EnumerateMethod", "");
            this.colTemplate.NamedProperties.Put("FieldFlags", "163");
            this.colTemplate.NamedProperties.Put("LovReference", "");
            this.colTemplate.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colTemplate.NamedProperties.Put("ResizeableChildObject", "");
            this.colTemplate.NamedProperties.Put("SqlColumn", "TEMPLATE");
            this.colTemplate.NamedProperties.Put("ValidateMethod", "");
            this.colTemplate.Position = 4;
            resources.ApplyResources(this.colTemplate, "colTemplate");
            // 
            // colDescription
            // 
            this.colDescription.MaxLength = 200;
            this.colDescription.Name = "colDescription";
            this.colDescription.NamedProperties.Put("EnumerateMethod", "");
            this.colDescription.NamedProperties.Put("FieldFlags", "295");
            this.colDescription.NamedProperties.Put("LovReference", "");
            this.colDescription.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.colDescription.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            this.colDescription.NamedProperties.Put("ValidateMethod", "");
            this.colDescription.Position = 5;
            resources.ApplyResources(this.colDescription, "colDescription");
            // 
            // colValidFrom
            // 
            this.colValidFrom.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.colValidFrom.Format = "d";
            this.colValidFrom.Name = "colValidFrom";
            this.colValidFrom.NamedProperties.Put("EnumerateMethod", "");
            this.colValidFrom.NamedProperties.Put("FieldFlags", "295");
            this.colValidFrom.NamedProperties.Put("LovReference", "");
            this.colValidFrom.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colValidFrom.NamedProperties.Put("ResizeableChildObject", "");
            this.colValidFrom.NamedProperties.Put("SqlColumn", "VALID_FROM");
            this.colValidFrom.NamedProperties.Put("ValidateMethod", "");
            this.colValidFrom.Position = 6;
            resources.ApplyResources(this.colValidFrom, "colValidFrom");
            // 
            // colValidUntil
            // 
            this.colValidUntil.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.colValidUntil.Format = "d";
            this.colValidUntil.Name = "colValidUntil";
            this.colValidUntil.NamedProperties.Put("EnumerateMethod", "");
            this.colValidUntil.NamedProperties.Put("FieldFlags", "295");
            this.colValidUntil.NamedProperties.Put("LovReference", "");
            this.colValidUntil.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colValidUntil.NamedProperties.Put("ResizeableChildObject", "");
            this.colValidUntil.NamedProperties.Put("SqlColumn", "VALID_UNTIL");
            this.colValidUntil.NamedProperties.Put("ValidateMethod", "");
            this.colValidUntil.Position = 7;
            resources.ApplyResources(this.colValidUntil, "colValidUntil");
            // 
            // menuOperations
            // 
            this.menuOperations.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem__Voucher,
            this.menuItem_Change});
            this.menuOperations.Name = "menuOperations";
            resources.ApplyResources(this.menuOperations, "menuOperations");
            // 
            // menuItem__Voucher
            // 
            this.menuItem__Voucher.Command = this.menuOperations_menu_Voucher_Template___;
            this.menuItem__Voucher.Name = "menuItem__Voucher";
            resources.ApplyResources(this.menuItem__Voucher, "menuItem__Voucher");
            this.menuItem__Voucher.Text = "&Voucher Template...";
            // 
            // menuItem_Change
            // 
            this.menuItem_Change.Command = this.menuOperations_menuChange__Company___;
            this.menuItem_Change.Name = "menuItem_Change";
            resources.ApplyResources(this.menuItem_Change, "menuItem_Change");
            this.menuItem_Change.Text = "Change &Company...";
            // 
            // menuTbwMethods
            // 
            this.menuTbwMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem__Voucher_1,
            this.menuSeparator1,
            this.menuItem_Change_1});
            this.menuTbwMethods.Name = "menuTbwMethods";
            resources.ApplyResources(this.menuTbwMethods, "menuTbwMethods");
            // 
            // menuItem__Voucher_1
            // 
            this.menuItem__Voucher_1.Command = this.menuTbwMethods_menu_Voucher_Template___;
            this.menuItem__Voucher_1.Name = "menuItem__Voucher_1";
            resources.ApplyResources(this.menuItem__Voucher_1, "menuItem__Voucher_1");
            this.menuItem__Voucher_1.Text = "&Voucher Template...";
            // 
            // menuSeparator1
            // 
            this.menuSeparator1.Name = "menuSeparator1";
            resources.ApplyResources(this.menuSeparator1, "menuSeparator1");
            // 
            // menuItem_Change_1
            // 
            this.menuItem_Change_1.Command = this.menuTbwMethods_menuChange__Company___;
            this.menuItem_Change_1.Name = "menuItem_Change_1";
            resources.ApplyResources(this.menuItem_Change_1, "menuItem_Change_1");
            this.menuItem_Change_1.Text = "Change &Company...";
            // 
            // tbwOverviewVouTemplate
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colCompany);
            this.Controls.Add(this.colTemplate);
            this.Controls.Add(this.colDescription);
            this.Controls.Add(this.colValidFrom);
            this.Controls.Add(this.colValidUntil);
            this.Name = "tbwOverviewVouTemplate";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "COMPANY = :global.company");
            this.NamedProperties.Put("LogicalUnit", "VoucherTemplate");
            this.NamedProperties.Put("PackageName", "VOUCHER_TEMPLATE_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "449");
            this.NamedProperties.Put("ViewName", "VOUCHER_TEMPLATE");
            this.Controls.SetChildIndex(this.colValidUntil, 0);
            this.Controls.SetChildIndex(this.colValidFrom, 0);
            this.Controls.SetChildIndex(this.colDescription, 0);
            this.Controls.SetChildIndex(this.colTemplate, 0);
            this.Controls.SetChildIndex(this.colCompany, 0);
            this.Controls.SetChildIndex(this.@__colObjversion, 0);
            this.Controls.SetChildIndex(this.@__colObjid, 0);
            this.menuOperations.ResumeLayout(false);
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

        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menu_Voucher_Template___;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menuChange__Company___;
        public Fnd.Windows.Forms.FndCommand menuOperations_menu_Voucher_Template___;
        public Fnd.Windows.Forms.FndCommand menuOperations_menuChange__Company___;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuOperations;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Voucher;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTbwMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Voucher_1;
        protected Fnd.Windows.Forms.FndToolStripSeparator menuSeparator1;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change_1;
	}
}
