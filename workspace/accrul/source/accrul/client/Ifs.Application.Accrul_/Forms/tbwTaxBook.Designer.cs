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
	
	public partial class tbwTaxBook
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cColumn colsCompany;
		public cColumn colsTaxBookId;
		public cColumn colsDescription;
		public cLookupColumn colsTaxCode;
		public SalTableColumn colsOldTaxCode;
		public cLookupColumn colsTaxDirectionSp;
		public cColumn colsTaxSeriesId;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwTaxBook));
            this.menuTbwMethods_menu_Tax_Codes_Per_Tax_Book___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_menu_Change_Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.colsCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsTaxBookId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsTaxCode = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.colsOldTaxCode = new PPJ.Runtime.Windows.SalTableColumn();
            this.colsTaxDirectionSp = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.colsTaxSeriesId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.menuTbwMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem__Tax = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuSeparator1 = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.menuItem__Change = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuTbwMethods.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuTbwMethods_menu_Tax_Codes_Per_Tax_Book___);
            this.commandManager.Commands.Add(this.menuTbwMethods_menu_Change_Company___);
            this.commandManager.ContextMenus.Add(this.menuTbwMethods);
            // 
            // menuTbwMethods_menu_Tax_Codes_Per_Tax_Book___
            // 
            resources.ApplyResources(this.menuTbwMethods_menu_Tax_Codes_Per_Tax_Book___, "menuTbwMethods_menu_Tax_Codes_Per_Tax_Book___");
            this.menuTbwMethods_menu_Tax_Codes_Per_Tax_Book___.Name = "menuTbwMethods_menu_Tax_Codes_Per_Tax_Book___";
            this.menuTbwMethods_menu_Tax_Codes_Per_Tax_Book___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Tax_Execute);
            this.menuTbwMethods_menu_Tax_Codes_Per_Tax_Book___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Tax_Inquire);
            // 
            // menuTbwMethods_menu_Change_Company___
            // 
            resources.ApplyResources(this.menuTbwMethods_menu_Change_Company___, "menuTbwMethods_menu_Change_Company___");
            this.menuTbwMethods_menu_Change_Company___.Name = "menuTbwMethods_menu_Change_Company___";
            this.menuTbwMethods_menu_Change_Company___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Change_Execute);
            this.menuTbwMethods_menu_Change_Company___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Change_Inquire);
            // 
            // colsCompany
            // 
            this.colsCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.colsCompany, "colsCompany");
            this.colsCompany.MaxLength = 20;
            this.colsCompany.Name = "colsCompany";
            this.colsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.colsCompany.NamedProperties.Put("FieldFlags", "67");
            this.colsCompany.NamedProperties.Put("LovReference", "COMPANY_FINANCE");
            this.colsCompany.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.colsCompany.Position = 3;
            // 
            // colsTaxBookId
            // 
            this.colsTaxBookId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsTaxBookId.MaxLength = 10;
            this.colsTaxBookId.Name = "colsTaxBookId";
            this.colsTaxBookId.NamedProperties.Put("EnumerateMethod", "");
            this.colsTaxBookId.NamedProperties.Put("FieldFlags", "163");
            this.colsTaxBookId.NamedProperties.Put("LovReference", "");
            this.colsTaxBookId.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsTaxBookId.NamedProperties.Put("ResizeableChildObject", "");
            this.colsTaxBookId.NamedProperties.Put("SqlColumn", "TAX_BOOK_ID");
            this.colsTaxBookId.NamedProperties.Put("ValidateMethod", "");
            this.colsTaxBookId.Position = 4;
            resources.ApplyResources(this.colsTaxBookId, "colsTaxBookId");
            // 
            // colsDescription
            // 
            this.colsDescription.MaxLength = 40;
            this.colsDescription.Name = "colsDescription";
            this.colsDescription.NamedProperties.Put("EnumerateMethod", "");
            this.colsDescription.NamedProperties.Put("FieldFlags", "295");
            this.colsDescription.NamedProperties.Put("LovReference", "");
            this.colsDescription.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsDescription.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            this.colsDescription.Position = 5;
            resources.ApplyResources(this.colsDescription, "colsDescription");
            // 
            // colsTaxCode
            // 
            this.colsTaxCode.MaxLength = 200;
            this.colsTaxCode.Name = "colsTaxCode";
            this.colsTaxCode.NamedProperties.Put("EnumerateMethod", "TAX_CODE_API.Enumerate");
            this.colsTaxCode.NamedProperties.Put("FieldFlags", "295");
            this.colsTaxCode.NamedProperties.Put("LovReference", "");
            this.colsTaxCode.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsTaxCode.NamedProperties.Put("SqlColumn", "TAX_CODE");
            this.colsTaxCode.Position = 6;
            resources.ApplyResources(this.colsTaxCode, "colsTaxCode");
            this.colsTaxCode.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsTaxCode_WindowActions);
            // 
            // colsOldTaxCode
            // 
            resources.ApplyResources(this.colsOldTaxCode, "colsOldTaxCode");
            this.colsOldTaxCode.Name = "colsOldTaxCode";
            this.colsOldTaxCode.NamedProperties.Put("EnumerateMethod", "");
            this.colsOldTaxCode.NamedProperties.Put("FieldFlags", "262");
            this.colsOldTaxCode.NamedProperties.Put("LovReference", "");
            this.colsOldTaxCode.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsOldTaxCode.NamedProperties.Put("ResizeableChildObject", "");
            this.colsOldTaxCode.NamedProperties.Put("SqlColumn", "");
            this.colsOldTaxCode.NamedProperties.Put("ValidateMethod", "");
            this.colsOldTaxCode.Position = 7;
            // 
            // colsTaxDirectionSp
            // 
            this.colsTaxDirectionSp.MaxLength = 200;
            this.colsTaxDirectionSp.Name = "colsTaxDirectionSp";
            this.colsTaxDirectionSp.NamedProperties.Put("EnumerateMethod", "TAX_DIRECTION_SP_API.Enumerate");
            this.colsTaxDirectionSp.NamedProperties.Put("FieldFlags", "295");
            this.colsTaxDirectionSp.NamedProperties.Put("LovReference", "");
            this.colsTaxDirectionSp.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsTaxDirectionSp.NamedProperties.Put("SqlColumn", "TAX_DIRECTION_SP");
            this.colsTaxDirectionSp.Position = 8;
            resources.ApplyResources(this.colsTaxDirectionSp, "colsTaxDirectionSp");
            // 
            // colsTaxSeriesId
            // 
            this.colsTaxSeriesId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsTaxSeriesId.MaxLength = 20;
            this.colsTaxSeriesId.Name = "colsTaxSeriesId";
            this.colsTaxSeriesId.NamedProperties.Put("EnumerateMethod", "");
            this.colsTaxSeriesId.NamedProperties.Put("FieldFlags", "294");
            this.colsTaxSeriesId.NamedProperties.Put("LovReference", "TAX_SERIES(COMPANY)");
            this.colsTaxSeriesId.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsTaxSeriesId.NamedProperties.Put("ResizeableChildObject", "");
            this.colsTaxSeriesId.NamedProperties.Put("SqlColumn", "TAX_SERIES_ID");
            this.colsTaxSeriesId.NamedProperties.Put("ValidateMethod", "");
            this.colsTaxSeriesId.Position = 9;
            resources.ApplyResources(this.colsTaxSeriesId, "colsTaxSeriesId");
            // 
            // menuTbwMethods
            // 
            this.menuTbwMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem__Tax,
            this.menuSeparator1,
            this.menuItem__Change});
            this.menuTbwMethods.Name = "menuTbwMethods";
            resources.ApplyResources(this.menuTbwMethods, "menuTbwMethods");
            // 
            // menuItem__Tax
            // 
            this.menuItem__Tax.Command = this.menuTbwMethods_menu_Tax_Codes_Per_Tax_Book___;
            this.menuItem__Tax.Name = "menuItem__Tax";
            resources.ApplyResources(this.menuItem__Tax, "menuItem__Tax");
            this.menuItem__Tax.Text = "&Tax Codes Per Tax Book...";
            // 
            // menuSeparator1
            // 
            this.menuSeparator1.Name = "menuSeparator1";
            resources.ApplyResources(this.menuSeparator1, "menuSeparator1");
            // 
            // menuItem__Change
            // 
            this.menuItem__Change.Command = this.menuTbwMethods_menu_Change_Company___;
            this.menuItem__Change.Name = "menuItem__Change";
            resources.ApplyResources(this.menuItem__Change, "menuItem__Change");
            this.menuItem__Change.Text = "&Change Company...";
            // 
            // tbwTaxBook
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colsCompany);
            this.Controls.Add(this.colsTaxBookId);
            this.Controls.Add(this.colsDescription);
            this.Controls.Add(this.colsTaxCode);
            this.Controls.Add(this.colsOldTaxCode);
            this.Controls.Add(this.colsTaxDirectionSp);
            this.Controls.Add(this.colsTaxSeriesId);
            this.Name = "tbwTaxBook";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "company = :global.company");
            this.NamedProperties.Put("LogicalUnit", "TaxBook");
            this.NamedProperties.Put("PackageName", "TAX_BOOK_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "449");
            this.NamedProperties.Put("ViewName", "TAX_BOOK");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tbwTaxBook_WindowActions);
            this.Controls.SetChildIndex(this.colsTaxSeriesId, 0);
            this.Controls.SetChildIndex(this.colsTaxDirectionSp, 0);
            this.Controls.SetChildIndex(this.colsOldTaxCode, 0);
            this.Controls.SetChildIndex(this.colsTaxCode, 0);
            this.Controls.SetChildIndex(this.colsDescription, 0);
            this.Controls.SetChildIndex(this.colsTaxBookId, 0);
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

        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menu_Tax_Codes_Per_Tax_Book___;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menu_Change_Company___;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTbwMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Tax;
        protected Fnd.Windows.Forms.FndToolStripSeparator menuSeparator1;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Change;
	}
}
