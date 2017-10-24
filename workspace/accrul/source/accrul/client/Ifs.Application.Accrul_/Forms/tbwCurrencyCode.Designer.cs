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
	
	public partial class tbwCurrencyCode
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cColumn colCompany;
		public cColumn colRefCurrencyCode;
		public cColumn colCurrencyCode;
		public cColumn colIsoCurrencyDescription;
		public cColumn colConvFactor;
		public cLookupColumn colCurrencyRounding;
		public cColumn colDecimalsInRate;
		public cColumn coldEmuCurrencyFromDate;
		public cCheckBoxColumn colnInverted;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwCurrencyCode));
            this.menuTbwMethods_menuInclude_currency_as_EMU_currency = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_menuExclude_currency_as_EMU_currency = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_menuChange__Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.colCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colRefCurrencyCode = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colCurrencyCode = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colIsoCurrencyDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colConvFactor = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colCurrencyRounding = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.colDecimalsInRate = new Ifs.Fnd.ApplicationForms.cColumn();
            this.coldEmuCurrencyFromDate = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colnInverted = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.menuTbwMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_Include = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem_Exclude = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuSeparator1 = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.menuItem_Change = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuTbwMethods.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuTbwMethods_menuInclude_currency_as_EMU_currency);
            this.commandManager.Commands.Add(this.menuTbwMethods_menuExclude_currency_as_EMU_currency);
            this.commandManager.Commands.Add(this.menuTbwMethods_menuChange__Company___);
            this.commandManager.ContextMenus.Add(this.menuTbwMethods);
            // 
            // menuTbwMethods_menuInclude_currency_as_EMU_currency
            // 
            resources.ApplyResources(this.menuTbwMethods_menuInclude_currency_as_EMU_currency, "menuTbwMethods_menuInclude_currency_as_EMU_currency");
            this.menuTbwMethods_menuInclude_currency_as_EMU_currency.Name = "menuTbwMethods_menuInclude_currency_as_EMU_currency";
            this.menuTbwMethods_menuInclude_currency_as_EMU_currency.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Include_Execute);
            this.menuTbwMethods_menuInclude_currency_as_EMU_currency.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Include_Inquire);
            // 
            // menuTbwMethods_menuExclude_currency_as_EMU_currency
            // 
            resources.ApplyResources(this.menuTbwMethods_menuExclude_currency_as_EMU_currency, "menuTbwMethods_menuExclude_currency_as_EMU_currency");
            this.menuTbwMethods_menuExclude_currency_as_EMU_currency.Name = "menuTbwMethods_menuExclude_currency_as_EMU_currency";
            this.menuTbwMethods_menuExclude_currency_as_EMU_currency.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Exclude_Execute);
            this.menuTbwMethods_menuExclude_currency_as_EMU_currency.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Exclude_Inquire);
            // 
            // menuTbwMethods_menuChange__Company___
            // 
            resources.ApplyResources(this.menuTbwMethods_menuChange__Company___, "menuTbwMethods_menuChange__Company___");
            this.menuTbwMethods_menuChange__Company___.Name = "menuTbwMethods_menuChange__Company___";
            this.menuTbwMethods_menuChange__Company___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Change_Execute);
            this.menuTbwMethods_menuChange__Company___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Change_Inquire);
            // 
            // colCompany
            // 
            this.colCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.colCompany, "colCompany");
            this.colCompany.MaxLength = 20;
            this.colCompany.Name = "colCompany";
            this.colCompany.NamedProperties.Put("EnumerateMethod", "");
            this.colCompany.NamedProperties.Put("FieldFlags", "131");
            this.colCompany.NamedProperties.Put("LovReference", "");
            this.colCompany.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.colCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.colCompany.NamedProperties.Put("ValidateMethod", "");
            this.colCompany.Position = 3;
            // 
            // colRefCurrencyCode
            // 
            resources.ApplyResources(this.colRefCurrencyCode, "colRefCurrencyCode");
            this.colRefCurrencyCode.Name = "colRefCurrencyCode";
            this.colRefCurrencyCode.NamedProperties.Put("EnumerateMethod", "");
            this.colRefCurrencyCode.NamedProperties.Put("FieldFlags", "256");
            this.colRefCurrencyCode.NamedProperties.Put("LovReference", "");
            this.colRefCurrencyCode.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colRefCurrencyCode.NamedProperties.Put("ResizeableChildObject", "");
            this.colRefCurrencyCode.NamedProperties.Put("SqlColumn", "");
            this.colRefCurrencyCode.NamedProperties.Put("ValidateMethod", "");
            this.colRefCurrencyCode.Position = 4;
            // 
            // colCurrencyCode
            // 
            this.colCurrencyCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colCurrencyCode.MaxLength = 3;
            this.colCurrencyCode.Name = "colCurrencyCode";
            this.colCurrencyCode.NamedProperties.Put("EnumerateMethod", "");
            this.colCurrencyCode.NamedProperties.Put("FieldFlags", "163");
            this.colCurrencyCode.NamedProperties.Put("LovReference", "ISO_CURRENCY");
            this.colCurrencyCode.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colCurrencyCode.NamedProperties.Put("SqlColumn", "CURRENCY_CODE");
            this.colCurrencyCode.NamedProperties.Put("ValidateMethod", "");
            this.colCurrencyCode.Position = 5;
            this.colCurrencyCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            resources.ApplyResources(this.colCurrencyCode, "colCurrencyCode");
            this.colCurrencyCode.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colCurrencyCode_WindowActions);
            // 
            // colIsoCurrencyDescription
            // 
            this.colIsoCurrencyDescription.Name = "colIsoCurrencyDescription";
            this.colIsoCurrencyDescription.NamedProperties.Put("EnumerateMethod", "");
            this.colIsoCurrencyDescription.NamedProperties.Put("FieldFlags", "288");
            this.colIsoCurrencyDescription.NamedProperties.Put("LovReference", "");
            this.colIsoCurrencyDescription.NamedProperties.Put("ParentName", "colCurrencyCode");
            this.colIsoCurrencyDescription.NamedProperties.Put("SqlColumn", "ISO_CURRENCY_API.Get_Description(CURRENCY_CODE)");
            this.colIsoCurrencyDescription.Position = 6;
            resources.ApplyResources(this.colIsoCurrencyDescription, "colIsoCurrencyDescription");
            // 
            // colConvFactor
            // 
            this.colConvFactor.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colConvFactor.MaxLength = 11;
            this.colConvFactor.Name = "colConvFactor";
            this.colConvFactor.NamedProperties.Put("EnumerateMethod", "");
            this.colConvFactor.NamedProperties.Put("FieldFlags", "291");
            this.colConvFactor.NamedProperties.Put("LovReference", "");
            this.colConvFactor.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colConvFactor.NamedProperties.Put("SqlColumn", "CONV_FACTOR");
            this.colConvFactor.Position = 7;
            resources.ApplyResources(this.colConvFactor, "colConvFactor");
            // 
            // colCurrencyRounding
            // 
            this.colCurrencyRounding.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colCurrencyRounding.MaxLength = 1;
            this.colCurrencyRounding.Name = "colCurrencyRounding";
            this.colCurrencyRounding.NamedProperties.Put("EnumerateMethod", "Currency_Code_Api.Enumerate");
            this.colCurrencyRounding.NamedProperties.Put("FieldFlags", "295");
            this.colCurrencyRounding.NamedProperties.Put("LovReference", "");
            this.colCurrencyRounding.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colCurrencyRounding.NamedProperties.Put("ResizeableChildObject", "");
            this.colCurrencyRounding.NamedProperties.Put("SqlColumn", "CURRENCY_ROUNDING");
            this.colCurrencyRounding.NamedProperties.Put("ValidateMethod", "");
            this.colCurrencyRounding.Position = 8;
            this.colCurrencyRounding.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            resources.ApplyResources(this.colCurrencyRounding, "colCurrencyRounding");
            this.colCurrencyRounding.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colCurrencyRounding_WindowActions);
            // 
            // colDecimalsInRate
            // 
            this.colDecimalsInRate.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colDecimalsInRate.MaxLength = 1;
            this.colDecimalsInRate.Name = "colDecimalsInRate";
            this.colDecimalsInRate.NamedProperties.Put("EnumerateMethod", "");
            this.colDecimalsInRate.NamedProperties.Put("FieldFlags", "295");
            this.colDecimalsInRate.NamedProperties.Put("LovReference", "");
            this.colDecimalsInRate.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colDecimalsInRate.NamedProperties.Put("SqlColumn", "DECIMALS_IN_RATE");
            this.colDecimalsInRate.NamedProperties.Put("ValidateMethod", "");
            this.colDecimalsInRate.Position = 9;
            this.colDecimalsInRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            resources.ApplyResources(this.colDecimalsInRate, "colDecimalsInRate");
            // 
            // coldEmuCurrencyFromDate
            // 
            this.coldEmuCurrencyFromDate.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.coldEmuCurrencyFromDate.Format = "d";
            this.coldEmuCurrencyFromDate.Name = "coldEmuCurrencyFromDate";
            this.coldEmuCurrencyFromDate.NamedProperties.Put("EnumerateMethod", "");
            this.coldEmuCurrencyFromDate.NamedProperties.Put("FieldFlags", "288");
            this.coldEmuCurrencyFromDate.NamedProperties.Put("LovReference", "");
            this.coldEmuCurrencyFromDate.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.coldEmuCurrencyFromDate.NamedProperties.Put("ResizeableChildObject", "");
            this.coldEmuCurrencyFromDate.NamedProperties.Put("SqlColumn", "EMU_CURRENCY_FROM_DATE");
            this.coldEmuCurrencyFromDate.NamedProperties.Put("ValidateMethod", "");
            this.coldEmuCurrencyFromDate.Position = 10;
            this.coldEmuCurrencyFromDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            resources.ApplyResources(this.coldEmuCurrencyFromDate, "coldEmuCurrencyFromDate");
            // 
            // colnInverted
            // 
            this.colnInverted.MaxLength = 5;
            this.colnInverted.Name = "colnInverted";
            this.colnInverted.NamedProperties.Put("EnumerateMethod", "");
            this.colnInverted.NamedProperties.Put("FieldFlags", "291");
            this.colnInverted.NamedProperties.Put("LovReference", "");
            this.colnInverted.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colnInverted.NamedProperties.Put("ResizeableChildObject", "");
            this.colnInverted.NamedProperties.Put("SqlColumn", "INVERTED");
            this.colnInverted.NamedProperties.Put("ValidateMethod", "");
            this.colnInverted.Position = 11;
            resources.ApplyResources(this.colnInverted, "colnInverted");
            // 
            // menuTbwMethods
            // 
            this.menuTbwMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_Include,
            this.menuItem_Exclude,
            this.menuSeparator1,
            this.menuItem_Change});
            this.menuTbwMethods.Name = "menuTbwMethods";
            resources.ApplyResources(this.menuTbwMethods, "menuTbwMethods");
            // 
            // menuItem_Include
            // 
            this.menuItem_Include.Command = this.menuTbwMethods_menuInclude_currency_as_EMU_currency;
            this.menuItem_Include.Name = "menuItem_Include";
            resources.ApplyResources(this.menuItem_Include, "menuItem_Include");
            this.menuItem_Include.Text = "Include currency as EMU-currency...";
            // 
            // menuItem_Exclude
            // 
            this.menuItem_Exclude.Command = this.menuTbwMethods_menuExclude_currency_as_EMU_currency;
            this.menuItem_Exclude.Name = "menuItem_Exclude";
            resources.ApplyResources(this.menuItem_Exclude, "menuItem_Exclude");
            this.menuItem_Exclude.Text = "Exclude currency as EMU-currency....";
            // 
            // menuSeparator1
            // 
            this.menuSeparator1.Name = "menuSeparator1";
            resources.ApplyResources(this.menuSeparator1, "menuSeparator1");
            // 
            // menuItem_Change
            // 
            this.menuItem_Change.Command = this.menuTbwMethods_menuChange__Company___;
            this.menuItem_Change.Name = "menuItem_Change";
            resources.ApplyResources(this.menuItem_Change, "menuItem_Change");
            this.menuItem_Change.Text = "Change &Company...";
            // 
            // tbwCurrencyCode
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colCompany);
            this.Controls.Add(this.colRefCurrencyCode);
            this.Controls.Add(this.colCurrencyCode);
            this.Controls.Add(this.colIsoCurrencyDescription);
            this.Controls.Add(this.colConvFactor);
            this.Controls.Add(this.colCurrencyRounding);
            this.Controls.Add(this.colDecimalsInRate);
            this.Controls.Add(this.coldEmuCurrencyFromDate);
            this.Controls.Add(this.colnInverted);
            this.Name = "tbwCurrencyCode";
            this.NamedProperties.Put("DefaultOrderBy", "CURRENCY_CODE");
            this.NamedProperties.Put("DefaultWhere", "COMPANY = :global.company");
            this.NamedProperties.Put("LogicalUnit", "CurrencyCode");
            this.NamedProperties.Put("PackageName", "CURRENCY_CODE_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "0");
            this.NamedProperties.Put("SourceFlags", "449");
            this.NamedProperties.Put("ViewName", "CURRENCY_CODE");
            this.NamedProperties.Put("Warnings", "TRUE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tbwCurrencyCode_WindowActions);
            this.Controls.SetChildIndex(this.colnInverted, 0);
            this.Controls.SetChildIndex(this.coldEmuCurrencyFromDate, 0);
            this.Controls.SetChildIndex(this.colDecimalsInRate, 0);
            this.Controls.SetChildIndex(this.colCurrencyRounding, 0);
            this.Controls.SetChildIndex(this.colConvFactor, 0);
            this.Controls.SetChildIndex(this.colIsoCurrencyDescription, 0);
            this.Controls.SetChildIndex(this.colCurrencyCode, 0);
            this.Controls.SetChildIndex(this.colRefCurrencyCode, 0);
            this.Controls.SetChildIndex(this.colCompany, 0);
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

        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menuInclude_currency_as_EMU_currency;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menuExclude_currency_as_EMU_currency;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menuChange__Company___;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTbwMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Include;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Exclude;
        protected Fnd.Windows.Forms.FndToolStripSeparator menuSeparator1;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change;
	}
}
