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
	
	public partial class frmExternalFileLogDetail
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		protected cBackgroundText labelccsLoadFileId;
		public cRecListDataField ccsLoadFileId;
		public cDataField dfnSeqNo;
		protected cBackgroundText labeldfsState;
		public cDataField dfsState;
		protected cBackgroundText labeldfdLogDate;
		public cDataField dfdLogDate;
		protected cBackgroundText labeldfsFileType;
		public cDataField dfsFileType;
		protected cBackgroundText labeldfExtFileTypeDescription;
		public cDataField dfExtFileTypeDescription;
		protected cBackgroundText labeldfsFileTemplateId;
		public cDataField dfsFileTemplateId;
		protected cBackgroundText labeldfExtFileTemplateDescription;
		public cDataField dfExtFileTemplateDescription;
        // Bug 73298 Begin - Changed the derived base class.
		// Bug 73298 End.
		protected cBackgroundText labeldfExtFileLoadFile_Direction;
		public cDataField dfExtFileLoadFile_Direction;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExternalFileLogDetail));
            this.labelccsLoadFileId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.ccsLoadFileId = new Ifs.Fnd.ApplicationForms.cRecListDataField();
            this.dfnSeqNo = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsState = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsState = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfdLogDate = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfdLogDate = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsFileType = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsFileType = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfExtFileTypeDescription = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfExtFileTypeDescription = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsFileTemplateId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsFileTemplateId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfExtFileTemplateDescription = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfExtFileTemplateDescription = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfExtFileLoadFile_Direction = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfExtFileLoadFile_Direction = new Ifs.Fnd.ApplicationForms.cDataField();
            this.tblExternalFileLogDetail = new Ifs.Application.Accrul.cChildTableFinBase();
            this.tblExternalFileLogDetail_colnLoadFileId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExternalFileLogDetail_colnSeqNo = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExternalFileLogDetail_colsRowState = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.tblExternalFileLogDetail_colnNoOfRecords = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExternalFileLogDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelccsLoadFileId
            // 
            resources.ApplyResources(this.labelccsLoadFileId, "labelccsLoadFileId");
            this.labelccsLoadFileId.Name = "labelccsLoadFileId";
            // 
            // ccsLoadFileId
            // 
            resources.ApplyResources(this.ccsLoadFileId, "ccsLoadFileId");
            this.ccsLoadFileId.Name = "ccsLoadFileId";
            this.ccsLoadFileId.NamedProperties.Put("DataType", "3");
            this.ccsLoadFileId.NamedProperties.Put("EnumerateMethod", "");
            this.ccsLoadFileId.NamedProperties.Put("FieldFlags", "163");
            this.ccsLoadFileId.NamedProperties.Put("LovReference", "");
            this.ccsLoadFileId.NamedProperties.Put("ResizeableChildObject", "");
            this.ccsLoadFileId.NamedProperties.Put("SqlColumn", "LOAD_FILE_ID");
            this.ccsLoadFileId.NamedProperties.Put("ValidateMethod", "");
            this.ccsLoadFileId.NamedProperties.Put("XDataLength", "Class Default");
            // 
            // dfnSeqNo
            // 
            this.dfnSeqNo.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfnSeqNo, "dfnSeqNo");
            this.dfnSeqNo.Name = "dfnSeqNo";
            this.dfnSeqNo.NamedProperties.Put("EnumerateMethod", "");
            this.dfnSeqNo.NamedProperties.Put("FieldFlags", "131");
            this.dfnSeqNo.NamedProperties.Put("LovReference", "");
            this.dfnSeqNo.NamedProperties.Put("ResizeableChildObject", "");
            this.dfnSeqNo.NamedProperties.Put("SqlColumn", "SEQ_NO");
            this.dfnSeqNo.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsState
            // 
            resources.ApplyResources(this.labeldfsState, "labeldfsState");
            this.labeldfsState.Name = "labeldfsState";
            // 
            // dfsState
            // 
            resources.ApplyResources(this.dfsState, "dfsState");
            this.dfsState.Name = "dfsState";
            this.dfsState.NamedProperties.Put("EnumerateMethod", "");
            this.dfsState.NamedProperties.Put("FieldFlags", "290");
            this.dfsState.NamedProperties.Put("LovReference", "");
            this.dfsState.NamedProperties.Put("ParentName", "ccsLoadFileId");
            this.dfsState.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsState.NamedProperties.Put("SqlColumn", "STATE");
            this.dfsState.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfdLogDate
            // 
            resources.ApplyResources(this.labeldfdLogDate, "labeldfdLogDate");
            this.labeldfdLogDate.Name = "labeldfdLogDate";
            // 
            // dfdLogDate
            // 
            this.dfdLogDate.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.dfdLogDate.Format = "G";
            resources.ApplyResources(this.dfdLogDate, "dfdLogDate");
            this.dfdLogDate.Name = "dfdLogDate";
            this.dfdLogDate.NamedProperties.Put("EnumerateMethod", "");
            this.dfdLogDate.NamedProperties.Put("FieldFlags", "291");
            this.dfdLogDate.NamedProperties.Put("LovReference", "");
            this.dfdLogDate.NamedProperties.Put("ParentName", "ccsLoadFileId");
            this.dfdLogDate.NamedProperties.Put("ResizeableChildObject", "");
            this.dfdLogDate.NamedProperties.Put("SqlColumn", "LOG_DATE");
            this.dfdLogDate.NamedProperties.Put("ValidateMethod", "");
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
            this.dfsFileType.NamedProperties.Put("LovReference", "");
            this.dfsFileType.NamedProperties.Put("ParentName", "ccsLoadFileId");
            this.dfsFileType.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsFileType.NamedProperties.Put("SqlColumn", "Ext_File_Load_API.Get_File_Type(LOAD_FILE_ID)");
            this.dfsFileType.NamedProperties.Put("ValidateMethod", "");
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
            this.dfExtFileTypeDescription.NamedProperties.Put("SqlColumn", "EXT_FILE_TYPE_API.Get_Description(Ext_File_Load_API.Get_File_Type(LOAD_FILE_ID))");
            this.dfExtFileTypeDescription.NamedProperties.Put("ValidateMethod", "");
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
            this.dfsFileTemplateId.NamedProperties.Put("LovReference", "");
            this.dfsFileTemplateId.NamedProperties.Put("ParentName", "ccsLoadFileId");
            this.dfsFileTemplateId.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsFileTemplateId.NamedProperties.Put("SqlColumn", "Ext_File_Load_API.Get_File_Template_Id(LOAD_FILE_ID)");
            this.dfsFileTemplateId.NamedProperties.Put("ValidateMethod", "");
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
            this.dfExtFileTemplateDescription.NamedProperties.Put("FieldFlags", "272");
            this.dfExtFileTemplateDescription.NamedProperties.Put("LovReference", "");
            this.dfExtFileTemplateDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.dfExtFileTemplateDescription.NamedProperties.Put("SqlColumn", "EXT_FILE_TEMPLATE_API.Get_Description(Ext_File_Load_API.Get_File_Template_Id(LOAD" +
                    "_FILE_ID))");
            this.dfExtFileTemplateDescription.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfExtFileLoadFile_Direction
            // 
            resources.ApplyResources(this.labeldfExtFileLoadFile_Direction, "labeldfExtFileLoadFile_Direction");
            this.labeldfExtFileLoadFile_Direction.Name = "labeldfExtFileLoadFile_Direction";
            // 
            // dfExtFileLoadFile_Direction
            // 
            resources.ApplyResources(this.dfExtFileLoadFile_Direction, "dfExtFileLoadFile_Direction");
            this.dfExtFileLoadFile_Direction.Name = "dfExtFileLoadFile_Direction";
            this.dfExtFileLoadFile_Direction.NamedProperties.Put("EnumerateMethod", "");
            this.dfExtFileLoadFile_Direction.NamedProperties.Put("FieldFlags", "304");
            this.dfExtFileLoadFile_Direction.NamedProperties.Put("LovReference", "");
            this.dfExtFileLoadFile_Direction.NamedProperties.Put("ResizeableChildObject", "");
            this.dfExtFileLoadFile_Direction.NamedProperties.Put("SqlColumn", "EXT_FILE_LOAD_API.Get_File_Direction(LOAD_FILE_ID)");
            this.dfExtFileLoadFile_Direction.NamedProperties.Put("ValidateMethod", "");
            // 
            // tblExternalFileLogDetail
            // 
            this.tblExternalFileLogDetail.Controls.Add(this.tblExternalFileLogDetail_colnLoadFileId);
            this.tblExternalFileLogDetail.Controls.Add(this.tblExternalFileLogDetail_colnSeqNo);
            this.tblExternalFileLogDetail.Controls.Add(this.tblExternalFileLogDetail_colsRowState);
            this.tblExternalFileLogDetail.Controls.Add(this.tblExternalFileLogDetail_colnNoOfRecords);
            resources.ApplyResources(this.tblExternalFileLogDetail, "tblExternalFileLogDetail");
            this.tblExternalFileLogDetail.Name = "tblExternalFileLogDetail";
            this.tblExternalFileLogDetail.NamedProperties.Put("DefaultOrderBy", "");
            this.tblExternalFileLogDetail.NamedProperties.Put("DefaultWhere", "");
            this.tblExternalFileLogDetail.NamedProperties.Put("LogicalUnit", "ExtFileLogDetail");
            this.tblExternalFileLogDetail.NamedProperties.Put("PackageName", "EXT_FILE_LOG_DETAIL_API");
            this.tblExternalFileLogDetail.NamedProperties.Put("ResizeableChildObject", "LLMM");
            this.tblExternalFileLogDetail.NamedProperties.Put("SourceFlags", "1");
            this.tblExternalFileLogDetail.NamedProperties.Put("ViewName", "EXT_FILE_LOG_DETAIL");
            this.tblExternalFileLogDetail.NamedProperties.Put("Warnings", "FALSE");
            this.tblExternalFileLogDetail.Controls.SetChildIndex(this.tblExternalFileLogDetail_colnNoOfRecords, 0);
            this.tblExternalFileLogDetail.Controls.SetChildIndex(this.tblExternalFileLogDetail_colsRowState, 0);
            this.tblExternalFileLogDetail.Controls.SetChildIndex(this.tblExternalFileLogDetail_colnSeqNo, 0);
            this.tblExternalFileLogDetail.Controls.SetChildIndex(this.tblExternalFileLogDetail_colnLoadFileId, 0);
            // 
            // tblExternalFileLogDetail_colnLoadFileId
            // 
            this.tblExternalFileLogDetail_colnLoadFileId.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.tblExternalFileLogDetail_colnLoadFileId, "tblExternalFileLogDetail_colnLoadFileId");
            this.tblExternalFileLogDetail_colnLoadFileId.Name = "tblExternalFileLogDetail_colnLoadFileId";
            this.tblExternalFileLogDetail_colnLoadFileId.NamedProperties.Put("EnumerateMethod", "");
            this.tblExternalFileLogDetail_colnLoadFileId.NamedProperties.Put("FieldFlags", "67");
            this.tblExternalFileLogDetail_colnLoadFileId.NamedProperties.Put("LovReference", "");
            this.tblExternalFileLogDetail_colnLoadFileId.NamedProperties.Put("SqlColumn", "LOAD_FILE_ID");
            this.tblExternalFileLogDetail_colnLoadFileId.Position = 3;
            // 
            // tblExternalFileLogDetail_colnSeqNo
            // 
            this.tblExternalFileLogDetail_colnSeqNo.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.tblExternalFileLogDetail_colnSeqNo, "tblExternalFileLogDetail_colnSeqNo");
            this.tblExternalFileLogDetail_colnSeqNo.Name = "tblExternalFileLogDetail_colnSeqNo";
            this.tblExternalFileLogDetail_colnSeqNo.NamedProperties.Put("EnumerateMethod", "");
            this.tblExternalFileLogDetail_colnSeqNo.NamedProperties.Put("FieldFlags", "67");
            this.tblExternalFileLogDetail_colnSeqNo.NamedProperties.Put("LovReference", "EXT_FILE_LOG(LOAD_FILE_ID)");
            this.tblExternalFileLogDetail_colnSeqNo.NamedProperties.Put("SqlColumn", "SEQ_NO");
            this.tblExternalFileLogDetail_colnSeqNo.Position = 4;
            // 
            // tblExternalFileLogDetail_colsRowState
            // 
            this.tblExternalFileLogDetail_colsRowState.MaxLength = 200;
            this.tblExternalFileLogDetail_colsRowState.Name = "tblExternalFileLogDetail_colsRowState";
            this.tblExternalFileLogDetail_colsRowState.NamedProperties.Put("EnumerateMethod", "EXT_FILE_ROW_STATE_API.Enumerate");
            this.tblExternalFileLogDetail_colsRowState.NamedProperties.Put("FieldFlags", "167");
            this.tblExternalFileLogDetail_colsRowState.NamedProperties.Put("LovReference", "");
            this.tblExternalFileLogDetail_colsRowState.NamedProperties.Put("SqlColumn", "ROW_STATE");
            this.tblExternalFileLogDetail_colsRowState.Position = 5;
            resources.ApplyResources(this.tblExternalFileLogDetail_colsRowState, "tblExternalFileLogDetail_colsRowState");
            // 
            // tblExternalFileLogDetail_colnNoOfRecords
            // 
            this.tblExternalFileLogDetail_colnNoOfRecords.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExternalFileLogDetail_colnNoOfRecords.Name = "tblExternalFileLogDetail_colnNoOfRecords";
            this.tblExternalFileLogDetail_colnNoOfRecords.NamedProperties.Put("EnumerateMethod", "");
            this.tblExternalFileLogDetail_colnNoOfRecords.NamedProperties.Put("FieldFlags", "163");
            this.tblExternalFileLogDetail_colnNoOfRecords.NamedProperties.Put("LovReference", "");
            this.tblExternalFileLogDetail_colnNoOfRecords.NamedProperties.Put("SqlColumn", "NO_OF_RECORDS");
            this.tblExternalFileLogDetail_colnNoOfRecords.Position = 6;
            resources.ApplyResources(this.tblExternalFileLogDetail_colnNoOfRecords, "tblExternalFileLogDetail_colnNoOfRecords");
            // 
            // frmExternalFileLogDetail
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.dfExtFileLoadFile_Direction);
            this.Controls.Add(this.tblExternalFileLogDetail);
            this.Controls.Add(this.dfExtFileTemplateDescription);
            this.Controls.Add(this.dfsFileTemplateId);
            this.Controls.Add(this.dfExtFileTypeDescription);
            this.Controls.Add(this.dfsFileType);
            this.Controls.Add(this.dfdLogDate);
            this.Controls.Add(this.dfsState);
            this.Controls.Add(this.dfnSeqNo);
            this.Controls.Add(this.ccsLoadFileId);
            this.Controls.Add(this.labeldfExtFileLoadFile_Direction);
            this.Controls.Add(this.labeldfExtFileTemplateDescription);
            this.Controls.Add(this.labeldfsFileTemplateId);
            this.Controls.Add(this.labeldfExtFileTypeDescription);
            this.Controls.Add(this.labeldfsFileType);
            this.Controls.Add(this.labeldfdLogDate);
            this.Controls.Add(this.labeldfsState);
            this.Controls.Add(this.labelccsLoadFileId);
            this.Name = "frmExternalFileLogDetail";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "ExtFileLog");
            this.NamedProperties.Put("PackageName", "EXT_FILE_LOG_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "1");
            this.NamedProperties.Put("ViewName", "EXT_FILE_LOG");
            this.NamedProperties.Put("Warnings", "TRUE");
            this.tblExternalFileLogDetail.ResumeLayout(false);
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

        public Accrul.cChildTableFinBase tblExternalFileLogDetail;
        protected cColumn tblExternalFileLogDetail_colnLoadFileId;
        protected cColumn tblExternalFileLogDetail_colnSeqNo;
        protected cLookupColumn tblExternalFileLogDetail_colsRowState;
        protected cColumn tblExternalFileLogDetail_colnNoOfRecords;
		
	}
}
