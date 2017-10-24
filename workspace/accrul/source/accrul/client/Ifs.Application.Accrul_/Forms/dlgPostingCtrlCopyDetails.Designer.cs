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
	
	public partial class dlgPostingCtrlCopyDetails
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cDataField dfCompany;
		protected cBackgroundText labeldfsPostingType;
		public cDataField dfsPostingType;
		protected cBackgroundText labeldfsModule;
		public cDataField dfsModule;
		protected cBackgroundText labeldfdValidFrom;
		public cDataField dfdValidFrom;
		protected cBackgroundText labeldfsPostingTypeDesc;
		public cDataField dfsPostingTypeDesc;
		protected cBackgroundText labeldfsCodeName;
		public cDataField dfsCodeName;
		protected cBackgroundText labeldfsControlType;
		public cDataField dfsControlType;
		protected cBackgroundText labeldfsControlTypeDesc;
		public cDataField dfsControlTypeDesc;
		public cPushButton pbOk;
		public cPushButton pbCancel;
		public SalPushbutton pbQuery;
		public SalPushbutton pbPopulate;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgPostingCtrlCopyDetails));
            this.dfCompany = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsPostingType = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsPostingType = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsModule = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsModule = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfdValidFrom = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfdValidFrom = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsPostingTypeDesc = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsPostingTypeDesc = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsCodeName = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsCodeName = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsControlType = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsControlType = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsControlTypeDesc = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsControlTypeDesc = new Ifs.Fnd.ApplicationForms.cDataField();
            this.pbOk = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbCancel = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbQuery = new PPJ.Runtime.Windows.SalPushbutton();
            this.pbPopulate = new PPJ.Runtime.Windows.SalPushbutton();
            this.tblPostingControlDetail = new Ifs.Application.Accrul.cChildTableFinBase();
            this.tblPostingControlDetail_colsPostingType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPostingControlDetail_colPostingTypeDesc = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPostingControlDetail_colCurrControlType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPostingControlDetail_colSpecExist = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.tblPostingControlDetail_colsControlType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPostingControlDetail_colsCodePart = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblPostingControlDetail_colsIncludeCopy = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.tblPostingControlDetail_coldCopyValidFrom = new Ifs.Fnd.ApplicationForms.cColumn();
            this.ClientArea.SuspendLayout();
            this.tblPostingControlDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolBar
            // 
            resources.ApplyResources(this.ToolBar, "ToolBar");
            // 
            // ClientArea
            // 
            this.ClientArea.Controls.Add(this.pbPopulate);
            this.ClientArea.Controls.Add(this.pbQuery);
            this.ClientArea.Controls.Add(this.pbCancel);
            this.ClientArea.Controls.Add(this.pbOk);
            this.ClientArea.Controls.Add(this.tblPostingControlDetail);
            this.ClientArea.Controls.Add(this.dfsControlTypeDesc);
            this.ClientArea.Controls.Add(this.dfsControlType);
            this.ClientArea.Controls.Add(this.dfsCodeName);
            this.ClientArea.Controls.Add(this.dfsPostingTypeDesc);
            this.ClientArea.Controls.Add(this.dfdValidFrom);
            this.ClientArea.Controls.Add(this.dfsModule);
            this.ClientArea.Controls.Add(this.dfsPostingType);
            this.ClientArea.Controls.Add(this.dfCompany);
            this.ClientArea.Controls.Add(this.labeldfsControlTypeDesc);
            this.ClientArea.Controls.Add(this.labeldfsControlType);
            this.ClientArea.Controls.Add(this.labeldfsCodeName);
            this.ClientArea.Controls.Add(this.labeldfsPostingTypeDesc);
            this.ClientArea.Controls.Add(this.labeldfdValidFrom);
            this.ClientArea.Controls.Add(this.labeldfsModule);
            this.ClientArea.Controls.Add(this.labeldfsPostingType);
            resources.ApplyResources(this.ClientArea, "ClientArea");
            // 
            // StatusBar
            // 
            resources.ApplyResources(this.StatusBar, "StatusBar");
            // 
            // commandManager
            // 
            this.commandManager.Components.Add(this.pbCancel);
            this.commandManager.Components.Add(this.pbOk);
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
            // labeldfsPostingType
            // 
            resources.ApplyResources(this.labeldfsPostingType, "labeldfsPostingType");
            this.labeldfsPostingType.Name = "labeldfsPostingType";
            // 
            // dfsPostingType
            // 
            resources.ApplyResources(this.dfsPostingType, "dfsPostingType");
            this.dfsPostingType.Name = "dfsPostingType";
            this.dfsPostingType.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsPostingType_WindowActions);
            // 
            // labeldfsModule
            // 
            resources.ApplyResources(this.labeldfsModule, "labeldfsModule");
            this.labeldfsModule.Name = "labeldfsModule";
            // 
            // dfsModule
            // 
            resources.ApplyResources(this.dfsModule, "dfsModule");
            this.dfsModule.Name = "dfsModule";
            this.dfsModule.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsModule_WindowActions);
            // 
            // labeldfdValidFrom
            // 
            resources.ApplyResources(this.labeldfdValidFrom, "labeldfdValidFrom");
            this.labeldfdValidFrom.Name = "labeldfdValidFrom";
            // 
            // dfdValidFrom
            // 
            this.dfdValidFrom.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.dfdValidFrom.Format = "d";
            resources.ApplyResources(this.dfdValidFrom, "dfdValidFrom");
            this.dfdValidFrom.Name = "dfdValidFrom";
            this.dfdValidFrom.NamedProperties.Put("EnumerateMethod", "");
            this.dfdValidFrom.NamedProperties.Put("LovReference", "");
            this.dfdValidFrom.NamedProperties.Put("ResizeableChildObject", "");
            this.dfdValidFrom.NamedProperties.Put("SqlColumn", "PC_VALID_FROM");
            this.dfdValidFrom.NamedProperties.Put("ValidateMethod", "");
            this.dfdValidFrom.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfdValidFrom_WindowActions);
            // 
            // labeldfsPostingTypeDesc
            // 
            resources.ApplyResources(this.labeldfsPostingTypeDesc, "labeldfsPostingTypeDesc");
            this.labeldfsPostingTypeDesc.Name = "labeldfsPostingTypeDesc";
            // 
            // dfsPostingTypeDesc
            // 
            resources.ApplyResources(this.dfsPostingTypeDesc, "dfsPostingTypeDesc");
            this.dfsPostingTypeDesc.Name = "dfsPostingTypeDesc";
            this.dfsPostingTypeDesc.NamedProperties.Put("EnumerateMethod", "");
            this.dfsPostingTypeDesc.NamedProperties.Put("LovReference", "");
            this.dfsPostingTypeDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsPostingTypeDesc.NamedProperties.Put("SqlColumn", "");
            this.dfsPostingTypeDesc.NamedProperties.Put("ValidateMethod", "");
            this.dfsPostingTypeDesc.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsPostingTypeDesc_WindowActions);
            // 
            // labeldfsCodeName
            // 
            resources.ApplyResources(this.labeldfsCodeName, "labeldfsCodeName");
            this.labeldfsCodeName.Name = "labeldfsCodeName";
            // 
            // dfsCodeName
            // 
            resources.ApplyResources(this.dfsCodeName, "dfsCodeName");
            this.dfsCodeName.Name = "dfsCodeName";
            this.dfsCodeName.NamedProperties.Put("EnumerateMethod", "");
            this.dfsCodeName.NamedProperties.Put("LovReference", "");
            this.dfsCodeName.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsCodeName.NamedProperties.Put("SqlColumn", "");
            this.dfsCodeName.NamedProperties.Put("ValidateMethod", "");
            this.dfsCodeName.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsCodeName_WindowActions);
            // 
            // labeldfsControlType
            // 
            resources.ApplyResources(this.labeldfsControlType, "labeldfsControlType");
            this.labeldfsControlType.Name = "labeldfsControlType";
            // 
            // dfsControlType
            // 
            resources.ApplyResources(this.dfsControlType, "dfsControlType");
            this.dfsControlType.Name = "dfsControlType";
            this.dfsControlType.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsControlType_WindowActions);
            // 
            // labeldfsControlTypeDesc
            // 
            resources.ApplyResources(this.labeldfsControlTypeDesc, "labeldfsControlTypeDesc");
            this.labeldfsControlTypeDesc.Name = "labeldfsControlTypeDesc";
            // 
            // dfsControlTypeDesc
            // 
            resources.ApplyResources(this.dfsControlTypeDesc, "dfsControlTypeDesc");
            this.dfsControlTypeDesc.Name = "dfsControlTypeDesc";
            this.dfsControlTypeDesc.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsControlTypeDesc_WindowActions);
            // 
            // pbOk
            // 
            this.pbOk.AcceleratorKey = System.Windows.Forms.Keys.Return;
            resources.ApplyResources(this.pbOk, "pbOk");
            this.pbOk.Name = "pbOk";
            this.pbOk.NamedProperties.Put("MethodId", "18385");
            this.pbOk.NamedProperties.Put("MethodParameter", "Ok");
            this.pbOk.NamedProperties.Put("ResizeableChildObject", "");
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
            this.pbQuery.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.pbQuery_WindowActions);
            // 
            // pbPopulate
            // 
            this.pbPopulate.AcceleratorKey = System.Windows.Forms.Keys.F2;
            resources.ApplyResources(this.pbPopulate, "pbPopulate");
            this.pbPopulate.Name = "pbPopulate";
            this.pbPopulate.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.pbPopulate_WindowActions);
            // 
            // tblPostingControlDetail
            // 
            this.tblPostingControlDetail.Controls.Add(this.tblPostingControlDetail_colsPostingType);
            this.tblPostingControlDetail.Controls.Add(this.tblPostingControlDetail_colPostingTypeDesc);
            this.tblPostingControlDetail.Controls.Add(this.tblPostingControlDetail_colCurrControlType);
            this.tblPostingControlDetail.Controls.Add(this.tblPostingControlDetail_colSpecExist);
            this.tblPostingControlDetail.Controls.Add(this.tblPostingControlDetail_colsControlType);
            this.tblPostingControlDetail.Controls.Add(this.tblPostingControlDetail_colsCodePart);
            this.tblPostingControlDetail.Controls.Add(this.tblPostingControlDetail_colsIncludeCopy);
            this.tblPostingControlDetail.Controls.Add(this.tblPostingControlDetail_coldCopyValidFrom);
            resources.ApplyResources(this.tblPostingControlDetail, "tblPostingControlDetail");
            this.tblPostingControlDetail.Name = "tblPostingControlDetail";
            this.tblPostingControlDetail.NamedProperties.Put("DefaultOrderBy", "post_module, sort_order, code_part");
            this.tblPostingControlDetail.NamedProperties.Put("DefaultWhere", "CONTROL_TYPE = :i_hWndFrame.dlgPostingCtrlCopyDetails.sControlType\r\nAND CODE_PART" +
                    " IN (:i_hWndFrame.dlgPostingCtrlCopyDetails.sCodePart, \'*\')\r\nAND POSTING_TYPE !=" +
                    " :i_hWndFrame.dlgPostingCtrlCopyDetails.sPostingType");
            this.tblPostingControlDetail.NamedProperties.Put("LogicalUnit", "");
            this.tblPostingControlDetail.NamedProperties.Put("PackageName", "");
            this.tblPostingControlDetail.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPostingControlDetail.NamedProperties.Put("SourceFlags", "129");
            this.tblPostingControlDetail.NamedProperties.Put("ViewName", "POSTING_CTRL_ALWD_COMBINATION");
            this.tblPostingControlDetail.NamedProperties.Put("Warnings", "FALSE");
            this.tblPostingControlDetail.Controls.SetChildIndex(this.tblPostingControlDetail_coldCopyValidFrom, 0);
            this.tblPostingControlDetail.Controls.SetChildIndex(this.tblPostingControlDetail_colsIncludeCopy, 0);
            this.tblPostingControlDetail.Controls.SetChildIndex(this.tblPostingControlDetail_colsCodePart, 0);
            this.tblPostingControlDetail.Controls.SetChildIndex(this.tblPostingControlDetail_colsControlType, 0);
            this.tblPostingControlDetail.Controls.SetChildIndex(this.tblPostingControlDetail_colSpecExist, 0);
            this.tblPostingControlDetail.Controls.SetChildIndex(this.tblPostingControlDetail_colCurrControlType, 0);
            this.tblPostingControlDetail.Controls.SetChildIndex(this.tblPostingControlDetail_colPostingTypeDesc, 0);
            this.tblPostingControlDetail.Controls.SetChildIndex(this.tblPostingControlDetail_colsPostingType, 0);
            // 
            // tblPostingControlDetail_colsPostingType
            // 
            this.tblPostingControlDetail_colsPostingType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblPostingControlDetail_colsPostingType.MaxLength = 10;
            this.tblPostingControlDetail_colsPostingType.Name = "tblPostingControlDetail_colsPostingType";
            this.tblPostingControlDetail_colsPostingType.NamedProperties.Put("EnumerateMethod", "");
            this.tblPostingControlDetail_colsPostingType.NamedProperties.Put("FieldFlags", "99");
            this.tblPostingControlDetail_colsPostingType.NamedProperties.Put("LovReference", "POSTING_CTRL_POSTING_TYPE");
            this.tblPostingControlDetail_colsPostingType.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPostingControlDetail_colsPostingType.NamedProperties.Put("SqlColumn", "POSTING_TYPE");
            this.tblPostingControlDetail_colsPostingType.NamedProperties.Put("ValidateMethod", "");
            this.tblPostingControlDetail_colsPostingType.Position = 3;
            resources.ApplyResources(this.tblPostingControlDetail_colsPostingType, "tblPostingControlDetail_colsPostingType");
            this.tblPostingControlDetail_colsPostingType.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsPostingType_WindowActions);
            // 
            // tblPostingControlDetail_colPostingTypeDesc
            // 
            this.tblPostingControlDetail_colPostingTypeDesc.MaxLength = 2000;
            this.tblPostingControlDetail_colPostingTypeDesc.Name = "tblPostingControlDetail_colPostingTypeDesc";
            this.tblPostingControlDetail_colPostingTypeDesc.NamedProperties.Put("EnumerateMethod", "");
            this.tblPostingControlDetail_colPostingTypeDesc.NamedProperties.Put("FieldFlags", "304");
            this.tblPostingControlDetail_colPostingTypeDesc.NamedProperties.Put("LovReference", "");
            this.tblPostingControlDetail_colPostingTypeDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPostingControlDetail_colPostingTypeDesc.NamedProperties.Put("SqlColumn", "POSTING_CTRL_POSTING_TYPE_API.Get_Description(POSTING_TYPE)");
            this.tblPostingControlDetail_colPostingTypeDesc.NamedProperties.Put("ValidateMethod", "");
            this.tblPostingControlDetail_colPostingTypeDesc.Position = 4;
            resources.ApplyResources(this.tblPostingControlDetail_colPostingTypeDesc, "tblPostingControlDetail_colPostingTypeDesc");
            // 
            // tblPostingControlDetail_colCurrControlType
            // 
            this.tblPostingControlDetail_colCurrControlType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblPostingControlDetail_colCurrControlType.MaxLength = 2000;
            this.tblPostingControlDetail_colCurrControlType.Name = "tblPostingControlDetail_colCurrControlType";
            this.tblPostingControlDetail_colCurrControlType.NamedProperties.Put("EnumerateMethod", "");
            this.tblPostingControlDetail_colCurrControlType.NamedProperties.Put("FieldFlags", "288");
            this.tblPostingControlDetail_colCurrControlType.NamedProperties.Put("LovReference", "");
            this.tblPostingControlDetail_colCurrControlType.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPostingControlDetail_colCurrControlType.NamedProperties.Put("SqlColumn", "POSTING_CTRL_API.Get_Current_Control_Type(:i_hWndFrame.dlgPostingCtrlCopyDetails." +
                    "sCompany, POSTING_TYPE, :i_hWndFrame.dlgPostingCtrlCopyDetails.sCodePart)");
            this.tblPostingControlDetail_colCurrControlType.NamedProperties.Put("ValidateMethod", "");
            this.tblPostingControlDetail_colCurrControlType.Position = 5;
            resources.ApplyResources(this.tblPostingControlDetail_colCurrControlType, "tblPostingControlDetail_colCurrControlType");
            // 
            // tblPostingControlDetail_colSpecExist
            // 
            this.tblPostingControlDetail_colSpecExist.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblPostingControlDetail_colSpecExist, "tblPostingControlDetail_colSpecExist");
            this.tblPostingControlDetail_colSpecExist.MaxLength = 5;
            this.tblPostingControlDetail_colSpecExist.Name = "tblPostingControlDetail_colSpecExist";
            this.tblPostingControlDetail_colSpecExist.NamedProperties.Put("EnumerateMethod", "");
            this.tblPostingControlDetail_colSpecExist.NamedProperties.Put("FieldFlags", "304");
            this.tblPostingControlDetail_colSpecExist.NamedProperties.Put("LovReference", "");
            this.tblPostingControlDetail_colSpecExist.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPostingControlDetail_colSpecExist.NamedProperties.Put("SqlColumn", "POSTING_CTRL_API.Is_Detail_Spec(:i_hWndFrame.dlgPostingCtrlCopyDetails.sCompany, " +
                    "POSTING_TYPE, :i_hWndFrame.dlgPostingCtrlCopyDetails.sCodePart)");
            this.tblPostingControlDetail_colSpecExist.NamedProperties.Put("ValidateMethod", "");
            this.tblPostingControlDetail_colSpecExist.Position = 6;
            // 
            // tblPostingControlDetail_colsControlType
            // 
            this.tblPostingControlDetail_colsControlType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblPostingControlDetail_colsControlType, "tblPostingControlDetail_colsControlType");
            this.tblPostingControlDetail_colsControlType.MaxLength = 10;
            this.tblPostingControlDetail_colsControlType.Name = "tblPostingControlDetail_colsControlType";
            this.tblPostingControlDetail_colsControlType.NamedProperties.Put("EnumerateMethod", "");
            this.tblPostingControlDetail_colsControlType.NamedProperties.Put("FieldFlags", "67");
            this.tblPostingControlDetail_colsControlType.NamedProperties.Put("LovReference", "");
            this.tblPostingControlDetail_colsControlType.NamedProperties.Put("SqlColumn", "CONTROL_TYPE");
            this.tblPostingControlDetail_colsControlType.Position = 7;
            // 
            // tblPostingControlDetail_colsCodePart
            // 
            resources.ApplyResources(this.tblPostingControlDetail_colsCodePart, "tblPostingControlDetail_colsCodePart");
            this.tblPostingControlDetail_colsCodePart.MaxLength = 1;
            this.tblPostingControlDetail_colsCodePart.Name = "tblPostingControlDetail_colsCodePart";
            this.tblPostingControlDetail_colsCodePart.NamedProperties.Put("EnumerateMethod", "POSTING_CTRL_ALL_CODEPART_API.Enumerate");
            this.tblPostingControlDetail_colsCodePart.NamedProperties.Put("FieldFlags", "131");
            this.tblPostingControlDetail_colsCodePart.NamedProperties.Put("LovReference", "");
            this.tblPostingControlDetail_colsCodePart.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPostingControlDetail_colsCodePart.NamedProperties.Put("SqlColumn", "CODE_PART");
            this.tblPostingControlDetail_colsCodePart.NamedProperties.Put("ValidateMethod", "");
            this.tblPostingControlDetail_colsCodePart.Position = 8;
            // 
            // tblPostingControlDetail_colsIncludeCopy
            // 
            this.tblPostingControlDetail_colsIncludeCopy.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblPostingControlDetail_colsIncludeCopy.MaxLength = 5;
            this.tblPostingControlDetail_colsIncludeCopy.Name = "tblPostingControlDetail_colsIncludeCopy";
            this.tblPostingControlDetail_colsIncludeCopy.NamedProperties.Put("EnumerateMethod", "");
            this.tblPostingControlDetail_colsIncludeCopy.NamedProperties.Put("FieldFlags", "67");
            this.tblPostingControlDetail_colsIncludeCopy.NamedProperties.Put("LovReference", "");
            this.tblPostingControlDetail_colsIncludeCopy.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPostingControlDetail_colsIncludeCopy.NamedProperties.Put("SqlColumn", "\'FALSE\'");
            this.tblPostingControlDetail_colsIncludeCopy.NamedProperties.Put("ValidateMethod", "");
            this.tblPostingControlDetail_colsIncludeCopy.Position = 9;
            resources.ApplyResources(this.tblPostingControlDetail_colsIncludeCopy, "tblPostingControlDetail_colsIncludeCopy");
            this.tblPostingControlDetail_colsIncludeCopy.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsIncludeCopy_WindowActions);
            // 
            // tblPostingControlDetail_coldCopyValidFrom
            // 
            this.tblPostingControlDetail_coldCopyValidFrom.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.tblPostingControlDetail_coldCopyValidFrom.Format = "d";
            this.tblPostingControlDetail_coldCopyValidFrom.Name = "tblPostingControlDetail_coldCopyValidFrom";
            this.tblPostingControlDetail_coldCopyValidFrom.NamedProperties.Put("EnumerateMethod", "");
            this.tblPostingControlDetail_coldCopyValidFrom.NamedProperties.Put("FieldFlags", "262");
            this.tblPostingControlDetail_coldCopyValidFrom.NamedProperties.Put("LovReference", "");
            this.tblPostingControlDetail_coldCopyValidFrom.NamedProperties.Put("ResizeableChildObject", "");
            this.tblPostingControlDetail_coldCopyValidFrom.NamedProperties.Put("SqlColumn", "");
            this.tblPostingControlDetail_coldCopyValidFrom.NamedProperties.Put("ValidateMethod", "");
            this.tblPostingControlDetail_coldCopyValidFrom.Position = 10;
            resources.ApplyResources(this.tblPostingControlDetail_coldCopyValidFrom, "tblPostingControlDetail_coldCopyValidFrom");
            this.tblPostingControlDetail_coldCopyValidFrom.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.coldCopyValidFrom_WindowActions);
            // 
            // dlgPostingCtrlCopyDetails
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "dlgPostingCtrlCopyDetails";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "company= :global.company");
            this.NamedProperties.Put("LogicalUnit", "PostingCtrl");
            this.NamedProperties.Put("PackageName", "POSTING_CTRL_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizableChildObject", "");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("ViewName", "POSTING_CTRL_MASTER");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.ShowIcon = false;
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dlgPostingCtrlCopyDetails_WindowActions);
            this.ClientArea.ResumeLayout(false);
            this.ClientArea.PerformLayout();
            this.tblPostingControlDetail.ResumeLayout(false);
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

        public cChildTableFinBase tblPostingControlDetail;
        protected cColumn tblPostingControlDetail_colsPostingType;
        protected cColumn tblPostingControlDetail_colPostingTypeDesc;
        protected cColumn tblPostingControlDetail_colCurrControlType;
        protected cColumn tblPostingControlDetail_colsControlType;
        protected cColumn tblPostingControlDetail_colsCodePart;
        protected cColumn tblPostingControlDetail_coldCopyValidFrom;
        protected cCheckBoxColumn tblPostingControlDetail_colSpecExist;
        protected cCheckBoxColumn tblPostingControlDetail_colsIncludeCopy;
		
		
	}
}
