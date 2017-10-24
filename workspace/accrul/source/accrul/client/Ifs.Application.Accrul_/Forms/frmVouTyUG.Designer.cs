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
	
	public partial class frmVouTyUG
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		protected cBackgroundText labeldfVoucherType;
		public cDataField dfVoucherType;
		protected cBackgroundText labeldfDescription;
		public cDataField dfDescription;
		protected cBackgroundText labeldfnSerieFromPer;
		public cDataField dfnSerieFromPer;
		protected cBackgroundText labeldfnSerieUntilPer;
		public cDataField dfnSerieUntilPer;
		public cDataField dfCompany;
		protected cBackgroundText labeldfnSerieFrom;
		public cDataField dfnSerieFrom;
		protected cBackgroundText labeldfnSerieUntil;
		public cDataField dfnSerieUntil;
		protected cBackgroundText labelccYearP;
		public cRecListDataField ccYearP;
		protected cBackgroundText labelccYear;
		public cRecSelExtComboBox ccYear;
		protected cBackgroundText labeldfPeriod;
		public cDataField dfPeriod;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVouTyUG));
            this.menuOperations_menuTrans_lation___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuOperations_menuChange__Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.tblVouTemplateRow_menuTrans_lation___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.tblVouTemplateRow_menuChange__Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuFrmMethods_menuTrans_lation___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuFrmMethods_menuChange__Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.labeldfVoucherType = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfVoucherType = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfDescription = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfDescription = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfnSerieFromPer = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfnSerieFromPer = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfnSerieUntilPer = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfnSerieUntilPer = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfCompany = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfnSerieFrom = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfnSerieFrom = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfnSerieUntil = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfnSerieUntil = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelccYearP = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.ccYearP = new Ifs.Fnd.ApplicationForms.cRecListDataField();
            this.labelccYear = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.ccYear = new Ifs.Fnd.ApplicationForms.cRecSelExtComboBox();
            this.labeldfPeriod = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfPeriod = new Ifs.Fnd.ApplicationForms.cDataField();
            this.menuFrmMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_Translation = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuSeparator1 = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.menuItem_Change = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.tblVouTemplateRow = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_Translation_1 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuSeparator2 = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.menuItem_Change_1 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuOperations = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_Translation_2 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuSeparator3 = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.menuItem_Change_2 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.tblUserGroups = new Ifs.Application.Accrul.cChildTableFinBase();
            this.tblUserGroups_colCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblUserGroups_colVoucherType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblUserGroups_colUserGroup = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblUserGroups_colDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblUserGroups_colAuthorizeLevel = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.tblUserGroups_colYear = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblUserGroups_colDefaultType = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.tblUserGroups_colDefaultType2 = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblUserGroups_colVoucherFunction = new Ifs.Fnd.ApplicationForms.cColumn();
            this.menuFrmMethods.SuspendLayout();
            this.tblVouTemplateRow.SuspendLayout();
            this.menuOperations.SuspendLayout();
            this.tblUserGroups.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuFrmMethods_menuTrans_lation___);
            this.commandManager.Commands.Add(this.menuFrmMethods_menuChange__Company___);
            this.commandManager.Commands.Add(this.tblVouTemplateRow_menuTrans_lation___);
            this.commandManager.Commands.Add(this.tblVouTemplateRow_menuChange__Company___);
            this.commandManager.Commands.Add(this.menuOperations_menuTrans_lation___);
            this.commandManager.Commands.Add(this.menuOperations_menuChange__Company___);
            this.commandManager.ContextMenus.Add(this.menuFrmMethods);
            this.commandManager.ContextMenus.Add(this.tblVouTemplateRow);
            this.commandManager.ContextMenus.Add(this.menuOperations);
            this.commandManager.ImageList = null;
            // 
            // menuOperations_menuTrans_lation___
            // 
            resources.ApplyResources(this.menuOperations_menuTrans_lation___, "menuOperations_menuTrans_lation___");
            this.menuOperations_menuTrans_lation___.Name = "menuOperations_menuTrans_lation___";
            this.menuOperations_menuTrans_lation___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Translation_2_Execute);
            this.menuOperations_menuTrans_lation___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Translation_2_Inquire);
            // 
            // menuOperations_menuChange__Company___
            // 
            resources.ApplyResources(this.menuOperations_menuChange__Company___, "menuOperations_menuChange__Company___");
            this.menuOperations_menuChange__Company___.Name = "menuOperations_menuChange__Company___";
            this.menuOperations_menuChange__Company___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Change_2_Execute);
            this.menuOperations_menuChange__Company___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Change_2_Inquire);
            // 
            // tblVouTemplateRow_menuTrans_lation___
            // 
            resources.ApplyResources(this.tblVouTemplateRow_menuTrans_lation___, "tblVouTemplateRow_menuTrans_lation___");
            this.tblVouTemplateRow_menuTrans_lation___.Name = "tblVouTemplateRow_menuTrans_lation___";
            this.tblVouTemplateRow_menuTrans_lation___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Translation_1_Execute);
            this.tblVouTemplateRow_menuTrans_lation___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Translation_1_Inquire);
            // 
            // tblVouTemplateRow_menuChange__Company___
            // 
            resources.ApplyResources(this.tblVouTemplateRow_menuChange__Company___, "tblVouTemplateRow_menuChange__Company___");
            this.tblVouTemplateRow_menuChange__Company___.Name = "tblVouTemplateRow_menuChange__Company___";
            this.tblVouTemplateRow_menuChange__Company___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Change_1_Execute);
            this.tblVouTemplateRow_menuChange__Company___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Change_1_Inquire);
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
            // labeldfVoucherType
            // 
            resources.ApplyResources(this.labeldfVoucherType, "labeldfVoucherType");
            this.labeldfVoucherType.Name = "labeldfVoucherType";
            // 
            // dfVoucherType
            // 
            this.dfVoucherType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfVoucherType, "dfVoucherType");
            this.dfVoucherType.Name = "dfVoucherType";
            this.dfVoucherType.NamedProperties.Put("EnumerateMethod", "");
            this.dfVoucherType.NamedProperties.Put("FieldFlags", "167");
            this.dfVoucherType.NamedProperties.Put("LovReference", "");
            this.dfVoucherType.NamedProperties.Put("SqlColumn", "VOUCHER_TYPE");
            this.dfVoucherType.NamedProperties.Put("ValidateMethod", "");
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
            this.dfDescription.NamedProperties.Put("ParentName", "dfVoucherType");
            this.dfDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.dfDescription.NamedProperties.Put("SqlColumn", "VOUCHER_TYPE_API.GET_DESCRIPTION(COMPANY,VOUCHER_TYPE)");
            this.dfDescription.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfnSerieFromPer
            // 
            resources.ApplyResources(this.labeldfnSerieFromPer, "labeldfnSerieFromPer");
            this.labeldfnSerieFromPer.Name = "labeldfnSerieFromPer";
            // 
            // dfnSerieFromPer
            // 
            this.dfnSerieFromPer.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfnSerieFromPer, "dfnSerieFromPer");
            this.dfnSerieFromPer.Name = "dfnSerieFromPer";
            this.dfnSerieFromPer.NamedProperties.Put("EnumerateMethod", "");
            this.dfnSerieFromPer.NamedProperties.Put("LovReference", "");
            this.dfnSerieFromPer.NamedProperties.Put("ResizeableChildObject", "");
            this.dfnSerieFromPer.NamedProperties.Put("SqlColumn", "SERIE_FROM");
            this.dfnSerieFromPer.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfnSerieUntilPer
            // 
            resources.ApplyResources(this.labeldfnSerieUntilPer, "labeldfnSerieUntilPer");
            this.labeldfnSerieUntilPer.Name = "labeldfnSerieUntilPer";
            // 
            // dfnSerieUntilPer
            // 
            this.dfnSerieUntilPer.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfnSerieUntilPer, "dfnSerieUntilPer");
            this.dfnSerieUntilPer.Name = "dfnSerieUntilPer";
            this.dfnSerieUntilPer.NamedProperties.Put("EnumerateMethod", "");
            this.dfnSerieUntilPer.NamedProperties.Put("LovReference", "");
            this.dfnSerieUntilPer.NamedProperties.Put("ResizeableChildObject", "");
            this.dfnSerieUntilPer.NamedProperties.Put("SqlColumn", "SERIE_UNTIL");
            this.dfnSerieUntilPer.NamedProperties.Put("ValidateMethod", "");
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
            // labeldfnSerieFrom
            // 
            resources.ApplyResources(this.labeldfnSerieFrom, "labeldfnSerieFrom");
            this.labeldfnSerieFrom.Name = "labeldfnSerieFrom";
            // 
            // dfnSerieFrom
            // 
            this.dfnSerieFrom.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfnSerieFrom, "dfnSerieFrom");
            this.dfnSerieFrom.Name = "dfnSerieFrom";
            this.dfnSerieFrom.NamedProperties.Put("EnumerateMethod", "");
            this.dfnSerieFrom.NamedProperties.Put("LovReference", "");
            this.dfnSerieFrom.NamedProperties.Put("ResizeableChildObject", "");
            this.dfnSerieFrom.NamedProperties.Put("SqlColumn", "SERIE_FROM");
            this.dfnSerieFrom.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfnSerieUntil
            // 
            resources.ApplyResources(this.labeldfnSerieUntil, "labeldfnSerieUntil");
            this.labeldfnSerieUntil.Name = "labeldfnSerieUntil";
            // 
            // dfnSerieUntil
            // 
            this.dfnSerieUntil.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfnSerieUntil, "dfnSerieUntil");
            this.dfnSerieUntil.Name = "dfnSerieUntil";
            this.dfnSerieUntil.NamedProperties.Put("EnumerateMethod", "");
            this.dfnSerieUntil.NamedProperties.Put("LovReference", "");
            this.dfnSerieUntil.NamedProperties.Put("ResizeableChildObject", "");
            this.dfnSerieUntil.NamedProperties.Put("SqlColumn", "SERIE_UNTIL");
            this.dfnSerieUntil.NamedProperties.Put("ValidateMethod", "");
            // 
            // labelccYearP
            // 
            resources.ApplyResources(this.labelccYearP, "labelccYearP");
            this.labelccYearP.Name = "labelccYearP";
            // 
            // ccYearP
            // 
            resources.ApplyResources(this.ccYearP, "ccYearP");
            this.ccYearP.Name = "ccYearP";
            this.ccYearP.NamedProperties.Put("DataType", "3");
            this.ccYearP.NamedProperties.Put("EnumerateMethod", "");
            this.ccYearP.NamedProperties.Put("FieldFlags", "163");
            this.ccYearP.NamedProperties.Put("LovReference", "");
            this.ccYearP.NamedProperties.Put("ResizeableChildObject", "");
            this.ccYearP.NamedProperties.Put("SqlColumn", "ACCOUNTING_YEAR");
            this.ccYearP.NamedProperties.Put("ValidateMethod", "");
            this.ccYearP.NamedProperties.Put("XDataLength", "4");
            // 
            // labelccYear
            // 
            resources.ApplyResources(this.labelccYear, "labelccYear");
            this.labelccYear.Name = "labelccYear";
            // 
            // ccYear
            // 
            resources.ApplyResources(this.ccYear, "ccYear");
            this.ccYear.Name = "ccYear";
            this.ccYear.NamedProperties.Put("DataType", "3");
            this.ccYear.NamedProperties.Put("EnumerateMethod", "");
            this.ccYear.NamedProperties.Put("FieldFlags", "131");
            this.ccYear.NamedProperties.Put("LovReference", "");
            this.ccYear.NamedProperties.Put("ResizeableChildObject", "");
            this.ccYear.NamedProperties.Put("SqlColumn", "ACCOUNTING_YEAR_USED");
            this.ccYear.NamedProperties.Put("ValidateMethod", "");
            this.ccYear.NamedProperties.Put("XDataLength", "4");
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
            this.dfPeriod.NamedProperties.Put("ParentName", "ccYearP");
            this.dfPeriod.NamedProperties.Put("ResizeableChildObject", "");
            this.dfPeriod.NamedProperties.Put("SqlColumn", "PERIOD");
            this.dfPeriod.NamedProperties.Put("ValidateMethod", "");
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
            // tblVouTemplateRow
            // 
            this.tblVouTemplateRow.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_Translation_1,
            this.menuSeparator2,
            this.menuItem_Change_1});
            this.tblVouTemplateRow.Name = "tblVouTemplateRow";
            resources.ApplyResources(this.tblVouTemplateRow, "tblVouTemplateRow");
            // 
            // menuItem_Translation_1
            // 
            this.menuItem_Translation_1.Command = this.tblVouTemplateRow_menuTrans_lation___;
            this.menuItem_Translation_1.Name = "menuItem_Translation_1";
            resources.ApplyResources(this.menuItem_Translation_1, "menuItem_Translation_1");
            this.menuItem_Translation_1.Text = "Trans&lation...";
            // 
            // menuSeparator2
            // 
            this.menuSeparator2.Name = "menuSeparator2";
            resources.ApplyResources(this.menuSeparator2, "menuSeparator2");
            // 
            // menuItem_Change_1
            // 
            this.menuItem_Change_1.Command = this.tblVouTemplateRow_menuChange__Company___;
            this.menuItem_Change_1.Name = "menuItem_Change_1";
            resources.ApplyResources(this.menuItem_Change_1, "menuItem_Change_1");
            this.menuItem_Change_1.Text = "Change &Company...";
            // 
            // menuOperations
            // 
            this.menuOperations.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_Translation_2,
            this.menuSeparator3,
            this.menuItem_Change_2});
            this.menuOperations.Name = "menuOperations";
            resources.ApplyResources(this.menuOperations, "menuOperations");
            // 
            // menuItem_Translation_2
            // 
            this.menuItem_Translation_2.Command = this.menuOperations_menuTrans_lation___;
            this.menuItem_Translation_2.Name = "menuItem_Translation_2";
            resources.ApplyResources(this.menuItem_Translation_2, "menuItem_Translation_2");
            this.menuItem_Translation_2.Text = "Trans&lation...";
            // 
            // menuSeparator3
            // 
            this.menuSeparator3.Name = "menuSeparator3";
            resources.ApplyResources(this.menuSeparator3, "menuSeparator3");
            // 
            // menuItem_Change_2
            // 
            this.menuItem_Change_2.Command = this.menuOperations_menuChange__Company___;
            this.menuItem_Change_2.Name = "menuItem_Change_2";
            resources.ApplyResources(this.menuItem_Change_2, "menuItem_Change_2");
            this.menuItem_Change_2.Text = "Change &Company...";
            // 
            // tblUserGroups
            // 
            this.tblUserGroups.Controls.Add(this.tblUserGroups_colCompany);
            this.tblUserGroups.Controls.Add(this.tblUserGroups_colVoucherType);
            this.tblUserGroups.Controls.Add(this.tblUserGroups_colUserGroup);
            this.tblUserGroups.Controls.Add(this.tblUserGroups_colDescription);
            this.tblUserGroups.Controls.Add(this.tblUserGroups_colAuthorizeLevel);
            this.tblUserGroups.Controls.Add(this.tblUserGroups_colYear);
            this.tblUserGroups.Controls.Add(this.tblUserGroups_colDefaultType);
            this.tblUserGroups.Controls.Add(this.tblUserGroups_colDefaultType2);
            this.tblUserGroups.Controls.Add(this.tblUserGroups_colVoucherFunction);
            resources.ApplyResources(this.tblUserGroups, "tblUserGroups");
            this.tblUserGroups.Name = "tblUserGroups";
            this.tblUserGroups.NamedProperties.Put("DefaultOrderBy", "");
            this.tblUserGroups.NamedProperties.Put("DefaultWhere", "COMPANY = :i_hWndFrame.frmVouTyUG.i_sCompany AND\r\nVOUCHER_TYPE =:i_hWndFrame.frmV" +
                    "ouTyUG.dfVoucherType  AND\r\nACCOUNTING_YEAR = :i_hWndFrame.frmVouTyUG.ccYear.i_sM" +
                    "yValue");
            this.tblUserGroups.NamedProperties.Put("LogicalUnit", "VoucherTypeUserGroup");
            this.tblUserGroups.NamedProperties.Put("PackageName", "VOUCHER_TYPE_USER_GROUP_API");
            this.tblUserGroups.NamedProperties.Put("ResizeableChildObject", "MLMM");
            this.tblUserGroups.NamedProperties.Put("ViewName", "VOUCHER_TYPE_USER_GROUP");
            this.tblUserGroups.NamedProperties.Put("Warnings", "FALSE");
            this.tblUserGroups.DataRecordGetDefaultsEvent += new System.EventHandler<Ifs.Fnd.ApplicationForms.FndReturnEventArgsSalBoolean>(this.tblUserGroups_DataRecordGetDefaultsEvent);
            this.tblUserGroups.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblUserGroups_WindowActions);
            this.tblUserGroups.Controls.SetChildIndex(this.tblUserGroups_colVoucherFunction, 0);
            this.tblUserGroups.Controls.SetChildIndex(this.tblUserGroups_colDefaultType2, 0);
            this.tblUserGroups.Controls.SetChildIndex(this.tblUserGroups_colDefaultType, 0);
            this.tblUserGroups.Controls.SetChildIndex(this.tblUserGroups_colYear, 0);
            this.tblUserGroups.Controls.SetChildIndex(this.tblUserGroups_colAuthorizeLevel, 0);
            this.tblUserGroups.Controls.SetChildIndex(this.tblUserGroups_colDescription, 0);
            this.tblUserGroups.Controls.SetChildIndex(this.tblUserGroups_colUserGroup, 0);
            this.tblUserGroups.Controls.SetChildIndex(this.tblUserGroups_colVoucherType, 0);
            this.tblUserGroups.Controls.SetChildIndex(this.tblUserGroups_colCompany, 0);
            // 
            // tblUserGroups_colCompany
            // 
            this.tblUserGroups_colCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblUserGroups_colCompany, "tblUserGroups_colCompany");
            this.tblUserGroups_colCompany.MaxLength = 20;
            this.tblUserGroups_colCompany.Name = "tblUserGroups_colCompany";
            this.tblUserGroups_colCompany.NamedProperties.Put("EnumerateMethod", "");
            this.tblUserGroups_colCompany.NamedProperties.Put("FieldFlags", "129");
            this.tblUserGroups_colCompany.NamedProperties.Put("LovReference", "");
            this.tblUserGroups_colCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.tblUserGroups_colCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.tblUserGroups_colCompany.NamedProperties.Put("ValidateMethod", "");
            this.tblUserGroups_colCompany.Position = 3;
            // 
            // tblUserGroups_colVoucherType
            // 
            this.tblUserGroups_colVoucherType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblUserGroups_colVoucherType, "tblUserGroups_colVoucherType");
            this.tblUserGroups_colVoucherType.MaxLength = 3;
            this.tblUserGroups_colVoucherType.Name = "tblUserGroups_colVoucherType";
            this.tblUserGroups_colVoucherType.NamedProperties.Put("EnumerateMethod", "");
            this.tblUserGroups_colVoucherType.NamedProperties.Put("FieldFlags", "131");
            this.tblUserGroups_colVoucherType.NamedProperties.Put("LovReference", "");
            this.tblUserGroups_colVoucherType.NamedProperties.Put("SqlColumn", "VOUCHER_TYPE");
            this.tblUserGroups_colVoucherType.Position = 4;
            // 
            // tblUserGroups_colUserGroup
            // 
            this.tblUserGroups_colUserGroup.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblUserGroups_colUserGroup.MaxLength = 30;
            this.tblUserGroups_colUserGroup.Name = "tblUserGroups_colUserGroup";
            this.tblUserGroups_colUserGroup.NamedProperties.Put("EnumerateMethod", "");
            this.tblUserGroups_colUserGroup.NamedProperties.Put("FieldFlags", "291");
            this.tblUserGroups_colUserGroup.NamedProperties.Put("LovReference", "USER_GROUP_FINANCE(COMPANY)");
            this.tblUserGroups_colUserGroup.NamedProperties.Put("ResizeableChildObject", "");
            this.tblUserGroups_colUserGroup.NamedProperties.Put("SqlColumn", "USER_GROUP");
            this.tblUserGroups_colUserGroup.NamedProperties.Put("ValidateMethod", "");
            this.tblUserGroups_colUserGroup.Position = 5;
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
            this.tblUserGroups_colDescription.Position = 6;
            resources.ApplyResources(this.tblUserGroups_colDescription, "tblUserGroups_colDescription");
            // 
            // tblUserGroups_colAuthorizeLevel
            // 
            this.tblUserGroups_colAuthorizeLevel.Name = "tblUserGroups_colAuthorizeLevel";
            this.tblUserGroups_colAuthorizeLevel.NamedProperties.Put("EnumerateMethod", "AUTHORIZE_LEVEL_API.Enumerate");
            this.tblUserGroups_colAuthorizeLevel.NamedProperties.Put("FieldFlags", "295");
            this.tblUserGroups_colAuthorizeLevel.NamedProperties.Put("LovReference", "");
            this.tblUserGroups_colAuthorizeLevel.NamedProperties.Put("ResizeableChildObject", "");
            this.tblUserGroups_colAuthorizeLevel.NamedProperties.Put("SqlColumn", "AUTHORIZE_LEVEL");
            this.tblUserGroups_colAuthorizeLevel.NamedProperties.Put("ValidateMethod", "");
            this.tblUserGroups_colAuthorizeLevel.Position = 7;
            resources.ApplyResources(this.tblUserGroups_colAuthorizeLevel, "tblUserGroups_colAuthorizeLevel");
            // 
            // tblUserGroups_colYear
            // 
            this.tblUserGroups_colYear.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.tblUserGroups_colYear, "tblUserGroups_colYear");
            this.tblUserGroups_colYear.MaxLength = 4;
            this.tblUserGroups_colYear.Name = "tblUserGroups_colYear";
            this.tblUserGroups_colYear.NamedProperties.Put("EnumerateMethod", "");
            this.tblUserGroups_colYear.NamedProperties.Put("FieldFlags", "163");
            this.tblUserGroups_colYear.NamedProperties.Put("LovReference", "");
            this.tblUserGroups_colYear.NamedProperties.Put("SqlColumn", "ACCOUNTING_YEAR");
            this.tblUserGroups_colYear.Position = 8;
            this.tblUserGroups_colYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tblUserGroups_colDefaultType
            // 
            this.tblUserGroups_colDefaultType.MaxLength = 10;
            this.tblUserGroups_colDefaultType.Name = "tblUserGroups_colDefaultType";
            this.tblUserGroups_colDefaultType.NamedProperties.Put("EnumerateMethod", "DEFAULT_TYPE_API.Enumerate");
            this.tblUserGroups_colDefaultType.NamedProperties.Put("FieldFlags", "295");
            this.tblUserGroups_colDefaultType.NamedProperties.Put("LovReference", "");
            this.tblUserGroups_colDefaultType.NamedProperties.Put("SqlColumn", "DEFAULT_TYPE");
            this.tblUserGroups_colDefaultType.NamedProperties.Put("ValidateMethod", "");
            this.tblUserGroups_colDefaultType.Position = 9;
            this.tblUserGroups_colDefaultType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            resources.ApplyResources(this.tblUserGroups_colDefaultType, "tblUserGroups_colDefaultType");
            this.tblUserGroups_colDefaultType.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblUserGroups_colDefaultType_WindowActions);
            // 
            // tblUserGroups_colDefaultType2
            // 
            resources.ApplyResources(this.tblUserGroups_colDefaultType2, "tblUserGroups_colDefaultType2");
            this.tblUserGroups_colDefaultType2.MaxLength = 10;
            this.tblUserGroups_colDefaultType2.Name = "tblUserGroups_colDefaultType2";
            this.tblUserGroups_colDefaultType2.NamedProperties.Put("EnumerateMethod", "DEFAULT_TYPE_API.Enumerate");
            this.tblUserGroups_colDefaultType2.NamedProperties.Put("LovReference", "");
            this.tblUserGroups_colDefaultType2.NamedProperties.Put("SqlColumn", "DEFAULT_TYPE");
            this.tblUserGroups_colDefaultType2.Position = 10;
            this.tblUserGroups_colDefaultType2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tblUserGroups_colVoucherFunction
            // 
            this.tblUserGroups_colVoucherFunction.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblUserGroups_colVoucherFunction.MaxLength = 10;
            this.tblUserGroups_colVoucherFunction.Name = "tblUserGroups_colVoucherFunction";
            this.tblUserGroups_colVoucherFunction.NamedProperties.Put("EnumerateMethod", "");
            this.tblUserGroups_colVoucherFunction.NamedProperties.Put("FieldFlags", "295");
            this.tblUserGroups_colVoucherFunction.NamedProperties.Put("LovReference", "VOUCHER_TYPE_DETAIL_LOV(COMPANY, VOUCHER_TYPE)");
            this.tblUserGroups_colVoucherFunction.NamedProperties.Put("ResizeableChildObject", "");
            this.tblUserGroups_colVoucherFunction.NamedProperties.Put("SqlColumn", "FUNCTION_GROUP");
            this.tblUserGroups_colVoucherFunction.NamedProperties.Put("ValidateMethod", "");
            this.tblUserGroups_colVoucherFunction.Position = 11;
            resources.ApplyResources(this.tblUserGroups_colVoucherFunction, "tblUserGroups_colVoucherFunction");
            // 
            // frmVouTyUG
            // 
            this.AutoScaleBaseDpi = new System.Drawing.Size(106, 106);
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.tblUserGroups);
            this.Controls.Add(this.dfPeriod);
            this.Controls.Add(this.ccYear);
            this.Controls.Add(this.ccYearP);
            this.Controls.Add(this.dfnSerieUntil);
            this.Controls.Add(this.dfnSerieFrom);
            this.Controls.Add(this.dfCompany);
            this.Controls.Add(this.dfnSerieUntilPer);
            this.Controls.Add(this.dfnSerieFromPer);
            this.Controls.Add(this.dfDescription);
            this.Controls.Add(this.dfVoucherType);
            this.Controls.Add(this.labeldfPeriod);
            this.Controls.Add(this.labelccYear);
            this.Controls.Add(this.labelccYearP);
            this.Controls.Add(this.labeldfnSerieUntil);
            this.Controls.Add(this.labeldfnSerieFrom);
            this.Controls.Add(this.labeldfnSerieUntilPer);
            this.Controls.Add(this.labeldfnSerieFromPer);
            this.Controls.Add(this.labeldfDescription);
            this.Controls.Add(this.labeldfVoucherType);
            this.MaximizeBox = true;
            this.Name = "frmVouTyUG";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "company = :i_hWndFrame.frmVouTyUG.i_sCompany\r\nand voucher_type = :i_hWndFrame.frm" +
                    "VouTyUG.sVoucherType");
            this.NamedProperties.Put("LogicalUnit", "VoucherNoSerial");
            this.NamedProperties.Put("PackageName", "VOUCHER_NO_SERIAL_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "0");
            this.NamedProperties.Put("SourceFlags", "129");
            this.NamedProperties.Put("ViewName", "VOUCHER_NO_SERIAL_YR");
            this.NamedProperties.Put("Warnings", "TRUE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.frmVouTyUG_WindowActions);
            this.menuFrmMethods.ResumeLayout(false);
            this.tblVouTemplateRow.ResumeLayout(false);
            this.menuOperations.ResumeLayout(false);
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
		
		public Fnd.Windows.Forms.FndCommand menuOperations_menuTrans_lation___;
        public Fnd.Windows.Forms.FndCommand menuOperations_menuChange__Company___;
        public Fnd.Windows.Forms.FndCommand tblVouTemplateRow_menuTrans_lation___;
        public Fnd.Windows.Forms.FndCommand tblVouTemplateRow_menuChange__Company___;
        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menuTrans_lation___;
        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menuChange__Company___;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuFrmMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Translation;
        protected Fnd.Windows.Forms.FndToolStripSeparator menuSeparator1;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change;
        protected Fnd.Windows.Forms.FndContextMenuStrip tblVouTemplateRow;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Translation_1;
        protected Fnd.Windows.Forms.FndToolStripSeparator menuSeparator2;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change_1;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuOperations;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Translation_2;
        protected Fnd.Windows.Forms.FndToolStripSeparator menuSeparator3;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change_2;
        public cChildTableFinBase tblUserGroups;
        protected cColumn tblUserGroups_colCompany;
        protected cColumn tblUserGroups_colVoucherType;
        protected cColumn tblUserGroups_colUserGroup;
        protected cColumn tblUserGroups_colDescription;
        protected cLookupColumn tblUserGroups_colAuthorizeLevel;
        protected cColumn tblUserGroups_colYear;
        protected cLookupColumn tblUserGroups_colDefaultType;
        protected cColumn tblUserGroups_colDefaultType2;
        protected cColumn tblUserGroups_colVoucherFunction;
	}
}
