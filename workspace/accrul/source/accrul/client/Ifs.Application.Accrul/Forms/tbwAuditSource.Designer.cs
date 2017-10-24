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

namespace Ifs.Application.Accrul
{

    public partial class tbwAuditSource
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwAuditSource));
            this.colsAuditSource = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsSourceType = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.colsSystemDefinedDb = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.Columns = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItemColumns = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.colsInternalLedgerDb = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.menuTbwMethods.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.Columns);
            this.commandManager.ContextMenus.Add(this.menuTbwMethods);
            // 
            // colsAuditSource
            // 
            this.colsAuditSource.MaxLength = 30;
            this.colsAuditSource.Name = "colsAuditSource";
            this.colsAuditSource.NamedProperties.Put("EnumerateMethod", "");
            this.colsAuditSource.NamedProperties.Put("FieldFlags", "163");
            this.colsAuditSource.NamedProperties.Put("LovReference", "");
            this.colsAuditSource.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsAuditSource.NamedProperties.Put("SqlColumn", "AUDIT_SOURCE");
            this.colsAuditSource.Position = 3;
            resources.ApplyResources(this.colsAuditSource, "colsAuditSource");
            // 
            // colsDescription
            // 
            this.colsDescription.Name = "colsDescription";
            this.colsDescription.NamedProperties.Put("EnumerateMethod", "");
            this.colsDescription.NamedProperties.Put("FieldFlags", "295");
            this.colsDescription.NamedProperties.Put("LovReference", "");
            this.colsDescription.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsDescription.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            this.colsDescription.Position = 4;
            resources.ApplyResources(this.colsDescription, "colsDescription");
            // 
            // colsSourceType
            // 
            this.colsSourceType.Name = "colsSourceType";
            this.colsSourceType.NamedProperties.Put("EnumerateMethod", "Audit_Source_Type_API.Enumerate");
            this.colsSourceType.NamedProperties.Put("FieldFlags", "288");
            this.colsSourceType.NamedProperties.Put("LovReference", "");
            this.colsSourceType.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsSourceType.NamedProperties.Put("SqlColumn", "SOURCE_TYPE");
            this.colsSourceType.Position = 5;
            resources.ApplyResources(this.colsSourceType, "colsSourceType");
            // 
            // colsSystemDefinedDb
            // 
            this.colsSystemDefinedDb.MaxLength = 20;
            this.colsSystemDefinedDb.Name = "colsSystemDefinedDb";
            this.colsSystemDefinedDb.NamedProperties.Put("EnumerateMethod", "");
            this.colsSystemDefinedDb.NamedProperties.Put("FieldFlags", "288");
            this.colsSystemDefinedDb.NamedProperties.Put("LovReference", "");
            this.colsSystemDefinedDb.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsSystemDefinedDb.NamedProperties.Put("SqlColumn", "SYSTEM_DEFINED_DB");
            this.colsSystemDefinedDb.Position = 7;
            resources.ApplyResources(this.colsSystemDefinedDb, "colsSystemDefinedDb");
            // 
            // Columns
            // 
            resources.ApplyResources(this.Columns, "Columns");
            this.Columns.Name = "Columns";
            this.Columns.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.Columns_Execute);
            this.Columns.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.Columns_Inquire);
            // 
            // menuTbwMethods
            // 
            this.menuTbwMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemColumns});
            this.menuTbwMethods.Name = "menuTbwMethods";
            resources.ApplyResources(this.menuTbwMethods, "menuTbwMethods");
            // 
            // menuItemColumns
            // 
            this.menuItemColumns.Command = this.Columns;
            this.menuItemColumns.Name = "menuItemColumns";
            resources.ApplyResources(this.menuItemColumns, "menuItemColumns");
            this.menuItemColumns.Text = "Source Columns...";
            // 
            // colsInternalLedgerDb
            // 
            this.colsInternalLedgerDb.MaxLength = 20;
            this.colsInternalLedgerDb.Name = "colsInternalLedgerDb";
            this.colsInternalLedgerDb.NamedProperties.Put("EnumerateMethod", "");
            this.colsInternalLedgerDb.NamedProperties.Put("FieldFlags", "288");
            this.colsInternalLedgerDb.NamedProperties.Put("LovReference", "");
            this.colsInternalLedgerDb.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsInternalLedgerDb.NamedProperties.Put("SqlColumn", "INTERNAL_LEDGER_DB");
            this.colsInternalLedgerDb.Position = 6;
            resources.ApplyResources(this.colsInternalLedgerDb, "colsInternalLedgerDb");
            // 
            // tbwAuditSource
            // 
            resources.ApplyResources(this, "$this");
            this.ContextMenuStrip = this.menuTbwMethods;
            this.Controls.Add(this.colsAuditSource);
            this.Controls.Add(this.colsDescription);
            this.Controls.Add(this.colsInternalLedgerDb);
            this.Controls.Add(this.colsSourceType);
            this.Controls.Add(this.colsSystemDefinedDb);
            this.Name = "tbwAuditSource";
            this.NamedProperties.Put("LogicalUnit", "AuditSource");
            this.NamedProperties.Put("PackageName", "AUDIT_SOURCE_API");
            this.NamedProperties.Put("SourceFlags", "16832");
            this.NamedProperties.Put("ViewName", "AUDIT_SOURCE");
            this.Controls.SetChildIndex(this.colsSystemDefinedDb, 0);
            this.Controls.SetChildIndex(this.colsSourceType, 0);
            this.Controls.SetChildIndex(this.colsInternalLedgerDb, 0);
            this.Controls.SetChildIndex(this.colsDescription, 0);
            this.Controls.SetChildIndex(this.colsAuditSource, 0);
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

        protected cColumn colsAuditSource;
        protected cColumn colsDescription;
        protected cLookupColumn colsSourceType;
        protected cCheckBoxColumn colsSystemDefinedDb;
        protected Fnd.Windows.Forms.FndCommand Columns;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTbwMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItemColumns;
        protected cCheckBoxColumn colsInternalLedgerDb;
    }
}
