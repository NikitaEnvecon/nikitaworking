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
	
	public partial class dlgRepSelectIncludeExclude
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		protected cBackgroundText labellbCols;
		public VisRadioListBox lbCols;
		public SalPushbutton pbOk;
		public SalPushbutton pbCancel;
		public cPushButton pbSave;
		public cPushButton pbManual;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgRepSelectIncludeExclude));
            this.labellbCols = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.lbCols = new PPJ.Runtime.Vis.VisRadioListBox();
            this.pbOk = new PPJ.Runtime.Windows.SalPushbutton();
            this.pbCancel = new PPJ.Runtime.Windows.SalPushbutton();
            this.pbSave = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbManual = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.ClientArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // ClientArea
            // 
            this.ClientArea.Controls.Add(this.pbManual);
            this.ClientArea.Controls.Add(this.pbSave);
            this.ClientArea.Controls.Add(this.pbCancel);
            this.ClientArea.Controls.Add(this.pbOk);
            this.ClientArea.Controls.Add(this.lbCols);
            this.ClientArea.Controls.Add(this.labellbCols);
            resources.ApplyResources(this.ClientArea, "ClientArea");
            // 
            // commandManager
            // 
            this.commandManager.Components.Add(this.pbManual);
            this.commandManager.Components.Add(this.pbSave);
            // 
            // labellbCols
            // 
            resources.ApplyResources(this.labellbCols, "labellbCols");
            this.labellbCols.Name = "labellbCols";
            // 
            // lbCols
            // 
            resources.ApplyResources(this.lbCols, "lbCols");
            this.lbCols.Name = "lbCols";
            this.lbCols.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbCols.Sorted = false;
            this.lbCols.UseCustomTabOffsets = true;
            // 
            // pbOk
            // 
            this.pbOk.AcceleratorKey = System.Windows.Forms.Keys.Return;
            resources.ApplyResources(this.pbOk, "pbOk");
            this.pbOk.Name = "pbOk";
            this.pbOk.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.pbOk_WindowActions);
            // 
            // pbCancel
            // 
            this.pbCancel.AcceleratorKey = System.Windows.Forms.Keys.Escape;
            resources.ApplyResources(this.pbCancel, "pbCancel");
            this.pbCancel.Name = "pbCancel";
            this.pbCancel.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.pbCancel_WindowActions);
            // 
            // pbSave
            // 
            resources.ApplyResources(this.pbSave, "pbSave");
            this.pbSave.Name = "pbSave";
            this.pbSave.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.pbSave_WindowActions);
            // 
            // pbManual
            // 
            resources.ApplyResources(this.pbManual, "pbManual");
            this.pbManual.Name = "pbManual";
            this.pbManual.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.pbManual_WindowActions);
            // 
            // dlgRepSelectIncludeExclude
            // 
            resources.ApplyResources(this, "$this");
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Name = "dlgRepSelectIncludeExclude";
            this.ShowIcon = false;
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dlgRepSelectIncludeExclude_WindowActions);
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
