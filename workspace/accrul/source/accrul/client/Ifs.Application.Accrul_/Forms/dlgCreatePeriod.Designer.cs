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
	
	public partial class dlgCreatePeriod
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		protected cBackgroundText labeldfCompany;
		public cDataField dfCompany;
		protected cBackgroundText labelcmbUserGroup;
		public SalComboBox cmbUserGroup;
		protected cBackgroundText labeldfsDescription;
		public cDataField dfsDescription;
		public cPushButton pbOk;
		public cPushButton pbCancel;
		protected SalGroupBox gbUser_Group_Information;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgCreatePeriod));
            this.labeldfCompany = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfCompany = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelcmbUserGroup = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbUserGroup = new PPJ.Runtime.Windows.SalComboBox();
            this.labeldfsDescription = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsDescription = new Ifs.Fnd.ApplicationForms.cDataField();
            this.pbOk = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbCancel = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.gbUser_Group_Information = new PPJ.Runtime.Windows.SalGroupBox();
            this.ClientArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // ClientArea
            // 
            this.ClientArea.Controls.Add(this.pbCancel);
            this.ClientArea.Controls.Add(this.pbOk);
            this.ClientArea.Controls.Add(this.dfsDescription);
            this.ClientArea.Controls.Add(this.cmbUserGroup);
            this.ClientArea.Controls.Add(this.dfCompany);
            this.ClientArea.Controls.Add(this.labeldfsDescription);
            this.ClientArea.Controls.Add(this.labelcmbUserGroup);
            this.ClientArea.Controls.Add(this.labeldfCompany);
            this.ClientArea.Controls.Add(this.gbUser_Group_Information);
            resources.ApplyResources(this.ClientArea, "ClientArea");
            // 
            // commandManager
            // 
            this.commandManager.Components.Add(this.pbCancel);
            this.commandManager.Components.Add(this.pbOk);
            // 
            // labeldfCompany
            // 
            resources.ApplyResources(this.labeldfCompany, "labeldfCompany");
            this.labeldfCompany.Name = "labeldfCompany";
            // 
            // dfCompany
            // 
            resources.ApplyResources(this.dfCompany, "dfCompany");
            this.dfCompany.Name = "dfCompany";
            this.dfCompany.NamedProperties.Put("EnumerateMethod", "");
            this.dfCompany.NamedProperties.Put("FieldFlags", "134");
            this.dfCompany.NamedProperties.Put("LovReference", "");
            this.dfCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.dfCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.dfCompany.NamedProperties.Put("ValidateMethod", "");
            // 
            // labelcmbUserGroup
            // 
            resources.ApplyResources(this.labelcmbUserGroup, "labelcmbUserGroup");
            this.labelcmbUserGroup.Name = "labelcmbUserGroup";
            // 
            // cmbUserGroup
            // 
            resources.ApplyResources(this.cmbUserGroup, "cmbUserGroup");
            this.cmbUserGroup.Name = "cmbUserGroup";
            this.cmbUserGroup.NamedProperties.Put("DataType", "5");
            this.cmbUserGroup.NamedProperties.Put("EnumerateMethod", "");
            this.cmbUserGroup.NamedProperties.Put("FieldFlags", "288");
            this.cmbUserGroup.NamedProperties.Put("Format", "0");
            this.cmbUserGroup.NamedProperties.Put("LovReference", "");
            this.cmbUserGroup.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.cmbUserGroup.NamedProperties.Put("SqlColumn", "USER_GROUP");
            this.cmbUserGroup.Sorted = true;
            this.cmbUserGroup.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbUserGroup_WindowActions);
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
            this.dfsDescription.NamedProperties.Put("FieldFlags", "288");
            this.dfsDescription.NamedProperties.Put("LovReference", "");
            this.dfsDescription.NamedProperties.Put("SqlColumn", "");
            // 
            // pbOk
            // 
            this.pbOk.AcceleratorKey = System.Windows.Forms.Keys.Return;
            resources.ApplyResources(this.pbOk, "pbOk");
            this.pbOk.Name = "pbOk";
            this.pbOk.NamedProperties.Put("MethodId", "18385");
            this.pbOk.NamedProperties.Put("MethodParameter", "OK");
            // 
            // pbCancel
            // 
            this.pbCancel.AcceleratorKey = System.Windows.Forms.Keys.Escape;
            resources.ApplyResources(this.pbCancel, "pbCancel");
            this.pbCancel.Name = "pbCancel";
            this.pbCancel.NamedProperties.Put("MethodId", "18385");
            this.pbCancel.NamedProperties.Put("MethodParameter", "Cancel");
            // 
            // gbUser_Group_Information
            // 
            resources.ApplyResources(this.gbUser_Group_Information, "gbUser_Group_Information");
            this.gbUser_Group_Information.Name = "gbUser_Group_Information";
            this.gbUser_Group_Information.TabStop = false;
            // 
            // dlgCreatePeriod
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "dlgCreatePeriod";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "");
            this.NamedProperties.Put("PackageName", "");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("ViewName", "");
            this.ShowIcon = false;
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dlgCreatePeriod_WindowActions);
            this.ClientArea.ResumeLayout(false);
            this.ClientArea.PerformLayout();
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
