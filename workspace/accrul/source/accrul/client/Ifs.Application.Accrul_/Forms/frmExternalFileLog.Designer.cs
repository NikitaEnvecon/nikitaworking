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
	
	public partial class frmExternalFileLog
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		protected cBackgroundText labelccsLoadFileId;
		public cRecListDataField ccsLoadFileId;
		protected cBackgroundText labeldfdLoadDate;
		public cDataField dfdLoadDate;
		protected cBackgroundText labeldfsUserId;
		public cDataField dfsUserId;
		protected cBackgroundText labeldfsFileType;
		public cDataField dfsFileType;
		protected cBackgroundText labeldfExtFileTypeDescription;
		public cDataField dfExtFileTypeDescription;
		protected cBackgroundText labeldfsState;
		public cDataField dfsState;
		protected cBackgroundText labeldfsFileTemplateId;
		public cDataField dfsFileTemplateId;
		protected cBackgroundText labeldfExtFileTemplateDescription;
		public cDataField dfExtFileTemplateDescription;
		protected cBackgroundText labeldfFileDirection;
		public cDataField dfFileDirection;
        public Accrul.cChildTableFinBase tblExternalFileLog;
        protected cColumn tblExternalFileLog_colnLoadFileId;
        protected cColumn tblExternalFileLog_colnSeqNo;
        protected cColumn tblExternalFileLog_colsState;
        protected cColumn tblExternalFileLog_coldLogDate;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExternalFileLog));
            this.menuTblMethods_menuExternal_File_Log__Details___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.labelccsLoadFileId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.ccsLoadFileId = new Ifs.Fnd.ApplicationForms.cRecListDataField();
            this.labeldfdLoadDate = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfdLoadDate = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsUserId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsUserId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsFileType = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsFileType = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfExtFileTypeDescription = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfExtFileTypeDescription = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsState = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsState = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsFileTemplateId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsFileTemplateId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfExtFileTemplateDescription = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfExtFileTemplateDescription = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfFileDirection = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfFileDirection = new Ifs.Fnd.ApplicationForms.cDataField();
            this.menuTblMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_External = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.tblExternalFileLog = new Ifs.Application.Accrul.cChildTableFinBase();
            this.tblExternalFileLog_colnLoadFileId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExternalFileLog_colnSeqNo = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExternalFileLog_colsState = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExternalFileLog_coldLogDate = new Ifs.Fnd.ApplicationForms.cColumn();
            this.menuTblMethods.SuspendLayout();
            this.tblExternalFileLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuTblMethods_menuExternal_File_Log__Details___);
            this.commandManager.ContextMenus.Add(this.menuTblMethods);
            // 
            // menuTblMethods_menuExternal_File_Log__Details___
            // 
            resources.ApplyResources(this.menuTblMethods_menuExternal_File_Log__Details___, "menuTblMethods_menuExternal_File_Log__Details___");
            this.menuTblMethods_menuExternal_File_Log__Details___.Name = "menuTblMethods_menuExternal_File_Log__Details___";
            this.menuTblMethods_menuExternal_File_Log__Details___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_External_Execute);
            this.menuTblMethods_menuExternal_File_Log__Details___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_External_Inquire);
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
            // labeldfdLoadDate
            // 
            resources.ApplyResources(this.labeldfdLoadDate, "labeldfdLoadDate");
            this.labeldfdLoadDate.Name = "labeldfdLoadDate";
            // 
            // dfdLoadDate
            // 
            this.dfdLoadDate.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.dfdLoadDate.Format = "d";
            resources.ApplyResources(this.dfdLoadDate, "dfdLoadDate");
            this.dfdLoadDate.Name = "dfdLoadDate";
            this.dfdLoadDate.NamedProperties.Put("EnumerateMethod", "");
            this.dfdLoadDate.NamedProperties.Put("FieldFlags", "291");
            this.dfdLoadDate.NamedProperties.Put("LovReference", "");
            this.dfdLoadDate.NamedProperties.Put("ParentName", "ccsLoadFileId");
            this.dfdLoadDate.NamedProperties.Put("ResizeableChildObject", "");
            this.dfdLoadDate.NamedProperties.Put("SqlColumn", "LOAD_DATE");
            this.dfdLoadDate.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsUserId
            // 
            resources.ApplyResources(this.labeldfsUserId, "labeldfsUserId");
            this.labeldfsUserId.Name = "labeldfsUserId";
            // 
            // dfsUserId
            // 
            resources.ApplyResources(this.dfsUserId, "dfsUserId");
            this.dfsUserId.Name = "dfsUserId";
            this.dfsUserId.NamedProperties.Put("EnumerateMethod", "");
            this.dfsUserId.NamedProperties.Put("FieldFlags", "290");
            this.dfsUserId.NamedProperties.Put("LovReference", "");
            this.dfsUserId.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsUserId.NamedProperties.Put("SqlColumn", "USER_ID");
            this.dfsUserId.NamedProperties.Put("ValidateMethod", "");
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
            this.dfsFileType.NamedProperties.Put("LovReference", "EXT_FILE_MODULE_NAME");
            this.dfsFileType.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsFileType.NamedProperties.Put("SqlColumn", "FILE_TYPE");
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
            this.dfExtFileTypeDescription.NamedProperties.Put("SqlColumn", "EXT_FILE_TYPE_API.Get_Description(FILE_TYPE)");
            this.dfExtFileTypeDescription.NamedProperties.Put("ValidateMethod", "");
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
            this.dfsState.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsState.NamedProperties.Put("SqlColumn", "STATE");
            this.dfsState.NamedProperties.Put("ValidateMethod", "");
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
            this.dfsFileTemplateId.NamedProperties.Put("LovReference", "EXT_FILE_TEMPLATE");
            this.dfsFileTemplateId.NamedProperties.Put("ParentName", "ccsLoadFileId");
            this.dfsFileTemplateId.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsFileTemplateId.NamedProperties.Put("SqlColumn", "FILE_TEMPLATE_ID");
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
            this.dfExtFileTemplateDescription.NamedProperties.Put("SqlColumn", "EXT_FILE_TEMPLATE_API.Get_Description(FILE_TEMPLATE_ID)");
            this.dfExtFileTemplateDescription.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfFileDirection
            // 
            resources.ApplyResources(this.labeldfFileDirection, "labeldfFileDirection");
            this.labeldfFileDirection.Name = "labeldfFileDirection";
            // 
            // dfFileDirection
            // 
            resources.ApplyResources(this.dfFileDirection, "dfFileDirection");
            this.dfFileDirection.Name = "dfFileDirection";
            this.dfFileDirection.NamedProperties.Put("EnumerateMethod", "");
            this.dfFileDirection.NamedProperties.Put("FieldFlags", "257");
            this.dfFileDirection.NamedProperties.Put("LovReference", "");
            this.dfFileDirection.NamedProperties.Put("ResizeableChildObject", "");
            this.dfFileDirection.NamedProperties.Put("SqlColumn", "FILE_DIRECTION");
            this.dfFileDirection.NamedProperties.Put("ValidateMethod", "");
            // 
            // menuTblMethods
            // 
            this.menuTblMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_External});
            this.menuTblMethods.Name = "menuTblMethods";
            resources.ApplyResources(this.menuTblMethods, "menuTblMethods");
            // 
            // menuItem_External
            // 
            this.menuItem_External.Command = this.menuTblMethods_menuExternal_File_Log__Details___;
            this.menuItem_External.Name = "menuItem_External";
            resources.ApplyResources(this.menuItem_External, "menuItem_External");
            this.menuItem_External.Text = "External File Log &Details...";
            // 
            // tblExternalFileLog
            // 
            this.tblExternalFileLog.Controls.Add(this.tblExternalFileLog_colnLoadFileId);
            this.tblExternalFileLog.Controls.Add(this.tblExternalFileLog_colnSeqNo);
            this.tblExternalFileLog.Controls.Add(this.tblExternalFileLog_colsState);
            this.tblExternalFileLog.Controls.Add(this.tblExternalFileLog_coldLogDate);
            resources.ApplyResources(this.tblExternalFileLog, "tblExternalFileLog");
            this.tblExternalFileLog.Name = "tblExternalFileLog";
            this.tblExternalFileLog.NamedProperties.Put("DefaultOrderBy", "SEQ_NO");
            this.tblExternalFileLog.NamedProperties.Put("DefaultWhere", "");
            this.tblExternalFileLog.NamedProperties.Put("LogicalUnit", "ExtFileLog");
            this.tblExternalFileLog.NamedProperties.Put("PackageName", "EXT_FILE_LOG_API");
            this.tblExternalFileLog.NamedProperties.Put("ResizeableChildObject", "LLMM");
            this.tblExternalFileLog.NamedProperties.Put("SourceFlags", "1");
            this.tblExternalFileLog.NamedProperties.Put("ViewName", "EXT_FILE_LOG");
            this.tblExternalFileLog.NamedProperties.Put("Warnings", "FALSE");
            this.tblExternalFileLog.Controls.SetChildIndex(this.tblExternalFileLog_coldLogDate, 0);
            this.tblExternalFileLog.Controls.SetChildIndex(this.tblExternalFileLog_colsState, 0);
            this.tblExternalFileLog.Controls.SetChildIndex(this.tblExternalFileLog_colnSeqNo, 0);
            this.tblExternalFileLog.Controls.SetChildIndex(this.tblExternalFileLog_colnLoadFileId, 0);
            // 
            // tblExternalFileLog_colnLoadFileId
            // 
            this.tblExternalFileLog_colnLoadFileId.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.tblExternalFileLog_colnLoadFileId, "tblExternalFileLog_colnLoadFileId");
            this.tblExternalFileLog_colnLoadFileId.Name = "tblExternalFileLog_colnLoadFileId";
            this.tblExternalFileLog_colnLoadFileId.NamedProperties.Put("EnumerateMethod", "");
            this.tblExternalFileLog_colnLoadFileId.NamedProperties.Put("FieldFlags", "67");
            this.tblExternalFileLog_colnLoadFileId.NamedProperties.Put("LovReference", "EXT_FILE_LOAD");
            this.tblExternalFileLog_colnLoadFileId.NamedProperties.Put("SqlColumn", "LOAD_FILE_ID");
            this.tblExternalFileLog_colnLoadFileId.Position = 3;
            // 
            // tblExternalFileLog_colnSeqNo
            // 
            this.tblExternalFileLog_colnSeqNo.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.tblExternalFileLog_colnSeqNo, "tblExternalFileLog_colnSeqNo");
            this.tblExternalFileLog_colnSeqNo.Name = "tblExternalFileLog_colnSeqNo";
            this.tblExternalFileLog_colnSeqNo.NamedProperties.Put("EnumerateMethod", "");
            this.tblExternalFileLog_colnSeqNo.NamedProperties.Put("FieldFlags", "163");
            this.tblExternalFileLog_colnSeqNo.NamedProperties.Put("LovReference", "");
            this.tblExternalFileLog_colnSeqNo.NamedProperties.Put("SqlColumn", "SEQ_NO");
            this.tblExternalFileLog_colnSeqNo.Position = 4;
            // 
            // tblExternalFileLog_colsState
            // 
            this.tblExternalFileLog_colsState.MaxLength = 200;
            this.tblExternalFileLog_colsState.Name = "tblExternalFileLog_colsState";
            this.tblExternalFileLog_colsState.NamedProperties.Put("EnumerateMethod", "");
            this.tblExternalFileLog_colsState.NamedProperties.Put("FieldFlags", "290");
            this.tblExternalFileLog_colsState.NamedProperties.Put("LovReference", "");
            this.tblExternalFileLog_colsState.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExternalFileLog_colsState.NamedProperties.Put("SqlColumn", "STATE");
            this.tblExternalFileLog_colsState.NamedProperties.Put("ValidateMethod", "");
            this.tblExternalFileLog_colsState.Position = 5;
            resources.ApplyResources(this.tblExternalFileLog_colsState, "tblExternalFileLog_colsState");
            // 
            // tblExternalFileLog_coldLogDate
            // 
            this.tblExternalFileLog_coldLogDate.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.tblExternalFileLog_coldLogDate.Format = "G";
            this.tblExternalFileLog_coldLogDate.Name = "tblExternalFileLog_coldLogDate";
            this.tblExternalFileLog_coldLogDate.NamedProperties.Put("EnumerateMethod", "");
            this.tblExternalFileLog_coldLogDate.NamedProperties.Put("FieldFlags", "291");
            this.tblExternalFileLog_coldLogDate.NamedProperties.Put("LovReference", "");
            this.tblExternalFileLog_coldLogDate.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExternalFileLog_coldLogDate.NamedProperties.Put("SqlColumn", "LOG_DATE");
            this.tblExternalFileLog_coldLogDate.NamedProperties.Put("ValidateMethod", "");
            this.tblExternalFileLog_coldLogDate.Position = 6;
            resources.ApplyResources(this.tblExternalFileLog_coldLogDate, "tblExternalFileLog_coldLogDate");
            // 
            // frmExternalFileLog
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.tblExternalFileLog);
            this.Controls.Add(this.dfFileDirection);
            this.Controls.Add(this.dfExtFileTemplateDescription);
            this.Controls.Add(this.dfsFileTemplateId);
            this.Controls.Add(this.dfsState);
            this.Controls.Add(this.dfExtFileTypeDescription);
            this.Controls.Add(this.dfsFileType);
            this.Controls.Add(this.dfsUserId);
            this.Controls.Add(this.dfdLoadDate);
            this.Controls.Add(this.ccsLoadFileId);
            this.Controls.Add(this.labeldfFileDirection);
            this.Controls.Add(this.labeldfExtFileTemplateDescription);
            this.Controls.Add(this.labeldfsFileTemplateId);
            this.Controls.Add(this.labeldfsState);
            this.Controls.Add(this.labeldfExtFileTypeDescription);
            this.Controls.Add(this.labeldfsFileType);
            this.Controls.Add(this.labeldfsUserId);
            this.Controls.Add(this.labeldfdLoadDate);
            this.Controls.Add(this.labelccsLoadFileId);
            this.Name = "frmExternalFileLog";
            this.NamedProperties.Put("DefaultOrderBy", "LOAD_FILE_ID DESC");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "ExtFileLoad");
            this.NamedProperties.Put("PackageName", "EXT_FILE_LOAD_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "1");
            this.NamedProperties.Put("ViewName", "EXT_FILE_LOAD");
            this.NamedProperties.Put("Warnings", "TRUE");
            this.menuTblMethods.ResumeLayout(false);
            this.tblExternalFileLog.ResumeLayout(false);
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
		
        public Fnd.Windows.Forms.FndCommand menuTblMethods_menuExternal_File_Log__Details___;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTblMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_External;

	}
}
