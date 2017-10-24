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
using Ifs.Application.Appsrv;
using Ifs.Application.Enterp;
using Ifs.Fnd.ApplicationForms;
using PPJ.Runtime;
using PPJ.Runtime.Sql;
using PPJ.Runtime.Vis;
using PPJ.Runtime.Windows;
using PPJ.Runtime.Windows.QO;

namespace Ifs.Application.Accrul
{
	
	public partial class frmCdCompl
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cDataField dfsCdPart;
		public cDataField dfsCompany;
		protected cBackgroundText labelcmbsCdPartValue;
		public cRecListDataField cmbsCdPartValue;
		protected cBackgroundText labeldfsCdPartDesc;
		public cDataField dfsCdPartDesc;
		protected cBackgroundText labeldfsCdPartName;
		public cDataField dfsCdPartName;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCdCompl));
            this.menuFrmMethods_menuChange__Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.dfsCdPart = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsCompany = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelcmbsCdPartValue = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbsCdPartValue = new Ifs.Fnd.ApplicationForms.cRecListDataField();
            this.labeldfsCdPartDesc = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsCdPartDesc = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsCdPartName = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsCdPartName = new Ifs.Fnd.ApplicationForms.cDataField();
            this.menuFrmMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_Change = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.tblCdCompl = new Ifs.Application.Accrul.cChildTableFinBase();
            this.tblCdCompl_colsCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblCdCompl_colsCdPart = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblCdCompl_colsCdPartValue = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblCdCompl_colsCdPartFill = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblCdCompl_colsCdPartFillName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblCdCompl_colsCdPartBlocked = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblCdCompl_colsFillValue = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblCdCompl_colsFillValueDesc = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblCdCompl_colsCdPartFillNameStr = new PPJ.Runtime.Windows.SalTableColumn();
            this.menuFrmMethods.SuspendLayout();
            this.tblCdCompl.SuspendLayout();
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
            // dfsCdPart
            // 
            resources.ApplyResources(this.dfsCdPart, "dfsCdPart");
            this.dfsCdPart.Name = "dfsCdPart";
            this.dfsCdPart.NamedProperties.Put("EnumerateMethod", "");
            this.dfsCdPart.NamedProperties.Put("FieldFlags", "130");
            this.dfsCdPart.NamedProperties.Put("LovReference", "");
            this.dfsCdPart.NamedProperties.Put("SqlColumn", "CODE_PART");
            // 
            // dfsCompany
            // 
            resources.ApplyResources(this.dfsCompany, "dfsCompany");
            this.dfsCompany.Name = "dfsCompany";
            this.dfsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.dfsCompany.NamedProperties.Put("FieldFlags", "128");
            this.dfsCompany.NamedProperties.Put("LovReference", "");
            this.dfsCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.dfsCompany.NamedProperties.Put("ValidateMethod", "");
            // 
            // labelcmbsCdPartValue
            // 
            resources.ApplyResources(this.labelcmbsCdPartValue, "labelcmbsCdPartValue");
            this.labelcmbsCdPartValue.Name = "labelcmbsCdPartValue";
            // 
            // cmbsCdPartValue
            // 
            resources.ApplyResources(this.cmbsCdPartValue, "cmbsCdPartValue");
            this.cmbsCdPartValue.Name = "cmbsCdPartValue";
            this.cmbsCdPartValue.NamedProperties.Put("EnumerateMethod", "");
            this.cmbsCdPartValue.NamedProperties.Put("FieldFlags", "163");
            this.cmbsCdPartValue.NamedProperties.Put("LovReference", "");
            this.cmbsCdPartValue.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbsCdPartValue.NamedProperties.Put("SqlColumn", "CODE_PART_VALUE");
            this.cmbsCdPartValue.NamedProperties.Put("ValidateMethod", "");
            this.cmbsCdPartValue.NamedProperties.Put("XDataLength", "20");
            this.cmbsCdPartValue.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbsCdPartValue_WindowActions);
            // 
            // labeldfsCdPartDesc
            // 
            resources.ApplyResources(this.labeldfsCdPartDesc, "labeldfsCdPartDesc");
            this.labeldfsCdPartDesc.Name = "labeldfsCdPartDesc";
            // 
            // dfsCdPartDesc
            // 
            resources.ApplyResources(this.dfsCdPartDesc, "dfsCdPartDesc");
            this.dfsCdPartDesc.Name = "dfsCdPartDesc";
            this.dfsCdPartDesc.NamedProperties.Put("EnumerateMethod", "");
            this.dfsCdPartDesc.NamedProperties.Put("FieldFlags", "288");
            this.dfsCdPartDesc.NamedProperties.Put("LovReference", "");
            this.dfsCdPartDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsCdPartDesc.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            this.dfsCdPartDesc.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsCdPartName
            // 
            resources.ApplyResources(this.labeldfsCdPartName, "labeldfsCdPartName");
            this.labeldfsCdPartName.Name = "labeldfsCdPartName";
            // 
            // dfsCdPartName
            // 
            resources.ApplyResources(this.dfsCdPartName, "dfsCdPartName");
            this.dfsCdPartName.Name = "dfsCdPartName";
            this.dfsCdPartName.NamedProperties.Put("EnumerateMethod", "");
            this.dfsCdPartName.NamedProperties.Put("FieldFlags", "290");
            this.dfsCdPartName.NamedProperties.Put("LovReference", "");
            this.dfsCdPartName.NamedProperties.Put("ParentName", "cmbsCdPartValue");
            this.dfsCdPartName.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsCdPartName.NamedProperties.Put("SqlColumn", "Enterp_Comp_Connect_V170_API.Get_Company_Translation(COMPANY, \'ACCRUL\', \'Accounti" +
                    "ngCodeParts\', CODE_PART) ");
            this.dfsCdPartName.NamedProperties.Put("ValidateMethod", "");
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
            resources.ApplyResources(this.menuItem_Change, "menuItem_Change");
            this.menuItem_Change.Name = "menuItem_Change";
            this.menuItem_Change.Text = "Change &Company...";
            // 
            // tblCdCompl
            // 
            this.tblCdCompl.Controls.Add(this.tblCdCompl_colsCompany);
            this.tblCdCompl.Controls.Add(this.tblCdCompl_colsCdPart);
            this.tblCdCompl.Controls.Add(this.tblCdCompl_colsCdPartValue);
            this.tblCdCompl.Controls.Add(this.tblCdCompl_colsCdPartFill);
            this.tblCdCompl.Controls.Add(this.tblCdCompl_colsCdPartFillName);
            this.tblCdCompl.Controls.Add(this.tblCdCompl_colsCdPartBlocked);
            this.tblCdCompl.Controls.Add(this.tblCdCompl_colsFillValue);
            this.tblCdCompl.Controls.Add(this.tblCdCompl_colsFillValueDesc);
            this.tblCdCompl.Controls.Add(this.tblCdCompl_colsCdPartFillNameStr);
            resources.ApplyResources(this.tblCdCompl, "tblCdCompl");
            this.tblCdCompl.Name = "tblCdCompl";
            this.tblCdCompl.NamedProperties.Put("DefaultOrderBy", "");
            this.tblCdCompl.NamedProperties.Put("DefaultWhere", "COMPANY = :i_hWndFrame.frmCdCompl.i_sCompany  AND\r\nCODE_PART =  :i_hWndFrame.frmC" +
                    "dCompl.dfsCdPart AND\r\nCODE_PART_VALUE =  :i_hWndFrame.frmCdCompl.cmbsCdPartValue" +
                    ".i_sMyValue");
            this.tblCdCompl.NamedProperties.Put("LogicalUnit", "AccountingCodestrCompl");
            this.tblCdCompl.NamedProperties.Put("PackageName", "ACCOUNTING_CODESTR_COMPL_API");
            this.tblCdCompl.NamedProperties.Put("ResizeableChildObject", "LLMM");
            this.tblCdCompl.NamedProperties.Put("ViewName", "ACCOUNTING_CODESTR_COMPL");
            this.tblCdCompl.NamedProperties.Put("Warnings", "FALSE");
            this.tblCdCompl.DataRecordGetDefaultsEvent += new System.EventHandler<Ifs.Fnd.ApplicationForms.FndReturnEventArgsSalBoolean>(this.tblCdCompl_DataRecordGetDefaultsEvent);
            this.tblCdCompl.DataRecordNewEvent += new Ifs.Fnd.ApplicationForms.cDataSource.DataRecordNewEventHandler(this.tblCdCompl_DataRecordNewEvent);
            this.tblCdCompl.DataRecordRemoveEvent += new Ifs.Fnd.ApplicationForms.cDataSource.DataRecordRemoveEventHandler(this.tblCdCompl_DataRecordRemoveEvent);
            this.tblCdCompl.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblCdCompl_WindowActions);
            this.tblCdCompl.Controls.SetChildIndex(this.tblCdCompl_colsCdPartFillNameStr, 0);
            this.tblCdCompl.Controls.SetChildIndex(this.tblCdCompl_colsFillValueDesc, 0);
            this.tblCdCompl.Controls.SetChildIndex(this.tblCdCompl_colsFillValue, 0);
            this.tblCdCompl.Controls.SetChildIndex(this.tblCdCompl_colsCdPartBlocked, 0);
            this.tblCdCompl.Controls.SetChildIndex(this.tblCdCompl_colsCdPartFillName, 0);
            this.tblCdCompl.Controls.SetChildIndex(this.tblCdCompl_colsCdPartFill, 0);
            this.tblCdCompl.Controls.SetChildIndex(this.tblCdCompl_colsCdPartValue, 0);
            this.tblCdCompl.Controls.SetChildIndex(this.tblCdCompl_colsCdPart, 0);
            this.tblCdCompl.Controls.SetChildIndex(this.tblCdCompl_colsCompany, 0);
            // 
            // tblCdCompl_colsCompany
            // 
            resources.ApplyResources(this.tblCdCompl_colsCompany, "tblCdCompl_colsCompany");
            this.tblCdCompl_colsCompany.MaxLength = 20;
            this.tblCdCompl_colsCompany.Name = "tblCdCompl_colsCompany";
            this.tblCdCompl_colsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.tblCdCompl_colsCompany.NamedProperties.Put("FieldFlags", "131");
            this.tblCdCompl_colsCompany.NamedProperties.Put("LovReference", "");
            this.tblCdCompl_colsCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.tblCdCompl_colsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.tblCdCompl_colsCompany.NamedProperties.Put("ValidateMethod", "");
            this.tblCdCompl_colsCompany.Position = 3;
            // 
            // tblCdCompl_colsCdPart
            // 
            this.tblCdCompl_colsCdPart.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblCdCompl_colsCdPart, "tblCdCompl_colsCdPart");
            this.tblCdCompl_colsCdPart.MaxLength = 1;
            this.tblCdCompl_colsCdPart.Name = "tblCdCompl_colsCdPart";
            this.tblCdCompl_colsCdPart.NamedProperties.Put("EnumerateMethod", "");
            this.tblCdCompl_colsCdPart.NamedProperties.Put("FieldFlags", "135");
            this.tblCdCompl_colsCdPart.NamedProperties.Put("LovReference", "");
            this.tblCdCompl_colsCdPart.NamedProperties.Put("SqlColumn", "CODE_PART");
            this.tblCdCompl_colsCdPart.Position = 4;
            // 
            // tblCdCompl_colsCdPartValue
            // 
            this.tblCdCompl_colsCdPartValue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblCdCompl_colsCdPartValue, "tblCdCompl_colsCdPartValue");
            this.tblCdCompl_colsCdPartValue.MaxLength = 20;
            this.tblCdCompl_colsCdPartValue.Name = "tblCdCompl_colsCdPartValue";
            this.tblCdCompl_colsCdPartValue.NamedProperties.Put("EnumerateMethod", "");
            this.tblCdCompl_colsCdPartValue.NamedProperties.Put("FieldFlags", "134");
            this.tblCdCompl_colsCdPartValue.NamedProperties.Put("LovReference", "");
            this.tblCdCompl_colsCdPartValue.NamedProperties.Put("ResizeableChildObject", "");
            this.tblCdCompl_colsCdPartValue.NamedProperties.Put("SqlColumn", "CODE_PART_VALUE");
            this.tblCdCompl_colsCdPartValue.NamedProperties.Put("ValidateMethod", "");
            this.tblCdCompl_colsCdPartValue.Position = 5;
            // 
            // tblCdCompl_colsCdPartFill
            // 
            resources.ApplyResources(this.tblCdCompl_colsCdPartFill, "tblCdCompl_colsCdPartFill");
            this.tblCdCompl_colsCdPartFill.MaxLength = 1;
            this.tblCdCompl_colsCdPartFill.Name = "tblCdCompl_colsCdPartFill";
            this.tblCdCompl_colsCdPartFill.NamedProperties.Put("EnumerateMethod", "");
            this.tblCdCompl_colsCdPartFill.NamedProperties.Put("FieldFlags", "131");
            this.tblCdCompl_colsCdPartFill.NamedProperties.Put("LovReference", "");
            this.tblCdCompl_colsCdPartFill.NamedProperties.Put("ResizeableChildObject", "");
            this.tblCdCompl_colsCdPartFill.NamedProperties.Put("SqlColumn", "CODEFILL_CODE_PART");
            this.tblCdCompl_colsCdPartFill.NamedProperties.Put("ValidateMethod", "");
            this.tblCdCompl_colsCdPartFill.Position = 6;
            // 
            // tblCdCompl_colsCdPartFillName
            // 
            this.tblCdCompl_colsCdPartFillName.Name = "tblCdCompl_colsCdPartFillName";
            this.tblCdCompl_colsCdPartFillName.NamedProperties.Put("EnumerateMethod", "");
            this.tblCdCompl_colsCdPartFillName.NamedProperties.Put("LovReference", "");
            this.tblCdCompl_colsCdPartFillName.NamedProperties.Put("ResizeableChildObject", "");
            this.tblCdCompl_colsCdPartFillName.NamedProperties.Put("SqlColumn", "Accounting_Codestr_Compl_API.Get_Translated_Code_Fill_Name(COMPANY, \'ACCRUL\', \'Ac" +
                    "countingCodeParts\', CODEFILL_CODE_PART)");
            this.tblCdCompl_colsCdPartFillName.NamedProperties.Put("ValidateMethod", "");
            this.tblCdCompl_colsCdPartFillName.Position = 7;
            resources.ApplyResources(this.tblCdCompl_colsCdPartFillName, "tblCdCompl_colsCdPartFillName");
            // 
            // tblCdCompl_colsCdPartBlocked
            // 
            resources.ApplyResources(this.tblCdCompl_colsCdPartBlocked, "tblCdCompl_colsCdPartBlocked");
            this.tblCdCompl_colsCdPartBlocked.Name = "tblCdCompl_colsCdPartBlocked";
            this.tblCdCompl_colsCdPartBlocked.Position = 8;
            // 
            // tblCdCompl_colsFillValue
            // 
            this.tblCdCompl_colsFillValue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblCdCompl_colsFillValue.MaxLength = 20;
            this.tblCdCompl_colsFillValue.Name = "tblCdCompl_colsFillValue";
            this.tblCdCompl_colsFillValue.NamedProperties.Put("EnumerateMethod", "");
            this.tblCdCompl_colsFillValue.NamedProperties.Put("FieldFlags", "262");
            this.tblCdCompl_colsFillValue.NamedProperties.Put("LovReference", "");
            this.tblCdCompl_colsFillValue.NamedProperties.Put("ResizeableChildObject", "");
            this.tblCdCompl_colsFillValue.NamedProperties.Put("SqlColumn", "CODEFILL_VALUE");
            this.tblCdCompl_colsFillValue.NamedProperties.Put("ValidateMethod", "");
            this.tblCdCompl_colsFillValue.Position = 9;
            resources.ApplyResources(this.tblCdCompl_colsFillValue, "tblCdCompl_colsFillValue");
            this.tblCdCompl_colsFillValue.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblCdCompl_colsFillValue_WindowActions);
            // 
            // tblCdCompl_colsFillValueDesc
            // 
            this.tblCdCompl_colsFillValueDesc.Name = "tblCdCompl_colsFillValueDesc";
            this.tblCdCompl_colsFillValueDesc.NamedProperties.Put("EnumerateMethod", "");
            this.tblCdCompl_colsFillValueDesc.NamedProperties.Put("LovReference", "");
            this.tblCdCompl_colsFillValueDesc.NamedProperties.Put("SqlColumn", "CODEFILL_VALUE_NAME    ");
            this.tblCdCompl_colsFillValueDesc.Position = 10;
            resources.ApplyResources(this.tblCdCompl_colsFillValueDesc, "tblCdCompl_colsFillValueDesc");
            // 
            // tblCdCompl_colsCdPartFillNameStr
            // 
            resources.ApplyResources(this.tblCdCompl_colsCdPartFillNameStr, "tblCdCompl_colsCdPartFillNameStr");
            this.tblCdCompl_colsCdPartFillNameStr.Name = "tblCdCompl_colsCdPartFillNameStr";
            this.tblCdCompl_colsCdPartFillNameStr.Position = 11;
            // 
            // frmCdCompl
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.tblCdCompl);
            this.Controls.Add(this.dfsCdPartName);
            this.Controls.Add(this.dfsCdPartDesc);
            this.Controls.Add(this.cmbsCdPartValue);
            this.Controls.Add(this.dfsCompany);
            this.Controls.Add(this.dfsCdPart);
            this.Controls.Add(this.labeldfsCdPartName);
            this.Controls.Add(this.labeldfsCdPartDesc);
            this.Controls.Add(this.labelcmbsCdPartValue);
            this.MaximizeBox = true;
            this.Name = "frmCdCompl";
            this.NamedProperties.Put("DefaultOrderBy", "SORT_VALUE");
            this.NamedProperties.Put("DefaultWhere", "COMPANY = :i_hWndFrame.frmCdCompl.i_sCompany ");
            this.NamedProperties.Put("LogicalUnit", "AccountingCodePartValue");
            this.NamedProperties.Put("PackageName", "ACCOUNTING_CODE_PART_VALUE_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "0");
            this.NamedProperties.Put("SourceFlags", "1");
            this.NamedProperties.Put("ViewName", "ACCOUNTING_CODE_PART_VALUE");
            this.NamedProperties.Put("Warnings", "TRUE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.frmCdCompl_WindowActions);
            this.menuFrmMethods.ResumeLayout(false);
            this.tblCdCompl.ResumeLayout(false);
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
        public cChildTableFinBase tblCdCompl;
        protected cColumn tblCdCompl_colsCompany;
        protected cColumn tblCdCompl_colsCdPart;
        protected cColumn tblCdCompl_colsCdPartValue;
        protected cColumn tblCdCompl_colsCdPartFill;
        protected cColumn tblCdCompl_colsCdPartFillName;
        protected cColumn tblCdCompl_colsCdPartBlocked;
        protected cColumn tblCdCompl_colsFillValue;
        protected cColumn tblCdCompl_colsFillValueDesc;
        protected SalTableColumn tblCdCompl_colsCdPartFillNameStr;
	}
}
