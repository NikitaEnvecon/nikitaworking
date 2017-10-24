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
	
	public partial class dlgCreateYear
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		protected SalGroupBox gbUser_Group_Information;
		protected cBackgroundText labelcmbUserGroup;
		public cRecSelComboBox cmbUserGroup;
		protected cBackgroundText labeldfDescription;
		public cDataFieldFin dfDescription;
		protected cBackgroundText labeldfCompany;
		public cDataFieldFin dfCompany;
		protected cBackgroundText labelcmbAuthorizeLevel;
		public cComboBox cmbAuthorizeLevel;
		protected cBackgroundText labelcmbDefaultType;
		public cComboBox cmbDefaultType;
		protected cBackgroundText labelcmbFunctionGroup;
		public cComboBox cmbFunctionGroup;
		public cDataFieldFin dfVoucherType;
		public cRadioButton rbSingle;
		public cRadioButton rbAll;
		public cPushButton pbOk;
		public cPushButton pbCancel;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgCreateYear));
            this.gbUser_Group_Information = new PPJ.Runtime.Windows.SalGroupBox();
            this.labelcmbUserGroup = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbUserGroup = new Ifs.Fnd.ApplicationForms.cRecSelComboBox();
            this.labeldfDescription = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfDescription = new Ifs.Application.Accrul.cDataFieldFin();
            this.labeldfCompany = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfCompany = new Ifs.Application.Accrul.cDataFieldFin();
            this.labelcmbAuthorizeLevel = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbAuthorizeLevel = new Ifs.Fnd.ApplicationForms.cComboBox();
            this.labelcmbDefaultType = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbDefaultType = new Ifs.Fnd.ApplicationForms.cComboBox();
            this.labelcmbFunctionGroup = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbFunctionGroup = new Ifs.Fnd.ApplicationForms.cComboBox();
            this.dfVoucherType = new Ifs.Application.Accrul.cDataFieldFin();
            this.rbSingle = new Ifs.Fnd.ApplicationForms.cRadioButton();
            this.rbAll = new Ifs.Fnd.ApplicationForms.cRadioButton();
            this.pbOk = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbCancel = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.ClientArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // ClientArea
            // 
            this.ClientArea.Controls.Add(this.labelcmbUserGroup);
            this.ClientArea.Controls.Add(this.labeldfDescription);
            this.ClientArea.Controls.Add(this.pbCancel);
            this.ClientArea.Controls.Add(this.pbOk);
            this.ClientArea.Controls.Add(this.rbAll);
            this.ClientArea.Controls.Add(this.rbSingle);
            this.ClientArea.Controls.Add(this.dfVoucherType);
            this.ClientArea.Controls.Add(this.cmbFunctionGroup);
            this.ClientArea.Controls.Add(this.cmbDefaultType);
            this.ClientArea.Controls.Add(this.cmbAuthorizeLevel);
            this.ClientArea.Controls.Add(this.dfCompany);
            this.ClientArea.Controls.Add(this.dfDescription);
            this.ClientArea.Controls.Add(this.cmbUserGroup);
            this.ClientArea.Controls.Add(this.labelcmbFunctionGroup);
            this.ClientArea.Controls.Add(this.labelcmbDefaultType);
            this.ClientArea.Controls.Add(this.labelcmbAuthorizeLevel);
            this.ClientArea.Controls.Add(this.labeldfCompany);
            this.ClientArea.Controls.Add(this.gbUser_Group_Information);
            resources.ApplyResources(this.ClientArea, "ClientArea");
            // 
            // commandManager
            // 
            this.commandManager.Components.Add(this.pbCancel);
            this.commandManager.Components.Add(this.pbOk);
            // 
            // gbUser_Group_Information
            // 
            resources.ApplyResources(this.gbUser_Group_Information, "gbUser_Group_Information");
            this.gbUser_Group_Information.Name = "gbUser_Group_Information";
            this.gbUser_Group_Information.TabStop = false;
            // 
            // labelcmbUserGroup
            // 
            resources.ApplyResources(this.labelcmbUserGroup, "labelcmbUserGroup");
            this.labelcmbUserGroup.Name = "labelcmbUserGroup";
            // 
            // cmbUserGroup
            // 
            resources.ApplyResources(this.cmbUserGroup, "cmbUserGroup");
            this.cmbUserGroup.Name = "cmbUserGroup";
            this.cmbUserGroup.NamedProperties.Put("EnumerateMethod", "");
            this.cmbUserGroup.NamedProperties.Put("FieldFlags", "295");
            this.cmbUserGroup.NamedProperties.Put("LovReference", "");
            this.cmbUserGroup.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbUserGroup.NamedProperties.Put("SqlColumn", "USER_GROUP");
            this.cmbUserGroup.NamedProperties.Put("ValidateMethod", "");
            this.cmbUserGroup.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbUserGroup_WindowActions);
            // 
            // labeldfDescription
            // 
            resources.ApplyResources(this.labeldfDescription, "labeldfDescription");
            this.labeldfDescription.Name = "labeldfDescription";
            // 
            // dfDescription
            // 
            resources.ApplyResources(this.dfDescription, "dfDescription");
            this.dfDescription.Name = "dfDescription";
            this.dfDescription.NamedProperties.Put("EnumerateMethod", "");
            this.dfDescription.NamedProperties.Put("FieldFlags", "288");
            this.dfDescription.NamedProperties.Put("LovReference", "");
            this.dfDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.dfDescription.NamedProperties.Put("SqlColumn", "");
            this.dfDescription.NamedProperties.Put("ValidateMethod", "");
            this.dfDescription.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfDescription_WindowActions);
            // 
            // labeldfCompany
            // 
            resources.ApplyResources(this.labeldfCompany, "labeldfCompany");
            this.labeldfCompany.Name = "labeldfCompany";
            // 
            // dfCompany
            // 
            resources.ApplyResources(this.dfCompany, "dfCompany");
            this.dfCompany.Name = "dfCompany";
            this.dfCompany.TabStop = false;
            // 
            // labelcmbAuthorizeLevel
            // 
            resources.ApplyResources(this.labelcmbAuthorizeLevel, "labelcmbAuthorizeLevel");
            this.labelcmbAuthorizeLevel.Name = "labelcmbAuthorizeLevel";
            // 
            // cmbAuthorizeLevel
            // 
            this.cmbAuthorizeLevel.DropDownHeight = 191;
            this.cmbAuthorizeLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cmbAuthorizeLevel, "cmbAuthorizeLevel");
            this.cmbAuthorizeLevel.Name = "cmbAuthorizeLevel";
            this.cmbAuthorizeLevel.NamedProperties.Put("EnumerateMethod", "AUTHORIZE_LEVEL_API.Enumerate");
            this.cmbAuthorizeLevel.NamedProperties.Put("FieldFlags", "294");
            this.cmbAuthorizeLevel.NamedProperties.Put("LovReference", "");
            this.cmbAuthorizeLevel.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbAuthorizeLevel.NamedProperties.Put("SqlColumn", "AUTHORIZE_LEVEL");
            this.cmbAuthorizeLevel.NamedProperties.Put("ValidateMethod", "");
            // 
            // labelcmbDefaultType
            // 
            resources.ApplyResources(this.labelcmbDefaultType, "labelcmbDefaultType");
            this.labelcmbDefaultType.Name = "labelcmbDefaultType";
            // 
            // cmbDefaultType
            // 
            this.cmbDefaultType.DropDownHeight = 334;
            this.cmbDefaultType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cmbDefaultType, "cmbDefaultType");
            this.cmbDefaultType.Name = "cmbDefaultType";
            this.cmbDefaultType.NamedProperties.Put("EnumerateMethod", "DEFAULT_TYPE_API.Enumerate");
            this.cmbDefaultType.NamedProperties.Put("FieldFlags", "294");
            this.cmbDefaultType.NamedProperties.Put("Format", "9");
            this.cmbDefaultType.NamedProperties.Put("LovReference", "");
            this.cmbDefaultType.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbDefaultType.NamedProperties.Put("SqlColumn", "DEFAULT_TYPE");
            this.cmbDefaultType.NamedProperties.Put("ValidateMethod", "");
            // 
            // labelcmbFunctionGroup
            // 
            resources.ApplyResources(this.labelcmbFunctionGroup, "labelcmbFunctionGroup");
            this.labelcmbFunctionGroup.Name = "labelcmbFunctionGroup";
            // 
            // cmbFunctionGroup
            // 
            this.cmbFunctionGroup.DropDownHeight = 165;
            this.cmbFunctionGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cmbFunctionGroup, "cmbFunctionGroup");
            this.cmbFunctionGroup.Name = "cmbFunctionGroup";
            this.cmbFunctionGroup.NamedProperties.Put("EnumerateMethod", "");
            this.cmbFunctionGroup.NamedProperties.Put("FieldFlags", "294");
            this.cmbFunctionGroup.NamedProperties.Put("Format", "9");
            this.cmbFunctionGroup.NamedProperties.Put("LovReference", "VOUCHER_TYPE_DETAIL_LOV(COMPANY, VOUCHER_TYPE)");
            this.cmbFunctionGroup.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbFunctionGroup.NamedProperties.Put("SqlColumn", "FUNCTION_GROUP");
            this.cmbFunctionGroup.NamedProperties.Put("ValidateMethod", "");
            // 
            // dfVoucherType
            // 
            resources.ApplyResources(this.dfVoucherType, "dfVoucherType");
            this.dfVoucherType.Name = "dfVoucherType";
            this.dfVoucherType.NamedProperties.Put("EnumerateMethod", "");
            this.dfVoucherType.NamedProperties.Put("FieldFlags", "128");
            this.dfVoucherType.NamedProperties.Put("LovReference", "");
            this.dfVoucherType.NamedProperties.Put("ResizeableChildObject", "");
            this.dfVoucherType.NamedProperties.Put("SqlColumn", "VOUCHER_TYPE");
            this.dfVoucherType.NamedProperties.Put("ValidateMethod", "");
            this.dfVoucherType.TabStop = false;
            // 
            // rbSingle
            // 
            resources.ApplyResources(this.rbSingle, "rbSingle");
            this.rbSingle.Name = "rbSingle";
            this.rbSingle.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.rbSingle_WindowActions);
            // 
            // rbAll
            // 
            resources.ApplyResources(this.rbAll, "rbAll");
            this.rbAll.Name = "rbAll";
            this.rbAll.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.rbAll_WindowActions);
            // 
            // pbOk
            // 
            resources.ApplyResources(this.pbOk, "pbOk");
            this.pbOk.Name = "pbOk";
            this.pbOk.NamedProperties.Put("MethodId", "18385");
            this.pbOk.NamedProperties.Put("MethodParameter", "OK");
            this.pbOk.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // pbCancel
            // 
            resources.ApplyResources(this.pbCancel, "pbCancel");
            this.pbCancel.Name = "pbCancel";
            this.pbCancel.NamedProperties.Put("MethodId", "18385");
            this.pbCancel.NamedProperties.Put("MethodParameter", "Cancel");
            this.pbCancel.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // dlgCreateYear
            // 
            resources.ApplyResources(this, "$this");
            this.DataBound = false;
            this.Name = "dlgCreateYear";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "VoucherTypeUserGroup");
            this.NamedProperties.Put("PackageName", "VOUCHER_TYPE_USER_GROUP_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "1");
            this.NamedProperties.Put("ViewName", "");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.ShowIcon = false;
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dlgCreateYear_WindowActions);
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
