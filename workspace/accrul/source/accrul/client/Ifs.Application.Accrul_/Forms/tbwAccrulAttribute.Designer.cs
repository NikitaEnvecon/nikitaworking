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
	
	public partial class tbwAccrulAttribute
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cColumn colsAttributeName;
		// Bug 79498 Increased length to 259
		public cColumn colsAttributeValue;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwAccrulAttribute));
            this.colsAttributeName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsAttributeValue = new Ifs.Fnd.ApplicationForms.cColumn();
            this.SuspendLayout();
            // 
            // colsAttributeName
            // 
            this.colsAttributeName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsAttributeName.Name = "colsAttributeName";
            this.colsAttributeName.NamedProperties.Put("EnumerateMethod", "");
            this.colsAttributeName.NamedProperties.Put("FieldFlags", "163");
            this.colsAttributeName.NamedProperties.Put("LovReference", "");
            this.colsAttributeName.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsAttributeName.NamedProperties.Put("ResizeableChildObject", "");
            this.colsAttributeName.NamedProperties.Put("SqlColumn", "ATTRIBUTE_NAME");
            this.colsAttributeName.NamedProperties.Put("ValidateMethod", "");
            this.colsAttributeName.Position = 3;
            resources.ApplyResources(this.colsAttributeName, "colsAttributeName");
            // 
            // colsAttributeValue
            // 
            this.colsAttributeValue.MaxLength = 259;
            this.colsAttributeValue.Name = "colsAttributeValue";
            this.colsAttributeValue.NamedProperties.Put("EnumerateMethod", "");
            this.colsAttributeValue.NamedProperties.Put("FieldFlags", "295");
            this.colsAttributeValue.NamedProperties.Put("LovReference", "");
            this.colsAttributeValue.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsAttributeValue.NamedProperties.Put("ResizeableChildObject", "");
            this.colsAttributeValue.NamedProperties.Put("SqlColumn", "ATTRIBUTE_VALUE");
            this.colsAttributeValue.NamedProperties.Put("ValidateMethod", "");
            this.colsAttributeValue.Position = 4;
            resources.ApplyResources(this.colsAttributeValue, "colsAttributeValue");
            // 
            // tbwAccrulAttribute
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colsAttributeName);
            this.Controls.Add(this.colsAttributeValue);
            this.Name = "tbwAccrulAttribute";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "AccrulAttribute");
            this.NamedProperties.Put("PackageName", "ACCRUL_ATTRIBUTE_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "129");
            this.NamedProperties.Put("ViewName", "ACCRUL_ATTRIBUTE");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.Controls.SetChildIndex(this.colsAttributeValue, 0);
            this.Controls.SetChildIndex(this.colsAttributeName, 0);
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
