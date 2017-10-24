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
	
	public partial class tbwCombControl
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cColumn colsCompany;
		// Bug 77483, Begin
		public cColumn colCombRuleId;
		// Bug 77483, End
		public cColumn colUserGroup;
		public cColumn colDescription;
		public cLookupColumn colAllowed;
		public cColumnFin colCodea;
		public cColumnCodePartDescFin colsAccountDesc;
		public cColumnFin colCodeb;
		public cColumnCodePartDescFin colsCodeBDesc;
		public cColumnFin colCodec;
		public cColumnCodePartDescFin colsCodeCDesc;
		public cColumnFin colCoded;
		public cColumnCodePartDescFin colsCodeDDesc;
		public cColumnFin colCodee;
		public cColumnCodePartDescFin colsCodeEDesc;
		public cColumnFin colCodef;
		public cColumnCodePartDescFin colsCodeFDesc;
		public cColumnFin colCodeg;
		public cColumnCodePartDescFin colsCodeGDesc;
		public cColumnFin colCodeh;
		public cColumnCodePartDescFin colsCodeHDesc;
		public cColumnFin colCodei;
		public cColumnCodePartDescFin colsCodeIDesc;
		public cColumnFin colCodej;
		public cColumnCodePartDescFin colsCodeJDesc;
		public cColumn coldummyCdPart;
		public cColumn colsProcessCode;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwCombControl));
            this.menuOperations_menuChange__Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_menuChange__Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.colsCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colCombRuleId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colUserGroup = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colAllowed = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.colCodea = new Ifs.Application.Accrul.cColumnFin();
            this.colsAccountDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.colCodeb = new Ifs.Application.Accrul.cColumnFin();
            this.colsCodeBDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.colCodec = new Ifs.Application.Accrul.cColumnFin();
            this.colsCodeCDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.colCoded = new Ifs.Application.Accrul.cColumnFin();
            this.colsCodeDDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.colCodee = new Ifs.Application.Accrul.cColumnFin();
            this.colsCodeEDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.colCodef = new Ifs.Application.Accrul.cColumnFin();
            this.colsCodeFDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.colCodeg = new Ifs.Application.Accrul.cColumnFin();
            this.colsCodeGDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.colCodeh = new Ifs.Application.Accrul.cColumnFin();
            this.colsCodeHDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.colCodei = new Ifs.Application.Accrul.cColumnFin();
            this.colsCodeIDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.colCodej = new Ifs.Application.Accrul.cColumnFin();
            this.colsCodeJDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.coldummyCdPart = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsProcessCode = new Ifs.Fnd.ApplicationForms.cColumn();
            this.menuTbwMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_Change = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuOperations = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_Change_1 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuTbwMethods.SuspendLayout();
            this.menuOperations.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuTbwMethods_menuChange__Company___);
            this.commandManager.Commands.Add(this.menuOperations_menuChange__Company___);
            this.commandManager.ContextMenus.Add(this.menuTbwMethods);
            this.commandManager.ContextMenus.Add(this.menuOperations);
            // 
            // menuOperations_menuChange__Company___
            // 
            resources.ApplyResources(this.menuOperations_menuChange__Company___, "menuOperations_menuChange__Company___");
            this.menuOperations_menuChange__Company___.Name = "menuOperations_menuChange__Company___";
            this.menuOperations_menuChange__Company___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Change_1_Execute);
            this.menuOperations_menuChange__Company___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Change_1_Inquire);
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
            this.colsCompany.NamedProperties.Put("LovReference", "");
            this.colsCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.colsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.colsCompany.NamedProperties.Put("ValidateMethod", "");
            this.colsCompany.Position = 3;
            // 
            // colCombRuleId
            // 
            this.colCombRuleId.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.colCombRuleId, "colCombRuleId");
            this.colCombRuleId.Name = "colCombRuleId";
            this.colCombRuleId.NamedProperties.Put("EnumerateMethod", "");
            this.colCombRuleId.NamedProperties.Put("FieldFlags", "288");
            this.colCombRuleId.NamedProperties.Put("LovReference", "");
            this.colCombRuleId.NamedProperties.Put("ResizeableChildObject", "");
            this.colCombRuleId.NamedProperties.Put("SqlColumn", "COMB_RULE_ID");
            this.colCombRuleId.NamedProperties.Put("ValidateMethod", "");
            this.colCombRuleId.Position = 4;
            // 
            // colUserGroup
            // 
            this.colUserGroup.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colUserGroup.MaxLength = 30;
            this.colUserGroup.Name = "colUserGroup";
            this.colUserGroup.NamedProperties.Put("EnumerateMethod", "");
            this.colUserGroup.NamedProperties.Put("FieldFlags", "167");
            this.colUserGroup.NamedProperties.Put("LovReference", "USER_GROUP_FINANCE(COMPANY)");
            this.colUserGroup.NamedProperties.Put("ResizeableChildObject", "");
            this.colUserGroup.NamedProperties.Put("SqlColumn", "USER_GROUP");
            this.colUserGroup.NamedProperties.Put("ValidateMethod", "");
            this.colUserGroup.Position = 5;
            resources.ApplyResources(this.colUserGroup, "colUserGroup");
            // 
            // colDescription
            // 
            this.colDescription.MaxLength = 35;
            this.colDescription.Name = "colDescription";
            this.colDescription.NamedProperties.Put("EnumerateMethod", "");
            this.colDescription.NamedProperties.Put("FieldFlags", "288");
            this.colDescription.NamedProperties.Put("LovReference", "");
            this.colDescription.NamedProperties.Put("ParentName", "colUserGroup");
            this.colDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.colDescription.NamedProperties.Put("SqlColumn", "USER_GROUP_FINANCE_API.GET_USER_GROUP_DESCRIPTION(COMPANY,USER_GROUP)");
            this.colDescription.NamedProperties.Put("ValidateMethod", "");
            this.colDescription.Position = 6;
            resources.ApplyResources(this.colDescription, "colDescription");
            // 
            // colAllowed
            // 
            this.colAllowed.MaxLength = 20;
            this.colAllowed.Name = "colAllowed";
            this.colAllowed.NamedProperties.Put("EnumerateMethod", "COMB_CONTROL_ALLOWED_API.Enumerate");
            this.colAllowed.NamedProperties.Put("FieldFlags", "294");
            this.colAllowed.NamedProperties.Put("LovReference", "");
            this.colAllowed.NamedProperties.Put("SqlColumn", "ALLOWED");
            this.colAllowed.Position = 7;
            resources.ApplyResources(this.colAllowed, "colAllowed");
            this.colAllowed.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colAllowed_WindowActions);
            // 
            // colCodea
            // 
            this.colCodea.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colCodea.MaxLength = 20;
            this.colCodea.Name = "colCodea";
            this.colCodea.NamedProperties.Put("EnumerateMethod", "");
            this.colCodea.NamedProperties.Put("FieldFlags", "295");
            this.colCodea.NamedProperties.Put("LovReference", "ACCOUNT(COMPANY)");
            this.colCodea.NamedProperties.Put("ResizeableChildObject", "");
            this.colCodea.NamedProperties.Put("SqlColumn", "ACCOUNT");
            this.colCodea.NamedProperties.Put("ValidateMethod", "");
            this.colCodea.Position = 8;
            resources.ApplyResources(this.colCodea, "colCodea");
            this.colCodea.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colCodea_WindowActions);
            // 
            // colsAccountDesc
            // 
            resources.ApplyResources(this.colsAccountDesc, "colsAccountDesc");
            this.colsAccountDesc.Name = "colsAccountDesc";
            this.colsAccountDesc.NamedProperties.Put("EnumerateMethod", "");
            this.colsAccountDesc.NamedProperties.Put("LovReference", "");
            this.colsAccountDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.colsAccountDesc.NamedProperties.Put("SqlColumn", "ACCOUNT_DESC");
            this.colsAccountDesc.NamedProperties.Put("ValidateMethod", "");
            this.colsAccountDesc.Position = 9;
            // 
            // colCodeb
            // 
            this.colCodeb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colCodeb.MaxLength = 20;
            this.colCodeb.Name = "colCodeb";
            this.colCodeb.NamedProperties.Put("EnumerateMethod", "");
            this.colCodeb.NamedProperties.Put("FieldFlags", "294");
            this.colCodeb.NamedProperties.Put("LovReference", "CODE_B(COMPANY)");
            this.colCodeb.NamedProperties.Put("ResizeableChildObject", "");
            this.colCodeb.NamedProperties.Put("SqlColumn", "CODE_B");
            this.colCodeb.NamedProperties.Put("ValidateMethod", "");
            this.colCodeb.Position = 10;
            resources.ApplyResources(this.colCodeb, "colCodeb");
            this.colCodeb.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colCodeb_WindowActions);
            // 
            // colsCodeBDesc
            // 
            resources.ApplyResources(this.colsCodeBDesc, "colsCodeBDesc");
            this.colsCodeBDesc.Name = "colsCodeBDesc";
            this.colsCodeBDesc.NamedProperties.Put("EnumerateMethod", "");
            this.colsCodeBDesc.NamedProperties.Put("LovReference", "");
            this.colsCodeBDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.colsCodeBDesc.NamedProperties.Put("SqlColumn", "CODE_B_DESC");
            this.colsCodeBDesc.NamedProperties.Put("ValidateMethod", "");
            this.colsCodeBDesc.Position = 11;
            // 
            // colCodec
            // 
            this.colCodec.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colCodec.MaxLength = 20;
            this.colCodec.Name = "colCodec";
            this.colCodec.NamedProperties.Put("EnumerateMethod", "");
            this.colCodec.NamedProperties.Put("FieldFlags", "294");
            this.colCodec.NamedProperties.Put("LovReference", "CODE_C(COMPANY)");
            this.colCodec.NamedProperties.Put("ResizeableChildObject", "");
            this.colCodec.NamedProperties.Put("SqlColumn", "CODE_C");
            this.colCodec.NamedProperties.Put("ValidateMethod", "");
            this.colCodec.Position = 12;
            resources.ApplyResources(this.colCodec, "colCodec");
            this.colCodec.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colCodec_WindowActions);
            // 
            // colsCodeCDesc
            // 
            resources.ApplyResources(this.colsCodeCDesc, "colsCodeCDesc");
            this.colsCodeCDesc.Name = "colsCodeCDesc";
            this.colsCodeCDesc.NamedProperties.Put("EnumerateMethod", "");
            this.colsCodeCDesc.NamedProperties.Put("LovReference", "");
            this.colsCodeCDesc.NamedProperties.Put("SqlColumn", "CODE_C_DESC");
            this.colsCodeCDesc.NamedProperties.Put("ValidateMethod", "");
            this.colsCodeCDesc.Position = 13;
            // 
            // colCoded
            // 
            this.colCoded.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colCoded.MaxLength = 20;
            this.colCoded.Name = "colCoded";
            this.colCoded.NamedProperties.Put("EnumerateMethod", "");
            this.colCoded.NamedProperties.Put("FieldFlags", "294");
            this.colCoded.NamedProperties.Put("LovReference", "CODE_D(COMPANY)");
            this.colCoded.NamedProperties.Put("ResizeableChildObject", "");
            this.colCoded.NamedProperties.Put("SqlColumn", "CODE_D");
            this.colCoded.NamedProperties.Put("ValidateMethod", "");
            this.colCoded.Position = 14;
            resources.ApplyResources(this.colCoded, "colCoded");
            this.colCoded.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colCoded_WindowActions);
            // 
            // colsCodeDDesc
            // 
            resources.ApplyResources(this.colsCodeDDesc, "colsCodeDDesc");
            this.colsCodeDDesc.Name = "colsCodeDDesc";
            this.colsCodeDDesc.NamedProperties.Put("EnumerateMethod", "");
            this.colsCodeDDesc.NamedProperties.Put("LovReference", "");
            this.colsCodeDDesc.NamedProperties.Put("SqlColumn", "CODE_D_DESC");
            this.colsCodeDDesc.NamedProperties.Put("ValidateMethod", "");
            this.colsCodeDDesc.Position = 15;
            // 
            // colCodee
            // 
            this.colCodee.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colCodee.MaxLength = 20;
            this.colCodee.Name = "colCodee";
            this.colCodee.NamedProperties.Put("EnumerateMethod", "");
            this.colCodee.NamedProperties.Put("FieldFlags", "294");
            this.colCodee.NamedProperties.Put("LovReference", "CODE_E(COMPANY)");
            this.colCodee.NamedProperties.Put("ResizeableChildObject", "");
            this.colCodee.NamedProperties.Put("SqlColumn", "CODE_E");
            this.colCodee.NamedProperties.Put("ValidateMethod", "");
            this.colCodee.Position = 16;
            resources.ApplyResources(this.colCodee, "colCodee");
            this.colCodee.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colCodee_WindowActions);
            // 
            // colsCodeEDesc
            // 
            resources.ApplyResources(this.colsCodeEDesc, "colsCodeEDesc");
            this.colsCodeEDesc.Name = "colsCodeEDesc";
            this.colsCodeEDesc.NamedProperties.Put("EnumerateMethod", "");
            this.colsCodeEDesc.NamedProperties.Put("LovReference", "");
            this.colsCodeEDesc.NamedProperties.Put("SqlColumn", "CODE_E_DESC");
            this.colsCodeEDesc.NamedProperties.Put("ValidateMethod", "");
            this.colsCodeEDesc.Position = 17;
            // 
            // colCodef
            // 
            this.colCodef.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colCodef.MaxLength = 20;
            this.colCodef.Name = "colCodef";
            this.colCodef.NamedProperties.Put("EnumerateMethod", "");
            this.colCodef.NamedProperties.Put("FieldFlags", "294");
            this.colCodef.NamedProperties.Put("LovReference", "CODE_F(COMPANY)");
            this.colCodef.NamedProperties.Put("ResizeableChildObject", "");
            this.colCodef.NamedProperties.Put("SqlColumn", "CODE_F");
            this.colCodef.NamedProperties.Put("ValidateMethod", "");
            this.colCodef.Position = 18;
            resources.ApplyResources(this.colCodef, "colCodef");
            this.colCodef.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colCodef_WindowActions);
            // 
            // colsCodeFDesc
            // 
            resources.ApplyResources(this.colsCodeFDesc, "colsCodeFDesc");
            this.colsCodeFDesc.Name = "colsCodeFDesc";
            this.colsCodeFDesc.NamedProperties.Put("EnumerateMethod", "");
            this.colsCodeFDesc.NamedProperties.Put("LovReference", "");
            this.colsCodeFDesc.NamedProperties.Put("SqlColumn", "CODE_F_DESC");
            this.colsCodeFDesc.NamedProperties.Put("ValidateMethod", "");
            this.colsCodeFDesc.Position = 19;
            // 
            // colCodeg
            // 
            this.colCodeg.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colCodeg.MaxLength = 20;
            this.colCodeg.Name = "colCodeg";
            this.colCodeg.NamedProperties.Put("EnumerateMethod", "");
            this.colCodeg.NamedProperties.Put("FieldFlags", "294");
            this.colCodeg.NamedProperties.Put("LovReference", "CODE_G(COMPANY)");
            this.colCodeg.NamedProperties.Put("ResizeableChildObject", "");
            this.colCodeg.NamedProperties.Put("SqlColumn", "CODE_G");
            this.colCodeg.NamedProperties.Put("ValidateMethod", "");
            this.colCodeg.Position = 20;
            resources.ApplyResources(this.colCodeg, "colCodeg");
            this.colCodeg.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colCodeg_WindowActions);
            // 
            // colsCodeGDesc
            // 
            resources.ApplyResources(this.colsCodeGDesc, "colsCodeGDesc");
            this.colsCodeGDesc.Name = "colsCodeGDesc";
            this.colsCodeGDesc.NamedProperties.Put("EnumerateMethod", "");
            this.colsCodeGDesc.NamedProperties.Put("LovReference", "");
            this.colsCodeGDesc.NamedProperties.Put("SqlColumn", "CODE_G_DESC");
            this.colsCodeGDesc.NamedProperties.Put("ValidateMethod", "");
            this.colsCodeGDesc.Position = 21;
            // 
            // colCodeh
            // 
            this.colCodeh.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colCodeh.MaxLength = 20;
            this.colCodeh.Name = "colCodeh";
            this.colCodeh.NamedProperties.Put("EnumerateMethod", "");
            this.colCodeh.NamedProperties.Put("FieldFlags", "294");
            this.colCodeh.NamedProperties.Put("LovReference", "CODE_H(COMPANY)");
            this.colCodeh.NamedProperties.Put("ResizeableChildObject", "");
            this.colCodeh.NamedProperties.Put("SqlColumn", "CODE_H");
            this.colCodeh.NamedProperties.Put("ValidateMethod", "");
            this.colCodeh.Position = 22;
            resources.ApplyResources(this.colCodeh, "colCodeh");
            this.colCodeh.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colCodeh_WindowActions);
            // 
            // colsCodeHDesc
            // 
            resources.ApplyResources(this.colsCodeHDesc, "colsCodeHDesc");
            this.colsCodeHDesc.Name = "colsCodeHDesc";
            this.colsCodeHDesc.NamedProperties.Put("EnumerateMethod", "");
            this.colsCodeHDesc.NamedProperties.Put("LovReference", "");
            this.colsCodeHDesc.NamedProperties.Put("SqlColumn", "CODE_H_DESC");
            this.colsCodeHDesc.NamedProperties.Put("ValidateMethod", "");
            this.colsCodeHDesc.Position = 23;
            // 
            // colCodei
            // 
            this.colCodei.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colCodei.MaxLength = 20;
            this.colCodei.Name = "colCodei";
            this.colCodei.NamedProperties.Put("EnumerateMethod", "");
            this.colCodei.NamedProperties.Put("FieldFlags", "294");
            this.colCodei.NamedProperties.Put("LovReference", "CODE_I(COMPANY)");
            this.colCodei.NamedProperties.Put("ResizeableChildObject", "");
            this.colCodei.NamedProperties.Put("SqlColumn", "CODE_I");
            this.colCodei.NamedProperties.Put("ValidateMethod", "");
            this.colCodei.Position = 24;
            resources.ApplyResources(this.colCodei, "colCodei");
            this.colCodei.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colCodei_WindowActions);
            // 
            // colsCodeIDesc
            // 
            resources.ApplyResources(this.colsCodeIDesc, "colsCodeIDesc");
            this.colsCodeIDesc.Name = "colsCodeIDesc";
            this.colsCodeIDesc.NamedProperties.Put("EnumerateMethod", "");
            this.colsCodeIDesc.NamedProperties.Put("LovReference", "");
            this.colsCodeIDesc.NamedProperties.Put("SqlColumn", "CODE_I_DESC");
            this.colsCodeIDesc.NamedProperties.Put("ValidateMethod", "");
            this.colsCodeIDesc.Position = 25;
            // 
            // colCodej
            // 
            this.colCodej.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colCodej.MaxLength = 20;
            this.colCodej.Name = "colCodej";
            this.colCodej.NamedProperties.Put("EnumerateMethod", "");
            this.colCodej.NamedProperties.Put("FieldFlags", "294");
            this.colCodej.NamedProperties.Put("LovReference", "CODE_J(COMPANY)");
            this.colCodej.NamedProperties.Put("ResizeableChildObject", "");
            this.colCodej.NamedProperties.Put("SqlColumn", "CODE_J");
            this.colCodej.NamedProperties.Put("ValidateMethod", "");
            this.colCodej.Position = 26;
            resources.ApplyResources(this.colCodej, "colCodej");
            this.colCodej.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colCodej_WindowActions);
            // 
            // colsCodeJDesc
            // 
            resources.ApplyResources(this.colsCodeJDesc, "colsCodeJDesc");
            this.colsCodeJDesc.Name = "colsCodeJDesc";
            this.colsCodeJDesc.NamedProperties.Put("EnumerateMethod", "");
            this.colsCodeJDesc.NamedProperties.Put("LovReference", "");
            this.colsCodeJDesc.NamedProperties.Put("SqlColumn", "CODE_J_DESC");
            this.colsCodeJDesc.NamedProperties.Put("ValidateMethod", "");
            this.colsCodeJDesc.Position = 27;
            // 
            // coldummyCdPart
            // 
            resources.ApplyResources(this.coldummyCdPart, "coldummyCdPart");
            this.coldummyCdPart.Name = "coldummyCdPart";
            this.coldummyCdPart.NamedProperties.Put("EnumerateMethod", "");
            this.coldummyCdPart.NamedProperties.Put("FieldFlags", "262");
            this.coldummyCdPart.NamedProperties.Put("LovReference", "ACCOUNTING_CODESTR_COMB(COMPANY,CODE_PART)");
            this.coldummyCdPart.NamedProperties.Put("SqlColumn", "CODE_PART");
            this.coldummyCdPart.Position = 28;
            // 
            // colsProcessCode
            // 
            this.colsProcessCode.MaxLength = 10;
            this.colsProcessCode.Name = "colsProcessCode";
            this.colsProcessCode.NamedProperties.Put("EnumerateMethod", "");
            this.colsProcessCode.NamedProperties.Put("FieldFlags", "294");
            this.colsProcessCode.NamedProperties.Put("LovReference", "ACCOUNT_PROCESS_CODE(COMPANY)");
            this.colsProcessCode.NamedProperties.Put("ResizeableChildObject", "");
            this.colsProcessCode.NamedProperties.Put("SqlColumn", "PROCESS_CODE");
            this.colsProcessCode.NamedProperties.Put("ValidateMethod", "");
            this.colsProcessCode.Position = 29;
            resources.ApplyResources(this.colsProcessCode, "colsProcessCode");
            // 
            // menuTbwMethods
            // 
            this.menuTbwMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_Change});
            this.menuTbwMethods.Name = "menuTbwMethods";
            resources.ApplyResources(this.menuTbwMethods, "menuTbwMethods");
            // 
            // menuItem_Change
            // 
            this.menuItem_Change.Command = this.menuTbwMethods_menuChange__Company___;
            resources.ApplyResources(this.menuItem_Change, "menuItem_Change");
            this.menuItem_Change.Name = "menuItem_Change";
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
            resources.ApplyResources(this.menuItem_Change_1, "menuItem_Change_1");
            this.menuItem_Change_1.Name = "menuItem_Change_1";
            this.menuItem_Change_1.Text = "Change &Company...";
            // 
            // tbwCombControl
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colsCompany);
            this.Controls.Add(this.colCombRuleId);
            this.Controls.Add(this.colUserGroup);
            this.Controls.Add(this.colDescription);
            this.Controls.Add(this.colAllowed);
            this.Controls.Add(this.colCodea);
            this.Controls.Add(this.colsAccountDesc);
            this.Controls.Add(this.colCodeb);
            this.Controls.Add(this.colsCodeBDesc);
            this.Controls.Add(this.colCodec);
            this.Controls.Add(this.colsCodeCDesc);
            this.Controls.Add(this.colCoded);
            this.Controls.Add(this.colsCodeDDesc);
            this.Controls.Add(this.colCodee);
            this.Controls.Add(this.colsCodeEDesc);
            this.Controls.Add(this.colCodef);
            this.Controls.Add(this.colsCodeFDesc);
            this.Controls.Add(this.colCodeg);
            this.Controls.Add(this.colsCodeGDesc);
            this.Controls.Add(this.colCodeh);
            this.Controls.Add(this.colsCodeHDesc);
            this.Controls.Add(this.colCodei);
            this.Controls.Add(this.colsCodeIDesc);
            this.Controls.Add(this.colCodej);
            this.Controls.Add(this.colsCodeJDesc);
            this.Controls.Add(this.coldummyCdPart);
            this.Controls.Add(this.colsProcessCode);
            this.Name = "tbwCombControl";
            this.NamedProperties.Put("DefaultOrderBy", "COMB_RULE_ID");
            this.NamedProperties.Put("DefaultWhere", "COMPANY = :global.company");
            this.NamedProperties.Put("LogicalUnit", "AccountingCodestrComb");
            this.NamedProperties.Put("PackageName", "ACCOUNTING_CODESTR_COMB_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "0");
            this.NamedProperties.Put("SourceFlags", "449");
            this.NamedProperties.Put("ViewName", "ACCOUNTING_CODESTR_COMB_UIV");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tbwCombControl_WindowActions);
            this.Controls.SetChildIndex(this.colsProcessCode, 0);
            this.Controls.SetChildIndex(this.coldummyCdPart, 0);
            this.Controls.SetChildIndex(this.colsCodeJDesc, 0);
            this.Controls.SetChildIndex(this.colCodej, 0);
            this.Controls.SetChildIndex(this.colsCodeIDesc, 0);
            this.Controls.SetChildIndex(this.colCodei, 0);
            this.Controls.SetChildIndex(this.colsCodeHDesc, 0);
            this.Controls.SetChildIndex(this.colCodeh, 0);
            this.Controls.SetChildIndex(this.colsCodeGDesc, 0);
            this.Controls.SetChildIndex(this.colCodeg, 0);
            this.Controls.SetChildIndex(this.colsCodeFDesc, 0);
            this.Controls.SetChildIndex(this.colCodef, 0);
            this.Controls.SetChildIndex(this.colsCodeEDesc, 0);
            this.Controls.SetChildIndex(this.colCodee, 0);
            this.Controls.SetChildIndex(this.colsCodeDDesc, 0);
            this.Controls.SetChildIndex(this.colCoded, 0);
            this.Controls.SetChildIndex(this.colsCodeCDesc, 0);
            this.Controls.SetChildIndex(this.colCodec, 0);
            this.Controls.SetChildIndex(this.colsCodeBDesc, 0);
            this.Controls.SetChildIndex(this.colCodeb, 0);
            this.Controls.SetChildIndex(this.colsAccountDesc, 0);
            this.Controls.SetChildIndex(this.colCodea, 0);
            this.Controls.SetChildIndex(this.colAllowed, 0);
            this.Controls.SetChildIndex(this.colDescription, 0);
            this.Controls.SetChildIndex(this.colUserGroup, 0);
            this.Controls.SetChildIndex(this.colCombRuleId, 0);
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

        public Fnd.Windows.Forms.FndCommand menuOperations_menuChange__Company___;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menuChange__Company___;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTbwMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuOperations;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change_1;
	}
}
