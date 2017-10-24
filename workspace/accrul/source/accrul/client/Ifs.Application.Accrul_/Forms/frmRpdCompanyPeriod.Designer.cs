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

    public partial class frmRpdCompanyPeriod
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRpdCompanyPeriod));
            this.cChildTableDetail = new Ifs.Fnd.ApplicationForms.cChildTable();
            this.cChildTableDetail_colsRpdId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.cChildTableDetail_colsCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.cChildTableDetail_colnRpdYear = new Ifs.Fnd.ApplicationForms.cColumn();
            this.cChildTableDetail_colnRpdPeriod = new Ifs.Fnd.ApplicationForms.cColumn();
            this.cChildTableDetail_colRpdPeriodFrom = new Ifs.Fnd.ApplicationForms.cColumn();
            this.cChildTableDetail_colRpdPeriodUntil = new Ifs.Fnd.ApplicationForms.cColumn();
            this.cChildTableDetail_colnAccountingYear = new Ifs.Fnd.ApplicationForms.cColumn();
            this.cChildTableDetail_colnAccountingPeriod = new Ifs.Fnd.ApplicationForms.cColumn();
            this.cChildTableDetail_colAccPeriodFrom = new Ifs.Fnd.ApplicationForms.cColumn();
            this.cChildTableDetail_colAccPeriodUntil = new Ifs.Fnd.ApplicationForms.cColumn();
            this.cChildTableDetail_colSplitAccountingPeriod = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.labelRpdId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.labelCompany = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.labelDescription = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsDescription = new Ifs.Fnd.ApplicationForms.cDataField();
            this.cmbRpdId = new Ifs.Fnd.ApplicationForms.cRecListDataField();
            this.dfsCompany = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelCompanyName = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsCompanyName = new Ifs.Fnd.ApplicationForms.cDataField();
            this.cChildTableDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // cChildTableDetail
            // 
            this.cChildTableDetail.Controls.Add(this.cChildTableDetail_colsRpdId);
            this.cChildTableDetail.Controls.Add(this.cChildTableDetail_colsCompany);
            this.cChildTableDetail.Controls.Add(this.cChildTableDetail_colnRpdYear);
            this.cChildTableDetail.Controls.Add(this.cChildTableDetail_colnRpdPeriod);
            this.cChildTableDetail.Controls.Add(this.cChildTableDetail_colRpdPeriodFrom);
            this.cChildTableDetail.Controls.Add(this.cChildTableDetail_colRpdPeriodUntil);
            this.cChildTableDetail.Controls.Add(this.cChildTableDetail_colnAccountingYear);
            this.cChildTableDetail.Controls.Add(this.cChildTableDetail_colnAccountingPeriod);
            this.cChildTableDetail.Controls.Add(this.cChildTableDetail_colAccPeriodFrom);
            this.cChildTableDetail.Controls.Add(this.cChildTableDetail_colAccPeriodUntil);
            this.cChildTableDetail.Controls.Add(this.cChildTableDetail_colSplitAccountingPeriod);
            resources.ApplyResources(this.cChildTableDetail, "cChildTableDetail");
            this.cChildTableDetail.Name = "cChildTableDetail";
            this.cChildTableDetail.NamedProperties.Put("DefaultWhere", "RPD_ID = :i_hWndFrame.frmRpdCompanyPeriod.cmbRpdId.i_sMyValue\n AND COMPANY = :i_h" +
                    "WndFrame.frmRpdCompanyPeriod.dfsCompany");
            this.cChildTableDetail.NamedProperties.Put("LogicalUnit", "RpdCompanyPeriod");
            this.cChildTableDetail.NamedProperties.Put("Module", "ACCRUL");
            this.cChildTableDetail.NamedProperties.Put("PackageName", "RPD_COMPANY_PERIOD_API");
            this.cChildTableDetail.NamedProperties.Put("ResizeableChildObject", "LLMM");
            this.cChildTableDetail.NamedProperties.Put("ViewName", "RPD_COMPANY_PERIOD");
            this.cChildTableDetail.Controls.SetChildIndex(this.cChildTableDetail_colSplitAccountingPeriod, 0);
            this.cChildTableDetail.Controls.SetChildIndex(this.cChildTableDetail_colAccPeriodUntil, 0);
            this.cChildTableDetail.Controls.SetChildIndex(this.cChildTableDetail_colAccPeriodFrom, 0);
            this.cChildTableDetail.Controls.SetChildIndex(this.cChildTableDetail_colnAccountingPeriod, 0);
            this.cChildTableDetail.Controls.SetChildIndex(this.cChildTableDetail_colnAccountingYear, 0);
            this.cChildTableDetail.Controls.SetChildIndex(this.cChildTableDetail_colRpdPeriodUntil, 0);
            this.cChildTableDetail.Controls.SetChildIndex(this.cChildTableDetail_colRpdPeriodFrom, 0);
            this.cChildTableDetail.Controls.SetChildIndex(this.cChildTableDetail_colnRpdPeriod, 0);
            this.cChildTableDetail.Controls.SetChildIndex(this.cChildTableDetail_colnRpdYear, 0);
            this.cChildTableDetail.Controls.SetChildIndex(this.cChildTableDetail_colsCompany, 0);
            this.cChildTableDetail.Controls.SetChildIndex(this.cChildTableDetail_colsRpdId, 0);
            // 
            // cChildTableDetail_colsRpdId
            // 
            this.cChildTableDetail_colsRpdId.Name = "cChildTableDetail_colsRpdId";
            this.cChildTableDetail_colsRpdId.NamedProperties.Put("EnumerateMethod", "");
            this.cChildTableDetail_colsRpdId.NamedProperties.Put("FieldFlags", "99");
            this.cChildTableDetail_colsRpdId.NamedProperties.Put("LovReference", "RPD_IDENTITY");
            this.cChildTableDetail_colsRpdId.NamedProperties.Put("SqlColumn", "RPD_ID");
            this.cChildTableDetail_colsRpdId.Position = 3;
            resources.ApplyResources(this.cChildTableDetail_colsRpdId, "cChildTableDetail_colsRpdId");
            // 
            // cChildTableDetail_colsCompany
            // 
            this.cChildTableDetail_colsCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cChildTableDetail_colsCompany.Name = "cChildTableDetail_colsCompany";
            this.cChildTableDetail_colsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.cChildTableDetail_colsCompany.NamedProperties.Put("FieldFlags", "99");
            this.cChildTableDetail_colsCompany.NamedProperties.Put("LovReference", "RPD_COMPANY(RPD_ID)");
            this.cChildTableDetail_colsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.cChildTableDetail_colsCompany.Position = 4;
            resources.ApplyResources(this.cChildTableDetail_colsCompany, "cChildTableDetail_colsCompany");
            // 
            // cChildTableDetail_colnRpdYear
            // 
            this.cChildTableDetail_colnRpdYear.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.cChildTableDetail_colnRpdYear.Name = "cChildTableDetail_colnRpdYear";
            this.cChildTableDetail_colnRpdYear.NamedProperties.Put("EnumerateMethod", "");
            this.cChildTableDetail_colnRpdYear.NamedProperties.Put("FieldFlags", "163");
            this.cChildTableDetail_colnRpdYear.NamedProperties.Put("Format", "");
            this.cChildTableDetail_colnRpdYear.NamedProperties.Put("LovReference", "RPD_YEAR(RPD_ID)");
            this.cChildTableDetail_colnRpdYear.NamedProperties.Put("SqlColumn", "RPD_YEAR");
            this.cChildTableDetail_colnRpdYear.Position = 5;
            resources.ApplyResources(this.cChildTableDetail_colnRpdYear, "cChildTableDetail_colnRpdYear");
            this.cChildTableDetail_colnRpdYear.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cChildTableDetail_colnRpdYear_WindowActions);
            // 
            // cChildTableDetail_colnRpdPeriod
            // 
            this.cChildTableDetail_colnRpdPeriod.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.cChildTableDetail_colnRpdPeriod.Name = "cChildTableDetail_colnRpdPeriod";
            this.cChildTableDetail_colnRpdPeriod.NamedProperties.Put("EnumerateMethod", "");
            this.cChildTableDetail_colnRpdPeriod.NamedProperties.Put("FieldFlags", "163");
            this.cChildTableDetail_colnRpdPeriod.NamedProperties.Put("Format", "");
            this.cChildTableDetail_colnRpdPeriod.NamedProperties.Put("LovReference", "RPD_PERIOD(RPD_ID,RPD_YEAR)");
            this.cChildTableDetail_colnRpdPeriod.NamedProperties.Put("SqlColumn", "RPD_PERIOD");
            this.cChildTableDetail_colnRpdPeriod.Position = 6;
            resources.ApplyResources(this.cChildTableDetail_colnRpdPeriod, "cChildTableDetail_colnRpdPeriod");
            this.cChildTableDetail_colnRpdPeriod.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cChildTableDetail_colnRpdPeriod_WindowActions);
            // 
            // cChildTableDetail_colRpdPeriodFrom
            // 
            this.cChildTableDetail_colRpdPeriodFrom.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.cChildTableDetail_colRpdPeriodFrom.Format = "d";
            this.cChildTableDetail_colRpdPeriodFrom.MaxLength = 2000;
            this.cChildTableDetail_colRpdPeriodFrom.Name = "cChildTableDetail_colRpdPeriodFrom";
            this.cChildTableDetail_colRpdPeriodFrom.NamedProperties.Put("EnumerateMethod", "");
            this.cChildTableDetail_colRpdPeriodFrom.NamedProperties.Put("LovReference", "");
            this.cChildTableDetail_colRpdPeriodFrom.NamedProperties.Put("ParentName", "cChildTableDetail.cChildTableDetail_colnRpdPeriod");
            this.cChildTableDetail_colRpdPeriodFrom.NamedProperties.Put("SqlColumn", "RPD_PERIOD_API.Get_From_Date(RPD_ID,RPD_YEAR,RPD_PERIOD)");
            this.cChildTableDetail_colRpdPeriodFrom.Position = 7;
            this.cChildTableDetail_colRpdPeriodFrom.ReadOnly = true;
            resources.ApplyResources(this.cChildTableDetail_colRpdPeriodFrom, "cChildTableDetail_colRpdPeriodFrom");
            // 
            // cChildTableDetail_colRpdPeriodUntil
            // 
            this.cChildTableDetail_colRpdPeriodUntil.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.cChildTableDetail_colRpdPeriodUntil.Format = "d";
            this.cChildTableDetail_colRpdPeriodUntil.MaxLength = 2000;
            this.cChildTableDetail_colRpdPeriodUntil.Name = "cChildTableDetail_colRpdPeriodUntil";
            this.cChildTableDetail_colRpdPeriodUntil.NamedProperties.Put("EnumerateMethod", "");
            this.cChildTableDetail_colRpdPeriodUntil.NamedProperties.Put("LovReference", "");
            this.cChildTableDetail_colRpdPeriodUntil.NamedProperties.Put("ParentName", "cChildTableDetail.cChildTableDetail_colnRpdPeriod");
            this.cChildTableDetail_colRpdPeriodUntil.NamedProperties.Put("SqlColumn", "RPD_PERIOD_API.Get_Until_Date(RPD_ID,RPD_YEAR,RPD_PERIOD)");
            this.cChildTableDetail_colRpdPeriodUntil.Position = 8;
            this.cChildTableDetail_colRpdPeriodUntil.ReadOnly = true;
            resources.ApplyResources(this.cChildTableDetail_colRpdPeriodUntil, "cChildTableDetail_colRpdPeriodUntil");
            // 
            // cChildTableDetail_colnAccountingYear
            // 
            this.cChildTableDetail_colnAccountingYear.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.cChildTableDetail_colnAccountingYear.Name = "cChildTableDetail_colnAccountingYear";
            this.cChildTableDetail_colnAccountingYear.NamedProperties.Put("EnumerateMethod", "");
            this.cChildTableDetail_colnAccountingYear.NamedProperties.Put("FieldFlags", "163");
            this.cChildTableDetail_colnAccountingYear.NamedProperties.Put("Format", "");
            this.cChildTableDetail_colnAccountingYear.NamedProperties.Put("LovReference", "ACCOUNTING_YEAR(COMPANY)");
            this.cChildTableDetail_colnAccountingYear.NamedProperties.Put("SqlColumn", "ACCOUNTING_YEAR");
            this.cChildTableDetail_colnAccountingYear.Position = 9;
            resources.ApplyResources(this.cChildTableDetail_colnAccountingYear, "cChildTableDetail_colnAccountingYear");
            this.cChildTableDetail_colnAccountingYear.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cChildTableDetail_colnAccountingYear_WindowActions);
            // 
            // cChildTableDetail_colnAccountingPeriod
            // 
            this.cChildTableDetail_colnAccountingPeriod.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.cChildTableDetail_colnAccountingPeriod.Name = "cChildTableDetail_colnAccountingPeriod";
            this.cChildTableDetail_colnAccountingPeriod.NamedProperties.Put("EnumerateMethod", "");
            this.cChildTableDetail_colnAccountingPeriod.NamedProperties.Put("FieldFlags", "163");
            this.cChildTableDetail_colnAccountingPeriod.NamedProperties.Put("Format", "");
            this.cChildTableDetail_colnAccountingPeriod.NamedProperties.Put("LovReference", "ACCOUNTING_YEAR_PERIOD(COMPANY,ACCOUNTING_YEAR)");
            this.cChildTableDetail_colnAccountingPeriod.NamedProperties.Put("SqlColumn", "ACCOUNTING_PERIOD");
            this.cChildTableDetail_colnAccountingPeriod.Position = 10;
            resources.ApplyResources(this.cChildTableDetail_colnAccountingPeriod, "cChildTableDetail_colnAccountingPeriod");
            this.cChildTableDetail_colnAccountingPeriod.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cChildTableDetail_colnAccountingPeriod_WindowActions);
            // 
            // cChildTableDetail_colAccPeriodFrom
            // 
            this.cChildTableDetail_colAccPeriodFrom.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.cChildTableDetail_colAccPeriodFrom.Format = "d";
            this.cChildTableDetail_colAccPeriodFrom.MaxLength = 2000;
            this.cChildTableDetail_colAccPeriodFrom.Name = "cChildTableDetail_colAccPeriodFrom";
            this.cChildTableDetail_colAccPeriodFrom.NamedProperties.Put("EnumerateMethod", "");
            this.cChildTableDetail_colAccPeriodFrom.NamedProperties.Put("LovReference", "");
            this.cChildTableDetail_colAccPeriodFrom.NamedProperties.Put("ParentName", "cChildTableDetail.cChildTableDetail_colnAccountingPeriod");
            this.cChildTableDetail_colAccPeriodFrom.NamedProperties.Put("SqlColumn", "ACCOUNTING_PERIOD_API.Get_Date_From(COMPANY,ACCOUNTING_YEAR,ACCOUNTING_PERIOD)");
            this.cChildTableDetail_colAccPeriodFrom.Position = 11;
            this.cChildTableDetail_colAccPeriodFrom.ReadOnly = true;
            resources.ApplyResources(this.cChildTableDetail_colAccPeriodFrom, "cChildTableDetail_colAccPeriodFrom");
            // 
            // cChildTableDetail_colAccPeriodUntil
            // 
            this.cChildTableDetail_colAccPeriodUntil.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.cChildTableDetail_colAccPeriodUntil.Format = "d";
            this.cChildTableDetail_colAccPeriodUntil.MaxLength = 2000;
            this.cChildTableDetail_colAccPeriodUntil.Name = "cChildTableDetail_colAccPeriodUntil";
            this.cChildTableDetail_colAccPeriodUntil.NamedProperties.Put("EnumerateMethod", "");
            this.cChildTableDetail_colAccPeriodUntil.NamedProperties.Put("LovReference", "");
            this.cChildTableDetail_colAccPeriodUntil.NamedProperties.Put("ParentName", "cChildTableDetail.cChildTableDetail_colnAccountingPeriod");
            this.cChildTableDetail_colAccPeriodUntil.NamedProperties.Put("SqlColumn", "ACCOUNTING_PERIOD_API.Get_Date_Until(COMPANY,ACCOUNTING_YEAR,ACCOUNTING_PERIOD)");
            this.cChildTableDetail_colAccPeriodUntil.Position = 12;
            this.cChildTableDetail_colAccPeriodUntil.ReadOnly = true;
            resources.ApplyResources(this.cChildTableDetail_colAccPeriodUntil, "cChildTableDetail_colAccPeriodUntil");
            // 
            // cChildTableDetail_colSplitAccountingPeriod
            // 
            this.cChildTableDetail_colSplitAccountingPeriod.CheckBox.CheckedValue = "1";
            this.cChildTableDetail_colSplitAccountingPeriod.CheckBox.IgnoreCase = true;
            this.cChildTableDetail_colSplitAccountingPeriod.CheckBox.UncheckedValue = "0";
            this.cChildTableDetail_colSplitAccountingPeriod.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.cChildTableDetail_colSplitAccountingPeriod.Name = "cChildTableDetail_colSplitAccountingPeriod";
            this.cChildTableDetail_colSplitAccountingPeriod.NamedProperties.Put("EnumerateMethod", "");
            this.cChildTableDetail_colSplitAccountingPeriod.NamedProperties.Put("FieldFlags", "288");
            this.cChildTableDetail_colSplitAccountingPeriod.NamedProperties.Put("LovReference", "");
            this.cChildTableDetail_colSplitAccountingPeriod.NamedProperties.Put("SqlColumn", "SPLIT_ACCOUNTING_PERIOD");
            this.cChildTableDetail_colSplitAccountingPeriod.Position = 13;
            this.cChildTableDetail_colSplitAccountingPeriod.ReadOnly = true;
            resources.ApplyResources(this.cChildTableDetail_colSplitAccountingPeriod, "cChildTableDetail_colSplitAccountingPeriod");
            // 
            // labelRpdId
            // 
            resources.ApplyResources(this.labelRpdId, "labelRpdId");
            this.labelRpdId.Name = "labelRpdId";
            // 
            // labelCompany
            // 
            resources.ApplyResources(this.labelCompany, "labelCompany");
            this.labelCompany.Name = "labelCompany";
            // 
            // labelDescription
            // 
            resources.ApplyResources(this.labelDescription, "labelDescription");
            this.labelDescription.Name = "labelDescription";
            // 
            // dfsDescription
            // 
            resources.ApplyResources(this.dfsDescription, "dfsDescription");
            this.dfsDescription.Name = "dfsDescription";
            this.dfsDescription.NamedProperties.Put("EnumerateMethod", "");
            this.dfsDescription.NamedProperties.Put("FieldFlags", "288");
            this.dfsDescription.NamedProperties.Put("LovReference", "");
            this.dfsDescription.NamedProperties.Put("ParentName", "cmbRpdId");
            this.dfsDescription.NamedProperties.Put("SqlColumn", "RPD_IDENTITY_API.GET_DESCRIPTION(RPD_ID)");
            // 
            // cmbRpdId
            // 
            this.cmbRpdId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.cmbRpdId, "cmbRpdId");
            this.cmbRpdId.Name = "cmbRpdId";
            this.cmbRpdId.NamedProperties.Put("EnumerateMethod", "");
            this.cmbRpdId.NamedProperties.Put("FieldFlags", "99");
            this.cmbRpdId.NamedProperties.Put("Format", "9");
            this.cmbRpdId.NamedProperties.Put("LovReference", "RPD_IDENTITY");
            this.cmbRpdId.NamedProperties.Put("SqlColumn", "RPD_ID");
            this.cmbRpdId.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbRpdId_WindowActions);
            // 
            // dfsCompany
            // 
            this.dfsCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsCompany, "dfsCompany");
            this.dfsCompany.Name = "dfsCompany";
            this.dfsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.dfsCompany.NamedProperties.Put("FieldFlags", "163");
            this.dfsCompany.NamedProperties.Put("LovReference", "COMPANY_FINANCE");
            this.dfsCompany.NamedProperties.Put("ParentName", "cmbRpdId");
            this.dfsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.dfsCompany.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsCompany_WindowActions);
            // 
            // labelCompanyName
            // 
            resources.ApplyResources(this.labelCompanyName, "labelCompanyName");
            this.labelCompanyName.Name = "labelCompanyName";
            // 
            // dfsCompanyName
            // 
            resources.ApplyResources(this.dfsCompanyName, "dfsCompanyName");
            this.dfsCompanyName.Name = "dfsCompanyName";
            this.dfsCompanyName.NamedProperties.Put("EnumerateMethod", "");
            this.dfsCompanyName.NamedProperties.Put("LovReference", "");
            this.dfsCompanyName.NamedProperties.Put("ParentName", "cmbRpdId");
            this.dfsCompanyName.NamedProperties.Put("SqlColumn", "COMPANY_FINANCE_API.GET_DESCRIPTION(COMPANY)");
            // 
            // frmRpdCompanyPeriod
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.labelCompanyName);
            this.Controls.Add(this.dfsCompanyName);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.dfsDescription);
            this.Controls.Add(this.labelCompany);
            this.Controls.Add(this.dfsCompany);
            this.Controls.Add(this.labelRpdId);
            this.Controls.Add(this.cmbRpdId);
            this.Controls.Add(this.cChildTableDetail);
            this.Name = "frmRpdCompanyPeriod";
            this.NamedProperties.Put("LogicalUnit", "RpdCompany");
            this.NamedProperties.Put("Module", "ACCRUL");
            this.NamedProperties.Put("PackageName", "RPD_COMPANY_API");
            this.NamedProperties.Put("ViewName", "RPD_COMPANY");
            this.cChildTableDetail.ResumeLayout(false);
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
        protected cBackgroundText labelRpdId;
        protected cBackgroundText labelCompany;
        protected cBackgroundText labelDescription;
        protected cDataField dfsDescription;
        protected cRecListDataField cmbRpdId;
        protected cDataField dfsCompany;
        protected cColumn cChildTableDetail_colsRpdId;
        protected cColumn cChildTableDetail_colsCompany;
        protected cColumn cChildTableDetail_colnRpdYear;
        protected cColumn cChildTableDetail_colnRpdPeriod;
        protected cColumn cChildTableDetail_colnAccountingYear;
        protected cColumn cChildTableDetail_colnAccountingPeriod;
        protected cBackgroundText labelCompanyName;
        protected cDataField dfsCompanyName;
        protected cColumn cChildTableDetail_colAccPeriodFrom;
        protected cColumn cChildTableDetail_colAccPeriodUntil;
        protected cColumn cChildTableDetail_colRpdPeriodFrom;
        protected cColumn cChildTableDetail_colRpdPeriodUntil;
        protected cCheckBoxColumn cChildTableDetail_colSplitAccountingPeriod;        
    }
}
