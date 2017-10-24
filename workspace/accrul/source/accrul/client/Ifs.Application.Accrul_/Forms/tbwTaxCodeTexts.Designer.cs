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
	
	public partial class tbwTaxCodeTexts
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cColumn colsCompany;
		public cColumn colsFeeCode;
		public cColumn colsTaxCodeDescription;
		public cColumn colTaxCodeText;
		public cColumn coldValidFrom;
		public cColumn coldValidUntil;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwTaxCodeTexts));
            this.menuOperations_menu_Change_Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_menu_Change_Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_menu_Translation_Tax_Code_Text___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.colsCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsFeeCode = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsTaxCodeDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colTaxCodeText = new Ifs.Fnd.ApplicationForms.cColumn();
            this.coldValidFrom = new Ifs.Fnd.ApplicationForms.cColumn();
            this.coldValidUntil = new Ifs.Fnd.ApplicationForms.cColumn();
            this.menuTbwMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem__Change = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem__Translation = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuOperations = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem__Change_1 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuSeparator1 = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.menuTbwMethods.SuspendLayout();
            this.menuOperations.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuTbwMethods_menu_Change_Company___);
            this.commandManager.Commands.Add(this.menuTbwMethods_menu_Translation_Tax_Code_Text___);
            this.commandManager.Commands.Add(this.menuOperations_menu_Change_Company___);
            this.commandManager.ContextMenus.Add(this.menuTbwMethods);
            this.commandManager.ContextMenus.Add(this.menuOperations);
            // 
            // menuOperations_menu_Change_Company___
            // 
            resources.ApplyResources(this.menuOperations_menu_Change_Company___, "menuOperations_menu_Change_Company___");
            this.menuOperations_menu_Change_Company___.Name = "menuOperations_menu_Change_Company___";
            this.menuOperations_menu_Change_Company___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Change_1_Execute);
            this.menuOperations_menu_Change_Company___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Change_1_Inquire);
            // 
            // menuTbwMethods_menu_Change_Company___
            // 
            resources.ApplyResources(this.menuTbwMethods_menu_Change_Company___, "menuTbwMethods_menu_Change_Company___");
            this.menuTbwMethods_menu_Change_Company___.Name = "menuTbwMethods_menu_Change_Company___";
            this.menuTbwMethods_menu_Change_Company___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Change_Execute);
            this.menuTbwMethods_menu_Change_Company___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Change_Inquire);
            // 
            // menuTbwMethods_menu_Translation_Tax_Code_Text___
            // 
            resources.ApplyResources(this.menuTbwMethods_menu_Translation_Tax_Code_Text___, "menuTbwMethods_menu_Translation_Tax_Code_Text___");
            this.menuTbwMethods_menu_Translation_Tax_Code_Text___.Name = "menuTbwMethods_menu_Translation_Tax_Code_Text___";
            this.menuTbwMethods_menu_Translation_Tax_Code_Text___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Translation_Execute);
            this.menuTbwMethods_menu_Translation_Tax_Code_Text___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Translation_Inquire);
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
            this.colsCompany.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.colsCompany.Position = 3;
            // 
            // colsFeeCode
            // 
            this.colsFeeCode.MaxLength = 20;
            this.colsFeeCode.Name = "colsFeeCode";
            this.colsFeeCode.NamedProperties.Put("EnumerateMethod", "");
            this.colsFeeCode.NamedProperties.Put("FieldFlags", "67");
            this.colsFeeCode.NamedProperties.Put("LovReference", "STATUTORY_FEE(COMPANY)");
            this.colsFeeCode.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsFeeCode.NamedProperties.Put("ResizeableChildObject", "");
            this.colsFeeCode.NamedProperties.Put("SqlColumn", "FEE_CODE");
            this.colsFeeCode.NamedProperties.Put("ValidateMethod", "");
            this.colsFeeCode.Position = 4;
            resources.ApplyResources(this.colsFeeCode, "colsFeeCode");
            this.colsFeeCode.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsFeeCode_WindowActions);
            // 
            // colsTaxCodeDescription
            // 
            this.colsTaxCodeDescription.Name = "colsTaxCodeDescription";
            this.colsTaxCodeDescription.NamedProperties.Put("EnumerateMethod", "");
            this.colsTaxCodeDescription.NamedProperties.Put("FieldFlags", "288");
            this.colsTaxCodeDescription.NamedProperties.Put("LovReference", "");
            this.colsTaxCodeDescription.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsTaxCodeDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.colsTaxCodeDescription.NamedProperties.Put("SqlColumn", "TAX_CODE_DESCRIPTION");
            this.colsTaxCodeDescription.NamedProperties.Put("ValidateMethod", "");
            this.colsTaxCodeDescription.Position = 5;
            resources.ApplyResources(this.colsTaxCodeDescription, "colsTaxCodeDescription");
            // 
            // colTaxCodeText
            // 
            this.colTaxCodeText.MaxLength = 500;
            this.colTaxCodeText.Name = "colTaxCodeText";
            this.colTaxCodeText.NamedProperties.Put("EnumerateMethod", "");
            this.colTaxCodeText.NamedProperties.Put("FieldFlags", "310");
            this.colTaxCodeText.NamedProperties.Put("LovReference", "");
            this.colTaxCodeText.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colTaxCodeText.NamedProperties.Put("ResizeableChildObject", "");
            this.colTaxCodeText.NamedProperties.Put("SqlColumn", "TAX_CODE_TEXT");
            this.colTaxCodeText.NamedProperties.Put("ValidateMethod", "");
            this.colTaxCodeText.Position = 6;
            resources.ApplyResources(this.colTaxCodeText, "colTaxCodeText");
            // 
            // coldValidFrom
            // 
            this.coldValidFrom.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.coldValidFrom.Format = "d";
            this.coldValidFrom.Name = "coldValidFrom";
            this.coldValidFrom.NamedProperties.Put("EnumerateMethod", "");
            this.coldValidFrom.NamedProperties.Put("FieldFlags", "163");
            this.coldValidFrom.NamedProperties.Put("LovReference", "");
            this.coldValidFrom.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.coldValidFrom.NamedProperties.Put("ResizeableChildObject", "");
            this.coldValidFrom.NamedProperties.Put("SqlColumn", "VALID_FROM");
            this.coldValidFrom.NamedProperties.Put("ValidateMethod", "");
            this.coldValidFrom.Position = 7;
            resources.ApplyResources(this.coldValidFrom, "coldValidFrom");
            // 
            // coldValidUntil
            // 
            this.coldValidUntil.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.coldValidUntil.Format = "d";
            this.coldValidUntil.Name = "coldValidUntil";
            this.coldValidUntil.NamedProperties.Put("EnumerateMethod", "");
            this.coldValidUntil.NamedProperties.Put("FieldFlags", "163");
            this.coldValidUntil.NamedProperties.Put("LovReference", "");
            this.coldValidUntil.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.coldValidUntil.NamedProperties.Put("ResizeableChildObject", "");
            this.coldValidUntil.NamedProperties.Put("SqlColumn", "VALID_UNTIL");
            this.coldValidUntil.NamedProperties.Put("ValidateMethod", "");
            this.coldValidUntil.Position = 8;
            resources.ApplyResources(this.coldValidUntil, "coldValidUntil");
            // 
            // menuTbwMethods
            // 
            this.menuTbwMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem__Change,
            this.menuItem__Translation});
            this.menuTbwMethods.Name = "menuTbwMethods";
            resources.ApplyResources(this.menuTbwMethods, "menuTbwMethods");
            // 
            // menuItem__Change
            // 
            this.menuItem__Change.Command = this.menuTbwMethods_menu_Change_Company___;
            this.menuItem__Change.Name = "menuItem__Change";
            resources.ApplyResources(this.menuItem__Change, "menuItem__Change");
            this.menuItem__Change.Text = "&Change Company...";
            // 
            // menuItem__Translation
            // 
            this.menuItem__Translation.Command = this.menuTbwMethods_menu_Translation_Tax_Code_Text___;
            this.menuItem__Translation.Name = "menuItem__Translation";
            resources.ApplyResources(this.menuItem__Translation, "menuItem__Translation");
            this.menuItem__Translation.Text = "&Translation Tax Code Text...";
            // 
            // menuOperations
            // 
            this.menuOperations.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem__Change_1,
            this.menuSeparator1});
            this.menuOperations.Name = "menuOperations";
            resources.ApplyResources(this.menuOperations, "menuOperations");
            // 
            // menuItem__Change_1
            // 
            this.menuItem__Change_1.Command = this.menuOperations_menu_Change_Company___;
            this.menuItem__Change_1.Name = "menuItem__Change_1";
            resources.ApplyResources(this.menuItem__Change_1, "menuItem__Change_1");
            this.menuItem__Change_1.Text = "&Change Company...";
            // 
            // menuSeparator1
            // 
            this.menuSeparator1.Name = "menuSeparator1";
            resources.ApplyResources(this.menuSeparator1, "menuSeparator1");
            // 
            // tbwTaxCodeTexts
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colsCompany);
            this.Controls.Add(this.colsFeeCode);
            this.Controls.Add(this.colsTaxCodeDescription);
            this.Controls.Add(this.colTaxCodeText);
            this.Controls.Add(this.coldValidFrom);
            this.Controls.Add(this.coldValidUntil);
            this.Name = "tbwTaxCodeTexts";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "company = :global.company");
            this.NamedProperties.Put("LogicalUnit", "TaxCodeTexts");
            this.NamedProperties.Put("PackageName", "TAX_CODE_TEXTS_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "449");
            this.NamedProperties.Put("ViewName", "TAX_CODE_TEXTS");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.Controls.SetChildIndex(this.coldValidUntil, 0);
            this.Controls.SetChildIndex(this.coldValidFrom, 0);
            this.Controls.SetChildIndex(this.colTaxCodeText, 0);
            this.Controls.SetChildIndex(this.colsTaxCodeDescription, 0);
            this.Controls.SetChildIndex(this.colsFeeCode, 0);
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

        public Fnd.Windows.Forms.FndCommand menuOperations_menu_Change_Company___;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menu_Change_Company___;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menu_Translation_Tax_Code_Text___;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTbwMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Change;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Translation;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuOperations;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Change_1;
        protected Fnd.Windows.Forms.FndToolStripSeparator menuSeparator1;
	}
}
