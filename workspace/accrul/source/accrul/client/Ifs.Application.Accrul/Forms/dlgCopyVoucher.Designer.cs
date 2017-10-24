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
	
	public partial class dlgCopyVoucher
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		protected SalGroupBox gbCopy_Voucher_Information;
		protected cBackgroundText labeldfAccountingYearPeriod;
		public cDataField dfAccountingYearPeriod;
		protected cBackgroundText labeldfVoucherType;
		public cDataField dfVoucherType;
		protected cBackgroundText labeldfVoucherNo;
		public cDataField dfVoucherNo;
		public cCheckBox cbCorrection;
		public cCheckBox cbReverse;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgCopyVoucher));
            this.gbCopy_Voucher_Information = new PPJ.Runtime.Windows.SalGroupBox();
            this.labeldfAccountingYearPeriod = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfAccountingYearPeriod = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfVoucherType = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfVoucherType = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfVoucherNo = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfVoucherNo = new Ifs.Fnd.ApplicationForms.cDataField();
            this.cbCorrection = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.cbReverse = new Ifs.Fnd.ApplicationForms.cCheckBox();
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
            this.ClientArea.Controls.Add(this.cbReverse);
            this.ClientArea.Controls.Add(this.cbCorrection);
            this.ClientArea.Controls.Add(this.dfVoucherNo);
            this.ClientArea.Controls.Add(this.dfVoucherType);
            this.ClientArea.Controls.Add(this.dfAccountingYearPeriod);
            this.ClientArea.Controls.Add(this.labeldfVoucherNo);
            this.ClientArea.Controls.Add(this.labeldfVoucherType);
            this.ClientArea.Controls.Add(this.labeldfAccountingYearPeriod);
            this.ClientArea.Controls.Add(this.gbCopy_Voucher_Information);
            resources.ApplyResources(this.ClientArea, "ClientArea");
            // 
            // commandManager
            // 
            this.commandManager.Components.Add(this.pbCancel);
            this.commandManager.Components.Add(this.pbOk);
            // 
            // gbCopy_Voucher_Information
            // 
            resources.ApplyResources(this.gbCopy_Voucher_Information, "gbCopy_Voucher_Information");
            this.gbCopy_Voucher_Information.Name = "gbCopy_Voucher_Information";
            this.gbCopy_Voucher_Information.TabStop = false;
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
            resources.ApplyResources(this.dfAccountingYearPeriod, "dfAccountingYearPeriod");
            this.dfAccountingYearPeriod.Name = "dfAccountingYearPeriod";
            this.dfAccountingYearPeriod.NamedProperties.Put("EnumerateMethod", "");
            this.dfAccountingYearPeriod.NamedProperties.Put("LovReference", "");
            this.dfAccountingYearPeriod.NamedProperties.Put("ResizeableChildObject", "");
            this.dfAccountingYearPeriod.NamedProperties.Put("SqlColumn", "");
            this.dfAccountingYearPeriod.NamedProperties.Put("ValidateMethod", "");
            this.dfAccountingYearPeriod.ReadOnly = true;
            // 
            // labeldfVoucherType
            // 
            resources.ApplyResources(this.labeldfVoucherType, "labeldfVoucherType");
            this.labeldfVoucherType.Name = "labeldfVoucherType";
            // 
            // dfVoucherType
            // 
            this.dfVoucherType.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.dfVoucherType, "dfVoucherType");
            this.dfVoucherType.Name = "dfVoucherType";
            this.dfVoucherType.NamedProperties.Put("EnumerateMethod", "");
            this.dfVoucherType.NamedProperties.Put("LovReference", "");
            this.dfVoucherType.NamedProperties.Put("ResizeableChildObject", "");
            this.dfVoucherType.NamedProperties.Put("SqlColumn", "");
            this.dfVoucherType.NamedProperties.Put("ValidateMethod", "");
            this.dfVoucherType.ReadOnly = true;
            // 
            // labeldfVoucherNo
            // 
            resources.ApplyResources(this.labeldfVoucherNo, "labeldfVoucherNo");
            this.labeldfVoucherNo.Name = "labeldfVoucherNo";
            // 
            // dfVoucherNo
            // 
            this.dfVoucherNo.BackColor = System.Drawing.SystemColors.Control;
            this.dfVoucherNo.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfVoucherNo, "dfVoucherNo");
            this.dfVoucherNo.Name = "dfVoucherNo";
            this.dfVoucherNo.ReadOnly = true;
            // 
            // cbCorrection
            // 
            resources.ApplyResources(this.cbCorrection, "cbCorrection");
            this.cbCorrection.Name = "cbCorrection";
            this.cbCorrection.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cbCorrection_WindowActions);
            // 
            // cbReverse
            // 
            resources.ApplyResources(this.cbReverse, "cbReverse");
            this.cbReverse.Name = "cbReverse";
            this.cbReverse.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cbReverse_WindowActions);
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
            // dlgCopyVoucher
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "dlgCopyVoucher";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "NULL");
            this.NamedProperties.Put("PackageName", "");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "0");
            this.NamedProperties.Put("SourceFlags", "448");
            this.NamedProperties.Put("ViewName", "");
            this.ShowIcon = false;
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dlgCopyVoucher_WindowActions);
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
