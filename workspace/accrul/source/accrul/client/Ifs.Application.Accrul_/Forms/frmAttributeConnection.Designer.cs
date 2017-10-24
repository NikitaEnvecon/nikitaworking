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
	
	public partial class frmAttributeConnection
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		protected cBackgroundText labeldfsCompany;
		public cDataField dfsCompany;
		protected cBackgroundText labelcmbAttribute;
		// Bug 83857, Begin, Checked F1 property queryable
		public cRecSelComboBoxFin cmbAttribute;
		// Bug 83857, End
		protected cBackgroundText labeldfsDescription;
		public cDataField dfsDescription;
		// Bug 83782 Begin , changed Object Title
		protected cBackgroundText labeldfsCodeName;
		public cDataField dfsCodeName;
		// Bug 83782 End
		protected cBackgroundText labeldfsCodePart;
		public cDataField dfsCodePart;
        // Bug 73298 Begin - Changed the derived base class.
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAttributeConnection));
            this.labeldfsCompany = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsCompany = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelcmbAttribute = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbAttribute = new Ifs.Application.Accrul.cRecSelComboBoxFin();
            this.labeldfsDescription = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsDescription = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsCodeName = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsCodeName = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsCodePart = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsCodePart = new Ifs.Fnd.ApplicationForms.cDataField();
            this.tblCodePartValues = new Ifs.Application.Accrul.cChildTableFinBase();
            this.tblCodePartValues_colsCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblCodePartValues_colsAttribute = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblCodePartValues_colsCodePart = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblCodePartValues_colsCodePartValue = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblCodePartValues_colsCodePartValueDesc = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblCodePartValues_colsAttributeValue = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblCodePartValues_colsAttributeValueDesc = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblCodePartValues.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.ImageList = null;
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
            this.dfsCompany.NamedProperties.Put("FieldFlags", "65");
            this.dfsCompany.NamedProperties.Put("LovReference", "COMPANY_FINANCE");
            this.dfsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.dfsCompany.NamedProperties.Put("ValidateMethod", "");
            // 
            // labelcmbAttribute
            // 
            resources.ApplyResources(this.labelcmbAttribute, "labelcmbAttribute");
            this.labelcmbAttribute.Name = "labelcmbAttribute";
            // 
            // cmbAttribute
            // 
            resources.ApplyResources(this.cmbAttribute, "cmbAttribute");
            this.cmbAttribute.Name = "cmbAttribute";
            this.cmbAttribute.NamedProperties.Put("EnumerateMethod", "");
            this.cmbAttribute.NamedProperties.Put("FieldFlags", "289");
            this.cmbAttribute.NamedProperties.Put("LovReference", "ACCOUNTING_ATTRIBUTE(COMPANY)");
            this.cmbAttribute.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbAttribute.NamedProperties.Put("SqlColumn", "ATTRIBUTE");
            this.cmbAttribute.NamedProperties.Put("ValidateMethod", "");
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
            this.dfsDescription.NamedProperties.Put("ParentName", "cmbAttribute");
            this.dfsDescription.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            this.dfsDescription.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsCodeName
            // 
            resources.ApplyResources(this.labeldfsCodeName, "labeldfsCodeName");
            this.labeldfsCodeName.Name = "labeldfsCodeName";
            // 
            // dfsCodeName
            // 
            resources.ApplyResources(this.dfsCodeName, "dfsCodeName");
            this.dfsCodeName.Name = "dfsCodeName";
            this.dfsCodeName.NamedProperties.Put("EnumerateMethod", "");
            this.dfsCodeName.NamedProperties.Put("FieldFlags", "290");
            this.dfsCodeName.NamedProperties.Put("LovReference", "ACCOUNTING_CODE_PARTS_USED2(COMPANY,CODE_PART)");
            this.dfsCodeName.NamedProperties.Put("ParentName", "cmbAttribute");
            this.dfsCodeName.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsCodeName.NamedProperties.Put("SqlColumn", "CODE_NAME");
            this.dfsCodeName.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsCodePart
            // 
            resources.ApplyResources(this.labeldfsCodePart, "labeldfsCodePart");
            this.labeldfsCodePart.Name = "labeldfsCodePart";
            // 
            // dfsCodePart
            // 
            resources.ApplyResources(this.dfsCodePart, "dfsCodePart");
            this.dfsCodePart.Name = "dfsCodePart";
            this.dfsCodePart.NamedProperties.Put("EnumerateMethod", "");
            this.dfsCodePart.NamedProperties.Put("FieldFlags", "259");
            this.dfsCodePart.NamedProperties.Put("LovReference", "ACCOUNTING_CODE_PARTS(COMPANY)");
            this.dfsCodePart.NamedProperties.Put("ParentName", "cmbAttribute");
            this.dfsCodePart.NamedProperties.Put("SqlColumn", "CODE_PART");
            this.dfsCodePart.NamedProperties.Put("ValidateMethod", "");
            // 
            // tblCodePartValues
            // 
            this.tblCodePartValues.Controls.Add(this.tblCodePartValues_colsCompany);
            this.tblCodePartValues.Controls.Add(this.tblCodePartValues_colsAttribute);
            this.tblCodePartValues.Controls.Add(this.tblCodePartValues_colsCodePart);
            this.tblCodePartValues.Controls.Add(this.tblCodePartValues_colsCodePartValue);
            this.tblCodePartValues.Controls.Add(this.tblCodePartValues_colsCodePartValueDesc);
            this.tblCodePartValues.Controls.Add(this.tblCodePartValues_colsAttributeValue);
            this.tblCodePartValues.Controls.Add(this.tblCodePartValues_colsAttributeValueDesc);
            resources.ApplyResources(this.tblCodePartValues, "tblCodePartValues");
            this.tblCodePartValues.Name = "tblCodePartValues";
            this.tblCodePartValues.NamedProperties.Put("DefaultOrderBy", "");
            this.tblCodePartValues.NamedProperties.Put("DefaultWhere", "");
            this.tblCodePartValues.NamedProperties.Put("LogicalUnit", "AccountingAttributeCon");
            this.tblCodePartValues.NamedProperties.Put("PackageName", "ACCOUNTING_ATTRIBUTE_CON_API");
            this.tblCodePartValues.NamedProperties.Put("ResizeableChildObject", "LLRR");
            this.tblCodePartValues.NamedProperties.Put("SourceFlags", "129");
            this.tblCodePartValues.NamedProperties.Put("ViewName", "ACCOUNTING_ATTRIBUTE_CON2");
            this.tblCodePartValues.NamedProperties.Put("Warnings", "FALSE");
            this.tblCodePartValues.DataRecordExecuteModifyEvent += new Ifs.Fnd.ApplicationForms.cDataSource.DataRecordExecuteModifyEventHandler(this.tblCodePartValues_DataRecordExecuteModifyEvent);
            this.tblCodePartValues.Controls.SetChildIndex(this.tblCodePartValues_colsAttributeValueDesc, 0);
            this.tblCodePartValues.Controls.SetChildIndex(this.tblCodePartValues_colsAttributeValue, 0);
            this.tblCodePartValues.Controls.SetChildIndex(this.tblCodePartValues_colsCodePartValueDesc, 0);
            this.tblCodePartValues.Controls.SetChildIndex(this.tblCodePartValues_colsCodePartValue, 0);
            this.tblCodePartValues.Controls.SetChildIndex(this.tblCodePartValues_colsCodePart, 0);
            this.tblCodePartValues.Controls.SetChildIndex(this.tblCodePartValues_colsAttribute, 0);
            this.tblCodePartValues.Controls.SetChildIndex(this.tblCodePartValues_colsCompany, 0);
            // 
            // tblCodePartValues_colsCompany
            // 
            this.tblCodePartValues_colsCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblCodePartValues_colsCompany, "tblCodePartValues_colsCompany");
            this.tblCodePartValues_colsCompany.MaxLength = 20;
            this.tblCodePartValues_colsCompany.Name = "tblCodePartValues_colsCompany";
            this.tblCodePartValues_colsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.tblCodePartValues_colsCompany.NamedProperties.Put("FieldFlags", "67");
            this.tblCodePartValues_colsCompany.NamedProperties.Put("LovReference", "");
            this.tblCodePartValues_colsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.tblCodePartValues_colsCompany.NamedProperties.Put("ValidateMethod", "");
            this.tblCodePartValues_colsCompany.Position = 3;
            // 
            // tblCodePartValues_colsAttribute
            // 
            this.tblCodePartValues_colsAttribute.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblCodePartValues_colsAttribute, "tblCodePartValues_colsAttribute");
            this.tblCodePartValues_colsAttribute.MaxLength = 20;
            this.tblCodePartValues_colsAttribute.Name = "tblCodePartValues_colsAttribute";
            this.tblCodePartValues_colsAttribute.NamedProperties.Put("EnumerateMethod", "");
            this.tblCodePartValues_colsAttribute.NamedProperties.Put("FieldFlags", "67");
            this.tblCodePartValues_colsAttribute.NamedProperties.Put("LovReference", "ACCOUNTING_ATTRIBUTE(COMPANY)");
            this.tblCodePartValues_colsAttribute.NamedProperties.Put("SqlColumn", "ATTRIBUTE");
            this.tblCodePartValues_colsAttribute.NamedProperties.Put("ValidateMethod", "");
            this.tblCodePartValues_colsAttribute.Position = 4;
            // 
            // tblCodePartValues_colsCodePart
            // 
            this.tblCodePartValues_colsCodePart.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblCodePartValues_colsCodePart, "tblCodePartValues_colsCodePart");
            this.tblCodePartValues_colsCodePart.MaxLength = 1;
            this.tblCodePartValues_colsCodePart.Name = "tblCodePartValues_colsCodePart";
            this.tblCodePartValues_colsCodePart.NamedProperties.Put("EnumerateMethod", "");
            this.tblCodePartValues_colsCodePart.NamedProperties.Put("FieldFlags", "67");
            this.tblCodePartValues_colsCodePart.NamedProperties.Put("LovReference", "");
            this.tblCodePartValues_colsCodePart.NamedProperties.Put("SqlColumn", "CODE_PART");
            this.tblCodePartValues_colsCodePart.NamedProperties.Put("ValidateMethod", "");
            this.tblCodePartValues_colsCodePart.Position = 5;
            // 
            // tblCodePartValues_colsCodePartValue
            // 
            this.tblCodePartValues_colsCodePartValue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblCodePartValues_colsCodePartValue.MaxLength = 20;
            this.tblCodePartValues_colsCodePartValue.Name = "tblCodePartValues_colsCodePartValue";
            this.tblCodePartValues_colsCodePartValue.NamedProperties.Put("EnumerateMethod", "");
            this.tblCodePartValues_colsCodePartValue.NamedProperties.Put("FieldFlags", "163");
            this.tblCodePartValues_colsCodePartValue.NamedProperties.Put("LovReference", "ACCOUNTING_CODEPART_VAL_FINREP(COMPANY,CODE_PART)");
            this.tblCodePartValues_colsCodePartValue.NamedProperties.Put("ResizeableChildObject", "");
            this.tblCodePartValues_colsCodePartValue.NamedProperties.Put("SqlColumn", "CODE_PART_VALUE");
            this.tblCodePartValues_colsCodePartValue.NamedProperties.Put("ValidateMethod", "");
            this.tblCodePartValues_colsCodePartValue.Position = 6;
            resources.ApplyResources(this.tblCodePartValues_colsCodePartValue, "tblCodePartValues_colsCodePartValue");
            // 
            // tblCodePartValues_colsCodePartValueDesc
            // 
            this.tblCodePartValues_colsCodePartValueDesc.Name = "tblCodePartValues_colsCodePartValueDesc";
            this.tblCodePartValues_colsCodePartValueDesc.NamedProperties.Put("EnumerateMethod", "");
            this.tblCodePartValues_colsCodePartValueDesc.NamedProperties.Put("FieldFlags", "288");
            this.tblCodePartValues_colsCodePartValueDesc.NamedProperties.Put("LovReference", "");
            this.tblCodePartValues_colsCodePartValueDesc.NamedProperties.Put("SqlColumn", "ACCOUNTING_CODE_PART_VALUE_API.Get_Description(company,code_part,CODE_PART_VALUE)" +
                    "");
            this.tblCodePartValues_colsCodePartValueDesc.NamedProperties.Put("ValidateMethod", "");
            this.tblCodePartValues_colsCodePartValueDesc.Position = 7;
            resources.ApplyResources(this.tblCodePartValues_colsCodePartValueDesc, "tblCodePartValues_colsCodePartValueDesc");
            // 
            // tblCodePartValues_colsAttributeValue
            // 
            this.tblCodePartValues_colsAttributeValue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblCodePartValues_colsAttributeValue.Name = "tblCodePartValues_colsAttributeValue";
            this.tblCodePartValues_colsAttributeValue.NamedProperties.Put("EnumerateMethod", "");
            this.tblCodePartValues_colsAttributeValue.NamedProperties.Put("FieldFlags", "292");
            this.tblCodePartValues_colsAttributeValue.NamedProperties.Put("LovReference", "ACCOUNTING_ATTRIBUTE_VALUE(COMPANY,ATTRIBUTE)");
            this.tblCodePartValues_colsAttributeValue.NamedProperties.Put("ResizeableChildObject", "");
            this.tblCodePartValues_colsAttributeValue.NamedProperties.Put("SqlColumn", "ATTRIBUTE_VALUE");
            this.tblCodePartValues_colsAttributeValue.NamedProperties.Put("ValidateMethod", "");
            this.tblCodePartValues_colsAttributeValue.Position = 8;
            resources.ApplyResources(this.tblCodePartValues_colsAttributeValue, "tblCodePartValues_colsAttributeValue");
            // 
            // tblCodePartValues_colsAttributeValueDesc
            // 
            this.tblCodePartValues_colsAttributeValueDesc.MaxLength = 2000;
            this.tblCodePartValues_colsAttributeValueDesc.Name = "tblCodePartValues_colsAttributeValueDesc";
            this.tblCodePartValues_colsAttributeValueDesc.NamedProperties.Put("EnumerateMethod", "");
            this.tblCodePartValues_colsAttributeValueDesc.NamedProperties.Put("FieldFlags", "288");
            this.tblCodePartValues_colsAttributeValueDesc.NamedProperties.Put("LovReference", "");
            this.tblCodePartValues_colsAttributeValueDesc.NamedProperties.Put("ParentName", "tblCodePartValues.tblCodePartValues_colsAttributeValue");
            this.tblCodePartValues_colsAttributeValueDesc.NamedProperties.Put("SqlColumn", "ACCOUNTING_ATTRIBUTE_VALUE_API.Get_Desc(company,attribute,ATTRIBUTE_VALUE)");
            this.tblCodePartValues_colsAttributeValueDesc.NamedProperties.Put("ValidateMethod", "");
            this.tblCodePartValues_colsAttributeValueDesc.Position = 9;
            resources.ApplyResources(this.tblCodePartValues_colsAttributeValueDesc, "tblCodePartValues_colsAttributeValueDesc");
            // 
            // frmAttributeConnection
            // 
            this.AutoScaleBaseDpi = new System.Drawing.Size(106, 106);
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.tblCodePartValues);
            this.Controls.Add(this.dfsCodePart);
            this.Controls.Add(this.dfsCodeName);
            this.Controls.Add(this.dfsDescription);
            this.Controls.Add(this.cmbAttribute);
            this.Controls.Add(this.dfsCompany);
            this.Controls.Add(this.labeldfsCodePart);
            this.Controls.Add(this.labeldfsCodeName);
            this.Controls.Add(this.labeldfsDescription);
            this.Controls.Add(this.labelcmbAttribute);
            this.Controls.Add(this.labeldfsCompany);
            this.MaximizeBox = true;
            this.Name = "frmAttributeConnection";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "COMPANY = :global.company");
            this.NamedProperties.Put("LogicalUnit", "AccountingAttribute");
            this.NamedProperties.Put("PackageName", "ACCOUNTING_ATTRIBUTE_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "1");
            this.NamedProperties.Put("ViewName", "ACCOUNTING_ATTRIBUTE");
            this.NamedProperties.Put("Warnings", "TRUE");
            this.tblCodePartValues.ResumeLayout(false);
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

        public cChildTableFinBase tblCodePartValues;
        protected cColumn tblCodePartValues_colsCompany;
        protected cColumn tblCodePartValues_colsAttribute;
        protected cColumn tblCodePartValues_colsCodePart;
        protected cColumn tblCodePartValues_colsCodePartValue;
        protected cColumn tblCodePartValues_colsCodePartValueDesc;
        protected cColumn tblCodePartValues_colsAttributeValue;
        protected cColumn tblCodePartValues_colsAttributeValueDesc;
	}
}
