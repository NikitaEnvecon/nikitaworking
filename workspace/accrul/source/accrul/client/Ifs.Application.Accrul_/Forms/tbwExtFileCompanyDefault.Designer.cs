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

namespace Ifs.Application.Accrul_
{
	
	public partial class tbwExtFileCompanyDefault
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cColumn colCompany;
		public cColumn colsFileType;
		public cColumn colExtFileTypeDescription;
		// Bug 92155 Begin Change the F1 property to Uppercase
		public cColumn colsUserId;
		// Bug 92155 End
		public cColumn colsFileTemplateId;
		public cColumn colExtFileTemplateDescription;
		public cColumn colsSetId;
		// Bug 92155 Begin Change Logical parent to others in  F1 property
		public cColumn colExtTypeParamSetDescription;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwExtFileCompanyDefault));
            this.menuTbwMethods_menuChange__Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuOperations_menuChange__Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.colCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsFileType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colExtFileTypeDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsUserId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsFileTemplateId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colExtFileTemplateDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsSetId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colExtTypeParamSetDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.menuOperations = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_Change = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuTbwMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_Change_1 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuOperations.SuspendLayout();
            this.menuTbwMethods.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuOperations_menuChange__Company___);
            this.commandManager.Commands.Add(this.menuTbwMethods_menuChange__Company___);
            this.commandManager.ContextMenus.Add(this.menuOperations);
            this.commandManager.ContextMenus.Add(this.menuTbwMethods);
            // 
            // menuTbwMethods_menuChange__Company___
            // 
            resources.ApplyResources(this.menuTbwMethods_menuChange__Company___, "menuTbwMethods_menuChange__Company___");
            this.menuTbwMethods_menuChange__Company___.Name = "menuTbwMethods_menuChange__Company___";
            this.menuTbwMethods_menuChange__Company___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Change_1_Execute);
            this.menuTbwMethods_menuChange__Company___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Change_1_Inquire);
            // 
            // menuOperations_menuChange__Company___
            // 
            resources.ApplyResources(this.menuOperations_menuChange__Company___, "menuOperations_menuChange__Company___");
            this.menuOperations_menuChange__Company___.Name = "menuOperations_menuChange__Company___";
            this.menuOperations_menuChange__Company___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Change_Execute);
            this.menuOperations_menuChange__Company___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Change_Inquire);
            // 
            // colCompany
            // 
            this.colCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.colCompany, "colCompany");
            this.colCompany.MaxLength = 20;
            this.colCompany.Name = "colCompany";
            this.colCompany.NamedProperties.Put("EnumerateMethod", "");
            this.colCompany.NamedProperties.Put("FieldFlags", "67");
            this.colCompany.NamedProperties.Put("LovReference", "COMPANY_FINANCE");
            this.colCompany.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.colCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.colCompany.NamedProperties.Put("ValidateMethod", "");
            this.colCompany.Position = 3;
            // 
            // colsFileType
            // 
            this.colsFileType.MaxLength = 30;
            this.colsFileType.Name = "colsFileType";
            this.colsFileType.NamedProperties.Put("EnumerateMethod", "");
            this.colsFileType.NamedProperties.Put("FieldFlags", "163");
            this.colsFileType.NamedProperties.Put("LovReference", "EXT_FILE_TYPE");
            this.colsFileType.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsFileType.NamedProperties.Put("ResizeableChildObject", "");
            this.colsFileType.NamedProperties.Put("SqlColumn", "FILE_TYPE");
            this.colsFileType.NamedProperties.Put("ValidateMethod", "");
            this.colsFileType.Position = 4;
            resources.ApplyResources(this.colsFileType, "colsFileType");
            // 
            // colExtFileTypeDescription
            // 
            this.colExtFileTypeDescription.MaxLength = 2000;
            this.colExtFileTypeDescription.Name = "colExtFileTypeDescription";
            this.colExtFileTypeDescription.NamedProperties.Put("EnumerateMethod", "");
            this.colExtFileTypeDescription.NamedProperties.Put("FieldFlags", "272");
            this.colExtFileTypeDescription.NamedProperties.Put("LovReference", "");
            this.colExtFileTypeDescription.NamedProperties.Put("ParentName", "colsFileType");
            this.colExtFileTypeDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.colExtFileTypeDescription.NamedProperties.Put("SqlColumn", "EXT_FILE_TYPE_API.Get_Description(FILE_TYPE)");
            this.colExtFileTypeDescription.NamedProperties.Put("ValidateMethod", "");
            this.colExtFileTypeDescription.Position = 5;
            resources.ApplyResources(this.colExtFileTypeDescription, "colExtFileTypeDescription");
            // 
            // colsUserId
            // 
            this.colsUserId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsUserId.MaxLength = 30;
            this.colsUserId.Name = "colsUserId";
            this.colsUserId.NamedProperties.Put("EnumerateMethod", "");
            this.colsUserId.NamedProperties.Put("FieldFlags", "295");
            this.colsUserId.NamedProperties.Put("LovReference", "USER_FINANCE(COMPANY)");
            this.colsUserId.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsUserId.NamedProperties.Put("ResizeableChildObject", "");
            this.colsUserId.NamedProperties.Put("SqlColumn", "USER_ID");
            this.colsUserId.NamedProperties.Put("ValidateMethod", "");
            this.colsUserId.Position = 6;
            resources.ApplyResources(this.colsUserId, "colsUserId");
            // 
            // colsFileTemplateId
            // 
            this.colsFileTemplateId.MaxLength = 30;
            this.colsFileTemplateId.Name = "colsFileTemplateId";
            this.colsFileTemplateId.NamedProperties.Put("EnumerateMethod", "");
            this.colsFileTemplateId.NamedProperties.Put("FieldFlags", "295");
            this.colsFileTemplateId.NamedProperties.Put("LovReference", "EXT_FILE_TEMPLATE_LOV2(FILE_TYPE)");
            this.colsFileTemplateId.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsFileTemplateId.NamedProperties.Put("ResizeableChildObject", "");
            this.colsFileTemplateId.NamedProperties.Put("SqlColumn", "FILE_TEMPLATE_ID");
            this.colsFileTemplateId.NamedProperties.Put("ValidateMethod", "");
            this.colsFileTemplateId.Position = 7;
            resources.ApplyResources(this.colsFileTemplateId, "colsFileTemplateId");
            // 
            // colExtFileTemplateDescription
            // 
            this.colExtFileTemplateDescription.MaxLength = 2000;
            this.colExtFileTemplateDescription.Name = "colExtFileTemplateDescription";
            this.colExtFileTemplateDescription.NamedProperties.Put("EnumerateMethod", "");
            this.colExtFileTemplateDescription.NamedProperties.Put("FieldFlags", "272");
            this.colExtFileTemplateDescription.NamedProperties.Put("LovReference", "");
            this.colExtFileTemplateDescription.NamedProperties.Put("ParentName", "colsFileTemplateId");
            this.colExtFileTemplateDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.colExtFileTemplateDescription.NamedProperties.Put("SqlColumn", "EXT_FILE_TEMPLATE_API.Get_Description(FILE_TEMPLATE_ID)");
            this.colExtFileTemplateDescription.NamedProperties.Put("ValidateMethod", "");
            this.colExtFileTemplateDescription.Position = 8;
            resources.ApplyResources(this.colExtFileTemplateDescription, "colExtFileTemplateDescription");
            // 
            // colsSetId
            // 
            this.colsSetId.MaxLength = 30;
            this.colsSetId.Name = "colsSetId";
            this.colsSetId.NamedProperties.Put("EnumerateMethod", "");
            this.colsSetId.NamedProperties.Put("FieldFlags", "294");
            this.colsSetId.NamedProperties.Put("LovReference", "EXT_TYPE_PARAM_SET(FILE_TYPE)");
            this.colsSetId.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsSetId.NamedProperties.Put("SqlColumn", "SET_ID");
            this.colsSetId.Position = 9;
            resources.ApplyResources(this.colsSetId, "colsSetId");
            // 
            // colExtTypeParamSetDescription
            // 
            this.colExtTypeParamSetDescription.MaxLength = 2000;
            this.colExtTypeParamSetDescription.Name = "colExtTypeParamSetDescription";
            this.colExtTypeParamSetDescription.NamedProperties.Put("EnumerateMethod", "");
            this.colExtTypeParamSetDescription.NamedProperties.Put("FieldFlags", "304");
            this.colExtTypeParamSetDescription.NamedProperties.Put("LovReference", "");
            this.colExtTypeParamSetDescription.NamedProperties.Put("ParentName", "colsSetId");
            this.colExtTypeParamSetDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.colExtTypeParamSetDescription.NamedProperties.Put("SqlColumn", "EXT_TYPE_PARAM_SET_API.Get_Description(FILE_TYPE,SET_ID)");
            this.colExtTypeParamSetDescription.NamedProperties.Put("ValidateMethod", "");
            this.colExtTypeParamSetDescription.Position = 10;
            resources.ApplyResources(this.colExtTypeParamSetDescription, "colExtTypeParamSetDescription");
            // 
            // menuOperations
            // 
            this.menuOperations.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_Change});
            this.menuOperations.Name = "menuOperations";
            resources.ApplyResources(this.menuOperations, "menuOperations");
            // 
            // menuItem_Change
            // 
            this.menuItem_Change.Command = this.menuOperations_menuChange__Company___;
            this.menuItem_Change.Name = "menuItem_Change";
            resources.ApplyResources(this.menuItem_Change, "menuItem_Change");
            this.menuItem_Change.Text = "Change &Company...";
            // 
            // menuTbwMethods
            // 
            this.menuTbwMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_Change_1});
            this.menuTbwMethods.Name = "menuTbwMethods";
            resources.ApplyResources(this.menuTbwMethods, "menuTbwMethods");
            // 
            // menuItem_Change_1
            // 
            this.menuItem_Change_1.Command = this.menuTbwMethods_menuChange__Company___;
            this.menuItem_Change_1.Name = "menuItem_Change_1";
            resources.ApplyResources(this.menuItem_Change_1, "menuItem_Change_1");
            this.menuItem_Change_1.Text = "Change &Company...";
            // 
            // tbwExtFileCompanyDefault
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colCompany);
            this.Controls.Add(this.colsFileType);
            this.Controls.Add(this.colExtFileTypeDescription);
            this.Controls.Add(this.colsUserId);
            this.Controls.Add(this.colsFileTemplateId);
            this.Controls.Add(this.colExtFileTemplateDescription);
            this.Controls.Add(this.colsSetId);
            this.Controls.Add(this.colExtTypeParamSetDescription);
            this.Name = "tbwExtFileCompanyDefault";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "COMPANY= :global.company");
            this.NamedProperties.Put("LogicalUnit", "ExtFileCompanyDefault");
            this.NamedProperties.Put("PackageName", "EXT_FILE_COMPANY_DEFAULT_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "449");
            this.NamedProperties.Put("ViewName", "EXT_FILE_COMPANY_DEFAULT");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.Controls.SetChildIndex(this.colExtTypeParamSetDescription, 0);
            this.Controls.SetChildIndex(this.colsSetId, 0);
            this.Controls.SetChildIndex(this.colExtFileTemplateDescription, 0);
            this.Controls.SetChildIndex(this.colsFileTemplateId, 0);
            this.Controls.SetChildIndex(this.colsUserId, 0);
            this.Controls.SetChildIndex(this.colExtFileTypeDescription, 0);
            this.Controls.SetChildIndex(this.colsFileType, 0);
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

        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menuChange__Company___;
        public Fnd.Windows.Forms.FndCommand menuOperations_menuChange__Company___;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuOperations;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTbwMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change_1;
	}
}
