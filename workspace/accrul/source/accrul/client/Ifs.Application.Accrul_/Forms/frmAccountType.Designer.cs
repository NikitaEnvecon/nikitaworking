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
	
	public partial class frmAccountType
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		// Bug 77248, Begin, changed the visibility to false
		protected cBackgroundText labeldfsCompany;
		// Bug 77248, End
		public cDataField dfsCompany;
		protected cBackgroundText labelcmbAccntType;
		public cRecSelExtComboBoxFin cmbAccntType;
		protected cBackgroundText labeldfsDescription;
		public cDataField dfsDescription;
		protected cBackgroundText labelcmbLogicalAccountType;
		public cComboBoxFin cmbLogicalAccountType;
		protected cBackgroundText labelcmbReqCodeBDefault;
		public cComboBoxFin cmbReqCodeBDefault;
		protected cBackgroundText labelcmbReqCodeCDefault;
		public cComboBoxFin cmbReqCodeCDefault;
		protected cBackgroundText labelcmbReqCodeDDefault;
		public cComboBoxFin cmbReqCodeDDefault;
		protected cBackgroundText labelcmbReqCodeEDefault;
		public cComboBoxFin cmbReqCodeEDefault;
		protected cBackgroundText labelcmbReqCodeFDefault;
		public cComboBoxFin cmbReqCodeFDefault;
		protected cBackgroundText labelcmbReqCodeGDefault;
		public cComboBoxFin cmbReqCodeGDefault;
		protected cBackgroundText labelcmbReqCodeHDefault;
		public cComboBoxFin cmbReqCodeHDefault;
		protected cBackgroundText labelcmbReqCodeIDefault;
		public cComboBoxFin cmbReqCodeIDefault;
		protected cBackgroundText labelcmbReqCodeJDefault;
		public cComboBoxFin cmbReqCodeJDefault;
		protected cBackgroundText labelcmbReqQuantityDefault;
		public cComboBoxFin cmbReqQuantityDefault;
		protected cBackgroundText labelcmbProcessCodeDefault;
		public cComboBoxFin cmbProcessCodeDefault;
		protected cBackgroundText labelcmbReqBudCodeBDefault;
		public cComboBoxFin cmbReqBudCodeBDefault;
		protected cBackgroundText labelcmbReqBudCodeCDefault;
		public cComboBoxFin cmbReqBudCodeCDefault;
		protected cBackgroundText labelcmbReqBudCodeDDefault;
		public cComboBoxFin cmbReqBudCodeDDefault;
		protected cBackgroundText labelcmbReqBudCodeEDefault;
		public cComboBoxFin cmbReqBudCodeEDefault;
		protected cBackgroundText labelcmbReqBudCodeFDefault;
		public cComboBoxFin cmbReqBudCodeFDefault;
		protected cBackgroundText labelcmbReqBudCodeGDefault;
		public cComboBoxFin cmbReqBudCodeGDefault;
		protected cBackgroundText labelcmbReqBudCodeHDefault;
		public cComboBoxFin cmbReqBudCodeHDefault;
		protected cBackgroundText labelcmbReqBudCodeIDefault;
		public cComboBoxFin cmbReqBudCodeIDefault;
		protected cBackgroundText labelcmbReqBudCodeJDefault;
		public cComboBoxFin cmbReqBudCodeJDefault;
		protected cBackgroundText labelcmbReqBudQuantityDefault;
		public cComboBoxFin cmbReqBudQuantityDefault;
		protected cBackgroundText labelcmbTextDefault;
		public cComboBoxFin cmbTextDefault;
		public cDataFieldFin dfAction;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAccountType));
            this.menuFrmMethods_menuChange__Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.labeldfsCompany = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsCompany = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelcmbAccntType = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbAccntType = new Ifs.Application.Accrul.cRecSelExtComboBoxFin();
            this.labeldfsDescription = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsDescription = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelcmbLogicalAccountType = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbLogicalAccountType = new Ifs.Application.Accrul.cComboBoxFin();
            this.labelcmbReqCodeBDefault = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbReqCodeBDefault = new Ifs.Application.Accrul.cComboBoxFin();
            this.labelcmbReqCodeCDefault = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbReqCodeCDefault = new Ifs.Application.Accrul.cComboBoxFin();
            this.labelcmbReqCodeDDefault = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbReqCodeDDefault = new Ifs.Application.Accrul.cComboBoxFin();
            this.labelcmbReqCodeEDefault = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbReqCodeEDefault = new Ifs.Application.Accrul.cComboBoxFin();
            this.labelcmbReqCodeFDefault = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbReqCodeFDefault = new Ifs.Application.Accrul.cComboBoxFin();
            this.labelcmbReqCodeGDefault = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbReqCodeGDefault = new Ifs.Application.Accrul.cComboBoxFin();
            this.labelcmbReqCodeHDefault = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbReqCodeHDefault = new Ifs.Application.Accrul.cComboBoxFin();
            this.labelcmbReqCodeIDefault = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbReqCodeIDefault = new Ifs.Application.Accrul.cComboBoxFin();
            this.labelcmbReqCodeJDefault = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbReqCodeJDefault = new Ifs.Application.Accrul.cComboBoxFin();
            this.labelcmbReqQuantityDefault = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbReqQuantityDefault = new Ifs.Application.Accrul.cComboBoxFin();
            this.labelcmbProcessCodeDefault = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbProcessCodeDefault = new Ifs.Application.Accrul.cComboBoxFin();
            this.labelcmbReqBudCodeBDefault = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbReqBudCodeBDefault = new Ifs.Application.Accrul.cComboBoxFin();
            this.labelcmbReqBudCodeCDefault = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbReqBudCodeCDefault = new Ifs.Application.Accrul.cComboBoxFin();
            this.labelcmbReqBudCodeDDefault = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbReqBudCodeDDefault = new Ifs.Application.Accrul.cComboBoxFin();
            this.labelcmbReqBudCodeEDefault = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbReqBudCodeEDefault = new Ifs.Application.Accrul.cComboBoxFin();
            this.labelcmbReqBudCodeFDefault = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbReqBudCodeFDefault = new Ifs.Application.Accrul.cComboBoxFin();
            this.labelcmbReqBudCodeGDefault = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbReqBudCodeGDefault = new Ifs.Application.Accrul.cComboBoxFin();
            this.labelcmbReqBudCodeHDefault = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbReqBudCodeHDefault = new Ifs.Application.Accrul.cComboBoxFin();
            this.labelcmbReqBudCodeIDefault = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbReqBudCodeIDefault = new Ifs.Application.Accrul.cComboBoxFin();
            this.labelcmbReqBudCodeJDefault = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbReqBudCodeJDefault = new Ifs.Application.Accrul.cComboBoxFin();
            this.labelcmbReqBudQuantityDefault = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbReqBudQuantityDefault = new Ifs.Application.Accrul.cComboBoxFin();
            this.labelcmbTextDefault = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbTextDefault = new Ifs.Application.Accrul.cComboBoxFin();
            this.dfAction = new Ifs.Application.Accrul.cDataFieldFin();
            this.menuFrmMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_Change = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuFrmMethods.SuspendLayout();
            this.SuspendLayout();
            // 
            // picTabs
            // 
            resources.ApplyResources(this.picTabs, "picTabs");
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuFrmMethods_menuChange__Company___);
            this.commandManager.ContextMenus.Add(this.menuFrmMethods);
            // 
            // menuFrmMethods_menuChange__Company___
            // 
            resources.ApplyResources(this.menuFrmMethods_menuChange__Company___, "menuFrmMethods_menuChange__Company___");
            this.menuFrmMethods_menuChange__Company___.Name = "menuFrmMethods_menuChange__Company___";
            this.menuFrmMethods_menuChange__Company___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Change_Execute);
            this.menuFrmMethods_menuChange__Company___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Change_Inquire);
            // 
            // labeldfsCompany
            // 
            resources.ApplyResources(this.labeldfsCompany, "labeldfsCompany");
            this.labeldfsCompany.Name = "labeldfsCompany";
            // 
            // dfsCompany
            // 
            this.dfsCompany.BackColor = System.Drawing.SystemColors.Control;
            this.dfsCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsCompany, "dfsCompany");
            this.dfsCompany.Name = "dfsCompany";
            this.dfsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.dfsCompany.NamedProperties.Put("FieldFlags", "67");
            this.dfsCompany.NamedProperties.Put("LovReference", "COMPANY_FINANCE");
            this.dfsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.dfsCompany.ReadOnly = true;
            // 
            // labelcmbAccntType
            // 
            resources.ApplyResources(this.labelcmbAccntType, "labelcmbAccntType");
            this.labelcmbAccntType.Name = "labelcmbAccntType";
            // 
            // cmbAccntType
            // 
            resources.ApplyResources(this.cmbAccntType, "cmbAccntType");
            this.cmbAccntType.Name = "cmbAccntType";
            this.cmbAccntType.NamedProperties.Put("EnumerateMethod", "");
            this.cmbAccntType.NamedProperties.Put("FieldFlags", "163");
            this.cmbAccntType.NamedProperties.Put("Format", "9");
            this.cmbAccntType.NamedProperties.Put("LovReference", "");
            this.cmbAccntType.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbAccntType.NamedProperties.Put("SqlColumn", "ACCNT_TYPE");
            this.cmbAccntType.NamedProperties.Put("ValidateMethod", "");
            this.cmbAccntType.NamedProperties.Put("XDataLength", "20");
            this.cmbAccntType.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbAccntType_WindowActions);
            // 
            // labeldfsDescription
            // 
            resources.ApplyResources(this.labeldfsDescription, "labeldfsDescription");
            this.labeldfsDescription.BackColor = System.Drawing.Color.Transparent;
            this.picTabs.SetControlTabPages(this.labeldfsDescription, "Default Code Part Demands;Default Budget Code Part Demands");
            this.labeldfsDescription.Name = "labeldfsDescription";
            // 
            // dfsDescription
            // 
            this.picTabs.SetControlTabPages(this.dfsDescription, "Default Code Part Demands;Default Budget Code Part Demands");
            resources.ApplyResources(this.dfsDescription, "dfsDescription");
            this.dfsDescription.Name = "dfsDescription";
            this.dfsDescription.NamedProperties.Put("EnumerateMethod", "");
            this.dfsDescription.NamedProperties.Put("FieldFlags", "295");
            this.dfsDescription.NamedProperties.Put("LovReference", "");
            this.dfsDescription.NamedProperties.Put("ParentName", "cmbAccntType");
            this.dfsDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsDescription.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            this.dfsDescription.NamedProperties.Put("ValidateMethod", "");
            // 
            // labelcmbLogicalAccountType
            // 
            resources.ApplyResources(this.labelcmbLogicalAccountType, "labelcmbLogicalAccountType");
            this.labelcmbLogicalAccountType.Name = "labelcmbLogicalAccountType";
            // 
            // cmbLogicalAccountType
            // 
            resources.ApplyResources(this.cmbLogicalAccountType, "cmbLogicalAccountType");
            this.cmbLogicalAccountType.Name = "cmbLogicalAccountType";
            this.cmbLogicalAccountType.NamedProperties.Put("EnumerateMethod", "ACCOUNT_TYPE_VALUE_API.Enumerate");
            this.cmbLogicalAccountType.NamedProperties.Put("FieldFlags", "295");
            this.cmbLogicalAccountType.NamedProperties.Put("LovReference", "");
            this.cmbLogicalAccountType.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbLogicalAccountType.NamedProperties.Put("SqlColumn", "LOGICAL_ACCOUNT_TYPE");
            this.cmbLogicalAccountType.NamedProperties.Put("ValidateMethod", "");
            this.cmbLogicalAccountType.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbLogicalAccountType_WindowActions);
            // 
            // labelcmbReqCodeBDefault
            // 
            resources.ApplyResources(this.labelcmbReqCodeBDefault, "labelcmbReqCodeBDefault");
            this.labelcmbReqCodeBDefault.BackColor = System.Drawing.Color.Transparent;
            this.picTabs.SetControlTabPages(this.labelcmbReqCodeBDefault, "Default Code Part Demands");
            this.labelcmbReqCodeBDefault.Name = "labelcmbReqCodeBDefault";
            // 
            // cmbReqCodeBDefault
            // 
            this.picTabs.SetControlTabPages(this.cmbReqCodeBDefault, "Default Code Part Demands");
            resources.ApplyResources(this.cmbReqCodeBDefault, "cmbReqCodeBDefault");
            this.cmbReqCodeBDefault.Name = "cmbReqCodeBDefault";
            this.cmbReqCodeBDefault.NamedProperties.Put("EnumerateMethod", "ACCOUNT_REQUEST_API.Enumerate");
            this.cmbReqCodeBDefault.NamedProperties.Put("FieldFlags", "295");
            this.cmbReqCodeBDefault.NamedProperties.Put("LovReference", "");
            this.cmbReqCodeBDefault.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbReqCodeBDefault.NamedProperties.Put("SqlColumn", "REQ_CODE_B_DEFAULT");
            this.cmbReqCodeBDefault.NamedProperties.Put("ValidateMethod", "");
            this.cmbReqCodeBDefault.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbReqCodeBDefault_WindowActions);
            // 
            // labelcmbReqCodeCDefault
            // 
            resources.ApplyResources(this.labelcmbReqCodeCDefault, "labelcmbReqCodeCDefault");
            this.labelcmbReqCodeCDefault.BackColor = System.Drawing.Color.Transparent;
            this.picTabs.SetControlTabPages(this.labelcmbReqCodeCDefault, "Default Code Part Demands");
            this.labelcmbReqCodeCDefault.Name = "labelcmbReqCodeCDefault";
            // 
            // cmbReqCodeCDefault
            // 
            this.picTabs.SetControlTabPages(this.cmbReqCodeCDefault, "Default Code Part Demands");
            resources.ApplyResources(this.cmbReqCodeCDefault, "cmbReqCodeCDefault");
            this.cmbReqCodeCDefault.Name = "cmbReqCodeCDefault";
            this.cmbReqCodeCDefault.NamedProperties.Put("EnumerateMethod", "ACCOUNT_REQUEST_API.Enumerate");
            this.cmbReqCodeCDefault.NamedProperties.Put("FieldFlags", "295");
            this.cmbReqCodeCDefault.NamedProperties.Put("LovReference", "");
            this.cmbReqCodeCDefault.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbReqCodeCDefault.NamedProperties.Put("SqlColumn", "REQ_CODE_C_DEFAULT");
            this.cmbReqCodeCDefault.NamedProperties.Put("ValidateMethod", "");
            this.cmbReqCodeCDefault.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbReqCodeCDefault_WindowActions);
            // 
            // labelcmbReqCodeDDefault
            // 
            resources.ApplyResources(this.labelcmbReqCodeDDefault, "labelcmbReqCodeDDefault");
            this.labelcmbReqCodeDDefault.BackColor = System.Drawing.Color.Transparent;
            this.picTabs.SetControlTabPages(this.labelcmbReqCodeDDefault, "Default Code Part Demands");
            this.labelcmbReqCodeDDefault.Name = "labelcmbReqCodeDDefault";
            // 
            // cmbReqCodeDDefault
            // 
            this.picTabs.SetControlTabPages(this.cmbReqCodeDDefault, "Default Code Part Demands");
            resources.ApplyResources(this.cmbReqCodeDDefault, "cmbReqCodeDDefault");
            this.cmbReqCodeDDefault.Name = "cmbReqCodeDDefault";
            this.cmbReqCodeDDefault.NamedProperties.Put("EnumerateMethod", "ACCOUNT_REQUEST_API.Enumerate");
            this.cmbReqCodeDDefault.NamedProperties.Put("FieldFlags", "295");
            this.cmbReqCodeDDefault.NamedProperties.Put("LovReference", "");
            this.cmbReqCodeDDefault.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbReqCodeDDefault.NamedProperties.Put("SqlColumn", "REQ_CODE_D_DEFAULT");
            this.cmbReqCodeDDefault.NamedProperties.Put("ValidateMethod", "");
            this.cmbReqCodeDDefault.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbReqCodeDDefault_WindowActions);
            // 
            // labelcmbReqCodeEDefault
            // 
            resources.ApplyResources(this.labelcmbReqCodeEDefault, "labelcmbReqCodeEDefault");
            this.labelcmbReqCodeEDefault.BackColor = System.Drawing.Color.Transparent;
            this.picTabs.SetControlTabPages(this.labelcmbReqCodeEDefault, "Default Code Part Demands");
            this.labelcmbReqCodeEDefault.Name = "labelcmbReqCodeEDefault";
            // 
            // cmbReqCodeEDefault
            // 
            this.picTabs.SetControlTabPages(this.cmbReqCodeEDefault, "Default Code Part Demands");
            resources.ApplyResources(this.cmbReqCodeEDefault, "cmbReqCodeEDefault");
            this.cmbReqCodeEDefault.Name = "cmbReqCodeEDefault";
            this.cmbReqCodeEDefault.NamedProperties.Put("EnumerateMethod", "ACCOUNT_REQUEST_API.Enumerate");
            this.cmbReqCodeEDefault.NamedProperties.Put("FieldFlags", "295");
            this.cmbReqCodeEDefault.NamedProperties.Put("LovReference", "");
            this.cmbReqCodeEDefault.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbReqCodeEDefault.NamedProperties.Put("SqlColumn", "REQ_CODE_E_DEFAULT");
            this.cmbReqCodeEDefault.NamedProperties.Put("ValidateMethod", "");
            this.cmbReqCodeEDefault.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbReqCodeEDefault_WindowActions);
            // 
            // labelcmbReqCodeFDefault
            // 
            resources.ApplyResources(this.labelcmbReqCodeFDefault, "labelcmbReqCodeFDefault");
            this.labelcmbReqCodeFDefault.BackColor = System.Drawing.Color.Transparent;
            this.picTabs.SetControlTabPages(this.labelcmbReqCodeFDefault, "Default Code Part Demands");
            this.labelcmbReqCodeFDefault.Name = "labelcmbReqCodeFDefault";
            // 
            // cmbReqCodeFDefault
            // 
            this.picTabs.SetControlTabPages(this.cmbReqCodeFDefault, "Default Code Part Demands");
            resources.ApplyResources(this.cmbReqCodeFDefault, "cmbReqCodeFDefault");
            this.cmbReqCodeFDefault.Name = "cmbReqCodeFDefault";
            this.cmbReqCodeFDefault.NamedProperties.Put("EnumerateMethod", "ACCOUNT_REQUEST_API.Enumerate");
            this.cmbReqCodeFDefault.NamedProperties.Put("FieldFlags", "295");
            this.cmbReqCodeFDefault.NamedProperties.Put("LovReference", "");
            this.cmbReqCodeFDefault.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbReqCodeFDefault.NamedProperties.Put("SqlColumn", "REQ_CODE_F_DEFAULT");
            this.cmbReqCodeFDefault.NamedProperties.Put("ValidateMethod", "");
            this.cmbReqCodeFDefault.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbReqCodeFDefault_WindowActions);
            // 
            // labelcmbReqCodeGDefault
            // 
            resources.ApplyResources(this.labelcmbReqCodeGDefault, "labelcmbReqCodeGDefault");
            this.labelcmbReqCodeGDefault.BackColor = System.Drawing.Color.Transparent;
            this.picTabs.SetControlTabPages(this.labelcmbReqCodeGDefault, "Default Code Part Demands");
            this.labelcmbReqCodeGDefault.Name = "labelcmbReqCodeGDefault";
            // 
            // cmbReqCodeGDefault
            // 
            this.picTabs.SetControlTabPages(this.cmbReqCodeGDefault, "Default Code Part Demands");
            resources.ApplyResources(this.cmbReqCodeGDefault, "cmbReqCodeGDefault");
            this.cmbReqCodeGDefault.Name = "cmbReqCodeGDefault";
            this.cmbReqCodeGDefault.NamedProperties.Put("EnumerateMethod", "ACCOUNT_REQUEST_API.Enumerate");
            this.cmbReqCodeGDefault.NamedProperties.Put("FieldFlags", "295");
            this.cmbReqCodeGDefault.NamedProperties.Put("LovReference", "");
            this.cmbReqCodeGDefault.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbReqCodeGDefault.NamedProperties.Put("SqlColumn", "REQ_CODE_G_DEFAULT");
            this.cmbReqCodeGDefault.NamedProperties.Put("ValidateMethod", "");
            this.cmbReqCodeGDefault.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbReqCodeGDefault_WindowActions);
            // 
            // labelcmbReqCodeHDefault
            // 
            resources.ApplyResources(this.labelcmbReqCodeHDefault, "labelcmbReqCodeHDefault");
            this.labelcmbReqCodeHDefault.BackColor = System.Drawing.Color.Transparent;
            this.picTabs.SetControlTabPages(this.labelcmbReqCodeHDefault, "Default Code Part Demands");
            this.labelcmbReqCodeHDefault.Name = "labelcmbReqCodeHDefault";
            // 
            // cmbReqCodeHDefault
            // 
            this.picTabs.SetControlTabPages(this.cmbReqCodeHDefault, "Default Code Part Demands");
            resources.ApplyResources(this.cmbReqCodeHDefault, "cmbReqCodeHDefault");
            this.cmbReqCodeHDefault.Name = "cmbReqCodeHDefault";
            this.cmbReqCodeHDefault.NamedProperties.Put("EnumerateMethod", "ACCOUNT_REQUEST_API.Enumerate");
            this.cmbReqCodeHDefault.NamedProperties.Put("FieldFlags", "295");
            this.cmbReqCodeHDefault.NamedProperties.Put("LovReference", "");
            this.cmbReqCodeHDefault.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbReqCodeHDefault.NamedProperties.Put("SqlColumn", "REQ_CODE_H_DEFAULT");
            this.cmbReqCodeHDefault.NamedProperties.Put("ValidateMethod", "");
            this.cmbReqCodeHDefault.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbReqCodeHDefault_WindowActions);
            // 
            // labelcmbReqCodeIDefault
            // 
            resources.ApplyResources(this.labelcmbReqCodeIDefault, "labelcmbReqCodeIDefault");
            this.labelcmbReqCodeIDefault.BackColor = System.Drawing.Color.Transparent;
            this.picTabs.SetControlTabPages(this.labelcmbReqCodeIDefault, "Default Code Part Demands");
            this.labelcmbReqCodeIDefault.Name = "labelcmbReqCodeIDefault";
            // 
            // cmbReqCodeIDefault
            // 
            this.picTabs.SetControlTabPages(this.cmbReqCodeIDefault, "Default Code Part Demands");
            resources.ApplyResources(this.cmbReqCodeIDefault, "cmbReqCodeIDefault");
            this.cmbReqCodeIDefault.Name = "cmbReqCodeIDefault";
            this.cmbReqCodeIDefault.NamedProperties.Put("EnumerateMethod", "ACCOUNT_REQUEST_API.Enumerate");
            this.cmbReqCodeIDefault.NamedProperties.Put("FieldFlags", "295");
            this.cmbReqCodeIDefault.NamedProperties.Put("LovReference", "");
            this.cmbReqCodeIDefault.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbReqCodeIDefault.NamedProperties.Put("SqlColumn", "REQ_CODE_I_DEFAULT");
            this.cmbReqCodeIDefault.NamedProperties.Put("ValidateMethod", "");
            this.cmbReqCodeIDefault.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbReqCodeIDefault_WindowActions);
            // 
            // labelcmbReqCodeJDefault
            // 
            resources.ApplyResources(this.labelcmbReqCodeJDefault, "labelcmbReqCodeJDefault");
            this.labelcmbReqCodeJDefault.BackColor = System.Drawing.Color.Transparent;
            this.picTabs.SetControlTabPages(this.labelcmbReqCodeJDefault, "Default Code Part Demands");
            this.labelcmbReqCodeJDefault.Name = "labelcmbReqCodeJDefault";
            // 
            // cmbReqCodeJDefault
            // 
            this.picTabs.SetControlTabPages(this.cmbReqCodeJDefault, "Default Code Part Demands");
            resources.ApplyResources(this.cmbReqCodeJDefault, "cmbReqCodeJDefault");
            this.cmbReqCodeJDefault.Name = "cmbReqCodeJDefault";
            this.cmbReqCodeJDefault.NamedProperties.Put("EnumerateMethod", "ACCOUNT_REQUEST_API.Enumerate");
            this.cmbReqCodeJDefault.NamedProperties.Put("FieldFlags", "295");
            this.cmbReqCodeJDefault.NamedProperties.Put("LovReference", "");
            this.cmbReqCodeJDefault.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbReqCodeJDefault.NamedProperties.Put("SqlColumn", "REQ_CODE_J_DEFAULT");
            this.cmbReqCodeJDefault.NamedProperties.Put("ValidateMethod", "");
            this.cmbReqCodeJDefault.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbReqCodeJDefault_WindowActions);
            // 
            // labelcmbReqQuantityDefault
            // 
            resources.ApplyResources(this.labelcmbReqQuantityDefault, "labelcmbReqQuantityDefault");
            this.labelcmbReqQuantityDefault.BackColor = System.Drawing.Color.Transparent;
            this.picTabs.SetControlTabPages(this.labelcmbReqQuantityDefault, "Default Code Part Demands");
            this.labelcmbReqQuantityDefault.Name = "labelcmbReqQuantityDefault";
            // 
            // cmbReqQuantityDefault
            // 
            this.picTabs.SetControlTabPages(this.cmbReqQuantityDefault, "Default Code Part Demands");
            resources.ApplyResources(this.cmbReqQuantityDefault, "cmbReqQuantityDefault");
            this.cmbReqQuantityDefault.Name = "cmbReqQuantityDefault";
            this.cmbReqQuantityDefault.NamedProperties.Put("EnumerateMethod", "ACCOUNT_REQUEST_API.Enumerate");
            this.cmbReqQuantityDefault.NamedProperties.Put("FieldFlags", "295");
            this.cmbReqQuantityDefault.NamedProperties.Put("LovReference", "");
            this.cmbReqQuantityDefault.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbReqQuantityDefault.NamedProperties.Put("SqlColumn", "REQ_QUANTITY_DEFAULT");
            this.cmbReqQuantityDefault.NamedProperties.Put("ValidateMethod", "");
            this.cmbReqQuantityDefault.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbReqQuantityDefault_WindowActions);
            // 
            // labelcmbProcessCodeDefault
            // 
            resources.ApplyResources(this.labelcmbProcessCodeDefault, "labelcmbProcessCodeDefault");
            this.labelcmbProcessCodeDefault.BackColor = System.Drawing.Color.Transparent;
            this.picTabs.SetControlTabPages(this.labelcmbProcessCodeDefault, "Default Code Part Demands");
            this.labelcmbProcessCodeDefault.Name = "labelcmbProcessCodeDefault";
            // 
            // cmbProcessCodeDefault
            // 
            this.picTabs.SetControlTabPages(this.cmbProcessCodeDefault, "Default Code Part Demands");
            resources.ApplyResources(this.cmbProcessCodeDefault, "cmbProcessCodeDefault");
            this.cmbProcessCodeDefault.Name = "cmbProcessCodeDefault";
            this.cmbProcessCodeDefault.NamedProperties.Put("EnumerateMethod", "ACCOUNT_REQUEST_API.Enumerate");
            this.cmbProcessCodeDefault.NamedProperties.Put("FieldFlags", "295");
            this.cmbProcessCodeDefault.NamedProperties.Put("LovReference", "");
            this.cmbProcessCodeDefault.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbProcessCodeDefault.NamedProperties.Put("SqlColumn", "PROCESS_CODE_DEFAULT");
            this.cmbProcessCodeDefault.NamedProperties.Put("ValidateMethod", "");
            this.cmbProcessCodeDefault.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbProcessCodeDefault_WindowActions);
            // 
            // labelcmbReqBudCodeBDefault
            // 
            resources.ApplyResources(this.labelcmbReqBudCodeBDefault, "labelcmbReqBudCodeBDefault");
            this.labelcmbReqBudCodeBDefault.BackColor = System.Drawing.Color.Transparent;
            this.picTabs.SetControlTabPages(this.labelcmbReqBudCodeBDefault, "Default Budget Code Part Demands");
            this.labelcmbReqBudCodeBDefault.Name = "labelcmbReqBudCodeBDefault";
            // 
            // cmbReqBudCodeBDefault
            // 
            this.picTabs.SetControlTabPages(this.cmbReqBudCodeBDefault, "Default Budget Code Part Demands");
            resources.ApplyResources(this.cmbReqBudCodeBDefault, "cmbReqBudCodeBDefault");
            this.cmbReqBudCodeBDefault.Name = "cmbReqBudCodeBDefault";
            this.cmbReqBudCodeBDefault.NamedProperties.Put("EnumerateMethod", "ACCOUNT_REQUEST_API.Enumerate");
            this.cmbReqBudCodeBDefault.NamedProperties.Put("FieldFlags", "295");
            this.cmbReqBudCodeBDefault.NamedProperties.Put("LovReference", "");
            this.cmbReqBudCodeBDefault.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbReqBudCodeBDefault.NamedProperties.Put("SqlColumn", "REQ_BUD_CODE_B_DEFAULT");
            this.cmbReqBudCodeBDefault.NamedProperties.Put("ValidateMethod", "");
            this.cmbReqBudCodeBDefault.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbReqBudCodeBDefault_WindowActions);
            // 
            // labelcmbReqBudCodeCDefault
            // 
            resources.ApplyResources(this.labelcmbReqBudCodeCDefault, "labelcmbReqBudCodeCDefault");
            this.labelcmbReqBudCodeCDefault.BackColor = System.Drawing.Color.Transparent;
            this.picTabs.SetControlTabPages(this.labelcmbReqBudCodeCDefault, "Default Budget Code Part Demands");
            this.labelcmbReqBudCodeCDefault.Name = "labelcmbReqBudCodeCDefault";
            // 
            // cmbReqBudCodeCDefault
            // 
            this.picTabs.SetControlTabPages(this.cmbReqBudCodeCDefault, "Default Budget Code Part Demands");
            resources.ApplyResources(this.cmbReqBudCodeCDefault, "cmbReqBudCodeCDefault");
            this.cmbReqBudCodeCDefault.Name = "cmbReqBudCodeCDefault";
            this.cmbReqBudCodeCDefault.NamedProperties.Put("EnumerateMethod", "ACCOUNT_REQUEST_API.Enumerate");
            this.cmbReqBudCodeCDefault.NamedProperties.Put("FieldFlags", "295");
            this.cmbReqBudCodeCDefault.NamedProperties.Put("LovReference", "");
            this.cmbReqBudCodeCDefault.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbReqBudCodeCDefault.NamedProperties.Put("SqlColumn", "REQ_BUD_CODE_C_DEFAULT");
            this.cmbReqBudCodeCDefault.NamedProperties.Put("ValidateMethod", "");
            this.cmbReqBudCodeCDefault.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbReqBudCodeCDefault_WindowActions);
            // 
            // labelcmbReqBudCodeDDefault
            // 
            resources.ApplyResources(this.labelcmbReqBudCodeDDefault, "labelcmbReqBudCodeDDefault");
            this.labelcmbReqBudCodeDDefault.BackColor = System.Drawing.Color.Transparent;
            this.picTabs.SetControlTabPages(this.labelcmbReqBudCodeDDefault, "Default Budget Code Part Demands");
            this.labelcmbReqBudCodeDDefault.Name = "labelcmbReqBudCodeDDefault";
            // 
            // cmbReqBudCodeDDefault
            // 
            this.picTabs.SetControlTabPages(this.cmbReqBudCodeDDefault, "Default Budget Code Part Demands");
            resources.ApplyResources(this.cmbReqBudCodeDDefault, "cmbReqBudCodeDDefault");
            this.cmbReqBudCodeDDefault.Name = "cmbReqBudCodeDDefault";
            this.cmbReqBudCodeDDefault.NamedProperties.Put("EnumerateMethod", "ACCOUNT_REQUEST_API.Enumerate");
            this.cmbReqBudCodeDDefault.NamedProperties.Put("FieldFlags", "295");
            this.cmbReqBudCodeDDefault.NamedProperties.Put("LovReference", "");
            this.cmbReqBudCodeDDefault.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbReqBudCodeDDefault.NamedProperties.Put("SqlColumn", "REQ_BUD_CODE_D_DEFAULT");
            this.cmbReqBudCodeDDefault.NamedProperties.Put("ValidateMethod", "");
            this.cmbReqBudCodeDDefault.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbReqBudCodeDDefault_WindowActions);
            // 
            // labelcmbReqBudCodeEDefault
            // 
            resources.ApplyResources(this.labelcmbReqBudCodeEDefault, "labelcmbReqBudCodeEDefault");
            this.labelcmbReqBudCodeEDefault.BackColor = System.Drawing.Color.Transparent;
            this.picTabs.SetControlTabPages(this.labelcmbReqBudCodeEDefault, "Default Budget Code Part Demands");
            this.labelcmbReqBudCodeEDefault.Name = "labelcmbReqBudCodeEDefault";
            // 
            // cmbReqBudCodeEDefault
            // 
            this.picTabs.SetControlTabPages(this.cmbReqBudCodeEDefault, "Default Budget Code Part Demands");
            resources.ApplyResources(this.cmbReqBudCodeEDefault, "cmbReqBudCodeEDefault");
            this.cmbReqBudCodeEDefault.Name = "cmbReqBudCodeEDefault";
            this.cmbReqBudCodeEDefault.NamedProperties.Put("EnumerateMethod", "ACCOUNT_REQUEST_API.Enumerate");
            this.cmbReqBudCodeEDefault.NamedProperties.Put("FieldFlags", "295");
            this.cmbReqBudCodeEDefault.NamedProperties.Put("LovReference", "");
            this.cmbReqBudCodeEDefault.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbReqBudCodeEDefault.NamedProperties.Put("SqlColumn", "REQ_BUD_CODE_E_DEFAULT");
            this.cmbReqBudCodeEDefault.NamedProperties.Put("ValidateMethod", "");
            this.cmbReqBudCodeEDefault.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbReqBudCodeEDefault_WindowActions);
            // 
            // labelcmbReqBudCodeFDefault
            // 
            resources.ApplyResources(this.labelcmbReqBudCodeFDefault, "labelcmbReqBudCodeFDefault");
            this.labelcmbReqBudCodeFDefault.BackColor = System.Drawing.Color.Transparent;
            this.picTabs.SetControlTabPages(this.labelcmbReqBudCodeFDefault, "Default Budget Code Part Demands");
            this.labelcmbReqBudCodeFDefault.Name = "labelcmbReqBudCodeFDefault";
            // 
            // cmbReqBudCodeFDefault
            // 
            this.picTabs.SetControlTabPages(this.cmbReqBudCodeFDefault, "Default Budget Code Part Demands");
            resources.ApplyResources(this.cmbReqBudCodeFDefault, "cmbReqBudCodeFDefault");
            this.cmbReqBudCodeFDefault.Name = "cmbReqBudCodeFDefault";
            this.cmbReqBudCodeFDefault.NamedProperties.Put("EnumerateMethod", "ACCOUNT_REQUEST_API.Enumerate");
            this.cmbReqBudCodeFDefault.NamedProperties.Put("FieldFlags", "295");
            this.cmbReqBudCodeFDefault.NamedProperties.Put("LovReference", "");
            this.cmbReqBudCodeFDefault.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbReqBudCodeFDefault.NamedProperties.Put("SqlColumn", "REQ_BUD_CODE_F_DEFAULT");
            this.cmbReqBudCodeFDefault.NamedProperties.Put("ValidateMethod", "");
            this.cmbReqBudCodeFDefault.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbReqBudCodeFDefault_WindowActions);
            // 
            // labelcmbReqBudCodeGDefault
            // 
            resources.ApplyResources(this.labelcmbReqBudCodeGDefault, "labelcmbReqBudCodeGDefault");
            this.labelcmbReqBudCodeGDefault.BackColor = System.Drawing.Color.Transparent;
            this.picTabs.SetControlTabPages(this.labelcmbReqBudCodeGDefault, "Default Budget Code Part Demands");
            this.labelcmbReqBudCodeGDefault.Name = "labelcmbReqBudCodeGDefault";
            // 
            // cmbReqBudCodeGDefault
            // 
            this.picTabs.SetControlTabPages(this.cmbReqBudCodeGDefault, "Default Budget Code Part Demands");
            resources.ApplyResources(this.cmbReqBudCodeGDefault, "cmbReqBudCodeGDefault");
            this.cmbReqBudCodeGDefault.Name = "cmbReqBudCodeGDefault";
            this.cmbReqBudCodeGDefault.NamedProperties.Put("EnumerateMethod", "ACCOUNT_REQUEST_API.Enumerate");
            this.cmbReqBudCodeGDefault.NamedProperties.Put("FieldFlags", "295");
            this.cmbReqBudCodeGDefault.NamedProperties.Put("LovReference", "");
            this.cmbReqBudCodeGDefault.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbReqBudCodeGDefault.NamedProperties.Put("SqlColumn", "REQ_BUD_CODE_G_DEFAULT");
            this.cmbReqBudCodeGDefault.NamedProperties.Put("ValidateMethod", "");
            this.cmbReqBudCodeGDefault.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbReqBudCodeGDefault_WindowActions);
            // 
            // labelcmbReqBudCodeHDefault
            // 
            resources.ApplyResources(this.labelcmbReqBudCodeHDefault, "labelcmbReqBudCodeHDefault");
            this.labelcmbReqBudCodeHDefault.BackColor = System.Drawing.Color.Transparent;
            this.picTabs.SetControlTabPages(this.labelcmbReqBudCodeHDefault, "Default Budget Code Part Demands");
            this.labelcmbReqBudCodeHDefault.Name = "labelcmbReqBudCodeHDefault";
            // 
            // cmbReqBudCodeHDefault
            // 
            this.picTabs.SetControlTabPages(this.cmbReqBudCodeHDefault, "Default Budget Code Part Demands");
            resources.ApplyResources(this.cmbReqBudCodeHDefault, "cmbReqBudCodeHDefault");
            this.cmbReqBudCodeHDefault.Name = "cmbReqBudCodeHDefault";
            this.cmbReqBudCodeHDefault.NamedProperties.Put("EnumerateMethod", "ACCOUNT_REQUEST_API.Enumerate");
            this.cmbReqBudCodeHDefault.NamedProperties.Put("FieldFlags", "295");
            this.cmbReqBudCodeHDefault.NamedProperties.Put("LovReference", "");
            this.cmbReqBudCodeHDefault.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbReqBudCodeHDefault.NamedProperties.Put("SqlColumn", "REQ_BUD_CODE_H_DEFAULT");
            this.cmbReqBudCodeHDefault.NamedProperties.Put("ValidateMethod", "");
            this.cmbReqBudCodeHDefault.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbReqBudCodeHDefault_WindowActions);
            // 
            // labelcmbReqBudCodeIDefault
            // 
            resources.ApplyResources(this.labelcmbReqBudCodeIDefault, "labelcmbReqBudCodeIDefault");
            this.labelcmbReqBudCodeIDefault.BackColor = System.Drawing.Color.Transparent;
            this.picTabs.SetControlTabPages(this.labelcmbReqBudCodeIDefault, "Default Budget Code Part Demands");
            this.labelcmbReqBudCodeIDefault.Name = "labelcmbReqBudCodeIDefault";
            // 
            // cmbReqBudCodeIDefault
            // 
            this.picTabs.SetControlTabPages(this.cmbReqBudCodeIDefault, "Default Budget Code Part Demands");
            resources.ApplyResources(this.cmbReqBudCodeIDefault, "cmbReqBudCodeIDefault");
            this.cmbReqBudCodeIDefault.Name = "cmbReqBudCodeIDefault";
            this.cmbReqBudCodeIDefault.NamedProperties.Put("EnumerateMethod", "ACCOUNT_REQUEST_API.Enumerate");
            this.cmbReqBudCodeIDefault.NamedProperties.Put("FieldFlags", "295");
            this.cmbReqBudCodeIDefault.NamedProperties.Put("LovReference", "");
            this.cmbReqBudCodeIDefault.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbReqBudCodeIDefault.NamedProperties.Put("SqlColumn", "REQ_BUD_CODE_I_DEFAULT");
            this.cmbReqBudCodeIDefault.NamedProperties.Put("ValidateMethod", "");
            this.cmbReqBudCodeIDefault.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbReqBudCodeIDefault_WindowActions);
            // 
            // labelcmbReqBudCodeJDefault
            // 
            resources.ApplyResources(this.labelcmbReqBudCodeJDefault, "labelcmbReqBudCodeJDefault");
            this.labelcmbReqBudCodeJDefault.BackColor = System.Drawing.Color.Transparent;
            this.picTabs.SetControlTabPages(this.labelcmbReqBudCodeJDefault, "Default Budget Code Part Demands");
            this.labelcmbReqBudCodeJDefault.Name = "labelcmbReqBudCodeJDefault";
            // 
            // cmbReqBudCodeJDefault
            // 
            this.picTabs.SetControlTabPages(this.cmbReqBudCodeJDefault, "Default Budget Code Part Demands");
            resources.ApplyResources(this.cmbReqBudCodeJDefault, "cmbReqBudCodeJDefault");
            this.cmbReqBudCodeJDefault.Name = "cmbReqBudCodeJDefault";
            this.cmbReqBudCodeJDefault.NamedProperties.Put("EnumerateMethod", "ACCOUNT_REQUEST_API.Enumerate");
            this.cmbReqBudCodeJDefault.NamedProperties.Put("FieldFlags", "295");
            this.cmbReqBudCodeJDefault.NamedProperties.Put("LovReference", "");
            this.cmbReqBudCodeJDefault.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbReqBudCodeJDefault.NamedProperties.Put("SqlColumn", "REQ_BUD_CODE_J_DEFAULT");
            this.cmbReqBudCodeJDefault.NamedProperties.Put("ValidateMethod", "");
            this.cmbReqBudCodeJDefault.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbReqBudCodeJDefault_WindowActions);
            // 
            // labelcmbReqBudQuantityDefault
            // 
            resources.ApplyResources(this.labelcmbReqBudQuantityDefault, "labelcmbReqBudQuantityDefault");
            this.labelcmbReqBudQuantityDefault.BackColor = System.Drawing.Color.Transparent;
            this.picTabs.SetControlTabPages(this.labelcmbReqBudQuantityDefault, "Default Budget Code Part Demands");
            this.labelcmbReqBudQuantityDefault.Name = "labelcmbReqBudQuantityDefault";
            // 
            // cmbReqBudQuantityDefault
            // 
            this.picTabs.SetControlTabPages(this.cmbReqBudQuantityDefault, "Default Budget Code Part Demands");
            resources.ApplyResources(this.cmbReqBudQuantityDefault, "cmbReqBudQuantityDefault");
            this.cmbReqBudQuantityDefault.Name = "cmbReqBudQuantityDefault";
            this.cmbReqBudQuantityDefault.NamedProperties.Put("EnumerateMethod", "ACCOUNT_REQUEST_API.Enumerate");
            this.cmbReqBudQuantityDefault.NamedProperties.Put("FieldFlags", "295");
            this.cmbReqBudQuantityDefault.NamedProperties.Put("LovReference", "");
            this.cmbReqBudQuantityDefault.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbReqBudQuantityDefault.NamedProperties.Put("SqlColumn", "REQ_BUD_QUANTITY_DEFAULT");
            this.cmbReqBudQuantityDefault.NamedProperties.Put("ValidateMethod", "");
            this.cmbReqBudQuantityDefault.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbReqBudQuantityDefault_WindowActions);
            // 
            // labelcmbTextDefault
            // 
            resources.ApplyResources(this.labelcmbTextDefault, "labelcmbTextDefault");
            this.labelcmbTextDefault.BackColor = System.Drawing.Color.Transparent;
            this.picTabs.SetControlTabPages(this.labelcmbTextDefault, "Default Code Part Demands");
            this.labelcmbTextDefault.Name = "labelcmbTextDefault";
            // 
            // cmbTextDefault
            // 
            this.picTabs.SetControlTabPages(this.cmbTextDefault, "Default Code Part Demands");
            resources.ApplyResources(this.cmbTextDefault, "cmbTextDefault");
            this.cmbTextDefault.Name = "cmbTextDefault";
            this.cmbTextDefault.NamedProperties.Put("EnumerateMethod", "ACCOUNT_REQUEST_TEXT_API.Enumerate");
            this.cmbTextDefault.NamedProperties.Put("FieldFlags", "295");
            this.cmbTextDefault.NamedProperties.Put("LovReference", "");
            this.cmbTextDefault.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbTextDefault.NamedProperties.Put("SqlColumn", "TEXT_DEFAULT");
            this.cmbTextDefault.NamedProperties.Put("ValidateMethod", "");
            this.cmbTextDefault.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbTextDefault_WindowActions);
            // 
            // dfAction
            // 
            resources.ApplyResources(this.dfAction, "dfAction");
            this.dfAction.Name = "dfAction";
            this.dfAction.NamedProperties.Put("EnumerateMethod", "");
            this.dfAction.NamedProperties.Put("FieldFlags", "262");
            this.dfAction.NamedProperties.Put("LovReference", "");
            this.dfAction.NamedProperties.Put("ResizeableChildObject", "");
            this.dfAction.NamedProperties.Put("SqlColumn", "ACTION");
            this.dfAction.NamedProperties.Put("ValidateMethod", "");
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
            // frmAccountType
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.dfAction);
            this.Controls.Add(this.cmbTextDefault);
            this.Controls.Add(this.cmbReqBudCodeBDefault);
            this.Controls.Add(this.cmbReqBudCodeCDefault);
            this.Controls.Add(this.cmbReqBudCodeDDefault);
            this.Controls.Add(this.cmbReqBudCodeEDefault);
            this.Controls.Add(this.cmbReqBudCodeFDefault);
            this.Controls.Add(this.cmbReqBudCodeGDefault);
            this.Controls.Add(this.cmbReqBudCodeHDefault);
            this.Controls.Add(this.cmbReqBudCodeIDefault);
            this.Controls.Add(this.cmbReqBudCodeJDefault);
            this.Controls.Add(this.cmbReqBudQuantityDefault);
            this.Controls.Add(this.cmbProcessCodeDefault);
            this.Controls.Add(this.cmbReqQuantityDefault);
            this.Controls.Add(this.cmbReqCodeJDefault);
            this.Controls.Add(this.cmbReqCodeIDefault);
            this.Controls.Add(this.cmbReqCodeHDefault);
            this.Controls.Add(this.cmbReqCodeGDefault);
            this.Controls.Add(this.cmbReqCodeFDefault);
            this.Controls.Add(this.cmbReqCodeEDefault);
            this.Controls.Add(this.cmbReqCodeDDefault);
            this.Controls.Add(this.cmbReqCodeCDefault);
            this.Controls.Add(this.cmbReqCodeBDefault);
            this.Controls.Add(this.cmbLogicalAccountType);
            this.Controls.Add(this.dfsDescription);
            this.Controls.Add(this.cmbAccntType);
            this.Controls.Add(this.dfsCompany);
            this.Controls.Add(this.labelcmbTextDefault);
            this.Controls.Add(this.labelcmbReqBudCodeBDefault);
            this.Controls.Add(this.labelcmbReqBudCodeCDefault);
            this.Controls.Add(this.labelcmbReqBudCodeDDefault);
            this.Controls.Add(this.labelcmbReqBudCodeEDefault);
            this.Controls.Add(this.labelcmbReqBudCodeFDefault);
            this.Controls.Add(this.labelcmbReqBudCodeGDefault);
            this.Controls.Add(this.labelcmbReqBudCodeHDefault);
            this.Controls.Add(this.labelcmbReqBudCodeIDefault);
            this.Controls.Add(this.labelcmbReqBudCodeJDefault);
            this.Controls.Add(this.labelcmbReqBudQuantityDefault);
            this.Controls.Add(this.labelcmbProcessCodeDefault);
            this.Controls.Add(this.labelcmbReqQuantityDefault);
            this.Controls.Add(this.labelcmbReqCodeJDefault);
            this.Controls.Add(this.labelcmbReqCodeIDefault);
            this.Controls.Add(this.labelcmbReqCodeHDefault);
            this.Controls.Add(this.labelcmbReqCodeGDefault);
            this.Controls.Add(this.labelcmbReqCodeFDefault);
            this.Controls.Add(this.labelcmbReqCodeEDefault);
            this.Controls.Add(this.labelcmbReqCodeDDefault);
            this.Controls.Add(this.labelcmbReqCodeCDefault);
            this.Controls.Add(this.labelcmbReqCodeBDefault);
            this.Controls.Add(this.labelcmbLogicalAccountType);
            this.Controls.Add(this.labeldfsDescription);
            this.Controls.Add(this.labelcmbAccntType);
            this.Controls.Add(this.labeldfsCompany);
            this.Name = "frmAccountType";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "COMPANY=:global.company");
            this.NamedProperties.Put("LogicalUnit", "AccountType");
            this.NamedProperties.Put("PackageName", "ACCOUNT_TYPE_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("ViewName", "ACCOUNT_TYPE");
            this.NamedProperties.Put("Warnings", "TRUE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.frmAccountType_WindowActions);
            this.Controls.SetChildIndex(this.picTabs, 0);
            this.Controls.SetChildIndex(this.labeldfsCompany, 0);
            this.Controls.SetChildIndex(this.labelcmbAccntType, 0);
            this.Controls.SetChildIndex(this.labeldfsDescription, 0);
            this.Controls.SetChildIndex(this.labelcmbLogicalAccountType, 0);
            this.Controls.SetChildIndex(this.labelcmbReqCodeBDefault, 0);
            this.Controls.SetChildIndex(this.labelcmbReqCodeCDefault, 0);
            this.Controls.SetChildIndex(this.labelcmbReqCodeDDefault, 0);
            this.Controls.SetChildIndex(this.labelcmbReqCodeEDefault, 0);
            this.Controls.SetChildIndex(this.labelcmbReqCodeFDefault, 0);
            this.Controls.SetChildIndex(this.labelcmbReqCodeGDefault, 0);
            this.Controls.SetChildIndex(this.labelcmbReqCodeHDefault, 0);
            this.Controls.SetChildIndex(this.labelcmbReqCodeIDefault, 0);
            this.Controls.SetChildIndex(this.labelcmbReqCodeJDefault, 0);
            this.Controls.SetChildIndex(this.labelcmbReqQuantityDefault, 0);
            this.Controls.SetChildIndex(this.labelcmbProcessCodeDefault, 0);
            this.Controls.SetChildIndex(this.labelcmbReqBudQuantityDefault, 0);
            this.Controls.SetChildIndex(this.labelcmbReqBudCodeJDefault, 0);
            this.Controls.SetChildIndex(this.labelcmbReqBudCodeIDefault, 0);
            this.Controls.SetChildIndex(this.labelcmbReqBudCodeHDefault, 0);
            this.Controls.SetChildIndex(this.labelcmbReqBudCodeGDefault, 0);
            this.Controls.SetChildIndex(this.labelcmbReqBudCodeFDefault, 0);
            this.Controls.SetChildIndex(this.labelcmbReqBudCodeEDefault, 0);
            this.Controls.SetChildIndex(this.labelcmbReqBudCodeDDefault, 0);
            this.Controls.SetChildIndex(this.labelcmbReqBudCodeCDefault, 0);
            this.Controls.SetChildIndex(this.labelcmbReqBudCodeBDefault, 0);
            this.Controls.SetChildIndex(this.labelcmbTextDefault, 0);
            this.Controls.SetChildIndex(this.dfsCompany, 0);
            this.Controls.SetChildIndex(this.cmbAccntType, 0);
            this.Controls.SetChildIndex(this.dfsDescription, 0);
            this.Controls.SetChildIndex(this.cmbLogicalAccountType, 0);
            this.Controls.SetChildIndex(this.cmbReqCodeBDefault, 0);
            this.Controls.SetChildIndex(this.cmbReqCodeCDefault, 0);
            this.Controls.SetChildIndex(this.cmbReqCodeDDefault, 0);
            this.Controls.SetChildIndex(this.cmbReqCodeEDefault, 0);
            this.Controls.SetChildIndex(this.cmbReqCodeFDefault, 0);
            this.Controls.SetChildIndex(this.cmbReqCodeGDefault, 0);
            this.Controls.SetChildIndex(this.cmbReqCodeHDefault, 0);
            this.Controls.SetChildIndex(this.cmbReqCodeIDefault, 0);
            this.Controls.SetChildIndex(this.cmbReqCodeJDefault, 0);
            this.Controls.SetChildIndex(this.cmbReqQuantityDefault, 0);
            this.Controls.SetChildIndex(this.cmbProcessCodeDefault, 0);
            this.Controls.SetChildIndex(this.cmbReqBudQuantityDefault, 0);
            this.Controls.SetChildIndex(this.cmbReqBudCodeJDefault, 0);
            this.Controls.SetChildIndex(this.cmbReqBudCodeIDefault, 0);
            this.Controls.SetChildIndex(this.cmbReqBudCodeHDefault, 0);
            this.Controls.SetChildIndex(this.cmbReqBudCodeGDefault, 0);
            this.Controls.SetChildIndex(this.cmbReqBudCodeFDefault, 0);
            this.Controls.SetChildIndex(this.cmbReqBudCodeEDefault, 0);
            this.Controls.SetChildIndex(this.cmbReqBudCodeDDefault, 0);
            this.Controls.SetChildIndex(this.cmbReqBudCodeCDefault, 0);
            this.Controls.SetChildIndex(this.cmbReqBudCodeBDefault, 0);
            this.Controls.SetChildIndex(this.cmbTextDefault, 0);
            this.Controls.SetChildIndex(this.dfAction, 0);
            this.menuFrmMethods.ResumeLayout(false);
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

        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menuChange__Company___;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuFrmMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change;
	}
}
