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
	
	public partial class frmUserFin
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		protected cBackgroundText labelcmbsCompany;
		public cRecListDataField cmbsCompany;
		// Bug 81656 Begin - Changed Foundation1 Properties to Unformatted.
		protected cBackgroundText labeldfsDescription;
		public cDataField dfsDescription;
		// Bug 81656 End.
        // Bug 73298 Begin - Changed the derived base class.
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUserFin));
            this.labelcmbsCompany = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbsCompany = new Ifs.Fnd.ApplicationForms.cRecListDataField();
            this.labeldfsDescription = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsDescription = new Ifs.Fnd.ApplicationForms.cDataField();
            this.tblUserFin = new Ifs.Application.Accrul.cChildTableFinBase();
            this.tblUserFin_colsCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblUserFin_colsUserId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblUserFin_colsDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblUserFin_colsDefault = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.tblUserFin_colsIsNewUserId = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.tblUserFin_colsDefaultComp2 = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblUserFin.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.ImageList = null;
            // 
            // labelcmbsCompany
            // 
            resources.ApplyResources(this.labelcmbsCompany, "labelcmbsCompany");
            this.labelcmbsCompany.Name = "labelcmbsCompany";
            // 
            // cmbsCompany
            // 
            this.cmbsCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.cmbsCompany, "cmbsCompany");
            this.cmbsCompany.Name = "cmbsCompany";
            this.cmbsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.cmbsCompany.NamedProperties.Put("FieldFlags", "163");
            this.cmbsCompany.NamedProperties.Put("Format", "9");
            this.cmbsCompany.NamedProperties.Put("LovReference", "COMPANY_FINANCE");
            this.cmbsCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.cmbsCompany.NamedProperties.Put("ValidateMethod", "");
            this.cmbsCompany.NamedProperties.Put("XDataLength", "20");
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
            this.dfsDescription.NamedProperties.Put("ParentName", "cmbsCompany");
            this.dfsDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsDescription.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            this.dfsDescription.NamedProperties.Put("ValidateMethod", "");
            // 
            // tblUserFin
            // 
            this.tblUserFin.Controls.Add(this.tblUserFin_colsCompany);
            this.tblUserFin.Controls.Add(this.tblUserFin_colsUserId);
            this.tblUserFin.Controls.Add(this.tblUserFin_colsDescription);
            this.tblUserFin.Controls.Add(this.tblUserFin_colsDefault);
            this.tblUserFin.Controls.Add(this.tblUserFin_colsIsNewUserId);
            this.tblUserFin.Controls.Add(this.tblUserFin_colsDefaultComp2);
            resources.ApplyResources(this.tblUserFin, "tblUserFin");
            this.tblUserFin.Name = "tblUserFin";
            this.tblUserFin.NamedProperties.Put("DefaultOrderBy", "");
            this.tblUserFin.NamedProperties.Put("DefaultWhere", "COMPANY = :i_hWndFrame.frmUserFin.cmbsCompany.i_sMyValue");
            this.tblUserFin.NamedProperties.Put("LogicalUnit", "UserFinance");
            this.tblUserFin.NamedProperties.Put("PackageName", "USER_FINANCE_API");
            this.tblUserFin.NamedProperties.Put("ResizeableChildObject", "LLMM");
            this.tblUserFin.NamedProperties.Put("ViewName", "USER_FINANCE");
            this.tblUserFin.NamedProperties.Put("Warnings", "FALSE");
            this.tblUserFin.DataRecordCheckRequiredEvent += new System.EventHandler<Ifs.Fnd.ApplicationForms.FndReturnEventArgsSalBoolean>(this.tblUserFin_DataRecordCheckRequiredEvent);
            this.tblUserFin.DataRecordExecuteModifyEvent += new Ifs.Fnd.ApplicationForms.cDataSource.DataRecordExecuteModifyEventHandler(this.tblUserFin_DataRecordExecuteModifyEvent);
            this.tblUserFin.DataRecordExecuteNewEvent += new Ifs.Fnd.ApplicationForms.cDataSource.DataRecordExecuteNewEventHandler(this.tblUserFin_DataRecordExecuteNewEvent);
            this.tblUserFin.DataRecordGetDefaultsEvent += new System.EventHandler<Ifs.Fnd.ApplicationForms.FndReturnEventArgsSalBoolean>(this.tblUserFin_DataRecordGetDefaultsEvent);
            this.tblUserFin.DataRecordRemoveEvent += new Ifs.Fnd.ApplicationForms.cDataSource.DataRecordRemoveEventHandler(this.tblUserFin_DataRecordRemoveEvent);
            this.tblUserFin.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblUserFin_WindowActions);
            this.tblUserFin.Controls.SetChildIndex(this.tblUserFin_colsDefaultComp2, 0);
            this.tblUserFin.Controls.SetChildIndex(this.tblUserFin_colsIsNewUserId, 0);
            this.tblUserFin.Controls.SetChildIndex(this.tblUserFin_colsDefault, 0);
            this.tblUserFin.Controls.SetChildIndex(this.tblUserFin_colsDescription, 0);
            this.tblUserFin.Controls.SetChildIndex(this.tblUserFin_colsUserId, 0);
            this.tblUserFin.Controls.SetChildIndex(this.tblUserFin_colsCompany, 0);
            // 
            // tblUserFin_colsCompany
            // 
            resources.ApplyResources(this.tblUserFin_colsCompany, "tblUserFin_colsCompany");
            this.tblUserFin_colsCompany.MaxLength = 20;
            this.tblUserFin_colsCompany.Name = "tblUserFin_colsCompany";
            this.tblUserFin_colsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.tblUserFin_colsCompany.NamedProperties.Put("FieldFlags", "131");
            this.tblUserFin_colsCompany.NamedProperties.Put("LovReference", "");
            this.tblUserFin_colsCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.tblUserFin_colsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.tblUserFin_colsCompany.NamedProperties.Put("ValidateMethod", "");
            this.tblUserFin_colsCompany.Position = 3;
            // 
            // tblUserFin_colsUserId
            // 
            this.tblUserFin_colsUserId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblUserFin_colsUserId.MaxLength = 30;
            this.tblUserFin_colsUserId.Name = "tblUserFin_colsUserId";
            this.tblUserFin_colsUserId.NamedProperties.Put("EnumerateMethod", "");
            this.tblUserFin_colsUserId.NamedProperties.Put("FieldFlags", "163");
            this.tblUserFin_colsUserId.NamedProperties.Put("LovReference", "FND_USER");
            this.tblUserFin_colsUserId.NamedProperties.Put("ResizeableChildObject", "");
            this.tblUserFin_colsUserId.NamedProperties.Put("SqlColumn", "USERID");
            this.tblUserFin_colsUserId.NamedProperties.Put("ValidateMethod", "");
            this.tblUserFin_colsUserId.Position = 4;
            resources.ApplyResources(this.tblUserFin_colsUserId, "tblUserFin_colsUserId");
            this.tblUserFin_colsUserId.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblUserFin_colsUserId_WindowActions);
            // 
            // tblUserFin_colsDescription
            // 
            this.tblUserFin_colsDescription.MaxLength = 2000;
            this.tblUserFin_colsDescription.Name = "tblUserFin_colsDescription";
            this.tblUserFin_colsDescription.NamedProperties.Put("EnumerateMethod", "");
            this.tblUserFin_colsDescription.NamedProperties.Put("FieldFlags", "289");
            this.tblUserFin_colsDescription.NamedProperties.Put("LovReference", "");
            this.tblUserFin_colsDescription.NamedProperties.Put("ParentName", "tblUserFin.tblUserFin_colsUserId");
            this.tblUserFin_colsDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.tblUserFin_colsDescription.NamedProperties.Put("SqlColumn", "FND_USER_API.Get_Description(USERID)");
            this.tblUserFin_colsDescription.NamedProperties.Put("ValidateMethod", "");
            this.tblUserFin_colsDescription.Position = 5;
            resources.ApplyResources(this.tblUserFin_colsDescription, "tblUserFin_colsDescription");
            // 
            // tblUserFin_colsDefault
            // 
            this.tblUserFin_colsDefault.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblUserFin_colsDefault.MaxLength = 10;
            this.tblUserFin_colsDefault.Name = "tblUserFin_colsDefault";
            this.tblUserFin_colsDefault.NamedProperties.Put("EnumerateMethod", "");
            this.tblUserFin_colsDefault.NamedProperties.Put("FieldFlags", "294");
            this.tblUserFin_colsDefault.NamedProperties.Put("LovReference", "");
            this.tblUserFin_colsDefault.NamedProperties.Put("SqlColumn", "DEFAULT_COMPANY");
            this.tblUserFin_colsDefault.Position = 6;
            resources.ApplyResources(this.tblUserFin_colsDefault, "tblUserFin_colsDefault");
            this.tblUserFin_colsDefault.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblUserFin_colsDefault_WindowActions);
            // 
            // tblUserFin_colsIsNewUserId
            // 
            this.tblUserFin_colsIsNewUserId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblUserFin_colsIsNewUserId.CheckBox.CheckedValue = "Y";
            this.tblUserFin_colsIsNewUserId.CheckBox.IgnoreCase = true;
            this.tblUserFin_colsIsNewUserId.CheckBox.UncheckedValue = "N";
            resources.ApplyResources(this.tblUserFin_colsIsNewUserId, "tblUserFin_colsIsNewUserId");
            this.tblUserFin_colsIsNewUserId.MaxLength = 10;
            this.tblUserFin_colsIsNewUserId.Name = "tblUserFin_colsIsNewUserId";
            this.tblUserFin_colsIsNewUserId.NamedProperties.Put("EnumerateMethod", "");
            this.tblUserFin_colsIsNewUserId.NamedProperties.Put("FieldFlags", "260");
            this.tblUserFin_colsIsNewUserId.NamedProperties.Put("LovReference", "");
            this.tblUserFin_colsIsNewUserId.NamedProperties.Put("SqlColumn", "");
            this.tblUserFin_colsIsNewUserId.Position = 7;
            // 
            // tblUserFin_colsDefaultComp2
            // 
            resources.ApplyResources(this.tblUserFin_colsDefaultComp2, "tblUserFin_colsDefaultComp2");
            this.tblUserFin_colsDefaultComp2.MaxLength = 20;
            this.tblUserFin_colsDefaultComp2.Name = "tblUserFin_colsDefaultComp2";
            this.tblUserFin_colsDefaultComp2.NamedProperties.Put("EnumerateMethod", "");
            this.tblUserFin_colsDefaultComp2.NamedProperties.Put("FieldFlags", "262");
            this.tblUserFin_colsDefaultComp2.NamedProperties.Put("LovReference", "");
            this.tblUserFin_colsDefaultComp2.NamedProperties.Put("ResizeableChildObject", "");
            this.tblUserFin_colsDefaultComp2.NamedProperties.Put("SqlColumn", "");
            this.tblUserFin_colsDefaultComp2.NamedProperties.Put("ValidateMethod", "");
            this.tblUserFin_colsDefaultComp2.Position = 8;
            // 
            // frmUserFin
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.tblUserFin);
            this.Controls.Add(this.dfsDescription);
            this.Controls.Add(this.cmbsCompany);
            this.Controls.Add(this.labeldfsDescription);
            this.Controls.Add(this.labelcmbsCompany);
            this.MaximizeBox = true;
            this.Name = "frmUserFin";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "CompanyFinance");
            this.NamedProperties.Put("PackageName", "COMPANY_FINANCE_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "1");
            this.NamedProperties.Put("ViewName", "COMPANY_FINANCE");
            this.tblUserFin.ResumeLayout(false);
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

        public cChildTableFinBase tblUserFin;
        protected cColumn tblUserFin_colsCompany;
        protected cColumn tblUserFin_colsUserId;
        protected cColumn tblUserFin_colsDescription;
        protected cCheckBoxColumn tblUserFin_colsDefault;
        protected cCheckBoxColumn tblUserFin_colsIsNewUserId;
        protected cColumn tblUserFin_colsDefaultComp2;
	}
}
