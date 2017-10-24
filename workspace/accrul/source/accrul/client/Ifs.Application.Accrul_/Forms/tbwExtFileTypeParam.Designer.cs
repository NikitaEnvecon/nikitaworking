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

namespace Ifs.Application.Accrul_
{
	
	public partial class tbwExtFileTypeParam
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cColumn colsFileType;
		public cColumn colnParamNo;
		public cColumn colsParamId;
		public cColumn colsDescription;
		public cCheckBoxColumn colsBrowsableField;
		public cColumn colsHelpText;
		public cColumn colsValidateMethod;
		public cColumn colsLovView;
		public cColumn colsEnumerateMethod;
		public cLookupColumn colsDataType;
		public cColumn colExtFileTypeSystem_Defined;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwExtFileTypeParam));
            this.colsFileType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colnParamNo = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsParamId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsBrowsableField = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.colsHelpText = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsValidateMethod = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsLovView = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsEnumerateMethod = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsDataType = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.colExtFileTypeSystem_Defined = new Ifs.Fnd.ApplicationForms.cColumn();
            this.SuspendLayout();
            // 
            // colsFileType
            // 
            resources.ApplyResources(this.colsFileType, "colsFileType");
            this.colsFileType.MaxLength = 30;
            this.colsFileType.Name = "colsFileType";
            this.colsFileType.NamedProperties.Put("EnumerateMethod", "");
            this.colsFileType.NamedProperties.Put("FieldFlags", "67");
            this.colsFileType.NamedProperties.Put("LovReference", "EXT_FILE_MODULE_NAME");
            this.colsFileType.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsFileType.NamedProperties.Put("SqlColumn", "FILE_TYPE");
            this.colsFileType.Position = 3;
            this.colsFileType.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsFileType_WindowActions);
            // 
            // colnParamNo
            // 
            this.colnParamNo.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colnParamNo.Name = "colnParamNo";
            this.colnParamNo.NamedProperties.Put("EnumerateMethod", "");
            this.colnParamNo.NamedProperties.Put("FieldFlags", "163");
            this.colnParamNo.NamedProperties.Put("LovReference", "");
            this.colnParamNo.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colnParamNo.NamedProperties.Put("ResizeableChildObject", "");
            this.colnParamNo.NamedProperties.Put("SqlColumn", "PARAM_NO");
            this.colnParamNo.NamedProperties.Put("ValidateMethod", "");
            this.colnParamNo.Position = 4;
            resources.ApplyResources(this.colnParamNo, "colnParamNo");
            this.colnParamNo.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colnParamNo_WindowActions);
            // 
            // colsParamId
            // 
            this.colsParamId.MaxLength = 30;
            this.colsParamId.Name = "colsParamId";
            this.colsParamId.NamedProperties.Put("EnumerateMethod", "");
            this.colsParamId.NamedProperties.Put("FieldFlags", "295");
            this.colsParamId.NamedProperties.Put("LovReference", "");
            this.colsParamId.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsParamId.NamedProperties.Put("SqlColumn", "PARAM_ID");
            this.colsParamId.Position = 5;
            resources.ApplyResources(this.colsParamId, "colsParamId");
            this.colsParamId.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsParamId_WindowActions);
            // 
            // colsDescription
            // 
            this.colsDescription.MaxLength = 200;
            this.colsDescription.Name = "colsDescription";
            this.colsDescription.NamedProperties.Put("EnumerateMethod", "");
            this.colsDescription.NamedProperties.Put("FieldFlags", "291");
            this.colsDescription.NamedProperties.Put("LovReference", "");
            this.colsDescription.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.colsDescription.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            this.colsDescription.NamedProperties.Put("ValidateMethod", "");
            this.colsDescription.Position = 6;
            resources.ApplyResources(this.colsDescription, "colsDescription");
            this.colsDescription.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsDescription_WindowActions);
            // 
            // colsBrowsableField
            // 
            this.colsBrowsableField.MaxLength = 5;
            this.colsBrowsableField.Name = "colsBrowsableField";
            this.colsBrowsableField.NamedProperties.Put("EnumerateMethod", "");
            this.colsBrowsableField.NamedProperties.Put("FieldFlags", "294");
            this.colsBrowsableField.NamedProperties.Put("LovReference", "");
            this.colsBrowsableField.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsBrowsableField.NamedProperties.Put("ResizeableChildObject", "");
            this.colsBrowsableField.NamedProperties.Put("SqlColumn", "BROWSABLE_FIELD");
            this.colsBrowsableField.NamedProperties.Put("ValidateMethod", "");
            this.colsBrowsableField.Position = 7;
            resources.ApplyResources(this.colsBrowsableField, "colsBrowsableField");
            this.colsBrowsableField.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsBrowsableField_WindowActions);
            // 
            // colsHelpText
            // 
            this.colsHelpText.MaxLength = 200;
            this.colsHelpText.Name = "colsHelpText";
            this.colsHelpText.NamedProperties.Put("EnumerateMethod", "");
            this.colsHelpText.NamedProperties.Put("FieldFlags", "294");
            this.colsHelpText.NamedProperties.Put("LovReference", "");
            this.colsHelpText.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsHelpText.NamedProperties.Put("SqlColumn", "HELP_TEXT");
            this.colsHelpText.Position = 8;
            resources.ApplyResources(this.colsHelpText, "colsHelpText");
            this.colsHelpText.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsHelpText_WindowActions);
            // 
            // colsValidateMethod
            // 
            this.colsValidateMethod.MaxLength = 200;
            this.colsValidateMethod.Name = "colsValidateMethod";
            this.colsValidateMethod.NamedProperties.Put("EnumerateMethod", "");
            this.colsValidateMethod.NamedProperties.Put("FieldFlags", "294");
            this.colsValidateMethod.NamedProperties.Put("LovReference", "");
            this.colsValidateMethod.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsValidateMethod.NamedProperties.Put("SqlColumn", "VALIDATE_METHOD");
            this.colsValidateMethod.Position = 9;
            resources.ApplyResources(this.colsValidateMethod, "colsValidateMethod");
            this.colsValidateMethod.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsValidateMethod_WindowActions);
            // 
            // colsLovView
            // 
            this.colsLovView.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsLovView.MaxLength = 200;
            this.colsLovView.Name = "colsLovView";
            this.colsLovView.NamedProperties.Put("EnumerateMethod", "");
            this.colsLovView.NamedProperties.Put("FieldFlags", "294");
            this.colsLovView.NamedProperties.Put("LovReference", "");
            this.colsLovView.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsLovView.NamedProperties.Put("ResizeableChildObject", "");
            this.colsLovView.NamedProperties.Put("SqlColumn", "LOV_VIEW");
            this.colsLovView.NamedProperties.Put("ValidateMethod", "");
            this.colsLovView.Position = 10;
            resources.ApplyResources(this.colsLovView, "colsLovView");
            this.colsLovView.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsLovView_WindowActions);
            // 
            // colsEnumerateMethod
            // 
            this.colsEnumerateMethod.MaxLength = 200;
            this.colsEnumerateMethod.Name = "colsEnumerateMethod";
            this.colsEnumerateMethod.NamedProperties.Put("EnumerateMethod", "");
            this.colsEnumerateMethod.NamedProperties.Put("FieldFlags", "294");
            this.colsEnumerateMethod.NamedProperties.Put("LovReference", "");
            this.colsEnumerateMethod.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsEnumerateMethod.NamedProperties.Put("ResizeableChildObject", "");
            this.colsEnumerateMethod.NamedProperties.Put("SqlColumn", "ENUMERATE_METHOD");
            this.colsEnumerateMethod.NamedProperties.Put("ValidateMethod", "");
            this.colsEnumerateMethod.Position = 11;
            resources.ApplyResources(this.colsEnumerateMethod, "colsEnumerateMethod");
            this.colsEnumerateMethod.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsEnumerateMethod_WindowActions);
            // 
            // colsDataType
            // 
            this.colsDataType.MaxLength = 200;
            this.colsDataType.Name = "colsDataType";
            this.colsDataType.NamedProperties.Put("EnumerateMethod", "EXTY_DATA_TYPE_API.Enumerate");
            this.colsDataType.NamedProperties.Put("FieldFlags", "295");
            this.colsDataType.NamedProperties.Put("LovReference", "");
            this.colsDataType.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsDataType.NamedProperties.Put("ResizeableChildObject", "");
            this.colsDataType.NamedProperties.Put("SqlColumn", "DATA_TYPE");
            this.colsDataType.NamedProperties.Put("ValidateMethod", "");
            this.colsDataType.Position = 12;
            resources.ApplyResources(this.colsDataType, "colsDataType");
            this.colsDataType.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsDataType_WindowActions);
            // 
            // colExtFileTypeSystem_Defined
            // 
            resources.ApplyResources(this.colExtFileTypeSystem_Defined, "colExtFileTypeSystem_Defined");
            this.colExtFileTypeSystem_Defined.MaxLength = 2000;
            this.colExtFileTypeSystem_Defined.Name = "colExtFileTypeSystem_Defined";
            this.colExtFileTypeSystem_Defined.NamedProperties.Put("EnumerateMethod", "");
            this.colExtFileTypeSystem_Defined.NamedProperties.Put("FieldFlags", "304");
            this.colExtFileTypeSystem_Defined.NamedProperties.Put("LovReference", "");
            this.colExtFileTypeSystem_Defined.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colExtFileTypeSystem_Defined.NamedProperties.Put("SqlColumn", "EXT_FILE_TYPE_API.Get_System_Defined(FILE_TYPE)");
            this.colExtFileTypeSystem_Defined.Position = 13;
            // 
            // tbwExtFileTypeParam
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colsFileType);
            this.Controls.Add(this.colnParamNo);
            this.Controls.Add(this.colsParamId);
            this.Controls.Add(this.colsDescription);
            this.Controls.Add(this.colsBrowsableField);
            this.Controls.Add(this.colsHelpText);
            this.Controls.Add(this.colsValidateMethod);
            this.Controls.Add(this.colsLovView);
            this.Controls.Add(this.colsEnumerateMethod);
            this.Controls.Add(this.colsDataType);
            this.Controls.Add(this.colExtFileTypeSystem_Defined);
            this.Name = "tbwExtFileTypeParam";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "ExtFileTypeParam");
            this.NamedProperties.Put("PackageName", "EXT_FILE_TYPE_PARAM_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "449");
            this.NamedProperties.Put("ViewName", "EXT_FILE_TYPE_PARAM");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.Tag = "Ext File Type Param ";
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tbwExtFileTypeParam_WindowActions);
            this.Controls.SetChildIndex(this.colExtFileTypeSystem_Defined, 0);
            this.Controls.SetChildIndex(this.colsDataType, 0);
            this.Controls.SetChildIndex(this.colsEnumerateMethod, 0);
            this.Controls.SetChildIndex(this.colsLovView, 0);
            this.Controls.SetChildIndex(this.colsValidateMethod, 0);
            this.Controls.SetChildIndex(this.colsHelpText, 0);
            this.Controls.SetChildIndex(this.colsBrowsableField, 0);
            this.Controls.SetChildIndex(this.colsDescription, 0);
            this.Controls.SetChildIndex(this.colsParamId, 0);
            this.Controls.SetChildIndex(this.colnParamNo, 0);
            this.Controls.SetChildIndex(this.colsFileType, 0);
            this.Controls.SetChildIndex(this.@__colObjversion, 0);
            this.Controls.SetChildIndex(this.@__colObjid, 0);
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
