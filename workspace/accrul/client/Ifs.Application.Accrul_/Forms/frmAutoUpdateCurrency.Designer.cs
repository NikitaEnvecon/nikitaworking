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
	
	public partial class frmAutoUpdateCurrency
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		protected cBackgroundText labelcmbTaskId;
		public cRecListDataField cmbTaskId;
		protected cBackgroundText labeldfsDescription;
        public cDataField dfsDescription;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAutoUpdateCurrency));
            this.labelcmbTaskId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbTaskId = new Ifs.Fnd.ApplicationForms.cRecListDataField();
            this.labeldfsDescription = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsDescription = new Ifs.Fnd.ApplicationForms.cDataField();
            this.tblCurrencyDetail = new Ifs.Application.Accrul.cChildTableFin();
            this.tblCurrencyDetail_colsTaskId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblCurrencyDetail_colsCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblCurrencyDetail_colsCurrencyType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblCurrencyDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelcmbTaskId
            // 
            resources.ApplyResources(this.labelcmbTaskId, "labelcmbTaskId");
            this.labelcmbTaskId.Name = "labelcmbTaskId";
            // 
            // cmbTaskId
            // 
            this.cmbTaskId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.cmbTaskId, "cmbTaskId");
            this.cmbTaskId.Name = "cmbTaskId";
            this.cmbTaskId.NamedProperties.Put("EnumerateMethod", "");
            this.cmbTaskId.NamedProperties.Put("FieldFlags", "99");
            this.cmbTaskId.NamedProperties.Put("Format", "9");
            this.cmbTaskId.NamedProperties.Put("LovReference", "EXT_CURRENCY_TASK");
            this.cmbTaskId.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbTaskId.NamedProperties.Put("SqlColumn", "TASK_ID");
            this.cmbTaskId.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsDescription
            // 
            resources.ApplyResources(this.labeldfsDescription, "labeldfsDescription");
            this.labeldfsDescription.Name = "labeldfsDescription";
            // 
            // dfsDescription
            // 
            resources.ApplyResources(this.dfsDescription, "dfsDescription");
            this.dfsDescription.Name = "dfsDescription";
            this.dfsDescription.NamedProperties.Put("EnumerateMethod", "");
            this.dfsDescription.NamedProperties.Put("FieldFlags", "295");
            this.dfsDescription.NamedProperties.Put("LovReference", "");
            this.dfsDescription.NamedProperties.Put("ResizeableChildObject", "LLML");
            this.dfsDescription.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            this.dfsDescription.NamedProperties.Put("ValidateMethod", "");
            // 
            // tblCurrencyDetail
            // 
            this.tblCurrencyDetail.Controls.Add(this.tblCurrencyDetail_colsTaskId);
            this.tblCurrencyDetail.Controls.Add(this.tblCurrencyDetail_colsCompany);
            this.tblCurrencyDetail.Controls.Add(this.tblCurrencyDetail_colsCurrencyType);
            resources.ApplyResources(this.tblCurrencyDetail, "tblCurrencyDetail");
            this.tblCurrencyDetail.Name = "tblCurrencyDetail";
            this.tblCurrencyDetail.NamedProperties.Put("DefaultOrderBy", "");
            this.tblCurrencyDetail.NamedProperties.Put("DefaultWhere", "");
            this.tblCurrencyDetail.NamedProperties.Put("LogicalUnit", "ExtCurrencyTaskDetail");
            this.tblCurrencyDetail.NamedProperties.Put("PackageName", "EXT_CURRENCY_TASK_DETAIL_API");
            this.tblCurrencyDetail.NamedProperties.Put("ResizeableChildObject", "LLMM");
            this.tblCurrencyDetail.NamedProperties.Put("ViewName", "EXT_CURRENCY_TASK_DETAIL");
            this.tblCurrencyDetail.NamedProperties.Put("Warnings", "FALSE");
            this.tblCurrencyDetail.DataRecordGetDefaultsEvent += new System.EventHandler<Ifs.Fnd.ApplicationForms.FndReturnEventArgsSalBoolean>(this.tblCurrencyDetail_DataRecordGetDefaultsEvent);
            this.tblCurrencyDetail.Controls.SetChildIndex(this.tblCurrencyDetail_colsCurrencyType, 0);
            this.tblCurrencyDetail.Controls.SetChildIndex(this.tblCurrencyDetail_colsCompany, 0);
            this.tblCurrencyDetail.Controls.SetChildIndex(this.tblCurrencyDetail_colsTaskId, 0);
            // 
            // tblCurrencyDetail_colsTaskId
            // 
            this.tblCurrencyDetail_colsTaskId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblCurrencyDetail_colsTaskId, "tblCurrencyDetail_colsTaskId");
            this.tblCurrencyDetail_colsTaskId.MaxLength = 10;
            this.tblCurrencyDetail_colsTaskId.Name = "tblCurrencyDetail_colsTaskId";
            this.tblCurrencyDetail_colsTaskId.NamedProperties.Put("EnumerateMethod", "");
            this.tblCurrencyDetail_colsTaskId.NamedProperties.Put("FieldFlags", "67");
            this.tblCurrencyDetail_colsTaskId.NamedProperties.Put("LovReference", "");
            this.tblCurrencyDetail_colsTaskId.NamedProperties.Put("SqlColumn", "TASK_ID");
            this.tblCurrencyDetail_colsTaskId.Position = 3;
            // 
            // tblCurrencyDetail_colsCompany
            // 
            this.tblCurrencyDetail_colsCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblCurrencyDetail_colsCompany.MaxLength = 20;
            this.tblCurrencyDetail_colsCompany.Name = "tblCurrencyDetail_colsCompany";
            this.tblCurrencyDetail_colsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.tblCurrencyDetail_colsCompany.NamedProperties.Put("FieldFlags", "67");
            this.tblCurrencyDetail_colsCompany.NamedProperties.Put("LovReference", "COMPANY_FINANCE");
            this.tblCurrencyDetail_colsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.tblCurrencyDetail_colsCompany.Position = 4;
            resources.ApplyResources(this.tblCurrencyDetail_colsCompany, "tblCurrencyDetail_colsCompany");
            this.tblCurrencyDetail_colsCompany.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblCurrencyDetail_colsCompany_WindowActions);
            // 
            // tblCurrencyDetail_colsCurrencyType
            // 
            this.tblCurrencyDetail_colsCurrencyType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblCurrencyDetail_colsCurrencyType.MaxLength = 10;
            this.tblCurrencyDetail_colsCurrencyType.Name = "tblCurrencyDetail_colsCurrencyType";
            this.tblCurrencyDetail_colsCurrencyType.NamedProperties.Put("EnumerateMethod", "");
            this.tblCurrencyDetail_colsCurrencyType.NamedProperties.Put("FieldFlags", "163");
            this.tblCurrencyDetail_colsCurrencyType.NamedProperties.Put("LovReference", "CURRENCY_TYPE3(COMPANY)");
            this.tblCurrencyDetail_colsCurrencyType.NamedProperties.Put("SqlColumn", "CURRENCY_TYPE");
            this.tblCurrencyDetail_colsCurrencyType.Position = 5;
            resources.ApplyResources(this.tblCurrencyDetail_colsCurrencyType, "tblCurrencyDetail_colsCurrencyType");
            // 
            // frmAutoUpdateCurrency
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.tblCurrencyDetail);
            this.Controls.Add(this.dfsDescription);
            this.Controls.Add(this.cmbTaskId);
            this.Controls.Add(this.labeldfsDescription);
            this.Controls.Add(this.labelcmbTaskId);
            this.MaximizeBox = true;
            this.Name = "frmAutoUpdateCurrency";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "ExtCurrencyTask");
            this.NamedProperties.Put("PackageName", "EXT_CURRENCY_TASK_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("ViewName", "EXT_CURRENCY_TASK");
            this.NamedProperties.Put("Warnings", "TRUE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.frmAutoUpdateCurrency_WindowActions);
            this.tblCurrencyDetail.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

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

        public cChildTableFin tblCurrencyDetail;
        protected cColumn tblCurrencyDetail_colsTaskId;
        protected cColumn tblCurrencyDetail_colsCompany;
        protected cColumn tblCurrencyDetail_colsCurrencyType;
	}
}
