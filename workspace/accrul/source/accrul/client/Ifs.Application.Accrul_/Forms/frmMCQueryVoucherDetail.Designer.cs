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
// Date     By      Notes
// -----    ------  ---------------------------------------------------------------------------------
// 111031   Umdolk  SFI-218. Corrected Assertion errors.
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
	
	public partial class frmMCQueryVoucherDetail
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		protected cBackgroundText labeldfCompany;
		public cDataField dfCompany;
		protected cBackgroundText labelccVoucherType;
		public cRecListDataField ccVoucherType;
		protected cBackgroundText labeldfVoucherNo;
		public cDataField dfVoucherNo;
		protected SalGroupBox gbAccounting_Period;
		protected cBackgroundText labeldfAccountingYear;
		public cDataField dfAccountingYear;
		protected cBackgroundText labeldfAccountingPeriod;
		public cDataField dfAccountingPeriod;
		protected cBackgroundText labeldfVoucherDate;
		public cDataField dfVoucherDate;
		protected SalGroupBox gbVoucher_Registration_by_User;
		protected cBackgroundText labeldfUserid;
		public cDataField dfUserid;
		protected cBackgroundText labeldfUserGroup;
		public cDataField dfUserGroup;
		protected cBackgroundText labeldfDateReg;
		public cDataField dfDateReg;
		// Bug 71533, Begin (Modified F1 sql column)
		// Bug 77430, Removed dfVoucherText
		// Bug 71533, End
		// Bug 77430, Begin, changed F1 property Column Name
		// Bug 77430, Begin, changed the message action
		public cCheckBox cbNotes;
		// Bug 77430, End
		protected cBackgroundText labeldfUpdateError;
		public cDataField dfUpdateError;
		protected cBackgroundText labeldfCodePartValue;
		public cDataFieldFinContent dfCodePartValue;
		protected cBackgroundText labeldfCodePartDescription;
		public cDataFieldFinDescription dfCodePartDescription;
        // Bug 76068 Begin Increased max Rows in memory
		// Bug 76068 End
		// Bug 81897, Begin, Added colon
		protected cBackgroundText labeldfFunctionGroup;
		// Bug 81897, End
		public cDataField dfFunctionGroup;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMCQueryVoucherDetail));
            this.menuTblMethods_menuChange__Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuOperations_menuChange__Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuFrmMethods_menuChange__Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.labeldfCompany = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfCompany = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelccVoucherType = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.ccVoucherType = new Ifs.Fnd.ApplicationForms.cRecListDataField();
            this.labeldfVoucherNo = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfVoucherNo = new Ifs.Fnd.ApplicationForms.cDataField();
            this.gbAccounting_Period = new PPJ.Runtime.Windows.SalGroupBox();
            this.labeldfAccountingYear = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfAccountingYear = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfAccountingPeriod = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfAccountingPeriod = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfVoucherDate = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfVoucherDate = new Ifs.Fnd.ApplicationForms.cDataField();
            this.gbVoucher_Registration_by_User = new PPJ.Runtime.Windows.SalGroupBox();
            this.labeldfUserid = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfUserid = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfUserGroup = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfUserGroup = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfDateReg = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfDateReg = new Ifs.Fnd.ApplicationForms.cDataField();
            this.cbNotes = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.labeldfUpdateError = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfUpdateError = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfCodePartValue = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfCodePartValue = new Ifs.Application.Accrul.cDataFieldFinContent();
            this.labeldfCodePartDescription = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfCodePartDescription = new Ifs.Application.Accrul.cDataFieldFinDescription();
            this.labeldfFunctionGroup = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfFunctionGroup = new Ifs.Fnd.ApplicationForms.cDataField();
            this.menuFrmMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_Change = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuOperations = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_Change_1 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuTblMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_Change_2 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.tblVoucherRow = new Ifs.Application.Accrul.cChildTableFin();
            this.tblVoucherRow_colCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherRow_colVoucherType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherRow_colVoucherNo = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherRow_colAccountingYear = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherRow_colRowNo = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherRow_colVoucherCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherRow_colAccount = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.tblVoucherRow_colsAccountDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.tblVoucherRow_colCodeB = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.tblVoucherRow_colsCodeBDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.tblVoucherRow_colCodeC = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.tblVoucherRow_colsCodeCDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.tblVoucherRow_colCodeD = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.tblVoucherRow_colsCodeDDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.tblVoucherRow_colCodeE = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.tblVoucherRow_colsCodeEDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.tblVoucherRow_colCodeF = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.tblVoucherRow_colsCodeFDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.tblVoucherRow_colCodeG = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.tblVoucherRow_colsCodeGDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.tblVoucherRow_colCodeH = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.tblVoucherRow_colsCodeHDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.tblVoucherRow_colCodeI = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.tblVoucherRow_colsCodeIDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.tblVoucherRow_colCodeJ = new Ifs.Application.Accrul.cColumnCodePartFin();
            this.tblVoucherRow_colsCodeJDesc = new Ifs.Application.Accrul.cColumnCodePartDescFin();
            this.tblVoucherRow_colProcessCode = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherRow_colCurrencyType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherRow_colCurrencyCode = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherRow_colCurrencyRate = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherRow_colConversionFactor = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherRow_colDebitAmount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherRow_colCreditAmount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherRow_colAmount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherRow_colAccCurr = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherRow_colCurrencyDebitAmount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherRow_colCurrencyCreditAmount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherRow_colCurrencyAmount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherRow_colQuantity = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherRow_colPeriodAllocation = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.tblVoucherRow_colText = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherRow_colsDeliveryTypeId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherRow_colsDeliveTypeDesc = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherRow_colOptionalCode = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherRow_colActivitySeqNo = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherRow_colUpdateError = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherRow_colTransCode = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherRow_colConvertionFactor = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherRow_colCodeDemand = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherRow_colCodePart = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherRow_colTransferId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherRow_colReferenceSerie = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherRow_colReferenceNumber = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherRow_colVoucherTypeRef = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherRow_colVoucherNoRef = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherRow_colAccountingYearRef = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblVoucherRow_colnRowGroupId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.menuFrmMethods.SuspendLayout();
            this.menuOperations.SuspendLayout();
            this.menuTblMethods.SuspendLayout();
            this.tblVoucherRow.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuFrmMethods_menuChange__Company___);
            this.commandManager.Commands.Add(this.menuOperations_menuChange__Company___);
            this.commandManager.Commands.Add(this.menuTblMethods_menuChange__Company___);
            this.commandManager.ContextMenus.Add(this.menuFrmMethods);
            this.commandManager.ContextMenus.Add(this.menuOperations);
            this.commandManager.ContextMenus.Add(this.menuTblMethods);
            // 
            // menuTblMethods_menuChange__Company___
            // 
            resources.ApplyResources(this.menuTblMethods_menuChange__Company___, "menuTblMethods_menuChange__Company___");
            this.menuTblMethods_menuChange__Company___.Name = "menuTblMethods_menuChange__Company___";
            this.menuTblMethods_menuChange__Company___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Change_2_Execute);
            this.menuTblMethods_menuChange__Company___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Change_2_Inquire);
            // 
            // menuOperations_menuChange__Company___
            // 
            resources.ApplyResources(this.menuOperations_menuChange__Company___, "menuOperations_menuChange__Company___");
            this.menuOperations_menuChange__Company___.Name = "menuOperations_menuChange__Company___";
            this.menuOperations_menuChange__Company___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Change_1_Execute);
            this.menuOperations_menuChange__Company___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Change_1_Inquire);
            // 
            // menuFrmMethods_menuChange__Company___
            // 
            resources.ApplyResources(this.menuFrmMethods_menuChange__Company___, "menuFrmMethods_menuChange__Company___");
            this.menuFrmMethods_menuChange__Company___.Name = "menuFrmMethods_menuChange__Company___";
            this.menuFrmMethods_menuChange__Company___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Change_Execute);
            this.menuFrmMethods_menuChange__Company___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Change_Inquire);
            // 
            // labeldfCompany
            // 
            resources.ApplyResources(this.labeldfCompany, "labeldfCompany");
            this.labeldfCompany.Name = "labeldfCompany";
            // 
            // dfCompany
            // 
            this.dfCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfCompany, "dfCompany");
            this.dfCompany.Name = "dfCompany";
            this.dfCompany.NamedProperties.Put("EnumerateMethod", "");
            this.dfCompany.NamedProperties.Put("FieldFlags", "67");
            this.dfCompany.NamedProperties.Put("LovReference", "");
            this.dfCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.dfCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.dfCompany.NamedProperties.Put("ValidateMethod", "");
            // 
            // labelccVoucherType
            // 
            resources.ApplyResources(this.labelccVoucherType, "labelccVoucherType");
            this.labelccVoucherType.Name = "labelccVoucherType";
            // 
            // ccVoucherType
            // 
            this.ccVoucherType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.ccVoucherType, "ccVoucherType");
            this.ccVoucherType.Name = "ccVoucherType";
            this.ccVoucherType.NamedProperties.Put("EnumerateMethod", "");
            this.ccVoucherType.NamedProperties.Put("FieldFlags", "99");
            this.ccVoucherType.NamedProperties.Put("Format", "9");
            this.ccVoucherType.NamedProperties.Put("LovReference", "VOUCHER_TYPE(COMPANY)");
            this.ccVoucherType.NamedProperties.Put("ResizeableChildObject", "");
            this.ccVoucherType.NamedProperties.Put("SqlColumn", "VOUCHER_TYPE");
            this.ccVoucherType.NamedProperties.Put("ValidateMethod", "");
            this.ccVoucherType.NamedProperties.Put("XDataLength", "3");
            // 
            // labeldfVoucherNo
            // 
            resources.ApplyResources(this.labeldfVoucherNo, "labeldfVoucherNo");
            this.labeldfVoucherNo.Name = "labeldfVoucherNo";
            // 
            // dfVoucherNo
            // 
            this.dfVoucherNo.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfVoucherNo, "dfVoucherNo");
            this.dfVoucherNo.Name = "dfVoucherNo";
            this.dfVoucherNo.NamedProperties.Put("EnumerateMethod", "");
            this.dfVoucherNo.NamedProperties.Put("FieldFlags", "163");
            this.dfVoucherNo.NamedProperties.Put("LovReference", "");
            this.dfVoucherNo.NamedProperties.Put("ParentName", "ccVoucherType");
            this.dfVoucherNo.NamedProperties.Put("ResizeableChildObject", "");
            this.dfVoucherNo.NamedProperties.Put("SqlColumn", "VOUCHER_NO");
            this.dfVoucherNo.NamedProperties.Put("ValidateMethod", "");
            // 
            // gbAccounting_Period
            // 
            resources.ApplyResources(this.gbAccounting_Period, "gbAccounting_Period");
            this.gbAccounting_Period.Name = "gbAccounting_Period";
            this.gbAccounting_Period.TabStop = false;
            // 
            // labeldfAccountingYear
            // 
            resources.ApplyResources(this.labeldfAccountingYear, "labeldfAccountingYear");
            this.labeldfAccountingYear.Name = "labeldfAccountingYear";
            // 
            // dfAccountingYear
            // 
            this.dfAccountingYear.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfAccountingYear, "dfAccountingYear");
            this.dfAccountingYear.Name = "dfAccountingYear";
            this.dfAccountingYear.NamedProperties.Put("EnumerateMethod", "");
            this.dfAccountingYear.NamedProperties.Put("FieldFlags", "163");
            this.dfAccountingYear.NamedProperties.Put("LovReference", "");
            this.dfAccountingYear.NamedProperties.Put("ParentName", "ccVoucherType");
            this.dfAccountingYear.NamedProperties.Put("ResizeableChildObject", "");
            this.dfAccountingYear.NamedProperties.Put("SqlColumn", "ACCOUNTING_YEAR");
            this.dfAccountingYear.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfAccountingPeriod
            // 
            resources.ApplyResources(this.labeldfAccountingPeriod, "labeldfAccountingPeriod");
            this.labeldfAccountingPeriod.Name = "labeldfAccountingPeriod";
            // 
            // dfAccountingPeriod
            // 
            this.dfAccountingPeriod.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfAccountingPeriod, "dfAccountingPeriod");
            this.dfAccountingPeriod.Name = "dfAccountingPeriod";
            this.dfAccountingPeriod.NamedProperties.Put("EnumerateMethod", "");
            this.dfAccountingPeriod.NamedProperties.Put("FieldFlags", "288");
            this.dfAccountingPeriod.NamedProperties.Put("LovReference", "");
            this.dfAccountingPeriod.NamedProperties.Put("ResizeableChildObject", "");
            this.dfAccountingPeriod.NamedProperties.Put("SqlColumn", "ACCOUNTING_PERIOD");
            this.dfAccountingPeriod.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfVoucherDate
            // 
            resources.ApplyResources(this.labeldfVoucherDate, "labeldfVoucherDate");
            this.labeldfVoucherDate.Name = "labeldfVoucherDate";
            // 
            // dfVoucherDate
            // 
            this.dfVoucherDate.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.dfVoucherDate.Format = "d";
            resources.ApplyResources(this.dfVoucherDate, "dfVoucherDate");
            this.dfVoucherDate.Name = "dfVoucherDate";
            this.dfVoucherDate.NamedProperties.Put("EnumerateMethod", "");
            this.dfVoucherDate.NamedProperties.Put("FieldFlags", "288");
            this.dfVoucherDate.NamedProperties.Put("LovReference", "");
            this.dfVoucherDate.NamedProperties.Put("ResizeableChildObject", "");
            this.dfVoucherDate.NamedProperties.Put("SqlColumn", "VOUCHER_DATE");
            this.dfVoucherDate.NamedProperties.Put("ValidateMethod", "");
            // 
            // gbVoucher_Registration_by_User
            // 
            resources.ApplyResources(this.gbVoucher_Registration_by_User, "gbVoucher_Registration_by_User");
            this.gbVoucher_Registration_by_User.Name = "gbVoucher_Registration_by_User";
            this.gbVoucher_Registration_by_User.TabStop = false;
            // 
            // labeldfUserid
            // 
            resources.ApplyResources(this.labeldfUserid, "labeldfUserid");
            this.labeldfUserid.Name = "labeldfUserid";
            // 
            // dfUserid
            // 
            resources.ApplyResources(this.dfUserid, "dfUserid");
            this.dfUserid.Name = "dfUserid";
            this.dfUserid.NamedProperties.Put("EnumerateMethod", "");
            this.dfUserid.NamedProperties.Put("FieldFlags", "288");
            this.dfUserid.NamedProperties.Put("LovReference", "");
            this.dfUserid.NamedProperties.Put("ResizeableChildObject", "");
            this.dfUserid.NamedProperties.Put("SqlColumn", "USERID");
            this.dfUserid.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfUserGroup
            // 
            resources.ApplyResources(this.labeldfUserGroup, "labeldfUserGroup");
            this.labeldfUserGroup.Name = "labeldfUserGroup";
            // 
            // dfUserGroup
            // 
            resources.ApplyResources(this.dfUserGroup, "dfUserGroup");
            this.dfUserGroup.Name = "dfUserGroup";
            this.dfUserGroup.NamedProperties.Put("EnumerateMethod", "");
            this.dfUserGroup.NamedProperties.Put("FieldFlags", "288");
            this.dfUserGroup.NamedProperties.Put("LovReference", "");
            this.dfUserGroup.NamedProperties.Put("ResizeableChildObject", "");
            this.dfUserGroup.NamedProperties.Put("SqlColumn", "USER_GROUP");
            this.dfUserGroup.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfDateReg
            // 
            resources.ApplyResources(this.labeldfDateReg, "labeldfDateReg");
            this.labeldfDateReg.Name = "labeldfDateReg";
            // 
            // dfDateReg
            // 
            this.dfDateReg.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.dfDateReg.Format = "d";
            resources.ApplyResources(this.dfDateReg, "dfDateReg");
            this.dfDateReg.Name = "dfDateReg";
            this.dfDateReg.NamedProperties.Put("EnumerateMethod", "");
            this.dfDateReg.NamedProperties.Put("FieldFlags", "288");
            this.dfDateReg.NamedProperties.Put("LovReference", "");
            this.dfDateReg.NamedProperties.Put("ResizeableChildObject", "");
            this.dfDateReg.NamedProperties.Put("SqlColumn", "DATE_REG");
            this.dfDateReg.NamedProperties.Put("ValidateMethod", "");
            // 
            // cbNotes
            // 
            resources.ApplyResources(this.cbNotes, "cbNotes");
            this.cbNotes.Name = "cbNotes";
            this.cbNotes.NamedProperties.Put("DataType", "5");
            this.cbNotes.NamedProperties.Put("EnumerateMethod", "");
            this.cbNotes.NamedProperties.Put("FieldFlags", "288");
            this.cbNotes.NamedProperties.Put("LovReference", "");
            this.cbNotes.NamedProperties.Put("ResizeableChildObject", "");
            this.cbNotes.NamedProperties.Put("SqlColumn", "Voucher_Note_API.Check_Note_Exist(COMPANY,ACCOUNTING_YEAR,VOUCHER_TYPE,VOUCHER_NO" +
                    ")");
            this.cbNotes.NamedProperties.Put("ValidateMethod", "");
            this.cbNotes.NamedProperties.Put("XDataLength", "");
            this.cbNotes.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cbNotes_WindowActions);
            // 
            // labeldfUpdateError
            // 
            resources.ApplyResources(this.labeldfUpdateError, "labeldfUpdateError");
            this.labeldfUpdateError.Name = "labeldfUpdateError";
            // 
            // dfUpdateError
            // 
            resources.ApplyResources(this.dfUpdateError, "dfUpdateError");
            this.dfUpdateError.Name = "dfUpdateError";
            this.dfUpdateError.NamedProperties.Put("EnumerateMethod", "");
            this.dfUpdateError.NamedProperties.Put("FieldFlags", "288");
            this.dfUpdateError.NamedProperties.Put("LovReference", "");
            this.dfUpdateError.NamedProperties.Put("ResizeableChildObject", "");
            this.dfUpdateError.NamedProperties.Put("SqlColumn", "UPDATE_ERROR");
            this.dfUpdateError.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfCodePartValue
            // 
            resources.ApplyResources(this.labeldfCodePartValue, "labeldfCodePartValue");
            this.labeldfCodePartValue.Name = "labeldfCodePartValue";
            // 
            // dfCodePartValue
            // 
            resources.ApplyResources(this.dfCodePartValue, "dfCodePartValue");
            this.dfCodePartValue.Name = "dfCodePartValue";
            this.dfCodePartValue.NamedProperties.Put("EnumerateMethod", "");
            this.dfCodePartValue.NamedProperties.Put("LovReference", "");
            this.dfCodePartValue.NamedProperties.Put("ResizeableChildObject", "");
            this.dfCodePartValue.NamedProperties.Put("SqlColumn", "");
            this.dfCodePartValue.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfCodePartDescription
            // 
            resources.ApplyResources(this.labeldfCodePartDescription, "labeldfCodePartDescription");
            this.labeldfCodePartDescription.Name = "labeldfCodePartDescription";
            // 
            // dfCodePartDescription
            // 
            resources.ApplyResources(this.dfCodePartDescription, "dfCodePartDescription");
            this.dfCodePartDescription.Name = "dfCodePartDescription";
            this.dfCodePartDescription.NamedProperties.Put("EnumerateMethod", "");
            this.dfCodePartDescription.NamedProperties.Put("LovReference", "");
            this.dfCodePartDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.dfCodePartDescription.NamedProperties.Put("SqlColumn", "");
            this.dfCodePartDescription.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfFunctionGroup
            // 
            resources.ApplyResources(this.labeldfFunctionGroup, "labeldfFunctionGroup");
            this.labeldfFunctionGroup.Name = "labeldfFunctionGroup";
            // 
            // dfFunctionGroup
            // 
            this.dfFunctionGroup.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfFunctionGroup, "dfFunctionGroup");
            this.dfFunctionGroup.Name = "dfFunctionGroup";
            this.dfFunctionGroup.NamedProperties.Put("EnumerateMethod", "");
            this.dfFunctionGroup.NamedProperties.Put("LovReference", "");
            this.dfFunctionGroup.NamedProperties.Put("ResizeableChildObject", "");
            this.dfFunctionGroup.NamedProperties.Put("SqlColumn", "FUNCTION_GROUP");
            this.dfFunctionGroup.NamedProperties.Put("ValidateMethod", "");
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
            // menuOperations
            // 
            this.menuOperations.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_Change_1});
            this.menuOperations.Name = "menuOperations";
            resources.ApplyResources(this.menuOperations, "menuOperations");
            // 
            // menuItem_Change_1
            // 
            this.menuItem_Change_1.Command = this.menuOperations_menuChange__Company___;
            this.menuItem_Change_1.Name = "menuItem_Change_1";
            resources.ApplyResources(this.menuItem_Change_1, "menuItem_Change_1");
            this.menuItem_Change_1.Text = "Change &Company...";
            // 
            // menuTblMethods
            // 
            this.menuTblMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_Change_2});
            this.menuTblMethods.Name = "menuTblMethods";
            resources.ApplyResources(this.menuTblMethods, "menuTblMethods");
            // 
            // menuItem_Change_2
            // 
            this.menuItem_Change_2.Command = this.menuTblMethods_menuChange__Company___;
            this.menuItem_Change_2.Name = "menuItem_Change_2";
            resources.ApplyResources(this.menuItem_Change_2, "menuItem_Change_2");
            this.menuItem_Change_2.Text = "Change &Company...";
            // 
            // tblVoucherRow
            // 
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colCompany);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colVoucherType);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colVoucherNo);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colAccountingYear);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colRowNo);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colVoucherCompany);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colAccount);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colsAccountDesc);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colCodeB);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colsCodeBDesc);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colCodeC);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colsCodeCDesc);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colCodeD);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colsCodeDDesc);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colCodeE);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colsCodeEDesc);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colCodeF);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colsCodeFDesc);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colCodeG);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colsCodeGDesc);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colCodeH);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colsCodeHDesc);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colCodeI);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colsCodeIDesc);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colCodeJ);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colsCodeJDesc);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colProcessCode);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colCurrencyType);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colCurrencyCode);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colCurrencyRate);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colConversionFactor);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colDebitAmount);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colCreditAmount);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colAmount);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colAccCurr);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colCurrencyDebitAmount);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colCurrencyCreditAmount);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colCurrencyAmount);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colQuantity);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colPeriodAllocation);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colText);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colsDeliveryTypeId);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colsDeliveTypeDesc);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colOptionalCode);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colActivitySeqNo);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colUpdateError);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colTransCode);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colConvertionFactor);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colCodeDemand);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colCodePart);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colTransferId);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colReferenceSerie);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colReferenceNumber);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colVoucherTypeRef);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colVoucherNoRef);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colAccountingYearRef);
            this.tblVoucherRow.Controls.Add(this.tblVoucherRow_colnRowGroupId);
            resources.ApplyResources(this.tblVoucherRow, "tblVoucherRow");
            this.tblVoucherRow.Name = "tblVoucherRow";
            this.tblVoucherRow.NamedProperties.Put("DefaultOrderBy", "");
            this.tblVoucherRow.NamedProperties.Put("DefaultWhere", "");
            this.tblVoucherRow.NamedProperties.Put("LogicalUnit", "MultiCompanyVoucherRow");
            this.tblVoucherRow.NamedProperties.Put("PackageName", "MULTI_COMPANY_VOUCHER_ROW_API");
            this.tblVoucherRow.NamedProperties.Put("ResizeableChildObject", "LLMM");
            this.tblVoucherRow.NamedProperties.Put("SourceFlags", "16833");
            this.tblVoucherRow.NamedProperties.Put("ViewName", "MULTI_COMPANY_VOUCHER_ROW2");
            this.tblVoucherRow.NamedProperties.Put("Warnings", "FALSE");
            this.tblVoucherRow.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblVoucherRow_WindowActions);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colnRowGroupId, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colAccountingYearRef, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colVoucherNoRef, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colVoucherTypeRef, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colReferenceNumber, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colReferenceSerie, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colTransferId, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colCodePart, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colCodeDemand, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colConvertionFactor, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colTransCode, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colUpdateError, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colActivitySeqNo, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colOptionalCode, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colsDeliveTypeDesc, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colsDeliveryTypeId, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colText, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colPeriodAllocation, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colQuantity, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colCurrencyAmount, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colCurrencyCreditAmount, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colCurrencyDebitAmount, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colAccCurr, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colAmount, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colCreditAmount, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colDebitAmount, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colConversionFactor, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colCurrencyRate, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colCurrencyCode, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colCurrencyType, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colProcessCode, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colsCodeJDesc, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colCodeJ, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colsCodeIDesc, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colCodeI, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colsCodeHDesc, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colCodeH, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colsCodeGDesc, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colCodeG, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colsCodeFDesc, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colCodeF, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colsCodeEDesc, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colCodeE, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colsCodeDDesc, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colCodeD, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colsCodeCDesc, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colCodeC, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colsCodeBDesc, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colCodeB, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colsAccountDesc, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colAccount, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colVoucherCompany, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colRowNo, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colAccountingYear, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colVoucherNo, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colVoucherType, 0);
            this.tblVoucherRow.Controls.SetChildIndex(this.tblVoucherRow_colCompany, 0);
            // 
            // tblVoucherRow_colCompany
            // 
            this.tblVoucherRow_colCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblVoucherRow_colCompany, "tblVoucherRow_colCompany");
            this.tblVoucherRow_colCompany.MaxLength = 20;
            this.tblVoucherRow_colCompany.Name = "tblVoucherRow_colCompany";
            this.tblVoucherRow_colCompany.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colCompany.NamedProperties.Put("FieldFlags", "64");
            this.tblVoucherRow_colCompany.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.tblVoucherRow_colCompany.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colCompany.Position = 3;
            this.tblVoucherRow_colCompany.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colVoucherCompany_WindowActions);
            // 
            // tblVoucherRow_colVoucherType
            // 
            this.tblVoucherRow_colVoucherType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblVoucherRow_colVoucherType, "tblVoucherRow_colVoucherType");
            this.tblVoucherRow_colVoucherType.MaxLength = 3;
            this.tblVoucherRow_colVoucherType.Name = "tblVoucherRow_colVoucherType";
            this.tblVoucherRow_colVoucherType.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colVoucherType.NamedProperties.Put("FieldFlags", "64");
            this.tblVoucherRow_colVoucherType.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colVoucherType.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colVoucherType.NamedProperties.Put("SqlColumn", "VOUCHER_TYPE");
            this.tblVoucherRow_colVoucherType.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colVoucherType.Position = 4;
            // 
            // tblVoucherRow_colVoucherNo
            // 
            this.tblVoucherRow_colVoucherNo.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.tblVoucherRow_colVoucherNo, "tblVoucherRow_colVoucherNo");
            this.tblVoucherRow_colVoucherNo.MaxLength = 10;
            this.tblVoucherRow_colVoucherNo.Name = "tblVoucherRow_colVoucherNo";
            this.tblVoucherRow_colVoucherNo.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colVoucherNo.NamedProperties.Put("FieldFlags", "64");
            this.tblVoucherRow_colVoucherNo.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colVoucherNo.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colVoucherNo.NamedProperties.Put("SqlColumn", "VOUCHER_NO");
            this.tblVoucherRow_colVoucherNo.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colVoucherNo.Position = 5;
            // 
            // tblVoucherRow_colAccountingYear
            // 
            this.tblVoucherRow_colAccountingYear.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.tblVoucherRow_colAccountingYear, "tblVoucherRow_colAccountingYear");
            this.tblVoucherRow_colAccountingYear.Name = "tblVoucherRow_colAccountingYear";
            this.tblVoucherRow_colAccountingYear.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colAccountingYear.NamedProperties.Put("FieldFlags", "64");
            this.tblVoucherRow_colAccountingYear.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colAccountingYear.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colAccountingYear.NamedProperties.Put("SqlColumn", "ACCOUNTING_YEAR");
            this.tblVoucherRow_colAccountingYear.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colAccountingYear.Position = 6;
            // 
            // tblVoucherRow_colRowNo
            // 
            this.tblVoucherRow_colRowNo.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVoucherRow_colRowNo.Name = "tblVoucherRow_colRowNo";
            this.tblVoucherRow_colRowNo.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colRowNo.NamedProperties.Put("FieldFlags", "160");
            this.tblVoucherRow_colRowNo.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colRowNo.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colRowNo.NamedProperties.Put("SqlColumn", "ROW_NO");
            this.tblVoucherRow_colRowNo.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colRowNo.Position = 7;
            resources.ApplyResources(this.tblVoucherRow_colRowNo, "tblVoucherRow_colRowNo");
            // 
            // tblVoucherRow_colVoucherCompany
            // 
            this.tblVoucherRow_colVoucherCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblVoucherRow_colVoucherCompany.MaxLength = 20;
            this.tblVoucherRow_colVoucherCompany.Name = "tblVoucherRow_colVoucherCompany";
            this.tblVoucherRow_colVoucherCompany.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colVoucherCompany.NamedProperties.Put("FieldFlags", "288");
            this.tblVoucherRow_colVoucherCompany.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colVoucherCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colVoucherCompany.NamedProperties.Put("SqlColumn", "VOUCHER_COMPANY");
            this.tblVoucherRow_colVoucherCompany.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colVoucherCompany.Position = 8;
            resources.ApplyResources(this.tblVoucherRow_colVoucherCompany, "tblVoucherRow_colVoucherCompany");
            this.tblVoucherRow_colVoucherCompany.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colVoucherCompany_WindowActions);
            // 
            // tblVoucherRow_colAccount
            // 
            this.tblVoucherRow_colAccount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblVoucherRow_colAccount.Name = "tblVoucherRow_colAccount";
            this.tblVoucherRow_colAccount.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colAccount.NamedProperties.Put("FieldFlags", "288");
            this.tblVoucherRow_colAccount.NamedProperties.Put("LovReference", "PS_CODE_ACCOUNT(VOUCHER_COMPANY)");
            this.tblVoucherRow_colAccount.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colAccount.NamedProperties.Put("SqlColumn", "ACCOUNT");
            this.tblVoucherRow_colAccount.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colAccount.Position = 9;
            resources.ApplyResources(this.tblVoucherRow_colAccount, "tblVoucherRow_colAccount");
            // 
            // tblVoucherRow_colsAccountDesc
            // 
            this.tblVoucherRow_colsAccountDesc.Name = "tblVoucherRow_colsAccountDesc";
            this.tblVoucherRow_colsAccountDesc.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colsAccountDesc.NamedProperties.Put("FieldFlags", "2304");
            this.tblVoucherRow_colsAccountDesc.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colsAccountDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colsAccountDesc.NamedProperties.Put("SqlColumn", "ACCOUNT_DESC");
            this.tblVoucherRow_colsAccountDesc.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colsAccountDesc.Position = 10;
            resources.ApplyResources(this.tblVoucherRow_colsAccountDesc, "tblVoucherRow_colsAccountDesc");
            // 
            // tblVoucherRow_colCodeB
            // 
            this.tblVoucherRow_colCodeB.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblVoucherRow_colCodeB.Name = "tblVoucherRow_colCodeB";
            this.tblVoucherRow_colCodeB.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colCodeB.NamedProperties.Put("FieldFlags", "288");
            this.tblVoucherRow_colCodeB.NamedProperties.Put("LovReference", "CODE_B(VOUCHER_COMPANY)");
            this.tblVoucherRow_colCodeB.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colCodeB.NamedProperties.Put("SqlColumn", "CODE_B");
            this.tblVoucherRow_colCodeB.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colCodeB.Position = 11;
            resources.ApplyResources(this.tblVoucherRow_colCodeB, "tblVoucherRow_colCodeB");
            // 
            // tblVoucherRow_colsCodeBDesc
            // 
            this.tblVoucherRow_colsCodeBDesc.Name = "tblVoucherRow_colsCodeBDesc";
            this.tblVoucherRow_colsCodeBDesc.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colsCodeBDesc.NamedProperties.Put("FieldFlags", "2304");
            this.tblVoucherRow_colsCodeBDesc.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colsCodeBDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colsCodeBDesc.NamedProperties.Put("SqlColumn", "CODE_B_DESC");
            this.tblVoucherRow_colsCodeBDesc.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colsCodeBDesc.Position = 12;
            resources.ApplyResources(this.tblVoucherRow_colsCodeBDesc, "tblVoucherRow_colsCodeBDesc");
            // 
            // tblVoucherRow_colCodeC
            // 
            this.tblVoucherRow_colCodeC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblVoucherRow_colCodeC.Name = "tblVoucherRow_colCodeC";
            this.tblVoucherRow_colCodeC.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colCodeC.NamedProperties.Put("FieldFlags", "288");
            this.tblVoucherRow_colCodeC.NamedProperties.Put("LovReference", "CODE_C(VOUCHER_COMPANY)");
            this.tblVoucherRow_colCodeC.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colCodeC.NamedProperties.Put("SqlColumn", "CODE_C");
            this.tblVoucherRow_colCodeC.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colCodeC.Position = 13;
            resources.ApplyResources(this.tblVoucherRow_colCodeC, "tblVoucherRow_colCodeC");
            // 
            // tblVoucherRow_colsCodeCDesc
            // 
            this.tblVoucherRow_colsCodeCDesc.Name = "tblVoucherRow_colsCodeCDesc";
            this.tblVoucherRow_colsCodeCDesc.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colsCodeCDesc.NamedProperties.Put("FieldFlags", "2304");
            this.tblVoucherRow_colsCodeCDesc.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colsCodeCDesc.NamedProperties.Put("SqlColumn", "CODE_C_DESC");
            this.tblVoucherRow_colsCodeCDesc.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colsCodeCDesc.Position = 14;
            resources.ApplyResources(this.tblVoucherRow_colsCodeCDesc, "tblVoucherRow_colsCodeCDesc");
            // 
            // tblVoucherRow_colCodeD
            // 
            this.tblVoucherRow_colCodeD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblVoucherRow_colCodeD.Name = "tblVoucherRow_colCodeD";
            this.tblVoucherRow_colCodeD.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colCodeD.NamedProperties.Put("FieldFlags", "288");
            this.tblVoucherRow_colCodeD.NamedProperties.Put("LovReference", "CODE_D(VOUCHER_COMPANY)");
            this.tblVoucherRow_colCodeD.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colCodeD.NamedProperties.Put("SqlColumn", "CODE_D");
            this.tblVoucherRow_colCodeD.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colCodeD.Position = 15;
            resources.ApplyResources(this.tblVoucherRow_colCodeD, "tblVoucherRow_colCodeD");
            // 
            // tblVoucherRow_colsCodeDDesc
            // 
            this.tblVoucherRow_colsCodeDDesc.Name = "tblVoucherRow_colsCodeDDesc";
            this.tblVoucherRow_colsCodeDDesc.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colsCodeDDesc.NamedProperties.Put("FieldFlags", "2304");
            this.tblVoucherRow_colsCodeDDesc.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colsCodeDDesc.NamedProperties.Put("SqlColumn", "CODE_D_DESC");
            this.tblVoucherRow_colsCodeDDesc.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colsCodeDDesc.Position = 16;
            resources.ApplyResources(this.tblVoucherRow_colsCodeDDesc, "tblVoucherRow_colsCodeDDesc");
            // 
            // tblVoucherRow_colCodeE
            // 
            this.tblVoucherRow_colCodeE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblVoucherRow_colCodeE.Name = "tblVoucherRow_colCodeE";
            this.tblVoucherRow_colCodeE.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colCodeE.NamedProperties.Put("FieldFlags", "288");
            this.tblVoucherRow_colCodeE.NamedProperties.Put("LovReference", "CODE_E(VOUCHER_COMPANY)");
            this.tblVoucherRow_colCodeE.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colCodeE.NamedProperties.Put("SqlColumn", "CODE_E");
            this.tblVoucherRow_colCodeE.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colCodeE.Position = 17;
            resources.ApplyResources(this.tblVoucherRow_colCodeE, "tblVoucherRow_colCodeE");
            // 
            // tblVoucherRow_colsCodeEDesc
            // 
            this.tblVoucherRow_colsCodeEDesc.Name = "tblVoucherRow_colsCodeEDesc";
            this.tblVoucherRow_colsCodeEDesc.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colsCodeEDesc.NamedProperties.Put("FieldFlags", "2304");
            this.tblVoucherRow_colsCodeEDesc.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colsCodeEDesc.NamedProperties.Put("SqlColumn", "CODE_E_DESC");
            this.tblVoucherRow_colsCodeEDesc.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colsCodeEDesc.Position = 18;
            resources.ApplyResources(this.tblVoucherRow_colsCodeEDesc, "tblVoucherRow_colsCodeEDesc");
            // 
            // tblVoucherRow_colCodeF
            // 
            this.tblVoucherRow_colCodeF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblVoucherRow_colCodeF.Name = "tblVoucherRow_colCodeF";
            this.tblVoucherRow_colCodeF.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colCodeF.NamedProperties.Put("FieldFlags", "288");
            this.tblVoucherRow_colCodeF.NamedProperties.Put("LovReference", "CODE_F(VOUCHER_COMPANY)");
            this.tblVoucherRow_colCodeF.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colCodeF.NamedProperties.Put("SqlColumn", "CODE_F");
            this.tblVoucherRow_colCodeF.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colCodeF.Position = 19;
            resources.ApplyResources(this.tblVoucherRow_colCodeF, "tblVoucherRow_colCodeF");
            // 
            // tblVoucherRow_colsCodeFDesc
            // 
            this.tblVoucherRow_colsCodeFDesc.Name = "tblVoucherRow_colsCodeFDesc";
            this.tblVoucherRow_colsCodeFDesc.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colsCodeFDesc.NamedProperties.Put("FieldFlags", "2304");
            this.tblVoucherRow_colsCodeFDesc.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colsCodeFDesc.NamedProperties.Put("SqlColumn", "CODE_F_DESC");
            this.tblVoucherRow_colsCodeFDesc.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colsCodeFDesc.Position = 20;
            resources.ApplyResources(this.tblVoucherRow_colsCodeFDesc, "tblVoucherRow_colsCodeFDesc");
            // 
            // tblVoucherRow_colCodeG
            // 
            this.tblVoucherRow_colCodeG.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblVoucherRow_colCodeG.Name = "tblVoucherRow_colCodeG";
            this.tblVoucherRow_colCodeG.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colCodeG.NamedProperties.Put("FieldFlags", "288");
            this.tblVoucherRow_colCodeG.NamedProperties.Put("LovReference", "CODE_G(VOUCHER_COMPANY)");
            this.tblVoucherRow_colCodeG.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colCodeG.NamedProperties.Put("SqlColumn", "CODE_G");
            this.tblVoucherRow_colCodeG.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colCodeG.Position = 21;
            resources.ApplyResources(this.tblVoucherRow_colCodeG, "tblVoucherRow_colCodeG");
            // 
            // tblVoucherRow_colsCodeGDesc
            // 
            this.tblVoucherRow_colsCodeGDesc.Name = "tblVoucherRow_colsCodeGDesc";
            this.tblVoucherRow_colsCodeGDesc.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colsCodeGDesc.NamedProperties.Put("FieldFlags", "2304");
            this.tblVoucherRow_colsCodeGDesc.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colsCodeGDesc.NamedProperties.Put("SqlColumn", "CODE_G_DESC");
            this.tblVoucherRow_colsCodeGDesc.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colsCodeGDesc.Position = 22;
            resources.ApplyResources(this.tblVoucherRow_colsCodeGDesc, "tblVoucherRow_colsCodeGDesc");
            // 
            // tblVoucherRow_colCodeH
            // 
            this.tblVoucherRow_colCodeH.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblVoucherRow_colCodeH.Name = "tblVoucherRow_colCodeH";
            this.tblVoucherRow_colCodeH.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colCodeH.NamedProperties.Put("FieldFlags", "288");
            this.tblVoucherRow_colCodeH.NamedProperties.Put("LovReference", "CODE_H(VOUCHER_COMPANY)");
            this.tblVoucherRow_colCodeH.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colCodeH.NamedProperties.Put("SqlColumn", "CODE_H");
            this.tblVoucherRow_colCodeH.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colCodeH.Position = 23;
            resources.ApplyResources(this.tblVoucherRow_colCodeH, "tblVoucherRow_colCodeH");
            // 
            // tblVoucherRow_colsCodeHDesc
            // 
            this.tblVoucherRow_colsCodeHDesc.Name = "tblVoucherRow_colsCodeHDesc";
            this.tblVoucherRow_colsCodeHDesc.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colsCodeHDesc.NamedProperties.Put("FieldFlags", "2304");
            this.tblVoucherRow_colsCodeHDesc.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colsCodeHDesc.NamedProperties.Put("SqlColumn", "CODE_H_DESC");
            this.tblVoucherRow_colsCodeHDesc.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colsCodeHDesc.Position = 24;
            resources.ApplyResources(this.tblVoucherRow_colsCodeHDesc, "tblVoucherRow_colsCodeHDesc");
            // 
            // tblVoucherRow_colCodeI
            // 
            this.tblVoucherRow_colCodeI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblVoucherRow_colCodeI.Name = "tblVoucherRow_colCodeI";
            this.tblVoucherRow_colCodeI.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colCodeI.NamedProperties.Put("FieldFlags", "288");
            this.tblVoucherRow_colCodeI.NamedProperties.Put("LovReference", "CODE_I(VOUCHER_COMPANY)");
            this.tblVoucherRow_colCodeI.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colCodeI.NamedProperties.Put("SqlColumn", "CODE_I");
            this.tblVoucherRow_colCodeI.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colCodeI.Position = 25;
            resources.ApplyResources(this.tblVoucherRow_colCodeI, "tblVoucherRow_colCodeI");
            // 
            // tblVoucherRow_colsCodeIDesc
            // 
            this.tblVoucherRow_colsCodeIDesc.Name = "tblVoucherRow_colsCodeIDesc";
            this.tblVoucherRow_colsCodeIDesc.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colsCodeIDesc.NamedProperties.Put("FieldFlags", "2304");
            this.tblVoucherRow_colsCodeIDesc.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colsCodeIDesc.NamedProperties.Put("SqlColumn", "CODE_I_DESC");
            this.tblVoucherRow_colsCodeIDesc.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colsCodeIDesc.Position = 26;
            resources.ApplyResources(this.tblVoucherRow_colsCodeIDesc, "tblVoucherRow_colsCodeIDesc");
            // 
            // tblVoucherRow_colCodeJ
            // 
            this.tblVoucherRow_colCodeJ.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblVoucherRow_colCodeJ.Name = "tblVoucherRow_colCodeJ";
            this.tblVoucherRow_colCodeJ.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colCodeJ.NamedProperties.Put("FieldFlags", "288");
            this.tblVoucherRow_colCodeJ.NamedProperties.Put("LovReference", "CODE_J(VOUCHER_COMPANY)");
            this.tblVoucherRow_colCodeJ.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colCodeJ.NamedProperties.Put("SqlColumn", "CODE_J");
            this.tblVoucherRow_colCodeJ.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colCodeJ.Position = 27;
            resources.ApplyResources(this.tblVoucherRow_colCodeJ, "tblVoucherRow_colCodeJ");
            // 
            // tblVoucherRow_colsCodeJDesc
            // 
            this.tblVoucherRow_colsCodeJDesc.Name = "tblVoucherRow_colsCodeJDesc";
            this.tblVoucherRow_colsCodeJDesc.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colsCodeJDesc.NamedProperties.Put("FieldFlags", "2304");
            this.tblVoucherRow_colsCodeJDesc.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colsCodeJDesc.NamedProperties.Put("SqlColumn", "CODE_J_DESC");
            this.tblVoucherRow_colsCodeJDesc.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colsCodeJDesc.Position = 28;
            resources.ApplyResources(this.tblVoucherRow_colsCodeJDesc, "tblVoucherRow_colsCodeJDesc");
            // 
            // tblVoucherRow_colProcessCode
            // 
            this.tblVoucherRow_colProcessCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblVoucherRow_colProcessCode.Name = "tblVoucherRow_colProcessCode";
            this.tblVoucherRow_colProcessCode.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colProcessCode.NamedProperties.Put("FieldFlags", "288");
            this.tblVoucherRow_colProcessCode.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colProcessCode.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colProcessCode.NamedProperties.Put("SqlColumn", "");
            this.tblVoucherRow_colProcessCode.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colProcessCode.Position = 29;
            resources.ApplyResources(this.tblVoucherRow_colProcessCode, "tblVoucherRow_colProcessCode");
            // 
            // tblVoucherRow_colCurrencyType
            // 
            this.tblVoucherRow_colCurrencyType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblVoucherRow_colCurrencyType, "tblVoucherRow_colCurrencyType");
            this.tblVoucherRow_colCurrencyType.MaxLength = 10;
            this.tblVoucherRow_colCurrencyType.Name = "tblVoucherRow_colCurrencyType";
            this.tblVoucherRow_colCurrencyType.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colCurrencyType.NamedProperties.Put("FieldFlags", "288");
            this.tblVoucherRow_colCurrencyType.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colCurrencyType.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colCurrencyType.NamedProperties.Put("SqlColumn", "CURRENCY_TYPE");
            this.tblVoucherRow_colCurrencyType.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colCurrencyType.Position = 30;
            // 
            // tblVoucherRow_colCurrencyCode
            // 
            this.tblVoucherRow_colCurrencyCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblVoucherRow_colCurrencyCode.Name = "tblVoucherRow_colCurrencyCode";
            this.tblVoucherRow_colCurrencyCode.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colCurrencyCode.NamedProperties.Put("FieldFlags", "288");
            this.tblVoucherRow_colCurrencyCode.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colCurrencyCode.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colCurrencyCode.NamedProperties.Put("SqlColumn", "CURRENCY_CODE");
            this.tblVoucherRow_colCurrencyCode.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colCurrencyCode.Position = 31;
            resources.ApplyResources(this.tblVoucherRow_colCurrencyCode, "tblVoucherRow_colCurrencyCode");
            // 
            // tblVoucherRow_colCurrencyRate
            // 
            this.tblVoucherRow_colCurrencyRate.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVoucherRow_colCurrencyRate.Name = "tblVoucherRow_colCurrencyRate";
            this.tblVoucherRow_colCurrencyRate.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colCurrencyRate.NamedProperties.Put("FieldFlags", "288");
            this.tblVoucherRow_colCurrencyRate.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colCurrencyRate.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colCurrencyRate.NamedProperties.Put("SqlColumn", "CURRENCY_RATE");
            this.tblVoucherRow_colCurrencyRate.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colCurrencyRate.Position = 32;
            this.tblVoucherRow_colCurrencyRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblVoucherRow_colCurrencyRate, "tblVoucherRow_colCurrencyRate");
            // 
            // tblVoucherRow_colConversionFactor
            // 
            this.tblVoucherRow_colConversionFactor.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVoucherRow_colConversionFactor.Name = "tblVoucherRow_colConversionFactor";
            this.tblVoucherRow_colConversionFactor.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colConversionFactor.NamedProperties.Put("FieldFlags", "288");
            this.tblVoucherRow_colConversionFactor.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colConversionFactor.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colConversionFactor.NamedProperties.Put("SqlColumn", "CONV_FACTOR");
            this.tblVoucherRow_colConversionFactor.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colConversionFactor.Position = 33;
            this.tblVoucherRow_colConversionFactor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblVoucherRow_colConversionFactor, "tblVoucherRow_colConversionFactor");
            // 
            // tblVoucherRow_colDebitAmount
            // 
            this.tblVoucherRow_colDebitAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVoucherRow_colDebitAmount.Name = "tblVoucherRow_colDebitAmount";
            this.tblVoucherRow_colDebitAmount.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colDebitAmount.NamedProperties.Put("FieldFlags", "288");
            this.tblVoucherRow_colDebitAmount.NamedProperties.Put("Format", "20");
            this.tblVoucherRow_colDebitAmount.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colDebitAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colDebitAmount.NamedProperties.Put("SqlColumn", "DEBIT_AMOUNT");
            this.tblVoucherRow_colDebitAmount.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colDebitAmount.Position = 34;
            this.tblVoucherRow_colDebitAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblVoucherRow_colDebitAmount, "tblVoucherRow_colDebitAmount");
            // 
            // tblVoucherRow_colCreditAmount
            // 
            this.tblVoucherRow_colCreditAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVoucherRow_colCreditAmount.Name = "tblVoucherRow_colCreditAmount";
            this.tblVoucherRow_colCreditAmount.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colCreditAmount.NamedProperties.Put("FieldFlags", "288");
            this.tblVoucherRow_colCreditAmount.NamedProperties.Put("Format", "20");
            this.tblVoucherRow_colCreditAmount.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colCreditAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colCreditAmount.NamedProperties.Put("SqlColumn", "CREDIT_AMOUNT");
            this.tblVoucherRow_colCreditAmount.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colCreditAmount.Position = 35;
            this.tblVoucherRow_colCreditAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblVoucherRow_colCreditAmount, "tblVoucherRow_colCreditAmount");
            // 
            // tblVoucherRow_colAmount
            // 
            this.tblVoucherRow_colAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVoucherRow_colAmount.MaxLength = 15;
            this.tblVoucherRow_colAmount.Name = "tblVoucherRow_colAmount";
            this.tblVoucherRow_colAmount.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colAmount.NamedProperties.Put("FieldFlags", "288");
            this.tblVoucherRow_colAmount.NamedProperties.Put("Format", "20");
            this.tblVoucherRow_colAmount.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colAmount.NamedProperties.Put("SqlColumn", "AMOUNT");
            this.tblVoucherRow_colAmount.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colAmount.Position = 36;
            this.tblVoucherRow_colAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblVoucherRow_colAmount, "tblVoucherRow_colAmount");
            // 
            // tblVoucherRow_colAccCurr
            // 
            this.tblVoucherRow_colAccCurr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblVoucherRow_colAccCurr.Name = "tblVoucherRow_colAccCurr";
            this.tblVoucherRow_colAccCurr.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colAccCurr.NamedProperties.Put("FieldFlags", "288");
            this.tblVoucherRow_colAccCurr.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colAccCurr.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colAccCurr.NamedProperties.Put("SqlColumn", "PARALLEL_ACC_CURRENCY");
            this.tblVoucherRow_colAccCurr.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colAccCurr.Position = 37;
            resources.ApplyResources(this.tblVoucherRow_colAccCurr, "tblVoucherRow_colAccCurr");
            // 
            // tblVoucherRow_colCurrencyDebitAmount
            // 
            this.tblVoucherRow_colCurrencyDebitAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVoucherRow_colCurrencyDebitAmount.Name = "tblVoucherRow_colCurrencyDebitAmount";
            this.tblVoucherRow_colCurrencyDebitAmount.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colCurrencyDebitAmount.NamedProperties.Put("FieldFlags", "288");
            this.tblVoucherRow_colCurrencyDebitAmount.NamedProperties.Put("Format", "20");
            this.tblVoucherRow_colCurrencyDebitAmount.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colCurrencyDebitAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colCurrencyDebitAmount.NamedProperties.Put("SqlColumn", "CURRENCY_DEBIT_AMOUNT");
            this.tblVoucherRow_colCurrencyDebitAmount.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colCurrencyDebitAmount.Position = 38;
            this.tblVoucherRow_colCurrencyDebitAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblVoucherRow_colCurrencyDebitAmount, "tblVoucherRow_colCurrencyDebitAmount");
            // 
            // tblVoucherRow_colCurrencyCreditAmount
            // 
            this.tblVoucherRow_colCurrencyCreditAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVoucherRow_colCurrencyCreditAmount.Name = "tblVoucherRow_colCurrencyCreditAmount";
            this.tblVoucherRow_colCurrencyCreditAmount.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colCurrencyCreditAmount.NamedProperties.Put("FieldFlags", "288");
            this.tblVoucherRow_colCurrencyCreditAmount.NamedProperties.Put("Format", "20");
            this.tblVoucherRow_colCurrencyCreditAmount.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colCurrencyCreditAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colCurrencyCreditAmount.NamedProperties.Put("SqlColumn", "CURRENCY_CREDIT_AMOUNT");
            this.tblVoucherRow_colCurrencyCreditAmount.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colCurrencyCreditAmount.Position = 39;
            this.tblVoucherRow_colCurrencyCreditAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblVoucherRow_colCurrencyCreditAmount, "tblVoucherRow_colCurrencyCreditAmount");
            // 
            // tblVoucherRow_colCurrencyAmount
            // 
            this.tblVoucherRow_colCurrencyAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVoucherRow_colCurrencyAmount.MaxLength = 15;
            this.tblVoucherRow_colCurrencyAmount.Name = "tblVoucherRow_colCurrencyAmount";
            this.tblVoucherRow_colCurrencyAmount.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colCurrencyAmount.NamedProperties.Put("FieldFlags", "288");
            this.tblVoucherRow_colCurrencyAmount.NamedProperties.Put("Format", "20");
            this.tblVoucherRow_colCurrencyAmount.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colCurrencyAmount.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colCurrencyAmount.NamedProperties.Put("SqlColumn", "CURRENCY_AMOUNT");
            this.tblVoucherRow_colCurrencyAmount.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colCurrencyAmount.Position = 40;
            this.tblVoucherRow_colCurrencyAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblVoucherRow_colCurrencyAmount, "tblVoucherRow_colCurrencyAmount");
            // 
            // tblVoucherRow_colQuantity
            // 
            this.tblVoucherRow_colQuantity.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVoucherRow_colQuantity.Name = "tblVoucherRow_colQuantity";
            this.tblVoucherRow_colQuantity.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colQuantity.NamedProperties.Put("FieldFlags", "288");
            this.tblVoucherRow_colQuantity.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colQuantity.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colQuantity.NamedProperties.Put("SqlColumn", "QUANTITY");
            this.tblVoucherRow_colQuantity.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colQuantity.Position = 41;
            this.tblVoucherRow_colQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblVoucherRow_colQuantity, "tblVoucherRow_colQuantity");
            // 
            // tblVoucherRow_colPeriodAllocation
            // 
            this.tblVoucherRow_colPeriodAllocation.CheckBox.CheckedValue = "Y";
            this.tblVoucherRow_colPeriodAllocation.CheckBox.IgnoreCase = true;
            this.tblVoucherRow_colPeriodAllocation.CheckBox.UncheckedValue = "N";
            this.tblVoucherRow_colPeriodAllocation.MaxLength = 20;
            this.tblVoucherRow_colPeriodAllocation.Name = "tblVoucherRow_colPeriodAllocation";
            this.tblVoucherRow_colPeriodAllocation.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colPeriodAllocation.NamedProperties.Put("FieldFlags", "288");
            this.tblVoucherRow_colPeriodAllocation.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colPeriodAllocation.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colPeriodAllocation.NamedProperties.Put("SqlColumn", "PERIOD_ALLOCATION");
            this.tblVoucherRow_colPeriodAllocation.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colPeriodAllocation.Position = 42;
            resources.ApplyResources(this.tblVoucherRow_colPeriodAllocation, "tblVoucherRow_colPeriodAllocation");
            // 
            // tblVoucherRow_colText
            // 
            this.tblVoucherRow_colText.MaxLength = 200;
            this.tblVoucherRow_colText.Name = "tblVoucherRow_colText";
            this.tblVoucherRow_colText.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colText.NamedProperties.Put("FieldFlags", "288");
            this.tblVoucherRow_colText.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colText.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colText.NamedProperties.Put("SqlColumn", "TEXT");
            this.tblVoucherRow_colText.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colText.Position = 43;
            resources.ApplyResources(this.tblVoucherRow_colText, "tblVoucherRow_colText");
            // 
            // tblVoucherRow_colsDeliveryTypeId
            // 
            this.tblVoucherRow_colsDeliveryTypeId.MaxLength = 20;
            this.tblVoucherRow_colsDeliveryTypeId.Name = "tblVoucherRow_colsDeliveryTypeId";
            this.tblVoucherRow_colsDeliveryTypeId.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colsDeliveryTypeId.NamedProperties.Put("FieldFlags", "288");
            this.tblVoucherRow_colsDeliveryTypeId.NamedProperties.Put("LovReference", "DELIVERY_TYPE(VOUCHER_COMPANY)");
            this.tblVoucherRow_colsDeliveryTypeId.NamedProperties.Put("SqlColumn", "DELIV_TYPE_ID");
            this.tblVoucherRow_colsDeliveryTypeId.Position = 44;
            resources.ApplyResources(this.tblVoucherRow_colsDeliveryTypeId, "tblVoucherRow_colsDeliveryTypeId");
            // 
            // tblVoucherRow_colsDeliveTypeDesc
            // 
            this.tblVoucherRow_colsDeliveTypeDesc.MaxLength = 2000;
            this.tblVoucherRow_colsDeliveTypeDesc.Name = "tblVoucherRow_colsDeliveTypeDesc";
            this.tblVoucherRow_colsDeliveTypeDesc.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colsDeliveTypeDesc.NamedProperties.Put("FieldFlags", "288");
            this.tblVoucherRow_colsDeliveTypeDesc.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colsDeliveTypeDesc.NamedProperties.Put("ParentName", "tblVoucherRow.tblVoucherRow_colsDeliveryTypeId");
            this.tblVoucherRow_colsDeliveTypeDesc.NamedProperties.Put("SqlColumn", "Voucher_Row_API.Get_Delivery_Type_Description(VOUCHER_COMPANY,DELIV_TYPE_ID)");
            this.tblVoucherRow_colsDeliveTypeDesc.Position = 45;
            resources.ApplyResources(this.tblVoucherRow_colsDeliveTypeDesc, "tblVoucherRow_colsDeliveTypeDesc");
            // 
            // tblVoucherRow_colOptionalCode
            // 
            this.tblVoucherRow_colOptionalCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblVoucherRow_colOptionalCode.MaxLength = 20;
            this.tblVoucherRow_colOptionalCode.Name = "tblVoucherRow_colOptionalCode";
            this.tblVoucherRow_colOptionalCode.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colOptionalCode.NamedProperties.Put("FieldFlags", "288");
            this.tblVoucherRow_colOptionalCode.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colOptionalCode.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colOptionalCode.NamedProperties.Put("SqlColumn", "OPTIONAL_CODE");
            this.tblVoucherRow_colOptionalCode.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colOptionalCode.Position = 46;
            resources.ApplyResources(this.tblVoucherRow_colOptionalCode, "tblVoucherRow_colOptionalCode");
            // 
            // tblVoucherRow_colActivitySeqNo
            // 
            this.tblVoucherRow_colActivitySeqNo.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVoucherRow_colActivitySeqNo.Name = "tblVoucherRow_colActivitySeqNo";
            this.tblVoucherRow_colActivitySeqNo.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colActivitySeqNo.NamedProperties.Put("FieldFlags", "288");
            this.tblVoucherRow_colActivitySeqNo.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colActivitySeqNo.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colActivitySeqNo.NamedProperties.Put("SqlColumn", "PROJECT_ACTIVITY_ID");
            this.tblVoucherRow_colActivitySeqNo.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colActivitySeqNo.Position = 47;
            resources.ApplyResources(this.tblVoucherRow_colActivitySeqNo, "tblVoucherRow_colActivitySeqNo");
            // 
            // tblVoucherRow_colUpdateError
            // 
            this.tblVoucherRow_colUpdateError.MaxLength = 200;
            this.tblVoucherRow_colUpdateError.Name = "tblVoucherRow_colUpdateError";
            this.tblVoucherRow_colUpdateError.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colUpdateError.NamedProperties.Put("FieldFlags", "288");
            this.tblVoucherRow_colUpdateError.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colUpdateError.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colUpdateError.NamedProperties.Put("SqlColumn", "UPDATE_ERROR");
            this.tblVoucherRow_colUpdateError.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colUpdateError.Position = 48;
            resources.ApplyResources(this.tblVoucherRow_colUpdateError, "tblVoucherRow_colUpdateError");
            // 
            // tblVoucherRow_colTransCode
            // 
            this.tblVoucherRow_colTransCode.MaxLength = 20;
            this.tblVoucherRow_colTransCode.Name = "tblVoucherRow_colTransCode";
            this.tblVoucherRow_colTransCode.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colTransCode.NamedProperties.Put("FieldFlags", "288");
            this.tblVoucherRow_colTransCode.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colTransCode.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colTransCode.NamedProperties.Put("SqlColumn", "TRANS_CODE");
            this.tblVoucherRow_colTransCode.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colTransCode.Position = 49;
            resources.ApplyResources(this.tblVoucherRow_colTransCode, "tblVoucherRow_colTransCode");
            // 
            // tblVoucherRow_colConvertionFactor
            // 
            this.tblVoucherRow_colConvertionFactor.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.tblVoucherRow_colConvertionFactor, "tblVoucherRow_colConvertionFactor");
            this.tblVoucherRow_colConvertionFactor.Name = "tblVoucherRow_colConvertionFactor";
            this.tblVoucherRow_colConvertionFactor.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colConvertionFactor.NamedProperties.Put("FieldFlags", "288");
            this.tblVoucherRow_colConvertionFactor.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colConvertionFactor.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colConvertionFactor.NamedProperties.Put("SqlColumn", "");
            this.tblVoucherRow_colConvertionFactor.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colConvertionFactor.Position = 50;
            // 
            // tblVoucherRow_colCodeDemand
            // 
            this.tblVoucherRow_colCodeDemand.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblVoucherRow_colCodeDemand, "tblVoucherRow_colCodeDemand");
            this.tblVoucherRow_colCodeDemand.Name = "tblVoucherRow_colCodeDemand";
            this.tblVoucherRow_colCodeDemand.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colCodeDemand.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colCodeDemand.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colCodeDemand.NamedProperties.Put("SqlColumn", "");
            this.tblVoucherRow_colCodeDemand.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colCodeDemand.Position = 51;
            // 
            // tblVoucherRow_colCodePart
            // 
            resources.ApplyResources(this.tblVoucherRow_colCodePart, "tblVoucherRow_colCodePart");
            this.tblVoucherRow_colCodePart.MaxLength = 1;
            this.tblVoucherRow_colCodePart.Name = "tblVoucherRow_colCodePart";
            this.tblVoucherRow_colCodePart.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colCodePart.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colCodePart.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colCodePart.NamedProperties.Put("SqlColumn", "CODE_PART");
            this.tblVoucherRow_colCodePart.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colCodePart.Position = 52;
            // 
            // tblVoucherRow_colTransferId
            // 
            resources.ApplyResources(this.tblVoucherRow_colTransferId, "tblVoucherRow_colTransferId");
            this.tblVoucherRow_colTransferId.MaxLength = 20;
            this.tblVoucherRow_colTransferId.Name = "tblVoucherRow_colTransferId";
            this.tblVoucherRow_colTransferId.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colTransferId.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colTransferId.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colTransferId.NamedProperties.Put("SqlColumn", "TRANSFER_ID");
            this.tblVoucherRow_colTransferId.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colTransferId.Position = 53;
            // 
            // tblVoucherRow_colReferenceSerie
            // 
            this.tblVoucherRow_colReferenceSerie.MaxLength = 50;
            this.tblVoucherRow_colReferenceSerie.Name = "tblVoucherRow_colReferenceSerie";
            this.tblVoucherRow_colReferenceSerie.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colReferenceSerie.NamedProperties.Put("FieldFlags", "288");
            this.tblVoucherRow_colReferenceSerie.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colReferenceSerie.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colReferenceSerie.NamedProperties.Put("SqlColumn", "REFERENCE_SERIE");
            this.tblVoucherRow_colReferenceSerie.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colReferenceSerie.Position = 54;
            resources.ApplyResources(this.tblVoucherRow_colReferenceSerie, "tblVoucherRow_colReferenceSerie");
            // 
            // tblVoucherRow_colReferenceNumber
            // 
            this.tblVoucherRow_colReferenceNumber.MaxLength = 50;
            this.tblVoucherRow_colReferenceNumber.Name = "tblVoucherRow_colReferenceNumber";
            this.tblVoucherRow_colReferenceNumber.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colReferenceNumber.NamedProperties.Put("FieldFlags", "288");
            this.tblVoucherRow_colReferenceNumber.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colReferenceNumber.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colReferenceNumber.NamedProperties.Put("SqlColumn", "REFERENCE_NUMBER");
            this.tblVoucherRow_colReferenceNumber.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colReferenceNumber.Position = 55;
            resources.ApplyResources(this.tblVoucherRow_colReferenceNumber, "tblVoucherRow_colReferenceNumber");
            // 
            // tblVoucherRow_colVoucherTypeRef
            // 
            this.tblVoucherRow_colVoucherTypeRef.Name = "tblVoucherRow_colVoucherTypeRef";
            this.tblVoucherRow_colVoucherTypeRef.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colVoucherTypeRef.NamedProperties.Put("FieldFlags", "288");
            this.tblVoucherRow_colVoucherTypeRef.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colVoucherTypeRef.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colVoucherTypeRef.NamedProperties.Put("SqlColumn", "VOUCHER_TYPE_REF");
            this.tblVoucherRow_colVoucherTypeRef.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colVoucherTypeRef.Position = 56;
            resources.ApplyResources(this.tblVoucherRow_colVoucherTypeRef, "tblVoucherRow_colVoucherTypeRef");
            // 
            // tblVoucherRow_colVoucherNoRef
            // 
            this.tblVoucherRow_colVoucherNoRef.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVoucherRow_colVoucherNoRef.Name = "tblVoucherRow_colVoucherNoRef";
            this.tblVoucherRow_colVoucherNoRef.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colVoucherNoRef.NamedProperties.Put("FieldFlags", "288");
            this.tblVoucherRow_colVoucherNoRef.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colVoucherNoRef.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colVoucherNoRef.NamedProperties.Put("SqlColumn", "VOUCHER_NO_REF");
            this.tblVoucherRow_colVoucherNoRef.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colVoucherNoRef.Position = 57;
            resources.ApplyResources(this.tblVoucherRow_colVoucherNoRef, "tblVoucherRow_colVoucherNoRef");
            // 
            // tblVoucherRow_colAccountingYearRef
            // 
            this.tblVoucherRow_colAccountingYearRef.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVoucherRow_colAccountingYearRef.Name = "tblVoucherRow_colAccountingYearRef";
            this.tblVoucherRow_colAccountingYearRef.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colAccountingYearRef.NamedProperties.Put("FieldFlags", "288");
            this.tblVoucherRow_colAccountingYearRef.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colAccountingYearRef.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colAccountingYearRef.NamedProperties.Put("SqlColumn", "ACCOUNTING_YEAR_REF");
            this.tblVoucherRow_colAccountingYearRef.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colAccountingYearRef.Position = 58;
            resources.ApplyResources(this.tblVoucherRow_colAccountingYearRef, "tblVoucherRow_colAccountingYearRef");
            // 
            // tblVoucherRow_colnRowGroupId
            // 
            this.tblVoucherRow_colnRowGroupId.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblVoucherRow_colnRowGroupId.Name = "tblVoucherRow_colnRowGroupId";
            this.tblVoucherRow_colnRowGroupId.NamedProperties.Put("EnumerateMethod", "");
            this.tblVoucherRow_colnRowGroupId.NamedProperties.Put("FieldFlags", "294");
            this.tblVoucherRow_colnRowGroupId.NamedProperties.Put("LovReference", "");
            this.tblVoucherRow_colnRowGroupId.NamedProperties.Put("ResizeableChildObject", "");
            this.tblVoucherRow_colnRowGroupId.NamedProperties.Put("SqlColumn", "ROW_GROUP_ID");
            this.tblVoucherRow_colnRowGroupId.NamedProperties.Put("ValidateMethod", "");
            this.tblVoucherRow_colnRowGroupId.Position = 59;
            resources.ApplyResources(this.tblVoucherRow_colnRowGroupId, "tblVoucherRow_colnRowGroupId");
            // 
            // frmMCQueryVoucherDetail
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.dfFunctionGroup);
            this.Controls.Add(this.tblVoucherRow);
            this.Controls.Add(this.dfCodePartDescription);
            this.Controls.Add(this.dfCodePartValue);
            this.Controls.Add(this.dfUpdateError);
            this.Controls.Add(this.cbNotes);
            this.Controls.Add(this.dfDateReg);
            this.Controls.Add(this.dfUserGroup);
            this.Controls.Add(this.dfUserid);
            this.Controls.Add(this.dfVoucherDate);
            this.Controls.Add(this.dfAccountingPeriod);
            this.Controls.Add(this.dfAccountingYear);
            this.Controls.Add(this.dfVoucherNo);
            this.Controls.Add(this.ccVoucherType);
            this.Controls.Add(this.dfCompany);
            this.Controls.Add(this.labeldfFunctionGroup);
            this.Controls.Add(this.labeldfCodePartDescription);
            this.Controls.Add(this.labeldfCodePartValue);
            this.Controls.Add(this.labeldfUpdateError);
            this.Controls.Add(this.labeldfDateReg);
            this.Controls.Add(this.labeldfUserGroup);
            this.Controls.Add(this.labeldfUserid);
            this.Controls.Add(this.labeldfVoucherDate);
            this.Controls.Add(this.labeldfAccountingPeriod);
            this.Controls.Add(this.labeldfAccountingYear);
            this.Controls.Add(this.labeldfVoucherNo);
            this.Controls.Add(this.labelccVoucherType);
            this.Controls.Add(this.labeldfCompany);
            this.Controls.Add(this.gbVoucher_Registration_by_User);
            this.Controls.Add(this.gbAccounting_Period);
            this.MaximizeBox = true;
            this.Name = "frmMCQueryVoucherDetail";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "COMPANY = :i_hWndFrame.frmMCQueryVoucherDetail.i_sCompany");
            this.NamedProperties.Put("LogicalUnit", "MultiCompanyVoucher");
            this.NamedProperties.Put("PackageName", "MULTI_COMPANY_VOUCHER_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "0");
            this.NamedProperties.Put("ViewName", "MULTI_COMPANY_VOUCHER2");
            this.NamedProperties.Put("Warnings", "TRUE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.frmMCQueryVoucherDetail_WindowActions);
            this.menuFrmMethods.ResumeLayout(false);
            this.menuOperations.ResumeLayout(false);
            this.menuTblMethods.ResumeLayout(false);
            this.tblVoucherRow.ResumeLayout(false);
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
		
        public Fnd.Windows.Forms.FndCommand menuTblMethods_menuChange__Company___;
        public Fnd.Windows.Forms.FndCommand menuOperations_menuChange__Company___;
        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menuChange__Company___;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuFrmMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuOperations;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change_1;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTblMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change_2;
        public cChildTableFin tblVoucherRow;
        protected cColumn tblVoucherRow_colCompany;
        protected cColumn tblVoucherRow_colVoucherType;
        protected cColumn tblVoucherRow_colVoucherNo;
        protected cColumn tblVoucherRow_colAccountingYear;
        protected cColumn tblVoucherRow_colRowNo;
        protected cColumn tblVoucherRow_colVoucherCompany;
        protected cColumnCodePartFin tblVoucherRow_colAccount;
        protected cColumnCodePartDescFin tblVoucherRow_colsAccountDesc;
        protected cColumnCodePartFin tblVoucherRow_colCodeB;
        protected cColumnCodePartDescFin tblVoucherRow_colsCodeBDesc;
        protected cColumnCodePartFin tblVoucherRow_colCodeC;
        protected cColumnCodePartDescFin tblVoucherRow_colsCodeCDesc;
        protected cColumnCodePartFin tblVoucherRow_colCodeD;
        protected cColumnCodePartDescFin tblVoucherRow_colsCodeDDesc;
        protected cColumnCodePartFin tblVoucherRow_colCodeE;
        protected cColumnCodePartDescFin tblVoucherRow_colsCodeEDesc;
        protected cColumnCodePartFin tblVoucherRow_colCodeF;
        protected cColumnCodePartDescFin tblVoucherRow_colsCodeFDesc;
        protected cColumnCodePartFin tblVoucherRow_colCodeG;
        protected cColumnCodePartDescFin tblVoucherRow_colsCodeGDesc;
        protected cColumnCodePartFin tblVoucherRow_colCodeH;
        protected cColumnCodePartDescFin tblVoucherRow_colsCodeHDesc;
        protected cColumnCodePartFin tblVoucherRow_colCodeI;
        protected cColumnCodePartDescFin tblVoucherRow_colsCodeIDesc;
        protected cColumnCodePartFin tblVoucherRow_colCodeJ;
        protected cColumnCodePartDescFin tblVoucherRow_colsCodeJDesc;
        protected cColumn tblVoucherRow_colProcessCode;
        protected cColumn tblVoucherRow_colCurrencyType;
        protected cColumn tblVoucherRow_colCurrencyCode;
        protected cColumn tblVoucherRow_colCurrencyRate;
        protected cColumn tblVoucherRow_colConversionFactor;
        protected cColumn tblVoucherRow_colDebitAmount;
        protected cColumn tblVoucherRow_colCreditAmount;
        protected cColumn tblVoucherRow_colAmount;
        protected cColumn tblVoucherRow_colAccCurr;
        protected cColumn tblVoucherRow_colCurrencyDebitAmount;
        protected cColumn tblVoucherRow_colCurrencyCreditAmount;
        protected cColumn tblVoucherRow_colCurrencyAmount;
        protected cColumn tblVoucherRow_colQuantity;
        protected cColumn tblVoucherRow_colText;
        protected cColumn tblVoucherRow_colOptionalCode;
        protected cColumn tblVoucherRow_colActivitySeqNo;
        protected cColumn tblVoucherRow_colUpdateError;
        protected cColumn tblVoucherRow_colTransCode;
        protected cColumn tblVoucherRow_colConvertionFactor;
        protected cColumn tblVoucherRow_colCodeDemand;
        protected cColumn tblVoucherRow_colCodePart;
        protected cColumn tblVoucherRow_colTransferId;
        protected cColumn tblVoucherRow_colReferenceSerie;
        protected cColumn tblVoucherRow_colReferenceNumber;
        protected cColumn tblVoucherRow_colVoucherTypeRef;
        protected cColumn tblVoucherRow_colVoucherNoRef;
        protected cColumn tblVoucherRow_colAccountingYearRef;
        protected cColumn tblVoucherRow_colnRowGroupId;
        protected cCheckBoxColumn tblVoucherRow_colPeriodAllocation;
        protected cColumn tblVoucherRow_colsDeliveryTypeId;
        protected cColumn tblVoucherRow_colsDeliveTypeDesc;
	}
}
