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
	
	public partial class dlgCreateVouTemplate
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		protected cBackgroundText labeldfTemplate;
		public cDataField dfTemplate;
		protected cBackgroundText labeldfDescription;
		public cDataField dfDescription;
		protected cBackgroundText labeldfValidFrom;
		public cDataField dfValidFrom;
		protected cBackgroundText labeldfValidUntil;
		public cDataField dfValidUntil;
		public cCheckBoxFin cbIncludeAmount;
		public cPushButton pbOK;
		public cPushButton pbCancel;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgCreateVouTemplate));
            this.labeldfTemplate = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfTemplate = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfDescription = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfDescription = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfValidFrom = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfValidFrom = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfValidUntil = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfValidUntil = new Ifs.Fnd.ApplicationForms.cDataField();
            this.cbIncludeAmount = new Ifs.Application.Accrul.cCheckBoxFin();
            this.pbOK = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbCancel = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.ClientArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolBar
            // 
            resources.ApplyResources(this.ToolBar, "ToolBar");
            // 
            // ClientArea
            // 
            this.ClientArea.Controls.Add(this.pbCancel);
            this.ClientArea.Controls.Add(this.pbOK);
            this.ClientArea.Controls.Add(this.cbIncludeAmount);
            this.ClientArea.Controls.Add(this.dfValidUntil);
            this.ClientArea.Controls.Add(this.dfValidFrom);
            this.ClientArea.Controls.Add(this.dfDescription);
            this.ClientArea.Controls.Add(this.dfTemplate);
            this.ClientArea.Controls.Add(this.labeldfValidUntil);
            this.ClientArea.Controls.Add(this.labeldfValidFrom);
            this.ClientArea.Controls.Add(this.labeldfDescription);
            this.ClientArea.Controls.Add(this.labeldfTemplate);
            resources.ApplyResources(this.ClientArea, "ClientArea");
            // 
            // commandManager
            // 
            this.commandManager.Components.Add(this.pbCancel);
            this.commandManager.Components.Add(this.pbOK);
            // 
            // labeldfTemplate
            // 
            resources.ApplyResources(this.labeldfTemplate, "labeldfTemplate");
            this.labeldfTemplate.Name = "labeldfTemplate";
            // 
            // dfTemplate
            // 
            this.dfTemplate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfTemplate, "dfTemplate");
            this.dfTemplate.Name = "dfTemplate";
            this.dfTemplate.NamedProperties.Put("EnumerateMethod", "");
            this.dfTemplate.NamedProperties.Put("FieldFlags", "263");
            this.dfTemplate.NamedProperties.Put("LovReference", "");
            this.dfTemplate.NamedProperties.Put("ResizeableChildObject", "");
            this.dfTemplate.NamedProperties.Put("SqlColumn", "TEMPLATE");
            this.dfTemplate.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfDescription
            // 
            resources.ApplyResources(this.labeldfDescription, "labeldfDescription");
            this.labeldfDescription.Name = "labeldfDescription";
            // 
            // dfDescription
            // 
            resources.ApplyResources(this.dfDescription, "dfDescription");
            this.dfDescription.Name = "dfDescription";
            this.dfDescription.NamedProperties.Put("EnumerateMethod", "");
            this.dfDescription.NamedProperties.Put("FieldFlags", "263");
            this.dfDescription.NamedProperties.Put("LovReference", "");
            this.dfDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.dfDescription.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            this.dfDescription.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfValidFrom
            // 
            resources.ApplyResources(this.labeldfValidFrom, "labeldfValidFrom");
            this.labeldfValidFrom.Name = "labeldfValidFrom";
            // 
            // dfValidFrom
            // 
            this.dfValidFrom.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.dfValidFrom.Format = "d";
            resources.ApplyResources(this.dfValidFrom, "dfValidFrom");
            this.dfValidFrom.Name = "dfValidFrom";
            this.dfValidFrom.NamedProperties.Put("EnumerateMethod", "");
            this.dfValidFrom.NamedProperties.Put("FieldFlags", "263");
            this.dfValidFrom.NamedProperties.Put("LovReference", "");
            this.dfValidFrom.NamedProperties.Put("ResizeableChildObject", "");
            this.dfValidFrom.NamedProperties.Put("SqlColumn", "VALID_FROM");
            this.dfValidFrom.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfValidUntil
            // 
            resources.ApplyResources(this.labeldfValidUntil, "labeldfValidUntil");
            this.labeldfValidUntil.Name = "labeldfValidUntil";
            // 
            // dfValidUntil
            // 
            this.dfValidUntil.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.dfValidUntil.Format = "d";
            resources.ApplyResources(this.dfValidUntil, "dfValidUntil");
            this.dfValidUntil.Name = "dfValidUntil";
            this.dfValidUntil.NamedProperties.Put("EnumerateMethod", "");
            this.dfValidUntil.NamedProperties.Put("FieldFlags", "263");
            this.dfValidUntil.NamedProperties.Put("LovReference", "");
            this.dfValidUntil.NamedProperties.Put("ResizeableChildObject", "");
            this.dfValidUntil.NamedProperties.Put("SqlColumn", "VALID_UNTIL");
            this.dfValidUntil.NamedProperties.Put("ValidateMethod", "");
            this.dfValidUntil.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfValidUntil_WindowActions);
            // 
            // cbIncludeAmount
            // 
            resources.ApplyResources(this.cbIncludeAmount, "cbIncludeAmount");
            this.cbIncludeAmount.Name = "cbIncludeAmount";
            this.cbIncludeAmount.NamedProperties.Put("EnumerateMethod", "");
            this.cbIncludeAmount.NamedProperties.Put("FieldFlags", "262");
            this.cbIncludeAmount.NamedProperties.Put("LovReference", "");
            this.cbIncludeAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.cbIncludeAmount.NamedProperties.Put("SqlColumn", "");
            this.cbIncludeAmount.NamedProperties.Put("ValidateMethod", "");
            this.cbIncludeAmount.NamedProperties.Put("XDataLength", "");
            // 
            // pbOK
            // 
            this.pbOK.AcceleratorKey = System.Windows.Forms.Keys.Return;
            resources.ApplyResources(this.pbOK, "pbOK");
            this.pbOK.Name = "pbOK";
            this.pbOK.NamedProperties.Put("MethodId", "18385");
            this.pbOK.NamedProperties.Put("MethodParameter", "OK");
            this.pbOK.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // pbCancel
            // 
            this.pbCancel.AcceleratorKey = System.Windows.Forms.Keys.Escape;
            resources.ApplyResources(this.pbCancel, "pbCancel");
            this.pbCancel.Name = "pbCancel";
            this.pbCancel.NamedProperties.Put("MethodId", "18385");
            this.pbCancel.NamedProperties.Put("MethodParameter", "Cancel");
            this.pbCancel.NamedProperties.Put("ResizeableChildObject", "");
            this.pbCancel.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.pbCancel_WindowActions);
            // 
            // dlgCreateVouTemplate
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "dlgCreateVouTemplate";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "VoucherTemplate");
            this.NamedProperties.Put("PackageName", "VOUCHER_TEMPLATE_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("ViewName", "VOUCHER_TEMPLATE");
            this.ShowIcon = false;
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dlgCreateVouTemplate_WindowActions);
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
