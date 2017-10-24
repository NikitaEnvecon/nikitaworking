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
using Ifs.Fnd.ApplicationForms;
using PPJ.Runtime;
using PPJ.Runtime.Sql;
using PPJ.Runtime.Vis;
using PPJ.Runtime.Windows;
using PPJ.Runtime.Windows.QO;

namespace Ifs.Application.Fndmig_
{
	
	public partial class dlgExecSingel
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		protected SalGroupBox gbSingle_Execution;
		public SalRadioButton rbOnline;
		public SalRadioButton rbAsap;
		public SalRadioButton rbScheduled;
		protected SalBackgroundText labeldfScheduledDate;
		public SalDataField dfScheduledDate;
		protected SalBackgroundText labeldfScheduledTime;
		public SalDataField dfScheduledTime;
		public cPushButton pbStart;
		public cPushButton pbRestart;
		public cPushButton pbCancel;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgExecSingel));
            this.gbSingle_Execution = new PPJ.Runtime.Windows.SalGroupBox();
            this.rbOnline = new PPJ.Runtime.Windows.SalRadioButton();
            this.rbAsap = new PPJ.Runtime.Windows.SalRadioButton();
            this.rbScheduled = new PPJ.Runtime.Windows.SalRadioButton();
            this.labeldfScheduledDate = new PPJ.Runtime.Windows.SalBackgroundText();
            this.dfScheduledDate = new PPJ.Runtime.Windows.SalDataField();
            this.labeldfScheduledTime = new PPJ.Runtime.Windows.SalBackgroundText();
            this.dfScheduledTime = new PPJ.Runtime.Windows.SalDataField();
            this.pbStart = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbRestart = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbCancel = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.ClientArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // ClientArea
            // 
            this.ClientArea.Controls.Add(this.pbCancel);
            this.ClientArea.Controls.Add(this.pbRestart);
            this.ClientArea.Controls.Add(this.pbStart);
            this.ClientArea.Controls.Add(this.dfScheduledTime);
            this.ClientArea.Controls.Add(this.dfScheduledDate);
            this.ClientArea.Controls.Add(this.rbScheduled);
            this.ClientArea.Controls.Add(this.rbAsap);
            this.ClientArea.Controls.Add(this.rbOnline);
            this.ClientArea.Controls.Add(this.labeldfScheduledTime);
            this.ClientArea.Controls.Add(this.labeldfScheduledDate);
            this.ClientArea.Controls.Add(this.gbSingle_Execution);
            resources.ApplyResources(this.ClientArea, "ClientArea");
            // 
            // commandManager
            // 
            this.commandManager.Components.Add(this.pbCancel);
            this.commandManager.Components.Add(this.pbRestart);
            this.commandManager.Components.Add(this.pbStart);
            // 
            // gbSingle_Execution
            // 
            resources.ApplyResources(this.gbSingle_Execution, "gbSingle_Execution");
            this.gbSingle_Execution.Name = "gbSingle_Execution";
            this.gbSingle_Execution.TabStop = false;
            // 
            // rbOnline
            // 
            resources.ApplyResources(this.rbOnline, "rbOnline");
            this.rbOnline.Name = "rbOnline";
            this.rbOnline.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.rbOnline_WindowActions);
            // 
            // rbAsap
            // 
            resources.ApplyResources(this.rbAsap, "rbAsap");
            this.rbAsap.Name = "rbAsap";
            this.rbAsap.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.rbAsap_WindowActions);
            // 
            // rbScheduled
            // 
            resources.ApplyResources(this.rbScheduled, "rbScheduled");
            this.rbScheduled.Name = "rbScheduled";
            this.rbScheduled.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.rbScheduled_WindowActions);
            // 
            // labeldfScheduledDate
            // 
            resources.ApplyResources(this.labeldfScheduledDate, "labeldfScheduledDate");
            this.labeldfScheduledDate.Name = "labeldfScheduledDate";
            // 
            // dfScheduledDate
            // 
            this.dfScheduledDate.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            resources.ApplyResources(this.dfScheduledDate, "dfScheduledDate");
            this.dfScheduledDate.Format = "d";
            this.dfScheduledDate.Name = "dfScheduledDate";
            // 
            // labeldfScheduledTime
            // 
            resources.ApplyResources(this.labeldfScheduledTime, "labeldfScheduledTime");
            this.labeldfScheduledTime.Name = "labeldfScheduledTime";
            // 
            // dfScheduledTime
            // 
            this.dfScheduledTime.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.dfScheduledTime.EditMask = "99:99";
            resources.ApplyResources(this.dfScheduledTime, "dfScheduledTime");
            this.dfScheduledTime.Format = "HH:mm";
            this.dfScheduledTime.Name = "dfScheduledTime";
            // 
            // pbStart
            // 
            resources.ApplyResources(this.pbStart, "pbStart");
            this.pbStart.Name = "pbStart";
            this.pbStart.NamedProperties.Put("MethodId", "18385");
            this.pbStart.NamedProperties.Put("MethodIdStr", "");
            this.pbStart.NamedProperties.Put("MethodParameter", "StartProcedure");
            this.pbStart.NamedProperties.Put("MethodParameterType", "String");
            this.pbStart.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.pbStart.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // pbRestart
            // 
            resources.ApplyResources(this.pbRestart, "pbRestart");
            this.pbRestart.Name = "pbRestart";
            this.pbRestart.NamedProperties.Put("MethodId", "18385");
            this.pbRestart.NamedProperties.Put("MethodIdStr", "");
            this.pbRestart.NamedProperties.Put("MethodParameter", "RestartProcedure");
            this.pbRestart.NamedProperties.Put("MethodParameterType", "String");
            this.pbRestart.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.pbRestart.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // pbCancel
            // 
            resources.ApplyResources(this.pbCancel, "pbCancel");
            this.pbCancel.Name = "pbCancel";
            this.pbCancel.NamedProperties.Put("MethodId", "18385");
            this.pbCancel.NamedProperties.Put("MethodIdStr", "");
            this.pbCancel.NamedProperties.Put("MethodParameter", "Cancel");
            this.pbCancel.NamedProperties.Put("MethodParameterType", "String");
            this.pbCancel.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.pbCancel.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // dlgExecSingel
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "dlgExecSingel";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "IntfaceDetail");
            this.NamedProperties.Put("Module", "%");
            this.NamedProperties.Put("PackageName", "INTFACE_DETAIL_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "449");
            this.NamedProperties.Put("ViewName", "INTFACE_DETAIL");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dlgExecSingel_WindowActions);
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
