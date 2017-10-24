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
	
	public partial class frmUserGrMem
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		protected cBackgroundText labeldfCompany;
		public cDataField dfCompany;
		protected cBackgroundText labelcmbUserGroup;
		public cRecListDataField cmbUserGroup;
		// Bug 74642, Begin, Moved to left to keep some space in-between user group & description fields.
		protected cBackgroundText labeldfDescription;
		public cDataField dfDescription;
        // Bug 74642, End
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUserGrMem));
            this.menuOperations_menuChange__Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTblMethods_menuChange__Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.labeldfCompany = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfCompany = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelcmbUserGroup = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbUserGroup = new Ifs.Fnd.ApplicationForms.cRecListDataField();
            this.labeldfDescription = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfDescription = new Ifs.Fnd.ApplicationForms.cDataField();
            this.menuTblMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_Change = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuOperations = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_Change_1 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.tblUserGroups = new Ifs.Application.Accrul.cChildTableFin();
            this.tblUserGroups_colCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblUserGroups_colUserGroup = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblUserGroups_colUserid = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblUserGroups_colDefaultGroup = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.tblUserGroups_colsDefaultGroupDb = new Ifs.Fnd.ApplicationForms.cColumn();
            this.menuTblMethods.SuspendLayout();
            this.menuOperations.SuspendLayout();
            this.tblUserGroups.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuTblMethods_menuChange__Company___);
            this.commandManager.Commands.Add(this.menuOperations_menuChange__Company___);
            this.commandManager.ContextMenus.Add(this.menuTblMethods);
            this.commandManager.ContextMenus.Add(this.menuOperations);
            // 
            // menuOperations_menuChange__Company___
            // 
            resources.ApplyResources(this.menuOperations_menuChange__Company___, "menuOperations_menuChange__Company___");
            this.menuOperations_menuChange__Company___.Name = "menuOperations_menuChange__Company___";
            this.menuOperations_menuChange__Company___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Change_1_Execute);
            this.menuOperations_menuChange__Company___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Change_1_Inquire);
            // 
            // menuTblMethods_menuChange__Company___
            // 
            resources.ApplyResources(this.menuTblMethods_menuChange__Company___, "menuTblMethods_menuChange__Company___");
            this.menuTblMethods_menuChange__Company___.Name = "menuTblMethods_menuChange__Company___";
            this.menuTblMethods_menuChange__Company___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Change_Execute);
            this.menuTblMethods_menuChange__Company___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Change_Inquire);
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
            this.dfCompany.NamedProperties.Put("FieldFlags", "128");
            this.dfCompany.NamedProperties.Put("LovReference", "");
            this.dfCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.dfCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.dfCompany.NamedProperties.Put("ValidateMethod", "");
            // 
            // labelcmbUserGroup
            // 
            resources.ApplyResources(this.labelcmbUserGroup, "labelcmbUserGroup");
            this.labelcmbUserGroup.Name = "labelcmbUserGroup";
            // 
            // cmbUserGroup
            // 
            resources.ApplyResources(this.cmbUserGroup, "cmbUserGroup");
            this.cmbUserGroup.Name = "cmbUserGroup";
            this.cmbUserGroup.NamedProperties.Put("EnumerateMethod", "");
            this.cmbUserGroup.NamedProperties.Put("FieldFlags", "99");
            this.cmbUserGroup.NamedProperties.Put("LovReference", "");
            this.cmbUserGroup.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbUserGroup.NamedProperties.Put("SqlColumn", "USER_GROUP");
            this.cmbUserGroup.NamedProperties.Put("ValidateMethod", "");
            this.cmbUserGroup.NamedProperties.Put("XDataLength", "30");
            // 
            // labeldfDescription
            // 
            resources.ApplyResources(this.labeldfDescription, "labeldfDescription");
            this.labeldfDescription.Name = "labeldfDescription";
            // 
            // dfDescription
            // 
            resources.ApplyResources(this.dfDescription, "dfDescription");
            this.dfDescription.Name = "dfDescription";
            this.dfDescription.NamedProperties.Put("EnumerateMethod", "");
            this.dfDescription.NamedProperties.Put("FieldFlags", "288");
            this.dfDescription.NamedProperties.Put("LovReference", "");
            this.dfDescription.NamedProperties.Put("ParentName", "cmbUserGroup");
            this.dfDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.dfDescription.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            this.dfDescription.NamedProperties.Put("ValidateMethod", "");
            // 
            // menuTblMethods
            // 
            this.menuTblMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_Change});
            this.menuTblMethods.Name = "menuTblMethods";
            resources.ApplyResources(this.menuTblMethods, "menuTblMethods");
            // 
            // menuItem_Change
            // 
            this.menuItem_Change.Command = this.menuTblMethods_menuChange__Company___;
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
            // tblUserGroups
            // 
            this.tblUserGroups.Controls.Add(this.tblUserGroups_colCompany);
            this.tblUserGroups.Controls.Add(this.tblUserGroups_colUserGroup);
            this.tblUserGroups.Controls.Add(this.tblUserGroups_colUserid);
            this.tblUserGroups.Controls.Add(this.tblUserGroups_colDefaultGroup);
            this.tblUserGroups.Controls.Add(this.tblUserGroups_colsDefaultGroupDb);
            resources.ApplyResources(this.tblUserGroups, "tblUserGroups");
            this.tblUserGroups.Name = "tblUserGroups";
            this.tblUserGroups.NamedProperties.Put("DefaultOrderBy", "USERID");
            this.tblUserGroups.NamedProperties.Put("DefaultWhere", "COMPANY = :global.company AND USER_GROUP = :i_hWndFrame.frmUserGrMem.cmbUserGroup" +
        ".i_sMyValue");
            this.tblUserGroups.NamedProperties.Put("LogicalUnit", "UserGroupMemberFinance");
            this.tblUserGroups.NamedProperties.Put("PackageName", "USER_GROUP_MEMBER_FINANCE_API");
            this.tblUserGroups.NamedProperties.Put("ResizeableChildObject", "LLMM");
            this.tblUserGroups.NamedProperties.Put("ViewName", "USER_GROUP_MEMBER_FINANCE");
            this.tblUserGroups.NamedProperties.Put("Warnings", "FALSE");
            this.tblUserGroups.DataRecordCheckRemoveEvent += new Ifs.Fnd.ApplicationForms.cDataSource.DataRecordCheckRemoveEventHandler(this.tblUserGroups_DataRecordCheckRemoveEvent);
            this.tblUserGroups.DataRecordGetDefaultsEvent += new System.EventHandler<Ifs.Fnd.ApplicationForms.FndReturnEventArgsSalBoolean>(this.tblUserGroups_DataRecordGetDefaultsEvent);
            this.tblUserGroups.DataRecordRemoveEvent += new Ifs.Fnd.ApplicationForms.cDataSource.DataRecordRemoveEventHandler(this.tblUserGroups_DataRecordRemoveEvent);
            this.tblUserGroups.Controls.SetChildIndex(this.tblUserGroups_colsDefaultGroupDb, 0);
            this.tblUserGroups.Controls.SetChildIndex(this.tblUserGroups_colDefaultGroup, 0);
            this.tblUserGroups.Controls.SetChildIndex(this.tblUserGroups_colUserid, 0);
            this.tblUserGroups.Controls.SetChildIndex(this.tblUserGroups_colUserGroup, 0);
            this.tblUserGroups.Controls.SetChildIndex(this.tblUserGroups_colCompany, 0);
            // 
            // tblUserGroups_colCompany
            // 
            this.tblUserGroups_colCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblUserGroups_colCompany, "tblUserGroups_colCompany");
            this.tblUserGroups_colCompany.MaxLength = 20;
            this.tblUserGroups_colCompany.Name = "tblUserGroups_colCompany";
            this.tblUserGroups_colCompany.NamedProperties.Put("EnumerateMethod", "");
            this.tblUserGroups_colCompany.NamedProperties.Put("FieldFlags", "129");
            this.tblUserGroups_colCompany.NamedProperties.Put("LovReference", "");
            this.tblUserGroups_colCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.tblUserGroups_colCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.tblUserGroups_colCompany.NamedProperties.Put("ValidateMethod", "");
            this.tblUserGroups_colCompany.Position = 3;
            // 
            // tblUserGroups_colUserGroup
            // 
            resources.ApplyResources(this.tblUserGroups_colUserGroup, "tblUserGroups_colUserGroup");
            this.tblUserGroups_colUserGroup.MaxLength = 30;
            this.tblUserGroups_colUserGroup.Name = "tblUserGroups_colUserGroup";
            this.tblUserGroups_colUserGroup.NamedProperties.Put("EnumerateMethod", "");
            this.tblUserGroups_colUserGroup.NamedProperties.Put("FieldFlags", "163");
            this.tblUserGroups_colUserGroup.NamedProperties.Put("LovReference", "");
            this.tblUserGroups_colUserGroup.NamedProperties.Put("ResizeableChildObject", "");
            this.tblUserGroups_colUserGroup.NamedProperties.Put("SqlColumn", "USER_GROUP");
            this.tblUserGroups_colUserGroup.NamedProperties.Put("ValidateMethod", "");
            this.tblUserGroups_colUserGroup.Position = 4;
            // 
            // tblUserGroups_colUserid
            // 
            this.tblUserGroups_colUserid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblUserGroups_colUserid.MaxLength = 30;
            this.tblUserGroups_colUserid.Name = "tblUserGroups_colUserid";
            this.tblUserGroups_colUserid.NamedProperties.Put("EnumerateMethod", "");
            this.tblUserGroups_colUserid.NamedProperties.Put("FieldFlags", "167");
            this.tblUserGroups_colUserid.NamedProperties.Put("LovReference", "USER_FINANCE(COMPANY)");
            this.tblUserGroups_colUserid.NamedProperties.Put("ResizeableChildObject", "");
            this.tblUserGroups_colUserid.NamedProperties.Put("SqlColumn", "USERID");
            this.tblUserGroups_colUserid.NamedProperties.Put("ValidateMethod", "");
            this.tblUserGroups_colUserid.Position = 5;
            resources.ApplyResources(this.tblUserGroups_colUserid, "tblUserGroups_colUserid");
            this.tblUserGroups_colUserid.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblUserGroups_colUserid_WindowActions);
            // 
            // tblUserGroups_colDefaultGroup
            // 
            this.tblUserGroups_colDefaultGroup.MaxLength = 15;
            this.tblUserGroups_colDefaultGroup.Name = "tblUserGroups_colDefaultGroup";
            this.tblUserGroups_colDefaultGroup.NamedProperties.Put("EnumerateMethod", "DEFAULT_GROUP_API.Enumerate");
            this.tblUserGroups_colDefaultGroup.NamedProperties.Put("FieldFlags", "295");
            this.tblUserGroups_colDefaultGroup.NamedProperties.Put("LovReference", "");
            this.tblUserGroups_colDefaultGroup.NamedProperties.Put("ResizeableChildObject", "");
            this.tblUserGroups_colDefaultGroup.NamedProperties.Put("SqlColumn", "DEFAULT_GROUP");
            this.tblUserGroups_colDefaultGroup.NamedProperties.Put("ValidateMethod", "");
            this.tblUserGroups_colDefaultGroup.Position = 6;
            this.tblUserGroups_colDefaultGroup.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            resources.ApplyResources(this.tblUserGroups_colDefaultGroup, "tblUserGroups_colDefaultGroup");
            this.tblUserGroups_colDefaultGroup.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblUserGroups_colDefaultGroup_WindowActions);
            // 
            // tblUserGroups_colsDefaultGroupDb
            // 
            resources.ApplyResources(this.tblUserGroups_colsDefaultGroupDb, "tblUserGroups_colsDefaultGroupDb");
            this.tblUserGroups_colsDefaultGroupDb.MaxLength = 20;
            this.tblUserGroups_colsDefaultGroupDb.Name = "tblUserGroups_colsDefaultGroupDb";
            this.tblUserGroups_colsDefaultGroupDb.NamedProperties.Put("EnumerateMethod", "");
            this.tblUserGroups_colsDefaultGroupDb.NamedProperties.Put("LovReference", "");
            this.tblUserGroups_colsDefaultGroupDb.NamedProperties.Put("ResizeableChildObject", "");
            this.tblUserGroups_colsDefaultGroupDb.NamedProperties.Put("SqlColumn", "DEFAULT_GROUP_DB");
            this.tblUserGroups_colsDefaultGroupDb.NamedProperties.Put("ValidateMethod", "");
            this.tblUserGroups_colsDefaultGroupDb.Position = 7;
            // 
            // frmUserGrMem
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.tblUserGroups);
            this.Controls.Add(this.dfDescription);
            this.Controls.Add(this.cmbUserGroup);
            this.Controls.Add(this.dfCompany);
            this.Controls.Add(this.labeldfDescription);
            this.Controls.Add(this.labelcmbUserGroup);
            this.Controls.Add(this.labeldfCompany);
            this.MaximizeBox = true;
            this.Name = "frmUserGrMem";
            this.NamedProperties.Put("DefaultOrderBy", "USER_GROUP");
            this.NamedProperties.Put("DefaultWhere", "COMPANY= :global.company");
            this.NamedProperties.Put("LogicalUnit", "UserGroupFinance");
            this.NamedProperties.Put("PackageName", "USER_GROUP_FINANCE_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "0");
            this.NamedProperties.Put("SourceFlags", "1");
            this.NamedProperties.Put("ViewName", "USER_GROUP_FINANCE");
            this.menuTblMethods.ResumeLayout(false);
            this.menuOperations.ResumeLayout(false);
            this.tblUserGroups.ResumeLayout(false);
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

        public Fnd.Windows.Forms.FndCommand menuOperations_menuChange__Company___;
        public Fnd.Windows.Forms.FndCommand menuTblMethods_menuChange__Company___;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTblMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuOperations;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change_1;
        public cChildTableFin tblUserGroups;
        protected cColumn tblUserGroups_colCompany;
        protected cColumn tblUserGroups_colUserGroup;
        protected cColumn tblUserGroups_colUserid;
        protected cLookupColumn tblUserGroups_colDefaultGroup;
        protected cColumn tblUserGroups_colsDefaultGroupDb;
	}
}
