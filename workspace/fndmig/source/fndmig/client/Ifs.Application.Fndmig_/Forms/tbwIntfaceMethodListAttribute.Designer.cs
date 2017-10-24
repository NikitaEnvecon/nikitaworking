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
	
	public partial class tbwIntfaceMethodListAttribute
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cColumn colsIntfaceName;
		public cColumn colnExecuteSeq;
		public cColumn colnColumnSequence;
		public cColumn colsColumnName;
		public cColumn colsDescription;
		public cColumn colFixedValue;
		public cColumn colsFlags;
		public cCheckBoxColumn colsOnNew;
		public cCheckBoxColumn colsOnModify;
		public cColumn colsLuReference;
		public cColumn colIidValues;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwIntfaceMethodListAttribute));
            this.colsIntfaceName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colnExecuteSeq = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colnColumnSequence = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsColumnName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colFixedValue = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsFlags = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsOnNew = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.colsOnModify = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.colsLuReference = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colIidValues = new Ifs.Fnd.ApplicationForms.cColumn();
            this.SuspendLayout();
            // 
            // colsIntfaceName
            // 
            this.colsIntfaceName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.colsIntfaceName, "colsIntfaceName");
            this.colsIntfaceName.MaxLength = 30;
            this.colsIntfaceName.Name = "colsIntfaceName";
            this.colsIntfaceName.NamedProperties.Put("EnumerateMethod", "");
            this.colsIntfaceName.NamedProperties.Put("FieldFlags", "67");
            this.colsIntfaceName.NamedProperties.Put("LovReference", "");
            this.colsIntfaceName.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsIntfaceName.NamedProperties.Put("SqlColumn", "INTFACE_NAME");
            this.colsIntfaceName.Position = 3;
            // 
            // colnExecuteSeq
            // 
            this.colnExecuteSeq.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.colnExecuteSeq, "colnExecuteSeq");
            this.colnExecuteSeq.Name = "colnExecuteSeq";
            this.colnExecuteSeq.NamedProperties.Put("EnumerateMethod", "");
            this.colnExecuteSeq.NamedProperties.Put("FieldFlags", "67");
            this.colnExecuteSeq.NamedProperties.Put("LovReference", "INTFACE_METHOD_LIST(INTFACE_NAME)");
            this.colnExecuteSeq.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colnExecuteSeq.NamedProperties.Put("SqlColumn", "EXECUTE_SEQ");
            this.colnExecuteSeq.Position = 4;
            // 
            // colnColumnSequence
            // 
            this.colnColumnSequence.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colnColumnSequence.Name = "colnColumnSequence";
            this.colnColumnSequence.NamedProperties.Put("EnumerateMethod", "");
            this.colnColumnSequence.NamedProperties.Put("FieldFlags", "163");
            this.colnColumnSequence.NamedProperties.Put("LovReference", "");
            this.colnColumnSequence.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colnColumnSequence.NamedProperties.Put("ResizeableChildObject", "");
            this.colnColumnSequence.NamedProperties.Put("SqlColumn", "COLUMN_SEQUENCE");
            this.colnColumnSequence.NamedProperties.Put("ValidateMethod", "");
            this.colnColumnSequence.Position = 5;
            resources.ApplyResources(this.colnColumnSequence, "colnColumnSequence");
            // 
            // colsColumnName
            // 
            this.colsColumnName.MaxLength = 30;
            this.colsColumnName.Name = "colsColumnName";
            this.colsColumnName.NamedProperties.Put("EnumerateMethod", "");
            this.colsColumnName.NamedProperties.Put("FieldFlags", "291");
            this.colsColumnName.NamedProperties.Put("LovReference", "");
            this.colsColumnName.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsColumnName.NamedProperties.Put("SqlColumn", "COLUMN_NAME");
            this.colsColumnName.Position = 6;
            resources.ApplyResources(this.colsColumnName, "colsColumnName");
            // 
            // colsDescription
            // 
            this.colsDescription.Name = "colsDescription";
            this.colsDescription.NamedProperties.Put("EnumerateMethod", "");
            this.colsDescription.NamedProperties.Put("FieldFlags", "290");
            this.colsDescription.NamedProperties.Put("LovReference", "");
            this.colsDescription.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.colsDescription.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            this.colsDescription.NamedProperties.Put("ValidateMethod", "");
            this.colsDescription.Position = 7;
            resources.ApplyResources(this.colsDescription, "colsDescription");
            // 
            // colFixedValue
            // 
            this.colFixedValue.MaxLength = 2000;
            this.colFixedValue.Name = "colFixedValue";
            this.colFixedValue.NamedProperties.Put("EnumerateMethod", "");
            this.colFixedValue.NamedProperties.Put("FieldFlags", "310");
            this.colFixedValue.NamedProperties.Put("LovReference", "");
            this.colFixedValue.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colFixedValue.NamedProperties.Put("SqlColumn", "FIXED_VALUE");
            this.colFixedValue.Position = 8;
            resources.ApplyResources(this.colFixedValue, "colFixedValue");
            // 
            // colsFlags
            // 
            this.colsFlags.MaxLength = 5;
            this.colsFlags.Name = "colsFlags";
            this.colsFlags.NamedProperties.Put("EnumerateMethod", "");
            this.colsFlags.NamedProperties.Put("FieldFlags", "295");
            this.colsFlags.NamedProperties.Put("LovReference", "");
            this.colsFlags.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsFlags.NamedProperties.Put("SqlColumn", "FLAGS");
            this.colsFlags.Position = 9;
            resources.ApplyResources(this.colsFlags, "colsFlags");
            // 
            // colsOnNew
            // 
            this.colsOnNew.MaxLength = 5;
            this.colsOnNew.Name = "colsOnNew";
            this.colsOnNew.NamedProperties.Put("EnumerateMethod", "");
            this.colsOnNew.NamedProperties.Put("FieldFlags", "294");
            this.colsOnNew.NamedProperties.Put("LovReference", "");
            this.colsOnNew.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsOnNew.NamedProperties.Put("ResizeableChildObject", "");
            this.colsOnNew.NamedProperties.Put("SqlColumn", "ON_NEW");
            this.colsOnNew.NamedProperties.Put("ValidateMethod", "");
            this.colsOnNew.Position = 10;
            resources.ApplyResources(this.colsOnNew, "colsOnNew");
            // 
            // colsOnModify
            // 
            this.colsOnModify.MaxLength = 5;
            this.colsOnModify.Name = "colsOnModify";
            this.colsOnModify.NamedProperties.Put("EnumerateMethod", "");
            this.colsOnModify.NamedProperties.Put("FieldFlags", "294");
            this.colsOnModify.NamedProperties.Put("LovReference", "");
            this.colsOnModify.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsOnModify.NamedProperties.Put("ResizeableChildObject", "");
            this.colsOnModify.NamedProperties.Put("SqlColumn", "ON_MODIFY");
            this.colsOnModify.NamedProperties.Put("ValidateMethod", "");
            this.colsOnModify.Position = 11;
            resources.ApplyResources(this.colsOnModify, "colsOnModify");
            // 
            // colsLuReference
            // 
            this.colsLuReference.MaxLength = 50;
            this.colsLuReference.Name = "colsLuReference";
            this.colsLuReference.NamedProperties.Put("EnumerateMethod", "");
            this.colsLuReference.NamedProperties.Put("FieldFlags", "290");
            this.colsLuReference.NamedProperties.Put("LovReference", "");
            this.colsLuReference.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsLuReference.NamedProperties.Put("ResizeableChildObject", "");
            this.colsLuReference.NamedProperties.Put("SqlColumn", "LU_REFERENCE");
            this.colsLuReference.NamedProperties.Put("ValidateMethod", "");
            this.colsLuReference.Position = 12;
            resources.ApplyResources(this.colsLuReference, "colsLuReference");
            // 
            // colIidValues
            // 
            this.colIidValues.MaxLength = 2000;
            this.colIidValues.Name = "colIidValues";
            this.colIidValues.NamedProperties.Put("EnumerateMethod", "");
            this.colIidValues.NamedProperties.Put("FieldFlags", "306");
            this.colIidValues.NamedProperties.Put("LovReference", "");
            this.colIidValues.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colIidValues.NamedProperties.Put("ResizeableChildObject", "");
            this.colIidValues.NamedProperties.Put("SqlColumn", "IID_VALUES");
            this.colIidValues.NamedProperties.Put("ValidateMethod", "");
            this.colIidValues.Position = 13;
            resources.ApplyResources(this.colIidValues, "colIidValues");
            // 
            // tbwIntfaceMethodListAttribute
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colsIntfaceName);
            this.Controls.Add(this.colnExecuteSeq);
            this.Controls.Add(this.colnColumnSequence);
            this.Controls.Add(this.colsColumnName);
            this.Controls.Add(this.colsDescription);
            this.Controls.Add(this.colFixedValue);
            this.Controls.Add(this.colsFlags);
            this.Controls.Add(this.colsOnNew);
            this.Controls.Add(this.colsOnModify);
            this.Controls.Add(this.colsLuReference);
            this.Controls.Add(this.colIidValues);
            this.Name = "tbwIntfaceMethodListAttribute";
            this.NamedProperties.Put("DefaultOrderBy", "column_sequence");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "IntfaceMethodListAttrib");
            this.NamedProperties.Put("PackageName", "INTFACE_METHOD_LIST_ATTRIB_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "449");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.NamedProperties.Put("ViewName", "INTFACE_METHOD_LIST_ATTRIB");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tbwIntfaceMethodListAttribute_WindowActions);
            this.Controls.SetChildIndex(this.colIidValues, 0);
            this.Controls.SetChildIndex(this.colsLuReference, 0);
            this.Controls.SetChildIndex(this.colsOnModify, 0);
            this.Controls.SetChildIndex(this.colsOnNew, 0);
            this.Controls.SetChildIndex(this.colsFlags, 0);
            this.Controls.SetChildIndex(this.colFixedValue, 0);
            this.Controls.SetChildIndex(this.colsDescription, 0);
            this.Controls.SetChildIndex(this.colsColumnName, 0);
            this.Controls.SetChildIndex(this.colnColumnSequence, 0);
            this.Controls.SetChildIndex(this.colnExecuteSeq, 0);
            this.Controls.SetChildIndex(this.colsIntfaceName, 0);
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
