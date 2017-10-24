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

namespace Ifs.Application.Accrul
{
	
	public partial class dlgAuditFileResult
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		protected cBackgroundText labeldfsOutputFileName;
		public cDataField dfsOutputFileName;
		public cPushButton pbOk;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgAuditFileResult));
            this.labeldfsOutputFileName = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsOutputFileName = new Ifs.Fnd.ApplicationForms.cDataField();
            this.pbOk = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.ClientArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // ClientArea
            // 
            this.ClientArea.Controls.Add(this.pbOk);
            this.ClientArea.Controls.Add(this.dfsOutputFileName);
            this.ClientArea.Controls.Add(this.labeldfsOutputFileName);
            resources.ApplyResources(this.ClientArea, "ClientArea");
            // 
            // commandManager
            // 
            this.commandManager.Components.Add(this.pbOk);
            // 
            // labeldfsOutputFileName
            // 
            resources.ApplyResources(this.labeldfsOutputFileName, "labeldfsOutputFileName");
            this.labeldfsOutputFileName.Name = "labeldfsOutputFileName";
            // 
            // dfsOutputFileName
            // 
            resources.ApplyResources(this.dfsOutputFileName, "dfsOutputFileName");
            this.dfsOutputFileName.Name = "dfsOutputFileName";
            this.dfsOutputFileName.NamedProperties.Put("EnumerateMethod", "");
            this.dfsOutputFileName.NamedProperties.Put("LovReference", "");
            this.dfsOutputFileName.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsOutputFileName.NamedProperties.Put("SqlColumn", "");
            this.dfsOutputFileName.NamedProperties.Put("ValidateMethod", "");
            // 
            // pbOk
            // 
            this.pbOk.AcceleratorKey = System.Windows.Forms.Keys.Return;
            resources.ApplyResources(this.pbOk, "pbOk");
            this.pbOk.Name = "pbOk";
            this.pbOk.NamedProperties.Put("MethodId", "18385");
            this.pbOk.NamedProperties.Put("MethodParameter", "Ok_Button");
            this.pbOk.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // dlgAuditFileResult
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "dlgAuditFileResult";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "");
            this.NamedProperties.Put("PackageName", "");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "448");
            this.NamedProperties.Put("ViewName", "");
            this.ShowIcon = false;
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dlgAuditFileResult_WindowActions);
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
