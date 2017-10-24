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
	
	public partial class tbwProcCode
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cColumn colCompany;
		public cColumn colProcCode;
		public cColumn colDescription;
		public cColumn colValidFrom;
		public cColumn colValidTo;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwProcCode));
            this.menuOperations_menu_Translation___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuOperations_menuChange__Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_menu_Translation___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_menuChange__Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.colCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colProcCode = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colValidFrom = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colValidTo = new Ifs.Fnd.ApplicationForms.cColumn();
            this.menuTbwMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem__Translation = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuSeparator1 = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.menuItem_Change = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuOperations = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem__Translation_1 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuSeparator2 = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.menuItem_Change_1 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuTbwMethods.SuspendLayout();
            this.menuOperations.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuTbwMethods_menu_Translation___);
            this.commandManager.Commands.Add(this.menuTbwMethods_menuChange__Company___);
            this.commandManager.Commands.Add(this.menuOperations_menu_Translation___);
            this.commandManager.Commands.Add(this.menuOperations_menuChange__Company___);
            this.commandManager.ContextMenus.Add(this.menuTbwMethods);
            this.commandManager.ContextMenus.Add(this.menuOperations);
            // 
            // menuOperations_menu_Translation___
            // 
            resources.ApplyResources(this.menuOperations_menu_Translation___, "menuOperations_menu_Translation___");
            this.menuOperations_menu_Translation___.Name = "menuOperations_menu_Translation___";
            this.menuOperations_menu_Translation___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Translation_1_Execute);
            this.menuOperations_menu_Translation___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Translation_1_Inquire);
            // 
            // menuOperations_menuChange__Company___
            // 
            resources.ApplyResources(this.menuOperations_menuChange__Company___, "menuOperations_menuChange__Company___");
            this.menuOperations_menuChange__Company___.Name = "menuOperations_menuChange__Company___";
            this.menuOperations_menuChange__Company___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Change_1_Execute);
            this.menuOperations_menuChange__Company___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Change_1_Inquire);
            // 
            // menuTbwMethods_menu_Translation___
            // 
            resources.ApplyResources(this.menuTbwMethods_menu_Translation___, "menuTbwMethods_menu_Translation___");
            this.menuTbwMethods_menu_Translation___.Name = "menuTbwMethods_menu_Translation___";
            this.menuTbwMethods_menu_Translation___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Translation_Execute);
            this.menuTbwMethods_menu_Translation___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Translation_Inquire);
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
            // colProcCode
            // 
            this.colProcCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colProcCode.MaxLength = 10;
            this.colProcCode.Name = "colProcCode";
            this.colProcCode.NamedProperties.Put("EnumerateMethod", "");
            this.colProcCode.NamedProperties.Put("FieldFlags", "163");
            this.colProcCode.NamedProperties.Put("LovReference", "");
            this.colProcCode.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colProcCode.NamedProperties.Put("ResizeableChildObject", "");
            this.colProcCode.NamedProperties.Put("SqlColumn", "PROCESS_CODE");
            this.colProcCode.NamedProperties.Put("ValidateMethod", "");
            this.colProcCode.Position = 4;
            resources.ApplyResources(this.colProcCode, "colProcCode");
            // 
            // colDescription
            // 
            this.colDescription.MaxLength = 35;
            this.colDescription.Name = "colDescription";
            this.colDescription.NamedProperties.Put("EnumerateMethod", "");
            this.colDescription.NamedProperties.Put("FieldFlags", "294");
            this.colDescription.NamedProperties.Put("LovReference", "");
            this.colDescription.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colDescription.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            this.colDescription.NamedProperties.Put("ValidateMethod", "");
            this.colDescription.Position = 5;
            resources.ApplyResources(this.colDescription, "colDescription");
            // 
            // colValidFrom
            // 
            this.colValidFrom.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.colValidFrom.Format = "d";
            this.colValidFrom.MaxLength = 20;
            this.colValidFrom.Name = "colValidFrom";
            this.colValidFrom.NamedProperties.Put("EnumerateMethod", "");
            this.colValidFrom.NamedProperties.Put("FieldFlags", "295");
            this.colValidFrom.NamedProperties.Put("LovReference", "");
            this.colValidFrom.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colValidFrom.NamedProperties.Put("SqlColumn", "VALID_FROM");
            this.colValidFrom.NamedProperties.Put("ValidateMethod", "");
            this.colValidFrom.Position = 6;
            resources.ApplyResources(this.colValidFrom, "colValidFrom");
            this.colValidFrom.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colValidFrom_WindowActions);
            // 
            // colValidTo
            // 
            this.colValidTo.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.colValidTo.Format = "d";
            this.colValidTo.MaxLength = 20;
            this.colValidTo.Name = "colValidTo";
            this.colValidTo.NamedProperties.Put("EnumerateMethod", "");
            this.colValidTo.NamedProperties.Put("FieldFlags", "295");
            this.colValidTo.NamedProperties.Put("LovReference", "");
            this.colValidTo.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colValidTo.NamedProperties.Put("SqlColumn", "VALID_UNTIL");
            this.colValidTo.NamedProperties.Put("ValidateMethod", "");
            this.colValidTo.Position = 7;
            resources.ApplyResources(this.colValidTo, "colValidTo");
            this.colValidTo.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colValidTo_WindowActions);
            // 
            // menuTbwMethods
            // 
            this.menuTbwMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem__Translation,
            this.menuSeparator1,
            this.menuItem_Change});
            this.menuTbwMethods.Name = "menuTbwMethods";
            resources.ApplyResources(this.menuTbwMethods, "menuTbwMethods");
            // 
            // menuItem__Translation
            // 
            this.menuItem__Translation.Command = this.menuTbwMethods_menu_Translation___;
            this.menuItem__Translation.Name = "menuItem__Translation";
            resources.ApplyResources(this.menuItem__Translation, "menuItem__Translation");
            this.menuItem__Translation.Text = "&Translation...";
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
            this.menuItem__Translation_1,
            this.menuSeparator2,
            this.menuItem_Change_1});
            this.menuOperations.Name = "menuOperations";
            resources.ApplyResources(this.menuOperations, "menuOperations");
            // 
            // menuItem__Translation_1
            // 
            this.menuItem__Translation_1.Command = this.menuOperations_menu_Translation___;
            this.menuItem__Translation_1.Name = "menuItem__Translation_1";
            resources.ApplyResources(this.menuItem__Translation_1, "menuItem__Translation_1");
            this.menuItem__Translation_1.Text = "&Translation...";
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
            // tbwProcCode
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colCompany);
            this.Controls.Add(this.colProcCode);
            this.Controls.Add(this.colDescription);
            this.Controls.Add(this.colValidFrom);
            this.Controls.Add(this.colValidTo);
            this.Name = "tbwProcCode";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "COMPANY = :global.company");
            this.NamedProperties.Put("LogicalUnit", "AccountProcessCode");
            this.NamedProperties.Put("PackageName", "ACCOUNT_PROCESS_CODE_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "0");
            this.NamedProperties.Put("SourceFlags", "449");
            this.NamedProperties.Put("ViewName", "ACCOUNT_PROCESS_CODE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tbwProcCode_WindowActions);
            this.Controls.SetChildIndex(this.colValidTo, 0);
            this.Controls.SetChildIndex(this.colValidFrom, 0);
            this.Controls.SetChildIndex(this.colDescription, 0);
            this.Controls.SetChildIndex(this.colProcCode, 0);
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

        public Fnd.Windows.Forms.FndCommand menuOperations_menu_Translation___;
        public Fnd.Windows.Forms.FndCommand menuOperations_menuChange__Company___;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menu_Translation___;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menuChange__Company___;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTbwMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Translation;
        protected Fnd.Windows.Forms.FndToolStripSeparator menuSeparator1;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuOperations;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Translation_1;
        protected Fnd.Windows.Forms.FndToolStripSeparator menuSeparator2;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change_1;
	}
}
