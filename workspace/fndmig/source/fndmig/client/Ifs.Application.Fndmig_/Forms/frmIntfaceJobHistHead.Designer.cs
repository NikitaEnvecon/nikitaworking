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

using Ifs.Fnd.ApplicationForms;
using PPJ.Runtime.Windows;

namespace Ifs.Application.Fndmig_
{
	
	public partial class frmIntfaceJobHistHead
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		protected SalBackgroundText labelecmbIntfaceName;
        protected cRecListDataField ecmbIntfaceName;
        protected SalBackgroundText labeldfIntfaceHeaderDescription;
        protected cDataField dfIntfaceHeaderDescription;
		protected SalBackgroundText labeldfsExecutedBy;
        protected cDataField dfsExecutedBy;
        protected SalBackgroundText labeldfdDateExecuted;
        protected cDataField dfdDateExecuted;
		protected SalBackgroundText labelcmbStatus;
        protected cComboBox cmbStatus;
		protected SalBackgroundText labeldfnExecutionNo;
        protected cDataField dfnExecutionNo;
        protected SalBackgroundText labeldfsLastInfo;
        protected cDataField dfsLastInfo;
        protected cChildTable tblIntfaceJobHistDetail;
        protected cColumn tblIntfaceJobHistDetail_colsIntfaceName;
        protected cColumn tblIntfaceJobHistDetail_colnExecutionNo;
        protected cColumn tblIntfaceJobHistDetail_colnLineNo;
        protected cColumn tblIntfaceJobHistDetail_colFileString;
        protected cColumn tblIntfaceJobHistDetail_colAttributeString;
        protected cColumn tblIntfaceJobHistDetail_colErrorMessage;
        protected cColumn tblIntfaceJobHistDetail_colsSourceRowid;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIntfaceJobHistHead));
            this.labelecmbIntfaceName = new PPJ.Runtime.Windows.SalBackgroundText();
            this.ecmbIntfaceName = new Ifs.Fnd.ApplicationForms.cRecListDataField();
            this.labeldfIntfaceHeaderDescription = new PPJ.Runtime.Windows.SalBackgroundText();
            this.dfIntfaceHeaderDescription = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsExecutedBy = new PPJ.Runtime.Windows.SalBackgroundText();
            this.dfsExecutedBy = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfdDateExecuted = new PPJ.Runtime.Windows.SalBackgroundText();
            this.dfdDateExecuted = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelcmbStatus = new PPJ.Runtime.Windows.SalBackgroundText();
            this.cmbStatus = new Ifs.Fnd.ApplicationForms.cComboBox();
            this.labeldfnExecutionNo = new PPJ.Runtime.Windows.SalBackgroundText();
            this.dfnExecutionNo = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsLastInfo = new PPJ.Runtime.Windows.SalBackgroundText();
            this.dfsLastInfo = new Ifs.Fnd.ApplicationForms.cDataField();
            this.tblIntfaceJobHistDetail = new Ifs.Fnd.ApplicationForms.cChildTable();
            this.tblIntfaceJobHistDetail_colsIntfaceName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblIntfaceJobHistDetail_colnExecutionNo = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblIntfaceJobHistDetail_colnLineNo = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblIntfaceJobHistDetail_colFileString = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblIntfaceJobHistDetail_colAttributeString = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblIntfaceJobHistDetail_colErrorMessage = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblIntfaceJobHistDetail_colsSourceRowid = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblIntfaceJobHistDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelecmbIntfaceName
            // 
            resources.ApplyResources(this.labelecmbIntfaceName, "labelecmbIntfaceName");
            this.labelecmbIntfaceName.Name = "labelecmbIntfaceName";
            // 
            // ecmbIntfaceName
            // 
            this.ecmbIntfaceName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.ecmbIntfaceName, "ecmbIntfaceName");
            this.ecmbIntfaceName.Name = "ecmbIntfaceName";
            this.ecmbIntfaceName.NamedProperties.Put("EnumerateMethod", "");
            this.ecmbIntfaceName.NamedProperties.Put("FieldFlags", "163");
            this.ecmbIntfaceName.NamedProperties.Put("Format", "9");
            this.ecmbIntfaceName.NamedProperties.Put("LovReference", "");
            this.ecmbIntfaceName.NamedProperties.Put("ResizeableChildObject", "");
            this.ecmbIntfaceName.NamedProperties.Put("SqlColumn", "INTFACE_NAME");
            this.ecmbIntfaceName.NamedProperties.Put("ValidateMethod", "");
            this.ecmbIntfaceName.NamedProperties.Put("XDataLength", "30");
            // 
            // labeldfIntfaceHeaderDescription
            // 
            resources.ApplyResources(this.labeldfIntfaceHeaderDescription, "labeldfIntfaceHeaderDescription");
            this.labeldfIntfaceHeaderDescription.Name = "labeldfIntfaceHeaderDescription";
            // 
            // dfIntfaceHeaderDescription
            // 
            resources.ApplyResources(this.dfIntfaceHeaderDescription, "dfIntfaceHeaderDescription");
            this.dfIntfaceHeaderDescription.Name = "dfIntfaceHeaderDescription";
            this.dfIntfaceHeaderDescription.NamedProperties.Put("EnumerateMethod", "");
            this.dfIntfaceHeaderDescription.NamedProperties.Put("FieldFlags", "288");
            this.dfIntfaceHeaderDescription.NamedProperties.Put("LovReference", "");
            this.dfIntfaceHeaderDescription.NamedProperties.Put("ResizeableChildObject", "LLCL");
            this.dfIntfaceHeaderDescription.NamedProperties.Put("SqlColumn", "INTFACE_HEADER_API.Get_Description(INTFACE_NAME)");
            this.dfIntfaceHeaderDescription.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsExecutedBy
            // 
            resources.ApplyResources(this.labeldfsExecutedBy, "labeldfsExecutedBy");
            this.labeldfsExecutedBy.Name = "labeldfsExecutedBy";
            // 
            // dfsExecutedBy
            // 
            resources.ApplyResources(this.dfsExecutedBy, "dfsExecutedBy");
            this.dfsExecutedBy.Name = "dfsExecutedBy";
            this.dfsExecutedBy.NamedProperties.Put("EnumerateMethod", "");
            this.dfsExecutedBy.NamedProperties.Put("FieldFlags", "289");
            this.dfsExecutedBy.NamedProperties.Put("LovReference", "");
            this.dfsExecutedBy.NamedProperties.Put("SqlColumn", "EXECUTED_BY");
            this.dfsExecutedBy.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfdDateExecuted
            // 
            resources.ApplyResources(this.labeldfdDateExecuted, "labeldfdDateExecuted");
            this.labeldfdDateExecuted.Name = "labeldfdDateExecuted";
            // 
            // dfdDateExecuted
            // 
            this.dfdDateExecuted.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.dfdDateExecuted.Format = "d";
            resources.ApplyResources(this.dfdDateExecuted, "dfdDateExecuted");
            this.dfdDateExecuted.Name = "dfdDateExecuted";
            this.dfdDateExecuted.NamedProperties.Put("EnumerateMethod", "");
            this.dfdDateExecuted.NamedProperties.Put("FieldFlags", "289");
            this.dfdDateExecuted.NamedProperties.Put("LovReference", "");
            this.dfdDateExecuted.NamedProperties.Put("SqlColumn", "DATE_EXECUTED");
            this.dfdDateExecuted.NamedProperties.Put("ValidateMethod", "");
            // 
            // labelcmbStatus
            // 
            resources.ApplyResources(this.labelcmbStatus, "labelcmbStatus");
            this.labelcmbStatus.Name = "labelcmbStatus";
            // 
            // cmbStatus
            // 
            resources.ApplyResources(this.cmbStatus, "cmbStatus");
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.NamedProperties.Put("EnumerateMethod", "INTFACE_JOB_STATUS_API.Enumerate");
            this.cmbStatus.NamedProperties.Put("FieldFlags", "289");
            this.cmbStatus.NamedProperties.Put("LovReference", "");
            this.cmbStatus.NamedProperties.Put("ResizeableChildObject", "LLLL");
            this.cmbStatus.NamedProperties.Put("SqlColumn", "STATUS");
            this.cmbStatus.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfnExecutionNo
            // 
            resources.ApplyResources(this.labeldfnExecutionNo, "labeldfnExecutionNo");
            this.labeldfnExecutionNo.Name = "labeldfnExecutionNo";
            // 
            // dfnExecutionNo
            // 
            this.dfnExecutionNo.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfnExecutionNo, "dfnExecutionNo");
            this.dfnExecutionNo.Name = "dfnExecutionNo";
            this.dfnExecutionNo.NamedProperties.Put("EnumerateMethod", "");
            this.dfnExecutionNo.NamedProperties.Put("FieldFlags", "161");
            this.dfnExecutionNo.NamedProperties.Put("LovReference", "");
            this.dfnExecutionNo.NamedProperties.Put("ResizeableChildObject", "LLCL");
            this.dfnExecutionNo.NamedProperties.Put("SqlColumn", "EXECUTION_NO");
            this.dfnExecutionNo.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsLastInfo
            // 
            resources.ApplyResources(this.labeldfsLastInfo, "labeldfsLastInfo");
            this.labeldfsLastInfo.Name = "labeldfsLastInfo";
            // 
            // dfsLastInfo
            // 
            resources.ApplyResources(this.dfsLastInfo, "dfsLastInfo");
            this.dfsLastInfo.Name = "dfsLastInfo";
            this.dfsLastInfo.NamedProperties.Put("EnumerateMethod", "");
            this.dfsLastInfo.NamedProperties.Put("FieldFlags", "304");
            this.dfsLastInfo.NamedProperties.Put("LovReference", "");
            this.dfsLastInfo.NamedProperties.Put("ResizeableChildObject", "LLCL");
            this.dfsLastInfo.NamedProperties.Put("SqlColumn", "LAST_INFO");
            this.dfsLastInfo.NamedProperties.Put("ValidateMethod", "");
            // 
            // tblIntfaceJobHistDetail
            // 
            this.tblIntfaceJobHistDetail.Controls.Add(this.tblIntfaceJobHistDetail_colsIntfaceName);
            this.tblIntfaceJobHistDetail.Controls.Add(this.tblIntfaceJobHistDetail_colnExecutionNo);
            this.tblIntfaceJobHistDetail.Controls.Add(this.tblIntfaceJobHistDetail_colnLineNo);
            this.tblIntfaceJobHistDetail.Controls.Add(this.tblIntfaceJobHistDetail_colFileString);
            this.tblIntfaceJobHistDetail.Controls.Add(this.tblIntfaceJobHistDetail_colAttributeString);
            this.tblIntfaceJobHistDetail.Controls.Add(this.tblIntfaceJobHistDetail_colErrorMessage);
            this.tblIntfaceJobHistDetail.Controls.Add(this.tblIntfaceJobHistDetail_colsSourceRowid);
            resources.ApplyResources(this.tblIntfaceJobHistDetail, "tblIntfaceJobHistDetail");
            this.tblIntfaceJobHistDetail.Name = "tblIntfaceJobHistDetail";
            this.tblIntfaceJobHistDetail.NamedProperties.Put("DefaultOrderBy", "INTFACE_NAME, EXECUTION_NO, LINE_NO");
            this.tblIntfaceJobHistDetail.NamedProperties.Put("DefaultWhere", "");
            this.tblIntfaceJobHistDetail.NamedProperties.Put("LogicalUnit", "IntfaceJobHistDetail");
            this.tblIntfaceJobHistDetail.NamedProperties.Put("PackageName", "INTFACE_JOB_HIST_DETAIL_TAB");
            this.tblIntfaceJobHistDetail.NamedProperties.Put("ResizeableChildObject", "MLMM");
            this.tblIntfaceJobHistDetail.NamedProperties.Put("SourceFlags", "1");
            this.tblIntfaceJobHistDetail.NamedProperties.Put("ViewName", "INTFACE_JOB_HIST_DETAIL");
            this.tblIntfaceJobHistDetail.NamedProperties.Put("Warnings", "FALSE");
            this.tblIntfaceJobHistDetail.Controls.SetChildIndex(this.tblIntfaceJobHistDetail_colsSourceRowid, 0);
            this.tblIntfaceJobHistDetail.Controls.SetChildIndex(this.tblIntfaceJobHistDetail_colErrorMessage, 0);
            this.tblIntfaceJobHistDetail.Controls.SetChildIndex(this.tblIntfaceJobHistDetail_colAttributeString, 0);
            this.tblIntfaceJobHistDetail.Controls.SetChildIndex(this.tblIntfaceJobHistDetail_colFileString, 0);
            this.tblIntfaceJobHistDetail.Controls.SetChildIndex(this.tblIntfaceJobHistDetail_colnLineNo, 0);
            this.tblIntfaceJobHistDetail.Controls.SetChildIndex(this.tblIntfaceJobHistDetail_colnExecutionNo, 0);
            this.tblIntfaceJobHistDetail.Controls.SetChildIndex(this.tblIntfaceJobHistDetail_colsIntfaceName, 0);
            // 
            // tblIntfaceJobHistDetail_colsIntfaceName
            // 
            this.tblIntfaceJobHistDetail_colsIntfaceName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblIntfaceJobHistDetail_colsIntfaceName, "tblIntfaceJobHistDetail_colsIntfaceName");
            this.tblIntfaceJobHistDetail_colsIntfaceName.MaxLength = 30;
            this.tblIntfaceJobHistDetail_colsIntfaceName.Name = "tblIntfaceJobHistDetail_colsIntfaceName";
            this.tblIntfaceJobHistDetail_colsIntfaceName.NamedProperties.Put("EnumerateMethod", "");
            this.tblIntfaceJobHistDetail_colsIntfaceName.NamedProperties.Put("FieldFlags", "65");
            this.tblIntfaceJobHistDetail_colsIntfaceName.NamedProperties.Put("LovReference", "");
            this.tblIntfaceJobHistDetail_colsIntfaceName.NamedProperties.Put("SqlColumn", "INTFACE_NAME");
            this.tblIntfaceJobHistDetail_colsIntfaceName.NamedProperties.Put("ValidateMethod", "");
            this.tblIntfaceJobHistDetail_colsIntfaceName.Position = 3;
            // 
            // tblIntfaceJobHistDetail_colnExecutionNo
            // 
            this.tblIntfaceJobHistDetail_colnExecutionNo.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.tblIntfaceJobHistDetail_colnExecutionNo, "tblIntfaceJobHistDetail_colnExecutionNo");
            this.tblIntfaceJobHistDetail_colnExecutionNo.Name = "tblIntfaceJobHistDetail_colnExecutionNo";
            this.tblIntfaceJobHistDetail_colnExecutionNo.NamedProperties.Put("EnumerateMethod", "");
            this.tblIntfaceJobHistDetail_colnExecutionNo.NamedProperties.Put("FieldFlags", "65");
            this.tblIntfaceJobHistDetail_colnExecutionNo.NamedProperties.Put("LovReference", "INTFACE_JOB_HIST_HEAD(INTFACE_NAME)");
            this.tblIntfaceJobHistDetail_colnExecutionNo.NamedProperties.Put("SqlColumn", "EXECUTION_NO");
            this.tblIntfaceJobHistDetail_colnExecutionNo.NamedProperties.Put("ValidateMethod", "");
            this.tblIntfaceJobHistDetail_colnExecutionNo.Position = 4;
            // 
            // tblIntfaceJobHistDetail_colnLineNo
            // 
            this.tblIntfaceJobHistDetail_colnLineNo.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblIntfaceJobHistDetail_colnLineNo.Name = "tblIntfaceJobHistDetail_colnLineNo";
            this.tblIntfaceJobHistDetail_colnLineNo.NamedProperties.Put("EnumerateMethod", "");
            this.tblIntfaceJobHistDetail_colnLineNo.NamedProperties.Put("FieldFlags", "161");
            this.tblIntfaceJobHistDetail_colnLineNo.NamedProperties.Put("LovReference", "");
            this.tblIntfaceJobHistDetail_colnLineNo.NamedProperties.Put("SqlColumn", "LINE_NO");
            this.tblIntfaceJobHistDetail_colnLineNo.NamedProperties.Put("ValidateMethod", "");
            this.tblIntfaceJobHistDetail_colnLineNo.Position = 5;
            resources.ApplyResources(this.tblIntfaceJobHistDetail_colnLineNo, "tblIntfaceJobHistDetail_colnLineNo");
            // 
            // tblIntfaceJobHistDetail_colFileString
            // 
            this.tblIntfaceJobHistDetail_colFileString.MaxLength = 4000;
            this.tblIntfaceJobHistDetail_colFileString.Name = "tblIntfaceJobHistDetail_colFileString";
            this.tblIntfaceJobHistDetail_colFileString.NamedProperties.Put("EnumerateMethod", "");
            this.tblIntfaceJobHistDetail_colFileString.NamedProperties.Put("FieldFlags", "304");
            this.tblIntfaceJobHistDetail_colFileString.NamedProperties.Put("LovReference", "");
            this.tblIntfaceJobHistDetail_colFileString.NamedProperties.Put("SqlColumn", "FILE_STRING");
            this.tblIntfaceJobHistDetail_colFileString.NamedProperties.Put("ValidateMethod", "");
            this.tblIntfaceJobHistDetail_colFileString.Position = 6;
            resources.ApplyResources(this.tblIntfaceJobHistDetail_colFileString, "tblIntfaceJobHistDetail_colFileString");
            // 
            // tblIntfaceJobHistDetail_colAttributeString
            // 
            this.tblIntfaceJobHistDetail_colAttributeString.MaxLength = 4000;
            this.tblIntfaceJobHistDetail_colAttributeString.Name = "tblIntfaceJobHistDetail_colAttributeString";
            this.tblIntfaceJobHistDetail_colAttributeString.NamedProperties.Put("EnumerateMethod", "");
            this.tblIntfaceJobHistDetail_colAttributeString.NamedProperties.Put("FieldFlags", "304");
            this.tblIntfaceJobHistDetail_colAttributeString.NamedProperties.Put("LovReference", "");
            this.tblIntfaceJobHistDetail_colAttributeString.NamedProperties.Put("SqlColumn", "ATTRIBUTE_STRING");
            this.tblIntfaceJobHistDetail_colAttributeString.NamedProperties.Put("ValidateMethod", "");
            this.tblIntfaceJobHistDetail_colAttributeString.Position = 7;
            resources.ApplyResources(this.tblIntfaceJobHistDetail_colAttributeString, "tblIntfaceJobHistDetail_colAttributeString");
            // 
            // tblIntfaceJobHistDetail_colErrorMessage
            // 
            this.tblIntfaceJobHistDetail_colErrorMessage.MaxLength = 2000;
            this.tblIntfaceJobHistDetail_colErrorMessage.Name = "tblIntfaceJobHistDetail_colErrorMessage";
            this.tblIntfaceJobHistDetail_colErrorMessage.NamedProperties.Put("EnumerateMethod", "");
            this.tblIntfaceJobHistDetail_colErrorMessage.NamedProperties.Put("FieldFlags", "304");
            this.tblIntfaceJobHistDetail_colErrorMessage.NamedProperties.Put("LovReference", "");
            this.tblIntfaceJobHistDetail_colErrorMessage.NamedProperties.Put("SqlColumn", "ERROR_MESSAGE");
            this.tblIntfaceJobHistDetail_colErrorMessage.NamedProperties.Put("ValidateMethod", "");
            this.tblIntfaceJobHistDetail_colErrorMessage.Position = 8;
            resources.ApplyResources(this.tblIntfaceJobHistDetail_colErrorMessage, "tblIntfaceJobHistDetail_colErrorMessage");
            // 
            // tblIntfaceJobHistDetail_colsSourceRowid
            // 
            this.tblIntfaceJobHistDetail_colsSourceRowid.Name = "tblIntfaceJobHistDetail_colsSourceRowid";
            this.tblIntfaceJobHistDetail_colsSourceRowid.NamedProperties.Put("EnumerateMethod", "");
            this.tblIntfaceJobHistDetail_colsSourceRowid.NamedProperties.Put("FieldFlags", "288");
            this.tblIntfaceJobHistDetail_colsSourceRowid.NamedProperties.Put("LovReference", "");
            this.tblIntfaceJobHistDetail_colsSourceRowid.NamedProperties.Put("SqlColumn", "SOURCE_ROWID");
            this.tblIntfaceJobHistDetail_colsSourceRowid.NamedProperties.Put("ValidateMethod", "");
            this.tblIntfaceJobHistDetail_colsSourceRowid.Position = 9;
            resources.ApplyResources(this.tblIntfaceJobHistDetail_colsSourceRowid, "tblIntfaceJobHistDetail_colsSourceRowid");
            // 
            // frmIntfaceJobHistHead
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.tblIntfaceJobHistDetail);
            this.Controls.Add(this.dfsLastInfo);
            this.Controls.Add(this.dfnExecutionNo);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.dfdDateExecuted);
            this.Controls.Add(this.dfsExecutedBy);
            this.Controls.Add(this.dfIntfaceHeaderDescription);
            this.Controls.Add(this.ecmbIntfaceName);
            this.Controls.Add(this.labeldfsLastInfo);
            this.Controls.Add(this.labeldfnExecutionNo);
            this.Controls.Add(this.labelcmbStatus);
            this.Controls.Add(this.labeldfdDateExecuted);
            this.Controls.Add(this.labeldfsExecutedBy);
            this.Controls.Add(this.labeldfIntfaceHeaderDescription);
            this.Controls.Add(this.labelecmbIntfaceName);
            this.Name = "frmIntfaceJobHistHead";
            this.NamedProperties.Put("DefaultOrderBy", "INTFACE_NAME, EXECUTION_NO DESC");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "IntfaceJobHistHead");
            this.NamedProperties.Put("PackageName", "INTFACE_JOB_HIST_HEAD_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "1");
            this.NamedProperties.Put("ViewName", "INTFACE_JOB_HIST_HEAD");
            this.NamedProperties.Put("Warnings", "TRUE");
            this.tblIntfaceJobHistDetail.ResumeLayout(false);
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
	}
}
