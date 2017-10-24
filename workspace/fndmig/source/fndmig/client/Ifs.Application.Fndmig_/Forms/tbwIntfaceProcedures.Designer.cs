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
	
	public partial class tbwIntfaceProcedures
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cColumn colsProcedureName;
		public cColumn colsDescription;
		public cLookupColumn colsDirection;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwIntfaceProcedures));
            this.colsProcedureName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsDirection = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.SuspendLayout();
            // 
            // colsProcedureName
            // 
            this.colsProcedureName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsProcedureName.Name = "colsProcedureName";
            this.colsProcedureName.NamedProperties.Put("EnumerateMethod", "");
            this.colsProcedureName.NamedProperties.Put("FieldFlags", "163");
            this.colsProcedureName.NamedProperties.Put("LovReference", "");
            this.colsProcedureName.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsProcedureName.NamedProperties.Put("ResizeableChildObject", "");
            this.colsProcedureName.NamedProperties.Put("SqlColumn", "PROCEDURE_NAME");
            this.colsProcedureName.NamedProperties.Put("ValidateMethod", "");
            this.colsProcedureName.Position = 3;
            resources.ApplyResources(this.colsProcedureName, "colsProcedureName");
            this.colsProcedureName.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsProcedureName_WindowActions);
            // 
            // colsDescription
            // 
            this.colsDescription.MaxLength = 4000;
            this.colsDescription.Name = "colsDescription";
            this.colsDescription.NamedProperties.Put("EnumerateMethod", "");
            this.colsDescription.NamedProperties.Put("FieldFlags", "295");
            this.colsDescription.NamedProperties.Put("LovReference", "");
            this.colsDescription.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.colsDescription.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            this.colsDescription.NamedProperties.Put("ValidateMethod", "");
            this.colsDescription.Position = 4;
            resources.ApplyResources(this.colsDescription, "colsDescription");
            // 
            // colsDirection
            // 
            this.colsDirection.MaxLength = 200;
            this.colsDirection.Name = "colsDirection";
            this.colsDirection.NamedProperties.Put("EnumerateMethod", "INTFACE_DIRECTION_API.Enumerate");
            this.colsDirection.NamedProperties.Put("FieldFlags", "295");
            this.colsDirection.NamedProperties.Put("LovReference", "");
            this.colsDirection.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsDirection.NamedProperties.Put("ResizeableChildObject", "");
            this.colsDirection.NamedProperties.Put("SqlColumn", "DIRECTION");
            this.colsDirection.NamedProperties.Put("ValidateMethod", "");
            this.colsDirection.Position = 5;
            resources.ApplyResources(this.colsDirection, "colsDirection");
            // 
            // tbwIntfaceProcedures
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colsProcedureName);
            this.Controls.Add(this.colsDescription);
            this.Controls.Add(this.colsDirection);
            this.Name = "tbwIntfaceProcedures";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "Intface_User_API.Get_Privilege(Fnd_Session_API.Get_FND_User) = Intface_Privilege_" +
                    "API.Get_Client_Value(1)");
            this.NamedProperties.Put("LogicalUnit", "IntfaceProcedures");
            this.NamedProperties.Put("PackageName", "Intface_Procedures_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "449");
            this.NamedProperties.Put("ViewName", "INTFACE_PROCEDURES");
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Controls.SetChildIndex(this.colsDirection, 0);
            this.Controls.SetChildIndex(this.colsDescription, 0);
            this.Controls.SetChildIndex(this.colsProcedureName, 0);
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
