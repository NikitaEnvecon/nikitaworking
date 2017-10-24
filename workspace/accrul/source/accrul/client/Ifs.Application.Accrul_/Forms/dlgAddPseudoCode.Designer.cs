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
	
	public partial class dlgAddPseudoCode
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls

        public cPushButton pbOK;
		public cPushButton pbSave;
		public cPushButton pbCancel;
		public cPushButton pbList;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgAddPseudoCode));
            this.pbOK = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbSave = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbCancel = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbList = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.tblCurrPseudoCode = new Ifs.Application.Accrul.cChildTableFin();
            this.tblCurrPseudoCode_colsCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblCurrPseudoCode_colsUserId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblCurrPseudoCode_colsPseudoCode = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblCurrPseudoCode_colsDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblCurrPseudoCode_colsAccount = new Ifs.Application.Accrul.cColumnFin();
            this.tblCurrPseudoCode_colsCodeB = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.tblCurrPseudoCode_colsCodeC = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.tblCurrPseudoCode_colsCodeD = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.tblCurrPseudoCode_colsCodeE = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.tblCurrPseudoCode_colsCodeF = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.tblCurrPseudoCode_colsCodeG = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.tblCurrPseudoCode_colsCodeH = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.tblCurrPseudoCode_colsCodeI = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.tblCurrPseudoCode_colsCodeJ = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.tblCurrPseudoCode_colsProcessCode = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblCurrPseudoCode_colnProjectActivityId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblCurrPseudoCode_colsText = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblCurrPseudoCode_colnQuantity = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblCurrPseudoCode_colsPseudoCodeOwnership = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.tblCurrPseudoCode_colsProjectId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblCurrPseudoCode_colsProjectActivityIdEnabled = new Ifs.Fnd.ApplicationForms.cColumn();
            this.ClientArea.SuspendLayout();
            this.tblCurrPseudoCode.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolBar
            // 
            resources.ApplyResources(this.ToolBar, "ToolBar");
            // 
            // ClientArea
            // 
            this.ClientArea.BackColor = System.Drawing.Color.Transparent;
            this.ClientArea.Controls.Add(this.pbList);
            this.ClientArea.Controls.Add(this.pbCancel);
            this.ClientArea.Controls.Add(this.pbSave);
            this.ClientArea.Controls.Add(this.pbOK);
            this.ClientArea.Controls.Add(this.tblCurrPseudoCode);
            resources.ApplyResources(this.ClientArea, "ClientArea");
            // 
            // StatusBar
            // 
            resources.ApplyResources(this.StatusBar, "StatusBar");
            // 
            // commandManager
            // 
            this.commandManager.Components.Add(this.pbList);
            this.commandManager.Components.Add(this.pbCancel);
            this.commandManager.Components.Add(this.pbSave);
            this.commandManager.Components.Add(this.pbOK);
            // 
            // pbOK
            // 
            resources.ApplyResources(this.pbOK, "pbOK");
            this.pbOK.Name = "pbOK";
            this.pbOK.NamedProperties.Put("MethodId", "18385");
            this.pbOK.NamedProperties.Put("MethodParameter", "OK");
            this.pbOK.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // pbSave
            // 
            resources.ApplyResources(this.pbSave, "pbSave");
            this.pbSave.Name = "pbSave";
            this.pbSave.NamedProperties.Put("MethodId", "18385");
            this.pbSave.NamedProperties.Put("MethodParameter", "Save");
            this.pbSave.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // pbCancel
            // 
            resources.ApplyResources(this.pbCancel, "pbCancel");
            this.pbCancel.Name = "pbCancel";
            this.pbCancel.NamedProperties.Put("MethodId", "18385");
            this.pbCancel.NamedProperties.Put("MethodParameter", "Cancel");
            this.pbCancel.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // pbList
            // 
            resources.ApplyResources(this.pbList, "pbList");
            this.pbList.Name = "pbList";
            this.pbList.NamedProperties.Put("MethodId", "18385");
            this.pbList.NamedProperties.Put("MethodParameter", "List");
            this.pbList.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // tblCurrPseudoCode
            // 
            resources.ApplyResources(this.tblCurrPseudoCode, "tblCurrPseudoCode");
            this.tblCurrPseudoCode.Controls.Add(this.tblCurrPseudoCode_colsCompany);
            this.tblCurrPseudoCode.Controls.Add(this.tblCurrPseudoCode_colsUserId);
            this.tblCurrPseudoCode.Controls.Add(this.tblCurrPseudoCode_colsPseudoCode);
            this.tblCurrPseudoCode.Controls.Add(this.tblCurrPseudoCode_colsDescription);
            this.tblCurrPseudoCode.Controls.Add(this.tblCurrPseudoCode_colsAccount);
            this.tblCurrPseudoCode.Controls.Add(this.tblCurrPseudoCode_colsCodeB);
            this.tblCurrPseudoCode.Controls.Add(this.tblCurrPseudoCode_colsCodeC);
            this.tblCurrPseudoCode.Controls.Add(this.tblCurrPseudoCode_colsCodeD);
            this.tblCurrPseudoCode.Controls.Add(this.tblCurrPseudoCode_colsCodeE);
            this.tblCurrPseudoCode.Controls.Add(this.tblCurrPseudoCode_colsCodeF);
            this.tblCurrPseudoCode.Controls.Add(this.tblCurrPseudoCode_colsCodeG);
            this.tblCurrPseudoCode.Controls.Add(this.tblCurrPseudoCode_colsCodeH);
            this.tblCurrPseudoCode.Controls.Add(this.tblCurrPseudoCode_colsCodeI);
            this.tblCurrPseudoCode.Controls.Add(this.tblCurrPseudoCode_colsCodeJ);
            this.tblCurrPseudoCode.Controls.Add(this.tblCurrPseudoCode_colsProcessCode);
            this.tblCurrPseudoCode.Controls.Add(this.tblCurrPseudoCode_colnProjectActivityId);
            this.tblCurrPseudoCode.Controls.Add(this.tblCurrPseudoCode_colsText);
            this.tblCurrPseudoCode.Controls.Add(this.tblCurrPseudoCode_colnQuantity);
            this.tblCurrPseudoCode.Controls.Add(this.tblCurrPseudoCode_colsPseudoCodeOwnership);
            this.tblCurrPseudoCode.Controls.Add(this.tblCurrPseudoCode_colsProjectId);
            this.tblCurrPseudoCode.Controls.Add(this.tblCurrPseudoCode_colsProjectActivityIdEnabled);
            this.tblCurrPseudoCode.Name = "tblCurrPseudoCode";
            this.tblCurrPseudoCode.NamedProperties.Put("DefaultOrderBy", "");
            this.tblCurrPseudoCode.NamedProperties.Put("DefaultWhere", "");
            this.tblCurrPseudoCode.NamedProperties.Put("LogicalUnit", "PseudoCodes");
            this.tblCurrPseudoCode.NamedProperties.Put("PackageName", "PSEUDO_CODES_API");
            this.tblCurrPseudoCode.NamedProperties.Put("ResizeableChildObject", "");
            this.tblCurrPseudoCode.NamedProperties.Put("ViewName", "PRIVATE_PSEUDO_CODES");
            this.tblCurrPseudoCode.NamedProperties.Put("Warnings", "FALSE");
            this.tblCurrPseudoCode.EnableDisableProjectActivityIdEvent += new System.EventHandler<Ifs.Application.Accrul.cChildTableFin.cChildTableFinEventArgs>(this.tblCurrPseudoCode_EnableDisableProjectActivityIdEvent);
            this.tblCurrPseudoCode.DataRecordGetDefaultsEvent += new System.EventHandler<Ifs.Fnd.ApplicationForms.FndReturnEventArgsSalBoolean>(this.tblCurrPseudoCode_DataRecordGetDefaultsEvent);
            this.tblCurrPseudoCode.Controls.SetChildIndex(this.tblCurrPseudoCode_colsProjectActivityIdEnabled, 0);
            this.tblCurrPseudoCode.Controls.SetChildIndex(this.tblCurrPseudoCode_colsProjectId, 0);
            this.tblCurrPseudoCode.Controls.SetChildIndex(this.tblCurrPseudoCode_colsPseudoCodeOwnership, 0);
            this.tblCurrPseudoCode.Controls.SetChildIndex(this.tblCurrPseudoCode_colnQuantity, 0);
            this.tblCurrPseudoCode.Controls.SetChildIndex(this.tblCurrPseudoCode_colsText, 0);
            this.tblCurrPseudoCode.Controls.SetChildIndex(this.tblCurrPseudoCode_colnProjectActivityId, 0);
            this.tblCurrPseudoCode.Controls.SetChildIndex(this.tblCurrPseudoCode_colsProcessCode, 0);
            this.tblCurrPseudoCode.Controls.SetChildIndex(this.tblCurrPseudoCode_colsCodeJ, 0);
            this.tblCurrPseudoCode.Controls.SetChildIndex(this.tblCurrPseudoCode_colsCodeI, 0);
            this.tblCurrPseudoCode.Controls.SetChildIndex(this.tblCurrPseudoCode_colsCodeH, 0);
            this.tblCurrPseudoCode.Controls.SetChildIndex(this.tblCurrPseudoCode_colsCodeG, 0);
            this.tblCurrPseudoCode.Controls.SetChildIndex(this.tblCurrPseudoCode_colsCodeF, 0);
            this.tblCurrPseudoCode.Controls.SetChildIndex(this.tblCurrPseudoCode_colsCodeE, 0);
            this.tblCurrPseudoCode.Controls.SetChildIndex(this.tblCurrPseudoCode_colsCodeD, 0);
            this.tblCurrPseudoCode.Controls.SetChildIndex(this.tblCurrPseudoCode_colsCodeC, 0);
            this.tblCurrPseudoCode.Controls.SetChildIndex(this.tblCurrPseudoCode_colsCodeB, 0);
            this.tblCurrPseudoCode.Controls.SetChildIndex(this.tblCurrPseudoCode_colsAccount, 0);
            this.tblCurrPseudoCode.Controls.SetChildIndex(this.tblCurrPseudoCode_colsDescription, 0);
            this.tblCurrPseudoCode.Controls.SetChildIndex(this.tblCurrPseudoCode_colsPseudoCode, 0);
            this.tblCurrPseudoCode.Controls.SetChildIndex(this.tblCurrPseudoCode_colsUserId, 0);
            this.tblCurrPseudoCode.Controls.SetChildIndex(this.tblCurrPseudoCode_colsCompany, 0);
            // 
            // tblCurrPseudoCode_colsCompany
            // 
            this.tblCurrPseudoCode_colsCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblCurrPseudoCode_colsCompany, "tblCurrPseudoCode_colsCompany");
            this.tblCurrPseudoCode_colsCompany.MaxLength = 20;
            this.tblCurrPseudoCode_colsCompany.Name = "tblCurrPseudoCode_colsCompany";
            this.tblCurrPseudoCode_colsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.tblCurrPseudoCode_colsCompany.NamedProperties.Put("FieldFlags", "67");
            this.tblCurrPseudoCode_colsCompany.NamedProperties.Put("LovReference", "COMPANY_FINANCE");
            this.tblCurrPseudoCode_colsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.tblCurrPseudoCode_colsCompany.Position = 3;
            // 
            // tblCurrPseudoCode_colsUserId
            // 
            this.tblCurrPseudoCode_colsUserId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblCurrPseudoCode_colsUserId.MaxLength = 30;
            this.tblCurrPseudoCode_colsUserId.Name = "tblCurrPseudoCode_colsUserId";
            this.tblCurrPseudoCode_colsUserId.NamedProperties.Put("EnumerateMethod", "");
            this.tblCurrPseudoCode_colsUserId.NamedProperties.Put("FieldFlags", "161");
            this.tblCurrPseudoCode_colsUserId.NamedProperties.Put("LovReference", "");
            this.tblCurrPseudoCode_colsUserId.NamedProperties.Put("ResizeableChildObject", "");
            this.tblCurrPseudoCode_colsUserId.NamedProperties.Put("SqlColumn", "USER_NAME");
            this.tblCurrPseudoCode_colsUserId.NamedProperties.Put("ValidateMethod", "");
            this.tblCurrPseudoCode_colsUserId.Position = 4;
            resources.ApplyResources(this.tblCurrPseudoCode_colsUserId, "tblCurrPseudoCode_colsUserId");
            // 
            // tblCurrPseudoCode_colsPseudoCode
            // 
            this.tblCurrPseudoCode_colsPseudoCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblCurrPseudoCode_colsPseudoCode.MaxLength = 20;
            this.tblCurrPseudoCode_colsPseudoCode.Name = "tblCurrPseudoCode_colsPseudoCode";
            this.tblCurrPseudoCode_colsPseudoCode.NamedProperties.Put("EnumerateMethod", "");
            this.tblCurrPseudoCode_colsPseudoCode.NamedProperties.Put("FieldFlags", "167");
            this.tblCurrPseudoCode_colsPseudoCode.NamedProperties.Put("LovReference", "");
            this.tblCurrPseudoCode_colsPseudoCode.NamedProperties.Put("SqlColumn", "PSEUDO_CODE");
            this.tblCurrPseudoCode_colsPseudoCode.Position = 5;
            resources.ApplyResources(this.tblCurrPseudoCode_colsPseudoCode, "tblCurrPseudoCode_colsPseudoCode");
            this.tblCurrPseudoCode_colsPseudoCode.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblCurrPseudoCode_colsPseudoCode_WindowActions);

            // 
            // tblCurrPseudoCode_colsDescription
            // 
            this.tblCurrPseudoCode_colsDescription.Name = "tblCurrPseudoCode_colsDescription";
            this.tblCurrPseudoCode_colsDescription.NamedProperties.Put("EnumerateMethod", "");
            this.tblCurrPseudoCode_colsDescription.NamedProperties.Put("FieldFlags", "295");
            this.tblCurrPseudoCode_colsDescription.NamedProperties.Put("LovReference", "");
            this.tblCurrPseudoCode_colsDescription.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            this.tblCurrPseudoCode_colsDescription.Position = 6;
            resources.ApplyResources(this.tblCurrPseudoCode_colsDescription, "tblCurrPseudoCode_colsDescription");
            this.tblCurrPseudoCode_colsDescription.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblCurrPseudoCode_colsDescription_WindowActions);
            // 
            // tblCurrPseudoCode_colsAccount
            // 
            this.tblCurrPseudoCode_colsAccount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblCurrPseudoCode_colsAccount.MaxLength = 20;
            this.tblCurrPseudoCode_colsAccount.Name = "tblCurrPseudoCode_colsAccount";
            this.tblCurrPseudoCode_colsAccount.NamedProperties.Put("EnumerateMethod", "");
            this.tblCurrPseudoCode_colsAccount.NamedProperties.Put("FieldFlags", "294");
            this.tblCurrPseudoCode_colsAccount.NamedProperties.Put("LovReference", "ACCOUNT(COMPANY)");
            this.tblCurrPseudoCode_colsAccount.NamedProperties.Put("SqlColumn", "ACCOUNT");
            this.tblCurrPseudoCode_colsAccount.Position = 7;
            resources.ApplyResources(this.tblCurrPseudoCode_colsAccount, "tblCurrPseudoCode_colsAccount");
            this.tblCurrPseudoCode_colsAccount.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblCurrPseudoCode_colsAccount_WindowActions);
            // 
            // tblCurrPseudoCode_colsCodeB
            // 
            this.tblCurrPseudoCode_colsCodeB.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblCurrPseudoCode_colsCodeB.MaxLength = 20;
            this.tblCurrPseudoCode_colsCodeB.Name = "tblCurrPseudoCode_colsCodeB";
            this.tblCurrPseudoCode_colsCodeB.NamedProperties.Put("EnumerateMethod", "");
            this.tblCurrPseudoCode_colsCodeB.NamedProperties.Put("FieldFlags", "294");
            this.tblCurrPseudoCode_colsCodeB.NamedProperties.Put("LovReference", "CODE_B(COMPANY)");
            this.tblCurrPseudoCode_colsCodeB.NamedProperties.Put("SqlColumn", "CODE_B");
            this.tblCurrPseudoCode_colsCodeB.Position = 8;
            resources.ApplyResources(this.tblCurrPseudoCode_colsCodeB, "tblCurrPseudoCode_colsCodeB");
            this.tblCurrPseudoCode_colsCodeB.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblCurrPseudoCode_colsCodeB_WindowActions);
            // 
            // tblCurrPseudoCode_colsCodeC
            // 
            this.tblCurrPseudoCode_colsCodeC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblCurrPseudoCode_colsCodeC.MaxLength = 20;
            this.tblCurrPseudoCode_colsCodeC.Name = "tblCurrPseudoCode_colsCodeC";
            this.tblCurrPseudoCode_colsCodeC.NamedProperties.Put("EnumerateMethod", "");
            this.tblCurrPseudoCode_colsCodeC.NamedProperties.Put("FieldFlags", "294");
            this.tblCurrPseudoCode_colsCodeC.NamedProperties.Put("LovReference", "CODE_C(COMPANY)");
            this.tblCurrPseudoCode_colsCodeC.NamedProperties.Put("SqlColumn", "CODE_C");
            this.tblCurrPseudoCode_colsCodeC.Position = 9;
            resources.ApplyResources(this.tblCurrPseudoCode_colsCodeC, "tblCurrPseudoCode_colsCodeC");
            this.tblCurrPseudoCode_colsCodeC.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblCurrPseudoCode_colsCodeC_WindowActions);
            // 
            // tblCurrPseudoCode_colsCodeD
            // 
            this.tblCurrPseudoCode_colsCodeD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblCurrPseudoCode_colsCodeD.MaxLength = 20;
            this.tblCurrPseudoCode_colsCodeD.Name = "tblCurrPseudoCode_colsCodeD";
            this.tblCurrPseudoCode_colsCodeD.NamedProperties.Put("EnumerateMethod", "");
            this.tblCurrPseudoCode_colsCodeD.NamedProperties.Put("FieldFlags", "294");
            this.tblCurrPseudoCode_colsCodeD.NamedProperties.Put("LovReference", "CODE_D(COMPANY)");
            this.tblCurrPseudoCode_colsCodeD.NamedProperties.Put("SqlColumn", "CODE_D");
            this.tblCurrPseudoCode_colsCodeD.Position = 10;
            resources.ApplyResources(this.tblCurrPseudoCode_colsCodeD, "tblCurrPseudoCode_colsCodeD");
            this.tblCurrPseudoCode_colsCodeD.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblCurrPseudoCode_colsCodeD_WindowActions);
            // 
            // tblCurrPseudoCode_colsCodeE
            // 
            this.tblCurrPseudoCode_colsCodeE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblCurrPseudoCode_colsCodeE.MaxLength = 20;
            this.tblCurrPseudoCode_colsCodeE.Name = "tblCurrPseudoCode_colsCodeE";
            this.tblCurrPseudoCode_colsCodeE.NamedProperties.Put("EnumerateMethod", "");
            this.tblCurrPseudoCode_colsCodeE.NamedProperties.Put("FieldFlags", "294");
            this.tblCurrPseudoCode_colsCodeE.NamedProperties.Put("LovReference", "CODE_E(COMPANY)");
            this.tblCurrPseudoCode_colsCodeE.NamedProperties.Put("SqlColumn", "CODE_E");
            this.tblCurrPseudoCode_colsCodeE.Position = 11;
            resources.ApplyResources(this.tblCurrPseudoCode_colsCodeE, "tblCurrPseudoCode_colsCodeE");
            this.tblCurrPseudoCode_colsCodeE.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblCurrPseudoCode_colsCodeE_WindowActions);
            // 
            // tblCurrPseudoCode_colsCodeF
            // 
            this.tblCurrPseudoCode_colsCodeF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblCurrPseudoCode_colsCodeF.MaxLength = 20;
            this.tblCurrPseudoCode_colsCodeF.Name = "tblCurrPseudoCode_colsCodeF";
            this.tblCurrPseudoCode_colsCodeF.NamedProperties.Put("EnumerateMethod", "");
            this.tblCurrPseudoCode_colsCodeF.NamedProperties.Put("FieldFlags", "294");
            this.tblCurrPseudoCode_colsCodeF.NamedProperties.Put("LovReference", "CODE_F(COMPANY)");
            this.tblCurrPseudoCode_colsCodeF.NamedProperties.Put("SqlColumn", "CODE_F");
            this.tblCurrPseudoCode_colsCodeF.Position = 12;
            resources.ApplyResources(this.tblCurrPseudoCode_colsCodeF, "tblCurrPseudoCode_colsCodeF");
            this.tblCurrPseudoCode_colsCodeF.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblCurrPseudoCode_colsCodeF_WindowActions);
            // 
            // tblCurrPseudoCode_colsCodeG
            // 
            this.tblCurrPseudoCode_colsCodeG.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblCurrPseudoCode_colsCodeG.MaxLength = 20;
            this.tblCurrPseudoCode_colsCodeG.Name = "tblCurrPseudoCode_colsCodeG";
            this.tblCurrPseudoCode_colsCodeG.NamedProperties.Put("EnumerateMethod", "");
            this.tblCurrPseudoCode_colsCodeG.NamedProperties.Put("FieldFlags", "294");
            this.tblCurrPseudoCode_colsCodeG.NamedProperties.Put("LovReference", "CODE_G(COMPANY)");
            this.tblCurrPseudoCode_colsCodeG.NamedProperties.Put("SqlColumn", "CODE_G");
            this.tblCurrPseudoCode_colsCodeG.Position = 13;
            resources.ApplyResources(this.tblCurrPseudoCode_colsCodeG, "tblCurrPseudoCode_colsCodeG");
            this.tblCurrPseudoCode_colsCodeG.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblCurrPseudoCode_colsCodeG_WindowActions);
            // 
            // tblCurrPseudoCode_colsCodeH
            // 
            this.tblCurrPseudoCode_colsCodeH.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblCurrPseudoCode_colsCodeH.MaxLength = 20;
            this.tblCurrPseudoCode_colsCodeH.Name = "tblCurrPseudoCode_colsCodeH";
            this.tblCurrPseudoCode_colsCodeH.NamedProperties.Put("EnumerateMethod", "");
            this.tblCurrPseudoCode_colsCodeH.NamedProperties.Put("FieldFlags", "294");
            this.tblCurrPseudoCode_colsCodeH.NamedProperties.Put("LovReference", "CODE_H(COMPANY)");
            this.tblCurrPseudoCode_colsCodeH.NamedProperties.Put("SqlColumn", "CODE_H");
            this.tblCurrPseudoCode_colsCodeH.Position = 14;
            resources.ApplyResources(this.tblCurrPseudoCode_colsCodeH, "tblCurrPseudoCode_colsCodeH");
            this.tblCurrPseudoCode_colsCodeH.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblCurrPseudoCode_colsCodeH_WindowActions);
            // 
            // tblCurrPseudoCode_colsCodeI
            // 
            this.tblCurrPseudoCode_colsCodeI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblCurrPseudoCode_colsCodeI.MaxLength = 20;
            this.tblCurrPseudoCode_colsCodeI.Name = "tblCurrPseudoCode_colsCodeI";
            this.tblCurrPseudoCode_colsCodeI.NamedProperties.Put("EnumerateMethod", "");
            this.tblCurrPseudoCode_colsCodeI.NamedProperties.Put("FieldFlags", "294");
            this.tblCurrPseudoCode_colsCodeI.NamedProperties.Put("LovReference", "CODE_I(COMPANY)");
            this.tblCurrPseudoCode_colsCodeI.NamedProperties.Put("SqlColumn", "CODE_I");
            this.tblCurrPseudoCode_colsCodeI.Position = 15;
            resources.ApplyResources(this.tblCurrPseudoCode_colsCodeI, "tblCurrPseudoCode_colsCodeI");
            this.tblCurrPseudoCode_colsCodeI.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblCurrPseudoCode_colsCodeI_WindowActions);
            // 
            // tblCurrPseudoCode_colsCodeJ
            // 
            this.tblCurrPseudoCode_colsCodeJ.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblCurrPseudoCode_colsCodeJ.MaxLength = 20;
            this.tblCurrPseudoCode_colsCodeJ.Name = "tblCurrPseudoCode_colsCodeJ";
            this.tblCurrPseudoCode_colsCodeJ.NamedProperties.Put("EnumerateMethod", "");
            this.tblCurrPseudoCode_colsCodeJ.NamedProperties.Put("FieldFlags", "294");
            this.tblCurrPseudoCode_colsCodeJ.NamedProperties.Put("LovReference", "CODE_J(COMPANY)");
            this.tblCurrPseudoCode_colsCodeJ.NamedProperties.Put("SqlColumn", "CODE_J");
            this.tblCurrPseudoCode_colsCodeJ.Position = 16;
            resources.ApplyResources(this.tblCurrPseudoCode_colsCodeJ, "tblCurrPseudoCode_colsCodeJ");
            this.tblCurrPseudoCode_colsCodeJ.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblCurrPseudoCode_colsCodeJ_WindowActions);
            // 
            // tblCurrPseudoCode_colsProcessCode
            // 
            this.tblCurrPseudoCode_colsProcessCode.MaxLength = 10;
            this.tblCurrPseudoCode_colsProcessCode.Name = "tblCurrPseudoCode_colsProcessCode";
            this.tblCurrPseudoCode_colsProcessCode.NamedProperties.Put("EnumerateMethod", "");
            this.tblCurrPseudoCode_colsProcessCode.NamedProperties.Put("FieldFlags", "294");
            this.tblCurrPseudoCode_colsProcessCode.NamedProperties.Put("LovReference", "ACCOUNT_PROCESS_CODE(COMPANY)");
            this.tblCurrPseudoCode_colsProcessCode.NamedProperties.Put("ResizeableChildObject", "");
            this.tblCurrPseudoCode_colsProcessCode.NamedProperties.Put("SqlColumn", "PROCESS_CODE");
            this.tblCurrPseudoCode_colsProcessCode.NamedProperties.Put("ValidateMethod", "");
            this.tblCurrPseudoCode_colsProcessCode.Position = 17;
            resources.ApplyResources(this.tblCurrPseudoCode_colsProcessCode, "tblCurrPseudoCode_colsProcessCode");
            this.tblCurrPseudoCode_colsProcessCode.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblCurrPseudoCode_colsProcessCode_WindowActions);
            // 
            // tblCurrPseudoCode_colnProjectActivityId
            // 
            this.tblCurrPseudoCode_colnProjectActivityId.Name = "tblCurrPseudoCode_colnProjectActivityId";
            this.tblCurrPseudoCode_colnProjectActivityId.NamedProperties.Put("EnumerateMethod", "");
            this.tblCurrPseudoCode_colnProjectActivityId.NamedProperties.Put("FieldFlags", "294");
            this.tblCurrPseudoCode_colnProjectActivityId.NamedProperties.Put("Format", "");
            this.tblCurrPseudoCode_colnProjectActivityId.NamedProperties.Put("LovReference", "PROJECT_ACTIVITY_POSTABLE(PROJECT_ID)");
            this.tblCurrPseudoCode_colnProjectActivityId.NamedProperties.Put("SqlColumn", "PROJECT_ACTIVITY_ID");
            this.tblCurrPseudoCode_colnProjectActivityId.Position = 18;
            resources.ApplyResources(this.tblCurrPseudoCode_colnProjectActivityId, "tblCurrPseudoCode_colnProjectActivityId");
            this.tblCurrPseudoCode_colnProjectActivityId.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblCurrPseudoCode_colnProjectActivityId_WindowActions);
            // 
            // tblCurrPseudoCode_colsText
            // 
            this.tblCurrPseudoCode_colsText.MaxLength = 200;
            this.tblCurrPseudoCode_colsText.Name = "tblCurrPseudoCode_colsText";
            this.tblCurrPseudoCode_colsText.NamedProperties.Put("EnumerateMethod", "");
            this.tblCurrPseudoCode_colsText.NamedProperties.Put("FieldFlags", "294");
            this.tblCurrPseudoCode_colsText.NamedProperties.Put("LovReference", "");
            this.tblCurrPseudoCode_colsText.NamedProperties.Put("SqlColumn", "TEXT");
            this.tblCurrPseudoCode_colsText.Position = 19;
            resources.ApplyResources(this.tblCurrPseudoCode_colsText, "tblCurrPseudoCode_colsText");
            this.tblCurrPseudoCode_colsText.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblCurrPseudoCode_colsText_WindowActions);
            // 
            // tblCurrPseudoCode_colnQuantity
            // 
            this.tblCurrPseudoCode_colnQuantity.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblCurrPseudoCode_colnQuantity.MaxLength = 18;
            this.tblCurrPseudoCode_colnQuantity.Name = "tblCurrPseudoCode_colnQuantity";
            this.tblCurrPseudoCode_colnQuantity.NamedProperties.Put("EnumerateMethod", "");
            this.tblCurrPseudoCode_colnQuantity.NamedProperties.Put("FieldFlags", "294");
            this.tblCurrPseudoCode_colnQuantity.NamedProperties.Put("LovReference", "");
            this.tblCurrPseudoCode_colnQuantity.NamedProperties.Put("SqlColumn", "QUANTITY");
            this.tblCurrPseudoCode_colnQuantity.Position = 20;
            resources.ApplyResources(this.tblCurrPseudoCode_colnQuantity, "tblCurrPseudoCode_colnQuantity");
            this.tblCurrPseudoCode_colnQuantity.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblCurrPseudoCode_colnQuantity_WindowActions);
            // 
            // tblCurrPseudoCode_colsPseudoCodeOwnership
            // 
            this.tblCurrPseudoCode_colsPseudoCodeOwnership.MaxLength = 200;
            this.tblCurrPseudoCode_colsPseudoCodeOwnership.Name = "tblCurrPseudoCode_colsPseudoCodeOwnership";
            this.tblCurrPseudoCode_colsPseudoCodeOwnership.NamedProperties.Put("EnumerateMethod", "Fin_Ownership_API.Enumerate");
            this.tblCurrPseudoCode_colsPseudoCodeOwnership.NamedProperties.Put("FieldFlags", "295");
            this.tblCurrPseudoCode_colsPseudoCodeOwnership.NamedProperties.Put("LovReference", "");
            this.tblCurrPseudoCode_colsPseudoCodeOwnership.NamedProperties.Put("SqlColumn", "PSEUDO_CODE_OWNERSHIP");
            this.tblCurrPseudoCode_colsPseudoCodeOwnership.Position = 21;
            resources.ApplyResources(this.tblCurrPseudoCode_colsPseudoCodeOwnership, "tblCurrPseudoCode_colsPseudoCodeOwnership");

            // 
            // tblCurrPseudoCode_colsProjectId
            // 
            this.tblCurrPseudoCode_colsProjectId.Name = "tblCurrPseudoCode_colsProjectId";
            this.tblCurrPseudoCode_colsProjectId.NamedProperties.Put("SqlColumn", "PROJECT_ID");
            this.tblCurrPseudoCode_colsProjectId.Position = 22;
            resources.ApplyResources(this.tblCurrPseudoCode_colsProjectId, "tblCurrPseudoCode_colsProjectId");
            // 
            // tblCurrPseudoCode_colsProjectActivityIdEnabled
            // 
            this.tblCurrPseudoCode_colsProjectActivityIdEnabled.Name = "tblCurrPseudoCode_colsProjectActivityIdEnabled";
            this.tblCurrPseudoCode_colsProjectActivityIdEnabled.Position = 23;
            resources.ApplyResources(this.tblCurrPseudoCode_colsProjectActivityIdEnabled, "tblCurrPseudoCode_colsProjectActivityIdEnabled");
            // 
            // dlgAddPseudoCode
            // 
            resources.ApplyResources(this, "$this");
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Name = "dlgAddPseudoCode";
            this.ShowIcon = false;
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dlgAddPseudoCode_WindowActions);
            this.ClientArea.ResumeLayout(false);
            this.tblCurrPseudoCode.ResumeLayout(false);
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

        public cChildTableFin tblCurrPseudoCode;
        protected cColumn tblCurrPseudoCode_colsCompany;
        protected cColumn tblCurrPseudoCode_colsUserId;
        protected cColumn tblCurrPseudoCode_colsPseudoCode;
        protected cColumn tblCurrPseudoCode_colsDescription;
        protected cColumnFin tblCurrPseudoCode_colsAccount;
        protected cColumnCodePartFin tblCurrPseudoCode_colsCodeB;
        protected cColumnCodePartFin tblCurrPseudoCode_colsCodeC;
        protected cColumnCodePartFin tblCurrPseudoCode_colsCodeD;
        protected cColumnCodePartFin tblCurrPseudoCode_colsCodeE;
        protected cColumnCodePartFin tblCurrPseudoCode_colsCodeF;
        protected cColumnCodePartFin tblCurrPseudoCode_colsCodeG;
        protected cColumnCodePartFin tblCurrPseudoCode_colsCodeH;
        protected cColumnCodePartFin tblCurrPseudoCode_colsCodeI;
        protected cColumnCodePartFin tblCurrPseudoCode_colsCodeJ;
        protected cColumn tblCurrPseudoCode_colsProcessCode;
        protected cColumn tblCurrPseudoCode_colnProjectActivityId;
        protected cColumn tblCurrPseudoCode_colsText;
        protected cColumn tblCurrPseudoCode_colnQuantity;
        protected cLookupColumn tblCurrPseudoCode_colsPseudoCodeOwnership;
        protected cColumn tblCurrPseudoCode_colsProjectActivityIdEnabled;
        protected cColumn tblCurrPseudoCode_colsProjectId;
		
	}
}
