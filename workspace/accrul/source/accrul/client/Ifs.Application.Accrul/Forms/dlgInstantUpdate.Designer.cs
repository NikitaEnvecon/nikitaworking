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
	
	public partial class dlgInstantUpdate
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
        // Bug 73298 Begin - Changed the derived base class.
		// Bug 73298 End.
		public cPushButton pbUpdate;
		public cPushButton pbCancel;
		public cCheckBox cbAutoUpdate;
		public cPushButton pbQuery;
		public cCheckBox cbAutoPopulate;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgInstantUpdate));
            this.pbUpdate = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbCancel = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.cbAutoUpdate = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.pbQuery = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.cbAutoPopulate = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.tblInstVouUpdate = new Ifs.Application.Accrul.cChildTableFinBase();
            this.tblInstVouUpdate_colsVoucherType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblInstVouUpdate_colnVoucherNo = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblInstVouUpdate_colnAccountingYear = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblInstVouUpdate_colnAccountingPeriod = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblInstVouUpdate_colsUserid = new Ifs.Fnd.ApplicationForms.cColumn();
            this.ClientArea.SuspendLayout();
            this.tblInstVouUpdate.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolBar
            // 
            resources.ApplyResources(this.ToolBar, "ToolBar");
            // 
            // ClientArea
            // 
            this.ClientArea.Controls.Add(this.cbAutoPopulate);
            this.ClientArea.Controls.Add(this.pbQuery);
            this.ClientArea.Controls.Add(this.cbAutoUpdate);
            this.ClientArea.Controls.Add(this.pbCancel);
            this.ClientArea.Controls.Add(this.pbUpdate);
            this.ClientArea.Controls.Add(this.tblInstVouUpdate);
            resources.ApplyResources(this.ClientArea, "ClientArea");
            // 
            // StatusBar
            // 
            this.StatusBar.Create = true;
            resources.ApplyResources(this.StatusBar, "StatusBar");
            // 
            // commandManager
            // 
            this.commandManager.Components.Add(this.pbQuery);
            this.commandManager.Components.Add(this.pbCancel);
            this.commandManager.Components.Add(this.pbUpdate);
            // 
            // pbUpdate
            // 
            this.pbUpdate.AcceleratorKey = System.Windows.Forms.Keys.Return;
            resources.ApplyResources(this.pbUpdate, "pbUpdate");
            this.pbUpdate.Name = "pbUpdate";
            this.pbUpdate.NamedProperties.Put("MethodId", "18385");
            this.pbUpdate.NamedProperties.Put("MethodParameter", "MyOK");
            this.pbUpdate.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // pbCancel
            // 
            this.pbCancel.AcceleratorKey = System.Windows.Forms.Keys.Escape;
            resources.ApplyResources(this.pbCancel, "pbCancel");
            this.pbCancel.Name = "pbCancel";
            this.pbCancel.NamedProperties.Put("MethodId", "18385");
            this.pbCancel.NamedProperties.Put("MethodParameter", "MyCancel");
            this.pbCancel.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // cbAutoUpdate
            // 
            resources.ApplyResources(this.cbAutoUpdate, "cbAutoUpdate");
            this.cbAutoUpdate.Name = "cbAutoUpdate";
            this.cbAutoUpdate.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cbAutoUpdate_WindowActions);
            // 
            // pbQuery
            // 
            resources.ApplyResources(this.pbQuery, "pbQuery");
            this.pbQuery.Name = "pbQuery";
            this.pbQuery.NamedProperties.Put("MethodId", "18385");
            this.pbQuery.NamedProperties.Put("MethodParameter", "MyQuery");
            this.pbQuery.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // cbAutoPopulate
            // 
            resources.ApplyResources(this.cbAutoPopulate, "cbAutoPopulate");
            this.cbAutoPopulate.Name = "cbAutoPopulate";
            this.cbAutoPopulate.NamedProperties.Put("DataType", "5");
            this.cbAutoPopulate.NamedProperties.Put("EnumerateMethod", "");
            this.cbAutoPopulate.NamedProperties.Put("LovReference", "");
            this.cbAutoPopulate.NamedProperties.Put("ResizeableChildObject", "");
            this.cbAutoPopulate.NamedProperties.Put("SqlColumn", "");
            this.cbAutoPopulate.NamedProperties.Put("ValidateMethod", "");
            this.cbAutoPopulate.NamedProperties.Put("XDataLength", "");
            // 
            // tblInstVouUpdate
            // 
            this.tblInstVouUpdate.Controls.Add(this.tblInstVouUpdate_colsVoucherType);
            this.tblInstVouUpdate.Controls.Add(this.tblInstVouUpdate_colnVoucherNo);
            this.tblInstVouUpdate.Controls.Add(this.tblInstVouUpdate_colnAccountingYear);
            this.tblInstVouUpdate.Controls.Add(this.tblInstVouUpdate_colnAccountingPeriod);
            this.tblInstVouUpdate.Controls.Add(this.tblInstVouUpdate_colsUserid);
            resources.ApplyResources(this.tblInstVouUpdate, "tblInstVouUpdate");
            this.tblInstVouUpdate.Name = "tblInstVouUpdate";
            this.tblInstVouUpdate.NamedProperties.Put("DefaultOrderBy", "VOUCHER_TYPE, VOUCHER_NO");
            this.tblInstVouUpdate.NamedProperties.Put("DefaultWhere", "COMPANY = :i_hWndFrame.dlgInstantUpdate.i_sCompany\r\nAND VOUCHER_STATUS_DB IN (\'Co" +
                    "nfirmed\', \'Cancelled\')\r\nAND VOUCHER_UPDATED_DB=\'N\'\r\nAND VOUCHER_API.Is_Pca_Updat" +
                    "e_Blocked(COMPANY,FUNCTION_GROUP) = \'FALSE\'");
            this.tblInstVouUpdate.NamedProperties.Put("LogicalUnit", "Voucher");
            this.tblInstVouUpdate.NamedProperties.Put("PackageName", "VOUCHER_API");
            this.tblInstVouUpdate.NamedProperties.Put("ResizeableChildObject", "");
            this.tblInstVouUpdate.NamedProperties.Put("ViewName", "VOUCHER");
            this.tblInstVouUpdate.NamedProperties.Put("Warnings", "FALSE");
            this.tblInstVouUpdate.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblInstVouUpdate_WindowActions);
            this.tblInstVouUpdate.Controls.SetChildIndex(this.tblInstVouUpdate_colsUserid, 0);
            this.tblInstVouUpdate.Controls.SetChildIndex(this.tblInstVouUpdate_colnAccountingPeriod, 0);
            this.tblInstVouUpdate.Controls.SetChildIndex(this.tblInstVouUpdate_colnAccountingYear, 0);
            this.tblInstVouUpdate.Controls.SetChildIndex(this.tblInstVouUpdate_colnVoucherNo, 0);
            this.tblInstVouUpdate.Controls.SetChildIndex(this.tblInstVouUpdate_colsVoucherType, 0);
            // 
            // tblInstVouUpdate_colsVoucherType
            // 
            this.tblInstVouUpdate_colsVoucherType.MaxLength = 3;
            this.tblInstVouUpdate_colsVoucherType.Name = "tblInstVouUpdate_colsVoucherType";
            this.tblInstVouUpdate_colsVoucherType.NamedProperties.Put("EnumerateMethod", "");
            this.tblInstVouUpdate_colsVoucherType.NamedProperties.Put("FieldFlags", "291");
            this.tblInstVouUpdate_colsVoucherType.NamedProperties.Put("LovReference", "");
            this.tblInstVouUpdate_colsVoucherType.NamedProperties.Put("ResizeableChildObject", "");
            this.tblInstVouUpdate_colsVoucherType.NamedProperties.Put("SqlColumn", "VOUCHER_TYPE");
            this.tblInstVouUpdate_colsVoucherType.NamedProperties.Put("ValidateMethod", "");
            this.tblInstVouUpdate_colsVoucherType.Position = 3;
            resources.ApplyResources(this.tblInstVouUpdate_colsVoucherType, "tblInstVouUpdate_colsVoucherType");
            // 
            // tblInstVouUpdate_colnVoucherNo
            // 
            this.tblInstVouUpdate_colnVoucherNo.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblInstVouUpdate_colnVoucherNo.MaxLength = 10;
            this.tblInstVouUpdate_colnVoucherNo.Name = "tblInstVouUpdate_colnVoucherNo";
            this.tblInstVouUpdate_colnVoucherNo.NamedProperties.Put("EnumerateMethod", "");
            this.tblInstVouUpdate_colnVoucherNo.NamedProperties.Put("FieldFlags", "163");
            this.tblInstVouUpdate_colnVoucherNo.NamedProperties.Put("LovReference", "");
            this.tblInstVouUpdate_colnVoucherNo.NamedProperties.Put("ResizeableChildObject", "");
            this.tblInstVouUpdate_colnVoucherNo.NamedProperties.Put("SqlColumn", "VOUCHER_NO");
            this.tblInstVouUpdate_colnVoucherNo.NamedProperties.Put("ValidateMethod", "");
            this.tblInstVouUpdate_colnVoucherNo.Position = 4;
            resources.ApplyResources(this.tblInstVouUpdate_colnVoucherNo, "tblInstVouUpdate_colnVoucherNo");
            // 
            // tblInstVouUpdate_colnAccountingYear
            // 
            this.tblInstVouUpdate_colnAccountingYear.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblInstVouUpdate_colnAccountingYear.MaxLength = 4;
            this.tblInstVouUpdate_colnAccountingYear.Name = "tblInstVouUpdate_colnAccountingYear";
            this.tblInstVouUpdate_colnAccountingYear.NamedProperties.Put("EnumerateMethod", "");
            this.tblInstVouUpdate_colnAccountingYear.NamedProperties.Put("FieldFlags", "291");
            this.tblInstVouUpdate_colnAccountingYear.NamedProperties.Put("LovReference", "");
            this.tblInstVouUpdate_colnAccountingYear.NamedProperties.Put("ResizeableChildObject", "");
            this.tblInstVouUpdate_colnAccountingYear.NamedProperties.Put("SqlColumn", "ACCOUNTING_YEAR");
            this.tblInstVouUpdate_colnAccountingYear.NamedProperties.Put("ValidateMethod", "");
            this.tblInstVouUpdate_colnAccountingYear.Position = 5;
            resources.ApplyResources(this.tblInstVouUpdate_colnAccountingYear, "tblInstVouUpdate_colnAccountingYear");
            // 
            // tblInstVouUpdate_colnAccountingPeriod
            // 
            this.tblInstVouUpdate_colnAccountingPeriod.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblInstVouUpdate_colnAccountingPeriod.Name = "tblInstVouUpdate_colnAccountingPeriod";
            this.tblInstVouUpdate_colnAccountingPeriod.NamedProperties.Put("EnumerateMethod", "");
            this.tblInstVouUpdate_colnAccountingPeriod.NamedProperties.Put("FieldFlags", "291");
            this.tblInstVouUpdate_colnAccountingPeriod.NamedProperties.Put("LovReference", "");
            this.tblInstVouUpdate_colnAccountingPeriod.NamedProperties.Put("ResizeableChildObject", "");
            this.tblInstVouUpdate_colnAccountingPeriod.NamedProperties.Put("SqlColumn", "ACCOUNTING_PERIOD");
            this.tblInstVouUpdate_colnAccountingPeriod.NamedProperties.Put("ValidateMethod", "");
            this.tblInstVouUpdate_colnAccountingPeriod.Position = 6;
            resources.ApplyResources(this.tblInstVouUpdate_colnAccountingPeriod, "tblInstVouUpdate_colnAccountingPeriod");
            // 
            // tblInstVouUpdate_colsUserid
            // 
            this.tblInstVouUpdate_colsUserid.MaxLength = 30;
            this.tblInstVouUpdate_colsUserid.Name = "tblInstVouUpdate_colsUserid";
            this.tblInstVouUpdate_colsUserid.NamedProperties.Put("EnumerateMethod", "");
            this.tblInstVouUpdate_colsUserid.NamedProperties.Put("FieldFlags", "290");
            this.tblInstVouUpdate_colsUserid.NamedProperties.Put("LovReference", "");
            this.tblInstVouUpdate_colsUserid.NamedProperties.Put("ResizeableChildObject", "");
            this.tblInstVouUpdate_colsUserid.NamedProperties.Put("SqlColumn", "USERID");
            this.tblInstVouUpdate_colsUserid.NamedProperties.Put("ValidateMethod", "");
            this.tblInstVouUpdate_colsUserid.Position = 7;
            resources.ApplyResources(this.tblInstVouUpdate_colsUserid, "tblInstVouUpdate_colsUserid");
            // 
            // dlgInstantUpdate
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "dlgInstantUpdate";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "Voucher");
            this.NamedProperties.Put("PackageName", "VOUCHER_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("ViewName", "VOUCHER");
            this.ShowIcon = false;
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dlgInstantUpdate_WindowActions);
            this.ClientArea.ResumeLayout(false);
            this.ClientArea.PerformLayout();
            this.tblInstVouUpdate.ResumeLayout(false);
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

        public cChildTableFinBase tblInstVouUpdate;
        protected cColumn tblInstVouUpdate_colsVoucherType;
        protected cColumn tblInstVouUpdate_colnVoucherNo;
        protected cColumn tblInstVouUpdate_colnAccountingYear;
        protected cColumn tblInstVouUpdate_colnAccountingPeriod;
        protected cColumn tblInstVouUpdate_colsUserid;
		
		
	}
}
