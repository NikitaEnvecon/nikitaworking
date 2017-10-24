#region Copyright (c) IFS Research & Development
// ======================================================================================================
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
// ======================================================================================================
#endregion
#region History
#endregion

using System;
using System.Text;
using System.Drawing;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;
using System.ComponentModel;
using Ifs.Application.Accrul;
using Ifs.Application.Appsrv;
using Ifs.Application.Enterp;
using Ifs.Fnd.ApplicationForms;
using PPJ.Runtime;
using PPJ.Runtime.Sql;
using PPJ.Runtime.Vis;
using PPJ.Runtime.Windows;
using PPJ.Runtime.Windows.QO;

namespace Ifs.Application.Accrul_
{
	
	public partial class frmTaxBookStructure
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cDataField dfsCompany;
		protected cBackgroundText labelcmbStructureId;
		public cRecListDataField cmbStructureId;
		protected cBackgroundText labeldfsDescription;
		public cDataField dfsDescription;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTaxBookStructure));
            this.menuFrmMethods_menuChange__Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.dfsCompany = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelcmbStructureId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbStructureId = new Ifs.Fnd.ApplicationForms.cRecListDataField();
            this.labeldfsDescription = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsDescription = new Ifs.Fnd.ApplicationForms.cDataField();
            this.menuFrmMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_Change = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuFrmMethods.SuspendLayout();
            this.SuspendLayout();
            // 
            // picTab
            // 
            resources.ApplyResources(this.picTab, "picTab");
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuFrmMethods_menuChange__Company___);
            this.commandManager.ContextMenus.Add(this.menuFrmMethods);
            // 
            // menuFrmMethods_menuChange__Company___
            // 
            resources.ApplyResources(this.menuFrmMethods_menuChange__Company___, "menuFrmMethods_menuChange__Company___");
            this.menuFrmMethods_menuChange__Company___.Name = "menuFrmMethods_menuChange__Company___";
            this.menuFrmMethods_menuChange__Company___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Change_Execute);
            this.menuFrmMethods_menuChange__Company___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Change_Inquire);
            // 
            // dfsCompany
            // 
            resources.ApplyResources(this.dfsCompany, "dfsCompany");
            this.dfsCompany.Name = "dfsCompany";
            this.dfsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.dfsCompany.NamedProperties.Put("FieldFlags", "67");
            this.dfsCompany.NamedProperties.Put("LovReference", "COMPANY_FINANCE");
            this.dfsCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.dfsCompany.NamedProperties.Put("ValidateMethod", "");
            // 
            // labelcmbStructureId
            // 
            resources.ApplyResources(this.labelcmbStructureId, "labelcmbStructureId");
            this.labelcmbStructureId.Name = "labelcmbStructureId";
            // 
            // cmbStructureId
            // 
            this.cmbStructureId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.cmbStructureId, "cmbStructureId");
            this.cmbStructureId.Name = "cmbStructureId";
            this.cmbStructureId.NamedProperties.Put("EnumerateMethod", "");
            this.cmbStructureId.NamedProperties.Put("FieldFlags", "163");
            this.cmbStructureId.NamedProperties.Put("Format", "9");
            this.cmbStructureId.NamedProperties.Put("LovReference", "");
            this.cmbStructureId.NamedProperties.Put("ResizableChildObject", "");
            this.cmbStructureId.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbStructureId.NamedProperties.Put("SqlColumn", "STRUCTURE_ID");
            this.cmbStructureId.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsDescription
            // 
            resources.ApplyResources(this.labeldfsDescription, "labeldfsDescription");
            this.labeldfsDescription.Name = "labeldfsDescription";
            // 
            // dfsDescription
            // 
            resources.ApplyResources(this.dfsDescription, "dfsDescription");
            this.dfsDescription.Name = "dfsDescription";
            this.dfsDescription.NamedProperties.Put("EnumerateMethod", "");
            this.dfsDescription.NamedProperties.Put("FieldFlags", "294");
            this.dfsDescription.NamedProperties.Put("LovReference", "");
            this.dfsDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsDescription.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            this.dfsDescription.NamedProperties.Put("ValidateMethod", "");
            // 
            // menuFrmMethods
            // 
            this.menuFrmMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_Change});
            this.menuFrmMethods.Name = "menuFrmMethods";
            resources.ApplyResources(this.menuFrmMethods, "menuFrmMethods");
            // 
            // menuItem_Change
            // 
            this.menuItem_Change.Command = this.menuFrmMethods_menuChange__Company___;
            this.menuItem_Change.Name = "menuItem_Change";
            resources.ApplyResources(this.menuItem_Change, "menuItem_Change");
            this.menuItem_Change.Text = "Change &Company...";
            // 
            // frmTaxBookStructure
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.dfsDescription);
            this.Controls.Add(this.cmbStructureId);
            this.Controls.Add(this.dfsCompany);
            this.Controls.Add(this.labeldfsDescription);
            this.Controls.Add(this.labelcmbStructureId);
            this.Name = "frmTaxBookStructure";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "company=:global.company");
            this.NamedProperties.Put("LogicalUnit", "TaxBookStructure");
            this.NamedProperties.Put("PackageName", "TAX_BOOK_STRUCTURE_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizableChildObject", "");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "4545");
            this.NamedProperties.Put("ViewName", "TAX_BOOK_STRUCTURE");
            this.NamedProperties.Put("Warnings", "TRUE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.frmTaxBookStructure_WindowActions);
            this.Controls.SetChildIndex(this.picTab, 0);
            this.Controls.SetChildIndex(this.labelcmbStructureId, 0);
            this.Controls.SetChildIndex(this.labeldfsDescription, 0);
            this.Controls.SetChildIndex(this.dfsCompany, 0);
            this.Controls.SetChildIndex(this.cmbStructureId, 0);
            this.Controls.SetChildIndex(this.dfsDescription, 0);
            this.menuFrmMethods.ResumeLayout(false);
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

        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menuChange__Company___;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuFrmMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change;
	}
}
