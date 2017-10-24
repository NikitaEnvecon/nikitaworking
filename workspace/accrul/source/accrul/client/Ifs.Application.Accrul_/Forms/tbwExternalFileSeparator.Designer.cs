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
	
	public partial class tbwExternalFileSeparator
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cColumn colsSeparatorId;
		public cColumn colsDescription;
		public cColumn colsSeparator;
		public cColumn colsSeparatorAscii;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwExternalFileSeparator));
            this.colsSeparatorId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsSeparator = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsSeparatorAscii = new Ifs.Fnd.ApplicationForms.cColumn();
            this.SuspendLayout();
            // 
            // colsSeparatorId
            // 
            this.colsSeparatorId.MaxLength = 30;
            this.colsSeparatorId.Name = "colsSeparatorId";
            this.colsSeparatorId.NamedProperties.Put("EnumerateMethod", "");
            this.colsSeparatorId.NamedProperties.Put("FieldFlags", "163");
            this.colsSeparatorId.NamedProperties.Put("LovReference", "");
            this.colsSeparatorId.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsSeparatorId.NamedProperties.Put("SqlColumn", "SEPARATOR_ID");
            this.colsSeparatorId.Position = 3;
            resources.ApplyResources(this.colsSeparatorId, "colsSeparatorId");
            // 
            // colsDescription
            // 
            this.colsDescription.Name = "colsDescription";
            this.colsDescription.NamedProperties.Put("EnumerateMethod", "");
            this.colsDescription.NamedProperties.Put("FieldFlags", "295");
            this.colsDescription.NamedProperties.Put("LovReference", "");
            this.colsDescription.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsDescription.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            this.colsDescription.Position = 4;
            resources.ApplyResources(this.colsDescription, "colsDescription");
            // 
            // colsSeparator
            // 
            this.colsSeparator.MaxLength = 10;
            this.colsSeparator.Name = "colsSeparator";
            this.colsSeparator.NamedProperties.Put("EnumerateMethod", "");
            this.colsSeparator.NamedProperties.Put("FieldFlags", "294");
            this.colsSeparator.NamedProperties.Put("LovReference", "");
            this.colsSeparator.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsSeparator.NamedProperties.Put("ResizeableChildObject", "");
            this.colsSeparator.NamedProperties.Put("SqlColumn", "SEPARATOR");
            this.colsSeparator.NamedProperties.Put("ValidateMethod", "");
            this.colsSeparator.Position = 5;
            resources.ApplyResources(this.colsSeparator, "colsSeparator");
            // 
            // colsSeparatorAscii
            // 
            this.colsSeparatorAscii.MaxLength = 10;
            this.colsSeparatorAscii.Name = "colsSeparatorAscii";
            this.colsSeparatorAscii.NamedProperties.Put("EnumerateMethod", "");
            this.colsSeparatorAscii.NamedProperties.Put("FieldFlags", "294");
            this.colsSeparatorAscii.NamedProperties.Put("LovReference", "");
            this.colsSeparatorAscii.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsSeparatorAscii.NamedProperties.Put("ResizeableChildObject", "");
            this.colsSeparatorAscii.NamedProperties.Put("SqlColumn", "SEPARATOR_ASCII");
            this.colsSeparatorAscii.NamedProperties.Put("ValidateMethod", "");
            this.colsSeparatorAscii.Position = 6;
            resources.ApplyResources(this.colsSeparatorAscii, "colsSeparatorAscii");
            // 
            // tbwExternalFileSeparator
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colsSeparatorId);
            this.Controls.Add(this.colsDescription);
            this.Controls.Add(this.colsSeparator);
            this.Controls.Add(this.colsSeparatorAscii);
            this.Name = "tbwExternalFileSeparator";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "ExtFileSeparator");
            this.NamedProperties.Put("PackageName", "EXT_FILE_SEPARATOR_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "449");
            this.NamedProperties.Put("ViewName", "EXT_FILE_SEPARATOR");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.Controls.SetChildIndex(this.colsSeparatorAscii, 0);
            this.Controls.SetChildIndex(this.colsSeparator, 0);
            this.Controls.SetChildIndex(this.colsDescription, 0);
            this.Controls.SetChildIndex(this.colsSeparatorId, 0);
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
