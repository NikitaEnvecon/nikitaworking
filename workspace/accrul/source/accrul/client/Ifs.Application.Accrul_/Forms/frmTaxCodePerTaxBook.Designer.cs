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
	
	public partial class frmTaxCodePerTaxBook
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		// Bug 83845, Begin. Make the height of cmbTaxBookId and dfsDescription to class default
		protected cBackgroundText labeldfsCompany;
		public cDataField dfsCompany;
		protected cBackgroundText labelcmbTaxBookId;
		public cRecSelComboBoxFin cmbTaxBookId;
		protected cBackgroundText labeldfsDescription;
		public cDataField dfsDescription;
        // Bug 83845, End
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTaxCodePerTaxBook));
            this.labeldfsCompany = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsCompany = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelcmbTaxBookId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbTaxBookId = new Ifs.Application.Accrul.cRecSelComboBoxFin();
            this.labeldfsDescription = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsDescription = new Ifs.Fnd.ApplicationForms.cDataField();
            this.tblTaxCode = new Ifs.Application.Accrul.cChildTableFin();
            this.tblTaxCode_colsCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblTaxCode_colsTaxBookId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblTaxCode_colsFeeCode = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblTaxCode_colStatutoryFeeDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblTaxCode.SuspendLayout();
            this.SuspendLayout();
            // 
            // labeldfsCompany
            // 
            resources.ApplyResources(this.labeldfsCompany, "labeldfsCompany");
            this.labeldfsCompany.Name = "labeldfsCompany";
            // 
            // dfsCompany
            // 
            this.dfsCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsCompany, "dfsCompany");
            this.dfsCompany.Name = "dfsCompany";
            this.dfsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.dfsCompany.NamedProperties.Put("FieldFlags", "67");
            this.dfsCompany.NamedProperties.Put("LovReference", "COMPANY_FINANCE");
            this.dfsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            // 
            // labelcmbTaxBookId
            // 
            resources.ApplyResources(this.labelcmbTaxBookId, "labelcmbTaxBookId");
            this.labelcmbTaxBookId.Name = "labelcmbTaxBookId";
            // 
            // cmbTaxBookId
            // 
            resources.ApplyResources(this.cmbTaxBookId, "cmbTaxBookId");
            this.cmbTaxBookId.Name = "cmbTaxBookId";
            this.cmbTaxBookId.NamedProperties.Put("EnumerateMethod", "");
            this.cmbTaxBookId.NamedProperties.Put("FieldFlags", "163");
            this.cmbTaxBookId.NamedProperties.Put("Format", "9");
            this.cmbTaxBookId.NamedProperties.Put("LovReference", "");
            this.cmbTaxBookId.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbTaxBookId.NamedProperties.Put("SqlColumn", "TAX_BOOK_ID");
            this.cmbTaxBookId.NamedProperties.Put("ValidateMethod", "");
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
            this.dfsDescription.NamedProperties.Put("FieldFlags", "295");
            this.dfsDescription.NamedProperties.Put("LovReference", "");
            this.dfsDescription.NamedProperties.Put("ParentName", "cmbTaxBookId");
            this.dfsDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsDescription.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            this.dfsDescription.NamedProperties.Put("ValidateMethod", "");
            // 
            // tblTaxCode
            // 
            this.tblTaxCode.Controls.Add(this.tblTaxCode_colsCompany);
            this.tblTaxCode.Controls.Add(this.tblTaxCode_colsTaxBookId);
            this.tblTaxCode.Controls.Add(this.tblTaxCode_colsFeeCode);
            this.tblTaxCode.Controls.Add(this.tblTaxCode_colStatutoryFeeDescription);
            resources.ApplyResources(this.tblTaxCode, "tblTaxCode");
            this.tblTaxCode.Name = "tblTaxCode";
            this.tblTaxCode.NamedProperties.Put("DefaultOrderBy", "");
            this.tblTaxCode.NamedProperties.Put("DefaultWhere", "");
            this.tblTaxCode.NamedProperties.Put("LogicalUnit", "TaxCodePerTaxBook");
            this.tblTaxCode.NamedProperties.Put("PackageName", "TAX_CODE_PER_TAX_BOOK_API");
            this.tblTaxCode.NamedProperties.Put("ResizeableChildObject", "LLMM");
            this.tblTaxCode.NamedProperties.Put("ViewName", "TAX_CODE_PER_TAX_BOOK");
            this.tblTaxCode.NamedProperties.Put("Warnings", "FALSE");
            this.tblTaxCode.Controls.SetChildIndex(this.tblTaxCode_colStatutoryFeeDescription, 0);
            this.tblTaxCode.Controls.SetChildIndex(this.tblTaxCode_colsFeeCode, 0);
            this.tblTaxCode.Controls.SetChildIndex(this.tblTaxCode_colsTaxBookId, 0);
            this.tblTaxCode.Controls.SetChildIndex(this.tblTaxCode_colsCompany, 0);
            // 
            // tblTaxCode_colsCompany
            // 
            this.tblTaxCode_colsCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblTaxCode_colsCompany, "tblTaxCode_colsCompany");
            this.tblTaxCode_colsCompany.MaxLength = 20;
            this.tblTaxCode_colsCompany.Name = "tblTaxCode_colsCompany";
            this.tblTaxCode_colsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.tblTaxCode_colsCompany.NamedProperties.Put("FieldFlags", "67");
            this.tblTaxCode_colsCompany.NamedProperties.Put("LovReference", "");
            this.tblTaxCode_colsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.tblTaxCode_colsCompany.Position = 3;
            // 
            // tblTaxCode_colsTaxBookId
            // 
            resources.ApplyResources(this.tblTaxCode_colsTaxBookId, "tblTaxCode_colsTaxBookId");
            this.tblTaxCode_colsTaxBookId.MaxLength = 10;
            this.tblTaxCode_colsTaxBookId.Name = "tblTaxCode_colsTaxBookId";
            this.tblTaxCode_colsTaxBookId.NamedProperties.Put("EnumerateMethod", "");
            this.tblTaxCode_colsTaxBookId.NamedProperties.Put("FieldFlags", "67");
            this.tblTaxCode_colsTaxBookId.NamedProperties.Put("LovReference", "TAX_BOOK(COMPANY)");
            this.tblTaxCode_colsTaxBookId.NamedProperties.Put("SqlColumn", "TAX_BOOK_ID");
            this.tblTaxCode_colsTaxBookId.Position = 4;
            // 
            // tblTaxCode_colsFeeCode
            // 
            this.tblTaxCode_colsFeeCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblTaxCode_colsFeeCode.MaxLength = 20;
            this.tblTaxCode_colsFeeCode.Name = "tblTaxCode_colsFeeCode";
            this.tblTaxCode_colsFeeCode.NamedProperties.Put("EnumerateMethod", "");
            this.tblTaxCode_colsFeeCode.NamedProperties.Put("FieldFlags", "167");
            this.tblTaxCode_colsFeeCode.NamedProperties.Put("LovReference", "STATUTORY_FEE_DEDUCTIBLE(COMPANY)");
            this.tblTaxCode_colsFeeCode.NamedProperties.Put("ResizeableChildObject", "");
            this.tblTaxCode_colsFeeCode.NamedProperties.Put("SqlColumn", "FEE_CODE");
            this.tblTaxCode_colsFeeCode.NamedProperties.Put("ValidateMethod", "");
            this.tblTaxCode_colsFeeCode.Position = 5;
            resources.ApplyResources(this.tblTaxCode_colsFeeCode, "tblTaxCode_colsFeeCode");
            // 
            // tblTaxCode_colStatutoryFeeDescription
            // 
            this.tblTaxCode_colStatutoryFeeDescription.MaxLength = 2000;
            this.tblTaxCode_colStatutoryFeeDescription.Name = "tblTaxCode_colStatutoryFeeDescription";
            this.tblTaxCode_colStatutoryFeeDescription.NamedProperties.Put("EnumerateMethod", "");
            this.tblTaxCode_colStatutoryFeeDescription.NamedProperties.Put("FieldFlags", "304");
            this.tblTaxCode_colStatutoryFeeDescription.NamedProperties.Put("LovReference", "");
            this.tblTaxCode_colStatutoryFeeDescription.NamedProperties.Put("ParentName", "tblTaxCode.tblTaxCode_colsFeeCode");
            this.tblTaxCode_colStatutoryFeeDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.tblTaxCode_colStatutoryFeeDescription.NamedProperties.Put("SqlColumn", "STATUTORY_FEE_API.Get_Description(company,FEE_CODE)");
            this.tblTaxCode_colStatutoryFeeDescription.NamedProperties.Put("ValidateMethod", "");
            this.tblTaxCode_colStatutoryFeeDescription.Position = 6;
            resources.ApplyResources(this.tblTaxCode_colStatutoryFeeDescription, "tblTaxCode_colStatutoryFeeDescription");
            // 
            // frmTaxCodePerTaxBook
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.tblTaxCode);
            this.Controls.Add(this.dfsDescription);
            this.Controls.Add(this.cmbTaxBookId);
            this.Controls.Add(this.dfsCompany);
            this.Controls.Add(this.labeldfsDescription);
            this.Controls.Add(this.labelcmbTaxBookId);
            this.Controls.Add(this.labeldfsCompany);
            this.Name = "frmTaxCodePerTaxBook";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "Company = :i_hWndFrame.frmTaxCodePerTaxBook.sCompany \r\nAND Tax_Code_Db = \'RESTRIC" +
                    "TED\'");
            this.NamedProperties.Put("LogicalUnit", "TaxBook");
            this.NamedProperties.Put("PackageName", "TAX_BOOK_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "1");
            this.NamedProperties.Put("ViewName", "TAX_BOOK");
            this.NamedProperties.Put("Warnings", "TRUE");
            this.tblTaxCode.ResumeLayout(false);
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

        public cChildTableFin tblTaxCode;
        protected cColumn tblTaxCode_colsCompany;
        protected cColumn tblTaxCode_colsTaxBookId;
        protected cColumn tblTaxCode_colsFeeCode;
        protected cColumn tblTaxCode_colStatutoryFeeDescription;
		
	}
}
