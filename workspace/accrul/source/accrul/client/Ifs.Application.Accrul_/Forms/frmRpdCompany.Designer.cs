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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ifs.Fnd.ApplicationForms;
using PPJ.Runtime;
using PPJ.Runtime.Windows;

namespace Ifs.Application.Accrul_
{

    public partial class frmRpdCompany
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRpdCompany));
            this.cChildTableDetail = new Ifs.Fnd.ApplicationForms.cChildTable();
            this.menuTblMenu = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuTblMenu_MenuItem_AccPerConnections = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.cmd_menuTblMenu_MenuItem_AccPerConnections = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.tsMenuItemSeparator = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.menuTblMenu_MenuItem_MapAccPeriods = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.cmd_menuTblMenu_MenuItem_MapAccountingPeriods = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.cChildTableDetail_colsRpdId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.cChildTableDetail_colsCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.cChildTableDetail_colsCompanyName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.cChildTableDetail_colIsRpdPeriodsDefined = new Ifs.Fnd.ApplicationForms.cColumn();
            this.labelDescription = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsDescription = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelRpdId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbRpdId = new Ifs.Fnd.ApplicationForms.cRecListDataField();
            this.cChildTableDetail.SuspendLayout();
            this.menuTblMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.cmd_menuTblMenu_MenuItem_AccPerConnections);
            this.commandManager.Commands.Add(this.cmd_menuTblMenu_MenuItem_MapAccountingPeriods);
            this.commandManager.ContextMenus.Add(this.menuTblMenu);
            // 
            // cChildTableDetail
            // 
            this.cChildTableDetail.ContextMenuStrip = this.menuTblMenu;
            this.cChildTableDetail.Controls.Add(this.cChildTableDetail_colsRpdId);
            this.cChildTableDetail.Controls.Add(this.cChildTableDetail_colsCompany);
            this.cChildTableDetail.Controls.Add(this.cChildTableDetail_colsCompanyName);
            this.cChildTableDetail.Controls.Add(this.cChildTableDetail_colIsRpdPeriodsDefined);
            resources.ApplyResources(this.cChildTableDetail, "cChildTableDetail");
            this.cChildTableDetail.Name = "cChildTableDetail";
            this.cChildTableDetail.NamedProperties.Put("DefaultWhere", "RPD_ID = :i_hWndFrame.frmRpdCompany.cmbRpdId.i_sMyValue\n");
            this.cChildTableDetail.NamedProperties.Put("LogicalUnit", "RpdCompany");
            this.cChildTableDetail.NamedProperties.Put("Module", "ACCRUL");
            this.cChildTableDetail.NamedProperties.Put("PackageName", "RPD_COMPANY_API");
            this.cChildTableDetail.NamedProperties.Put("ResizeableChildObject", "LLMM");
            this.cChildTableDetail.NamedProperties.Put("ViewName", "RPD_COMPANY");
            this.cChildTableDetail.Controls.SetChildIndex(this.cChildTableDetail_colIsRpdPeriodsDefined, 0);
            this.cChildTableDetail.Controls.SetChildIndex(this.cChildTableDetail_colsCompanyName, 0);
            this.cChildTableDetail.Controls.SetChildIndex(this.cChildTableDetail_colsCompany, 0);
            this.cChildTableDetail.Controls.SetChildIndex(this.cChildTableDetail_colsRpdId, 0);
            // 
            // menuTblMenu
            // 
            this.menuTblMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuTblMenu_MenuItem_AccPerConnections,
            this.tsMenuItemSeparator,
            this.menuTblMenu_MenuItem_MapAccPeriods});
            this.menuTblMenu.Name = "menuTblMenu";
            resources.ApplyResources(this.menuTblMenu, "menuTblMenu");
            // 
            // menuTblMenu_MenuItem_AccPerConnections
            // 
            this.menuTblMenu_MenuItem_AccPerConnections.Command = this.cmd_menuTblMenu_MenuItem_AccPerConnections;
            this.menuTblMenu_MenuItem_AccPerConnections.Name = "menuTblMenu_MenuItem_AccPerConnections";
            resources.ApplyResources(this.menuTblMenu_MenuItem_AccPerConnections, "menuTblMenu_MenuItem_AccPerConnections");
            this.menuTblMenu_MenuItem_AccPerConnections.Text = "Accounting Period Connections...";
            // 
            // cmd_menuTblMenu_MenuItem_AccPerConnections
            // 
            resources.ApplyResources(this.cmd_menuTblMenu_MenuItem_AccPerConnections, "cmd_menuTblMenu_MenuItem_AccPerConnections");
            this.cmd_menuTblMenu_MenuItem_AccPerConnections.Name = "cmd_menuTblMenu_MenuItem_AccPerConnections";
            this.cmd_menuTblMenu_MenuItem_AccPerConnections.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.cmd_menuTblMenu_MenuItem_AccPerConnections_Execute);
            this.cmd_menuTblMenu_MenuItem_AccPerConnections.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.cmd_menuTblMenu_MenuItem_AccPerConnections_Inquire);
            // 
            // tsMenuItemSeparator
            // 
            this.tsMenuItemSeparator.Name = "tsMenuItemSeparator";
            resources.ApplyResources(this.tsMenuItemSeparator, "tsMenuItemSeparator");
            // 
            // menuTblMenu_MenuItem_MapAccPeriods
            // 
            this.menuTblMenu_MenuItem_MapAccPeriods.Command = this.cmd_menuTblMenu_MenuItem_MapAccountingPeriods;
            this.menuTblMenu_MenuItem_MapAccPeriods.Name = "menuTblMenu_MenuItem_MapAccPeriods";
            resources.ApplyResources(this.menuTblMenu_MenuItem_MapAccPeriods, "menuTblMenu_MenuItem_MapAccPeriods");
            this.menuTblMenu_MenuItem_MapAccPeriods.Text = "Map Accounting Periods...";
            // 
            // cmd_menuTblMenu_MenuItem_MapAccountingPeriods
            // 
            resources.ApplyResources(this.cmd_menuTblMenu_MenuItem_MapAccountingPeriods, "cmd_menuTblMenu_MenuItem_MapAccountingPeriods");
            this.cmd_menuTblMenu_MenuItem_MapAccountingPeriods.Name = "cmd_menuTblMenu_MenuItem_MapAccountingPeriods";
            this.cmd_menuTblMenu_MenuItem_MapAccountingPeriods.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.cmd_menuTblMenu_MenuItem_MapAccountingPeriods_Execute);
            this.cmd_menuTblMenu_MenuItem_MapAccountingPeriods.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.cmd_menuTblMenu_MenuItem_MapAccountingPeriods_Inquire);
            // 
            // cChildTableDetail_colsRpdId
            // 
            this.cChildTableDetail_colsRpdId.Name = "cChildTableDetail_colsRpdId";
            this.cChildTableDetail_colsRpdId.NamedProperties.Put("EnumerateMethod", "");
            this.cChildTableDetail_colsRpdId.NamedProperties.Put("FieldFlags", "99");
            this.cChildTableDetail_colsRpdId.NamedProperties.Put("LovReference", "RPD_IDENTITY");
            this.cChildTableDetail_colsRpdId.NamedProperties.Put("SqlColumn", "RPD_ID");
            this.cChildTableDetail_colsRpdId.Position = 3;
            resources.ApplyResources(this.cChildTableDetail_colsRpdId, "cChildTableDetail_colsRpdId");
            // 
            // cChildTableDetail_colsCompany
            // 
            this.cChildTableDetail_colsCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cChildTableDetail_colsCompany.Name = "cChildTableDetail_colsCompany";
            this.cChildTableDetail_colsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.cChildTableDetail_colsCompany.NamedProperties.Put("FieldFlags", "163");
            this.cChildTableDetail_colsCompany.NamedProperties.Put("LovReference", "COMPANY_FINANCE");
            this.cChildTableDetail_colsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.cChildTableDetail_colsCompany.Position = 4;
            resources.ApplyResources(this.cChildTableDetail_colsCompany, "cChildTableDetail_colsCompany");
            // 
            // cChildTableDetail_colsCompanyName
            // 
            this.cChildTableDetail_colsCompanyName.MaxLength = 2000;
            this.cChildTableDetail_colsCompanyName.Name = "cChildTableDetail_colsCompanyName";
            this.cChildTableDetail_colsCompanyName.NamedProperties.Put("EnumerateMethod", "");
            this.cChildTableDetail_colsCompanyName.NamedProperties.Put("FieldFlags", "288");
            this.cChildTableDetail_colsCompanyName.NamedProperties.Put("LovReference", "");
            this.cChildTableDetail_colsCompanyName.NamedProperties.Put("ParentName", "cChildTableDetail.cChildTableDetail_colsCompany");
            this.cChildTableDetail_colsCompanyName.NamedProperties.Put("SqlColumn", "COMPANY_FINANCE_API.GET_DESCRIPTION(COMPANY)");
            this.cChildTableDetail_colsCompanyName.Position = 5;
            resources.ApplyResources(this.cChildTableDetail_colsCompanyName, "cChildTableDetail_colsCompanyName");
            // 
            // cChildTableDetail_colIsRpdPeriodsDefined
            // 
            this.cChildTableDetail_colIsRpdPeriodsDefined.CellType = PPJ.Runtime.Windows.CellType.CheckBox;
            this.cChildTableDetail_colIsRpdPeriodsDefined.CheckBox.CheckedValue = "TRUE";
            this.cChildTableDetail_colIsRpdPeriodsDefined.CheckBox.IgnoreCase = true;
            this.cChildTableDetail_colIsRpdPeriodsDefined.CheckBox.UncheckedValue = "";
            this.cChildTableDetail_colIsRpdPeriodsDefined.MaxLength = 2000;
            this.cChildTableDetail_colIsRpdPeriodsDefined.Name = "cChildTableDetail_colIsRpdPeriodsDefined";
            this.cChildTableDetail_colIsRpdPeriodsDefined.NamedProperties.Put("EnumerateMethod", "");
            this.cChildTableDetail_colIsRpdPeriodsDefined.NamedProperties.Put("FieldFlags", "288");
            this.cChildTableDetail_colIsRpdPeriodsDefined.NamedProperties.Put("LovReference", "");
            this.cChildTableDetail_colIsRpdPeriodsDefined.NamedProperties.Put("ParentName", "cChildTableDetail.cChildTableDetail_colsCompany");
            this.cChildTableDetail_colIsRpdPeriodsDefined.NamedProperties.Put("SqlColumn", "RPD_IDENTITY_API.Is_Rpd_Periods_Defined(RPD_ID)");
            this.cChildTableDetail_colIsRpdPeriodsDefined.Position = 6;
            this.cChildTableDetail_colIsRpdPeriodsDefined.ReadOnly = true;
            resources.ApplyResources(this.cChildTableDetail_colIsRpdPeriodsDefined, "cChildTableDetail_colIsRpdPeriodsDefined");
            // 
            // labelDescription
            // 
            resources.ApplyResources(this.labelDescription, "labelDescription");
            this.labelDescription.Name = "labelDescription";
            // 
            // dfsDescription
            // 
            resources.ApplyResources(this.dfsDescription, "dfsDescription");
            this.dfsDescription.Name = "dfsDescription";
            this.dfsDescription.NamedProperties.Put("EnumerateMethod", "");
            this.dfsDescription.NamedProperties.Put("FieldFlags", "288");
            this.dfsDescription.NamedProperties.Put("LovReference", "");
            this.dfsDescription.NamedProperties.Put("ParentName", "cmbRpdId");
            this.dfsDescription.NamedProperties.Put("SqlColumn", "RPD_IDENTITY_API.GET_DESCRIPTION(RPD_ID)");
            // 
            // labelRpdId
            // 
            resources.ApplyResources(this.labelRpdId, "labelRpdId");
            this.labelRpdId.Name = "labelRpdId";
            // 
            // cmbRpdId
            // 
            this.cmbRpdId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.cmbRpdId, "cmbRpdId");
            this.cmbRpdId.Name = "cmbRpdId";
            this.cmbRpdId.NamedProperties.Put("EnumerateMethod", "");
            this.cmbRpdId.NamedProperties.Put("FieldFlags", "99");
            this.cmbRpdId.NamedProperties.Put("Format", "9");
            this.cmbRpdId.NamedProperties.Put("LovReference", "RPD_IDENTITY");
            this.cmbRpdId.NamedProperties.Put("SqlColumn", "RPD_ID");
            this.cmbRpdId.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbRpdId_WindowActions);
            // 
            // frmRpdCompany
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.dfsDescription);
            this.Controls.Add(this.labelRpdId);
            this.Controls.Add(this.cmbRpdId);
            this.Controls.Add(this.cChildTableDetail);
            this.Name = "frmRpdCompany";
            this.NamedProperties.Put("LogicalUnit", "RpdIdentity");
            this.NamedProperties.Put("Module", "ACCRUL");
            this.NamedProperties.Put("PackageName", "RPD_IDENTITY_API");
            this.NamedProperties.Put("ViewName", "RPD_IDENTITY");
            this.cChildTableDetail.ResumeLayout(false);
            this.menuTblMenu.ResumeLayout(false);
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

        protected cChildTable cChildTableDetail;
        protected cColumn cChildTableDetail_colsRpdId;
        protected cColumn cChildTableDetail_colsCompany;
        protected cBackgroundText labelDescription;
        protected cDataField dfsDescription;
        protected cBackgroundText labelRpdId;
        protected cRecListDataField cmbRpdId;
        protected cColumn cChildTableDetail_colsCompanyName;
        protected Fnd.Windows.Forms.FndCommand cmd_menuTblMenu_MenuItem_AccPerConnections;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTblMenu;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuTblMenu_MenuItem_AccPerConnections;
        protected Fnd.Windows.Forms.FndCommand cmd_menuTblMenu_MenuItem_MapAccountingPeriods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuTblMenu_MenuItem_MapAccPeriods;
        protected Fnd.Windows.Forms.FndToolStripSeparator tsMenuItemSeparator;
        protected cColumn cChildTableDetail_colIsRpdPeriodsDefined;
    }
}
