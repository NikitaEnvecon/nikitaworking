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
	
	public partial class dlgGLVoucher
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls

        public cPushButton pbCopy;
		public cPushButton pbCancel;
		public cPushButton pbQuery;
		public cPushButton pbVourow;
		public cCheckBox cbCorrection;
		public cCheckBox cbReverse;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgGLVoucher));
            this.pbCopy = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbCancel = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbQuery = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbVourow = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.cbCorrection = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.cbReverse = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.tblGLVoucher = new Ifs.Application.Accrul.cChildTableFin();
            this.tblGLVoucher_colCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblGLVoucher_colVoucherType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblGLVoucher_colVoucherNo = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblGLVoucher_colVoucherDate = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblGLVoucher_colUserGroup = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblGLVoucher_colnAccountingYear = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblGLVoucher_colnAccountingPeriod = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblGLVoucher_colDateReg = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblGLVoucher_colUserid = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblGLVoucher_colTransferId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblGLVoucher_colVoucherText = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblGLVoucher_colText = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblGLVoucher_colJouNo = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblGLVoucher_colInterimVoucher = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblGLVoucher_colVoucherTypeReference = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblGLVoucher_colVoucherNoReference = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblGLVoucher_colnAccountingYearReference = new Ifs.Fnd.ApplicationForms.cColumn();
            this.cPanelCtrlContainer = new Ifs.Fnd.ApplicationForms.cPanel();
            this.ClientArea.SuspendLayout();
            this.tblGLVoucher.SuspendLayout();
            this.cPanelCtrlContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolBar
            // 
            resources.ApplyResources(this.ToolBar, "ToolBar");
            // 
            // ClientArea
            // 
            this.ClientArea.BackColor = System.Drawing.Color.Transparent;
            this.ClientArea.Controls.Add(this.tblGLVoucher);
            this.ClientArea.Controls.Add(this.cPanelCtrlContainer);
            resources.ApplyResources(this.ClientArea, "ClientArea");
            // 
            // commandManager
            // 
            this.commandManager.Components.Add(this.pbCopy);
            this.commandManager.Components.Add(this.pbCancel);
            this.commandManager.Components.Add(this.pbVourow);
            this.commandManager.Components.Add(this.pbQuery);
            this.commandManager.ImageList = null;
            // 
            // pbCopy
            // 
            this.pbCopy.AcceleratorKey = System.Windows.Forms.Keys.Return;
            resources.ApplyResources(this.pbCopy, "pbCopy");
            this.pbCopy.Name = "pbCopy";
            this.pbCopy.NamedProperties.Put("MethodId", "18385");
            this.pbCopy.NamedProperties.Put("MethodParameter", "Copy");
            this.pbCopy.NamedProperties.Put("ResizeableChildObject", "");
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
            // pbQuery
            // 
            this.pbQuery.AcceleratorKey = System.Windows.Forms.Keys.F3;
            resources.ApplyResources(this.pbQuery, "pbQuery");
            this.pbQuery.Name = "pbQuery";
            this.pbQuery.NamedProperties.Put("MethodId", "18385");
            this.pbQuery.NamedProperties.Put("MethodParameter", "Query");
            this.pbQuery.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // pbVourow
            // 
            resources.ApplyResources(this.pbVourow, "pbVourow");
            this.pbVourow.Name = "pbVourow";
            this.pbVourow.NamedProperties.Put("MethodId", "18385");
            this.pbVourow.NamedProperties.Put("MethodParameter", "Vourow");
            this.pbVourow.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // cbCorrection
            // 
            resources.ApplyResources(this.cbCorrection, "cbCorrection");
            this.cbCorrection.Name = "cbCorrection";
            this.cbCorrection.NamedProperties.Put("DataType", "5");
            this.cbCorrection.NamedProperties.Put("EnumerateMethod", "");
            this.cbCorrection.NamedProperties.Put("LovReference", "");
            this.cbCorrection.NamedProperties.Put("ResizeableChildObject", "");
            this.cbCorrection.NamedProperties.Put("SqlColumn", "");
            this.cbCorrection.NamedProperties.Put("ValidateMethod", "");
            this.cbCorrection.NamedProperties.Put("XDataLength", "");
            this.cbCorrection.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cbCorrection_WindowActions);
            // 
            // cbReverse
            // 
            resources.ApplyResources(this.cbReverse, "cbReverse");
            this.cbReverse.Name = "cbReverse";
            this.cbReverse.NamedProperties.Put("DataType", "5");
            this.cbReverse.NamedProperties.Put("EnumerateMethod", "");
            this.cbReverse.NamedProperties.Put("LovReference", "");
            this.cbReverse.NamedProperties.Put("ResizeableChildObject", "");
            this.cbReverse.NamedProperties.Put("SqlColumn", "");
            this.cbReverse.NamedProperties.Put("ValidateMethod", "");
            this.cbReverse.NamedProperties.Put("XDataLength", "");
            this.cbReverse.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cbReverse_WindowActions);
            // 
            // tblGLVoucher
            // 
            resources.ApplyResources(this.tblGLVoucher, "tblGLVoucher");
            this.tblGLVoucher.Controls.Add(this.tblGLVoucher_colCompany);
            this.tblGLVoucher.Controls.Add(this.tblGLVoucher_colVoucherType);
            this.tblGLVoucher.Controls.Add(this.tblGLVoucher_colVoucherNo);
            this.tblGLVoucher.Controls.Add(this.tblGLVoucher_colVoucherDate);
            this.tblGLVoucher.Controls.Add(this.tblGLVoucher_colUserGroup);
            this.tblGLVoucher.Controls.Add(this.tblGLVoucher_colnAccountingYear);
            this.tblGLVoucher.Controls.Add(this.tblGLVoucher_colnAccountingPeriod);
            this.tblGLVoucher.Controls.Add(this.tblGLVoucher_colDateReg);
            this.tblGLVoucher.Controls.Add(this.tblGLVoucher_colUserid);
            this.tblGLVoucher.Controls.Add(this.tblGLVoucher_colTransferId);
            this.tblGLVoucher.Controls.Add(this.tblGLVoucher_colVoucherText);
            this.tblGLVoucher.Controls.Add(this.tblGLVoucher_colText);
            this.tblGLVoucher.Controls.Add(this.tblGLVoucher_colJouNo);
            this.tblGLVoucher.Controls.Add(this.tblGLVoucher_colInterimVoucher);
            this.tblGLVoucher.Controls.Add(this.tblGLVoucher_colVoucherTypeReference);
            this.tblGLVoucher.Controls.Add(this.tblGLVoucher_colVoucherNoReference);
            this.tblGLVoucher.Controls.Add(this.tblGLVoucher_colnAccountingYearReference);
            this.tblGLVoucher.Name = "tblGLVoucher";
            this.tblGLVoucher.NamedProperties.Put("DefaultOrderBy", "");
            this.tblGLVoucher.NamedProperties.Put("DefaultWhere", "COMPANY = :i_hWndFrame.dlgGLVoucher.i_sCompany\r\nAND VOUCHER_TYPE_API.Get_Voucher_" +
        "Group(COMPANY, VOUCHER_TYPE)  IN (\'M\',\'Q\')\r\n \r\nAND JOU_NO >0");
            this.tblGLVoucher.NamedProperties.Put("LogicalUnit", "GenLedVoucher");
            this.tblGLVoucher.NamedProperties.Put("PackageName", "GEN_LED_VOUCHER_API");
            this.tblGLVoucher.NamedProperties.Put("ResizeableChildObject", "");
            this.tblGLVoucher.NamedProperties.Put("SourceFlags", "1");
            this.tblGLVoucher.NamedProperties.Put("ViewName", "GEN_LED_VOUCHER");
            this.tblGLVoucher.NamedProperties.Put("Warnings", "FALSE");
            this.tblGLVoucher.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblGLVoucher_WindowActions);
            this.tblGLVoucher.Controls.SetChildIndex(this.tblGLVoucher_colnAccountingYearReference, 0);
            this.tblGLVoucher.Controls.SetChildIndex(this.tblGLVoucher_colVoucherNoReference, 0);
            this.tblGLVoucher.Controls.SetChildIndex(this.tblGLVoucher_colVoucherTypeReference, 0);
            this.tblGLVoucher.Controls.SetChildIndex(this.tblGLVoucher_colInterimVoucher, 0);
            this.tblGLVoucher.Controls.SetChildIndex(this.tblGLVoucher_colJouNo, 0);
            this.tblGLVoucher.Controls.SetChildIndex(this.tblGLVoucher_colText, 0);
            this.tblGLVoucher.Controls.SetChildIndex(this.tblGLVoucher_colVoucherText, 0);
            this.tblGLVoucher.Controls.SetChildIndex(this.tblGLVoucher_colTransferId, 0);
            this.tblGLVoucher.Controls.SetChildIndex(this.tblGLVoucher_colUserid, 0);
            this.tblGLVoucher.Controls.SetChildIndex(this.tblGLVoucher_colDateReg, 0);
            this.tblGLVoucher.Controls.SetChildIndex(this.tblGLVoucher_colnAccountingPeriod, 0);
            this.tblGLVoucher.Controls.SetChildIndex(this.tblGLVoucher_colnAccountingYear, 0);
            this.tblGLVoucher.Controls.SetChildIndex(this.tblGLVoucher_colUserGroup, 0);
            this.tblGLVoucher.Controls.SetChildIndex(this.tblGLVoucher_colVoucherDate, 0);
            this.tblGLVoucher.Controls.SetChildIndex(this.tblGLVoucher_colVoucherNo, 0);
            this.tblGLVoucher.Controls.SetChildIndex(this.tblGLVoucher_colVoucherType, 0);
            this.tblGLVoucher.Controls.SetChildIndex(this.tblGLVoucher_colCompany, 0);
            // 
            // tblGLVoucher_colCompany
            // 
            resources.ApplyResources(this.tblGLVoucher_colCompany, "tblGLVoucher_colCompany");
            this.tblGLVoucher_colCompany.Name = "tblGLVoucher_colCompany";
            this.tblGLVoucher_colCompany.NamedProperties.Put("EnumerateMethod", "");
            this.tblGLVoucher_colCompany.NamedProperties.Put("FieldFlags", "259");
            this.tblGLVoucher_colCompany.NamedProperties.Put("LovReference", "");
            this.tblGLVoucher_colCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.tblGLVoucher_colCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.tblGLVoucher_colCompany.NamedProperties.Put("ValidateMethod", "");
            this.tblGLVoucher_colCompany.Position = 3;
            // 
            // tblGLVoucher_colVoucherType
            // 
            this.tblGLVoucher_colVoucherType.Name = "tblGLVoucher_colVoucherType";
            this.tblGLVoucher_colVoucherType.NamedProperties.Put("EnumerateMethod", "");
            this.tblGLVoucher_colVoucherType.NamedProperties.Put("FieldFlags", "291");
            this.tblGLVoucher_colVoucherType.NamedProperties.Put("LovReference", "");
            this.tblGLVoucher_colVoucherType.NamedProperties.Put("ResizableChildObject", "");
            this.tblGLVoucher_colVoucherType.NamedProperties.Put("ResizeableChildObject", "");
            this.tblGLVoucher_colVoucherType.NamedProperties.Put("SqlColumn", "VOUCHER_TYPE");
            this.tblGLVoucher_colVoucherType.NamedProperties.Put("ValidateMethod", "");
            this.tblGLVoucher_colVoucherType.Position = 4;
            resources.ApplyResources(this.tblGLVoucher_colVoucherType, "tblGLVoucher_colVoucherType");
            // 
            // tblGLVoucher_colVoucherNo
            // 
            this.tblGLVoucher_colVoucherNo.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblGLVoucher_colVoucherNo.Name = "tblGLVoucher_colVoucherNo";
            this.tblGLVoucher_colVoucherNo.NamedProperties.Put("EnumerateMethod", "");
            this.tblGLVoucher_colVoucherNo.NamedProperties.Put("FieldFlags", "294");
            this.tblGLVoucher_colVoucherNo.NamedProperties.Put("LovReference", "");
            this.tblGLVoucher_colVoucherNo.NamedProperties.Put("ResizeableChildObject", "");
            this.tblGLVoucher_colVoucherNo.NamedProperties.Put("SqlColumn", "VOUCHER_NO");
            this.tblGLVoucher_colVoucherNo.NamedProperties.Put("ValidateMethod", "");
            this.tblGLVoucher_colVoucherNo.Position = 5;
            resources.ApplyResources(this.tblGLVoucher_colVoucherNo, "tblGLVoucher_colVoucherNo");
            // 
            // tblGLVoucher_colVoucherDate
            // 
            this.tblGLVoucher_colVoucherDate.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.tblGLVoucher_colVoucherDate.Format = "d";
            this.tblGLVoucher_colVoucherDate.Name = "tblGLVoucher_colVoucherDate";
            this.tblGLVoucher_colVoucherDate.NamedProperties.Put("EnumerateMethod", "");
            this.tblGLVoucher_colVoucherDate.NamedProperties.Put("FieldFlags", "294");
            this.tblGLVoucher_colVoucherDate.NamedProperties.Put("LovReference", "");
            this.tblGLVoucher_colVoucherDate.NamedProperties.Put("ResizeableChildObject", "");
            this.tblGLVoucher_colVoucherDate.NamedProperties.Put("SqlColumn", "VOUCHER_DATE");
            this.tblGLVoucher_colVoucherDate.NamedProperties.Put("ValidateMethod", "");
            this.tblGLVoucher_colVoucherDate.Position = 6;
            resources.ApplyResources(this.tblGLVoucher_colVoucherDate, "tblGLVoucher_colVoucherDate");
            // 
            // tblGLVoucher_colUserGroup
            // 
            this.tblGLVoucher_colUserGroup.MaxLength = 30;
            this.tblGLVoucher_colUserGroup.Name = "tblGLVoucher_colUserGroup";
            this.tblGLVoucher_colUserGroup.NamedProperties.Put("EnumerateMethod", "");
            this.tblGLVoucher_colUserGroup.NamedProperties.Put("FieldFlags", "294");
            this.tblGLVoucher_colUserGroup.NamedProperties.Put("LovReference", "");
            this.tblGLVoucher_colUserGroup.NamedProperties.Put("ResizeableChildObject", "");
            this.tblGLVoucher_colUserGroup.NamedProperties.Put("SqlColumn", "USER_GROUP");
            this.tblGLVoucher_colUserGroup.NamedProperties.Put("ValidateMethod", "");
            this.tblGLVoucher_colUserGroup.Position = 7;
            resources.ApplyResources(this.tblGLVoucher_colUserGroup, "tblGLVoucher_colUserGroup");
            // 
            // tblGLVoucher_colnAccountingYear
            // 
            this.tblGLVoucher_colnAccountingYear.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblGLVoucher_colnAccountingYear.Name = "tblGLVoucher_colnAccountingYear";
            this.tblGLVoucher_colnAccountingYear.NamedProperties.Put("EnumerateMethod", "");
            this.tblGLVoucher_colnAccountingYear.NamedProperties.Put("FieldFlags", "294");
            this.tblGLVoucher_colnAccountingYear.NamedProperties.Put("LovReference", "");
            this.tblGLVoucher_colnAccountingYear.NamedProperties.Put("ResizeableChildObject", "");
            this.tblGLVoucher_colnAccountingYear.NamedProperties.Put("SqlColumn", "ACCOUNTING_YEAR");
            this.tblGLVoucher_colnAccountingYear.NamedProperties.Put("ValidateMethod", "");
            this.tblGLVoucher_colnAccountingYear.Position = 8;
            resources.ApplyResources(this.tblGLVoucher_colnAccountingYear, "tblGLVoucher_colnAccountingYear");
            // 
            // tblGLVoucher_colnAccountingPeriod
            // 
            this.tblGLVoucher_colnAccountingPeriod.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblGLVoucher_colnAccountingPeriod.Name = "tblGLVoucher_colnAccountingPeriod";
            this.tblGLVoucher_colnAccountingPeriod.NamedProperties.Put("EnumerateMethod", "");
            this.tblGLVoucher_colnAccountingPeriod.NamedProperties.Put("FieldFlags", "294");
            this.tblGLVoucher_colnAccountingPeriod.NamedProperties.Put("LovReference", "");
            this.tblGLVoucher_colnAccountingPeriod.NamedProperties.Put("ResizeableChildObject", "");
            this.tblGLVoucher_colnAccountingPeriod.NamedProperties.Put("SqlColumn", "ACCOUNTING_PERIOD");
            this.tblGLVoucher_colnAccountingPeriod.NamedProperties.Put("ValidateMethod", "");
            this.tblGLVoucher_colnAccountingPeriod.Position = 9;
            resources.ApplyResources(this.tblGLVoucher_colnAccountingPeriod, "tblGLVoucher_colnAccountingPeriod");
            // 
            // tblGLVoucher_colDateReg
            // 
            this.tblGLVoucher_colDateReg.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.tblGLVoucher_colDateReg.Format = "d";
            this.tblGLVoucher_colDateReg.Name = "tblGLVoucher_colDateReg";
            this.tblGLVoucher_colDateReg.NamedProperties.Put("EnumerateMethod", "");
            this.tblGLVoucher_colDateReg.NamedProperties.Put("FieldFlags", "294");
            this.tblGLVoucher_colDateReg.NamedProperties.Put("LovReference", "");
            this.tblGLVoucher_colDateReg.NamedProperties.Put("ResizeableChildObject", "");
            this.tblGLVoucher_colDateReg.NamedProperties.Put("SqlColumn", "DATE_REG");
            this.tblGLVoucher_colDateReg.NamedProperties.Put("ValidateMethod", "");
            this.tblGLVoucher_colDateReg.Position = 10;
            resources.ApplyResources(this.tblGLVoucher_colDateReg, "tblGLVoucher_colDateReg");
            // 
            // tblGLVoucher_colUserid
            // 
            this.tblGLVoucher_colUserid.Name = "tblGLVoucher_colUserid";
            this.tblGLVoucher_colUserid.NamedProperties.Put("EnumerateMethod", "");
            this.tblGLVoucher_colUserid.NamedProperties.Put("FieldFlags", "294");
            this.tblGLVoucher_colUserid.NamedProperties.Put("LovReference", "");
            this.tblGLVoucher_colUserid.NamedProperties.Put("ResizeableChildObject", "");
            this.tblGLVoucher_colUserid.NamedProperties.Put("SqlColumn", "USERID");
            this.tblGLVoucher_colUserid.NamedProperties.Put("ValidateMethod", "");
            this.tblGLVoucher_colUserid.Position = 11;
            resources.ApplyResources(this.tblGLVoucher_colUserid, "tblGLVoucher_colUserid");
            // 
            // tblGLVoucher_colTransferId
            // 
            this.tblGLVoucher_colTransferId.Name = "tblGLVoucher_colTransferId";
            this.tblGLVoucher_colTransferId.NamedProperties.Put("EnumerateMethod", "");
            this.tblGLVoucher_colTransferId.NamedProperties.Put("FieldFlags", "294");
            this.tblGLVoucher_colTransferId.NamedProperties.Put("LovReference", "");
            this.tblGLVoucher_colTransferId.NamedProperties.Put("ResizeableChildObject", "");
            this.tblGLVoucher_colTransferId.NamedProperties.Put("SqlColumn", "TRANSFER_ID");
            this.tblGLVoucher_colTransferId.NamedProperties.Put("ValidateMethod", "");
            this.tblGLVoucher_colTransferId.Position = 12;
            resources.ApplyResources(this.tblGLVoucher_colTransferId, "tblGLVoucher_colTransferId");
            // 
            // tblGLVoucher_colVoucherText
            // 
            resources.ApplyResources(this.tblGLVoucher_colVoucherText, "tblGLVoucher_colVoucherText");
            this.tblGLVoucher_colVoucherText.Name = "tblGLVoucher_colVoucherText";
            this.tblGLVoucher_colVoucherText.NamedProperties.Put("EnumerateMethod", "");
            this.tblGLVoucher_colVoucherText.NamedProperties.Put("LovReference", "");
            this.tblGLVoucher_colVoucherText.NamedProperties.Put("ResizeableChildObject", "");
            this.tblGLVoucher_colVoucherText.NamedProperties.Put("SqlColumn", "VOUCHER_TEXT");
            this.tblGLVoucher_colVoucherText.NamedProperties.Put("ValidateMethod", "");
            this.tblGLVoucher_colVoucherText.Position = 13;
            // 
            // tblGLVoucher_colText
            // 
            this.tblGLVoucher_colText.Name = "tblGLVoucher_colText";
            this.tblGLVoucher_colText.NamedProperties.Put("EnumerateMethod", "");
            this.tblGLVoucher_colText.NamedProperties.Put("FieldFlags", "258");
            this.tblGLVoucher_colText.NamedProperties.Put("LovReference", "");
            this.tblGLVoucher_colText.NamedProperties.Put("ResizeableChildObject", "");
            this.tblGLVoucher_colText.NamedProperties.Put("SqlColumn", "VOUCHER_TEXT");
            this.tblGLVoucher_colText.NamedProperties.Put("ValidateMethod", "");
            this.tblGLVoucher_colText.Position = 14;
            resources.ApplyResources(this.tblGLVoucher_colText, "tblGLVoucher_colText");
            // 
            // tblGLVoucher_colJouNo
            // 
            this.tblGLVoucher_colJouNo.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblGLVoucher_colJouNo.Name = "tblGLVoucher_colJouNo";
            this.tblGLVoucher_colJouNo.NamedProperties.Put("EnumerateMethod", "");
            this.tblGLVoucher_colJouNo.NamedProperties.Put("FieldFlags", "290");
            this.tblGLVoucher_colJouNo.NamedProperties.Put("LovReference", "");
            this.tblGLVoucher_colJouNo.NamedProperties.Put("ResizeableChildObject", "");
            this.tblGLVoucher_colJouNo.NamedProperties.Put("SqlColumn", "JOU_NO");
            this.tblGLVoucher_colJouNo.NamedProperties.Put("ValidateMethod", "");
            this.tblGLVoucher_colJouNo.Position = 15;
            resources.ApplyResources(this.tblGLVoucher_colJouNo, "tblGLVoucher_colJouNo");
            // 
            // tblGLVoucher_colInterimVoucher
            // 
            this.tblGLVoucher_colInterimVoucher.Name = "tblGLVoucher_colInterimVoucher";
            this.tblGLVoucher_colInterimVoucher.NamedProperties.Put("EnumerateMethod", "");
            this.tblGLVoucher_colInterimVoucher.NamedProperties.Put("FieldFlags", "294");
            this.tblGLVoucher_colInterimVoucher.NamedProperties.Put("LovReference", "");
            this.tblGLVoucher_colInterimVoucher.NamedProperties.Put("SqlColumn", "INTERIM_VOUCHER");
            this.tblGLVoucher_colInterimVoucher.NamedProperties.Put("ValidateMethod", "");
            this.tblGLVoucher_colInterimVoucher.Position = 16;
            resources.ApplyResources(this.tblGLVoucher_colInterimVoucher, "tblGLVoucher_colInterimVoucher");
            // 
            // tblGLVoucher_colVoucherTypeReference
            // 
            this.tblGLVoucher_colVoucherTypeReference.Name = "tblGLVoucher_colVoucherTypeReference";
            this.tblGLVoucher_colVoucherTypeReference.NamedProperties.Put("EnumerateMethod", "");
            this.tblGLVoucher_colVoucherTypeReference.NamedProperties.Put("FieldFlags", "294");
            this.tblGLVoucher_colVoucherTypeReference.NamedProperties.Put("LovReference", "");
            this.tblGLVoucher_colVoucherTypeReference.NamedProperties.Put("SqlColumn", "VOUCHER_TYPE_REFERENCE");
            this.tblGLVoucher_colVoucherTypeReference.NamedProperties.Put("ValidateMethod", "");
            this.tblGLVoucher_colVoucherTypeReference.Position = 17;
            resources.ApplyResources(this.tblGLVoucher_colVoucherTypeReference, "tblGLVoucher_colVoucherTypeReference");
            // 
            // tblGLVoucher_colVoucherNoReference
            // 
            this.tblGLVoucher_colVoucherNoReference.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblGLVoucher_colVoucherNoReference.Name = "tblGLVoucher_colVoucherNoReference";
            this.tblGLVoucher_colVoucherNoReference.NamedProperties.Put("EnumerateMethod", "");
            this.tblGLVoucher_colVoucherNoReference.NamedProperties.Put("FieldFlags", "294");
            this.tblGLVoucher_colVoucherNoReference.NamedProperties.Put("LovReference", "");
            this.tblGLVoucher_colVoucherNoReference.NamedProperties.Put("SqlColumn", "VOUCHER_NO_REFERENCE");
            this.tblGLVoucher_colVoucherNoReference.NamedProperties.Put("ValidateMethod", "");
            this.tblGLVoucher_colVoucherNoReference.Position = 18;
            resources.ApplyResources(this.tblGLVoucher_colVoucherNoReference, "tblGLVoucher_colVoucherNoReference");
            // 
            // tblGLVoucher_colnAccountingYearReference
            // 
            this.tblGLVoucher_colnAccountingYearReference.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblGLVoucher_colnAccountingYearReference.Name = "tblGLVoucher_colnAccountingYearReference";
            this.tblGLVoucher_colnAccountingYearReference.NamedProperties.Put("EnumerateMethod", "");
            this.tblGLVoucher_colnAccountingYearReference.NamedProperties.Put("FieldFlags", "294");
            this.tblGLVoucher_colnAccountingYearReference.NamedProperties.Put("LovReference", "");
            this.tblGLVoucher_colnAccountingYearReference.NamedProperties.Put("SqlColumn", "ACCOUNTING_YEAR_REFERENCE");
            this.tblGLVoucher_colnAccountingYearReference.NamedProperties.Put("ValidateMethod", "");
            this.tblGLVoucher_colnAccountingYearReference.Position = 19;
            resources.ApplyResources(this.tblGLVoucher_colnAccountingYearReference, "tblGLVoucher_colnAccountingYearReference");
            // 
            // cPanelCtrlContainer
            // 
            resources.ApplyResources(this.cPanelCtrlContainer, "cPanelCtrlContainer");
            this.cPanelCtrlContainer.Controls.Add(this.cbReverse);
            this.cPanelCtrlContainer.Controls.Add(this.pbCopy);
            this.cPanelCtrlContainer.Controls.Add(this.cbCorrection);
            this.cPanelCtrlContainer.Controls.Add(this.pbCancel);
            this.cPanelCtrlContainer.Controls.Add(this.pbVourow);
            this.cPanelCtrlContainer.Controls.Add(this.pbQuery);
            this.cPanelCtrlContainer.Name = "cPanelCtrlContainer";
            // 
            // dlgGLVoucher
            // 
            resources.ApplyResources(this, "$this");
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Name = "dlgGLVoucher";
            this.ShowIcon = false;
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dlgGLVoucher_WindowActions);
            this.ClientArea.ResumeLayout(false);
            this.tblGLVoucher.ResumeLayout(false);
            this.cPanelCtrlContainer.ResumeLayout(false);
            this.cPanelCtrlContainer.PerformLayout();
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

        public cChildTableFin tblGLVoucher;
        protected cColumn tblGLVoucher_colCompany;
        protected cColumn tblGLVoucher_colVoucherType;
        protected cColumn tblGLVoucher_colVoucherNo;
        protected cColumn tblGLVoucher_colVoucherDate;
        protected cColumn tblGLVoucher_colUserGroup;
        protected cColumn tblGLVoucher_colnAccountingYear;
        protected cColumn tblGLVoucher_colnAccountingPeriod;
        protected cColumn tblGLVoucher_colDateReg;
        protected cColumn tblGLVoucher_colUserid;
        protected cColumn tblGLVoucher_colTransferId;
        protected cColumn tblGLVoucher_colVoucherText;
        protected cColumn tblGLVoucher_colText;
        protected cColumn tblGLVoucher_colJouNo;
        protected cColumn tblGLVoucher_colInterimVoucher;
        protected cColumn tblGLVoucher_colVoucherTypeReference;
        protected cColumn tblGLVoucher_colVoucherNoReference;
        protected cColumn tblGLVoucher_colnAccountingYearReference;
        protected cPanel cPanelCtrlContainer;
		
	}
}
