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
using Ifs.Fnd.ApplicationForms;
using PPJ.Runtime;
using PPJ.Runtime.Sql;
using PPJ.Runtime.Vis;
using PPJ.Runtime.Windows;
using PPJ.Runtime.Windows.QO;

namespace Ifs.Application.Fndmig_
{
	
	public partial class tbwIntfStartDefaults
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cColumn colsIntfaceName;
		public cColumn colsColumnName;
		// InMu 011202 Begin
		public cColumn colsDescription;
		// InMu 011202 End
		public cColumn colsDefaultValue;
		public cColumn colsDefaultWhere;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwIntfStartDefaults));
            this.colsIntfaceName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsColumnName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsDefaultValue = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsDefaultWhere = new Ifs.Fnd.ApplicationForms.cColumn();
            this.SuspendLayout();
            // 
            // colsIntfaceName
            // 
            this.colsIntfaceName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.colsIntfaceName, "colsIntfaceName");
            this.colsIntfaceName.MaxLength = 30;
            this.colsIntfaceName.Name = "colsIntfaceName";
            this.colsIntfaceName.NamedProperties.Put("EnumerateMethod", "");
            this.colsIntfaceName.NamedProperties.Put("FieldFlags", "67");
            this.colsIntfaceName.NamedProperties.Put("LovReference", "INTFACE_HEADER");
            this.colsIntfaceName.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsIntfaceName.NamedProperties.Put("SqlColumn", "INTFACE_NAME");
            this.colsIntfaceName.Position = 3;
            // 
            // colsColumnName
            // 
            this.colsColumnName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsColumnName.MaxLength = 30;
            this.colsColumnName.Name = "colsColumnName";
            this.colsColumnName.NamedProperties.Put("EnumerateMethod", "");
            this.colsColumnName.NamedProperties.Put("FieldFlags", "163");
            this.colsColumnName.NamedProperties.Put("LovReference", "");
            this.colsColumnName.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsColumnName.NamedProperties.Put("SqlColumn", "COLUMN_NAME");
            this.colsColumnName.Position = 4;
            resources.ApplyResources(this.colsColumnName, "colsColumnName");
            // 
            // colsDescription
            // 
            this.colsDescription.Name = "colsDescription";
            this.colsDescription.NamedProperties.Put("EnumerateMethod", "");
            this.colsDescription.NamedProperties.Put("FieldFlags", "290");
            this.colsDescription.NamedProperties.Put("LovReference", "");
            this.colsDescription.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsDescription.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            this.colsDescription.Position = 5;
            resources.ApplyResources(this.colsDescription, "colsDescription");
            // 
            // colsDefaultValue
            // 
            this.colsDefaultValue.MaxLength = 2000;
            this.colsDefaultValue.Name = "colsDefaultValue";
            this.colsDefaultValue.NamedProperties.Put("EnumerateMethod", "");
            this.colsDefaultValue.NamedProperties.Put("FieldFlags", "310");
            this.colsDefaultValue.NamedProperties.Put("LovReference", "");
            this.colsDefaultValue.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsDefaultValue.NamedProperties.Put("ResizeableChildObject", "");
            this.colsDefaultValue.NamedProperties.Put("SqlColumn", "DEFAULT_VALUE");
            this.colsDefaultValue.NamedProperties.Put("ValidateMethod", "");
            this.colsDefaultValue.Position = 6;
            resources.ApplyResources(this.colsDefaultValue, "colsDefaultValue");
            // 
            // colsDefaultWhere
            // 
            this.colsDefaultWhere.MaxLength = 2000;
            this.colsDefaultWhere.Name = "colsDefaultWhere";
            this.colsDefaultWhere.NamedProperties.Put("EnumerateMethod", "");
            this.colsDefaultWhere.NamedProperties.Put("FieldFlags", "294");
            this.colsDefaultWhere.NamedProperties.Put("LovReference", "");
            this.colsDefaultWhere.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsDefaultWhere.NamedProperties.Put("ResizeableChildObject", "");
            this.colsDefaultWhere.NamedProperties.Put("SqlColumn", "DEFAULT_WHERE");
            this.colsDefaultWhere.NamedProperties.Put("ValidateMethod", "");
            this.colsDefaultWhere.Position = 7;
            resources.ApplyResources(this.colsDefaultWhere, "colsDefaultWhere");
            // 
            // tbwIntfStartDefaults
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colsIntfaceName);
            this.Controls.Add(this.colsColumnName);
            this.Controls.Add(this.colsDescription);
            this.Controls.Add(this.colsDefaultValue);
            this.Controls.Add(this.colsDefaultWhere);
            this.Name = "tbwIntfStartDefaults";
            this.NamedProperties.Put("DefaultOrderBy", "DECODE(POS, 0, 999, POS), DEFAULT_VALUE, DEFAULT_WHERE, ATTR_SEQ");
            this.NamedProperties.Put("DefaultWhere", "CHANGE_DEFAULTS = &AO.Intface_Change_Defaults_API.Decode(\'1\')");
            this.NamedProperties.Put("LogicalUnit", "IntfaceDetail");
            this.NamedProperties.Put("PackageName", "Intface_Detail_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "129");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.NamedProperties.Put("ViewName", "INTFACE_DETAIL");
            this.Controls.SetChildIndex(this.colsDefaultWhere, 0);
            this.Controls.SetChildIndex(this.colsDefaultValue, 0);
            this.Controls.SetChildIndex(this.colsDescription, 0);
            this.Controls.SetChildIndex(this.colsColumnName, 0);
            this.Controls.SetChildIndex(this.colsIntfaceName, 0);
            this.Controls.SetChildIndex(this.@__colObjversion, 0);
            this.Controls.SetChildIndex(this.@__colObjid, 0);
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
	}
}
