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
	
	public partial class dlgCreateSelectionTemplate
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		protected cBackgroundText labeldfsTemplateId;
		public cDataField dfsTemplateId;
		protected cBackgroundText labeldfsDescription;
		public cDataField dfsDescription;
		protected cBackgroundText labelcmbOwnership;
		public cComboBox cmbOwnership;
		protected cBackgroundText labeldfOwner;
		public cDataField dfOwner;
		public cPushButton pbOk;
		public cPushButton pbCancel;
		public cCheckBox cbExcludeValues;
		public cCheckBox cbDefault;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgCreateSelectionTemplate));
            this.labeldfsTemplateId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsTemplateId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsDescription = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsDescription = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelcmbOwnership = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbOwnership = new Ifs.Fnd.ApplicationForms.cComboBox();
            this.labeldfOwner = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfOwner = new Ifs.Fnd.ApplicationForms.cDataField();
            this.pbOk = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbCancel = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.cbExcludeValues = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.cbDefault = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.ClientArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // ClientArea
            // 
            this.ClientArea.Controls.Add(this.cbDefault);
            this.ClientArea.Controls.Add(this.cbExcludeValues);
            this.ClientArea.Controls.Add(this.pbCancel);
            this.ClientArea.Controls.Add(this.pbOk);
            this.ClientArea.Controls.Add(this.dfOwner);
            this.ClientArea.Controls.Add(this.cmbOwnership);
            this.ClientArea.Controls.Add(this.dfsDescription);
            this.ClientArea.Controls.Add(this.dfsTemplateId);
            this.ClientArea.Controls.Add(this.labeldfOwner);
            this.ClientArea.Controls.Add(this.labelcmbOwnership);
            this.ClientArea.Controls.Add(this.labeldfsDescription);
            this.ClientArea.Controls.Add(this.labeldfsTemplateId);
            resources.ApplyResources(this.ClientArea, "ClientArea");
            // 
            // commandManager
            // 
            this.commandManager.Components.Add(this.pbCancel);
            this.commandManager.Components.Add(this.pbOk);
            // 
            // labeldfsTemplateId
            // 
            resources.ApplyResources(this.labeldfsTemplateId, "labeldfsTemplateId");
            this.labeldfsTemplateId.Name = "labeldfsTemplateId";
            // 
            // dfsTemplateId
            // 
            this.dfsTemplateId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsTemplateId, "dfsTemplateId");
            this.dfsTemplateId.Name = "dfsTemplateId";
            this.dfsTemplateId.NamedProperties.Put("EnumerateMethod", "");
            this.dfsTemplateId.NamedProperties.Put("FieldFlags", "262");
            this.dfsTemplateId.NamedProperties.Put("LovReference", "");
            this.dfsTemplateId.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsTemplateId.NamedProperties.Put("SqlColumn", "");
            this.dfsTemplateId.NamedProperties.Put("ValidateMethod", "");
            this.dfsTemplateId.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsTemplateId_WindowActions);
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
            this.cmbOwnership.NamedProperties.Put("FieldFlags", "262");
            this.cmbOwnership.NamedProperties.Put("LovReference", "");
            this.cmbOwnership.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbOwnership.NamedProperties.Put("SqlColumn", "");
            this.cmbOwnership.NamedProperties.Put("ValidateMethod", "");
            this.cmbOwnership.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbOwnership_WindowActions);
            // 
            // labeldfOwner
            // 
            resources.ApplyResources(this.labeldfOwner, "labeldfOwner");
            this.labeldfOwner.Name = "labeldfOwner";
            // 
            // dfOwner
            // 
            this.dfOwner.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.dfOwner, "dfOwner");
            this.dfOwner.Name = "dfOwner";
            this.dfOwner.ReadOnly = true;
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
            // cbExcludeValues
            // 
            resources.ApplyResources(this.cbExcludeValues, "cbExcludeValues");
            this.cbExcludeValues.Name = "cbExcludeValues";
            this.cbExcludeValues.NamedProperties.Put("DataType", "5");
            this.cbExcludeValues.NamedProperties.Put("EnumerateMethod", "");
            this.cbExcludeValues.NamedProperties.Put("FieldFlags", "262");
            this.cbExcludeValues.NamedProperties.Put("LovReference", "");
            this.cbExcludeValues.NamedProperties.Put("ResizeableChildObject", "");
            this.cbExcludeValues.NamedProperties.Put("SqlColumn", "");
            this.cbExcludeValues.NamedProperties.Put("ValidateMethod", "");
            this.cbExcludeValues.NamedProperties.Put("XDataLength", "");
            // 
            // cbDefault
            // 
            resources.ApplyResources(this.cbDefault, "cbDefault");
            this.cbDefault.Name = "cbDefault";
            this.cbDefault.NamedProperties.Put("DataType", "5");
            this.cbDefault.NamedProperties.Put("EnumerateMethod", "");
            this.cbDefault.NamedProperties.Put("FieldFlags", "262");
            this.cbDefault.NamedProperties.Put("LovReference", "");
            this.cbDefault.NamedProperties.Put("ResizeableChildObject", "");
            this.cbDefault.NamedProperties.Put("SqlColumn", "");
            this.cbDefault.NamedProperties.Put("ValidateMethod", "");
            this.cbDefault.NamedProperties.Put("XDataLength", "");
            // 
            // dlgCreateSelectionTemplate
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "dlgCreateSelectionTemplate";
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
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dlgCreateSelectionTemplate_WindowActions);
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
