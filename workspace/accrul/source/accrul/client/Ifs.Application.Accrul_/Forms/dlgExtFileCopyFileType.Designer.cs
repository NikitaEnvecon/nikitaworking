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
	
	public partial class dlgExtFileCopyFileType
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		protected SalGroupBox gbSource;
		protected cBackgroundText labeldfFromFileType;
		public cDataField dfFromFileType;
		protected cBackgroundText labeldfsDescriptionFrom;
		public cDataField dfsDescriptionFrom;
		protected SalGroupBox gbDestination;
		protected cBackgroundText labeldfFileType;
		public cDataField dfFileType;
		protected cBackgroundText labeldfsDescriptionTo;
		public cDataField dfsDescriptionTo;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgExtFileCopyFileType));
            this.gbSource = new PPJ.Runtime.Windows.SalGroupBox();
            this.labeldfFromFileType = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfFromFileType = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsDescriptionFrom = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsDescriptionFrom = new Ifs.Fnd.ApplicationForms.cDataField();
            this.gbDestination = new PPJ.Runtime.Windows.SalGroupBox();
            this.labeldfFileType = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfFileType = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsDescriptionTo = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsDescriptionTo = new Ifs.Fnd.ApplicationForms.cDataField();
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
            this.ClientArea.Controls.Add(this.dfsDescriptionTo);
            this.ClientArea.Controls.Add(this.dfFileType);
            this.ClientArea.Controls.Add(this.dfsDescriptionFrom);
            this.ClientArea.Controls.Add(this.dfFromFileType);
            this.ClientArea.Controls.Add(this.labeldfsDescriptionTo);
            this.ClientArea.Controls.Add(this.labeldfFileType);
            this.ClientArea.Controls.Add(this.labeldfsDescriptionFrom);
            this.ClientArea.Controls.Add(this.labeldfFromFileType);
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
            // labeldfFromFileType
            // 
            resources.ApplyResources(this.labeldfFromFileType, "labeldfFromFileType");
            this.labeldfFromFileType.Name = "labeldfFromFileType";
            // 
            // dfFromFileType
            // 
            resources.ApplyResources(this.dfFromFileType, "dfFromFileType");
            this.dfFromFileType.Name = "dfFromFileType";
            this.dfFromFileType.NamedProperties.Put("EnumerateMethod", "");
            this.dfFromFileType.NamedProperties.Put("FieldFlags", "260");
            this.dfFromFileType.NamedProperties.Put("LovReference", "EXT_FILE_TYPE");
            this.dfFromFileType.NamedProperties.Put("ResizeableChildObject", "");
            this.dfFromFileType.NamedProperties.Put("SqlColumn", "FILE_TYPE");
            this.dfFromFileType.NamedProperties.Put("ValidateMethod", "");
            this.dfFromFileType.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfFromFileType_WindowActions);
            // 
            // labeldfsDescriptionFrom
            // 
            resources.ApplyResources(this.labeldfsDescriptionFrom, "labeldfsDescriptionFrom");
            this.labeldfsDescriptionFrom.Name = "labeldfsDescriptionFrom";
            // 
            // dfsDescriptionFrom
            // 
            resources.ApplyResources(this.dfsDescriptionFrom, "dfsDescriptionFrom");
            this.dfsDescriptionFrom.Name = "dfsDescriptionFrom";
            this.dfsDescriptionFrom.NamedProperties.Put("EnumerateMethod", "");
            this.dfsDescriptionFrom.NamedProperties.Put("FieldFlags", "290");
            this.dfsDescriptionFrom.NamedProperties.Put("LovReference", "");
            this.dfsDescriptionFrom.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsDescriptionFrom.NamedProperties.Put("SqlColumn", "");
            this.dfsDescriptionFrom.NamedProperties.Put("ValidateMethod", "");
            this.dfsDescriptionFrom.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsDescriptionFrom_WindowActions);
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
            this.dfsDescriptionTo.NamedProperties.Put("FieldFlags", "260");
            this.dfsDescriptionTo.NamedProperties.Put("LovReference", "");
            this.dfsDescriptionTo.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsDescriptionTo.NamedProperties.Put("SqlColumn", "");
            this.dfsDescriptionTo.NamedProperties.Put("ValidateMethod", "");
            this.dfsDescriptionTo.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsDescriptionTo_WindowActions);
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
            // dlgExtFileCopyFileType
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "dlgExtFileCopyFileType";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "");
            this.NamedProperties.Put("PackageName", "");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("ViewName", "");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.ShowIcon = false;
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dlgExtFileCopyFileType_WindowActions);
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
