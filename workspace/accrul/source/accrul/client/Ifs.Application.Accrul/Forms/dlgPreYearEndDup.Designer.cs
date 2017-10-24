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
	
	public partial class dlgPreYearEndDup
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cDataField dfCompany;
		protected SalGroupBox gbCriteria;
		protected SalGroupBox gbThird_Currency_Balance;
		public cPushButton pbOK;
		public cPushButton pbCancel;
		public cPushButton pbPreview;
		public cPushButton pbPrint;
		public cPushButton pbList;
		protected cBackgroundText labeldfFromAccYear;
		public cDataField dfFromAccYear;
		protected cBackgroundText labeldfToAccYear;
		public cDataField dfToAccYear;
		public cCheckBox cbCalculateAll;
		protected cBackgroundText labeldfRate;
		public cDataField dfRate;
		protected cBackgroundText labeldfText;
		public cDataField dfText;
		// The following dummy field was added to enable the above text to be translated
		public cDataField dfDummy;
		public cDataField dfCalculateAll;
		protected cBackgroundText labeldfConvFactor;
		public cDataField dfConvFactor;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgPreYearEndDup));
            this.dfCompany = new Ifs.Fnd.ApplicationForms.cDataField();
            this.gbCriteria = new PPJ.Runtime.Windows.SalGroupBox();
            this.gbThird_Currency_Balance = new PPJ.Runtime.Windows.SalGroupBox();
            this.pbOK = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbCancel = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbPreview = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbPrint = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbList = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.labeldfFromAccYear = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfFromAccYear = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfToAccYear = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfToAccYear = new Ifs.Fnd.ApplicationForms.cDataField();
            this.cbCalculateAll = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.labeldfRate = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfRate = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfText = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfText = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfDummy = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfCalculateAll = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfConvFactor = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfConvFactor = new Ifs.Fnd.ApplicationForms.cDataField();
            this.ClientArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // ClientArea
            // 
            this.ClientArea.Controls.Add(this.dfConvFactor);
            this.ClientArea.Controls.Add(this.dfCalculateAll);
            this.ClientArea.Controls.Add(this.dfDummy);
            this.ClientArea.Controls.Add(this.dfText);
            this.ClientArea.Controls.Add(this.dfRate);
            this.ClientArea.Controls.Add(this.cbCalculateAll);
            this.ClientArea.Controls.Add(this.dfToAccYear);
            this.ClientArea.Controls.Add(this.dfFromAccYear);
            this.ClientArea.Controls.Add(this.pbList);
            this.ClientArea.Controls.Add(this.pbPrint);
            this.ClientArea.Controls.Add(this.pbPreview);
            this.ClientArea.Controls.Add(this.pbCancel);
            this.ClientArea.Controls.Add(this.pbOK);
            this.ClientArea.Controls.Add(this.dfCompany);
            this.ClientArea.Controls.Add(this.labeldfConvFactor);
            this.ClientArea.Controls.Add(this.labeldfText);
            this.ClientArea.Controls.Add(this.labeldfRate);
            this.ClientArea.Controls.Add(this.labeldfToAccYear);
            this.ClientArea.Controls.Add(this.labeldfFromAccYear);
            this.ClientArea.Controls.Add(this.gbThird_Currency_Balance);
            this.ClientArea.Controls.Add(this.gbCriteria);
            resources.ApplyResources(this.ClientArea, "ClientArea");
            // 
            // commandManager
            // 
            this.commandManager.Components.Add(this.pbList);
            this.commandManager.Components.Add(this.pbPrint);
            this.commandManager.Components.Add(this.pbPreview);
            this.commandManager.Components.Add(this.pbCancel);
            this.commandManager.Components.Add(this.pbOK);
            // 
            // dfCompany
            // 
            resources.ApplyResources(this.dfCompany, "dfCompany");
            this.dfCompany.Name = "dfCompany";
            this.dfCompany.NamedProperties.Put("EnumerateMethod", "");
            this.dfCompany.NamedProperties.Put("LovReference", "");
            this.dfCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.dfCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.dfCompany.NamedProperties.Put("ValidateMethod", "");
            // 
            // gbCriteria
            // 
            resources.ApplyResources(this.gbCriteria, "gbCriteria");
            this.gbCriteria.Name = "gbCriteria";
            this.gbCriteria.TabStop = false;
            // 
            // gbThird_Currency_Balance
            // 
            resources.ApplyResources(this.gbThird_Currency_Balance, "gbThird_Currency_Balance");
            this.gbThird_Currency_Balance.Name = "gbThird_Currency_Balance";
            this.gbThird_Currency_Balance.TabStop = false;
            // 
            // pbOK
            // 
            this.pbOK.AcceleratorKey = System.Windows.Forms.Keys.Return;
            resources.ApplyResources(this.pbOK, "pbOK");
            this.pbOK.Name = "pbOK";
            this.pbOK.NamedProperties.Put("MethodId", "18385");
            this.pbOK.NamedProperties.Put("MethodParameter", "Ok");
            this.pbOK.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // pbCancel
            // 
            this.pbCancel.AcceleratorKey = System.Windows.Forms.Keys.Escape;
            resources.ApplyResources(this.pbCancel, "pbCancel");
            this.pbCancel.Name = "pbCancel";
            this.pbCancel.NamedProperties.Put("MethodId", "18385");
            this.pbCancel.NamedProperties.Put("MethodParameter", "Cancel");
            this.pbCancel.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // pbPreview
            // 
            resources.ApplyResources(this.pbPreview, "pbPreview");
            this.pbPreview.Name = "pbPreview";
            this.pbPreview.NamedProperties.Put("MethodId", "18385");
            this.pbPreview.NamedProperties.Put("MethodParameter", "Preview");
            this.pbPreview.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // pbPrint
            // 
            resources.ApplyResources(this.pbPrint, "pbPrint");
            this.pbPrint.Name = "pbPrint";
            this.pbPrint.NamedProperties.Put("MethodId", "18385");
            this.pbPrint.NamedProperties.Put("MethodParameter", "Print");
            this.pbPrint.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // pbList
            // 
            this.pbList.AcceleratorKey = System.Windows.Forms.Keys.F8;
            resources.ApplyResources(this.pbList, "pbList");
            this.pbList.Name = "pbList";
            this.pbList.NamedProperties.Put("MethodId", "18385");
            this.pbList.NamedProperties.Put("MethodParameter", "List");
            this.pbList.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // labeldfFromAccYear
            // 
            resources.ApplyResources(this.labeldfFromAccYear, "labeldfFromAccYear");
            this.labeldfFromAccYear.ForeColor = System.Drawing.Color.Black;
            this.labeldfFromAccYear.Name = "labeldfFromAccYear";
            // 
            // dfFromAccYear
            // 
            this.dfFromAccYear.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfFromAccYear, "dfFromAccYear");
            this.dfFromAccYear.Name = "dfFromAccYear";
            this.dfFromAccYear.NamedProperties.Put("EnumerateMethod", "");
            this.dfFromAccYear.NamedProperties.Put("FieldFlags", "676");
            this.dfFromAccYear.NamedProperties.Put("LovReference", "ACCOUNTING_BALANCE_YEAR(COMPANY)");
            this.dfFromAccYear.NamedProperties.Put("ResizableChildObject", "");
            this.dfFromAccYear.NamedProperties.Put("ResizeableChildObject", "");
            this.dfFromAccYear.NamedProperties.Put("SqlColumn", "FROM_ACCOUNTING_YEAR");
            this.dfFromAccYear.NamedProperties.Put("ValidateMethod", "");
            this.dfFromAccYear.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfFromAccYear_WindowActions);
            // 
            // labeldfToAccYear
            // 
            resources.ApplyResources(this.labeldfToAccYear, "labeldfToAccYear");
            this.labeldfToAccYear.Name = "labeldfToAccYear";
            // 
            // dfToAccYear
            // 
            this.dfToAccYear.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfToAccYear, "dfToAccYear");
            this.dfToAccYear.Name = "dfToAccYear";
            this.dfToAccYear.NamedProperties.Put("EnumerateMethod", "");
            this.dfToAccYear.NamedProperties.Put("FieldFlags", "804");
            this.dfToAccYear.NamedProperties.Put("LovReference", "ACCOUNTING_BALANCE_TO_YEAR(COMPANY, FROM_ACCOUNTING_YEAR)");
            this.dfToAccYear.NamedProperties.Put("ResizableChildObject", "");
            this.dfToAccYear.NamedProperties.Put("ResizeableChildObject", "");
            this.dfToAccYear.NamedProperties.Put("SqlColumn", "TO_ACCOUNTING_YEAR");
            this.dfToAccYear.NamedProperties.Put("ValidateMethod", "");
            this.dfToAccYear.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfToAccYear_WindowActions);
            // 
            // cbCalculateAll
            // 
            resources.ApplyResources(this.cbCalculateAll, "cbCalculateAll");
            this.cbCalculateAll.Name = "cbCalculateAll";
            this.cbCalculateAll.NamedProperties.Put("DataType", "5");
            this.cbCalculateAll.NamedProperties.Put("EnumerateMethod", "");
            this.cbCalculateAll.NamedProperties.Put("FieldFlags", "262");
            this.cbCalculateAll.NamedProperties.Put("LovReference", "");
            this.cbCalculateAll.NamedProperties.Put("ResizeableChildObject", "");
            this.cbCalculateAll.NamedProperties.Put("SqlColumn", "*");
            this.cbCalculateAll.NamedProperties.Put("ValidateMethod", "");
            this.cbCalculateAll.NamedProperties.Put("XDataLength", "Class Default");
            this.cbCalculateAll.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cbCalculateAll_WindowActions);
            // 
            // labeldfRate
            // 
            resources.ApplyResources(this.labeldfRate, "labeldfRate");
            this.labeldfRate.Name = "labeldfRate";
            // 
            // dfRate
            // 
            this.dfRate.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfRate, "dfRate");
            this.dfRate.Name = "dfRate";
            this.dfRate.NamedProperties.Put("EnumerateMethod", "");
            this.dfRate.NamedProperties.Put("FieldFlags", "294");
            this.dfRate.NamedProperties.Put("LovReference", "");
            this.dfRate.NamedProperties.Put("ResizeableChildObject", "");
            this.dfRate.NamedProperties.Put("SqlColumn", "");
            this.dfRate.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfText
            // 
            resources.ApplyResources(this.labeldfText, "labeldfText");
            this.labeldfText.Name = "labeldfText";
            // 
            // dfText
            // 
            resources.ApplyResources(this.dfText, "dfText");
            this.dfText.Name = "dfText";
            // 
            // dfDummy
            // 
            resources.ApplyResources(this.dfDummy, "dfDummy");
            this.dfDummy.Name = "dfDummy";
            // 
            // dfCalculateAll
            // 
            resources.ApplyResources(this.dfCalculateAll, "dfCalculateAll");
            this.dfCalculateAll.Name = "dfCalculateAll";
            // 
            // labeldfConvFactor
            // 
            resources.ApplyResources(this.labeldfConvFactor, "labeldfConvFactor");
            this.labeldfConvFactor.Name = "labeldfConvFactor";
            // 
            // dfConvFactor
            // 
            this.dfConvFactor.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfConvFactor, "dfConvFactor");
            this.dfConvFactor.Name = "dfConvFactor";
            this.dfConvFactor.NamedProperties.Put("EnumerateMethod", "");
            this.dfConvFactor.NamedProperties.Put("FieldFlags", "262");
            this.dfConvFactor.NamedProperties.Put("LovReference", "");
            this.dfConvFactor.NamedProperties.Put("ResizeableChildObject", "");
            this.dfConvFactor.NamedProperties.Put("SqlColumn", "");
            this.dfConvFactor.NamedProperties.Put("ValidateMethod", "");
            // 
            // dlgPreYearEndDup
            // 
            resources.ApplyResources(this, "$this");
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "dlgPreYearEndDup";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "AccountingBalance");
            this.NamedProperties.Put("PackageName", "ACCOUNTING_BALANCE_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ViewName", "ACCOUNTING_BALANCE");
            this.ShowIcon = false;
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dlgPreYearEndDup_WindowActions);
            this.ClientArea.ResumeLayout(false);
            this.ClientArea.PerformLayout();
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
	}
}
