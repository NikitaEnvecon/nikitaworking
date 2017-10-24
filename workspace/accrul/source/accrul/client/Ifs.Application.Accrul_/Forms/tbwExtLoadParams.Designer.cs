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
	
	public partial class tbwExtLoadParams
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cColumn colCompany;
		public cColumn colLoadId;
		public cColumn colVoucherType;
		public cColumn colLoadDate;
		public cColumn colUserid;
		public cColumn colsExtLoadState;
		public cColumn colsLoadType;
		public cColumn colnLoadFileId;
		public cColumn colsExtLoadStateDb;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwExtLoadParams));
            this.menuTbwMethods_menuShow__Transactions___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_menuRemove_loads___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_menuRemove_All_Error_Codes___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_menuExternal_File_T_ransaction___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_menuCheck_External_Voucher___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_menuCreate_Voucher = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_menu_Change_Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuOperations_menuShow__Transactions = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuOperations_menu_Change_Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.colCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colLoadId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colVoucherType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colLoadDate = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colUserid = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsExtLoadState = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsLoadType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colnLoadFileId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsExtLoadStateDb = new Ifs.Fnd.ApplicationForms.cColumn();
            this.menuOperations = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_Show = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuSeparator1 = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.menuItem__Change = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuTbwMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_Show_1 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem_Remove = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem_Remove_1 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem_External = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuSeparator2 = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.menuItem_Check = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem_Create = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuSeparator3 = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.menuItem__Change_1 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuOperations.SuspendLayout();
            this.menuTbwMethods.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuOperations_menuShow__Transactions);
            this.commandManager.Commands.Add(this.menuOperations_menu_Change_Company___);
            this.commandManager.Commands.Add(this.menuTbwMethods_menuShow__Transactions___);
            this.commandManager.Commands.Add(this.menuTbwMethods_menuRemove_loads___);
            this.commandManager.Commands.Add(this.menuTbwMethods_menuRemove_All_Error_Codes___);
            this.commandManager.Commands.Add(this.menuTbwMethods_menuExternal_File_T_ransaction___);
            this.commandManager.Commands.Add(this.menuTbwMethods_menuCheck_External_Voucher___);
            this.commandManager.Commands.Add(this.menuTbwMethods_menuCreate_Voucher);
            this.commandManager.Commands.Add(this.menuTbwMethods_menu_Change_Company___);
            this.commandManager.ContextMenus.Add(this.menuOperations);
            this.commandManager.ContextMenus.Add(this.menuTbwMethods);
            // 
            // menuTbwMethods_menuShow__Transactions___
            // 
            resources.ApplyResources(this.menuTbwMethods_menuShow__Transactions___, "menuTbwMethods_menuShow__Transactions___");
            this.menuTbwMethods_menuShow__Transactions___.Name = "menuTbwMethods_menuShow__Transactions___";
            this.menuTbwMethods_menuShow__Transactions___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Show_1_Execute);
            this.menuTbwMethods_menuShow__Transactions___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Show_1_Inquire);
            // 
            // menuTbwMethods_menuRemove_loads___
            // 
            resources.ApplyResources(this.menuTbwMethods_menuRemove_loads___, "menuTbwMethods_menuRemove_loads___");
            this.menuTbwMethods_menuRemove_loads___.Name = "menuTbwMethods_menuRemove_loads___";
            this.menuTbwMethods_menuRemove_loads___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Remove_Execute);
            this.menuTbwMethods_menuRemove_loads___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Remove_Inquire);
            // 
            // menuTbwMethods_menuRemove_All_Error_Codes___
            // 
            resources.ApplyResources(this.menuTbwMethods_menuRemove_All_Error_Codes___, "menuTbwMethods_menuRemove_All_Error_Codes___");
            this.menuTbwMethods_menuRemove_All_Error_Codes___.Name = "menuTbwMethods_menuRemove_All_Error_Codes___";
            this.menuTbwMethods_menuRemove_All_Error_Codes___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Remove_1_Execute);
            this.menuTbwMethods_menuRemove_All_Error_Codes___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Remove_1_Inquire);
            // 
            // menuTbwMethods_menuExternal_File_T_ransaction___
            // 
            resources.ApplyResources(this.menuTbwMethods_menuExternal_File_T_ransaction___, "menuTbwMethods_menuExternal_File_T_ransaction___");
            this.menuTbwMethods_menuExternal_File_T_ransaction___.Name = "menuTbwMethods_menuExternal_File_T_ransaction___";
            this.menuTbwMethods_menuExternal_File_T_ransaction___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_External_Execute);
            this.menuTbwMethods_menuExternal_File_T_ransaction___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_External_Inquire);
            // 
            // menuTbwMethods_menuCheck_External_Voucher___
            // 
            resources.ApplyResources(this.menuTbwMethods_menuCheck_External_Voucher___, "menuTbwMethods_menuCheck_External_Voucher___");
            this.menuTbwMethods_menuCheck_External_Voucher___.Name = "menuTbwMethods_menuCheck_External_Voucher___";
            this.menuTbwMethods_menuCheck_External_Voucher___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Check_Execute);
            this.menuTbwMethods_menuCheck_External_Voucher___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Check_Inquire);
            // 
            // menuTbwMethods_menuCreate_Voucher
            // 
            resources.ApplyResources(this.menuTbwMethods_menuCreate_Voucher, "menuTbwMethods_menuCreate_Voucher");
            this.menuTbwMethods_menuCreate_Voucher.Name = "menuTbwMethods_menuCreate_Voucher";
            this.menuTbwMethods_menuCreate_Voucher.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Create_Execute);
            this.menuTbwMethods_menuCreate_Voucher.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Create_Inquire);
            // 
            // menuTbwMethods_menu_Change_Company___
            // 
            resources.ApplyResources(this.menuTbwMethods_menu_Change_Company___, "menuTbwMethods_menu_Change_Company___");
            this.menuTbwMethods_menu_Change_Company___.Name = "menuTbwMethods_menu_Change_Company___";
            this.menuTbwMethods_menu_Change_Company___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Change_1_Execute);
            this.menuTbwMethods_menu_Change_Company___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Change_1_Inquire);
            // 
            // menuOperations_menuShow__Transactions
            // 
            resources.ApplyResources(this.menuOperations_menuShow__Transactions, "menuOperations_menuShow__Transactions");
            this.menuOperations_menuShow__Transactions.Name = "menuOperations_menuShow__Transactions";
            this.menuOperations_menuShow__Transactions.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Show_Execute);
            this.menuOperations_menuShow__Transactions.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Show_Inquire);
            // 
            // menuOperations_menu_Change_Company___
            // 
            resources.ApplyResources(this.menuOperations_menu_Change_Company___, "menuOperations_menu_Change_Company___");
            this.menuOperations_menu_Change_Company___.Name = "menuOperations_menu_Change_Company___";
            this.menuOperations_menu_Change_Company___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Change_Execute);
            this.menuOperations_menu_Change_Company___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Change_Inquire);
            // 
            // colCompany
            // 
            resources.ApplyResources(this.colCompany, "colCompany");
            this.colCompany.Name = "colCompany";
            this.colCompany.NamedProperties.Put("EnumerateMethod", "");
            this.colCompany.NamedProperties.Put("FieldFlags", "67");
            this.colCompany.NamedProperties.Put("LovReference", "COMPANY_FINANCE");
            this.colCompany.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.colCompany.NamedProperties.Put("ValidateMethod", "");
            this.colCompany.Position = 3;
            // 
            // colLoadId
            // 
            this.colLoadId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colLoadId.MaxLength = 20;
            this.colLoadId.Name = "colLoadId";
            this.colLoadId.NamedProperties.Put("EnumerateMethod", "");
            this.colLoadId.NamedProperties.Put("FieldFlags", "163");
            this.colLoadId.NamedProperties.Put("LovReference", "");
            this.colLoadId.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colLoadId.NamedProperties.Put("ResizeableChildObject", "");
            this.colLoadId.NamedProperties.Put("SqlColumn", "LOAD_ID");
            this.colLoadId.NamedProperties.Put("ValidateMethod", "");
            this.colLoadId.Position = 4;
            resources.ApplyResources(this.colLoadId, "colLoadId");
            // 
            // colVoucherType
            // 
            this.colVoucherType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colVoucherType.MaxLength = 3;
            this.colVoucherType.Name = "colVoucherType";
            this.colVoucherType.NamedProperties.Put("EnumerateMethod", "");
            this.colVoucherType.NamedProperties.Put("FieldFlags", "295");
            this.colVoucherType.NamedProperties.Put("LovReference", "");
            this.colVoucherType.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colVoucherType.NamedProperties.Put("ResizeableChildObject", "");
            this.colVoucherType.NamedProperties.Put("SqlColumn", "VOUCHER_TYPE");
            this.colVoucherType.NamedProperties.Put("ValidateMethod", "");
            this.colVoucherType.Position = 5;
            resources.ApplyResources(this.colVoucherType, "colVoucherType");
            this.colVoucherType.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colVoucherType_WindowActions);
            // 
            // colLoadDate
            // 
            this.colLoadDate.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.colLoadDate.Format = "d";
            this.colLoadDate.Name = "colLoadDate";
            this.colLoadDate.NamedProperties.Put("EnumerateMethod", "");
            this.colLoadDate.NamedProperties.Put("FieldFlags", "295");
            this.colLoadDate.NamedProperties.Put("LovReference", "");
            this.colLoadDate.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colLoadDate.NamedProperties.Put("ResizeableChildObject", "");
            this.colLoadDate.NamedProperties.Put("SqlColumn", "LOAD_DATE");
            this.colLoadDate.NamedProperties.Put("ValidateMethod", "");
            this.colLoadDate.Position = 6;
            resources.ApplyResources(this.colLoadDate, "colLoadDate");
            // 
            // colUserid
            // 
            this.colUserid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colUserid.MaxLength = 30;
            this.colUserid.Name = "colUserid";
            this.colUserid.NamedProperties.Put("EnumerateMethod", "");
            this.colUserid.NamedProperties.Put("FieldFlags", "295");
            this.colUserid.NamedProperties.Put("LovReference", "");
            this.colUserid.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colUserid.NamedProperties.Put("ResizeableChildObject", "");
            this.colUserid.NamedProperties.Put("SqlColumn", "USERID");
            this.colUserid.NamedProperties.Put("ValidateMethod", "");
            this.colUserid.Position = 7;
            resources.ApplyResources(this.colUserid, "colUserid");
            // 
            // colsExtLoadState
            // 
            this.colsExtLoadState.MaxLength = 200;
            this.colsExtLoadState.Name = "colsExtLoadState";
            this.colsExtLoadState.NamedProperties.Put("EnumerateMethod", "");
            this.colsExtLoadState.NamedProperties.Put("FieldFlags", "291");
            this.colsExtLoadState.NamedProperties.Put("LovReference", "");
            this.colsExtLoadState.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsExtLoadState.NamedProperties.Put("ResizeableChildObject", "");
            this.colsExtLoadState.NamedProperties.Put("SqlColumn", "EXT_LOAD_STATE");
            this.colsExtLoadState.NamedProperties.Put("ValidateMethod", "");
            this.colsExtLoadState.Position = 8;
            resources.ApplyResources(this.colsExtLoadState, "colsExtLoadState");
            // 
            // colsLoadType
            // 
            this.colsLoadType.MaxLength = 20;
            this.colsLoadType.Name = "colsLoadType";
            this.colsLoadType.NamedProperties.Put("EnumerateMethod", "");
            this.colsLoadType.NamedProperties.Put("FieldFlags", "291");
            this.colsLoadType.NamedProperties.Put("LovReference", "");
            this.colsLoadType.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsLoadType.NamedProperties.Put("ResizeableChildObject", "");
            this.colsLoadType.NamedProperties.Put("SqlColumn", "LOAD_TYPE");
            this.colsLoadType.NamedProperties.Put("ValidateMethod", "");
            this.colsLoadType.Position = 9;
            resources.ApplyResources(this.colsLoadType, "colsLoadType");
            // 
            // colnLoadFileId
            // 
            this.colnLoadFileId.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colnLoadFileId.Name = "colnLoadFileId";
            this.colnLoadFileId.NamedProperties.Put("EnumerateMethod", "");
            this.colnLoadFileId.NamedProperties.Put("FieldFlags", "291");
            this.colnLoadFileId.NamedProperties.Put("LovReference", "");
            this.colnLoadFileId.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colnLoadFileId.NamedProperties.Put("ResizeableChildObject", "");
            this.colnLoadFileId.NamedProperties.Put("SqlColumn", "LOAD_FILE_ID");
            this.colnLoadFileId.NamedProperties.Put("ValidateMethod", "");
            this.colnLoadFileId.Position = 10;
            resources.ApplyResources(this.colnLoadFileId, "colnLoadFileId");
            // 
            // colsExtLoadStateDb
            // 
            resources.ApplyResources(this.colsExtLoadStateDb, "colsExtLoadStateDb");
            this.colsExtLoadStateDb.MaxLength = 20;
            this.colsExtLoadStateDb.Name = "colsExtLoadStateDb";
            this.colsExtLoadStateDb.NamedProperties.Put("EnumerateMethod", "");
            this.colsExtLoadStateDb.NamedProperties.Put("FieldFlags", "288");
            this.colsExtLoadStateDb.NamedProperties.Put("LovReference", "");
            this.colsExtLoadStateDb.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsExtLoadStateDb.NamedProperties.Put("SqlColumn", "EXT_LOAD_STATE_DB");
            this.colsExtLoadStateDb.Position = 11;
            // 
            // menuOperations
            // 
            this.menuOperations.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_Show,
            this.menuSeparator1,
            this.menuItem__Change});
            this.menuOperations.Name = "menuOperations";
            resources.ApplyResources(this.menuOperations, "menuOperations");
            // 
            // menuItem_Show
            // 
            this.menuItem_Show.Command = this.menuOperations_menuShow__Transactions;
            this.menuItem_Show.Name = "menuItem_Show";
            resources.ApplyResources(this.menuItem_Show, "menuItem_Show");
            this.menuItem_Show.Text = "Show &Transactions";
            // 
            // menuSeparator1
            // 
            this.menuSeparator1.Name = "menuSeparator1";
            resources.ApplyResources(this.menuSeparator1, "menuSeparator1");
            // 
            // menuItem__Change
            // 
            this.menuItem__Change.Command = this.menuOperations_menu_Change_Company___;
            this.menuItem__Change.Name = "menuItem__Change";
            resources.ApplyResources(this.menuItem__Change, "menuItem__Change");
            this.menuItem__Change.Text = "&Change Company...";
            // 
            // menuTbwMethods
            // 
            this.menuTbwMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_Show_1,
            this.menuItem_Remove,
            this.menuItem_Remove_1,
            this.menuItem_External,
            this.menuSeparator2,
            this.menuItem_Check,
            this.menuItem_Create,
            this.menuSeparator3,
            this.menuItem__Change_1});
            this.menuTbwMethods.Name = "menuTbwMethods";
            resources.ApplyResources(this.menuTbwMethods, "menuTbwMethods");
            // 
            // menuItem_Show_1
            // 
            this.menuItem_Show_1.Command = this.menuTbwMethods_menuShow__Transactions___;
            this.menuItem_Show_1.Name = "menuItem_Show_1";
            resources.ApplyResources(this.menuItem_Show_1, "menuItem_Show_1");
            this.menuItem_Show_1.Text = "Show &Transactions...";
            // 
            // menuItem_Remove
            // 
            this.menuItem_Remove.Command = this.menuTbwMethods_menuRemove_loads___;
            this.menuItem_Remove.Name = "menuItem_Remove";
            resources.ApplyResources(this.menuItem_Remove, "menuItem_Remove");
            this.menuItem_Remove.Text = "Remove loads...";
            // 
            // menuItem_Remove_1
            // 
            this.menuItem_Remove_1.Command = this.menuTbwMethods_menuRemove_All_Error_Codes___;
            this.menuItem_Remove_1.Name = "menuItem_Remove_1";
            resources.ApplyResources(this.menuItem_Remove_1, "menuItem_Remove_1");
            this.menuItem_Remove_1.Text = "Remove All Error Codes...";
            // 
            // menuItem_External
            // 
            this.menuItem_External.Command = this.menuTbwMethods_menuExternal_File_T_ransaction___;
            this.menuItem_External.Name = "menuItem_External";
            resources.ApplyResources(this.menuItem_External, "menuItem_External");
            this.menuItem_External.Text = "External File T&ransaction...";
            // 
            // menuSeparator2
            // 
            this.menuSeparator2.Name = "menuSeparator2";
            resources.ApplyResources(this.menuSeparator2, "menuSeparator2");
            // 
            // menuItem_Check
            // 
            this.menuItem_Check.Command = this.menuTbwMethods_menuCheck_External_Voucher___;
            this.menuItem_Check.Name = "menuItem_Check";
            resources.ApplyResources(this.menuItem_Check, "menuItem_Check");
            this.menuItem_Check.Text = "Check External Voucher...";
            // 
            // menuItem_Create
            // 
            this.menuItem_Create.Command = this.menuTbwMethods_menuCreate_Voucher;
            this.menuItem_Create.Name = "menuItem_Create";
            resources.ApplyResources(this.menuItem_Create, "menuItem_Create");
            this.menuItem_Create.Text = "Create Voucher";
            // 
            // menuSeparator3
            // 
            this.menuSeparator3.Name = "menuSeparator3";
            resources.ApplyResources(this.menuSeparator3, "menuSeparator3");
            // 
            // menuItem__Change_1
            // 
            this.menuItem__Change_1.Command = this.menuTbwMethods_menu_Change_Company___;
            this.menuItem__Change_1.Name = "menuItem__Change_1";
            resources.ApplyResources(this.menuItem__Change_1, "menuItem__Change_1");
            this.menuItem__Change_1.Text = "&Change Company...";
            // 
            // tbwExtLoadParams
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colCompany);
            this.Controls.Add(this.colLoadId);
            this.Controls.Add(this.colVoucherType);
            this.Controls.Add(this.colLoadDate);
            this.Controls.Add(this.colUserid);
            this.Controls.Add(this.colsExtLoadState);
            this.Controls.Add(this.colsLoadType);
            this.Controls.Add(this.colnLoadFileId);
            this.Controls.Add(this.colsExtLoadStateDb);
            this.Name = "tbwExtLoadParams";
            this.NamedProperties.Put("DefaultOrderBy", "LOAD_DATE DESC , LPAD(LOAD_ID, 50, \' \')DESC");
            this.NamedProperties.Put("DefaultWhere", "COMPANY=:global.company");
            this.NamedProperties.Put("LogicalUnit", "ExtLoadInfo");
            this.NamedProperties.Put("PackageName", "EXT_LOAD_INFO_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "448");
            this.NamedProperties.Put("ViewName", "EXT_LOAD_INFO");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tbwExtLoadParams_WindowActions);
            this.Controls.SetChildIndex(this.colsExtLoadStateDb, 0);
            this.Controls.SetChildIndex(this.colnLoadFileId, 0);
            this.Controls.SetChildIndex(this.colsLoadType, 0);
            this.Controls.SetChildIndex(this.colsExtLoadState, 0);
            this.Controls.SetChildIndex(this.colUserid, 0);
            this.Controls.SetChildIndex(this.colLoadDate, 0);
            this.Controls.SetChildIndex(this.colVoucherType, 0);
            this.Controls.SetChildIndex(this.colLoadId, 0);
            this.Controls.SetChildIndex(this.colCompany, 0);
            this.Controls.SetChildIndex(this.@__colObjversion, 0);
            this.Controls.SetChildIndex(this.@__colObjid, 0);
            this.menuOperations.ResumeLayout(false);
            this.menuTbwMethods.ResumeLayout(false);
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

        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menuShow__Transactions___;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menuRemove_loads___;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menuRemove_All_Error_Codes___;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menuExternal_File_T_ransaction___;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menuCheck_External_Voucher___;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menuCreate_Voucher;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menu_Change_Company___;
        public Fnd.Windows.Forms.FndCommand menuOperations_menuShow__Transactions;
        public Fnd.Windows.Forms.FndCommand menuOperations_menu_Change_Company___;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuOperations;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Show;
        protected Fnd.Windows.Forms.FndToolStripSeparator menuSeparator1;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Change;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTbwMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Show_1;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Remove;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Remove_1;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_External;
        protected Fnd.Windows.Forms.FndToolStripSeparator menuSeparator2;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Check;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Create;
        protected Fnd.Windows.Forms.FndToolStripSeparator menuSeparator3;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Change_1;
	}
}
