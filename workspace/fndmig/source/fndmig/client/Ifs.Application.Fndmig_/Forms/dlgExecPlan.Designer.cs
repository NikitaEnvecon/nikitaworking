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
	
	public partial class dlgExecPlan
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		// Single Execution block
		protected SalGroupBox gbSingle_Execution;
		public SalRadioButton rbOnline;
		public SalRadioButton rbAsap;
		public SalRadioButton rbScheduled;
		public SalRadioButton rbInterval;
		public SalRadioButton rbDaily;
		public SalRadioButton rbWeekly;
		protected SalBackgroundText labeldfScheduledDate;
		public SalDataField dfScheduledDate;
		protected SalBackgroundText labeldfScheduledTime;
		public SalDataField dfScheduledTime;
		// Repeated Execution Block
		protected SalGroupBox gbRepeated_Execution;
		public SalCheckBox cbMonday;
		public SalCheckBox cbTuesday;
		public SalCheckBox cbWednesday;
		public SalCheckBox cbThursday;
		public SalCheckBox cbFriday;
		public SalCheckBox cbSaturday;
		public SalCheckBox cbSunday;
		public SalDataField dfRepeatedTime;
		public SalDataField dfnInterval;
		public SalComboBox cmbInterval;
		public cPushButton pbOk;
		public cPushButton pbCancel;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgExecPlan));
            this.gbSingle_Execution = new PPJ.Runtime.Windows.SalGroupBox();
            this.rbOnline = new PPJ.Runtime.Windows.SalRadioButton();
            this.rbAsap = new PPJ.Runtime.Windows.SalRadioButton();
            this.rbScheduled = new PPJ.Runtime.Windows.SalRadioButton();
            this.rbInterval = new PPJ.Runtime.Windows.SalRadioButton();
            this.rbDaily = new PPJ.Runtime.Windows.SalRadioButton();
            this.rbWeekly = new PPJ.Runtime.Windows.SalRadioButton();
            this.labeldfScheduledDate = new PPJ.Runtime.Windows.SalBackgroundText();
            this.dfScheduledDate = new PPJ.Runtime.Windows.SalDataField();
            this.labeldfScheduledTime = new PPJ.Runtime.Windows.SalBackgroundText();
            this.dfScheduledTime = new PPJ.Runtime.Windows.SalDataField();
            this.gbRepeated_Execution = new PPJ.Runtime.Windows.SalGroupBox();
            this.cbMonday = new PPJ.Runtime.Windows.SalCheckBox();
            this.cbTuesday = new PPJ.Runtime.Windows.SalCheckBox();
            this.cbWednesday = new PPJ.Runtime.Windows.SalCheckBox();
            this.cbThursday = new PPJ.Runtime.Windows.SalCheckBox();
            this.cbFriday = new PPJ.Runtime.Windows.SalCheckBox();
            this.cbSaturday = new PPJ.Runtime.Windows.SalCheckBox();
            this.cbSunday = new PPJ.Runtime.Windows.SalCheckBox();
            this.dfRepeatedTime = new PPJ.Runtime.Windows.SalDataField();
            this.dfnInterval = new PPJ.Runtime.Windows.SalDataField();
            this.cmbInterval = new PPJ.Runtime.Windows.SalComboBox();
            this.pbOk = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbCancel = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.ClientArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Components.Add(this.pbCancel);
            this.commandManager.Components.Add(this.pbOk);
            // 
            // ClientArea
            // 
            this.ClientArea.Controls.Add(this.pbCancel);
            this.ClientArea.Controls.Add(this.pbOk);
            this.ClientArea.Controls.Add(this.cmbInterval);
            this.ClientArea.Controls.Add(this.dfnInterval);
            this.ClientArea.Controls.Add(this.dfRepeatedTime);
            this.ClientArea.Controls.Add(this.cbSunday);
            this.ClientArea.Controls.Add(this.cbSaturday);
            this.ClientArea.Controls.Add(this.cbFriday);
            this.ClientArea.Controls.Add(this.cbThursday);
            this.ClientArea.Controls.Add(this.cbWednesday);
            this.ClientArea.Controls.Add(this.cbTuesday);
            this.ClientArea.Controls.Add(this.cbMonday);
            this.ClientArea.Controls.Add(this.dfScheduledTime);
            this.ClientArea.Controls.Add(this.dfScheduledDate);
            this.ClientArea.Controls.Add(this.rbWeekly);
            this.ClientArea.Controls.Add(this.rbDaily);
            this.ClientArea.Controls.Add(this.rbInterval);
            this.ClientArea.Controls.Add(this.rbScheduled);
            this.ClientArea.Controls.Add(this.rbAsap);
            this.ClientArea.Controls.Add(this.rbOnline);
            this.ClientArea.Controls.Add(this.labeldfScheduledTime);
            this.ClientArea.Controls.Add(this.labeldfScheduledDate);
            this.ClientArea.Controls.Add(this.gbRepeated_Execution);
            this.ClientArea.Controls.Add(this.gbSingle_Execution);
            resources.ApplyResources(this.ClientArea, "ClientArea");
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
            // rbInterval
            // 
            resources.ApplyResources(this.rbInterval, "rbInterval");
            this.rbInterval.Name = "rbInterval";
            this.rbInterval.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.rbInterval_WindowActions);
            // 
            // rbDaily
            // 
            resources.ApplyResources(this.rbDaily, "rbDaily");
            this.rbDaily.Name = "rbDaily";
            this.rbDaily.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.rbDaily_WindowActions);
            // 
            // rbWeekly
            // 
            resources.ApplyResources(this.rbWeekly, "rbWeekly");
            this.rbWeekly.Name = "rbWeekly";
            this.rbWeekly.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.rbWeekly_WindowActions);
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
            // gbRepeated_Execution
            // 
            resources.ApplyResources(this.gbRepeated_Execution, "gbRepeated_Execution");
            this.gbRepeated_Execution.Name = "gbRepeated_Execution";
            this.gbRepeated_Execution.TabStop = false;
            // 
            // cbMonday
            // 
            resources.ApplyResources(this.cbMonday, "cbMonday");
            this.cbMonday.Name = "cbMonday";
            // 
            // cbTuesday
            // 
            resources.ApplyResources(this.cbTuesday, "cbTuesday");
            this.cbTuesday.Name = "cbTuesday";
            // 
            // cbWednesday
            // 
            resources.ApplyResources(this.cbWednesday, "cbWednesday");
            this.cbWednesday.Name = "cbWednesday";
            // 
            // cbThursday
            // 
            resources.ApplyResources(this.cbThursday, "cbThursday");
            this.cbThursday.Name = "cbThursday";
            // 
            // cbFriday
            // 
            resources.ApplyResources(this.cbFriday, "cbFriday");
            this.cbFriday.Name = "cbFriday";
            // 
            // cbSaturday
            // 
            resources.ApplyResources(this.cbSaturday, "cbSaturday");
            this.cbSaturday.Name = "cbSaturday";
            // 
            // cbSunday
            // 
            resources.ApplyResources(this.cbSunday, "cbSunday");
            this.cbSunday.Name = "cbSunday";
            // 
            // dfRepeatedTime
            // 
            this.dfRepeatedTime.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.dfRepeatedTime.EditMask = "99:99";
            resources.ApplyResources(this.dfRepeatedTime, "dfRepeatedTime");
            this.dfRepeatedTime.Format = "HH:mm";
            this.dfRepeatedTime.Name = "dfRepeatedTime";
            // 
            // dfnInterval
            // 
            this.dfnInterval.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfnInterval, "dfnInterval");
            this.dfnInterval.Name = "dfnInterval";
            // 
            // cmbInterval
            // 
            resources.ApplyResources(this.cmbInterval, "cmbInterval");
            this.cmbInterval.Name = "cmbInterval";
            // 
            // pbOk
            // 
            resources.ApplyResources(this.pbOk, "pbOk");
            this.pbOk.Name = "pbOk";
            this.pbOk.NamedProperties.Put("MethodId", "18385");
            this.pbOk.NamedProperties.Put("MethodIdStr", "");
            this.pbOk.NamedProperties.Put("MethodParameter", "OK");
            this.pbOk.NamedProperties.Put("MethodParameterType", "String");
            this.pbOk.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.pbOk.NamedProperties.Put("ResizeableChildObject", "");
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
            // dlgExecPlan
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "dlgExecPlan";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "IntfaceHeader");
            this.NamedProperties.Put("Module", "%");
            this.NamedProperties.Put("PackageName", "INTFACE_HEADER_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "449");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.NamedProperties.Put("ViewName", "INTFACE_HEADER");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dlgExecPlan_WindowActions);
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
