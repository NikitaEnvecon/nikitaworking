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
using Ifs.Fnd.ApplicationForms;
using PPJ.Runtime;
using PPJ.Runtime.Sql;
using PPJ.Runtime.Vis;
using PPJ.Runtime.Windows;
using PPJ.Runtime.Windows.QO;

namespace Ifs.Application.Fndmig_
{
	
	public partial class tbwIntfaceSourceCols
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cColumn colsSourceName;
		public cColumn colsSourceOwner;
		public cColumn colsColumnName;
		public cColumn colsDataType;
		public cColumn colnDataLength;
		public cColumn colnDataPrecision;
		public cColumn colnDataScale;
		public cColumn colnColumnId;
		public cColumn colsNullable;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwIntfaceSourceCols));
            this.colsSourceName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsSourceOwner = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsColumnName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsDataType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colnDataLength = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colnDataPrecision = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colnDataScale = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colnColumnId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsNullable = new Ifs.Fnd.ApplicationForms.cColumn();
            this.SuspendLayout();
            // 
            // colsSourceName
            // 
            this.colsSourceName.MaxLength = 30;
            this.colsSourceName.Name = "colsSourceName";
            this.colsSourceName.NamedProperties.Put("EnumerateMethod", "");
            this.colsSourceName.NamedProperties.Put("FieldFlags", "163");
            this.colsSourceName.NamedProperties.Put("LovReference", "");
            this.colsSourceName.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsSourceName.NamedProperties.Put("SqlColumn", "SOURCE_NAME");
            this.colsSourceName.Position = 3;
            resources.ApplyResources(this.colsSourceName, "colsSourceName");
            // 
            // colsSourceOwner
            // 
            this.colsSourceOwner.MaxLength = 30;
            this.colsSourceOwner.Name = "colsSourceOwner";
            this.colsSourceOwner.NamedProperties.Put("EnumerateMethod", "");
            this.colsSourceOwner.NamedProperties.Put("FieldFlags", "163");
            this.colsSourceOwner.NamedProperties.Put("LovReference", "");
            this.colsSourceOwner.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsSourceOwner.NamedProperties.Put("SqlColumn", "SOURCE_OWNER");
            this.colsSourceOwner.Position = 4;
            resources.ApplyResources(this.colsSourceOwner, "colsSourceOwner");
            // 
            // colsColumnName
            // 
            this.colsColumnName.MaxLength = 30;
            this.colsColumnName.Name = "colsColumnName";
            this.colsColumnName.NamedProperties.Put("EnumerateMethod", "");
            this.colsColumnName.NamedProperties.Put("FieldFlags", "163");
            this.colsColumnName.NamedProperties.Put("LovReference", "");
            this.colsColumnName.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsColumnName.NamedProperties.Put("SqlColumn", "COLUMN_NAME");
            this.colsColumnName.Position = 5;
            resources.ApplyResources(this.colsColumnName, "colsColumnName");
            // 
            // colsDataType
            // 
            this.colsDataType.MaxLength = 9;
            this.colsDataType.Name = "colsDataType";
            this.colsDataType.NamedProperties.Put("EnumerateMethod", "");
            this.colsDataType.NamedProperties.Put("FieldFlags", "291");
            this.colsDataType.NamedProperties.Put("LovReference", "");
            this.colsDataType.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsDataType.NamedProperties.Put("SqlColumn", "DATA_TYPE");
            this.colsDataType.Position = 6;
            resources.ApplyResources(this.colsDataType, "colsDataType");
            // 
            // colnDataLength
            // 
            this.colnDataLength.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colnDataLength.Name = "colnDataLength";
            this.colnDataLength.NamedProperties.Put("EnumerateMethod", "");
            this.colnDataLength.NamedProperties.Put("FieldFlags", "291");
            this.colnDataLength.NamedProperties.Put("LovReference", "");
            this.colnDataLength.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colnDataLength.NamedProperties.Put("SqlColumn", "DATA_LENGTH");
            this.colnDataLength.Position = 7;
            resources.ApplyResources(this.colnDataLength, "colnDataLength");
            // 
            // colnDataPrecision
            // 
            this.colnDataPrecision.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colnDataPrecision.Name = "colnDataPrecision";
            this.colnDataPrecision.NamedProperties.Put("EnumerateMethod", "");
            this.colnDataPrecision.NamedProperties.Put("FieldFlags", "291");
            this.colnDataPrecision.NamedProperties.Put("LovReference", "");
            this.colnDataPrecision.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colnDataPrecision.NamedProperties.Put("SqlColumn", "DATA_PRECISION");
            this.colnDataPrecision.Position = 8;
            resources.ApplyResources(this.colnDataPrecision, "colnDataPrecision");
            // 
            // colnDataScale
            // 
            this.colnDataScale.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colnDataScale.Name = "colnDataScale";
            this.colnDataScale.NamedProperties.Put("EnumerateMethod", "");
            this.colnDataScale.NamedProperties.Put("FieldFlags", "291");
            this.colnDataScale.NamedProperties.Put("LovReference", "");
            this.colnDataScale.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colnDataScale.NamedProperties.Put("SqlColumn", "DATA_SCALE");
            this.colnDataScale.Position = 9;
            resources.ApplyResources(this.colnDataScale, "colnDataScale");
            // 
            // colnColumnId
            // 
            this.colnColumnId.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colnColumnId.Name = "colnColumnId";
            this.colnColumnId.NamedProperties.Put("EnumerateMethod", "");
            this.colnColumnId.NamedProperties.Put("FieldFlags", "294");
            this.colnColumnId.NamedProperties.Put("LovReference", "");
            this.colnColumnId.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colnColumnId.NamedProperties.Put("SqlColumn", "COLUMN_ID");
            this.colnColumnId.Position = 10;
            resources.ApplyResources(this.colnColumnId, "colnColumnId");
            // 
            // colsNullable
            // 
            this.colsNullable.MaxLength = 1;
            this.colsNullable.Name = "colsNullable";
            this.colsNullable.NamedProperties.Put("EnumerateMethod", "");
            this.colsNullable.NamedProperties.Put("FieldFlags", "291");
            this.colsNullable.NamedProperties.Put("LovReference", "");
            this.colsNullable.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsNullable.NamedProperties.Put("SqlColumn", "NULLABLE");
            this.colsNullable.Position = 11;
            resources.ApplyResources(this.colsNullable, "colsNullable");
            // 
            // tbwIntfaceSourceCols
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colsSourceName);
            this.Controls.Add(this.colsSourceOwner);
            this.Controls.Add(this.colsColumnName);
            this.Controls.Add(this.colsDataType);
            this.Controls.Add(this.colnDataLength);
            this.Controls.Add(this.colnDataPrecision);
            this.Controls.Add(this.colnDataScale);
            this.Controls.Add(this.colnColumnId);
            this.Controls.Add(this.colsNullable);
            this.Name = "tbwIntfaceSourceCols";
            this.NamedProperties.Put("DefaultOrderBy", "SOURCE_OWNER, SOURCE_NAME,COLUMN_ID");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "IntfaceViews");
            this.NamedProperties.Put("PackageName", "");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "448");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.NamedProperties.Put("ViewName", "INTFACE_SOURCE_COL_LOV");
            this.Controls.SetChildIndex(this.colsNullable, 0);
            this.Controls.SetChildIndex(this.colnColumnId, 0);
            this.Controls.SetChildIndex(this.colnDataScale, 0);
            this.Controls.SetChildIndex(this.colnDataPrecision, 0);
            this.Controls.SetChildIndex(this.colnDataLength, 0);
            this.Controls.SetChildIndex(this.colsDataType, 0);
            this.Controls.SetChildIndex(this.colsColumnName, 0);
            this.Controls.SetChildIndex(this.colsSourceOwner, 0);
            this.Controls.SetChildIndex(this.colsSourceName, 0);
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
