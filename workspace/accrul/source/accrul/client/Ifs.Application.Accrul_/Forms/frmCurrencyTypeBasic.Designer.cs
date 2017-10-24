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
	
	public partial class frmCurrencyTypeBasic
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		protected cBackgroundText labeldfsCompany;
		public cDataField dfsCompany;
		protected cBackgroundText labeldfsBuy;
		public cDataField dfsBuy;
		// Bug 74642, Begin, Unchecked Queryble in F1 properties
		public cDataField dfsBuyDescription;
		// Bug 74642, End
		protected cBackgroundText labeldfsSell;
		// Return SalHStringToNumber('REF_CURRENCY_CODE= :i_hWndFrame.frmCurrencyTypeBasic.dfsRefCurrencyCode')
		public cDataField dfsSell;
		// Bug 74642, Begin, Unchecked Queryble in F1 properties
		public cDataField dfsSellDescription;
		// Bug 74642, End
		protected cBackgroundText labeldfsRefCurrencyCode;
		public cDataField dfsRefCurrencyCode;
		protected SalGroupBox gbDefault_Currency_Rate_Types_for_;
		protected cBackgroundText labeldfsTaxBuy;
		public cDataField dfsTaxBuy;
		// Bug 74642, Begin, Unchecked Queryble in F1 properties
		public cDataField dfsTaxBuyDescription;
		// Bug 74642, End
		protected cBackgroundText labeldfsTaxSell;
		public cDataField dfsTaxSell;
		// Bug 74642, Begin, Unchecked Queryble in F1 properties
		public cDataField dfsTaxSellDescription;
		// Bug 74642, End
		public cCheckBox cbUseTaxRates;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCurrencyTypeBasic));
            this.labeldfsCompany = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsCompany = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsBuy = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsBuy = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsBuyDescription = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsSell = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsSell = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsSellDescription = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsRefCurrencyCode = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsRefCurrencyCode = new Ifs.Fnd.ApplicationForms.cDataField();
            this.gbDefault_Currency_Rate_Types_for_ = new PPJ.Runtime.Windows.SalGroupBox();
            this.labeldfsTaxBuy = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsTaxBuy = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsTaxBuyDescription = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsTaxSell = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsTaxSell = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsTaxSellDescription = new Ifs.Fnd.ApplicationForms.cDataField();
            this.cbUseTaxRates = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.SuspendLayout();
            // 
            // labeldfsCompany
            // 
            resources.ApplyResources(this.labeldfsCompany, "labeldfsCompany");
            this.labeldfsCompany.Name = "labeldfsCompany";
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
            // labeldfsBuy
            // 
            resources.ApplyResources(this.labeldfsBuy, "labeldfsBuy");
            this.labeldfsBuy.Name = "labeldfsBuy";
            // 
            // dfsBuy
            // 
            this.dfsBuy.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsBuy, "dfsBuy");
            this.dfsBuy.Name = "dfsBuy";
            this.dfsBuy.NamedProperties.Put("EnumerateMethod", "");
            this.dfsBuy.NamedProperties.Put("FieldFlags", "294");
            this.dfsBuy.NamedProperties.Put("LovReference", "CURRENCY_TYPE(COMPANY)");
            this.dfsBuy.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsBuy.NamedProperties.Put("SqlColumn", "BUY");
            this.dfsBuy.NamedProperties.Put("ValidateMethod", "");
            this.dfsBuy.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsBuy_WindowActions);
            // 
            // dfsBuyDescription
            // 
            resources.ApplyResources(this.dfsBuyDescription, "dfsBuyDescription");
            this.dfsBuyDescription.Name = "dfsBuyDescription";
            this.dfsBuyDescription.NamedProperties.Put("EnumerateMethod", "");
            this.dfsBuyDescription.NamedProperties.Put("LovReference", "");
            this.dfsBuyDescription.NamedProperties.Put("ParentName", "dfsBuy");
            this.dfsBuyDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsBuyDescription.NamedProperties.Put("SqlColumn", "CURRENCY_TYPE_API.GET_DESCRIPTION(COMPANY,BUY)");
            this.dfsBuyDescription.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsSell
            // 
            resources.ApplyResources(this.labeldfsSell, "labeldfsSell");
            this.labeldfsSell.Name = "labeldfsSell";
            // 
            // dfsSell
            // 
            this.dfsSell.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsSell, "dfsSell");
            this.dfsSell.Name = "dfsSell";
            this.dfsSell.NamedProperties.Put("EnumerateMethod", "");
            this.dfsSell.NamedProperties.Put("FieldFlags", "294");
            this.dfsSell.NamedProperties.Put("LovReference", "CURRENCY_TYPE(COMPANY)");
            this.dfsSell.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsSell.NamedProperties.Put("SqlColumn", "SELL");
            this.dfsSell.NamedProperties.Put("ValidateMethod", "");
            this.dfsSell.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsSell_WindowActions);
            // 
            // dfsSellDescription
            // 
            resources.ApplyResources(this.dfsSellDescription, "dfsSellDescription");
            this.dfsSellDescription.Name = "dfsSellDescription";
            this.dfsSellDescription.NamedProperties.Put("EnumerateMethod", "");
            this.dfsSellDescription.NamedProperties.Put("LovReference", "");
            this.dfsSellDescription.NamedProperties.Put("ParentName", "dfsSell");
            this.dfsSellDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsSellDescription.NamedProperties.Put("SqlColumn", "CURRENCY_TYPE_API.GET_DESCRIPTION(COMPANY,SELL)");
            this.dfsSellDescription.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsRefCurrencyCode
            // 
            resources.ApplyResources(this.labeldfsRefCurrencyCode, "labeldfsRefCurrencyCode");
            this.labeldfsRefCurrencyCode.Name = "labeldfsRefCurrencyCode";
            // 
            // dfsRefCurrencyCode
            // 
            resources.ApplyResources(this.dfsRefCurrencyCode, "dfsRefCurrencyCode");
            this.dfsRefCurrencyCode.Name = "dfsRefCurrencyCode";
            this.dfsRefCurrencyCode.NamedProperties.Put("EnumerateMethod", "");
            this.dfsRefCurrencyCode.NamedProperties.Put("LovReference", "");
            this.dfsRefCurrencyCode.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsRefCurrencyCode.NamedProperties.Put("SqlColumn", "COMPANY_FINANCE_API.Get_Currency_Code(COMPANY)");
            this.dfsRefCurrencyCode.NamedProperties.Put("ValidateMethod", "");
            // 
            // gbDefault_Currency_Rate_Types_for_
            // 
            resources.ApplyResources(this.gbDefault_Currency_Rate_Types_for_, "gbDefault_Currency_Rate_Types_for_");
            this.gbDefault_Currency_Rate_Types_for_.Name = "gbDefault_Currency_Rate_Types_for_";
            this.gbDefault_Currency_Rate_Types_for_.TabStop = false;
            // 
            // labeldfsTaxBuy
            // 
            resources.ApplyResources(this.labeldfsTaxBuy, "labeldfsTaxBuy");
            this.labeldfsTaxBuy.Name = "labeldfsTaxBuy";
            // 
            // dfsTaxBuy
            // 
            this.dfsTaxBuy.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsTaxBuy, "dfsTaxBuy");
            this.dfsTaxBuy.Name = "dfsTaxBuy";
            this.dfsTaxBuy.NamedProperties.Put("EnumerateMethod", "");
            this.dfsTaxBuy.NamedProperties.Put("FieldFlags", "294");
            this.dfsTaxBuy.NamedProperties.Put("LovReference", "CURRENCY_TYPE(COMPANY)");
            this.dfsTaxBuy.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsTaxBuy.NamedProperties.Put("SqlColumn", "TAX_BUY");
            this.dfsTaxBuy.NamedProperties.Put("ValidateMethod", "");
            this.dfsTaxBuy.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsTaxBuy_WindowActions);
            // 
            // dfsTaxBuyDescription
            // 
            resources.ApplyResources(this.dfsTaxBuyDescription, "dfsTaxBuyDescription");
            this.dfsTaxBuyDescription.Name = "dfsTaxBuyDescription";
            this.dfsTaxBuyDescription.NamedProperties.Put("EnumerateMethod", "");
            this.dfsTaxBuyDescription.NamedProperties.Put("LovReference", "");
            this.dfsTaxBuyDescription.NamedProperties.Put("ParentName", "dfsTaxBuy");
            this.dfsTaxBuyDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsTaxBuyDescription.NamedProperties.Put("SqlColumn", "CURRENCY_TYPE_API.Get_Description(company,TAX_BUY)");
            this.dfsTaxBuyDescription.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsTaxSell
            // 
            resources.ApplyResources(this.labeldfsTaxSell, "labeldfsTaxSell");
            this.labeldfsTaxSell.Name = "labeldfsTaxSell";
            // 
            // dfsTaxSell
            // 
            this.dfsTaxSell.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsTaxSell, "dfsTaxSell");
            this.dfsTaxSell.Name = "dfsTaxSell";
            this.dfsTaxSell.NamedProperties.Put("EnumerateMethod", "");
            this.dfsTaxSell.NamedProperties.Put("FieldFlags", "294");
            this.dfsTaxSell.NamedProperties.Put("LovReference", "CURRENCY_TYPE(COMPANY)");
            this.dfsTaxSell.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsTaxSell.NamedProperties.Put("SqlColumn", "TAX_SELL");
            this.dfsTaxSell.NamedProperties.Put("ValidateMethod", "");
            this.dfsTaxSell.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsTaxSell_WindowActions);
            // 
            // dfsTaxSellDescription
            // 
            resources.ApplyResources(this.dfsTaxSellDescription, "dfsTaxSellDescription");
            this.dfsTaxSellDescription.Name = "dfsTaxSellDescription";
            this.dfsTaxSellDescription.NamedProperties.Put("EnumerateMethod", "");
            this.dfsTaxSellDescription.NamedProperties.Put("LovReference", "");
            this.dfsTaxSellDescription.NamedProperties.Put("ParentName", "dfsTaxSell");
            this.dfsTaxSellDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsTaxSellDescription.NamedProperties.Put("SqlColumn", "CURRENCY_TYPE_API.Get_Description(company,TAX_SELL)");
            this.dfsTaxSellDescription.NamedProperties.Put("ValidateMethod", "");
            // 
            // cbUseTaxRates
            // 
            resources.ApplyResources(this.cbUseTaxRates, "cbUseTaxRates");
            this.cbUseTaxRates.Name = "cbUseTaxRates";
            this.cbUseTaxRates.NamedProperties.Put("DataType", "5");
            this.cbUseTaxRates.NamedProperties.Put("EnumerateMethod", "");
            this.cbUseTaxRates.NamedProperties.Put("FieldFlags", "262");
            this.cbUseTaxRates.NamedProperties.Put("LovReference", "");
            this.cbUseTaxRates.NamedProperties.Put("ResizeableChildObject", "");
            this.cbUseTaxRates.NamedProperties.Put("SqlColumn", "USE_TAX_RATES");
            this.cbUseTaxRates.NamedProperties.Put("ValidateMethod", "");
            this.cbUseTaxRates.NamedProperties.Put("XDataLength", "5");
            this.cbUseTaxRates.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cbUseTaxRates_WindowActions);
            // 
            // frmCurrencyTypeBasic
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.cbUseTaxRates);
            this.Controls.Add(this.dfsTaxSellDescription);
            this.Controls.Add(this.dfsTaxSell);
            this.Controls.Add(this.dfsTaxBuyDescription);
            this.Controls.Add(this.dfsTaxBuy);
            this.Controls.Add(this.dfsRefCurrencyCode);
            this.Controls.Add(this.dfsSellDescription);
            this.Controls.Add(this.dfsSell);
            this.Controls.Add(this.dfsBuyDescription);
            this.Controls.Add(this.dfsBuy);
            this.Controls.Add(this.dfsCompany);
            this.Controls.Add(this.labeldfsTaxSell);
            this.Controls.Add(this.labeldfsTaxBuy);
            this.Controls.Add(this.labeldfsRefCurrencyCode);
            this.Controls.Add(this.labeldfsSell);
            this.Controls.Add(this.labeldfsBuy);
            this.Controls.Add(this.labeldfsCompany);
            this.Controls.Add(this.gbDefault_Currency_Rate_Types_for_);
            this.Name = "frmCurrencyTypeBasic";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "CurrencyTypeBasicData");
            this.NamedProperties.Put("PackageName", "CURRENCY_TYPE_BASIC_DATA_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "193");
            this.NamedProperties.Put("ViewName", "CURRENCY_TYPE_BASIC_DATA");
            this.NamedProperties.Put("Warnings", "TRUE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.frmCurrencyTypeBasic_WindowActions);
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
	}
}
