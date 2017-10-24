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
	
	public partial class frmStatFeeDetail
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cDataField dfsCompany;
		protected cBackgroundText labelccTaxCode;
		public cRecListDataField ccTaxCode;
		public cDataField dfFeeCode;
		protected cBackgroundText labeldfsDescription;
		public cDataField dfsDescription;
		protected cBackgroundText labeldfsFeeType;
		public cDataField dfsFeeType;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStatFeeDetail));
            this.menuFrmMethods_menu_Change_Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.dfsCompany = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelccTaxCode = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.ccTaxCode = new Ifs.Fnd.ApplicationForms.cRecListDataField();
            this.dfFeeCode = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsDescription = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsDescription = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsFeeType = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsFeeType = new Ifs.Fnd.ApplicationForms.cDataField();
            this.menuFrmMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem__Change = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.tblStatFeeDet = new Ifs.Application.Accrul.cChildTableFinBase();
            this.tblStatFeeDet_colsFeeCode = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblStatFeeDet_colsCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblStatFeeDet_colsAttFeeCode = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblStatFeeDet_colDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblStatFeeDet_colnFeeRate = new Ifs.Fnd.ApplicationForms.cColumn();
            this.menuFrmMethods.SuspendLayout();
            this.tblStatFeeDet.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuFrmMethods_menu_Change_Company___);
            this.commandManager.ContextMenus.Add(this.menuFrmMethods);
            // 
            // menuFrmMethods_menu_Change_Company___
            // 
            resources.ApplyResources(this.menuFrmMethods_menu_Change_Company___, "menuFrmMethods_menu_Change_Company___");
            this.menuFrmMethods_menu_Change_Company___.Name = "menuFrmMethods_menu_Change_Company___";
            this.menuFrmMethods_menu_Change_Company___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Change_Execute);
            this.menuFrmMethods_menu_Change_Company___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Change_Inquire);
            // 
            // dfsCompany
            // 
            this.dfsCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsCompany, "dfsCompany");
            this.dfsCompany.Name = "dfsCompany";
            this.dfsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.dfsCompany.NamedProperties.Put("FieldFlags", "67");
            this.dfsCompany.NamedProperties.Put("LovReference", "COMPANY_FINANCE");
            this.dfsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            // 
            // labelccTaxCode
            // 
            resources.ApplyResources(this.labelccTaxCode, "labelccTaxCode");
            this.labelccTaxCode.Name = "labelccTaxCode";
            // 
            // ccTaxCode
            // 
            resources.ApplyResources(this.ccTaxCode, "ccTaxCode");
            this.ccTaxCode.Name = "ccTaxCode";
            this.ccTaxCode.NamedProperties.Put("EnumerateMethod", "");
            this.ccTaxCode.NamedProperties.Put("LovReference", "");
            this.ccTaxCode.NamedProperties.Put("ResizeableChildObject", "");
            this.ccTaxCode.NamedProperties.Put("SqlColumn", "FEE_CODE");
            this.ccTaxCode.NamedProperties.Put("ValidateMethod", "");
            this.ccTaxCode.NamedProperties.Put("XDataLength", "");
            // 
            // dfFeeCode
            // 
            this.dfFeeCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.dfFeeCode.Name = "dfFeeCode";
            this.dfFeeCode.NamedProperties.Put("EnumerateMethod", "");
            this.dfFeeCode.NamedProperties.Put("LovReference", "");
            this.dfFeeCode.NamedProperties.Put("ResizeableChildObject", "");
            this.dfFeeCode.NamedProperties.Put("SqlColumn", "FEE_CODE");
            this.dfFeeCode.NamedProperties.Put("ValidateMethod", "");
            resources.ApplyResources(this.dfFeeCode, "dfFeeCode");
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
            this.dfsDescription.NamedProperties.Put("FieldFlags", "291");
            this.dfsDescription.NamedProperties.Put("LovReference", "");
            this.dfsDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsDescription.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            this.dfsDescription.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsFeeType
            // 
            resources.ApplyResources(this.labeldfsFeeType, "labeldfsFeeType");
            this.labeldfsFeeType.Name = "labeldfsFeeType";
            // 
            // dfsFeeType
            // 
            resources.ApplyResources(this.dfsFeeType, "dfsFeeType");
            this.dfsFeeType.Name = "dfsFeeType";
            this.dfsFeeType.NamedProperties.Put("EnumerateMethod", "");
            this.dfsFeeType.NamedProperties.Put("FieldFlags", "288");
            this.dfsFeeType.NamedProperties.Put("LovReference", "");
            this.dfsFeeType.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsFeeType.NamedProperties.Put("SqlColumn", "FEE_TYPE");
            this.dfsFeeType.NamedProperties.Put("ValidateMethod", "");
            this.dfsFeeType.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsFeeType_WindowActions);
            // 
            // menuFrmMethods
            // 
            this.menuFrmMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem__Change});
            this.menuFrmMethods.Name = "menuFrmMethods";
            resources.ApplyResources(this.menuFrmMethods, "menuFrmMethods");
            // 
            // menuItem__Change
            // 
            this.menuItem__Change.Command = this.menuFrmMethods_menu_Change_Company___;
            this.menuItem__Change.Name = "menuItem__Change";
            resources.ApplyResources(this.menuItem__Change, "menuItem__Change");
            this.menuItem__Change.Text = "&Change Company...";
            // 
            // tblStatFeeDet
            // 
            this.tblStatFeeDet.Controls.Add(this.tblStatFeeDet_colsFeeCode);
            this.tblStatFeeDet.Controls.Add(this.tblStatFeeDet_colsCompany);
            this.tblStatFeeDet.Controls.Add(this.tblStatFeeDet_colsAttFeeCode);
            this.tblStatFeeDet.Controls.Add(this.tblStatFeeDet_colDescription);
            this.tblStatFeeDet.Controls.Add(this.tblStatFeeDet_colnFeeRate);
            resources.ApplyResources(this.tblStatFeeDet, "tblStatFeeDet");
            this.tblStatFeeDet.Name = "tblStatFeeDet";
            this.tblStatFeeDet.NamedProperties.Put("DefaultOrderBy", "");
            this.tblStatFeeDet.NamedProperties.Put("DefaultWhere", "FEE_CODE = :i_hWndFrame.frmStatFeeDetail.dfFeeCode\r\nAND COMPANY = :global.company" +
                    "");
            this.tblStatFeeDet.NamedProperties.Put("LogicalUnit", "StatutoryFeeDetail");
            this.tblStatFeeDet.NamedProperties.Put("PackageName", "STATUTORY_FEE_DETAIL_API");
            this.tblStatFeeDet.NamedProperties.Put("ResizeableChildObject", "LLFF");
            this.tblStatFeeDet.NamedProperties.Put("ViewName", "STATUTORY_FEE_DETAIL");
            this.tblStatFeeDet.NamedProperties.Put("Warnings", "FALSE");
            this.tblStatFeeDet.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblStatFeeDet_WindowActions);
            this.tblStatFeeDet.Controls.SetChildIndex(this.tblStatFeeDet_colnFeeRate, 0);
            this.tblStatFeeDet.Controls.SetChildIndex(this.tblStatFeeDet_colDescription, 0);
            this.tblStatFeeDet.Controls.SetChildIndex(this.tblStatFeeDet_colsAttFeeCode, 0);
            this.tblStatFeeDet.Controls.SetChildIndex(this.tblStatFeeDet_colsCompany, 0);
            this.tblStatFeeDet.Controls.SetChildIndex(this.tblStatFeeDet_colsFeeCode, 0);
            // 
            // tblStatFeeDet_colsFeeCode
            // 
            resources.ApplyResources(this.tblStatFeeDet_colsFeeCode, "tblStatFeeDet_colsFeeCode");
            this.tblStatFeeDet_colsFeeCode.MaxLength = 20;
            this.tblStatFeeDet_colsFeeCode.Name = "tblStatFeeDet_colsFeeCode";
            this.tblStatFeeDet_colsFeeCode.NamedProperties.Put("EnumerateMethod", "");
            this.tblStatFeeDet_colsFeeCode.NamedProperties.Put("FieldFlags", "67");
            this.tblStatFeeDet_colsFeeCode.NamedProperties.Put("LovReference", "STATUTORY_FEE(COMPANY)");
            this.tblStatFeeDet_colsFeeCode.NamedProperties.Put("SqlColumn", "FEE_CODE");
            this.tblStatFeeDet_colsFeeCode.Position = 3;
            // 
            // tblStatFeeDet_colsCompany
            // 
            this.tblStatFeeDet_colsCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblStatFeeDet_colsCompany, "tblStatFeeDet_colsCompany");
            this.tblStatFeeDet_colsCompany.MaxLength = 20;
            this.tblStatFeeDet_colsCompany.Name = "tblStatFeeDet_colsCompany";
            this.tblStatFeeDet_colsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.tblStatFeeDet_colsCompany.NamedProperties.Put("FieldFlags", "67");
            this.tblStatFeeDet_colsCompany.NamedProperties.Put("LovReference", "");
            this.tblStatFeeDet_colsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.tblStatFeeDet_colsCompany.Position = 4;
            // 
            // tblStatFeeDet_colsAttFeeCode
            // 
            this.tblStatFeeDet_colsAttFeeCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblStatFeeDet_colsAttFeeCode.MaxLength = 20;
            this.tblStatFeeDet_colsAttFeeCode.Name = "tblStatFeeDet_colsAttFeeCode";
            this.tblStatFeeDet_colsAttFeeCode.NamedProperties.Put("EnumerateMethod", "");
            this.tblStatFeeDet_colsAttFeeCode.NamedProperties.Put("FieldFlags", "167");
            this.tblStatFeeDet_colsAttFeeCode.NamedProperties.Put("LovReference", "STATUTORY_FEE_VSR(COMPANY)");
            this.tblStatFeeDet_colsAttFeeCode.NamedProperties.Put("ResizeableChildObject", "");
            this.tblStatFeeDet_colsAttFeeCode.NamedProperties.Put("SqlColumn", "ATT_FEE_CODE");
            this.tblStatFeeDet_colsAttFeeCode.NamedProperties.Put("ValidateMethod", "");
            this.tblStatFeeDet_colsAttFeeCode.Position = 5;
            resources.ApplyResources(this.tblStatFeeDet_colsAttFeeCode, "tblStatFeeDet_colsAttFeeCode");
            this.tblStatFeeDet_colsAttFeeCode.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsAttFeeCode_WindowActions);
            // 
            // tblStatFeeDet_colDescription
            // 
            this.tblStatFeeDet_colDescription.MaxLength = 4000;
            this.tblStatFeeDet_colDescription.Name = "tblStatFeeDet_colDescription";
            this.tblStatFeeDet_colDescription.NamedProperties.Put("EnumerateMethod", "");
            this.tblStatFeeDet_colDescription.NamedProperties.Put("FieldFlags", "304");
            this.tblStatFeeDet_colDescription.NamedProperties.Put("LovReference", "");
            this.tblStatFeeDet_colDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.tblStatFeeDet_colDescription.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            this.tblStatFeeDet_colDescription.NamedProperties.Put("ValidateMethod", "");
            this.tblStatFeeDet_colDescription.Position = 6;
            resources.ApplyResources(this.tblStatFeeDet_colDescription, "tblStatFeeDet_colDescription");
            // 
            // tblStatFeeDet_colnFeeRate
            // 
            this.tblStatFeeDet_colnFeeRate.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblStatFeeDet_colnFeeRate.Name = "tblStatFeeDet_colnFeeRate";
            this.tblStatFeeDet_colnFeeRate.NamedProperties.Put("EnumerateMethod", "");
            this.tblStatFeeDet_colnFeeRate.NamedProperties.Put("FieldFlags", "288");
            this.tblStatFeeDet_colnFeeRate.NamedProperties.Put("LovReference", "");
            this.tblStatFeeDet_colnFeeRate.NamedProperties.Put("ResizeableChildObject", "");
            this.tblStatFeeDet_colnFeeRate.NamedProperties.Put("SqlColumn", "FEE_RATE");
            this.tblStatFeeDet_colnFeeRate.NamedProperties.Put("ValidateMethod", "");
            this.tblStatFeeDet_colnFeeRate.Position = 7;
            this.tblStatFeeDet_colnFeeRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblStatFeeDet_colnFeeRate, "tblStatFeeDet_colnFeeRate");
            // 
            // frmStatFeeDetail
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.tblStatFeeDet);
            this.Controls.Add(this.dfsFeeType);
            this.Controls.Add(this.dfsDescription);
            this.Controls.Add(this.dfFeeCode);
            this.Controls.Add(this.ccTaxCode);
            this.Controls.Add(this.dfsCompany);
            this.Controls.Add(this.labeldfsFeeType);
            this.Controls.Add(this.labeldfsDescription);
            this.Controls.Add(this.labelccTaxCode);
            this.MaximizeBox = true;
            this.Name = "frmStatFeeDetail";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "COMPANY = :global.company\r\nAND (FEE_TYPE_DB = \'VAT\' OR FEE_TYPE_DB = \'SALETX\')");
            this.NamedProperties.Put("LogicalUnit", "StatutoryFee");
            this.NamedProperties.Put("PackageName", "STATUTORY_FEE_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "0");
            this.NamedProperties.Put("SourceFlags", "1");
            this.NamedProperties.Put("ViewName", "STATUTORY_FEE_DEDUCT_MULTIPLE");
            this.NamedProperties.Put("Warnings", "TRUE");
            this.menuFrmMethods.ResumeLayout(false);
            this.tblStatFeeDet.ResumeLayout(false);
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
		
        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menu_Change_Company___;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuFrmMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Change;
        public cChildTableFinBase tblStatFeeDet;
        protected cColumn tblStatFeeDet_colsFeeCode;
        protected cColumn tblStatFeeDet_colsCompany;
        protected cColumn tblStatFeeDet_colsAttFeeCode;
        protected cColumn tblStatFeeDet_colDescription;
        protected cColumn tblStatFeeDet_colnFeeRate;
	}
}
