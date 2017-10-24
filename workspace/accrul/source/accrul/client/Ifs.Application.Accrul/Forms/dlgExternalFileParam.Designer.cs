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
	
	public partial class dlgExternalFileParam
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls

        public cPushButton pbOk;
		public cPushButton pbCancel;
		public cPushButton pbBrowse;
		public cPushButton pbList;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgExternalFileParam));
            this.pbOk = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbCancel = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbBrowse = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbList = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.tblExternalFileParam = new Ifs.Application.Accrul.cChildTableFin();
            this.tblExternalFileParam_colsFileType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExternalFileParam_colsParamId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExternalFileParam_colsDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExternalFileParam_colsValue = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.tblExternalFileParam_colsBrowsableField = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExternalFileParam_colsHelpText = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExternalFileParam_colnParamNo = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExternalFileParam_colsLovView = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExternalFileParam_colsEnumerateMethod = new Ifs.Fnd.ApplicationForms.cColumn();
            this.ClientArea.SuspendLayout();
            this.tblExternalFileParam.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolBar
            // 
            resources.ApplyResources(this.ToolBar, "ToolBar");
            // 
            // ClientArea
            // 
            this.ClientArea.Controls.Add(this.pbList);
            this.ClientArea.Controls.Add(this.pbBrowse);
            this.ClientArea.Controls.Add(this.pbCancel);
            this.ClientArea.Controls.Add(this.pbOk);
            this.ClientArea.Controls.Add(this.tblExternalFileParam);
            resources.ApplyResources(this.ClientArea, "ClientArea");
            // 
            // StatusBar
            // 
            resources.ApplyResources(this.StatusBar, "StatusBar");
            // 
            // commandManager
            // 
            this.commandManager.Components.Add(this.pbList);
            this.commandManager.Components.Add(this.pbBrowse);
            this.commandManager.Components.Add(this.pbCancel);
            this.commandManager.Components.Add(this.pbOk);
            // 
            // pbOk
            // 
            resources.ApplyResources(this.pbOk, "pbOk");
            this.pbOk.Name = "pbOk";
            this.pbOk.NamedProperties.Put("MethodId", "18385");
            this.pbOk.NamedProperties.Put("MethodParameter", "OKButton");
            this.pbOk.NamedProperties.Put("ResizeableChildObject", "");
            this.pbOk.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.pbOk_WindowActions);
            // 
            // pbCancel
            // 
            resources.ApplyResources(this.pbCancel, "pbCancel");
            this.pbCancel.Name = "pbCancel";
            this.pbCancel.NamedProperties.Put("MethodId", "18385");
            this.pbCancel.NamedProperties.Put("MethodParameter", "CancelButton");
            this.pbCancel.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // pbBrowse
            // 
            this.pbBrowse.AcceleratorKey = System.Windows.Forms.Keys.F1;
            resources.ApplyResources(this.pbBrowse, "pbBrowse");
            this.pbBrowse.Name = "pbBrowse";
            this.pbBrowse.NamedProperties.Put("MethodId", "18385");
            this.pbBrowse.NamedProperties.Put("MethodParameter", "BrowseButton");
            this.pbBrowse.NamedProperties.Put("ResizeableChildObject", "");
            this.pbBrowse.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.pbBrowse_WindowActions);
            // 
            // pbList
            // 
            this.pbList.AcceleratorKey = System.Windows.Forms.Keys.F8;
            resources.ApplyResources(this.pbList, "pbList");
            this.pbList.Name = "pbList";
            this.pbList.NamedProperties.Put("MethodId", "18385");
            this.pbList.NamedProperties.Put("MethodParameter", "ListButton");
            this.pbList.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // tblExternalFileParam
            // 
            this.tblExternalFileParam.Controls.Add(this.tblExternalFileParam_colsFileType);
            this.tblExternalFileParam.Controls.Add(this.tblExternalFileParam_colsParamId);
            this.tblExternalFileParam.Controls.Add(this.tblExternalFileParam_colsDescription);
            this.tblExternalFileParam.Controls.Add(this.tblExternalFileParam_colsValue);
            this.tblExternalFileParam.Controls.Add(this.tblExternalFileParam_colsBrowsableField);
            this.tblExternalFileParam.Controls.Add(this.tblExternalFileParam_colsHelpText);
            this.tblExternalFileParam.Controls.Add(this.tblExternalFileParam_colnParamNo);
            this.tblExternalFileParam.Controls.Add(this.tblExternalFileParam_colsLovView);
            this.tblExternalFileParam.Controls.Add(this.tblExternalFileParam_colsEnumerateMethod);
            resources.ApplyResources(this.tblExternalFileParam, "tblExternalFileParam");
            this.tblExternalFileParam.Name = "tblExternalFileParam";
            this.tblExternalFileParam.NamedProperties.Put("DefaultOrderBy", "PARAM_NO");
            this.tblExternalFileParam.NamedProperties.Put("DefaultWhere", "");
            this.tblExternalFileParam.NamedProperties.Put("LogicalUnit", "ExtFileTypeParam");
            this.tblExternalFileParam.NamedProperties.Put("PackageName", "EXT_FILE_TYPE_PARAM_API");
            this.tblExternalFileParam.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExternalFileParam.NamedProperties.Put("SourceFlags", "129");
            this.tblExternalFileParam.NamedProperties.Put("ViewName", "EXT_FILE_TYPE_PARAM_DIALOG");
            this.tblExternalFileParam.NamedProperties.Put("Warnings", "FALSE");
            this.tblExternalFileParam.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblExternalFileParam_WindowActions);
            this.tblExternalFileParam.Controls.SetChildIndex(this.tblExternalFileParam_colsEnumerateMethod, 0);
            this.tblExternalFileParam.Controls.SetChildIndex(this.tblExternalFileParam_colsLovView, 0);
            this.tblExternalFileParam.Controls.SetChildIndex(this.tblExternalFileParam_colnParamNo, 0);
            this.tblExternalFileParam.Controls.SetChildIndex(this.tblExternalFileParam_colsHelpText, 0);
            this.tblExternalFileParam.Controls.SetChildIndex(this.tblExternalFileParam_colsBrowsableField, 0);
            this.tblExternalFileParam.Controls.SetChildIndex(this.tblExternalFileParam_colsValue, 0);
            this.tblExternalFileParam.Controls.SetChildIndex(this.tblExternalFileParam_colsDescription, 0);
            this.tblExternalFileParam.Controls.SetChildIndex(this.tblExternalFileParam_colsParamId, 0);
            this.tblExternalFileParam.Controls.SetChildIndex(this.tblExternalFileParam_colsFileType, 0);
            // 
            // tblExternalFileParam_colsFileType
            // 
            resources.ApplyResources(this.tblExternalFileParam_colsFileType, "tblExternalFileParam_colsFileType");
            this.tblExternalFileParam_colsFileType.MaxLength = 30;
            this.tblExternalFileParam_colsFileType.Name = "tblExternalFileParam_colsFileType";
            this.tblExternalFileParam_colsFileType.NamedProperties.Put("EnumerateMethod", "");
            this.tblExternalFileParam_colsFileType.NamedProperties.Put("FieldFlags", "97");
            this.tblExternalFileParam_colsFileType.NamedProperties.Put("LovReference", "EXT_FILE_MODULE_NAME");
            this.tblExternalFileParam_colsFileType.NamedProperties.Put("SqlColumn", "FILE_TYPE");
            this.tblExternalFileParam_colsFileType.NamedProperties.Put("ValidateMethod", "");
            this.tblExternalFileParam_colsFileType.Position = 3;
            // 
            // tblExternalFileParam_colsParamId
            // 
            resources.ApplyResources(this.tblExternalFileParam_colsParamId, "tblExternalFileParam_colsParamId");
            this.tblExternalFileParam_colsParamId.MaxLength = 30;
            this.tblExternalFileParam_colsParamId.Name = "tblExternalFileParam_colsParamId";
            this.tblExternalFileParam_colsParamId.NamedProperties.Put("EnumerateMethod", "");
            this.tblExternalFileParam_colsParamId.NamedProperties.Put("FieldFlags", "289");
            this.tblExternalFileParam_colsParamId.NamedProperties.Put("LovReference", "");
            this.tblExternalFileParam_colsParamId.NamedProperties.Put("SqlColumn", "PARAM_ID");
            this.tblExternalFileParam_colsParamId.NamedProperties.Put("ValidateMethod", "");
            this.tblExternalFileParam_colsParamId.Position = 4;
            // 
            // tblExternalFileParam_colsDescription
            // 
            this.tblExternalFileParam_colsDescription.MaxLength = 200;
            this.tblExternalFileParam_colsDescription.Name = "tblExternalFileParam_colsDescription";
            this.tblExternalFileParam_colsDescription.NamedProperties.Put("EnumerateMethod", "");
            this.tblExternalFileParam_colsDescription.NamedProperties.Put("FieldFlags", "289");
            this.tblExternalFileParam_colsDescription.NamedProperties.Put("LovReference", "");
            this.tblExternalFileParam_colsDescription.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            this.tblExternalFileParam_colsDescription.NamedProperties.Put("ValidateMethod", "");
            this.tblExternalFileParam_colsDescription.Position = 5;
            resources.ApplyResources(this.tblExternalFileParam_colsDescription, "tblExternalFileParam_colsDescription");
            // 
            // tblExternalFileParam_colsValue
            // 
            this.tblExternalFileParam_colsValue.Name = "tblExternalFileParam_colsValue";
            this.tblExternalFileParam_colsValue.NamedProperties.Put("EnumerateMethod", "");
            this.tblExternalFileParam_colsValue.NamedProperties.Put("FieldFlags", "262");
            this.tblExternalFileParam_colsValue.NamedProperties.Put("LovReference", "");
            this.tblExternalFileParam_colsValue.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExternalFileParam_colsValue.NamedProperties.Put("SqlColumn", "");
            this.tblExternalFileParam_colsValue.NamedProperties.Put("ValidateMethod", "");
            this.tblExternalFileParam_colsValue.Position = 6;
            resources.ApplyResources(this.tblExternalFileParam_colsValue, "tblExternalFileParam_colsValue");
            this.tblExternalFileParam_colsValue.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblExternalFileParam_colsValue_WindowActions);
            // 
            // tblExternalFileParam_colsBrowsableField
            // 
            resources.ApplyResources(this.tblExternalFileParam_colsBrowsableField, "tblExternalFileParam_colsBrowsableField");
            this.tblExternalFileParam_colsBrowsableField.MaxLength = 5;
            this.tblExternalFileParam_colsBrowsableField.Name = "tblExternalFileParam_colsBrowsableField";
            this.tblExternalFileParam_colsBrowsableField.NamedProperties.Put("EnumerateMethod", "");
            this.tblExternalFileParam_colsBrowsableField.NamedProperties.Put("FieldFlags", "288");
            this.tblExternalFileParam_colsBrowsableField.NamedProperties.Put("LovReference", "");
            this.tblExternalFileParam_colsBrowsableField.NamedProperties.Put("SqlColumn", "BROWSABLE_FIELD");
            this.tblExternalFileParam_colsBrowsableField.NamedProperties.Put("ValidateMethod", "");
            this.tblExternalFileParam_colsBrowsableField.Position = 7;
            // 
            // tblExternalFileParam_colsHelpText
            // 
            resources.ApplyResources(this.tblExternalFileParam_colsHelpText, "tblExternalFileParam_colsHelpText");
            this.tblExternalFileParam_colsHelpText.MaxLength = 200;
            this.tblExternalFileParam_colsHelpText.Name = "tblExternalFileParam_colsHelpText";
            this.tblExternalFileParam_colsHelpText.NamedProperties.Put("EnumerateMethod", "");
            this.tblExternalFileParam_colsHelpText.NamedProperties.Put("FieldFlags", "288");
            this.tblExternalFileParam_colsHelpText.NamedProperties.Put("LovReference", "");
            this.tblExternalFileParam_colsHelpText.NamedProperties.Put("SqlColumn", "HELP_TEXT");
            this.tblExternalFileParam_colsHelpText.NamedProperties.Put("ValidateMethod", "");
            this.tblExternalFileParam_colsHelpText.Position = 8;
            // 
            // tblExternalFileParam_colnParamNo
            // 
            this.tblExternalFileParam_colnParamNo.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.tblExternalFileParam_colnParamNo, "tblExternalFileParam_colnParamNo");
            this.tblExternalFileParam_colnParamNo.Name = "tblExternalFileParam_colnParamNo";
            this.tblExternalFileParam_colnParamNo.NamedProperties.Put("EnumerateMethod", "");
            this.tblExternalFileParam_colnParamNo.NamedProperties.Put("FieldFlags", "288");
            this.tblExternalFileParam_colnParamNo.NamedProperties.Put("LovReference", "");
            this.tblExternalFileParam_colnParamNo.NamedProperties.Put("SqlColumn", "PARAM_NO");
            this.tblExternalFileParam_colnParamNo.NamedProperties.Put("ValidateMethod", "");
            this.tblExternalFileParam_colnParamNo.Position = 9;
            // 
            // tblExternalFileParam_colsLovView
            // 
            resources.ApplyResources(this.tblExternalFileParam_colsLovView, "tblExternalFileParam_colsLovView");
            this.tblExternalFileParam_colsLovView.MaxLength = 200;
            this.tblExternalFileParam_colsLovView.Name = "tblExternalFileParam_colsLovView";
            this.tblExternalFileParam_colsLovView.NamedProperties.Put("EnumerateMethod", "");
            this.tblExternalFileParam_colsLovView.NamedProperties.Put("FieldFlags", "288");
            this.tblExternalFileParam_colsLovView.NamedProperties.Put("LovReference", "");
            this.tblExternalFileParam_colsLovView.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExternalFileParam_colsLovView.NamedProperties.Put("SqlColumn", "LOV_VIEW");
            this.tblExternalFileParam_colsLovView.NamedProperties.Put("ValidateMethod", "");
            this.tblExternalFileParam_colsLovView.Position = 10;
            // 
            // tblExternalFileParam_colsEnumerateMethod
            // 
            resources.ApplyResources(this.tblExternalFileParam_colsEnumerateMethod, "tblExternalFileParam_colsEnumerateMethod");
            this.tblExternalFileParam_colsEnumerateMethod.MaxLength = 200;
            this.tblExternalFileParam_colsEnumerateMethod.Name = "tblExternalFileParam_colsEnumerateMethod";
            this.tblExternalFileParam_colsEnumerateMethod.NamedProperties.Put("EnumerateMethod", "");
            this.tblExternalFileParam_colsEnumerateMethod.NamedProperties.Put("FieldFlags", "288");
            this.tblExternalFileParam_colsEnumerateMethod.NamedProperties.Put("LovReference", "");
            this.tblExternalFileParam_colsEnumerateMethod.NamedProperties.Put("SqlColumn", "ENUMERATE_METHOD");
            this.tblExternalFileParam_colsEnumerateMethod.NamedProperties.Put("ValidateMethod", "");
            this.tblExternalFileParam_colsEnumerateMethod.Position = 11;
            // 
            // dlgExternalFileParam
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "dlgExternalFileParam";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "");
            this.NamedProperties.Put("PackageName", "");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "1");
            this.NamedProperties.Put("ViewName", "");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.ShowIcon = false;
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dlgExternalFileParam_WindowActions);
            this.ClientArea.ResumeLayout(false);
            this.tblExternalFileParam.ResumeLayout(false);
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

        public cChildTableFin tblExternalFileParam;
        protected cColumn tblExternalFileParam_colsFileType;
        protected cColumn tblExternalFileParam_colsParamId;
        protected cColumn tblExternalFileParam_colsDescription;
        protected cLookupColumn tblExternalFileParam_colsValue;
        protected cColumn tblExternalFileParam_colsBrowsableField;
        protected cColumn tblExternalFileParam_colsHelpText;
        protected cColumn tblExternalFileParam_colnParamNo;
        protected cColumn tblExternalFileParam_colsLovView;
        protected cColumn tblExternalFileParam_colsEnumerateMethod;
		
	}
}
