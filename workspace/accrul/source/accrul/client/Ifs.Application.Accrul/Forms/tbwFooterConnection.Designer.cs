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

    public partial class tbwFooterConnection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwFooterConnection));
            this.ColsCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsReportId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsReportName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsFooterId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsFooterName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsContract = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsModule = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsContractDependent = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.SuspendLayout();
            // 
            // ColsCompany
            // 
            this.ColsCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ColsCompany.MaxLength = 20;
            this.ColsCompany.Name = "ColsCompany";
            this.ColsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.ColsCompany.NamedProperties.Put("FieldFlags", "4163");
            this.ColsCompany.NamedProperties.Put("LovReference", "COMPANY");
            this.ColsCompany.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.ColsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.ColsCompany.Position = 3;
            resources.ApplyResources(this.ColsCompany, "ColsCompany");
            // 
            // colsReportId
            // 
            this.colsReportId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsReportId.MaxLength = 30;
            this.colsReportId.Name = "colsReportId";
            this.colsReportId.NamedProperties.Put("EnumerateMethod", "");
            this.colsReportId.NamedProperties.Put("FieldFlags", "167");
            this.colsReportId.NamedProperties.Put("LovReference", "FOOTER_CONNECTION_MASTER_LOV");
            this.colsReportId.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsReportId.NamedProperties.Put("SqlColumn", "REPORT_ID");
            this.colsReportId.Position = 4;
            resources.ApplyResources(this.colsReportId, "colsReportId");
            this.colsReportId.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsReportId_WindowActions);
            // 
            // colsReportName
            // 
            this.colsReportName.MaxLength = 2000;
            this.colsReportName.Name = "colsReportName";
            this.colsReportName.NamedProperties.Put("EnumerateMethod", "");
            this.colsReportName.NamedProperties.Put("FieldFlags", "288");
            this.colsReportName.NamedProperties.Put("LovReference", "");
            this.colsReportName.NamedProperties.Put("ParentName", "colsReportId");
            this.colsReportName.NamedProperties.Put("SqlColumn", "REPORT_DEFINITION_API.GET_REPORT_TITLE(REPORT_ID)");
            this.colsReportName.Position = 5;
            resources.ApplyResources(this.colsReportName, "colsReportName");
            // 
            // colsFooterId
            // 
            this.colsFooterId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsFooterId.MaxLength = 20;
            this.colsFooterId.Name = "colsFooterId";
            this.colsFooterId.NamedProperties.Put("EnumerateMethod", "");
            this.colsFooterId.NamedProperties.Put("FieldFlags", "294");
            this.colsFooterId.NamedProperties.Put("LovReference", "FOOTER_DEFINITION(COMPANY)");
            this.colsFooterId.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsFooterId.NamedProperties.Put("SqlColumn", "FOOTER_ID");
            this.colsFooterId.Position = 8;
            resources.ApplyResources(this.colsFooterId, "colsFooterId");
            // 
            // colsFooterName
            // 
            this.colsFooterName.MaxLength = 2000;
            this.colsFooterName.Name = "colsFooterName";
            this.colsFooterName.NamedProperties.Put("EnumerateMethod", "");
            this.colsFooterName.NamedProperties.Put("FieldFlags", "288");
            this.colsFooterName.NamedProperties.Put("LovReference", "");
            this.colsFooterName.NamedProperties.Put("ParentName", "colsFooterId");
            this.colsFooterName.NamedProperties.Put("SqlColumn", "FOOTER_DEFINITION_API.GET_FOOTER_DESCRIPTION(COMPANY,FOOTER_ID)");
            this.colsFooterName.Position = 9;
            resources.ApplyResources(this.colsFooterName, "colsFooterName");
            // 
            // colsContract
            // 
            this.colsContract.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsContract.MaxLength = 20;
            this.colsContract.Name = "colsContract";
            this.colsContract.NamedProperties.Put("EnumerateMethod", "");
            this.colsContract.NamedProperties.Put("FieldFlags", "163");
            this.colsContract.NamedProperties.Put("LovReference", "");
            this.colsContract.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsContract.NamedProperties.Put("SqlColumn", "CONTRACT");
            this.colsContract.Position = 7;
            resources.ApplyResources(this.colsContract, "colsContract");
            this.colsContract.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsContract_WindowActions);
            // 
            // colsModule
            // 
            this.colsModule.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsModule.MaxLength = 2000;
            this.colsModule.Name = "colsModule";
            this.colsModule.NamedProperties.Put("EnumerateMethod", "");
            this.colsModule.NamedProperties.Put("FieldFlags", "288");
            this.colsModule.NamedProperties.Put("LovReference", "");
            this.colsModule.NamedProperties.Put("ParentName", "colsReportId");
            this.colsModule.NamedProperties.Put("SqlColumn", "&AO.Footer_Connection_Master_API.Get_Module(REPORT_ID)");
            this.colsModule.Position = 6;
            resources.ApplyResources(this.colsModule, "colsModule");
            // 
            // colsContractDependent
            // 
            this.colsContractDependent.MaxLength = 2000;
            this.colsContractDependent.Name = "colsContractDependent";
            this.colsContractDependent.NamedProperties.Put("EnumerateMethod", "");
            this.colsContractDependent.NamedProperties.Put("FieldFlags", "4352");
            this.colsContractDependent.NamedProperties.Put("LovReference", "");
            this.colsContractDependent.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsContractDependent.NamedProperties.Put("SqlColumn", "Footer_Connection_Master_API.Get_Contract_Dependent_Db(REPORT_ID)");
            this.colsContractDependent.Position = 10;
            resources.ApplyResources(this.colsContractDependent, "colsContractDependent");
            // 
            // tbwFooterConnection
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.ColsCompany);
            this.Controls.Add(this.colsReportId);
            this.Controls.Add(this.colsReportName);
            this.Controls.Add(this.colsModule);
            this.Controls.Add(this.colsContract);
            this.Controls.Add(this.colsFooterId);
            this.Controls.Add(this.colsFooterName);
            this.Controls.Add(this.colsContractDependent);
            this.Name = "tbwFooterConnection";
            this.NamedProperties.Put("DefaultOrderBy", "REPORT_ID");
            this.NamedProperties.Put("LogicalUnit", "FooterConnection");
            this.NamedProperties.Put("Module", "ACCRUL");
            this.NamedProperties.Put("PackageName", "FOOTER_CONNECTION_API");
            this.NamedProperties.Put("SourceFlags", "16833");
            this.NamedProperties.Put("ViewName", "FOOTER_CONNECTION");
            this.Controls.SetChildIndex(this.colsContractDependent, 0);
            this.Controls.SetChildIndex(this.colsFooterName, 0);
            this.Controls.SetChildIndex(this.colsFooterId, 0);
            this.Controls.SetChildIndex(this.colsContract, 0);
            this.Controls.SetChildIndex(this.colsModule, 0);
            this.Controls.SetChildIndex(this.colsReportName, 0);
            this.Controls.SetChildIndex(this.colsReportId, 0);
            this.Controls.SetChildIndex(this.ColsCompany, 0);
            this.Controls.SetChildIndex(this.@__colObjversion, 0);
            this.Controls.SetChildIndex(this.@__colObjid, 0);
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

        protected cColumn ColsCompany;
        protected cColumn colsReportId;
        protected cColumn colsReportName;
        protected cColumn colsFooterId;
        public cColumn colsFooterName;
        protected cColumn colsContract;
        protected cColumn colsModule;
        protected cCheckBoxColumn colsContractDependent;
    }
}
