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
	
	public partial class tbwAccountGroup
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cColumn colCompany;
		public cColumn colAccntGrpName;
		public cColumn colDescription;
		public cColumn colConsCompany;
		public cColumn colDefaultConsAccnt;
		public cColumn colDefConsAccountDescription;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwAccountGroup));
            this.menuTbwMethods_menuTrans_lation___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_menuChange__Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.colCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colAccntGrpName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colConsCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colDefaultConsAccnt = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colDefConsAccountDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.menuTbwMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_Translation = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuSeparator1 = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.menuItem_Change = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuTbwMethods.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuTbwMethods_menuTrans_lation___);
            this.commandManager.Commands.Add(this.menuTbwMethods_menuChange__Company___);
            this.commandManager.ContextMenus.Add(this.menuTbwMethods);
            // 
            // menuTbwMethods_menuTrans_lation___
            // 
            resources.ApplyResources(this.menuTbwMethods_menuTrans_lation___, "menuTbwMethods_menuTrans_lation___");
            this.menuTbwMethods_menuTrans_lation___.Name = "menuTbwMethods_menuTrans_lation___";
            this.menuTbwMethods_menuTrans_lation___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Translation_Execute);
            this.menuTbwMethods_menuTrans_lation___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Translation_Inquire);
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
            this.colCompany.NamedProperties.Put("FieldFlags", "67");
            this.colCompany.NamedProperties.Put("LovReference", "");
            this.colCompany.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.colCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.colCompany.NamedProperties.Put("ValidateMethod", "");
            this.colCompany.Position = 3;
            // 
            // colAccntGrpName
            // 
            this.colAccntGrpName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colAccntGrpName.MaxLength = 20;
            this.colAccntGrpName.Name = "colAccntGrpName";
            this.colAccntGrpName.NamedProperties.Put("EnumerateMethod", "");
            this.colAccntGrpName.NamedProperties.Put("FieldFlags", "163");
            this.colAccntGrpName.NamedProperties.Put("LovReference", "");
            this.colAccntGrpName.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colAccntGrpName.NamedProperties.Put("SqlColumn", "ACCNT_GROUP");
            this.colAccntGrpName.Position = 4;
            resources.ApplyResources(this.colAccntGrpName, "colAccntGrpName");
            // 
            // colDescription
            // 
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
            // colConsCompany
            // 
            this.colConsCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.colConsCompany, "colConsCompany");
            this.colConsCompany.MaxLength = 20;
            this.colConsCompany.Name = "colConsCompany";
            this.colConsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.colConsCompany.NamedProperties.Put("FieldFlags", "256");
            this.colConsCompany.NamedProperties.Put("LovReference", "");
            this.colConsCompany.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colConsCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.colConsCompany.NamedProperties.Put("SqlColumn", "CONS_COMPANY");
            this.colConsCompany.NamedProperties.Put("ValidateMethod", "");
            this.colConsCompany.Position = 6;
            // 
            // colDefaultConsAccnt
            // 
            this.colDefaultConsAccnt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colDefaultConsAccnt.MaxLength = 20;
            this.colDefaultConsAccnt.Name = "colDefaultConsAccnt";
            this.colDefaultConsAccnt.NamedProperties.Put("EnumerateMethod", "");
            this.colDefaultConsAccnt.NamedProperties.Put("FieldFlags", "294");
            this.colDefaultConsAccnt.NamedProperties.Put("LovReference", "ACCOUNTS_CONSOLIDATION(CONS_COMPANY)");
            this.colDefaultConsAccnt.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colDefaultConsAccnt.NamedProperties.Put("ResizeableChildObject", "");
            this.colDefaultConsAccnt.NamedProperties.Put("SqlColumn", "DEFAULT_CONS_ACCNT");
            this.colDefaultConsAccnt.NamedProperties.Put("ValidateMethod", "");
            this.colDefaultConsAccnt.Position = 7;
            resources.ApplyResources(this.colDefaultConsAccnt, "colDefaultConsAccnt");
            // 
            // colDefConsAccountDescription
            // 
            this.colDefConsAccountDescription.Name = "colDefConsAccountDescription";
            this.colDefConsAccountDescription.NamedProperties.Put("EnumerateMethod", "");
            this.colDefConsAccountDescription.NamedProperties.Put("FieldFlags", "256");
            this.colDefConsAccountDescription.NamedProperties.Put("LovReference", "");
            this.colDefConsAccountDescription.NamedProperties.Put("ParentName", "colDefaultConsAccnt");
            this.colDefConsAccountDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.colDefConsAccountDescription.NamedProperties.Put("SqlColumn", "Account_API.Get_Description(CONS_COMPANY,DEFAULT_CONS_ACCNT)");
            this.colDefConsAccountDescription.NamedProperties.Put("ValidateMethod", "");
            this.colDefConsAccountDescription.Position = 8;
            resources.ApplyResources(this.colDefConsAccountDescription, "colDefConsAccountDescription");
            // 
            // menuTbwMethods
            // 
            this.menuTbwMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_Translation,
            this.menuSeparator1,
            this.menuItem_Change});
            this.menuTbwMethods.Name = "menuTbwMethods";
            resources.ApplyResources(this.menuTbwMethods, "menuTbwMethods");
            // 
            // menuItem_Translation
            // 
            this.menuItem_Translation.Command = this.menuTbwMethods_menuTrans_lation___;
            this.menuItem_Translation.Name = "menuItem_Translation";
            resources.ApplyResources(this.menuItem_Translation, "menuItem_Translation");
            this.menuItem_Translation.Text = "Trans&lation...";
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
            // tbwAccountGroup
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colCompany);
            this.Controls.Add(this.colAccntGrpName);
            this.Controls.Add(this.colDescription);
            this.Controls.Add(this.colConsCompany);
            this.Controls.Add(this.colDefaultConsAccnt);
            this.Controls.Add(this.colDefConsAccountDescription);
            this.Name = "tbwAccountGroup";
            this.NamedProperties.Put("DefaultOrderBy", "ACCNT_GROUP");
            this.NamedProperties.Put("DefaultWhere", "COMPANY = :global.company");
            this.NamedProperties.Put("LogicalUnit", "AccountGroup");
            this.NamedProperties.Put("PackageName", "ACCOUNT_GROUP_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "0");
            this.NamedProperties.Put("SourceFlags", "449");
            this.NamedProperties.Put("ViewName", "ACCOUNT_GROUP");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tbwAccountGroup_WindowActions);
            this.Controls.SetChildIndex(this.colDefConsAccountDescription, 0);
            this.Controls.SetChildIndex(this.colDefaultConsAccnt, 0);
            this.Controls.SetChildIndex(this.colConsCompany, 0);
            this.Controls.SetChildIndex(this.colDescription, 0);
            this.Controls.SetChildIndex(this.colAccntGrpName, 0);
            this.Controls.SetChildIndex(this.colCompany, 0);
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

        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menuTrans_lation___;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menuChange__Company___;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTbwMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Translation;
        protected Fnd.Windows.Forms.FndToolStripSeparator menuSeparator1;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change;
	}
}
