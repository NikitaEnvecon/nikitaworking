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
	
	public partial class tbwExternalFileIdentity
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cColumn colsIdentity;
		public cColumn coldLoadDate;
		public cColumn colsFileName;
		public cColumn colsUserId;
		public cColumn colParameterString;
		public cColumn colsFileTemplateId;
		public cColumn colsFileType;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwExternalFileIdentity));
            this.colsIdentity = new Ifs.Fnd.ApplicationForms.cColumn();
            this.coldLoadDate = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsFileName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsUserId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colParameterString = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsFileTemplateId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsFileType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.SuspendLayout();
            // 
            // colsIdentity
            // 
            this.colsIdentity.MaxLength = 200;
            this.colsIdentity.Name = "colsIdentity";
            this.colsIdentity.NamedProperties.Put("EnumerateMethod", "");
            this.colsIdentity.NamedProperties.Put("FieldFlags", "163");
            this.colsIdentity.NamedProperties.Put("LovReference", "");
            this.colsIdentity.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsIdentity.NamedProperties.Put("SqlColumn", "IDENTITY");
            this.colsIdentity.Position = 3;
            resources.ApplyResources(this.colsIdentity, "colsIdentity");
            // 
            // coldLoadDate
            // 
            this.coldLoadDate.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.coldLoadDate.Format = "d";
            this.coldLoadDate.Name = "coldLoadDate";
            this.coldLoadDate.NamedProperties.Put("EnumerateMethod", "");
            this.coldLoadDate.NamedProperties.Put("FieldFlags", "294");
            this.coldLoadDate.NamedProperties.Put("LovReference", "");
            this.coldLoadDate.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.coldLoadDate.NamedProperties.Put("SqlColumn", "LOAD_DATE");
            this.coldLoadDate.Position = 4;
            resources.ApplyResources(this.coldLoadDate, "coldLoadDate");
            // 
            // colsFileName
            // 
            this.colsFileName.MaxLength = 200;
            this.colsFileName.Name = "colsFileName";
            this.colsFileName.NamedProperties.Put("EnumerateMethod", "");
            this.colsFileName.NamedProperties.Put("FieldFlags", "294");
            this.colsFileName.NamedProperties.Put("LovReference", "");
            this.colsFileName.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsFileName.NamedProperties.Put("ResizeableChildObject", "");
            this.colsFileName.NamedProperties.Put("SqlColumn", "FILE_NAME");
            this.colsFileName.NamedProperties.Put("ValidateMethod", "");
            this.colsFileName.Position = 5;
            resources.ApplyResources(this.colsFileName, "colsFileName");
            // 
            // colsUserId
            // 
            this.colsUserId.MaxLength = 30;
            this.colsUserId.Name = "colsUserId";
            this.colsUserId.NamedProperties.Put("EnumerateMethod", "");
            this.colsUserId.NamedProperties.Put("FieldFlags", "294");
            this.colsUserId.NamedProperties.Put("LovReference", "");
            this.colsUserId.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsUserId.NamedProperties.Put("SqlColumn", "USER_ID");
            this.colsUserId.Position = 6;
            resources.ApplyResources(this.colsUserId, "colsUserId");
            // 
            // colParameterString
            // 
            this.colParameterString.MaxLength = 2000;
            this.colParameterString.Name = "colParameterString";
            this.colParameterString.NamedProperties.Put("EnumerateMethod", "");
            this.colParameterString.NamedProperties.Put("FieldFlags", "310");
            this.colParameterString.NamedProperties.Put("LovReference", "");
            this.colParameterString.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colParameterString.NamedProperties.Put("SqlColumn", "PARAMETER_STRING");
            this.colParameterString.Position = 7;
            resources.ApplyResources(this.colParameterString, "colParameterString");
            // 
            // colsFileTemplateId
            // 
            this.colsFileTemplateId.MaxLength = 30;
            this.colsFileTemplateId.Name = "colsFileTemplateId";
            this.colsFileTemplateId.NamedProperties.Put("EnumerateMethod", "");
            this.colsFileTemplateId.NamedProperties.Put("FieldFlags", "294");
            this.colsFileTemplateId.NamedProperties.Put("LovReference", "");
            this.colsFileTemplateId.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsFileTemplateId.NamedProperties.Put("SqlColumn", "FILE_TEMPLATE_ID");
            this.colsFileTemplateId.Position = 8;
            resources.ApplyResources(this.colsFileTemplateId, "colsFileTemplateId");
            // 
            // colsFileType
            // 
            this.colsFileType.MaxLength = 30;
            this.colsFileType.Name = "colsFileType";
            this.colsFileType.NamedProperties.Put("EnumerateMethod", "");
            this.colsFileType.NamedProperties.Put("FieldFlags", "294");
            this.colsFileType.NamedProperties.Put("LovReference", "");
            this.colsFileType.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsFileType.NamedProperties.Put("SqlColumn", "FILE_TYPE");
            this.colsFileType.Position = 9;
            resources.ApplyResources(this.colsFileType, "colsFileType");
            // 
            // tbwExternalFileIdentity
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colsIdentity);
            this.Controls.Add(this.coldLoadDate);
            this.Controls.Add(this.colsFileName);
            this.Controls.Add(this.colsUserId);
            this.Controls.Add(this.colParameterString);
            this.Controls.Add(this.colsFileTemplateId);
            this.Controls.Add(this.colsFileType);
            this.Name = "tbwExternalFileIdentity";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "ExtFileIdentity");
            this.NamedProperties.Put("PackageName", "EXT_FILE_IDENTITY_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "257");
            this.NamedProperties.Put("ViewName", "EXT_FILE_IDENTITY");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.Controls.SetChildIndex(this.colsFileType, 0);
            this.Controls.SetChildIndex(this.colsFileTemplateId, 0);
            this.Controls.SetChildIndex(this.colParameterString, 0);
            this.Controls.SetChildIndex(this.colsUserId, 0);
            this.Controls.SetChildIndex(this.colsFileName, 0);
            this.Controls.SetChildIndex(this.coldLoadDate, 0);
            this.Controls.SetChildIndex(this.colsIdentity, 0);
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
