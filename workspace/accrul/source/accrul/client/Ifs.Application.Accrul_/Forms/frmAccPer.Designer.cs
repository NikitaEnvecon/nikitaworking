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
	
	public partial class frmAccPer
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cDataField dfsCompany;
		protected cBackgroundText labelecmbYear;
		public cRecSelExtComboBoxFin ecmbYear;
		protected cBackgroundText labeldfOpeningBalances;
		public cDataField dfOpeningBalances;
		protected cBackgroundText labeldfClosingBalances;
		public cDataField dfClosingBalances;
		protected cBackgroundText labeldfStatus;
		public cDataField dfStatus;
		// Hidden fields
		public cDataField dfStatusDb;
		public cDataField dfOpeningBalancesDb;
		public cDataField dfClosingBalancesDb;
        public cCheckBox cbOpenBalConsol;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAccPer));
            this.menuOperations_menuChange__Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuOperations_menuOpen_up_Closed_Accounting_Year = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuFrmMethods_menuChange__Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuFrmMethods_menuOpen_up_Closed_Accounting_Year = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTblMethods_menuUser_Groups_per_Period___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTblMethods_menuCreate_Periods_for_User_Groups__ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTblMethods_menuValidate_Transactions_in_Progres = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTblMethods_menuClose_GL_Period = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTblMethods_menuOpen_GL_Period = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTblMethods_menuClose_GL_Period_Finally___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTblMethods_menuChange__Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.dfsCompany = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelecmbYear = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.ecmbYear = new Ifs.Application.Accrul.cRecSelExtComboBoxFin();
            this.labeldfOpeningBalances = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfOpeningBalances = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfClosingBalances = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfClosingBalances = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfStatus = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfStatus = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfStatusDb = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfOpeningBalancesDb = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfClosingBalancesDb = new Ifs.Fnd.ApplicationForms.cDataField();
            this.cbOpenBalConsol = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.menuTblMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_User = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem_Create = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuSeparator1 = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.menuItem_Validate = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem_Close = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem_Open = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem_Close_1 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuSeparator2 = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.menuItem_Change = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuFrmMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_Change_1 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem_Open_1 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuOperations = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_Change_2 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem_Open_2 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.tblAccPerDetail = new Ifs.Application.Accrul.cChildTableFin();
            this.tblAccPerDetail_colAccountingYear = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblAccPerDetail_colAccountingPeriod = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblAccPerDetail_colsDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblAccPerDetail_coldDateFrom = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblAccPerDetail_coldDateUntil = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblAccPerDetail_colsYearEndPeriodDb = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblAccPerDetail_colsPeriodType = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.tblAccPerDetail_colPeriodStatus = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblAccPerDetail_colsPeriodStatusInt = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.tblAccPerDetail_colsConsolidated = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.tblAccPerDetail_colCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblAccPerDetail_coldReportFromDate = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblAccPerDetail_coldReportUntilDate = new Ifs.Fnd.ApplicationForms.cColumn();
            this.menuTblMethods.SuspendLayout();
            this.menuFrmMethods.SuspendLayout();
            this.menuOperations.SuspendLayout();
            this.tblAccPerDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuTblMethods_menuUser_Groups_per_Period___);
            this.commandManager.Commands.Add(this.menuTblMethods_menuCreate_Periods_for_User_Groups__);
            this.commandManager.Commands.Add(this.menuTblMethods_menuValidate_Transactions_in_Progres);
            this.commandManager.Commands.Add(this.menuTblMethods_menuClose_GL_Period);
            this.commandManager.Commands.Add(this.menuTblMethods_menuOpen_GL_Period);
            this.commandManager.Commands.Add(this.menuTblMethods_menuClose_GL_Period_Finally___);
            this.commandManager.Commands.Add(this.menuTblMethods_menuChange__Company___);
            this.commandManager.Commands.Add(this.menuFrmMethods_menuChange__Company___);
            this.commandManager.Commands.Add(this.menuFrmMethods_menuOpen_up_Closed_Accounting_Year);
            this.commandManager.Commands.Add(this.menuOperations_menuChange__Company___);
            this.commandManager.Commands.Add(this.menuOperations_menuOpen_up_Closed_Accounting_Year);
            this.commandManager.ContextMenus.Add(this.menuTblMethods);
            this.commandManager.ContextMenus.Add(this.menuFrmMethods);
            this.commandManager.ContextMenus.Add(this.menuOperations);
            // 
            // menuOperations_menuChange__Company___
            // 
            resources.ApplyResources(this.menuOperations_menuChange__Company___, "menuOperations_menuChange__Company___");
            this.menuOperations_menuChange__Company___.Name = "menuOperations_menuChange__Company___";
            this.menuOperations_menuChange__Company___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Change_2_Execute);
            this.menuOperations_menuChange__Company___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Change_2_Inquire);
            // 
            // menuOperations_menuOpen_up_Closed_Accounting_Year
            // 
            resources.ApplyResources(this.menuOperations_menuOpen_up_Closed_Accounting_Year, "menuOperations_menuOpen_up_Closed_Accounting_Year");
            this.menuOperations_menuOpen_up_Closed_Accounting_Year.Name = "menuOperations_menuOpen_up_Closed_Accounting_Year";
            this.menuOperations_menuOpen_up_Closed_Accounting_Year.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Open_2_Execute);
            this.menuOperations_menuOpen_up_Closed_Accounting_Year.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Open_2_Inquire);
            // 
            // menuFrmMethods_menuChange__Company___
            // 
            resources.ApplyResources(this.menuFrmMethods_menuChange__Company___, "menuFrmMethods_menuChange__Company___");
            this.menuFrmMethods_menuChange__Company___.Name = "menuFrmMethods_menuChange__Company___";
            this.menuFrmMethods_menuChange__Company___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Change_1_Execute);
            this.menuFrmMethods_menuChange__Company___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Change_1_Inquire);
            // 
            // menuFrmMethods_menuOpen_up_Closed_Accounting_Year
            // 
            resources.ApplyResources(this.menuFrmMethods_menuOpen_up_Closed_Accounting_Year, "menuFrmMethods_menuOpen_up_Closed_Accounting_Year");
            this.menuFrmMethods_menuOpen_up_Closed_Accounting_Year.Name = "menuFrmMethods_menuOpen_up_Closed_Accounting_Year";
            this.menuFrmMethods_menuOpen_up_Closed_Accounting_Year.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Open_1_Execute);
            this.menuFrmMethods_menuOpen_up_Closed_Accounting_Year.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Open_1_Inquire);
            // 
            // menuTblMethods_menuUser_Groups_per_Period___
            // 
            resources.ApplyResources(this.menuTblMethods_menuUser_Groups_per_Period___, "menuTblMethods_menuUser_Groups_per_Period___");
            this.menuTblMethods_menuUser_Groups_per_Period___.Name = "menuTblMethods_menuUser_Groups_per_Period___";
            this.menuTblMethods_menuUser_Groups_per_Period___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_User_Execute);
            this.menuTblMethods_menuUser_Groups_per_Period___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_User_Inquire);
            // 
            // menuTblMethods_menuCreate_Periods_for_User_Groups__
            // 
            resources.ApplyResources(this.menuTblMethods_menuCreate_Periods_for_User_Groups__, "menuTblMethods_menuCreate_Periods_for_User_Groups__");
            this.menuTblMethods_menuCreate_Periods_for_User_Groups__.Name = "menuTblMethods_menuCreate_Periods_for_User_Groups__";
            this.menuTblMethods_menuCreate_Periods_for_User_Groups__.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Create_Execute);
            this.menuTblMethods_menuCreate_Periods_for_User_Groups__.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Create_Inquire);
            // 
            // menuTblMethods_menuValidate_Transactions_in_Progres
            // 
            resources.ApplyResources(this.menuTblMethods_menuValidate_Transactions_in_Progres, "menuTblMethods_menuValidate_Transactions_in_Progres");
            this.menuTblMethods_menuValidate_Transactions_in_Progres.Name = "menuTblMethods_menuValidate_Transactions_in_Progres";
            this.menuTblMethods_menuValidate_Transactions_in_Progres.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Validate_Execute);
            this.menuTblMethods_menuValidate_Transactions_in_Progres.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Validate_Inquire);
            // 
            // menuTblMethods_menuClose_GL_Period
            // 
            resources.ApplyResources(this.menuTblMethods_menuClose_GL_Period, "menuTblMethods_menuClose_GL_Period");
            this.menuTblMethods_menuClose_GL_Period.Name = "menuTblMethods_menuClose_GL_Period";
            this.menuTblMethods_menuClose_GL_Period.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Close_Execute);
            this.menuTblMethods_menuClose_GL_Period.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Close_Inquire);
            // 
            // menuTblMethods_menuOpen_GL_Period
            // 
            resources.ApplyResources(this.menuTblMethods_menuOpen_GL_Period, "menuTblMethods_menuOpen_GL_Period");
            this.menuTblMethods_menuOpen_GL_Period.Name = "menuTblMethods_menuOpen_GL_Period";
            this.menuTblMethods_menuOpen_GL_Period.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Open_Execute);
            this.menuTblMethods_menuOpen_GL_Period.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Open_Inquire);
            // 
            // menuTblMethods_menuClose_GL_Period_Finally___
            // 
            resources.ApplyResources(this.menuTblMethods_menuClose_GL_Period_Finally___, "menuTblMethods_menuClose_GL_Period_Finally___");
            this.menuTblMethods_menuClose_GL_Period_Finally___.Name = "menuTblMethods_menuClose_GL_Period_Finally___";
            this.menuTblMethods_menuClose_GL_Period_Finally___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Close_1_Execute);
            this.menuTblMethods_menuClose_GL_Period_Finally___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Close_1_Inquire);
            // 
            // menuTblMethods_menuChange__Company___
            // 
            resources.ApplyResources(this.menuTblMethods_menuChange__Company___, "menuTblMethods_menuChange__Company___");
            this.menuTblMethods_menuChange__Company___.Name = "menuTblMethods_menuChange__Company___";
            this.menuTblMethods_menuChange__Company___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Change_Execute);
            this.menuTblMethods_menuChange__Company___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Change_Inquire);
            // 
            // dfsCompany
            // 
            this.dfsCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsCompany, "dfsCompany");
            this.dfsCompany.Name = "dfsCompany";
            this.dfsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.dfsCompany.NamedProperties.Put("FieldFlags", "67");
            this.dfsCompany.NamedProperties.Put("LovReference", "COMPANY_FINANCE");
            this.dfsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            // 
            // labelecmbYear
            // 
            resources.ApplyResources(this.labelecmbYear, "labelecmbYear");
            this.labelecmbYear.Name = "labelecmbYear";
            // 
            // ecmbYear
            // 
            resources.ApplyResources(this.ecmbYear, "ecmbYear");
            this.ecmbYear.Name = "ecmbYear";
            this.ecmbYear.NamedProperties.Put("DataType", "3");
            this.ecmbYear.NamedProperties.Put("EnumerateMethod", "");
            this.ecmbYear.NamedProperties.Put("FieldFlags", "163");
            this.ecmbYear.NamedProperties.Put("LovReference", "");
            this.ecmbYear.NamedProperties.Put("ResizeableChildObject", "");
            this.ecmbYear.NamedProperties.Put("SqlColumn", "ACCOUNTING_YEAR");
            this.ecmbYear.NamedProperties.Put("ValidateMethod", "");
            this.ecmbYear.NamedProperties.Put("XDataLength", "");
            // 
            // labeldfOpeningBalances
            // 
            resources.ApplyResources(this.labeldfOpeningBalances, "labeldfOpeningBalances");
            this.labeldfOpeningBalances.Name = "labeldfOpeningBalances";
            // 
            // dfOpeningBalances
            // 
            this.dfOpeningBalances.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.dfOpeningBalances, "dfOpeningBalances");
            this.dfOpeningBalances.Name = "dfOpeningBalances";
            this.dfOpeningBalances.NamedProperties.Put("EnumerateMethod", "ACC_YEAR_OP_BAL_API.Enumerate");
            this.dfOpeningBalances.NamedProperties.Put("FieldFlags", "288");
            this.dfOpeningBalances.NamedProperties.Put("LovReference", "");
            this.dfOpeningBalances.NamedProperties.Put("ResizeableChildObject", "");
            this.dfOpeningBalances.NamedProperties.Put("SqlColumn", "OPENING_BALANCES");
            this.dfOpeningBalances.NamedProperties.Put("ValidateMethod", "");
            this.dfOpeningBalances.ReadOnly = true;
            // 
            // labeldfClosingBalances
            // 
            resources.ApplyResources(this.labeldfClosingBalances, "labeldfClosingBalances");
            this.labeldfClosingBalances.Name = "labeldfClosingBalances";
            // 
            // dfClosingBalances
            // 
            this.dfClosingBalances.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.dfClosingBalances, "dfClosingBalances");
            this.dfClosingBalances.Name = "dfClosingBalances";
            this.dfClosingBalances.NamedProperties.Put("EnumerateMethod", "ACC_YEAR_CL_BAL_API.Enumerate");
            this.dfClosingBalances.NamedProperties.Put("FieldFlags", "288");
            this.dfClosingBalances.NamedProperties.Put("LovReference", "");
            this.dfClosingBalances.NamedProperties.Put("ResizeableChildObject", "");
            this.dfClosingBalances.NamedProperties.Put("SqlColumn", "CLOSING_BALANCES");
            this.dfClosingBalances.NamedProperties.Put("ValidateMethod", "");
            this.dfClosingBalances.ReadOnly = true;
            // 
            // labeldfStatus
            // 
            resources.ApplyResources(this.labeldfStatus, "labeldfStatus");
            this.labeldfStatus.Name = "labeldfStatus";
            // 
            // dfStatus
            // 
            this.dfStatus.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.dfStatus, "dfStatus");
            this.dfStatus.Name = "dfStatus";
            this.dfStatus.NamedProperties.Put("EnumerateMethod", "ACC_YEAR_STATUS_API.Enumerate");
            this.dfStatus.NamedProperties.Put("FieldFlags", "288");
            this.dfStatus.NamedProperties.Put("LovReference", "");
            this.dfStatus.NamedProperties.Put("ResizeableChildObject", "");
            this.dfStatus.NamedProperties.Put("SqlColumn", "YEAR_STATUS");
            this.dfStatus.NamedProperties.Put("ValidateMethod", "");
            this.dfStatus.ReadOnly = true;
            // 
            // dfStatusDb
            // 
            resources.ApplyResources(this.dfStatusDb, "dfStatusDb");
            this.dfStatusDb.Name = "dfStatusDb";
            this.dfStatusDb.NamedProperties.Put("EnumerateMethod", "");
            this.dfStatusDb.NamedProperties.Put("LovReference", "");
            this.dfStatusDb.NamedProperties.Put("ResizeableChildObject", "");
            this.dfStatusDb.NamedProperties.Put("SqlColumn", "YEAR_STATUS_DB");
            this.dfStatusDb.NamedProperties.Put("ValidateMethod", "");
            // 
            // dfOpeningBalancesDb
            // 
            resources.ApplyResources(this.dfOpeningBalancesDb, "dfOpeningBalancesDb");
            this.dfOpeningBalancesDb.Name = "dfOpeningBalancesDb";
            this.dfOpeningBalancesDb.NamedProperties.Put("EnumerateMethod", "");
            this.dfOpeningBalancesDb.NamedProperties.Put("LovReference", "");
            this.dfOpeningBalancesDb.NamedProperties.Put("ResizeableChildObject", "");
            this.dfOpeningBalancesDb.NamedProperties.Put("SqlColumn", "OPENING_BALANCES_DB");
            this.dfOpeningBalancesDb.NamedProperties.Put("ValidateMethod", "");
            // 
            // dfClosingBalancesDb
            // 
            resources.ApplyResources(this.dfClosingBalancesDb, "dfClosingBalancesDb");
            this.dfClosingBalancesDb.Name = "dfClosingBalancesDb";
            this.dfClosingBalancesDb.NamedProperties.Put("EnumerateMethod", "");
            this.dfClosingBalancesDb.NamedProperties.Put("LovReference", "");
            this.dfClosingBalancesDb.NamedProperties.Put("ResizeableChildObject", "");
            this.dfClosingBalancesDb.NamedProperties.Put("SqlColumn", "CLOSING_BALANCES_DB");
            this.dfClosingBalancesDb.NamedProperties.Put("ValidateMethod", "");
            // 
            // cbOpenBalConsol
            // 
            resources.ApplyResources(this.cbOpenBalConsol, "cbOpenBalConsol");
            this.cbOpenBalConsol.Name = "cbOpenBalConsol";
            this.cbOpenBalConsol.NamedProperties.Put("DataType", "5");
            this.cbOpenBalConsol.NamedProperties.Put("EnumerateMethod", "");
            this.cbOpenBalConsol.NamedProperties.Put("LovReference", "");
            this.cbOpenBalConsol.NamedProperties.Put("ResizeableChildObject", "");
            this.cbOpenBalConsol.NamedProperties.Put("SqlColumn", "OPEN_BAL_CONSOLIDATED_DB");
            this.cbOpenBalConsol.NamedProperties.Put("ValidateMethod", "");
            this.cbOpenBalConsol.NamedProperties.Put("XDataLength", "Class Default");
            this.cbOpenBalConsol.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cbOpenBalConsol_WindowActions);
            // 
            // menuTblMethods
            // 
            this.menuTblMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_User,
            this.menuItem_Create,
            this.menuSeparator1,
            this.menuItem_Validate,
            this.menuItem_Close,
            this.menuItem_Open,
            this.menuItem_Close_1,
            this.menuSeparator2,
            this.menuItem_Change});
            this.menuTblMethods.Name = "menuTblMethods";
            resources.ApplyResources(this.menuTblMethods, "menuTblMethods");
            // 
            // menuItem_User
            // 
            this.menuItem_User.Command = this.menuTblMethods_menuUser_Groups_per_Period___;
            this.menuItem_User.Name = "menuItem_User";
            resources.ApplyResources(this.menuItem_User, "menuItem_User");
            this.menuItem_User.Text = "User Groups per Period...";
            // 
            // menuItem_Create
            // 
            this.menuItem_Create.Command = this.menuTblMethods_menuCreate_Periods_for_User_Groups__;
            this.menuItem_Create.Name = "menuItem_Create";
            resources.ApplyResources(this.menuItem_Create, "menuItem_Create");
            this.menuItem_Create.Text = "Create Periods for User Groups...";
            // 
            // menuSeparator1
            // 
            this.menuSeparator1.Name = "menuSeparator1";
            resources.ApplyResources(this.menuSeparator1, "menuSeparator1");
            // 
            // menuItem_Validate
            // 
            this.menuItem_Validate.Command = this.menuTblMethods_menuValidate_Transactions_in_Progres;
            this.menuItem_Validate.Name = "menuItem_Validate";
            resources.ApplyResources(this.menuItem_Validate, "menuItem_Validate");
            this.menuItem_Validate.Text = "Validate Transactions in Progress";
            // 
            // menuItem_Close
            // 
            this.menuItem_Close.Command = this.menuTblMethods_menuClose_GL_Period;
            this.menuItem_Close.Name = "menuItem_Close";
            resources.ApplyResources(this.menuItem_Close, "menuItem_Close");
            this.menuItem_Close.Text = "Close GL Period";
            // 
            // menuItem_Open
            // 
            this.menuItem_Open.Command = this.menuTblMethods_menuOpen_GL_Period;
            this.menuItem_Open.Name = "menuItem_Open";
            resources.ApplyResources(this.menuItem_Open, "menuItem_Open");
            this.menuItem_Open.Text = "Open GL Period";
            // 
            // menuItem_Close_1
            // 
            this.menuItem_Close_1.Command = this.menuTblMethods_menuClose_GL_Period_Finally___;
            this.menuItem_Close_1.Name = "menuItem_Close_1";
            resources.ApplyResources(this.menuItem_Close_1, "menuItem_Close_1");
            this.menuItem_Close_1.Text = "Close GL Period Finally...";
            // 
            // menuSeparator2
            // 
            this.menuSeparator2.Name = "menuSeparator2";
            resources.ApplyResources(this.menuSeparator2, "menuSeparator2");
            // 
            // menuItem_Change
            // 
            this.menuItem_Change.Command = this.menuTblMethods_menuChange__Company___;
            this.menuItem_Change.Name = "menuItem_Change";
            resources.ApplyResources(this.menuItem_Change, "menuItem_Change");
            this.menuItem_Change.Text = "Change &Company...";
            // 
            // menuFrmMethods
            // 
            this.menuFrmMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_Change_1,
            this.menuItem_Open_1});
            this.menuFrmMethods.Name = "menuFrmMethods";
            resources.ApplyResources(this.menuFrmMethods, "menuFrmMethods");
            // 
            // menuItem_Change_1
            // 
            this.menuItem_Change_1.Command = this.menuFrmMethods_menuChange__Company___;
            this.menuItem_Change_1.Name = "menuItem_Change_1";
            resources.ApplyResources(this.menuItem_Change_1, "menuItem_Change_1");
            this.menuItem_Change_1.Text = "Change &Company...";
            // 
            // menuItem_Open_1
            // 
            this.menuItem_Open_1.Command = this.menuFrmMethods_menuOpen_up_Closed_Accounting_Year;
            this.menuItem_Open_1.Name = "menuItem_Open_1";
            resources.ApplyResources(this.menuItem_Open_1, "menuItem_Open_1");
            this.menuItem_Open_1.Text = "Open up Closed Accounting Year";
            // 
            // menuOperations
            // 
            this.menuOperations.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_Change_2,
            this.menuItem_Open_2});
            this.menuOperations.Name = "menuOperations";
            resources.ApplyResources(this.menuOperations, "menuOperations");
            // 
            // menuItem_Change_2
            // 
            this.menuItem_Change_2.Command = this.menuOperations_menuChange__Company___;
            this.menuItem_Change_2.Name = "menuItem_Change_2";
            resources.ApplyResources(this.menuItem_Change_2, "menuItem_Change_2");
            this.menuItem_Change_2.Text = "Change &Company...";
            // 
            // menuItem_Open_2
            // 
            this.menuItem_Open_2.Command = this.menuOperations_menuOpen_up_Closed_Accounting_Year;
            this.menuItem_Open_2.Name = "menuItem_Open_2";
            resources.ApplyResources(this.menuItem_Open_2, "menuItem_Open_2");
            this.menuItem_Open_2.Text = "Open up Closed Accounting Year";
            // 
            // tblAccPerDetail
            // 
            this.tblAccPerDetail.Controls.Add(this.tblAccPerDetail_colAccountingYear);
            this.tblAccPerDetail.Controls.Add(this.tblAccPerDetail_colAccountingPeriod);
            this.tblAccPerDetail.Controls.Add(this.tblAccPerDetail_colsDescription);
            this.tblAccPerDetail.Controls.Add(this.tblAccPerDetail_coldDateFrom);
            this.tblAccPerDetail.Controls.Add(this.tblAccPerDetail_coldDateUntil);
            this.tblAccPerDetail.Controls.Add(this.tblAccPerDetail_colsYearEndPeriodDb);
            this.tblAccPerDetail.Controls.Add(this.tblAccPerDetail_colsPeriodType);
            this.tblAccPerDetail.Controls.Add(this.tblAccPerDetail_colPeriodStatus);
            this.tblAccPerDetail.Controls.Add(this.tblAccPerDetail_colsPeriodStatusInt);
            this.tblAccPerDetail.Controls.Add(this.tblAccPerDetail_colsConsolidated);
            this.tblAccPerDetail.Controls.Add(this.tblAccPerDetail_colCompany);
            this.tblAccPerDetail.Controls.Add(this.tblAccPerDetail_coldReportFromDate);
            this.tblAccPerDetail.Controls.Add(this.tblAccPerDetail_coldReportUntilDate);
            resources.ApplyResources(this.tblAccPerDetail, "tblAccPerDetail");
            this.tblAccPerDetail.Name = "tblAccPerDetail";
            this.tblAccPerDetail.NamedProperties.Put("DefaultOrderBy", "ACCOUNTING_PERIOD");
            this.tblAccPerDetail.NamedProperties.Put("DefaultWhere", "COMPANY = :global.company AND\r\nACCOUNTING_YEAR = :i_hWndFrame.frmAccPer.ecmbYear." +
        "i_sMyValue");
            this.tblAccPerDetail.NamedProperties.Put("LogicalUnit", "AccountingPeriod");
            this.tblAccPerDetail.NamedProperties.Put("PackageName", "ACCOUNTING_PERIOD_API");
            this.tblAccPerDetail.NamedProperties.Put("ResizeableChildObject", "LLMM");
            this.tblAccPerDetail.NamedProperties.Put("ViewName", "ACCOUNTING_PERIOD");
            this.tblAccPerDetail.NamedProperties.Put("Warnings", "FALSE");
            this.tblAccPerDetail.DataRecordGetDefaultsEvent += new System.EventHandler<Ifs.Fnd.ApplicationForms.FndReturnEventArgsSalBoolean>(this.tblAccPerDetail_DataRecordGetDefaultsEvent);
            this.tblAccPerDetail.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblAccPerDetail_WindowActions);
            this.tblAccPerDetail.Controls.SetChildIndex(this.tblAccPerDetail_coldReportUntilDate, 0);
            this.tblAccPerDetail.Controls.SetChildIndex(this.tblAccPerDetail_coldReportFromDate, 0);
            this.tblAccPerDetail.Controls.SetChildIndex(this.tblAccPerDetail_colCompany, 0);
            this.tblAccPerDetail.Controls.SetChildIndex(this.tblAccPerDetail_colsConsolidated, 0);
            this.tblAccPerDetail.Controls.SetChildIndex(this.tblAccPerDetail_colsPeriodStatusInt, 0);
            this.tblAccPerDetail.Controls.SetChildIndex(this.tblAccPerDetail_colPeriodStatus, 0);
            this.tblAccPerDetail.Controls.SetChildIndex(this.tblAccPerDetail_colsPeriodType, 0);
            this.tblAccPerDetail.Controls.SetChildIndex(this.tblAccPerDetail_colsYearEndPeriodDb, 0);
            this.tblAccPerDetail.Controls.SetChildIndex(this.tblAccPerDetail_coldDateUntil, 0);
            this.tblAccPerDetail.Controls.SetChildIndex(this.tblAccPerDetail_coldDateFrom, 0);
            this.tblAccPerDetail.Controls.SetChildIndex(this.tblAccPerDetail_colsDescription, 0);
            this.tblAccPerDetail.Controls.SetChildIndex(this.tblAccPerDetail_colAccountingPeriod, 0);
            this.tblAccPerDetail.Controls.SetChildIndex(this.tblAccPerDetail_colAccountingYear, 0);
            // 
            // tblAccPerDetail_colAccountingYear
            // 
            this.tblAccPerDetail_colAccountingYear.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.tblAccPerDetail_colAccountingYear, "tblAccPerDetail_colAccountingYear");
            this.tblAccPerDetail_colAccountingYear.Name = "tblAccPerDetail_colAccountingYear";
            this.tblAccPerDetail_colAccountingYear.NamedProperties.Put("EnumerateMethod", "");
            this.tblAccPerDetail_colAccountingYear.NamedProperties.Put("FieldFlags", "131");
            this.tblAccPerDetail_colAccountingYear.NamedProperties.Put("LovReference", "");
            this.tblAccPerDetail_colAccountingYear.NamedProperties.Put("ResizeableChildObject", "");
            this.tblAccPerDetail_colAccountingYear.NamedProperties.Put("SqlColumn", "ACCOUNTING_YEAR");
            this.tblAccPerDetail_colAccountingYear.NamedProperties.Put("ValidateMethod", "");
            this.tblAccPerDetail_colAccountingYear.Position = 3;
            // 
            // tblAccPerDetail_colAccountingPeriod
            // 
            this.tblAccPerDetail_colAccountingPeriod.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblAccPerDetail_colAccountingPeriod.MaxLength = 2;
            this.tblAccPerDetail_colAccountingPeriod.Name = "tblAccPerDetail_colAccountingPeriod";
            this.tblAccPerDetail_colAccountingPeriod.NamedProperties.Put("EnumerateMethod", "");
            this.tblAccPerDetail_colAccountingPeriod.NamedProperties.Put("FieldFlags", "163");
            this.tblAccPerDetail_colAccountingPeriod.NamedProperties.Put("LovReference", "");
            this.tblAccPerDetail_colAccountingPeriod.NamedProperties.Put("ResizeableChildObject", "");
            this.tblAccPerDetail_colAccountingPeriod.NamedProperties.Put("SqlColumn", "ACCOUNTING_PERIOD");
            this.tblAccPerDetail_colAccountingPeriod.NamedProperties.Put("ValidateMethod", "");
            this.tblAccPerDetail_colAccountingPeriod.Position = 4;
            resources.ApplyResources(this.tblAccPerDetail_colAccountingPeriod, "tblAccPerDetail_colAccountingPeriod");
            this.tblAccPerDetail_colAccountingPeriod.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblAccPerDetail_colAccountingPeriod_WindowActions);
            // 
            // tblAccPerDetail_colsDescription
            // 
            this.tblAccPerDetail_colsDescription.MaxLength = 35;
            this.tblAccPerDetail_colsDescription.Name = "tblAccPerDetail_colsDescription";
            this.tblAccPerDetail_colsDescription.NamedProperties.Put("EnumerateMethod", "");
            this.tblAccPerDetail_colsDescription.NamedProperties.Put("FieldFlags", "295");
            this.tblAccPerDetail_colsDescription.NamedProperties.Put("LovReference", "");
            this.tblAccPerDetail_colsDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.tblAccPerDetail_colsDescription.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            this.tblAccPerDetail_colsDescription.NamedProperties.Put("ValidateMethod", "");
            this.tblAccPerDetail_colsDescription.Position = 5;
            resources.ApplyResources(this.tblAccPerDetail_colsDescription, "tblAccPerDetail_colsDescription");
            this.tblAccPerDetail_colsDescription.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblAccPerDetail_colsDescription_WindowActions);
            // 
            // tblAccPerDetail_coldDateFrom
            // 
            this.tblAccPerDetail_coldDateFrom.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.tblAccPerDetail_coldDateFrom.Format = "d";
            this.tblAccPerDetail_coldDateFrom.Name = "tblAccPerDetail_coldDateFrom";
            this.tblAccPerDetail_coldDateFrom.NamedProperties.Put("EnumerateMethod", "");
            this.tblAccPerDetail_coldDateFrom.NamedProperties.Put("FieldFlags", "295");
            this.tblAccPerDetail_coldDateFrom.NamedProperties.Put("LovReference", "");
            this.tblAccPerDetail_coldDateFrom.NamedProperties.Put("ResizeableChildObject", "");
            this.tblAccPerDetail_coldDateFrom.NamedProperties.Put("SqlColumn", "DATE_FROM");
            this.tblAccPerDetail_coldDateFrom.NamedProperties.Put("ValidateMethod", "");
            this.tblAccPerDetail_coldDateFrom.Position = 6;
            resources.ApplyResources(this.tblAccPerDetail_coldDateFrom, "tblAccPerDetail_coldDateFrom");
            this.tblAccPerDetail_coldDateFrom.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblAccPerDetail_coldDateFrom_WindowActions);
            // 
            // tblAccPerDetail_coldDateUntil
            // 
            this.tblAccPerDetail_coldDateUntil.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.tblAccPerDetail_coldDateUntil.Format = "d";
            this.tblAccPerDetail_coldDateUntil.Name = "tblAccPerDetail_coldDateUntil";
            this.tblAccPerDetail_coldDateUntil.NamedProperties.Put("EnumerateMethod", "");
            this.tblAccPerDetail_coldDateUntil.NamedProperties.Put("FieldFlags", "295");
            this.tblAccPerDetail_coldDateUntil.NamedProperties.Put("LovReference", "");
            this.tblAccPerDetail_coldDateUntil.NamedProperties.Put("ResizeableChildObject", "");
            this.tblAccPerDetail_coldDateUntil.NamedProperties.Put("SqlColumn", "DATE_UNTIL");
            this.tblAccPerDetail_coldDateUntil.NamedProperties.Put("ValidateMethod", "");
            this.tblAccPerDetail_coldDateUntil.Position = 7;
            resources.ApplyResources(this.tblAccPerDetail_coldDateUntil, "tblAccPerDetail_coldDateUntil");
            this.tblAccPerDetail_coldDateUntil.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblAccPerDetail_coldDateUntil_WindowActions);
            // 
            // tblAccPerDetail_colsYearEndPeriodDb
            // 
            resources.ApplyResources(this.tblAccPerDetail_colsYearEndPeriodDb, "tblAccPerDetail_colsYearEndPeriodDb");
            this.tblAccPerDetail_colsYearEndPeriodDb.MaxLength = 20;
            this.tblAccPerDetail_colsYearEndPeriodDb.Name = "tblAccPerDetail_colsYearEndPeriodDb";
            this.tblAccPerDetail_colsYearEndPeriodDb.NamedProperties.Put("EnumerateMethod", "");
            this.tblAccPerDetail_colsYearEndPeriodDb.NamedProperties.Put("FieldFlags", "288");
            this.tblAccPerDetail_colsYearEndPeriodDb.NamedProperties.Put("LovReference", "");
            this.tblAccPerDetail_colsYearEndPeriodDb.NamedProperties.Put("SqlColumn", "YEAR_END_PERIOD_DB");
            this.tblAccPerDetail_colsYearEndPeriodDb.Position = 8;
            // 
            // tblAccPerDetail_colsPeriodType
            // 
            this.tblAccPerDetail_colsPeriodType.Name = "tblAccPerDetail_colsPeriodType";
            this.tblAccPerDetail_colsPeriodType.NamedProperties.Put("EnumerateMethod", "PERIOD_TYPE_API.Enumerate");
            this.tblAccPerDetail_colsPeriodType.NamedProperties.Put("FieldFlags", "294");
            this.tblAccPerDetail_colsPeriodType.NamedProperties.Put("LovReference", "");
            this.tblAccPerDetail_colsPeriodType.NamedProperties.Put("ResizeableChildObject", "");
            this.tblAccPerDetail_colsPeriodType.NamedProperties.Put("SqlColumn", "YEAR_END_PERIOD");
            this.tblAccPerDetail_colsPeriodType.NamedProperties.Put("ValidateMethod", "");
            this.tblAccPerDetail_colsPeriodType.Position = 9;
            resources.ApplyResources(this.tblAccPerDetail_colsPeriodType, "tblAccPerDetail_colsPeriodType");
            this.tblAccPerDetail_colsPeriodType.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblAccPerDetail_colsPeriodType_WindowActions);
            // 
            // tblAccPerDetail_colPeriodStatus
            // 
            this.tblAccPerDetail_colPeriodStatus.Name = "tblAccPerDetail_colPeriodStatus";
            this.tblAccPerDetail_colPeriodStatus.NamedProperties.Put("EnumerateMethod", "ACC_PER_STATUS_API.Enumerate");
            this.tblAccPerDetail_colPeriodStatus.NamedProperties.Put("FieldFlags", "288");
            this.tblAccPerDetail_colPeriodStatus.NamedProperties.Put("LovReference", "");
            this.tblAccPerDetail_colPeriodStatus.NamedProperties.Put("ResizeableChildObject", "");
            this.tblAccPerDetail_colPeriodStatus.NamedProperties.Put("SqlColumn", "PERIOD_STATUS");
            this.tblAccPerDetail_colPeriodStatus.NamedProperties.Put("ValidateMethod", "");
            this.tblAccPerDetail_colPeriodStatus.Position = 10;
            resources.ApplyResources(this.tblAccPerDetail_colPeriodStatus, "tblAccPerDetail_colPeriodStatus");
            // 
            // tblAccPerDetail_colsPeriodStatusInt
            // 
            this.tblAccPerDetail_colsPeriodStatusInt.MaxLength = 200;
            this.tblAccPerDetail_colsPeriodStatusInt.Name = "tblAccPerDetail_colsPeriodStatusInt";
            this.tblAccPerDetail_colsPeriodStatusInt.NamedProperties.Put("EnumerateMethod", "ACC_PER_STATUS_API.Enumerate_No_Finall_Close");
            this.tblAccPerDetail_colsPeriodStatusInt.NamedProperties.Put("FieldFlags", "295");
            this.tblAccPerDetail_colsPeriodStatusInt.NamedProperties.Put("LovReference", "");
            this.tblAccPerDetail_colsPeriodStatusInt.NamedProperties.Put("ResizeableChildObject", "");
            this.tblAccPerDetail_colsPeriodStatusInt.NamedProperties.Put("SqlColumn", "PERIOD_STATUS_INT");
            this.tblAccPerDetail_colsPeriodStatusInt.NamedProperties.Put("ValidateMethod", "");
            this.tblAccPerDetail_colsPeriodStatusInt.Position = 11;
            resources.ApplyResources(this.tblAccPerDetail_colsPeriodStatusInt, "tblAccPerDetail_colsPeriodStatusInt");
            // 
            // tblAccPerDetail_colsConsolidated
            // 
            resources.ApplyResources(this.tblAccPerDetail_colsConsolidated, "tblAccPerDetail_colsConsolidated");
            this.tblAccPerDetail_colsConsolidated.MaxLength = 200;
            this.tblAccPerDetail_colsConsolidated.Name = "tblAccPerDetail_colsConsolidated";
            this.tblAccPerDetail_colsConsolidated.NamedProperties.Put("EnumerateMethod", "CONSOLIDATED_YES_NO_API.Enumerate");
            this.tblAccPerDetail_colsConsolidated.NamedProperties.Put("FieldFlags", "295");
            this.tblAccPerDetail_colsConsolidated.NamedProperties.Put("LovReference", "");
            this.tblAccPerDetail_colsConsolidated.NamedProperties.Put("ResizeableChildObject", "");
            this.tblAccPerDetail_colsConsolidated.NamedProperties.Put("SqlColumn", "CONSOLIDATED");
            this.tblAccPerDetail_colsConsolidated.NamedProperties.Put("ValidateMethod", "");
            this.tblAccPerDetail_colsConsolidated.Position = 12;
            // 
            // tblAccPerDetail_colCompany
            // 
            resources.ApplyResources(this.tblAccPerDetail_colCompany, "tblAccPerDetail_colCompany");
            this.tblAccPerDetail_colCompany.Name = "tblAccPerDetail_colCompany";
            this.tblAccPerDetail_colCompany.NamedProperties.Put("EnumerateMethod", "");
            this.tblAccPerDetail_colCompany.NamedProperties.Put("FieldFlags", "131");
            this.tblAccPerDetail_colCompany.NamedProperties.Put("LovReference", "");
            this.tblAccPerDetail_colCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.tblAccPerDetail_colCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.tblAccPerDetail_colCompany.NamedProperties.Put("ValidateMethod", "");
            this.tblAccPerDetail_colCompany.Position = 13;
            // 
            // tblAccPerDetail_coldReportFromDate
            // 
            this.tblAccPerDetail_coldReportFromDate.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.tblAccPerDetail_coldReportFromDate.Format = "d";
            this.tblAccPerDetail_coldReportFromDate.Name = "tblAccPerDetail_coldReportFromDate";
            this.tblAccPerDetail_coldReportFromDate.NamedProperties.Put("EnumerateMethod", "");
            this.tblAccPerDetail_coldReportFromDate.NamedProperties.Put("FieldFlags", "294");
            this.tblAccPerDetail_coldReportFromDate.NamedProperties.Put("LovReference", "");
            this.tblAccPerDetail_coldReportFromDate.NamedProperties.Put("SqlColumn", "REPORT_FROM_DATE");
            this.tblAccPerDetail_coldReportFromDate.Position = 14;
            resources.ApplyResources(this.tblAccPerDetail_coldReportFromDate, "tblAccPerDetail_coldReportFromDate");
            // 
            // tblAccPerDetail_coldReportUntilDate
            // 
            this.tblAccPerDetail_coldReportUntilDate.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.tblAccPerDetail_coldReportUntilDate.Format = "d";
            this.tblAccPerDetail_coldReportUntilDate.Name = "tblAccPerDetail_coldReportUntilDate";
            this.tblAccPerDetail_coldReportUntilDate.NamedProperties.Put("EnumerateMethod", "");
            this.tblAccPerDetail_coldReportUntilDate.NamedProperties.Put("FieldFlags", "294");
            this.tblAccPerDetail_coldReportUntilDate.NamedProperties.Put("LovReference", "");
            this.tblAccPerDetail_coldReportUntilDate.NamedProperties.Put("SqlColumn", "REPORT_UNTIL_DATE");
            this.tblAccPerDetail_coldReportUntilDate.Position = 15;
            resources.ApplyResources(this.tblAccPerDetail_coldReportUntilDate, "tblAccPerDetail_coldReportUntilDate");
            // 
            // frmAccPer
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.tblAccPerDetail);
            this.Controls.Add(this.cbOpenBalConsol);
            this.Controls.Add(this.dfClosingBalancesDb);
            this.Controls.Add(this.dfOpeningBalancesDb);
            this.Controls.Add(this.dfStatusDb);
            this.Controls.Add(this.dfStatus);
            this.Controls.Add(this.dfClosingBalances);
            this.Controls.Add(this.dfOpeningBalances);
            this.Controls.Add(this.ecmbYear);
            this.Controls.Add(this.dfsCompany);
            this.Controls.Add(this.labeldfStatus);
            this.Controls.Add(this.labeldfClosingBalances);
            this.Controls.Add(this.labeldfOpeningBalances);
            this.Controls.Add(this.labelecmbYear);
            this.MaximizeBox = true;
            this.Name = "frmAccPer";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "Company = :global.company");
            this.NamedProperties.Put("LogicalUnit", "AccountingYear");
            this.NamedProperties.Put("PackageName", "ACCOUNTING_YEAR_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("ViewName", "ACC_YEAR");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.frmAccPer_WindowActions);
            this.menuTblMethods.ResumeLayout(false);
            this.menuFrmMethods.ResumeLayout(false);
            this.menuOperations.ResumeLayout(false);
            this.tblAccPerDetail.ResumeLayout(false);
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
		
		public Fnd.Windows.Forms.FndCommand menuOperations_menuChange__Company___;
        public Fnd.Windows.Forms.FndCommand menuOperations_menuOpen_up_Closed_Accounting_Year;
        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menuChange__Company___;
        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menuOpen_up_Closed_Accounting_Year;
        public Fnd.Windows.Forms.FndCommand menuTblMethods_menuUser_Groups_per_Period___;
        public Fnd.Windows.Forms.FndCommand menuTblMethods_menuCreate_Periods_for_User_Groups__;
        public Fnd.Windows.Forms.FndCommand menuTblMethods_menuValidate_Transactions_in_Progres;
        public Fnd.Windows.Forms.FndCommand menuTblMethods_menuClose_GL_Period;
        public Fnd.Windows.Forms.FndCommand menuTblMethods_menuOpen_GL_Period;
        public Fnd.Windows.Forms.FndCommand menuTblMethods_menuClose_GL_Period_Finally___;
        public Fnd.Windows.Forms.FndCommand menuTblMethods_menuChange__Company___;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTblMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_User;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Create;
        protected Fnd.Windows.Forms.FndToolStripSeparator menuSeparator1;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Validate;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Close;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Open;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Close_1;
        protected Fnd.Windows.Forms.FndToolStripSeparator menuSeparator2;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuFrmMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change_1;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Open_1;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuOperations;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change_2;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Open_2;
        public cChildTableFin tblAccPerDetail;
        protected cColumn tblAccPerDetail_colAccountingYear;
        protected cColumn tblAccPerDetail_colAccountingPeriod;
        protected cColumn tblAccPerDetail_colsDescription;
        protected cColumn tblAccPerDetail_coldDateFrom;
        protected cColumn tblAccPerDetail_coldDateUntil;
        protected cColumn tblAccPerDetail_colsYearEndPeriodDb;
        public cLookupColumn tblAccPerDetail_colsPeriodType;
        protected cColumn tblAccPerDetail_colPeriodStatus;
        protected cLookupColumn tblAccPerDetail_colsPeriodStatusInt;
        protected cLookupColumn tblAccPerDetail_colsConsolidated;
        protected cColumn tblAccPerDetail_colCompany;
        protected cColumn tblAccPerDetail_coldReportFromDate;
        protected cColumn tblAccPerDetail_coldReportUntilDate;
	}
}
