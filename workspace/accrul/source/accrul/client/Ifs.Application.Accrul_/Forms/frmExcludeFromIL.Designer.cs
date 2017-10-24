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
	
	public partial class frmExcludeFromIL
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		// Bug 82568, Begin
		protected cBackgroundText labeldfsVoucherType;
		public cDataField dfsVoucherType;
		// Bug 82568, End
		// Bug 82568, Begin
		protected cBackgroundText labeldfsDescription;
		public cDataField dfsDescription;
		// Bug 82568, End
		public cDataField dfCompany;
        // Bug 73298 Begin - Changed the derived base class.
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExcludeFromIL));
            this.menuFrmMethods_menuChange__Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.labeldfsVoucherType = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsVoucherType = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsDescription = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsDescription = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfCompany = new Ifs.Fnd.ApplicationForms.cDataField();
            this.menuFrmMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuSeparator1 = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.menuItem_Change = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.tblExcludedIL = new Ifs.Application.Accrul.cChildTableFinBase();
            this.tblExcludedIL_colsCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExcludedIL_colsLedgerId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExcludedIL_colInternalLedgerDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExcludedIL_colsVoucherType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.menuFrmMethods.SuspendLayout();
            this.tblExcludedIL.SuspendLayout();
            this.SuspendLayout();
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
            // labeldfsVoucherType
            // 
            resources.ApplyResources(this.labeldfsVoucherType, "labeldfsVoucherType");
            this.labeldfsVoucherType.Name = "labeldfsVoucherType";
            // 
            // dfsVoucherType
            // 
            this.dfsVoucherType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsVoucherType, "dfsVoucherType");
            this.dfsVoucherType.Name = "dfsVoucherType";
            this.dfsVoucherType.NamedProperties.Put("EnumerateMethod", "");
            this.dfsVoucherType.NamedProperties.Put("FieldFlags", "163");
            this.dfsVoucherType.NamedProperties.Put("LovReference", "");
            this.dfsVoucherType.NamedProperties.Put("SqlColumn", "VOUCHER_TYPE");
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
            this.dfsDescription.NamedProperties.Put("FieldFlags", "295");
            this.dfsDescription.NamedProperties.Put("LovReference", "");
            this.dfsDescription.NamedProperties.Put("ParentName", "dfsVoucherType");
            this.dfsDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsDescription.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            this.dfsDescription.NamedProperties.Put("ValidateMethod", "");
            // 
            // dfCompany
            // 
            this.dfCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfCompany, "dfCompany");
            this.dfCompany.Name = "dfCompany";
            this.dfCompany.NamedProperties.Put("EnumerateMethod", "");
            this.dfCompany.NamedProperties.Put("FieldFlags", "64");
            this.dfCompany.NamedProperties.Put("LovReference", "");
            this.dfCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.dfCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.dfCompany.NamedProperties.Put("ValidateMethod", "");
            // 
            // menuFrmMethods
            // 
            this.menuFrmMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSeparator1,
            this.menuItem_Change});
            this.menuFrmMethods.Name = "menuFrmMethods";
            resources.ApplyResources(this.menuFrmMethods, "menuFrmMethods");
            // 
            // menuSeparator1
            // 
            this.menuSeparator1.Name = "menuSeparator1";
            resources.ApplyResources(this.menuSeparator1, "menuSeparator1");
            // 
            // menuItem_Change
            // 
            this.menuItem_Change.Command = this.menuFrmMethods_menuChange__Company___;
            this.menuItem_Change.Name = "menuItem_Change";
            resources.ApplyResources(this.menuItem_Change, "menuItem_Change");
            this.menuItem_Change.Text = "Change &Company...";
            // 
            // tblExcludedIL
            // 
            this.tblExcludedIL.Controls.Add(this.tblExcludedIL_colsCompany);
            this.tblExcludedIL.Controls.Add(this.tblExcludedIL_colsLedgerId);
            this.tblExcludedIL.Controls.Add(this.tblExcludedIL_colInternalLedgerDescription);
            this.tblExcludedIL.Controls.Add(this.tblExcludedIL_colsVoucherType);
            resources.ApplyResources(this.tblExcludedIL, "tblExcludedIL");
            this.tblExcludedIL.Name = "tblExcludedIL";
            this.tblExcludedIL.NamedProperties.Put("DefaultOrderBy", "");
            this.tblExcludedIL.NamedProperties.Put("DefaultWhere", "VOUCHER_TYPE =:i_hWndFrame.frmExcludeFromIL.dfsVoucherType");
            this.tblExcludedIL.NamedProperties.Put("LogicalUnit", "GlVoucherIlPosting");
            this.tblExcludedIL.NamedProperties.Put("PackageName", "GL_VOUCHER_IL_POSTING_API");
            this.tblExcludedIL.NamedProperties.Put("ResizeableChildObject", "MLMM");
            this.tblExcludedIL.NamedProperties.Put("SourceFlags", "448");
            this.tblExcludedIL.NamedProperties.Put("ViewName", "GL_VOUCHER_IL_POSTING");
            this.tblExcludedIL.NamedProperties.Put("Warnings", "FALSE");
            this.tblExcludedIL.Controls.SetChildIndex(this.tblExcludedIL_colsVoucherType, 0);
            this.tblExcludedIL.Controls.SetChildIndex(this.tblExcludedIL_colInternalLedgerDescription, 0);
            this.tblExcludedIL.Controls.SetChildIndex(this.tblExcludedIL_colsLedgerId, 0);
            this.tblExcludedIL.Controls.SetChildIndex(this.tblExcludedIL_colsCompany, 0);
            // 
            // tblExcludedIL_colsCompany
            // 
            this.tblExcludedIL_colsCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblExcludedIL_colsCompany, "tblExcludedIL_colsCompany");
            this.tblExcludedIL_colsCompany.MaxLength = 20;
            this.tblExcludedIL_colsCompany.Name = "tblExcludedIL_colsCompany";
            this.tblExcludedIL_colsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.tblExcludedIL_colsCompany.NamedProperties.Put("FieldFlags", "67");
            this.tblExcludedIL_colsCompany.NamedProperties.Put("LovReference", "");
            this.tblExcludedIL_colsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.tblExcludedIL_colsCompany.Position = 3;
            // 
            // tblExcludedIL_colsLedgerId
            // 
            this.tblExcludedIL_colsLedgerId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblExcludedIL_colsLedgerId.MaxLength = 10;
            this.tblExcludedIL_colsLedgerId.Name = "tblExcludedIL_colsLedgerId";
            this.tblExcludedIL_colsLedgerId.NamedProperties.Put("EnumerateMethod", "");
            this.tblExcludedIL_colsLedgerId.NamedProperties.Put("FieldFlags", "99");
            this.tblExcludedIL_colsLedgerId.NamedProperties.Put("LovReference", "INTERNAL_LEDGER(COMPANY)");
            this.tblExcludedIL_colsLedgerId.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExcludedIL_colsLedgerId.NamedProperties.Put("SqlColumn", "LEDGER_ID");
            this.tblExcludedIL_colsLedgerId.NamedProperties.Put("ValidateMethod", "");
            this.tblExcludedIL_colsLedgerId.Position = 4;
            resources.ApplyResources(this.tblExcludedIL_colsLedgerId, "tblExcludedIL_colsLedgerId");
            // 
            // tblExcludedIL_colInternalLedgerDescription
            // 
            this.tblExcludedIL_colInternalLedgerDescription.MaxLength = 2000;
            this.tblExcludedIL_colInternalLedgerDescription.Name = "tblExcludedIL_colInternalLedgerDescription";
            this.tblExcludedIL_colInternalLedgerDescription.NamedProperties.Put("EnumerateMethod", "");
            this.tblExcludedIL_colInternalLedgerDescription.NamedProperties.Put("FieldFlags", "272");
            this.tblExcludedIL_colInternalLedgerDescription.NamedProperties.Put("LovReference", "");
            this.tblExcludedIL_colInternalLedgerDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExcludedIL_colInternalLedgerDescription.NamedProperties.Put("SqlColumn", "INTERNAL_LEDGER_API.Get_Description(company,LEDGER_ID)");
            this.tblExcludedIL_colInternalLedgerDescription.NamedProperties.Put("ValidateMethod", "");
            this.tblExcludedIL_colInternalLedgerDescription.Position = 5;
            resources.ApplyResources(this.tblExcludedIL_colInternalLedgerDescription, "tblExcludedIL_colInternalLedgerDescription");
            // 
            // tblExcludedIL_colsVoucherType
            // 
            this.tblExcludedIL_colsVoucherType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblExcludedIL_colsVoucherType, "tblExcludedIL_colsVoucherType");
            this.tblExcludedIL_colsVoucherType.MaxLength = 3;
            this.tblExcludedIL_colsVoucherType.Name = "tblExcludedIL_colsVoucherType";
            this.tblExcludedIL_colsVoucherType.NamedProperties.Put("EnumerateMethod", "");
            this.tblExcludedIL_colsVoucherType.NamedProperties.Put("FieldFlags", "67");
            this.tblExcludedIL_colsVoucherType.NamedProperties.Put("LovReference", "CUST_CHECK_VOU_TYPE(COMPANY)");
            this.tblExcludedIL_colsVoucherType.NamedProperties.Put("SqlColumn", "VOUCHER_TYPE");
            this.tblExcludedIL_colsVoucherType.Position = 6;
            // 
            // frmExcludeFromIL
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.tblExcludedIL);
            this.Controls.Add(this.dfCompany);
            this.Controls.Add(this.dfsDescription);
            this.Controls.Add(this.dfsVoucherType);
            this.Controls.Add(this.labeldfsDescription);
            this.Controls.Add(this.labeldfsVoucherType);
            this.MaximizeBox = true;
            this.Name = "frmExcludeFromIL";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "company = :global.company");
            this.NamedProperties.Put("LogicalUnit", "VoucherType");
            this.NamedProperties.Put("PackageName", "VOUCHER_TYPE_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "0");
            this.NamedProperties.Put("SourceFlags", "0");
            this.NamedProperties.Put("ViewName", "VOUCHER_TYPE");
            this.NamedProperties.Put("Warnings", "TRUE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.frmExcludeFromIL_WindowActions);
            this.menuFrmMethods.ResumeLayout(false);
            this.tblExcludedIL.ResumeLayout(false);
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
        protected Fnd.Windows.Forms.FndToolStripSeparator menuSeparator1;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change;
        public cChildTableFinBase tblExcludedIL;
        protected cColumn tblExcludedIL_colsCompany;
        protected cColumn tblExcludedIL_colsLedgerId;
        protected cColumn tblExcludedIL_colInternalLedgerDescription;
        protected cColumn tblExcludedIL_colsVoucherType;
	}
}
