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
	
	public partial class dlgPaymentTermDetails
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		protected cBackgroundText labeldfnNoOfInstallments;
		public cDataField dfnNoOfInstallments;
		protected cBackgroundText labeldfnNoOfFreeDelivMonths;
		public cDataField dfnNoOfFreeDelivMonths;
		protected cBackgroundText labeldfnDaysToDueDate;
		public cDataField dfnDaysToDueDate;
		public cCheckBox cbEndOfMonth;
		protected cBackgroundText labeldfnDueDay1;
		public cDataField dfnDueDay1;
		protected cBackgroundText labeldfnDueDay2;
		public cDataField dfnDueDay2;
		protected cBackgroundText labeldfnDueDay3;
		public cDataField dfnDueDay3;
		protected cBackgroundText labeldfsInstituteId;
		public cDataField dfsInstituteId;
		protected cBackgroundText labeldfWayId;
		public cDataField dfWayId;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgPaymentTermDetails));
            this.labeldfnNoOfInstallments = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfnNoOfInstallments = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfnNoOfFreeDelivMonths = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfnNoOfFreeDelivMonths = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfnDaysToDueDate = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfnDaysToDueDate = new Ifs.Fnd.ApplicationForms.cDataField();
            this.cbEndOfMonth = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.labeldfnDueDay1 = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfnDueDay1 = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfnDueDay2 = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfnDueDay2 = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfnDueDay3 = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfnDueDay3 = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsInstituteId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsInstituteId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfWayId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfWayId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.pbOk = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbCancel = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbList = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.ClientArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // ClientArea
            // 
            this.ClientArea.Controls.Add(this.pbList);
            this.ClientArea.Controls.Add(this.pbCancel);
            this.ClientArea.Controls.Add(this.pbOk);
            this.ClientArea.Controls.Add(this.dfWayId);
            this.ClientArea.Controls.Add(this.dfsInstituteId);
            this.ClientArea.Controls.Add(this.dfnDueDay3);
            this.ClientArea.Controls.Add(this.dfnDueDay2);
            this.ClientArea.Controls.Add(this.dfnDueDay1);
            this.ClientArea.Controls.Add(this.cbEndOfMonth);
            this.ClientArea.Controls.Add(this.dfnDaysToDueDate);
            this.ClientArea.Controls.Add(this.dfnNoOfFreeDelivMonths);
            this.ClientArea.Controls.Add(this.dfnNoOfInstallments);
            this.ClientArea.Controls.Add(this.labeldfWayId);
            this.ClientArea.Controls.Add(this.labeldfsInstituteId);
            this.ClientArea.Controls.Add(this.labeldfnDueDay3);
            this.ClientArea.Controls.Add(this.labeldfnDueDay2);
            this.ClientArea.Controls.Add(this.labeldfnDueDay1);
            this.ClientArea.Controls.Add(this.labeldfnDaysToDueDate);
            this.ClientArea.Controls.Add(this.labeldfnNoOfFreeDelivMonths);
            this.ClientArea.Controls.Add(this.labeldfnNoOfInstallments);
            resources.ApplyResources(this.ClientArea, "ClientArea");
            // 
            // commandManager
            // 
            this.commandManager.Components.Add(this.pbList);
            this.commandManager.Components.Add(this.pbCancel);
            this.commandManager.Components.Add(this.pbOk);
            // 
            // labeldfnNoOfInstallments
            // 
            resources.ApplyResources(this.labeldfnNoOfInstallments, "labeldfnNoOfInstallments");
            this.labeldfnNoOfInstallments.Name = "labeldfnNoOfInstallments";
            // 
            // dfnNoOfInstallments
            // 
            this.dfnNoOfInstallments.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.dfnNoOfInstallments.Format = "#0";
            resources.ApplyResources(this.dfnNoOfInstallments, "dfnNoOfInstallments");
            this.dfnNoOfInstallments.Name = "dfnNoOfInstallments";
            this.dfnNoOfInstallments.NamedProperties.Put("EnumerateMethod", "");
            this.dfnNoOfInstallments.NamedProperties.Put("FieldFlags", "263");
            this.dfnNoOfInstallments.NamedProperties.Put("LovReference", "");
            this.dfnNoOfInstallments.NamedProperties.Put("SqlColumn", "");
            this.dfnNoOfInstallments.NamedProperties.Put("ValidateMethod", "");
            this.dfnNoOfInstallments.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfnNoOfInstallments_WindowActions);
            // 
            // labeldfnNoOfFreeDelivMonths
            // 
            resources.ApplyResources(this.labeldfnNoOfFreeDelivMonths, "labeldfnNoOfFreeDelivMonths");
            this.labeldfnNoOfFreeDelivMonths.Name = "labeldfnNoOfFreeDelivMonths";
            // 
            // dfnNoOfFreeDelivMonths
            // 
            this.dfnNoOfFreeDelivMonths.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.dfnNoOfFreeDelivMonths.Format = "#0";
            resources.ApplyResources(this.dfnNoOfFreeDelivMonths, "dfnNoOfFreeDelivMonths");
            this.dfnNoOfFreeDelivMonths.Name = "dfnNoOfFreeDelivMonths";
            this.dfnNoOfFreeDelivMonths.NamedProperties.Put("EnumerateMethod", "");
            this.dfnNoOfFreeDelivMonths.NamedProperties.Put("FieldFlags", "263");
            this.dfnNoOfFreeDelivMonths.NamedProperties.Put("LovReference", "");
            this.dfnNoOfFreeDelivMonths.NamedProperties.Put("SqlColumn", "");
            this.dfnNoOfFreeDelivMonths.NamedProperties.Put("ValidateMethod", "");
            this.dfnNoOfFreeDelivMonths.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfnNoOfFreeDelivMonths_WindowActions);
            // 
            // labeldfnDaysToDueDate
            // 
            resources.ApplyResources(this.labeldfnDaysToDueDate, "labeldfnDaysToDueDate");
            this.labeldfnDaysToDueDate.Name = "labeldfnDaysToDueDate";
            // 
            // dfnDaysToDueDate
            // 
            this.dfnDaysToDueDate.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfnDaysToDueDate, "dfnDaysToDueDate");
            this.dfnDaysToDueDate.Name = "dfnDaysToDueDate";
            this.dfnDaysToDueDate.NamedProperties.Put("EnumerateMethod", "");
            this.dfnDaysToDueDate.NamedProperties.Put("FieldFlags", "262");
            this.dfnDaysToDueDate.NamedProperties.Put("LovReference", "");
            this.dfnDaysToDueDate.NamedProperties.Put("SqlColumn", "");
            this.dfnDaysToDueDate.NamedProperties.Put("ValidateMethod", "");
            this.dfnDaysToDueDate.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfnDaysToDueDate_WindowActions);
            // 
            // cbEndOfMonth
            // 
            resources.ApplyResources(this.cbEndOfMonth, "cbEndOfMonth");
            this.cbEndOfMonth.Name = "cbEndOfMonth";
            this.cbEndOfMonth.NamedProperties.Put("DataType", "5");
            this.cbEndOfMonth.NamedProperties.Put("EnumerateMethod", "");
            this.cbEndOfMonth.NamedProperties.Put("FieldFlags", "262");
            this.cbEndOfMonth.NamedProperties.Put("LovReference", "");
            this.cbEndOfMonth.NamedProperties.Put("SqlColumn", "");
            this.cbEndOfMonth.NamedProperties.Put("ValidateMethod", "");
            this.cbEndOfMonth.NamedProperties.Put("XDataLength", "");
            this.cbEndOfMonth.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cbEndOfMonth_WindowActions);
            // 
            // labeldfnDueDay1
            // 
            resources.ApplyResources(this.labeldfnDueDay1, "labeldfnDueDay1");
            this.labeldfnDueDay1.Name = "labeldfnDueDay1";
            // 
            // dfnDueDay1
            // 
            this.dfnDueDay1.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfnDueDay1, "dfnDueDay1");
            this.dfnDueDay1.Name = "dfnDueDay1";
            this.dfnDueDay1.NamedProperties.Put("EnumerateMethod", "");
            this.dfnDueDay1.NamedProperties.Put("FieldFlags", "262");
            this.dfnDueDay1.NamedProperties.Put("LovReference", "");
            this.dfnDueDay1.NamedProperties.Put("SqlColumn", "");
            this.dfnDueDay1.NamedProperties.Put("ValidateMethod", "");
            this.dfnDueDay1.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfnDueDay1_WindowActions);
            // 
            // labeldfnDueDay2
            // 
            resources.ApplyResources(this.labeldfnDueDay2, "labeldfnDueDay2");
            this.labeldfnDueDay2.Name = "labeldfnDueDay2";
            // 
            // dfnDueDay2
            // 
            this.dfnDueDay2.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfnDueDay2, "dfnDueDay2");
            this.dfnDueDay2.Name = "dfnDueDay2";
            this.dfnDueDay2.NamedProperties.Put("EnumerateMethod", "");
            this.dfnDueDay2.NamedProperties.Put("FieldFlags", "262");
            this.dfnDueDay2.NamedProperties.Put("LovReference", "");
            this.dfnDueDay2.NamedProperties.Put("SqlColumn", "");
            this.dfnDueDay2.NamedProperties.Put("ValidateMethod", "");
            this.dfnDueDay2.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfnDueDay2_WindowActions);
            // 
            // labeldfnDueDay3
            // 
            resources.ApplyResources(this.labeldfnDueDay3, "labeldfnDueDay3");
            this.labeldfnDueDay3.Name = "labeldfnDueDay3";
            // 
            // dfnDueDay3
            // 
            this.dfnDueDay3.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfnDueDay3, "dfnDueDay3");
            this.dfnDueDay3.Name = "dfnDueDay3";
            this.dfnDueDay3.NamedProperties.Put("EnumerateMethod", "");
            this.dfnDueDay3.NamedProperties.Put("FieldFlags", "262");
            this.dfnDueDay3.NamedProperties.Put("LovReference", "");
            this.dfnDueDay3.NamedProperties.Put("SqlColumn", "");
            this.dfnDueDay3.NamedProperties.Put("ValidateMethod", "");
            this.dfnDueDay3.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfnDueDay3_WindowActions);
            // 
            // labeldfsInstituteId
            // 
            resources.ApplyResources(this.labeldfsInstituteId, "labeldfsInstituteId");
            this.labeldfsInstituteId.Name = "labeldfsInstituteId";
            // 
            // dfsInstituteId
            // 
            this.dfsInstituteId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsInstituteId, "dfsInstituteId");
            this.dfsInstituteId.Name = "dfsInstituteId";
            this.dfsInstituteId.NamedProperties.Put("EnumerateMethod", "");
            this.dfsInstituteId.NamedProperties.Put("FieldFlags", "263");
            this.dfsInstituteId.NamedProperties.Put("LovReference", "");
            this.dfsInstituteId.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsInstituteId.NamedProperties.Put("SqlColumn", "");
            this.dfsInstituteId.NamedProperties.Put("ValidateMethod", "");
            this.dfsInstituteId.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsInstituteId_WindowActions);
            // 
            // labeldfWayId
            // 
            resources.ApplyResources(this.labeldfWayId, "labeldfWayId");
            this.labeldfWayId.Name = "labeldfWayId";
            // 
            // dfWayId
            // 
            this.dfWayId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfWayId, "dfWayId");
            this.dfWayId.Name = "dfWayId";
            this.dfWayId.NamedProperties.Put("EnumerateMethod", "");
            this.dfWayId.NamedProperties.Put("FieldFlags", "263");
            this.dfWayId.NamedProperties.Put("LovReference", "");
            this.dfWayId.NamedProperties.Put("ResizeableChildObject", "");
            this.dfWayId.NamedProperties.Put("SqlColumn", "");
            this.dfWayId.NamedProperties.Put("ValidateMethod", "");
            this.dfWayId.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfWayId_WindowActions);
            // 
            // pbOk
            // 
            this.pbOk.AcceleratorKey = System.Windows.Forms.Keys.Return;
            resources.ApplyResources(this.pbOk, "pbOk");
            this.pbOk.Name = "pbOk";
            this.pbOk.NamedProperties.Put("MethodId", "18385");
            this.pbOk.NamedProperties.Put("MethodParameter", "Ok");
            this.pbOk.NamedProperties.Put("ResizeableChildObject", "");
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
            // pbList
            // 
            this.pbList.AcceleratorKey = System.Windows.Forms.Keys.F8;
            resources.ApplyResources(this.pbList, "pbList");
            this.pbList.Name = "pbList";
            this.pbList.NamedProperties.Put("MethodId", "18385");
            this.pbList.NamedProperties.Put("MethodParameter", "List");
            this.pbList.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // dlgPaymentTermDetails
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "dlgPaymentTermDetails";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "PaymentTermDetails");
            this.NamedProperties.Put("PackageName", "PAYMENT_TERM_DETAILS_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("ViewName", "");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.ShowIcon = false;
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dlgPaymentTermDetails_WindowActions);
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
