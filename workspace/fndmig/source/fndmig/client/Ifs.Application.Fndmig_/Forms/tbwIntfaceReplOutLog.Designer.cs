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
	
	public partial class tbwIntfaceReplOutLog
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cColumn colsIntfaceName;
		public cColumn colnLogSeq;
		public cColumn colsKeyAttr;
		public cColumn colnStructureSeq;
		public cColumn colnPos;
		public cColumn colnStartPos;
		public cColumn colsTriggerType;
		public cColumn coldLogDate;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwIntfaceReplOutLog));
            this.colsIntfaceName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colnLogSeq = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsKeyAttr = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colnStructureSeq = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colnPos = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colnStartPos = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsTriggerType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.coldLogDate = new Ifs.Fnd.ApplicationForms.cColumn();
            this.SuspendLayout();
            // 
            // colsIntfaceName
            // 
            this.colsIntfaceName.Name = "colsIntfaceName";
            this.colsIntfaceName.NamedProperties.Put("EnumerateMethod", "");
            this.colsIntfaceName.NamedProperties.Put("FieldFlags", "295");
            this.colsIntfaceName.NamedProperties.Put("LovReference", "");
            this.colsIntfaceName.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsIntfaceName.NamedProperties.Put("SqlColumn", "INTFACE_NAME");
            this.colsIntfaceName.Position = 3;
            resources.ApplyResources(this.colsIntfaceName, "colsIntfaceName");
            // 
            // colnLogSeq
            // 
            this.colnLogSeq.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colnLogSeq.Name = "colnLogSeq";
            this.colnLogSeq.NamedProperties.Put("EnumerateMethod", "");
            this.colnLogSeq.NamedProperties.Put("FieldFlags", "163");
            this.colnLogSeq.NamedProperties.Put("LovReference", "");
            this.colnLogSeq.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colnLogSeq.NamedProperties.Put("SqlColumn", "LOG_SEQ");
            this.colnLogSeq.Position = 4;
            resources.ApplyResources(this.colnLogSeq, "colnLogSeq");
            // 
            // colsKeyAttr
            // 
            this.colsKeyAttr.Name = "colsKeyAttr";
            this.colsKeyAttr.NamedProperties.Put("EnumerateMethod", "");
            this.colsKeyAttr.NamedProperties.Put("FieldFlags", "295");
            this.colsKeyAttr.NamedProperties.Put("LovReference", "");
            this.colsKeyAttr.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsKeyAttr.NamedProperties.Put("SqlColumn", "KEY_ATTR");
            this.colsKeyAttr.NamedProperties.Put("ValidateMethod", "");
            this.colsKeyAttr.Position = 5;
            resources.ApplyResources(this.colsKeyAttr, "colsKeyAttr");
            // 
            // colnStructureSeq
            // 
            this.colnStructureSeq.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colnStructureSeq.Name = "colnStructureSeq";
            this.colnStructureSeq.NamedProperties.Put("EnumerateMethod", "");
            this.colnStructureSeq.NamedProperties.Put("FieldFlags", "295");
            this.colnStructureSeq.NamedProperties.Put("LovReference", "");
            this.colnStructureSeq.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colnStructureSeq.NamedProperties.Put("SqlColumn", "STRUCTURE_SEQ");
            this.colnStructureSeq.Position = 6;
            resources.ApplyResources(this.colnStructureSeq, "colnStructureSeq");
            // 
            // colnPos
            // 
            this.colnPos.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colnPos.Name = "colnPos";
            this.colnPos.NamedProperties.Put("EnumerateMethod", "");
            this.colnPos.NamedProperties.Put("FieldFlags", "295");
            this.colnPos.NamedProperties.Put("LovReference", "");
            this.colnPos.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colnPos.NamedProperties.Put("SqlColumn", "POS");
            this.colnPos.Position = 7;
            resources.ApplyResources(this.colnPos, "colnPos");
            // 
            // colnStartPos
            // 
            this.colnStartPos.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colnStartPos.Name = "colnStartPos";
            this.colnStartPos.NamedProperties.Put("EnumerateMethod", "");
            this.colnStartPos.NamedProperties.Put("FieldFlags", "294");
            this.colnStartPos.NamedProperties.Put("LovReference", "");
            this.colnStartPos.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colnStartPos.NamedProperties.Put("SqlColumn", "START_POS");
            this.colnStartPos.Position = 8;
            resources.ApplyResources(this.colnStartPos, "colnStartPos");
            // 
            // colsTriggerType
            // 
            this.colsTriggerType.Name = "colsTriggerType";
            this.colsTriggerType.NamedProperties.Put("EnumerateMethod", "");
            this.colsTriggerType.NamedProperties.Put("FieldFlags", "295");
            this.colsTriggerType.NamedProperties.Put("LovReference", "");
            this.colsTriggerType.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsTriggerType.NamedProperties.Put("SqlColumn", "TRIGGER_TYPE");
            this.colsTriggerType.Position = 9;
            resources.ApplyResources(this.colsTriggerType, "colsTriggerType");
            // 
            // coldLogDate
            // 
            this.coldLogDate.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.coldLogDate.Format = "d";
            this.coldLogDate.Name = "coldLogDate";
            this.coldLogDate.NamedProperties.Put("EnumerateMethod", "");
            this.coldLogDate.NamedProperties.Put("FieldFlags", "295");
            this.coldLogDate.NamedProperties.Put("LovReference", "");
            this.coldLogDate.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.coldLogDate.NamedProperties.Put("SqlColumn", "LOG_DATE");
            this.coldLogDate.Position = 10;
            resources.ApplyResources(this.coldLogDate, "coldLogDate");
            // 
            // tbwIntfaceReplOutLog
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colsIntfaceName);
            this.Controls.Add(this.colnLogSeq);
            this.Controls.Add(this.colsKeyAttr);
            this.Controls.Add(this.colnStructureSeq);
            this.Controls.Add(this.colnPos);
            this.Controls.Add(this.colnStartPos);
            this.Controls.Add(this.colsTriggerType);
            this.Controls.Add(this.coldLogDate);
            this.Name = "tbwIntfaceReplOutLog";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "IntfaceReplOutLog");
            this.NamedProperties.Put("PackageName", "INTFACE_REPL_OUT_LOG_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "257");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.NamedProperties.Put("ViewName", "INTFACE_REPL_OUT_LOG");
            this.Controls.SetChildIndex(this.coldLogDate, 0);
            this.Controls.SetChildIndex(this.colsTriggerType, 0);
            this.Controls.SetChildIndex(this.colnStartPos, 0);
            this.Controls.SetChildIndex(this.colnPos, 0);
            this.Controls.SetChildIndex(this.colnStructureSeq, 0);
            this.Controls.SetChildIndex(this.colsKeyAttr, 0);
            this.Controls.SetChildIndex(this.colnLogSeq, 0);
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
