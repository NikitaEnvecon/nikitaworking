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

using Ifs.Fnd.ApplicationForms;
using PPJ.Runtime.Windows;

namespace Ifs.Application.Fndmig_
{
	
	public partial class frmIntfaceConvList
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		protected SalBackgroundText labelecmbConvListId;
        protected cRecSelExtComboBox ecmbConvListId;
		protected SalBackgroundText labeldfsDescription;
        protected cDataField dfsDescription;
        protected cChildTable tblIntfaceConvListCols;
        protected cColumn tblIntfaceConvListCols_colsConvListId;
        protected cColumn tblIntfaceConvListCols_colsOldValue;
        protected cColumn tblIntfaceConvListCols_colsNewValue;
        #endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIntfaceConvList));
            this.labelecmbConvListId = new PPJ.Runtime.Windows.SalBackgroundText();
            this.ecmbConvListId = new Ifs.Fnd.ApplicationForms.cRecSelExtComboBox();
            this.labeldfsDescription = new PPJ.Runtime.Windows.SalBackgroundText();
            this.dfsDescription = new Ifs.Fnd.ApplicationForms.cDataField();
            this.tblIntfaceConvListCols = new Ifs.Fnd.ApplicationForms.cChildTable();
            this.tblIntfaceConvListCols_colsConvListId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblIntfaceConvListCols_colsOldValue = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblIntfaceConvListCols_colsNewValue = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblIntfaceConvListCols.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.ImageList = null;
            // 
            // labelecmbConvListId
            // 
            resources.ApplyResources(this.labelecmbConvListId, "labelecmbConvListId");
            this.labelecmbConvListId.Name = "labelecmbConvListId";
            // 
            // ecmbConvListId
            // 
            resources.ApplyResources(this.ecmbConvListId, "ecmbConvListId");
            this.ecmbConvListId.Name = "ecmbConvListId";
            this.ecmbConvListId.NamedProperties.Put("EnumerateMethod", "");
            this.ecmbConvListId.NamedProperties.Put("FieldFlags", "163");
            this.ecmbConvListId.NamedProperties.Put("Format", "9");
            this.ecmbConvListId.NamedProperties.Put("LovReference", "");
            this.ecmbConvListId.NamedProperties.Put("ResizeableChildObject", "");
            this.ecmbConvListId.NamedProperties.Put("SqlColumn", "CONV_LIST_ID");
            this.ecmbConvListId.NamedProperties.Put("ValidateMethod", "");
            this.ecmbConvListId.NamedProperties.Put("XDataLength", "100");
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
            this.dfsDescription.NamedProperties.Put("FieldFlags", "311");
            this.dfsDescription.NamedProperties.Put("LovReference", "");
            this.dfsDescription.NamedProperties.Put("ResizeableChildObject", "LLCL");
            this.dfsDescription.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            this.dfsDescription.NamedProperties.Put("ValidateMethod", "");
            // 
            // tblIntfaceConvListCols
            // 
            this.tblIntfaceConvListCols.Controls.Add(this.tblIntfaceConvListCols_colsConvListId);
            this.tblIntfaceConvListCols.Controls.Add(this.tblIntfaceConvListCols_colsOldValue);
            this.tblIntfaceConvListCols.Controls.Add(this.tblIntfaceConvListCols_colsNewValue);
            resources.ApplyResources(this.tblIntfaceConvListCols, "tblIntfaceConvListCols");
            this.tblIntfaceConvListCols.Name = "tblIntfaceConvListCols";
            this.tblIntfaceConvListCols.NamedProperties.Put("DefaultOrderBy", "OLD_VALUE DESC");
            this.tblIntfaceConvListCols.NamedProperties.Put("DefaultWhere", "");
            this.tblIntfaceConvListCols.NamedProperties.Put("LogicalUnit", "IntfaceConvListCols");
            this.tblIntfaceConvListCols.NamedProperties.Put("PackageName", "INTFACE_CONV_LIST_COLS_API");
            this.tblIntfaceConvListCols.NamedProperties.Put("ResizeableChildObject", "MLMM");
            this.tblIntfaceConvListCols.NamedProperties.Put("Warnings", "TRUE");
            this.tblIntfaceConvListCols.NamedProperties.Put("ViewName", "INTFACE_CONV_LIST_COLS");
            this.tblIntfaceConvListCols.Controls.SetChildIndex(this.tblIntfaceConvListCols_colsNewValue, 0);
            this.tblIntfaceConvListCols.Controls.SetChildIndex(this.tblIntfaceConvListCols_colsOldValue, 0);
            this.tblIntfaceConvListCols.Controls.SetChildIndex(this.tblIntfaceConvListCols_colsConvListId, 0);
            // 
            // tblIntfaceConvListCols_colsConvListId
            // 
            this.tblIntfaceConvListCols_colsConvListId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblIntfaceConvListCols_colsConvListId, "tblIntfaceConvListCols_colsConvListId");
            this.tblIntfaceConvListCols_colsConvListId.Name = "tblIntfaceConvListCols_colsConvListId";
            this.tblIntfaceConvListCols_colsConvListId.NamedProperties.Put("EnumerateMethod", "");
            this.tblIntfaceConvListCols_colsConvListId.NamedProperties.Put("FieldFlags", "67");
            this.tblIntfaceConvListCols_colsConvListId.NamedProperties.Put("LovReference", "INTFACE_CONV_LIST");
            this.tblIntfaceConvListCols_colsConvListId.NamedProperties.Put("ResizeableChildObject", "");
            this.tblIntfaceConvListCols_colsConvListId.NamedProperties.Put("SqlColumn", "CONV_LIST_ID");
            this.tblIntfaceConvListCols_colsConvListId.NamedProperties.Put("ValidateMethod", "");
            this.tblIntfaceConvListCols_colsConvListId.Position = 3;
            // 
            // tblIntfaceConvListCols_colsOldValue
            // 
            this.tblIntfaceConvListCols_colsOldValue.MaxLength = 200;
            this.tblIntfaceConvListCols_colsOldValue.Name = "tblIntfaceConvListCols_colsOldValue";
            this.tblIntfaceConvListCols_colsOldValue.NamedProperties.Put("EnumerateMethod", "");
            this.tblIntfaceConvListCols_colsOldValue.NamedProperties.Put("FieldFlags", "163");
            this.tblIntfaceConvListCols_colsOldValue.NamedProperties.Put("LovReference", "");
            this.tblIntfaceConvListCols_colsOldValue.NamedProperties.Put("ResizeableChildObject", "");
            this.tblIntfaceConvListCols_colsOldValue.NamedProperties.Put("SqlColumn", "OLD_VALUE");
            this.tblIntfaceConvListCols_colsOldValue.NamedProperties.Put("ValidateMethod", "");
            this.tblIntfaceConvListCols_colsOldValue.Position = 4;
            resources.ApplyResources(this.tblIntfaceConvListCols_colsOldValue, "tblIntfaceConvListCols_colsOldValue");
            // 
            // tblIntfaceConvListCols_colsNewValue
            // 
            this.tblIntfaceConvListCols_colsNewValue.MaxLength = 200;
            this.tblIntfaceConvListCols_colsNewValue.Name = "tblIntfaceConvListCols_colsNewValue";
            this.tblIntfaceConvListCols_colsNewValue.NamedProperties.Put("EnumerateMethod", "");
            this.tblIntfaceConvListCols_colsNewValue.NamedProperties.Put("FieldFlags", "294");
            this.tblIntfaceConvListCols_colsNewValue.NamedProperties.Put("LovReference", "");
            this.tblIntfaceConvListCols_colsNewValue.NamedProperties.Put("ResizeableChildObject", "");
            this.tblIntfaceConvListCols_colsNewValue.NamedProperties.Put("SqlColumn", "NEW_VALUE");
            this.tblIntfaceConvListCols_colsNewValue.NamedProperties.Put("ValidateMethod", "");
            this.tblIntfaceConvListCols_colsNewValue.Position = 5;
            resources.ApplyResources(this.tblIntfaceConvListCols_colsNewValue, "tblIntfaceConvListCols_colsNewValue");
            // 
            // frmIntfaceConvList
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.tblIntfaceConvListCols);
            this.Controls.Add(this.dfsDescription);
            this.Controls.Add(this.ecmbConvListId);
            this.Controls.Add(this.labeldfsDescription);
            this.Controls.Add(this.labelecmbConvListId);
            this.Name = "frmIntfaceConvList";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "IntfaceConvList");
            this.NamedProperties.Put("PackageName", "INTFACE_CONV_LIST_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("Warnings", "TRUE");
            this.NamedProperties.Put("ViewName", "INTFACE_CONV_LIST");
            this.tblIntfaceConvListCols.ResumeLayout(false);
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

	}
}
