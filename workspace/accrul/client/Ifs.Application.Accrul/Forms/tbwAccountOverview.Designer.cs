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
	
	public partial class tbwAccountOverview
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cColumn colsCompany;
		public cColumnFin colsAccount;
		public cColumnFin colsAccountDescription;
		public cColumnFin colsAccountType;
		public cColumnFin colsAccountTypeDescription;
		public cColumnFin colsAccountGroup;
		public cColumnFin colsAccountGroupDescription;
		public cLookupColumn colsTaxHandlingValue;
		public cCheckBoxColumn colsPrevTaxHandlingValue;
		public cCheckBoxColumn colsTaxCodeMandatory;
		public cColumnFin coldtValidFrom;
		public cColumnFin coldtValiduntil;
		public cCheckBoxColumn colCurrencyBalance;
		public cCheckBoxColumn colBudgetAccount;
		public cCheckBoxColumn colLedgerAccount;
		public cCheckBoxColumn colTaxAccount;
		public cCheckBoxColumn colsStatAccount;
		// Bug 85877, Begin, changed the class type and set insertable
		public cCheckBoxColumn colsExcludeProjFollowup;
		// Bug 85877, Removed the message action PM_DataItemQueryEnabled
		public cLookupColumnFin colsArchivingTrans;
		// Bug 85877, End
		public cLookupColumnFin colsReqAccntB;
		public cLookupColumnFin colsReqAccntC;
		public cLookupColumnFin colsReqAccntD;
		public cLookupColumnFin colsReqAccntE;
		public cLookupColumnFin colsReqAccntF;
		public cLookupColumnFin colsReqAccntG;
		public cLookupColumnFin colsReqAccntH;
		public cLookupColumnFin colsReqAccntI;
		public cLookupColumnFin colsReqAccntJ;
		public cLookupColumn colsReqQuantity;
		public cLookupColumn colsProcessCode;
		public cLookupColumn colsReqText;
		public cCheckBoxColumn colsCBCodeString;
		// Bug 85877, Begin, changed the class type to cCheckBoxColumn and override the PM_DataItemQueryEnabled
		public cCheckBoxColumn colsCBAttribute;
		public cCheckBoxColumn colsCBText;
		// Bug 85877, End
		public cColumn colsText;
		public cLookupColumnFin colsReqBudgetCodeB;
		public cLookupColumnFin colsReqBudgetCodeC;
		public cLookupColumnFin colsReqBudgetCodeD;
		public cLookupColumnFin colsReqBudgetCodeE;
		public cLookupColumnFin colsReqBudgetCodeF;
		public cLookupColumnFin colsReqBudgetCodeG;
		public cLookupColumnFin colsReqBudgetCodeH;
		public cLookupColumnFin colsReqBudgetCodeI;
		public cLookupColumnFin colsReqBudgetCodeJ;
		// Bug 89393 Begin, Change cColumn to cLookupColumnFin
		public cLookupColumnFin colsReqBudgetQuantity;
		// Bug 89393 End
		public cColumn coldCompanyFinanceValid_From;
		public cColumn colsLogicalAccountTypeDb;
		// Bug 65271,Begin, Used in DataSourcePrepareKeyTransfer
		public cColumn colCodePart;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwAccountOverview));
            this.menuTbwMethods_menuCode__String_Completion___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_menu_Account___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_menu_Tax_Codes_per_Account___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_menu_Code_Part_Attribute_Connection_ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_menu_Project_Cost_Revenue_Element_pe = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_menuTrans_lation___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_menu_Notes___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_menuChange__Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.colsCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsAccount = new Ifs.Application.Accrul.cColumnFin();
            this.colsAccountDescription = new Ifs.Application.Accrul.cColumnFin();
            this.colsAccountType = new Ifs.Application.Accrul.cColumnFin();
            this.colsAccountTypeDescription = new Ifs.Application.Accrul.cColumnFin();
            this.colsAccountGroup = new Ifs.Application.Accrul.cColumnFin();
            this.colsAccountGroupDescription = new Ifs.Application.Accrul.cColumnFin();
            this.colsTaxHandlingValue = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.colsPrevTaxHandlingValue = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.colsTaxCodeMandatory = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.coldtValidFrom = new Ifs.Application.Accrul.cColumnFin();
            this.coldtValiduntil = new Ifs.Application.Accrul.cColumnFin();
            this.colCurrencyBalance = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.colBudgetAccount = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.colLedgerAccount = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.colTaxAccount = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.colsStatAccount = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.colsExcludeProjFollowup = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.colsArchivingTrans = new Ifs.Application.Accrul.cLookupColumnFin();
            this.colsReqAccntB = new Ifs.Application.Accrul.cLookupColumnFin();
            this.colsReqAccntC = new Ifs.Application.Accrul.cLookupColumnFin();
            this.colsReqAccntD = new Ifs.Application.Accrul.cLookupColumnFin();
            this.colsReqAccntE = new Ifs.Application.Accrul.cLookupColumnFin();
            this.colsReqAccntF = new Ifs.Application.Accrul.cLookupColumnFin();
            this.colsReqAccntG = new Ifs.Application.Accrul.cLookupColumnFin();
            this.colsReqAccntH = new Ifs.Application.Accrul.cLookupColumnFin();
            this.colsReqAccntI = new Ifs.Application.Accrul.cLookupColumnFin();
            this.colsReqAccntJ = new Ifs.Application.Accrul.cLookupColumnFin();
            this.colsReqQuantity = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.colsProcessCode = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.colsReqText = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.colsCBCodeString = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.colsCBAttribute = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.colsCBText = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.colsText = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsReqBudgetCodeB = new Ifs.Application.Accrul.cLookupColumnFin();
            this.colsReqBudgetCodeC = new Ifs.Application.Accrul.cLookupColumnFin();
            this.colsReqBudgetCodeD = new Ifs.Application.Accrul.cLookupColumnFin();
            this.colsReqBudgetCodeE = new Ifs.Application.Accrul.cLookupColumnFin();
            this.colsReqBudgetCodeF = new Ifs.Application.Accrul.cLookupColumnFin();
            this.colsReqBudgetCodeG = new Ifs.Application.Accrul.cLookupColumnFin();
            this.colsReqBudgetCodeH = new Ifs.Application.Accrul.cLookupColumnFin();
            this.colsReqBudgetCodeI = new Ifs.Application.Accrul.cLookupColumnFin();
            this.colsReqBudgetCodeJ = new Ifs.Application.Accrul.cLookupColumnFin();
            this.colsReqBudgetQuantity = new Ifs.Application.Accrul.cLookupColumnFin();
            this.coldCompanyFinanceValid_From = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsLogicalAccountTypeDb = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colCodePart = new Ifs.Fnd.ApplicationForms.cColumn();
            this.menuTbwMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_Code = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuSeparator1 = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.menuItem__Account = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem__Tax = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuSeparator2 = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.menuItem__Code = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem__Project = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuSeparator3 = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.menuItem_Translation = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuSeparator4 = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.menuItem__Notes = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuSeparator5 = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.menuItem_Change = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.colsExcludePeriodicalCap = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.colsConsAccnt = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsConsCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsConsolidAccountDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsExcludeCurrTrans = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.colsKeepRepCurrency = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.colsKeepReportingEntity = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.menuTbwMethods.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuTbwMethods_menuCode__String_Completion___);
            this.commandManager.Commands.Add(this.menuTbwMethods_menu_Account___);
            this.commandManager.Commands.Add(this.menuTbwMethods_menu_Tax_Codes_per_Account___);
            this.commandManager.Commands.Add(this.menuTbwMethods_menu_Code_Part_Attribute_Connection_);
            this.commandManager.Commands.Add(this.menuTbwMethods_menu_Project_Cost_Revenue_Element_pe);
            this.commandManager.Commands.Add(this.menuTbwMethods_menuTrans_lation___);
            this.commandManager.Commands.Add(this.menuTbwMethods_menu_Notes___);
            this.commandManager.Commands.Add(this.menuTbwMethods_menuChange__Company___);
            this.commandManager.ContextMenus.Add(this.menuTbwMethods);
            // 
            // menuTbwMethods_menuCode__String_Completion___
            // 
            resources.ApplyResources(this.menuTbwMethods_menuCode__String_Completion___, "menuTbwMethods_menuCode__String_Completion___");
            this.menuTbwMethods_menuCode__String_Completion___.Name = "menuTbwMethods_menuCode__String_Completion___";
            this.menuTbwMethods_menuCode__String_Completion___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Code_Execute);
            this.menuTbwMethods_menuCode__String_Completion___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Code_Inquire);
            // 
            // menuTbwMethods_menu_Account___
            // 
            resources.ApplyResources(this.menuTbwMethods_menu_Account___, "menuTbwMethods_menu_Account___");
            this.menuTbwMethods_menu_Account___.Name = "menuTbwMethods_menu_Account___";
            this.menuTbwMethods_menu_Account___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Account_Execute);
            this.menuTbwMethods_menu_Account___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Account_Inquire);
            // 
            // menuTbwMethods_menu_Tax_Codes_per_Account___
            // 
            resources.ApplyResources(this.menuTbwMethods_menu_Tax_Codes_per_Account___, "menuTbwMethods_menu_Tax_Codes_per_Account___");
            this.menuTbwMethods_menu_Tax_Codes_per_Account___.Name = "menuTbwMethods_menu_Tax_Codes_per_Account___";
            this.menuTbwMethods_menu_Tax_Codes_per_Account___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Tax_Execute);
            this.menuTbwMethods_menu_Tax_Codes_per_Account___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Tax_Inquire);
            // 
            // menuTbwMethods_menu_Code_Part_Attribute_Connection_
            // 
            resources.ApplyResources(this.menuTbwMethods_menu_Code_Part_Attribute_Connection_, "menuTbwMethods_menu_Code_Part_Attribute_Connection_");
            this.menuTbwMethods_menu_Code_Part_Attribute_Connection_.Name = "menuTbwMethods_menu_Code_Part_Attribute_Connection_";
            this.menuTbwMethods_menu_Code_Part_Attribute_Connection_.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Code_Execute);
            this.menuTbwMethods_menu_Code_Part_Attribute_Connection_.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Code_Inquire);
            // 
            // menuTbwMethods_menu_Project_Cost_Revenue_Element_pe
            // 
            resources.ApplyResources(this.menuTbwMethods_menu_Project_Cost_Revenue_Element_pe, "menuTbwMethods_menu_Project_Cost_Revenue_Element_pe");
            this.menuTbwMethods_menu_Project_Cost_Revenue_Element_pe.Name = "menuTbwMethods_menu_Project_Cost_Revenue_Element_pe";
            this.menuTbwMethods_menu_Project_Cost_Revenue_Element_pe.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Project_Execute);
            this.menuTbwMethods_menu_Project_Cost_Revenue_Element_pe.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Project_Inquire);
            // 
            // menuTbwMethods_menuTrans_lation___
            // 
            resources.ApplyResources(this.menuTbwMethods_menuTrans_lation___, "menuTbwMethods_menuTrans_lation___");
            this.menuTbwMethods_menuTrans_lation___.Name = "menuTbwMethods_menuTrans_lation___";
            this.menuTbwMethods_menuTrans_lation___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Translation_Execute);
            this.menuTbwMethods_menuTrans_lation___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Translation_Inquire);
            // 
            // menuTbwMethods_menu_Notes___
            // 
            resources.ApplyResources(this.menuTbwMethods_menu_Notes___, "menuTbwMethods_menu_Notes___");
            this.menuTbwMethods_menu_Notes___.Name = "menuTbwMethods_menu_Notes___";
            this.menuTbwMethods_menu_Notes___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Notes_Execute);
            this.menuTbwMethods_menu_Notes___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Notes_Inquire);
            // 
            // menuTbwMethods_menuChange__Company___
            // 
            resources.ApplyResources(this.menuTbwMethods_menuChange__Company___, "menuTbwMethods_menuChange__Company___");
            this.menuTbwMethods_menuChange__Company___.Name = "menuTbwMethods_menuChange__Company___";
            this.menuTbwMethods_menuChange__Company___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Change_Execute);
            this.menuTbwMethods_menuChange__Company___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Change_Inquire);
            // 
            // colsCompany
            // 
            resources.ApplyResources(this.colsCompany, "colsCompany");
            this.colsCompany.MaxLength = 20;
            this.colsCompany.Name = "colsCompany";
            this.colsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.colsCompany.NamedProperties.Put("FieldFlags", "67");
            this.colsCompany.NamedProperties.Put("LovReference", "");
            this.colsCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.colsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.colsCompany.NamedProperties.Put("ValidateMethod", "");
            this.colsCompany.Position = 3;
            // 
            // colsAccount
            // 
            this.colsAccount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsAccount.MaxLength = 20;
            this.colsAccount.Name = "colsAccount";
            this.colsAccount.NamedProperties.Put("EnumerateMethod", "");
            this.colsAccount.NamedProperties.Put("FieldFlags", "163");
            this.colsAccount.NamedProperties.Put("LovReference", "ACCOUNTS_CONSOLIDATION(COMPANY)");
            this.colsAccount.NamedProperties.Put("ResizeableChildObject", "");
            this.colsAccount.NamedProperties.Put("SqlColumn", "ACCOUNT");
            this.colsAccount.NamedProperties.Put("ValidateMethod", "");
            this.colsAccount.Position = 4;
            resources.ApplyResources(this.colsAccount, "colsAccount");
            this.colsAccount.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsAccount_WindowActions);
            // 
            // colsAccountDescription
            // 
            this.colsAccountDescription.Name = "colsAccountDescription";
            this.colsAccountDescription.NamedProperties.Put("EnumerateMethod", "");
            this.colsAccountDescription.NamedProperties.Put("FieldFlags", "295");
            this.colsAccountDescription.NamedProperties.Put("LovReference", "");
            this.colsAccountDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.colsAccountDescription.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            this.colsAccountDescription.NamedProperties.Put("ValidateMethod", "");
            this.colsAccountDescription.Position = 5;
            resources.ApplyResources(this.colsAccountDescription, "colsAccountDescription");
            // 
            // colsAccountType
            // 
            this.colsAccountType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsAccountType.MaxLength = 20;
            this.colsAccountType.Name = "colsAccountType";
            this.colsAccountType.NamedProperties.Put("EnumerateMethod", "");
            this.colsAccountType.NamedProperties.Put("FieldFlags", "295");
            this.colsAccountType.NamedProperties.Put("LovReference", "ACCOUNT_TYPE(COMPANY)");
            this.colsAccountType.NamedProperties.Put("ResizeableChildObject", "");
            this.colsAccountType.NamedProperties.Put("SqlColumn", "ACCNT_TYPE");
            this.colsAccountType.NamedProperties.Put("ValidateMethod", "");
            this.colsAccountType.Position = 6;
            resources.ApplyResources(this.colsAccountType, "colsAccountType");
            this.colsAccountType.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsAccountType_WindowActions);
            // 
            // colsAccountTypeDescription
            // 
            this.colsAccountTypeDescription.Name = "colsAccountTypeDescription";
            this.colsAccountTypeDescription.NamedProperties.Put("EnumerateMethod", "");
            this.colsAccountTypeDescription.NamedProperties.Put("LovReference", "");
            this.colsAccountTypeDescription.NamedProperties.Put("ParentName", "colsAccountType");
            this.colsAccountTypeDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.colsAccountTypeDescription.NamedProperties.Put("SqlColumn", "Enterp_Comp_Connect_V170_API.Get_Company_Translation(COMPANY, \'ACCRUL\', \'AccountT" +
        "ype\', ACCNT_TYPE,NULL,\'NO\')");
            this.colsAccountTypeDescription.NamedProperties.Put("ValidateMethod", "");
            this.colsAccountTypeDescription.Position = 7;
            resources.ApplyResources(this.colsAccountTypeDescription, "colsAccountTypeDescription");
            // 
            // colsAccountGroup
            // 
            this.colsAccountGroup.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsAccountGroup.MaxLength = 20;
            this.colsAccountGroup.Name = "colsAccountGroup";
            this.colsAccountGroup.NamedProperties.Put("EnumerateMethod", "");
            this.colsAccountGroup.NamedProperties.Put("FieldFlags", "295");
            this.colsAccountGroup.NamedProperties.Put("LovReference", "ACCOUNT_GROUP(COMPANY)");
            this.colsAccountGroup.NamedProperties.Put("SqlColumn", "ACCNT_GROUP");
            this.colsAccountGroup.Position = 8;
            resources.ApplyResources(this.colsAccountGroup, "colsAccountGroup");
            // 
            // colsAccountGroupDescription
            // 
            this.colsAccountGroupDescription.MaxLength = 35;
            this.colsAccountGroupDescription.Name = "colsAccountGroupDescription";
            this.colsAccountGroupDescription.NamedProperties.Put("EnumerateMethod", "");
            this.colsAccountGroupDescription.NamedProperties.Put("FieldFlags", "288");
            this.colsAccountGroupDescription.NamedProperties.Put("LovReference", "");
            this.colsAccountGroupDescription.NamedProperties.Put("ParentName", "colsAccountGroup");
            this.colsAccountGroupDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.colsAccountGroupDescription.NamedProperties.Put("SqlColumn", "Account_group_API.Get_Description(COMPANY,ACCNT_GROUP)");
            this.colsAccountGroupDescription.NamedProperties.Put("ValidateMethod", "");
            this.colsAccountGroupDescription.Position = 9;
            resources.ApplyResources(this.colsAccountGroupDescription, "colsAccountGroupDescription");
            // 
            // colsTaxHandlingValue
            // 
            this.colsTaxHandlingValue.MaxLength = 25;
            this.colsTaxHandlingValue.Name = "colsTaxHandlingValue";
            this.colsTaxHandlingValue.NamedProperties.Put("EnumerateMethod", "TAX_HANDLING_VALUE_API.Enumerate");
            this.colsTaxHandlingValue.NamedProperties.Put("FieldFlags", "295");
            this.colsTaxHandlingValue.NamedProperties.Put("LovReference", "");
            this.colsTaxHandlingValue.NamedProperties.Put("ResizeableChildObject", "");
            this.colsTaxHandlingValue.NamedProperties.Put("SqlColumn", "TAX_HANDLING_VALUE");
            this.colsTaxHandlingValue.NamedProperties.Put("ValidateMethod", "");
            this.colsTaxHandlingValue.Position = 10;
            resources.ApplyResources(this.colsTaxHandlingValue, "colsTaxHandlingValue");
            this.colsTaxHandlingValue.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsTaxHandlingValue_WindowActions);
            // 
            // colsPrevTaxHandlingValue
            // 
            resources.ApplyResources(this.colsPrevTaxHandlingValue, "colsPrevTaxHandlingValue");
            this.colsPrevTaxHandlingValue.Name = "colsPrevTaxHandlingValue";
            this.colsPrevTaxHandlingValue.NamedProperties.Put("EnumerateMethod", "");
            this.colsPrevTaxHandlingValue.NamedProperties.Put("FieldFlags", "260");
            this.colsPrevTaxHandlingValue.NamedProperties.Put("LovReference", "");
            this.colsPrevTaxHandlingValue.NamedProperties.Put("ResizeableChildObject", "");
            this.colsPrevTaxHandlingValue.NamedProperties.Put("SqlColumn", "");
            this.colsPrevTaxHandlingValue.NamedProperties.Put("ValidateMethod", "");
            this.colsPrevTaxHandlingValue.Position = 11;
            // 
            // colsTaxCodeMandatory
            // 
            this.colsTaxCodeMandatory.Name = "colsTaxCodeMandatory";
            this.colsTaxCodeMandatory.NamedProperties.Put("EnumerateMethod", "");
            this.colsTaxCodeMandatory.NamedProperties.Put("FieldFlags", "295");
            this.colsTaxCodeMandatory.NamedProperties.Put("LovReference", "");
            this.colsTaxCodeMandatory.NamedProperties.Put("ResizeableChildObject", "");
            this.colsTaxCodeMandatory.NamedProperties.Put("SqlColumn", "TAX_CODE_MANDATORY");
            this.colsTaxCodeMandatory.NamedProperties.Put("ValidateMethod", "");
            this.colsTaxCodeMandatory.Position = 12;
            resources.ApplyResources(this.colsTaxCodeMandatory, "colsTaxCodeMandatory");
            this.colsTaxCodeMandatory.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsTaxCodeMandatory_WindowActions);
            // 
            // coldtValidFrom
            // 
            this.coldtValidFrom.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.coldtValidFrom.Format = "d";
            this.coldtValidFrom.Name = "coldtValidFrom";
            this.coldtValidFrom.NamedProperties.Put("EnumerateMethod", "");
            this.coldtValidFrom.NamedProperties.Put("FieldFlags", "295");
            this.coldtValidFrom.NamedProperties.Put("LovReference", "");
            this.coldtValidFrom.NamedProperties.Put("SqlColumn", "VALID_FROM");
            this.coldtValidFrom.Position = 13;
            resources.ApplyResources(this.coldtValidFrom, "coldtValidFrom");
            // 
            // coldtValiduntil
            // 
            this.coldtValiduntil.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.coldtValiduntil.Format = "d";
            this.coldtValiduntil.Name = "coldtValiduntil";
            this.coldtValiduntil.NamedProperties.Put("EnumerateMethod", "");
            this.coldtValiduntil.NamedProperties.Put("FieldFlags", "295");
            this.coldtValiduntil.NamedProperties.Put("LovReference", "");
            this.coldtValiduntil.NamedProperties.Put("SqlColumn", "VALID_UNTIL");
            this.coldtValiduntil.Position = 14;
            resources.ApplyResources(this.coldtValiduntil, "coldtValiduntil");
            // 
            // colCurrencyBalance
            // 
            this.colCurrencyBalance.CheckBox.CheckedValue = "Y";
            this.colCurrencyBalance.CheckBox.IgnoreCase = true;
            this.colCurrencyBalance.CheckBox.UncheckedValue = "N";
            this.colCurrencyBalance.MaxLength = 20;
            this.colCurrencyBalance.Name = "colCurrencyBalance";
            this.colCurrencyBalance.NamedProperties.Put("EnumerateMethod", "");
            this.colCurrencyBalance.NamedProperties.Put("FieldFlags", "294");
            this.colCurrencyBalance.NamedProperties.Put("LovReference", "");
            this.colCurrencyBalance.NamedProperties.Put("ResizeableChildObject", "");
            this.colCurrencyBalance.NamedProperties.Put("SqlColumn", "CURR_BALANCE_DB");
            this.colCurrencyBalance.NamedProperties.Put("ValidateMethod", "");
            this.colCurrencyBalance.Position = 15;
            resources.ApplyResources(this.colCurrencyBalance, "colCurrencyBalance");
            this.colCurrencyBalance.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colCurrencyBalance_WindowActions);
            // 
            // colBudgetAccount
            // 
            this.colBudgetAccount.CheckBox.CheckedValue = "Y";
            this.colBudgetAccount.CheckBox.IgnoreCase = true;
            this.colBudgetAccount.CheckBox.UncheckedValue = "N";
            this.colBudgetAccount.MaxLength = 20;
            this.colBudgetAccount.Name = "colBudgetAccount";
            this.colBudgetAccount.NamedProperties.Put("EnumerateMethod", "");
            this.colBudgetAccount.NamedProperties.Put("FieldFlags", "295");
            this.colBudgetAccount.NamedProperties.Put("LovReference", "");
            this.colBudgetAccount.NamedProperties.Put("ResizeableChildObject", "");
            this.colBudgetAccount.NamedProperties.Put("SqlColumn", "BUD_ACCOUNT_DB");
            this.colBudgetAccount.NamedProperties.Put("ValidateMethod", "");
            this.colBudgetAccount.Position = 16;
            resources.ApplyResources(this.colBudgetAccount, "colBudgetAccount");
            this.colBudgetAccount.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colBudgetAccount_WindowActions);
            // 
            // colLedgerAccount
            // 
            this.colLedgerAccount.CheckBox.CheckedValue = "Y";
            this.colLedgerAccount.CheckBox.IgnoreCase = true;
            this.colLedgerAccount.CheckBox.UncheckedValue = "N";
            this.colLedgerAccount.MaxLength = 20;
            this.colLedgerAccount.Name = "colLedgerAccount";
            this.colLedgerAccount.NamedProperties.Put("EnumerateMethod", "");
            this.colLedgerAccount.NamedProperties.Put("FieldFlags", "295");
            this.colLedgerAccount.NamedProperties.Put("LovReference", "");
            this.colLedgerAccount.NamedProperties.Put("ResizeableChildObject", "");
            this.colLedgerAccount.NamedProperties.Put("SqlColumn", "LEDG_FLAG_DB");
            this.colLedgerAccount.NamedProperties.Put("ValidateMethod", "");
            this.colLedgerAccount.Position = 17;
            resources.ApplyResources(this.colLedgerAccount, "colLedgerAccount");
            this.colLedgerAccount.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colLedgerAccount_WindowActions);
            // 
            // colTaxAccount
            // 
            this.colTaxAccount.CheckBox.CheckedValue = "Y";
            this.colTaxAccount.CheckBox.IgnoreCase = true;
            this.colTaxAccount.CheckBox.UncheckedValue = "N";
            this.colTaxAccount.MaxLength = 20;
            this.colTaxAccount.Name = "colTaxAccount";
            this.colTaxAccount.NamedProperties.Put("EnumerateMethod", "");
            this.colTaxAccount.NamedProperties.Put("FieldFlags", "295");
            this.colTaxAccount.NamedProperties.Put("LovReference", "");
            this.colTaxAccount.NamedProperties.Put("ResizeableChildObject", "");
            this.colTaxAccount.NamedProperties.Put("SqlColumn", "TAX_FLAG_DB");
            this.colTaxAccount.NamedProperties.Put("ValidateMethod", "");
            this.colTaxAccount.Position = 18;
            resources.ApplyResources(this.colTaxAccount, "colTaxAccount");
            this.colTaxAccount.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colTaxAccount_WindowActions);
            // 
            // colsStatAccount
            // 
            this.colsStatAccount.CheckBox.CheckedValue = "Y";
            this.colsStatAccount.CheckBox.IgnoreCase = true;
            this.colsStatAccount.CheckBox.UncheckedValue = "N";
            this.colsStatAccount.MaxLength = 200;
            this.colsStatAccount.Name = "colsStatAccount";
            this.colsStatAccount.NamedProperties.Put("EnumerateMethod", "");
            this.colsStatAccount.NamedProperties.Put("FieldFlags", "295");
            this.colsStatAccount.NamedProperties.Put("LovReference", "");
            this.colsStatAccount.NamedProperties.Put("ResizeableChildObject", "");
            this.colsStatAccount.NamedProperties.Put("SqlColumn", "STAT_ACCOUNT_DB");
            this.colsStatAccount.NamedProperties.Put("ValidateMethod", "");
            this.colsStatAccount.Position = 19;
            resources.ApplyResources(this.colsStatAccount, "colsStatAccount");
            this.colsStatAccount.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsStatAccount_WindowActions);
            // 
            // colsExcludeProjFollowup
            // 
            this.colsExcludeProjFollowup.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsExcludeProjFollowup.MaxLength = 5;
            this.colsExcludeProjFollowup.Name = "colsExcludeProjFollowup";
            this.colsExcludeProjFollowup.NamedProperties.Put("EnumerateMethod", "");
            this.colsExcludeProjFollowup.NamedProperties.Put("FieldFlags", "294");
            this.colsExcludeProjFollowup.NamedProperties.Put("LovReference", "");
            this.colsExcludeProjFollowup.NamedProperties.Put("SqlColumn", "EXCLUDE_PROJ_FOLLOWUP");
            this.colsExcludeProjFollowup.Position = 21;
            resources.ApplyResources(this.colsExcludeProjFollowup, "colsExcludeProjFollowup");
            this.colsExcludeProjFollowup.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsExcludeProjFollowup_WindowActions);
            // 
            // colsArchivingTrans
            // 
            this.colsArchivingTrans.Name = "colsArchivingTrans";
            this.colsArchivingTrans.NamedProperties.Put("EnumerateMethod", "ARCHIVING_TRANS_VALUE_API.Enumerate");
            this.colsArchivingTrans.NamedProperties.Put("FieldFlags", "295");
            this.colsArchivingTrans.NamedProperties.Put("LovReference", "");
            this.colsArchivingTrans.NamedProperties.Put("ResizeableChildObject", "");
            this.colsArchivingTrans.NamedProperties.Put("SqlColumn", "ARCHIVING_TRANS_VALUE");
            this.colsArchivingTrans.NamedProperties.Put("ValidateMethod", "");
            this.colsArchivingTrans.Position = 22;
            resources.ApplyResources(this.colsArchivingTrans, "colsArchivingTrans");
            // 
            // colsReqAccntB
            // 
            this.colsReqAccntB.MaxLength = 20;
            this.colsReqAccntB.Name = "colsReqAccntB";
            this.colsReqAccntB.NamedProperties.Put("EnumerateMethod", "ACCOUNT_REQUEST_API.Enumerate");
            this.colsReqAccntB.NamedProperties.Put("FieldFlags", "295");
            this.colsReqAccntB.NamedProperties.Put("LovReference", "");
            this.colsReqAccntB.NamedProperties.Put("ResizeableChildObject", "");
            this.colsReqAccntB.NamedProperties.Put("SqlColumn", "REQ_CODE_B");
            this.colsReqAccntB.NamedProperties.Put("ValidateMethod", "");
            this.colsReqAccntB.Position = 23;
            resources.ApplyResources(this.colsReqAccntB, "colsReqAccntB");
            // 
            // colsReqAccntC
            // 
            this.colsReqAccntC.MaxLength = 20;
            this.colsReqAccntC.Name = "colsReqAccntC";
            this.colsReqAccntC.NamedProperties.Put("EnumerateMethod", "ACCOUNT_REQUEST_API.Enumerate");
            this.colsReqAccntC.NamedProperties.Put("FieldFlags", "295");
            this.colsReqAccntC.NamedProperties.Put("LovReference", "");
            this.colsReqAccntC.NamedProperties.Put("ResizeableChildObject", "");
            this.colsReqAccntC.NamedProperties.Put("SqlColumn", "REQ_CODE_C");
            this.colsReqAccntC.NamedProperties.Put("ValidateMethod", "");
            this.colsReqAccntC.Position = 24;
            resources.ApplyResources(this.colsReqAccntC, "colsReqAccntC");
            // 
            // colsReqAccntD
            // 
            this.colsReqAccntD.MaxLength = 20;
            this.colsReqAccntD.Name = "colsReqAccntD";
            this.colsReqAccntD.NamedProperties.Put("EnumerateMethod", "ACCOUNT_REQUEST_API.Enumerate");
            this.colsReqAccntD.NamedProperties.Put("FieldFlags", "295");
            this.colsReqAccntD.NamedProperties.Put("LovReference", "");
            this.colsReqAccntD.NamedProperties.Put("ResizeableChildObject", "");
            this.colsReqAccntD.NamedProperties.Put("SqlColumn", "REQ_CODE_D");
            this.colsReqAccntD.NamedProperties.Put("ValidateMethod", "");
            this.colsReqAccntD.Position = 25;
            resources.ApplyResources(this.colsReqAccntD, "colsReqAccntD");
            // 
            // colsReqAccntE
            // 
            this.colsReqAccntE.MaxLength = 20;
            this.colsReqAccntE.Name = "colsReqAccntE";
            this.colsReqAccntE.NamedProperties.Put("EnumerateMethod", "ACCOUNT_REQUEST_API.Enumerate");
            this.colsReqAccntE.NamedProperties.Put("FieldFlags", "295");
            this.colsReqAccntE.NamedProperties.Put("LovReference", "");
            this.colsReqAccntE.NamedProperties.Put("ResizeableChildObject", "");
            this.colsReqAccntE.NamedProperties.Put("SqlColumn", "REQ_CODE_E");
            this.colsReqAccntE.NamedProperties.Put("ValidateMethod", "");
            this.colsReqAccntE.Position = 26;
            resources.ApplyResources(this.colsReqAccntE, "colsReqAccntE");
            // 
            // colsReqAccntF
            // 
            this.colsReqAccntF.MaxLength = 20;
            this.colsReqAccntF.Name = "colsReqAccntF";
            this.colsReqAccntF.NamedProperties.Put("EnumerateMethod", "ACCOUNT_REQUEST_API.Enumerate");
            this.colsReqAccntF.NamedProperties.Put("FieldFlags", "295");
            this.colsReqAccntF.NamedProperties.Put("LovReference", "");
            this.colsReqAccntF.NamedProperties.Put("ResizeableChildObject", "");
            this.colsReqAccntF.NamedProperties.Put("SqlColumn", "REQ_CODE_F");
            this.colsReqAccntF.NamedProperties.Put("ValidateMethod", "");
            this.colsReqAccntF.Position = 27;
            resources.ApplyResources(this.colsReqAccntF, "colsReqAccntF");
            // 
            // colsReqAccntG
            // 
            this.colsReqAccntG.MaxLength = 20;
            this.colsReqAccntG.Name = "colsReqAccntG";
            this.colsReqAccntG.NamedProperties.Put("EnumerateMethod", "ACCOUNT_REQUEST_API.Enumerate");
            this.colsReqAccntG.NamedProperties.Put("FieldFlags", "295");
            this.colsReqAccntG.NamedProperties.Put("LovReference", "");
            this.colsReqAccntG.NamedProperties.Put("ResizeableChildObject", "");
            this.colsReqAccntG.NamedProperties.Put("SqlColumn", "REQ_CODE_G");
            this.colsReqAccntG.NamedProperties.Put("ValidateMethod", "");
            this.colsReqAccntG.Position = 28;
            resources.ApplyResources(this.colsReqAccntG, "colsReqAccntG");
            // 
            // colsReqAccntH
            // 
            this.colsReqAccntH.MaxLength = 20;
            this.colsReqAccntH.Name = "colsReqAccntH";
            this.colsReqAccntH.NamedProperties.Put("EnumerateMethod", "ACCOUNT_REQUEST_API.Enumerate");
            this.colsReqAccntH.NamedProperties.Put("FieldFlags", "295");
            this.colsReqAccntH.NamedProperties.Put("LovReference", "");
            this.colsReqAccntH.NamedProperties.Put("ResizeableChildObject", "");
            this.colsReqAccntH.NamedProperties.Put("SqlColumn", "REQ_CODE_H");
            this.colsReqAccntH.NamedProperties.Put("ValidateMethod", "");
            this.colsReqAccntH.Position = 29;
            resources.ApplyResources(this.colsReqAccntH, "colsReqAccntH");
            // 
            // colsReqAccntI
            // 
            this.colsReqAccntI.MaxLength = 20;
            this.colsReqAccntI.Name = "colsReqAccntI";
            this.colsReqAccntI.NamedProperties.Put("EnumerateMethod", "ACCOUNT_REQUEST_API.Enumerate");
            this.colsReqAccntI.NamedProperties.Put("FieldFlags", "295");
            this.colsReqAccntI.NamedProperties.Put("LovReference", "");
            this.colsReqAccntI.NamedProperties.Put("ResizeableChildObject", "");
            this.colsReqAccntI.NamedProperties.Put("SqlColumn", "REQ_CODE_I");
            this.colsReqAccntI.NamedProperties.Put("ValidateMethod", "");
            this.colsReqAccntI.Position = 30;
            resources.ApplyResources(this.colsReqAccntI, "colsReqAccntI");
            // 
            // colsReqAccntJ
            // 
            this.colsReqAccntJ.MaxLength = 20;
            this.colsReqAccntJ.Name = "colsReqAccntJ";
            this.colsReqAccntJ.NamedProperties.Put("EnumerateMethod", "ACCOUNT_REQUEST_API.Enumerate");
            this.colsReqAccntJ.NamedProperties.Put("FieldFlags", "295");
            this.colsReqAccntJ.NamedProperties.Put("LovReference", "");
            this.colsReqAccntJ.NamedProperties.Put("ResizeableChildObject", "");
            this.colsReqAccntJ.NamedProperties.Put("SqlColumn", "REQ_CODE_J");
            this.colsReqAccntJ.NamedProperties.Put("ValidateMethod", "");
            this.colsReqAccntJ.Position = 31;
            resources.ApplyResources(this.colsReqAccntJ, "colsReqAccntJ");
            // 
            // colsReqQuantity
            // 
            this.colsReqQuantity.MaxLength = 200;
            this.colsReqQuantity.Name = "colsReqQuantity";
            this.colsReqQuantity.NamedProperties.Put("EnumerateMethod", "ACCOUNT_REQUEST_API.Enumerate");
            this.colsReqQuantity.NamedProperties.Put("FieldFlags", "295");
            this.colsReqQuantity.NamedProperties.Put("LovReference", "");
            this.colsReqQuantity.NamedProperties.Put("ResizeableChildObject", "");
            this.colsReqQuantity.NamedProperties.Put("SqlColumn", "REQ_QUANTITY");
            this.colsReqQuantity.NamedProperties.Put("ValidateMethod", "");
            this.colsReqQuantity.Position = 32;
            resources.ApplyResources(this.colsReqQuantity, "colsReqQuantity");
            // 
            // colsProcessCode
            // 
            this.colsProcessCode.MaxLength = 20;
            this.colsProcessCode.Name = "colsProcessCode";
            this.colsProcessCode.NamedProperties.Put("EnumerateMethod", "ACCOUNT_REQUEST_API.Enumerate");
            this.colsProcessCode.NamedProperties.Put("FieldFlags", "295");
            this.colsProcessCode.NamedProperties.Put("LovReference", "");
            this.colsProcessCode.NamedProperties.Put("ResizeableChildObject", "");
            this.colsProcessCode.NamedProperties.Put("SqlColumn", "REQ_PROCESS_CODE");
            this.colsProcessCode.NamedProperties.Put("ValidateMethod", "");
            this.colsProcessCode.Position = 33;
            resources.ApplyResources(this.colsProcessCode, "colsProcessCode");
            // 
            // colsReqText
            // 
            this.colsReqText.MaxLength = 20;
            this.colsReqText.Name = "colsReqText";
            this.colsReqText.NamedProperties.Put("EnumerateMethod", "Account_Request_Text_API.Enumerate");
            this.colsReqText.NamedProperties.Put("FieldFlags", "295");
            this.colsReqText.NamedProperties.Put("LovReference", "");
            this.colsReqText.NamedProperties.Put("ResizeableChildObject", "");
            this.colsReqText.NamedProperties.Put("SqlColumn", "REQ_TEXT");
            this.colsReqText.NamedProperties.Put("ValidateMethod", "");
            this.colsReqText.Position = 34;
            resources.ApplyResources(this.colsReqText, "colsReqText");
            // 
            // colsCBCodeString
            // 
            this.colsCBCodeString.CheckBox.CheckedValue = "T";
            this.colsCBCodeString.CheckBox.IgnoreCase = true;
            this.colsCBCodeString.CheckBox.UncheckedValue = "F";
            this.colsCBCodeString.MaxLength = 1;
            this.colsCBCodeString.Name = "colsCBCodeString";
            this.colsCBCodeString.NamedProperties.Put("EnumerateMethod", "");
            this.colsCBCodeString.NamedProperties.Put("FieldFlags", "288");
            this.colsCBCodeString.NamedProperties.Put("LovReference", "");
            this.colsCBCodeString.NamedProperties.Put("ResizeableChildObject", "");
            this.colsCBCodeString.NamedProperties.Put("SqlColumn", "ACCOUNTING_CODESTR_COMPL_API.Connect_To_Account(COMPANY,\'A\',ACCOUNT)");
            this.colsCBCodeString.NamedProperties.Put("ValidateMethod", "");
            this.colsCBCodeString.Position = 35;
            resources.ApplyResources(this.colsCBCodeString, "colsCBCodeString");
            // 
            // colsCBAttribute
            // 
            this.colsCBAttribute.CheckBox.CheckedValue = "T";
            this.colsCBAttribute.CheckBox.IgnoreCase = true;
            this.colsCBAttribute.CheckBox.UncheckedValue = "F";
            this.colsCBAttribute.MaxLength = 1;
            this.colsCBAttribute.Name = "colsCBAttribute";
            this.colsCBAttribute.NamedProperties.Put("EnumerateMethod", "");
            this.colsCBAttribute.NamedProperties.Put("FieldFlags", "288");
            this.colsCBAttribute.NamedProperties.Put("LovReference", "");
            this.colsCBAttribute.NamedProperties.Put("ResizeableChildObject", "");
            this.colsCBAttribute.NamedProperties.Put("SqlColumn", "ACCOUNTING_ATTRIBUTE_CON_API.Connect_To_Attribute(COMPANY,\'A\',ACCOUNT)");
            this.colsCBAttribute.NamedProperties.Put("ValidateMethod", "");
            this.colsCBAttribute.Position = 36;
            resources.ApplyResources(this.colsCBAttribute, "colsCBAttribute");
            this.colsCBAttribute.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsCBAttribute_WindowActions);
            // 
            // colsCBText
            // 
            this.colsCBText.CheckBox.CheckedValue = "T";
            this.colsCBText.CheckBox.IgnoreCase = true;
            this.colsCBText.CheckBox.UncheckedValue = "F";
            this.colsCBText.Name = "colsCBText";
            this.colsCBText.NamedProperties.Put("EnumerateMethod", "");
            this.colsCBText.NamedProperties.Put("FieldFlags", "800");
            this.colsCBText.NamedProperties.Put("LovReference", "");
            this.colsCBText.NamedProperties.Put("SqlColumn", "CB_TEXT");
            this.colsCBText.Position = 37;
            resources.ApplyResources(this.colsCBText, "colsCBText");
            this.colsCBText.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsCBText_WindowActions);
            // 
            // colsText
            // 
            resources.ApplyResources(this.colsText, "colsText");
            this.colsText.MaxLength = 2000;
            this.colsText.Name = "colsText";
            this.colsText.NamedProperties.Put("EnumerateMethod", "");
            this.colsText.NamedProperties.Put("FieldFlags", "262");
            this.colsText.NamedProperties.Put("LovReference", "");
            this.colsText.NamedProperties.Put("SqlColumn", "TEXT");
            this.colsText.Position = 38;
            this.colsText.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsText_WindowActions);
            // 
            // colsReqBudgetCodeB
            // 
            this.colsReqBudgetCodeB.MaxLength = 200;
            this.colsReqBudgetCodeB.Name = "colsReqBudgetCodeB";
            this.colsReqBudgetCodeB.NamedProperties.Put("EnumerateMethod", "ACCOUNT_REQUEST_API.Enumerate");
            this.colsReqBudgetCodeB.NamedProperties.Put("FieldFlags", "295");
            this.colsReqBudgetCodeB.NamedProperties.Put("LovReference", "");
            this.colsReqBudgetCodeB.NamedProperties.Put("ResizeableChildObject", "");
            this.colsReqBudgetCodeB.NamedProperties.Put("SqlColumn", "REQ_BUDGET_CODE_B");
            this.colsReqBudgetCodeB.NamedProperties.Put("ValidateMethod", "");
            this.colsReqBudgetCodeB.Position = 39;
            resources.ApplyResources(this.colsReqBudgetCodeB, "colsReqBudgetCodeB");
            // 
            // colsReqBudgetCodeC
            // 
            this.colsReqBudgetCodeC.MaxLength = 200;
            this.colsReqBudgetCodeC.Name = "colsReqBudgetCodeC";
            this.colsReqBudgetCodeC.NamedProperties.Put("EnumerateMethod", "ACCOUNT_REQUEST_API.Enumerate");
            this.colsReqBudgetCodeC.NamedProperties.Put("FieldFlags", "295");
            this.colsReqBudgetCodeC.NamedProperties.Put("LovReference", "");
            this.colsReqBudgetCodeC.NamedProperties.Put("ResizeableChildObject", "");
            this.colsReqBudgetCodeC.NamedProperties.Put("SqlColumn", "REQ_BUDGET_CODE_C");
            this.colsReqBudgetCodeC.NamedProperties.Put("ValidateMethod", "");
            this.colsReqBudgetCodeC.Position = 40;
            resources.ApplyResources(this.colsReqBudgetCodeC, "colsReqBudgetCodeC");
            // 
            // colsReqBudgetCodeD
            // 
            this.colsReqBudgetCodeD.MaxLength = 200;
            this.colsReqBudgetCodeD.Name = "colsReqBudgetCodeD";
            this.colsReqBudgetCodeD.NamedProperties.Put("EnumerateMethod", "ACCOUNT_REQUEST_API.Enumerate");
            this.colsReqBudgetCodeD.NamedProperties.Put("FieldFlags", "295");
            this.colsReqBudgetCodeD.NamedProperties.Put("LovReference", "");
            this.colsReqBudgetCodeD.NamedProperties.Put("ResizeableChildObject", "");
            this.colsReqBudgetCodeD.NamedProperties.Put("SqlColumn", "REQ_BUDGET_CODE_D");
            this.colsReqBudgetCodeD.NamedProperties.Put("ValidateMethod", "");
            this.colsReqBudgetCodeD.Position = 41;
            resources.ApplyResources(this.colsReqBudgetCodeD, "colsReqBudgetCodeD");
            // 
            // colsReqBudgetCodeE
            // 
            this.colsReqBudgetCodeE.MaxLength = 200;
            this.colsReqBudgetCodeE.Name = "colsReqBudgetCodeE";
            this.colsReqBudgetCodeE.NamedProperties.Put("EnumerateMethod", "ACCOUNT_REQUEST_API.Enumerate");
            this.colsReqBudgetCodeE.NamedProperties.Put("FieldFlags", "295");
            this.colsReqBudgetCodeE.NamedProperties.Put("LovReference", "");
            this.colsReqBudgetCodeE.NamedProperties.Put("ResizeableChildObject", "");
            this.colsReqBudgetCodeE.NamedProperties.Put("SqlColumn", "REQ_BUDGET_CODE_E");
            this.colsReqBudgetCodeE.NamedProperties.Put("ValidateMethod", "");
            this.colsReqBudgetCodeE.Position = 42;
            resources.ApplyResources(this.colsReqBudgetCodeE, "colsReqBudgetCodeE");
            // 
            // colsReqBudgetCodeF
            // 
            this.colsReqBudgetCodeF.MaxLength = 200;
            this.colsReqBudgetCodeF.Name = "colsReqBudgetCodeF";
            this.colsReqBudgetCodeF.NamedProperties.Put("EnumerateMethod", "ACCOUNT_REQUEST_API.Enumerate");
            this.colsReqBudgetCodeF.NamedProperties.Put("FieldFlags", "295");
            this.colsReqBudgetCodeF.NamedProperties.Put("LovReference", "");
            this.colsReqBudgetCodeF.NamedProperties.Put("ResizeableChildObject", "");
            this.colsReqBudgetCodeF.NamedProperties.Put("SqlColumn", "REQ_BUDGET_CODE_F");
            this.colsReqBudgetCodeF.NamedProperties.Put("ValidateMethod", "");
            this.colsReqBudgetCodeF.Position = 43;
            resources.ApplyResources(this.colsReqBudgetCodeF, "colsReqBudgetCodeF");
            // 
            // colsReqBudgetCodeG
            // 
            this.colsReqBudgetCodeG.MaxLength = 200;
            this.colsReqBudgetCodeG.Name = "colsReqBudgetCodeG";
            this.colsReqBudgetCodeG.NamedProperties.Put("EnumerateMethod", "ACCOUNT_REQUEST_API.Enumerate");
            this.colsReqBudgetCodeG.NamedProperties.Put("FieldFlags", "295");
            this.colsReqBudgetCodeG.NamedProperties.Put("LovReference", "");
            this.colsReqBudgetCodeG.NamedProperties.Put("ResizeableChildObject", "");
            this.colsReqBudgetCodeG.NamedProperties.Put("SqlColumn", "REQ_BUDGET_CODE_G");
            this.colsReqBudgetCodeG.NamedProperties.Put("ValidateMethod", "");
            this.colsReqBudgetCodeG.Position = 44;
            resources.ApplyResources(this.colsReqBudgetCodeG, "colsReqBudgetCodeG");
            // 
            // colsReqBudgetCodeH
            // 
            this.colsReqBudgetCodeH.MaxLength = 200;
            this.colsReqBudgetCodeH.Name = "colsReqBudgetCodeH";
            this.colsReqBudgetCodeH.NamedProperties.Put("EnumerateMethod", "ACCOUNT_REQUEST_API.Enumerate");
            this.colsReqBudgetCodeH.NamedProperties.Put("FieldFlags", "295");
            this.colsReqBudgetCodeH.NamedProperties.Put("LovReference", "");
            this.colsReqBudgetCodeH.NamedProperties.Put("ResizeableChildObject", "");
            this.colsReqBudgetCodeH.NamedProperties.Put("SqlColumn", "REQ_BUDGET_CODE_H");
            this.colsReqBudgetCodeH.NamedProperties.Put("ValidateMethod", "");
            this.colsReqBudgetCodeH.Position = 45;
            resources.ApplyResources(this.colsReqBudgetCodeH, "colsReqBudgetCodeH");
            // 
            // colsReqBudgetCodeI
            // 
            this.colsReqBudgetCodeI.MaxLength = 200;
            this.colsReqBudgetCodeI.Name = "colsReqBudgetCodeI";
            this.colsReqBudgetCodeI.NamedProperties.Put("EnumerateMethod", "ACCOUNT_REQUEST_API.Enumerate");
            this.colsReqBudgetCodeI.NamedProperties.Put("FieldFlags", "295");
            this.colsReqBudgetCodeI.NamedProperties.Put("LovReference", "");
            this.colsReqBudgetCodeI.NamedProperties.Put("ResizeableChildObject", "");
            this.colsReqBudgetCodeI.NamedProperties.Put("SqlColumn", "REQ_BUDGET_CODE_I");
            this.colsReqBudgetCodeI.NamedProperties.Put("ValidateMethod", "");
            this.colsReqBudgetCodeI.Position = 46;
            resources.ApplyResources(this.colsReqBudgetCodeI, "colsReqBudgetCodeI");
            // 
            // colsReqBudgetCodeJ
            // 
            this.colsReqBudgetCodeJ.MaxLength = 200;
            this.colsReqBudgetCodeJ.Name = "colsReqBudgetCodeJ";
            this.colsReqBudgetCodeJ.NamedProperties.Put("EnumerateMethod", "ACCOUNT_REQUEST_API.Enumerate");
            this.colsReqBudgetCodeJ.NamedProperties.Put("FieldFlags", "295");
            this.colsReqBudgetCodeJ.NamedProperties.Put("LovReference", "");
            this.colsReqBudgetCodeJ.NamedProperties.Put("ResizeableChildObject", "");
            this.colsReqBudgetCodeJ.NamedProperties.Put("SqlColumn", "REQ_BUDGET_CODE_J");
            this.colsReqBudgetCodeJ.NamedProperties.Put("ValidateMethod", "");
            this.colsReqBudgetCodeJ.Position = 47;
            resources.ApplyResources(this.colsReqBudgetCodeJ, "colsReqBudgetCodeJ");
            // 
            // colsReqBudgetQuantity
            // 
            this.colsReqBudgetQuantity.MaxLength = 200;
            this.colsReqBudgetQuantity.Name = "colsReqBudgetQuantity";
            this.colsReqBudgetQuantity.NamedProperties.Put("EnumerateMethod", "ACCOUNT_REQUEST_API.Enumerate");
            this.colsReqBudgetQuantity.NamedProperties.Put("FieldFlags", "295");
            this.colsReqBudgetQuantity.NamedProperties.Put("LovReference", "");
            this.colsReqBudgetQuantity.NamedProperties.Put("ResizeableChildObject", "");
            this.colsReqBudgetQuantity.NamedProperties.Put("SqlColumn", "REQ_BUDGET_QUANTITY");
            this.colsReqBudgetQuantity.NamedProperties.Put("ValidateMethod", "");
            this.colsReqBudgetQuantity.Position = 48;
            resources.ApplyResources(this.colsReqBudgetQuantity, "colsReqBudgetQuantity");
            // 
            // coldCompanyFinanceValid_From
            // 
            this.coldCompanyFinanceValid_From.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            resources.ApplyResources(this.coldCompanyFinanceValid_From, "coldCompanyFinanceValid_From");
            this.coldCompanyFinanceValid_From.Name = "coldCompanyFinanceValid_From";
            this.coldCompanyFinanceValid_From.NamedProperties.Put("EnumerateMethod", "");
            this.coldCompanyFinanceValid_From.NamedProperties.Put("FieldFlags", "288");
            this.coldCompanyFinanceValid_From.NamedProperties.Put("LovReference", "");
            this.coldCompanyFinanceValid_From.NamedProperties.Put("ResizeableChildObject", "");
            this.coldCompanyFinanceValid_From.NamedProperties.Put("SqlColumn", "COMPANY_FINANCE_API.Get_Valid_From(CONS_COMPANY)");
            this.coldCompanyFinanceValid_From.NamedProperties.Put("ValidateMethod", "");
            this.coldCompanyFinanceValid_From.Position = 49;
            // 
            // colsLogicalAccountTypeDb
            // 
            this.colsLogicalAccountTypeDb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.colsLogicalAccountTypeDb, "colsLogicalAccountTypeDb");
            this.colsLogicalAccountTypeDb.MaxLength = 2;
            this.colsLogicalAccountTypeDb.Name = "colsLogicalAccountTypeDb";
            this.colsLogicalAccountTypeDb.NamedProperties.Put("EnumerateMethod", "");
            this.colsLogicalAccountTypeDb.NamedProperties.Put("LovReference", "");
            this.colsLogicalAccountTypeDb.NamedProperties.Put("ResizeableChildObject", "");
            this.colsLogicalAccountTypeDb.NamedProperties.Put("SqlColumn", "LOGICAL_ACCOUNT_TYPE_DB");
            this.colsLogicalAccountTypeDb.NamedProperties.Put("ValidateMethod", "");
            this.colsLogicalAccountTypeDb.Position = 50;
            // 
            // colCodePart
            // 
            resources.ApplyResources(this.colCodePart, "colCodePart");
            this.colCodePart.Name = "colCodePart";
            this.colCodePart.Position = 51;
            // 
            // menuTbwMethods
            // 
            this.menuTbwMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_Code,
            this.menuSeparator1,
            this.menuItem__Account,
            this.menuItem__Tax,
            this.menuSeparator2,
            this.menuItem__Code,
            this.menuItem__Project,
            this.menuSeparator3,
            this.menuItem_Translation,
            this.menuSeparator4,
            this.menuItem__Notes,
            this.menuSeparator5,
            this.menuItem_Change});
            this.menuTbwMethods.Name = "menuTbwMethods";
            resources.ApplyResources(this.menuTbwMethods, "menuTbwMethods");
            // 
            // menuItem_Code
            // 
            this.menuItem_Code.Command = this.menuTbwMethods_menuCode__String_Completion___;
            this.menuItem_Code.Name = "menuItem_Code";
            resources.ApplyResources(this.menuItem_Code, "menuItem_Code");
            this.menuItem_Code.Text = "Code &String Completion...";
            // 
            // menuSeparator1
            // 
            this.menuSeparator1.Name = "menuSeparator1";
            resources.ApplyResources(this.menuSeparator1, "menuSeparator1");
            // 
            // menuItem__Account
            // 
            this.menuItem__Account.Command = this.menuTbwMethods_menu_Account___;
            this.menuItem__Account.Name = "menuItem__Account";
            resources.ApplyResources(this.menuItem__Account, "menuItem__Account");
            this.menuItem__Account.Text = "&Account...";
            // 
            // menuItem__Tax
            // 
            this.menuItem__Tax.Command = this.menuTbwMethods_menu_Tax_Codes_per_Account___;
            this.menuItem__Tax.Name = "menuItem__Tax";
            resources.ApplyResources(this.menuItem__Tax, "menuItem__Tax");
            this.menuItem__Tax.Text = "&Tax Codes per Account...";
            // 
            // menuSeparator2
            // 
            this.menuSeparator2.Name = "menuSeparator2";
            resources.ApplyResources(this.menuSeparator2, "menuSeparator2");
            // 
            // menuItem__Code
            // 
            this.menuItem__Code.Command = this.menuTbwMethods_menu_Code_Part_Attribute_Connection_;
            this.menuItem__Code.Name = "menuItem__Code";
            resources.ApplyResources(this.menuItem__Code, "menuItem__Code");
            this.menuItem__Code.Text = "&Code Part Attribute Connection...";
            // 
            // menuItem__Project
            // 
            this.menuItem__Project.Command = this.menuTbwMethods_menu_Project_Cost_Revenue_Element_pe;
            this.menuItem__Project.Name = "menuItem__Project";
            resources.ApplyResources(this.menuItem__Project, "menuItem__Project");
            this.menuItem__Project.Text = "&Project Cost/Revenue Element per Code Part Value...";
            // 
            // menuSeparator3
            // 
            this.menuSeparator3.Name = "menuSeparator3";
            resources.ApplyResources(this.menuSeparator3, "menuSeparator3");
            // 
            // menuItem_Translation
            // 
            this.menuItem_Translation.Command = this.menuTbwMethods_menuTrans_lation___;
            this.menuItem_Translation.Name = "menuItem_Translation";
            resources.ApplyResources(this.menuItem_Translation, "menuItem_Translation");
            this.menuItem_Translation.Text = "Trans&lation...";
            // 
            // menuSeparator4
            // 
            this.menuSeparator4.Name = "menuSeparator4";
            resources.ApplyResources(this.menuSeparator4, "menuSeparator4");
            // 
            // menuItem__Notes
            // 
            this.menuItem__Notes.Command = this.menuTbwMethods_menu_Notes___;
            this.menuItem__Notes.Name = "menuItem__Notes";
            resources.ApplyResources(this.menuItem__Notes, "menuItem__Notes");
            this.menuItem__Notes.Text = "&Notes...";
            // 
            // menuSeparator5
            // 
            this.menuSeparator5.Name = "menuSeparator5";
            resources.ApplyResources(this.menuSeparator5, "menuSeparator5");
            // 
            // menuItem_Change
            // 
            this.menuItem_Change.Command = this.menuTbwMethods_menuChange__Company___;
            this.menuItem_Change.Name = "menuItem_Change";
            resources.ApplyResources(this.menuItem_Change, "menuItem_Change");
            this.menuItem_Change.Text = "Change &Company...";
            // 
            // colsExcludePeriodicalCap
            // 
            this.colsExcludePeriodicalCap.MaxLength = 200;
            this.colsExcludePeriodicalCap.Name = "colsExcludePeriodicalCap";
            this.colsExcludePeriodicalCap.NamedProperties.Put("EnumerateMethod", "EXCLUDE_PERIODICAL_CAP_API.Enumerate");
            this.colsExcludePeriodicalCap.NamedProperties.Put("FieldFlags", "294");
            this.colsExcludePeriodicalCap.NamedProperties.Put("SqlColumn", "EXCLUDE_PERIODICAL_CAP");
            this.colsExcludePeriodicalCap.Position = 20;
            resources.ApplyResources(this.colsExcludePeriodicalCap, "colsExcludePeriodicalCap");
            this.colsExcludePeriodicalCap.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsExcludePeriodicalCap_WindowActions);
            // 
            // colsConsAccnt
            // 
            this.colsConsAccnt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsConsAccnt.MaxLength = 20;
            this.colsConsAccnt.Name = "colsConsAccnt";
            this.colsConsAccnt.NamedProperties.Put("EnumerateMethod", "");
            this.colsConsAccnt.NamedProperties.Put("FieldFlags", "294");
            this.colsConsAccnt.NamedProperties.Put("LovReference", "ACCOUNT(CONS_COMPANY)");
            this.colsConsAccnt.NamedProperties.Put("SqlColumn", "CONS_ACCNT");
            this.colsConsAccnt.Position = 52;
            resources.ApplyResources(this.colsConsAccnt, "colsConsAccnt");
            this.colsConsAccnt.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsConsAccnt_WindowActions);
            // 
            // colsConsCompany
            // 
            this.colsConsCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.colsConsCompany, "colsConsCompany");
            this.colsConsCompany.MaxLength = 20;
            this.colsConsCompany.Name = "colsConsCompany";
            this.colsConsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.colsConsCompany.NamedProperties.Put("LovReference", "COMPANY_FINANCE");
            this.colsConsCompany.NamedProperties.Put("SqlColumn", "CONS_COMPANY");
            this.colsConsCompany.Position = 54;
            // 
            // colsConsolidAccountDescription
            // 
            this.colsConsolidAccountDescription.MaxLength = 2000;
            this.colsConsolidAccountDescription.Name = "colsConsolidAccountDescription";
            this.colsConsolidAccountDescription.NamedProperties.Put("EnumerateMethod", "");
            this.colsConsolidAccountDescription.NamedProperties.Put("FieldFlags", "288");
            this.colsConsolidAccountDescription.NamedProperties.Put("LovReference", "");
            this.colsConsolidAccountDescription.NamedProperties.Put("ParentName", "colsConsAccnt");
            this.colsConsolidAccountDescription.NamedProperties.Put("SqlColumn", "Accounting_Code_Part_A_API.Get_Description(CONS_COMPANY,CONS_ACCNT)");
            this.colsConsolidAccountDescription.Position = 53;
            resources.ApplyResources(this.colsConsolidAccountDescription, "colsConsolidAccountDescription");
            // 
            // colsExcludeCurrTrans
            // 
            this.colsExcludeCurrTrans.CheckBox.CheckedValue = "Y";
            this.colsExcludeCurrTrans.CheckBox.IgnoreCase = true;
            this.colsExcludeCurrTrans.CheckBox.UncheckedValue = "N";
            this.colsExcludeCurrTrans.MaxLength = 20;
            this.colsExcludeCurrTrans.Name = "colsExcludeCurrTrans";
            this.colsExcludeCurrTrans.NamedProperties.Put("EnumerateMethod", "");
            this.colsExcludeCurrTrans.NamedProperties.Put("FieldFlags", "288");
            this.colsExcludeCurrTrans.NamedProperties.Put("LovReference", "");
            this.colsExcludeCurrTrans.NamedProperties.Put("ResizeableChildObject", "");
            this.colsExcludeCurrTrans.NamedProperties.Put("SqlColumn", "EXCLUDE_FROM_CURR_TRANS_DB");
            this.colsExcludeCurrTrans.NamedProperties.Put("ValidateMethod", "");
            this.colsExcludeCurrTrans.Position = 55;
            resources.ApplyResources(this.colsExcludeCurrTrans, "colsExcludeCurrTrans");
            // 
            // colsKeepRepCurrency
            // 
            this.colsKeepRepCurrency.MaxLength = 20;
            this.colsKeepRepCurrency.Name = "colsKeepRepCurrency";
            this.colsKeepRepCurrency.NamedProperties.Put("EnumerateMethod", "");
            this.colsKeepRepCurrency.NamedProperties.Put("FieldFlags", "294");
            this.colsKeepRepCurrency.NamedProperties.Put("LovReference", "");
            this.colsKeepRepCurrency.NamedProperties.Put("SqlColumn", "KEEP_REP_CURRENCY_DB");
            this.colsKeepRepCurrency.Position = 56;
            resources.ApplyResources(this.colsKeepRepCurrency, "colsKeepRepCurrency");
            this.colsKeepRepCurrency.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tableWindow_colsKeepRepCurrency_WindowActions);
            // 
            // colsKeepReportingEntity
            // 
            this.colsKeepReportingEntity.MaxLength = 20;
            this.colsKeepReportingEntity.Name = "colsKeepReportingEntity";
            this.colsKeepReportingEntity.NamedProperties.Put("EnumerateMethod", "");
            this.colsKeepReportingEntity.NamedProperties.Put("FieldFlags", "294");
            this.colsKeepReportingEntity.NamedProperties.Put("LovReference", "");
            this.colsKeepReportingEntity.NamedProperties.Put("SqlColumn", "KEEP_REPORTING_ENTITY_DB");
            this.colsKeepReportingEntity.Position = 57;
            resources.ApplyResources(this.colsKeepReportingEntity, "colsKeepReportingEntity");
            this.colsKeepReportingEntity.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tableWindow_colsKeepReportingEntity_WindowActions);
            // 
            // tbwAccountOverview
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colsCompany);
            this.Controls.Add(this.colsAccount);
            this.Controls.Add(this.colsAccountDescription);
            this.Controls.Add(this.colsAccountType);
            this.Controls.Add(this.colsAccountTypeDescription);
            this.Controls.Add(this.colsAccountGroup);
            this.Controls.Add(this.colsAccountGroupDescription);
            this.Controls.Add(this.colsTaxHandlingValue);
            this.Controls.Add(this.colsPrevTaxHandlingValue);
            this.Controls.Add(this.colsTaxCodeMandatory);
            this.Controls.Add(this.coldtValidFrom);
            this.Controls.Add(this.coldtValiduntil);
            this.Controls.Add(this.colCurrencyBalance);
            this.Controls.Add(this.colBudgetAccount);
            this.Controls.Add(this.colLedgerAccount);
            this.Controls.Add(this.colTaxAccount);
            this.Controls.Add(this.colsStatAccount);
            this.Controls.Add(this.colsExcludePeriodicalCap);
            this.Controls.Add(this.colsExcludeProjFollowup);
            this.Controls.Add(this.colsArchivingTrans);
            this.Controls.Add(this.colsReqAccntB);
            this.Controls.Add(this.colsReqAccntC);
            this.Controls.Add(this.colsReqAccntD);
            this.Controls.Add(this.colsReqAccntE);
            this.Controls.Add(this.colsReqAccntF);
            this.Controls.Add(this.colsReqAccntG);
            this.Controls.Add(this.colsReqAccntH);
            this.Controls.Add(this.colsReqAccntI);
            this.Controls.Add(this.colsReqAccntJ);
            this.Controls.Add(this.colsReqQuantity);
            this.Controls.Add(this.colsProcessCode);
            this.Controls.Add(this.colsReqText);
            this.Controls.Add(this.colsCBCodeString);
            this.Controls.Add(this.colsCBAttribute);
            this.Controls.Add(this.colsCBText);
            this.Controls.Add(this.colsText);
            this.Controls.Add(this.colsReqBudgetCodeB);
            this.Controls.Add(this.colsReqBudgetCodeC);
            this.Controls.Add(this.colsReqBudgetCodeD);
            this.Controls.Add(this.colsReqBudgetCodeE);
            this.Controls.Add(this.colsReqBudgetCodeF);
            this.Controls.Add(this.colsReqBudgetCodeG);
            this.Controls.Add(this.colsReqBudgetCodeH);
            this.Controls.Add(this.colsReqBudgetCodeI);
            this.Controls.Add(this.colsReqBudgetCodeJ);
            this.Controls.Add(this.colsReqBudgetQuantity);
            this.Controls.Add(this.coldCompanyFinanceValid_From);
            this.Controls.Add(this.colsLogicalAccountTypeDb);
            this.Controls.Add(this.colCodePart);
            this.Controls.Add(this.colsConsAccnt);
            this.Controls.Add(this.colsConsolidAccountDescription);
            this.Controls.Add(this.colsConsCompany);
            this.Controls.Add(this.colsExcludeCurrTrans);
            this.Controls.Add(this.colsKeepRepCurrency);
            this.Controls.Add(this.colsKeepReportingEntity);
            this.Name = "tbwAccountOverview";
            this.NamedProperties.Put("DefaultOrderBy", "SORT_VALUE");
            this.NamedProperties.Put("DefaultWhere", "COMPANY= :i_hWndFrame.tbwAccountOverview.i_sCompany");
            this.NamedProperties.Put("LogicalUnit", "Account");
            this.NamedProperties.Put("PackageName", "ACCOUNT_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "0");
            this.NamedProperties.Put("ViewName", "ACCOUNT");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tbwAccountOverview_WindowActions);
            this.Controls.SetChildIndex(this.colsKeepReportingEntity, 0);
            this.Controls.SetChildIndex(this.colsKeepRepCurrency, 0);
            this.Controls.SetChildIndex(this.colsExcludeCurrTrans, 0);
            this.Controls.SetChildIndex(this.colsConsCompany, 0);
            this.Controls.SetChildIndex(this.colsConsolidAccountDescription, 0);
            this.Controls.SetChildIndex(this.colsConsAccnt, 0);
            this.Controls.SetChildIndex(this.colCodePart, 0);
            this.Controls.SetChildIndex(this.colsLogicalAccountTypeDb, 0);
            this.Controls.SetChildIndex(this.coldCompanyFinanceValid_From, 0);
            this.Controls.SetChildIndex(this.colsReqBudgetQuantity, 0);
            this.Controls.SetChildIndex(this.colsReqBudgetCodeJ, 0);
            this.Controls.SetChildIndex(this.colsReqBudgetCodeI, 0);
            this.Controls.SetChildIndex(this.colsReqBudgetCodeH, 0);
            this.Controls.SetChildIndex(this.colsReqBudgetCodeG, 0);
            this.Controls.SetChildIndex(this.colsReqBudgetCodeF, 0);
            this.Controls.SetChildIndex(this.colsReqBudgetCodeE, 0);
            this.Controls.SetChildIndex(this.colsReqBudgetCodeD, 0);
            this.Controls.SetChildIndex(this.colsReqBudgetCodeC, 0);
            this.Controls.SetChildIndex(this.colsReqBudgetCodeB, 0);
            this.Controls.SetChildIndex(this.colsText, 0);
            this.Controls.SetChildIndex(this.colsCBText, 0);
            this.Controls.SetChildIndex(this.colsCBAttribute, 0);
            this.Controls.SetChildIndex(this.colsCBCodeString, 0);
            this.Controls.SetChildIndex(this.colsReqText, 0);
            this.Controls.SetChildIndex(this.colsProcessCode, 0);
            this.Controls.SetChildIndex(this.colsReqQuantity, 0);
            this.Controls.SetChildIndex(this.colsReqAccntJ, 0);
            this.Controls.SetChildIndex(this.colsReqAccntI, 0);
            this.Controls.SetChildIndex(this.colsReqAccntH, 0);
            this.Controls.SetChildIndex(this.colsReqAccntG, 0);
            this.Controls.SetChildIndex(this.colsReqAccntF, 0);
            this.Controls.SetChildIndex(this.colsReqAccntE, 0);
            this.Controls.SetChildIndex(this.colsReqAccntD, 0);
            this.Controls.SetChildIndex(this.colsReqAccntC, 0);
            this.Controls.SetChildIndex(this.colsReqAccntB, 0);
            this.Controls.SetChildIndex(this.colsArchivingTrans, 0);
            this.Controls.SetChildIndex(this.colsExcludeProjFollowup, 0);
            this.Controls.SetChildIndex(this.colsExcludePeriodicalCap, 0);
            this.Controls.SetChildIndex(this.colsStatAccount, 0);
            this.Controls.SetChildIndex(this.colTaxAccount, 0);
            this.Controls.SetChildIndex(this.colLedgerAccount, 0);
            this.Controls.SetChildIndex(this.colBudgetAccount, 0);
            this.Controls.SetChildIndex(this.colCurrencyBalance, 0);
            this.Controls.SetChildIndex(this.coldtValiduntil, 0);
            this.Controls.SetChildIndex(this.coldtValidFrom, 0);
            this.Controls.SetChildIndex(this.colsTaxCodeMandatory, 0);
            this.Controls.SetChildIndex(this.colsPrevTaxHandlingValue, 0);
            this.Controls.SetChildIndex(this.colsTaxHandlingValue, 0);
            this.Controls.SetChildIndex(this.colsAccountGroupDescription, 0);
            this.Controls.SetChildIndex(this.colsAccountGroup, 0);
            this.Controls.SetChildIndex(this.colsAccountTypeDescription, 0);
            this.Controls.SetChildIndex(this.colsAccountType, 0);
            this.Controls.SetChildIndex(this.colsAccountDescription, 0);
            this.Controls.SetChildIndex(this.colsAccount, 0);
            this.Controls.SetChildIndex(this.colsCompany, 0);
            this.Controls.SetChildIndex(this.@__colObjversion, 0);
            this.Controls.SetChildIndex(this.@__colObjid, 0);
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

        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menuCode__String_Completion___;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menu_Account___;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menu_Tax_Codes_per_Account___;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menu_Code_Part_Attribute_Connection_;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menu_Project_Cost_Revenue_Element_pe;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menuTrans_lation___;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menu_Notes___;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menuChange__Company___;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTbwMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Code;
        protected Fnd.Windows.Forms.FndToolStripSeparator menuSeparator1;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Account;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Tax;
        protected Fnd.Windows.Forms.FndToolStripSeparator menuSeparator2;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Code;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Project;
        protected Fnd.Windows.Forms.FndToolStripSeparator menuSeparator3;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Translation;
        protected Fnd.Windows.Forms.FndToolStripSeparator menuSeparator4;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Notes;
        protected Fnd.Windows.Forms.FndToolStripSeparator menuSeparator5;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change;
        protected cLookupColumn colsExcludePeriodicalCap;
        protected cColumn colsConsAccnt;
        protected cColumn colsConsCompany;
        protected cColumn colsConsolidAccountDescription;
        public cCheckBoxColumn colsExcludeCurrTrans;
        protected cCheckBoxColumn colsKeepRepCurrency;
        protected cCheckBoxColumn colsKeepReportingEntity;
	}
}
