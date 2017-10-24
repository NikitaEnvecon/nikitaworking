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
	
	public partial class tbwExternalFileDetail
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cColumn colsFileTemplateId;
		public cColumn colExtFileTemplateSeparated;
		public cColumn colRowNo;
		public cColumn colsFileType;
		public cColumn colsRecordTypeId;
		public cColumn colsColumnId;
		public cColumn colsDescription;
		public cColumn colsDataType;
		public cColumn colnColumnNo;
		public cColumn colnStartPosition;
		public cColumn colnEndPosition;
		public cColumn DetailFunction;
		public cColumn colsDateFormat;
		public cColumn colnDenominator;
		public cCheckBoxColumn colControlColumn;
		public cColumn colsDestinationColumn;
		public cColumn colExtFileTemplateSystem_Defined;
		public cCheckBoxColumn colHideColumn;
		public cColumn colnColumnSort;
		public cColumn colnMaxLength;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwExternalFileDetail));
            this.menuTbwMethods_menuFunction__Details___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.colsFileTemplateId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colExtFileTemplateSeparated = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colRowNo = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsFileType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsRecordTypeId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsColumnId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsDataType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colnColumnNo = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colnStartPosition = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colnEndPosition = new Ifs.Fnd.ApplicationForms.cColumn();
            this.DetailFunction = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsDateFormat = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colnDenominator = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colControlColumn = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.colsDestinationColumn = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colExtFileTemplateSystem_Defined = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colHideColumn = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.colnColumnSort = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colnMaxLength = new Ifs.Fnd.ApplicationForms.cColumn();
            this.menuTbwMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_Function = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuTbwMethods.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuTbwMethods_menuFunction__Details___);
            this.commandManager.ContextMenus.Add(this.menuTbwMethods);
            // 
            // menuTbwMethods_menuFunction__Details___
            // 
            resources.ApplyResources(this.menuTbwMethods_menuFunction__Details___, "menuTbwMethods_menuFunction__Details___");
            this.menuTbwMethods_menuFunction__Details___.Name = "menuTbwMethods_menuFunction__Details___";
            this.menuTbwMethods_menuFunction__Details___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Function_Execute);
            this.menuTbwMethods_menuFunction__Details___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Function_Inquire);
            // 
            // colsFileTemplateId
            // 
            resources.ApplyResources(this.colsFileTemplateId, "colsFileTemplateId");
            this.colsFileTemplateId.MaxLength = 30;
            this.colsFileTemplateId.Name = "colsFileTemplateId";
            this.colsFileTemplateId.NamedProperties.Put("EnumerateMethod", "");
            this.colsFileTemplateId.NamedProperties.Put("FieldFlags", "67");
            this.colsFileTemplateId.NamedProperties.Put("LovReference", "EXT_FILE_TEMPLATE");
            this.colsFileTemplateId.NamedProperties.Put("SqlColumn", "FILE_TEMPLATE_ID");
            this.colsFileTemplateId.Position = 3;
            this.colsFileTemplateId.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsFileTemplateId_WindowActions);
            // 
            // colExtFileTemplateSeparated
            // 
            resources.ApplyResources(this.colExtFileTemplateSeparated, "colExtFileTemplateSeparated");
            this.colExtFileTemplateSeparated.MaxLength = 2000;
            this.colExtFileTemplateSeparated.Name = "colExtFileTemplateSeparated";
            this.colExtFileTemplateSeparated.NamedProperties.Put("EnumerateMethod", "");
            this.colExtFileTemplateSeparated.NamedProperties.Put("FieldFlags", "272");
            this.colExtFileTemplateSeparated.NamedProperties.Put("LovReference", "");
            this.colExtFileTemplateSeparated.NamedProperties.Put("ParentName", "colsFileTemplateId");
            this.colExtFileTemplateSeparated.NamedProperties.Put("ResizeableChildObject", "");
            this.colExtFileTemplateSeparated.NamedProperties.Put("SqlColumn", "EXT_FILE_TEMPLATE_API.Get_Separated(FILE_TEMPLATE_ID)");
            this.colExtFileTemplateSeparated.NamedProperties.Put("ValidateMethod", "");
            this.colExtFileTemplateSeparated.Position = 4;
            this.colExtFileTemplateSeparated.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colExtFileTemplateSeparated_WindowActions);
            // 
            // colRowNo
            // 
            this.colRowNo.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.colRowNo, "colRowNo");
            this.colRowNo.Name = "colRowNo";
            this.colRowNo.NamedProperties.Put("EnumerateMethod", "");
            this.colRowNo.NamedProperties.Put("FieldFlags", "130");
            this.colRowNo.NamedProperties.Put("LovReference", "");
            this.colRowNo.NamedProperties.Put("ResizeableChildObject", "");
            this.colRowNo.NamedProperties.Put("SqlColumn", "ROW_NO");
            this.colRowNo.NamedProperties.Put("ValidateMethod", "");
            this.colRowNo.Position = 5;
            this.colRowNo.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colRowNo_WindowActions);
            // 
            // colsFileType
            // 
            resources.ApplyResources(this.colsFileType, "colsFileType");
            this.colsFileType.MaxLength = 30;
            this.colsFileType.Name = "colsFileType";
            this.colsFileType.NamedProperties.Put("EnumerateMethod", "");
            this.colsFileType.NamedProperties.Put("FieldFlags", "262");
            this.colsFileType.NamedProperties.Put("LovReference", "");
            this.colsFileType.NamedProperties.Put("ResizeableChildObject", "");
            this.colsFileType.NamedProperties.Put("SqlColumn", "FILE_TYPE");
            this.colsFileType.NamedProperties.Put("ValidateMethod", "");
            this.colsFileType.Position = 6;
            this.colsFileType.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsFileType_WindowActions);
            // 
            // colsRecordTypeId
            // 
            this.colsRecordTypeId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsRecordTypeId.MaxLength = 20;
            this.colsRecordTypeId.Name = "colsRecordTypeId";
            this.colsRecordTypeId.NamedProperties.Put("EnumerateMethod", "");
            this.colsRecordTypeId.NamedProperties.Put("FieldFlags", "294");
            this.colsRecordTypeId.NamedProperties.Put("LovReference", "EXT_FILE_TYPE_REC(FILE_TYPE)");
            this.colsRecordTypeId.NamedProperties.Put("ResizeableChildObject", "");
            this.colsRecordTypeId.NamedProperties.Put("SqlColumn", "RECORD_TYPE_ID");
            this.colsRecordTypeId.NamedProperties.Put("ValidateMethod", "");
            this.colsRecordTypeId.Position = 7;
            resources.ApplyResources(this.colsRecordTypeId, "colsRecordTypeId");
            this.colsRecordTypeId.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsRecordTypeId_WindowActions);
            // 
            // colsColumnId
            // 
            this.colsColumnId.MaxLength = 30;
            this.colsColumnId.Name = "colsColumnId";
            this.colsColumnId.NamedProperties.Put("EnumerateMethod", "");
            this.colsColumnId.NamedProperties.Put("FieldFlags", "294");
            this.colsColumnId.NamedProperties.Put("LovReference", "EXT_FILE_TYPE_REC_COLUMN(FILE_TYPE,RECORD_TYPE_ID)");
            this.colsColumnId.NamedProperties.Put("ResizeableChildObject", "");
            this.colsColumnId.NamedProperties.Put("SqlColumn", "COLUMN_ID");
            this.colsColumnId.NamedProperties.Put("ValidateMethod", "");
            this.colsColumnId.Position = 8;
            resources.ApplyResources(this.colsColumnId, "colsColumnId");
            this.colsColumnId.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsColumnId_WindowActions);
            // 
            // colsDescription
            // 
            this.colsDescription.MaxLength = 2000;
            this.colsDescription.Name = "colsDescription";
            this.colsDescription.NamedProperties.Put("EnumerateMethod", "");
            this.colsDescription.NamedProperties.Put("LovReference", "");
            this.colsDescription.NamedProperties.Put("ParentName", "colsColumnId");
            this.colsDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.colsDescription.NamedProperties.Put("SqlColumn", "EXT_FILE_TYPE_REC_COLUMN_API.Get_Description(FILE_TYPE,RECORD_TYPE_ID,COLUMN_ID)");
            this.colsDescription.NamedProperties.Put("ValidateMethod", "");
            this.colsDescription.Position = 9;
            resources.ApplyResources(this.colsDescription, "colsDescription");
            this.colsDescription.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsDescription_WindowActions);
            // 
            // colsDataType
            // 
            this.colsDataType.MaxLength = 2000;
            this.colsDataType.Name = "colsDataType";
            this.colsDataType.NamedProperties.Put("EnumerateMethod", "");
            this.colsDataType.NamedProperties.Put("LovReference", "");
            this.colsDataType.NamedProperties.Put("ParentName", "colsColumnId");
            this.colsDataType.NamedProperties.Put("ResizeableChildObject", "");
            this.colsDataType.NamedProperties.Put("SqlColumn", "EXT_FILE_TYPE_REC_COLUMN_API.Get_Data_Type(file_type,record_type_id,COLUMN_ID)");
            this.colsDataType.NamedProperties.Put("ValidateMethod", "");
            this.colsDataType.Position = 10;
            resources.ApplyResources(this.colsDataType, "colsDataType");
            this.colsDataType.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsDataType_WindowActions);
            // 
            // colnColumnNo
            // 
            this.colnColumnNo.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colnColumnNo.Name = "colnColumnNo";
            this.colnColumnNo.NamedProperties.Put("EnumerateMethod", "");
            this.colnColumnNo.NamedProperties.Put("FieldFlags", "294");
            this.colnColumnNo.NamedProperties.Put("LovReference", "");
            this.colnColumnNo.NamedProperties.Put("ResizeableChildObject", "");
            this.colnColumnNo.NamedProperties.Put("SqlColumn", "COLUMN_NO");
            this.colnColumnNo.NamedProperties.Put("ValidateMethod", "");
            this.colnColumnNo.Position = 11;
            resources.ApplyResources(this.colnColumnNo, "colnColumnNo");
            this.colnColumnNo.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colnColumnNo_WindowActions);
            // 
            // colnStartPosition
            // 
            this.colnStartPosition.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colnStartPosition.Name = "colnStartPosition";
            this.colnStartPosition.NamedProperties.Put("EnumerateMethod", "");
            this.colnStartPosition.NamedProperties.Put("FieldFlags", "294");
            this.colnStartPosition.NamedProperties.Put("LovReference", "");
            this.colnStartPosition.NamedProperties.Put("SqlColumn", "START_POSITION");
            this.colnStartPosition.NamedProperties.Put("ValidateMethod", "");
            this.colnStartPosition.Position = 12;
            resources.ApplyResources(this.colnStartPosition, "colnStartPosition");
            this.colnStartPosition.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colnStartPosition_WindowActions);
            // 
            // colnEndPosition
            // 
            this.colnEndPosition.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colnEndPosition.Name = "colnEndPosition";
            this.colnEndPosition.NamedProperties.Put("EnumerateMethod", "");
            this.colnEndPosition.NamedProperties.Put("FieldFlags", "294");
            this.colnEndPosition.NamedProperties.Put("LovReference", "");
            this.colnEndPosition.NamedProperties.Put("SqlColumn", "END_POSITION");
            this.colnEndPosition.NamedProperties.Put("ValidateMethod", "");
            this.colnEndPosition.Position = 13;
            resources.ApplyResources(this.colnEndPosition, "colnEndPosition");
            this.colnEndPosition.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colnEndPosition_WindowActions);
            // 
            // DetailFunction
            // 
            this.DetailFunction.Name = "DetailFunction";
            this.DetailFunction.NamedProperties.Put("EnumerateMethod", "");
            this.DetailFunction.NamedProperties.Put("LovReference", "");
            this.DetailFunction.NamedProperties.Put("ResizeableChildObject", "");
            this.DetailFunction.NamedProperties.Put("SqlColumn", "EXT_FILE_TEMPLATE_DETAIL_API.Display_Detail_Function( FILE_TEMPLATE_ID, ROW_NO )");
            this.DetailFunction.NamedProperties.Put("ValidateMethod", "");
            this.DetailFunction.Position = 14;
            resources.ApplyResources(this.DetailFunction, "DetailFunction");
            // 
            // colsDateFormat
            // 
            this.colsDateFormat.MaxLength = 20;
            this.colsDateFormat.Name = "colsDateFormat";
            this.colsDateFormat.NamedProperties.Put("EnumerateMethod", "");
            this.colsDateFormat.NamedProperties.Put("FieldFlags", "294");
            this.colsDateFormat.NamedProperties.Put("LovReference", "");
            this.colsDateFormat.NamedProperties.Put("SqlColumn", "DATE_FORMAT");
            this.colsDateFormat.NamedProperties.Put("ValidateMethod", "");
            this.colsDateFormat.Position = 15;
            resources.ApplyResources(this.colsDateFormat, "colsDateFormat");
            this.colsDateFormat.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsDateFormat_WindowActions);
            // 
            // colnDenominator
            // 
            this.colnDenominator.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colnDenominator.Name = "colnDenominator";
            this.colnDenominator.NamedProperties.Put("EnumerateMethod", "");
            this.colnDenominator.NamedProperties.Put("FieldFlags", "294");
            this.colnDenominator.NamedProperties.Put("LovReference", "");
            this.colnDenominator.NamedProperties.Put("SqlColumn", "DENOMINATOR");
            this.colnDenominator.NamedProperties.Put("ValidateMethod", "");
            this.colnDenominator.Position = 16;
            resources.ApplyResources(this.colnDenominator, "colnDenominator");
            this.colnDenominator.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colnDenominator_WindowActions);
            // 
            // colControlColumn
            // 
            this.colControlColumn.Name = "colControlColumn";
            this.colControlColumn.NamedProperties.Put("EnumerateMethod", "");
            this.colControlColumn.NamedProperties.Put("FieldFlags", "294");
            this.colControlColumn.NamedProperties.Put("LovReference", "");
            this.colControlColumn.NamedProperties.Put("SqlColumn", "CONTROL_COLUMN");
            this.colControlColumn.NamedProperties.Put("ValidateMethod", "");
            this.colControlColumn.Position = 17;
            resources.ApplyResources(this.colControlColumn, "colControlColumn");
            // 
            // colsDestinationColumn
            // 
            this.colsDestinationColumn.MaxLength = 2000;
            this.colsDestinationColumn.Name = "colsDestinationColumn";
            this.colsDestinationColumn.NamedProperties.Put("EnumerateMethod", "");
            this.colsDestinationColumn.NamedProperties.Put("FieldFlags", "304");
            this.colsDestinationColumn.NamedProperties.Put("LovReference", "");
            this.colsDestinationColumn.NamedProperties.Put("ParentName", "colsColumnId");
            this.colsDestinationColumn.NamedProperties.Put("ResizeableChildObject", "");
            this.colsDestinationColumn.NamedProperties.Put("SqlColumn", "EXT_FILE_TYPE_REC_COLUMN_API.Get_Destination_Column(FILE_TYPE,RECORD_TYPE_ID,COLU" +
                    "MN_ID)");
            this.colsDestinationColumn.NamedProperties.Put("ValidateMethod", "");
            this.colsDestinationColumn.Position = 18;
            resources.ApplyResources(this.colsDestinationColumn, "colsDestinationColumn");
            this.colsDestinationColumn.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsDestinationColumn_WindowActions);
            // 
            // colExtFileTemplateSystem_Defined
            // 
            resources.ApplyResources(this.colExtFileTemplateSystem_Defined, "colExtFileTemplateSystem_Defined");
            this.colExtFileTemplateSystem_Defined.MaxLength = 2000;
            this.colExtFileTemplateSystem_Defined.Name = "colExtFileTemplateSystem_Defined";
            this.colExtFileTemplateSystem_Defined.NamedProperties.Put("EnumerateMethod", "");
            this.colExtFileTemplateSystem_Defined.NamedProperties.Put("FieldFlags", "272");
            this.colExtFileTemplateSystem_Defined.NamedProperties.Put("LovReference", "");
            this.colExtFileTemplateSystem_Defined.NamedProperties.Put("SqlColumn", "EXT_FILE_TEMPLATE_API.Get_System_Defined(FILE_TEMPLATE_ID)");
            this.colExtFileTemplateSystem_Defined.NamedProperties.Put("ValidateMethod", "");
            this.colExtFileTemplateSystem_Defined.Position = 19;
            // 
            // colHideColumn
            // 
            this.colHideColumn.Name = "colHideColumn";
            this.colHideColumn.NamedProperties.Put("EnumerateMethod", "");
            this.colHideColumn.NamedProperties.Put("FieldFlags", "294");
            this.colHideColumn.NamedProperties.Put("LovReference", "");
            this.colHideColumn.NamedProperties.Put("ResizeableChildObject", "");
            this.colHideColumn.NamedProperties.Put("SqlColumn", "HIDE_COLUMN");
            this.colHideColumn.NamedProperties.Put("ValidateMethod", "");
            this.colHideColumn.Position = 20;
            resources.ApplyResources(this.colHideColumn, "colHideColumn");
            // 
            // colnColumnSort
            // 
            this.colnColumnSort.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colnColumnSort.Name = "colnColumnSort";
            this.colnColumnSort.NamedProperties.Put("EnumerateMethod", "");
            this.colnColumnSort.NamedProperties.Put("FieldFlags", "294");
            this.colnColumnSort.NamedProperties.Put("LovReference", "");
            this.colnColumnSort.NamedProperties.Put("SqlColumn", "COLUMN_SORT");
            this.colnColumnSort.Position = 21;
            resources.ApplyResources(this.colnColumnSort, "colnColumnSort");
            // 
            // colnMaxLength
            // 
            this.colnMaxLength.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colnMaxLength.Name = "colnMaxLength";
            this.colnMaxLength.NamedProperties.Put("EnumerateMethod", "");
            this.colnMaxLength.NamedProperties.Put("FieldFlags", "294");
            this.colnMaxLength.NamedProperties.Put("LovReference", "");
            this.colnMaxLength.NamedProperties.Put("SqlColumn", "MAX_LENGTH");
            this.colnMaxLength.Position = 22;
            resources.ApplyResources(this.colnMaxLength, "colnMaxLength");
            // 
            // menuTbwMethods
            // 
            this.menuTbwMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_Function});
            this.menuTbwMethods.Name = "menuTbwMethods";
            resources.ApplyResources(this.menuTbwMethods, "menuTbwMethods");
            // 
            // menuItem_Function
            // 
            this.menuItem_Function.Command = this.menuTbwMethods_menuFunction__Details___;
            this.menuItem_Function.Name = "menuItem_Function";
            resources.ApplyResources(this.menuItem_Function, "menuItem_Function");
            this.menuItem_Function.Text = "Function &Details...";
            // 
            // tbwExternalFileDetail
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colsFileTemplateId);
            this.Controls.Add(this.colExtFileTemplateSeparated);
            this.Controls.Add(this.colRowNo);
            this.Controls.Add(this.colsFileType);
            this.Controls.Add(this.colsRecordTypeId);
            this.Controls.Add(this.colsColumnId);
            this.Controls.Add(this.colsDescription);
            this.Controls.Add(this.colsDataType);
            this.Controls.Add(this.colnColumnNo);
            this.Controls.Add(this.colnStartPosition);
            this.Controls.Add(this.colnEndPosition);
            this.Controls.Add(this.DetailFunction);
            this.Controls.Add(this.colsDateFormat);
            this.Controls.Add(this.colnDenominator);
            this.Controls.Add(this.colControlColumn);
            this.Controls.Add(this.colsDestinationColumn);
            this.Controls.Add(this.colExtFileTemplateSystem_Defined);
            this.Controls.Add(this.colHideColumn);
            this.Controls.Add(this.colnColumnSort);
            this.Controls.Add(this.colnMaxLength);
            this.Name = "tbwExternalFileDetail";
            this.NamedProperties.Put("DefaultOrderBy", "RECORD_TYPE_ID,NVL(COLUMN_NO,NVL(START_POSITION,99999)),NVL(COLUMN_SORT,99999),CO" +
                    "LUMN_NO,START_POSITION");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "ExtFileTemplateDetail");
            this.NamedProperties.Put("PackageName", "EXT_FILE_TEMPLATE_DETAIL_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "449");
            this.NamedProperties.Put("ViewName", "EXT_FILE_TEMPLATE_DETAIL");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tbwExternalFileDetail_WindowActions);
            this.Controls.SetChildIndex(this.colnMaxLength, 0);
            this.Controls.SetChildIndex(this.colnColumnSort, 0);
            this.Controls.SetChildIndex(this.colHideColumn, 0);
            this.Controls.SetChildIndex(this.colExtFileTemplateSystem_Defined, 0);
            this.Controls.SetChildIndex(this.colsDestinationColumn, 0);
            this.Controls.SetChildIndex(this.colControlColumn, 0);
            this.Controls.SetChildIndex(this.colnDenominator, 0);
            this.Controls.SetChildIndex(this.colsDateFormat, 0);
            this.Controls.SetChildIndex(this.DetailFunction, 0);
            this.Controls.SetChildIndex(this.colnEndPosition, 0);
            this.Controls.SetChildIndex(this.colnStartPosition, 0);
            this.Controls.SetChildIndex(this.colnColumnNo, 0);
            this.Controls.SetChildIndex(this.colsDataType, 0);
            this.Controls.SetChildIndex(this.colsDescription, 0);
            this.Controls.SetChildIndex(this.colsColumnId, 0);
            this.Controls.SetChildIndex(this.colsRecordTypeId, 0);
            this.Controls.SetChildIndex(this.colsFileType, 0);
            this.Controls.SetChildIndex(this.colRowNo, 0);
            this.Controls.SetChildIndex(this.colExtFileTemplateSeparated, 0);
            this.Controls.SetChildIndex(this.colsFileTemplateId, 0);
            this.Controls.SetChildIndex(this.@__colObjversion, 0);
            this.Controls.SetChildIndex(this.@__colObjid, 0);
            this.menuTbwMethods.ResumeLayout(false);
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

        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menuFunction__Details___;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTbwMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Function;
	}
}
