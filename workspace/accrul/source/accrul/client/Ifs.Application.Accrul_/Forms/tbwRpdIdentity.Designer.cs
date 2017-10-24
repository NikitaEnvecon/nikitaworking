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

    public partial class tbwRpdIdentity
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwRpdIdentity));
            this.colsRpdId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.menuTbwMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuTbwMethods_MenuItem_RPDPeriods = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.cmd_menuTbwMethods_MenuItem_RPDPeriods = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_MenuItem_CompaniesPerRPD = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.cmd_menuTbwMethods_MenuItem_CompaniesPerRPD = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_MenuItemSeparator = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.menuTbwMethods_MenuItem_GenOnStdCal = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.cmd_menuTbwMethods_MenuItem_GenOnSysCal = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_MenuItem_GenOnAccCal = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.cmd_menuTbwMethods_MenuItem_GenOnAccCal = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.cmd_menuTbwMethods_MenuItem_GenOnSysCal);
            this.commandManager.Commands.Add(this.cmd_menuTbwMethods_MenuItem_GenOnAccCal);
            this.commandManager.Commands.Add(this.cmd_menuTbwMethods_MenuItem_CompaniesPerRPD);
            this.commandManager.Commands.Add(this.cmd_menuTbwMethods_MenuItem_RPDPeriods);
            this.commandManager.ContextMenus.Add(this.menuTbwMethods);
            // 
            // __colObjid
            // 
            this.@__colObjid.Position = 3;
            // 
            // __colObjversion
            // 
            this.@__colObjversion.Position = 4;
            // 
            // colsRpdId
            // 
            this.colsRpdId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsRpdId.Name = "colsRpdId";
            this.colsRpdId.NamedProperties.Put("EnumerateMethod", "");
            this.colsRpdId.NamedProperties.Put("FieldFlags", "163");
            this.colsRpdId.NamedProperties.Put("LovReference", "");
            this.colsRpdId.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsRpdId.NamedProperties.Put("SqlColumn", "RPD_ID");
            this.colsRpdId.Position = 1;
            resources.ApplyResources(this.colsRpdId, "colsRpdId");
            // 
            // colsDescription
            // 
            this.colsDescription.MaxLength = 200;
            this.colsDescription.Name = "colsDescription";
            this.colsDescription.NamedProperties.Put("EnumerateMethod", "");
            this.colsDescription.NamedProperties.Put("FieldFlags", "294");
            this.colsDescription.NamedProperties.Put("LovReference", "");
            this.colsDescription.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsDescription.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            this.colsDescription.Position = 2;
            resources.ApplyResources(this.colsDescription, "colsDescription");
            // 
            // menuTbwMethods
            // 
            this.menuTbwMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuTbwMethods_MenuItem_RPDPeriods,
            this.menuTbwMethods_MenuItem_CompaniesPerRPD,
            this.menuTbwMethods_MenuItemSeparator,
            this.menuTbwMethods_MenuItem_GenOnStdCal,
            this.menuTbwMethods_MenuItem_GenOnAccCal});
            this.menuTbwMethods.Name = "menuTbwMethods";
            resources.ApplyResources(this.menuTbwMethods, "menuTbwMethods");
            // 
            // menuTbwMethods_MenuItem_RPDPeriods
            // 
            this.menuTbwMethods_MenuItem_RPDPeriods.Command = this.cmd_menuTbwMethods_MenuItem_RPDPeriods;
            this.menuTbwMethods_MenuItem_RPDPeriods.Name = "menuTbwMethods_MenuItem_RPDPeriods";
            resources.ApplyResources(this.menuTbwMethods_MenuItem_RPDPeriods, "menuTbwMethods_MenuItem_RPDPeriods");
            this.menuTbwMethods_MenuItem_RPDPeriods.Text = "Reporting Periods...";
            // 
            // cmd_menuTbwMethods_MenuItem_RPDPeriods
            // 
            resources.ApplyResources(this.cmd_menuTbwMethods_MenuItem_RPDPeriods, "cmd_menuTbwMethods_MenuItem_RPDPeriods");
            this.cmd_menuTbwMethods_MenuItem_RPDPeriods.Name = "cmd_menuTbwMethods_MenuItem_RPDPeriods";
            this.cmd_menuTbwMethods_MenuItem_RPDPeriods.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.cmd_menuTbwMethods_MenuItem_RPDPeriods_Execute);
            this.cmd_menuTbwMethods_MenuItem_RPDPeriods.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.cmd_menuTbwMethods_MenuItem_RPDPeriods_Inquire);
            // 
            // menuTbwMethods_MenuItem_CompaniesPerRPD
            // 
            this.menuTbwMethods_MenuItem_CompaniesPerRPD.Command = this.cmd_menuTbwMethods_MenuItem_CompaniesPerRPD;
            this.menuTbwMethods_MenuItem_CompaniesPerRPD.Name = "menuTbwMethods_MenuItem_CompaniesPerRPD";
            resources.ApplyResources(this.menuTbwMethods_MenuItem_CompaniesPerRPD, "menuTbwMethods_MenuItem_CompaniesPerRPD");
            this.menuTbwMethods_MenuItem_CompaniesPerRPD.Text = "Companies per Reporting Period Definition ID...";
            // 
            // cmd_menuTbwMethods_MenuItem_CompaniesPerRPD
            // 
            resources.ApplyResources(this.cmd_menuTbwMethods_MenuItem_CompaniesPerRPD, "cmd_menuTbwMethods_MenuItem_CompaniesPerRPD");
            this.cmd_menuTbwMethods_MenuItem_CompaniesPerRPD.Name = "cmd_menuTbwMethods_MenuItem_CompaniesPerRPD";
            this.cmd_menuTbwMethods_MenuItem_CompaniesPerRPD.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.cmd_menuTbwMethods_MenuItem_CompaniesPerRPD_Execute);
            this.cmd_menuTbwMethods_MenuItem_CompaniesPerRPD.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.cmd_menuTbwMethods_MenuItem_CompaniesPerRPD_Inquire);
            // 
            // menuTbwMethods_MenuItemSeparator
            // 
            this.menuTbwMethods_MenuItemSeparator.Name = "menuTbwMethods_MenuItemSeparator";
            resources.ApplyResources(this.menuTbwMethods_MenuItemSeparator, "menuTbwMethods_MenuItemSeparator");
            // 
            // menuTbwMethods_MenuItem_GenOnStdCal
            // 
            this.menuTbwMethods_MenuItem_GenOnStdCal.Command = this.cmd_menuTbwMethods_MenuItem_GenOnSysCal;
            this.menuTbwMethods_MenuItem_GenOnStdCal.Name = "menuTbwMethods_MenuItem_GenOnStdCal";
            resources.ApplyResources(this.menuTbwMethods_MenuItem_GenOnStdCal, "menuTbwMethods_MenuItem_GenOnStdCal");
            this.menuTbwMethods_MenuItem_GenOnStdCal.Text = "Generate Based on System Calendar...";
            // 
            // cmd_menuTbwMethods_MenuItem_GenOnSysCal
            // 
            resources.ApplyResources(this.cmd_menuTbwMethods_MenuItem_GenOnSysCal, "cmd_menuTbwMethods_MenuItem_GenOnSysCal");
            this.cmd_menuTbwMethods_MenuItem_GenOnSysCal.Name = "cmd_menuTbwMethods_MenuItem_GenOnSysCal";
            this.cmd_menuTbwMethods_MenuItem_GenOnSysCal.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.cmd_menuTbwMethods_MenuItem_GenOnSysCal_Execute);
            this.cmd_menuTbwMethods_MenuItem_GenOnSysCal.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.cmd_menuTbwMethods_MenuItem_GenOnSysCal_Inquire);
            // 
            // menuTbwMethods_MenuItem_GenOnAccCal
            // 
            this.menuTbwMethods_MenuItem_GenOnAccCal.Command = this.cmd_menuTbwMethods_MenuItem_GenOnAccCal;
            this.menuTbwMethods_MenuItem_GenOnAccCal.Name = "menuTbwMethods_MenuItem_GenOnAccCal";
            resources.ApplyResources(this.menuTbwMethods_MenuItem_GenOnAccCal, "menuTbwMethods_MenuItem_GenOnAccCal");
            this.menuTbwMethods_MenuItem_GenOnAccCal.Text = "Generate Based on Accounting Calendar...";
            // 
            // cmd_menuTbwMethods_MenuItem_GenOnAccCal
            // 
            resources.ApplyResources(this.cmd_menuTbwMethods_MenuItem_GenOnAccCal, "cmd_menuTbwMethods_MenuItem_GenOnAccCal");
            this.cmd_menuTbwMethods_MenuItem_GenOnAccCal.Name = "cmd_menuTbwMethods_MenuItem_GenOnAccCal";
            this.cmd_menuTbwMethods_MenuItem_GenOnAccCal.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.cmd_menuTbwMethods_MenuItem_GenOnAccCal_Execute);
            this.cmd_menuTbwMethods_MenuItem_GenOnAccCal.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.cmd_menuTbwMethods_MenuItem_GenOnAccCal_Inquire);
            // 
            // tbwRpdIdentity
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colsRpdId);
            this.Controls.Add(this.colsDescription);
            this.Name = "tbwRpdIdentity";
            this.NamedProperties.Put("LogicalUnit", "RpdIdentity");
            this.NamedProperties.Put("Module", "ACCRUL");
            this.NamedProperties.Put("PackageName", "RPD_IDENTITY_API");
            this.NamedProperties.Put("SourceFlags", "16833");
            this.NamedProperties.Put("ViewName", "RPD_IDENTITY");
            this.Controls.SetChildIndex(this.@__colObjversion, 0);
            this.Controls.SetChildIndex(this.@__colObjid, 0);
            this.Controls.SetChildIndex(this.colsDescription, 0);
            this.Controls.SetChildIndex(this.colsRpdId, 0);
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

        protected cColumn colsRpdId;
        protected cColumn colsDescription;
        protected Fnd.Windows.Forms.FndCommand cmd_menuTbwMethods_MenuItem_GenOnSysCal;
        protected Fnd.Windows.Forms.FndCommand cmd_menuTbwMethods_MenuItem_GenOnAccCal;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTbwMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuTbwMethods_MenuItem_GenOnAccCal;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuTbwMethods_MenuItem_GenOnStdCal;
        protected Fnd.Windows.Forms.FndCommand cmd_menuTbwMethods_MenuItem_CompaniesPerRPD;
        protected Fnd.Windows.Forms.FndCommand cmd_menuTbwMethods_MenuItem_RPDPeriods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuTbwMethods_MenuItem_RPDPeriods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuTbwMethods_MenuItem_CompaniesPerRPD;
        protected Fnd.Windows.Forms.FndToolStripSeparator menuTbwMethods_MenuItemSeparator;
    }
}
