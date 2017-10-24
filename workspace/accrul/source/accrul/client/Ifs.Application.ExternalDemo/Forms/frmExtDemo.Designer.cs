#region Copyright (c) IFS Research & Development
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
#endregion
#region History
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ifs.Fnd.ApplicationForms;
using PPJ.Runtime;
using PPJ.Runtime.Windows;

namespace Ifs.Application.ExternalDemo
{

    public partial class frmExtDemo
    {

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExtDemo));
            this.tblExtFileTransDemo = new Ifs.Fnd.ApplicationForms.cChildTable();
            this.cChildTableDetail_colnRowNo = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExtFileTransDemo_colnLoadFileId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.cChildTableDetail_colsFileLine = new Ifs.Fnd.ApplicationForms.cColumn();
            this.cChildTableDetail_colsRowState = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.cChildTableDetail_colnRecordSetNo = new Ifs.Fnd.ApplicationForms.cColumn();
            this.cChildTableDetail_colsRecordTypeId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.cChildTableDetail_colsErrorText = new Ifs.Fnd.ApplicationForms.cColumn();
            this.cChildTableDetail_colsControlId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.dfnLoadFileId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelLoadFileId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfdLoadDate = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelLoadDate = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsStateDb = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelStateDb = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsUserId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelUserId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsFileType = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelFileType = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsSetId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelSetId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsFileTemplateId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelFileTemplateId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsFileName = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelFileName = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbFileDirection = new Ifs.Fnd.ApplicationForms.cComboBox();
            this.labelFileDirection = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tblExtFileTransColDemo = new Ifs.Fnd.ApplicationForms.cChildTable();
            this.cColumn1 = new Ifs.Fnd.ApplicationForms.cColumn();
            this.cColumn4 = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExtFileTransColDemo_colnLoadFileId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExtFileTransColDemo_colsC0 = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExtFileTransColDemo_colsC1 = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExtFileTransColDemo_colsC2 = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExtFileTransColDemo_colsC3 = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExtFileTransColDemo_colsC4 = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExtFileTransColDemo_colsC5 = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExtFileTransColDemo_colsC6 = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExtFileTransColDemo_colsC7 = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExtFileTransColDemo_colsC8 = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExtFileTransColDemo_colsC9 = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExtFileTransColDemo_colsC10 = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExtFileTransColDemo_colsC11 = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExtFileTransColDemo_colsC12 = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExtFileTransColDemo_colsC13 = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExtFileTransColDemo_colsC14 = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExtFileTransColDemo_colsC15 = new Ifs.Fnd.ApplicationForms.cColumn();
            this.Revision = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.tblExtFileTransDemo.SuspendLayout();
            this.tblExtFileTransColDemo.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.Revision);
            this.commandManager.ImageList = null;
            // 
            // tblExtFileTransDemo
            // 
            this.tblExtFileTransDemo.Controls.Add(this.tblExtFileTransDemo_colnLoadFileId);
            this.tblExtFileTransDemo.Controls.Add(this.cChildTableDetail_colnRowNo);
            this.tblExtFileTransDemo.Controls.Add(this.cChildTableDetail_colsFileLine);
            this.tblExtFileTransDemo.Controls.Add(this.cChildTableDetail_colsRowState);
            this.tblExtFileTransDemo.Controls.Add(this.cChildTableDetail_colnRecordSetNo);
            this.tblExtFileTransDemo.Controls.Add(this.cChildTableDetail_colsRecordTypeId);
            this.tblExtFileTransDemo.Controls.Add(this.cChildTableDetail_colsErrorText);
            this.tblExtFileTransDemo.Controls.Add(this.cChildTableDetail_colsControlId);
            resources.ApplyResources(this.tblExtFileTransDemo, "tblExtFileTransDemo");
            this.tblExtFileTransDemo.Name = "tblExtFileTransDemo";
            this.tblExtFileTransDemo.NamedProperties.Put("LogicalUnit", "ExtFileTrans");
            this.tblExtFileTransDemo.NamedProperties.Put("Module", "ACCRUL");
            this.tblExtFileTransDemo.NamedProperties.Put("PackageName", "EXT_FILE_TRANS_API");
            this.tblExtFileTransDemo.NamedProperties.Put("ResizeableChildObject", "MLMM");
            this.tblExtFileTransDemo.NamedProperties.Put("ViewName", "EXT_FILE_TRANS");
            this.tblExtFileTransDemo.Controls.SetChildIndex(this.cChildTableDetail_colsControlId, 0);
            this.tblExtFileTransDemo.Controls.SetChildIndex(this.cChildTableDetail_colsErrorText, 0);
            this.tblExtFileTransDemo.Controls.SetChildIndex(this.cChildTableDetail_colsRecordTypeId, 0);
            this.tblExtFileTransDemo.Controls.SetChildIndex(this.cChildTableDetail_colnRecordSetNo, 0);
            this.tblExtFileTransDemo.Controls.SetChildIndex(this.cChildTableDetail_colsRowState, 0);
            this.tblExtFileTransDemo.Controls.SetChildIndex(this.cChildTableDetail_colsFileLine, 0);
            this.tblExtFileTransDemo.Controls.SetChildIndex(this.cChildTableDetail_colnRowNo, 0);
            this.tblExtFileTransDemo.Controls.SetChildIndex(this.tblExtFileTransDemo_colnLoadFileId, 0);
            // 
            // cChildTableDetail_colnRowNo
            // 
            this.cChildTableDetail_colnRowNo.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.cChildTableDetail_colnRowNo.Name = "cChildTableDetail_colnRowNo";
            this.cChildTableDetail_colnRowNo.NamedProperties.Put("EnumerateMethod", "");
            this.cChildTableDetail_colnRowNo.NamedProperties.Put("FieldFlags", "163");
            this.cChildTableDetail_colnRowNo.NamedProperties.Put("Format", "");
            this.cChildTableDetail_colnRowNo.NamedProperties.Put("LovReference", "");
            this.cChildTableDetail_colnRowNo.NamedProperties.Put("SqlColumn", "ROW_NO");
            this.cChildTableDetail_colnRowNo.Position = 4;
            this.cChildTableDetail_colnRowNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.cChildTableDetail_colnRowNo, "cChildTableDetail_colnRowNo");
            // 
            // tblExtFileTransDemo_colnLoadFileId
            // 
            this.tblExtFileTransDemo_colnLoadFileId.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransDemo_colnLoadFileId.Name = "tblExtFileTransDemo_colnLoadFileId";
            this.tblExtFileTransDemo_colnLoadFileId.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransDemo_colnLoadFileId.NamedProperties.Put("FieldFlags", "99");
            this.tblExtFileTransDemo_colnLoadFileId.NamedProperties.Put("Format", "");
            this.tblExtFileTransDemo_colnLoadFileId.NamedProperties.Put("LovReference", "EXT_FILE_LOAD");
            this.tblExtFileTransDemo_colnLoadFileId.NamedProperties.Put("SqlColumn", "LOAD_FILE_ID");
            this.tblExtFileTransDemo_colnLoadFileId.Position = 3;
            this.tblExtFileTransDemo_colnLoadFileId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblExtFileTransDemo_colnLoadFileId, "tblExtFileTransDemo_colnLoadFileId");
            this.tblExtFileTransDemo_colnLoadFileId.Click += new System.EventHandler(this.tblExtFileTransDemo_colnLoadFileId_Click);
            // 
            // cChildTableDetail_colsFileLine
            // 
            this.cChildTableDetail_colsFileLine.MaxLength = 4000;
            this.cChildTableDetail_colsFileLine.Name = "cChildTableDetail_colsFileLine";
            this.cChildTableDetail_colsFileLine.NamedProperties.Put("EnumerateMethod", "");
            this.cChildTableDetail_colsFileLine.NamedProperties.Put("FieldFlags", "311");
            this.cChildTableDetail_colsFileLine.NamedProperties.Put("LovReference", "");
            this.cChildTableDetail_colsFileLine.NamedProperties.Put("SqlColumn", "FILE_LINE");
            this.cChildTableDetail_colsFileLine.Position = 5;
            resources.ApplyResources(this.cChildTableDetail_colsFileLine, "cChildTableDetail_colsFileLine");
            // 
            // cChildTableDetail_colsRowState
            // 
            this.cChildTableDetail_colsRowState.MaxLength = 200;
            this.cChildTableDetail_colsRowState.Name = "cChildTableDetail_colsRowState";
            this.cChildTableDetail_colsRowState.NamedProperties.Put("EnumerateMethod", "EXT_FILE_ROW_STATE_API.Enumerate");
            this.cChildTableDetail_colsRowState.NamedProperties.Put("FieldFlags", "295");
            this.cChildTableDetail_colsRowState.NamedProperties.Put("LovReference", "");
            this.cChildTableDetail_colsRowState.NamedProperties.Put("SqlColumn", "ROW_STATE");
            this.cChildTableDetail_colsRowState.Position = 6;
            resources.ApplyResources(this.cChildTableDetail_colsRowState, "cChildTableDetail_colsRowState");
            // 
            // cChildTableDetail_colnRecordSetNo
            // 
            this.cChildTableDetail_colnRecordSetNo.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.cChildTableDetail_colnRecordSetNo.Name = "cChildTableDetail_colnRecordSetNo";
            this.cChildTableDetail_colnRecordSetNo.NamedProperties.Put("EnumerateMethod", "");
            this.cChildTableDetail_colnRecordSetNo.NamedProperties.Put("FieldFlags", "294");
            this.cChildTableDetail_colnRecordSetNo.NamedProperties.Put("Format", "");
            this.cChildTableDetail_colnRecordSetNo.NamedProperties.Put("LovReference", "");
            this.cChildTableDetail_colnRecordSetNo.NamedProperties.Put("SqlColumn", "RECORD_SET_NO");
            this.cChildTableDetail_colnRecordSetNo.Position = 7;
            this.cChildTableDetail_colnRecordSetNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.cChildTableDetail_colnRecordSetNo, "cChildTableDetail_colnRecordSetNo");
            // 
            // cChildTableDetail_colsRecordTypeId
            // 
            this.cChildTableDetail_colsRecordTypeId.MaxLength = 20;
            this.cChildTableDetail_colsRecordTypeId.Name = "cChildTableDetail_colsRecordTypeId";
            this.cChildTableDetail_colsRecordTypeId.NamedProperties.Put("EnumerateMethod", "");
            this.cChildTableDetail_colsRecordTypeId.NamedProperties.Put("FieldFlags", "294");
            this.cChildTableDetail_colsRecordTypeId.NamedProperties.Put("LovReference", "");
            this.cChildTableDetail_colsRecordTypeId.NamedProperties.Put("SqlColumn", "RECORD_TYPE_ID");
            this.cChildTableDetail_colsRecordTypeId.Position = 8;
            resources.ApplyResources(this.cChildTableDetail_colsRecordTypeId, "cChildTableDetail_colsRecordTypeId");
            // 
            // cChildTableDetail_colsErrorText
            // 
            this.cChildTableDetail_colsErrorText.MaxLength = 2000;
            this.cChildTableDetail_colsErrorText.Name = "cChildTableDetail_colsErrorText";
            this.cChildTableDetail_colsErrorText.NamedProperties.Put("EnumerateMethod", "");
            this.cChildTableDetail_colsErrorText.NamedProperties.Put("FieldFlags", "310");
            this.cChildTableDetail_colsErrorText.NamedProperties.Put("LovReference", "");
            this.cChildTableDetail_colsErrorText.NamedProperties.Put("SqlColumn", "ERROR_TEXT");
            this.cChildTableDetail_colsErrorText.Position = 9;
            resources.ApplyResources(this.cChildTableDetail_colsErrorText, "cChildTableDetail_colsErrorText");
            // 
            // cChildTableDetail_colsControlId
            // 
            this.cChildTableDetail_colsControlId.MaxLength = 200;
            this.cChildTableDetail_colsControlId.Name = "cChildTableDetail_colsControlId";
            this.cChildTableDetail_colsControlId.NamedProperties.Put("EnumerateMethod", "");
            this.cChildTableDetail_colsControlId.NamedProperties.Put("FieldFlags", "294");
            this.cChildTableDetail_colsControlId.NamedProperties.Put("LovReference", "");
            this.cChildTableDetail_colsControlId.NamedProperties.Put("SqlColumn", "CONTROL_ID");
            this.cChildTableDetail_colsControlId.Position = 10;
            resources.ApplyResources(this.cChildTableDetail_colsControlId, "cChildTableDetail_colsControlId");
            // 
            // dfnLoadFileId
            // 
            this.dfnLoadFileId.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfnLoadFileId, "dfnLoadFileId");
            this.dfnLoadFileId.Name = "dfnLoadFileId";
            this.dfnLoadFileId.NamedProperties.Put("EnumerateMethod", "");
            this.dfnLoadFileId.NamedProperties.Put("FieldFlags", "163");
            this.dfnLoadFileId.NamedProperties.Put("Format", "");
            this.dfnLoadFileId.NamedProperties.Put("LovReference", "");
            this.dfnLoadFileId.NamedProperties.Put("SqlColumn", "LOAD_FILE_ID");
            // 
            // labelLoadFileId
            // 
            resources.ApplyResources(this.labelLoadFileId, "labelLoadFileId");
            this.labelLoadFileId.Name = "labelLoadFileId";
            // 
            // dfdLoadDate
            // 
            this.dfdLoadDate.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.dfdLoadDate.Format = "d";
            resources.ApplyResources(this.dfdLoadDate, "dfdLoadDate");
            this.dfdLoadDate.Name = "dfdLoadDate";
            this.dfdLoadDate.NamedProperties.Put("EnumerateMethod", "");
            this.dfdLoadDate.NamedProperties.Put("FieldFlags", "295");
            this.dfdLoadDate.NamedProperties.Put("LovReference", "");
            this.dfdLoadDate.NamedProperties.Put("SqlColumn", "LOAD_DATE");
            // 
            // labelLoadDate
            // 
            resources.ApplyResources(this.labelLoadDate, "labelLoadDate");
            this.labelLoadDate.Name = "labelLoadDate";
            // 
            // dfsStateDb
            // 
            resources.ApplyResources(this.dfsStateDb, "dfsStateDb");
            this.dfsStateDb.Name = "dfsStateDb";
            this.dfsStateDb.NamedProperties.Put("EnumerateMethod", "");
            this.dfsStateDb.NamedProperties.Put("FieldFlags", "288");
            this.dfsStateDb.NamedProperties.Put("LovReference", "");
            this.dfsStateDb.NamedProperties.Put("SqlColumn", "STATE_DB");
            // 
            // labelStateDb
            // 
            resources.ApplyResources(this.labelStateDb, "labelStateDb");
            this.labelStateDb.Name = "labelStateDb";
            // 
            // dfsUserId
            // 
            resources.ApplyResources(this.dfsUserId, "dfsUserId");
            this.dfsUserId.Name = "dfsUserId";
            this.dfsUserId.NamedProperties.Put("EnumerateMethod", "");
            this.dfsUserId.NamedProperties.Put("FieldFlags", "294");
            this.dfsUserId.NamedProperties.Put("LovReference", "");
            this.dfsUserId.NamedProperties.Put("SqlColumn", "USER_ID");
            this.dfsUserId.TextChanged += new System.EventHandler(this.dfsUserId_TextChanged);
            // 
            // labelUserId
            // 
            resources.ApplyResources(this.labelUserId, "labelUserId");
            this.labelUserId.Name = "labelUserId";
            // 
            // dfsFileType
            // 
            resources.ApplyResources(this.dfsFileType, "dfsFileType");
            this.dfsFileType.Name = "dfsFileType";
            this.dfsFileType.NamedProperties.Put("EnumerateMethod", "");
            this.dfsFileType.NamedProperties.Put("FieldFlags", "288");
            this.dfsFileType.NamedProperties.Put("LovReference", "");
            this.dfsFileType.NamedProperties.Put("SqlColumn", "FILE_TYPE");
            // 
            // labelFileType
            // 
            resources.ApplyResources(this.labelFileType, "labelFileType");
            this.labelFileType.Name = "labelFileType";
            // 
            // dfsSetId
            // 
            resources.ApplyResources(this.dfsSetId, "dfsSetId");
            this.dfsSetId.Name = "dfsSetId";
            this.dfsSetId.NamedProperties.Put("EnumerateMethod", "");
            this.dfsSetId.NamedProperties.Put("FieldFlags", "294");
            this.dfsSetId.NamedProperties.Put("LovReference", "EXT_TYPE_PARAM_SET(FILE_TYPE)");
            this.dfsSetId.NamedProperties.Put("SqlColumn", "SET_ID");
            // 
            // labelSetId
            // 
            resources.ApplyResources(this.labelSetId, "labelSetId");
            this.labelSetId.Name = "labelSetId";
            // 
            // dfsFileTemplateId
            // 
            resources.ApplyResources(this.dfsFileTemplateId, "dfsFileTemplateId");
            this.dfsFileTemplateId.Name = "dfsFileTemplateId";
            this.dfsFileTemplateId.NamedProperties.Put("EnumerateMethod", "");
            this.dfsFileTemplateId.NamedProperties.Put("FieldFlags", "294");
            this.dfsFileTemplateId.NamedProperties.Put("LovReference", "EXT_FILE_TEMPLATE");
            this.dfsFileTemplateId.NamedProperties.Put("SqlColumn", "FILE_TEMPLATE_ID");
            // 
            // labelFileTemplateId
            // 
            resources.ApplyResources(this.labelFileTemplateId, "labelFileTemplateId");
            this.labelFileTemplateId.Name = "labelFileTemplateId";
            // 
            // dfsFileName
            // 
            resources.ApplyResources(this.dfsFileName, "dfsFileName");
            this.dfsFileName.Name = "dfsFileName";
            this.dfsFileName.NamedProperties.Put("EnumerateMethod", "");
            this.dfsFileName.NamedProperties.Put("FieldFlags", "310");
            this.dfsFileName.NamedProperties.Put("LovReference", "");
            this.dfsFileName.NamedProperties.Put("SqlColumn", "FILE_NAME");
            // 
            // labelFileName
            // 
            resources.ApplyResources(this.labelFileName, "labelFileName");
            this.labelFileName.Name = "labelFileName";
            // 
            // cmbFileDirection
            // 
            this.cmbFileDirection.FormattingEnabled = true;
            resources.ApplyResources(this.cmbFileDirection, "cmbFileDirection");
            this.cmbFileDirection.Name = "cmbFileDirection";
            this.cmbFileDirection.NamedProperties.Put("EnumerateMethod", "FILE_DIRECTION_API.Enumerate");
            this.cmbFileDirection.NamedProperties.Put("FieldFlags", "295");
            this.cmbFileDirection.NamedProperties.Put("LovReference", "");
            this.cmbFileDirection.NamedProperties.Put("SqlColumn", "FILE_DIRECTION");
            // 
            // labelFileDirection
            // 
            resources.ApplyResources(this.labelFileDirection, "labelFileDirection");
            this.labelFileDirection.Name = "labelFileDirection";
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            // 
            // textBox2
            // 
            resources.ApplyResources(this.textBox2, "textBox2");
            this.textBox2.Name = "textBox2";
            // 
            // textBox3
            // 
            resources.ApplyResources(this.textBox3, "textBox3");
            this.textBox3.Name = "textBox3";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // tblExtFileTransColDemo
            // 
            this.tblExtFileTransColDemo.Controls.Add(this.cColumn1);
            this.tblExtFileTransColDemo.Controls.Add(this.cColumn4);
            this.tblExtFileTransColDemo.Controls.Add(this.tblExtFileTransColDemo_colnLoadFileId);
            this.tblExtFileTransColDemo.Controls.Add(this.tblExtFileTransColDemo_colsC0);
            this.tblExtFileTransColDemo.Controls.Add(this.tblExtFileTransColDemo_colsC1);
            this.tblExtFileTransColDemo.Controls.Add(this.tblExtFileTransColDemo_colsC2);
            this.tblExtFileTransColDemo.Controls.Add(this.tblExtFileTransColDemo_colsC3);
            this.tblExtFileTransColDemo.Controls.Add(this.tblExtFileTransColDemo_colsC4);
            this.tblExtFileTransColDemo.Controls.Add(this.tblExtFileTransColDemo_colsC5);
            this.tblExtFileTransColDemo.Controls.Add(this.tblExtFileTransColDemo_colsC6);
            this.tblExtFileTransColDemo.Controls.Add(this.tblExtFileTransColDemo_colsC7);
            this.tblExtFileTransColDemo.Controls.Add(this.tblExtFileTransColDemo_colsC8);
            this.tblExtFileTransColDemo.Controls.Add(this.tblExtFileTransColDemo_colsC9);
            this.tblExtFileTransColDemo.Controls.Add(this.tblExtFileTransColDemo_colsC10);
            this.tblExtFileTransColDemo.Controls.Add(this.tblExtFileTransColDemo_colsC11);
            this.tblExtFileTransColDemo.Controls.Add(this.tblExtFileTransColDemo_colsC12);
            this.tblExtFileTransColDemo.Controls.Add(this.tblExtFileTransColDemo_colsC13);
            this.tblExtFileTransColDemo.Controls.Add(this.tblExtFileTransColDemo_colsC14);
            this.tblExtFileTransColDemo.Controls.Add(this.tblExtFileTransColDemo_colsC15);
            resources.ApplyResources(this.tblExtFileTransColDemo, "tblExtFileTransColDemo");
            this.tblExtFileTransColDemo.Name = "tblExtFileTransColDemo";
            this.tblExtFileTransColDemo.NamedProperties.Put("DefaultWhere", "ROW_NO = :i_hWndFrame.frmExtfileTrans.tblExtFileTrans_colnRowNo");
            this.tblExtFileTransColDemo.NamedProperties.Put("LogicalUnit", "ExtFileTrans");
            this.tblExtFileTransColDemo.NamedProperties.Put("Module", "ACCRUL");
            this.tblExtFileTransColDemo.NamedProperties.Put("PackageName", "EXT_FILE_TRANS_API");
            this.tblExtFileTransColDemo.NamedProperties.Put("ResizeableChildObject", "MLMM");
            this.tblExtFileTransColDemo.NamedProperties.Put("ViewName", "EXT_FILE_TRANS");
            this.tblExtFileTransColDemo.Controls.SetChildIndex(this.tblExtFileTransColDemo_colsC15, 0);
            this.tblExtFileTransColDemo.Controls.SetChildIndex(this.tblExtFileTransColDemo_colsC14, 0);
            this.tblExtFileTransColDemo.Controls.SetChildIndex(this.tblExtFileTransColDemo_colsC13, 0);
            this.tblExtFileTransColDemo.Controls.SetChildIndex(this.tblExtFileTransColDemo_colsC12, 0);
            this.tblExtFileTransColDemo.Controls.SetChildIndex(this.tblExtFileTransColDemo_colsC11, 0);
            this.tblExtFileTransColDemo.Controls.SetChildIndex(this.tblExtFileTransColDemo_colsC10, 0);
            this.tblExtFileTransColDemo.Controls.SetChildIndex(this.tblExtFileTransColDemo_colsC9, 0);
            this.tblExtFileTransColDemo.Controls.SetChildIndex(this.tblExtFileTransColDemo_colsC8, 0);
            this.tblExtFileTransColDemo.Controls.SetChildIndex(this.tblExtFileTransColDemo_colsC7, 0);
            this.tblExtFileTransColDemo.Controls.SetChildIndex(this.tblExtFileTransColDemo_colsC6, 0);
            this.tblExtFileTransColDemo.Controls.SetChildIndex(this.tblExtFileTransColDemo_colsC5, 0);
            this.tblExtFileTransColDemo.Controls.SetChildIndex(this.tblExtFileTransColDemo_colsC4, 0);
            this.tblExtFileTransColDemo.Controls.SetChildIndex(this.tblExtFileTransColDemo_colsC3, 0);
            this.tblExtFileTransColDemo.Controls.SetChildIndex(this.tblExtFileTransColDemo_colsC2, 0);
            this.tblExtFileTransColDemo.Controls.SetChildIndex(this.tblExtFileTransColDemo_colsC1, 0);
            this.tblExtFileTransColDemo.Controls.SetChildIndex(this.tblExtFileTransColDemo_colsC0, 0);
            this.tblExtFileTransColDemo.Controls.SetChildIndex(this.tblExtFileTransColDemo_colnLoadFileId, 0);
            this.tblExtFileTransColDemo.Controls.SetChildIndex(this.cColumn4, 0);
            this.tblExtFileTransColDemo.Controls.SetChildIndex(this.cColumn1, 0);
            // 
            // cColumn1
            // 
            this.cColumn1.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.cColumn1.Name = "cColumn1";
            this.cColumn1.NamedProperties.Put("EnumerateMethod", "");
            this.cColumn1.NamedProperties.Put("FieldFlags", "163");
            this.cColumn1.NamedProperties.Put("Format", "");
            this.cColumn1.NamedProperties.Put("LovReference", "");
            this.cColumn1.NamedProperties.Put("SqlColumn", "ROW_NO");
            this.cColumn1.Position = 3;
            this.cColumn1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.cColumn1, "cColumn1");
            // 
            // cColumn4
            // 
            this.cColumn4.MaxLength = 20;
            this.cColumn4.Name = "cColumn4";
            this.cColumn4.NamedProperties.Put("EnumerateMethod", "");
            this.cColumn4.NamedProperties.Put("FieldFlags", "294");
            this.cColumn4.NamedProperties.Put("LovReference", "");
            this.cColumn4.NamedProperties.Put("SqlColumn", "RECORD_TYPE_ID");
            this.cColumn4.Position = 4;
            resources.ApplyResources(this.cColumn4, "cColumn4");
            // 
            // tblExtFileTransColDemo_colnLoadFileId
            // 
            this.tblExtFileTransColDemo_colnLoadFileId.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColDemo_colnLoadFileId.Name = "tblExtFileTransColDemo_colnLoadFileId";
            this.tblExtFileTransColDemo_colnLoadFileId.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColDemo_colnLoadFileId.NamedProperties.Put("FieldFlags", "99");
            this.tblExtFileTransColDemo_colnLoadFileId.NamedProperties.Put("Format", "");
            this.tblExtFileTransColDemo_colnLoadFileId.NamedProperties.Put("LovReference", "EXT_FILE_LOAD");
            this.tblExtFileTransColDemo_colnLoadFileId.NamedProperties.Put("SqlColumn", "LOAD_FILE_ID");
            this.tblExtFileTransColDemo_colnLoadFileId.Position = 5;
            this.tblExtFileTransColDemo_colnLoadFileId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblExtFileTransColDemo_colnLoadFileId, "tblExtFileTransColDemo_colnLoadFileId");
            // 
            // tblExtFileTransColDemo_colsC0
            // 
            this.tblExtFileTransColDemo_colsC0.MaxLength = 2000;
            this.tblExtFileTransColDemo_colsC0.Name = "tblExtFileTransColDemo_colsC0";
            this.tblExtFileTransColDemo_colsC0.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColDemo_colsC0.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColDemo_colsC0.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColDemo_colsC0.NamedProperties.Put("SqlColumn", "C0");
            this.tblExtFileTransColDemo_colsC0.Position = 6;
            resources.ApplyResources(this.tblExtFileTransColDemo_colsC0, "tblExtFileTransColDemo_colsC0");
            // 
            // tblExtFileTransColDemo_colsC1
            // 
            this.tblExtFileTransColDemo_colsC1.MaxLength = 2000;
            this.tblExtFileTransColDemo_colsC1.Name = "tblExtFileTransColDemo_colsC1";
            this.tblExtFileTransColDemo_colsC1.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColDemo_colsC1.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColDemo_colsC1.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColDemo_colsC1.NamedProperties.Put("SqlColumn", "C1");
            this.tblExtFileTransColDemo_colsC1.Position = 7;
            resources.ApplyResources(this.tblExtFileTransColDemo_colsC1, "tblExtFileTransColDemo_colsC1");
            // 
            // tblExtFileTransColDemo_colsC2
            // 
            this.tblExtFileTransColDemo_colsC2.MaxLength = 2000;
            this.tblExtFileTransColDemo_colsC2.Name = "tblExtFileTransColDemo_colsC2";
            this.tblExtFileTransColDemo_colsC2.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColDemo_colsC2.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColDemo_colsC2.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColDemo_colsC2.NamedProperties.Put("SqlColumn", "C2");
            this.tblExtFileTransColDemo_colsC2.Position = 8;
            resources.ApplyResources(this.tblExtFileTransColDemo_colsC2, "tblExtFileTransColDemo_colsC2");
            // 
            // tblExtFileTransColDemo_colsC3
            // 
            this.tblExtFileTransColDemo_colsC3.MaxLength = 2000;
            this.tblExtFileTransColDemo_colsC3.Name = "tblExtFileTransColDemo_colsC3";
            this.tblExtFileTransColDemo_colsC3.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColDemo_colsC3.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColDemo_colsC3.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColDemo_colsC3.NamedProperties.Put("SqlColumn", "C3");
            this.tblExtFileTransColDemo_colsC3.Position = 9;
            resources.ApplyResources(this.tblExtFileTransColDemo_colsC3, "tblExtFileTransColDemo_colsC3");
            // 
            // tblExtFileTransColDemo_colsC4
            // 
            this.tblExtFileTransColDemo_colsC4.MaxLength = 2000;
            this.tblExtFileTransColDemo_colsC4.Name = "tblExtFileTransColDemo_colsC4";
            this.tblExtFileTransColDemo_colsC4.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColDemo_colsC4.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColDemo_colsC4.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColDemo_colsC4.NamedProperties.Put("SqlColumn", "C4");
            this.tblExtFileTransColDemo_colsC4.Position = 10;
            resources.ApplyResources(this.tblExtFileTransColDemo_colsC4, "tblExtFileTransColDemo_colsC4");
            // 
            // tblExtFileTransColDemo_colsC5
            // 
            this.tblExtFileTransColDemo_colsC5.MaxLength = 2000;
            this.tblExtFileTransColDemo_colsC5.Name = "tblExtFileTransColDemo_colsC5";
            this.tblExtFileTransColDemo_colsC5.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColDemo_colsC5.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColDemo_colsC5.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColDemo_colsC5.NamedProperties.Put("SqlColumn", "C5");
            this.tblExtFileTransColDemo_colsC5.Position = 11;
            resources.ApplyResources(this.tblExtFileTransColDemo_colsC5, "tblExtFileTransColDemo_colsC5");
            // 
            // tblExtFileTransColDemo_colsC6
            // 
            this.tblExtFileTransColDemo_colsC6.MaxLength = 2000;
            this.tblExtFileTransColDemo_colsC6.Name = "tblExtFileTransColDemo_colsC6";
            this.tblExtFileTransColDemo_colsC6.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColDemo_colsC6.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColDemo_colsC6.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColDemo_colsC6.NamedProperties.Put("SqlColumn", "C6");
            this.tblExtFileTransColDemo_colsC6.Position = 12;
            resources.ApplyResources(this.tblExtFileTransColDemo_colsC6, "tblExtFileTransColDemo_colsC6");
            // 
            // tblExtFileTransColDemo_colsC7
            // 
            this.tblExtFileTransColDemo_colsC7.MaxLength = 2000;
            this.tblExtFileTransColDemo_colsC7.Name = "tblExtFileTransColDemo_colsC7";
            this.tblExtFileTransColDemo_colsC7.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColDemo_colsC7.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColDemo_colsC7.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColDemo_colsC7.NamedProperties.Put("SqlColumn", "C7");
            this.tblExtFileTransColDemo_colsC7.Position = 13;
            resources.ApplyResources(this.tblExtFileTransColDemo_colsC7, "tblExtFileTransColDemo_colsC7");
            // 
            // tblExtFileTransColDemo_colsC8
            // 
            this.tblExtFileTransColDemo_colsC8.MaxLength = 2000;
            this.tblExtFileTransColDemo_colsC8.Name = "tblExtFileTransColDemo_colsC8";
            this.tblExtFileTransColDemo_colsC8.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColDemo_colsC8.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColDemo_colsC8.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColDemo_colsC8.NamedProperties.Put("SqlColumn", "C8");
            this.tblExtFileTransColDemo_colsC8.Position = 14;
            resources.ApplyResources(this.tblExtFileTransColDemo_colsC8, "tblExtFileTransColDemo_colsC8");
            // 
            // tblExtFileTransColDemo_colsC9
            // 
            this.tblExtFileTransColDemo_colsC9.MaxLength = 2000;
            this.tblExtFileTransColDemo_colsC9.Name = "tblExtFileTransColDemo_colsC9";
            this.tblExtFileTransColDemo_colsC9.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColDemo_colsC9.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColDemo_colsC9.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColDemo_colsC9.NamedProperties.Put("SqlColumn", "C9");
            this.tblExtFileTransColDemo_colsC9.Position = 15;
            resources.ApplyResources(this.tblExtFileTransColDemo_colsC9, "tblExtFileTransColDemo_colsC9");
            // 
            // tblExtFileTransColDemo_colsC10
            // 
            this.tblExtFileTransColDemo_colsC10.MaxLength = 2000;
            this.tblExtFileTransColDemo_colsC10.Name = "tblExtFileTransColDemo_colsC10";
            this.tblExtFileTransColDemo_colsC10.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColDemo_colsC10.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColDemo_colsC10.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColDemo_colsC10.NamedProperties.Put("SqlColumn", "C10");
            this.tblExtFileTransColDemo_colsC10.Position = 16;
            resources.ApplyResources(this.tblExtFileTransColDemo_colsC10, "tblExtFileTransColDemo_colsC10");
            // 
            // tblExtFileTransColDemo_colsC11
            // 
            this.tblExtFileTransColDemo_colsC11.MaxLength = 2000;
            this.tblExtFileTransColDemo_colsC11.Name = "tblExtFileTransColDemo_colsC11";
            this.tblExtFileTransColDemo_colsC11.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColDemo_colsC11.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColDemo_colsC11.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColDemo_colsC11.NamedProperties.Put("SqlColumn", "C11");
            this.tblExtFileTransColDemo_colsC11.Position = 17;
            resources.ApplyResources(this.tblExtFileTransColDemo_colsC11, "tblExtFileTransColDemo_colsC11");
            // 
            // tblExtFileTransColDemo_colsC12
            // 
            this.tblExtFileTransColDemo_colsC12.MaxLength = 4000;
            this.tblExtFileTransColDemo_colsC12.Name = "tblExtFileTransColDemo_colsC12";
            this.tblExtFileTransColDemo_colsC12.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColDemo_colsC12.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColDemo_colsC12.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColDemo_colsC12.NamedProperties.Put("SqlColumn", "C12");
            this.tblExtFileTransColDemo_colsC12.Position = 18;
            resources.ApplyResources(this.tblExtFileTransColDemo_colsC12, "tblExtFileTransColDemo_colsC12");
            // 
            // tblExtFileTransColDemo_colsC13
            // 
            this.tblExtFileTransColDemo_colsC13.MaxLength = 2000;
            this.tblExtFileTransColDemo_colsC13.Name = "tblExtFileTransColDemo_colsC13";
            this.tblExtFileTransColDemo_colsC13.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColDemo_colsC13.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColDemo_colsC13.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColDemo_colsC13.NamedProperties.Put("SqlColumn", "C13");
            this.tblExtFileTransColDemo_colsC13.Position = 19;
            resources.ApplyResources(this.tblExtFileTransColDemo_colsC13, "tblExtFileTransColDemo_colsC13");
            // 
            // tblExtFileTransColDemo_colsC14
            // 
            this.tblExtFileTransColDemo_colsC14.MaxLength = 2000;
            this.tblExtFileTransColDemo_colsC14.Name = "tblExtFileTransColDemo_colsC14";
            this.tblExtFileTransColDemo_colsC14.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColDemo_colsC14.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColDemo_colsC14.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColDemo_colsC14.NamedProperties.Put("SqlColumn", "C14");
            this.tblExtFileTransColDemo_colsC14.Position = 20;
            resources.ApplyResources(this.tblExtFileTransColDemo_colsC14, "tblExtFileTransColDemo_colsC14");
            // 
            // tblExtFileTransColDemo_colsC15
            // 
            this.tblExtFileTransColDemo_colsC15.MaxLength = 2000;
            this.tblExtFileTransColDemo_colsC15.Name = "tblExtFileTransColDemo_colsC15";
            this.tblExtFileTransColDemo_colsC15.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColDemo_colsC15.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColDemo_colsC15.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColDemo_colsC15.NamedProperties.Put("SqlColumn", "C15");
            this.tblExtFileTransColDemo_colsC15.Position = 21;
            resources.ApplyResources(this.tblExtFileTransColDemo_colsC15, "tblExtFileTransColDemo_colsC15");
            // 
            // Revision
            // 
            resources.ApplyResources(this.Revision, "Revision");
            this.Revision.Name = "Revision";
            this.Revision.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.Revision_Execute);
            this.Revision.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.Revision_Inquire);
            // 
            // frmExtDemo
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.tblExtFileTransColDemo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmbFileDirection);
            this.Controls.Add(this.labelFileDirection);
            this.Controls.Add(this.dfsFileName);
            this.Controls.Add(this.labelFileName);
            this.Controls.Add(this.dfsFileTemplateId);
            this.Controls.Add(this.labelFileTemplateId);
            this.Controls.Add(this.dfsSetId);
            this.Controls.Add(this.labelSetId);
            this.Controls.Add(this.dfsFileType);
            this.Controls.Add(this.labelFileType);
            this.Controls.Add(this.dfsUserId);
            this.Controls.Add(this.labelUserId);
            this.Controls.Add(this.dfsStateDb);
            this.Controls.Add(this.labelStateDb);
            this.Controls.Add(this.dfdLoadDate);
            this.Controls.Add(this.labelLoadDate);
            this.Controls.Add(this.dfnLoadFileId);
            this.Controls.Add(this.labelLoadFileId);
            this.Controls.Add(this.tblExtFileTransDemo);
            this.Name = "frmExtDemo";
            this.NamedProperties.Put("LogicalUnit", "ExtFileLoad");
            this.NamedProperties.Put("Module", "ACCRUL");
            this.NamedProperties.Put("PackageName", "EXT_FILE_LOAD_API");
            this.NamedProperties.Put("ViewName", "EXT_FILE_LOAD");
            this.Load += new System.EventHandler(this.frmExtDemo_Load);
            this.tblExtFileTransDemo.ResumeLayout(false);
            this.tblExtFileTransColDemo.ResumeLayout(false);
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

        private cChildTable tblExtFileTransDemo;
        protected cDataField dfnLoadFileId;
        protected cBackgroundText labelLoadFileId;
        protected cDataField dfdLoadDate;
        protected cBackgroundText labelLoadDate;
        protected cDataField dfsStateDb;
        protected cBackgroundText labelStateDb;
        protected cDataField dfsUserId;
        protected cBackgroundText labelUserId;
        protected cDataField dfsFileType;
        protected cBackgroundText labelFileType;
        protected cDataField dfsSetId;
        protected cBackgroundText labelSetId;
        protected cDataField dfsFileTemplateId;
        protected cBackgroundText labelFileTemplateId;
        protected cDataField dfsFileName;
        protected cBackgroundText labelFileName;
        protected cComboBox cmbFileDirection;
        protected cBackgroundText labelFileDirection;
        private Button button1;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Label label1;
        private Label label2;
        private Label label3;
        protected cColumn cChildTableDetail_colnRowNo;
        protected cColumn cChildTableDetail_colsFileLine;
        protected cLookupColumn cChildTableDetail_colsRowState;
        protected cColumn cChildTableDetail_colnRecordSetNo;
        protected cColumn cChildTableDetail_colsRecordTypeId;
        protected cColumn cChildTableDetail_colsErrorText;
        protected cColumn cChildTableDetail_colsControlId;
        private cChildTable tblExtFileTransColDemo;
        protected cColumn cColumn1;
        protected cColumn cColumn4;
        protected Fnd.Windows.Forms.FndCommand Revision;
        protected cColumn tblExtFileTransDemo_colnLoadFileId;
        protected cColumn tblExtFileTransColDemo_colnLoadFileId;
        protected cColumn tblExtFileTransColDemo_colsC0;
        protected cColumn tblExtFileTransColDemo_colsC1;
        protected cColumn tblExtFileTransColDemo_colsC2;
        protected cColumn tblExtFileTransColDemo_colsC3;
        protected cColumn tblExtFileTransColDemo_colsC4;
        protected cColumn tblExtFileTransColDemo_colsC5;
        protected cColumn tblExtFileTransColDemo_colsC6;
        protected cColumn tblExtFileTransColDemo_colsC7;
        protected cColumn tblExtFileTransColDemo_colsC8;
        protected cColumn tblExtFileTransColDemo_colsC9;
        protected cColumn tblExtFileTransColDemo_colsC10;
        protected cColumn tblExtFileTransColDemo_colsC11;
        protected cColumn tblExtFileTransColDemo_colsC12;
        protected cColumn tblExtFileTransColDemo_colsC13;
        protected cColumn tblExtFileTransColDemo_colsC14;
        protected cColumn tblExtFileTransColDemo_colsC15;

        
    }
}
