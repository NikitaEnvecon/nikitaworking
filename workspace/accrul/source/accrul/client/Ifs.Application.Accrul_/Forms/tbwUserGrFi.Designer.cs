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
	
	public partial class tbwUserGrFi
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cColumn colCompany;
		public cColumn colUserGroup;
		public cColumn colDescription;
		public cLookupColumn cmbAllowedAccPeriod;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwUserGrFi));
            this.menuOperations_menuUsers_per_User_Group___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuOperations_menuChange__Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_menuUsers_per_User_Group___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_menuChange__Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.colCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colUserGroup = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.cmbAllowedAccPeriod = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.menuTbwMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_Users = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuSeparator1 = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.menuItem_Change = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuOperations = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_Users_1 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuSeparator2 = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.menuItem_Change_1 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuTbwMethods.SuspendLayout();
            this.menuOperations.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuTbwMethods_menuUsers_per_User_Group___);
            this.commandManager.Commands.Add(this.menuTbwMethods_menuChange__Company___);
            this.commandManager.Commands.Add(this.menuOperations_menuUsers_per_User_Group___);
            this.commandManager.Commands.Add(this.menuOperations_menuChange__Company___);
            this.commandManager.ContextMenus.Add(this.menuTbwMethods);
            this.commandManager.ContextMenus.Add(this.menuOperations);
            // 
            // menuOperations_menuUsers_per_User_Group___
            // 
            resources.ApplyResources(this.menuOperations_menuUsers_per_User_Group___, "menuOperations_menuUsers_per_User_Group___");
            this.menuOperations_menuUsers_per_User_Group___.Name = "menuOperations_menuUsers_per_User_Group___";
            this.menuOperations_menuUsers_per_User_Group___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Users_1_Execute);
            this.menuOperations_menuUsers_per_User_Group___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Users_1_Inquire);
            // 
            // menuOperations_menuChange__Company___
            // 
            resources.ApplyResources(this.menuOperations_menuChange__Company___, "menuOperations_menuChange__Company___");
            this.menuOperations_menuChange__Company___.Name = "menuOperations_menuChange__Company___";
            this.menuOperations_menuChange__Company___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Change_1_Execute);
            this.menuOperations_menuChange__Company___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Change_1_Inquire);
            // 
            // menuTbwMethods_menuUsers_per_User_Group___
            // 
            resources.ApplyResources(this.menuTbwMethods_menuUsers_per_User_Group___, "menuTbwMethods_menuUsers_per_User_Group___");
            this.menuTbwMethods_menuUsers_per_User_Group___.Name = "menuTbwMethods_menuUsers_per_User_Group___";
            this.menuTbwMethods_menuUsers_per_User_Group___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Users_Execute);
            this.menuTbwMethods_menuUsers_per_User_Group___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Users_Inquire);
            // 
            // menuTbwMethods_menuChange__Company___
            // 
            resources.ApplyResources(this.menuTbwMethods_menuChange__Company___, "menuTbwMethods_menuChange__Company___");
            this.menuTbwMethods_menuChange__Company___.Name = "menuTbwMethods_menuChange__Company___";
            this.menuTbwMethods_menuChange__Company___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Change_Execute);
            this.menuTbwMethods_menuChange__Company___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Change_Inquire);
            // 
            // colCompany
            // 
            this.colCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.colCompany, "colCompany");
            this.colCompany.MaxLength = 20;
            this.colCompany.Name = "colCompany";
            this.colCompany.NamedProperties.Put("EnumerateMethod", "");
            this.colCompany.NamedProperties.Put("FieldFlags", "131");
            this.colCompany.NamedProperties.Put("LovReference", "COMPANY_FINANCE");
            this.colCompany.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.colCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.colCompany.NamedProperties.Put("ValidateMethod", "");
            this.colCompany.Position = 3;
            // 
            // colUserGroup
            // 
            this.colUserGroup.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colUserGroup.MaxLength = 30;
            this.colUserGroup.Name = "colUserGroup";
            this.colUserGroup.NamedProperties.Put("EnumerateMethod", "");
            this.colUserGroup.NamedProperties.Put("FieldFlags", "163");
            this.colUserGroup.NamedProperties.Put("LovReference", "USER_GROUP_FINANCE(COMPANY)");
            this.colUserGroup.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colUserGroup.NamedProperties.Put("ResizeableChildObject", "");
            this.colUserGroup.NamedProperties.Put("SqlColumn", "USER_GROUP");
            this.colUserGroup.NamedProperties.Put("ValidateMethod", "");
            this.colUserGroup.Position = 4;
            resources.ApplyResources(this.colUserGroup, "colUserGroup");
            // 
            // colDescription
            // 
            this.colDescription.MaxLength = 35;
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
            // cmbAllowedAccPeriod
            // 
            this.cmbAllowedAccPeriod.Name = "cmbAllowedAccPeriod";
            this.cmbAllowedAccPeriod.NamedProperties.Put("EnumerateMethod", "ALLOWED_ACCOUNTING_PERIODS_API.Enumerate");
            this.cmbAllowedAccPeriod.NamedProperties.Put("FieldFlags", "294");
            this.cmbAllowedAccPeriod.NamedProperties.Put("LovReference", "");
            this.cmbAllowedAccPeriod.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.cmbAllowedAccPeriod.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbAllowedAccPeriod.NamedProperties.Put("SqlColumn", "ALLOWED_ACCOUNTING_PERIOD");
            this.cmbAllowedAccPeriod.NamedProperties.Put("ValidateMethod", "");
            this.cmbAllowedAccPeriod.Position = 6;
            resources.ApplyResources(this.cmbAllowedAccPeriod, "cmbAllowedAccPeriod");
            // 
            // menuTbwMethods
            // 
            this.menuTbwMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_Users,
            this.menuSeparator1,
            this.menuItem_Change});
            this.menuTbwMethods.Name = "menuTbwMethods";
            resources.ApplyResources(this.menuTbwMethods, "menuTbwMethods");
            // 
            // menuItem_Users
            // 
            this.menuItem_Users.Command = this.menuTbwMethods_menuUsers_per_User_Group___;
            this.menuItem_Users.Name = "menuItem_Users";
            resources.ApplyResources(this.menuItem_Users, "menuItem_Users");
            this.menuItem_Users.Text = "Users per User Group...";
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
            // menuOperations
            // 
            this.menuOperations.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_Users_1,
            this.menuSeparator2,
            this.menuItem_Change_1});
            this.menuOperations.Name = "menuOperations";
            resources.ApplyResources(this.menuOperations, "menuOperations");
            // 
            // menuItem_Users_1
            // 
            this.menuItem_Users_1.Command = this.menuOperations_menuUsers_per_User_Group___;
            this.menuItem_Users_1.Name = "menuItem_Users_1";
            resources.ApplyResources(this.menuItem_Users_1, "menuItem_Users_1");
            this.menuItem_Users_1.Text = "Users per User Group...";
            // 
            // menuSeparator2
            // 
            this.menuSeparator2.Name = "menuSeparator2";
            resources.ApplyResources(this.menuSeparator2, "menuSeparator2");
            // 
            // menuItem_Change_1
            // 
            this.menuItem_Change_1.Command = this.menuOperations_menuChange__Company___;
            this.menuItem_Change_1.Name = "menuItem_Change_1";
            resources.ApplyResources(this.menuItem_Change_1, "menuItem_Change_1");
            this.menuItem_Change_1.Text = "Change &Company...";
            // 
            // tbwUserGrFi
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colCompany);
            this.Controls.Add(this.colUserGroup);
            this.Controls.Add(this.colDescription);
            this.Controls.Add(this.cmbAllowedAccPeriod);
            this.Name = "tbwUserGrFi";
            this.NamedProperties.Put("DefaultOrderBy", "company,user_group");
            this.NamedProperties.Put("DefaultWhere", "company = :global.company");
            this.NamedProperties.Put("LogicalUnit", "UserGroupFinance");
            this.NamedProperties.Put("PackageName", "USER_GROUP_FINANCE_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "0");
            this.NamedProperties.Put("SourceFlags", "449");
            this.NamedProperties.Put("ViewName", "USER_GROUP_FINANCE");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tbwUserGrFi_WindowActions);
            this.Controls.SetChildIndex(this.cmbAllowedAccPeriod, 0);
            this.Controls.SetChildIndex(this.colDescription, 0);
            this.Controls.SetChildIndex(this.colUserGroup, 0);
            this.Controls.SetChildIndex(this.colCompany, 0);
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

        public Fnd.Windows.Forms.FndCommand menuOperations_menuUsers_per_User_Group___;
        public Fnd.Windows.Forms.FndCommand menuOperations_menuChange__Company___;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menuUsers_per_User_Group___;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menuChange__Company___;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTbwMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Users;
        protected Fnd.Windows.Forms.FndToolStripSeparator menuSeparator1;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuOperations;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Users_1;
        protected Fnd.Windows.Forms.FndToolStripSeparator menuSeparator2;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change_1;
	}
}
