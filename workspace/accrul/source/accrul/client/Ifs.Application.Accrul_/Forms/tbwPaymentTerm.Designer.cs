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
	
	public partial class tbwPaymentTerm
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cColumn colCompany;
		public cColumn colPayTermId;
		public cColumn colDescription;
		public cCheckBoxColumn colsUseCommercialYear;
		public cLookupColumn colsVatDistribution;
		public cCheckBoxColumn colsConsiderPayVacPeriod;
		public cCheckBoxColumn colBlockForDirectDebiting;
		public cCheckBoxColumn colsExcludeCreditLimit;
		public cCheckBoxColumn colsSuppressAmount;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwPaymentTerm));
            this.menuOperations_menuTranslation___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuOperations_menuChange__Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_menuPayment_Term___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_menuTranslation___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_menuPayment_Vacation_Days___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_menuChange__Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.colCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colPayTermId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsUseCommercialYear = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.colsVatDistribution = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.colsConsiderPayVacPeriod = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.colBlockForDirectDebiting = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.colsExcludeCreditLimit = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.colsSuppressAmount = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.menuTbwMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_Payment = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem_Translation = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem_Payment_1 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuSeparator1 = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.menuItem_Change = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuOperations = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_Translation_1 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuSeparator2 = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.menuItem_Change_1 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.colsCashDiscFixassAcqValueDb = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.menuTbwMethods.SuspendLayout();
            this.menuOperations.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuTbwMethods_menuPayment_Term___);
            this.commandManager.Commands.Add(this.menuTbwMethods_menuTranslation___);
            this.commandManager.Commands.Add(this.menuTbwMethods_menuPayment_Vacation_Days___);
            this.commandManager.Commands.Add(this.menuTbwMethods_menuChange__Company___);
            this.commandManager.Commands.Add(this.menuOperations_menuTranslation___);
            this.commandManager.Commands.Add(this.menuOperations_menuChange__Company___);
            this.commandManager.ContextMenus.Add(this.menuTbwMethods);
            this.commandManager.ContextMenus.Add(this.menuOperations);
            // 
            // menuOperations_menuTranslation___
            // 
            resources.ApplyResources(this.menuOperations_menuTranslation___, "menuOperations_menuTranslation___");
            this.menuOperations_menuTranslation___.Name = "menuOperations_menuTranslation___";
            this.menuOperations_menuTranslation___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Translation_1_Execute);
            this.menuOperations_menuTranslation___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Translation_1_Inquire);
            // 
            // menuOperations_menuChange__Company___
            // 
            resources.ApplyResources(this.menuOperations_menuChange__Company___, "menuOperations_menuChange__Company___");
            this.menuOperations_menuChange__Company___.Name = "menuOperations_menuChange__Company___";
            this.menuOperations_menuChange__Company___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Change_1_Execute);
            this.menuOperations_menuChange__Company___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Change_1_Inquire);
            // 
            // menuTbwMethods_menuPayment_Term___
            // 
            resources.ApplyResources(this.menuTbwMethods_menuPayment_Term___, "menuTbwMethods_menuPayment_Term___");
            this.menuTbwMethods_menuPayment_Term___.Name = "menuTbwMethods_menuPayment_Term___";
            this.menuTbwMethods_menuPayment_Term___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Payment_Execute);
            this.menuTbwMethods_menuPayment_Term___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Payment_Inquire);
            // 
            // menuTbwMethods_menuTranslation___
            // 
            resources.ApplyResources(this.menuTbwMethods_menuTranslation___, "menuTbwMethods_menuTranslation___");
            this.menuTbwMethods_menuTranslation___.Name = "menuTbwMethods_menuTranslation___";
            this.menuTbwMethods_menuTranslation___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Translation_Execute);
            this.menuTbwMethods_menuTranslation___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Translation_Inquire);
            // 
            // menuTbwMethods_menuPayment_Vacation_Days___
            // 
            resources.ApplyResources(this.menuTbwMethods_menuPayment_Vacation_Days___, "menuTbwMethods_menuPayment_Vacation_Days___");
            this.menuTbwMethods_menuPayment_Vacation_Days___.Name = "menuTbwMethods_menuPayment_Vacation_Days___";
            this.menuTbwMethods_menuPayment_Vacation_Days___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Payment_1_Execute);
            this.menuTbwMethods_menuPayment_Vacation_Days___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Payment_1_Inquire);
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
            resources.ApplyResources(this.colCompany, "colCompany");
            this.colCompany.Name = "colCompany";
            this.colCompany.NamedProperties.Put("EnumerateMethod", "");
            this.colCompany.NamedProperties.Put("FieldFlags", "67");
            this.colCompany.NamedProperties.Put("LovReference", "COMPANY_INVOICE_INFO");
            this.colCompany.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.colCompany.Position = 3;
            // 
            // colPayTermId
            // 
            this.colPayTermId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colPayTermId.MaxLength = 20;
            this.colPayTermId.Name = "colPayTermId";
            this.colPayTermId.NamedProperties.Put("EnumerateMethod", "");
            this.colPayTermId.NamedProperties.Put("FieldFlags", "163");
            this.colPayTermId.NamedProperties.Put("LovReference", "");
            this.colPayTermId.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colPayTermId.NamedProperties.Put("SqlColumn", "PAY_TERM_ID");
            this.colPayTermId.Position = 4;
            resources.ApplyResources(this.colPayTermId, "colPayTermId");
            // 
            // colDescription
            // 
            this.colDescription.Name = "colDescription";
            this.colDescription.NamedProperties.Put("EnumerateMethod", "");
            this.colDescription.NamedProperties.Put("FieldFlags", "295");
            this.colDescription.NamedProperties.Put("LovReference", "");
            this.colDescription.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colDescription.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            this.colDescription.NamedProperties.Put("ValidateMethod", "");
            this.colDescription.Position = 5;
            resources.ApplyResources(this.colDescription, "colDescription");
            // 
            // colsUseCommercialYear
            // 
            this.colsUseCommercialYear.Name = "colsUseCommercialYear";
            this.colsUseCommercialYear.NamedProperties.Put("EnumerateMethod", "");
            this.colsUseCommercialYear.NamedProperties.Put("FieldFlags", "294");
            this.colsUseCommercialYear.NamedProperties.Put("LovReference", "");
            this.colsUseCommercialYear.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsUseCommercialYear.NamedProperties.Put("ResizeableChildObject", "");
            this.colsUseCommercialYear.NamedProperties.Put("SqlColumn", "USE_COMMERCIAL_YEAR");
            this.colsUseCommercialYear.NamedProperties.Put("ValidateMethod", "");
            this.colsUseCommercialYear.Position = 6;
            resources.ApplyResources(this.colsUseCommercialYear, "colsUseCommercialYear");
            // 
            // colsVatDistribution
            // 
            this.colsVatDistribution.MaxLength = 200;
            this.colsVatDistribution.Name = "colsVatDistribution";
            this.colsVatDistribution.NamedProperties.Put("EnumerateMethod", "VAT_DISTRIBUTION_API.Enumerate");
            this.colsVatDistribution.NamedProperties.Put("FieldFlags", "295");
            this.colsVatDistribution.NamedProperties.Put("LovReference", "");
            this.colsVatDistribution.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsVatDistribution.NamedProperties.Put("ResizeableChildObject", "");
            this.colsVatDistribution.NamedProperties.Put("SqlColumn", "VAT_DISTRIBUTION");
            this.colsVatDistribution.NamedProperties.Put("ValidateMethod", "");
            this.colsVatDistribution.Position = 7;
            resources.ApplyResources(this.colsVatDistribution, "colsVatDistribution");
            this.colsVatDistribution.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsVatDistribution_WindowActions);
            // 
            // colsConsiderPayVacPeriod
            // 
            this.colsConsiderPayVacPeriod.Name = "colsConsiderPayVacPeriod";
            this.colsConsiderPayVacPeriod.NamedProperties.Put("EnumerateMethod", "");
            this.colsConsiderPayVacPeriod.NamedProperties.Put("FieldFlags", "294");
            this.colsConsiderPayVacPeriod.NamedProperties.Put("LovReference", "");
            this.colsConsiderPayVacPeriod.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsConsiderPayVacPeriod.NamedProperties.Put("ResizeableChildObject", "");
            this.colsConsiderPayVacPeriod.NamedProperties.Put("SqlColumn", "CONSIDER_PAY_VAC_PERIOD");
            this.colsConsiderPayVacPeriod.NamedProperties.Put("ValidateMethod", "");
            this.colsConsiderPayVacPeriod.Position = 8;
            resources.ApplyResources(this.colsConsiderPayVacPeriod, "colsConsiderPayVacPeriod");
            // 
            // colBlockForDirectDebiting
            // 
            this.colBlockForDirectDebiting.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colBlockForDirectDebiting.MaxLength = 5;
            this.colBlockForDirectDebiting.Name = "colBlockForDirectDebiting";
            this.colBlockForDirectDebiting.NamedProperties.Put("EnumerateMethod", "");
            this.colBlockForDirectDebiting.NamedProperties.Put("FieldFlags", "295");
            this.colBlockForDirectDebiting.NamedProperties.Put("LovReference", "");
            this.colBlockForDirectDebiting.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colBlockForDirectDebiting.NamedProperties.Put("ResizeableChildObject", "");
            this.colBlockForDirectDebiting.NamedProperties.Put("SqlColumn", "BLOCK_FOR_DIRECT_DEBITING");
            this.colBlockForDirectDebiting.NamedProperties.Put("ValidateMethod", "");
            this.colBlockForDirectDebiting.Position = 9;
            resources.ApplyResources(this.colBlockForDirectDebiting, "colBlockForDirectDebiting");
            // 
            // colsExcludeCreditLimit
            // 
            this.colsExcludeCreditLimit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsExcludeCreditLimit.MaxLength = 5;
            this.colsExcludeCreditLimit.Name = "colsExcludeCreditLimit";
            this.colsExcludeCreditLimit.NamedProperties.Put("EnumerateMethod", "");
            this.colsExcludeCreditLimit.NamedProperties.Put("FieldFlags", "295");
            this.colsExcludeCreditLimit.NamedProperties.Put("LovReference", "");
            this.colsExcludeCreditLimit.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsExcludeCreditLimit.NamedProperties.Put("ResizeableChildObject", "");
            this.colsExcludeCreditLimit.NamedProperties.Put("SqlColumn", "EXCLUDE_CREDIT_LIMIT");
            this.colsExcludeCreditLimit.NamedProperties.Put("ValidateMethod", "");
            this.colsExcludeCreditLimit.Position = 10;
            resources.ApplyResources(this.colsExcludeCreditLimit, "colsExcludeCreditLimit");
            // 
            // colsSuppressAmount
            // 
            this.colsSuppressAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsSuppressAmount.MaxLength = 5;
            this.colsSuppressAmount.Name = "colsSuppressAmount";
            this.colsSuppressAmount.NamedProperties.Put("EnumerateMethod", "");
            this.colsSuppressAmount.NamedProperties.Put("FieldFlags", "295");
            this.colsSuppressAmount.NamedProperties.Put("LovReference", "");
            this.colsSuppressAmount.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsSuppressAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.colsSuppressAmount.NamedProperties.Put("SqlColumn", "SUPPRESS_AMOUNT");
            this.colsSuppressAmount.NamedProperties.Put("ValidateMethod", "");
            this.colsSuppressAmount.Position = 11;
            resources.ApplyResources(this.colsSuppressAmount, "colsSuppressAmount");
            // 
            // menuTbwMethods
            // 
            this.menuTbwMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_Payment,
            this.menuItem_Translation,
            this.menuItem_Payment_1,
            this.menuSeparator1,
            this.menuItem_Change});
            this.menuTbwMethods.Name = "menuTbwMethods";
            resources.ApplyResources(this.menuTbwMethods, "menuTbwMethods");
            // 
            // menuItem_Payment
            // 
            this.menuItem_Payment.Command = this.menuTbwMethods_menuPayment_Term___;
            this.menuItem_Payment.Name = "menuItem_Payment";
            resources.ApplyResources(this.menuItem_Payment, "menuItem_Payment");
            this.menuItem_Payment.Text = "Payment Term...";
            // 
            // menuItem_Translation
            // 
            this.menuItem_Translation.Command = this.menuTbwMethods_menuTranslation___;
            this.menuItem_Translation.Name = "menuItem_Translation";
            resources.ApplyResources(this.menuItem_Translation, "menuItem_Translation");
            this.menuItem_Translation.Text = "Translation...";
            // 
            // menuItem_Payment_1
            // 
            this.menuItem_Payment_1.Command = this.menuTbwMethods_menuPayment_Vacation_Days___;
            this.menuItem_Payment_1.Name = "menuItem_Payment_1";
            resources.ApplyResources(this.menuItem_Payment_1, "menuItem_Payment_1");
            this.menuItem_Payment_1.Text = "Payment Vacation Days...";
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
            this.menuItem_Translation_1,
            this.menuSeparator2,
            this.menuItem_Change_1});
            this.menuOperations.Name = "menuOperations";
            resources.ApplyResources(this.menuOperations, "menuOperations");
            // 
            // menuItem_Translation_1
            // 
            this.menuItem_Translation_1.Command = this.menuOperations_menuTranslation___;
            this.menuItem_Translation_1.Name = "menuItem_Translation_1";
            resources.ApplyResources(this.menuItem_Translation_1, "menuItem_Translation_1");
            this.menuItem_Translation_1.Text = "Translation...";
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
            // colsCashDiscFixassAcqValueDb
            // 
            this.colsCashDiscFixassAcqValueDb.MaxLength = 20;
            this.colsCashDiscFixassAcqValueDb.Name = "colsCashDiscFixassAcqValueDb";
            this.colsCashDiscFixassAcqValueDb.NamedProperties.Put("EnumerateMethod", "");
            this.colsCashDiscFixassAcqValueDb.NamedProperties.Put("FieldFlags", "294");
            this.colsCashDiscFixassAcqValueDb.NamedProperties.Put("LovReference", "");
            this.colsCashDiscFixassAcqValueDb.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsCashDiscFixassAcqValueDb.NamedProperties.Put("SqlColumn", "CASH_DISC_FIXASS_ACQ_VALUE_DB");
            this.colsCashDiscFixassAcqValueDb.Position = 12;
            resources.ApplyResources(this.colsCashDiscFixassAcqValueDb, "colsCashDiscFixassAcqValueDb");
            this.colsCashDiscFixassAcqValueDb.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tableWindow_colsCashDiscFixassAcqValueDb_WindowActions);
            // 
            // tbwPaymentTerm
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colCompany);
            this.Controls.Add(this.colPayTermId);
            this.Controls.Add(this.colDescription);
            this.Controls.Add(this.colsUseCommercialYear);
            this.Controls.Add(this.colsVatDistribution);
            this.Controls.Add(this.colsConsiderPayVacPeriod);
            this.Controls.Add(this.colBlockForDirectDebiting);
            this.Controls.Add(this.colsExcludeCreditLimit);
            this.Controls.Add(this.colsSuppressAmount);
            this.Controls.Add(this.colsCashDiscFixassAcqValueDb);
            this.Name = "tbwPaymentTerm";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "COMPANY= :i_hWndFrame.tbwPaymentTerm.i_sCompany");
            this.NamedProperties.Put("LogicalUnit", "PaymentTerm");
            this.NamedProperties.Put("PackageName", "PAYMENT_TERM_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "0");
            this.NamedProperties.Put("SourceFlags", "449");
            this.NamedProperties.Put("ViewName", "PAYMENT_TERM");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.Controls.SetChildIndex(this.colsCashDiscFixassAcqValueDb, 0);
            this.Controls.SetChildIndex(this.colsSuppressAmount, 0);
            this.Controls.SetChildIndex(this.colsExcludeCreditLimit, 0);
            this.Controls.SetChildIndex(this.colBlockForDirectDebiting, 0);
            this.Controls.SetChildIndex(this.colsConsiderPayVacPeriod, 0);
            this.Controls.SetChildIndex(this.colsVatDistribution, 0);
            this.Controls.SetChildIndex(this.colsUseCommercialYear, 0);
            this.Controls.SetChildIndex(this.colDescription, 0);
            this.Controls.SetChildIndex(this.colPayTermId, 0);
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

        public Fnd.Windows.Forms.FndCommand menuOperations_menuTranslation___;
        public Fnd.Windows.Forms.FndCommand menuOperations_menuChange__Company___;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menuPayment_Term___;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menuTranslation___;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menuPayment_Vacation_Days___;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menuChange__Company___;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTbwMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Payment;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Translation;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Payment_1;
        protected Fnd.Windows.Forms.FndToolStripSeparator menuSeparator1;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuOperations;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Translation_1;
        protected Fnd.Windows.Forms.FndToolStripSeparator menuSeparator2;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change_1;
        protected cCheckBoxColumn colsCashDiscFixassAcqValueDb;
	}
}
