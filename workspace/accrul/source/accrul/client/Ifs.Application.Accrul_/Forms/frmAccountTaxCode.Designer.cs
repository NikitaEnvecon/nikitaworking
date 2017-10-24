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
	
	public partial class frmAccountTaxCode
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		// Invisible fields
		public cDataField dfsCompany;
		protected cBackgroundText labelcmbAccount;
		public cRecSelExtComboBoxFin cmbAccount;
		protected cBackgroundText labeldfsDescription;
		public cDataField dfsDescription;
		protected cBackgroundText labeldfsTaxHandlingValue;
        public cDataField dfsTaxHandlingValue;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAccountTaxCode));
            this.menuFrmMethods_menuChange__Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuOperations_menuChange__Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTblMethods_menuChange__Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.dfsCompany = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelcmbAccount = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbAccount = new Ifs.Application.Accrul.cRecSelExtComboBoxFin();
            this.labeldfsDescription = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsDescription = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsTaxHandlingValue = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsTaxHandlingValue = new Ifs.Fnd.ApplicationForms.cDataField();
            this.menuTblMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_Change = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuOperations = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_Change_1 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuFrmMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_Change_2 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.tblTaxCodes = new Ifs.Application.Accrul.cChildTableFin();
            this.tblTaxCodes_colsCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblTaxCodes_colsAccount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblTaxCodes_colsFeeCode = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblTaxCodes_colStatutoryFeeDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblTaxCodes_colsDefaultTaxCode = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.menuTblMethods.SuspendLayout();
            this.menuOperations.SuspendLayout();
            this.menuFrmMethods.SuspendLayout();
            this.tblTaxCodes.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuTblMethods_menuChange__Company___);
            this.commandManager.Commands.Add(this.menuOperations_menuChange__Company___);
            this.commandManager.Commands.Add(this.menuFrmMethods_menuChange__Company___);
            this.commandManager.ContextMenus.Add(this.menuTblMethods);
            this.commandManager.ContextMenus.Add(this.menuOperations);
            this.commandManager.ContextMenus.Add(this.menuFrmMethods);
            // 
            // menuFrmMethods_menuChange__Company___
            // 
            resources.ApplyResources(this.menuFrmMethods_menuChange__Company___, "menuFrmMethods_menuChange__Company___");
            this.menuFrmMethods_menuChange__Company___.Name = "menuFrmMethods_menuChange__Company___";
            this.menuFrmMethods_menuChange__Company___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Change_2_Execute);
            this.menuFrmMethods_menuChange__Company___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Change_2_Inquire);
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
            // dfsCompany
            // 
            this.dfsCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsCompany, "dfsCompany");
            this.dfsCompany.Name = "dfsCompany";
            this.dfsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.dfsCompany.NamedProperties.Put("FieldFlags", "65");
            this.dfsCompany.NamedProperties.Put("LovReference", "");
            this.dfsCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.dfsCompany.NamedProperties.Put("ValidateMethod", "");
            // 
            // labelcmbAccount
            // 
            resources.ApplyResources(this.labelcmbAccount, "labelcmbAccount");
            this.labelcmbAccount.Name = "labelcmbAccount";
            // 
            // cmbAccount
            // 
            resources.ApplyResources(this.cmbAccount, "cmbAccount");
            this.cmbAccount.Name = "cmbAccount";
            this.cmbAccount.NamedProperties.Put("EnumerateMethod", "");
            this.cmbAccount.NamedProperties.Put("FieldFlags", "161");
            this.cmbAccount.NamedProperties.Put("Format", "9");
            this.cmbAccount.NamedProperties.Put("LovReference", "ACCOUNTS_CONSOLIDATION(COMPANY)");
            this.cmbAccount.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbAccount.NamedProperties.Put("SqlColumn", "ACCOUNT");
            this.cmbAccount.NamedProperties.Put("ValidateMethod", "");
            this.cmbAccount.NamedProperties.Put("XDataLength", "20");
            // 
            // labeldfsDescription
            // 
            resources.ApplyResources(this.labeldfsDescription, "labeldfsDescription");
            this.labeldfsDescription.Name = "labeldfsDescription";
            // 
            // dfsDescription
            // 
            resources.ApplyResources(this.dfsDescription, "dfsDescription");
            this.dfsDescription.Name = "dfsDescription";
            this.dfsDescription.NamedProperties.Put("EnumerateMethod", "");
            this.dfsDescription.NamedProperties.Put("FieldFlags", "289");
            this.dfsDescription.NamedProperties.Put("LovReference", "");
            this.dfsDescription.NamedProperties.Put("ParentName", "cmbAccount");
            this.dfsDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsDescription.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            this.dfsDescription.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsTaxHandlingValue
            // 
            resources.ApplyResources(this.labeldfsTaxHandlingValue, "labeldfsTaxHandlingValue");
            this.labeldfsTaxHandlingValue.Name = "labeldfsTaxHandlingValue";
            // 
            // dfsTaxHandlingValue
            // 
            resources.ApplyResources(this.dfsTaxHandlingValue, "dfsTaxHandlingValue");
            this.dfsTaxHandlingValue.Name = "dfsTaxHandlingValue";
            this.dfsTaxHandlingValue.NamedProperties.Put("EnumerateMethod", "");
            this.dfsTaxHandlingValue.NamedProperties.Put("FieldFlags", "289");
            this.dfsTaxHandlingValue.NamedProperties.Put("LovReference", "");
            this.dfsTaxHandlingValue.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsTaxHandlingValue.NamedProperties.Put("SqlColumn", "TAX_HANDLING_VALUE");
            this.dfsTaxHandlingValue.NamedProperties.Put("ValidateMethod", "");
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
            // menuFrmMethods
            // 
            this.menuFrmMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_Change_2});
            this.menuFrmMethods.Name = "menuFrmMethods";
            resources.ApplyResources(this.menuFrmMethods, "menuFrmMethods");
            // 
            // menuItem_Change_2
            // 
            this.menuItem_Change_2.Command = this.menuFrmMethods_menuChange__Company___;
            this.menuItem_Change_2.Name = "menuItem_Change_2";
            resources.ApplyResources(this.menuItem_Change_2, "menuItem_Change_2");
            this.menuItem_Change_2.Text = "Change &Company...";
            // 
            // tblTaxCodes
            // 
            this.tblTaxCodes.Controls.Add(this.tblTaxCodes_colsCompany);
            this.tblTaxCodes.Controls.Add(this.tblTaxCodes_colsAccount);
            this.tblTaxCodes.Controls.Add(this.tblTaxCodes_colsFeeCode);
            this.tblTaxCodes.Controls.Add(this.tblTaxCodes_colStatutoryFeeDescription);
            this.tblTaxCodes.Controls.Add(this.tblTaxCodes_colsDefaultTaxCode);
            resources.ApplyResources(this.tblTaxCodes, "tblTaxCodes");
            this.tblTaxCodes.Name = "tblTaxCodes";
            this.tblTaxCodes.NamedProperties.Put("DefaultOrderBy", "");
            this.tblTaxCodes.NamedProperties.Put("DefaultWhere", "");
            this.tblTaxCodes.NamedProperties.Put("LogicalUnit", "AccountTaxCode");
            this.tblTaxCodes.NamedProperties.Put("PackageName", "ACCOUNT_TAX_CODE_API");
            this.tblTaxCodes.NamedProperties.Put("ResizeableChildObject", "LLMM");
            this.tblTaxCodes.NamedProperties.Put("ViewName", "ACCOUNT_TAX_CODE");
            this.tblTaxCodes.NamedProperties.Put("Warnings", "FALSE");
            this.tblTaxCodes.DataRecordGetDefaultsEvent += new System.EventHandler<Ifs.Fnd.ApplicationForms.FndReturnEventArgsSalBoolean>(this.tblTaxCodes_DataRecordGetDefaultsEvent);
            this.tblTaxCodes.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblTaxCodes_WindowActions);
            this.tblTaxCodes.Controls.SetChildIndex(this.tblTaxCodes_colsDefaultTaxCode, 0);
            this.tblTaxCodes.Controls.SetChildIndex(this.tblTaxCodes_colStatutoryFeeDescription, 0);
            this.tblTaxCodes.Controls.SetChildIndex(this.tblTaxCodes_colsFeeCode, 0);
            this.tblTaxCodes.Controls.SetChildIndex(this.tblTaxCodes_colsAccount, 0);
            this.tblTaxCodes.Controls.SetChildIndex(this.tblTaxCodes_colsCompany, 0);
            // 
            // tblTaxCodes_colsCompany
            // 
            this.tblTaxCodes_colsCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblTaxCodes_colsCompany, "tblTaxCodes_colsCompany");
            this.tblTaxCodes_colsCompany.MaxLength = 20;
            this.tblTaxCodes_colsCompany.Name = "tblTaxCodes_colsCompany";
            this.tblTaxCodes_colsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.tblTaxCodes_colsCompany.NamedProperties.Put("FieldFlags", "67");
            this.tblTaxCodes_colsCompany.NamedProperties.Put("LovReference", "");
            this.tblTaxCodes_colsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.tblTaxCodes_colsCompany.NamedProperties.Put("ValidateMethod", "");
            this.tblTaxCodes_colsCompany.Position = 3;
            // 
            // tblTaxCodes_colsAccount
            // 
            this.tblTaxCodes_colsAccount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblTaxCodes_colsAccount, "tblTaxCodes_colsAccount");
            this.tblTaxCodes_colsAccount.MaxLength = 20;
            this.tblTaxCodes_colsAccount.Name = "tblTaxCodes_colsAccount";
            this.tblTaxCodes_colsAccount.NamedProperties.Put("EnumerateMethod", "");
            this.tblTaxCodes_colsAccount.NamedProperties.Put("FieldFlags", "99");
            this.tblTaxCodes_colsAccount.NamedProperties.Put("LovReference", "");
            this.tblTaxCodes_colsAccount.NamedProperties.Put("SqlColumn", "ACCOUNT");
            this.tblTaxCodes_colsAccount.NamedProperties.Put("ValidateMethod", "");
            this.tblTaxCodes_colsAccount.Position = 4;
            // 
            // tblTaxCodes_colsFeeCode
            // 
            this.tblTaxCodes_colsFeeCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblTaxCodes_colsFeeCode.MaxLength = 20;
            this.tblTaxCodes_colsFeeCode.Name = "tblTaxCodes_colsFeeCode";
            this.tblTaxCodes_colsFeeCode.NamedProperties.Put("EnumerateMethod", "");
            this.tblTaxCodes_colsFeeCode.NamedProperties.Put("FieldFlags", "99");
            this.tblTaxCodes_colsFeeCode.NamedProperties.Put("LovReference", "STATUTORY_FEE_DEDUCTIBLE(COMPANY)");
            this.tblTaxCodes_colsFeeCode.NamedProperties.Put("ResizeableChildObject", "");
            this.tblTaxCodes_colsFeeCode.NamedProperties.Put("SqlColumn", "FEE_CODE");
            this.tblTaxCodes_colsFeeCode.NamedProperties.Put("ValidateMethod", "");
            this.tblTaxCodes_colsFeeCode.Position = 5;
            resources.ApplyResources(this.tblTaxCodes_colsFeeCode, "tblTaxCodes_colsFeeCode");
            // 
            // tblTaxCodes_colStatutoryFeeDescription
            // 
            this.tblTaxCodes_colStatutoryFeeDescription.MaxLength = 2000;
            this.tblTaxCodes_colStatutoryFeeDescription.Name = "tblTaxCodes_colStatutoryFeeDescription";
            this.tblTaxCodes_colStatutoryFeeDescription.NamedProperties.Put("EnumerateMethod", "");
            this.tblTaxCodes_colStatutoryFeeDescription.NamedProperties.Put("FieldFlags", "288");
            this.tblTaxCodes_colStatutoryFeeDescription.NamedProperties.Put("LovReference", "");
            this.tblTaxCodes_colStatutoryFeeDescription.NamedProperties.Put("ParentName", "tblTaxCodes.tblTaxCodes_colsFeeCode");
            this.tblTaxCodes_colStatutoryFeeDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.tblTaxCodes_colStatutoryFeeDescription.NamedProperties.Put("SqlColumn", "STATUTORY_FEE_API.Get_Description(company,FEE_CODE)");
            this.tblTaxCodes_colStatutoryFeeDescription.NamedProperties.Put("ValidateMethod", "");
            this.tblTaxCodes_colStatutoryFeeDescription.Position = 6;
            resources.ApplyResources(this.tblTaxCodes_colStatutoryFeeDescription, "tblTaxCodes_colStatutoryFeeDescription");
            // 
            // tblTaxCodes_colsDefaultTaxCode
            // 
            this.tblTaxCodes_colsDefaultTaxCode.CheckBox.CheckedValue = "Y";
            this.tblTaxCodes_colsDefaultTaxCode.CheckBox.IgnoreCase = true;
            this.tblTaxCodes_colsDefaultTaxCode.CheckBox.UncheckedValue = "N";
            this.tblTaxCodes_colsDefaultTaxCode.MaxLength = 1;
            this.tblTaxCodes_colsDefaultTaxCode.Name = "tblTaxCodes_colsDefaultTaxCode";
            this.tblTaxCodes_colsDefaultTaxCode.NamedProperties.Put("EnumerateMethod", "");
            this.tblTaxCodes_colsDefaultTaxCode.NamedProperties.Put("FieldFlags", "294");
            this.tblTaxCodes_colsDefaultTaxCode.NamedProperties.Put("LovReference", "");
            this.tblTaxCodes_colsDefaultTaxCode.NamedProperties.Put("ResizeableChildObject", "");
            this.tblTaxCodes_colsDefaultTaxCode.NamedProperties.Put("SqlColumn", "DEFAULT_TAX_CODE");
            this.tblTaxCodes_colsDefaultTaxCode.NamedProperties.Put("ValidateMethod", "");
            this.tblTaxCodes_colsDefaultTaxCode.Position = 7;
            resources.ApplyResources(this.tblTaxCodes_colsDefaultTaxCode, "tblTaxCodes_colsDefaultTaxCode");
            this.tblTaxCodes_colsDefaultTaxCode.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblTaxCodes_colsDefaultTaxCode_WindowActions);
            // 
            // frmAccountTaxCode
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.tblTaxCodes);
            this.Controls.Add(this.dfsTaxHandlingValue);
            this.Controls.Add(this.dfsDescription);
            this.Controls.Add(this.cmbAccount);
            this.Controls.Add(this.dfsCompany);
            this.Controls.Add(this.labeldfsTaxHandlingValue);
            this.Controls.Add(this.labeldfsDescription);
            this.Controls.Add(this.labelcmbAccount);
            this.MaximizeBox = true;
            this.Name = "frmAccountTaxCode";
            this.NamedProperties.Put("DefaultOrderBy", "SORT_VALUE");
            this.NamedProperties.Put("DefaultWhere", "COMPANY=:global.company AND TAX_HANDLING_VALUE_DB != \'BLOCKED\'");
            this.NamedProperties.Put("LogicalUnit", "Account");
            this.NamedProperties.Put("PackageName", "ACCOUNT_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "1");
            this.NamedProperties.Put("ViewName", "ACCOUNT");
            this.NamedProperties.Put("Warnings", "TRUE");
            this.menuTblMethods.ResumeLayout(false);
            this.menuOperations.ResumeLayout(false);
            this.menuFrmMethods.ResumeLayout(false);
            this.tblTaxCodes.ResumeLayout(false);
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
		
		public Fnd.Windows.Forms.FndCommand menuFrmMethods_menuChange__Company___;
        public Fnd.Windows.Forms.FndCommand menuOperations_menuChange__Company___;
        public Fnd.Windows.Forms.FndCommand menuTblMethods_menuChange__Company___;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTblMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuOperations;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change_1;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuFrmMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change_2;
        public cChildTableFin tblTaxCodes;
        protected cColumn tblTaxCodes_colsCompany;
        protected cColumn tblTaxCodes_colsAccount;
        protected cColumn tblTaxCodes_colsFeeCode;
        protected cColumn tblTaxCodes_colStatutoryFeeDescription;
        protected cCheckBoxColumn tblTaxCodes_colsDefaultTaxCode;
	}
}
