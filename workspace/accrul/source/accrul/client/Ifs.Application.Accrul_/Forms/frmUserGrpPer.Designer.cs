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
	
	public partial class frmUserGrpPer
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cDataField dfCompany;
		protected cBackgroundText labelcmbAccPer;
		public cRecListDataField cmbAccPer;
		protected cBackgroundText labeldfPeriod;
		public cDataField dfPeriod;
		protected cBackgroundText labeldfDescription;
		public cDataField dfDescription;
		protected cBackgroundText labeldfStatus;
		public cDataField dfStatus;
		protected cBackgroundText labeldfILStatus;
		public cDataField dfILStatus;
        // Bug 73298 Begin - Changed the derived base class.
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUserGrpPer));
            this.menuTblMethods_menuChange__Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuOperations_menuChange__Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuFrmMethods_menuChange__Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.dfCompany = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelcmbAccPer = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbAccPer = new Ifs.Fnd.ApplicationForms.cRecListDataField();
            this.labeldfPeriod = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfPeriod = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfDescription = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfDescription = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfStatus = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfStatus = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfILStatus = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfILStatus = new Ifs.Fnd.ApplicationForms.cDataField();
            this.menuFrmMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_Change = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuOperations = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_Change_1 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuTblMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_Change_2 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.tblUserGroups = new Ifs.Application.Accrul.cChildTableFinBase();
            this.tblUserGroups_colCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblUserGroups_colAccountingYear = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblUserGroups_colAccountingPeriod = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblUserGroups_colUserGroup = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblUserGroups_colDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblUserGroups_colPeriodStatus = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.tblUserGroups_colsPeriodStatusInt = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.menuFrmMethods.SuspendLayout();
            this.menuOperations.SuspendLayout();
            this.menuTblMethods.SuspendLayout();
            this.tblUserGroups.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuFrmMethods_menuChange__Company___);
            this.commandManager.Commands.Add(this.menuOperations_menuChange__Company___);
            this.commandManager.Commands.Add(this.menuTblMethods_menuChange__Company___);
            this.commandManager.ContextMenus.Add(this.menuFrmMethods);
            this.commandManager.ContextMenus.Add(this.menuOperations);
            this.commandManager.ContextMenus.Add(this.menuTblMethods);
            // 
            // menuTblMethods_menuChange__Company___
            // 
            resources.ApplyResources(this.menuTblMethods_menuChange__Company___, "menuTblMethods_menuChange__Company___");
            this.menuTblMethods_menuChange__Company___.Name = "menuTblMethods_menuChange__Company___";
            this.menuTblMethods_menuChange__Company___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Change_2_Execute);
            this.menuTblMethods_menuChange__Company___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Change_2_Inquire);
            // 
            // menuOperations_menuChange__Company___
            // 
            resources.ApplyResources(this.menuOperations_menuChange__Company___, "menuOperations_menuChange__Company___");
            this.menuOperations_menuChange__Company___.Name = "menuOperations_menuChange__Company___";
            this.menuOperations_menuChange__Company___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Change_1_Execute);
            this.menuOperations_menuChange__Company___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Change_1_Inquire);
            // 
            // menuFrmMethods_menuChange__Company___
            // 
            resources.ApplyResources(this.menuFrmMethods_menuChange__Company___, "menuFrmMethods_menuChange__Company___");
            this.menuFrmMethods_menuChange__Company___.Name = "menuFrmMethods_menuChange__Company___";
            this.menuFrmMethods_menuChange__Company___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Change_Execute);
            this.menuFrmMethods_menuChange__Company___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Change_Inquire);
            // 
            // dfCompany
            // 
            resources.ApplyResources(this.dfCompany, "dfCompany");
            this.dfCompany.Name = "dfCompany";
            this.dfCompany.NamedProperties.Put("EnumerateMethod", "");
            this.dfCompany.NamedProperties.Put("FieldFlags", "128");
            this.dfCompany.NamedProperties.Put("LovReference", "");
            this.dfCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            // 
            // labelcmbAccPer
            // 
            resources.ApplyResources(this.labelcmbAccPer, "labelcmbAccPer");
            this.labelcmbAccPer.Name = "labelcmbAccPer";
            // 
            // cmbAccPer
            // 
            resources.ApplyResources(this.cmbAccPer, "cmbAccPer");
            this.cmbAccPer.Name = "cmbAccPer";
            this.cmbAccPer.NamedProperties.Put("DataType", "3");
            this.cmbAccPer.NamedProperties.Put("EnumerateMethod", "");
            this.cmbAccPer.NamedProperties.Put("FieldFlags", "163");
            this.cmbAccPer.NamedProperties.Put("LovReference", "");
            this.cmbAccPer.NamedProperties.Put("SqlColumn", "ACCOUNTING_YEAR");
            // 
            // labeldfPeriod
            // 
            resources.ApplyResources(this.labeldfPeriod, "labeldfPeriod");
            this.labeldfPeriod.Name = "labeldfPeriod";
            // 
            // dfPeriod
            // 
            this.dfPeriod.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfPeriod, "dfPeriod");
            this.dfPeriod.Name = "dfPeriod";
            this.dfPeriod.NamedProperties.Put("EnumerateMethod", "");
            this.dfPeriod.NamedProperties.Put("FieldFlags", "163");
            this.dfPeriod.NamedProperties.Put("LovReference", "");
            this.dfPeriod.NamedProperties.Put("ParentName", "cmbAccPer");
            this.dfPeriod.NamedProperties.Put("SqlColumn", "ACCOUNTING_PERIOD");
            // 
            // labeldfDescription
            // 
            resources.ApplyResources(this.labeldfDescription, "labeldfDescription");
            this.labeldfDescription.Name = "labeldfDescription";
            // 
            // dfDescription
            // 
            resources.ApplyResources(this.dfDescription, "dfDescription");
            this.dfDescription.Name = "dfDescription";
            this.dfDescription.NamedProperties.Put("EnumerateMethod", "");
            this.dfDescription.NamedProperties.Put("FieldFlags", "288");
            this.dfDescription.NamedProperties.Put("LovReference", "");
            this.dfDescription.NamedProperties.Put("ParentName", "cmbAccPer");
            this.dfDescription.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            // 
            // labeldfStatus
            // 
            resources.ApplyResources(this.labeldfStatus, "labeldfStatus");
            this.labeldfStatus.Name = "labeldfStatus";
            // 
            // dfStatus
            // 
            resources.ApplyResources(this.dfStatus, "dfStatus");
            this.dfStatus.Name = "dfStatus";
            this.dfStatus.NamedProperties.Put("EnumerateMethod", "ACC_PER_STATUS_API.Enumerate");
            this.dfStatus.NamedProperties.Put("FieldFlags", "288");
            this.dfStatus.NamedProperties.Put("LovReference", "");
            this.dfStatus.NamedProperties.Put("SqlColumn", "PERIOD_STATUS");
            // 
            // labeldfILStatus
            // 
            resources.ApplyResources(this.labeldfILStatus, "labeldfILStatus");
            this.labeldfILStatus.Name = "labeldfILStatus";
            // 
            // dfILStatus
            // 
            resources.ApplyResources(this.dfILStatus, "dfILStatus");
            this.dfILStatus.Name = "dfILStatus";
            this.dfILStatus.NamedProperties.Put("EnumerateMethod", "");
            this.dfILStatus.NamedProperties.Put("FieldFlags", "288");
            this.dfILStatus.NamedProperties.Put("LovReference", "");
            this.dfILStatus.NamedProperties.Put("ResizeableChildObject", "");
            this.dfILStatus.NamedProperties.Put("SqlColumn", "PERIOD_STATUS_INT");
            this.dfILStatus.NamedProperties.Put("ValidateMethod", "");
            // 
            // menuFrmMethods
            // 
            this.menuFrmMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_Change});
            this.menuFrmMethods.Name = "menuFrmMethods";
            resources.ApplyResources(this.menuFrmMethods, "menuFrmMethods");
            // 
            // menuItem_Change
            // 
            this.menuItem_Change.Command = this.menuFrmMethods_menuChange__Company___;
            this.menuItem_Change.Name = "menuItem_Change";
            resources.ApplyResources(this.menuItem_Change, "menuItem_Change");
            this.menuItem_Change.Text = "Change &Company...";
            // 
            // menuOperations
            // 
            this.menuOperations.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_Change_1});
            this.menuOperations.Name = "menuOperations";
            resources.ApplyResources(this.menuOperations, "menuOperations");
            // 
            // menuItem_Change_1
            // 
            this.menuItem_Change_1.Command = this.menuOperations_menuChange__Company___;
            this.menuItem_Change_1.Name = "menuItem_Change_1";
            resources.ApplyResources(this.menuItem_Change_1, "menuItem_Change_1");
            this.menuItem_Change_1.Text = "Change &Company...";
            // 
            // menuTblMethods
            // 
            this.menuTblMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_Change_2});
            this.menuTblMethods.Name = "menuTblMethods";
            resources.ApplyResources(this.menuTblMethods, "menuTblMethods");
            // 
            // menuItem_Change_2
            // 
            this.menuItem_Change_2.Command = this.menuTblMethods_menuChange__Company___;
            this.menuItem_Change_2.Name = "menuItem_Change_2";
            resources.ApplyResources(this.menuItem_Change_2, "menuItem_Change_2");
            this.menuItem_Change_2.Text = "Change &Company...";
            // 
            // tblUserGroups
            // 
            this.tblUserGroups.Controls.Add(this.tblUserGroups_colCompany);
            this.tblUserGroups.Controls.Add(this.tblUserGroups_colAccountingYear);
            this.tblUserGroups.Controls.Add(this.tblUserGroups_colAccountingPeriod);
            this.tblUserGroups.Controls.Add(this.tblUserGroups_colUserGroup);
            this.tblUserGroups.Controls.Add(this.tblUserGroups_colDescription);
            this.tblUserGroups.Controls.Add(this.tblUserGroups_colPeriodStatus);
            this.tblUserGroups.Controls.Add(this.tblUserGroups_colsPeriodStatusInt);
            resources.ApplyResources(this.tblUserGroups, "tblUserGroups");
            this.tblUserGroups.Name = "tblUserGroups";
            this.tblUserGroups.NamedProperties.Put("DefaultOrderBy", "");
            this.tblUserGroups.NamedProperties.Put("DefaultWhere", "COMPANY = :global.company AND\r\nACCOUNTING_YEAR = :i_hWndFrame.frmUserGrpPer.cmbAc" +
                    "cPer.i_sMyValue AND\r\nACCOUNTING_PERIOD =:i_hWndFrame.frmUserGrpPer.dfPeriod");
            this.tblUserGroups.NamedProperties.Put("LogicalUnit", "UserGroupPeriod");
            this.tblUserGroups.NamedProperties.Put("PackageName", "USER_GROUP_PERIOD_API");
            this.tblUserGroups.NamedProperties.Put("ResizeableChildObject", "LLMM");
            this.tblUserGroups.NamedProperties.Put("ViewName", "USER_GROUP_PERIOD");
            this.tblUserGroups.NamedProperties.Put("Warnings", "FALSE");
            this.tblUserGroups.DataRecordGetDefaultsEvent += new System.EventHandler<Ifs.Fnd.ApplicationForms.FndReturnEventArgsSalBoolean>(this.tblUserGroups_DataRecordGetDefaultsEvent);
            this.tblUserGroups.Controls.SetChildIndex(this.tblUserGroups_colsPeriodStatusInt, 0);
            this.tblUserGroups.Controls.SetChildIndex(this.tblUserGroups_colPeriodStatus, 0);
            this.tblUserGroups.Controls.SetChildIndex(this.tblUserGroups_colDescription, 0);
            this.tblUserGroups.Controls.SetChildIndex(this.tblUserGroups_colUserGroup, 0);
            this.tblUserGroups.Controls.SetChildIndex(this.tblUserGroups_colAccountingPeriod, 0);
            this.tblUserGroups.Controls.SetChildIndex(this.tblUserGroups_colAccountingYear, 0);
            this.tblUserGroups.Controls.SetChildIndex(this.tblUserGroups_colCompany, 0);
            // 
            // tblUserGroups_colCompany
            // 
            this.tblUserGroups_colCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblUserGroups_colCompany, "tblUserGroups_colCompany");
            this.tblUserGroups_colCompany.MaxLength = 20;
            this.tblUserGroups_colCompany.Name = "tblUserGroups_colCompany";
            this.tblUserGroups_colCompany.NamedProperties.Put("EnumerateMethod", "");
            this.tblUserGroups_colCompany.NamedProperties.Put("FieldFlags", "131");
            this.tblUserGroups_colCompany.NamedProperties.Put("LovReference", "COMPANY_FINANCE");
            this.tblUserGroups_colCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.tblUserGroups_colCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.tblUserGroups_colCompany.NamedProperties.Put("ValidateMethod", "");
            this.tblUserGroups_colCompany.Position = 3;
            // 
            // tblUserGroups_colAccountingYear
            // 
            resources.ApplyResources(this.tblUserGroups_colAccountingYear, "tblUserGroups_colAccountingYear");
            this.tblUserGroups_colAccountingYear.MaxLength = 4;
            this.tblUserGroups_colAccountingYear.Name = "tblUserGroups_colAccountingYear";
            this.tblUserGroups_colAccountingYear.NamedProperties.Put("EnumerateMethod", "");
            this.tblUserGroups_colAccountingYear.NamedProperties.Put("FieldFlags", "131");
            this.tblUserGroups_colAccountingYear.NamedProperties.Put("LovReference", "");
            this.tblUserGroups_colAccountingYear.NamedProperties.Put("ResizeableChildObject", "");
            this.tblUserGroups_colAccountingYear.NamedProperties.Put("SqlColumn", "ACCOUNTING_YEAR");
            this.tblUserGroups_colAccountingYear.NamedProperties.Put("ValidateMethod", "");
            this.tblUserGroups_colAccountingYear.Position = 4;
            // 
            // tblUserGroups_colAccountingPeriod
            // 
            this.tblUserGroups_colAccountingPeriod.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.tblUserGroups_colAccountingPeriod, "tblUserGroups_colAccountingPeriod");
            this.tblUserGroups_colAccountingPeriod.MaxLength = 2;
            this.tblUserGroups_colAccountingPeriod.Name = "tblUserGroups_colAccountingPeriod";
            this.tblUserGroups_colAccountingPeriod.NamedProperties.Put("EnumerateMethod", "");
            this.tblUserGroups_colAccountingPeriod.NamedProperties.Put("FieldFlags", "131");
            this.tblUserGroups_colAccountingPeriod.NamedProperties.Put("LovReference", "");
            this.tblUserGroups_colAccountingPeriod.NamedProperties.Put("ResizeableChildObject", "");
            this.tblUserGroups_colAccountingPeriod.NamedProperties.Put("SqlColumn", "ACCOUNTING_PERIOD");
            this.tblUserGroups_colAccountingPeriod.NamedProperties.Put("ValidateMethod", "");
            this.tblUserGroups_colAccountingPeriod.Position = 5;
            // 
            // tblUserGroups_colUserGroup
            // 
            this.tblUserGroups_colUserGroup.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblUserGroups_colUserGroup.MaxLength = 30;
            this.tblUserGroups_colUserGroup.Name = "tblUserGroups_colUserGroup";
            this.tblUserGroups_colUserGroup.NamedProperties.Put("EnumerateMethod", "");
            this.tblUserGroups_colUserGroup.NamedProperties.Put("FieldFlags", "163");
            this.tblUserGroups_colUserGroup.NamedProperties.Put("LovReference", "USER_GROUP_FINANCE(COMPANY)");
            this.tblUserGroups_colUserGroup.NamedProperties.Put("ResizeableChildObject", "");
            this.tblUserGroups_colUserGroup.NamedProperties.Put("SqlColumn", "USER_GROUP");
            this.tblUserGroups_colUserGroup.NamedProperties.Put("ValidateMethod", "");
            this.tblUserGroups_colUserGroup.Position = 6;
            resources.ApplyResources(this.tblUserGroups_colUserGroup, "tblUserGroups_colUserGroup");
            // 
            // tblUserGroups_colDescription
            // 
            this.tblUserGroups_colDescription.MaxLength = 35;
            this.tblUserGroups_colDescription.Name = "tblUserGroups_colDescription";
            this.tblUserGroups_colDescription.NamedProperties.Put("EnumerateMethod", "");
            this.tblUserGroups_colDescription.NamedProperties.Put("FieldFlags", "288");
            this.tblUserGroups_colDescription.NamedProperties.Put("LovReference", "");
            this.tblUserGroups_colDescription.NamedProperties.Put("ParentName", "tblUserGroups.tblUserGroups_colUserGroup");
            this.tblUserGroups_colDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.tblUserGroups_colDescription.NamedProperties.Put("SqlColumn", "USER_GROUP_FINANCE_API.GET_USER_GROUP_DESCRIPTION(COMPANY,USER_GROUP)");
            this.tblUserGroups_colDescription.NamedProperties.Put("ValidateMethod", "");
            this.tblUserGroups_colDescription.Position = 7;
            resources.ApplyResources(this.tblUserGroups_colDescription, "tblUserGroups_colDescription");
            // 
            // tblUserGroups_colPeriodStatus
            // 
            this.tblUserGroups_colPeriodStatus.MaxLength = 20;
            this.tblUserGroups_colPeriodStatus.Name = "tblUserGroups_colPeriodStatus";
            this.tblUserGroups_colPeriodStatus.NamedProperties.Put("EnumerateMethod", "ACC_PER_STATUS_API.Enumerate_No_Finall_Close");
            this.tblUserGroups_colPeriodStatus.NamedProperties.Put("FieldFlags", "295");
            this.tblUserGroups_colPeriodStatus.NamedProperties.Put("LovReference", "");
            this.tblUserGroups_colPeriodStatus.NamedProperties.Put("ResizeableChildObject", "");
            this.tblUserGroups_colPeriodStatus.NamedProperties.Put("SqlColumn", "PERIOD_STATUS");
            this.tblUserGroups_colPeriodStatus.NamedProperties.Put("ValidateMethod", "");
            this.tblUserGroups_colPeriodStatus.Position = 8;
            resources.ApplyResources(this.tblUserGroups_colPeriodStatus, "tblUserGroups_colPeriodStatus");
            // 
            // tblUserGroups_colsPeriodStatusInt
            // 
            this.tblUserGroups_colsPeriodStatusInt.MaxLength = 200;
            this.tblUserGroups_colsPeriodStatusInt.Name = "tblUserGroups_colsPeriodStatusInt";
            this.tblUserGroups_colsPeriodStatusInt.NamedProperties.Put("EnumerateMethod", "ACC_PER_STATUS_API.Enumerate_No_Finall_Close");
            this.tblUserGroups_colsPeriodStatusInt.NamedProperties.Put("FieldFlags", "295");
            this.tblUserGroups_colsPeriodStatusInt.NamedProperties.Put("LovReference", "");
            this.tblUserGroups_colsPeriodStatusInt.NamedProperties.Put("ResizeableChildObject", "");
            this.tblUserGroups_colsPeriodStatusInt.NamedProperties.Put("SqlColumn", "PERIOD_STATUS_INT");
            this.tblUserGroups_colsPeriodStatusInt.NamedProperties.Put("ValidateMethod", "");
            this.tblUserGroups_colsPeriodStatusInt.Position = 9;
            resources.ApplyResources(this.tblUserGroups_colsPeriodStatusInt, "tblUserGroups_colsPeriodStatusInt");
            // 
            // frmUserGrpPer
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.tblUserGroups);
            this.Controls.Add(this.dfILStatus);
            this.Controls.Add(this.dfStatus);
            this.Controls.Add(this.dfDescription);
            this.Controls.Add(this.dfPeriod);
            this.Controls.Add(this.cmbAccPer);
            this.Controls.Add(this.dfCompany);
            this.Controls.Add(this.labeldfILStatus);
            this.Controls.Add(this.labeldfStatus);
            this.Controls.Add(this.labeldfDescription);
            this.Controls.Add(this.labeldfPeriod);
            this.Controls.Add(this.labelcmbAccPer);
            this.MaximizeBox = true;
            this.Name = "frmUserGrpPer";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "COMPANY = :global.company");
            this.NamedProperties.Put("LogicalUnit", "AccountingPeriod");
            this.NamedProperties.Put("PackageName", "ACCOUNTING_PERIOD_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "0");
            this.NamedProperties.Put("SourceFlags", "1");
            this.NamedProperties.Put("ViewName", "ACCOUNTING_PERIOD");
            this.NamedProperties.Put("Warnings", "TRUE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.frmUserGrpPer_WindowActions);
            this.menuFrmMethods.ResumeLayout(false);
            this.menuOperations.ResumeLayout(false);
            this.menuTblMethods.ResumeLayout(false);
            this.tblUserGroups.ResumeLayout(false);
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
		
		public Fnd.Windows.Forms.FndCommand menuTblMethods_menuChange__Company___;
        public Fnd.Windows.Forms.FndCommand menuOperations_menuChange__Company___;
        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menuChange__Company___;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuFrmMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuOperations;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change_1;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTblMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change_2;
        public cChildTableFinBase tblUserGroups;
        protected cColumn tblUserGroups_colCompany;
        protected cColumn tblUserGroups_colAccountingYear;
        protected cColumn tblUserGroups_colAccountingPeriod;
        protected cColumn tblUserGroups_colUserGroup;
        protected cColumn tblUserGroups_colDescription;
        protected cLookupColumn tblUserGroups_colPeriodStatus;
        protected cLookupColumn tblUserGroups_colsPeriodStatusInt;
	}
}
