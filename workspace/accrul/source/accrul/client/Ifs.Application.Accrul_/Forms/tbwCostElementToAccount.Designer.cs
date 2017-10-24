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
	
	public partial class tbwCostElementToAccount
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cColumn colsCompany;
		// MAKRLK, Twin Peaks,Changes for Project Cost Element Setup ,Start
		public cColumn colsCodePart;
		// MAKRLK, Twin Peaks,Changes for Project Cost Element Setup ,End
		public cColumnFin colsAccount;
		public cColumnFin colsAccountDescription;
		public cColumnFin colsProjectCostElement;
		public cColumnFin colsProjectCostElementDesc;
		// MAKRLK, Twin Peaks,Changes for Project Cost Element Setup ,Start
		public cColumn coldValidFrom;
		// MAKRLK, Twin Peaks,Changes for Project Cost Element Setup ,End
		// MAKRLK, Twin Peaks,Project Follow-Up Elements for Revenue , Start
		public cColumnFin colsElementType;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwCostElementToAccount));
            this.menuTbwMethods_menuChange__Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.colsCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsCodePart = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsAccount = new Ifs.Application.Accrul.cColumnFin();
            this.colsAccountDescription = new Ifs.Application.Accrul.cColumnFin();
            this.colsProjectCostElement = new Ifs.Application.Accrul.cColumnFin();
            this.colsProjectCostElementDesc = new Ifs.Application.Accrul.cColumnFin();
            this.coldValidFrom = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsElementType = new Ifs.Application.Accrul.cColumnFin();
            this.menuTbwMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_Change = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem_Secondary = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuTbwMethods_menuSecondary__Cost___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuTbwMethods_menuChange__Company___);
            this.commandManager.Commands.Add(this.menuTbwMethods_menuSecondary__Cost___);
            this.commandManager.ContextMenus.Add(this.menuTbwMethods);
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
            this.colsCompany.MaxLength = 80;
            this.colsCompany.Name = "colsCompany";
            this.colsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.colsCompany.NamedProperties.Put("FieldFlags", "259");
            this.colsCompany.NamedProperties.Put("LovReference", "");
            this.colsCompany.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.colsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.colsCompany.NamedProperties.Put("ValidateMethod", "");
            this.colsCompany.Position = 3;
            // 
            // colsCodePart
            // 
            this.colsCodePart.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.colsCodePart, "colsCodePart");
            this.colsCodePart.Name = "colsCodePart";
            this.colsCodePart.NamedProperties.Put("EnumerateMethod", "");
            this.colsCodePart.NamedProperties.Put("FieldFlags", "258");
            this.colsCodePart.NamedProperties.Put("LovReference", "");
            this.colsCodePart.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsCodePart.NamedProperties.Put("ResizeableChildObject", "");
            this.colsCodePart.NamedProperties.Put("SqlColumn", "CODE_PART");
            this.colsCodePart.NamedProperties.Put("ValidateMethod", "");
            this.colsCodePart.Position = 4;
            // 
            // colsAccount
            // 
            this.colsAccount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsAccount.MaxLength = 20;
            this.colsAccount.Name = "colsAccount";
            this.colsAccount.NamedProperties.Put("EnumerateMethod", "");
            this.colsAccount.NamedProperties.Put("FieldFlags", "291");
            this.colsAccount.NamedProperties.Put("LovReference", "ACCOUNTING_CODE_PART_VALUE_LOV(COMPANY,CODE_PART)");
            this.colsAccount.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsAccount.NamedProperties.Put("ResizeableChildObject", "");
            this.colsAccount.NamedProperties.Put("SqlColumn", "ACCOUNT");
            this.colsAccount.NamedProperties.Put("ValidateMethod", "");
            this.colsAccount.Position = 5;
            resources.ApplyResources(this.colsAccount, "colsAccount");
            this.colsAccount.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsAccount_WindowActions);
            // 
            // colsAccountDescription
            // 
            this.colsAccountDescription.Name = "colsAccountDescription";
            this.colsAccountDescription.NamedProperties.Put("EnumerateMethod", "");
            this.colsAccountDescription.NamedProperties.Put("FieldFlags", "288");
            this.colsAccountDescription.NamedProperties.Put("LovReference", "");
            this.colsAccountDescription.NamedProperties.Put("ParentName", "colsAccount");
            this.colsAccountDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.colsAccountDescription.NamedProperties.Put("SqlColumn", "Accounting_Code_Part_Value_API.Get_Desc_For_Code_Part(COMPANY, CODE_PART, ACCOUNT" +
                    ")");
            this.colsAccountDescription.NamedProperties.Put("ValidateMethod", "");
            this.colsAccountDescription.Position = 6;
            resources.ApplyResources(this.colsAccountDescription, "colsAccountDescription");
            // 
            // colsProjectCostElement
            // 
            this.colsProjectCostElement.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsProjectCostElement.Name = "colsProjectCostElement";
            this.colsProjectCostElement.NamedProperties.Put("EnumerateMethod", "");
            this.colsProjectCostElement.NamedProperties.Put("FieldFlags", "294");
            this.colsProjectCostElement.NamedProperties.Put("LovReference", "PROJECT_COST_ELEMENT_LOV(COMPANY)");
            this.colsProjectCostElement.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsProjectCostElement.NamedProperties.Put("ResizeableChildObject", "");
            this.colsProjectCostElement.NamedProperties.Put("SqlColumn", "PROJECT_COST_ELEMENT");
            this.colsProjectCostElement.NamedProperties.Put("ValidateMethod", "");
            this.colsProjectCostElement.Position = 7;
            resources.ApplyResources(this.colsProjectCostElement, "colsProjectCostElement");
            this.colsProjectCostElement.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsProjectCostElement_WindowActions);
            // 
            // colsProjectCostElementDesc
            // 
            this.colsProjectCostElementDesc.Name = "colsProjectCostElementDesc";
            this.colsProjectCostElementDesc.NamedProperties.Put("EnumerateMethod", "");
            this.colsProjectCostElementDesc.NamedProperties.Put("FieldFlags", "288");
            this.colsProjectCostElementDesc.NamedProperties.Put("LovReference", "");
            this.colsProjectCostElementDesc.NamedProperties.Put("ParentName", "colsProjectCostElement");
            this.colsProjectCostElementDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.colsProjectCostElementDesc.NamedProperties.Put("SqlColumn", "Project_Cost_Element_API.Get_Description(COMPANY, PROJECT_COST_ELEMENT)");
            this.colsProjectCostElementDesc.NamedProperties.Put("ValidateMethod", "");
            this.colsProjectCostElementDesc.Position = 8;
            resources.ApplyResources(this.colsProjectCostElementDesc, "colsProjectCostElementDesc");
            // 
            // coldValidFrom
            // 
            this.coldValidFrom.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.coldValidFrom.Format = "d";
            this.coldValidFrom.Name = "coldValidFrom";
            this.coldValidFrom.NamedProperties.Put("EnumerateMethod", "");
            this.coldValidFrom.NamedProperties.Put("FieldFlags", "162");
            this.coldValidFrom.NamedProperties.Put("LovReference", "");
            this.coldValidFrom.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.coldValidFrom.NamedProperties.Put("ResizeableChildObject", "");
            this.coldValidFrom.NamedProperties.Put("SqlColumn", "VALID_FROM");
            this.coldValidFrom.NamedProperties.Put("ValidateMethod", "");
            this.coldValidFrom.Position = 9;
            resources.ApplyResources(this.coldValidFrom, "coldValidFrom");
            // 
            // colsElementType
            // 
            this.colsElementType.MaxLength = 20;
            this.colsElementType.Name = "colsElementType";
            this.colsElementType.NamedProperties.Put("EnumerateMethod", "PRJ_FOLLOWUP_ELEMENT_TYPE_API.Enumerate");
            this.colsElementType.NamedProperties.Put("FieldFlags", "288");
            this.colsElementType.NamedProperties.Put("LovReference", "");
            this.colsElementType.NamedProperties.Put("ParentName", "colsProjectCostElement");
            this.colsElementType.NamedProperties.Put("ResizeableChildObject", "");
            this.colsElementType.NamedProperties.Put("SqlColumn", "Project_Cost_Element_API.Get_Element_Type_Client(COMPANY, PROJECT_COST_ELEMENT)");
            this.colsElementType.NamedProperties.Put("ValidateMethod", "");
            this.colsElementType.Position = 10;
            resources.ApplyResources(this.colsElementType, "colsElementType");
            // 
            // menuTbwMethods
            // 
            this.menuTbwMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_Change,
            this.menuItem_Secondary});
            this.menuTbwMethods.Name = "menuTbwMethods";
            resources.ApplyResources(this.menuTbwMethods, "menuTbwMethods");
            // 
            // menuItem_Change
            // 
            this.menuItem_Change.Command = this.menuTbwMethods_menuChange__Company___;
            this.menuItem_Change.Name = "menuItem_Change";
            resources.ApplyResources(this.menuItem_Change, "menuItem_Change");
            this.menuItem_Change.Text = "Change &Company...";
            // 
            // menuItem_Secondary
            // 
            this.menuItem_Secondary.Command = this.menuTbwMethods_menuSecondary__Cost___;
            this.menuItem_Secondary.Name = "menuItem_Secondary";
            resources.ApplyResources(this.menuItem_Secondary, "menuItem_Secondary");
            this.menuItem_Secondary.Text = "Secondary Project Cost/Revenue Element...";
            // 
            // menuTbwMethods_menuSecondary__Cost___
            // 
            resources.ApplyResources(this.menuTbwMethods_menuSecondary__Cost___, "menuTbwMethods_menuSecondary__Cost___");
            this.menuTbwMethods_menuSecondary__Cost___.Name = "menuTbwMethods_menuSecondary__Cost___";
            this.menuTbwMethods_menuSecondary__Cost___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Secondary_Execute);
            this.menuTbwMethods_menuSecondary__Cost___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Secondary_Inquire);
            // 
            // tbwCostElementToAccount
            // 
            resources.ApplyResources(this, "$this");
            this.ContextMenuStrip = this.menuTbwMethods;
            this.Controls.Add(this.colsCompany);
            this.Controls.Add(this.colsCodePart);
            this.Controls.Add(this.colsAccount);
            this.Controls.Add(this.colsAccountDescription);
            this.Controls.Add(this.colsProjectCostElement);
            this.Controls.Add(this.colsProjectCostElementDesc);
            this.Controls.Add(this.coldValidFrom);
            this.Controls.Add(this.colsElementType);
            this.Name = "tbwCostElementToAccount";
            this.NamedProperties.Put("DefaultOrderBy", "ACCOUNT");
            this.NamedProperties.Put("DefaultWhere", "COMPANY =:global.company ");
            this.NamedProperties.Put("LogicalUnit", "CostElementToAccount");
            this.NamedProperties.Put("PackageName", "COST_ELEMENT_TO_ACCOUNT_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "449");
            this.NamedProperties.Put("ViewName", "COST_ELEMENT_TO_ACCOUNT_ALL");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tbwCostElementToAccount_WindowActions);
            this.Controls.SetChildIndex(this.colsElementType, 0);
            this.Controls.SetChildIndex(this.coldValidFrom, 0);
            this.Controls.SetChildIndex(this.colsProjectCostElementDesc, 0);
            this.Controls.SetChildIndex(this.colsProjectCostElement, 0);
            this.Controls.SetChildIndex(this.colsAccountDescription, 0);
            this.Controls.SetChildIndex(this.colsAccount, 0);
            this.Controls.SetChildIndex(this.colsCodePart, 0);
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

        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menuChange__Company___;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTbwMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Secondary;
        protected Fnd.Windows.Forms.FndCommand menuTbwMethods_menuSecondary__Cost___;
	}
}
