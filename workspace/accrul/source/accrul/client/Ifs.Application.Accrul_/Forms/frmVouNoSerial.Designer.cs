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
	
	public partial class frmVouNoSerial
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		protected cBackgroundText labelcmbVoucherType;
		public cRecListDataField cmbVoucherType;
		protected cBackgroundText labeldfDescription;
		public cDataField dfDescription;
		public cDataField dfCompany;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVouNoSerial));
            this.menuOperations_menuUser_Group_per_Voucher_Series___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuOperations_menuTrans_lation___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuOperations_menuChange__Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTblMethods_menuUser_Group_per_Voucher_Series___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTblMethods_menuCreate_User_Groups_per_Voucher_T = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTblMethods_menuChange__Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuFrmMethods_menuTrans_lation___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuFrmMethods_menuChange__Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.labelcmbVoucherType = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbVoucherType = new Ifs.Fnd.ApplicationForms.cRecListDataField();
            this.labeldfDescription = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfDescription = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfCompany = new Ifs.Fnd.ApplicationForms.cDataField();
            this.menuFrmMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_Translation = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuSeparator1 = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.menuItem_Change = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuTblMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_User = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem_Create = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuSeparator2 = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.menuItem_Change_1 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuOperations = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_User_1 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuSeparator3 = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.menuItem_Translation_1 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuSeparator4 = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.menuItem_Change_2 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.tblSeries = new Ifs.Application.Accrul.cChildTableFinBase();
            this.tblSeries_colCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblSeries_colVoucherType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblSeries_colYear = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblSeries_colnPeriod = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblSeries_colSerieFrom = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblSeries_colSerieUntil = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblSeries_colActualNumber = new Ifs.Fnd.ApplicationForms.cColumn();
            this.menuFrmMethods.SuspendLayout();
            this.menuTblMethods.SuspendLayout();
            this.menuOperations.SuspendLayout();
            this.tblSeries.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuFrmMethods_menuTrans_lation___);
            this.commandManager.Commands.Add(this.menuFrmMethods_menuChange__Company___);
            this.commandManager.Commands.Add(this.menuTblMethods_menuUser_Group_per_Voucher_Series___);
            this.commandManager.Commands.Add(this.menuTblMethods_menuCreate_User_Groups_per_Voucher_T);
            this.commandManager.Commands.Add(this.menuTblMethods_menuChange__Company___);
            this.commandManager.Commands.Add(this.menuOperations_menuUser_Group_per_Voucher_Series___);
            this.commandManager.Commands.Add(this.menuOperations_menuTrans_lation___);
            this.commandManager.Commands.Add(this.menuOperations_menuChange__Company___);
            this.commandManager.ContextMenus.Add(this.menuFrmMethods);
            this.commandManager.ContextMenus.Add(this.menuTblMethods);
            this.commandManager.ContextMenus.Add(this.menuOperations);
            // 
            // menuOperations_menuUser_Group_per_Voucher_Series___
            // 
            resources.ApplyResources(this.menuOperations_menuUser_Group_per_Voucher_Series___, "menuOperations_menuUser_Group_per_Voucher_Series___");
            this.menuOperations_menuUser_Group_per_Voucher_Series___.Name = "menuOperations_menuUser_Group_per_Voucher_Series___";
            this.menuOperations_menuUser_Group_per_Voucher_Series___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_User_1_Execute);
            this.menuOperations_menuUser_Group_per_Voucher_Series___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_User_1_Inquire);
            // 
            // menuOperations_menuTrans_lation___
            // 
            resources.ApplyResources(this.menuOperations_menuTrans_lation___, "menuOperations_menuTrans_lation___");
            this.menuOperations_menuTrans_lation___.Name = "menuOperations_menuTrans_lation___";
            this.menuOperations_menuTrans_lation___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Translation_1_Execute);
            this.menuOperations_menuTrans_lation___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Translation_1_Inquire);
            // 
            // menuOperations_menuChange__Company___
            // 
            resources.ApplyResources(this.menuOperations_menuChange__Company___, "menuOperations_menuChange__Company___");
            this.menuOperations_menuChange__Company___.Name = "menuOperations_menuChange__Company___";
            this.menuOperations_menuChange__Company___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Change_2_Execute);
            this.menuOperations_menuChange__Company___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Change_2_Inquire);
            // 
            // menuTblMethods_menuUser_Group_per_Voucher_Series___
            // 
            resources.ApplyResources(this.menuTblMethods_menuUser_Group_per_Voucher_Series___, "menuTblMethods_menuUser_Group_per_Voucher_Series___");
            this.menuTblMethods_menuUser_Group_per_Voucher_Series___.Name = "menuTblMethods_menuUser_Group_per_Voucher_Series___";
            this.menuTblMethods_menuUser_Group_per_Voucher_Series___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_User_Execute);
            this.menuTblMethods_menuUser_Group_per_Voucher_Series___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_User_Inquire);
            // 
            // menuTblMethods_menuCreate_User_Groups_per_Voucher_T
            // 
            resources.ApplyResources(this.menuTblMethods_menuCreate_User_Groups_per_Voucher_T, "menuTblMethods_menuCreate_User_Groups_per_Voucher_T");
            this.menuTblMethods_menuCreate_User_Groups_per_Voucher_T.Name = "menuTblMethods_menuCreate_User_Groups_per_Voucher_T";
            this.menuTblMethods_menuCreate_User_Groups_per_Voucher_T.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Create_Execute);
            this.menuTblMethods_menuCreate_User_Groups_per_Voucher_T.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Create_Inquire);
            // 
            // menuTblMethods_menuChange__Company___
            // 
            resources.ApplyResources(this.menuTblMethods_menuChange__Company___, "menuTblMethods_menuChange__Company___");
            this.menuTblMethods_menuChange__Company___.Name = "menuTblMethods_menuChange__Company___";
            this.menuTblMethods_menuChange__Company___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Change_1_Execute);
            this.menuTblMethods_menuChange__Company___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Change_1_Inquire);
            // 
            // menuFrmMethods_menuTrans_lation___
            // 
            resources.ApplyResources(this.menuFrmMethods_menuTrans_lation___, "menuFrmMethods_menuTrans_lation___");
            this.menuFrmMethods_menuTrans_lation___.Name = "menuFrmMethods_menuTrans_lation___";
            this.menuFrmMethods_menuTrans_lation___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Translation_Execute);
            this.menuFrmMethods_menuTrans_lation___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Translation_Inquire);
            // 
            // menuFrmMethods_menuChange__Company___
            // 
            resources.ApplyResources(this.menuFrmMethods_menuChange__Company___, "menuFrmMethods_menuChange__Company___");
            this.menuFrmMethods_menuChange__Company___.Name = "menuFrmMethods_menuChange__Company___";
            this.menuFrmMethods_menuChange__Company___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Change_Execute);
            this.menuFrmMethods_menuChange__Company___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Change_Inquire);
            // 
            // labelcmbVoucherType
            // 
            resources.ApplyResources(this.labelcmbVoucherType, "labelcmbVoucherType");
            this.labelcmbVoucherType.Name = "labelcmbVoucherType";
            // 
            // cmbVoucherType
            // 
            this.cmbVoucherType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.cmbVoucherType, "cmbVoucherType");
            this.cmbVoucherType.Name = "cmbVoucherType";
            this.cmbVoucherType.NamedProperties.Put("EnumerateMethod", "");
            this.cmbVoucherType.NamedProperties.Put("FieldFlags", "163");
            this.cmbVoucherType.NamedProperties.Put("Format", "9");
            this.cmbVoucherType.NamedProperties.Put("LovReference", "");
            this.cmbVoucherType.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbVoucherType.NamedProperties.Put("SqlColumn", "VOUCHER_TYPE");
            this.cmbVoucherType.NamedProperties.Put("ValidateMethod", "");
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
            this.dfDescription.NamedProperties.Put("ParentName", "cmbVoucherType");
            this.dfDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.dfDescription.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            this.dfDescription.NamedProperties.Put("ValidateMethod", "");
            // 
            // dfCompany
            // 
            this.dfCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfCompany, "dfCompany");
            this.dfCompany.Name = "dfCompany";
            this.dfCompany.NamedProperties.Put("EnumerateMethod", "");
            this.dfCompany.NamedProperties.Put("FieldFlags", "64");
            this.dfCompany.NamedProperties.Put("LovReference", "");
            this.dfCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.dfCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.dfCompany.NamedProperties.Put("ValidateMethod", "");
            // 
            // menuFrmMethods
            // 
            this.menuFrmMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_Translation,
            this.menuSeparator1,
            this.menuItem_Change});
            this.menuFrmMethods.Name = "menuFrmMethods";
            resources.ApplyResources(this.menuFrmMethods, "menuFrmMethods");
            // 
            // menuItem_Translation
            // 
            this.menuItem_Translation.Command = this.menuFrmMethods_menuTrans_lation___;
            this.menuItem_Translation.Name = "menuItem_Translation";
            resources.ApplyResources(this.menuItem_Translation, "menuItem_Translation");
            this.menuItem_Translation.Text = "Trans&lation...";
            // 
            // menuSeparator1
            // 
            this.menuSeparator1.Name = "menuSeparator1";
            resources.ApplyResources(this.menuSeparator1, "menuSeparator1");
            // 
            // menuItem_Change
            // 
            this.menuItem_Change.Command = this.menuFrmMethods_menuChange__Company___;
            this.menuItem_Change.Name = "menuItem_Change";
            resources.ApplyResources(this.menuItem_Change, "menuItem_Change");
            this.menuItem_Change.Text = "Change &Company...";
            // 
            // menuTblMethods
            // 
            this.menuTblMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_User,
            this.menuItem_Create,
            this.menuSeparator2,
            this.menuItem_Change_1});
            this.menuTblMethods.Name = "menuTblMethods";
            resources.ApplyResources(this.menuTblMethods, "menuTblMethods");
            // 
            // menuItem_User
            // 
            this.menuItem_User.Command = this.menuTblMethods_menuUser_Group_per_Voucher_Series___;
            this.menuItem_User.Name = "menuItem_User";
            resources.ApplyResources(this.menuItem_User, "menuItem_User");
            this.menuItem_User.Text = "User Group per Voucher Series...";
            // 
            // menuItem_Create
            // 
            this.menuItem_Create.Command = this.menuTblMethods_menuCreate_User_Groups_per_Voucher_T;
            this.menuItem_Create.Name = "menuItem_Create";
            resources.ApplyResources(this.menuItem_Create, "menuItem_Create");
            this.menuItem_Create.Text = "Create User Groups per Voucher Type...";
            // 
            // menuSeparator2
            // 
            this.menuSeparator2.Name = "menuSeparator2";
            resources.ApplyResources(this.menuSeparator2, "menuSeparator2");
            // 
            // menuItem_Change_1
            // 
            this.menuItem_Change_1.Command = this.menuTblMethods_menuChange__Company___;
            this.menuItem_Change_1.Name = "menuItem_Change_1";
            resources.ApplyResources(this.menuItem_Change_1, "menuItem_Change_1");
            this.menuItem_Change_1.Text = "Change &Company...";
            // 
            // menuOperations
            // 
            this.menuOperations.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_User_1,
            this.menuSeparator3,
            this.menuItem_Translation_1,
            this.menuSeparator4,
            this.menuItem_Change_2});
            this.menuOperations.Name = "menuOperations";
            resources.ApplyResources(this.menuOperations, "menuOperations");
            // 
            // menuItem_User_1
            // 
            this.menuItem_User_1.Command = this.menuOperations_menuUser_Group_per_Voucher_Series___;
            this.menuItem_User_1.Name = "menuItem_User_1";
            resources.ApplyResources(this.menuItem_User_1, "menuItem_User_1");
            this.menuItem_User_1.Text = "User Group per Voucher Series...";
            // 
            // menuSeparator3
            // 
            this.menuSeparator3.Name = "menuSeparator3";
            resources.ApplyResources(this.menuSeparator3, "menuSeparator3");
            // 
            // menuItem_Translation_1
            // 
            this.menuItem_Translation_1.Command = this.menuOperations_menuTrans_lation___;
            this.menuItem_Translation_1.Name = "menuItem_Translation_1";
            resources.ApplyResources(this.menuItem_Translation_1, "menuItem_Translation_1");
            this.menuItem_Translation_1.Text = "Trans&lation...";
            // 
            // menuSeparator4
            // 
            this.menuSeparator4.Name = "menuSeparator4";
            resources.ApplyResources(this.menuSeparator4, "menuSeparator4");
            // 
            // menuItem_Change_2
            // 
            this.menuItem_Change_2.Command = this.menuOperations_menuChange__Company___;
            this.menuItem_Change_2.Name = "menuItem_Change_2";
            resources.ApplyResources(this.menuItem_Change_2, "menuItem_Change_2");
            this.menuItem_Change_2.Text = "Change &Company...";
            // 
            // tblSeries
            // 
            this.tblSeries.Controls.Add(this.tblSeries_colCompany);
            this.tblSeries.Controls.Add(this.tblSeries_colVoucherType);
            this.tblSeries.Controls.Add(this.tblSeries_colYear);
            this.tblSeries.Controls.Add(this.tblSeries_colnPeriod);
            this.tblSeries.Controls.Add(this.tblSeries_colSerieFrom);
            this.tblSeries.Controls.Add(this.tblSeries_colSerieUntil);
            this.tblSeries.Controls.Add(this.tblSeries_colActualNumber);
            resources.ApplyResources(this.tblSeries, "tblSeries");
            this.tblSeries.Name = "tblSeries";
            this.tblSeries.NamedProperties.Put("DefaultOrderBy", "");
            this.tblSeries.NamedProperties.Put("DefaultWhere", "VOUCHER_TYPE =:i_hWndFrame.frmVouNoSerial.cmbVoucherType ");
            this.tblSeries.NamedProperties.Put("LogicalUnit", "VoucherNoSerial");
            this.tblSeries.NamedProperties.Put("PackageName", "VOUCHER_NO_SERIAL_API");
            this.tblSeries.NamedProperties.Put("ResizeableChildObject", "LLMM");
            this.tblSeries.NamedProperties.Put("ViewName", "VOUCHER_NO_SERIAL");
            this.tblSeries.NamedProperties.Put("Warnings", "FALSE");
            this.tblSeries.UserMethodEvent += new Ifs.Fnd.ApplicationForms.cMethodManager.UserMethodEventHandler(this.tblSeries_UserMethodEvent);
            this.tblSeries.DataRecordGetDefaultsEvent += new System.EventHandler<Ifs.Fnd.ApplicationForms.FndReturnEventArgsSalBoolean>(this.tblSeries_DataRecordGetDefaultsEvent);
            this.tblSeries.Controls.SetChildIndex(this.tblSeries_colActualNumber, 0);
            this.tblSeries.Controls.SetChildIndex(this.tblSeries_colSerieUntil, 0);
            this.tblSeries.Controls.SetChildIndex(this.tblSeries_colSerieFrom, 0);
            this.tblSeries.Controls.SetChildIndex(this.tblSeries_colnPeriod, 0);
            this.tblSeries.Controls.SetChildIndex(this.tblSeries_colYear, 0);
            this.tblSeries.Controls.SetChildIndex(this.tblSeries_colVoucherType, 0);
            this.tblSeries.Controls.SetChildIndex(this.tblSeries_colCompany, 0);
            // 
            // tblSeries_colCompany
            // 
            this.tblSeries_colCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblSeries_colCompany, "tblSeries_colCompany");
            this.tblSeries_colCompany.MaxLength = 20;
            this.tblSeries_colCompany.Name = "tblSeries_colCompany";
            this.tblSeries_colCompany.NamedProperties.Put("EnumerateMethod", "");
            this.tblSeries_colCompany.NamedProperties.Put("FieldFlags", "65");
            this.tblSeries_colCompany.NamedProperties.Put("LovReference", "");
            this.tblSeries_colCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.tblSeries_colCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.tblSeries_colCompany.NamedProperties.Put("ValidateMethod", "");
            this.tblSeries_colCompany.Position = 3;
            // 
            // tblSeries_colVoucherType
            // 
            this.tblSeries_colVoucherType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblSeries_colVoucherType, "tblSeries_colVoucherType");
            this.tblSeries_colVoucherType.MaxLength = 3;
            this.tblSeries_colVoucherType.Name = "tblSeries_colVoucherType";
            this.tblSeries_colVoucherType.NamedProperties.Put("EnumerateMethod", "");
            this.tblSeries_colVoucherType.NamedProperties.Put("FieldFlags", "131");
            this.tblSeries_colVoucherType.NamedProperties.Put("LovReference", "");
            this.tblSeries_colVoucherType.NamedProperties.Put("SqlColumn", "VOUCHER_TYPE");
            this.tblSeries_colVoucherType.Position = 4;
            // 
            // tblSeries_colYear
            // 
            this.tblSeries_colYear.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblSeries_colYear.MaxLength = 4;
            this.tblSeries_colYear.Name = "tblSeries_colYear";
            this.tblSeries_colYear.NamedProperties.Put("EnumerateMethod", "");
            this.tblSeries_colYear.NamedProperties.Put("FieldFlags", "163");
            this.tblSeries_colYear.NamedProperties.Put("LovReference", "ACCOUNTING_YEAR(COMPANY)");
            this.tblSeries_colYear.NamedProperties.Put("ResizeableChildObject", "");
            this.tblSeries_colYear.NamedProperties.Put("SqlColumn", "ACCOUNTING_YEAR");
            this.tblSeries_colYear.NamedProperties.Put("ValidateMethod", "");
            this.tblSeries_colYear.Position = 5;
            this.tblSeries_colYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            resources.ApplyResources(this.tblSeries_colYear, "tblSeries_colYear");
            this.tblSeries_colYear.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblSeries_colYear_WindowActions);
            // 
            // tblSeries_colnPeriod
            // 
            this.tblSeries_colnPeriod.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblSeries_colnPeriod.Name = "tblSeries_colnPeriod";
            this.tblSeries_colnPeriod.NamedProperties.Put("EnumerateMethod", "");
            this.tblSeries_colnPeriod.NamedProperties.Put("FieldFlags", "162");
            this.tblSeries_colnPeriod.NamedProperties.Put("LovReference", "ACCOUNTING_PERIOD(COMPANY,ACCOUNTING_YEAR)");
            this.tblSeries_colnPeriod.NamedProperties.Put("ResizeableChildObject", "");
            this.tblSeries_colnPeriod.NamedProperties.Put("SqlColumn", "PERIOD");
            this.tblSeries_colnPeriod.NamedProperties.Put("ValidateMethod", "");
            this.tblSeries_colnPeriod.Position = 6;
            resources.ApplyResources(this.tblSeries_colnPeriod, "tblSeries_colnPeriod");
            this.tblSeries_colnPeriod.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblSeries_colnPeriod_WindowActions);
            // 
            // tblSeries_colSerieFrom
            // 
            this.tblSeries_colSerieFrom.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblSeries_colSerieFrom.MaxLength = 10;
            this.tblSeries_colSerieFrom.Name = "tblSeries_colSerieFrom";
            this.tblSeries_colSerieFrom.NamedProperties.Put("EnumerateMethod", "");
            this.tblSeries_colSerieFrom.NamedProperties.Put("FieldFlags", "291");
            this.tblSeries_colSerieFrom.NamedProperties.Put("LovReference", "");
            this.tblSeries_colSerieFrom.NamedProperties.Put("SqlColumn", "SERIE_FROM");
            this.tblSeries_colSerieFrom.NamedProperties.Put("ValidateMethod", "");
            this.tblSeries_colSerieFrom.Position = 7;
            this.tblSeries_colSerieFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblSeries_colSerieFrom, "tblSeries_colSerieFrom");
            this.tblSeries_colSerieFrom.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblSeries_colSerieFrom_WindowActions);
            // 
            // tblSeries_colSerieUntil
            // 
            this.tblSeries_colSerieUntil.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblSeries_colSerieUntil.MaxLength = 10;
            this.tblSeries_colSerieUntil.Name = "tblSeries_colSerieUntil";
            this.tblSeries_colSerieUntil.NamedProperties.Put("EnumerateMethod", "");
            this.tblSeries_colSerieUntil.NamedProperties.Put("FieldFlags", "295");
            this.tblSeries_colSerieUntil.NamedProperties.Put("LovReference", "");
            this.tblSeries_colSerieUntil.NamedProperties.Put("SqlColumn", "SERIE_UNTIL");
            this.tblSeries_colSerieUntil.Position = 8;
            this.tblSeries_colSerieUntil.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblSeries_colSerieUntil, "tblSeries_colSerieUntil");
            this.tblSeries_colSerieUntil.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblSeries_colSerieUntil_WindowActions);
            // 
            // tblSeries_colActualNumber
            // 
            this.tblSeries_colActualNumber.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblSeries_colActualNumber.MaxLength = 10;
            this.tblSeries_colActualNumber.Name = "tblSeries_colActualNumber";
            this.tblSeries_colActualNumber.NamedProperties.Put("EnumerateMethod", "");
            this.tblSeries_colActualNumber.NamedProperties.Put("FieldFlags", "295");
            this.tblSeries_colActualNumber.NamedProperties.Put("LovReference", "");
            this.tblSeries_colActualNumber.NamedProperties.Put("SqlColumn", "CURRENT_NUMBER");
            this.tblSeries_colActualNumber.NamedProperties.Put("ValidateMethod", "");
            this.tblSeries_colActualNumber.Position = 9;
            this.tblSeries_colActualNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblSeries_colActualNumber, "tblSeries_colActualNumber");
            // 
            // frmVouNoSerial
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.tblSeries);
            this.Controls.Add(this.dfCompany);
            this.Controls.Add(this.dfDescription);
            this.Controls.Add(this.cmbVoucherType);
            this.Controls.Add(this.labeldfDescription);
            this.Controls.Add(this.labelcmbVoucherType);
            this.MaximizeBox = true;
            this.Name = "frmVouNoSerial";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "company = :global.company");
            this.NamedProperties.Put("LogicalUnit", "VoucherType");
            this.NamedProperties.Put("PackageName", "VOUCHER_TYPE_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "0");
            this.NamedProperties.Put("SourceFlags", "1");
            this.NamedProperties.Put("ViewName", "VOUCHER_TYPE");
            this.NamedProperties.Put("Warnings", "TRUE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.frmVouNoSerial_WindowActions);
            this.menuFrmMethods.ResumeLayout(false);
            this.menuTblMethods.ResumeLayout(false);
            this.menuOperations.ResumeLayout(false);
            this.tblSeries.ResumeLayout(false);
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
		
		public Fnd.Windows.Forms.FndCommand menuOperations_menuUser_Group_per_Voucher_Series___;
        public Fnd.Windows.Forms.FndCommand menuOperations_menuTrans_lation___;
        public Fnd.Windows.Forms.FndCommand menuOperations_menuChange__Company___;
        public Fnd.Windows.Forms.FndCommand menuTblMethods_menuUser_Group_per_Voucher_Series___;
        public Fnd.Windows.Forms.FndCommand menuTblMethods_menuCreate_User_Groups_per_Voucher_T;
        public Fnd.Windows.Forms.FndCommand menuTblMethods_menuChange__Company___;
        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menuTrans_lation___;
        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menuChange__Company___;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuFrmMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Translation;
        protected Fnd.Windows.Forms.FndToolStripSeparator menuSeparator1;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTblMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_User;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Create;
        protected Fnd.Windows.Forms.FndToolStripSeparator menuSeparator2;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change_1;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuOperations;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_User_1;
        protected Fnd.Windows.Forms.FndToolStripSeparator menuSeparator3;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Translation_1;
        protected Fnd.Windows.Forms.FndToolStripSeparator menuSeparator4;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change_2;
        public cChildTableFinBase tblSeries;
        protected cColumn tblSeries_colCompany;
        protected cColumn tblSeries_colVoucherType;
        protected cColumn tblSeries_colYear;
        protected cColumn tblSeries_colnPeriod;
        protected cColumn tblSeries_colSerieFrom;
        protected cColumn tblSeries_colSerieUntil;
        protected cColumn tblSeries_colActualNumber;
	}
}
