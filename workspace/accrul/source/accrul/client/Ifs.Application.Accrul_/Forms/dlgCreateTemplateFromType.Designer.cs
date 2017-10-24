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
	
	public partial class dlgCreateTemplateFromType
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		protected SalGroupBox gbSource;
		protected cBackgroundText labeldfFileType;
		public cDataField dfFileType;
		protected cBackgroundText labeldfsTypeDescription;
		public cDataField dfsTypeDescription;
		protected SalGroupBox gbDestination;
		protected cBackgroundText labeldfFileId;
		public cDataField dfFileId;
		protected cBackgroundText labeldfsTempDescription;
		public cDataField dfsTempDescription;
		public cCheckBox cbMandatory;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgCreateTemplateFromType));
            this.gbSource = new PPJ.Runtime.Windows.SalGroupBox();
            this.labeldfFileType = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfFileType = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsTypeDescription = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsTypeDescription = new Ifs.Fnd.ApplicationForms.cDataField();
            this.gbDestination = new PPJ.Runtime.Windows.SalGroupBox();
            this.labeldfFileId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfFileId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsTempDescription = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsTempDescription = new Ifs.Fnd.ApplicationForms.cDataField();
            this.cbMandatory = new Ifs.Fnd.ApplicationForms.cCheckBox();
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
            this.ClientArea.Controls.Add(this.cbMandatory);
            this.ClientArea.Controls.Add(this.dfsTempDescription);
            this.ClientArea.Controls.Add(this.dfFileId);
            this.ClientArea.Controls.Add(this.dfsTypeDescription);
            this.ClientArea.Controls.Add(this.dfFileType);
            this.ClientArea.Controls.Add(this.labeldfsTempDescription);
            this.ClientArea.Controls.Add(this.labeldfFileId);
            this.ClientArea.Controls.Add(this.labeldfsTypeDescription);
            this.ClientArea.Controls.Add(this.labeldfFileType);
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
            this.dfFileType.NamedProperties.Put("LovReference", "EXT_FILE_TYPE");
            this.dfFileType.NamedProperties.Put("ResizeableChildObject", "");
            this.dfFileType.NamedProperties.Put("SqlColumn", "FILE_TYPE");
            this.dfFileType.NamedProperties.Put("ValidateMethod", "");
            this.dfFileType.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfFileType_WindowActions);
            // 
            // labeldfsTypeDescription
            // 
            resources.ApplyResources(this.labeldfsTypeDescription, "labeldfsTypeDescription");
            this.labeldfsTypeDescription.Name = "labeldfsTypeDescription";
            // 
            // dfsTypeDescription
            // 
            resources.ApplyResources(this.dfsTypeDescription, "dfsTypeDescription");
            this.dfsTypeDescription.Name = "dfsTypeDescription";
            this.dfsTypeDescription.NamedProperties.Put("EnumerateMethod", "");
            this.dfsTypeDescription.NamedProperties.Put("FieldFlags", "288");
            this.dfsTypeDescription.NamedProperties.Put("LovReference", "");
            this.dfsTypeDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsTypeDescription.NamedProperties.Put("SqlColumn", "");
            this.dfsTypeDescription.NamedProperties.Put("ValidateMethod", "");
            this.dfsTypeDescription.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsTypeDescription_WindowActions);
            // 
            // gbDestination
            // 
            resources.ApplyResources(this.gbDestination, "gbDestination");
            this.gbDestination.Name = "gbDestination";
            this.gbDestination.TabStop = false;
            // 
            // labeldfFileId
            // 
            resources.ApplyResources(this.labeldfFileId, "labeldfFileId");
            this.labeldfFileId.Name = "labeldfFileId";
            // 
            // dfFileId
            // 
            resources.ApplyResources(this.dfFileId, "dfFileId");
            this.dfFileId.Name = "dfFileId";
            this.dfFileId.NamedProperties.Put("EnumerateMethod", "");
            this.dfFileId.NamedProperties.Put("FieldFlags", "260");
            this.dfFileId.NamedProperties.Put("LovReference", "");
            this.dfFileId.NamedProperties.Put("ResizeableChildObject", "");
            this.dfFileId.NamedProperties.Put("SqlColumn", "");
            this.dfFileId.NamedProperties.Put("ValidateMethod", "");
            this.dfFileId.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfFileId_WindowActions);
            // 
            // labeldfsTempDescription
            // 
            resources.ApplyResources(this.labeldfsTempDescription, "labeldfsTempDescription");
            this.labeldfsTempDescription.Name = "labeldfsTempDescription";
            // 
            // dfsTempDescription
            // 
            resources.ApplyResources(this.dfsTempDescription, "dfsTempDescription");
            this.dfsTempDescription.Name = "dfsTempDescription";
            this.dfsTempDescription.NamedProperties.Put("EnumerateMethod", "");
            this.dfsTempDescription.NamedProperties.Put("FieldFlags", "292");
            this.dfsTempDescription.NamedProperties.Put("LovReference", "");
            this.dfsTempDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsTempDescription.NamedProperties.Put("SqlColumn", "");
            this.dfsTempDescription.NamedProperties.Put("ValidateMethod", "");
            this.dfsTempDescription.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsTempDescription_WindowActions);
            // 
            // cbMandatory
            // 
            resources.ApplyResources(this.cbMandatory, "cbMandatory");
            this.cbMandatory.Name = "cbMandatory";
            this.cbMandatory.NamedProperties.Put("DataType", "5");
            this.cbMandatory.NamedProperties.Put("EnumerateMethod", "");
            this.cbMandatory.NamedProperties.Put("FieldFlags", "262");
            this.cbMandatory.NamedProperties.Put("LovReference", "");
            this.cbMandatory.NamedProperties.Put("ResizeableChildObject", "");
            this.cbMandatory.NamedProperties.Put("SqlColumn", "");
            this.cbMandatory.NamedProperties.Put("ValidateMethod", "");
            this.cbMandatory.NamedProperties.Put("XDataLength", "");
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
            // dlgCreateTemplateFromType
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "dlgCreateTemplateFromType";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "");
            this.NamedProperties.Put("PackageName", "");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("ViewName", "");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.ShowIcon = false;
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dlgCreateTemplateFromType_WindowActions);
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
