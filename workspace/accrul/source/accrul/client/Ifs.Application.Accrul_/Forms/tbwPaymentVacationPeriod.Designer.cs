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
	
	public partial class tbwPaymentVacationPeriod
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cColumn colsCompany;
		public cColumn colsPaymentMethod;
		public cColumn colsCustomerId;
		public cColumn coldStartDate;
		public cColumn coldEndDate;
		public cColumn coldNewDueDate;
		public cColumn colsPartyType;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwPaymentVacationPeriod));
            this.menuTbwMethods_menuChange__Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.colsCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsPaymentMethod = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsCustomerId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.coldStartDate = new Ifs.Fnd.ApplicationForms.cColumn();
            this.coldEndDate = new Ifs.Fnd.ApplicationForms.cColumn();
            this.coldNewDueDate = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsPartyType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.menuTbwMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_Change = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuTbwMethods.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuTbwMethods_menuChange__Company___);
            this.commandManager.ContextMenus.Add(this.menuTbwMethods);
            // 
            // menuTbwMethods_menuChange__Company___
            // 
            resources.ApplyResources(this.menuTbwMethods_menuChange__Company___, "menuTbwMethods_menuChange__Company___");
            this.menuTbwMethods_menuChange__Company___.Name = "menuTbwMethods_menuChange__Company___";
            this.menuTbwMethods_menuChange__Company___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Change_Execute);
            this.menuTbwMethods_menuChange__Company___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Change_Inquire);
            // 
            // colsCompany
            // 
            this.colsCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.colsCompany, "colsCompany");
            this.colsCompany.MaxLength = 20;
            this.colsCompany.Name = "colsCompany";
            this.colsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.colsCompany.NamedProperties.Put("FieldFlags", "67");
            this.colsCompany.NamedProperties.Put("LovReference", "COMPANY_FINANCE");
            this.colsCompany.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.colsCompany.Position = 3;
            // 
            // colsPaymentMethod
            // 
            this.colsPaymentMethod.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsPaymentMethod.MaxLength = 20;
            this.colsPaymentMethod.Name = "colsPaymentMethod";
            this.colsPaymentMethod.NamedProperties.Put("EnumerateMethod", "");
            this.colsPaymentMethod.NamedProperties.Put("FieldFlags", "163");
            this.colsPaymentMethod.NamedProperties.Put("LovReference", "PAYMENT_WAY_LOV2(COMPANY)");
            this.colsPaymentMethod.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsPaymentMethod.NamedProperties.Put("ResizeableChildObject", "");
            this.colsPaymentMethod.NamedProperties.Put("SqlColumn", "PAYMENT_METHOD");
            this.colsPaymentMethod.NamedProperties.Put("ValidateMethod", "");
            this.colsPaymentMethod.Position = 4;
            resources.ApplyResources(this.colsPaymentMethod, "colsPaymentMethod");
            this.colsPaymentMethod.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsPaymentMethod_WindowActions);
            // 
            // colsCustomerId
            // 
            this.colsCustomerId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsCustomerId.MaxLength = 20;
            this.colsCustomerId.Name = "colsCustomerId";
            this.colsCustomerId.NamedProperties.Put("EnumerateMethod", "");
            this.colsCustomerId.NamedProperties.Put("FieldFlags", "163");
            this.colsCustomerId.NamedProperties.Put("LovReference", "");
            this.colsCustomerId.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsCustomerId.NamedProperties.Put("ResizeableChildObject", "");
            this.colsCustomerId.NamedProperties.Put("SqlColumn", "CUSTOMER_ID");
            this.colsCustomerId.NamedProperties.Put("ValidateMethod", "");
            this.colsCustomerId.Position = 5;
            resources.ApplyResources(this.colsCustomerId, "colsCustomerId");
            this.colsCustomerId.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsCustomerId_WindowActions);
            // 
            // coldStartDate
            // 
            this.coldStartDate.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.coldStartDate.Format = "d";
            this.coldStartDate.Name = "coldStartDate";
            this.coldStartDate.NamedProperties.Put("EnumerateMethod", "");
            this.coldStartDate.NamedProperties.Put("FieldFlags", "163");
            this.coldStartDate.NamedProperties.Put("LovReference", "");
            this.coldStartDate.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.coldStartDate.NamedProperties.Put("SqlColumn", "START_DATE");
            this.coldStartDate.NamedProperties.Put("ValidateMethod", "");
            this.coldStartDate.Position = 6;
            resources.ApplyResources(this.coldStartDate, "coldStartDate");
            // 
            // coldEndDate
            // 
            this.coldEndDate.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.coldEndDate.Format = "d";
            this.coldEndDate.Name = "coldEndDate";
            this.coldEndDate.NamedProperties.Put("EnumerateMethod", "");
            this.coldEndDate.NamedProperties.Put("FieldFlags", "295");
            this.coldEndDate.NamedProperties.Put("LovReference", "");
            this.coldEndDate.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.coldEndDate.NamedProperties.Put("SqlColumn", "END_DATE");
            this.coldEndDate.NamedProperties.Put("ValidateMethod", "");
            this.coldEndDate.Position = 7;
            resources.ApplyResources(this.coldEndDate, "coldEndDate");
            // 
            // coldNewDueDate
            // 
            this.coldNewDueDate.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.coldNewDueDate.Format = "d";
            this.coldNewDueDate.Name = "coldNewDueDate";
            this.coldNewDueDate.NamedProperties.Put("EnumerateMethod", "");
            this.coldNewDueDate.NamedProperties.Put("FieldFlags", "294");
            this.coldNewDueDate.NamedProperties.Put("LovReference", "");
            this.coldNewDueDate.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.coldNewDueDate.NamedProperties.Put("SqlColumn", "NEW_DUE_DATE");
            this.coldNewDueDate.Position = 8;
            resources.ApplyResources(this.coldNewDueDate, "coldNewDueDate");
            // 
            // colsPartyType
            // 
            resources.ApplyResources(this.colsPartyType, "colsPartyType");
            this.colsPartyType.MaxLength = 200;
            this.colsPartyType.Name = "colsPartyType";
            this.colsPartyType.NamedProperties.Put("EnumerateMethod", "");
            this.colsPartyType.NamedProperties.Put("FieldFlags", "256");
            this.colsPartyType.NamedProperties.Put("LovReference", "");
            this.colsPartyType.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsPartyType.NamedProperties.Put("ResizeableChildObject", "");
            this.colsPartyType.NamedProperties.Put("SqlColumn", "PARTY_TYPE");
            this.colsPartyType.NamedProperties.Put("ValidateMethod", "");
            this.colsPartyType.Position = 9;
            // 
            // menuTbwMethods
            // 
            this.menuTbwMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_Change});
            this.menuTbwMethods.Name = "menuTbwMethods";
            resources.ApplyResources(this.menuTbwMethods, "menuTbwMethods");
            // 
            // menuItem_Change
            // 
            this.menuItem_Change.Command = this.menuTbwMethods_menuChange__Company___;
            this.menuItem_Change.Name = "menuItem_Change";
            resources.ApplyResources(this.menuItem_Change, "menuItem_Change");
            this.menuItem_Change.Text = "Change &Company...";
            // 
            // tbwPaymentVacationPeriod
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colsCompany);
            this.Controls.Add(this.colsPaymentMethod);
            this.Controls.Add(this.colsCustomerId);
            this.Controls.Add(this.coldStartDate);
            this.Controls.Add(this.coldEndDate);
            this.Controls.Add(this.coldNewDueDate);
            this.Controls.Add(this.colsPartyType);
            this.Name = "tbwPaymentVacationPeriod";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "COMPANY= :i_hWndFrame.tbwPaymentVacationPeriod.i_sCompany");
            this.NamedProperties.Put("LogicalUnit", "PaymentVacationPeriod");
            this.NamedProperties.Put("PackageName", "PAYMENT_VACATION_PERIOD_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "0");
            this.NamedProperties.Put("SourceFlags", "449");
            this.NamedProperties.Put("ViewName", "PAYMENT_VACATION_PERIOD");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tbwPaymentVacationPeriod_WindowActions);
            this.Controls.SetChildIndex(this.colsPartyType, 0);
            this.Controls.SetChildIndex(this.coldNewDueDate, 0);
            this.Controls.SetChildIndex(this.coldEndDate, 0);
            this.Controls.SetChildIndex(this.coldStartDate, 0);
            this.Controls.SetChildIndex(this.colsCustomerId, 0);
            this.Controls.SetChildIndex(this.colsPaymentMethod, 0);
            this.Controls.SetChildIndex(this.colsCompany, 0);
            this.Controls.SetChildIndex(this.@__colObjversion, 0);
            this.Controls.SetChildIndex(this.@__colObjid, 0);
            this.menuTbwMethods.ResumeLayout(false);
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

        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menuChange__Company___;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTbwMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change;
	}
}
