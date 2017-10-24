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
	
	public partial class frmTabAccount
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		// warning ==============>>> do not elimited the trailing background spaces of object with Extension Fin  ........!!!
		// Bug 81897, Begin Redesign the layout
		// ! Bug 82084 Begin Change cRecSelComboBoxFin to cRecSelExtComboBoxFin and chane the logical parent to others in dfsDescription
		protected cBackgroundText labelcmbAccount;
		// Bug 81897 Deleted Line
		public cRecSelExtComboBoxFin cmbAccount;
		protected cBackgroundText labeldfsDescription;
		public cDataFieldFin dfsDescription;
		// Bug 82084 End
		public cDataField dfsCompany;
		// Tab Basic
		protected cBackgroundText labeldfsAccountType;
		// Bug 85877, Begin, checked for the permission to edit
		public cDataFieldFin dfsAccountType;
		protected cBackgroundText labeldfsAccountTypeDescription;
		public cDataFieldFin dfsAccountTypeDescription;
		protected cBackgroundText labeldfsLogicalAccountType;
		public cDataFieldFin dfsLogicalAccountType;
		protected cBackgroundText labeldfsAccountGroup;
		public cDataFieldFin dfsAccountGroup;
		protected cBackgroundText labeldfsAccountGroupDescription;
		public cDataFieldFin dfsAccountGroupDescription;
		protected SalGroupBox gbTax_Options;
		protected cBackgroundText labelcmbTaxHandlingValue;
		public cComboBox cmbTaxHandlingValue;
		public cCheckBox cbTaxCodeMandatory;
		protected cBackgroundText labeldfdtValidFrom;
		public cDataField dfdtValidFrom;
		protected cBackgroundText labeldfdtValidUntil;
		public cDataField dfdtValidUntil;
		protected SalGroupBox gbOptions;
		public cCheckBox cbTaxAccount;
		public cCheckBox cbLedgFlag;
		public cCheckBox cbCurrBalance;
		public cCheckBox cbBudAccount;
		public cCheckBox cbStatisticalAccount;
		// free text
		public cMultilineField mlsText;
		public cCheckBox cbCodeStr;
		public cCheckBox cbAttribute;
        public cCheckBox cbFreeText;
		// Tab Code Part Demands
		// To minimize no of Db calls Enumerate methods were removed from foundation properties
		// And called it once on SAM_CreateComplete then set them on PM_LookupInit in each cComboBoxFin - Asitha
		protected cBackgroundText labelcmbCostCenter;
		public cComboBoxFin cmbCostCenter;
		protected cBackgroundText labelcmbCodeC;
		public cComboBoxFin cmbCodeC;
		protected cBackgroundText labelcmbCodeD;
		public cComboBoxFin cmbCodeD;
		protected cBackgroundText labelcmbObject;
		public cComboBoxFin cmbObject;
		protected cBackgroundText labelcmbProject;
		public cComboBoxFin cmbProject;
		protected cBackgroundText labelcmbCodeG;
		public cComboBoxFin cmbCodeG;
		protected cBackgroundText labelcmbCodeH;
		public cComboBoxFin cmbCodeH;
		protected cBackgroundText labelcmbCodeI;
		public cComboBoxFin cmbCodeI;
		protected cBackgroundText labelcmbCodeJ;
		public cComboBoxFin cmbCodeJ;
		protected cBackgroundText labelcmbQuantity;
		public cComboBoxFin cmbQuantity;
		protected cBackgroundText labelcmbReqProcessCode;
		public cComboBox cmbReqProcessCode;
		protected cBackgroundText labelcmbText;
		public cComboBox cmbText;
		// Tab Consolidation
		protected cBackgroundText labeldfsConsolidAccount;
		public cDataFieldFin dfsConsolidAccount;
		protected cBackgroundText labeldfsConsolidAccntDescription;
		public cDataFieldFin dfsConsolidAccntDescription;
		public cDataField dfConsCompany;
		// Tab Budget Code Part Demand
		protected cBackgroundText labelcmbReqBudgetCodeB;
		public cComboBoxFin cmbReqBudgetCodeB;
		protected cBackgroundText labelcmbReqBudgetCodeC;
		public cComboBoxFin cmbReqBudgetCodeC;
		protected cBackgroundText labelcmbReqBudgetCodeD;
		public cComboBoxFin cmbReqBudgetCodeD;
		protected cBackgroundText labelcmbReqBudgetCodeE;
		public cComboBoxFin cmbReqBudgetCodeE;
		protected cBackgroundText labelcmbReqBudgetCodeF;
		public cComboBoxFin cmbReqBudgetCodeF;
		protected cBackgroundText labelcmbReqBudgetCodeG;
		public cComboBoxFin cmbReqBudgetCodeG;
		protected cBackgroundText labelcmbReqBudgetCodeH;
		public cComboBoxFin cmbReqBudgetCodeH;
		protected cBackgroundText labelcmbReqBudgetCodeI;
		public cComboBoxFin cmbReqBudgetCodeI;
		protected cBackgroundText labelcmbReqBudgetCodeJ;
		public cComboBoxFin cmbReqBudgetCodeJ;
		protected cBackgroundText labelcmbReqBudgetQuantity;
		public cComboBoxFin cmbReqBudgetQuantity;
		protected SalGroupBox gbValid;
        protected SalGroupBox gbArchiving_Options;
		protected cBackgroundText labeldfNoArchiveTrans;
		public cDataField dfNoArchiveTrans;
		// Bug 65271,Begin
		public cDataField dfsCodePart;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTabAccount));
            this.menuFrmMethods_menuCode__String_Completion___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuFrmMethods_menu_Tax_Codes_per_Account___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuFrmMethods_menu_Code_Part_Attribute_Connection_ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuFrmMethods_menu_Project_Cost_Revenue_Element_pe = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuFrmMethods_menuTrans_lation___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuFrmMethods_menu_Notes___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuFrmMethods_menuChange__Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.labelcmbAccount = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbAccount = new Ifs.Application.Accrul.cRecSelExtComboBoxFin();
            this.labeldfsDescription = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsDescription = new Ifs.Application.Accrul.cDataFieldFin();
            this.dfsCompany = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsAccountType = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsAccountType = new Ifs.Application.Accrul.cDataFieldFin();
            this.labeldfsAccountTypeDescription = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsAccountTypeDescription = new Ifs.Application.Accrul.cDataFieldFin();
            this.labeldfsLogicalAccountType = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsLogicalAccountType = new Ifs.Application.Accrul.cDataFieldFin();
            this.labeldfsAccountGroup = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsAccountGroup = new Ifs.Application.Accrul.cDataFieldFin();
            this.labeldfsAccountGroupDescription = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsAccountGroupDescription = new Ifs.Application.Accrul.cDataFieldFin();
            this.gbTax_Options = new PPJ.Runtime.Windows.SalGroupBox();
            this.labelcmbTaxHandlingValue = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbTaxHandlingValue = new Ifs.Fnd.ApplicationForms.cComboBox();
            this.cbTaxCodeMandatory = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.labeldfdtValidFrom = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfdtValidFrom = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfdtValidUntil = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfdtValidUntil = new Ifs.Fnd.ApplicationForms.cDataField();
            this.gbOptions = new PPJ.Runtime.Windows.SalGroupBox();
            this.cbTaxAccount = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.cbLedgFlag = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.cbCurrBalance = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.cbBudAccount = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.cbStatisticalAccount = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.mlsText = new Ifs.Fnd.ApplicationForms.cMultilineField();
            this.cbCodeStr = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.cbAttribute = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.cbFreeText = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.labelcmbCostCenter = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbCostCenter = new Ifs.Application.Accrul.cComboBoxFin();
            this.labelcmbCodeC = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbCodeC = new Ifs.Application.Accrul.cComboBoxFin();
            this.labelcmbCodeD = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbCodeD = new Ifs.Application.Accrul.cComboBoxFin();
            this.labelcmbObject = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbObject = new Ifs.Application.Accrul.cComboBoxFin();
            this.labelcmbProject = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbProject = new Ifs.Application.Accrul.cComboBoxFin();
            this.labelcmbCodeG = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbCodeG = new Ifs.Application.Accrul.cComboBoxFin();
            this.labelcmbCodeH = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbCodeH = new Ifs.Application.Accrul.cComboBoxFin();
            this.labelcmbCodeI = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbCodeI = new Ifs.Application.Accrul.cComboBoxFin();
            this.labelcmbCodeJ = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbCodeJ = new Ifs.Application.Accrul.cComboBoxFin();
            this.labelcmbQuantity = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbQuantity = new Ifs.Application.Accrul.cComboBoxFin();
            this.labelcmbReqProcessCode = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbReqProcessCode = new Ifs.Fnd.ApplicationForms.cComboBox();
            this.labelcmbText = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbText = new Ifs.Fnd.ApplicationForms.cComboBox();
            this.labeldfsConsolidAccount = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsConsolidAccount = new Ifs.Application.Accrul.cDataFieldFin();
            this.labeldfsConsolidAccntDescription = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsConsolidAccntDescription = new Ifs.Application.Accrul.cDataFieldFin();
            this.dfConsCompany = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelcmbReqBudgetCodeB = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbReqBudgetCodeB = new Ifs.Application.Accrul.cComboBoxFin();
            this.labelcmbReqBudgetCodeC = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbReqBudgetCodeC = new Ifs.Application.Accrul.cComboBoxFin();
            this.labelcmbReqBudgetCodeD = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbReqBudgetCodeD = new Ifs.Application.Accrul.cComboBoxFin();
            this.labelcmbReqBudgetCodeE = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbReqBudgetCodeE = new Ifs.Application.Accrul.cComboBoxFin();
            this.labelcmbReqBudgetCodeF = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbReqBudgetCodeF = new Ifs.Application.Accrul.cComboBoxFin();
            this.labelcmbReqBudgetCodeG = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbReqBudgetCodeG = new Ifs.Application.Accrul.cComboBoxFin();
            this.labelcmbReqBudgetCodeH = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbReqBudgetCodeH = new Ifs.Application.Accrul.cComboBoxFin();
            this.labelcmbReqBudgetCodeI = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbReqBudgetCodeI = new Ifs.Application.Accrul.cComboBoxFin();
            this.labelcmbReqBudgetCodeJ = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbReqBudgetCodeJ = new Ifs.Application.Accrul.cComboBoxFin();
            this.labelcmbReqBudgetQuantity = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbReqBudgetQuantity = new Ifs.Application.Accrul.cComboBoxFin();
            this.gbValid = new PPJ.Runtime.Windows.SalGroupBox();
            this.gbArchiving_Options = new PPJ.Runtime.Windows.SalGroupBox();
            this.rbMatchedTrans = new Ifs.Fnd.ApplicationForms.cRadioButton();
            this.rbAllTrans = new Ifs.Fnd.ApplicationForms.cRadioButton();
            this.labeldfNoArchiveTrans = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfNoArchiveTrans = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsCodePart = new Ifs.Fnd.ApplicationForms.cDataField();
            this.menuFrmMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_Code = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem__Tax = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuSeparator1 = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.menuItem__Code = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem__Project = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuSeparator2 = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.menuItem_Translation = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuSeparator3 = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.menuItem__Notes = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuSeparator4 = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.menuItem_Change = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.gbProjects = new PPJ.Runtime.Windows.SalGroupBox();
            this.cbExcludeProjFollowup = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.cmbExcludePeriodicalCap = new Ifs.Fnd.ApplicationForms.cComboBox();
            this.labelcmbExcludePeriodicalCap = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cbExcludeCurrTrans = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.gbArchiving_Options.SuspendLayout();
            this.menuFrmMethods.SuspendLayout();
            this.gbProjects.SuspendLayout();
            this.SuspendLayout();
            // 
            // picTabs
            // 
            resources.ApplyResources(this.picTabs, "picTabs");
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuFrmMethods_menuCode__String_Completion___);
            this.commandManager.Commands.Add(this.menuFrmMethods_menu_Tax_Codes_per_Account___);
            this.commandManager.Commands.Add(this.menuFrmMethods_menu_Code_Part_Attribute_Connection_);
            this.commandManager.Commands.Add(this.menuFrmMethods_menu_Project_Cost_Revenue_Element_pe);
            this.commandManager.Commands.Add(this.menuFrmMethods_menuTrans_lation___);
            this.commandManager.Commands.Add(this.menuFrmMethods_menu_Notes___);
            this.commandManager.Commands.Add(this.menuFrmMethods_menuChange__Company___);
            this.commandManager.ContextMenus.Add(this.menuFrmMethods);
            // 
            // menuFrmMethods_menuCode__String_Completion___
            // 
            resources.ApplyResources(this.menuFrmMethods_menuCode__String_Completion___, "menuFrmMethods_menuCode__String_Completion___");
            this.menuFrmMethods_menuCode__String_Completion___.Name = "menuFrmMethods_menuCode__String_Completion___";
            this.menuFrmMethods_menuCode__String_Completion___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Code_Execute);
            this.menuFrmMethods_menuCode__String_Completion___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Code_Inquire);
            // 
            // menuFrmMethods_menu_Tax_Codes_per_Account___
            // 
            resources.ApplyResources(this.menuFrmMethods_menu_Tax_Codes_per_Account___, "menuFrmMethods_menu_Tax_Codes_per_Account___");
            this.menuFrmMethods_menu_Tax_Codes_per_Account___.Name = "menuFrmMethods_menu_Tax_Codes_per_Account___";
            this.menuFrmMethods_menu_Tax_Codes_per_Account___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Tax_Execute);
            this.menuFrmMethods_menu_Tax_Codes_per_Account___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Tax_Inquire);
            // 
            // menuFrmMethods_menu_Code_Part_Attribute_Connection_
            // 
            resources.ApplyResources(this.menuFrmMethods_menu_Code_Part_Attribute_Connection_, "menuFrmMethods_menu_Code_Part_Attribute_Connection_");
            this.menuFrmMethods_menu_Code_Part_Attribute_Connection_.Name = "menuFrmMethods_menu_Code_Part_Attribute_Connection_";
            this.menuFrmMethods_menu_Code_Part_Attribute_Connection_.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Code_Execute);
            this.menuFrmMethods_menu_Code_Part_Attribute_Connection_.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Code_Inquire);
            // 
            // menuFrmMethods_menu_Project_Cost_Revenue_Element_pe
            // 
            resources.ApplyResources(this.menuFrmMethods_menu_Project_Cost_Revenue_Element_pe, "menuFrmMethods_menu_Project_Cost_Revenue_Element_pe");
            this.menuFrmMethods_menu_Project_Cost_Revenue_Element_pe.Name = "menuFrmMethods_menu_Project_Cost_Revenue_Element_pe";
            this.menuFrmMethods_menu_Project_Cost_Revenue_Element_pe.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Project_Execute);
            this.menuFrmMethods_menu_Project_Cost_Revenue_Element_pe.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Project_Inquire);
            // 
            // menuFrmMethods_menuTrans_lation___
            // 
            resources.ApplyResources(this.menuFrmMethods_menuTrans_lation___, "menuFrmMethods_menuTrans_lation___");
            this.menuFrmMethods_menuTrans_lation___.Name = "menuFrmMethods_menuTrans_lation___";
            this.menuFrmMethods_menuTrans_lation___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Translation_Execute);
            this.menuFrmMethods_menuTrans_lation___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Translation_Inquire);
            // 
            // menuFrmMethods_menu_Notes___
            // 
            resources.ApplyResources(this.menuFrmMethods_menu_Notes___, "menuFrmMethods_menu_Notes___");
            this.menuFrmMethods_menu_Notes___.Name = "menuFrmMethods_menu_Notes___";
            this.menuFrmMethods_menu_Notes___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Notes_Execute);
            this.menuFrmMethods_menu_Notes___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Notes_Inquire);
            // 
            // menuFrmMethods_menuChange__Company___
            // 
            resources.ApplyResources(this.menuFrmMethods_menuChange__Company___, "menuFrmMethods_menuChange__Company___");
            this.menuFrmMethods_menuChange__Company___.Name = "menuFrmMethods_menuChange__Company___";
            this.menuFrmMethods_menuChange__Company___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Change_Execute);
            this.menuFrmMethods_menuChange__Company___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Change_Inquire);
            // 
            // labelcmbAccount
            // 
            resources.ApplyResources(this.labelcmbAccount, "labelcmbAccount");
            this.labelcmbAccount.BackColor = System.Drawing.Color.Transparent;
            this.picTabs.SetControlTabPages(this.labelcmbAccount, "tabBasic;tabCodePartDemands;tabBudgetDemand;tabConsolidation");
            this.labelcmbAccount.Name = "labelcmbAccount";
            // 
            // cmbAccount
            // 
            this.picTabs.SetControlTabPages(this.cmbAccount, "tabBasic;tabCodePartDemands;tabBudgetDemand;tabConsolidation");
            resources.ApplyResources(this.cmbAccount, "cmbAccount");
            this.cmbAccount.Name = "cmbAccount";
            this.cmbAccount.NamedProperties.Put("EnumerateMethod", "");
            this.cmbAccount.NamedProperties.Put("FieldFlags", "163");
            this.cmbAccount.NamedProperties.Put("Format", "9");
            this.cmbAccount.NamedProperties.Put("LovReference", "ACCOUNTS_CONSOLIDATION(COMPANY)");
            this.cmbAccount.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbAccount.NamedProperties.Put("SqlColumn", "ACCOUNT");
            this.cmbAccount.NamedProperties.Put("ValidateMethod", "");
            this.cmbAccount.NamedProperties.Put("XDataLength", "20");
            this.cmbAccount.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbAccount_WindowActions);
            // 
            // labeldfsDescription
            // 
            resources.ApplyResources(this.labeldfsDescription, "labeldfsDescription");
            this.labeldfsDescription.Name = "labeldfsDescription";
            // 
            // dfsDescription
            // 
            this.picTabs.SetControlTabPages(this.dfsDescription, "tabBasic;tabCodePartDemands;tabBudgetDemand;tabConsolidation");
            resources.ApplyResources(this.dfsDescription, "dfsDescription");
            this.dfsDescription.Name = "dfsDescription";
            this.dfsDescription.NamedProperties.Put("EnumerateMethod", "");
            this.dfsDescription.NamedProperties.Put("FieldFlags", "295");
            this.dfsDescription.NamedProperties.Put("LovReference", "");
            this.dfsDescription.NamedProperties.Put("ParentName", "cmbAccount");
            this.dfsDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsDescription.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            this.dfsDescription.NamedProperties.Put("ValidateMethod", "");
            // 
            // dfsCompany
            // 
            this.dfsCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsCompany, "dfsCompany");
            this.dfsCompany.Name = "dfsCompany";
            this.dfsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.dfsCompany.NamedProperties.Put("FieldFlags", "67");
            this.dfsCompany.NamedProperties.Put("LovReference", "COMPANY_FINANCE");
            this.dfsCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.dfsCompany.NamedProperties.Put("ValidateMethod", "");
            this.dfsCompany.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsCompany_WindowActions);
            // 
            // labeldfsAccountType
            // 
            resources.ApplyResources(this.labeldfsAccountType, "labeldfsAccountType");
            this.labeldfsAccountType.BackColor = System.Drawing.Color.Transparent;
            this.picTabs.SetControlTabPages(this.labeldfsAccountType, "tabBasic");
            this.labeldfsAccountType.Name = "labeldfsAccountType";
            // 
            // dfsAccountType
            // 
            this.dfsAccountType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.picTabs.SetControlTabPages(this.dfsAccountType, "tabBasic");
            resources.ApplyResources(this.dfsAccountType, "dfsAccountType");
            this.dfsAccountType.Name = "dfsAccountType";
            this.dfsAccountType.NamedProperties.Put("EnumerateMethod", "");
            this.dfsAccountType.NamedProperties.Put("FieldFlags", "295");
            this.dfsAccountType.NamedProperties.Put("LovReference", "ACCOUNT_TYPE(COMPANY)");
            this.dfsAccountType.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsAccountType.NamedProperties.Put("SqlColumn", "ACCNT_TYPE");
            this.dfsAccountType.NamedProperties.Put("ValidateMethod", "");
            this.dfsAccountType.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsAccountType_WindowActions);
            // 
            // labeldfsAccountTypeDescription
            // 
            resources.ApplyResources(this.labeldfsAccountTypeDescription, "labeldfsAccountTypeDescription");
            this.labeldfsAccountTypeDescription.Name = "labeldfsAccountTypeDescription";
            // 
            // dfsAccountTypeDescription
            // 
            this.picTabs.SetControlTabPages(this.dfsAccountTypeDescription, "tabBasic");
            resources.ApplyResources(this.dfsAccountTypeDescription, "dfsAccountTypeDescription");
            this.dfsAccountTypeDescription.Name = "dfsAccountTypeDescription";
            this.dfsAccountTypeDescription.NamedProperties.Put("EnumerateMethod", "");
            this.dfsAccountTypeDescription.NamedProperties.Put("LovReference", "");
            this.dfsAccountTypeDescription.NamedProperties.Put("ParentName", "dfsAccountType");
            this.dfsAccountTypeDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsAccountTypeDescription.NamedProperties.Put("SqlColumn", "Enterp_Comp_Connect_V170_API.Get_Company_Translation( COMPANY,\'ACCRUL\',\'AccountTy" +
        "pe\',ACCNT_TYPE,NULL,\'NO\')");
            this.dfsAccountTypeDescription.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsLogicalAccountType
            // 
            resources.ApplyResources(this.labeldfsLogicalAccountType, "labeldfsLogicalAccountType");
            this.labeldfsLogicalAccountType.Name = "labeldfsLogicalAccountType";
            // 
            // dfsLogicalAccountType
            // 
            resources.ApplyResources(this.dfsLogicalAccountType, "dfsLogicalAccountType");
            this.dfsLogicalAccountType.Name = "dfsLogicalAccountType";
            this.dfsLogicalAccountType.NamedProperties.Put("EnumerateMethod", "");
            this.dfsLogicalAccountType.NamedProperties.Put("LovReference", "");
            this.dfsLogicalAccountType.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsLogicalAccountType.NamedProperties.Put("SqlColumn", "LOGICAL_ACCOUNT_TYPE_DB");
            this.dfsLogicalAccountType.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsAccountGroup
            // 
            resources.ApplyResources(this.labeldfsAccountGroup, "labeldfsAccountGroup");
            this.labeldfsAccountGroup.BackColor = System.Drawing.Color.Transparent;
            this.picTabs.SetControlTabPages(this.labeldfsAccountGroup, "tabBasic");
            this.labeldfsAccountGroup.Name = "labeldfsAccountGroup";
            // 
            // dfsAccountGroup
            // 
            this.dfsAccountGroup.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.picTabs.SetControlTabPages(this.dfsAccountGroup, "tabBasic");
            resources.ApplyResources(this.dfsAccountGroup, "dfsAccountGroup");
            this.dfsAccountGroup.Name = "dfsAccountGroup";
            this.dfsAccountGroup.NamedProperties.Put("EnumerateMethod", "");
            this.dfsAccountGroup.NamedProperties.Put("FieldFlags", "295");
            this.dfsAccountGroup.NamedProperties.Put("LovReference", "ACCOUNT_GROUP(COMPANY)");
            this.dfsAccountGroup.NamedProperties.Put("SqlColumn", "ACCNT_GROUP");
            // 
            // labeldfsAccountGroupDescription
            // 
            resources.ApplyResources(this.labeldfsAccountGroupDescription, "labeldfsAccountGroupDescription");
            this.labeldfsAccountGroupDescription.BackColor = System.Drawing.Color.Transparent;
            this.picTabs.SetControlTabPages(this.labeldfsAccountGroupDescription, "tabBasic");
            this.labeldfsAccountGroupDescription.Name = "labeldfsAccountGroupDescription";
            // 
            // dfsAccountGroupDescription
            // 
            this.picTabs.SetControlTabPages(this.dfsAccountGroupDescription, "tabBasic");
            resources.ApplyResources(this.dfsAccountGroupDescription, "dfsAccountGroupDescription");
            this.dfsAccountGroupDescription.Name = "dfsAccountGroupDescription";
            this.dfsAccountGroupDescription.NamedProperties.Put("EnumerateMethod", "");
            this.dfsAccountGroupDescription.NamedProperties.Put("FieldFlags", "288");
            this.dfsAccountGroupDescription.NamedProperties.Put("LovReference", "");
            this.dfsAccountGroupDescription.NamedProperties.Put("ParentName", "dfsAccountGroup");
            this.dfsAccountGroupDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsAccountGroupDescription.NamedProperties.Put("SqlColumn", "Account_group_API.Get_Description(COMPANY,ACCNT_GROUP)");
            this.dfsAccountGroupDescription.NamedProperties.Put("ValidateMethod", "");
            // 
            // gbTax_Options
            // 
            this.gbTax_Options.BackColor = System.Drawing.Color.Transparent;
            this.picTabs.SetControlTabPages(this.gbTax_Options, "tabBasic");
            resources.ApplyResources(this.gbTax_Options, "gbTax_Options");
            this.gbTax_Options.Name = "gbTax_Options";
            this.gbTax_Options.TabStop = false;
            // 
            // labelcmbTaxHandlingValue
            // 
            resources.ApplyResources(this.labelcmbTaxHandlingValue, "labelcmbTaxHandlingValue");
            this.labelcmbTaxHandlingValue.BackColor = System.Drawing.Color.Transparent;
            this.picTabs.SetControlTabPages(this.labelcmbTaxHandlingValue, "tabBasic");
            this.labelcmbTaxHandlingValue.Name = "labelcmbTaxHandlingValue";
            // 
            // cmbTaxHandlingValue
            // 
            this.picTabs.SetControlTabPages(this.cmbTaxHandlingValue, "tabBasic");
            resources.ApplyResources(this.cmbTaxHandlingValue, "cmbTaxHandlingValue");
            this.cmbTaxHandlingValue.Name = "cmbTaxHandlingValue";
            this.cmbTaxHandlingValue.NamedProperties.Put("EnumerateMethod", "TAX_HANDLING_VALUE_API.Enumerate");
            this.cmbTaxHandlingValue.NamedProperties.Put("FieldFlags", "295");
            this.cmbTaxHandlingValue.NamedProperties.Put("LovReference", "");
            this.cmbTaxHandlingValue.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbTaxHandlingValue.NamedProperties.Put("SqlColumn", "TAX_HANDLING_VALUE");
            this.cmbTaxHandlingValue.NamedProperties.Put("ValidateMethod", "");
            this.cmbTaxHandlingValue.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbTaxHandlingValue_WindowActions);
            // 
            // cbTaxCodeMandatory
            // 
            this.cbTaxCodeMandatory.BackColor = System.Drawing.Color.Transparent;
            this.picTabs.SetControlTabPages(this.cbTaxCodeMandatory, "tabBasic");
            resources.ApplyResources(this.cbTaxCodeMandatory, "cbTaxCodeMandatory");
            this.cbTaxCodeMandatory.Name = "cbTaxCodeMandatory";
            this.cbTaxCodeMandatory.NamedProperties.Put("DataType", "5");
            this.cbTaxCodeMandatory.NamedProperties.Put("EnumerateMethod", "");
            this.cbTaxCodeMandatory.NamedProperties.Put("FieldFlags", "295");
            this.cbTaxCodeMandatory.NamedProperties.Put("LovReference", "");
            this.cbTaxCodeMandatory.NamedProperties.Put("ResizeableChildObject", "");
            this.cbTaxCodeMandatory.NamedProperties.Put("SqlColumn", "TAX_CODE_MANDATORY");
            this.cbTaxCodeMandatory.NamedProperties.Put("ValidateMethod", "");
            this.cbTaxCodeMandatory.NamedProperties.Put("XDataLength", "");
            this.cbTaxCodeMandatory.UseVisualStyleBackColor = false;
            this.cbTaxCodeMandatory.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cbTaxCodeMandatory_WindowActions);
            // 
            // labeldfdtValidFrom
            // 
            resources.ApplyResources(this.labeldfdtValidFrom, "labeldfdtValidFrom");
            this.labeldfdtValidFrom.BackColor = System.Drawing.Color.Transparent;
            this.picTabs.SetControlTabPages(this.labeldfdtValidFrom, "tabBasic");
            this.labeldfdtValidFrom.Name = "labeldfdtValidFrom";
            // 
            // dfdtValidFrom
            // 
            this.picTabs.SetControlTabPages(this.dfdtValidFrom, "tabBasic");
            this.dfdtValidFrom.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.dfdtValidFrom.Format = "d";
            resources.ApplyResources(this.dfdtValidFrom, "dfdtValidFrom");
            this.dfdtValidFrom.Name = "dfdtValidFrom";
            this.dfdtValidFrom.NamedProperties.Put("EnumerateMethod", "");
            this.dfdtValidFrom.NamedProperties.Put("FieldFlags", "295");
            this.dfdtValidFrom.NamedProperties.Put("LovReference", "");
            this.dfdtValidFrom.NamedProperties.Put("SqlColumn", "VALID_FROM");
            // 
            // labeldfdtValidUntil
            // 
            resources.ApplyResources(this.labeldfdtValidUntil, "labeldfdtValidUntil");
            this.labeldfdtValidUntil.BackColor = System.Drawing.Color.Transparent;
            this.picTabs.SetControlTabPages(this.labeldfdtValidUntil, "tabBasic");
            this.labeldfdtValidUntil.Name = "labeldfdtValidUntil";
            // 
            // dfdtValidUntil
            // 
            this.picTabs.SetControlTabPages(this.dfdtValidUntil, "tabBasic");
            this.dfdtValidUntil.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.dfdtValidUntil.Format = "d";
            resources.ApplyResources(this.dfdtValidUntil, "dfdtValidUntil");
            this.dfdtValidUntil.Name = "dfdtValidUntil";
            this.dfdtValidUntil.NamedProperties.Put("EnumerateMethod", "");
            this.dfdtValidUntil.NamedProperties.Put("FieldFlags", "295");
            this.dfdtValidUntil.NamedProperties.Put("LovReference", "");
            this.dfdtValidUntil.NamedProperties.Put("SqlColumn", "VALID_UNTIL");
            // 
            // gbOptions
            // 
            this.gbOptions.BackColor = System.Drawing.Color.Transparent;
            this.picTabs.SetControlTabPages(this.gbOptions, "tabBasic");
            resources.ApplyResources(this.gbOptions, "gbOptions");
            this.gbOptions.Name = "gbOptions";
            this.gbOptions.TabStop = false;
            // 
            // cbTaxAccount
            // 
            this.cbTaxAccount.BackColor = System.Drawing.Color.Transparent;
            this.picTabs.SetControlTabPages(this.cbTaxAccount, "tabBasic");
            resources.ApplyResources(this.cbTaxAccount, "cbTaxAccount");
            this.cbTaxAccount.Name = "cbTaxAccount";
            this.cbTaxAccount.NamedProperties.Put("DataType", "5");
            this.cbTaxAccount.NamedProperties.Put("EnumerateMethod", "");
            this.cbTaxAccount.NamedProperties.Put("FieldFlags", "295");
            this.cbTaxAccount.NamedProperties.Put("LovReference", "");
            this.cbTaxAccount.NamedProperties.Put("ResizeableChildObject", "");
            this.cbTaxAccount.NamedProperties.Put("SqlColumn", "TAX_FLAG_DB");
            this.cbTaxAccount.NamedProperties.Put("ValidateMethod", "");
            this.cbTaxAccount.NamedProperties.Put("XDataLength", "1");
            this.cbTaxAccount.UseVisualStyleBackColor = false;
            this.cbTaxAccount.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cbTaxAccount_WindowActions);
            // 
            // cbLedgFlag
            // 
            resources.ApplyResources(this.cbLedgFlag, "cbLedgFlag");
            this.cbLedgFlag.BackColor = System.Drawing.Color.Transparent;
            this.picTabs.SetControlTabPages(this.cbLedgFlag, "tabBasic");
            this.cbLedgFlag.Name = "cbLedgFlag";
            this.cbLedgFlag.NamedProperties.Put("DataType", "5");
            this.cbLedgFlag.NamedProperties.Put("EnumerateMethod", "");
            this.cbLedgFlag.NamedProperties.Put("FieldFlags", "295");
            this.cbLedgFlag.NamedProperties.Put("LovReference", "");
            this.cbLedgFlag.NamedProperties.Put("ResizeableChildObject", "");
            this.cbLedgFlag.NamedProperties.Put("SqlColumn", "LEDG_FLAG_DB");
            this.cbLedgFlag.NamedProperties.Put("ValidateMethod", "");
            this.cbLedgFlag.NamedProperties.Put("XDataLength", "1");
            this.cbLedgFlag.UseVisualStyleBackColor = false;
            this.cbLedgFlag.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cbLedgFlag_WindowActions);
            // 
            // cbCurrBalance
            // 
            this.cbCurrBalance.BackColor = System.Drawing.Color.Transparent;
            this.picTabs.SetControlTabPages(this.cbCurrBalance, "tabBasic");
            resources.ApplyResources(this.cbCurrBalance, "cbCurrBalance");
            this.cbCurrBalance.Name = "cbCurrBalance";
            this.cbCurrBalance.NamedProperties.Put("EnumerateMethod", "");
            this.cbCurrBalance.NamedProperties.Put("FieldFlags", "294");
            this.cbCurrBalance.NamedProperties.Put("LovReference", "");
            this.cbCurrBalance.NamedProperties.Put("ResizeableChildObject", "");
            this.cbCurrBalance.NamedProperties.Put("SqlColumn", "CURR_BALANCE_DB");
            this.cbCurrBalance.NamedProperties.Put("ValidateMethod", "");
            this.cbCurrBalance.NamedProperties.Put("XDataLength", "1");
            this.cbCurrBalance.UseVisualStyleBackColor = false;
            this.cbCurrBalance.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cbCurrBalance_WindowActions);
            // 
            // cbBudAccount
            // 
            this.cbBudAccount.BackColor = System.Drawing.Color.Transparent;
            this.picTabs.SetControlTabPages(this.cbBudAccount, "tabBasic");
            resources.ApplyResources(this.cbBudAccount, "cbBudAccount");
            this.cbBudAccount.Name = "cbBudAccount";
            this.cbBudAccount.NamedProperties.Put("EnumerateMethod", "");
            this.cbBudAccount.NamedProperties.Put("FieldFlags", "295");
            this.cbBudAccount.NamedProperties.Put("LovReference", "");
            this.cbBudAccount.NamedProperties.Put("ResizeableChildObject", "");
            this.cbBudAccount.NamedProperties.Put("SqlColumn", "BUD_ACCOUNT_DB");
            this.cbBudAccount.NamedProperties.Put("ValidateMethod", "");
            this.cbBudAccount.NamedProperties.Put("XDataLength", "1");
            this.cbBudAccount.UseVisualStyleBackColor = false;
            this.cbBudAccount.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cbBudAccount_WindowActions);
            // 
            // cbStatisticalAccount
            // 
            this.cbStatisticalAccount.BackColor = System.Drawing.Color.Transparent;
            this.picTabs.SetControlTabPages(this.cbStatisticalAccount, "tabBasic");
            resources.ApplyResources(this.cbStatisticalAccount, "cbStatisticalAccount");
            this.cbStatisticalAccount.Name = "cbStatisticalAccount";
            this.cbStatisticalAccount.NamedProperties.Put("EnumerateMethod", "");
            this.cbStatisticalAccount.NamedProperties.Put("FieldFlags", "295");
            this.cbStatisticalAccount.NamedProperties.Put("LovReference", "");
            this.cbStatisticalAccount.NamedProperties.Put("ResizeableChildObject", "");
            this.cbStatisticalAccount.NamedProperties.Put("SqlColumn", "STAT_ACCOUNT_DB");
            this.cbStatisticalAccount.NamedProperties.Put("ValidateMethod", "");
            this.cbStatisticalAccount.NamedProperties.Put("XDataLength", "1");
            this.cbStatisticalAccount.UseVisualStyleBackColor = false;
            this.cbStatisticalAccount.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cbStatisticalAccount_WindowActions);
            // 
            // mlsText
            // 
            resources.ApplyResources(this.mlsText, "mlsText");
            this.mlsText.Name = "mlsText";
            this.mlsText.NamedProperties.Put("EnumerateMethod", "");
            this.mlsText.NamedProperties.Put("FieldFlags", "262");
            this.mlsText.NamedProperties.Put("LovReference", "");
            this.mlsText.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.mlsText.NamedProperties.Put("ResizeableChildObject", "");
            this.mlsText.NamedProperties.Put("SqlColumn", "TEXT");
            this.mlsText.NamedProperties.Put("ValidateMethod", "");
            this.mlsText.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.mlsText_WindowActions);
            // 
            // cbCodeStr
            // 
            this.cbCodeStr.BackColor = System.Drawing.Color.Transparent;
            this.picTabs.SetControlTabPages(this.cbCodeStr, "tabBasic");
            resources.ApplyResources(this.cbCodeStr, "cbCodeStr");
            this.cbCodeStr.Name = "cbCodeStr";
            this.cbCodeStr.NamedProperties.Put("DataType", "5");
            this.cbCodeStr.NamedProperties.Put("EnumerateMethod", "");
            this.cbCodeStr.NamedProperties.Put("FieldFlags", "288");
            this.cbCodeStr.NamedProperties.Put("LovReference", "");
            this.cbCodeStr.NamedProperties.Put("ResizeableChildObject", "");
            this.cbCodeStr.NamedProperties.Put("SqlColumn", "ACCOUNTING_CODESTR_COMPL_API.Connect_To_Account(COMPANY,\'A\',ACCOUNT)");
            this.cbCodeStr.NamedProperties.Put("ValidateMethod", "");
            this.cbCodeStr.NamedProperties.Put("XDataLength", "1");
            this.cbCodeStr.UseVisualStyleBackColor = false;
            this.cbCodeStr.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cbCodeStr_WindowActions);
            // 
            // cbAttribute
            // 
            this.cbAttribute.BackColor = System.Drawing.Color.Transparent;
            this.picTabs.SetControlTabPages(this.cbAttribute, "tabBasic");
            resources.ApplyResources(this.cbAttribute, "cbAttribute");
            this.cbAttribute.Name = "cbAttribute";
            this.cbAttribute.NamedProperties.Put("DataType", "5");
            this.cbAttribute.NamedProperties.Put("EnumerateMethod", "");
            this.cbAttribute.NamedProperties.Put("FieldFlags", "288");
            this.cbAttribute.NamedProperties.Put("LovReference", "");
            this.cbAttribute.NamedProperties.Put("ResizeableChildObject", "");
            this.cbAttribute.NamedProperties.Put("SqlColumn", "ACCOUNTING_ATTRIBUTE_CON_API.Connect_To_Attribute(COMPANY,\'A\',ACCOUNT)");
            this.cbAttribute.NamedProperties.Put("ValidateMethod", "");
            this.cbAttribute.NamedProperties.Put("XDataLength", "1");
            this.cbAttribute.UseVisualStyleBackColor = false;
            this.cbAttribute.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cbAttribute_WindowActions);
            // 
            // cbFreeText
            // 
            this.cbFreeText.BackColor = System.Drawing.Color.Transparent;
            this.picTabs.SetControlTabPages(this.cbFreeText, "tabBasic");
            resources.ApplyResources(this.cbFreeText, "cbFreeText");
            this.cbFreeText.Name = "cbFreeText";
            this.cbFreeText.NamedProperties.Put("DataType", "5");
            this.cbFreeText.NamedProperties.Put("EnumerateMethod", "");
            this.cbFreeText.NamedProperties.Put("FieldFlags", "800");
            this.cbFreeText.NamedProperties.Put("LovReference", "");
            this.cbFreeText.NamedProperties.Put("ResizeableChildObject", "");
            this.cbFreeText.NamedProperties.Put("SqlColumn", "CB_TEXT");
            this.cbFreeText.NamedProperties.Put("ValidateMethod", "");
            this.cbFreeText.NamedProperties.Put("XDataLength", "5");
            this.cbFreeText.UseVisualStyleBackColor = false;
            this.cbFreeText.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cbFreeText_WindowActions);
            // 
            // labelcmbCostCenter
            // 
            resources.ApplyResources(this.labelcmbCostCenter, "labelcmbCostCenter");
            this.labelcmbCostCenter.BackColor = System.Drawing.Color.Transparent;
            this.picTabs.SetControlTabPages(this.labelcmbCostCenter, "tabCodePartDemands");
            this.labelcmbCostCenter.Name = "labelcmbCostCenter";
            // 
            // cmbCostCenter
            // 
            this.picTabs.SetControlTabPages(this.cmbCostCenter, "tabCodePartDemands");
            resources.ApplyResources(this.cmbCostCenter, "cmbCostCenter");
            this.cmbCostCenter.Name = "cmbCostCenter";
            this.cmbCostCenter.NamedProperties.Put("EnumerateMethod", "");
            this.cmbCostCenter.NamedProperties.Put("FieldFlags", "295");
            this.cmbCostCenter.NamedProperties.Put("LovReference", "");
            this.cmbCostCenter.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbCostCenter.NamedProperties.Put("SqlColumn", "REQ_CODE_B");
            this.cmbCostCenter.NamedProperties.Put("ValidateMethod", "");
            this.cmbCostCenter.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbCostCenter_WindowActions);
            // 
            // labelcmbCodeC
            // 
            resources.ApplyResources(this.labelcmbCodeC, "labelcmbCodeC");
            this.labelcmbCodeC.BackColor = System.Drawing.Color.Transparent;
            this.picTabs.SetControlTabPages(this.labelcmbCodeC, "tabCodePartDemands");
            this.labelcmbCodeC.Name = "labelcmbCodeC";
            // 
            // cmbCodeC
            // 
            this.picTabs.SetControlTabPages(this.cmbCodeC, "tabCodePartDemands");
            resources.ApplyResources(this.cmbCodeC, "cmbCodeC");
            this.cmbCodeC.Name = "cmbCodeC";
            this.cmbCodeC.NamedProperties.Put("EnumerateMethod", "");
            this.cmbCodeC.NamedProperties.Put("FieldFlags", "295");
            this.cmbCodeC.NamedProperties.Put("LovReference", "");
            this.cmbCodeC.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbCodeC.NamedProperties.Put("SqlColumn", "REQ_CODE_C");
            this.cmbCodeC.NamedProperties.Put("ValidateMethod", "");
            this.cmbCodeC.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbCodeC_WindowActions);
            // 
            // labelcmbCodeD
            // 
            resources.ApplyResources(this.labelcmbCodeD, "labelcmbCodeD");
            this.labelcmbCodeD.BackColor = System.Drawing.Color.Transparent;
            this.picTabs.SetControlTabPages(this.labelcmbCodeD, "tabCodePartDemands");
            this.labelcmbCodeD.Name = "labelcmbCodeD";
            // 
            // cmbCodeD
            // 
            this.picTabs.SetControlTabPages(this.cmbCodeD, "tabCodePartDemands");
            resources.ApplyResources(this.cmbCodeD, "cmbCodeD");
            this.cmbCodeD.Name = "cmbCodeD";
            this.cmbCodeD.NamedProperties.Put("EnumerateMethod", "");
            this.cmbCodeD.NamedProperties.Put("FieldFlags", "295");
            this.cmbCodeD.NamedProperties.Put("LovReference", "");
            this.cmbCodeD.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbCodeD.NamedProperties.Put("SqlColumn", "REQ_CODE_D");
            this.cmbCodeD.NamedProperties.Put("ValidateMethod", "");
            this.cmbCodeD.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbCodeD_WindowActions);
            // 
            // labelcmbObject
            // 
            resources.ApplyResources(this.labelcmbObject, "labelcmbObject");
            this.labelcmbObject.BackColor = System.Drawing.Color.Transparent;
            this.picTabs.SetControlTabPages(this.labelcmbObject, "tabCodePartDemands");
            this.labelcmbObject.Name = "labelcmbObject";
            // 
            // cmbObject
            // 
            this.picTabs.SetControlTabPages(this.cmbObject, "tabCodePartDemands");
            resources.ApplyResources(this.cmbObject, "cmbObject");
            this.cmbObject.Name = "cmbObject";
            this.cmbObject.NamedProperties.Put("EnumerateMethod", "");
            this.cmbObject.NamedProperties.Put("FieldFlags", "295");
            this.cmbObject.NamedProperties.Put("LovReference", "");
            this.cmbObject.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbObject.NamedProperties.Put("SqlColumn", "REQ_CODE_E");
            this.cmbObject.NamedProperties.Put("ValidateMethod", "");
            this.cmbObject.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbObject_WindowActions);
            // 
            // labelcmbProject
            // 
            resources.ApplyResources(this.labelcmbProject, "labelcmbProject");
            this.labelcmbProject.BackColor = System.Drawing.Color.Transparent;
            this.picTabs.SetControlTabPages(this.labelcmbProject, "tabCodePartDemands");
            this.labelcmbProject.Name = "labelcmbProject";
            // 
            // cmbProject
            // 
            this.picTabs.SetControlTabPages(this.cmbProject, "tabCodePartDemands");
            resources.ApplyResources(this.cmbProject, "cmbProject");
            this.cmbProject.Name = "cmbProject";
            this.cmbProject.NamedProperties.Put("EnumerateMethod", "");
            this.cmbProject.NamedProperties.Put("FieldFlags", "295");
            this.cmbProject.NamedProperties.Put("LovReference", "");
            this.cmbProject.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbProject.NamedProperties.Put("SqlColumn", "REQ_CODE_F");
            this.cmbProject.NamedProperties.Put("ValidateMethod", "");
            this.cmbProject.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbProject_WindowActions);
            // 
            // labelcmbCodeG
            // 
            resources.ApplyResources(this.labelcmbCodeG, "labelcmbCodeG");
            this.labelcmbCodeG.BackColor = System.Drawing.Color.Transparent;
            this.picTabs.SetControlTabPages(this.labelcmbCodeG, "tabCodePartDemands");
            this.labelcmbCodeG.Name = "labelcmbCodeG";
            // 
            // cmbCodeG
            // 
            this.picTabs.SetControlTabPages(this.cmbCodeG, "tabCodePartDemands");
            resources.ApplyResources(this.cmbCodeG, "cmbCodeG");
            this.cmbCodeG.Name = "cmbCodeG";
            this.cmbCodeG.NamedProperties.Put("EnumerateMethod", "");
            this.cmbCodeG.NamedProperties.Put("FieldFlags", "295");
            this.cmbCodeG.NamedProperties.Put("LovReference", "");
            this.cmbCodeG.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbCodeG.NamedProperties.Put("SqlColumn", "REQ_CODE_G");
            this.cmbCodeG.NamedProperties.Put("ValidateMethod", "");
            this.cmbCodeG.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbCodeG_WindowActions);
            // 
            // labelcmbCodeH
            // 
            resources.ApplyResources(this.labelcmbCodeH, "labelcmbCodeH");
            this.labelcmbCodeH.BackColor = System.Drawing.Color.Transparent;
            this.picTabs.SetControlTabPages(this.labelcmbCodeH, "tabCodePartDemands");
            this.labelcmbCodeH.Name = "labelcmbCodeH";
            // 
            // cmbCodeH
            // 
            this.picTabs.SetControlTabPages(this.cmbCodeH, "tabCodePartDemands");
            this.cmbCodeH.DropDownHeight = 153;
            resources.ApplyResources(this.cmbCodeH, "cmbCodeH");
            this.cmbCodeH.Name = "cmbCodeH";
            this.cmbCodeH.NamedProperties.Put("EnumerateMethod", "");
            this.cmbCodeH.NamedProperties.Put("FieldFlags", "295");
            this.cmbCodeH.NamedProperties.Put("LovReference", "");
            this.cmbCodeH.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbCodeH.NamedProperties.Put("SqlColumn", "REQ_CODE_H");
            this.cmbCodeH.NamedProperties.Put("ValidateMethod", "");
            this.cmbCodeH.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbCodeH_WindowActions);
            // 
            // labelcmbCodeI
            // 
            resources.ApplyResources(this.labelcmbCodeI, "labelcmbCodeI");
            this.labelcmbCodeI.BackColor = System.Drawing.Color.Transparent;
            this.picTabs.SetControlTabPages(this.labelcmbCodeI, "tabCodePartDemands");
            this.labelcmbCodeI.Name = "labelcmbCodeI";
            // 
            // cmbCodeI
            // 
            this.picTabs.SetControlTabPages(this.cmbCodeI, "tabCodePartDemands");
            resources.ApplyResources(this.cmbCodeI, "cmbCodeI");
            this.cmbCodeI.Name = "cmbCodeI";
            this.cmbCodeI.NamedProperties.Put("EnumerateMethod", "");
            this.cmbCodeI.NamedProperties.Put("FieldFlags", "295");
            this.cmbCodeI.NamedProperties.Put("LovReference", "");
            this.cmbCodeI.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbCodeI.NamedProperties.Put("SqlColumn", "REQ_CODE_I");
            this.cmbCodeI.NamedProperties.Put("ValidateMethod", "");
            this.cmbCodeI.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbCodeI_WindowActions);
            // 
            // labelcmbCodeJ
            // 
            resources.ApplyResources(this.labelcmbCodeJ, "labelcmbCodeJ");
            this.labelcmbCodeJ.BackColor = System.Drawing.Color.Transparent;
            this.picTabs.SetControlTabPages(this.labelcmbCodeJ, "tabCodePartDemands");
            this.labelcmbCodeJ.Name = "labelcmbCodeJ";
            // 
            // cmbCodeJ
            // 
            this.picTabs.SetControlTabPages(this.cmbCodeJ, "tabCodePartDemands");
            resources.ApplyResources(this.cmbCodeJ, "cmbCodeJ");
            this.cmbCodeJ.Name = "cmbCodeJ";
            this.cmbCodeJ.NamedProperties.Put("EnumerateMethod", "");
            this.cmbCodeJ.NamedProperties.Put("FieldFlags", "295");
            this.cmbCodeJ.NamedProperties.Put("LovReference", "");
            this.cmbCodeJ.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbCodeJ.NamedProperties.Put("SqlColumn", "REQ_CODE_J");
            this.cmbCodeJ.NamedProperties.Put("ValidateMethod", "");
            this.cmbCodeJ.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbCodeJ_WindowActions);
            // 
            // labelcmbQuantity
            // 
            resources.ApplyResources(this.labelcmbQuantity, "labelcmbQuantity");
            this.labelcmbQuantity.BackColor = System.Drawing.Color.Transparent;
            this.picTabs.SetControlTabPages(this.labelcmbQuantity, "tabCodePartDemands");
            this.labelcmbQuantity.Name = "labelcmbQuantity";
            // 
            // cmbQuantity
            // 
            this.picTabs.SetControlTabPages(this.cmbQuantity, "tabCodePartDemands");
            resources.ApplyResources(this.cmbQuantity, "cmbQuantity");
            this.cmbQuantity.Name = "cmbQuantity";
            this.cmbQuantity.NamedProperties.Put("EnumerateMethod", "");
            this.cmbQuantity.NamedProperties.Put("FieldFlags", "295");
            this.cmbQuantity.NamedProperties.Put("LovReference", "");
            this.cmbQuantity.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbQuantity.NamedProperties.Put("SqlColumn", "REQ_QUANTITY");
            this.cmbQuantity.NamedProperties.Put("ValidateMethod", "");
            this.cmbQuantity.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbQuantity_WindowActions);
            // 
            // labelcmbReqProcessCode
            // 
            resources.ApplyResources(this.labelcmbReqProcessCode, "labelcmbReqProcessCode");
            this.labelcmbReqProcessCode.BackColor = System.Drawing.Color.Transparent;
            this.picTabs.SetControlTabPages(this.labelcmbReqProcessCode, "tabCodePartDemands");
            this.labelcmbReqProcessCode.Name = "labelcmbReqProcessCode";
            // 
            // cmbReqProcessCode
            // 
            this.picTabs.SetControlTabPages(this.cmbReqProcessCode, "tabCodePartDemands");
            resources.ApplyResources(this.cmbReqProcessCode, "cmbReqProcessCode");
            this.cmbReqProcessCode.Name = "cmbReqProcessCode";
            this.cmbReqProcessCode.NamedProperties.Put("EnumerateMethod", "");
            this.cmbReqProcessCode.NamedProperties.Put("FieldFlags", "295");
            this.cmbReqProcessCode.NamedProperties.Put("LovReference", "");
            this.cmbReqProcessCode.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbReqProcessCode.NamedProperties.Put("SqlColumn", "REQ_PROCESS_CODE");
            this.cmbReqProcessCode.NamedProperties.Put("ValidateMethod", "");
            this.cmbReqProcessCode.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbReqProcessCode_WindowActions);
            // 
            // labelcmbText
            // 
            resources.ApplyResources(this.labelcmbText, "labelcmbText");
            this.labelcmbText.BackColor = System.Drawing.Color.Transparent;
            this.picTabs.SetControlTabPages(this.labelcmbText, "tabCodePartDemands");
            this.labelcmbText.Name = "labelcmbText";
            // 
            // cmbText
            // 
            this.picTabs.SetControlTabPages(this.cmbText, "tabCodePartDemands");
            resources.ApplyResources(this.cmbText, "cmbText");
            this.cmbText.Name = "cmbText";
            this.cmbText.NamedProperties.Put("EnumerateMethod", "");
            this.cmbText.NamedProperties.Put("FieldFlags", "295");
            this.cmbText.NamedProperties.Put("LovReference", "");
            this.cmbText.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbText.NamedProperties.Put("SqlColumn", "REQ_TEXT");
            this.cmbText.NamedProperties.Put("ValidateMethod", "");
            this.cmbText.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbText_WindowActions);
            // 
            // labeldfsConsolidAccount
            // 
            resources.ApplyResources(this.labeldfsConsolidAccount, "labeldfsConsolidAccount");
            this.labeldfsConsolidAccount.BackColor = System.Drawing.Color.Transparent;
            this.picTabs.SetControlTabPages(this.labeldfsConsolidAccount, "tabConsolidation");
            this.labeldfsConsolidAccount.Name = "labeldfsConsolidAccount";
            // 
            // dfsConsolidAccount
            // 
            this.dfsConsolidAccount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.picTabs.SetControlTabPages(this.dfsConsolidAccount, "tabConsolidation");
            resources.ApplyResources(this.dfsConsolidAccount, "dfsConsolidAccount");
            this.dfsConsolidAccount.Name = "dfsConsolidAccount";
            this.dfsConsolidAccount.NamedProperties.Put("EnumerateMethod", "");
            this.dfsConsolidAccount.NamedProperties.Put("FieldFlags", "294");
            this.dfsConsolidAccount.NamedProperties.Put("LovReference", "ACCOUNT(CONS_COMPANY)");
            this.dfsConsolidAccount.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsConsolidAccount.NamedProperties.Put("SqlColumn", "CONS_ACCNT");
            this.dfsConsolidAccount.NamedProperties.Put("ValidateMethod", "");
            this.dfsConsolidAccount.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsConsolidAccount_WindowActions);
            // 
            // labeldfsConsolidAccntDescription
            // 
            resources.ApplyResources(this.labeldfsConsolidAccntDescription, "labeldfsConsolidAccntDescription");
            this.labeldfsConsolidAccntDescription.Name = "labeldfsConsolidAccntDescription";
            // 
            // dfsConsolidAccntDescription
            // 
            this.picTabs.SetControlTabPages(this.dfsConsolidAccntDescription, "tabConsolidation");
            resources.ApplyResources(this.dfsConsolidAccntDescription, "dfsConsolidAccntDescription");
            this.dfsConsolidAccntDescription.Name = "dfsConsolidAccntDescription";
            this.dfsConsolidAccntDescription.NamedProperties.Put("FieldFlags", "288");
            this.dfsConsolidAccntDescription.NamedProperties.Put("ParentName", "dfsConsolidAccount");
            this.dfsConsolidAccntDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsConsolidAccntDescription.NamedProperties.Put("SqlColumn", "");
            // 
            // dfConsCompany
            // 
            this.dfConsCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfConsCompany, "dfConsCompany");
            this.dfConsCompany.Name = "dfConsCompany";
            this.dfConsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.dfConsCompany.NamedProperties.Put("FieldFlags", "262");
            this.dfConsCompany.NamedProperties.Put("LovReference", "");
            this.dfConsCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.dfConsCompany.NamedProperties.Put("SqlColumn", "CONS_COMPANY");
            this.dfConsCompany.NamedProperties.Put("ValidateMethod", "");
            // 
            // labelcmbReqBudgetCodeB
            // 
            resources.ApplyResources(this.labelcmbReqBudgetCodeB, "labelcmbReqBudgetCodeB");
            this.labelcmbReqBudgetCodeB.BackColor = System.Drawing.Color.Transparent;
            this.picTabs.SetControlTabPages(this.labelcmbReqBudgetCodeB, "tabBudgetDemand");
            this.labelcmbReqBudgetCodeB.Name = "labelcmbReqBudgetCodeB";
            // 
            // cmbReqBudgetCodeB
            // 
            this.picTabs.SetControlTabPages(this.cmbReqBudgetCodeB, "tabBudgetDemand");
            resources.ApplyResources(this.cmbReqBudgetCodeB, "cmbReqBudgetCodeB");
            this.cmbReqBudgetCodeB.Name = "cmbReqBudgetCodeB";
            this.cmbReqBudgetCodeB.NamedProperties.Put("EnumerateMethod", "");
            this.cmbReqBudgetCodeB.NamedProperties.Put("FieldFlags", "295");
            this.cmbReqBudgetCodeB.NamedProperties.Put("LovReference", "");
            this.cmbReqBudgetCodeB.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbReqBudgetCodeB.NamedProperties.Put("SqlColumn", "REQ_BUDGET_CODE_B");
            this.cmbReqBudgetCodeB.NamedProperties.Put("ValidateMethod", "");
            this.cmbReqBudgetCodeB.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbReqBudgetCodeB_WindowActions);
            // 
            // labelcmbReqBudgetCodeC
            // 
            resources.ApplyResources(this.labelcmbReqBudgetCodeC, "labelcmbReqBudgetCodeC");
            this.labelcmbReqBudgetCodeC.BackColor = System.Drawing.Color.Transparent;
            this.picTabs.SetControlTabPages(this.labelcmbReqBudgetCodeC, "tabBudgetDemand");
            this.labelcmbReqBudgetCodeC.Name = "labelcmbReqBudgetCodeC";
            // 
            // cmbReqBudgetCodeC
            // 
            this.picTabs.SetControlTabPages(this.cmbReqBudgetCodeC, "tabBudgetDemand");
            resources.ApplyResources(this.cmbReqBudgetCodeC, "cmbReqBudgetCodeC");
            this.cmbReqBudgetCodeC.Name = "cmbReqBudgetCodeC";
            this.cmbReqBudgetCodeC.NamedProperties.Put("EnumerateMethod", "");
            this.cmbReqBudgetCodeC.NamedProperties.Put("FieldFlags", "295");
            this.cmbReqBudgetCodeC.NamedProperties.Put("LovReference", "");
            this.cmbReqBudgetCodeC.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbReqBudgetCodeC.NamedProperties.Put("SqlColumn", "REQ_BUDGET_CODE_C");
            this.cmbReqBudgetCodeC.NamedProperties.Put("ValidateMethod", "");
            this.cmbReqBudgetCodeC.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbReqBudgetCodeC_WindowActions);
            // 
            // labelcmbReqBudgetCodeD
            // 
            resources.ApplyResources(this.labelcmbReqBudgetCodeD, "labelcmbReqBudgetCodeD");
            this.labelcmbReqBudgetCodeD.BackColor = System.Drawing.Color.Transparent;
            this.picTabs.SetControlTabPages(this.labelcmbReqBudgetCodeD, "tabBudgetDemand");
            this.labelcmbReqBudgetCodeD.Name = "labelcmbReqBudgetCodeD";
            // 
            // cmbReqBudgetCodeD
            // 
            this.picTabs.SetControlTabPages(this.cmbReqBudgetCodeD, "tabBudgetDemand");
            resources.ApplyResources(this.cmbReqBudgetCodeD, "cmbReqBudgetCodeD");
            this.cmbReqBudgetCodeD.Name = "cmbReqBudgetCodeD";
            this.cmbReqBudgetCodeD.NamedProperties.Put("EnumerateMethod", "");
            this.cmbReqBudgetCodeD.NamedProperties.Put("FieldFlags", "295");
            this.cmbReqBudgetCodeD.NamedProperties.Put("LovReference", "");
            this.cmbReqBudgetCodeD.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbReqBudgetCodeD.NamedProperties.Put("SqlColumn", "REQ_BUDGET_CODE_D");
            this.cmbReqBudgetCodeD.NamedProperties.Put("ValidateMethod", "");
            this.cmbReqBudgetCodeD.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbReqBudgetCodeD_WindowActions);
            // 
            // labelcmbReqBudgetCodeE
            // 
            resources.ApplyResources(this.labelcmbReqBudgetCodeE, "labelcmbReqBudgetCodeE");
            this.labelcmbReqBudgetCodeE.BackColor = System.Drawing.Color.Transparent;
            this.picTabs.SetControlTabPages(this.labelcmbReqBudgetCodeE, "tabBudgetDemand");
            this.labelcmbReqBudgetCodeE.Name = "labelcmbReqBudgetCodeE";
            // 
            // cmbReqBudgetCodeE
            // 
            this.picTabs.SetControlTabPages(this.cmbReqBudgetCodeE, "tabBudgetDemand");
            resources.ApplyResources(this.cmbReqBudgetCodeE, "cmbReqBudgetCodeE");
            this.cmbReqBudgetCodeE.Name = "cmbReqBudgetCodeE";
            this.cmbReqBudgetCodeE.NamedProperties.Put("EnumerateMethod", "");
            this.cmbReqBudgetCodeE.NamedProperties.Put("FieldFlags", "295");
            this.cmbReqBudgetCodeE.NamedProperties.Put("LovReference", "");
            this.cmbReqBudgetCodeE.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbReqBudgetCodeE.NamedProperties.Put("SqlColumn", "REQ_BUDGET_CODE_E");
            this.cmbReqBudgetCodeE.NamedProperties.Put("ValidateMethod", "");
            this.cmbReqBudgetCodeE.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbReqBudgetCodeE_WindowActions);
            // 
            // labelcmbReqBudgetCodeF
            // 
            resources.ApplyResources(this.labelcmbReqBudgetCodeF, "labelcmbReqBudgetCodeF");
            this.labelcmbReqBudgetCodeF.BackColor = System.Drawing.Color.Transparent;
            this.picTabs.SetControlTabPages(this.labelcmbReqBudgetCodeF, "tabBudgetDemand");
            this.labelcmbReqBudgetCodeF.Name = "labelcmbReqBudgetCodeF";
            // 
            // cmbReqBudgetCodeF
            // 
            this.picTabs.SetControlTabPages(this.cmbReqBudgetCodeF, "tabBudgetDemand");
            resources.ApplyResources(this.cmbReqBudgetCodeF, "cmbReqBudgetCodeF");
            this.cmbReqBudgetCodeF.Name = "cmbReqBudgetCodeF";
            this.cmbReqBudgetCodeF.NamedProperties.Put("EnumerateMethod", "");
            this.cmbReqBudgetCodeF.NamedProperties.Put("FieldFlags", "295");
            this.cmbReqBudgetCodeF.NamedProperties.Put("LovReference", "");
            this.cmbReqBudgetCodeF.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbReqBudgetCodeF.NamedProperties.Put("SqlColumn", "REQ_BUDGET_CODE_F");
            this.cmbReqBudgetCodeF.NamedProperties.Put("ValidateMethod", "");
            this.cmbReqBudgetCodeF.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbReqBudgetCodeF_WindowActions);
            // 
            // labelcmbReqBudgetCodeG
            // 
            resources.ApplyResources(this.labelcmbReqBudgetCodeG, "labelcmbReqBudgetCodeG");
            this.labelcmbReqBudgetCodeG.BackColor = System.Drawing.Color.Transparent;
            this.picTabs.SetControlTabPages(this.labelcmbReqBudgetCodeG, "tabBudgetDemand");
            this.labelcmbReqBudgetCodeG.Name = "labelcmbReqBudgetCodeG";
            // 
            // cmbReqBudgetCodeG
            // 
            this.picTabs.SetControlTabPages(this.cmbReqBudgetCodeG, "tabBudgetDemand");
            resources.ApplyResources(this.cmbReqBudgetCodeG, "cmbReqBudgetCodeG");
            this.cmbReqBudgetCodeG.Name = "cmbReqBudgetCodeG";
            this.cmbReqBudgetCodeG.NamedProperties.Put("EnumerateMethod", "");
            this.cmbReqBudgetCodeG.NamedProperties.Put("FieldFlags", "295");
            this.cmbReqBudgetCodeG.NamedProperties.Put("LovReference", "");
            this.cmbReqBudgetCodeG.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbReqBudgetCodeG.NamedProperties.Put("SqlColumn", "REQ_BUDGET_CODE_G");
            this.cmbReqBudgetCodeG.NamedProperties.Put("ValidateMethod", "");
            this.cmbReqBudgetCodeG.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbReqBudgetCodeG_WindowActions);
            // 
            // labelcmbReqBudgetCodeH
            // 
            resources.ApplyResources(this.labelcmbReqBudgetCodeH, "labelcmbReqBudgetCodeH");
            this.labelcmbReqBudgetCodeH.BackColor = System.Drawing.Color.Transparent;
            this.picTabs.SetControlTabPages(this.labelcmbReqBudgetCodeH, "tabBudgetDemand");
            this.labelcmbReqBudgetCodeH.Name = "labelcmbReqBudgetCodeH";
            // 
            // cmbReqBudgetCodeH
            // 
            this.picTabs.SetControlTabPages(this.cmbReqBudgetCodeH, "tabBudgetDemand");
            resources.ApplyResources(this.cmbReqBudgetCodeH, "cmbReqBudgetCodeH");
            this.cmbReqBudgetCodeH.Name = "cmbReqBudgetCodeH";
            this.cmbReqBudgetCodeH.NamedProperties.Put("EnumerateMethod", "");
            this.cmbReqBudgetCodeH.NamedProperties.Put("FieldFlags", "295");
            this.cmbReqBudgetCodeH.NamedProperties.Put("LovReference", "");
            this.cmbReqBudgetCodeH.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbReqBudgetCodeH.NamedProperties.Put("SqlColumn", "REQ_BUDGET_CODE_H");
            this.cmbReqBudgetCodeH.NamedProperties.Put("ValidateMethod", "");
            this.cmbReqBudgetCodeH.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbReqBudgetCodeH_WindowActions);
            // 
            // labelcmbReqBudgetCodeI
            // 
            resources.ApplyResources(this.labelcmbReqBudgetCodeI, "labelcmbReqBudgetCodeI");
            this.labelcmbReqBudgetCodeI.BackColor = System.Drawing.Color.Transparent;
            this.picTabs.SetControlTabPages(this.labelcmbReqBudgetCodeI, "tabBudgetDemand");
            this.labelcmbReqBudgetCodeI.Name = "labelcmbReqBudgetCodeI";
            // 
            // cmbReqBudgetCodeI
            // 
            this.picTabs.SetControlTabPages(this.cmbReqBudgetCodeI, "tabBudgetDemand");
            resources.ApplyResources(this.cmbReqBudgetCodeI, "cmbReqBudgetCodeI");
            this.cmbReqBudgetCodeI.Name = "cmbReqBudgetCodeI";
            this.cmbReqBudgetCodeI.NamedProperties.Put("EnumerateMethod", "");
            this.cmbReqBudgetCodeI.NamedProperties.Put("FieldFlags", "295");
            this.cmbReqBudgetCodeI.NamedProperties.Put("LovReference", "");
            this.cmbReqBudgetCodeI.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbReqBudgetCodeI.NamedProperties.Put("SqlColumn", "REQ_BUDGET_CODE_I");
            this.cmbReqBudgetCodeI.NamedProperties.Put("ValidateMethod", "");
            this.cmbReqBudgetCodeI.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbReqBudgetCodeI_WindowActions);
            // 
            // labelcmbReqBudgetCodeJ
            // 
            resources.ApplyResources(this.labelcmbReqBudgetCodeJ, "labelcmbReqBudgetCodeJ");
            this.labelcmbReqBudgetCodeJ.BackColor = System.Drawing.Color.Transparent;
            this.picTabs.SetControlTabPages(this.labelcmbReqBudgetCodeJ, "tabBudgetDemand");
            this.labelcmbReqBudgetCodeJ.Name = "labelcmbReqBudgetCodeJ";
            // 
            // cmbReqBudgetCodeJ
            // 
            this.picTabs.SetControlTabPages(this.cmbReqBudgetCodeJ, "tabBudgetDemand");
            resources.ApplyResources(this.cmbReqBudgetCodeJ, "cmbReqBudgetCodeJ");
            this.cmbReqBudgetCodeJ.Name = "cmbReqBudgetCodeJ";
            this.cmbReqBudgetCodeJ.NamedProperties.Put("EnumerateMethod", "");
            this.cmbReqBudgetCodeJ.NamedProperties.Put("FieldFlags", "295");
            this.cmbReqBudgetCodeJ.NamedProperties.Put("LovReference", "");
            this.cmbReqBudgetCodeJ.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbReqBudgetCodeJ.NamedProperties.Put("SqlColumn", "REQ_BUDGET_CODE_J");
            this.cmbReqBudgetCodeJ.NamedProperties.Put("ValidateMethod", "");
            this.cmbReqBudgetCodeJ.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbReqBudgetCodeJ_WindowActions);
            // 
            // labelcmbReqBudgetQuantity
            // 
            resources.ApplyResources(this.labelcmbReqBudgetQuantity, "labelcmbReqBudgetQuantity");
            this.labelcmbReqBudgetQuantity.BackColor = System.Drawing.Color.Transparent;
            this.picTabs.SetControlTabPages(this.labelcmbReqBudgetQuantity, "tabBudgetDemand");
            this.labelcmbReqBudgetQuantity.Name = "labelcmbReqBudgetQuantity";
            // 
            // cmbReqBudgetQuantity
            // 
            this.picTabs.SetControlTabPages(this.cmbReqBudgetQuantity, "tabBudgetDemand");
            resources.ApplyResources(this.cmbReqBudgetQuantity, "cmbReqBudgetQuantity");
            this.cmbReqBudgetQuantity.Name = "cmbReqBudgetQuantity";
            this.cmbReqBudgetQuantity.NamedProperties.Put("EnumerateMethod", "");
            this.cmbReqBudgetQuantity.NamedProperties.Put("FieldFlags", "295");
            this.cmbReqBudgetQuantity.NamedProperties.Put("LovReference", "");
            this.cmbReqBudgetQuantity.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbReqBudgetQuantity.NamedProperties.Put("SqlColumn", "REQ_BUDGET_QUANTITY");
            this.cmbReqBudgetQuantity.NamedProperties.Put("ValidateMethod", "");
            this.cmbReqBudgetQuantity.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbReqBudgetQuantity_WindowActions);
            // 
            // gbValid
            // 
            this.gbValid.BackColor = System.Drawing.Color.Transparent;
            this.picTabs.SetControlTabPages(this.gbValid, "tabBasic");
            resources.ApplyResources(this.gbValid, "gbValid");
            this.gbValid.Name = "gbValid";
            this.gbValid.TabStop = false;
            // 
            // gbArchiving_Options
            // 
            this.gbArchiving_Options.BackColor = System.Drawing.Color.Transparent;
            this.gbArchiving_Options.Controls.Add(this.rbMatchedTrans);
            this.gbArchiving_Options.Controls.Add(this.rbAllTrans);
            this.picTabs.SetControlTabPages(this.gbArchiving_Options, "tabBasic");
            resources.ApplyResources(this.gbArchiving_Options, "gbArchiving_Options");
            this.gbArchiving_Options.Name = "gbArchiving_Options";
            this.gbArchiving_Options.TabStop = false;
            // 
            // rbMatchedTrans
            // 
            this.rbMatchedTrans.BackColor = System.Drawing.Color.Transparent;
            this.picTabs.SetControlTabPages(this.rbMatchedTrans, "tabBasic");
            resources.ApplyResources(this.rbMatchedTrans, "rbMatchedTrans");
            this.rbMatchedTrans.Name = "rbMatchedTrans";
            this.rbMatchedTrans.UseVisualStyleBackColor = false;
            this.rbMatchedTrans.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.rbMatchedTrans_WindowActions);
            // 
            // rbAllTrans
            // 
            this.rbAllTrans.BackColor = System.Drawing.Color.Transparent;
            this.picTabs.SetControlTabPages(this.rbAllTrans, "tabBasic");
            resources.ApplyResources(this.rbAllTrans, "rbAllTrans");
            this.rbAllTrans.Name = "rbAllTrans";
            this.rbAllTrans.UseVisualStyleBackColor = false;
            this.rbAllTrans.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.rbAllTrans_WindowActions);
            // 
            // labeldfNoArchiveTrans
            // 
            resources.ApplyResources(this.labeldfNoArchiveTrans, "labeldfNoArchiveTrans");
            this.labeldfNoArchiveTrans.Name = "labeldfNoArchiveTrans";
            // 
            // dfNoArchiveTrans
            // 
            resources.ApplyResources(this.dfNoArchiveTrans, "dfNoArchiveTrans");
            this.dfNoArchiveTrans.Name = "dfNoArchiveTrans";
            this.dfNoArchiveTrans.NamedProperties.Put("EnumerateMethod", "");
            this.dfNoArchiveTrans.NamedProperties.Put("FieldFlags", "263");
            this.dfNoArchiveTrans.NamedProperties.Put("LovReference", "");
            this.dfNoArchiveTrans.NamedProperties.Put("ResizeableChildObject", "");
            this.dfNoArchiveTrans.NamedProperties.Put("SqlColumn", "ARCHIVING_TRANS_VALUE_DB");
            this.dfNoArchiveTrans.NamedProperties.Put("ValidateMethod", "");
            // 
            // dfsCodePart
            // 
            resources.ApplyResources(this.dfsCodePart, "dfsCodePart");
            this.dfsCodePart.Name = "dfsCodePart";
            // 
            // menuFrmMethods
            // 
            this.menuFrmMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_Code,
            this.menuItem__Tax,
            this.menuSeparator1,
            this.menuItem__Code,
            this.menuItem__Project,
            this.menuSeparator2,
            this.menuItem_Translation,
            this.menuSeparator3,
            this.menuItem__Notes,
            this.menuSeparator4,
            this.menuItem_Change});
            this.menuFrmMethods.Name = "menuFrmMethods";
            resources.ApplyResources(this.menuFrmMethods, "menuFrmMethods");
            // 
            // menuItem_Code
            // 
            this.menuItem_Code.Command = this.menuFrmMethods_menuCode__String_Completion___;
            this.menuItem_Code.Name = "menuItem_Code";
            resources.ApplyResources(this.menuItem_Code, "menuItem_Code");
            this.menuItem_Code.Text = "Code &String Completion...";
            // 
            // menuItem__Tax
            // 
            this.menuItem__Tax.Command = this.menuFrmMethods_menu_Tax_Codes_per_Account___;
            this.menuItem__Tax.Name = "menuItem__Tax";
            resources.ApplyResources(this.menuItem__Tax, "menuItem__Tax");
            this.menuItem__Tax.Text = "&Tax Codes per Account...";
            // 
            // menuSeparator1
            // 
            this.menuSeparator1.Name = "menuSeparator1";
            resources.ApplyResources(this.menuSeparator1, "menuSeparator1");
            // 
            // menuItem__Code
            // 
            this.menuItem__Code.Command = this.menuFrmMethods_menu_Code_Part_Attribute_Connection_;
            this.menuItem__Code.Name = "menuItem__Code";
            resources.ApplyResources(this.menuItem__Code, "menuItem__Code");
            this.menuItem__Code.Text = "&Code Part Attribute Connection...";
            // 
            // menuItem__Project
            // 
            this.menuItem__Project.Command = this.menuFrmMethods_menu_Project_Cost_Revenue_Element_pe;
            this.menuItem__Project.Name = "menuItem__Project";
            resources.ApplyResources(this.menuItem__Project, "menuItem__Project");
            this.menuItem__Project.Text = "&Project Cost/Revenue Element per Code Part Value...";
            // 
            // menuSeparator2
            // 
            this.menuSeparator2.Name = "menuSeparator2";
            resources.ApplyResources(this.menuSeparator2, "menuSeparator2");
            // 
            // menuItem_Translation
            // 
            this.menuItem_Translation.Command = this.menuFrmMethods_menuTrans_lation___;
            this.menuItem_Translation.Name = "menuItem_Translation";
            resources.ApplyResources(this.menuItem_Translation, "menuItem_Translation");
            this.menuItem_Translation.Text = "Trans&lation...";
            // 
            // menuSeparator3
            // 
            this.menuSeparator3.Name = "menuSeparator3";
            resources.ApplyResources(this.menuSeparator3, "menuSeparator3");
            // 
            // menuItem__Notes
            // 
            this.menuItem__Notes.Command = this.menuFrmMethods_menu_Notes___;
            this.menuItem__Notes.Name = "menuItem__Notes";
            resources.ApplyResources(this.menuItem__Notes, "menuItem__Notes");
            this.menuItem__Notes.Text = "&Notes...";
            // 
            // menuSeparator4
            // 
            this.menuSeparator4.Name = "menuSeparator4";
            resources.ApplyResources(this.menuSeparator4, "menuSeparator4");
            // 
            // menuItem_Change
            // 
            this.menuItem_Change.Command = this.menuFrmMethods_menuChange__Company___;
            this.menuItem_Change.Name = "menuItem_Change";
            resources.ApplyResources(this.menuItem_Change, "menuItem_Change");
            this.menuItem_Change.Text = "Change &Company...";
            // 
            // gbProjects
            // 
            this.gbProjects.BackColor = System.Drawing.Color.Transparent;
            this.gbProjects.Controls.Add(this.cbExcludeProjFollowup);
            this.gbProjects.Controls.Add(this.cmbExcludePeriodicalCap);
            this.picTabs.SetControlTabPages(this.gbProjects, "tabBasic");
            resources.ApplyResources(this.gbProjects, "gbProjects");
            this.gbProjects.Name = "gbProjects";
            this.gbProjects.TabStop = false;
            // 
            // cbExcludeProjFollowup
            // 
            resources.ApplyResources(this.cbExcludeProjFollowup, "cbExcludeProjFollowup");
            this.cbExcludeProjFollowup.BackColor = System.Drawing.Color.Transparent;
            this.picTabs.SetControlTabPages(this.cbExcludeProjFollowup, "tabBasic");
            this.cbExcludeProjFollowup.Name = "cbExcludeProjFollowup";
            this.cbExcludeProjFollowup.NamedProperties.Put("DataType", "5");
            this.cbExcludeProjFollowup.NamedProperties.Put("EnumerateMethod", "");
            this.cbExcludeProjFollowup.NamedProperties.Put("FieldFlags", "294");
            this.cbExcludeProjFollowup.NamedProperties.Put("LovReference", "");
            this.cbExcludeProjFollowup.NamedProperties.Put("ResizeableChildObject", "");
            this.cbExcludeProjFollowup.NamedProperties.Put("SqlColumn", "EXCLUDE_PROJ_FOLLOWUP");
            this.cbExcludeProjFollowup.NamedProperties.Put("ValidateMethod", "");
            this.cbExcludeProjFollowup.NamedProperties.Put("XDataLength", "5");
            this.cbExcludeProjFollowup.UseVisualStyleBackColor = false;
            this.cbExcludeProjFollowup.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cbExcludeProjFollowup_WindowActions);
            // 
            // cmbExcludePeriodicalCap
            // 
            this.picTabs.SetControlTabPages(this.cmbExcludePeriodicalCap, "tabBasic");
            this.cmbExcludePeriodicalCap.FormattingEnabled = true;
            resources.ApplyResources(this.cmbExcludePeriodicalCap, "cmbExcludePeriodicalCap");
            this.cmbExcludePeriodicalCap.Name = "cmbExcludePeriodicalCap";
            this.cmbExcludePeriodicalCap.NamedProperties.Put("EnumerateMethod", "EXCLUDE_PERIODICAL_CAP_API.Enumerate");
            this.cmbExcludePeriodicalCap.NamedProperties.Put("FieldFlags", "295");
            this.cmbExcludePeriodicalCap.NamedProperties.Put("SqlColumn", "EXCLUDE_PERIODICAL_CAP");
            this.cmbExcludePeriodicalCap.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbExcludePeriodicalCap_WindowActions);
            // 
            // labelcmbExcludePeriodicalCap
            // 
            resources.ApplyResources(this.labelcmbExcludePeriodicalCap, "labelcmbExcludePeriodicalCap");
            this.labelcmbExcludePeriodicalCap.BackColor = System.Drawing.Color.Transparent;
            this.picTabs.SetControlTabPages(this.labelcmbExcludePeriodicalCap, "tabBasic");
            this.labelcmbExcludePeriodicalCap.Name = "labelcmbExcludePeriodicalCap";
            // 
            // cbExcludeCurrTrans
            // 
            resources.ApplyResources(this.cbExcludeCurrTrans, "cbExcludeCurrTrans");
            this.cbExcludeCurrTrans.BackColor = System.Drawing.Color.Transparent;
            this.cbExcludeCurrTrans.CheckedValue = "TRUE";
            this.picTabs.SetControlTabPages(this.cbExcludeCurrTrans, "tabBasic");
            this.cbExcludeCurrTrans.Name = "cbExcludeCurrTrans";
            this.cbExcludeCurrTrans.NamedProperties.Put("EnumerateMethod", "");
            this.cbExcludeCurrTrans.NamedProperties.Put("FieldFlags", "294");
            this.cbExcludeCurrTrans.NamedProperties.Put("LovReference", "");
            this.cbExcludeCurrTrans.NamedProperties.Put("ResizeableChildObject", "");
            this.cbExcludeCurrTrans.NamedProperties.Put("SqlColumn", "EXCLUDE_FROM_CURR_TRANS_DB");
            this.cbExcludeCurrTrans.NamedProperties.Put("ValidateMethod", "");
            this.cbExcludeCurrTrans.NamedProperties.Put("XDataLength", "1");
            this.cbExcludeCurrTrans.UncheckedValue = "FALSE";
            this.cbExcludeCurrTrans.UseVisualStyleBackColor = false;
            this.cbExcludeCurrTrans.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cbExcludeCurrTrans_WindowActions);
            // 
            // frmTabAccount
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.cbExcludeCurrTrans);
            this.Controls.Add(this.cmbTaxHandlingValue);
            this.Controls.Add(this.cbTaxCodeMandatory);
            this.Controls.Add(this.labelcmbTaxHandlingValue);
            this.Controls.Add(this.dfsCodePart);
            this.Controls.Add(this.cbTaxAccount);
            this.Controls.Add(this.cbLedgFlag);
            this.Controls.Add(this.cbCurrBalance);
            this.Controls.Add(this.cbBudAccount);
            this.Controls.Add(this.cbStatisticalAccount);
            this.Controls.Add(this.gbOptions);
            this.Controls.Add(this.labelcmbExcludePeriodicalCap);
            this.Controls.Add(this.gbProjects);
            this.Controls.Add(this.dfNoArchiveTrans);
            this.Controls.Add(this.dfConsCompany);
            this.Controls.Add(this.dfsConsolidAccntDescription);
            this.Controls.Add(this.dfsConsolidAccount);
            this.Controls.Add(this.mlsText);
            this.Controls.Add(this.dfdtValidUntil);
            this.Controls.Add(this.dfdtValidFrom);
            this.Controls.Add(this.dfsAccountGroupDescription);
            this.Controls.Add(this.dfsAccountGroup);
            this.Controls.Add(this.dfsLogicalAccountType);
            this.Controls.Add(this.dfsAccountTypeDescription);
            this.Controls.Add(this.dfsAccountType);
            this.Controls.Add(this.dfsCompany);
            this.Controls.Add(this.dfsDescription);
            this.Controls.Add(this.cmbAccount);
            this.Controls.Add(this.cbCodeStr);
            this.Controls.Add(this.cbAttribute);
            this.Controls.Add(this.cbFreeText);
            this.Controls.Add(this.cmbCostCenter);
            this.Controls.Add(this.cmbCodeC);
            this.Controls.Add(this.cmbCodeD);
            this.Controls.Add(this.cmbObject);
            this.Controls.Add(this.cmbProject);
            this.Controls.Add(this.cmbCodeG);
            this.Controls.Add(this.cmbCodeH);
            this.Controls.Add(this.cmbCodeI);
            this.Controls.Add(this.cmbCodeJ);
            this.Controls.Add(this.cmbQuantity);
            this.Controls.Add(this.cmbReqProcessCode);
            this.Controls.Add(this.cmbText);
            this.Controls.Add(this.cmbReqBudgetCodeB);
            this.Controls.Add(this.cmbReqBudgetCodeC);
            this.Controls.Add(this.cmbReqBudgetCodeD);
            this.Controls.Add(this.cmbReqBudgetCodeE);
            this.Controls.Add(this.cmbReqBudgetCodeF);
            this.Controls.Add(this.cmbReqBudgetCodeG);
            this.Controls.Add(this.cmbReqBudgetCodeH);
            this.Controls.Add(this.cmbReqBudgetCodeI);
            this.Controls.Add(this.cmbReqBudgetCodeJ);
            this.Controls.Add(this.cmbReqBudgetQuantity);
            this.Controls.Add(this.labeldfNoArchiveTrans);
            this.Controls.Add(this.labelcmbReqBudgetCodeB);
            this.Controls.Add(this.labelcmbReqBudgetCodeC);
            this.Controls.Add(this.labelcmbReqBudgetCodeD);
            this.Controls.Add(this.labelcmbReqBudgetCodeE);
            this.Controls.Add(this.labelcmbReqBudgetCodeF);
            this.Controls.Add(this.labelcmbReqBudgetCodeG);
            this.Controls.Add(this.labelcmbReqBudgetCodeH);
            this.Controls.Add(this.labelcmbReqBudgetCodeI);
            this.Controls.Add(this.labelcmbReqBudgetCodeJ);
            this.Controls.Add(this.labelcmbReqBudgetQuantity);
            this.Controls.Add(this.labeldfsConsolidAccntDescription);
            this.Controls.Add(this.labeldfsAccountGroup);
            this.Controls.Add(this.labeldfsAccountGroupDescription);
            this.Controls.Add(this.labeldfdtValidFrom);
            this.Controls.Add(this.labeldfdtValidUntil);
            this.Controls.Add(this.labelcmbCostCenter);
            this.Controls.Add(this.labelcmbCodeC);
            this.Controls.Add(this.labelcmbCodeD);
            this.Controls.Add(this.labelcmbObject);
            this.Controls.Add(this.labelcmbProject);
            this.Controls.Add(this.labelcmbCodeG);
            this.Controls.Add(this.labelcmbCodeH);
            this.Controls.Add(this.labelcmbCodeI);
            this.Controls.Add(this.labelcmbCodeJ);
            this.Controls.Add(this.labelcmbQuantity);
            this.Controls.Add(this.labelcmbReqProcessCode);
            this.Controls.Add(this.labelcmbText);
            this.Controls.Add(this.labeldfsConsolidAccount);
            this.Controls.Add(this.labeldfsLogicalAccountType);
            this.Controls.Add(this.labeldfsAccountTypeDescription);
            this.Controls.Add(this.labeldfsAccountType);
            this.Controls.Add(this.labeldfsDescription);
            this.Controls.Add(this.labelcmbAccount);
            this.Controls.Add(this.gbValid);
            this.Controls.Add(this.gbArchiving_Options);
            this.Controls.Add(this.gbTax_Options);
            this.Name = "frmTabAccount";
            this.NamedProperties.Put("DefaultOrderBy", "SORT_VALUE");
            this.NamedProperties.Put("DefaultWhere", "COMPANY= :global.company");
            this.NamedProperties.Put("LogicalUnit", "Account");
            this.NamedProperties.Put("PackageName", "ACCOUNT_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "0");
            this.NamedProperties.Put("ViewName", "ACCOUNT");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.frmTabAccount_WindowActions);
            this.Controls.SetChildIndex(this.gbTax_Options, 0);
            this.Controls.SetChildIndex(this.picTabs, 0);
            this.Controls.SetChildIndex(this.gbArchiving_Options, 0);
            this.Controls.SetChildIndex(this.gbValid, 0);
            this.Controls.SetChildIndex(this.labelcmbAccount, 0);
            this.Controls.SetChildIndex(this.labeldfsDescription, 0);
            this.Controls.SetChildIndex(this.labeldfsAccountType, 0);
            this.Controls.SetChildIndex(this.labeldfsAccountTypeDescription, 0);
            this.Controls.SetChildIndex(this.labeldfsLogicalAccountType, 0);
            this.Controls.SetChildIndex(this.labeldfsConsolidAccount, 0);
            this.Controls.SetChildIndex(this.labelcmbText, 0);
            this.Controls.SetChildIndex(this.labelcmbReqProcessCode, 0);
            this.Controls.SetChildIndex(this.labelcmbQuantity, 0);
            this.Controls.SetChildIndex(this.labelcmbCodeJ, 0);
            this.Controls.SetChildIndex(this.labelcmbCodeI, 0);
            this.Controls.SetChildIndex(this.labelcmbCodeH, 0);
            this.Controls.SetChildIndex(this.labelcmbCodeG, 0);
            this.Controls.SetChildIndex(this.labelcmbProject, 0);
            this.Controls.SetChildIndex(this.labelcmbObject, 0);
            this.Controls.SetChildIndex(this.labelcmbCodeD, 0);
            this.Controls.SetChildIndex(this.labelcmbCodeC, 0);
            this.Controls.SetChildIndex(this.labelcmbCostCenter, 0);
            this.Controls.SetChildIndex(this.labeldfdtValidUntil, 0);
            this.Controls.SetChildIndex(this.labeldfdtValidFrom, 0);
            this.Controls.SetChildIndex(this.labeldfsAccountGroupDescription, 0);
            this.Controls.SetChildIndex(this.labeldfsAccountGroup, 0);
            this.Controls.SetChildIndex(this.labeldfsConsolidAccntDescription, 0);
            this.Controls.SetChildIndex(this.labelcmbReqBudgetQuantity, 0);
            this.Controls.SetChildIndex(this.labelcmbReqBudgetCodeJ, 0);
            this.Controls.SetChildIndex(this.labelcmbReqBudgetCodeI, 0);
            this.Controls.SetChildIndex(this.labelcmbReqBudgetCodeH, 0);
            this.Controls.SetChildIndex(this.labelcmbReqBudgetCodeG, 0);
            this.Controls.SetChildIndex(this.labelcmbReqBudgetCodeF, 0);
            this.Controls.SetChildIndex(this.labelcmbReqBudgetCodeE, 0);
            this.Controls.SetChildIndex(this.labelcmbReqBudgetCodeD, 0);
            this.Controls.SetChildIndex(this.labelcmbReqBudgetCodeC, 0);
            this.Controls.SetChildIndex(this.labelcmbReqBudgetCodeB, 0);
            this.Controls.SetChildIndex(this.labeldfNoArchiveTrans, 0);
            this.Controls.SetChildIndex(this.cmbReqBudgetQuantity, 0);
            this.Controls.SetChildIndex(this.cmbReqBudgetCodeJ, 0);
            this.Controls.SetChildIndex(this.cmbReqBudgetCodeI, 0);
            this.Controls.SetChildIndex(this.cmbReqBudgetCodeH, 0);
            this.Controls.SetChildIndex(this.cmbReqBudgetCodeG, 0);
            this.Controls.SetChildIndex(this.cmbReqBudgetCodeF, 0);
            this.Controls.SetChildIndex(this.cmbReqBudgetCodeE, 0);
            this.Controls.SetChildIndex(this.cmbReqBudgetCodeD, 0);
            this.Controls.SetChildIndex(this.cmbReqBudgetCodeC, 0);
            this.Controls.SetChildIndex(this.cmbReqBudgetCodeB, 0);
            this.Controls.SetChildIndex(this.cmbText, 0);
            this.Controls.SetChildIndex(this.cmbReqProcessCode, 0);
            this.Controls.SetChildIndex(this.cmbQuantity, 0);
            this.Controls.SetChildIndex(this.cmbCodeJ, 0);
            this.Controls.SetChildIndex(this.cmbCodeI, 0);
            this.Controls.SetChildIndex(this.cmbCodeH, 0);
            this.Controls.SetChildIndex(this.cmbCodeG, 0);
            this.Controls.SetChildIndex(this.cmbProject, 0);
            this.Controls.SetChildIndex(this.cmbObject, 0);
            this.Controls.SetChildIndex(this.cmbCodeD, 0);
            this.Controls.SetChildIndex(this.cmbCodeC, 0);
            this.Controls.SetChildIndex(this.cmbCostCenter, 0);
            this.Controls.SetChildIndex(this.cbFreeText, 0);
            this.Controls.SetChildIndex(this.cbAttribute, 0);
            this.Controls.SetChildIndex(this.cbCodeStr, 0);
            this.Controls.SetChildIndex(this.cmbAccount, 0);
            this.Controls.SetChildIndex(this.dfsDescription, 0);
            this.Controls.SetChildIndex(this.dfsCompany, 0);
            this.Controls.SetChildIndex(this.dfsAccountType, 0);
            this.Controls.SetChildIndex(this.dfsAccountTypeDescription, 0);
            this.Controls.SetChildIndex(this.dfsLogicalAccountType, 0);
            this.Controls.SetChildIndex(this.dfsAccountGroup, 0);
            this.Controls.SetChildIndex(this.dfsAccountGroupDescription, 0);
            this.Controls.SetChildIndex(this.dfdtValidFrom, 0);
            this.Controls.SetChildIndex(this.dfdtValidUntil, 0);
            this.Controls.SetChildIndex(this.mlsText, 0);
            this.Controls.SetChildIndex(this.dfsConsolidAccount, 0);
            this.Controls.SetChildIndex(this.dfsConsolidAccntDescription, 0);
            this.Controls.SetChildIndex(this.dfConsCompany, 0);
            this.Controls.SetChildIndex(this.dfNoArchiveTrans, 0);
            this.Controls.SetChildIndex(this.gbProjects, 0);
            this.Controls.SetChildIndex(this.labelcmbExcludePeriodicalCap, 0);
            this.Controls.SetChildIndex(this.gbOptions, 0);
            this.Controls.SetChildIndex(this.cbStatisticalAccount, 0);
            this.Controls.SetChildIndex(this.cbBudAccount, 0);
            this.Controls.SetChildIndex(this.cbCurrBalance, 0);
            this.Controls.SetChildIndex(this.cbLedgFlag, 0);
            this.Controls.SetChildIndex(this.cbTaxAccount, 0);
            this.Controls.SetChildIndex(this.dfsCodePart, 0);
            this.Controls.SetChildIndex(this.labelcmbTaxHandlingValue, 0);
            this.Controls.SetChildIndex(this.cbTaxCodeMandatory, 0);
            this.Controls.SetChildIndex(this.cmbTaxHandlingValue, 0);
            this.Controls.SetChildIndex(this.cbExcludeCurrTrans, 0);
            this.gbArchiving_Options.ResumeLayout(false);
            this.gbArchiving_Options.PerformLayout();
            this.menuFrmMethods.ResumeLayout(false);
            this.gbProjects.ResumeLayout(false);
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

        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menuCode__String_Completion___;
        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menu_Tax_Codes_per_Account___;
        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menu_Code_Part_Attribute_Connection_;
        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menu_Project_Cost_Revenue_Element_pe;
        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menuTrans_lation___;
        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menu_Notes___;
        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menuChange__Company___;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuFrmMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Code;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Tax;
        protected Fnd.Windows.Forms.FndToolStripSeparator menuSeparator1;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Code;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Project;
        protected Fnd.Windows.Forms.FndToolStripSeparator menuSeparator2;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Translation;
        protected Fnd.Windows.Forms.FndToolStripSeparator menuSeparator3;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Notes;
        protected Fnd.Windows.Forms.FndToolStripSeparator menuSeparator4;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change;
        protected SalGroupBox gbProjects;
        protected cComboBox cmbExcludePeriodicalCap;
        protected cBackgroundText labelcmbExcludePeriodicalCap;
        public cCheckBox cbExcludeProjFollowup;
        public cRadioButton rbAllTrans;
        public cRadioButton rbMatchedTrans;
        public cCheckBox cbExcludeCurrTrans;
	}
}
