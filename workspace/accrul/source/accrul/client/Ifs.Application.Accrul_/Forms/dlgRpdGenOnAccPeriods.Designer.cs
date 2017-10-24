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

    public partial class dlgRpdGenOnAccPeriods
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgRpdGenOnAccPeriods));
            this.commandOk = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.commandCancel = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.pbList = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.commandList = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.pbCancel = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbOk = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.dfnAccountingYearTo = new Ifs.Fnd.ApplicationForms.cDataField();
            this.cbIncludeYearEnd = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.dfnAccountingYearFrom = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsCompany = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfnAccountingYearTo = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.labeldfnAccountingYearFrom = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.labeldfnCompany = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.gbAccYearInfo = new Ifs.Fnd.ApplicationForms.cGroupBox();
            this.ClientArea.SuspendLayout();
            this.gbAccYearInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // ClientArea
            // 
            this.ClientArea.BackColor = System.Drawing.SystemColors.Control;
            this.ClientArea.Controls.Add(this.gbAccYearInfo);
            this.ClientArea.Controls.Add(this.pbList);
            this.ClientArea.Controls.Add(this.pbCancel);
            this.ClientArea.Controls.Add(this.pbOk);
            resources.ApplyResources(this.ClientArea, "ClientArea");
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.commandOk);
            this.commandManager.Commands.Add(this.commandCancel);
            this.commandManager.Commands.Add(this.commandList);
            this.commandManager.Components.Add(this.pbList);
            this.commandManager.Components.Add(this.pbCancel);
            this.commandManager.Components.Add(this.pbOk);
            // 
            // commandOk
            // 
            resources.ApplyResources(this.commandOk, "commandOk");
            this.commandOk.Name = "commandOk";
            // 
            // commandCancel
            // 
            resources.ApplyResources(this.commandCancel, "commandCancel");
            this.commandCancel.Name = "commandCancel";
            // 
            // pbList
            // 
            this.pbList.AcceleratorKey = System.Windows.Forms.Keys.F8;
            this.pbList.Command = this.commandList;
            resources.ApplyResources(this.pbList, "pbList");
            this.pbList.Name = "pbList";
            this.pbList.NamedProperties.Put("MethodId", "18385");
            this.pbList.NamedProperties.Put("MethodParameter", "List");
            this.pbList.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // commandList
            // 
            resources.ApplyResources(this.commandList, "commandList");
            this.commandList.Name = "commandList";
            // 
            // pbCancel
            // 
            this.pbCancel.AcceleratorKey = System.Windows.Forms.Keys.Escape;
            this.pbCancel.Command = this.commandCancel;
            this.pbCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.pbCancel, "pbCancel");
            this.pbCancel.Name = "pbCancel";
            this.pbCancel.NamedProperties.Put("MethodId", "18385");
            this.pbCancel.NamedProperties.Put("MethodParameter", "Cancel");
            this.pbCancel.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // pbOk
            // 
            this.pbOk.AcceleratorKey = System.Windows.Forms.Keys.Return;
            this.pbOk.Command = this.commandOk;
            resources.ApplyResources(this.pbOk, "pbOk");
            this.pbOk.Name = "pbOk";
            this.pbOk.NamedProperties.Put("MethodId", "18385");
            this.pbOk.NamedProperties.Put("MethodParameter", "OK");
            this.pbOk.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // dfnAccountingYearTo
            // 
            this.dfnAccountingYearTo.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfnAccountingYearTo, "dfnAccountingYearTo");
            this.dfnAccountingYearTo.Name = "dfnAccountingYearTo";
            this.dfnAccountingYearTo.NamedProperties.Put("EnumerateMethod", "");
            this.dfnAccountingYearTo.NamedProperties.Put("FieldFlags", "263");
            this.dfnAccountingYearTo.NamedProperties.Put("LovReference", "ACCOUNTING_YEAR(COMPANY)");
            this.dfnAccountingYearTo.NamedProperties.Put("SqlColumn", "ACCOUNTING_YEAR_TO");
            this.dfnAccountingYearTo.NamedProperties.Put("ValidateMethod", "");
            this.dfnAccountingYearTo.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfnAccountingYearTo_WindowActions);
            // 
            // cbIncludeYearEnd
            // 
            resources.ApplyResources(this.cbIncludeYearEnd, "cbIncludeYearEnd");
            this.cbIncludeYearEnd.Name = "cbIncludeYearEnd";
            this.cbIncludeYearEnd.NamedProperties.Put("DataType", "5");
            this.cbIncludeYearEnd.NamedProperties.Put("EnumerateMethod", "");
            this.cbIncludeYearEnd.NamedProperties.Put("FieldFlags", "262");
            this.cbIncludeYearEnd.NamedProperties.Put("LovReference", "");
            this.cbIncludeYearEnd.NamedProperties.Put("SqlColumn", "");
            this.cbIncludeYearEnd.NamedProperties.Put("ValidateMethod", "");
            this.cbIncludeYearEnd.NamedProperties.Put("XDataLength", "");
            this.cbIncludeYearEnd.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cbIncludeYearEnd_WindowActions);
            // 
            // dfnAccountingYearFrom
            // 
            this.dfnAccountingYearFrom.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfnAccountingYearFrom, "dfnAccountingYearFrom");
            this.dfnAccountingYearFrom.Format = "#0";
            this.dfnAccountingYearFrom.Name = "dfnAccountingYearFrom";
            this.dfnAccountingYearFrom.NamedProperties.Put("EnumerateMethod", "");
            this.dfnAccountingYearFrom.NamedProperties.Put("FieldFlags", "263");
            this.dfnAccountingYearFrom.NamedProperties.Put("LovReference", "ACCOUNTING_YEAR(COMPANY)");
            this.dfnAccountingYearFrom.NamedProperties.Put("SqlColumn", "ACCOUNTING_YEAR_FROM");
            this.dfnAccountingYearFrom.NamedProperties.Put("ValidateMethod", "");
            this.dfnAccountingYearFrom.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfnAccountingYearFrom_WindowActions);
            // 
            // dfsCompany
            // 
            resources.ApplyResources(this.dfsCompany, "dfsCompany");
            this.dfsCompany.Format = "#0";
            this.dfsCompany.Name = "dfsCompany";
            this.dfsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.dfsCompany.NamedProperties.Put("FieldFlags", "263");
            this.dfsCompany.NamedProperties.Put("LovReference", "COMPANY_FINANCE");
            this.dfsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.dfsCompany.NamedProperties.Put("ValidateMethod", "");
            this.dfsCompany.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsCompany_WindowActions);
            // 
            // labeldfnAccountingYearTo
            // 
            resources.ApplyResources(this.labeldfnAccountingYearTo, "labeldfnAccountingYearTo");
            this.labeldfnAccountingYearTo.Name = "labeldfnAccountingYearTo";
            // 
            // labeldfnAccountingYearFrom
            // 
            resources.ApplyResources(this.labeldfnAccountingYearFrom, "labeldfnAccountingYearFrom");
            this.labeldfnAccountingYearFrom.Name = "labeldfnAccountingYearFrom";
            // 
            // labeldfnCompany
            // 
            resources.ApplyResources(this.labeldfnCompany, "labeldfnCompany");
            this.labeldfnCompany.Name = "labeldfnCompany";
            // 
            // gbAccYearInfo
            // 
            this.gbAccYearInfo.Controls.Add(this.labeldfnCompany);
            this.gbAccYearInfo.Controls.Add(this.labeldfnAccountingYearTo);
            this.gbAccYearInfo.Controls.Add(this.dfnAccountingYearFrom);
            this.gbAccYearInfo.Controls.Add(this.labeldfnAccountingYearFrom);
            this.gbAccYearInfo.Controls.Add(this.dfsCompany);
            this.gbAccYearInfo.Controls.Add(this.cbIncludeYearEnd);
            this.gbAccYearInfo.Controls.Add(this.dfnAccountingYearTo);
            resources.ApplyResources(this.gbAccYearInfo, "gbAccYearInfo");
            this.gbAccYearInfo.Name = "gbAccYearInfo";
            this.gbAccYearInfo.TabStop = false;
            // 
            // dlgRpdGenOnAccPeriods
            // 
            resources.ApplyResources(this, "$this");
            this.DataBound = false;
            this.Name = "dlgRpdGenOnAccPeriods";
            this.NamedProperties.Put("LogicalUnit", "");
            this.NamedProperties.Put("ViewName", "");
            this.ShowIcon = false;
            this.ClientArea.ResumeLayout(false);
            this.gbAccYearInfo.ResumeLayout(false);
            this.gbAccYearInfo.PerformLayout();
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

        protected Ifs.Fnd.Windows.Forms.FndCommand commandOk;
        protected Ifs.Fnd.Windows.Forms.FndCommand commandCancel;
        public cPushButton pbList;
        public cPushButton pbCancel;
        public cPushButton pbOk;
        public cDataField dfsCompany;
        public cDataField dfnAccountingYearTo;
        protected cBackgroundText labeldfnCompany;
        public cCheckBox cbIncludeYearEnd;
        protected cBackgroundText labeldfnAccountingYearFrom;
        public cDataField dfnAccountingYearFrom;
        protected cBackgroundText labeldfnAccountingYearTo;
        protected Fnd.Windows.Forms.FndCommand commandList;
        protected cGroupBox gbAccYearInfo;

    }
}
