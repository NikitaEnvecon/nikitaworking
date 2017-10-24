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

    public partial class dlgPSheetCleanupAuditSourceInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgPSheetCleanupAuditSourceInfo));
            this.labelInformationText = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.gbDeleteAuditInfo = new Ifs.Fnd.ApplicationForms.cGroupBox();
            this.lblDaysBeforeCurrentDate = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfCreatedBefore = new Ifs.Fnd.ApplicationForms.cDataField();
            this.lblCreatedBefore = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfDaysBefore = new Ifs.Fnd.ApplicationForms.cDataField();
            this.rbCreatedBefore = new Ifs.Fnd.ApplicationForms.cRadioButton();
            this.rbBeforeCurrentDate = new Ifs.Fnd.ApplicationForms.cRadioButton();
            this.ClientArea.SuspendLayout();
            this.gbDeleteAuditInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolBar
            // 
            resources.ApplyResources(this.ToolBar, "ToolBar");
            // 
            // ClientArea
            // 
            this.ClientArea.Controls.Add(this.gbDeleteAuditInfo);
            resources.ApplyResources(this.ClientArea, "ClientArea");
            // 
            // StatusBar
            // 
            resources.ApplyResources(this.StatusBar, "StatusBar");
            // 
            // labelInformationText
            // 
            resources.ApplyResources(this.labelInformationText, "labelInformationText");
            this.labelInformationText.Name = "labelInformationText";
            // 
            // gbDeleteAuditInfo
            // 
            this.gbDeleteAuditInfo.Controls.Add(this.lblDaysBeforeCurrentDate);
            this.gbDeleteAuditInfo.Controls.Add(this.dfCreatedBefore);
            this.gbDeleteAuditInfo.Controls.Add(this.lblCreatedBefore);
            this.gbDeleteAuditInfo.Controls.Add(this.dfDaysBefore);
            this.gbDeleteAuditInfo.Controls.Add(this.rbCreatedBefore);
            this.gbDeleteAuditInfo.Controls.Add(this.rbBeforeCurrentDate);
            resources.ApplyResources(this.gbDeleteAuditInfo, "gbDeleteAuditInfo");
            this.gbDeleteAuditInfo.Name = "gbDeleteAuditInfo";
            this.gbDeleteAuditInfo.TabStop = false;
            // 
            // lblDaysBeforeCurrentDate
            // 
            resources.ApplyResources(this.lblDaysBeforeCurrentDate, "lblDaysBeforeCurrentDate");
            this.lblDaysBeforeCurrentDate.Name = "lblDaysBeforeCurrentDate";
            // 
            // dfCreatedBefore
            // 
            this.dfCreatedBefore.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.dfCreatedBefore.Format = "d";
            resources.ApplyResources(this.dfCreatedBefore, "dfCreatedBefore");
            this.dfCreatedBefore.Name = "dfCreatedBefore";
            this.dfCreatedBefore.NamedProperties.Put("FieldFlags", "262");
            this.dfCreatedBefore.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfCreatedBefore_WindowActions);
            // 
            // lblCreatedBefore
            // 
            resources.ApplyResources(this.lblCreatedBefore, "lblCreatedBefore");
            this.lblCreatedBefore.Name = "lblCreatedBefore";
            // 
            // dfDaysBefore
            // 
            this.dfDaysBefore.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfDaysBefore, "dfDaysBefore");
            this.dfDaysBefore.Name = "dfDaysBefore";
            this.dfDaysBefore.NamedProperties.Put("FieldFlags", "262");
            this.dfDaysBefore.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfDaysBefore_WindowActions);
            // 
            // rbCreatedBefore
            // 
            resources.ApplyResources(this.rbCreatedBefore, "rbCreatedBefore");
            this.rbCreatedBefore.Name = "rbCreatedBefore";
            this.rbCreatedBefore.TabStop = true;
            this.rbCreatedBefore.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.rbCreatedBefore_WindowActions);
            // 
            // rbBeforeCurrentDate
            // 
            resources.ApplyResources(this.rbBeforeCurrentDate, "rbBeforeCurrentDate");
            this.rbBeforeCurrentDate.Name = "rbBeforeCurrentDate";
            this.rbBeforeCurrentDate.TabStop = true;
            this.rbBeforeCurrentDate.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.rbBeforeCurrentDate_WindowActions);
            // 
            // dlgPSheetCleanupAuditSourceInfo
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.labelInformationText);
            this.Name = "dlgPSheetCleanupAuditSourceInfo";
            this.Controls.SetChildIndex(this.ClientArea, 0);
            this.Controls.SetChildIndex(this.labelInformationText, 0);
            this.Controls.SetChildIndex(this.StatusBar, 0);
            this.Controls.SetChildIndex(this.ToolBar, 0);
            this.ClientArea.ResumeLayout(false);
            this.gbDeleteAuditInfo.ResumeLayout(false);
            this.gbDeleteAuditInfo.PerformLayout();
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

        protected cBackgroundText labelInformationText;
        protected cGroupBox gbDeleteAuditInfo;
        protected cRadioButton rbCreatedBefore;
        protected cRadioButton rbBeforeCurrentDate;
        protected cDataField dfCreatedBefore;
        protected cDataField dfDaysBefore;
        protected cBackgroundText lblDaysBeforeCurrentDate;
        protected cBackgroundText lblCreatedBefore;

    }
}
