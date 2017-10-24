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
	
	public partial class tbwIntfaceReplStructCols
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cColumn colnColumnSeq;
		public cColumn colColumnName;
		public cColumn colsDescription;
		public cColumn colsFlags;
		public cColumn colColumnAlias;
		public cColumn colsParentKeyName;
		public cCheckBoxColumn colsOnInsert;
		public cCheckBoxColumn colsOnUpdate;
		public cColumn colsDataType;
		public cColumn colsIntfaceName;
		public cColumn colnStructureSeq;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwIntfaceReplStructCols));
            this.colnColumnSeq = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colColumnName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsFlags = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colColumnAlias = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsParentKeyName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsOnInsert = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.colsOnUpdate = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.colsDataType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsIntfaceName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colnStructureSeq = new Ifs.Fnd.ApplicationForms.cColumn();
            this.SuspendLayout();
            // 
            // colnColumnSeq
            // 
            this.colnColumnSeq.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colnColumnSeq.Name = "colnColumnSeq";
            this.colnColumnSeq.NamedProperties.Put("EnumerateMethod", "");
            this.colnColumnSeq.NamedProperties.Put("FieldFlags", "163");
            this.colnColumnSeq.NamedProperties.Put("LovReference", "");
            this.colnColumnSeq.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colnColumnSeq.NamedProperties.Put("SqlColumn", "COLUMN_SEQ");
            this.colnColumnSeq.Position = 3;
            resources.ApplyResources(this.colnColumnSeq, "colnColumnSeq");
            // 
            // colColumnName
            // 
            this.colColumnName.MaxLength = 2000;
            this.colColumnName.Name = "colColumnName";
            this.colColumnName.NamedProperties.Put("EnumerateMethod", "");
            this.colColumnName.NamedProperties.Put("FieldFlags", "311");
            this.colColumnName.NamedProperties.Put("LovReference", "");
            this.colColumnName.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colColumnName.NamedProperties.Put("SqlColumn", "COLUMN_NAME");
            this.colColumnName.Position = 4;
            resources.ApplyResources(this.colColumnName, "colColumnName");
            // 
            // colsDescription
            // 
            this.colsDescription.Name = "colsDescription";
            this.colsDescription.NamedProperties.Put("EnumerateMethod", "");
            this.colsDescription.NamedProperties.Put("FieldFlags", "295");
            this.colsDescription.NamedProperties.Put("LovReference", "");
            this.colsDescription.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsDescription.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            this.colsDescription.Position = 5;
            resources.ApplyResources(this.colsDescription, "colsDescription");
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
            this.colsFlags.Position = 6;
            resources.ApplyResources(this.colsFlags, "colsFlags");
            // 
            // colColumnAlias
            // 
            this.colColumnAlias.MaxLength = 2000;
            this.colColumnAlias.Name = "colColumnAlias";
            this.colColumnAlias.NamedProperties.Put("EnumerateMethod", "");
            this.colColumnAlias.NamedProperties.Put("FieldFlags", "310");
            this.colColumnAlias.NamedProperties.Put("LovReference", "");
            this.colColumnAlias.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colColumnAlias.NamedProperties.Put("SqlColumn", "COLUMN_ALIAS");
            this.colColumnAlias.Position = 7;
            resources.ApplyResources(this.colColumnAlias, "colColumnAlias");
            // 
            // colsParentKeyName
            // 
            this.colsParentKeyName.MaxLength = 30;
            this.colsParentKeyName.Name = "colsParentKeyName";
            this.colsParentKeyName.NamedProperties.Put("EnumerateMethod", "");
            this.colsParentKeyName.NamedProperties.Put("FieldFlags", "294");
            this.colsParentKeyName.NamedProperties.Put("LovReference", "");
            this.colsParentKeyName.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsParentKeyName.NamedProperties.Put("SqlColumn", "PARENT_KEY_NAME");
            this.colsParentKeyName.Position = 8;
            resources.ApplyResources(this.colsParentKeyName, "colsParentKeyName");
            // 
            // colsOnInsert
            // 
            this.colsOnInsert.MaxLength = 5;
            this.colsOnInsert.Name = "colsOnInsert";
            this.colsOnInsert.NamedProperties.Put("EnumerateMethod", "");
            this.colsOnInsert.NamedProperties.Put("FieldFlags", "295");
            this.colsOnInsert.NamedProperties.Put("LovReference", "");
            this.colsOnInsert.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsOnInsert.NamedProperties.Put("SqlColumn", "ON_INSERT");
            this.colsOnInsert.Position = 9;
            resources.ApplyResources(this.colsOnInsert, "colsOnInsert");
            // 
            // colsOnUpdate
            // 
            this.colsOnUpdate.MaxLength = 5;
            this.colsOnUpdate.Name = "colsOnUpdate";
            this.colsOnUpdate.NamedProperties.Put("EnumerateMethod", "");
            this.colsOnUpdate.NamedProperties.Put("FieldFlags", "295");
            this.colsOnUpdate.NamedProperties.Put("LovReference", "");
            this.colsOnUpdate.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsOnUpdate.NamedProperties.Put("SqlColumn", "ON_UPDATE");
            this.colsOnUpdate.Position = 10;
            resources.ApplyResources(this.colsOnUpdate, "colsOnUpdate");
            // 
            // colsDataType
            // 
            this.colsDataType.MaxLength = 10;
            this.colsDataType.Name = "colsDataType";
            this.colsDataType.NamedProperties.Put("EnumerateMethod", "");
            this.colsDataType.NamedProperties.Put("FieldFlags", "295");
            this.colsDataType.NamedProperties.Put("LovReference", "");
            this.colsDataType.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsDataType.NamedProperties.Put("SqlColumn", "DATA_TYPE");
            this.colsDataType.Position = 11;
            resources.ApplyResources(this.colsDataType, "colsDataType");
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
            this.colsIntfaceName.Position = 12;
            // 
            // colnStructureSeq
            // 
            this.colnStructureSeq.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.colnStructureSeq, "colnStructureSeq");
            this.colnStructureSeq.Name = "colnStructureSeq";
            this.colnStructureSeq.NamedProperties.Put("EnumerateMethod", "");
            this.colnStructureSeq.NamedProperties.Put("FieldFlags", "67");
            this.colnStructureSeq.NamedProperties.Put("LovReference", "INTFACE_REPL_PARENT_LOV(INTFACE_NAME)");
            this.colnStructureSeq.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colnStructureSeq.NamedProperties.Put("SqlColumn", "STRUCTURE_SEQ");
            this.colnStructureSeq.Position = 13;
            // 
            // tbwIntfaceReplStructCols
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colnColumnSeq);
            this.Controls.Add(this.colColumnName);
            this.Controls.Add(this.colsDescription);
            this.Controls.Add(this.colsFlags);
            this.Controls.Add(this.colColumnAlias);
            this.Controls.Add(this.colsParentKeyName);
            this.Controls.Add(this.colsOnInsert);
            this.Controls.Add(this.colsOnUpdate);
            this.Controls.Add(this.colsDataType);
            this.Controls.Add(this.colsIntfaceName);
            this.Controls.Add(this.colnStructureSeq);
            this.Name = "tbwIntfaceReplStructCols";
            this.NamedProperties.Put("DefaultOrderBy", "column_seq");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "IntfaceReplStructCols");
            this.NamedProperties.Put("PackageName", "INTFACE_REPL_STRUCT_COLS_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "449");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.NamedProperties.Put("ViewName", "INTFACE_REPL_STRUCT_COLS");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tbwIntfaceReplStructCols_WindowActions);
            this.Controls.SetChildIndex(this.colnStructureSeq, 0);
            this.Controls.SetChildIndex(this.colsIntfaceName, 0);
            this.Controls.SetChildIndex(this.colsDataType, 0);
            this.Controls.SetChildIndex(this.colsOnUpdate, 0);
            this.Controls.SetChildIndex(this.colsOnInsert, 0);
            this.Controls.SetChildIndex(this.colsParentKeyName, 0);
            this.Controls.SetChildIndex(this.colColumnAlias, 0);
            this.Controls.SetChildIndex(this.colsFlags, 0);
            this.Controls.SetChildIndex(this.colsDescription, 0);
            this.Controls.SetChildIndex(this.colColumnName, 0);
            this.Controls.SetChildIndex(this.colnColumnSeq, 0);
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
