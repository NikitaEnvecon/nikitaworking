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
	
	public partial class tbwExternalFileTransactions
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cColumn colnLoadFileId;
		public cColumn coldLoadDate;
		public cColumn colsUserId;
		public cColumn colsFileType;
		public cColumn colsFileTemplateId;
		public cColumn colExtFileTemplateDescription;
		public cLookupColumn colsFileDirection;
		public cColumn colsSetId;
		public cColumn colsCompany;
		public cColumn colCompanyFinanceCompany_Name;
		public cColumn colsFileName;
		public cColumn colsState;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwExternalFileTransactions));
            this.menuTbwMethods_menu_Details___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_menu_External_File_Log___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.colnLoadFileId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.coldLoadDate = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsUserId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsFileType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsFileTemplateId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colExtFileTemplateDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsFileDirection = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.colsSetId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colCompanyFinanceCompany_Name = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsFileName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsState = new Ifs.Fnd.ApplicationForms.cColumn();
            this.menuTbwMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem__Details = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem__External = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuTbwMethods.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuTbwMethods_menu_Details___);
            this.commandManager.Commands.Add(this.menuTbwMethods_menu_External_File_Log___);
            this.commandManager.ContextMenus.Add(this.menuTbwMethods);
            // 
            // menuTbwMethods_menu_Details___
            // 
            resources.ApplyResources(this.menuTbwMethods_menu_Details___, "menuTbwMethods_menu_Details___");
            this.menuTbwMethods_menu_Details___.Name = "menuTbwMethods_menu_Details___";
            this.menuTbwMethods_menu_Details___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Details_Execute);
            this.menuTbwMethods_menu_Details___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Details_Inquire);
            // 
            // menuTbwMethods_menu_External_File_Log___
            // 
            resources.ApplyResources(this.menuTbwMethods_menu_External_File_Log___, "menuTbwMethods_menu_External_File_Log___");
            this.menuTbwMethods_menu_External_File_Log___.Name = "menuTbwMethods_menu_External_File_Log___";
            this.menuTbwMethods_menu_External_File_Log___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__External_Execute);
            this.menuTbwMethods_menu_External_File_Log___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__External_Inquire);
            // 
            // colnLoadFileId
            // 
            this.colnLoadFileId.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colnLoadFileId.Name = "colnLoadFileId";
            this.colnLoadFileId.NamedProperties.Put("EnumerateMethod", "");
            this.colnLoadFileId.NamedProperties.Put("FieldFlags", "163");
            this.colnLoadFileId.NamedProperties.Put("LovReference", "");
            this.colnLoadFileId.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colnLoadFileId.NamedProperties.Put("SqlColumn", "LOAD_FILE_ID");
            this.colnLoadFileId.Position = 3;
            resources.ApplyResources(this.colnLoadFileId, "colnLoadFileId");
            // 
            // coldLoadDate
            // 
            this.coldLoadDate.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.coldLoadDate.Format = "d";
            this.coldLoadDate.Name = "coldLoadDate";
            this.coldLoadDate.NamedProperties.Put("EnumerateMethod", "");
            this.coldLoadDate.NamedProperties.Put("FieldFlags", "295");
            this.coldLoadDate.NamedProperties.Put("LovReference", "");
            this.coldLoadDate.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.coldLoadDate.NamedProperties.Put("SqlColumn", "LOAD_DATE");
            this.coldLoadDate.Position = 4;
            resources.ApplyResources(this.coldLoadDate, "coldLoadDate");
            // 
            // colsUserId
            // 
            this.colsUserId.MaxLength = 30;
            this.colsUserId.Name = "colsUserId";
            this.colsUserId.NamedProperties.Put("EnumerateMethod", "");
            this.colsUserId.NamedProperties.Put("FieldFlags", "294");
            this.colsUserId.NamedProperties.Put("LovReference", "");
            this.colsUserId.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsUserId.NamedProperties.Put("SqlColumn", "USER_ID");
            this.colsUserId.Position = 5;
            resources.ApplyResources(this.colsUserId, "colsUserId");
            // 
            // colsFileType
            // 
            this.colsFileType.MaxLength = 30;
            this.colsFileType.Name = "colsFileType";
            this.colsFileType.NamedProperties.Put("EnumerateMethod", "");
            this.colsFileType.NamedProperties.Put("FieldFlags", "294");
            this.colsFileType.NamedProperties.Put("LovReference", "EXT_FILE_TYPE_USABLE");
            this.colsFileType.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsFileType.NamedProperties.Put("SqlColumn", "FILE_TYPE");
            this.colsFileType.Position = 6;
            resources.ApplyResources(this.colsFileType, "colsFileType");
            // 
            // colsFileTemplateId
            // 
            this.colsFileTemplateId.MaxLength = 30;
            this.colsFileTemplateId.Name = "colsFileTemplateId";
            this.colsFileTemplateId.NamedProperties.Put("EnumerateMethod", "");
            this.colsFileTemplateId.NamedProperties.Put("FieldFlags", "294");
            this.colsFileTemplateId.NamedProperties.Put("LovReference", "EXT_FILE_TEMPLATE");
            this.colsFileTemplateId.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsFileTemplateId.NamedProperties.Put("SqlColumn", "FILE_TEMPLATE_ID");
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
            this.colExtFileTemplateDescription.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colExtFileTemplateDescription.NamedProperties.Put("SqlColumn", "EXT_FILE_TEMPLATE_API.Get_Description(FILE_TEMPLATE_ID)");
            this.colExtFileTemplateDescription.NamedProperties.Put("ValidateMethod", "");
            this.colExtFileTemplateDescription.Position = 8;
            resources.ApplyResources(this.colExtFileTemplateDescription, "colExtFileTemplateDescription");
            // 
            // colsFileDirection
            // 
            this.colsFileDirection.MaxLength = 200;
            this.colsFileDirection.Name = "colsFileDirection";
            this.colsFileDirection.NamedProperties.Put("EnumerateMethod", "FILE_DIRECTION_API.Enumerate");
            this.colsFileDirection.NamedProperties.Put("FieldFlags", "295");
            this.colsFileDirection.NamedProperties.Put("LovReference", "");
            this.colsFileDirection.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsFileDirection.NamedProperties.Put("SqlColumn", "FILE_DIRECTION");
            this.colsFileDirection.Position = 9;
            resources.ApplyResources(this.colsFileDirection, "colsFileDirection");
            // 
            // colsSetId
            // 
            this.colsSetId.MaxLength = 20;
            this.colsSetId.Name = "colsSetId";
            this.colsSetId.NamedProperties.Put("EnumerateMethod", "");
            this.colsSetId.NamedProperties.Put("FieldFlags", "294");
            this.colsSetId.NamedProperties.Put("LovReference", "EXT_TYPE_PARAM_SET(FILE_TYPE)");
            this.colsSetId.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsSetId.NamedProperties.Put("SqlColumn", "SET_ID");
            this.colsSetId.Position = 10;
            resources.ApplyResources(this.colsSetId, "colsSetId");
            // 
            // colsCompany
            // 
            this.colsCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsCompany.MaxLength = 20;
            this.colsCompany.Name = "colsCompany";
            this.colsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.colsCompany.NamedProperties.Put("FieldFlags", "294");
            this.colsCompany.NamedProperties.Put("LovReference", "COMPANY_FINANCE");
            this.colsCompany.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.colsCompany.Position = 11;
            resources.ApplyResources(this.colsCompany, "colsCompany");
            // 
            // colCompanyFinanceCompany_Name
            // 
            this.colCompanyFinanceCompany_Name.MaxLength = 2000;
            this.colCompanyFinanceCompany_Name.Name = "colCompanyFinanceCompany_Name";
            this.colCompanyFinanceCompany_Name.NamedProperties.Put("EnumerateMethod", "");
            this.colCompanyFinanceCompany_Name.NamedProperties.Put("FieldFlags", "272");
            this.colCompanyFinanceCompany_Name.NamedProperties.Put("LovReference", "");
            this.colCompanyFinanceCompany_Name.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colCompanyFinanceCompany_Name.NamedProperties.Put("SqlColumn", "COMPANY_FINANCE_API.Get_Company_Name(COMPANY)");
            this.colCompanyFinanceCompany_Name.NamedProperties.Put("ValidateMethod", "");
            this.colCompanyFinanceCompany_Name.Position = 12;
            resources.ApplyResources(this.colCompanyFinanceCompany_Name, "colCompanyFinanceCompany_Name");
            // 
            // colsFileName
            // 
            this.colsFileName.MaxLength = 200;
            this.colsFileName.Name = "colsFileName";
            this.colsFileName.NamedProperties.Put("EnumerateMethod", "");
            this.colsFileName.NamedProperties.Put("FieldFlags", "294");
            this.colsFileName.NamedProperties.Put("LovReference", "");
            this.colsFileName.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsFileName.NamedProperties.Put("ResizeableChildObject", "");
            this.colsFileName.NamedProperties.Put("SqlColumn", "FILE_NAME");
            this.colsFileName.NamedProperties.Put("ValidateMethod", "");
            this.colsFileName.Position = 13;
            resources.ApplyResources(this.colsFileName, "colsFileName");
            // 
            // colsState
            // 
            this.colsState.MaxLength = 200;
            this.colsState.Name = "colsState";
            this.colsState.NamedProperties.Put("EnumerateMethod", "");
            this.colsState.NamedProperties.Put("FieldFlags", "294");
            this.colsState.NamedProperties.Put("LovReference", "");
            this.colsState.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsState.NamedProperties.Put("SqlColumn", "STATE");
            this.colsState.Position = 14;
            resources.ApplyResources(this.colsState, "colsState");
            // 
            // menuTbwMethods
            // 
            this.menuTbwMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem__Details,
            this.menuItem__External});
            this.menuTbwMethods.Name = "menuTbwMethods";
            resources.ApplyResources(this.menuTbwMethods, "menuTbwMethods");
            // 
            // menuItem__Details
            // 
            this.menuItem__Details.Command = this.menuTbwMethods_menu_Details___;
            this.menuItem__Details.Name = "menuItem__Details";
            resources.ApplyResources(this.menuItem__Details, "menuItem__Details");
            this.menuItem__Details.Text = "&Details...";
            // 
            // menuItem__External
            // 
            this.menuItem__External.Command = this.menuTbwMethods_menu_External_File_Log___;
            this.menuItem__External.Name = "menuItem__External";
            resources.ApplyResources(this.menuItem__External, "menuItem__External");
            this.menuItem__External.Text = "&External File Log...";
            // 
            // tbwExternalFileTransactions
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colnLoadFileId);
            this.Controls.Add(this.coldLoadDate);
            this.Controls.Add(this.colsUserId);
            this.Controls.Add(this.colsFileType);
            this.Controls.Add(this.colsFileTemplateId);
            this.Controls.Add(this.colExtFileTemplateDescription);
            this.Controls.Add(this.colsFileDirection);
            this.Controls.Add(this.colsSetId);
            this.Controls.Add(this.colsCompany);
            this.Controls.Add(this.colCompanyFinanceCompany_Name);
            this.Controls.Add(this.colsFileName);
            this.Controls.Add(this.colsState);
            this.Name = "tbwExternalFileTransactions";
            this.NamedProperties.Put("DefaultOrderBy", "LOAD_FILE_ID DESC");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "ExtFileLoad");
            this.NamedProperties.Put("PackageName", "EXT_FILE_LOAD_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "257");
            this.NamedProperties.Put("ViewName", "EXT_FILE_LOAD");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tbwExternalFileTransactions_WindowActions);
            this.Controls.SetChildIndex(this.colsState, 0);
            this.Controls.SetChildIndex(this.colsFileName, 0);
            this.Controls.SetChildIndex(this.colCompanyFinanceCompany_Name, 0);
            this.Controls.SetChildIndex(this.colsCompany, 0);
            this.Controls.SetChildIndex(this.colsSetId, 0);
            this.Controls.SetChildIndex(this.colsFileDirection, 0);
            this.Controls.SetChildIndex(this.colExtFileTemplateDescription, 0);
            this.Controls.SetChildIndex(this.colsFileTemplateId, 0);
            this.Controls.SetChildIndex(this.colsFileType, 0);
            this.Controls.SetChildIndex(this.colsUserId, 0);
            this.Controls.SetChildIndex(this.coldLoadDate, 0);
            this.Controls.SetChildIndex(this.colnLoadFileId, 0);
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

        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menu_Details___;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menu_External_File_Log___;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTbwMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Details;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__External;
	}
}
