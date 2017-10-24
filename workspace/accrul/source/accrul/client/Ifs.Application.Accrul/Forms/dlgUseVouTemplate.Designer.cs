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
	
	public partial class dlgUseVouTemplate
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls

        public cPushButton pbOK;
		public cPushButton pbCancel;
		public cPushButton pbQuery;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgUseVouTemplate));
            this.pbOK = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbCancel = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbQuery = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.tblUseVoucher = new Ifs.Application.Accrul.cChildTableFin();
            this.tblUseVoucher_colsCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblUseVoucher_colsTemplate = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblUseVoucher_colsDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblUseVoucher_coldValidFrom = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblUseVoucher_coldValidUntil = new Ifs.Fnd.ApplicationForms.cColumn();
            this.ClientArea.SuspendLayout();
            this.tblUseVoucher.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolBar
            // 
            this.ToolBar.Create = true;
            resources.ApplyResources(this.ToolBar, "ToolBar");
            // 
            // ClientArea
            // 
            this.ClientArea.Controls.Add(this.pbQuery);
            this.ClientArea.Controls.Add(this.pbCancel);
            this.ClientArea.Controls.Add(this.pbOK);
            this.ClientArea.Controls.Add(this.tblUseVoucher);
            resources.ApplyResources(this.ClientArea, "ClientArea");
            // 
            // commandManager
            // 
            this.commandManager.Components.Add(this.pbQuery);
            this.commandManager.Components.Add(this.pbCancel);
            this.commandManager.Components.Add(this.pbOK);
            // 
            // pbOK
            // 
            this.pbOK.AcceleratorKey = System.Windows.Forms.Keys.Return;
            resources.ApplyResources(this.pbOK, "pbOK");
            this.pbOK.Name = "pbOK";
            this.pbOK.NamedProperties.Put("MethodId", "18385");
            this.pbOK.NamedProperties.Put("MethodParameter", "OK");
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
            // pbQuery
            // 
            this.pbQuery.AcceleratorKey = System.Windows.Forms.Keys.Escape;
            resources.ApplyResources(this.pbQuery, "pbQuery");
            this.pbQuery.Name = "pbQuery";
            this.pbQuery.NamedProperties.Put("MethodId", "18385");
            this.pbQuery.NamedProperties.Put("MethodParameter", "Query");
            this.pbQuery.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // tblUseVoucher
            // 
            this.tblUseVoucher.Controls.Add(this.tblUseVoucher_colsCompany);
            this.tblUseVoucher.Controls.Add(this.tblUseVoucher_colsTemplate);
            this.tblUseVoucher.Controls.Add(this.tblUseVoucher_colsDescription);
            this.tblUseVoucher.Controls.Add(this.tblUseVoucher_coldValidFrom);
            this.tblUseVoucher.Controls.Add(this.tblUseVoucher_coldValidUntil);
            resources.ApplyResources(this.tblUseVoucher, "tblUseVoucher");
            this.tblUseVoucher.Name = "tblUseVoucher";
            this.tblUseVoucher.NamedProperties.Put("DefaultOrderBy", "TEMPLATE ASC");
            this.tblUseVoucher.NamedProperties.Put("DefaultWhere", "COMPANY =  :i_hWndFrame.dlgUseVouTemplate.i_sCompany");
            this.tblUseVoucher.NamedProperties.Put("LogicalUnit", "VoucherTemplate");
            this.tblUseVoucher.NamedProperties.Put("PackageName", "VOUCHER_TEMPLATE_API");
            this.tblUseVoucher.NamedProperties.Put("ResizeableChildObject", "");
            this.tblUseVoucher.NamedProperties.Put("ViewName", "VOUCHER_TEMPLATE");
            this.tblUseVoucher.NamedProperties.Put("Warnings", "FALSE");
            this.tblUseVoucher.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblUseVoucher_WindowActions);
            this.tblUseVoucher.Controls.SetChildIndex(this.tblUseVoucher_coldValidUntil, 0);
            this.tblUseVoucher.Controls.SetChildIndex(this.tblUseVoucher_coldValidFrom, 0);
            this.tblUseVoucher.Controls.SetChildIndex(this.tblUseVoucher_colsDescription, 0);
            this.tblUseVoucher.Controls.SetChildIndex(this.tblUseVoucher_colsTemplate, 0);
            this.tblUseVoucher.Controls.SetChildIndex(this.tblUseVoucher_colsCompany, 0);
            // 
            // tblUseVoucher_colsCompany
            // 
            this.tblUseVoucher_colsCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblUseVoucher_colsCompany, "tblUseVoucher_colsCompany");
            this.tblUseVoucher_colsCompany.MaxLength = 20;
            this.tblUseVoucher_colsCompany.Name = "tblUseVoucher_colsCompany";
            this.tblUseVoucher_colsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.tblUseVoucher_colsCompany.NamedProperties.Put("FieldFlags", "67");
            this.tblUseVoucher_colsCompany.NamedProperties.Put("LovReference", "COMPANY_FINANCE");
            this.tblUseVoucher_colsCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.tblUseVoucher_colsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.tblUseVoucher_colsCompany.NamedProperties.Put("ValidateMethod", "");
            this.tblUseVoucher_colsCompany.Position = 3;
            // 
            // tblUseVoucher_colsTemplate
            // 
            resources.ApplyResources(this.tblUseVoucher_colsTemplate, "tblUseVoucher_colsTemplate");
            this.tblUseVoucher_colsTemplate.MaxLength = 10;
            this.tblUseVoucher_colsTemplate.Name = "tblUseVoucher_colsTemplate";
            this.tblUseVoucher_colsTemplate.NamedProperties.Put("EnumerateMethod", "");
            this.tblUseVoucher_colsTemplate.NamedProperties.Put("FieldFlags", "163");
            this.tblUseVoucher_colsTemplate.NamedProperties.Put("LovReference", "");
            this.tblUseVoucher_colsTemplate.NamedProperties.Put("ResizeableChildObject", "");
            this.tblUseVoucher_colsTemplate.NamedProperties.Put("SqlColumn", "TEMPLATE");
            this.tblUseVoucher_colsTemplate.NamedProperties.Put("ValidateMethod", "");
            this.tblUseVoucher_colsTemplate.Position = 4;
            // 
            // tblUseVoucher_colsDescription
            // 
            resources.ApplyResources(this.tblUseVoucher_colsDescription, "tblUseVoucher_colsDescription");
            this.tblUseVoucher_colsDescription.MaxLength = 200;
            this.tblUseVoucher_colsDescription.Name = "tblUseVoucher_colsDescription";
            this.tblUseVoucher_colsDescription.NamedProperties.Put("EnumerateMethod", "");
            this.tblUseVoucher_colsDescription.NamedProperties.Put("FieldFlags", "290");
            this.tblUseVoucher_colsDescription.NamedProperties.Put("LovReference", "");
            this.tblUseVoucher_colsDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.tblUseVoucher_colsDescription.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            this.tblUseVoucher_colsDescription.NamedProperties.Put("ValidateMethod", "");
            this.tblUseVoucher_colsDescription.Position = 5;
            // 
            // tblUseVoucher_coldValidFrom
            // 
            this.tblUseVoucher_coldValidFrom.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            resources.ApplyResources(this.tblUseVoucher_coldValidFrom, "tblUseVoucher_coldValidFrom");
            this.tblUseVoucher_coldValidFrom.Format = "d";
            this.tblUseVoucher_coldValidFrom.MaxLength = 0;
            this.tblUseVoucher_coldValidFrom.Name = "tblUseVoucher_coldValidFrom";
            this.tblUseVoucher_coldValidFrom.NamedProperties.Put("EnumerateMethod", "");
            this.tblUseVoucher_coldValidFrom.NamedProperties.Put("FieldFlags", "290");
            this.tblUseVoucher_coldValidFrom.NamedProperties.Put("LovReference", "");
            this.tblUseVoucher_coldValidFrom.NamedProperties.Put("ResizeableChildObject", "");
            this.tblUseVoucher_coldValidFrom.NamedProperties.Put("SqlColumn", "VALID_FROM");
            this.tblUseVoucher_coldValidFrom.NamedProperties.Put("ValidateMethod", "");
            this.tblUseVoucher_coldValidFrom.Position = 6;
            // 
            // tblUseVoucher_coldValidUntil
            // 
            this.tblUseVoucher_coldValidUntil.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            resources.ApplyResources(this.tblUseVoucher_coldValidUntil, "tblUseVoucher_coldValidUntil");
            this.tblUseVoucher_coldValidUntil.Format = "d";
            this.tblUseVoucher_coldValidUntil.MaxLength = 0;
            this.tblUseVoucher_coldValidUntil.Name = "tblUseVoucher_coldValidUntil";
            this.tblUseVoucher_coldValidUntil.NamedProperties.Put("EnumerateMethod", "");
            this.tblUseVoucher_coldValidUntil.NamedProperties.Put("FieldFlags", "290");
            this.tblUseVoucher_coldValidUntil.NamedProperties.Put("LovReference", "");
            this.tblUseVoucher_coldValidUntil.NamedProperties.Put("ResizeableChildObject", "");
            this.tblUseVoucher_coldValidUntil.NamedProperties.Put("SqlColumn", "VALID_UNTIL");
            this.tblUseVoucher_coldValidUntil.NamedProperties.Put("ValidateMethod", "");
            this.tblUseVoucher_coldValidUntil.Position = 7;
            // 
            // dlgUseVouTemplate
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "dlgUseVouTemplate";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "VoucherTemplate");
            this.NamedProperties.Put("PackageName", "VOUCHER_TEMPLATE_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("ViewName", "VOUCHER_TEMPLATE");
            this.ShowIcon = false;
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dlgUseVouTemplate_WindowActions);
            this.ClientArea.ResumeLayout(false);
            this.tblUseVoucher.ResumeLayout(false);
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

        public cChildTableFin tblUseVoucher;
        protected cColumn tblUseVoucher_colsCompany;
        protected cColumn tblUseVoucher_colsTemplate;
        protected cColumn tblUseVoucher_colsDescription;
        protected cColumn tblUseVoucher_coldValidFrom;
        protected cColumn tblUseVoucher_coldValidUntil;
		
	}
}
