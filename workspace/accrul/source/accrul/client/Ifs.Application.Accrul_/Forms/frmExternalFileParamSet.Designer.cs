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
	
	public partial class frmExternalFileParamSet
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		protected cBackgroundText labeldfsFileType;
		public cRecListDataField dfsFileType;
		protected cBackgroundText labeldfExtFileTypeDescription;
		public cDataField dfExtFileTypeDescription;
		protected cBackgroundText labeldfsSetId;
		public cDataField dfsSetId;
		protected cBackgroundText labeldfsDescription;
		public cDataField dfsDescription;
		public cCheckBox cbSetIdDefault;
		public cCheckBox cbSystemDefined;
        // Bug 73298 Begin - Changed the derived base class.
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExternalFileParamSet));
            this.labeldfsFileType = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsFileType = new Ifs.Fnd.ApplicationForms.cRecListDataField();
            this.labeldfExtFileTypeDescription = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfExtFileTypeDescription = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsSetId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsSetId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsDescription = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsDescription = new Ifs.Fnd.ApplicationForms.cDataField();
            this.cbSetIdDefault = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.cbSystemDefined = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.tblExtFileParamPerSet = new Ifs.Application.Accrul.cChildTableFinBase();
            this.tblExtFileParamPerSet_colsFileType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExtFileParamPerSet_colsSetId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExtFileParamPerSet_colnParamNo = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExtFileParamPerSet_colExtFileTypeParamDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExtFileParamPerSet_colsEnumValue = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.tblExtFileParamPerSet_colsDefaultValue = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExtFileParamPerSet_colsMandatoryParam = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.tblExtFileParamPerSet_colsShowAtLoad = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.tblExtFileParamPerSet_colsInputableAtLoad = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.tblExtFileParamPerSet_colEnumerate_Method = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExtFileParamPerSet.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.ImageList = null;
            // 
            // labeldfsFileType
            // 
            resources.ApplyResources(this.labeldfsFileType, "labeldfsFileType");
            this.labeldfsFileType.Name = "labeldfsFileType";
            // 
            // dfsFileType
            // 
            resources.ApplyResources(this.dfsFileType, "dfsFileType");
            this.dfsFileType.Name = "dfsFileType";
            this.dfsFileType.NamedProperties.Put("EnumerateMethod", "");
            this.dfsFileType.NamedProperties.Put("FieldFlags", "288");
            this.dfsFileType.NamedProperties.Put("LovReference", "");
            this.dfsFileType.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsFileType.NamedProperties.Put("SqlColumn", "FILE_TYPE");
            this.dfsFileType.NamedProperties.Put("ValidateMethod", "");
            this.dfsFileType.NamedProperties.Put("XDataLength", "");
            this.dfsFileType.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsFileType_WindowActions);
            // 
            // labeldfExtFileTypeDescription
            // 
            resources.ApplyResources(this.labeldfExtFileTypeDescription, "labeldfExtFileTypeDescription");
            this.labeldfExtFileTypeDescription.Name = "labeldfExtFileTypeDescription";
            // 
            // dfExtFileTypeDescription
            // 
            resources.ApplyResources(this.dfExtFileTypeDescription, "dfExtFileTypeDescription");
            this.dfExtFileTypeDescription.Name = "dfExtFileTypeDescription";
            this.dfExtFileTypeDescription.NamedProperties.Put("EnumerateMethod", "");
            this.dfExtFileTypeDescription.NamedProperties.Put("FieldFlags", "272");
            this.dfExtFileTypeDescription.NamedProperties.Put("LovReference", "");
            this.dfExtFileTypeDescription.NamedProperties.Put("SqlColumn", "EXT_FILE_TYPE_API.Get_Description(FILE_TYPE)");
            this.dfExtFileTypeDescription.NamedProperties.Put("ValidateMethod", "");
            this.dfExtFileTypeDescription.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfExtFileTypeDescription_WindowActions);
            // 
            // labeldfsSetId
            // 
            resources.ApplyResources(this.labeldfsSetId, "labeldfsSetId");
            this.labeldfsSetId.Name = "labeldfsSetId";
            // 
            // dfsSetId
            // 
            resources.ApplyResources(this.dfsSetId, "dfsSetId");
            this.dfsSetId.Name = "dfsSetId";
            this.dfsSetId.NamedProperties.Put("EnumerateMethod", "");
            this.dfsSetId.NamedProperties.Put("FieldFlags", "163");
            this.dfsSetId.NamedProperties.Put("LovReference", "");
            this.dfsSetId.NamedProperties.Put("ParentName", "dfsFileType");
            this.dfsSetId.NamedProperties.Put("SqlColumn", "SET_ID");
            this.dfsSetId.NamedProperties.Put("ValidateMethod", "");
            this.dfsSetId.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsSetId_WindowActions);
            // 
            // labeldfsDescription
            // 
            resources.ApplyResources(this.labeldfsDescription, "labeldfsDescription");
            this.labeldfsDescription.Name = "labeldfsDescription";
            // 
            // dfsDescription
            // 
            resources.ApplyResources(this.dfsDescription, "dfsDescription");
            this.dfsDescription.Name = "dfsDescription";
            this.dfsDescription.NamedProperties.Put("EnumerateMethod", "");
            this.dfsDescription.NamedProperties.Put("FieldFlags", "295");
            this.dfsDescription.NamedProperties.Put("LovReference", "");
            this.dfsDescription.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            this.dfsDescription.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsDescription_WindowActions);
            // 
            // cbSetIdDefault
            // 
            resources.ApplyResources(this.cbSetIdDefault, "cbSetIdDefault");
            this.cbSetIdDefault.Name = "cbSetIdDefault";
            this.cbSetIdDefault.NamedProperties.Put("DataType", "5");
            this.cbSetIdDefault.NamedProperties.Put("EnumerateMethod", "");
            this.cbSetIdDefault.NamedProperties.Put("FieldFlags", "290");
            this.cbSetIdDefault.NamedProperties.Put("LovReference", "");
            this.cbSetIdDefault.NamedProperties.Put("ResizeableChildObject", "");
            this.cbSetIdDefault.NamedProperties.Put("SqlColumn", "SET_ID_DEFAULT");
            this.cbSetIdDefault.NamedProperties.Put("ValidateMethod", "");
            this.cbSetIdDefault.NamedProperties.Put("XDataLength", "5");
            this.cbSetIdDefault.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cbSetIdDefault_WindowActions);
            // 
            // cbSystemDefined
            // 
            resources.ApplyResources(this.cbSystemDefined, "cbSystemDefined");
            this.cbSystemDefined.Name = "cbSystemDefined";
            this.cbSystemDefined.NamedProperties.Put("DataType", "5");
            this.cbSystemDefined.NamedProperties.Put("EnumerateMethod", "");
            this.cbSystemDefined.NamedProperties.Put("FieldFlags", "290");
            this.cbSystemDefined.NamedProperties.Put("LovReference", "");
            this.cbSystemDefined.NamedProperties.Put("ResizeableChildObject", "");
            this.cbSystemDefined.NamedProperties.Put("SqlColumn", "SYSTEM_DEFINED");
            this.cbSystemDefined.NamedProperties.Put("ValidateMethod", "");
            this.cbSystemDefined.NamedProperties.Put("XDataLength", "5");
            this.cbSystemDefined.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cbSystemDefined_WindowActions);
            // 
            // tblExtFileParamPerSet
            // 
            this.tblExtFileParamPerSet.Controls.Add(this.tblExtFileParamPerSet_colsFileType);
            this.tblExtFileParamPerSet.Controls.Add(this.tblExtFileParamPerSet_colsSetId);
            this.tblExtFileParamPerSet.Controls.Add(this.tblExtFileParamPerSet_colnParamNo);
            this.tblExtFileParamPerSet.Controls.Add(this.tblExtFileParamPerSet_colExtFileTypeParamDescription);
            this.tblExtFileParamPerSet.Controls.Add(this.tblExtFileParamPerSet_colsEnumValue);
            this.tblExtFileParamPerSet.Controls.Add(this.tblExtFileParamPerSet_colsDefaultValue);
            this.tblExtFileParamPerSet.Controls.Add(this.tblExtFileParamPerSet_colsMandatoryParam);
            this.tblExtFileParamPerSet.Controls.Add(this.tblExtFileParamPerSet_colsShowAtLoad);
            this.tblExtFileParamPerSet.Controls.Add(this.tblExtFileParamPerSet_colsInputableAtLoad);
            this.tblExtFileParamPerSet.Controls.Add(this.tblExtFileParamPerSet_colEnumerate_Method);
            resources.ApplyResources(this.tblExtFileParamPerSet, "tblExtFileParamPerSet");
            this.tblExtFileParamPerSet.Name = "tblExtFileParamPerSet";
            this.tblExtFileParamPerSet.NamedProperties.Put("DefaultOrderBy", "");
            this.tblExtFileParamPerSet.NamedProperties.Put("DefaultWhere", "");
            this.tblExtFileParamPerSet.NamedProperties.Put("LogicalUnit", "ExtTypeParamPerSet");
            this.tblExtFileParamPerSet.NamedProperties.Put("PackageName", "EXT_TYPE_PARAM_PER_SET_API");
            this.tblExtFileParamPerSet.NamedProperties.Put("ResizeableChildObject", "LLMM");
            this.tblExtFileParamPerSet.NamedProperties.Put("ViewName", "EXT_TYPE_PARAM_PER_SET");
            this.tblExtFileParamPerSet.NamedProperties.Put("Warnings", "FALSE");
            this.tblExtFileParamPerSet.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblExtFileParamPerSet_WindowActions);
            this.tblExtFileParamPerSet.Controls.SetChildIndex(this.tblExtFileParamPerSet_colEnumerate_Method, 0);
            this.tblExtFileParamPerSet.Controls.SetChildIndex(this.tblExtFileParamPerSet_colsInputableAtLoad, 0);
            this.tblExtFileParamPerSet.Controls.SetChildIndex(this.tblExtFileParamPerSet_colsShowAtLoad, 0);
            this.tblExtFileParamPerSet.Controls.SetChildIndex(this.tblExtFileParamPerSet_colsMandatoryParam, 0);
            this.tblExtFileParamPerSet.Controls.SetChildIndex(this.tblExtFileParamPerSet_colsDefaultValue, 0);
            this.tblExtFileParamPerSet.Controls.SetChildIndex(this.tblExtFileParamPerSet_colsEnumValue, 0);
            this.tblExtFileParamPerSet.Controls.SetChildIndex(this.tblExtFileParamPerSet_colExtFileTypeParamDescription, 0);
            this.tblExtFileParamPerSet.Controls.SetChildIndex(this.tblExtFileParamPerSet_colnParamNo, 0);
            this.tblExtFileParamPerSet.Controls.SetChildIndex(this.tblExtFileParamPerSet_colsSetId, 0);
            this.tblExtFileParamPerSet.Controls.SetChildIndex(this.tblExtFileParamPerSet_colsFileType, 0);
            // 
            // tblExtFileParamPerSet_colsFileType
            // 
            resources.ApplyResources(this.tblExtFileParamPerSet_colsFileType, "tblExtFileParamPerSet_colsFileType");
            this.tblExtFileParamPerSet_colsFileType.MaxLength = 30;
            this.tblExtFileParamPerSet_colsFileType.Name = "tblExtFileParamPerSet_colsFileType";
            this.tblExtFileParamPerSet_colsFileType.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileParamPerSet_colsFileType.NamedProperties.Put("FieldFlags", "67");
            this.tblExtFileParamPerSet_colsFileType.NamedProperties.Put("LovReference", "");
            this.tblExtFileParamPerSet_colsFileType.NamedProperties.Put("SqlColumn", "FILE_TYPE");
            this.tblExtFileParamPerSet_colsFileType.Position = 3;
            this.tblExtFileParamPerSet_colsFileType.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblExtFileParamPerSet_colsFileType_WindowActions);
            // 
            // tblExtFileParamPerSet_colsSetId
            // 
            resources.ApplyResources(this.tblExtFileParamPerSet_colsSetId, "tblExtFileParamPerSet_colsSetId");
            this.tblExtFileParamPerSet_colsSetId.MaxLength = 20;
            this.tblExtFileParamPerSet_colsSetId.Name = "tblExtFileParamPerSet_colsSetId";
            this.tblExtFileParamPerSet_colsSetId.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileParamPerSet_colsSetId.NamedProperties.Put("FieldFlags", "67");
            this.tblExtFileParamPerSet_colsSetId.NamedProperties.Put("LovReference", "EXT_TYPE_PARAM_SET(FILE_TYPE)");
            this.tblExtFileParamPerSet_colsSetId.NamedProperties.Put("SqlColumn", "SET_ID");
            this.tblExtFileParamPerSet_colsSetId.Position = 4;
            this.tblExtFileParamPerSet_colsSetId.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblExtFileParamPerSet_colsSetId_WindowActions);
            // 
            // tblExtFileParamPerSet_colnParamNo
            // 
            this.tblExtFileParamPerSet_colnParamNo.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileParamPerSet_colnParamNo.Name = "tblExtFileParamPerSet_colnParamNo";
            this.tblExtFileParamPerSet_colnParamNo.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileParamPerSet_colnParamNo.NamedProperties.Put("FieldFlags", "67");
            this.tblExtFileParamPerSet_colnParamNo.NamedProperties.Put("LovReference", "EXT_FILE_TYPE_PARAM(FILE_TYPE)");
            this.tblExtFileParamPerSet_colnParamNo.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileParamPerSet_colnParamNo.NamedProperties.Put("SqlColumn", "PARAM_NO");
            this.tblExtFileParamPerSet_colnParamNo.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileParamPerSet_colnParamNo.Position = 5;
            resources.ApplyResources(this.tblExtFileParamPerSet_colnParamNo, "tblExtFileParamPerSet_colnParamNo");
            this.tblExtFileParamPerSet_colnParamNo.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblExtFileParamPerSet_colnParamNo_WindowActions);
            // 
            // tblExtFileParamPerSet_colExtFileTypeParamDescription
            // 
            this.tblExtFileParamPerSet_colExtFileTypeParamDescription.MaxLength = 2000;
            this.tblExtFileParamPerSet_colExtFileTypeParamDescription.Name = "tblExtFileParamPerSet_colExtFileTypeParamDescription";
            this.tblExtFileParamPerSet_colExtFileTypeParamDescription.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileParamPerSet_colExtFileTypeParamDescription.NamedProperties.Put("FieldFlags", "272");
            this.tblExtFileParamPerSet_colExtFileTypeParamDescription.NamedProperties.Put("LovReference", "");
            this.tblExtFileParamPerSet_colExtFileTypeParamDescription.NamedProperties.Put("ParentName", "tblExtFileParamPerSet.tblExtFileParamPerSet_colnParamNo");
            this.tblExtFileParamPerSet_colExtFileTypeParamDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileParamPerSet_colExtFileTypeParamDescription.NamedProperties.Put("SqlColumn", "EXT_FILE_TYPE_PARAM_API.Get_Description(file_type,PARAM_NO)");
            this.tblExtFileParamPerSet_colExtFileTypeParamDescription.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileParamPerSet_colExtFileTypeParamDescription.Position = 6;
            resources.ApplyResources(this.tblExtFileParamPerSet_colExtFileTypeParamDescription, "tblExtFileParamPerSet_colExtFileTypeParamDescription");
            this.tblExtFileParamPerSet_colExtFileTypeParamDescription.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblExtFileParamPerSet_colExtFileTypeParamDescription_WindowActions);
            // 
            // tblExtFileParamPerSet_colsEnumValue
            // 
            this.tblExtFileParamPerSet_colsEnumValue.Name = "tblExtFileParamPerSet_colsEnumValue";
            this.tblExtFileParamPerSet_colsEnumValue.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileParamPerSet_colsEnumValue.NamedProperties.Put("FieldFlags", "262");
            this.tblExtFileParamPerSet_colsEnumValue.NamedProperties.Put("LovReference", "");
            this.tblExtFileParamPerSet_colsEnumValue.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileParamPerSet_colsEnumValue.NamedProperties.Put("SqlColumn", "");
            this.tblExtFileParamPerSet_colsEnumValue.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileParamPerSet_colsEnumValue.Position = 7;
            resources.ApplyResources(this.tblExtFileParamPerSet_colsEnumValue, "tblExtFileParamPerSet_colsEnumValue");
            this.tblExtFileParamPerSet_colsEnumValue.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblExtFileParamPerSet_colsEnumValue_WindowActions);
            // 
            // tblExtFileParamPerSet_colsDefaultValue
            // 
            resources.ApplyResources(this.tblExtFileParamPerSet_colsDefaultValue, "tblExtFileParamPerSet_colsDefaultValue");
            this.tblExtFileParamPerSet_colsDefaultValue.MaxLength = 50;
            this.tblExtFileParamPerSet_colsDefaultValue.Name = "tblExtFileParamPerSet_colsDefaultValue";
            this.tblExtFileParamPerSet_colsDefaultValue.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileParamPerSet_colsDefaultValue.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileParamPerSet_colsDefaultValue.NamedProperties.Put("LovReference", "");
            this.tblExtFileParamPerSet_colsDefaultValue.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileParamPerSet_colsDefaultValue.NamedProperties.Put("SqlColumn", "DEFAULT_VALUE");
            this.tblExtFileParamPerSet_colsDefaultValue.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileParamPerSet_colsDefaultValue.Position = 8;
            // 
            // tblExtFileParamPerSet_colsMandatoryParam
            // 
            this.tblExtFileParamPerSet_colsMandatoryParam.MaxLength = 5;
            this.tblExtFileParamPerSet_colsMandatoryParam.Name = "tblExtFileParamPerSet_colsMandatoryParam";
            this.tblExtFileParamPerSet_colsMandatoryParam.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileParamPerSet_colsMandatoryParam.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileParamPerSet_colsMandatoryParam.NamedProperties.Put("LovReference", "");
            this.tblExtFileParamPerSet_colsMandatoryParam.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileParamPerSet_colsMandatoryParam.NamedProperties.Put("SqlColumn", "MANDATORY_PARAM");
            this.tblExtFileParamPerSet_colsMandatoryParam.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileParamPerSet_colsMandatoryParam.Position = 9;
            resources.ApplyResources(this.tblExtFileParamPerSet_colsMandatoryParam, "tblExtFileParamPerSet_colsMandatoryParam");
            this.tblExtFileParamPerSet_colsMandatoryParam.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblExtFileParamPerSet_colsMandatoryParam_WindowActions);
            // 
            // tblExtFileParamPerSet_colsShowAtLoad
            // 
            this.tblExtFileParamPerSet_colsShowAtLoad.MaxLength = 5;
            this.tblExtFileParamPerSet_colsShowAtLoad.Name = "tblExtFileParamPerSet_colsShowAtLoad";
            this.tblExtFileParamPerSet_colsShowAtLoad.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileParamPerSet_colsShowAtLoad.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileParamPerSet_colsShowAtLoad.NamedProperties.Put("LovReference", "");
            this.tblExtFileParamPerSet_colsShowAtLoad.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileParamPerSet_colsShowAtLoad.NamedProperties.Put("SqlColumn", "SHOW_AT_LOAD");
            this.tblExtFileParamPerSet_colsShowAtLoad.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileParamPerSet_colsShowAtLoad.Position = 10;
            resources.ApplyResources(this.tblExtFileParamPerSet_colsShowAtLoad, "tblExtFileParamPerSet_colsShowAtLoad");
            this.tblExtFileParamPerSet_colsShowAtLoad.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblExtFileParamPerSet_colsShowAtLoad_WindowActions);
            // 
            // tblExtFileParamPerSet_colsInputableAtLoad
            // 
            this.tblExtFileParamPerSet_colsInputableAtLoad.MaxLength = 5;
            this.tblExtFileParamPerSet_colsInputableAtLoad.Name = "tblExtFileParamPerSet_colsInputableAtLoad";
            this.tblExtFileParamPerSet_colsInputableAtLoad.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileParamPerSet_colsInputableAtLoad.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileParamPerSet_colsInputableAtLoad.NamedProperties.Put("LovReference", "");
            this.tblExtFileParamPerSet_colsInputableAtLoad.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileParamPerSet_colsInputableAtLoad.NamedProperties.Put("SqlColumn", "INPUTABLE_AT_LOAD");
            this.tblExtFileParamPerSet_colsInputableAtLoad.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileParamPerSet_colsInputableAtLoad.Position = 11;
            resources.ApplyResources(this.tblExtFileParamPerSet_colsInputableAtLoad, "tblExtFileParamPerSet_colsInputableAtLoad");
            this.tblExtFileParamPerSet_colsInputableAtLoad.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblExtFileParamPerSet_colsInputableAtLoad_WindowActions);
            // 
            // tblExtFileParamPerSet_colEnumerate_Method
            // 
            resources.ApplyResources(this.tblExtFileParamPerSet_colEnumerate_Method, "tblExtFileParamPerSet_colEnumerate_Method");
            this.tblExtFileParamPerSet_colEnumerate_Method.MaxLength = 2000;
            this.tblExtFileParamPerSet_colEnumerate_Method.Name = "tblExtFileParamPerSet_colEnumerate_Method";
            this.tblExtFileParamPerSet_colEnumerate_Method.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileParamPerSet_colEnumerate_Method.NamedProperties.Put("FieldFlags", "304");
            this.tblExtFileParamPerSet_colEnumerate_Method.NamedProperties.Put("LovReference", "");
            this.tblExtFileParamPerSet_colEnumerate_Method.NamedProperties.Put("SqlColumn", "EXT_FILE_TYPE_PARAM_API.Get_Enumerate_Method(file_type,PARAM_NO)");
            this.tblExtFileParamPerSet_colEnumerate_Method.Position = 12;
            // 
            // frmExternalFileParamSet
            // 
            this.AutoScaleBaseDpi = new System.Drawing.Size(106, 106);
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.tblExtFileParamPerSet);
            this.Controls.Add(this.cbSystemDefined);
            this.Controls.Add(this.cbSetIdDefault);
            this.Controls.Add(this.dfsDescription);
            this.Controls.Add(this.dfsSetId);
            this.Controls.Add(this.dfExtFileTypeDescription);
            this.Controls.Add(this.dfsFileType);
            this.Controls.Add(this.labeldfsDescription);
            this.Controls.Add(this.labeldfsSetId);
            this.Controls.Add(this.labeldfExtFileTypeDescription);
            this.Controls.Add(this.labeldfsFileType);
            this.Name = "frmExternalFileParamSet";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "ExtTypeParamSet");
            this.NamedProperties.Put("PackageName", "EXT_TYPE_PARAM_SET_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "1");
            this.NamedProperties.Put("ViewName", "EXT_TYPE_PARAM_SET");
            this.NamedProperties.Put("Warnings", "TRUE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.frmExternalFileParamSet_WindowActions);
            this.tblExtFileParamPerSet.ResumeLayout(false);
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

        public Accrul.cChildTableFinBase tblExtFileParamPerSet;
        protected cColumn tblExtFileParamPerSet_colsFileType;
        protected cColumn tblExtFileParamPerSet_colsSetId;
        protected cColumn tblExtFileParamPerSet_colnParamNo;
        protected cColumn tblExtFileParamPerSet_colExtFileTypeParamDescription;
        protected cLookupColumn tblExtFileParamPerSet_colsEnumValue;
        protected cColumn tblExtFileParamPerSet_colsDefaultValue;
        protected cCheckBoxColumn tblExtFileParamPerSet_colsMandatoryParam;
        protected cCheckBoxColumn tblExtFileParamPerSet_colsShowAtLoad;
        protected cCheckBoxColumn tblExtFileParamPerSet_colsInputableAtLoad;
        protected cColumn tblExtFileParamPerSet_colEnumerate_Method;
		
	}
}
