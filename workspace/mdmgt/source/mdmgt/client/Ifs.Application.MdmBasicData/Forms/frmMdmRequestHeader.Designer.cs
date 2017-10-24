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

    public partial class frmMdmRequestHeader
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMdmRequestHeader));
            this.dfsDescription = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelDescription = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsTemplateId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelTemplateId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsRequestedBy = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelRequestedBy = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfdRequestedDate = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelRequestedDate = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cbApprovalRequired = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.cbApprovalRejected = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.dfnRevision = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelRevision = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsState = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelState = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmdReleased = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.cmdCompleted = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.cmdCancelled = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.contextMenu = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.tsMenuItem = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.tsMenuItem1 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.tsMenuItem2 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.dfnRequestNo = new Ifs.Fnd.ApplicationForms.cRecListDataField();
            this.labelRequestNo = new Ifs.Fnd.ApplicationForms.cBackgroundText();
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
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.cmdReleased);
            this.commandManager.Commands.Add(this.cmdCompleted);
            this.commandManager.Commands.Add(this.cmdCancelled);
            this.commandManager.ContextMenus.Add(this.contextMenu);
            // 
            // dfsDescription
            // 
            resources.ApplyResources(this.dfsDescription, "dfsDescription");
            this.dfsDescription.Name = "dfsDescription";
            this.dfsDescription.NamedProperties.Put("EnumerateMethod", "");
            this.dfsDescription.NamedProperties.Put("FieldFlags", "295");
            this.dfsDescription.NamedProperties.Put("LovReference", "");
            this.dfsDescription.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            // 
            // labelDescription
            // 
            resources.ApplyResources(this.labelDescription, "labelDescription");
            this.labelDescription.Name = "labelDescription";
            // 
            // dfsTemplateId
            // 
            this.dfsTemplateId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsTemplateId, "dfsTemplateId");
            this.dfsTemplateId.Name = "dfsTemplateId";
            this.dfsTemplateId.NamedProperties.Put("EnumerateMethod", "");
            this.dfsTemplateId.NamedProperties.Put("FieldFlags", "99");
            this.dfsTemplateId.NamedProperties.Put("LovReference", "MDM_BASIC_DATA_HEADER(TEMPLATE_ID)");
            this.dfsTemplateId.NamedProperties.Put("ParentName", "dfnRequestNo");
            this.dfsTemplateId.NamedProperties.Put("SqlColumn", "TEMPLATE_ID");
            // 
            // labelTemplateId
            // 
            resources.ApplyResources(this.labelTemplateId, "labelTemplateId");
            this.labelTemplateId.Name = "labelTemplateId";
            // 
            // dfsRequestedBy
            // 
            resources.ApplyResources(this.dfsRequestedBy, "dfsRequestedBy");
            this.dfsRequestedBy.Name = "dfsRequestedBy";
            this.dfsRequestedBy.NamedProperties.Put("EnumerateMethod", "");
            this.dfsRequestedBy.NamedProperties.Put("FieldFlags", "295");
            this.dfsRequestedBy.NamedProperties.Put("LovReference", "");
            this.dfsRequestedBy.NamedProperties.Put("SqlColumn", "REQUESTED_BY");
            // 
            // labelRequestedBy
            // 
            resources.ApplyResources(this.labelRequestedBy, "labelRequestedBy");
            this.labelRequestedBy.Name = "labelRequestedBy";
            // 
            // dfdRequestedDate
            // 
            this.dfdRequestedDate.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.dfdRequestedDate.Format = "d";
            resources.ApplyResources(this.dfdRequestedDate, "dfdRequestedDate");
            this.dfdRequestedDate.Name = "dfdRequestedDate";
            this.dfdRequestedDate.NamedProperties.Put("EnumerateMethod", "");
            this.dfdRequestedDate.NamedProperties.Put("FieldFlags", "295");
            this.dfdRequestedDate.NamedProperties.Put("LovReference", "");
            this.dfdRequestedDate.NamedProperties.Put("SqlColumn", "REQUESTED_DATE");
            this.dfdRequestedDate.TextChanged += new System.EventHandler(this.dfdRequestedDate_TextChanged);
            // 
            // labelRequestedDate
            // 
            resources.ApplyResources(this.labelRequestedDate, "labelRequestedDate");
            this.labelRequestedDate.Name = "labelRequestedDate";
            // 
            // cbApprovalRequired
            // 
            resources.ApplyResources(this.cbApprovalRequired, "cbApprovalRequired");
            this.cbApprovalRequired.Name = "cbApprovalRequired";
            this.cbApprovalRequired.NamedProperties.Put("EnumerateMethod", "");
            this.cbApprovalRequired.NamedProperties.Put("FieldFlags", "294");
            this.cbApprovalRequired.NamedProperties.Put("LovReference", "");
            this.cbApprovalRequired.NamedProperties.Put("SqlColumn", "APPROVAL_REQUIRED");
            // 
            // cbApprovalRejected
            // 
            resources.ApplyResources(this.cbApprovalRejected, "cbApprovalRejected");
            this.cbApprovalRejected.Name = "cbApprovalRejected";
            this.cbApprovalRejected.NamedProperties.Put("EnumerateMethod", "");
            this.cbApprovalRejected.NamedProperties.Put("FieldFlags", "294");
            this.cbApprovalRejected.NamedProperties.Put("LovReference", "");
            this.cbApprovalRejected.NamedProperties.Put("SqlColumn", "APPROVAL_REJECTED");
            // 
            // dfnRevision
            // 
            this.dfnRevision.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfnRevision, "dfnRevision");
            this.dfnRevision.Name = "dfnRevision";
            this.dfnRevision.NamedProperties.Put("EnumerateMethod", "");
            this.dfnRevision.NamedProperties.Put("FieldFlags", "99");
            this.dfnRevision.NamedProperties.Put("Format", "");
            this.dfnRevision.NamedProperties.Put("LovReference", "MDM_BASIC_DATA_HEADER(TEMPLATE_ID)");
            this.dfnRevision.NamedProperties.Put("ParentName", "dfnRequestNo");
            this.dfnRevision.NamedProperties.Put("SqlColumn", "REVISION");
            // 
            // labelRevision
            // 
            resources.ApplyResources(this.labelRevision, "labelRevision");
            this.labelRevision.Name = "labelRevision";
            // 
            // dfsState
            // 
            resources.ApplyResources(this.dfsState, "dfsState");
            this.dfsState.Name = "dfsState";
            this.dfsState.NamedProperties.Put("EnumerateMethod", "");
            this.dfsState.NamedProperties.Put("FieldFlags", "288");
            this.dfsState.NamedProperties.Put("LovReference", "");
            this.dfsState.NamedProperties.Put("SqlColumn", "STATE");
            // 
            // labelState
            // 
            resources.ApplyResources(this.labelState, "labelState");
            this.labelState.Name = "labelState";
            // 
            // cmdReleased
            // 
            resources.ApplyResources(this.cmdReleased, "cmdReleased");
            this.cmdReleased.Name = "cmdReleased";
            this.cmdReleased.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.cmdReleased_Execute);
            this.cmdReleased.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.cmdReleased_Inquire);
            // 
            // cmdCompleted
            // 
            resources.ApplyResources(this.cmdCompleted, "cmdCompleted");
            this.cmdCompleted.Name = "cmdCompleted";
            this.cmdCompleted.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.cmdCompleted_Execute);
            this.cmdCompleted.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.cmdCompleted_Inquire);
            // 
            // cmdCancelled
            // 
            resources.ApplyResources(this.cmdCancelled, "cmdCancelled");
            this.cmdCancelled.Name = "cmdCancelled";
            this.cmdCancelled.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.cmdCancelled_Execute);
            this.cmdCancelled.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.cmdCancelled_Inquire);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMenuItem,
            this.tsMenuItem1,
            this.tsMenuItem2});
            this.contextMenu.Name = "contextMenu";
            resources.ApplyResources(this.contextMenu, "contextMenu");
            // 
            // tsMenuItem
            // 
            this.tsMenuItem.Command = this.cmdReleased;
            this.tsMenuItem.Name = "tsMenuItem";
            resources.ApplyResources(this.tsMenuItem, "tsMenuItem");
            this.tsMenuItem.Text = "Released";
            // 
            // tsMenuItem1
            // 
            this.tsMenuItem1.Command = this.cmdCompleted;
            this.tsMenuItem1.Name = "tsMenuItem1";
            resources.ApplyResources(this.tsMenuItem1, "tsMenuItem1");
            this.tsMenuItem1.Text = "Completed";
            // 
            // tsMenuItem2
            // 
            this.tsMenuItem2.Command = this.cmdCancelled;
            this.tsMenuItem2.Name = "tsMenuItem2";
            resources.ApplyResources(this.tsMenuItem2, "tsMenuItem2");
            this.tsMenuItem2.Text = "Cancelled";
            // 
            // dfnRequestNo
            // 
            resources.ApplyResources(this.dfnRequestNo, "dfnRequestNo");
            this.dfnRequestNo.Name = "dfnRequestNo";
            this.dfnRequestNo.NamedProperties.Put("DataType", "3");
            this.dfnRequestNo.NamedProperties.Put("EnumerateMethod", "");
            this.dfnRequestNo.NamedProperties.Put("FieldFlags", "163");
            this.dfnRequestNo.NamedProperties.Put("Format", "");
            this.dfnRequestNo.NamedProperties.Put("LovReference", "");
            this.dfnRequestNo.NamedProperties.Put("SqlColumn", "REQUEST_NO");
            this.dfnRequestNo.TextChanged += new System.EventHandler(this.dfnRequestNo_TextChanged);
            // 
            // labelRequestNo
            // 
            resources.ApplyResources(this.labelRequestNo, "labelRequestNo");
            this.labelRequestNo.Name = "labelRequestNo";
            // 
            // frmMdmRequestHeader
            // 
            resources.ApplyResources(this, "$this");
            this.ContextMenuStrip = this.contextMenu;
            this.Controls.Add(this.dfnRequestNo);
            this.Controls.Add(this.labelRequestNo);
            this.Controls.Add(this.dfsState);
            this.Controls.Add(this.labelState);
            this.Controls.Add(this.dfnRevision);
            this.Controls.Add(this.labelRevision);
            this.Controls.Add(this.cbApprovalRejected);
            this.Controls.Add(this.cbApprovalRequired);
            this.Controls.Add(this.dfdRequestedDate);
            this.Controls.Add(this.labelRequestedDate);
            this.Controls.Add(this.dfsRequestedBy);
            this.Controls.Add(this.labelRequestedBy);
            this.Controls.Add(this.dfsTemplateId);
            this.Controls.Add(this.labelTemplateId);
            this.Controls.Add(this.dfsDescription);
            this.Controls.Add(this.labelDescription);
            this.Name = "frmMdmRequestHeader";
            this.NamedProperties.Put("LogicalUnit", "MdmRequestHeader");
            this.NamedProperties.Put("Module", "MDMGT");
            this.NamedProperties.Put("PackageName", "MDM_REQUEST_HEADER_API");
            this.NamedProperties.Put("SourceFlags", "4545");
            this.NamedProperties.Put("ViewName", "MDM_REQUEST_HEADER");
            this.Controls.SetChildIndex(this.picTab, 0);
            this.Controls.SetChildIndex(this.labelDescription, 0);
            this.Controls.SetChildIndex(this.dfsDescription, 0);
            this.Controls.SetChildIndex(this.labelTemplateId, 0);
            this.Controls.SetChildIndex(this.dfsTemplateId, 0);
            this.Controls.SetChildIndex(this.labelRequestedBy, 0);
            this.Controls.SetChildIndex(this.dfsRequestedBy, 0);
            this.Controls.SetChildIndex(this.labelRequestedDate, 0);
            this.Controls.SetChildIndex(this.dfdRequestedDate, 0);
            this.Controls.SetChildIndex(this.cbApprovalRequired, 0);
            this.Controls.SetChildIndex(this.cbApprovalRejected, 0);
            this.Controls.SetChildIndex(this.labelRevision, 0);
            this.Controls.SetChildIndex(this.dfnRevision, 0);
            this.Controls.SetChildIndex(this.labelState, 0);
            this.Controls.SetChildIndex(this.dfsState, 0);
            this.Controls.SetChildIndex(this.labelRequestNo, 0);
            this.Controls.SetChildIndex(this.dfnRequestNo, 0);
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

        protected cDataField dfsDescription;
        protected cBackgroundText labelDescription;
        protected cDataField dfsTemplateId;
        protected cBackgroundText labelTemplateId;
        protected cDataField dfsRequestedBy;
        protected cBackgroundText labelRequestedBy;
        protected cDataField dfdRequestedDate;
        protected cBackgroundText labelRequestedDate;
        protected cCheckBox cbApprovalRequired;
        protected cCheckBox cbApprovalRejected;
        protected cDataField dfnRevision;
        protected cBackgroundText labelRevision;
        protected cDataField dfsState;
        protected cBackgroundText labelState;
        protected Fnd.Windows.Forms.FndCommand cmdReleased;
        protected Fnd.Windows.Forms.FndCommand cmdCompleted;
        protected Fnd.Windows.Forms.FndCommand cmdCancelled;
        protected Fnd.Windows.Forms.FndContextMenuStrip contextMenu;
        protected Fnd.Windows.Forms.FndToolStripMenuItem tsMenuItem;
        protected Fnd.Windows.Forms.FndToolStripMenuItem tsMenuItem1;
        protected Fnd.Windows.Forms.FndToolStripMenuItem tsMenuItem2;
        protected cRecListDataField dfnRequestNo;
        protected cBackgroundText labelRequestNo;
    }
}
