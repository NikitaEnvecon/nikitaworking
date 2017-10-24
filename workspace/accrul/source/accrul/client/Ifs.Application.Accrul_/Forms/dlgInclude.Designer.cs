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
	
	public partial class dlgInclude
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		// Bug 86390 begin, changed the data field type to cDataFieldFin
		protected cBackgroundText labeldfEMUValidDate;
		public cDataFieldFin dfEMUValidDate;
		// Bug 86390 end
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgInclude));
            this.labeldfEMUValidDate = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfEMUValidDate = new Ifs.Application.Accrul.cDataFieldFin();
            this.pbOK = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbCancel = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.ClientArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // ClientArea
            // 
            this.ClientArea.Controls.Add(this.pbCancel);
            this.ClientArea.Controls.Add(this.pbOK);
            this.ClientArea.Controls.Add(this.dfEMUValidDate);
            this.ClientArea.Controls.Add(this.labeldfEMUValidDate);
            resources.ApplyResources(this.ClientArea, "ClientArea");
            // 
            // commandManager
            // 
            this.commandManager.Components.Add(this.pbCancel);
            this.commandManager.Components.Add(this.pbOK);
            // 
            // labeldfEMUValidDate
            // 
            resources.ApplyResources(this.labeldfEMUValidDate, "labeldfEMUValidDate");
            this.labeldfEMUValidDate.Name = "labeldfEMUValidDate";
            // 
            // dfEMUValidDate
            // 
            this.dfEMUValidDate.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.dfEMUValidDate.Format = "d";
            resources.ApplyResources(this.dfEMUValidDate, "dfEMUValidDate");
            this.dfEMUValidDate.Name = "dfEMUValidDate";
            this.dfEMUValidDate.NamedProperties.Put("EnumerateMethod", "");
            this.dfEMUValidDate.NamedProperties.Put("LovReference", "");
            this.dfEMUValidDate.NamedProperties.Put("ResizeableChildObject", "");
            this.dfEMUValidDate.NamedProperties.Put("SqlColumn", "");
            this.dfEMUValidDate.NamedProperties.Put("ValidateMethod", "");
            this.dfEMUValidDate.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfEMUValidDate_WindowActions);
            // 
            // pbOK
            // 
            this.pbOK.AcceleratorKey = System.Windows.Forms.Keys.Return;
            resources.ApplyResources(this.pbOK, "pbOK");
            this.pbOK.Name = "pbOK";
            this.pbOK.NamedProperties.Put("MethodId", "18385");
            this.pbOK.NamedProperties.Put("MethodParameter", "Ok");
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
            // 
            // dlgInclude
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "dlgInclude";
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
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dlgInclude_WindowActions);
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
