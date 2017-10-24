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
	
	public partial class frmExternalFileTemplateControl
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		protected cBackgroundText labeldfsFileTemplateId;
		public cDataField dfsFileTemplateId;
		protected cBackgroundText labeldfExtFileTemplateDescription;
		public cDataField dfExtFileTemplateDescription;
		public cCheckBoxFin cbSystemDefined;
		protected cBackgroundText labeldfsFileType;
		public cDataField dfsFileType;
		protected cBackgroundText labeldfExtFileTypeDescription;
		public cDataField dfExtFileTypeDescription;
		protected cBackgroundText labeldfsFileDirection;
		public cDataField dfsFileDirection;
		public cDataField dfsFileDirectionDb;
        // Bug 73298 Begin - Changed the derived base class.
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExternalFileTemplateControl));
            this.labeldfsFileTemplateId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsFileTemplateId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfExtFileTemplateDescription = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfExtFileTemplateDescription = new Ifs.Fnd.ApplicationForms.cDataField();
            this.cbSystemDefined = new Ifs.Application.Accrul.cCheckBoxFin();
            this.labeldfsFileType = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsFileType = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfExtFileTypeDescription = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfExtFileTypeDescription = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsFileDirection = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsFileDirection = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsFileDirectionDb = new Ifs.Fnd.ApplicationForms.cDataField();
            this.tblExtFileTemplateControl = new Ifs.Application.Accrul.cChildTableFinBase();
            this.tblExtFileTemplateControl_colxFileTemplateId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExtFileTemplateControl_colxFileType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExtFileTemplateControl_colsFileDirection = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.tblExtFileTemplateControl_colsRecordTypeId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExtFileTemplateControl_colnRowNo = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExtFileTemplateControl_colnGroupNo = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExtFileTemplateControl_colsCondition = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.tblExtFileTemplateControl_colnColumnNo = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExtFileTemplateControl_colnStartPosition = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExtFileTemplateControl_colnEndPosition = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExtFileTemplateControl_colsControlString = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExtFileTemplateControl_colsDestinationColumn = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExtFileTemplateControl_colnNoOfLines = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExtFileTemplateControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.ImageList = null;
            // 
            // labeldfsFileTemplateId
            // 
            resources.ApplyResources(this.labeldfsFileTemplateId, "labeldfsFileTemplateId");
            this.labeldfsFileTemplateId.Name = "labeldfsFileTemplateId";
            // 
            // dfsFileTemplateId
            // 
            resources.ApplyResources(this.dfsFileTemplateId, "dfsFileTemplateId");
            this.dfsFileTemplateId.Name = "dfsFileTemplateId";
            this.dfsFileTemplateId.NamedProperties.Put("EnumerateMethod", "");
            this.dfsFileTemplateId.NamedProperties.Put("FieldFlags", "290");
            this.dfsFileTemplateId.NamedProperties.Put("LovReference", "");
            this.dfsFileTemplateId.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsFileTemplateId.NamedProperties.Put("SqlColumn", "FILE_TEMPLATE_ID");
            this.dfsFileTemplateId.NamedProperties.Put("ValidateMethod", "");
            this.dfsFileTemplateId.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsFileTemplateId_WindowActions);
            // 
            // labeldfExtFileTemplateDescription
            // 
            resources.ApplyResources(this.labeldfExtFileTemplateDescription, "labeldfExtFileTemplateDescription");
            this.labeldfExtFileTemplateDescription.Name = "labeldfExtFileTemplateDescription";
            // 
            // dfExtFileTemplateDescription
            // 
            resources.ApplyResources(this.dfExtFileTemplateDescription, "dfExtFileTemplateDescription");
            this.dfExtFileTemplateDescription.Name = "dfExtFileTemplateDescription";
            this.dfExtFileTemplateDescription.NamedProperties.Put("EnumerateMethod", "");
            this.dfExtFileTemplateDescription.NamedProperties.Put("FieldFlags", "304");
            this.dfExtFileTemplateDescription.NamedProperties.Put("LovReference", "");
            this.dfExtFileTemplateDescription.NamedProperties.Put("SqlColumn", "EXT_FILE_TEMPLATE_API.Get_Description(FILE_TEMPLATE_ID)");
            this.dfExtFileTemplateDescription.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfExtFileTemplateDescription_WindowActions);
            // 
            // cbSystemDefined
            // 
            resources.ApplyResources(this.cbSystemDefined, "cbSystemDefined");
            this.cbSystemDefined.Name = "cbSystemDefined";
            this.cbSystemDefined.NamedProperties.Put("DataType", "7");
            this.cbSystemDefined.NamedProperties.Put("EnumerateMethod", "");
            this.cbSystemDefined.NamedProperties.Put("FieldFlags", "291");
            this.cbSystemDefined.NamedProperties.Put("LovReference", "");
            this.cbSystemDefined.NamedProperties.Put("ParentName", "dfsFileTemplateId");
            this.cbSystemDefined.NamedProperties.Put("ResizeableChildObject", "");
            this.cbSystemDefined.NamedProperties.Put("SqlColumn", "EXT_FILE_TEMPLATE_API.Get_System_Defined(FILE_TEMPLATE_ID)");
            this.cbSystemDefined.NamedProperties.Put("ValidateMethod", "");
            this.cbSystemDefined.NamedProperties.Put("XDataLength", "2000");
            this.cbSystemDefined.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cbSystemDefined_WindowActions);
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
            this.dfsFileType.NamedProperties.Put("FieldFlags", "290");
            this.dfsFileType.NamedProperties.Put("LovReference", "");
            this.dfsFileType.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsFileType.NamedProperties.Put("SqlColumn", "EXT_FILE_TEMPLATE_API.Get_File_Type(FILE_TEMPLATE_ID)");
            this.dfsFileType.NamedProperties.Put("ValidateMethod", "");
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
            this.dfExtFileTypeDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.dfExtFileTypeDescription.NamedProperties.Put("SqlColumn", "EXT_FILE_TYPE_API.Get_Description(EXT_FILE_TEMPLATE_API.Get_File_Type(FILE_TEMPLA" +
                    "TE_ID))");
            this.dfExtFileTypeDescription.NamedProperties.Put("ValidateMethod", "");
            this.dfExtFileTypeDescription.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfExtFileTypeDescription_WindowActions);
            // 
            // labeldfsFileDirection
            // 
            resources.ApplyResources(this.labeldfsFileDirection, "labeldfsFileDirection");
            this.labeldfsFileDirection.Name = "labeldfsFileDirection";
            // 
            // dfsFileDirection
            // 
            resources.ApplyResources(this.dfsFileDirection, "dfsFileDirection");
            this.dfsFileDirection.Name = "dfsFileDirection";
            this.dfsFileDirection.NamedProperties.Put("EnumerateMethod", "");
            this.dfsFileDirection.NamedProperties.Put("FieldFlags", "288");
            this.dfsFileDirection.NamedProperties.Put("LovReference", "");
            this.dfsFileDirection.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsFileDirection.NamedProperties.Put("SqlColumn", "FILE_DIRECTION");
            this.dfsFileDirection.NamedProperties.Put("ValidateMethod", "");
            this.dfsFileDirection.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsFileDirection_WindowActions);
            // 
            // dfsFileDirectionDb
            // 
            resources.ApplyResources(this.dfsFileDirectionDb, "dfsFileDirectionDb");
            this.dfsFileDirectionDb.Name = "dfsFileDirectionDb";
            this.dfsFileDirectionDb.NamedProperties.Put("EnumerateMethod", "");
            this.dfsFileDirectionDb.NamedProperties.Put("LovReference", "");
            this.dfsFileDirectionDb.NamedProperties.Put("SqlColumn", "FILE_DIRECTION_DB");
            this.dfsFileDirectionDb.NamedProperties.Put("ValidateMethod", "");
            this.dfsFileDirectionDb.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsFileDirectionDb_WindowActions);
            // 
            // tblExtFileTemplateControl
            // 
            this.tblExtFileTemplateControl.Controls.Add(this.tblExtFileTemplateControl_colxFileTemplateId);
            this.tblExtFileTemplateControl.Controls.Add(this.tblExtFileTemplateControl_colxFileType);
            this.tblExtFileTemplateControl.Controls.Add(this.tblExtFileTemplateControl_colsFileDirection);
            this.tblExtFileTemplateControl.Controls.Add(this.tblExtFileTemplateControl_colsRecordTypeId);
            this.tblExtFileTemplateControl.Controls.Add(this.tblExtFileTemplateControl_colnRowNo);
            this.tblExtFileTemplateControl.Controls.Add(this.tblExtFileTemplateControl_colnGroupNo);
            this.tblExtFileTemplateControl.Controls.Add(this.tblExtFileTemplateControl_colsCondition);
            this.tblExtFileTemplateControl.Controls.Add(this.tblExtFileTemplateControl_colnColumnNo);
            this.tblExtFileTemplateControl.Controls.Add(this.tblExtFileTemplateControl_colnStartPosition);
            this.tblExtFileTemplateControl.Controls.Add(this.tblExtFileTemplateControl_colnEndPosition);
            this.tblExtFileTemplateControl.Controls.Add(this.tblExtFileTemplateControl_colsControlString);
            this.tblExtFileTemplateControl.Controls.Add(this.tblExtFileTemplateControl_colsDestinationColumn);
            this.tblExtFileTemplateControl.Controls.Add(this.tblExtFileTemplateControl_colnNoOfLines);
            resources.ApplyResources(this.tblExtFileTemplateControl, "tblExtFileTemplateControl");
            this.tblExtFileTemplateControl.Name = "tblExtFileTemplateControl";
            this.tblExtFileTemplateControl.NamedProperties.Put("DefaultOrderBy", "");
            this.tblExtFileTemplateControl.NamedProperties.Put("DefaultWhere", "");
            this.tblExtFileTemplateControl.NamedProperties.Put("LogicalUnit", "ExtFileTemplateControl");
            this.tblExtFileTemplateControl.NamedProperties.Put("PackageName", "EXT_FILE_TEMPLATE_CONTROL_API");
            this.tblExtFileTemplateControl.NamedProperties.Put("ResizeableChildObject", "LLMM");
            this.tblExtFileTemplateControl.NamedProperties.Put("ViewName", "EXT_FILE_TEMPLATE_CONTROL");
            this.tblExtFileTemplateControl.NamedProperties.Put("Warnings", "FALSE");
            this.tblExtFileTemplateControl.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblExtFileTemplateControl_WindowActions);
            this.tblExtFileTemplateControl.Controls.SetChildIndex(this.tblExtFileTemplateControl_colnNoOfLines, 0);
            this.tblExtFileTemplateControl.Controls.SetChildIndex(this.tblExtFileTemplateControl_colsDestinationColumn, 0);
            this.tblExtFileTemplateControl.Controls.SetChildIndex(this.tblExtFileTemplateControl_colsControlString, 0);
            this.tblExtFileTemplateControl.Controls.SetChildIndex(this.tblExtFileTemplateControl_colnEndPosition, 0);
            this.tblExtFileTemplateControl.Controls.SetChildIndex(this.tblExtFileTemplateControl_colnStartPosition, 0);
            this.tblExtFileTemplateControl.Controls.SetChildIndex(this.tblExtFileTemplateControl_colnColumnNo, 0);
            this.tblExtFileTemplateControl.Controls.SetChildIndex(this.tblExtFileTemplateControl_colsCondition, 0);
            this.tblExtFileTemplateControl.Controls.SetChildIndex(this.tblExtFileTemplateControl_colnGroupNo, 0);
            this.tblExtFileTemplateControl.Controls.SetChildIndex(this.tblExtFileTemplateControl_colnRowNo, 0);
            this.tblExtFileTemplateControl.Controls.SetChildIndex(this.tblExtFileTemplateControl_colsRecordTypeId, 0);
            this.tblExtFileTemplateControl.Controls.SetChildIndex(this.tblExtFileTemplateControl_colsFileDirection, 0);
            this.tblExtFileTemplateControl.Controls.SetChildIndex(this.tblExtFileTemplateControl_colxFileType, 0);
            this.tblExtFileTemplateControl.Controls.SetChildIndex(this.tblExtFileTemplateControl_colxFileTemplateId, 0);
            // 
            // tblExtFileTemplateControl_colxFileTemplateId
            // 
            resources.ApplyResources(this.tblExtFileTemplateControl_colxFileTemplateId, "tblExtFileTemplateControl_colxFileTemplateId");
            this.tblExtFileTemplateControl_colxFileTemplateId.MaxLength = 30;
            this.tblExtFileTemplateControl_colxFileTemplateId.Name = "tblExtFileTemplateControl_colxFileTemplateId";
            this.tblExtFileTemplateControl_colxFileTemplateId.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTemplateControl_colxFileTemplateId.NamedProperties.Put("FieldFlags", "67");
            this.tblExtFileTemplateControl_colxFileTemplateId.NamedProperties.Put("LovReference", "");
            this.tblExtFileTemplateControl_colxFileTemplateId.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTemplateControl_colxFileTemplateId.NamedProperties.Put("SqlColumn", "FILE_TEMPLATE_ID");
            this.tblExtFileTemplateControl_colxFileTemplateId.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTemplateControl_colxFileTemplateId.Position = 3;
            // 
            // tblExtFileTemplateControl_colxFileType
            // 
            resources.ApplyResources(this.tblExtFileTemplateControl_colxFileType, "tblExtFileTemplateControl_colxFileType");
            this.tblExtFileTemplateControl_colxFileType.MaxLength = 30;
            this.tblExtFileTemplateControl_colxFileType.Name = "tblExtFileTemplateControl_colxFileType";
            this.tblExtFileTemplateControl_colxFileType.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTemplateControl_colxFileType.NamedProperties.Put("FieldFlags", "262");
            this.tblExtFileTemplateControl_colxFileType.NamedProperties.Put("LovReference", "EXT_FILE_MODULE_NAME");
            this.tblExtFileTemplateControl_colxFileType.NamedProperties.Put("SqlColumn", "FILE_TYPE");
            this.tblExtFileTemplateControl_colxFileType.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTemplateControl_colxFileType.Position = 4;
            this.tblExtFileTemplateControl_colxFileType.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblExtFileTemplateControl_colxFileType_WindowActions);
            // 
            // tblExtFileTemplateControl_colsFileDirection
            // 
            resources.ApplyResources(this.tblExtFileTemplateControl_colsFileDirection, "tblExtFileTemplateControl_colsFileDirection");
            this.tblExtFileTemplateControl_colsFileDirection.MaxLength = 200;
            this.tblExtFileTemplateControl_colsFileDirection.Name = "tblExtFileTemplateControl_colsFileDirection";
            this.tblExtFileTemplateControl_colsFileDirection.NamedProperties.Put("EnumerateMethod", "FILE_DIRECTION_API.Enumerate");
            this.tblExtFileTemplateControl_colsFileDirection.NamedProperties.Put("FieldFlags", "71");
            this.tblExtFileTemplateControl_colsFileDirection.NamedProperties.Put("LovReference", "");
            this.tblExtFileTemplateControl_colsFileDirection.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTemplateControl_colsFileDirection.NamedProperties.Put("SqlColumn", "FILE_DIRECTION");
            this.tblExtFileTemplateControl_colsFileDirection.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTemplateControl_colsFileDirection.Position = 5;
            this.tblExtFileTemplateControl_colsFileDirection.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblExtFileTemplateControl_colsFileDirection_WindowActions);
            // 
            // tblExtFileTemplateControl_colsRecordTypeId
            // 
            this.tblExtFileTemplateControl_colsRecordTypeId.MaxLength = 20;
            this.tblExtFileTemplateControl_colsRecordTypeId.Name = "tblExtFileTemplateControl_colsRecordTypeId";
            this.tblExtFileTemplateControl_colsRecordTypeId.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTemplateControl_colsRecordTypeId.NamedProperties.Put("FieldFlags", "295");
            this.tblExtFileTemplateControl_colsRecordTypeId.NamedProperties.Put("LovReference", "EXT_FILE_TEMPLATE_DETAIL_REC(FILE_TYPE,FILE_TEMPLATE_ID)");
            this.tblExtFileTemplateControl_colsRecordTypeId.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTemplateControl_colsRecordTypeId.NamedProperties.Put("SqlColumn", "RECORD_TYPE_ID");
            this.tblExtFileTemplateControl_colsRecordTypeId.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTemplateControl_colsRecordTypeId.Position = 6;
            resources.ApplyResources(this.tblExtFileTemplateControl_colsRecordTypeId, "tblExtFileTemplateControl_colsRecordTypeId");
            this.tblExtFileTemplateControl_colsRecordTypeId.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblExtFileTemplateControl_colsRecordTypeId_WindowActions);
            // 
            // tblExtFileTemplateControl_colnRowNo
            // 
            this.tblExtFileTemplateControl_colnRowNo.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTemplateControl_colnRowNo.Name = "tblExtFileTemplateControl_colnRowNo";
            this.tblExtFileTemplateControl_colnRowNo.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTemplateControl_colnRowNo.NamedProperties.Put("FieldFlags", "167");
            this.tblExtFileTemplateControl_colnRowNo.NamedProperties.Put("LovReference", "");
            this.tblExtFileTemplateControl_colnRowNo.NamedProperties.Put("SqlColumn", "ROW_NO");
            this.tblExtFileTemplateControl_colnRowNo.Position = 7;
            resources.ApplyResources(this.tblExtFileTemplateControl_colnRowNo, "tblExtFileTemplateControl_colnRowNo");
            this.tblExtFileTemplateControl_colnRowNo.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblExtFileTemplateControl_colnRowNo_WindowActions);
            // 
            // tblExtFileTemplateControl_colnGroupNo
            // 
            this.tblExtFileTemplateControl_colnGroupNo.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTemplateControl_colnGroupNo.Name = "tblExtFileTemplateControl_colnGroupNo";
            this.tblExtFileTemplateControl_colnGroupNo.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTemplateControl_colnGroupNo.NamedProperties.Put("FieldFlags", "295");
            this.tblExtFileTemplateControl_colnGroupNo.NamedProperties.Put("LovReference", "");
            this.tblExtFileTemplateControl_colnGroupNo.NamedProperties.Put("SqlColumn", "GROUP_NO");
            this.tblExtFileTemplateControl_colnGroupNo.Position = 8;
            resources.ApplyResources(this.tblExtFileTemplateControl_colnGroupNo, "tblExtFileTemplateControl_colnGroupNo");
            this.tblExtFileTemplateControl_colnGroupNo.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblExtFileTemplateControl_colnGroupNo_WindowActions);
            // 
            // tblExtFileTemplateControl_colsCondition
            // 
            this.tblExtFileTemplateControl_colsCondition.MaxLength = 200;
            this.tblExtFileTemplateControl_colsCondition.Name = "tblExtFileTemplateControl_colsCondition";
            this.tblExtFileTemplateControl_colsCondition.NamedProperties.Put("EnumerateMethod", "EXT_CONDITION_API.Enumerate");
            this.tblExtFileTemplateControl_colsCondition.NamedProperties.Put("FieldFlags", "295");
            this.tblExtFileTemplateControl_colsCondition.NamedProperties.Put("LovReference", "");
            this.tblExtFileTemplateControl_colsCondition.NamedProperties.Put("SqlColumn", "CONDITION");
            this.tblExtFileTemplateControl_colsCondition.Position = 9;
            resources.ApplyResources(this.tblExtFileTemplateControl_colsCondition, "tblExtFileTemplateControl_colsCondition");
            this.tblExtFileTemplateControl_colsCondition.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblExtFileTemplateControl_colsCondition_WindowActions);
            // 
            // tblExtFileTemplateControl_colnColumnNo
            // 
            this.tblExtFileTemplateControl_colnColumnNo.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTemplateControl_colnColumnNo.Name = "tblExtFileTemplateControl_colnColumnNo";
            this.tblExtFileTemplateControl_colnColumnNo.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTemplateControl_colnColumnNo.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTemplateControl_colnColumnNo.NamedProperties.Put("LovReference", "");
            this.tblExtFileTemplateControl_colnColumnNo.NamedProperties.Put("SqlColumn", "COLUMN_NO");
            this.tblExtFileTemplateControl_colnColumnNo.Position = 10;
            resources.ApplyResources(this.tblExtFileTemplateControl_colnColumnNo, "tblExtFileTemplateControl_colnColumnNo");
            this.tblExtFileTemplateControl_colnColumnNo.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblExtFileTemplateControl_colnColumnNo_WindowActions);
            // 
            // tblExtFileTemplateControl_colnStartPosition
            // 
            this.tblExtFileTemplateControl_colnStartPosition.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTemplateControl_colnStartPosition.Name = "tblExtFileTemplateControl_colnStartPosition";
            this.tblExtFileTemplateControl_colnStartPosition.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTemplateControl_colnStartPosition.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTemplateControl_colnStartPosition.NamedProperties.Put("LovReference", "");
            this.tblExtFileTemplateControl_colnStartPosition.NamedProperties.Put("SqlColumn", "START_POSITION");
            this.tblExtFileTemplateControl_colnStartPosition.Position = 11;
            resources.ApplyResources(this.tblExtFileTemplateControl_colnStartPosition, "tblExtFileTemplateControl_colnStartPosition");
            this.tblExtFileTemplateControl_colnStartPosition.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblExtFileTemplateControl_colnStartPosition_WindowActions);
            // 
            // tblExtFileTemplateControl_colnEndPosition
            // 
            this.tblExtFileTemplateControl_colnEndPosition.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTemplateControl_colnEndPosition.Name = "tblExtFileTemplateControl_colnEndPosition";
            this.tblExtFileTemplateControl_colnEndPosition.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTemplateControl_colnEndPosition.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTemplateControl_colnEndPosition.NamedProperties.Put("LovReference", "");
            this.tblExtFileTemplateControl_colnEndPosition.NamedProperties.Put("SqlColumn", "END_POSITION");
            this.tblExtFileTemplateControl_colnEndPosition.Position = 12;
            resources.ApplyResources(this.tblExtFileTemplateControl_colnEndPosition, "tblExtFileTemplateControl_colnEndPosition");
            this.tblExtFileTemplateControl_colnEndPosition.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblExtFileTemplateControl_colnEndPosition_WindowActions);
            // 
            // tblExtFileTemplateControl_colsControlString
            // 
            this.tblExtFileTemplateControl_colsControlString.Name = "tblExtFileTemplateControl_colsControlString";
            this.tblExtFileTemplateControl_colsControlString.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTemplateControl_colsControlString.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTemplateControl_colsControlString.NamedProperties.Put("LovReference", "");
            this.tblExtFileTemplateControl_colsControlString.NamedProperties.Put("SqlColumn", "CONTROL_STRING");
            this.tblExtFileTemplateControl_colsControlString.Position = 13;
            resources.ApplyResources(this.tblExtFileTemplateControl_colsControlString, "tblExtFileTemplateControl_colsControlString");
            this.tblExtFileTemplateControl_colsControlString.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblExtFileTemplateControl_colsControlString_WindowActions);
            // 
            // tblExtFileTemplateControl_colsDestinationColumn
            // 
            this.tblExtFileTemplateControl_colsDestinationColumn.Name = "tblExtFileTemplateControl_colsDestinationColumn";
            this.tblExtFileTemplateControl_colsDestinationColumn.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTemplateControl_colsDestinationColumn.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTemplateControl_colsDestinationColumn.NamedProperties.Put("LovReference", "EXT_FILE_TEMPLATE_DETAIL_DEST(FILE_TYPE,RECORD_TYPE_ID,FILE_TEMPLATE_ID)");
            this.tblExtFileTemplateControl_colsDestinationColumn.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTemplateControl_colsDestinationColumn.NamedProperties.Put("SqlColumn", "DESTINATION_COLUMN");
            this.tblExtFileTemplateControl_colsDestinationColumn.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTemplateControl_colsDestinationColumn.Position = 14;
            resources.ApplyResources(this.tblExtFileTemplateControl_colsDestinationColumn, "tblExtFileTemplateControl_colsDestinationColumn");
            this.tblExtFileTemplateControl_colsDestinationColumn.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblExtFileTemplateControl_colsDestinationColumn_WindowActions);
            // 
            // tblExtFileTemplateControl_colnNoOfLines
            // 
            this.tblExtFileTemplateControl_colnNoOfLines.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTemplateControl_colnNoOfLines.Name = "tblExtFileTemplateControl_colnNoOfLines";
            this.tblExtFileTemplateControl_colnNoOfLines.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTemplateControl_colnNoOfLines.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTemplateControl_colnNoOfLines.NamedProperties.Put("LovReference", "");
            this.tblExtFileTemplateControl_colnNoOfLines.NamedProperties.Put("SqlColumn", "NO_OF_LINES");
            this.tblExtFileTemplateControl_colnNoOfLines.Position = 15;
            resources.ApplyResources(this.tblExtFileTemplateControl_colnNoOfLines, "tblExtFileTemplateControl_colnNoOfLines");
            // 
            // frmExternalFileTemplateControl
            // 
            this.AutoScaleBaseDpi = new System.Drawing.Size(106, 106);
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.tblExtFileTemplateControl);
            this.Controls.Add(this.dfsFileDirectionDb);
            this.Controls.Add(this.dfsFileDirection);
            this.Controls.Add(this.dfExtFileTypeDescription);
            this.Controls.Add(this.dfsFileType);
            this.Controls.Add(this.cbSystemDefined);
            this.Controls.Add(this.dfExtFileTemplateDescription);
            this.Controls.Add(this.dfsFileTemplateId);
            this.Controls.Add(this.labeldfsFileDirection);
            this.Controls.Add(this.labeldfExtFileTypeDescription);
            this.Controls.Add(this.labeldfsFileType);
            this.Controls.Add(this.labeldfExtFileTemplateDescription);
            this.Controls.Add(this.labeldfsFileTemplateId);
            this.Name = "frmExternalFileTemplateControl";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "ExtFileTemplateDir");
            this.NamedProperties.Put("PackageName", "EXT_FILE_TEMPLATE_DIR_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "1");
            this.NamedProperties.Put("ViewName", "EXT_FILE_TEMPLATE_DIR");
            this.NamedProperties.Put("Warnings", "TRUE");
            this.tblExtFileTemplateControl.ResumeLayout(false);
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

        public cChildTableFinBase tblExtFileTemplateControl;
        protected cColumn tblExtFileTemplateControl_colxFileTemplateId;
        protected cColumn tblExtFileTemplateControl_colxFileType;
        protected cLookupColumn tblExtFileTemplateControl_colsFileDirection;
        protected cColumn tblExtFileTemplateControl_colsRecordTypeId;
        protected cColumn tblExtFileTemplateControl_colnRowNo;
        protected cColumn tblExtFileTemplateControl_colnGroupNo;
        protected cLookupColumn tblExtFileTemplateControl_colsCondition;
        protected cColumn tblExtFileTemplateControl_colnColumnNo;
        protected cColumn tblExtFileTemplateControl_colnStartPosition;
        protected cColumn tblExtFileTemplateControl_colnEndPosition;
        protected cColumn tblExtFileTemplateControl_colsControlString;
        protected cColumn tblExtFileTemplateControl_colsDestinationColumn;
        protected cColumn tblExtFileTemplateControl_colnNoOfLines;
		
	}
}
