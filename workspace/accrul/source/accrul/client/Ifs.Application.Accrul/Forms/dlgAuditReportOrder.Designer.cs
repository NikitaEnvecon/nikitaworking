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

    public partial class dlgAuditReportOrder
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
            this.cCommandButtonOK = new Ifs.Fnd.ApplicationForms.cCommandButton();
            this.commandOk = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.cCommandButtonCancel = new Ifs.Fnd.ApplicationForms.cCommandButton();
            this.commandCancel = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabParam = new System.Windows.Forms.TabPage();
            this.pbList = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.commandList = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.dfReportId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.gb_Report = new PPJ.Runtime.Windows.SalGroupBox();
            this.labelReportId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.commandOk);
            this.commandManager.Commands.Add(this.commandCancel);
            this.commandManager.Commands.Add(this.commandList);
            this.commandManager.Components.Add(this.cCommandButtonOK);
            this.commandManager.Components.Add(this.cCommandButtonCancel);
            this.commandManager.Components.Add(this.pbList);
            // 
            // cCommandButtonOK
            // 
            this.cCommandButtonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cCommandButtonOK.Command = this.commandOk;
            this.cCommandButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cCommandButtonOK.Location = new System.Drawing.Point(448, 554);
            this.cCommandButtonOK.Name = "cCommandButtonOK";
            this.cCommandButtonOK.NamedProperties.Put("MethodIdStr", "");
            this.cCommandButtonOK.NamedProperties.Put("MethodParameterType", "String");
            this.cCommandButtonOK.TabIndex = 5;
            // 
            // commandOk
            // 
            this.commandOk.Caption = "OK";
            this.commandOk.Name = "commandOk";
            this.commandOk.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.commandOk_Execute);
            // 
            // cCommandButtonCancel
            // 
            this.cCommandButtonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cCommandButtonCancel.Command = this.commandCancel;
            this.cCommandButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cCommandButtonCancel.Location = new System.Drawing.Point(526, 554);
            this.cCommandButtonCancel.Name = "cCommandButtonCancel";
            this.cCommandButtonCancel.NamedProperties.Put("MethodIdStr", "");
            this.cCommandButtonCancel.NamedProperties.Put("MethodParameterType", "String");
            this.cCommandButtonCancel.TabIndex = 6;
            // 
            // commandCancel
            // 
            this.commandCancel.Caption = "Cancel";
            this.commandCancel.Name = "commandCancel";
            this.commandCancel.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.commandCancel_Execute);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabParam);
            this.tabControl1.Location = new System.Drawing.Point(12, 75);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(588, 471);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl1.TabIndex = 4;
            // 
            // tabParam
            // 
            this.tabParam.BackColor = System.Drawing.SystemColors.Control;
            this.tabParam.Location = new System.Drawing.Point(4, 22);
            this.tabParam.Name = "tabParam";
            this.tabParam.Padding = new System.Windows.Forms.Padding(3);
            this.tabParam.Size = new System.Drawing.Size(580, 445);
            this.tabParam.TabIndex = 0;
            this.tabParam.Text = "Parameter";
            // 
            // pbList
            // 
            this.pbList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pbList.Command = this.commandList;
            this.pbList.Location = new System.Drawing.Point(370, 554);
            this.pbList.Name = "pbList";
            this.pbList.TabIndex = 7;
            this.pbList.Text = "List...";
            // 
            // commandList
            // 
            this.commandList.Caption = "List";
            this.commandList.Name = "commandList";
            this.commandList.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.commandList_Execute);
            // 
            // dfReportId
            // 
            this.dfReportId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dfReportId.Location = new System.Drawing.Point(24, 30);
            this.dfReportId.MaxLength = 32767;
            this.dfReportId.Name = "dfReportId";
            this.dfReportId.Size = new System.Drawing.Size(560, 20);
            this.dfReportId.TabIndex = 3;
            // 
            // gb_Report
            // 
            this.gb_Report.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.gb_Report.Location = new System.Drawing.Point(13, 11);
            this.gb_Report.Name = "gb_Report";
            this.gb_Report.Size = new System.Drawing.Size(583, 50);
            this.gb_Report.TabIndex = 1;
            this.gb_Report.TabStop = false;
            this.gb_Report.Text = "&Report";
            // 
            // labelReportId
            // 
            this.labelReportId.AutoSize = true;
            this.labelReportId.Location = new System.Drawing.Point(423, 33);
            this.labelReportId.Name = "labelReportId";
            this.labelReportId.Size = new System.Drawing.Size(40, 13);
            this.labelReportId.TabIndex = 2;
            this.labelReportId.Text = "Report";
            this.labelReportId.Visible = false;
            // 
            // dlgAuditReportOrder
            // 
            this.AcceptButton = this.cCommandButtonOK;
            this.CancelButton = this.cCommandButtonCancel;
            this.ClientSize = new System.Drawing.Size(610, 589);
            this.Controls.Add(this.dfReportId);
            this.Controls.Add(this.pbList);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.cCommandButtonOK);
            this.Controls.Add(this.cCommandButtonCancel);
            this.Controls.Add(this.gb_Report);
            this.Controls.Add(this.labelReportId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Name = "dlgAuditReportOrder";
            this.ShowIcon = false;
            this.Text = "Order Report";
            this.tabControl1.ResumeLayout(false);
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

        protected cCommandButton cCommandButtonOK;
        protected cCommandButton cCommandButtonCancel;
        protected Ifs.Fnd.Windows.Forms.FndCommand commandOk;
        protected Ifs.Fnd.Windows.Forms.FndCommand commandCancel;
        protected TabControl tabControl1;
        protected TabPage tabParam;
        protected cPushButton pbList;
        protected Fnd.Windows.Forms.FndCommand commandList;
        public cDataField dfReportId;
        protected SalGroupBox gb_Report;
        protected cBackgroundText labelReportId;

    }
}
