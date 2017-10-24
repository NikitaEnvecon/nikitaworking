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

    public partial class frmAuditSourceColumn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAuditSourceColumn));
            this.cChildTableDetail = new Ifs.Fnd.ApplicationForms.cChildTable();
            this.cChildTableDetail_colsAuditSource = new Ifs.Fnd.ApplicationForms.cColumn();
            this.cChildTableDetail_colsSourceColumn = new Ifs.Fnd.ApplicationForms.cColumn();
            this.cChildTableDetail_colsDatatype = new Ifs.Fnd.ApplicationForms.cColumn();
            this.cChildTableDetail_colnPrecision = new Ifs.Fnd.ApplicationForms.cColumn();
            this.cChildTableDetail_colsSelectionDateDb = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.labelAuditSource = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsDescription = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelDescription = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfAuditSource = new Ifs.Fnd.ApplicationForms.cRecListDataField();
            this.cChildTableDetail_colsSelectionDateTitle = new Ifs.Fnd.ApplicationForms.cColumn();
            this.cmdTranslate = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTblMetod = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.MenuItemTranslate = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.cChildTableDetail.SuspendLayout();
            this.menuTblMetod.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.cmdTranslate);
            this.commandManager.ContextMenus.Add(this.menuTblMetod);
            // 
            // cChildTableDetail
            // 
            this.cChildTableDetail.ContextMenuStrip = this.menuTblMetod;
            this.cChildTableDetail.Controls.Add(this.cChildTableDetail_colsAuditSource);
            this.cChildTableDetail.Controls.Add(this.cChildTableDetail_colsSourceColumn);
            this.cChildTableDetail.Controls.Add(this.cChildTableDetail_colsDatatype);
            this.cChildTableDetail.Controls.Add(this.cChildTableDetail_colnPrecision);
            this.cChildTableDetail.Controls.Add(this.cChildTableDetail_colsSelectionDateTitle);
            this.cChildTableDetail.Controls.Add(this.cChildTableDetail_colsSelectionDateDb);
            resources.ApplyResources(this.cChildTableDetail, "cChildTableDetail");
            this.cChildTableDetail.Name = "cChildTableDetail";
            this.cChildTableDetail.NamedProperties.Put("LogicalUnit", "AuditSourceColumn");
            this.cChildTableDetail.NamedProperties.Put("PackageName", "AUDIT_SOURCE_COLUMN_API");
            this.cChildTableDetail.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.cChildTableDetail.NamedProperties.Put("ResizeableChildObject", "MLMM");
            this.cChildTableDetail.NamedProperties.Put("SourceFlags", "448");
            this.cChildTableDetail.NamedProperties.Put("ViewName", "AUDIT_SOURCE_COLUMN");
            // 
            // cChildTableDetail_colsAuditSource
            // 
            this.cChildTableDetail_colsAuditSource.Name = "cChildTableDetail_colsAuditSource";
            this.cChildTableDetail_colsAuditSource.NamedProperties.Put("EnumerateMethod", "");
            this.cChildTableDetail_colsAuditSource.NamedProperties.Put("FieldFlags", "96");
            this.cChildTableDetail_colsAuditSource.NamedProperties.Put("LovReference", "AUDIT_SOURCE");
            this.cChildTableDetail_colsAuditSource.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.cChildTableDetail_colsAuditSource.NamedProperties.Put("SqlColumn", "AUDIT_SOURCE");
            this.cChildTableDetail_colsAuditSource.Position = 3;
            resources.ApplyResources(this.cChildTableDetail_colsAuditSource, "cChildTableDetail_colsAuditSource");
            // 
            // cChildTableDetail_colsSourceColumn
            // 
            this.cChildTableDetail_colsSourceColumn.MaxLength = 30;
            this.cChildTableDetail_colsSourceColumn.Name = "cChildTableDetail_colsSourceColumn";
            this.cChildTableDetail_colsSourceColumn.NamedProperties.Put("EnumerateMethod", "");
            this.cChildTableDetail_colsSourceColumn.NamedProperties.Put("FieldFlags", "163");
            this.cChildTableDetail_colsSourceColumn.NamedProperties.Put("LovReference", "");
            this.cChildTableDetail_colsSourceColumn.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.cChildTableDetail_colsSourceColumn.NamedProperties.Put("SqlColumn", "SOURCE_COLUMN");
            this.cChildTableDetail_colsSourceColumn.Position = 4;
            resources.ApplyResources(this.cChildTableDetail_colsSourceColumn, "cChildTableDetail_colsSourceColumn");
            // 
            // cChildTableDetail_colsDatatype
            // 
            this.cChildTableDetail_colsDatatype.MaxLength = 200;
            this.cChildTableDetail_colsDatatype.Name = "cChildTableDetail_colsDatatype";
            this.cChildTableDetail_colsDatatype.NamedProperties.Put("EnumerateMethod", "");
            this.cChildTableDetail_colsDatatype.NamedProperties.Put("FieldFlags", "294");
            this.cChildTableDetail_colsDatatype.NamedProperties.Put("LovReference", "");
            this.cChildTableDetail_colsDatatype.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.cChildTableDetail_colsDatatype.NamedProperties.Put("SqlColumn", "DATATYPE");
            this.cChildTableDetail_colsDatatype.Position = 5;
            resources.ApplyResources(this.cChildTableDetail_colsDatatype, "cChildTableDetail_colsDatatype");
            // 
            // cChildTableDetail_colnPrecision
            // 
            this.cChildTableDetail_colnPrecision.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.cChildTableDetail_colnPrecision.Name = "cChildTableDetail_colnPrecision";
            this.cChildTableDetail_colnPrecision.NamedProperties.Put("EnumerateMethod", "");
            this.cChildTableDetail_colnPrecision.NamedProperties.Put("FieldFlags", "294");
            this.cChildTableDetail_colnPrecision.NamedProperties.Put("Format", "");
            this.cChildTableDetail_colnPrecision.NamedProperties.Put("LovReference", "");
            this.cChildTableDetail_colnPrecision.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.cChildTableDetail_colnPrecision.NamedProperties.Put("SqlColumn", "PRECISION");
            this.cChildTableDetail_colnPrecision.Position = 6;
            this.cChildTableDetail_colnPrecision.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.cChildTableDetail_colnPrecision, "cChildTableDetail_colnPrecision");
            // 
            // cChildTableDetail_colsSelectionDateDb
            // 
            this.cChildTableDetail_colsSelectionDateDb.MaxLength = 20;
            this.cChildTableDetail_colsSelectionDateDb.Name = "cChildTableDetail_colsSelectionDateDb";
            this.cChildTableDetail_colsSelectionDateDb.NamedProperties.Put("EnumerateMethod", "");
            this.cChildTableDetail_colsSelectionDateDb.NamedProperties.Put("FieldFlags", "288");
            this.cChildTableDetail_colsSelectionDateDb.NamedProperties.Put("LovReference", "");
            this.cChildTableDetail_colsSelectionDateDb.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.cChildTableDetail_colsSelectionDateDb.NamedProperties.Put("SqlColumn", "SELECTION_DATE_DB");
            this.cChildTableDetail_colsSelectionDateDb.Position = 7;
            resources.ApplyResources(this.cChildTableDetail_colsSelectionDateDb, "cChildTableDetail_colsSelectionDateDb");
            // 
            // labelAuditSource
            // 
            resources.ApplyResources(this.labelAuditSource, "labelAuditSource");
            this.labelAuditSource.Name = "labelAuditSource";
            // 
            // dfsDescription
            // 
            resources.ApplyResources(this.dfsDescription, "dfsDescription");
            this.dfsDescription.Name = "dfsDescription";
            this.dfsDescription.NamedProperties.Put("EnumerateMethod", "");
            this.dfsDescription.NamedProperties.Put("FieldFlags", "295");
            this.dfsDescription.NamedProperties.Put("LovReference", "");
            this.dfsDescription.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.dfsDescription.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            // 
            // labelDescription
            // 
            resources.ApplyResources(this.labelDescription, "labelDescription");
            this.labelDescription.Name = "labelDescription";
            // 
            // dfAuditSource
            // 
            resources.ApplyResources(this.dfAuditSource, "dfAuditSource");
            this.dfAuditSource.Name = "dfAuditSource";
            this.dfAuditSource.NamedProperties.Put("DataType", "5");
            this.dfAuditSource.NamedProperties.Put("EnumerateMethod", "");
            this.dfAuditSource.NamedProperties.Put("FieldFlags", "163");
            this.dfAuditSource.NamedProperties.Put("Format", "0");
            this.dfAuditSource.NamedProperties.Put("LovReference", "");
            this.dfAuditSource.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.dfAuditSource.NamedProperties.Put("SqlColumn", "AUDIT_SOURCE");
            // 
            // cChildTableDetail_colsSelectionDateTitle
            // 
            this.cChildTableDetail_colsSelectionDateTitle.MaxLength = 50;
            this.cChildTableDetail_colsSelectionDateTitle.Name = "cChildTableDetail_colsSelectionDateTitle";
            this.cChildTableDetail_colsSelectionDateTitle.NamedProperties.Put("EnumerateMethod", "");
            this.cChildTableDetail_colsSelectionDateTitle.NamedProperties.Put("FieldFlags", "294");
            this.cChildTableDetail_colsSelectionDateTitle.NamedProperties.Put("LovReference", "");
            this.cChildTableDetail_colsSelectionDateTitle.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.cChildTableDetail_colsSelectionDateTitle.NamedProperties.Put("SqlColumn", "SELECTION_DATE_TITLE");
            this.cChildTableDetail_colsSelectionDateTitle.Position = 8;
            resources.ApplyResources(this.cChildTableDetail_colsSelectionDateTitle, "cChildTableDetail_colsSelectionDateTitle");
            // 
            // cmdTranslate
            // 
            resources.ApplyResources(this.cmdTranslate, "cmdTranslate");
            this.cmdTranslate.Name = "cmdTranslate";
            this.cmdTranslate.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.cmdTranslate_Execute);
            this.cmdTranslate.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.cmdTranslate_Inquire);
            // 
            // menuTblMetod
            // 
            this.menuTblMetod.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemTranslate});
            this.menuTblMetod.Name = "menuTblMetod";
            resources.ApplyResources(this.menuTblMetod, "menuTblMetod");
            // 
            // MenuItemTranslate
            // 
            this.MenuItemTranslate.Command = this.cmdTranslate;
            this.MenuItemTranslate.Name = "MenuItemTranslate";
            resources.ApplyResources(this.MenuItemTranslate, "MenuItemTranslate");
            this.MenuItemTranslate.Text = "Translation...";
            // 
            // frmAuditSourceColumn
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.dfAuditSource);
            this.Controls.Add(this.dfsDescription);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.labelAuditSource);
            this.Controls.Add(this.cChildTableDetail);
            this.Name = "frmAuditSourceColumn";
            this.NamedProperties.Put("LogicalUnit", "AuditSource");
            this.NamedProperties.Put("Module", "");
            this.NamedProperties.Put("PackageName", "AUDIT_SOURCE_API");
            this.NamedProperties.Put("SourceFlags", "448");
            this.NamedProperties.Put("ViewName", "AUDIT_SOURCE");
            this.cChildTableDetail.ResumeLayout(false);
            this.menuTblMetod.ResumeLayout(false);
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
        protected cBackgroundText labelAuditSource;
        protected cDataField dfsDescription;
        protected cBackgroundText labelDescription;
        protected cRecListDataField dfAuditSource;
        protected cColumn cChildTableDetail_colsAuditSource;
        protected cColumn cChildTableDetail_colsSourceColumn;
        protected cColumn cChildTableDetail_colnPrecision;
        protected cCheckBoxColumn cChildTableDetail_colsSelectionDateDb;
        protected cColumn cChildTableDetail_colsDatatype;
        protected cColumn cChildTableDetail_colsSelectionDateTitle;
        protected Fnd.Windows.Forms.FndCommand cmdTranslate;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTblMetod;
        protected Fnd.Windows.Forms.FndToolStripMenuItem MenuItemTranslate;
    }
}
