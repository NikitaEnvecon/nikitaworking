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
	
	public partial class tbwCdCompl
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cColumn colCompany;
		public cColumn colCodePart;
		public cColumn colCodePartValue;
		public cColumn colCodePartValueDesc;
		public cColumn colCodePartName;
		public cColumn colCodeFillCodePart;
		public cColumn colCodeFillCodePartName;
		public cColumn colCodefillValue;
		public cColumn colCodefillValueName;
		public cColumn colCdPartBlocked;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwCdCompl));
            this.menuTbwMethods_menu_Change_Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.colCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colCodePart = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colCodePartValue = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colCodePartValueDesc = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colCodePartName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colCodeFillCodePart = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colCodeFillCodePartName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colCodefillValue = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colCodefillValueName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colCdPartBlocked = new Ifs.Fnd.ApplicationForms.cColumn();
            this.menuTbwMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem__Change = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuTbwMethods.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuTbwMethods_menu_Change_Company___);
            this.commandManager.ContextMenus.Add(this.menuTbwMethods);
            // 
            // menuTbwMethods_menu_Change_Company___
            // 
            resources.ApplyResources(this.menuTbwMethods_menu_Change_Company___, "menuTbwMethods_menu_Change_Company___");
            this.menuTbwMethods_menu_Change_Company___.Name = "menuTbwMethods_menu_Change_Company___";
            this.menuTbwMethods_menu_Change_Company___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Change_Execute);
            this.menuTbwMethods_menu_Change_Company___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Change_Inquire);
            // 
            // colCompany
            // 
            resources.ApplyResources(this.colCompany, "colCompany");
            this.colCompany.MaxLength = 20;
            this.colCompany.Name = "colCompany";
            this.colCompany.NamedProperties.Put("EnumerateMethod", "");
            this.colCompany.NamedProperties.Put("FieldFlags", "67");
            this.colCompany.NamedProperties.Put("LovReference", "");
            this.colCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.colCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.colCompany.NamedProperties.Put("ValidateMethod", "");
            this.colCompany.Position = 3;
            // 
            // colCodePart
            // 
            resources.ApplyResources(this.colCodePart, "colCodePart");
            this.colCodePart.MaxLength = 1;
            this.colCodePart.Name = "colCodePart";
            this.colCodePart.NamedProperties.Put("EnumerateMethod", "");
            this.colCodePart.NamedProperties.Put("FieldFlags", "131");
            this.colCodePart.NamedProperties.Put("LovReference", "");
            this.colCodePart.NamedProperties.Put("SqlColumn", "CODE_PART");
            this.colCodePart.Position = 4;
            // 
            // colCodePartValue
            // 
            this.colCodePartValue.MaxLength = 20;
            this.colCodePartValue.Name = "colCodePartValue";
            this.colCodePartValue.NamedProperties.Put("EnumerateMethod", "");
            this.colCodePartValue.NamedProperties.Put("FieldFlags", "163");
            this.colCodePartValue.NamedProperties.Put("LovReference", "ACCOUNTING_CODE_PART_VALUE_LOV(COMPANY,CODE_PART)");
            this.colCodePartValue.NamedProperties.Put("ResizeableChildObject", "");
            this.colCodePartValue.NamedProperties.Put("SqlColumn", "CODE_PART_VALUE");
            this.colCodePartValue.NamedProperties.Put("ValidateMethod", "");
            this.colCodePartValue.Position = 5;
            resources.ApplyResources(this.colCodePartValue, "colCodePartValue");
            // 
            // colCodePartValueDesc
            // 
            this.colCodePartValueDesc.Name = "colCodePartValueDesc";
            this.colCodePartValueDesc.NamedProperties.Put("EnumerateMethod", "");
            this.colCodePartValueDesc.NamedProperties.Put("FieldFlags", "288");
            this.colCodePartValueDesc.NamedProperties.Put("LovReference", "");
            this.colCodePartValueDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.colCodePartValueDesc.NamedProperties.Put("SqlColumn", "ACCOUNTING_CODE_PART_VALUE_API.Get_Desc_For_Code_Part(company,code_part,CODE_PART" +
                    "_VALUE)");
            this.colCodePartValueDesc.NamedProperties.Put("ValidateMethod", "");
            this.colCodePartValueDesc.Position = 6;
            resources.ApplyResources(this.colCodePartValueDesc, "colCodePartValueDesc");
            // 
            // colCodePartName
            // 
            this.colCodePartName.MaxLength = 10;
            this.colCodePartName.Name = "colCodePartName";
            this.colCodePartName.NamedProperties.Put("EnumerateMethod", "");
            this.colCodePartName.NamedProperties.Put("FieldFlags", "290");
            this.colCodePartName.NamedProperties.Put("LovReference", "ACCOUNTING_CODE_PARTS_USED2(COMPANY)");
            this.colCodePartName.NamedProperties.Put("ResizeableChildObject", "");
            this.colCodePartName.NamedProperties.Put("SqlColumn", "Enterp_Comp_Connect_V170_API.Get_Company_Translation(COMPANY, \'ACCRUL\', \'Accounti" +
                    "ngCodeParts\', CODE_PART)");
            this.colCodePartName.NamedProperties.Put("ValidateMethod", "");
            this.colCodePartName.Position = 7;
            resources.ApplyResources(this.colCodePartName, "colCodePartName");
            // 
            // colCodeFillCodePart
            // 
            resources.ApplyResources(this.colCodeFillCodePart, "colCodeFillCodePart");
            this.colCodeFillCodePart.MaxLength = 1;
            this.colCodeFillCodePart.Name = "colCodeFillCodePart";
            this.colCodeFillCodePart.NamedProperties.Put("EnumerateMethod", "");
            this.colCodeFillCodePart.NamedProperties.Put("FieldFlags", "131");
            this.colCodeFillCodePart.NamedProperties.Put("LovReference", "");
            this.colCodeFillCodePart.NamedProperties.Put("SqlColumn", "CODEFILL_CODE_PART");
            this.colCodeFillCodePart.Position = 8;
            // 
            // colCodeFillCodePartName
            // 
            this.colCodeFillCodePartName.Name = "colCodeFillCodePartName";
            this.colCodeFillCodePartName.NamedProperties.Put("EnumerateMethod", "");
            this.colCodeFillCodePartName.NamedProperties.Put("FieldFlags", "290");
            this.colCodeFillCodePartName.NamedProperties.Put("LovReference", "");
            this.colCodeFillCodePartName.NamedProperties.Put("ResizeableChildObject", "");
            this.colCodeFillCodePartName.NamedProperties.Put("SqlColumn", "Accounting_Codestr_Compl_API.Get_Translated_Code_Fill_Name(COMPANY, \'ACCRUL\', \'Ac" +
                    "countingCodeParts\', CODEFILL_CODE_PART)");
            this.colCodeFillCodePartName.NamedProperties.Put("ValidateMethod", "");
            this.colCodeFillCodePartName.Position = 9;
            resources.ApplyResources(this.colCodeFillCodePartName, "colCodeFillCodePartName");
            // 
            // colCodefillValue
            // 
            this.colCodefillValue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colCodefillValue.MaxLength = 20;
            this.colCodefillValue.Name = "colCodefillValue";
            this.colCodefillValue.NamedProperties.Put("EnumerateMethod", "");
            this.colCodefillValue.NamedProperties.Put("FieldFlags", "294");
            this.colCodefillValue.NamedProperties.Put("LovReference", "");
            this.colCodefillValue.NamedProperties.Put("ResizeableChildObject", "");
            this.colCodefillValue.NamedProperties.Put("SqlColumn", "CODEFILL_VALUE");
            this.colCodefillValue.NamedProperties.Put("ValidateMethod", "");
            this.colCodefillValue.Position = 10;
            resources.ApplyResources(this.colCodefillValue, "colCodefillValue");
            this.colCodefillValue.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colCodefillValue_WindowActions);
            // 
            // colCodefillValueName
            // 
            this.colCodefillValueName.Name = "colCodefillValueName";
            this.colCodefillValueName.NamedProperties.Put("EnumerateMethod", "");
            this.colCodefillValueName.NamedProperties.Put("FieldFlags", "290");
            this.colCodefillValueName.NamedProperties.Put("LovReference", "");
            this.colCodefillValueName.NamedProperties.Put("ResizeableChildObject", "");
            this.colCodefillValueName.NamedProperties.Put("SqlColumn", "CODEFILL_VALUE_NAME");
            this.colCodefillValueName.NamedProperties.Put("ValidateMethod", "");
            this.colCodefillValueName.Position = 11;
            resources.ApplyResources(this.colCodefillValueName, "colCodefillValueName");
            // 
            // colCdPartBlocked
            // 
            resources.ApplyResources(this.colCdPartBlocked, "colCdPartBlocked");
            this.colCdPartBlocked.MaxLength = 5;
            this.colCdPartBlocked.Name = "colCdPartBlocked";
            this.colCdPartBlocked.NamedProperties.Put("EnumerateMethod", "");
            this.colCdPartBlocked.NamedProperties.Put("LovReference", "");
            this.colCdPartBlocked.NamedProperties.Put("SqlColumn", "");
            this.colCdPartBlocked.NamedProperties.Put("ValidateMethod", "");
            this.colCdPartBlocked.Position = 12;
            // 
            // menuTbwMethods
            // 
            this.menuTbwMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem__Change});
            this.menuTbwMethods.Name = "menuTbwMethods";
            resources.ApplyResources(this.menuTbwMethods, "menuTbwMethods");
            // 
            // menuItem__Change
            // 
            this.menuItem__Change.Command = this.menuTbwMethods_menu_Change_Company___;
            this.menuItem__Change.Name = "menuItem__Change";
            resources.ApplyResources(this.menuItem__Change, "menuItem__Change");
            this.menuItem__Change.Text = "&Change Company...";
            // 
            // tbwCdCompl
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colCompany);
            this.Controls.Add(this.colCodePart);
            this.Controls.Add(this.colCodePartValue);
            this.Controls.Add(this.colCodePartValueDesc);
            this.Controls.Add(this.colCodePartName);
            this.Controls.Add(this.colCodeFillCodePart);
            this.Controls.Add(this.colCodeFillCodePartName);
            this.Controls.Add(this.colCodefillValue);
            this.Controls.Add(this.colCodefillValueName);
            this.Controls.Add(this.colCdPartBlocked);
            this.Name = "tbwCdCompl";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "COMPANY = :global.company");
            this.NamedProperties.Put("LogicalUnit", "AccountingCodestrCompl");
            this.NamedProperties.Put("PackageName", "ACCOUNTING_CODESTR_COMPL_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "0");
            this.NamedProperties.Put("SourceFlags", "129");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.NamedProperties.Put("ViewName", "ACCOUNTING_CODESTR_COMPL");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tbwCdCompl_WindowActions);
            this.Controls.SetChildIndex(this.colCdPartBlocked, 0);
            this.Controls.SetChildIndex(this.colCodefillValueName, 0);
            this.Controls.SetChildIndex(this.colCodefillValue, 0);
            this.Controls.SetChildIndex(this.colCodeFillCodePartName, 0);
            this.Controls.SetChildIndex(this.colCodeFillCodePart, 0);
            this.Controls.SetChildIndex(this.colCodePartName, 0);
            this.Controls.SetChildIndex(this.colCodePartValueDesc, 0);
            this.Controls.SetChildIndex(this.colCodePartValue, 0);
            this.Controls.SetChildIndex(this.colCodePart, 0);
            this.Controls.SetChildIndex(this.colCompany, 0);
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

        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menu_Change_Company___;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTbwMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Change;
	}
}
