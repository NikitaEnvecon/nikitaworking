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
	
	public partial class dlgCreateFileTypeTemplFromView
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		protected SalGroupBox gbSource;
		protected cBackgroundText labeldfsComponent;
		public cDataField dfsComponent;
		protected cBackgroundText labeldfsViewName1;
		public cDataField dfsViewName1;
		protected cBackgroundText labeldfsInputPackage;
		public cDataField dfsInputPackage;
		protected SalGroupBox gbDestination;
		protected cBackgroundText labeldfFileType;
		public cDataField dfFileType;
		protected cBackgroundText labeldfsDescriptionTo;
		public cDataField dfsDescriptionTo;
		public cCheckBox cCreateTemplate;
		protected cBackgroundText labeldfFileTemplate;
		public cDataField dfFileTemplate;
		protected cBackgroundText labeldfsDescriptionTemplate;
		public cDataField dfsDescriptionTemplate;
		public cCheckBox cbCreateInput;
		public cCheckBox cbCreateOutput;
		public cPushButton pbOk;
		public cPushButton pbCancel;
		public cPushButton pbList;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgCreateFileTypeTemplFromView));
            this.gbSource = new PPJ.Runtime.Windows.SalGroupBox();
            this.labeldfsComponent = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsComponent = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsViewName1 = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsViewName1 = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsInputPackage = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsInputPackage = new Ifs.Fnd.ApplicationForms.cDataField();
            this.gbDestination = new PPJ.Runtime.Windows.SalGroupBox();
            this.labeldfFileType = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfFileType = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsDescriptionTo = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsDescriptionTo = new Ifs.Fnd.ApplicationForms.cDataField();
            this.cCreateTemplate = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.labeldfFileTemplate = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfFileTemplate = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsDescriptionTemplate = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsDescriptionTemplate = new Ifs.Fnd.ApplicationForms.cDataField();
            this.cbCreateInput = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.cbCreateOutput = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.pbOk = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbCancel = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbList = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.ClientArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolBar
            // 
            resources.ApplyResources(this.ToolBar, "ToolBar");
            // 
            // ClientArea
            // 
            this.ClientArea.Controls.Add(this.pbList);
            this.ClientArea.Controls.Add(this.pbCancel);
            this.ClientArea.Controls.Add(this.pbOk);
            this.ClientArea.Controls.Add(this.cbCreateOutput);
            this.ClientArea.Controls.Add(this.cbCreateInput);
            this.ClientArea.Controls.Add(this.dfsDescriptionTemplate);
            this.ClientArea.Controls.Add(this.dfFileTemplate);
            this.ClientArea.Controls.Add(this.cCreateTemplate);
            this.ClientArea.Controls.Add(this.dfsDescriptionTo);
            this.ClientArea.Controls.Add(this.dfFileType);
            this.ClientArea.Controls.Add(this.dfsInputPackage);
            this.ClientArea.Controls.Add(this.dfsViewName1);
            this.ClientArea.Controls.Add(this.dfsComponent);
            this.ClientArea.Controls.Add(this.labeldfsDescriptionTemplate);
            this.ClientArea.Controls.Add(this.labeldfFileTemplate);
            this.ClientArea.Controls.Add(this.labeldfsDescriptionTo);
            this.ClientArea.Controls.Add(this.labeldfFileType);
            this.ClientArea.Controls.Add(this.labeldfsInputPackage);
            this.ClientArea.Controls.Add(this.labeldfsViewName1);
            this.ClientArea.Controls.Add(this.labeldfsComponent);
            this.ClientArea.Controls.Add(this.gbDestination);
            this.ClientArea.Controls.Add(this.gbSource);
            resources.ApplyResources(this.ClientArea, "ClientArea");
            // 
            // commandManager
            // 
            this.commandManager.Components.Add(this.pbList);
            this.commandManager.Components.Add(this.pbCancel);
            this.commandManager.Components.Add(this.pbOk);
            // 
            // gbSource
            // 
            resources.ApplyResources(this.gbSource, "gbSource");
            this.gbSource.Name = "gbSource";
            this.gbSource.TabStop = false;
            // 
            // labeldfsComponent
            // 
            resources.ApplyResources(this.labeldfsComponent, "labeldfsComponent");
            this.labeldfsComponent.Name = "labeldfsComponent";
            // 
            // dfsComponent
            // 
            this.dfsComponent.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsComponent, "dfsComponent");
            this.dfsComponent.Name = "dfsComponent";
            this.dfsComponent.NamedProperties.Put("EnumerateMethod", "");
            this.dfsComponent.NamedProperties.Put("FieldFlags", "292");
            this.dfsComponent.NamedProperties.Put("LovReference", "EXT_FILE_MODULE_NAME");
            this.dfsComponent.NamedProperties.Put("MethodId", "18385");
            this.dfsComponent.NamedProperties.Put("MethodParameter", "OKButton");
            this.dfsComponent.NamedProperties.Put("MethodParameterType", "String");
            this.dfsComponent.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsComponent.NamedProperties.Put("SqlColumn", "COMPONENT");
            this.dfsComponent.NamedProperties.Put("ValidateMethod", "");
            this.dfsComponent.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsComponent_WindowActions);
            // 
            // labeldfsViewName1
            // 
            resources.ApplyResources(this.labeldfsViewName1, "labeldfsViewName1");
            this.labeldfsViewName1.Name = "labeldfsViewName1";
            // 
            // dfsViewName1
            // 
            this.dfsViewName1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsViewName1, "dfsViewName1");
            this.dfsViewName1.Name = "dfsViewName1";
            this.dfsViewName1.NamedProperties.Put("EnumerateMethod", "");
            this.dfsViewName1.NamedProperties.Put("FieldFlags", "295");
            this.dfsViewName1.NamedProperties.Put("LovReference", "EXT_FILE_VIEW_NAME");
            this.dfsViewName1.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsViewName1.NamedProperties.Put("SqlColumn", "VIEW_NAME");
            this.dfsViewName1.NamedProperties.Put("ValidateMethod", "");
            this.dfsViewName1.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsViewName1_WindowActions);
            // 
            // labeldfsInputPackage
            // 
            resources.ApplyResources(this.labeldfsInputPackage, "labeldfsInputPackage");
            this.labeldfsInputPackage.Name = "labeldfsInputPackage";
            // 
            // dfsInputPackage
            // 
            this.dfsInputPackage.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.dfsInputPackage, "dfsInputPackage");
            this.dfsInputPackage.Name = "dfsInputPackage";
            this.dfsInputPackage.NamedProperties.Put("EnumerateMethod", "");
            this.dfsInputPackage.NamedProperties.Put("FieldFlags", "288");
            this.dfsInputPackage.NamedProperties.Put("LovReference", "");
            this.dfsInputPackage.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsInputPackage.NamedProperties.Put("SqlColumn", "INPUT_PACKAGE");
            this.dfsInputPackage.NamedProperties.Put("ValidateMethod", "");
            this.dfsInputPackage.ReadOnly = true;
            // 
            // gbDestination
            // 
            resources.ApplyResources(this.gbDestination, "gbDestination");
            this.gbDestination.Name = "gbDestination";
            this.gbDestination.TabStop = false;
            // 
            // labeldfFileType
            // 
            resources.ApplyResources(this.labeldfFileType, "labeldfFileType");
            this.labeldfFileType.Name = "labeldfFileType";
            // 
            // dfFileType
            // 
            resources.ApplyResources(this.dfFileType, "dfFileType");
            this.dfFileType.Name = "dfFileType";
            this.dfFileType.NamedProperties.Put("EnumerateMethod", "");
            this.dfFileType.NamedProperties.Put("FieldFlags", "260");
            this.dfFileType.NamedProperties.Put("LovReference", "");
            this.dfFileType.NamedProperties.Put("MethodId", "18385");
            this.dfFileType.NamedProperties.Put("MethodParameter", "OKButton");
            this.dfFileType.NamedProperties.Put("MethodParameterType", "String");
            this.dfFileType.NamedProperties.Put("ResizeableChildObject", "");
            this.dfFileType.NamedProperties.Put("SqlColumn", "FILE_TYPE");
            this.dfFileType.NamedProperties.Put("ValidateMethod", "");
            this.dfFileType.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfFileType_WindowActions);
            // 
            // labeldfsDescriptionTo
            // 
            resources.ApplyResources(this.labeldfsDescriptionTo, "labeldfsDescriptionTo");
            this.labeldfsDescriptionTo.Name = "labeldfsDescriptionTo";
            // 
            // dfsDescriptionTo
            // 
            resources.ApplyResources(this.dfsDescriptionTo, "dfsDescriptionTo");
            this.dfsDescriptionTo.Name = "dfsDescriptionTo";
            this.dfsDescriptionTo.NamedProperties.Put("EnumerateMethod", "");
            this.dfsDescriptionTo.NamedProperties.Put("FieldFlags", "292");
            this.dfsDescriptionTo.NamedProperties.Put("LovReference", "");
            this.dfsDescriptionTo.NamedProperties.Put("MethodId", "18385");
            this.dfsDescriptionTo.NamedProperties.Put("MethodParameter", "OKButton");
            this.dfsDescriptionTo.NamedProperties.Put("MethodParameterType", "String");
            this.dfsDescriptionTo.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsDescriptionTo.NamedProperties.Put("SqlColumn", "");
            this.dfsDescriptionTo.NamedProperties.Put("ValidateMethod", "");
            this.dfsDescriptionTo.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsDescriptionTo_WindowActions);
            // 
            // cCreateTemplate
            // 
            resources.ApplyResources(this.cCreateTemplate, "cCreateTemplate");
            this.cCreateTemplate.Name = "cCreateTemplate";
            this.cCreateTemplate.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cCreateTemplate_WindowActions);
            // 
            // labeldfFileTemplate
            // 
            resources.ApplyResources(this.labeldfFileTemplate, "labeldfFileTemplate");
            this.labeldfFileTemplate.Name = "labeldfFileTemplate";
            // 
            // dfFileTemplate
            // 
            resources.ApplyResources(this.dfFileTemplate, "dfFileTemplate");
            this.dfFileTemplate.Name = "dfFileTemplate";
            this.dfFileTemplate.NamedProperties.Put("EnumerateMethod", "");
            this.dfFileTemplate.NamedProperties.Put("FieldFlags", "260");
            this.dfFileTemplate.NamedProperties.Put("LovReference", "");
            this.dfFileTemplate.NamedProperties.Put("MethodId", "18385");
            this.dfFileTemplate.NamedProperties.Put("MethodParameter", "OKButton");
            this.dfFileTemplate.NamedProperties.Put("MethodParameterType", "String");
            this.dfFileTemplate.NamedProperties.Put("ResizeableChildObject", "");
            this.dfFileTemplate.NamedProperties.Put("SqlColumn", "FILE_TEMPLATE");
            this.dfFileTemplate.NamedProperties.Put("ValidateMethod", "");
            this.dfFileTemplate.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfFileTemplate_WindowActions);
            // 
            // labeldfsDescriptionTemplate
            // 
            resources.ApplyResources(this.labeldfsDescriptionTemplate, "labeldfsDescriptionTemplate");
            this.labeldfsDescriptionTemplate.Name = "labeldfsDescriptionTemplate";
            // 
            // dfsDescriptionTemplate
            // 
            resources.ApplyResources(this.dfsDescriptionTemplate, "dfsDescriptionTemplate");
            this.dfsDescriptionTemplate.Name = "dfsDescriptionTemplate";
            this.dfsDescriptionTemplate.NamedProperties.Put("EnumerateMethod", "");
            this.dfsDescriptionTemplate.NamedProperties.Put("FieldFlags", "292");
            this.dfsDescriptionTemplate.NamedProperties.Put("LovReference", "");
            this.dfsDescriptionTemplate.NamedProperties.Put("MethodId", "18385");
            this.dfsDescriptionTemplate.NamedProperties.Put("MethodParameter", "OKButton");
            this.dfsDescriptionTemplate.NamedProperties.Put("MethodParameterType", "String");
            this.dfsDescriptionTemplate.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsDescriptionTemplate.NamedProperties.Put("SqlColumn", "");
            this.dfsDescriptionTemplate.NamedProperties.Put("ValidateMethod", "");
            this.dfsDescriptionTemplate.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsDescriptionTemplate_WindowActions);
            // 
            // cbCreateInput
            // 
            resources.ApplyResources(this.cbCreateInput, "cbCreateInput");
            this.cbCreateInput.Name = "cbCreateInput";
            this.cbCreateInput.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cbCreateInput_WindowActions);
            // 
            // cbCreateOutput
            // 
            resources.ApplyResources(this.cbCreateOutput, "cbCreateOutput");
            this.cbCreateOutput.Name = "cbCreateOutput";
            // 
            // pbOk
            // 
            resources.ApplyResources(this.pbOk, "pbOk");
            this.pbOk.Name = "pbOk";
            this.pbOk.NamedProperties.Put("MethodId", "18385");
            this.pbOk.NamedProperties.Put("MethodParameter", "OKButton");
            this.pbOk.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // pbCancel
            // 
            resources.ApplyResources(this.pbCancel, "pbCancel");
            this.pbCancel.Name = "pbCancel";
            this.pbCancel.NamedProperties.Put("MethodId", "18385");
            this.pbCancel.NamedProperties.Put("MethodParameter", "CancelButton");
            this.pbCancel.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // pbList
            // 
            this.pbList.AcceleratorKey = System.Windows.Forms.Keys.F8;
            resources.ApplyResources(this.pbList, "pbList");
            this.pbList.Name = "pbList";
            this.pbList.NamedProperties.Put("MethodId", "18385");
            this.pbList.NamedProperties.Put("MethodParameter", "ListButton");
            this.pbList.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // dlgCreateFileTypeTemplFromView
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "dlgCreateFileTypeTemplFromView";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "");
            this.NamedProperties.Put("PackageName", "");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("ViewName", "");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.ShowIcon = false;
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dlgCreateFileTypeTemplFromView_WindowActions);
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
