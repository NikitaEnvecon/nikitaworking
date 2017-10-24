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

    public partial class frmFooterField
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFooterField));
            this.lableFiledId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.lableHeaderText = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cHeaderText = new Ifs.Fnd.ApplicationForms.cDataField();
            this.cbSystemDefined = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.cbFreeText = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.dfCompany = new Ifs.Fnd.ApplicationForms.cDataField();
            this.mlFooterText = new Ifs.Fnd.ApplicationForms.cMultilineField();
            this.cmbFieldId = new Ifs.Fnd.ApplicationForms.cRecSelComboBox();
            this.contextMenu = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.tsMenuItem = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.cmdTranslateFooter = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.tsMenuItem1 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.cmdImportSystemFooter = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.cmdTranslateFooter);
            this.commandManager.Commands.Add(this.cmdImportSystemFooter);
            this.commandManager.ContextMenus.Add(this.contextMenu);
            // 
            // lableFiledId
            // 
            resources.ApplyResources(this.lableFiledId, "lableFiledId");
            this.lableFiledId.Name = "lableFiledId";
            // 
            // lableHeaderText
            // 
            resources.ApplyResources(this.lableHeaderText, "lableHeaderText");
            this.lableHeaderText.Name = "lableHeaderText";
            // 
            // cHeaderText
            // 
            resources.ApplyResources(this.cHeaderText, "cHeaderText");
            this.cHeaderText.Name = "cHeaderText";
            this.cHeaderText.NamedProperties.Put("EnumerateMethod", "");
            this.cHeaderText.NamedProperties.Put("FieldFlags", "294");
            this.cHeaderText.NamedProperties.Put("LovReference", "");
            this.cHeaderText.NamedProperties.Put("SqlColumn", "FOOTER_FIELD_DESC");
            // 
            // cbSystemDefined
            // 
            resources.ApplyResources(this.cbSystemDefined, "cbSystemDefined");
            this.cbSystemDefined.Name = "cbSystemDefined";
            this.cbSystemDefined.NamedProperties.Put("EnumerateMethod", "");
            this.cbSystemDefined.NamedProperties.Put("FieldFlags", "288");
            this.cbSystemDefined.NamedProperties.Put("LovReference", "");
            this.cbSystemDefined.NamedProperties.Put("SqlColumn", "SYSTEM_DEFINED_DB");
            // 
            // cbFreeText
            // 
            resources.ApplyResources(this.cbFreeText, "cbFreeText");
            this.cbFreeText.Name = "cbFreeText";
            this.cbFreeText.NamedProperties.Put("EnumerateMethod", "");
            this.cbFreeText.NamedProperties.Put("FieldFlags", "288");
            this.cbFreeText.NamedProperties.Put("LovReference", "");
            this.cbFreeText.NamedProperties.Put("SqlColumn", "FREE_TEXT_DB");
            this.cbFreeText.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cbFreeText_WindowActions);
            // 
            // dfCompany
            // 
            this.dfCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfCompany, "dfCompany");
            this.dfCompany.Name = "dfCompany";
            this.dfCompany.NamedProperties.Put("EnumerateMethod", "");
            this.dfCompany.NamedProperties.Put("FieldFlags", "71");
            this.dfCompany.NamedProperties.Put("LovReference", "COMPANY");
            this.dfCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            // 
            // mlFooterText
            // 
            resources.ApplyResources(this.mlFooterText, "mlFooterText");
            this.mlFooterText.Name = "mlFooterText";
            this.mlFooterText.NamedProperties.Put("EnumerateMethod", "");
            this.mlFooterText.NamedProperties.Put("FieldFlags", "294");
            this.mlFooterText.NamedProperties.Put("LovReference", "");
            this.mlFooterText.NamedProperties.Put("SqlColumn", "FOOTER_TEXT");
            this.mlFooterText.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.mlFooterText_WindowActions);
            // 
            // cmbFieldId
            // 
            this.cmbFieldId.FormattingEnabled = true;
            resources.ApplyResources(this.cmbFieldId, "cmbFieldId");
            this.cmbFieldId.Name = "cmbFieldId";
            this.cmbFieldId.NamedProperties.Put("EnumerateMethod", "");
            this.cmbFieldId.NamedProperties.Put("FieldFlags", "163");
            this.cmbFieldId.NamedProperties.Put("Format", "9");
            this.cmbFieldId.NamedProperties.Put("LovReference", "");
            this.cmbFieldId.NamedProperties.Put("SqlColumn", "FOOTER_FIELD_ID");
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMenuItem,
            this.tsMenuItem1});
            this.contextMenu.Name = "contextMenu";
            resources.ApplyResources(this.contextMenu, "contextMenu");
            // 
            // tsMenuItem
            // 
            this.tsMenuItem.Command = this.cmdTranslateFooter;
            this.tsMenuItem.Name = "tsMenuItem";
            resources.ApplyResources(this.tsMenuItem, "tsMenuItem");
            this.tsMenuItem.Text = "Translation...";
            // 
            // cmdTranslateFooter
            // 
            resources.ApplyResources(this.cmdTranslateFooter, "cmdTranslateFooter");
            this.cmdTranslateFooter.Name = "cmdTranslateFooter";
            this.cmdTranslateFooter.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.cmdTranslateFooter_Execute);
            this.cmdTranslateFooter.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.cmdTranslateFooter_Inquire);
            // 
            // tsMenuItem1
            // 
            this.tsMenuItem1.Command = this.cmdImportSystemFooter;
            this.tsMenuItem1.Name = "tsMenuItem1";
            resources.ApplyResources(this.tsMenuItem1, "tsMenuItem1");
            this.tsMenuItem1.Text = "Import System Footer Fields";
            // 
            // cmdImportSystemFooter
            // 
            resources.ApplyResources(this.cmdImportSystemFooter, "cmdImportSystemFooter");
            this.cmdImportSystemFooter.Name = "cmdImportSystemFooter";
            this.cmdImportSystemFooter.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.cmdImportSystemFooter_Execute);
            this.cmdImportSystemFooter.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.cmdImportSystemFooter_Inquire);
            // 
            // frmFooterField
            // 
            resources.ApplyResources(this, "$this");
            this.ContextMenuStrip = this.contextMenu;
            this.Controls.Add(this.lableFiledId);
            this.Controls.Add(this.cmbFieldId);
            this.Controls.Add(this.mlFooterText);
            this.Controls.Add(this.dfCompany);
            this.Controls.Add(this.lableHeaderText);
            this.Controls.Add(this.cbFreeText);
            this.Controls.Add(this.cbSystemDefined);
            this.Controls.Add(this.cHeaderText);
            this.Name = "frmFooterField";
            this.NamedProperties.Put("LogicalUnit", "FooterField");
            this.NamedProperties.Put("Module", "ACCRUL");
            this.NamedProperties.Put("PackageName", "FOOTER_FIELD_API");
            this.NamedProperties.Put("ViewName", "FOOTER_FIELD");
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

        protected cBackgroundText lableFiledId;
        protected cBackgroundText lableHeaderText;
        protected cDataField cHeaderText;
        protected cCheckBox cbSystemDefined;
        protected cCheckBox cbFreeText;
        protected cDataField dfCompany;
        protected cMultilineField mlFooterText;
        protected cRecSelComboBox cmbFieldId;
        protected Fnd.Windows.Forms.FndCommand cmdTranslateFooter;
        protected Fnd.Windows.Forms.FndContextMenuStrip contextMenu;
        protected Fnd.Windows.Forms.FndToolStripMenuItem tsMenuItem;
        protected Fnd.Windows.Forms.FndCommand cmdImportSystemFooter;
        protected Fnd.Windows.Forms.FndToolStripMenuItem tsMenuItem1;
    }
}
