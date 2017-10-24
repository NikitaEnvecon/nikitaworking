#region Copyright (c) IFS Research & Development
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

    public partial class tbwCostEleToAccntSecmap
    {

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwCostEleToAccntSecmap));
            this.colsCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsCodePart = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsAccount = new Ifs.Application.Accrul.cColumnFin();
            this.colsProjectCostElement = new Ifs.Application.Accrul.cColumnFin();
            this.coldValidFrom = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsAccountDescription = new Ifs.Application.Accrul.cColumnFin();
            this.colsProjectCostElementDesc = new Ifs.Application.Accrul.cColumnFin();
            this.colsElementType = new Ifs.Application.Accrul.cColumnFin();
            this.menuTbwMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_CopyCRE = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuTbwMethods_menuCopyCRESecondary_Mapping__ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuItem_Change = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuTbwMethods_menuChange_Company__ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuTbwMethods_menuCopyCRESecondary_Mapping__);
            this.commandManager.Commands.Add(this.menuTbwMethods_menuChange_Company__);
            this.commandManager.ContextMenus.Add(this.menuTbwMethods);
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
            this.colsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
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
            this.colsCodePart.NamedProperties.Put("SqlColumn", "CODE_PART");
            this.colsCodePart.Position = 4;
            // 
            // colsAccount
            // 
            this.colsAccount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsAccount.MaxLength = 20;
            this.colsAccount.Name = "colsAccount";
            this.colsAccount.NamedProperties.Put("EnumerateMethod", "");
            this.colsAccount.NamedProperties.Put("FieldFlags", "291");
            this.colsAccount.NamedProperties.Put("LovReference", "SECONDARY_ACC_CODE_PART_VALUE(COMPANY,CODE_PART)");
            this.colsAccount.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsAccount.NamedProperties.Put("SqlColumn", "ACCOUNT");
            this.colsAccount.Position = 5;
            resources.ApplyResources(this.colsAccount, "colsAccount");
            this.colsAccount.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsAccount_WindowActions);
            // 
            // colsProjectCostElement
            // 
            this.colsProjectCostElement.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsProjectCostElement.Name = "colsProjectCostElement";
            this.colsProjectCostElement.NamedProperties.Put("EnumerateMethod", "");
            this.colsProjectCostElement.NamedProperties.Put("FieldFlags", "294");
            this.colsProjectCostElement.NamedProperties.Put("LovReference", "PROJECT_COST_ELEMENT_LOV(COMPANY)");
            this.colsProjectCostElement.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsProjectCostElement.NamedProperties.Put("SqlColumn", "PROJECT_COST_ELEMENT");
            this.colsProjectCostElement.Position = 7;
            resources.ApplyResources(this.colsProjectCostElement, "colsProjectCostElement");
            this.colsProjectCostElement.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsProjectCostElement_WindowActions);
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
            this.coldValidFrom.NamedProperties.Put("SqlColumn", "VALID_FROM");
            this.coldValidFrom.Position = 9;
            resources.ApplyResources(this.coldValidFrom, "coldValidFrom");
            // 
            // colsAccountDescription
            // 
            this.colsAccountDescription.Name = "colsAccountDescription";
            this.colsAccountDescription.NamedProperties.Put("EnumerateMethod", "");
            this.colsAccountDescription.NamedProperties.Put("FieldFlags", "288");
            this.colsAccountDescription.NamedProperties.Put("LovReference", "");
            this.colsAccountDescription.NamedProperties.Put("ParentName", "colsAccount");
            this.colsAccountDescription.NamedProperties.Put("SqlColumn", "Accounting_Code_Part_Value_API.Get_Desc_For_Code_Part(COMPANY, CODE_PART, ACCOUNT" +
                    ")");
            this.colsAccountDescription.Position = 6;
            resources.ApplyResources(this.colsAccountDescription, "colsAccountDescription");
            // 
            // colsProjectCostElementDesc
            // 
            this.colsProjectCostElementDesc.Name = "colsProjectCostElementDesc";
            this.colsProjectCostElementDesc.NamedProperties.Put("EnumerateMethod", "");
            this.colsProjectCostElementDesc.NamedProperties.Put("FieldFlags", "288");
            this.colsProjectCostElementDesc.NamedProperties.Put("LovReference", "");
            this.colsProjectCostElementDesc.NamedProperties.Put("ParentName", "colsProjectCostElement");
            this.colsProjectCostElementDesc.NamedProperties.Put("SqlColumn", "Project_Cost_Element_API.Get_Description(COMPANY, PROJECT_COST_ELEMENT)");
            this.colsProjectCostElementDesc.Position = 8;
            resources.ApplyResources(this.colsProjectCostElementDesc, "colsProjectCostElementDesc");
            // 
            // colsElementType
            // 
            this.colsElementType.MaxLength = 20;
            this.colsElementType.Name = "colsElementType";
            this.colsElementType.NamedProperties.Put("EnumerateMethod", "");
            this.colsElementType.NamedProperties.Put("FieldFlags", "288");
            this.colsElementType.NamedProperties.Put("LovReference", "");
            this.colsElementType.NamedProperties.Put("ParentName", "colsProjectCostElement");
            this.colsElementType.NamedProperties.Put("SqlColumn", "Project_Cost_Element_API.Get_Element_Type_Client(COMPANY, PROJECT_COST_ELEMENT)");
            this.colsElementType.Position = 10;
            resources.ApplyResources(this.colsElementType, "colsElementType");
            // 
            // menuTbwMethods
            // 
            this.menuTbwMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_CopyCRE,
            this.menuItem_Change});
            this.menuTbwMethods.Name = "menuTbwMethods";
            resources.ApplyResources(this.menuTbwMethods, "menuTbwMethods");
            // 
            // menuItem_CopyCRE
            // 
            this.menuItem_CopyCRE.Command = this.menuTbwMethods_menuCopyCRESecondary_Mapping__;
            resources.ApplyResources(this.menuItem_CopyCRE, "menuItem_CopyCRE");
            this.menuItem_CopyCRE.Name = "menuItem_CopyCRE";
            this.menuItem_CopyCRE.Text = "Copy Cost/Revenue Elements to Secondary Mapping...";
            // 
            // menuTbwMethods_menuCopyCRESecondary_Mapping__
            // 
            resources.ApplyResources(this.menuTbwMethods_menuCopyCRESecondary_Mapping__, "menuTbwMethods_menuCopyCRESecondary_Mapping__");
            this.menuTbwMethods_menuCopyCRESecondary_Mapping__.Enabled = false;
            this.menuTbwMethods_menuCopyCRESecondary_Mapping__.Name = "menuTbwMethods_menuCopyCRESecondary_Mapping__";
            this.menuTbwMethods_menuCopyCRESecondary_Mapping__.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_CopyCRE_Execute);
            this.menuTbwMethods_menuCopyCRESecondary_Mapping__.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_CopyCRE_Inquire);
            // 
            // menuItem_Change
            // 
            this.menuItem_Change.Command = this.menuTbwMethods_menuChange_Company__;
            this.menuItem_Change.Name = "menuItem_Change";
            resources.ApplyResources(this.menuItem_Change, "menuItem_Change");
            this.menuItem_Change.Text = "Change &Company...";
            // 
            // menuTbwMethods_menuChange_Company__
            // 
            resources.ApplyResources(this.menuTbwMethods_menuChange_Company__, "menuTbwMethods_menuChange_Company__");
            this.menuTbwMethods_menuChange_Company__.Name = "menuTbwMethods_menuChange_Company__";
            this.menuTbwMethods_menuChange_Company__.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Change_Execute);
            this.menuTbwMethods_menuChange_Company__.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Change_Inquire);
            // 
            // tbwCostEleToAccntSecmap
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colsCompany);
            this.Controls.Add(this.colsCodePart);
            this.Controls.Add(this.colsAccount);
            this.Controls.Add(this.colsAccountDescription);
            this.Controls.Add(this.colsProjectCostElement);
            this.Controls.Add(this.colsProjectCostElementDesc);
            this.Controls.Add(this.coldValidFrom);
            this.Controls.Add(this.colsElementType);
            this.Name = "tbwCostEleToAccntSecmap";
            this.NamedProperties.Put("DefaultOrderBy", "ACCOUNT");
            this.NamedProperties.Put("DefaultWhere", "COMPANY =:global.company ");
            this.NamedProperties.Put("LogicalUnit", "CostEleToAccntSecmap");
            this.NamedProperties.Put("Module", "ACCRUL");
            this.NamedProperties.Put("PackageName", "COST_ELE_TO_ACCNT_SECMAP_API");
            this.NamedProperties.Put("SourceFlags", "449");
            this.NamedProperties.Put("ViewName", "COST_ELE_TO_ACCNT_SECMAP");
            this.NamedProperties.Put("Warnings", "TRUE");
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

        public cColumn colsCompany;
        public cColumn colsCodePart;

        public cColumnFin colsAccount;
        public cColumnFin colsAccountDescription;
        public cColumnFin colsProjectCostElement;
        public cColumnFin colsProjectCostElementDesc;

        public cColumn coldValidFrom;
        public cColumnFin colsElementType;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTbwMethods;
        protected Fnd.Windows.Forms.FndCommand menuTbwMethods_menuCopyCRESecondary_Mapping__;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_CopyCRE;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menuChange_Company__;
    }
}
