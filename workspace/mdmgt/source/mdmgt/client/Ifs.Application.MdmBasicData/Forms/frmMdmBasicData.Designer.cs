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

namespace Ifs.Application.MdmBasicData
{

    public partial class frmMdmBasicData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMdmBasicData));
            this.dfnRevision = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelRevision = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsDescription = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelDescription = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsCreatedBy = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelCreatedBy = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfdCreatedDate = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelCreatedDate = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsState = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelState = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmdActive = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.cmdReOpen = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.cmdCreateRevision = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.contextMenu = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.tsMenuItemActive = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.tsMenuItemReOpen = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.tsMenuItemCreateRevision = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.dfsProfileId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelProfileId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.ecmbTemplateId = new Ifs.Fnd.ApplicationForms.cRecListDataField();
            this.labelTemplateId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // _cTabManager
            // 
            resources.ApplyResources(this._cTabManager, "_cTabManager");
            // 
            // picTab
            // 
            resources.ApplyResources(this.picTab, "picTab");
            this.picTab.SelectedIndex = 1;
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.cmdActive);
            this.commandManager.Commands.Add(this.cmdReOpen);
            this.commandManager.Commands.Add(this.cmdCreateRevision);
            this.commandManager.ContextMenus.Add(this.contextMenu);
            this.commandManager.ImageList = null;
            // 
            // dfnRevision
            // 
            this.dfnRevision.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfnRevision, "dfnRevision");
            this.dfnRevision.Name = "dfnRevision";
            this.dfnRevision.NamedProperties.Put("EnumerateMethod", "");
            this.dfnRevision.NamedProperties.Put("FieldFlags", "291");
            this.dfnRevision.NamedProperties.Put("Format", "");
            this.dfnRevision.NamedProperties.Put("LovReference", "");
            this.dfnRevision.NamedProperties.Put("ParentName", "ecmbTemplateId");
            this.dfnRevision.NamedProperties.Put("SqlColumn", "REVISION");
            // 
            // labelRevision
            // 
            resources.ApplyResources(this.labelRevision, "labelRevision");
            this.labelRevision.Name = "labelRevision";
            // 
            // dfsDescription
            // 
            resources.ApplyResources(this.dfsDescription, "dfsDescription");
            this.dfsDescription.Name = "dfsDescription";
            this.dfsDescription.NamedProperties.Put("EnumerateMethod", "");
            this.dfsDescription.NamedProperties.Put("FieldFlags", "295");
            this.dfsDescription.NamedProperties.Put("LovReference", "");
            this.dfsDescription.NamedProperties.Put("ParentName", "ecmbTemplateId");
            this.dfsDescription.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            // 
            // labelDescription
            // 
            resources.ApplyResources(this.labelDescription, "labelDescription");
            this.labelDescription.Name = "labelDescription";
            // 
            // dfsCreatedBy
            // 
            resources.ApplyResources(this.dfsCreatedBy, "dfsCreatedBy");
            this.dfsCreatedBy.Name = "dfsCreatedBy";
            this.dfsCreatedBy.NamedProperties.Put("EnumerateMethod", "");
            this.dfsCreatedBy.NamedProperties.Put("FieldFlags", "291");
            this.dfsCreatedBy.NamedProperties.Put("LovReference", "");
            this.dfsCreatedBy.NamedProperties.Put("SqlColumn", "CREATED_BY");
            // 
            // labelCreatedBy
            // 
            resources.ApplyResources(this.labelCreatedBy, "labelCreatedBy");
            this.labelCreatedBy.Name = "labelCreatedBy";
            // 
            // dfdCreatedDate
            // 
            this.dfdCreatedDate.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.dfdCreatedDate.Format = "d";
            resources.ApplyResources(this.dfdCreatedDate, "dfdCreatedDate");
            this.dfdCreatedDate.Name = "dfdCreatedDate";
            this.dfdCreatedDate.NamedProperties.Put("EnumerateMethod", "");
            this.dfdCreatedDate.NamedProperties.Put("FieldFlags", "291");
            this.dfdCreatedDate.NamedProperties.Put("LovReference", "");
            this.dfdCreatedDate.NamedProperties.Put("SqlColumn", "CREATED_DATE");
            // 
            // labelCreatedDate
            // 
            resources.ApplyResources(this.labelCreatedDate, "labelCreatedDate");
            this.labelCreatedDate.Name = "labelCreatedDate";
            // 
            // dfsState
            // 
            resources.ApplyResources(this.dfsState, "dfsState");
            this.dfsState.Name = "dfsState";
            this.dfsState.NamedProperties.Put("EnumerateMethod", "");
            this.dfsState.NamedProperties.Put("FieldFlags", "288");
            this.dfsState.NamedProperties.Put("LovReference", "");
            this.dfsState.NamedProperties.Put("ParentName", "ecmbTemplateId");
            this.dfsState.NamedProperties.Put("SqlColumn", "STATE");
            // 
            // labelState
            // 
            resources.ApplyResources(this.labelState, "labelState");
            this.labelState.Name = "labelState";
            // 
            // cmdActive
            // 
            resources.ApplyResources(this.cmdActive, "cmdActive");
            this.cmdActive.Name = "cmdActive";
            this.cmdActive.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.cmdActive_Execute);
            this.cmdActive.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.cmdActive_Inquire);
            // 
            // cmdReOpen
            // 
            resources.ApplyResources(this.cmdReOpen, "cmdReOpen");
            this.cmdReOpen.Name = "cmdReOpen";
            this.cmdReOpen.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.cmdReOpen_Execute);
            this.cmdReOpen.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.cmdReOpen_Inquire);
            // 
            // cmdCreateRevision
            // 
            resources.ApplyResources(this.cmdCreateRevision, "cmdCreateRevision");
            this.cmdCreateRevision.Name = "cmdCreateRevision";
            this.cmdCreateRevision.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.cmdCreateRevision_Execute);
            this.cmdCreateRevision.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.cmdCreateRevision_Inquire);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMenuItemActive,
            this.tsMenuItemReOpen,
            this.tsMenuItemCreateRevision});
            this.contextMenu.Name = "contextMenu";
            resources.ApplyResources(this.contextMenu, "contextMenu");
            // 
            // tsMenuItemActive
            // 
            this.tsMenuItemActive.Command = this.cmdActive;
            this.tsMenuItemActive.Name = "tsMenuItemActive";
            resources.ApplyResources(this.tsMenuItemActive, "tsMenuItemActive");
            this.tsMenuItemActive.Text = "Active";
            // 
            // tsMenuItemReOpen
            // 
            this.tsMenuItemReOpen.Command = this.cmdReOpen;
            this.tsMenuItemReOpen.Name = "tsMenuItemReOpen";
            resources.ApplyResources(this.tsMenuItemReOpen, "tsMenuItemReOpen");
            this.tsMenuItemReOpen.Text = "Reopen";
            // 
            // tsMenuItemCreateRevision
            // 
            this.tsMenuItemCreateRevision.Command = this.cmdCreateRevision;
            this.tsMenuItemCreateRevision.Name = "tsMenuItemCreateRevision";
            resources.ApplyResources(this.tsMenuItemCreateRevision, "tsMenuItemCreateRevision");
            this.tsMenuItemCreateRevision.Text = "Create Revision";
            // 
            // dfsProfileId
            // 
            resources.ApplyResources(this.dfsProfileId, "dfsProfileId");
            this.dfsProfileId.Name = "dfsProfileId";
            this.dfsProfileId.NamedProperties.Put("EnumerateMethod", "");
            this.dfsProfileId.NamedProperties.Put("FieldFlags", "294");
            this.dfsProfileId.NamedProperties.Put("LovReference", "APPROVAL_PROFILE");
            this.dfsProfileId.NamedProperties.Put("SqlColumn", "PROFILE_ID");
            // 
            // labelProfileId
            // 
            resources.ApplyResources(this.labelProfileId, "labelProfileId");
            this.labelProfileId.Name = "labelProfileId";
            // 
            // ecmbTemplateId
            // 
            this.ecmbTemplateId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.ecmbTemplateId, "ecmbTemplateId");
            this.ecmbTemplateId.Name = "ecmbTemplateId";
            this.ecmbTemplateId.NamedProperties.Put("EnumerateMethod", "");
            this.ecmbTemplateId.NamedProperties.Put("FieldFlags", "162");
            this.ecmbTemplateId.NamedProperties.Put("LovReference", "");
            this.ecmbTemplateId.NamedProperties.Put("SqlColumn", "TEMPLATE_ID");
            this.ecmbTemplateId.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.ecmbTemplateId_WindowActions);
            // 
            // labelTemplateId
            // 
            resources.ApplyResources(this.labelTemplateId, "labelTemplateId");
            this.labelTemplateId.Name = "labelTemplateId";
            // 
            // frmMdmBasicData
            // 
            resources.ApplyResources(this, "$this");
            this.ContextMenuStrip = this.contextMenu;
            this.Controls.Add(this.ecmbTemplateId);
            this.Controls.Add(this.labelTemplateId);
            this.Controls.Add(this.dfsProfileId);
            this.Controls.Add(this.labelProfileId);
            this.Controls.Add(this.dfsState);
            this.Controls.Add(this.labelState);
            this.Controls.Add(this.dfdCreatedDate);
            this.Controls.Add(this.labelCreatedDate);
            this.Controls.Add(this.dfsCreatedBy);
            this.Controls.Add(this.labelCreatedBy);
            this.Controls.Add(this.dfsDescription);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.dfnRevision);
            this.Controls.Add(this.labelRevision);
            this.Name = "frmMdmBasicData";
            this.NamedProperties.Put("LogicalUnit", "MdmBasicDataHeader");
            this.NamedProperties.Put("Module", "MDMGT");
            this.NamedProperties.Put("PackageName", "MDM_BASIC_DATA_HEADER_API");
            this.NamedProperties.Put("SourceFlags", "4545");
            this.NamedProperties.Put("ViewName", "MDM_BASIC_DATA_HEADER");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.frmMdmBasicData_WindowActions);
            this.Controls.SetChildIndex(this.picTab, 0);
            this.Controls.SetChildIndex(this.labelRevision, 0);
            this.Controls.SetChildIndex(this.dfnRevision, 0);
            this.Controls.SetChildIndex(this.labelDescription, 0);
            this.Controls.SetChildIndex(this.dfsDescription, 0);
            this.Controls.SetChildIndex(this.labelCreatedBy, 0);
            this.Controls.SetChildIndex(this.dfsCreatedBy, 0);
            this.Controls.SetChildIndex(this.labelCreatedDate, 0);
            this.Controls.SetChildIndex(this.dfdCreatedDate, 0);
            this.Controls.SetChildIndex(this.labelState, 0);
            this.Controls.SetChildIndex(this.dfsState, 0);
            this.Controls.SetChildIndex(this.labelProfileId, 0);
            this.Controls.SetChildIndex(this.dfsProfileId, 0);
            this.Controls.SetChildIndex(this.labelTemplateId, 0);
            this.Controls.SetChildIndex(this.ecmbTemplateId, 0);
            this.contextMenu.ResumeLayout(false);
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

        protected cDataField dfnRevision;
        protected cBackgroundText labelRevision;
        protected cDataField dfsDescription;
        protected cBackgroundText labelDescription;
        protected cDataField dfsCreatedBy;
        protected cBackgroundText labelCreatedBy;
        protected cDataField dfdCreatedDate;
        protected cBackgroundText labelCreatedDate;
        protected cDataField dfsState;
        protected cBackgroundText labelState;
        protected Fnd.Windows.Forms.FndCommand cmdActive;
        protected Fnd.Windows.Forms.FndCommand cmdReOpen;
        protected Fnd.Windows.Forms.FndCommand cmdCreateRevision;
        protected Fnd.Windows.Forms.FndContextMenuStrip contextMenu;
        protected Fnd.Windows.Forms.FndToolStripMenuItem tsMenuItemActive;
        protected Fnd.Windows.Forms.FndToolStripMenuItem tsMenuItemReOpen;
        protected Fnd.Windows.Forms.FndToolStripMenuItem tsMenuItemCreateRevision;
        protected cDataField dfsProfileId;
        protected cBackgroundText labelProfileId;
        protected cRecListDataField ecmbTemplateId;
        protected cBackgroundText labelTemplateId;
    }
}
