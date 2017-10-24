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
	
	public partial class dlgInterimVoucher
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		protected SalGroupBox gbInterim_Voucher_Information;
		// Bug 81897, Begin, Added colon
		protected cBackgroundText labelcmbUserGroup;
		// Bug 81897, End
		public cComboBox cmbUserGroup;
		protected cBackgroundText labeldfVoucherDate;
		public cDataField dfVoucherDate;
		protected cBackgroundText labeldfAccountingYearPeriod;
		public cDataField dfAccountingYearPeriod;
		protected cBackgroundText labelcmbVoucherType;
		public cComboBox cmbVoucherType;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgInterimVoucher));
            this.gbInterim_Voucher_Information = new PPJ.Runtime.Windows.SalGroupBox();
            this.labelcmbUserGroup = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbUserGroup = new Ifs.Fnd.ApplicationForms.cComboBox();
            this.labeldfVoucherDate = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfVoucherDate = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfAccountingYearPeriod = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfAccountingYearPeriod = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelcmbVoucherType = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbVoucherType = new Ifs.Fnd.ApplicationForms.cComboBox();
            this.pbOk = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbCancel = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.ClientArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolBar
            // 
            resources.ApplyResources(this.ToolBar, "ToolBar");
            // 
            // ClientArea
            // 
            this.ClientArea.Controls.Add(this.pbCancel);
            this.ClientArea.Controls.Add(this.pbOk);
            this.ClientArea.Controls.Add(this.cmbVoucherType);
            this.ClientArea.Controls.Add(this.dfAccountingYearPeriod);
            this.ClientArea.Controls.Add(this.dfVoucherDate);
            this.ClientArea.Controls.Add(this.cmbUserGroup);
            this.ClientArea.Controls.Add(this.labelcmbVoucherType);
            this.ClientArea.Controls.Add(this.labeldfAccountingYearPeriod);
            this.ClientArea.Controls.Add(this.labeldfVoucherDate);
            this.ClientArea.Controls.Add(this.labelcmbUserGroup);
            this.ClientArea.Controls.Add(this.gbInterim_Voucher_Information);
            resources.ApplyResources(this.ClientArea, "ClientArea");
            // 
            // commandManager
            // 
            this.commandManager.Components.Add(this.pbCancel);
            this.commandManager.Components.Add(this.pbOk);
            // 
            // gbInterim_Voucher_Information
            // 
            resources.ApplyResources(this.gbInterim_Voucher_Information, "gbInterim_Voucher_Information");
            this.gbInterim_Voucher_Information.Name = "gbInterim_Voucher_Information";
            this.gbInterim_Voucher_Information.TabStop = false;
            // 
            // labelcmbUserGroup
            // 
            resources.ApplyResources(this.labelcmbUserGroup, "labelcmbUserGroup");
            this.labelcmbUserGroup.Name = "labelcmbUserGroup";
            // 
            // cmbUserGroup
            // 
            this.cmbUserGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cmbUserGroup, "cmbUserGroup");
            this.cmbUserGroup.Name = "cmbUserGroup";
            this.cmbUserGroup.NamedProperties.Put("DataType", "7");
            this.cmbUserGroup.NamedProperties.Put("EnumerateMethod", "");
            this.cmbUserGroup.NamedProperties.Put("FieldFlags", "288");
            this.cmbUserGroup.NamedProperties.Put("LovReference", "");
            this.cmbUserGroup.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbUserGroup.NamedProperties.Put("SqlColumn", "");
            this.cmbUserGroup.NamedProperties.Put("ValidateMethod", "");
            this.cmbUserGroup.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbUserGroup_WindowActions);
            // 
            // labeldfVoucherDate
            // 
            resources.ApplyResources(this.labeldfVoucherDate, "labeldfVoucherDate");
            this.labeldfVoucherDate.Name = "labeldfVoucherDate";
            // 
            // dfVoucherDate
            // 
            this.dfVoucherDate.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.dfVoucherDate.Format = "d";
            resources.ApplyResources(this.dfVoucherDate, "dfVoucherDate");
            this.dfVoucherDate.Name = "dfVoucherDate";
            this.dfVoucherDate.NamedProperties.Put("EnumerateMethod", "");
            this.dfVoucherDate.NamedProperties.Put("LovReference", "");
            this.dfVoucherDate.NamedProperties.Put("ResizeableChildObject", "");
            this.dfVoucherDate.NamedProperties.Put("SqlColumn", "");
            this.dfVoucherDate.NamedProperties.Put("ValidateMethod", "");
            this.dfVoucherDate.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfVoucherDate_WindowActions);
            // 
            // labeldfAccountingYearPeriod
            // 
            resources.ApplyResources(this.labeldfAccountingYearPeriod, "labeldfAccountingYearPeriod");
            this.labeldfAccountingYearPeriod.Name = "labeldfAccountingYearPeriod";
            // 
            // dfAccountingYearPeriod
            // 
            this.dfAccountingYearPeriod.BackColor = System.Drawing.SystemColors.Control;
            this.dfAccountingYearPeriod.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.dfAccountingYearPeriod.EditMask = "9999 99";
            resources.ApplyResources(this.dfAccountingYearPeriod, "dfAccountingYearPeriod");
            this.dfAccountingYearPeriod.Name = "dfAccountingYearPeriod";
            this.dfAccountingYearPeriod.NamedProperties.Put("EnumerateMethod", "");
            this.dfAccountingYearPeriod.NamedProperties.Put("FieldFlags", "288");
            this.dfAccountingYearPeriod.NamedProperties.Put("LovReference", "");
            this.dfAccountingYearPeriod.NamedProperties.Put("ResizeableChildObject", "");
            this.dfAccountingYearPeriod.NamedProperties.Put("SqlColumn", "");
            this.dfAccountingYearPeriod.NamedProperties.Put("ValidateMethod", "");
            this.dfAccountingYearPeriod.ReadOnly = true;
            this.dfAccountingYearPeriod.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfAccountingYearPeriod_WindowActions);
            // 
            // labelcmbVoucherType
            // 
            resources.ApplyResources(this.labelcmbVoucherType, "labelcmbVoucherType");
            this.labelcmbVoucherType.Name = "labelcmbVoucherType";
            // 
            // cmbVoucherType
            // 
            this.cmbVoucherType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cmbVoucherType, "cmbVoucherType");
            this.cmbVoucherType.Name = "cmbVoucherType";
            this.cmbVoucherType.NamedProperties.Put("EnumerateMethod", "");
            this.cmbVoucherType.NamedProperties.Put("FieldFlags", "288");
            this.cmbVoucherType.NamedProperties.Put("Format", "9");
            this.cmbVoucherType.NamedProperties.Put("LovReference", "");
            this.cmbVoucherType.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbVoucherType.NamedProperties.Put("SqlColumn", "");
            this.cmbVoucherType.NamedProperties.Put("ValidateMethod", "");
            this.cmbVoucherType.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbVoucherType_WindowActions);
            // 
            // pbOk
            // 
            this.pbOk.AcceleratorKey = System.Windows.Forms.Keys.Return;
            resources.ApplyResources(this.pbOk, "pbOk");
            this.pbOk.Name = "pbOk";
            this.pbOk.NamedProperties.Put("MethodId", "18385");
            this.pbOk.NamedProperties.Put("MethodParameter", "ButtonOk");
            this.pbOk.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // pbCancel
            // 
            this.pbCancel.AcceleratorKey = System.Windows.Forms.Keys.Escape;
            resources.ApplyResources(this.pbCancel, "pbCancel");
            this.pbCancel.Name = "pbCancel";
            this.pbCancel.NamedProperties.Put("MethodId", "18385");
            this.pbCancel.NamedProperties.Put("MethodParameter", "ButonCancel");
            this.pbCancel.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // dlgInterimVoucher
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "dlgInterimVoucher";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "Voucher");
            this.NamedProperties.Put("PackageName", "VOUCHER_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "0");
            this.NamedProperties.Put("ViewName", "VOUCHER");
            this.ShowIcon = false;
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dlgInterimVoucher_WindowActions);
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
