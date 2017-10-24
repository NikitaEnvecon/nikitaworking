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
	
	public partial class dlgCreateRecDetFromView
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
		public cDataField dfsDescriptionTo;
		protected cBackgroundText labeldfRecordTypeId;
		public cDataField dfRecordTypeId;
		public cDataField dfsRecDescriptionTo;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgCreateRecDetFromView));
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
            this.dfsDescriptionTo = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfRecordTypeId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfRecordTypeId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsRecDescriptionTo = new Ifs.Fnd.ApplicationForms.cDataField();
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
            this.ClientArea.Controls.Add(this.dfsRecDescriptionTo);
            this.ClientArea.Controls.Add(this.dfRecordTypeId);
            this.ClientArea.Controls.Add(this.dfsDescriptionTo);
            this.ClientArea.Controls.Add(this.dfFileType);
            this.ClientArea.Controls.Add(this.dfsInputPackage);
            this.ClientArea.Controls.Add(this.dfsViewName1);
            this.ClientArea.Controls.Add(this.dfsComponent);
            this.ClientArea.Controls.Add(this.labeldfRecordTypeId);
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
            this.dfFileType.NamedProperties.Put("LovReference", "");
            this.dfFileType.NamedProperties.Put("MethodId", "18385");
            this.dfFileType.NamedProperties.Put("MethodParameter", "OKButton");
            this.dfFileType.NamedProperties.Put("MethodParameterType", "String");
            this.dfFileType.NamedProperties.Put("ResizeableChildObject", "");
            this.dfFileType.NamedProperties.Put("SqlColumn", "FILE_TYPE");
            this.dfFileType.NamedProperties.Put("ValidateMethod", "");
            // 
            // dfsDescriptionTo
            // 
            resources.ApplyResources(this.dfsDescriptionTo, "dfsDescriptionTo");
            this.dfsDescriptionTo.Name = "dfsDescriptionTo";
            this.dfsDescriptionTo.NamedProperties.Put("EnumerateMethod", "");
            this.dfsDescriptionTo.NamedProperties.Put("FieldFlags", "288");
            this.dfsDescriptionTo.NamedProperties.Put("LovReference", "");
            this.dfsDescriptionTo.NamedProperties.Put("MethodId", "18385");
            this.dfsDescriptionTo.NamedProperties.Put("MethodParameter", "OKButton");
            this.dfsDescriptionTo.NamedProperties.Put("MethodParameterType", "String");
            this.dfsDescriptionTo.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsDescriptionTo.NamedProperties.Put("SqlColumn", "");
            this.dfsDescriptionTo.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfRecordTypeId
            // 
            resources.ApplyResources(this.labeldfRecordTypeId, "labeldfRecordTypeId");
            this.labeldfRecordTypeId.Name = "labeldfRecordTypeId";
            // 
            // dfRecordTypeId
            // 
            resources.ApplyResources(this.dfRecordTypeId, "dfRecordTypeId");
            this.dfRecordTypeId.Name = "dfRecordTypeId";
            this.dfRecordTypeId.NamedProperties.Put("EnumerateMethod", "");
            this.dfRecordTypeId.NamedProperties.Put("LovReference", "");
            this.dfRecordTypeId.NamedProperties.Put("MethodId", "18385");
            this.dfRecordTypeId.NamedProperties.Put("MethodParameter", "OKButton");
            this.dfRecordTypeId.NamedProperties.Put("MethodParameterType", "String");
            this.dfRecordTypeId.NamedProperties.Put("ResizeableChildObject", "");
            this.dfRecordTypeId.NamedProperties.Put("SqlColumn", "FILE_TYPE");
            this.dfRecordTypeId.NamedProperties.Put("ValidateMethod", "");
            // 
            // dfsRecDescriptionTo
            // 
            resources.ApplyResources(this.dfsRecDescriptionTo, "dfsRecDescriptionTo");
            this.dfsRecDescriptionTo.Name = "dfsRecDescriptionTo";
            this.dfsRecDescriptionTo.NamedProperties.Put("EnumerateMethod", "");
            this.dfsRecDescriptionTo.NamedProperties.Put("FieldFlags", "288");
            this.dfsRecDescriptionTo.NamedProperties.Put("LovReference", "");
            this.dfsRecDescriptionTo.NamedProperties.Put("MethodId", "18385");
            this.dfsRecDescriptionTo.NamedProperties.Put("MethodParameter", "OKButton");
            this.dfsRecDescriptionTo.NamedProperties.Put("MethodParameterType", "String");
            this.dfsRecDescriptionTo.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsRecDescriptionTo.NamedProperties.Put("SqlColumn", "");
            this.dfsRecDescriptionTo.NamedProperties.Put("ValidateMethod", "");
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
            // dlgCreateRecDetFromView
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "dlgCreateRecDetFromView";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "");
            this.NamedProperties.Put("PackageName", "");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("ViewName", "");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.ShowIcon = false;
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dlgCreateRecDetFromView_WindowActions);
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
