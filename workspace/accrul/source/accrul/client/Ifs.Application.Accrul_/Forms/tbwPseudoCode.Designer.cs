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
	
	public partial class tbwPseudoCode
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cColumn colsCompany;
		public cColumn colsPseudoCode;
		public cColumn colsDescription;
		public cColumnFin colsAccount;
		public cColumnFin colsAccountDesc;
		public cColumnFin colsCodeB;
		public cColumnFin colsCodeBDesc;
		public cColumnFin colsCodeC;
		public cColumnFin colsCodeCDesc;
		public cColumnFin colsCodeD;
		public cColumnFin colsCodeDDesc;
		public cColumnFin colsCodeE;
		public cColumnFin colsCodeEDesc;
		public cColumnFin colsCodeF;
		public cColumnFin colsCodeFDesc;
		public cColumnFin colsCodeG;
		public cColumnFin colsCodeGDesc;
		public cColumnFin colsCodeH;
		public cColumnFin colsCodeHDesc;
		public cColumnFin colsCodeI;
		public cColumnFin colsCodeIDesc;
		public cColumnFin colsCodeJ;
		public cColumnFin colsCodeJDesc;
		public cColumn colsProcessCodeP;
		public cColumn colsText;
		public cColumn colnQuantity;
		public cColumn colsCodePart;
		public cColumn colsCodeDemand;
		public cLookupColumn colsPseudoCodeOwnership;
		public cColumn colsUserName;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwPseudoCode));
            this.menuOperations_menu_Translation___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuOperations_menuChange__Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_menu_Translation___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_menuChange__Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.colsCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsPseudoCode = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsAccount = new Ifs.Application.Accrul.cColumnFin();
            this.colsAccountDesc = new Ifs.Application.Accrul.cColumnFin();
            this.colsCodeB = new Ifs.Application.Accrul.cColumnFin();
            this.colsCodeBDesc = new Ifs.Application.Accrul.cColumnFin();
            this.colsCodeC = new Ifs.Application.Accrul.cColumnFin();
            this.colsCodeCDesc = new Ifs.Application.Accrul.cColumnFin();
            this.colsCodeD = new Ifs.Application.Accrul.cColumnFin();
            this.colsCodeDDesc = new Ifs.Application.Accrul.cColumnFin();
            this.colsCodeE = new Ifs.Application.Accrul.cColumnFin();
            this.colsCodeEDesc = new Ifs.Application.Accrul.cColumnFin();
            this.colsCodeF = new Ifs.Application.Accrul.cColumnFin();
            this.colsCodeFDesc = new Ifs.Application.Accrul.cColumnFin();
            this.colsCodeG = new Ifs.Application.Accrul.cColumnFin();
            this.colsCodeGDesc = new Ifs.Application.Accrul.cColumnFin();
            this.colsCodeH = new Ifs.Application.Accrul.cColumnFin();
            this.colsCodeHDesc = new Ifs.Application.Accrul.cColumnFin();
            this.colsCodeI = new Ifs.Application.Accrul.cColumnFin();
            this.colsCodeIDesc = new Ifs.Application.Accrul.cColumnFin();
            this.colsCodeJ = new Ifs.Application.Accrul.cColumnFin();
            this.colsCodeJDesc = new Ifs.Application.Accrul.cColumnFin();
            this.colsProcessCodeP = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsText = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colnQuantity = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsCodePart = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsCodeDemand = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsPseudoCodeOwnership = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.colsUserName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.menuTbwMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem__Translation = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuSeparator1 = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.menuItem_Change = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuOperations = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem__Translation_1 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuSeparator2 = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.menuItem_Change_1 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.colnProjectActivityId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.menuTbwMethods.SuspendLayout();
            this.menuOperations.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuTbwMethods_menu_Translation___);
            this.commandManager.Commands.Add(this.menuTbwMethods_menuChange__Company___);
            this.commandManager.Commands.Add(this.menuOperations_menu_Translation___);
            this.commandManager.Commands.Add(this.menuOperations_menuChange__Company___);
            this.commandManager.ContextMenus.Add(this.menuTbwMethods);
            this.commandManager.ContextMenus.Add(this.menuOperations);
            // 
            // menuOperations_menu_Translation___
            // 
            resources.ApplyResources(this.menuOperations_menu_Translation___, "menuOperations_menu_Translation___");
            this.menuOperations_menu_Translation___.Name = "menuOperations_menu_Translation___";
            this.menuOperations_menu_Translation___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Translation_1_Execute);
            this.menuOperations_menu_Translation___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Translation_1_Inquire);
            // 
            // menuOperations_menuChange__Company___
            // 
            resources.ApplyResources(this.menuOperations_menuChange__Company___, "menuOperations_menuChange__Company___");
            this.menuOperations_menuChange__Company___.Name = "menuOperations_menuChange__Company___";
            this.menuOperations_menuChange__Company___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Change_1_Execute);
            this.menuOperations_menuChange__Company___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Change_1_Inquire);
            // 
            // menuTbwMethods_menu_Translation___
            // 
            resources.ApplyResources(this.menuTbwMethods_menu_Translation___, "menuTbwMethods_menu_Translation___");
            this.menuTbwMethods_menu_Translation___.Name = "menuTbwMethods_menu_Translation___";
            this.menuTbwMethods_menu_Translation___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Translation_Execute);
            this.menuTbwMethods_menu_Translation___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Translation_Inquire);
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
            this.colsCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.colsCompany, "colsCompany");
            this.colsCompany.MaxLength = 20;
            this.colsCompany.Name = "colsCompany";
            this.colsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.colsCompany.NamedProperties.Put("FieldFlags", "67");
            this.colsCompany.NamedProperties.Put("LovReference", "COMPANY_FINANCE");
            this.colsCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.colsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.colsCompany.NamedProperties.Put("ValidateMethod", "");
            this.colsCompany.Position = 3;
            // 
            // colsPseudoCode
            // 
            this.colsPseudoCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsPseudoCode.MaxLength = 20;
            this.colsPseudoCode.Name = "colsPseudoCode";
            this.colsPseudoCode.NamedProperties.Put("EnumerateMethod", "");
            this.colsPseudoCode.NamedProperties.Put("FieldFlags", "163");
            this.colsPseudoCode.NamedProperties.Put("LovReference", "");
            this.colsPseudoCode.NamedProperties.Put("ResizeableChildObject", "");
            this.colsPseudoCode.NamedProperties.Put("SqlColumn", "PSEUDO_CODE");
            this.colsPseudoCode.NamedProperties.Put("ValidateMethod", "");
            this.colsPseudoCode.Position = 4;
            resources.ApplyResources(this.colsPseudoCode, "colsPseudoCode");
            this.colsPseudoCode.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsPseudoCode_WindowActions);
            // 
            // colsDescription
            // 
            this.colsDescription.Name = "colsDescription";
            this.colsDescription.NamedProperties.Put("EnumerateMethod", "");
            this.colsDescription.NamedProperties.Put("FieldFlags", "295");
            this.colsDescription.NamedProperties.Put("LovReference", "");
            this.colsDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.colsDescription.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            this.colsDescription.NamedProperties.Put("ValidateMethod", "");
            this.colsDescription.Position = 5;
            resources.ApplyResources(this.colsDescription, "colsDescription");
            // 
            // colsAccount
            // 
            this.colsAccount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsAccount.MaxLength = 20;
            this.colsAccount.Name = "colsAccount";
            this.colsAccount.NamedProperties.Put("EnumerateMethod", "");
            this.colsAccount.NamedProperties.Put("FieldFlags", "295");
            this.colsAccount.NamedProperties.Put("LovReference", "ACCOUNT(COMPANY)");
            this.colsAccount.NamedProperties.Put("ResizeableChildObject", "");
            this.colsAccount.NamedProperties.Put("SqlColumn", "ACCOUNT");
            this.colsAccount.NamedProperties.Put("ValidateMethod", "");
            this.colsAccount.Position = 6;
            resources.ApplyResources(this.colsAccount, "colsAccount");
            this.colsAccount.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsAccount_WindowActions);
            // 
            // colsAccountDesc
            // 
            this.colsAccountDesc.Name = "colsAccountDesc";
            this.colsAccountDesc.NamedProperties.Put("EnumerateMethod", "");
            this.colsAccountDesc.NamedProperties.Put("FieldFlags", "2304");
            this.colsAccountDesc.NamedProperties.Put("LovReference", "");
            this.colsAccountDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.colsAccountDesc.NamedProperties.Put("SqlColumn", "ACCOUNT_DESC");
            this.colsAccountDesc.NamedProperties.Put("ValidateMethod", "");
            this.colsAccountDesc.Position = 7;
            resources.ApplyResources(this.colsAccountDesc, "colsAccountDesc");
            // 
            // colsCodeB
            // 
            this.colsCodeB.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsCodeB.MaxLength = 20;
            this.colsCodeB.Name = "colsCodeB";
            this.colsCodeB.NamedProperties.Put("EnumerateMethod", "");
            this.colsCodeB.NamedProperties.Put("FieldFlags", "294");
            this.colsCodeB.NamedProperties.Put("LovReference", "CODE_B(COMPANY)");
            this.colsCodeB.NamedProperties.Put("ResizeableChildObject", "");
            this.colsCodeB.NamedProperties.Put("SqlColumn", "CODE_B");
            this.colsCodeB.NamedProperties.Put("ValidateMethod", "");
            this.colsCodeB.Position = 8;
            resources.ApplyResources(this.colsCodeB, "colsCodeB");
            this.colsCodeB.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsCodeB_WindowActions);
            // 
            // colsCodeBDesc
            // 
            this.colsCodeBDesc.Name = "colsCodeBDesc";
            this.colsCodeBDesc.NamedProperties.Put("EnumerateMethod", "");
            this.colsCodeBDesc.NamedProperties.Put("FieldFlags", "2304");
            this.colsCodeBDesc.NamedProperties.Put("LovReference", "");
            this.colsCodeBDesc.NamedProperties.Put("SqlColumn", "CODE_B_DESC");
            this.colsCodeBDesc.NamedProperties.Put("ValidateMethod", "");
            this.colsCodeBDesc.Position = 9;
            resources.ApplyResources(this.colsCodeBDesc, "colsCodeBDesc");
            this.colsCodeBDesc.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsCodeBDesc_WindowActions);
            // 
            // colsCodeC
            // 
            this.colsCodeC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsCodeC.MaxLength = 20;
            this.colsCodeC.Name = "colsCodeC";
            this.colsCodeC.NamedProperties.Put("EnumerateMethod", "");
            this.colsCodeC.NamedProperties.Put("FieldFlags", "294");
            this.colsCodeC.NamedProperties.Put("LovReference", "CODE_C(COMPANY)");
            this.colsCodeC.NamedProperties.Put("ResizeableChildObject", "");
            this.colsCodeC.NamedProperties.Put("SqlColumn", "CODE_C");
            this.colsCodeC.NamedProperties.Put("ValidateMethod", "");
            this.colsCodeC.Position = 10;
            resources.ApplyResources(this.colsCodeC, "colsCodeC");
            this.colsCodeC.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsCodeC_WindowActions);
            // 
            // colsCodeCDesc
            // 
            this.colsCodeCDesc.Name = "colsCodeCDesc";
            this.colsCodeCDesc.NamedProperties.Put("EnumerateMethod", "");
            this.colsCodeCDesc.NamedProperties.Put("FieldFlags", "2304");
            this.colsCodeCDesc.NamedProperties.Put("LovReference", "");
            this.colsCodeCDesc.NamedProperties.Put("SqlColumn", "CODE_C_DESC");
            this.colsCodeCDesc.NamedProperties.Put("ValidateMethod", "");
            this.colsCodeCDesc.Position = 11;
            resources.ApplyResources(this.colsCodeCDesc, "colsCodeCDesc");
            this.colsCodeCDesc.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsCodeCDesc_WindowActions);
            // 
            // colsCodeD
            // 
            this.colsCodeD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsCodeD.MaxLength = 20;
            this.colsCodeD.Name = "colsCodeD";
            this.colsCodeD.NamedProperties.Put("EnumerateMethod", "");
            this.colsCodeD.NamedProperties.Put("FieldFlags", "294");
            this.colsCodeD.NamedProperties.Put("LovReference", "CODE_D(COMPANY)");
            this.colsCodeD.NamedProperties.Put("ResizeableChildObject", "");
            this.colsCodeD.NamedProperties.Put("SqlColumn", "CODE_D");
            this.colsCodeD.NamedProperties.Put("ValidateMethod", "");
            this.colsCodeD.Position = 12;
            resources.ApplyResources(this.colsCodeD, "colsCodeD");
            this.colsCodeD.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsCodeD_WindowActions);
            // 
            // colsCodeDDesc
            // 
            this.colsCodeDDesc.Name = "colsCodeDDesc";
            this.colsCodeDDesc.NamedProperties.Put("EnumerateMethod", "");
            this.colsCodeDDesc.NamedProperties.Put("FieldFlags", "2304");
            this.colsCodeDDesc.NamedProperties.Put("LovReference", "");
            this.colsCodeDDesc.NamedProperties.Put("SqlColumn", "CODE_D_DESC");
            this.colsCodeDDesc.NamedProperties.Put("ValidateMethod", "");
            this.colsCodeDDesc.Position = 13;
            resources.ApplyResources(this.colsCodeDDesc, "colsCodeDDesc");
            this.colsCodeDDesc.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsCodeDDesc_WindowActions);
            // 
            // colsCodeE
            // 
            this.colsCodeE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsCodeE.MaxLength = 20;
            this.colsCodeE.Name = "colsCodeE";
            this.colsCodeE.NamedProperties.Put("EnumerateMethod", "");
            this.colsCodeE.NamedProperties.Put("FieldFlags", "294");
            this.colsCodeE.NamedProperties.Put("LovReference", "CODE_E(COMPANY)");
            this.colsCodeE.NamedProperties.Put("ResizeableChildObject", "");
            this.colsCodeE.NamedProperties.Put("SqlColumn", "CODE_E");
            this.colsCodeE.NamedProperties.Put("ValidateMethod", "");
            this.colsCodeE.Position = 14;
            resources.ApplyResources(this.colsCodeE, "colsCodeE");
            this.colsCodeE.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsCodeE_WindowActions);
            // 
            // colsCodeEDesc
            // 
            this.colsCodeEDesc.Name = "colsCodeEDesc";
            this.colsCodeEDesc.NamedProperties.Put("EnumerateMethod", "");
            this.colsCodeEDesc.NamedProperties.Put("FieldFlags", "2304");
            this.colsCodeEDesc.NamedProperties.Put("LovReference", "");
            this.colsCodeEDesc.NamedProperties.Put("SqlColumn", "CODE_E_DESC");
            this.colsCodeEDesc.NamedProperties.Put("ValidateMethod", "");
            this.colsCodeEDesc.Position = 15;
            resources.ApplyResources(this.colsCodeEDesc, "colsCodeEDesc");
            this.colsCodeEDesc.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsCodeEDesc_WindowActions);
            // 
            // colsCodeF
            // 
            this.colsCodeF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsCodeF.MaxLength = 20;
            this.colsCodeF.Name = "colsCodeF";
            this.colsCodeF.NamedProperties.Put("EnumerateMethod", "");
            this.colsCodeF.NamedProperties.Put("FieldFlags", "294");
            this.colsCodeF.NamedProperties.Put("LovReference", "CODE_F(COMPANY)");
            this.colsCodeF.NamedProperties.Put("ResizeableChildObject", "");
            this.colsCodeF.NamedProperties.Put("SqlColumn", "CODE_F");
            this.colsCodeF.NamedProperties.Put("ValidateMethod", "");
            this.colsCodeF.Position = 16;
            resources.ApplyResources(this.colsCodeF, "colsCodeF");
            this.colsCodeF.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsCodeF_WindowActions);
            // 
            // colsCodeFDesc
            // 
            this.colsCodeFDesc.Name = "colsCodeFDesc";
            this.colsCodeFDesc.NamedProperties.Put("EnumerateMethod", "");
            this.colsCodeFDesc.NamedProperties.Put("FieldFlags", "2304");
            this.colsCodeFDesc.NamedProperties.Put("LovReference", "");
            this.colsCodeFDesc.NamedProperties.Put("SqlColumn", "CODE_F_DESC");
            this.colsCodeFDesc.NamedProperties.Put("ValidateMethod", "");
            this.colsCodeFDesc.Position = 17;
            resources.ApplyResources(this.colsCodeFDesc, "colsCodeFDesc");
            this.colsCodeFDesc.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsCodeFDesc_WindowActions);
            // 
            // colsCodeG
            // 
            this.colsCodeG.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsCodeG.MaxLength = 20;
            this.colsCodeG.Name = "colsCodeG";
            this.colsCodeG.NamedProperties.Put("EnumerateMethod", "");
            this.colsCodeG.NamedProperties.Put("FieldFlags", "294");
            this.colsCodeG.NamedProperties.Put("LovReference", "CODE_G(COMPANY)");
            this.colsCodeG.NamedProperties.Put("ResizeableChildObject", "");
            this.colsCodeG.NamedProperties.Put("SqlColumn", "CODE_G");
            this.colsCodeG.NamedProperties.Put("ValidateMethod", "");
            this.colsCodeG.Position = 18;
            resources.ApplyResources(this.colsCodeG, "colsCodeG");
            this.colsCodeG.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsCodeG_WindowActions);
            // 
            // colsCodeGDesc
            // 
            this.colsCodeGDesc.Name = "colsCodeGDesc";
            this.colsCodeGDesc.NamedProperties.Put("EnumerateMethod", "");
            this.colsCodeGDesc.NamedProperties.Put("FieldFlags", "2304");
            this.colsCodeGDesc.NamedProperties.Put("LovReference", "");
            this.colsCodeGDesc.NamedProperties.Put("SqlColumn", "CODE_G_DESC");
            this.colsCodeGDesc.NamedProperties.Put("ValidateMethod", "");
            this.colsCodeGDesc.Position = 19;
            resources.ApplyResources(this.colsCodeGDesc, "colsCodeGDesc");
            this.colsCodeGDesc.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsCodeGDesc_WindowActions);
            // 
            // colsCodeH
            // 
            this.colsCodeH.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsCodeH.MaxLength = 20;
            this.colsCodeH.Name = "colsCodeH";
            this.colsCodeH.NamedProperties.Put("EnumerateMethod", "");
            this.colsCodeH.NamedProperties.Put("FieldFlags", "294");
            this.colsCodeH.NamedProperties.Put("LovReference", "CODE_H(COMPANY)");
            this.colsCodeH.NamedProperties.Put("ResizeableChildObject", "");
            this.colsCodeH.NamedProperties.Put("SqlColumn", "CODE_H");
            this.colsCodeH.NamedProperties.Put("ValidateMethod", "");
            this.colsCodeH.Position = 20;
            resources.ApplyResources(this.colsCodeH, "colsCodeH");
            this.colsCodeH.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsCodeH_WindowActions);
            // 
            // colsCodeHDesc
            // 
            this.colsCodeHDesc.Name = "colsCodeHDesc";
            this.colsCodeHDesc.NamedProperties.Put("EnumerateMethod", "");
            this.colsCodeHDesc.NamedProperties.Put("FieldFlags", "2304");
            this.colsCodeHDesc.NamedProperties.Put("LovReference", "");
            this.colsCodeHDesc.NamedProperties.Put("SqlColumn", "CODE_H_DESC");
            this.colsCodeHDesc.NamedProperties.Put("ValidateMethod", "");
            this.colsCodeHDesc.Position = 21;
            resources.ApplyResources(this.colsCodeHDesc, "colsCodeHDesc");
            this.colsCodeHDesc.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsCodeHDesc_WindowActions);
            // 
            // colsCodeI
            // 
            this.colsCodeI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsCodeI.MaxLength = 20;
            this.colsCodeI.Name = "colsCodeI";
            this.colsCodeI.NamedProperties.Put("EnumerateMethod", "");
            this.colsCodeI.NamedProperties.Put("FieldFlags", "294");
            this.colsCodeI.NamedProperties.Put("LovReference", "CODE_I(COMPANY)");
            this.colsCodeI.NamedProperties.Put("ResizeableChildObject", "");
            this.colsCodeI.NamedProperties.Put("SqlColumn", "CODE_I");
            this.colsCodeI.NamedProperties.Put("ValidateMethod", "");
            this.colsCodeI.Position = 22;
            resources.ApplyResources(this.colsCodeI, "colsCodeI");
            this.colsCodeI.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsCodeI_WindowActions);
            // 
            // colsCodeIDesc
            // 
            this.colsCodeIDesc.Name = "colsCodeIDesc";
            this.colsCodeIDesc.NamedProperties.Put("EnumerateMethod", "");
            this.colsCodeIDesc.NamedProperties.Put("FieldFlags", "2304");
            this.colsCodeIDesc.NamedProperties.Put("LovReference", "");
            this.colsCodeIDesc.NamedProperties.Put("SqlColumn", "CODE_I_DESC");
            this.colsCodeIDesc.NamedProperties.Put("ValidateMethod", "");
            this.colsCodeIDesc.Position = 23;
            resources.ApplyResources(this.colsCodeIDesc, "colsCodeIDesc");
            this.colsCodeIDesc.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsCodeIDesc_WindowActions);
            // 
            // colsCodeJ
            // 
            this.colsCodeJ.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsCodeJ.MaxLength = 20;
            this.colsCodeJ.Name = "colsCodeJ";
            this.colsCodeJ.NamedProperties.Put("EnumerateMethod", "");
            this.colsCodeJ.NamedProperties.Put("FieldFlags", "294");
            this.colsCodeJ.NamedProperties.Put("LovReference", "CODE_J(COMPANY)");
            this.colsCodeJ.NamedProperties.Put("ResizeableChildObject", "");
            this.colsCodeJ.NamedProperties.Put("SqlColumn", "CODE_J");
            this.colsCodeJ.NamedProperties.Put("ValidateMethod", "");
            this.colsCodeJ.Position = 24;
            resources.ApplyResources(this.colsCodeJ, "colsCodeJ");
            this.colsCodeJ.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsCodeJ_WindowActions);
            // 
            // colsCodeJDesc
            // 
            this.colsCodeJDesc.Name = "colsCodeJDesc";
            this.colsCodeJDesc.NamedProperties.Put("EnumerateMethod", "");
            this.colsCodeJDesc.NamedProperties.Put("FieldFlags", "2304");
            this.colsCodeJDesc.NamedProperties.Put("LovReference", "");
            this.colsCodeJDesc.NamedProperties.Put("SqlColumn", "CODE_J_DESC");
            this.colsCodeJDesc.NamedProperties.Put("ValidateMethod", "");
            this.colsCodeJDesc.Position = 25;
            resources.ApplyResources(this.colsCodeJDesc, "colsCodeJDesc");
            this.colsCodeJDesc.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsCodeJDesc_WindowActions);
            // 
            // colsProcessCodeP
            // 
            this.colsProcessCodeP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsProcessCodeP.MaxLength = 10;
            this.colsProcessCodeP.Name = "colsProcessCodeP";
            this.colsProcessCodeP.NamedProperties.Put("EnumerateMethod", "");
            this.colsProcessCodeP.NamedProperties.Put("FieldFlags", "294");
            this.colsProcessCodeP.NamedProperties.Put("LovReference", "ACCOUNT_PROCESS_CODE(COMPANY)");
            this.colsProcessCodeP.NamedProperties.Put("ResizeableChildObject", "");
            this.colsProcessCodeP.NamedProperties.Put("SqlColumn", "PROCESS_CODE");
            this.colsProcessCodeP.NamedProperties.Put("ValidateMethod", "");
            this.colsProcessCodeP.Position = 26;
            resources.ApplyResources(this.colsProcessCodeP, "colsProcessCodeP");
            this.colsProcessCodeP.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsProcessCodeP_WindowActions);
            // 
            // colsText
            // 
            this.colsText.MaxLength = 200;
            this.colsText.Name = "colsText";
            this.colsText.NamedProperties.Put("EnumerateMethod", "");
            this.colsText.NamedProperties.Put("FieldFlags", "294");
            this.colsText.NamedProperties.Put("LovReference", "");
            this.colsText.NamedProperties.Put("ResizeableChildObject", "");
            this.colsText.NamedProperties.Put("SqlColumn", "TEXT");
            this.colsText.NamedProperties.Put("ValidateMethod", "");
            this.colsText.Position = 27;
            resources.ApplyResources(this.colsText, "colsText");
            // 
            // colnQuantity
            // 
            this.colnQuantity.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colnQuantity.Name = "colnQuantity";
            this.colnQuantity.NamedProperties.Put("EnumerateMethod", "");
            this.colnQuantity.NamedProperties.Put("FieldFlags", "294");
            this.colnQuantity.NamedProperties.Put("LovReference", "");
            this.colnQuantity.NamedProperties.Put("ResizeableChildObject", "");
            this.colnQuantity.NamedProperties.Put("SqlColumn", "QUANTITY");
            this.colnQuantity.NamedProperties.Put("ValidateMethod", "");
            this.colnQuantity.Position = 28;
            this.colnQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.colnQuantity, "colnQuantity");
            // 
            // colsCodePart
            // 
            resources.ApplyResources(this.colsCodePart, "colsCodePart");
            this.colsCodePart.Name = "colsCodePart";
            this.colsCodePart.NamedProperties.Put("EnumerateMethod", "");
            this.colsCodePart.NamedProperties.Put("FieldFlags", "262");
            this.colsCodePart.NamedProperties.Put("LovReference", "");
            this.colsCodePart.NamedProperties.Put("ResizeableChildObject", "");
            this.colsCodePart.NamedProperties.Put("SqlColumn", "CODE_PART");
            this.colsCodePart.NamedProperties.Put("ValidateMethod", "");
            this.colsCodePart.Position = 29;
            // 
            // colsCodeDemand
            // 
            resources.ApplyResources(this.colsCodeDemand, "colsCodeDemand");
            this.colsCodeDemand.Name = "colsCodeDemand";
            this.colsCodeDemand.NamedProperties.Put("EnumerateMethod", "");
            this.colsCodeDemand.NamedProperties.Put("FieldFlags", "262");
            this.colsCodeDemand.NamedProperties.Put("LovReference", "");
            this.colsCodeDemand.NamedProperties.Put("SqlColumn", "CODE_DEMAND");
            this.colsCodeDemand.NamedProperties.Put("ValidateMethod", "");
            this.colsCodeDemand.Position = 30;
            // 
            // colsPseudoCodeOwnership
            // 
            this.colsPseudoCodeOwnership.MaxLength = 200;
            this.colsPseudoCodeOwnership.Name = "colsPseudoCodeOwnership";
            this.colsPseudoCodeOwnership.NamedProperties.Put("EnumerateMethod", "Fin_Ownership_API.Enumerate");
            this.colsPseudoCodeOwnership.NamedProperties.Put("FieldFlags", "295");
            this.colsPseudoCodeOwnership.NamedProperties.Put("LovReference", "");
            this.colsPseudoCodeOwnership.NamedProperties.Put("ResizeableChildObject", "");
            this.colsPseudoCodeOwnership.NamedProperties.Put("SqlColumn", "PSEUDO_CODE_OWNERSHIP");
            this.colsPseudoCodeOwnership.NamedProperties.Put("ValidateMethod", "");
            this.colsPseudoCodeOwnership.Position = 31;
            resources.ApplyResources(this.colsPseudoCodeOwnership, "colsPseudoCodeOwnership");
            this.colsPseudoCodeOwnership.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsPseudoCodeOwnership_WindowActions);
            // 
            // colsUserName
            // 
            this.colsUserName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.colsUserName, "colsUserName");
            this.colsUserName.MaxLength = 30;
            this.colsUserName.Name = "colsUserName";
            this.colsUserName.NamedProperties.Put("EnumerateMethod", "");
            this.colsUserName.NamedProperties.Put("FieldFlags", "163");
            this.colsUserName.NamedProperties.Put("LovReference", "");
            this.colsUserName.NamedProperties.Put("ResizeableChildObject", "");
            this.colsUserName.NamedProperties.Put("SqlColumn", "USER_NAME");
            this.colsUserName.NamedProperties.Put("ValidateMethod", "");
            this.colsUserName.Position = 32;
            // 
            // menuTbwMethods
            // 
            this.menuTbwMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem__Translation,
            this.menuSeparator1,
            this.menuItem_Change});
            this.menuTbwMethods.Name = "menuTbwMethods";
            resources.ApplyResources(this.menuTbwMethods, "menuTbwMethods");
            // 
            // menuItem__Translation
            // 
            this.menuItem__Translation.Command = this.menuTbwMethods_menu_Translation___;
            this.menuItem__Translation.Name = "menuItem__Translation";
            resources.ApplyResources(this.menuItem__Translation, "menuItem__Translation");
            this.menuItem__Translation.Text = "&Translation...";
            // 
            // menuSeparator1
            // 
            this.menuSeparator1.Name = "menuSeparator1";
            resources.ApplyResources(this.menuSeparator1, "menuSeparator1");
            // 
            // menuItem_Change
            // 
            this.menuItem_Change.Command = this.menuTbwMethods_menuChange__Company___;
            this.menuItem_Change.Name = "menuItem_Change";
            resources.ApplyResources(this.menuItem_Change, "menuItem_Change");
            this.menuItem_Change.Text = "Change &Company...";
            // 
            // menuOperations
            // 
            this.menuOperations.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem__Translation_1,
            this.menuSeparator2,
            this.menuItem_Change_1});
            this.menuOperations.Name = "menuOperations";
            resources.ApplyResources(this.menuOperations, "menuOperations");
            // 
            // menuItem__Translation_1
            // 
            this.menuItem__Translation_1.Command = this.menuOperations_menu_Translation___;
            this.menuItem__Translation_1.Name = "menuItem__Translation_1";
            resources.ApplyResources(this.menuItem__Translation_1, "menuItem__Translation_1");
            this.menuItem__Translation_1.Text = "&Translation...";
            // 
            // menuSeparator2
            // 
            this.menuSeparator2.Name = "menuSeparator2";
            resources.ApplyResources(this.menuSeparator2, "menuSeparator2");
            // 
            // menuItem_Change_1
            // 
            this.menuItem_Change_1.Command = this.menuOperations_menuChange__Company___;
            this.menuItem_Change_1.Name = "menuItem_Change_1";
            resources.ApplyResources(this.menuItem_Change_1, "menuItem_Change_1");
            this.menuItem_Change_1.Text = "Change &Company...";
            // 
            // colnProjectActivityId
            // 
            this.colnProjectActivityId.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colnProjectActivityId.Name = "colnProjectActivityId";
            this.colnProjectActivityId.NamedProperties.Put("EnumerateMethod", "");
            this.colnProjectActivityId.NamedProperties.Put("FieldFlags", "294");
            this.colnProjectActivityId.NamedProperties.Put("Format", "");
            this.colnProjectActivityId.NamedProperties.Put("LovReference", "PROJECT_ACTIVITY_POSTABLE(project_id)");
            this.colnProjectActivityId.NamedProperties.Put("SqlColumn", "PROJECT_ACTIVITY_ID");
            this.colnProjectActivityId.Position = 33;
            resources.ApplyResources(this.colnProjectActivityId, "colnProjectActivityId");
            this.colnProjectActivityId.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colnProjectActivityId_WindowActions);
            // 
            // tbwPseudoCode
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colsCompany);
            this.Controls.Add(this.colsPseudoCode);
            this.Controls.Add(this.colsDescription);
            this.Controls.Add(this.colsAccount);
            this.Controls.Add(this.colsAccountDesc);
            this.Controls.Add(this.colsCodeB);
            this.Controls.Add(this.colsCodeBDesc);
            this.Controls.Add(this.colsCodeC);
            this.Controls.Add(this.colsCodeCDesc);
            this.Controls.Add(this.colsCodeD);
            this.Controls.Add(this.colsCodeDDesc);
            this.Controls.Add(this.colsCodeE);
            this.Controls.Add(this.colsCodeEDesc);
            this.Controls.Add(this.colsCodeF);
            this.Controls.Add(this.colsCodeFDesc);
            this.Controls.Add(this.colsCodeG);
            this.Controls.Add(this.colsCodeGDesc);
            this.Controls.Add(this.colsCodeH);
            this.Controls.Add(this.colsCodeHDesc);
            this.Controls.Add(this.colsCodeI);
            this.Controls.Add(this.colsCodeIDesc);
            this.Controls.Add(this.colsCodeJ);
            this.Controls.Add(this.colsCodeJDesc);
            this.Controls.Add(this.colsProcessCodeP);
            this.Controls.Add(this.colsText);
            this.Controls.Add(this.colnQuantity);
            this.Controls.Add(this.colsCodePart);
            this.Controls.Add(this.colsCodeDemand);
            this.Controls.Add(this.colsPseudoCodeOwnership);
            this.Controls.Add(this.colsUserName);
            this.Controls.Add(this.colnProjectActivityId);
            this.Name = "tbwPseudoCode";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "COMPANY = :global.company");
            this.NamedProperties.Put("LogicalUnit", "PseudoCodes");
            this.NamedProperties.Put("PackageName", "PSEUDO_CODES_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "449");
            this.NamedProperties.Put("ViewName", "PSEUDO_CODES");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tbwPseudoCode_WindowActions);
            this.Controls.SetChildIndex(this.colnProjectActivityId, 0);
            this.Controls.SetChildIndex(this.colsUserName, 0);
            this.Controls.SetChildIndex(this.colsPseudoCodeOwnership, 0);
            this.Controls.SetChildIndex(this.colsCodeDemand, 0);
            this.Controls.SetChildIndex(this.colsCodePart, 0);
            this.Controls.SetChildIndex(this.colnQuantity, 0);
            this.Controls.SetChildIndex(this.colsText, 0);
            this.Controls.SetChildIndex(this.colsProcessCodeP, 0);
            this.Controls.SetChildIndex(this.colsCodeJDesc, 0);
            this.Controls.SetChildIndex(this.colsCodeJ, 0);
            this.Controls.SetChildIndex(this.colsCodeIDesc, 0);
            this.Controls.SetChildIndex(this.colsCodeI, 0);
            this.Controls.SetChildIndex(this.colsCodeHDesc, 0);
            this.Controls.SetChildIndex(this.colsCodeH, 0);
            this.Controls.SetChildIndex(this.colsCodeGDesc, 0);
            this.Controls.SetChildIndex(this.colsCodeG, 0);
            this.Controls.SetChildIndex(this.colsCodeFDesc, 0);
            this.Controls.SetChildIndex(this.colsCodeF, 0);
            this.Controls.SetChildIndex(this.colsCodeEDesc, 0);
            this.Controls.SetChildIndex(this.colsCodeE, 0);
            this.Controls.SetChildIndex(this.colsCodeDDesc, 0);
            this.Controls.SetChildIndex(this.colsCodeD, 0);
            this.Controls.SetChildIndex(this.colsCodeCDesc, 0);
            this.Controls.SetChildIndex(this.colsCodeC, 0);
            this.Controls.SetChildIndex(this.colsCodeBDesc, 0);
            this.Controls.SetChildIndex(this.colsCodeB, 0);
            this.Controls.SetChildIndex(this.colsAccountDesc, 0);
            this.Controls.SetChildIndex(this.colsAccount, 0);
            this.Controls.SetChildIndex(this.colsDescription, 0);
            this.Controls.SetChildIndex(this.colsPseudoCode, 0);
            this.Controls.SetChildIndex(this.colsCompany, 0);
            this.Controls.SetChildIndex(this.@__colObjversion, 0);
            this.Controls.SetChildIndex(this.@__colObjid, 0);
            this.menuTbwMethods.ResumeLayout(false);
            this.menuOperations.ResumeLayout(false);
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

        public Fnd.Windows.Forms.FndCommand menuOperations_menu_Translation___;
        public Fnd.Windows.Forms.FndCommand menuOperations_menuChange__Company___;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menu_Translation___;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menuChange__Company___;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTbwMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Translation;
        protected Fnd.Windows.Forms.FndToolStripSeparator menuSeparator1;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuOperations;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Translation_1;
        protected Fnd.Windows.Forms.FndToolStripSeparator menuSeparator2;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change_1;
        protected cColumn colnProjectActivityId;
	}
}
