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
	
	public partial class tbwTaxWithhold
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cColumn colCompany;
		public cColumn colFeeCode;
		public cColumn colDescription;
		public cColumn colAmountNotTaxable;
		public cColumn colMinWithheldAmount;
		public cColumn colCurrency;
		public cCheckBoxColumn colUseWithholdAmountTable;
		public cColumn colnMinimumBaseAmount;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwTaxWithhold));
            this.menuOperations_menu_Change_Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_menu_Change_Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.colCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colFeeCode = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colAmountNotTaxable = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colMinWithheldAmount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colCurrency = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colUseWithholdAmountTable = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.colnMinimumBaseAmount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.menuTbwMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem__Change = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
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
            // colCompany
            // 
            resources.ApplyResources(this.colCompany, "colCompany");
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
            // colFeeCode
            // 
            this.colFeeCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colFeeCode.Name = "colFeeCode";
            this.colFeeCode.NamedProperties.Put("EnumerateMethod", "");
            this.colFeeCode.NamedProperties.Put("FieldFlags", "163");
            this.colFeeCode.NamedProperties.Put("LovReference", "");
            this.colFeeCode.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colFeeCode.NamedProperties.Put("SqlColumn", "FEE_CODE");
            this.colFeeCode.NamedProperties.Put("ValidateMethod", "");
            this.colFeeCode.Position = 4;
            resources.ApplyResources(this.colFeeCode, "colFeeCode");
            // 
            // colDescription
            // 
            this.colDescription.Name = "colDescription";
            this.colDescription.NamedProperties.Put("EnumerateMethod", "");
            this.colDescription.NamedProperties.Put("FieldFlags", "289");
            this.colDescription.NamedProperties.Put("LovReference", "");
            this.colDescription.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.colDescription.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            this.colDescription.NamedProperties.Put("ValidateMethod", "");
            this.colDescription.Position = 5;
            resources.ApplyResources(this.colDescription, "colDescription");
            // 
            // colAmountNotTaxable
            // 
            this.colAmountNotTaxable.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colAmountNotTaxable.Name = "colAmountNotTaxable";
            this.colAmountNotTaxable.NamedProperties.Put("EnumerateMethod", "");
            this.colAmountNotTaxable.NamedProperties.Put("FieldFlags", "294");
            this.colAmountNotTaxable.NamedProperties.Put("LovReference", "");
            this.colAmountNotTaxable.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colAmountNotTaxable.NamedProperties.Put("ResizeableChildObject", "");
            this.colAmountNotTaxable.NamedProperties.Put("SqlColumn", "AMOUNT_NOT_TAXABLE");
            this.colAmountNotTaxable.NamedProperties.Put("ValidateMethod", "");
            this.colAmountNotTaxable.Position = 6;
            this.colAmountNotTaxable.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.colAmountNotTaxable, "colAmountNotTaxable");
            // 
            // colMinWithheldAmount
            // 
            this.colMinWithheldAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colMinWithheldAmount.Name = "colMinWithheldAmount";
            this.colMinWithheldAmount.NamedProperties.Put("EnumerateMethod", "");
            this.colMinWithheldAmount.NamedProperties.Put("FieldFlags", "294");
            this.colMinWithheldAmount.NamedProperties.Put("LovReference", "");
            this.colMinWithheldAmount.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colMinWithheldAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.colMinWithheldAmount.NamedProperties.Put("SqlColumn", "MIN_WITHHELD_AMOUNT");
            this.colMinWithheldAmount.NamedProperties.Put("ValidateMethod", "");
            this.colMinWithheldAmount.Position = 7;
            this.colMinWithheldAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.colMinWithheldAmount, "colMinWithheldAmount");
            // 
            // colCurrency
            // 
            this.colCurrency.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colCurrency.MaxLength = 3;
            this.colCurrency.Name = "colCurrency";
            this.colCurrency.NamedProperties.Put("EnumerateMethod", "");
            this.colCurrency.NamedProperties.Put("FieldFlags", "289");
            this.colCurrency.NamedProperties.Put("LovReference", "");
            this.colCurrency.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colCurrency.NamedProperties.Put("ResizeableChildObject", "");
            this.colCurrency.NamedProperties.Put("SqlColumn", "Company_Finance_API.Get_Currency_Code(company)");
            this.colCurrency.NamedProperties.Put("ValidateMethod", "");
            this.colCurrency.Position = 8;
            resources.ApplyResources(this.colCurrency, "colCurrency");
            // 
            // colUseWithholdAmountTable
            // 
            this.colUseWithholdAmountTable.CheckBox.CheckedValue = "TRUE";
            this.colUseWithholdAmountTable.CheckBox.IgnoreCase = false;
            this.colUseWithholdAmountTable.CheckBox.UncheckedValue = "FALSE";
            this.colUseWithholdAmountTable.MaxLength = 5;
            this.colUseWithholdAmountTable.Name = "colUseWithholdAmountTable";
            this.colUseWithholdAmountTable.NamedProperties.Put("EnumerateMethod", "");
            this.colUseWithholdAmountTable.NamedProperties.Put("FieldFlags", "295");
            this.colUseWithholdAmountTable.NamedProperties.Put("LovReference", "");
            this.colUseWithholdAmountTable.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colUseWithholdAmountTable.NamedProperties.Put("ResizeableChildObject", "");
            this.colUseWithholdAmountTable.NamedProperties.Put("SqlColumn", "USE_WITHHOLD_AMOUNT_TABLE");
            this.colUseWithholdAmountTable.NamedProperties.Put("ValidateMethod", "");
            this.colUseWithholdAmountTable.Position = 9;
            resources.ApplyResources(this.colUseWithholdAmountTable, "colUseWithholdAmountTable");
            // 
            // colnMinimumBaseAmount
            // 
            this.colnMinimumBaseAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colnMinimumBaseAmount.Name = "colnMinimumBaseAmount";
            this.colnMinimumBaseAmount.NamedProperties.Put("EnumerateMethod", "");
            this.colnMinimumBaseAmount.NamedProperties.Put("FieldFlags", "294");
            this.colnMinimumBaseAmount.NamedProperties.Put("LovReference", "");
            this.colnMinimumBaseAmount.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colnMinimumBaseAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.colnMinimumBaseAmount.NamedProperties.Put("SqlColumn", "MINIMUM_BASE_AMOUNT");
            this.colnMinimumBaseAmount.NamedProperties.Put("ValidateMethod", "");
            this.colnMinimumBaseAmount.Position = 10;
            this.colnMinimumBaseAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.colnMinimumBaseAmount, "colnMinimumBaseAmount");
            // 
            // menuTbwMethods
            // 
            this.menuTbwMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem__Change});
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
            // tbwTaxWithhold
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colCompany);
            this.Controls.Add(this.colFeeCode);
            this.Controls.Add(this.colDescription);
            this.Controls.Add(this.colAmountNotTaxable);
            this.Controls.Add(this.colMinWithheldAmount);
            this.Controls.Add(this.colCurrency);
            this.Controls.Add(this.colUseWithholdAmountTable);
            this.Controls.Add(this.colnMinimumBaseAmount);
            this.Name = "tbwTaxWithhold";
            this.NamedProperties.Put("DefaultOrderBy", "fee_code");
            this.NamedProperties.Put("DefaultWhere", "company = :global.company and fee_type_db IN (\'IRS1099TX\')");
            this.NamedProperties.Put("LogicalUnit", "StatutoryFee");
            this.NamedProperties.Put("PackageName", "STATUTORY_FEE_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "0");
            this.NamedProperties.Put("SourceFlags", "449");
            this.NamedProperties.Put("ViewName", "STATUTORY_FEE_DEDUCT_MULTIPLE");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tbwTaxWithhold_WindowActions);
            this.Controls.SetChildIndex(this.colnMinimumBaseAmount, 0);
            this.Controls.SetChildIndex(this.colUseWithholdAmountTable, 0);
            this.Controls.SetChildIndex(this.colCurrency, 0);
            this.Controls.SetChildIndex(this.colMinWithheldAmount, 0);
            this.Controls.SetChildIndex(this.colAmountNotTaxable, 0);
            this.Controls.SetChildIndex(this.colDescription, 0);
            this.Controls.SetChildIndex(this.colFeeCode, 0);
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

        public Fnd.Windows.Forms.FndCommand menuOperations_menu_Change_Company___;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menu_Change_Company___;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTbwMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Change;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuOperations;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Change_1;
        protected Fnd.Windows.Forms.FndToolStripSeparator menuSeparator1;
	}
}
