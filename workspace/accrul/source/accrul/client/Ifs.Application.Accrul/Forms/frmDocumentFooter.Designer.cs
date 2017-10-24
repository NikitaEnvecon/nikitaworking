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

    public partial class frmDocumentFooter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDocumentFooter));
            this.dfsName = new Ifs.Fnd.ApplicationForms.cDataField();
            this.cmbsCompany = new Ifs.Fnd.ApplicationForms.cRecListDataField();
            this.labeldfsName = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.labelcmbsCompany = new Ifs.Fnd.ApplicationForms.cBackgroundText();
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
            // dfsName
            // 
            resources.ApplyResources(this.dfsName, "dfsName");
            this.dfsName.Name = "dfsName";
            this.dfsName.NamedProperties.Put("EnumerateMethod", "");
            this.dfsName.NamedProperties.Put("LovReference", "");
            this.dfsName.NamedProperties.Put("ResizeableChildObject", "LLLL");
            this.dfsName.NamedProperties.Put("SqlColumn", "NAME");
            this.dfsName.NamedProperties.Put("StatusText", "");
            this.dfsName.NamedProperties.Put("ValidateMethod", "");
            // 
            // cmbsCompany
            // 
            this.cmbsCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.cmbsCompany, "cmbsCompany");
            this.cmbsCompany.Name = "cmbsCompany";
            this.cmbsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.cmbsCompany.NamedProperties.Put("FieldFlags", "160");
            this.cmbsCompany.NamedProperties.Put("LovReference", "");
            this.cmbsCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.cmbsCompany.NamedProperties.Put("ValidateMethod", "");
            this.cmbsCompany.NamedProperties.Put("XDataLength", "");
            // 
            // labeldfsName
            // 
            resources.ApplyResources(this.labeldfsName, "labeldfsName");
            this.labeldfsName.Name = "labeldfsName";
            // 
            // labelcmbsCompany
            // 
            resources.ApplyResources(this.labelcmbsCompany, "labelcmbsCompany");
            this.labelcmbsCompany.Name = "labelcmbsCompany";
            // 
            // frmDocumentFooter
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.dfsName);
            this.Controls.Add(this.cmbsCompany);
            this.Controls.Add(this.labeldfsName);
            this.Controls.Add(this.labelcmbsCompany);
            this.Name = "frmDocumentFooter";
            this.NamedProperties.Put("LogicalUnit", "Company");
            this.NamedProperties.Put("Module", "ACCRUL");
            this.NamedProperties.Put("ViewName", "COMPANY");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.frmDocumentFooter_WindowActions);
            this.Controls.SetChildIndex(this.picTab, 0);
            this.Controls.SetChildIndex(this.labelcmbsCompany, 0);
            this.Controls.SetChildIndex(this.labeldfsName, 0);
            this.Controls.SetChildIndex(this.cmbsCompany, 0);
            this.Controls.SetChildIndex(this.dfsName, 0);
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

        public cDataField dfsName;
        public cRecListDataField cmbsCompany;
        protected cBackgroundText labeldfsName;
        protected cBackgroundText labelcmbsCompany;
    }
}
