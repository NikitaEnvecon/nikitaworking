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

namespace Ifs.Application.Accrul
{
	
	public partial class dlgCopySelectionTemplate
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		protected cBackgroundText labeldfsFromTemplateId;
		public cDataField dfsFromTemplateId;
		protected cBackgroundText labeldfsNewTemplateId;
		public cDataField dfsNewTemplateId;
		protected cBackgroundText labeldfsDescription;
		public cDataField dfsDescription;
		protected cBackgroundText labelcmbOwnership;
		public cComboBox cmbOwnership;
		public cPushButton pbOk;
		public cPushButton pbCancel;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgCopySelectionTemplate));
            this.labeldfsFromTemplateId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsFromTemplateId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsNewTemplateId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsNewTemplateId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsDescription = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsDescription = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelcmbOwnership = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbOwnership = new Ifs.Fnd.ApplicationForms.cComboBox();
            this.pbOk = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbCancel = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.ClientArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // ClientArea
            // 
            this.ClientArea.Controls.Add(this.pbCancel);
            this.ClientArea.Controls.Add(this.pbOk);
            this.ClientArea.Controls.Add(this.cmbOwnership);
            this.ClientArea.Controls.Add(this.dfsDescription);
            this.ClientArea.Controls.Add(this.dfsNewTemplateId);
            this.ClientArea.Controls.Add(this.dfsFromTemplateId);
            this.ClientArea.Controls.Add(this.labelcmbOwnership);
            this.ClientArea.Controls.Add(this.labeldfsDescription);
            this.ClientArea.Controls.Add(this.labeldfsNewTemplateId);
            this.ClientArea.Controls.Add(this.labeldfsFromTemplateId);
            resources.ApplyResources(this.ClientArea, "ClientArea");
            // 
            // commandManager
            // 
            this.commandManager.Components.Add(this.pbCancel);
            this.commandManager.Components.Add(this.pbOk);
            // 
            // labeldfsFromTemplateId
            // 
            resources.ApplyResources(this.labeldfsFromTemplateId, "labeldfsFromTemplateId");
            this.labeldfsFromTemplateId.Name = "labeldfsFromTemplateId";
            // 
            // dfsFromTemplateId
            // 
            this.dfsFromTemplateId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsFromTemplateId, "dfsFromTemplateId");
            this.dfsFromTemplateId.Name = "dfsFromTemplateId";
            this.dfsFromTemplateId.NamedProperties.Put("EnumerateMethod", "");
            this.dfsFromTemplateId.NamedProperties.Put("FieldFlags", "258");
            this.dfsFromTemplateId.NamedProperties.Put("LovReference", "");
            this.dfsFromTemplateId.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsFromTemplateId.NamedProperties.Put("SqlColumn", "");
            this.dfsFromTemplateId.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsNewTemplateId
            // 
            resources.ApplyResources(this.labeldfsNewTemplateId, "labeldfsNewTemplateId");
            this.labeldfsNewTemplateId.Name = "labeldfsNewTemplateId";
            // 
            // dfsNewTemplateId
            // 
            this.dfsNewTemplateId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsNewTemplateId, "dfsNewTemplateId");
            this.dfsNewTemplateId.Name = "dfsNewTemplateId";
            this.dfsNewTemplateId.NamedProperties.Put("EnumerateMethod", "");
            this.dfsNewTemplateId.NamedProperties.Put("FieldFlags", "262");
            this.dfsNewTemplateId.NamedProperties.Put("LovReference", "");
            this.dfsNewTemplateId.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsNewTemplateId.NamedProperties.Put("SqlColumn", "");
            this.dfsNewTemplateId.NamedProperties.Put("ValidateMethod", "");
            this.dfsNewTemplateId.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsNewTemplateId_WindowActions);
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
            this.dfsDescription.NamedProperties.Put("FieldFlags", "263");
            this.dfsDescription.NamedProperties.Put("LovReference", "");
            this.dfsDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsDescription.NamedProperties.Put("SqlColumn", "");
            this.dfsDescription.NamedProperties.Put("ValidateMethod", "");
            this.dfsDescription.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsDescription_WindowActions);
            // 
            // labelcmbOwnership
            // 
            resources.ApplyResources(this.labelcmbOwnership, "labelcmbOwnership");
            this.labelcmbOwnership.Name = "labelcmbOwnership";
            // 
            // cmbOwnership
            // 
            resources.ApplyResources(this.cmbOwnership, "cmbOwnership");
            this.cmbOwnership.Name = "cmbOwnership";
            this.cmbOwnership.NamedProperties.Put("EnumerateMethod", "Fin_Sel_Templ_Ownership_API.Enumerate");
            this.cmbOwnership.NamedProperties.Put("FieldFlags", "263");
            this.cmbOwnership.NamedProperties.Put("LovReference", "");
            this.cmbOwnership.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbOwnership.NamedProperties.Put("SqlColumn", "");
            this.cmbOwnership.NamedProperties.Put("ValidateMethod", "");
            this.cmbOwnership.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbOwnership_WindowActions);
            // 
            // pbOk
            // 
            this.pbOk.AcceleratorKey = System.Windows.Forms.Keys.Return;
            resources.ApplyResources(this.pbOk, "pbOk");
            this.pbOk.Name = "pbOk";
            this.pbOk.NamedProperties.Put("MethodId", "18385");
            this.pbOk.NamedProperties.Put("MethodParameter", "ok");
            this.pbOk.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // pbCancel
            // 
            this.pbCancel.AcceleratorKey = System.Windows.Forms.Keys.Escape;
            resources.ApplyResources(this.pbCancel, "pbCancel");
            this.pbCancel.Name = "pbCancel";
            this.pbCancel.NamedProperties.Put("MethodId", "18385");
            this.pbCancel.NamedProperties.Put("MethodParameter", "cancel");
            this.pbCancel.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // dlgCopySelectionTemplate
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "dlgCopySelectionTemplate";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "");
            this.NamedProperties.Put("PackageName", "");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "129");
            this.NamedProperties.Put("ViewName", "");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.ShowIcon = false;
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dlgCopySelectionTemplate_WindowActions);
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
