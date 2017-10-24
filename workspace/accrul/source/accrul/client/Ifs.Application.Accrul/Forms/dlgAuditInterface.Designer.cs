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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using Ifs.Fnd.ApplicationForms;
using PPJ.Runtime;
using PPJ.Runtime.Windows;

namespace Ifs.Application.Accrul
{

    public partial class dlgAuditInterface
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgAuditInterface));
            this.labeldfHeading = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfHeading = new Ifs.Fnd.ApplicationForms.cDataField();
            this.gbProcess = new Ifs.Fnd.ApplicationForms.cGroupBox();
            this.rbBatch = new Ifs.Fnd.ApplicationForms.cRadioButton();
            this.rbOnline = new Ifs.Fnd.ApplicationForms.cRadioButton();
            this.dfDateUntil = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelDateFrom = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.labelDateUntil = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfDateFrom = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelCountry = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.labelAuditSource = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfAuditSource = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelOutputPath = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfOutputPath = new Ifs.Fnd.ApplicationForms.cDataField();
            this.WizardStep = new Ifs.Fnd.ApplicationForms.@__cWizardStep();
            this.WizardStep2 = new Ifs.Fnd.ApplicationForms.@__cWizardStep();
            this.pbBrowse = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.cmdBrowse = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.gbSelection = new Ifs.Fnd.ApplicationForms.cGroupBox();
            this.gbDateTitle = new Ifs.Fnd.ApplicationForms.cGroupBox();
            this.dfLedgerDesc = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfLedgerID = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelLedgerID = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.labelLedgerDesc = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfCompanyDesc = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfCompany = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelCompany = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.labelCompanyDesc = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfCountry = new Ifs.Fnd.ApplicationForms.cDataField();
            ((System.ComponentModel.ISupportInitialize)(this.picWizard)).BeginInit();
            this.ToolBar.SuspendLayout();
            this.ClientArea.SuspendLayout();
            this.gbProcess.SuspendLayout();
            this.gbSelection.SuspendLayout();
            this.gbDateTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbFinish
            // 
            resources.ApplyResources(this.pbFinish, "pbFinish");
            // 
            // pbNext
            // 
            resources.ApplyResources(this.pbNext, "pbNext");
            // 
            // pbBack
            // 
            resources.ApplyResources(this.pbBack, "pbBack");
            // 
            // pbCancel
            // 
            resources.ApplyResources(this.pbCancel, "pbCancel");
            // 
            // picWizard
            // 
            resources.ApplyResources(this.picWizard, "picWizard");
            // 
            // ToolBar
            // 
            this.ToolBar.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.ToolBar, "ToolBar");
            // 
            // ClientArea
            // 
            this.ClientArea.BackColor = System.Drawing.SystemColors.Control;
            this.ClientArea.Controls.Add(this.dfCompanyDesc);
            this.ClientArea.Controls.Add(this.dfCompany);
            this.ClientArea.Controls.Add(this.dfCountry);
            this.ClientArea.Controls.Add(this.labelCompany);
            this.ClientArea.Controls.Add(this.gbProcess);
            this.ClientArea.Controls.Add(this.pbBrowse);
            this.ClientArea.Controls.Add(this.dfAuditSource);
            this.ClientArea.Controls.Add(this.dfOutputPath);
            this.ClientArea.Controls.Add(this.labelOutputPath);
            this.ClientArea.Controls.Add(this.labelAuditSource);
            this.ClientArea.Controls.Add(this.labelCountry);
            this.ClientArea.Controls.Add(this.gbSelection);
            this.ClientArea.Controls.Add(this.labeldfHeading);
            this.ClientArea.Controls.Add(this.dfHeading);
            this.ClientArea.Controls.Add(this.labelCompanyDesc);
            resources.ApplyResources(this.ClientArea, "ClientArea");
            this.ClientArea.Controls.SetChildIndex(this.labelCompanyDesc, 0);
            this.ClientArea.Controls.SetChildIndex(this.dfHeading, 0);
            this.ClientArea.Controls.SetChildIndex(this.labeldfHeading, 0);
            this.ClientArea.Controls.SetChildIndex(this.gbSelection, 0);
            this.ClientArea.Controls.SetChildIndex(this.picWizard, 0);
            this.ClientArea.Controls.SetChildIndex(this.labelCountry, 0);
            this.ClientArea.Controls.SetChildIndex(this.labelAuditSource, 0);
            this.ClientArea.Controls.SetChildIndex(this.labelOutputPath, 0);
            this.ClientArea.Controls.SetChildIndex(this.dfOutputPath, 0);
            this.ClientArea.Controls.SetChildIndex(this.dfAuditSource, 0);
            this.ClientArea.Controls.SetChildIndex(this.pbBrowse, 0);
            this.ClientArea.Controls.SetChildIndex(this.gbProcess, 0);
            this.ClientArea.Controls.SetChildIndex(this.labelCompany, 0);
            this.ClientArea.Controls.SetChildIndex(this.dfCountry, 0);
            this.ClientArea.Controls.SetChildIndex(this.dfCompany, 0);
            this.ClientArea.Controls.SetChildIndex(this.dfCompanyDesc, 0);
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.cmdBrowse);
            this.commandManager.Components.Add(this.pbBrowse);
            // 
            // labeldfHeading
            // 
            resources.ApplyResources(this.labeldfHeading, "labeldfHeading");
            this.labeldfHeading.Name = "labeldfHeading";
            // 
            // dfHeading
            // 
            resources.ApplyResources(this.dfHeading, "dfHeading");
            this.dfHeading.Name = "dfHeading";
            // 
            // gbProcess
            // 
            this.gbProcess.Controls.Add(this.rbBatch);
            this.gbProcess.Controls.Add(this.rbOnline);
            resources.ApplyResources(this.gbProcess, "gbProcess");
            this.gbProcess.Name = "gbProcess";
            this.gbProcess.TabStop = false;
            // 
            // rbBatch
            // 
            resources.ApplyResources(this.rbBatch, "rbBatch");
            this.rbBatch.Name = "rbBatch";
            this.rbBatch.TabStop = true;
            // 
            // rbOnline
            // 
            resources.ApplyResources(this.rbOnline, "rbOnline");
            this.rbOnline.Name = "rbOnline";
            this.rbOnline.TabStop = true;
            // 
            // dfDateUntil
            // 
            this.dfDateUntil.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.dfDateUntil.Format = "d";
            resources.ApplyResources(this.dfDateUntil, "dfDateUntil");
            this.dfDateUntil.Name = "dfDateUntil";
            this.dfDateUntil.NamedProperties.Put("EnumerateMethod", "");
            this.dfDateUntil.NamedProperties.Put("FieldFlags", "294");
            this.dfDateUntil.NamedProperties.Put("LovReference", "");
            this.dfDateUntil.NamedProperties.Put("SqlColumn", "DATE_UNTIL");
            this.dfDateUntil.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfDateUntil_WindowActions);
            // 
            // labelDateFrom
            // 
            resources.ApplyResources(this.labelDateFrom, "labelDateFrom");
            this.labelDateFrom.Name = "labelDateFrom";
            // 
            // labelDateUntil
            // 
            resources.ApplyResources(this.labelDateUntil, "labelDateUntil");
            this.labelDateUntil.Name = "labelDateUntil";
            // 
            // dfDateFrom
            // 
            this.dfDateFrom.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.dfDateFrom.Format = "d";
            resources.ApplyResources(this.dfDateFrom, "dfDateFrom");
            this.dfDateFrom.Name = "dfDateFrom";
            this.dfDateFrom.NamedProperties.Put("EnumerateMethod", "");
            this.dfDateFrom.NamedProperties.Put("FieldFlags", "294");
            this.dfDateFrom.NamedProperties.Put("LovReference", "");
            this.dfDateFrom.NamedProperties.Put("SqlColumn", "DATE_FROM");
            this.dfDateFrom.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfDateFrom_WindowActions);
            // 
            // labelCountry
            // 
            resources.ApplyResources(this.labelCountry, "labelCountry");
            this.labelCountry.Name = "labelCountry";
            // 
            // labelAuditSource
            // 
            resources.ApplyResources(this.labelAuditSource, "labelAuditSource");
            this.labelAuditSource.Name = "labelAuditSource";
            // 
            // dfAuditSource
            // 
            resources.ApplyResources(this.dfAuditSource, "dfAuditSource");
            this.dfAuditSource.Name = "dfAuditSource";
            this.dfAuditSource.NamedProperties.Put("EnumerateMethod", "");
            this.dfAuditSource.NamedProperties.Put("FieldFlags", "294");
            this.dfAuditSource.NamedProperties.Put("LovReference", "AUDIT_SOURCE");
            this.dfAuditSource.NamedProperties.Put("SqlColumn", "AUDIT_SOURCE");
            this.dfAuditSource.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfAuditSource_WindowActions);
            // 
            // labelOutputPath
            // 
            resources.ApplyResources(this.labelOutputPath, "labelOutputPath");
            this.labelOutputPath.Name = "labelOutputPath";
            // 
            // dfOutputPath
            // 
            resources.ApplyResources(this.dfOutputPath, "dfOutputPath");
            this.dfOutputPath.Name = "dfOutputPath";
            this.dfOutputPath.NamedProperties.Put("EnumerateMethod", "");
            this.dfOutputPath.NamedProperties.Put("FieldFlags", "292");
            this.dfOutputPath.NamedProperties.Put("LovReference", "");
            this.dfOutputPath.NamedProperties.Put("SqlColumn", "DUMMY");
            this.dfOutputPath.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfOutputPath_WindowActions);
            // 
            // WizardStep
            // 
            this.WizardStep.Controls = new string[] {
        "labelCountry",
        "dfCountry",
        "labelAuditSource",
        "dfAuditSource",
        "labelOutputPath",
        "dfOutputPath",
        "pbBrowse",
        "dfCompany",
        "dfCompanyDesc",
        "dfDateFrom",
        "dfDateUntil",
        "gbSelection",
        "labelCompany",
        "labelDateFrom",
        "labelDateUntil",
        "dfLedgerID",
        "labelLedgerID",
        "labelLedgerDesc",
        "dfLedgerDesc",
        "gbDateTitle"};
            this.WizardStep.StepDescription = "Step2";
            resources.ApplyResources(this.WizardStep, "WizardStep");
            this.WizardStep.UseInternalControls = true;
            // 
            // WizardStep2
            // 
            this.WizardStep2.Controls = new string[] {
        "dfHeading",
        "rbBatch",
        "rbOnline",
        "cGroupBox1",
        "gbProcess"};
            this.WizardStep2.StepDescription = "Step1";
            resources.ApplyResources(this.WizardStep2, "WizardStep2");
            this.WizardStep2.UseInternalControls = true;
            // 
            // pbBrowse
            // 
            this.pbBrowse.Command = this.cmdBrowse;
            resources.ApplyResources(this.pbBrowse, "pbBrowse");
            this.pbBrowse.Name = "pbBrowse";
            // 
            // cmdBrowse
            // 
            resources.ApplyResources(this.cmdBrowse, "cmdBrowse");
            this.cmdBrowse.Name = "cmdBrowse";
            this.cmdBrowse.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.cmdBrowse_Execute);
            this.cmdBrowse.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.cmdBrowse_Inquire);
            // 
            // gbSelection
            // 
            this.gbSelection.Controls.Add(this.gbDateTitle);
            this.gbSelection.Controls.Add(this.dfLedgerDesc);
            this.gbSelection.Controls.Add(this.dfLedgerID);
            this.gbSelection.Controls.Add(this.labelLedgerID);
            this.gbSelection.Controls.Add(this.labelLedgerDesc);
            resources.ApplyResources(this.gbSelection, "gbSelection");
            this.gbSelection.Name = "gbSelection";
            this.gbSelection.TabStop = false;
            // 
            // gbDateTitle
            // 
            this.gbDateTitle.Controls.Add(this.labelDateUntil);
            this.gbDateTitle.Controls.Add(this.labelDateFrom);
            this.gbDateTitle.Controls.Add(this.dfDateUntil);
            this.gbDateTitle.Controls.Add(this.dfDateFrom);
            resources.ApplyResources(this.gbDateTitle, "gbDateTitle");
            this.gbDateTitle.Name = "gbDateTitle";
            this.gbDateTitle.TabStop = false;
            // 
            // dfLedgerDesc
            // 
            resources.ApplyResources(this.dfLedgerDesc, "dfLedgerDesc");
            this.dfLedgerDesc.Name = "dfLedgerDesc";
            // 
            // dfLedgerID
            // 
            this.dfLedgerID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfLedgerID, "dfLedgerID");
            this.dfLedgerID.Name = "dfLedgerID";
            this.dfLedgerID.NamedProperties.Put("FieldFlags", "262");
            this.dfLedgerID.NamedProperties.Put("LovReference", "INTERNAL_LEDGER_LOV(COMPANY)");
            this.dfLedgerID.NamedProperties.Put("SqlColumn", "LEDGER_ID");
            this.dfLedgerID.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfLedgerID_WindowActions);
            // 
            // labelLedgerID
            // 
            resources.ApplyResources(this.labelLedgerID, "labelLedgerID");
            this.labelLedgerID.Name = "labelLedgerID";
            // 
            // labelLedgerDesc
            // 
            resources.ApplyResources(this.labelLedgerDesc, "labelLedgerDesc");
            this.labelLedgerDesc.Name = "labelLedgerDesc";
            // 
            // dfCompanyDesc
            // 
            resources.ApplyResources(this.dfCompanyDesc, "dfCompanyDesc");
            this.dfCompanyDesc.Name = "dfCompanyDesc";
            this.dfCompanyDesc.NamedProperties.Put("EnumerateMethod", "");
            this.dfCompanyDesc.NamedProperties.Put("FieldFlags", "288");
            this.dfCompanyDesc.NamedProperties.Put("LovReference", "");
            this.dfCompanyDesc.NamedProperties.Put("SqlColumn", "");
            // 
            // dfCompany
            // 
            this.dfCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfCompany, "dfCompany");
            this.dfCompany.Name = "dfCompany";
            this.dfCompany.NamedProperties.Put("EnumerateMethod", "");
            this.dfCompany.NamedProperties.Put("FieldFlags", "294");
            this.dfCompany.NamedProperties.Put("LovReference", "COMPANY_FINANCE");
            this.dfCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.dfCompany.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfCompany_WindowActions);
            // 
            // labelCompany
            // 
            resources.ApplyResources(this.labelCompany, "labelCompany");
            this.labelCompany.Name = "labelCompany";
            // 
            // labelCompanyDesc
            // 
            resources.ApplyResources(this.labelCompanyDesc, "labelCompanyDesc");
            this.labelCompanyDesc.Name = "labelCompanyDesc";
            // 
            // dfCountry
            // 
            this.dfCountry.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfCountry, "dfCountry");
            this.dfCountry.Name = "dfCountry";
            this.dfCountry.NamedProperties.Put("EnumerateMethod", "");
            this.dfCountry.NamedProperties.Put("FieldFlags", "294");
            this.dfCountry.NamedProperties.Put("LovReference", "AUDIT_FORMAT(COMPANY)");
            this.dfCountry.NamedProperties.Put("SqlColumn", "COUNTRY");
            this.dfCountry.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfCountry_WindowActions);
            // 
            // dlgAuditInterface
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "dlgAuditInterface";
            this.NamedProperties.Put("Module", "%");
            this.NamedProperties.Put("SourceFlags", "449");
            this.ShowIcon = false;
            this.ShowList = true;
            this.ShowPicture = true;
            this.WizardSteps.Add(this.WizardStep2);
            this.WizardSteps.Add(this.WizardStep);
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dlgAuditInterface_WindowActions);
            ((System.ComponentModel.ISupportInitialize)(this.picWizard)).EndInit();
            this.ToolBar.ResumeLayout(false);
            this.ClientArea.ResumeLayout(false);
            this.ClientArea.PerformLayout();
            this.gbProcess.ResumeLayout(false);
            this.gbProcess.PerformLayout();
            this.gbSelection.ResumeLayout(false);
            this.gbSelection.PerformLayout();
            this.gbDateTitle.ResumeLayout(false);
            this.gbDateTitle.PerformLayout();
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

        protected cBackgroundText labeldfHeading;
        protected cGroupBox gbProcess;
        protected cDataField dfHeading;
        protected cBackgroundText labelAuditSource;
        protected cDataField dfAuditSource;
        protected cBackgroundText labelCountry;
        protected cRadioButton rbBatch;
        protected cRadioButton rbOnline;
        protected cDataField dfOutputPath;
        protected cBackgroundText labelOutputPath;
        protected __cWizardStep WizardStep;
        protected __cWizardStep WizardStep2;
        protected cPushButton pbBrowse;
        protected Fnd.Windows.Forms.FndCommand cmdBrowse;
        protected cDataField dfDateUntil;
        protected cBackgroundText labelDateFrom;
        protected cBackgroundText labelDateUntil;
        protected cDataField dfDateFrom;
        protected cGroupBox gbSelection;
        protected cDataField dfCompanyDesc;
        protected cDataField dfCompany;
        protected cBackgroundText labelCompany;
        protected cBackgroundText labelCompanyDesc;
        protected cDataField dfCountry;
        protected cDataField dfLedgerID;
        protected cBackgroundText labelLedgerID;
        protected cDataField dfLedgerDesc;
        protected cBackgroundText labelLedgerDesc;
        protected cGroupBox gbDateTitle;
    }
}
